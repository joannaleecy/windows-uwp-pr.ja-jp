---
author: stevewhims
description: このトピックでは、C++/WinRT を使用した Windows ランタイムの非同期オブジェクトの作成方法と利用方法について説明します。
title: C++/WinRT を使用した同時実行操作と非同期操作
ms.author: stwhi
ms.date: 05/07/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10、uwp、標準、c++、cpp、winrt、プロジェクション、同時実行、非同期、非同期、非同期操作
ms.localizationpriority: medium
ms.openlocfilehash: 85071fb28cb87c991e2f5ba7f64b681c6850c819
ms.sourcegitcommit: 9e2c34a5ed3134aeca7eb9490f05b20eb9a3e5df
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/17/2018
ms.locfileid: "3988543"
---
# <a name="concurrency-and-asynchronous-operations-with-cwinrtwindowsuwpcpp-and-winrt-apisintro-to-using-cpp-with-winrt"></a><span data-ttu-id="962d9-104">[C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt) を使用した同時実行と非同期操作</span><span class="sxs-lookup"><span data-stu-id="962d9-104">Concurrency and asynchronous operations with [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)</span></span>
> [!NOTE]
> **<span data-ttu-id="962d9-105">一部の情報はリリース前の製品に関する事項であり、正式版がリリースされるまでに大幅に変更される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="962d9-105">Some information relates to pre-released product which may be substantially modified before it’s commercially released.</span></span> <span data-ttu-id="962d9-106">本書に記載された情報について、Microsoft は明示または黙示を問わずいかなる保証をするものでもありません。</span><span class="sxs-lookup"><span data-stu-id="962d9-106">Microsoft makes no warranties, express or implied, with respect to the information provided here.</span></span>**

<span data-ttu-id="962d9-107">このトピックでは、C++/WinRT を使用した Windows ランタイムの非同期オブジェクトの作成方法と利用方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="962d9-107">This topic shows the ways in which you can both create and consume Windows Runtime asynchronous objects with C++/WinRT.</span></span>

## <a name="asynchronous-operations-and-windows-runtime-async-functions"></a><span data-ttu-id="962d9-108">非同期操作と Windows ランタイムの "非同期" 関数</span><span class="sxs-lookup"><span data-stu-id="962d9-108">Asynchronous operations and Windows Runtime "Async" functions</span></span>
<span data-ttu-id="962d9-109">完了までの時間が 50 ミリ秒を超える可能性がある Windows ランタイム API は、非同期の関数 (末尾が "Async") として実装されます。</span><span class="sxs-lookup"><span data-stu-id="962d9-109">Any Windows Runtime API that has the potential to take more than 50 milliseconds to complete is implemented as an asynchronous function (with a name ending in "Async").</span></span> <span data-ttu-id="962d9-110">非同期関数を実装すると、別のスレッドの作業が開始され、非同期操作を表すオブジェクトがすぐに返されます。</span><span class="sxs-lookup"><span data-stu-id="962d9-110">The implementation of an asynchronous function initiates the work on another thread and returns immediately with an object that represents the asynchronous operation.</span></span> <span data-ttu-id="962d9-111">非同期操作が完了すると、作業結果が含まれるオブジェクトが返されます。</span><span class="sxs-lookup"><span data-stu-id="962d9-111">When the asynchronous operation completes, that returned object contains any value that resulted from the work.</span></span> <span data-ttu-id="962d9-112">**Windows::Foundation** Windows ランタイムの名前空間には 4 種類の非同期操作オブジェクトが含まれます。</span><span class="sxs-lookup"><span data-stu-id="962d9-112">The **Windows::Foundation** Windows Runtime namespace contains four types of asynchronous operation object.</span></span>

- <span data-ttu-id="962d9-113">[**IAsyncAction**](/uwp/api/windows.foundation.iasyncaction)、</span><span class="sxs-lookup"><span data-stu-id="962d9-113">[**IAsyncAction**](/uwp/api/windows.foundation.iasyncaction),</span></span>
- <span data-ttu-id="962d9-114">[**IAsyncActionWithProgress&lt;TProgress&gt;**](/uwp/api/windows.foundation.iasyncactionwithprogress_tprogress_)、</span><span class="sxs-lookup"><span data-stu-id="962d9-114">[**IAsyncActionWithProgress&lt;TProgress&gt;**](/uwp/api/windows.foundation.iasyncactionwithprogress_tprogress_),</span></span>
- <span data-ttu-id="962d9-115">[**IAsyncOperation&lt;TResult&gt;**](/uwp/api/windows.foundation.iasyncoperation_tresult_)、</span><span class="sxs-lookup"><span data-stu-id="962d9-115">[**IAsyncOperation&lt;TResult&gt;**](/uwp/api/windows.foundation.iasyncoperation_tresult_), and</span></span>
- <span data-ttu-id="962d9-116">[**IAsyncOperationWithProgress&lt;TResult, TProgress&gt;**](/uwp/api/windows.foundation.iasyncoperationwithprogress_tresult_tprogress_)。</span><span class="sxs-lookup"><span data-stu-id="962d9-116">[**IAsyncOperationWithProgress&lt;TResult, TProgress&gt;**](/uwp/api/windows.foundation.iasyncoperationwithprogress_tresult_tprogress_).</span></span>

