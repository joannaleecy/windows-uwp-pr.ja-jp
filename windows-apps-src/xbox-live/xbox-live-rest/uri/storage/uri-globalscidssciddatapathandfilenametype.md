---
title: /global/scids/{scid}/data/{pathAndFileName},{type}
assetID: 774ce2dc-15c5-fe12-42b9-4e040bd4d2cf
permalink: en-us/docs/xboxlive/rest/uri-globalscidssciddatapathandfilenametype.html
description: " /global/scids/{scid}/data/{pathAndFileName},{type}"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: d8c58ee4888cbbe7d9a752531c489b1da3fdde86
ms.sourcegitcommit: 8921a9cc0dd3e5665345ae8eca7ab7aeb83ccc6f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8877168"
---
# <a name="globalscidssciddatapathandfilenametype"></a><span data-ttu-id="4e7a1-104">/global/scids/{scid}/data/{pathAndFileName},{type}</span><span class="sxs-lookup"><span data-stu-id="4e7a1-104">/global/scids/{scid}/data/{pathAndFileName},{type}</span></span>
<span data-ttu-id="4e7a1-105">ファイルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="4e7a1-105">Downloads a file.</span></span> <span data-ttu-id="4e7a1-106">これらの Uri のドメインが`titlestorage.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="4e7a1-106">The domain for these URIs is `titlestorage.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="4e7a1-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4e7a1-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="4e7a1-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4e7a1-108">URI parameters</span></span>
 
| <span data-ttu-id="4e7a1-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="4e7a1-109">Parameter</span></span>| <span data-ttu-id="4e7a1-110">型</span><span class="sxs-lookup"><span data-stu-id="4e7a1-110">Type</span></span>| <span data-ttu-id="4e7a1-111">説明</span><span class="sxs-lookup"><span data-stu-id="4e7a1-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="4e7a1-112">scid</span><span class="sxs-lookup"><span data-stu-id="4e7a1-112">scid</span></span>| <span data-ttu-id="4e7a1-113">guid</span><span class="sxs-lookup"><span data-stu-id="4e7a1-113">guid</span></span>| <span data-ttu-id="4e7a1-114">ルックアップ サービス構成の ID です。</span><span class="sxs-lookup"><span data-stu-id="4e7a1-114">the ID of the service config to look up.</span></span>| 
| <span data-ttu-id="4e7a1-115">pathAndFileName</span><span class="sxs-lookup"><span data-stu-id="4e7a1-115">pathAndFileName</span></span>| <span data-ttu-id="4e7a1-116">string</span><span class="sxs-lookup"><span data-stu-id="4e7a1-116">string</span></span>| <span data-ttu-id="4e7a1-117">アクセスできる項目のパスとファイルの名前です。</span><span class="sxs-lookup"><span data-stu-id="4e7a1-117">Path and file name for the item to be accessed.</span></span> <span data-ttu-id="4e7a1-118">パスの部分 (となどを含む最終的なスラッシュ) の有効な文字は大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9)、アンダー スコア (_) を含めるし、スラッシュ (/)。パス部分を空にすることがあります。有効な文字 (すべての最終的なスラッシュ後) ファイル名の部分には、大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9) が含まれているアンダー スコア (_)、ピリオド (.)、およびハイフン (-)。</span><span class="sxs-lookup"><span data-stu-id="4e7a1-118">Valid characters for the path portion (up to and including the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), and forward slash (/). The path portion may be empty. Valid characters for the file name portion (everything after the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), period (.), and hyphen (-).</span></span> <span data-ttu-id="4e7a1-119">ファイル名を空にすることがありますはいない期間の終了または 2 つの連続するピリオドが含まれてはします。</span><span class="sxs-lookup"><span data-stu-id="4e7a1-119">The file name may not be empty, end in a period or contain two consecutive periods.</span></span>| 
| <span data-ttu-id="4e7a1-120">type</span><span class="sxs-lookup"><span data-stu-id="4e7a1-120">type</span></span>| <span data-ttu-id="4e7a1-121">文字列</span><span class="sxs-lookup"><span data-stu-id="4e7a1-121">string</span></span>| <span data-ttu-id="4e7a1-122">データの形式です。</span><span class="sxs-lookup"><span data-stu-id="4e7a1-122">The format of the data.</span></span> <span data-ttu-id="4e7a1-123">使用可能な値: バイナリ、config または json します。</span><span class="sxs-lookup"><span data-stu-id="4e7a1-123">Possible values are: binary, config or json.</span></span>| 
  
<a id="ID4EFC"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="4e7a1-124">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="4e7a1-124">Valid methods</span></span>

[<span data-ttu-id="4e7a1-125">GET</span><span class="sxs-lookup"><span data-stu-id="4e7a1-125">GET</span></span>](uri-globalscidssciddatapathandfilenametype-get.md)

<span data-ttu-id="4e7a1-126">&nbsp;&nbsp;ファイルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="4e7a1-126">&nbsp;&nbsp;Downloads a file.</span></span>
 
<a id="ID4EPC"></a>

 
## <a name="see-also"></a><span data-ttu-id="4e7a1-127">関連項目</span><span class="sxs-lookup"><span data-stu-id="4e7a1-127">See also</span></span>
 
<a id="ID4ERC"></a>

 
##### <a name="parent"></a><span data-ttu-id="4e7a1-128">Parent</span><span class="sxs-lookup"><span data-stu-id="4e7a1-128">Parent</span></span> 

[<span data-ttu-id="4e7a1-129">タイトル ストレージ URI</span><span class="sxs-lookup"><span data-stu-id="4e7a1-129">Title Storage URIs</span></span>](atoc-reference-storagev2.md)

   