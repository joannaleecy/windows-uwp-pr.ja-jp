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
# <a name="create-depth-buffer-device-resources"></a>深度バッファーのデバイス リソースの作成




シャドウ ボリュームの深度のテストをサポートするために必要な Direct3D デバイス リソースを作成する方法について説明します。 パート 1 の[チュートリアル。Direct3d11 の深度バッファーを使用してボリュームをシャドウ実装](implementing-depth-buffers-for-shadow-mapping.md)します。

## <a name="resources-youll-need"></a>必要なリソース


シャドウ ボリュームの深度マップをレンダリングするには、次の Direct3D デバイス依存リソースが必要です。

-   深度マップのリソース (バッファー)
-   リソースの深度ステンシル ビューとシェーダー リソース ビュー
-   比較サンプラーの状態オブジェクト
-   ライトの POV マトリックスの定数バッファー
-   シャドウ マップをレンダリングするためのビューポート (通常は正方形のビューポート)
-   前面のカリングを有効にするためのレンダリングの状態オブジェクト
-   レンダリングの状態オブジェクトをまだ使っていない場合は、背面のカリングに戻るために、このオブジェクトも必要になります。

これらのリソースの作成をデバイス依存リソースの作成ルーチンに含める必要があることに注意してください。そうすれば、新しいデバイス ドライバーがインストールされたり、別のグラフィックス アダプターに接続されているモニターにユーザーがアプリを移動したりした場合などに、レンダラーがデバイス依存リソースを再作成できます。

## <a name="check-feature-support"></a>サポートされている機能


深さのマップを作成する前に呼び出す、 [ **CheckFeatureSupport** ](https://msdn.microsoft.com/library/windows/desktop/ff476497)メソッド、Direct3D デバイスで要求**D3D11\_機能\_D3D9\_シャドウ\_サポート**を提供し、 [ **D3D11\_機能\_データ\_D3D9\_シャドウ\_サポート**](https://msdn.microsoft.com/library/windows/desktop/jj247569)構造体。

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

この機能がサポートされていない場合は 9 のシェーダー モデル 4 レベル用にコンパイルされたシェーダーをロードしてはいけません\_x サンプル比較関数を呼び出すことです。 この機能がサポートされない場合、GPU がレガシ デバイスであり、ドライバーが更新されていないため WDDM 1.2 以上がサポートされないというケースがほとんどです。 デバイスは、少なくとも機能レベル 10 場合\_0 するには、4 のシェーダー モデル用にコンパイルされたサンプル比較シェーダーを読み込むことができます\_0 代わりにします。

## <a name="create-depth-buffer"></a>深度バッファーの作成


まず、高精度深度形式の深度マップを作成してください。 最初に、一致するシェーダー リソース ビュー プロパティを設定します。 デバイス メモリの不足やハードウェアでサポートされない形式などが原因でリソースの作成が失敗した場合は、低精度形式を試して、照合するプロパティを変更してください。

この手順は、たとえば中解像度 Direct3D 機能レベル 9 で表示するときに、低精度の深さの形式のみ必要な場合は省略可能な\_1 デバイス。

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

次に、リソース ビューを作成します。 深度ステンシル ビューで mip スライスを 0 に設定し、シェーダー リソース ビューで mip レベルを 1 に設定します。 両方の TEXTURE2D、テクスチャのディメンションがあり、照合を使用する必要が両方[ **DXGI\_形式**](https://msdn.microsoft.com/library/windows/desktop/bb173059)します。

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

## <a name="create-comparison-state"></a>比較の状態の作成


ここで、比較サンプラーの状態オブジェクトを作成します。 機能レベル 9\_1 は、D3D11 のみがサポートされます。\_比較\_少ない\_と等しい。 フィルタリングの選択肢について詳しくは、「[ハードウェアの範囲でのシャドウ マップのサポート](target-a-range-of-hardware.md)」をご覧ください。シャドウ マップの高速化のために、ポイント フィルタリングを選ぶこともできます。

D3D11 を指定できることに注意してください\_テクスチャ\_アドレス\_境界線アドレス モードとは 9 の機能レベルで機能\_1 デバイス。 これは、深度のテストの実行前に、ピクセルがライトの視錐台内にあるかどうかをテストしないピクセル シェーダーに適用されます。 各境界線に 0 または 1 を指定することで、ライトの視錐台の外にあるピクセルが深度テストにパスするかどうかを制御できます。結果的に、ライトに照らされているか、シャドウ内にあるかを制御できます。

機能レベルの 9\_1、次の必須の値を設定する必要があります。**MinLOD**は 0 に設定されている**MaxLOD**に設定されている**D3D11\_FLOAT32\_最大**、および**MaxAnisotropy** 0 に設定されます。

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

## <a name="create-render-states"></a>レンダリングの状態の作成


次に、前面のカリングを有効にするために使用できるレンダリングの状態を作成します。 その機能レベル 9 に注意してください\_1 のデバイスが必要です**DepthClipEnable**設定**true**します。

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

背面のカリングを有効にするために使用できるレンダリングの状態を作成します。 レンダリング コードで既に背面のカリングを有効にしている場合は、この手順を省略できます。

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

## <a name="create-constant-buffers"></a>定数バッファーの作成


ライトの位置からのレンダリングのために定数バッファーを忘れずに作成してください。 シェーダーにライトの位置を指定するために、この定数バッファーを使うこともできます。 ポイント ライトには遠近投影マトリックスを使い、指向性ライト (太陽光など) には正投影マトリックスを使います。

```cpp
DX::ThrowIfFailed(
    m_deviceResources->GetD3DDevice()->CreateBuffer(
        &viewProjectionConstantBufferDesc,
        nullptr,
        &m_lightViewProjectionBuffer
        )
    );
```

定数バッファーにデータを入力します。 定数バッファーは初期化中に一度更新し、前のフレームからライトの値が変更された場合にもう一度更新します。

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

## <a name="create-a-viewport"></a>ビューポートの作成


シャドウ マップにレンダリングするための個別のビューポートが必要です。 ビューポートはデバイス ベースのリソースではありません。コードの別の場所で自由に作成できます。 シャドウ マップと同時にビューポートを作成すると、ビューポートのサイズとシャドウ マップのサイズの整合性を保つのが簡単になります。

```cpp
// Init viewport for shadow rendering
ZeroMemory(&m_shadowViewport, sizeof(D3D11_VIEWPORT));
m_shadowViewport.Height = m_shadowMapDimension;
m_shadowViewport.Width = m_shadowMapDimension;
m_shadowViewport.MinDepth = 0.f;
m_shadowViewport.MaxDepth = 1.f;
```

このチュートリアルの次のパートでは、[深度バッファーへのレンダリング](render-the-shadow-map-to-the-depth-buffer.md)によってシャドウ マップを作成する方法について説明します。

 

 




