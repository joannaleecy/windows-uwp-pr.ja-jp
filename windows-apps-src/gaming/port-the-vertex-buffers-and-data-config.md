---
xxxxx: Xxxx xxx xxxxxx xxxxxxx xxx xxxx
xxxxxxxxxxx: Xx xxxx xxxx, xxx'xx xxxxxx xxx xxxxxx xxxxxxx xxxx xxxx xxxxxxx xxxx xxxxxx xxx xxx xxxxx xxxxxxx xxxx xxxxx xxx xxxxxxx xx xxxxxxxx xxx xxxxxxxx xx x xxxxxxxxx xxxxx.
xx.xxxxxxx: YxYYYYxY-YYYY-YYYY-YxYY-YYxYYYYYYxYY
---

# Xxxx xxx xxxxxx xxxxxxx xxx xxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


**Xxxxxxxxx XXXx**

-   [**XXYXXxxxxx::XxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476501)
-   [**XXYXXxxxxxXxxxxxx::XXXxxXxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476456)
-   [**XXYXYYXxxxxxXxxxxxx::XXXxxXxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/desktop/bb173588)

Xx xxxx xxxx, xxx'xx xxxxxx xxx xxxxxx xxxxxxx xxxx xxxx xxxxxxx xxxx xxxxxx xxx xxx xxxxx xxxxxxx xxxx xxxxx xxx xxxxxxx xx xxxxxxxx xxx xxxxxxxx xx x xxxxxxxxx xxxxx.

Xx xxxx xxxxx, xxx'x xxxxxxx xxx xxxxxxxxx xxxxx xxx xxx xxxx xxxx xx xxx xxxxx. Xxxx xxxxxxxxxxxxxxx xxxx xxx xxxxxxxx xxxxxxxxx xx x xxxxxxxx xxxx (xx xxxxxxx xx x xxxxx xx xxxxx xxxx xxxxxxxxx xxxxxxxx xxxxxx). Xxx xxxxxxxx xx xxxx xxxxxxxxxxxxxxx xxxx xxxx xxxxxxxxxx xxxxxxx xxx xxxxx xxxxxx. Xxxx xx xxx XxxxxxYX xxxx xx xxxx xxxxx xxxxxx xx xxxxxxxxx xxx xxxxxxx xxxxxxx xx xxx XxxxxxYX xxxxxxx.

Xxxx'x xxx xxxx xxx xxxxxxxxxx xx XxxxXX XX Y.Y. Xx xxx xxxxxx xxxxxxxxxxxxxx, xxxx xxxxxx xx Y xxxxx xxxxxx: Y xxxxxxxx xxxxxxxxxxx xxxxxxxx xx Y XXXX xxxxx xxxxxx.

```cpp
#define CUBE_INDICES 36
#define CUBE_VERTICES 8

GLfloat cubeVertsAndColors[] = 
{
  -0.5f, -0.5f,  0.5f, 0.0f, 0.0f, 1.0f, 1.0f,
  -0.5f, -0.5f, -0.5f, 0.0f, 0.0f, 0.0f, 1.0f,
  -0.5f,  0.5f,  0.5f, 0.0f, 1.0f, 1.0f, 1.0f,
  -0.5f,  0.5f, -0.5f, 0.0f, 1.0f, 0.0f, 1.0f,
  0.5f, -0.5f,  0.5f, 1.0f, 0.0f, 1.0f, 1.0f,
  0.5f, -0.5f, -0.5f, 1.0f, 0.0f, 0.0f, 1.0f,  
  0.5f,  0.5f,  0.5f, 1.0f, 1.0f, 1.0f, 1.0f,
  0.5f,  0.5f, -0.5f, 1.0f, 1.0f, 0.0f, 1.0f
};

GLuint cubeIndices[] = 
{
  0, 1, 2, // -x
  1, 3, 2,

  4, 6, 5, // +x
  6, 7, 5,

  0, 5, 1, // -y
  5, 6, 1,

  2, 6, 3, // +y
  6, 7, 3,

  0, 4, 2, // +z
  4, 6, 2,

  1, 7, 3, // -z
  5, 7, 1
};
```

