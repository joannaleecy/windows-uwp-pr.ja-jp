---
xxxxx: Xxx xxxxx xxx xxxxxxx xx xxxxxxxxxx
xxxxxxxxxxx: Xxxx, xx xxxx xxx xxx xx xxx xxxxx, xxxxxxxxxxx, xxxxx, xxx xxxxx xxxxxxx xx xxxxxxxxxx.
xx.xxxxxxx: YYxxYYxY-xYxY-xxxx-YYYY-xYYxxYYYYYYx
---

# Xxx xxxxx xxx xxxxxxx xx xxxxxxxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

Xxxx, xx xxxx xxx xxx xx xxx xxxxx, xxxxxxxxxxx, xxxxx, xxx xxxxx xxxxxxx xx xxxxxxxxxx.

**Xxxxxxxxx:** Xx xxxxxx x YX xxxxxx xxx xxxxx xxxxx xxxxxx xxxxxxxx xxx xxxxxxxx xx xx.

## Xxxxxxxxxxxxx


Xx xxxxxx xxxx xxx xxx xxxxxxxx xxxx X++. Xxx xxxx xxxx xxxxx xxxxxxxxxx xxxx xxxxxxxx xxxxxxxxxxx xxxxxxxx.

Xx xxxx xxxxxx xxxx xxx xxxx xxxxxxx [Xxxxxxxxxx: xxxxxxx xx XxxxxxX xxxxxxxxx xxx xxxxxxxxxx xx xxxxx](setting-up-directx-resources.md) xxx [Xxxxxxxx xxxxxxx xxx xxxxxxx xxxxxxxxxx](creating-shaders-and-drawing-primitives.md).

**Xxxx xx xxxxxxxx:** YY xxxxxxx.

Xxxxxxxxxxxx
------------

### Y. Xxxxxxxx xxxx xxxxxxxxx

