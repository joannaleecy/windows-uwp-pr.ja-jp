---
title: /users/{ownerId}/clips
assetID: cc200b89-dc63-9ab5-b037-7a910f46dae9
permalink: en-us/docs/xboxlive/rest/uri-usersowneridclips.html
author: KevinAsgari
description: " /users/{ownerId}/clips"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 755d30796c7e948a2fe97e84986a74a461795f83
ms.sourcegitcommit: 3257416aebb5a7b1515e107866806f8bd57845a8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/17/2018
ms.locfileid: "7150077"
---
# <a name="usersowneridclips"></a><span data-ttu-id="a7a80-104">/users/{ownerId}/clips</span><span class="sxs-lookup"><span data-stu-id="a7a80-104">/users/{ownerId}/clips</span></span>
<span data-ttu-id="a7a80-105">ユーザーのクリップのアクセスの一覧です。</span><span class="sxs-lookup"><span data-stu-id="a7a80-105">Access list of user's clips.</span></span> <span data-ttu-id="a7a80-106">これらの Uri のドメイン`gameclipsmetadata.xboxlive.com`と`gameclipstransfer.xboxlive.com`に対象の URI の機能に依存します。</span><span class="sxs-lookup"><span data-stu-id="a7a80-106">The domains for these URIs are `gameclipsmetadata.xboxlive.com` and `gameclipstransfer.xboxlive.com`, depending on the function of the URI in question.</span></span>
 
  * [<span data-ttu-id="a7a80-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="a7a80-107">URI parameters</span></span>](#ID4EX)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="a7a80-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="a7a80-108">URI parameters</span></span>
 
| <span data-ttu-id="a7a80-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="a7a80-109">Parameter</span></span>| <span data-ttu-id="a7a80-110">型</span><span class="sxs-lookup"><span data-stu-id="a7a80-110">Type</span></span>| <span data-ttu-id="a7a80-111">説明</span><span class="sxs-lookup"><span data-stu-id="a7a80-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="a7a80-112">ownerId</span><span class="sxs-lookup"><span data-stu-id="a7a80-112">ownerId</span></span>| <span data-ttu-id="a7a80-113">string</span><span class="sxs-lookup"><span data-stu-id="a7a80-113">string</span></span>| <span data-ttu-id="a7a80-114">そのリソースにアクセスしているユーザーのユーザー id。</span><span class="sxs-lookup"><span data-stu-id="a7a80-114">User identity of the user whose resource is being accessed.</span></span> <span data-ttu-id="a7a80-115">サポートされる形式:"me"または"xuid(123456789)"。</span><span class="sxs-lookup"><span data-stu-id="a7a80-115">Supported formats: "me" or "xuid(123456789)".</span></span> <span data-ttu-id="a7a80-116">最大長: 16 します。</span><span class="sxs-lookup"><span data-stu-id="a7a80-116">Maximum length: 16.</span></span>| 
  
<a id="ID4EVB"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="a7a80-117">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="a7a80-117">Valid methods</span></span>

[<span data-ttu-id="a7a80-118">GET (/users/{ownerId}/clips)</span><span class="sxs-lookup"><span data-stu-id="a7a80-118">GET (/users/{ownerId}/clips)</span></span>](uri-usersowneridclipsget.md)

<span data-ttu-id="a7a80-119">&nbsp;&nbsp;ユーザーのクリップの一覧を取得します。</span><span class="sxs-lookup"><span data-stu-id="a7a80-119">&nbsp;&nbsp;Retrieve list of user's clips.</span></span>
 
<a id="ID4E6B"></a>

 
## <a name="see-also"></a><span data-ttu-id="a7a80-120">関連項目</span><span class="sxs-lookup"><span data-stu-id="a7a80-120">See also</span></span>
 
<a id="ID4EBC"></a>

 
##### <a name="parent"></a><span data-ttu-id="a7a80-121">Parent</span><span class="sxs-lookup"><span data-stu-id="a7a80-121">Parent</span></span> 

[<span data-ttu-id="a7a80-122">ゲーム DVR URI</span><span class="sxs-lookup"><span data-stu-id="a7a80-122">Game DVR URIs</span></span>](atoc-reference-dvr.md)

   