Xxx xxxx'x xxx xxxx xxxx xxx xxxxxxxxxx xx XxxxxxYX YY.

```cpp
VertexPositionColor cubeVerticesAndColors[] = 
// struct format is position, color
{
  {XMFLOAT3(-0.5f, -0.5f, -0.5f), XMFLOAT3(0.0f, 0.0f, 0.0f)},
  {XMFLOAT3(-0.5f, -0.5f,  0.5f), XMFLOAT3(0.0f, 0.0f, 1.0f)},
  {XMFLOAT3(-0.5f,  0.5f, -0.5f), XMFLOAT3(0.0f, 1.0f, 0.0f)},
  {XMFLOAT3(-0.5f,  0.5f,  0.5f), XMFLOAT3(0.0f, 1.0f, 1.0f)},
  {XMFLOAT3( 0.5f, -0.5f, -0.5f), XMFLOAT3(1.0f, 0.0f, 0.0f)},
  {XMFLOAT3( 0.5f, -0.5f,  0.5f), XMFLOAT3(1.0f, 0.0f, 1.0f)},
  {XMFLOAT3( 0.5f,  0.5f, -0.5f), XMFLOAT3(1.0f, 1.0f, 0.0f)},
  {XMFLOAT3( 0.5f,  0.5f,  0.5f), XMFLOAT3(1.0f, 1.0f, 1.0f)},
};
        
unsigned short cubeIndices[] = 
{
  0, 2, 1, // -x
  1, 2, 3,

  4, 5, 6, // +x
  5, 7, 6,

  0, 1, 5, // -y
  0, 5, 4,

  2, 6, 7, // +y
  2, 7, 3,

  0, 4, 6, // -z
  0, 6, 2,

  1, 3, 7, // +z
  1, 7, 5
};
```

Xxxxxxxxx xxxx xxxx, xxx xxxxxx xxxx xxx xxxx xx xxx XxxxXX XX Y.Y xxxx xx xxxxxxxxxxx xx x xxxxx-xxxx xxxxxxxxxx xxxxxx, xxxxxxx xxx xxxx xx xxx XxxxxxYX-xxxxxxxx xxxx xx xxxxxxxxxxx xx x xxxx-xxxx xxxxxxxxxx xxxxxx. Xxxx xxxxxxxxx xxxx xxx xxxx xxxx, xxx xxxx xxxxxxx xxx x-xxxx xxxxxxxxxxx xxx xxxx xxxxx xxx xxxxxx xxx xxxxxxx xxx xxxx xxxx xxxxxxxxxxx xx xxxxxxxx xxx xxxxxxxxx xxxxxxxxx xx xxx xxxxxx xx xxx xxxxxxxxxx xxxxxx.

Xxxxxxxx xxxx xx xxxx xxxxxxxxxxxx xxxxx xxx xxxx xxxx xxxx xxx xxxxx-xxxxxx XxxxXX XX Y.Y xxxxxxxxxx xxxxxx xx xxx xxxx-xxxxxx XxxxxxYX xxx, xxx'x xxx xxx xx xxxx xxx xxxx xxxx xxx xxxxxxxxxx xx xxxx xxxxxx.

## Xxxxxxxxxxxx

### Xxxx Y: Xxxxxx xx xxxxx xxxxxx

Xx XxxxXX XX Y.Y, xxxx xxxxxx xxxx xx xxxxxxxx xx xxxxxxxxxx xxxx xxxx xx xxxxxxxx xx xxx xxxx xx xxx xxxxxx xxxxxxx. Xxx xxxxxxxxx xxxxxxx x xxxxxx xxxx xxxxxxxx xxx xxxxxxxxx xxxx xxxx xx xxx xxxxxx'x XXXX xx xxx xxxxxx xxxxxxx xxxxxx, xxx xxx x xxxxxx xxxxxxxx xxxx xxxx xxx xxx xxxxxx xx xxx xxxxxx. Xx xxxx xxxxxxx, x xxxxxx xxxxxx xxxxxx xxxxxxxx x xxxx xx xxxxxx Xxxxxx xxxxxxxxxx, xxxxxxx xxx xxxxxxxxx xx xxxxxxx:

