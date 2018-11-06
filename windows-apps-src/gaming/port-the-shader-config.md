---
author: mtoepke
title: シェーダー オブジェクトの移植
description: OpenGL ES 2.0 から簡単なレンダラーを移植する場合、最初の手順では、Direct3D 11 の対応する頂点シェーダー オブジェクトとフラグメント シェーダー オブジェクトを設定し、コンパイル後にメイン プログラムがシェーダー オブジェクトと通信できるようにします。
ms.assetid: 0383b774-bc1b-910e-8eb6-cc969b3dcc08
ms.author: mtoepke
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, 移植, シェーダー, Direct3D, OpenGL
ms.localizationpriority: medium
ms.openlocfilehash: bbf7e05a93ccce4188d62f9800a5f225be713cc6
ms.sourcegitcommit: e814a13978f33654d8e995584f4b047cb53e0aef
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/05/2018
ms.locfileid: "6042113"
---
# <a name="port-the-shader-objects"></a><span data-ttu-id="be298-104">シェーダー オブジェクトの移植</span><span class="sxs-lookup"><span data-stu-id="be298-104">Port the shader objects</span></span>




**<span data-ttu-id="be298-105">重要な API</span><span class="sxs-lookup"><span data-stu-id="be298-105">Important APIs</span></span>**

