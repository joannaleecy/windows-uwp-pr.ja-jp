---
author: mtoepke
title: GLSL と HLSL の対応を示すリファレンス
description: グラフィックス アーキテクチャを OpenGL ES 2.0 から Direct3D 11 に移植してユニバーサル Windows プラットフォーム (UWP) 向けのゲームを作成する際は、OpenGL シェーダー言語 (GLSL) コードを Microsoft 上位レベル シェーダー言語 (HLSL) コードに移植します。
ms.assetid: 979d19f6-ef0c-64e4-89c2-a31e1c7b7692
ms.author: mtoepke
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, GLSL, HLSL, OpenGL, DirectX, シェーダー
ms.localizationpriority: medium
ms.openlocfilehash: 30c925f9ebb07d578147dfba373fdeb3baa364fe
ms.sourcegitcommit: e38b334edb82bf2b1474ba686990f4299b8f59c7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/15/2018
ms.locfileid: "6838919"
---
# <a name="glsl-to-hlsl-reference"></a><span data-ttu-id="9a92a-104">GLSL と HLSL の対応を示すリファレンス</span><span class="sxs-lookup"><span data-stu-id="9a92a-104">GLSL-to-HLSL reference</span></span>



<span data-ttu-id="9a92a-105">[グラフィックス アーキテクチャを OpenGL ES 2.0 から Direct3D 11 に移植して](port-from-opengl-es-2-0-to-directx-11-1.md)ユニバーサル Windows プラットフォーム (UWP) 向けのゲームを作成する際は、OpenGL シェーダー言語 (GLSL) コードを Microsoft 上位レベル シェーダー言語 (HLSL) コードに移植します。</span><span class="sxs-lookup"><span data-stu-id="9a92a-105">You port your OpenGL Shader Language (GLSL) code to Microsoft High Level Shader Language (HLSL) code when you [port your graphics architecture from OpenGL ES 2.0 to Direct3D 11](port-from-opengl-es-2-0-to-directx-11-1.md) to create a game for Universal Windows Platform (UWP).</span></span> <span data-ttu-id="9a92a-106">ここで参照される GLSL は OpenGL ES 2.0 とは互換性がありません。HLSL は Direct3D 11 と互換性があります。</span><span class="sxs-lookup"><span data-stu-id="9a92a-106">The GLSL that is referred to herein is compatible with OpenGL ES 2.0; the HLSL is compatible with Direct3D 11.</span></span> <span data-ttu-id="9a92a-107">Direct3D 11 と以前のバージョンの Direct3D の違いについては、「[機能のマッピング](feature-mapping.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9a92a-107">For info about the differences between Direct3D 11 and previous versions of Direct3D, see [Feature mapping](feature-mapping.md).</span></span>

-   [<span data-ttu-id="9a92a-108">OpenGL ES 2.0 と Direct3D 11 の比較</span><span class="sxs-lookup"><span data-stu-id="9a92a-108">Comparing OpenGL ES 2.0 with Direct3D 11</span></span>](#comparing-opengl-es-20-with-direct3d-11)
-   [<span data-ttu-id="9a92a-109">HLSL への GLSL 変数の移植</span><span class="sxs-lookup"><span data-stu-id="9a92a-109">Porting GLSL variables to HLSL</span></span>](#porting-glsl-variables-to-hlsl)
-   [<span data-ttu-id="9a92a-110">HLSL への GLSL の型の移植</span><span class="sxs-lookup"><span data-stu-id="9a92a-110">Porting GLSL types to HLSL</span></span>](#porting-glsl-types-to-hlsl)
-   [<span data-ttu-id="9a92a-111">HLSL への GLSL の定義済みグローバル変数の移植</span><span class="sxs-lookup"><span data-stu-id="9a92a-111">Porting GLSL pre-defined global variables to HLSL</span></span>](#porting-glsl-pre-defined-global-variables-to-hlsl)
-   [<span data-ttu-id="9a92a-112">HLSL への GLSL 変数の移植の例</span><span class="sxs-lookup"><span data-stu-id="9a92a-112">Examples of porting GLSL variables to HLSL</span></span>](#examples-of-porting-glsl-variables-to-hlsl)
    -   [<span data-ttu-id="9a92a-113">GLSL での uniform、attribute、および varying</span><span class="sxs-lookup"><span data-stu-id="9a92a-113">Uniform, attribute, and varying in GLSL</span></span>](#uniform-attribute-and-varying-in-glsl)
    -   [<span data-ttu-id="9a92a-114">HLSL での定数バッファーとデータ転送</span><span class="sxs-lookup"><span data-stu-id="9a92a-114">Constant buffers and data transfers in HLSL</span></span>](#constant-buffers-and-data-transfers-in-hlsl)
-   [<span data-ttu-id="9a92a-115">Direct3D への OpenGL のレンダリング コードの移植例</span><span class="sxs-lookup"><span data-stu-id="9a92a-115">Examples of porting OpenGL rendering code to Direct3D</span></span>](#examples-of-porting-opengl-rendering-code-to-direct3d)
-   [<span data-ttu-id="9a92a-116">関連トピック</span><span class="sxs-lookup"><span data-stu-id="9a92a-116">Related topics</span></span>](#related-topics)

## <a name="comparing-opengl-es-20-with-direct3d-11"></a><span data-ttu-id="9a92a-117">OpenGL ES 2.0 と Direct3D 11 の比較</span><span class="sxs-lookup"><span data-stu-id="9a92a-117">Comparing OpenGL ES 2.0 with Direct3D 11</span></span>


<span data-ttu-id="9a92a-118">OpenGL ES 2.0 と Direct3D 11 には多くの類似点があります。</span><span class="sxs-lookup"><span data-stu-id="9a92a-118">OpenGL ES 2.0 and Direct3D 11 have many similarities.</span></span> <span data-ttu-id="9a92a-119">どちらも、類似したレンダリング パイプラインとグラフィックス機能があります。</span><span class="sxs-lookup"><span data-stu-id="9a92a-119">They both have similar rendering pipelines and graphics features.</span></span> <span data-ttu-id="9a92a-120">ただし、Direct3D 11 はレンダリングの実装と API であり、仕様ではありません。OpenGL ES 2.0 はレンダリングの仕様と API であり、実装ではありません。</span><span class="sxs-lookup"><span data-stu-id="9a92a-120">But Direct3D 11 is a rendering implementation and API, not a specification; OpenGL ES 2.0 is a rendering specification and API, not an implementation.</span></span> <span data-ttu-id="9a92a-121">Direct3D 11 と OpenGL ES 2.0 は通常、次の点で異なります。</span><span class="sxs-lookup"><span data-stu-id="9a92a-121">Direct3D 11 and OpenGL ES 2.0 generally differ in these ways:</span></span>

| <span data-ttu-id="9a92a-122">OpenGL ES 2.0</span><span class="sxs-lookup"><span data-stu-id="9a92a-122">OpenGL ES 2.0</span></span>                                                                                         | <span data-ttu-id="9a92a-123">Direct3D 11</span><span class="sxs-lookup"><span data-stu-id="9a92a-123">Direct3D 11</span></span>                                                                                                            |
|-------------------------------------------------------------------------------------------------------|------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="9a92a-124">ハードウェアやオペレーティング システムにとらわれない仕様とベンダーが提供する実装</span><span class="sxs-lookup"><span data-stu-id="9a92a-124">Hardware and operating system agnostic specification with vendor provided implementations</span></span>             | <span data-ttu-id="9a92a-125">Windows プラットフォームのハードウェア アブストラクションと認定の Microsoft 実装</span><span class="sxs-lookup"><span data-stu-id="9a92a-125">Microsoft implementation of hardware abstraction and certification on Windows platforms</span></span>                                |
| <span data-ttu-id="9a92a-126">多様なハードウェア向けに抽象化、ランタイムがほとんどのリソースを管理</span><span class="sxs-lookup"><span data-stu-id="9a92a-126">Abstracted for hardware diversity, runtime manages most resources</span></span>                                     | <span data-ttu-id="9a92a-127">ハードウェアのレイアウトに直接アクセス。アプリがリソースと処理を管理できる</span><span class="sxs-lookup"><span data-stu-id="9a92a-127">Direct access to hardware layout; app can manage resources and processing</span></span>                                              |
| <span data-ttu-id="9a92a-128">サード パーティのライブラリ (たとえば、Simple DirectMedia Layer (SDL)) によって高レベルのモジュールを提供</span><span class="sxs-lookup"><span data-stu-id="9a92a-128">Provides higher-level modules via third-party libraries (for example, Simple DirectMedia Layer (SDL))</span></span> | <span data-ttu-id="9a92a-129">Direct2D などの高レベルのモジュールは下位モジュールに基づいて構築されるため、Windows アプリの開発が簡略化</span><span class="sxs-lookup"><span data-stu-id="9a92a-129">Higher-level modules, like Direct2D, are built upon lower modules to simplify development for Windows apps</span></span>             |
| <span data-ttu-id="9a92a-130">ハードウェア ベンダーは拡張子によって区別</span><span class="sxs-lookup"><span data-stu-id="9a92a-130">Hardware vendors differentiate via extensions</span></span>                                                         | <span data-ttu-id="9a92a-131">Microsoft は、汎用的な方法で API にオプション機能を追加するため、特定のハードウェア ベンダーに限定されない</span><span class="sxs-lookup"><span data-stu-id="9a92a-131">Microsoft adds optional features to the API in a generic way so they aren't specific to any particular hardware vendor</span></span> |

 

<span data-ttu-id="9a92a-132">GLSL と HLSL は一般に次の点で異なります。</span><span class="sxs-lookup"><span data-stu-id="9a92a-132">GLSL and HLSL generally differ in these ways:</span></span>

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="9a92a-133">GLSL</span><span class="sxs-lookup"><span data-stu-id="9a92a-133">GLSL</span></span></th>
<th align="left"><span data-ttu-id="9a92a-134">HLSL</span><span class="sxs-lookup"><span data-stu-id="9a92a-134">HLSL</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="9a92a-135">手続き型、ステップ中心 (C など)</span><span class="sxs-lookup"><span data-stu-id="9a92a-135">Procedural, step-centric (C like)</span></span></td>
<td align="left"><span data-ttu-id="9a92a-136">オブジェクト指向、データ中心 (C++ など)</span><span class="sxs-lookup"><span data-stu-id="9a92a-136">Object oriented, data-centric (C++ like)</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="9a92a-137">グラフィックス API に統合されたシェーダー コンパイル</span><span class="sxs-lookup"><span data-stu-id="9a92a-137">Shader compilation integrated into the graphics API</span></span></td>
<td align="left"><span data-ttu-id="9a92a-138">HLSL コンパイラが中間バイナリ表現に<a href="https://msdn.microsoft.com/library/windows/desktop/bb509633">シェーダーをコンパイルし</a>、その後で Direct3D がそれをドライバーに渡します。</span><span class="sxs-lookup"><span data-stu-id="9a92a-138">The HLSL compiler <a href="https://msdn.microsoft.com/library/windows/desktop/bb509633">compiles the shader</a> to an intermediate binary representation before Direct3D passes it to the driver.</span></span>
<div class="alert"><span data-ttu-id="9a92a-139">
<strong>注:</strong>このバイナリ表現はハードウェアに依存しません。</span><span class="sxs-lookup"><span data-stu-id="9a92a-139">
<strong>Note</strong>This binary representation is hardware independent.</span></span> <span data-ttu-id="9a92a-140">通常はアプリの実行時ではなくアプリのビルド時にコンパイルされます。</span><span class="sxs-lookup"><span data-stu-id="9a92a-140">It's typically compiled at app build time, rather than at app run time.</span></span>
</div>
<div>
 
</div></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="9a92a-141"><a href="#porting-glsl-variables-to-hlsl">変数</a>ストレージ修飾子</span><span class="sxs-lookup"><span data-stu-id="9a92a-141"><a href="#porting-glsl-variables-to-hlsl">Variable</a> storage modifiers</span></span></td>
<td align="left"><span data-ttu-id="9a92a-142">入力レイアウトの宣言による定数バッファーとデータ転送</span><span class="sxs-lookup"><span data-stu-id="9a92a-142">Constant buffers and data transfers via input layout declarations</span></span></td>
</tr>
<tr class="even">
<td align="left"><p><a href="#porting-glsl-types-to-hlsl"><span data-ttu-id="9a92a-143">型</span><span class="sxs-lookup"><span data-stu-id="9a92a-143">Types</span></span></a></p>
<p><span data-ttu-id="9a92a-144">一般的なベクター型: vec2/3/4</span><span class="sxs-lookup"><span data-stu-id="9a92a-144">Typical vector type: vec2/3/4</span></span></p>
<p><span data-ttu-id="9a92a-145">lowp、mediump、highp</span><span class="sxs-lookup"><span data-stu-id="9a92a-145">lowp, mediump, highp</span></span></p></td>
<td align="left"><p><span data-ttu-id="9a92a-146">一般的なベクター型: float2/3/4</span><span class="sxs-lookup"><span data-stu-id="9a92a-146">Typical vector type: float2/3/4</span></span></p>
<p><span data-ttu-id="9a92a-147">min10float、min16float</span><span class="sxs-lookup"><span data-stu-id="9a92a-147">min10float, min16float</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="9a92a-148">texture2D [Function]</span><span class="sxs-lookup"><span data-stu-id="9a92a-148">texture2D [Function]</span></span></td>
<td align="left"><span data-ttu-id="9a92a-149"><a href="https://msdn.microsoft.com/library/windows/desktop/bb509695">texture.Sample</a> [datatype.Function]</span><span class="sxs-lookup"><span data-stu-id="9a92a-149"><a href="https://msdn.microsoft.com/library/windows/desktop/bb509695">texture.Sample</a> [datatype.Function]</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="9a92a-150">sampler2D [datatype]</span><span class="sxs-lookup"><span data-stu-id="9a92a-150">sampler2D [datatype]</span></span></td>
<td align="left"><span data-ttu-id="9a92a-151"><a href="https://msdn.microsoft.com/library/windows/desktop/ff471525">Texture2D</a> [datatype]</span><span class="sxs-lookup"><span data-stu-id="9a92a-151"><a href="https://msdn.microsoft.com/library/windows/desktop/ff471525">Texture2D</a> [datatype]</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="9a92a-152">行優先マトリックス (既定)</span><span class="sxs-lookup"><span data-stu-id="9a92a-152">Row-major matrices (default)</span></span></td>
<td align="left"><span data-ttu-id="9a92a-153">列優先マトリックス (既定)</span><span class="sxs-lookup"><span data-stu-id="9a92a-153">Column-major matrices (default)</span></span>
<div class="alert"><span data-ttu-id="9a92a-154">
<strong>注:</strong>  <strong>row_major</strong>の種類の修飾子を使用して、1 つの変数のレイアウトを変更します。</span><span class="sxs-lookup"><span data-stu-id="9a92a-154">
<strong>Note</strong> Use the <strong>row_major</strong> type-modifier to change the layout for one variable.</span></span> <span data-ttu-id="9a92a-155">詳しくは、「<a href="https://msdn.microsoft.com/library/windows/desktop/bb509706">変数の構文</a>」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9a92a-155">For more info, see <a href="https://msdn.microsoft.com/library/windows/desktop/bb509706">Variable Syntax</a>.</span></span> <span data-ttu-id="9a92a-156">コンパイラ フラグまたはプラグマを指定してグローバルな既定値を変更することもできます。</span><span class="sxs-lookup"><span data-stu-id="9a92a-156">You can also specify a compiler flag or a pragma to change the global default.</span></span>
</div>
<div>
 
</div></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="9a92a-157">フラグメント シェーダー</span><span class="sxs-lookup"><span data-stu-id="9a92a-157">Fragment shader</span></span></td>
<td align="left"><span data-ttu-id="9a92a-158">ピクセル シェーダー</span><span class="sxs-lookup"><span data-stu-id="9a92a-158">Pixel shader</span></span></td>
</tr>
</tbody>
</table>

 

> <span data-ttu-id="9a92a-159">**注:** HLSL がテクスチャとサンプラーとして 2 つのオブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="9a92a-159">**Note**HLSL has textures and samplers as two separate objects.</span></span> <span data-ttu-id="9a92a-160">GLSL では、Direct3D 9 と同様に、テクスチャのバインドはサンプラーの状態の一部です。</span><span class="sxs-lookup"><span data-stu-id="9a92a-160">In GLSL, like Direct3D 9, the texture binding is part of the sampler state.</span></span>

 

<span data-ttu-id="9a92a-161">GLSL では、事前定義されたグローバル変数として OpenGL の状態の多くを示します。</span><span class="sxs-lookup"><span data-stu-id="9a92a-161">In GLSL, you present much of the OpenGL state as pre-defined global variables.</span></span> <span data-ttu-id="9a92a-162">たとえば、GLSL では、**gl\_Position** 変数を使って頂点の位置を指定し、**gl\_FragColor** 変数を使ってフラグメントの色を指定します。</span><span class="sxs-lookup"><span data-stu-id="9a92a-162">For example, with GLSL, you use the **gl\_Position** variable to specify vertex position and the **gl\_FragColor** variable to specify fragment color.</span></span> <span data-ttu-id="9a92a-163">HLSL では、アプリ コードからシェーダーに Direct3D の状態を明示的に渡します。</span><span class="sxs-lookup"><span data-stu-id="9a92a-163">In HLSL, you pass Direct3D state explicitly from the app code to the shader.</span></span> <span data-ttu-id="9a92a-164">たとえば、Direct3D と HLSL を使う場合は、頂点シェーダーへの入力が頂点バッファーのデータ形式に一致し、アプリ コードの定数バッファーの構造がシェーダー コードの定数バッファー ([cbuffer](https://msdn.microsoft.com/library/windows/desktop/bb509581)) の構造と一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="9a92a-164">For example, with Direct3D and HLSL, the input to the vertex shader must match the data format in the vertex buffer, and the structure of a constant buffer in the app code must match the structure of a constant buffer ([cbuffer](https://msdn.microsoft.com/library/windows/desktop/bb509581)) in shader code.</span></span>

## <a name="porting-glsl-variables-to-hlsl"></a><span data-ttu-id="9a92a-165">HLSL への GLSL 変数の移植</span><span class="sxs-lookup"><span data-stu-id="9a92a-165">Porting GLSL variables to HLSL</span></span>


<span data-ttu-id="9a92a-166">GLSL では、グローバル シェーダーの変数の宣言に修飾子を適用し、その変数にシェーダーの特定の動作を割り当てます。</span><span class="sxs-lookup"><span data-stu-id="9a92a-166">In GLSL, you apply modifiers (qualifiers) to a global shader variable declaration to give that variable a specific behavior in your shaders.</span></span> <span data-ttu-id="9a92a-167">HLSL では、シェーダーとやり取りする引数を使ってシェーダーのフローを定義するため、これらの修飾子は必要ではありません。</span><span class="sxs-lookup"><span data-stu-id="9a92a-167">In HLSL, you don’t need these modifiers because you define the flow of the shader with the arguments that you pass to your shader and that you return from your shader.</span></span>

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="9a92a-168">GLSL の変数の動作</span><span class="sxs-lookup"><span data-stu-id="9a92a-168">GLSL variable behavior</span></span></th>
<th align="left"><span data-ttu-id="9a92a-169">相当する HLSL の要素</span><span class="sxs-lookup"><span data-stu-id="9a92a-169">HLSL equivalent</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><strong><span data-ttu-id="9a92a-170">uniform</span><span class="sxs-lookup"><span data-stu-id="9a92a-170">uniform</span></span></strong></p>
<p><span data-ttu-id="9a92a-171">アプリ コードから uniform 変数を頂点シェーダーとフラグメント シェーダーのどちらか一方または両方に渡します。</span><span class="sxs-lookup"><span data-stu-id="9a92a-171">You pass a uniform variable from the app code into either or both vertex and fragment shaders.</span></span> <span data-ttu-id="9a92a-172">これらのシェーダーを使って三角形を描画する前にすべての uniform の値を設定する必要があります。三角形のメッシュの描画中に値が変わらないようにするためです。</span><span class="sxs-lookup"><span data-stu-id="9a92a-172">You must set the values of all uniforms before you draw any triangles with those shaders so their values stay the same throughout the drawing of a triangle mesh.</span></span> <span data-ttu-id="9a92a-173">これらの値は変化しません。</span><span class="sxs-lookup"><span data-stu-id="9a92a-173">These values are uniform.</span></span> <span data-ttu-id="9a92a-174">フレーム全体に対して設定される uniform もあれば、特定の頂点ピクセル シェーダーのペアに対してのみ設定される uniform もあります。</span><span class="sxs-lookup"><span data-stu-id="9a92a-174">Some uniforms are set for the entire frame and others uniquely to one particular vertex-pixel shader pair.</span></span></p>
<p><span data-ttu-id="9a92a-175">uniform 変数はポリゴン単位の変数です。</span><span class="sxs-lookup"><span data-stu-id="9a92a-175">Uniform variables are per-polygon variables.</span></span></p></td>
<td align="left"><p><span data-ttu-id="9a92a-176">定数バッファーを使います。</span><span class="sxs-lookup"><span data-stu-id="9a92a-176">Use constant buffer.</span></span></p>
<p><span data-ttu-id="9a92a-177">「<a href="https://msdn.microsoft.com/library/windows/desktop/ff476896">定数バッファーを作成する方法</a>」と「<a href="https://msdn.microsoft.com/library/windows/desktop/bb509581">シェーダー定数</a>」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9a92a-177">See <a href="https://msdn.microsoft.com/library/windows/desktop/ff476896">How to: Create a Constant Buffer</a> and <a href="https://msdn.microsoft.com/library/windows/desktop/bb509581">Shader Constants</a>.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><strong><span data-ttu-id="9a92a-178">varying</span><span class="sxs-lookup"><span data-stu-id="9a92a-178">varying</span></span></strong></p>
<p><span data-ttu-id="9a92a-179">頂点シェーダー内で varying 変数を初期化し、フラグメント シェーダーの同じ名前の varying 変数に渡します。</span><span class="sxs-lookup"><span data-stu-id="9a92a-179">You initialize a varying variable inside the vertex shader and pass it through to an identically named varying variable in the fragment shader.</span></span> <span data-ttu-id="9a92a-180">頂点シェーダーは各頂点でのみさまざまな変数の値を設定するため、ラスタライザーはその値を (透視補正の方法で) 補間し、フラグメント単位の値を生成してフラグメント シェーダーに渡します。</span><span class="sxs-lookup"><span data-stu-id="9a92a-180">Because the vertex shader only sets the value of the varying variables at each vertex, the rasterizer interpolates those values (in a perspective-correct manner) to generate per fragment values to pass into the fragment shader.</span></span> <span data-ttu-id="9a92a-181">これらの変数は各三角形で異なります。</span><span class="sxs-lookup"><span data-stu-id="9a92a-181">These variables vary across each triangle.</span></span></p></td>
<td align="left"><span data-ttu-id="9a92a-182">頂点シェーダーから取得した構造をピクセル シェーダーへの入力として使います。</span><span class="sxs-lookup"><span data-stu-id="9a92a-182">Use the structure that you return from your vertex shader as the input to your pixel shader.</span></span> <span data-ttu-id="9a92a-183">セマンティック値が一致することを確かめてください。</span><span class="sxs-lookup"><span data-stu-id="9a92a-183">Make sure the semantic values match.</span></span></td>
</tr>
<tr class="odd">
<td align="left"><p><strong><span data-ttu-id="9a92a-184">属性</span><span class="sxs-lookup"><span data-stu-id="9a92a-184">attribute</span></span></strong></p>
<p><span data-ttu-id="9a92a-185">属性は、アプリ コードから頂点シェーダーだけに渡す頂点の記述の一部です。</span><span class="sxs-lookup"><span data-stu-id="9a92a-185">An attribute is a part of the description of a vertex that you pass from the app code to the vertex shader alone.</span></span> <span data-ttu-id="9a92a-186">uniform とは異なり、頂点ごとに各属性の値を設定します。それにより、各頂点が異なる値を持つことができるようになります。</span><span class="sxs-lookup"><span data-stu-id="9a92a-186">Unlike a uniform, you set each attribute’s value for each vertex, which, in turn, allows each vertex to have a different value.</span></span> <span data-ttu-id="9a92a-187">属性変数は頂点単位の変数です。</span><span class="sxs-lookup"><span data-stu-id="9a92a-187">Attribute variables are per-vertex variables.</span></span></p></td>
<td align="left"><p><span data-ttu-id="9a92a-188">Direct3D アプリ コードで頂点バッファーを定義し、頂点シェーダーで定義されている頂点の入力と一致させます。</span><span class="sxs-lookup"><span data-stu-id="9a92a-188">Define a vertex buffer in your Direct3D app code and match it to the vertex input defined in the vertex shader.</span></span> <span data-ttu-id="9a92a-189">必要に応じてインデックス バッファーを定義します。</span><span class="sxs-lookup"><span data-stu-id="9a92a-189">Optionally, define an index buffer.</span></span> <span data-ttu-id="9a92a-190">「<a href="https://msdn.microsoft.com/library/windows/desktop/ff476899">頂点バッファーを作成する方法</a>」と「<a href="https://msdn.microsoft.com/library/windows/desktop/ff476897">インデックス バッファーを作成する方法</a>」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9a92a-190">See <a href="https://msdn.microsoft.com/library/windows/desktop/ff476899">How to: Create a Vertex Buffer</a> and <a href="https://msdn.microsoft.com/library/windows/desktop/ff476897">How to: Create an Index Buffer</a>.</span></span></p>
<p><span data-ttu-id="9a92a-191">Direct3D アプリ コードで入力レイアウトを作成し、セマンティック値を頂点の入力の値と一致させます。</span><span class="sxs-lookup"><span data-stu-id="9a92a-191">Create an input layout in your Direct3D app code and match semantic values with those in the vertex input.</span></span> <span data-ttu-id="9a92a-192">「<a href="https://msdn.microsoft.com/library/windows/desktop/bb205117#Create_the_Input_Layout">入力レイアウトの作成</a>」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9a92a-192">See <a href="https://msdn.microsoft.com/library/windows/desktop/bb205117#Create_the_Input_Layout">Create the input layout</a>.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><strong><span data-ttu-id="9a92a-193">const</span><span class="sxs-lookup"><span data-stu-id="9a92a-193">const</span></span></strong></p>
<p><span data-ttu-id="9a92a-194">シェーダーにコンパイルされ、変更されない定数。</span><span class="sxs-lookup"><span data-stu-id="9a92a-194">Constants that are compiled into the shader and never change.</span></span></p></td>
<td align="left"><span data-ttu-id="9a92a-195"><strong>static const</strong> を使用します。</span><span class="sxs-lookup"><span data-stu-id="9a92a-195">Use a <strong>static const</strong>.</span></span> <span data-ttu-id="9a92a-196"><strong>static</strong> は、値が定数バッファーに公開されないことを表し、<strong>const</strong> は、シェーダーが値を変更できないことを表します。</span><span class="sxs-lookup"><span data-stu-id="9a92a-196"><strong>static</strong> means the value isn't exposed to constant buffers, <strong>const</strong> means the shader can't change the value.</span></span> <span data-ttu-id="9a92a-197">そのため、値は初期化子に基づいてコンパイル時に把握されます。</span><span class="sxs-lookup"><span data-stu-id="9a92a-197">So, the value is known at compile time based on its initializer.</span></span></td>
</tr>
</tbody>
</table>

 

<span data-ttu-id="9a92a-198">GLSL では、修飾子のない変数は、各シェーダーに対してプライベートな通常のグローバル変数に過ぎません。</span><span class="sxs-lookup"><span data-stu-id="9a92a-198">In GLSL, variables without modifiers are just ordinary global variables that are private to each shader.</span></span>

<span data-ttu-id="9a92a-199">テクスチャ (HLSL での [Texture2D](https://msdn.microsoft.com/library/windows/desktop/ff471525)) と関連のサンプラー (HLSL での [SamplerState](https://msdn.microsoft.com/library/windows/desktop/bb509644)) にデータを渡すときに、通常は、ピクセル シェーダーのグローバル変数としてこれらを宣言します。</span><span class="sxs-lookup"><span data-stu-id="9a92a-199">When you pass data to textures ([Texture2D](https://msdn.microsoft.com/library/windows/desktop/ff471525) in HLSL) and their associated samplers ([SamplerState](https://msdn.microsoft.com/library/windows/desktop/bb509644) in HLSL), you typically declare them as global variables in the pixel shader.</span></span>

## <a name="porting-glsl-types-to-hlsl"></a><span data-ttu-id="9a92a-200">HLSL への GLSL の型の移植</span><span class="sxs-lookup"><span data-stu-id="9a92a-200">Porting GLSL types to HLSL</span></span>


<span data-ttu-id="9a92a-201">HLSL に GLSL の型を移植する場合は、次の表を参考にしてください。</span><span class="sxs-lookup"><span data-stu-id="9a92a-201">Use this table to port your GLSL types to HLSL.</span></span>

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="9a92a-202">GLSL の型</span><span class="sxs-lookup"><span data-stu-id="9a92a-202">GLSL type</span></span></th>
<th align="left"><span data-ttu-id="9a92a-203">HLSL の型</span><span class="sxs-lookup"><span data-stu-id="9a92a-203">HLSL type</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="9a92a-204">スカラー型: float、int、bool</span><span class="sxs-lookup"><span data-stu-id="9a92a-204">scalar types: float, int, bool</span></span></td>
<td align="left"><p><span data-ttu-id="9a92a-205">スカラー型: float、int、bool</span><span class="sxs-lookup"><span data-stu-id="9a92a-205">scalar types: float, int, bool</span></span></p>
<p><span data-ttu-id="9a92a-206">また、uint、double</span><span class="sxs-lookup"><span data-stu-id="9a92a-206">also, uint, double</span></span></p>
<p><span data-ttu-id="9a92a-207">詳しくは、「<a href="https://msdn.microsoft.com/library/windows/desktop/bb509646">スカラー型</a>」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9a92a-207">For more info, see <a href="https://msdn.microsoft.com/library/windows/desktop/bb509646">Scalar Types</a>.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="9a92a-208">ベクター型</span><span class="sxs-lookup"><span data-stu-id="9a92a-208">vector type</span></span></p>
<ul>
<li><span data-ttu-id="9a92a-209">浮動小数点ベクター: vec2、vec3、vec4</span><span class="sxs-lookup"><span data-stu-id="9a92a-209">floating-point vector: vec2, vec3, vec4</span></span></li>
<li><span data-ttu-id="9a92a-210">ブール ベクター: bvec2、bvec3、bvec4</span><span class="sxs-lookup"><span data-stu-id="9a92a-210">Boolean vector: bvec2, bvec3, bvec4</span></span></li>
<li><span data-ttu-id="9a92a-211">符号付き整数ベクター: ivec2、ivec3、ivec4</span><span class="sxs-lookup"><span data-stu-id="9a92a-211">signed integer vector: ivec2, ivec3, ivec4</span></span></li>
</ul></td>
<td align="left"><p><span data-ttu-id="9a92a-212">ベクター型</span><span class="sxs-lookup"><span data-stu-id="9a92a-212">vector type</span></span></p>
<ul>
<li><span data-ttu-id="9a92a-213">float2、float3、float4、float1</span><span class="sxs-lookup"><span data-stu-id="9a92a-213">float2, float3, float4, and float1</span></span></li>
<li><span data-ttu-id="9a92a-214">bool2、bool3、bool4、bool1</span><span class="sxs-lookup"><span data-stu-id="9a92a-214">bool2, bool3, bool4, and bool1</span></span></li>
<li><span data-ttu-id="9a92a-215">int2、int3、int4、int1</span><span class="sxs-lookup"><span data-stu-id="9a92a-215">int2, int3, int4, and int1</span></span></li>
<li><p><span data-ttu-id="9a92a-216">これらの型には、float、bool、int に似たベクター拡張もあります。</span><span class="sxs-lookup"><span data-stu-id="9a92a-216">These types also have vector expansions similar to float, bool, and int:</span></span></p>
<ul>
<li><span data-ttu-id="9a92a-217">uint</span><span class="sxs-lookup"><span data-stu-id="9a92a-217">uint</span></span></li>
<li><span data-ttu-id="9a92a-218">min10float、min16float</span><span class="sxs-lookup"><span data-stu-id="9a92a-218">min10float, min16float</span></span></li>
<li><span data-ttu-id="9a92a-219">min12int、min16int</span><span class="sxs-lookup"><span data-stu-id="9a92a-219">min12int, min16int</span></span></li>
<li><span data-ttu-id="9a92a-220">min16uint</span><span class="sxs-lookup"><span data-stu-id="9a92a-220">min16uint</span></span></li>
</ul></li>
</ul>
<p><span data-ttu-id="9a92a-221">詳しくは、「<a href="https://msdn.microsoft.com/library/windows/desktop/bb509707">ベクター型</a>」と「<a href="https://msdn.microsoft.com/library/windows/desktop/bb509568">キーワード</a>」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9a92a-221">For more info, see <a href="https://msdn.microsoft.com/library/windows/desktop/bb509707">Vector Type</a> and <a href="https://msdn.microsoft.com/library/windows/desktop/bb509568">Keywords</a>.</span></span></p>
<p><span data-ttu-id="9a92a-222">vector は、float4 として定義される型でもあります (typedef vector &lt;float, 4&gt; vector;)。</span><span class="sxs-lookup"><span data-stu-id="9a92a-222">vector is also type defined as float4 (typedef vector &lt;float, 4&gt; vector;).</span></span> <span data-ttu-id="9a92a-223">詳しくは、「<a href="https://msdn.microsoft.com/library/windows/desktop/bb509702">ユーザー定義型</a>」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9a92a-223">For more info, see <a href="https://msdn.microsoft.com/library/windows/desktop/bb509702">User-Defined Type</a>.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="9a92a-224">マトリックス型</span><span class="sxs-lookup"><span data-stu-id="9a92a-224">matrix type</span></span></p>
<ul>
<li><span data-ttu-id="9a92a-225">mat2: 2x2 浮動小数点マトリックス</span><span class="sxs-lookup"><span data-stu-id="9a92a-225">mat2: 2x2 float matrix</span></span></li>
<li><span data-ttu-id="9a92a-226">mat3: 3x3 浮動小数点マトリックス</span><span class="sxs-lookup"><span data-stu-id="9a92a-226">mat3: 3x3 float matrix</span></span></li>
<li><span data-ttu-id="9a92a-227">mat4: 4x4 浮動小数点マトリックス</span><span class="sxs-lookup"><span data-stu-id="9a92a-227">mat4: 4x4 float matrix</span></span></li>
</ul></td>
<td align="left"><p><span data-ttu-id="9a92a-228">マトリックス型</span><span class="sxs-lookup"><span data-stu-id="9a92a-228">matrix type</span></span></p>
<ul>
<li><span data-ttu-id="9a92a-229">float2x2</span><span class="sxs-lookup"><span data-stu-id="9a92a-229">float2x2</span></span></li>
<li><span data-ttu-id="9a92a-230">float3x3</span><span class="sxs-lookup"><span data-stu-id="9a92a-230">float3x3</span></span></li>
<li><span data-ttu-id="9a92a-231">float4x4</span><span class="sxs-lookup"><span data-stu-id="9a92a-231">float4x4</span></span></li>
<li><span data-ttu-id="9a92a-232">また、float1x1、float1x2、float1x3、float1x4、float2x1、float2x3、float2x4、float3x1、float3x2、float3x4、float4x1、float4x2、float4x3</span><span class="sxs-lookup"><span data-stu-id="9a92a-232">also, float1x1, float1x2, float1x3, float1x4, float2x1, float2x3, float2x4, float3x1, float3x2, float3x4, float4x1, float4x2, float4x3</span></span></li>
<li><p><span data-ttu-id="9a92a-233">これらの型には、float に似たマトリックス拡張もあります。</span><span class="sxs-lookup"><span data-stu-id="9a92a-233">These types also have matrix expansions similar to float:</span></span></p>
<ul>
<li><span data-ttu-id="9a92a-234">int、uint、bool</span><span class="sxs-lookup"><span data-stu-id="9a92a-234">int, uint, bool</span></span></li>
<li><span data-ttu-id="9a92a-235">min10float、min16float</span><span class="sxs-lookup"><span data-stu-id="9a92a-235">min10float, min16float</span></span></li>
<li><span data-ttu-id="9a92a-236">min12int、min16int</span><span class="sxs-lookup"><span data-stu-id="9a92a-236">min12int, min16int</span></span></li>
<li><span data-ttu-id="9a92a-237">min16uint</span><span class="sxs-lookup"><span data-stu-id="9a92a-237">min16uint</span></span></li>
</ul></li>
</ul>
<p><span data-ttu-id="9a92a-238">また、マトリックスの定義に<a href="https://msdn.microsoft.com/library/windows/desktop/bb509623">マトリックス型</a>を使うこともできます。</span><span class="sxs-lookup"><span data-stu-id="9a92a-238">You can also use the <a href="https://msdn.microsoft.com/library/windows/desktop/bb509623">matrix type</a> to define a matrix.</span></span></p>
<p><span data-ttu-id="9a92a-239">例: matrix &lt;float, 2, 2&gt; fMatrix = {0.0f, 0.1, 2.1f, 2.2f};</span><span class="sxs-lookup"><span data-stu-id="9a92a-239">For example: matrix &lt;float, 2, 2&gt; fMatrix = {0.0f, 0.1, 2.1f, 2.2f};</span></span></p>
<p><span data-ttu-id="9a92a-240">matrix は、float4x4 として定義される型でもあります (typedef matrix &lt;float, 4, 4&gt; matrix;)。</span><span class="sxs-lookup"><span data-stu-id="9a92a-240">matrix is also type defined as float4x4 (typedef matrix &lt;float, 4, 4&gt; matrix;).</span></span> <span data-ttu-id="9a92a-241">詳しくは、「<a href="https://msdn.microsoft.com/library/windows/desktop/bb509702">ユーザー定義型</a>」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9a92a-241">For more info, see <a href="https://msdn.microsoft.com/library/windows/desktop/bb509702">User-Defined Type</a>.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="9a92a-242">float、int、sampler の有効桁数修飾子</span><span class="sxs-lookup"><span data-stu-id="9a92a-242">precision qualifiers for float, int, sampler</span></span></p>
<ul>
<li><p><span data-ttu-id="9a92a-243">highp</span><span class="sxs-lookup"><span data-stu-id="9a92a-243">highp</span></span></p>
<p><span data-ttu-id="9a92a-244">この修飾子は min16float によって指定されるものより大きく、完全な 32 ビット float より小さい最小有効桁数要件を指定します。</span><span class="sxs-lookup"><span data-stu-id="9a92a-244">This qualifier provides minimum precision requirements that are greater than that provided by min16float and less than a full 32-bit float.</span></span> <span data-ttu-id="9a92a-245">相当する HLSL の要素:</span><span class="sxs-lookup"><span data-stu-id="9a92a-245">Equivalent in HLSL is:</span></span></p>
<p><span data-ttu-id="9a92a-246">highp float -&gt; float</span><span class="sxs-lookup"><span data-stu-id="9a92a-246">highp float -&gt; float</span></span></p>
<p><span data-ttu-id="9a92a-247">highp int -&gt; int</span><span class="sxs-lookup"><span data-stu-id="9a92a-247">highp int -&gt; int</span></span></p></li>
<li><p><span data-ttu-id="9a92a-248">mediump</span><span class="sxs-lookup"><span data-stu-id="9a92a-248">mediump</span></span></p>
<p><span data-ttu-id="9a92a-249">float と int に適用されるこの修飾子は、HLSL の min16float と min12int に相当します。</span><span class="sxs-lookup"><span data-stu-id="9a92a-249">This qualifier applied to float and int is equivalent to min16float and min12int in HLSL.</span></span> <span data-ttu-id="9a92a-250">mantissa の最小 10 ビット。min10float とは異なります。</span><span class="sxs-lookup"><span data-stu-id="9a92a-250">Minimum 10 bits of mantissa, not like min10float.</span></span></p></li>
<li><p><span data-ttu-id="9a92a-251">lowp</span><span class="sxs-lookup"><span data-stu-id="9a92a-251">lowp</span></span></p>
<p><span data-ttu-id="9a92a-252">float に適用されるこの修飾子は、-2 ～ 2 の浮動小数点の範囲を指定します。</span><span class="sxs-lookup"><span data-stu-id="9a92a-252">This qualifier applied to float provides a floating point range of -2 to 2.</span></span> <span data-ttu-id="9a92a-253">HLSL での min10float に相当します。</span><span class="sxs-lookup"><span data-stu-id="9a92a-253">Equivalent to min10float in HLSL.</span></span></p></li>
</ul></td>
<td align="left"><p><span data-ttu-id="9a92a-254">有効桁数の型</span><span class="sxs-lookup"><span data-stu-id="9a92a-254">precision types</span></span></p>
<ul>
<li><span data-ttu-id="9a92a-255">min16float: 16 ビットの最小浮動小数点値</span><span class="sxs-lookup"><span data-stu-id="9a92a-255">min16float: minimum 16-bit floating point value</span></span></li>
<li><p><span data-ttu-id="9a92a-256">min10float</span><span class="sxs-lookup"><span data-stu-id="9a92a-256">min10float</span></span></p>
<p><span data-ttu-id="9a92a-257">最小の符号付き固定小数点 2.8 ビット値 (整数部は 2 ビット、小数部は 8 ビット)。</span><span class="sxs-lookup"><span data-stu-id="9a92a-257">Minimum fixed-point signed 2.8 bit value (2 bits of whole number and 8 bits fractional component).</span></span> <span data-ttu-id="9a92a-258">8 ビットの小数部には 1 を含めることができます。また、-2 ～ 2 の範囲の両端を含めることができます。</span><span class="sxs-lookup"><span data-stu-id="9a92a-258">The 8-bit fractional component can be inclusive of 1 instead of exclusive to give it the full inclusive range of -2 to 2.</span></span></p></li>
<li><span data-ttu-id="9a92a-259">min16int: 16 ビットの最小符号付き整数</span><span class="sxs-lookup"><span data-stu-id="9a92a-259">min16int: minimum 16-bit signed integer</span></span></li>
<li><p><span data-ttu-id="9a92a-260">min12int: 12 ビットの最小符号付き整数</span><span class="sxs-lookup"><span data-stu-id="9a92a-260">min12int: minimum 12-bit signed integer</span></span></p>
<p><span data-ttu-id="9a92a-261">この型は 10Level9 (<a href="https://msdn.microsoft.com/library/windows/desktop/ff476876">9_x の機能レベル</a>) 向けであり、整数は浮動小数点数で表されます。</span><span class="sxs-lookup"><span data-stu-id="9a92a-261">This type is for 10Level9 (<a href="https://msdn.microsoft.com/library/windows/desktop/ff476876">9_x feature levels</a>) in which integers are represented by floating point numbers.</span></span> <span data-ttu-id="9a92a-262">これは、16 ビットの浮動小数点数で整数をエミュレートするときに取得できる有効桁数です。</span><span class="sxs-lookup"><span data-stu-id="9a92a-262">This is the precision you can get when you emulate an integer with a 16-bit floating point number.</span></span></p></li>
<li><span data-ttu-id="9a92a-263">min16int: 16 ビットの最小符号なし整数</span><span class="sxs-lookup"><span data-stu-id="9a92a-263">min16uint: minimum 16-bit unsigned integer</span></span></li>
</ul>
<p><span data-ttu-id="9a92a-264">詳しくは、「<a href="https://msdn.microsoft.com/library/windows/desktop/bb509646">スカラー型</a>」と「<a href="https://msdn.microsoft.com/library/windows/desktop/hh968108">HLSL の最小精度の使用</a>」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9a92a-264">For more info, see <a href="https://msdn.microsoft.com/library/windows/desktop/bb509646">Scalar Types</a> and <a href="https://msdn.microsoft.com/library/windows/desktop/hh968108">Using HLSL minimum precision</a>.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="9a92a-265">sampler2D</span><span class="sxs-lookup"><span data-stu-id="9a92a-265">sampler2D</span></span></td>
<td align="left"><a href="https://msdn.microsoft.com/library/windows/desktop/ff471525"><span data-ttu-id="9a92a-266">Texture2D</span><span class="sxs-lookup"><span data-stu-id="9a92a-266">Texture2D</span></span></a></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="9a92a-267">samplerCube</span><span class="sxs-lookup"><span data-stu-id="9a92a-267">samplerCube</span></span></td>
<td align="left"><a href="https://msdn.microsoft.com/library/windows/desktop/bb509700"><span data-ttu-id="9a92a-268">TextureCube</span><span class="sxs-lookup"><span data-stu-id="9a92a-268">TextureCube</span></span></a></td>
</tr>
</tbody>
</table>

 

## <a name="porting-glsl-pre-defined-global-variables-to-hlsl"></a><span data-ttu-id="9a92a-269">HLSL への GLSL の定義済みグローバル変数の移植</span><span class="sxs-lookup"><span data-stu-id="9a92a-269">Porting GLSL pre-defined global variables to HLSL</span></span>


<span data-ttu-id="9a92a-270">GLSL の定義済みグローバル変数を HLSL に移植する場合は、次の表を参考にしてください。</span><span class="sxs-lookup"><span data-stu-id="9a92a-270">Use this table to port GLSL pre-defined global variables to HLSL.</span></span>

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="9a92a-271">GLSL の定義済みグローバル変数</span><span class="sxs-lookup"><span data-stu-id="9a92a-271">GLSL pre-defined global variable</span></span></th>
<th align="left"><span data-ttu-id="9a92a-272">HLSL セマンティクス</span><span class="sxs-lookup"><span data-stu-id="9a92a-272">HLSL semantics</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><strong><span data-ttu-id="9a92a-273">gl_Position</span><span class="sxs-lookup"><span data-stu-id="9a92a-273">gl_Position</span></span></strong></p>
<p><span data-ttu-id="9a92a-274">この変数は <strong>vec4</strong> 型です。</span><span class="sxs-lookup"><span data-stu-id="9a92a-274">This variable is type <strong>vec4</strong>.</span></span></p>
<p><span data-ttu-id="9a92a-275">頂点の位置</span><span class="sxs-lookup"><span data-stu-id="9a92a-275">Vertex position</span></span></p>
<p><span data-ttu-id="9a92a-276">例: gl_Position = position;</span><span class="sxs-lookup"><span data-stu-id="9a92a-276">for example - gl_Position = position;</span></span></p></td>
<td align="left"><p><span data-ttu-id="9a92a-277">SV_Position</span><span class="sxs-lookup"><span data-stu-id="9a92a-277">SV_Position</span></span></p>
<p><span data-ttu-id="9a92a-278">Direct3D 9 の POSITION</span><span class="sxs-lookup"><span data-stu-id="9a92a-278">POSITION in Direct3D 9</span></span></p>
<p><span data-ttu-id="9a92a-279">このセマンティックは <strong>float4</strong> 型です。</span><span class="sxs-lookup"><span data-stu-id="9a92a-279">This semantic is type <strong>float4</strong>.</span></span></p>
<p><span data-ttu-id="9a92a-280">頂点シェーダーの出力</span><span class="sxs-lookup"><span data-stu-id="9a92a-280">Vertex shader output</span></span></p>
<p><span data-ttu-id="9a92a-281">頂点の位置</span><span class="sxs-lookup"><span data-stu-id="9a92a-281">Vertex position</span></span></p>
<p><span data-ttu-id="9a92a-282">例: float4 vPosition : SV_Position;</span><span class="sxs-lookup"><span data-stu-id="9a92a-282">for example - float4 vPosition : SV_Position;</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><strong><span data-ttu-id="9a92a-283">gl_PointSize</span><span class="sxs-lookup"><span data-stu-id="9a92a-283">gl_PointSize</span></span></strong></p>
<p><span data-ttu-id="9a92a-284">この変数は <strong>float</strong> 型です。</span><span class="sxs-lookup"><span data-stu-id="9a92a-284">This variable is type <strong>float</strong>.</span></span></p>
<p><span data-ttu-id="9a92a-285">ポイントのサイズ</span><span class="sxs-lookup"><span data-stu-id="9a92a-285">Point size</span></span></p></td>
<td align="left"><p><span data-ttu-id="9a92a-286">PSIZE</span><span class="sxs-lookup"><span data-stu-id="9a92a-286">PSIZE</span></span></p>
<p><span data-ttu-id="9a92a-287">Direct3D 9 を対象としない場合、意味はありません</span><span class="sxs-lookup"><span data-stu-id="9a92a-287">No meaning unless you target Direct3D 9</span></span></p>
<p><span data-ttu-id="9a92a-288">このセマンティックは <strong>float</strong> 型です。</span><span class="sxs-lookup"><span data-stu-id="9a92a-288">This semantic is type <strong>float</strong>.</span></span></p>
<p><span data-ttu-id="9a92a-289">頂点シェーダーの出力</span><span class="sxs-lookup"><span data-stu-id="9a92a-289">Vertex shader output</span></span></p>
<p><span data-ttu-id="9a92a-290">ポイントのサイズ</span><span class="sxs-lookup"><span data-stu-id="9a92a-290">Point size</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><strong><span data-ttu-id="9a92a-291">gl_FragColor</span><span class="sxs-lookup"><span data-stu-id="9a92a-291">gl_FragColor</span></span></strong></p>
<p><span data-ttu-id="9a92a-292">この変数は <strong>vec4</strong> 型です。</span><span class="sxs-lookup"><span data-stu-id="9a92a-292">This variable is type <strong>vec4</strong>.</span></span></p>
<p><span data-ttu-id="9a92a-293">フラグメント色</span><span class="sxs-lookup"><span data-stu-id="9a92a-293">Fragment color</span></span></p>
<p><span data-ttu-id="9a92a-294">例: gl_FragColor = vec4(colorVarying, 1.0);</span><span class="sxs-lookup"><span data-stu-id="9a92a-294">for example - gl_FragColor = vec4(colorVarying, 1.0);</span></span></p></td>
<td align="left"><p><span data-ttu-id="9a92a-295">SV_Target</span><span class="sxs-lookup"><span data-stu-id="9a92a-295">SV_Target</span></span></p>
<p><span data-ttu-id="9a92a-296">Direct3D 9 の COLOR</span><span class="sxs-lookup"><span data-stu-id="9a92a-296">COLOR in Direct3D 9</span></span></p>
<p><span data-ttu-id="9a92a-297">このセマンティックは <strong>float4</strong> 型です。</span><span class="sxs-lookup"><span data-stu-id="9a92a-297">This semantic is type <strong>float4</strong>.</span></span></p>
<p><span data-ttu-id="9a92a-298">ピクセル シェーダーの出力</span><span class="sxs-lookup"><span data-stu-id="9a92a-298">Pixel shader output</span></span></p>
<p><span data-ttu-id="9a92a-299">ピクセルの色</span><span class="sxs-lookup"><span data-stu-id="9a92a-299">Pixel color</span></span></p>
<p><span data-ttu-id="9a92a-300">例: float4 Color[4] : SV_Target;</span><span class="sxs-lookup"><span data-stu-id="9a92a-300">for example - float4 Color[4] : SV_Target;</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><strong><span data-ttu-id="9a92a-301">gl_FragData[n]</span><span class="sxs-lookup"><span data-stu-id="9a92a-301">gl_FragData[n]</span></span></strong></p>
<p><span data-ttu-id="9a92a-302">この変数は <strong>vec4</strong> 型です。</span><span class="sxs-lookup"><span data-stu-id="9a92a-302">This variable is type <strong>vec4</strong>.</span></span></p>
<p><span data-ttu-id="9a92a-303">カラー アタッチメント n のフラグメント色</span><span class="sxs-lookup"><span data-stu-id="9a92a-303">Fragment color for color attachment n</span></span></p></td>
<td align="left"><p><span data-ttu-id="9a92a-304">SV_Target[n]</span><span class="sxs-lookup"><span data-stu-id="9a92a-304">SV_Target[n]</span></span></p>
<p><span data-ttu-id="9a92a-305">このセマンティックは <strong>float4</strong> 型です。</span><span class="sxs-lookup"><span data-stu-id="9a92a-305">This semantic is type <strong>float4</strong>.</span></span></p>
<p><span data-ttu-id="9a92a-306">n レンダー ターゲットに格納されるピクセル シェーダーの出力値 (0 &lt;= n &lt;= 7)。</span><span class="sxs-lookup"><span data-stu-id="9a92a-306">Pixel shader output value that is stored in n render target, where 0 &lt;= n &lt;= 7.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><strong><span data-ttu-id="9a92a-307">gl_FragCoord</span><span class="sxs-lookup"><span data-stu-id="9a92a-307">gl_FragCoord</span></span></strong></p>
<p><span data-ttu-id="9a92a-308">この変数は <strong>vec4</strong> 型です。</span><span class="sxs-lookup"><span data-stu-id="9a92a-308">This variable is type <strong>vec4</strong>.</span></span></p>
<p><span data-ttu-id="9a92a-309">フレーム バッファー内のフラグメントの位置</span><span class="sxs-lookup"><span data-stu-id="9a92a-309">Fragment position within frame buffer</span></span></p></td>
<td align="left"><p><span data-ttu-id="9a92a-310">SV_Position</span><span class="sxs-lookup"><span data-stu-id="9a92a-310">SV_Position</span></span></p>
<p><span data-ttu-id="9a92a-311">Direct3D 9 では使用できません</span><span class="sxs-lookup"><span data-stu-id="9a92a-311">Not available in Direct3D 9</span></span></p>
<p><span data-ttu-id="9a92a-312">このセマンティックは <strong>float4</strong> 型です。</span><span class="sxs-lookup"><span data-stu-id="9a92a-312">This semantic is type <strong>float4</strong>.</span></span></p>
<p><span data-ttu-id="9a92a-313">ピクセル シェーダーの入力</span><span class="sxs-lookup"><span data-stu-id="9a92a-313">Pixel shader input</span></span></p>
<p><span data-ttu-id="9a92a-314">画面領域の座標</span><span class="sxs-lookup"><span data-stu-id="9a92a-314">Screen space coordinates</span></span></p>
<p><span data-ttu-id="9a92a-315">例: float4 screenSpace : SV_Position</span><span class="sxs-lookup"><span data-stu-id="9a92a-315">for example - float4 screenSpace : SV_Position</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><strong><span data-ttu-id="9a92a-316">gl_FrontFacing</span><span class="sxs-lookup"><span data-stu-id="9a92a-316">gl_FrontFacing</span></span></strong></p>
<p><span data-ttu-id="9a92a-317">この変数は <strong>bool</strong> 型です。</span><span class="sxs-lookup"><span data-stu-id="9a92a-317">This variable is type <strong>bool</strong>.</span></span></p>
<p><span data-ttu-id="9a92a-318">フラグメントが前向きのプリミティブに属しているかどうかを決定します。</span><span class="sxs-lookup"><span data-stu-id="9a92a-318">Determines whether fragment belongs to a front-facing primitive.</span></span></p></td>
<td align="left"><p><span data-ttu-id="9a92a-319">SV_IsFrontFace</span><span class="sxs-lookup"><span data-stu-id="9a92a-319">SV_IsFrontFace</span></span></p>
<p><span data-ttu-id="9a92a-320">Direct3D 9 の VFACE</span><span class="sxs-lookup"><span data-stu-id="9a92a-320">VFACE in Direct3D 9</span></span></p>
<p><span data-ttu-id="9a92a-321">SV_IsFrontFace は <strong>bool</strong> 型です。</span><span class="sxs-lookup"><span data-stu-id="9a92a-321">SV_IsFrontFace is type <strong>bool</strong>.</span></span></p>
<p><span data-ttu-id="9a92a-322">VFACE は <strong>float</strong> 型です。</span><span class="sxs-lookup"><span data-stu-id="9a92a-322">VFACE is type <strong>float</strong>.</span></span></p>
<p><span data-ttu-id="9a92a-323">ピクセル シェーダーの入力</span><span class="sxs-lookup"><span data-stu-id="9a92a-323">Pixel shader input</span></span></p>
<p><span data-ttu-id="9a92a-324">プリミティブの向き</span><span class="sxs-lookup"><span data-stu-id="9a92a-324">Primitive facing</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><strong><span data-ttu-id="9a92a-325">gl_PointCoord</span><span class="sxs-lookup"><span data-stu-id="9a92a-325">gl_PointCoord</span></span></strong></p>
<p><span data-ttu-id="9a92a-326">この変数は <strong>vec2</strong> 型です。</span><span class="sxs-lookup"><span data-stu-id="9a92a-326">This variable is type <strong>vec2</strong>.</span></span></p>
<p><span data-ttu-id="9a92a-327">ポイント内のフラグメントの位置 (ポイントのラスター化のみ)</span><span class="sxs-lookup"><span data-stu-id="9a92a-327">Fragment position within a point (point rasterization only)</span></span></p></td>
<td align="left"><p><span data-ttu-id="9a92a-328">SV_Position</span><span class="sxs-lookup"><span data-stu-id="9a92a-328">SV_Position</span></span></p>
<p><span data-ttu-id="9a92a-329">Direct3D 9 の VPOS</span><span class="sxs-lookup"><span data-stu-id="9a92a-329">VPOS in Direct3D 9</span></span></p>
<p><span data-ttu-id="9a92a-330">SV_Position は <strong>float4</strong> 型です。</span><span class="sxs-lookup"><span data-stu-id="9a92a-330">SV_Position is type <strong>float4</strong>.</span></span></p>
<p><span data-ttu-id="9a92a-331">VPOS は <strong>float2</strong> 型です。</span><span class="sxs-lookup"><span data-stu-id="9a92a-331">VPOS is type <strong>float2</strong>.</span></span></p>
<p><span data-ttu-id="9a92a-332">ピクセル シェーダーの入力</span><span class="sxs-lookup"><span data-stu-id="9a92a-332">Pixel shader input</span></span></p>
<p><span data-ttu-id="9a92a-333">画面領域のピクセルまたはサンプルの位置</span><span class="sxs-lookup"><span data-stu-id="9a92a-333">The pixel or sample position in screen space</span></span></p>
<p><span data-ttu-id="9a92a-334">例: float4 pos : SV_Position</span><span class="sxs-lookup"><span data-stu-id="9a92a-334">for example - float4 pos : SV_Position</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><strong><span data-ttu-id="9a92a-335">gl_FragDepth</span><span class="sxs-lookup"><span data-stu-id="9a92a-335">gl_FragDepth</span></span></strong></p>
<p><span data-ttu-id="9a92a-336">この変数は <strong>float</strong> 型です。</span><span class="sxs-lookup"><span data-stu-id="9a92a-336">This variable is type <strong>float</strong>.</span></span></p>
<p><span data-ttu-id="9a92a-337">深度バッファーのデータ</span><span class="sxs-lookup"><span data-stu-id="9a92a-337">Depth buffer data</span></span></p></td>
<td align="left"><p><span data-ttu-id="9a92a-338">SV_Depth</span><span class="sxs-lookup"><span data-stu-id="9a92a-338">SV_Depth</span></span></p>
<p><span data-ttu-id="9a92a-339">Direct3D 9 の DEPTH</span><span class="sxs-lookup"><span data-stu-id="9a92a-339">DEPTH in Direct3D 9</span></span></p>
<p><span data-ttu-id="9a92a-340">SV_Depth は <strong>float</strong> 型です。</span><span class="sxs-lookup"><span data-stu-id="9a92a-340">SV_Depth is type <strong>float</strong>.</span></span></p>
<p><span data-ttu-id="9a92a-341">ピクセル シェーダーの出力</span><span class="sxs-lookup"><span data-stu-id="9a92a-341">Pixel shader output</span></span></p>
<p><span data-ttu-id="9a92a-342">深度バッファーのデータ</span><span class="sxs-lookup"><span data-stu-id="9a92a-342">Depth buffer data</span></span></p></td>
</tr>
</tbody>
</table>

 

<span data-ttu-id="9a92a-343">頂点シェーダーの入力とピクセル シェーダーの入力に位置や色などを指定するには、セマンティクスを使います。</span><span class="sxs-lookup"><span data-stu-id="9a92a-343">You use semantics to specify position, color, and so on for vertex shader input and pixel shader input.</span></span> <span data-ttu-id="9a92a-344">入力レイアウトのセマンティクス値と頂点シェーダーの入力を一致させる必要があります。</span><span class="sxs-lookup"><span data-stu-id="9a92a-344">You must match the semantics values in the input layout with the vertex shader input.</span></span> <span data-ttu-id="9a92a-345">例については、「[HLSL への GLSL 変数の移植の例](#examples-of-porting-glsl-variables-to-hlsl)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9a92a-345">For examples, see [Examples of porting GLSL variables to HLSL](#examples-of-porting-glsl-variables-to-hlsl).</span></span> <span data-ttu-id="9a92a-346">HLSL セマンティクスについて詳しくは、「[セマンティクス](https://msdn.microsoft.com/library/windows/desktop/bb509647)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9a92a-346">For more info about the HLSL semantics, see [Semantics](https://msdn.microsoft.com/library/windows/desktop/bb509647).</span></span>

## <a name="examples-of-porting-glsl-variables-to-hlsl"></a><span data-ttu-id="9a92a-347">HLSL への GLSL 変数の移植の例</span><span class="sxs-lookup"><span data-stu-id="9a92a-347">Examples of porting GLSL variables to HLSL</span></span>


<span data-ttu-id="9a92a-348">ここでは、OpenGL/GLSL コードの GLSL 変数の使用例と、Direct3D/HLSL コードでの相当する例を紹介します。</span><span class="sxs-lookup"><span data-stu-id="9a92a-348">Here we show examples of using GLSL variables in OpenGL/GLSL code and then the equivalent example in Direct3D/HLSL code.</span></span>

### <a name="uniform-attribute-and-varying-in-glsl"></a><span data-ttu-id="9a92a-349">GLSL での uniform、attribute、および varying</span><span class="sxs-lookup"><span data-stu-id="9a92a-349">Uniform, attribute, and varying in GLSL</span></span>

<span data-ttu-id="9a92a-350">OpenGL のアプリ コード</span><span class="sxs-lookup"><span data-stu-id="9a92a-350">OpenGL app code</span></span>

``` syntax
// Uniform values can be set in app code and then processed in the shader code.
uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;

// Incoming position of vertex
attribute vec4 position;
 
// Incoming color for the vertex
attribute vec3 color;
 
// The varying variable tells the shader pipeline to pass it  
// on to the fragment shader.
varying vec3 colorVarying;
```

<span data-ttu-id="9a92a-351">GLSL の頂点シェーダー コード</span><span class="sxs-lookup"><span data-stu-id="9a92a-351">GLSL vertex shader code</span></span>

``` syntax
//The shader entry point is the main method.
void main()
{
colorVarying = color; //Use the varying variable to pass the color to the fragment shader
gl_Position = position; //Copy the position to the gl_Position pre-defined global variable
}
```

<span data-ttu-id="9a92a-352">GLSL のフラグメント シェーダー コード</span><span class="sxs-lookup"><span data-stu-id="9a92a-352">GLSL fragment shader code</span></span>

``` syntax
void main()
{
//Pad the colorVarying vec3 with a 1.0 for alpha to create a vec4 color
//and assign that color to the gl_FragColor pre-defined global variable
//This color then becomes the fragment's color.
gl_FragColor = vec4(colorVarying, 1.0);
}
```

### <a name="constant-buffers-and-data-transfers-in-hlsl"></a><span data-ttu-id="9a92a-353">HLSL での定数バッファーとデータ転送</span><span class="sxs-lookup"><span data-stu-id="9a92a-353">Constant buffers and data transfers in HLSL</span></span>

<span data-ttu-id="9a92a-354">データを HLSL の頂点シェーダーに渡し、それがピクセル シェーダーに渡されるしくみの例を示します。</span><span class="sxs-lookup"><span data-stu-id="9a92a-354">Here is an example of how you pass data to the HLSL vertex shader that then flows through to the pixel shader.</span></span> <span data-ttu-id="9a92a-355">アプリ コードでは、頂点と定数バッファーを定義します。</span><span class="sxs-lookup"><span data-stu-id="9a92a-355">In your app code, define a vertex and a constant buffer.</span></span> <span data-ttu-id="9a92a-356">次に、頂点シェーダー コードで、定数バッファーを [cbuffer](https://msdn.microsoft.com/library/windows/desktop/bb509581) として定義し、頂点単位のデータとピクセル シェーダーの入力データを格納します。</span><span class="sxs-lookup"><span data-stu-id="9a92a-356">Then, in your vertex shader code, define the constant buffer as a [cbuffer](https://msdn.microsoft.com/library/windows/desktop/bb509581) and store the per-vertex data and the pixel shader input data.</span></span> <span data-ttu-id="9a92a-357">ここでは、**VertexShaderInput** および **PixelShaderInput** と呼ばれる構造を使います。</span><span class="sxs-lookup"><span data-stu-id="9a92a-357">Here we use structures called **VertexShaderInput** and **PixelShaderInput**.</span></span>

<span data-ttu-id="9a92a-358">Direct3D のアプリ コード</span><span class="sxs-lookup"><span data-stu-id="9a92a-358">Direct3D app code</span></span>

```cpp
struct ConstantBuffer
{
    XMFLOAT4X4 model;
    XMFLOAT4X4 view;
    XMFLOAT4X4 projection;
};
struct SimpleCubeVertex
{
    XMFLOAT3 pos;   // position
    XMFLOAT3 color; // color
};

 // Create an input layout that matches the layout defined in the vertex shader code.
 const D3D11_INPUT_ELEMENT_DESC basicVertexLayoutDesc[] =
 {
     { "POSITION", 0, DXGI_FORMAT_R32G32B32_FLOAT, 0,  0, D3D11_INPUT_PER_VERTEX_DATA, 0 },
     { "COLOR",    0, DXGI_FORMAT_R32G32B32_FLOAT, 0, 12, D3D11_INPUT_PER_VERTEX_DATA, 0 },
 };

// Create vertex and index buffers that define a geometry.
```

<span data-ttu-id="9a92a-359">HLSL の頂点シェーダー コード</span><span class="sxs-lookup"><span data-stu-id="9a92a-359">HLSL vertex shader code</span></span>

``` syntax
cbuffer ModelViewProjectionCB : register( b0 )
{
    matrix model; 
    matrix view;
    matrix projection;
};
// The POSITION and COLOR semantics must match the semantics in the input layout Direct3D app code.
struct VertexShaderInput
{
    float3 pos : POSITION; // Incoming position of vertex 
    float3 color : COLOR; // Incoming color for the vertex
};

struct PixelShaderInput
{
    float4 pos : SV_Position; // Copy the vertex position.
    float4 color : COLOR; // Pass the color to the pixel shader.
};

PixelShaderInput main(VertexShaderInput input)
{
    PixelShaderInput vertexShaderOutput;

    // shader source code

    return vertexShaderOutput;
}
```

<span data-ttu-id="9a92a-360">HLSL のピクセル シェーダー コード</span><span class="sxs-lookup"><span data-stu-id="9a92a-360">HLSL pixel shader code</span></span>

``` syntax
// Collect input from the vertex shader. 
// The COLOR semantic must match the semantic in the vertex shader code.
struct PixelShaderInput
{
    float4 pos : SV_Position;
    float4 color : COLOR; // Color for the pixel
};

// Set the pixel color value for the renter target. 
float4 main(PixelShaderInput input) : SV_Target
{
    return input.color;
}
```

## <a name="examples-of-porting-opengl-rendering-code-to-direct3d"></a><span data-ttu-id="9a92a-361">Direct3D への OpenGL のレンダリング コードの移植例</span><span class="sxs-lookup"><span data-stu-id="9a92a-361">Examples of porting OpenGL rendering code to Direct3D</span></span>


<span data-ttu-id="9a92a-362">ここでは、OpenGL ES 2.0 コードのレンダリングの例と、Direct3D 11 コードでの相当する例を紹介します。</span><span class="sxs-lookup"><span data-stu-id="9a92a-362">Here we show an example of rendering in OpenGL ES 2.0 code and then the equivalent example in Direct3D 11 code.</span></span>

<span data-ttu-id="9a92a-363">OpenGL のレンダリング コード</span><span class="sxs-lookup"><span data-stu-id="9a92a-363">OpenGL rendering code</span></span>

``` syntax
// Bind shaders to the pipeline. 
// Both vertex shader and fragment shader are in a program.
glUseProgram(m_shader->getProgram());
 
// Input asssembly 
// Get the position and color attributes of the vertex.

m_positionLocation = glGetAttribLocation(m_shader->getProgram(), "position");
glEnableVertexAttribArray(m_positionLocation);

m_colorLocation = glGetAttribColor(m_shader->getProgram(), "color");
glEnableVertexAttribArray(m_colorLocation);
 
// Bind the vertex buffer object to the input assembler.
glBindBuffer(GL_ARRAY_BUFFER, m_geometryBuffer);
glVertexAttribPointer(m_positionLocation, 4, GL_FLOAT, GL_FALSE, 0, NULL);
glBindBuffer(GL_ARRAY_BUFFER, m_colorBuffer);
glVertexAttribPointer(m_colorLocation, 3, GL_FLOAT, GL_FALSE, 0, NULL);
 
// Draw a triangle with 3 vertices.
glDrawArray(GL_TRIANGLES, 0, 3);
```

<span data-ttu-id="9a92a-364">Direct3D のレンダリング コード</span><span class="sxs-lookup"><span data-stu-id="9a92a-364">Direct3D rendering code</span></span>

```cpp
// Bind the vertex shader and pixel shader to the pipeline.
m_d3dDeviceContext->VSSetShader(vertexShader.Get(),nullptr,0);
m_d3dDeviceContext->PSSetShader(pixelShader.Get(),nullptr,0);
 
// Declare the inputs that the shaders expect.
m_d3dDeviceContext->IASetInputLayout(inputLayout.Get());
m_d3dDeviceContext->IASetVertexBuffers(0, 1, vertexBuffer.GetAddressOf(), &stride, &offset);

// Set the primitive's topology.
m_d3dDeviceContext->IASetPrimitiveTopology(D3D11_PRIMITIVE_TOPOLOGY_TRIANGLELIST);

// Draw a triangle with 3 vertices. triangleVertices is an array of 3 vertices.
m_d3dDeviceContext->Draw(ARRAYSIZE(triangleVertices),0);
```

## <a name="related-topics"></a><span data-ttu-id="9a92a-365">関連トピック</span><span class="sxs-lookup"><span data-stu-id="9a92a-365">Related topics</span></span>


* [<span data-ttu-id="9a92a-366">OpenGL ES 2.0 から Direct3D 11 への移植</span><span class="sxs-lookup"><span data-stu-id="9a92a-366">Port from OpenGL ES 2.0 to Direct3D 11</span></span>](port-from-opengl-es-2-0-to-directx-11-1.md)

 

 




