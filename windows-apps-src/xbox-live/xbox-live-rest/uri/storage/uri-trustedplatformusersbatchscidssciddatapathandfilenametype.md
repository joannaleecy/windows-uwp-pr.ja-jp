---
title: /trustedplatform/users/batch/scids/{scid}/data/{pathAndFileName},{type}
assetID: c92d247a-5ea1-7a06-36db-7c67a1dc3151
permalink: en-us/docs/xboxlive/rest/uri-trustedplatformusersbatchscidssciddatapathandfilenametype.html
author: KevinAsgari
description: " /trustedplatform/users/batch/scids/{scid}/data/{pathAndFileName},{type}"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 0278b9a090f648dd2092641efcaa2c7a346d96b1
ms.sourcegitcommit: e4f3e1b2d08a02b9920e78e802234e5b674e7223
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/26/2018
ms.locfileid: "4211539"
---
# <a name="trustedplatformusersbatchscidssciddatapathandfilenametype"></a><span data-ttu-id="f8c9b-104">/trustedplatform/users/batch/scids/{scid}/data/{pathAndFileName},{type}</span><span class="sxs-lookup"><span data-stu-id="f8c9b-104">/trustedplatform/users/batch/scids/{scid}/data/{pathAndFileName},{type}</span></span>
<span data-ttu-id="f8c9b-105">同じファイル名を持つ複数のユーザーから複数のファイルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="f8c9b-105">Downloads multiple files from multiple users with the same filename.</span></span> <span data-ttu-id="f8c9b-106">これらの Uri のドメインが`titlestorage.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="f8c9b-106">The domain for these URIs is `titlestorage.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="f8c9b-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="f8c9b-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="f8c9b-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="f8c9b-108">URI parameters</span></span>
 
| <span data-ttu-id="f8c9b-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="f8c9b-109">Parameter</span></span>| <span data-ttu-id="f8c9b-110">型</span><span class="sxs-lookup"><span data-stu-id="f8c9b-110">Type</span></span>| <span data-ttu-id="f8c9b-111">説明</span><span class="sxs-lookup"><span data-stu-id="f8c9b-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="f8c9b-112">scid</span><span class="sxs-lookup"><span data-stu-id="f8c9b-112">scid</span></span>| <span data-ttu-id="f8c9b-113">guid</span><span class="sxs-lookup"><span data-stu-id="f8c9b-113">guid</span></span>| <span data-ttu-id="f8c9b-114">ルックアップ サービス構成の ID です。</span><span class="sxs-lookup"><span data-stu-id="f8c9b-114">the ID of the service config to look up.</span></span>| 
| <span data-ttu-id="f8c9b-115">pathAndFileName</span><span class="sxs-lookup"><span data-stu-id="f8c9b-115">pathAndFileName</span></span>| <span data-ttu-id="f8c9b-116">string</span><span class="sxs-lookup"><span data-stu-id="f8c9b-116">string</span></span>| <span data-ttu-id="f8c9b-117">アクセスできる項目のパスとファイル名。</span><span class="sxs-lookup"><span data-stu-id="f8c9b-117">Path and file name for the item to be accessed.</span></span> <span data-ttu-id="f8c9b-118">パス部分 (となどを含む最終的なスラッシュ) の有効な文字が大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9)、アンダー スコア (_) を含めるし、スラッシュ (/)。パス部分を空にすることがあります。有効な文字 (すべての最終的なスラッシュ後) ファイル名の部分には、大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9) が含まれているアンダー スコア (_)、ピリオド (.)、およびハイフン (-)。</span><span class="sxs-lookup"><span data-stu-id="f8c9b-118">Valid characters for the path portion (up to and including the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), and forward slash (/). The path portion may be empty. Valid characters for the file name portion (everything after the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), period (.), and hyphen (-).</span></span> <span data-ttu-id="f8c9b-119">ファイル名可能性がありますいないを空にする、期間の終了または 2 つの連続するピリオドが含まれています。</span><span class="sxs-lookup"><span data-stu-id="f8c9b-119">The file name may not be empty, end in a period or contain two consecutive periods.</span></span>| 
| <span data-ttu-id="f8c9b-120">type</span><span class="sxs-lookup"><span data-stu-id="f8c9b-120">type</span></span>| <span data-ttu-id="f8c9b-121">文字列</span><span class="sxs-lookup"><span data-stu-id="f8c9b-121">string</span></span>| <span data-ttu-id="f8c9b-122">データの形式です。</span><span class="sxs-lookup"><span data-stu-id="f8c9b-122">The format of the data.</span></span> <span data-ttu-id="f8c9b-123">可能な値は、バイナリまたは json です。</span><span class="sxs-lookup"><span data-stu-id="f8c9b-123">Possible values are binary or json.</span></span>| 
  
<a id="ID4EFC"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="f8c9b-124">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="f8c9b-124">Valid methods</span></span>

[<span data-ttu-id="f8c9b-125">POST</span><span class="sxs-lookup"><span data-stu-id="f8c9b-125">POST</span></span>](uri-trustedplatformusersbatchscidssciddatapathandfilenametype-post.md)

<span data-ttu-id="f8c9b-126">&nbsp;&nbsp;同じファイル名を持つ複数のユーザーから複数のファイルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="f8c9b-126">&nbsp;&nbsp;Downloads multiple files from multiple users with the same filename.</span></span>
 
<a id="ID4EPC"></a>

 
## <a name="see-also"></a><span data-ttu-id="f8c9b-127">関連項目</span><span class="sxs-lookup"><span data-stu-id="f8c9b-127">See also</span></span>
 
<a id="ID4ERC"></a>

 
##### <a name="parent"></a><span data-ttu-id="f8c9b-128">Parent</span><span class="sxs-lookup"><span data-stu-id="f8c9b-128">Parent</span></span> 

[<span data-ttu-id="f8c9b-129">タイトル ストレージ URI</span><span class="sxs-lookup"><span data-stu-id="f8c9b-129">Title Storage URIs</span></span>](atoc-reference-storagev2.md)

   