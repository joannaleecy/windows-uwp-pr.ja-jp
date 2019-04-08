---
description: このトピックでは、C++/WinRT を使用した Windows ランタイムの非同期オブジェクトの作成方法と利用方法について説明します。
title: C++/WinRT を使用した同時実行操作と非同期操作
ms.date: 10/27/2018
ms.topic: article
keywords: Windows 10、uwp、標準、c++、cpp、winrt、プロジェクション、同時実行、非同期、非同期、非同期操作
ms.localizationpriority: medium
ms.openlocfilehash: f3283ffa5fa047806befa2712301c25a7d07af8e
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57611297"
---
# <a name="concurrency-and-asynchronous-operations-with-cwinrt"></a>C++/WinRT を使用した同時実行操作と非同期操作

このトピックではどちらもできる方法を作成およびと Windows ランタイムの非同期オブジェクトを使用[C +/cli WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)します。

## <a name="asynchronous-operations-and-windows-runtime-async-functions"></a>非同期操作と Windows ランタイムの "非同期" 関数

完了までの時間が 50 ミリ秒を超える可能性がある Windows ランタイム API は、非同期の関数 (末尾が "Async") として実装されます。 非同期関数を実装すると、別のスレッドの作業が開始され、非同期操作を表すオブジェクトがすぐに返されます。 非同期操作が完了すると、作業結果が含まれるオブジェクトが返されます。 **Windows::Foundation** Windows ランタイムの名前空間には 4 種類の非同期操作オブジェクトが含まれます。

- [**IAsyncAction**](/uwp/api/windows.foundation.iasyncaction)、
- [**IAsyncActionWithProgress&lt;TProgress&gt;**](/uwp/api/windows.foundation.iasyncactionwithprogress_tprogress_)、
- [**IAsyncOperation&lt;TResult&gt;**](/uwp/api/windows.foundation.iasyncoperation_tresult_)と
- [**IAsyncOperationWithProgress&lt;TResult, TProgress&gt;**](/uwp/api/windows.foundation.iasyncoperationwithprogress_tresult_tprogress_)します。

各非同期操作は、**winrt::Windows::Foundation** C++/WinRT の名前空間で対応する型に投影されます。 また、C++/WinRT には内部 await アダプター構造体も含まれます。 記述できますを使用しないことを直接が、その構造体に協力してくれた、`co_await`協調的にこれらの非同期操作の種類のいずれかを返す任意の関数の結果を待機するステートメント。 その後、これらの型を返す独自のコルーチンを作成できます。

