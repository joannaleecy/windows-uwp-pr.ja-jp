---
title: プリミティブへのテクスチャの適用
description: ここでは、生のテクスチャ データを読み込み、そのデータを、「プリミティブに対する深度と各種効果の使用」で作成した立方体を使って 3D プリミティブに適用します。
ms.assetid: aeed09e3-c47a-4dd9-d0e8-d1b8bdd7e9b4
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10、UWP、ゲーム、テクスチャ、DirectX
ms.localizationpriority: medium
ms.openlocfilehash: a857f62839841a2e20c4f6b6cf753e9d85dcb32c
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57601657"
---
# <a name="apply-textures-to-primitives"></a><span data-ttu-id="814d2-104">プリミティブへのテクスチャの適用</span><span class="sxs-lookup"><span data-stu-id="814d2-104">Apply textures to primitives</span></span>

<span data-ttu-id="814d2-105">ここでは、生のテクスチャ データを読み込み、そのデータを、「[プリミティブに対する深度と各種効果の使用](using-depth-and-effects-on-primitives.md)」で作成した立方体を使って 3D プリミティブに適用します。</span><span class="sxs-lookup"><span data-stu-id="814d2-105">Here, we load raw texture data and apply that data to a 3D primitive by using the cube that we created in [Using depth and effects on primitives](using-depth-and-effects-on-primitives.md).</span></span> <span data-ttu-id="814d2-106">また、光源との距離や角度に応じて立方体のサーフェスの明暗の度合いが変化する単純なドット積の照明モデルを紹介します。</span><span class="sxs-lookup"><span data-stu-id="814d2-106">We also introduce a simple dot-product lighting model, where the cube surfaces are lighter or darker based on their distance and angle relative to a light source.</span></span>

<span data-ttu-id="814d2-107">**目標:** プリミティブにテクスチャを適用します。</span><span class="sxs-lookup"><span data-stu-id="814d2-107">**Objective:** To apply textures to primitives.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="814d2-108">前提条件</span><span class="sxs-lookup"><span data-stu-id="814d2-108">Prerequisites</span></span>

<span data-ttu-id="814d2-109">このトピックを最大限に活用を取得するには、C++ に慣れておく必要があります。</span><span class="sxs-lookup"><span data-stu-id="814d2-109">To get the most out of this topic, you'll need to be familiar with C++.</span></span> <span data-ttu-id="814d2-110">グラフィックス プログラミングの概念と基本的な経験も必要になります。</span><span class="sxs-lookup"><span data-stu-id="814d2-110">You'll also need basic experience with graphics programming concepts.</span></span> <span data-ttu-id="814d2-111">理想的には、既にと共に実行する必要があり、[クイック スタート: DirectX リソースを設定し、イメージを表示する](setting-up-directx-resources.md)、[シェーダーを作成して、プリミティブを描画](creating-shaders-and-drawing-primitives.md)、および[を使用します。深さとプリミティブに対する影響](using-depth-and-effects-on-primitives.md)します。</span><span class="sxs-lookup"><span data-stu-id="814d2-111">And, ideally, you'll need to have already followed along with [Quickstart: setting up DirectX resources and displaying an image](setting-up-directx-resources.md), [Creating shaders and drawing primitives](creating-shaders-and-drawing-primitives.md), and [Using depth and effects on primitives](using-depth-and-effects-on-primitives.md).</span></span>

<span data-ttu-id="814d2-112">**所要時間:** 20 分です。</span><span class="sxs-lookup"><span data-stu-id="814d2-112">**Time to complete:** 20 minutes.</span></span>

<a name="instructions"></a><span data-ttu-id="814d2-113">手順</span><span class="sxs-lookup"><span data-stu-id="814d2-113">Instructions</span></span>
------------
### <a name="1-defining-variables-for-a-textured-cube"></a><span data-ttu-id="814d2-114">1. テクスチャ キューブの変数を定義します。</span><span class="sxs-lookup"><span data-stu-id="814d2-114">1. Defining variables for a textured cube</span></span>

