---
xxxxx: Xxxxxx xxx xxxxxx xxx xx xxx xxxxx xxxxxx
xxxxxxxxxxx: Xxxxxx xxxx xxx xxxxx xx xxxx xx xxx xxxxx xx xxxxxx x xxx-xxxxxxxxxxx xxxxx xxx xxxxxxxxxxxx xxx xxxxxx xxxxxx.
xx.xxxxxxx: YxYxYYYY-xYYY-YYYY-xxYY-YYYYYYxYxYxY
---

# Xxxxxx xxx xxxxxx xxx xx xxx xxxxx xxxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


Xxxxxx xxxx xxx xxxxx xx xxxx xx xxx xxxxx xx xxxxxx x xxx-xxxxxxxxxxx xxxxx xxx xxxxxxxxxxxx xxx xxxxxx xxxxxx. Xxx xxxxx xxx xxxxx xxx xxxxx xxxx xxxx xx xxxxxxxx xx xxxxxx. Xxxx Y xx [Xxxxxxxxxxx: Xxxxxxxxx xxxxxx xxxxxxx xxxxx xxxxx xxxxxxx xx XxxxxxYX YY](implementing-depth-buffers-for-shadow-mapping.md).

## Xxxxx xxx xxxxx xxxxxx


Xxxxxx xxxxx xxx xxxxx xxxxxx xxxxxx xxxxxxxxx xx xx.

```cpp
context->ClearRenderTargetView(m_deviceResources->GetBackBufferRenderTargetView(), DirectX::Colors::CornflowerBlue);
context->ClearDepthStencilView(m_shadowDepthView.Get(), D3D11_CLEAR_DEPTH | D3D11_CLEAR_STENCIL, 1.0f, 0);
```

## Xxxxxx xxx xxxxxx xxx xx xxx xxxxx xxxxxx


Xxx xxx xxxxxx xxxxxxxxx xxxx, xxxxxxx x xxxxx xxxxxx xxx xx xxx xxxxxxx x xxxxxx xxxxxx.

Xxxxxxx xxx xxxxx xxxxxxxx, x xxxxxx xxxxxx, xxx xxx xxx xxxxx xxxxx xxxxxxxx xxxxxxx. Xxx xxxxx xxxx xxxxxxx xxx xxxx xxxx xx xxxxxxxx xxx xxxxx xxxxxx xxxxxx xx xxx xxxxxx xxxxxx.

Xxxx xxxx xx xxxx xxxxxxx, xxx xxx xxxxxxx xxxxxxx xxx xxx xxxxx xxxxxx (xx xxxx xxxxxxxxxx x xxxxx xxxxxx xxxxxxxx). Xxx xxxx xxxxxxx xxx xxxxx xx xxxxxxxxx xxxx xxx xxxx xxxx xx xxx XxxxxxYX xxxxxx xxxx x xxxx xxxxx xxxxxx xxx. Xx xxxxx xxxx xxxxxxxxx, xxx xxx xxx x xxxxxxx xxxxx xxxxxx xxx xxx xxxxxx xxxxxxxxx xxxx. Xxx xxxxxx xx xxxx xxxxxx xx xxxxxx xxxx; xx xxx xxxx [**xxxxxxx**](https://msdn.microsoft.com/library/windows/desktop/bb943995) xx xxxxx xxxxx.

Xxxxxx xxx xxxxxxx xxxx xxx xxxx xxxxxxx, xxx xxx'x xxxxxx xxxxxxxxx xxxxxxxx xxxx xxx'x xxxx x xxxxxx (xxxx x xxxxx xx x xxxx, xx xxxxxxx xxxxxxx xxxx xxx xxxxxx xxxx xxx xxxxxxxxxxxx xxxxxxx).

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

**Xxxxxxxx xxx xxxx xxxxxxx:**  Xxxx xxxx xxxx xxxxxxxxxxxxxx xxxxxxxx x xxxxx xxxx xxxxxxx xx xxxx xxx xxx xxx xxxx xxxxxxxxx xxx xx xxxx xxxxx xxxxxx. Xxx [Xxxxxx Xxxxxxxxxx xx Xxxxxxx Xxxxxx Xxxxx Xxxx](https://msdn.microsoft.com/library/windows/desktop/ee416324) xxx xxxx xxxx xx xxxxxx xxxxxxxxx.

## Xxxxxx xxxxxx xxx xxxxxx xxxx


Xxx x xxxxxxxxxx xxxxxxx xx xxxx xxxxxx xxxxxx xx xxxxxx xxxx xxx xxxxxx xxxxxxxx xx xxxxx xxxxx. Xxx'x xxxxxxx xxx xxxxxxxx xxxxxxx, xxxxxxxxx xxxxxxxxxxxxxxx, xxx xx xx.

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

Xx xxx xxxx xxxx xx xxxx xxxxxxxxxxx, xxxxx xxx xx xxx xxxxxxx xx [xxxxxxxxx xxxx xxxxx xxxxxxx](render-the-scene-with-depth-testing.md).

 

 




<!--HONumber=Mar16_HO1-->
