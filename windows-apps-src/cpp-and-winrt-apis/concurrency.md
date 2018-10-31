---
author: stevewhims
description: このトピックでは、C++/WinRT を使用した Windows ランタイムの非同期オブジェクトの作成方法と利用方法について説明します。
title: C++/WinRT を使用した同時実行操作と非同期操作
ms.author: stwhi
ms.date: 10/27/2018
ms.topic: article
keywords: Windows 10、uwp、標準、c++、cpp、winrt、プロジェクション、同時実行、非同期、非同期、非同期操作
ms.localizationpriority: medium
ms.openlocfilehash: d59fec17c1e8cc340f630ba236f7361325046ea2
ms.sourcegitcommit: ca96031debe1e76d4501621a7680079244ef1c60
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/30/2018
ms.locfileid: "5824489"
---
# <a name="concurrency-and-asynchronous-operations-with-cwinrt"></a><span data-ttu-id="1f2a9-104">C++/WinRT を使用した同時実行操作と非同期操作</span><span class="sxs-lookup"><span data-stu-id="1f2a9-104">Concurrency and asynchronous operations with C++/WinRT</span></span>

<span data-ttu-id="1f2a9-105">このトピックでは両方ともできる方法の作成し、Windows ランタイムの非同期オブジェクトを利用[、C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)します。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-105">This topic shows the ways in which you can both create and consume Windows Runtime asynchronous objects with [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt).</span></span>

## <a name="asynchronous-operations-and-windows-runtime-async-functions"></a><span data-ttu-id="1f2a9-106">非同期操作と Windows ランタイムの "非同期" 関数</span><span class="sxs-lookup"><span data-stu-id="1f2a9-106">Asynchronous operations and Windows Runtime "Async" functions</span></span>

<span data-ttu-id="1f2a9-107">完了までの時間が 50 ミリ秒を超える可能性がある Windows ランタイム API は、非同期の関数 (末尾が "Async") として実装されます。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-107">Any Windows Runtime API that has the potential to take more than 50 milliseconds to complete is implemented as an asynchronous function (with a name ending in "Async").</span></span> <span data-ttu-id="1f2a9-108">非同期関数を実装すると、別のスレッドの作業が開始され、非同期操作を表すオブジェクトがすぐに返されます。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-108">The implementation of an asynchronous function initiates the work on another thread and returns immediately with an object that represents the asynchronous operation.</span></span> <span data-ttu-id="1f2a9-109">非同期操作が完了すると、作業結果が含まれるオブジェクトが返されます。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-109">When the asynchronous operation completes, that returned object contains any value that resulted from the work.</span></span> <span data-ttu-id="1f2a9-110">**Windows::Foundation** Windows ランタイムの名前空間には 4 種類の非同期操作オブジェクトが含まれます。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-110">The **Windows::Foundation** Windows Runtime namespace contains four types of asynchronous operation object.</span></span>

- <span data-ttu-id="1f2a9-111">[**IAsyncAction**](/uwp/api/windows.foundation.iasyncaction)、</span><span class="sxs-lookup"><span data-stu-id="1f2a9-111">[**IAsyncAction**](/uwp/api/windows.foundation.iasyncaction),</span></span>
- <span data-ttu-id="1f2a9-112">[**IAsyncActionWithProgress&lt;TProgress&gt;**](/uwp/api/windows.foundation.iasyncactionwithprogress_tprogress_)、</span><span class="sxs-lookup"><span data-stu-id="1f2a9-112">[**IAsyncActionWithProgress&lt;TProgress&gt;**](/uwp/api/windows.foundation.iasyncactionwithprogress_tprogress_),</span></span>
- <span data-ttu-id="1f2a9-113">[**IAsyncOperation&lt;TResult&gt;**](/uwp/api/windows.foundation.iasyncoperation_tresult_)、</span><span class="sxs-lookup"><span data-stu-id="1f2a9-113">[**IAsyncOperation&lt;TResult&gt;**](/uwp/api/windows.foundation.iasyncoperation_tresult_), and</span></span>
- <span data-ttu-id="1f2a9-114">[**IAsyncOperationWithProgress&lt;TResult, TProgress&gt;**](/uwp/api/windows.foundation.iasyncoperationwithprogress_tresult_tprogress_)。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-114">[**IAsyncOperationWithProgress&lt;TResult, TProgress&gt;**](/uwp/api/windows.foundation.iasyncoperationwithprogress_tresult_tprogress_).</span></span>

<span data-ttu-id="1f2a9-115">各非同期操作は、**winrt::Windows::Foundation** C++/WinRT の名前空間で対応する型に投影されます。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-115">Each of these asynchronous operation types is projected into a corresponding type in the **winrt::Windows::Foundation** C++/WinRT namespace.</span></span> <span data-ttu-id="1f2a9-116">また、C++/WinRT には内部 await アダプター構造体も含まれます。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-116">C++/WinRT also contains an internal await adapter struct.</span></span> <span data-ttu-id="1f2a9-117">直接が、これにより、その構造体は使用しない、作成、`co_await`ステートメントを一緒にこれらの非同期操作型のいずれかを返す関数の結果を待機します。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-117">You don't use it directly but, thanks to that struct, you can write a `co_await` statement to cooperatively await the result of any function that returns one of these asychronous operation types.</span></span> <span data-ttu-id="1f2a9-118">その後、これらの型を返す独自のコルーチンを作成できます。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-118">And you can author your own coroutines that return these types.</span></span>