<span data-ttu-id="814d2-115">まず、テクスチャの適用対象となる立方体の **BasicVertex** 構造体と **ConstantBuffer** 構造体を定義する必要があります。</span><span class="sxs-lookup"><span data-stu-id="814d2-115">First, we need to define the **BasicVertex** and **ConstantBuffer** structures for the textured cube.</span></span> <span data-ttu-id="814d2-116">立方体の頂点の位置、方向、テクスチャに加え、その見え方が、これらの構造体によって指定されます。</span><span class="sxs-lookup"><span data-stu-id="814d2-116">These structures specify the vertex positions, orientations, and textures for the cube and how the cube will be viewed.</span></span> <span data-ttu-id="814d2-117">それ以外は、前のチュートリアル (「[プリミティブに対する深度と各種効果の使用](using-depth-and-effects-on-primitives.md)」) と同様の変数を宣言します。</span><span class="sxs-lookup"><span data-stu-id="814d2-117">Otherwise, we declare variables similarly to the previous tutorial, [Using depth and effects on primitives](using-depth-and-effects-on-primitives.md).</span></span>

```cppcx
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

### <a name="2-creating-vertex-and-pixel-shaders-with-surface-and-texture-elements"></a><span data-ttu-id="814d2-118">2. 画面とテクスチャの要素を持つ頂点とピクセル シェーダーを作成します。</span><span class="sxs-lookup"><span data-stu-id="814d2-118">2. Creating vertex and pixel shaders with surface and texture elements</span></span>

<span data-ttu-id="814d2-119">ここでは、前のチュートリアル (「[プリミティブに対する深度と各種効果の使用](using-depth-and-effects-on-primitives.md)」) で作成したものよりも複雑な頂点シェーダーとピクセル シェーダーを作成します。</span><span class="sxs-lookup"><span data-stu-id="814d2-119">Here, we create more complex vertex and pixel shaders than in the previous tutorial, [Using depth and effects on primitives](using-depth-and-effects-on-primitives.md).</span></span> <span data-ttu-id="814d2-120">このアプリの頂点シェーダーは、個々の頂点の位置を投影空間に変換し、頂点のテクスチャ座標をピクセル シェーダーに渡します。</span><span class="sxs-lookup"><span data-stu-id="814d2-120">This app's vertex shader transforms each vertex position into projection space and passes the vertex texture coordinate through to the pixel shader.</span></span>

<span data-ttu-id="814d2-121">アプリの配列の[ **D3D11\_入力\_要素\_DESC** ](https://msdn.microsoft.com/library/windows/desktop/ff476180)頂点シェーダー コードのレイアウトを記述する構造体が 3 つのレイアウト要素: 1 つの要素頂点の位置を定義します。 別の要素は、面法線ベクトル (通常、画面に面している方向) を定義し、3 番目の要素は、テクスチャ座標を定義します。</span><span class="sxs-lookup"><span data-stu-id="814d2-121">The app's array of [**D3D11\_INPUT\_ELEMENT\_DESC**](https://msdn.microsoft.com/library/windows/desktop/ff476180) structures that describe the layout of the vertex shader code has three layout elements: one element defines the vertex position, another element defines the surface normal vector (the direction that the surface normally faces), and the third element defines the texture coordinates.</span></span>

<span data-ttu-id="814d2-122">テクスチャを適用した周回する立方体を定義する頂点バッファー、インデックス バッファー、定数バッファーを作成します。</span><span class="sxs-lookup"><span data-stu-id="814d2-122">We create vertex, index, and constant buffers that define an orbiting textured cube.</span></span>

<span data-ttu-id="814d2-123">**周回テクスチャ キューブを定義するには**</span><span class="sxs-lookup"><span data-stu-id="814d2-123">**To define an orbiting textured cube**</span></span>

1.  <span data-ttu-id="814d2-124">まず立方体を定義します。</span><span class="sxs-lookup"><span data-stu-id="814d2-124">First, we define the cube.</span></span> <span data-ttu-id="814d2-125">それぞれの頂点には、位置、サーフェスの標準ベクター、テクスチャの座標が割り当てられます。</span><span class="sxs-lookup"><span data-stu-id="814d2-125">Each vertex is assigned a position, a surface normal vector, and texture coordinates.</span></span> <span data-ttu-id="814d2-126">面ごとに異なる標準ベクターとテクスチャ座標を定義できるよう、各コーナーには複数の頂点を使います。</span><span class="sxs-lookup"><span data-stu-id="814d2-126">We use multiple vertices for each corner to allow different normal vectors and texture coordinates to be defined for each face.</span></span>
2.  <span data-ttu-id="814d2-127">次に、頂点とインデックス バッファーについて説明します ([**D3D11\_バッファー\_DESC** ](https://msdn.microsoft.com/library/windows/desktop/ff476092)と[ **D3D11\_SUBRESOURCE\_データ**](https://msdn.microsoft.com/library/windows/desktop/ff476220)) キューブの定義を使用します。</span><span class="sxs-lookup"><span data-stu-id="814d2-127">Next, we describe the vertex and index buffers ([**D3D11\_BUFFER\_DESC**](https://msdn.microsoft.com/library/windows/desktop/ff476092) and [**D3D11\_SUBRESOURCE\_DATA**](https://msdn.microsoft.com/library/windows/desktop/ff476220)) using the cube definition.</span></span> <span data-ttu-id="814d2-128">各バッファーについて、[**ID3D11Device::CreateBuffer**](https://msdn.microsoft.com/library/windows/desktop/ff476501) を 1 回呼び出します。</span><span class="sxs-lookup"><span data-stu-id="814d2-128">We call [**ID3D11Device::CreateBuffer**](https://msdn.microsoft.com/library/windows/desktop/ff476501) once for each buffer.</span></span>
3.  <span data-ttu-id="814d2-129">次に、定数バッファーを作成します ([**D3D11\_バッファー\_DESC**](https://msdn.microsoft.com/library/windows/desktop/ff476092)) モデル、ビュー、および投影マトリックスを頂点シェーダーに渡すことです。</span><span class="sxs-lookup"><span data-stu-id="814d2-129">Next, we create a constant buffer ([**D3D11\_BUFFER\_DESC**](https://msdn.microsoft.com/library/windows/desktop/ff476092)) for passing model, view, and projection matrices to the vertex shader.</span></span> <span data-ttu-id="814d2-130">後でこの定数バッファーを使って、立方体を回転させたり、そこに透視投影を適用したりすることができます。</span><span class="sxs-lookup"><span data-stu-id="814d2-130">We can later use the constant buffer to rotate the cube and apply a perspective projection to it.</span></span> <span data-ttu-id="814d2-131">定数バッファーを作成するには、[**ID3D11Device::CreateBuffer**](https://msdn.microsoft.com/library/windows/desktop/ff476501) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="814d2-131">We call [**ID3D11Device::CreateBuffer**](https://msdn.microsoft.com/library/windows/desktop/ff476501) to create the constant buffer.</span></span>
4.  <span data-ttu-id="814d2-132">最後に、カメラ位置 (X = 0、Y = 1、Z = 2) に対応するビュー変換を指定します。</span><span class="sxs-lookup"><span data-stu-id="814d2-132">Finally, we specify the view transform that corresponds to a camera position of X = 0, Y = 1, Z = 2.</span></span>

```cppcx
auto loadVSTask = DX::ReadDataAsync(L"SimpleVertexShader.cso");
auto loadPSTask = DX::ReadDataAsync(L"SimplePixelShader.cso");

