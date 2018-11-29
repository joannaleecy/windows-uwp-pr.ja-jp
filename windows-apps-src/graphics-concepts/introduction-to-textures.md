---
title: テクスチャの概要
description: テクスチャ リソースはテクセルを保存するデータ構造で、読み書きできるテクスチャの最小単位です。 テクスチャがシェーダーにより読み取られる際、テクスチャ サンプラーでフィルターを適用することができます。
ms.assetid: 6F3C76A8-F762-4296-AE02-BFBD6476A5A8
keywords:
- テクスチャの概要
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 3cd5ca66635b57b79c2fca3e6ff10b8debb43fd0
ms.sourcegitcommit: 89ff8ff88ef58f4fe6d3b1368fe94f62e59118ad
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/29/2018
ms.locfileid: "8209295"
---
# <a name="introduction-to-textures"></a>テクスチャの概要


テクスチャ リソースはテクセルを保存するデータ構造で、読み書きできるテクスチャの最小単位です。 テクスチャがシェーダーにより読み取られる際、テクスチャ サンプラーでフィルターを適用することができます。

テクスチャ リソースは、テクセルを格納するように設計された、データの構造化されたコレクションです。 テクセルは、パイプラインで読み取ったり、書き込んだりすることができるテクスチャの最小単位を表します。 バッファーと異なり、テクスチャは、シェーダー ユニットに読み取られる際にテクスチャ サンプラーでフィルターを適用することができます。 テクスチャへのフィルター処理の適用方法はテクスチャの種類に影響されます。 各テクセルは 1 ～ 4 つの成分を含み、DXGI\_FORMAT 列挙値により定義された DXGI 形式のいずれかで配置されます。

テクスチャは構造化されたリソースとして、既知のサイズで作成されます。 ただし、各テクスチャはリソースの作成時に型指定される場合もありますが、テクスチャをパイプラインにバインドするときにビューを使用して型を完全に指定するという条件で、リソース作成時に型指定されない場合もあります。

## <a name="span-idtexturetypesspanspan-idtexturetypesspanspan-idtexturetypesspantexture-types"></a><span id="Texture_Types"></span><span id="texture_types"></span><span id="TEXTURE_TYPES"></span>テクスチャの種類


Direct3D は、複数の浮動小数点表現をサポートします。 すべての浮動小数点計算は、IEEE 754 32 ビット単精度浮動小数点ルールの定義済みサブセット下で実行されます。

テクスチャの種類には 1D、2D、および 3D があり、それぞれミップマップ付きまたはミップマップなしで作成できます。 Direct3D では、テクスチャ配列とマルチサンプリングされたテクスチャもサポートされています。

