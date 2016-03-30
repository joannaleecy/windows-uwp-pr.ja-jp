---
xxxxx: Xxxx xxx xxxxxx xxxxxxx
xxxxxxxxxxx: Xxxx xxxxxxx xxx xxxxxx xxxxxxxx xxxx XxxxXX XX Y.Y, xxx xxxxx xxxx xx xx xxx xx xxx xxxxxxxxxx xxxxxx xxx xxxxxxxx xxxxxx xxxxxxx xx XxxxxxYX YY, xxx xx xxxx xxxx xxxx xxx xxxx xxxxxxx xxx xxxxxxxxxxx xxxx xxx xxxxxx xxxxxxx xxxxx xxxx xxx xxxxxxxx.
xx.xxxxxxx: YYYYxYYY-xxYx-YYYx-YxxY-xxYYYxYxxxYY
---

# Xxxx xxx xxxxxx xxxxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


**Xxxxxxxxx XXXx**

-   [**XXYXYYXxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476379)
-   [**XXYXYYXxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476385)

Xxxx xxxxxxx xxx xxxxxx xxxxxxxx xxxx XxxxXX XX Y.Y, xxx xxxxx xxxx xx xx xxx xx xxx xxxxxxxxxx xxxxxx xxx xxxxxxxx xxxxxx xxxxxxx xx XxxxxxYX YY, xxx xx xxxx xxxx xxxx xxx xxxx xxxxxxx xxx xxxxxxxxxxx xxxx xxx xxxxxx xxxxxxx xxxxx xxxx xxx xxxxxxxx.

> **Xxxx**   Xxxx xxx xxxxxxx x xxx XxxxxxYX xxxxxxx? Xx xxx, xxxxxx xxx xxxxxxxxxxxx xx [Xxxxxx x xxx XxxxxxX YY xxxxxxx xxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX)](user-interface.md). Xxxx xxxxxxxxxxx xxxxxxx xxxx xxx xxxx xxx xxxxxxx xxx XXXX xxx XxxxxxYX xxxxxxxxx xxx xxxxxxx xx xxx xxxxxx, xxx xxxxx xxx xxxxxxxx xx xxx xxxxxxxx.

 

Xxxx xxxx XxxxXX XX Y.Y, xxx xxxxxxxx xxxxxxx xx XxxxxxYX xxxx xx xxxxxxxxxx xxxx x xxxxxxx xxxxxxx. Xxxxxxx, XxxxxxYX xxxx xxx xxxx xxx xxxxxxx xx x xxxxxx xxxxxxx xxxxxx xxx xx; xxxxxxx, xxx xxxx xxxxxx xxx xxxxxxx xxxxxxxx xx x [**XXYXYYXxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476385). Xxxx xxxx xxxxxxx xxx XxxxXX XX Y.Y xxxxxxx xxx xxxxxxxx xxx xxxxxxx xxxxxx xxxxxxx, xxx xxxxxxxx xxx xxxx xxx xxxxxxxxxxxxx XXX xxxxxxxxx xx XxxxxxYX.

Xxxxxxxxxxxx
------------

### Xxxx Y: Xxxxxxx xxx xxxxxxx

Xx xxxx xxxxxx XxxxXX XX Y.Y xxxxxx, xxx xxxxxxx xxx xxxxxx xx xxxx xxxxx xxx xxxxxx xx xxxxxx xxxx xxx xxx-xxxx xxxxxxxxxxx.

XxxxXX XX Y.Y: Xxxxxxx x xxxxxx

``` syntax
GLuint __cdecl CompileShader (GLenum shaderType, const char *shaderSrcStr)
// shaderType can be GL_VERTEX_SHADER or GL_FRAGMENT_SHADER. Returns 0 if compilation fails.
{
  GLuint shaderHandle;
  GLint compiledShaderHandle;
   
  // Create an empty shader object.
  shaderHandle = glCreateShader(shaderType);

  if (shaderHandle == 0)
  return 0;

  // Load the GLSL shader source as a string value. You could obtain it from
  // from reading a text file or hardcoded.
  glShaderSource(shaderHandle, 1, &shaderSrcStr, NULL);
   
  // Compile the shader.
  glCompileShader(shaderHandle);

  // Check the compile status
  glGetShaderiv(shaderHandle, GL_COMPILE_STATUS, &compiledShaderHandle);

  if (!compiledShaderHandle) // error in compilation occurred
  {
    // Handle any errors here.
              
    glDeleteShader(shaderHandle);
    return 0;
  }

  return shaderHandle;

}
```

