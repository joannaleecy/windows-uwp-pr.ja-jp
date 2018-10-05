---
title: /sessions/{sessionId}/scids/{scid}/data/{pathAndFileName},{type}
assetID: f5e91763-0704-8526-77d4-c55dfec3b5a5
permalink: en-us/docs/xboxlive/rest/uri-sessionssessionidscidssciddatapathandfilenametype.html
author: KevinAsgari
description: " /sessions/{sessionId}/scids/{scid}/data/{pathAndFileName},{type}"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: f0ce084fed46cce407c712ee42b782565c1174d4
ms.sourcegitcommit: 5c9a47b135c5f587214675e39c1ac058c0380f4c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/04/2018
ms.locfileid: "4360429"
---
# <a name="sessionssessionidscidssciddatapathandfilenametype"></a><span data-ttu-id="40c07-104">/sessions/{sessionId}/scids/{scid}/data/{pathAndFileName},{type}</span><span class="sxs-lookup"><span data-stu-id="40c07-104">/sessions/{sessionId}/scids/{scid}/data/{pathAndFileName},{type}</span></span>
<span data-ttu-id="40c07-105">ファイルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="40c07-105">Downloads a file.</span></span> <span data-ttu-id="40c07-106">これらの Uri のドメインが`titlestorage.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="40c07-106">The domain for these URIs is `titlestorage.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="40c07-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="40c07-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="40c07-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="40c07-108">URI parameters</span></span>
 
| <span data-ttu-id="40c07-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="40c07-109">Parameter</span></span>| <span data-ttu-id="40c07-110">型</span><span class="sxs-lookup"><span data-stu-id="40c07-110">Type</span></span>| <span data-ttu-id="40c07-111">説明</span><span class="sxs-lookup"><span data-stu-id="40c07-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="40c07-112">sessionId</span><span class="sxs-lookup"><span data-stu-id="40c07-112">sessionId</span></span>| <span data-ttu-id="40c07-113">string</span><span class="sxs-lookup"><span data-stu-id="40c07-113">string</span></span>| <span data-ttu-id="40c07-114">検索するセッションの ID。</span><span class="sxs-lookup"><span data-stu-id="40c07-114">the ID of the session to look up.</span></span>| 
| <span data-ttu-id="40c07-115">scid</span><span class="sxs-lookup"><span data-stu-id="40c07-115">scid</span></span>| <span data-ttu-id="40c07-116">guid</span><span class="sxs-lookup"><span data-stu-id="40c07-116">guid</span></span>| <span data-ttu-id="40c07-117">ルックアップ サービス構成の ID です。</span><span class="sxs-lookup"><span data-stu-id="40c07-117">the ID of the service config to look up.</span></span>| 
| <span data-ttu-id="40c07-118">pathAndFileName</span><span class="sxs-lookup"><span data-stu-id="40c07-118">pathAndFileName</span></span>| <span data-ttu-id="40c07-119">string</span><span class="sxs-lookup"><span data-stu-id="40c07-119">string</span></span>| <span data-ttu-id="40c07-120">アクセスできる項目のパスとファイル名。</span><span class="sxs-lookup"><span data-stu-id="40c07-120">Path and file name for the item to be accessed.</span></span> <span data-ttu-id="40c07-121">パスの部分 (となどを含む最終的なスラッシュ) の有効な文字は大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9)、アンダー スコア (_) を含めるし、スラッシュ (/)。パス部分を空にすることがあります。有効な文字 (すべての最終的なスラッシュ後) ファイル名の部分には、大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9) が含まれているアンダー スコア (_)、ピリオド (.)、およびハイフン (-)。</span><span class="sxs-lookup"><span data-stu-id="40c07-121">Valid characters for the path portion (up to and including the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), and forward slash (/). The path portion may be empty. Valid characters for the file name portion (everything after the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), period (.), and hyphen (-).</span></span> <span data-ttu-id="40c07-122">ファイル名可能性がありますいないを空にする、期間の終了または 2 つの連続するピリオドが含まれています。</span><span class="sxs-lookup"><span data-stu-id="40c07-122">The file name may not be empty, end in a period or contain two consecutive periods.</span></span>| 
| <span data-ttu-id="40c07-123">type</span><span class="sxs-lookup"><span data-stu-id="40c07-123">type</span></span>| <span data-ttu-id="40c07-124">文字列</span><span class="sxs-lookup"><span data-stu-id="40c07-124">string</span></span>| <span data-ttu-id="40c07-125">データの形式です。</span><span class="sxs-lookup"><span data-stu-id="40c07-125">The format of the data.</span></span> <span data-ttu-id="40c07-126">値はバイナリ json します。</span><span class="sxs-lookup"><span data-stu-id="40c07-126">Possible values are binary or json.</span></span>| 
  
