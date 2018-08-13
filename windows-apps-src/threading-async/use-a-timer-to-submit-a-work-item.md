---
author: normesta
ms.assetid: AAE467F9-B3C7-4366-99A2-8A880E5692BE
title: タイマーを使った作業項目の送信
description: タイマーが終了した後に実行される作業項目の作成方法を説明します。
ms.author: normesta
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, タイマー, スレッド
ms.openlocfilehash: 214a3ad9d84ffb8bc26a4aa02d79d0b1c06f2bfe
ms.sourcegitcommit: 378382419f1fda4e4df76ffa9c8cea753d271e6a
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 06/08/2017
ms.locfileid: "665346"
---
# <a name="use-a-timer-to-submit-a-work-item"></a><span data-ttu-id="82ee6-104">タイマーを使った作業項目の送信</span><span class="sxs-lookup"><span data-stu-id="82ee6-104">Use a timer to submit a work item</span></span>

<span data-ttu-id="82ee6-105">\[Windows 10 の UWP アプリ向けに更新。</span><span class="sxs-lookup"><span data-stu-id="82ee6-105">\[ Updated for UWP apps on Windows 10.</span></span> <span data-ttu-id="82ee6-106">Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]</span><span class="sxs-lookup"><span data-stu-id="82ee6-106">For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]</span></span>

<span data-ttu-id="82ee6-107">** 重要な API **</span><span class="sxs-lookup"><span data-stu-id="82ee6-107">** Important APIs **</span></span>