Xx XxxxxxYX, xxxxxxx xxx xxx xxxxxxxx xxxxxx xxx-xxxx; xxxx xxx xxxxxx xxxxxxxx xx XXX xxxxx xxxx xxx xxxx xx xxx xxxxxxx xx xxxxxxxx. Xxxx xxx xxxxxxx xxxx xxx xxxx Xxxxxxxxx Xxxxxx Xxxxxx, xxx XXXX xxxxx xxx xxxxxxxx xx XXX (.xxx) xxxxx xxxx xxxx xxx xxxx xxxx. Xxxx xxxx xxx xxxxxxx xxxxx XXX xxxxx xxxx xxxx xxx xxxx xxx xxxxxxx xx!

> **Xxxx**   Xxx xxxxxxxxx xxxxxxx xxxxxxxx xxx xxxxxx xxxxxxx xxx xxxxxxxxxxx xxxxxxxxxxxxxx xxxxx xxx **xxxx** xxxxxxx xxx xxxxxx xxxxxx. XxxxXxxxXxxxx() xx x xxxxxx xxxxxxxxxxx xxx xxx xxxxxxxx xxxx xxxxx xx x XXX xxxx xx xx xxxxx xx xxxx xxxx (xxxxXxxx).

 

XxxxxxYX YY: Xxxxxxx x xxxxxx

``` syntax
auto loadVSTask = DX::ReadDataAsync(m_projectDir + "SimpleVertexShader.cso");
auto loadPSTask = DX::ReadDataAsync(m_projectDir + "SimplePixelShader.cso");

auto createVSTask = loadVSTask.then([this](Platform::Array<byte>^ fileData) {

m_d3dDevice->CreateVertexShader(
  fileData->Data,
  fileData->Length,
  nullptr,
  &m_vertexShader);

auto createPSTask = loadPSTask.then([this](Platform::Array<byte>^ fileData) {
  m_d3dDevice->CreatePixelShader(
    fileData->Data,
    fileData->Length,
    nullptr,
    &m_pixelShader;
};
```

### Xxxx Y: Xxxxxx xxx xxxx xxx xxxxxx xxx xxxxxxxx (xxxxx) xxxxxxx

XxxxXX XX Y.Y xxx xxx xxxxxx xx x xxxxxx "xxxxxxx", xxxxx xxxxxx xx xxx xxxxxxxxx xxxxxxx xxx xxxx xxxxxxx xxxxxxx xx xxx XXX xxx xxx xxxxxxx, xxxxx xxx xxxxxxxx xx xxx XXX. Xxxxxxx xxx xxxxxxxx (xx xxxxxx xxxx xxxxxxxx xxxxxxx) xxx xxxxxxxxxx xxxx x xxxxxxx, xxxxx xxxxxxx xxxxxxxxx xx xxx XXX.

XxxxXX XX Y.Y: Xxxxxxx xxx xxxxxx xxx xxxxxxxx xxxxxxx xxxx x xxxxxxx xxxxxxx

``` syntax
GLuint __cdecl LoadShaderProgram (const char *vertShaderSrcStr, const char *fragShaderSrcStr)
{
  GLuint programObject, vertexShaderHandle, fragmentShaderHandle;
  GLint linkStatusCode;

  // Load the vertex shader and compile it to an internal executable format.
  vertexShaderHandle = CompileShader(GL_VERTEX_SHADER, vertShaderSrcStr);
  if (vertexShaderHandle == 0)
  {
    glDeleteShader(vertexShaderHandle);
    return 0;
  }

   // Load the fragment/pixel shader and compile it to an internal executable format.
  fragmentShaderHandle = CompileShader(GL_FRAGMENT_SHADER, fragShaderSrcStr);
  if (fragmentShaderHandle == 0)
  {
    glDeleteShader(fragmentShaderHandle);
    return 0;
  }

  // Create the program object proper.
  programObject = glCreateProgram();
   
  if (programObject == 0)    return 0;

  // Attach the compiled shaders
  glAttachShader(programObject, vertexShaderHandle);
  glAttachShader(programObject, fragmentShaderHandle);

  // Compile the shaders into binary executables in memory and link them to the program object..
  glLinkProgram(programObject);

  // Check the project object link status and determine if the program is available.
  glGetProgramiv(programObject, GL_LINK_STATUS, &linkStatusCode);

  if (!linkStatusCode) // if link status <> 0
  {
    // Linking failed; delete the program object and return a failure code (0).

    glDeleteProgram (programObject);
    return 0;
  }

  // Deallocate the unused shader resources. The actual executables are part of the program object.
  glDeleteShader(vertexShaderHandle);
  glDeleteShader(fragmentShaderHandle);

  return programObject;
}

// ...

glUseProgram(renderer->programObject);
```

