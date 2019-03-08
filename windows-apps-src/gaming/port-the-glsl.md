---
title: GLSL の移植
description: バッファーとシェーダー オブジェクトを作成して構成するコードが完成したら、それらのシェーダー内のコードを OpenGL ES 2.0 の GL シェーダー言語 (GLSL) から Direct3D 11 の上位レベル シェーダー言語 (HLSL) に移植します。
ms.assetid: 0de06c51-8a34-dc68-6768-ea9f75dc57ee
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, GLSL, 移植
ms.localizationpriority: medium
ms.openlocfilehash: 809440f9e77af19c01f4a050eee3b6f8d1c709b7
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57621377"
---
# <a name="port-the-glsl"></a><span data-ttu-id="a4262-104">GLSL の移植</span><span class="sxs-lookup"><span data-stu-id="a4262-104">Port the GLSL</span></span>




<span data-ttu-id="a4262-105">**重要な API**</span><span class="sxs-lookup"><span data-stu-id="a4262-105">**Important APIs**</span></span>

-   [<span data-ttu-id="a4262-106">HLSL のセマンティクス</span><span class="sxs-lookup"><span data-stu-id="a4262-106">HLSL Semantics</span></span>](https://msdn.microsoft.com/library/windows/desktop/bb205574)
-   [<span data-ttu-id="a4262-107">シェーダー定数 (HLSL)</span><span class="sxs-lookup"><span data-stu-id="a4262-107">Shader Constants (HLSL)</span></span>](https://msdn.microsoft.com/library/windows/desktop/bb509581)

<span data-ttu-id="a4262-108">バッファーとシェーダー オブジェクトを作成して構成するコードが完成したら、それらのシェーダー内のコードを OpenGL ES 2.0 の GL シェーダー言語 (GLSL) から Direct3D 11 の上位レベル シェーダー言語 (HLSL) に移植します。</span><span class="sxs-lookup"><span data-stu-id="a4262-108">Once you've moved over the code that creates and configures your buffers and shader objects, it's time to port the code inside those shaders from OpenGL ES 2.0's GL Shader Language (GLSL) to Direct3D 11's High-level Shader Language (HLSL).</span></span>

<span data-ttu-id="a4262-109">OpenGL ES 2.0 でシェーダーがなどの組み込み関数を使用して実行後にデータを返す**gl\_位置**、 **gl\_FragColor**、または**gl\_FragData\[n\]**  (n は、特定のレンダー ターゲットのインデックスです)。</span><span class="sxs-lookup"><span data-stu-id="a4262-109">In OpenGL ES 2.0, shaders return data after execution using intrinsics such as **gl\_Position**, **gl\_FragColor**, or **gl\_FragData\[n\]** (where n is the index for a specific render target).</span></span> <span data-ttu-id="a4262-110">Direct3D では、特定の組み込みメソッドはなく、シェーダーはそれぞれの main() 関数の戻り値の型としてデータを返します。</span><span class="sxs-lookup"><span data-stu-id="a4262-110">In Direct3D, there are no specific intrinsics, and the shaders return data as the return type of their respective main() functions.</span></span>

<span data-ttu-id="a4262-111">頂点の位置や法線など、シェーダー ステージ間で補間されるデータは、**varying** 宣言を使って処理します。</span><span class="sxs-lookup"><span data-stu-id="a4262-111">Data that you want interpolated between shader stages, such as the vertex position or normal, is handled through the use of the **varying** declaration.</span></span> <span data-ttu-id="a4262-112">ただし、Direct3D にはこの宣言がありません。そのため、シェーダー ステージ間で受け渡されるデータは [HLSL セマンティクス](https://msdn.microsoft.com/library/windows/desktop/bb205574)でマークする必要があります。</span><span class="sxs-lookup"><span data-stu-id="a4262-112">However, Direct3D doesn't have this declaration; rather, any data that you want passed between shader stages must be marked with an [HLSL semantic](https://msdn.microsoft.com/library/windows/desktop/bb205574).</span></span> <span data-ttu-id="a4262-113">選んだ特定のセマンティクスはデータの目的を示します。</span><span class="sxs-lookup"><span data-stu-id="a4262-113">The specific semantic chosen indicates the purpose of the data, and is.</span></span> <span data-ttu-id="a4262-114">たとえば、フラグメント シェーダー間で補完される頂点データは次のように宣言します。</span><span class="sxs-lookup"><span data-stu-id="a4262-114">For example, you'd declare vertex data that you want interpolated between the fragment shader as:</span></span>

`float4 vertPos : POSITION;`

<span data-ttu-id="a4262-115">または</span><span class="sxs-lookup"><span data-stu-id="a4262-115">or</span></span>

`float4 vertColor : COLOR;`

<span data-ttu-id="a4262-116">POSITION は、頂点の位置データを示すために使うセマンティクスです。</span><span class="sxs-lookup"><span data-stu-id="a4262-116">Where POSITION is the semantic used to indicate vertex position data.</span></span> <span data-ttu-id="a4262-117">また、POSITION は特殊なケースで、補間後にピクセル シェーダーからアクセスできません。</span><span class="sxs-lookup"><span data-stu-id="a4262-117">POSITION is also a special case, since after interpolation, it cannot be accessed by the pixel shader.</span></span> <span data-ttu-id="a4262-118">したがって、SV でピクセル シェーダーへの入力を指定する必要があります\_位置と、補間された頂点データは、その変数に配置されます。</span><span class="sxs-lookup"><span data-stu-id="a4262-118">Therefore, you must specify input to the pixel shader with SV\_POSITION and the interpolated vertex data will be placed in that variable.</span></span>

`float4 position : SV_POSITION;`

<span data-ttu-id="a4262-119">セマンティクスは、シェーダーの body (main) メソッドで宣言できます。</span><span class="sxs-lookup"><span data-stu-id="a4262-119">Semantics can be declared on the body (main) methods of shaders.</span></span> <span data-ttu-id="a4262-120">ピクセル シェーダー、SV の\_ターゲット\[n\]、本文メソッドで必要なレンダー ターゲットを示します。</span><span class="sxs-lookup"><span data-stu-id="a4262-120">For pixel shaders, SV\_TARGET\[n\], which indicates a render target, is required on the body method.</span></span> <span data-ttu-id="a4262-121">(SV\_ターゲット インデックス 0 を表示するために既定値は数値のサフィックスなしの対象です)。</span><span class="sxs-lookup"><span data-stu-id="a4262-121">(SV\_TARGET without a numeric suffix defaults to render target index 0.)</span></span>

<span data-ttu-id="a4262-122">また 頂点シェーダーが SV を出力するために必要なことに注意してください\_位置システム値セマンティック。</span><span class="sxs-lookup"><span data-stu-id="a4262-122">Also note that vertex shaders are required to output the SV\_POSITION system value semantic.</span></span> <span data-ttu-id="a4262-123">このセマンティクスは頂点の位置データを座標値に解決します。x は -1 ～ 1 の値に、y は -1 ～ 1 の値になり、z は元の同次座標 w の値で割られ (z/w)、w は 1 を元の w の値で割った値 (1/w) になります。</span><span class="sxs-lookup"><span data-stu-id="a4262-123">This semantic resolves the vertex position data to coordinate values where x is between -1 and 1, y is between -1 and 1, z is divided by the original homogeneous coordinate w value (z/w), and w is 1 divided by the original w value (1/w).</span></span> <span data-ttu-id="a4262-124">ピクセル シェーダーを使用して、SV\_セマンティック x が 0 と、レンダー ターゲットの幅と y の間は、画面のピクセル位置を取得する位置のシステム値が 0 ~ レンダー ターゲットの高さ (0.5 で各オフセット)。</span><span class="sxs-lookup"><span data-stu-id="a4262-124">Pixel shaders use the SV\_POSITION system value semantic to retrieve the pixel location on the screen, where x is between 0 and the render target width and y is between 0 and the render target height (each offset by 0.5).</span></span> <span data-ttu-id="a4262-125">機能レベル 9\_ピクセル シェーダーは、SV から読み取ることができません x\_位置の値。</span><span class="sxs-lookup"><span data-stu-id="a4262-125">Feature level 9\_x pixel shaders cannot read from the SV\_POSITION value.</span></span>

<span data-ttu-id="a4262-126">定数バッファーは **cbuffer** を使って宣言し、検索のために特定の開始レジスタに関連付ける必要があります。</span><span class="sxs-lookup"><span data-stu-id="a4262-126">Constant buffers must be declared with **cbuffer** and be associated with a specific starting register for lookup.</span></span>

<span data-ttu-id="a4262-127">Direct3D 11。HLSL 定数バッファーの宣言は、</span><span class="sxs-lookup"><span data-stu-id="a4262-127">Direct3D 11: An HLSL constant buffer declaration</span></span>

``` syntax
cbuffer ModelViewProjectionConstantBuffer : register(b0)
{
  matrix mvp;
};
```

<span data-ttu-id="a4262-128">ここでは、定数バッファーはレジスタ b0 を使って、パックされたバッファーを保持します。</span><span class="sxs-lookup"><span data-stu-id="a4262-128">Here, the constant buffer uses register b0 to hold the packed buffer.</span></span> <span data-ttu-id="a4262-129">すべてのレジスタ フォーム b で参照される\#します。</span><span class="sxs-lookup"><span data-stu-id="a4262-129">All registers are referred to in the form b\#.</span></span> <span data-ttu-id="a4262-130">HLSL での定数バッファー、レジスタ、データ パッキングの実装について詳しくは、「[シェーダー定数 (HLSL)](https://msdn.microsoft.com/library/windows/desktop/bb509581)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a4262-130">For more information on the HLSL implementation of constant buffers, registers, and data packing, read [Shader Constants (HLSL)](https://msdn.microsoft.com/library/windows/desktop/bb509581).</span></span>

<a name="instructions"></a><span data-ttu-id="a4262-131">手順</span><span class="sxs-lookup"><span data-stu-id="a4262-131">Instructions</span></span>
------------
### <a name="step-1-port-the-vertex-shader"></a><span data-ttu-id="a4262-132">手順 1:ポート、頂点シェーダー</span><span class="sxs-lookup"><span data-stu-id="a4262-132">Step 1: Port the vertex shader</span></span>

<span data-ttu-id="a4262-133">この簡単な OpenGL ES 2.0 の例では、頂点シェーダーに 3 つの入力があります。1 つの定数のモデル ビュー プロジェクション 4x4 マトリックスと 2 つの 4 座標ベクトルです。</span><span class="sxs-lookup"><span data-stu-id="a4262-133">In our simple OpenGL ES 2.0 example, the vertex shader has three inputs: a constant model-view-projection 4x4 matrix, and two 4-coordinate vectors.</span></span> <span data-ttu-id="a4262-134">これら 2 つのベクトルには、頂点の位置と色が含まれます。</span><span class="sxs-lookup"><span data-stu-id="a4262-134">These two vectors contain the vertex position and its color.</span></span> <span data-ttu-id="a4262-135">シェーダーがパースペクティブ座標に position ベクトルを変換し、gl に代入\_ラスタライズの組み込みの位置。</span><span class="sxs-lookup"><span data-stu-id="a4262-135">The shader transforms the position vector to perspective coordinates and assigns it to the gl\_Position intrinsic for rasterization.</span></span> <span data-ttu-id="a4262-136">また、頂点の色は、ラスタライズ時に補間のために varying 変数にコピーされます。</span><span class="sxs-lookup"><span data-stu-id="a4262-136">The vertex color is copied to a varying variable for interpolation during rasterization, as well.</span></span>

<span data-ttu-id="a4262-137">OpenGL ES 2.0:キューブ オブジェクト (GLSL) の頂点シェーダー</span><span class="sxs-lookup"><span data-stu-id="a4262-137">OpenGL ES 2.0: Vertex shader for the cube object (GLSL)</span></span>

``` syntax
uniform mat4 u_mvpMatrix; 
attribute vec4 a_position;
attribute vec4 a_color;
varying vec4 destColor;

void main()
{           
  gl_Position = u_mvpMatrix * a_position;
  destColor = a_color;
}
```

<span data-ttu-id="a4262-138">次に、direct3d で定数のモデル-ビュー-射影行列がレジスタ b0 に搭載された定数バッファーに含まれているし、頂点の位置と色が、適切なそれぞれの HLSL セマンティクスでマークされた具体的には。位置や色。</span><span class="sxs-lookup"><span data-stu-id="a4262-138">Now, in Direct3D, the constant model-view-projection matrix is contained in a constant buffer packed at register b0, and the vertex position and color are specifically marked with the appropriate respective HLSL semantics: POSITION and COLOR.</span></span> <span data-ttu-id="a4262-139">入力レイアウトはこれら 2 つの頂点の値の特定の配置を示しているため、それらの値を保持する構造体を作成し、シェーダーの body 関数 (main) でその構造体を入力パラメーターの型として宣言します </span><span class="sxs-lookup"><span data-stu-id="a4262-139">Since our input layout indicates a specific arrangement of these two vertex values, you create a struct to hold them and declare it as the type for the input parameter on the shader body function (main).</span></span> <span data-ttu-id="a4262-140">(2 つの個別のパラメーターとして指定することも、面倒を取得する可能性があります)。このステージでは、挿入位置と色を含む出力の種類を指定し、頂点シェーダーの本文の関数の戻り値として変数を宣言します。</span><span class="sxs-lookup"><span data-stu-id="a4262-140">(You could also specify them as two individual parameters, but that could get cumbersome.) You also specify an output type for this stage, which contains the interpolated position and color, and declare it as the return value for the body function of the vertex shader.</span></span>

<span data-ttu-id="a4262-141">Direct3D 11。キューブ オブジェクト (HLSL) の頂点シェーダー</span><span class="sxs-lookup"><span data-stu-id="a4262-141">Direct3D 11: Vertex shader for the cube object (HLSL)</span></span>

``` syntax
cbuffer ModelViewProjectionConstantBuffer : register(b0)
{
  matrix mvp;
};

// Per-vertex data used as input to the vertex shader.
struct VertexShaderInput
{
  float3 pos : POSITION;
  float3 color : COLOR;
};

// Per-vertex color data passed through the pixel shader.
struct PixelShaderInput
{
  float3 pos : SV_POSITION;
  float3 color : COLOR;
};

PixelShaderInput main(VertexShaderInput input)
{
  PixelShaderInput output;
  float4 pos = float4(input.pos, 1.0f); // add the w-coordinate

  pos = mul(mvp, projection);
  output.pos = pos;

  output.color = input.color;

  return output;
}
```

<span data-ttu-id="a4262-142">出力のデータ型 PixelShaderInput は、ラスタライズ時に設定され、フラグメント (ピクセル) シェーダーに渡されます。</span><span class="sxs-lookup"><span data-stu-id="a4262-142">The output data type, PixelShaderInput, is populated during rasterization and provided to the fragment (pixel) shader.</span></span>

### <a name="step-2-port-the-fragment-shader"></a><span data-ttu-id="a4262-143">手順 2:ポート フラグメント シェーダー</span><span class="sxs-lookup"><span data-stu-id="a4262-143">Step 2: Port the fragment shader</span></span>

<span data-ttu-id="a4262-144">GLSL で、例のフラグメント シェーダーは非常に単純: 提供、gl\_FragColor 色の補間値を持つ組み込み。</span><span class="sxs-lookup"><span data-stu-id="a4262-144">Our example fragment shader in GLSL is extremely simple: provide the gl\_FragColor intrinsic with the interpolated color value.</span></span> <span data-ttu-id="a4262-145">OpenGL ES 2.0 では、それを既定のレンダー ターゲットに書き込みます。</span><span class="sxs-lookup"><span data-stu-id="a4262-145">OpenGL ES 2.0 will write it to the default render target.</span></span>

<span data-ttu-id="a4262-146">OpenGL ES 2.0:キューブ オブジェクト (GLSL) のフラグメント シェーダー</span><span class="sxs-lookup"><span data-stu-id="a4262-146">OpenGL ES 2.0: Fragment shader for the cube object (GLSL)</span></span>

``` syntax
varying vec4 destColor;

void main()
{
  gl_FragColor = destColor;
} 
```

<span data-ttu-id="a4262-147">Direct3D も同じくらい簡単です。</span><span class="sxs-lookup"><span data-stu-id="a4262-147">Direct3D is almost as simple.</span></span> <span data-ttu-id="a4262-148">大きな違いは、ピクセル シェーダーの body 関数で値を返す必要があることだけです。</span><span class="sxs-lookup"><span data-stu-id="a4262-148">The only significant difference is that the body function of the pixel shader must return a value.</span></span> <span data-ttu-id="a4262-149">Float4 として戻り値の型を示すし、SV として既定のレンダー ターゲットを指定し、色は、4 座標 (RGBA) の浮動小数点値であるため\_ターゲット システム値セマンティック。</span><span class="sxs-lookup"><span data-stu-id="a4262-149">Since the color is a 4-coordinate (RGBA) float value, you indicate float4 as the return type, and then specify the default render target as the SV\_TARGET system value semantic.</span></span>

<span data-ttu-id="a4262-150">Direct3D 11。キューブ オブジェクト (HLSL) のピクセル シェーダー</span><span class="sxs-lookup"><span data-stu-id="a4262-150">Direct3D 11: Pixel shader for the cube object (HLSL)</span></span>

``` syntax
struct PixelShaderInput
{
  float4 pos : SV_POSITION;
  float3 color : COLOR;
};


float4 main(PixelShaderInput input) : SV_TARGET
{
  return float4(input.color, 1.0f);
}
```

<span data-ttu-id="a4262-151">位置のピクセルの色はレンダー ターゲットに書き込まれます。</span><span class="sxs-lookup"><span data-stu-id="a4262-151">The color for the pixel at the position is written to the render target.</span></span> <span data-ttu-id="a4262-152">次に、「[画面への描画](draw-to-the-screen.md)」でそのレンダー ターゲットのコンテンツを表示する方法を見ていきます。</span><span class="sxs-lookup"><span data-stu-id="a4262-152">Now, let's see how to display the contents of that render target in [Draw to the screen](draw-to-the-screen.md)!</span></span>

## <a name="previous-step"></a><span data-ttu-id="a4262-153">前のステップ</span><span class="sxs-lookup"><span data-stu-id="a4262-153">Previous step</span></span>


<span data-ttu-id="a4262-154">[頂点バッファーと頂点データの移植](port-the-vertex-buffers-and-data-config.md) 次の手順</span><span class="sxs-lookup"><span data-stu-id="a4262-154">[Port the vertex buffers and data](port-the-vertex-buffers-and-data-config.md) Next step</span></span>
---------
<span data-ttu-id="a4262-155">[画面への描画](draw-to-the-screen.md) 解説</span><span class="sxs-lookup"><span data-stu-id="a4262-155">[Draw to the screen](draw-to-the-screen.md) Remarks</span></span>
-------
<span data-ttu-id="a4262-156">HLSL セマンティクスと定数バッファーのパッキングについて理解すると、デバッグの苦労がいくらか少なくなるだけでなく、最適化できるようにもなります。</span><span class="sxs-lookup"><span data-stu-id="a4262-156">Understanding HLSL semantics and the packing of constant buffers can save you a bit of a debugging headache, as well as provide optimization opportunities.</span></span> <span data-ttu-id="a4262-157">機会を得る場合読んで[変数構文 (HLSL)](https://msdn.microsoft.com/library/windows/desktop/bb509706)、 [direct3d11 のバッファーの概要](https://msdn.microsoft.com/library/windows/desktop/ff476898)、および[方法。定数バッファーを作成](https://msdn.microsoft.com/library/windows/desktop/ff476896)です。</span><span class="sxs-lookup"><span data-stu-id="a4262-157">If you get a chance, read through [Variable Syntax (HLSL)](https://msdn.microsoft.com/library/windows/desktop/bb509706), [Introduction to Buffers in Direct3D 11](https://msdn.microsoft.com/library/windows/desktop/ff476898), and [How to: Create a Constant Buffer](https://msdn.microsoft.com/library/windows/desktop/ff476896).</span></span> <span data-ttu-id="a4262-158">機会がない場合は、次のセマンティクスと定数バッファーについての基本的なヒントを心に留めておいてください。</span><span class="sxs-lookup"><span data-stu-id="a4262-158">If not, though, here's a few starting tips to keep in mind about semantics and constant buffers:</span></span>

-   <span data-ttu-id="a4262-159">必ずレンダラーの Direct3D 構成コードを見直して、定数バッファーの構造体が HLSL の cbuffer 構造体の宣言と一致し、コンポーネントのスカラー型が両方の宣言で一致していることを確認する。</span><span class="sxs-lookup"><span data-stu-id="a4262-159">Always double check your renderer's Direct3D configuration code to make sure that the structures for your constant buffers match the cbuffer struct declarations in your HLSL, and that the component scalar types match across both declarations.</span></span>
-   <span data-ttu-id="a4262-160">レンダラーの C++ コードでは、データ パッキングが適切に行われるように、定数バッファーの宣言で [DirectXMath](https://msdn.microsoft.com/library/windows/desktop/hh437833) 型を使う。</span><span class="sxs-lookup"><span data-stu-id="a4262-160">In your renderer's C++ code, use [DirectXMath](https://msdn.microsoft.com/library/windows/desktop/hh437833) types in your constant buffer declarations to ensure proper data packing.</span></span>
-   <span data-ttu-id="a4262-161">定数バッファーを効率的に使う最良の方法として、更新頻度に応じてシェーダーの変数を定数バッファーにまとめる。</span><span class="sxs-lookup"><span data-stu-id="a4262-161">The best way to efficiently use constant buffers is to organize shader variables into constant buffers based on their frequency of update.</span></span> <span data-ttu-id="a4262-162">たとえば、フレームごとに 1 回更新される uniform データと、カメラが移動したときにだけ更新される uniform データがある場合は、それらのデータを 2 つの定数バッファーに分けることを考えます。</span><span class="sxs-lookup"><span data-stu-id="a4262-162">For example, if you have some uniform data that is updated once per frame, and other uniform data that is updated only when the camera moves, consider separating that data into two separate constant buffers.</span></span>
-   <span data-ttu-id="a4262-163">セマンティクスの適用し忘れや誤った適用は、シェーダー コンパイル (FXC) エラーのよくある原因である。</span><span class="sxs-lookup"><span data-stu-id="a4262-163">Semantics that you have forgotten to apply or which you have applied incorrectly will be your earliest source of shader compilation (FXC) errors.</span></span> <span data-ttu-id="a4262-164">よく見直してください。</span><span class="sxs-lookup"><span data-stu-id="a4262-164">Double-check them!</span></span> <span data-ttu-id="a4262-165">以前のページやサンプルの多くでは Direct3D 11 より前のさまざまなバージョンの HLSL セマンティクスを参照しているため、ドキュメントが混乱を招くことがあります。</span><span class="sxs-lookup"><span data-stu-id="a4262-165">The docs can be a bit confusing, as many older pages and samples refer to different versions of HLSL semantics prior to Direct3D 11.</span></span>
-   <span data-ttu-id="a4262-166">各シェーダーのターゲットとする Direct3D 機能レベルを確認する。</span><span class="sxs-lookup"><span data-stu-id="a4262-166">Make sure you know which Direct3D feature level you are targeting for each shader.</span></span> <span data-ttu-id="a4262-167">機能をセマンティクス レベル 9\_ \*が 11 の異なる\_1。</span><span class="sxs-lookup"><span data-stu-id="a4262-167">The semantics for feature level 9\_\* are different from those for 11\_1.</span></span>
-   <span data-ttu-id="a4262-168">SV\_位置セマンティック解決の座標 x は 0 と、レンダー ターゲットの幅、y の間で値を後の補間の関連付けられている位置データが 0 ~、レンダー ターゲットの高さ、z が元の同種の座標 w で割った値値 (z/w)、および w は、元の w 値 (1 w) で割った値 1 です。</span><span class="sxs-lookup"><span data-stu-id="a4262-168">The SV\_POSITION semantic resolves the associated post-interpolation position data to coordinate values where x is between 0 and the render target width, y is between 0 and the render target height, z is divided by the original homogeneous coordinate w value (z/w), and w is 1 divided by the original w value (1/w).</span></span>

## <a name="related-topics"></a><span data-ttu-id="a4262-169">関連トピック</span><span class="sxs-lookup"><span data-stu-id="a4262-169">Related topics</span></span>


[<span data-ttu-id="a4262-170">方法: direct3d11 を単純な OpenGL ES 2.0 レンダラーのポート</span><span class="sxs-lookup"><span data-stu-id="a4262-170">How to: port a simple OpenGL ES 2.0 renderer to Direct3D 11</span></span>](port-a-simple-opengl-es-2-0-renderer-to-directx-11-1.md)

[<span data-ttu-id="a4262-171">シェーダー オブジェクトの移植</span><span class="sxs-lookup"><span data-stu-id="a4262-171">Port the shader objects</span></span>](port-the-shader-config.md)

[<span data-ttu-id="a4262-172">頂点バッファーと頂点データの移植</span><span class="sxs-lookup"><span data-stu-id="a4262-172">Port the vertex buffers and data</span></span>](port-the-vertex-buffers-and-data-config.md)

[<span data-ttu-id="a4262-173">画面への描画</span><span class="sxs-lookup"><span data-stu-id="a4262-173">Draw to the screen</span></span>](draw-to-the-screen.md)

 

 




