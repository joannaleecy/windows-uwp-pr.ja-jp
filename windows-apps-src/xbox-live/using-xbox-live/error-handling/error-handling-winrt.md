---
title: WinRT API のエラー処理
author: KevinAsgari
description: WinRT API を使って Xbox Live サービス呼び出しを行ったときのエラーを処理する方法について説明します。
ms.assetid: b4f04798-df91-430e-90f0-83b5a48b9ab2
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one, エラー処理
ms.localizationpriority: medium
ms.openlocfilehash: 706a9c7ccaa9188bef046c814cb19e8568fd26b7
ms.sourcegitcommit: f5321b525034e2b3af202709e9b942ad5557e193
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/18/2018
ms.locfileid: "4018109"
---
# <a name="winrt-api-error-handling"></a>WinRT API のエラー処理

C++/CX、C#、JavaScript から呼び出すことができる WinRT API では、エラーは例外を使用して報告されるので、try/catch ブロックを使用してエラーを処理する必要があります。

非同期呼び出しの場合は次のように 2 つの try/catch ブロックが必要であることに注意してください。

```cpp
    try
    {
        auto asyncOp = xboxLiveContext->TitleStorageService->UploadBlobAsync(
            blobMetadata,
            blobBuffer,
            TitleStorageETagMatchCondition::NotUsed,
            DEFAULT_UPLOAD_BLOCK_SIZE
            );

        create_task(asyncOp)
        .then([this, ui]( task<TitleStorageBlobMetadata^> t )
        {
            try
            {
                TitleStorageBlobMetadata^ blobMetadata = t.get();

                ui->Log(L"UploadBlobAsync succeeded");
                PrintBlobMetadata(ui, blobMetadata);

                SaveNewETag(blobMetadata->ETag);
            }
            catch (Platform::Exception^ ex)
            {
                // This could happen if there's a network error or the service returns an error
                ui->Log("The async task of UploadBlobAsync failed with", ex->ToString());
            }
        });
    }
    catch (Platform::Exception^ ex)
    {
        // This could happen if there's invalid args sent to the API
        ui->Log("The API call to UploadBlobAsync failed with", ex->ToString());
    }
```

XSAPI の非同期メソッドには、メソッドが呼び出されたときに同期的に実行されるコードがあります。  同期コードは、入力引数の検証や、非同期の操作/処理の開始というようなことを行います。  したがって、非同期メソッドの呼び出しであっても例外が発生する可能性がありますが、通常のシナリオでは発生しないはずです (つまり、ネットワークのエラーではなくプログラマのエラー)。  この可能性を考慮して、入力を検証し、開発中にコードをしっかりとテストすることによって、問題の発生を防いでください。  呼び出しの周辺または呼び出し履歴の上位レベルのどちらに配置するにしても、重要なのはどこかで try/catch を使用することです。

## <a name="help-my-game-crashes-when-i-call-xyz-xbox-service-api"></a>トラブルシューティング XYZ という Xbox Service API を呼び出すとゲームがクラッシュします

ゲームがクラッシュして、呼び出し履歴は Xbox Service API の呼び出しを示しているのですね。確認してみましょう。

```cpp
msvcr110.dll!Concurrency::details::_ReportUnobservedException() Line 2455    C++
Social110Release.exe!Concurrency::details::_ExceptionHolder::~_ExceptionHolder() Line 915    C++
Social110Release.exe!Concurrency::details::_Task_impl_base::~_Task_impl_base() Line 1488    C++
Social110Release.exe!Concurrency::details::_Task_impl<Microsoft::Xbox::Services::Social::XboxUserProfile ^ __ptr64>::`scalar deleting destructor'(unsigned int)    C++
Social110Release.exe!Concurrency::task<Microsoft::Xbox::Services::Social::XboxUserProfile ^ __ptr64>::_ContinuationTaskHandle<Microsoft::Xbox::Services::Social::XboxUserProfile ^ __ptr64,void,<lambda_8571b6148830c0805feee6ba9e76a692>,std::integral_constant<bool,1>,Concurrency::details::_TypeSelectorNoAsync>::`scalar deleting destructor'(unsigned int)    C++
msvcr110.dll!Concurrency::details::_TaskCollection::_NotifyCompletedChoreAndFree(Concurrency::details::_UnrealizedChore * pChore) Line 1171    C++
msvcr110.dll!Concurrency::details::_UnrealizedChore::_UnstructuredChoreWrapper(Concurrency::details::_UnrealizedChore * pChore) Line 373    C++
msvcr110.dll!Concurrency::details::InternalContextBase::Dispatch(Concurrency::DispatchState * pDispatchState) Line 1716    C++
msvcr110.dll!Concurrency::details::FreeThreadProxy::Dispatch() Line 203    C++
msvcr110.dll!Concurrency::details::ThreadProxy::ThreadProxyMain(void * lpParameter) Line 174    C++
ntdll.dll!RtlUserThreadStart(long (void *) * StartAddress, void * Argument) Line 822    C++
```

