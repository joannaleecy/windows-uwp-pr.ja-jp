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
ms.sourcegitcommit: a3dc929858415b933943bba5aa7487ffa721899f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/07/2018
ms.locfileid: "8795633"
---
# <a name="trustedplatformusersxuidxuidscidssciddatapathandfilenametype"></a><span data-ttu-id="a05e3-104">/trustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type}</span><span class="sxs-lookup"><span data-stu-id="a05e3-104">/trustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type}</span></span>
<span data-ttu-id="a05e3-105">ダウンロード、アップロード、またはファイルを削除します。</span><span class="sxs-lookup"><span data-stu-id="a05e3-105">Downloads, uploads, or deletes a file.</span></span> <span data-ttu-id="a05e3-106">これらの Uri のドメインが`titlestorage.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="a05e3-106">The domain for these URIs is `titlestorage.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="a05e3-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="a05e3-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="a05e3-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="a05e3-108">URI parameters</span></span>
 
| <span data-ttu-id="a05e3-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="a05e3-109">Parameter</span></span>| <span data-ttu-id="a05e3-110">型</span><span class="sxs-lookup"><span data-stu-id="a05e3-110">Type</span></span>| <span data-ttu-id="a05e3-111">説明</span><span class="sxs-lookup"><span data-stu-id="a05e3-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="a05e3-112">xuid</span><span class="sxs-lookup"><span data-stu-id="a05e3-112">xuid</span></span>| <span data-ttu-id="a05e3-113">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="a05e3-113">unsigned 64-bit integer</span></span>| <span data-ttu-id="a05e3-114">Xbox ユーザー ID を (XUID) プレイヤーの要求を行っているユーザー。</span><span class="sxs-lookup"><span data-stu-id="a05e3-114">The Xbox User ID (XUID) of the player who making the request.</span></span>| 
| <span data-ttu-id="a05e3-115">scid</span><span class="sxs-lookup"><span data-stu-id="a05e3-115">scid</span></span>| <span data-ttu-id="a05e3-116">guid</span><span class="sxs-lookup"><span data-stu-id="a05e3-116">guid</span></span>| <span data-ttu-id="a05e3-117">ルックアップ サービス構成の ID です。</span><span class="sxs-lookup"><span data-stu-id="a05e3-117">the ID of the service config to look up.</span></span>| 
| <span data-ttu-id="a05e3-118">pathAndFileName</span><span class="sxs-lookup"><span data-stu-id="a05e3-118">pathAndFileName</span></span>| <span data-ttu-id="a05e3-119">string</span><span class="sxs-lookup"><span data-stu-id="a05e3-119">string</span></span>| <span data-ttu-id="a05e3-120">アクセスできる項目のパスとファイルの名前です。</span><span class="sxs-lookup"><span data-stu-id="a05e3-120">Path and file name for the item to be accessed.</span></span> <span data-ttu-id="a05e3-121">パスの部分 (となどを含む最終的なスラッシュ) の有効な文字は大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9)、アンダー スコア (_) を含めるし、スラッシュ (/)。パス部分を空にすることがあります。有効な文字 (すべての最終的なスラッシュ後) ファイル名の部分には、大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9) が含まれているアンダー スコア (_)、ピリオド (.)、およびハイフン (-)。</span><span class="sxs-lookup"><span data-stu-id="a05e3-121">Valid characters for the path portion (up to and including the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), and forward slash (/). The path portion may be empty. Valid characters for the file name portion (everything after the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), period (.), and hyphen (-).</span></span> <span data-ttu-id="a05e3-122">ファイル名を空にすることがありますはいない期間の終了または 2 つの連続するピリオドが含まれてはします。</span><span class="sxs-lookup"><span data-stu-id="a05e3-122">The file name may not be empty, end in a period or contain two consecutive periods.</span></span>| 
| <span data-ttu-id="a05e3-123">type</span><span class="sxs-lookup"><span data-stu-id="a05e3-123">type</span></span>| <span data-ttu-id="a05e3-124">文字列</span><span class="sxs-lookup"><span data-stu-id="a05e3-124">string</span></span>| <span data-ttu-id="a05e3-125">データの形式です。</span><span class="sxs-lookup"><span data-stu-id="a05e3-125">The format of the data.</span></span> <span data-ttu-id="a05e3-126">使用可能な値とは、バイナリまたは json です。</span><span class="sxs-lookup"><span data-stu-id="a05e3-126">Possible values are binary or json.</span></span>| 
  
<a id="ID4EOC"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="a05e3-127">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="a05e3-127">Valid methods</span></span>

[<span data-ttu-id="a05e3-128">DELETE</span><span class="sxs-lookup"><span data-stu-id="a05e3-128">DELETE</span></span>](uri-trustedplatformusersxuidscidssciddatapathandfilenametype-delete.md)

<span data-ttu-id="a05e3-129">&nbsp;&nbsp;ファイルを削除します。</span><span class="sxs-lookup"><span data-stu-id="a05e3-129">&nbsp;&nbsp;Deletes a file.</span></span> 

[<span data-ttu-id="a05e3-130">GET</span><span class="sxs-lookup"><span data-stu-id="a05e3-130">GET</span></span>](uri-trustedplatformusersxuidscidssciddatapathandfilenametype-get.md)

<span data-ttu-id="a05e3-131">&nbsp;&nbsp;ファイルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="a05e3-131">&nbsp;&nbsp;Downloads a file.</span></span>

[<span data-ttu-id="a05e3-132">PUT</span><span class="sxs-lookup"><span data-stu-id="a05e3-132">PUT</span></span>](uri-trustedplatformusersxuidscidssciddatapathandfilenametype-put.md)

<span data-ttu-id="a05e3-133">&nbsp;&nbsp;ファイルをアップロードします。</span><span class="sxs-lookup"><span data-stu-id="a05e3-133">&nbsp;&nbsp;Uploads a file.</span></span> <span data-ttu-id="a05e3-134">データやメタデータが送信される 1 つのメッセージで、または一連の小さいブロックのデータやメタデータが送信される複数のブロック アップロードとして完全なアップロードでは、データをアップロードできます。</span><span class="sxs-lookup"><span data-stu-id="a05e3-134">The data can be uploaded in a full upload in which the data and metadata are sent in a single message, or as a multi-block upload in which the data and metadata are sent in a series of smaller blocks.</span></span> <span data-ttu-id="a05e3-135">1 つのメッセージとしては 4 つのメガバイトよりも小さいファイルのみを送信できます。</span><span class="sxs-lookup"><span data-stu-id="a05e3-135">Only files that are smaller than four megabytes can be sent as a single message.</span></span> <span data-ttu-id="a05e3-136">Json の種類のデータの複数のブロックのアップロードはサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="a05e3-136">Multi-block upload is not supported for data of type json.</span></span> 
 
<a id="ID4E5C"></a>

 
## <a name="see-also"></a><span data-ttu-id="a05e3-137">関連項目</span><span class="sxs-lookup"><span data-stu-id="a05e3-137">See also</span></span>
 
<a id="ID4EAD"></a>

 
##### <a name="parent"></a><span data-ttu-id="a05e3-138">Parent</span><span class="sxs-lookup"><span data-stu-id="a05e3-138">Parent</span></span> 

[<span data-ttu-id="a05e3-139">タイトル ストレージ URI</span><span class="sxs-lookup"><span data-stu-id="a05e3-139">Title Storage URIs</span></span>](atoc-reference-storagev2.md)

   