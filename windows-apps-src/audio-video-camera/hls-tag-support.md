---
author: drewbatgit
ms.assetid: 66a9cfe2-b212-4c73-8a36-963c33270099
description: この記事では、UWP アプリでサポートされている HTTP ライブ ストリーミング (HLS) プロトコルのタグを示します。
title: HTTP ライブ ストリーミング (HLS) タグのサポート
ms.author: drewbat
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 6d8e90f98dd79150cf19727fe31e51278a88a198
ms.sourcegitcommit: 71e8eae5c077a7740e5606298951bb78fc42b22c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/13/2018
ms.locfileid: "6663911"
---
# <a name="http-live-streaming-hls-tag-support"></a>HTTP ライブ ストリーミング (HLS) タグのサポート
次の表では、UWP アプリでサポートされている HLS タグを示します。

> [!NOTE] 
> "X-" で始まるカスタム タグには、「[メディア項目、プレイリスト、トラック](media-playback-with-mediasource.md)」の記事で示されているように、タイミングが設定されたメタデータとしてアクセスできます。

|タグ |導入済みの HLS プロトコルのバージョン|HLS プロトコル ドキュメント草案のバージョン|クライアントに必須|7 月にリリースされた Windows 10|Windows 10 バージョン 1511|Windows 10 バージョン 1607 |
|---------------------|-----------|--------------|---------|--------------|-----|-----|
|4.3.1.  基本タグ                 |             |                   |         |             |     |    |
| 4.3.1.1.  EXTM3U |1|0|必須|サポートされる|サポートされる|サポートされる|
| 4.3.1.2.  EXT-X-VERSION |2|3|必須|サポートされる|サポートされる|サポートされる
|4.3.2.  メディア セグメント タグ                 |             |                   |         |             |     |    | 
| 4.3.2.1.  EXTINF  |1|0|必須|サポートされる|サポートされる|サポートされる
| 4.3.2.2.  EXT-X-BYTERANGE |4|7|省略可能|サポートされる|サポートされる|サポートされる|
| 4.3.2.3.  EXT-X-DISCONTINUITY |1|2|省略可能|サポートされる|サポートされる|サポートされる|
| 4.3.2.4.  EXT-X-KEY |1|0|省略可能|サポートされる|サポートされる|サポートされる|
|&nbsp;&nbsp;&nbsp; METHOD|1|0|備わっている|"NONE、AES-128"|"NONE、AES-128"|"NONE、AES-128、SAMPLE-AES"|
|&nbsp;&nbsp;&nbsp; URI|1|0|備わっている|サポートされる|サポートされる|サポートされる|
|&nbsp;&nbsp;&nbsp; IV|2|3|備わっている|サポートされる|サポートされる|サポートされる|
|&nbsp;&nbsp;&nbsp; KEYFORMAT|5|9|備わっている|サポートされない|サポートされない|サポートされない|
|&nbsp;&nbsp;&nbsp; KEYFORMATVERSIONS|5|9|備わっている|サポートされない|サポートされない|サポートされない|
| 4.3.2.5.  EXT-X-MAP |5|9|省略可能|サポートされない|サポートされない|サポートされない|
|&nbsp;&nbsp;&nbsp; URI|5|9|備わっている|サポートされない|サポートされない|サポートされない|
|&nbsp;&nbsp;&nbsp; BYTERANGE|5|9|備わっている|サポートされない|サポートされない|サポートされない|
| 4.3.2.6.  EXT-X-PROGRAM-DATE-TIME |1|0|省略可能|サポートされない|サポートされない|サポートされない|
|4.3.3.  メディア プレイリスト タグ                 |             |                   |         |             |     |    | 
| 4.3.3.1.  EXT-X-TARGETDURATION  |1|0|必須|サポートされる|サポートされる|サポートされる|
| 4.3.3.2.  EXT-X-MEDIA-SEQUENCE  |1|0|省略可能|サポートされる|サポートされる|サポートされる|
| 4.3.3.3.  EXT-X-DISCONTINUITY-SEQUENCE|6|12|省略可能|サポートされない|サポートされない|サポートされない|
| 4.3.3.4.  EXT-X-ENDLIST |1|0|省略可能|サポートされる|サポートされる|サポートされる|
| 4.3.3.5.  EXT-X-PLAYLIST-TYPE |3|6|省略可能|サポートされる|サポートされる|サポートされる|
| 4.3.3.6.  EXT-X-I-FRAMES-ONLY |4|7|省略可能|サポートされない|サポートされない|サポートされない|
|4.3.4.  マスター プレイリスト タグ                 |             |                   |         |             |     |    |
| 4.3.4.1.  EXT-X-MEDIA |4|7|省略可能|サポートされる|サポートされる|サポートされる|
|&nbsp;&nbsp;&nbsp;  TYPE|4|7|備わっている|"AUDIO、VIDEO"|"AUDIO、VIDEO"|"AUDIO、VIDEO、SUBTITLES"|
|&nbsp;&nbsp;&nbsp;  URI|4|7|備わっている|サポートされる|サポートされる|サポートされる|
|&nbsp;&nbsp;&nbsp;  GROUP-ID|4|7|備わっている|サポートされる|サポートされる|サポートされる|
|&nbsp;&nbsp;&nbsp;  LANGUAGE|4|7|備わっている|サポートされる|サポートされる|サポートされる|
|&nbsp;&nbsp;&nbsp;  ASSOC-LANGUAGE|6|13|備わっている|サポートされない|サポートされない|サポートされない|
|&nbsp;&nbsp;&nbsp;  NAME|4|7|備わっている|サポートされない|サポートされない|サポートされる|
|&nbsp;&nbsp;&nbsp;  DEFAULT|4|7|備わっている|サポートされない|サポートされない|サポートされない|
|&nbsp;&nbsp;&nbsp;  AUTOSELECT|4|7|備わっている|サポートされない|サポートされない|サポートされない|
|&nbsp;&nbsp;&nbsp;  FORCED|5|9|備わっている|サポートされない|サポートされない|サポートされない|
|&nbsp;&nbsp;&nbsp;  INSTREAM-ID|6|12|備わっている|サポートされない|サポートされない|サポートされない|
|&nbsp;&nbsp;&nbsp;  CHARACTERISTICS|5|9|備わっている|サポートされない|サポートされない|サポートされない|
| 4.3.4.2.  EXT-X-STREAM-INF  |1|0|必須|サポートされる|サポートされる|サポートされる|
|&nbsp;&nbsp;&nbsp;  BANDWIDTH|1|0|備わっている|サポートされる|サポートされる|サポートされる|
|&nbsp;&nbsp;&nbsp;  PROGRAM-ID|1|0|備わっている|該当なし|該当なし|該当なし|
|&nbsp;&nbsp;&nbsp;  AVERAGE-BANDWIDTH|7|14|備わっている|サポートされない|サポートされない|サポートされない|
|&nbsp;&nbsp;&nbsp;  CODECS|1|0|備わっている|サポートされる|サポートされる|サポートされる|
|&nbsp;&nbsp;&nbsp;  RESOLUTION|2|3|備わっている|サポートされる|サポートされる|サポートされる|
|&nbsp;&nbsp;&nbsp;  FRAME-RATE|7|15|備わっている|該当なし|該当なし|該当なし|
|&nbsp;&nbsp;&nbsp;  AUDIO|4|7|備わっている|サポートされる|サポートされる|サポートされる|
|&nbsp;&nbsp;&nbsp;  VIDEO|4|7|備わっている|サポートされる|サポートされる|サポートされる|
|&nbsp;&nbsp;&nbsp;  SUBTITLES|5|9|備わっている|サポートされない|サポートされない|サポートされる|
|&nbsp;&nbsp;&nbsp;  CLOSED-CAPTIONS|6|12|備わっている|サポートされない|サポートされない|サポートされない|
| 4.3.4.3.  EXT-X-I-FRAME-STREAM-INF  |4|7|省略可能|サポートされない|サポートされない|サポートされない|
| 4.3.4.4.  EXT-X-SESSION-DATA  |7|14|省略可能|サポートされない|サポートされない|サポートされない|
| 4.3.4.5.  EXT-X-SESSION-KEY |7|17|省略可能|サポートされない|サポートされない|サポートされない|
|4.3.5.   メディアまたはマスター プレイリスト タグ                  |             |                   |         |             |     |    |
| 4.3.5.1.   EXT-X-INDEPENDENT-SEGMENTS |6|13|省略可能|サポートされない|サポートされる|サポートされる|
| 4.3.5.2.   EXT-X-START  |6|12|省略可能|サポートされない|部分的にサポートされる|部分的にサポートされる|
|&nbsp;&nbsp;&nbsp;  TIME-OFFSET|6|12|備わっている|サポートされない|サポートされる|サポートされる|
|&nbsp;&nbsp;&nbsp;  PRECISE|6|12|備わっている|サポートされない|既定ではサポートされない|既定ではサポートされない|



## <a name="related-topics"></a>関連トピック

* [メディア再生](media-playback.md)
* [アダプティブ ストリーミング](adaptive-streaming.md)
 

 




