---
title: /trustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type}
assetID: be789e70-517d-383e-ea35-b0c39e846081
permalink: en-us/docs/xboxlive/rest/uri-trustedplatformusersxuidscidssciddatapathandfilenametype.html
author: KevinAsgari
description: " /trustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type}"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: b0c776c3aae1978edb501d41fffccafcc76f799e
ms.sourcegitcommit: 82c3fc0b06ad490c3456ad18180a6b23ecd9c1a7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/24/2018
ms.locfileid: "5483518"
---
# <a name="trustedplatformusersxuidxuidscidssciddatapathandfilenametype"></a><span data-ttu-id="00f0d-104">/trustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type}</span><span class="sxs-lookup"><span data-stu-id="00f0d-104">/trustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type}</span></span>
<span data-ttu-id="00f0d-105">ダウンロード、アップロード、またはファイルを削除します。</span><span class="sxs-lookup"><span data-stu-id="00f0d-105">Downloads, uploads, or deletes a file.</span></span> <span data-ttu-id="00f0d-106">これらの Uri のドメインは、 `titlestorage.xboxlive.com`。</span><span class="sxs-lookup"><span data-stu-id="00f0d-106">The domain for these URIs is `titlestorage.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="00f0d-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="00f0d-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="00f0d-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="00f0d-108">URI parameters</span></span>
 
| <span data-ttu-id="00f0d-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="00f0d-109">Parameter</span></span>| <span data-ttu-id="00f0d-110">型</span><span class="sxs-lookup"><span data-stu-id="00f0d-110">Type</span></span>| <span data-ttu-id="00f0d-111">説明</span><span class="sxs-lookup"><span data-stu-id="00f0d-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="00f0d-112">xuid</span><span class="sxs-lookup"><span data-stu-id="00f0d-112">xuid</span></span>| <span data-ttu-id="00f0d-113">64 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="00f0d-113">unsigned 64-bit integer</span></span>| <span data-ttu-id="00f0d-114">Xbox ユーザー ID を (XUID) プレーヤーの要求を行っています。</span><span class="sxs-lookup"><span data-stu-id="00f0d-114">The Xbox User ID (XUID) of the player who making the request.</span></span>| 
| <span data-ttu-id="00f0d-115">scid</span><span class="sxs-lookup"><span data-stu-id="00f0d-115">scid</span></span>| <span data-ttu-id="00f0d-116">guid</span><span class="sxs-lookup"><span data-stu-id="00f0d-116">guid</span></span>| <span data-ttu-id="00f0d-117">検索するサービスの構成の ID です。</span><span class="sxs-lookup"><span data-stu-id="00f0d-117">the ID of the service config to look up.</span></span>| 
| <span data-ttu-id="00f0d-118">pathAndFileName</span><span class="sxs-lookup"><span data-stu-id="00f0d-118">pathAndFileName</span></span>| <span data-ttu-id="00f0d-119">string</span><span class="sxs-lookup"><span data-stu-id="00f0d-119">string</span></span>| <span data-ttu-id="00f0d-120">アクセスするアイテムのパスとファイル名です。</span><span class="sxs-lookup"><span data-stu-id="00f0d-120">Path and file name for the item to be accessed.</span></span> <span data-ttu-id="00f0d-121">パスの部分と最後のスラッシュを含む) に有効な文字は、大文字の英字 (A-Z)、英小文字 (a から z)、数字 (0-9)、アンダー スコア (_) が含まれます、スラッシュ (/)。パスの部分を空にすることがあります。ファイル名の部分 (最後のスラッシュ以降後のすべて) に含まれている大文字の英字 (A-Z)、英小文字 (a から z)、数字 (0-9)、アンダー スコア文字の有効な (_)、ピリオド (.)、およびハイフン (-) です。</span><span class="sxs-lookup"><span data-stu-id="00f0d-121">Valid characters for the path portion (up to and including the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), and forward slash (/). The path portion may be empty. Valid characters for the file name portion (everything after the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), period (.), and hyphen (-).</span></span> <span data-ttu-id="00f0d-122">ファイル名可能性がありますいないを空にする、期間の終了または 2 つの連続するピリオドが含まれています。</span><span class="sxs-lookup"><span data-stu-id="00f0d-122">The file name may not be empty, end in a period or contain two consecutive periods.</span></span>| 
| <span data-ttu-id="00f0d-123">type</span><span class="sxs-lookup"><span data-stu-id="00f0d-123">type</span></span>| <span data-ttu-id="00f0d-124">文字列</span><span class="sxs-lookup"><span data-stu-id="00f0d-124">string</span></span>| <span data-ttu-id="00f0d-125">データの形式です。</span><span class="sxs-lookup"><span data-stu-id="00f0d-125">The format of the data.</span></span> <span data-ttu-id="00f0d-126">使用可能な値は、バイナリまたは json です。</span><span class="sxs-lookup"><span data-stu-id="00f0d-126">Possible values are binary or json.</span></span>| 
  
<a id="ID4EOC"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="00f0d-127">有効な方法</span><span class="sxs-lookup"><span data-stu-id="00f0d-127">Valid methods</span></span>

[<span data-ttu-id="00f0d-128">DELETE</span><span class="sxs-lookup"><span data-stu-id="00f0d-128">DELETE</span></span>](uri-trustedplatformusersxuidscidssciddatapathandfilenametype-delete.md)

<span data-ttu-id="00f0d-129">&nbsp;&nbsp;ファイルを削除します。</span><span class="sxs-lookup"><span data-stu-id="00f0d-129">&nbsp;&nbsp;Deletes a file.</span></span> 

[<span data-ttu-id="00f0d-130">GET</span><span class="sxs-lookup"><span data-stu-id="00f0d-130">GET</span></span>](uri-trustedplatformusersxuidscidssciddatapathandfilenametype-get.md)

<span data-ttu-id="00f0d-131">&nbsp;&nbsp;ファイルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="00f0d-131">&nbsp;&nbsp;Downloads a file.</span></span>

[<span data-ttu-id="00f0d-132">PUT</span><span class="sxs-lookup"><span data-stu-id="00f0d-132">PUT</span></span>](uri-trustedplatformusersxuidscidssciddatapathandfilenametype-put.md)

<span data-ttu-id="00f0d-133">&nbsp;&nbsp;ファイルをアップロードします。</span><span class="sxs-lookup"><span data-stu-id="00f0d-133">&nbsp;&nbsp;Uploads a file.</span></span> <span data-ttu-id="00f0d-134">データは、完全なデータとメタデータが送信される 1 つまたは一連の小さなブロックのデータとメタデータが送信される複数のブロックのアップロードとアップロードでアップロードできます。</span><span class="sxs-lookup"><span data-stu-id="00f0d-134">The data can be uploaded in a full upload in which the data and metadata are sent in a single message, or as a multi-block upload in which the data and metadata are sent in a series of smaller blocks.</span></span> <span data-ttu-id="00f0d-135">4 メガバイト未満のファイルだけは、1 つのメッセージとして送信できます。</span><span class="sxs-lookup"><span data-stu-id="00f0d-135">Only files that are smaller than four megabytes can be sent as a single message.</span></span> <span data-ttu-id="00f0d-136">型の json のデータには、複数のブロックのアップロードはサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="00f0d-136">Multi-block upload is not supported for data of type json.</span></span> 
 
<a id="ID4E5C"></a>

 
## <a name="see-also"></a><span data-ttu-id="00f0d-137">関連項目</span><span class="sxs-lookup"><span data-stu-id="00f0d-137">See also</span></span>
 
<a id="ID4EAD"></a>

 
##### <a name="parent"></a><span data-ttu-id="00f0d-138">Parent</span><span class="sxs-lookup"><span data-stu-id="00f0d-138">Parent</span></span> 

[<span data-ttu-id="00f0d-139">タイトル ストレージ URI</span><span class="sxs-lookup"><span data-stu-id="00f0d-139">Title Storage URIs</span></span>](atoc-reference-storagev2.md)

   