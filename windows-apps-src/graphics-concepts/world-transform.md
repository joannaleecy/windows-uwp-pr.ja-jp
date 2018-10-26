---
title: ワールド変換
description: ワールド変換は、座標系をモデル空間からワールド空間に変更します。モデル空間では、頂点はモデルのローカル原点を基準として相対的に定義されます。
ms.assetid: 767B032C-69D0-4583-8FEB-247F4C41E31D
keywords:
- ワールド変換
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 9c6ada4bd964a9430d6ef47bd46f954ca76c404a
ms.sourcegitcommit: 6cc275f2151f78db40c11ace381ee2d35f0155f9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5565130"
---
# <a name="world-transform"></a>ワールド変換


ワールド変換は、座標系をモデル空間からワールド空間に変更します。モデル空間では、頂点はモデルのローカル原点を基準として相対的に定義されます。 ワールド空間では、頂点はシーン内のすべてのオブジェクトに共通の原点を基準として相対的に定義されます。 ワールド変換は、モデルをワールド空間に配置します。

## <span id="What_Is_a_World_Transform"></span><span id="what_is_a_world_transform"></span><span id="WHAT_IS_A_WORLD_TRANSFORM"></span>


次の図は、ワールド座標系とモデルのローカル座標系の関係を示しています。

![ワールド座標とローカル座標の関係を示す図](images/worldcrd.png)

ワールド変換には、平行移動、回転、スケーリングを任意に組み合わせて含めることができます。

## <a name="span-idsettingupaworldmatrixxmlspansetting-up-a-world-matrix"></a><span id="SETTING_UP_A_WORLD_MATRIX.XML"></span>ワールド行列の設定


ワールド変換を作成するには、他の変換と同様に、複数の行列を組み合わせて、それらの効果をすべて含む 1 つの行列に連結します。 最も単純な例として、モデルがワールド原点に位置し、そのローカル座標軸がワールド空間と同じ方向であるとすると、ワールド行列は単位行列になります。 より一般的な例でのワールド行列は、ワールド空間への平行移動と、必要に応じてモデルを回転させる 1 つ以上の回転の組み合わせになります。

Direct3D は、ユーザーが設定したワールド行列とビュー行列を使って、いくつかの内部データ構造を構成します。 新しいワールド行列またはビュー行列を設定するたびに、関連付けられた内部構造がシステムによって再計算されます。 これらの行列を頻繁に、たとえばフレーム当たりに数千回という頻度で設定すると、計算に時間を要することになります。 必要な計算回数を最小限に抑えるには、ワールド行列とビュー行列を連結して 1 つのワールド ビュー行列を作成し、それをワールド行列として設定した後、ビュー行列を単位元に設定します。 このとき、必要に応じてワールド行列を変更、連結、リセットできるように、個々のワールド行列とビュー行列のキャッシュ コピーを保持しておくことをお勧めします。

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[変換](transforms.md)

 

 




