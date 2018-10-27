---
author: normesta
ms.assetid: 34C00F9F-2196-46A3-A32F-0067AB48291B
description: この記事では VisualC コンポーネント拡張機能での非同期メソッドに推奨される方法について説明します。 (、C++/cli CX) ppltasks.h の concurrency 名前空間で定義された task クラスを使用しています。
title: C++ での非同期プログラミング
ms.author: normesta
ms.date: 05/14/2018
ms.topic: article
keywords: Windows 10、UWP、スレッド、非同期、C++
ms.localizationpriority: medium
ms.openlocfilehash: 33b110e713608260cd5c19544292e9211904a730
ms.sourcegitcommit: 086001cffaf436e6e4324761d59bcc5e598c15ea
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/27/2018
ms.locfileid: "5687775"
---
# <a name="asynchronous-programming-in-ccx"></a>C++/CX での非同期プログラミング
> [!NOTE]
> このトピックは、C++/CX アプリケーションの管理ができるようにすることを目的としています。 ただし、新しいアプリケーションには [C++/WinRT](../cpp-and-winrt-apis/intro-to-using-cpp-with-winrt.md) を使用することをお勧めします。 C++/WinRT は Windows ランタイム (WinRT) API の標準的な最新の C++17 言語プロジェクションで、ヘッダー ファイル ベースのライブラリとして実装され、最新の Windows API への最上位アクセス権を提供するように設計されています。

この記事では VisualC コンポーネント拡張機能での非同期メソッドに推奨される方法について説明します。 (、C++/cli CX) を使用して、`task`クラスで定義されている、 `concurrency` ppltasks.h で名前空間です。

## <a name="universal-windows-platform-uwp-asynchronous-types"></a>ユニバーサル Windows プラットフォーム (UWP) の非同期型
ユニバーサル Windows プラットフォーム (UWP) には、非同期メソッドを呼び出すためのモデルが明確に定義されており、非同期メソッドを使う必要がある型があります。 UWP の非同期モデルについて詳しくない場合は、この記事の前に「[非同期プログラミング][AsyncProgramming]」をご覧ください。

非同期 UWP API は C++ で直接使うこともできますが、[**task class**][task-class] とそれに関連する型と関数を使うことをお勧めします。これは [**concurrency**][concurrencyNamespace] 名前空間のクラスで、`<ppltasks.h>` で定義されています。 **concurrency::task** は汎用型のクラスですが、**/ZW** コンパイラ スイッチ (ユニバーサル Windows プラットフォーム (UWP) アプリとそのコンポーネントには必須) を使うと、task クラスで UWP の非同期型をカプセル化して次の処理を簡単に行うことができます。

-   複数の非同期操作や同期操作を 1 つのチェーンで連結する

-   タスク チェーンで例外を処理する

-   タスク チェーンで取り消しを実行する

-   各タスクを適切なスレッド コンテキストまたはスレッド アパートメントで実行する

ここでは、**task** クラスを UWP の非同期 API で使う方法に関する基本的なガイダンスを示しています。 **task** クラスと、[**create\_task**][createTask] を含む関連メソッドの詳細については、[タスクの並列処理 (同時実行ランタイム)][taskParallelism] を参照してください。 

## <a name="consuming-an-async-operation-by-using-a-task"></a>タスクを使った非同期操作の使用
次の例は、task クラスを使って、[**IAsyncOperation**][IAsyncOperation] インターフェイスを返す **async** メソッドを使う方法を示しています。この操作では値が生成されます。 基本的な手順は次のとおりです。

1.  `create_task` メソッドを呼び出し、**IAsyncOperation** オブジェクトに渡します。

2.  タスクのメンバー関数 [**task::then**][taskThen] を呼び出し、非同期操作の完了時に呼び出すラムダを指定します。

``` cpp
#include <ppltasks.h>
using namespace concurrency;
using namespace Windows::Devices::Enumeration;
...
void App::TestAsync()
{    
    //Call the *Async method that starts the operation.
    IAsyncOperation<DeviceInformationCollection^>^ deviceOp =
        DeviceInformation::FindAllAsync();

    // Explicit construction. (Not recommended)
    // Pass the IAsyncOperation to a task constructor.
    // task<DeviceInformationCollection^> deviceEnumTask(deviceOp);

    // Recommended:
    auto deviceEnumTask = create_task(deviceOp);

    // Call the task's .then member function, and provide
    // the lambda to be invoked when the async operation completes.
    deviceEnumTask.then( [this] (DeviceInformationCollection^ devices )
    {       
        for(int i = 0; i < devices->Size; i++)
        {
            DeviceInformation^ di = devices->GetAt(i);
            // Do something with di...          
        }       
    }); // end lambda
    // Continue doing work or return...
}
```

