---
title: /untrustedplatform/users/batch/scids/{scid}/data/{pathAndFileName},{type}
assetID: c2909e75-e108-3555-c157-f2d552f10e9f
permalink: en-us/docs/xboxlive/rest/uri-untrustedplatformusersbatchscidssciddatapathandfilenametype.html
author: KevinAsgari
description: " /untrustedplatform/users/batch/scids/{scid}/data/{pathAndFileName},{type}"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 04952a183a2903a5c296a6b27af35766bccbddc1
ms.sourcegitcommit: e6daa7ff878f2f0c7015aca9787e7f2730abcfbf
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/04/2018
ms.locfileid: "4310283"
---
# <a name="untrustedplatformusersbatchscidssciddatapathandfilenametype"></a><span data-ttu-id="f6e89-104">/untrustedplatform/users/batch/scids/{scid}/data/{pathAndFileName},{type}</span><span class="sxs-lookup"><span data-stu-id="f6e89-104">/untrustedplatform/users/batch/scids/{scid}/data/{pathAndFileName},{type}</span></span>
<span data-ttu-id="f6e89-105">同じファイル名を持つ複数のユーザーから複数のファイルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="f6e89-105">Downloads multiple files from multiple users with the same filename.</span></span> <span data-ttu-id="f6e89-106">これらの Uri のドメインが`titlestorage.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="f6e89-106">The domain for these URIs is `titlestorage.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="f6e89-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="f6e89-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="f6e89-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="f6e89-108">URI parameters</span></span>
 
| <span data-ttu-id="f6e89-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="f6e89-109">Parameter</span></span>| <span data-ttu-id="f6e89-110">型</span><span class="sxs-lookup"><span data-stu-id="f6e89-110">Type</span></span>| <span data-ttu-id="f6e89-111">説明</span><span class="sxs-lookup"><span data-stu-id="f6e89-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="f6e89-112">scid</span><span class="sxs-lookup"><span data-stu-id="f6e89-112">scid</span></span>| <span data-ttu-id="f6e89-113">guid</span><span class="sxs-lookup"><span data-stu-id="f6e89-113">guid</span></span>| <span data-ttu-id="f6e89-114">ルックアップ サービス構成の ID です。</span><span class="sxs-lookup"><span data-stu-id="f6e89-114">the ID of the service config to look up.</span></span>| 
| <span data-ttu-id="f6e89-115">pathAndFileName</span><span class="sxs-lookup"><span data-stu-id="f6e89-115">pathAndFileName</span></span>| <span data-ttu-id="f6e89-116">string</span><span class="sxs-lookup"><span data-stu-id="f6e89-116">string</span></span>| <span data-ttu-id="f6e89-117">アクセスできる項目のパスとファイル名。</span><span class="sxs-lookup"><span data-stu-id="f6e89-117">Path and file name for the item to be accessed.</span></span> <span data-ttu-id="f6e89-118">パス部分 (となどを含む最終的なスラッシュ) の有効な文字が大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9)、アンダー スコア (_) を含めるし、スラッシュ (/)。パス部分を空にすることがあります。有効な文字 (すべての最終的なスラッシュ後) ファイル名の部分には、大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9) が含まれているアンダー スコア (_)、ピリオド (.)、およびハイフン (-)。</span><span class="sxs-lookup"><span data-stu-id="f6e89-118">Valid characters for the path portion (up to and including the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), and forward slash (/). The path portion may be empty. Valid characters for the file name portion (everything after the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), period (.), and hyphen (-).</span></span> <span data-ttu-id="f6e89-119">ファイル名可能性がありますいないを空にする、期間の終了または 2 つの連続するピリオドが含まれています。</span><span class="sxs-lookup"><span data-stu-id="f6e89-119">The file name may not be empty, end in a period or contain two consecutive periods.</span></span>| 
| <span data-ttu-id="f6e89-120">type</span><span class="sxs-lookup"><span data-stu-id="f6e89-120">type</span></span>| <span data-ttu-id="f6e89-121">文字列</span><span class="sxs-lookup"><span data-stu-id="f6e89-121">string</span></span>| <span data-ttu-id="f6e89-122">データの形式です。</span><span class="sxs-lookup"><span data-stu-id="f6e89-122">The format of the data.</span></span> <span data-ttu-id="f6e89-123">設定可能な値は、バイナリ json です。</span><span class="sxs-lookup"><span data-stu-id="f6e89-123">Possible values are binary json.</span></span>| 
  
<a id="ID4EFC"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="f6e89-124">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="f6e89-124">Valid methods</span></span>

[<span data-ttu-id="f6e89-125">POST</span><span class="sxs-lookup"><span data-stu-id="f6e89-125">POST</span></span>](uri-untrustedplatformusersbatchscidssciddatapathandfilenametype-post.md)

<span data-ttu-id="f6e89-126">&nbsp;&nbsp;同じファイル名を持つ複数のユーザーから複数のファイルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="f6e89-126">&nbsp;&nbsp;Downloads multiple files from multiple users with the same filename.</span></span>
 
<a id="ID4EPC"></a>

 
## <a name="see-also"></a><span data-ttu-id="f6e89-127">関連項目</span><span class="sxs-lookup"><span data-stu-id="f6e89-127">See also</span></span>
 
<a id="ID4ERC"></a>

 
##### <a name="parent"></a><span data-ttu-id="f6e89-128">Parent</span><span class="sxs-lookup"><span data-stu-id="f6e89-128">Parent</span></span> 

[<span data-ttu-id="f6e89-129">タイトル ストレージ URI</span><span class="sxs-lookup"><span data-stu-id="f6e89-129">Title Storage URIs</span></span>](atoc-reference-storagev2.md)

   