---
author: mtoepke
title: プリミティブに対する深度と各種効果の使用
description: ここでは、深度、視点、色、その他の効果をプリミティブに対して使う方法について説明します。
ms.assetid: 71ef34c5-b4a3-adae-5266-f86ba257482a
ms.author: mtoepke
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, 深度, 効果, プリミティブ, DirectX
ms.localizationpriority: medium
ms.openlocfilehash: f81c441910cd0d0205641a119c243cb22d0b695e
ms.sourcegitcommit: ed0304b8a214c03b8aab74b8ef12c9f82b8e3c5f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/19/2018
ms.locfileid: "7304844"
---
# <a name="use-depth-and-effects-on-primitives"></a><span data-ttu-id="24205-104">プリミティブに対する深度と各種効果の使用</span><span class="sxs-lookup"><span data-stu-id="24205-104">Use depth and effects on primitives</span></span>



<span data-ttu-id="24205-105">ここでは、深度、視点、色、その他の効果をプリミティブに対して使う方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="24205-105">Here, we show you how to use depth, perspective, color, and other effects on primitives.</span></span>

<span data-ttu-id="24205-106">**目標:** 3D オブジェクトを作成し、基本的な頂点の照明や色付けをオブジェクトに適用する。</span><span class="sxs-lookup"><span data-stu-id="24205-106">**Objective:** To create a 3D object and apply basic vertex lighting and coloring to it.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="24205-107">前提条件</span><span class="sxs-lookup"><span data-stu-id="24205-107">Prerequisites</span></span>


<span data-ttu-id="24205-108">C++ に習熟していることを前提としています。</span><span class="sxs-lookup"><span data-stu-id="24205-108">We assume that you are familiar with C++.</span></span> <span data-ttu-id="24205-109">また、グラフィックス プログラミングの概念に対する基礎的な知識も必要となります。</span><span class="sxs-lookup"><span data-stu-id="24205-109">You also need basic experience with graphics programming concepts.</span></span>

<span data-ttu-id="24205-110">加えて、「[クイック スタート: DirectX リソースの設定と画像の表示](setting-up-directx-resources.md)」と「[シェーダーの作成とプリミティブの描画](creating-shaders-and-drawing-primitives.md)」にひととおり目を通しておく必要があります。</span><span class="sxs-lookup"><span data-stu-id="24205-110">We also assume that you went through [Quickstart: setting up DirectX resources and displaying an image](setting-up-directx-resources.md) and [Creating shaders and drawing primitives](creating-shaders-and-drawing-primitives.md).</span></span>

<span data-ttu-id="24205-111">**完了までの時間:** 20 分。</span><span class="sxs-lookup"><span data-stu-id="24205-111">**Time to complete:** 20 minutes.</span></span>

<a name="instructions"></a><span data-ttu-id="24205-112">手順</span><span class="sxs-lookup"><span data-stu-id="24205-112">Instructions</span></span>
------------

### <a name="1-defining-cube-variables"></a><span data-ttu-id="24205-113">1. 立方体変数の定義</span><span class="sxs-lookup"><span data-stu-id="24205-113">1. Defining cube variables</span></span>

