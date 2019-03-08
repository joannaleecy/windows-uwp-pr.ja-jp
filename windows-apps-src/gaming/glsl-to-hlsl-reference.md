---
title: GLSL と HLSL の対応を示すリファレンス
description: グラフィックス アーキテクチャを OpenGL ES 2.0 から Direct3D 11 に移植してユニバーサル Windows プラットフォーム (UWP) 向けのゲームを作成する際は、OpenGL シェーダー言語 (GLSL) コードを Microsoft 上位レベル シェーダー言語 (HLSL) コードに移植します。
ms.assetid: 979d19f6-ef0c-64e4-89c2-a31e1c7b7692
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, GLSL, HLSL, OpenGL, DirectX, シェーダー
ms.localizationpriority: medium
ms.openlocfilehash: 8f468584d995de40ff14df1527ab1df8275c36a8
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57611167"
---
# <a name="glsl-to-hlsl-reference"></a>GLSL と HLSL の対応を示すリファレンス



[グラフィックス アーキテクチャを OpenGL ES 2.0 から Direct3D 11 に移植して](port-from-opengl-es-2-0-to-directx-11-1.md)ユニバーサル Windows プラットフォーム (UWP) 向けのゲームを作成する際は、OpenGL シェーダー言語 (GLSL) コードを Microsoft 上位レベル シェーダー言語 (HLSL) コードに移植します。 ここで参照される GLSL は OpenGL ES 2.0 とは互換性がありません。HLSL は Direct3D 11 と互換性があります。 Direct3D 11 と以前のバージョンの Direct3D の違いについては、「[機能のマッピング](feature-mapping.md)」をご覧ください。

