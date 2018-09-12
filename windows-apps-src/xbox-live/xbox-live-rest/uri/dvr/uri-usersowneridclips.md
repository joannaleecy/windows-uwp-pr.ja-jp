---
title: /users/{ownerId} クリップ/
assetID: cc200b89-dc63-9ab5-b037-7a910f46dae9
permalink: en-us/docs/xboxlive/rest/uri-usersowneridclips.html
author: KevinAsgari
description: " /users/{ownerId} クリップ/"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: b0819ab8f0014b945a2340ebf7252bbe9d8d8726
ms.sourcegitcommit: 2a63ee6770413bc35ace09b14f56b60007be7433
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3935624"
---
# <a name="usersowneridclips"></a><span data-ttu-id="43daf-104">/users/{ownerId} クリップ/</span><span class="sxs-lookup"><span data-stu-id="43daf-104">/users/{ownerId}/clips</span></span>
<span data-ttu-id="43daf-105">ユーザーのクリップのアクセスの一覧です。</span><span class="sxs-lookup"><span data-stu-id="43daf-105">Access list of user's clips.</span></span> <span data-ttu-id="43daf-106">これらの Uri のドメインは、`gameclipsmetadata.xboxlive.com`と`gameclipstransfer.xboxlive.com`対象の URI の機能に応じて、します。</span><span class="sxs-lookup"><span data-stu-id="43daf-106">The domains for these URIs are `gameclipsmetadata.xboxlive.com` and `gameclipstransfer.xboxlive.com`, depending on the function of the URI in question.</span></span>
 
  * [<span data-ttu-id="43daf-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="43daf-107">URI parameters</span></span>](#ID4EX)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="43daf-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="43daf-108">URI parameters</span></span>
 
| <span data-ttu-id="43daf-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="43daf-109">Parameter</span></span>| <span data-ttu-id="43daf-110">型</span><span class="sxs-lookup"><span data-stu-id="43daf-110">Type</span></span>| <span data-ttu-id="43daf-111">説明</span><span class="sxs-lookup"><span data-stu-id="43daf-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="43daf-112">ownerId</span><span class="sxs-lookup"><span data-stu-id="43daf-112">ownerId</span></span>| <span data-ttu-id="43daf-113">string</span><span class="sxs-lookup"><span data-stu-id="43daf-113">string</span></span>| <span data-ttu-id="43daf-114">リソースにアクセスしているユーザーのユーザー id。</span><span class="sxs-lookup"><span data-stu-id="43daf-114">User identity of the user whose resource is being accessed.</span></span> <span data-ttu-id="43daf-115">サポートされる形式:"me"または"xuid(123456789)"です。</span><span class="sxs-lookup"><span data-stu-id="43daf-115">Supported formats: "me" or "xuid(123456789)".</span></span> <span data-ttu-id="43daf-116">最大長: 16 します。</span><span class="sxs-lookup"><span data-stu-id="43daf-116">Maximum length: 16.</span></span>| 
  
<a id="ID4EVB"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="43daf-117">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="43daf-117">Valid methods</span></span>

[<span data-ttu-id="43daf-118">取得する (/users/{ownerId} クリップ/)</span><span class="sxs-lookup"><span data-stu-id="43daf-118">GET (/users/{ownerId}/clips)</span></span>](uri-usersowneridclipsget.md)

<span data-ttu-id="43daf-119">&nbsp;&nbsp;ユーザーのクリップの一覧を取得します。</span><span class="sxs-lookup"><span data-stu-id="43daf-119">&nbsp;&nbsp;Retrieve list of user's clips.</span></span>
 
<a id="ID4E6B"></a>

 
## <a name="see-also"></a><span data-ttu-id="43daf-120">関連項目</span><span class="sxs-lookup"><span data-stu-id="43daf-120">See also</span></span>
 
<a id="ID4EBC"></a>

 
##### <a name="parent"></a><span data-ttu-id="43daf-121">Parent</span><span class="sxs-lookup"><span data-stu-id="43daf-121">Parent</span></span> 

[<span data-ttu-id="43daf-122">ゲーム DVR Uri</span><span class="sxs-lookup"><span data-stu-id="43daf-122">Game DVR URIs</span></span>](atoc-reference-dvr.md)

   