<span data-ttu-id="24205-114">まず、立方体の **SimpleCubeVertex** 構造体と **ConstantBuffer** 構造体を定義する必要があります。</span><span class="sxs-lookup"><span data-stu-id="24205-114">First, we need to define the **SimpleCubeVertex** and **ConstantBuffer** structures for the cube.</span></span> <span data-ttu-id="24205-115">立方体の頂点の位置と色に加え、その見え方が、これらの構造体によって指定されます。</span><span class="sxs-lookup"><span data-stu-id="24205-115">These structures specify the vertex positions and colors for the cube and how the cube will be viewed.</span></span> <span data-ttu-id="24205-116">[**ID3D11DepthStencilView**](https://msdn.microsoft.com/library/windows/desktop/ff476377) と [**ID3D11Buffer**](https://msdn.microsoft.com/library/windows/desktop/ff476351) を [**ComPtr**](https://msdn.microsoft.com/library/windows/apps/br244983.aspx) で宣言し、**ConstantBuffer** のインスタンスを宣言します。</span><span class="sxs-lookup"><span data-stu-id="24205-116">We declare [**ID3D11DepthStencilView**](https://msdn.microsoft.com/library/windows/desktop/ff476377) and [**ID3D11Buffer**](https://msdn.microsoft.com/library/windows/desktop/ff476351) with [**ComPtr**](https://msdn.microsoft.com/library/windows/apps/br244983.aspx) and declare an instance of **ConstantBuffer**.</span></span>

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

### <a name="2-creating-a-depth-stencil-view"></a><span data-ttu-id="24205-117">2. 深度ステンシル ビューの作成</span><span class="sxs-lookup"><span data-stu-id="24205-117">2. Creating a depth stencil view</span></span>

<span data-ttu-id="24205-118">レンダー ターゲット ビューに加え、深度ステンシル ビューも作成します。</span><span class="sxs-lookup"><span data-stu-id="24205-118">In addition to creating the render-target view, we also create a depth-stencil view.</span></span> <span data-ttu-id="24205-119">深度/ステンシル ビューによって、カメラに近いオブジェクトをカメラから遠いオブジェクトの前にレンダリングする Direct3D の処理を効率化できます。</span><span class="sxs-lookup"><span data-stu-id="24205-119">The depth-stencil view enables Direct3D to efficiently render objects closer to the camera in front of objects further from the camera.</span></span> <span data-ttu-id="24205-120">深度ステンシル バッファーのビューを作成する前に、深度ステンシル バッファーを作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="24205-120">Before we can create a view to a depth-stencil buffer, we must create the depth-stencil buffer.</span></span> <span data-ttu-id="24205-121">[**D3D11\_TEXTURE2D\_DESC**](https://msdn.microsoft.com/library/windows/desktop/ff476253) を設定して深度ステンシル バッファーを定義し、その後、[**ID3D11Device::CreateTexture2D**](https://msdn.microsoft.com/library/windows/desktop/ff476521) を呼び出して深度ステンシル バッファーを作成します。</span><span class="sxs-lookup"><span data-stu-id="24205-121">We populate a [**D3D11\_TEXTURE2D\_DESC**](https://msdn.microsoft.com/library/windows/desktop/ff476253) to describe the depth-stencil buffer and then call [**ID3D11Device::CreateTexture2D**](https://msdn.microsoft.com/library/windows/desktop/ff476521) to create the depth-stencil buffer.</span></span> <span data-ttu-id="24205-122">深度ステンシル ビューを作成するには、[**D3D11\_DEPTH\_STENCIL\_VIEW\_DESC**](https://msdn.microsoft.com/library/windows/desktop/ff476112) を設定して深度ステンシル ビューを定義し、その深度ステンシル ビューの定義と深度ステンシル バッファーを [**ID3D11Device::CreateDepthStencilView**](https://msdn.microsoft.com/library/windows/desktop/ff476507) に渡します。</span><span class="sxs-lookup"><span data-stu-id="24205-122">To create the depth-stencil view, we populate a [**D3D11\_DEPTH\_STENCIL\_VIEW\_DESC**](https://msdn.microsoft.com/library/windows/desktop/ff476112) to describe the depth-stencil view and pass the depth-stencil view description and the depth-stencil buffer to [**ID3D11Device::CreateDepthStencilView**](https://msdn.microsoft.com/library/windows/desktop/ff476507).</span></span>

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

### <a name="3-updating-perspective-with-the-window"></a><span data-ttu-id="24205-123">3. ウィンドウに基づく視点の更新</span><span class="sxs-lookup"><span data-stu-id="24205-123">3. Updating perspective with the window</span></span>

<span data-ttu-id="24205-124">ウィンドウのサイズに応じて定数バッファーの透視投影パラメーターを更新します。</span><span class="sxs-lookup"><span data-stu-id="24205-124">We update the perspective projection parameters for the constant buffer depending on the window dimensions.</span></span> <span data-ttu-id="24205-125">パラメーターは、視野が 70°、深度の範囲が 0.01 ～ 100 に修正されています。</span><span class="sxs-lookup"><span data-stu-id="24205-125">We fix the parameters to a 70-degree field of view with a depth range of 0.01 to 100.</span></span>

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

### <a name="4-creating-vertex-and-pixel-shaders-with-color-elements"></a><span data-ttu-id="24205-126">4. 色要素を使った頂点シェーダーとピクセル シェーダーの作成</span><span class="sxs-lookup"><span data-stu-id="24205-126">4. Creating vertex and pixel shaders with color elements</span></span>

<span data-ttu-id="24205-127">このアプリでは、前のチュートリアル (「[シェーダーの作成とプリミティブの描画](creating-shaders-and-drawing-primitives.md)」) で説明したものよりも複雑な頂点シェーダーとピクセル シェーダーを作成します。</span><span class="sxs-lookup"><span data-stu-id="24205-127">In this app, we create more complex vertex and pixel shaders than what we described in the previous tutorial, [Creating shaders and drawing primitives](creating-shaders-and-drawing-primitives.md).</span></span> <span data-ttu-id="24205-128">このアプリの頂点シェーダーは、個々の頂点の位置を投影空間に変換し、頂点の色をピクセル シェーダーに渡します。</span><span class="sxs-lookup"><span data-stu-id="24205-128">The app's vertex shader transforms each vertex position into projection space and passes the vertex color through to the pixel shader.</span></span>

<span data-ttu-id="24205-129">このアプリでは、[**D3D11\_INPUT\_ELEMENT\_DESC**](https://msdn.microsoft.com/library/windows/desktop/ff476180) 構造体の配列を使って頂点シェーダー コードのレイアウトを記述しています。このレイアウトには、2 つのレイアウト要素があります。頂点位置を定義する要素と、色を定義する要素です。</span><span class="sxs-lookup"><span data-stu-id="24205-129">The app's array of [**D3D11\_INPUT\_ELEMENT\_DESC**](https://msdn.microsoft.com/library/windows/desktop/ff476180) structures that describe the layout of the vertex shader code has two layout elements: one element defines the vertex position and the other element defines the color.</span></span>

<span data-ttu-id="24205-130">周回する立方体を定義する頂点バッファー、インデックス バッファー、定数バッファーを作成します。</span><span class="sxs-lookup"><span data-stu-id="24205-130">We create vertex, index, and constant buffers to define an orbiting cube.</span></span>

**<span data-ttu-id="24205-131">周回する立方体を定義するには</span><span class="sxs-lookup"><span data-stu-id="24205-131">To define an orbiting cube</span></span>**

1.  <span data-ttu-id="24205-132">まず立方体を定義します。</span><span class="sxs-lookup"><span data-stu-id="24205-132">First, we define the cube.</span></span> <span data-ttu-id="24205-133">それぞれの頂点に、位置に加えて色を割り当てます。</span><span class="sxs-lookup"><span data-stu-id="24205-133">We assign each vertex a color in addition to a position.</span></span> <span data-ttu-id="24205-134">これによってピクセル シェーダーが各表面に異なる色を適用できるようになり、表面が区別されます。</span><span class="sxs-lookup"><span data-stu-id="24205-134">This allows the pixel shader to color each face differently so the face can be distinguished.</span></span>
2.  <span data-ttu-id="24205-135">次に、立方体の定義を使い、頂点バッファーとインデックス バッファー ([**D3D11\_BUFFER\_DESC**](https://msdn.microsoft.com/library/windows/desktop/ff476092) と [**D3D11\_SUBRESOURCE\_DATA**](https://msdn.microsoft.com/library/windows/desktop/ff476220)) を記述します。</span><span class="sxs-lookup"><span data-stu-id="24205-135">Next, we describe the vertex and index buffers ([**D3D11\_BUFFER\_DESC**](https://msdn.microsoft.com/library/windows/desktop/ff476092) and [**D3D11\_SUBRESOURCE\_DATA**](https://msdn.microsoft.com/library/windows/desktop/ff476220)) using the cube definition.</span></span> <span data-ttu-id="24205-136">各バッファーについて、[**ID3D11Device::CreateBuffer**](https://msdn.microsoft.com/library/windows/desktop/ff476501) を 1 回呼び出します。</span><span class="sxs-lookup"><span data-stu-id="24205-136">We call [**ID3D11Device::CreateBuffer**](https://msdn.microsoft.com/library/windows/desktop/ff476501) once for each buffer.</span></span>
3.  <span data-ttu-id="24205-137">次に、モデル マトリックス、ビュー マトリックス、プロジェクション マトリックスを頂点シェーダーに渡すための定数バッファー ([**D3D11\_BUFFER\_DESC**](https://msdn.microsoft.com/library/windows/desktop/ff476092)) を作成します。</span><span class="sxs-lookup"><span data-stu-id="24205-137">Next, we create a constant buffer ([**D3D11\_BUFFER\_DESC**](https://msdn.microsoft.com/library/windows/desktop/ff476092)) for passing model, view, and projection matrices to the vertex shader.</span></span> <span data-ttu-id="24205-138">後でこの定数バッファーを使って、立方体を回転させたり、そこに透視投影を適用したりすることができます。</span><span class="sxs-lookup"><span data-stu-id="24205-138">We can later use the constant buffer to rotate the cube and apply a perspective projection to it.</span></span> <span data-ttu-id="24205-139">定数バッファーを作成するには、[**ID3D11Device::CreateBuffer**](https://msdn.microsoft.com/library/windows/desktop/ff476501) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="24205-139">We call [**ID3D11Device::CreateBuffer**](https://msdn.microsoft.com/library/windows/desktop/ff476501) to create the constant buffer.</span></span>
4.  <span data-ttu-id="24205-140">次に、カメラ位置 (X = 0、Y = 1、Z = 2) に対応するビュー変換を指定します。</span><span class="sxs-lookup"><span data-stu-id="24205-140">Next, we specify the view transform that corresponds to a camera position of X = 0, Y = 1, Z = 2.</span></span>
5.  <span data-ttu-id="24205-141">最後に、*degree* 変数を宣言します。これは、立方体をフレームごとに回転させてアニメーション化する目的で使います。</span><span class="sxs-lookup"><span data-stu-id="24205-141">Finally, we declare a *degree* variable that we will use to animate the cube by rotating it every frame.</span></span>

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

### <a name="5-rotating-and-drawing-the-cube-and-presenting-the-rendered-image"></a><span data-ttu-id="24205-142">5. 立方体の回転と描画およびレンダリングされた画像の表示</span><span class="sxs-lookup"><span data-stu-id="24205-142">5. Rotating and drawing the cube and presenting the rendered image</span></span>

<span data-ttu-id="24205-143">シーンをレンダリングして表示し続けるために、無限ループを使います。</span><span class="sxs-lookup"><span data-stu-id="24205-143">We enter an endless loop to continually render and display the scene.</span></span> <span data-ttu-id="24205-144">立方体のモデル マトリックスを Y 軸を中心に回転させるための値を設定するため、**rotationY** インライン関数 (BasicMath.h) に回転量を指定して呼び出します。</span><span class="sxs-lookup"><span data-stu-id="24205-144">We call the **rotationY** inline function (BasicMath.h) with a rotation amount to set values that will rotate the cube’s model matrix around the Y axis.</span></span> <span data-ttu-id="24205-145">さらに、[**ID3D11DeviceContext::UpdateSubresource**](https://msdn.microsoft.com/library/windows/desktop/ff476486) を呼び出して定数バッファーを更新し、立方体モデルを回転させます。</span><span class="sxs-lookup"><span data-stu-id="24205-145">We then call [**ID3D11DeviceContext::UpdateSubresource**](https://msdn.microsoft.com/library/windows/desktop/ff476486) to update the constant buffer and rotate the cube model.</span></span> <span data-ttu-id="24205-146">[**ID3D11DeviceContext::OMSetRenderTargets**](https://msdn.microsoft.com/library/windows/desktop/ff476464) を呼び出して、レンダー ターゲットを出力ターゲットとして指定します。</span><span class="sxs-lookup"><span data-stu-id="24205-146">We call [**ID3D11DeviceContext::OMSetRenderTargets**](https://msdn.microsoft.com/library/windows/desktop/ff476464) to specify the render target as the output target.</span></span> <span data-ttu-id="24205-147">この **OMSetRenderTargets** 呼び出しでは、深度ステンシル ビューを渡します。</span><span class="sxs-lookup"><span data-stu-id="24205-147">In this **OMSetRenderTargets** call, we pass the depth-stencil view.</span></span> <span data-ttu-id="24205-148">[**ID3D11DeviceContext::ClearRenderTargetView**](https://msdn.microsoft.com/library/windows/desktop/ff476388) を呼び出してレンダー ターゲットを無地の青色にクリアし、[**ID3D11DeviceContext::ClearDepthStencilView**](https://msdn.microsoft.com/library/windows/desktop/ff476387) を呼び出して深度バッファーをクリアします。</span><span class="sxs-lookup"><span data-stu-id="24205-148">We call [**ID3D11DeviceContext::ClearRenderTargetView**](https://msdn.microsoft.com/library/windows/desktop/ff476388) to clear the render target to a solid blue color and call [**ID3D11DeviceContext::ClearDepthStencilView**](https://msdn.microsoft.com/library/windows/desktop/ff476387) to clear the depth buffer.</span></span>

<span data-ttu-id="24205-149">無限ループで、立方体を青色のサーフェス上に描画します。</span><span class="sxs-lookup"><span data-stu-id="24205-149">In the endless loop, we also draw the cube on the blue surface.</span></span>

**<span data-ttu-id="24205-150">立方体を描画するには</span><span class="sxs-lookup"><span data-stu-id="24205-150">To draw the cube</span></span>**

1.  <span data-ttu-id="24205-151">まず、頂点バッファーから入力アセンブラー ステージへのデータの流れを定義するために、[**ID3D11DeviceContext::IASetInputLayout**](https://msdn.microsoft.com/library/windows/desktop/ff476454) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="24205-151">First, we call [**ID3D11DeviceContext::IASetInputLayout**](https://msdn.microsoft.com/library/windows/desktop/ff476454) to describe how vertex buffer data is streamed into the input-assembler stage.</span></span>
2.  <span data-ttu-id="24205-152">次に、[**ID3D11DeviceContext::IASetVertexBuffers**](https://msdn.microsoft.com/library/windows/desktop/ff476456) と [**ID3D11DeviceContext::IASetIndexBuffer**](https://msdn.microsoft.com/library/windows/desktop/ff476453) を呼び出して、頂点バッファーとインデックス バッファーを入力アセンブラー ステージにバインドします。</span><span class="sxs-lookup"><span data-stu-id="24205-152">Next, we call [**ID3D11DeviceContext::IASetVertexBuffers**](https://msdn.microsoft.com/library/windows/desktop/ff476456) and [**ID3D11DeviceContext::IASetIndexBuffer**](https://msdn.microsoft.com/library/windows/desktop/ff476453) to bind the vertex and index buffers to the input-assembler stage.</span></span>
3.  <span data-ttu-id="24205-153">次に、[**ID3D11DeviceContext::IASetPrimitiveTopology**](https://msdn.microsoft.com/library/windows/desktop/ff476455) の呼び出しで [**D3D11\_PRIMITIVE\_TOPOLOGY\_TRIANGLESTRIP**](https://msdn.microsoft.com/library/windows/desktop/ff476189#D3D11_PRIMITIVE_TOPOLOGY_TRIANGLESTRIP) 値を渡し、頂点データを三角形ストリップとして解釈するよう入力アセンブラー ステージに指定します。</span><span class="sxs-lookup"><span data-stu-id="24205-153">Next, we call [**ID3D11DeviceContext::IASetPrimitiveTopology**](https://msdn.microsoft.com/library/windows/desktop/ff476455) with the [**D3D11\_PRIMITIVE\_TOPOLOGY\_TRIANGLESTRIP**](https://msdn.microsoft.com/library/windows/desktop/ff476189#D3D11_PRIMITIVE_TOPOLOGY_TRIANGLESTRIP) value to specify for the input-assembler stage to interpret the vertex data as a triangle strip.</span></span>
4.  <span data-ttu-id="24205-154">次に、[**ID3D11DeviceContext::VSSetShader**](https://msdn.microsoft.com/library/windows/desktop/ff476493) を呼び出して頂点シェーダー ステージを頂点シェーダー コードで初期化し、さらに、[**ID3D11DeviceContext::PSSetShader**](https://msdn.microsoft.com/library/windows/desktop/ff476472) を呼び出してピクセル シェーダー ステージをピクセル シェーダー コードで初期化します。</span><span class="sxs-lookup"><span data-stu-id="24205-154">Next, we call [**ID3D11DeviceContext::VSSetShader**](https://msdn.microsoft.com/library/windows/desktop/ff476493) to initialize the vertex shader stage with the vertex shader code and [**ID3D11DeviceContext::PSSetShader**](https://msdn.microsoft.com/library/windows/desktop/ff476472) to initialize the pixel shader stage with the pixel shader code.</span></span>
5.  <span data-ttu-id="24205-155">次に、[**ID3D11DeviceContext::VSSetConstantBuffers**](https://msdn.microsoft.com/library/windows/desktop/ff476491) を呼び出し、頂点シェーダーのパイプライン ステージで使われる定数バッファーを設定します。</span><span class="sxs-lookup"><span data-stu-id="24205-155">Next, we call [**ID3D11DeviceContext::VSSetConstantBuffers**](https://msdn.microsoft.com/library/windows/desktop/ff476491) to set the constant buffer that is used by the vertex shader pipeline stage.</span></span>
6.  <span data-ttu-id="24205-156">最後に、[**ID3D11DeviceContext::DrawIndexed**](https://msdn.microsoft.com/library/windows/desktop/ff476409) を呼び出して立方体を描画し、レンダリング パイプラインに送ります。</span><span class="sxs-lookup"><span data-stu-id="24205-156">Finally, we call [**ID3D11DeviceContext::DrawIndexed**](https://msdn.microsoft.com/library/windows/desktop/ff476409) to draw the cube and submit it to the rendering pipeline.</span></span>

<span data-ttu-id="24205-157">レンダリングされた画像をウィンドウに表示するために、[**IDXGISwapChain::Present**](https://msdn.microsoft.com/library/windows/desktop/bb174576) を呼び出しています。</span><span class="sxs-lookup"><span data-stu-id="24205-157">We call [**IDXGISwapChain::Present**](https://msdn.microsoft.com/library/windows/desktop/bb174576) to present the rendered image to the window.</span></span>

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

## <a name="summary-and-next-steps"></a><span data-ttu-id="24205-158">要約と次のステップ</span><span class="sxs-lookup"><span data-stu-id="24205-158">Summary and next steps</span></span>


<span data-ttu-id="24205-159">深度、視点、色、その他の効果をプリミティブに対して使いました。</span><span class="sxs-lookup"><span data-stu-id="24205-159">We used depth, perspective, color, and other effects on primitives.</span></span>

<span data-ttu-id="24205-160">次は、プリミティブにテクスチャを適用します。</span><span class="sxs-lookup"><span data-stu-id="24205-160">Next, we apply textures to primitives.</span></span>

[<span data-ttu-id="24205-161">プリミティブへのテクスチャの適用</span><span class="sxs-lookup"><span data-stu-id="24205-161">Applying textures to primitives</span></span>](applying-textures-to-primitives.md)

 

 