XxxxxxYX xxxx xxx xxxx xxx xxxxxxx xx x xxxxxx xxxxxxx xxxxxx. Xxxxxx, xxx xxxxxxx xxx xxxxxxx xxxx xxx xx xxx xxxxxx xxxxxxxx xxxxxxx xx xxx [**XXYXYYXxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476379) xxxxxxxxx (xxxx xx [**XXYXYYXxxxxx::XxxxxxXxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476524) xx [**XXYXYYXxxxxx::XxxxxxXxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476513)) xx xxxxxx. Xx xxx xxx xxxxxxx xxx xxx xxxxxxx xxxxxxx xxxxxxx, xx xxxxxxx xxxx xx xxxxxxxxxxxxx [**XXYXYYXxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476385) xxxx x xxx xxxxxx xxxxxx, xxxx xx [**XXYXYYXxxxxxXxxxxxx::XXXxxXxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476493) xxx xxx xxxxxx xxxxxx xx [**XXYXYYXxxxxxXxxxxxx::XXXxxXxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476472) xxx xxx xxxxxxxx xxxxxx.

XxxxxxYX YY: Xxx xxx xxxxxxx xxx xxx xxxxxxxx xxxxxx xxxxxxx xxxxxxx.

``` syntax
m_d3dContext->VSSetShader(
  m_vertexShader.Get(),
  nullptr,
  0);

m_d3dContext->PSSetShader(
  m_pixelShader.Get(),
  nullptr,
  0);
```

### Xxxx Y: Xxxxxx xxx xxxx xx xxxxxx xx xxx xxxxxxx

Xx xxx XxxxXX XX Y.Y xxxxxxx, xx xxxx xxx **xxxxxxx** xx xxxxxxx xxx xxx xxxxxx xxxxxxxx:

-   **x\_xxxXxxxxx**: x YxY xxxxx xx xxxxxx xxxx xxxxxxxxxx xxx xxxxx xxxxx-xxxx-xxxxxxxxxx xxxxxxxxxxxxxx xxxxxx xxxx xxxxx xxx xxxxx xxxxxxxxxxx xxx xxx xxxx xxx xxxxxxxxxx xxxx xxxx YX xxxxxxxxxx xxxxxxxxxxx xxx xxxx xxxxxxxxxx.

Xxx xxx **xxxxxxxxx** xxxxxx xxx xxx xxxxxx xxxx:

-   **x\_xxxxxxxx**: x Y-xxxxx xxxxxx xxx xxx xxxxx xxxxxxxxxxx xx x xxxxxx.
-   **x\_xxxxx**: X Y-xxxxx xxxxxx xxx xxx XXXX xxxxx xxxxx xxxxxxxxxx xxxx xxx xxxxxx.

Xxxx XX XX Y.Y: XXXX xxxxxxxxxxx xxx xxx xxxxxxxx xxx xxxxxxxxxx

``` syntax
uniform mat4 u_mvpMatrix;
attribute vec4 a_position;
attribute vec4 a_color;
```

Xxx xxxxxxxxxxxxx xxxx xxxxxxx xxxxxxxxx xxx xxxxxxx xx xxxxxx xx xxx xxxxxxxx xxxxxx, xx xxxx xxxx. (Xxxxx xx xxx xxxxxx xx [Xxx xx: xxxx x xxxxxx XxxxXX XX Y.Y xxxxxxxx xx XxxxxxYX YY](port-a-simple-opengl-es-2-0-renderer-to-directx-11-1.md).) Xxxx xx'xx xxxx xxxx, xx xxxx xx xxxxxxx xxx xxxxxxxxx xx xxxxxx xxxxx xxx xxxx xxxxxxx xxxx xxxxxx xxxxx xxxxxx xxx xxx xxxxxx xxxxxxxx, xxxxx xx xxxxxxxxx xx xxxxx xxxxxx x xxxx xxxx:

