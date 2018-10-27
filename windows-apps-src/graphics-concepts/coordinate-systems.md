---
title: 座標系
description: 通常、3D グラフィック アプリケーションでは、2 種類のデカルト座標系、つまり左手系と右手系が使用されます。 いずれの座標系においても、x 軸の正の向きは右を指し、y 軸の正の向きは上を指します。
ms.assetid: 138D9B81-146F-4E9F-B742-1EDED8FBF2AE
keywords:
- 座標系
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 1b8faed0719419d4be8ac1e5d493610ec2660598
ms.sourcegitcommit: 086001cffaf436e6e4324761d59bcc5e598c15ea
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/27/2018
ms.locfileid: "5696688"
---
# <a name="coordinate-systems"></a>座標系


通常、3D グラフィック アプリケーションでは、2 種類のデカルト座標系、つまり左手系と右手系が使用されます。 いずれの座標系においても、x 軸の正の向きは右を指し、y 軸の正の向きは上を指します。

## <a name="span-idleftandrighthandedcoordinatesspanspan-idleftandrighthandedcoordinatesspanspan-idleftandrighthandedcoordinatesspanleft-and-right-handed-coordinates"></a><span id="Left_and_right_handed_coordinates"></span><span id="left_and_right_handed_coordinates"></span><span id="LEFT_AND_RIGHT_HANDED_COORDINATES"></span>左手と右手の座標系


どちらの方向を z 軸の正の向きが指しているかは、左手または右手の指で x 軸の正の向きを指し、指を y 軸の正の向きに曲げることによって、思い出すことができます。 親指が指している方向は、自身に向かうかまたは離れる方向のいずれかとなり、その座標系の z 軸の正の向きが指す方向となります。 次の図は、これらの 2 つの座標系を示しています。

![左手と右手によるデカルト座標系の図](images/leftrght.png)

Direct3D は、左手座標系を使用します。 左手および右手座標が最も一般的な座標系ですが、さまざまな他の座標系が 3D ソフトウェアで使用されています。 たとえば、y 軸がビューアーに向かうかまたはビューアーから離れる方向を指し、かつ z 軸が上を指す座標系を使用することも、3D モデリング アプリケーションでは珍しくはありません。

## <a name="span-idverticesandvectorsspanspan-idverticesandvectorsspanspan-idverticesandvectorsspanvertices-and-vectors"></a><span id="Vertices_and_vectors"></span><span id="vertices_and_vectors"></span><span id="VERTICES_AND_VECTORS"></span>頂点とベクトル


座標系が与えられると、x、y、z 座標を使って空間の点 (「頂点」) および 3D 方向 (「ベクトル」) を定義することができます。

頂点の集合は、線と図形を定義するために使用できます。 頂点によって定義可能な最も単純なオブジェクトは[プリミティブ](primitives.md)と呼ばれ、プリミティブのセットによって定義される、より複雑なオブジェクトは「メッシュ」と呼ばれます。

3D 座標系で定義されたメッシュに対して実行される基本的な操作は、移動、回転、拡大縮小です。 これらの基本的な変換を組み合わせて、変換マトリックスを作成することができます。 詳しくは、「[変換](transforms.md)」をご覧ください。

これらの演算を組み合わせると、結果は非可換です。行列を乗算する順序が重要です。

## <a name="span-idportingfromaright-handedcoordinatesystemspanspan-idportingfromaright-handedcoordinatesystemspanspan-idportingfromaright-handedcoordinatesystemspanporting-from-a-right-handed-coordinate-system"></a><span id="Porting_from_a_right-handed_coordinate_system"></span><span id="porting_from_a_right-handed_coordinate_system"></span><span id="PORTING_FROM_A_RIGHT-HANDED_COORDINATE_SYSTEM"></span>右手座標系からの移植


右手座標系に基づいたアプリケーションを移植する場合、Direct3D に渡すデータに 2 つの変更を行う必要があります。

-   三角形頂点の順序を反転させて、システムがそれらの三角形頂点を正面から時計方向にトラバースするようにします。 つまり、頂点が v0、v1、v2 とすると、それらを Direct3D に v0、v2、v1 として渡します。
-   ビュー行列を使用し、ワールド空間で z 方向に -1 のスケーリングを適用します。 そのためには、ビュー行列に使用している行列構造体の \_31、\_32、\_33、\_34 メンバーの符号を反転させます。

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[座標系とジオメトリ](coordinate-systems-and-geometry.md)

 

 




