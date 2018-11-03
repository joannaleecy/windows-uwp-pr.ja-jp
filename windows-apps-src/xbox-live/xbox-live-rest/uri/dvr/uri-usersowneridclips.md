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
ms.sourcegitcommit: 144f5f127fc4fbd852f2f6780ef26054192d68fc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/03/2018
ms.locfileid: "5992022"
---
# <a name="usersowneridclips"></a><span data-ttu-id="091e1-104">/users/{ownerId}/clips</span><span class="sxs-lookup"><span data-stu-id="091e1-104">/users/{ownerId}/clips</span></span>
<span data-ttu-id="091e1-105">ユーザーのクリップのアクセスの一覧です。</span><span class="sxs-lookup"><span data-stu-id="091e1-105">Access list of user's clips.</span></span> <span data-ttu-id="091e1-106">これらの Uri のドメインは、`gameclipsmetadata.xboxlive.com`と`gameclipstransfer.xboxlive.com`に対象の URI の機能に依存します。</span><span class="sxs-lookup"><span data-stu-id="091e1-106">The domains for these URIs are `gameclipsmetadata.xboxlive.com` and `gameclipstransfer.xboxlive.com`, depending on the function of the URI in question.</span></span>
 
  * [<span data-ttu-id="091e1-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="091e1-107">URI parameters</span></span>](#ID4EX)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="091e1-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="091e1-108">URI parameters</span></span>
 
| <span data-ttu-id="091e1-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="091e1-109">Parameter</span></span>| <span data-ttu-id="091e1-110">型</span><span class="sxs-lookup"><span data-stu-id="091e1-110">Type</span></span>| <span data-ttu-id="091e1-111">説明</span><span class="sxs-lookup"><span data-stu-id="091e1-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="091e1-112">ownerId</span><span class="sxs-lookup"><span data-stu-id="091e1-112">ownerId</span></span>| <span data-ttu-id="091e1-113">string</span><span class="sxs-lookup"><span data-stu-id="091e1-113">string</span></span>| <span data-ttu-id="091e1-114">リソースにアクセスしているユーザーのユーザー id。</span><span class="sxs-lookup"><span data-stu-id="091e1-114">User identity of the user whose resource is being accessed.</span></span> <span data-ttu-id="091e1-115">サポートされる形式:"me"または"xuid(123456789)"します。</span><span class="sxs-lookup"><span data-stu-id="091e1-115">Supported formats: "me" or "xuid(123456789)".</span></span> <span data-ttu-id="091e1-116">最大長: 16 します。</span><span class="sxs-lookup"><span data-stu-id="091e1-116">Maximum length: 16.</span></span>| 
  
<a id="ID4EVB"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="091e1-117">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="091e1-117">Valid methods</span></span>

[<span data-ttu-id="091e1-118">GET (/users/{ownerId}/clips)</span><span class="sxs-lookup"><span data-stu-id="091e1-118">GET (/users/{ownerId}/clips)</span></span>](uri-usersowneridclipsget.md)

<span data-ttu-id="091e1-119">&nbsp;&nbsp;ユーザーのクリップの一覧を取得します。</span><span class="sxs-lookup"><span data-stu-id="091e1-119">&nbsp;&nbsp;Retrieve list of user's clips.</span></span>
 
<a id="ID4E6B"></a>

 
## <a name="see-also"></a><span data-ttu-id="091e1-120">関連項目</span><span class="sxs-lookup"><span data-stu-id="091e1-120">See also</span></span>
 
<a id="ID4EBC"></a>

 
##### <a name="parent"></a><span data-ttu-id="091e1-121">Parent</span><span class="sxs-lookup"><span data-stu-id="091e1-121">Parent</span></span> 

[<span data-ttu-id="091e1-122">ゲーム DVR URI</span><span class="sxs-lookup"><span data-stu-id="091e1-122">Game DVR URIs</span></span>](atoc-reference-dvr.md)

   