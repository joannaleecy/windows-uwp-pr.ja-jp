---
xxxxx: Xxxxx xxxxxxxx xx xxxxxxxxxx
xxxxxxxxxxx: Xxxx, xx xxxx xxx xxxxxxx xxxx xxx xxxxx xxxx xxxx xx x YX xxxxxxxxx xx xxxxx xxx xxxx xxxx xx xxxxxxx xx Xxxxx xxxxx xxx xxxxxxx xx xxxxxxxxxx.
xx.xxxxxxx: xxxxYYxY-xYYx-YxxY-xYxY-xYxYxxxYxYxY
---

# Xxxxx xxxxxxxx xx xxxxxxxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

Xxxx, xx xxxx xxx xxxxxxx xxxx xxx xxxxx xxxx xxxx xx x YX xxxxxxxxx xx xxxxx xxx xxxx xxxx xx xxxxxxx xx [Xxxxx xxxxx xxx xxxxxxx xx xxxxxxxxxx](using-depth-and-effects-on-primitives.md). Xx xxxx xxxxxxxxx x xxxxxx xxx-xxxxxxx xxxxxxxx xxxxx, xxxxx xxx xxxx xxxxxxxx xxx xxxxxxx xx xxxxxx xxxxx xx xxxxx xxxxxxxx xxx xxxxx xxxxxxxx xx x xxxxx xxxxxx.

**Xxxxxxxxx:** Xx xxxxx xxxxxxxx xx xxxxxxxxxx.

## Xxxxxxxxxxxxx


Xx xxxxxx xxxx xxx xxx xxxxxxxx xxxx X++. Xxx xxxx xxxx xxxxx xxxxxxxxxx xxxx xxxxxxxx xxxxxxxxxxx xxxxxxxx.

Xx xxxx xxxxxx xxxx xxx xxxx xxxxxxx [Xxxxxxxxxx: xxxxxxx xx XxxxxxX xxxxxxxxx xxx xxxxxxxxxx xx xxxxx](setting-up-directx-resources.md), [Xxxxxxxx xxxxxxx xxx xxxxxxx xxxxxxxxxx](creating-shaders-and-drawing-primitives.md), xxx [Xxxxx xxxxx xxx xxxxxxx xx xxxxxxxxxx](using-depth-and-effects-on-primitives.md).

**Xxxx xx xxxxxxxx:** YY xxxxxxx.

Xxxxxxxxxxxx
------------

### Y. Xxxxxxxx xxxxxxxxx xxx x xxxxxxxx xxxx

Xxxxx, xx xxxx xx xxxxxx xxx **XxxxxXxxxxx** xxx **XxxxxxxxXxxxxx** xxxxxxxxxx xxx xxx xxxxxxxx xxxx. Xxxxx xxxxxxxxxx xxxxxxx xxx xxxxxx xxxxxxxxx, xxxxxxxxxxxx, xxx xxxxxxxx xxx xxx xxxx xxx xxx xxx xxxx xxxx xx xxxxxx. Xxxxxxxxx, xx xxxxxxx xxxxxxxxx xxxxxxxxx xx xxx xxxxxxxx xxxxxxxx, [Xxxxx xxxxx xxx xxxxxxx xx xxxxxxxxxx](using-depth-and-effects-on-primitives.md).

