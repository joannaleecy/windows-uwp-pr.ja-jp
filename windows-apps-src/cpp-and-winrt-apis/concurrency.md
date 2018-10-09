---
author: stevewhims
description: このトピックでは、C++/WinRT を使用した Windows ランタイムの非同期オブジェクトの作成方法と利用方法について説明します。
title: C++/WinRT を使用した同時実行操作と非同期操作
ms.author: stwhi
ms.date: 10/03/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10、uwp、標準、c++、cpp、winrt、プロジェクション、同時実行、非同期、非同期、非同期操作
ms.localizationpriority: medium
ms.openlocfilehash: 9f29828a800795aba70c17bcab19b56b85d56382
ms.sourcegitcommit: 49aab071aa2bd88f1c165438ee7e5c854b3e4f61
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/09/2018
ms.locfileid: "4466482"
---
# <a name="concurrency-and-asynchronous-operations-with-cwinrt"></a>C++/WinRT を使用した同時実行操作と非同期操作

このトピックでは両方ともできる方法の作成し、Windows ランタイムの非同期オブジェクトを利用[、C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)します。

## <a name="asynchronous-operations-and-windows-runtime-async-functions"></a>非同期操作と Windows ランタイムの "非同期" 関数
完了までの時間が 50 ミリ秒を超える可能性がある Windows ランタイム API は、非同期の関数 (末尾が "Async") として実装されます。 非同期関数を実装すると、別のスレッドの作業が開始され、非同期操作を表すオブジェクトがすぐに返されます。 非同期操作が完了すると、作業結果が含まれるオブジェクトが返されます。 **Windows::Foundation** Windows ランタイムの名前空間には 4 種類の非同期操作オブジェクトが含まれます。

- [**IAsyncAction**](/uwp/api/windows.foundation.iasyncaction)、
- [**IAsyncActionWithProgress&lt;TProgress&gt;**](/uwp/api/windows.foundation.iasyncactionwithprogress_tprogress_)、
- [**IAsyncOperation&lt;TResult&gt;**](/uwp/api/windows.foundation.iasyncoperation_tresult_)、
- [**IAsyncOperationWithProgress&lt;TResult, TProgress&gt;**](/uwp/api/windows.foundation.iasyncoperationwithprogress_tresult_tprogress_)。

各非同期操作は、**winrt::Windows::Foundation** C++/WinRT の名前空間で対応する型に投影されます。 また、C++/WinRT には内部 await アダプター構造体も含まれます。 直接が、これにより、その構造体は使用しない、作成、`co_await`これらの非同期操作型のいずれかを返す関数の結果を一緒に待機するステートメントです。 その後、これらの型を返す独自のコルーチンを作成できます。

たとえば、非同期の Windows 関数である [**SyndicationClient::RetrieveFeedAsync**](https://docs.microsoft.com/uwp/api/windows.web.syndication.syndicationclient.retrievefeedasync) は、[**IAsyncOperationWithProgress&lt;TResult, TProgress&gt;**](/uwp/api/windows.foundation.iasyncoperationwithprogress_tresult_tprogress_) 型の非同期操作オブジェクトを返します。 それでは、C++/WinRT を使用してそのような API を呼び出すためのいくつかの方法 (ブロックと非ブロック) を示します。

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
    SyndicationFeed syndicationFeed = syndicationClient.RetrieveFeedAsync(rssFeedUri).get();
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
> C++ で**取得する**関数が存在する/WinRT プロジェクション入力**winrt::Windows::Foundation::IAsyncAction**、c++ 内から関数を呼び出すことができます/WinRT プロジェクトです。 実際の Windows ランタイム型**IAsyncAction**のアプリケーション バイナリ インターフェイス (ABI) サーフェスの一部でない**を取得する**ため、 [**IAsyncAction**](/uwp/api/windows.foundation.iasyncaction)インターフェイスのメンバーとして記載されている関数は検索されません。

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

    auto processOp = ProcessFeedAsync();
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

    auto feedOp = RetrieveBlogFeedAsync();
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
        SyndicationFeed syndicationFeed = syndicationClient.RetrieveFeedAsync(rssFeedUri).get();
        return std::wstring{ syndicationFeed.Items().GetAt(0).Title().Text() };
    });
}

