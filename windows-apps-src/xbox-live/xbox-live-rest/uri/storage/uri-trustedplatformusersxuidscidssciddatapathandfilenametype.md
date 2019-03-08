---
title: /trustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type}
assetID: be789e70-517d-383e-ea35-b0c39e846081
permalink: en-us/docs/xboxlive/rest/uri-trustedplatformusersxuidscidssciddatapathandfilenametype.html
description: " /trustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type}"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 035f30279321b7b386f59e014fa6d185e6b71b57
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57603717"
---
# <a name="trustedplatformusersxuidxuidscidssciddatapathandfilenametype"></a><span data-ttu-id="665ae-104">/trustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type}</span><span class="sxs-lookup"><span data-stu-id="665ae-104">/trustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type}</span></span>
<span data-ttu-id="665ae-105">ダウンロード、アップロード、またはファイルを削除します。</span><span class="sxs-lookup"><span data-stu-id="665ae-105">Downloads, uploads, or deletes a file.</span></span> <span data-ttu-id="665ae-106">これらの Uri のドメインが`titlestorage.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="665ae-106">The domain for these URIs is `titlestorage.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="665ae-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="665ae-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="665ae-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="665ae-108">URI parameters</span></span>
 
| <span data-ttu-id="665ae-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="665ae-109">Parameter</span></span>| <span data-ttu-id="665ae-110">種類</span><span class="sxs-lookup"><span data-stu-id="665ae-110">Type</span></span>| <span data-ttu-id="665ae-111">説明</span><span class="sxs-lookup"><span data-stu-id="665ae-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="665ae-112">xuid</span><span class="sxs-lookup"><span data-stu-id="665ae-112">xuid</span></span>| <span data-ttu-id="665ae-113">64 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="665ae-113">unsigned 64-bit integer</span></span>| <span data-ttu-id="665ae-114">Xbox のユーザー ID を (XUID)、プレーヤーの要求を行う。</span><span class="sxs-lookup"><span data-stu-id="665ae-114">The Xbox User ID (XUID) of the player who making the request.</span></span>| 
| <span data-ttu-id="665ae-115">scid</span><span class="sxs-lookup"><span data-stu-id="665ae-115">scid</span></span>| <span data-ttu-id="665ae-116">guid</span><span class="sxs-lookup"><span data-stu-id="665ae-116">guid</span></span>| <span data-ttu-id="665ae-117">検索するサービス構成の ID。</span><span class="sxs-lookup"><span data-stu-id="665ae-117">the ID of the service config to look up.</span></span>| 
| <span data-ttu-id="665ae-118">pathAndFileName</span><span class="sxs-lookup"><span data-stu-id="665ae-118">pathAndFileName</span></span>| <span data-ttu-id="665ae-119">string</span><span class="sxs-lookup"><span data-stu-id="665ae-119">string</span></span>| <span data-ttu-id="665ae-120">アクセスする項目のパスとファイル名。</span><span class="sxs-lookup"><span data-stu-id="665ae-120">Path and file name for the item to be accessed.</span></span> <span data-ttu-id="665ae-121">有効な文字 (最大、および最後のスラッシュを含む) のパス部分に含まれている大文字 (A ~ Z)、英小文字 (a ~ z)、数字 (0 ~ 9)、アンダー スコア (_)、スラッシュ (/) とします。パスの部分を空にすることがあります。有効な文字の大文字 (A ~ Z)、英小文字 (a ~ z)、数字 (0 ~ 9)、ファイル名の部分 (最後のスラッシュの後の部分すべて) が含まれているアンダー スコア (_)、ピリオド (.)、およびハイフン (-)。</span><span class="sxs-lookup"><span data-stu-id="665ae-121">Valid characters for the path portion (up to and including the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), and forward slash (/). The path portion may be empty. Valid characters for the file name portion (everything after the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), period (.), and hyphen (-).</span></span> <span data-ttu-id="665ae-122">ファイル名を空にする可能性がありますはいない末尾をピリオドまたは 2 つの連続するピリオドを含めることは。</span><span class="sxs-lookup"><span data-stu-id="665ae-122">The file name may not be empty, end in a period or contain two consecutive periods.</span></span>| 
| <span data-ttu-id="665ae-123">type</span><span class="sxs-lookup"><span data-stu-id="665ae-123">type</span></span>| <span data-ttu-id="665ae-124">string</span><span class="sxs-lookup"><span data-stu-id="665ae-124">string</span></span>| <span data-ttu-id="665ae-125">データの形式です。</span><span class="sxs-lookup"><span data-stu-id="665ae-125">The format of the data.</span></span> <span data-ttu-id="665ae-126">有効値とは、バイナリまたは json です。</span><span class="sxs-lookup"><span data-stu-id="665ae-126">Possible values are binary or json.</span></span>| 
  
