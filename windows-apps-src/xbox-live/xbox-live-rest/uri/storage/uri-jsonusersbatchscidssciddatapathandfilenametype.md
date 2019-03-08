---
title: /json/users/batch/scids/{scid}/data/{pathAndFileName},json
assetID: 06ae159f-7739-1330-df15-871d260e6ba1
permalink: en-us/docs/xboxlive/rest/uri-jsonusersbatchscidssciddatapathandfilenametype.html
description: " /json/users/batch/scids/{scid}/data/{pathAndFileName},json"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 2b28b0faad1c321137344455bc7cd471f7cb6eba
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57598597"
---
# <a name="jsonusersbatchscidssciddatapathandfilenamejson"></a><span data-ttu-id="fce77-104">/json/users/batch/scids/{scid}/data/{pathAndFileName},json</span><span class="sxs-lookup"><span data-stu-id="fce77-104">/json/users/batch/scids/{scid}/data/{pathAndFileName},json</span></span>
<span data-ttu-id="fce77-105">同じファイル名を持つ複数のユーザーからは、複数のファイルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="fce77-105">Downloads multiple files from multiple users with the same filename.</span></span> <span data-ttu-id="fce77-106">これらの Uri のドメインが`titlestorage.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="fce77-106">The domain for these URIs is `titlestorage.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="fce77-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="fce77-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="fce77-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="fce77-108">URI parameters</span></span>
 
| <span data-ttu-id="fce77-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="fce77-109">Parameter</span></span>| <span data-ttu-id="fce77-110">種類</span><span class="sxs-lookup"><span data-stu-id="fce77-110">Type</span></span>| <span data-ttu-id="fce77-111">説明</span><span class="sxs-lookup"><span data-stu-id="fce77-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="fce77-112">scid</span><span class="sxs-lookup"><span data-stu-id="fce77-112">scid</span></span>| <span data-ttu-id="fce77-113">guid</span><span class="sxs-lookup"><span data-stu-id="fce77-113">guid</span></span>| <span data-ttu-id="fce77-114">検索するサービス構成の ID。</span><span class="sxs-lookup"><span data-stu-id="fce77-114">the ID of the service config to look up.</span></span>| 
| <span data-ttu-id="fce77-115">pathAndFileName</span><span class="sxs-lookup"><span data-stu-id="fce77-115">pathAndFileName</span></span>| <span data-ttu-id="fce77-116">string</span><span class="sxs-lookup"><span data-stu-id="fce77-116">string</span></span>| <span data-ttu-id="fce77-117">アクセスする項目のパスとファイル名。</span><span class="sxs-lookup"><span data-stu-id="fce77-117">Path and file name for the item to be accessed.</span></span> <span data-ttu-id="fce77-118">有効な文字 (最大、および最後のスラッシュを含む) のパス部分に含まれている大文字 (A ~ Z)、英小文字 (a ~ z)、数字 (0 ~ 9)、アンダー スコア (_)、スラッシュ (/) とします。パスの部分を空にすることがあります。有効な文字の大文字 (A ~ Z)、英小文字 (a ~ z)、数字 (0 ~ 9)、ファイル名の部分 (最後のスラッシュの後の部分すべて) が含まれているアンダー スコア (_)、ピリオド (.)、およびハイフン (-)。</span><span class="sxs-lookup"><span data-stu-id="fce77-118">Valid characters for the path portion (up to and including the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), and forward slash (/). The path portion may be empty. Valid characters for the file name portion (everything after the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), period (.), and hyphen (-).</span></span> <span data-ttu-id="fce77-119">ファイル名を空にする可能性がありますはいない末尾をピリオドまたは 2 つの連続するピリオドを含めることは。</span><span class="sxs-lookup"><span data-stu-id="fce77-119">The file name may not be empty, end in a period or contain two consecutive periods.</span></span>| 
  
<a id="ID4E3B"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="fce77-120">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="fce77-120">Valid methods</span></span>

[<span data-ttu-id="fce77-121">投稿</span><span class="sxs-lookup"><span data-stu-id="fce77-121">POST</span></span>](uri-jsonusersbatchscidssciddatapathandfilenametype-post.md)

<span data-ttu-id="fce77-122">&nbsp;&nbsp;同じファイル名を持つ複数のユーザーからは、複数のファイルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="fce77-122">&nbsp;&nbsp;Downloads multiple files from multiple users with the same filename.</span></span> <span data-ttu-id="fce77-123">ファイルのダウンロードは、要求の URI によって決定されます。</span><span class="sxs-lookup"><span data-stu-id="fce77-123">The file to be downloaded is determined by the URI of the request.</span></span> <span data-ttu-id="fce77-124">要求の本文には、ダウンロードするファイル持つには Xuid、ユーザーの一覧が含まれています。</span><span class="sxs-lookup"><span data-stu-id="fce77-124">The body of the request contains the list of XUIDs of the users whose files to download.</span></span> <span data-ttu-id="fce77-125">応答の本文を各要素は、独自のヘッダーのセットを特定のユーザーのファイルを表す、マルチパート MIME メッセージとなります。</span><span class="sxs-lookup"><span data-stu-id="fce77-125">The body of the response will be a multi-part MIME message, with each part representing a file for a particular user with its own set of headers.</span></span> <span data-ttu-id="fce77-126">成功と失敗の組み合わせに対する応答の部分のことができます。</span><span class="sxs-lookup"><span data-stu-id="fce77-126">It's possible for the parts of the response to be a mix of successes and failures.</span></span>
 
<a id="ID4EGC"></a>

 
## <a name="see-also"></a><span data-ttu-id="fce77-127">関連項目</span><span class="sxs-lookup"><span data-stu-id="fce77-127">See also</span></span>
 
<a id="ID4EIC"></a>

 
##### <a name="parent"></a><span data-ttu-id="fce77-128">Parent</span><span class="sxs-lookup"><span data-stu-id="fce77-128">Parent</span></span> 

[<span data-ttu-id="fce77-129">ストレージ Uri のタイトル</span><span class="sxs-lookup"><span data-stu-id="fce77-129">Title Storage URIs</span></span>](atoc-reference-storagev2.md)

   