int main()
{
    winrt::init_apartment();

    auto firstTitleOp = RetrieveFirstTitleAsync();
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
コルーチンで計算処理にかかる処理を行う前に、呼び出し元がブロックされないように呼び出し元に実行を返す必要があります (つまり、一時停止ポイントを導入します)。 その他の操作を `co-await` することでこれをまだ行っていない場合は、**winrt::resume_background** 関数を `co-await` できます。 これにより、呼び出し元に制御が返され、スレッド プールのスレッドですぐに実行が再開されます。

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

上のコードは、[**winrt::hresult_wrong_thread**](/uwp/cpp-ref-for-winrt/hresult-wrong-thread) 例外をスローします。これは、**TextBlock** がそれを作成したスレッド (UI スレッド) から更新する必要があるためです。 1 つの解決方法は、コルーチンが最初に呼び出されたスレッド コンテキストをキャプチャする方法です。 **winrt::apartment_context** オブジェクトをインスタンス化し、それを `co_await` します。

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

場所、わからない呼び出しスレッドの場合、UI の更新のより一般的な解決策を`co-await`特定のフォア グラウンド スレッドに切り替える **:resume_foreground**関数。 次のコード例では、([**Dispatcher**](/uwp/api/windows.ui.xaml.dependencyobject.dispatcher#Windows_UI_Xaml_DependencyObject_Dispatcher) プロパティにアクセスして) **TextBlock** に関連するディスパッチャー オブジェクトを渡すことでフォアグラウンド スレッドを指定しています。 **winrt::resume_foreground** の実装では、そのディスパッチャー オブジェクトで [**CoreDispatcher.RunAsync**](/uwp/api/windows.ui.core.coredispatcher.runasync) を呼び出し、コルーチンでその後に続く処理を実行しています。

```cppwinrt
IAsyncAction DoWorkAsync(TextBlock textblock)
{
    co_await winrt::resume_background();
    // Do compute-bound work here.

    co_await winrt::resume_foreground(textblock.Dispatcher()); // Switch to the foreground thread associated with textblock.

    textblock.Text(L"Done!"); // Guaranteed to work.
}
```

## <a name="canceling-an-asychronous-operation-and-cancellation-callbacks"></a>非同期操作と取り消しコールバックをキャンセルします。

非同期プログラミングの Windows ランタイムの機能を使用中の非同期アクションまたは操作をキャンセルすることができます。 単純な例から始めましょう。

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

**ImplicitCancellationAsync**印刷 1 つのメッセージを 3 秒間、その後、1 秒あたりに自動的に時間が表示されますし、上記の例を実行する場合は、キャンセル中の結果として終了します。 発生しているため、この作業は、`co_await`式、コルーチンのチェックがキャンセルされたかどうか。 場合は、その後、short-circuits アウトしてください。されていない場合を中断し、通常どおりします。

取り消し、もちろん、起こりますコルーチンが中断されているとき。 コルーチンの再開時にのみ別に達したか`co_await`、取り消しに対してが確認されます。 問題では、取り消しに対応する場合の待機時間の可能性のあるすぎる粗い-細かいの 1 つです。

そのため、明示的にポーリングするには、コルーチン内からの取り消しに対してすることが別のオプションです。 以下のリスト内のコードでは、上記の例を更新します。 この新しい例では**ExplicitCancellationAsync** 、 [**winrt::get_cancellation_token**](/uwp/cpp-ref-for-winrt/get-cancellation-token)関数によって返されるオブジェクトを取得を定期的にコルーチンが取り消されたかどうかを確認します。 コルーチンが無限に; ループがキャンセルされない限り、取り消された後、ループと関数正常終了します。 結果は、前の例が、ここで終了するが、明示的に行われるため、管理と同じです。

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

**Winrt::get_cancellation_token**を待機して、お客様に代わって、コルーチンを作成**IAsyncAction**の知識を持つキャンセル トークンを取得します。 そのトークンを関数呼び出し演算子を使用するには取り消し状態を照会&mdash;取り消しに対して本質的にポーリングします。 いくつかの計算にバインドされている操作を実行している場合は、大規模なコレクションの反復し、これは、適切な手法。

### <a name="register-a-cancellation-callback"></a>取り消しコールバックを登録します。
Windows ランタイムのキャンセルない他の非同期オブジェクトに自動的に流し込まれます。 しかし、&mdash;Windows SDK のバージョン 10.0.17763.0 (Windows 10、バージョン 1809) で導入された&mdash;取り消しコールバックを登録することができます。 これは、事前フックによって取り消し反映できます、既存の同時実行ライブラリとの統合が可能になります。

次のコード例、 **NestedCoroutineAsync**は、作業には特別な取り消しロジックはありません。 **CancellationPropagatorAsync**入れ子になったコルーチン; のラッパー基本的には、します。ラッパーは、先制取り消しを転送します。

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

**CancellationPropagatorAsync**独自の取り消しコールバックのラムダ関数を登録して、その後の待機中 (中断) 入れ子になった作業が完了するまでです。 とき、または**CancellationPropagatorAsync**が取り消された場合は、入れ子になったコルーチンに取り消しを伝達します。 取り消し; をポーリングする必要はありません。取り消しがブロックされている無期限にします。 このメカニズムは、C++ の何も認識しているコルーチンまたは concurrency ライブラリとの相互運用機能を使用するのに十分な柔軟性/WinRT します。

## <a name="reporting-progress"></a>進行状況の報告

コルーチンでは、 [**IAsyncActionWithProgress**](/uwp/api/windows.foundation.iasyncactionwithprogress_tprogress_)、または[**IAsyncOperationWithProgress**](/uwp/api/windows.foundation.iasyncoperationwithprogress_tresult_tprogress_)のいずれかが返された場合ことができます、 [**winrt::get_progress_token**](/uwp/cpp-ref-for-winrt/get-progress-token)関数によって返されるオブジェクトを取得し、使用して、進行状況に進行状況を報告するハンドラーです。 次にコード例を示します。

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
> 正しい非同期アクションまたは操作中には、複数の*完了ハンドラー*を実装することはできません。 その完了のイベントの 1 つのデリゲートしたりすることができます`co_await`ことです。 両方がある場合は、2 つ目は失敗します。 いずれか完了ハンドラーの次の 2 種類のいずれかが適切です。両方の同じ非同期オブジェクト。

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

場合によっては、他の作業と同時に実行できるタスクがあるし、そのタスクを完了するを待機する必要はありません (その他の作業依存しない)、必要な値を返すこともできます。 その場合は、タスクを起動し、忘れたできます。 戻り値の型は、(代わりに、Windows ランタイム非同期操作型または**concurrency::task**のいずれか) [**winrt::fire_and_forget**](/uwp/cpp-ref-for-winrt/fire-and-forget)コルーチンを記述しているを行うことができます。

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