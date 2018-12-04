---
title: 簡単な OpenGL ES 2.0 レンダラーの Direct3D 11 への移植
description: 最初の移植作業では、基本から始めます。Visual Studio 2015 の DirectX 11 アプリ (ユニバーサル Windows) テンプレートに対応するように、頂点シェーディングされた回転する立方体の簡単なレンダラーを OpenGL ES 2.0 から Direct3D に移植します。
ms.assetid: e7f6fa41-ab05-8a1e-a154-704834e72e6d
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, OpenGL, Direct3D 11, 移植
ms.localizationpriority: medium
ms.openlocfilehash: 78bcf3c2cae53fba4e67ecd4b3bcc44adddde1bf
ms.sourcegitcommit: b4c502d69a13340f6e3c887aa3c26ef2aeee9cee
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/03/2018
ms.locfileid: "8475664"
---
# <a name="port-a-simple-opengl-es-20-renderer-to-direct3d-11"></a><span data-ttu-id="ea312-104">簡単な OpenGL ES 2.0 レンダラーの Direct3D 11 への移植</span><span class="sxs-lookup"><span data-stu-id="ea312-104">Port a simple OpenGL ES 2.0 renderer to Direct3D 11</span></span>



<span data-ttu-id="ea312-105">この移植作業では、基本から始めます。Visual Studio 2015 の DirectX 11 アプリ (ユニバーサル Windows) テンプレートに対応するように、頂点シェーディングされた回転する立方体の簡単なレンダラーを OpenGL ES 2.0 から Direct3D に移植します。</span><span class="sxs-lookup"><span data-stu-id="ea312-105">For this porting exercise, we'll start with the basics: bringing a simple renderer for a spinning, vertex-shaded cube from OpenGL ES 2.0 into Direct3D, such that it matches the DirectX 11 App (Universal Windows) template from Visual Studio 2015.</span></span> <span data-ttu-id="ea312-106">この移植プロセスでは、次について説明します。</span><span class="sxs-lookup"><span data-stu-id="ea312-106">As we walk through this port process, you will learn the following:</span></span>

-   <span data-ttu-id="ea312-107">一連の簡単な頂点バッファーを Direct3D の入力バッファーに移植する方法</span><span class="sxs-lookup"><span data-stu-id="ea312-107">How to port a simple set of vertex buffers to Direct3D input buffers</span></span>
-   <span data-ttu-id="ea312-108">uniform と attribute を定数バッファーに移植する方法</span><span class="sxs-lookup"><span data-stu-id="ea312-108">How to port uniforms and attributes to constant buffers</span></span>
-   <span data-ttu-id="ea312-109">Direct3D のシェーダー オブジェクトを構成する方法</span><span class="sxs-lookup"><span data-stu-id="ea312-109">How to configure Direct3D shader objects</span></span>
-   <span data-ttu-id="ea312-110">Direct3D のシェーダー開発で基本的な HLSL セマンティクスを使う方法</span><span class="sxs-lookup"><span data-stu-id="ea312-110">How basic HLSL semantics are used in Direct3D shader development</span></span>
-   <span data-ttu-id="ea312-111">非常に簡単な GLSL を HLSL に移植する方法</span><span class="sxs-lookup"><span data-stu-id="ea312-111">How to port very simple GLSL to HLSL</span></span>

