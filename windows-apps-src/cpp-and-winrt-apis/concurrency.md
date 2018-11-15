---
author: stevewhims
description: このトピックでは、C++/WinRT を使用した Windows ランタイムの非同期オブジェクトの作成方法と利用方法について説明します。
title: C++/WinRT を使用した同時実行操作と非同期操作
ms.author: stwhi
ms.date: 10/27/2018
ms.topic: article
keywords: Windows 10、uwp、標準、c++、cpp、winrt、プロジェクション、同時実行、非同期、非同期、非同期操作
ms.localizationpriority: medium
ms.openlocfilehash: 18eddbc9356f126e887ae2731ea87381352ea061
ms.sourcegitcommit: 71e8eae5c077a7740e5606298951bb78fc42b22c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/13/2018
ms.locfileid: "6653312"
---
# <a name="concurrency-and-asynchronous-operations-with-cwinrt"></a>C++/WinRT を使用した同時実行操作と非同期操作

このトピックではどちらもできる方法の作成し、Windows ランタイムの非同期オブジェクトを利用[、C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)します。

## <a name="asynchronous-operations-and-windows-runtime-async-functions"></a>非同期操作と Windows ランタイムの "非同期" 関数

完了までの時間が 50 ミリ秒を超える可能性がある Windows ランタイム API は、非同期の関数 (末尾が "Async") として実装されます。 非同期関数を実装すると、別のスレッドの作業が開始され、非同期操作を表すオブジェクトがすぐに返されます。 非同期操作が完了すると、作業結果が含まれるオブジェクトが返されます。 **Windows::Foundation** Windows ランタイムの名前空間には 4 種類の非同期操作オブジェクトが含まれます。

- [**IAsyncAction**](/uwp/api/windows.foundation.iasyncaction)、
- [**IAsyncActionWithProgress&lt;TProgress&gt;**](/uwp/api/windows.foundation.iasyncactionwithprogress_tprogress_)、
- [**IAsyncOperation&lt;TResult&gt;**](/uwp/api/windows.foundation.iasyncoperation_tresult_)、
- [**IAsyncOperationWithProgress&lt;TResult, TProgress&gt;**](/uwp/api/windows.foundation.iasyncoperationwithprogress_tresult_tprogress_)。

各非同期操作は、**winrt::Windows::Foundation** C++/WinRT の名前空間で対応する型に投影されます。 また、C++/WinRT には内部 await アダプター構造体も含まれます。 直接が、これにより、その構造体は使用しない、作成、`co_await`ステートメントを一緒にこれらの非同期操作型のいずれかを返す関数の結果を待機します。 その後、これらの型を返す独自のコルーチンを作成できます。