<a id="ID4EOC"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="40c07-127">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="40c07-127">Valid methods</span></span>

[<span data-ttu-id="40c07-128">DELETE (/sessions/{sessionId}/scids/{scid}/data/{pathAndFileName},{type})</span><span class="sxs-lookup"><span data-stu-id="40c07-128">DELETE (/sessions/{sessionId}/scids/{scid}/data/{pathAndFileName},{type})</span></span>](uri-sessionssessionidscidssciddatapathandfilenametype-delete.md)

<span data-ttu-id="40c07-129">&nbsp;&nbsp;ファイルを削除します。</span><span class="sxs-lookup"><span data-stu-id="40c07-129">&nbsp;&nbsp;Deletes a file.</span></span> 

[<span data-ttu-id="40c07-130">GET (/sessions/{sessionId}/scids/{scid}/data/{pathAndFileName},{type})</span><span class="sxs-lookup"><span data-stu-id="40c07-130">GET (/sessions/{sessionId}/scids/{scid}/data/{pathAndFileName},{type})</span></span>](uri-sessionssessionidscidssciddatapathandfilenametype-get.md)

<span data-ttu-id="40c07-131">&nbsp;&nbsp;ファイルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="40c07-131">&nbsp;&nbsp;Downloads a file.</span></span>

[<span data-ttu-id="40c07-132">PUT (/sessions/{sessionId}/scids/{scid}/data/{pathAndFileName},{type})</span><span class="sxs-lookup"><span data-stu-id="40c07-132">PUT (/sessions/{sessionId}/scids/{scid}/data/{pathAndFileName},{type})</span></span>](uri-sessionssessionidscidssciddatapathandfilenametype-put.md)

<span data-ttu-id="40c07-133">&nbsp;&nbsp;ファイルをアップロードします。</span><span class="sxs-lookup"><span data-stu-id="40c07-133">&nbsp;&nbsp;Uploads a file.</span></span> <span data-ttu-id="40c07-134">データやメタデータが送信される 1 つのメッセージで、または一連の小さいブロックのデータやメタデータが送信される複数のブロック アップロードとして完全なアップロードでは、データをアップロードできます。</span><span class="sxs-lookup"><span data-stu-id="40c07-134">The data can be uploaded in a full upload in which the data and metadata are sent in a single message, or as a multi-block upload in which the data and metadata are sent in a series of smaller blocks.</span></span> <span data-ttu-id="40c07-135">1 つのメッセージとしては 4 つのメガバイト数よりも小さいファイルのみを送信できます。</span><span class="sxs-lookup"><span data-stu-id="40c07-135">Only files that are smaller than four megabytes can be sent as a single message.</span></span> <span data-ttu-id="40c07-136">Json の種類のデータの複数のブロックのアップロードがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="40c07-136">Multi-block upload is not supported for data of type json.</span></span> 
 
<a id="ID4E5C"></a>

 
## <a name="see-also"></a><span data-ttu-id="40c07-137">関連項目</span><span class="sxs-lookup"><span data-stu-id="40c07-137">See also</span></span>
 
<a id="ID4EAD"></a>

 
##### <a name="parent"></a><span data-ttu-id="40c07-138">Parent</span><span class="sxs-lookup"><span data-stu-id="40c07-138">Parent</span></span> 

[<span data-ttu-id="40c07-139">タイトル ストレージ URI</span><span class="sxs-lookup"><span data-stu-id="40c07-139">Title Storage URIs</span></span>](atoc-reference-storagev2.md)

   