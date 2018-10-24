---
title: /global/scids/{scid}/data/{path}
assetID: d6353cd3-9127-98d4-bb99-5df690e07022
permalink: en-us/docs/xboxlive/rest/uri-globalscidssciddatapath.html
author: KevinAsgari
description: " /global/scids/{scid}/data/{path}"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: b091f3bbb5e03808d04a255b204c13eee93f7fdb
ms.sourcegitcommit: 4b97117d3aff38db89d560502a3c372f12bb6ed5
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/24/2018
ms.locfileid: "5443512"
---
# <a name="globalscidssciddatapath"></a><span data-ttu-id="4d177-104">/global/scids/{scid}/data/{path}</span><span class="sxs-lookup"><span data-stu-id="4d177-104">/global/scids/{scid}/data/{path}</span></span>
<span data-ttu-id="4d177-105">指定されたパスのファイル情報の一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="4d177-105">Lists file information at a specified path.</span></span> <span data-ttu-id="4d177-106">これらの Uri のドメインが`titlestorage.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="4d177-106">The domain for these URIs is `titlestorage.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="4d177-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4d177-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="4d177-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4d177-108">URI parameters</span></span>
 
| <span data-ttu-id="4d177-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="4d177-109">Parameter</span></span>| <span data-ttu-id="4d177-110">型</span><span class="sxs-lookup"><span data-stu-id="4d177-110">Type</span></span>| <span data-ttu-id="4d177-111">説明</span><span class="sxs-lookup"><span data-stu-id="4d177-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="4d177-112">scid</span><span class="sxs-lookup"><span data-stu-id="4d177-112">scid</span></span>| <span data-ttu-id="4d177-113">guid</span><span class="sxs-lookup"><span data-stu-id="4d177-113">guid</span></span>| <span data-ttu-id="4d177-114">検索するサービス構成の ID。</span><span class="sxs-lookup"><span data-stu-id="4d177-114">the ID of the service config to look up.</span></span>| 
| <span data-ttu-id="4d177-115">path</span><span class="sxs-lookup"><span data-stu-id="4d177-115">path</span></span>| <span data-ttu-id="4d177-116">string</span><span class="sxs-lookup"><span data-stu-id="4d177-116">string</span></span>| <span data-ttu-id="4d177-117">返されるデータ項目へのパス。</span><span class="sxs-lookup"><span data-stu-id="4d177-117">The path to the data items to return.</span></span> <span data-ttu-id="4d177-118">一致するすべてのディレクトリとサブディレクトリを取得する返されます。</span><span class="sxs-lookup"><span data-stu-id="4d177-118">All matching directories and subdirectories get returned.</span></span> <span data-ttu-id="4d177-119">有効な文字には、(A ~ Z) の大文字、小文字の英字 (a ~ z)、数字 (0 ~ 9)、アンダー スコア (_)、およびスラッシュ (/) が含まれます。</span><span class="sxs-lookup"><span data-stu-id="4d177-119">Valid characters include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), and forward slash (/).</span></span> <span data-ttu-id="4d177-120">空にすることがあります。</span><span class="sxs-lookup"><span data-stu-id="4d177-120">May be empty.</span></span> <span data-ttu-id="4d177-121">256 の最大の長さ。</span><span class="sxs-lookup"><span data-stu-id="4d177-121">Max length of 256.</span></span>| 
  
<a id="ID4E3B"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="4d177-122">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="4d177-122">Valid methods</span></span>

[<span data-ttu-id="4d177-123">GET</span><span class="sxs-lookup"><span data-stu-id="4d177-123">GET</span></span>](uri-globalscidssciddatapath-get.md)

<span data-ttu-id="4d177-124">&nbsp;&nbsp;指定されたパスのファイル情報の一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="4d177-124">&nbsp;&nbsp;Lists file information at a specified path.</span></span>
 
<a id="ID4EGC"></a>

 
## <a name="see-also"></a><span data-ttu-id="4d177-125">関連項目</span><span class="sxs-lookup"><span data-stu-id="4d177-125">See also</span></span>
 
<a id="ID4EIC"></a>

 
##### <a name="parent"></a><span data-ttu-id="4d177-126">Parent</span><span class="sxs-lookup"><span data-stu-id="4d177-126">Parent</span></span> 

[<span data-ttu-id="4d177-127">タイトル ストレージ URI</span><span class="sxs-lookup"><span data-stu-id="4d177-127">Title Storage URIs</span></span>](atoc-reference-storagev2.md)

   