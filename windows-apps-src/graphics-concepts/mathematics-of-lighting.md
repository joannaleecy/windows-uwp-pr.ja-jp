---
title: 光源の計算
description: Direct3D の照明モデルは、環境光、拡散光、反射光、放射光を扱います。 これにより、さまざまな照明の状況に十分対応することができます。 シーン内の照明の合計量は、全体照明と呼ばれます。
ms.assetid: D0521F56-050D-4EDF-9BD1-34748E94B873
keywords:
- 光源の計算
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 19734964c9b4ab087f7d5fd6ea749b57cccce26c
ms.sourcegitcommit: f2c9a050a9137a473f28b613968d5782866142c6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/09/2018
ms.locfileid: "6255144"
---
# <a name="mathematics-of-lighting"></a>光源の計算


Direct3D の照明モデルは、環境光、拡散光、反射光、放射光を扱います。 これにより、さまざまな照明の状況に十分対応することができます。 シーン内の照明の合計量は、*全体照明*と呼ばれます。

全体照明は次のように計算されます。

```
Global Illumination = Ambient Light + Diffuse Light + Specular Light + Emissive Light 
```

[環境光](ambient-lighting.md)は一定の照明です。 環境光は、すべての方向において一定であり、オブジェクトのすべてのピクセルが同じように色付けされます。 すぐに計算されますが、オブジェクトは平面的で非現実的なままです。

[拡散光](diffuse-lighting.md)は、光の方向とオブジェクト サーフェスの法線の両方によって決まります。 光の方向を変更し、サーフェスの法線ベクトルを変更すると、拡散光がオブジェクトのサーフェス上で変化します。 オブジェクト頂点ごとに変化するため、拡散光の方が計算に時間がかかりますが、オブジェクトに陰影が付き、3 次元 (3D) の奥行きが出るというメリットがあります。

[反射光](specular-lighting.md)では、光がオブジェクトの表面に当たり、カメラに向かって反射する明るい反射光を指定します。 反射光は拡散光よりも強い光で、オブジェクトの表面から短時間で消えます。 反射光の方が拡散光よりも計算に時間がかかりますが、反射光を使用すると、表面の表現力が格段に向上します。

[放射光](emissive-lighting.md)は、オブジェクトにより放射される光 (輝きなど) です。 放射によって、レンダリングされるオブジェクトが自己発光しているように見えます。 放射は、オブジェクトの色に影響を与え、たとえば、暗い素材を明るくしたり、放射される色の一部を引き受けたりすることができます。

現実的な光は、これらの種類の光をそれぞれ 3D シーンに適用することによって実現できます。 環境、放射、および拡散コンポーネントに計算される値は、拡散頂点の色として出力されます。鏡面反射コンポーネントの値は、反射頂点の色として出力されます。 環境光、拡散光、反射光の値は、特定の光の減衰とスポットライト要素の影響を受けます。 「[減衰とスポットライト係数](attenuation-and-spotlight-factor.md)」を参照してください。

より現実的な照明効果を出すため、多くの照明を追加できますが、シーンのレンダリングに時間がかかります。 デザイナーが望むすべての効果を出すため、一部のゲームでは一般に使われているより多くの CPU 能力を使っています。 この場合、テクスチャ マップを使うと同時に照明マップと環境マップを使ってシーンに照明を追加することにより、照明計算の数を最小限に減らすのが一般的です。

照明は、カメラ空間で計算されます。 「[カメラの空間変換](camera-space-transformations.md)」をご覧ください。 法線ベクトルが既に正規化されていて、頂点ブレンドが必要なく、変換マトリックスが直角であるという特殊な条件が存在する場合、最適化された照明をモデル空間で計算できます。

すべての照明計算は、ワールド マトリックスの逆数を使って、カメラ位置と共に光源の位置と方向をモデル空間に変換することにより、モデル空間で行われます。 そのため、ワールド マトリックスとビュー マトリックスに不均一なスケーリングが導入されている場合、結果として生じる照明が不正確になることがあります。

## <a name="span-idin-this-sectionspanin-this-section"></a><span id="in-this-section"></span>このセクションの内容


<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">トピック</th>
<th align="left">説明</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><a href="ambient-lighting.md">環境光</a></p></td>
<td align="left"><p>環境光は、シーンに一定のライティングを付加します。 頂点法線、光の方向、光の位置、減衰などの他の照明要素に依存していないため、すべてのオブジェクト頂点を同じように照らします。 環境光は、すべての方向において一定であり、オブジェクトのすべてのピクセルが同じように色付けされます。 すぐに計算されますが、オブジェクトは平面的で非現実的なままです。</p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="diffuse-lighting.md">拡散光</a></p></td>
<td align="left"><p><em>拡散光</em>は、ライトの方向とオブジェクトのサーフェス法線の両方に依存します。 光の方向を変更し、サーフェスの法線ベクトルを変更すると、拡散光がオブジェクトのサーフェス上で変化します。 オブジェクト頂点ごとに変化するため、拡散光の方が計算に時間がかかりますが、オブジェクトに陰影が付き、3 次元 (3D) の奥行きが出るというメリットがあります。</p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="specular-lighting.md">反射光</a></p></td>
<td align="left"><p><em>反射光</em>では、光がオブジェクトの表面に当たり、カメラに向かって反射する明るい反射光を指定します。 反射光は拡散光よりも強い光で、オブジェクトの表面から短時間で消えます。 反射光の方が拡散光よりも計算に時間がかかりますが、反射光を使用すると、表面の表現力が格段に向上します。</p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="emissive-lighting.md">放射光</a></p></td>
<td align="left"><p><em>放射光</em>は、白熱光などオブジェクトによって放射される光です。 放射によって、レンダリングされるオブジェクトが自己発光しているように見えます。 放射は、オブジェクトの色に影響を与え、たとえば、暗い素材を明るくしたり、放射される色の一部を引き受けたりすることができます。</p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="camera-space-transformations.md">カメラの空間変換</a></p></td>
<td align="left"><p>カメラ空間内の頂点は、ワールド ビュー マトリックスによってオブジェクト頂点を変換することにより計算されます。</p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="attenuation-and-spotlight-factor.md">減衰とスポットライトの要素</a></p></td>
<td align="left"><p>全体照明の方程式の拡散光および反射光コンポーネントには、光の減衰とスポットライト コーンを表す項が含まれています。</p></td>
</tr>
</tbody>
</table>

 

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[照明および素材](lights-and-materials.md)

 

 