<span data-ttu-id="ea312-112">このトピックは、新しい DirectX 11 プロジェクトを作成したところから始まります。</span><span class="sxs-lookup"><span data-stu-id="ea312-112">This topic starts after you have created a new DirectX 11 project.</span></span> <span data-ttu-id="ea312-113">新しい DirectX 11 プロジェクトを作成する方法については、「[テンプレートからの DirectX ゲーム プロジェクトの作成](user-interface.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ea312-113">To learn how to create a new DirectX 11 project, read [Create a new DirectX 11 project for Universal Windows Platform (UWP)](user-interface.md).</span></span>

<span data-ttu-id="ea312-114">これらのリンクのどちらかから作成されたプロジェクトには [Direct3D](https://msdn.microsoft.com/library/windows/desktop/ff476345) インフラストラクチャ用のコードがすべて用意されているため、OpenGL ES 2.0 から Direct3D 11 にレンダラーを移植するプロセスをすぐに始めることができます。</span><span class="sxs-lookup"><span data-stu-id="ea312-114">The project created from either of these links has all the code for the [Direct3D](https://msdn.microsoft.com/library/windows/desktop/ff476345) infrastructure prepared, and you can immediately start into the process of porting your renderer from Open GL ES 2.0 to Direct3D 11.</span></span>

<span data-ttu-id="ea312-115">このトピックでは、2 つのコード パスについて説明します。どちらも同じ基本的なグラフィックス タスクを実行します。頂点シェーディングされた回転する立方体をウィンドウに表示するというものです。</span><span class="sxs-lookup"><span data-stu-id="ea312-115">This topic walks two code paths that perform the same basic graphics task: display a rotating vertex-shaded cube in a window.</span></span> <span data-ttu-id="ea312-116">どちらの場合も、コードは次のプロセスに対応しています。</span><span class="sxs-lookup"><span data-stu-id="ea312-116">In both cases, the code covers the following process:</span></span>

1.  <span data-ttu-id="ea312-117">ハードコードされたデータから立方体のメッシュを作成する。</span><span class="sxs-lookup"><span data-stu-id="ea312-117">Creating a cube mesh from hardcoded data.</span></span> <span data-ttu-id="ea312-118">このメッシュは頂点の一覧として表され、各頂点では位置、法線ベクトル、色ベクトルを処理します。</span><span class="sxs-lookup"><span data-stu-id="ea312-118">This mesh is represented as a list of vertices, with each vertex possessing a position, a normal vector, and a color vector.</span></span> <span data-ttu-id="ea312-119">シェーディング パイプラインで処理するためにこのメッシュを頂点バッファーに配置します。</span><span class="sxs-lookup"><span data-stu-id="ea312-119">This mesh is put into a vertex buffer for the shading pipeline to process.</span></span>
2.  <span data-ttu-id="ea312-120">立方体のメッシュを処理するシェーダー オブジェクトを作成する。</span><span class="sxs-lookup"><span data-stu-id="ea312-120">Creating shader objects to process the cube mesh.</span></span> <span data-ttu-id="ea312-121">シェーダーは 2 つあります。1 つはラスタライズのために頂点を処理する頂点シェーダーで、もう 1 つはラスタライズ後に立方体の個々のピクセルに色を設定するフラグメント (ピクセル) シェーダーです。</span><span class="sxs-lookup"><span data-stu-id="ea312-121">There are two shaders: a vertex shader that processes the vertices for rasterization, and a fragment (pixel) shader that colors the individual pixels of the cube after rasterization.</span></span> <span data-ttu-id="ea312-122">これらのピクセルは、表示のためにレンダー ターゲットに書き込まれます。</span><span class="sxs-lookup"><span data-stu-id="ea312-122">These pixels are written into a render target for display.</span></span>
3.  <span data-ttu-id="ea312-123">頂点シェーダーとフラグメント シェーダーでそれぞれ処理する頂点とピクセルに使われるシェーダー言語を構成する。</span><span class="sxs-lookup"><span data-stu-id="ea312-123">Forming the shading language that is used for vertex and pixel processing in the vertex and fragment shaders, respectively.</span></span>
4.  <span data-ttu-id="ea312-124">レンダリングされた立方体を画面に表示する。</span><span class="sxs-lookup"><span data-stu-id="ea312-124">Displaying the rendered cube on the screen.</span></span>

![OpenGL の単純な立方体](images/simple-opengl-cube.png)

<span data-ttu-id="ea312-126">このチュートリアルを終了すると、OpenGL ES 2.0 と Direct3D 11 の次の基本的な違いを理解できます。</span><span class="sxs-lookup"><span data-stu-id="ea312-126">Upon completing this walkthrough, you should be familiar with the following basic differences between Open GL ES 2.0 and Direct3D 11:</span></span>

-   <span data-ttu-id="ea312-127">頂点バッファーと頂点データの表現。</span><span class="sxs-lookup"><span data-stu-id="ea312-127">The representation of vertex buffers and vertex data.</span></span>
-   <span data-ttu-id="ea312-128">シェーダーを作成して構成するプロセス。</span><span class="sxs-lookup"><span data-stu-id="ea312-128">The process of creating and configuring shaders.</span></span>
-   <span data-ttu-id="ea312-129">シェーダー言語と、シェーダー オブジェクトに対する入力と出力。</span><span class="sxs-lookup"><span data-stu-id="ea312-129">Shading languages, and the inputs and outputs to shader objects.</span></span>
-   <span data-ttu-id="ea312-130">画面の描画動作。</span><span class="sxs-lookup"><span data-stu-id="ea312-130">Screen drawing behaviors.</span></span>

<span data-ttu-id="ea312-131">このチュートリアルでは、次のように定義される簡単で一般的な OpenGL レンダラーの構造体を参照します。</span><span class="sxs-lookup"><span data-stu-id="ea312-131">In this walkthrough, we refer to an simple and generic OpenGL renderer structure, which is defined like this:</span></span>

``` syntax
typedef struct 
{
    GLfloat pos[3];        
    GLfloat rgba[4];
} Vertex;

typedef struct
{
  // Integer handle to the shader program object.
  GLuint programObject;

  // The vertex and index buffers
  GLuint vertexBuffer;
  GLuint indexBuffer;

  // Handle to the location of model-view-projection matrix uniform
  GLint  mvpLoc; 
   
  // Vertex and index data
  Vertex  *vertices;
  GLuint   *vertexIndices;
  int       numIndices;

  // Rotation angle used for animation
  GLfloat   angle;

  GLfloat  mvpMatrix[4][4]; // the model-view-projection matrix itself
} Renderer;
```

<span data-ttu-id="ea312-132">この構造体には、インスタンスが 1 つあり、頂点シェーディングされた非常に簡単なメッシュをレンダリングするために必要なコンポーネントがすべて含まれています。</span><span class="sxs-lookup"><span data-stu-id="ea312-132">This structure has one instance and contains all the necessary components for rendering a very simple vertex-shaded mesh.</span></span>

> <span data-ttu-id="ea312-133">**注:** このトピックの OpenGL ES 2.0 コードは、Khronos Group によって提供される Windows API の実装に基づいてし、Windows C プログラミング構文を使用します。</span><span class="sxs-lookup"><span data-stu-id="ea312-133">**Note**Any OpenGL ES 2.0 code in this topic is based on the Windows API implementation provided by the Khronos Group, and uses Windows C programming syntax.</span></span>

 

## <a name="what-you-need-to-know"></a><span data-ttu-id="ea312-134">理解しておく必要があること</span><span class="sxs-lookup"><span data-stu-id="ea312-134">What you need to know</span></span>


### <a name="technologies"></a><span data-ttu-id="ea312-135">テクノロジ</span><span class="sxs-lookup"><span data-stu-id="ea312-135">Technologies</span></span>

-   [<span data-ttu-id="ea312-136">Microsoft Visual C++</span><span class="sxs-lookup"><span data-stu-id="ea312-136">Microsoft Visual C++</span></span>](http://msdn.microsoft.com/library/vstudio/60k1461a.aspx)
-   <span data-ttu-id="ea312-137">OpenGL ES 2.0</span><span class="sxs-lookup"><span data-stu-id="ea312-137">OpenGL ES 2.0</span></span>

### <a name="prerequisites"></a><span data-ttu-id="ea312-138">前提条件</span><span class="sxs-lookup"><span data-stu-id="ea312-138">Prerequisites</span></span>

-   <span data-ttu-id="ea312-139">省略可能です。</span><span class="sxs-lookup"><span data-stu-id="ea312-139">Optional.</span></span> <span data-ttu-id="ea312-140">「[DXGI と Direct3D の EGL コードの比較](moving-from-egl-to-dxgi.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ea312-140">Review [Port EGL code to DXGI and Direct3D](moving-from-egl-to-dxgi.md).</span></span> <span data-ttu-id="ea312-141">このトピックを読むと、DirectX によって提供されるグラフィックス インターフェイスについて理解を深めることができます。</span><span class="sxs-lookup"><span data-stu-id="ea312-141">Read this topic to better understand the graphics interface provided by DirectX.</span></span>

## <a name="span-idkeylinksstepsheadingspansteps"></a><span data-ttu-id="ea312-142"><span id="keylinks_steps_heading"></span>ステップ</span><span class="sxs-lookup"><span data-stu-id="ea312-142"><span id="keylinks_steps_heading"></span>Steps</span></span>


<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="ea312-143">トピック</span><span class="sxs-lookup"><span data-stu-id="ea312-143">Topic</span></span></th>
<th align="left"><span data-ttu-id="ea312-144">説明</span><span class="sxs-lookup"><span data-stu-id="ea312-144">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><a href="port-the-shader-config.md"><span data-ttu-id="ea312-145">シェーダー オブジェクトの移植</span><span class="sxs-lookup"><span data-stu-id="ea312-145">Port the shader objects</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="ea312-146">OpenGL ES 2.0 から簡単なレンダラーを移植する場合、最初の手順では、Direct3D 11 の対応する頂点シェーダー オブジェクトとフラグメント シェーダー オブジェクトを設定し、コンパイル後にメイン プログラムがシェーダー オブジェクトと通信できるようにします。</span><span class="sxs-lookup"><span data-stu-id="ea312-146">When porting the simple renderer from OpenGL ES 2.0, the first step is to set up the equivalent vertex and fragment shader objects in Direct3D 11, and to make sure that the main program can communicate with the shader objects after they are compiled.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="port-the-vertex-buffers-and-data-config.md"><span data-ttu-id="ea312-147">頂点バッファーと頂点データの移植</span><span class="sxs-lookup"><span data-stu-id="ea312-147">Port the vertex buffers and data</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="ea312-148">この手順では、シェーダーが指定された順番で頂点を走査できるようにするインデックス バッファーとメッシュを格納する頂点バッファーを定義します。</span><span class="sxs-lookup"><span data-stu-id="ea312-148">In this step, you'll define the vertex buffers that will contain your meshes and the index buffers that allow the shaders to traverse the vertices in a specified order.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="port-the-glsl.md"><span data-ttu-id="ea312-149">GLSL の移植</span><span class="sxs-lookup"><span data-stu-id="ea312-149">Port the GLSL</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="ea312-150">バッファーとシェーダー オブジェクトを作成して構成するコードが完成したら、それらのシェーダー内のコードを OpenGL ES 2.0 の GL シェーダー言語 (GLSL) から Direct3D 11 の上位レベル シェーダー言語 (HLSL) に移植します。</span><span class="sxs-lookup"><span data-stu-id="ea312-150">Once you've moved over the code that creates and configures your buffers and shader objects, it's time to port the code inside those shaders from OpenGL ES 2.0's GL Shader Language (GLSL) to Direct3D 11's High-level Shader Language (HLSL).</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="draw-to-the-screen.md"><span data-ttu-id="ea312-151">画面への描画</span><span class="sxs-lookup"><span data-stu-id="ea312-151">Draw to the screen</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="ea312-152">最後に、回転する立方体を画面に描画するコードを移植します。</span><span class="sxs-lookup"><span data-stu-id="ea312-152">Finally, we port the code that draws the spinning cube to the screen.</span></span></p></td>
</tr>
</tbody>
</table>

 

## <a name="span-idadditionalresourcesspanadditional-resources"></a><span data-ttu-id="ea312-153"><span id="additional_resources"></span>その他の情報</span><span class="sxs-lookup"><span data-stu-id="ea312-153"><span id="additional_resources"></span>Additional resources</span></span>


-   [<span data-ttu-id="ea312-154">UWP DirectX ゲーム プログラミング環境の準備</span><span class="sxs-lookup"><span data-stu-id="ea312-154">Prepare your dev environment for UWP DirectX game development</span></span>](prepare-your-dev-environment-for-windows-store-directx-game-development.md)
-   [<span data-ttu-id="ea312-155">テンプレートからの DirectX ゲーム プロジェクトの作成</span><span class="sxs-lookup"><span data-stu-id="ea312-155">Create a new DirectX 11 project for UWP</span></span>](user-interface.md)
-   [<span data-ttu-id="ea312-156">Direct3D 11 への OpenGL ES 2.0 のマッピング</span><span class="sxs-lookup"><span data-stu-id="ea312-156">Map OpenGL ES 2.0 concepts and infrastructure to Direct3D 11</span></span>](map-concepts-and-infrastructure.md)

 

 




