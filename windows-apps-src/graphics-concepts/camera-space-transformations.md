---
title: "カメラの空間変換"
description: "カメラ空間の頂点は、オブジェクトの頂点をワールド ビュー行列で変換することによって計算します。"
ms.assetid: 86EDEB95-8348-4FAA-897F-25251B32B076
keywords:
- "カメラの空間変換"
author: PeterTurcan
ms.author: pettur
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
translationtype: Human Translation
ms.sourcegitcommit: c6b64cff1bbebc8ba69bc6e03d34b69f85e798fc
ms.openlocfilehash: 478202cc8fd4f968539e3081edd6c6feddcec38b
ms.lasthandoff: 02/07/2017

---

# <a name="camera-space-transformations"></a>カメラの空間変換


カメラ空間の頂点は、オブジェクトの頂点をワールド ビュー行列で変換することによって計算します。

V = V \* wvMatrix

カメラ空間内の頂点の法線は、オブジェクトの法線をワールド ビュー行列の逆転置行列で変換することによって計算します。 ワールド ビュー行列は、正射影である場合とそうでない場合があります。

N = N \* (wvMatrix⁻¹)<sup>T</sup>

行列の逆変換と転置では、4 × 4 の行列を操作します。 乗算は、その結果得られる 4 × 4 行列の 3 × 3 部分と、法線とを結合します。

レンダリングの状態が法線の正規化に設定されている場合、頂点法線ベクトルはカメラ空間への変換の後、次のように正規化されます。

N = norm(N)

カメラ空間でのライトの位置は、光源の位置をビュー行列で変換することによって計算します。

Lₚ = Lₚ \* vMatrix

指向性ライトの場合、カメラ空間でのライトへの方向は、光源の方向をビュー行列で乗算し、その結果を正規化して正負を反転することによって計算します。

L<sub>dir</sub> = -norm(L<sub>dir</sub> \* wvMatrix)

ポイント ライトとスポット ライトの場合は、ライトへの方向は次のように計算します。

L<sub>dir</sub> = norm(V \* Lₚ) これらのパラメータの定義を次の表に示します。

| パラメーター       | 既定値 | 種類                                          | 説明                                               |
|-----------------|---------------|-----------------------------------------------|-----------------------------------------------------------|
| L<sub>dir</sub> | なし           | 3D ベクトル (x、y、z 浮動小数点値) | オブジェクトの頂点からライトへの方向ベクトル          |
| V               | なし           | 3D ベクトル (x、y、z 浮動小数点値) | カメラ空間での頂点の位置                           |
| wvMatrix        | ID      | 浮動小数点値の 4 x 4 マトリックス           | ワールドとビューの変換を含む合成行列 |
| N               | なし           | 3D ベクトル (x、y、z 浮動小数点値) | 頂点法線                                             |
| Lₚ              | なし           | 3D ベクトル (x、y、z 浮動小数点値) | カメラ空間でのライトの位置                            |
| vMatrix         | ID      | 浮動小数点値の 4 x 4 マトリックス           | ビュー変換を含む行列                      |

 

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連項目


[光源の計算](mathematics-of-lighting.md)

 

 





