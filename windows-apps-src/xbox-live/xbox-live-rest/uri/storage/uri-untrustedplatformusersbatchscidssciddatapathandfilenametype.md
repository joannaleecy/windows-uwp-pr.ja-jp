---
title: /untrustedplatform/users/batch/scids/{scid}/data/{pathAndFileName},{type}
assetID: c2909e75-e108-3555-c157-f2d552f10e9f
permalink: en-us/docs/xboxlive/rest/uri-untrustedplatformusersbatchscidssciddatapathandfilenametype.html
author: KevinAsgari
description: " /untrustedplatform/users/batch/scids/{scid}/data/{pathAndFileName},{type}"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 905bc248ee330221695c1dc107745bed45ba813c
ms.sourcegitcommit: 086001cffaf436e6e4324761d59bcc5e598c15ea
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/27/2018
ms.locfileid: "5687544"
---
# <a name="untrustedplatformusersbatchscidssciddatapathandfilenametype"></a><span data-ttu-id="18ba4-104">/untrustedplatform/users/batch/scids/{scid}/data/{pathAndFileName},{type}</span><span class="sxs-lookup"><span data-stu-id="18ba4-104">/untrustedplatform/users/batch/scids/{scid}/data/{pathAndFileName},{type}</span></span>
<span data-ttu-id="18ba4-105">同じファイル名を持つ複数のユーザーからは、複数のファイルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="18ba4-105">Downloads multiple files from multiple users with the same filename.</span></span> <span data-ttu-id="18ba4-106">これらの Uri のドメインが`titlestorage.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="18ba4-106">The domain for these URIs is `titlestorage.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="18ba4-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="18ba4-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="18ba4-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="18ba4-108">URI parameters</span></span>
 
| <span data-ttu-id="18ba4-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="18ba4-109">Parameter</span></span>| <span data-ttu-id="18ba4-110">型</span><span class="sxs-lookup"><span data-stu-id="18ba4-110">Type</span></span>| <span data-ttu-id="18ba4-111">説明</span><span class="sxs-lookup"><span data-stu-id="18ba4-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="18ba4-112">scid</span><span class="sxs-lookup"><span data-stu-id="18ba4-112">scid</span></span>| <span data-ttu-id="18ba4-113">guid</span><span class="sxs-lookup"><span data-stu-id="18ba4-113">guid</span></span>| <span data-ttu-id="18ba4-114">ルックアップ サービス構成の ID です。</span><span class="sxs-lookup"><span data-stu-id="18ba4-114">the ID of the service config to look up.</span></span>| 
| <span data-ttu-id="18ba4-115">pathAndFileName</span><span class="sxs-lookup"><span data-stu-id="18ba4-115">pathAndFileName</span></span>| <span data-ttu-id="18ba4-116">string</span><span class="sxs-lookup"><span data-stu-id="18ba4-116">string</span></span>| <span data-ttu-id="18ba4-117">アクセスできる項目のパスとファイルの名前です。</span><span class="sxs-lookup"><span data-stu-id="18ba4-117">Path and file name for the item to be accessed.</span></span> <span data-ttu-id="18ba4-118">パス部分 (となどを含む最終的なスラッシュ) の有効な文字が大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9)、アンダー スコア (_) を含めるし、スラッシュ (/)。パス部分を空にすることがあります。有効な文字 (すべての最終的なスラッシュ後) ファイル名の部分には、大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9) が含まれているアンダー スコア (_)、ピリオド (.)、およびハイフン (-)。</span><span class="sxs-lookup"><span data-stu-id="18ba4-118">Valid characters for the path portion (up to and including the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), and forward slash (/). The path portion may be empty. Valid characters for the file name portion (everything after the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), period (.), and hyphen (-).</span></span> <span data-ttu-id="18ba4-119">ファイル名を空にする可能性がありますはない期間の終了または 2 つの連続するピリオドが含まれてはします。</span><span class="sxs-lookup"><span data-stu-id="18ba4-119">The file name may not be empty, end in a period or contain two consecutive periods.</span></span>| 
| <span data-ttu-id="18ba4-120">type</span><span class="sxs-lookup"><span data-stu-id="18ba4-120">type</span></span>| <span data-ttu-id="18ba4-121">文字列</span><span class="sxs-lookup"><span data-stu-id="18ba4-121">string</span></span>| <span data-ttu-id="18ba4-122">データの形式です。</span><span class="sxs-lookup"><span data-stu-id="18ba4-122">The format of the data.</span></span> <span data-ttu-id="18ba4-123">設定可能な値は、バイナリ json です。</span><span class="sxs-lookup"><span data-stu-id="18ba4-123">Possible values are binary json.</span></span>| 
  
<a id="ID4EFC"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="18ba4-124">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="18ba4-124">Valid methods</span></span>

[<span data-ttu-id="18ba4-125">POST</span><span class="sxs-lookup"><span data-stu-id="18ba4-125">POST</span></span>](uri-untrustedplatformusersbatchscidssciddatapathandfilenametype-post.md)

<span data-ttu-id="18ba4-126">&nbsp;&nbsp;同じファイル名を持つ複数のユーザーからは、複数のファイルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="18ba4-126">&nbsp;&nbsp;Downloads multiple files from multiple users with the same filename.</span></span>
 
<a id="ID4EPC"></a>

 
## <a name="see-also"></a><span data-ttu-id="18ba4-127">関連項目</span><span class="sxs-lookup"><span data-stu-id="18ba4-127">See also</span></span>
 
<a id="ID4ERC"></a>

 
##### <a name="parent"></a><span data-ttu-id="18ba4-128">Parent</span><span class="sxs-lookup"><span data-stu-id="18ba4-128">Parent</span></span> 

[<span data-ttu-id="18ba4-129">タイトル ストレージ URI</span><span class="sxs-lookup"><span data-stu-id="18ba4-129">Title Storage URIs</span></span>](atoc-reference-storagev2.md)

   