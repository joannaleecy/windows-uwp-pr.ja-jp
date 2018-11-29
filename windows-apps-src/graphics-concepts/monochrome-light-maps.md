---
title: モノクロ ライト マップ
description: モノクロ ライト マップを使うと、古い 3D アクセラレータ ボードが宛先ピクセルのアルファ値を使ったテクスチャ ブレンドをサポートしていない場合に、古いアダプターでもマルチパス テクスチャ ブレンドを実行できます。
ms.assetid: 60F8F8F6-9DB7-452B-8DC0-407FFAA4BFE1
keywords:
- モノクロ ライト マップ
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: b81838393d7b2692e6fd04b7ce535f58dc773780
ms.sourcegitcommit: b5c9c18e70625ab770946b8243f3465ee1013184
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/29/2018
ms.locfileid: "7982920"
---
# <a name="monochrome-light-maps"></a>モノクロ ライト マップ


モノクロ ライト マップを使うと、古い 3D アクセラレータ ボードが宛先ピクセルのアルファ値を使ったテクスチャ ブレンドをサポートしていない場合に、古いアダプターでもマルチパス テクスチャ ブレンドを実行できます。

一部の古い 3D アクセラレータ ボードは、宛先ピクセルのアルファ値を使ったテクスチャ ブレンドをサポートしていません。 これらのアダプターは多くの場合、複数テクスチャ ブレンドもサポートしていません。 アプリケーションがこのようなアダプターで実行されている場合、マルチパス テクスチャ ブレンドを使ってモノクロ ライト マッピングを実行できます。

モノクロ ライト マッピングを実行するため、アプリケーションはライト マップ テクスチャのアルファ データに照明情報を格納します。 アプリケーションは、Direct3D のテクスチャ フィルタリング機能を使って、プリミティブのイメージ内の各ピクセルからライト マップ内の対応するテクセルへのマッピングを実行します。 また、ソース ブレンド要素を対応するテクセルのアルファ値に設定します。

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[テクスチャでのライト マッピング](light-mapping-with-textures.md)

 

 




