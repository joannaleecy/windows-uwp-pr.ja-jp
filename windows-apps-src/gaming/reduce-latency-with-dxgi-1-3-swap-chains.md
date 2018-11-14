---
author: mtoepke
title: DXGI 1.3 スワップ チェーンによる遅延の減少
description: DXGI 1.3 を使って、スワップ チェーンが新しいフレームのレンダリング開始の適切な時間を通知するまで待機することで、実質的なフレーム待機時間を削減します。
ms.assetid: c99b97ed-a757-879f-3d55-7ed77133f6ce
ms.author: mtoepke
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, 待機時間, DXGI, スワップ チェーン, DirectX
ms.localizationpriority: medium
ms.openlocfilehash: 51a1dd6d7f1c39d82201d3b9741276a54e4c06a8
ms.sourcegitcommit: f2c9a050a9137a473f28b613968d5782866142c6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/09/2018
ms.locfileid: "6254504"
---
# <a name="reduce-latency-with-dxgi-13-swap-chains"></a>DXGI 1.3 スワップ チェーンによる遅延の減少



DXGI 1.3 を使って、スワップ チェーンが新しいフレームのレンダリング開始の適切な時間を通知するまで待機することで、実質的なフレーム待機時間を削減します。 ゲームでは一般的に、プレイヤーの入力を受け取った時点からゲームがその入力に応答して表示を更新するまでの待機時間を、可能な限り短縮する必要があります。 このトピックでは、Direct3D 11.2 以降で利用できるようになった、ゲーム内の実際のフレーム待機時間を最小化する手法について説明します。

## <a name="how-does-waiting-on-the-back-buffer-reduce-latency"></a>バック バッファーでの待機によって待機時間を減らす方法


