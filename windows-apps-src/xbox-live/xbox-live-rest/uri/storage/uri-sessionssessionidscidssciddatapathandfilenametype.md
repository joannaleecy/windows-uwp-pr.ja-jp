---
title: /sessions/{sessionId}/scids/{scid}/data/{pathAndFileName},{type}
assetID: f5e91763-0704-8526-77d4-c55dfec3b5a5
permalink: en-us/docs/xboxlive/rest/uri-sessionssessionidscidssciddatapathandfilenametype.html
description: " /sessions/{sessionId}/scids/{scid}/data/{pathAndFileName},{type}"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 402b4589a2812e34792622c253fb4b919d3f9c74
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57599667"
---
# <a name="sessionssessionidscidssciddatapathandfilenametype"></a><span data-ttu-id="8f6b1-104">/sessions/{sessionId}/scids/{scid}/data/{pathAndFileName},{type}</span><span class="sxs-lookup"><span data-stu-id="8f6b1-104">/sessions/{sessionId}/scids/{scid}/data/{pathAndFileName},{type}</span></span>
<span data-ttu-id="8f6b1-105">ファイルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="8f6b1-105">Downloads a file.</span></span> <span data-ttu-id="8f6b1-106">これらの Uri のドメインが`titlestorage.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="8f6b1-106">The domain for these URIs is `titlestorage.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="8f6b1-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="8f6b1-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="8f6b1-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="8f6b1-108">URI parameters</span></span>
 
| <span data-ttu-id="8f6b1-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="8f6b1-109">Parameter</span></span>| <span data-ttu-id="8f6b1-110">種類</span><span class="sxs-lookup"><span data-stu-id="8f6b1-110">Type</span></span>| <span data-ttu-id="8f6b1-111">説明</span><span class="sxs-lookup"><span data-stu-id="8f6b1-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="8f6b1-112">sessionId</span><span class="sxs-lookup"><span data-stu-id="8f6b1-112">sessionId</span></span>| <span data-ttu-id="8f6b1-113">string</span><span class="sxs-lookup"><span data-stu-id="8f6b1-113">string</span></span>| <span data-ttu-id="8f6b1-114">検索する、セッションの ID。</span><span class="sxs-lookup"><span data-stu-id="8f6b1-114">the ID of the session to look up.</span></span>| 
| <span data-ttu-id="8f6b1-115">scid</span><span class="sxs-lookup"><span data-stu-id="8f6b1-115">scid</span></span>| <span data-ttu-id="8f6b1-116">guid</span><span class="sxs-lookup"><span data-stu-id="8f6b1-116">guid</span></span>| <span data-ttu-id="8f6b1-117">検索するサービス構成の ID。</span><span class="sxs-lookup"><span data-stu-id="8f6b1-117">the ID of the service config to look up.</span></span>| 
| <span data-ttu-id="8f6b1-118">pathAndFileName</span><span class="sxs-lookup"><span data-stu-id="8f6b1-118">pathAndFileName</span></span>| <span data-ttu-id="8f6b1-119">string</span><span class="sxs-lookup"><span data-stu-id="8f6b1-119">string</span></span>| <span data-ttu-id="8f6b1-120">アクセスする項目のパスとファイル名。</span><span class="sxs-lookup"><span data-stu-id="8f6b1-120">Path and file name for the item to be accessed.</span></span> <span data-ttu-id="8f6b1-121">有効な文字 (最大、および最後のスラッシュを含む) のパス部分に含まれている大文字 (A ~ Z)、英小文字 (a ~ z)、数字 (0 ~ 9)、アンダー スコア (_)、スラッシュ (/) とします。パスの部分を空にすることがあります。有効な文字の大文字 (A ~ Z)、英小文字 (a ~ z)、数字 (0 ~ 9)、ファイル名の部分 (最後のスラッシュの後の部分すべて) が含まれているアンダー スコア (_)、ピリオド (.)、およびハイフン (-)。</span><span class="sxs-lookup"><span data-stu-id="8f6b1-121">Valid characters for the path portion (up to and including the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), and forward slash (/). The path portion may be empty. Valid characters for the file name portion (everything after the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), period (.), and hyphen (-).</span></span> <span data-ttu-id="8f6b1-122">ファイル名を空にする可能性がありますはいない末尾をピリオドまたは 2 つの連続するピリオドを含めることは。</span><span class="sxs-lookup"><span data-stu-id="8f6b1-122">The file name may not be empty, end in a period or contain two consecutive periods.</span></span>| 
| <span data-ttu-id="8f6b1-123">type</span><span class="sxs-lookup"><span data-stu-id="8f6b1-123">type</span></span>| <span data-ttu-id="8f6b1-124">string</span><span class="sxs-lookup"><span data-stu-id="8f6b1-124">string</span></span>| <span data-ttu-id="8f6b1-125">データの形式です。</span><span class="sxs-lookup"><span data-stu-id="8f6b1-125">The format of the data.</span></span> <span data-ttu-id="8f6b1-126">有効値とは、バイナリまたは json です。</span><span class="sxs-lookup"><span data-stu-id="8f6b1-126">Possible values are binary or json.</span></span>| 
  
