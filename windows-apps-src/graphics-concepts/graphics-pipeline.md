---
title: "グラフィックス パイプライン"
description: "Direct3D グラフィックス パイプラインは、リアルタイム ゲーム アプリケーション用のグラフィックスを生成できるように設計されています。 データは、構成可能またはプログラミング可能な各ステージを通じて、入力から出力へと流れます。"
ms.assetid: C9519AD0-5425-48BD-9FF4-AED8959CA4AD
keywords:
- "グラフィックス パイプライン"
- "パイプラインのステージ"
author: PeterTurcan
ms.author: pettur
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
translationtype: Human Translation
ms.sourcegitcommit: c6b64cff1bbebc8ba69bc6e03d34b69f85e798fc
ms.openlocfilehash: 72e4985481f464cd45c13fd390d27c4ba0e7c618
ms.lasthandoff: 02/07/2017

---

# <a name="graphics-pipeline"></a>グラフィックス パイプライン


Direct3D グラフィックス パイプラインは、リアルタイム ゲーム アプリケーション用のグラフィックスを生成できるように設計されています。 データは、構成可能またはプログラミング可能な各ステージを通じて、入力から出力へと流れます。

すべてのステージは、Direct3D API を使用して構成できます。 一般的なシェーダー コア (角丸四角形のブロック) の機能を利用するステージは、[HLSL](https://msdn.microsoft.com/library/windows/desktop/bb509561) プログラミング言語を使用することによってプログラミングできます。 これにより、パイプラインは柔軟性および適応性が非常に高くなっています。

最もよく使用されるのは、頂点シェーダー (VS) ステージとピクセル シェーダー (PS) ステージです。 これらのシェーダー ステージを用意しない場合は、既定の何もしない、パススルー頂点シェーダーとピクセル シェーダーが使われます。

![Direct3D 11 のプログラム可能なパイプラインでのデータ フローの図](images/d3d11-pipeline-stages.jpg)

## <a name="input-assembler-stage"></a>入力アセンブラー ステージ

 

| | |
|-|-|
|目的|[入力アセンブラー (IA) ステージ](input-assembler-stage--ia-.md)は、三角形、線、点などのパイプラインにプリミティブ データと隣接性データを提供し (セマンティクス ID など)、まだ処理されていないプリミティブの処理を減らすことでシェーダーの効率を高めます。|
|入力|メモリ内のユーザーが入力したバッファーからのプリミティブ データ (三角形、線、点)。 隣接性データが含まれる場合もあります。 三角形では、三角形ごとに 3 つの頂点と、場合によって三角形ごとに隣接性データの 3 つの頂点になります。|
|出力|システム生成値 (プリミティブ ID、インスタンス ID、頂点 ID など) が添付されたプリミティブ。|
| | |

<!---
<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<tbody>
<tr class="odd">
<td align="left">Purpose</td>
<td align="left">The [Input Assembler (IA) stage](input-assembler-stage--ia-.md) supplies primitive and adjacency data to the pipeline, such as triangles, lines and points, including semantics IDs to help make shaders more efficient by reducing processing to primitives that haven't already been processed.</td>
</tr>
<tr class="even">
<td align="left">Input</td>
<td align="left"> Primitive data (triangles, lines, and/or points), from user-filled buffers in memory. And possibly adjacency data. A triangle would be 3 vertices for each triangle and possibly 3 vertices for adjacency data per triangle.  </td>
</tr>
<tr class="odd">
<td align="left">Output</td>
<td align="left">Primitives with attached system-generated values (such as a primitive ID, an instance ID, or a vertex ID). </td>
</tr>
</tbody>
</table>
 -->



## <a name="vertex-shader-stage"></a>頂点シェーダー ステージ
 

| | |
|-|-|
|目的|[頂点シェーダー (VS) ステージ](vertex-shader-stage--vs-.md)では、頂点を処理し、多くの場合は変換、スキン、照明の適用などの操作を実行します。 頂点シェーダーは 1 つの入力頂点を受け取り、1 つの出力頂点を生成します。 変換、スキン適用、変形、頂点ごとの照明など、頂点ごとの個別の操作です。|
|入力|1 つの頂点と、システム生成値である VertexID および InstanceID。 頂点シェーダーの各入力頂点は、最大 16 個の 32 ビット ベクトル (それぞれ最大 4 要素) で構成できます。|
|出力|1 つの頂点。 各出力頂点は、最大 16 個の 32 ビット 4 要素ベクトルで構成できます。|
| | |

<!---
<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<tbody>
<tr class="odd">
<td align="left">Purpose</td>
<td align="left">The [Vertex Shader (VS) stage](vertex-shader-stage--vs-.md) processes vertices, typically performing operations such as transformations, skinning, and lighting. A vertex shader takes a single input vertex and produces a single output vertex. Individual per-vertex operations, such as:
<ul>
<li>Transformations</li>
<li>Skinning</li>
<li>Morphing</li>
<li>Per-vertex lighting</li>
</ul></td>
</tr>
<tr class="even">
<td align="left">Input</td>
<td align="left">A single vertex, with VertexID and InstanceID system-generated values. Each vertex shader input vertex can be comprised of up to 16 32-bit vectors (up to 4 components each).</td>
</tr>
<tr class="odd">
<td align="left">Output</td>
<td align="left">A single vertex. Each output vertex can be comprised of as many as 16 32-bit 4-component vectors.</td>
</tr>
</tbody>
</table>
-->
 

## <a name="hull-shader-stage"></a>ハル シェーダー ステージ
 

| | |
|-|-|
|目的|[ハル シェーダー (HS) ステージ](hull-shader-stage--hs-.md)は、モデルの 1 つのサーフェスを効率的に多数の三角形に分割する、テセレーション ステージの 1 つです。 ハル シェーダーは、パッチごとに 1 回呼び出され、低次サーフェスを定義する入力制御点を、パッチを構成する制御点に変換します。 また、ハル シェーダーは、いくつかのパッチごとの計算を行い、データをテッセレータ (TS) ステージとドメイン シェーダー (DS) ステージに提供します。|
|入力|1 ～ 32 個の入力制御点。これらがまとまって低次サーフェスを定義します。|
|出力|1 ～ 32 個の出力制御点。これらがまとまってパッチを構成します。 ハル シェーダーは、テッセレータ (TS) ステージの状態を宣言します。これには、テセレーションで使用する制御点の数、パッチ面の種類、分割の種類が含まれます。|
| | |

<!---
<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<tbody>
<tr class="odd">
<td align="left">Purpose</td>
<td align="left">The [Hull Shader (HS) stage](hull-shader-stage--hs-.md) is one of the tessellation stages, which efficiently break up a single surface of a model into many triangles. A hull shader is invoked once per patch, and it transforms input control points that define a low-order surface into control points that make up a patch. It also does some per-patch calculations to provide data for the Tessellator (TS) stage and the Domain Shader (DS) stage.</td>
</tr>
<tr class="even">
<td align="left">Input</td>
<td align="left">Between 1 and 32 input control points, which together define a low-order surface. </td>
</tr>
<tr class="odd">
<td align="left">Output</td>
<td align="left">Between 1 and 32 output control points, which together make up a patch. The hull shader declares the state for the Tessellator (TS) stage, including the number of control points, the type of patch face, and the type of partitioning to use when tessellating. </td>
</tr>
</tbody>
</table>
-->

## <a name="tessellator-stage"></a>テッセレータ ステージ
 

| | |
|-|-|
|目的|[テッセレータ (TS) ステージ](tessellator-stage--ts-.md)は、ジオメトリ パッチを表すドメインのサンプリング パターンを作成し、サンプルを接続する一連の小さいオブジェクト (三角形、点、または線) を生成します。|
|入力|テッセレータは、ハル シェーダー ステージから渡されるテッセレーション係数 (ドメインをどの程度詳細にテッセレーションするかを指定する) およびパーティションの種類 (パッチのスライスに使用するアルゴリズムを指定する) を使用して、パッチごとに 1 回動作します。 |
|出力|テッセレータは、uv (およびオプションとして w) 座標およびサーフェス トポロジをドメイン シェーダー ステージに出力します。|
| | |

<!---
<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<tbody>
<tr class="odd">
<td align="left">Purpose</td>
<td align="left">The [Tessellator (TS) stage](tessellator-stage--ts-.md) creates a sampling pattern of the domain that represents the geometry patch and generates a set of smaller objects (triangles, points, or lines) that connect these samples.   </td>
</tr>
<tr class="even">
<td align="left">Input</td>
<td align="left"> The tessellator operates once per patch using the tessellation factors (which specify how finely the domain will be tessellated) and the type of partitioning (which specifies the algorithm used to slice up a patch) that are passed in from the hull-shader stage. </td>
</tr>
<tr class="odd">
<td align="left">Output</td>
<td align="left">The tessellator outputs uv (and optionally w) coordinates and the surface topology to the domain-shader stage.     </td>
</tr>
</tbody>
</table>
 -->

## <a name="domain-shader-stage"></a>ドメイン シェーダー ステージ
 

| | |
|-|-|
|目的|[ドメイン シェーダー (DS) ステージ](domain-shader-stage--ds-.md)では、パッチ内の細分化されたポイントの頂点の位置を計算します。つまり、各ドメイン サンプルに対応する頂点の位置を計算します。 ドメイン シェーダーは、テッセレータ ステージの出力ポイントごとに 1 回実行され、ハル シェーダーの出力パッチや出力パッチ定数、およびテッセレータ ステージの出力 UV 座標への読み取り専用アクセスが可能です。|
|入力|ドメイン シェーダーは、[ハル シェーダー (HS) ステージ](hull-shader-stage--hs-.md)からの出力の制御点を利用します。 ハル シェーダーの出力: 制御点、パッチ定数データ、テセレーション係数 (テセレーション係数には、固定関数テッセレータによって使用される値と、整数テセレーションによる丸め前の未処理の値を含めることができ、ジオモーフィングなどが容易になります)。 ドメイン シェーダーは、[テッセレータ (TS) ステージ](tessellator-stage--ts-.md)からの出力座標ごとに 1 回呼び出されます。|
|出力|ドメイン シェーダー (DS) ステージでは、出力パッチ内の細分化されたポイントの頂点の位置を出力します。|
| | |

<!---
<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<tbody>
<tr class="odd">
<td align="left">Purpose</td>
<td align="left">The [Domain Shader (DS) stage](domain-shader-stage--ds-.md) calculates the vertex position of a subdivided point in the output patch; it calculates the vertex position that corresponds to each domain sample. A domain shader is run once per tessellator stage output point and has read-only access to the hull shader output patch and output patch constants, and the tessellator stage output UV coordinates.</td>
</tr>
<tr class="even">
<td align="left">Input</td>
<td align="left"><ul>
<li>A domain shader consumes output control points from the [Hull Shader (HS) stage](hull-shader-stage--hs-.md). The hull shader outputs include:
<ul>
<li>Control points.</li>
<li>Patch constant data.</li>
<li>Tessellation factors. The tessellation factors can include the values used by the fixed-function tessellator as well as the raw values (before rounding by integer tessellation, for example), which facilitates geomorphing, for example.</li>
</ul></li>
<li>A domain shader is invoked once per output coordinate from the [Tessellator (TS) stage](tessellator-stage--ts-.md).</li>
</ul></td>
</tr>
<tr class="odd">
<td align="left">Output</td>
<td align="left">The Domain Shader (DS) stage outputs the vertex position of a subdivided point in the output patch.</td>
</tr>
</tbody>
</table>
-->
 

## <a name="geometry-shader-stage"></a>ジオメトリ シェーダー ステージ
 

| | |
|-|-|
|目的|[ジオメトリ シェーダー (GS) ステージ](geometry-shader-stage--gs-.md)では、プリミティブの全体の三角形、線、点が、隣接する頂点と共に処理されます。 これは、ジオメトリ増幅と減幅をサポートします。 ジオメトリ シェーダー ステージは、ポイント スプライト拡張、動的パーティクル システム、Fur/Fin の生成、シャドウ ボリュームの生成、単一パスでのキューブマップへのレンダリング、プリミティブ単位のマテリアル スワッピング、プリミティブ単位のマテリアル セットアップ (プリミティブ データとしての重心座標の生成も含まれています。これにより、ピクセル シェーダーはカスタム属性補間を実行できます) などのアルゴリズムに適しています。 |
|入力|1 つの頂点を処理する頂点シェーダーとは異なり、ジオメトリ シェーダーの入力はプリミティブ全体 (三角形の 3 つの頂点、線の 2 つの頂点、点の 1 つの頂点など) の頂点です。|
|出力|ジオメトリ シェーダー (GS) ステージでは、1 つの選択したトポロジを形成する複数の頂点を出力することができます。 利用可能なジオメトリ シェーダーの出力トポロジには、<strong>tristrip</strong>、<strong>linestrip</strong>、および<strong>pointlist</strong> があります。 生成されるプリミティブの数は、ジオメトリ シェーダーの呼び出し内で自由に変えることができますが、生成可能な頂点の最大数は、静的に宣言する必要があります。 ジオメトリ シェーダーの呼び出しから生成されるストリップの長さは任意で、新しいストリップは [RestartStrip](https://msdn.microsoft.com/library/windows/desktop/bb509660) HLSL 組み込み関数を使用して作成できます。|
| | |

<!---
<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<tbody>
<tr class="odd">
<td align="left">Purpose</td>
<td align="left">The [Geometry Shader (GS) stage](geometry-shader-stage--gs-.md) processes entire primitives: triangles, lines, and points, along with their adjacent vertices. It is useful for algorithms including Point Sprite Expansion, Dynamic Particle Systems, and Shadow Volume Generation. It supports geometry amplification and de-amplification.
<ul>
<li>Point Sprite Expansion</li>
<li>Dynamic Particle Systems</li>
<li>Fur/Fin Generation</li>
<li>Shadow Volume Generation</li>
<li>Single Pass Render-to-Cubemap</li>
<li>Per-Primitive Material Swapping</li>
<li>Per-Primitive Material Setup, including generation of barycentric coordinates as primitive data so that a pixel shader can perform custom attribute interpolation.</li>
</ul></td>
</tr>
<tr class="even">
<td align="left">Input</td>
<td align="left">Unlike vertex shaders, which operate on a single vertex, the geometry shader's inputs are the vertices for a full primitive (three vertices for triangles, two vertices for lines, or single vertex for point).</td>
</tr>
<tr class="odd">
<td align="left">Output</td>
<td align="left">The Geometry Shader (GS) stage is capable of outputting multiple vertices forming a single selected topology. Available geometry shader output topologies are <strong>tristrip</strong>, <strong>linestrip</strong>, and <strong>pointlist</strong>. The number of primitives emitted can vary freely within any invocation of the geometry shader, though the maximum number of vertices that could be emitted must be declared statically. Strip lengths emitted from a geometry shader invocation can be arbitrary, and new strips can be created via the [RestartStrip](https://msdn.microsoft.com/library/windows/desktop/bb509660) HLSL function.</td>
</tr>
</tbody>
</table>
-->
 

## <a name="stream-output-stage"></a>ストリーム出力ステージ
 

| | |
|-|-|
|目的|[ストリーム出力 (SO) ステージ](stream-output-stage--so-.md)では、直前のアクティブなステージからメモリ内の 1 つ以上のバッファーに、頂点データを連続して出力 (ストリーミング) します。 メモリにストリーミングされたデータは、CPU からの入力データまたはリード バックとして、パイプラインに再循環させることができます。|
|入力|前のパイプライン ステージの頂点データです。|
|出力|ストリーム出力 (SO) ステージでは、ジオメトリ シェーダー (GS) ステージなど、直前のアクティブなステージからメモリ内の 1 つ以上のバッファーに、頂点データを連続して出力 (ストリーミング) します。 ジオメトリ シェーダー (GS) ステージがアクティブではなく、ストリーム出力 (SO) ステージがアクティブである場合、ストリーム出力ステージでは、ドメイン シェーダー (DS) ステージから (DS もアクティブでない場合は、頂点シェーダー (VS) ステージから) メモリ内のバッファーに頂点データを継続して出力します。|
| | |

<!---
<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<tbody>
<tr class="odd">
<td align="left">Purpose</td>
<td align="left">The [Stream Output (SO) stage](stream-output-stage--so-.md) continuously outputs (or streams) vertex data from the previous active stage to one or more buffers in memory. Data streamed out to memory can be recirculated back into the pipeline as input data, or read-back from the CPU.</td>
</tr>
<tr class="even">
<td align="left">Input</td>
<td align="left">Vertex data from a previous pipeline stage.   </td>
</tr>
<tr class="odd">
<td align="left">Output</td>
<td align="left">The Stream Output (SO) stage continuously outputs (or streams) vertex data from the previous active stage, such as the Geometry Shader (GS) stage, to one or more buffers in memory. If the Geometry Shader (GS) stage is inactive, and the Stream Output (SO) stage is active, it continuously outputs vertex data from the Domain Shader (DS) stage to buffers in memory (or if the DS is also inactive, from the Vertex Shader (VS) stage).</td>
</tr>
</tbody>
</table>
-->

## <a name="rasterizer-stage"></a>ラスタライザー ステージ
 

| | |
|-|-|
|目的|[ラスタライザー (RS) ステージ](rasterizer-stage--rs-.md)は、表示されないプリミティブをトリミングし、ピクセル シェーダー (PS) ステージ用にプリミティブを準備して、ピクセル シェーダーを呼び出す方法を決定します。 リアルタイム 3D グラフィックスを表示するために、(図形やプリミティブで構成された) ベクター情報を (ピクセルで構成された) ラスター画像に変換します。|
|入力|ラスタライザー ステージに渡される頂点 (x、y、z、w) は同次クリップ空間と見なされます。 この座標空間では、X 軸は右向き、Y 軸は上向き、Z 軸はカメラから遠ざかる方向を向きます。|
|出力|レンダリングする必要がある実際のピクセル。 ピクセル シェーダーによる補間で使用するためのいくつかの頂点属性が含まれています。|
| | |

<!---
<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<tbody>
<tr class="odd">
<td align="left">Purpose</td>
<td align="left">The [Rasterizer (RS) stage](rasterizer-stage--rs-.md) clips primitives that aren't in view, prepares primitives for the Pixel Shader (PS) stage, and determines how to invoke pixel shaders. Converts vector information (composed of shapes or primitives) into a raster image (composed of pixels) for the purpose of displaying real-time 3D graphics.</td>
</tr>
<tr class="even">
<td align="left">Input</td>
<td align="left">Vertices (x,y,z,w) coming into the Rasterizer stage are assumed to be in homogeneous clip-space. In this coordinate space the X axis points right, Y points up and Z points away from camera.</td>
</tr>
<tr class="odd">
<td align="left">Output</td>
<td align="left">The actual pixels that need to be rendered. Includes some vertex attributes for use in interpolation by the pixel Shader.</td>
</tr>
</tbody>
</table>
 -->

## <a name="pixel-shader-stage"></a>ピクセル シェーダー ステージ
 

| | |
|-|-|
|目的|[ピクセル シェーダー (PS) ステージ](pixel-shader-stage--ps-.md)はプリミティブの補間データを受信し、カラーなどのピクセル単位のデータを生成します。|
|入力|パイプラインがジオメトリ シェーダーなしに構成されている場合、ピクセル シェーダーは 16 個の 32 ビット、4 成分の入力に制限されます。 それ以外の場合、ピクセル シェーダーは 32 ビット、4 成分の入力を 32 個まで受け取ることができます。 ピクセル シェーダーの入力データには (パースペクティブ補正あり/なしで補間可能な) 頂点属性が含まれます。または、ピクセル シェーダーの入力データをプリミティブ単位の定数として処理することもできます。 ピクセル シェーダー入力は、宣言された補間モードに基づき、ラスター化されているプリミティブの頂点属性から補間されます。 プリミティブがラスター化前にクリップされた場合は、クリッピング処理中に補間モードが受け入れられます。 |
|出力|ピクセル シェーダーは、32 ビット、4 成分の色を 8 つまで出力できます。ピクセルが破棄された場合は色を出力することはできません。 ピクセル シェーダーの出力レジスタの成分は、使用前に宣言する必要があります。レジスタごとに異なる出力書き込みマスクを使用できます。|
| | |

<!---
<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<tbody>
<tr class="odd">
<td align="left">Purpose</td>
<td align="left">The [Pixel Shader (PS) stage](pixel-shader-stage--ps-.md) receives interpolated data for a primitive and generates per-pixel data such as color.</td>
</tr>
<tr class="even">
<td align="left">Input</td>
<td align="left"><p>When the pipeline is configured without a geometry shader, a pixel shader is limited to 16, 32-bit, 4-component inputs. Otherwise, a pixel shader can take up to 32, 32-bit, 4-component inputs.</p>
<p>Pixel shader input data includes vertex attributes (that can be interpolated with or without perspective correction) or can be treated as per-primitive constants. Pixel shader inputs are interpolated from the vertex attributes of the primitive being rasterized, based on the interpolation mode declared. If a primitive gets clipped before rasterization, the interpolation mode is honored during the clipping process as well.</p></td>
</tr>
<tr class="odd">
<td align="left">Output</td>
<td align="left"><p>A pixel shader can output up to 8, 32-bit, 4-component colors, or no color if the pixel is discarded. Pixel shader output register components must be declared before they can be used; each register is allowed a distinct output-write mask.</p></td>
</tr>
</tbody>
</table>
-->
 

## <a name="output-merger-stage"></a>出力マージャー ステージ
 

| | |
|-|-|
|目的|[出力マージャー (OM) ステージ](output-merger-stage--om-.md)では、各種出力データ (ピクセル シェーダー値、深度とステンシルの情報) をレンダー ターゲットおよび深度/ステンシル バッファーの内容と結合し、最終的なパイプラインの結果を生成します。|
|入力|出力マージャー入力は、パイプラインの状態、ピクセル シェーダーによって生成されたピクセル データ、レンダー ターゲットの内容、深度/ステンシル バッファーの内容です。|
|出力|最終的にレンダリングされるピクセルの色。|
| | |


<!---
<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<tbody>
<tr class="odd">
<td align="left">Purpose</td>
<td align="left">The [Output Merger (OM) stage](output-merger-stage--om-.md) combines various types of output data (pixel shader values, depth and stencil information) with the contents of the render target and depth/stencil buffers to generate the final pipeline result.</td>
</tr>
<tr class="even">
<td align="left">Input</td>
<td align="left"><ul>
<li>Pipeline state</li>
<li>The pixel data generated by the pixel shaders</li>
<li>The contents of the render targets</li>
<li>The contents of the depth/stencil buffers.</li>
</ul></td>
</tr>
<tr class="odd">
<td align="left">Output</td>
<td align="left">The final rendered pixel color.</td>
</tr>
</tbody>
</table>


| | |
|-|-|
|Purpose|xxxx|
|Input|yyyy|
|Output|zzzz|
| | |
-->

## <a name="related-topics"></a>関連トピック


[Direct3D Graphics の学習ガイド](index.md)

[計算パイプライン](compute-pipeline.md)

 

 