フリップ モデルのスワップ チェーンでは、ゲームが [**IDXGISwapChain::Present**](https://msdn.microsoft.com/library/windows/desktop/bb174576) を呼び出すたびにバック バッファーの "フリップ" がキューに入れられます。 レンダリング ループによって Present() が呼び出されると、前のフレームの表示が完了するまでスレッドがブロックされ、新しいフレームが実際に表示されるまでキューに入れておくための領域を確保します。 これにより、ゲームによってフレームを描画した時点から、そのフレームが表示できるようになる時点まで、追加の待機時間が生まれます。 多くの場合、各フレームのレンダリングが開始されてから表示されるまでの間にほぼ 1 フレーム分の追加待機時間が常に発生するという、安定した状態に到達します。 新しいフレームを許可する準備が整うまで待機してから、現在のデータに基づいてフレームをレンダリングし、即座にキューに入れることをお勧めします。

[**DXGI\_SWAP\_CHAIN\_FLAG\_FRAME\_LATENCY\_WAITABLE\_OBJECT**](https://msdn.microsoft.com/library/windows/desktop/bb173076) フラグを使って待機可能スワップ チェーンを作成します。 この方法で作成されたスワップ チェーンでは、システムが実際に新しいフレームを許可する準備ができたことをレンダリング ループに通知できます。 これにより、現在のデータに基づいてレンダリングした結果を即座に現在のキューに入れることができます。

## <a name="step-1-create-a-waitable-swap-chain"></a>手順 1: 待機可能スワップ チェーンを作成する


[**CreateSwapChainForCoreWindow**](https://msdn.microsoft.com/library/windows/desktop/hh404559) を呼び出すときに [**DXGI\_SWAP\_CHAIN\_FLAG\_FRAME\_LATENCY\_WAITABLE\_OBJECT**](https://msdn.microsoft.com/library/windows/desktop/bb173076) フラグを指定します。

```cpp
swapChainDesc.Flags = DXGI_SWAP_CHAIN_FLAG_FRAME_LATENCY_WAITABLE_OBJECT; // Enable GetFrameLatencyWaitableObject().
```

> **注:** いくつかのフラグとこのフラグを追加できませんまたは[**ResizeBuffers**](https://msdn.microsoft.com/library/windows/desktop/bb174577)を使用して削除します。 このフラグの設定が、スワップ チェーンが作成された時点の設定と異なっている場合、DXGI はエラー コードを返します。

 

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

## <a name="step-2-set-the-frame-latency"></a>手順 2: フレーム待機時間を設定する


フレーム待機時間は、[**IDXGIDevice1::SetMaximumFrameLatency**](https://msdn.microsoft.com/library/windows/desktop/ff471334) を呼び出すのではなく [**IDXGISwapChain2::SetMaximumFrameLatency**](https://msdn.microsoft.com/library/windows/desktop/dn268313) API を使って設定します。

既定では、待機可能スワップ チェーンのフレーム待機時間が 1 に設定されており、最小限の待機時間になっていますが、これにより CPU-GPU 並列処理も削減されます。 60 FPS を達成するために CPU-GPU 並列処理を増やす必要がある場合、つまり CPU と GPU それぞれの 1 フレーム分の処理レンダリング処理時間を 16.7 ミリ秒未満に抑えたが、CPU と GPU を合わせた合計処理時間が 16.7 ミリ秒を超えている場合は、フレームの待機時間を 2 に設定します。 これにより、前のフレームの間に CPU がキューに入れた作業を GPU で処理できます。同時に、CPU はそれと関係なく現在のフレームのレンダリング コマンドを送信できます。

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

## <a name="step-3-get-the-waitable-object-from-the-swap-chain"></a>手順 3: スワップ チェーンから待機可能オブジェクトを取得する


[**IDXGISwapChain2::GetFrameLatencyWaitableObject**](https://msdn.microsoft.com/library/windows/desktop/dn268309) を呼び出して待機ハンドルを取得します。 待機ハンドルは、待機可能オブジェクトへのポインターです。 レンダリング ループで使うために、このハンドルを格納します。

```cpp
// Get the frame latency waitable object, which is used by the WaitOnSwapChain method. This
// requires that swap chain be created with the DXGI_SWAP_CHAIN_FLAG_FRAME_LATENCY_WAITABLE_OBJECT
// flag.
m_frameLatencyWaitableObject = swapChain2->GetFrameLatencyWaitableObject();
```

## <a name="step-4-wait-before-rendering-each-frame"></a>手順 4: 各フレームをレンダリングする前に待機する


レンダリング ループでは、各フレームのレンダリングを開始する前に、待機可能オブジェクトを利用してスワップ チェーンによる通知を待機する必要があります。 これには、スワップ チェーンでレンダリングされた最初のフレームが含まれます。 [**WaitForSingleObjectEx**](https://msdn.microsoft.com/library/windows/desktop/ms687036) を使い、手順 2. で取得した待機ハンドルを提供して各フレームの開始を通知します。

次の例は、DirectXLatency サンプルからのレンダー ループを示しています。

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

次の例は、DirectXLatency サンプルからの WaitForSingleObjectEx 呼び出しを示しています。

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

## <a name="what-should-my-game-do-while-it-waits-for-the-swap-chain-to-present"></a>ゲームがスワップ チェーンの表示を待機する間に実行する必要のあるタスク


レンダー ループをブロックするタスクがゲームに存在しない場合、スワップ チェーンが表示されるまで待機することが消費電力の削減 (モバイル デバイスで特に重要) に有効な場合があります。 レンダー ループをブロックするタスクが存在する場合は、スワップ チェーンの表示を待機している間にマルチスレッドを使って作業を完了できます。 次に、ゲームで実行できるタスクのごく一部を示します。

-   ネットワーク イベントの処理
-   AI の更新
-   CPU ベースの物理
-   遅延コンテキストのレンダリング (サポートされているデバイス)
-   アセットの読み込み

Windows でのマルチスレッド プログラミングについて詳しくは、次の関連トピックをご覧ください。

## <a name="related-topics"></a>関連トピック


* [DirectXLatency のサンプル](http://go.microsoft.com/fwlink/p/?LinkID=317361)
* [**IDXGISwapChain2::GetFrameLatencyWaitableObject**](https://msdn.microsoft.com/library/windows/desktop/dn268309)
* [**WaitForSingleObjectEx**](https://msdn.microsoft.com/library/windows/desktop/ms687036)
* [**Windows.System.Threading**](https://msdn.microsoft.com/library/windows/apps/br229642)
* [C++ での非同期プログラミング](https://msdn.microsoft.com/library/windows/apps/mt187334)
* [プロセスとスレッド](https://msdn.microsoft.com/library/windows/desktop/ms684841)
* [同期](https://msdn.microsoft.com/library/windows/desktop/ms686353)
* [イベント オブジェクトの使用 (Windows)](https://msdn.microsoft.com/library/windows/desktop/ms686915)

 

 




