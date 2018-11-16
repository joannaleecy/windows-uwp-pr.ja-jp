---
author: mtoepke
title: 基本的なメッシュの作成と表示
description: 3-D のユニバーサル Windows プラットフォーム (UWP) ゲームでは、通常は多角形を使ってゲーム内のオブジェクトやサーフェスを表現します。
ms.assetid: bfe0ed5b-63d8-935b-a25b-378b36982b7d
ms.author: mtoepke
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10、UWP、ゲーム、メッシュ、DirectX
ms.localizationpriority: medium
ms.openlocfilehash: e3ae6416217efa16d70b65b8ff55e36654a11557
ms.sourcegitcommit: e2fca6c79f31e521ba76f7ecf343cf8f278e6a15
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/15/2018
ms.locfileid: "6971379"
---
# <a name="create-and-display-a-basic-mesh"></a><span data-ttu-id="b1865-104">基本的なメッシュの作成と表示</span><span class="sxs-lookup"><span data-stu-id="b1865-104">Create and display a basic mesh</span></span>



<span data-ttu-id="b1865-105">3-D のユニバーサル Windows プラットフォーム (UWP) ゲームでは、通常は多角形を使ってゲーム内のオブジェクトやサーフェスを表現します。</span><span class="sxs-lookup"><span data-stu-id="b1865-105">3-D Universal Windows Platform (UWP) games typically use polygons to represent objects and surfaces in the game.</span></span> <span data-ttu-id="b1865-106">そのような多角形によるオブジェクトやサーフェスの構造を構成する頂点のリストをメッシュと呼びます。</span><span class="sxs-lookup"><span data-stu-id="b1865-106">The lists of vertices that comprise the structure of these polygonal objects and surfaces are called meshes.</span></span> <span data-ttu-id="b1865-107">ここでは、立方体オブジェクトの基本的なメッシュを作り、シェーダー パイプラインに渡してレンダリングと表示を行います。</span><span class="sxs-lookup"><span data-stu-id="b1865-107">Here, we create a basic mesh for a cube object and provide it to the shader pipeline for rendering and display.</span></span>

> <span data-ttu-id="b1865-108">**重要な**含まれているコードの例は、ここで (directx::xmfloat3:xmfloat4x4 など) の型と DirectXMath.h で宣言されているインライン メソッドに使用します。</span><span class="sxs-lookup"><span data-stu-id="b1865-108">**Important** The example code included here uses types (such as DirectX::XMFLOAT3 and DirectX::XMFLOAT4X4) and inline methods declared in DirectXMath.h.</span></span> <span data-ttu-id="b1865-109">このコードを切り取って貼り付ける場合は、プロジェクトに \#include &lt;DirectXMath.h&gt; を含めてください。</span><span class="sxs-lookup"><span data-stu-id="b1865-109">If you're cutting and pasting this code, \#include &lt;DirectXMath.h&gt; in your project.</span></span>

 

## <a name="what-you-need-to-know"></a><span data-ttu-id="b1865-110">理解しておく必要があること</span><span class="sxs-lookup"><span data-stu-id="b1865-110">What you need to know</span></span>


### <a name="technologies"></a><span data-ttu-id="b1865-111">テクノロジ</span><span class="sxs-lookup"><span data-stu-id="b1865-111">Technologies</span></span>

