---
title: マップされていないタイルでのラスタライザー動作
description: このセクションでは、マップされていないタイルを使用したラスタライザー動作について説明します。
ms.assetid: AC7B818D-E52B-4727-AEA2-39CFDC279CE7
keywords:
- マップされていないタイルでのラスタライザー動作
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: f56e8051c8a66cf579a7c3dbcddc738b3a10bcaf
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/02/2018
ms.locfileid: "5937849"
---
# <a name="span-iddirect3dconceptsrasterizerbehaviorwithnon-mappedtilesspanrasterizer-behavior-with-non-mapped-tiles"></a><span id="direct3dconcepts.rasterizer_behavior_with_non-mapped_tiles"></span>マップされていないタイルでのラスタライザー動作


このセクションでは、マップされていないタイルを使用したラスタライザー動作について説明します。

## <a name="span-iddepthstencilviewspanspan-iddepthstencilviewspanspan-iddepthstencilviewspandepthstencilview"></a><span id="DepthStencilView"></span><span id="depthstencilview"></span><span id="DEPTHSTENCILVIEW"></span>DepthStencilView


深度ステンシル ビュー (DSV) の読み取りと書き込みの動作は、ハードウェア サポートのレベルによって異なります。 要件について詳しくは、「[ストリーミング リソース機能の階層](streaming-resources-features-tiers.md)」の全体の読み取りと書き込みの動作をご覧ください。

最適な動作を次に示します。

DepthStencilView でタイルがマップされていない場合、深度の読み取りによる戻り値は 0 です。その後、この値が、深度の読み取り値に対して構成されたすべての処理に渡されます。 存在しない深度タイルへの書き込みは破棄されます。 書き込み処理について、このような最適な定義は[階層 2](tier-2.md) では必要ありません。マップされていないタイルへの書き込みは最終的にキャッシュに格納され、その後の読み取りではこのキャッシュが取得される可能性があります。

## <a name="span-idrendertargetviewspanspan-idrendertargetviewspanspan-idrendertargetviewspanrendertargetview"></a><span id="RenderTargetView"></span><span id="rendertargetview"></span><span id="RENDERTARGETVIEW"></span>RenderTargetView


レンダー ターゲット ビュー (RTV) の読み取りと書き込みの動作は、ハードウェア サポートのレベルによって異なります。 要件について詳しくは、「[ストリーミング リソース機能の階層](streaming-resources-features-tiers.md)」の全体の読み取りと書き込みの動作をご覧ください。

すべての実装において、異なる RTV (および DSV) が同時にバインドされると、さまざまな領域でマップされた領域とマップされていない領域が発生し、さまざまなサイズのサーフェス形式 (つまり、さまざまなタイルの形状) が生じる可能性があります。

最適な動作を次に示します。

RTV からの読み取りでは、存在しないタイルにおいては 0 が返され、書き込みが破棄されます。 書き込み処理について、このような最適な定義は[階層 2](tier-2.md) では必要ありません。マップされていないタイルへの書き込みは最終的にキャッシュに格納され、その後の読み取りではこのキャッシュが取得される可能性があります。

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[ストリーミング リソースへのパイプライン アクセス](pipeline-access-to-streaming-resources.md)

 

 




