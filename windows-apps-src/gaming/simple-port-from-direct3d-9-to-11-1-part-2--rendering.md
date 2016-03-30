---
xxxxx: Xxxxxxx xxx xxxxxxxxx xxxxxxxxx
xxxxxxxxxxx: Xxxxx xxx xx xxxxxxx x xxxxxx xxxxxxxxx xxxxxxxxx xxxx XxxxxxYX Y xx XxxxxxYX YY, xxxxxxxxx xxx xx xxxx xxxxxxxx xxxxxxx, xxx xx xxxxxxx xxx xxxx XXXX xxxxxx xxxxxxxx, xxx xxx xx xxxxxxxxx xxx xxxxxxxxx xxxxx xx XxxxxxYX YY.
xx.xxxxxxx: xYxxYYYY-YxxY-YYYx-YxYx-xYxxYxYYxxYY
---

# Xxxxxxx xxx xxxxxxxxx xxxxxxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

**Xxxxxxx**

-   [Xxxx Y: Xxxxxxxxxx XxxxxxYX YY](simple-port-from-direct3d-9-to-11-1-part-1--initializing-direct3d.md)
-   Xxxx Y: Xxxxxxx xxx xxxxxxxxx xxxxxxxxx
-   [Xxxx Y: Xxxx xxx xxxx xxxx](simple-port-from-direct3d-9-to-11-1-part-3--viewport-and-game-loop.md)


Xxxxx xxx xx xxxxxxx x xxxxxx xxxxxxxxx xxxxxxxxx xxxx XxxxxxYX Y xx XxxxxxYX YY, xxxxxxxxx xxx xx xxxx xxxxxxxx xxxxxxx, xxx xx xxxxxxx xxx xxxx XXXX xxxxxx xxxxxxxx, xxx xxx xx xxxxxxxxx xxx xxxxxxxxx xxxxx xx XxxxxxYX YY. Xxxx Y xx xxx [Xxxx x xxxxxx XxxxxxYX Y xxx xx XxxxxxX YY xxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX)](walkthrough--simple-port-from-direct3d-9-to-11-1.md) xxxxxxxxxxx.

## Xxxxxxx xxxxxxx xx XXXX xxxxxxx


Xxx xxxxxxxxx xxxxxxx xx x xxxxxx XYXX xxxxxxxxx, xxxxxxx xxx xxx xxxxxx Xxxxxxx XXX, xxx xxxxxxxx xxxxxx xxxxxxxxxxxxxx xxx xxxx-xxxxxxx xxxxx xxxx.

XxxxxxYX Y xxxxxx xxxx

```cpp
// Global variables
matrix g_mWorld;        // world matrix for object
matrix g_View;          // view matrix
matrix g_Projection;    // projection matrix

// Shader pipeline structures
struct VS_OUTPUT
{
    float4 Position   : POSITION;   // vertex position
    float4 Color      : COLOR0;     // vertex diffuse color
};

struct PS_OUTPUT
{
    float4 RGBColor : COLOR0;  // Pixel color    
};

// Vertex shader
VS_OUTPUT RenderSceneVS(float3 vPos : POSITION, 
                        float3 vColor : COLOR0)
{
    VS_OUTPUT Output;
    
    float4 pos = float4(vPos, 1.0f);

    // Transform the position from object space to homogeneous projection space
    pos = mul(pos, g_mWorld);
    pos = mul(pos, g_View);
    pos = mul(pos, g_Projection);

    Output.Position = pos;
    
    // Just pass through the color data
    Output.Color = float4(vColor, 1.0f);
    
    return Output;
}

// Pixel shader
PS_OUTPUT RenderScenePS(VS_OUTPUT In) 
{ 
    PS_OUTPUT Output;

    Output.RGBColor = In.Color;

    return Output;
}

// Technique
technique RenderSceneSimple
{
    pass P0
    {          
        VertexShader = compile vs_2_0 RenderSceneVS();
        PixelShader  = compile ps_2_0 RenderScenePS(); 
    }
}
```

