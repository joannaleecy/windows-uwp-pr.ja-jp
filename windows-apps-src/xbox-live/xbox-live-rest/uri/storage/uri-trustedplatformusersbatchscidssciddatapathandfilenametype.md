---
title: /trustedplatform/users/batch/scids/{scid}/data/{pathAndFileName},{type}
assetID: c92d247a-5ea1-7a06-36db-7c67a1dc3151
permalink: en-us/docs/xboxlive/rest/uri-trustedplatformusersbatchscidssciddatapathandfilenametype.html
description: " /trustedplatform/users/batch/scids/{scid}/data/{pathAndFileName},{type}"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 716632e355fd37512f6777f1b877f11280c689eb
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57661667"
---
# <a name="trustedplatformusersbatchscidssciddatapathandfilenametype"></a><span data-ttu-id="f858e-104">/trustedplatform/users/batch/scids/{scid}/data/{pathAndFileName},{type}</span><span class="sxs-lookup"><span data-stu-id="f858e-104">/trustedplatform/users/batch/scids/{scid}/data/{pathAndFileName},{type}</span></span>
<span data-ttu-id="f858e-105">同じファイル名を持つ複数のユーザーからは、複数のファイルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="f858e-105">Downloads multiple files from multiple users with the same filename.</span></span> <span data-ttu-id="f858e-106">これらの Uri のドメインが`titlestorage.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="f858e-106">The domain for these URIs is `titlestorage.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="f858e-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="f858e-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="f858e-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="f858e-108">URI parameters</span></span>
 
| <span data-ttu-id="f858e-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="f858e-109">Parameter</span></span>| <span data-ttu-id="f858e-110">種類</span><span class="sxs-lookup"><span data-stu-id="f858e-110">Type</span></span>| <span data-ttu-id="f858e-111">説明</span><span class="sxs-lookup"><span data-stu-id="f858e-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="f858e-112">scid</span><span class="sxs-lookup"><span data-stu-id="f858e-112">scid</span></span>| <span data-ttu-id="f858e-113">guid</span><span class="sxs-lookup"><span data-stu-id="f858e-113">guid</span></span>| <span data-ttu-id="f858e-114">検索するサービス構成の ID。</span><span class="sxs-lookup"><span data-stu-id="f858e-114">the ID of the service config to look up.</span></span>| 
| <span data-ttu-id="f858e-115">pathAndFileName</span><span class="sxs-lookup"><span data-stu-id="f858e-115">pathAndFileName</span></span>| <span data-ttu-id="f858e-116">string</span><span class="sxs-lookup"><span data-stu-id="f858e-116">string</span></span>| <span data-ttu-id="f858e-117">アクセスする項目のパスとファイル名。</span><span class="sxs-lookup"><span data-stu-id="f858e-117">Path and file name for the item to be accessed.</span></span> <span data-ttu-id="f858e-118">有効な文字 (最大、および最後のスラッシュを含む) のパス部分に含まれている大文字 (A ~ Z)、英小文字 (a ~ z)、数字 (0 ~ 9)、アンダー スコア (_)、スラッシュ (/) とします。パスの部分を空にすることがあります。有効な文字の大文字 (A ~ Z)、英小文字 (a ~ z)、数字 (0 ~ 9)、ファイル名の部分 (最後のスラッシュの後の部分すべて) が含まれているアンダー スコア (_)、ピリオド (.)、およびハイフン (-)。</span><span class="sxs-lookup"><span data-stu-id="f858e-118">Valid characters for the path portion (up to and including the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), and forward slash (/). The path portion may be empty. Valid characters for the file name portion (everything after the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), period (.), and hyphen (-).</span></span> <span data-ttu-id="f858e-119">ファイル名を空にする可能性がありますはいない末尾をピリオドまたは 2 つの連続するピリオドを含めることは。</span><span class="sxs-lookup"><span data-stu-id="f858e-119">The file name may not be empty, end in a period or contain two consecutive periods.</span></span>| 
| <span data-ttu-id="f858e-120">type</span><span class="sxs-lookup"><span data-stu-id="f858e-120">type</span></span>| <span data-ttu-id="f858e-121">string</span><span class="sxs-lookup"><span data-stu-id="f858e-121">string</span></span>| <span data-ttu-id="f858e-122">データの形式です。</span><span class="sxs-lookup"><span data-stu-id="f858e-122">The format of the data.</span></span> <span data-ttu-id="f858e-123">有効値とは、バイナリまたは json です。</span><span class="sxs-lookup"><span data-stu-id="f858e-123">Possible values are binary or json.</span></span>| 
  
<a id="ID4EFC"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="f858e-124">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="f858e-124">Valid methods</span></span>

[<span data-ttu-id="f858e-125">投稿</span><span class="sxs-lookup"><span data-stu-id="f858e-125">POST</span></span>](uri-trustedplatformusersbatchscidssciddatapathandfilenametype-post.md)

<span data-ttu-id="f858e-126">&nbsp;&nbsp;同じファイル名を持つ複数のユーザーからは、複数のファイルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="f858e-126">&nbsp;&nbsp;Downloads multiple files from multiple users with the same filename.</span></span>
 
<a id="ID4EPC"></a>

 
## <a name="see-also"></a><span data-ttu-id="f858e-127">関連項目</span><span class="sxs-lookup"><span data-stu-id="f858e-127">See also</span></span>
 
<a id="ID4ERC"></a>

 
##### <a name="parent"></a><span data-ttu-id="f858e-128">Parent</span><span class="sxs-lookup"><span data-stu-id="f858e-128">Parent</span></span> 

[<span data-ttu-id="f858e-129">ストレージ Uri のタイトル</span><span class="sxs-lookup"><span data-stu-id="f858e-129">Title Storage URIs</span></span>](atoc-reference-storagev2.md)

   