たとえば、非同期の Windows 関数である [**SyndicationClient::RetrieveFeedAsync**](https://docs.microsoft.com/uwp/api/windows.web.syndication.syndicationclient.retrievefeedasync) は、[**IAsyncOperationWithProgress&lt;TResult, TProgress&gt;**](/uwp/api/windows.foundation.iasyncoperationwithprogress_tresult_tprogress_) 型の非同期操作オブジェクトを返します。 いくつかの方法を見てみましょう&mdash;、最初のブロックとし、非ブロッキング&mdash;使用する C +/cli WinRT をなどの API を呼び出す。

## <a name="block-the-calling-thread"></a>呼び出しスレッドのブロック

次のコード例では、**RetrieveFeedAsync** から非同期操作オブジェクトを受け取り、非同期操作の結果が利用可能になるまで呼び出しスレッドをブロックするようにこのオブジェクトで **get** を呼び出します。

```cppwinrt
// main.cpp

#include "pch.h"
#include <winrt/Windows.Foundation.h>
#include <winrt/Windows.Web.Syndication.h>

using namespace winrt;
using namespace Windows::Foundation;
using namespace Windows::Web::Syndication;

void ProcessFeed()
{
    Uri rssFeedUri{ L"https://blogs.windows.com/feed" };
    SyndicationClient syndicationClient;
    SyndicationFeed syndicationFeed{ syndicationClient.RetrieveFeedAsync(rssFeedUri).get() };
    // use syndicationFeed.
}

int main()
{
    winrt::init_apartment();
    ProcessFeed();
}
```

**get** を呼び出すとコーディングが簡単になり、何らかの理由でコルーチンを使用しないコンソール アプリやバックグラウンド スレッドに最適です。 ただし、同時実行でも非同期でもないため、UI スレッドには適していません (UI スレッドで使用しようとすると、最適化されないビルドでアサーションが発生します)。 OS スレッドの他の有用な作業を妨げないように、さまざまな方法が必要です。

## <a name="write-a-coroutine"></a>コルーチンの作成

C++/WinRT は C++ コルーチンをプログラミング モデルに統合し、結果を連携して待機するための自然な方法を提供します。 コルーチンを作成すると、独自の Windows ランタイム非同期操作を作成することができます。 次のコード例で、**ProcessFeedAsync** はコルーチンします。

> [!NOTE]
> **取得**関数が c++ に存在する/cli WinRT プロジェクション型**winrt::Windows::Foundation::IAsyncAction**すべて C + 内から関数を呼び出すことができますので、/cli WinRT プロジェクト。 メンバーとして記載されている関数は見つかりません、 [ **IAsyncAction** ](/uwp/api/windows.foundation.iasyncaction)で**取得**アプリケーション バイナリ インターフェイス (ABI) の表面の一部でない、実際の Windows ランタイム型**IAsyncAction**します。

```cppwinrt
// main.cpp

#include "pch.h"
#include <winrt/Windows.Foundation.h>
#include <winrt/Windows.Web.Syndication.h>
#include <iostream>

using namespace winrt;
using namespace Windows::Foundation;
using namespace Windows::Web::Syndication;

void PrintFeed(SyndicationFeed const& syndicationFeed)
{
    for (SyndicationItem const& syndicationItem : syndicationFeed.Items())
    {
        std::wcout << syndicationItem.Title().Text().c_str() << std::endl;
    }
}

IAsyncAction ProcessFeedAsync()
{
    Uri rssFeedUri{ L"https://blogs.windows.com/feed" };
    SyndicationClient syndicationClient;
    SyndicationFeed syndicationFeed{ co_await syndicationClient.RetrieveFeedAsync(rssFeedUri) };
    PrintFeed(syndicationFeed);
}

int main()
{
    winrt::init_apartment();

    auto processOp{ ProcessFeedAsync() };
    // do other work while the feed is being printed.
    processOp.get(); // no more work to do; call get() so that we see the printout before the application exits.
}
```

コルーチンは中断して再開できる関数です。 上記の **ProcessFeedAsync** コルーチンでは、`co_await` ステートメントに到達すると、コルーチンは **RetrieveFeedAsync** 呼び出しを非同期的に起動してからすぐに自身を中断し、呼び出し元 (上記の例の **main**) に戻ります。 次に、フィードが取得および印刷されるまで、**main** は作業を続けます。 完了すると (**RetrieveFeedAsync** 呼び出しが完了すると)、**ProcessFeedAsync** コルーチンは次のステートメントを再開します。

コルーチンは別のコルーチンに集約することができます。 または、**get** を呼び出してブロックするか、完了するまで待機します (結果が存在する場合には取得します)。 または、Windows ランタイムをサポートする別のプログラミング言語に渡すことができます。

また、デリゲートを使用して、非同期アクションおよび操作の完了イベントと進行状況イベントを処理することもできます。 詳細とコード例については、「[非同期アクションと操作のデリゲート型](handle-events.md#delegate-types-for-asynchronous-actions-and-operations)」をご覧ください。

## <a name="asychronously-return-a-windows-runtime-type"></a>Windows ランタイム型を非同期的に返す

次の例では、特定の URI で呼び出しを **RetrieveFeedAsync** にラップして、[**SyndicationFeed**](/uwp/api/windows.web.syndication.syndicationfeed) を非同期的に返す **RetrieveBlogFeedAsync** 関数を示します。

```cppwinrt
// main.cpp

#include "pch.h"
#include <winrt/Windows.Foundation.h>
#include <winrt/Windows.Web.Syndication.h>
#include <iostream>

using namespace winrt;
using namespace Windows::Foundation;
using namespace Windows::Web::Syndication;

void PrintFeed(SyndicationFeed const& syndicationFeed)
{
    for (SyndicationItem const& syndicationItem : syndicationFeed.Items())
    {
        std::wcout << syndicationItem.Title().Text().c_str() << std::endl;
    }
}

IAsyncOperationWithProgress<SyndicationFeed, RetrievalProgress> RetrieveBlogFeedAsync()
{
    Uri rssFeedUri{ L"https://blogs.windows.com/feed" };
    SyndicationClient syndicationClient;
    return syndicationClient.RetrieveFeedAsync(rssFeedUri);
}

int main()
{
    winrt::init_apartment();

    auto feedOp{ RetrieveBlogFeedAsync() };
    // do other work.
    PrintFeed(feedOp.get());
}
```

次の例では、**RetrieveBlogFeedAsync** は進捗状況と戻り値の両方が含まれる **IAsyncOperationWithProgress** を返します。 **RetrieveBlogFeedAsync** が自分の処理を行い、フィードを取得している間は、他の作業を行うことができます。 次に、非同期操作オブジェクトで **get** を呼び出し、ブロックするか完了まで待機して、操作結果を取得します。

Windows ランタイム型を非同期的に返す場合は、[**IAsyncOperation&lt;TResult&gt;**](/uwp/api/windows.foundation.iasyncoperation_tresult_) または [**IAsyncOperationWithProgress&lt;TResult, TProgress&gt;**](/uwp/api/windows.foundation.iasyncoperationwithprogress_tresult_tprogress_) を返す必要があります。 ファースト パーティ製またはサード パーティ製のランタイム クラス、または Windows ランタイム関数との間で受け渡しできる任意の型 (例、`int` または **winrt::hstring**) がこれに適合します。 コンパイラは、Windows ランタイム型以外でこれらの非同期操作型のいずれかを使用しようとすると表示される "*WinRT 型である必要があります*" というエラーをサポートします。

コルーチンに 1 つ以上の `co_await` ステートメントがない場合、コルーチンであると認められるために、1 つ以上の `co_return` または 1 つの `co_yield` ステートメントが必要です。 非同期操作を必要とせず、そのためにコンテキストのブロックや切り替えを行わずに、コルーチンが値を返すことができる場合があります。 値をキャッシュすることでそれを行う例を次に示します (2 回目以降は呼び出されます)。

```cppwinrt
winrt::hstring m_cache;
 
IAsyncOperation<winrt::hstring> ReadAsync()
{
    if (m_cache.empty())
    {
        // Asynchronously download and cache the string.
    }
    co_return m_cache;
}
``` 

## <a name="asychronously-return-a-non-windows-runtime-type"></a>Windows ランタイム型以外を非同期的に返す

Windows ランタイム型*以外*の型を非同期的に返す場合は、並列パターン ライブラリ (PPL) [**concurrency::task**](/cpp/parallel/concrt/reference/task-class) を返す必要があります。 **std::future**よりもパフォーマンスに優れているため (また、今後の互換性の向上により)、**concurrency::task** をお勧めします。

> [!TIP]
> `<pplawait.h>` を含めると、コルーチンの型として **concurrency::task** を使用できます。

```cppwinrt
// main.cpp

#include "pch.h"
#include <winrt/Windows.Foundation.h>
#include <winrt/Windows.Web.Syndication.h>
#include <iostream>
#include <ppltasks.h>

using namespace winrt;
using namespace Windows::Foundation;
using namespace Windows::Web::Syndication;

concurrency::task<std::wstring> RetrieveFirstTitleAsync()
{
    return concurrency::create_task([]
    {
        Uri rssFeedUri{ L"https://blogs.windows.com/feed" };
        SyndicationClient syndicationClient;
        SyndicationFeed syndicationFeed{ syndicationClient.RetrieveFeedAsync(rssFeedUri).get() };
        return std::wstring{ syndicationFeed.Items().GetAt(0).Title().Text() };
    });
}

int main()
{
    winrt::init_apartment();

    auto firstTitleOp{ RetrieveFirstTitleAsync() };
    // Do other work here.
    std::wcout << firstTitleOp.get() << std::endl;
}
```

## <a name="parameter-passing"></a>パラメーターの引き渡し

同期関数では、既定で `const&` パラメーターを使用する必要があります。 これにより、コピーのオーバーヘッドが回避されます (参照カウント、つまりインタロックされたインクリメントとデクリメントが含まれます)。

```cppwinrt
// Synchronous function.
void DoWork(Param const& value);
```

ただし、コルーチンに参照パラメーターを渡した場合、問題が発生する可能性があります。

```cppwinrt
// NOT the recommended way to pass a value to a coroutine!
IASyncAction DoWorkAsync(Param const& value)
{
    // While it's ok to access value here...
    
    co_await DoOtherWorkAsync();

    // ...accessing value here carries no guarantees of safety.
}
```

コルーチンでは、最初の一時停止ポイントまで実行は同期であり、ここでは、コントロールは呼び出し元に返されます。 コルーチンが再開するまで、参照パラメーターが参照するソース値に何かが発生している可能性があります。 コルーチンの観点からは、参照パラメーターには管理されていない有効期間があります。 そのため、上記の例では、`co_await` まで*値*に安全にアクセスできますが、それ以降は安全ではありません。 また、その後その関数が中断し、再開した後で*値*を使用しようとするリスクがある場合、**DoOtherWorkAsync** に安全に*値*を渡すこともできません。 中断して再開した後で、パラメーターを安全に使用できるようにするには、コルーチンは既定で値渡しを使用し、値でキャプチャして有効期間の問題を回避できるようにする必要があります。 それを行うことが安全であると確信できるためにそのガイダンスから逸脱できる場合は稀です。

```cppwinrt
// Coroutine
IASyncAction DoWorkAsync(Param value);
```

(値を移動しない限り) 定数値を渡すことが良い方法であるということにも議論の余地があります。 コピー元のソース値に影響はありませんが、意図が明確になり、誤ってコピーを変更した場合に役立ちます。
    
```cppwinrt
// coroutine with strictly unnecessary const (but arguably good practice).
IASyncAction DoWorkAsync(Param const value);
```

非同期の呼び出し先に標準ベクターを渡す方法について説明した「[標準的な配列とベクトル](std-cpp-data-types.md#standard-arrays-and-vectors)」も参照してください。

## <a name="offloading-work-onto-the-windows-thread-pool"></a>Windows スレッド プールへの処理のオフロード

コルーチンは、関数に実行を返すまで、呼び出し元がブロックされていることなどの他の機能です。 返すコルーチンの最初のチャンスが 1 つ目とは、 `co_await`、 `co_return`、または`co_yield`します。

そのため、実行する前にコルーチンでの作業を計算主体、実行を返す、呼び出し元にする必要があります (つまり、中断ポイントを導入する) 呼び出し元がブロックされないようにします。 をまだ行っている場合`co_await`- その他のいくつか操作してかまいません ing `co_await` 、 [ **winrt::resume_background** ](/uwp/cpp-ref-for-winrt/resume-background)関数。 これにより、呼び出し元に制御が返され、スレッド プールのスレッドですぐに実行が再開されます。

実装で使用されているスレッド プールは低レベルの [Windows スレッド プール](https://msdn.microsoft.com/library/windows/desktop/ms686766)であるため、最適に効率化されます。

```cppwinrt
IAsyncOperation<uint32_t> DoWorkOnThreadPoolAsync()
{
    co_await winrt::resume_background(); // Return control; resume on thread pool.

    uint32_t result;
    for (uint32_t y = 0; y < height; ++y)
    for (uint32_t x = 0; x < width; ++x)
    {
        // Do compute-bound work here.
    }
    co_return result;
}
```

## <a name="programming-with-thread-affinity-in-mind"></a>スレッドの関係を考慮したプログラミング

このシナリオは、前のシナリオをさらに詳しく説明しています。 一部の処理をスレッド プールにオフロードするが、ユーザー インターフェイス (UI) で進行状況を表示したいとします。

```cppwinrt
IAsyncAction DoWorkAsync(TextBlock textblock)
{
    co_await winrt::resume_background();
    // Do compute-bound work here.

    textblock.Text(L"Done!"); // Error: TextBlock has thread affinity.
}
```

上のコードは、[**winrt::hresult_wrong_thread**](/uwp/cpp-ref-for-winrt/error-handling/hresult-wrong-thread) 例外をスローします。これは、**TextBlock** がそれを作成したスレッド (UI スレッド) から更新する必要があるためです。 1 つの解決方法は、コルーチンが最初に呼び出されたスレッド コンテキストをキャプチャする方法です。 インスタンス化、 [ **winrt::apartment_context** ](/uwp/cpp-ref-for-winrt/apartment-context)オブジェクト、バック グラウンド作業をし`co_await`、 **apartment_context**呼び出し元に戻すコンテキスト。

```cppwinrt
IAsyncAction DoWorkAsync(TextBlock textblock)
{
    winrt::apartment_context ui_thread; // Capture calling context.

    co_await winrt::resume_background();
    // Do compute-bound work here.

    co_await ui_thread; // Switch back to calling context.

    textblock.Text(L"Done!"); // Ok if we really were called from the UI thread.
}
```

上のコルーチンが **TextBlock** を作成した UI スレッドから呼び出される限り、この手法は機能します。 アプリで多くの場合にそれを確信できます。

一般的なソリューションは、呼び出し元のスレッドが不明確していない場合を対象とする、UI を更新することができます`co_await`、 [ **winrt::resume_foreground** ](/uwp/cpp-ref-for-winrt/resume-foreground)スイッチを特定する関数フォア グラウンド スレッドです。 次のコード例では、([**Dispatcher**](/uwp/api/windows.ui.xaml.dependencyobject.dispatcher#Windows_UI_Xaml_DependencyObject_Dispatcher) プロパティにアクセスして) **TextBlock** に関連するディスパッチャー オブジェクトを渡すことでフォアグラウンド スレッドを指定しています。 **winrt::resume_foreground** の実装では、そのディスパッチャー オブジェクトで [**CoreDispatcher.RunAsync**](/uwp/api/windows.ui.core.coredispatcher.runasync) を呼び出し、コルーチンでその後に続く処理を実行しています。

```cppwinrt
#include <winrt/Windows.UI.Core.h> // necessary in order to use winrt::resume_foreground.
IAsyncAction DoWorkAsync(TextBlock textblock)
{
    co_await winrt::resume_background();
    // Do compute-bound work here.

    co_await winrt::resume_foreground(textblock.Dispatcher()); // Switch to the foreground thread associated with textblock.

    textblock.Text(L"Done!"); // Guaranteed to work.
}
```

## <a name="execution-contexts-resuming-and-switching-in-a-coroutine"></a>実行コンテキスト、再開、およびコルーチンでの切り替え

大まかに言えば、コルーチンでの中断ポイントした後、元のスレッドの実行の終了してもよいし、再開に任意のスレッドで発生する可能性があります (つまり、任意のスレッドを呼び出すことができます、**完了**非同期操作のメソッド)。

場合する`co_await`4 つの Windows ランタイムの非同期操作の種類のいずれか (**IAsyncXxx**)、し、C++/cli WinRT はポイントで呼び出し元のコンテキストをキャプチャする`co_await`します。 および継続タスクを再開したとき、そのコンテキストにまだ残っていることになります。 C +/cli WinRT は呼び出し元のコンテキストに既にいるかどうかをチェックし、そうでない場合は、これに切り替えることによって。 したかどうかは、前に、シングル スレッド アパートメント (STA) スレッドで`co_await`、ことと同じものに後で; したかどうかは、前に、マルチ スレッド アパートメント (MTA) スレッドで`co_await`、後でいずれかにあります。

```cppwinrt
IAsyncAction ProcessFeedAsync()
{
    Uri rssFeedUri{ L"https://blogs.windows.com/feed" };
    SyndicationClient syndicationClient;

    // The thread context at this point is captured...
    SyndicationFeed syndicationFeed{ co_await syndicationClient.RetrieveFeedAsync(rssFeedUri) };
    // ...and is restored at this point.
}
```

この動作に依存できる理由は、ためには C +/cli WinRT C++ コルーチンの言語サポート (これらのコードは待機のアダプターで呼ばれます) に、Windows ランタイム非同期操作の種類を調整するためのコードを提供します。 残りの待機可能な型に C +/cli WinRT はスレッド プール ラッパーやヘルパー。そのため、スレッド プールで完了します。

```cppwinrt
using namespace std::chrono;
IAsyncOperation<int> return_123_after_5s()
{
    // No matter what the thread context is at this point...
    co_await 5s;
    // ...we're on the thread pool at this point.
    co_return 123;
}
```

場合する`co_await`他の何らかの種類&mdash;C + 内でも/cli WinRT コルーチンの実装&mdash;別のライブラリは、アダプターを提供し、再開とコンテキストの観点からこれらのアダプターが行う操作を理解する必要があります。

コンテキストの切り替えを最小値までを保持するには、このトピックで前述したよう手法の一部を使用できます。 これを行うのいくつかの図を見てみましょう。 この次の擬似コードの例では、イベント ハンドラー、イメージを読み込むための Windows ランタイム API を呼び出すし、そのイメージを処理するバック グラウンド スレッドにドロップし、UI でイメージを表示する UI スレッドに戻りますのアウトラインを説明します。

```cppwinrt
#include <winrt/Windows.UI.Core.h> // necessary in order to use winrt::resume_foreground.
IAsyncAction MainPage::ClickHandler(IInspectable /* sender */, RoutedEventArgs /* args */)
{
    // We begin in the UI context.

    // Call StorageFile::OpenAsync to load an image file.

    // The call to OpenAsync occurred on a background thread, but C++/WinRT has restored us to the UI thread by this point.

    co_await winrt::resume_background();

    // We're now on a background thread.

    // Process the image.

    co_await winrt::resume_foreground(this->Dispatcher());

    // We're back on MainPage's UI thread.

    // Display the image in the UI.
}
```

このシナリオでは、少し呼び出しの周囲の ineffiency **StorageFile::OpenAsync**します。 背景に必要なコンテキスト スイッチがある (そのハンドラーは、実行を呼び出し元に戻すことができる) スレッド、再開後にどの C +/cli WinRT が UI スレッドのコンテキストを復元します。 しかし、ここでは、UI を更新しようとしていることになるまで、UI スレッド上に存在する必要はありません。 いわゆる複数の Windows ランタイム Api*する前に*への呼び出しを**winrt::resume_background**より不要な - 前後のコンテキスト スイッチが発生しています。 ソリューションは呼び出す*任意*その前に、Windows ランタイム Api です。 すべての後に移動、 **winrt::resume_background**します。

```cppwinrt
#include <winrt/Windows.UI.Core.h> // necessary in order to use winrt::resume_foreground.
IAsyncAction MainPage::ClickHandler(IInspectable /* sender */, RoutedEventArgs /* args */)
{
    // We begin in the UI context.

    co_await winrt::resume_background();

    // We're now on a background thread.

    // Call StorageFile::OpenAsync to load an image file.

    // Process the image.

    co_await winrt::resume_foreground(this->Dispatcher());

    // We're back on MainPage's UI thread.

    // Display the image in the UI.
}
```

独自に記述する可能性がありより高度なものを行いたい場合は、アダプターを待機します。 たい場合など、`co_await`で非同期操作が完了するのと同じスレッドで再開する (そのためがないコンテキストの切り替え) を記述して開始する可能性がありますし、await の次に示すようなアダプター。

> [!NOTE]
> 教育目的のみで、次のコード例が提供されます。作業を開始するのには理解がどのアダプターの連携を待機します。 開発および、独自にテストすることをお勧めし、独自のコードベースでは、この手法を使用する場合は、アダプター struct(s) を待機します。 たとえば、作成する**complete_on_any**、 **complete_on_current**、および**complete_on(dispatcher)** します。 受け取るテンプレートにすることも検討、 **IAsyncXxx**型テンプレート パラメーターとして。

```cppwinrt
struct no_switch
{
    no_switch(Windows::Foundation::IAsyncAction const& async) : m_async(async)
    {
    }

    bool await_ready() const
    {
        return m_async.Status() == Windows::Foundation::AsyncStatus::Completed;
    }

    void await_suspend(std::experimental::coroutine_handle<> handle) const
    {
        m_async.Completed([handle](Windows::Foundation::IAsyncAction const& /* asyncInfo */, Windows::Foundation::AsyncStatus const& /* asyncStatus */)
        {
            handle();
        });
    }

    auto await_resume() const
    {
        return m_async.GetResults();
    }

private:
    Windows::Foundation::IAsyncAction const& m_async;
};
```

使用する方法を理解する、**切り替え**await アダプター、C コンパイラで検出したときを把握する必要がありますのでは最初、`co_await`呼び出された関数が検索式**await_ready**、 **await_suspend**、および**await_resume**します。 C++/cli WinRT ライブラリは、既定では、このような適切な動作を取得するためにこれらの関数を提供します。

```cppwinrt
IAsyncAction async{ ProcessFeedAsync() };
co_await async;
```

使用する、**切り替え**await アダプター、その型を変更するだけ`co_await`から式**IAsyncXxx**に**切り替え**、次のようにします。

```cppwinrt
IAsyncAction async{ ProcessFeedAsync() };
co_await static_cast<no_switch>(async);
```

次の 3 つの検索ではなく、 **await_xxx**関数と一致する**IAsyncXxx**、C++ コンパイラと一致する関数を探します**切り替え**します。

## <a name="canceling-an-asychronous-operation-and-cancellation-callbacks"></a>非同期操作、および取り消しのコールバックをキャンセル

非同期プログラミング向けの Windows ランタイムの機能を使用すると、実行中の非同期アクションまたは操作をキャンセルできます。 呼び出す例を次に示します[ **StorageFolder::GetFilesAsync** ](/uwp/api/windows.storage.storagefolder.getfilesasync)が大きくなる可能性、ファイルのコレクションを取得するには、データ メンバーの非同期操作の結果のオブジェクトを格納します。 ユーザーには、操作をキャンセルするオプションがあります。

```cppwinrt
// MainPage.xaml
...
<Button x:Name="workButton" Click="OnWork">Work</Button>
<Button x:Name="cancelButton" Click="OnCancel">Cancel</Button>
...

// MainPage.h
...
#include <winrt/Windows.Storage.Search.h>
...
struct MainPage : MainPageT<MainPage>
{
    MainPage()
    {
        InitializeComponent();
    }

    IAsyncAction OnWork(IInspectable /* sender */, RoutedEventArgs /* args */)
    {
        workButton().Content(winrt::box_value(L"Working..."));

        // Enable the Pictures Library capability in the app manifest file.
        StorageFolder picturesLibrary{ KnownFolders::PicturesLibrary() };

        m_async = picturesLibrary.GetFilesAsync(CommonFileQuery::OrderByDate, 0, 1000);

        IVectorView<StorageFile> filesInFolder{ co_await m_async };

        workButton().Content(box_value(L"Done!"));

        // Process the files in some way.
    }

    void OnCancel(IInspectable const& /* sender */, RoutedEventArgs const& /* args */)
    {
        if (m_async.Status() != AsyncStatus::Completed)
        {
            m_async.Cancel();
            workButton().Content(winrt::box_value(L"Canceled"));
        }
    }

private:
    IAsyncOperation<::IVectorView<StorageFile>> m_async;
};
```

キャンセルの実装側では、簡単な例から始めましょう。

```cppwinrt
// pch.h
#pragma once
#include <iostream>
#include <winrt/Windows.Foundation.h>

// main.cpp : Defines the entry point for the console application.
#include "pch.h"
using namespace winrt;
using namespace Windows::Foundation;
using namespace std::chrono_literals;

IAsyncAction ImplicitCancellationAsync()
{
    while (true)
    {
        std::cout << "ImplicitCancellationAsync: do some work for 1 second" << std::endl;
        co_await 1s;
    }
}

IAsyncAction MainCoroutineAsync()
{
    auto implicit_cancellation{ ImplicitCancellationAsync() };
    co_await 3s;
    implicit_cancellation.Cancel();
}

int main()
{
    winrt::init_apartment();
    MainCoroutineAsync().get();
}
```

上記の例を実行するかどうかは、表示**ImplicitCancellationAsync** 3 秒間、その後に自動的に終了しますその結果れるキャンセルの 1 秒あたりの 1 つのメッセージを出力します。 発生したため、これは、機能、`co_await`が取り消されましたかどうか、式、コルーチンを確認します。 場合は、し、それを実行せずにアウトしてください。これに該当しない場合は、これを中断し、通常どおりです。

キャンセルは、コルーチンを中断している間、発生します。 コルーチンの再開時にのみヒット別または`co_await`、これは取り消し状態をチェックします。 問題では、キャンセルに応答する可能性のあるすぎる粗い-詳細の待機時間の 1 つです。

そのため、別のオプションは、コルーチン内からのキャンセルを明示的にポーリングします。 以下のリスト内のコードでは、上記の例を更新します。 この新しい例では**ExplicitCancellationAsync**によって返されるオブジェクトを取得、 [ **winrt::get_cancellation_token** ](/uwp/cpp-ref-for-winrt/get-cancellation-token)関数は、オブジェクトを定期的に使用してコルーチンが取り消されたかどうかを確認します。 コルーチンが無制限にループ処理が取り消されない限り、キャンセルすると、ループ、関数は、通常どおりに終了します。 結果は、ここで終了するが、前の例では、明示的が行われるため、管理下にある同じです。

```cppwinrt
...
IAsyncAction ExplicitCancellationAsync()
{
    auto cancellation_token{ co_await winrt::get_cancellation_token() };

    while (!cancellation_token())
    {
        std::cout << "ExplicitCancellationAsync: do some work for 1 second" << std::endl;
        co_await 1s;
    }
}

IAsyncAction MainCoroutineAsync()
{
    auto explicit_cancellation{ ExplicitCancellationAsync() };
    co_await 3s;
    explicit_cancellation.Cancel();
}
...
```

待機している**winrt::get_cancellation_token**の知識があるキャンセル トークンを取得、 **IAsyncAction**コルーチンが自動的に生成します。 そのトークンに関数呼び出し演算子を使用するにはキャンセル状態を照会する&mdash;本質的に取り消し状態をポーリングします。 大規模なコレクションを反復し、これは、適切な手法によって計算バウンドの操作を実行している場合。

### <a name="register-a-cancellation-callback"></a>キャンセル コールバックを登録します。

Windows ランタイムの取り消しは、その他の非同期オブジェクトを自動的に流れません。 &mdash;10.0.17763.0 (Windows 10、バージョンは 1809) のバージョンの Windows SDK で導入された&mdash;取り消しのコールバックを登録することができます。 これは、プリエンプティブなフックをキャンセルを伝えることができるし、同時実行の既存のライブラリと統合することになります。

この次のコード例では**NestedCoroutineAsync**作業が特別な取り消しロジックがありません。 **CancellationPropagatorAsync** ; 入れ子になったコルーチンのラッパーでは基本的には、ラッパーがにわかキャンセルを転送します。

```cppwinrt
// pch.h
#pragma once
#include <iostream>
#include <winrt/Windows.Foundation.h>

// main.cpp : Defines the entry point for the console application.
#include "pch.h"
using namespace winrt;
using namespace Windows::Foundation;
using namespace std::chrono_literals;

IAsyncAction NestedCoroutineAsync()
{
    while (true)
    {
        std::cout << "NestedCoroutineAsync: do some work for 1 second" << std::endl;
        co_await 1s;
    }
}

IAsyncAction CancellationPropagatorAsync()
{
    auto cancellation_token{ co_await winrt::get_cancellation_token() };
    auto nested_coroutine{ NestedCoroutineAsync() };

    cancellation_token.callback([=]
    {
        nested_coroutine.Cancel();
    });

    co_await nested_coroutine;
}

IAsyncAction MainCoroutineAsync()
{
    auto cancellation_propagator{ CancellationPropagatorAsync() };
    co_await 3s;
    cancellation_propagator.Cancel();
}

int main()
{
    winrt::init_apartment();
    MainCoroutineAsync().get();
}
```

**CancellationPropagatorAsync**レジスタの独自のキャンセル コールバックし、ラムダ関数を待機 (が中断されます)、入れ子になった作業が完了するまでです。 場合、または**CancellationPropagatorAsync**が取り消されると、入れ子になったコルーチンにキャンセルを伝達します。 キャンセル; をポーリングする必要はありません。キャンセルは無限にブロックします。 このメカニズムはコルーチンまたは同時実行の何も認識しているライブラリとの相互運用に使用するための十分な柔軟性/cli WinRT します。

## <a name="reporting-progress"></a>進行状況の報告

場合は、コルーチンでは、どちらかを返します[ **IAsyncActionWithProgress**](/uwp/api/windows.foundation.iasyncactionwithprogress_tprogress_)、または[ **IAsyncOperationWithProgress**](/uwp/api/windows.foundation.iasyncoperationwithprogress_tresult_tprogress_)、取得することができ、によって返されるオブジェクト、 [ **winrt::get_progress_token** ](/uwp/cpp-ref-for-winrt/get-progress-token)関数、および進行状況のハンドラーに進行状況の報告に使用します。 次にコード例を示します。

```cppwinrt
// pch.h
#pragma once
#include <iostream>
#include <winrt/Windows.Foundation.h>

// main.cpp : Defines the entry point for the console application.
#include "pch.h"
using namespace winrt;
using namespace Windows::Foundation;
using namespace std::chrono_literals;

IAsyncOperationWithProgress<double, double> CalcPiTo5DPs()
{
    auto progress{ co_await winrt::get_progress_token() };

    co_await 1s;
    double pi_so_far{ 3.1 };
    progress(0.2);

    co_await 1s;
    pi_so_far += 4.e-2;
    progress(0.4);

    co_await 1s;
    pi_so_far += 1.e-3;
    progress(0.6);

    co_await 1s;
    pi_so_far += 5.e-4;
    progress(0.8);

    co_await 1s;
    pi_so_far += 9.e-5;
    progress(1.0);
    co_return pi_so_far;
}

IAsyncAction DoMath()
{
    auto async_op_with_progress{ CalcPiTo5DPs() };
    async_op_with_progress.Progress([](auto const& /* sender */, double progress)
    {
        std::wcout << L"CalcPiTo5DPs() reports progress: " << progress << std::endl;
    });
    double pi{ co_await async_op_with_progress };
    std::wcout << L"CalcPiTo5DPs() is complete !" << std::endl;
    std::wcout << L"Pi is approx.: " << pi << std::endl;
}

int main()
{
    winrt::init_apartment();
    DoMath().get();
}
```

> [!NOTE]
> 1 つ以上実装するために正しくない*完了ハンドラー*非同期アクションまたは操作します。 、Completed イベントの 1 つのデリゲートがあることもできます`co_await`こと。 両方がある場合は、2 つ目は失敗します。 いずれか適切な; 次の 2 種類の完了ハンドラーの 1 つです両方ではなく、同じ非同期オブジェクトの。

```cppwinrt
auto async_op_with_progress{ CalcPiTo5DPs() };
async_op_with_progress.Completed([](auto const& sender, AsyncStatus /* status */)
{
    double pi{ sender.GetResults() };
});
```

```cppwinrt
auto async_op_with_progress{ CalcPiTo5DPs() };
double pi{ co_await async_op_with_progress };
```

完了ハンドラーの詳細については、次を参照してください。[非同期アクションおよび操作の種類をデリゲート](handle-events.md#delegate-types-for-asynchronous-actions-and-operations)します。

## <a name="fire-and-forget"></a>ファイア アンド フォーゲット

場合によっては、他の作業と同時に実行できるタスクがあるし、そのタスクを完了するまで待機する必要はありません (その他の作業なしに依存)、その値を返す必要があるとします。 その場合は、タスクを起動し、忘れたできます。 コルーチンの戻り値の型を記述することができます[ **winrt::fire_and_forget** ](/uwp/cpp-ref-for-winrt/fire-and-forget) (Windows ランタイムの非同期操作の種類のいずれかではなくまたは**concurrency::task**).

```cppwinrt
// pch.h
#pragma once
#include <winrt/Windows.Foundation.h>

// main.cpp : Defines the entry point for the console application.
#include "pch.h"
using namespace winrt;
using namespace std::chrono_literals;

winrt::fire_and_forget CompleteInFiveSeconds()
{
    co_await 5s;
}

int main()
{
    winrt::init_apartment();
    CompleteInFiveSeconds();
    // Do other work here.
}
```

## <a name="important-apis"></a>重要な API
* [concurrency::task クラス](/cpp/parallel/concrt/reference/task-class)
* [IAsyncAction インターフェイス](/uwp/api/windows.foundation.iasyncaction)
* [IAsyncActionWithProgress&lt;TProgress&gt;インターフェイス](/uwp/api/windows.foundation.iasyncactionwithprogress_tprogress_)
* [IAsyncOperation&lt;TResult&gt;インターフェイス](/uwp/api/windows.foundation.iasyncoperation_tresult_)
* [IAsyncOperationWithProgress&lt;TResult, TProgress&gt;インターフェイス](/uwp/api/windows.foundation.iasyncoperationwithprogress_tresult_tprogress_)
* [SyndicationClient::RetrieveFeedAsync メソッド](/uwp/api/windows.web.syndication.syndicationclient.retrievefeedasync)
* [SyndicationFeed クラス](/uwp/api/windows.web.syndication.syndicationfeed)
* [winrt::get_cancellation_token](/uwp/cpp-ref-for-winrt/get-cancellation-token)
* [winrt::get_progress_token](/uwp/cpp-ref-for-winrt/get-progress-token)
* [winrt::fire_and_forget](/uwp/cpp-ref-for-winrt/fire-and-forget)

## <a name="related-topics"></a>関連トピック
* [C + でデリゲートを使用してイベントを処理/cli WinRT](handle-events.md)
* [標準的な C++ のデータ型と C++/WinRT](std-cpp-data-types.md)
