---
title: DELETE (/users/xuid({xuid})/inbox/{messageId})
assetID: c54eede3-3e3b-2cbe-1be9-8bf3a48171bc
permalink: en-us/docs/xboxlive/rest/uri-usersxuidinboxmessageiddelete.html
description: " DELETE (/users/xuid({xuid})/inbox/{messageId})"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 80ec2a462648177cc6bfc846b9c84278821b0e5e
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57594107"
---
# <a name="delete-usersxuidxuidinboxmessageid"></a><span data-ttu-id="b9c0e-104">DELETE (/users/xuid({xuid})/inbox/{messageId})</span><span class="sxs-lookup"><span data-stu-id="b9c0e-104">DELETE (/users/xuid({xuid})/inbox/{messageId})</span></span>
<span data-ttu-id="b9c0e-105">ユーザーの受信トレイ内のユーザー メッセージを削除します。</span><span class="sxs-lookup"><span data-stu-id="b9c0e-105">Deletes a user message in the user's inbox.</span></span> <span data-ttu-id="b9c0e-106">これらの Uri のドメインが`msg.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="b9c0e-106">The domain for these URIs is `msg.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="b9c0e-107">注釈</span><span class="sxs-lookup"><span data-stu-id="b9c0e-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="b9c0e-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="b9c0e-108">URI parameters</span></span>](#ID4ECB)
  * [<span data-ttu-id="b9c0e-109">承認</span><span class="sxs-lookup"><span data-stu-id="b9c0e-109">Authorization</span></span>](#ID4EPB)
  * [<span data-ttu-id="b9c0e-110">要求本文</span><span class="sxs-lookup"><span data-stu-id="b9c0e-110">Request body</span></span>](#ID4E1B)
  * [<span data-ttu-id="b9c0e-111">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="b9c0e-111">HTTP status codes</span></span>](#ID4EHC)
  * [<span data-ttu-id="b9c0e-112">JavaScript Object Notation (JSON) の応答</span><span class="sxs-lookup"><span data-stu-id="b9c0e-112">JavaScript Object Notation (JSON) Response</span></span>](#ID4EAE)
  * [<span data-ttu-id="b9c0e-113">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="b9c0e-113">Effect of privacy settings on resource</span></span>](#ID4EYF)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a><span data-ttu-id="b9c0e-114">注釈</span><span class="sxs-lookup"><span data-stu-id="b9c0e-114">Remarks</span></span> 
 
<span data-ttu-id="b9c0e-115">削除操作は、べき等です。</span><span class="sxs-lookup"><span data-stu-id="b9c0e-115">The delete operation is idempotent.</span></span>
 
<span data-ttu-id="b9c0e-116">この API はサポートのみコンテンツの種類は、"application/json"に必要な各呼び出しの HTTP ヘッダーが。</span><span class="sxs-lookup"><span data-stu-id="b9c0e-116">The only content type this API supports is "application/json", which is required in the HTTP headers of each call.</span></span> 
  
<a id="ID4ECB"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="b9c0e-117">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="b9c0e-117">URI parameters</span></span> 
 
| <span data-ttu-id="b9c0e-118">パラメーター</span><span class="sxs-lookup"><span data-stu-id="b9c0e-118">Parameter</span></span>| <span data-ttu-id="b9c0e-119">種類</span><span class="sxs-lookup"><span data-stu-id="b9c0e-119">Type</span></span>| <span data-ttu-id="b9c0e-120">説明</span><span class="sxs-lookup"><span data-stu-id="b9c0e-120">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="b9c0e-121">xuid</span><span class="sxs-lookup"><span data-stu-id="b9c0e-121">xuid</span></span> | <span data-ttu-id="b9c0e-122">64 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="b9c0e-122">unsigned 64-bit integer</span></span> | <span data-ttu-id="b9c0e-123">Xbox ユーザー ID (XUID) の要求を行っているプレーヤー。</span><span class="sxs-lookup"><span data-stu-id="b9c0e-123">The Xbox User ID (XUID) of the player who is making the request.</span></span> | 
| <span data-ttu-id="b9c0e-124">メッセージ Id</span><span class="sxs-lookup"><span data-stu-id="b9c0e-124">messageId</span></span> | <span data-ttu-id="b9c0e-125">string[50]</span><span class="sxs-lookup"><span data-stu-id="b9c0e-125">string[50]</span></span> | <span data-ttu-id="b9c0e-126">メッセージの取得中または削除の ID。</span><span class="sxs-lookup"><span data-stu-id="b9c0e-126">ID of the message being retrieved or deleted.</span></span> | 
  
<a id="ID4EPB"></a>

 
## <a name="authorization"></a><span data-ttu-id="b9c0e-127">Authorization</span><span class="sxs-lookup"><span data-stu-id="b9c0e-127">Authorization</span></span> 
 
<span data-ttu-id="b9c0e-128">要求のユーザー メッセージを削除して、独自のユーザーが必要です。</span><span class="sxs-lookup"><span data-stu-id="b9c0e-128">You must have your own user claim to delete a user message.</span></span>
  
<a id="ID4E1B"></a>

 
## <a name="request-body"></a><span data-ttu-id="b9c0e-129">要求本文</span><span class="sxs-lookup"><span data-stu-id="b9c0e-129">Request body</span></span> 
 
<span data-ttu-id="b9c0e-130">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="b9c0e-130">No objects are sent in the body of this request.</span></span>
  
<a id="ID4EHC"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="b9c0e-131">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="b9c0e-131">HTTP status codes</span></span> 
 
<span data-ttu-id="b9c0e-132">サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="b9c0e-132">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="b9c0e-133">Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。</span><span class="sxs-lookup"><span data-stu-id="b9c0e-133">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="b9c0e-134">コード</span><span class="sxs-lookup"><span data-stu-id="b9c0e-134">Code</span></span>| <span data-ttu-id="b9c0e-135">説明</span><span class="sxs-lookup"><span data-stu-id="b9c0e-135">Description</span></span>| 
| --- | --- | --- | --- | --- | 
| <span data-ttu-id="b9c0e-136">204</span><span class="sxs-lookup"><span data-stu-id="b9c0e-136">204</span></span>| <span data-ttu-id="b9c0e-137">成功しました。</span><span class="sxs-lookup"><span data-stu-id="b9c0e-137">Success.</span></span>| 
| <span data-ttu-id="b9c0e-138">403</span><span class="sxs-lookup"><span data-stu-id="b9c0e-138">403</span></span>| <span data-ttu-id="b9c0e-139">XUID を変換することはできませんまたは有効な XUID 要求が見つかりません。</span><span class="sxs-lookup"><span data-stu-id="b9c0e-139">The XUID cannot be converted or a valid XUID claim cannot be found.</span></span>| 
| <span data-ttu-id="b9c0e-140">404</span><span class="sxs-lookup"><span data-stu-id="b9c0e-140">404</span></span>| <span data-ttu-id="b9c0e-141">URI にメッセージ ID を解析できないか、XUID が URI ではありません。</span><span class="sxs-lookup"><span data-stu-id="b9c0e-141">Message ID in the URI cannot be parsed or an XUID is missing in the URI.</span></span>| 
| <span data-ttu-id="b9c0e-142">500</span><span class="sxs-lookup"><span data-stu-id="b9c0e-142">500</span></span>| <span data-ttu-id="b9c0e-143">サーバー側の一般エラーです。</span><span class="sxs-lookup"><span data-stu-id="b9c0e-143">General server-side error.</span></span>| 
  
<a id="ID4EAE"></a>

 
## <a name="javascript-object-notation-json-response"></a><span data-ttu-id="b9c0e-144">JavaScript Object Notation (JSON) の応答</span><span class="sxs-lookup"><span data-stu-id="b9c0e-144">JavaScript Object Notation (JSON) Response</span></span> 
 
<span data-ttu-id="b9c0e-145">エラーが発生した場合、サービスはサービスの環境から値を含むことができる、存在する errorResponse オブジェクトを返す可能性があります。</span><span class="sxs-lookup"><span data-stu-id="b9c0e-145">In case of error, the service may return an errorResponse object, which may contain values from the environment of the service.</span></span>
 
| <span data-ttu-id="b9c0e-146">プロパティ</span><span class="sxs-lookup"><span data-stu-id="b9c0e-146">Property</span></span>| <span data-ttu-id="b9c0e-147">種類</span><span class="sxs-lookup"><span data-stu-id="b9c0e-147">Type</span></span>| <span data-ttu-id="b9c0e-148">説明</span><span class="sxs-lookup"><span data-stu-id="b9c0e-148">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="b9c0e-149">errorSource</span><span class="sxs-lookup"><span data-stu-id="b9c0e-149">errorSource</span></span>| <span data-ttu-id="b9c0e-150">string</span><span class="sxs-lookup"><span data-stu-id="b9c0e-150">string</span></span>| <span data-ttu-id="b9c0e-151">エラーの発生元を示します。</span><span class="sxs-lookup"><span data-stu-id="b9c0e-151">An indication of where the error originated.</span></span>| 
| <span data-ttu-id="b9c0e-152">エラー コード</span><span class="sxs-lookup"><span data-stu-id="b9c0e-152">errorCode</span></span>| <span data-ttu-id="b9c0e-153">int</span><span class="sxs-lookup"><span data-stu-id="b9c0e-153">int</span></span>| <span data-ttu-id="b9c0e-154">(Null にすることができます)、エラーに関連付けられている数値コードです。</span><span class="sxs-lookup"><span data-stu-id="b9c0e-154">Numeric code associated with the error (can be null).</span></span>| 
| <span data-ttu-id="b9c0e-155">エラー メッセージ</span><span class="sxs-lookup"><span data-stu-id="b9c0e-155">errorMessage</span></span>| <span data-ttu-id="b9c0e-156">string</span><span class="sxs-lookup"><span data-stu-id="b9c0e-156">string</span></span>| <span data-ttu-id="b9c0e-157">詳細を表示するように構成してある場合、エラーの詳細です。</span><span class="sxs-lookup"><span data-stu-id="b9c0e-157">Details of the error if configured to show details.</span></span>| 
  
<a id="ID4EYF"></a>

 
## <a name="effect-of-privacy-settings-on-resource"></a><span data-ttu-id="b9c0e-158">リソースのプライバシーの設定の効果</span><span class="sxs-lookup"><span data-stu-id="b9c0e-158">Effect of privacy settings on resource</span></span> 
 
<span data-ttu-id="b9c0e-159">のみ、独自のユーザー メッセージを削除することができます。</span><span class="sxs-lookup"><span data-stu-id="b9c0e-159">Only you can delete your own user messages.</span></span> 
  
<a id="ID4EDG"></a>

 
## <a name="see-also"></a><span data-ttu-id="b9c0e-160">関連項目</span><span class="sxs-lookup"><span data-stu-id="b9c0e-160">See also</span></span>
 
<a id="ID4EFG"></a>

 
##### <a name="parent"></a><span data-ttu-id="b9c0e-161">Parent</span><span class="sxs-lookup"><span data-stu-id="b9c0e-161">Parent</span></span>  

[<span data-ttu-id="b9c0e-162">/users/xuid({xuid})/inbox</span><span class="sxs-lookup"><span data-stu-id="b9c0e-162">/users/xuid({xuid})/inbox</span></span>](uri-usersxuidinbox.md)

  
<a id="ID4ETG"></a>

 
##### <a name="reference--standard-http-status-codesadditionalhttpstatuscodesmd"></a><span data-ttu-id="b9c0e-163">参照[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)</span><span class="sxs-lookup"><span data-stu-id="b9c0e-163">Reference  [Standard HTTP status codes](../../additional/httpstatuscodes.md)</span></span>

   