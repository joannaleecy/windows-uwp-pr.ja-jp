---
author: drewbatgit
ms.assetid: 
description: "この記事では、UWP アプリでサポートされている HTTP ライブ ストリーミング (HLS) プロトコルのタグを示します。"
title: "HTTP ライブ ストリーミング (HLS) タグのサポート"
translationtype: Human Translation
ms.sourcegitcommit: 3d61f5272e4d11acfb7e0a85436ca60ba458dcae
ms.openlocfilehash: a561f11a1638d5fea21d1d3b3f8bc47f71271f3f

---

# HTTP ライブ ストリーミング (HLS) タグのサポート
次の表では、UWP アプリでサポートされている HLS タグを示します。

> [!NOTE] 
> "X-" で始まるカスタム タグには、「[メディア項目、プレイリスト、トラック](media-playback-with-mediasource.md)」の記事で示されているように、タイミングが設定されたメタデータとしてアクセスできます。

|タグ |導入済みの HLS プロトコルのバージョン|HLS プロトコル ドキュメント草案のバージョン|クライアントに必須|7 月にリリースされた Windows 10|Windows 10 バージョン 1511|Windows 10 バージョン 1606 |
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




## 関連トピック

* [メディア再生](media-playback.md)
* [アダプティブ ストリーミング](adaptive-streaming.md)
 

 







<!--HONumber=Nov16_HO1-->


