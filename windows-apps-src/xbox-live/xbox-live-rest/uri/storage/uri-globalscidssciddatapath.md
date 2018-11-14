---
title: /global/scids/{scid}/data/{path}
assetID: d6353cd3-9127-98d4-bb99-5df690e07022
permalink: en-us/docs/xboxlive/rest/uri-globalscidssciddatapath.html
author: KevinAsgari
description: " /global/scids/{scid}/data/{path}"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 70ad4c3238dca10150293af60aedb14a4d1ca756
ms.sourcegitcommit: f2c9a050a9137a473f28b613968d5782866142c6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/10/2018
ms.locfileid: "6277042"
---
# <a name="globalscidssciddatapath"></a><span data-ttu-id="7ef1b-104">/global/scids/{scid}/data/{path}</span><span class="sxs-lookup"><span data-stu-id="7ef1b-104">/global/scids/{scid}/data/{path}</span></span>
<span data-ttu-id="7ef1b-105">指定されたパスのファイル情報の一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="7ef1b-105">Lists file information at a specified path.</span></span> <span data-ttu-id="7ef1b-106">これらの Uri のドメインが`titlestorage.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="7ef1b-106">The domain for these URIs is `titlestorage.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="7ef1b-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="7ef1b-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="7ef1b-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="7ef1b-108">URI parameters</span></span>
 
| <span data-ttu-id="7ef1b-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="7ef1b-109">Parameter</span></span>| <span data-ttu-id="7ef1b-110">型</span><span class="sxs-lookup"><span data-stu-id="7ef1b-110">Type</span></span>| <span data-ttu-id="7ef1b-111">説明</span><span class="sxs-lookup"><span data-stu-id="7ef1b-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="7ef1b-112">scid</span><span class="sxs-lookup"><span data-stu-id="7ef1b-112">scid</span></span>| <span data-ttu-id="7ef1b-113">guid</span><span class="sxs-lookup"><span data-stu-id="7ef1b-113">guid</span></span>| <span data-ttu-id="7ef1b-114">ルックアップ サービス構成の ID です。</span><span class="sxs-lookup"><span data-stu-id="7ef1b-114">the ID of the service config to look up.</span></span>| 
| <span data-ttu-id="7ef1b-115">path</span><span class="sxs-lookup"><span data-stu-id="7ef1b-115">path</span></span>| <span data-ttu-id="7ef1b-116">string</span><span class="sxs-lookup"><span data-stu-id="7ef1b-116">string</span></span>| <span data-ttu-id="7ef1b-117">返されるデータ項目へのパス。</span><span class="sxs-lookup"><span data-stu-id="7ef1b-117">The path to the data items to return.</span></span> <span data-ttu-id="7ef1b-118">一致するすべてのディレクトリとサブディレクトリを取得する返されます。</span><span class="sxs-lookup"><span data-stu-id="7ef1b-118">All matching directories and subdirectories get returned.</span></span> <span data-ttu-id="7ef1b-119">有効な文字には、(A ~ Z) の大文字、小文字の英字 (a ~ z)、数字 (0 ~ 9)、アンダー スコア (_) およびスラッシュ (/) が含まれます。</span><span class="sxs-lookup"><span data-stu-id="7ef1b-119">Valid characters include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), and forward slash (/).</span></span> <span data-ttu-id="7ef1b-120">空にすることがあります。</span><span class="sxs-lookup"><span data-stu-id="7ef1b-120">May be empty.</span></span> <span data-ttu-id="7ef1b-121">256 の最大の長さ。</span><span class="sxs-lookup"><span data-stu-id="7ef1b-121">Max length of 256.</span></span>| 
  
<a id="ID4E3B"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="7ef1b-122">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="7ef1b-122">Valid methods</span></span>

[<span data-ttu-id="7ef1b-123">GET</span><span class="sxs-lookup"><span data-stu-id="7ef1b-123">GET</span></span>](uri-globalscidssciddatapath-get.md)

<span data-ttu-id="7ef1b-124">&nbsp;&nbsp;指定されたパスのファイル情報の一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="7ef1b-124">&nbsp;&nbsp;Lists file information at a specified path.</span></span>
 
<a id="ID4EGC"></a>

 
## <a name="see-also"></a><span data-ttu-id="7ef1b-125">関連項目</span><span class="sxs-lookup"><span data-stu-id="7ef1b-125">See also</span></span>
 
<a id="ID4EIC"></a>

 
##### <a name="parent"></a><span data-ttu-id="7ef1b-126">Parent</span><span class="sxs-lookup"><span data-stu-id="7ef1b-126">Parent</span></span> 

[<span data-ttu-id="7ef1b-127">タイトル ストレージ URI</span><span class="sxs-lookup"><span data-stu-id="7ef1b-127">Title Storage URIs</span></span>](atoc-reference-storagev2.md)

   