<a id="ID4EOC"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="8f6b1-127">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="8f6b1-127">Valid methods</span></span>

[<span data-ttu-id="8f6b1-128">DELETE (/sessions/{sessionId}/scids/{scid}/data/{pathAndFileName},{type})</span><span class="sxs-lookup"><span data-stu-id="8f6b1-128">DELETE (/sessions/{sessionId}/scids/{scid}/data/{pathAndFileName},{type})</span></span>](uri-sessionssessionidscidssciddatapathandfilenametype-delete.md)

<span data-ttu-id="8f6b1-129">&nbsp;&nbsp;ファイルを削除します。</span><span class="sxs-lookup"><span data-stu-id="8f6b1-129">&nbsp;&nbsp;Deletes a file.</span></span> 

[<span data-ttu-id="8f6b1-130">GET (/sessions/{sessionId}/scids/{scid}/data/{pathAndFileName},{type})</span><span class="sxs-lookup"><span data-stu-id="8f6b1-130">GET (/sessions/{sessionId}/scids/{scid}/data/{pathAndFileName},{type})</span></span>](uri-sessionssessionidscidssciddatapathandfilenametype-get.md)

<span data-ttu-id="8f6b1-131">&nbsp;&nbsp;ファイルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="8f6b1-131">&nbsp;&nbsp;Downloads a file.</span></span>

[<span data-ttu-id="8f6b1-132">PUT (/sessions/{sessionId}/scids/{scid}/data/{pathAndFileName},{type})</span><span class="sxs-lookup"><span data-stu-id="8f6b1-132">PUT (/sessions/{sessionId}/scids/{scid}/data/{pathAndFileName},{type})</span></span>](uri-sessionssessionidscidssciddatapathandfilenametype-put.md)

<span data-ttu-id="8f6b1-133">&nbsp;&nbsp;ファイルをアップロードします。</span><span class="sxs-lookup"><span data-stu-id="8f6b1-133">&nbsp;&nbsp;Uploads a file.</span></span> <span data-ttu-id="8f6b1-134">データおよびメタデータが送信される一連の小さなブロックのデータとメタデータが送信される複数のブロックのアップロードや 1 つのメッセージで完全なアップロードには、データをアップロードできます。</span><span class="sxs-lookup"><span data-stu-id="8f6b1-134">The data can be uploaded in a full upload in which the data and metadata are sent in a single message, or as a multi-block upload in which the data and metadata are sent in a series of smaller blocks.</span></span> <span data-ttu-id="8f6b1-135">1 つのメッセージとして 4 メガバイト未満のファイルのみを送信できます。</span><span class="sxs-lookup"><span data-stu-id="8f6b1-135">Only files that are smaller than four megabytes can be sent as a single message.</span></span> <span data-ttu-id="8f6b1-136">データ型の json は、複数のブロックのアップロードはサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="8f6b1-136">Multi-block upload is not supported for data of type json.</span></span> 
 
<a id="ID4E5C"></a>

 
## <a name="see-also"></a><span data-ttu-id="8f6b1-137">関連項目</span><span class="sxs-lookup"><span data-stu-id="8f6b1-137">See also</span></span>
 
<a id="ID4EAD"></a>

 
##### <a name="parent"></a><span data-ttu-id="8f6b1-138">Parent</span><span class="sxs-lookup"><span data-stu-id="8f6b1-138">Parent</span></span> 

[<span data-ttu-id="8f6b1-139">ストレージ Uri のタイトル</span><span class="sxs-lookup"><span data-stu-id="8f6b1-139">Title Storage URIs</span></span>](atoc-reference-storagev2.md)

   