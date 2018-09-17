---
title: /json/users/batch/scids/{scid}/data/{pathAndFileName},json
assetID: 06ae159f-7739-1330-df15-871d260e6ba1
permalink: en-us/docs/xboxlive/rest/uri-jsonusersbatchscidssciddatapathandfilenametype.html
author: KevinAsgari
description: " /json/users/batch/scids/{scid}/data/{pathAndFileName},json"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 8b620144bbeee783835f5bf9181381a4c9b38a66
ms.sourcegitcommit: 9e2c34a5ed3134aeca7eb9490f05b20eb9a3e5df
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/17/2018
ms.locfileid: "3985556"
---
# <a name="jsonusersbatchscidssciddatapathandfilenamejson"></a><span data-ttu-id="2a641-104">/json/users/batch/scids/{scid}/data/{pathAndFileName},json</span><span class="sxs-lookup"><span data-stu-id="2a641-104">/json/users/batch/scids/{scid}/data/{pathAndFileName},json</span></span>
<span data-ttu-id="2a641-105">同じファイル名を持つ複数のユーザーから複数のファイルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="2a641-105">Downloads multiple files from multiple users with the same filename.</span></span> <span data-ttu-id="2a641-106">これらの Uri のドメインが`titlestorage.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="2a641-106">The domain for these URIs is `titlestorage.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="2a641-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="2a641-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="2a641-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="2a641-108">URI parameters</span></span>
 
| <span data-ttu-id="2a641-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="2a641-109">Parameter</span></span>| <span data-ttu-id="2a641-110">型</span><span class="sxs-lookup"><span data-stu-id="2a641-110">Type</span></span>| <span data-ttu-id="2a641-111">説明</span><span class="sxs-lookup"><span data-stu-id="2a641-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="2a641-112">scid</span><span class="sxs-lookup"><span data-stu-id="2a641-112">scid</span></span>| <span data-ttu-id="2a641-113">guid</span><span class="sxs-lookup"><span data-stu-id="2a641-113">guid</span></span>| <span data-ttu-id="2a641-114">ルックアップ サービス構成の ID です。</span><span class="sxs-lookup"><span data-stu-id="2a641-114">the ID of the service config to look up.</span></span>| 
| <span data-ttu-id="2a641-115">pathAndFileName</span><span class="sxs-lookup"><span data-stu-id="2a641-115">pathAndFileName</span></span>| <span data-ttu-id="2a641-116">string</span><span class="sxs-lookup"><span data-stu-id="2a641-116">string</span></span>| <span data-ttu-id="2a641-117">アクセスできる項目のパスとファイル名。</span><span class="sxs-lookup"><span data-stu-id="2a641-117">Path and file name for the item to be accessed.</span></span> <span data-ttu-id="2a641-118">パス部分 (となどを含む最終的なスラッシュ) の有効な文字が大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9)、アンダー スコア (_) を含めるし、スラッシュ (/)。パス部分を空にすることがあります。有効な文字 (すべての最終的なスラッシュ後) ファイル名の部分には、大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9) が含まれているアンダー スコア (_)、ピリオド (.)、およびハイフン (-)。</span><span class="sxs-lookup"><span data-stu-id="2a641-118">Valid characters for the path portion (up to and including the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), and forward slash (/). The path portion may be empty. Valid characters for the file name portion (everything after the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), period (.), and hyphen (-).</span></span> <span data-ttu-id="2a641-119">ファイル名可能性がありますいないを空にする、期間の終了または 2 つの連続するピリオドが含まれています。</span><span class="sxs-lookup"><span data-stu-id="2a641-119">The file name may not be empty, end in a period or contain two consecutive periods.</span></span>| 
  
<a id="ID4E3B"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="2a641-120">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="2a641-120">Valid methods</span></span>

[<span data-ttu-id="2a641-121">POST</span><span class="sxs-lookup"><span data-stu-id="2a641-121">POST</span></span>](uri-jsonusersbatchscidssciddatapathandfilenametype-post.md)

<span data-ttu-id="2a641-122">&nbsp;&nbsp;同じファイル名を持つ複数のユーザーから複数のファイルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="2a641-122">&nbsp;&nbsp;Downloads multiple files from multiple users with the same filename.</span></span> <span data-ttu-id="2a641-123">ファイルのダウンロードについては、要求の URI によって決まります。</span><span class="sxs-lookup"><span data-stu-id="2a641-123">The file to be downloaded is determined by the URI of the request.</span></span> <span data-ttu-id="2a641-124">要求の本文には、ダウンロードするファイル持つにはユーザーの Xuid のリストが含まれています。</span><span class="sxs-lookup"><span data-stu-id="2a641-124">The body of the request contains the list of XUIDs of the users whose files to download.</span></span> <span data-ttu-id="2a641-125">応答の本文が含まれるマルチパート MIME メッセージ、独自のヘッダーのセットを特定のユーザーのファイルを表す各部分になります。</span><span class="sxs-lookup"><span data-stu-id="2a641-125">The body of the response will be a multi-part MIME message, with each part representing a file for a particular user with its own set of headers.</span></span> <span data-ttu-id="2a641-126">成功と失敗のミックスする応答の部分のことができます。</span><span class="sxs-lookup"><span data-stu-id="2a641-126">It's possible for the parts of the response to be a mix of successes and failures.</span></span>
 
<a id="ID4EGC"></a>

 
## <a name="see-also"></a><span data-ttu-id="2a641-127">関連項目</span><span class="sxs-lookup"><span data-stu-id="2a641-127">See also</span></span>
 
<a id="ID4EIC"></a>

 
##### <a name="parent"></a><span data-ttu-id="2a641-128">Parent</span><span class="sxs-lookup"><span data-stu-id="2a641-128">Parent</span></span> 

[<span data-ttu-id="2a641-129">タイトル ストレージ URI</span><span class="sxs-lookup"><span data-stu-id="2a641-129">Title Storage URIs</span></span>](atoc-reference-storagev2.md)

   