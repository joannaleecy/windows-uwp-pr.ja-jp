---
author: mtoepke
title: OpenGL ES 2.0 と Direct3D のシェーダー パイプラインの比較
description: 概念的には、Direct3D 11 のシェーダー パイプラインは OpenGL ES 2.0 のそれとよく似ています。
ms.assetid: 3678a264-e3f9-72d2-be91-f79cd6f7c4ca
ms.author: mtoepke
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, ゲーム, OpenGL, Direct3D, シェーダー パイプライン
ms.openlocfilehash: 20d02d9b9724c0cfd8120d4d38fa476b9efa3bb3
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.locfileid: "246722"
---
# <a name="compare-the-opengl-es-20-shader-pipeline-to-direct3d"></a><span data-ttu-id="e48c0-104">OpenGL ES 2.0 と Direct3D のシェーダー パイプラインの比較</span><span class="sxs-lookup"><span data-stu-id="e48c0-104">Compare the OpenGL ES 2.0 shader pipeline to Direct3D</span></span>


<span data-ttu-id="e48c0-105">\[Windows 10 の UWP アプリ向けに更新。</span><span class="sxs-lookup"><span data-stu-id="e48c0-105">\[ Updated for UWP apps on Windows 10.</span></span> <span data-ttu-id="e48c0-106">Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132) をご覧ください\]</span><span class="sxs-lookup"><span data-stu-id="e48c0-106">For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]</span></span>


**<span data-ttu-id="e48c0-107">重要な API</span><span class="sxs-lookup"><span data-stu-id="e48c0-107">Important APIs</span></span>**

