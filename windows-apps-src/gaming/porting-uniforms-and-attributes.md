---
author: mtoepke
title: OpenGL ES 2.0 のバッファー、uniform、頂点属性 を Direct3D に移植する
description: OpenGL ES 2.0 から Direct3D 11 に移植するプロセスでは、アプリとシェーダー プログラムの間でデータを受け渡すための構文と API の動作を変更する必要があります。
ms.assetid: 9b215874-6549-80c5-cc70-c97b571c74fe
ms.author: mtoepke
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, OpenGL, Direct3D, バッファー, uniform, 頂点属性
ms.localizationpriority: medium
ms.openlocfilehash: bc0192eb4b89ef91bc895a96e46cd39524f24c44
ms.sourcegitcommit: e2fca6c79f31e521ba76f7ecf343cf8f278e6a15
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/15/2018
ms.locfileid: "6977652"
---
# <a name="compare-opengl-es-20-buffers-uniforms-and-vertex-attributes-to-direct3d"></a><span data-ttu-id="d02f7-104">OpenGL ES 2.0 のバッファー、uniform、頂点 attribute と Direct3D の比較</span><span class="sxs-lookup"><span data-stu-id="d02f7-104">Compare OpenGL ES 2.0 buffers, uniforms, and vertex attributes to Direct3D</span></span>




**<span data-ttu-id="d02f7-105">重要な API</span><span class="sxs-lookup"><span data-stu-id="d02f7-105">Important APIs</span></span>**

