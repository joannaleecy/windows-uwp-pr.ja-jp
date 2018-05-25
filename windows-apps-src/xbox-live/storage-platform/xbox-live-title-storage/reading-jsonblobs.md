---
title: JSON BLOB の読み取り
author: KevinAsgari
description: Xbox Live タイトル ストレージ内の JSON BLOB の読み取りについて説明します。
ms.assetid: 3697af16-d054-4835-af7f-7fee8c628345
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one
ms.localizationpriority: low
ms.openlocfilehash: 74c977765f5c539e3e2bcd991fd358cd728de900
ms.sourcegitcommit: 01760b73fa8cdb423a9aa1f63e72e70647d8f6ab
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 02/24/2018
---
# <a name="reading-a-json-blob-in-xbox-live-title-storage"></a>Xbox Live タイトル ストレージ内の JSON BLOB の読み取り

1.  タイトル ストレージからデータを読み取るには、*GET* メソッドを使用して要求を送信します。 次の例ではグローバル タイトル ストレージを使用します。

        GET https://titlestorage.xboxlive.com/global/scids/{scid}/data/surprise.json,json
        Content-Type: application/octet-stream
        x-xbl-contract-version: 1
        Authorization: XBL3.0 x=<userHash>;<STSTokenString>
        Connection: Keep-Alive

-   更新するには、ユーザーはそのセッション内にいなければなりません。

-   STSTokenString は、簡潔にするためのプレースホルダーであり、認証要求から返されるトークンで置き換える必要があります。

#### <a name="reference"></a>参照先

**/global/scids/{scid}/data/{pathAndFileName},{type}**
