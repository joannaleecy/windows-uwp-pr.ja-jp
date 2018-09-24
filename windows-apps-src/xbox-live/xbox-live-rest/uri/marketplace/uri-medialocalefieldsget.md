---
title: GET (/media/{marketplaceId}/fields)
assetID: 1d535344-8522-0fd1-4daa-cd0f0a0f1121
permalink: en-us/docs/xboxlive/rest/uri-medialocalefieldsget.html
author: KevinAsgari
description: " GET (/media/{marketplaceId}/fields)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 4c46981121393ce80228d857c32a01784d58af96
ms.sourcegitcommit: 194ab5aa395226580753869c6b66fce88be83522
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/24/2018
ms.locfileid: "4152476"
---
# <a name="get-mediamarketplaceidfields"></a><span data-ttu-id="6cf13-104">GET (/media/{marketplaceId}/fields)</span><span class="sxs-lookup"><span data-stu-id="6cf13-104">GET (/media/{marketplaceId}/fields)</span></span>
<span data-ttu-id="6cf13-105">フィールド トークンを取得します。</span><span class="sxs-lookup"><span data-stu-id="6cf13-105">Gets the fields token.</span></span> <span data-ttu-id="6cf13-106">これらの Uri のドメインが`eds.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="6cf13-106">The domain for these URIs is `eds.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="6cf13-107">注釈</span><span class="sxs-lookup"><span data-stu-id="6cf13-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="6cf13-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="6cf13-108">URI parameters</span></span>](#ID4EGC)
  * [<span data-ttu-id="6cf13-109">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="6cf13-109">Query string parameters</span></span>](#ID4ERC)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a><span data-ttu-id="6cf13-110">注釈</span><span class="sxs-lookup"><span data-stu-id="6cf13-110">Remarks</span></span>
 
<span data-ttu-id="6cf13-111">エンターテイメント探索サービス (EDS) 既定では、Api は、各項目のフィールドの非常に小さい最小セットを返します。</span><span class="sxs-lookup"><span data-stu-id="6cf13-111">The Entertainment Discovery Services (EDS) APIs, by default, returns a very small minimum set of fields for each item:</span></span>
 
   * <span data-ttu-id="6cf13-112">メディア項目の種類</span><span class="sxs-lookup"><span data-stu-id="6cf13-112">Media item type</span></span>
   * <span data-ttu-id="6cf13-113">メディア グループ</span><span class="sxs-lookup"><span data-stu-id="6cf13-113">Media group</span></span>
   * <span data-ttu-id="6cf13-114">ID</span><span class="sxs-lookup"><span data-stu-id="6cf13-114">Id</span></span>
   * <span data-ttu-id="6cf13-115">名前</span><span class="sxs-lookup"><span data-stu-id="6cf13-115">Name</span></span>
  
<span data-ttu-id="6cf13-116">詳細を取得するのには、Api は、するその他のデータの一部を返すように指定する**フィールド**パラメーターを受け入れます。</span><span class="sxs-lookup"><span data-stu-id="6cf13-116">To get more information, the APIs accept a **fields** parameter that specifies which additional pieces of data should be returned.</span></span> <span data-ttu-id="6cf13-117">多くの使用可能なフィールドがあるため、API 呼び出しごとに完全に自分の名前を指定することが大幅に膨張要求します。</span><span class="sxs-lookup"><span data-stu-id="6cf13-117">Because there are many possible fields, specifying their name in full for each API call would greatly bloat the request.</span></span> <span data-ttu-id="6cf13-118">代わりに、名前は、その他の Api に渡すことができるより小さい値を生成するこの API に渡すことができます。</span><span class="sxs-lookup"><span data-stu-id="6cf13-118">Instead, the names can be passed into this API which will generate a much smaller value that can be passed into the other APIs.</span></span>
 
<span data-ttu-id="6cf13-119">このパラメーターを受け取る API, 指定された値はすべて指定したメディア項目の種類のすべてのフィールドのスーパー セットである必要があります。</span><span class="sxs-lookup"><span data-stu-id="6cf13-119">For any API that accepts this parameter, the provided value must be the superset of all fields in all specified media item types.</span></span> <span data-ttu-id="6cf13-120">別のメディア項目の種類のフィールドの異なるセットを指定することはできません。</span><span class="sxs-lookup"><span data-stu-id="6cf13-120">It's not possible to specify different sets of fields for different media item types.</span></span> <span data-ttu-id="6cf13-121">ただし、フィールドは、1 つのメディア項目の種類がない別、それに適用する場合にのみ表示、メディア項目の種類のデータが存在する (への呼び出しで"AvatarBodyType"が含まれている場合に、[を取得する (/media/{marketplaceId} フィールド/)]()、AvatarItems のみがフィールドを含む)。</span><span class="sxs-lookup"><span data-stu-id="6cf13-121">However, if a field applies to one media item type but not another, it will only appear in the media item types where data exists (for example, if "AvatarBodyType" is included in the call to [GET (/media/{marketplaceId}/fields)](), only AvatarItems will contain the field).</span></span>
 
<span data-ttu-id="6cf13-122">この API から返される値は、実際に強くキャッシュ--、それらは変更されません除く EDS の展開の間でします。</span><span class="sxs-lookup"><span data-stu-id="6cf13-122">The values returned from this API are highly cacheable -- in fact, they should not change except between deployments of EDS.</span></span> <span data-ttu-id="6cf13-123">キャッシュが必要な場合、キャッシュ最後のユーザーのセッションしなくなったことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="6cf13-123">It's recommended that, if caching is desired, the cache last no longer than the session of the user.</span></span>
 
<span data-ttu-id="6cf13-124">実際のフィールド名を受け付けるだけでなくこの API は、"all"を有効な値として受け取ります。</span><span class="sxs-lookup"><span data-stu-id="6cf13-124">In addition to accepting the actual field names, this API accepts "all" as a valid value.</span></span> <span data-ttu-id="6cf13-125">これにより、指定することは、各フィールドが含まれている値が生成されます。</span><span class="sxs-lookup"><span data-stu-id="6cf13-125">This will generate a value that contains each field it's possible to specify.</span></span> <span data-ttu-id="6cf13-126">"All"の値の使用は、開発、デバッグ、テスト目的でに対してのみお勧めします。</span><span class="sxs-lookup"><span data-stu-id="6cf13-126">Use of the "all" value is recommended only for development, debugging, and testing purposes.</span></span>
 
<span data-ttu-id="6cf13-127">送信する代わりに、 `desired={list of fields separated by a '.'}` **フィールド**トークンを受け取るいずれかの API にします。</span><span class="sxs-lookup"><span data-stu-id="6cf13-127">Alternatively, you can send `desired={list of fields separated by a '.'}` to any API that accepts the **fields** token.</span></span>
 
<span data-ttu-id="6cf13-128">まとめて**目的**と**フィールド**の両方に渡すことはできません。</span><span class="sxs-lookup"><span data-stu-id="6cf13-128">You cannot pass in both **desired** and **fields** together.</span></span>
  
<a id="ID4EGC"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="6cf13-129">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="6cf13-129">URI parameters</span></span>
 
| <span data-ttu-id="6cf13-130">パラメーター</span><span class="sxs-lookup"><span data-stu-id="6cf13-130">Parameter</span></span>| <span data-ttu-id="6cf13-131">型</span><span class="sxs-lookup"><span data-stu-id="6cf13-131">Type</span></span>| <span data-ttu-id="6cf13-132">説明</span><span class="sxs-lookup"><span data-stu-id="6cf13-132">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="6cf13-133">marketplaceId</span><span class="sxs-lookup"><span data-stu-id="6cf13-133">marketplaceId</span></span>| <span data-ttu-id="6cf13-134">string</span><span class="sxs-lookup"><span data-stu-id="6cf13-134">string</span></span>| <span data-ttu-id="6cf13-135">必須。</span><span class="sxs-lookup"><span data-stu-id="6cf13-135">Required.</span></span> <span data-ttu-id="6cf13-136">文字列<b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>から取得した値です。</span><span class="sxs-lookup"><span data-stu-id="6cf13-136">String value obtained from the <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>.</span></span>| 
  
<a id="ID4ERC"></a>

 
## <a name="query-string-parameters"></a><span data-ttu-id="6cf13-137">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="6cf13-137">Query string parameters</span></span>
 
| <span data-ttu-id="6cf13-138">パラメーター</span><span class="sxs-lookup"><span data-stu-id="6cf13-138">Parameter</span></span>| <span data-ttu-id="6cf13-139">型</span><span class="sxs-lookup"><span data-stu-id="6cf13-139">Type</span></span>| <span data-ttu-id="6cf13-140">説明</span><span class="sxs-lookup"><span data-stu-id="6cf13-140">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="6cf13-141">目的</span><span class="sxs-lookup"><span data-stu-id="6cf13-141">desired</span></span>| <span data-ttu-id="6cf13-142">string</span><span class="sxs-lookup"><span data-stu-id="6cf13-142">string</span></span>| <span data-ttu-id="6cf13-143">必須。</span><span class="sxs-lookup"><span data-stu-id="6cf13-143">Required.</span></span> <span data-ttu-id="6cf13-144">'."-最小セットのほかに返されるフィールドの一覧を分離します。</span><span class="sxs-lookup"><span data-stu-id="6cf13-144">The '.'-separated list of fields that should be returned in addition to the minimum set.</span></span> <span data-ttu-id="6cf13-145">指定したすべてのフィールドは保証されています (データだけが存在しないの特定の項目の) オブジェクトごとに、返されるが、ここで指定されていない最小セットの外部のフィールドは返されません。</span><span class="sxs-lookup"><span data-stu-id="6cf13-145">Not all fields specified are guaranteed to be returned for each object (data may simply not exist for certain items), but no fields outside the minimum set that aren't specified here will be returned.</span></span> | 
  
<a id="ID4EMD"></a>

 
## <a name="see-also"></a><span data-ttu-id="6cf13-146">関連項目</span><span class="sxs-lookup"><span data-stu-id="6cf13-146">See also</span></span>
 
<a id="ID4EOD"></a>

 
##### <a name="parent"></a><span data-ttu-id="6cf13-147">Parent</span><span class="sxs-lookup"><span data-stu-id="6cf13-147">Parent</span></span> 

[<span data-ttu-id="6cf13-148">/media/{marketplaceId}/fields</span><span class="sxs-lookup"><span data-stu-id="6cf13-148">/media/{marketplaceId}/fields</span></span>](uri-medialocalefields.md)

  
<a id="ID4EYD"></a>

 
##### <a name="further-information"></a><span data-ttu-id="6cf13-149">詳細情報</span><span class="sxs-lookup"><span data-stu-id="6cf13-149">Further Information</span></span> 

[<span data-ttu-id="6cf13-150">EDS 共通ヘッダー</span><span class="sxs-lookup"><span data-stu-id="6cf13-150">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="6cf13-151">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="6cf13-151">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="6cf13-152">EDS クエリの絞り込み条件</span><span class="sxs-lookup"><span data-stu-id="6cf13-152">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="6cf13-153">マーケットプレース URI</span><span class="sxs-lookup"><span data-stu-id="6cf13-153">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

 [<span data-ttu-id="6cf13-154">その他の参照情報</span><span class="sxs-lookup"><span data-stu-id="6cf13-154">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   