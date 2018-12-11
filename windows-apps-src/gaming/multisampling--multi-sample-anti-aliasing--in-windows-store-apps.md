---
title: ユニバーサル Windows プラットフォーム (UWP) アプリのマルチサンプリング
description: Direct3D を使って構築されたユニバーサル Windows プラットフォーム (UWP) アプリでマルチサンプリングを使う方法について説明します。
ms.assetid: 1cd482b8-32ff-1eb0-4c91-83eb52f08484
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, マルチサンプリング, Direct3D
ms.localizationpriority: medium
ms.openlocfilehash: 0c1634af8589a97f5070ff85909fe12ab16bf8d6
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8924918"
---
# <a name="span-iddevgamingmultisamplingmulti-sampleantialiasinginwindowsstoreappsspan-multisampling-in-universal-windows-platform-uwp-apps"></a><span id="dev_gaming.multisampling__multi-sample_anti_aliasing__in_windows_store_apps"></span>ユニバーサル Windows プラットフォーム (UWP) アプリのマルチサンプリング



Direct3D を使って構築されたユニバーサル Windows プラットフォーム (UWP) アプリでマルチサンプリングを使う方法について説明します。 マルチサンプリングとは、マルチサンプル アンチエイリアシングとも呼ばれ、エッジを滑らかに描画するために使用されるグラフィックス技法です。 最終的なレンダー ターゲットの実際のピクセルよりも多くのピクセルを描画し、その値を平均して、特定のピクセルで "部分的" エッジの外観を維持するというしくみです。 Direct3D で実際にマルチサンプリングがどのように働くかについて詳しくは、「[マルチサンプル アンチエイリアシング ラスタライズ規則](https://msdn.microsoft.com/library/windows/desktop/cc627092#Multisample)」をご覧ください。

## <a name="multisampling-and-the-flip-model-swap-chain"></a>マルチサンプリングとフリップ モデル スワップ チェーン


DirectX を使う UWP アプリでは、フリップ モデル スワップ チェーンを使う必要があります。 フリップ モデル スワップ チェーンは、マルチサンプリングを直接サポートするわけではなく、方法は異なりますが、マルチサンプリングされたレンダー ターゲット ビューにシーンをレンダリングした後、マルチサンプリングされたレンダー ターゲットをバック バッファーに解決して表示することで、マルチサンプリングを適用することができます。 この記事では、UWP アプリにマルチサンプリングを追加するための手順を説明します。

### <a name="how-to-use-multisampling"></a>マルチサンプリングを使う方法

Direct3D 機能レベルは、特定の最小サンプル数機能のサポートを保証し、マルチサンプリングをサポートする特定のバッファー形式が使用できることを保証します。 グラフィックス デバイスは、多くの場合、最小限必要なものよりも広い範囲の形式とサンプル数をサポートしています。 マルチサンプリング サポートは、特定の DXGI 形式を使うマルチサンプリング機能がサポートされているか確認し、サポートされている形式ごとに使うことのできるサンプル数を確認することで、実行時に判断できます。

1.  [**ID3D11Device::CheckFeatureSupport**](https://msdn.microsoft.com/library/windows/desktop/ff476497) を呼び出して、どの DXGI 形式をマルチサンプリングで使うことができるか確認します。 ゲームで使うことのできるレンダー ターゲット形式を指定します。 レンダー ターゲットと解決ターゲットは、どちらも同じ形式を使う必要があるため、[**D3D11\_FORMAT\_SUPPORT\_MULTISAMPLE\_RENDERTARGET**](https://msdn.microsoft.com/library/windows/desktop/ff476134) と **D3D11\_FORMAT\_SUPPORT\_MULTISAMPLE\_RESOLVE** の両方を確認します。

    **機能レベル 9:** 機能レベル 9 のデバイス[のマルチ サンプリングされたレンダー ターゲット形式のサポートを保証](https://msdn.microsoft.com/library/windows/desktop/ff471324#MultiSample_RenderTarget)が、マルチ サンプル解決ターゲットのサポートは保証されません。 そこで、このトピックで説明するマルチサンプリング技法を使おうとする前に、この確認が必要になります。

    次のコードは、すべての DXGI\_FORMAT 値についてマルチサンプリング サポートを確認します。

    ```cpp
    // Determine the format support for multisampling.
    for (UINT i = 1; i < DXGI_FORMAT_MAX; i++)
    {
        DXGI_FORMAT inFormat = safe_cast<DXGI_FORMAT>(i);
        UINT formatSupport = 0;
        HRESULT hr = m_d3dDevice->CheckFormatSupport(inFormat, &formatSupport);

        if ((formatSupport & D3D11_FORMAT_SUPPORT_MULTISAMPLE_RESOLVE) &&
            (formatSupport & D3D11_FORMAT_SUPPORT_MULTISAMPLE_RENDERTARGET)
            )
        {
            m_supportInfo->SetFormatSupport(i, true);
        }
        else
        {
            m_supportInfo->SetFormatSupport(i, false);
        }
    }
    ```

2.  サポートされている形式ごとに、[**ID3D11Device::CheckMultisampleQualityLevels**](https://msdn.microsoft.com/library/windows/desktop/ff476499) を呼び出して、サンプル数のサポートを照会します。

    次のコードは、サポートされている DXGI 形式についてサンプル サイズのサポートを確認します。

    ```cpp
    // Find available sample sizes for each supported format.
    for (unsigned int i = 0; i < DXGI_FORMAT_MAX; i++)
    {
        for (unsigned int j = 1; j < MAX_SAMPLES_CHECK; j++)
        {
            UINT numQualityFlags;

            HRESULT test = m_d3dDevice->CheckMultisampleQualityLevels(
                (DXGI_FORMAT) i,
                j,
                &numQualityFlags
                );

            if (SUCCEEDED(test) && (numQualityFlags > 0))
            {
                m_supportInfo->SetSampleSize(i, j, 1);
                m_supportInfo->SetQualityFlagsAt(i, j, numQualityFlags);
            }
        }
    }
    ```

    > **注:** 使用[**id3d11device 2::checkmultisamplequalitylevels1**](https://msdn.microsoft.com/library/windows/desktop/dn280494)代わりのマルチ サンプル サポートを確認する必要がある場合は、タイル リソース バッファー。

     

3.  目的のサンプル数を使って、バッファーとレンダー ターゲット ビューを作成します。 スワップ チェーンと同じ DXGI\_FORMAT、幅、高さを使いますが、1 より大きなサンプル数を指定してマルチサンプリングされたテクスチャ ディメンション (たとえば、**D3D11\_RTV\_DIMENSION\_TEXTURE2DMS**) を使います。 必要な場合、マルチサンプリングに最適な新しい設定を使ってスワップ チェーンを再作成することもできます。

    次のコードでは、マルチサンプリングされたレンダー ターゲットが作成されます。

    ```cpp
    float widthMulti = m_d3dRenderTargetSize.Width;
    float heightMulti = m_d3dRenderTargetSize.Height;

    D3D11_TEXTURE2D_DESC offScreenSurfaceDesc;
    ZeroMemory(&offScreenSurfaceDesc, sizeof(D3D11_TEXTURE2D_DESC));

    offScreenSurfaceDesc.Format = DXGI_FORMAT_B8G8R8A8_UNORM;
    offScreenSurfaceDesc.Width = static_cast<UINT>(widthMulti);
    offScreenSurfaceDesc.Height = static_cast<UINT>(heightMulti);
    offScreenSurfaceDesc.BindFlags = D3D11_BIND_RENDER_TARGET;
    offScreenSurfaceDesc.MipLevels = 1;
    offScreenSurfaceDesc.ArraySize = 1;
    offScreenSurfaceDesc.SampleDesc.Count = m_sampleSize;
    offScreenSurfaceDesc.SampleDesc.Quality = m_qualityFlags;

    // Create a surface that's multisampled.
    DX::ThrowIfFailed(
        m_d3dDevice->CreateTexture2D(
        &offScreenSurfaceDesc,
        nullptr,
        &m_offScreenSurface)
        );

    // Create a render target view. 
    CD3D11_RENDER_TARGET_VIEW_DESC renderTargetViewDesc(D3D11_RTV_DIMENSION_TEXTURE2DMS);
    DX::ThrowIfFailed(
        m_d3dDevice->CreateRenderTargetView(
        m_offScreenSurface.Get(),
        &renderTargetViewDesc,
        &m_d3dRenderTargetView
        )
        );
    ```

4.  深度バッファーは、マルチサンプリングされたレンダー ターゲットと一致する、同じ幅、高さ、サンプル数、テクスチャ ディメンションを待つ必要があります。

    次のコードでは、マルチサンプリングされた深度バッファーが作成されます。

    ```cpp
    // Create a depth stencil view for use with 3D rendering if needed.
    CD3D11_TEXTURE2D_DESC depthStencilDesc(
        DXGI_FORMAT_D24_UNORM_S8_UINT,
        static_cast<UINT>(widthMulti),
        static_cast<UINT>(heightMulti),
        1, // This depth stencil view has only one texture.
        1, // Use a single mipmap level.
        D3D11_BIND_DEPTH_STENCIL,
        D3D11_USAGE_DEFAULT,
        0,
        m_sampleSize,
        m_qualityFlags
        );

    ComPtr<ID3D11Texture2D> depthStencil;
    DX::ThrowIfFailed(
        m_d3dDevice->CreateTexture2D(
        &depthStencilDesc,
        nullptr,
        &depthStencil
        )
        );

    CD3D11_DEPTH_STENCIL_VIEW_DESC depthStencilViewDesc(D3D11_DSV_DIMENSION_TEXTURE2DMS);
    DX::ThrowIfFailed(
        m_d3dDevice->CreateDepthStencilView(
        depthStencil.Get(),
        &depthStencilViewDesc,
        &m_d3dDepthStencilView
        )
        );
    ```

5.  ここでビューボートを作成します。ビューポートの幅と高さもレンダー ターゲットと一致している必要があるためです。

    次のコードでは、ビューポートが作成されます。

    ```cpp
    // Set the 3D rendering viewport to target the entire window.
    m_screenViewport = CD3D11_VIEWPORT(
        0.0f,
        0.0f,
        widthMulti / m_scalingFactor,
        heightMulti / m_scalingFactor
        );

    m_d3dContext->RSSetViewports(1, &m_screenViewport);
    ```

6.  マルチサンプリングされたレンダー ターゲットに各フレームをレンダリングします。 レンダリングが完了したら、フレームを表示する前に [**ID3D11DeviceContext::ResolveSubresource**](https://msdn.microsoft.com/library/windows/desktop/ff476474) を呼び出します。 これにより Direct3D はマルチサンプリング操作を実行し、表示する各ピクセルの値を計算して、結果をバック バッファーに配置します。 バック バッファーには最終的なアンチエイリアシングされた画像が格納され、表示できるようになります。

    次のコードは、フレームを表示する前に、サブリソースを解決します。

    ```cpp
    if (m_sampleSize > 1)
    {
        unsigned int sub = D3D11CalcSubresource(0, 0, 1);

        m_d3dContext->ResolveSubresource(
            m_backBuffer.Get(),
            sub,
            m_offScreenSurface.Get(),
            sub,
            DXGI_FORMAT_B8G8R8A8_UNORM
            );
    }

    // The first argument instructs DXGI to block until VSync, putting the application
    // to sleep until the next VSync. This ensures that we don't waste any cycles rendering
    // frames that will never be displayed to the screen.
    hr = m_swapChain->Present(1, 0);
    ```

 

 