```cpp
struct BasicVertex
{
    DirectX::XMFLOAT3 pos;  // Position
    DirectX::XMFLOAT3 norm; // Surface normal vector
    DirectX::XMFLOAT2 tex;  // Texture coordinate
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

### Y. Xxxxxxxx xxxxxx xxx xxxxx xxxxxxx xxxx xxxxxxx xxx xxxxxxx xxxxxxxx

Xxxx, xx xxxxxx xxxx xxxxxxx xxxxxx xxx xxxxx xxxxxxx xxxx xx xxx xxxxxxxx xxxxxxxx, [Xxxxx xxxxx xxx xxxxxxx xx xxxxxxxxxx](using-depth-and-effects-on-primitives.md). Xxxx xxx'x xxxxxx xxxxxx xxxxxxxxxx xxxx xxxxxx xxxxxxxx xxxx xxxxxxxxxx xxxxx xxx xxxxxx xxx xxxxxx xxxxxxx xxxxxxxxxx xxxxxxx xx xxx xxxxx xxxxxx.

Xxx xxx'x xxxxx xx [**XYXYY\_XXXXX\_XXXXXXX\_XXXX**](https://msdn.microsoft.com/library/windows/desktop/ff476180) xxxxxxxxxx xxxx xxxxxxxx xxx xxxxxx xx xxx xxxxxx xxxxxx xxxx xxx xxxxx xxxxxx xxxxxxxx: xxx xxxxxxx xxxxxxx xxx xxxxxx xxxxxxxx, xxxxxxx xxxxxxx xxxxxxx xxx xxxxxxx xxxxxx xxxxxx (xxx xxxxxxxxx xxxx xxx xxxxxxx xxxxxxxx xxxxx), xxx xxx xxxxx xxxxxxx xxxxxxx xxx xxxxxxx xxxxxxxxxxx.

Xx xxxxxx xxxxxx, xxxxx, xxx xxxxxxxx xxxxxxx xxxx xxxxxx xx xxxxxxxx xxxxxxxx xxxx.

**Xx xxxxxx xx xxxxxxxx xxxxxxxx xxxx**

1.  Xxxxx, xx xxxxxx xxx xxxx. Xxxx xxxxxx xx xxxxxxxx x xxxxxxxx, x xxxxxxx xxxxxx xxxxxx, xxx xxxxxxx xxxxxxxxxxx. Xx xxx xxxxxxxx xxxxxxxx xxx xxxx xxxxxx xx xxxxx xxxxxxxxx xxxxxx xxxxxxx xxx xxxxxxx xxxxxxxxxxx xx xx xxxxxxx xxx xxxx xxxx.
2.  Xxxx, xx xxxxxxxx xxx xxxxxx xxx xxxxx xxxxxxx ([**XYXYY\_XXXXXX\_XXXX**](https://msdn.microsoft.com/library/windows/desktop/ff476092) xxx [**XYXYY\_XXXXXXXXXXX\_XXXX**](https://msdn.microsoft.com/library/windows/desktop/ff476220)) xxxxx xxx xxxx xxxxxxxxxx. Xx xxxx [**XXYXYYXxxxxx::XxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476501) xxxx xxx xxxx xxxxxx.
3.  Xxxx, xx xxxxxx x xxxxxxxx xxxxxx ([**XYXYY\_XXXXXX\_XXXX**](https://msdn.microsoft.com/library/windows/desktop/ff476092)) xxx xxxxxxx xxxxx, xxxx, xxx xxxxxxxxxx xxxxxxxx xx xxx xxxxxx xxxxxx. Xx xxx xxxxx xxx xxx xxxxxxxx xxxxxx xx xxxxxx xxx xxxx xxx xxxxx x xxxxxxxxxxx xxxxxxxxxx xx xx. Xx xxxx [**XXYXYYXxxxxx::XxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476501) xx xxxxxx xxx xxxxxxxx xxxxxx.
4.  Xxxxxxx, xx xxxxxxx xxx xxxx xxxxxxxxx xxxx xxxxxxxxxxx xx x xxxxxx xxxxxxxx xx X = Y, X = Y, X = Y.

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
          // These correspond to the elements of the BasicVertex struct defined above.
          const D3D11_INPUT_ELEMENT_DESC basicVertexLayoutDesc[] =
          {
              { "POSITION", 0, DXGI_FORMAT_R32G32B32_FLOAT, 0,  0, D3D11_INPUT_PER_VERTEX_DATA, 0 },
              { "NORMAL",   0, DXGI_FORMAT_R32G32B32_FLOAT, 0, 12, D3D11_INPUT_PER_VERTEX_DATA, 0 },
              { "TEXCOORD", 0, DXGI_FORMAT_R32G32_FLOAT,    0, 24, D3D11_INPUT_PER_VERTEX_DATA, 0 },
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
          // multiple vertices are used for each corner to allow different normal vectors and
          // texture coordinates to be defined for each face.
          BasicVertex cubeVertices[] =
          {
              { DirectX::XMFLOAT3(-0.5f, 0.5f, -0.5f), DirectX::XMFLOAT3(0.0f, 1.0f, 0.0f), DirectX::XMFLOAT2(0.0f, 0.0f) }, // +Y (top face)
              { DirectX::XMFLOAT3( 0.5f, 0.5f, -0.5f), DirectX::XMFLOAT3(0.0f, 1.0f, 0.0f), DirectX::XMFLOAT2(1.0f, 0.0f) },
              { DirectX::XMFLOAT3( 0.5f, 0.5f,  0.5f), DirectX::XMFLOAT3(0.0f, 1.0f, 0.0f), DirectX::XMFLOAT2(1.0f, 1.0f) },
              { DirectX::XMFLOAT3(-0.5f, 0.5f,  0.5f), DirectX::XMFLOAT3(0.0f, 1.0f, 0.0f), DirectX::XMFLOAT2(0.0f, 1.0f) },

              { DirectX::XMFLOAT3(-0.5f, -0.5f,  0.5f), DirectX::XMFLOAT3(0.0f, -1.0f, 0.0f), DirectX::XMFLOAT2(0.0f, 0.0f) }, // -Y (bottom face)
              { DirectX::XMFLOAT3( 0.5f, -0.5f,  0.5f), DirectX::XMFLOAT3(0.0f, -1.0f, 0.0f), DirectX::XMFLOAT2(1.0f, 0.0f) },
              { DirectX::XMFLOAT3( 0.5f, -0.5f, -0.5f), DirectX::XMFLOAT3(0.0f, -1.0f, 0.0f), DirectX::XMFLOAT2(1.0f, 1.0f) },
              { DirectX::XMFLOAT3(-0.5f, -0.5f, -0.5f), DirectX::XMFLOAT3(0.0f, -1.0f, 0.0f), DirectX::XMFLOAT2(0.0f, 1.0f) },

              { DirectX::XMFLOAT3(0.5f,  0.5f,  0.5f), DirectX::XMFLOAT3(1.0f, 0.0f, 0.0f), DirectX::XMFLOAT2(0.0f, 0.0f) }, // +X (right face)
              { DirectX::XMFLOAT3(0.5f,  0.5f, -0.5f), DirectX::XMFLOAT3(1.0f, 0.0f, 0.0f), DirectX::XMFLOAT2(1.0f, 0.0f) },
              { DirectX::XMFLOAT3(0.5f, -0.5f, -0.5f), DirectX::XMFLOAT3(1.0f, 0.0f, 0.0f), DirectX::XMFLOAT2(1.0f, 1.0f) },
              { DirectX::XMFLOAT3(0.5f, -0.5f,  0.5f), DirectX::XMFLOAT3(1.0f, 0.0f, 0.0f), DirectX::XMFLOAT2(0.0f, 1.0f) },

              { DirectX::XMFLOAT3(-0.5f,  0.5f, -0.5f), DirectX::XMFLOAT3(-1.0f, 0.0f, 0.0f), DirectX::XMFLOAT2(0.0f, 0.0f) }, // -X (left face)
              { DirectX::XMFLOAT3(-0.5f,  0.5f,  0.5f), DirectX::XMFLOAT3(-1.0f, 0.0f, 0.0f), DirectX::XMFLOAT2(1.0f, 0.0f) },
              { DirectX::XMFLOAT3(-0.5f, -0.5f,  0.5f), DirectX::XMFLOAT3(-1.0f, 0.0f, 0.0f), DirectX::XMFLOAT2(1.0f, 1.0f) },
              { DirectX::XMFLOAT3(-0.5f, -0.5f, -0.5f), DirectX::XMFLOAT3(-1.0f, 0.0f, 0.0f), DirectX::XMFLOAT2(0.0f, 1.0f) },

              { DirectX::XMFLOAT3(-0.5f,  0.5f, 0.5f), DirectX::XMFLOAT3(0.0f, 0.0f, 1.0f), DirectX::XMFLOAT2(0.0f, 0.0f) }, // +Z (front face)
              { DirectX::XMFLOAT3( 0.5f,  0.5f, 0.5f), DirectX::XMFLOAT3(0.0f, 0.0f, 1.0f), DirectX::XMFLOAT2(1.0f, 0.0f) },
              { DirectX::XMFLOAT3( 0.5f, -0.5f, 0.5f), DirectX::XMFLOAT3(0.0f, 0.0f, 1.0f), DirectX::XMFLOAT2(1.0f, 1.0f) },
              { DirectX::XMFLOAT3(-0.5f, -0.5f, 0.5f), DirectX::XMFLOAT3(0.0f, 0.0f, 1.0f), DirectX::XMFLOAT2(0.0f, 1.0f) },

              { DirectX::XMFLOAT3( 0.5f,  0.5f, -0.5f), DirectX::XMFLOAT3(0.0f, 0.0f, -1.0f), DirectX::XMFLOAT2(0.0f, 0.0f) }, // -Z (back face)
              { DirectX::XMFLOAT3(-0.5f,  0.5f, -0.5f), DirectX::XMFLOAT3(0.0f, 0.0f, -1.0f), DirectX::XMFLOAT2(1.0f, 0.0f) },
              { DirectX::XMFLOAT3(-0.5f, -0.5f, -0.5f), DirectX::XMFLOAT3(0.0f, 0.0f, -1.0f), DirectX::XMFLOAT2(1.0f, 1.0f) },
              { DirectX::XMFLOAT3( 0.5f, -0.5f, -0.5f), DirectX::XMFLOAT3(0.0f, 0.0f, -1.0f), DirectX::XMFLOAT2(0.0f, 1.0f) },
          };

          unsigned short cubeIndices[] =
          {
              0, 1, 2,
              0, 2, 3,

              4, 5, 6,
              4, 6, 7,

              8, 9, 10,
              8, 10, 11,

              12, 13, 14,
              12, 14, 15,

              16, 17, 18,
              16, 18, 19,

              20, 21, 22,
              20, 22, 23
          };

          D3D11_BUFFER_DESC vertexBufferDesc = {0};
          vertexBufferDesc.ByteWidth = sizeof(BasicVertex) * ARRAYSIZE(cubeVertices);
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
```

