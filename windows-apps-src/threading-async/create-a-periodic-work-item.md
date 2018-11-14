---
author: normesta
ms.assetid: 1B077801-0A58-4A34-887C-F1E85E9A37B0
title: 定期的な作業項目の作成
description: 定期的に実行される作業項目の作成方法を説明します。
ms.author: normesta
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10、UWP、定期的な作業項目、スレッド、タイマー
ms.localizationpriority: medium
ms.openlocfilehash: 4afa137b01738c42f8e15c95ef09ec921d1e44ae
ms.sourcegitcommit: 4d88adfaf544a3dab05f4660e2f59bbe60311c00
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/12/2018
ms.locfileid: "6448165"
---
# <a name="create-a-periodic-work-item"></a><span data-ttu-id="0ca61-104">定期的な作業項目の作成</span><span class="sxs-lookup"><span data-stu-id="0ca61-104">Create a periodic work item</span></span>


<span data-ttu-id="0ca61-105">\*\* 重要な API \*\*</span><span class="sxs-lookup"><span data-stu-id="0ca61-105">\*\* Important APIs \*\*</span></span>

-   [**<span data-ttu-id="0ca61-106">CreatePeriodicTimer</span><span class="sxs-lookup"><span data-stu-id="0ca61-106">CreatePeriodicTimer</span></span>**](https://msdn.microsoft.com/library/windows/apps/Hh967915)
-   [**<span data-ttu-id="0ca61-107">ThreadPoolTimer</span><span class="sxs-lookup"><span data-stu-id="0ca61-107">ThreadPoolTimer</span></span>**](https://msdn.microsoft.com/library/windows/apps/BR230587)

<span data-ttu-id="0ca61-108">定期的に実行される作業項目の作成方法を説明します。</span><span class="sxs-lookup"><span data-stu-id="0ca61-108">Learn how to create a work item that repeats periodically.</span></span>

## <a name="create-the-periodic-work-item"></a><span data-ttu-id="0ca61-109">定期的な作業項目の作成</span><span class="sxs-lookup"><span data-stu-id="0ca61-109">Create the periodic work item</span></span>

<span data-ttu-id="0ca61-110">定期的な作業項目を作成するには、[**CreatePeriodicTimer**](https://msdn.microsoft.com/library/windows/apps/Hh967915) メソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="0ca61-110">Use the [**CreatePeriodicTimer**](https://msdn.microsoft.com/library/windows/apps/Hh967915) method to create a periodic work item.</span></span> <span data-ttu-id="0ca61-111">作業を実行するラムダを指定し、*period* パラメーターを使って送信の間隔を指定します。</span><span class="sxs-lookup"><span data-stu-id="0ca61-111">Supply a lambda that accomplishes the work, and use the *period* parameter to specify the interval between submissions.</span></span> <span data-ttu-id="0ca61-112">period パラメーターは [**TimeSpan**](https://msdn.microsoft.com/library/windows/apps/BR225996) 構造体を使って指定します。</span><span class="sxs-lookup"><span data-stu-id="0ca61-112">The period is specified using a [**TimeSpan**](https://msdn.microsoft.com/library/windows/apps/BR225996) structure.</span></span> <span data-ttu-id="0ca61-113">この期間が経過するたびに作業項目が再送信されるため、作業を完了できる十分な長さを確保してください。</span><span class="sxs-lookup"><span data-stu-id="0ca61-113">The work item will be resubmitted every time the period elapses, so make sure the period is long enough for work to complete.</span></span>

<span data-ttu-id="0ca61-114">[**CreateTimer**](https://msdn.microsoft.com/library/windows/apps/windows.system.threading.threadpooltimer.createtimer.aspx) は [**ThreadPoolTimer**](https://msdn.microsoft.com/library/windows/apps/BR230587) オブジェクトを返します。</span><span class="sxs-lookup"><span data-stu-id="0ca61-114">[**CreateTimer**](https://msdn.microsoft.com/library/windows/apps/windows.system.threading.threadpooltimer.createtimer.aspx) returns a [**ThreadPoolTimer**](https://msdn.microsoft.com/library/windows/apps/BR230587) object.</span></span> <span data-ttu-id="0ca61-115">タイマーを取り消す必要が生じた場合は、このオブジェクトを格納します。</span><span class="sxs-lookup"><span data-stu-id="0ca61-115">Store this object in case the timer needs to be canceled.</span></span>

> <span data-ttu-id="0ca61-116">**注:** 0 の値を指定することを避けるため (または 1 ミリ秒未満の値) の間隔をします。</span><span class="sxs-lookup"><span data-stu-id="0ca61-116">**Note**Avoid specifying a value of zero (or any value less than one millisecond) for the interval.</span></span> <span data-ttu-id="0ca61-117">この場合、定期タイマーは 1 回限りのタイマーとして動作します。</span><span class="sxs-lookup"><span data-stu-id="0ca61-117">This causes the periodic timer to behave as a single-shot timer instead.</span></span>

> <span data-ttu-id="0ca61-118">**注:** を UI にアクセスし、作業項目の進捗状況を表示する[**CoreDispatcher.RunAsync**](https://msdn.microsoft.com/library/windows/apps/Hh750317)を使用することができます。</span><span class="sxs-lookup"><span data-stu-id="0ca61-118">**Note**You can use [**CoreDispatcher.RunAsync**](https://msdn.microsoft.com/library/windows/apps/Hh750317) to access the UI and show progress from the work item.</span></span>

<span data-ttu-id="0ca61-119">次の例では、60 秒ごとに 1 回実行される作業項目を作成します。</span><span class="sxs-lookup"><span data-stu-id="0ca61-119">The following example creates a work item that runs once every 60 seconds:</span></span>

> [!div class="tabbedCodeSnippets"]
> ```csharp
> TimeSpan period = TimeSpan.FromSeconds(60);
>
> ThreadPoolTimer PeriodicTimer = ThreadPoolTimer.CreatePeriodicTimer((source) =>
>     {
>         //
>         // TODO: Work
>         //
>         
>         //
>         // Update the UI thread by using the UI core dispatcher.
>         //
>         Dispatcher.RunAsync(CoreDispatcherPriority.High,
>             () =>
>             {
>                 //
>                 // UI components can be accessed within this scope.
>                 //
>
>             });
>
>     }, period);
> ```
> ``` cpp
> TimeSpan period;
> period.Duration = 60 * 10000000; // 10,000,000 ticks per second
>
> ThreadPoolTimer ^ PeriodicTimer = ThreadPoolTimer::CreatePeriodicTimer(
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
>                 }));
>
>         }), period);
> ```

## <a name="handle-cancellation-of-the-periodic-work-item-optional"></a><span data-ttu-id="0ca61-120">定期的な作業項目の取り消しの処理 (オプション)</span><span class="sxs-lookup"><span data-stu-id="0ca61-120">Handle cancellation of the periodic work item (optional)</span></span>

<span data-ttu-id="0ca61-121">必要であれば、[**TimerDestroyedHandler**](https://msdn.microsoft.com/library/windows/apps/Hh967926) を使って、定期タイマーの取り消しを処理できます。</span><span class="sxs-lookup"><span data-stu-id="0ca61-121">If needed, you can handle cancellation of the periodic timer with a [**TimerDestroyedHandler**](https://msdn.microsoft.com/library/windows/apps/Hh967926).</span></span> <span data-ttu-id="0ca61-122">定期的な作業項目の取り消しを処理するラムダを追加で指定するには、[**CreatePeriodicTimer**](https://msdn.microsoft.com/library/windows/apps/Hh967915) オーバーロードを使います。</span><span class="sxs-lookup"><span data-stu-id="0ca61-122">Use the [**CreatePeriodicTimer**](https://msdn.microsoft.com/library/windows/apps/Hh967915) overload to supply an additional lambda that handles cancellation of the periodic work item.</span></span>

<span data-ttu-id="0ca61-123">次の例では、60 秒ごとに実行される定期的な作業項目を作成します。ここでは取り消しハンドラーも指定しています。</span><span class="sxs-lookup"><span data-stu-id="0ca61-123">The following example creates a periodic work item that repeats every 60 seconds and it also supplies a cancellation handler:</span></span>

> [!div class="tabbedCodeSnippets"]
> ``` csharp
> using Windows.System.Threading;
>
>     TimeSpan period = TimeSpan.FromSeconds(60);
>
>     ThreadPoolTimer PeriodicTimer = ThreadPoolTimer.CreatePeriodicTimer((source) =>
>     {
>         //
>         // TODO: Work
>         //
>         
>         //
>         // Update the UI thread by using the UI core dispatcher.
>         //
>         Dispatcher.RunAsync(CoreDispatcherPriority.High,
>             () =>
>             {
>                 //
>                 // UI components can be accessed within this scope.
>                 //
>
>             });
>     },
>     period,
>     (source) =>
>     {
>         //
>         // TODO: Handle periodic timer cancellation.
>         //
>
>         //
>         // Update the UI thread by using the UI core dispatcher.
>         //
>         Dispatcher->RunAsync(CoreDispatcherPriority.High,
>             ()=>
>             {
>                 //
>                 // UI components can be accessed within this scope.
>                 //                 
>
>                 // Periodic timer cancelled.
>
>             }));
>     });
> ```
> ``` cpp
> using namespace Windows::System::Threading;
> using namespace Windows::UI::Core;
>
> TimeSpan period;
> period.Duration = 60 * 10000000; // 10,000,000 ticks per second
>
> ThreadPoolTimer ^ PeriodicTimer = ThreadPoolTimer::CreatePeriodicTimer(
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
>                 }));
>
>         }),
>         period,
>         ref new TimerDestroyedHandler([&](ThreadPoolTimer ^ source)
>         {
>             //
>             // TODO: Handle periodic timer cancellation.
>             //
>
>             Dispatcher->RunAsync(CoreDispatcherPriority::High,
>                 ref new DispatchedHandler([&]()
>                 {
>                     //
>                     // UI components can be accessed within this scope.
>                     //
>
>                     // Periodic timer cancelled.
>
>                 }));
>         }));
> ```

## <a name="cancel-the-timer"></a><span data-ttu-id="0ca61-124">タイマーの取り消し</span><span class="sxs-lookup"><span data-stu-id="0ca61-124">Cancel the timer</span></span>

<span data-ttu-id="0ca61-125">必要に応じて [**Cancel**](https://msdn.microsoft.com/library/windows/apps/windows.system.threading.threadpooltimer.cancel.aspx) メソッドを呼び出し、定期的な作業項目の繰り返しを停止します。</span><span class="sxs-lookup"><span data-stu-id="0ca61-125">When necessary, call the [**Cancel**](https://msdn.microsoft.com/library/windows/apps/windows.system.threading.threadpooltimer.cancel.aspx) method to stop the periodic work item from repeating.</span></span> <span data-ttu-id="0ca61-126">定期タイマーが取り消されたときに作業項目が実行中だった場合には、完了するまで実行することができます。</span><span class="sxs-lookup"><span data-stu-id="0ca61-126">If the work item is running when the periodic timer is cancelled it is allowed to complete.</span></span> <span data-ttu-id="0ca61-127">定期的な作業項目のすべてのインスタンスが完了したときに、[**TimerDestroyedHandler**](https://msdn.microsoft.com/library/windows/apps/Hh967926) が呼び出されます (指定していた場合)。</span><span class="sxs-lookup"><span data-stu-id="0ca61-127">The [**TimerDestroyedHandler**](https://msdn.microsoft.com/library/windows/apps/Hh967926) (if provided) is called when all instances of the periodic work item have completed.</span></span>

> [!div class="tabbedCodeSnippets"]
> ``` csharp
> PeriodicTimer.Cancel();
> ```
> ``` cpp
> PeriodicTimer->Cancel();
> ```

## <a name="remarks"></a><span data-ttu-id="0ca61-128">注釈</span><span class="sxs-lookup"><span data-stu-id="0ca61-128">Remarks</span></span>

<span data-ttu-id="0ca61-129">1 回限りのタイマーについて詳しくは、「[タイマーを使った作業項目の送信](use-a-timer-to-submit-a-work-item.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0ca61-129">For information about single-use timers, see [Use a timer to submit a work item](use-a-timer-to-submit-a-work-item.md).</span></span>

## <a name="related-topics"></a><span data-ttu-id="0ca61-130">関連トピック</span><span class="sxs-lookup"><span data-stu-id="0ca61-130">Related topics</span></span>

* [<span data-ttu-id="0ca61-131">スレッド プールへの作業項目の送信</span><span class="sxs-lookup"><span data-stu-id="0ca61-131">Submit a work item to the thread pool</span></span>](submit-a-work-item-to-the-thread-pool.md)
* [<span data-ttu-id="0ca61-132">スレッド プールを使うためのベスト プラクティス</span><span class="sxs-lookup"><span data-stu-id="0ca61-132">Best practices for using the thread pool</span></span>](best-practices-for-using-the-thread-pool.md)
* [<span data-ttu-id="0ca61-133">タイマーを使った作業項目の送信</span><span class="sxs-lookup"><span data-stu-id="0ca61-133">Use a timer to submit a work item</span></span>](use-a-timer-to-submit-a-work-item.md)
 
