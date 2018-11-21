---
title: シェーダー リソース ビュー (SRV) と順序指定されていないアクセス ビュー (UAV)
description: シェーダー リソース ビューは、通常、シェーダーがアクセスできる形式でテクスチャをラップします。 順序指定されていないアクセス ビューも同様の機能を提供しますが、任意の順序で、テクスチャ (やその他のリソース) の読み取りや書き込みを行うことができます。
ms.assetid: 4505BCD2-0EDA-40F2-887C-EC081FE32E8F
keywords:
- シェーダー リソース ビュー (SRV)
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: e98b9942dfc14604c061a036cd3c9803abaf3915
ms.sourcegitcommit: cbe7cf620622a5e4df7414f9e38dfecec1cfca99
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/20/2018
ms.locfileid: "7431486"
---
# <a name="shader-resource-view-srv-and-unordered-access-view-uav"></a>シェーダー リソース ビュー (SRV) と順序指定されていないアクセス ビュー (UAV)


シェーダー リソース ビューは、通常、シェーダーがアクセスできる形式でテクスチャをラップします。 順序指定されていないアクセス ビューも同様の機能を提供しますが、任意の順序で、テクスチャ (やその他のリソース) の読み取りや書き込みを行うことができます。

テクスチャを 1 つだけラップするのが、おそらく最もシンプルなシェーダー リソース ビューの形です。 より複雑な例としては、サブリソース (ミップマップ テクスチャの個々の配列、プレーン、または色)、3D テクスチャ、1D テクスチャのグラデーションなどのコレクションがあります。

順序指定されていないアクセス ビューは、パフォーマンスの面ではややコストが高くなりますが、たとえばテクスチャの読み取りと同時に書き込みをすることができます。 そのため、更新されたテクスチャをグラフィック パイプラインによって他の目的に再利用できます。 シェーダー リソース ビューは、読み取り専用です (これは、最も一般的なリソースの使い方です)。

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[ビュー](views.md)

 

 




