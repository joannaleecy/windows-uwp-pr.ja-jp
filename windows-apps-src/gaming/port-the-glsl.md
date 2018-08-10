---
author: mtoepke
title: GLSL の移植
description: バッファーとシェーダー オブジェクトを作成して構成するコードが完成したら、それらのシェーダー内のコードを OpenGL ES 2.0 の GL シェーダー言語 (GLSL) から Direct3D 11 の上位レベル シェーダー言語 (HLSL) に移植します。
ms.assetid: 0de06c51-8a34-dc68-6768-ea9f75dc57ee
ms.author: mtoepke
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, ゲーム, GLSL, 移植
ms.openlocfilehash: 7416a4dafe24f86243a3a9962d01db1dc7b61031
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.locfileid: "243270"
---
# <a name="port-the-glsl"></a><span data-ttu-id="125da-104">GLSL の移植</span><span class="sxs-lookup"><span data-stu-id="125da-104">Port the GLSL</span></span>


<span data-ttu-id="125da-105">\[ Windows 10 の UWP アプリ向けに更新。</span><span class="sxs-lookup"><span data-stu-id="125da-105">\[ Updated for UWP apps on Windows 10.</span></span> <span data-ttu-id="125da-106">Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください。\]</span><span class="sxs-lookup"><span data-stu-id="125da-106">For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]</span></span>


**<span data-ttu-id="125da-107">重要な API</span><span class="sxs-lookup"><span data-stu-id="125da-107">Important APIs</span></span>**