<span data-ttu-id="1f2a9-119">たとえば、非同期の Windows 関数である [**SyndicationClient::RetrieveFeedAsync**](https://docs.microsoft.com/uwp/api/windows.web.syndication.syndicationclient.retrievefeedasync) は、[**IAsyncOperationWithProgress&lt;TResult, TProgress&gt;**](/uwp/api/windows.foundation.iasyncoperationwithprogress_tresult_tprogress_) 型の非同期操作オブジェクトを返します。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-119">An example of an asynchronous Windows function is [**SyndicationClient::RetrieveFeedAsync**](https://docs.microsoft.com/uwp/api/windows.web.syndication.syndicationclient.retrievefeedasync), which returns an asynchronous operation object of type [**IAsyncOperationWithProgress&lt;TResult, TProgress&gt;**](/uwp/api/windows.foundation.iasyncoperationwithprogress_tresult_tprogress_).</span></span> <span data-ttu-id="1f2a9-120">いくつかの方法を見てみましょう&mdash;、最初のブロックとし、非ブロック&mdash;を使用して、C++ の/WinRT をそのような API を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-120">Let's look at some ways&mdash;first blocking, and then non-blocking&mdash;of using C++/WinRT to call an API such as that.</span></span>

## <a name="block-the-calling-thread"></a><span data-ttu-id="1f2a9-121">呼び出しスレッドのブロック</span><span class="sxs-lookup"><span data-stu-id="1f2a9-121">Block the calling thread</span></span>

<span data-ttu-id="1f2a9-122">次のコード例では、**RetrieveFeedAsync** から非同期操作オブジェクトを受け取り、非同期操作の結果が利用可能になるまで呼び出しスレッドをブロックするようにこのオブジェクトで **get** を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-122">The code example below receives an asynchronous operation object from **RetrieveFeedAsync**, and it calls **get** on that object to block the calling thread until the results of the asynchronous operation are available.</span></span>

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

<span data-ttu-id="1f2a9-123">**get** を呼び出すとコーディングが簡単になり、何らかの理由でコルーチンを使用しないコンソール アプリやバックグラウンド スレッドに最適です。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-123">Calling **get** makes for convenient coding, and it's ideal for console apps or background threads where you may not want to use a coroutine for whatever reason.</span></span> <span data-ttu-id="1f2a9-124">ただし、同時実行でも非同期でもないため、UI スレッドには適していません (UI スレッドで使用しようとすると、最適化されないビルドでアサーションが発生します)。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-124">But it's not concurrent nor asynchronous, so it's not appropriate for a UI thread (and an assertion will fire in unoptimized builds if you attempt to use it on one).</span></span> <span data-ttu-id="1f2a9-125">OS スレッドの他の有用な作業を妨げないように、さまざまな方法が必要です。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-125">To avoid holding up OS threads from doing other useful work, we need a different technique.</span></span>

## <a name="write-a-coroutine"></a><span data-ttu-id="1f2a9-126">コルーチンの作成</span><span class="sxs-lookup"><span data-stu-id="1f2a9-126">Write a coroutine</span></span>

<span data-ttu-id="1f2a9-127">C++/WinRT は C++ コルーチンをプログラミング モデルに統合し、結果を連携して待機するための自然な方法を提供します。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-127">C++/WinRT integrates C++ coroutines into the programming model to provide a natural way to cooperatively wait for a result.</span></span> <span data-ttu-id="1f2a9-128">コルーチンを作成すると、独自の Windows ランタイム非同期操作を作成することができます。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-128">You can produce your own Windows Runtime asynchronous operation by writing a coroutine.</span></span> <span data-ttu-id="1f2a9-129">次のコード例で、**ProcessFeedAsync** はコルーチンします。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-129">In the code example below, **ProcessFeedAsync** is the coroutine.</span></span>

> [!NOTE]
> <span data-ttu-id="1f2a9-130">C++ に**get**関数が存在する/WinRT プロジェクション入力**winrt::Windows::Foundation::IAsyncAction**、c++ 内から関数を呼び出すことができます/WinRT プロジェクトです。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-130">The **get** function exists on the C++/WinRT projection type **winrt::Windows::Foundation::IAsyncAction**, so you can call the function from within any C++/WinRT project.</span></span> <span data-ttu-id="1f2a9-131">実際の Windows ランタイム型**IAsyncAction**のアプリケーション バイナリ インターフェイス (ABI) のサーフェスの一部でない**を取得する**ため、 [**IAsyncAction**](/uwp/api/windows.foundation.iasyncaction)インターフェイスのメンバーとして記載されている関数は検索されません。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-131">You will not find the function listed as a member of the [**IAsyncAction**](/uwp/api/windows.foundation.iasyncaction) interface, because **get** is not part of the application binary interface (ABI) surface of the actual Windows Runtime type **IAsyncAction**.</span></span>

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

<span data-ttu-id="1f2a9-132">コルーチンは中断して再開できる関数です。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-132">A coroutine is a function that can be suspended and resumed.</span></span> <span data-ttu-id="1f2a9-133">上記の **ProcessFeedAsync** コルーチンでは、`co_await` ステートメントに到達すると、コルーチンは **RetrieveFeedAsync** 呼び出しを非同期的に起動してからすぐに自身を中断し、呼び出し元 (上記の例の **main**) に戻ります。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-133">In the **ProcessFeedAsync** coroutine above, when the `co_await` statement is reached, the coroutine asynchronously initiates the **RetrieveFeedAsync** call and then it immediately suspends itself and returns control back to the caller (which is **main** in the example above).</span></span> <span data-ttu-id="1f2a9-134">次に、フィードが取得および印刷されるまで、**main** は作業を続けます。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-134">**main** can then continue to do work while the feed is being retrieved and printed.</span></span> <span data-ttu-id="1f2a9-135">完了すると (**RetrieveFeedAsync** 呼び出しが完了すると)、**ProcessFeedAsync** コルーチンは次のステートメントを再開します。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-135">When that's done (when the **RetrieveFeedAsync** call completes), the **ProcessFeedAsync** coroutine resumes at the next statement.</span></span>

<span data-ttu-id="1f2a9-136">コルーチンは別のコルーチンに集約することができます。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-136">You can aggregate a coroutine into other coroutines.</span></span> <span data-ttu-id="1f2a9-137">または、**get** を呼び出してブロックするか、完了するまで待機します (結果が存在する場合には取得します)。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-137">Or you can call **get** to block and wait for it to complete (and get the result if there is one).</span></span> <span data-ttu-id="1f2a9-138">または、Windows ランタイムをサポートする別のプログラミング言語に渡すことができます。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-138">Or you can pass it to another programming language that supports the Windows Runtime.</span></span>

<span data-ttu-id="1f2a9-139">また、デリゲートを使用して、非同期アクションおよび操作の完了イベントと進行状況イベントを処理することもできます。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-139">It's also possible to handle the completed and/or progress events of asynchronous actions and operations by using delegates.</span></span> <span data-ttu-id="1f2a9-140">詳細とコード例については、「[非同期アクションと操作のデリゲート型](handle-events.md#delegate-types-for-asynchronous-actions-and-operations)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-140">For details, and code examples, see [Delegate types for asynchronous actions and operations](handle-events.md#delegate-types-for-asynchronous-actions-and-operations).</span></span>

## <a name="asychronously-return-a-windows-runtime-type"></a><span data-ttu-id="1f2a9-141">Windows ランタイム型を非同期的に返す</span><span class="sxs-lookup"><span data-stu-id="1f2a9-141">Asychronously return a Windows Runtime type</span></span>

<span data-ttu-id="1f2a9-142">次の例では、特定の URI で呼び出しを **RetrieveFeedAsync** にラップして、[**SyndicationFeed**](/uwp/api/windows.web.syndication.syndicationfeed) を非同期的に返す **RetrieveBlogFeedAsync** 関数を示します。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-142">In this next example we wrap a call to **RetrieveFeedAsync**, for a specific URI, to give us a **RetrieveBlogFeedAsync** function that asynchronously returns a [**SyndicationFeed**](/uwp/api/windows.web.syndication.syndicationfeed).</span></span>

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

<span data-ttu-id="1f2a9-143">次の例では、**RetrieveBlogFeedAsync** は進捗状況と戻り値の両方が含まれる **IAsyncOperationWithProgress** を返します。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-143">In the example above, **RetrieveBlogFeedAsync** returns an **IAsyncOperationWithProgress**, which has both progress and a return value.</span></span> <span data-ttu-id="1f2a9-144">**RetrieveBlogFeedAsync** が自分の処理を行い、フィードを取得している間は、他の作業を行うことができます。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-144">We can do other work while **RetrieveBlogFeedAsync** is doing its thing and retrieving the feed.</span></span> <span data-ttu-id="1f2a9-145">次に、非同期操作オブジェクトで **get** を呼び出し、ブロックするか完了まで待機して、操作結果を取得します。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-145">Then, we call **get** on that asynchronous operation object to block, wait for it to complete, and then obtain the results of the operation.</span></span>

<span data-ttu-id="1f2a9-146">Windows ランタイム型を非同期的に返す場合は、[**IAsyncOperation&lt;TResult&gt;**](/uwp/api/windows.foundation.iasyncoperation_tresult_) または [**IAsyncOperationWithProgress&lt;TResult, TProgress&gt;**](/uwp/api/windows.foundation.iasyncoperationwithprogress_tresult_tprogress_) を返す必要があります。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-146">If you're asynchronously returning a Windows Runtime type, then you should return an [**IAsyncOperation&lt;TResult&gt;**](/uwp/api/windows.foundation.iasyncoperation_tresult_) or an [**IAsyncOperationWithProgress&lt;TResult, TProgress&gt;**](/uwp/api/windows.foundation.iasyncoperationwithprogress_tresult_tprogress_).</span></span> <span data-ttu-id="1f2a9-147">ファースト パーティ製またはサード パーティ製のランタイム クラス、または Windows ランタイム関数との間で受け渡しできる任意の型 (例、`int` または **winrt::hstring**) がこれに適合します。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-147">Any first- or third-party runtime class qualifies, or any type that can be passed to or from a Windows Runtime function (for example, `int`, or **winrt::hstring**).</span></span> <span data-ttu-id="1f2a9-148">コンパイラは、Windows ランタイム型以外でこれらの非同期操作型のいずれかを使用しようとすると表示される "*WinRT 型である必要があります*" というエラーをサポートします。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-148">The compiler will help you with a "*must be WinRT type*" error if you try to use one of these asychronous operation types with a non-Windows Runtime type.</span></span>

<span data-ttu-id="1f2a9-149">コルーチンに 1 つ以上の `co_await` ステートメントがない場合、コルーチンであると認められるために、1 つ以上の `co_return` または 1 つの `co_yield` ステートメントが必要です。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-149">If a coroutine doesn't have at least one `co_await` statement then, in order to qualify as a coroutine, it must have at least one `co_return` or one `co_yield` statement.</span></span> <span data-ttu-id="1f2a9-150">非同期操作を必要とせず、そのためにコンテキストのブロックや切り替えを行わずに、コルーチンが値を返すことができる場合があります。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-150">There will be cases where your coroutine can return a value without introducing any asynchrony, and therefore without blocking nor switching context.</span></span> <span data-ttu-id="1f2a9-151">値をキャッシュすることでそれを行う例を次に示します (2 回目以降は呼び出されます)。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-151">Here's an example that does that (the second and subsequent times it's called) by caching a value.</span></span>

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

## <a name="asychronously-return-a-non-windows-runtime-type"></a><span data-ttu-id="1f2a9-152">Windows ランタイム型以外を非同期的に返す</span><span class="sxs-lookup"><span data-stu-id="1f2a9-152">Asychronously return a non-Windows-Runtime type</span></span>

<span data-ttu-id="1f2a9-153">Windows ランタイム型*以外*の型を非同期的に返す場合は、並列パターン ライブラリ (PPL) [**concurrency::task**](/cpp/parallel/concrt/reference/task-class) を返す必要があります。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-153">If you're asynchronously returning a type that's *not* a Windows Runtime type, then you should return a Parallel Patterns Library (PPL) [**concurrency::task**](/cpp/parallel/concrt/reference/task-class).</span></span> <span data-ttu-id="1f2a9-154">**std::future**よりもパフォーマンスに優れているため (また、今後の互換性の向上により)、**concurrency::task** をお勧めします。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-154">We recommend **concurrency::task** because it gives you better performance (and better compatibility going forward) than **std::future** does.</span></span>

> [!TIP]
> <span data-ttu-id="1f2a9-155">`<pplawait.h>` を含めると、コルーチンの型として **concurrency::task** を使用できます。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-155">If you include `<pplawait.h>`, then you can use **concurrency::task** as a coroutine type.</span></span>

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

## <a name="parameter-passing"></a><span data-ttu-id="1f2a9-156">パラメーターの引き渡し</span><span class="sxs-lookup"><span data-stu-id="1f2a9-156">Parameter-passing</span></span>

<span data-ttu-id="1f2a9-157">同期関数では、既定で `const&` パラメーターを使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-157">For synchronous functions, you should use `const&` parameters by default.</span></span> <span data-ttu-id="1f2a9-158">これにより、コピーのオーバーヘッドが回避されます (参照カウント、つまりインタロックされたインクリメントとデクリメントが含まれます)。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-158">That will avoid the overhead of copies (which involve reference counting, and that means interlocked increments and decrements).</span></span>

```cppwinrt
// Synchronous function.
void DoWork(Param const& value);
```

<span data-ttu-id="1f2a9-159">ただし、コルーチンに参照パラメーターを渡した場合、問題が発生する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-159">But you can run into problems if you pass a reference parameter to a coroutine.</span></span>

```cppwinrt
// NOT the recommended way to pass a value to a coroutine!
IASyncAction DoWorkAsync(Param const& value)
{
    // While it's ok to access value here...
    
    co_await DoOtherWorkAsync();

    // ...accessing value here carries no guarantees of safety.
}
```

<span data-ttu-id="1f2a9-160">コルーチンでは、最初の一時停止ポイントまで実行は同期であり、ここでは、コントロールは呼び出し元に返されます。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-160">In a coroutine, execution is synchronous up until the first suspension point, where control is returned to the caller.</span></span> <span data-ttu-id="1f2a9-161">コルーチンが再開するまで、参照パラメーターが参照するソース値に何かが発生している可能性があります。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-161">By the time the coroutine resumes, anything might have happened to the source value that a reference parameter references.</span></span> <span data-ttu-id="1f2a9-162">コルーチンの観点からは、参照パラメーターには管理されていない有効期間があります。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-162">From the coroutine's perspective, a reference parameter has uncontrolled lifetime.</span></span> <span data-ttu-id="1f2a9-163">そのため、上記の例では、`co_await` まで*値*に安全にアクセスできますが、それ以降は安全ではありません。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-163">So, in the example above, we're safe to access *value* up until the `co_await`, but not after it.</span></span> <span data-ttu-id="1f2a9-164">また、その後その関数が中断し、再開した後で*値*を使用しようとするリスクがある場合、**DoOtherWorkAsync** に安全に*値*を渡すこともできません。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-164">Nor can we safely pass *value* to **DoOtherWorkAsync** if there's any risk that that function will in turn suspend and then try to use *value* after it resumes.</span></span> <span data-ttu-id="1f2a9-165">中断して再開した後で、パラメーターを安全に使用できるようにするには、コルーチンは既定で値渡しを使用し、値でキャプチャして有効期間の問題を回避できるようにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-165">To make parameters safe to use after suspending and resuming, your coroutines should use pass-by-value by default to ensure that they capture by value and avoid lifetime issues.</span></span> <span data-ttu-id="1f2a9-166">それを行うことが安全であると確信できるためにそのガイダンスから逸脱できる場合は稀です。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-166">Cases when you can deviate from that guidance because you're certain that it's safe to do so are going to be rare.</span></span>

```cppwinrt
// Coroutine
IASyncAction DoWorkAsync(Param value);
```

<span data-ttu-id="1f2a9-167">(値を移動しない限り) 定数値を渡すことが良い方法であるということにも議論の余地があります。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-167">It's also arguable that (unless you want to move the value) passing by const value is good practice.</span></span> <span data-ttu-id="1f2a9-168">コピー元のソース値に影響はありませんが、意図が明確になり、誤ってコピーを変更した場合に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-168">It won't have any effect on the source value from which you're making a copy, but it makes the intent clear, and helps if you inadvertently modify the copy.</span></span>
    
```cppwinrt
// coroutine with strictly unnecessary const (but arguably good practice).
IASyncAction DoWorkAsync(Param const value);
```

<span data-ttu-id="1f2a9-169">非同期の呼び出し先に標準ベクターを渡す方法について説明した「[標準的な配列とベクトル](std-cpp-data-types.md#standard-arrays-and-vectors)」も参照してください。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-169">Also see [Standard arrays and vectors](std-cpp-data-types.md#standard-arrays-and-vectors), which deals with how to pass a standard vector into an asynchronous callee.</span></span>

## <a name="offloading-work-onto-the-windows-thread-pool"></a><span data-ttu-id="1f2a9-170">Windows スレッド プールへの処理のオフロード</span><span class="sxs-lookup"><span data-stu-id="1f2a9-170">Offloading work onto the Windows thread pool</span></span>

<span data-ttu-id="1f2a9-171">コルーチンは、その関数は、それに実行を返すまでに、呼び出し元がブロックされているなどの他の機能です。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-171">A coroutine is a function like any other in that a caller is blocked until a function returns execution to it.</span></span> <span data-ttu-id="1f2a9-172">そしてを返すコルーチンの最初の機会が最初の`co_await`、 `co_return`、または`co_yield`します。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-172">And, the first opportunity for a coroutine to return is the first `co_await`, `co_return`, or `co_yield`.</span></span>

<span data-ttu-id="1f2a9-173">そのため、その前に、コルーチンで計算にバインドされている作業、呼び出し元に実行を返す必要があります (つまり、一時停止ポイントを導入します)、呼び出し元がブロックされないようにします。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-173">So, before you do compute-bound work in a coroutine, you need to return execution to the caller (in other words, introduce a suspension point) so that the caller isn't blocked.</span></span> <span data-ttu-id="1f2a9-174">まだ行っていないを場合`co_await`にその他の操作を取り`co_await` [**winrt::resume_background**](/uwp/cpp-ref-for-winrt/resume-background)関数です。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-174">If you're not already doing that by `co_await`-ing some other operation, then you can `co_await` the [**winrt::resume_background**](/uwp/cpp-ref-for-winrt/resume-background) function.</span></span> <span data-ttu-id="1f2a9-175">これにより、呼び出し元に制御が返され、スレッド プールのスレッドですぐに実行が再開されます。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-175">That returns control to the caller, and then immediately resumes execution on a thread pool thread.</span></span>

<span data-ttu-id="1f2a9-176">実装で使用されているスレッド プールは低レベルの [Windows スレッド プール](https://msdn.microsoft.com/library/windows/desktop/ms686766)であるため、最適に効率化されます。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-176">The thread pool being used in the implementation is the low-level [Windows thread pool](https://msdn.microsoft.com/library/windows/desktop/ms686766), so it's optimially efficient.</span></span>

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

## <a name="programming-with-thread-affinity-in-mind"></a><span data-ttu-id="1f2a9-177">スレッドの関係を考慮したプログラミング</span><span class="sxs-lookup"><span data-stu-id="1f2a9-177">Programming with thread affinity in mind</span></span>

<span data-ttu-id="1f2a9-178">このシナリオは、前のシナリオをさらに詳しく説明しています。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-178">This scenario expands on the previous one.</span></span> <span data-ttu-id="1f2a9-179">一部の処理をスレッド プールにオフロードするが、ユーザー インターフェイス (UI) で進行状況を表示したいとします。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-179">You offload some work onto the thread pool, but then you want to display progress in the user interface (UI).</span></span>

```cppwinrt
IAsyncAction DoWorkAsync(TextBlock const& textblock)
{
    co_await winrt::resume_background();
    // Do compute-bound work here.

    textblock.Text(L"Done!"); // Error: TextBlock has thread affinity.
}
```

<span data-ttu-id="1f2a9-180">上のコードは、[**winrt::hresult_wrong_thread**](/uwp/cpp-ref-for-winrt/hresult-wrong-thread) 例外をスローします。これは、**TextBlock** がそれを作成したスレッド (UI スレッド) から更新する必要があるためです。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-180">The code above throws a [**winrt::hresult_wrong_thread**](/uwp/cpp-ref-for-winrt/hresult-wrong-thread) exception, because a **TextBlock** must be updated from the thread that created it, which is the UI thread.</span></span> <span data-ttu-id="1f2a9-181">1 つの解決方法は、コルーチンが最初に呼び出されたスレッド コンテキストをキャプチャする方法です。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-181">One solution is to capture the thread context within which our coroutine was originally called.</span></span> <span data-ttu-id="1f2a9-182">そのためには[**winrt::apartment_context**](/uwp/cpp-ref-for-winrt/apartment-context)オブジェクトをインスタンス化、バック グラウンドの作業を実行し、`co_await`呼び出し元コンテキストに戻るに**apartment_context**します。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-182">To do that, instantiate a [**winrt::apartment_context**](/uwp/cpp-ref-for-winrt/apartment-context) object, do background work, and then `co_await` the **apartment_context** to switch back to the calling context.</span></span>

```cppwinrt
IAsyncAction DoWorkAsync(TextBlock const& textblock)
{
    winrt::apartment_context ui_thread; // Capture calling context.

    co_await winrt::resume_background();
    // Do compute-bound work here.

    co_await ui_thread; // Switch back to calling context.

    textblock.Text(L"Done!"); // Ok if we really were called from the UI thread.
}
```

<span data-ttu-id="1f2a9-183">上のコルーチンが **TextBlock** を作成した UI スレッドから呼び出される限り、この手法は機能します。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-183">As long as the coroutine above is called from the UI thread that created the **TextBlock**, then this technique works.</span></span> <span data-ttu-id="1f2a9-184">アプリで多くの場合にそれを確信できます。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-184">There will be many cases in your app where you're certain of that.</span></span>

<span data-ttu-id="1f2a9-185">できます、場所、わからない呼び出しスレッドの場合、UI の更新に対するより一般的なソリューションの`co_await`特定のフォア グラウンド スレッドに切り替える[**winrt::resume_foreground**](/uwp/cpp-ref-for-winrt/resume-foreground)関数です。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-185">For a more general solution to updating UI, which covers cases where you're uncertain about the calling thread, you can `co_await` the [**winrt::resume_foreground**](/uwp/cpp-ref-for-winrt/resume-foreground) function to switch to a specific foreground thread.</span></span> <span data-ttu-id="1f2a9-186">次のコード例では、([**Dispatcher**](/uwp/api/windows.ui.xaml.dependencyobject.dispatcher#Windows_UI_Xaml_DependencyObject_Dispatcher) プロパティにアクセスして) **TextBlock** に関連するディスパッチャー オブジェクトを渡すことでフォアグラウンド スレッドを指定しています。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-186">In the code example below, we specify the foreground thread by passing the dispatcher object associated with the **TextBlock** (by accessing its [**Dispatcher**](/uwp/api/windows.ui.xaml.dependencyobject.dispatcher#Windows_UI_Xaml_DependencyObject_Dispatcher) property).</span></span> <span data-ttu-id="1f2a9-187">**winrt::resume_foreground** の実装では、そのディスパッチャー オブジェクトで [**CoreDispatcher.RunAsync**](/uwp/api/windows.ui.core.coredispatcher.runasync) を呼び出し、コルーチンでその後に続く処理を実行しています。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-187">The implementation of **winrt::resume_foreground** calls [**CoreDispatcher.RunAsync**](/uwp/api/windows.ui.core.coredispatcher.runasync) on that dispatcher object to execute the work that comes after it in the coroutine.</span></span>

```cppwinrt
#include <winrt/Windows.UI.Core.h> // necessary in order to use winrt::resume_foreground.
IAsyncAction DoWorkAsync(TextBlock const& textblock)
{
    co_await winrt::resume_background();
    // Do compute-bound work here.

    co_await winrt::resume_foreground(textblock.Dispatcher()); // Switch to the foreground thread associated with textblock.

    textblock.Text(L"Done!"); // Guaranteed to work.
}
```

## <a name="execution-contexts-resuming-and-switching-in-a-coroutine"></a><span data-ttu-id="1f2a9-188">実行コンテキスト、再開、およびコルーチンの切り替え</span><span class="sxs-lookup"><span data-stu-id="1f2a9-188">Execution contexts, resuming, and switching in a coroutine</span></span>

<span data-ttu-id="1f2a9-189">大まかに言うと、コルーチンで一時停止ポイント後、元のスレッドの実行の可能性があります離れた移動し、再開が任意のスレッドで発生する可能性があります (つまり、任意のスレッドが、メソッドを呼び出して**Completed**非同期操作の)。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-189">Broadly speaking, after a suspension point in a coroutine, the original thread of execution may go away and resumption may occur on any thread (in other words, any thread may call the **Completed** method for the async operation).</span></span>

<span data-ttu-id="1f2a9-190">場合する`co_await`、4 つの Windows ランタイム非同期操作型 (**IAsyncXxx**) し、C++ のいずれかの/WinRT 時点では、呼び出し元のコンテキストをキャプチャする`co_await`します。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-190">But if you `co_await` any of the four Windows Runtime asynchronous operation types (**IAsyncXxx**), then C++/WinRT captures the calling context at the point you `co_await`.</span></span> <span data-ttu-id="1f2a9-191">や、継続の再開時そのコンテキストに残っていることになります。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-191">And it ensures that you're still on that context when the continuation resumes.</span></span> <span data-ttu-id="1f2a9-192">C++/WinRT は呼び出し元のコンテキストでされているかどうかを確認し、そうでない場合は、それに切り替えます。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-192">C++/WinRT does this by checking whether you're already on the calling context and, if not, switching to it.</span></span> <span data-ttu-id="1f2a9-193">したかどうかは、前にシングル スレッド アパートメント (STA) スレッドで`co_await`、その後でものと同じ上にありますしたかどうかは、前にマルチ スレッド アパートメント (MTA) スレッドで`co_await`、その後でいずれかでにあります。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-193">If you were on a single-threaded apartment (STA) thread before `co_await`, then you'll be on the same one afterward; if you were on a multi-threaded apartment (MTA) thread before `co_await`, then you'll be on one afterward.</span></span>

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

<span data-ttu-id="1f2a9-194">この動作に依存することは、ため、C++/WinRT が (コードのこれらのコンポーネントと呼ばれる待機アダプター) C++ コルーチン言語サポートをそれらの Windows ランタイム非同期操作型の対応するコードを提供します。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-194">The reason you can rely on this behavior is because C++/WinRT provides code to adapt those Windows Runtime asynchronous operation types to the C++ coroutine language support (these pieces of code are called wait adapters).</span></span> <span data-ttu-id="1f2a9-195">残りの待機型 c++/WinRT はスレッド プールのラッパーやヘルパーです。スレッド プールに完了したためです。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-195">The remaining awaitable types in C++/WinRT are simply thread pool wrappers and/or helpers; so they complete on the thread pool.</span></span>

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

<span data-ttu-id="1f2a9-196">場合する`co_await`他の種類&mdash;内であっても、C++/cli/winrt コルーチンの実装&mdash;別のライブラリのアダプターを提供し、再開、およびコンテキストの観点からこれらのアダプターは何を理解する必要があります。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-196">If you `co_await` some other type&mdash;even within a C++/WinRT coroutine implementation&mdash;then another library provides the adapters, and you'll need to understand what those adapters do in terms of resumption and contexts.</span></span>

<span data-ttu-id="1f2a9-197">最小下コンテキストの切り替えを維持するには、このトピックで説明した既に手法の一部を使用できます。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-197">To keep context switches down to a minimum, you can use some of the techniques that we've already seen in this topic.</span></span> <span data-ttu-id="1f2a9-198">これを行うのいくつかの図を見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-198">Let's see some illustrations of doing that.</span></span> <span data-ttu-id="1f2a9-199">この次の擬似コード例では、イメージを読み込むための Windows ランタイム API を呼び出す、そのイメージを処理するバック グラウンド スレッドにドロップし、UI の画像を表示する UI スレッドに返すイベント ハンドラーの概要について説明します。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-199">In this next pseudo-code example, we show the outline of an event handler that calls a Windows Runtime API to load an image, drops onto a background thread to process that image, and then returns to the UI thread to display the image in the UI.</span></span>

```cppwinrt
#include <winrt/Windows.UI.Core.h> // necessary in order to use winrt::resume_foreground.
IAsyncAction MainPage::ClickHandler(IInspectable const& /* sender */, RoutedEventArgs const& /* args */)
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

<span data-ttu-id="1f2a9-200">このようなシナリオは、少しの呼び出しを**StorageFile::OpenAsync**ineffiency です。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-200">For this scenario, there's a little bit of ineffiency around the call to **StorageFile::OpenAsync**.</span></span> <span data-ttu-id="1f2a9-201">背景に必要なコンテキスト スイッチがあるスレッド (ハンドラーは、呼び出し元に実行を返すことができます) するためのどの C + 後の再開時/WinRT は UI スレッド コンテキストを復元します。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-201">There's a necessary context switch to a background thread (so that the handler can return execution to the caller), on resumption after which C++/WinRT restores the UI thread context.</span></span> <span data-ttu-id="1f2a9-202">ただし、この例では、UI を更新しようとするまでに、UI スレッド上にする必要はありません。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-202">But, in this case, it's not neccessary to be on the UI thread until we're about to update the UI.</span></span> <span data-ttu-id="1f2a9-203">詳細 Windows ランタイム Api 呼び出し*の前に* **winrt::resume_background**、当社の呼び出しは不要な - 前後のコンテキスト スイッチが発生します。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-203">The more Windows Runtime APIs we call *before* our call to **winrt::resume_background**, the more unnecessary back-and-forth context switches we incur.</span></span> <span data-ttu-id="1f2a9-204">ソリューションとしていないを呼び出して *、* Windows ランタイム Api する前に。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-204">The solution is not to call *any* Windows Runtime APIs before then.</span></span> <span data-ttu-id="1f2a9-205">**Winrt::resume_background**後に、それらを移動します。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-205">Move them all after the **winrt::resume_background**.</span></span>

```cppwinrt
#include <winrt/Windows.UI.Core.h> // necessary in order to use winrt::resume_foreground.
IAsyncAction MainPage::ClickHandler(IInspectable const& /* sender */, RoutedEventArgs const& /* args */)
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

<span data-ttu-id="1f2a9-206">独自に記述することもできますしより高度な何かを実行する場合は、アダプターを待機します。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-206">If you want to do something more advanced, then you could write your own await adapters.</span></span> <span data-ttu-id="1f2a9-207">例では、する場合は、`co_await`で非同期操作が完了するのと同じスレッドで再開する (そのためがないコンテキストの切り替え) を記述して開始することができますし、await アダプターを次に示すものに似ています。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-207">For example, if you want a `co_await` to resume on the same thread that the async action completes on (so, there's no context switch), then you could begin by writing await adapters similar to the ones shown below.</span></span>

> [!NOTE]
> <span data-ttu-id="1f2a9-208">次のコード例では、教育だけを目的が提供されます。作業を開始するのには理解がアダプター作業をどのように await します。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-208">The code example below is provided for educational purposes only; it's to get you started understanding how await adapters work.</span></span> <span data-ttu-id="1f2a9-209">開発や、独自のテストを行うことをお勧めしますこの手法は、独自のコードベースを使用する場合は await アダプター struct(s) です。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-209">If you want to use this technique in your own codebase, then we recommend that you develop and test your own await adapter struct(s).</span></span> <span data-ttu-id="1f2a9-210">たとえば、 **complete_on_any**、 **complete_on_current**、および**complete_on(dispatcher)** を記述することができます。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-210">For example, you could write **complete_on_any**, **complete_on_current**, and **complete_on(dispatcher)**.</span></span> <span data-ttu-id="1f2a9-211">また、テンプレートをテンプレート パラメーターとして、 **IAsyncXxx**の種類を取得する際に検討してください。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-211">Also consider making them templates that take the **IAsyncXxx** type as a template parameter.</span></span>

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

<span data-ttu-id="1f2a9-212">**切り替え**を使用する方法を理解する await アダプター、まず、C++ コンパイラで発生したときにことを把握する必要があります、 `co_await` **await_ready**、 **await_suspend**、および**await_resume**機能の数式が呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-212">To understand how to use the **no_switch** await adapters, you'll first need to know that when the C++ compiler encounters a `co_await` expression it looks for functions called **await_ready**, **await_suspend**, and **await_resume**.</span></span> <span data-ttu-id="1f2a9-213">C++/WinRT ライブラリは、既定では、次のように適切な動作を取得するためにこれらの機能を提供します。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-213">The C++/WinRT library provides those functions so that you get reasonable behavior by default, like this.</span></span>

```cppwinrt
IAsyncAction async{ ProcessFeedAsync() };
co_await async;
```

<span data-ttu-id="1f2a9-214">使用する**切り替え**await アダプター、変更されるの種類`co_await`式**IAsyncXxx**の**切り替えなし**、次のようにします。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-214">To use the **no_switch** await adapters, just change the type of that `co_await` expression from **IAsyncXxx** to **no_switch**, like this.</span></span>

```cppwinrt
IAsyncAction async{ ProcessFeedAsync() };
co_await static_cast<no_switch>(async);
```

<span data-ttu-id="1f2a9-215">次に、 **IAsyncXxx**に一致する 3 つの**await_xxx**関数を探してではなく、C++ コンパイラを探します**切り替えなし**に一致する機能。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-215">Then, instead of looking for the three **await_xxx** functions that match **IAsyncXxx**, the C++ compiler looks for functions that match **no_switch**.</span></span>

## <a name="canceling-an-asychronous-operation-and-cancellation-callbacks"></a><span data-ttu-id="1f2a9-216">非同期操作と取り消しコールバックをキャンセルします。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-216">Canceling an asychronous operation, and cancellation callbacks</span></span>

<span data-ttu-id="1f2a9-217">非同期プログラミング用の Windows ランタイムの機能を使用中の非同期アクションまたは操作をキャンセルすることができます。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-217">The Windows Runtime's features for asynchronous programming allow you to cancel an in-flight asynchronous action or operation.</span></span> <span data-ttu-id="1f2a9-218">呼び出す[**StorageFolder::GetFilesAsync**](/uwp/api/windows.storage.storagefolder.getfilesasync)大きい可能性がある、ファイルのコレクションを取得する例を次に示し、データ メンバーに結果として得られる非同期操作オブジェクトを格納します。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-218">Here's an example that calls [**StorageFolder::GetFilesAsync**](/uwp/api/windows.storage.storagefolder.getfilesasync) to retrieve a potentially large collection of files, and it stores the resulting asynchronous operation object in a data member.</span></span> <span data-ttu-id="1f2a9-219">ユーザーには、操作をキャンセルするオプションがあります。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-219">The user has the option to cancel the operation.</span></span>

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

    IAsyncAction OnWork(IInspectable const& /* sender */, RoutedEventArgs const& /* args */)
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

<span data-ttu-id="1f2a9-220">取り消しの実装側での単純な例から始めましょう。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-220">For the implementation side of cancellation, let's begin with a simple example.</span></span>

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

<span data-ttu-id="1f2a9-221">**ImplicitCancellationAsync**印刷 1 つのメッセージを 3 秒間、その後、1 秒あたりに自動的に時間が表示されますし、上記の例を実行する場合は、キャンセルされる結果として終了します。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-221">If you run the example above, then you'll see **ImplicitCancellationAsync** print one message per second for three seconds, after which time it automatically terminates as a result of being canceled.</span></span> <span data-ttu-id="1f2a9-222">発生しているため、この作業は、`co_await`式、コルーチンのチェックがキャンセルされたかどうか。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-222">This works because, on encountering a `co_await` expression, a coroutine checks whether it has been cancelled.</span></span> <span data-ttu-id="1f2a9-223">場合は、その後、short-circuits アウトしてください。されていない場合を中断し、通常どおりします。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-223">If it has, then it short-circuits out; and if it hasn't, then it suspends as normal.</span></span>

<span data-ttu-id="1f2a9-224">取り消し、もちろん、起こりますコルーチンが中断されているとき。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-224">Cancellation can, of course, happen while the coroutine is suspended.</span></span> <span data-ttu-id="1f2a9-225">コルーチンの再開時にのみ別に達したまたは`co_await`、取り消しに対してが確認されます。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-225">Only when the coroutine resumes, or hits another `co_await`, will it check for cancellation.</span></span> <span data-ttu-id="1f2a9-226">問題がある取り消しに対応する場合の待機時間の可能性のあるすぎる粗い-細かいのいずれか。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-226">The issue is one of potentially too-coarse-grained latency in responding to cancellation.</span></span>

<span data-ttu-id="1f2a9-227">そのため、明示的にポーリングするには、コルーチン内からの取り消しに対してすることが別のオプションです。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-227">So, another option is to explicitly poll for cancellation from within your coroutine.</span></span> <span data-ttu-id="1f2a9-228">以下のリスト内のコードでは、上記の例を更新します。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-228">Update the example above with the code in the listing below.</span></span> <span data-ttu-id="1f2a9-229">この新しい例では**ExplicitCancellationAsync** 、 [**winrt::get_cancellation_token**](/uwp/cpp-ref-for-winrt/get-cancellation-token)関数によって返されるオブジェクトを取得を定期的にコルーチンが取り消されたかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-229">In this new example, **ExplicitCancellationAsync** retrieves the object returned by the [**winrt::get_cancellation_token**](/uwp/cpp-ref-for-winrt/get-cancellation-token) function, and uses it to periodically check whether the coroutine has been canceled.</span></span> <span data-ttu-id="1f2a9-230">コルーチンが無限に; ループがキャンセルされない限り取り消された後、ループと関数正常終了します。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-230">As long as it's not canceled, the coroutine loops indefinitely; once it is canceled, the loop and the function exit normally.</span></span> <span data-ttu-id="1f2a9-231">結果は、前の例が、ここで終了するが、明示的に行われるため、および管理下に、同じです。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-231">The outcome is the same as the previous example, but here exiting happens explicitly, and under control.</span></span>

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

<span data-ttu-id="1f2a9-232">**Winrt::get_cancellation_token**を待機している、お客様に代わって、コルーチンが生成**IAsyncAction**の知識を持つキャンセル トークンを取得します。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-232">Waiting on **winrt::get_cancellation_token** retrieves a cancellation token with knowledge of the **IAsyncAction** that the coroutine is producing on your behalf.</span></span> <span data-ttu-id="1f2a9-233">そのトークンを関数呼び出し演算子を使用するには取り消し状態を照会&mdash;取り消しに対して本質的にポーリングします。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-233">You can use the function call operator on that token to query the cancellation state&mdash;essentially polling for cancellation.</span></span> <span data-ttu-id="1f2a9-234">場合は、いくつかの計算にバインドされている操作を実行しているか、大規模なコレクションの反復処理している、し、これは、適切な手法です。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-234">If you're performing some compute-bound operation, or iterating through a large collection, then this is a reasonable technique.</span></span>

### <a name="register-a-cancellation-callback"></a><span data-ttu-id="1f2a9-235">取り消しコールバックを登録します。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-235">Register a cancellation callback</span></span>

<span data-ttu-id="1f2a9-236">Windows ランタイムのキャンセルは他の非同期オブジェクトに自動的に流し込まれます。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-236">The Windows Runtime's cancellation doesn't automatically flow to other asynchronous objects.</span></span> <span data-ttu-id="1f2a9-237">ただし&mdash;Windows SDK のバージョン 10.0.17763.0 (Windows 10、バージョン 1809) で導入された&mdash;取り消しコールバックを登録することができます。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-237">But&mdash;introduced in version 10.0.17763.0 (Windows 10, version 1809) of the Windows SDK&mdash;you can register a cancellation callback.</span></span> <span data-ttu-id="1f2a9-238">これは、事前フックによって、取り消しは反映できます、既存の同時実行ライブラリとの統合が可能になります。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-238">This is a pre-emptive hook by which cancellation can be propagated, and makes it possible to integrate with existing concurrency libraries.</span></span>

<span data-ttu-id="1f2a9-239">、次のコード例では、 **NestedCoroutineAsync**は、作業がその取り消しの特別なロジックはありません。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-239">In this next code example, **NestedCoroutineAsync** does the work, but it has no special cancellation logic in it.</span></span> <span data-ttu-id="1f2a9-240">**CancellationPropagatorAsync**は基本的には、入れ子になったコルーチンでラッパーです。ラッパーは、先制取り消しを転送します。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-240">**CancellationPropagatorAsync** is essentially a wrapper on the nested coroutine; the wrapper forwards cancellation pre-emptively.</span></span>

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

<span data-ttu-id="1f2a9-241">**CancellationPropagatorAsync**独自取り消しコールバックのラムダ関数を登録して、その後の待機中 (中断) 入れ子になった作業が完了するまでです。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-241">**CancellationPropagatorAsync** registers a lambda function for its own cancellation callback, and then it awaits (it suspends) until the nested work completes.</span></span> <span data-ttu-id="1f2a9-242">とき、または**CancellationPropagatorAsync**が取り消された場合は、入れ子になったコルーチンに取り消しを伝達します。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-242">When or if **CancellationPropagatorAsync** is canceled, it propagates the cancellation to the nested coroutine.</span></span> <span data-ttu-id="1f2a9-243">取り消し; に対してをポーリングする必要はありません。取り消しがブロックされている無期限にします。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-243">There's no need to poll for cancellation; nor is cancellation blocked indefinitely.</span></span> <span data-ttu-id="1f2a9-244">このメカニズムは、C++ の何も認識しているコルーチンまたは同時実行のライブラリとの相互運用機能を使用するために十分な柔軟性/WinRT します。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-244">This mechanism is flexible enough for you to use it to interop with a coroutine or concurrency library that knows nothing of C++/WinRT.</span></span>

## <a name="reporting-progress"></a><span data-ttu-id="1f2a9-245">進行状況の報告</span><span class="sxs-lookup"><span data-stu-id="1f2a9-245">Reporting progress</span></span>

<span data-ttu-id="1f2a9-246">コルーチンでは、または[**IAsyncOperationWithProgress**](/uwp/api/windows.foundation.iasyncoperationwithprogress_tresult_tprogress_)と[**IAsyncActionWithProgress**](/uwp/api/windows.foundation.iasyncactionwithprogress_tprogress_)のいずれかが返された場合ことができます、 [**winrt::get_progress_token**](/uwp/cpp-ref-for-winrt/get-progress-token)関数によって返されるオブジェクトを取得し、使用して、進行状況に進行状況を報告するハンドラーです。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-246">If your coroutine returns either [**IAsyncActionWithProgress**](/uwp/api/windows.foundation.iasyncactionwithprogress_tprogress_), or [**IAsyncOperationWithProgress**](/uwp/api/windows.foundation.iasyncoperationwithprogress_tresult_tprogress_), then you can retrieve the object returned by the [**winrt::get_progress_token**](/uwp/cpp-ref-for-winrt/get-progress-token) function, and use it to report progress back to a progress handler.</span></span> <span data-ttu-id="1f2a9-247">次にコード例を示します。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-247">Here's a code example.</span></span>

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
> <span data-ttu-id="1f2a9-248">正しい非同期アクションまたは操作中には、複数の*完了ハンドラー*を実装することはできません。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-248">It's not correct to implement more than one *completion handler* for an asynchronous action or operation.</span></span> <span data-ttu-id="1f2a9-249">その完了のイベントの 1 つのデリゲートしたりすることができます`co_await`ことです。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-249">You can have either a single delegate for its completed event, or you can `co_await` it.</span></span> <span data-ttu-id="1f2a9-250">両方がある場合は、2 つ目は失敗します。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-250">If you have both, then the second will fail.</span></span> <span data-ttu-id="1f2a9-251">いずれか完了ハンドラーの次の 2 種類のいずれかが適切です。両方の同じ非同期オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-251">Either one of the following two kinds of completion handlers is appropriate; not both for the same async object.</span></span>

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

<span data-ttu-id="1f2a9-252">完了ハンドラーについて詳しくは、[非同期アクションと非同期操作のデリゲート型](handle-events.md#delegate-types-for-asynchronous-actions-and-operations)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-252">For more info about completion handlers, see [Delegate types for asynchronous actions and operations](handle-events.md#delegate-types-for-asynchronous-actions-and-operations).</span></span>

## <a name="fire-and-forget"></a><span data-ttu-id="1f2a9-253">再生後に消去</span><span class="sxs-lookup"><span data-stu-id="1f2a9-253">Fire and forget</span></span>

<span data-ttu-id="1f2a9-254">場合によっては、他の作業と同時に実行できるタスクがあり、そのタスクを完了するを待機する必要はありません (その他の作業依存しない)、必要な値を返すこともできます。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-254">Sometimes, you have a task that can be done concurrently with other work, and you don't need to wait for that task to complete (no other work depends on it), nor do you need it to return a value.</span></span> <span data-ttu-id="1f2a9-255">その場合は、タスクを起動し、忘れたできます。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-255">In that case, you can fire off the task and forget it.</span></span> <span data-ttu-id="1f2a9-256">戻り値の型が (ではなく、Windows ランタイム非同期操作型、または**concurrency::task**のいずれか) [**winrt::fire_and_forget**](/uwp/cpp-ref-for-winrt/fire-and-forget)コルーチンを作成しているを行うことができます。</span><span class="sxs-lookup"><span data-stu-id="1f2a9-256">You can do that by writing a coroutine whose return type is [**winrt::fire_and_forget**](/uwp/cpp-ref-for-winrt/fire-and-forget) (instead of one of the Windows Runtime asynchronous operation types, or **concurrency::task**).</span></span>

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

## <a name="important-apis"></a><span data-ttu-id="1f2a9-257">重要な API</span><span class="sxs-lookup"><span data-stu-id="1f2a9-257">Important APIs</span></span>
* [<span data-ttu-id="1f2a9-258">concurrency::task クラス</span><span class="sxs-lookup"><span data-stu-id="1f2a9-258">concurrency::task class</span></span>](/cpp/parallel/concrt/reference/task-class)
* [<span data-ttu-id="1f2a9-259">IAsyncAction インターフェイス</span><span class="sxs-lookup"><span data-stu-id="1f2a9-259">IAsyncAction interface</span></span>](/uwp/api/windows.foundation.iasyncaction)
* [<span data-ttu-id="1f2a9-260">IAsyncActionWithProgress&lt;TProgress&gt;インターフェイス</span><span class="sxs-lookup"><span data-stu-id="1f2a9-260">IAsyncActionWithProgress&lt;TProgress&gt; interface</span></span>](/uwp/api/windows.foundation.iasyncactionwithprogress_tprogress_)
* [<span data-ttu-id="1f2a9-261">IAsyncOperation&lt;TResult&gt;インターフェイス</span><span class="sxs-lookup"><span data-stu-id="1f2a9-261">IAsyncOperation&lt;TResult&gt; interface</span></span>](/uwp/api/windows.foundation.iasyncoperation_tresult_)
* [<span data-ttu-id="1f2a9-262">IAsyncOperationWithProgress&lt;TResult, TProgress&gt;インターフェイス</span><span class="sxs-lookup"><span data-stu-id="1f2a9-262">IAsyncOperationWithProgress&lt;TResult, TProgress&gt; interface</span></span>](/uwp/api/windows.foundation.iasyncoperationwithprogress_tresult_tprogress_)
* [<span data-ttu-id="1f2a9-263">Syndicationclient::retrievefeedasync メソッド</span><span class="sxs-lookup"><span data-stu-id="1f2a9-263">SyndicationClient::RetrieveFeedAsync method</span></span>](/uwp/api/windows.web.syndication.syndicationclient.retrievefeedasync)
* [<span data-ttu-id="1f2a9-264">SyndicationFeed クラス</span><span class="sxs-lookup"><span data-stu-id="1f2a9-264">SyndicationFeed class</span></span>](/uwp/api/windows.web.syndication.syndicationfeed)
* [<span data-ttu-id="1f2a9-265">winrt::get_cancellation_token</span><span class="sxs-lookup"><span data-stu-id="1f2a9-265">winrt::get_cancellation_token</span></span>](/uwp/cpp-ref-for-winrt/get-cancellation-token)
* [<span data-ttu-id="1f2a9-266">winrt::get_progress_token</span><span class="sxs-lookup"><span data-stu-id="1f2a9-266">winrt::get_progress_token</span></span>](/uwp/cpp-ref-for-winrt/get-progress-token)
* [<span data-ttu-id="1f2a9-267">winrt::fire_and_forget</span><span class="sxs-lookup"><span data-stu-id="1f2a9-267">winrt::fire_and_forget</span></span>](/uwp/cpp-ref-for-winrt/fire-and-forget)

## <a name="related-topics"></a><span data-ttu-id="1f2a9-268">関連トピック</span><span class="sxs-lookup"><span data-stu-id="1f2a9-268">Related topics</span></span>
* [<span data-ttu-id="1f2a9-269">C++/WinRT でのデリゲートを使用したイベントの処理</span><span class="sxs-lookup"><span data-stu-id="1f2a9-269">Handle events by using delegates in C++/WinRT</span></span>](handle-events.md)
* [<span data-ttu-id="1f2a9-270">標準的な C++ のデータ型と C++/WinRT</span><span class="sxs-lookup"><span data-stu-id="1f2a9-270">Standard C++ data types and C++/WinRT</span></span>](std-cpp-data-types.md)