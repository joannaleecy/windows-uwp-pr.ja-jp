---
xxxxx: Xxxxxx xxxxxxx xxx xxxxxxx xxxxxxxxxx
xxxxxxxxxxx: Xxxx, xx xxxx xxx xxx xx xxx XXXX xxxxxx xxxxx xx xxxxxxx xxx xxxxxx xxxxxxx xxxx xxx xxx xxxx xxx xx xxxx xxxxxxxxxx xx xxx xxxxxxx.
xx.xxxxxxx: YYYYYxxx-YYxY-YxxY-YYYY-YYxYxxYxYYxY
---

# Xxxxxx xxxxxxx xxx xxxxxxx xxxxxxxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

Xxxx, xx xxxx xxx xxx xx xxx XXXX xxxxxx xxxxx xx xxxxxxx xxx xxxxxx xxxxxxx xxxx xxx xxx xxxx xxx xx xxxx xxxxxxxxxx xx xxx xxxxxxx.

Xx xxxxxx xxx xxxx x xxxxxx xxxxxxxx xx xxxxx xxxxxx xxx xxxxx xxxxxxx. Xxxxx xx xxxxxx xxx XxxxxxYX xxxxxx, xxx xxxx xxxxx, xxx xxx xxxxxx-xxxxxx xxxx, xx xxxx xxxx xxxx xxxxxx xxxxxx xxxxxx xxxxx xx xxx xxxx.

**Xxxxxxxxx:** Xx xxxxxx xxxxxxx xxx xx xxxx xxxxxxxxxx.

## Xxxxxxxxxxxxx


Xx xxxxxx xxxx xxx xxx xxxxxxxx xxxx X++. Xxx xxxx xxxx xxxxx xxxxxxxxxx xxxx xxxxxxxx xxxxxxxxxxx xxxxxxxx.

Xx xxxx xxxxxx xxxx xxx xxxx xxxxxxx [Xxxxxxxxxx: xxxxxxx xx XxxxxxX xxxxxxxxx xxx xxxxxxxxxx xx xxxxx](setting-up-directx-resources.md).

**Xxxx xx xxxxxxxx:** YY xxxxxxx.

## Xxxxxxxxxxxx

### Y. Xxxxxxxxx XXXX xxxxxx xxxxx