-   [<span data-ttu-id="125da-108">HLSL セマンティクス</span><span class="sxs-lookup"><span data-stu-id="125da-108">HLSL Semantics</span></span>](https://msdn.microsoft.com/library/windows/desktop/bb205574)
-   [<span data-ttu-id="125da-109">シェーダー定数 (HLSL)</span><span class="sxs-lookup"><span data-stu-id="125da-109">Shader Constants (HLSL)</span></span>](https://msdn.microsoft.com/library/windows/desktop/bb509581)

<span data-ttu-id="125da-110">バッファーとシェーダー オブジェクトを作成して構成するコードが完成したら、それらのシェーダー内のコードを OpenGL ES 2.0 の GL シェーダー言語 (GLSL) から Direct3D 11 の上位レベル シェーダー言語 (HLSL) に移植します。</span><span class="sxs-lookup"><span data-stu-id="125da-110">Once you've moved over the code that creates and configures your buffers and shader objects, it's time to port the code inside those shaders from OpenGL ES 2.0's GL Shader Language (GLSL) to Direct3D 11's High-level Shader Language (HLSL).</span></span>

<span data-ttu-id="125da-111">OpenGL ES 2.0 では、シェーダーは **gl\_Position**、**gl\_FragColor**、または **gl\_FragData\[n\]** (n は特定のレンダー ターゲットのインデックス) などの組み込みメソッドを使って実行した後にデータを返します。</span><span class="sxs-lookup"><span data-stu-id="125da-111">In OpenGL ES 2.0, shaders return data after execution using intrinsics such as **gl\_Position**, **gl\_FragColor**, or **gl\_FragData\[n\]** (where n is the index for a specific render target).</span></span> <span data-ttu-id="125da-112">Direct3D では、特定の組み込みメソッドはなく、シェーダーはそれぞれの main() 関数の戻り値の型としてデータを返します。</span><span class="sxs-lookup"><span data-stu-id="125da-112">In Direct3D, there are no specific intrinsics, and the shaders return data as the return type of their respective main() functions.</span></span>

<span data-ttu-id="125da-113">頂点の位置や法線など、シェーダー ステージ間で補間されるデータは、**varying** 宣言を使って処理します。</span><span class="sxs-lookup"><span data-stu-id="125da-113">Data that you want interpolated between shader stages, such as the vertex position or normal, is handled through the use of the **varying** declaration.</span></span> <span data-ttu-id="125da-114">ただし、Direct3D にはこの宣言がありません。そのため、シェーダー ステージ間で受け渡されるデータは [HLSL セマンティクス](https://msdn.microsoft.com/library/windows/desktop/bb205574)でマークする必要があります。</span><span class="sxs-lookup"><span data-stu-id="125da-114">However, Direct3D doesn't have this declaration; rather, any data that you want passed between shader stages must be marked with an [HLSL semantic](https://msdn.microsoft.com/library/windows/desktop/bb205574).</span></span> <span data-ttu-id="125da-115">選んだ特定のセマンティクスはデータの目的を示します。</span><span class="sxs-lookup"><span data-stu-id="125da-115">The specific semantic chosen indicates the purpose of the data, and is.</span></span> <span data-ttu-id="125da-116">たとえば、フラグメント シェーダー間で補完される頂点データは次のように宣言します。</span><span class="sxs-lookup"><span data-stu-id="125da-116">For example, you'd declare vertex data that you want interpolated between the fragment shader as:</span></span>

`float4 vertPos : POSITION;`

<span data-ttu-id="125da-117">または</span><span class="sxs-lookup"><span data-stu-id="125da-117">or</span></span>

`float4 vertColor : COLOR;`

<span data-ttu-id="125da-118">POSITION は、頂点の位置データを示すために使うセマンティクスです。</span><span class="sxs-lookup"><span data-stu-id="125da-118">Where POSITION is the semantic used to indicate vertex position data.</span></span> <span data-ttu-id="125da-119">また、POSITION は特殊なケースで、補間後にピクセル シェーダーからアクセスできません。</span><span class="sxs-lookup"><span data-stu-id="125da-119">POSITION is also a special case, since after interpolation, it cannot be accessed by the pixel shader.</span></span> <span data-ttu-id="125da-120">そのため、SV\_POSITION を使ってピクセル シェーダーへの入力を指定する必要があります。補完された頂点データはその変数に配置されます。</span><span class="sxs-lookup"><span data-stu-id="125da-120">Therefore, you must specify input to the pixel shader with SV\_POSITION and the interpolated vertex data will be placed in that variable.</span></span>

`float4 position : SV_POSITION;`

<span data-ttu-id="125da-121">セマンティクスは、シェーダーの body (main) メソッドで宣言できます。</span><span class="sxs-lookup"><span data-stu-id="125da-121">Semantics can be declared on the body (main) methods of shaders.</span></span> <span data-ttu-id="125da-122">ピクセル シェーダーでは、body メソッドにレンダー ターゲットを示す SV\_TARGET\[n\] が必要です </span><span class="sxs-lookup"><span data-stu-id="125da-122">For pixel shaders, SV\_TARGET\[n\], which indicates a render target, is required on the body method.</span></span> <span data-ttu-id="125da-123">(数値サフィックスのない SV\_TARGET は、既定でレンダー ターゲット インデックス 0 に設定されます)。</span><span class="sxs-lookup"><span data-stu-id="125da-123">(SV\_TARGET without a numeric suffix defaults to render target index 0.)</span></span>

<span data-ttu-id="125da-124">また、頂点シェーダーでは、SV\_POSITION システム値セマンティクスを出力する必要があります。</span><span class="sxs-lookup"><span data-stu-id="125da-124">Also note that vertex shaders are required to output the SV\_POSITION system value semantic.</span></span> <span data-ttu-id="125da-125">このセマンティクスは頂点の位置データを座標値に解決します。x は -1 ～ 1 の値に、y は -1 ～ 1 の値になり、z は元の同次座標 w の値で割られ (z/w)、w は 1 を元の w の値で割った値 (1/w) になります。</span><span class="sxs-lookup"><span data-stu-id="125da-125">This semantic resolves the vertex position data to coordinate values where x is between -1 and 1, y is between -1 and 1, z is divided by the original homogeneous coordinate w value (z/w), and w is 1 divided by the original w value (1/w).</span></span> <span data-ttu-id="125da-126">ピクセル シェーダーでは、SV\_POSITION システム値セマンティクスを使って、画面上のピクセル位置を取得します。x は 0 からレンダー ターゲットの幅までの値に、y は 0 からレンダー ターゲットの高さまでの値になります (各オフセットは 0.5 単位)。</span><span class="sxs-lookup"><span data-stu-id="125da-126">Pixel shaders use the SV\_POSITION system value semantic to retrieve the pixel location on the screen, where x is between 0 and the render target width and y is between 0 and the render target height (each offset by 0.5).</span></span> <span data-ttu-id="125da-127">機能レベル 9\_x ピクセル シェーダーでは、SV\_POSITION 値から読み取ることができません。</span><span class="sxs-lookup"><span data-stu-id="125da-127">Feature level 9\_x pixel shaders cannot read from the SV\_POSITION value.</span></span>

<span data-ttu-id="125da-128">定数バッファーは **cbuffer** を使って宣言し、検索のために特定の開始レジスタに関連付ける必要があります。</span><span class="sxs-lookup"><span data-stu-id="125da-128">Constant buffers must be declared with **cbuffer** and be associated with a specific starting register for lookup.</span></span>

<span data-ttu-id="125da-129">Direct3D 11: HLSL での定数バッファーの宣言</span><span class="sxs-lookup"><span data-stu-id="125da-129">Direct3D 11: An HLSL constant buffer declaration</span></span>

``` syntax
cbuffer ModelViewProjectionConstantBuffer : register(b0)
{
  matrix mvp;
};
```

<span data-ttu-id="125da-130">ここでは、定数バッファーはレジスタ b0 を使って、パックされたバッファーを保持します。</span><span class="sxs-lookup"><span data-stu-id="125da-130">Here, the constant buffer uses register b0 to hold the packed buffer.</span></span> <span data-ttu-id="125da-131">b\# という形式ですべてのレジスタを参照します。</span><span class="sxs-lookup"><span data-stu-id="125da-131">All registers are referred to in the form b\#.</span></span> <span data-ttu-id="125da-132">HLSL での定数バッファー、レジスタ、データ パッキングの実装について詳しくは、「[シェーダー定数 (HLSL)](https://msdn.microsoft.com/library/windows/desktop/bb509581)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="125da-132">For more information on the HLSL implementation of constant buffers, registers, and data packing, read [Shader Constants (HLSL)](https://msdn.microsoft.com/library/windows/desktop/bb509581).</span></span>

<a name="instructions"></a><span data-ttu-id="125da-133">手順</span><span class="sxs-lookup"><span data-stu-id="125da-133">Instructions</span></span>
------------

### <a name="step-1-port-the-vertex-shader"></a><span data-ttu-id="125da-134">手順 1: 頂点シェーダーの移植</span><span class="sxs-lookup"><span data-stu-id="125da-134">Step 1: Port the vertex shader</span></span>

<span data-ttu-id="125da-135">この簡単な OpenGL ES 2.0 の例では、頂点シェーダーに 3 つの入力があります。1 つの定数のモデル ビュー プロジェクション 4x4 マトリックスと 2 つの 4 座標ベクトルです。</span><span class="sxs-lookup"><span data-stu-id="125da-135">In our simple OpenGL ES 2.0 example, the vertex shader has three inputs: a constant model-view-projection 4x4 matrix, and two 4-coordinate vectors.</span></span> <span data-ttu-id="125da-136">これら 2 つのベクトルには、頂点の位置と色が含まれます。</span><span class="sxs-lookup"><span data-stu-id="125da-136">These two vectors contain the vertex position and its color.</span></span> <span data-ttu-id="125da-137">シェーダーでは、ラスタライズするために、位置ベクトルをパースペクティブ座標に変換し、それを gl\_Position 組み込みメソッドに割り当てます。</span><span class="sxs-lookup"><span data-stu-id="125da-137">The shader transforms the position vector to perspective coordinates and assigns it to the gl\_Position intrinsic for rasterization.</span></span> <span data-ttu-id="125da-138">また、頂点の色は、ラスタライズ時に補間のために varying 変数にコピーされます。</span><span class="sxs-lookup"><span data-stu-id="125da-138">The vertex color is copied to a varying variable for interpolation during rasterization, as well.</span></span>

<span data-ttu-id="125da-139">OpenGL ES 2.0: 立方体オブジェクトの頂点シェーダー (GLSL)</span><span class="sxs-lookup"><span data-stu-id="125da-139">OpenGL ES 2.0: Vertex shader for the cube object (GLSL)</span></span>

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

<span data-ttu-id="125da-140">次に、Direct3D では、レジスタ b0 にパックされた定数バッファーに定数のモデル ビュー プロジェクション マトリックスを格納し、頂点の位置と色をそれぞれ適切な HLSL セマンティクス (POSITION と COLOR) 使って明確にマークします。</span><span class="sxs-lookup"><span data-stu-id="125da-140">Now, in Direct3D, the constant model-view-projection matrix is contained in a constant buffer packed at register b0, and the vertex position and color are specifically marked with the appropriate respective HLSL semantics: POSITION and COLOR.</span></span> <span data-ttu-id="125da-141">入力レイアウトはこれら 2 つの頂点の値の特定の配置を示しているため、それらの値を保持する構造体を作成し、シェーダーの body 関数 (main) でその構造体を入力パラメーターの型として宣言します </span><span class="sxs-lookup"><span data-stu-id="125da-141">Since our input layout indicates a specific arrangement of these two vertex values, you create a struct to hold them and declare it as the type for the input parameter on the shader body function (main).</span></span> <span data-ttu-id="125da-142">(それらの値を 2 つのパラメーターとして指定することもできますが、そうすると扱いにくくなる場合があります)。また、補完された位置と色を格納するこのステージの出力の型を指定し、それを頂点シェーダーの body 関数の戻り値として宣言します。</span><span class="sxs-lookup"><span data-stu-id="125da-142">(You could also specify them as two individual parameters, but that could get cumbersome.) You also specify an output type for this stage, which contains the interpolated position and color, and declare it as the return value for the body function of the vertex shader.</span></span>

<span data-ttu-id="125da-143">Direct3D 11: 立方体オブジェクトの頂点シェーダー (HLSL)</span><span class="sxs-lookup"><span data-stu-id="125da-143">Direct3D 11: Vertex shader for the cube object (HLSL)</span></span>

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

<span data-ttu-id="125da-144">出力のデータ型 PixelShaderInput は、ラスタライズ時に設定され、フラグメント (ピクセル) シェーダーに渡されます。</span><span class="sxs-lookup"><span data-stu-id="125da-144">The output data type, PixelShaderInput, is populated during rasterization and provided to the fragment (pixel) shader.</span></span>

### <a name="step-2-port-the-fragment-shader"></a><span data-ttu-id="125da-145">手順 2: フラグメント シェーダーの移植</span><span class="sxs-lookup"><span data-stu-id="125da-145">Step 2: Port the fragment shader</span></span>

<span data-ttu-id="125da-146">GLSL のフラグメント シェーダーの例は非常に簡単です。補完された色値を gl\_FragColor 組み込みメソッドに渡します。</span><span class="sxs-lookup"><span data-stu-id="125da-146">Our example fragment shader in GLSL is extremely simple: provide the gl\_FragColor intrinsic with the interpolated color value.</span></span> <span data-ttu-id="125da-147">OpenGL ES 2.0 では、それを既定のレンダー ターゲットに書き込みます。</span><span class="sxs-lookup"><span data-stu-id="125da-147">OpenGL ES 2.0 will write it to the default render target.</span></span>

<span data-ttu-id="125da-148">OpenGL ES 2.0: 立方体オブジェクトのフラグメント シェーダー (GLSL)</span><span class="sxs-lookup"><span data-stu-id="125da-148">OpenGL ES 2.0: Fragment shader for the cube object (GLSL)</span></span>

``` syntax
varying vec4 destColor;

void main()
{
  gl_FragColor = destColor;
} 
```

<span data-ttu-id="125da-149">Direct3D も同じくらい簡単です。</span><span class="sxs-lookup"><span data-stu-id="125da-149">Direct3D is almost as simple.</span></span> <span data-ttu-id="125da-150">大きな違いは、ピクセル シェーダーの body 関数で値を返す必要があることだけです。</span><span class="sxs-lookup"><span data-stu-id="125da-150">The only significant difference is that the body function of the pixel shader must return a value.</span></span> <span data-ttu-id="125da-151">色が 4 座標 (RGBA) の浮動小数点値であるため、戻り値の型として float4 を指定し、SV\_TARGET システム値セマンティクスとして既定のレンダー ターゲットを指定します。</span><span class="sxs-lookup"><span data-stu-id="125da-151">Since the color is a 4-coordinate (RGBA) float value, you indicate float4 as the return type, and then specify the default render target as the SV\_TARGET system value semantic.</span></span>

<span data-ttu-id="125da-152">Direct3D 11: 立方体オブジェクトのピクセル シェーダー (HLSL)</span><span class="sxs-lookup"><span data-stu-id="125da-152">Direct3D 11: Pixel shader for the cube object (HLSL)</span></span>

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

<span data-ttu-id="125da-153">位置のピクセルの色はレンダー ターゲットに書き込まれます。</span><span class="sxs-lookup"><span data-stu-id="125da-153">The color for the pixel at the position is written to the render target.</span></span> <span data-ttu-id="125da-154">次に、「[画面への描画](draw-to-the-screen.md)」でそのレンダー ターゲットのコンテンツを表示する方法を見ていきます。</span><span class="sxs-lookup"><span data-stu-id="125da-154">Now, let's see how to display the contents of that render target in [Draw to the screen](draw-to-the-screen.md)!</span></span>

## <a name="previous-step"></a><span data-ttu-id="125da-155">前の手順</span><span class="sxs-lookup"><span data-stu-id="125da-155">Previous step</span></span>


<span data-ttu-id="125da-156">[頂点バッファーと頂点データの移植](port-the-vertex-buffers-and-data-config.md) 次の手順</span><span class="sxs-lookup"><span data-stu-id="125da-156">[Port the vertex buffers and data](port-the-vertex-buffers-and-data-config.md) Next step</span></span>
---------

<span data-ttu-id="125da-157">[画面への描画](draw-to-the-screen.md) 解説</span><span class="sxs-lookup"><span data-stu-id="125da-157">[Draw to the screen](draw-to-the-screen.md) Remarks</span></span>
-------

<span data-ttu-id="125da-158">HLSL セマンティクスと定数バッファーのパッキングについて理解すると、デバッグの苦労がいくらか少なくなるだけでなく、最適化できるようにもなります。</span><span class="sxs-lookup"><span data-stu-id="125da-158">Understanding HLSL semantics and the packing of constant buffers can save you a bit of a debugging headache, as well as provide optimization opportunities.</span></span> <span data-ttu-id="125da-159">機会があれば、「[変数の構文 (HLSL)](https://msdn.microsoft.com/library/windows/desktop/bb509706)」、「[Direct3D 11 のバッファーについて](https://msdn.microsoft.com/library/windows/desktop/ff476898)」、「[定数バッファーを作成する方法](https://msdn.microsoft.com/library/windows/desktop/ff476896)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="125da-159">If you get a chance, read through [Variable Syntax (HLSL)](https://msdn.microsoft.com/library/windows/desktop/bb509706), [Introduction to Buffers in Direct3D 11](https://msdn.microsoft.com/library/windows/desktop/ff476898), and [How to: Create a Constant Buffer](https://msdn.microsoft.com/library/windows/desktop/ff476896).</span></span> <span data-ttu-id="125da-160">機会がない場合は、次のセマンティクスと定数バッファーについての基本的なヒントを心に留めておいてください。</span><span class="sxs-lookup"><span data-stu-id="125da-160">If not, though, here's a few starting tips to keep in mind about semantics and constant buffers:</span></span>

-   <span data-ttu-id="125da-161">必ずレンダラーの Direct3D 構成コードを見直して、定数バッファーの構造体が HLSL の cbuffer 構造体の宣言と一致し、コンポーネントのスカラー型が両方の宣言で一致していることを確認する。</span><span class="sxs-lookup"><span data-stu-id="125da-161">Always double check your renderer's Direct3D configuration code to make sure that the structures for your constant buffers match the cbuffer struct declarations in your HLSL, and that the component scalar types match across both declarations.</span></span>
-   <span data-ttu-id="125da-162">レンダラーの C++ コードでは、データ パッキングが適切に行われるように、定数バッファーの宣言で [DirectXMath](https://msdn.microsoft.com/library/windows/desktop/hh437833) 型を使う。</span><span class="sxs-lookup"><span data-stu-id="125da-162">In your renderer's C++ code, use [DirectXMath](https://msdn.microsoft.com/library/windows/desktop/hh437833) types in your constant buffer declarations to ensure proper data packing.</span></span>
-   <span data-ttu-id="125da-163">定数バッファーを効率的に使う最良の方法として、更新頻度に応じてシェーダーの変数を定数バッファーにまとめる。</span><span class="sxs-lookup"><span data-stu-id="125da-163">The best way to efficiently use constant buffers is to organize shader variables into constant buffers based on their frequency of update.</span></span> <span data-ttu-id="125da-164">たとえば、フレームごとに 1 回更新される uniform データと、カメラが移動したときにだけ更新される uniform データがある場合は、それらのデータを 2 つの定数バッファーに分けることを考えます。</span><span class="sxs-lookup"><span data-stu-id="125da-164">For example, if you have some uniform data that is updated once per frame, and other uniform data that is updated only when the camera moves, consider separating that data into two separate constant buffers.</span></span>
-   <span data-ttu-id="125da-165">セマンティクスの適用し忘れや誤った適用は、シェーダー コンパイル (FXC) エラーのよくある原因である。</span><span class="sxs-lookup"><span data-stu-id="125da-165">Semantics that you have forgotten to apply or which you have applied incorrectly will be your earliest source of shader compilation (FXC) errors.</span></span> <span data-ttu-id="125da-166">よく見直してください。</span><span class="sxs-lookup"><span data-stu-id="125da-166">Double-check them!</span></span> <span data-ttu-id="125da-167">以前のページやサンプルの多くでは Direct3D 11 より前のさまざまなバージョンの HLSL セマンティクスを参照しているため、ドキュメントが混乱を招くことがあります。</span><span class="sxs-lookup"><span data-stu-id="125da-167">The docs can be a bit confusing, as many older pages and samples refer to different versions of HLSL semantics prior to Direct3D 11.</span></span>
-   <span data-ttu-id="125da-168">各シェーダーのターゲットとする Direct3D 機能レベルを確認する。</span><span class="sxs-lookup"><span data-stu-id="125da-168">Make sure you know which Direct3D feature level you are targeting for each shader.</span></span> <span data-ttu-id="125da-169">機能レベル 9\_\* のセマンティクスは 11\_1 のセマンティクスと異なります。</span><span class="sxs-lookup"><span data-stu-id="125da-169">The semantics for feature level 9\_\* are different from those for 11\_1.</span></span>
-   <span data-ttu-id="125da-170">SV\_POSITION セマンティクスは関連する補間後の位置データを座標値に解決します。x は 0 からレンダー ターゲットの幅までの値に、y は 0 からレンダー ターゲットの高さまでの値になり、z は元の同次座標 w の値で割られ (z/w)、w は 1 を元の w の値で割った値 (1/w) になります。</span><span class="sxs-lookup"><span data-stu-id="125da-170">The SV\_POSITION semantic resolves the associated post-interpolation position data to coordinate values where x is between 0 and the render target width, y is between 0 and the render target height, z is divided by the original homogeneous coordinate w value (z/w), and w is 1 divided by the original w value (1/w).</span></span>

## <a name="related-topics"></a><span data-ttu-id="125da-171">関連トピック</span><span class="sxs-lookup"><span data-stu-id="125da-171">Related topics</span></span>


[<span data-ttu-id="125da-172">簡単な OpenGL ES 2.0 レンダラーを Direct3D 11 に移植する方法</span><span class="sxs-lookup"><span data-stu-id="125da-172">How to: port a simple OpenGL ES 2.0 renderer to Direct3D 11</span></span>](port-a-simple-opengl-es-2-0-renderer-to-directx-11-1.md)

[<span data-ttu-id="125da-173">シェーダー オブジェクトの移植</span><span class="sxs-lookup"><span data-stu-id="125da-173">Port the shader objects</span></span>](port-the-shader-config.md)

[<span data-ttu-id="125da-174">頂点バッファーと頂点データの移植</span><span class="sxs-lookup"><span data-stu-id="125da-174">Port the vertex buffers and data</span></span>](port-the-vertex-buffers-and-data-config.md)

[<span data-ttu-id="125da-175">画面への描画</span><span class="sxs-lookup"><span data-stu-id="125da-175">Draw to the screen</span></span>](draw-to-the-screen.md)

 

 




