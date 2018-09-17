---
title: /users/{ownerId}/clips
assetID: cc200b89-dc63-9ab5-b037-7a910f46dae9
permalink: en-us/docs/xboxlive/rest/uri-usersowneridclips.html
author: KevinAsgari
description: " /users/{ownerId}/clips"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: b0819ab8f0014b945a2340ebf7252bbe9d8d8726
ms.sourcegitcommit: 9e2c34a5ed3134aeca7eb9490f05b20eb9a3e5df
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/17/2018
ms.locfileid: "3984666"
---
# <a name="usersowneridclips"></a><span data-ttu-id="ddfdc-104">/users/{ownerId}/clips</span><span class="sxs-lookup"><span data-stu-id="ddfdc-104">/users/{ownerId}/clips</span></span>
<span data-ttu-id="ddfdc-105">ユーザーのクリップのアクセスの一覧です。</span><span class="sxs-lookup"><span data-stu-id="ddfdc-105">Access list of user's clips.</span></span> <span data-ttu-id="ddfdc-106">これらの Uri のドメインは、`gameclipsmetadata.xboxlive.com`と`gameclipstransfer.xboxlive.com`問題の URI の機能に応じて、します。</span><span class="sxs-lookup"><span data-stu-id="ddfdc-106">The domains for these URIs are `gameclipsmetadata.xboxlive.com` and `gameclipstransfer.xboxlive.com`, depending on the function of the URI in question.</span></span>
 
  * [<span data-ttu-id="ddfdc-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="ddfdc-107">URI parameters</span></span>](#ID4EX)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="ddfdc-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="ddfdc-108">URI parameters</span></span>
 
| <span data-ttu-id="ddfdc-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="ddfdc-109">Parameter</span></span>| <span data-ttu-id="ddfdc-110">型</span><span class="sxs-lookup"><span data-stu-id="ddfdc-110">Type</span></span>| <span data-ttu-id="ddfdc-111">説明</span><span class="sxs-lookup"><span data-stu-id="ddfdc-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="ddfdc-112">ownerId</span><span class="sxs-lookup"><span data-stu-id="ddfdc-112">ownerId</span></span>| <span data-ttu-id="ddfdc-113">string</span><span class="sxs-lookup"><span data-stu-id="ddfdc-113">string</span></span>| <span data-ttu-id="ddfdc-114">そのリソースにアクセスしているユーザーのユーザー id。</span><span class="sxs-lookup"><span data-stu-id="ddfdc-114">User identity of the user whose resource is being accessed.</span></span> <span data-ttu-id="ddfdc-115">サポートされる形式:"me"または"xuid(123456789)"です。</span><span class="sxs-lookup"><span data-stu-id="ddfdc-115">Supported formats: "me" or "xuid(123456789)".</span></span> <span data-ttu-id="ddfdc-116">最大長: 16 です。</span><span class="sxs-lookup"><span data-stu-id="ddfdc-116">Maximum length: 16.</span></span>| 
  
<a id="ID4EVB"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="ddfdc-117">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="ddfdc-117">Valid methods</span></span>

[<span data-ttu-id="ddfdc-118">GET (/users/{ownerId}/clips)</span><span class="sxs-lookup"><span data-stu-id="ddfdc-118">GET (/users/{ownerId}/clips)</span></span>](uri-usersowneridclipsget.md)

<span data-ttu-id="ddfdc-119">&nbsp;&nbsp;ユーザーのクリップの一覧を取得します。</span><span class="sxs-lookup"><span data-stu-id="ddfdc-119">&nbsp;&nbsp;Retrieve list of user's clips.</span></span>
 
<a id="ID4E6B"></a>

 
## <a name="see-also"></a><span data-ttu-id="ddfdc-120">関連項目</span><span class="sxs-lookup"><span data-stu-id="ddfdc-120">See also</span></span>
 
<a id="ID4EBC"></a>

 
##### <a name="parent"></a><span data-ttu-id="ddfdc-121">Parent</span><span class="sxs-lookup"><span data-stu-id="ddfdc-121">Parent</span></span> 

[<span data-ttu-id="ddfdc-122">ゲーム DVR URI</span><span class="sxs-lookup"><span data-stu-id="ddfdc-122">Game DVR URIs</span></span>](atoc-reference-dvr.md)

   