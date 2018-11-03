---
title: DELETE (/users/xuid({xuid})/inbox/{messageId})
assetID: c54eede3-3e3b-2cbe-1be9-8bf3a48171bc
permalink: en-us/docs/xboxlive/rest/uri-usersxuidinboxmessageiddelete.html
author: KevinAsgari
description: " DELETE (/users/xuid({xuid})/inbox/{messageId})"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 9d550147fe18a0233fd4f0a62ccb2826ef2a5c03
ms.sourcegitcommit: 144f5f127fc4fbd852f2f6780ef26054192d68fc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/03/2018
ms.locfileid: "5983248"
---
# <a name="delete-usersxuidxuidinboxmessageid"></a><span data-ttu-id="ffacc-104">DELETE (/users/xuid({xuid})/inbox/{messageId})</span><span class="sxs-lookup"><span data-stu-id="ffacc-104">DELETE (/users/xuid({xuid})/inbox/{messageId})</span></span>
<span data-ttu-id="ffacc-105">ユーザーの受信トレイでユーザーのメッセージを削除します。</span><span class="sxs-lookup"><span data-stu-id="ffacc-105">Deletes a user message in the user's inbox.</span></span> <span data-ttu-id="ffacc-106">これらの Uri のドメインが`msg.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="ffacc-106">The domain for these URIs is `msg.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="ffacc-107">注釈</span><span class="sxs-lookup"><span data-stu-id="ffacc-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="ffacc-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="ffacc-108">URI parameters</span></span>](#ID4ECB)
  * [<span data-ttu-id="ffacc-109">Authorization</span><span class="sxs-lookup"><span data-stu-id="ffacc-109">Authorization</span></span>](#ID4EPB)
  * [<span data-ttu-id="ffacc-110">要求本文</span><span class="sxs-lookup"><span data-stu-id="ffacc-110">Request body</span></span>](#ID4E1B)
  * [<span data-ttu-id="ffacc-111">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="ffacc-111">HTTP status codes</span></span>](#ID4EHC)
  * [<span data-ttu-id="ffacc-112">JavaScript Object Notation (JSON) の応答</span><span class="sxs-lookup"><span data-stu-id="ffacc-112">JavaScript Object Notation (JSON) Response</span></span>](#ID4EAE)
  * [<span data-ttu-id="ffacc-113">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="ffacc-113">Effect of privacy settings on resource</span></span>](#ID4EYF)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a><span data-ttu-id="ffacc-114">注釈</span><span class="sxs-lookup"><span data-stu-id="ffacc-114">Remarks</span></span> 
 
<span data-ttu-id="ffacc-115">削除操作では、等です。</span><span class="sxs-lookup"><span data-stu-id="ffacc-115">The delete operation is idempotent.</span></span>
 
<span data-ttu-id="ffacc-116">この API はサポートのみのコンテンツの種類は、"アプリケーション/json"、呼び出しごとの HTTP ヘッダーのために必要です。</span><span class="sxs-lookup"><span data-stu-id="ffacc-116">The only content type this API supports is "application/json", which is required in the HTTP headers of each call.</span></span> 
  
<a id="ID4ECB"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="ffacc-117">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="ffacc-117">URI parameters</span></span> 
 
| <span data-ttu-id="ffacc-118">パラメーター</span><span class="sxs-lookup"><span data-stu-id="ffacc-118">Parameter</span></span>| <span data-ttu-id="ffacc-119">型</span><span class="sxs-lookup"><span data-stu-id="ffacc-119">Type</span></span>| <span data-ttu-id="ffacc-120">説明</span><span class="sxs-lookup"><span data-stu-id="ffacc-120">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="ffacc-121">xuid</span><span class="sxs-lookup"><span data-stu-id="ffacc-121">xuid</span></span> | <span data-ttu-id="ffacc-122">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="ffacc-122">unsigned 64-bit integer</span></span> | <span data-ttu-id="ffacc-123">Xbox ユーザー ID (XUID) の要求を行っているプレイヤーです。</span><span class="sxs-lookup"><span data-stu-id="ffacc-123">The Xbox User ID (XUID) of the player who is making the request.</span></span> | 
| <span data-ttu-id="ffacc-124">メッセージ Id</span><span class="sxs-lookup"><span data-stu-id="ffacc-124">messageId</span></span> | <span data-ttu-id="ffacc-125">文字列 [50]</span><span class="sxs-lookup"><span data-stu-id="ffacc-125">string[50]</span></span> | <span data-ttu-id="ffacc-126">取得または削除されるメッセージの ID です。</span><span class="sxs-lookup"><span data-stu-id="ffacc-126">ID of the message being retrieved or deleted.</span></span> | 
  
<a id="ID4EPB"></a>

 
## <a name="authorization"></a><span data-ttu-id="ffacc-127">Authorization</span><span class="sxs-lookup"><span data-stu-id="ffacc-127">Authorization</span></span> 
 
<span data-ttu-id="ffacc-128">独自のユーザーがユーザーのメッセージを削除する要求が必要です。</span><span class="sxs-lookup"><span data-stu-id="ffacc-128">You must have your own user claim to delete a user message.</span></span>
  
<a id="ID4E1B"></a>

 
## <a name="request-body"></a><span data-ttu-id="ffacc-129">要求本文</span><span class="sxs-lookup"><span data-stu-id="ffacc-129">Request body</span></span> 
 
<span data-ttu-id="ffacc-130">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="ffacc-130">No objects are sent in the body of this request.</span></span>
  
<a id="ID4EHC"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="ffacc-131">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="ffacc-131">HTTP status codes</span></span> 
 
<span data-ttu-id="ffacc-132">サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、状態コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="ffacc-132">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="ffacc-133">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="ffacc-133">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="ffacc-134">コード</span><span class="sxs-lookup"><span data-stu-id="ffacc-134">Code</span></span>| <span data-ttu-id="ffacc-135">説明</span><span class="sxs-lookup"><span data-stu-id="ffacc-135">Description</span></span>| 
| --- | --- | --- | --- | --- | 
| <span data-ttu-id="ffacc-136">204</span><span class="sxs-lookup"><span data-stu-id="ffacc-136">204</span></span>| <span data-ttu-id="ffacc-137">成功します。</span><span class="sxs-lookup"><span data-stu-id="ffacc-137">Success.</span></span>| 
| <span data-ttu-id="ffacc-138">403</span><span class="sxs-lookup"><span data-stu-id="ffacc-138">403</span></span>| <span data-ttu-id="ffacc-139">XUID に変換することはできませんか、有効な XUID クレームが見つかったことはできません。</span><span class="sxs-lookup"><span data-stu-id="ffacc-139">The XUID cannot be converted or a valid XUID claim cannot be found.</span></span>| 
| <span data-ttu-id="ffacc-140">404</span><span class="sxs-lookup"><span data-stu-id="ffacc-140">404</span></span>| <span data-ttu-id="ffacc-141">URI のメッセージ ID を解析できませんまたは、XUID が URI ではありません。</span><span class="sxs-lookup"><span data-stu-id="ffacc-141">Message ID in the URI cannot be parsed or an XUID is missing in the URI.</span></span>| 
| <span data-ttu-id="ffacc-142">500</span><span class="sxs-lookup"><span data-stu-id="ffacc-142">500</span></span>| <span data-ttu-id="ffacc-143">サーバー側の一般的なエラーです。</span><span class="sxs-lookup"><span data-stu-id="ffacc-143">General server-side error.</span></span>| 
  
<a id="ID4EAE"></a>

 
## <a name="javascript-object-notation-json-response"></a><span data-ttu-id="ffacc-144">JavaScript Object Notation (JSON) の応答</span><span class="sxs-lookup"><span data-stu-id="ffacc-144">JavaScript Object Notation (JSON) Response</span></span> 
 
<span data-ttu-id="ffacc-145">エラーの場合、サービスは、サービスの環境から値を含めることができますが、全て、errorResponse オブジェクトを返すことがあります。</span><span class="sxs-lookup"><span data-stu-id="ffacc-145">In case of error, the service may return an errorResponse object, which may contain values from the environment of the service.</span></span>
 
| <span data-ttu-id="ffacc-146">プロパティ</span><span class="sxs-lookup"><span data-stu-id="ffacc-146">Property</span></span>| <span data-ttu-id="ffacc-147">型</span><span class="sxs-lookup"><span data-stu-id="ffacc-147">Type</span></span>| <span data-ttu-id="ffacc-148">説明</span><span class="sxs-lookup"><span data-stu-id="ffacc-148">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="ffacc-149">errorSource</span><span class="sxs-lookup"><span data-stu-id="ffacc-149">errorSource</span></span>| <span data-ttu-id="ffacc-150">string</span><span class="sxs-lookup"><span data-stu-id="ffacc-150">string</span></span>| <span data-ttu-id="ffacc-151">エラーが発生した場所を指定します。</span><span class="sxs-lookup"><span data-stu-id="ffacc-151">An indication of where the error originated.</span></span>| 
| <span data-ttu-id="ffacc-152">errorCode</span><span class="sxs-lookup"><span data-stu-id="ffacc-152">errorCode</span></span>| <span data-ttu-id="ffacc-153">int</span><span class="sxs-lookup"><span data-stu-id="ffacc-153">int</span></span>| <span data-ttu-id="ffacc-154">(Null にすることができます)、エラーに関連付けられている数値コードです。</span><span class="sxs-lookup"><span data-stu-id="ffacc-154">Numeric code associated with the error (can be null).</span></span>| 
| <span data-ttu-id="ffacc-155">エラー メッセージ</span><span class="sxs-lookup"><span data-stu-id="ffacc-155">errorMessage</span></span>| <span data-ttu-id="ffacc-156">string</span><span class="sxs-lookup"><span data-stu-id="ffacc-156">string</span></span>| <span data-ttu-id="ffacc-157">詳細を表示するように構成する場合のエラーの説明します。</span><span class="sxs-lookup"><span data-stu-id="ffacc-157">Details of the error if configured to show details.</span></span>| 
  
<a id="ID4EYF"></a>

 
## <a name="effect-of-privacy-settings-on-resource"></a><span data-ttu-id="ffacc-158">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="ffacc-158">Effect of privacy settings on resource</span></span> 
 
<span data-ttu-id="ffacc-159">のみ、独自のユーザーのメッセージを削除することができます。</span><span class="sxs-lookup"><span data-stu-id="ffacc-159">Only you can delete your own user messages.</span></span> 
  
<a id="ID4EDG"></a>

 
## <a name="see-also"></a><span data-ttu-id="ffacc-160">関連項目</span><span class="sxs-lookup"><span data-stu-id="ffacc-160">See also</span></span>
 
<a id="ID4EFG"></a>

 
##### <a name="parent"></a><span data-ttu-id="ffacc-161">Parent</span><span class="sxs-lookup"><span data-stu-id="ffacc-161">Parent</span></span>  

[<span data-ttu-id="ffacc-162">/users/xuid({xuid})/inbox</span><span class="sxs-lookup"><span data-stu-id="ffacc-162">/users/xuid({xuid})/inbox</span></span>](uri-usersxuidinbox.md)

  
<a id="ID4ETG"></a>

 
##### <a name="reference--standard-http-status-codesadditionalhttpstatuscodesmd"></a><span data-ttu-id="ffacc-163">参照[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)</span><span class="sxs-lookup"><span data-stu-id="ffacc-163">Reference  [Standard HTTP status codes](../../additional/httpstatuscodes.md)</span></span>

   