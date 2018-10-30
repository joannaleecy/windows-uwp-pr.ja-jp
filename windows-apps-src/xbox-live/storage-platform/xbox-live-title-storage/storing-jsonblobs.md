---
title: バイナリ JSON の保存
author: KevinAsgari
description: Xbox Live タイトル ストレージにバイナリ JSON を保存する方法について説明します。
ms.assetid: f424aca1-e671-4e31-84c6-098fda4a9558
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one, タイトル ストレージ
ms.localizationpriority: medium
ms.openlocfilehash: 629bc38e8d5e5afa4c9d78349587585d0701b3de
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/30/2018
ms.locfileid: "5752146"
---
# <a name="storing-a-json-blob-in-xbox-live-title-storage"></a>Xbox Live タイトル ストレージへの JSON BLOB の保存

1.  タイトル ストレージにデータを送信するには、*PUT* メソッドを使用して要求を送信します。

        PUT https://titlestorage.xboxlive.com/json/users/xuid(1245111)/scids/{scid}/data/{pathAndFileName},json
        Content-Type: application/octet-stream
        x-xbl-contract-version: 1
        Authorization: XBL3.0 x=<userHash>;<STSTokenString>
        Content-Length: 240
        Connection: Keep-Alive



-   更新するには、ユーザーはそのセッション内にいなければなりません。

-   STSTokenString は、簡潔にするためのプレースホルダーであり、認証要求から返されるトークンで置き換える必要があります。

2.  JSON オブジェクトを送信します。

        {
            "startlevel":"1",
            "expression":"smile"
        }

#### <a name="reference"></a>参照先

**/json/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},json)**