Xx XxxxxxYX YY, xx xxx xxxxx xxx xxx XXXX xxxxxxx. Xx xxx xxxx xxxxxx xx xxx xxx XXXX xxxx xx xxxx Xxxxxx Xxxxxx xxxxxxxx xxxx xxxx xxxxxxxx xxxxx xxx xxxxx, xx'xx xxxx xxxx xx xxxxxxxx XxxxxxYX xxxxxxxxx. Xx xxx xxx xxxxxx xxxxx xx [Xxxxxx Xxxxx Y Xxxxx Y\_Y (/Y\_Y\_xxxxx\_Y\_Y)](https://msdn.microsoft.com/library/windows/desktop/ff476876) xxxxxxx xxxxx xxxxxxx xxx xxxxxxx xxx XxxxxxX Y.Y XXXx.

Xxxx xx xxxxxxx xxx xxxxx xxxxxx, xx xxxx xxxx xx xxxxxxxxxxx xxx xxxx xxxx xxxxxxxxx xx xxx xx xxxxx xxx-xxxxxx xxxx xx xxxxxx xxxxxx xxx xx XXX xxxxxx. Xxxxxxxxx, xxx xxxxxx xx x xxxxxx xxxxxx xxxxxx xxxxx xxx xxxxxxxxx xxxx xx xxxxx xx xxx xxxxx xxxxxx. Xxx xxxxx xxx xxx xxx xxxx xx xxxxxxx xxxx xxxx xxx xxxxxxxx xx xxxxxxx xx X++; xxx xxx xxxx xxxxxx xxxxxxxxx xx xxx xxx xx xxx xxxxxxxxx. Xxx xxx xxxxx xxx'x xx xxxxxxxxxx xxx xxx xxx'x xxxx xxxxxxx xx xxx xxxxxx xx xxx xxxx xxxxxxxxx.

> **Xxxx**  
Xxx xxxxx xx XxxxxxYX Y xxx xxxxxxx xxxxxx xxxxxxx xx xxxxx xxxxxxx xxxx xxxx xxxxxxx xxxx xxx xxxxx xx XxxxxxYX YY. Xxx XxxxxxYX Y xxxxxxxxxxx xxx xxxxxxxx, xxx xxxxxxxxxxx.

 

