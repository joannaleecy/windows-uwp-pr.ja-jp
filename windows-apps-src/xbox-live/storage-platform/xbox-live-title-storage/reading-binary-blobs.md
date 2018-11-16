---
title: バイナリ BLOB の読み取り
author: KevinAsgari
description: Xbox Live タイトル ストレージ内のバイナリ BLOB の読み取りについて説明します。
ms.assetid: 9b8e0c35-0cea-4491-bf30-22fad224f11b
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one, タイトル ストレージ
ms.localizationpriority: medium
ms.openlocfilehash: 5dc5e429ab36621db1c5525ae7f1a8dc5da3b4fc
ms.sourcegitcommit: e38b334edb82bf2b1474ba686990f4299b8f59c7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/14/2018
ms.locfileid: "6835651"
---
# <a name="reading-a-binary-blob-in-xbox-live-title-storage"></a><span data-ttu-id="df9c1-104">Xbox Live タイトル ストレージ内のバイナリ BLOB の読み取り</span><span class="sxs-lookup"><span data-stu-id="df9c1-104">Reading a binary blob in Xbox Live Title Storage</span></span>

1.  <span data-ttu-id="df9c1-105">タイトル ストレージからデータを読み取るには、*GET* メソッドを使用して要求を送信します。</span><span class="sxs-lookup"><span data-stu-id="df9c1-105">Send a request using the *GET* method to read the data from title storage.</span></span> <span data-ttu-id="df9c1-106">次の例ではグローバル タイトル ストレージを使用します。</span><span class="sxs-lookup"><span data-stu-id="df9c1-106">This example uses global title storage.</span></span>

        GET https://titlestorage.xboxlive.com/global/scids/{scid}/data/userinfo.bin,binary
        Content-Type: application/octet-stream
        x-xbl-contract-version: 1
        Authorization: XBL3.0 x=<userHash>;<STSTokenString>
        Connection: Keep-Alive



-   <span data-ttu-id="df9c1-107">更新するには、ユーザーはそのセッション内にいなければなりません。</span><span class="sxs-lookup"><span data-stu-id="df9c1-107">The user must be in the session to update it.</span></span>

-   <span data-ttu-id="df9c1-108">STSTokenString は、簡潔にするためのプレースホルダーであり、認証要求から返されるトークンで置き換える必要があります。</span><span class="sxs-lookup"><span data-stu-id="df9c1-108">STSTokenString is a placeholder for brevity and should be replaced with the token returned by the authentication request.</span></span>

#### <a name="reference"></a><span data-ttu-id="df9c1-109">参照先</span><span class="sxs-lookup"><span data-stu-id="df9c1-109">Reference</span></span>

**<span data-ttu-id="df9c1-110">/global/scids/{scid}/data/{pathAndFileName},{type}</span><span class="sxs-lookup"><span data-stu-id="df9c1-110">/global/scids/{scid}/data/{pathAndFileName},{type}</span></span>**
