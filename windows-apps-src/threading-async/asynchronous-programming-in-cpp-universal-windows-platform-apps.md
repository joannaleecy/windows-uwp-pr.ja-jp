---
ms.assetid: 34C00F9F-2196-46A3-A32F-0067AB48291B
description: この記事では、Visual C コンポーネント拡張機能での非同期メソッドを使用することをお勧めの方法を説明します。 (C +/cli CX) ppltasks.h で同時実行の名前空間で定義されているタスク クラスを使用しています。
title: C++ での非同期プログラミング
ms.date: 05/14/2018
ms.topic: article
keywords: Windows 10、UWP、スレッド、非同期、C++
ms.localizationpriority: medium
ms.openlocfilehash: beab78415ab36fc7bc0659af1b3466b2c3601d88
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57662837"
---
# <a name="asynchronous-programming-in-ccx"></a>C++/CX での非同期プログラミング
> [!NOTE]
> このトピックは、C++/CX アプリケーションの管理ができるようにすることを目的としています。 ただし、新しいアプリケーションには [C++/WinRT](../cpp-and-winrt-apis/intro-to-using-cpp-with-winrt.md) を使用することをお勧めします。 C++/WinRT は Windows ランタイム (WinRT) API の標準的な最新の C++17 言語プロジェクションで、ヘッダー ファイル ベースのライブラリとして実装され、最新の Windows API への最上位アクセス権を提供するように設計されています。

この記事では、Visual C コンポーネント拡張機能での非同期メソッドを使用することをお勧めの方法を説明します。 (C +/cli CX) を使用して、`task`クラスで定義されている、 `concurrency` ppltasks.h 内の名前空間。

## <a name="universal-windows-platform-uwp-asynchronous-types"></a>ユニバーサル Windows プラットフォーム (UWP) の非同期型
ユニバーサル Windows プラットフォーム (UWP) には、非同期メソッドを呼び出すためのモデルが明確に定義されており、非同期メソッドを使う必要がある型があります。 UWP の非同期モデルについて詳しくない場合は、この記事の前に「[非同期プログラミング][AsyncProgramming]」をご覧ください。

非同期 UWP API は C++ で直接使うこともできますが、[**task class**][task-class] とそれに関連する型と関数を使うことをお勧めします。これは [**concurrency**][concurrencyNamespace] 名前空間のクラスで、`<ppltasks.h>` で定義されています。 **concurrency::task** は汎用型のクラスですが、**/ZW** コンパイラ スイッチ (ユニバーサル Windows プラットフォーム (UWP) アプリとそのコンポーネントには必須) を使うと、task クラスで UWP の非同期型をカプセル化して次の処理を簡単に行うことができます。

-   複数の非同期操作や同期操作を 1 つのチェーンで連結する

-   タスク チェーンで例外を処理する

-   タスク チェーンで取り消しを実行する

-   各タスクを適切なスレッド コンテキストまたはスレッド アパートメントで実行する

ここでは、**task** クラスを UWP の非同期 API で使う方法に関する基本的なガイダンスを示しています。 詳細については、に関するドキュメントを完成**タスク**およびその関連メソッドを含む[**作成\_タスク**][createTask]を参照してください。[タスクの並列化 (同時実行ランタイム)][taskParallelism]します。 

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

