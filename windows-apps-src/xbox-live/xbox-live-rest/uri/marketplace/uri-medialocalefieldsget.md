---
title: GET (/media/{marketplaceId}/fields)
assetID: 1d535344-8522-0fd1-4daa-cd0f0a0f1121
permalink: en-us/docs/xboxlive/rest/uri-medialocalefieldsget.html
author: KevinAsgari
description: " GET (/media/{marketplaceId}/fields)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 26d172c54dec94990918780bd67b9d47954f8552
ms.sourcegitcommit: 93c0a60cf531c7d9fe7b00e7cf78df86906f9d6e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/23/2018
ms.locfileid: "7560215"
---
# <a name="get-mediamarketplaceidfields"></a><span data-ttu-id="9769f-104">GET (/media/{marketplaceId}/fields)</span><span class="sxs-lookup"><span data-stu-id="9769f-104">GET (/media/{marketplaceId}/fields)</span></span>
<span data-ttu-id="9769f-105">フィールド トークンを取得します。</span><span class="sxs-lookup"><span data-stu-id="9769f-105">Gets the fields token.</span></span> <span data-ttu-id="9769f-106">これらの Uri のドメインが`eds.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="9769f-106">The domain for these URIs is `eds.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="9769f-107">注釈</span><span class="sxs-lookup"><span data-stu-id="9769f-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="9769f-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="9769f-108">URI parameters</span></span>](#ID4EGC)
  * [<span data-ttu-id="9769f-109">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="9769f-109">Query string parameters</span></span>](#ID4ERC)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a><span data-ttu-id="9769f-110">注釈</span><span class="sxs-lookup"><span data-stu-id="9769f-110">Remarks</span></span>
 
<span data-ttu-id="9769f-111">エンターテイメント探索サービス (EDS)、既定での Api は、各項目のフィールドの非常に小さい最小セットを返します。</span><span class="sxs-lookup"><span data-stu-id="9769f-111">The Entertainment Discovery Services (EDS) APIs, by default, returns a very small minimum set of fields for each item:</span></span>
 
   * <span data-ttu-id="9769f-112">メディア項目の種類</span><span class="sxs-lookup"><span data-stu-id="9769f-112">Media item type</span></span>
   * <span data-ttu-id="9769f-113">メディア グループ</span><span class="sxs-lookup"><span data-stu-id="9769f-113">Media group</span></span>
   * <span data-ttu-id="9769f-114">ID</span><span class="sxs-lookup"><span data-stu-id="9769f-114">Id</span></span>
   * <span data-ttu-id="9769f-115">名前</span><span class="sxs-lookup"><span data-stu-id="9769f-115">Name</span></span>
  
<span data-ttu-id="9769f-116">詳細を取得するのには、Api は、返されるデータや追加コンポーネントを指定する**フィールド**パラメーターを受け入れます。</span><span class="sxs-lookup"><span data-stu-id="9769f-116">To get more information, the APIs accept a **fields** parameter that specifies which additional pieces of data should be returned.</span></span> <span data-ttu-id="9769f-117">多くの使用可能なフィールドがあるため、API 呼び出しごとに完全に自分の名前を指定することが大幅に膨張要求します。</span><span class="sxs-lookup"><span data-stu-id="9769f-117">Because there are many possible fields, specifying their name in full for each API call would greatly bloat the request.</span></span> <span data-ttu-id="9769f-118">代わりに、名前は、その他の Api に渡すことができるより小さい値を生成するこの API に渡すことができます。</span><span class="sxs-lookup"><span data-stu-id="9769f-118">Instead, the names can be passed into this API which will generate a much smaller value that can be passed into the other APIs.</span></span>
 
<span data-ttu-id="9769f-119">このパラメーターを受け取る API, 指定された値が指定したメディア項目のすべての種類のすべてのフィールドのスーパー セットである必要があります。</span><span class="sxs-lookup"><span data-stu-id="9769f-119">For any API that accepts this parameter, the provided value must be the superset of all fields in all specified media item types.</span></span> <span data-ttu-id="9769f-120">さまざまなさまざまなメディア項目の種類のフィールドのセットを指定することはできません。</span><span class="sxs-lookup"><span data-stu-id="9769f-120">It's not possible to specify different sets of fields for different media item types.</span></span> <span data-ttu-id="9769f-121">ただし、フィールドは、1 つのメディア項目の種類がない別、それに適用する場合にのみ表示、メディア項目の種類のデータが存在する (への呼び出しで"AvatarBodyType"が含まれている場合に、[を取得する (/media/{marketplaceId}/fields)]()、AvatarItems のみがフィールドを含む)。</span><span class="sxs-lookup"><span data-stu-id="9769f-121">However, if a field applies to one media item type but not another, it will only appear in the media item types where data exists (for example, if "AvatarBodyType" is included in the call to [GET (/media/{marketplaceId}/fields)](), only AvatarItems will contain the field).</span></span>
 
<span data-ttu-id="9769f-122">この API から返される値は、実際に強くキャッシュ -、それらは変更されません除く EDS の展開の間でします。</span><span class="sxs-lookup"><span data-stu-id="9769f-122">The values returned from this API are highly cacheable -- in fact, they should not change except between deployments of EDS.</span></span> <span data-ttu-id="9769f-123">キャッシュが必要な場合、キャッシュ最後のユーザーのセッションしなくなったことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="9769f-123">It's recommended that, if caching is desired, the cache last no longer than the session of the user.</span></span>
 
<span data-ttu-id="9769f-124">実際のフィールド名を受け付けるだけでなくこの API は、"all"を有効な値として受け取ります。</span><span class="sxs-lookup"><span data-stu-id="9769f-124">In addition to accepting the actual field names, this API accepts "all" as a valid value.</span></span> <span data-ttu-id="9769f-125">これにより、指定することは、各フィールドが含まれている値が生成されます。</span><span class="sxs-lookup"><span data-stu-id="9769f-125">This will generate a value that contains each field it's possible to specify.</span></span> <span data-ttu-id="9769f-126">"All"の値の使用は、開発、デバッグ、テスト目的に対してのみお勧めします。</span><span class="sxs-lookup"><span data-stu-id="9769f-126">Use of the "all" value is recommended only for development, debugging, and testing purposes.</span></span>
 
<span data-ttu-id="9769f-127">送信する代わりに、 `desired={list of fields separated by a '.'}` **フィールド**トークンを受け取るいずれかの API にします。</span><span class="sxs-lookup"><span data-stu-id="9769f-127">Alternatively, you can send `desired={list of fields separated by a '.'}` to any API that accepts the **fields** token.</span></span>
 
<span data-ttu-id="9769f-128">まとめて**目的**と**フィールド**の両方に渡すことはできません。</span><span class="sxs-lookup"><span data-stu-id="9769f-128">You cannot pass in both **desired** and **fields** together.</span></span>
  
<a id="ID4EGC"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="9769f-129">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="9769f-129">URI parameters</span></span>
 
| <span data-ttu-id="9769f-130">パラメーター</span><span class="sxs-lookup"><span data-stu-id="9769f-130">Parameter</span></span>| <span data-ttu-id="9769f-131">型</span><span class="sxs-lookup"><span data-stu-id="9769f-131">Type</span></span>| <span data-ttu-id="9769f-132">説明</span><span class="sxs-lookup"><span data-stu-id="9769f-132">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="9769f-133">marketplaceId</span><span class="sxs-lookup"><span data-stu-id="9769f-133">marketplaceId</span></span>| <span data-ttu-id="9769f-134">string</span><span class="sxs-lookup"><span data-stu-id="9769f-134">string</span></span>| <span data-ttu-id="9769f-135">必須。</span><span class="sxs-lookup"><span data-stu-id="9769f-135">Required.</span></span> <span data-ttu-id="9769f-136"><b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>から取得した値の文字列を指定します。</span><span class="sxs-lookup"><span data-stu-id="9769f-136">String value obtained from the <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>.</span></span>| 
  
<a id="ID4ERC"></a>

 
## <a name="query-string-parameters"></a><span data-ttu-id="9769f-137">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="9769f-137">Query string parameters</span></span>
 
| <span data-ttu-id="9769f-138">パラメーター</span><span class="sxs-lookup"><span data-stu-id="9769f-138">Parameter</span></span>| <span data-ttu-id="9769f-139">型</span><span class="sxs-lookup"><span data-stu-id="9769f-139">Type</span></span>| <span data-ttu-id="9769f-140">説明</span><span class="sxs-lookup"><span data-stu-id="9769f-140">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="9769f-141">目的</span><span class="sxs-lookup"><span data-stu-id="9769f-141">desired</span></span>| <span data-ttu-id="9769f-142">string</span><span class="sxs-lookup"><span data-stu-id="9769f-142">string</span></span>| <span data-ttu-id="9769f-143">必須。</span><span class="sxs-lookup"><span data-stu-id="9769f-143">Required.</span></span> <span data-ttu-id="9769f-144">'."-で区切られた最小セットのほかに返されるフィールドの一覧。</span><span class="sxs-lookup"><span data-stu-id="9769f-144">The '.'-separated list of fields that should be returned in addition to the minimum set.</span></span> <span data-ttu-id="9769f-145">指定したすべてのフィールドは保証されています (データだけが存在しないの特定の項目の) オブジェクトごとに、返されるが、ここで指定されていない最小セットの外部のフィールドは返されません。</span><span class="sxs-lookup"><span data-stu-id="9769f-145">Not all fields specified are guaranteed to be returned for each object (data may simply not exist for certain items), but no fields outside the minimum set that aren't specified here will be returned.</span></span> | 
  
<a id="ID4EMD"></a>

 
## <a name="see-also"></a><span data-ttu-id="9769f-146">関連項目</span><span class="sxs-lookup"><span data-stu-id="9769f-146">See also</span></span>
 
<a id="ID4EOD"></a>

 
##### <a name="parent"></a><span data-ttu-id="9769f-147">Parent</span><span class="sxs-lookup"><span data-stu-id="9769f-147">Parent</span></span> 

[<span data-ttu-id="9769f-148">/media/{marketplaceId}/fields</span><span class="sxs-lookup"><span data-stu-id="9769f-148">/media/{marketplaceId}/fields</span></span>](uri-medialocalefields.md)

  
<a id="ID4EYD"></a>

 
##### <a name="further-information"></a><span data-ttu-id="9769f-149">詳細情報</span><span class="sxs-lookup"><span data-stu-id="9769f-149">Further Information</span></span> 

[<span data-ttu-id="9769f-150">EDS 共通ヘッダー</span><span class="sxs-lookup"><span data-stu-id="9769f-150">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="9769f-151">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="9769f-151">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="9769f-152">EDS クエリの絞り込み条件</span><span class="sxs-lookup"><span data-stu-id="9769f-152">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="9769f-153">マーケットプレース URI</span><span class="sxs-lookup"><span data-stu-id="9769f-153">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

 [<span data-ttu-id="9769f-154">その他の参照情報</span><span class="sxs-lookup"><span data-stu-id="9769f-154">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   