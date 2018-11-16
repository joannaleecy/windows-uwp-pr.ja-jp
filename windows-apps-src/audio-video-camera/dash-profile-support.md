---
author: drewbatgit
ms.assetid: 3E0FBB43-F6A4-4558-AA89-20E7760BA73F
description: この記事では、UWP アプリでサポートされる Dynamic Adaptive Streaming over HTTP (DASH) プロファイルの一覧を示します。
title: Dynamic Adaptive Streaming over HTTP (DASH) プロファイルのサポート
ms.author: drewbat
ms.date: 02/15/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 7a4ec9f9e81010d39af496da156afa676f4b3714
ms.sourcegitcommit: e38b334edb82bf2b1474ba686990f4299b8f59c7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/15/2018
ms.locfileid: "6837845"
---
# <a name="dynamic-adaptive-streaming-over-http-dash-profile-support"></a>Dynamic Adaptive Streaming over HTTP (DASH) プロファイルのサポート


## <a name="supported-dash-profiles"></a>サポートされている DASH プロファイル
次の表では、UWP アプリでサポートされている DASH プロファイルを示します。

|タグ | マニフェストの種類 | 説明|7 月にリリースされた Windows 10|Windows 10 バージョン 1511|Windows 10 バージョン 1607 |Windows 10 バージョン 1607 |Windows 10 Version 1703|
|----------------|------|-------|-----------|--------------|---------|-------|--------|
|urn:mpeg&#58;dash:profile:isoff-live:2011 | 静的 |     |サポートされる            |  サポートされる              | サポートされる        |サポートされる| サポートされる|
|urn:mpeg&#58;dash:profile:isoff-main:2011 |        | ベスト エフォート | サポートされる            |  サポートされる              | サポートされる        |サポートされる| サポートされる|
|urn:mpeg&#58;dash:profile:isoff-live:2011 | 動的 | セグメント テンプレートで $Time$ はサポートされていますが、$Number$ はサポートされていません。 | サポートされない            | サポートされない              | サポートされない        |サポートされない| サポートされる|


## <a name="unsupported-dash-profiles"></a>サポートされていない DASH プロファイル
上の表に示されていないプロファイルはサポートされていません。これには、次のようなものが含まれますが、これらに限定されません。

* urn:mpeg&#58;dash:profile:full:2011
* urn:mpeg&#58;dash:profile:isoff-on-demand:2011
* urn:mpeg&#58;dash:profile:mp2t-main:2011
* urn:mpeg&#58;dash:profile:mp2t-simple:2011


## <a name="related-topics"></a>関連トピック

* [メディア再生](media-playback.md)
* [アダプティブ ストリーミング](adaptive-streaming.md)
 

 