XxxxXX XX Y.Y: Xxxxxxx xxx xxxxxxxx xx xxx xxxxxxx xxx xxxxxxxxx xxxx

``` syntax

// Inform the shader of the attribute locations
loc = glGetAttribLocation(renderer->programObject, "a_position");
glVertexAttribPointer(loc, 3, GL_FLOAT, GL_FALSE, 
    sizeof(Vertex), 0);
glEnableVertexAttribArray(loc);

loc = glGetAttribLocation(renderer->programObject, "a_color");
glVertexAttribPointer(loc, 4, GL_FLOAT, GL_FALSE, 
    sizeof(Vertex), (GLvoid*) (sizeof(float) * 3));
glEnableVertexAttribArray(loc);


// Inform the shader program of the uniform location
renderer->mvpLoc = glGetUniformLocation(renderer->programObject, "u_mvpMatrix");
```

XxxxxxYX xxxx xxx xxxx xxx xxxxxxx xx xx "xxxxxxxxx" xx x "xxxxxxx" xx xxx xxxx xxxxx (xx, xx xxxxx, xx xxxx xxx xxxxx xxxx xxxxxx). Xxxxxx, xx xxx xxxxxxxx xxxxxxx, xxxxxxxxxxx xx XxxxxxYX xxxxxxxxxxxx -- xxxxxxxxx xxxx xxx xxxxxx xxxxxxx xxx xxxx xxxxxxx xxx xxx xxxxxx xxxxxxxx. Xxxx xx xxxxx xxxxxxxxxxxx, xxxx xx xxxxxx xxxxxxxxx xxx xxxxxx, xxx xxxxxxxxx xx XXXX xxxxxxxxx. Xxx xxxx xxxx xx xxxxxxxx xxxxxxx xxx XXXX xxxxxxxxx xx xxxx xxxxxx xx XxxxXX XX Y.Y xxxxxxxx, xxxx [Xxxx xxxxx xxxxxx xxxxxxx, xxxxxxxx, xxx xxxxxxxxxx](porting-uniforms-and-attributes.md).

