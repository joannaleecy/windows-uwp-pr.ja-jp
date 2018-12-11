---
title: シェーダーの作成とプリミティブの描画
description: ここでは、HLSL ソース ファイルを使い、シェーダーをコンパイルして作成する方法について説明します。作成したシェーダーを使って、ディスプレイ上にプリミティブを描画することができます。
ms.assetid: 91113bbe-96c9-4ef9-6482-39f1ff1a70f4
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10、UWP、ゲーム、シェーダー、プリミティブ、DirectX
ms.localizationpriority: medium
ms.openlocfilehash: 5173adc26e0730ccb80f93fe0c12af286b0c1a49
ms.sourcegitcommit: 8921a9cc0dd3e5665345ae8eca7ab7aeb83ccc6f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/10/2018
ms.locfileid: "8877908"
---
# <a name="create-shaders-and-drawing-primitives"></a><span data-ttu-id="33494-104">シェーダーの作成とプリミティブの描画</span><span class="sxs-lookup"><span data-stu-id="33494-104">Create shaders and drawing primitives</span></span>



<span data-ttu-id="33494-105">ここでは、HLSL ソース ファイルを使い、シェーダーをコンパイルして作成する方法について説明します。作成したシェーダーを使って、ディスプレイ上にプリミティブを描画することができます。</span><span class="sxs-lookup"><span data-stu-id="33494-105">Here, we show you how to use HLSL source files to compile and create shaders that you can then use to draw primitives on the display.</span></span>

<span data-ttu-id="33494-106">頂点シェーダーとピクセル シェーダーを使って、黄色の三角形を作成し描画します。</span><span class="sxs-lookup"><span data-stu-id="33494-106">We create and draw a yellow triangle by using vertex and pixel shaders.</span></span> <span data-ttu-id="33494-107">Direct3D デバイス、スワップ チェーン、レンダー ターゲット ビューを作成した後、ディスク上のバイナリ シェーダー オブジェクト ファイルからデータを読み取ります。</span><span class="sxs-lookup"><span data-stu-id="33494-107">After we create the Direct3D device, the swap chain, and the render-target view, we read data from binary shader object files on the disk.</span></span>

<span data-ttu-id="33494-108">**目標:** シェーダーを作成し、プリミティブを描画する。</span><span class="sxs-lookup"><span data-stu-id="33494-108">**Objective:** To create shaders and to draw primitives.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="33494-109">前提条件</span><span class="sxs-lookup"><span data-stu-id="33494-109">Prerequisites</span></span>


<span data-ttu-id="33494-110">C++ に習熟していることを前提としています。</span><span class="sxs-lookup"><span data-stu-id="33494-110">We assume that you are familiar with C++.</span></span> <span data-ttu-id="33494-111">また、グラフィックス プログラミングの概念に対する基礎的な知識も必要となります。</span><span class="sxs-lookup"><span data-stu-id="33494-111">You also need basic experience with graphics programming concepts.</span></span>

<span data-ttu-id="33494-112">また、「[クイック スタート: DirectX リソースの設定と画像の表示](setting-up-directx-resources.md)」にひととおり目を通しておく必要があります。</span><span class="sxs-lookup"><span data-stu-id="33494-112">We also assume that you went through [Quickstart: setting up DirectX resources and displaying an image](setting-up-directx-resources.md).</span></span>

<span data-ttu-id="33494-113">**完了までの時間:** 20 分。</span><span class="sxs-lookup"><span data-stu-id="33494-113">**Time to complete:** 20 minutes.</span></span>

## <a name="instructions"></a><span data-ttu-id="33494-114">手順</span><span class="sxs-lookup"><span data-stu-id="33494-114">Instructions</span></span>

### <a name="1-compiling-hlsl-source-files"></a><span data-ttu-id="33494-115">1. HLSL ソース ファイルのコンパイル</span><span class="sxs-lookup"><span data-stu-id="33494-115">1. Compiling HLSL source files</span></span>

