---
author: stevewhims
description: このトピックでは、C++/WinRT を使用した Windows ランタイムの非同期オブジェクトの作成方法と利用方法について説明します。
title: C++/WinRT を使用した同時実行操作と非同期操作
ms.author: stwhi
ms.date: 04/23/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10、uwp、標準、c++、cpp、winrt、プロジェクション、同時実行、非同期、非同期、非同期操作
ms.localizationpriority: medium
ms.openlocfilehash: 3af9125abc3abf41327f5b49e6a05d81e214f89f
ms.sourcegitcommit: ab92c3e0dd294a36e7f65cf82522ec621699db87
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/03/2018
ms.locfileid: "1831836"
---
# <a name="concurrency-and-asynchronous-operations-with-cwinrtwindowsuwpcpp-and-winrt-apisintro-to-using-cpp-with-winrt"></a><span data-ttu-id="f75a3-104">[C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt) を使用した同時実行と非同期操作</span><span class="sxs-lookup"><span data-stu-id="f75a3-104">Concurrency and asynchronous operations with [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)</span></span>
<span data-ttu-id="f75a3-105">このトピックでは、C++/WinRT を使用した Windows ランタイムの非同期オブジェクトの作成方法と利用方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="f75a3-105">This topic shows the ways in which you can both create and consume Windows Runtime asynchronous objects with C++/WinRT.</span></span>

## <a name="asynchronous-operations-and-windows-runtime-async-functions"></a><span data-ttu-id="f75a3-106">非同期操作と Windows ランタイムの "非同期" 関数</span><span class="sxs-lookup"><span data-stu-id="f75a3-106">Asynchronous operations and Windows Runtime "Async" functions</span></span>
<span data-ttu-id="f75a3-107">完了までの時間が 50 ミリ秒を超える可能性がある Windows ランタイム API は、非同期の関数 (末尾が "Async") として実装されます。</span><span class="sxs-lookup"><span data-stu-id="f75a3-107">Any Windows Runtime API that has the potential to take more than 50 milliseconds to complete is implemented as an asynchronous function (with a name ending in "Async").</span></span> <span data-ttu-id="f75a3-108">非同期関数を実装すると、別のスレッドの作業が開始され、非同期操作を表すオブジェクトがすぐに返されます。</span><span class="sxs-lookup"><span data-stu-id="f75a3-108">The implementation of an asynchronous function initiates the work on another thread and returns immediately with an object that represents the asynchronous operation.</span></span> <span data-ttu-id="f75a3-109">非同期操作が完了すると、作業結果が含まれるオブジェクトが返されます。</span><span class="sxs-lookup"><span data-stu-id="f75a3-109">When the asynchronous operation completes, that returned object contains any value that resulted from the work.</span></span> <span data-ttu-id="f75a3-110">**Windows::Foundation** Windows ランタイムの名前空間には次の 4 種類の非同期操作オブジェクトが含まれます。</span><span class="sxs-lookup"><span data-stu-id="f75a3-110">The **Windows::Foundation** Windows Runtime namespace contains four types of asynchronous operation object, and they are</span></span>

- <span data-ttu-id="f75a3-111">[**IAsyncAction**](/uwp/api/windows.foundation.iasyncaction)、</span><span class="sxs-lookup"><span data-stu-id="f75a3-111">[**IAsyncAction**](/uwp/api/windows.foundation.iasyncaction),</span></span>
- <span data-ttu-id="f75a3-112">[**IAsyncActionWithProgress&lt;TProgress&gt;**](/uwp/api/windows.foundation.iasyncactionwithprogress_tprogress_)、</span><span class="sxs-lookup"><span data-stu-id="f75a3-112">[**IAsyncActionWithProgress&lt;TProgress&gt;**](/uwp/api/windows.foundation.iasyncactionwithprogress_tprogress_),</span></span>
- <span data-ttu-id="f75a3-113">[**IAsyncOperation&lt;TResult&gt;**](/uwp/api/windows.foundation.iasyncoperation_tresult_)、</span><span class="sxs-lookup"><span data-stu-id="f75a3-113">[**IAsyncOperation&lt;TResult&gt;**](/uwp/api/windows.foundation.iasyncoperation_tresult_), and</span></span>
- <span data-ttu-id="f75a3-114">[**IAsyncOperationWithProgress&lt;TResult, TProgress&gt;**](/uwp/api/windows.foundation.iasyncoperationwithprogress_tresult_tprogress_)。</span><span class="sxs-lookup"><span data-stu-id="f75a3-114">[**IAsyncOperationWithProgress&lt;TResult, TProgress&gt;**](/uwp/api/windows.foundation.iasyncoperationwithprogress_tresult_tprogress_).</span></span>

