---
title: /untrustedplatform/users/batch/scids/{scid}/data/{pathAndFileName},{type}
assetID: c2909e75-e108-3555-c157-f2d552f10e9f
permalink: en-us/docs/xboxlive/rest/uri-untrustedplatformusersbatchscidssciddatapathandfilenametype.html
description: " /untrustedplatform/users/batch/scids/{scid}/data/{pathAndFileName},{type}"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: bc57ce4cd80a33b831be3eb3615489cec5a633b2
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57599737"
---
# <a name="untrustedplatformusersbatchscidssciddatapathandfilenametype"></a><span data-ttu-id="211ab-104">/untrustedplatform/users/batch/scids/{scid}/data/{pathAndFileName},{type}</span><span class="sxs-lookup"><span data-stu-id="211ab-104">/untrustedplatform/users/batch/scids/{scid}/data/{pathAndFileName},{type}</span></span>
<span data-ttu-id="211ab-105">同じファイル名を持つ複数のユーザーからは、複数のファイルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="211ab-105">Downloads multiple files from multiple users with the same filename.</span></span> <span data-ttu-id="211ab-106">これらの Uri のドメインが`titlestorage.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="211ab-106">The domain for these URIs is `titlestorage.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="211ab-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="211ab-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="211ab-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="211ab-108">URI parameters</span></span>
 
| <span data-ttu-id="211ab-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="211ab-109">Parameter</span></span>| <span data-ttu-id="211ab-110">種類</span><span class="sxs-lookup"><span data-stu-id="211ab-110">Type</span></span>| <span data-ttu-id="211ab-111">説明</span><span class="sxs-lookup"><span data-stu-id="211ab-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="211ab-112">scid</span><span class="sxs-lookup"><span data-stu-id="211ab-112">scid</span></span>| <span data-ttu-id="211ab-113">guid</span><span class="sxs-lookup"><span data-stu-id="211ab-113">guid</span></span>| <span data-ttu-id="211ab-114">検索するサービス構成の ID。</span><span class="sxs-lookup"><span data-stu-id="211ab-114">the ID of the service config to look up.</span></span>| 
| <span data-ttu-id="211ab-115">pathAndFileName</span><span class="sxs-lookup"><span data-stu-id="211ab-115">pathAndFileName</span></span>| <span data-ttu-id="211ab-116">string</span><span class="sxs-lookup"><span data-stu-id="211ab-116">string</span></span>| <span data-ttu-id="211ab-117">アクセスする項目のパスとファイル名。</span><span class="sxs-lookup"><span data-stu-id="211ab-117">Path and file name for the item to be accessed.</span></span> <span data-ttu-id="211ab-118">有効な文字 (最大、および最後のスラッシュを含む) のパス部分に含まれている大文字 (A ~ Z)、英小文字 (a ~ z)、数字 (0 ~ 9)、アンダー スコア (_)、スラッシュ (/) とします。パスの部分を空にすることがあります。有効な文字の大文字 (A ~ Z)、英小文字 (a ~ z)、数字 (0 ~ 9)、ファイル名の部分 (最後のスラッシュの後の部分すべて) が含まれているアンダー スコア (_)、ピリオド (.)、およびハイフン (-)。</span><span class="sxs-lookup"><span data-stu-id="211ab-118">Valid characters for the path portion (up to and including the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), and forward slash (/). The path portion may be empty. Valid characters for the file name portion (everything after the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), period (.), and hyphen (-).</span></span> <span data-ttu-id="211ab-119">ファイル名を空にする可能性がありますはいない末尾をピリオドまたは 2 つの連続するピリオドを含めることは。</span><span class="sxs-lookup"><span data-stu-id="211ab-119">The file name may not be empty, end in a period or contain two consecutive periods.</span></span>| 
| <span data-ttu-id="211ab-120">type</span><span class="sxs-lookup"><span data-stu-id="211ab-120">type</span></span>| <span data-ttu-id="211ab-121">string</span><span class="sxs-lookup"><span data-stu-id="211ab-121">string</span></span>| <span data-ttu-id="211ab-122">データの形式です。</span><span class="sxs-lookup"><span data-stu-id="211ab-122">The format of the data.</span></span> <span data-ttu-id="211ab-123">使用可能な値は、バイナリの json です。</span><span class="sxs-lookup"><span data-stu-id="211ab-123">Possible values are binary json.</span></span>| 
  
<a id="ID4EFC"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="211ab-124">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="211ab-124">Valid methods</span></span>

[<span data-ttu-id="211ab-125">投稿</span><span class="sxs-lookup"><span data-stu-id="211ab-125">POST</span></span>](uri-untrustedplatformusersbatchscidssciddatapathandfilenametype-post.md)

<span data-ttu-id="211ab-126">&nbsp;&nbsp;同じファイル名を持つ複数のユーザーからは、複数のファイルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="211ab-126">&nbsp;&nbsp;Downloads multiple files from multiple users with the same filename.</span></span>
 
<a id="ID4EPC"></a>

 
## <a name="see-also"></a><span data-ttu-id="211ab-127">関連項目</span><span class="sxs-lookup"><span data-stu-id="211ab-127">See also</span></span>
 
<a id="ID4ERC"></a>

 
##### <a name="parent"></a><span data-ttu-id="211ab-128">Parent</span><span class="sxs-lookup"><span data-stu-id="211ab-128">Parent</span></span> 

[<span data-ttu-id="211ab-129">ストレージ Uri のタイトル</span><span class="sxs-lookup"><span data-stu-id="211ab-129">Title Storage URIs</span></span>](atoc-reference-storagev2.md)

   