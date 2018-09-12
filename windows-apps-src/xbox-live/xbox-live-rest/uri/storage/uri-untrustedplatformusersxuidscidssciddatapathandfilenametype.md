---
title: /untrustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName} {型}
assetID: f7de98c3-e6d1-2c40-00f0-d45e418af8bf
permalink: en-us/docs/xboxlive/rest/uri-untrustedplatformusersxuidscidssciddatapathandfilenametype.html
author: KevinAsgari
description: " /untrustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName} {型}"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 82d1978571f07ac3122c4e2ed0062ed9439e974d
ms.sourcegitcommit: 2a63ee6770413bc35ace09b14f56b60007be7433
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3931023"
---
# <a name="untrustedplatformusersxuidxuidscidssciddatapathandfilenametype"></a><span data-ttu-id="bc287-104">/untrustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName} {型}</span><span class="sxs-lookup"><span data-stu-id="bc287-104">/untrustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type}</span></span>
<span data-ttu-id="bc287-105">ダウンロード、アップロード、またはファイルを削除します。</span><span class="sxs-lookup"><span data-stu-id="bc287-105">Downloads, uploads, or deletes a file.</span></span> <span data-ttu-id="bc287-106">これらの Uri のドメインが`titlestorage.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="bc287-106">The domain for these URIs is `titlestorage.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="bc287-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="bc287-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="bc287-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="bc287-108">URI parameters</span></span>
 
| <span data-ttu-id="bc287-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="bc287-109">Parameter</span></span>| <span data-ttu-id="bc287-110">型</span><span class="sxs-lookup"><span data-stu-id="bc287-110">Type</span></span>| <span data-ttu-id="bc287-111">説明</span><span class="sxs-lookup"><span data-stu-id="bc287-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="bc287-112">xuid</span><span class="sxs-lookup"><span data-stu-id="bc287-112">xuid</span></span>| <span data-ttu-id="bc287-113">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="bc287-113">unsigned 64-bit integer</span></span>| <span data-ttu-id="bc287-114">Xbox ユーザー ID を (XUID) プレイヤーの要求を行っているユーザー。</span><span class="sxs-lookup"><span data-stu-id="bc287-114">The Xbox User ID (XUID) of the player who making the request.</span></span>| 
| <span data-ttu-id="bc287-115">scid</span><span class="sxs-lookup"><span data-stu-id="bc287-115">scid</span></span>| <span data-ttu-id="bc287-116">guid</span><span class="sxs-lookup"><span data-stu-id="bc287-116">guid</span></span>| <span data-ttu-id="bc287-117">ルックアップ サービス構成の ID です。</span><span class="sxs-lookup"><span data-stu-id="bc287-117">the ID of the service config to look up.</span></span>| 
| <span data-ttu-id="bc287-118">pathAndFileName</span><span class="sxs-lookup"><span data-stu-id="bc287-118">pathAndFileName</span></span>| <span data-ttu-id="bc287-119">string</span><span class="sxs-lookup"><span data-stu-id="bc287-119">string</span></span>| <span data-ttu-id="bc287-120">アクセスできる項目のパスとファイル名。</span><span class="sxs-lookup"><span data-stu-id="bc287-120">Path and file name for the item to be accessed.</span></span> <span data-ttu-id="bc287-121">(となどを含む最終的なスラッシュ) のパス部分に有効な文字は大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9)、アンダー スコア (_) を含めるし、スラッシュ (/)。パス部分を空にすることがあります。有効な文字 (すべての最終的なスラッシュ後) ファイル名の部分には、大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9) が含まれているアンダー スコア (_)、ピリオド (.)、およびハイフン (-)。</span><span class="sxs-lookup"><span data-stu-id="bc287-121">Valid characters for the path portion (up to and including the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), and forward slash (/). The path portion may be empty. Valid characters for the file name portion (everything after the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), period (.), and hyphen (-).</span></span> <span data-ttu-id="bc287-122">ファイル名可能性がありますいないを空にする、期間の終了または 2 つの連続するピリオドが含まれています。</span><span class="sxs-lookup"><span data-stu-id="bc287-122">The file name may not be empty, end in a period or contain two consecutive periods.</span></span>| 
| <span data-ttu-id="bc287-123">type</span><span class="sxs-lookup"><span data-stu-id="bc287-123">type</span></span>| <span data-ttu-id="bc287-124">文字列</span><span class="sxs-lookup"><span data-stu-id="bc287-124">string</span></span>| <span data-ttu-id="bc287-125">データの形式です。</span><span class="sxs-lookup"><span data-stu-id="bc287-125">The format of the data.</span></span> <span data-ttu-id="bc287-126">可能な値は、バイナリまたは json です。</span><span class="sxs-lookup"><span data-stu-id="bc287-126">Possible values are binary or json.</span></span>| 
  