-   [OpenGL ES 2.0 Direct3D とを比較する 11](#comparing-opengl-es-20-with-direct3d-11)
-   [GLSL HLSL 変数の移植](#porting-glsl-variables-to-hlsl)
-   [GLSL HLSL の種類の移植](#porting-glsl-types-to-hlsl)
-   [HLSL のグローバル変数を事前に定義された GLSL の移植](#porting-glsl-pre-defined-global-variables-to-hlsl)
-   [GLSL HLSL 変数への移植の例](#examples-of-porting-glsl-variables-to-hlsl)
    -   [統一された、属性、および GLSL のさまざまな](#uniform-attribute-and-varying-in-glsl)
    -   [HLSL の定数バッファーとデータの転送](#constant-buffers-and-data-transfers-in-hlsl)
-   [Direct3D に OpenGL レンダリング コードの移植の例](#examples-of-porting-opengl-rendering-code-to-direct3d)
-   [関連トピック](#related-topics)

## <a name="comparing-opengl-es-20-with-direct3d-11"></a>OpenGL ES 2.0 と Direct3D 11 の比較


OpenGL ES 2.0 と Direct3D 11 には多くの類似点があります。 どちらも、類似したレンダリング パイプラインとグラフィックス機能があります。 ただし、Direct3D 11 はレンダリングの実装と API であり、仕様ではありません。OpenGL ES 2.0 はレンダリングの仕様と API であり、実装ではありません。 Direct3D 11 と OpenGL ES 2.0 は通常、次の点で異なります。

| OpenGL ES 2.0                                                                                         | Direct3D 11                                                                                                            |
|-------------------------------------------------------------------------------------------------------|------------------------------------------------------------------------------------------------------------------------|
| ハードウェアやオペレーティング システムにとらわれない仕様とベンダーが提供する実装             | Windows プラットフォームのハードウェア アブストラクションと認定の Microsoft 実装                                |
| 多様なハードウェア向けに抽象化、ランタイムがほとんどのリソースを管理                                     | ハードウェアのレイアウトに直接アクセス。アプリがリソースと処理を管理できる                                              |
| サード パーティのライブラリ (たとえば、Simple DirectMedia Layer (SDL)) によって高レベルのモジュールを提供 | Direct2D などの高レベルのモジュールは下位モジュールに基づいて構築されるため、Windows アプリの開発が簡略化             |
| ハードウェア ベンダーは拡張子によって区別                                                         | Microsoft は、汎用的な方法で API にオプション機能を追加するため、特定のハードウェア ベンダーに限定されない |

 

GLSL と HLSL は一般に次の点で異なります。

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">GLSL</th>
<th align="left">HLSL</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left">手続き型、ステップ中心 (C など)</td>
<td align="left">オブジェクト指向、データ中心 (C++ など)</td>
</tr>
<tr class="even">
<td align="left">グラフィックス API に統合されたシェーダー コンパイル</td>
<td align="left">HLSL コンパイラが中間バイナリ表現に<a href="https://msdn.microsoft.com/library/windows/desktop/bb509633">シェーダーをコンパイルし</a>、その後で Direct3D がそれをドライバーに渡します。
<div class="alert">
<strong>注</strong>  このバイナリ表現はハードウェアに依存しません。 通常はアプリの実行時ではなくアプリのビルド時にコンパイルされます。
</div>
<div>
 
</div></td>
</tr>
<tr class="odd">
<td align="left"><a href="#porting-glsl-variables-to-hlsl">変数</a>ストレージ修飾子</td>
<td align="left">入力レイアウトの宣言による定数バッファーとデータ転送</td>
</tr>
<tr class="even">
<td align="left"><p><a href="#porting-glsl-types-to-hlsl">型</a></p>
<p>一般的なベクター型: vec2/3/4</p>
<p>lowp、mediump、highp</p></td>
<td align="left"><p>一般的なベクター型: float2/3/4</p>
<p>min10float、min16float</p></td>
</tr>
<tr class="odd">
<td align="left">texture2D [Function]</td>
<td align="left"><a href="https://msdn.microsoft.com/library/windows/desktop/bb509695">texture.Sample</a> [datatype.Function]</td>
</tr>
<tr class="even">
<td align="left">sampler2D [datatype]</td>
<td align="left"><a href="https://msdn.microsoft.com/library/windows/desktop/ff471525">Texture2D</a> [datatype]</td>
</tr>
<tr class="odd">
<td align="left">行優先マトリックス (既定)</td>
<td align="left">列優先マトリックス (既定)
<div class="alert">
<strong>注</strong>  使用、 <strong>row_major</strong>型修飾子で 1 つの変数のレイアウトを変更します。 詳しくは、「<a href="https://msdn.microsoft.com/library/windows/desktop/bb509706">変数の構文</a>」をご覧ください。 コンパイラ フラグまたはプラグマを指定してグローバルな既定値を変更することもできます。
</div>
<div>
 
</div></td>
</tr>
<tr class="even">
<td align="left">フラグメント シェーダー</td>
<td align="left">ピクセル シェーダー</td>
</tr>
</tbody>
</table>

 

> **注**  HLSL がテクスチャおよびサンプラーとして 2 つのオブジェクト。 GLSL では、Direct3D 9 と同様に、テクスチャのバインドはサンプラーの状態の一部です。

 

GLSL では、事前定義されたグローバル変数として OpenGL の状態の多くを示します。 たとえば、GLSL でを使用する、 **gl\_位置**頂点の位置を指定する変数と**gl\_FragColor**フラグメントの色を指定する変数。 HLSL では、アプリ コードからシェーダーに Direct3D の状態を明示的に渡します。 たとえば、Direct3D と HLSL を使う場合は、頂点シェーダーへの入力が頂点バッファーのデータ形式に一致し、アプリ コードの定数バッファーの構造がシェーダー コードの定数バッファー ([cbuffer](https://msdn.microsoft.com/library/windows/desktop/bb509581)) の構造と一致する必要があります。

## <a name="porting-glsl-variables-to-hlsl"></a>HLSL への GLSL 変数の移植


GLSL では、グローバル シェーダーの変数の宣言に修飾子を適用し、その変数にシェーダーの特定の動作を割り当てます。 HLSL では、シェーダーとやり取りする引数を使ってシェーダーのフローを定義するため、これらの修飾子は必要ではありません。

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">GLSL の変数の動作</th>
<th align="left">相当する HLSL の要素</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><strong>uniform</strong></p>
<p>アプリ コードから uniform 変数を頂点シェーダーとフラグメント シェーダーのどちらか一方または両方に渡します。 これらのシェーダーを使って三角形を描画する前にすべての uniform の値を設定する必要があります。三角形のメッシュの描画中に値が変わらないようにするためです。 これらの値は変化しません。 フレーム全体に対して設定される uniform もあれば、特定の頂点ピクセル シェーダーのペアに対してのみ設定される uniform もあります。</p>
<p>uniform 変数はポリゴン単位の変数です。</p></td>
<td align="left"><p>定数バッファーを使います。</p>
<p>参照してください<a href="https://msdn.microsoft.com/library/windows/desktop/ff476896">方法。定数バッファーを作成</a>と<a href="https://msdn.microsoft.com/library/windows/desktop/bb509581">シェーダー定数</a>します。</p></td>
</tr>
<tr class="even">
<td align="left"><p><strong>さまざまな</strong></p>
<p>頂点シェーダー内で varying 変数を初期化し、フラグメント シェーダーの同じ名前の varying 変数に渡します。 頂点シェーダーは各頂点でのみさまざまな変数の値を設定するため、ラスタライザーはその値を (透視補正の方法で) 補間し、フラグメント単位の値を生成してフラグメント シェーダーに渡します。 これらの変数は各三角形で異なります。</p></td>
<td align="left">頂点シェーダーから取得した構造をピクセル シェーダーへの入力として使います。 セマンティック値が一致することを確かめてください。</td>
</tr>
<tr class="odd">
<td align="left"><p><strong>attribute</strong></p>
<p>属性は、アプリ コードから頂点シェーダーだけに渡す頂点の記述の一部です。 uniform とは異なり、頂点ごとに各属性の値を設定します。それにより、各頂点が異なる値を持つことができるようになります。 属性変数は頂点単位の変数です。</p></td>
<td align="left"><p>Direct3D アプリ コードで頂点バッファーを定義し、頂点シェーダーで定義されている頂点の入力と一致させます。 必要に応じてインデックス バッファーを定義します。 参照してください<a href="https://msdn.microsoft.com/library/windows/desktop/ff476899">方法。頂点バッファーを作成</a>と<a href="https://msdn.microsoft.com/library/windows/desktop/ff476897">方法。インデックス バッファーを作成</a>です。</p>
<p>Direct3D アプリ コードで入力レイアウトを作成し、セマンティック値を頂点の入力の値と一致させます。 「<a href="https://msdn.microsoft.com/library/windows/desktop/bb205117#Create_the_Input_Layout">入力レイアウトの作成</a>」をご覧ください。</p></td>
</tr>
<tr class="even">
<td align="left"><p><strong>const</strong></p>
<p>シェーダーにコンパイルされ、変更されない定数。</p></td>
<td align="left"><strong>static const</strong> を使用します。 <strong>static</strong> は、値が定数バッファーに公開されないことを表し、<strong>const</strong> は、シェーダーが値を変更できないことを表します。 そのため、値は初期化子に基づいてコンパイル時に把握されます。</td>
</tr>
</tbody>
</table>

 

GLSL では、修飾子のない変数は、各シェーダーに対してプライベートな通常のグローバル変数に過ぎません。

テクスチャ (HLSL での [Texture2D](https://msdn.microsoft.com/library/windows/desktop/ff471525)) と関連のサンプラー (HLSL での [SamplerState](https://msdn.microsoft.com/library/windows/desktop/bb509644)) にデータを渡すときに、通常は、ピクセル シェーダーのグローバル変数としてこれらを宣言します。

## <a name="porting-glsl-types-to-hlsl"></a>HLSL への GLSL の型の移植


HLSL に GLSL の型を移植する場合は、次の表を参考にしてください。

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">GLSL の型</th>
<th align="left">HLSL の型</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left">スカラー型: float、int、bool</td>
<td align="left"><p>スカラー型: float、int、bool</p>
<p>また、uint、double</p>
<p>詳しくは、「<a href="https://msdn.microsoft.com/library/windows/desktop/bb509646">スカラー型</a>」をご覧ください。</p></td>
</tr>
<tr class="even">
<td align="left"><p>ベクター型</p>
<ul>
<li>浮動小数点ベクター: vec2、vec3、vec4</li>
<li>ブール ベクター: bvec2、bvec3、bvec4</li>
<li>符号付き整数ベクター: ivec2、ivec3、ivec4</li>
</ul></td>
<td align="left"><p>ベクター型</p>
<ul>
<li>float2、float3、float4、float1</li>
<li>bool2、bool3、bool4、bool1</li>
<li>int2、int3、int4、int1</li>
<li><p>これらの型には、float、bool、int に似たベクター拡張もあります。</p>
<ul>
<li>uint</li>
<li>min10float、min16float</li>
<li>min12int、min16int</li>
<li>min16uint</li>
</ul></li>
</ul>
<p>詳しくは、「<a href="https://msdn.microsoft.com/library/windows/desktop/bb509707">ベクター型</a>」と「<a href="https://msdn.microsoft.com/library/windows/desktop/bb509568">キーワード</a>」をご覧ください。</p>
<p>vector は、float4 として定義される型でもあります (typedef vector &lt;float, 4&gt; vector;)。 詳しくは、「<a href="https://msdn.microsoft.com/library/windows/desktop/bb509702">ユーザー定義型</a>」をご覧ください。</p></td>
</tr>
<tr class="odd">
<td align="left"><p>マトリックス型</p>
<ul>
<li>mat2:float の 2 × 2 の行列</li>
<li>mat3:float の 3 x 3 行列</li>
<li>mat4:4 x 4 float マトリックス</li>
</ul></td>
<td align="left"><p>マトリックス型</p>
<ul>
<li>float2x2</li>
<li>float3x3</li>
<li>float4x4</li>
<li>また、float1x1、float1x2、float1x3、float1x4、float2x1、float2x3、float2x4、float3x1、float3x2、float3x4、float4x1、float4x2、float4x3</li>
<li><p>これらの型には、float に似たマトリックス拡張もあります。</p>
<ul>
<li>int、uint、bool</li>
<li>min10float、min16float</li>
<li>min12int、min16int</li>
<li>min16uint</li>
</ul></li>
</ul>
<p>また、マトリックスの定義に<a href="https://msdn.microsoft.com/library/windows/desktop/bb509623">マトリックス型</a>を使うこともできます。</p>
<p>例: matrix &lt;float, 2, 2&gt; fMatrix = {0.0f, 0.1, 2.1f, 2.2f};</p>
<p>matrix は、float4x4 として定義される型でもあります (typedef matrix &lt;float, 4, 4&gt; matrix;)。 詳しくは、「<a href="https://msdn.microsoft.com/library/windows/desktop/bb509702">ユーザー定義型</a>」をご覧ください。</p></td>
</tr>
<tr class="even">
<td align="left"><p>float、int、sampler の有効桁数修飾子</p>
<ul>
<li><p>highp</p>
<p>この修飾子は min16float によって指定されるものより大きく、完全な 32 ビット float より小さい最小有効桁数要件を指定します。 相当する HLSL の要素:</p>
<p>highp float -&gt; float</p>
<p>highp int -&gt; int</p></li>
<li><p>mediump</p>
<p>float と int に適用されるこの修飾子は、HLSL の min16float と min12int に相当します。 mantissa の最小 10 ビット。min10float とは異なります。</p></li>
<li><p>lowp</p>
<p>float に適用されるこの修飾子は、-2 ～ 2 の浮動小数点の範囲を指定します。 HLSL での min10float に相当します。</p></li>
</ul></td>
<td align="left"><p>有効桁数の型</p>
<ul>
<li>min16float: 16 ビットの最小浮動小数点値</li>
<li><p>min10float</p>
<p>最小の符号付き固定小数点 2.8 ビット値 (整数部は 2 ビット、小数部は 8 ビット)。 8 ビットの小数部には 1 を含めることができます。また、-2 ～ 2 の範囲の両端を含めることができます。</p></li>
<li>min16int: 16 ビットの最小符号付き整数</li>
<li><p>min12int: 12 ビットの最小符号付き整数</p>
<p>この型は 10Level9 (<a href="https://msdn.microsoft.com/library/windows/desktop/ff476876">9_x の機能レベル</a>) 向けであり、整数は浮動小数点数で表されます。 これは、16 ビットの浮動小数点数で整数をエミュレートするときに取得できる有効桁数です。</p></li>
<li>min16int: 16 ビットの最小符号なし整数</li>
</ul>
<p>詳しくは、「<a href="https://msdn.microsoft.com/library/windows/desktop/bb509646">スカラー型</a>」と「<a href="https://msdn.microsoft.com/library/windows/desktop/hh968108">HLSL の最小精度の使用</a>」をご覧ください。</p></td>
</tr>
<tr class="odd">
<td align="left">sampler2D</td>
<td align="left"><a href="https://msdn.microsoft.com/library/windows/desktop/ff471525">Texture2D</a></td>
</tr>
<tr class="even">
<td align="left">samplerCube</td>
<td align="left"><a href="https://msdn.microsoft.com/library/windows/desktop/bb509700">TextureCube</a></td>
</tr>
</tbody>
</table>

 

## <a name="porting-glsl-pre-defined-global-variables-to-hlsl"></a>HLSL への GLSL の定義済みグローバル変数の移植


GLSL の定義済みグローバル変数を HLSL に移植する場合は、次の表を参考にしてください。

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">GLSL の定義済みグローバル変数</th>
<th align="left">HLSL セマンティクス</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><strong>gl_Position</strong></p>
<p>この変数は <strong>vec4</strong> 型です。</p>
<p>頂点の位置</p>
<p>例: gl_Position = position;</p></td>
<td align="left"><p>SV_Position</p>
<p>Direct3D 9 の POSITION</p>
<p>このセマンティックは <strong>float4</strong> 型です。</p>
<p>頂点シェーダーの出力</p>
<p>頂点の位置</p>
<p>たとえば、float4 vPosition:SV_Position;</p></td>
</tr>
<tr class="even">
<td align="left"><p><strong>gl_PointSize</strong></p>
<p>この変数は <strong>float</strong> 型です。</p>
<p>ポイントのサイズ</p></td>
<td align="left"><p>PSIZE</p>
<p>Direct3D 9 を対象としない場合、意味はありません</p>
<p>このセマンティックは <strong>float</strong> 型です。</p>
<p>頂点シェーダーの出力</p>
<p>ポイントのサイズ</p></td>
</tr>
<tr class="odd">
<td align="left"><p><strong>gl_FragColor</strong></p>
<p>この変数は <strong>vec4</strong> 型です。</p>
<p>フラグメント色</p>
<p>例: gl_FragColor = vec4(colorVarying, 1.0);</p></td>
<td align="left"><p>SV_Target</p>
<p>Direct3D 9 の COLOR</p>
<p>このセマンティックは <strong>float4</strong> 型です。</p>
<p>ピクセル シェーダーの出力</p>
<p>ピクセルの色</p>
<p>例 - float4 色 [4]。SV_Target;</p></td>
</tr>
<tr class="even">
<td align="left"><p><strong>gl_FragData[n]</strong></p>
<p>この変数は <strong>vec4</strong> 型です。</p>
<p>カラー アタッチメント n のフラグメント色</p></td>
<td align="left"><p>SV_Target[n]</p>
<p>このセマンティックは <strong>float4</strong> 型です。</p>
<p>n レンダー ターゲットに格納されるピクセル シェーダーの出力値 (0 &lt;= n &lt;= 7)。</p></td>
</tr>
<tr class="odd">
<td align="left"><p><strong>gl_FragCoord</strong></p>
<p>この変数は <strong>vec4</strong> 型です。</p>
<p>フレーム バッファー内のフラグメントの位置</p></td>
<td align="left"><p>SV_Position</p>
<p>Direct3D 9 では使用できません</p>
<p>このセマンティックは <strong>float4</strong> 型です。</p>
<p>ピクセル シェーダーの入力</p>
<p>画面領域の座標</p>
<p>例 - float4 スクリーン空間。SV_Position</p></td>
</tr>
<tr class="even">
<td align="left"><p><strong>gl_FrontFacing</strong></p>
<p>この変数は <strong>bool</strong> 型です。</p>
<p>フラグメントが前向きのプリミティブに属しているかどうかを決定します。</p></td>
<td align="left"><p>SV_IsFrontFace</p>
<p>Direct3D 9 の VFACE</p>
<p>SV_IsFrontFace は <strong>bool</strong> 型です。</p>
<p>VFACE は <strong>float</strong> 型です。</p>
<p>ピクセル シェーダーの入力</p>
<p>プリミティブの向き</p></td>
</tr>
<tr class="odd">
<td align="left"><p><strong>gl_PointCoord</strong></p>
<p>この変数は <strong>vec2</strong> 型です。</p>
<p>ポイント内のフラグメントの位置 (ポイントのラスター化のみ)</p></td>
<td align="left"><p>SV_Position</p>
<p>Direct3D 9 の VPOS</p>
<p>SV_Position は <strong>float4</strong> 型です。</p>
<p>VPOS は <strong>float2</strong> 型です。</p>
<p>ピクセル シェーダーの入力</p>
<p>画面領域のピクセルまたはサンプルの位置</p>
<p>たとえば、float4 pos:SV_Position</p></td>
</tr>
<tr class="even">
<td align="left"><p><strong>gl_FragDepth</strong></p>
<p>この変数は <strong>float</strong> 型です。</p>
<p>深度バッファーのデータ</p></td>
<td align="left"><p>SV_Depth</p>
<p>Direct3D 9 の DEPTH</p>
<p>SV_Depth は <strong>float</strong> 型です。</p>
<p>ピクセル シェーダーの出力</p>
<p>深度バッファーのデータ</p></td>
</tr>
</tbody>
</table>

 

頂点シェーダーの入力とピクセル シェーダーの入力に位置や色などを指定するには、セマンティクスを使います。 入力レイアウトのセマンティクス値と頂点シェーダーの入力を一致させる必要があります。 例については、「[HLSL への GLSL 変数の移植の例](#examples-of-porting-glsl-variables-to-hlsl)」をご覧ください。 HLSL セマンティクスについて詳しくは、「[セマンティクス](https://msdn.microsoft.com/library/windows/desktop/bb509647)」をご覧ください。

## <a name="examples-of-porting-glsl-variables-to-hlsl"></a>HLSL への GLSL 変数の移植の例


ここでは、OpenGL/GLSL コードの GLSL 変数の使用例と、Direct3D/HLSL コードでの相当する例を紹介します。

### <a name="uniform-attribute-and-varying-in-glsl"></a>GLSL での uniform、attribute、および varying

OpenGL のアプリ コード

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

GLSL の頂点シェーダー コード

``` syntax
//The shader entry point is the main method.
void main()
{
colorVarying = color; //Use the varying variable to pass the color to the fragment shader
gl_Position = position; //Copy the position to the gl_Position pre-defined global variable
}
```

GLSL のフラグメント シェーダー コード

``` syntax
void main()
{
//Pad the colorVarying vec3 with a 1.0 for alpha to create a vec4 color
//and assign that color to the gl_FragColor pre-defined global variable
//This color then becomes the fragment's color.
gl_FragColor = vec4(colorVarying, 1.0);
}
```

### <a name="constant-buffers-and-data-transfers-in-hlsl"></a>HLSL での定数バッファーとデータ転送

データを HLSL の頂点シェーダーに渡し、それがピクセル シェーダーに渡されるしくみの例を示します。 アプリ コードでは、頂点と定数バッファーを定義します。 次に、頂点シェーダー コードで、定数バッファーを [cbuffer](https://msdn.microsoft.com/library/windows/desktop/bb509581) として定義し、頂点単位のデータとピクセル シェーダーの入力データを格納します。 ここでは、**VertexShaderInput** および **PixelShaderInput** と呼ばれる構造を使います。

Direct3D のアプリ コード

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

HLSL の頂点シェーダー コード

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

HLSL のピクセル シェーダー コード

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

## <a name="examples-of-porting-opengl-rendering-code-to-direct3d"></a>Direct3D への OpenGL のレンダリング コードの移植例


ここでは、OpenGL ES 2.0 コードのレンダリングの例と、Direct3D 11 コードでの相当する例を紹介します。

OpenGL のレンダリング コード

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

Direct3D のレンダリング コード

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

## <a name="related-topics"></a>関連トピック


* [OpenGL ES 2.0 から Direct3D への移植 11](port-from-opengl-es-2-0-to-directx-11-1.md)

 

 