Xx'x xxxxxxxx xxxx xxxx XXXX xxxxx xxxx xxxxx xxxxxx xxx xxxxxx xxxxxxxxx - xxx xxxxxxx, XXXXX xxxxxxx xx XX\_XXXXXX. Xx xx xxx'xx xxxx xx xxxxxx XXXX xxxxxxxxxxxxx xxxx (/Xxx xxxxxxxx xxxxxx) xx xxxxxx xxx xxxxxx [xxxxxxxxx](https://msdn.microsoft.com/library/windows/desktop/bb509647) xx xxx xxxxxxx xxxxxx. Xxx xxxxxx xxxxxx xx xxxx xxxxxxx xxx xxxx xxxxxxx xxxx xxxxxxx xxxxxx.

Xxxx'x xxx xxxxxxxx xxxxxxxxxxxxxx xxxxxx xxxxxx, xxxx xxxx xxxxxxx xx xxx xxx xxxx.

> **Xxxx**  Xxxxxx xxxxxxx xxx xxxxxxxx xx xxxxxx xxx XX\_XXXXXXXX xxxxxx xxxxx xxxxxxxx. Xxxx xxxxxxxx xxxxxxxx xxx xxxxxx xxxxxxxx xxxx xx xxxxxxxxxx xxxxxx xxxxx x xx xxxxxxx -Y xxx Y, x xx xxxxxxx -Y xxx Y, x xx xxxxxxx xx xxx xxxxxxxx xxxxxxxxxxx xxxxxxxxxx x xxxxx (x/x), xxx x xx Y xxxxxxx xx xxx xxxxxxxx x xxxxx (Y/x).

 

XXXX xxxxxx xxxxxx (xxxxxxx xxxxx Y.Y)

```cpp
cbuffer ModelViewProjectionConstantBuffer : register(b0)
{
    matrix mWorld;       // world matrix for object
    matrix View;        // view matrix
    matrix Projection;  // projection matrix
};

struct VS_INPUT
{
    float3 vPos   : POSITION;
    float3 vColor : COLOR0;
};

struct VS_OUTPUT
{
    float4 Position : SV_POSITION; // Vertex shaders must output SV_POSITION
    float4 Color    : COLOR0;
};

VS_OUTPUT main(VS_INPUT input) // main is the default function name
{
    VS_OUTPUT Output;

    float4 pos = float4(input.vPos, 1.0f);

    // Transform the position from object space to homogeneous projection space
    pos = mul(pos, mWorld);
    pos = mul(pos, View);
    pos = mul(pos, Projection);
    Output.Position = pos;

    // Just pass through the color data
    Output.Color = float4(input.vColor, 1.0f);

    return Output;
}
```

Xxxx xx xxx xx xxxx xxx xxx xxxx-xxxxxxx xxxxx xxxxxx. Xxxx xxxxxx xx xxxx xx x xxxx-xxxxxxx, xx'x xxxxxxxx xxxxxxx xxxxxxxxxxx-xxxxxxx xxxxxxxxxxxx xxxxx xxxx xxx xxxx xxxxx. Xxxx xxxx xxx XX\_XXXXXX xxxxxx xxxxx xxxxxxxx xx xxxxxxx xx xxx xxxxx xxxxx xxxxxx xx xxx xxxxx xxxxxx xx xxxxxxxx xx xxx XXX.

> **Xxxx**  Xxxxxx xxxxx Y\_x xxxxx xxxxxxx xxxxxx xxxx xxxx xxx XX\_XXXXXXXX xxxxxx xxxxx xxxxxxxx. Xxxxx Y.Y (xxx xxxxxx) xxxxx xxxxxxx xxx xxx XX\_XXXXXXXX xx xxxxxxxx xxx xxxxx xxxxxxxx xx xxx xxxxxx, xxxxx x xx xxxxxxx Y xxx xxx xxxxxx xxxxxx xxxxx xxx x xx xxxxxxx Y xxx xxx xxxxxx xxxxxx xxxxxx (xxxx xxxxxx xx Y.Y).

 

Xxxx xxxxx xxxxxxx xxx xxxx xxxx xxxxxxx xxxx x xxxx xxxxxxx; xxxx xxxx xxxxxx XxxxxxYX xxxxxxx xxxxxx xxxxx x xxxx xxxxxxx xxxxxx xx xxxxxxxxxxxx xxx xxxxxx xxxxxxx.

XXXX xxxxx xxxxxx (xxxxxxx xxxxx Y.Y)

```cpp
struct PS_INPUT
{
    float4 Position : SV_POSITION;  // interpolated vertex position (system value)
    float4 Color    : COLOR0;       // interpolated diffuse color
};

struct PS_OUTPUT
{
    float4 RGBColor : SV_TARGET;  // pixel color (your PS computes this system value)
};

PS_OUTPUT main(PS_INPUT In)
{
    PS_OUTPUT Output;

    Output.RGBColor = In.Color;

    return Output;
}
```

## Xxxxxxx xxx xxxx xxxxxxx


XxxxxxYX Y xxxxx xxxxx xxxx xxx Xxxxxxx xxxxxxx xx x xxxxxxxxxx xxx xx xxxxxxxxx xxxxxxxxxxxx xxxxxxxxx. Xxxxxxx xxxxx xx xxxxxxxx xx xxx-xxxx xxxxx xxx [**XYXXXxxxxxXxxxxxXxxxXxxx xxxxxxxx**](https://msdn.microsoft.com/library/windows/desktop/bb172768) xxxxxx.

Xxxxxxx xx xxxxxx xx XxxxxxYX Y

```cpp
// Turn off preshader optimization to keep calculations on the GPU
DWORD dwShaderFlags = D3DXSHADER_NO_PRESHADER;

// Only enable debug info when compiling for a debug target
#if defined (DEBUG) || defined (_DEBUG)
dwShaderFlags |= D3DXSHADER_DEBUG;
#endif

D3DXCreateEffectFromFile(
    m_pd3dDevice,
    L"CubeShaders.fx",
    NULL,
    NULL,
    dwShaderFlags,
    NULL,
    &m_pEffect,
    NULL
    );
```

XxxxxxYX YY xxxxx xxxx xxxxxx xxxxxxxx xx xxxxxx xxxxxxxxx. Xxxxxxx xxx xxxxxxxx xxxx xxx xxxxxxx xx xxxxx xxx xxxx xxxxxxx xx xxxxxxxxx. Xx xxx xxxxxxx xxxx xxxx xxx xxxxxx xxxxxxxx xxxx xxxxxx xxxxxx, xxx xxx XxxxxxYX xxxxxx xxxxxxxxx xx xxxxxx x XxxxxxYX xxxxxxxx xxx xxxx xxxxxx, xxx xxxxx xx xxx XxxxxxYX xxxxxx xxxxxxxxx xxxx xx xxx xx xxxx xxxxx.

Xxxxxxx x xxxxxx xxxxxxxx xx XxxxxxYX YY

```cpp
// BasicReaderWriter is a tested file loader used in SDK samples.
BasicReaderWriter^ readerWriter = ref new BasicReaderWriter();


// Load vertex shader:
Platform::Array<byte>^ vertexShaderData =
    readerWriter->ReadData("CubeVertexShader.cso");

// This call allocates a device resource, validates the vertex shader 
// with the device feature level, and stores the vertex shader bits in 
// graphics memory.
m_d3dDevice->CreateVertexShader(
    vertexShaderData->Data,
    vertexShaderData->Length,
    nullptr,
    &m_vertexShader
    );
```

Xx xxxxxxx xxx xxxxxx xxxxxxxx xx xxxx xxxxxxxx xxx xxxxxxx, xxxx xxx xxx XXXX xxxx xx xxx Xxxxxx Xxxxxx xxxxxxx. Xxxxxx Xxxxxx xxxx xxx xxx [Xxxxxx-Xxxxxxxx Xxxx](https://msdn.microsoft.com/library/windows/desktop/bb232919) (XXX) xx xxxxxxx XXXX xxxxx xxxx xxxxxxxx xxxxxx xxxxxxx (.XXX xxxxx) xxx xxxxxxx xxxx xx xxx xxx xxxxxxx.

> **Xxxx**   Xx xxxx xx xxx xxx xxxxxxx xxxxxx xxxxxxx xxxxx xxx xxx XXXX xxxxxxxx: xxxxx-xxxxx xxx XXXX xxxxxx xxxx xx Xxxxxx Xxxxxx, xxxxxx Xxxxxxxxxx, xxx xxxxxx xxx **Xxxxxx Xxxxx** xxxxxxx xxxxx **XXXX Xxxxxxxx -&xx; Xxxxxxx**. XxxxxxYX xxxxxx xxxx xxxxxxxx xxxxxxx xxx xxxxxxxx xxxxxxxxxxxx xxxx xxxx xxx xxxxxxx xxx XxxxxxYX xxxxxx xxxxxxxx.

 

![xxxx xxxxxx xxxxxxxxxx](images/hlslshaderpropertiesmenu.png)![xxxx xxxxxx xxxx](images/hlslshadertypeproperties.png)

Xxxx xx x xxxx xxxxx xx xxxxxx xxx xxxxx xxxxxx, xxxxx xxxxxxxxxxx xx xxx xxxxxx xxxxxx xxxxxxxxxxx xx XxxxxxYX Y. Xxx xxx-xxxxxx xxxx xxxxxxxxx xxxxx xx xxxxx xxxx xxx xxxxxx xxxxxx xxxx; xx XxxxxxYX YY xx xxxx xxxx xxxxxxx xxxx xxx xxxxx xxxxxx; xx xxx xxxxxx xxx xxxxx xxxx xxx xxx xxxxxx xx xxxxxxxx-xxxxx xxxxxxx xxx xxxxxxx xxxxxxxxx xxx xxx xxxxxx xxxxxx. Xx xxxxxx x [**XYXYY\_XXXXX\_XXXXXXX\_XXXX**](https://msdn.microsoft.com/library/windows/desktop/ff476180) xxxxxxxxx xxx xxx xx xx xxxxxx XxxxxxYX xxxx xxx xxx-xxxxxx xxxx xxxx xxxx xxxx. Xx xxxxxx xxxxx xxxxx xx xxxxxx xxx xxxxxx xxxxxx xx xxxxxx xxx xxxxx xxxxxx xxxxxxx xxx XXX xxxxxxxxx xxx xxxxx xxxxxx xxxxxxx xxx xxxxxx xxxxxx xxxxxxxx. Xx xxx xxxxx xxxxxx xxx'x xxxxxxxxxx xxxx XxxxxxYX xxxxxx xx xxxxxxxxx.

Xxx-xxxxxx xxxx xxx xx xx xxxxxx xx xxxxxxxxxx xxxxx xx xxxxxx xxxxxx. XxxxxxXXxxx xxxx xxxxx xxx xxxx; xxx xxxxxxx, XXXX\_XXXXXX\_XYYXYYXYY\_XXXXX xxxxxxxxxxx xx [**XXXXXXXY**](https://msdn.microsoft.com/library/windows/desktop/ee419475).

> **Xxxx**   Xxxxxxxx xxxxxxx xxx x xxxxx xxxxx xxxxxx xxxx xxxxxx xx xxxx xxxxxxxx-xxxxx xxxxxxx xx x xxxx. [
            **XXXXXXXY**](https://msdn.microsoft.com/library/windows/desktop/ee419608) (xxx xxx xxxxxxxxxxx) xxx xxxxxxxxxxx xxx xxxxxxxx xxxxxx xxxx.

 

Xxxxxxx xxx xxxxx xxxxxx xx XxxxxxYX YY

```cpp
// Create input layout:
const D3D11_INPUT_ELEMENT_DESC vertexDesc[] = 
{
    { "POSITION", 0, DXGI_FORMAT_R32G32B32_FLOAT,
        0, 0,  D3D11_INPUT_PER_VERTEX_DATA, 0 },

    { "COLOR",    0, DXGI_FORMAT_R32G32B32_FLOAT, 
        0, 12, D3D11_INPUT_PER_VERTEX_DATA, 0 },
};
```

## Xxxxxx xxxxxxxx xxxxxxxxx


Xx XxxxxxYX Y xx xxxxxx xxxxxxxx xxxxxxxxx xx xxxxxxxx xxxxxxx xx xxx XxxxxxYX xxxxxx, xxxxxxx xxx xxxxxx, xxx xxxxxxx xxxx xxxx XXX xxxxxx xx XXX xxxxxx.

XxxxxxYX Y

```cpp
// Create vertex buffer:
VOID* pVertices;

// In Direct3D 9 we create the buffer, lock it, and copy the data from 
// system memory to graphics memory.
m_pd3dDevice->CreateVertexBuffer(
    sizeof(CubeVertices),
    0,
    D3DFVF_XYZ | D3DFVF_DIFFUSE,
    D3DPOOL_MANAGED,
    &pVertexBuffer,
    NULL);

pVertexBuffer->Lock(
    0,
    sizeof(CubeVertices),
    &pVertices,
    0);

memcpy(pVertices, CubeVertices, sizeof(CubeVertices));
pVertexBuffer->Unlock();
```

XxxxxxX YY xxxxxxx x xxxxxxx xxxxxxx. Xxx XXX xxxxxxxxxxxxx xxxxxx xxx xxxx xxxx xxxxxx xxxxxx xx xxx XXX. Xx xxx xxx XXX xxxxx xxxxxxxx xx xxxx xxxx xxxxxxxxxxx xxxxxx.

XxxxxxX YY

```cpp
D3D11_SUBRESOURCE_DATA vertexBufferData = {0};
vertexBufferData.pSysMem = CubeVertices;
vertexBufferData.SysMemPitch = 0;
vertexBufferData.SysMemSlicePitch = 0;
CD3D11_BUFFER_DESC vertexBufferDesc(
    sizeof(CubeVertices),
    D3D11_BIND_VERTEX_BUFFER);
  
// This call allocates a device resource for the vertex buffer and copies
// in the data.
m_d3dDevice->CreateBuffer(
    &vertexBufferDesc,
    &vertexBufferData,
    &m_vertexBuffer
    );
```

## Xxxxxxxxx xxx xxxxxxxxx xxxxx


XxxxxxYX Y xxxxx xxxxx xxxx xx xxxxxx-xxxxx xxxxxxxxx xxxxx. Xxxx xxxx xx xxxxxxxxx xxxxx xxxx xx xxx xxxxxx xxxxxx, xxxxxxxx xx xxxx xxx xxxxxxxxx xx xxxxx, xxx xxxx xx xxxxxx xxxx xxxx.

XxxxxxYX Y xxxxxxxxx xxxxx

```cpp
// Clear the render target and the z-buffer.
m_pd3dDevice->Clear(
    0, NULL,
    D3DCLEAR_TARGET | D3DCLEAR_ZBUFFER,
    D3DCOLOR_ARGB(0, 45, 50, 170),
    1.0f, 0
    );

// Set the effect technique
m_pEffect->SetTechnique("RenderSceneSimple");

// Rotate the cube 1 degree per frame.
D3DXMATRIX world;
D3DXMatrixRotationY(&world, D3DXToRadian(m_frameCount++));


// Set the matrices up using traditional functions.
m_pEffect->SetMatrix("g_mWorld", &world);
m_pEffect->SetMatrix("g_View", &m_view);
m_pEffect->SetMatrix("g_Projection", &m_projection);

// Render the scene using the Effects library.
if(SUCCEEDED(m_pd3dDevice->BeginScene()))
{
    // Begin rendering effect passes.
    UINT passes = 0;
    m_pEffect->Begin(&passes, 0);
    
    for (UINT i = 0; i < passes; i++)
    {
        m_pEffect->BeginPass(i);
        
        // Send vertex data to the pipeline.
        m_pd3dDevice->SetFVF(D3DFVF_XYZ | D3DFVF_DIFFUSE);
        m_pd3dDevice->SetStreamSource(
            0, pVertexBuffer,
            0, sizeof(VertexPositionColor)
            );
        m_pd3dDevice->SetIndices(pIndexBuffer);
        
        // Draw the cube.
        m_pd3dDevice->DrawIndexedPrimitive(
            D3DPT_TRIANGLELIST,
            0, 0, 8, 0, 12
            );
        m_pEffect->EndPass();
    }
    m_pEffect->End();
    
    // End drawing.
    m_pd3dDevice->EndScene();
}

// Present frame:
// Show the frame on the primary surface.
m_pd3dDevice->Present(NULL, NULL, NULL, NULL);
```

Xxx XxxxxxX YY xxxxxxxxx xxxxx xxxx xxxxx xx xxx xxxx xxxxx, xxx xxx xxxxxxxxx xxxxxx xxxx xx xx xxxxxxxxxxx xxxxxxxxxxx. Xxxxxxx xx xxxxxxx xxx xxxxxxxxx xx XX xxxxx xxx xxxxxxx xxx xxxxxxxxx xxxxxxxxxx xx xxxx-xx-xxxx xxxxxx xx xxx X++ xxxx, xx'xx xxx xx xxx xxx xxxxxxxxx xx X++.

Xxxx'x xxx xxx xxxxxxxxx xxxxx xxxx xxxx. Xx xxxx xx xxxxxx xxx xxxxx xxxxxx xx xxxxxxx xxxxx xxxxxxx xxx xxxxxx xxxxxx, xxxxxx xxxx xx xxx xxxxxx xxxxxxx, xxx xxxxxxx xxx xxxxxxxx xxxxxxx xxx xxxx xxxxxx xx xxx. Xxxx xxxxxxx xxxxx'x xxxxxxx xxxxxxxx xxxxxxxxx xxxxxx, xxx xx xx xxx xx'x xx x xxxxxxx xxxxxxxxx xxxxx xxx xxxx xxxx, xxxxxxxx xxx xxxxx xx xxxxxx.

XxxxxxYX YY xxxxxxxxx xxxxx

```cpp
// Clear the back buffer.
const float midnightBlue[] = { 0.098f, 0.098f, 0.439f, 1.000f };
m_d3dContext->ClearRenderTargetView(
    m_renderTargetView.Get(),
    midnightBlue
    );

// Set the render target. This starts the drawing operation.
m_d3dContext->OMSetRenderTargets(
    1,  // number of render target views for this drawing operation.
    m_renderTargetView.GetAddressOf(),
    nullptr
    );


// Rotate the cube 1 degree per frame.
XMStoreFloat4x4(
    &m_constantBufferData.model, 
    XMMatrixTranspose(XMMatrixRotationY(m_frameCount++ * XM_PI / 180.f))
    );

// Copy the updated constant buffer from system memory to video memory.
m_d3dContext->UpdateSubresource(
    m_constantBuffer.Get(),
    0,      // update the 0th subresource
    NULL,   // use the whole destination
    &m_constantBufferData,
    0,      // default pitch
    0       // default pitch
    );


// Send vertex data to the Input Assembler stage.
UINT stride = sizeof(VertexPositionColor);
UINT offset = 0;

m_d3dContext->IASetVertexBuffers(
    0,  // start with the first vertex buffer
    1,  // one vertex buffer
    m_vertexBuffer.GetAddressOf(),
    &stride,
    &offset
    );

m_d3dContext->IASetIndexBuffer(
    m_indexBuffer.Get(),
    DXGI_FORMAT_R16_UINT,
    0   // no offset
    );

m_d3dContext->IASetPrimitiveTopology(D3D11_PRIMITIVE_TOPOLOGY_TRIANGLELIST);
m_d3dContext->IASetInputLayout(m_inputLayout.Get());


// Set the vertex shader.
m_d3dContext->VSSetShader(
    m_vertexShader.Get(),
    nullptr,
    0
    );

// Set the vertex shader constant buffer data.
m_d3dContext->VSSetConstantBuffers(
    0,  // register 0
    1,  // one constant buffer
    m_constantBuffer.GetAddressOf()
    );


// Set the pixel shader.
m_d3dContext->PSSetShader(
    m_pixelShader.Get(),
    nullptr,
    0
    );


// Draw the cube.
m_d3dContext->DrawIndexed(
    m_indexCount,
    0,  // start with index 0
    0   // start with vertex 0
    );
```

Xxx xxxx xxxxx xx xxxx xx xxxxxxxx xxxxxxxxxxxxxx, xx xx xxx xxx XXXX xxxx xxxxx xx xxxxxxx xxx xxxxxxxxx xxxxx. XXXX xxxxxx xxx xxxx xxxxx xxx xxxx xxxxx; xxxx xx xxxxxxx, xxx xxx xxxx xxxx xxx xxxxxxxx xx xxx xxxx xxxxxxxxx.

Xxxxxxxxxx x xxxxx xx xxx xxxxxx xxxxx XxxxxxX YY

```cpp
m_swapChain->Present(1, 0);
```

Xxx xxxxxxxxx xxxxx xx xxxx xxxxxxx xxxx xx xxxxxx xxxx x xxxx xxxx xxxxxxxxxxx xx xxx [**XXxxxxxxxxXxxx::Xxx**](https://msdn.microsoft.com/library/windows/apps/hh700505) xxxxxx. Xxxx xx xxxxx xx [Xxxx Y: Xxxxxxxx xxx xxxx xxxx](simple-port-from-direct3d-9-to-11-1-part-3--viewport-and-game-loop.md).

 

 




<!--HONumber=Mar16_HO1-->
