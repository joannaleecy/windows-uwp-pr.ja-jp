---
title: ビューポートとクリッピング
description: ビューポートとは、3D シーンが投影される 2 次元 (2D) の四角形です。
ms.assetid: D0DD646E-13AE-452A-AD22-8C35000D0BA9
keywords:
- ビューポートとクリッピング
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 4dd319c686bebf2a30431017f399f48b08618cb6
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/29/2018
ms.locfileid: "5749960"
---
# <a name="viewports-and-clipping"></a>ビューポートとクリッピング


"ビューポート**" とは、3D シーンが投影される 2 次元 (2D) の矩形です。 Direct3D では、この四角形は Direct3D サーフェス内の座標として存在し、システムによってレンダー ターゲットとして使われます。 射影変換は、頂点をビューポートで使われる座標系に変換します。 ビューポートは、シーンがレンダリングされるレンダー ターゲット サーフェス上の深度値の範囲 (通常は 0.0 ～ 1.0) を指定するためにも使われます。

## <a name="span-idtheviewingfrustumspanspan-idtheviewingfrustumspanspan-idtheviewingfrustumspanthe-viewing-frustum"></a><span id="The_Viewing_Frustum"></span><span id="the_viewing_frustum"></span><span id="THE_VIEWING_FRUSTUM"></span>視錐台


視錐台とは、ビューポートのカメラに対して相対的に配置された、シーン内の 3D ボリュームです。 カメラ空間から画面にモデルがどのように投影されるかは、このボリュームの形に影響されます。 最も一般的な種類の投影である透視投影では、カメラの近くにあるオブジェクトを、離れた位置のオブジェクトよりも大きく表示します。 透視ビューの場合、視錐台は先端にカメラのある四角錐と考えることができます。これを図で表すと次のようになります。 この四角錐は、前方および後方のクリッピング面と交差します。 四角錐を前方と後方のクリッピング面で切り取ったボリュームが、視錐台です。 オブジェクトは、このボリュームの内部にある場合にのみ表示されます。

![視錐台と前方および後方のクリッピング面を表した図](images/frustum.png)

暗い部屋に立って正方形の窓から外を眺めたところを想像すると、視錐台のイメージがよくわかります。 この例では、前方のクリッピング面は窓であり、後方のクリッピング面は視界を最終的に遮るものになります。たとえば、道路の向こうにある高層ビルや、遠くに見える山並みの場合もあれば、何もない場合もあります。 四角錐の窓から視界を遮るものまでの間を切り取った内部はすべて見渡すことができ、それ以外の部分は何も見えません。

視錐台は、fov (視野) と、z 座標で指定される前方クリッピング面と後方クリッピング面の間の距離によって定義されます。これを次の図に示します。

![視錐台の図](images/fovdiag.png)

この図において変数 D は、カメラから、ジオメトリ パイプラインの直前の部分 (ビュー変換) で定義された空間の原点までの距離を表します。 この空間の周りに視錐台の限界を設定します。 この変数 D が射影行列の構築時にどのように使われるかについては、「[射影変換](projection-transform.md)」をご覧ください。

## <a name="span-idviewportrectanglespanspan-idviewportrectanglespanspan-idviewportrectanglespanviewport-rectangle"></a><span id="Viewport_Rectangle"></span><span id="viewport_rectangle"></span><span id="VIEWPORT_RECTANGLE"></span>ビューポート矩形


ビューポート構造体には、シーンのレンダリング先となるレンダー ターゲット サーフェスの領域を定義する 4 つのメンバー (X、Y、Width、Height) が含まれています。 これらの値は、次の図に示すように、出力先の四角形、つまりビューポート矩形に対応します。

![ビューポート矩形の図](images/destrect.png)

X、Y、Width、Height の各メンバーに指定する値は、レンダー ターゲット サーフェスの左上隅を基準とした相対的なスクリーン座標です。 構造体には他に、シーンがレンダリングされる深度範囲を示す 2 つのメンバー (MinZ と MaxZ) も定義されています。

