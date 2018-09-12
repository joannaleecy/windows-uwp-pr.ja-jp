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
ms.sourcegitcommit: 2a63ee6770413bc35ace09b14f56b60007be7433
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3932836"
---
# <a name="globalscidssciddatapathandfilenametype"></a><span data-ttu-id="2b102-104">/global/scids/{scid}/data/{pathAndFileName},{type}</span><span class="sxs-lookup"><span data-stu-id="2b102-104">/global/scids/{scid}/data/{pathAndFileName},{type}</span></span>
<span data-ttu-id="2b102-105">ファイルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="2b102-105">Downloads a file.</span></span> <span data-ttu-id="2b102-106">これらの Uri のドメインが`titlestorage.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="2b102-106">The domain for these URIs is `titlestorage.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="2b102-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="2b102-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="2b102-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="2b102-108">URI parameters</span></span>
 
| <span data-ttu-id="2b102-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="2b102-109">Parameter</span></span>| <span data-ttu-id="2b102-110">型</span><span class="sxs-lookup"><span data-stu-id="2b102-110">Type</span></span>| <span data-ttu-id="2b102-111">説明</span><span class="sxs-lookup"><span data-stu-id="2b102-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="2b102-112">scid</span><span class="sxs-lookup"><span data-stu-id="2b102-112">scid</span></span>| <span data-ttu-id="2b102-113">guid</span><span class="sxs-lookup"><span data-stu-id="2b102-113">guid</span></span>| <span data-ttu-id="2b102-114">ルックアップ サービス構成の ID です。</span><span class="sxs-lookup"><span data-stu-id="2b102-114">the ID of the service config to look up.</span></span>| 
| <span data-ttu-id="2b102-115">pathAndFileName</span><span class="sxs-lookup"><span data-stu-id="2b102-115">pathAndFileName</span></span>| <span data-ttu-id="2b102-116">string</span><span class="sxs-lookup"><span data-stu-id="2b102-116">string</span></span>| <span data-ttu-id="2b102-117">アクセスできる項目のパスとファイル名。</span><span class="sxs-lookup"><span data-stu-id="2b102-117">Path and file name for the item to be accessed.</span></span> <span data-ttu-id="2b102-118">(となどを含む最終的なスラッシュ) のパス部分に有効な文字は大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9)、アンダー スコア (_) を含めるし、スラッシュ (/)。パス部分を空にすることがあります。有効な文字 (すべての最終的なスラッシュ後) ファイル名の部分には、大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9) が含まれているアンダー スコア (_)、ピリオド (.)、およびハイフン (-)。</span><span class="sxs-lookup"><span data-stu-id="2b102-118">Valid characters for the path portion (up to and including the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), and forward slash (/). The path portion may be empty. Valid characters for the file name portion (everything after the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), period (.), and hyphen (-).</span></span> <span data-ttu-id="2b102-119">ファイル名可能性がありますいないを空にする、期間の終了または 2 つの連続するピリオドが含まれています。</span><span class="sxs-lookup"><span data-stu-id="2b102-119">The file name may not be empty, end in a period or contain two consecutive periods.</span></span>| 
| <span data-ttu-id="2b102-120">type</span><span class="sxs-lookup"><span data-stu-id="2b102-120">type</span></span>| <span data-ttu-id="2b102-121">文字列</span><span class="sxs-lookup"><span data-stu-id="2b102-121">string</span></span>| <span data-ttu-id="2b102-122">データの形式です。</span><span class="sxs-lookup"><span data-stu-id="2b102-122">The format of the data.</span></span> <span data-ttu-id="2b102-123">使用可能な値: バイナリ、config または json します。</span><span class="sxs-lookup"><span data-stu-id="2b102-123">Possible values are: binary, config or json.</span></span>| 
  
<a id="ID4EFC"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="2b102-124">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="2b102-124">Valid methods</span></span>

[<span data-ttu-id="2b102-125">GET</span><span class="sxs-lookup"><span data-stu-id="2b102-125">GET</span></span>](uri-globalscidssciddatapathandfilenametype-get.md)

<span data-ttu-id="2b102-126">&nbsp;&nbsp;ファイルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="2b102-126">&nbsp;&nbsp;Downloads a file.</span></span>
 
<a id="ID4EPC"></a>

 
## <a name="see-also"></a><span data-ttu-id="2b102-127">関連項目</span><span class="sxs-lookup"><span data-stu-id="2b102-127">See also</span></span>
 
<a id="ID4ERC"></a>

 
##### <a name="parent"></a><span data-ttu-id="2b102-128">Parent</span><span class="sxs-lookup"><span data-stu-id="2b102-128">Parent</span></span> 

[<span data-ttu-id="2b102-129">タイトル ストレージ Uri</span><span class="sxs-lookup"><span data-stu-id="2b102-129">Title Storage URIs</span></span>](atoc-reference-storagev2.md)

   