<a id="ID4EOC"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="bc287-127">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="bc287-127">Valid methods</span></span>

[<span data-ttu-id="bc287-128">DELETE</span><span class="sxs-lookup"><span data-stu-id="bc287-128">DELETE</span></span>](uri-untrustedplatformusersxuidscidssciddatapathandfilenametype-delete.md)

<span data-ttu-id="bc287-129">&nbsp;&nbsp;ファイルを削除します。</span><span class="sxs-lookup"><span data-stu-id="bc287-129">&nbsp;&nbsp;Deletes a file.</span></span> 

[<span data-ttu-id="bc287-130">GET</span><span class="sxs-lookup"><span data-stu-id="bc287-130">GET</span></span>](uri-untrustedplatformusersxuidscidssciddatapathandfilenametype-get.md)

<span data-ttu-id="bc287-131">&nbsp;&nbsp;ファイルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="bc287-131">&nbsp;&nbsp;Downloads a file.</span></span>

[<span data-ttu-id="bc287-132">PUT</span><span class="sxs-lookup"><span data-stu-id="bc287-132">PUT</span></span>](uri-untrustedplatformusersxuidscidssciddatapathandfilenametype-put.md)

<span data-ttu-id="bc287-133">&nbsp;&nbsp;ファイルをアップロードします。</span><span class="sxs-lookup"><span data-stu-id="bc287-133">&nbsp;&nbsp;Uploads a file.</span></span> <span data-ttu-id="bc287-134">データやメタデータが送信される 1 つのメッセージで、または一連の小さいブロックのデータやメタデータが送信される複数のブロック アップロードとして完全なアップロードでは、データをアップロードできます。</span><span class="sxs-lookup"><span data-stu-id="bc287-134">The data can be uploaded in a full upload in which the data and metadata are sent in a single message, or as a multi-block upload in which the data and metadata are sent in a series of smaller blocks.</span></span> <span data-ttu-id="bc287-135">単一のメッセージとしては 4 つのメガバイト数よりも小さいファイルのみを送信できます。</span><span class="sxs-lookup"><span data-stu-id="bc287-135">Only files that are smaller than four megabytes can be sent as a single message.</span></span> <span data-ttu-id="bc287-136">Json の種類のデータの複数のブロックのアップロードはサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="bc287-136">Multi-block upload is not supported for data of type json.</span></span> 
 
<a id="ID4E5C"></a>

 
## <a name="see-also"></a><span data-ttu-id="bc287-137">関連項目</span><span class="sxs-lookup"><span data-stu-id="bc287-137">See also</span></span>
 
<a id="ID4EAD"></a>

 
##### <a name="parent"></a><span data-ttu-id="bc287-138">Parent</span><span class="sxs-lookup"><span data-stu-id="bc287-138">Parent</span></span> 

[<span data-ttu-id="bc287-139">タイトル ストレージ Uri</span><span class="sxs-lookup"><span data-stu-id="bc287-139">Title Storage URIs</span></span>](atoc-reference-storagev2.md)

   