たとえば、非同期の Windows 関数である [**SyndicationClient::RetrieveFeedAsync**](https://docs.microsoft.com/uwp/api/windows.web.syndication.syndicationclient.retrievefeedasync) は、[**IAsyncOperationWithProgress&lt;TResult, TProgress&gt;**](/uwp/api/windows.foundation.iasyncoperationwithprogress_tresult_tprogress_) 型の非同期操作オブジェクトを返します。 いくつかの方法を見てみましょう&mdash;、最初のブロックとし、非ブロック&mdash;を使用して、C++ の/WinRT にそのような API を呼び出します。

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
> C++ で**取得する**関数が存在する/WinRT プロジェクション入力**winrt::Windows::Foundation::IAsyncAction**、c++ 内から関数を呼び出すことができます/WinRT プロジェクトです。 実際の Windows ランタイム型**IAsyncAction**のアプリケーション バイナリ インターフェイス (ABI) のサーフェスの一部でない**を取得する**ため、 [**IAsyncAction**](/uwp/api/windows.foundation.iasyncaction)インターフェイスのメンバーとして記載されている関数は検索されません。

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

コルーチンは、その関数は、それに実行を返すまでに、呼び出し元がブロックされているなどの他の機能です。 そしてを返すコルーチンの最初の機会が最初の`co_await`、 `co_return`、または`co_yield`します。

そのため、その前に、コルーチンで計算にバインドされている作業、呼び出し元に実行を返す必要があります (つまり、一時停止ポイントを導入します)、呼び出し元がブロックされないようにします。 まだ行っていないを場合`co_await`にその他の操作を取り`co_await` [**winrt::resume_background**](/uwp/cpp-ref-for-winrt/resume-background)関数。 これにより、呼び出し元に制御が返され、スレッド プールのスレッドですぐに実行が再開されます。

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

上のコードは、[**winrt::hresult_wrong_thread**](/uwp/cpp-ref-for-winrt/hresult-wrong-thread) 例外をスローします。これは、**TextBlock** がそれを作成したスレッド (UI スレッド) から更新する必要があるためです。 1 つの解決方法は、コルーチンが最初に呼び出されたスレッド コンテキストをキャプチャする方法です。 そのためには、 [**winrt::apartment_context**](/uwp/cpp-ref-for-winrt/apartment-context)オブジェクトをインスタンス化、バック グラウンドの作業を実行し、 `co_await` **apartment_context**呼び出し元コンテキストに戻るにします。

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

できます、場所、わからない呼び出しスレッドの場合、UI の更新に対するより一般的なソリューションの`co_await`特定のフォア グラウンド スレッドに切り替える[**:resume_foreground**](/uwp/cpp-ref-for-winrt/resume-foreground)関数。 次のコード例では、([**Dispatcher**](/uwp/api/windows.ui.xaml.dependencyobject.dispatcher#Windows_UI_Xaml_DependencyObject_Dispatcher) プロパティにアクセスして) **TextBlock** に関連するディスパッチャー オブジェクトを渡すことでフォアグラウンド スレッドを指定しています。 **winrt::resume_foreground** の実装では、そのディスパッチャー オブジェクトで [**CoreDispatcher.RunAsync**](/uwp/api/windows.ui.core.coredispatcher.runasync) を呼び出し、コルーチンでその後に続く処理を実行しています。

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

大まかに言うと、コルーチンで一時停止ポイント後の実行元のスレッドが消えるし、再開は、任意のスレッドで発生する可能性があります (つまり、任意のスレッドが、メソッドを呼び出して**Completed**非同期操作の)。

場合する`co_await`、4 つの Windows ランタイム非同期操作型 (**IAsyncXxx**) し、C++ のいずれかの/WinRT 時点では、呼び出し元のコンテキストをキャプチャする`co_await`します。 継続の再開時そのコンテキストに残っていることを保証します。 C++/WinRT は呼び出し元のコンテキストでされているかどうかを確認し、そうでない場合は、それに切り替えます。 したかどうかは、前にシングル スレッド アパートメント (STA) スレッドで`co_await`、その後でものと同じ上にありますしたかどうかは、前にマルチ スレッド アパートメント (MTA スレッドで`co_await`、その後でいずれかでにあります。

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

この動作に依存することが理由は、C++/WinRT が (コードのこれらのコンポーネントと呼ばれる待機アダプター) C++ コルーチン言語サポートをそれらの Windows ランタイム非同期操作型の対応するコードを提供します。 残りの待機型 c++/WinRT はスレッド プールのラッパーやヘルパーです。スレッド プールに完了したためです。

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

場合する`co_await`他の種類&mdash;内であっても、C++/cli/winrt コルーチンの実装&mdash;別のライブラリは、アダプターを提供し、再開、およびコンテキストの観点から実行するこれらのアダプターを理解する必要があります。

最低限にコンテキストの切り替えを維持するには、このトピックで説明した既に手法の一部を使用できます。 これを行うのいくつかの図を見てみましょう。 次の擬似コード例では、画像を読み込むに Windows ランタイム API を呼び出す、そのイメージを処理するバック グラウンド スレッドにドロップし、その UI に画像を表示する UI スレッドにイベント ハンドラーの概要について説明します。

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

このシナリオでは、ineffiency **StorageFile::OpenAsync**への呼び出しを中心に少しです。 背景に必要なコンテキスト スイッチがあるスレッド (ハンドラーは、呼び出し元に実行を返すことができます) するためのどの C + 後の再開時/WinRT は UI スレッド コンテキストを復元します。 ただし、この例では、UI を更新しようとするまでに、UI スレッド上にする必要はありません。 詳細 Windows ランタイム Api 呼び出し*の前に* **winrt::resume_background**、当社の呼び出し、不要なより - 前後コンテキストの切り替えが発生します。 ソリューションは呼び出す*任意*の Windows ランタイム Api する前にしません。 **Winrt::resume_background**後に、それらを移動します。

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

独自に記述することもでき、高度な処理を行う場合は、アダプターを待機します。 する場合など、`co_await`で非同期操作が完了するのと同じスレッドで再開する (そのためがないコンテキストの切り替え) を作成して開始することができますし、await アダプターを次に示すように似ています。

> [!NOTE]
> 次のコード例では、教育だけを目的が提供されます。作業を開始するのにはそれについて理解アダプターの作業を待機する方法。 開発や、独自にテストを行うことをお勧めしますこの手法は、独自のコードベースを使用する場合は、アダプター struct(s) を待ちます。 たとえば、 **complete_on_any**、 **complete_on_current**、および**complete_on(dispatcher)** を記述することができます。 テンプレートをテンプレート パラメーターとして**IAsyncXxx**の種類を取得する際に検討してください。

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

**切り替え**を使用する方法を理解する await アダプター、最初に、C++ コンパイラで発生したときにことを把握する必要があります、 `co_await` **await_ready**、 **await_suspend**、および**await_resume**関数を探す式が呼び出されます。 C++/WinRT ライブラリは、既定では、次のように、適切な動作を取得するためにこれらの機能を提供します。

```cppwinrt
IAsyncAction async{ ProcessFeedAsync() };
co_await async;
```

使用する**切り替え**await アダプターを変更するの種類`co_await`式**IAsyncXxx**の**切り替え**、次のようにします。

```cppwinrt
IAsyncAction async{ ProcessFeedAsync() };
co_await static_cast<no_switch>(async);
```

次に、 **IAsyncXxx**に一致する 3 つの**await_xxx**関数を探してではなく C++ コンパイラーはな**切り替えなし**に一致する機能。

## <a name="canceling-an-asychronous-operation-and-cancellation-callbacks"></a>非同期操作と取り消しコールバックをキャンセルします。

非同期プログラミング用の Windows ランタイムの機能を使用すると、非同期処理中のアクションまたは操作を取り消すことができます。 データ メンバーに、結果として得られる非同期操作オブジェクトを格納し、大きい可能性がある、ファイルのコレクションを取得する[**StorageFolder::GetFilesAsync**](/uwp/api/windows.storage.storagefolder.getfilesasync)を呼び出す例を次に示します。 ユーザーには、操作をキャンセルするオプションがあります。

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

取り消しの実装側の単純な例から始めましょう。

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

メッセージが表示されます**ImplicitCancellationAsync**印刷 1 つ後の 3 秒を 1 秒あたり時間を自動的にし、上記の例を実行する場合は、キャンセルされる結果として終了します。 発生しているため、この作業は、`co_await`式、コルーチンのチェックがキャンセルされたかどうか。 場合は、その後、short-circuits アウトしてください。されていない場合は、それを中断し、通常どおりします。

取り消し、もちろん、起こりコルーチンが中断されているとき。 コルーチンが再開するときにのみ別に達したか`co_await`、取り消しに対してが確認されます。 問題では、取り消しに対応する場合の待機時間の可能性のあるすぎる粗い-細かいの 1 つです。

そのため、明示的にポーリングするには、コルーチン内からの取り消しに対してすることが別のオプションです。 以下のリスト内のコードでは、上記の例を更新します。 この新しい例では**ExplicitCancellationAsync** 、 [**winrt::get_cancellation_token**](/uwp/cpp-ref-for-winrt/get-cancellation-token)関数によって返されるオブジェクトを取得しますを定期的に、コルーチンが取り消されたかどうかを確認します。 コルーチンが無限に; ループがキャンセルされない限り取り消されたしたら、ループと関数正常終了します。 結果は、前の例が、ここで終了するが、明示的に行われるため、管理と同じです。

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

**Winrt::get_cancellation_token**を待機している、お客様に代わって、コルーチンが生成**IAsyncAction**の知識を持つキャンセル トークンを取得します。 そのトークンを関数呼び出し演算子を使用するには取り消し状態を照会&mdash;本質的に取り消しをポーリングします。 いくつかの計算にバインドされている操作を実行している場合は、大規模なコレクションの反復し、これは、適切な手法。

### <a name="register-a-cancellation-callback"></a>取り消しコールバックを登録します。

Windows ランタイムのキャンセルは他の非同期オブジェクトに自動的に流し込まれます。 ただし&mdash;Windows SDK のバージョン 10.0.17763.0 (Windows 10、バージョン 1809) で導入された&mdash;キャンセル コールバックを登録することができます。 これは、事前フックする取り消し反映でき、既存の同時実行ライブラリと統合することもできます。

次のコード例、 **NestedCoroutineAsync**は、作業には特別な取り消しロジックはありません。 **CancellationPropagatorAsync**は入れ子になったコルーチン; でラッパー本質的にはラッパーは、先制取り消しを転送します。

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

    cancellation_token.callback([&]
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

**CancellationPropagatorAsync**独自の取り消しコールバックのラムダ関数を登録して、それを待機し、(中断) 入れ子になった作業が完了するまでです。 とき、または**CancellationPropagatorAsync**が取り消された場合は、入れ子になったコルーチンに取り消しを伝達します。 取り消し; をポーリングする必要はありません。取り消しがブロックされている無期限にします。 このメカニズムは、C++ の何も認識しているコルーチンまたは concurrency ライブラリとの相互運用機能を使用するのに十分な柔軟性/WinRT します。

## <a name="reporting-progress"></a>進行状況の報告

[**IAsyncActionWithProgress**](/uwp/api/windows.foundation.iasyncactionwithprogress_tprogress_)、または[**IAsyncOperationWithProgress**](/uwp/api/windows.foundation.iasyncoperationwithprogress_tresult_tprogress_)コルーチンが返される場合ことができます、 [**winrt::get_progress_token**](/uwp/cpp-ref-for-winrt/get-progress-token)関数によって返されるオブジェクトを取得し、使用して、進行状況に進行状況を報告するハンドラーです。 次にコード例を示します。

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
> 正しい非同期アクションまたは操作中には、複数の*完了ハンドラー*を実装することはできません。 その完了のイベントのデリゲートが 1 つしたりすることができます`co_await`ことです。 両方がある場合は、2 つ目は失敗します。 いずれか完了ハンドラーの次の 2 種類のいずれかが適切です。両方の同じ非同期オブジェクト。

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

完了ハンドラーについて詳しくは、[非同期アクションと非同期操作のデリゲート型](handle-events.md#delegate-types-for-asynchronous-actions-and-operations)を参照してください。

## <a name="fire-and-forget"></a>再生後に消去

場合によっては、他の作業と同時に実行できるタスクがあり、そのタスクを完了するを待機する必要はありません (その他の作業依存しない)、必要な値を返すこともできます。 その場合は、タスクを起動し、忘れたできます。 戻り値の型が (代わりに、Windows ランタイム非同期操作型または**concurrency::task**のいずれか) [**winrt::fire_and_forget**](/uwp/cpp-ref-for-winrt/fire-and-forget)コルーチンを作成しているを行うことができます。

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
* [Syndicationclient::retrievefeedasync メソッド](/uwp/api/windows.web.syndication.syndicationclient.retrievefeedasync)
* [SyndicationFeed クラス](/uwp/api/windows.web.syndication.syndicationfeed)
* [winrt::get_cancellation_token](/uwp/cpp-ref-for-winrt/get-cancellation-token)
* [winrt::get_progress_token](/uwp/cpp-ref-for-winrt/get-progress-token)
* [winrt::fire_and_forget](/uwp/cpp-ref-for-winrt/fire-and-forget)

## <a name="related-topics"></a>関連トピック
* [C++/WinRT でのデリゲートを使用したイベントの処理](handle-events.md)
* [標準的な C++ のデータ型と C++/WinRT](std-cpp-data-types.md)