<a id="ID4EOC"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="665ae-127">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="665ae-127">Valid methods</span></span>

[<span data-ttu-id="665ae-128">DELETE</span><span class="sxs-lookup"><span data-stu-id="665ae-128">DELETE</span></span>](uri-trustedplatformusersxuidscidssciddatapathandfilenametype-delete.md)

<span data-ttu-id="665ae-129">&nbsp;&nbsp;ファイルを削除します。</span><span class="sxs-lookup"><span data-stu-id="665ae-129">&nbsp;&nbsp;Deletes a file.</span></span> 

[<span data-ttu-id="665ae-130">取得</span><span class="sxs-lookup"><span data-stu-id="665ae-130">GET</span></span>](uri-trustedplatformusersxuidscidssciddatapathandfilenametype-get.md)

<span data-ttu-id="665ae-131">&nbsp;&nbsp;ファイルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="665ae-131">&nbsp;&nbsp;Downloads a file.</span></span>

[<span data-ttu-id="665ae-132">PUT</span><span class="sxs-lookup"><span data-stu-id="665ae-132">PUT</span></span>](uri-trustedplatformusersxuidscidssciddatapathandfilenametype-put.md)

<span data-ttu-id="665ae-133">&nbsp;&nbsp;ファイルをアップロードします。</span><span class="sxs-lookup"><span data-stu-id="665ae-133">&nbsp;&nbsp;Uploads a file.</span></span> <span data-ttu-id="665ae-134">データおよびメタデータが送信される一連の小さなブロックのデータとメタデータが送信される複数のブロックのアップロードや 1 つのメッセージで完全なアップロードには、データをアップロードできます。</span><span class="sxs-lookup"><span data-stu-id="665ae-134">The data can be uploaded in a full upload in which the data and metadata are sent in a single message, or as a multi-block upload in which the data and metadata are sent in a series of smaller blocks.</span></span> <span data-ttu-id="665ae-135">1 つのメッセージとして 4 メガバイト未満のファイルのみを送信できます。</span><span class="sxs-lookup"><span data-stu-id="665ae-135">Only files that are smaller than four megabytes can be sent as a single message.</span></span> <span data-ttu-id="665ae-136">データ型の json は、複数のブロックのアップロードはサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="665ae-136">Multi-block upload is not supported for data of type json.</span></span> 
 
<a id="ID4E5C"></a>

 
## <a name="see-also"></a><span data-ttu-id="665ae-137">関連項目</span><span class="sxs-lookup"><span data-stu-id="665ae-137">See also</span></span>
 
<a id="ID4EAD"></a>

 
##### <a name="parent"></a><span data-ttu-id="665ae-138">Parent</span><span class="sxs-lookup"><span data-stu-id="665ae-138">Parent</span></span> 

[<span data-ttu-id="665ae-139">ストレージ Uri のタイトル</span><span class="sxs-lookup"><span data-stu-id="665ae-139">Title Storage URIs</span></span>](atoc-reference-storagev2.md)

   