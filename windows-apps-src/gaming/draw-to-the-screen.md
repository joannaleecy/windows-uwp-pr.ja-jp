---
xxxxx: Xxxx xx xxx xxxxxx
xxxxxxxxxxx: Xxxxxxx, xx xxxx xxx xxxx xxxx xxxxx xxx xxxxxxxx xxxx xx xxx xxxxxx.
xx.xxxxxxx: xxYYYYYY-xYYY-xYYY-xYYx-YYYYxYYYxYxx
---

# Xxxx xx xxx xxxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


**Xxxxxxxxx XXXx**

-   [**XXYXYYXxxxxxxYX**](https://msdn.microsoft.com/library/windows/desktop/ff476635)
-   [**XXYXYYXxxxxxXxxxxxXxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476582)
-   [**XXXXXXxxxXxxxxY**](https://msdn.microsoft.com/library/windows/desktop/hh404631)

Xxxxxxx, xx xxxx xxx xxxx xxxx xxxxx xxx xxxxxxxx xxxx xx xxx xxxxxx.

Xx XxxxXX XX Y.Y, xxxx xxxxxxx xxxxxxx xx xxxxxxx xx xx XXXXxxxxxx xxxx, xxxxx xxxxxxxx xxx xxxxxx xxx xxxxxxx xxxxxxxxxx xx xxxx xxx xxxxxxxxx xxxxxxxxx xxx xxxxxxx xx xxx xxxxxx xxxxxxx xxxx xxxx xx xxxx xx xxxxxxx xxx xxxxx xxxxx xxxxxxxxx xx xxx xxxxxx. Xxx xxx xxxx xxxxxxx xx xxxxxxxxx xxx xxxxxxxx xxxxxxxxx xx xxxxxxxxx xxxxxxx xxx xxxxxxx xx xxxx xxxxxx xxxxxxxx xx xxx xxxxxxx. Xxx xx xxx xxxxxxx xxxxxxxxx xx xxx "xxxx xxxxxx" (xx "xxxxx xxxxxx xxxxxx") xxxx xxxxxxxx xxx xxxxx, xxxxxxxxxx xxxxxx xxxxxxx, xxxxx xxx xxxxxxxxxxxx xx xxx xxxxxxx.

Xxxx XxxxxxYX, xxx xxxxxxx xx xxxxxxxxxxx xxx xxxxxxxx xxxxxxxxx xxx xxxxxxx xx xxx xxxxxxx xx xxxx xxxxxxxx, xxx xxxxxxxx xxxxx x xxx xxxx XXXx. (X Xxxxxxxxx Xxxxxx Xxxxxx XxxxxxYX xxxxxxxx xxx xxxxxxxxxxxxx xxxxxxxx xxxx xxxxxxx, xxxxxx!) Xx xxxxxx x xxxxxxx (xxxxxx x XxxxxxYX xxxxxx xxxxxxx), xxx xxxx xxxxx xxxxxx xx [**XXYXYYXxxxxxY**](https://msdn.microsoft.com/library/windows/desktop/hh404575) xxxxxx, xxx xxx xx xx xxxxxx xxx xxxxxxxxx xx [**XXYXYYXxxxxxXxxxxxxY**](https://msdn.microsoft.com/library/windows/desktop/hh404598) xxxxxx. Xxxxx xxx xxxxxxx xxx xxxx xx xxxxxxxxxxx xx xxxxxxxxx xxx xxxxxxxx xxxxxxxxx xxx xxxx xxx xxxxxxx xx xxx xxxxxxx.

Xx xxxxx, xxx XXXX XXXx xxxxxxx xxxxxxxxx XXXx xxx xxxxxxxx xxxxxxxxx xxxx xxxxxxxx xxxxxxx xx xxx xxxxxxxx xxxxxxx, xxx XxxxxxYX xxxxxxxx xxx XXXx xxxx xxxxx xxx xx xxxxxxxxx xxxxxxx xxx XXX xxx xxxx xxxx xxxxxxx xxxxxxx xx xxx XXX.

Xxx xxx xxxxxxxx xx xxxxxxxxxx xx xxxx xxxxxx, xxxx xxx xxx xxxxxxxx xxxxx xxxx xxxx XXX:

-   [
            **XXYXYYXxxxxxY**](https://msdn.microsoft.com/library/windows/desktop/hh404575): xxxxxxxx x xxxxxxx xxxxxxxxxxxxxx xx xxx xxxxxxxx xxxxxx xxx xxx xxxxxxxxx.
-   [
            **XXYXYYXxxxxxXxxxxxxY**](https://msdn.microsoft.com/library/windows/desktop/hh404598): xxxxxxxx xxx xxxxxxxxx xx xxxxxxxxx xxxxxxx xxx xxxxx xxxxxxxxx xxxxxxxx.
-   [
            **XXXXXXxxxXxxxxY**](https://msdn.microsoft.com/library/windows/desktop/hh404631): xxx xxxx xxxxx xx xxxxxxxxx xx xxx xxxx xxxxxx xx XxxxXX XX Y.Y. Xx xx xxx xxxxxx xx xxxxxx xx xxx xxxxxxxx xxxxxxx xxxx xxxxxxxx xxx xxxxx xxxxxxxx xxxxx(x) xxx xxxxxxx. Xx xx xxxxxx xxx "xxxx xxxxx" xxxxxxx xx xxx xxxxxxx xxxxxxx xxxx xxx xx xxxxxxx xx xxx "xxxxxxx" xx xxxxxxx xxx xxxxxx xxxxxx xx xxx xxxxxx.
-   [
            **XXYXYYXxxxxxXxxxxxXxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476582): xxxx xxxxxxxx xxx YX xxxxxx xxxxxx xxxx xxx XxxxxxYX xxxxxx xxxxxxx xxxxx xxxx, xxx xxxxx xx xxxxxxxxx xx xxx xxxx xxxxx. Xx xxxx XxxxXX XX Y.Y, xxx xxx xxxx xxxxxxxx xxxxxx xxxxxxx, xxxx xx xxxxx xxx xxx xxxxx xx xxx xxxx xxxxx xxx xxx xxxx xxx xxxxx-xxxx xxxxxxx xxxxxxxxxx.

Xx xxx xxxxxxxx, xxx xxxxxxxx xxxxxx xxxxxxxx xxx xxxxxxxxx xxxxxx:

XxxxxxYX YY: Xxxxxx xxx xxxxxx xxxxxxx xxxxxxxxxxxx

``` syntax
Platform::Agile<Windows::UI::Core::CoreWindow>       m_window;

Microsoft::WRL::ComPtr<ID3D11Device1>                m_d3dDevice;
Microsoft::WRL::ComPtr<ID3D11DeviceContext1>          m_d3dContext;
Microsoft::WRL::ComPtr<IDXGISwapChain1>                      m_swapChainCoreWindow;
Microsoft::WRL::ComPtr<ID3D11RenderTargetView>          m_d3dRenderTargetViewWin;
```

Xxxx'x xxx xxx xxxx xxxxxx xx xxxxxxxxxx xx x xxxxxx xxxxxx xxx xxxxxxxx xx xxx xxxx xxxxx.

``` syntax
ComPtr<ID3D11Texture2D> backBuffer;
m_swapChainCoreWindow->GetBuffer(0, IID_PPV_ARGS(backBuffer));
m_d3dDevice->CreateRenderTargetView(
  backBuffer.Get(),
  nullptr,
  &m_d3dRenderTargetViewWin);
```

Xxx XxxxxxYX xxxxxxx xxxxxxxxxx xxxxxxx xx [**XXXXXXxxxxxxY**](https://msdn.microsoft.com/library/windows/desktop/ff471343) xxx xxx [**XXYXYYXxxxxxxYX**](https://msdn.microsoft.com/library/windows/desktop/ff476635), xxxxx xxxxxxxxxx xxx xxxxxxx xx x "xxxx xxxxxx" xxxx xxx xxxx xxxxx xxx xxx xxx xxxxxxx.

Xxx xxxxxxxxxxxxxx xxx xxxxxxxxxxxxx xx xxx XxxxxxYX xxxxxx xxx xxxxxx xxxxxxx, xx xxxx xx xxx xxxxxx xxxxxxx, xxx xx xxxxx xx xxx xxxxxx **XxxxxxXxxxxxXxxxxxxxx** xxx **XxxxxxXxxxxxXxxxXxxxxxxxxXxxxxxxxx** xxxxxxx xx xxx XxxxxxYX xxxxxxxx.

Xxx xxxx xxxx xx XxxxxxYX xxxxxx xxxxxxx xx xx xxxxxxx xx XXX xxx xxx XXXXxxxxxx xxxx, xxxx [Xxxx XXX xxxx xx XXXX xxx XxxxxxYX](moving-from-egl-to-dxgi.md).

## Xxxxxxxxxxxx

### Xxxx Y: Xxxxxxxxx xxx xxxxx xxx xxxxxxxxxx xx

Xxxxx xxxxxxxx xxx xxxx xxxx (xx xxxx xxxx, xx xxxxxxxx xx xxxxxxxx xxxxxx xxx x xxxx), xxx Xxxxxx xxxxxx xxxx xxx xxxxxxxx xx xxx xxxxxxxxxx xx xx xxxxxxx xxxxxxx (xx XXXXxxxxxx). Xxxx xxxxxxx xxxxxxxx xxx xxxxx xxxxxx xxxx xxxx xx xxxxxxxxx xx xxx xxxxxx xxxxxxx (xx XXXXxxxxxx), xxxxx xxx xxxxxxxxxx xxxxxxx (XXXXxxxxxx). Xx xxxx xxxx, xxx xxxxxxx xxxxxxx xxx xxxxxx xxxx xxxxxxxxxx, xx-xxxxx xxx xxxxx xxxxxx, xxxxx xxx xxxx, xxx xxxxx xx xxxxx xxxxxx xxxxx xx xxx xxxxxxx xxxxxxxx xx xxx xxxxxxx xxxxxxx.

XxxxXX XX Y.Y: Xxxxxxxxx x xxxxx xxx xxxxxxx

``` syntax
void Render(GraphicsContext *drawContext)
{
  Renderer *renderer = drawContext->renderer;

  int loc;
   
  // Set the viewport
  glViewport ( 0, 0, drawContext->width, drawContext->height );
   
   
  // Clear the color buffer
  glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
  glEnable(GL_DEPTH_TEST);


  // Use the program object
  glUseProgram (renderer->programObject);

  // Load the a_position attribute with the vertex position portion of a vertex buffer element
  loc = glGetAttribLocation(renderer->programObject, "a_position");
  glVertexAttribPointer(loc, 3, GL_FLOAT, GL_FALSE, 
      sizeof(Vertex), 0);
  glEnableVertexAttribArray(loc);

  // Load the a_color attribute with the color position portion of a vertex buffer element
  loc = glGetAttribLocation(renderer->programObject, "a_color");
  glVertexAttribPointer(loc, 4, GL_FLOAT, GL_FALSE, 
      sizeof(Vertex), (GLvoid*) (sizeof(float) * 3));
  glEnableVertexAttribArray(loc);

  // Bind the index buffer
  glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, renderer->indexBuffer);

  // Load the MVP matrix
  glUniformMatrix4fv(renderer->mvpLoc, 1, GL_FALSE, (GLfloat*) &renderer->mvpMatrix.m[0][0]);

  // Draw the cube
  glDrawElements(GL_TRIANGLES, renderer->numIndices, GL_UNSIGNED_INT, 0);

  eglSwapBuffers(drawContext->eglDisplay, drawContext->eglSurface);
}
```

Xx XxxxxxYX YY, xxx xxxxxxx xx xxxx xxxxxxx. (Xx'xx xxxxxxxx xxxx xxx'xx xxxxx xxx xxxxxxxx xxx xxxxxx xxxxxx xxxxxxxxxxxxx xxxx xxx XxxxxxYX xxxxxxxx.

-   Xxxxxx xxx xxxxxxxx xxxxxxx (xxx xxxxx-xxxx-xxxxxxxxxx xxxxxx, xx xxxx xxxx) xxxx xxxxx xx [**XXYXYYXxxxxxXxxxxxxY::XxxxxxXxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/desktop/hh446790).
-   Xxx xxx xxxxxx xxxxxx xxxx [**XXYXYYXxxxxxXxxxxxxY::XXXxxXxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476456).
-   Xxx xxx xxxxx xxxxxx xxxx [**XXYXYYXxxxxxXxxxxxxY::XXXxxXxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476453).
-   Xxx xxx xxxxxxxx xxxxxxxx xxxxxxxx (x xxxxxxxx xxxx) xxxx [**XXYXYYXxxxxxXxxxxxxY::XXXxxXxxxxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476455).
-   Xxx xxx xxxxx xxxxxx xx xxx xxxxxx xxxxxx xxxx [**XXYXYYXxxxxxXxxxxxxY::XXXxxXxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476454).
-   Xxxx xxx xxxxxx xxxxxx xxxx [**XXYXYYXxxxxxXxxxxxxY::XXXxxXxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476493).
-   Xxxx xxx xxxxxxxx xxxxxx xxxx [**XXYXYYXxxxxxXxxxxxxY::XXXxxXxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476472).
-   Xxxx xxx xxxxxxx xxxxxxxx xxxxxxx xxx xxxxxxx xxx xxxxxx xxx xxxxx xxxxxxx xx xxx xxxxxx xxxxxx xxxxxx xxxx [**XXYXYYXxxxxxXxxxxxxY::XxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476409).
-   Xxxxxxx xxx xxxxxx xxxxxx xxxxxx xxxx [**XXXXXXxxxXxxxxY::XxxxxxxY**](https://msdn.microsoft.com/library/windows/desktop/hh446797).

XxxxxxYX YY: Xxxxxxxxx x xxxxx xxx xxxxxxx

``` syntax
void RenderObject::Render()
{
  // ...

  // Only update shader resources that have changed since the last frame.
  m_d3dContext->UpdateSubresource(
    m_constantBuffer.Get(),
    0,
    NULL,
    &m_constantBufferData,
    0,
    0);

  // Set up the IA stage corresponding to the current draw operation.
  UINT stride = sizeof(VertexPositionColor);
  UINT offset = 0;
  m_d3dContext->IASetVertexBuffers(
    0,
    1,
    m_vertexBuffer.GetAddressOf(),
    &stride,
    &offset);

  m_d3dContext->IASetIndexBuffer(
    m_indexBuffer.Get(),
    DXGI_FORMAT_R16_UINT,
    0);

  m_d3dContext->IASetPrimitiveTopology(D3D11_PRIMITIVE_TOPOLOGY_TRIANGLELIST);
  m_d3dContext->IASetInputLayout(m_inputLayout.Get());

  // Set up the vertex shader corresponding to the current draw operation.
  m_d3dContext->VSSetShader(
    m_vertexShader.Get(),
    nullptr,
    0);

  m_d3dContext->VSSetConstantBuffers(
    0,
    1,
    m_constantBuffer.GetAddressOf());

  // Set up the pixel shader corresponding to the current draw operation.
  m_d3dContext->PSSetShader(
    m_pixelShader.Get(),
    nullptr,
    0);

  m_d3dContext->DrawIndexed(
    m_indexCount,
    0,
    0);

    // ...

  m_swapChainCoreWindow->Present1(1, 0, &parameters);
}

```

Xxxx [**XXXXXXxxxXxxxxY::XxxxxxxY**](https://msdn.microsoft.com/library/windows/desktop/hh446797) xx xxxxxx, xxxx xxxxx xx xxxxxx xx xxx xxxxxxxxxx xxxxxxx.

## Xxxxxxxx xxxx


[Xxxx xxx XXXX](port-the-glsl.md)

## Xxxxxxx

Xxxx xxxxxxx xxxxxxx xxxx xxxx xx xxx xxxxxxxxxx xxxx xxxx xxxx xxxxxxxxxxx xxxxxx xxxxxxxxx, xxxxxxxxxx xxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) XxxxxxX xxxx. Xx xxxxxxx xxx xxxxxx xxx xxxx xxxxxxxx xxxx, xxxxxxxxxx xxx xxxxx xxxx xxxxxxx xxx xxxxxx xxx xxxxxx xxxxxxxx xxxxx xxx xxxxxxxxxx. XXX xxxx xxxx xx xxxxxxx xxxxxxxx xxxxxx xx xxxx xx xxxxxxx/xxxxxx xxxxxx, xxx xxx xxxxxxxx xxxxxxxxxxxx xxxx xxxxxxxxx xxx xxxxxxxx xxx xxxx xx xx xxxxxxxxx xx x xxxxxx xx xxx xxxxxxx xxxxxxxxxx.

## Xxxxxxx xxxxxx


* [Xxx xx: xxxx x xxxxxx XxxxXX XX Y.Y xxxxxxxx xx XxxxxxYX YY](port-a-simple-opengl-es-2-0-renderer-to-directx-11-1.md)
* [Xxxx xxx xxxxxx xxxxxxx](port-the-shader-config.md)
* [Xxxx xxx XXXX](port-the-glsl.md)
* [Xxxx xx xxx xxxxxx](draw-to-the-screen.md)

 

 




<!--HONumber=Mar16_HO1-->
