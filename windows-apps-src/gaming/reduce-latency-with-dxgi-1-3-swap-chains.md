---
author: mtoepke
title: DXGI 1.3 スワップ チェーンによる遅延の減少
description: DXGI 1.3 を使って、スワップ チェーンが新しいフレームのレンダリング開始の適切な時間を通知するまで待機することで、実質的なフレーム待機時間を削減します。
ms.assetid: c99b97ed-a757-879f-3d55-7ed77133f6ce
ms.author: mtoepke
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, ゲーム, 待機時間, DXGI, スワップ チェーン, DirectX
ms.openlocfilehash: 9f2babdac40e3baf27bec9b2e214e9350d1f2539
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.locfileid: "243183"
---
# <a name="reduce-latency-with-dxgi-13-swap-chains"></a><span data-ttu-id="e6d05-104">DXGI 1.3 スワップ チェーンによる遅延の減少</span><span class="sxs-lookup"><span data-stu-id="e6d05-104">Reduce latency with DXGI 1.3 swap chains</span></span>


<span data-ttu-id="e6d05-105">\[ Windows 10 の UWP アプリ向けに更新。</span><span class="sxs-lookup"><span data-stu-id="e6d05-105">\[ Updated for UWP apps on Windows 10.</span></span> <span data-ttu-id="e6d05-106">Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]</span><span class="sxs-lookup"><span data-stu-id="e6d05-106">For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]</span></span>

<span data-ttu-id="e6d05-107">DXGI 1.3 を使って、スワップ チェーンが新しいフレームのレンダリング開始の適切な時間を通知するまで待機することで、実質的なフレーム待機時間を削減します。</span><span class="sxs-lookup"><span data-stu-id="e6d05-107">Use DXGI 1.3 to reduce the effective frame latency by waiting for the swap chain to signal the appropriate time to begin rendering a new frame.</span></span> <span data-ttu-id="e6d05-108">ゲームでは一般的に、プレイヤーの入力を受け取った時点からゲームがその入力に応答して表示を更新するまでの待機時間を、可能な限り短縮する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e6d05-108">Games typically need to provide the lowest amount of latency possible from the time the player input is received, to when the game responds to that input by updating the display.</span></span> <span data-ttu-id="e6d05-109">このトピックでは、Direct3D 11.2 以降で利用できるようになった、ゲーム内の実際のフレーム待機時間を最小化する手法について説明します。</span><span class="sxs-lookup"><span data-stu-id="e6d05-109">This topic explains a technique available starting in Direct3D 11.2 that you can use to minimize the effective frame latency in your game.</span></span>

## <a name="how-does-waiting-on-the-back-buffer-reduce-latency"></a><span data-ttu-id="e6d05-110">バック バッファーでの待機によって待機時間を減らす方法</span><span class="sxs-lookup"><span data-stu-id="e6d05-110">How does waiting on the back buffer reduce latency?</span></span>


