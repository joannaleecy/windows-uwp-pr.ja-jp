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
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/02/2018
ms.locfileid: "8337632"
---
# <a name="untrustedplatformusersbatchscidssciddatapathandfilenametype"></a><span data-ttu-id="af6c6-104">/untrustedplatform/users/batch/scids/{scid}/data/{pathAndFileName},{type}</span><span class="sxs-lookup"><span data-stu-id="af6c6-104">/untrustedplatform/users/batch/scids/{scid}/data/{pathAndFileName},{type}</span></span>
<span data-ttu-id="af6c6-105">同じファイル名を持つ複数のユーザーから複数のファイルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="af6c6-105">Downloads multiple files from multiple users with the same filename.</span></span> <span data-ttu-id="af6c6-106">これらの Uri のドメインが`titlestorage.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="af6c6-106">The domain for these URIs is `titlestorage.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="af6c6-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="af6c6-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="af6c6-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="af6c6-108">URI parameters</span></span>
 
| <span data-ttu-id="af6c6-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="af6c6-109">Parameter</span></span>| <span data-ttu-id="af6c6-110">型</span><span class="sxs-lookup"><span data-stu-id="af6c6-110">Type</span></span>| <span data-ttu-id="af6c6-111">説明</span><span class="sxs-lookup"><span data-stu-id="af6c6-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="af6c6-112">scid</span><span class="sxs-lookup"><span data-stu-id="af6c6-112">scid</span></span>| <span data-ttu-id="af6c6-113">guid</span><span class="sxs-lookup"><span data-stu-id="af6c6-113">guid</span></span>| <span data-ttu-id="af6c6-114">ルックアップ サービス構成の ID です。</span><span class="sxs-lookup"><span data-stu-id="af6c6-114">the ID of the service config to look up.</span></span>| 
| <span data-ttu-id="af6c6-115">pathAndFileName</span><span class="sxs-lookup"><span data-stu-id="af6c6-115">pathAndFileName</span></span>| <span data-ttu-id="af6c6-116">string</span><span class="sxs-lookup"><span data-stu-id="af6c6-116">string</span></span>| <span data-ttu-id="af6c6-117">アクセスできる項目のパスとファイルの名前です。</span><span class="sxs-lookup"><span data-stu-id="af6c6-117">Path and file name for the item to be accessed.</span></span> <span data-ttu-id="af6c6-118">パス部分 (となどを含む最終的なスラッシュ) の有効な文字が大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9)、アンダー スコア (_) を含めるし、スラッシュ (/)。パス部分を空にすることがあります。有効な文字 (すべての最終的なスラッシュ後) ファイル名の部分には、大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9) が含まれているアンダー スコア (_)、ピリオド (.)、およびハイフン (-)。</span><span class="sxs-lookup"><span data-stu-id="af6c6-118">Valid characters for the path portion (up to and including the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), and forward slash (/). The path portion may be empty. Valid characters for the file name portion (everything after the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), period (.), and hyphen (-).</span></span> <span data-ttu-id="af6c6-119">ファイル名を空にする可能性がありますはない期間の終了または 2 つの連続するピリオドが含まれてはします。</span><span class="sxs-lookup"><span data-stu-id="af6c6-119">The file name may not be empty, end in a period or contain two consecutive periods.</span></span>| 
| <span data-ttu-id="af6c6-120">type</span><span class="sxs-lookup"><span data-stu-id="af6c6-120">type</span></span>| <span data-ttu-id="af6c6-121">文字列</span><span class="sxs-lookup"><span data-stu-id="af6c6-121">string</span></span>| <span data-ttu-id="af6c6-122">データの形式です。</span><span class="sxs-lookup"><span data-stu-id="af6c6-122">The format of the data.</span></span> <span data-ttu-id="af6c6-123">設定可能な値は、バイナリ json です。</span><span class="sxs-lookup"><span data-stu-id="af6c6-123">Possible values are binary json.</span></span>| 
  
<a id="ID4EFC"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="af6c6-124">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="af6c6-124">Valid methods</span></span>

[<span data-ttu-id="af6c6-125">POST</span><span class="sxs-lookup"><span data-stu-id="af6c6-125">POST</span></span>](uri-untrustedplatformusersbatchscidssciddatapathandfilenametype-post.md)

<span data-ttu-id="af6c6-126">&nbsp;&nbsp;同じファイル名を持つ複数のユーザーから複数のファイルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="af6c6-126">&nbsp;&nbsp;Downloads multiple files from multiple users with the same filename.</span></span>
 
<a id="ID4EPC"></a>

 
## <a name="see-also"></a><span data-ttu-id="af6c6-127">関連項目</span><span class="sxs-lookup"><span data-stu-id="af6c6-127">See also</span></span>
 
<a id="ID4ERC"></a>

 
##### <a name="parent"></a><span data-ttu-id="af6c6-128">Parent</span><span class="sxs-lookup"><span data-stu-id="af6c6-128">Parent</span></span> 

[<span data-ttu-id="af6c6-129">タイトル ストレージ URI</span><span class="sxs-lookup"><span data-stu-id="af6c6-129">Title Storage URIs</span></span>](atoc-reference-storagev2.md)

   