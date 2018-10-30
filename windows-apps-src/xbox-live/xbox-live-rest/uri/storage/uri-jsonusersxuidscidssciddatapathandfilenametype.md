---
title: /json/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},json
assetID: d004d715-d73c-693e-2a0b-ce64f482642b
permalink: en-us/docs/xboxlive/rest/uri-jsonusersxuidscidssciddatapathandfilenametype.html
author: KevinAsgari
description: " /json/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},json"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: fb630c8537fa4190585b6f95274a6cd4760a2987
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/30/2018
ms.locfileid: "5743777"
---
# <a name="jsonusersxuidxuidscidssciddatapathandfilenamejson"></a><span data-ttu-id="efdc4-104">/json/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},json</span><span class="sxs-lookup"><span data-stu-id="efdc4-104">/json/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},json</span></span>
<span data-ttu-id="efdc4-105">ダウンロード、アップロード、またはファイルを削除します。</span><span class="sxs-lookup"><span data-stu-id="efdc4-105">Downloads, uploads, or deletes a file.</span></span> <span data-ttu-id="efdc4-106">これらの Uri のドメインが`titlestorage.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="efdc4-106">The domain for these URIs is `titlestorage.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="efdc4-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="efdc4-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="efdc4-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="efdc4-108">URI parameters</span></span>
 
| <span data-ttu-id="efdc4-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="efdc4-109">Parameter</span></span>| <span data-ttu-id="efdc4-110">型</span><span class="sxs-lookup"><span data-stu-id="efdc4-110">Type</span></span>| <span data-ttu-id="efdc4-111">説明</span><span class="sxs-lookup"><span data-stu-id="efdc4-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="efdc4-112">xuid</span><span class="sxs-lookup"><span data-stu-id="efdc4-112">xuid</span></span>| <span data-ttu-id="efdc4-113">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="efdc4-113">unsigned 64-bit integer</span></span>| <span data-ttu-id="efdc4-114">Xbox ユーザー ID を (XUID) プレイヤーの要求を行っているユーザー。</span><span class="sxs-lookup"><span data-stu-id="efdc4-114">The Xbox User ID (XUID) of the player who making the request.</span></span>| 
| <span data-ttu-id="efdc4-115">scid</span><span class="sxs-lookup"><span data-stu-id="efdc4-115">scid</span></span>| <span data-ttu-id="efdc4-116">guid</span><span class="sxs-lookup"><span data-stu-id="efdc4-116">guid</span></span>| <span data-ttu-id="efdc4-117">ルックアップ サービス構成の ID です。</span><span class="sxs-lookup"><span data-stu-id="efdc4-117">the ID of the service config to look up.</span></span>| 
| <span data-ttu-id="efdc4-118">pathAndFileName</span><span class="sxs-lookup"><span data-stu-id="efdc4-118">pathAndFileName</span></span>| <span data-ttu-id="efdc4-119">string</span><span class="sxs-lookup"><span data-stu-id="efdc4-119">string</span></span>| <span data-ttu-id="efdc4-120">アクセスできる項目のパスとファイルの名前です。</span><span class="sxs-lookup"><span data-stu-id="efdc4-120">Path and file name for the item to be accessed.</span></span> <span data-ttu-id="efdc4-121">パス部分 (となどを含む最終的なスラッシュ) の有効な文字が大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9)、アンダー スコア (_) を含めるし、スラッシュ (/)。パス部分を空にすることがあります。有効な文字 (すべての最終的なスラッシュ後) ファイル名の部分には、大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9) が含まれているアンダー スコア (_)、ピリオド (.)、およびハイフン (-)。</span><span class="sxs-lookup"><span data-stu-id="efdc4-121">Valid characters for the path portion (up to and including the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), and forward slash (/). The path portion may be empty. Valid characters for the file name portion (everything after the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), period (.), and hyphen (-).</span></span> <span data-ttu-id="efdc4-122">ファイル名を空にする可能性がありますはない期間の終了または 2 つの連続するピリオドが含まれてはします。</span><span class="sxs-lookup"><span data-stu-id="efdc4-122">The file name may not be empty, end in a period or contain two consecutive periods.</span></span>| 
  
<a id="ID4EFC"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="efdc4-123">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="efdc4-123">Valid methods</span></span>

[<span data-ttu-id="efdc4-124">DELETE</span><span class="sxs-lookup"><span data-stu-id="efdc4-124">DELETE</span></span>](uri-jsonusersxuidscidssciddatapathandfilenametype-delete.md)

<span data-ttu-id="efdc4-125">&nbsp;&nbsp;ファイルを削除します。</span><span class="sxs-lookup"><span data-stu-id="efdc4-125">&nbsp;&nbsp;Deletes a file.</span></span> 

[<span data-ttu-id="efdc4-126">GET</span><span class="sxs-lookup"><span data-stu-id="efdc4-126">GET</span></span>](uri-jsonusersxuidscidssciddatapathandfilenametype-get.md)

<span data-ttu-id="efdc4-127">&nbsp;&nbsp;ファイルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="efdc4-127">&nbsp;&nbsp;Downloads a file.</span></span>

[<span data-ttu-id="efdc4-128">PUT</span><span class="sxs-lookup"><span data-stu-id="efdc4-128">PUT</span></span>](uri-jsonusersxuidscidssciddatapathandfilenametype-put.md)

<span data-ttu-id="efdc4-129">&nbsp;&nbsp;ファイルをアップロードします。</span><span class="sxs-lookup"><span data-stu-id="efdc4-129">&nbsp;&nbsp;Uploads a file.</span></span> <span data-ttu-id="efdc4-130">Json の種類のデータの複数のブロックのアップロードはサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="efdc4-130">Multi-block upload is not supported for data of type json.</span></span> 
 
<a id="ID4EVC"></a>

 
## <a name="see-also"></a><span data-ttu-id="efdc4-131">関連項目</span><span class="sxs-lookup"><span data-stu-id="efdc4-131">See also</span></span>
 
<a id="ID4EXC"></a>

 
##### <a name="parent"></a><span data-ttu-id="efdc4-132">Parent</span><span class="sxs-lookup"><span data-stu-id="efdc4-132">Parent</span></span> 

[<span data-ttu-id="efdc4-133">タイトル ストレージ URI</span><span class="sxs-lookup"><span data-stu-id="efdc4-133">Title Storage URIs</span></span>](atoc-reference-storagev2.md)

   