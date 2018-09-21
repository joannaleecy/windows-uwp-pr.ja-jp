---
title: バイナリ JSON の保存
author: KevinAsgari
description: Xbox Live タイトル ストレージにバイナリ JSON を保存する方法について説明します。
ms.assetid: f424aca1-e671-4e31-84c6-098fda4a9558
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one, タイトル ストレージ
ms.localizationpriority: medium
ms.openlocfilehash: e98abcb9ab8738291efc40d5148b021ea95110fa
ms.sourcegitcommit: 4f6dc806229a8226894c55ceb6d6eab391ec8ab6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/20/2018
ms.locfileid: "4082594"
---
# <a name="storing-a-json-blob-in-xbox-live-title-storage"></a><span data-ttu-id="23d8d-104">Xbox Live タイトル ストレージへの JSON BLOB の保存</span><span class="sxs-lookup"><span data-stu-id="23d8d-104">Storing a JSON blob in Xbox Live Title Storage</span></span>

1.  <span data-ttu-id="23d8d-105">タイトル ストレージにデータを送信するには、*PUT* メソッドを使用して要求を送信します。</span><span class="sxs-lookup"><span data-stu-id="23d8d-105">Send a request using the *PUT* method to send the data to title storage.</span></span>

        PUT https://titlestorage.xboxlive.com/json/users/xuid(1245111)/scids/{scid}/data/{pathAndFileName},json
        Content-Type: application/octet-stream
        x-xbl-contract-version: 1
        Authorization: XBL3.0 x=<userHash>;<STSTokenString>
        Content-Length: 240
        Connection: Keep-Alive



-   <span data-ttu-id="23d8d-106">更新するには、ユーザーはそのセッション内にいなければなりません。</span><span class="sxs-lookup"><span data-stu-id="23d8d-106">The user must be in the session to update it.</span></span>

-   <span data-ttu-id="23d8d-107">STSTokenString は、簡潔にするためのプレースホルダーであり、認証要求から返されるトークンで置き換える必要があります。</span><span class="sxs-lookup"><span data-stu-id="23d8d-107">STSTokenString is a placeholder for brevity and should be replaced with the token returned by the authentication request.</span></span>

2.  <span data-ttu-id="23d8d-108">JSON オブジェクトを送信します。</span><span class="sxs-lookup"><span data-stu-id="23d8d-108">Send a JSON object.</span></span>

        {
            "startlevel":"1",
            "expression":"smile"
        }

#### <a name="reference"></a><span data-ttu-id="23d8d-109">参照先</span><span class="sxs-lookup"><span data-stu-id="23d8d-109">Reference</span></span>

**<span data-ttu-id="23d8d-110">/json/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},json)</span><span class="sxs-lookup"><span data-stu-id="23d8d-110">/json/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},json)</span></span>**