Xxxxxxxxx Xxxxxx Xxxxxx xxxx xxx [xxx.xxx](https://msdn.microsoft.com/library/windows/desktop/bb232919) XXXX xxxx xxxxxxxx xx xxxxxxx xxx .xxxx xxxxxx xxxxx (XxxxxxXxxxxxXxxxxx.xxxx xxx XxxxxxXxxxxXxxxxx.xxxx) xxxx .xxx xxxxxx xxxxxx xxxxxx xxxxx (XxxxxxXxxxxxXxxxxx.xxx xxx XxxxxxXxxxxXxxxxx.xxx). Xxx xxxx xxxx xxxxx xxx XXXX xxxx xxxxxxxx, xxx Xxxxxx-Xxxxxxxx Xxxx. Xxx xxxx xxxx xxxxx xxxxxxxxx xxxxxx xxxx, xxx [Xxxxxxxxx Xxxxxxx](https://msdn.microsoft.com/library/windows/desktop/bb509633).

Xxxx xx xxx xxxx xx XxxxxxXxxxxxXxxxxx.xxxx:

```hlsl
struct VertexShaderInput
{
    DirectX::XMFLOAT2 pos : POSITION;
};

struct PixelShaderInput
{
    float4 pos : SV_POSITION;
};

PixelShaderInput SimpleVertexShader(VertexShaderInput input)
{
    PixelShaderInput vertexShaderOutput;

    // For this lesson, set the vertex depth value to 0.5, so it is guaranteed to be drawn.
    vertexShaderOutput.pos = float4(input.pos, 0.5f, 1.0f);

    return vertexShaderOutput;
}
```

Xxxx xx xxx xxxx xx XxxxxxXxxxxXxxxxx.xxxx:

```hlsl
struct PixelShaderInput
{
    float4 pos : SV_POSITION;
};

float4 SimplePixelShader(PixelShaderInput input) : SV_TARGET
{
    // Draw the entire triangle yellow.
    return float4(1.0f, 1.0f, 0.0f, 1.0f);
}
```

### Y. Xxxxxxx xxxx xxxx xxxx

Xx xxx xxx XX::XxxxXxxxXxxxx xxxxxxxx xxxx XxxxxxXXxxxxx.x xx xxx XxxxxxX YY Xxx (Xxxxxxxxx Xxxxxxx) xxxxxxxx xx xxxxxxxxxxxxxx xxxx xxxx xxxx x xxxx xx xxx xxxx.

### Y. Xxxxxxxx xxxxxx xxx xxxxx xxxxxxx

Xx xxxx xxxx xxxx xxx XxxxxxXxxxxxXxxxxx.xxx xxxx xxx xxxxxx xxx xxxx xx xxx *xxxxxxXxxxxxXxxxxxxx* xxxx xxxxx. Xx xxxx [**XXYXYYXxxxxx::XxxxxxXxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476524) xxxx xxx xxxx xxxxx xx xxxxxx xxx xxxxxx xxxxxx ([**XXYXYYXxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476641)). Xx xxx xxx xxxxxx xxxxx xxxxx xx Y.Y xx xxx XxxxxxXxxxxxXxxxxx.xxxx xxxxxx xx xxxxxxxxx xxxx xxx xxxxxxxx xx xxxxx. Xx xxxxxxxx xx xxxxx xx [**XYXYY\_XXXXX\_XXXXXXX\_XXXX**](https://msdn.microsoft.com/library/windows/desktop/ff476180) xxxxxxxxxx xx xxxxxxxx xxx xxxxxx xx xxx xxxxxx xxxxxx xxxx xxx xxxx xxxx [**XXYXYYXxxxxx::XxxxxxXxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476512) xx xxxxxx xxx xxxxxx. Xxx xxxxx xxx xxx xxxxxx xxxxxxx xxxx xxxxxxx xxx xxxxxx xxxxxxxx. Xx xxxx xxxx xxxx xxx XxxxxxXxxxxXxxxxx.xxx xxxx xxx xxxxxx xxx xxxx xx xxx *xxxxxXxxxxxXxxxxxxx* xxxx xxxxx. Xx xxxx [**XXYXYYXxxxxx::XxxxxxXxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476513) xxxx xxx xxxx xxxxx xx xxxxxx xxx xxxxx xxxxxx ([**XXYXYYXxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476576)). Xx xxx xxx xxxxx xxxxx xx (Y,Y,Y,Y) xx xxx XxxxxxXxxxxXxxxxx.xxxx xxxxxx xx xxxx xxx xxxxxxxx xxxxxx. Xxx xxx xxxxxx xxx xxxxx xx xxxxxxxx xxxx xxxxx.

Xx xxxxxx xxxxxx xxx xxxxx xxxxxxx xxxx xxxxxx x xxxxxx xxxxxxxx. Xx xx xxxx, xx xxxxx xxxxxx xxx xxxxxxxx, xxxx xxxxxxxx xxx xxxxxx xxx xxxxx xxxxxxx ([**XYXYY\_XXXXXX\_XXXX**](https://msdn.microsoft.com/library/windows/desktop/ff476092) xxx [**XYXYY\_XXXXXXXXXXX\_XXXX**](https://msdn.microsoft.com/library/windows/desktop/ff476220)) xxxxx xxx xxxxxxxx xxxxxxxxxx, xxx xxxxxxx xxxx [**XXYXYYXxxxxx::XxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476501) xxxx xxx xxxx xxxxxx.

```cpp
        auto loadVSTask = DX::ReadDataAsync(L"SimpleVertexShader.cso");
        auto loadPSTask = DX::ReadDataAsync(L"SimplePixelShader.cso");
        
        // Load the raw vertex shader bytecode from disk and create a vertex shader with it.
        auto createVSTask = loadVSTask.then([this](const std::vector<byte>& vertexShaderBytecode) {


          ComPtr<ID3D11VertexShader> vertexShader;
          DX::ThrowIfFailed(
              m_d3dDevice->CreateVertexShader(
                  vertexShaderBytecode->Data,
                  vertexShaderBytecode->Length,
                  nullptr,
                  &vertexShader
                  )
              );

          // Create an input layout that matches the layout defined in the vertex shader code.
          // For this lesson, this is simply a DirectX::XMFLOAT2 vector defining the vertex position.
          const D3D11_INPUT_ELEMENT_DESC basicVertexLayoutDesc[] =
          {
              { "POSITION", 0, DXGI_FORMAT_R32G32_FLOAT, 0, 0, D3D11_INPUT_PER_VERTEX_DATA, 0 },
          };

          ComPtr<ID3D11InputLayout> inputLayout;
          DX::ThrowIfFailed(
              m_d3dDevice->CreateInputLayout(
                  basicVertexLayoutDesc,
                  ARRAYSIZE(basicVertexLayoutDesc),
                  vertexShaderBytecode->Data,
                  vertexShaderBytecode->Length,
                  &inputLayout
                  )
              );
        });
        
        // Load the raw pixel shader bytecode from disk and create a pixel shader with it.
        auto createPSTask = loadPSTask.then([this](const std::vector<byte>& pixelShaderBytecode) {
          ComPtr<ID3D11PixelShader> pixelShader;
          DX::ThrowIfFailed(
              m_d3dDevice->CreatePixelShader(
                  pixelShaderBytecode->Data,
                  pixelShaderBytecode->Length,
                  nullptr,
                  &pixelShader
                  )
              );
        });

        // Create vertex and index buffers that define a simple triangle.
        auto createTriangleTask = (createPSTask && createVSTask).then([this] () {

          DirectX::XMFLOAT2 triangleVertices[] =
          {
              float2(-0.5f, -0.5f),
              float2( 0.0f,  0.5f),
              float2( 0.5f, -0.5f),
          };

          unsigned short triangleIndices[] =
          {
              0, 1, 2,
          };

          D3D11_BUFFER_DESC vertexBufferDesc = {0};
          vertexBufferDesc.ByteWidth = sizeof(float2) * ARRAYSIZE(triangleVertices);
          vertexBufferDesc.Usage = D3D11_USAGE_DEFAULT;
          vertexBufferDesc.BindFlags = D3D11_BIND_VERTEX_BUFFER;
          vertexBufferDesc.CPUAccessFlags = 0;
          vertexBufferDesc.MiscFlags = 0;
          vertexBufferDesc.StructureByteStride = 0;

          D3D11_SUBRESOURCE_DATA vertexBufferData;
          vertexBufferData.pSysMem = triangleVertices;
          vertexBufferData.SysMemPitch = 0;
          vertexBufferData.SysMemSlicePitch = 0;

          ComPtr<ID3D11Buffer> vertexBuffer;
          DX::ThrowIfFailed(
              m_d3dDevice->CreateBuffer(
                  &vertexBufferDesc,
                  &vertexBufferData,
                  &vertexBuffer
                  )
              );

          D3D11_BUFFER_DESC indexBufferDesc;
          indexBufferDesc.ByteWidth = sizeof(unsigned short) * ARRAYSIZE(triangleIndices);
          indexBufferDesc.Usage = D3D11_USAGE_DEFAULT;
          indexBufferDesc.BindFlags = D3D11_BIND_INDEX_BUFFER;
          indexBufferDesc.CPUAccessFlags = 0;
          indexBufferDesc.MiscFlags = 0;
          indexBufferDesc.StructureByteStride = 0;

          D3D11_SUBRESOURCE_DATA indexBufferData;
          indexBufferData.pSysMem = triangleIndices;
          indexBufferData.SysMemPitch = 0;
          indexBufferData.SysMemSlicePitch = 0;

          ComPtr<ID3D11Buffer> indexBuffer;
          DX::ThrowIfFailed(
              m_d3dDevice->CreateBuffer(
                  &indexBufferDesc,
                  &indexBufferData,
                  &indexBuffer
                  )
              );
        });
```

Xx xxx xxx xxxxxx xxx xxxxx xxxxxxx, xxx xxxxxx xxxxxx xxxxxx, xxx xxx xxxxxx xxx xxxxx xxxxxxx xx xxxx x xxxxxx xxxxxxxx.

### Y. Xxxxxxx xxx xxxxxxxx xxx xxxxxxxxxx xxx xxxxxxxx xxxxx

Xx xxxxx xx xxxxxxx xxxx xx xxxxxxxxxxx xxxxxx xxx xxxxxxx xxx xxxxx. Xx xxxx [**XXYXYYXxxxxxXxxxxxx::XXXxxXxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476464) xx xxxxxxx xxx xxxxxx xxxxxx xx xxx xxxxxx xxxxxx. Xx xxxx [**XXYXYYXxxxxxXxxxxxx::XxxxxXxxxxxXxxxxxXxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476388) xxxx { Y.YYYx, Y.YYx, Y.YYYx, Y.Yx } xx xxxxx xxx xxxxxx xxxxxx xx x xxxxx xxxx xxxxx.

Xx xxx xxxxxxx xxxx, xx xxxx x xxxxxx xxxxxxxx xx xxx xxxx xxxxxxx.

**Xx xxxx x xxxxxx xxxxxxxx**

1.  Xxxxx, xx xxxx [**XXYXYYXxxxxxXxxxxxx::XXXxxXxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476454) xx xxxxxxxx xxx xxxxxx xxxxxx xxxx xx xxxxxxxx xxxx xxx xxxxx-xxxxxxxxx xxxxx.
2.  Xxxx, xx xxxx [**XXYXYYXxxxxxXxxxxxx::XXXxxXxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476456) xxx [**XXYXYYXxxxxxXxxxxxx::XXXxxXxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476453) xx xxxx xxx xxxxxx xxx xxxxx xxxxxxx xx xxx xxxxx-xxxxxxxxx xxxxx.
3.  Xxxx, xx xxxx [**XXYXYYXxxxxxXxxxxxx::XXXxxXxxxxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476455) xxxx xxx [**XYXYY\_XXXXXXXXX\_XXXXXXXX\_XXXXXXXXXXXXX**](https://msdn.microsoft.com/library/windows/desktop/ff476189#D3D11_PRIMITIVE_TOPOLOGY_TRIANGLESTRIP) xxxxx xx xxxxxxx xxx xxx xxxxx-xxxxxxxxx xxxxx xx xxxxxxxxx xxx xxxxxx xxxx xx x xxxxxxxx xxxxx.
4.  Xxxx, xx xxxx [**XXYXYYXxxxxxXxxxxxx::XXXxxXxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476493) xx xxxxxxxxxx xxx xxxxxx xxxxxx xxxxx xxxx xxx xxxxxx xxxxxx xxxx xxx [**XXYXYYXxxxxxXxxxxxx::XXXxxXxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476472) xx xxxxxxxxxx xxx xxxxx xxxxxx xxxxx xxxx xxx xxxxx xxxxxx xxxx.
5.  Xxxxxxx, xx xxxx [**XXYXYYXxxxxxXxxxxxx::XxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476409) xx xxxx xxx xxxxxxxx xxx xxxxxx xx xx xxx xxxxxxxxx xxxxxxxx.

Xx xxxx [**XXXXXXxxxXxxxx::Xxxxxxx**](https://msdn.microsoft.com/library/windows/desktop/bb174576) xx xxxxxxx xxx xxxxxxxx xxxxx xx xxx xxxxxx.

```cpp
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

            m_d3dDeviceContext->IASetInputLayout(inputLayout.Get());

            // Set the vertex and index buffers, and specify the way they define geometry.
            UINT stride = sizeof(float2);
            UINT offset = 0;
            m_d3dDeviceContext->IASetVertexBuffers(
                0,
                1,
                vertexBuffer.GetAddressOf(),
                &stride,
                &offset
                );

            m_d3dDeviceContext->IASetIndexBuffer(
                indexBuffer.Get(),
                DXGI_FORMAT_R16_UINT,
                0
                );

            m_d3dDeviceContext->IASetPrimitiveTopology(D3D11_PRIMITIVE_TOPOLOGY_TRIANGLELIST);

            // Set the vertex and pixel shader stage state.
            m_d3dDeviceContext->VSSetShader(
                vertexShader.Get(),
                nullptr,
                0
                );

            m_d3dDeviceContext->PSSetShader(
                pixelShader.Get(),
                nullptr,
                0
                );

            // Draw the cube.
            m_d3dDeviceContext->DrawIndexed(
                ARRAYSIZE(triangleIndices),
                0,
                0
                );

            // Present the rendered image to the window.  Because the maximum frame latency is set to 1,
            // the render loop will generally be throttled to the screen refresh rate, typically around
            // 60 Hz, by sleeping the application on Present until the screen is refreshed.
            DX::ThrowIfFailed(
                m_swapChain->Present(1, 0)
                );
```

## Xxxxxxx xxx xxxx xxxxx


Xx xxxxxxx xxx xxxx x xxxxxx xxxxxxxx xx xxxxx xxxxxx xxx xxxxx xxxxxxx.

Xxxx, xx xxxxxx xx xxxxxxxx YX xxxx xxx xxxxx xxxxxxxx xxxxxxx xx xx.

[Xxxxx xxxxx xxx xxxxxxx xx xxxxxxxxxx](using-depth-and-effects-on-primitives.md)

 

 




<!--HONumber=Mar16_HO1-->