上記の呼び出し履歴はとてもわかりにくいですね。  Concurrency があちこちに出現します。  Microsoft::Xbox::Services::Social::XboxUserProfile が呼び出し履歴にあるので、きっとこれが原因に違いない、と思ってしまいます。  実際には、これは無効な Xbox User ID に対する GetUserProfileAsync の呼び出しによって生成された呼び出し履歴です。この呼び出し履歴を生成したサンプル コードは次のようなものです。

```cpp
    auto pAsyncOp = requester->ProfileService->GetUserProfileAsync("abc123"); //passing invalid Xbox User Id;

    create_task( pAsyncOp )
    .then( [this] (task<XboxUserProfile^> resultTask)
    {
        // Oops, I forgot my exception handling code here.
        // If I don't call resultTask.get() and catch any potential exception it may throw,
        // then PPL will report an unobserved exception.  That unobserved exception will cause your
        // app to crash.
    });
```

実際の呼び出し履歴に Concurrency::_ReportUnobservedException() が含まれているでしょうか。  上記の呼び出し履歴をもう一度よく見てください。  これは非常に重要です。  呼び出し履歴に Concurrency::_ReportUnobservedException() が含まれている場合、ゲームのコードにバグがあることになります。

PPL はタスクを作成し、他のタスクがそれに続くことがあります。  上記の例では、create_task() によって GetUserProfileAsync() を呼び出すタスクが作成され、.then() によって後続のタスクが作成されます。  これらは、先行タスク (最初のタスク) および継続タスク (2 番目のタスク) と呼ばれることがあります。  この例では、継続タスクにエラー処理がありません。  タスクが例外をスローし、そのタスクまたは継続タスクの 1 つで例外がキャッチされない場合、ランタイムはアプリを終了します。

継続タスクに関しては、実際には 2 つの異なる種類があることに注意してください。  1 番目はタスク ベースの継続であり、前のタスクを入力引数として受け取ります。  このタスクは、先行タスクが例外をスローした場合でも常に実行されます。  先行タスクの結果を取得するには、引数で .get() を呼び出す必要があります。  2 番目は値に基づくもので、前のタスクの出力を直接受け取ります。これは一点を除けばシンタックス シュガーのようなものです。先行タスクが例外をスローした場合、値ベースの継続タスクはまったく実行されません。

推奨事項: クラッシュを防ぐため、継続チェーンの最後にはタスク ベースの継続を使用し、すべての concurrency::task::get() または concurrency::task::wait() 呼び出しを try/catch ブロックで囲んでリカバリー可能なエラーを処理します。

以下に例をいくつか示します。

タスク ベースの継続の例

```cpp
    create_task( pAsyncOp )
    .then( [this] (task<XboxUserProfile^> resultTask)   // Task-based continuation
    {
        try
        {
            XboxUserProfile^ result = resultTask.get();

            // success, do something
        }
        catch (Platform::Exception^ ex)
        {
            // concurrency::task::get threw an exception
            // safely handle the error here
        }
    });
```

値ベースの継続の例