<span data-ttu-id="e6d05-111">フリップ モデルのスワップ チェーンでは、ゲームが [**IDXGISwapChain::Present**](https://msdn.microsoft.com/library/windows/desktop/bb174576) を呼び出すたびにバック バッファーの "フリップ" がキューに入れられます。</span><span class="sxs-lookup"><span data-stu-id="e6d05-111">With the flip model swap chain, back buffer "flips" are queued whenever your game calls [**IDXGISwapChain::Present**](https://msdn.microsoft.com/library/windows/desktop/bb174576).</span></span> <span data-ttu-id="e6d05-112">レンダリング ループによって Present() が呼び出されると、前のフレームの表示が完了するまでスレッドがブロックされ、新しいフレームが実際に表示されるまでキューに入れておくための領域を確保します。</span><span class="sxs-lookup"><span data-stu-id="e6d05-112">When the rendering loop calls Present(), the system blocks the thread until it is done presenting a prior frame, making room to queue up the new frame, before it actually presents.</span></span> <span data-ttu-id="e6d05-113">これにより、ゲームによってフレームを描画した時点から、そのフレームが表示できるようになる時点まで、追加の待機時間が生まれます。</span><span class="sxs-lookup"><span data-stu-id="e6d05-113">This causes extra latency between the time the game draws a frame and the time the system allows it to display that frame.</span></span> <span data-ttu-id="e6d05-114">多くの場合、各フレームのレンダリングが開始されてから表示されるまでの間にほぼ 1 フレーム分の追加待機時間が常に発生するという、安定した状態に到達します。</span><span class="sxs-lookup"><span data-stu-id="e6d05-114">In many cases, the system will reach a stable equilibrium where the game is always waiting almost a full extra frame between the time it renders and the time it presents each frame.</span></span> <span data-ttu-id="e6d05-115">新しいフレームを許可する準備が整うまで待機してから、現在のデータに基づいてフレームをレンダリングし、即座にキューに入れることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="e6d05-115">It's better to wait until the system is ready to accept a new frame, then render the frame based on current data and queue the frame immediately.</span></span>

<span data-ttu-id="e6d05-116">[**DXGI\_SWAP\_CHAIN\_FLAG\_FRAME\_LATENCY\_WAITABLE\_OBJECT**](https://msdn.microsoft.com/library/windows/desktop/bb173076) フラグを使って待機可能スワップ チェーンを作成します。</span><span class="sxs-lookup"><span data-stu-id="e6d05-116">Create a waitable swap chain with the [**DXGI\_SWAP\_CHAIN\_FLAG\_FRAME\_LATENCY\_WAITABLE\_OBJECT**](https://msdn.microsoft.com/library/windows/desktop/bb173076) flag.</span></span> <span data-ttu-id="e6d05-117">この方法で作成されたスワップ チェーンでは、システムが実際に新しいフレームを許可する準備ができたことをレンダリング ループに通知できます。</span><span class="sxs-lookup"><span data-stu-id="e6d05-117">Swap chains created this way can notify your rendering loop when the system is actually ready to accept a new frame.</span></span> <span data-ttu-id="e6d05-118">これにより、現在のデータに基づいてレンダリングした結果を即座に現在のキューに入れることができます。</span><span class="sxs-lookup"><span data-stu-id="e6d05-118">This allows your game to render based on current data and then put the result in the present queue right away.</span></span>

## <a name="step-1-create-a-waitable-swap-chain"></a><span data-ttu-id="e6d05-119">手順 1: 待機可能スワップ チェーンを作成する</span><span class="sxs-lookup"><span data-stu-id="e6d05-119">Step 1: Create a waitable swap chain</span></span>


<span data-ttu-id="e6d05-120">[**CreateSwapChainForCoreWindow**](https://msdn.microsoft.com/library/windows/desktop/hh404559) を呼び出すときに [**DXGI\_SWAP\_CHAIN\_FLAG\_FRAME\_LATENCY\_WAITABLE\_OBJECT**](https://msdn.microsoft.com/library/windows/desktop/bb173076) フラグを指定します。</span><span class="sxs-lookup"><span data-stu-id="e6d05-120">Specify the [**DXGI\_SWAP\_CHAIN\_FLAG\_FRAME\_LATENCY\_WAITABLE\_OBJECT**](https://msdn.microsoft.com/library/windows/desktop/bb173076) flag when you call [**CreateSwapChainForCoreWindow**](https://msdn.microsoft.com/library/windows/desktop/hh404559).</span></span>

```cpp
swapChainDesc.Flags = DXGI_SWAP_CHAIN_FLAG_FRAME_LATENCY_WAITABLE_OBJECT; // Enable GetFrameLatencyWaitableObject().
```

> <span data-ttu-id="e6d05-121">**注** 一部の他のフラグと異なり、このフラグは [**ResizeBuffers**](https://msdn.microsoft.com/library/windows/desktop/bb174577) を使って追加または削除できません。</span><span class="sxs-lookup"><span data-stu-id="e6d05-121">**Note**   In contrast to some flags, this flag can't be added or removed using [**ResizeBuffers**](https://msdn.microsoft.com/library/windows/desktop/bb174577).</span></span> <span data-ttu-id="e6d05-122">このフラグの設定が、スワップ チェーンが作成された時点の設定と異なっている場合、DXGI はエラー コードを返します。</span><span class="sxs-lookup"><span data-stu-id="e6d05-122">DXGI returns an error code if this flag is set differently from when the swap chain was created.</span></span>

 

```cpp
// If the swap chain already exists, resize it.
HRESULT hr = m_swapChain->ResizeBuffers(
    2, // Double-buffered swap chain.
    static_cast<UINT>(m_d3dRenderTargetSize.Width),
    static_cast<UINT>(m_d3dRenderTargetSize.Height),
    DXGI_FORMAT_B8G8R8A8_UNORM,
    DXGI_SWAP_CHAIN_FLAG_FRAME_LATENCY_WAITABLE_OBJECT // Enable GetFrameLatencyWaitableObject().
    );
```

## <a name="step-2-set-the-frame-latency"></a><span data-ttu-id="e6d05-123">手順 2: フレーム待機時間を設定する</span><span class="sxs-lookup"><span data-stu-id="e6d05-123">Step 2: Set the frame latency</span></span>


<span data-ttu-id="e6d05-124">フレーム待機時間は、[**IDXGIDevice1::SetMaximumFrameLatency**](https://msdn.microsoft.com/library/windows/desktop/ff471334) を呼び出すのではなく [**IDXGISwapChain2::SetMaximumFrameLatency**](https://msdn.microsoft.com/library/windows/desktop/dn268313) API を使って設定します。</span><span class="sxs-lookup"><span data-stu-id="e6d05-124">Set the frame latency with the [**IDXGISwapChain2::SetMaximumFrameLatency**](https://msdn.microsoft.com/library/windows/desktop/dn268313) API, instead of calling [**IDXGIDevice1::SetMaximumFrameLatency**](https://msdn.microsoft.com/library/windows/desktop/ff471334).</span></span>

<span data-ttu-id="e6d05-125">既定では、待機可能スワップ チェーンのフレーム待機時間が 1 に設定されており、最小限の待機時間になっていますが、これにより CPU-GPU 並列処理も削減されます。</span><span class="sxs-lookup"><span data-stu-id="e6d05-125">By default, the frame latency for waitable swap chains is set to 1, which results in the least possible latency but also reduces CPU-GPU parallelism.</span></span> <span data-ttu-id="e6d05-126">60 FPS を達成するために CPU-GPU 並列処理を増やす必要がある場合、つまり CPU と GPU それぞれの 1 フレーム分の処理レンダリング処理時間を 16.7 ミリ秒未満に抑えたが、CPU と GPU を合わせた合計処理時間が 16.7 ミリ秒を超えている場合は、フレームの待機時間を 2 に設定します。</span><span class="sxs-lookup"><span data-stu-id="e6d05-126">If you need increased CPU-GPU parallelism to achieve 60 FPS - that is, if the CPU and GPU each spend less than 16.7 ms a frame processing rendering work, but their combined sum is greater than 16.7 ms — set the frame latency to 2.</span></span> <span data-ttu-id="e6d05-127">これにより、前のフレームの間に CPU がキューに入れた作業を GPU で処理できます。同時に、CPU はそれと関係なく現在のフレームのレンダリング コマンドを送信できます。</span><span class="sxs-lookup"><span data-stu-id="e6d05-127">This allows the GPU to process work queued up by the CPU during the previous frame, while at the same time allowing the CPU to submit rendering commands for the current frame independently.</span></span>

```cpp
// Swapchains created with the DXGI_SWAP_CHAIN_FLAG_FRAME_LATENCY_WAITABLE_OBJECT flag use their
// own per-swapchain latency setting instead of the one associated with the DXGI device. The
// default per-swapchain latency is 1, which ensures that DXGI does not queue more than one frame
// at a time. This both reduces latency and ensures that the application will only render after
// each VSync, minimizing power consumption.
//DX::ThrowIfFailed(
//    swapChain2->SetMaximumFrameLatency(1)
//    );
```

## <a name="step-3-get-the-waitable-object-from-the-swap-chain"></a><span data-ttu-id="e6d05-128">手順 3: スワップ チェーンから待機可能オブジェクトを取得する</span><span class="sxs-lookup"><span data-stu-id="e6d05-128">Step 3: Get the waitable object from the swap chain</span></span>


<span data-ttu-id="e6d05-129">[**IDXGISwapChain2::GetFrameLatencyWaitableObject**](https://msdn.microsoft.com/library/windows/desktop/dn268309) を呼び出して待機ハンドルを取得します。</span><span class="sxs-lookup"><span data-stu-id="e6d05-129">Call [**IDXGISwapChain2::GetFrameLatencyWaitableObject**](https://msdn.microsoft.com/library/windows/desktop/dn268309) to retrieve the wait handle.</span></span> <span data-ttu-id="e6d05-130">待機ハンドルは、待機可能オブジェクトへのポインターです。</span><span class="sxs-lookup"><span data-stu-id="e6d05-130">The wait handle is a pointer to the waitable object.</span></span> <span data-ttu-id="e6d05-131">レンダリング ループで使うために、このハンドルを格納します。</span><span class="sxs-lookup"><span data-stu-id="e6d05-131">Store this handle for use by your rendering loop.</span></span>

```cpp
// Get the frame latency waitable object, which is used by the WaitOnSwapChain method. This
// requires that swap chain be created with the DXGI_SWAP_CHAIN_FLAG_FRAME_LATENCY_WAITABLE_OBJECT
// flag.
m_frameLatencyWaitableObject = swapChain2->GetFrameLatencyWaitableObject();
```

## <a name="step-4-wait-before-rendering-each-frame"></a><span data-ttu-id="e6d05-132">手順 4: 各フレームをレンダリングする前に待機する</span><span class="sxs-lookup"><span data-stu-id="e6d05-132">Step 4: Wait before rendering each frame</span></span>


<span data-ttu-id="e6d05-133">レンダリング ループでは、各フレームのレンダリングを開始する前に、待機可能オブジェクトを利用してスワップ チェーンによる通知を待機する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e6d05-133">Your rendering loop should wait for the swap chain to signal via the waitable object before it begins rendering every frame.</span></span> <span data-ttu-id="e6d05-134">これには、スワップ チェーンでレンダリングされた最初のフレームが含まれます。</span><span class="sxs-lookup"><span data-stu-id="e6d05-134">This includes the first frame rendered with the swap chain.</span></span> <span data-ttu-id="e6d05-135">[**WaitForSingleObjectEx**](https://msdn.microsoft.com/library/windows/desktop/ms687036) を使い、手順 2. で取得した待機ハンドルを提供して各フレームの開始を通知します。</span><span class="sxs-lookup"><span data-stu-id="e6d05-135">Use [**WaitForSingleObjectEx**](https://msdn.microsoft.com/library/windows/desktop/ms687036), providing the wait handle retrieved in Step 2, to signal the start of each frame.</span></span>

<span data-ttu-id="e6d05-136">次の例は、DirectXLatency サンプルからのレンダー ループを示しています。</span><span class="sxs-lookup"><span data-stu-id="e6d05-136">The following example shows the render loop from the DirectXLatency sample:</span></span>

```cpp
while (!m_windowClosed)
{
    if (m_windowVisible)
    {
        // Block this thread until the swap chain is finished presenting. Note that it is
        // important to call this before the first Present in order to minimize the latency
        // of the swap chain.
        m_deviceResources->WaitOnSwapChain();

        // Process any UI events in the queue.
        CoreWindow::GetForCurrentThread()->Dispatcher->ProcessEvents(CoreProcessEventsOption::ProcessAllIfPresent);

        // Update app state in response to any UI events that occurred.
        m_main->Update();

        // Render the scene.
        m_main->Render();

        // Present the scene.
        m_deviceResources->Present();
    }
    else
    {
        // The window is hidden. Block until a UI event occurs.
        CoreWindow::GetForCurrentThread()->Dispatcher->ProcessEvents(CoreProcessEventsOption::ProcessOneAndAllPending);
    }
}
```

<span data-ttu-id="e6d05-137">次の例は、DirectXLatency サンプルからの WaitForSingleObjectEx 呼び出しを示しています。</span><span class="sxs-lookup"><span data-stu-id="e6d05-137">The following example shows the WaitForSingleObjectEx call from the DirectXLatency sample:</span></span>

```cpp
// Block the current thread until the swap chain has finished presenting.
void DX::DeviceResources::WaitOnSwapChain()
{
    DWORD result = WaitForSingleObjectEx(
        m_frameLatencyWaitableObject,
        1000, // 1 second timeout (shouldn't ever occur)
        true
        );
}
```

## <a name="what-should-my-game-do-while-it-waits-for-the-swap-chain-to-present"></a><span data-ttu-id="e6d05-138">ゲームがスワップ チェーンの表示を待機する間に実行する必要のあるタスク</span><span class="sxs-lookup"><span data-stu-id="e6d05-138">What should my game do while it waits for the swap chain to present?</span></span>


<span data-ttu-id="e6d05-139">レンダー ループをブロックするタスクがゲームに存在しない場合、スワップ チェーンが表示されるまで待機することが消費電力の削減 (モバイル デバイスで特に重要) に有効な場合があります。</span><span class="sxs-lookup"><span data-stu-id="e6d05-139">If your game doesn’t have any tasks that block on the render loop, letting it wait for the swap chain to present can be advantageous because it saves power, which is especially important on mobile devices.</span></span> <span data-ttu-id="e6d05-140">レンダー ループをブロックするタスクが存在する場合は、スワップ チェーンの表示を待機している間にマルチスレッドを使って作業を完了できます。</span><span class="sxs-lookup"><span data-stu-id="e6d05-140">Otherwise, you can use multithreading to accomplish work while your game is waiting for the swap chain to present.</span></span> <span data-ttu-id="e6d05-141">次に、ゲームで実行できるタスクのごく一部を示します。</span><span class="sxs-lookup"><span data-stu-id="e6d05-141">Here are just a few tasks that your game can complete:</span></span>

-   <span data-ttu-id="e6d05-142">ネットワーク イベントの処理</span><span class="sxs-lookup"><span data-stu-id="e6d05-142">Process network events</span></span>
-   <span data-ttu-id="e6d05-143">AI の更新</span><span class="sxs-lookup"><span data-stu-id="e6d05-143">Update the AI</span></span>
-   <span data-ttu-id="e6d05-144">CPU ベースの物理</span><span class="sxs-lookup"><span data-stu-id="e6d05-144">CPU-based physics</span></span>
-   <span data-ttu-id="e6d05-145">遅延コンテキストのレンダリング (サポートされているデバイス)</span><span class="sxs-lookup"><span data-stu-id="e6d05-145">Deferred-context rendering (on supported devices)</span></span>
-   <span data-ttu-id="e6d05-146">アセットの読み込み</span><span class="sxs-lookup"><span data-stu-id="e6d05-146">Asset loading</span></span>

<span data-ttu-id="e6d05-147">Windows でのマルチスレッド プログラミングについて詳しくは、次の関連トピックをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e6d05-147">For more information about multithreaded programming in Windows, see the following related topics.</span></span>

## <a name="related-topics"></a><span data-ttu-id="e6d05-148">関連トピック</span><span class="sxs-lookup"><span data-stu-id="e6d05-148">Related topics</span></span>


* [<span data-ttu-id="e6d05-149">DirectXLatency のサンプル</span><span class="sxs-lookup"><span data-stu-id="e6d05-149">DirectXLatency sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=317361)
* [**<span data-ttu-id="e6d05-150">IDXGISwapChain2::GetFrameLatencyWaitableObject</span><span class="sxs-lookup"><span data-stu-id="e6d05-150">IDXGISwapChain2::GetFrameLatencyWaitableObject</span></span>**](https://msdn.microsoft.com/library/windows/desktop/dn268309)
* [**<span data-ttu-id="e6d05-151">WaitForSingleObjectEx</span><span class="sxs-lookup"><span data-stu-id="e6d05-151">WaitForSingleObjectEx</span></span>**](https://msdn.microsoft.com/library/windows/desktop/ms687036)
* [**<span data-ttu-id="e6d05-152">Windows.System.Threading</span><span class="sxs-lookup"><span data-stu-id="e6d05-152">Windows.System.Threading</span></span>**](https://msdn.microsoft.com/library/windows/apps/br229642)
* [<span data-ttu-id="e6d05-153">C++ での非同期プログラミング</span><span class="sxs-lookup"><span data-stu-id="e6d05-153">Asynchronous programming in C++</span></span>](https://msdn.microsoft.com/library/windows/apps/mt187334)
* [<span data-ttu-id="e6d05-154">プロセスとスレッド</span><span class="sxs-lookup"><span data-stu-id="e6d05-154">Processes and Threads</span></span>](https://msdn.microsoft.com/library/windows/desktop/ms684841)
* [<span data-ttu-id="e6d05-155">同期</span><span class="sxs-lookup"><span data-stu-id="e6d05-155">Synchronization</span></span>](https://msdn.microsoft.com/library/windows/desktop/ms686353)
* [<span data-ttu-id="e6d05-156">イベント オブジェクトの使用 (Windows)</span><span class="sxs-lookup"><span data-stu-id="e6d05-156">Using Event Objects (Windows)</span></span>](https://msdn.microsoft.com/library/windows/desktop/ms686915)

 

 




