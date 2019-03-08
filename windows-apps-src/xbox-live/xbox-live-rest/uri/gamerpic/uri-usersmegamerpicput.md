---
title: PUT (/users/me/gamerpic)
assetID: ddf71c62-197d-a81d-35a7-47c6dc9e1b0c
permalink: en-us/docs/xboxlive/rest/uri-usersmegamerpicput.html
description: " PUT (/users/me/gamerpic)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 7aedc7cbd8366c9cb8d3a60e2cb1f5e843b24a8a
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57661657"
---
# <a name="put-usersmegamerpic"></a><span data-ttu-id="5e702-104">PUT (/users/me/gamerpic)</span><span class="sxs-lookup"><span data-stu-id="5e702-104">PUT (/users/me/gamerpic)</span></span>
<span data-ttu-id="5e702-105">1080 x 1080 gamerpic をアップロードします。</span><span class="sxs-lookup"><span data-stu-id="5e702-105">Uploads a 1080x1080 gamerpic.</span></span> 
  * [<span data-ttu-id="5e702-106">要求本文</span><span class="sxs-lookup"><span data-stu-id="5e702-106">Request body</span></span>](#ID4EQ)
  * [<span data-ttu-id="5e702-107">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="5e702-107">HTTP status codes</span></span>](#ID4EZ)
  * [<span data-ttu-id="5e702-108">応答本文</span><span class="sxs-lookup"><span data-stu-id="5e702-108">Response body</span></span>](#ID4EXC)
 
<a id="ID4EQ"></a>

 
## <a name="request-body"></a><span data-ttu-id="5e702-109">要求本文</span><span class="sxs-lookup"><span data-stu-id="5e702-109">Request body</span></span>
 
<span data-ttu-id="5e702-110">要求本文は、gamerpic (1080 x 1080 の PNG ファイルです)。</span><span class="sxs-lookup"><span data-stu-id="5e702-110">The request body is a gamerpic (1080x1080 PNG file).</span></span>
  
<a id="ID4EZ"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="5e702-111">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="5e702-111">HTTP status codes</span></span>
 
<span data-ttu-id="5e702-112">サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="5e702-112">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="5e702-113">Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。</span><span class="sxs-lookup"><span data-stu-id="5e702-113">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="5e702-114">コード</span><span class="sxs-lookup"><span data-stu-id="5e702-114">Code</span></span>| <span data-ttu-id="5e702-115">理由語句</span><span class="sxs-lookup"><span data-stu-id="5e702-115">Reason phrase</span></span>| <span data-ttu-id="5e702-116">説明</span><span class="sxs-lookup"><span data-stu-id="5e702-116">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="5e702-117">200</span><span class="sxs-lookup"><span data-stu-id="5e702-117">200</span></span>| <span data-ttu-id="5e702-118">OK</span><span class="sxs-lookup"><span data-stu-id="5e702-118">OK</span></span>| <span data-ttu-id="5e702-119">正常に取得します。</span><span class="sxs-lookup"><span data-stu-id="5e702-119">Successful GET.</span></span>| 
| <span data-ttu-id="5e702-120">201</span><span class="sxs-lookup"><span data-stu-id="5e702-120">201</span></span>| <span data-ttu-id="5e702-121">作成されます。</span><span class="sxs-lookup"><span data-stu-id="5e702-121">Created.</span></span>| <span data-ttu-id="5e702-122">アップロードが正常に完了しました。</span><span class="sxs-lookup"><span data-stu-id="5e702-122">Upload was successful.</span></span>| 
| <span data-ttu-id="5e702-123">403</span><span class="sxs-lookup"><span data-stu-id="5e702-123">403</span></span>| <span data-ttu-id="5e702-124">Forbidden</span><span class="sxs-lookup"><span data-stu-id="5e702-124">Forbidden</span></span>| <span data-ttu-id="5e702-125">特権は失効します。</span><span class="sxs-lookup"><span data-stu-id="5e702-125">The privilege is revoked.</span></span>| 
| <span data-ttu-id="5e702-126">500</span><span class="sxs-lookup"><span data-stu-id="5e702-126">500</span></span>| <span data-ttu-id="5e702-127">エラー</span><span class="sxs-lookup"><span data-stu-id="5e702-127">Error</span></span>| <span data-ttu-id="5e702-128">問題が発生しました。</span><span class="sxs-lookup"><span data-stu-id="5e702-128">Something went wrong.</span></span>| 
  
<a id="ID4EXC"></a>

 
## <a name="response-body"></a><span data-ttu-id="5e702-129">応答本文</span><span class="sxs-lookup"><span data-stu-id="5e702-129">Response body</span></span>
 
<span data-ttu-id="5e702-130">応答の本文では、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="5e702-130">No objects are sent in the body of the response.</span></span>
  
<a id="ID4ECD"></a>

 
## <a name="see-also"></a><span data-ttu-id="5e702-131">関連項目</span><span class="sxs-lookup"><span data-stu-id="5e702-131">See also</span></span>
 
<a id="ID4EED"></a>

 
##### <a name="parent"></a><span data-ttu-id="5e702-132">Parent</span><span class="sxs-lookup"><span data-stu-id="5e702-132">Parent</span></span> 

[<span data-ttu-id="5e702-133">/users/me/gamerpic</span><span class="sxs-lookup"><span data-stu-id="5e702-133">/users/me/gamerpic</span></span>](uri-usersmegamerpic.md)

   