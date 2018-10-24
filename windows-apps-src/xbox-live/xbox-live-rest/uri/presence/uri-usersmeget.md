---
title: GET (/users/me)
assetID: 726c279b-73fb-02ea-cbff-700ff2dc31af
permalink: en-us/docs/xboxlive/rest/uri-usersmeget.html
author: KevinAsgari
description: " GET (/users/me)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 3a10b8704de47ef62a283c1b634b4a5212623e5c
ms.sourcegitcommit: 4b97117d3aff38db89d560502a3c372f12bb6ed5
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/24/2018
ms.locfileid: "5431383"
---
# <a name="get-usersme"></a><span data-ttu-id="f2e05-104">GET (/users/me)</span><span class="sxs-lookup"><span data-stu-id="f2e05-104">GET (/users/me)</span></span>
<span data-ttu-id="f2e05-105">ユーザーの XUID を確認することがなく、現在のユーザーの[PresenceRecord](../../json/json-presencerecord.md)を取得します。</span><span class="sxs-lookup"><span data-stu-id="f2e05-105">Obtain the current user's [PresenceRecord](../../json/json-presencerecord.md) without having to know the user's XUID.</span></span>
<span data-ttu-id="f2e05-106">これらの Uri のドメインが`userpresence.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="f2e05-106">The domain for these URIs is `userpresence.xboxlive.com`.</span></span>

  * [<span data-ttu-id="f2e05-107">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="f2e05-107">Query string parameters</span></span>](#ID4EZ)
  * [<span data-ttu-id="f2e05-108">Authorization</span><span class="sxs-lookup"><span data-stu-id="f2e05-108">Authorization</span></span>](#ID4EIC)
  * [<span data-ttu-id="f2e05-109">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="f2e05-109">Required Request Headers</span></span>](#ID4ELD)
  * [<span data-ttu-id="f2e05-110">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="f2e05-110">Optional Request Headers</span></span>](#ID4EPF)
  * [<span data-ttu-id="f2e05-111">要求本文</span><span class="sxs-lookup"><span data-stu-id="f2e05-111">Request body</span></span>](#ID4EPG)
  * [<span data-ttu-id="f2e05-112">応答本文</span><span class="sxs-lookup"><span data-stu-id="f2e05-112">Response body</span></span>](#ID4E1G)

<a id="ID4EZ"></a>


## <a name="query-string-parameters"></a><span data-ttu-id="f2e05-113">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="f2e05-113">Query string parameters</span></span>

| <span data-ttu-id="f2e05-114">パラメーター</span><span class="sxs-lookup"><span data-stu-id="f2e05-114">Parameter</span></span>| <span data-ttu-id="f2e05-115">型</span><span class="sxs-lookup"><span data-stu-id="f2e05-115">Type</span></span>| <span data-ttu-id="f2e05-116">説明</span><span class="sxs-lookup"><span data-stu-id="f2e05-116">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="f2e05-117">level</span><span class="sxs-lookup"><span data-stu-id="f2e05-117">level</span></span>| <span data-ttu-id="f2e05-118">string</span><span class="sxs-lookup"><span data-stu-id="f2e05-118">string</span></span>| <span data-ttu-id="f2e05-119">省略可能。</span><span class="sxs-lookup"><span data-stu-id="f2e05-119">Optional.</span></span> <ul><li><span data-ttu-id="f2e05-120"><b>ユーザー</b>: ユーザー ノードのみを返します。</span><span class="sxs-lookup"><span data-stu-id="f2e05-120"><b>user</b>: Returns only the user node.</span></span></li><li><span data-ttu-id="f2e05-121"><b>デバイス</b>: ユーザー ノードとデバイス ノードを返します。</span><span class="sxs-lookup"><span data-stu-id="f2e05-121"><b>device</b>: Returns user node and device nodes.</span></span></li><li><span data-ttu-id="f2e05-122"><b>タイトル</b>: 既定値します。</span><span class="sxs-lookup"><span data-stu-id="f2e05-122"><b>title</b>: Default.</span></span> <span data-ttu-id="f2e05-123">アクティビティを除くツリー全体を返します。</span><span class="sxs-lookup"><span data-stu-id="f2e05-123">Returns the whole tree except activity.</span></span></li><li><span data-ttu-id="f2e05-124"><b>すべて</b>: アクティビティ レベルのプレゼンスを含むツリー全体を返します。</span><span class="sxs-lookup"><span data-stu-id="f2e05-124"><b>all</b>: Returns the whole tree, including activity-level presence.</span></span></li></ul> | 

<a id="ID4EIC"></a>


## <a name="authorization"></a><span data-ttu-id="f2e05-125">Authorization</span><span class="sxs-lookup"><span data-stu-id="f2e05-125">Authorization</span></span>

| <span data-ttu-id="f2e05-126">型</span><span class="sxs-lookup"><span data-stu-id="f2e05-126">Type</span></span>| <span data-ttu-id="f2e05-127">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="f2e05-127">Required</span></span>| <span data-ttu-id="f2e05-128">説明</span><span class="sxs-lookup"><span data-stu-id="f2e05-128">Description</span></span>| <span data-ttu-id="f2e05-129">不足している場合、応答</span><span class="sxs-lookup"><span data-stu-id="f2e05-129">Response if missing</span></span>|
| --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="f2e05-130">XUID</span><span class="sxs-lookup"><span data-stu-id="f2e05-130">XUID</span></span>| <span data-ttu-id="f2e05-131">はい</span><span class="sxs-lookup"><span data-stu-id="f2e05-131">Yes</span></span>| <span data-ttu-id="f2e05-132">呼び出し元のように、Xbox ユーザー ID (XUID)</span><span class="sxs-lookup"><span data-stu-id="f2e05-132">Xbox User ID (XUID) of the caller</span></span>| <span data-ttu-id="f2e05-133">403 Forbidden</span><span class="sxs-lookup"><span data-stu-id="f2e05-133">403 Forbidden</span></span>|

<a id="ID4ELD"></a>


## <a name="required-request-headers"></a><span data-ttu-id="f2e05-134">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="f2e05-134">Required Request Headers</span></span>

| <span data-ttu-id="f2e05-135">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="f2e05-135">Header</span></span>| <span data-ttu-id="f2e05-136">型</span><span class="sxs-lookup"><span data-stu-id="f2e05-136">Type</span></span>| <span data-ttu-id="f2e05-137">説明</span><span class="sxs-lookup"><span data-stu-id="f2e05-137">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="f2e05-138">Authorization</span><span class="sxs-lookup"><span data-stu-id="f2e05-138">Authorization</span></span>| <span data-ttu-id="f2e05-139">string</span><span class="sxs-lookup"><span data-stu-id="f2e05-139">string</span></span>| <span data-ttu-id="f2e05-140">HTTP の認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="f2e05-140">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="f2e05-141">値の例:"XBL3.0 x =&lt;userhash > です。&lt;トークン >"。</span><span class="sxs-lookup"><span data-stu-id="f2e05-141">Example value: "XBL3.0 x=&lt;userhash>;&lt;token>".</span></span>|
| <span data-ttu-id="f2e05-142">x xbl コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="f2e05-142">x-xbl-contract-version</span></span>| <span data-ttu-id="f2e05-143">string</span><span class="sxs-lookup"><span data-stu-id="f2e05-143">string</span></span>| <span data-ttu-id="f2e05-144">この要求する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="f2e05-144">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="f2e05-145">要求はのみにルーティングすると、サービスの認証トークン内の要求ヘッダーの有効性を確認した後。</span><span class="sxs-lookup"><span data-stu-id="f2e05-145">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, and so on.</span></span> <span data-ttu-id="f2e05-146">値の例: 3, vnext します。</span><span class="sxs-lookup"><span data-stu-id="f2e05-146">Example values: 3, vnext.</span></span>|
| <span data-ttu-id="f2e05-147">Accept</span><span class="sxs-lookup"><span data-stu-id="f2e05-147">Accept</span></span>| <span data-ttu-id="f2e05-148">string</span><span class="sxs-lookup"><span data-stu-id="f2e05-148">string</span></span>| <span data-ttu-id="f2e05-149">コンテンツの種類の受け入れられるします。</span><span class="sxs-lookup"><span data-stu-id="f2e05-149">Content-Types that are acceptable.</span></span> <span data-ttu-id="f2e05-150">プレゼンスでサポートされている 1 つだけがアプリケーション/json がヘッダーで指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f2e05-150">The only one supported by Presence is application/json, but it must be specified in the header.</span></span>|
| <span data-ttu-id="f2e05-151">同意言語</span><span class="sxs-lookup"><span data-stu-id="f2e05-151">Accept-Language</span></span>| <span data-ttu-id="f2e05-152">string</span><span class="sxs-lookup"><span data-stu-id="f2e05-152">string</span></span>| <span data-ttu-id="f2e05-153">応答で文字列を許容できるロケールです。</span><span class="sxs-lookup"><span data-stu-id="f2e05-153">Acceptable locale for strings in the response.</span></span> <span data-ttu-id="f2e05-154">値の例: EN-US にします。</span><span class="sxs-lookup"><span data-stu-id="f2e05-154">Example values: en-US.</span></span>|
| <span data-ttu-id="f2e05-155">Host</span><span class="sxs-lookup"><span data-stu-id="f2e05-155">Host</span></span>| <span data-ttu-id="f2e05-156">string</span><span class="sxs-lookup"><span data-stu-id="f2e05-156">string</span></span>| <span data-ttu-id="f2e05-157">サーバーのドメイン名。</span><span class="sxs-lookup"><span data-stu-id="f2e05-157">Domain name of the server.</span></span> <span data-ttu-id="f2e05-158">値の例: presencebeta.xboxlive.com します。</span><span class="sxs-lookup"><span data-stu-id="f2e05-158">Example value: presencebeta.xboxlive.com.</span></span>|

<a id="ID4EPF"></a>


## <a name="optional-request-headers"></a><span data-ttu-id="f2e05-159">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="f2e05-159">Optional Request Headers</span></span>

| <span data-ttu-id="f2e05-160">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="f2e05-160">Header</span></span>| <span data-ttu-id="f2e05-161">型</span><span class="sxs-lookup"><span data-stu-id="f2e05-161">Type</span></span>| <span data-ttu-id="f2e05-162">説明</span><span class="sxs-lookup"><span data-stu-id="f2e05-162">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="f2e05-163">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="f2e05-163">X-RequestedServiceVersion</span></span>|  | <span data-ttu-id="f2e05-164">この要求する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="f2e05-164">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="f2e05-165">要求はのみにルーティングすると、サービスの認証トークン内の要求ヘッダーの有効性を確認した後。</span><span class="sxs-lookup"><span data-stu-id="f2e05-165">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, and so on.</span></span> <span data-ttu-id="f2e05-166">既定値: 1 です。</span><span class="sxs-lookup"><span data-stu-id="f2e05-166">Default value: 1.</span></span>|

<a id="ID4EPG"></a>


## <a name="request-body"></a><span data-ttu-id="f2e05-167">要求本文</span><span class="sxs-lookup"><span data-stu-id="f2e05-167">Request body</span></span>

<span data-ttu-id="f2e05-168">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="f2e05-168">No objects are sent in the body of this request.</span></span>

<a id="ID4E1G"></a>


## <a name="response-body"></a><span data-ttu-id="f2e05-169">応答本文</span><span class="sxs-lookup"><span data-stu-id="f2e05-169">Response body</span></span>

<a id="ID4EAH"></a>


### <a name="sample-response"></a><span data-ttu-id="f2e05-170">応答の例</span><span class="sxs-lookup"><span data-stu-id="f2e05-170">Sample response</span></span>

<span data-ttu-id="f2e05-171">このメソッドは、 [PresenceRecord](../../json/json-presencerecord.md)を返します。</span><span class="sxs-lookup"><span data-stu-id="f2e05-171">This method returns a [PresenceRecord](../../json/json-presencerecord.md).</span></span>


```cpp
{
  xuid:"0123456789",
  state:"online",
  devices:
  [{
    type:"D",
    titles:
    [{
      id:"12341234",
      name:"Contoso 5",
      state:"active",
      placement:"fill",
      timestamp:"2012-09-17T07:15:23.4930000",
      activity:
      {
        richPresence:"Team Deathmatch on Nirvana"
      }
    },
    {
      id:"12341235",
      name:"Contoso Waypoint",
      timestamp:"2012-09-17T07:15:23.4930000",
      placement:"snapped",
      state:"active",
      activity:
      {
        richPresence:"Using radar"
      }
    }]
  },
  {
    type:W8,
    titles:
    [{
      id:"23452345",
      name:"Contoso Gamehelp",
      state:"active",
      placement:"full",
      timestamp:"2012-09-17T07:15:23.4930000",
      activity:
      {
        richPresence:"Nirvana page",
      }
    }]
  }]
}

```


<a id="ID4EQH"></a>


## <a name="see-also"></a><span data-ttu-id="f2e05-172">関連項目</span><span class="sxs-lookup"><span data-stu-id="f2e05-172">See also</span></span>

<a id="ID4ESH"></a>


##### <a name="parent"></a><span data-ttu-id="f2e05-173">Parent</span><span class="sxs-lookup"><span data-stu-id="f2e05-173">Parent</span></span>

[<span data-ttu-id="f2e05-174">/users/me</span><span class="sxs-lookup"><span data-stu-id="f2e05-174">/users/me</span></span>](uri-usersme.md)
