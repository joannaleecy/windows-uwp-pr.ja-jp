---
title: 深度バッファーのデバイス リソースの作成
description: シャドウ ボリュームの深度のテストをサポートするために必要な Direct3D デバイス リソースを作成する方法について説明します。
ms.assetid: 86d5791b-1faa-17e4-44a8-bbba07062756
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10、UWP、ゲーム、Direct3D、深度バッファー
ms.localizationpriority: medium
ms.openlocfilehash: f5ce1ec522a194111e175e41f82c4275cda4fbf5
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57613697"
---
# <a name="create-depth-buffer-device-resources"></a><span data-ttu-id="36c28-104">深度バッファーのデバイス リソースの作成</span><span class="sxs-lookup"><span data-stu-id="36c28-104">Create depth buffer device resources</span></span>




<span data-ttu-id="36c28-105">シャドウ ボリュームの深度のテストをサポートするために必要な Direct3D デバイス リソースを作成する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="36c28-105">Learn how to create the Direct3D device resources necessary to support depth testing for shadow volumes.</span></span> <span data-ttu-id="36c28-106">パート 1 の[チュートリアル。Direct3d11 の深度バッファーを使用してボリュームをシャドウ実装](implementing-depth-buffers-for-shadow-mapping.md)します。</span><span class="sxs-lookup"><span data-stu-id="36c28-106">Part 1 of [Walkthrough: Implement shadow volumes using depth buffers in Direct3D 11](implementing-depth-buffers-for-shadow-mapping.md).</span></span>

## <a name="resources-youll-need"></a><span data-ttu-id="36c28-107">必要なリソース</span><span class="sxs-lookup"><span data-stu-id="36c28-107">Resources you'll need</span></span>


<span data-ttu-id="36c28-108">シャドウ ボリュームの深度マップをレンダリングするには、次の Direct3D デバイス依存リソースが必要です。</span><span class="sxs-lookup"><span data-stu-id="36c28-108">Rendering a depth map for shadow volumes requires the following Direct3D device-dependent resources:</span></span>

-   <span data-ttu-id="36c28-109">深度マップのリソース (バッファー)</span><span class="sxs-lookup"><span data-stu-id="36c28-109">A resource (buffer) for the depth map</span></span>
-   <span data-ttu-id="36c28-110">リソースの深度ステンシル ビューとシェーダー リソース ビュー</span><span class="sxs-lookup"><span data-stu-id="36c28-110">A depth stencil view and shader resource view for the resource</span></span>
-   <span data-ttu-id="36c28-111">比較サンプラーの状態オブジェクト</span><span class="sxs-lookup"><span data-stu-id="36c28-111">A comparison sampler state object</span></span>
-   <span data-ttu-id="36c28-112">ライトの POV マトリックスの定数バッファー</span><span class="sxs-lookup"><span data-stu-id="36c28-112">Constant buffers for light POV matrices</span></span>
-   <span data-ttu-id="36c28-113">シャドウ マップをレンダリングするためのビューポート (通常は正方形のビューポート)</span><span class="sxs-lookup"><span data-stu-id="36c28-113">A viewport for rendering the shadow map (typically a square viewport)</span></span>
-   <span data-ttu-id="36c28-114">前面のカリングを有効にするためのレンダリングの状態オブジェクト</span><span class="sxs-lookup"><span data-stu-id="36c28-114">A rendering state object to enable front face culling</span></span>
-   <span data-ttu-id="36c28-115">レンダリングの状態オブジェクトをまだ使っていない場合は、背面のカリングに戻るために、このオブジェクトも必要になります。</span><span class="sxs-lookup"><span data-stu-id="36c28-115">You will also need a rendering state object to switch back to back face culling, if you don't already use one.</span></span>

<span data-ttu-id="36c28-116">これらのリソースの作成をデバイス依存リソースの作成ルーチンに含める必要があることに注意してください。そうすれば、新しいデバイス ドライバーがインストールされたり、別のグラフィックス アダプターに接続されているモニターにユーザーがアプリを移動したりした場合などに、レンダラーがデバイス依存リソースを再作成できます。</span><span class="sxs-lookup"><span data-stu-id="36c28-116">Note that creation of these resources needs to be included in a device-dependent resource creation routine, that way your renderer can recreate them if (for example) a new device driver is installed, or the user moves your app to a monitor attached to a different graphics adapter.</span></span>