### Y. Xxxxxxxx xxxxxxxx xxx xxxxxxxx

Xxxx, xx xxxxx xxxxxxx xxxx xx x xxxx xxxxxx xxxx xxxxxxxx xxxxxx xx xx xxx xxxxxxxx xxxxxxxx, [Xxxxx xxxxx xxx xxxxxxx xx xxxxxxxxxx](using-depth-and-effects-on-primitives.md).

Xx xxx xxx xxxxxxx xxxx xx xxxxxx xxxxxxxx.

**Xx xxxxxx xxxxxxxx xxx xxxxxxxx**

1.  Xxxxx, xx xxxx xxx xxxxxxx xxxx xxxx xxx xxxxxxxxxxx.xxx xxxx xx xxxx.
2.  Xxxx, xx xxxxxxxxx x [**XYXYY\_XXXXXXXXXXX\_XXXX**](https://msdn.microsoft.com/library/windows/desktop/ff476220) xxxxxxxxx xxxx xxxxxxxxxx xxxx xxx xxxxxxx xxxx.
3.  Xxxx, xx xxxxxxxx x [**XYXYY\_XXXXXXXYX\_XXXX**](https://msdn.microsoft.com/library/windows/desktop/ff476253) xxxxxxxxx xx xxxxxxxx xxx xxxxxxx. Xx xxxx xxxx xxx [**XYXYY\_XXXXXXXXXXX\_XXXX**](https://msdn.microsoft.com/library/windows/desktop/ff476220) xxx **XYXYY\_XXXXXXXYX\_XXXX** xxxxxxxxxx xx x xxxx xx [**XXYXYYXxxxxx::XxxxxxXxxxxxxYX**](https://msdn.microsoft.com/library/windows/desktop/ff476521) xx xxxxxx xxx xxxxxxx.
4.  Xxxx, xx xxxxxx x xxxxxx-xxxxxxxx xxxx xx xxx xxxxxxx xx xxxxxxx xxx xxx xxx xxxxxxx. Xx xxxxxx xxx xxxxxx-xxxxxxxx xxxx, xx xxxxxxxx x [**XYXYY\_XXXXXX\_XXXXXXXX\_XXXX\_XXXX**](https://msdn.microsoft.com/library/windows/desktop/ff476211) xx xxxxxxxx xxx xxxxxx-xxxxxxxx xxxx xxx xxxx xxx xxxxxx-xxxxxxxx xxxx xxxxxxxxxxx xxx xxx xxxxxxx xx [**XXYXYYXxxxxx::XxxxxxXxxxxxXxxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476519). Xx xxxxxxx, xxx xxxxx xxx xxxx xxxxxxxxxxx xxxx xxx xxxxxxx xxxxxxxxxxx.
5.  Xxxx, xx xxxxxx xxxxxxx xxxxx xxx xxx xxxxxxx. Xxxx xxxxxxx xxxxx xxxx xxx xxxxxxxx xxxxxxx xxxx xx xxxxxx xxx xxx xxxxx xxx x xxxxxxxxxx xxxxxxx xxxxxxxxxx xx xxxxxxxxxx. Xx xxxxxxxx x [**XYXYY\_XXXXXXX\_XXXX**](https://msdn.microsoft.com/library/windows/desktop/ff476207) xxxxxxxxx xx xxxxxxxx xxx xxxxxxx xxxxx. Xx xxxx xxxx xxx **XYXYY\_XXXXXXX\_XXXX** xxxxxxxxx xx x xxxx xx [**XXYXYYXxxxxx::XxxxxxXxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476518) xx xxxxxx xxx xxxxxxx xxxxx.
6.  Xxxxxxx, xx xxxxxxx x *xxxxxx* xxxxxxxx xxxx xx xxxx xxx xx xxxxxxx xxx xxxx xx xxxxxxxx xx xxxxx xxxxx.

```cpp
        
        // Load the raw texture data from disk and construct a subresource description that references it.
        auto loadTDTask = DX::ReadDataAsync(L"texturedata.bin");
          
        auto constructSubresourceTask = loadTDTask.then([this](const std::vector<byte>& vertexShaderBytecode) {  
        
          D3D11_SUBRESOURCE_DATA textureSubresourceData = {0};
          textureSubresourceData.pSysMem = textureData->Data;

          // Specify the size of a row in bytes, known as a priori about the texture data.
          textureSubresourceData.SysMemPitch = 1024;

          // As this is not a texture array or 3D texture, this parameter is ignored.
          textureSubresourceData.SysMemSlicePitch = 0;

          // Create a texture description from information known as a priori about the data.
          // Generalized texture loading code can be found in the Resource Loading sample.
          D3D11_TEXTURE2D_DESC textureDesc = {0};
          textureDesc.Width = 256;
          textureDesc.Height = 256;
          textureDesc.Format = DXGI_FORMAT_R8G8B8A8_UNORM;
          textureDesc.Usage = D3D11_USAGE_DEFAULT;
          textureDesc.CPUAccessFlags = 0;
          textureDesc.MiscFlags = 0;

          // Most textures contain more than one MIP level.  For simplicity, this sample uses only one.
          textureDesc.MipLevels = 1;

          // As this will not be a texture array, this parameter is ignored.
          textureDesc.ArraySize = 1;

          // Don't use multi-sampling.
          textureDesc.SampleDesc.Count = 1;
          textureDesc.SampleDesc.Quality = 0;

          // Allow the texture to be bound as a shader resource.
          textureDesc.BindFlags = D3D11_BIND_SHADER_RESOURCE;

          ComPtr<ID3D11Texture2D> texture;
          DX::ThrowIfFailed(
              m_d3dDevice->CreateTexture2D(
                  &textureDesc,
                  &textureSubresourceData,
                  &texture
                  )
              );

          // Once the texture is created, we must create a shader resource view of it
          // so that shaders may use it.  In general, the view description will match
          // the texture description.
          D3D11_SHADER_RESOURCE_VIEW_DESC textureViewDesc;
          ZeroMemory(&textureViewDesc, sizeof(textureViewDesc));
          textureViewDesc.Format = textureDesc.Format;
          textureViewDesc.ViewDimension = D3D11_SRV_DIMENSION_TEXTURE2D;
          textureViewDesc.Texture2D.MipLevels = textureDesc.MipLevels;
          textureViewDesc.Texture2D.MostDetailedMip = 0;

          ComPtr<ID3D11ShaderResourceView> textureView;
          DX::ThrowIfFailed(
              m_d3dDevice->CreateShaderResourceView(
                  texture.Get(),
                  &textureViewDesc,
                  &textureView
                  )
              );

          // Once the texture view is created, create a sampler.  This defines how the color
          // for a particular texture coordinate is determined using the relevant texture data.
          D3D11_SAMPLER_DESC samplerDesc;
          ZeroMemory(&samplerDesc, sizeof(samplerDesc));

          samplerDesc.Filter = D3D11_FILTER_MIN_MAG_MIP_LINEAR;

          // The sampler does not use anisotropic filtering, so this parameter is ignored.
          samplerDesc.MaxAnisotropy = 0;

          // Specify how texture coordinates outside of the range 0..1 are resolved.
          samplerDesc.AddressU = D3D11_TEXTURE_ADDRESS_WRAP;
          samplerDesc.AddressV = D3D11_TEXTURE_ADDRESS_WRAP;
          samplerDesc.AddressW = D3D11_TEXTURE_ADDRESS_WRAP;

          // Use no special MIP clamping or bias.
          samplerDesc.MipLODBias = 0.0f;
          samplerDesc.MinLOD = 0;
          samplerDesc.MaxLOD = D3D11_FLOAT32_MAX;

          // Don't use a comparison function.
          samplerDesc.ComparisonFunc = D3D11_COMPARISON_NEVER;

          // Border address mode is not used, so this parameter is ignored.
          samplerDesc.BorderColor[0] = 0.0f;
          samplerDesc.BorderColor[1] = 0.0f;
          samplerDesc.BorderColor[2] = 0.0f;
          samplerDesc.BorderColor[3] = 0.0f;

          ComPtr<ID3D11SamplerState> sampler;
          DX::ThrowIfFailed(
              m_d3dDevice->CreateSamplerState(
                  &samplerDesc,
                  &sampler
                  )
              );
        });

        // This value will be used to animate the cube by rotating it every frame;
        float degree = 0.0f;
```

### Y. Xxxxxxxx xxx xxxxxxx xxx xxxxxxxx xxxx xxx xxxxxxxxxx xxx xxxxxxxx xxxxx

Xx xx xxx xxxxxxxx xxxxxxxxx, xx xxxxx xx xxxxxxx xxxx xx xxxxxxxxxxx xxxxxx xxx xxxxxxx xxx xxxxx. Xx xxxx xxx **xxxxxxxxX** xxxxxx xxxxxxxx (XxxxxXxxx.x) xxxx x xxxxxxxx xxxxxx xx xxx xxxxxx xxxx xxxx xxxxxx xxx xxxx’x xxxxx xxxxxx xxxxxx xxx X xxxx. Xx xxxx xxxx [**XXYXYYXxxxxxXxxxxxx::XxxxxxXxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476486) xx xxxxxx xxx xxxxxxxx xxxxxx xxx xxxxxx xxx xxxx xxxxx. Xxxx, xx xxxx [**XXYXYYXxxxxxXxxxxxx::XXXxxXxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476464) xx xxxxxxx xxx xxxxxx xxxxxx xxx xxx xxxxx-xxxxxxx xxxx. Xx xxxx [**XXYXYYXxxxxxXxxxxxx::XxxxxXxxxxxXxxxxxXxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476388) xx xxxxx xxx xxxxxx xxxxxx xx x xxxxx xxxx xxxxx xxx xxxx [**XXYXYYXxxxxxXxxxxxx::XxxxxXxxxxXxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476387) xx xxxxx xxx xxxxx xxxxxx.

Xx xxx xxxxxxx xxxx, xx xxxx xxxx xxx xxxxxxxx xxxx xx xxx xxxx xxxxxxx.

**Xx xxxx xxx xxxxxxxx xxxx**

1.  Xxxxx, xx xxxx [**XXYXYYXxxxxxXxxxxxx::XXXxxXxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476454) xx xxxxxxxx xxx xxxxxx xxxxxx xxxx xx xxxxxxxx xxxx xxx xxxxx-xxxxxxxxx xxxxx.
2.  Xxxx, xx xxxx [**XXYXYYXxxxxxXxxxxxx::XXXxxXxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476456) xxx [**XXYXYYXxxxxxXxxxxxx::XXXxxXxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476453) xx xxxx xxx xxxxxx xxx xxxxx xxxxxxx xx xxx xxxxx-xxxxxxxxx xxxxx.
3.  Xxxx, xx xxxx [**XXYXYYXxxxxxXxxxxxx::XXXxxXxxxxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476455) xxxx xxx [**XYXYY\_XXXXXXXXX\_XXXXXXXX\_XXXXXXXXXXXXX**](https://msdn.microsoft.com/library/windows/desktop/ff476189#D3D11_PRIMITIVE_TOPOLOGY_TRIANGLESTRIP) xxxxx xx xxxxxxx xxx xxx xxxxx-xxxxxxxxx xxxxx xx xxxxxxxxx xxx xxxxxx xxxx xx x xxxxxxxx xxxxx.
4.  Xxxx, xx xxxx [**XXYXYYXxxxxxXxxxxxx::XXXxxXxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476493) xx xxxxxxxxxx xxx xxxxxx xxxxxx xxxxx xxxx xxx xxxxxx xxxxxx xxxx xxx [**XXYXYYXxxxxxXxxxxxx::XXXxxXxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476472) xx xxxxxxxxxx xxx xxxxx xxxxxx xxxxx xxxx xxx xxxxx xxxxxx xxxx.
5.  Xxxx, xx xxxx [**XXYXYYXxxxxxXxxxxxx::XXXxxXxxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476491) xx xxx xxx xxxxxxxx xxxxxx xxxx xx xxxx xx xxx xxxxxx xxxxxx xxxxxxxx xxxxx.
6.  Xxxx, xx xxxx [**XXXxxXxxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476473) xx xxxx xxx xxxxxx-xxxxxxxx xxxx xx xxx xxxxxxx xx xxx xxxxx xxxxxx xxxxxxxx xxxxx.
7.  Xxxx, xx xxxx [**XXXxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476471) xx xxx xxx xxxxxxx xxxxx xx xxx xxxxx xxxxxx xxxxxxxx xxxxx.
8.  Xxxxxxx, xx xxxx [**XXYXYYXxxxxxXxxxxxx::XxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476409) xx xxxx xxx xxxx xxx xxxxxx xx xx xxx xxxxxxxxx xxxxxxxx.

Xx xx xxx xxxxxxxx xxxxxxxxx, xx xxxx [**XXXXXXxxxXxxxx::Xxxxxxx**](https://msdn.microsoft.com/library/windows/desktop/bb174576) xx xxxxxxx xxx xxxxxxxx xxxxx xx xxx xxxxxx.

```cpp
            // Update the constant buffer to rotate the cube model.
            m_constantBufferData.model = DirectX::XMMatrixRotationY(-degree);
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
            UINT stride = sizeof(BasicVertex);
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

            m_d3dDeviceContext->PSSetShaderResources(
                0,
                1,
                textureView.GetAddressOf()
                );

            m_d3dDeviceContext->PSSetSamplers(
                0,
                1,
                sampler.GetAddressOf()
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

## Xxxxxxx


Xx xxxxxx xxx xxxxxxx xxxx xxx xxxxxxx xxxx xxxx xx x YX xxxxxxxxx.

 

 




<!--HONumber=Mar16_HO1-->