-   [**<span data-ttu-id="be298-106">ID3D11Device</span><span class="sxs-lookup"><span data-stu-id="be298-106">ID3D11Device</span></span>**](https://msdn.microsoft.com/library/windows/desktop/ff476379)
-   [**<span data-ttu-id="be298-107">ID3D11DeviceContext</span><span class="sxs-lookup"><span data-stu-id="be298-107">ID3D11DeviceContext</span></span>**](https://msdn.microsoft.com/library/windows/desktop/ff476385)

<span data-ttu-id="be298-108">OpenGL ES 2.0 から簡単なレンダラーを移植する場合、最初の手順では、Direct3D 11 の対応する頂点シェーダー オブジェクトとフラグメント シェーダー オブジェクトを設定し、コンパイル後にメイン プログラムがシェーダー オブジェクトと通信できるようにします。</span><span class="sxs-lookup"><span data-stu-id="be298-108">When porting the simple renderer from OpenGL ES 2.0, the first step is to set up the equivalent vertex and fragment shader objects in Direct3D 11, and to make sure that the main program can communicate with the shader objects after they are compiled.</span></span>

> <span data-ttu-id="be298-109">**注:** 新しい Direct3D プロジェクトを作成するかどうか。</span><span class="sxs-lookup"><span data-stu-id="be298-109">**Note** Have you created a new Direct3D project?</span></span> <span data-ttu-id="be298-110">作成していない場合は、「[テンプレートからの DirectX ゲーム プロジェクトの作成](user-interface.md)」の指示に従ってください。</span><span class="sxs-lookup"><span data-stu-id="be298-110">If not, follow the instructions in [Create a new DirectX 11 project for Universal Windows Platform (UWP)](user-interface.md).</span></span> <span data-ttu-id="be298-111">このチュートリアルでは、画面に描画するために DXGI リソースと Direct3D リソースを作成していることを前提としています。これらのリソースは、テンプレートで提供されます。</span><span class="sxs-lookup"><span data-stu-id="be298-111">This walkthrough assumes that you have the created the DXGI and Direct3D resources for drawing to the screen, and which are provided in the template.</span></span>

 

<span data-ttu-id="be298-112">OpenGL ES 2.0 と同じように、Direct3D のコンパイル済みシェーダーは描画コンテキストに関連付ける必要があります。</span><span class="sxs-lookup"><span data-stu-id="be298-112">Much like OpenGL ES 2.0, the compiled shaders in Direct3D must be associated with a drawing context.</span></span> <span data-ttu-id="be298-113">ただし、Direct3D にはもともとシェーダー プログラム オブジェクトという概念がありません。そのため、代わりに、シェーダーを [**ID3D11DeviceContext**](https://msdn.microsoft.com/library/windows/desktop/ff476385) に直接割り当てる必要があります。</span><span class="sxs-lookup"><span data-stu-id="be298-113">However, Direct3D does not have the concept of a shader program object per se; instead, you must assign the shaders directly to a [**ID3D11DeviceContext**](https://msdn.microsoft.com/library/windows/desktop/ff476385).</span></span> <span data-ttu-id="be298-114">この手順では、OpenGL ES 2.0 のシェーダー オブジェクトを作成してバインドするプロセスに従い、Direct3D で対応する API の動作を実現します。</span><span class="sxs-lookup"><span data-stu-id="be298-114">This step follows the OpenGL ES 2.0 process for creating and binding shader objects, and provides you with the corresponding API behaviors in Direct3D.</span></span>

<a name="instructions"></a><span data-ttu-id="be298-115">手順</span><span class="sxs-lookup"><span data-stu-id="be298-115">Instructions</span></span>
------------

### <a name="step-1-compile-the-shaders"></a><span data-ttu-id="be298-116">手順 1: シェーダーのコンパイル</span><span class="sxs-lookup"><span data-stu-id="be298-116">Step 1: Compile the shaders</span></span>

<span data-ttu-id="be298-117">この簡単な OpenGL ES 2.0 のサンプルでは、シェーダーをテキスト ファイルとして保存し、実行時コンパイルのために文字列データとして読み込みます。</span><span class="sxs-lookup"><span data-stu-id="be298-117">In this simple OpenGL ES 2.0 sample, the shaders are stored as text files and loaded as string data for run-time compilation.</span></span>

<span data-ttu-id="be298-118">OpenGL ES 2.0: シェーダーのコンパイル</span><span class="sxs-lookup"><span data-stu-id="be298-118">OpenGL ES 2.0: Compile a shader</span></span>

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

<span data-ttu-id="be298-119">Direct3D では、シェーダーは実行時にコンパイルされず、常に、プログラムの他の部分をコンパイルしたときに、CSO ファイルにコンパイルされます。</span><span class="sxs-lookup"><span data-stu-id="be298-119">In Direct3D, shaders are not compiled during run-time; they are always compiled to CSO files when the rest of the program is compiled.</span></span> <span data-ttu-id="be298-120">Microsoft Visual Studio でアプリをコンパイルすると、HLSL ファイルは、アプリで読み込む必要がある CSO (.cso) ファイルにコンパイルされます。</span><span class="sxs-lookup"><span data-stu-id="be298-120">When you compile your app with Microsoft Visual Studio, the HLSL files are compiled to CSO (.cso) files that your app must load.</span></span> <span data-ttu-id="be298-121">アプリをパッケージ化するときは、これらの CSO ファイルを必ず含めてください。</span><span class="sxs-lookup"><span data-stu-id="be298-121">Make sure you include these CSO files with your app when you package it!</span></span>

> <span data-ttu-id="be298-122">**注:** 次の例は、シェーダーの読み込みと**auto**キーワードとラムダ構文を使用して非同期でコンパイルを実行します。</span><span class="sxs-lookup"><span data-stu-id="be298-122">**Note** The following example performs the shader loading and compilation asynchronously using the **auto** keyword and lambda syntax.</span></span> <span data-ttu-id="be298-123">ReadDataAsync() はテンプレートに実装されているメソッドで、CSO ファイルをバイト データの配列 (fileData) として読み取ります。</span><span class="sxs-lookup"><span data-stu-id="be298-123">ReadDataAsync() is a method implemented for the template that reads in a CSO file as an array of byte data (fileData).</span></span>

 

<span data-ttu-id="be298-124">Direct3D 11: シェーダーのコンパイル</span><span class="sxs-lookup"><span data-stu-id="be298-124">Direct3D 11: Compile a shader</span></span>

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

### <a name="step-2-create-and-load-the-vertex-and-fragment-pixel-shaders"></a><span data-ttu-id="be298-125">手順 2: 頂点シェーダーとフラグメント (ピクセル) シェーダーの作成と読み込み</span><span class="sxs-lookup"><span data-stu-id="be298-125">Step 2: Create and load the vertex and fragment (pixel) shaders</span></span>

<span data-ttu-id="be298-126">OpenGL ES 2.0 にはシェーダー "プログラム" という概念があります。この概念は、CPU で実行されるメイン プログラムと GPU で実行されるシェーダーの間のインターフェイスとして機能します。</span><span class="sxs-lookup"><span data-stu-id="be298-126">OpenGL ES 2.0 has the notion of a shader "program", which serves as the interface between the main program running on the CPU and the shaders, which are executed on the GPU.</span></span> <span data-ttu-id="be298-127">シェーダーはコンパイルされ (またはコンパイル済みのソースから読み込まれ)、プログラムに関連付けられることで、GPU で実行できるようになります。</span><span class="sxs-lookup"><span data-stu-id="be298-127">Shaders are compiled (or loaded from compiled sources) and associated with a program, which enables execution on the GPU.</span></span>

<span data-ttu-id="be298-128">OpenGL ES 2.0: シェーダー プログラムへの頂点シェーダーとフラグメント シェーダーの読み込み</span><span class="sxs-lookup"><span data-stu-id="be298-128">OpenGL ES 2.0: Loading the vertex and fragment shaders into a shading program</span></span>

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

<span data-ttu-id="be298-129">Direct3D には、シェーダー プログラム オブジェクトという概念がありません。</span><span class="sxs-lookup"><span data-stu-id="be298-129">Direct3D does not have the concept of a shader program object.</span></span> <span data-ttu-id="be298-130">そのため、シェーダーは、[**ID3D11Device**](https://msdn.microsoft.com/library/windows/desktop/ff476379) インターフェイスでいずれかのシェーダー作成メソッド ([**ID3D11Device::CreateVertexShader**](https://msdn.microsoft.com/library/windows/desktop/ff476524) や [**ID3D11Device::CreatePixelShader**](https://msdn.microsoft.com/library/windows/desktop/ff476513) など) が呼び出されたときに作成されます。</span><span class="sxs-lookup"><span data-stu-id="be298-130">Rather, the shaders are created when one of the shader creation methods on the [**ID3D11Device**](https://msdn.microsoft.com/library/windows/desktop/ff476379) interface (such as [**ID3D11Device::CreateVertexShader**](https://msdn.microsoft.com/library/windows/desktop/ff476524) or [**ID3D11Device::CreatePixelShader**](https://msdn.microsoft.com/library/windows/desktop/ff476513)) is called.</span></span> <span data-ttu-id="be298-131">現在の描画コンテキストのシェーダーを設定するには、シェーダー設定メソッド (頂点シェーダーの [**ID3D11DeviceContext::VSSetShader**](https://msdn.microsoft.com/library/windows/desktop/ff476493) やフラグメント シェーダーの [**ID3D11DeviceContext::PSSetShader**](https://msdn.microsoft.com/library/windows/desktop/ff476472) など) を使って、シェーダーを対応する [**ID3D11DeviceContext**](https://msdn.microsoft.com/library/windows/desktop/ff476385) に渡します。</span><span class="sxs-lookup"><span data-stu-id="be298-131">To set the shaders for the current drawing context, we provide them to corresponding [**ID3D11DeviceContext**](https://msdn.microsoft.com/library/windows/desktop/ff476385) with a set shader method, such as [**ID3D11DeviceContext::VSSetShader**](https://msdn.microsoft.com/library/windows/desktop/ff476493) for the vertex shader or [**ID3D11DeviceContext::PSSetShader**](https://msdn.microsoft.com/library/windows/desktop/ff476472) for the fragment shader.</span></span>

<span data-ttu-id="be298-132">Direct3D 11: グラフィックス デバイスの描画コンテキストのシェーダーの設定</span><span class="sxs-lookup"><span data-stu-id="be298-132">Direct3D 11: Set the shaders for the graphics device drawing context.</span></span>

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

### <a name="step-3-define-the-data-to-supply-to-the-shaders"></a><span data-ttu-id="be298-133">手順 3: シェーダーに渡すデータの定義</span><span class="sxs-lookup"><span data-stu-id="be298-133">Step 3: Define the data to supply to the shaders</span></span>

<span data-ttu-id="be298-134">OpenGL ES 2.0 の例では、シェーダー パイプラインに対して宣言する次の **uniform** が 1 つあります。</span><span class="sxs-lookup"><span data-stu-id="be298-134">In our OpenGL ES 2.0 example, we have one **uniform** to declare for the shader pipeline:</span></span>

-   <span data-ttu-id="be298-135">**u\_mvpMatrix**: 立方体のモデル座標を受け取り、それをスキャン変換のために 2D プロジェクション座標に変換する最終的なモデル ビュー プロジェクション変換マトリックスを表す浮動小数点値の 4x4 配列。</span><span class="sxs-lookup"><span data-stu-id="be298-135">**u\_mvpMatrix**: a 4x4 array of floats that represents the final model-view-projection transformation matrix that takes the model coordinates for the cube and transforms them into 2D projection coordinates for scan conversion.</span></span>

<span data-ttu-id="be298-136">さらに、頂点データ用の次の **attribute** 値が 2 つあります。</span><span class="sxs-lookup"><span data-stu-id="be298-136">And two **attribute** values for the vertex data:</span></span>

-   <span data-ttu-id="be298-137">**a\_position**: 頂点のモデル座標の 4 つの浮動小数点値で構成されたベクトル。</span><span class="sxs-lookup"><span data-stu-id="be298-137">**a\_position**: a 4-float vector for the model coordinates of a vertex.</span></span>
-   <span data-ttu-id="be298-138">**a\_color**: 頂点に関連付けられている RGBA カラー値の 4 つの浮動小数点値で構成されたベクトル。</span><span class="sxs-lookup"><span data-stu-id="be298-138">**a\_color**: A 4-float vector for the RGBA color value associated with the vertex.</span></span>

<span data-ttu-id="be298-139">OpenGL ES 2.0: GLSL での uniform と attribute の定義</span><span class="sxs-lookup"><span data-stu-id="be298-139">Open GL ES 2.0: GLSL definitions for the uniforms and attributes</span></span>

``` syntax
uniform mat4 u_mvpMatrix;
attribute vec4 a_position;
attribute vec4 a_color;
```

<span data-ttu-id="be298-140">この場合は、対応するメイン プログラムの変数をレンダラー オブジェクトのフィールドとして定義します </span><span class="sxs-lookup"><span data-stu-id="be298-140">The corresponding main program variables are defined as fields on the renderer object, in this case.</span></span> <span data-ttu-id="be298-141">(「[簡単な OpenGL ES 2.0 レンダラーを Direct3D 11 に移植する方法](port-a-simple-opengl-es-2-0-renderer-to-directx-11-1.md)」の見出しをご覧ください)。定義したら、メイン プログラムでシェーダー パイプラインにこれらの値を渡すメモリ内の場所を指定する必要があります。これは、通常、描画呼び出しの直前に行います。</span><span class="sxs-lookup"><span data-stu-id="be298-141">(Refer to the header in [How to: port a simple OpenGL ES 2.0 renderer to Direct3D 11](port-a-simple-opengl-es-2-0-renderer-to-directx-11-1.md).) Once we've done that, we need to specify the locations in memory where the main program will supply these values for the shader pipeline, which we typically do right before a draw call:</span></span>

<span data-ttu-id="be298-142">OpenGL ES 2.0: uniform データと attribute データの場所のマーキング</span><span class="sxs-lookup"><span data-stu-id="be298-142">OpenGL ES 2.0: Marking the location of the uniform and attribute data</span></span>

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

<span data-ttu-id="be298-143">Direct3D には、同じ意味での "attribute" と "uniform" の概念がありません (または、少なくともこの構文を共有しません)。</span><span class="sxs-lookup"><span data-stu-id="be298-143">Direct3D does not have the concept of an "attribute" or a "uniform" in the same sense (or, at least, it does not share this syntax).</span></span> <span data-ttu-id="be298-144">その代わり、Direct3D サブリソースとして表される定数バッファーがあります。これは、メイン プログラムとシェーダー プログラムの間で共有されるリソースです。</span><span class="sxs-lookup"><span data-stu-id="be298-144">Rather, it has constant buffers, represented as Direct3D subresources -- resources that are shared between the main program and the shader programs.</span></span> <span data-ttu-id="be298-145">頂点の位置や色など、これらのサブリソースの一部は HLSL セマンティクスと呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="be298-145">Some of these subresources, such as vertex positions and colors, are described as HLSL semantics.</span></span> <span data-ttu-id="be298-146">OpenGL ES 2.0 の概念に関連する定数バッファーと HLSL セマンティクスについて詳しくは、「[OpenGL ES 2.0 のバッファー、uniform、頂点 attribute と Direct3D の比較](porting-uniforms-and-attributes.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="be298-146">For more info on constant buffers and HLSL semantics as they relate to OpenGL ES 2.0 concepts, read [Port frame buffer objects, uniforms, and attributes](porting-uniforms-and-attributes.md).</span></span>

<span data-ttu-id="be298-147">このプロセスを Direct3D に移行する場合は、uniform を Direct3D の定数バッファー (cbuffer) に変換し、**register** HLSL セマンティクスを使って、検索のために cbuffer をレジスタに割り当てます。</span><span class="sxs-lookup"><span data-stu-id="be298-147">When moving this process to Direct3D, we convert the uniform to a Direct3D constant buffer (cbuffer) and assign it a register for lookup with the **register** HLSL semantic.</span></span> <span data-ttu-id="be298-148">2 つの頂点 attribute はシェーダー パイプライン ステージの入力要素として処理され、シェーダーに通知する [HLSL セマンティクス](https://msdn.microsoft.com/library/windows/desktop/bb205574) (POSITION と COLOR0) が割り当てられます。</span><span class="sxs-lookup"><span data-stu-id="be298-148">The two vertex attributes are handled as input elements to the shader pipeline stages, and are also assigned [HLSL semantics](https://msdn.microsoft.com/library/windows/desktop/bb205574) (POSITION and COLOR0) that inform the shaders.</span></span> <span data-ttu-id="be298-149">ピクセル シェーダーは、GPU によって生成されたシステム値であることを示す SV\_ プレフィックスが付いている SV\_POSITION を受け取ります </span><span class="sxs-lookup"><span data-stu-id="be298-149">The pixel shader takes an SV\_POSITION, with the SV\_ prefix indicating that it is a system value generated by the GPU.</span></span> <span data-ttu-id="be298-150">(この場合は、スキャン変換時に生成されたピクセルの位置です)。VertexShaderInput と PixelShaderInput は定数バッファーとして宣言しません。これは、VertexShaderInput は頂点バッファーを定義するために使い (「[頂点バッファーと頂点データの移植](port-the-vertex-buffers-and-data-config.md)」をご覧ください)、PixelShaderInput のデータはパイプラインの前のステージ (この場合は頂点シェーダー) の結果として生成されるためです。</span><span class="sxs-lookup"><span data-stu-id="be298-150">(In this case, it is a pixel position generated during scan conversion.) VertexShaderInput and PixelShaderInput are not declared as constant buffers because the former will be used to define the vertex buffer (see [Port the vertex buffers and data](port-the-vertex-buffers-and-data-config.md)), and the data for the latter is generated as the result of a previous stage in the pipeline, which in this case is the vertex shader.</span></span>

<span data-ttu-id="be298-151">Direct3D: HLSL での定数バッファーと頂点データの定義</span><span class="sxs-lookup"><span data-stu-id="be298-151">Direct3D: HLSL definitions for the constant buffers and vertex data</span></span>

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

<span data-ttu-id="be298-152">定数バッファーへの移植と HLSL セマンティクスの利用について詳しくは、「[OpenGL ES 2.0 のバッファー、uniform、頂点 attribute と Direct3D の比較](porting-uniforms-and-attributes.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="be298-152">For more info on porting to constant buffers and the application of HLSL semantics, read [Port frame buffer objects, uniforms, and attributes](porting-uniforms-and-attributes.md).</span></span>

<span data-ttu-id="be298-153">定数バッファーまたは頂点バッファーを使ってシェーダー パイプラインに渡されるデータのレイアウトの構造体を次に示します。</span><span class="sxs-lookup"><span data-stu-id="be298-153">Here are the structures for the layout of the data passed to the shader pipeline with a constant or vertex buffer.</span></span>

<span data-ttu-id="be298-154">Direct3D 11: 定数バッファーと頂点バッファーのレイアウトの宣言</span><span class="sxs-lookup"><span data-stu-id="be298-154">Direct3D 11: Declaring the constant and vertex buffers layout</span></span>

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

<span data-ttu-id="be298-155">定数バッファー要素には DirectXMath XM\* 型を使っています。これにより、シェーダー パイプラインに送信する際に、コンテンツのパッキングとアラインメントが適切に行われます。</span><span class="sxs-lookup"><span data-stu-id="be298-155">Use the DirectXMath XM\* types for your constant buffer elements, since they provide proper packing and alignment for the contents when they are sent to the shader pipeline.</span></span> <span data-ttu-id="be298-156">Windows プラットフォームの標準の浮動小数点型と配列を使う場合は、手動でパッキングとアラインメントを実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="be298-156">If you use standard Windows platform float types and arrays, you must perform the packing and alignment yourself.</span></span>

<span data-ttu-id="be298-157">定数バッファーをバインドするために、レイアウトの記述を [**CD3D11\_BUFFER\_DESC**](https://msdn.microsoft.com/library/windows/desktop/jj151620) 構造体として作成し、[**ID3DDevice::CreateBuffer**](https://msdn.microsoft.com/library/windows/desktop/ff476501) に渡します。</span><span class="sxs-lookup"><span data-stu-id="be298-157">To bind a constant buffer, create a layout description as a [**CD3D11\_BUFFER\_DESC**](https://msdn.microsoft.com/library/windows/desktop/jj151620) structure, and pass it to [**ID3DDevice::CreateBuffer**](https://msdn.microsoft.com/library/windows/desktop/ff476501).</span></span> <span data-ttu-id="be298-158">次に、レンダリング メソッドで、定数バッファーを [**ID3D11DeviceContext::UpdateSubresource**](https://msdn.microsoft.com/library/windows/desktop/ff476486) に渡してから、描画します。</span><span class="sxs-lookup"><span data-stu-id="be298-158">Then, in your render method, pass the constant buffer to [**ID3D11DeviceContext::UpdateSubresource**](https://msdn.microsoft.com/library/windows/desktop/ff476486) before drawing.</span></span>

<span data-ttu-id="be298-159">Direct3D 11: 定数バッファーのバインド</span><span class="sxs-lookup"><span data-stu-id="be298-159">Direct3D 11: Bind the constant buffer</span></span>

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

<span data-ttu-id="be298-160">同じように頂点バッファーを作成して更新します。これについては、次の手順の「[頂点バッファーと頂点データの移植](port-the-vertex-buffers-and-data-config.md)」で説明します。</span><span class="sxs-lookup"><span data-stu-id="be298-160">The vertex buffer is created and updated similarly, and is discussed in the next step, [Port the vertex buffers and data](port-the-vertex-buffers-and-data-config.md).</span></span>

<a name="next-step"></a><span data-ttu-id="be298-161">次の手順</span><span class="sxs-lookup"><span data-stu-id="be298-161">Next step</span></span>
---------

[<span data-ttu-id="be298-162">頂点バッファーと頂点データの移植</span><span class="sxs-lookup"><span data-stu-id="be298-162">Port the vertex buffers and data</span></span>](port-the-vertex-buffers-and-data-config.md)
## <a name="related-topics"></a><span data-ttu-id="be298-163">関連トピック</span><span class="sxs-lookup"><span data-stu-id="be298-163">Related topics</span></span>


[<span data-ttu-id="be298-164">簡単な OpenGL ES 2.0 レンダラーを Direct3D 11 に移植する方法</span><span class="sxs-lookup"><span data-stu-id="be298-164">How to: port a simple OpenGL ES 2.0 renderer to Direct3D 11</span></span>](port-a-simple-opengl-es-2-0-renderer-to-directx-11-1.md)

[<span data-ttu-id="be298-165">頂点バッファーと頂点データの移植</span><span class="sxs-lookup"><span data-stu-id="be298-165">Port the vertex buffers and data</span></span>](port-the-vertex-buffers-and-data-config.md)

[<span data-ttu-id="be298-166">GLSL の移植</span><span class="sxs-lookup"><span data-stu-id="be298-166">Port the GLSL</span></span>](port-the-glsl.md)

[<span data-ttu-id="be298-167">画面への描画</span><span class="sxs-lookup"><span data-stu-id="be298-167">Draw to the screen</span></span>](draw-to-the-screen.md)

 

 




