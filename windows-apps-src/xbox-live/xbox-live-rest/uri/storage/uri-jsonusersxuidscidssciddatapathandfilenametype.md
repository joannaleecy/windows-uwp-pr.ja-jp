---
title: /json/users/xuid({xuid})/scids/{scid} {scid}/data}、json
assetID: d004d715-d73c-693e-2a0b-ce64f482642b
permalink: en-us/docs/xboxlive/rest/uri-jsonusersxuidscidssciddatapathandfilenametype.html
author: KevinAsgari
description: " /json/users/xuid({xuid})/scids/{scid} {scid}/data}、json"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: fa553cce9ee3179f32573e00c1e215ab46e89b21
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3882087"
---
# <a name="jsonusersxuidxuidscidssciddatapathandfilenamejson"></a><span data-ttu-id="12d8e-104">/json/users/xuid({xuid})/scids/{scid} {scid}/data}、json</span><span class="sxs-lookup"><span data-stu-id="12d8e-104">/json/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},json</span></span>
<span data-ttu-id="12d8e-105">ダウンロード、アップロード、またはファイルを削除します。</span><span class="sxs-lookup"><span data-stu-id="12d8e-105">Downloads, uploads, or deletes a file.</span></span> <span data-ttu-id="12d8e-106">これらの Uri のドメインが`titlestorage.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="12d8e-106">The domain for these URIs is `titlestorage.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="12d8e-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="12d8e-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="12d8e-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="12d8e-108">URI parameters</span></span>
 
| <span data-ttu-id="12d8e-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="12d8e-109">Parameter</span></span>| <span data-ttu-id="12d8e-110">型</span><span class="sxs-lookup"><span data-stu-id="12d8e-110">Type</span></span>| <span data-ttu-id="12d8e-111">説明</span><span class="sxs-lookup"><span data-stu-id="12d8e-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="12d8e-112">xuid</span><span class="sxs-lookup"><span data-stu-id="12d8e-112">xuid</span></span>| <span data-ttu-id="12d8e-113">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="12d8e-113">unsigned 64-bit integer</span></span>| <span data-ttu-id="12d8e-114">Xbox ユーザー ID を (XUID)、プレイヤーの要求を行っているユーザー。</span><span class="sxs-lookup"><span data-stu-id="12d8e-114">The Xbox User ID (XUID) of the player who making the request.</span></span>| 
| <span data-ttu-id="12d8e-115">scid</span><span class="sxs-lookup"><span data-stu-id="12d8e-115">scid</span></span>| <span data-ttu-id="12d8e-116">guid</span><span class="sxs-lookup"><span data-stu-id="12d8e-116">guid</span></span>| <span data-ttu-id="12d8e-117">ルックアップ サービス構成の ID です。</span><span class="sxs-lookup"><span data-stu-id="12d8e-117">the ID of the service config to look up.</span></span>| 
| <span data-ttu-id="12d8e-118">pathAndFileName</span><span class="sxs-lookup"><span data-stu-id="12d8e-118">pathAndFileName</span></span>| <span data-ttu-id="12d8e-119">string</span><span class="sxs-lookup"><span data-stu-id="12d8e-119">string</span></span>| <span data-ttu-id="12d8e-120">アクセスする項目のパスとファイル名。</span><span class="sxs-lookup"><span data-stu-id="12d8e-120">Path and file name for the item to be accessed.</span></span> <span data-ttu-id="12d8e-121">パス部分 (となどを含む最終的なスラッシュ) の有効な文字が大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9)、アンダー スコア (_) を含めるし、スラッシュ (/)。パス部分を空にすることがあります。有効な文字 (すべての最終的なスラッシュ後) ファイル名の部分には、大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9) が含まれているアンダー スコア (_)、ピリオド (.)、およびハイフン (-)。</span><span class="sxs-lookup"><span data-stu-id="12d8e-121">Valid characters for the path portion (up to and including the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), and forward slash (/). The path portion may be empty. Valid characters for the file name portion (everything after the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), period (.), and hyphen (-).</span></span> <span data-ttu-id="12d8e-122">ファイル名を空にする場合がありますはいない期間の終了または 2 つの連続するピリオドが含まれては。</span><span class="sxs-lookup"><span data-stu-id="12d8e-122">The file name may not be empty, end in a period or contain two consecutive periods.</span></span>| 
  
<a id="ID4EFC"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="12d8e-123">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="12d8e-123">Valid methods</span></span>

[<span data-ttu-id="12d8e-124">DELETE</span><span class="sxs-lookup"><span data-stu-id="12d8e-124">DELETE</span></span>](uri-jsonusersxuidscidssciddatapathandfilenametype-delete.md)

<span data-ttu-id="12d8e-125">&nbsp;&nbsp;ファイルを削除します。</span><span class="sxs-lookup"><span data-stu-id="12d8e-125">&nbsp;&nbsp;Deletes a file.</span></span> 

[<span data-ttu-id="12d8e-126">GET</span><span class="sxs-lookup"><span data-stu-id="12d8e-126">GET</span></span>](uri-jsonusersxuidscidssciddatapathandfilenametype-get.md)

<span data-ttu-id="12d8e-127">&nbsp;&nbsp;ファイルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="12d8e-127">&nbsp;&nbsp;Downloads a file.</span></span>

[<span data-ttu-id="12d8e-128">PUT</span><span class="sxs-lookup"><span data-stu-id="12d8e-128">PUT</span></span>](uri-jsonusersxuidscidssciddatapathandfilenametype-put.md)

<span data-ttu-id="12d8e-129">&nbsp;&nbsp;ファイルをアップロードします。</span><span class="sxs-lookup"><span data-stu-id="12d8e-129">&nbsp;&nbsp;Uploads a file.</span></span> <span data-ttu-id="12d8e-130">複数のブロックのアップロードの種類の json データはサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="12d8e-130">Multi-block upload is not supported for data of type json.</span></span> 
 
<a id="ID4EVC"></a>

 
## <a name="see-also"></a><span data-ttu-id="12d8e-131">関連項目</span><span class="sxs-lookup"><span data-stu-id="12d8e-131">See also</span></span>
 
<a id="ID4EXC"></a>

 
##### <a name="parent"></a><span data-ttu-id="12d8e-132">Parent</span><span class="sxs-lookup"><span data-stu-id="12d8e-132">Parent</span></span> 

[<span data-ttu-id="12d8e-133">タイトル ストレージ Uri</span><span class="sxs-lookup"><span data-stu-id="12d8e-133">Title Storage URIs</span></span>](atoc-reference-storagev2.md)

   