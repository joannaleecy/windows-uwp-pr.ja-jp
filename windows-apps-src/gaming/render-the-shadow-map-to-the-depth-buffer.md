---
author: mtoepke
title: 深度バッファーへのシャドウ マップのレンダリング
description: ライトの視点からレンダリングして、シャドウ ボリュームを表す 2 次元の深度マップを作成します。
ms.assetid: 7f3d0208-c379-8871-cc48-027047c6c2d0
ms.author: mtoepke
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10、UWP、ゲーム、レンダリング、シャドウ マップ、深度バッファー、Direct3D
ms.localizationpriority: medium
ms.openlocfilehash: a73754fef6d87505751460ec134d853c6bca0530
ms.sourcegitcommit: e2fca6c79f31e521ba76f7ecf343cf8f278e6a15
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/15/2018
ms.locfileid: "6996815"
---
# <a name="render-the-shadow-map-to-the-depth-buffer"></a><span data-ttu-id="9211b-104">深度バッファーへのシャドウ マップのレンダリング</span><span class="sxs-lookup"><span data-stu-id="9211b-104">Render the shadow map to the depth buffer</span></span>




<span data-ttu-id="9211b-105">ライトの視点からレンダリングして、シャドウ ボリュームを表す 2 次元の深度マップを作成します。</span><span class="sxs-lookup"><span data-stu-id="9211b-105">Render from the point of view of the light to create a two-dimensional depth map representing the shadow volume.</span></span> <span data-ttu-id="9211b-106">深度マップでは、シャドウ内にレンダリングされる空間をマークします。</span><span class="sxs-lookup"><span data-stu-id="9211b-106">The depth map masks the space that will be rendered in shadow.</span></span> <span data-ttu-id="9211b-107">「[チュートリアル: Direct3D 11 の深度バッファーを使ったシャドウ ボリュームの実装](implementing-depth-buffers-for-shadow-mapping.md)」のパート 2 です。</span><span class="sxs-lookup"><span data-stu-id="9211b-107">Part 2 of [Walkthrough: Implement shadow volumes using depth buffers in Direct3D 11](implementing-depth-buffers-for-shadow-mapping.md).</span></span>

## <a name="clear-the-depth-buffer"></a><span data-ttu-id="9211b-108">深度バッファーの消去</span><span class="sxs-lookup"><span data-stu-id="9211b-108">Clear the depth buffer</span></span>


<span data-ttu-id="9211b-109">深度バッファーにレンダリングする前に、必ず深度バッファーを消去します。</span><span class="sxs-lookup"><span data-stu-id="9211b-109">Always clear the depth buffer before rendering to it.</span></span>

```cpp
context->ClearRenderTargetView(m_deviceResources->GetBackBufferRenderTargetView(), DirectX::Colors::CornflowerBlue);
context->ClearDepthStencilView(m_shadowDepthView.Get(), D3D11_CLEAR_DEPTH | D3D11_CLEAR_STENCIL, 1.0f, 0);
```

## <a name="render-the-shadow-map-to-the-depth-buffer"></a><span data-ttu-id="9211b-110">深度バッファーへのシャドウ マップのレンダリング</span><span class="sxs-lookup"><span data-stu-id="9211b-110">Render the shadow map to the depth buffer</span></span>


<span data-ttu-id="9211b-111">シャドウのレンダリング パスでは、深度バッファーを指定しますが、レンダー ターゲットは指定しません。</span><span class="sxs-lookup"><span data-stu-id="9211b-111">For the shadow rendering pass, specify a depth buffer but do not specify a render target.</span></span>

<span data-ttu-id="9211b-112">ライト ビューポート、頂点シェーダーを指定し、ライト空間の定数バッファーを設定します。</span><span class="sxs-lookup"><span data-stu-id="9211b-112">Specify the light viewport, a vertex shader, and set the light space constant buffers.</span></span> <span data-ttu-id="9211b-113">このパスに前面のカリングを使って、シャドウ バッファーに配置された深度値を最適化します。</span><span class="sxs-lookup"><span data-stu-id="9211b-113">Use front face culling for this pass to optimize the depth values placed in the shadow buffer.</span></span>