-   [**<span data-ttu-id="82ee6-108">Windows.UI.Core 名前空間</span><span class="sxs-lookup"><span data-stu-id="82ee6-108">Windows.UI.Core namespace</span></span>**](https://msdn.microsoft.com/library/windows/apps/BR208383)
-   [**<span data-ttu-id="82ee6-109">Windows.System.Threading 名前空間</span><span class="sxs-lookup"><span data-stu-id="82ee6-109">Windows.System.Threading namespace</span></span>**](https://msdn.microsoft.com/library/windows/apps/BR229642)

<span data-ttu-id="82ee6-110">タイマーが終了した後に実行される作業項目の作成方法を説明します。</span><span class="sxs-lookup"><span data-stu-id="82ee6-110">Learn how to create a work item that runs after a timer elapses.</span></span>

## <a name="create-a-single-shot-timer"></a><span data-ttu-id="82ee6-111">1 回限りのタイマーの作成</span><span class="sxs-lookup"><span data-stu-id="82ee6-111">Create a single-shot timer</span></span>

<span data-ttu-id="82ee6-112">[**CreateTimer**](https://msdn.microsoft.com/library/windows/apps/Hh967921) メソッドを使って、作業項目に対応するタイマーを作成します。</span><span class="sxs-lookup"><span data-stu-id="82ee6-112">Use the [**CreateTimer**](https://msdn.microsoft.com/library/windows/apps/Hh967921) method to create a timer for the work item.</span></span> <span data-ttu-id="82ee6-113">作業を実行するラムダを指定し、*delay* パラメーターを使って、利用可能なスレッドに作業項目を割り当てることができるようになるまでスレッド プールが待機する時間を指定します。</span><span class="sxs-lookup"><span data-stu-id="82ee6-113">Supply a lambda that accomplishes the work, and use the *delay* parameter to specify how long the thread pool waits before it can assign the work item to an available thread.</span></span> <span data-ttu-id="82ee6-114">delay パラメーターは [**TimeSpan**](https://msdn.microsoft.com/library/windows/apps/BR225996) 構造体を使って指定します。</span><span class="sxs-lookup"><span data-stu-id="82ee6-114">The delay is specified using a [**TimeSpan**](https://msdn.microsoft.com/library/windows/apps/BR225996) structure.</span></span>

> <span data-ttu-id="82ee6-115">**注**  [**CoreDispatcher.RunAsync**](https://msdn.microsoft.com/library/windows/apps/Hh750317) を使って UI にアクセスしたり、作業項目の進捗状況を表示したりすることができます。</span><span class="sxs-lookup"><span data-stu-id="82ee6-115">**Note**  You can use [**CoreDispatcher.RunAsync**](https://msdn.microsoft.com/library/windows/apps/Hh750317) to access the UI and show progress from the work item.</span></span>

<span data-ttu-id="82ee6-116">次の例では、3 分間実行される作業項目を作成します。</span><span class="sxs-lookup"><span data-stu-id="82ee6-116">The following example creates a work item that runs in three minutes:</span></span>

> [!div class="tabbedCodeSnippets"]
> ``` csharp
> TimeSpan delay = TimeSpan.FromMinutes(3);
>             
> ThreadPoolTimer DelayTimer = ThreadPoolTimer.CreateTimer(
>     (source) =>
>     {
>         //
>         // TODO: Work
>         //
>         
>         //
>         // Update the UI thread by using the UI core dispatcher.
>         //
>         Dispatcher.RunAsync(
>             CoreDispatcherPriority.High,
>             () =>
>             {
>                 //
>                 // UI components can be accessed within this scope.
>                 //
>
>             });
>
>     }, delay);
> ```
> ``` cpp
> TimeSpan delay;
> delay.Duration = 3 * 60 * 10000000; // 10,000,000 ticks per second
>
> ThreadPoolTimer ^ DelayTimer = ThreadPoolTimer::CreateTimer(
>         ref new TimerElapsedHandler([this](ThreadPoolTimer^ source)
>         {
>             //
>             // TODO: Work
>             //
>             
>             //
>             // Update the UI thread by using the UI core dispatcher.
>             //
>             Dispatcher->RunAsync(CoreDispatcherPriority::High,
>                 ref new DispatchedHandler([this]()
>                 {
>                     //
>                     // UI components can be accessed within this scope.
>                     //
>
>                     ExampleUIUpdateMethod("Timer completed.");
>
>                 }));
>
>         }), delay);
> ```

## <a name="provide-a-completion-handler"></a><span data-ttu-id="82ee6-117">完了ハンドラーの指定</span><span class="sxs-lookup"><span data-stu-id="82ee6-117">Provide a completion handler</span></span>

<span data-ttu-id="82ee6-118">必要であれば、[**TimerDestroyedHandler**](https://msdn.microsoft.com/library/windows/apps/Hh967926) を使って、作業項目の取り消しと完了を処理します。</span><span class="sxs-lookup"><span data-stu-id="82ee6-118">If needed, handle cancellation and completion of the work item with a [**TimerDestroyedHandler**](https://msdn.microsoft.com/library/windows/apps/Hh967926).</span></span> <span data-ttu-id="82ee6-119">追加のラムダを指定するには、[**CreateTimer**](https://msdn.microsoft.com/library/windows/apps/Hh967921) オーバーロードを使います。</span><span class="sxs-lookup"><span data-stu-id="82ee6-119">Use the [**CreateTimer**](https://msdn.microsoft.com/library/windows/apps/Hh967921) overload to supply an additional lambda.</span></span> <span data-ttu-id="82ee6-120">これは、タイマーが取り消されたとき、または作業項目が完了したときに実行されます。</span><span class="sxs-lookup"><span data-stu-id="82ee6-120">This runs when the timer is cancelled or when the work item completes.</span></span>

<span data-ttu-id="82ee6-121">次の例では、作業項目を送信するタイマーを作成し、作業項目が完了したとき、またはタイマーが取り消されたときにメソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="82ee6-121">The following example creates a timer that submits the work item, and calls a method when the work item finishes or the timer is cancelled:</span></span>

> [!div class="tabbedCodeSnippets"]
> ``` csharp
> TimeSpan delay = TimeSpan.FromMinutes(3);
>             
> bool completed = false;
>
> ThreadPoolTimer DelayTimer = ThreadPoolTimer.CreateTimer(
>     (source) =>
>     {
>         //
>         // TODO: Work
>         //
>
>         //
>         // Update the UI thread by using the UI core dispatcher.
>         //
>         Dispatcher.RunAsync(
>                 CoreDispatcherPriority.High,
>                 () =>
>                 {
>                     //
>                     // UI components can be accessed within this scope.
>                     //
>
>                 });
>
>         completed = true;
>     },
>     delay,
>     (source) =>
>     {
>         //
>         // TODO: Handle work cancellation/completion.
>         //
>
>
>         //
>         // Update the UI thread by using the UI core dispatcher.
>         //
>         Dispatcher.RunAsync(
>             CoreDispatcherPriority.High,
>             () =>
>             {
>                 //
>                 // UI components can be accessed within this scope.
>                 //
>
>                 if (completed)
>                 {
>                     // Timer completed.
>                 }
>                 else
>                 {
>                     // Timer cancelled.
>                 }
>
>             });
>     });
> ```
> ``` cpp
> TimeSpan delay;
> delay.Duration = 3 * 60 * 10000000; // 10,000,000 ticks per second
>
> completed = false;
>
> ThreadPoolTimer ^ DelayTimer = ThreadPoolTimer::CreateTimer(
>         ref new TimerElapsedHandler([&](ThreadPoolTimer ^ source)
>         {
>             //
>             // TODO: Work
>             //
>
>             //
>             // Update the UI thread by using the UI core dispatcher.
>             //
>             Dispatcher->RunAsync(CoreDispatcherPriority::High,
>                 ref new DispatchedHandler([&]()
>                 {
>                     //
>                     // UI components can be accessed within this scope.
>                     //
>
>                 }));
>
>             completed = true;
>
>         }),
>         delay,
>         ref new TimerDestroyedHandler([&](ThreadPoolTimer ^ source)
>         {
>             //
>             // TODO: Handle work cancellation/completion.
>             //
>
>             Dispatcher->RunAsync(CoreDispatcherPriority::High,
>                 ref new DispatchedHandler([&]()
>                 {
>                     //
>                     // Update the UI thread by using the UI core dispatcher.
>                     //
>
>                     if (completed)
>                     {
>                         // Timer completed.
>                     }
>                     else
>                     {
>                         // Timer cancelled.
>                     }
>
>                 }));
>         }));
> ```

## <a name="cancel-the-timer"></a><span data-ttu-id="82ee6-122">タイマーの取り消し</span><span class="sxs-lookup"><span data-stu-id="82ee6-122">Cancel the timer</span></span>

<span data-ttu-id="82ee6-123">タイマーがカウント ダウンを続けているが、作業項目はもう不要である場合は、[**Cancel**](https://msdn.microsoft.com/library/windows/apps/BR230588) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="82ee6-123">If the timer is still counting down, but the work item is no longer needed, call [**Cancel**](https://msdn.microsoft.com/library/windows/apps/BR230588).</span></span> <span data-ttu-id="82ee6-124">タイマーが取り消され、作業項目がスレッド プールに送信されなくなります。</span><span class="sxs-lookup"><span data-stu-id="82ee6-124">The timer is cancelled and the work item won't be submitted to the thread pool.</span></span>

> [!div class="tabbedCodeSnippets"]
> ``` csharp
> DelayTimer.Cancel();
> ```
> ``` cpp
> DelayTimer->Cancel();
> ```

## <a name="remarks"></a><span data-ttu-id="82ee6-125">注釈</span><span class="sxs-lookup"><span data-stu-id="82ee6-125">Remarks</span></span>

<span data-ttu-id="82ee6-126">ユニバーサル Windows プラットフォーム (UWP) アプリでは UI スレッドをブロックできるため、**Thread.Sleep** を使うことができません。</span><span class="sxs-lookup"><span data-stu-id="82ee6-126">Universal Windows Platform (UWP) apps can't use **Thread.Sleep** because it can block the UI thread.</span></span> <span data-ttu-id="82ee6-127">代わりに、[**ThreadPoolTimer**](https://msdn.microsoft.com/library/windows/apps/BR230587) を使って作業項目を作ります。これによって、UI スレッドをブロックすることなく、作業項目によって実行されたタスクを遅延します。</span><span class="sxs-lookup"><span data-stu-id="82ee6-127">You can use a [**ThreadPoolTimer**](https://msdn.microsoft.com/library/windows/apps/BR230587) to create a work item instead, and this will delay the task accomplished by the work item without blocking the UI thread.</span></span>

<span data-ttu-id="82ee6-128">作業項目、タイマー作業項目、定期的な作業項目の使い方を示すコード サンプル全体については、[スレッド プールのサンプルに関するページ](http://go.microsoft.com/fwlink/p/?linkid=255387)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="82ee6-128">See the [thread pool sample](http://go.microsoft.com/fwlink/p/?linkid=255387) for a complete code sample that demonstrates work items, timer work items, and periodic work items.</span></span> <span data-ttu-id="82ee6-129">コード サンプルは、当初、Windows 8.1 用に作成されましたが、コードは Windows 10 で再利用できます。</span><span class="sxs-lookup"><span data-stu-id="82ee6-129">The code sample was originally written for Windows 8.1 but the code can be re-used in Windows 10.</span></span>

<span data-ttu-id="82ee6-130">繰り返しタイマーについて詳しくは、「[定期的な作業項目の作成](create-a-periodic-work-item.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="82ee6-130">For information about repeating timers, see [Create a periodic work item](create-a-periodic-work-item.md).</span></span>

## <a name="related-topics"></a><span data-ttu-id="82ee6-131">関連トピック</span><span class="sxs-lookup"><span data-stu-id="82ee6-131">Related topics</span></span>

* [<span data-ttu-id="82ee6-132">スレッド プールへの作業項目の送信</span><span class="sxs-lookup"><span data-stu-id="82ee6-132">Submit a work item to the thread pool</span></span>](submit-a-work-item-to-the-thread-pool.md)
* [<span data-ttu-id="82ee6-133">スレッド プールを使うためのベスト プラクティス</span><span class="sxs-lookup"><span data-stu-id="82ee6-133">Best practices for using the thread pool</span></span>](best-practices-for-using-the-thread-pool.md)
* [<span data-ttu-id="82ee6-134">タイマーを使った作業項目の送信</span><span class="sxs-lookup"><span data-stu-id="82ee6-134">Use a timer to submit a work item</span></span>](use-a-timer-to-submit-a-work-item.md)
 

 
