---
title: DELETE (/handles/{handleId})
assetID: 71cceff4-3a74-dc05-12db-cfe3f20a8aea
permalink: en-us/docs/xboxlive/rest/uri-handleshandleiddelete.html
author: KevinAsgari
description: " DELETE (/handles/{handleId})"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 15300451495c198a1f15997bae38cb862a9b8186
ms.sourcegitcommit: d10fb9eb5f75f2d10e1c543a177402b50fe4019e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/12/2018
ms.locfileid: "4563194"
---
# <a name="delete-handleshandleid"></a><span data-ttu-id="142a1-104">DELETE (/handles/{handleId})</span><span class="sxs-lookup"><span data-stu-id="142a1-104">DELETE (/handles/{handleId})</span></span>
<span data-ttu-id="142a1-105">ハンドル ID で指定されたハンドルを削除します。</span><span class="sxs-lookup"><span data-stu-id="142a1-105">Deletes handles specified by handle ID.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="142a1-106">このメソッドは、2015年マルチプレイヤーで使用し、および後でそのマルチプレイヤーのバージョンにのみ適用されます。</span><span class="sxs-lookup"><span data-stu-id="142a1-106">This method is used by the 2015 Multiplayer and applies only to that multiplayer version and later.</span></span> <span data-ttu-id="142a1-107">テンプレート コントラクト 104/105 以降で使用するものであり、X Xbl コントラクト バージョンのヘッダー要素が必要です: 104/105 または後ですべての要求します。</span><span class="sxs-lookup"><span data-stu-id="142a1-107">It is intended for use with template contract 104/105 or later, and requires a header element of X-Xbl-Contract-Version: 104/105 or later on every request.</span></span>

  * [<span data-ttu-id="142a1-108">注釈</span><span class="sxs-lookup"><span data-stu-id="142a1-108">Remarks</span></span>](#ID4ET)
  * [<span data-ttu-id="142a1-109">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="142a1-109">URI parameters</span></span>](#ID4EAB)
  * [<span data-ttu-id="142a1-110">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="142a1-110">HTTP status codes</span></span>](#ID4ELB)
  * [<span data-ttu-id="142a1-111">要求本文</span><span class="sxs-lookup"><span data-stu-id="142a1-111">Request body</span></span>](#ID4ESB)
  * [<span data-ttu-id="142a1-112">応答本文</span><span class="sxs-lookup"><span data-stu-id="142a1-112">Response body</span></span>](#ID4E4B)

<a id="ID4ET"></a>


## <a name="remarks"></a><span data-ttu-id="142a1-113">注釈</span><span class="sxs-lookup"><span data-stu-id="142a1-113">Remarks</span></span>
<span data-ttu-id="142a1-114">この HTTP/REST メソッドでは、指定された id のハンドルを削除し、セッションのユーザーの現在のアクティビティをクリアします。</span><span class="sxs-lookup"><span data-stu-id="142a1-114">This HTTP/REST method deletes the handles for the specified ID and clears the user's current activity for the session.</span></span> <span data-ttu-id="142a1-115">このメソッドは、 **Microsoft.Xbox.Services.Multiplayer.MultiplayerService.ClearActivityAsync**でラップすることができます。</span><span class="sxs-lookup"><span data-stu-id="142a1-115">This method can be wrapped by **Microsoft.Xbox.Services.Multiplayer.MultiplayerService.ClearActivityAsync**.</span></span>  
<a id="ID4EAB"></a>


## <a name="uri-parameters"></a><span data-ttu-id="142a1-116">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="142a1-116">URI parameters</span></span>

| <span data-ttu-id="142a1-117">パラメーター</span><span class="sxs-lookup"><span data-stu-id="142a1-117">Parameter</span></span>| <span data-ttu-id="142a1-118">型</span><span class="sxs-lookup"><span data-stu-id="142a1-118">Type</span></span>| <span data-ttu-id="142a1-119">説明</span><span class="sxs-lookup"><span data-stu-id="142a1-119">Description</span></span>|
| --- | --- | --- | --- |
| <span data-ttu-id="142a1-120">ハンドル id を使用</span><span class="sxs-lookup"><span data-stu-id="142a1-120">handleId</span></span>| <span data-ttu-id="142a1-121">GUID</span><span class="sxs-lookup"><span data-stu-id="142a1-121">GUID</span></span>| <span data-ttu-id="142a1-122">セッションのハンドルを一意の ID。</span><span class="sxs-lookup"><span data-stu-id="142a1-122">The unique ID of the handle for the session.</span></span>|

<a id="ID4ELB"></a>


## <a name="http-status-codes"></a><span data-ttu-id="142a1-123">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="142a1-123">HTTP status codes</span></span>
<span data-ttu-id="142a1-124">サービスは、MPSD に適用される HTTP ステータス コードを返します。</span><span class="sxs-lookup"><span data-stu-id="142a1-124">The service returns an HTTP status code as it applies to MPSD.</span></span>  
<a id="ID4ESB"></a>


## <a name="request-body"></a><span data-ttu-id="142a1-125">要求本文</span><span class="sxs-lookup"><span data-stu-id="142a1-125">Request body</span></span>

<span data-ttu-id="142a1-126">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="142a1-126">No objects are sent in the body of this request.</span></span>

<a id="ID4E4B"></a>


## <a name="response-body"></a><span data-ttu-id="142a1-127">応答本文</span><span class="sxs-lookup"><span data-stu-id="142a1-127">Response body</span></span>

<span data-ttu-id="142a1-128">応答の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="142a1-128">No objects are sent in the body of the response.</span></span>

<a id="ID4EIC"></a>


## <a name="see-also"></a><span data-ttu-id="142a1-129">関連項目</span><span class="sxs-lookup"><span data-stu-id="142a1-129">See also</span></span>

<a id="ID4EKC"></a>


##### <a name="parent"></a><span data-ttu-id="142a1-130">Parent</span><span class="sxs-lookup"><span data-stu-id="142a1-130">Parent</span></span>

[<span data-ttu-id="142a1-131">/handles/{handleId}</span><span class="sxs-lookup"><span data-stu-id="142a1-131">/handles/{handleId}</span></span>](uri-handleshandleid.md)