<span data-ttu-id="9211b-114">ほとんどのデバイスでは、ピクセル シェーダーに対して nullptr を指定できます (または、ピクセル シェーダーの指定を完全にスキップできます)。</span><span class="sxs-lookup"><span data-stu-id="9211b-114">Note that on most devices, you can specify nullptr for the pixel shader (or skip specifying a pixel shader entirely).</span></span> <span data-ttu-id="9211b-115">ただし、ドライバーによっては、Direct3D デバイスで null のピクセル シェーダーを設定して描画を呼び出すと、例外がスローされる場合があります。</span><span class="sxs-lookup"><span data-stu-id="9211b-115">But some drivers may throw an exception when you call draw on the Direct3D device with a null pixel shader set.</span></span> <span data-ttu-id="9211b-116">この例外を避けるには、シャドウのレンダリング パスに対して最小限のピクセル シェーダーを設定します。</span><span class="sxs-lookup"><span data-stu-id="9211b-116">To avoid this exception, you can set a minimal pixel shader for the shadow rendering pass.</span></span> <span data-ttu-id="9211b-117">このシェーダーの出力は破棄されるため、各ピクセルで [**discard**](https://msdn.microsoft.com/library/windows/desktop/bb943995) を呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="9211b-117">The output of this shader is thrown away; it can call [**discard**](https://msdn.microsoft.com/library/windows/desktop/bb943995) on every pixel.</span></span>

<span data-ttu-id="9211b-118">シャドウが生じる可能性があるオブジェクトをレンダリングしますが、シャドウが生じる可能性がないジオメトリ (部屋の床や、最適化のためにシャドウ パスから削除したオブジェクトなど) のレンダリングについては気にする必要はありません。</span><span class="sxs-lookup"><span data-stu-id="9211b-118">Render the objects that can cast shadows, but don't bother rendering geometry that can't cast a shadow (like a floor in a room, or objects removed from the shadow pass for optimization reasons).</span></span>

```cpp
void ShadowSceneRenderer::RenderShadowMap()
{
    auto context = m_deviceResources->GetD3DDeviceContext();

    // Render all the objects in the scene that can cast shadows onto themselves or onto other objects.

    // Only bind the ID3D11DepthStencilView for output.
    context->OMSetRenderTargets(
        0,
        nullptr,
        m_shadowDepthView.Get()
        );

    // Note that starting with the second frame, the previous call will display
    // warnings in VS debug output about forcing an unbind of the pixel shader
    // resource. This warning can be safely ignored when using shadow buffers
    // as demonstrated in this sample.

    // Set rendering state.
    context->RSSetState(m_shadowRenderState.Get());
    context->RSSetViewports(1, &m_shadowViewport);

    // Each vertex is one instance of the VertexPositionTexNormColor struct.
    UINT stride = sizeof(VertexPositionTexNormColor);
    UINT offset = 0;
    context->IASetVertexBuffers(
        0,
        1,
        m_vertexBuffer.GetAddressOf(),
        &stride,
        &offset
        );

    context->IASetIndexBuffer(
        m_indexBuffer.Get(),
        DXGI_FORMAT_R16_UINT, // Each index is one 16-bit unsigned integer (short).
        0
        );

    context->IASetPrimitiveTopology(D3D11_PRIMITIVE_TOPOLOGY_TRIANGLELIST);
    context->IASetInputLayout(m_inputLayout.Get());

    // Attach our vertex shader.
    context->VSSetShader(
        m_simpleVertexShader.Get(),
        nullptr,
        0
        );

    // Send the constant buffers to the Graphics device.
    context->VSSetConstantBuffers(
        0,
        1,
        m_lightViewProjectionBuffer.GetAddressOf()
        );

    context->VSSetConstantBuffers(
        1,
        1,
        m_rotatedModelBuffer.GetAddressOf()
        );

    // In some configurations, it's possible to avoid setting a pixel shader
    // (or set PS to nullptr). Not all drivers are tolerant of this, so to be
    // safe set a minimal shader here.
    //
    // Direct3D will discard output from this shader because the render target
    // view is unbound.
    context->PSSetShader(
        m_textureShader.Get(),
        nullptr,
        0
        );

    // Draw the objects.
    context->DrawIndexed(
        m_indexCountCube,
        0,
        0
        );
}
```

<span data-ttu-id="9211b-119">**視錐台の最適化:** 深度バッファーの精度を最大限に高めるために、実装では視錐台を厳密に計算してください。</span><span class="sxs-lookup"><span data-stu-id="9211b-119">**Optimize the view frustum:**  Make sure your implementation computes a tight view frustum so that you get the most precision out of your depth buffer.</span></span> <span data-ttu-id="9211b-120">シャドウの方法に関するヒントについては、「[シャドウ深度マップを向上させるための一般的な方法](https://msdn.microsoft.com/library/windows/desktop/ee416324)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9211b-120">See [Common Techniques to Improve Shadow Depth Maps](https://msdn.microsoft.com/library/windows/desktop/ee416324) for more tips on shadow technique.</span></span>

## <a name="vertex-shader-for-shadow-pass"></a><span data-ttu-id="9211b-121">シャドウ パスの頂点シェーダー</span><span class="sxs-lookup"><span data-stu-id="9211b-121">Vertex shader for shadow pass</span></span>


<span data-ttu-id="9211b-122">簡略化したバージョンの頂点シェーダーを使って、ライト空間内の頂点の位置だけをレンダリングします。</span><span class="sxs-lookup"><span data-stu-id="9211b-122">Use a simplified version of your vertex shader to render just the vertex position in light space.</span></span> <span data-ttu-id="9211b-123">照明法線や二次変換などを含めないでください。</span><span class="sxs-lookup"><span data-stu-id="9211b-123">Don't include any lighting normals, secondary transformations, and so on.</span></span>

```cpp
PixelShaderInput main(VertexShaderInput input)
{
    PixelShaderInput output;
    float4 pos = float4(input.pos, 1.0f);

    // Transform the vertex position into projected space.
    pos = mul(pos, model);
    pos = mul(pos, view);
    pos = mul(pos, projection);
    output.pos = pos;

    return output;
}
```

<span data-ttu-id="9211b-124">このチュートリアルの次のパートでは、[深度のテストを使ったレンダリング](render-the-scene-with-depth-testing.md)によってシャドウを追加する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="9211b-124">In the next part of this walkthrough, learn how to add shadows by [rendering with depth testing](render-the-scene-with-depth-testing.md).</span></span>

 

 




