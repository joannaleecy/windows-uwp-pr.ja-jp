---
title: /json/users/batch/scids/{scid}/data/{pathAndFileName},json
assetID: 06ae159f-7739-1330-df15-871d260e6ba1
permalink: en-us/docs/xboxlive/rest/uri-jsonusersbatchscidssciddatapathandfilenametype.html
author: KevinAsgari
description: " /json/users/batch/scids/{scid}/data/{pathAndFileName},json"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 91b78ea9e4d1f2de1e8987a57ba87b5db6a0b923
ms.sourcegitcommit: e814a13978f33654d8e995584f4b047cb53e0aef
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/06/2018
ms.locfileid: "6049938"
---
# <a name="jsonusersbatchscidssciddatapathandfilenamejson"></a><span data-ttu-id="b0827-104">/json/users/batch/scids/{scid}/data/{pathAndFileName},json</span><span class="sxs-lookup"><span data-stu-id="b0827-104">/json/users/batch/scids/{scid}/data/{pathAndFileName},json</span></span>
<span data-ttu-id="b0827-105">同じファイル名を持つ複数のユーザーからは、複数のファイルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="b0827-105">Downloads multiple files from multiple users with the same filename.</span></span> <span data-ttu-id="b0827-106">これらの Uri のドメインが`titlestorage.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="b0827-106">The domain for these URIs is `titlestorage.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="b0827-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="b0827-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="b0827-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="b0827-108">URI parameters</span></span>
 
| <span data-ttu-id="b0827-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="b0827-109">Parameter</span></span>| <span data-ttu-id="b0827-110">型</span><span class="sxs-lookup"><span data-stu-id="b0827-110">Type</span></span>| <span data-ttu-id="b0827-111">説明</span><span class="sxs-lookup"><span data-stu-id="b0827-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="b0827-112">scid</span><span class="sxs-lookup"><span data-stu-id="b0827-112">scid</span></span>| <span data-ttu-id="b0827-113">guid</span><span class="sxs-lookup"><span data-stu-id="b0827-113">guid</span></span>| <span data-ttu-id="b0827-114">ルックアップ サービス構成の ID です。</span><span class="sxs-lookup"><span data-stu-id="b0827-114">the ID of the service config to look up.</span></span>| 
| <span data-ttu-id="b0827-115">pathAndFileName</span><span class="sxs-lookup"><span data-stu-id="b0827-115">pathAndFileName</span></span>| <span data-ttu-id="b0827-116">string</span><span class="sxs-lookup"><span data-stu-id="b0827-116">string</span></span>| <span data-ttu-id="b0827-117">アクセスできる項目のパスとファイルの名前です。</span><span class="sxs-lookup"><span data-stu-id="b0827-117">Path and file name for the item to be accessed.</span></span> <span data-ttu-id="b0827-118">パス部分 (となどを含む最終的なスラッシュ) の有効な文字が大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9)、アンダー スコア (_) を含めるし、スラッシュ (/)。パス部分を空にすることがあります。有効な文字 (すべての最終的なスラッシュ後) ファイル名の部分には、大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9) が含まれているアンダー スコア (_)、ピリオド (.)、およびハイフン (-)。</span><span class="sxs-lookup"><span data-stu-id="b0827-118">Valid characters for the path portion (up to and including the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), and forward slash (/). The path portion may be empty. Valid characters for the file name portion (everything after the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), period (.), and hyphen (-).</span></span> <span data-ttu-id="b0827-119">ファイル名を空にする可能性がありますはない期間の終了または 2 つの連続するピリオドが含まれてはします。</span><span class="sxs-lookup"><span data-stu-id="b0827-119">The file name may not be empty, end in a period or contain two consecutive periods.</span></span>| 
  
<a id="ID4E3B"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="b0827-120">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="b0827-120">Valid methods</span></span>

[<span data-ttu-id="b0827-121">POST</span><span class="sxs-lookup"><span data-stu-id="b0827-121">POST</span></span>](uri-jsonusersbatchscidssciddatapathandfilenametype-post.md)

<span data-ttu-id="b0827-122">&nbsp;&nbsp;同じファイル名を持つ複数のユーザーからは、複数のファイルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="b0827-122">&nbsp;&nbsp;Downloads multiple files from multiple users with the same filename.</span></span> <span data-ttu-id="b0827-123">ファイルのダウンロードについては、要求の URI によって決まります。</span><span class="sxs-lookup"><span data-stu-id="b0827-123">The file to be downloaded is determined by the URI of the request.</span></span> <span data-ttu-id="b0827-124">要求の本文には、ダウンロードするファイル持つにはユーザーの Xuid のリストが含まれています。</span><span class="sxs-lookup"><span data-stu-id="b0827-124">The body of the request contains the list of XUIDs of the users whose files to download.</span></span> <span data-ttu-id="b0827-125">応答の本文が含まれるマルチパート MIME メッセージ、独自のヘッダーのセットを特定のユーザーのファイルを表す、各部分になります。</span><span class="sxs-lookup"><span data-stu-id="b0827-125">The body of the response will be a multi-part MIME message, with each part representing a file for a particular user with its own set of headers.</span></span> <span data-ttu-id="b0827-126">成功と失敗の混在する応答の部分のことができます。</span><span class="sxs-lookup"><span data-stu-id="b0827-126">It's possible for the parts of the response to be a mix of successes and failures.</span></span>
 
<a id="ID4EGC"></a>

 
## <a name="see-also"></a><span data-ttu-id="b0827-127">関連項目</span><span class="sxs-lookup"><span data-stu-id="b0827-127">See also</span></span>
 
<a id="ID4EIC"></a>

 
##### <a name="parent"></a><span data-ttu-id="b0827-128">Parent</span><span class="sxs-lookup"><span data-stu-id="b0827-128">Parent</span></span> 

[<span data-ttu-id="b0827-129">タイトル ストレージ URI</span><span class="sxs-lookup"><span data-stu-id="b0827-129">Title Storage URIs</span></span>](atoc-reference-storagev2.md)

   