Xxxxx, xx xxxx xx xxxxxx xxx **XxxxxxXxxxXxxxxx** xxx **XxxxxxxxXxxxxx** xxxxxxxxxx xxx xxx xxxx. Xxxxx xxxxxxxxxx xxxxxxx xxx xxxxxx xxxxxxxxx xxx xxxxxx xxx xxx xxxx xxx xxx xxx xxxx xxxx xx xxxxxx. Xx xxxxxxx [**XXYXYYXxxxxXxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476377) xxx [**XXYXYYXxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476351) xxxx [**XxxXxx**](https://msdn.microsoft.com/library/windows/apps/br244983.aspx) xxx xxxxxxx xx xxxxxxxx xx **XxxxxxxxXxxxxx**.

```cpp
struct SimpleCubeVertex
{
    DirectX::XMFLOAT3 pos;   // Position
    DirectX::XMFLOAT3 color; // Color
};

struct ConstantBuffer
{
    DirectX::XMFLOAT4X4 model;
    DirectX::XMFLOAT4X4 view;
    DirectX::XMFLOAT4X4 projection;
};

// This class defines the application as a whole.
ref class Direct3DTutorialFrameworkView : public IFrameworkView
{
private:
    Platform::Agile<CoreWindow> m_window;
    ComPtr<IDXGISwapChain1> m_swapChain;
    ComPtr<ID3D11Device1> m_d3dDevice;
    ComPtr<ID3D11DeviceContext1> m_d3dDeviceContext;
    ComPtr<ID3D11RenderTargetView> m_renderTargetView;
    ComPtr<ID3D11DepthStencilView> m_depthStencilView;
    ComPtr<ID3D11Buffer> m_constantBuffer;
    ConstantBuffer m_constantBufferData;
```

### Y. Xxxxxxxx x xxxxx xxxxxxx xxxx

Xx xxxxxxxx xx xxxxxxxx xxx xxxxxx-xxxxxx xxxx, xx xxxx xxxxxx x xxxxx-xxxxxxx xxxx. Xxx xxxxx-xxxxxxx xxxx xxxxxxx XxxxxxYX xx xxxxxxxxxxx xxxxxx xxxxxxx xxxxxx xx xxx xxxxxx xx xxxxx xx xxxxxxx xxxxxxx xxxx xxx xxxxxx. Xxxxxx xx xxx xxxxxx x xxxx xx x xxxxx-xxxxxxx xxxxxx, xx xxxx xxxxxx xxx xxxxx-xxxxxxx xxxxxx. Xx xxxxxxxx x [**XYXYY\_XXXXXXXYX\_XXXX**](https://msdn.microsoft.com/library/windows/desktop/ff476253) xx xxxxxxxx xxx xxxxx-xxxxxxx xxxxxx xxx xxxx xxxx [**XXYXYYXxxxxx::XxxxxxXxxxxxxYX**](https://msdn.microsoft.com/library/windows/desktop/ff476521) xx xxxxxx xxx xxxxx-xxxxxxx xxxxxx. Xx xxxxxx xxx xxxxx-xxxxxxx xxxx, xx xxxxxxxx x [**XYXYY\_XXXXX\_XXXXXXX\_XXXX\_XXXX**](https://msdn.microsoft.com/library/windows/desktop/ff476112) xx xxxxxxxx xxx xxxxx-xxxxxxx xxxx xxx xxxx xxx xxxxx-xxxxxxx xxxx xxxxxxxxxxx xxx xxx xxxxx-xxxxxxx xxxxxx xx [**XXYXYYXxxxxx::XxxxxxXxxxxXxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476507).

```cpp
        // Once the render target view is created, create a depth stencil view.  This
        // allows Direct3D to efficiently render objects closer to the camera in front
        // of objects further from the camera.

        D3D11_TEXTURE2D_DESC backBufferDesc = {0};
        backBuffer->GetDesc(&backBufferDesc);

        D3D11_TEXTURE2D_DESC depthStencilDesc;
        depthStencilDesc.Width = backBufferDesc.Width;
        depthStencilDesc.Height = backBufferDesc.Height;
        depthStencilDesc.MipLevels = 1;
        depthStencilDesc.ArraySize = 1;
        depthStencilDesc.Format = DXGI_FORMAT_D24_UNORM_S8_UINT;
        depthStencilDesc.SampleDesc.Count = 1;
        depthStencilDesc.SampleDesc.Quality = 0;
        depthStencilDesc.Usage = D3D11_USAGE_DEFAULT;
        depthStencilDesc.BindFlags = D3D11_BIND_DEPTH_STENCIL;
        depthStencilDesc.CPUAccessFlags = 0;
        depthStencilDesc.MiscFlags = 0;
        ComPtr<ID3D11Texture2D> depthStencil;
        DX::ThrowIfFailed(
            m_d3dDevice->CreateTexture2D(
                &depthStencilDesc,
                nullptr,
                &depthStencil
                )
            );

        D3D11_DEPTH_STENCIL_VIEW_DESC depthStencilViewDesc;
        depthStencilViewDesc.Format = depthStencilDesc.Format;
        depthStencilViewDesc.ViewDimension = D3D11_DSV_DIMENSION_TEXTURE2D;
        depthStencilViewDesc.Flags = 0;
        depthStencilViewDesc.Texture2D.MipSlice = 0;
        DX::ThrowIfFailed(
            m_d3dDevice->CreateDepthStencilView(
                depthStencil.Get(),
                &depthStencilViewDesc,
                &m_depthStencilView
                )
            );
```

### Y. Xxxxxxxx xxxxxxxxxxx xxxx xxx xxxxxx

Xx xxxxxx xxx xxxxxxxxxxx xxxxxxxxxx xxxxxxxxxx xxx xxx xxxxxxxx xxxxxx xxxxxxxxx xx xxx xxxxxx xxxxxxxxxx. Xx xxx xxx xxxxxxxxxx xx x YY-xxxxxx xxxxx xx xxxx xxxx x xxxxx xxxxx xx Y.YY xx YYY.

```cpp
        // Finally, update the constant buffer perspective projection parameters
        // to account for the size of the application window.  In this sample,
        // the parameters are fixed to a 70-degree field of view, with a depth
        // range of 0.01 to 100.  For a generalized camera class, see Lesson 5.

        float xScale = 1.42814801f;
        float yScale = 1.42814801f;
        if (backBufferDesc.Width > backBufferDesc.Height)
        {
            xScale = yScale *
                static_cast<float>(backBufferDesc.Height) /
                static_cast<float>(backBufferDesc.Width);
        }
        else
        {
            yScale = xScale *
                static_cast<float>(backBufferDesc.Width) /
                static_cast<float>(backBufferDesc.Height);
        }

        m_constantBufferData.projection = DirectX::XMFLOAT4X4(
            xScale, 0.0f,    0.0f,  0.0f,
            0.0f,   yScale,  0.0f,  0.0f,
            0.0f,   0.0f,   -1.0f, -0.01f,
            0.0f,   0.0f,   -1.0f,  0.0f
            );
```

### Y. Xxxxxxxx xxxxxx xxx xxxxx xxxxxxx xxxx xxxxx xxxxxxxx

Xx xxxx xxx, xx xxxxxx xxxx xxxxxxx xxxxxx xxx xxxxx xxxxxxx xxxx xxxx xx xxxxxxxxx xx xxx xxxxxxxx xxxxxxxx, [Xxxxxxxx xxxxxxx xxx xxxxxxx xxxxxxxxxx](creating-shaders-and-drawing-primitives.md). Xxx xxx'x xxxxxx xxxxxx xxxxxxxxxx xxxx xxxxxx xxxxxxxx xxxx xxxxxxxxxx xxxxx xxx xxxxxx xxx xxxxxx xxxxx xxxxxxx xx xxx xxxxx xxxxxx.

Xxx xxx'x xxxxx xx [**XYXYY\_XXXXX\_XXXXXXX\_XXXX**](https://msdn.microsoft.com/library/windows/desktop/ff476180) xxxxxxxxxx xxxx xxxxxxxx xxx xxxxxx xx xxx xxxxxx xxxxxx xxxx xxx xxx xxxxxx xxxxxxxx: xxx xxxxxxx xxxxxxx xxx xxxxxx xxxxxxxx xxx xxx xxxxx xxxxxxx xxxxxxx xxx xxxxx.

Xx xxxxxx xxxxxx, xxxxx, xxx xxxxxxxx xxxxxxx xx xxxxxx xx xxxxxxxx xxxx.

**Xx xxxxxx xx xxxxxxxx xxxx**

1.  Xxxxx, xx xxxxxx xxx xxxx. Xx xxxxxx xxxx xxxxxx x xxxxx xx xxxxxxxx xx x xxxxxxxx. Xxxx xxxxxx xxx xxxxx xxxxxx xx xxxxx xxxx xxxx xxxxxxxxxxx xx xxx xxxx xxx xx xxxxxxxxxxxxx.
2.  Xxxx, xx xxxxxxxx xxx xxxxxx xxx xxxxx xxxxxxx ([**XYXYY\_XXXXXX\_XXXX**](https://msdn.microsoft.com/library/windows/desktop/ff476092) xxx [**XYXYY\_XXXXXXXXXXX\_XXXX**](https://msdn.microsoft.com/library/windows/desktop/ff476220)) xxxxx xxx xxxx xxxxxxxxxx. Xx xxxx [**XXYXYYXxxxxx::XxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476501) xxxx xxx xxxx xxxxxx.
3.  Xxxx, xx xxxxxx x xxxxxxxx xxxxxx ([**XYXYY\_XXXXXX\_XXXX**](https://msdn.microsoft.com/library/windows/desktop/ff476092)) xxx xxxxxxx xxxxx, xxxx, xxx xxxxxxxxxx xxxxxxxx xx xxx xxxxxx xxxxxx. Xx xxx xxxxx xxx xxx xxxxxxxx xxxxxx xx xxxxxx xxx xxxx xxx xxxxx x xxxxxxxxxxx xxxxxxxxxx xx xx. Xx xxxx [**XXYXYYXxxxxx::XxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476501) xx xxxxxx xxx xxxxxxxx xxxxxx.
4.  Xxxx, xx xxxxxxx xxx xxxx xxxxxxxxx xxxx xxxxxxxxxxx xx x xxxxxx xxxxxxxx xx X = Y, X = Y, X = Y.
5.  Xxxxxxx, xx xxxxxxx x *xxxxxx* xxxxxxxx xxxx xx xxxx xxx xx xxxxxxx xxx xxxx xx xxxxxxxx xx xxxxx xxxxx.

```cpp
        
        auto loadVSTask = DX::ReadDataAsync(L"SimpleVertexShader.cso");
        auto loadPSTask = DX::ReadDataAsync(L"SimplePixelShader.cso");
        
        
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
          // For this lesson, this is simply a DirectX::XMFLOAT3 vector defining the vertex position, and
          // a DirectX::XMFLOAT3 vector defining the vertex color.
          const D3D11_INPUT_ELEMENT_DESC basicVertexLayoutDesc[] =
          {
              { "POSITION", 0, DXGI_FORMAT_R32G32B32_FLOAT, 0,  0, D3D11_INPUT_PER_VERTEX_DATA, 0 },
              { "COLOR",    0, DXGI_FORMAT_R32G32B32_FLOAT, 0, 12, D3D11_INPUT_PER_VERTEX_DATA, 0 },
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
        
        
        // Create vertex and index buffers that define a simple unit cube.
        auto createCubeTask = (createPSTask && createVSTask).then([this] () {

          // In the array below, which will be used to initialize the cube vertex buffers,
          // each vertex is assigned a color in addition to a position.  This will allow
          // the pixel shader to color each face differently, enabling them to be distinguished.
          SimpleCubeVertex cubeVertices[] =
          {
              { float3(-0.5f, 0.5f, -0.5f), float3(0.0f, 1.0f, 0.0f) }, // +Y (top face)
              { float3( 0.5f, 0.5f, -0.5f), float3(1.0f, 1.0f, 0.0f) },
              { float3( 0.5f, 0.5f,  0.5f), float3(1.0f, 1.0f, 1.0f) },
              { float3(-0.5f, 0.5f,  0.5f), float3(0.0f, 1.0f, 1.0f) },

              { float3(-0.5f, -0.5f,  0.5f), float3(0.0f, 0.0f, 1.0f) }, // -Y (bottom face)
              { float3( 0.5f, -0.5f,  0.5f), float3(1.0f, 0.0f, 1.0f) },
              { float3( 0.5f, -0.5f, -0.5f), float3(1.0f, 0.0f, 0.0f) },
              { float3(-0.5f, -0.5f, -0.5f), float3(0.0f, 0.0f, 0.0f) },
          };

          unsigned short cubeIndices[] =
          {
              0, 1, 2,
              0, 2, 3,

              4, 5, 6,
              4, 6, 7,

              3, 2, 5,
              3, 5, 4,

              2, 1, 6,
              2, 6, 5,

              1, 7, 6,
              1, 0, 7,

              0, 3, 4,
              0, 4, 7
          };

          D3D11_BUFFER_DESC vertexBufferDesc = {0};
          vertexBufferDesc.ByteWidth = sizeof(SimpleCubeVertex) * ARRAYSIZE(cubeVertices);
          vertexBufferDesc.Usage = D3D11_USAGE_DEFAULT;
          vertexBufferDesc.BindFlags = D3D11_BIND_VERTEX_BUFFER;
          vertexBufferDesc.CPUAccessFlags = 0;
          vertexBufferDesc.MiscFlags = 0;
          vertexBufferDesc.StructureByteStride = 0;

          D3D11_SUBRESOURCE_DATA vertexBufferData;
          vertexBufferData.pSysMem = cubeVertices;
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
          indexBufferDesc.ByteWidth = sizeof(unsigned short) * ARRAYSIZE(cubeIndices);
          indexBufferDesc.Usage = D3D11_USAGE_DEFAULT;
          indexBufferDesc.BindFlags = D3D11_BIND_INDEX_BUFFER;
          indexBufferDesc.CPUAccessFlags = 0;
          indexBufferDesc.MiscFlags = 0;
          indexBufferDesc.StructureByteStride = 0;

          D3D11_SUBRESOURCE_DATA indexBufferData;
          indexBufferData.pSysMem = cubeIndices;
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


          // Create a constant buffer for passing model, view, and projection matrices
          // to the vertex shader.  This will allow us to rotate the cube and apply
          // a perspective projection to it.

          D3D11_BUFFER_DESC constantBufferDesc = {0};
          constantBufferDesc.ByteWidth = sizeof(m_constantBufferData);
          constantBufferDesc.Usage = D3D11_USAGE_DEFAULT;
          constantBufferDesc.BindFlags = D3D11_BIND_CONSTANT_BUFFER;
          constantBufferDesc.CPUAccessFlags = 0;
          constantBufferDesc.MiscFlags = 0;
          constantBufferDesc.StructureByteStride = 0;
          DX::ThrowIfFailed(
              m_d3dDevice->CreateBuffer(
                  &constantBufferDesc,
                  nullptr,
                  &m_constantBuffer
                  )
              );

          // Specify the view transform corresponding to a camera position of
          // X = 0, Y = 1, Z = 2.  For a generalized camera class, see Lesson 5.

          m_constantBufferData.view = DirectX::XMFLOAT4X4(
              -1.00000000f, 0.00000000f,  0.00000000f,  0.00000000f,
               0.00000000f, 0.89442718f,  0.44721359f,  0.00000000f,
               0.00000000f, 0.44721359f, -0.89442718f, -2.23606800f,
               0.00000000f, 0.00000000f,  0.00000000f,  1.00000000f
              );

        });
        
        // This value will be used to animate the cube by rotating it every frame.
        float degree = 0.0f;
        
```

### Y. Xxxxxxxx xxx xxxxxxx xxx xxxx xxx xxxxxxxxxx xxx xxxxxxxx xxxxx

Xx xxxxx xx xxxxxxx xxxx xx xxxxxxxxxxx xxxxxx xxx xxxxxxx xxx xxxxx. Xx xxxx xxx **xxxxxxxxX** xxxxxx xxxxxxxx (XxxxxXxxx.x) xxxx x xxxxxxxx xxxxxx xx xxx xxxxxx xxxx xxxx xxxxxx xxx xxxx’x xxxxx xxxxxx xxxxxx xxx X xxxx. Xx xxxx xxxx [**XXYXYYXxxxxxXxxxxxx::XxxxxxXxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476486) xx xxxxxx xxx xxxxxxxx xxxxxx xxx xxxxxx xxx xxxx xxxxx. Xx xxxx [**XXYXYYXxxxxxXxxxxxx::XXXxxXxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476464) xx xxxxxxx xxx xxxxxx xxxxxx xx xxx xxxxxx xxxxxx. Xx xxxx **XXXxxXxxxxxXxxxxxx** xxxx, xx xxxx xxx xxxxx-xxxxxxx xxxx. Xx xxxx [**XXYXYYXxxxxxXxxxxxx::XxxxxXxxxxxXxxxxxXxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476388) xx xxxxx xxx xxxxxx xxxxxx xx x xxxxx xxxx xxxxx xxx xxxx [**XXYXYYXxxxxxXxxxxxx::XxxxxXxxxxXxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476387) xx xxxxx xxx xxxxx xxxxxx.

Xx xxx xxxxxxx xxxx, xx xxxx xxxx xxx xxxx xx xxx xxxx xxxxxxx.

**Xx xxxx xxx xxxx**

1.  Xxxxx, xx xxxx [**XXYXYYXxxxxxXxxxxxx::XXXxxXxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476454) xx xxxxxxxx xxx xxxxxx xxxxxx xxxx xx xxxxxxxx xxxx xxx xxxxx-xxxxxxxxx xxxxx.
2.  Xxxx, xx xxxx [**XXYXYYXxxxxxXxxxxxx::XXXxxXxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476456) xxx [**XXYXYYXxxxxxXxxxxxx::XXXxxXxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476453) xx xxxx xxx xxxxxx xxx xxxxx xxxxxxx xx xxx xxxxx-xxxxxxxxx xxxxx.
3.  Xxxx, xx xxxx [**XXYXYYXxxxxxXxxxxxx::XXXxxXxxxxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476455) xxxx xxx [**XYXYY\_XXXXXXXXX\_XXXXXXXX\_XXXXXXXXXXXXX**](https://msdn.microsoft.com/library/windows/desktop/ff476189#D3D11_PRIMITIVE_TOPOLOGY_TRIANGLESTRIP) xxxxx xx xxxxxxx xxx xxx xxxxx-xxxxxxxxx xxxxx xx xxxxxxxxx xxx xxxxxx xxxx xx x xxxxxxxx xxxxx.
4.  Xxxx, xx xxxx [**XXYXYYXxxxxxXxxxxxx::XXXxxXxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476493) xx xxxxxxxxxx xxx xxxxxx xxxxxx xxxxx xxxx xxx xxxxxx xxxxxx xxxx xxx [**XXYXYYXxxxxxXxxxxxx::XXXxxXxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476472) xx xxxxxxxxxx xxx xxxxx xxxxxx xxxxx xxxx xxx xxxxx xxxxxx xxxx.
5.  Xxxx, xx xxxx [**XXYXYYXxxxxxXxxxxxx::XXXxxXxxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476491) xx xxx xxx xxxxxxxx xxxxxx xxxx xx xxxx xx xxx xxxxxx xxxxxx xxxxxxxx xxxxx.
6.  Xxxxxxx, xx xxxx [**XXYXYYXxxxxxXxxxxxx::XxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476409) xx xxxx xxx xxxx xxx xxxxxx xx xx xxx xxxxxxxxx xxxxxxxx.

Xx xxxx [**XXXXXXxxxXxxxx::Xxxxxxx**](https://msdn.microsoft.com/library/windows/desktop/bb174576) xx xxxxxxx xxx xxxxxxxx xxxxx xx xxx xxxxxx.

```cpp
            // Update the constant buffer to rotate the cube model.
            m_constantBufferData.model = XMMatrixRotationY(-degree);
            degree += 1.0f;

            m_d3dDeviceContext->UpdateSubresource(
                m_constantBuffer.Get(),
                0,
                nullptr,
                &m_constantBufferData,
                0,
                0
                );

            // Specify the render target and depth stencil we created as the output target.
            m_d3dDeviceContext->OMSetRenderTargets(
                1,
                m_renderTargetView.GetAddressOf(),
                m_depthStencilView.Get()
                );

            // Clear the render target to a solid color, and reset the depth stencil.
            const float clearColor[4] = { 0.071f, 0.04f, 0.561f, 1.0f };
            m_d3dDeviceContext->ClearRenderTargetView(
                m_renderTargetView.Get(),
                clearColor
                );

            m_d3dDeviceContext->ClearDepthStencilView(
                m_depthStencilView.Get(),
                D3D11_CLEAR_DEPTH,
                1.0f,
                0
                );

            m_d3dDeviceContext->IASetInputLayout(inputLayout.Get());

            // Set the vertex and index buffers, and specify the way they define geometry.
            UINT stride = sizeof(SimpleCubeVertex);
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

            m_d3dDeviceContext->VSSetConstantBuffers(
                0,
                1,
                m_constantBuffer.GetAddressOf()
                );

            m_d3dDeviceContext->PSSetShader(
                pixelShader.Get(),
                nullptr,
                0
                );

            // Draw the cube.
            m_d3dDeviceContext->DrawIndexed(
                ARRAYSIZE(cubeIndices),
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


Xx xxxx xxxxx, xxxxxxxxxxx, xxxxx, xxx xxxxx xxxxxxx xx xxxxxxxxxx.

Xxxx, xx xxxxx xxxxxxxx xx xxxxxxxxxx.

[Xxxxxxxx xxxxxxxx xx xxxxxxxxxx](applying-textures-to-primitives.md)

 

 




<!--HONumber=Mar16_HO1-->
