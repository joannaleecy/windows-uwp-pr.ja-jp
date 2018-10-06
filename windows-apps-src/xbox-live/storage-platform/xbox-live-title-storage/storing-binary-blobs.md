---
title: バイナリ BLOB の保存
author: KevinAsgari
description: Xbox Live タイトル ストレージにバイナリ BLOB を保存する方法について説明します。
ms.assetid: a0da36ef-5a5a-466d-80a8-e055ba7e4cdc
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one, タイトル ストレージ
ms.localizationpriority: medium
ms.openlocfilehash: b74dd1943764b7dcfc7a635e569ed9bbd5d8e24b
ms.sourcegitcommit: 63cef0a7805f1594984da4d4ff2f76894f12d942
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/05/2018
ms.locfileid: "4390204"
---
# <a name="storing-a-binary-blob-in-xbox-live-title-storage"></a><span data-ttu-id="32f85-104">Xbox Live タイトル ストレージへのバイナリ BLOB の保存</span><span class="sxs-lookup"><span data-stu-id="32f85-104">Storing a binary blob in Xbox Live Title Storage</span></span>

1.  <span data-ttu-id="32f85-105">タイトル ストレージにデータを送信するには、次のメソッドを使用して要求を送信します。</span><span class="sxs-lookup"><span data-stu-id="32f85-105">Send a request using the below method to send the data to title storage.</span></span>

        PUT https://titlestorage.xboxlive.com/trustedplatform/users/xuid(1245111)/scids/{scid}/data/lastturn.bin,binary              
        Content-Type: application/octet-stream
        x-xbl-contract-version: 1
        Authorization: XBL3.0 x=<userHash>;<STSTokenString>
        Content-Length: 40
        Connection: Keep-Alive


-   <span data-ttu-id="32f85-106">更新するには、ユーザーはそのセッション内にいなければなりません。</span><span class="sxs-lookup"><span data-stu-id="32f85-106">The user must be in the session to update it.</span></span>

-   <span data-ttu-id="32f85-107">STSTokenString は、簡潔にするためのプレースホルダーであり、認証要求から返されるトークンで置き換える必要があります。</span><span class="sxs-lookup"><span data-stu-id="32f85-107">STSTokenString is a placeholder for brevity and should be replaced with the token returned by the authentication request.</span></span>

2.  <span data-ttu-id="32f85-108">バイナリ データを送信します。</span><span class="sxs-lookup"><span data-stu-id="32f85-108">Send the binary data.</span></span> <span data-ttu-id="32f85-109">データは HTTP で転送されるため、データは使用可能な文字セットに従う必要があります。</span><span class="sxs-lookup"><span data-stu-id="32f85-109">Since the data will be transferred through HTTP, the data must be constrained to the acceptable character set.</span></span> <span data-ttu-id="32f85-110">画像やオーディオ データなどの情報はエンコードする必要があります。</span><span class="sxs-lookup"><span data-stu-id="32f85-110">Information such as image or audio data must be encoded.</span></span> <span data-ttu-id="32f85-111">HTTP と互換性のある文字を生成する任意のエンコード方式を選択できます。</span><span class="sxs-lookup"><span data-stu-id="32f85-111">You may select any encoding method that generates HTTP compatible characters.</span></span>
<span data-ttu-id="32f85-112">d</span><span class="sxs-lookup"><span data-stu-id="32f85-112">d</span></span>
```
  01EAEFBAD05903A4
  1EA2311656677DFF
  CF00
```

#### <a name="reference"></a><span data-ttu-id="32f85-113">参照先</span><span class="sxs-lookup"><span data-stu-id="32f85-113">Reference</span></span>

**<span data-ttu-id="32f85-114">/trustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type}</span><span class="sxs-lookup"><span data-stu-id="32f85-114">/trustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type}</span></span>**
