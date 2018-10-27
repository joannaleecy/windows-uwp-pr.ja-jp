---
author: mtoepke
title: ユニバーサル Windows プラットフォーム (UWP) アプリのマルチサンプリング
description: Direct3D を使って構築されたユニバーサル Windows プラットフォーム (UWP) アプリでマルチサンプリングを使う方法について説明します。
ms.assetid: 1cd482b8-32ff-1eb0-4c91-83eb52f08484
ms.author: mtoepke
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, マルチサンプリング, Direct3D
ms.localizationpriority: medium
ms.openlocfilehash: 7b967ae1709849bbe5bc944b00d9e30f22052aeb
ms.sourcegitcommit: 086001cffaf436e6e4324761d59bcc5e598c15ea
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/27/2018
ms.locfileid: "5694395"
---
# <a name="span-iddevgamingmultisamplingmulti-sampleantialiasinginwindowsstoreappsspan-multisampling-in-universal-windows-platform-uwp-apps"></a><span data-ttu-id="864f8-104"><span id="dev_gaming.multisampling__multi-sample_anti_aliasing__in_windows_store_apps"></span>ユニバーサル Windows プラットフォーム (UWP) アプリのマルチサンプリング</span><span class="sxs-lookup"><span data-stu-id="864f8-104"><span id="dev_gaming.multisampling__multi-sample_anti_aliasing__in_windows_store_apps"></span> Multisampling in Universal Windows Platform (UWP) apps</span></span>



