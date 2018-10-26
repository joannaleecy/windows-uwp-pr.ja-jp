---
author: mtoepke
title: DirectX リソースの設定と画像の表示
description: ここでは、Direct3D デバイス、スワップ チェーン、レンダー ターゲット ビューを作成し、レンダリングされた画像をディスプレイに表示する方法について説明します。
ms.assetid: d54d96fe-3522-4acb-35f4-bb11c3a5b064
ms.author: mtoepke
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10、UWP、ゲーム、DirectX、リソース、画像
ms.localizationpriority: medium
ms.openlocfilehash: 24fd038bdd447491da43e5d5803445d00147ba2d
ms.sourcegitcommit: 6cc275f2151f78db40c11ace381ee2d35f0155f9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5567707"
---
# <a name="set-up-directx-resources-and-display-an-image"></a>DirectX リソースの設定と画像の表示



ここでは、Direct3D デバイス、スワップ チェーン、レンダー ターゲット ビューを作成し、レンダリングされた画像をディスプレイに表示する方法について説明します。

**目的:** C++ ユニバーサル Windows プラットフォーム (UWP) アプリで DirectX リソースを設定し、単色を表示する。

## <a name="prerequisites"></a>前提条件


C++ に習熟していることを前提としています。 また、グラフィックス プログラミングの概念に対する基礎的な知識も必要となります。

**完了までの時間:** 20 分。

## <a name="instructions"></a>手順

### <a name="1-declaring-direct3d-interface-variables-with-comptr"></a>1. ComPtr を使った Direct3D インターフェイス変数の宣言