[**task::then**][taskThen] 関数で作成されて返されるタスクのことを*後続タスク*と呼びます。 ユーザーが指定するラムダの入力引数は (この例の場合)、タスク操作の完了時に生成される結果です。 この値は、**IAsyncOperation** インターフェイスを直接使う場合に [**IAsyncOperation::GetResults**](https://msdn.microsoft.com/library/windows/apps/br206600) を呼び出して取得する値と同じになります。

[**task::then**][taskThen] メソッドからは直ちに制御が返され、そのデリゲートは非同期作業が正常に完了するまで実行されません。 この例では、非同期操作で例外がスローされるか、取り消し要求によって非同期操作が取り消された状態で終わると、継続は実行されません。 前のタスクが取り消されるか失敗しても実行される継続を記述する方法については後で説明します。

タスクの変数はローカル スタックで宣言しますが、その有効期間は、操作が完了する前にメソッドから制御が返されても、すべての操作が完了してすべての参照がスコープ外になるまで削除されないように管理されます。

## <a name="creating-a-chain-of-tasks"></a>タスクのチェーンの作成
非同期プログラミングでは、前のタスクが完了した場合にのみ継続が実行されるように、操作のシーケンス (*タスク チェーン*) を定義するのが一般的です。 場合によっては、前のタスク (*先行タスク*) で生成された値を後続タスクが入力として受け取ることもあります。 [**task::then**][taskThen] メソッドを使うと、直観的な方法で簡単にタスク チェーンを作成できます。このメソッドは、**task<T>** (**T** はラムダ関数の戻り値の型) を返します。 複数の継続を含めて 1 つのタスク チェーンを構成することができます。 `myTask.then(…).then(…).then(…);`

タスク チェーンは、継続で新しい非同期操作を作成する場合に特に便利です。このようなタスクのことを非同期タスクと呼びます。 次の例は、2 つの継続を含むタスク チェーンを示しています。 既存のファイルへのハンドルを取得する最初のタスクの操作が完了すると、1 つ目の継続でそのファイルを削除する新しい非同期操作が始まります。 その操作が完了すると、2 つ目の継続が実行され、確認メッセージが出力されます。

``` cpp
#include <ppltasks.h>
using namespace concurrency;
...
void App::DeleteWithTasks(String^ fileName)
{    
    using namespace Windows::Storage;
    StorageFolder^ localFolder = ApplicationData::Current->LocalFolder;
    auto getFileTask = create_task(localFolder->GetFileAsync(fileName));

    getFileTask.then([](StorageFile^ storageFileSample) ->IAsyncAction^ {       
        return storageFileSample->DeleteAsync();
    }).then([](void) {
        OutputDebugString(L"File deleted.");
    });
}
```

この例で重要なポイントは次の 4 つです。

-   1 つ目の継続は、[**IAsyncAction^**][IAsyncAction] オブジェクトを **task<void>** に変換し、**task** を返します。

-   2 つ目の継続は、エラー処理を実行しないため、**task<void>** ではなく **void** を入力として受け取ります。 これは値ベースの継続です。

-   2 つ目の後続タスクは、[**DeleteAsync**][deleteAsync] 操作が完了するまで実行されません。

-   2 つ目の後続タスクは値ベースであるため、[**DeleteAsync**][deleteAsync] を呼び出して開始された操作から例外がスローされると、2 つ目の後続タスクは実行されません。

**注:** 非同期操作を作成する、 **task**クラスを使用する方法の 1 つは、タスク チェーンを作成します。 結合演算子 (**&&**) や選択演算子 (**||**) を使って操作を構成することもできます。 詳しくは、「[タスクの並列処理 (同時実行ランタイム)][taskParallelism]」をご覧ください。

## <a name="lambda-function-return-types-and-task-return-types"></a>ラムダ関数の戻り値の型とタスクの戻り値の型
継続タスクでは、ラムダ関数の戻り値の型が **task** オブジェクトでラップされます。 ラムダが **double** を返す場合、継続タスクの型は **task<double>** になります。 ただし、タスク オブジェクトは、戻り値の型を必要以上に入れ子にしないように設計されています。 ラムダが **IAsyncOperation<SyndicationFeed^>^** を返す場合、継続は、**task<task<SyndicationFeed^>>** や **task<IAsyncOperation<SyndicationFeed^>^>^** ではなく、**task<SyndicationFeed^>** を返します。 *非同期ラップ解除*と呼ばれるこの処理により、さらに、継続内の非同期操作が完了しないと次の継続が呼び出されないようになります。

前の例では、ラムダが [**IAsyncInfo**][IAsyncInfo] オブジェクトを返しているのに、タスクは **task<void>** を返しています。 ラムダ関数とその外側のタスクの間で行われるこれらの型変換を次の表に示します。

| | |
|--------------------------------------------------------|---------------------|
| ラムダの戻り値の型                                     | `.then` の戻り値の型 |
| TResult                                                | task<TResult> |
| IAsyncOperation<TResult>^                        | task<TResult> |
| IAsyncOperationWithProgress<TResult, TProgress>^ | task<TResult> |
|IAsyncAction^                                           | task<void>    |
| IAsyncActionWithProgress<TProgress>^             |task<void>     |
| task<TResult>                                    |task<TResult>  |


## <a name="canceling-tasks"></a>タスクの取り消し
通常、非同期操作をユーザーが取り消せるようにすることをお勧めします。 また、場合によっては、プログラムを使ってタスク チェーンの外側から操作を取り消さなければならないこともあります。 \**Async** のそれぞれの戻り値の型には [**IAsyncInfo**][IAsyncInfo] から継承した [**Cancel**][IAsyncInfoCancel] メソッドが含まれますが、それを外部のメソッドに公開する方法はあまりお勧めできません。 タスク チェーンで取り消しをサポートするときは、[**cancellation\_token\_source**](https://msdn.microsoft.com/library/windows/apps/xaml/hh749985.aspx) を使って [**cancellation\_token**](https://msdn.microsoft.com/library/windows/apps/xaml/hh749975.aspx) を作成し、そのトークンを最初のタスクのコンストラクターに渡す方法をお勧めします。 キャンセル トークンを設定して非同期タスクを作成した場合、[**cancellation\_token\_source::cancel**](https://msdn.microsoft.com/library/windows/apps/xaml/hh750076.aspx) が呼び出されたときに、**IAsync\*** 操作に対する **Cancel** が自動的に呼び出され、取り消し要求が後続のタスク チェーンに渡されます。 この基本的な方法を示す疑似コードを次に示します。

``` cpp
//Class member:
cancellation_token_source m_fileTaskTokenSource;

// Cancel button event handler:
m_fileTaskTokenSource.cancel();

// task chain
auto getFileTask2 = create_task(documentsFolder->GetFileAsync(fileName),
                                m_fileTaskTokenSource.get_token());
//getFileTask2.then ...
```

タスクが取り消されると、[**task\_canceled**][taskCanceled]  例外がタスク チェーンを通じて伝達されます。 値ベースの後続タスクは実行されないだけですが、タスクベースの後続タスクでは、[**task::get**][taskGet] が呼び出されると例外がスローされます。 エラー処理を行う継続がある場合は、**task\_canceled** 例外を明示的にキャッチするようにしてください  (これは [**Platform::Exception**](https://msdn.microsoft.com/library/windows/apps/xaml/hh755825.aspx) から派生した例外ではありません)。

取り消しは連携して行います。 継続で、UWP メソッドを呼び出すだけでなく、時間のかかる作業を行うときは、キャンセル トークンの状態を定期的に確認し、取り消された場合は実行を中止する必要があります。 継続で割り当てられたすべてのリソースをクリーンアップした後、[**cancel\_current\_task**](https://msdn.microsoft.com/library/windows/apps/xaml/hh749945.aspx) を呼び出してそのタスクを取り消し、以降の値ベースの継続に取り消しを伝達します。 また、別の例として、[**FileSavePicker**](https://msdn.microsoft.com/library/windows/apps/BR207871) 操作の結果を表すタスク チェーンを作成するとします。 ユーザーが **[キャンセル]** ボタンをクリックした場合、[**IAsyncInfo::Cancel**][IAsyncInfoCancel] メソッドは呼び出されません。 代わりに、操作は完了しますが **nullptr** が返されます。 この場合、継続で入力パラメーターをテストし、入力が **nullptr** の場合に **cancel\_current\_task** を呼び出すことができます。

詳しくは、「[PPL での取り消し](https://msdn.microsoft.com/library/windows/apps/xaml/dd984117.aspx)」をご覧ください。

## <a name="handling-errors-in-a-task-chain"></a>タスク チェーンでのエラーの処理
先行タスクの取り消しや例外のスローが行われても継続を実行する場合は、継続のラムダ関数への入力を **task<TResult>** または **task<void>** (先行タスクのラムダが [**IAsyncAction^**][IAsyncAction] を返す場合) として指定して、継続をタスクベースにします。

タスク チェーンでエラーや取り消しを処理するために、すべての後続タスクをタスクベースにしたり、スローする可能性があるすべての操作を `try…catch` ブロック内に含めたりする必要はありません。 代わりに、タスクベースの後続タスクをチェーンの最後に追加し、その後続タスクですべてのエラーを処理します。 例外 ( [**task\_canceled**][taskCanceled] 例外も含む) はタスク チェーンを通じて伝達され、値ベースの継続はバイパスされるため、エラー処理を行うタスクベースの継続で例外を処理できます。 エラー処理を行うタスクベースの後続タスクを使うように前の例を書き換えると次のようになります。

``` cpp
#include <ppltasks.h>
void App::DeleteWithTasksHandleErrors(String^ fileName)
{    
    using namespace Windows::Storage;
    using namespace concurrency;

    StorageFolder^ documentsFolder = KnownFolders::DocumentsLibrary;
    auto getFileTask = create_task(documentsFolder->GetFileAsync(fileName));

    getFileTask.then([](StorageFile^ storageFileSample)
    {       
        return storageFileSample->DeleteAsync();
    })

    .then([](task<void> t)
    {

        try
        {
            t.get();
            // .get() didn' t throw, so we succeeded.
            OutputDebugString(L"File deleted.");
        }
        catch (Platform::COMException^ e)
        {
            //Example output: The system cannot find the specified file.
            OutputDebugString(e->Message->Data());
        }

    });
}
```

タスクベースの後続タスクで、メンバー関数 [**task::get**][taskGet] を呼び出してタスクの結果を取得しています。 **task::get** は、結果を生成しない [**IAsyncAction**][IAsyncAction] 操作の場合でも呼び出す必要があります。これは、**task::get** ではタスクに送られた例外も取得するためです。 入力タスクに例外が格納されている場合、**task::get** の呼び出しでその例外がスローされます。 **task::get** を呼び出していない場合、チェーンの最後でタスクベースの継続を使っていない場合、またはスローされた例外の種類をキャッチしていない場合は、タスクに対する参照がすべて削除されたときに **unobserved\_task\_exception** がスローされます。

キャッチする例外は処理できるものだけにしてください。 回復できないエラーがアプリで発生した場合は、不明な状態のままアプリの実行を続けるのではなく、アプリをクラッシュさせることをお勧めします。 また、一般に、**unobserved\_task\_exception** 自体はキャッチしないことをお勧めします。 この例外は、主に診断を目的としたものです。 **unobserved\_task\_exception** がスローされた場合、通常はコード内にバグがあることを示します。 原因のほとんどは、処理が必要な例外があること、またはコード内の他のエラーが原因で回復できない例外があることのどちらかです。

## <a name="managing-the-thread-context"></a>スレッド コンテキストの管理
UWP アプリの UI は、シングルスレッド アパートメント (STA) で実行されます。 ラムダが [**IAsyncAction**][IAsyncAction] または [**IAsyncOperation**][IAsyncOperation] を返すタスクは、アパートメントを認識します。 タスクが STA で作成されている場合、特に指定しない限り、その後続タスクもすべて STA で実行されます。 つまり、タスク チェーン全体が親タスクからアパートメントの認識を継承します。 この動作により、STA からしかアクセスできない UI コントロールの操作が簡単になります。

たとえば、UWP アプリの [**ListBox**](https://msdn.microsoft.com/library/windows/apps/BR242868) コントロールを設定するとき、XAML ページを表す任意のクラスのメンバー関数で [**task::then**][taskThen] メソッド内から設定できるため、[**Dispatcher**](https://msdn.microsoft.com/library/windows/apps/BR208211) オブジェクトを使う必要がありません。

``` cpp
#include <ppltasks.h>
void App::SetFeedText()
{    
    using namespace Windows::Web::Syndication;
    using namespace concurrency;
    String^ url = "http://windowsteamblog.com/windows_phone/b/wmdev/atom.aspx";
    SyndicationClient^ client = ref new SyndicationClient();
    auto feedOp = client->RetrieveFeedAsync(ref new Uri(url));

    create_task(feedOp).then([this]  (SyndicationFeed^ feed)
    {
        m_TextBlock1->Text = feed->Title->Text;
    });
}
```

[**IAsyncAction**][IAsyncAction] または [**IAsyncOperation**][IAsyncOperation] を返さないタスクは、アパートメントを認識しません。これらのタスクの後続タスクは、既定では、利用可能な最初のバックグラウンド スレッドで実行されます。

既定のスレッド コンテキストは、どちらの種類のタスクについても、[**task\_continuation\_context**](https://msdn.microsoft.com/library/windows/apps/xaml/hh749968.aspx) を受け取る [**task::then**][taskThen] のオーバーロードを使って上書きできます。 たとえば、状況によっては、アパートメントを認識するタスクの後続タスクをバックグラウンド スレッドでスケジュールする方が適している場合もあります。 このような場合は、[**task\_continuation\_context::use\_arbitrary**][useArbitrary] を渡して、マルチスレッド アパートメント内の次に利用可能なスレッドでタスクの処理をスケジュールできます。 これにより、継続の作業を UI スレッドで発生する他の作業と同期する必要がないため、継続のパフォーマンスが向上します。

次の例は、[**task\_continuation\_context::use\_arbitrary**][useArbitrary] オプションを指定すると役立つ状況の例を示しています。また、スレッド セーフでないコレクションの同時操作の同期に既定の継続のコンテキストがどのように役立つかも示しています。 このコードでは、RSS フィードの URL の一覧をループ処理し、各 URL について、非同期操作を開始してフィード データを取得しています。 フィードを取得する順序は制御できませんが、ここでは問題ありません。 [**RetrieveFeedAsync**](https://msdn.microsoft.com/library/windows/apps/BR210642) 操作が完了するたびに、1 つ目の継続が [**SyndicationFeed^**](https://msdn.microsoft.com/library/windows/apps/BR243485) オブジェクトを受け取り、それを使ってアプリで定義されている `FeedData^` オブジェクトを初期化します。 これらの操作はそれぞれ独立した操作であるため、継続のコンテキストとして **task\_continuation\_context::use\_arbitrary** を指定すると処理が速くなる可能性があります。 ただし、それぞれの `FeedData` オブジェクトを初期化した後に、そのオブジェクトを [**Vector**](https://msdn.microsoft.com/library/windows/apps/xaml/hh441570.aspx) に追加する必要があり、スレッド セーフなコレクションではありません。 そのため、ここでは、継続を作成して [**task\_continuation\_context::use\_current**](https://msdn.microsoft.com/library/windows/apps/xaml/hh750085.aspx) を指定することで、[**Append**](https://msdn.microsoft.com/library/windows/apps/BR206632) の呼び出しがすべて同じアプリケーション シングルスレッド アパートメント (ASTA) コンテキストで実行されるようにしています。 [**task\_continuation\_context::use\_default**](https://msdn.microsoft.com/library/windows/apps/xaml/hh750085.aspx) は既定のコンテキストであるため、明示的に指定する必要はありませんが、ここではわかりやすいように指定しています。

``` cpp
#include <ppltasks.h>
void App::InitDataSource(Vector<Object^>^ feedList, vector<wstring> urls)
{
                using namespace concurrency;
    SyndicationClient^ client = ref new SyndicationClient();

    std::for_each(std::begin(urls), std::end(urls), [=,this] (std::wstring url)
    {
        // Create the async operation. feedOp is an
        // IAsyncOperationWithProgress<SyndicationFeed^, RetrievalProgress>^
        // but we don't handle progress in this example.

        auto feedUri = ref new Uri(ref new String(url.c_str()));
        auto feedOp = client->RetrieveFeedAsync(feedUri);

        // Create the task object and pass it the async operation.
        // SyndicationFeed^ is the type of the return value
        // that the feedOp operation will eventually produce.

        // Then, initialize a FeedData object by using the feed info. Each
        // operation is independent and does not have to happen on the
        // UI thread. Therefore, we specify use_arbitrary.
        create_task(feedOp).then([this]  (SyndicationFeed^ feed) -> FeedData^
        {
            return GetFeedData(feed);
        }, task_continuation_context::use_arbitrary())

        // Append the initialized FeedData object to the list
        // that is the data source for the items collection.
        // This all has to happen on the same thread.
        // By using the use_default context, we can append
        // safely to the Vector without taking an explicit lock.
        .then([feedList] (FeedData^ fd)
        {
            feedList->Append(fd);
            OutputDebugString(fd->Title->Data());
        }, task_continuation_context::use_default())

        // The last continuation serves as an error handler. The
        // call to get() will surface any exceptions that were raised
        // at any point in the task chain.
        .then( [this] (task<void> t)
        {
            try
            {
                t.get();
            }
            catch(Platform::InvalidArgumentException^ e)
            {
                //TODO handle error.
                OutputDebugString(e->Message->Data());
            }
        }); //end task chain

    }); //end std::for_each
}
```

継続内で作成される入れ子になった新しいタスクは、最初のタスクのアパートメントの認識を継承しません。

## <a name="handing-progress-updates"></a>進行状況の更新の処理
[**IAsyncOperationWithProgress**](https://msdn.microsoft.com/library/windows/apps/br206594.aspx) または [**IAsyncActionWithProgress**](https://msdn.microsoft.com/library/windows/apps/br206581.aspx) をサポートするメソッドは、実行中の操作が完了するまでの間、定期的に進行状況の更新を提供します。 この進行状況の報告は、タスクや継続とは別に独立して処理されます。 オブジェクトの [**Progress**](https://msdn.microsoft.com/library/windows/apps/br206594) プロパティのデリゲートを指定するだけでかまいません。 このデリゲートの一般的な用途は、UI の進行状況バーを更新することです。

## <a name="related-topics"></a>関連トピック
* [UWP アプリ用に C++/CX で非同期操作を作成](https://msdn.microsoft.com/library/hh750082)
* [Visual C++ 言語のリファレンス](http://msdn.microsoft.com/library/windows/apps/hh699871.aspx)
* [非同期プログラミング][AsyncProgramming]
* [タスクの並列処理 (同時実行ランタイム)][taskParallelism]
* [concurrency::task](/cpp/parallel/concrt/reference/task-class)

<!-- LINKS -->
[AsyncProgramming]: <https://docs.microsoft.com/windows/uwp/threading-async/asynchronous-programming-universal-windows-platform-apps> "AsyncProgramming"
[concurrencyNamespace]: <https://docs.microsoft.com/cpp/parallel/concrt/reference/concurrency-namespace> "Concurrency 名前空間"
[createTask]: <https://docs.microsoft.com/cpp/parallel/concrt/reference/concurrency-namespace-functions#create_task> "CreateTask"
[deleteAsync]: <https://msdn.microsoft.com/library/windows/apps/BR227199> "DeleteAsync"
[IAsyncAction]: <https://msdn.microsoft.com/library/windows/apps/windows.foundation.iasyncaction.aspx> "IAsyncAction"
[IAsyncOperation]: <https://msdn.microsoft.com/library/windows/apps/BR206598> "IAsyncOperation"
[IAsyncInfo]: <https://msdn.microsoft.com/library/windows/apps/BR206587> "IAsyncInfo"
[IAsyncInfoCancel]: <https://msdn.microsoft.com/library/windows/apps/windows.foundation.iasyncinfo.cancel> "IAsyncInfoCancel"
[taskCanceled]: <https://docs.microsoft.com/cpp/parallel/concrt/reference/task-canceled-class> "TaskCancelled"
[task-class]: <https://docs.microsoft.com/cpp/parallel/concrt/reference/task-class#get> "Task Class"
[taskGet]: <https://msdn.microsoft.com/library/windows/apps/xaml/hh750017.aspx> "TaskGet"
[taskParallelism]: <https://docs.microsoft.com/cpp/parallel/concrt/task-parallelism-concurrency-runtime> "タスクの並列処理"
[taskThen]: <https://docs.microsoft.com/cpp/parallel/concrt/reference/task-class#then> "TaskThen"
[useArbitrary]: <https://msdn.microsoft.com/library/windows/apps/xaml/hh750036.aspx> "UseArbitrary"