<span data-ttu-id="864f8-105">Direct3D を使って構築されたユニバーサル Windows プラットフォーム (UWP) アプリでマルチサンプリングを使う方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="864f8-105">Learn how to use multisampling in Universal Windows Platform (UWP) apps built with Direct3D.</span></span> <span data-ttu-id="864f8-106">マルチサンプリングとは、マルチサンプル アンチエイリアシングとも呼ばれ、エッジを滑らかに描画するために使用されるグラフィックス技法です。</span><span class="sxs-lookup"><span data-stu-id="864f8-106">Multisampling, also known as multi-sample antialiasing, is a graphics technique used to reduce the appearance of aliased edges.</span></span> <span data-ttu-id="864f8-107">最終的なレンダー ターゲットの実際のピクセルよりも多くのピクセルを描画し、その値を平均して、特定のピクセルで "部分的" エッジの外観を維持するというしくみです。</span><span class="sxs-lookup"><span data-stu-id="864f8-107">It works by drawing more pixels than are actually in the final render target, then averaging values to maintain the appearance of a "partial" edge in certain pixels.</span></span> <span data-ttu-id="864f8-108">Direct3D で実際にマルチサンプリングがどのように働くかについて詳しくは、「[マルチサンプル アンチエイリアシング ラスタライズ規則](https://msdn.microsoft.com/library/windows/desktop/cc627092#Multisample)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="864f8-108">For a detailed description of how multisampling actually works in Direct3D, see [Multisample Anti-Aliasing Rasterization Rules](https://msdn.microsoft.com/library/windows/desktop/cc627092#Multisample).</span></span>

## <a name="multisampling-and-the-flip-model-swap-chain"></a><span data-ttu-id="864f8-109">マルチサンプリングとフリップ モデル スワップ チェーン</span><span class="sxs-lookup"><span data-stu-id="864f8-109">Multisampling and the flip model swap chain</span></span>


<span data-ttu-id="864f8-110">DirectX を使う UWP アプリでは、フリップ モデル スワップ チェーンを使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="864f8-110">UWP apps that use DirectX must use flip model swap chains.</span></span> <span data-ttu-id="864f8-111">フリップ モデル スワップ チェーンは、マルチサンプリングを直接サポートするわけではなく、方法は異なりますが、マルチサンプリングされたレンダー ターゲット ビューにシーンをレンダリングした後、マルチサンプリングされたレンダー ターゲットをバック バッファーに解決して表示することで、マルチサンプリングを適用することができます。</span><span class="sxs-lookup"><span data-stu-id="864f8-111">Flip model swap chains don't support multisampling directly, but multisampling can still be applied in a different way by rendering the scene to a multisampled render target view, and then resolving the multisampled render target to the back buffer before presenting.</span></span> <span data-ttu-id="864f8-112">この記事では、UWP アプリにマルチサンプリングを追加するための手順を説明します。</span><span class="sxs-lookup"><span data-stu-id="864f8-112">This article explains the steps required to add multisampling to your UWP app.</span></span>

### <a name="how-to-use-multisampling"></a><span data-ttu-id="864f8-113">マルチサンプリングを使う方法</span><span class="sxs-lookup"><span data-stu-id="864f8-113">How to use multisampling</span></span>

<span data-ttu-id="864f8-114">Direct3D 機能レベルは、特定の最小サンプル数機能のサポートを保証し、マルチサンプリングをサポートする特定のバッファー形式が使用できることを保証します。</span><span class="sxs-lookup"><span data-stu-id="864f8-114">Direct3D feature levels guarantee support for specific, minimum sample count capabilities, and guarantee certain buffer formats will be available that support multisampling.</span></span> <span data-ttu-id="864f8-115">グラフィックス デバイスは、多くの場合、最小限必要なものよりも広い範囲の形式とサンプル数をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="864f8-115">Graphics devices often support a wider range of formats and sample counts than the minimum required.</span></span> <span data-ttu-id="864f8-116">マルチサンプリング サポートは、特定の DXGI 形式を使うマルチサンプリング機能がサポートされているか確認し、サポートされている形式ごとに使うことのできるサンプル数を確認することで、実行時に判断できます。</span><span class="sxs-lookup"><span data-stu-id="864f8-116">Multisampling support can be determined at run-time by checking feature support for multisampling with specific DXGI formats, and then checking the sample counts you can use with each supported format.</span></span>

1.  <span data-ttu-id="864f8-117">[**ID3D11Device::CheckFeatureSupport**](https://msdn.microsoft.com/library/windows/desktop/ff476497) を呼び出して、どの DXGI 形式をマルチサンプリングで使うことができるか確認します。</span><span class="sxs-lookup"><span data-stu-id="864f8-117">Call [**ID3D11Device::CheckFeatureSupport**](https://msdn.microsoft.com/library/windows/desktop/ff476497) to find out which DXGI formats can be used with multisampling.</span></span> <span data-ttu-id="864f8-118">ゲームで使うことのできるレンダー ターゲット形式を指定します。</span><span class="sxs-lookup"><span data-stu-id="864f8-118">Supply the render target formats your game can use.</span></span> <span data-ttu-id="864f8-119">レンダー ターゲットと解決ターゲットは、どちらも同じ形式を使う必要があるため、[**D3D11\_FORMAT\_SUPPORT\_MULTISAMPLE\_RENDERTARGET**](https://msdn.microsoft.com/library/windows/desktop/ff476134) と **D3D11\_FORMAT\_SUPPORT\_MULTISAMPLE\_RESOLVE** の両方を確認します。</span><span class="sxs-lookup"><span data-stu-id="864f8-119">Both the render target and resolve target must use the same format, so check for both [**D3D11\_FORMAT\_SUPPORT\_MULTISAMPLE\_RENDERTARGET**](https://msdn.microsoft.com/library/windows/desktop/ff476134) and **D3D11\_FORMAT\_SUPPORT\_MULTISAMPLE\_RESOLVE**.</span></span>

    <span data-ttu-id="864f8-120">**機能レベル 9:** 機能レベル 9 のデバイス[のマルチ サンプリングされたレンダー ターゲット形式のサポートを保証](https://msdn.microsoft.com/library/windows/desktop/ff471324#MultiSample_RenderTarget)が、マルチ サンプル解決ターゲットのサポートは保証されません。</span><span class="sxs-lookup"><span data-stu-id="864f8-120">**Feature level 9:** Although feature level 9 devices [guarantee support for multisampled render target formats](https://msdn.microsoft.com/library/windows/desktop/ff471324#MultiSample_RenderTarget), support is not guaranteed for multisample resolve targets.</span></span> <span data-ttu-id="864f8-121">そこで、このトピックで説明するマルチサンプリング技法を使おうとする前に、この確認が必要になります。</span><span class="sxs-lookup"><span data-stu-id="864f8-121">So this check is necessary before trying to use the multisampling technique described in this topic.</span></span>

    <span data-ttu-id="864f8-122">次のコードは、すべての DXGI\_FORMAT 値についてマルチサンプリング サポートを確認します。</span><span class="sxs-lookup"><span data-stu-id="864f8-122">The following code checks multisampling support for all the DXGI\_FORMAT values:</span></span>

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

2.  <span data-ttu-id="864f8-123">サポートされている形式ごとに、[**ID3D11Device::CheckMultisampleQualityLevels**](https://msdn.microsoft.com/library/windows/desktop/ff476499) を呼び出して、サンプル数のサポートを照会します。</span><span class="sxs-lookup"><span data-stu-id="864f8-123">For each supported format, query for sample count support by calling [**ID3D11Device::CheckMultisampleQualityLevels**](https://msdn.microsoft.com/library/windows/desktop/ff476499).</span></span>

    <span data-ttu-id="864f8-124">次のコードは、サポートされている DXGI 形式についてサンプル サイズのサポートを確認します。</span><span class="sxs-lookup"><span data-stu-id="864f8-124">The following code checks sample size support for supported DXGI formats:</span></span>

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

    > <span data-ttu-id="864f8-125">**注:** 使用[**id3d11device 2::checkmultisamplequalitylevels1**](https://msdn.microsoft.com/library/windows/desktop/dn280494)代わりのマルチ サンプル サポートを確認する必要がある場合は、タイル リソース バッファー。</span><span class="sxs-lookup"><span data-stu-id="864f8-125">**Note** Use [**ID3D11Device2::CheckMultisampleQualityLevels1**](https://msdn.microsoft.com/library/windows/desktop/dn280494) instead if you need to check multisample support for tiled resource buffers.</span></span>

     

3.  <span data-ttu-id="864f8-126">目的のサンプル数を使って、バッファーとレンダー ターゲット ビューを作成します。</span><span class="sxs-lookup"><span data-stu-id="864f8-126">Create a buffer and render target view with the desired sample count.</span></span> <span data-ttu-id="864f8-127">スワップ チェーンと同じ DXGI\_FORMAT、幅、高さを使いますが、1 より大きなサンプル数を指定してマルチサンプリングされたテクスチャ ディメンション (たとえば、**D3D11\_RTV\_DIMENSION\_TEXTURE2DMS**) を使います。</span><span class="sxs-lookup"><span data-stu-id="864f8-127">Use the same DXGI\_FORMAT, width, and height as the swap chain, but specify a sample count greater than 1 and use a multisampled texture dimension (**D3D11\_RTV\_DIMENSION\_TEXTURE2DMS** for example).</span></span> <span data-ttu-id="864f8-128">必要な場合、マルチサンプリングに最適な新しい設定を使ってスワップ チェーンを再作成することもできます。</span><span class="sxs-lookup"><span data-stu-id="864f8-128">If necessary, you can re-create the swap chain with new settings that are optimal for multisampling.</span></span>

    <span data-ttu-id="864f8-129">次のコードでは、マルチサンプリングされたレンダー ターゲットが作成されます。</span><span class="sxs-lookup"><span data-stu-id="864f8-129">The following code creates a multisampled render target:</span></span>

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

4.  <span data-ttu-id="864f8-130">深度バッファーは、マルチサンプリングされたレンダー ターゲットと一致する、同じ幅、高さ、サンプル数、テクスチャ ディメンションを待つ必要があります。</span><span class="sxs-lookup"><span data-stu-id="864f8-130">The depth buffer must have the same width, height, sample count, and texture dimension to match the multisampled render target.</span></span>

    <span data-ttu-id="864f8-131">次のコードでは、マルチサンプリングされた深度バッファーが作成されます。</span><span class="sxs-lookup"><span data-stu-id="864f8-131">The following code creates a multisampled depth buffer:</span></span>

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

5.  <span data-ttu-id="864f8-132">ここでビューボートを作成します。ビューポートの幅と高さもレンダー ターゲットと一致している必要があるためです。</span><span class="sxs-lookup"><span data-stu-id="864f8-132">Now is a good time to create the viewport, because the viewport width and height must also match the render target.</span></span>

    <span data-ttu-id="864f8-133">次のコードでは、ビューポートが作成されます。</span><span class="sxs-lookup"><span data-stu-id="864f8-133">The following code creates a viewport:</span></span>

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

6.  <span data-ttu-id="864f8-134">マルチサンプリングされたレンダー ターゲットに各フレームをレンダリングします。</span><span class="sxs-lookup"><span data-stu-id="864f8-134">Render each frame to the multisampled render target.</span></span> <span data-ttu-id="864f8-135">レンダリングが完了したら、フレームを表示する前に [**ID3D11DeviceContext::ResolveSubresource**](https://msdn.microsoft.com/library/windows/desktop/ff476474) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="864f8-135">When rendering is complete, call [**ID3D11DeviceContext::ResolveSubresource**](https://msdn.microsoft.com/library/windows/desktop/ff476474) before presenting the frame.</span></span> <span data-ttu-id="864f8-136">これにより Direct3D はマルチサンプリング操作を実行し、表示する各ピクセルの値を計算して、結果をバック バッファーに配置します。</span><span class="sxs-lookup"><span data-stu-id="864f8-136">This instructs Direct3D to peform the multisampling operation, computing the value of each pixel for display and placing the result in the back buffer.</span></span> <span data-ttu-id="864f8-137">バック バッファーには最終的なアンチエイリアシングされた画像が格納され、表示できるようになります。</span><span class="sxs-lookup"><span data-stu-id="864f8-137">The back buffer then contains the final anti-aliased image and can be presented.</span></span>

    <span data-ttu-id="864f8-138">次のコードは、フレームを表示する前に、サブリソースを解決します。</span><span class="sxs-lookup"><span data-stu-id="864f8-138">The following code resolves the subresource before presenting the frame:</span></span>

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

 

 




