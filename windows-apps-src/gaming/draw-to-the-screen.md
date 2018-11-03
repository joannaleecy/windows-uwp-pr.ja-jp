---
author: mtoepke
title: 画面への描画
description: 最後に、回転する立方体を画面に描画するコードを移植します。
ms.assetid: cc681548-f694-f613-a19d-1525a184d4ab
ms.author: mtoepke
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, DirectX, グラフィックス
ms.localizationpriority: medium
ms.openlocfilehash: 0050b854b6c8c02cd6eda5e4903fe07ee25d521d
ms.sourcegitcommit: 144f5f127fc4fbd852f2f6780ef26054192d68fc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/02/2018
ms.locfileid: "5982986"
---
# <a name="draw-to-the-screen"></a><span data-ttu-id="0d145-104">画面への描画</span><span class="sxs-lookup"><span data-stu-id="0d145-104">Draw to the screen</span></span>




**<span data-ttu-id="0d145-105">重要な API</span><span class="sxs-lookup"><span data-stu-id="0d145-105">Important APIs</span></span>**

-   [**<span data-ttu-id="0d145-106">ID3D11Texture2D</span><span class="sxs-lookup"><span data-stu-id="0d145-106">ID3D11Texture2D</span></span>**](https://msdn.microsoft.com/library/windows/desktop/ff476635)
-   [**<span data-ttu-id="0d145-107">ID3D11RenderTargetView</span><span class="sxs-lookup"><span data-stu-id="0d145-107">ID3D11RenderTargetView</span></span>**](https://msdn.microsoft.com/library/windows/desktop/ff476582)
-   [**<span data-ttu-id="0d145-108">IDXGISwapChain1</span><span class="sxs-lookup"><span data-stu-id="0d145-108">IDXGISwapChain1</span></span>**](https://msdn.microsoft.com/library/windows/desktop/hh404631)

<span data-ttu-id="0d145-109">最後に、回転する立方体を画面に描画するコードを移植します。</span><span class="sxs-lookup"><span data-stu-id="0d145-109">Finally, we port the code that draws the spinning cube to the screen.</span></span>

<span data-ttu-id="0d145-110">OpenGL ES 2.0 では、描画コンテキストは EGLContext の型として定義されます。これには、ウィンドウとサーフェスのパラメーターのほか、ウィンドウに表示される最終的な画像の作成に使われるレンダー ターゲットへの描画に必要なリソースが含まれます。</span><span class="sxs-lookup"><span data-stu-id="0d145-110">In OpenGL ES 2.0, your drawing context is defined as an EGLContext type, which contains the window and surface parameters as well the resources necessary for drawing to the render targets that will be used to compose the final image displayed to the window.</span></span> <span data-ttu-id="0d145-111">このコンテキストを使ってグラフィックス リソースを構成し、シェーダー パイプラインの結果をディスプレイに正しく表示します。</span><span class="sxs-lookup"><span data-stu-id="0d145-111">You use this context to configure the graphics resources to correctly display the results of your shader pipeline on the display.</span></span> <span data-ttu-id="0d145-112">主要なリソースの 1 つは "バック バッファー" (または "フレーム バッファー オブジェクト") と呼ばれ、ディスプレイに表示できる最終的な構成済みレンダー ターゲットが含まれます。</span><span class="sxs-lookup"><span data-stu-id="0d145-112">One of the primary resources is the "back buffer" (or "frame buffer object") that contains the final, composited render targets, ready for presentation to the display.</span></span>

<span data-ttu-id="0d145-113">Direct3D を使ってディスプレイに描画するためのグラフィックス リソースを構成するプロセスは、もう少し解説が必要なプロセスであり、かなりの数の API を必要とします </span><span class="sxs-lookup"><span data-stu-id="0d145-113">With Direct3D, the process of configuring the graphics resources for drawing to the display is more didactic, and requires quite a few more APIs.</span></span> <span data-ttu-id="0d145-114">(ただし、Microsoft Visual Studio Direct3D テンプレートを使うと、このプロセスを大幅に簡素化できます)。コンテキスト (Direct3D デバイス コンテキスト) を取得するには、最初に [**ID3D11Device1**](https://msdn.microsoft.com/library/windows/desktop/hh404575) オブジェクトを取得し、それを使って [**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598) オブジェクトを作成、構成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0d145-114">(A Microsoft Visual Studio Direct3D template can significantly simplify this process, though!) To obtain a context (called a Direct3D device context), you must first obtain an [**ID3D11Device1**](https://msdn.microsoft.com/library/windows/desktop/hh404575) object, and use it to create and configure an [**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598) object.</span></span> <span data-ttu-id="0d145-115">これら 2 つのオブジェクトは、ディスプレイへの描画に必要な特定のリソースを構成するために、組み合わせて使われます。</span><span class="sxs-lookup"><span data-stu-id="0d145-115">These two objects are used in conjunction to configure the specific resources you need for drawing to the display.</span></span>

<span data-ttu-id="0d145-116">つまり、DXGI API には、グラフィックス アダプターに直接関係するリソースを管理するための API が主として含まれ、Direct3D には、CPU で実行されるメイン プログラムと GPU の橋渡しをする API が含まれます。</span><span class="sxs-lookup"><span data-stu-id="0d145-116">In short, the DXGI APIs contain primarily APIs for managing resources that directly pertain to the graphics adapter, and Direct3D contains the APIs that allow you to interface between the GPU and your main program running on the CPU.</span></span>

<span data-ttu-id="0d145-117">このサンプルでの比較のために、各 API から該当する型を紹介します。</span><span class="sxs-lookup"><span data-stu-id="0d145-117">For the purposes of comparison in this sample, here are the relevant types from each API:</span></span>

-   <span data-ttu-id="0d145-118">[**ID3D11Device1**](https://msdn.microsoft.com/library/windows/desktop/hh404575): グラフィックス デバイスとそのリソースの仮想表現を提供します。</span><span class="sxs-lookup"><span data-stu-id="0d145-118">[**ID3D11Device1**](https://msdn.microsoft.com/library/windows/desktop/hh404575): provides a virtual representation of the graphics device and its resources.</span></span>
-   <span data-ttu-id="0d145-119">[**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598): バッファーを構成し、レンダリング コマンドを発行するためのインターフェイスを提供します。</span><span class="sxs-lookup"><span data-stu-id="0d145-119">[**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598): provides the interface to configure buffers and issue rendering commands.</span></span>
-   <span data-ttu-id="0d145-120">[**IDXGISwapChain1**](https://msdn.microsoft.com/library/windows/desktop/hh404631): スワップ チェーンは OpenGL ES 2.0 のバック バッファーに似ています。</span><span class="sxs-lookup"><span data-stu-id="0d145-120">[**IDXGISwapChain1**](https://msdn.microsoft.com/library/windows/desktop/hh404631): the swap chain is analogous to the back buffer in OpenGL ES 2.0.</span></span> <span data-ttu-id="0d145-121">これは、ディスプレイに表示する最終的なレンダリング画像を含むグラフィックス アダプターのメモリ領域です。</span><span class="sxs-lookup"><span data-stu-id="0d145-121">It is the region of memory on the graphics adapter that contains the final rendered image(s) for display.</span></span> <span data-ttu-id="0d145-122">これは、最新のレンダリングを画面に表示するために、書き込みと "スワップ" を行うことのできるバッファーをいくつか持つため、"スワップ チェーン" と呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="0d145-122">It is called the "swap chain" because it has several buffers that can be written to and "swapped" to present the latest render to the screen.</span></span>
-   <span data-ttu-id="0d145-123">[**ID3D11RenderTargetView**](https://msdn.microsoft.com/library/windows/desktop/ff476582): Direct3D デバイス コンテキストの描画先の 2D ビットマップ バッファー (スワップ チェーンによって表示される) が含まれます。</span><span class="sxs-lookup"><span data-stu-id="0d145-123">[**ID3D11RenderTargetView**](https://msdn.microsoft.com/library/windows/desktop/ff476582): this contains the 2D bitmap buffer that the Direct3D device context draws into, and which is presented by the swap chain.</span></span> <span data-ttu-id="0d145-124">OpenGL ES 2.0 の場合と同様に、レンダー ターゲットは複数作成できます。その一部はスワップ チェーンにバインドされませんが、マルチパス シェーディング手法で利用されます。</span><span class="sxs-lookup"><span data-stu-id="0d145-124">As with OpenGL ES 2.0, you can have multiple render targets, some of which are not bound to the swap chain but are used for multi-pass shading techniques.</span></span>

<span data-ttu-id="0d145-125">テンプレートのレンダラー オブジェクトには次のフィールドがあります。</span><span class="sxs-lookup"><span data-stu-id="0d145-125">In the template, the renderer object contains the following fields:</span></span>

<span data-ttu-id="0d145-126">Direct3D 11: デバイスとデバイス コンテキストの宣言</span><span class="sxs-lookup"><span data-stu-id="0d145-126">Direct3D 11: Device and device context declarations</span></span>

``` syntax
Platform::Agile<Windows::UI::Core::CoreWindow>       m_window;

Microsoft::WRL::ComPtr<ID3D11Device1>                m_d3dDevice;
Microsoft::WRL::ComPtr<ID3D11DeviceContext1>          m_d3dContext;
Microsoft::WRL::ComPtr<IDXGISwapChain1>                      m_swapChainCoreWindow;
Microsoft::WRL::ComPtr<ID3D11RenderTargetView>          m_d3dRenderTargetViewWin;
```

<span data-ttu-id="0d145-127">次に、バック バッファーをレンダー ターゲットとして構成し、スワップ チェーンに提供する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="0d145-127">Here's how the back buffer is configured as a render target and provided to the swap chain.</span></span>

``` syntax
ComPtr<ID3D11Texture2D> backBuffer;
m_swapChainCoreWindow->GetBuffer(0, IID_PPV_ARGS(backBuffer));
m_d3dDevice->CreateRenderTargetView(
  backBuffer.Get(),
  nullptr,
  &m_d3dRenderTargetViewWin);
```

<span data-ttu-id="0d145-128">Direct3D ランタイムは [**ID3D11Texture2D**](https://msdn.microsoft.com/library/windows/desktop/ff476635) の [**IDXGISurface1**](https://msdn.microsoft.com/library/windows/desktop/ff471343) を暗黙的に作成します。これは、スワップ チェーンで表示に使うことのできる "バック バッファー" としてのテクスチャを表します。</span><span class="sxs-lookup"><span data-stu-id="0d145-128">The Direct3D runtime implicitly creates an [**IDXGISurface1**](https://msdn.microsoft.com/library/windows/desktop/ff471343) for the [**ID3D11Texture2D**](https://msdn.microsoft.com/library/windows/desktop/ff476635), which represents the texture as a "back buffer" that the swap chain can use for display.</span></span>

<span data-ttu-id="0d145-129">レンダー ターゲットのほか、Direct3D デバイスとデバイス コンテキストの初期化と構成は、Direct3D テンプレートのカスタムの **CreateDeviceResources** メソッドと **CreateWindowSizeDependentResources** メソッドで確かめることができます。</span><span class="sxs-lookup"><span data-stu-id="0d145-129">The initialization and configuration of the Direct3D device and device context, as well as the render targets, can be found in the custom **CreateDeviceResources** and **CreateWindowSizeDependentResources** methods in the Direct3D template.</span></span>

<span data-ttu-id="0d145-130">EGL と EGLContext の型に関連する Direct3D デバイス コンテキストについて詳しくは、「[DXGI と Direct3D の EGL コードの比較](moving-from-egl-to-dxgi.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0d145-130">For more info on Direct3D device context as it relates to EGL and the EGLContext type, read [Port EGL code to DXGI and Direct3D](moving-from-egl-to-dxgi.md).</span></span>

## <a name="instructions"></a><span data-ttu-id="0d145-131">手順</span><span class="sxs-lookup"><span data-stu-id="0d145-131">Instructions</span></span>

### <a name="step-1-rendering-the-scene-and-displaying-it"></a><span data-ttu-id="0d145-132">手順 1: シーンのレンダリングと表示</span><span class="sxs-lookup"><span data-stu-id="0d145-132">Step 1: Rendering the scene and displaying it</span></span>

<span data-ttu-id="0d145-133">立方体のデータを更新した後 (この例では y 軸を中心に少し回転させる) で、Render メソッドはビューポートを描画コンテキスト (EGLContext) のサイズに設定します。</span><span class="sxs-lookup"><span data-stu-id="0d145-133">After updating the cube data (in this case, by rotating it slightly around the y axis), the Render method sets the viewport to the dimensions of he drawing context (an EGLContext).</span></span> <span data-ttu-id="0d145-134">このコンテキストには、構成済みのディスプレイ (EGLDisplay) を使ってウィンドウ サーフェス (EGLSurface) に表示される色のバッファーが含まれます。</span><span class="sxs-lookup"><span data-stu-id="0d145-134">This context contains the color buffer that will be displayed to the window surface (an EGLSurface), using the configured display (EGLDisplay).</span></span> <span data-ttu-id="0d145-135">この時点で、この例では、頂点データの属性を更新する、インデックス バッファーを再バインドする、立方体を描画する、表示サーフェスへのシェーディング パイプラインによって描画される色のバッファーでスワップするという一連の処理を行います。</span><span class="sxs-lookup"><span data-stu-id="0d145-135">At this time, the example updates the vertex data attributes, re-binds the index buffer, draws the cube, and swaps in color buffer drawn by the shading pipeline to the display surface.</span></span>

<span data-ttu-id="0d145-136">OpenGL ES 2.0: 表示するフレームのレンダリング</span><span class="sxs-lookup"><span data-stu-id="0d145-136">OpenGL ES 2.0: Rendering a frame for display</span></span>

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

<span data-ttu-id="0d145-137">Direct3D 11 では、プロセスはよく似ています </span><span class="sxs-lookup"><span data-stu-id="0d145-137">In Direct3D 11, the process is very similar.</span></span> <span data-ttu-id="0d145-138">(Direct3D テンプレートのビューポートとレンダー ターゲットの構成を使っていることを前提とします)。</span><span class="sxs-lookup"><span data-stu-id="0d145-138">(We're assuming that you're using the viewport and render target configuration from the Direct3D template.</span></span>

-   <span data-ttu-id="0d145-139">[**ID3D11DeviceContext1::UpdateSubresource**](https://msdn.microsoft.com/library/windows/desktop/hh446790) を呼び出して定数バッファー (この場合はモデル ビュー プロジェクション マトリックス) を更新します。</span><span class="sxs-lookup"><span data-stu-id="0d145-139">Update the constant buffers (the model-view-projection matrix, in this case) with calls to [**ID3D11DeviceContext1::UpdateSubresource**](https://msdn.microsoft.com/library/windows/desktop/hh446790).</span></span>
-   <span data-ttu-id="0d145-140">[**ID3D11DeviceContext1::IASetVertexBuffers**](https://msdn.microsoft.com/library/windows/desktop/ff476456) で頂点バッファーを設定します。</span><span class="sxs-lookup"><span data-stu-id="0d145-140">Set the vertex buffer with [**ID3D11DeviceContext1::IASetVertexBuffers**](https://msdn.microsoft.com/library/windows/desktop/ff476456).</span></span>
-   <span data-ttu-id="0d145-141">[**ID3D11DeviceContext1::IASetIndexBuffer**](https://msdn.microsoft.com/library/windows/desktop/ff476453) でインデックス バッファーを設定します。</span><span class="sxs-lookup"><span data-stu-id="0d145-141">Set the index buffer with [**ID3D11DeviceContext1::IASetIndexBuffer**](https://msdn.microsoft.com/library/windows/desktop/ff476453).</span></span>
-   <span data-ttu-id="0d145-142">[**ID3D11DeviceContext1::IASetPrimitiveTopology**](https://msdn.microsoft.com/library/windows/desktop/ff476455) で特定の三角形のトポロジ (三角形のリスト) を設定します。</span><span class="sxs-lookup"><span data-stu-id="0d145-142">Set the specific triangle topology (a triangle list) with [**ID3D11DeviceContext1::IASetPrimitiveTopology**](https://msdn.microsoft.com/library/windows/desktop/ff476455).</span></span>
-   <span data-ttu-id="0d145-143">[**ID3D11DeviceContext1::IASetInputLayout**](https://msdn.microsoft.com/library/windows/desktop/ff476454) で頂点バッファーの入力レイアウトを設定します。</span><span class="sxs-lookup"><span data-stu-id="0d145-143">Set the input layout of the vertex buffer with [**ID3D11DeviceContext1::IASetInputLayout**](https://msdn.microsoft.com/library/windows/desktop/ff476454).</span></span>
-   <span data-ttu-id="0d145-144">[**ID3D11DeviceContext1::VSSetShader**](https://msdn.microsoft.com/library/windows/desktop/ff476493) で頂点シェーダーをバインドします。</span><span class="sxs-lookup"><span data-stu-id="0d145-144">Bind the vertex shader with [**ID3D11DeviceContext1::VSSetShader**](https://msdn.microsoft.com/library/windows/desktop/ff476493).</span></span>
-   <span data-ttu-id="0d145-145">[**ID3D11DeviceContext1::PSSetShader**](https://msdn.microsoft.com/library/windows/desktop/ff476472) でフラグメント シェーダーをバインドします。</span><span class="sxs-lookup"><span data-stu-id="0d145-145">Bind the fragment shader with [**ID3D11DeviceContext1::PSSetShader**](https://msdn.microsoft.com/library/windows/desktop/ff476472).</span></span>
-   <span data-ttu-id="0d145-146">[**ID3D11DeviceContext1::DrawIndexed**](https://msdn.microsoft.com/library/windows/desktop/ff476409) を使って、シェーダーを通じてインデックス付き頂点を送信し、レンダー ターゲット バッファーに色の結果を出力します。</span><span class="sxs-lookup"><span data-stu-id="0d145-146">Send the indexed vertices through the shaders and output the color results to the render target buffer with [**ID3D11DeviceContext1::DrawIndexed**](https://msdn.microsoft.com/library/windows/desktop/ff476409).</span></span>
-   <span data-ttu-id="0d145-147">[**IDXGISwapChain1::Present1**](https://msdn.microsoft.com/library/windows/desktop/hh446797) でレンダー ターゲット バッファーを表示します。</span><span class="sxs-lookup"><span data-stu-id="0d145-147">Display the render target buffer with [**IDXGISwapChain1::Present1**](https://msdn.microsoft.com/library/windows/desktop/hh446797).</span></span>

<span data-ttu-id="0d145-148">Direct3D 11: 表示するフレームのレンダリング</span><span class="sxs-lookup"><span data-stu-id="0d145-148">Direct3D 11: Rendering a frame for display</span></span>

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

<span data-ttu-id="0d145-149">[**IDXGISwapChain1::Present1**](https://msdn.microsoft.com/library/windows/desktop/hh446797) が呼び出されると、フレームが構成済みのディスプレイに出力されます。</span><span class="sxs-lookup"><span data-stu-id="0d145-149">Once [**IDXGISwapChain1::Present1**](https://msdn.microsoft.com/library/windows/desktop/hh446797) is called, your frame is output to the configured display.</span></span>

## <a name="previous-step"></a><span data-ttu-id="0d145-150">前のステップ</span><span class="sxs-lookup"><span data-stu-id="0d145-150">Previous step</span></span>


[<span data-ttu-id="0d145-151">GLSL の移植</span><span class="sxs-lookup"><span data-stu-id="0d145-151">Port the GLSL</span></span>](port-the-glsl.md)

## <a name="remarks"></a><span data-ttu-id="0d145-152">注釈</span><span class="sxs-lookup"><span data-stu-id="0d145-152">Remarks</span></span>

<span data-ttu-id="0d145-153">この例では、デバイス リソース (特にユニバーサル Windows プラットフォーム (UWP) DirectX アプリのデバイス リソース) の構成に伴う複雑さが目立っていません。</span><span class="sxs-lookup"><span data-stu-id="0d145-153">This example glosses over much of the complexity that goes into configuring device resources, especially for Universal Windows Platform (UWP) DirectX apps.</span></span> <span data-ttu-id="0d145-154">テンプレート コード全体を調べることをお勧めします。その中でも、ウィンドウとデバイス リソースの設定と管理に関係する部分に注目してください。</span><span class="sxs-lookup"><span data-stu-id="0d145-154">We suggest you review the full template code, especially the parts that perform the window and device resource setup and management.</span></span> <span data-ttu-id="0d145-155">UWP アプリは中断/再開イベントだけではなく回転イベントもサポートする必要がありますが、テンプレートを通じて、インターフェイスの喪失や表示パラメーターの変更を処理するうえでのベスト プラクティスを確かめることができます。</span><span class="sxs-lookup"><span data-stu-id="0d145-155">UWP apps have to support rotation events as well as suspend/resume events, and the template demonstrates best practices for handling the loss of an interface or a change in the display parameters.</span></span>

## <a name="related-topics"></a><span data-ttu-id="0d145-156">関連トピック</span><span class="sxs-lookup"><span data-stu-id="0d145-156">Related topics</span></span>


* [<span data-ttu-id="0d145-157">簡単な OpenGL ES 2.0 レンダラーを Direct3D 11 に移植する方法</span><span class="sxs-lookup"><span data-stu-id="0d145-157">How to: port a simple OpenGL ES 2.0 renderer to Direct3D 11</span></span>](port-a-simple-opengl-es-2-0-renderer-to-directx-11-1.md)
* [<span data-ttu-id="0d145-158">シェーダー オブジェクトの移植</span><span class="sxs-lookup"><span data-stu-id="0d145-158">Port the shader objects</span></span>](port-the-shader-config.md)
* [<span data-ttu-id="0d145-159">GLSL の移植</span><span class="sxs-lookup"><span data-stu-id="0d145-159">Port the GLSL</span></span>](port-the-glsl.md)
* [<span data-ttu-id="0d145-160">画面への描画</span><span class="sxs-lookup"><span data-stu-id="0d145-160">Draw to the screen</span></span>](draw-to-the-screen.md)

 

 