[  **task::then**][taskThen] 関数で作成されて返されるタスクのことを*後続タスク*と呼びます。 ユーザーが指定するラムダの入力引数は (この例の場合)、タスク操作の完了時に生成される結果です。 この値は、**IAsyncOperation** インターフェイスを直接使う場合に [**IAsyncOperation::GetResults**](https://msdn.microsoft.com/library/windows/apps/br206600) を呼び出して取得する値と同じになります。

[  **task::then**][taskThen] メソッドからは直ちに制御が返され、そのデリゲートは非同期作業が正常に完了するまで実行されません。 この例では、非同期操作で例外がスローされるか、取り消し要求によって非同期操作が取り消された状態で終わると、継続は実行されません。 前のタスクが取り消されるか失敗しても実行される継続を記述する方法については後で説明します。

タスクの変数はローカル スタックで宣言しますが、その有効期間は、操作が完了する前にメソッドから制御が返されても、すべての操作が完了してすべての参照がスコープ外になるまで削除されないように管理されます。

## <a name="creating-a-chain-of-tasks"></a>タスクのチェーンの作成
非同期プログラミングでは、前のタスクが完了した場合にのみ継続が実行されるように、操作のシーケンス (*タスク チェーン*) を定義するのが一般的です。 場合によっては、前のタスク (*先行タスク*) で生成された値を継続が入力として受け取ることもあります。 [  **task::then**][taskThen] メソッドを使うと、直観的な方法で簡単にタスク チェーンを作成できます。このメソッドは、**task<T>** (**T** はラムダ関数の戻り値の型) を返します。 複数の継続を含めて 1 つのタスク チェーンを構成することができます。`myTask.then(…).then(…).then(…);`

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

**注**  を使用する方法の 1 つは、タスクのチェーンを作成、**タスク**非同期操作を構成するクラス。 結合演算子 (**&&**) や選択演算子 (**||**) を使って操作を構成することもできます。 詳しくは、「[タスクの並列処理 (同時実行ランタイム)][taskParallelism]」をご覧ください。

## <a name="lambda-function-return-types-and-task-return-types"></a>ラムダ関数の戻り値の型とタスクの戻り値の型
継続タスクでは、ラムダ関数の戻り値の型が **task** オブジェクトでラップされます。 ラムダが **double** を返す場合、継続タスクの型は **task<double>** になります。 ただし、タスク オブジェクトは、戻り値の型を必要以上に入れ子にしないように設計されています。 ラムダが **IAsyncOperation<SyndicationFeed^>^** を返す場合、継続は、**task<task<SyndicationFeed^>>** や **task<IAsyncOperation<SyndicationFeed^>^>^** ではなく、**task<SyndicationFeed^>** を返します。 *非同期ラップ解除*と呼ばれるこの処理により、さらに、継続内の非同期操作が完了しないと次の継続が呼び出されないようになります。

前の例では、ラムダが [**IAsyncInfo**][IAsyncInfo] オブジェクトを返しているのに、タスクは **task<void>** を返しています。 ラムダ関数とその外側のタスクの間で行われるこれらの型変換を次の表に示します。

| | |
|--------------------------------------------------------|---------------------|
| ラムダの戻り値の型                                     | `.then` の戻り値の型 |
| TResult                                                | タスク<TResult> |
| IAsyncOperation<TResult>^                        | タスク<TResult> |
| IAsyncOperationWithProgress<TResult, TProgress>^ | タスク<TResult> |
|IAsyncAction^                                           | タスク<void>    |
| IAsyncActionWithProgress<TProgress>^             |タスク<void>     |
| タスク<TResult>                                    |タスク<TResult>  |


## <a name="canceling-tasks"></a>タスクの取り消し
通常、非同期操作をユーザーが取り消せるようにすることをお勧めします。 また、場合によっては、プログラムを使ってタスク チェーンの外側から操作を取り消さなければならないこともあります。 各\* **Async**戻り型を[**キャンセル**] [ IAsyncInfoCancel]メソッドから継承した[ **IAsyncInfo**][IAsyncInfo]、外側のメソッドを公開するため不適切です。 タスク チェーンでキャンセルをサポートするために推奨される方法は使用する、 [**キャンセル\_トークン\_ソース**](https://msdn.microsoft.com/library/windows/apps/xaml/hh749985.aspx)を作成する、 [**キャンセル\_トークン**](https://msdn.microsoft.com/library/windows/apps/xaml/hh749975.aspx)、最初のタスクのコンス トラクターにトークンを渡します。 キャンセル トークンを使用する非同期タスクを作成した場合と[**キャンセル\_トークン\_source::cancel** ](https://msdn.microsoft.com/library/windows/apps/xaml/hh750076.aspx)が呼び出されると、タスクに自動的に呼び出す**キャンセル**上、 **IAsync\*** その継続のチェーンをキャンセルが要求操作を渡します。 この基本的な方法を示す疑似コードを次に示します。

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

タスクが取り消されたときに、 [**タスク\_キャンセル**] [ taskCanceled]チェーン内のタスクに例外が反映されます。 値ベースの後続タスクは実行されないだけですが、タスクベースの後続タスクでは、[**task::get**][taskGet] が呼び出されると例外がスローされます。 エラー処理の継続がある場合は場合、キャッチすることを確認、**タスク\_キャンセル**例外明示的にします。 (これは [**Platform::Exception**](https://msdn.microsoft.com/library/windows/apps/xaml/hh755825.aspx) から派生した例外ではありません)。

取り消しは連携して行います。 継続で、UWP メソッドを呼び出すだけでなく、時間のかかる作業を行うときは、キャンセル トークンの状態を定期的に確認し、取り消された場合は実行を中止する必要があります。 継続タスクに割り当てられたすべてのリソースをクリーンアップする後[**キャンセル\_現在\_タスク**](https://msdn.microsoft.com/library/windows/apps/xaml/hh749945.aspx)そのタスクをキャンセルし、いずれかにキャンセルを伝達するにはそれに続く値ベースの継続します。 また、別の例として、[**FileSavePicker**](https://msdn.microsoft.com/library/windows/apps/BR207871) 操作の結果を表すタスク チェーンを作成するとします。 ユーザーが **[キャンセル]** ボタンをクリックした場合、[**IAsyncInfo::Cancel**][IAsyncInfoCancel] メソッドは呼び出されません。 代わりに、操作は完了しますが **nullptr** が返されます。 継続は、入力パラメーターと呼び出しをテストできます**キャンセル\_現在\_タスク**場合は、入力が**nullptr**します。

詳しくは、「[PPL での取り消し](https://msdn.microsoft.com/library/windows/apps/xaml/dd984117.aspx)」をご覧ください。

## <a name="handling-errors-in-a-task-chain"></a>タスク チェーンでのエラーの処理
先行タスクの取り消しや例外のスローが行われても継続を実行する場合は、継続のラムダ関数への入力を **task<TResult>** または **task<void>** (先行タスクのラムダが [**IAsyncAction^**][IAsyncAction] を返す場合) として指定して、継続をタスクベースにします。

タスク チェーンでエラーや取り消しを処理するために、すべての継続をタスクベースにしたり、スローする可能性があるすべての操作を `try…catch` ブロック内に含めたりする必要はありません。 代わりに、タスクベースの継続をチェーンの最後に追加し、その継続ですべてのエラーを処理します。 例外: これが含まれています、 [**タスク\_キャンセル**] [ taskCanceled]例外: チェーン内のタスクに反映され、すべての値ベースの継続をバイパスようにこれは、エラー処理のタスク ベースの継続で処理できます。 エラー処理を行うタスクベースの継続を使うように前の例を書き換えると次のようになります。

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

タスクベースの後続タスクで、メンバー関数 [**task::get**][taskGet] を呼び出してタスクの結果を取得しています。 **task::get** は、結果を生成しない [**IAsyncAction**][IAsyncAction] 操作の場合でも呼び出す必要があります。これは、**task::get** ではタスクに送られた例外も取得するためです。 入力タスクに例外が格納されている場合、**task::get** の呼び出しでその例外がスローされます。 呼び出さない場合**task::get**、スローされた例外の種類の例外をキャッチしないまたはチェーンの最後に、タスク ベースの継続を使用しないでください、**無視された\_タスク\_例外**タスクにすべての参照が削除された場合にスローされます。

キャッチする例外は処理できるものだけにしてください。 回復できないエラーがアプリで発生した場合は、不明な状態のままアプリの実行を続けるのではなく、アプリをクラッシュさせることをお勧めします。 また、一般に、しないでキャッチ、**無視された\_タスク\_例外**自体。 この例外は、主に診断を目的としたものです。 ときに**無視された\_タスク\_例外**がスローされると、通常を示します、コードのバグです。 原因のほとんどは、処理が必要な例外があること、またはコード内の他のエラーが原因で回復できない例外があることのどちらかです。

## <a name="managing-the-thread-context"></a>スレッド コンテキストの管理
UWP アプリの UI は、シングルスレッド アパートメント (STA) で実行されます。 ラムダが [**IAsyncAction**][IAsyncAction] または [**IAsyncOperation**][IAsyncOperation] を返すタスクは、アパートメントを認識します。 タスクが STA で作成されている場合、特に指定しない限り、その継続もすべて STA で実行されます。 つまり、タスク チェーン全体が親タスクからアパートメントの認識を継承します。 この動作により、STA からしかアクセスできない UI コントロールの操作が簡単になります。

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

[  **IAsyncAction**][IAsyncAction] または [**IAsyncOperation**][IAsyncOperation] を返さないタスクは、アパートメントを認識しません。これらのタスクの後続タスクは、既定では、利用可能な最初のバックグラウンド スレッドで実行されます。

オーバー ロードを使用してタスクのいずれかの種類の既定のスレッド コンテキストをオーバーライドすることができます[ **task::then** ] [ taskThen]を受け取る、 [**タスク\_継続\_コンテキスト**](https://msdn.microsoft.com/library/windows/apps/xaml/hh749968.aspx)します。 たとえば、状況によっては、アパートメントを認識するタスクの継続をバックグラウンド スレッドでスケジュールする方が適している場合もあります。 このような場合は、渡すことができます[**タスク\_継続\_context::use\_任意**] [ useArbitrary]でタスクの作業をスケジュールする、マルチ スレッド アパートメントで [次へ] の使用可能なスレッド。 これにより、継続の作業を UI スレッドで発生する他の作業と同期する必要がないため、継続のパフォーマンスが向上します。

次の例で指定すると便利な場合、 [**タスク\_継続\_context::use\_任意**] [ useArbitrary]オプション、およびそれも表示方法、既定の継続コンテキストはスレッド セーフのコレクションでの同時操作を同期するために便利です。 このコードでは、RSS フィードの URL の一覧をループ処理し、各 URL について、非同期操作を開始してフィード データを取得しています。 フィードを取得する順序は制御できませんが、ここでは問題ありません。 [  **RetrieveFeedAsync**](https://msdn.microsoft.com/library/windows/apps/BR210642) 操作が完了するたびに、1 つ目の継続が [**SyndicationFeed^**](https://msdn.microsoft.com/library/windows/apps/BR243485) オブジェクトを受け取り、それを使ってアプリで定義されている `FeedData^` オブジェクトを初期化します。 これらの各操作は、他のユーザーから独立しているためできる場合もあります速度を向上させるを指定することによって、**タスク\_継続\_context::use\_任意**継続コンテキスト. ただし、それぞれの `FeedData` オブジェクトを初期化した後に、そのオブジェクトを [**Vector**](https://msdn.microsoft.com/library/windows/apps/xaml/hh441570.aspx) に追加する必要があり、スレッド セーフなコレクションではありません。 そのため、継続を作成し、指定[**タスク\_継続\_context::use\_現在**](https://msdn.microsoft.com/library/windows/apps/xaml/hh750085.aspx)ことに、すべての呼び出しを確認する[**Append** ](https://msdn.microsoft.com/library/windows/apps/BR206632)同じ Application Single-Threaded アパートメント (ASTA) コンテキストで発生します。 [**タスク\_継続\_context::use\_既定**](https://msdn.microsoft.com/library/windows/apps/xaml/hh750085.aspx)既定のコンテキストには、それを明示的に指定する必要はありませんがこちらから行うことの sake のわかりやすくするためです。

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
[  **IAsyncOperationWithProgress**](https://msdn.microsoft.com/library/windows/apps/br206594.aspx) または [**IAsyncActionWithProgress**](https://msdn.microsoft.com/library/windows/apps/br206581.aspx) をサポートするメソッドは、実行中の操作が完了するまでの間、定期的に進行状況の更新を提供します。 この進行状況の報告は、タスクや継続とは別に独立して処理されます。 オブジェクトの [**Progress**](https://msdn.microsoft.com/library/windows/apps/br206594) プロパティのデリゲートを指定するだけでかまいません。 このデリゲートの一般的な用途は、UI の進行状況バーを更新することです。

## <a name="related-topics"></a>関連トピック
* [非同期操作を作成する c++/cli CX UWP アプリ用](https://msdn.microsoft.com/library/hh750082)
* [Visual C 言語リファレンス](https://msdn.microsoft.com/library/windows/apps/hh699871.aspx)
* [非同期プログラミング][AsyncProgramming]
* [タスクの並列処理 (同時実行ランタイム)][taskParallelism]
* [concurrency::task](/cpp/parallel/concrt/reference/task-class)

<!-- LINKS -->
[AsyncProgramming]: <https://docs.microsoft.com/windows/uwp/threading-async/asynchronous-programming-universal-windows-platform-apps> "AsyncProgramming"
[concurrencyNamespace]: <https://docs.microsoft.com/cpp/parallel/concrt/reference/concurrency-namespace> "同時実行 Namespace"
[createTask]: <https://docs.microsoft.com/cpp/parallel/concrt/reference/concurrency-namespace-functions#create_task> "CreateTask"
[deleteAsync]: <https://msdn.microsoft.com/library/windows/apps/BR227199> "DeleteAsync"
[IAsyncAction]: <https://msdn.microsoft.com/library/windows/apps/windows.foundation.iasyncaction.aspx> "IAsyncAction"
[IAsyncOperation]: <https://msdn.microsoft.com/library/windows/apps/BR206598> "IAsyncOperation"
[IAsyncInfo]: <https://msdn.microsoft.com/library/windows/apps/BR206587> "IAsyncInfo"
[IAsyncInfoCancel]: <https://msdn.microsoft.com/library/windows/apps/windows.foundation.iasyncinfo.cancel> "IAsyncInfoCancel"
[taskCanceled]: <https://docs.microsoft.com/cpp/parallel/concrt/reference/task-canceled-class> "TaskCancelled"
[task-class]: <https://docs.microsoft.com/cpp/parallel/concrt/reference/task-class#get> "Task クラス"
[taskGet]: <https://msdn.microsoft.com/library/windows/apps/xaml/hh750017.aspx> "TaskGet"
[taskParallelism]: <https://docs.microsoft.com/cpp/parallel/concrt/task-parallelism-concurrency-runtime> "タスクの並列化"
[taskThen]: <https://docs.microsoft.com/cpp/parallel/concrt/reference/task-class#then> "TaskThen"
[useArbitrary]: <https://msdn.microsoft.com/library/windows/apps/xaml/hh750036.aspx> "UseArbitrary"
