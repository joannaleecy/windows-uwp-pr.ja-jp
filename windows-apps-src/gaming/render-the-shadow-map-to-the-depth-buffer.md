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
ms.sourcegitcommit: 144f5f127fc4fbd852f2f6780ef26054192d68fc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/02/2018
ms.locfileid: "5987375"
---
# <a name="render-the-shadow-map-to-the-depth-buffer"></a>深度バッファーへのシャドウ マップのレンダリング




ライトの視点からレンダリングして、シャドウ ボリュームを表す 2 次元の深度マップを作成します。 深度マップでは、シャドウ内にレンダリングされる空間をマークします。 「[チュートリアル: Direct3D 11 の深度バッファーを使ったシャドウ ボリュームの実装](implementing-depth-buffers-for-shadow-mapping.md)」のパート 2 です。

## <a name="clear-the-depth-buffer"></a>深度バッファーの消去


深度バッファーにレンダリングする前に、必ず深度バッファーを消去します。

```cpp
context->ClearRenderTargetView(m_deviceResources->GetBackBufferRenderTargetView(), DirectX::Colors::CornflowerBlue);
context->ClearDepthStencilView(m_shadowDepthView.Get(), D3D11_CLEAR_DEPTH | D3D11_CLEAR_STENCIL, 1.0f, 0);
```

## <a name="render-the-shadow-map-to-the-depth-buffer"></a>深度バッファーへのシャドウ マップのレンダリング


シャドウのレンダリング パスでは、深度バッファーを指定しますが、レンダー ターゲットは指定しません。

ライト ビューポート、頂点シェーダーを指定し、ライト空間の定数バッファーを設定します。 このパスに前面のカリングを使って、シャドウ バッファーに配置された深度値を最適化します。

ほとんどのデバイスでは、ピクセル シェーダーに対して nullptr を指定できます (または、ピクセル シェーダーの指定を完全にスキップできます)。 ただし、ドライバーによっては、Direct3D デバイスで null のピクセル シェーダーを設定して描画を呼び出すと、例外がスローされる場合があります。 この例外を避けるには、シャドウのレンダリング パスに対して最小限のピクセル シェーダーを設定します。 このシェーダーの出力は破棄されるため、各ピクセルで [**discard**](https://msdn.microsoft.com/library/windows/desktop/bb943995) を呼び出すことができます。

シャドウが生じる可能性があるオブジェクトをレンダリングしますが、シャドウが生じる可能性がないジオメトリ (部屋の床や、最適化のためにシャドウ パスから削除したオブジェクトなど) のレンダリングについては気にする必要はありません。

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

**視錐台の最適化:** 深度バッファーの精度を最大限に高めるために、実装では視錐台を厳密に計算してください。 シャドウの方法に関するヒントについては、「[シャドウ深度マップを向上させるための一般的な方法](https://msdn.microsoft.com/library/windows/desktop/ee416324)」をご覧ください。

## <a name="vertex-shader-for-shadow-pass"></a>シャドウ パスの頂点シェーダー


簡略化したバージョンの頂点シェーダーを使って、ライト空間内の頂点の位置だけをレンダリングします。 照明法線や二次変換などを含めないでください。

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

このチュートリアルの次のパートでは、[深度のテストを使ったレンダリング](render-the-scene-with-depth-testing.md)によってシャドウを追加する方法について説明します。

 

 




