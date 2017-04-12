---
title: "マップされていないタイルでの SRV 動作"
description: "マップされていないタイルに関連するシェーダー リソース ビュー (SRV) の読み取り動作は、ハードウェア サポートのレベルによって異なります。"
ms.assetid: 0E1D64BE-EB09-4F9D-9800-BD23A3B374EE
keywords: "マップされていないタイルでの SRV 動作"
author: PeterTurcan
ms.author: pettur
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.openlocfilehash: e6c4334446ef3bc302602d0b59b81164c9a28f3d
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="span-iddirect3dconceptssrvbehaviorwithnon-mappedtilesspansrv-behavior-with-non-mapped-tiles"></a><span id="direct3dconcepts.srv_behavior_with_non-mapped_tiles"></span>マップされていないタイルでの SRV 動作


マップされていないタイルに関連するシェーダー リソース ビュー (SRV) の読み取り動作は、ハードウェア サポートのレベルによって異なります。 要件について詳しくは、「[ストリーミング リソース機能の階層](streaming-resources-features-tiers.md)」の読み取りの動作をご覧ください。 このセクションでは、[階層 2](tier-2.md) に必要な望ましい動作について概説します。

SRV 内の一連のテクセルから読み取るテクスチャ フィルター操作について考えます。 マップされているテクセルからの値の他、マップされていないタイルに適用されるテクセルからは、全体的なフィルター操作に対して、形式のコンポーネントのうち欠落していないものには 0 (欠落しているものには既定値) を返します。 データの提供元のタイルがマップされているかどうかを問わず、すべてのテクセルに重みが付けられ、組み合わされます。

一部の第一世代の[階層 2](tier-2.md) レベルのハードウェアはこの仕様要件を満たしていないため、いずれかのテクセル (0 以外の重み付き) がマップされていないタイルに適用される場合、全体のフィルター処理の結果として事前に記述されている既定値と併せて 0 を返します。 その他のハードウェアでは、すべての (0 以外の重み付きの) テクセルをフィルターに含めるには、必ず要件を満たす必要があります。

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[ストリーミング リソースへのパイプライン アクセス](pipeline-access-to-streaming-resources.md)

 

 