-   [1D テクスチャ](#texture1d-resource)
-   [1D テクスチャ配列](#texture1d-array-resource)
-   [2D テクスチャと 2D テクスチャ配列](#texture2d-resource)
-   [3D テクスチャ](#texture3d-resource)

### <a name="span-idtexture1dresourcespanspan-idtexture1dresourcespanspan-idtexture1dresourcespanspan-idtexture1d-resourcespan1d-textures"></a><span id="Texture1D_Resource"></span><span id="texture1d_resource"></span><span id="TEXTURE1D_RESOURCE"></span><span id="texture1d-resource"></span>1D テクスチャ

最も単純な形式の 1D テクスチャには、1 つのテクスチャ座標で処理できるテクスチャ データが格納されます。これをテクセルの配列として視覚化すると次の図のようになります。

次の図に 1D テクスチャを示します。

![1D テクスチャ](images/d3d10-1d-texture.png)

各テクセルには、格納されているデータ形式に応じた色成分がいくつか含まれます。 より複雑なものになると、次の図に示すように、ミップマップ レベルを持つ 1D テクスチャを作成できます。

![ミップマップ レベルを持つ 1D テクスチャ](images/d3d10-resource-texture1d.png)

ミップマップ レベルは、上のレベルよりも 2 の累乗だけ小さいテクスチャです。 最上位レベルが最も詳細で (大きく)、レベルが下がるほど小さくなります。 1D ミップマップの最小レベルはテクセルを 1 つだけ含みます。 さらに、MIP レベルは常に 1:1 まで下がります。

ミップマップが奇数サイズのテクスチャに生成された場合、1 つ下のレベルは必ず偶数サイズになります (最下位レベルが 1 に達した場合を除く)。 たとえば、この図は次の最下位レベルが 2x1 テクスチャである 5x1 テクスチャを示しており、次の (および最後の) ミップ レベルは 1x1 サイズのテクスチャです。 レベルの識別には詳細レベル (LOD) と呼ばれるインデックスを使用します。LOD は、カメラにそれほど近くないジオメトリをレンダリングする場合に、小さいテクスチャにアクセスするために使用されます。

### <a name="span-idtexture1darrayresourcespanspan-idtexture1darrayresourcespanspan-idtexture1darrayresourcespanspan-idtexture1d-array-resourcespan1d-texture-arrays"></a><span id="Texture1D_Array_Resource"></span><span id="texture1d_array_resource"></span><span id="TEXTURE1D_ARRAY_RESOURCE"></span><span id="texture1d-array-resource"></span>1D テクスチャ配列

Direct3D は、テクスチャの配列もサポートします。 1D テクスチャの配列は概念的に次の図のようになります。

![1D テクスチャの配列](images/d3d10-resource-texture1darray.png)

このテクスチャ配列には 3 つのテクスチャが含まれています。 3 つのテクスチャはそれぞれテクスチャ幅が 5 になっています (5 は最初のレイヤーの要素数)。 また、各テクスチャには 3 レイヤーのミップマップも格納されています。

Direct3D のすべてのテクスチャ配列は、テクスチャの同次配列です。つまり、1 つのテクスチャ配列内にあるテクスチャはすべて、データ形式とサイズが (テクスチャ幅とミップマップ レベル数も含めて) 同じである必要があります。 各配列に含まれるすべてのテクスチャのサイズが一致してさえいれば、さまざまなサイズのテクスチャ配列を作成できます。

### <a name="span-idtexture2dresourcespanspan-idtexture2dresourcespanspan-idtexture2dresourcespanspan-idtexture2d-resourcespan2d-textures-and-2d-texture-arrays"></a><span id="Texture2D_Resource"></span><span id="texture2d_resource"></span><span id="TEXTURE2D_RESOURCE"></span><span id="texture2d-resource"></span>2D テクスチャと 2D テクスチャ配列

Texture2D リソースにはテクセルの 2D グリッドが 1 つ含まれています。 各テクセルは u ベクトルと v ベクトルで指定できます。 これはテクスチャ リソースであるため、ミップマップ レベルとサブリソースが格納される場合もあります。 すべてのデータが設定された 2D テクスチャ リソースは次の図のようになります。

![2D テクスチャ リソース](images/d3d10-resource-texture2d.png)

このテクスチャ リソースには 1 つの 3x5 テクスチャと 3 つのミップマップ レベルが格納されています。

2D テクスチャ リソースは 2D テクスチャの同次配列であるため、各テクスチャのデータ形式とサイズは (ミップマップ レベルを含めて) 同じです。 次の図に示すように、このリソースはテクスチャに 2D データが含まれていることを除けば 1D テクスチャ配列とレイアウトが似ています。

![2D テクスチャの配列](images/d3d10-resource-texture2darray.png)

このテクスチャ配列には 3 つのテクスチャが含まれています。各テクスチャは 3x5 で、2 つのミップマップ レベルを持ちます。

### <a name="span-idtexture2darrayresourceasatexturecubespanspan-idtexture2darrayresourceasatexturecubespanspan-idtexture2darrayresourceasatexturecubespanusing-a-2d-texture-array-as-a-texture-cube"></a><span id="Texture2DArray_Resource_as_a_Texture_Cube"></span><span id="texture2darray_resource_as_a_texture_cube"></span><span id="TEXTURE2DARRAY_RESOURCE_AS_A_TEXTURE_CUBE"></span>テクスチャ キューブとしての 2D テクスチャ配列の使用

テクスチャ キューブは、6 つのテクスチャ (キューブの各面に 1 つずつ) が含まれた 2D テクスチャ配列です。 すべてのデータが設定されたテクスチャ キューブは次の図のようになります。

![テクスチャ キューブを表す 2D テクスチャ配列](images/d3d10-resource-texturecube.png)

6 つのテクスチャが含まれた 2D テクスチャ配列は、キューブ テクスチャ ビューを使ってパイプラインにバインドした後に、キューブ マップ組み込み関数を使ってシェーダー内から読み取ることができます。 テクスチャ キューブは、テクスチャ キューブの中心を起点とする 3D ベクトルによってシェーダーで処理されます。

### <a name="span-idtexture3dresourcespanspan-idtexture3dresourcespanspan-idtexture3dresourcespanspan-idtexture3d-resourcespan3d-textures"></a><span id="Texture3D_Resource"></span><span id="texture3d_resource"></span><span id="TEXTURE3D_RESOURCE"></span><span id="texture3d-resource"></span>3D テクスチャ

3D テクスチャ リソース (ボリューム テクスチャとも呼ばれます) にはテクセルの 3D ボリュームが格納されます。 これはテクスチャ リソースであるため、ミップマップ レベルが含まれる場合もあります。 すべてのデータが設定された 3D テクスチャは次の図のようになります。

![3D テクスチャ リソース](images/d3d10-resource-texture3d.png)

3D テクスチャ ミップマップ スライスを (レンダー ターゲット ビューを使って) レンダー ターゲット出力としてバインドした場合、3D テクスチャは n 個のスライスの 2D テクスチャ配列と同じように動作します。 特定のレンダー スライスはジオメトリ シェーダー ステージで選択します。

3D テクスチャ配列という概念は存在しません。そのため、3D テクスチャのサブリソースは単一のミップマップ レベルになります。

Direct3D の座標系は、ピクセルとテクセルで定義されます。

## <a name="span-idpixelspanspan-idpixelspanspan-idpixelspanpixel-coordinate-system"></a><span id="Pixel"></span><span id="pixel"></span><span id="PIXEL"></span>ピクセル座標系


Direct3D のピクセル座標系は、次の図に示すように、左上隅にあるレンダー ターゲットの原点を定義します。 ピクセルの中心は、整数位置から (0.5f,0.5f) オフセットされます。

![Direct3D 10 におけるピクセル座標系の図](images/d3d10-coordspix10.png)

## <a name="span-idtexelspanspan-idtexelspanspan-idtexelspantexel-coordinate-system"></a><span id="Texel"></span><span id="texel"></span><span id="TEXEL"></span>テクセル座標系


テクセル座標系では、次の図に示すように、テクスチャの左上隅に原点があります。 これにより、ピクセル座標権がテクセル座標系に揃えられるため、画面に沿ったテクスチャのレンダリングが簡単になります。

![テクセル座標系の図](images/d3d10-coordstex10.png)

テクスチャ座標は、正規化またはスケーリングされた番号で表現されます。各テクスチャ座標は、次のように特定のテクセルにマップされます。

正規化された座標の場合:

-   点サンプリング: テクセル \# = フロア(U \* 幅)
-   線サンプリング: 左テクセル \# = フロア(U \* 幅), 右テクセル \# = 左テクセル \# + 1

スケーリングされた座標の場合:

-   点サンプリング: テクセル \# = フロア(U)
-   線サンプリング: 左テクセル \# = フロア(U - 0.5), 右テクセル \# = 左テクセル \# + 1

ここで、幅はテクスチャの幅です (ピクセル単位)。

テクスチャ アドレスのラップは、テクセル位置が計算された後に行われます。

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[テクスチャ](textures.md)
