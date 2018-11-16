---
title: モノクロ ライト マップ
description: モノクロ ライト マップを使うと、古い 3D アクセラレータ ボードが宛先ピクセルのアルファ値を使ったテクスチャ ブレンドをサポートしていない場合に、古いアダプターでもマルチパス テクスチャ ブレンドを実行できます。
ms.assetid: 60F8F8F6-9DB7-452B-8DC0-407FFAA4BFE1
keywords:
- モノクロ ライト マップ
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 72bea3badb19991883e2a6cc62463ab2dc58ec4a
ms.sourcegitcommit: e2fca6c79f31e521ba76f7ecf343cf8f278e6a15
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/16/2018
ms.locfileid: "6994065"
---
# <a name="monochrome-light-maps"></a>モノクロ ライト マップ


モノクロ ライト マップを使うと、古い 3D アクセラレータ ボードが宛先ピクセルのアルファ値を使ったテクスチャ ブレンドをサポートしていない場合に、古いアダプターでもマルチパス テクスチャ ブレンドを実行できます。

一部の古い 3D アクセラレータ ボードは、宛先ピクセルのアルファ値を使ったテクスチャ ブレンドをサポートしていません。 これらのアダプターは多くの場合、複数テクスチャ ブレンドもサポートしていません。 アプリケーションがこのようなアダプターで実行されている場合、マルチパス テクスチャ ブレンドを使ってモノクロ ライト マッピングを実行できます。

モノクロ ライト マッピングを実行するため、アプリケーションはライト マップ テクスチャのアルファ データに照明情報を格納します。 アプリケーションは、Direct3D のテクスチャ フィルタリング機能を使って、プリミティブのイメージ内の各ピクセルからライト マップ内の対応するテクセルへのマッピングを実行します。 また、ソース ブレンド要素を対応するテクセルのアルファ値に設定します。

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[テクスチャでのライト マッピング](light-mapping-with-textures.md)

 

 