<span data-ttu-id="f75a3-115">各非同期操作は、**winrt::Windows::Foundation** C++/WinRT の名前空間で対応する型に投影されます。</span><span class="sxs-lookup"><span data-stu-id="f75a3-115">Each of these asynchronous operation types is projected into a corresponding type in the **winrt::Windows::Foundation** C++/WinRT namespace.</span></span> <span data-ttu-id="f75a3-116">また、C++/WinRT には内部 await アダプター構造体も含まれます。</span><span class="sxs-lookup"><span data-stu-id="f75a3-116">C++/WinRT also contains an internal await adapter struct.</span></span> <span data-ttu-id="f75a3-117">これを直接使用することはありませんが、これにより、これらの非同期操作型のいずれかを返す関数の結果を一緒に待機するように **co_await** ステートメントを作成することができます。</span><span class="sxs-lookup"><span data-stu-id="f75a3-117">You don't use it directly but, thanks to that struct, you can write a **co_await** statement to cooperatively await the result of any function that returns one of these asychronous operation types.</span></span> <span data-ttu-id="f75a3-118">その後、これらの型を返す独自のコルーチンを作成できます。</span><span class="sxs-lookup"><span data-stu-id="f75a3-118">And you can author your own coroutines that return these types.</span></span>

<span data-ttu-id="f75a3-119">たとえば、非同期の Windows 関数である [**SyndicationClient::RetrieveFeedAsync**](https://docs.microsoft.com/uwp/api/windows.web.syndication.syndicationclient.retrievefeedasync) は、[**IAsyncOperationWithProgress&lt;TResult, TProgress&gt;**](/uwp/api/windows.foundation.iasyncoperationwithprogress_tresult_tprogress_) 型の非同期操作オブジェクトを返します。</span><span class="sxs-lookup"><span data-stu-id="f75a3-119">An example of an asynchronous Windows function is [**SyndicationClient::RetrieveFeedAsync**](https://docs.microsoft.com/uwp/api/windows.web.syndication.syndicationclient.retrievefeedasync), which returns an asynchronous operation object of type [**IAsyncOperationWithProgress&lt;TResult, TProgress&gt;**](/uwp/api/windows.foundation.iasyncoperationwithprogress_tresult_tprogress_).</span></span> <span data-ttu-id="f75a3-120">それでは、C++/WinRT を使用してそのような API を呼び出すためのいくつかの方法 (ブロックと非ブロック) を示します。</span><span class="sxs-lookup"><span data-stu-id="f75a3-120">Let's look at some ways&mdash;blocking and non-blocking&mdash;of using C++/WinRT to call an API such as that.</span></span>

## <a name="block-the-calling-thread"></a><span data-ttu-id="f75a3-121">呼び出しスレッドのブロック</span><span class="sxs-lookup"><span data-stu-id="f75a3-121">Block the calling thread</span></span>
<span data-ttu-id="f75a3-122">次のコード例では、**RetrieveFeedAsync** から非同期操作オブジェクトを受け取り、非同期操作の結果が利用可能になるまで呼び出しスレッドをブロックするようにこのオブジェクトで **get** を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="f75a3-122">The code example below receives an asynchronous operation object from **RetrieveFeedAsync**, and it calls **get** on that object to block the calling thread until the results of the asynchronous operation are available.</span></span>

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

<span data-ttu-id="f75a3-123">**get** を呼び出すとコーディングが簡単になりますが、組み合わせて呼び出すことはできません。</span><span class="sxs-lookup"><span data-stu-id="f75a3-123">Calling **get** makes for convenient coding, but it's not what you'd call cooperative.</span></span> <span data-ttu-id="f75a3-124">同時実行または非同期でもありません。</span><span class="sxs-lookup"><span data-stu-id="f75a3-124">It's not concurrent nor asynchronous.</span></span> <span data-ttu-id="f75a3-125">OS スレッドの他の有用な作業を妨げないように、さまざまな方法が必要です。</span><span class="sxs-lookup"><span data-stu-id="f75a3-125">To avoid holding up OS threads from doing other useful work, we need a different technique.</span></span>

## <a name="write-a-coroutine"></a><span data-ttu-id="f75a3-126">コルーチンの作成</span><span class="sxs-lookup"><span data-stu-id="f75a3-126">Write a coroutine</span></span>
<span data-ttu-id="f75a3-127">C++/WinRT は C++ コルーチンをプログラミング モデルに統合し、結果を連携して待機するための自然な方法を提供します。</span><span class="sxs-lookup"><span data-stu-id="f75a3-127">C++/WinRT integrates C++ coroutines into the programming model to provide a natural way to cooperatively wait for a result.</span></span> <span data-ttu-id="f75a3-128">コルーチンを作成すると、独自の Windows ランタイム非同期操作を作成することができます。</span><span class="sxs-lookup"><span data-stu-id="f75a3-128">You can produce your own Windows Runtime asynchronous operation by writing a coroutine.</span></span> <span data-ttu-id="f75a3-129">次のコード例で、**ProcessFeedAsync** はコルーチンします。</span><span class="sxs-lookup"><span data-stu-id="f75a3-129">In the code example below, **ProcessFeedAsync** is the coroutine.</span></span>

```cppwinrt
// main.cpp

#include "pch.h"
#include <winrt/Windows.Foundation.h>
#include <winrt/Windows.Web.Syndication.h>
#include <iostream>

using namespace winrt;
using namespace Windows::Foundation;
using namespace Windows::Web::Syndication;

void PrintFeed(SyndicationFeed syndicationFeed)
{
    for (SyndicationItem syndicationItem : syndicationFeed.Items())
    {
        std::wcout << syndicationItem.Title().Text().c_str() << std::endl;
    }
}

IAsyncAction ProcessFeedAsync()
{
    Uri rssFeedUri{ L"https://blogs.windows.com/feed" };
    SyndicationClient syndicationClient;
    SyndicationFeed syndicationFeed = co_await syndicationClient.RetrieveFeedAsync(rssFeedUri);
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

<span data-ttu-id="f75a3-130">コルーチンは中断して再開できる関数です。</span><span class="sxs-lookup"><span data-stu-id="f75a3-130">A coroutine is a function that can be suspended and resumed.</span></span> <span data-ttu-id="f75a3-131">上記の **ProcessFeedAsync** コルーチンでは、**co_await** ステートメントに到達すると、コルーチンは **RetrieveFeedAsync** 呼び出しを非同期的に起動してからすぐに自身を中断し、呼び出し元 (上記の例の **main**) に戻ります。</span><span class="sxs-lookup"><span data-stu-id="f75a3-131">In the **ProcessFeedAsync** coroutine above, when the **co_await** statement is reached, the coroutine asynchronously initiates the **RetrieveFeedAsync** call and then it immediately suspends itself and returns control back to the caller (which is **main** in the example above).</span></span> <span data-ttu-id="f75a3-132">次に、フィードが取得および印刷されるまで、**main** は作業を続けます。</span><span class="sxs-lookup"><span data-stu-id="f75a3-132">**main** can then continue to do work while the feed is being retrieved and printed.</span></span> <span data-ttu-id="f75a3-133">完了すると (**RetrieveFeedAsync** 呼び出しが完了すると)、**ProcessFeedAsync** コルーチンは次のステートメントを再開します。</span><span class="sxs-lookup"><span data-stu-id="f75a3-133">When that's done (when the **RetrieveFeedAsync** call completes), the **ProcessFeedAsync** coroutine resumes at the next statement.</span></span>

<span data-ttu-id="f75a3-134">コルーチンは別のコルーチンに集約することができます。</span><span class="sxs-lookup"><span data-stu-id="f75a3-134">You can aggregate a couroutine into other coroutines.</span></span> <span data-ttu-id="f75a3-135">または、**get** を呼び出してブロックするか、完了するまで待機します (結果が存在する場合には取得します)。</span><span class="sxs-lookup"><span data-stu-id="f75a3-135">Or you can call **get** to block and wait for it to complete (and get the result if there is one).</span></span> <span data-ttu-id="f75a3-136">または、Windows ランタイムをサポートする別のプログラミング言語に渡すことができます。</span><span class="sxs-lookup"><span data-stu-id="f75a3-136">Or you can pass it to another programming language that supports the Windows Runtime.</span></span>

<span data-ttu-id="f75a3-137">また、デリゲートを使用して、非同期アクションおよび操作の完了イベントと進行状況イベントを処理することもできます。</span><span class="sxs-lookup"><span data-stu-id="f75a3-137">It's also possible to handle the completed and/or progress events of asynchronous actions and operations by using delegates.</span></span> <span data-ttu-id="f75a3-138">詳細とコード例については、「[非同期アクションと操作のデリゲート型](handle-events.md#delegate-types-for-asynchronous-actions-and-operations)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f75a3-138">For details, and code examples, see [Delegate types for asynchronous actions and operations](handle-events.md#delegate-types-for-asynchronous-actions-and-operations).</span></span>

## <a name="asychronously-return-a-windows-runtime-type"></a><span data-ttu-id="f75a3-139">Windows ランタイム型を非同期的に返す</span><span class="sxs-lookup"><span data-stu-id="f75a3-139">Asychronously return a Windows Runtime type</span></span>
<span data-ttu-id="f75a3-140">次の例では、特定の URI で呼び出しを **RetrieveFeedAsync** にラップして、[**SyndicationFeed**](/uwp/api/windows.web.syndication.syndicationfeed) を非同期的に返す **RetrieveBlogFeedAsync** 関数を示します。</span><span class="sxs-lookup"><span data-stu-id="f75a3-140">In this next example we wrap a call to **RetrieveFeedAsync**, for a specific URI, to give us a **RetrieveBlogFeedAsync** function that asynchronously returns a [**SyndicationFeed**](/uwp/api/windows.web.syndication.syndicationfeed).</span></span>

```cppwinrt
// main.cpp

#include "pch.h"
#include <winrt/Windows.Foundation.h>
#include <winrt/Windows.Web.Syndication.h>
#include <iostream>

using namespace winrt;
using namespace Windows::Foundation;
using namespace Windows::Web::Syndication;

void PrintFeed(SyndicationFeed syndicationFeed)
{
    for (SyndicationItem syndicationItem : syndicationFeed.Items())
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

<span data-ttu-id="f75a3-141">次の例では、**RetrieveBlogFeedAsync** は進捗状況と戻り値の両方が含まれる **IAsyncOperationWithProgress** を返します。</span><span class="sxs-lookup"><span data-stu-id="f75a3-141">In the example above, **RetrieveBlogFeedAsync** returns an **IAsyncOperationWithProgress**, which has both progress and a return value.</span></span> <span data-ttu-id="f75a3-142">**RetrieveBlogFeedAsync** が自分の処理を行い、フィードを取得している間は、他の作業を行うことができます。</span><span class="sxs-lookup"><span data-stu-id="f75a3-142">We can do other work while **RetrieveBlogFeedAsync** is doing its thing and retrieving the feed.</span></span> <span data-ttu-id="f75a3-143">次に、非同期操作オブジェクトで **get** を呼び出し、ブロックするか完了まで待機して、操作結果を取得します。</span><span class="sxs-lookup"><span data-stu-id="f75a3-143">Then, we call **get** on that asynchronous operation object to block, wait for it to complete, and then obtain the results of the operation.</span></span>

<span data-ttu-id="f75a3-144">Windows ランタイム型 (ファースト パーティかサード パーティかに関係なく) を非同期的に返す場合は、[**IAsyncOperation&lt;TResult&gt;**](/uwp/api/windows.foundation.iasyncoperation_tresult_) または [**IAsyncOperationWithProgress&lt;TResult, TProgress&gt;**](/uwp/api/windows.foundation.iasyncoperationwithprogress_tresult_tprogress_) を返す必要があります。</span><span class="sxs-lookup"><span data-stu-id="f75a3-144">If you're asynchronously returning a Windows Runtime type (whether that's a first-party or a third-party type), then you should return an [**IAsyncOperation&lt;TResult&gt;**](/uwp/api/windows.foundation.iasyncoperation_tresult_) or an [**IAsyncOperationWithProgress&lt;TResult, TProgress&gt;**](/uwp/api/windows.foundation.iasyncoperationwithprogress_tresult_tprogress_).</span></span>

<span data-ttu-id="f75a3-145">コンパイラは、Windows ランタイム型以外でこれらの非同期操作型のいずれかを使用しようとすると表示される "*WinRT 型である必要があります*" というエラーをサポートします。</span><span class="sxs-lookup"><span data-stu-id="f75a3-145">The compiler will help you with a "*must be WinRT type*" error if you try to use one of these asychronous operation types with a non-Windows Runtime type.</span></span>

## <a name="asychronously-return-a-non-windows-runtime-type"></a><span data-ttu-id="f75a3-146">Windows ランタイム型以外を非同期的に返す</span><span class="sxs-lookup"><span data-stu-id="f75a3-146">Asychronously return a non-Windows-Runtime type</span></span>
<span data-ttu-id="f75a3-147">Windows ランタイム型*以外*の型を非同期的に返す場合は、並列パターン ライブラリ (PPL) [**タスク**](https://msdn.microsoft.com/library/hh750113) を返す必要があります。</span><span class="sxs-lookup"><span data-stu-id="f75a3-147">If you're asynchronously returning a type that's *not* a Windows Runtime type, then you should return a Parallel Patterns Library (PPL) [**task**](https://msdn.microsoft.com/library/hh750113).</span></span> <span data-ttu-id="f75a3-148">**std::future** よりもパフォーマンスに優れているため (また、今後の互換性の向上により)、**タスク**をお勧めします。</span><span class="sxs-lookup"><span data-stu-id="f75a3-148">We recommend **task** because it gives you better performance (and better compatibility going forward) than **std::future** does.</span></span>

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
    // do other work.
    std::wcout << firstTitleOp.get() << std::endl;
}
```

## <a name="important-apis"></a><span data-ttu-id="f75a3-149">重要な API</span><span class="sxs-lookup"><span data-stu-id="f75a3-149">Important APIs</span></span>
* [<span data-ttu-id="f75a3-150">concurrency::task</span><span class="sxs-lookup"><span data-stu-id="f75a3-150">concurrency::task</span></span>](https://msdn.microsoft.com/library/hh750113)
* [<span data-ttu-id="f75a3-151">IAsyncAction</span><span class="sxs-lookup"><span data-stu-id="f75a3-151">IAsyncAction</span></span>](/uwp/api/windows.foundation.iasyncaction)
* [<span data-ttu-id="f75a3-152">IAsyncActionWithProgress&lt;TProgress&gt;</span><span class="sxs-lookup"><span data-stu-id="f75a3-152">IAsyncActionWithProgress&lt;TProgress&gt;</span></span>](/uwp/api/windows.foundation.iasyncactionwithprogress_tprogress_)
* [<span data-ttu-id="f75a3-153">IAsyncOperation&lt;TResult&gt;</span><span class="sxs-lookup"><span data-stu-id="f75a3-153">IAsyncOperation&lt;TResult&gt;</span></span>](/uwp/api/windows.foundation.iasyncoperation_tresult_)
* [<span data-ttu-id="f75a3-154">IAsyncOperationWithProgress&lt;TResult, TProgress&gt;</span><span class="sxs-lookup"><span data-stu-id="f75a3-154">IAsyncOperationWithProgress&lt;TResult, TProgress&gt;</span></span>](/uwp/api/windows.foundation.iasyncoperationwithprogress_tresult_tprogress_)
* [<span data-ttu-id="f75a3-155">SyndicationClient::RetrieveFeedAsync</span><span class="sxs-lookup"><span data-stu-id="f75a3-155">SyndicationClient::RetrieveFeedAsync</span></span>](/uwp/api/windows.web.syndication.syndicationclient.retrievefeedasync)
* [<span data-ttu-id="f75a3-156">SyndicationFeed</span><span class="sxs-lookup"><span data-stu-id="f75a3-156">SyndicationFeed</span></span>](/uwp/api/windows.web.syndication.syndicationfeed)
