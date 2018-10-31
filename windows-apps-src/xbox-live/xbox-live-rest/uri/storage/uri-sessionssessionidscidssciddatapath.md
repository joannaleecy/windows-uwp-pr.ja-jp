---
title: /sessions/{sessionId}/scids/{scid}/data/{path}
assetID: 932459b4-24b4-5b09-8146-ed214de0083a
permalink: en-us/docs/xboxlive/rest/uri-sessionssessionidscidssciddatapath.html
author: KevinAsgari
description: " /sessions/{sessionId}/scids/{scid}/data/{path}"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 52f0e12347f4a314f8e3b925ca3ba6bb2291da63
ms.sourcegitcommit: ca96031debe1e76d4501621a7680079244ef1c60
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/31/2018
ms.locfileid: "5837570"
---
# <a name="sessionssessionidscidssciddatapath"></a><span data-ttu-id="d7eeb-104">/sessions/{sessionId}/scids/{scid}/data/{path}</span><span class="sxs-lookup"><span data-stu-id="d7eeb-104">/sessions/{sessionId}/scids/{scid}/data/{path}</span></span>
<span data-ttu-id="d7eeb-105">指定されたパスのファイル情報の一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="d7eeb-105">Lists file information at a specified path.</span></span> <span data-ttu-id="d7eeb-106">これらの Uri のドメインが`titlestorage.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="d7eeb-106">The domain for these URIs is `titlestorage.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="d7eeb-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="d7eeb-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="d7eeb-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="d7eeb-108">URI parameters</span></span>
 
| <span data-ttu-id="d7eeb-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="d7eeb-109">Parameter</span></span>| <span data-ttu-id="d7eeb-110">型</span><span class="sxs-lookup"><span data-stu-id="d7eeb-110">Type</span></span>| <span data-ttu-id="d7eeb-111">説明</span><span class="sxs-lookup"><span data-stu-id="d7eeb-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="d7eeb-112">sessionId</span><span class="sxs-lookup"><span data-stu-id="d7eeb-112">sessionId</span></span>| <span data-ttu-id="d7eeb-113">string</span><span class="sxs-lookup"><span data-stu-id="d7eeb-113">string</span></span>| <span data-ttu-id="d7eeb-114">検索するセッションの ID。</span><span class="sxs-lookup"><span data-stu-id="d7eeb-114">the ID of the session to look up.</span></span>| 
| <span data-ttu-id="d7eeb-115">scid</span><span class="sxs-lookup"><span data-stu-id="d7eeb-115">scid</span></span>| <span data-ttu-id="d7eeb-116">guid</span><span class="sxs-lookup"><span data-stu-id="d7eeb-116">guid</span></span>| <span data-ttu-id="d7eeb-117">ルックアップ サービス構成の ID です。</span><span class="sxs-lookup"><span data-stu-id="d7eeb-117">The ID of the service config to look up.</span></span>| 
| <span data-ttu-id="d7eeb-118">path</span><span class="sxs-lookup"><span data-stu-id="d7eeb-118">path</span></span>| <span data-ttu-id="d7eeb-119">string</span><span class="sxs-lookup"><span data-stu-id="d7eeb-119">string</span></span>| <span data-ttu-id="d7eeb-120">返されるデータ項目へのパス。</span><span class="sxs-lookup"><span data-stu-id="d7eeb-120">The path to the data items to return.</span></span> <span data-ttu-id="d7eeb-121">一致するすべてのディレクトリとサブディレクトリを取得する返されます。</span><span class="sxs-lookup"><span data-stu-id="d7eeb-121">All matching directories and subdirectories get returned.</span></span> <span data-ttu-id="d7eeb-122">有効な文字には、大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9)、アンダー スコア (_)、およびスラッシュ (/) が含まれます。</span><span class="sxs-lookup"><span data-stu-id="d7eeb-122">Valid characters include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), and forward slash (/).</span></span> <span data-ttu-id="d7eeb-123">空にすることがあります。</span><span class="sxs-lookup"><span data-stu-id="d7eeb-123">May be empty.</span></span> <span data-ttu-id="d7eeb-124">256 の最大の長さ。</span><span class="sxs-lookup"><span data-stu-id="d7eeb-124">Max length of 256.</span></span>| 
  
<a id="ID4EFC"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="d7eeb-125">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="d7eeb-125">Valid methods</span></span>

[<span data-ttu-id="d7eeb-126">GET</span><span class="sxs-lookup"><span data-stu-id="d7eeb-126">GET</span></span>](uri-sessionssessionidscidssciddatapath-get.md)

<span data-ttu-id="d7eeb-127">&nbsp;&nbsp;指定されたパスのファイル情報の一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="d7eeb-127">&nbsp;&nbsp;Lists file information at a specified path.</span></span>
 
<a id="ID4EPC"></a>

 
## <a name="see-also"></a><span data-ttu-id="d7eeb-128">関連項目</span><span class="sxs-lookup"><span data-stu-id="d7eeb-128">See also</span></span>
 
<a id="ID4ERC"></a>

 
##### <a name="parent"></a><span data-ttu-id="d7eeb-129">Parent</span><span class="sxs-lookup"><span data-stu-id="d7eeb-129">Parent</span></span> 

[<span data-ttu-id="d7eeb-130">タイトル ストレージ URI</span><span class="sxs-lookup"><span data-stu-id="d7eeb-130">Title Storage URIs</span></span>](atoc-reference-storagev2.md)

   