auto createVSTask = loadVSTask.then([this](const std::vector<byte>& vertexShaderBytecode)
{
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
auto createPSTask = loadPSTask.then([this](const std::vector<byte>& pixelShaderBytecode)
{
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
auto createCubeTask = (createPSTask && createVSTask).then([this]()
{
    // In the array below, which will be used to initialize the cube vertex buffers,
    // multiple vertices are used for each corner to allow different normal vectors and
    // texture coordinates to be defined for each face.
    BasicVertex cubeVertices[] =
    {
        { DirectX::XMFLOAT3(-0.5f, 0.5f, -0.5f), DirectX::XMFLOAT3(0.0f, 1.0f, 0.0f), DirectX::XMFLOAT2(0.0f, 0.0f) }, // +Y (top face)
        { DirectX::XMFLOAT3(0.5f, 0.5f, -0.5f), DirectX::XMFLOAT3(0.0f, 1.0f, 0.0f), DirectX::XMFLOAT2(1.0f, 0.0f) },
        { DirectX::XMFLOAT3(0.5f, 0.5f,  0.5f), DirectX::XMFLOAT3(0.0f, 1.0f, 0.0f), DirectX::XMFLOAT2(1.0f, 1.0f) },
        { DirectX::XMFLOAT3(-0.5f, 0.5f,  0.5f), DirectX::XMFLOAT3(0.0f, 1.0f, 0.0f), DirectX::XMFLOAT2(0.0f, 1.0f) },

        { DirectX::XMFLOAT3(-0.5f, -0.5f,  0.5f), DirectX::XMFLOAT3(0.0f, -1.0f, 0.0f), DirectX::XMFLOAT2(0.0f, 0.0f) }, // -Y (bottom face)
        { DirectX::XMFLOAT3(0.5f, -0.5f,  0.5f), DirectX::XMFLOAT3(0.0f, -1.0f, 0.0f), DirectX::XMFLOAT2(1.0f, 0.0f) },
        { DirectX::XMFLOAT3(0.5f, -0.5f, -0.5f), DirectX::XMFLOAT3(0.0f, -1.0f, 0.0f), DirectX::XMFLOAT2(1.0f, 1.0f) },
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
        { DirectX::XMFLOAT3(0.5f,  0.5f, 0.5f), DirectX::XMFLOAT3(0.0f, 0.0f, 1.0f), DirectX::XMFLOAT2(1.0f, 0.0f) },
        { DirectX::XMFLOAT3(0.5f, -0.5f, 0.5f), DirectX::XMFLOAT3(0.0f, 0.0f, 1.0f), DirectX::XMFLOAT2(1.0f, 1.0f) },
        { DirectX::XMFLOAT3(-0.5f, -0.5f, 0.5f), DirectX::XMFLOAT3(0.0f, 0.0f, 1.0f), DirectX::XMFLOAT2(0.0f, 1.0f) },

        { DirectX::XMFLOAT3(0.5f,  0.5f, -0.5f), DirectX::XMFLOAT3(0.0f, 0.0f, -1.0f), DirectX::XMFLOAT2(0.0f, 0.0f) }, // -Z (back face)
        { DirectX::XMFLOAT3(-0.5f,  0.5f, -0.5f), DirectX::XMFLOAT3(0.0f, 0.0f, -1.0f), DirectX::XMFLOAT2(1.0f, 0.0f) },
        { DirectX::XMFLOAT3(-0.5f, -0.5f, -0.5f), DirectX::XMFLOAT3(0.0f, 0.0f, -1.0f), DirectX::XMFLOAT2(1.0f, 1.0f) },
        { DirectX::XMFLOAT3(0.5f, -0.5f, -0.5f), DirectX::XMFLOAT3(0.0f, 0.0f, -1.0f), DirectX::XMFLOAT2(0.0f, 1.0f) },
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

    D3D11_BUFFER_DESC vertexBufferDesc = { 0 };
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

    D3D11_BUFFER_DESC constantBufferDesc = { 0 };
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
        -1.00000000f, 0.00000000f, 0.00000000f, 0.00000000f,
        0.00000000f, 0.89442718f, 0.44721359f, 0.00000000f,
        0.00000000f, 0.44721359f, -0.89442718f, -2.23606800f,
        0.00000000f, 0.00000000f, 0.00000000f, 1.00000000f
    );
});
```

### <a name="3-creating-textures-and-samplers"></a><span data-ttu-id="814d2-133">3.テクスチャ サンプラーを作成します。</span><span class="sxs-lookup"><span data-stu-id="814d2-133">3. Creating textures and samplers</span></span>

<span data-ttu-id="814d2-134">ここでは、前のチュートリアル (「[プリミティブに対する深度と各種効果の使用](using-depth-and-effects-on-primitives.md)」) のように色を適用するのではなく、テクスチャ データを立方体に適用します。</span><span class="sxs-lookup"><span data-stu-id="814d2-134">Here, we apply texture data to a cube rather than applying colors as in the previous tutorial, [Using depth and effects on primitives](using-depth-and-effects-on-primitives.md).</span></span>

<span data-ttu-id="814d2-135">生のテクスチャ データを使ってテクスチャを作成します。</span><span class="sxs-lookup"><span data-stu-id="814d2-135">We use raw texture data to create textures.</span></span>

<span data-ttu-id="814d2-136">**テクスチャおよびサンプラーを作成するには**</span><span class="sxs-lookup"><span data-stu-id="814d2-136">**To create textures and samplers**</span></span>

1.  <span data-ttu-id="814d2-137">まず、ディスク上の texturedata.bin ファイルから生のテクスチャ データを読み取ります。</span><span class="sxs-lookup"><span data-stu-id="814d2-137">First, we read raw texture data from the texturedata.bin file on disk.</span></span>
2.  <span data-ttu-id="814d2-138">次に、作成、 [ **D3D11\_SUBRESOURCE\_データ**](https://msdn.microsoft.com/library/windows/desktop/ff476220)そのテクスチャの生データを参照する構造体。</span><span class="sxs-lookup"><span data-stu-id="814d2-138">Next, we construct a [**D3D11\_SUBRESOURCE\_DATA**](https://msdn.microsoft.com/library/windows/desktop/ff476220) structure that references that raw texture data.</span></span>
3.  <span data-ttu-id="814d2-139">次を設定します、 [ **D3D11\_TEXTURE2D\_DESC** ](https://msdn.microsoft.com/library/windows/desktop/ff476253)テクスチャを記述する構造体。</span><span class="sxs-lookup"><span data-stu-id="814d2-139">Then, we populate a [**D3D11\_TEXTURE2D\_DESC**](https://msdn.microsoft.com/library/windows/desktop/ff476253) structure to describe the texture.</span></span> <span data-ttu-id="814d2-140">渡して、 [ **D3D11\_SUBRESOURCE\_データ**](https://msdn.microsoft.com/library/windows/desktop/ff476220)と**D3D11\_TEXTURE2D\_DESC**内の構造体、呼び出す[ **ID3D11Device::CreateTexture2D** ](https://msdn.microsoft.com/library/windows/desktop/ff476521)テクスチャを作成します。</span><span class="sxs-lookup"><span data-stu-id="814d2-140">We then pass the [**D3D11\_SUBRESOURCE\_DATA**](https://msdn.microsoft.com/library/windows/desktop/ff476220) and **D3D11\_TEXTURE2D\_DESC** structures in a call to [**ID3D11Device::CreateTexture2D**](https://msdn.microsoft.com/library/windows/desktop/ff476521) to create the texture.</span></span>
4.  <span data-ttu-id="814d2-141">次に、テクスチャのシェーダー リソース ビューを作成して、シェーダーからテクスチャを利用できるようにします。</span><span class="sxs-lookup"><span data-stu-id="814d2-141">Next, we create a shader-resource view of the texture so shaders can use the texture.</span></span> <span data-ttu-id="814d2-142">設定しますシェーダー リソース ビューを作成する、 [ **D3D11\_シェーダー\_リソース\_ビュー\_DESC** ](https://msdn.microsoft.com/library/windows/desktop/ff476211)シェーダー リソース ビューを記述してシェーダー リソース ビューの説明とテクスチャを渡す[ **ID3D11Device::CreateShaderResourceView**](https://msdn.microsoft.com/library/windows/desktop/ff476519)します。</span><span class="sxs-lookup"><span data-stu-id="814d2-142">To create the shader-resource view, we populate a [**D3D11\_SHADER\_RESOURCE\_VIEW\_DESC**](https://msdn.microsoft.com/library/windows/desktop/ff476211) to describe the shader-resource view and pass the shader-resource view description and the texture to [**ID3D11Device::CreateShaderResourceView**](https://msdn.microsoft.com/library/windows/desktop/ff476519).</span></span> <span data-ttu-id="814d2-143">一般に、ビューの情報とテクスチャの情報は一致させる必要があります。</span><span class="sxs-lookup"><span data-stu-id="814d2-143">In general, you match the view description with the texture description.</span></span>
5.  <span data-ttu-id="814d2-144">次に、テクスチャのサンプラー ステートを作成します。</span><span class="sxs-lookup"><span data-stu-id="814d2-144">Next, we create sampler state for the texture.</span></span> <span data-ttu-id="814d2-145">このサンプラー ステートは、特定のテクスチャ座標の色の決定方法を、関連するテクスチャ データを使って定義します。</span><span class="sxs-lookup"><span data-stu-id="814d2-145">This sampler state uses the relevant texture data to define how the color for a particular texture coordinate is determined.</span></span> <span data-ttu-id="814d2-146">設定します、 [ **D3D11\_サンプラー\_DESC** ](https://msdn.microsoft.com/library/windows/desktop/ff476207)サンプラーの状態を記述する構造体。</span><span class="sxs-lookup"><span data-stu-id="814d2-146">We populate a [**D3D11\_SAMPLER\_DESC**](https://msdn.microsoft.com/library/windows/desktop/ff476207) structure to describe the sampler state.</span></span> <span data-ttu-id="814d2-147">渡して、 **D3D11\_サンプラー\_DESC**構造体への呼び出しで[ **ID3D11Device::CreateSamplerState** ](https://msdn.microsoft.com/library/windows/desktop/ff476518)サンプラーの状態を作成します。</span><span class="sxs-lookup"><span data-stu-id="814d2-147">We then pass the **D3D11\_SAMPLER\_DESC** structure in a call to [**ID3D11Device::CreateSamplerState**](https://msdn.microsoft.com/library/windows/desktop/ff476518) to create the sampler state.</span></span>
6.  <span data-ttu-id="814d2-148">最後に、*degree* 変数を宣言します。これは、立方体をフレームごとに回転させてアニメーション化する目的で使います。</span><span class="sxs-lookup"><span data-stu-id="814d2-148">Finally, we declare a *degree* variable that we will use to animate the cube by rotating it every frame.</span></span>

```cppcx
// Load the raw texture data from disk and construct a subresource description that references it.
auto loadTDTask = DX::ReadDataAsync(L"texturedata.bin");

auto constructSubresourceTask = loadTDTask.then([this](const std::vector<byte>& textureData)
{
    D3D11_SUBRESOURCE_DATA textureSubresourceData = { 0 };
    textureSubresourceData.pSysMem = textureData.data();

    // Specify the size of a row in bytes, known as a priori about the texture data.
    textureSubresourceData.SysMemPitch = 1024;

    // As this is not a texture array or 3D texture, this parameter is ignored.
    textureSubresourceData.SysMemSlicePitch = 0;

    // Create a texture description from information known as a priori about the data.
    // Generalized texture loading code can be found in the Resource Loading sample.
    D3D11_TEXTURE2D_DESC textureDesc = { 0 };
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

### <a name="4-rotating-and-drawing-the-textured-cube-and-presenting-the-rendered-image"></a><span data-ttu-id="814d2-149">4。回転し、テクスチャ キューブの描画およびレンダリングされたイメージを提供</span><span class="sxs-lookup"><span data-stu-id="814d2-149">4. Rotating and drawing the textured cube and presenting the rendered image</span></span>

<span data-ttu-id="814d2-150">前のチュートリアルと同様、シーンをレンダリングして表示し続けるために無限ループを使います。</span><span class="sxs-lookup"><span data-stu-id="814d2-150">As in the previous tutorials, we enter an endless loop to continually render and display the scene.</span></span> <span data-ttu-id="814d2-151">立方体のモデル マトリックスを Y 軸を中心に回転させるための値を設定するため、**rotationY** インライン関数 (BasicMath.h) に回転量を指定して呼び出します。</span><span class="sxs-lookup"><span data-stu-id="814d2-151">We call the **rotationY** inline function (BasicMath.h) with a rotation amount to set values that will rotate the cube’s model matrix around the Y axis.</span></span> <span data-ttu-id="814d2-152">さらに、[**ID3D11DeviceContext::UpdateSubresource**](https://msdn.microsoft.com/library/windows/desktop/ff476486) を呼び出して定数バッファーを更新し、立方体モデルを回転させます。</span><span class="sxs-lookup"><span data-stu-id="814d2-152">We then call [**ID3D11DeviceContext::UpdateSubresource**](https://msdn.microsoft.com/library/windows/desktop/ff476486) to update the constant buffer and rotate the cube model.</span></span> <span data-ttu-id="814d2-153">次に、[**ID3D11DeviceContext::OMSetRenderTargets**](https://msdn.microsoft.com/library/windows/desktop/ff476464) を呼び出して、レンダー ターゲットと深度ステンシル ビューを指定します。</span><span class="sxs-lookup"><span data-stu-id="814d2-153">Next, we call [**ID3D11DeviceContext::OMSetRenderTargets**](https://msdn.microsoft.com/library/windows/desktop/ff476464) to specify the render target and the depth-stencil view.</span></span> <span data-ttu-id="814d2-154">[  **ID3D11DeviceContext::ClearRenderTargetView**](https://msdn.microsoft.com/library/windows/desktop/ff476388) を呼び出してレンダー ターゲットを無地の青色にクリアし、[**ID3D11DeviceContext::ClearDepthStencilView**](https://msdn.microsoft.com/library/windows/desktop/ff476387) を呼び出して深度バッファーをクリアします。</span><span class="sxs-lookup"><span data-stu-id="814d2-154">We call [**ID3D11DeviceContext::ClearRenderTargetView**](https://msdn.microsoft.com/library/windows/desktop/ff476388) to clear the render target to a solid blue color and call [**ID3D11DeviceContext::ClearDepthStencilView**](https://msdn.microsoft.com/library/windows/desktop/ff476387) to clear the depth buffer.</span></span>

<span data-ttu-id="814d2-155">無限ループで、テクスチャを適用した立方体を青色のサーフェス上に描画します。</span><span class="sxs-lookup"><span data-stu-id="814d2-155">In the endless loop, we also draw the textured cube on the blue surface.</span></span>

<span data-ttu-id="814d2-156">**テクスチャ キューブを描画するには**</span><span class="sxs-lookup"><span data-stu-id="814d2-156">**To draw the textured cube**</span></span>

1.  <span data-ttu-id="814d2-157">まず、頂点バッファーから入力アセンブラー ステージへのデータの流れを定義するために、[**ID3D11DeviceContext::IASetInputLayout**](https://msdn.microsoft.com/library/windows/desktop/ff476454) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="814d2-157">First, we call [**ID3D11DeviceContext::IASetInputLayout**](https://msdn.microsoft.com/library/windows/desktop/ff476454) to describe how vertex buffer data is streamed into the input-assembler stage.</span></span>
2.  <span data-ttu-id="814d2-158">次に、[**ID3D11DeviceContext::IASetVertexBuffers**](https://msdn.microsoft.com/library/windows/desktop/ff476456) と [**ID3D11DeviceContext::IASetIndexBuffer**](https://msdn.microsoft.com/library/windows/desktop/ff476453) を呼び出して、頂点バッファーとインデックス バッファーを入力アセンブラー ステージにバインドします。</span><span class="sxs-lookup"><span data-stu-id="814d2-158">Next, we call [**ID3D11DeviceContext::IASetVertexBuffers**](https://msdn.microsoft.com/library/windows/desktop/ff476456) and [**ID3D11DeviceContext::IASetIndexBuffer**](https://msdn.microsoft.com/library/windows/desktop/ff476453) to bind the vertex and index buffers to the input-assembler stage.</span></span>
3.  <span data-ttu-id="814d2-159">次に、呼び出して[ **ID3D11DeviceContext::IASetPrimitiveTopology** ](https://msdn.microsoft.com/library/windows/desktop/ff476455)で、 [ **D3D11\_プリミティブ\_トポロジ\_TRIANGLESTRIP** ](https://msdn.microsoft.com/library/windows/desktop/ff476189#D3D11_PRIMITIVE_TOPOLOGY_TRIANGLESTRIP)入力アセンブラー ステージを三角形ストリップとして頂点データの解釈を指定する値。</span><span class="sxs-lookup"><span data-stu-id="814d2-159">Next, we call [**ID3D11DeviceContext::IASetPrimitiveTopology**](https://msdn.microsoft.com/library/windows/desktop/ff476455) with the [**D3D11\_PRIMITIVE\_TOPOLOGY\_TRIANGLESTRIP**](https://msdn.microsoft.com/library/windows/desktop/ff476189#D3D11_PRIMITIVE_TOPOLOGY_TRIANGLESTRIP) value to specify for the input-assembler stage to interpret the vertex data as a triangle strip.</span></span>
4.  <span data-ttu-id="814d2-160">次に、[**ID3D11DeviceContext::VSSetShader**](https://msdn.microsoft.com/library/windows/desktop/ff476493) を呼び出して頂点シェーダー ステージを頂点シェーダー コードで初期化し、さらに、[**ID3D11DeviceContext::PSSetShader**](https://msdn.microsoft.com/library/windows/desktop/ff476472) を呼び出してピクセル シェーダー ステージをピクセル シェーダー コードで初期化します。</span><span class="sxs-lookup"><span data-stu-id="814d2-160">Next, we call [**ID3D11DeviceContext::VSSetShader**](https://msdn.microsoft.com/library/windows/desktop/ff476493) to initialize the vertex shader stage with the vertex shader code and [**ID3D11DeviceContext::PSSetShader**](https://msdn.microsoft.com/library/windows/desktop/ff476472) to initialize the pixel shader stage with the pixel shader code.</span></span>
5.  <span data-ttu-id="814d2-161">次に、[**ID3D11DeviceContext::VSSetConstantBuffers**](https://msdn.microsoft.com/library/windows/desktop/ff476491) を呼び出し、頂点シェーダーのパイプライン ステージで使われる定数バッファーを設定します。</span><span class="sxs-lookup"><span data-stu-id="814d2-161">Next, we call [**ID3D11DeviceContext::VSSetConstantBuffers**](https://msdn.microsoft.com/library/windows/desktop/ff476491) to set the constant buffer that is used by the vertex shader pipeline stage.</span></span>
6.  <span data-ttu-id="814d2-162">次に、[**PSSetShaderResources**](https://msdn.microsoft.com/library/windows/desktop/ff476473) を呼び出し、テクスチャのシェーダー リソース ビューをピクセル シェーダーのパイプライン ステージにバインドします。</span><span class="sxs-lookup"><span data-stu-id="814d2-162">Next, we call [**PSSetShaderResources**](https://msdn.microsoft.com/library/windows/desktop/ff476473) to bind the shader-resource view of the texture to the pixel shader pipeline stage.</span></span>
7.  <span data-ttu-id="814d2-163">次に、[**PSSetSamplers**](https://msdn.microsoft.com/library/windows/desktop/ff476471) を呼び出し、サンプラー ステートをピクセル シェーダーのパイプライン ステージに設定します。</span><span class="sxs-lookup"><span data-stu-id="814d2-163">Next, we call [**PSSetSamplers**](https://msdn.microsoft.com/library/windows/desktop/ff476471) to set the sampler state to the pixel shader pipeline stage.</span></span>
8.  <span data-ttu-id="814d2-164">最後に、[**ID3D11DeviceContext::DrawIndexed**](https://msdn.microsoft.com/library/windows/desktop/ff476409) を呼び出して立方体を描画し、レンダリング パイプラインに送ります。</span><span class="sxs-lookup"><span data-stu-id="814d2-164">Finally, we call [**ID3D11DeviceContext::DrawIndexed**](https://msdn.microsoft.com/library/windows/desktop/ff476409) to draw the cube and submit it to the rendering pipeline.</span></span>

<span data-ttu-id="814d2-165">前のチュートリアルと同様、[**IDXGISwapChain::Present**](https://msdn.microsoft.com/library/windows/desktop/bb174576) を呼び出して、レンダリングされた画像をウィンドウに表示します。</span><span class="sxs-lookup"><span data-stu-id="814d2-165">As in the previous tutorials, we call [**IDXGISwapChain::Present**](https://msdn.microsoft.com/library/windows/desktop/bb174576) to present the rendered image to the window.</span></span>

```cppcx
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

## <a name="summary"></a><span data-ttu-id="814d2-166">概要</span><span class="sxs-lookup"><span data-stu-id="814d2-166">Summary</span></span>

<span data-ttu-id="814d2-167">このトピックは、テクスチャの生のデータが読み込まれてし、そのデータを 3D プリミティブに適用します。</span><span class="sxs-lookup"><span data-stu-id="814d2-167">In this topic, we loaded raw texture data, and applied that data to a 3D primitive.</span></span>