Xxxx xxxxxx xxxx xxxxxxx xx XxxxxxYX, xx xxxxxxx xxx xxxxxxx xx x XxxxxxYX xxxxxxxx xxxxxx (xxxxxxx) xxx xxxxxx xx x xxxxxxxx xxx xxxxxx xxxx xxx **xxxxxxxx** XXXX xxxxxxxx. Xxx xxx xxxxxx xxxxxxxxxx xxx xxxxxxx xx xxxxx xxxxxxxx xx xxx xxxxxx xxxxxxxx xxxxxx, xxx xxx xxxx xxxxxxxx [XXXX xxxxxxxxx](https://msdn.microsoft.com/library/windows/desktop/bb205574) (XXXXXXXX xxx XXXXXY) xxxx xxxxxx xxx xxxxxxx. Xxx xxxxx xxxxxx xxxxx xx XX\_XXXXXXXX, xxxx xxx XX\_ xxxxxx xxxxxxxxxx xxxx xx xx x xxxxxx xxxxx xxxxxxxxx xx xxx XXX. (Xx xxxx xxxx, xx xx x xxxxx xxxxxxxx xxxxxxxxx xxxxxx xxxx xxxxxxxxxx.) XxxxxxXxxxxxXxxxx xxx XxxxxXxxxxxXxxxx xxx xxx xxxxxxxx xx xxxxxxxx xxxxxxx xxxxxxx xxx xxxxxx xxxx xx xxxx xx xxxxxx xxx xxxxxx xxxxxx (xxx [Xxxx xxx xxxxxx xxxxxxx xxx xxxx](port-the-vertex-buffers-and-data-config.md)), xxx xxx xxxx xxx xxx xxxxxx xx xxxxxxxxx xx xxx xxxxxx xx x xxxxxxxx xxxxx xx xxx xxxxxxxx, xxxxx xx xxxx xxxx xx xxx xxxxxx xxxxxx.

XxxxxxYX: XXXX xxxxxxxxxxx xxx xxx xxxxxxxx xxxxxxx xxx xxxxxx xxxx

``` syntax
cbuffer ModelViewProjectionConstantBuffer : register(b0)
{
  matrix mvp;
};

// Per-vertex data used as input to the vertex shader.
struct VertexShaderInput
{
  float4 pos : POSITION;
  float4 color : COLOR0;
};

// Per-vertex color data passed through the pixel shader.
struct PixelShaderInput
{
  float4 pos : SV_POSITION;
  float3 color : COLOR0;
};
```

Xxx xxxx xxxx xx xxxxxxx xx xxxxxxxx xxxxxxx xxx xxx xxxxxxxxxxx xx XXXX xxxxxxxxx, xxxx [Xxxx xxxxx xxxxxx xxxxxxx, xxxxxxxx, xxx xxxxxxxxxx](porting-uniforms-and-attributes.md).

Xxxx xxx xxx xxxxxxxxxx xxx xxx xxxxxx xx xxx xxxx xxxxxx xx xxx xxxxxx xxxxxxxx xxxx x xxxxxxxx xx xxxxxx xxxxxx.

XxxxxxYX YY: Xxxxxxxxx xxx xxxxxxxx xxx xxxxxx xxxxxxx xxxxxx

``` syntax
// Constant buffer used to send MVP matrices to the vertex shader.
struct ModelViewProjectionConstantBuffer
{
  DirectX::XMFLOAT4X4 modelViewProjection;
};

// Used to send per-vertex data to the vertex shader.
struct VertexPositionColor
{
  DirectX::XMFLOAT4 pos;
  DirectX::XMFLOAT4 color;
};
```

Xxx xxx XxxxxxXXxxx XX\* xxxxx xxx xxxx xxxxxxxx xxxxxx xxxxxxxx, xxxxx xxxx xxxxxxx xxxxxx xxxxxxx xxx xxxxxxxxx xxx xxx xxxxxxxx xxxx xxxx xxx xxxx xx xxx xxxxxx xxxxxxxx. Xx xxx xxx xxxxxxxx Xxxxxxx xxxxxxxx xxxxx xxxxx xxx xxxxxx, xxx xxxx xxxxxxx xxx xxxxxxx xxx xxxxxxxxx xxxxxxxx.

Xx xxxx x xxxxxxxx xxxxxx, xxxxxx x xxxxxx xxxxxxxxxxx xx x [**XXYXYY\_XXXXXX\_XXXX**](https://msdn.microsoft.com/library/windows/desktop/jj151620) xxxxxxxxx, xxx xxxx xx xx [**XXYXXxxxxx::XxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476501). Xxxx, xx xxxx xxxxxx xxxxxx, xxxx xxx xxxxxxxx xxxxxx xx [**XXYXYYXxxxxxXxxxxxx::XxxxxxXxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476486) xxxxxx xxxxxxx.

XxxxxxYX YY: Xxxx xxx xxxxxxxx xxxxxx

``` syntax
CD3D11_BUFFER_DESC constantBufferDesc(sizeof(ModelViewProjectionConstantBuffer), D3D11_BIND_CONSTANT_BUFFER);

m_d3dDevice->CreateBuffer(
  &constantBufferDesc,
  nullptr,
  &m_constantBuffer);

// ...

// Only update shader resources that have changed since the last frame.
m_d3dContext->UpdateSubresource(
  m_constantBuffer.Get(),
  0,
  NULL,
  &m_constantBufferData,
  0,
  0);
```

Xxx xxxxxx xxxxxx xx xxxxxxx xxx xxxxxxx xxxxxxxxx, xxx xx xxxxxxxxx xx xxx xxxx xxxx, [Xxxx xxx xxxxxx xxxxxxx xxx xxxx](port-the-vertex-buffers-and-data-config.md).

Xxxx xxxx
---------

[Xxxx xxx xxxxxx xxxxxxx xxx xxxx](port-the-vertex-buffers-and-data-config.md)
## Xxxxxxx xxxxxx


[Xxx xx: xxxx x xxxxxx XxxxXX XX Y.Y xxxxxxxx xx XxxxxxYX YY](port-a-simple-opengl-es-2-0-renderer-to-directx-11-1.md)

[Xxxx xxx xxxxxx xxxxxxx xxx xxxx](port-the-vertex-buffers-and-data-config.md)

[Xxxx xxx XXXX](port-the-glsl.md)

[Xxxx xx xxx xxxxxx](draw-to-the-screen.md)

 

 




<!--HONumber=Mar16_HO1-->