```cpp
    create_task( pAsyncOp )
    .then( [this] (XboxUserProfile^ result) // Value-based continuation
    {
        // The task completed successfully, do something here.
        // if the task didn't complete successfully, you'd better have a task-based
        // continuation at the end of the continuation chain or the app will crash.
    })
    .then( [this] (task<void> previousTask) // Task-based continuation
    {
        try
        {
            // DO NOT IGNORE THIS THINKING IT'S NOT IMPORTANT.

            // call concurrency::task::get and handle any unobserved exception
            // so the application doesn't crash.
            previousTask.get();

            // success, continue
        }
        catch (Platform::Exception^ ex)
        {
            // concurrency::task::get threw an exception
            // safely handle the error here
            // By handling this exception, you ensure your application will not
            // crash when calling Xbox Service APIs
        }
    });
```

3 つ目のソリューションでは、値ベースの継続を完全に使用しますが、.get() または .wait() を別のスレッドで呼び出して、そこで例外をキャッチします。  次に単純な例を示します。

```cpp
    auto getProfileTask = create_task( pAsyncOp )
    .then( [this] (XboxUserProfile^ result) // Value-based continuation
    {
        // The task completed successfully, do something here.
    });
    // Note the lack of a task-based continuation with error handling at the end

    // You may call .get() or .wait() on a value-based only chain, but
    // must ensure you surround the call in a try/catch block and handle errors
    try
    {
        getProfileTask.get();     // or getProfileTask.wait();
    }
    catch (Platform::Exception^ ex)
    {
        // concurrency::task::get threw an exception
        // safely handle the error here
        // By handling this exception, you ensure your application will not
        // crash when calling Xbox Service APIs
    }
```

**PPL を使用しない場合** PPL の代わりに AsyncOperationCompletionHandler または AsyncActionCompletionHandler を使用する場合も、正しく行わないとアプリケーションがクラッシュするエラー処理がいくつかあります。  エラー処理方法の例を次に示します。

```cpp
    try
    {
        // Example is making a service call with an invalid XboxUserId which will result in an error.
        // The completion handler properly detects the error and does not crash the app.
        requester->ProfileService->GetUserProfileAsync("abc123")->Completed
            = ref new AsyncOperationCompletedHandler<XboxUserProfile^>([=] (IAsyncOperation<XboxUserProfile^>^ operation, Windows::Foundation::AsyncStatus status)
        {
            if( status == Windows::Foundation::AsyncStatus::Completed)
            {
                // Always check the AsyncStatus before calling GetResults().
                // If status is not AsyncStatus::Completed, calls to operation->GetResults()
                // may throw an exception.
                // You can also surround this call in a try/catch block for added safety.

                XboxUserProfile^ result = operation->GetResults();

                // success, do something with the result
            }
            else if( status == Windows::Foundation::AsyncStatus::Error )
            {
                // Failed
            }
        });
    }
    catch ( Platform::COMException^ ex )
    {
        // What is this try/catch block for?
        //
        // Xbox Service APIs do have some code that runs synchronously and errors need
        // to be safely handled.  In this example, if “” was passed instead of “abc123”,
        // then an invalid argument exception would be thrown when calling GetUserProfileAsync
    // See the next section for more a more detailed explanation.
        //
        // Note: this catch block will NOT catch exceptions thrown within the completion handler.
    }
```

**GetNextAsync() と例外** ページング API を使用していますか。  AchievementResult、LeaderboardResult、InventoryItemResult、TitleStorageBlobMetadataResult などのオブジェクトにはすべて、結果の次のページを要求するための GetNextAsync() メソッドが含まれます。  それ以上データがない特殊なケースがあり、GetNextAsync() を呼び出すと例外をトリガーします。  この例外は、GetNextAsync() の同期実行中にスローされます。  この場合、GetNextAsync メソッドは INET_E_DATA_NOT_AVAILABLE (0x800C0007) をスローします。

推奨事項: GetNextAsync() メソッドの呼び出しを try/catch ブロックで囲んで、INET_E_DATA_NOT_AVAILABLE のケースを適切に処理します。

```cpp
    try
    {
        // AchievementResult^ LastResult

        // Get next page of achievement results
        if(LastResult != nullptr)
        {
            auto getNextPage = LastResult->GetNextAsync(10);

            // create_task( getNextPage ) ...
        }
    }
    catch (Platform::Exception^ ex)
    {
        if (ex->HResult == INET_E_DATA_NOT_AVAILABLE)
        {
                // we hit the end of the achievements
        }
        else
        {
            // failed for unexpected reason
        }
    }
```