XxxxXX XX Y.Y: Xxxxxxxxx xxx xxxxxxxxxx xxxx xxxxxxx xxx xxx-xxxxxx xxxxxxxxxxx.

``` syntax
typedef struct 
{
  GLfloat pos[3];        
  GLfloat rgba[4];
} Vertex;
```

Xx XxxxXX XX Y.Y, xxxxx xxxxxxx xxx xxxxxxxx; xxx xxxx x xxxxxxx xxxxxxx XX\_XXXXXXX\_XXXXX\_XXXXXX xxx xxxxxx xxx xxxxxx xxx xxxxxx xxxx xxxx xxx xxxxxx xxxxxx xxx xxxxxxxxx xxx xxxx xxxxx xxxxxxxxx xx. Xxx xxxxxx xxx xxxxxx xxxxxx xxxxxxxxx xxxxx xxxxxxxxxx xxx xx xxxxx xxxxxxxx xx xxxx xxxxx xx xxxxxx xxxx xxxx **xxXxxxxxXxxxxxXxxxxxx**.

Xx XxxxxxYX, xxx xxxx xxxxxxx xx xxxxx xxxxxx xx xxxxxxxx xxx xxxxxxxxx xx xxx xxxxxx xxxx xx xxx xxxxxx xxxxxx xxxx xxx xxxxxx xxx xxxxxx, xxxxxxx xx xxxxxx xxx xxxx xxx xxxxxxxx. Xx xx xxxx, xxx xxx xx xxxxx xxxxxx xxxxx xxxxxxxxxxx xx xxxxxx xx xxx xxxx xxx xxx xxxxxxxxxx xxxxxxxx xx xxxxxx. Xx xx xxxx xxxxxxxxx xx xxxxxxx xxxx xxxxxxxxxx!

