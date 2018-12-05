---
title: OpenGL ES 2.0 と Direct3D のシェーダー パイプラインの比較
description: 概念的には、Direct3D 11 のシェーダー パイプラインは OpenGL ES 2.0 のそれとよく似ています。
ms.assetid: 3678a264-e3f9-72d2-be91-f79cd6f7c4ca
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, OpenGL, Direct3D, シェーダー パイプライン
ms.localizationpriority: medium
ms.openlocfilehash: f02b365175909b5038e5eb117f12851be9f14e3a
ms.sourcegitcommit: c01c29cd97f1cbf050950526e18e15823b6a12a0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/05/2018
ms.locfileid: "8700539"
---
# <a name="compare-the-opengl-es-20-shader-pipeline-to-direct3d"></a><span data-ttu-id="45a9b-104">OpenGL ES 2.0 と Direct3D のシェーダー パイプラインの比較</span><span class="sxs-lookup"><span data-stu-id="45a9b-104">Compare the OpenGL ES 2.0 shader pipeline to Direct3D</span></span>




**<span data-ttu-id="45a9b-105">重要な API</span><span class="sxs-lookup"><span data-stu-id="45a9b-105">Important APIs</span></span>**

-   [<span data-ttu-id="45a9b-106">入力アセンブラー ステージ</span><span class="sxs-lookup"><span data-stu-id="45a9b-106">Input-Assembler Stage</span></span>](https://msdn.microsoft.com/library/windows/desktop/bb205116)
-   [<span data-ttu-id="45a9b-107">頂点シェーダー ステージ</span><span class="sxs-lookup"><span data-stu-id="45a9b-107">Vertex-Shader Stage</span></span>](https://msdn.microsoft.com/library/windows/desktop/bb205146#Vertex_Shader_Stage)
-   [<span data-ttu-id="45a9b-108">ピクセル シェーダー ステージ</span><span class="sxs-lookup"><span data-stu-id="45a9b-108">Pixel-Shader Stage</span></span>](https://msdn.microsoft.com/library/windows/desktop/bb205146#Pixel_Shader_Stage)

<span data-ttu-id="45a9b-109">概念的には、Direct3D 11 のシェーダー パイプラインは OpenGL ES 2.0 のそれとよく似ています。</span><span class="sxs-lookup"><span data-stu-id="45a9b-109">Conceptually, the Direct3D 11 shader pipeline is very similar to the one in OpenGL ES 2.0.</span></span> <span data-ttu-id="45a9b-110">ただし、API の設計という点では、シェーダー ステージを作成、管理するための主要コンポーネントは、[**ID3D11Device1**](https://msdn.microsoft.com/library/windows/desktop/hh404575) と [**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598) という 2 つのプライマリ インターフェイスに含まれています。</span><span class="sxs-lookup"><span data-stu-id="45a9b-110">In terms of API design, however, the major components for creating and managing the shader stages are parts of two primary interfaces, [**ID3D11Device1**](https://msdn.microsoft.com/library/windows/desktop/hh404575) and [**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598).</span></span> <span data-ttu-id="45a9b-111">このトピックでは、OpenGL ES 2.0 の一般的なシェーダー パイプライン API パターンが、Direct3D 11 におけるこれらのインターフェイスの何に対応するかを説明します。</span><span class="sxs-lookup"><span data-stu-id="45a9b-111">This topic attempts to map common OpenGL ES 2.0 shader pipeline API patterns to the Direct3D 11 equivalents in these interfaces.</span></span>

## <a name="reviewing-the-direct3d-11-shader-pipeline"></a><span data-ttu-id="45a9b-112">Direct3D 11 のシェーダー パイプラインについて</span><span class="sxs-lookup"><span data-stu-id="45a9b-112">Reviewing the Direct3D 11 shader pipeline</span></span>


<span data-ttu-id="45a9b-113">シェーダー オブジェクトは [**ID3D11Device1::CreateVertexShader**](https://msdn.microsoft.com/library/windows/desktop/ff476524) や [**ID3D11Device1::CreatePixelShader**](https://msdn.microsoft.com/library/windows/desktop/ff476513) などの [**ID3D11Device1**](https://msdn.microsoft.com/library/windows/desktop/hh404575) インターフェイスのメソッドで作成されます。</span><span class="sxs-lookup"><span data-stu-id="45a9b-113">The shader objects are created with methods on the [**ID3D11Device1**](https://msdn.microsoft.com/library/windows/desktop/hh404575) interface, such as [**ID3D11Device1::CreateVertexShader**](https://msdn.microsoft.com/library/windows/desktop/ff476524) and [**ID3D11Device1::CreatePixelShader**](https://msdn.microsoft.com/library/windows/desktop/ff476513).</span></span>

<span data-ttu-id="45a9b-114">Direct3D 11 グラフィックス パイプラインは、[**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598) インターフェイスのインスタンスで管理され、次のステージが含まれます。</span><span class="sxs-lookup"><span data-stu-id="45a9b-114">The Direct3D 11 graphics pipeline is managed by instances of the [**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598) interface, and has the following stages:</span></span>

-   <span data-ttu-id="45a9b-115">[入力アセンブラー ステージ](https://msdn.microsoft.com/library/windows/desktop/bb205116): </span><span class="sxs-lookup"><span data-stu-id="45a9b-115">[Input-Assembler Stage](https://msdn.microsoft.com/library/windows/desktop/bb205116).</span></span> <span data-ttu-id="45a9b-116">入力アセンブラー ステージでは、パイプラインにデータ (三角形、線、点) を提供します。</span><span class="sxs-lookup"><span data-stu-id="45a9b-116">The input-assembler stage supplies data (triangles, lines and points) to the pipeline.</span></span> <span data-ttu-id="45a9b-117">このステージをサポートする [**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598) メソッドには、"IA" というプレフィックスが付きます。</span><span class="sxs-lookup"><span data-stu-id="45a9b-117">[**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598) methods that support this stage are prefixed with "IA".</span></span>
-   <span data-ttu-id="45a9b-118">[頂点シェーダー ステージ](https://msdn.microsoft.com/library/windows/desktop/bb205146#Vertex_Shader_Stage): 頂点シェーダー ステージでは頂点を処理し、通常は、変換、スキンの適用、照明の適用などの操作を実行します。</span><span class="sxs-lookup"><span data-stu-id="45a9b-118">[Vertex-Shader Stage](https://msdn.microsoft.com/library/windows/desktop/bb205146#Vertex_Shader_Stage) - The vertex-shader stage processes vertices, typically performing operations such as transformations, skinning, and lighting.</span></span> <span data-ttu-id="45a9b-119">頂点シェーダーは常に 1 つの入力頂点を受け取り、1 つの出力頂点を生成します。</span><span class="sxs-lookup"><span data-stu-id="45a9b-119">A vertex shader always takes a single input vertex and produces a single output vertex.</span></span> <span data-ttu-id="45a9b-120">このステージをサポートする [**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598) メソッドには、"VS" というプレフィックスが付きます。</span><span class="sxs-lookup"><span data-stu-id="45a9b-120">[**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598) methods that support this stage are prefixed with "VS".</span></span>
-   <span data-ttu-id="45a9b-121">[ストリーム出力ステージ](https://msdn.microsoft.com/library/windows/desktop/bb205121): ストリーム出力ステージでは、パイプラインからラスタライザーへの途中でメモリにプリミティブ データをストリーミングします。</span><span class="sxs-lookup"><span data-stu-id="45a9b-121">[Stream-Output Stage](https://msdn.microsoft.com/library/windows/desktop/bb205121) - The stream-output stage streams primitive data from the pipeline to memory on its way to the rasterizer.</span></span> <span data-ttu-id="45a9b-122">データはラスタライザーにストリーミングするか、渡すことができます。</span><span class="sxs-lookup"><span data-stu-id="45a9b-122">Data can be streamed out and/or passed into the rasterizer.</span></span> <span data-ttu-id="45a9b-123">メモリにストリーミングされたデータは、CPU からの入力データまたはリード バックとして、パイプラインに再循環させることができます。</span><span class="sxs-lookup"><span data-stu-id="45a9b-123">Data streamed out to memory can be recirculated back into the pipeline as input data or read-back from the CPU.</span></span> <span data-ttu-id="45a9b-124">このステージをサポートする [**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598) メソッドには、"SO" というプレフィックスが付きます。</span><span class="sxs-lookup"><span data-stu-id="45a9b-124">[**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598) methods that support this stage are prefixed with "SO".</span></span>
-   <span data-ttu-id="45a9b-125">[ラスタライザー ステージ](https://msdn.microsoft.com/library/windows/desktop/bb205125): ラスタライザーは、プリミティブをトリミングし、ピクセル シェーダー用にプリミティブを準備して、ピクセル シェーダーを呼び出す方法を決定します。</span><span class="sxs-lookup"><span data-stu-id="45a9b-125">[Rasterizer Stage](https://msdn.microsoft.com/library/windows/desktop/bb205125) - The rasterizer clips primitives, prepares primitives for the pixel shader, and determines how to invoke pixel shaders.</span></span> <span data-ttu-id="45a9b-126">ピクセル シェーダーがないことをパイプラインに示し ([**ID3D11DeviceContext::PSSetShader**](https://msdn.microsoft.com/library/windows/desktop/ff476472) でピクセル シェーダー ステージを NULL に設定)、深度とステンシルのテストを無効にすることで ([**D3D11\_DEPTH\_STENCIL\_DESC**](https://msdn.microsoft.com/library/windows/desktop/ff476110) で DepthEnable と StencilEnable を FALSE に設定)、ラスター化を無効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="45a9b-126">You can disable rasterization by telling the pipeline there is no pixel shader (set the pixel shader stage to NULL with [**ID3D11DeviceContext::PSSetShader**](https://msdn.microsoft.com/library/windows/desktop/ff476472)), and disabling depth and stencil testing (set DepthEnable and StencilEnable to FALSE in [**D3D11\_DEPTH\_STENCIL\_DESC**](https://msdn.microsoft.com/library/windows/desktop/ff476110)).</span></span> <span data-ttu-id="45a9b-127">無効になっている間、ラスター化関連のパイプライン カウンターは更新されません。</span><span class="sxs-lookup"><span data-stu-id="45a9b-127">While disabled, rasterization-related pipeline counters will not update.</span></span>
-   <span data-ttu-id="45a9b-128">[ピクセル シェーダー ステージ](https://msdn.microsoft.com/library/windows/desktop/bb205146#Pixel_Shader_Stage): ピクセル シェーダー ステージがプリミティブの補間データを受信し、カラーなどのピクセル単位のデータを生成します。</span><span class="sxs-lookup"><span data-stu-id="45a9b-128">[Pixel-Shader Stage](https://msdn.microsoft.com/library/windows/desktop/bb205146#Pixel_Shader_Stage) - The pixel-shader stage receives interpolated data for a primitive and generates per-pixel data such as color.</span></span> <span data-ttu-id="45a9b-129">このステージをサポートする [**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598) メソッドには、"PS" というプレフィックスが付きます。</span><span class="sxs-lookup"><span data-stu-id="45a9b-129">[**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598) methods that support this stage are prefixed with "PS".</span></span>
-   <span data-ttu-id="45a9b-130">[出力マージャー ステージ](https://msdn.microsoft.com/library/windows/desktop/bb205120): 出力マージャー ステージでは、各種出力データ (ピクセル シェーダー値、深度とステンシルの情報) をレンダー ターゲットおよび深度/ステンシル バッファーのコンテンツと結合し、最終的なパイプラインの結果を生成します。</span><span class="sxs-lookup"><span data-stu-id="45a9b-130">[Output-Merger Stage](https://msdn.microsoft.com/library/windows/desktop/bb205120) - The output-merger stage combines various types of output data (pixel shader values, depth and stencil information) with the contents of the render target and depth/stencil buffers to generate the final pipeline result.</span></span> <span data-ttu-id="45a9b-131">このステージをサポートする [**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598) メソッドには、"OM" というプレフィックスが付きます。</span><span class="sxs-lookup"><span data-stu-id="45a9b-131">[**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598) methods that support this stage are prefixed with "OM".</span></span>

<span data-ttu-id="45a9b-132">(ジオメトリ シェーダー、ハル シェーダー、テッセレーター、ドメイン シェーダーのステージもありますが、OpenGL ES 2.0 には類似するものがないので、ここでは説明しません) これらのステージのメソッドの詳しい一覧については、[**ID3D11DeviceContext**](https://msdn.microsoft.com/library/windows/desktop/ff476385) と [**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598) のリファレンス ページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="45a9b-132">(There are also stages for geometry shaders, hull shaders, tesselators, and domain shaders, but since they have no analogues in OpenGL ES 2.0, we won't discuss them here.) For a complete list of the methods for these stages, refer to the [**ID3D11DeviceContext**](https://msdn.microsoft.com/library/windows/desktop/ff476385) and [**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598) reference pages.</span></span> <span data-ttu-id="45a9b-133">**ID3D11DeviceContext1** は Direct3D 11 向けに **ID3D11DeviceContext** を拡張したものです。</span><span class="sxs-lookup"><span data-stu-id="45a9b-133">**ID3D11DeviceContext1** extends **ID3D11DeviceContext** for Direct3D 11.</span></span>

## <a name="creating-a-shader"></a><span data-ttu-id="45a9b-134">シェーダーの作成</span><span class="sxs-lookup"><span data-stu-id="45a9b-134">Creating a shader</span></span>


<span data-ttu-id="45a9b-135">Direct3D では、シェーダー リソースは、コンパイルと読み込みの前に作成されません。このリソースは HLSL が読み込まれたときに作成されます。</span><span class="sxs-lookup"><span data-stu-id="45a9b-135">In Direct3D, shader resources are not created before compiling and loading them; rather, the resource is created when the HLSLis loaded.</span></span> <span data-ttu-id="45a9b-136">そのため、GL\_VERTEX\_SHADER や GL\_FRAGMENT\_SHADER など、特定の型の初期化されたシェーダー リソースを作成する glCreateShader に相当する関数はありません。</span><span class="sxs-lookup"><span data-stu-id="45a9b-136">Therefore, there is no directly analogous function to glCreateShader, which creates an initialized shader resource of a specific type (such as GL\_VERTEX\_SHADER or GL\_FRAGMENT\_SHADER).</span></span> <span data-ttu-id="45a9b-137">Direct3D では、シェーダーは HLSL が [**ID3D11Device1::CreateVertexShader**](https://msdn.microsoft.com/library/windows/desktop/ff476524) や [**ID3D11Device1::CreatePixelShader**](https://msdn.microsoft.com/library/windows/desktop/ff476513) などの特定の関数で読み込まれた後で作成されます。これらの関数は、パラメーターとして型とコンパイルされた HLSL を受け取ります。</span><span class="sxs-lookup"><span data-stu-id="45a9b-137">Rather, shaders are created after the HLSL is loaded with specific functions like [**ID3D11Device1::CreateVertexShader**](https://msdn.microsoft.com/library/windows/desktop/ff476524) and [**ID3D11Device1::CreatePixelShader**](https://msdn.microsoft.com/library/windows/desktop/ff476513), and which take the type and the compiled HLSL as parameters.</span></span>

| <span data-ttu-id="45a9b-138">OpenGL ES 2.0</span><span class="sxs-lookup"><span data-stu-id="45a9b-138">OpenGL ES 2.0</span></span>  | <span data-ttu-id="45a9b-139">Direct3D 11</span><span class="sxs-lookup"><span data-stu-id="45a9b-139">Direct3D 11</span></span>                                                                                                                                                                                                                                                             |
|----------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="45a9b-140">glCreateShader</span><span class="sxs-lookup"><span data-stu-id="45a9b-140">glCreateShader</span></span> | <span data-ttu-id="45a9b-141">コンパイルされたシェーダー オブジェクトが正常に読み込まれた後で [**ID3D11Device1::CreateVertexShader**](https://msdn.microsoft.com/library/windows/desktop/ff476524) と [**ID3D11Device1::CreatePixelShader**](https://msdn.microsoft.com/library/windows/desktop/ff476513) を呼び出し、それらに CSO をバッファーとして渡します。</span><span class="sxs-lookup"><span data-stu-id="45a9b-141">Call [**ID3D11Device1::CreateVertexShader**](https://msdn.microsoft.com/library/windows/desktop/ff476524) and [**ID3D11Device1::CreatePixelShader**](https://msdn.microsoft.com/library/windows/desktop/ff476513) after successfully loading the compiled shader object, passing them the CSO as a buffer.</span></span> |

 

## <a name="compiling-a-shader"></a><span data-ttu-id="45a9b-142">シェーダーのコンパイル</span><span class="sxs-lookup"><span data-stu-id="45a9b-142">Compiling a shader</span></span>


<span data-ttu-id="45a9b-143">Direct3D のシェーダーは、ユニバーサル Windows プラットフォーム (UWP) アプリのコンパイル済みシェーダー オブジェクト (.cso) ファイルとしてプリコンパイルし、いずれかの Windows ランタイム ファイル API を使って読み込む必要があります </span><span class="sxs-lookup"><span data-stu-id="45a9b-143">Direct3D haders must be precompiled as Compiled Shader Object (.cso) files in Universal Windows Platform (UWP) apps and loaded using one of the Windows Runtime file APIs.</span></span> <span data-ttu-id="45a9b-144">(デスクトップ アプリは実行時にテキスト ファイルからのシェーダーや文字列をコンパイルできます)。CSO ファイルは、Microsoft Visual Studio プロジェクトに含まれる任意の .hlsl ファイルから作成され、同じ名前が保持されます。ただし、ファイル拡張子は .cso です。</span><span class="sxs-lookup"><span data-stu-id="45a9b-144">(Desktop apps can compile the shaders from text files or string at run-time.) The CSO files are built from any .hlsl files that are part of your Microsoft Visual Studio project, and retain the same names, only with a .cso file extension.</span></span> <span data-ttu-id="45a9b-145">出荷時に、これらがパッケージに含まれていることを確かめてください。</span><span class="sxs-lookup"><span data-stu-id="45a9b-145">Ensure that they are included with your package when you ship!</span></span>

| <span data-ttu-id="45a9b-146">OpenGL ES 2.0</span><span class="sxs-lookup"><span data-stu-id="45a9b-146">OpenGL ES 2.0</span></span>                          | <span data-ttu-id="45a9b-147">Direct3D 11</span><span class="sxs-lookup"><span data-stu-id="45a9b-147">Direct3D 11</span></span>                                                                                                                                                                   |
|----------------------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="45a9b-148">glCompileShader</span><span class="sxs-lookup"><span data-stu-id="45a9b-148">glCompileShader</span></span>                        | <span data-ttu-id="45a9b-149">なし。</span><span class="sxs-lookup"><span data-stu-id="45a9b-149">N/A.</span></span> <span data-ttu-id="45a9b-150">シェーダーを Visual Studio の .cso ファイルにコンパイルし、パッケージに含めます。</span><span class="sxs-lookup"><span data-stu-id="45a9b-150">Compile the shaders to .cso files in Visual Studio and include them in your package.</span></span>                                                                                     |
| <span data-ttu-id="45a9b-151">コンパイルの状態に glGetShaderiv を使用</span><span class="sxs-lookup"><span data-stu-id="45a9b-151">Using glGetShaderiv for compile status</span></span> | <span data-ttu-id="45a9b-152">なし。</span><span class="sxs-lookup"><span data-stu-id="45a9b-152">N/A.</span></span> <span data-ttu-id="45a9b-153">コンパイルでエラーが発生した場合は、Visual Studio の FX Compiler (FXC) からのコンパイル出力を調べてください。</span><span class="sxs-lookup"><span data-stu-id="45a9b-153">See the compilation output from Visual Studio's FX Compiler (FXC) if there are errors in compilation.</span></span> <span data-ttu-id="45a9b-154">コンパイルが成功すると、対応する CSO ファイルが作成されます。</span><span class="sxs-lookup"><span data-stu-id="45a9b-154">If compilation is successful, a corresponding CSO file is created.</span></span> |

 

## <a name="loading-a-shader"></a><span data-ttu-id="45a9b-155">シェーダーの読み込み</span><span class="sxs-lookup"><span data-stu-id="45a9b-155">Loading a shader</span></span>


<span data-ttu-id="45a9b-156">シェーダーの作成に関するセクションで触れたように、Direct3D 11 では、対応する CSO ファイルがバッファーに読み込まれ、次の表のいずれかのメソッドに渡されたときに、シェーダーを作成します。</span><span class="sxs-lookup"><span data-stu-id="45a9b-156">As noted in the section on creating a shader, Direct3D 11 creates the shader when the corresponding CSO file is loaded into a buffer and passed to one of the methods in the following table.</span></span>

| <span data-ttu-id="45a9b-157">OpenGL ES 2.0</span><span class="sxs-lookup"><span data-stu-id="45a9b-157">OpenGL ES 2.0</span></span> | <span data-ttu-id="45a9b-158">Direct3D 11</span><span class="sxs-lookup"><span data-stu-id="45a9b-158">Direct3D 11</span></span>                                                                                                                                                                                                                           |
|---------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="45a9b-159">ShaderSource</span><span class="sxs-lookup"><span data-stu-id="45a9b-159">ShaderSource</span></span>  | <span data-ttu-id="45a9b-160">コンパイルされたシェーダー オブジェクトが正常に読み込まれた後で [**ID3D11Device1::CreateVertexShader**](https://msdn.microsoft.com/library/windows/desktop/ff476524) と [**ID3D11Device1::CreatePixelShader**](https://msdn.microsoft.com/library/windows/desktop/ff476513) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="45a9b-160">Call [**ID3D11Device1::CreateVertexShader**](https://msdn.microsoft.com/library/windows/desktop/ff476524) and [**ID3D11Device1::CreatePixelShader**](https://msdn.microsoft.com/library/windows/desktop/ff476513) after successfully loading the compiled shader object.</span></span> |

 

## <a name="setting-up-the-pipeline"></a><span data-ttu-id="45a9b-161">パイプラインの設定</span><span class="sxs-lookup"><span data-stu-id="45a9b-161">Setting up the pipeline</span></span>


<span data-ttu-id="45a9b-162">OpenGL ES 2.0 には、実行のための複数のシェーダーを含む "シェーダー プログラム" オブジェクトがあります。</span><span class="sxs-lookup"><span data-stu-id="45a9b-162">OpenGL ES 2.0 has the "shader program" object, which contains multiple shaders for execution.</span></span> <span data-ttu-id="45a9b-163">個々のシェーダーはシェーダー プログラム オブジェクトにアタッチされます。</span><span class="sxs-lookup"><span data-stu-id="45a9b-163">Individual shaders are attached to the shader program object.</span></span> <span data-ttu-id="45a9b-164">ただし、Direct3D 11 では、レンダリング コンテキスト ([**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598)) を直接操作して、そのコンテキストでシェーダーを作成します。</span><span class="sxs-lookup"><span data-stu-id="45a9b-164">However, in Direct3D 11, you work with the rendering context ([**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598)) directly and create shaders on it.</span></span>

| <span data-ttu-id="45a9b-165">OpenGL ES 2.0</span><span class="sxs-lookup"><span data-stu-id="45a9b-165">OpenGL ES 2.0</span></span>   | <span data-ttu-id="45a9b-166">Direct3D 11</span><span class="sxs-lookup"><span data-stu-id="45a9b-166">Direct3D 11</span></span>                                                                                   |
|-----------------|-----------------------------------------------------------------------------------------------|
| <span data-ttu-id="45a9b-167">glCreateProgram</span><span class="sxs-lookup"><span data-stu-id="45a9b-167">glCreateProgram</span></span> | <span data-ttu-id="45a9b-168">なし。</span><span class="sxs-lookup"><span data-stu-id="45a9b-168">N/A.</span></span> <span data-ttu-id="45a9b-169">Direct3D 11 では、シェーダー プログラム オブジェクト アブストラクションは使われません。</span><span class="sxs-lookup"><span data-stu-id="45a9b-169">Direct3D 11 does not use the shader program object abstraction.</span></span>                          |
| <span data-ttu-id="45a9b-170">glLinkProgram</span><span class="sxs-lookup"><span data-stu-id="45a9b-170">glLinkProgram</span></span>   | <span data-ttu-id="45a9b-171">なし。</span><span class="sxs-lookup"><span data-stu-id="45a9b-171">N/A.</span></span> <span data-ttu-id="45a9b-172">Direct3D 11 では、シェーダー プログラム オブジェクト アブストラクションは使われません。</span><span class="sxs-lookup"><span data-stu-id="45a9b-172">Direct3D 11 does not use the shader program object abstraction.</span></span>                          |
| <span data-ttu-id="45a9b-173">glUseProgram</span><span class="sxs-lookup"><span data-stu-id="45a9b-173">glUseProgram</span></span>    | <span data-ttu-id="45a9b-174">なし。</span><span class="sxs-lookup"><span data-stu-id="45a9b-174">N/A.</span></span> <span data-ttu-id="45a9b-175">Direct3D 11 では、シェーダー プログラム オブジェクト アブストラクションは使われません。</span><span class="sxs-lookup"><span data-stu-id="45a9b-175">Direct3D 11 does not use the shader program object abstraction.</span></span>                          |
| <span data-ttu-id="45a9b-176">glGetProgramiv</span><span class="sxs-lookup"><span data-stu-id="45a9b-176">glGetProgramiv</span></span>  | <span data-ttu-id="45a9b-177">作成した、[**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598) への参照を使います。</span><span class="sxs-lookup"><span data-stu-id="45a9b-177">Use the reference you created to [**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598).</span></span> |

 

<span data-ttu-id="45a9b-178">静的な [**D3D11CreateDevice**](https://msdn.microsoft.com/library/windows/desktop/ff476082) メソッドを使って [**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598) と [**ID3D11Device1**](https://msdn.microsoft.com/library/windows/desktop/dn280493) のインスタンスを作成します。</span><span class="sxs-lookup"><span data-stu-id="45a9b-178">Create an instance of [**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598) and [**ID3D11Device1**](https://msdn.microsoft.com/library/windows/desktop/dn280493) with the static [**D3D11CreateDevice**](https://msdn.microsoft.com/library/windows/desktop/ff476082) method.</span></span>

``` syntax
Microsoft::WRL::ComPtr<ID3D11Device1>          m_d3dDevice;
Microsoft::WRL::ComPtr<ID3D11DeviceContext1>  m_d3dContext;

// ...

D3D11CreateDevice(
  nullptr, // Specify nullptr to use the default adapter.
  D3D_DRIVER_TYPE_HARDWARE,
  nullptr,
  creationFlags, // Set set debug and Direct2D compatibility flags.
  featureLevels, // List of feature levels this app can support.
  ARRAYSIZE(featureLevels),
  D3D11_SDK_VERSION, // Always set this to D3D11_SDK_VERSION for UWP apps.
  &device, // Returns the Direct3D device created.
  &m_featureLevel, // Returns feature level of device created.
  &m_d3dContext // Returns the device's immediate context.
);
```

## <a name="setting-the-viewports"></a><span data-ttu-id="45a9b-179">ビューポートの設定</span><span class="sxs-lookup"><span data-stu-id="45a9b-179">Setting the viewport(s)</span></span>


<span data-ttu-id="45a9b-180">Direct3D 11 のビューポートの設定は、OpenGL ES 2.0 でのビューポートの設定方法とよく似ています。</span><span class="sxs-lookup"><span data-stu-id="45a9b-180">Setting a viewport in Direct3D 11 is very similar to how you set a viewport in OpenGL ES 2.0.</span></span> <span data-ttu-id="45a9b-181">Direct3D 11 では、構成済みの [**CD3D11\_VIEWPORT**](https://msdn.microsoft.com/library/windows/desktop/jj151722) で [**ID3D11DeviceContext::RSSetViewports**](https://msdn.microsoft.com/library/windows/desktop/ff476480) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="45a9b-181">In Direct3D 11, call [**ID3D11DeviceContext::RSSetViewports**](https://msdn.microsoft.com/library/windows/desktop/ff476480) with a configured [**CD3D11\_VIEWPORT**](https://msdn.microsoft.com/library/windows/desktop/jj151722).</span></span>

<span data-ttu-id="45a9b-182">Direct3D 11: ビューポートを設定します。</span><span class="sxs-lookup"><span data-stu-id="45a9b-182">Direct3D 11: Setting a viewport.</span></span>

``` syntax
CD3D11_VIEWPORT viewport(
        0.0f,
        0.0f,
        m_d3dRenderTargetSize.Width,
        m_d3dRenderTargetSize.Height
        );
m_d3dContext->RSSetViewports(1, &viewport);
```

| <span data-ttu-id="45a9b-183">OpenGL ES 2.0</span><span class="sxs-lookup"><span data-stu-id="45a9b-183">OpenGL ES 2.0</span></span> | <span data-ttu-id="45a9b-184">Direct3D 11</span><span class="sxs-lookup"><span data-stu-id="45a9b-184">Direct3D 11</span></span>                                                                                                                                  |
|---------------|----------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="45a9b-185">glViewport</span><span class="sxs-lookup"><span data-stu-id="45a9b-185">glViewport</span></span>    | <span data-ttu-id="45a9b-186">[**CD3D11\_VIEWPORT**](https://msdn.microsoft.com/library/windows/desktop/jj151722), [**ID3D11DeviceContext::RSSetViewports**](https://msdn.microsoft.com/library/windows/desktop/ff476480)</span><span class="sxs-lookup"><span data-stu-id="45a9b-186">[**CD3D11\_VIEWPORT**](https://msdn.microsoft.com/library/windows/desktop/jj151722), [**ID3D11DeviceContext::RSSetViewports**](https://msdn.microsoft.com/library/windows/desktop/ff476480)</span></span> |

 

## <a name="configuring-the-vertex-shaders"></a><span data-ttu-id="45a9b-187">頂点シェーダーの構成</span><span class="sxs-lookup"><span data-stu-id="45a9b-187">Configuring the vertex shaders</span></span>


<span data-ttu-id="45a9b-188">Direct3D 11 の頂点シェーダーの構成は、シェーダーの読み込み時に行われます。</span><span class="sxs-lookup"><span data-stu-id="45a9b-188">Configuring a vertex shader in Direct3D 11 is done when the shader is loaded.</span></span> <span data-ttu-id="45a9b-189">Uniform は [**ID3D11DeviceContext1::VSSetConstantBuffers1**](https://msdn.microsoft.com/library/windows/desktop/hh446795) を使って定数バッファーとして渡されます。</span><span class="sxs-lookup"><span data-stu-id="45a9b-189">Uniforms are passed as constant buffers using [**ID3D11DeviceContext1::VSSetConstantBuffers1**](https://msdn.microsoft.com/library/windows/desktop/hh446795).</span></span>

| <span data-ttu-id="45a9b-190">OpenGL ES 2.0</span><span class="sxs-lookup"><span data-stu-id="45a9b-190">OpenGL ES 2.0</span></span>                    | <span data-ttu-id="45a9b-191">Direct3D 11</span><span class="sxs-lookup"><span data-stu-id="45a9b-191">Direct3D 11</span></span>                                                                                               |
|----------------------------------|-----------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="45a9b-192">glAttachShader</span><span class="sxs-lookup"><span data-stu-id="45a9b-192">glAttachShader</span></span>                   | [**<span data-ttu-id="45a9b-193">ID3D11Device1::CreateVertexShader</span><span class="sxs-lookup"><span data-stu-id="45a9b-193">ID3D11Device1::CreateVertexShader</span></span>**](https://msdn.microsoft.com/library/windows/desktop/ff476524)                       |
| <span data-ttu-id="45a9b-194">glGetShaderiv、glGetShaderSource</span><span class="sxs-lookup"><span data-stu-id="45a9b-194">glGetShaderiv, glGetShaderSource</span></span> | [**<span data-ttu-id="45a9b-195">ID3D11DeviceContext1::VSGetShader</span><span class="sxs-lookup"><span data-stu-id="45a9b-195">ID3D11DeviceContext1::VSGetShader</span></span>**](https://msdn.microsoft.com/library/windows/desktop/ff476489)                       |
| <span data-ttu-id="45a9b-196">glGetUniformfv、glGetUniformiv</span><span class="sxs-lookup"><span data-stu-id="45a9b-196">glGetUniformfv, glGetUniformiv</span></span>   | <span data-ttu-id="45a9b-197">[**ID3D11DeviceContext1::VSGetConstantBuffers1**](https://msdn.microsoft.com/library/windows/desktop/hh446793)</span><span class="sxs-lookup"><span data-stu-id="45a9b-197">[**ID3D11DeviceContext1::VSGetConstantBuffers1**](https://msdn.microsoft.com/library/windows/desktop/hh446793).</span></span> |

 

## <a name="configuring-the-pixel-shaders"></a><span data-ttu-id="45a9b-198">ピクセル シェーダーの構成</span><span class="sxs-lookup"><span data-stu-id="45a9b-198">Configuring the pixel shaders</span></span>


<span data-ttu-id="45a9b-199">Direct3D 11 のピクセル シェーダーの構成は、シェーダーの読み込み時に行われます。</span><span class="sxs-lookup"><span data-stu-id="45a9b-199">Configuring a pixel shader in Direct3D 11 is done when the shader is loaded.</span></span> <span data-ttu-id="45a9b-200">Uniform は [**ID3D11DeviceContext1::PSSetConstantBuffers1**](https://msdn.microsoft.com/library/windows/desktop/hh404649) を使って定数バッファーとして渡されます。</span><span class="sxs-lookup"><span data-stu-id="45a9b-200">Uniforms are passed as constant buffers using [**ID3D11DeviceContext1::PSSetConstantBuffers1.**](https://msdn.microsoft.com/library/windows/desktop/hh404649)</span></span>

| <span data-ttu-id="45a9b-201">OpenGL ES 2.0</span><span class="sxs-lookup"><span data-stu-id="45a9b-201">OpenGL ES 2.0</span></span>                    | <span data-ttu-id="45a9b-202">Direct3D 11</span><span class="sxs-lookup"><span data-stu-id="45a9b-202">Direct3D 11</span></span>                                                                                               |
|----------------------------------|-----------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="45a9b-203">glAttachShader</span><span class="sxs-lookup"><span data-stu-id="45a9b-203">glAttachShader</span></span>                   | [**<span data-ttu-id="45a9b-204">ID3D11Device1::CreatePixelShader</span><span class="sxs-lookup"><span data-stu-id="45a9b-204">ID3D11Device1::CreatePixelShader</span></span>**](https://msdn.microsoft.com/library/windows/desktop/ff476513)                         |
| <span data-ttu-id="45a9b-205">glGetShaderiv、glGetShaderSource</span><span class="sxs-lookup"><span data-stu-id="45a9b-205">glGetShaderiv, glGetShaderSource</span></span> | [**<span data-ttu-id="45a9b-206">ID3D11DeviceContext1::PSGetShader</span><span class="sxs-lookup"><span data-stu-id="45a9b-206">ID3D11DeviceContext1::PSGetShader</span></span>**](https://msdn.microsoft.com/library/windows/desktop/ff476468)                       |
| <span data-ttu-id="45a9b-207">glGetUniformfv、glGetUniformiv</span><span class="sxs-lookup"><span data-stu-id="45a9b-207">glGetUniformfv, glGetUniformiv</span></span>   | <span data-ttu-id="45a9b-208">[**ID3D11DeviceContext1::PSGetConstantBuffers1**](https://msdn.microsoft.com/library/windows/desktop/hh404645)</span><span class="sxs-lookup"><span data-stu-id="45a9b-208">[**ID3D11DeviceContext1::PSGetConstantBuffers1**](https://msdn.microsoft.com/library/windows/desktop/hh404645).</span></span> |

 

## <a name="generating-the-final-results"></a><span data-ttu-id="45a9b-209">最終結果の生成</span><span class="sxs-lookup"><span data-stu-id="45a9b-209">Generating the final results</span></span>


<span data-ttu-id="45a9b-210">パイプラインが完了したら、バック バッファーにシェーダー ステージの結果を描画します。</span><span class="sxs-lookup"><span data-stu-id="45a9b-210">When the pipeline completes, you draw the results of the shader stages into the back buffer.</span></span> <span data-ttu-id="45a9b-211">Direct3D 11 では、このとき、描画コマンドを呼び出して結果をバック バッファーのカラー マップとして出力し、そのバック バッファーをディスプレイに送信します。これは Open GL ES 2.0 と同様です。</span><span class="sxs-lookup"><span data-stu-id="45a9b-211">In Direct3D 11, just as it is with Open GL ES 2.0, this involves calling a draw command to output the results as a color map in the back buffer, and thensending that back buffer to the display.</span></span>

| <span data-ttu-id="45a9b-212">OpenGL ES 2.0</span><span class="sxs-lookup"><span data-stu-id="45a9b-212">OpenGL ES 2.0</span></span>  | <span data-ttu-id="45a9b-213">Direct3D 11</span><span class="sxs-lookup"><span data-stu-id="45a9b-213">Direct3D 11</span></span>                                                                                                                                                                                                                                         |
|----------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="45a9b-214">glDrawElements</span><span class="sxs-lookup"><span data-stu-id="45a9b-214">glDrawElements</span></span> | <span data-ttu-id="45a9b-215">[**ID3D11DeviceContext1::Draw**](https://msdn.microsoft.com/library/windows/desktop/ff476407)、[**ID3D11DeviceContext1::DrawIndexed**](https://msdn.microsoft.com/library/windows/desktop/ff476409) (または [**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/ff476385) の他の Draw\* メソッド)</span><span class="sxs-lookup"><span data-stu-id="45a9b-215">[**ID3D11DeviceContext1::Draw**](https://msdn.microsoft.com/library/windows/desktop/ff476407), [**ID3D11DeviceContext1::DrawIndexed**](https://msdn.microsoft.com/library/windows/desktop/ff476409) (or other Draw\* methods on [**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/ff476385)).</span></span> |
| <span data-ttu-id="45a9b-216">eglSwapBuffers</span><span class="sxs-lookup"><span data-stu-id="45a9b-216">eglSwapBuffers</span></span> | [**<span data-ttu-id="45a9b-217">IDXGISwapChain1::Present1</span><span class="sxs-lookup"><span data-stu-id="45a9b-217">IDXGISwapChain1::Present1</span></span>**](https://msdn.microsoft.com/library/windows/desktop/hh446797)                                                                                                                                                                              |

 

## <a name="porting-glsl-to-hlsl"></a><span data-ttu-id="45a9b-218">HLSL への GLSL の移植</span><span class="sxs-lookup"><span data-stu-id="45a9b-218">Porting GLSL to HLSL</span></span>


<span data-ttu-id="45a9b-219">GLSL と HLSL は、複合型のサポートと全体的な構文以外はそれほど違いません。</span><span class="sxs-lookup"><span data-stu-id="45a9b-219">GLSL and HLSL are not very different beyond complex type support and syntax some overall syntax.</span></span> <span data-ttu-id="45a9b-220">最も簡単な移植方法は、一般的な OpenGL ES 2.0 の命令と定義を HLSL の対応する要素にエイリアシングすることです。</span><span class="sxs-lookup"><span data-stu-id="45a9b-220">Many developers find it easiest to port between the two by aliasing common OpenGL ES 2.0 instructions and definitions to their HLSL equivalent.</span></span> <span data-ttu-id="45a9b-221">グラフィックス インターフェイスでサポートされる HLSL の機能セットを表現するために、Direct3D ではシェーダー モデル バージョンを使います。OpenGL には、HLSL 向けに異なるバージョン仕様があります。</span><span class="sxs-lookup"><span data-stu-id="45a9b-221">Note that Direct3D uses the Shader Model version to express the feature set of the HLSL supported by a graphics interface; OpenGL has a different version specification for HLSL.</span></span> <span data-ttu-id="45a9b-222">次の表では、他のバージョンの観点から、Direct3D 11 と OpenGL ES 2.0 に対して定義されているシェーダー言語機能セットについて、簡単に示します。</span><span class="sxs-lookup"><span data-stu-id="45a9b-222">The following table attempts to give you some approximate idea of the shader language feature sets defined for Direct3D 11 and OpenGL ES 2.0 in the terms of the other's version.</span></span>

| <span data-ttu-id="45a9b-223">シェーダー言語</span><span class="sxs-lookup"><span data-stu-id="45a9b-223">Shader language</span></span>           | <span data-ttu-id="45a9b-224">GLSL 機能バージョン</span><span class="sxs-lookup"><span data-stu-id="45a9b-224">GLSL feature version</span></span>                                                                                                                                                                                                      | <span data-ttu-id="45a9b-225">Direct3D シェーダー モデル</span><span class="sxs-lookup"><span data-stu-id="45a9b-225">Direct3D Shader Model</span></span> |
|---------------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|-----------------------|
| <span data-ttu-id="45a9b-226">Direct3D 11 HLSL</span><span class="sxs-lookup"><span data-stu-id="45a9b-226">Direct3D 11 HLSL</span></span>          | <span data-ttu-id="45a9b-227">～ 4.30。</span><span class="sxs-lookup"><span data-stu-id="45a9b-227">~4.30.</span></span>                                                                                                                                                                                                                    | <span data-ttu-id="45a9b-228">SM 5.0</span><span class="sxs-lookup"><span data-stu-id="45a9b-228">SM 5.0</span></span>                |
| <span data-ttu-id="45a9b-229">OpenGL ES 2.0 向けの GLSL ES</span><span class="sxs-lookup"><span data-stu-id="45a9b-229">GLSL ES for OpenGL ES 2.0</span></span> | <span data-ttu-id="45a9b-230">1.40。</span><span class="sxs-lookup"><span data-stu-id="45a9b-230">1.40.</span></span> <span data-ttu-id="45a9b-231">OpenGL ES 2.0 向けの GLSL ES の以前の実装では、1.10 から 1.30 までを使用できます。</span><span class="sxs-lookup"><span data-stu-id="45a9b-231">Older implementations of GLSL ES for OpenGL ES 2.0 may use 1.10 through 1.30.</span></span> <span data-ttu-id="45a9b-232">glGetString(GL\_SHADING\_LANGUAGE\_VERSION) または glGetString(SHADING\_LANGUAGE\_VERSION) で元のコードをチェックし、バージョンを調べてください。</span><span class="sxs-lookup"><span data-stu-id="45a9b-232">Check your original code with glGetString(GL\_SHADING\_LANGUAGE\_VERSION) or glGetString(SHADING\_LANGUAGE\_VERSION) to determine it.</span></span> | <span data-ttu-id="45a9b-233">～ SM 2.0</span><span class="sxs-lookup"><span data-stu-id="45a9b-233">~SM 2.0</span></span>               |

 

<span data-ttu-id="45a9b-234">2 つのシェーダー言語の違いと一般的な構文のマッピングについて詳しくは、「[GLSL と HLSL の対応を示すリファレンス](glsl-to-hlsl-reference.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="45a9b-234">For more details of differences between the two shader languages, as well as common syntax mappings, read the [GLSL-to-HLSL reference](glsl-to-hlsl-reference.md).</span></span>

## <a name="porting-the-opengl-intrinsics-to-hlsl-semantics"></a><span data-ttu-id="45a9b-235">HLSL セマンティクスへの OpenGL 組み込みメソッドの移植</span><span class="sxs-lookup"><span data-stu-id="45a9b-235">Porting the OpenGL intrinsics to HLSL semantics</span></span>


<span data-ttu-id="45a9b-236">Direct3D 11 HLSL セマンティクスは、uniform や属性名と同様に、アプリとシェーダー プログラムの間で渡される値を識別するために使われる文字列です。</span><span class="sxs-lookup"><span data-stu-id="45a9b-236">Direct3D 11 HLSL semantics are strings that, like a uniform or attribute name, are used to identify a value passed between the app and a shader program.</span></span> <span data-ttu-id="45a9b-237">使用できる文字列はさまざまですが、用途を示す文字列 (POSITION、COLOR など) を使うことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="45a9b-237">While they can be any of a variety of possible strings, the best practice is to use a string like POSITION or COLOR that indicates the usage.</span></span> <span data-ttu-id="45a9b-238">これらのセマンティクスは、定数バッファーまたはバッファー入力レイアウトを構成する際に割り当てます。</span><span class="sxs-lookup"><span data-stu-id="45a9b-238">You assign these semantics when you are constructing a constant buffer or buffer input layout.</span></span> <span data-ttu-id="45a9b-239">類似する値に別のレジスタを使うために、セマンティクスに 0 ～ 7 の範囲の数値を追加できます。</span><span class="sxs-lookup"><span data-stu-id="45a9b-239">You can also append a number between 0 and 7 to the semantic so that you use separate registers for similar values.</span></span> <span data-ttu-id="45a9b-240">COLOR0、COLOR1、COLOR2 などです。</span><span class="sxs-lookup"><span data-stu-id="45a9b-240">For example: COLOR0, COLOR1, COLOR2...</span></span>

<span data-ttu-id="45a9b-241">"SV\_" というプレフィックスが付いたセマンティクスは、シェーダー プログラムによって書き込みが行われるシステム値のセマンティクスです。CPU 上で実行されているアプリ自体で変更することはできません。</span><span class="sxs-lookup"><span data-stu-id="45a9b-241">Semantics that are prefixed with "SV\_" are system value semantics that are written to by your shader program; your app itself (running on the CPU) cannot modify them.</span></span> <span data-ttu-id="45a9b-242">通常、これらには、グラフィックス パイプラインの別のシェーダー ステージからの入出力値のほか、GPU のみによって生成された値が含まれます。</span><span class="sxs-lookup"><span data-stu-id="45a9b-242">Typically, these contain values that are inputs or outputs from another shader stage in the graphics pipeline, or are generated entirely by the GPU.</span></span>

<span data-ttu-id="45a9b-243">また、SV\_ セマンティクスは、シェーダー ステージとの間の入出力を指定するために使われた場合、異なる動作を持ちます。</span><span class="sxs-lookup"><span data-stu-id="45a9b-243">Additionally, SV\_ semantics have different behaviors when they are used to specify input to or output from a shader stage.</span></span> <span data-ttu-id="45a9b-244">たとえば、SV\_POSITION (出力) には頂点シェーダー ステージで変換された頂点データが含まれ、SV\_POSITION (入力) にはラスタライズ時に補間されたピクセル位置の値が含まれます。</span><span class="sxs-lookup"><span data-stu-id="45a9b-244">For example, SV\_POSITION (output) contains the vertex data transformed during the vertex shader stage, and SV\_POSITION (input) contains the pixel position values interpolated during rasterization.</span></span>

<span data-ttu-id="45a9b-245">次に、一般的な OpenGL ES 2.0 シェーダー組み込みメソッドのマッピングをいくつか示します。</span><span class="sxs-lookup"><span data-stu-id="45a9b-245">Here are a few mappings for common OpenGL ES 2.0 shader instrinsics:</span></span>

| <span data-ttu-id="45a9b-246">OpenGL のシステム値</span><span class="sxs-lookup"><span data-stu-id="45a9b-246">OpenGL system value</span></span> | <span data-ttu-id="45a9b-247">使用する HLSL セマンティック</span><span class="sxs-lookup"><span data-stu-id="45a9b-247">Use this HLSL Semantic</span></span>                                                                                                                                                   |
|---------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="45a9b-248">gl\_Position</span><span class="sxs-lookup"><span data-stu-id="45a9b-248">gl\_Position</span></span>        | <span data-ttu-id="45a9b-249">頂点バッファー データを表す POSITION(n)。</span><span class="sxs-lookup"><span data-stu-id="45a9b-249">POSITION(n) for vertex buffer data.</span></span> <span data-ttu-id="45a9b-250">SV\_POSITION は、ピクセル シェーダーにピクセル位置を提供します。アプリで書き込むことはできません。</span><span class="sxs-lookup"><span data-stu-id="45a9b-250">SV\_POSITION provides a pixel position to the pixel shader and cannot be written by your app.</span></span>                                        |
| <span data-ttu-id="45a9b-251">gl\_Normal</span><span class="sxs-lookup"><span data-stu-id="45a9b-251">gl\_Normal</span></span>          | <span data-ttu-id="45a9b-252">頂点バッファーによって提供される標準データを表す NORMAL(n)。</span><span class="sxs-lookup"><span data-stu-id="45a9b-252">NORMAL(n) for normal data provided by the vertex buffer.</span></span>                                                                                                                 |
| <span data-ttu-id="45a9b-253">gl\_TexCoord\[n\]</span><span class="sxs-lookup"><span data-stu-id="45a9b-253">gl\_TexCoord\[n\]</span></span>   | <span data-ttu-id="45a9b-254">シェーダーに提供されるテクスチャ UV (一部の OpenGL のドキュメントでは ST) 座標データを表す TEXCOORD(n)。</span><span class="sxs-lookup"><span data-stu-id="45a9b-254">TEXCOORD(n) for texture UV (ST in some OpenGL documentation) coordinate data supplied to a shader.</span></span>                                                                       |
| <span data-ttu-id="45a9b-255">gl\_FragColor</span><span class="sxs-lookup"><span data-stu-id="45a9b-255">gl\_FragColor</span></span>       | <span data-ttu-id="45a9b-256">シェーダーに提供される RGBA カラー データを表す COLOR(n)。</span><span class="sxs-lookup"><span data-stu-id="45a9b-256">COLOR(n) for RGBA color data supplied to a shader.</span></span> <span data-ttu-id="45a9b-257">座標データと同様に処理されることに注意してください。このセマンティクスは、単に色データであることを示すために使用します。</span><span class="sxs-lookup"><span data-stu-id="45a9b-257">Note that it is treated identically to coordinate data; the semantic simply helps you identify that it is color data.</span></span> |
| <span data-ttu-id="45a9b-258">gl\_FragData\[n\]</span><span class="sxs-lookup"><span data-stu-id="45a9b-258">gl\_FragData\[n\]</span></span>   | <span data-ttu-id="45a9b-259">ピクセル シェーダーからターゲット テクスチャまたはその他のピクセル バッファーへの書き込みを表す SV\_Target\[n\]。</span><span class="sxs-lookup"><span data-stu-id="45a9b-259">SV\_Target\[n\] for writing from a pixel shader to a target texture or other pixel buffer.</span></span>                                                                               |

 

<span data-ttu-id="45a9b-260">セマンティクスのコーディングに使うメソッドは、OpenGL ES 2.0 での組み込みメソッドの使用と同じではありません。</span><span class="sxs-lookup"><span data-stu-id="45a9b-260">The method by which you code for semantics is not the same as using intrinsics in OpenGL ES 2.0.</span></span> <span data-ttu-id="45a9b-261">OpenGL では、構成または宣言なしで組み込みメソッドの多くに直接アクセスできます。Direct3D では、特定のセマンティクスを使うために、特定の定数バッファーでフィールドを宣言するか、シェーダーの **main()** メソッドの戻り値として宣言する必要があります。</span><span class="sxs-lookup"><span data-stu-id="45a9b-261">In OpenGL, you can access many of the intrinsics directly without any configuration or declaration; in Direct3D, you must declare a field in a specific constant buffer to use a particular semantic, or you declare it as the return value for a shader's **main()** method.</span></span>

<span data-ttu-id="45a9b-262">定数バッファーの定義で使われるセマンティックの例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="45a9b-262">Here's an example of a semantic used in a constant buffer definition:</span></span>

```cpp
struct VertexShaderInput
{
  float3 pos : POSITION;
  float3 color : COLOR0;
};

// The position is interpolated to the pixel value by the system. The per-vertex color data is also interpolated and passed through the pixel shader. 
struct PixelShaderInput
{
  float4 pos : SV_POSITION;
  float3 color : COLOR0;
};
```

<span data-ttu-id="45a9b-263">このコードは、単純な定数バッファーのペアを定義します。</span><span class="sxs-lookup"><span data-stu-id="45a9b-263">This code defines a pair of simple constant buffers</span></span>

<span data-ttu-id="45a9b-264">フラグメント シェーダーによって返される値を定義するために使われるセマンティックの例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="45a9b-264">And here's an example of a semantic used to define the value returned by a fragment shader:</span></span>

```cpp
// A pass-through for the (interpolated) color data.
float4 main(PixelShaderInput input) : SV_TARGET
{
  return float4(input.color,1.0f);
}
```

<span data-ttu-id="45a9b-265">この場合、SV\_TARGET は、シェーダーの実行の完了時に、ピクセルの色 (4 つの浮動小数点値を持つベクターとして定義) が書き込まれるレンダー ターゲットの場所です。</span><span class="sxs-lookup"><span data-stu-id="45a9b-265">In this case, SV\_TARGET is the location of the render target that the pixel color (defined as a vector with four float values) is written to when the shader completes execution.</span></span>

<span data-ttu-id="45a9b-266">Direct3D でのセマンティクスの使用について詳しくは、「[HLSL セマンティクス](https://msdn.microsoft.com/library/windows/desktop/bb509647)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="45a9b-266">For more details on the use of semantics with Direct3D, read [HLSL Semantics](https://msdn.microsoft.com/library/windows/desktop/bb509647).</span></span>

 

 




