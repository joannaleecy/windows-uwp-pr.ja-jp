---
title: ラスター化規則の概要
description: 多くの場合、頂点として指定される点は、画面上のピクセルと正確には一致しません。 この場合、Direct3D は三角形のラスター化ルールを適用し、指定された三角形に適用するピクセルを決定します。
ms.assetid: 4232CDBA-F669-4417-9378-F9013E83462C
keywords:
- ラスター化規則の概要
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 65522195b9729ddd4f2ebeb193f43c905359eda2
ms.sourcegitcommit: 144f5f127fc4fbd852f2f6780ef26054192d68fc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/02/2018
ms.locfileid: "5980931"
---
# <a name="introduction-to-rasterization-rules"></a>ラスター化規則の概要


多くの場合、頂点として指定される点は、画面上のピクセルと正確には一致しません。 この場合、Direct3D は三角形のラスター化ルールを適用し、指定された三角形に適用するピクセルを決定します。

これは、ラスター化規則の簡単な説明です。 詳しくは、「[ラスター化ルール](rasterization-rules.md)」をご覧ください。 「[ラスタライザー (RS) ステージ](rasterizer-stage--rs-.md)」もご覧ください。

## <a name="span-idtrianglerasterizationrulesspanspan-idtrianglerasterizationrulesspanspan-idtrianglerasterizationrulesspantriangle-rasterization-rules"></a><span id="Triangle_Rasterization_Rules"></span><span id="triangle_rasterization_rules"></span><span id="TRIANGLE_RASTERIZATION_RULES"></span>三角形のラスター化ルール


Direct3D は、塗りつぶしジオメトリに左上の塗りつぶし規則を使います。 これは、GDI と OpenGL の長方形に使われているのと同じ規則です。 Direct3D では、ピクセルの中心が決定的な点となります。 中心が三角形の中の場合、ピクセルは三角形の一部です。 ピクセルの中心は、整数座標上にあります。

Direct3D により使われる三角形のラスター化ルールのこの説明は、必ずしも使用可能なすべてのハードウェアに当てはまるわけではありません。 テストの結果、これらのルールの実装が少し異なる場合があります。

次の図は、左上隅が (0, 0) で右下隅が (5, 5) の長方形を示しています。 この長方形は、予想されるとおり 25 ピクセルを塗りつぶします。 長方形の幅は右から左を減算した値と定義されます。 高さは下から上を減算した値と定義されます。

![5 つの行と列に分割された番号付きの正方形](images/pixmap.png)

左上の塗りつぶし規則では、*上*とは水平スパンにおける垂直方法の位置を示し、*左*はスパン内におけるピクセルの水平方向の位置を示します。 エッジは、水平方向でない限り上エッジとすることはできません。 通常、ほとんどの三角形には左エッジと右エッジのみあります。 次の図は、上エッジと右エッジを示しています。

![2 つの三角形を含む番号付きの正方形](images/triedge.png)

左上の塗りつぶし規則により、三角形がピクセルの中心を通過するときに Direct3D が実行する操作が決まります。 次の図は、2 つの三角形を示しています。1 つは (0, 0)、(5, 0)、(5, 5) にあり、もう 1 つは (0, 5)、(0, 0)、(5, 5) にあります。 このケースの 1 つ目の三角形は 15 ピクセル (黒で表示) を取得しますが、2 つ目の三角形が取得するのは 10 ピクセル (灰色で表示) だけです。共有されるエッジが 1 つ目の三角形の左エッジのためです。

![2 つの三角形を示す番号付きの正方形](images/twotris.png)

左上隅 (0.5, 0.5) と右下隅 (2.5, 4.5) で三角形を定義した場合、この三角形の中心点は (1.5, 2.5) になります。 Direct3D ラスタライザーによりこの三角形がテッセレーションされた場合、各ピクセルの中心は明確に 4 つの各三角形の中に収まり、左上の塗りつぶし規則は必要ありません。 次の図にこれを示します。 三角形内のピクセルには、Direct3D がピクセルを含める三角形に基づいてラベルが付けられます。

![4 つの三角形に分割された長方形を含む番号付きの正方形](images/noambig.png)

その左上隅が (1.0, 1.0)、右下隅が (3.0, 5.0)、中心点が (2.0, 3.0) となるように前の図の長方形を移動した場合、Direct3D は左上の塗りつぶし規則を適用します。 次の図が示すように、この長方形内のほとんどのピクセルは複数の三角形の境界をまたいでいます。

![4 つの三角形に分割された長方形を含む番号付きの正方形](images/fillrule.png)

どちらの長方形でも、次の図に示すように同じピクセルが影響を受けています。

![前の 2 つの番号付きの正方形の影響を受けているピクセル](images/samepix.png)

## <a name="span-idpointandlinerulesspanspan-idpointandlinerulesspanspan-idpointandlinerulesspanpoint-and-line-rules"></a><span id="Point_and_Line_Rules"></span><span id="point_and_line_rules"></span><span id="POINT_AND_LINE_RULES"></span>点および線のルール


点は、ポイント スプライトと同じようにレンダリングされます。どちらも画面に沿った四角形としてレンダリングされるため、多角形のレンダリングと同じルールに従います。

アンチエイリアスが適用されていない線のレンダリング ルールは、[GDI の線](https://msdn.microsoft.com/library/windows/desktop/dd145027)のルールとまったく同じです。

## <a name="span-idpointspriterulesspanspan-idpointspriterulesspanspan-idpointspriterulesspanpoint-sprite-rules"></a><span id="Point_Sprite_Rules"></span><span id="point_sprite_rules"></span><span id="POINT_SPRITE_RULES"></span>ポイント スプライトのルール


ポイント スプライトとパッチ プリミティブは、プリミティブが最初に三角形にテッセレーションされた後、その三角形がラスター化されたかのようにラスター化されます。

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[デバイス](devices.md)

[ラスタライザー (RS) ステージ](rasterizer-stage--rs-.md)

[ラスター化ルール](rasterization-rules.md)

 

 