Xxxx, xxx xxxxxx xx xxxxx xxxxxxxxxxx xx xx xxxxx xx [**XYXYY\_XXXXX\_XXXXXXX\_XXXX**](https://msdn.microsoft.com/library/windows/desktop/ff476180) xxxxxxxxxx.

XxxxxxYX: Xxxxxx xx xxxxx xxxxxx xxxxxxxxxxx.

``` syntax
struct VertexPositionColor
{
  DirectX::XMFLOAT3 pos;
  DirectX::XMFLOAT3 color;
};

// ...

const D3D11_INPUT_ELEMENT_DESC vertexDesc[] = 
{
  { "POSITION", 0, DXGI_FORMAT_R32G32B32_FLOAT, 0, 0,  D3D11_INPUT_PER_VERTEX_DATA, 0 },
  { "COLOR",    0, DXGI_FORMAT_R32G32B32_FLOAT, 0, 12, D3D11_INPUT_PER_VERTEX_DATA, 0 },
};

```

Xxxx xxxxx xxxxxxxxxxx xxxxxxx x xxxxxx xx x xxxx xx Y Y-xxxxxxxxxx xxxxxxx: xxx YX xxxxxx xx xxxxx xxx xxxxxxxx xx xxx xxxxxx xx xxxxx xxxxxxxxxxx, xxx xxxxxxx YX xxxxxx xx xxxxx xxx XXX xxxxx xxxxx xxxxxxxxxx xxxx xxx xxxxxx. Xx xxxx xxxx, xxx xxx YxYY xxx xxxxxxxx xxxxx xxxxxx, xxxxxxxx xx xxxxx xx xxxxxxxxx xx xxxx xx `XMFLOAT3(X.Xf, X.Xf, X.Xf)`. Xxx xxxxxx xxx xxxxx xxxx xxx [XxxxxxXXxxx](https://msdn.microsoft.com/library/windows/desktop/ee415574) xxxxxxx xxxxxxxx xxx xxx xxxxxxxx xxxx xxxx xxxx xx xxxx xx x xxxxxx, xx xx xxxxxx xxx xxxxxx xxxxxxx xxx xxxxxxxxx xx xxxx xxxx. (Xxx xxxxxxx, xxx [**XXXXXXXY**](https://msdn.microsoft.com/library/windows/desktop/ee419475) xx [**XXXXXXXY**](https://msdn.microsoft.com/library/windows/desktop/ee419608) xxx xxxxxx xxxx, xxx [**XXXXXXXYXY**](https://msdn.microsoft.com/library/windows/desktop/ee419621) xxx xxxxxxxx.)

Xxx x xxxx xx xxx xxx xxxxxxxx xxxxxx xxxxx, xxxxx xx [**XXXX\_XXXXXX**](https://msdn.microsoft.com/library/windows/desktop/bb173059).

Xxxx xxx xxx-xxxxxx xxxxx xxxxxx xxxxxxx, xxx xxxxxx xxx xxxxxx xxxxxx. Xx xxx xxxxxxxxx xxxx, xxx xxxxx xx xx **x\_xxxxxXxxxxx**, x xxxxxxxx xx xxxx **XxxXxx** (xxxxx xxxxxx xx xx xxxxxx xx xxxx [**XXYXYYXxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476575)). **xxxxXxxx** xxxxxxxx xxx xxxxxxxx xxxxxx xxxxxx xxxxxx xxxx xxx xxxxxxxx xxxx, [Xxxx xxx xxxxxxx](port-the-shader-config.md).

XxxxxxYX: Xxxxxx xxx xxxxx xxxxxx xxxx xx xxx xxxxxx xxxxxx.

``` syntax
Microsoft::WRL::ComPtr<ID3D11InputLayout>      m_inputLayout;

// ...

m_d3dDevice->CreateInputLayout(
  vertexDesc,
  ARRAYSIZE(vertexDesc),
  fileData->Data,
  fileShaderData->Length,
  &m_inputLayout
);
```

Xx'xx xxxxxxx xxx xxxxx xxxxxx. Xxx, xxx'x xxxxxx x xxxxxx xxxx xxxx xxxx xxxxxx xxx xxxx xx xxxx xxx xxxx xxxx xxxx.

### Xxxx Y: Xxxxxx xxx xxxx xxx xxxxxx xxxxxx(x)

Xx XxxxXX XX Y.Y, xxx xxxxxx x xxxx xx xxxxxxx, xxx xxx xxx xxxxxxxx xxxx xxx xxx xxx xxx xxxxx xxxx. (Xxx xxxxx xxxx xxxxxx x xxxxxx xxxx xxxxxxxx xxxx xxx x xxxxxx xxxxxx.) Xxx xxxx xxxx xxxxxx xxx xxxxx xxxxxxxx xxx xxxxx xxxx xxxx xxxx. Xxxxx, xxxxxx xxxx xxxxxx xxxxxxxx, xxxx xxx xxxxxxx xxxxx xxx xxxxxxx xxx xxxxxx xxxx xxx xxxxxx xx xxx xxxx xx xxx xxxxxx xx xx xxx xxxxxxxxx xxxxxxxxx xx.

XxxxXX XX Y.Y: Xxxx xxx xxxxxx xxxxxxx

``` syntax
// upload the data for the vertex position buffer
glGenBuffers(1, &renderer->vertexBuffer);    
glBindBuffer(GL_ARRAY_BUFFER, renderer->vertexBuffer);
glBufferData(GL_ARRAY_BUFFER, sizeof(VERTEX) * CUBE_VERTICES, renderer->vertices, GL_STATIC_DRAW);   
```

Xx XxxxxxYX, xxxxxx-xxxxxxxxxx xxxxxxx xxx xxxxxxxxxxx xx [**XYXYY\_XXXXXXXXXXX\_XXXX**](https://msdn.microsoft.com/library/windows/desktop/ff476220) xxxxxxxxxx. Xx xxxx xxx xxxxxxxx xx xxxx xxxxxx xx xxxxxx xxxxxx, xxx xxxx xx xxxxxx x XXYXYY\_XXXXXX\_XXXX xxxxxxxxx xxx xxxx xxxxxx xxxx [**XXYXXxxxxx::XxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476501), xxx xxxx xxx xxx xxxxxx xx xxx XxxxxxYX xxxxxx xxxxxxx xx xxxxxxx x xxx xxxxxx xxxxxxxx xx xxx xxxxxx xxxx, xxxx xx [**XXYXXxxxxxXxxxxxx::XXXxxXxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476456).

Xxxx xxx xxx xxx xxxxxx, xxx xxxx xxx xxx xxxxxx (xxx xxxx xx xxx xxxx xxxxxxx xxx xx xxxxxxxxxx xxxxxx) xx xxxx xxx xxxxxx (xxxxx xxx xxxxxx xxxx xxxxx xxxxxxxx xxxxxx) xxxx xxx xxxxxxxxx xx xxx xxxxxx.

Xxxxxx xxxx xx xxxxxx xxx xxxxxxx xx xxx **xxxxxxXxxxxxx** xxxxx xx xxx **xXxxXxx** xxxxx xx xxx [**XYXYY\_XXXXXXXXXXX\_XXXX**](https://msdn.microsoft.com/library/windows/desktop/ff476220) xxxxxxxxx. Xx xxxx xxx'x xxxxxxx, xxxx xxxx xxxx xx xxxxxxx xx xxxxx!

XxxxxxYX: Xxxxxx xxx xxx xxx xxxxxx xxxxxx

``` syntax
D3D11_SUBRESOURCE_DATA vertexBufferData = {0};
vertexBufferData.pSysMem = cubeVertices;
vertexBufferData.SysMemPitch = 0;
vertexBufferData.SysMemSlicePitch = 0;
CD3D11_BUFFER_DESC vertexBufferDesc(sizeof(cubeVertices), D3D11_BIND_VERTEX_BUFFER);
        
m_d3dDevice->CreateBuffer(
  &vertexBufferDesc,
  &vertexBufferData,
  &m_vertexBuffer);
        
// ...

UINT stride = sizeof(VertexPositionColor);
UINT offset = 0;
m_d3dContext->IASetVertexBuffers(
  0,
  1,
  m_vertexBuffer.GetAddressOf(),
  &stride,
  &offset);
```

### Xxxx Y: Xxxxxx xxx xxxx xxx xxxxx xxxxxx

Xxxxx xxxxxxx xxx xx xxxxxxxxx xxx xx xxxxx xxx xxxxxx xxxxxx xx xxxx xx xxxxxxxxxx xxxxxxxx. Xxxxxxxx xxxx xxx xxx xxxxxxxx, xx xxx xxxx xx xxxx xxxxxx xxxxxxxx. Xx xxxx xxxxxx xxxxxxx xx XxxxXX XX Y.Y, xx xxxxx xxxxxx xx xxxxxxx xxx xxxxx xx x xxxxxxx xxxxxxx xxxxxx xxx xxx xxxxxx xxxxxxx xxx xxxxxxx xxxxxxx xxx xxxxxx xxxx xx.

Xxxx xxx'xx xxxxx xx xxxx, xxx xxxx xxxx xxx xxxxxx xxx xxx xxxxx xxxxxx xxxxx, xxx xxxx **xxXxxxXxxxxxxx**.

XxxxXX XX Y.Y: Xxxx xxx xxxxx xxxxx xx xxx xxxx xxxx.

``` syntax
GLuint indexBuffer;

// ...

glGenBuffers(1, &renderer->indexBuffer);    
glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, renderer->indexBuffer);   
glBufferData(GL_ELEMENT_ARRAY_BUFFER, 
  sizeof(GLuint) * CUBE_INDICES, 
  renderer->vertexIndices, 
  GL_STATIC_DRAW);

// ...
// Drawing function

// Bind the index buffer
glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, renderer->indexBuffer);
glDrawElements (GL_TRIANGLES, renderer->numIndices, GL_UNSIGNED_INT, 0);
```

Xxxx XxxxxxYX, xx'x x xxx xxxx xxxxxxx xxxxxxx, xxxxxx x xxx xxxx xxxxxxxx. Xxxxxx xxx xxxxx xxxxxx xx x XxxxxxYX xxxxxxxxxxx xx xxx [**XXYXYYXxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476385) xxx xxxxxxx xxxx xxx xxxxxxxxxx XxxxxxYX. Xxx xx xxxx xx xxxxxxx [**XXYXYYXxxxxxXxxxxxx::XXXxxXxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/desktop/bb173588) xxxx xxx xxxxxxxxxx xxxxxxxxxxx xxx xxx xxxxx xxxxx, xx xxxxxxx. (Xxxxx, xxxxxx xxxx xxx xxxxxx xxx xxxxxxx xx xxx **xxxxXxxxxxx** xxxxx xx xxx **xXxxXxx** xxxxx xx xxx [**XYXYY\_XXXXXXXXXXX\_XXXX**](https://msdn.microsoft.com/library/windows/desktop/ff476220) xxxxxxxxx.)

XxxxxxYX: Xxxxxx xxx xxxxx xxxxxx.

``` syntax
m_indexCount = ARRAYSIZE(cubeIndices);

D3D11_SUBRESOURCE_DATA indexBufferData = {0};
indexBufferData.pSysMem = cubeIndices;
indexBufferData.SysMemPitch = 0;
indexBufferData.SysMemSlicePitch = 0;
CD3D11_BUFFER_DESC indexBufferDesc(sizeof(cubeIndices), D3D11_BIND_INDEX_BUFFER);

m_d3dDevice->CreateBuffer(
  &indexBufferDesc,
  &indexBufferData,
  &m_indexBuffer);

// ...

m_d3dContext->IASetIndexBuffer(
  m_indexBuffer.Get(),
  DXGI_FORMAT_R16_UINT,
  0);
```

Xxxxx, xxx xxxx xxxx xxx xxxxxxxxx xxxx x xxxx xx [**XXYXYYXxxxxxXxxxxxx::XxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476409) (xx [**XXYXYYXxxxxxXxxxxxx::Xxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476407) xxx xxxxxxxxx xxxxxxxx), xx xxxxxxx. (Xxx xxxx xxxxxxx, xxxx xxxxx xx [Xxxx xx xxx xxxxxx](draw-to-the-screen.md).)

XxxxxxYX: Xxxx xxx xxxxxxx xxxxxxxx.

``` syntax
m_d3dContext->IASetPrimitiveTopology(D3D11_PRIMITIVE_TOPOLOGY_TRIANGLELIST);
m_d3dContext->IASetInputLayout(m_inputLayout.Get());

// ...

m_d3dContext->DrawIndexed(
  m_indexCount,
  0,
  0);
```

## Xxxxxxxx xxxx


[Xxxx xxx xxxxxx xxxxxxx](port-the-shader-config.md)

## Xxxx xxxx

[Xxxx xxx XXXX](port-the-glsl.md)

## Xxxxxxx

Xxxx xxxxxxxxxxx xxxx XxxxxxYX, xxxxxxxx xxx xxxx xxxx xxxxx xxxxxxx xx [**XXYXYYXxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476379) xxxx x xxxxxx xxxx xx xxxxxx xxxxxxxx xxx xxxxxx xxxxxxxxx xxxx xx xx xxxxxxxxx. (Xx xxx XxxxxxYX xxxxxxx xxxxxxxx, xxxx xxxx xx xx xxx xxxxxxxx xxxxxx'x **XxxxxxXxxxxxXxxxxxxx** xxxxxxx. Xxx xxxx xxxx xxxxxxx xxx xxxxxx xxxxxxx ([**XXYXYYXxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476385)), xx xxx xxxxx xxxx, xx xxxxxx xx xxx **Xxxxxx** xxxxxx, xxxxx xxxx xx xxxxx xxx xxxxxxxx xxxxxxxxx xxx xxxxxx xxxxxx xxx xxxx xxx xxxx.

## Xxxxxxx xxxxxx


* [Xxx xx: xxxx x xxxxxx XxxxXX XX Y.Y xxxxxxxx xx XxxxxxYX YY](port-a-simple-opengl-es-2-0-renderer-to-directx-11-1.md)
* [Xxxx xxx xxxxxx xxxxxxx](port-the-shader-config.md)
* [Xxxx xxx xxxxxx xxxxxxx xxx xxxx](port-the-vertex-buffers-and-data-config.md)
* [Xxxx xxx XXXX](port-the-glsl.md)

 

 




<!--HONumber=Mar16_HO1-->
