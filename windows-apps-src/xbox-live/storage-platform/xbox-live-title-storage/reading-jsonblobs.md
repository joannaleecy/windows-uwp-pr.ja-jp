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
ms.localizationpriority: medium
ms.openlocfilehash: d392269f9cde18f3fcf86bbe0e061aa957fd877a
ms.sourcegitcommit: f5321b525034e2b3af202709e9b942ad5557e193
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/18/2018
ms.locfileid: "4017501"
---
# <a name="reading-a-json-blob-in-xbox-live-title-storage"></a><span data-ttu-id="8e2d9-104">Xbox Live タイトル ストレージ内の JSON BLOB の読み取り</span><span class="sxs-lookup"><span data-stu-id="8e2d9-104">Reading a JSON blob in Xbox Live Title Storage</span></span>

1.  <span data-ttu-id="8e2d9-105">タイトル ストレージからデータを読み取るには、*GET* メソッドを使用して要求を送信します。</span><span class="sxs-lookup"><span data-stu-id="8e2d9-105">Send a request using the *GET* method to read the data from title storage.</span></span> <span data-ttu-id="8e2d9-106">次の例ではグローバル タイトル ストレージを使用します。</span><span class="sxs-lookup"><span data-stu-id="8e2d9-106">This example uses global title storage.</span></span>

        GET https://titlestorage.xboxlive.com/global/scids/{scid}/data/surprise.json,json
        Content-Type: application/octet-stream
        x-xbl-contract-version: 1
        Authorization: XBL3.0 x=<userHash>;<STSTokenString>
        Connection: Keep-Alive

-   <span data-ttu-id="8e2d9-107">更新するには、ユーザーはそのセッション内にいなければなりません。</span><span class="sxs-lookup"><span data-stu-id="8e2d9-107">The user must be in the session to update it.</span></span>

-   <span data-ttu-id="8e2d9-108">STSTokenString は、簡潔にするためのプレースホルダーであり、認証要求から返されるトークンで置き換える必要があります。</span><span class="sxs-lookup"><span data-stu-id="8e2d9-108">STSTokenString is a placeholder for brevity and should be replaced with the token returned by the authentication request.</span></span>

#### <a name="reference"></a><span data-ttu-id="8e2d9-109">参照先</span><span class="sxs-lookup"><span data-stu-id="8e2d9-109">Reference</span></span>

**<span data-ttu-id="8e2d9-110">/global/scids/{scid}/data/{pathAndFileName},{type}</span><span class="sxs-lookup"><span data-stu-id="8e2d9-110">/global/scids/{scid}/data/{pathAndFileName},{type}</span></span>**