<span data-ttu-id="33494-116">Microsoft Visual Studio は [fxc.exe](https://msdn.microsoft.com/library/windows/desktop/bb232919) HLSL コード コンパイラを使って .hlsl ソース ファイル (SimpleVertexShader.hlsl と SimplePixelShader.hlsl) を .cso バイナリ シェーダー オブジェクト ファイル (SimpleVertexShader.cso と SimplePixelShader.cso) にコンパイルします。</span><span class="sxs-lookup"><span data-stu-id="33494-116">Microsoft Visual Studio uses the [fxc.exe](https://msdn.microsoft.com/library/windows/desktop/bb232919) HLSL code compiler to compile the .hlsl source files (SimpleVertexShader.hlsl and SimplePixelShader.hlsl) into .cso binary shader object files (SimpleVertexShader.cso and SimplePixelShader.cso).</span></span> <span data-ttu-id="33494-117">HLSL コード コンパイラについて詳しくは、「エフェクト コンパイラ ツール」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="33494-117">For more info about the HLSL code compiler, see Effect-Compiler Tool.</span></span> <span data-ttu-id="33494-118">シェーダー コードのコンパイルについて詳しくは、「[シェーダーのコンパイル](https://msdn.microsoft.com/library/windows/desktop/bb509633)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="33494-118">For more info about compiling shader code, see [Compiling Shaders](https://msdn.microsoft.com/library/windows/desktop/bb509633).</span></span>

<span data-ttu-id="33494-119">以下に示したのは、SimpleVertexShader.hlsl のコードです。</span><span class="sxs-lookup"><span data-stu-id="33494-119">Here is the code in SimpleVertexShader.hlsl:</span></span>

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

<span data-ttu-id="33494-120">以下に示したのは、SimplePixelShader.hlsl のコードです。</span><span class="sxs-lookup"><span data-stu-id="33494-120">Here is the code in SimplePixelShader.hlsl:</span></span>

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

### <a name="2-reading-data-from-disk"></a><span data-ttu-id="33494-121">2. ディスクからのデータの読み取り</span><span class="sxs-lookup"><span data-stu-id="33494-121">2. Reading data from disk</span></span>

<span data-ttu-id="33494-122">DirectX 11 アプリ (ユニバーサル Windows) テンプレート内の DirectXHelper.h から DX::ReadDataAsync 関数を使って、ディスク上のファイルからデータを非同期的に読み取ります。</span><span class="sxs-lookup"><span data-stu-id="33494-122">We use the DX::ReadDataAsync function from DirectXHelper.h in the DirectX 11 App (Universal Windows) template to asynchronously read data from a file on the disk.</span></span>

### <a name="3-creating-vertex-and-pixel-shaders"></a><span data-ttu-id="33494-123">3. 頂点シェーダーとピクセル シェーダーの作成</span><span class="sxs-lookup"><span data-stu-id="33494-123">3. Creating vertex and pixel shaders</span></span>

<span data-ttu-id="33494-124">SimpleVertexShader.cso ファイルからデータを読み取り、そのデータを *vertexShaderBytecode* バイト配列に割り当てます。</span><span class="sxs-lookup"><span data-stu-id="33494-124">We read data from the SimpleVertexShader.cso file and assign the data to the *vertexShaderBytecode* byte array.</span></span> <span data-ttu-id="33494-125">このバイト配列を使って [**ID3D11Device::CreateVertexShader**](https://msdn.microsoft.com/library/windows/desktop/ff476524) を呼び出し、頂点シェーダー ([**ID3D11VertexShader**](https://msdn.microsoft.com/library/windows/desktop/ff476641)) を作成します。</span><span class="sxs-lookup"><span data-stu-id="33494-125">We call [**ID3D11Device::CreateVertexShader**](https://msdn.microsoft.com/library/windows/desktop/ff476524) with the byte array to create the vertex shader ([**ID3D11VertexShader**](https://msdn.microsoft.com/library/windows/desktop/ff476641)).</span></span> <span data-ttu-id="33494-126">三角形が確実に描画されるように、SimpleVertexShader.hlsl ソースで頂点の深度値を 0.5 に設定します。</span><span class="sxs-lookup"><span data-stu-id="33494-126">We set the vertex depth value to 0.5 in the SimpleVertexShader.hlsl source to guarantee that our triangle is drawn.</span></span> <span data-ttu-id="33494-127">[**D3D11\_INPUT\_ELEMENT\_DESC**](https://msdn.microsoft.com/library/windows/desktop/ff476180) 構造体の配列に値を設定して頂点シェーダー コードのレイアウトを記述し、その後、[**ID3D11Device::CreateInputLayout**](https://msdn.microsoft.com/library/windows/desktop/ff476512) を呼び出してレイアウトを作成します。</span><span class="sxs-lookup"><span data-stu-id="33494-127">We populate an array of [**D3D11\_INPUT\_ELEMENT\_DESC**](https://msdn.microsoft.com/library/windows/desktop/ff476180) structures to describe the layout of the vertex shader code and then call [**ID3D11Device::CreateInputLayout**](https://msdn.microsoft.com/library/windows/desktop/ff476512) to create the layout.</span></span> <span data-ttu-id="33494-128">配列には頂点の位置を定義するレイアウト要素が 1 つあります。</span><span class="sxs-lookup"><span data-stu-id="33494-128">The array has one layout element that defines the vertex position.</span></span> <span data-ttu-id="33494-129">SimplePixelShader.cso ファイルからデータを読み取り、そのデータを *pixelShaderBytecode* バイト配列に割り当てます。</span><span class="sxs-lookup"><span data-stu-id="33494-129">We read data from the SimplePixelShader.cso file and assign the data to the *pixelShaderBytecode* byte array.</span></span> <span data-ttu-id="33494-130">このバイト配列を使って [**ID3D11Device::CreatePixelShader**](https://msdn.microsoft.com/library/windows/desktop/ff476513) を呼び出し、ピクセル シェーダー ([**ID3D11PixelShader**](https://msdn.microsoft.com/library/windows/desktop/ff476576)) を作成します。</span><span class="sxs-lookup"><span data-stu-id="33494-130">We call [**ID3D11Device::CreatePixelShader**](https://msdn.microsoft.com/library/windows/desktop/ff476513) with the byte array to create the pixel shader ([**ID3D11PixelShader**](https://msdn.microsoft.com/library/windows/desktop/ff476576)).</span></span> <span data-ttu-id="33494-131">三角形を黄色にするために、SimplePixelShader.hlsl ソースでピクセル値を (1,1,1,1) に設定します。</span><span class="sxs-lookup"><span data-stu-id="33494-131">We set the pixel value to (1,1,1,1) in the SimplePixelShader.hlsl source to make our triangle yellow.</span></span> <span data-ttu-id="33494-132">この値を変更することで色を変えることができます。</span><span class="sxs-lookup"><span data-stu-id="33494-132">You can change the color by changing this value.</span></span>

<span data-ttu-id="33494-133">単純な三角形を定義する頂点バッファーとインデックス バッファーを作成します。</span><span class="sxs-lookup"><span data-stu-id="33494-133">We create vertex and index buffers that define a simple triangle.</span></span> <span data-ttu-id="33494-134">そのためにまず三角形を定義し、次に三角形の定義を使って頂点バッファーとインデックス バッファー ([**D3D11\_BUFFER\_DESC**](https://msdn.microsoft.com/library/windows/desktop/ff476092) と [**D3D11\_SUBRESOURCE\_DATA**](https://msdn.microsoft.com/library/windows/desktop/ff476220)) を記述し、最後にバッファーごとに [**ID3D11Device::CreateBuffer**](https://msdn.microsoft.com/library/windows/desktop/ff476501) を 1 回呼び出します。</span><span class="sxs-lookup"><span data-stu-id="33494-134">To do this, we first define the triangle, next describe the vertex and index buffers ([**D3D11\_BUFFER\_DESC**](https://msdn.microsoft.com/library/windows/desktop/ff476092) and [**D3D11\_SUBRESOURCE\_DATA**](https://msdn.microsoft.com/library/windows/desktop/ff476220)) using the triangle definition, and finally call [**ID3D11Device::CreateBuffer**](https://msdn.microsoft.com/library/windows/desktop/ff476501) once for each buffer.</span></span>

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

<span data-ttu-id="33494-135">頂点シェーダー、ピクセル シェーダー、頂点シェーダー レイアウト、頂点バッファー、インデックス バッファーを使って、黄色の三角形を描画します。</span><span class="sxs-lookup"><span data-stu-id="33494-135">We use the vertex and pixel shaders, the vertex shader layout, and the vertex and index buffers to draw a yellow triangle.</span></span>

### <a name="4-drawing-the-triangle-and-presenting-the-rendered-image"></a><span data-ttu-id="33494-136">4. 三角形の描画とレンダリングされた画像の表示</span><span class="sxs-lookup"><span data-stu-id="33494-136">4. Drawing the triangle and presenting the rendered image</span></span>

<span data-ttu-id="33494-137">シーンをレンダリングして表示し続けるために、無限ループを使います。</span><span class="sxs-lookup"><span data-stu-id="33494-137">We enter an endless loop to continually render and display the scene.</span></span> <span data-ttu-id="33494-138">[**ID3D11DeviceContext::OMSetRenderTargets**](https://msdn.microsoft.com/library/windows/desktop/ff476464) を呼び出して、レンダー ターゲットを出力ターゲットとして指定します。</span><span class="sxs-lookup"><span data-stu-id="33494-138">We call [**ID3D11DeviceContext::OMSetRenderTargets**](https://msdn.microsoft.com/library/windows/desktop/ff476464) to specify the render target as the output target.</span></span> <span data-ttu-id="33494-139">[**ID3D11DeviceContext::ClearRenderTargetView**](https://msdn.microsoft.com/library/windows/desktop/ff476388) の呼び出しに { 0.071f, 0.04f, 0.561f, 1.0f } を渡して、レンダー ターゲットを無地の青色にクリアします。</span><span class="sxs-lookup"><span data-stu-id="33494-139">We call [**ID3D11DeviceContext::ClearRenderTargetView**](https://msdn.microsoft.com/library/windows/desktop/ff476388) with { 0.071f, 0.04f, 0.561f, 1.0f } to clear the render target to a solid blue color.</span></span>

<span data-ttu-id="33494-140">無限ループで、黄色の三角形を青色のサーフェス上に描画します。</span><span class="sxs-lookup"><span data-stu-id="33494-140">In the endless loop, we draw a yellow triangle on the blue surface.</span></span>

**<span data-ttu-id="33494-141">黄色の三角形を描画するには</span><span class="sxs-lookup"><span data-stu-id="33494-141">To draw a yellow triangle</span></span>**

1.  <span data-ttu-id="33494-142">まず、頂点バッファーから入力アセンブラー ステージへのデータの流れを定義するために、[**ID3D11DeviceContext::IASetInputLayout**](https://msdn.microsoft.com/library/windows/desktop/ff476454) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="33494-142">First, we call [**ID3D11DeviceContext::IASetInputLayout**](https://msdn.microsoft.com/library/windows/desktop/ff476454) to describe how vertex buffer data is streamed into the input-assembler stage.</span></span>
2.  <span data-ttu-id="33494-143">次に、[**ID3D11DeviceContext::IASetVertexBuffers**](https://msdn.microsoft.com/library/windows/desktop/ff476456) と [**ID3D11DeviceContext::IASetIndexBuffer**](https://msdn.microsoft.com/library/windows/desktop/ff476453) を呼び出して、頂点バッファーとインデックス バッファーを入力アセンブラー ステージにバインドします。</span><span class="sxs-lookup"><span data-stu-id="33494-143">Next, we call [**ID3D11DeviceContext::IASetVertexBuffers**](https://msdn.microsoft.com/library/windows/desktop/ff476456) and [**ID3D11DeviceContext::IASetIndexBuffer**](https://msdn.microsoft.com/library/windows/desktop/ff476453) to bind the vertex and index buffers to the input-assembler stage.</span></span>
3.  <span data-ttu-id="33494-144">次に、[**ID3D11DeviceContext::IASetPrimitiveTopology**](https://msdn.microsoft.com/library/windows/desktop/ff476455) の呼び出しで [**D3D11\_PRIMITIVE\_TOPOLOGY\_TRIANGLESTRIP**](https://msdn.microsoft.com/library/windows/desktop/ff476189#D3D11_PRIMITIVE_TOPOLOGY_TRIANGLESTRIP) 値を渡し、頂点データを三角形ストリップとして解釈するよう入力アセンブラー ステージに指定します。</span><span class="sxs-lookup"><span data-stu-id="33494-144">Next, we call [**ID3D11DeviceContext::IASetPrimitiveTopology**](https://msdn.microsoft.com/library/windows/desktop/ff476455) with the [**D3D11\_PRIMITIVE\_TOPOLOGY\_TRIANGLESTRIP**](https://msdn.microsoft.com/library/windows/desktop/ff476189#D3D11_PRIMITIVE_TOPOLOGY_TRIANGLESTRIP) value to specify for the input-assembler stage to interpret the vertex data as a triangle strip.</span></span>
4.  <span data-ttu-id="33494-145">次に、[**ID3D11DeviceContext::VSSetShader**](https://msdn.microsoft.com/library/windows/desktop/ff476493) を呼び出して頂点シェーダー ステージを頂点シェーダー コードで初期化し、さらに、[**ID3D11DeviceContext::PSSetShader**](https://msdn.microsoft.com/library/windows/desktop/ff476472) を呼び出してピクセル シェーダー ステージをピクセル シェーダー コードで初期化します。</span><span class="sxs-lookup"><span data-stu-id="33494-145">Next, we call [**ID3D11DeviceContext::VSSetShader**](https://msdn.microsoft.com/library/windows/desktop/ff476493) to initialize the vertex shader stage with the vertex shader code and [**ID3D11DeviceContext::PSSetShader**](https://msdn.microsoft.com/library/windows/desktop/ff476472) to initialize the pixel shader stage with the pixel shader code.</span></span>
5.  <span data-ttu-id="33494-146">最後に、[**ID3D11DeviceContext::DrawIndexed**](https://msdn.microsoft.com/library/windows/desktop/ff476409) を呼び出して三角形を描画し、レンダリング パイプラインに送ります。</span><span class="sxs-lookup"><span data-stu-id="33494-146">Finally, we call [**ID3D11DeviceContext::DrawIndexed**](https://msdn.microsoft.com/library/windows/desktop/ff476409) to draw the triangle and submit it to the rendering pipeline.</span></span>

<span data-ttu-id="33494-147">レンダリングされた画像をウィンドウに表示するために、[**IDXGISwapChain::Present**](https://msdn.microsoft.com/library/windows/desktop/bb174576) を呼び出しています。</span><span class="sxs-lookup"><span data-stu-id="33494-147">We call [**IDXGISwapChain::Present**](https://msdn.microsoft.com/library/windows/desktop/bb174576) to present the rendered image to the window.</span></span>

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

## <a name="summary-and-next-steps"></a><span data-ttu-id="33494-148">要約と次のステップ</span><span class="sxs-lookup"><span data-stu-id="33494-148">Summary and next steps</span></span>


<span data-ttu-id="33494-149">ここでは、頂点シェーダーとピクセル シェーダーを使って、黄色の三角形を作成し描画しました。</span><span class="sxs-lookup"><span data-stu-id="33494-149">We created and drew a yellow triangle by using vertex and pixel shaders.</span></span>

<span data-ttu-id="33494-150">次に、周回する 3D 立方体を作成し、そこに照明効果を適用します。</span><span class="sxs-lookup"><span data-stu-id="33494-150">Next, we create an orbiting 3D cube and apply lighting effects to it.</span></span>

[<span data-ttu-id="33494-151">プリミティブに対する深度と各種効果の使用</span><span class="sxs-lookup"><span data-stu-id="33494-151">Using depth and effects on primitives</span></span>](using-depth-and-effects-on-primitives.md)

 

 




