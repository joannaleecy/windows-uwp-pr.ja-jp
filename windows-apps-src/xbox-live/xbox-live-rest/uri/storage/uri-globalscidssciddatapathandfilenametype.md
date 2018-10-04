---
title: /global/scids/{scid}/data/{pathAndFileName},{type}
assetID: 774ce2dc-15c5-fe12-42b9-4e040bd4d2cf
permalink: en-us/docs/xboxlive/rest/uri-globalscidssciddatapathandfilenametype.html
author: KevinAsgari
description: " /global/scids/{scid}/data/{pathAndFileName},{type}"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: cd4323f8d4f929a46f0636facbc52e451b7a582e
ms.sourcegitcommit: e6daa7ff878f2f0c7015aca9787e7f2730abcfbf
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/04/2018
ms.locfileid: "4316693"
---
# <a name="globalscidssciddatapathandfilenametype"></a><span data-ttu-id="e8543-104">/global/scids/{scid}/data/{pathAndFileName},{type}</span><span class="sxs-lookup"><span data-stu-id="e8543-104">/global/scids/{scid}/data/{pathAndFileName},{type}</span></span>
<span data-ttu-id="e8543-105">ファイルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="e8543-105">Downloads a file.</span></span> <span data-ttu-id="e8543-106">これらの Uri のドメインが`titlestorage.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="e8543-106">The domain for these URIs is `titlestorage.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="e8543-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="e8543-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="e8543-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="e8543-108">URI parameters</span></span>
 
| <span data-ttu-id="e8543-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="e8543-109">Parameter</span></span>| <span data-ttu-id="e8543-110">型</span><span class="sxs-lookup"><span data-stu-id="e8543-110">Type</span></span>| <span data-ttu-id="e8543-111">説明</span><span class="sxs-lookup"><span data-stu-id="e8543-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="e8543-112">scid</span><span class="sxs-lookup"><span data-stu-id="e8543-112">scid</span></span>| <span data-ttu-id="e8543-113">guid</span><span class="sxs-lookup"><span data-stu-id="e8543-113">guid</span></span>| <span data-ttu-id="e8543-114">ルックアップ サービス構成の ID です。</span><span class="sxs-lookup"><span data-stu-id="e8543-114">the ID of the service config to look up.</span></span>| 
| <span data-ttu-id="e8543-115">pathAndFileName</span><span class="sxs-lookup"><span data-stu-id="e8543-115">pathAndFileName</span></span>| <span data-ttu-id="e8543-116">string</span><span class="sxs-lookup"><span data-stu-id="e8543-116">string</span></span>| <span data-ttu-id="e8543-117">アクセスできる項目のパスとファイル名。</span><span class="sxs-lookup"><span data-stu-id="e8543-117">Path and file name for the item to be accessed.</span></span> <span data-ttu-id="e8543-118">パス部分 (となどを含む最終的なスラッシュ) の有効な文字が大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9)、アンダー スコア (_) を含めるし、スラッシュ (/)。パス部分を空にすることがあります。有効な文字 (すべての最終的なスラッシュ後) ファイル名の部分には、大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9) が含まれているアンダー スコア (_)、ピリオド (.)、およびハイフン (-)。</span><span class="sxs-lookup"><span data-stu-id="e8543-118">Valid characters for the path portion (up to and including the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), and forward slash (/). The path portion may be empty. Valid characters for the file name portion (everything after the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), period (.), and hyphen (-).</span></span> <span data-ttu-id="e8543-119">ファイル名可能性がありますいないを空にする、期間の終了または 2 つの連続するピリオドが含まれています。</span><span class="sxs-lookup"><span data-stu-id="e8543-119">The file name may not be empty, end in a period or contain two consecutive periods.</span></span>| 
| <span data-ttu-id="e8543-120">type</span><span class="sxs-lookup"><span data-stu-id="e8543-120">type</span></span>| <span data-ttu-id="e8543-121">文字列</span><span class="sxs-lookup"><span data-stu-id="e8543-121">string</span></span>| <span data-ttu-id="e8543-122">データの形式です。</span><span class="sxs-lookup"><span data-stu-id="e8543-122">The format of the data.</span></span> <span data-ttu-id="e8543-123">使用可能な値: バイナリ、config または json します。</span><span class="sxs-lookup"><span data-stu-id="e8543-123">Possible values are: binary, config or json.</span></span>| 
  
<a id="ID4EFC"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="e8543-124">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="e8543-124">Valid methods</span></span>

[<span data-ttu-id="e8543-125">GET</span><span class="sxs-lookup"><span data-stu-id="e8543-125">GET</span></span>](uri-globalscidssciddatapathandfilenametype-get.md)

<span data-ttu-id="e8543-126">&nbsp;&nbsp;ファイルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="e8543-126">&nbsp;&nbsp;Downloads a file.</span></span>
 
<a id="ID4EPC"></a>

 
## <a name="see-also"></a><span data-ttu-id="e8543-127">関連項目</span><span class="sxs-lookup"><span data-stu-id="e8543-127">See also</span></span>
 
<a id="ID4ERC"></a>

 
##### <a name="parent"></a><span data-ttu-id="e8543-128">Parent</span><span class="sxs-lookup"><span data-stu-id="e8543-128">Parent</span></span> 

[<span data-ttu-id="e8543-129">タイトル ストレージ URI</span><span class="sxs-lookup"><span data-stu-id="e8543-129">Title Storage URIs</span></span>](atoc-reference-storagev2.md)

   