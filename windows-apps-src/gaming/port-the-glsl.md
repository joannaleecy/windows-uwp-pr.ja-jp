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
# <a name="port-the-glsl"></a>GLSL の移植




**重要な API**

-   [HLSL のセマンティクス](https://msdn.microsoft.com/library/windows/desktop/bb205574)
-   [シェーダー定数 (HLSL)](https://msdn.microsoft.com/library/windows/desktop/bb509581)

バッファーとシェーダー オブジェクトを作成して構成するコードが完成したら、それらのシェーダー内のコードを OpenGL ES 2.0 の GL シェーダー言語 (GLSL) から Direct3D 11 の上位レベル シェーダー言語 (HLSL) に移植します。

OpenGL ES 2.0 でシェーダーがなどの組み込み関数を使用して実行後にデータを返す**gl\_位置**、 **gl\_FragColor**、または**gl\_FragData\[n\]**  (n は、特定のレンダー ターゲットのインデックスです)。 Direct3D では、特定の組み込みメソッドはなく、シェーダーはそれぞれの main() 関数の戻り値の型としてデータを返します。

頂点の位置や法線など、シェーダー ステージ間で補間されるデータは、**varying** 宣言を使って処理します。 ただし、Direct3D にはこの宣言がありません。そのため、シェーダー ステージ間で受け渡されるデータは [HLSL セマンティクス](https://msdn.microsoft.com/library/windows/desktop/bb205574)でマークする必要があります。 選んだ特定のセマンティクスはデータの目的を示します。 たとえば、フラグメント シェーダー間で補完される頂点データは次のように宣言します。

`float4 vertPos : POSITION;`

または

`float4 vertColor : COLOR;`

POSITION は、頂点の位置データを示すために使うセマンティクスです。 また、POSITION は特殊なケースで、補間後にピクセル シェーダーからアクセスできません。 したがって、SV でピクセル シェーダーへの入力を指定する必要があります\_位置と、補間された頂点データは、その変数に配置されます。

`float4 position : SV_POSITION;`

セマンティクスは、シェーダーの body (main) メソッドで宣言できます。 ピクセル シェーダー、SV の\_ターゲット\[n\]、本文メソッドで必要なレンダー ターゲットを示します。 (SV\_ターゲット インデックス 0 を表示するために既定値は数値のサフィックスなしの対象です)。

また 頂点シェーダーが SV を出力するために必要なことに注意してください\_位置システム値セマンティック。 このセマンティクスは頂点の位置データを座標値に解決します。x は -1 ～ 1 の値に、y は -1 ～ 1 の値になり、z は元の同次座標 w の値で割られ (z/w)、w は 1 を元の w の値で割った値 (1/w) になります。 ピクセル シェーダーを使用して、SV\_セマンティック x が 0 と、レンダー ターゲットの幅と y の間は、画面のピクセル位置を取得する位置のシステム値が 0 ~ レンダー ターゲットの高さ (0.5 で各オフセット)。 機能レベル 9\_ピクセル シェーダーは、SV から読み取ることができません x\_位置の値。

定数バッファーは **cbuffer** を使って宣言し、検索のために特定の開始レジスタに関連付ける必要があります。

Direct3D 11。HLSL 定数バッファーの宣言は、

``` syntax
cbuffer ModelViewProjectionConstantBuffer : register(b0)
{
  matrix mvp;
};
```

ここでは、定数バッファーはレジスタ b0 を使って、パックされたバッファーを保持します。 すべてのレジスタ フォーム b で参照される\#します。 HLSL での定数バッファー、レジスタ、データ パッキングの実装について詳しくは、「[シェーダー定数 (HLSL)](https://msdn.microsoft.com/library/windows/desktop/bb509581)」をご覧ください。

<a name="instructions"></a>手順
------------
### <a name="step-1-port-the-vertex-shader"></a>手順 1:ポート、頂点シェーダー

この簡単な OpenGL ES 2.0 の例では、頂点シェーダーに 3 つの入力があります。1 つの定数のモデル ビュー プロジェクション 4x4 マトリックスと 2 つの 4 座標ベクトルです。 これら 2 つのベクトルには、頂点の位置と色が含まれます。 シェーダーがパースペクティブ座標に position ベクトルを変換し、gl に代入\_ラスタライズの組み込みの位置。 また、頂点の色は、ラスタライズ時に補間のために varying 変数にコピーされます。

OpenGL ES 2.0:キューブ オブジェクト (GLSL) の頂点シェーダー

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

次に、direct3d で定数のモデル-ビュー-射影行列がレジスタ b0 に搭載された定数バッファーに含まれているし、頂点の位置と色が、適切なそれぞれの HLSL セマンティクスでマークされた具体的には。位置や色。 入力レイアウトはこれら 2 つの頂点の値の特定の配置を示しているため、それらの値を保持する構造体を作成し、シェーダーの body 関数 (main) でその構造体を入力パラメーターの型として宣言します  (2 つの個別のパラメーターとして指定することも、面倒を取得する可能性があります)。このステージでは、挿入位置と色を含む出力の種類を指定し、頂点シェーダーの本文の関数の戻り値として変数を宣言します。

Direct3D 11。キューブ オブジェクト (HLSL) の頂点シェーダー

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

出力のデータ型 PixelShaderInput は、ラスタライズ時に設定され、フラグメント (ピクセル) シェーダーに渡されます。

### <a name="step-2-port-the-fragment-shader"></a>手順 2:ポート フラグメント シェーダー

GLSL で、例のフラグメント シェーダーは非常に単純: 提供、gl\_FragColor 色の補間値を持つ組み込み。 OpenGL ES 2.0 では、それを既定のレンダー ターゲットに書き込みます。

OpenGL ES 2.0:キューブ オブジェクト (GLSL) のフラグメント シェーダー

``` syntax
varying vec4 destColor;

void main()
{
  gl_FragColor = destColor;
} 
```

Direct3D も同じくらい簡単です。 大きな違いは、ピクセル シェーダーの body 関数で値を返す必要があることだけです。 Float4 として戻り値の型を示すし、SV として既定のレンダー ターゲットを指定し、色は、4 座標 (RGBA) の浮動小数点値であるため\_ターゲット システム値セマンティック。

Direct3D 11。キューブ オブジェクト (HLSL) のピクセル シェーダー

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

位置のピクセルの色はレンダー ターゲットに書き込まれます。 次に、「[画面への描画](draw-to-the-screen.md)」でそのレンダー ターゲットのコンテンツを表示する方法を見ていきます。

## <a name="previous-step"></a>前のステップ


[頂点バッファーと頂点データの移植](port-the-vertex-buffers-and-data-config.md) 次の手順
---------
[画面への描画](draw-to-the-screen.md) 解説
-------
HLSL セマンティクスと定数バッファーのパッキングについて理解すると、デバッグの苦労がいくらか少なくなるだけでなく、最適化できるようにもなります。 機会を得る場合読んで[変数構文 (HLSL)](https://msdn.microsoft.com/library/windows/desktop/bb509706)、 [direct3d11 のバッファーの概要](https://msdn.microsoft.com/library/windows/desktop/ff476898)、および[方法。定数バッファーを作成](https://msdn.microsoft.com/library/windows/desktop/ff476896)です。 機会がない場合は、次のセマンティクスと定数バッファーについての基本的なヒントを心に留めておいてください。

-   必ずレンダラーの Direct3D 構成コードを見直して、定数バッファーの構造体が HLSL の cbuffer 構造体の宣言と一致し、コンポーネントのスカラー型が両方の宣言で一致していることを確認する。
-   レンダラーの C++ コードでは、データ パッキングが適切に行われるように、定数バッファーの宣言で [DirectXMath](https://msdn.microsoft.com/library/windows/desktop/hh437833) 型を使う。
-   定数バッファーを効率的に使う最良の方法として、更新頻度に応じてシェーダーの変数を定数バッファーにまとめる。 たとえば、フレームごとに 1 回更新される uniform データと、カメラが移動したときにだけ更新される uniform データがある場合は、それらのデータを 2 つの定数バッファーに分けることを考えます。
-   セマンティクスの適用し忘れや誤った適用は、シェーダー コンパイル (FXC) エラーのよくある原因である。 よく見直してください。 以前のページやサンプルの多くでは Direct3D 11 より前のさまざまなバージョンの HLSL セマンティクスを参照しているため、ドキュメントが混乱を招くことがあります。
-   各シェーダーのターゲットとする Direct3D 機能レベルを確認する。 機能をセマンティクス レベル 9\_ \*が 11 の異なる\_1。
-   SV\_位置セマンティック解決の座標 x は 0 と、レンダー ターゲットの幅、y の間で値を後の補間の関連付けられている位置データが 0 ~、レンダー ターゲットの高さ、z が元の同種の座標 w で割った値値 (z/w)、および w は、元の w 値 (1 w) で割った値 1 です。

## <a name="related-topics"></a>関連トピック


[方法: direct3d11 を単純な OpenGL ES 2.0 レンダラーのポート](port-a-simple-opengl-es-2-0-renderer-to-directx-11-1.md)

[シェーダー オブジェクトの移植](port-the-shader-config.md)

[頂点バッファーと頂点データの移植](port-the-vertex-buffers-and-data-config.md)

[画面への描画](draw-to-the-screen.md)

 

 




