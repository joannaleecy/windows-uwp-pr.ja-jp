---
title: 面と頂点の法線ベクトル
description: メッシュ内の各面には、垂直な単位法線ベクトルがあります。 ベクトルの方向は、頂点が定義された順序によって、また座標系が右手系であるか左手系であるかによって決まります。
ms.assetid: 02333579-9749-4612-B121-23F97898A3E0
keywords:
- 面と頂点の法線ベクトル
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 2081e8c09a6f6fd75f460af3f339902bcb80bac6
ms.sourcegitcommit: 086001cffaf436e6e4324761d59bcc5e598c15ea
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/27/2018
ms.locfileid: "5700075"
---
# <a name="face-and-vertex-normal-vectors"></a>面と頂点の法線ベクトル


メッシュ内の各面には、垂直な単位法線ベクトルがあります。 ベクトルの方向は、頂点が定義された順序によって、また座標系が右手系であるか左手系であるかによって決まります。

## <a name="span-idperpendicularunitnormalvectorforafrontfacespanspan-idperpendicularunitnormalvectorforafrontfacespanspan-idperpendicularunitnormalvectorforafrontfacespanperpendicular-unit-normal-vector-for-a-front-face"></a><span id="Perpendicular_unit_normal_vector_for_a_front_face"></span><span id="perpendicular_unit_normal_vector_for_a_front_face"></span><span id="PERPENDICULAR_UNIT_NORMAL_VECTOR_FOR_A_FRONT_FACE"></span>前面対して垂直な単位法線ベクトル


メッシュ内の各面には、垂直な単位法線ベクトルがあります。 ベクトルの方向は、頂点が定義された順序によって、また座標系が右手系であるか左手系であるかによって決まります。 面の法線の向きは面の前面から離れる方向です。 Direct3D では、面の前面のみが表示されます。 前面は、頂点が時計回りの順序で定義されている面です。

次の図は、前面の法線ベクトルを示しています。

![前面の法線ベクトル](images/nrmlvect.png)

## <a name="span-idcullingbackfacesspanspan-idcullingbackfacesspanspan-idcullingbackfacesspanculling-back-faces"></a><span id="Culling_back_faces"></span><span id="culling_back_faces"></span><span id="CULLING_BACK_FACES"></span>背面のカリング


