---
title: バイナリ BLOB の保存
author: KevinAsgari
description: Xbox Live タイトル ストレージにバイナリ BLOB を保存する方法について説明します。
ms.assetid: a0da36ef-5a5a-466d-80a8-e055ba7e4cdc
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one, タイトル ストレージ
ms.localizationpriority: medium
ms.openlocfilehash: 3aa0598e724ffc0d919c9ad8b2ffdc3bb29d7d09
ms.sourcegitcommit: e814a13978f33654d8e995584f4b047cb53e0aef
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/06/2018
ms.locfileid: "6037583"
---
# <a name="storing-a-binary-blob-in-xbox-live-title-storage"></a>Xbox Live タイトル ストレージへのバイナリ BLOB の保存

1.  タイトル ストレージにデータを送信するには、次のメソッドを使用して要求を送信します。

        PUT https://titlestorage.xboxlive.com/trustedplatform/users/xuid(1245111)/scids/{scid}/data/lastturn.bin,binary              
        Content-Type: application/octet-stream
        x-xbl-contract-version: 1
        Authorization: XBL3.0 x=<userHash>;<STSTokenString>
        Content-Length: 40
        Connection: Keep-Alive


-   更新するには、ユーザーはそのセッション内にいなければなりません。

-   STSTokenString は、簡潔にするためのプレースホルダーであり、認証要求から返されるトークンで置き換える必要があります。

2.  バイナリ データを送信します。 データは HTTP で転送されるため、データは使用可能な文字セットに従う必要があります。 画像やオーディオ データなどの情報はエンコードする必要があります。 HTTP と互換性のある文字を生成する任意のエンコード方式を選択できます。
d
```
  01EAEFBAD05903A4
  1EA2311656677DFF
  CF00
```

#### <a name="reference"></a>参照先

**/trustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type}**
