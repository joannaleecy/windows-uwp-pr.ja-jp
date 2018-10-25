---
title: 構成 BLOB の読み取り
author: KevinAsgari
description: Xbox Live タイトル ストレージ内の構成 BLOB の読み取りについて説明します。
ms.assetid: ee62d221-69b9-4f52-9b5d-5a44d04de548
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one
ms.localizationpriority: medium
ms.openlocfilehash: 8f4ceed1c1258f2a53d1c5cb6306f27c7e8818a5
ms.sourcegitcommit: 82c3fc0b06ad490c3456ad18180a6b23ecd9c1a7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/24/2018
ms.locfileid: "5470188"
---
# <a name="reading-a-configuration-blob-in-xbox-live-title-storage"></a><span data-ttu-id="0f652-104">Xbox Live タイトル ストレージ内の構成 BLOB の読み取り</span><span class="sxs-lookup"><span data-stu-id="0f652-104">Reading a configuration blob in Xbox Live Title Storage</span></span>

<span data-ttu-id="0f652-105">*構成 BLOB* は、ゲーム データを保持している Xbox Live タイトル ストレージ内のファイルです。</span><span class="sxs-lookup"><span data-stu-id="0f652-105">*Configuration blobs* are files in Xbox Live title storage that hold game data.</span></span> <span data-ttu-id="0f652-106">データは仮想ノードを含む JSON オブジェクトであり、ゲームに配信される前にフィルターを適用できます。</span><span class="sxs-lookup"><span data-stu-id="0f652-106">The data are JSON objects that include virtual nodes that can be filtered before being delivered to the game.</span></span> <span data-ttu-id="0f652-107">構成 BLOB の詳細については、「**タイトル ストレージ URI**」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="0f652-107">For more information about configuration blobs, see **Title Storage URIs**.</span></span>

### <a name="to-read-a-configuration-blob"></a><span data-ttu-id="0f652-108">構成 BLOB を読み取るには</span><span class="sxs-lookup"><span data-stu-id="0f652-108">To read a configuration blob</span></span>

1.  <span data-ttu-id="0f652-109">タイトル ストレージからデータを読み取るには、次のメソッドを使用して要求を送信します。</span><span class="sxs-lookup"><span data-stu-id="0f652-109">Send a request using the below method to read the data from title storage.</span></span>

        GET https://titlestorage.xboxlive.com/global/scids/{scid}/data/config.json,config              
        Content-Type: application/octet-stream
        x-xbl-contract-version: 1
        Authorization: XBL3.0 x=<userHash>;<STSTokenString>
        Connection: Keep-Alive


-   <span data-ttu-id="0f652-110">更新するには、ユーザーはそのセッション内にいなければなりません。</span><span class="sxs-lookup"><span data-stu-id="0f652-110">The user must be in the session to update it.</span></span>
-   <span data-ttu-id="0f652-111">STSTokenString は、簡潔にするためのプレースホルダーであり、認証要求から返されるトークンで置き換える必要があります。</span><span class="sxs-lookup"><span data-stu-id="0f652-111">STSTokenString is a placeholder for brevity and should be replaced with the token returned by the authentication request.</span></span>

#### <a name="reference"></a><span data-ttu-id="0f652-112">参照先</span><span class="sxs-lookup"><span data-stu-id="0f652-112">Reference</span></span>

<span data-ttu-id="0f652-113">**/global/scids/{scid}/data/{pathAndFileName},{type}**
**GET (/global/scids/{scid}/data/{pathAndFileName},{type})**</span><span class="sxs-lookup"><span data-stu-id="0f652-113">**/global/scids/{scid}/data/{pathAndFileName},{type}**
**GET (/global/scids/{scid}/data/{pathAndFileName},{type})**</span></span>
