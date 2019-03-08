---
title: GET (/media/{marketplaceId}/fields)
assetID: 1d535344-8522-0fd1-4daa-cd0f0a0f1121
permalink: en-us/docs/xboxlive/rest/uri-medialocalefieldsget.html
description: " GET (/media/{marketplaceId}/fields)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: cc3ae8abfe04b7a0b9728d07b9488f9ed7c27816
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57606677"
---
# <a name="get-mediamarketplaceidfields"></a><span data-ttu-id="f3fb4-104">GET (/media/{marketplaceId}/fields)</span><span class="sxs-lookup"><span data-stu-id="f3fb4-104">GET (/media/{marketplaceId}/fields)</span></span>
<span data-ttu-id="f3fb4-105">フィールドのトークンを取得します。</span><span class="sxs-lookup"><span data-stu-id="f3fb4-105">Gets the fields token.</span></span> <span data-ttu-id="f3fb4-106">これらの Uri のドメインが`eds.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="f3fb4-106">The domain for these URIs is `eds.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="f3fb4-107">注釈</span><span class="sxs-lookup"><span data-stu-id="f3fb4-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="f3fb4-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="f3fb4-108">URI parameters</span></span>](#ID4EGC)
  * [<span data-ttu-id="f3fb4-109">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="f3fb4-109">Query string parameters</span></span>](#ID4ERC)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a><span data-ttu-id="f3fb4-110">注釈</span><span class="sxs-lookup"><span data-stu-id="f3fb4-110">Remarks</span></span>
 
<span data-ttu-id="f3fb4-111">エンターテイメント検出サービス (EDS) Api は、既定では、各項目のフィールドの場合は、非常に小さい最小セットが返されます。</span><span class="sxs-lookup"><span data-stu-id="f3fb4-111">The Entertainment Discovery Services (EDS) APIs, by default, returns a very small minimum set of fields for each item:</span></span>
 
   * <span data-ttu-id="f3fb4-112">メディア項目の種類</span><span class="sxs-lookup"><span data-stu-id="f3fb4-112">Media item type</span></span>
   * <span data-ttu-id="f3fb4-113">メディアのグループ</span><span class="sxs-lookup"><span data-stu-id="f3fb4-113">Media group</span></span>
   * <span data-ttu-id="f3fb4-114">ID</span><span class="sxs-lookup"><span data-stu-id="f3fb4-114">Id</span></span>
   * <span data-ttu-id="f3fb4-115">名前</span><span class="sxs-lookup"><span data-stu-id="f3fb4-115">Name</span></span>
  
<span data-ttu-id="f3fb4-116">詳細情報を表示するには、Api 同意、**フィールド**する追加のデータを返す必要があるかを指定するパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="f3fb4-116">To get more information, the APIs accept a **fields** parameter that specifies which additional pieces of data should be returned.</span></span> <span data-ttu-id="f3fb4-117">多くの使用可能なフィールドがあるため、各 API 呼び出しの場合は full での名前を指定することは大幅に膨張要求。</span><span class="sxs-lookup"><span data-stu-id="f3fb4-117">Because there are many possible fields, specifying their name in full for each API call would greatly bloat the request.</span></span> <span data-ttu-id="f3fb4-118">代わりに、名前は、他の Api に渡すことができるくらい小さな値を生成するこの API に渡すことができます。</span><span class="sxs-lookup"><span data-stu-id="f3fb4-118">Instead, the names can be passed into this API which will generate a much smaller value that can be passed into the other APIs.</span></span>
 
<span data-ttu-id="f3fb4-119">このパラメーターを受け取る任意の API、指定された値は指定されたメディアのすべての項目の種類のすべてのフィールドのスーパー セットである必要があります。</span><span class="sxs-lookup"><span data-stu-id="f3fb4-119">For any API that accepts this parameter, the provided value must be the superset of all fields in all specified media item types.</span></span> <span data-ttu-id="f3fb4-120">場合によっては、別のメディア項目の種類のフィールドのセットを指定することはできません。</span><span class="sxs-lookup"><span data-stu-id="f3fb4-120">It's not possible to specify different sets of fields for different media item types.</span></span> <span data-ttu-id="f3fb4-121">ただし、フィールドが 1 つのメディア項目の種類がない別、それに適用される場合にのみ表示されます、メディア項目の種類のデータが存在します (への呼び出しで"AvatarBodyType"が含まれている場合など、[取得 (/media/{marketplaceId} フィールド/)](uri-medialocalefields.md)のみAvatarItems にはフィールドが含まれて、)。</span><span class="sxs-lookup"><span data-stu-id="f3fb4-121">However, if a field applies to one media item type but not another, it will only appear in the media item types where data exists (for example, if "AvatarBodyType" is included in the call to [GET (/media/{marketplaceId}/fields)](uri-medialocalefields.md), only AvatarItems will contain the field).</span></span>
 
<span data-ttu-id="f3fb4-122">この API から返される値は、実際にキャッシュ可能 -、EDS のデプロイの間を除く、変更する必要がありますされません。</span><span class="sxs-lookup"><span data-stu-id="f3fb4-122">The values returned from this API are highly cacheable -- in fact, they should not change except between deployments of EDS.</span></span> <span data-ttu-id="f3fb4-123">キャッシュが必要な場合、キャッシュいいえよりも長く、ユーザーのセッションをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="f3fb4-123">It's recommended that, if caching is desired, the cache last no longer than the session of the user.</span></span>
 
<span data-ttu-id="f3fb4-124">実際のフィールド名を受け入れるだけでなくこの API は、"all"を有効な値として受け取ります。</span><span class="sxs-lookup"><span data-stu-id="f3fb4-124">In addition to accepting the actual field names, this API accepts "all" as a valid value.</span></span> <span data-ttu-id="f3fb4-125">これにより、指定することは、各フィールドが含まれる値が生成されます。</span><span class="sxs-lookup"><span data-stu-id="f3fb4-125">This will generate a value that contains each field it's possible to specify.</span></span> <span data-ttu-id="f3fb4-126">「すべて」の値の使用は、開発、デバッグ、およびテスト目的でのみ推奨されます。</span><span class="sxs-lookup"><span data-stu-id="f3fb4-126">Use of the "all" value is recommended only for development, debugging, and testing purposes.</span></span>
 
<span data-ttu-id="f3fb4-127">送信する代わりに、`desired={list of fields separated by a '.'}`を受け入れる任意の API に、**フィールド**トークンです。</span><span class="sxs-lookup"><span data-stu-id="f3fb4-127">Alternatively, you can send `desired={list of fields separated by a '.'}` to any API that accepts the **fields** token.</span></span>
 
<span data-ttu-id="f3fb4-128">両方に渡すことはできません**目的**と**フィールド**化します。</span><span class="sxs-lookup"><span data-stu-id="f3fb4-128">You cannot pass in both **desired** and **fields** together.</span></span>
  
<a id="ID4EGC"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="f3fb4-129">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="f3fb4-129">URI parameters</span></span>
 
| <span data-ttu-id="f3fb4-130">パラメーター</span><span class="sxs-lookup"><span data-stu-id="f3fb4-130">Parameter</span></span>| <span data-ttu-id="f3fb4-131">種類</span><span class="sxs-lookup"><span data-stu-id="f3fb4-131">Type</span></span>| <span data-ttu-id="f3fb4-132">説明</span><span class="sxs-lookup"><span data-stu-id="f3fb4-132">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="f3fb4-133">marketplaceId</span><span class="sxs-lookup"><span data-stu-id="f3fb4-133">marketplaceId</span></span>| <span data-ttu-id="f3fb4-134">string</span><span class="sxs-lookup"><span data-stu-id="f3fb4-134">string</span></span>| <span data-ttu-id="f3fb4-135">必須。</span><span class="sxs-lookup"><span data-stu-id="f3fb4-135">Required.</span></span> <span data-ttu-id="f3fb4-136">文字列から取得した値、 <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>します。</span><span class="sxs-lookup"><span data-stu-id="f3fb4-136">String value obtained from the <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>.</span></span>| 
  
<a id="ID4ERC"></a>

 
## <a name="query-string-parameters"></a><span data-ttu-id="f3fb4-137">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="f3fb4-137">Query string parameters</span></span>
 
| <span data-ttu-id="f3fb4-138">パラメーター</span><span class="sxs-lookup"><span data-stu-id="f3fb4-138">Parameter</span></span>| <span data-ttu-id="f3fb4-139">種類</span><span class="sxs-lookup"><span data-stu-id="f3fb4-139">Type</span></span>| <span data-ttu-id="f3fb4-140">説明</span><span class="sxs-lookup"><span data-stu-id="f3fb4-140">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="f3fb4-141">必要な</span><span class="sxs-lookup"><span data-stu-id="f3fb4-141">desired</span></span>| <span data-ttu-id="f3fb4-142">string</span><span class="sxs-lookup"><span data-stu-id="f3fb4-142">string</span></span>| <span data-ttu-id="f3fb4-143">必須。</span><span class="sxs-lookup"><span data-stu-id="f3fb4-143">Required.</span></span> <span data-ttu-id="f3fb4-144">'.'-だけでなく、最小セットが返されるフィールドの区切りのリスト。</span><span class="sxs-lookup"><span data-stu-id="f3fb4-144">The '.'-separated list of fields that should be returned in addition to the minimum set.</span></span> <span data-ttu-id="f3fb4-145">指定されたすべてのフィールド (データが単に存在しない特定の項目) の各オブジェクトに対して返されることが保証されますが、ここで指定されていない最小セットの範囲外のフィールドは返されません。</span><span class="sxs-lookup"><span data-stu-id="f3fb4-145">Not all fields specified are guaranteed to be returned for each object (data may simply not exist for certain items), but no fields outside the minimum set that aren't specified here will be returned.</span></span> | 
  
<a id="ID4EMD"></a>

 
## <a name="see-also"></a><span data-ttu-id="f3fb4-146">関連項目</span><span class="sxs-lookup"><span data-stu-id="f3fb4-146">See also</span></span>
 
<a id="ID4EOD"></a>

 
##### <a name="parent"></a><span data-ttu-id="f3fb4-147">Parent</span><span class="sxs-lookup"><span data-stu-id="f3fb4-147">Parent</span></span> 

[<span data-ttu-id="f3fb4-148">/media/{marketplaceId}/fields</span><span class="sxs-lookup"><span data-stu-id="f3fb4-148">/media/{marketplaceId}/fields</span></span>](uri-medialocalefields.md)

  
<a id="ID4EYD"></a>

 
##### <a name="further-information"></a><span data-ttu-id="f3fb4-149">詳細情報</span><span class="sxs-lookup"><span data-stu-id="f3fb4-149">Further Information</span></span> 

[<span data-ttu-id="f3fb4-150">EDS の一般的なヘッダー</span><span class="sxs-lookup"><span data-stu-id="f3fb4-150">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="f3fb4-151">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="f3fb4-151">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="f3fb4-152">EDS は、絞り込み条件をクエリします。</span><span class="sxs-lookup"><span data-stu-id="f3fb4-152">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="f3fb4-153">Marketplace の Uri</span><span class="sxs-lookup"><span data-stu-id="f3fb4-153">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

 [<span data-ttu-id="f3fb4-154">その他の参照</span><span class="sxs-lookup"><span data-stu-id="f3fb4-154">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   