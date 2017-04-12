---
author: drewbatgit
ms.assetid: 3E0FBB43-F6A4-4558-AA89-20E7760BA73F
description: "この記事では、UWP アプリでサポートされる Dynamic Adaptive Streaming over HTTP (DASH) プロファイルの一覧を示します。"
title: "Dynamic Adaptive Streaming over HTTP (DASH) プロファイルのサポート"
ms.author: drewbat
ms.date: 02/15/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 9ca8f2d1783a73ae38fed1d3ee1e58b809ddd2aa
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="dynamic-adaptive-streaming-over-http-dash-profile-support"></a>Dynamic Adaptive Streaming over HTTP (DASH) プロファイルのサポート
次の表では、UWP アプリでサポートされている DASH プロファイルを示します。



|タグ | マニフェストの種類 | 説明|7 月にリリースされた Windows 10|Windows 10 バージョン 1511|Windows 10 バージョン 1607 |Windows 10 バージョン 1607 |Windows 10 バージョン 1703|
|----------------|------|-------|-----------|--------------|---------|-------|--------|
|urn:mpeg:dash:profile:isoff-live:2011 | 静的 |     |サポートされる            |  サポートされる              | サポートされる        |サポートされる| サポートされる|
|urn:mpeg:dash:profile:isoff-main:2011 |        | ベスト エフォート | サポートされる            |  サポートされる              | サポートされる        |サポートされる| サポートされる|
|urn:mpeg:dash:profile:isoff-live:2011 | 動的 | セグメント テンプレートで $Time$ はサポートされていますが、$Number$ はサポートされていません。 | サポートされない            | サポートされない              | サポートされない        |サポートされない| サポートされる|


## <a name="related-topics"></a>関連トピック

* [メディア再生](media-playback.md)
* [アダプティブ ストリーミング](adaptive-streaming.md)
 

 




