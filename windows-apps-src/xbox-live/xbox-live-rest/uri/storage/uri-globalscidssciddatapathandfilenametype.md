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
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57656237"
---
# <a name="globalscidssciddatapathandfilenametype"></a><span data-ttu-id="cb5f0-104">/global/scids/{scid}/data/{pathAndFileName},{type}</span><span class="sxs-lookup"><span data-stu-id="cb5f0-104">/global/scids/{scid}/data/{pathAndFileName},{type}</span></span>
<span data-ttu-id="cb5f0-105">ファイルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="cb5f0-105">Downloads a file.</span></span> <span data-ttu-id="cb5f0-106">これらの Uri のドメインが`titlestorage.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="cb5f0-106">The domain for these URIs is `titlestorage.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="cb5f0-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="cb5f0-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="cb5f0-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="cb5f0-108">URI parameters</span></span>
 
| <span data-ttu-id="cb5f0-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="cb5f0-109">Parameter</span></span>| <span data-ttu-id="cb5f0-110">種類</span><span class="sxs-lookup"><span data-stu-id="cb5f0-110">Type</span></span>| <span data-ttu-id="cb5f0-111">説明</span><span class="sxs-lookup"><span data-stu-id="cb5f0-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="cb5f0-112">scid</span><span class="sxs-lookup"><span data-stu-id="cb5f0-112">scid</span></span>| <span data-ttu-id="cb5f0-113">guid</span><span class="sxs-lookup"><span data-stu-id="cb5f0-113">guid</span></span>| <span data-ttu-id="cb5f0-114">検索するサービス構成の ID。</span><span class="sxs-lookup"><span data-stu-id="cb5f0-114">the ID of the service config to look up.</span></span>| 
| <span data-ttu-id="cb5f0-115">pathAndFileName</span><span class="sxs-lookup"><span data-stu-id="cb5f0-115">pathAndFileName</span></span>| <span data-ttu-id="cb5f0-116">string</span><span class="sxs-lookup"><span data-stu-id="cb5f0-116">string</span></span>| <span data-ttu-id="cb5f0-117">アクセスする項目のパスとファイル名。</span><span class="sxs-lookup"><span data-stu-id="cb5f0-117">Path and file name for the item to be accessed.</span></span> <span data-ttu-id="cb5f0-118">有効な文字 (最大、および最後のスラッシュを含む) のパス部分に含まれている大文字 (A ~ Z)、英小文字 (a ~ z)、数字 (0 ~ 9)、アンダー スコア (_)、スラッシュ (/) とします。パスの部分を空にすることがあります。有効な文字の大文字 (A ~ Z)、英小文字 (a ~ z)、数字 (0 ~ 9)、ファイル名の部分 (最後のスラッシュの後の部分すべて) が含まれているアンダー スコア (_)、ピリオド (.)、およびハイフン (-)。</span><span class="sxs-lookup"><span data-stu-id="cb5f0-118">Valid characters for the path portion (up to and including the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), and forward slash (/). The path portion may be empty. Valid characters for the file name portion (everything after the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), period (.), and hyphen (-).</span></span> <span data-ttu-id="cb5f0-119">ファイル名を空にする可能性がありますはいない末尾をピリオドまたは 2 つの連続するピリオドを含めることは。</span><span class="sxs-lookup"><span data-stu-id="cb5f0-119">The file name may not be empty, end in a period or contain two consecutive periods.</span></span>| 
| <span data-ttu-id="cb5f0-120">type</span><span class="sxs-lookup"><span data-stu-id="cb5f0-120">type</span></span>| <span data-ttu-id="cb5f0-121">string</span><span class="sxs-lookup"><span data-stu-id="cb5f0-121">string</span></span>| <span data-ttu-id="cb5f0-122">データの形式です。</span><span class="sxs-lookup"><span data-stu-id="cb5f0-122">The format of the data.</span></span> <span data-ttu-id="cb5f0-123">指定できる値は。 バイナリ、構成、または json です。</span><span class="sxs-lookup"><span data-stu-id="cb5f0-123">Possible values are: binary, config or json.</span></span>| 
  
<a id="ID4EFC"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="cb5f0-124">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="cb5f0-124">Valid methods</span></span>

[<span data-ttu-id="cb5f0-125">取得</span><span class="sxs-lookup"><span data-stu-id="cb5f0-125">GET</span></span>](uri-globalscidssciddatapathandfilenametype-get.md)

<span data-ttu-id="cb5f0-126">&nbsp;&nbsp;ファイルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="cb5f0-126">&nbsp;&nbsp;Downloads a file.</span></span>
 
<a id="ID4EPC"></a>

 
## <a name="see-also"></a><span data-ttu-id="cb5f0-127">関連項目</span><span class="sxs-lookup"><span data-stu-id="cb5f0-127">See also</span></span>
 
<a id="ID4ERC"></a>

 
##### <a name="parent"></a><span data-ttu-id="cb5f0-128">Parent</span><span class="sxs-lookup"><span data-stu-id="cb5f0-128">Parent</span></span> 

[<span data-ttu-id="cb5f0-129">ストレージ Uri のタイトル</span><span class="sxs-lookup"><span data-stu-id="cb5f0-129">Title Storage URIs</span></span>](atoc-reference-storagev2.md)

   