前面ではない面はすべて背面です。 Direct3D では、背面は常にレンダリングされるわけではありません。これを、背面がカリングされているといいます。 背面のカリングは、背面がレンダリングされなくなることを意味します。 必要に応じて、カリング モードを変更し、背面をレンダリングすることもできます。 詳細については、「[カリング ステート](https://msdn.microsoft.com/library/windows/desktop/bb204882)」を参照してください。

## <a name="span-idvertexunitnormalsspanspan-idvertexunitnormalsspanspan-idvertexunitnormalsspanvertex-unit-normals"></a><span id="Vertex_unit_normals"></span><span id="vertex_unit_normals"></span><span id="VERTEX_UNIT_NORMALS"></span>頂点の単位法線


Direct3D では、グーロー シェーディング、光源、テクスチャの効果に頂点の単位法線を使用します。

次の図は、頂点法線を示しています。

![頂点法線](images/vertnrml.png)

グーロー シェーディングを多角形に適用するとき、Direct3D では、頂点法線を使用して光源とサーフェスの間の角度が計算されます。 頂点の色と明るさの値が計算され、プリミティブのすべてのサーフェスで、すべてのポイントが補間されます。 Direct3D では、角度を使用して光の強さを計算します。 角度が大きいほど、サーフェスでの光の輝きは少なくなります。

## <a name="span-idflatsurfacesspanspan-idflatsurfacesspanspan-idflatsurfacesspanflat-surfaces"></a><span id="Flat_surfaces"></span><span id="flat_surfaces"></span><span id="FLAT_SURFACES"></span>平坦なサーフェス


平坦なオブジェクトを作成している場合は、サーフェスに対して垂線になるように頂点法線を設定します。

次の図は、頂点法線と 2 つの三角形から成る平坦なサーフェスを示しています。

![頂点法線と 2 つの三角形から成る平坦なサーフェス](images/flatvert.png)

## <a name="span-idsmoothshadingonanon-flatobjectspanspan-idsmoothshadingonanon-flatobjectspanspan-idsmoothshadingonanon-flatobjectspansmooth-shading-on-a-non-flat-object"></a><span id="Smooth_shading_on_a_non-flat_object"></span><span id="smooth_shading_on_a_non-flat_object"></span><span id="SMOOTH_SHADING_ON_A_NON-FLAT_OBJECT"></span>平坦ではないオブジェクト上のスムーズ シェーディング


オブジェクトは、平坦なオブジェクトではなく、三角形ストリップで構成されており、三角形が同一平面上にないことがほとんどです。 ストリップ内のすべての三角形でスムーズ シェーディングを実現するための最も簡単な方法の 1 つは、まず頂点が関連付けられている多角形の面ごとにサーフェスの法線ベクトルを計算することです。 頂点法線は、各サーフェスの法線と等しい角度になるように設定できます。 ただし、この方法は、複雑なプリミティブには十分に効率的でないことがあります。

この方法を次の図で説明します。この図は、上方から横向きに見た 2 つのサーフェス S1 および S2 を示しています。 S1 および S2 の法線ベクトルは青色で示されています。 頂点法線ベクトルは赤色で示されています。 頂点法線ベクトルが S1 のサーフェス法線となす角度は、頂点法線と S2 のサーフェス法線との間の角度と同じです。 これらの 2 つのサーフェスが、光で照らされ、グーロー シェーディングでシェーディングされると、結果として、これらのサーフェスの間のエッジは、滑らかにシェーディングされ、滑らかに丸みの付いたものになります。

次の図は、2 つのサーフェス (S1 と S2) とその法線ベクトルおよび頂点法線ベクトルを示しています。

![2 つのサーフェス (s1 と s2) とその法線ベクトルおよび頂点法線ベクトル](images/gvert.png)

頂点法線が、関連付けられた面のうちの 1 つに向かって傾いている場合、光の強度は、頂点法線が光源となす角度に応じて、そのサーフェス上の点に対して増加または減少します。 次の図に例を示します。 これらのサーフェスは横向きに見たものです。 頂点法線は S1 に向かって傾いており、頂点法線と各サーフェス法線との角度が等しい場合と比べて、光源との角度は小さくなっています。

次の図は、1 つの面に向かって傾いた頂点法線ベクトルを持つ 2 つのサーフェス (S1 と S2) を示しています。

![1 つの面に向かって傾いた頂点法線ベクトルを持つ 2 つのサーフェス (s1 と s2)](images/gvert2.png)

## <a name="span-idsharpedgesspanspan-idsharpedgesspanspan-idsharpedgesspansharp-edges"></a><span id="Sharp_edges"></span><span id="sharp_edges"></span><span id="SHARP_EDGES"></span>鋭いエッジ


グーロー シェーディングを使用すると、3D シーンで鋭いエッジを持つオブジェクトを表示できます。 そのためには、鋭いエッジが必要な面の交線で頂点法線ベクトルを重複させます。

次の図に、鋭いエッジで重複している頂点法線ベクトルを示します。

![鋭いエッジで重複している頂点法線ベクトル](images/shade1.png)

DrawPrimitive メソッドを使用してシーンをレンダリングする場合、鋭いエッジを持つオブジェクトは、三角形ストリップではなく三角形リストとして定義します。 三角形ストリップとしてオブジェクトを定義すると、Direct3D では、複数の三角形面から成る単一の多角形として処理されます。 グーロー シェーディングは、多角形の各面全体と、隣接する面の間の両方に適用されます。

結果として、オブジェクトは面から面へと滑らかにシェーディングされます。 三角形リストは一連の結合されていない三角形面から成る多角形であるため、Direct3D では、多角形の各面にグーロー シェーディングが適用されます。 ただし、面と面の間には適用されません。 三角形リストの 2 つ以上の三角形が隣接している場合、それらの間には鋭いエッジがあるように見えます。

別の方法としては、鋭いエッジを持つオブジェクトをレンダリングする場合は、フラット シェーディングに変更することです。 これは、計算上は最も効率的な方法ですが、シーンのオブジェクトは、グーロー シェーディングされたオブジェクトのようにはリアルにレンダリングされないことがあります。

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[座標系とジオメトリ](coordinate-systems-and-geometry.md)

 

 