-   [**<span data-ttu-id="d02f7-106">ID3D11Device1::CreateBuffer</span><span class="sxs-lookup"><span data-stu-id="d02f7-106">ID3D11Device1::CreateBuffer</span></span>**](https://msdn.microsoft.com/library/windows/desktop/hh404575)
-   [**<span data-ttu-id="d02f7-107">ID3D11Device1::CreateInputLayout</span><span class="sxs-lookup"><span data-stu-id="d02f7-107">ID3D11Device1::CreateInputLayout</span></span>**](https://msdn.microsoft.com/library/windows/desktop/ff476512)
-   [**<span data-ttu-id="d02f7-108">ID3D11DeviceContext1::IASetInputLayout</span><span class="sxs-lookup"><span data-stu-id="d02f7-108">ID3D11DeviceContext1::IASetInputLayout</span></span>**](https://msdn.microsoft.com/library/windows/desktop/ff476454)

<span data-ttu-id="d02f7-109">OpenGL ES 2.0 から Direct3D 11 に移植するプロセスでは、アプリとシェーダー プログラムの間でデータを受け渡すための構文と API の動作を変更する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d02f7-109">During the process of porting to Direct3D 11 from OpenGL ES 2.0, you must change the syntax and API behavior for passing data between the app and the shader programs.</span></span>

<span data-ttu-id="d02f7-110">OpenGL ES 2.0 では、4 つの方法で (定数データは uniform として、頂点データは attribute として、テクスチャなどのその他のリソース データはバッファー オブジェクトとして) シェーダー プログラムとの間でデータを受け渡します。</span><span class="sxs-lookup"><span data-stu-id="d02f7-110">In OpenGL ES 2.0, data is passed to and from shader programs in four ways: as uniforms for constant data, as attributes for vertex data, as buffer objects for other resource data (such as textures).</span></span> <span data-ttu-id="d02f7-111">Direct3D 11 では、これらはだいたい定数バッファー、頂点バッファー、サブリソースにマップされます。</span><span class="sxs-lookup"><span data-stu-id="d02f7-111">In Direct3D 11, these roughly map to constant buffers, vertex buffers, and subresources.</span></span> <span data-ttu-id="d02f7-112">表面上は似ていますが、使う際の処理はまったく異なります。</span><span class="sxs-lookup"><span data-stu-id="d02f7-112">Despite the superficial commonality, they are handled quite different in usage.</span></span>

<span data-ttu-id="d02f7-113">基本的なマッピングを次に示します。</span><span class="sxs-lookup"><span data-stu-id="d02f7-113">Here's the basic mapping.</span></span>

| <span data-ttu-id="d02f7-114">OpenGL ES 2.0</span><span class="sxs-lookup"><span data-stu-id="d02f7-114">OpenGL ES 2.0</span></span>             | <span data-ttu-id="d02f7-115">Direct3D 11</span><span class="sxs-lookup"><span data-stu-id="d02f7-115">Direct3D 11</span></span>                                                                                                                                                                         |
|---------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="d02f7-116">uniform</span><span class="sxs-lookup"><span data-stu-id="d02f7-116">uniform</span></span>                   | <span data-ttu-id="d02f7-117">定数バッファー (**cbuffer**) フィールド。</span><span class="sxs-lookup"><span data-stu-id="d02f7-117">constant buffer (**cbuffer**) field.</span></span>                                                                                                                                                |
| <span data-ttu-id="d02f7-118">attribute</span><span class="sxs-lookup"><span data-stu-id="d02f7-118">attribute</span></span>                 | <span data-ttu-id="d02f7-119">入力レイアウトで指定し、特定の HLSL セマンティクスでマークされた頂点バッファー要素フィールド。</span><span class="sxs-lookup"><span data-stu-id="d02f7-119">vertex buffer element field, designated by an input layout and marked with a specific HLSL semantic.</span></span>                                                                                |
| <span data-ttu-id="d02f7-120">バッファー オブジェクト</span><span class="sxs-lookup"><span data-stu-id="d02f7-120">buffer object</span></span>             | <span data-ttu-id="d02f7-121">バッファー (「[**D3D11\_SUBRESOURCE\_DATA**](https://msdn.microsoft.com/library/windows/desktop/ff476220)」、「[**D3D11\_BUFFER\_DESC**](https://msdn.microsoft.com/library/windows/desktop/ff476092)」、汎用バッファーの定義に関するページをご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="d02f7-121">buffer; See [**D3D11\_SUBRESOURCE\_DATA**](https://msdn.microsoft.com/library/windows/desktop/ff476220) and [**D3D11\_BUFFER\_DESC**](https://msdn.microsoft.com/library/windows/desktop/ff476092) and for a general-use buffer definitions.</span></span> |
| <span data-ttu-id="d02f7-122">フレーム バッファー オブジェクト (FBO)</span><span class="sxs-lookup"><span data-stu-id="d02f7-122">frame buffer object (FBO)</span></span> | <span data-ttu-id="d02f7-123">レンダー ターゲット (「[**ID3D11Texture2D**](https://msdn.microsoft.com/library/windows/desktop/ff476635)」と「[**ID3D11RenderTargetView**](https://msdn.microsoft.com/library/windows/desktop/ff476582)」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="d02f7-123">render target(s); See [**ID3D11RenderTargetView**](https://msdn.microsoft.com/library/windows/desktop/ff476582) with [**ID3D11Texture2D**](https://msdn.microsoft.com/library/windows/desktop/ff476635).</span></span>                                       |
| <span data-ttu-id="d02f7-124">バック バッファー</span><span class="sxs-lookup"><span data-stu-id="d02f7-124">back buffer</span></span>               | <span data-ttu-id="d02f7-125">スワップ チェーンと "バック バッファー" サーフェス (「[**IDXGISwapChain1**](https://msdn.microsoft.com/library/windows/desktop/hh404631)」と「[**IDXGISurface1**](https://msdn.microsoft.com/library/windows/desktop/ff471343)」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="d02f7-125">swap chain with "back buffer" surface; See [**IDXGISwapChain1**](https://msdn.microsoft.com/library/windows/desktop/hh404631) with attached [**IDXGISurface1**](https://msdn.microsoft.com/library/windows/desktop/ff471343).</span></span>                       |

 

## <a name="port-buffers"></a><span data-ttu-id="d02f7-126">バッファーの移植</span><span class="sxs-lookup"><span data-stu-id="d02f7-126">Port buffers</span></span>


<span data-ttu-id="d02f7-127">OpenGL ES 2.0 では、どの種類のバッファーでも、作成してバインドするプロセスは、通常、次のパターンに従います。</span><span class="sxs-lookup"><span data-stu-id="d02f7-127">In OpenGL ES 2.0, the process for creating and binding any kind of buffer generally follows this pattern</span></span>

-   <span data-ttu-id="d02f7-128">glGenBuffers を呼び出して、1 つ以上のバッファーを生成し、それらへのハンドルを返す。</span><span class="sxs-lookup"><span data-stu-id="d02f7-128">Call glGenBuffers to generate one or more buffers and return the handles to them.</span></span>
-   <span data-ttu-id="d02f7-129">glBindBuffer を呼び出して、GL\_ELEMENT\_ARRAY\_BUFFER などのバッファーのレイアウトを定義する。</span><span class="sxs-lookup"><span data-stu-id="d02f7-129">Call glBindBuffer to define the layout of a buffer, such as GL\_ELEMENT\_ARRAY\_BUFFER.</span></span>
-   <span data-ttu-id="d02f7-130">glBufferData を呼び出して、特定のレイアウトの特定のデータ (頂点の構造体、インデックス データ、色データなど) をバッファーに設定する。</span><span class="sxs-lookup"><span data-stu-id="d02f7-130">Call glBufferData to populate the buffer with specific data (such as vertex structures, index data, or color data) in a specific layout.</span></span>

<span data-ttu-id="d02f7-131">最も一般的なバッファーは頂点バッファーで、少なくとも何らかの座標系内の頂点の位置を含みます。</span><span class="sxs-lookup"><span data-stu-id="d02f7-131">The most common kind of buffer is the vertex buffer, which minimally contains the positions of the vertices in some coordinate system.</span></span> <span data-ttu-id="d02f7-132">一般的な用途では、頂点は、位置座標、頂点の位置に向かう法線ベクトル、頂点の位置に向かう接線ベクトル、テクスチャ検索 (uv) 座標を含む構造体によって表されます。</span><span class="sxs-lookup"><span data-stu-id="d02f7-132">In typical use, a vertex is represented by a structure that contains the position coordinates, a normal vector to the vertex position, a tangent vector to the vertex position, and texture lookup (uv) coordinates.</span></span> <span data-ttu-id="d02f7-133">バッファーには何らかの順序 (三角形リスト、三角形ストリップ、三角形ファンなど) でのそうした頂点の連続する一覧が含まれ、それらがまとまってシーンに表示されるポリゴンを表します </span><span class="sxs-lookup"><span data-stu-id="d02f7-133">The buffer contains a contiguous list of these vertices, in some order (like a triangle list, or strip, or fan), and which collectively represent the visible polygons in your scene.</span></span> <span data-ttu-id="d02f7-134">(Direct3D 11 でも、OpenGL ES 2.0 でも、描画呼び出しごとに複数の頂点バッファーを作成するのは効率的ではありません)。</span><span class="sxs-lookup"><span data-stu-id="d02f7-134">(In Direct3D 11 as well as OpenGL ES 2.0 it is inefficient to have multiple vertex buffers per draw call.)</span></span>

<span data-ttu-id="d02f7-135">OpenGL ES 2.0 で作成した頂点バッファーとインデックス バッファーの例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="d02f7-135">Here's an example a vertex buffer and an index buffer created with OpenGL ES 2.0:</span></span>

<span data-ttu-id="d02f7-136">OpenGL ES 2.0: 頂点バッファーとインデックス バッファーの作成と設定</span><span class="sxs-lookup"><span data-stu-id="d02f7-136">OpenGL ES 2.0: Creating and populating a vertex buffer and an index buffer.</span></span>

``` syntax
glGenBuffers(1, &renderer->vertexBuffer);
glBindBuffer(GL_ARRAY_BUFFER, renderer->vertexBuffer);
glBufferData(GL_ARRAY_BUFFER, sizeof(Vertex) * CUBE_VERTICES, renderer->vertices, GL_STATIC_DRAW);

glGenBuffers(1, &renderer->indexBuffer);
glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, renderer->indexBuffer);
glBufferData(GL_ELEMENT_ARRAY_BUFFER, sizeof(int) * CUBE_INDICES, renderer->vertexIndices, GL_STATIC_DRAW);
```

<span data-ttu-id="d02f7-137">他のバッファーには、ピクセル バッファーとマップ (テクスチャなど) があります。</span><span class="sxs-lookup"><span data-stu-id="d02f7-137">Other buffers include pixel buffers and maps, like textures.</span></span> <span data-ttu-id="d02f7-138">シェーダー パイプラインでは、テクスチャ バッファー (pixmap) にレンダリングすることや、バッファー オブジェクトをレンダリングすることができます。また、後のシェーダー パスでこれらのバッファーを使うこともできます。</span><span class="sxs-lookup"><span data-stu-id="d02f7-138">The shader pipeline can render into texture buffers (pixmaps) or render buffer objects and use those buffers in future shader passes.</span></span> <span data-ttu-id="d02f7-139">最も単純なケースでは、呼び出しフローは次のようになります。</span><span class="sxs-lookup"><span data-stu-id="d02f7-139">In the simplest case, the call flow is:</span></span>

-   <span data-ttu-id="d02f7-140">glGenFramebuffers を呼び出して、フレーム バッファー オブジェクトを生成する。</span><span class="sxs-lookup"><span data-stu-id="d02f7-140">Call glGenFramebuffers to generate a frame buffer object.</span></span>
-   <span data-ttu-id="d02f7-141">glBindFramebuffer を呼び出して、書き込み用にフレーム バッファー オブジェクトをバインドする。</span><span class="sxs-lookup"><span data-stu-id="d02f7-141">Call glBindFramebuffer to bind the frame buffer object for writing.</span></span>
-   <span data-ttu-id="d02f7-142">glFramebufferTexture2D を呼び出して、指定されたテクスチャ マップに描画する。</span><span class="sxs-lookup"><span data-stu-id="d02f7-142">Call glFramebufferTexture2D to draw into a specified texture map.</span></span>

<span data-ttu-id="d02f7-143">Direct3D 11 では、バッファー データ要素は "サブリソース" と見なされます。そうした要素には、個々の頂点データ要素や MIP マップ テクスチャなどがあります。</span><span class="sxs-lookup"><span data-stu-id="d02f7-143">In Direct3D 11, buffer data elements are considered "subresources," and can range from individual vertex data elements to MIP-map textures.</span></span>

-   <span data-ttu-id="d02f7-144">バッファー データ要素の構成を [**D3D11\_SUBRESOURCE\_DATA**](https://msdn.microsoft.com/library/windows/desktop/ff476220) 構造体に設定する。</span><span class="sxs-lookup"><span data-stu-id="d02f7-144">Populate a [**D3D11\_SUBRESOURCE\_DATA**](https://msdn.microsoft.com/library/windows/desktop/ff476220) structure with the configuration for a buffer data element.</span></span>
-   <span data-ttu-id="d02f7-145">バッファーの個々の要素のサイズとバッファーの種類を [**D3D11\_BUFFER\_DESC**](https://msdn.microsoft.com/library/windows/desktop/ff476092) 構造体に設定する。</span><span class="sxs-lookup"><span data-stu-id="d02f7-145">Populate a [**D3D11\_BUFFER\_DESC**](https://msdn.microsoft.com/library/windows/desktop/ff476092) structure with the size of the individual elements in the buffer as well as the buffer type.</span></span>
-   <span data-ttu-id="d02f7-146">これら 2 つの構造体を指定して [**ID3D11Device1::CreateBuffer**](https://msdn.microsoft.com/library/windows/desktop/hh404575) を呼び出す。</span><span class="sxs-lookup"><span data-stu-id="d02f7-146">Call [**ID3D11Device1::CreateBuffer**](https://msdn.microsoft.com/library/windows/desktop/hh404575) with these two structures.</span></span>

<span data-ttu-id="d02f7-147">Direct3D 11: 頂点バッファーとインデックス バッファーの作成と設定</span><span class="sxs-lookup"><span data-stu-id="d02f7-147">Direct3D 11: Creating and populating a vertex buffer and an index buffer.</span></span>

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
    
```

<span data-ttu-id="d02f7-148">フレーム バッファーなど、書き込み可能なピクセル バッファーやマップは、[**ID3D11Texture2D**](https://msdn.microsoft.com/library/windows/desktop/ff476635) オブジェクトとして作成できます。</span><span class="sxs-lookup"><span data-stu-id="d02f7-148">Writable pixel buffers or maps, such as a frame buffer, can be created as [**ID3D11Texture2D**](https://msdn.microsoft.com/library/windows/desktop/ff476635) objects.</span></span> <span data-ttu-id="d02f7-149">これらはリソースとして [**ID3D11RenderTargetView**](https://msdn.microsoft.com/library/windows/desktop/ff476582) または [**ID3D11ShaderResourceView**](https://msdn.microsoft.com/library/windows/desktop/ff476628) にバインドできます。また、一度描画すると、ID3D11RenderTargetView は関連付けられているスワップ チェーンを使って表示でき、ID3D11ShaderResourceView はシェーダーに渡すことができます。</span><span class="sxs-lookup"><span data-stu-id="d02f7-149">These can be bound as resources to an [**ID3D11RenderTargetView**](https://msdn.microsoft.com/library/windows/desktop/ff476582) or [**ID3D11ShaderResourceView**](https://msdn.microsoft.com/library/windows/desktop/ff476628), which, once drawn into, can be displayed with the associated swap chain or passed to a shader, respectively.</span></span>

<span data-ttu-id="d02f7-150">Direct3D 11: フレーム バッファー オブジェクトの作成</span><span class="sxs-lookup"><span data-stu-id="d02f7-150">Direct3D 11: Creating a frame buffer object.</span></span>

``` syntax
ComPtr<ID3D11RenderTargetView> m_d3dRenderTargetViewWin;
// ...
ComPtr<ID3D11Texture2D> frameBuffer;

m_swapChainCoreWindow->GetBuffer(0, IID_PPV_ARGS(&frameBuffer));
m_d3dDevice->CreateRenderTargetView(
  frameBuffer.Get(),
  nullptr,
  &m_d3dRenderTargetViewWin);
```

## <a name="change-uniforms-and-uniform-buffer-objects-to-direct3d-constant-buffers"></a><span data-ttu-id="d02f7-151">Direct3D の定数バッファーへの uniform と uniform バッファー オブジェクトの変更</span><span class="sxs-lookup"><span data-stu-id="d02f7-151">Change uniforms and uniform buffer objects to Direct3D constant buffers</span></span>


<span data-ttu-id="d02f7-152">OpenGL ES 2.0 では、uniform は個々のシェーダー プログラムに定数データを渡すためのメカニズムです。</span><span class="sxs-lookup"><span data-stu-id="d02f7-152">In Open GL ES 2.0, uniforms are the mechanism to supply constant data to individual shader programs.</span></span> <span data-ttu-id="d02f7-153">このデータをシェーダーが変更することはできません。</span><span class="sxs-lookup"><span data-stu-id="d02f7-153">This data cannot be altered by the shaders.</span></span>

<span data-ttu-id="d02f7-154">uniform を設定する際は、通常、GPU 内のアップロード場所とアプリ メモリ内のデータへのポインターを指定した glUniform\* メソッドの 1 つを渡します。</span><span class="sxs-lookup"><span data-stu-id="d02f7-154">Setting a uniform typically involves providing one of the glUniform\* methods with the upload location in the GPU along with a pointer to the data in app memory.</span></span> <span data-ttu-id="d02f7-155">glUniform\* メソッドを実行すると、uniform データは GPU メモリに配置され、その uniform を宣言したシェーダーからアクセスできるようになります。</span><span class="sxs-lookup"><span data-stu-id="d02f7-155">After ithe glUniform\* method executes, the uniform data is in the GPU memory and accessible by the shaders that have declared that uniform.</span></span> <span data-ttu-id="d02f7-156">シェーダーがシェーダー内の uniform の宣言に基づいて (互換性のある型を使って) 解釈できる方法でデータをパックする必要があります。</span><span class="sxs-lookup"><span data-stu-id="d02f7-156">You are expected to ensure that the data is packed in such a way that the shader can interpret it based on the uniform declaration in the shader (by using compatible types).</span></span>

<span data-ttu-id="d02f7-157">OpenGL ES 2.0: uniform の作成と uniform へのデータのアップロード</span><span class="sxs-lookup"><span data-stu-id="d02f7-157">OpenGL ES 2.0 Creating a uniform and uploading data to it</span></span>

``` syntax
renderer->mvpLoc = glGetUniformLocation(renderer->programObject, "u_mvpMatrix");

// ...

glUniformMatrix4fv(renderer->mvpLoc, 1, GL_FALSE, (GLfloat*) &renderer->mvpMatrix.m[0][0]);
```

<span data-ttu-id="d02f7-158">シェーダーの GLSL では、対応する uniform の宣言は次のようになります。</span><span class="sxs-lookup"><span data-stu-id="d02f7-158">In a shader's GLSL, the corresponding uniform declaration looks like this:</span></span>

<span data-ttu-id="d02f7-159">Open GL ES 2.0: GLSL での uniform の宣言</span><span class="sxs-lookup"><span data-stu-id="d02f7-159">Open GL ES 2.0: GLSL uniform declaration</span></span>

``` syntax
uniform mat4 u_mvpMatrix;
```

<span data-ttu-id="d02f7-160">Direct3D では、uniform データを "定数バッファー" として指定します。定数バッファーには、uniform と同じように、個々のシェーダーに渡す定数データを含めます。</span><span class="sxs-lookup"><span data-stu-id="d02f7-160">Direct3D designates uniform data as "constant buffers," which, like uniforms, contain constant data provided to individual shaders.</span></span> <span data-ttu-id="d02f7-161">uniform バッファーと同じように、シェーダーが解釈できる方法でメモリ内の定数バッファー データをパックすることが重要です。</span><span class="sxs-lookup"><span data-stu-id="d02f7-161">As with uniform buffers, it is important to pack the constant buffer data in memory identically to the way the shader expects to interpret it.</span></span> <span data-ttu-id="d02f7-162">プラットフォームの型 (**float\*** や **float\[4\]** など) ではなく、DirectXMath 型 ([**XMFLOAT4**](https://msdn.microsoft.com/library/windows/desktop/ee419608) など) を使って、データ要素のアラインメントが適切に行われるようにします。</span><span class="sxs-lookup"><span data-stu-id="d02f7-162">Using DirectXMath types (such as [**XMFLOAT4**](https://msdn.microsoft.com/library/windows/desktop/ee419608)) instead of platform types (such as **float\*** or **float\[4\]**) guarantees proper data element alignment.</span></span>

<span data-ttu-id="d02f7-163">定数バッファーには、GPU でそのデータを参照するために使う GPU レジスタを関連付ける必要があります。</span><span class="sxs-lookup"><span data-stu-id="d02f7-163">Constant buffers must have an associated GPU register used to reference that data on the GPU.</span></span> <span data-ttu-id="d02f7-164">データは、バッファーのレイアウトで指定されているレジスタの場所にパックされます。</span><span class="sxs-lookup"><span data-stu-id="d02f7-164">The data is packed into the register location as indicated by the layout of the buffer.</span></span>

<span data-ttu-id="d02f7-165">Direct3D 11: 定数バッファーの作成と定数バッファーへのデータのアップロード</span><span class="sxs-lookup"><span data-stu-id="d02f7-165">Direct3D 11: Creating a constant buffer and uploading data to it</span></span>

``` syntax
struct ModelViewProjectionConstantBuffer
{
     DirectX::XMFLOAT4X4 mvp;
};

// ...

ModelViewProjectionConstantBuffer   m_constantBufferData;

// ...

XMStoreFloat4x4(&m_constantBufferData.mvp, mvpMatrix);

CD3D11_BUFFER_DESC constantBufferDesc(sizeof(ModelViewProjectionConstantBuffer), D3D11_BIND_CONSTANT_BUFFER);
m_d3dDevice->CreateBuffer(
  &constantBufferDesc,
  nullptr,
  &m_constantBuffer);
```

<span data-ttu-id="d02f7-166">シェーダーの HLSL では、対応する定数バッファーの宣言は次のようになります。</span><span class="sxs-lookup"><span data-stu-id="d02f7-166">In a shader's HLSL, the corresponding constant buffer declaration looks like this:</span></span>

<span data-ttu-id="d02f7-167">Direct3D 11: HLSL での定数バッファーの宣言</span><span class="sxs-lookup"><span data-stu-id="d02f7-167">Direct3D 11: Constant buffer HLSL declaration</span></span>

``` syntax
cbuffer ModelViewProjectionConstantBuffer : register(b0)
{
  matrix mvp;
};
```

<span data-ttu-id="d02f7-168">定数バッファーごとにレジスタを宣言する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d02f7-168">Note that a register must be declared for each constant buffer.</span></span> <span data-ttu-id="d02f7-169">Direct3D 機能レベルによって、利用できるレジスタの最大数が異なります。そのため、ターゲットとする最も低い機能レベルの最大数を超えないようにしてください。</span><span class="sxs-lookup"><span data-stu-id="d02f7-169">Different Direct3D feature levels have different maximum available registers, so do not exceed the maximum number for the lowest feature level you are targeting.</span></span>

## <a name="port-vertex-attributes-to-a-direct3d-input-layouts-and-hlsl-semantics"></a><span data-ttu-id="d02f7-170">Direct3D の入力レイアウトと HLSL セマンティクスへの頂点 attribute の移植</span><span class="sxs-lookup"><span data-stu-id="d02f7-170">Port vertex attributes to a Direct3D input layouts and HLSL semantics</span></span>


<span data-ttu-id="d02f7-171">頂点データはシェーダー パイプラインで変更できるため、OpenGL ES 2.0 では、頂点データを "uniform" ではなく "attribute" として指定する必要があります </span><span class="sxs-lookup"><span data-stu-id="d02f7-171">Since vertex data can be modified by the shader pipeline, OpenGL ES 2.0 requires that you specify them as "attributes" instead of "uniforms".</span></span> <span data-ttu-id="d02f7-172">(これは最近のバージョンの OpenGL と GLSL で変更されました)。頂点の位置、法線、接線、色値などの頂点固有のデータは、attribute 値としてシェーダーに渡します。</span><span class="sxs-lookup"><span data-stu-id="d02f7-172">(This has changed in later versions of OpenGL and GLSL.) Vertex-specific data such the vertex position, normals, tangents, and color values are supplied to the shaders as attribute values.</span></span> <span data-ttu-id="d02f7-173">これらの attribute 値は、頂点データの各要素の特定のオフセットに対応しています。たとえば、1 つ目の attribute は個々の頂点の位置コンポーネントを指し、2 つ目は法線を指します。</span><span class="sxs-lookup"><span data-stu-id="d02f7-173">These attribute values correspond to specific offsets for each element in the vertex data; for example, the first attribute could point to the position component of an individual vertex, and the second to the normal, and so on.</span></span>

<span data-ttu-id="d02f7-174">メイン メモリから GPU に頂点バッファー データを移動する基本的なプロセスを次のようになります。</span><span class="sxs-lookup"><span data-stu-id="d02f7-174">The basic process for moving the vertex buffer data from main memory to the GPU looks like this:</span></span>

-   <span data-ttu-id="d02f7-175">glBindBuffer を使って、頂点データをアップロードする。</span><span class="sxs-lookup"><span data-stu-id="d02f7-175">Upload the vertex data with glBindBuffer.</span></span>
-   <span data-ttu-id="d02f7-176">glGetAttribLocation を使って、GPU 上の attribute の場所を取得する。</span><span class="sxs-lookup"><span data-stu-id="d02f7-176">Get the location of the attributes on the GPU with glGetAttribLocation.</span></span> <span data-ttu-id="d02f7-177">頂点データ要素の attribute ごとに glGetAttribLocation を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="d02f7-177">Call it for each attribute in the vertex data element.</span></span>
-   <span data-ttu-id="d02f7-178">glVertexAttribPointer を呼び出して、個々の頂点データ要素内の正しい attribute のサイズとオフセットを設定する。</span><span class="sxs-lookup"><span data-stu-id="d02f7-178">Call glVertexAttribPointer to provide set the correct attribute size and offset inside an individual vertex data element.</span></span> <span data-ttu-id="d02f7-179">attribute ごとにこれを実行します。</span><span class="sxs-lookup"><span data-stu-id="d02f7-179">Do this for each attribute.</span></span>
-   <span data-ttu-id="d02f7-180">glEnableVertexAttribArray を使って、頂点データのレイアウト情報を有効にする。</span><span class="sxs-lookup"><span data-stu-id="d02f7-180">Enable the vertex data layout information with glEnableVertexAttribArray.</span></span>

<span data-ttu-id="d02f7-181">OpenGL ES 2.0: シェーダーの attribute への頂点バッファー データのアップロード</span><span class="sxs-lookup"><span data-stu-id="d02f7-181">OpenGL ES 2.0: Uploading vertex buffer data to the shader attribute</span></span>

``` syntax
glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, renderer->vertexBuffer);
loc = glGetAttribLocation(renderer->programObject, "a_position");

glVertexAttribPointer(loc, 3, GL_FLOAT, GL_FALSE, 
  sizeof(Vertex), 0);
loc = glGetAttribLocation(renderer->programObject, "a_color");
glEnableVertexAttribArray(loc);

glVertexAttribPointer(loc, 4, GL_FLOAT, GL_FALSE, 
  sizeof(Vertex), (GLvoid*) (sizeof(float) * 3));
glEnableVertexAttribArray(loc);
```

<span data-ttu-id="d02f7-182">次に、頂点シェーダーで、glGetAttribLocation の呼び出しで定義したのと同じ名前の attribute を宣言します。</span><span class="sxs-lookup"><span data-stu-id="d02f7-182">Now, in your vertex shader, you declare attributes with the same names you defined in your call to glGetAttribLocation.</span></span>

<span data-ttu-id="d02f7-183">OpenGL ES 2.0: GLSL での attribute の宣言</span><span class="sxs-lookup"><span data-stu-id="d02f7-183">OpenGL ES 2.0: Declaring an attribute in GLSL</span></span>

``` syntax
attribute vec4 a_position;
attribute vec4 a_color;                     
```

<span data-ttu-id="d02f7-184">ある意味では、同じプロセスが Direct3D にも当てはまります。</span><span class="sxs-lookup"><span data-stu-id="d02f7-184">In some ways, the same process holds for Direct3D.</span></span> <span data-ttu-id="d02f7-185">attribute ではなく、頂点データを入力バッファーに配置します。入力バッファーには、頂点バッファーと、対応するインデックス バッファーが含まれます。</span><span class="sxs-lookup"><span data-stu-id="d02f7-185">Instead of a attributes, vertex data is provided in input buffers, which include vertex buffers and the corresponding index buffers.</span></span> <span data-ttu-id="d02f7-186">ただし、Direct3D には "attribute" の宣言がないため、頂点バッファー内のデータ要素の個々のコンポーネントと、それらのコンポーネントを頂点シェーダーが解釈する場所と方法を示す HLSL セマンティクスを宣言する入力レイアウトを指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d02f7-186">However, since Direct3D does not have the "attribute" declaration, you must specify an input layout which declares the individual component of the data elements in the vertex buffer and the HLSL semantics that indicate where and how those components are to be interpreted by the vertex shader.</span></span> <span data-ttu-id="d02f7-187">HLSL セマンティクスでは、シェーダー エンジンに目的を通知する特定の文字列を使って、各コンポーネントの用途を定義する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d02f7-187">HLSL semantics require that you define the usage of each component with a specific string that informs the shader engine as to its purpose.</span></span> <span data-ttu-id="d02f7-188">たとえば、頂点の位置データは POSITION とマークし、法線データは NORMAL とマークし、頂点の色データは COLOR とマークします </span><span class="sxs-lookup"><span data-stu-id="d02f7-188">For example, vertex position data is marked as POSITION, normal data is marked as NORMAL, and vertex color data is marked as COLOR.</span></span> <span data-ttu-id="d02f7-189">(また、他のシェーダー ステージでも特定のセマンティクスが必要です。それらのセマンティクスは、シェーダー ステージに応じて解釈が異なります)。HLSL セマンティクスについて詳しくは、「[OpenGL ES 2.0 と Direct3D のシェーダー パイプラインの比較](change-your-shader-loading-code.md)」と「[HLSL セマンティクス](https://msdn.microsoft.com/library/windows/desktop/bb205574)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d02f7-189">(Other shader stages also require specific semantics, and those semantics have different interpretations based on the shader stage.) For more info on HLSL semantics, read [Port your shader pipeline](change-your-shader-loading-code.md) and [HLSL Semantics](https://msdn.microsoft.com/library/windows/desktop/bb205574).</span></span>

<span data-ttu-id="d02f7-190">頂点バッファーとインデックス バッファーを設定し、入力レイアウトを設定するプロセスはまとめて Direct3D グラフィックス パイプラインの "入力アセンブリ" (IA) ステージと呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="d02f7-190">Collectively, the process of setting the vertex and index buffers, and setting the input layout is called the "Input Assembly" (IA) stage of the Direct3D graphics pipeline.</span></span>

<span data-ttu-id="d02f7-191">Direct3D 11: 入力アセンブリ ステージの構成</span><span class="sxs-lookup"><span data-stu-id="d02f7-191">Direct3D 11: Configuring the input assembly stage</span></span>

``` syntax
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
```

<span data-ttu-id="d02f7-192">入力レイアウトを宣言し、頂点シェーダーに関連付けるには、頂点データ要素の形式と、各コンポーネントに使うセマンティクスを宣言します。</span><span class="sxs-lookup"><span data-stu-id="d02f7-192">An input layout is declared and associated with a vertex shader by declaring the format of the vertex data element and the semantic used for each component.</span></span> <span data-ttu-id="d02f7-193">作成した D3D11\_INPUT\_ELEMENT\_DESC に記述されている頂点要素データのレイアウトは、対応する構造体のレイアウトと対応している必要があります。</span><span class="sxs-lookup"><span data-stu-id="d02f7-193">The vertex element data layout described in the D3D11\_INPUT\_ELEMENT\_DESC you create must correspond to the layout of the corresponding structure.</span></span> <span data-ttu-id="d02f7-194">ここでは、次の 2 つのコンポーネントを含む頂点データのレイアウトを作成します。</span><span class="sxs-lookup"><span data-stu-id="d02f7-194">Here, you create a layout for vertex data that has two components:</span></span>

-   <span data-ttu-id="d02f7-195">メイン メモリ内で XMFLOAT3 として表される頂点の位置座標。これは、(x, y, z) 座標の 3 つの 32 ビット浮動小数点値のアラインメントされた配列です。</span><span class="sxs-lookup"><span data-stu-id="d02f7-195">A vertex position coordinate, represented in main memory as an XMFLOAT3, which is an aligned array of 3 32-bit floating point values for the (x, y, z) coordinates.</span></span>
-   <span data-ttu-id="d02f7-196">XMFLOAT4 として表される頂点の色値。これは、色 (RGBA) の 4 つの 32 ビット浮動小数点値のアラインメントされた配列です。</span><span class="sxs-lookup"><span data-stu-id="d02f7-196">A vertex color value, represented as an XMFLOAT4, which is an aligned array of 4 32-bit floating point values for the color (RGBA).</span></span>

<span data-ttu-id="d02f7-197">それぞれのセマンティクスと形式の種類を割り当てます。</span><span class="sxs-lookup"><span data-stu-id="d02f7-197">You assign a semantic for each one, as well as a format type.</span></span> <span data-ttu-id="d02f7-198">次に、記述を [**ID3D11Device1::CreateInputLayout**](https://msdn.microsoft.com/library/windows/desktop/ff476512) に渡します。</span><span class="sxs-lookup"><span data-stu-id="d02f7-198">You then pass the description to [**ID3D11Device1::CreateInputLayout**](https://msdn.microsoft.com/library/windows/desktop/ff476512).</span></span> <span data-ttu-id="d02f7-199">入力レイアウトは、レンダリング メソッドの実行時に入力アセンブリを設定するために、[**ID3D11DeviceContext1::IASetInputLayout**](https://msdn.microsoft.com/library/windows/desktop/ff476454) を呼び出すときに使います。</span><span class="sxs-lookup"><span data-stu-id="d02f7-199">The input layout is used when we call [**ID3D11DeviceContext1::IASetInputLayout**](https://msdn.microsoft.com/library/windows/desktop/ff476454) when you set up the input assembly during our render method.</span></span>

<span data-ttu-id="d02f7-200">Direct3D 11: 特定のセマンティクスを使った入力レイアウトの記述</span><span class="sxs-lookup"><span data-stu-id="d02f7-200">Direct3D 11: Describing an input layout with specific semantics</span></span>

``` syntax
ComPtr<ID3D11InputLayout> m_inputLayout;

// ...

const D3D11_INPUT_ELEMENT_DESC vertexDesc[] = 
{
  { "POSITION", 0, DXGI_FORMAT_R32G32B32_FLOAT, 0, 0,  D3D11_INPUT_PER_VERTEX_DATA, 0 },
  { "COLOR",    0, DXGI_FORMAT_R32G32B32_FLOAT, 0, 12, D3D11_INPUT_PER_VERTEX_DATA, 0 },
};

m_d3dDevice->CreateInputLayout(
  vertexDesc,
  ARRAYSIZE(vertexDesc),
  fileData->Data,
  fileData->Length,
  &m_inputLayout);

// ...
// When we start the drawing process...

m_d3dContext->IASetInputLayout(m_inputLayout.Get());
```

<span data-ttu-id="d02f7-201">最後に、入力を宣言して、シェーダーが入力データを理解できるようにします。</span><span class="sxs-lookup"><span data-stu-id="d02f7-201">Finally, you make sure that the shader can understand the input data by declaring the input.</span></span> <span data-ttu-id="d02f7-202">レイアウト内で割り当てたセマンティクスを使って、GPU メモリ内の正しい場所を選択します。</span><span class="sxs-lookup"><span data-stu-id="d02f7-202">The semantics you assigned in the layout are used to select the correct locations in GPU memory.</span></span>

<span data-ttu-id="d02f7-203">Direct3D 11: HLSL セマンティクスを使ったシェーダーの入力データの宣言</span><span class="sxs-lookup"><span data-stu-id="d02f7-203">Direct3D 11: Declaring shader input data with HLSL semantics</span></span>

``` syntax
struct VertexShaderInput
{
  float3 pos : POSITION;
  float3 color : COLOR;
};
```

 

 