Direct3D では、ビューポートのクリッピング ボリュームの範囲として、X は -1.0 ～ 1.0、Y は 1.0 ～ -1.0 を想定しています。これらは、過去のアプリケーションで最もよく使われた設定です。 クリッピングの前に[射影変換](projection-transform.md)を使うことで、ビューポートの縦横比を調整できます。

**注:**  MinZ と MaxZ にシーンがレンダリングされる深度範囲を示すし、クリッピングは使われません。 ほとんどのアプリケーションでは、システムが深度バッファー内の深度値の範囲全体をレンダリングできるように、これらの値を 0.0 と 1.0 に設定します。 場合によっては、他の深度範囲を使って特殊効果を実現することもできます。 たとえば、ゲームのヘッドアップ ディスプレイをレンダリングする場合、両方の値を 0.0 に設定すると、シーン内のオブジェクトを強制的に前面にレンダリングできます。または、両方を 1.0 に設定すると、常に背面に置く必要のあるオブジェクトをレンダリングできます。

 

ビューポート構造体の X、Y、Width、Height の各メンバーで使われる寸法は、レンダー ターゲット サーフェス上のビューポートの位置とサイズを定義します。 これらの値は、サーフェスの左上隅を基準とした相対的なスクリーン座標を示します。

Direct3D は、ビューポートの位置とサイズを使って頂点をスケーリングし、レンダリングするシーンをターゲット サーフェス上の適切な位置に配置します。 Direct3D の内部では、これらの値が次の行列に挿入され、各頂点に適用されます。

![各頂点に適用される行列](images/vpscale.png)

この行列は、ビューポートのサイズと指定の深度範囲に従って頂点をスケーリングし、レンダー ターゲット サーフェスの適切な位置に平行移動します。 また、この行列は、左上隅のスクリーン原点から y を下方へ増やした位置を反映するように y 軸を反転します。 この行列が適用された後も、頂点は同次です。つまり、各頂点は引き続き \[x,y,z,w\] 頂点として存在するため、ラスタライザーに送信する前に非同次の座標に変換する必要があります。

**注:** アプリケーション通常 MinZ と MaxZ を設定 0.0 と 1.0 それぞれに、システムに深度範囲全体をレンダリングします。 ただし、他の値を使って特定の効果を得ることもできます。 たとえば、両方の値を 0.0 に設定してすべてのオブジェクトを強制的に前面に配置したり、両方を 1.0 に設定してすべてのオブジェクトを背面にレンダリングしたりできます。

 

## <a name="span-idclearingaviewportspanspan-idclearingaviewportspanspan-idclearingaviewportspanclearing-a-viewport"></a><span id="Clearing_a_Viewport"></span><span id="clearing_a_viewport"></span><span id="CLEARING_A_VIEWPORT"></span>ビューポートのクリア


ビューポートをクリアすると、レンダー ターゲット サーフェス上のビューポート矩形の内容がリセットされます。 さらに、深度バッファー サーフェスとステンシル バッファー サーフェスの矩形もクリアできます。

## <a name="span-idsetuptheviewportforclippingspanspan-idsetuptheviewportforclippingspanspan-idsetuptheviewportforclippingspanset-up-the-viewport-for-clipping"></a><span id="Set_Up_the_Viewport_for_Clipping"></span><span id="set_up_the_viewport_for_clipping"></span><span id="SET_UP_THE_VIEWPORT_FOR_CLIPPING"></span>ビューポートのクリッピングの設定


射影行列の結果によって、次のように射影空間のクリッピング ボリュームが決まります。

-w<sub>c</sub>&lt;= x<sub>c</sub>&lt;= w<sub>c</sub>

-w<sub>c</sub>&lt;= y<sub>c</sub>&lt;= w<sub>c</sub>

0 &lt;= z<sub>c</sub>&lt;= w<sub>c</sub>

x、y、z、w は、射影変換が適用された後の頂点の座標を表します。 クリッピングが有効な場合 (既定の動作)、x、y、z の各要素がこれらの範囲外にある頂点はすべてクリッピングされます。

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[座標系とジオメトリ](coordinate-systems-and-geometry.md)

 

 