Windows ランタイム C++ テンプレート ライブラリ (WRL) の ComPtr [スマート ポインター](https://msdn.microsoft.com/library/windows/apps/hh279674.aspx) テンプレートを使って Direct3D インターフェイス変数を宣言して、これらの変数の有効期間を例外安全な方法で管理できるようにします。 これらの変数を使って [**ComPtr クラス**](https://msdn.microsoft.com/library/windows/apps/br244983.aspx) とそのメンバーにアクセスすることができます。 例:

```cpp
    ComPtr<ID3D11RenderTargetView> m_renderTargetView;
    m_d3dDeviceContext->OMSetRenderTargets(
        1,
        m_renderTargetView.GetAddressOf(),
        nullptr // Use no depth stencil.
        );
```

ComPtr を使って [**ID3D11RenderTargetView**](https://msdn.microsoft.com/library/windows/desktop/ff476582) を宣言すると、ComPtr の **GetAddressOf** メソッドを使って **ID3D11RenderTargetView** (\*\*ID3D11RenderTargetView) へのポインターのアドレスを取得し、[**ID3D11DeviceContext::OMSetRenderTargets**](https://msdn.microsoft.com/library/windows/desktop/ff476464) に渡すことができます。 **OMSetRenderTargets** は、レンダー ターゲットを [output-merger stage](https://msdn.microsoft.com/library/windows/desktop/bb205120) にバインドして、レンダー ターゲットを出力ターゲットとして指定します。

サンプル アプリを起動すると、初期化と読み込みが行われ、実行準備が整います。

### <a name="2-creating-the-direct3d-device"></a>2. Direct3D デバイスの作成

Direct3D API を使ってシーンをレンダリングするには、先にディスプレイ アダプターを表す Direct3D デバイスを作成する必要があります。 Direct3D デバイスを作成するために、[**D3D11CreateDevice**](https://msdn.microsoft.com/library/windows/desktop/ff476082) 関数を呼び出します。 [**D3D\_FEATURE\_LEVEL**](https://msdn.microsoft.com/library/windows/desktop/ff476329) 値の配列でレベル 9.1 から 11.1 を指定します。 Direct3D はこの配列を順に見ていき、サポートされる最高の機能レベルを返します。 そのため、利用可能な最高レベルの機能レベルを取得するため、**D3D\_FEATURE\_LEVEL** 配列エントリを最高レベルから最低レベルまで一覧にします。 [**D3D11\_CREATE\_DEVICE\_BGRA\_SUPPORT**](https://msdn.microsoft.com/library/windows/desktop/ff476107#D3D11_CREATE_DEVICE_BGRA_SUPPORT) フラグを *Flags* パラメーターに渡して、Direct3D リソースが Direct2D と相互運用できるようにします。 デバッグ ビルドを使う場合、[**D3D11\_CREATE\_DEVICE\_DEBUG**](https://msdn.microsoft.com/library/windows/desktop/ff476107#D3D11_CREATE_DEVICE_DEBUG) フラグも渡します。 アプリのデバッグについて詳しくは、「[デバッグ レイヤーを使ったアプリのデバッグ](https://msdn.microsoft.com/library/windows/desktop/jj200584)」をご覧ください。

[**D3D11CreateDevice**](https://msdn.microsoft.com/library/windows/desktop/ff476082) から返される Direct3D 11 デバイスとデバイス コンテキストを照会して、Direct3D 11.1 デバイス ([**ID3D11Device1**](https://msdn.microsoft.com/library/windows/desktop/hh404575)) とデバイス コンテキスト ([**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598)) を取得します。

```cpp
        // First, create the Direct3D device.

        // This flag is required in order to enable compatibility with Direct2D.
        UINT creationFlags = D3D11_CREATE_DEVICE_BGRA_SUPPORT;

#if defined(_DEBUG)
        // If the project is in a debug build, enable debugging via SDK Layers with this flag.
        creationFlags |= D3D11_CREATE_DEVICE_DEBUG;
#endif

        // This array defines the ordering of feature levels that D3D should attempt to create.
        D3D_FEATURE_LEVEL featureLevels[] =
        {
            D3D_FEATURE_LEVEL_11_1,
            D3D_FEATURE_LEVEL_11_0,
            D3D_FEATURE_LEVEL_10_1,
            D3D_FEATURE_LEVEL_10_0,
            D3D_FEATURE_LEVEL_9_3,
            D3D_FEATURE_LEVEL_9_1
        };

        ComPtr<ID3D11Device> d3dDevice;
        ComPtr<ID3D11DeviceContext> d3dDeviceContext;
        DX::ThrowIfFailed(
            D3D11CreateDevice(
                nullptr,                    // Specify nullptr to use the default adapter.
                D3D_DRIVER_TYPE_HARDWARE,
                nullptr,                    // leave as nullptr if hardware is used
                creationFlags,              // optionally set debug and Direct2D compatibility flags
                featureLevels,
                ARRAYSIZE(featureLevels),
                D3D11_SDK_VERSION,          // always set this to D3D11_SDK_VERSION
                &d3dDevice,
                nullptr,
                &d3dDeviceContext
                )
            );

        // Retrieve the Direct3D 11.1 interfaces.
        DX::ThrowIfFailed(
            d3dDevice.As(&m_d3dDevice)
            );

        DX::ThrowIfFailed(
            d3dDeviceContext.As(&m_d3dDeviceContext)
            );
```

### <a name="3-creating-the-swap-chain"></a>3. スワップ チェーンの作成

次に、デバイスがレンダリングと表示に使うスワップ チェーンを作成します。 [**DXGI\_SWAP\_CHAIN\_DESC1**](https://msdn.microsoft.com/library/windows/desktop/hh404528) 構造体を宣言して初期化し、スワップ チェーンを記述します。 次に、スワップ チェーンをフリップモデル (つまり [**DXGI\_SWAP\_EFFECT\_FLIP\_SEQUENTIAL**](https://msdn.microsoft.com/library/windows/desktop/bb173077#DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL) 値が **SwapEffect** メンバーに設定されているスワップ チェーン) として設定し、**Format** メンバーを [**DXGI\_FORMAT\_B8G8R8A8\_UNORM**](https://msdn.microsoft.com/library/windows/desktop/bb173059#DXGI_FORMAT_B8G8R8A8_UNORM) に設定します。 **SampleDesc** メンバーが指定する [**DXGI\_SAMPLE\_DESC**](https://msdn.microsoft.com/library/windows/desktop/bb173072) 構造体の **Count** メンバーを 1 に設定し、**DXGI\_SAMPLE\_DESC** の **Quality** メンバーを 0 に設定します。これは、フリップモデルでは複数サンプルのアンチエイリアシング (MSAA) をサポートしていないためです。 **BufferCount** メンバーを 2 に設定して、スワップ チェーンがディスプレイ デバイスを表すフロント バッファーと、レンダー ターゲットとして機能するバック バッファーを使えるようにします。

Direct3D 11.1 デバイスを照会して、ベースとなる DXGI デバイスを取得します。 電力消費を抑えることは、ノート PC やタブレットなどのバッテリー駆動デバイスでは重要です。そのため、DXGI がキューに入れることができるバック バッファー フレームの最大数として 1 を指定して、[**IDXGIDevice1::SetMaximumFrameLatency**](https://msdn.microsoft.com/library/windows/desktop/ff471334) メソッドを呼び出します。 これにより、アプリは垂直ブランクの後でのみレンダリングされるようになります。

最終的にスワップ チェーンを作成するには、DXGI デバイスから親ファクトリを取得する必要があります。 [**IDXGIDevice::GetAdapter**](https://msdn.microsoft.com/library/windows/desktop/bb174531) を呼び出してデバイスのアダプターを取得し、次にアダプターで [**IDXGIObject::GetParent**](https://msdn.microsoft.com/library/windows/desktop/bb174542) を呼び出して親ファクトリ ([**IDXGIFactory2**](https://msdn.microsoft.com/library/windows/desktop/hh404556)) を取得します。 スワップ チェーンを作成するため、スワップ チェーン記述子とアプリのコア ウィンドウを指定して [**IDXGIFactory2::CreateSwapChainForCoreWindow**](https://msdn.microsoft.com/library/windows/desktop/hh404559) を呼び出します。

```cpp
            // If the swap chain does not exist, create it.
            DXGI_SWAP_CHAIN_DESC1 swapChainDesc = {0};

            swapChainDesc.Stereo = false;
            swapChainDesc.BufferUsage = DXGI_USAGE_RENDER_TARGET_OUTPUT;
            swapChainDesc.Scaling = DXGI_SCALING_NONE;
            swapChainDesc.Flags = 0;

            // Use automatic sizing.
            swapChainDesc.Width = 0;
            swapChainDesc.Height = 0;

            // This is the most common swap chain format.
            swapChainDesc.Format = DXGI_FORMAT_B8G8R8A8_UNORM;

            // Don't use multi-sampling.
            swapChainDesc.SampleDesc.Count = 1;
            swapChainDesc.SampleDesc.Quality = 0;

            // Use two buffers to enable the flip effect.
            swapChainDesc.BufferCount = 2;

            // We recommend using this swap effect for all applications.
            swapChainDesc.SwapEffect = DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL;


            // Once the swap chain description is configured, it must be
            // created on the same adapter as the existing D3D Device.

            // First, retrieve the underlying DXGI Device from the D3D Device.
            ComPtr<IDXGIDevice2> dxgiDevice;
            DX::ThrowIfFailed(
                m_d3dDevice.As(&dxgiDevice)
                );

            // Ensure that DXGI does not queue more than one frame at a time. This both reduces
            // latency and ensures that the application will only render after each VSync, minimizing
            // power consumption.
            DX::ThrowIfFailed(
                dxgiDevice->SetMaximumFrameLatency(1)
                );

            // Next, get the parent factory from the DXGI Device.
            ComPtr<IDXGIAdapter> dxgiAdapter;
            DX::ThrowIfFailed(
                dxgiDevice->GetAdapter(&dxgiAdapter)
                );

            ComPtr<IDXGIFactory2> dxgiFactory;
            DX::ThrowIfFailed(
                dxgiAdapter->GetParent(IID_PPV_ARGS(&dxgiFactory))
                );

            // Finally, create the swap chain.
            CoreWindow^ window = m_window.Get();
            DX::ThrowIfFailed(
                dxgiFactory->CreateSwapChainForCoreWindow(
                    m_d3dDevice.Get(),
                    reinterpret_cast<IUnknown*>(window),
                    &swapChainDesc,
                    nullptr, // Allow on all displays.
                    &m_swapChain
                    )
                );
```

### <a name="4-creating-the-render-target-view"></a>4. レンダー ターゲット ビューの作成

グラフィックスをウィンドウにレンダリングするには、レンダー ターゲット ビューを作成する必要があります。 レンダー ターゲット ビューを作成するときには、[**IDXGISwapChain::GetBuffer**](https://msdn.microsoft.com/library/windows/desktop/bb174570) を呼び出してスワップ チェーンのバック バッファーを取得して使います。 バック バッファーを 2D テクスチャ ([**ID3D11Texture2D**](https://msdn.microsoft.com/library/windows/desktop/ff476635)) として指定します。 レンダー ターゲット ビューを作成するため、スワップ チェーンのバック バッファーを指定して [**ID3D11Device::CreateRenderTargetView**](https://msdn.microsoft.com/library/windows/desktop/ff476517) を呼び出します。 コア ウィンドウ全体に描画するように指定する必要があります。そのために、ビュー ポート ([**D3D11\_VIEWPORT**](https://msdn.microsoft.com/library/windows/desktop/ff476260)) をフル サイズのスワップ チェーンのバック バッファーとして指定します。 次に、このビュー ポートを [**ID3D11DeviceContext::RSSetViewports**](https://msdn.microsoft.com/library/windows/desktop/ff476480) への呼び出しで使い、ビュー ポートをパイプラインの[ラスタライザー ステージ](https://msdn.microsoft.com/library/windows/desktop/bb205125)にバインドします。 ラスタライザー ステージは、ベクター情報をラスター画像に変換します。 この場合は単色を表示するだけなので、変換は必要ありません。

```cpp
        // Once the swap chain is created, create a render target view.  This will
        // allow Direct3D to render graphics to the window.

        ComPtr<ID3D11Texture2D> backBuffer;
        DX::ThrowIfFailed(
            m_swapChain->GetBuffer(0, IID_PPV_ARGS(&backBuffer))
            );

        DX::ThrowIfFailed(
            m_d3dDevice->CreateRenderTargetView(
                backBuffer.Get(),
                nullptr,
                &m_renderTargetView
                )
            );


        // After the render target view is created, specify that the viewport,
        // which describes what portion of the window to draw to, should cover
        // the entire window.

        D3D11_TEXTURE2D_DESC backBufferDesc = {0};
        backBuffer->GetDesc(&backBufferDesc);

        D3D11_VIEWPORT viewport;
        viewport.TopLeftX = 0.0f;
        viewport.TopLeftY = 0.0f;
        viewport.Width = static_cast<float>(backBufferDesc.Width);
        viewport.Height = static_cast<float>(backBufferDesc.Height);
        viewport.MinDepth = D3D11_MIN_DEPTH;
        viewport.MaxDepth = D3D11_MAX_DEPTH;

        m_d3dDeviceContext->RSSetViewports(1, &viewport);
```

### <a name="5-presenting-the-rendered-image"></a>5. レンダリングされた画像の表示

シーンをレンダリングして表示し続けるために、無限ループを使います。

このループでは、次の呼び出しを実行します。

1.  [**ID3D11DeviceContext::OMSetRenderTargets**](https://msdn.microsoft.com/library/windows/desktop/ff476464)レンダー ターゲットを出力ターゲットに指定します。
2.  [**ID3D11DeviceContext::ClearRenderTargetView**](https://msdn.microsoft.com/library/windows/desktop/ff476388) レンダー ターゲットを単色にクリアします。
3.  [**IDXGISwapChain::Present**](https://msdn.microsoft.com/library/windows/desktop/bb174576)レンダリングされた画像をウィンドウに表示します。

この呼び出しでは前に最大フレーム待機時間を 1 に設定しているため、Windows は一般にレンダー ループの速度を画面のリフレッシュ レート (通常は約 60 Hz) まで下げます。 レンダー ループの速度を下げるために、アプリが [**Present**](https://msdn.microsoft.com/library/windows/desktop/bb174576) を呼び出したときにアプリをスリープ状態にします。 画面が更新されるまでアプリをスリープ状態にします。

```cpp
        // Enter the render loop.  Note that UWP apps should never exit.
        while (true)
        {
            // Process events incoming to the window.
            m_window->Dispatcher->ProcessEvents(CoreProcessEventsOption::ProcessAllIfPresent);

            // Specify the render target we created as the output target.
            m_d3dDeviceContext->OMSetRenderTargets(
                1,
                m_renderTargetView.GetAddressOf(),
                nullptr // Use no depth stencil.
                );

            // Clear the render target to a solid color.
            const float clearColor[4] = { 0.071f, 0.04f, 0.561f, 1.0f };
            m_d3dDeviceContext->ClearRenderTargetView(
                m_renderTargetView.Get(),
                clearColor
                );

            // Present the rendered image to the window.  Because the maximum frame latency is set to 1,
            // the render loop will generally be throttled to the screen refresh rate, typically around
            // 60 Hz, by sleeping the application on Present until the screen is refreshed.
            DX::ThrowIfFailed(
                m_swapChain->Present(1, 0)
                );
        }
```

### <a name="6-resizing-the-app-window-and-the-swap-chains-buffer"></a>6. アプリのウィンドウとスワップ チェーンのバッファーのサイズ変更

アプリ ウィンドウのサイズが変化すると、アプリはスワップ チェーンのバッファーのサイズを変更して、レンダー ターゲット ビューを再作成し、サイズが変更されたレンダリング済み画像を表示する必要があります。 スワップ チェーンのバッファーのサイズを変更するために、[**IDXGISwapChain::ResizeBuffers**](https://msdn.microsoft.com/library/windows/desktop/bb174577) を呼び出します。 この呼び出しでは、バッファーの数やバッファーの形式を変更しません (*BufferCount* パラメーターは 2、*NewFormat* パラメーターは [**DXGI\_FORMAT\_B8G8R8A8\_UNORM**](https://msdn.microsoft.com/library/windows/desktop/bb173059#DXGI_FORMAT_B8G8R8A8_UNORM))。 スワップ チェーンのバック バッファーのサイズは、サイズ変更されたウィンドウと同じサイズに設定します。 スワップ チェーンのバッファーのサイズを変更した後、新しいレンダー ターゲットを作成し、新しくレンダリングされた画像をアプリの初期化時と同様に表示します。

```cpp
            // If the swap chain already exists, resize it.
            DX::ThrowIfFailed(
                m_swapChain->ResizeBuffers(
                    2,
                    0,
                    0,
                    DXGI_FORMAT_B8G8R8A8_UNORM,
                    0
                    )
                );
```

## <a name="summary-and-next-steps"></a>要約と次のステップ


Direct3D デバイス、スワップ チェーン、レンダー ターゲット ビューを作成し、レンダリングされた画像がディスプレイに表示されるようになりました。

次は、ディスプレイに三角形を描画します。

[シェーダーの作成とプリミティブの描画](creating-shaders-and-drawing-primitives.md)

 

 




