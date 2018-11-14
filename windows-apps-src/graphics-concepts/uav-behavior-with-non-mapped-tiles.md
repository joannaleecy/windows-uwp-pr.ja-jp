---
title: マップされていないタイルでの UAV 動作
description: 順序指定されていないアクセス ビュー (UAV) の読み取りと書き込みの動作は、ハードウェア サポートのレベルによって異なります。
ms.assetid: CDB224E2-CC07-4568-9AAC-C8DC74536561
keywords:
- マップされていないタイルでの UAV 動作
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: a5418de3646f70a815f5c482f9063ea3e48ddfa1
ms.sourcegitcommit: 4d88adfaf544a3dab05f4660e2f59bbe60311c00
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/12/2018
ms.locfileid: "6443229"
---
# <a name="span-iddirect3dconceptsuavbehaviorwithnon-mappedtilesspanuav-behavior-with-non-mapped-tiles"></a><span id="direct3dconcepts.uav_behavior_with_non-mapped_tiles"></span>マップされていないタイルでの UAV 動作


順序指定されていないアクセス ビュー (UAV) の読み取りと書き込みの動作は、ハードウェア サポートのレベルによって異なります。 要件について詳しくは、「[ストリーミング リソース機能の階層](streaming-resources-features-tiers.md)」の全体の読み取りと書き込みの動作をご覧ください。 このセクションでは、望ましい動作について概説します。

UAV 内のマップされていないタイルから読み取りを行うシェーダー操作は、形式の欠落していないすべてのコンポーネントでは 0 を返し、欠落しているコンポーネントでは既定値を返します。

マップされていないタイルへの書き込みを試みるシェーダー操作では、マップされていない領域には何も書き込みません (マップされた領域への書き込みは続行されます)。 書き込み処理に関するこの理想的な定義は、[階層 2](tier-2.md) では求められません。マップされていないタイルへの書き込みは最終的にキャッシュに格納され、その後の読み取りで取得される可能性があります。

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[ストリーミング リソースへのパイプライン アクセス](pipeline-access-to-streaming-resources.md)

 

 