## <a name="check-feature-support"></a><span data-ttu-id="36c28-117">サポートされている機能</span><span class="sxs-lookup"><span data-stu-id="36c28-117">Check feature support</span></span>


<span data-ttu-id="36c28-118">深さのマップを作成する前に呼び出す、 [ **CheckFeatureSupport** ](https://msdn.microsoft.com/library/windows/desktop/ff476497)メソッド、Direct3D デバイスで要求**D3D11\_機能\_D3D9\_シャドウ\_サポート**を提供し、 [ **D3D11\_機能\_データ\_D3D9\_シャドウ\_サポート**](https://msdn.microsoft.com/library/windows/desktop/jj247569)構造体。</span><span class="sxs-lookup"><span data-stu-id="36c28-118">Before creating the depth map, call the [**CheckFeatureSupport**](https://msdn.microsoft.com/library/windows/desktop/ff476497) method on the Direct3D device, request **D3D11\_FEATURE\_D3D9\_SHADOW\_SUPPORT**, and provide a [**D3D11\_FEATURE\_DATA\_D3D9\_SHADOW\_SUPPORT**](https://msdn.microsoft.com/library/windows/desktop/jj247569) structure.</span></span>

```cpp
D3D11_FEATURE_DATA_D3D9_SHADOW_SUPPORT isD3D9ShadowSupported;
ZeroMemory(&isD3D9ShadowSupported, sizeof(isD3D9ShadowSupported));
pD3DDevice->CheckFeatureSupport(
    D3D11_FEATURE_D3D9_SHADOW_SUPPORT,
    &isD3D9ShadowSupported,
    sizeof(D3D11_FEATURE_D3D9_SHADOW_SUPPORT)
    );

if (isD3D9ShadowSupported.SupportsDepthAsTextureWithLessEqualComparisonFilter)
{
    // Init shadow map resources

```

<span data-ttu-id="36c28-119">この機能がサポートされていない場合は 9 のシェーダー モデル 4 レベル用にコンパイルされたシェーダーをロードしてはいけません\_x サンプル比較関数を呼び出すことです。</span><span class="sxs-lookup"><span data-stu-id="36c28-119">If this feature is not supported, do not try to load shaders compiled for shader model 4 level 9\_x that call sample comparison functions.</span></span> <span data-ttu-id="36c28-120">この機能がサポートされない場合、GPU がレガシ デバイスであり、ドライバーが更新されていないため WDDM 1.2 以上がサポートされないというケースがほとんどです。</span><span class="sxs-lookup"><span data-stu-id="36c28-120">In many cases, lack of support for this feature means that the GPU is a legacy device with a driver that isn't updated to support at least WDDM 1.2.</span></span> <span data-ttu-id="36c28-121">デバイスは、少なくとも機能レベル 10 場合\_0 するには、4 のシェーダー モデル用にコンパイルされたサンプル比較シェーダーを読み込むことができます\_0 代わりにします。</span><span class="sxs-lookup"><span data-stu-id="36c28-121">If the device supports at least feature level 10\_0 then you can load a sample comparison shader compiled for shader model 4\_0 instead.</span></span>

## <a name="create-depth-buffer"></a><span data-ttu-id="36c28-122">深度バッファーの作成</span><span class="sxs-lookup"><span data-stu-id="36c28-122">Create depth buffer</span></span>


<span data-ttu-id="36c28-123">まず、高精度深度形式の深度マップを作成してください。</span><span class="sxs-lookup"><span data-stu-id="36c28-123">First, try creating the depth map with a higher-precision depth format.</span></span> <span data-ttu-id="36c28-124">最初に、一致するシェーダー リソース ビュー プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="36c28-124">Set up matching shader resource view properties first.</span></span> <span data-ttu-id="36c28-125">デバイス メモリの不足やハードウェアでサポートされない形式などが原因でリソースの作成が失敗した場合は、低精度形式を試して、照合するプロパティを変更してください。</span><span class="sxs-lookup"><span data-stu-id="36c28-125">If the resource creation fails, for example due to low device memory or a format that the hardware doesn't support, try a lower-precision format and change properties to match.</span></span>

<span data-ttu-id="36c28-126">この手順は、たとえば中解像度 Direct3D 機能レベル 9 で表示するときに、低精度の深さの形式のみ必要な場合は省略可能な\_1 デバイス。</span><span class="sxs-lookup"><span data-stu-id="36c28-126">This step is optional if you only need a low-precision depth format, for example when rendering on medium-resolution Direct3D feature level 9\_1 devices.</span></span>

```cpp
D3D11_TEXTURE2D_DESC shadowMapDesc;
ZeroMemory(&shadowMapDesc, sizeof(D3D11_TEXTURE2D_DESC));
shadowMapDesc.Format = DXGI_FORMAT_R24G8_TYPELESS;
shadowMapDesc.MipLevels = 1;
shadowMapDesc.ArraySize = 1;
shadowMapDesc.SampleDesc.Count = 1;
shadowMapDesc.BindFlags = D3D11_BIND_SHADER_RESOURCE | D3D11_BIND_DEPTH_STENCIL;
shadowMapDesc.Height = static_cast<UINT>(m_shadowMapDimension);
shadowMapDesc.Width = static_cast<UINT>(m_shadowMapDimension);

HRESULT hr = pD3DDevice->CreateTexture2D(
    &shadowMapDesc,
    nullptr,
    &m_shadowMap
    );
```

<span data-ttu-id="36c28-127">次に、リソース ビューを作成します。</span><span class="sxs-lookup"><span data-stu-id="36c28-127">Then create the resource views.</span></span> <span data-ttu-id="36c28-128">深度ステンシル ビューで mip スライスを 0 に設定し、シェーダー リソース ビューで mip レベルを 1 に設定します。</span><span class="sxs-lookup"><span data-stu-id="36c28-128">Set the mip slice to zero on the depth stencil view and set mip levels to 1 on the shader resource view.</span></span> <span data-ttu-id="36c28-129">両方の TEXTURE2D、テクスチャのディメンションがあり、照合を使用する必要が両方[ **DXGI\_形式**](https://msdn.microsoft.com/library/windows/desktop/bb173059)します。</span><span class="sxs-lookup"><span data-stu-id="36c28-129">Both have a texture dimension of TEXTURE2D, and both need to use a matching [**DXGI\_FORMAT**](https://msdn.microsoft.com/library/windows/desktop/bb173059).</span></span>

```cpp
D3D11_DEPTH_STENCIL_VIEW_DESC depthStencilViewDesc;
ZeroMemory(&depthStencilViewDesc, sizeof(D3D11_DEPTH_STENCIL_VIEW_DESC));
depthStencilViewDesc.Format = DXGI_FORMAT_D24_UNORM_S8_UINT;
depthStencilViewDesc.ViewDimension = D3D11_DSV_DIMENSION_TEXTURE2D;
depthStencilViewDesc.Texture2D.MipSlice = 0;

D3D11_SHADER_RESOURCE_VIEW_DESC shaderResourceViewDesc;
ZeroMemory(&shaderResourceViewDesc, sizeof(D3D11_SHADER_RESOURCE_VIEW_DESC));
shaderResourceViewDesc.ViewDimension = D3D11_SRV_DIMENSION_TEXTURE2D;
shaderResourceViewDesc.Format = DXGI_FORMAT_R24_UNORM_X8_TYPELESS;
shaderResourceViewDesc.Texture2D.MipLevels = 1;

hr = pD3DDevice->CreateDepthStencilView(
    m_shadowMap.Get(),
    &depthStencilViewDesc,
    &m_shadowDepthView
    );

hr = pD3DDevice->CreateShaderResourceView(
    m_shadowMap.Get(),
    &shaderResourceViewDesc,
    &m_shadowResourceView
    );
```

## <a name="create-comparison-state"></a><span data-ttu-id="36c28-130">比較の状態の作成</span><span class="sxs-lookup"><span data-stu-id="36c28-130">Create comparison state</span></span>


<span data-ttu-id="36c28-131">ここで、比較サンプラーの状態オブジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="36c28-131">Now create the comparison sampler state object.</span></span> <span data-ttu-id="36c28-132">機能レベル 9\_1 は、D3D11 のみがサポートされます。\_比較\_少ない\_と等しい。</span><span class="sxs-lookup"><span data-stu-id="36c28-132">Feature level 9\_1 only supports D3D11\_COMPARISON\_LESS\_EQUAL.</span></span> <span data-ttu-id="36c28-133">フィルタリングの選択肢について詳しくは、「[ハードウェアの範囲でのシャドウ マップのサポート](target-a-range-of-hardware.md)」をご覧ください。シャドウ マップの高速化のために、ポイント フィルタリングを選ぶこともできます。</span><span class="sxs-lookup"><span data-stu-id="36c28-133">Filtering choices are explained more in [Supporting shadow maps on a range of hardware](target-a-range-of-hardware.md) - or you can just pick point filtering for faster shadow maps.</span></span>

<span data-ttu-id="36c28-134">D3D11 を指定できることに注意してください\_テクスチャ\_アドレス\_境界線アドレス モードとは 9 の機能レベルで機能\_1 デバイス。</span><span class="sxs-lookup"><span data-stu-id="36c28-134">Note that you can specify the D3D11\_TEXTURE\_ADDRESS\_BORDER address mode and it will work on feature level 9\_1 devices.</span></span> <span data-ttu-id="36c28-135">これは、深度のテストの実行前に、ピクセルがライトの視錐台内にあるかどうかをテストしないピクセル シェーダーに適用されます。</span><span class="sxs-lookup"><span data-stu-id="36c28-135">This applies to pixel shaders that don't test whether the pixel is in the light's view frustum before doing the depth test.</span></span> <span data-ttu-id="36c28-136">各境界線に 0 または 1 を指定することで、ライトの視錐台の外にあるピクセルが深度テストにパスするかどうかを制御できます。結果的に、ライトに照らされているか、シャドウ内にあるかを制御できます。</span><span class="sxs-lookup"><span data-stu-id="36c28-136">By specifying 0 or 1 for each border, you can control whether pixels outside the light's view frustum pass or fail the depth test, and therefore whether they are lit or in shadow.</span></span>

<span data-ttu-id="36c28-137">機能レベルの 9\_1、次の必須の値を設定する必要があります。**MinLOD**は 0 に設定されている**MaxLOD**に設定されている**D3D11\_FLOAT32\_最大**、および**MaxAnisotropy** 0 に設定されます。</span><span class="sxs-lookup"><span data-stu-id="36c28-137">On feature level 9\_1, the following required values must be set: **MinLOD** is set to zero, **MaxLOD** is set to **D3D11\_FLOAT32\_MAX**, and **MaxAnisotropy** is set to zero.</span></span>

```cpp
D3D11_SAMPLER_DESC comparisonSamplerDesc;
ZeroMemory(&comparisonSamplerDesc, sizeof(D3D11_SAMPLER_DESC));
comparisonSamplerDesc.AddressU = D3D11_TEXTURE_ADDRESS_BORDER;
comparisonSamplerDesc.AddressV = D3D11_TEXTURE_ADDRESS_BORDER;
comparisonSamplerDesc.AddressW = D3D11_TEXTURE_ADDRESS_BORDER;
comparisonSamplerDesc.BorderColor[0] = 1.0f;
comparisonSamplerDesc.BorderColor[1] = 1.0f;
comparisonSamplerDesc.BorderColor[2] = 1.0f;
comparisonSamplerDesc.BorderColor[3] = 1.0f;
comparisonSamplerDesc.MinLOD = 0.f;
comparisonSamplerDesc.MaxLOD = D3D11_FLOAT32_MAX;
comparisonSamplerDesc.MipLODBias = 0.f;
comparisonSamplerDesc.MaxAnisotropy = 0;
comparisonSamplerDesc.ComparisonFunc = D3D11_COMPARISON_LESS_EQUAL;
comparisonSamplerDesc.Filter = D3D11_FILTER_COMPARISON_MIN_MAG_MIP_POINT;

// Point filtered shadows can be faster, and may be a good choice when
// rendering on hardware with lower feature levels. This sample has a
// UI option to enable/disable filtering so you can see the difference
// in quality and speed.

DX::ThrowIfFailed(
    pD3DDevice->CreateSamplerState(
        &comparisonSamplerDesc,
        &m_comparisonSampler_point
        )
    );
```

## <a name="create-render-states"></a><span data-ttu-id="36c28-138">レンダリングの状態の作成</span><span class="sxs-lookup"><span data-stu-id="36c28-138">Create render states</span></span>


<span data-ttu-id="36c28-139">次に、前面のカリングを有効にするために使用できるレンダリングの状態を作成します。</span><span class="sxs-lookup"><span data-stu-id="36c28-139">Now create a render state you can use to enable front face culling.</span></span> <span data-ttu-id="36c28-140">その機能レベル 9 に注意してください\_1 のデバイスが必要です**DepthClipEnable**設定**true**します。</span><span class="sxs-lookup"><span data-stu-id="36c28-140">Note that feature level 9\_1 devices require **DepthClipEnable** set to **true**.</span></span>

```cpp
D3D11_RASTERIZER_DESC drawingRenderStateDesc;
ZeroMemory(&drawingRenderStateDesc, sizeof(D3D11_RASTERIZER_DESC));
drawingRenderStateDesc.CullMode = D3D11_CULL_BACK;
drawingRenderStateDesc.FillMode = D3D11_FILL_SOLID;
drawingRenderStateDesc.DepthClipEnable = true; // Feature level 9_1 requires DepthClipEnable == true
DX::ThrowIfFailed(
    pD3DDevice->CreateRasterizerState(
        &drawingRenderStateDesc,
        &m_drawingRenderState
        )
    );
```

<span data-ttu-id="36c28-141">背面のカリングを有効にするために使用できるレンダリングの状態を作成します。</span><span class="sxs-lookup"><span data-stu-id="36c28-141">Create a render state you can use to enable back face culling.</span></span> <span data-ttu-id="36c28-142">レンダリング コードで既に背面のカリングを有効にしている場合は、この手順を省略できます。</span><span class="sxs-lookup"><span data-stu-id="36c28-142">If your rendering code already turns on back face culling, then you can skip this step.</span></span>

```cpp
D3D11_RASTERIZER_DESC shadowRenderStateDesc;
ZeroMemory(&shadowRenderStateDesc, sizeof(D3D11_RASTERIZER_DESC));
shadowRenderStateDesc.CullMode = D3D11_CULL_FRONT;
shadowRenderStateDesc.FillMode = D3D11_FILL_SOLID;
shadowRenderStateDesc.DepthClipEnable = true;

DX::ThrowIfFailed(
    pD3DDevice->CreateRasterizerState(
        &shadowRenderStateDesc,
        &m_shadowRenderState
        )
    );
```

## <a name="create-constant-buffers"></a><span data-ttu-id="36c28-143">定数バッファーの作成</span><span class="sxs-lookup"><span data-stu-id="36c28-143">Create constant buffers</span></span>


<span data-ttu-id="36c28-144">ライトの位置からのレンダリングのために定数バッファーを忘れずに作成してください。</span><span class="sxs-lookup"><span data-stu-id="36c28-144">Don't forget to create a constant buffer for rendering from the light's point of view.</span></span> <span data-ttu-id="36c28-145">シェーダーにライトの位置を指定するために、この定数バッファーを使うこともできます。</span><span class="sxs-lookup"><span data-stu-id="36c28-145">You can also use this constant buffer to specify the light position to the shader.</span></span> <span data-ttu-id="36c28-146">ポイント ライトには遠近投影マトリックスを使い、指向性ライト (太陽光など) には正投影マトリックスを使います。</span><span class="sxs-lookup"><span data-stu-id="36c28-146">Use a perspective matrix for point lights, and use an orthogonal matrix for directional lights (such as sunlight).</span></span>

```cpp
DX::ThrowIfFailed(
    m_deviceResources->GetD3DDevice()->CreateBuffer(
        &viewProjectionConstantBufferDesc,
        nullptr,
        &m_lightViewProjectionBuffer
        )
    );
```

<span data-ttu-id="36c28-147">定数バッファーにデータを入力します。</span><span class="sxs-lookup"><span data-stu-id="36c28-147">Fill the constant buffer data.</span></span> <span data-ttu-id="36c28-148">定数バッファーは初期化中に一度更新し、前のフレームからライトの値が変更された場合にもう一度更新します。</span><span class="sxs-lookup"><span data-stu-id="36c28-148">Update the constant buffers once during initialization, and again if the light values have changed since the previous frame.</span></span>

```cpp
{
    XMMATRIX lightPerspectiveMatrix = XMMatrixPerspectiveFovRH(
        XM_PIDIV2,
        1.0f,
        12.f,
        50.f
        );

    XMStoreFloat4x4(
        &m_lightViewProjectionBufferData.projection,
        XMMatrixTranspose(lightPerspectiveMatrix)
        );

    // Point light at (20, 15, 20), pointed at the origin. POV up-vector is along the y-axis.
    static const XMVECTORF32 eye = { 20.0f, 15.0f, 20.0f, 0.0f };
    static const XMVECTORF32 at = { 0.0f, 0.0f, 0.0f, 0.0f };
    static const XMVECTORF32 up = { 0.0f, 1.0f, 0.0f, 0.0f };

    XMStoreFloat4x4(
        &m_lightViewProjectionBufferData.view,
        XMMatrixTranspose(XMMatrixLookAtRH(eye, at, up))
        );

    // Store the light position to help calculate the shadow offset.
    XMStoreFloat4(&m_lightViewProjectionBufferData.pos, eye);
}
```

```cpp
context->UpdateSubresource(
    m_lightViewProjectionBuffer.Get(),
    0,
    NULL,
    &m_lightViewProjectionBufferData,
    0,
    0
    );
```

## <a name="create-a-viewport"></a><span data-ttu-id="36c28-149">ビューポートの作成</span><span class="sxs-lookup"><span data-stu-id="36c28-149">Create a viewport</span></span>


<span data-ttu-id="36c28-150">シャドウ マップにレンダリングするための個別のビューポートが必要です。</span><span class="sxs-lookup"><span data-stu-id="36c28-150">You need a separate viewport to render to the shadow map.</span></span> <span data-ttu-id="36c28-151">ビューポートはデバイス ベースのリソースではありません。コードの別の場所で自由に作成できます。</span><span class="sxs-lookup"><span data-stu-id="36c28-151">The viewport isn't a device-based resource; you're free to create it elsewhere in your code.</span></span> <span data-ttu-id="36c28-152">シャドウ マップと同時にビューポートを作成すると、ビューポートのサイズとシャドウ マップのサイズの整合性を保つのが簡単になります。</span><span class="sxs-lookup"><span data-stu-id="36c28-152">Creating the viewport along with the shadow map can help make it more convenient to keep the dimension of the viewport congruent with the shadow map dimension.</span></span>

```cpp
// Init viewport for shadow rendering
ZeroMemory(&m_shadowViewport, sizeof(D3D11_VIEWPORT));
m_shadowViewport.Height = m_shadowMapDimension;
m_shadowViewport.Width = m_shadowMapDimension;
m_shadowViewport.MinDepth = 0.f;
m_shadowViewport.MaxDepth = 1.f;
```

<span data-ttu-id="36c28-153">このチュートリアルの次のパートでは、[深度バッファーへのレンダリング](render-the-shadow-map-to-the-depth-buffer.md)によってシャドウ マップを作成する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="36c28-153">In the next part of this walkthrough, learn how to create the shadow map by [rendering to the depth buffer](render-the-shadow-map-to-the-depth-buffer.md).</span></span>

 

 