<span data-ttu-id="962d9-117">各非同期操作は、**winrt::Windows::Foundation** C++/WinRT の名前空間で対応する型に投影されます。</span><span class="sxs-lookup"><span data-stu-id="962d9-117">Each of these asynchronous operation types is projected into a corresponding type in the **winrt::Windows::Foundation** C++/WinRT namespace.</span></span> <span data-ttu-id="962d9-118">また、C++/WinRT には内部 await アダプター構造体も含まれます。</span><span class="sxs-lookup"><span data-stu-id="962d9-118">C++/WinRT also contains an internal await adapter struct.</span></span> <span data-ttu-id="962d9-119">これを直接使用することはありませんが、これにより、これらの非同期操作型のいずれかを返す関数の結果を一緒に待機するように \`\`co_await\` ステートメントを作成することができます。</span><span class="sxs-lookup"><span data-stu-id="962d9-119">You don't use it directly but, thanks to that struct, you can write a \`\`co_await\` statement to cooperatively await the result of any function that returns one of these asychronous operation types.</span></span> <span data-ttu-id="962d9-120">その後、これらの型を返す独自のコルーチンを作成できます。</span><span class="sxs-lookup"><span data-stu-id="962d9-120">And you can author your own coroutines that return these types.</span></span>

<span data-ttu-id="962d9-121">たとえば、非同期の Windows 関数である [**SyndicationClient::RetrieveFeedAsync**](https://docs.microsoft.com/uwp/api/windows.web.syndication.syndicationclient.retrievefeedasync) は、[**IAsyncOperationWithProgress&lt;TResult, TProgress&gt;**](/uwp/api/windows.foundation.iasyncoperationwithprogress_tresult_tprogress_) 型の非同期操作オブジェクトを返します。</span><span class="sxs-lookup"><span data-stu-id="962d9-121">An example of an asynchronous Windows function is [**SyndicationClient::RetrieveFeedAsync**](https://docs.microsoft.com/uwp/api/windows.web.syndication.syndicationclient.retrievefeedasync), which returns an asynchronous operation object of type [**IAsyncOperationWithProgress&lt;TResult, TProgress&gt;**](/uwp/api/windows.foundation.iasyncoperationwithprogress_tresult_tprogress_).</span></span> <span data-ttu-id="962d9-122">それでは、C++/WinRT を使用してそのような API を呼び出すためのいくつかの方法 (ブロックと非ブロック) を示します。</span><span class="sxs-lookup"><span data-stu-id="962d9-122">Let's look at some ways&mdash;blocking and non-blocking&mdash;of using C++/WinRT to call an API such as that.</span></span>

## <a name="block-the-calling-thread"></a><span data-ttu-id="962d9-123">呼び出しスレッドのブロック</span><span class="sxs-lookup"><span data-stu-id="962d9-123">Block the calling thread</span></span>
<span data-ttu-id="962d9-124">次のコード例では、**RetrieveFeedAsync** から非同期操作オブジェクトを受け取り、非同期操作の結果が利用可能になるまで呼び出しスレッドをブロックするようにこのオブジェクトで **get** を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="962d9-124">The code example below receives an asynchronous operation object from **RetrieveFeedAsync**, and it calls **get** on that object to block the calling thread until the results of the asynchronous operation are available.</span></span>

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

<span data-ttu-id="962d9-125">**get** を呼び出すとコーディングが簡単になり、何らかの理由でコルーチンを使用しないコンソール アプリやバックグラウンド スレッドに最適です。</span><span class="sxs-lookup"><span data-stu-id="962d9-125">Calling **get** makes for convenient coding, and it's ideal for console apps or background threads where you may not want to use a coroutine for whatever reason.</span></span> <span data-ttu-id="962d9-126">ただし、同時実行でも非同期でもないため、UI スレッドには適していません (UI スレッドで使用しようとすると、最適化されないビルドでアサーションが発生します)。</span><span class="sxs-lookup"><span data-stu-id="962d9-126">But it's not concurrent nor asynchronous, so it's not appropriate for a UI thread (and an assertion will fire in unoptimized builds if you attempt to use it on one).</span></span> <span data-ttu-id="962d9-127">OS スレッドの他の有用な作業を妨げないように、さまざまな方法が必要です。</span><span class="sxs-lookup"><span data-stu-id="962d9-127">To avoid holding up OS threads from doing other useful work, we need a different technique.</span></span>

## <a name="write-a-coroutine"></a><span data-ttu-id="962d9-128">コルーチンの作成</span><span class="sxs-lookup"><span data-stu-id="962d9-128">Write a coroutine</span></span>
<span data-ttu-id="962d9-129">C++/WinRT は C++ コルーチンをプログラミング モデルに統合し、結果を連携して待機するための自然な方法を提供します。</span><span class="sxs-lookup"><span data-stu-id="962d9-129">C++/WinRT integrates C++ coroutines into the programming model to provide a natural way to cooperatively wait for a result.</span></span> <span data-ttu-id="962d9-130">コルーチンを作成すると、独自の Windows ランタイム非同期操作を作成することができます。</span><span class="sxs-lookup"><span data-stu-id="962d9-130">You can produce your own Windows Runtime asynchronous operation by writing a coroutine.</span></span> <span data-ttu-id="962d9-131">次のコード例で、**ProcessFeedAsync** はコルーチンします。</span><span class="sxs-lookup"><span data-stu-id="962d9-131">In the code example below, **ProcessFeedAsync** is the coroutine.</span></span>

> [!NOTE]
> <span data-ttu-id="962d9-132">**Get**関数が C + に存在する/WinRT プロジェクション入力**winrt::Windows::Foundation::IAsyncAction**、c++ 内から関数を呼び出すことができます/WinRT プロジェクトです。</span><span class="sxs-lookup"><span data-stu-id="962d9-132">The **get** function exists on the C++/WinRT projection type **winrt::Windows::Foundation::IAsyncAction**, so you can call the function from within any C++/WinRT project.</span></span> <span data-ttu-id="962d9-133">実際の Windows ランタイム型**IAsyncAction**のアプリケーション バイナリ インターフェイス (ABI) サーフェスの一部でない**を取得する**ため、 [**IAsyncAction**](/uwp/api/windows.foundation.iasyncaction)インターフェイスのメンバーとして記載されている関数は検索されません。</span><span class="sxs-lookup"><span data-stu-id="962d9-133">You will not find the function listed as a member of the [**IAsyncAction**](/uwp/api/windows.foundation.iasyncaction) interface, because **get** is not part of the application binary interface (ABI) surface of the actual Windows Runtime type **IAsyncAction**.</span></span>

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

<span data-ttu-id="962d9-134">コルーチンは中断して再開できる関数です。</span><span class="sxs-lookup"><span data-stu-id="962d9-134">A coroutine is a function that can be suspended and resumed.</span></span> <span data-ttu-id="962d9-135">上記の **ProcessFeedAsync** コルーチンでは、`co_await` ステートメントに到達すると、コルーチンは **RetrieveFeedAsync** 呼び出しを非同期的に起動してからすぐに自身を中断し、呼び出し元 (上記の例の **main**) に戻ります。</span><span class="sxs-lookup"><span data-stu-id="962d9-135">In the **ProcessFeedAsync** coroutine above, when the `co_await` statement is reached, the coroutine asynchronously initiates the **RetrieveFeedAsync** call and then it immediately suspends itself and returns control back to the caller (which is **main** in the example above).</span></span> <span data-ttu-id="962d9-136">次に、フィードが取得および印刷されるまで、**main** は作業を続けます。</span><span class="sxs-lookup"><span data-stu-id="962d9-136">**main** can then continue to do work while the feed is being retrieved and printed.</span></span> <span data-ttu-id="962d9-137">完了すると (**RetrieveFeedAsync** 呼び出しが完了すると)、**ProcessFeedAsync** コルーチンは次のステートメントを再開します。</span><span class="sxs-lookup"><span data-stu-id="962d9-137">When that's done (when the **RetrieveFeedAsync** call completes), the **ProcessFeedAsync** coroutine resumes at the next statement.</span></span>

<span data-ttu-id="962d9-138">コルーチンは別のコルーチンに集約することができます。</span><span class="sxs-lookup"><span data-stu-id="962d9-138">You can aggregate a coroutine into other coroutines.</span></span> <span data-ttu-id="962d9-139">または、**get** を呼び出してブロックするか、完了するまで待機します (結果が存在する場合には取得します)。</span><span class="sxs-lookup"><span data-stu-id="962d9-139">Or you can call **get** to block and wait for it to complete (and get the result if there is one).</span></span> <span data-ttu-id="962d9-140">または、Windows ランタイムをサポートする別のプログラミング言語に渡すことができます。</span><span class="sxs-lookup"><span data-stu-id="962d9-140">Or you can pass it to another programming language that supports the Windows Runtime.</span></span>

<span data-ttu-id="962d9-141">また、デリゲートを使用して、非同期アクションおよび操作の完了イベントと進行状況イベントを処理することもできます。</span><span class="sxs-lookup"><span data-stu-id="962d9-141">It's also possible to handle the completed and/or progress events of asynchronous actions and operations by using delegates.</span></span> <span data-ttu-id="962d9-142">詳細とコード例については、「[非同期アクションと操作のデリゲート型](handle-events.md#delegate-types-for-asynchronous-actions-and-operations)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="962d9-142">For details, and code examples, see [Delegate types for asynchronous actions and operations](handle-events.md#delegate-types-for-asynchronous-actions-and-operations).</span></span>

## <a name="asychronously-return-a-windows-runtime-type"></a><span data-ttu-id="962d9-143">Windows ランタイム型を非同期的に返す</span><span class="sxs-lookup"><span data-stu-id="962d9-143">Asychronously return a Windows Runtime type</span></span>
<span data-ttu-id="962d9-144">次の例では、特定の URI で呼び出しを **RetrieveFeedAsync** にラップして、[**SyndicationFeed**](/uwp/api/windows.web.syndication.syndicationfeed) を非同期的に返す **RetrieveBlogFeedAsync** 関数を示します。</span><span class="sxs-lookup"><span data-stu-id="962d9-144">In this next example we wrap a call to **RetrieveFeedAsync**, for a specific URI, to give us a **RetrieveBlogFeedAsync** function that asynchronously returns a [**SyndicationFeed**](/uwp/api/windows.web.syndication.syndicationfeed).</span></span>

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

<span data-ttu-id="962d9-145">次の例では、**RetrieveBlogFeedAsync** は進捗状況と戻り値の両方が含まれる **IAsyncOperationWithProgress** を返します。</span><span class="sxs-lookup"><span data-stu-id="962d9-145">In the example above, **RetrieveBlogFeedAsync** returns an **IAsyncOperationWithProgress**, which has both progress and a return value.</span></span> <span data-ttu-id="962d9-146">**RetrieveBlogFeedAsync** が自分の処理を行い、フィードを取得している間は、他の作業を行うことができます。</span><span class="sxs-lookup"><span data-stu-id="962d9-146">We can do other work while **RetrieveBlogFeedAsync** is doing its thing and retrieving the feed.</span></span> <span data-ttu-id="962d9-147">次に、非同期操作オブジェクトで **get** を呼び出し、ブロックするか完了まで待機して、操作結果を取得します。</span><span class="sxs-lookup"><span data-stu-id="962d9-147">Then, we call **get** on that asynchronous operation object to block, wait for it to complete, and then obtain the results of the operation.</span></span>

<span data-ttu-id="962d9-148">Windows ランタイム型を非同期的に返す場合は、[**IAsyncOperation&lt;TResult&gt;**](/uwp/api/windows.foundation.iasyncoperation_tresult_) または [**IAsyncOperationWithProgress&lt;TResult, TProgress&gt;**](/uwp/api/windows.foundation.iasyncoperationwithprogress_tresult_tprogress_) を返す必要があります。</span><span class="sxs-lookup"><span data-stu-id="962d9-148">If you're asynchronously returning a Windows Runtime type, then you should return an [**IAsyncOperation&lt;TResult&gt;**](/uwp/api/windows.foundation.iasyncoperation_tresult_) or an [**IAsyncOperationWithProgress&lt;TResult, TProgress&gt;**](/uwp/api/windows.foundation.iasyncoperationwithprogress_tresult_tprogress_).</span></span> <span data-ttu-id="962d9-149">ファースト パーティ製またはサード パーティ製のランタイム クラス、または Windows ランタイム関数との間で受け渡しできる任意の型 (例、`int` または **winrt::hstring**) がこれに適合します。</span><span class="sxs-lookup"><span data-stu-id="962d9-149">Any first- or third-party runtime class qualifies, or any type that can be passed to or from a Windows Runtime function (for example, `int`, or **winrt::hstring**).</span></span> <span data-ttu-id="962d9-150">コンパイラは、Windows ランタイム型以外でこれらの非同期操作型のいずれかを使用しようとすると表示される "*WinRT 型である必要があります*" というエラーをサポートします。</span><span class="sxs-lookup"><span data-stu-id="962d9-150">The compiler will help you with a "*must be WinRT type*" error if you try to use one of these asychronous operation types with a non-Windows Runtime type.</span></span>

<span data-ttu-id="962d9-151">コルーチンに 1 つ以上の `co_await` ステートメントがない場合、コルーチンであると認められるために、1 つ以上の `co_return` または 1 つの `co_yield` ステートメントが必要です。</span><span class="sxs-lookup"><span data-stu-id="962d9-151">If a coroutine doesn't have at least one `co_await` statement then, in order to qualify as a coroutine, it must have at least one `co_return` or one `co_yield` statement.</span></span> <span data-ttu-id="962d9-152">非同期操作を必要とせず、そのためにコンテキストのブロックや切り替えを行わずに、コルーチンが値を返すことができる場合があります。</span><span class="sxs-lookup"><span data-stu-id="962d9-152">There will be cases where your coroutine can return a value without introducing any asynchrony, and therefore without blocking nor switching context.</span></span> <span data-ttu-id="962d9-153">値をキャッシュすることでそれを行う例を次に示します (2 回目以降は呼び出されます)。</span><span class="sxs-lookup"><span data-stu-id="962d9-153">Here's an example that does that (the second and subsequent times it's called) by caching a value.</span></span>

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

## <a name="asychronously-return-a-non-windows-runtime-type"></a><span data-ttu-id="962d9-154">Windows ランタイム型以外を非同期的に返す</span><span class="sxs-lookup"><span data-stu-id="962d9-154">Asychronously return a non-Windows-Runtime type</span></span>
<span data-ttu-id="962d9-155">Windows ランタイム型*以外*の型を非同期的に返す場合は、並列パターン ライブラリ (PPL) [**concurrency::task**](/cpp/parallel/concrt/reference/task-class) を返す必要があります。</span><span class="sxs-lookup"><span data-stu-id="962d9-155">If you're asynchronously returning a type that's *not* a Windows Runtime type, then you should return a Parallel Patterns Library (PPL) [**concurrency::task**](/cpp/parallel/concrt/reference/task-class).</span></span> <span data-ttu-id="962d9-156">**std::future**よりもパフォーマンスに優れているため (また、今後の互換性の向上により)、**concurrency::task** をお勧めします。</span><span class="sxs-lookup"><span data-stu-id="962d9-156">We recommend **concurrency::task** because it gives you better performance (and better compatibility going forward) than **std::future** does.</span></span>

> [!TIP]
> <span data-ttu-id="962d9-157">`<pplawait.h>` を含めると、コルーチンの型として **concurrency::task** を使用できます。</span><span class="sxs-lookup"><span data-stu-id="962d9-157">If you include `<pplawait.h>`, then you can use **concurrency::task** as a coroutine type.</span></span>

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

## <a name="parameter-passing"></a><span data-ttu-id="962d9-158">パラメーターの引き渡し</span><span class="sxs-lookup"><span data-stu-id="962d9-158">Parameter-passing</span></span>
<span data-ttu-id="962d9-159">同期関数では、既定で `const&` パラメーターを使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="962d9-159">For synchronous functions, you should use `const&` parameters by default.</span></span> <span data-ttu-id="962d9-160">これにより、コピーのオーバーヘッドが回避されます (参照カウント、つまりインタロックされたインクリメントとデクリメントが含まれます)。</span><span class="sxs-lookup"><span data-stu-id="962d9-160">That will avoid the overhead of copies (which involve reference counting, and that means interlocked increments and decrements).</span></span>

```cppwinrt
// Synchronous function.
void DoWork(Param const& value);
```

<span data-ttu-id="962d9-161">ただし、コルーチンに参照パラメーターを渡した場合、問題が発生する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="962d9-161">But you can run into problems if you pass a reference parameter to a coroutine.</span></span>

```cppwinrt
// NOT the recommended way to pass a value to a coroutine!
IASyncAction DoWorkAsync(Param const& value)
{
    // While it's ok to access value here...
    
    co_await DoOtherWorkAsync();

    // ...accessing value here carries no guarantees of safety.
}
```

<span data-ttu-id="962d9-162">コルーチンでは、最初の一時停止ポイントまで実行は同期であり、ここでは、コントロールは呼び出し元に返されます。</span><span class="sxs-lookup"><span data-stu-id="962d9-162">In a coroutine, execution is synchronous up until the first suspension point, where control is returned to the caller.</span></span> <span data-ttu-id="962d9-163">コルーチンが再開するまで、参照パラメーターが参照するソース値に何かが発生している可能性があります。</span><span class="sxs-lookup"><span data-stu-id="962d9-163">By the time the coroutine resumes, anything might have happened to the source value that a reference parameter references.</span></span> <span data-ttu-id="962d9-164">コルーチンの観点からは、参照パラメーターには管理されていない有効期間があります。</span><span class="sxs-lookup"><span data-stu-id="962d9-164">From the coroutine's perspective, a reference parameter has uncontrolled lifetime.</span></span> <span data-ttu-id="962d9-165">そのため、上記の例では、`co_await` まで*値*に安全にアクセスできますが、それ以降は安全ではありません。</span><span class="sxs-lookup"><span data-stu-id="962d9-165">So, in the example above, we're safe to access *value* up until the `co_await`, but not after it.</span></span> <span data-ttu-id="962d9-166">また、その後その関数が中断し、再開した後で*値*を使用しようとするリスクがある場合、**DoOtherWorkAsync** に安全に*値*を渡すこともできません。</span><span class="sxs-lookup"><span data-stu-id="962d9-166">Nor can we safely pass *value* to **DoOtherWorkAsync** if there's any risk that that function will in turn suspend and then try to use *value* after it resumes.</span></span> <span data-ttu-id="962d9-167">中断して再開した後で、パラメーターを安全に使用できるようにするには、コルーチンは既定で値渡しを使用し、値でキャプチャして有効期間の問題を回避できるようにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="962d9-167">To make parameters safe to use after suspending and resuming, your coroutines should use pass-by-value by default to ensure that they capture by value and avoid lifetime issues.</span></span> <span data-ttu-id="962d9-168">それを行うことが安全であると確信できるためにそのガイダンスから逸脱できる場合は稀です。</span><span class="sxs-lookup"><span data-stu-id="962d9-168">Cases when you can deviate from that guidance because you're certain that it's safe to do so are going to be rare.</span></span>

```cppwinrt
// Coroutine
IASyncAction DoWorkAsync(Param value);
```

<span data-ttu-id="962d9-169">(値を移動しない限り) 定数値を渡すことが良い方法であるということにも議論の余地があります。</span><span class="sxs-lookup"><span data-stu-id="962d9-169">It's also arguable that (unless you want to move the value) passing by const value is good practice.</span></span> <span data-ttu-id="962d9-170">コピー元のソース値に影響はありませんが、意図が明確になり、誤ってコピーを変更した場合に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="962d9-170">It won't have any effect on the source value from which you're making a copy, but it makes the intent clear, and helps if you inadvertently modify the copy.</span></span>
    
```cppwinrt
// coroutine with strictly unnecessary const (but arguably good practice).
IASyncAction DoWorkAsync(Param const value);
```

<span data-ttu-id="962d9-171">非同期の呼び出し先に標準ベクターを渡す方法について説明した「[標準的な配列とベクトル](std-cpp-data-types.md#standard-arrays-and-vectors)」も参照してください。</span><span class="sxs-lookup"><span data-stu-id="962d9-171">Also see [Standard arrays and vectors](std-cpp-data-types.md#standard-arrays-and-vectors), which deals with how to pass a standard vector into an asynchronous callee.</span></span>

## <a name="offloading-work-onto-the-windows-thread-pool"></a><span data-ttu-id="962d9-172">Windows スレッド プールへの処理のオフロード</span><span class="sxs-lookup"><span data-stu-id="962d9-172">Offloading work onto the Windows thread pool</span></span>
<span data-ttu-id="962d9-173">コルーチンで計算処理にかかる処理を行う前に、呼び出し元がブロックされないように呼び出し元に実行を返す必要があります (つまり、一時停止ポイントを導入します)。</span><span class="sxs-lookup"><span data-stu-id="962d9-173">Before you do compute-bound work in a coroutine, you need to return execution to the caller so that the caller isn't blocked (in other words, introduce a suspension point).</span></span> <span data-ttu-id="962d9-174">その他の操作を `co-await` することでこれをまだ行っていない場合は、**winrt::resume_background** 関数を `co-await` できます。</span><span class="sxs-lookup"><span data-stu-id="962d9-174">If you're not already doing that by `co-await`-ing some other operation, then you can `co-await` the **winrt::resume_background** function.</span></span> <span data-ttu-id="962d9-175">これにより、呼び出し元に制御が返され、スレッド プールのスレッドですぐに実行が再開されます。</span><span class="sxs-lookup"><span data-stu-id="962d9-175">That returns control to the caller, and then immediately resumes execution on a thread pool thread.</span></span>

<span data-ttu-id="962d9-176">実装で使用されているスレッド プールは低レベルの [Windows スレッド プール](https://msdn.microsoft.com/library/windows/desktop/ms686766)であるため、最適に効率化されます。</span><span class="sxs-lookup"><span data-stu-id="962d9-176">The thread pool being used in the implementation is the low-level [Windows thread pool](https://msdn.microsoft.com/library/windows/desktop/ms686766), so it's optimially efficient.</span></span>

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

## <a name="programming-with-thread-affinity-in-mind"></a><span data-ttu-id="962d9-177">スレッドの関係を考慮したプログラミング</span><span class="sxs-lookup"><span data-stu-id="962d9-177">Programming with thread affinity in mind</span></span>
<span data-ttu-id="962d9-178">このシナリオは、前のシナリオをさらに詳しく説明しています。</span><span class="sxs-lookup"><span data-stu-id="962d9-178">This scenario expands on the previous one.</span></span> <span data-ttu-id="962d9-179">一部の処理をスレッド プールにオフロードするが、ユーザー インターフェイス (UI) で進行状況を表示したいとします。</span><span class="sxs-lookup"><span data-stu-id="962d9-179">You offload some work onto the thread pool, but then you want to display progress in the user interface (UI).</span></span>

```cppwinrt
IAsyncAction DoWorkAsync(TextBlock textblock)
{
    co_await winrt::resume_background();
    // Do compute-bound work here.

    textblock.Text(L"Done!"); // Error: TextBlock has thread affinity.
}
```

<span data-ttu-id="962d9-180">上のコードは、[**winrt::hresult_wrong_thread**](/uwp/cpp-ref-for-winrt/hresult-wrong-thread) 例外をスローします。これは、**TextBlock** がそれを作成したスレッド (UI スレッド) から更新する必要があるためです。</span><span class="sxs-lookup"><span data-stu-id="962d9-180">The code above throws a [**winrt::hresult_wrong_thread**](/uwp/cpp-ref-for-winrt/hresult-wrong-thread) exception, because a **TextBlock** must be updated from the thread that created it, which is the UI thread.</span></span> <span data-ttu-id="962d9-181">1 つの解決方法は、コルーチンが最初に呼び出されたスレッド コンテキストをキャプチャする方法です。</span><span class="sxs-lookup"><span data-stu-id="962d9-181">One solution is to capture the thread context within which our coroutine was originally called.</span></span> <span data-ttu-id="962d9-182">**winrt::apartment_context** オブジェクトをインスタンス化し、それを `co_await` します。</span><span class="sxs-lookup"><span data-stu-id="962d9-182">Instantiate a **winrt::apartment_context** object, and then `co_await` it.</span></span>

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

<span data-ttu-id="962d9-183">上のコルーチンが **TextBlock** を作成した UI スレッドから呼び出される限り、この手法は機能します。</span><span class="sxs-lookup"><span data-stu-id="962d9-183">As long as the coroutine above is called from the UI thread that created the **TextBlock**, then this technique works.</span></span> <span data-ttu-id="962d9-184">アプリで多くの場合にそれを確信できます。</span><span class="sxs-lookup"><span data-stu-id="962d9-184">There will be many cases in your app where you're certain of that.</span></span>

> [!NOTE]
> **<span data-ttu-id="962d9-185">次のコード例は、リリース前の製品に関するものであり、正式版がリリースされるまでに大幅に変更される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="962d9-185">The following code example relates to pre-released product which may be substantially modified before it’s commercially released.</span></span> <span data-ttu-id="962d9-186">本書に記載された情報について、Microsoft は明示または黙示を問わずいかなる保証をするものでもありません。</span><span class="sxs-lookup"><span data-stu-id="962d9-186">Microsoft makes no warranties, express or implied, with respect to the information provided here.</span></span>**

<span data-ttu-id="962d9-187">スレッドの呼び出しがよくわからない場合を対象とした、UI の更新に対するより一般的な解決策として、[Windows 10 SDK プレビュー ビルド 17661](https://www.microsoft.com/software-download/windowsinsiderpreviewSDK) 以降をインストールすることができます。</span><span class="sxs-lookup"><span data-stu-id="962d9-187">For a more general solution to updating UI, which covers cases where you're uncertain about the calling thread, you can install the [Windows 10 SDK Preview Build 17661](https://www.microsoft.com/software-download/windowsinsiderpreviewSDK), or later.</span></span> <span data-ttu-id="962d9-188">その後、**winrt::resume_foreground** 関数を `co-await` して特定のフォアグラウンド スレッドに切り替えることができます。</span><span class="sxs-lookup"><span data-stu-id="962d9-188">Then, you can `co-await` the **winrt::resume_foreground** function to switch to a specific foreground thread.</span></span> <span data-ttu-id="962d9-189">次のコード例では、([**Dispatcher**](/uwp/api/windows.ui.xaml.dependencyobject.dispatcher#Windows_UI_Xaml_DependencyObject_Dispatcher) プロパティにアクセスして) **TextBlock** に関連するディスパッチャー オブジェクトを渡すことでフォアグラウンド スレッドを指定しています。</span><span class="sxs-lookup"><span data-stu-id="962d9-189">In the code example below, we specify the foreground thread by passing the dispatcher object associated with the **TextBlock** (by accessing its [**Dispatcher**](/uwp/api/windows.ui.xaml.dependencyobject.dispatcher#Windows_UI_Xaml_DependencyObject_Dispatcher) property).</span></span> <span data-ttu-id="962d9-190">**winrt::resume_foreground** の実装では、そのディスパッチャー オブジェクトで [**CoreDispatcher.RunAsync**](/uwp/api/windows.ui.core.coredispatcher.runasync) を呼び出し、コルーチンでその後に続く処理を実行しています。</span><span class="sxs-lookup"><span data-stu-id="962d9-190">The implementation of **winrt::resume_foreground** calls [**CoreDispatcher.RunAsync**](/uwp/api/windows.ui.core.coredispatcher.runasync) on that dispatcher object to execute the work that comes after it in the coroutine.</span></span>

```cppwinrt
IAsyncAction DoWorkAsync(TextBlock textblock)
{
    co_await winrt::resume_background();
    // Do compute-bound work here.

    co_await winrt::resume_foreground(textblock.Dispatcher()); // Switch to the foreground thread associated with textblock.

    textblock.Text(L"Done!"); // Guaranteed to work.
}
```

## <a name="important-apis"></a><span data-ttu-id="962d9-191">重要な API</span><span class="sxs-lookup"><span data-stu-id="962d9-191">Important APIs</span></span>
* [<span data-ttu-id="962d9-192">concurrency::task クラス</span><span class="sxs-lookup"><span data-stu-id="962d9-192">concurrency::task class</span></span>](/cpp/parallel/concrt/reference/task-class)
* [<span data-ttu-id="962d9-193">IAsyncAction インターフェイス</span><span class="sxs-lookup"><span data-stu-id="962d9-193">IAsyncAction interface</span></span>](/uwp/api/windows.foundation.iasyncaction)
* [<span data-ttu-id="962d9-194">IAsyncActionWithProgress&lt;TProgress&gt;インターフェイス</span><span class="sxs-lookup"><span data-stu-id="962d9-194">IAsyncActionWithProgress&lt;TProgress&gt; interface</span></span>](/uwp/api/windows.foundation.iasyncactionwithprogress_tprogress_)
* [<span data-ttu-id="962d9-195">IAsyncOperation&lt;TResult&gt;インターフェイス</span><span class="sxs-lookup"><span data-stu-id="962d9-195">IAsyncOperation&lt;TResult&gt; interface</span></span>](/uwp/api/windows.foundation.iasyncoperation_tresult_)
* [<span data-ttu-id="962d9-196">IAsyncOperationWithProgress&lt;TResult, TProgress&gt;インターフェイス</span><span class="sxs-lookup"><span data-stu-id="962d9-196">IAsyncOperationWithProgress&lt;TResult, TProgress&gt; interface</span></span>](/uwp/api/windows.foundation.iasyncoperationwithprogress_tresult_tprogress_)
* [<span data-ttu-id="962d9-197">Syndicationclient::retrievefeedasync メソッド</span><span class="sxs-lookup"><span data-stu-id="962d9-197">SyndicationClient::RetrieveFeedAsync method</span></span>](/uwp/api/windows.web.syndication.syndicationclient.retrievefeedasync)
* [<span data-ttu-id="962d9-198">SyndicationFeed クラス</span><span class="sxs-lookup"><span data-stu-id="962d9-198">SyndicationFeed class</span></span>](/uwp/api/windows.web.syndication.syndicationfeed)

## <a name="related-topics"></a><span data-ttu-id="962d9-199">関連トピック</span><span class="sxs-lookup"><span data-stu-id="962d9-199">Related topics</span></span>
* [<span data-ttu-id="962d9-200">C++/WinRT でのデリゲートを使用したイベントの処理</span><span class="sxs-lookup"><span data-stu-id="962d9-200">Handle events by using delegates in C++/WinRT</span></span>](handle-events.md)
* [<span data-ttu-id="962d9-201">標準的な C++ のデータ型と C++/WinRT</span><span class="sxs-lookup"><span data-stu-id="962d9-201">Standard C++ data types and C++/WinRT</span></span>](std-cpp-data-types.md)