-   [<span data-ttu-id="e48c0-108">入力アセンブラー ステージ</span><span class="sxs-lookup"><span data-stu-id="e48c0-108">Input-Assembler Stage</span></span>](https://msdn.microsoft.com/library/windows/desktop/bb205116)
-   [<span data-ttu-id="e48c0-109">頂点シェーダー ステージ</span><span class="sxs-lookup"><span data-stu-id="e48c0-109">Vertex-Shader Stage</span></span>](https://msdn.microsoft.com/library/windows/desktop/bb205146#Vertex_Shader_Stage)
-   [<span data-ttu-id="e48c0-110">ピクセル シェーダー ステージ</span><span class="sxs-lookup"><span data-stu-id="e48c0-110">Pixel-Shader Stage</span></span>](https://msdn.microsoft.com/library/windows/desktop/bb205146#Pixel_Shader_Stage)

<span data-ttu-id="e48c0-111">概念的には、Direct3D 11 のシェーダー パイプラインは OpenGL ES 2.0 のそれとよく似ています。</span><span class="sxs-lookup"><span data-stu-id="e48c0-111">Conceptually, the Direct3D 11 shader pipeline is very similar to the one in OpenGL ES 2.0.</span></span> <span data-ttu-id="e48c0-112">ただし、API の設計という点では、シェーダー ステージを作成、管理するための主要コンポーネントは、[**ID3D11Device1**](https://msdn.microsoft.com/library/windows/desktop/hh404575) と [**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598) という 2 つのプライマリ インターフェイスに含まれています。</span><span class="sxs-lookup"><span data-stu-id="e48c0-112">In terms of API design, however, the major components for creating and managing the shader stages are parts of two primary interfaces, [**ID3D11Device1**](https://msdn.microsoft.com/library/windows/desktop/hh404575) and [**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598).</span></span> <span data-ttu-id="e48c0-113">このトピックでは、OpenGL ES 2.0 の一般的なシェーダー パイプライン API パターンが、Direct3D 11 におけるこれらのインターフェイスの何に対応するかを説明します。</span><span class="sxs-lookup"><span data-stu-id="e48c0-113">This topic attempts to map common OpenGL ES 2.0 shader pipeline API patterns to the Direct3D 11 equivalents in these interfaces.</span></span>

## <a name="reviewing-the-direct3d-11-shader-pipeline"></a><span data-ttu-id="e48c0-114">Direct3D 11 のシェーダー パイプラインについて</span><span class="sxs-lookup"><span data-stu-id="e48c0-114">Reviewing the Direct3D 11 shader pipeline</span></span>


<span data-ttu-id="e48c0-115">シェーダー オブジェクトは [**ID3D11Device1::CreateVertexShader**](https://msdn.microsoft.com/library/windows/desktop/ff476524) や [**ID3D11Device1::CreatePixelShader**](https://msdn.microsoft.com/library/windows/desktop/ff476513) などの [**ID3D11Device1**](https://msdn.microsoft.com/library/windows/desktop/hh404575) インターフェイスのメソッドで作成されます。</span><span class="sxs-lookup"><span data-stu-id="e48c0-115">The shader objects are created with methods on the [**ID3D11Device1**](https://msdn.microsoft.com/library/windows/desktop/hh404575) interface, such as [**ID3D11Device1::CreateVertexShader**](https://msdn.microsoft.com/library/windows/desktop/ff476524) and [**ID3D11Device1::CreatePixelShader**](https://msdn.microsoft.com/library/windows/desktop/ff476513).</span></span>

<span data-ttu-id="e48c0-116">Direct3D 11 グラフィックス パイプラインは、[**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598) インターフェイスのインスタンスで管理され、次のステージが含まれます。</span><span class="sxs-lookup"><span data-stu-id="e48c0-116">The Direct3D 11 graphics pipeline is managed by instances of the [**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598) interface, and has the following stages:</span></span>

-   <span data-ttu-id="e48c0-117">[入力アセンブラー ステージ](https://msdn.microsoft.com/library/windows/desktop/bb205116): </span><span class="sxs-lookup"><span data-stu-id="e48c0-117">[Input-Assembler Stage](https://msdn.microsoft.com/library/windows/desktop/bb205116).</span></span> <span data-ttu-id="e48c0-118">入力アセンブラー ステージでは、パイプラインにデータ (三角形、線、点) を提供します。</span><span class="sxs-lookup"><span data-stu-id="e48c0-118">The input-assembler stage supplies data (triangles, lines and points) to the pipeline.</span></span> <span data-ttu-id="e48c0-119">このステージをサポートする [**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598) メソッドには、"IA" というプレフィックスが付きます。</span><span class="sxs-lookup"><span data-stu-id="e48c0-119">[**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598) methods that support this stage are prefixed with "IA".</span></span>
-   <span data-ttu-id="e48c0-120">[頂点シェーダー ステージ](https://msdn.microsoft.com/library/windows/desktop/bb205146#Vertex_Shader_Stage): 頂点シェーダー ステージでは頂点を処理し、通常は、変換、スキンの適用、照明の適用などの操作を実行します。</span><span class="sxs-lookup"><span data-stu-id="e48c0-120">[Vertex-Shader Stage](https://msdn.microsoft.com/library/windows/desktop/bb205146#Vertex_Shader_Stage) - The vertex-shader stage processes vertices, typically performing operations such as transformations, skinning, and lighting.</span></span> <span data-ttu-id="e48c0-121">頂点シェーダーは常に 1 つの入力頂点を受け取り、1 つの出力頂点を生成します。</span><span class="sxs-lookup"><span data-stu-id="e48c0-121">A vertex shader always takes a single input vertex and produces a single output vertex.</span></span> <span data-ttu-id="e48c0-122">このステージをサポートする [**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598) メソッドには、"VS" というプレフィックスが付きます。</span><span class="sxs-lookup"><span data-stu-id="e48c0-122">[**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598) methods that support this stage are prefixed with "VS".</span></span>
-   <span data-ttu-id="e48c0-123">[ストリーム出力ステージ](https://msdn.microsoft.com/library/windows/desktop/bb205121): ストリーム出力ステージでは、パイプラインからラスタライザーへの途中でメモリにプリミティブ データをストリーミングします。</span><span class="sxs-lookup"><span data-stu-id="e48c0-123">[Stream-Output Stage](https://msdn.microsoft.com/library/windows/desktop/bb205121) - The stream-output stage streams primitive data from the pipeline to memory on its way to the rasterizer.</span></span> <span data-ttu-id="e48c0-124">データはラスタライザーにストリーミングするか、渡すことができます。</span><span class="sxs-lookup"><span data-stu-id="e48c0-124">Data can be streamed out and/or passed into the rasterizer.</span></span> <span data-ttu-id="e48c0-125">メモリにストリーミングされたデータは、CPU からの入力データまたはリード バックとして、パイプラインに再循環させることができます。</span><span class="sxs-lookup"><span data-stu-id="e48c0-125">Data streamed out to memory can be recirculated back into the pipeline as input data or read-back from the CPU.</span></span> <span data-ttu-id="e48c0-126">このステージをサポートする [**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598) メソッドには、"SO" というプレフィックスが付きます。</span><span class="sxs-lookup"><span data-stu-id="e48c0-126">[**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598) methods that support this stage are prefixed with "SO".</span></span>
-   <span data-ttu-id="e48c0-127">[ラスタライザー ステージ](https://msdn.microsoft.com/library/windows/desktop/bb205125): ラスタライザーは、プリミティブをトリミングし、ピクセル シェーダー用にプリミティブを準備して、ピクセル シェーダーを呼び出す方法を決定します。</span><span class="sxs-lookup"><span data-stu-id="e48c0-127">[Rasterizer Stage](https://msdn.microsoft.com/library/windows/desktop/bb205125) - The rasterizer clips primitives, prepares primitives for the pixel shader, and determines how to invoke pixel shaders.</span></span> <span data-ttu-id="e48c0-128">ピクセル シェーダーがないことをパイプラインに示し ([**ID3D11DeviceContext::PSSetShader**](https://msdn.microsoft.com/library/windows/desktop/ff476472) でピクセル シェーダー ステージを NULL に設定)、深度とステンシルのテストを無効にすることで ([**D3D11\_DEPTH\_STENCIL\_DESC**](https://msdn.microsoft.com/library/windows/desktop/ff476110) で DepthEnable と StencilEnable を FALSE に設定)、ラスター化を無効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="e48c0-128">You can disable rasterization by telling the pipeline there is no pixel shader (set the pixel shader stage to NULL with [**ID3D11DeviceContext::PSSetShader**](https://msdn.microsoft.com/library/windows/desktop/ff476472)), and disabling depth and stencil testing (set DepthEnable and StencilEnable to FALSE in [**D3D11\_DEPTH\_STENCIL\_DESC**](https://msdn.microsoft.com/library/windows/desktop/ff476110)).</span></span> <span data-ttu-id="e48c0-129">無効になっている間、ラスター化関連のパイプライン カウンターは更新されません。</span><span class="sxs-lookup"><span data-stu-id="e48c0-129">While disabled, rasterization-related pipeline counters will not update.</span></span>
-   <span data-ttu-id="e48c0-130">[ピクセル シェーダー ステージ](https://msdn.microsoft.com/library/windows/desktop/bb205146#Pixel_Shader_Stage): ピクセル シェーダー ステージがプリミティブの補間データを受信し、カラーなどのピクセル単位のデータを生成します。</span><span class="sxs-lookup"><span data-stu-id="e48c0-130">[Pixel-Shader Stage](https://msdn.microsoft.com/library/windows/desktop/bb205146#Pixel_Shader_Stage) - The pixel-shader stage receives interpolated data for a primitive and generates per-pixel data such as color.</span></span> <span data-ttu-id="e48c0-131">このステージをサポートする [**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598) メソッドには、"PS" というプレフィックスが付きます。</span><span class="sxs-lookup"><span data-stu-id="e48c0-131">[**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598) methods that support this stage are prefixed with "PS".</span></span>
-   <span data-ttu-id="e48c0-132">[出力マージャー ステージ](https://msdn.microsoft.com/library/windows/desktop/bb205120): 出力マージャー ステージでは、各種出力データ (ピクセル シェーダー値、深度とステンシルの情報) をレンダー ターゲットおよび深度/ステンシル バッファーのコンテンツと結合し、最終的なパイプラインの結果を生成します。</span><span class="sxs-lookup"><span data-stu-id="e48c0-132">[Output-Merger Stage](https://msdn.microsoft.com/library/windows/desktop/bb205120) - The output-merger stage combines various types of output data (pixel shader values, depth and stencil information) with the contents of the render target and depth/stencil buffers to generate the final pipeline result.</span></span> <span data-ttu-id="e48c0-133">このステージをサポートする [**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598) メソッドには、"OM" というプレフィックスが付きます。</span><span class="sxs-lookup"><span data-stu-id="e48c0-133">[**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598) methods that support this stage are prefixed with "OM".</span></span>

<span data-ttu-id="e48c0-134">(ジオメトリ シェーダー、ハル シェーダー、テッセレーター、ドメイン シェーダーのステージもありますが、OpenGL ES 2.0 には類似するものがないので、ここでは説明しません) これらのステージのメソッドの詳しい一覧については、[**ID3D11DeviceContext**](https://msdn.microsoft.com/library/windows/desktop/ff476385) と [**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598) のリファレンス ページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e48c0-134">(There are also stages for geometry shaders, hull shaders, tesselators, and domain shaders, but since they have no analogues in OpenGL ES 2.0, we won't discuss them here.) For a complete list of the methods for these stages, refer to the [**ID3D11DeviceContext**](https://msdn.microsoft.com/library/windows/desktop/ff476385) and [**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598) reference pages.</span></span> <span data-ttu-id="e48c0-135">**ID3D11DeviceContext1** は Direct3D 11 向けに **ID3D11DeviceContext** を拡張したものです。</span><span class="sxs-lookup"><span data-stu-id="e48c0-135">**ID3D11DeviceContext1** extends **ID3D11DeviceContext** for Direct3D 11.</span></span>

## <a name="creating-a-shader"></a><span data-ttu-id="e48c0-136">シェーダーの作成</span><span class="sxs-lookup"><span data-stu-id="e48c0-136">Creating a shader</span></span>


<span data-ttu-id="e48c0-137">Direct3D では、シェーダー リソースは、コンパイルと読み込みの前に作成されません。このリソースは HLSL が読み込まれたときに作成されます。</span><span class="sxs-lookup"><span data-stu-id="e48c0-137">In Direct3D, shader resources are not created before compiling and loading them; rather, the resource is created when the HLSLis loaded.</span></span> <span data-ttu-id="e48c0-138">そのため、GL\_VERTEX\_SHADER や GL\_FRAGMENT\_SHADER など、特定の型の初期化されたシェーダー リソースを作成する glCreateShader に相当する関数はありません。</span><span class="sxs-lookup"><span data-stu-id="e48c0-138">Therefore, there is no directly analogous function to glCreateShader, which creates an initialized shader resource of a specific type (such as GL\_VERTEX\_SHADER or GL\_FRAGMENT\_SHADER).</span></span> <span data-ttu-id="e48c0-139">Direct3D では、シェーダーは HLSL が [**ID3D11Device1::CreateVertexShader**](https://msdn.microsoft.com/library/windows/desktop/ff476524) や [**ID3D11Device1::CreatePixelShader**](https://msdn.microsoft.com/library/windows/desktop/ff476513) などの特定の関数で読み込まれた後で作成されます。これらの関数は、パラメーターとして型とコンパイルされた HLSL を受け取ります。</span><span class="sxs-lookup"><span data-stu-id="e48c0-139">Rather, shaders are created after the HLSL is loaded with specific functions like [**ID3D11Device1::CreateVertexShader**](https://msdn.microsoft.com/library/windows/desktop/ff476524) and [**ID3D11Device1::CreatePixelShader**](https://msdn.microsoft.com/library/windows/desktop/ff476513), and which take the type and the compiled HLSL as parameters.</span></span>

| <span data-ttu-id="e48c0-140">OpenGL ES 2.0</span><span class="sxs-lookup"><span data-stu-id="e48c0-140">OpenGL ES 2.0</span></span>  | <span data-ttu-id="e48c0-141">Direct3D 11</span><span class="sxs-lookup"><span data-stu-id="e48c0-141">Direct3D 11</span></span>                                                                                                                                                                                                                                                             |
|----------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="e48c0-142">glCreateShader</span><span class="sxs-lookup"><span data-stu-id="e48c0-142">glCreateShader</span></span> | <span data-ttu-id="e48c0-143">コンパイルされたシェーダー オブジェクトが正常に読み込まれた後で [**ID3D11Device1::CreateVertexShader**](https://msdn.microsoft.com/library/windows/desktop/ff476524) と [**ID3D11Device1::CreatePixelShader**](https://msdn.microsoft.com/library/windows/desktop/ff476513) を呼び出し、それらに CSO をバッファーとして渡します。</span><span class="sxs-lookup"><span data-stu-id="e48c0-143">Call [**ID3D11Device1::CreateVertexShader**](https://msdn.microsoft.com/library/windows/desktop/ff476524) and [**ID3D11Device1::CreatePixelShader**](https://msdn.microsoft.com/library/windows/desktop/ff476513) after successfully loading the compiled shader object, passing them the CSO as a buffer.</span></span> |

 

## <a name="compiling-a-shader"></a><span data-ttu-id="e48c0-144">シェーダーのコンパイル</span><span class="sxs-lookup"><span data-stu-id="e48c0-144">Compiling a shader</span></span>


<span data-ttu-id="e48c0-145">Direct3D のシェーダーは、ユニバーサル Windows プラットフォーム (UWP) アプリのコンパイル済みシェーダー オブジェクト (.cso) ファイルとしてプリコンパイルし、いずれかの Windows ランタイム ファイル API を使って読み込む必要があります </span><span class="sxs-lookup"><span data-stu-id="e48c0-145">Direct3D haders must be precompiled as Compiled Shader Object (.cso) files in Universal Windows Platform (UWP) apps and loaded using one of the Windows Runtime file APIs.</span></span> <span data-ttu-id="e48c0-146">(デスクトップ アプリは実行時にテキスト ファイルからのシェーダーや文字列をコンパイルできます)。CSO ファイルは、Microsoft Visual Studio プロジェクトに含まれる任意の .hlsl ファイルから作成され、同じ名前が保持されます。ただし、ファイル拡張子は .cso です。</span><span class="sxs-lookup"><span data-stu-id="e48c0-146">(Desktop apps can compile the shaders from text files or string at run-time.) The CSO files are built from any .hlsl files that are part of your Microsoft Visual Studio project, and retain the same names, only with a .cso file extension.</span></span> <span data-ttu-id="e48c0-147">出荷時に、これらがパッケージに含まれていることを確かめてください。</span><span class="sxs-lookup"><span data-stu-id="e48c0-147">Ensure that they are included with your package when you ship!</span></span>

| <span data-ttu-id="e48c0-148">OpenGL ES 2.0</span><span class="sxs-lookup"><span data-stu-id="e48c0-148">OpenGL ES 2.0</span></span>                          | <span data-ttu-id="e48c0-149">Direct3D 11</span><span class="sxs-lookup"><span data-stu-id="e48c0-149">Direct3D 11</span></span>                                                                                                                                                                   |
|----------------------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="e48c0-150">glCompileShader</span><span class="sxs-lookup"><span data-stu-id="e48c0-150">glCompileShader</span></span>                        | <span data-ttu-id="e48c0-151">なし。</span><span class="sxs-lookup"><span data-stu-id="e48c0-151">N/A.</span></span> <span data-ttu-id="e48c0-152">シェーダーを Visual Studio の .cso ファイルにコンパイルし、パッケージに含めます。</span><span class="sxs-lookup"><span data-stu-id="e48c0-152">Compile the shaders to .cso files in Visual Studio and include them in your package.</span></span>                                                                                     |
| <span data-ttu-id="e48c0-153">コンパイルの状態に glGetShaderiv を使用</span><span class="sxs-lookup"><span data-stu-id="e48c0-153">Using glGetShaderiv for compile status</span></span> | <span data-ttu-id="e48c0-154">なし。</span><span class="sxs-lookup"><span data-stu-id="e48c0-154">N/A.</span></span> <span data-ttu-id="e48c0-155">コンパイルでエラーが発生した場合は、Visual Studio の FX Compiler (FXC) からのコンパイル出力を調べてください。</span><span class="sxs-lookup"><span data-stu-id="e48c0-155">See the compilation output from Visual Studio's FX Compiler (FXC) if there are errors in compilation.</span></span> <span data-ttu-id="e48c0-156">コンパイルが成功すると、対応する CSO ファイルが作成されます。</span><span class="sxs-lookup"><span data-stu-id="e48c0-156">If compilation is successful, a corresponding CSO file is created.</span></span> |

 

## <a name="loading-a-shader"></a><span data-ttu-id="e48c0-157">シェーダーの読み込み</span><span class="sxs-lookup"><span data-stu-id="e48c0-157">Loading a shader</span></span>


<span data-ttu-id="e48c0-158">シェーダーの作成に関するセクションで触れたように、Direct3D 11 では、対応する CSO ファイルがバッファーに読み込まれ、次の表のいずれかのメソッドに渡されたときに、シェーダーを作成します。</span><span class="sxs-lookup"><span data-stu-id="e48c0-158">As noted in the section on creating a shader, Direct3D 11 creates the shader when the corresponding CSO file is loaded into a buffer and passed to one of the methods in the following table.</span></span>

| <span data-ttu-id="e48c0-159">OpenGL ES 2.0</span><span class="sxs-lookup"><span data-stu-id="e48c0-159">OpenGL ES 2.0</span></span> | <span data-ttu-id="e48c0-160">Direct3D 11</span><span class="sxs-lookup"><span data-stu-id="e48c0-160">Direct3D 11</span></span>                                                                                                                                                                                                                           |
|---------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="e48c0-161">ShaderSource</span><span class="sxs-lookup"><span data-stu-id="e48c0-161">ShaderSource</span></span>  | <span data-ttu-id="e48c0-162">コンパイルされたシェーダー オブジェクトが正常に読み込まれた後で [**ID3D11Device1::CreateVertexShader**](https://msdn.microsoft.com/library/windows/desktop/ff476524) と [**ID3D11Device1::CreatePixelShader**](https://msdn.microsoft.com/library/windows/desktop/ff476513) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="e48c0-162">Call [**ID3D11Device1::CreateVertexShader**](https://msdn.microsoft.com/library/windows/desktop/ff476524) and [**ID3D11Device1::CreatePixelShader**](https://msdn.microsoft.com/library/windows/desktop/ff476513) after successfully loading the compiled shader object.</span></span> |

 

## <a name="setting-up-the-pipeline"></a><span data-ttu-id="e48c0-163">パイプラインの設定</span><span class="sxs-lookup"><span data-stu-id="e48c0-163">Setting up the pipeline</span></span>


<span data-ttu-id="e48c0-164">OpenGL ES 2.0 には、実行のための複数のシェーダーを含む "シェーダー プログラム" オブジェクトがあります。</span><span class="sxs-lookup"><span data-stu-id="e48c0-164">OpenGL ES 2.0 has the "shader program" object, which contains multiple shaders for execution.</span></span> <span data-ttu-id="e48c0-165">個々のシェーダーはシェーダー プログラム オブジェクトにアタッチされます。</span><span class="sxs-lookup"><span data-stu-id="e48c0-165">Individual shaders are attached to the shader program object.</span></span> <span data-ttu-id="e48c0-166">ただし、Direct3D 11 では、レンダリング コンテキスト ([**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598)) を直接操作して、そのコンテキストでシェーダーを作成します。</span><span class="sxs-lookup"><span data-stu-id="e48c0-166">However, in Direct3D 11, you work with the rendering context ([**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598)) directly and create shaders on it.</span></span>

| <span data-ttu-id="e48c0-167">OpenGL ES 2.0</span><span class="sxs-lookup"><span data-stu-id="e48c0-167">OpenGL ES 2.0</span></span>   | <span data-ttu-id="e48c0-168">Direct3D 11</span><span class="sxs-lookup"><span data-stu-id="e48c0-168">Direct3D 11</span></span>                                                                                   |
|-----------------|-----------------------------------------------------------------------------------------------|
| <span data-ttu-id="e48c0-169">glCreateProgram</span><span class="sxs-lookup"><span data-stu-id="e48c0-169">glCreateProgram</span></span> | <span data-ttu-id="e48c0-170">なし。</span><span class="sxs-lookup"><span data-stu-id="e48c0-170">N/A.</span></span> <span data-ttu-id="e48c0-171">Direct3D 11 では、シェーダー プログラム オブジェクト アブストラクションは使われません。</span><span class="sxs-lookup"><span data-stu-id="e48c0-171">Direct3D 11 does not use the shader program object abstraction.</span></span>                          |
| <span data-ttu-id="e48c0-172">glLinkProgram</span><span class="sxs-lookup"><span data-stu-id="e48c0-172">glLinkProgram</span></span>   | <span data-ttu-id="e48c0-173">なし。</span><span class="sxs-lookup"><span data-stu-id="e48c0-173">N/A.</span></span> <span data-ttu-id="e48c0-174">Direct3D 11 では、シェーダー プログラム オブジェクト アブストラクションは使われません。</span><span class="sxs-lookup"><span data-stu-id="e48c0-174">Direct3D 11 does not use the shader program object abstraction.</span></span>                          |
| <span data-ttu-id="e48c0-175">glUseProgram</span><span class="sxs-lookup"><span data-stu-id="e48c0-175">glUseProgram</span></span>    | <span data-ttu-id="e48c0-176">なし。</span><span class="sxs-lookup"><span data-stu-id="e48c0-176">N/A.</span></span> <span data-ttu-id="e48c0-177">Direct3D 11 では、シェーダー プログラム オブジェクト アブストラクションは使われません。</span><span class="sxs-lookup"><span data-stu-id="e48c0-177">Direct3D 11 does not use the shader program object abstraction.</span></span>                          |
| <span data-ttu-id="e48c0-178">glGetProgramiv</span><span class="sxs-lookup"><span data-stu-id="e48c0-178">glGetProgramiv</span></span>  | <span data-ttu-id="e48c0-179">作成した、[**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598) への参照を使います。</span><span class="sxs-lookup"><span data-stu-id="e48c0-179">Use the reference you created to [**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598).</span></span> |

 

<span data-ttu-id="e48c0-180">静的な [**D3D11CreateDevice**](https://msdn.microsoft.com/library/windows/desktop/ff476082) メソッドを使って [**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598) と [**ID3D11Device1**](https://msdn.microsoft.com/library/windows/desktop/dn280493) のインスタンスを作成します。</span><span class="sxs-lookup"><span data-stu-id="e48c0-180">Create an instance of [**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/hh404598) and [**ID3D11Device1**](https://msdn.microsoft.com/library/windows/desktop/dn280493) with the static [**D3D11CreateDevice**](https://msdn.microsoft.com/library/windows/desktop/ff476082) method.</span></span>

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
  D3D11_SDK_VERSION, // Always set this to D3D11_SDK_VERSION for Windows Store apps.
  &device, // Returns the Direct3D device created.
  &m_featureLevel, // Returns feature level of device created.
  &m_d3dContext // Returns the device's immediate context.
);
```

## <a name="setting-the-viewports"></a><span data-ttu-id="e48c0-181">ビューポートの設定</span><span class="sxs-lookup"><span data-stu-id="e48c0-181">Setting the viewport(s)</span></span>


<span data-ttu-id="e48c0-182">Direct3D 11 のビューポートの設定は、OpenGL ES 2.0 でのビューポートの設定方法とよく似ています。</span><span class="sxs-lookup"><span data-stu-id="e48c0-182">Setting a viewport in Direct3D 11 is very similar to how you set a viewport in OpenGL ES 2.0.</span></span> <span data-ttu-id="e48c0-183">Direct3D 11 では、構成済みの [**CD3D11\_VIEWPORT**](https://msdn.microsoft.com/library/windows/desktop/jj151722) で [**ID3D11DeviceContext::RSSetViewports**](https://msdn.microsoft.com/library/windows/desktop/ff476480) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="e48c0-183">In Direct3D 11, call [**ID3D11DeviceContext::RSSetViewports**](https://msdn.microsoft.com/library/windows/desktop/ff476480) with a configured [**CD3D11\_VIEWPORT**](https://msdn.microsoft.com/library/windows/desktop/jj151722).</span></span>

<span data-ttu-id="e48c0-184">Direct3D 11: ビューポートを設定します。</span><span class="sxs-lookup"><span data-stu-id="e48c0-184">Direct3D 11: Setting a viewport.</span></span>

``` syntax
CD3D11_VIEWPORT viewport(
        0.0f,
        0.0f,
        m_d3dRenderTargetSize.Width,
        m_d3dRenderTargetSize.Height
        );
m_d3dContext->RSSetViewports(1, &viewport);
```

| <span data-ttu-id="e48c0-185">OpenGL ES 2.0</span><span class="sxs-lookup"><span data-stu-id="e48c0-185">OpenGL ES 2.0</span></span> | <span data-ttu-id="e48c0-186">Direct3D 11</span><span class="sxs-lookup"><span data-stu-id="e48c0-186">Direct3D 11</span></span>                                                                                                                                  |
|---------------|----------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="e48c0-187">glViewport</span><span class="sxs-lookup"><span data-stu-id="e48c0-187">glViewport</span></span>    | <span data-ttu-id="e48c0-188">[**CD3D11\_VIEWPORT**](https://msdn.microsoft.com/library/windows/desktop/jj151722), [**ID3D11DeviceContext::RSSetViewports**](https://msdn.microsoft.com/library/windows/desktop/ff476480)</span><span class="sxs-lookup"><span data-stu-id="e48c0-188">[**CD3D11\_VIEWPORT**](https://msdn.microsoft.com/library/windows/desktop/jj151722), [**ID3D11DeviceContext::RSSetViewports**](https://msdn.microsoft.com/library/windows/desktop/ff476480)</span></span> |

 

## <a name="configuring-the-vertex-shaders"></a><span data-ttu-id="e48c0-189">頂点シェーダーの構成</span><span class="sxs-lookup"><span data-stu-id="e48c0-189">Configuring the vertex shaders</span></span>


<span data-ttu-id="e48c0-190">Direct3D 11 の頂点シェーダーの構成は、シェーダーの読み込み時に行われます。</span><span class="sxs-lookup"><span data-stu-id="e48c0-190">Configuring a vertex shader in Direct3D 11 is done when the shader is loaded.</span></span> <span data-ttu-id="e48c0-191">Uniform は [**ID3D11DeviceContext1::VSSetConstantBuffers1**](https://msdn.microsoft.com/library/windows/desktop/hh446795) を使って定数バッファーとして渡されます。</span><span class="sxs-lookup"><span data-stu-id="e48c0-191">Uniforms are passed as constant buffers using [**ID3D11DeviceContext1::VSSetConstantBuffers1**](https://msdn.microsoft.com/library/windows/desktop/hh446795).</span></span>

| <span data-ttu-id="e48c0-192">OpenGL ES 2.0</span><span class="sxs-lookup"><span data-stu-id="e48c0-192">OpenGL ES 2.0</span></span>                    | <span data-ttu-id="e48c0-193">Direct3D 11</span><span class="sxs-lookup"><span data-stu-id="e48c0-193">Direct3D 11</span></span>                                                                                               |
|----------------------------------|-----------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="e48c0-194">glAttachShader</span><span class="sxs-lookup"><span data-stu-id="e48c0-194">glAttachShader</span></span>                   | [**<span data-ttu-id="e48c0-195">ID3D11Device1::CreateVertexShader</span><span class="sxs-lookup"><span data-stu-id="e48c0-195">ID3D11Device1::CreateVertexShader</span></span>**](https://msdn.microsoft.com/library/windows/desktop/ff476524)                       |
| <span data-ttu-id="e48c0-196">glGetShaderiv、glGetShaderSource</span><span class="sxs-lookup"><span data-stu-id="e48c0-196">glGetShaderiv, glGetShaderSource</span></span> | [**<span data-ttu-id="e48c0-197">ID3D11DeviceContext1::VSGetShader</span><span class="sxs-lookup"><span data-stu-id="e48c0-197">ID3D11DeviceContext1::VSGetShader</span></span>**](https://msdn.microsoft.com/library/windows/desktop/ff476489)                       |
| <span data-ttu-id="e48c0-198">glGetUniformfv、glGetUniformiv</span><span class="sxs-lookup"><span data-stu-id="e48c0-198">glGetUniformfv, glGetUniformiv</span></span>   | <span data-ttu-id="e48c0-199">[**ID3D11DeviceContext1::VSGetConstantBuffers1**](https://msdn.microsoft.com/library/windows/desktop/hh446793)</span><span class="sxs-lookup"><span data-stu-id="e48c0-199">[**ID3D11DeviceContext1::VSGetConstantBuffers1**](https://msdn.microsoft.com/library/windows/desktop/hh446793).</span></span> |

 

## <a name="configuring-the-pixel-shaders"></a><span data-ttu-id="e48c0-200">ピクセル シェーダーの構成</span><span class="sxs-lookup"><span data-stu-id="e48c0-200">Configuring the pixel shaders</span></span>


<span data-ttu-id="e48c0-201">Direct3D 11 のピクセル シェーダーの構成は、シェーダーの読み込み時に行われます。</span><span class="sxs-lookup"><span data-stu-id="e48c0-201">Configuring a pixel shader in Direct3D 11 is done when the shader is loaded.</span></span> <span data-ttu-id="e48c0-202">Uniform は [**ID3D11DeviceContext1::PSSetConstantBuffers1**](https://msdn.microsoft.com/library/windows/desktop/hh404649) を使って定数バッファーとして渡されます。</span><span class="sxs-lookup"><span data-stu-id="e48c0-202">Uniforms are passed as constant buffers using [**ID3D11DeviceContext1::PSSetConstantBuffers1.**](https://msdn.microsoft.com/library/windows/desktop/hh404649)</span></span>

| <span data-ttu-id="e48c0-203">OpenGL ES 2.0</span><span class="sxs-lookup"><span data-stu-id="e48c0-203">OpenGL ES 2.0</span></span>                    | <span data-ttu-id="e48c0-204">Direct3D 11</span><span class="sxs-lookup"><span data-stu-id="e48c0-204">Direct3D 11</span></span>                                                                                               |
|----------------------------------|-----------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="e48c0-205">glAttachShader</span><span class="sxs-lookup"><span data-stu-id="e48c0-205">glAttachShader</span></span>                   | [**<span data-ttu-id="e48c0-206">ID3D11Device1::CreatePixelShader</span><span class="sxs-lookup"><span data-stu-id="e48c0-206">ID3D11Device1::CreatePixelShader</span></span>**](https://msdn.microsoft.com/library/windows/desktop/ff476513)                         |
| <span data-ttu-id="e48c0-207">glGetShaderiv、glGetShaderSource</span><span class="sxs-lookup"><span data-stu-id="e48c0-207">glGetShaderiv, glGetShaderSource</span></span> | [**<span data-ttu-id="e48c0-208">ID3D11DeviceContext1::PSGetShader</span><span class="sxs-lookup"><span data-stu-id="e48c0-208">ID3D11DeviceContext1::PSGetShader</span></span>**](https://msdn.microsoft.com/library/windows/desktop/ff476468)                       |
| <span data-ttu-id="e48c0-209">glGetUniformfv、glGetUniformiv</span><span class="sxs-lookup"><span data-stu-id="e48c0-209">glGetUniformfv, glGetUniformiv</span></span>   | <span data-ttu-id="e48c0-210">[**ID3D11DeviceContext1::PSGetConstantBuffers1**](https://msdn.microsoft.com/library/windows/desktop/hh404645)</span><span class="sxs-lookup"><span data-stu-id="e48c0-210">[**ID3D11DeviceContext1::PSGetConstantBuffers1**](https://msdn.microsoft.com/library/windows/desktop/hh404645).</span></span> |

 

## <a name="generating-the-final-results"></a><span data-ttu-id="e48c0-211">最終結果の生成</span><span class="sxs-lookup"><span data-stu-id="e48c0-211">Generating the final results</span></span>


<span data-ttu-id="e48c0-212">パイプラインが完了したら、バック バッファーにシェーダー ステージの結果を描画します。</span><span class="sxs-lookup"><span data-stu-id="e48c0-212">When the pipeline completes, you draw the results of the shader stages into the back buffer.</span></span> <span data-ttu-id="e48c0-213">Direct3D 11 では、このとき、描画コマンドを呼び出して結果をバック バッファーのカラー マップとして出力し、そのバック バッファーをディスプレイに送信します。これは Open GL ES 2.0 と同様です。</span><span class="sxs-lookup"><span data-stu-id="e48c0-213">In Direct3D 11, just as it is with Open GL ES 2.0, this involves calling a draw command to output the results as a color map in the back buffer, and thensending that back buffer to the display.</span></span>

| <span data-ttu-id="e48c0-214">OpenGL ES 2.0</span><span class="sxs-lookup"><span data-stu-id="e48c0-214">OpenGL ES 2.0</span></span>  | <span data-ttu-id="e48c0-215">Direct3D 11</span><span class="sxs-lookup"><span data-stu-id="e48c0-215">Direct3D 11</span></span>                                                                                                                                                                                                                                         |
|----------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="e48c0-216">glDrawElements</span><span class="sxs-lookup"><span data-stu-id="e48c0-216">glDrawElements</span></span> | <span data-ttu-id="e48c0-217">[**ID3D11DeviceContext1::Draw**](https://msdn.microsoft.com/library/windows/desktop/ff476407)、[**ID3D11DeviceContext1::DrawIndexed**](https://msdn.microsoft.com/library/windows/desktop/ff476409) (または [**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/ff476385) の他の Draw\* メソッド)</span><span class="sxs-lookup"><span data-stu-id="e48c0-217">[**ID3D11DeviceContext1::Draw**](https://msdn.microsoft.com/library/windows/desktop/ff476407), [**ID3D11DeviceContext1::DrawIndexed**](https://msdn.microsoft.com/library/windows/desktop/ff476409) (or other Draw\* methods on [**ID3D11DeviceContext1**](https://msdn.microsoft.com/library/windows/desktop/ff476385)).</span></span> |
| <span data-ttu-id="e48c0-218">eglSwapBuffers</span><span class="sxs-lookup"><span data-stu-id="e48c0-218">eglSwapBuffers</span></span> | [**<span data-ttu-id="e48c0-219">IDXGISwapChain1::Present1</span><span class="sxs-lookup"><span data-stu-id="e48c0-219">IDXGISwapChain1::Present1</span></span>**](https://msdn.microsoft.com/library/windows/desktop/hh446797)                                                                                                                                                                              |

 

## <a name="porting-glsl-to-hlsl"></a><span data-ttu-id="e48c0-220">HLSL への GLSL の移植</span><span class="sxs-lookup"><span data-stu-id="e48c0-220">Porting GLSL to HLSL</span></span>


<span data-ttu-id="e48c0-221">GLSL と HLSL は、複合型のサポートと全体的な構文以外はそれほど違いません。</span><span class="sxs-lookup"><span data-stu-id="e48c0-221">GLSL and HLSL are not very different beyond complex type support and syntax some overall syntax.</span></span> <span data-ttu-id="e48c0-222">最も簡単な移植方法は、一般的な OpenGL ES 2.0 の命令と定義を HLSL の対応する要素にエイリアシングすることです。</span><span class="sxs-lookup"><span data-stu-id="e48c0-222">Many developers find it easiest to port between the two by aliasing common OpenGL ES 2.0 instructions and definitions to their HLSL equivalent.</span></span> <span data-ttu-id="e48c0-223">グラフィックス インターフェイスでサポートされる HLSL の機能セットを表現するために、Direct3D ではシェーダー モデル バージョンを使います。OpenGL には、HLSL 向けに異なるバージョン仕様があります。</span><span class="sxs-lookup"><span data-stu-id="e48c0-223">Note that Direct3D uses the Shader Model version to express the feature set of the HLSL supported by a graphics interface; OpenGL has a different version specification for HLSL.</span></span> <span data-ttu-id="e48c0-224">次の表では、他のバージョンの観点から、Direct3D 11 と OpenGL ES 2.0 に対して定義されているシェーダー言語機能セットについて、簡単に示します。</span><span class="sxs-lookup"><span data-stu-id="e48c0-224">The following table attempts to give you some approximate idea of the shader language feature sets defined for Direct3D 11 and OpenGL ES 2.0 in the terms of the other's version.</span></span>

| <span data-ttu-id="e48c0-225">シェーダー言語</span><span class="sxs-lookup"><span data-stu-id="e48c0-225">Shader language</span></span>           | <span data-ttu-id="e48c0-226">GLSL 機能バージョン</span><span class="sxs-lookup"><span data-stu-id="e48c0-226">GLSL feature version</span></span>                                                                                                                                                                                                      | <span data-ttu-id="e48c0-227">Direct3D シェーダー モデル</span><span class="sxs-lookup"><span data-stu-id="e48c0-227">Direct3D Shader Model</span></span> |
|---------------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|-----------------------|
| <span data-ttu-id="e48c0-228">Direct3D 11 HLSL</span><span class="sxs-lookup"><span data-stu-id="e48c0-228">Direct3D 11 HLSL</span></span>          | <span data-ttu-id="e48c0-229">～ 4.30。</span><span class="sxs-lookup"><span data-stu-id="e48c0-229">~4.30.</span></span>                                                                                                                                                                                                                    | <span data-ttu-id="e48c0-230">SM 5.0</span><span class="sxs-lookup"><span data-stu-id="e48c0-230">SM 5.0</span></span>                |
| <span data-ttu-id="e48c0-231">OpenGL ES 2.0 向けの GLSL ES</span><span class="sxs-lookup"><span data-stu-id="e48c0-231">GLSL ES for OpenGL ES 2.0</span></span> | <span data-ttu-id="e48c0-232">1.40。</span><span class="sxs-lookup"><span data-stu-id="e48c0-232">1.40.</span></span> <span data-ttu-id="e48c0-233">OpenGL ES 2.0 向けの GLSL ES の以前の実装では、1.10 から 1.30 までを使用できます。</span><span class="sxs-lookup"><span data-stu-id="e48c0-233">Older implementations of GLSL ES for OpenGL ES 2.0 may use 1.10 through 1.30.</span></span> <span data-ttu-id="e48c0-234">glGetString(GL\_SHADING\_LANGUAGE\_VERSION) または glGetString(SHADING\_LANGUAGE\_VERSION) で元のコードをチェックし、バージョンを調べてください。</span><span class="sxs-lookup"><span data-stu-id="e48c0-234">Check your original code with glGetString(GL\_SHADING\_LANGUAGE\_VERSION) or glGetString(SHADING\_LANGUAGE\_VERSION) to determine it.</span></span> | <span data-ttu-id="e48c0-235">～ SM 2.0</span><span class="sxs-lookup"><span data-stu-id="e48c0-235">~SM 2.0</span></span>               |

 

<span data-ttu-id="e48c0-236">2 つのシェーダー言語の違いと一般的な構文のマッピングについて詳しくは、「[GLSL と HLSL の対応を示すリファレンス](glsl-to-hlsl-reference.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e48c0-236">For more details of differences between the two shader languages, as well as common syntax mappings, read the [GLSL-to-HLSL reference](glsl-to-hlsl-reference.md).</span></span>

## <a name="porting-the-opengl-intrinsics-to-hlsl-semantics"></a><span data-ttu-id="e48c0-237">HLSL セマンティクスへの OpenGL 組み込みメソッドの移植</span><span class="sxs-lookup"><span data-stu-id="e48c0-237">Porting the OpenGL intrinsics to HLSL semantics</span></span>


<span data-ttu-id="e48c0-238">Direct3D 11 HLSL セマンティクスは、uniform や属性名と同様に、アプリとシェーダー プログラムの間で渡される値を識別するために使われる文字列です。</span><span class="sxs-lookup"><span data-stu-id="e48c0-238">Direct3D 11 HLSL semantics are strings that, like a uniform or attribute name, are used to identify a value passed between the app and a shader program.</span></span> <span data-ttu-id="e48c0-239">使用できる文字列はさまざまですが、用途を示す文字列 (POSITION、COLOR など) を使うことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="e48c0-239">While they can be any of a variety of possible strings, the best practice is to use a string like POSITION or COLOR that indicates the usage.</span></span> <span data-ttu-id="e48c0-240">これらのセマンティクスは、定数バッファーまたはバッファー入力レイアウトを構成する際に割り当てます。</span><span class="sxs-lookup"><span data-stu-id="e48c0-240">You assign these semantics when you are constructing a constant buffer or buffer input layout.</span></span> <span data-ttu-id="e48c0-241">類似する値に別のレジスタを使うために、セマンティクスに 0 ～ 7 の範囲の数値を追加できます。</span><span class="sxs-lookup"><span data-stu-id="e48c0-241">You can also append a number between 0 and 7 to the semantic so that you use separate registers for similar values.</span></span> <span data-ttu-id="e48c0-242">COLOR0、COLOR1、COLOR2 などです。</span><span class="sxs-lookup"><span data-stu-id="e48c0-242">For example: COLOR0, COLOR1, COLOR2...</span></span>

<span data-ttu-id="e48c0-243">"SV\_" というプレフィックスが付いたセマンティクスは、シェーダー プログラムによって書き込みが行われるシステム値のセマンティクスです。CPU 上で実行されているアプリ自体で変更することはできません。</span><span class="sxs-lookup"><span data-stu-id="e48c0-243">Semantics that are prefixed with "SV\_" are system value semantics that are written to by your shader program; your app itself (running on the CPU) cannot modify them.</span></span> <span data-ttu-id="e48c0-244">通常、これらには、グラフィックス パイプラインの別のシェーダー ステージからの入出力値のほか、GPU のみによって生成された値が含まれます。</span><span class="sxs-lookup"><span data-stu-id="e48c0-244">Typically, these contain values that are inputs or outputs from another shader stage in the graphics pipeline, or are generated entirely by the GPU.</span></span>

<span data-ttu-id="e48c0-245">また、SV\_ セマンティクスは、シェーダー ステージとの間の入出力を指定するために使われた場合、異なる動作を持ちます。</span><span class="sxs-lookup"><span data-stu-id="e48c0-245">Additionally, SV\_ semantics have different behaviors when they are used to specify input to or output from a shader stage.</span></span> <span data-ttu-id="e48c0-246">たとえば、SV\_POSITION (出力) には頂点シェーダー ステージで変換された頂点データが含まれ、SV\_POSITION (入力) にはラスタライズ時に補間されたピクセル位置の値が含まれます。</span><span class="sxs-lookup"><span data-stu-id="e48c0-246">For example, SV\_POSITION (output) contains the vertex data transformed during the vertex shader stage, and SV\_POSITION (input) contains the pixel position values interpolated during rasterization.</span></span>

<span data-ttu-id="e48c0-247">次に、一般的な OpenGL ES 2.0 シェーダー組み込みメソッドのマッピングをいくつか示します。</span><span class="sxs-lookup"><span data-stu-id="e48c0-247">Here are a few mappings for common OpenGL ES 2.0 shader instrinsics:</span></span>

| <span data-ttu-id="e48c0-248">OpenGL のシステム値</span><span class="sxs-lookup"><span data-stu-id="e48c0-248">OpenGL system value</span></span> | <span data-ttu-id="e48c0-249">使用する HLSL セマンティック</span><span class="sxs-lookup"><span data-stu-id="e48c0-249">Use this HLSL Semantic</span></span>                                                                                                                                                   |
|---------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="e48c0-250">gl\_Position</span><span class="sxs-lookup"><span data-stu-id="e48c0-250">gl\_Position</span></span>        | <span data-ttu-id="e48c0-251">頂点バッファー データを表す POSITION(n)。</span><span class="sxs-lookup"><span data-stu-id="e48c0-251">POSITION(n) for vertex buffer data.</span></span> <span data-ttu-id="e48c0-252">SV\_POSITION は、ピクセル シェーダーにピクセル位置を提供します。アプリで書き込むことはできません。</span><span class="sxs-lookup"><span data-stu-id="e48c0-252">SV\_POSITION provides a pixel position to the pixel shader and cannot be written by your app.</span></span>                                        |
| <span data-ttu-id="e48c0-253">gl\_Normal</span><span class="sxs-lookup"><span data-stu-id="e48c0-253">gl\_Normal</span></span>          | <span data-ttu-id="e48c0-254">頂点バッファーによって提供される標準データを表す NORMAL(n)。</span><span class="sxs-lookup"><span data-stu-id="e48c0-254">NORMAL(n) for normal data provided by the vertex buffer.</span></span>                                                                                                                 |
| <span data-ttu-id="e48c0-255">gl\_TexCoord\[n\]</span><span class="sxs-lookup"><span data-stu-id="e48c0-255">gl\_TexCoord\[n\]</span></span>   | <span data-ttu-id="e48c0-256">シェーダーに提供されるテクスチャ UV (一部の OpenGL のドキュメントでは ST) 座標データを表す TEXCOORD(n)。</span><span class="sxs-lookup"><span data-stu-id="e48c0-256">TEXCOORD(n) for texture UV (ST in some OpenGL documentation) coordinate data supplied to a shader.</span></span>                                                                       |
| <span data-ttu-id="e48c0-257">gl\_FragColor</span><span class="sxs-lookup"><span data-stu-id="e48c0-257">gl\_FragColor</span></span>       | <span data-ttu-id="e48c0-258">シェーダーに提供される RGBA カラー データを表す COLOR(n)。</span><span class="sxs-lookup"><span data-stu-id="e48c0-258">COLOR(n) for RGBA color data supplied to a shader.</span></span> <span data-ttu-id="e48c0-259">座標データと同様に処理されることに注意してください。このセマンティクスは、単に色データであることを示すために使用します。</span><span class="sxs-lookup"><span data-stu-id="e48c0-259">Note that it is treated identically to coordinate data; the semantic simply helps you identify that it is color data.</span></span> |
| <span data-ttu-id="e48c0-260">gl\_FragData\[n\]</span><span class="sxs-lookup"><span data-stu-id="e48c0-260">gl\_FragData\[n\]</span></span>   | <span data-ttu-id="e48c0-261">ピクセル シェーダーからターゲット テクスチャまたはその他のピクセル バッファーへの書き込みを表す SV\_Target\[n\]。</span><span class="sxs-lookup"><span data-stu-id="e48c0-261">SV\_Target\[n\] for writing from a pixel shader to a target texture or other pixel buffer.</span></span>                                                                               |

 

<span data-ttu-id="e48c0-262">セマンティクスのコーディングに使うメソッドは、OpenGL ES 2.0 での組み込みメソッドの使用と同じではありません。</span><span class="sxs-lookup"><span data-stu-id="e48c0-262">The method by which you code for semantics is not the same as using intrinsics in OpenGL ES 2.0.</span></span> <span data-ttu-id="e48c0-263">OpenGL では、構成または宣言なしで組み込みメソッドの多くに直接アクセスできます。Direct3D では、特定のセマンティクスを使うために、特定の定数バッファーでフィールドを宣言するか、シェーダーの **main()** メソッドの戻り値として宣言する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e48c0-263">In OpenGL, you can access many of the intrinsics directly without any configuration or declaration; in Direct3D, you must declare a field in a specific constant buffer to use a particular semantic, or you declare it as the return value for a shader's **main()** method.</span></span>

<span data-ttu-id="e48c0-264">定数バッファーの定義で使われるセマンティックの例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="e48c0-264">Here's an example of a semantic used in a constant buffer definition:</span></span>

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

<span data-ttu-id="e48c0-265">このコードは、単純な定数バッファーのペアを定義します。</span><span class="sxs-lookup"><span data-stu-id="e48c0-265">This code defines a pair of simple constant buffers</span></span>

<span data-ttu-id="e48c0-266">フラグメント シェーダーによって返される値を定義するために使われるセマンティックの例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="e48c0-266">And here's an example of a semantic used to define the value returned by a fragment shader:</span></span>

```cpp
// A pass-through for the (interpolated) color data.
float4 main(PixelShaderInput input) : SV_TARGET
{
  return float4(input.color,1.0f);
}
```

<span data-ttu-id="e48c0-267">この場合、SV\_TARGET は、シェーダーの実行の完了時に、ピクセルの色 (4 つの浮動小数点値を持つベクターとして定義) が書き込まれるレンダー ターゲットの場所です。</span><span class="sxs-lookup"><span data-stu-id="e48c0-267">In this case, SV\_TARGET is the location of the render target that the pixel color (defined as a vector with four float values) is written to when the shader completes execution.</span></span>

<span data-ttu-id="e48c0-268">Direct3D でのセマンティクスの使用について詳しくは、「[HLSL セマンティクス](https://msdn.microsoft.com/library/windows/desktop/bb509647)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e48c0-268">For more details on the use of semantics with Direct3D, read [HLSL Semantics](https://msdn.microsoft.com/library/windows/desktop/bb509647).</span></span>

 

 




