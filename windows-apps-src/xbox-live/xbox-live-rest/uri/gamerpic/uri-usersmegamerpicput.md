---
title: PUT (/users/me/gamerpic)
assetID: ddf71c62-197d-a81d-35a7-47c6dc9e1b0c
permalink: en-us/docs/xboxlive/rest/uri-usersmegamerpicput.html
author: KevinAsgari
description: " PUT (/users/me/gamerpic)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 0d9346303e82dea2dbbd60b542c4ee207dd40901
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/02/2018
ms.locfileid: "5935852"
---
# <a name="put-usersmegamerpic"></a><span data-ttu-id="95889-104">PUT (/users/me/gamerpic)</span><span class="sxs-lookup"><span data-stu-id="95889-104">PUT (/users/me/gamerpic)</span></span>
<span data-ttu-id="95889-105">1080 x 1080 ゲーマー アイコンをアップロードします。</span><span class="sxs-lookup"><span data-stu-id="95889-105">Uploads a 1080x1080 gamerpic.</span></span> 
  * [<span data-ttu-id="95889-106">要求本文</span><span class="sxs-lookup"><span data-stu-id="95889-106">Request body</span></span>](#ID4EQ)
  * [<span data-ttu-id="95889-107">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="95889-107">HTTP status codes</span></span>](#ID4EZ)
  * [<span data-ttu-id="95889-108">応答本文</span><span class="sxs-lookup"><span data-stu-id="95889-108">Response body</span></span>](#ID4EXC)
 
<a id="ID4EQ"></a>

 
## <a name="request-body"></a><span data-ttu-id="95889-109">要求本文</span><span class="sxs-lookup"><span data-stu-id="95889-109">Request body</span></span>
 
<span data-ttu-id="95889-110">要求本文は、ゲーマー アイコン (1080 x 1080 PNG ファイルです)。</span><span class="sxs-lookup"><span data-stu-id="95889-110">The request body is a gamerpic (1080x1080 PNG file).</span></span>
  
<a id="ID4EZ"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="95889-111">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="95889-111">HTTP status codes</span></span>
 
<span data-ttu-id="95889-112">サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、状態コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="95889-112">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="95889-113">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="95889-113">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="95889-114">コード</span><span class="sxs-lookup"><span data-stu-id="95889-114">Code</span></span>| <span data-ttu-id="95889-115">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="95889-115">Reason phrase</span></span>| <span data-ttu-id="95889-116">説明</span><span class="sxs-lookup"><span data-stu-id="95889-116">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="95889-117">200</span><span class="sxs-lookup"><span data-stu-id="95889-117">200</span></span>| <span data-ttu-id="95889-118">OK</span><span class="sxs-lookup"><span data-stu-id="95889-118">OK</span></span>| <span data-ttu-id="95889-119">成功した取得します。</span><span class="sxs-lookup"><span data-stu-id="95889-119">Successful GET.</span></span>| 
| <span data-ttu-id="95889-120">201</span><span class="sxs-lookup"><span data-stu-id="95889-120">201</span></span>| <span data-ttu-id="95889-121">作成されます。</span><span class="sxs-lookup"><span data-stu-id="95889-121">Created.</span></span>| <span data-ttu-id="95889-122">アップロードが正常に完了しました。</span><span class="sxs-lookup"><span data-stu-id="95889-122">Upload was successful.</span></span>| 
| <span data-ttu-id="95889-123">403</span><span class="sxs-lookup"><span data-stu-id="95889-123">403</span></span>| <span data-ttu-id="95889-124">Forbidden</span><span class="sxs-lookup"><span data-stu-id="95889-124">Forbidden</span></span>| <span data-ttu-id="95889-125">特権は失効されます。</span><span class="sxs-lookup"><span data-stu-id="95889-125">The privilege is revoked.</span></span>| 
| <span data-ttu-id="95889-126">500</span><span class="sxs-lookup"><span data-stu-id="95889-126">500</span></span>| <span data-ttu-id="95889-127">エラー</span><span class="sxs-lookup"><span data-stu-id="95889-127">Error</span></span>| <span data-ttu-id="95889-128">問題が発生しました。</span><span class="sxs-lookup"><span data-stu-id="95889-128">Something went wrong.</span></span>| 
  
<a id="ID4EXC"></a>

 
## <a name="response-body"></a><span data-ttu-id="95889-129">応答本文</span><span class="sxs-lookup"><span data-stu-id="95889-129">Response body</span></span>
 
<span data-ttu-id="95889-130">応答の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="95889-130">No objects are sent in the body of the response.</span></span>
  
<a id="ID4ECD"></a>

 
## <a name="see-also"></a><span data-ttu-id="95889-131">関連項目</span><span class="sxs-lookup"><span data-stu-id="95889-131">See also</span></span>
 
<a id="ID4EED"></a>

 
##### <a name="parent"></a><span data-ttu-id="95889-132">Parent</span><span class="sxs-lookup"><span data-stu-id="95889-132">Parent</span></span> 

[<span data-ttu-id="95889-133">/users/me/gamerpic</span><span class="sxs-lookup"><span data-stu-id="95889-133">/users/me/gamerpic</span></span>](uri-usersmegamerpic.md)

   