-   [<span data-ttu-id="b1865-112">Direct3D</span><span class="sxs-lookup"><span data-stu-id="b1865-112">Direct3D</span></span>](https://msdn.microsoft.com/library/windows/desktop/hh769064)

### <a name="prerequisites"></a><span data-ttu-id="b1865-113">前提条件</span><span class="sxs-lookup"><span data-stu-id="b1865-113">Prerequisites</span></span>

-   <span data-ttu-id="b1865-114">線形代数と 3-D 座標系の基本的な知識</span><span class="sxs-lookup"><span data-stu-id="b1865-114">Basic knowledge of linear algebra and 3-D coordinate systems</span></span>
-   <span data-ttu-id="b1865-115">Visual Studio 2015 またはそれ以降の Direct3D テンプレート</span><span class="sxs-lookup"><span data-stu-id="b1865-115">A Visual Studio 2015 or later Direct3D template</span></span>

## <a name="instructions"></a><span data-ttu-id="b1865-116">手順</span><span class="sxs-lookup"><span data-stu-id="b1865-116">Instructions</span></span>

<span data-ttu-id="b1865-117">次の手順では、基本的なメッシュ立方体を作成する方法を説明します。</span><span class="sxs-lookup"><span data-stu-id="b1865-117">These steps will show you how to create a basic mesh cube.</span></span> 


<span data-ttu-id="b1865-118">これらの概念の説明を聞くことを希望する場合には、このビデオをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b1865-118">If you prefer a talked-through explanation of these concepts, check out this video.</span></span>
</br>
</br>
<iframe src="https://channel9.msdn.com/Series/Introduction-to-C-and-DirectX-Game-Development/03/player#time=7m39s:paused" width="600" height="338" allowFullScreen frameBorder="0"></iframe>


### <a name="step-1-construct-the-mesh-for-the-model"></a><span data-ttu-id="b1865-119">手順 1: モデルのメッシュを構成する</span><span class="sxs-lookup"><span data-stu-id="b1865-119">Step 1: Construct the mesh for the model</span></span>

<span data-ttu-id="b1865-120">ほとんどのゲームでは、ゲーム オブジェクトのメッシュは特定の頂点データが含まれるファイルからロードされます。</span><span class="sxs-lookup"><span data-stu-id="b1865-120">In most games, the mesh for a game object is loaded from a file that contains the specific vertex data.</span></span> <span data-ttu-id="b1865-121">頂点の順序はアプリに依存していますが、通常は帯状または扇状にシリアル化されます。</span><span class="sxs-lookup"><span data-stu-id="b1865-121">The ordering of these vertices is app-dependent, but they are usually serialized as strips or fans.</span></span> <span data-ttu-id="b1865-122">頂点データは、ソフトウェア ソースからのものを使うことも、手動で作ることもできます。</span><span class="sxs-lookup"><span data-stu-id="b1865-122">Vertex data can come from any software source, or it can be created manually.</span></span> <span data-ttu-id="b1865-123">頂点シェーダーが効果的に処理できる方法でデータを解釈するかどうかはゲーム次第です。</span><span class="sxs-lookup"><span data-stu-id="b1865-123">It's up to your game to interpret the data in a way that the vertex shader can effectively process it.</span></span>

<span data-ttu-id="b1865-124">この例では、立方体用にシンプルなメッシュを使います。</span><span class="sxs-lookup"><span data-stu-id="b1865-124">In our example, we use a simple mesh for a cube.</span></span> <span data-ttu-id="b1865-125">立方体は、パイプラインのこの段階ではあらゆるオブジェクト メッシュと同様に、専用の座標系を使って表されます。</span><span class="sxs-lookup"><span data-stu-id="b1865-125">The cube, like any object mesh at this stage in the pipeline, is represented using its own coordinate system.</span></span> <span data-ttu-id="b1865-126">頂点シェーダーはその座標を使い、指定された変換マトリックスを適用して、同一座標系での最終的な 2-D ビュー プロジェクションを返します。</span><span class="sxs-lookup"><span data-stu-id="b1865-126">The vertex shader takes its coordinates and, by applying the transformation matrices you provide, returns the final 2-D view projection in a homogeneous coordinate system.</span></span>

<span data-ttu-id="b1865-127">立方体のメッシュを定義します。</span><span class="sxs-lookup"><span data-stu-id="b1865-127">Define the mesh for a cube.</span></span> <span data-ttu-id="b1865-128">(またはファイルからロードします。</span><span class="sxs-lookup"><span data-stu-id="b1865-128">(Or load it from a file.</span></span> <span data-ttu-id="b1865-129">決めるのはあなたです)</span><span class="sxs-lookup"><span data-stu-id="b1865-129">It's your call!)</span></span>

```cpp
SimpleCubeVertex cubeVertices[] =
{
    { DirectX::XMFLOAT3(-0.5f, 0.5f, -0.5f), DirectX::XMFLOAT3(0.0f, 1.0f, 0.0f) }, // +Y (top face)
    { DirectX::XMFLOAT3( 0.5f, 0.5f, -0.5f), DirectX::XMFLOAT3(1.0f, 1.0f, 0.0f) },
    { DirectX::XMFLOAT3( 0.5f, 0.5f,  0.5f), DirectX::XMFLOAT3(1.0f, 1.0f, 1.0f) },
    { DirectX::XMFLOAT3(-0.5f, 0.5f,  0.5f), DirectX::XMFLOAT3(0.0f, 1.0f, 1.0f) },

    { DirectX::XMFLOAT3(-0.5f, -0.5f,  0.5f), DirectX::XMFLOAT3(0.0f, 0.0f, 1.0f) }, // -Y (bottom face)
    { DirectX::XMFLOAT3( 0.5f, -0.5f,  0.5f), DirectX::XMFLOAT3(1.0f, 0.0f, 1.0f) },
    { DirectX::XMFLOAT3( 0.5f, -0.5f, -0.5f), DirectX::XMFLOAT3(1.0f, 0.0f, 0.0f) },
    { DirectX::XMFLOAT3(-0.5f, -0.5f, -0.5f), DirectX::XMFLOAT3(0.0f, 0.0f, 0.0f) },
};
```

<span data-ttu-id="b1865-130">立方体の座標系では立方体の中心が原点になり、Y 軸が上下を貫き、左手による座標系を使います。</span><span class="sxs-lookup"><span data-stu-id="b1865-130">The cube's coordinate system places the center of the cube at the origin, with the y-axis running top to bottom using a left-handed coordinate system.</span></span> <span data-ttu-id="b1865-131">座標値は、-1 ～ 1 の 32 ビット浮動小数点値で表されます。</span><span class="sxs-lookup"><span data-stu-id="b1865-131">Coordinate values are expressed as 32-bit floating values between -1 and 1.</span></span>

<span data-ttu-id="b1865-132">かっこ対ごとに 2 つ目の DirectX::XMFLOAT3 値グループは、頂点と関連付けられた色 (RGB 値) を指定します。</span><span class="sxs-lookup"><span data-stu-id="b1865-132">In each bracketed pairing, the second DirectX::XMFLOAT3 value group specifies the color associated with the vertex as an RGB value.</span></span> <span data-ttu-id="b1865-133">たとえば、(-0.5, 0.5, -0.5) にある 1 番目の頂点は、完全に緑色 (G 値が 1.0、R 値と B 値は 0 に設定) です。</span><span class="sxs-lookup"><span data-stu-id="b1865-133">For example, the first vertex at (-0.5, 0.5, -0.5) has a full green color (the G value is set to 1.0, and the "R" and "B" values are set to 0).</span></span>

<span data-ttu-id="b1865-134">最終的に 8 つの頂点があり、それぞれに特定の色が割り当てられています。</span><span class="sxs-lookup"><span data-stu-id="b1865-134">Therefore, you have 8 vertices, each with a specific color.</span></span> <span data-ttu-id="b1865-135">頂点/色の各ペアは、この例で使う頂点のフル データになっています。</span><span class="sxs-lookup"><span data-stu-id="b1865-135">Each vertex/color pairing is the complete data for a vertex in our example.</span></span> <span data-ttu-id="b1865-136">頂点バッファーを指定する場合は、この具体的なレイアウトを念頭に置いておく必要があります。</span><span class="sxs-lookup"><span data-stu-id="b1865-136">When you specify our vertex buffer, you must keep this specific layout in mind.</span></span> <span data-ttu-id="b1865-137">この入力レイアウトを頂点シェーダーに渡して、頂点データが頂点シェーダーで理解されるようにします。</span><span class="sxs-lookup"><span data-stu-id="b1865-137">We provide this input layout to the vertex shader so it can understand your vertex data.</span></span>

### <a name="step-2-set-up-the-input-layout"></a><span data-ttu-id="b1865-138">手順 2: 入力レイアウトを設定する</span><span class="sxs-lookup"><span data-stu-id="b1865-138">Step 2: Set up the input layout</span></span>

<span data-ttu-id="b1865-139">現在、頂点はメモリ内に取り込まれています。</span><span class="sxs-lookup"><span data-stu-id="b1865-139">Now, you have the vertices in memory.</span></span> <span data-ttu-id="b1865-140">ただし、グラフィックス デバイスには専用のメモリがあり、このメモリにアクセスするには Direct3D を使います。</span><span class="sxs-lookup"><span data-stu-id="b1865-140">But, your graphics device has its own memory, and you use Direct3D to access it.</span></span> <span data-ttu-id="b1865-141">頂点データをグラフィックス デバイスに取り込んで処理するには、言ってみればその方法を明らかにしておく必要があります。グラフィックス デバイスがゲームから頂点データを受け取ったときに解釈できるように、頂点データをどのように配置するのかを宣言しておく必要があるのです。</span><span class="sxs-lookup"><span data-stu-id="b1865-141">To get your vertex data into the graphics device for processing, you need to clear the way, as it were: you must declare how the vertex data is laid out so that the graphics device can interpret it when it gets it from your game.</span></span> <span data-ttu-id="b1865-142">それには、[**ID3D11InputLayout**](https://msdn.microsoft.com/library/windows/desktop/ff476575) を使います。</span><span class="sxs-lookup"><span data-stu-id="b1865-142">To do that, you use [**ID3D11InputLayout**](https://msdn.microsoft.com/library/windows/desktop/ff476575).</span></span>

<span data-ttu-id="b1865-143">頂点バッファー用に入力レイアウトを宣言し、設定します。</span><span class="sxs-lookup"><span data-stu-id="b1865-143">Declare and set the input layout for the vertex buffer.</span></span>

```cpp
const D3D11_INPUT_ELEMENT_DESC basicVertexLayoutDesc[] =
{
    { "POSITION", 0, DXGI_FORMAT_R32G32B32_FLOAT, 0,  0, D3D11_INPUT_PER_VERTEX_DATA, 0 },
    { "COLOR",    0, DXGI_FORMAT_R32G32B32_FLOAT, 0, 12, D3D11_INPUT_PER_VERTEX_DATA, 0 },
};

ComPtr<ID3D11InputLayout> inputLayout;
m_d3dDevice->CreateInputLayout(
                basicVertexLayoutDesc,
                ARRAYSIZE(basicVertexLayoutDesc),
                vertexShaderBytecode->Data,
                vertexShaderBytecode->Length,
                &inputLayout)
);
```

<span data-ttu-id="b1865-144">このコードでは、頂点のレイアウト、具体的には頂点リスト内の各要素に含まれるデータを指定します。</span><span class="sxs-lookup"><span data-stu-id="b1865-144">In this code, you specify a layout for the vertices, specifically, what data each element in the vertex list contains.</span></span> <span data-ttu-id="b1865-145">ここでは、**basicVertexLayoutDesc** で 2 つのデータ コンポーネントを指定します。</span><span class="sxs-lookup"><span data-stu-id="b1865-145">Here, in **basicVertexLayoutDesc**, you specify two data components:</span></span>

-   <span data-ttu-id="b1865-146">**POSITION**: これは、シェーダーに渡される位置データの HLSL セマンティックです。</span><span class="sxs-lookup"><span data-stu-id="b1865-146">**POSITION**: This is an HLSL semantic for position data provided to a shader.</span></span> <span data-ttu-id="b1865-147">このコードでは DirectX::XMFLOAT3、正確には 3D 座標 (x, y, z) に対応する 3 つの 32 ビット浮動小数点値を持つ構造です。</span><span class="sxs-lookup"><span data-stu-id="b1865-147">In this code, it's a DirectX::XMFLOAT3, or more specifically, a structure with 3 32-bit floating point values that correspond to a 3D coordinate (x, y, z).</span></span> <span data-ttu-id="b1865-148">統一された "w" 座標を提供する場合は (この例では DXGI\_FORMAT\_R32G32B32A32\_FLOAT を指定する場合は)、float4 を使うこともできます。</span><span class="sxs-lookup"><span data-stu-id="b1865-148">You could also use a float4 if you are supplying the homogeneous "w" coordinate, and in that case, you specify DXGI\_FORMAT\_R32G32B32A32\_FLOAT.</span></span> <span data-ttu-id="b1865-149">DirectX::XMFLOAT3 と float4 のどちらを使うのかは、ゲームの特定の必要性によって異なります。</span><span class="sxs-lookup"><span data-stu-id="b1865-149">Whether you use a DirectX::XMFLOAT3 or a float4 is up to the specific needs of your game.</span></span> <span data-ttu-id="b1865-150">メッシュの頂点データが、使う形式に正しく対応していることを確認してください。</span><span class="sxs-lookup"><span data-stu-id="b1865-150">Just make sure that the vertex data for your mesh corresponds correctly to the format you use!</span></span>

    <span data-ttu-id="b1865-151">各座標値は、オブジェクトの座標空間内で -1 ～ 1 の浮動小数点値で表されます。</span><span class="sxs-lookup"><span data-stu-id="b1865-151">Each coordinate value is expressed as a floating point value between -1 and 1, in the object's coordinate space.</span></span> <span data-ttu-id="b1865-152">頂点シェーダーが完了すると、変換された頂点は統一された (視点が修正された) ビュー プロジェクション空間内にあります。</span><span class="sxs-lookup"><span data-stu-id="b1865-152">When the vertex shader completes, the transformed vertex is in the homogeneous (perspective corrected) view projection space.</span></span>

    <span data-ttu-id="b1865-153">「でも、列挙値は、XYZ ではなく RGB を示しています。」</span><span class="sxs-lookup"><span data-stu-id="b1865-153">"But the enumeration value indicates RGB, not XYZ!"</span></span> <span data-ttu-id="b1865-154">ご指摘のとおりです。</span><span class="sxs-lookup"><span data-stu-id="b1865-154">you smartly note.</span></span> <span data-ttu-id="b1865-155">さすがです!</span><span class="sxs-lookup"><span data-stu-id="b1865-155">Good eye!</span></span> <span data-ttu-id="b1865-156">色データと座標データの両方で、通常は 3 つか 4 つの成分値を使います。それならば両方で同じ形式を使わないのはなぜなのでしょうか。</span><span class="sxs-lookup"><span data-stu-id="b1865-156">In both the cases of color data and coordinate data, you typically use 3 or 4 component values, so why not use the same format for both?</span></span> <span data-ttu-id="b1865-157">HLSL セマンティックは形式の名前ではなく、シェーダーがデータを扱う方法を表します。</span><span class="sxs-lookup"><span data-stu-id="b1865-157">The HLSL semantic, not the format name, indicates how the shader treats the data.</span></span>

-   <span data-ttu-id="b1865-158">**COLOR**: これは、色データの HLSL セマンティックです。</span><span class="sxs-lookup"><span data-stu-id="b1865-158">**COLOR**: This is an HLSL semantic for color data.</span></span> <span data-ttu-id="b1865-159">**POSITION** と同様に、3 つの 32 ビット浮動小数点値 (DirectX::XMFLOAT3) で構成されます。</span><span class="sxs-lookup"><span data-stu-id="b1865-159">Like **POSITION**, it consists of 3 32-bit floating point values (DirectX::XMFLOAT3).</span></span> <span data-ttu-id="b1865-160">それぞれの値は、0 ～ 1 の浮動小数点値で表される色成分の赤 (r)、青 (b)、または緑 (g) を含みます。</span><span class="sxs-lookup"><span data-stu-id="b1865-160">Each value contains a color component: red (r), blue (b), or green (g), expressed as a floating number between 0 and 1.</span></span>

    <span data-ttu-id="b1865-161">通常、**COLOR** の値は、シェーダー パイプラインの最後に 4 成分の RGBA 値として返されます。</span><span class="sxs-lookup"><span data-stu-id="b1865-161">**COLOR** values are typically returned as a 4-component RGBA value at the end of the shader pipeline.</span></span> <span data-ttu-id="b1865-162">この例では、すべてのピクセルについて、シェーダー パイプラインで "A" アルファ値を 1.0 (最大不透明度) に設定します。</span><span class="sxs-lookup"><span data-stu-id="b1865-162">For this example, you will be setting the "A" alpha value to 1.0 (maximum opacity) in the shader pipeline for all pixels.</span></span>

<span data-ttu-id="b1865-163">形式の全一覧については、[**DXGI\_FORMAT**](https://msdn.microsoft.com/library/windows/desktop/bb173059) をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b1865-163">For a complete list of formats, see [**DXGI\_FORMAT**](https://msdn.microsoft.com/library/windows/desktop/bb173059).</span></span> <span data-ttu-id="b1865-164">HLSL セマンティックの全一覧については、「[セマンティクス](https://msdn.microsoft.com/library/windows/desktop/bb509647)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b1865-164">For a complete list of HLSL semantics, see [Semantics](https://msdn.microsoft.com/library/windows/desktop/bb509647).</span></span>

<span data-ttu-id="b1865-165">[**ID3D11Device::CreateInputLayout**](https://msdn.microsoft.com/library/windows/desktop/ff476512) を呼び出し、Direct3D デバイスで入力レイアウトを作ります。</span><span class="sxs-lookup"><span data-stu-id="b1865-165">Call [**ID3D11Device::CreateInputLayout**](https://msdn.microsoft.com/library/windows/desktop/ff476512) and create the input layout on the Direct3D device.</span></span> <span data-ttu-id="b1865-166">次に、データを実際に保持できるバッファーを作る必要があります。</span><span class="sxs-lookup"><span data-stu-id="b1865-166">Now, you need to create a buffer that can actually hold the data!</span></span>

### <a name="step-3-populate-the-vertex-buffers"></a><span data-ttu-id="b1865-167">手順 3: 頂点バッファーを設定する</span><span class="sxs-lookup"><span data-stu-id="b1865-167">Step 3: Populate the vertex buffers</span></span>

<span data-ttu-id="b1865-168">頂点バッファーには、メッシュの各三角形の頂点のリストが含まれます。</span><span class="sxs-lookup"><span data-stu-id="b1865-168">Vertex buffers contain the list of vertices for each triangle in the mesh.</span></span> <span data-ttu-id="b1865-169">各頂点は、このリストで一意である必要があります。</span><span class="sxs-lookup"><span data-stu-id="b1865-169">Every vertex must be unique in this list.</span></span> <span data-ttu-id="b1865-170">この例では、立方体に 8 個の頂点があります。</span><span class="sxs-lookup"><span data-stu-id="b1865-170">In our example, you have 8 vertices for the cube.</span></span> <span data-ttu-id="b1865-171">頂点シェーダーはグラフィックス デバイス上で実行され、頂点バッファーからデータを読み取ります。データは、前の手順で指定した入力レイアウトに基づいて解釈されます。</span><span class="sxs-lookup"><span data-stu-id="b1865-171">The vertex shader runs on the graphics device and reads from the vertex buffer, and it interprets the data based on the input layout you specified in the previous step.</span></span>

<span data-ttu-id="b1865-172">次の例では、バッファーの説明とサブリソースを指定します。バッファーは、頂点データの物理マッピングと、グラフィックス デバイスのメモリで扱う方法を Direct3D に知らせます。</span><span class="sxs-lookup"><span data-stu-id="b1865-172">In the next example, you provide a description and a subresource for the buffer, which tell Direct3D a number of things about the physical mapping of the vertex data and how to treat it in memory on the graphics device.</span></span> <span data-ttu-id="b1865-173">何でも格納できる汎用 [**ID3D11Buffer**](https://msdn.microsoft.com/library/windows/desktop/ff476351) を使うため、これは必要です。</span><span class="sxs-lookup"><span data-stu-id="b1865-173">This is necessary because you use a generic [**ID3D11Buffer**](https://msdn.microsoft.com/library/windows/desktop/ff476351), which could contain anything!</span></span> <span data-ttu-id="b1865-174">[**D3D11\_BUFFER\_DESC**](https://msdn.microsoft.com/library/windows/desktop/ff476092) 構造体と [**D3D11\_SUBRESOURCE\_DATA**](https://msdn.microsoft.com/library/windows/desktop/ff476220) 構造体は、バッファー内の各頂点要素のサイズや頂点リストの最大サイズなど、Direct3D がバッファーの物理メモリ レイアウトを理解できるようにするために提供されます。</span><span class="sxs-lookup"><span data-stu-id="b1865-174">The [**D3D11\_BUFFER\_DESC**](https://msdn.microsoft.com/library/windows/desktop/ff476092) and [**D3D11\_SUBRESOURCE\_DATA**](https://msdn.microsoft.com/library/windows/desktop/ff476220) structures are supplied to ensure that Direct3D understands the physical memory layout of the buffer, including the size of each vertex element in the buffer as well as the maximum size of the vertex list.</span></span> <span data-ttu-id="b1865-175">ここではバッファー メモリへのアクセスや走査方法も制御できますが、その説明はこのチュートリアルの範囲を少々超えています。</span><span class="sxs-lookup"><span data-stu-id="b1865-175">You can also control access to the buffer memory here and how it is traversed, but that's a bit beyond the scope of this tutorial.</span></span>

<span data-ttu-id="b1865-176">バッファーを構成したら、[**ID3D11Device::CreateBuffer**](https://msdn.microsoft.com/library/windows/desktop/ff476501) を呼び出して、実際にバッファーを作ります。</span><span class="sxs-lookup"><span data-stu-id="b1865-176">After you configure the buffer, you call [**ID3D11Device::CreateBuffer**](https://msdn.microsoft.com/library/windows/desktop/ff476501) to actually create it.</span></span> <span data-ttu-id="b1865-177">明らかなことですが、複数のオブジェクトがある場合は、固有のモデルごとにバッファーを作ります。</span><span class="sxs-lookup"><span data-stu-id="b1865-177">Obviously, if you have more than one object, create buffers for each unique model.</span></span>

<span data-ttu-id="b1865-178">頂点バッファーを宣言して作ります。</span><span class="sxs-lookup"><span data-stu-id="b1865-178">Declare and create the vertex buffer.</span></span>

```cpp
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
m_d3dDevice->CreateBuffer(
                &vertexBufferDesc,
                &vertexBufferData,
                &vertexBuffer);
```

<span data-ttu-id="b1865-179">頂点がロードされます。</span><span class="sxs-lookup"><span data-stu-id="b1865-179">Vertices loaded.</span></span> <span data-ttu-id="b1865-180">しかし、これらの頂点を処理する順序はどうなるのでしょうか。</span><span class="sxs-lookup"><span data-stu-id="b1865-180">But what's the order of processing these vertices?</span></span> <span data-ttu-id="b1865-181">順序はインデックスのリストを頂点に割り当てるときに処理されます。インデックスの順序が頂点シェーダーが頂点を処理する順序になります。</span><span class="sxs-lookup"><span data-stu-id="b1865-181">That's handled when you provide a list of indices to the vertices—the ordering of these indices is the order in which the vertex shader processes them.</span></span>

### <a name="step-4-populate-the-index-buffers"></a><span data-ttu-id="b1865-182">手順 4: インデックス バッファーを設定する</span><span class="sxs-lookup"><span data-stu-id="b1865-182">Step 4: Populate the index buffers</span></span>

<span data-ttu-id="b1865-183">これから各頂点のインデックスのリストを用意します。</span><span class="sxs-lookup"><span data-stu-id="b1865-183">Now, you provide a list of the indices for each of the vertices.</span></span> <span data-ttu-id="b1865-184">インデックスは頂点バッファーで頂点の位置に対応し、0 から始まります。</span><span class="sxs-lookup"><span data-stu-id="b1865-184">These indices correspond to the position of the vertex in the vertex buffer, starting with 0.</span></span> <span data-ttu-id="b1865-185">この様子を視覚化するために、メッシュの各頂点に ID のような固有の番号が割り当てられていると考えます。</span><span class="sxs-lookup"><span data-stu-id="b1865-185">To help you visualize this, consider that each unique vertex in your mesh has a unique number assigned to it, like an ID.</span></span> <span data-ttu-id="b1865-186">この ID は、頂点バッファーで頂点の位置を表す整数です。</span><span class="sxs-lookup"><span data-stu-id="b1865-186">This ID is the integer position of the vertex in the vertex buffer.</span></span>

![8 個の頂点がある立方体](images/cube-mesh-1.png)

<span data-ttu-id="b1865-188">この立方体の例では、8 個の頂点があります。4 個の頂点で側面を形成し、4 個セットが 6 組あります。</span><span class="sxs-lookup"><span data-stu-id="b1865-188">In our example cube, you have 8 vertices, which create 6 quads for the sides.</span></span> <span data-ttu-id="b1865-189">この 4 個セットを三角形に分割すると、8 個の頂点を使った三角形が合計で 12 個できます。</span><span class="sxs-lookup"><span data-stu-id="b1865-189">You split the quads into triangles, for a total of 12 triangles that use our 8 vertices.</span></span> <span data-ttu-id="b1865-190">三角形 1 個あたり 3 個の頂点があるので、インデックス バッファーには 36 個のエントリがあります。</span><span class="sxs-lookup"><span data-stu-id="b1865-190">At 3 vertices per triangle, you have 36 entries in our index buffer.</span></span> <span data-ttu-id="b1865-191">この例に示したインデックスのパターンは三角形リストと呼ばれ、三角形リストはプリミティブ トポロジを設定するときに Direct3D に対して **D3D11\_PRIMITIVE\_TOPOLOGY\_TRIANGLELIST** として指定します。</span><span class="sxs-lookup"><span data-stu-id="b1865-191">In our example, this index pattern is known as a triangle list, and you indicate it to Direct3D as a **D3D11\_PRIMITIVE\_TOPOLOGY\_TRIANGLELIST** when you set the primitive topology.</span></span>

<span data-ttu-id="b1865-192">これはインデックスをリストする方法としてはおそらく最も非効率的でしょう。三角形が点や辺を共有すると、多くの冗長部分があります。</span><span class="sxs-lookup"><span data-stu-id="b1865-192">This is probably the most inefficient way to list indices, as there are many redundancies when triangles share points and sides.</span></span> <span data-ttu-id="b1865-193">たとえば、三角形がひし形状に辺を共有している場合は、次のように 4 個の頂点で 6 個のインデックスをリストします。</span><span class="sxs-lookup"><span data-stu-id="b1865-193">For example, when a triangle shares a side in a rhombus shape, you list 6 indices for the four vertices, like this:</span></span>

![ひし形を構成するときのインデックスの順序](images/rhombus-surface-1.png)

-   <span data-ttu-id="b1865-195">三角形 1: \[0, 1, 2\]</span><span class="sxs-lookup"><span data-stu-id="b1865-195">Triangle 1: \[0, 1, 2\]</span></span>
-   <span data-ttu-id="b1865-196">三角形 2: \[0, 2, 3\]</span><span class="sxs-lookup"><span data-stu-id="b1865-196">Triangle 2: \[0, 2, 3\]</span></span>

<span data-ttu-id="b1865-197">帯や扇のトポロジでは、走査時に多くの冗長な辺 (この図ではインデックス 0 からインデックス 2 への辺) を取り除くようにして頂点の順序を決めます。大きなメッシュになると、これで頂点シェーダーの実行回数が劇的に少なくなり、パフォーマンスが大きく向上します。</span><span class="sxs-lookup"><span data-stu-id="b1865-197">In a strip or fan topology, you order the vertices in a way that eliminates many redundant sides during traversal (such as the side from index 0 to index 2 in the image.) For large meshes, this dramatically reduces the number of times the vertex shader is run, and improves performance significantly.</span></span> <span data-ttu-id="b1865-198">ただし、ここではシンプルなまま、三角形リストに沿っておきます。</span><span class="sxs-lookup"><span data-stu-id="b1865-198">However, we'll keep it simple and stick with the triangle list.</span></span>

<span data-ttu-id="b1865-199">頂点バッファーのインデックスをシンプルな三角形リスト トポロジとして宣言します。</span><span class="sxs-lookup"><span data-stu-id="b1865-199">Declare the indices for the vertex buffer as a simple triangle list topology.</span></span>

```cpp
unsigned short cubeIndices[] =
{   0, 1, 2,
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
    0, 4, 7 };
```

<span data-ttu-id="b1865-200">頂点がわずか 8 個しかないのにバッファーに 36 個のインデックス要素があるというのは、非常に冗長です。</span><span class="sxs-lookup"><span data-stu-id="b1865-200">Thirty six index elements in the buffer is very redundant when you only have 8 vertices!</span></span> <span data-ttu-id="b1865-201">冗長さを若干取り除いて、帯状や扇状など別の頂点リスト タイプを使う場合は、[**ID3D11DeviceContext::IASetPrimitiveTopology**](https://msdn.microsoft.com/library/windows/desktop/ff476455) メソッドに特定の [**D3D11\_PRIMITIVE\_TOPOLOGY**](https://msdn.microsoft.com/library/windows/desktop/ff476189) 値を渡すときにそのタイプを指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b1865-201">If you choose to eliminate some of the redundancies and use a different vertex list type, such as a strip or a fan, you must specify that type when you provide a specific [**D3D11\_PRIMITIVE\_TOPOLOGY**](https://msdn.microsoft.com/library/windows/desktop/ff476189) value to the [**ID3D11DeviceContext::IASetPrimitiveTopology**](https://msdn.microsoft.com/library/windows/desktop/ff476455) method.</span></span>

<span data-ttu-id="b1865-202">さまざまなインデックス リストの手法について詳しくは、「[プリミティブ トポロジ](https://msdn.microsoft.com/library/windows/desktop/bb205124)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b1865-202">For more information about different index list techniques, see [Primitive Topologies](https://msdn.microsoft.com/library/windows/desktop/bb205124).</span></span>

### <a name="step-5-create-a-constant-buffer-for-your-transformation-matrices"></a><span data-ttu-id="b1865-203">手順 5: 変換マトリックス用の定数バッファーを作る</span><span class="sxs-lookup"><span data-stu-id="b1865-203">Step 5: Create a constant buffer for your transformation matrices</span></span>

<span data-ttu-id="b1865-204">頂点の処理を開始する前に、実行時に各頂点に適用 (乗算) する変換マトリックスを指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b1865-204">Before you can start processing vertices, you need to provide the transformation matrices that will be applied (multiplied) to each vertex when it runs.</span></span> <span data-ttu-id="b1865-205">ほとんどの 3-D ゲームには、3 種類の変換マトリックスがあります。</span><span class="sxs-lookup"><span data-stu-id="b1865-205">For most 3-D games, there are three of them:</span></span>

-   <span data-ttu-id="b1865-206">オブジェクト (モデル) 座標系から全体のワールド座標系に変換する 4x4 マトリックス。</span><span class="sxs-lookup"><span data-stu-id="b1865-206">The 4x4 matrix that transforms from the object (model) coordinate system to the overall world coordinate system.</span></span>
-   <span data-ttu-id="b1865-207">ワールド座標系からカメラ (ビュー) 座標系に変換する 4x4 マトリックス。</span><span class="sxs-lookup"><span data-stu-id="b1865-207">The 4x4 matrix that transforms from the world coordinate system to the camera (view) coordinate system.</span></span>
-   <span data-ttu-id="b1865-208">カメラ座標系から 2-D ビュー プロジェクション座標系に変換する 4x4 マトリックス。</span><span class="sxs-lookup"><span data-stu-id="b1865-208">The 4x4 matrix that transforms from the camera coordinate system to the 2-D view projection coordinate system.</span></span>

<span data-ttu-id="b1865-209">これらのマトリックスは、*定数バッファー*でシェーダーに渡されます。</span><span class="sxs-lookup"><span data-stu-id="b1865-209">These matrices are passed to the shader in a *constant buffer*.</span></span> <span data-ttu-id="b1865-210">定数バッファーは、シェーダー パイプラインの次のパスを実行する間、定数を保持するメモリ領域のことで、HLSL コードからシェーダーを使って直接アクセスできます。</span><span class="sxs-lookup"><span data-stu-id="b1865-210">A constant buffer is a region of memory that remains constant throughout the execution of the next pass of the shader pipeline, and which can be directly accessed by the shaders from your HLSL code.</span></span> <span data-ttu-id="b1865-211">各定数バッファーは 2 回定義します。ゲームの C++ コードで 1 回、そして C ライクな HLSL 構文のシェーダー コードで (少なくとも) 1 回です。</span><span class="sxs-lookup"><span data-stu-id="b1865-211">You define each constant buffer two times: first in your game's C++ code, and (at least) one time in the C-like HLSL syntax for your shader code.</span></span> <span data-ttu-id="b1865-212">この 2 回の宣言は、タイプとデータの配置に関して直接対応している必要があります。</span><span class="sxs-lookup"><span data-stu-id="b1865-212">The two declarations must directly correspond in terms of types and data alignment.</span></span> <span data-ttu-id="b1865-213">C++ で宣言されたデータを解釈するためにシェーダーで HLSL 宣言を使うと、発見が困難なエラーが紛れ込みやすくなり、タイプが一致しなかったりデータの配置が揃わなかったりします。</span><span class="sxs-lookup"><span data-stu-id="b1865-213">It's easy to introduce hard to find errors when the shader uses the HLSL declaration to interpret data declared in C++, and the types don't match or the alignment of data is off!</span></span>

<span data-ttu-id="b1865-214">定数バッファーは、HLSL で変更されません。</span><span class="sxs-lookup"><span data-stu-id="b1865-214">Constant buffers don't get changed by the HLSL.</span></span> <span data-ttu-id="b1865-215">ゲームで特定のデータを更新するときに、定数バッファーを変更できます。</span><span class="sxs-lookup"><span data-stu-id="b1865-215">You can change them when your game updates specific data.</span></span> <span data-ttu-id="b1865-216">ゲーム開発者は、定数バッファーを 4 種類作ることがよくあります。フレームごとの更新用、モデルやオブジェクトごとの更新用、ゲーム状態のリフレッシュごとの更新用、そしてゲームの存続中は変更することのないデータ用です。</span><span class="sxs-lookup"><span data-stu-id="b1865-216">Often, game devs create 4 classes of constant buffers: one type for updates per frame; one type for updates per model/object; one type for updates per game state refresh; and one type for data that never changes through the lifetime of the game.</span></span>

<span data-ttu-id="b1865-217">この例では、変更することがない定数バッファーのみを用意します。3 つのマトリックスの DirectX::XMFLOAT4X4 データです。</span><span class="sxs-lookup"><span data-stu-id="b1865-217">In this example, we just have one that never changes: the DirectX::XMFLOAT4X4 data for the three matrices.</span></span>

> <span data-ttu-id="b1865-218">**注:** ここに示すコード例は、列優先マトリックスを使用します。</span><span class="sxs-lookup"><span data-stu-id="b1865-218">**Note** The example code presented here uses column-major matrices.</span></span> <span data-ttu-id="b1865-219">HLSL で **row\_major** キーワードを使うと、代わりに行優先マトリックスを使うことができ、ソース マトリックス データも行優先になります。</span><span class="sxs-lookup"><span data-stu-id="b1865-219">You can use row-major matrices instead by using the **row\_major** keyword in HLSL, and ensuring your source matrix data is also row-major.</span></span> <span data-ttu-id="b1865-220">DirectXMath は行優先マトリックスを使います。**row\_major** キーワードで定義される HLSL マトリックスを使うと、DirectXMath を直接使うことができます。</span><span class="sxs-lookup"><span data-stu-id="b1865-220">DirectXMath uses row-major matrices and can be used directly with HLSL matrices defined with the **row\_major** keyword.</span></span>

 

<span data-ttu-id="b1865-221">各頂点を変換するために使う 3 つのマトリックスの定数バッファーを宣言して作ります。</span><span class="sxs-lookup"><span data-stu-id="b1865-221">Declare and create a constant buffer for the three matrices you use to transform each vertex.</span></span>

```cpp
struct ConstantBuffer
{
    DirectX::XMFLOAT4X4 model;
    DirectX::XMFLOAT4X4 view;
    DirectX::XMFLOAT4X4 projection;
};
ComPtr<ID3D11Buffer> m_constantBuffer;
ConstantBuffer m_constantBufferData;

// ...

// Create a constant buffer for passing model, view, and projection matrices
// to the vertex shader.  This allows us to rotate the cube and apply
// a perspective projection to it.

D3D11_BUFFER_DESC constantBufferDesc = {0};
constantBufferDesc.ByteWidth = sizeof(m_constantBufferData);
constantBufferDesc.Usage = D3D11_USAGE_DEFAULT;
constantBufferDesc.BindFlags = D3D11_BIND_CONSTANT_BUFFER;
constantBufferDesc.CPUAccessFlags = 0;
constantBufferDesc.MiscFlags = 0;
constantBufferDesc.StructureByteStride = 0;
m_d3dDevice->CreateBuffer(
                &constantBufferDesc,
                nullptr,
                &m_constantBuffer
             );

m_constantBufferData.model = DirectX::XMFLOAT4X4( // Identity matrix, since you are not animating the object
            1.0f, 0.0f, 0.0f, 0.0f,
            0.0f, 1.0f, 0.0f, 0.0f,
            0.0f, 0.0f, 1.0f, 0.0f,
            0.0f, 0.0f, 0.0f, 1.0f);

);
// Specify the view (camera) transform corresponding to a camera position of
// X = 0, Y = 1, Z = 2.  

m_constantBufferData.view = DirectX::XMFLOAT4X4(
            -1.00000000f, 0.00000000f,  0.00000000f,  0.00000000f,
             0.00000000f, 0.89442718f,  0.44721359f,  0.00000000f,
             0.00000000f, 0.44721359f, -0.89442718f, -2.23606800f,
             0.00000000f, 0.00000000f,  0.00000000f,  1.00000000f);
```

> <span data-ttu-id="b1865-222">**注:** 通常ためにを宣言する射影行列デバイス固有のリソースをセットアップするときに乗算の結果は、現在の 2 D ビューポート サイズ パラメーターに一致する必要があります (多くの場合、ピクセルの高さと幅に対応していますが、表示する)。</span><span class="sxs-lookup"><span data-stu-id="b1865-222">**Note**You usually declare the projection matrix when you set up device specific resources, because the results of multiplication with it must match the current 2-D viewport size parameters (which often correspond with the pixel height and width of the display).</span></span> <span data-ttu-id="b1865-223">これらのパラメーターを変更する場合は、それに合わせて x 座標と y 座標の値をスケーリングする必要があります。</span><span class="sxs-lookup"><span data-stu-id="b1865-223">If those change, you must scale the x- and y-coordinate values accordingly.</span></span>

 

```cpp
// Finally, update the constant buffer perspective projection parameters
// to account for the size of the application window.  In this sample,
// the parameters are fixed to a 70-degree field of view, with a depth
// range of 0.01 to 100.  

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

<span data-ttu-id="b1865-224">ここで、[ID3D11DeviceContext](https://msdn.microsoft.com/library/windows/desktop/ff476149)で頂点バッファーとインデックス バッファー、そして使っているトポロジを設定します。</span><span class="sxs-lookup"><span data-stu-id="b1865-224">While you're here, set the vertex and index buffers on the[ID3D11DeviceContext](https://msdn.microsoft.com/library/windows/desktop/ff476149), plus the topology you're using.</span></span>

```cpp
// Set the vertex and index buffers, and specify the way they define geometry.
UINT stride = sizeof(SimpleCubeVertex);
UINT offset = 0;
m_d3dDeviceContext->IASetVertexBuffers(
                0,
                1,
                vertexBuffer.GetAddressOf(),
                &stride,
                &offset);

m_d3dDeviceContext->IASetIndexBuffer(
                indexBuffer.Get(),
                DXGI_FORMAT_R16_UINT,
                0);

 m_d3dDeviceContext->IASetPrimitiveTopology(D3D11_PRIMITIVE_TOPOLOGY_TRIANGLELIST);
```

<span data-ttu-id="b1865-225">よくできました。</span><span class="sxs-lookup"><span data-stu-id="b1865-225">All right!</span></span> <span data-ttu-id="b1865-226">入力の組み立ては完了です。</span><span class="sxs-lookup"><span data-stu-id="b1865-226">Input assembly complete.</span></span> <span data-ttu-id="b1865-227">レンダリングの準備はすべて整いました。</span><span class="sxs-lookup"><span data-stu-id="b1865-227">Everything's in place for rendering.</span></span> <span data-ttu-id="b1865-228">それでは頂点シェーダーを使ってみましょう。</span><span class="sxs-lookup"><span data-stu-id="b1865-228">Let's get that vertex shader going.</span></span>

### <a name="step-6-process-the-mesh-with-the-vertex-shader"></a><span data-ttu-id="b1865-229">手順 6: 頂点シェーダーでメッシュを処理する</span><span class="sxs-lookup"><span data-stu-id="b1865-229">Step 6: Process the mesh with the vertex shader</span></span>

<span data-ttu-id="b1865-230">メッシュを定義する頂点を格納する頂点バッファーと、頂点の処理順序を定義するインデックス バッファーができたので、これから頂点シェーダーに頂点を送信します。</span><span class="sxs-lookup"><span data-stu-id="b1865-230">Now that you have a vertex buffer with the vertices that define your mesh, and the index buffer that defines the order in which the vertices are processed, you send them to the vertex shader.</span></span> <span data-ttu-id="b1865-231">頂点シェーダーのコードは、コンパイルされた上位レベル シェーダー言語として表されます。頂点バッファー内の頂点ごとに 1 回実行されるため、頂点ごとに変換を実行できます。</span><span class="sxs-lookup"><span data-stu-id="b1865-231">The vertex shader code, expressed as compiled high-level shader language, runs one time for each vertex in the vertex buffer, allowing you to perform your per-vertex transforms.</span></span> <span data-ttu-id="b1865-232">最終的な結果は、通常は 2-D プロジェクションになります。</span><span class="sxs-lookup"><span data-stu-id="b1865-232">The final result is typically a 2-D projection.</span></span>

<span data-ttu-id="b1865-233">(頂点シェーダーをロードしてありますか?</span><span class="sxs-lookup"><span data-stu-id="b1865-233">(Did you load your vertex shader?</span></span> <span data-ttu-id="b1865-234">まだの場合は、「[DirectX ゲームでリソースをロードする方法](load-a-game-asset.md)」をご覧ください。)</span><span class="sxs-lookup"><span data-stu-id="b1865-234">If not, review [How to load resources in your DirectX game](load-a-game-asset.md).)</span></span>

<span data-ttu-id="b1865-235">まず頂点シェーダーを作り ...</span><span class="sxs-lookup"><span data-stu-id="b1865-235">Here, you create the vertex shader...</span></span>

``` syntax
// Set the vertex and pixel shader stage state.
m_d3dDeviceContext->VSSetShader(
                vertexShader.Get(),
                nullptr,
                0);
```

<span data-ttu-id="b1865-236">... 次に定数バッファーを設定します。</span><span class="sxs-lookup"><span data-stu-id="b1865-236">...and set the constant buffers.</span></span>

``` syntax
m_d3dDeviceContext->VSSetConstantBuffers(
                0,
                1,
                m_constantBuffer.GetAddressOf());
```

<span data-ttu-id="b1865-237">この頂点シェーダーのコードは、オブジェクト座標からワールド座標への変換、その後で 2-D ビュー プロジェクション座標系への変換を処理します。</span><span class="sxs-lookup"><span data-stu-id="b1865-237">Here's the vertex shader code that handles the transformation from object coordinates to world coordinates and then to the 2-D view projection coordinate system.</span></span> <span data-ttu-id="b1865-238">見た目をよくするために、シンプルな頂点ごとの照明を適用することもできます。</span><span class="sxs-lookup"><span data-stu-id="b1865-238">You also apply some simple per-vertex lighting to make things pretty.</span></span> <span data-ttu-id="b1865-239">これは、頂点シェーダーの HLSL ファイル (この例では SimplerVertexShader.hlsl) に記載されています。</span><span class="sxs-lookup"><span data-stu-id="b1865-239">This goes in your vertex shader's HLSL file (SimplerVertexShader.hlsl, in this example).</span></span>

``` syntax
cbuffer simpleConstantBuffer : register( b0 )
{
    matrix model;
    matrix view;
    matrix projection;
};

struct VertexShaderInput
{
    DirectX::XMFLOAT3 pos : POSITION;
    DirectX::XMFLOAT3 color : COLOR;
};

struct PixelShaderInput
{
    float4 pos : SV_POSITION;
    float4 color : COLOR;
};

PixelShaderInput SimpleVertexShader(VertexShaderInput input)
{
    PixelShaderInput vertexShaderOutput;
    float4 pos = float4(input.pos, 1.0f);

    // Transform the vertex position into projection space.
    pos = mul(pos, model);
    pos = mul(pos, view);
    pos = mul(pos, projection);
    vertexShaderOutput.pos = pos;

    // Pass the vertex color through to the pixel shader.
    vertexShaderOutput.color = float4(input.color, 1.0f);

    return vertexShaderOutput;
}
```

<span data-ttu-id="b1865-240">先頭には **cbuffer** があります。</span><span class="sxs-lookup"><span data-stu-id="b1865-240">See that **cbuffer** at the top?</span></span> <span data-ttu-id="b1865-241">これは、前に C++ コードで宣言した定数バッファーと同じものを HLSL で表現したものです。</span><span class="sxs-lookup"><span data-stu-id="b1865-241">That's the HLSL analogue to the same constant buffer we declared in our C++ code previously.</span></span> <span data-ttu-id="b1865-242">**VertexShaderInputstruct** は、</span><span class="sxs-lookup"><span data-stu-id="b1865-242">And the **VertexShaderInputstruct**?</span></span> <span data-ttu-id="b1865-243">なぜか、作った入力レイアウトや頂点データの宣言とそっくりです。</span><span class="sxs-lookup"><span data-stu-id="b1865-243">Why, that looks just like your input layout and vertex data declaration!</span></span> <span data-ttu-id="b1865-244">大切なのは、C++ コードでの定数バッファーと頂点データの宣言が、HLSL コードでの宣言と一致していること、そして符号、タイプ、データの配置が含まれていることです。</span><span class="sxs-lookup"><span data-stu-id="b1865-244">It's important that the constant buffer and vertex data declarations in your C++ code match the declarations in your HLSL code—and that includes signs, types, and data alignment.</span></span>

<span data-ttu-id="b1865-245">**PixelShaderInput** は、頂点シェーダーのメインの関数から返されるデータのレイアウトを指定します。</span><span class="sxs-lookup"><span data-stu-id="b1865-245">**PixelShaderInput** specifies the layout of the data that is returned by the vertex shader's main function.</span></span> <span data-ttu-id="b1865-246">頂点の処理が完了すると、2-D プロジェクション空間における頂点の位置と、頂点ごとの照明に使われる色を返します。</span><span class="sxs-lookup"><span data-stu-id="b1865-246">When you finish processing a vertex, you'll return a vertex position in the 2-D projection space and a color used for per-vertex lighting.</span></span> <span data-ttu-id="b1865-247">グラフィックス カードは、シェーダーによるデータ出力を使って "フラグメント" (可能性のあるピクセル) を計算します。フラグメントは、パイプラインの次の段階でピクセル シェーダーが実行されたときに色が付きます。</span><span class="sxs-lookup"><span data-stu-id="b1865-247">The graphics card uses data output by the shader to calculate the "fragments" (possible pixels) that must be colored when the pixel shader is run in the next stage of the pipeline.</span></span>

### <a name="step-7-passing-the-mesh-through-the-pixel-shader"></a><span data-ttu-id="b1865-248">手順 7: ピクセル シェーダーでメッシュを渡す</span><span class="sxs-lookup"><span data-stu-id="b1865-248">Step 7: Passing the mesh through the pixel shader</span></span>

<span data-ttu-id="b1865-249">通常、グラフィックス パイプラインのこの段階では、オブジェクトのプロジェクションされたサーフェスの見えている部分でピクセル単位の操作を実行します </span><span class="sxs-lookup"><span data-stu-id="b1865-249">Typically, at this stage in the graphics pipeline, you perform per-pixel operations on the visible projected surfaces of your objects.</span></span> <span data-ttu-id="b1865-250">(テクスチャが好まれます)。ただし、これはサンプルなので、この段階では素通りするだけにします。</span><span class="sxs-lookup"><span data-stu-id="b1865-250">(People like textures.) For the purposes of sample, though, you simply pass it through this stage.</span></span>

<span data-ttu-id="b1865-251">まず、ピクセル シェーダーのインスタンスを作りましょう。</span><span class="sxs-lookup"><span data-stu-id="b1865-251">First, let's create an instance of the pixel shader.</span></span> <span data-ttu-id="b1865-252">ピクセル シェーダーは、シーンの 2-D プロジェクションの各ピクセルに対して実行され、そのピクセルに色を割り当てます。</span><span class="sxs-lookup"><span data-stu-id="b1865-252">The pixel shader runs for every pixel in the 2-D projection of your scene, assigning a color to that pixel.</span></span> <span data-ttu-id="b1865-253">この場合は、頂点シェーダーで返されたピクセルの色を素通りさせます。</span><span class="sxs-lookup"><span data-stu-id="b1865-253">In this case, we pass the color for the pixel returned by the vertex shader straight through.</span></span>

<span data-ttu-id="b1865-254">ピクセル シェーダーを設定します。</span><span class="sxs-lookup"><span data-stu-id="b1865-254">Set the pixel shader.</span></span>

``` syntax
m_d3dDeviceContext->PSSetShader( pixelShader.Get(), nullptr, 0 );
```

<span data-ttu-id="b1865-255">HLSL でパススルー ピクセル シェーダーを定義します。</span><span class="sxs-lookup"><span data-stu-id="b1865-255">Define a passthrough pixel shader in HLSL.</span></span>

``` syntax
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

<span data-ttu-id="b1865-256">このコードを頂点シェーダーの HLSL とは別の HLSL ファイルに配置します (たとえば SimplePixelShader.hlsl)。</span><span class="sxs-lookup"><span data-stu-id="b1865-256">Put this code in an HLSL file separate from the vertex shader HLSL (such as SimplePixelShader.hlsl).</span></span> <span data-ttu-id="b1865-257">このコードは、ビューポート (描画先画面の一部分のメモリ内表現) で見えているピクセルごとに 1 回実行されます。この場合のビューポートは、画面全体にマッピングされます。</span><span class="sxs-lookup"><span data-stu-id="b1865-257">This code is run one time for every visible pixel in your viewport (an in-memory representation of the portion of the screen you are drawing to), which, in this case, maps to the entire screen.</span></span> <span data-ttu-id="b1865-258">これで、グラフィックス パイプラインはすべて定義されました。</span><span class="sxs-lookup"><span data-stu-id="b1865-258">Now, your graphics pipeline is completely defined!</span></span>

### <a name="step-8-rasterizing-and-displaying-the-mesh"></a><span data-ttu-id="b1865-259">手順 8: メッシュのラスタライズと表示</span><span class="sxs-lookup"><span data-stu-id="b1865-259">Step 8: Rasterizing and displaying the mesh</span></span>

<span data-ttu-id="b1865-260">パイプラインを実行しましょう。</span><span class="sxs-lookup"><span data-stu-id="b1865-260">Let's run the pipeline.</span></span> <span data-ttu-id="b1865-261">手順は簡単です。[**ID3D11DeviceContext::DrawIndexed**](https://msdn.microsoft.com/library/windows/desktop/bb173565) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="b1865-261">This is easy: call [**ID3D11DeviceContext::DrawIndexed**](https://msdn.microsoft.com/library/windows/desktop/bb173565).</span></span>

<span data-ttu-id="b1865-262">立方体を描画します。</span><span class="sxs-lookup"><span data-stu-id="b1865-262">Draw that cube!</span></span>

```cpp
// Draw the cube.
m_d3dDeviceContext->DrawIndexed( ARRAYSIZE(cubeIndices), 0, 0 );
            
```

<span data-ttu-id="b1865-263">グラフィックス カード内で、各頂点がインデックス バッファーでの指定順に処理されます。</span><span class="sxs-lookup"><span data-stu-id="b1865-263">Inside the graphics card, each vertex is processed in the order specified in your index buffer.</span></span> <span data-ttu-id="b1865-264">コードが実行されると、頂点シェーダーと 2-D フラグメントが定義されます。次に、ピクセル シェーダーが呼び出されて、三角形に色が付きます。</span><span class="sxs-lookup"><span data-stu-id="b1865-264">After your code has executed the vertex shader and the 2-D fragments are defined, the pixel shader is invoked and the triangles colored.</span></span>

<span data-ttu-id="b1865-265">次に、立方体を画面に配置します。</span><span class="sxs-lookup"><span data-stu-id="b1865-265">Now, put the cube on the screen.</span></span>

<span data-ttu-id="b1865-266">フレーム バッファーをディスプレイに表示します。</span><span class="sxs-lookup"><span data-stu-id="b1865-266">Present that frame buffer to the display.</span></span>

```cpp
// Present the rendered image to the window.  Because the maximum frame latency is set to 1,
// the render loop is generally  throttled to the screen refresh rate, typically around
// 60 Hz, by sleeping the app on Present until the screen is refreshed.

m_swapChain->Present(1, 0);
```

<span data-ttu-id="b1865-267">これで、終わりです。</span><span class="sxs-lookup"><span data-stu-id="b1865-267">And you're done!</span></span> <span data-ttu-id="b1865-268">モデルがたくさんあるシーンでは、複数の頂点バッファーとインデックス バッファーを使ってください。モデルのタイプごとにシェーダーがある場合もあります。</span><span class="sxs-lookup"><span data-stu-id="b1865-268">For a scene full of models, use multiple vertex and index buffers, and you might even have different shaders for different model types.</span></span> <span data-ttu-id="b1865-269">各モデルには専用の座標系があり、定数バッファーで定義したマトリックスを使って、座標系を共有されるワールド座標系に変換する必要があることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="b1865-269">Remember that each model has its own coordinate system, and you need to transform them to the shared world coordinate system using the matrices you defined in the constant buffer.</span></span>

## <a name="remarks"></a><span data-ttu-id="b1865-270">注釈</span><span class="sxs-lookup"><span data-stu-id="b1865-270">Remarks</span></span>

<span data-ttu-id="b1865-271">このトピックでは、シンプルなジオメトリを自分で作り、表示する方法について取り上げました。</span><span class="sxs-lookup"><span data-stu-id="b1865-271">This topic covers creating and displaying simple geometry that you create yourself.</span></span> <span data-ttu-id="b1865-272">より複雑なジオメトリをファイルからロードしてサンプル専用の頂点バッファー オブジェクト (.vbo) 形式に変換する方法について詳しくは、「[DirectX ゲームでリソースをロードする方法](load-a-game-asset.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b1865-272">For more info about loading more complex geometry from a file and converting it to the sample-specific vertex buffer object (.vbo) format, see [How to load resources in your DirectX game](load-a-game-asset.md).</span></span>  

 

## <a name="related-topics"></a><span data-ttu-id="b1865-273">関連トピック</span><span class="sxs-lookup"><span data-stu-id="b1865-273">Related topics</span></span>


* [<span data-ttu-id="b1865-274">DirectX ゲームでリソースをロードする方法</span><span class="sxs-lookup"><span data-stu-id="b1865-274">How to load resources in your DirectX game</span></span>](load-a-game-asset.md)

 

 




