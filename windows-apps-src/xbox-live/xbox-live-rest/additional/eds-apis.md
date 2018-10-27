---
title: EDS の補助 API
assetID: 5729ab80-e88d-0190-fb61-bd0cc4f134f6
permalink: en-us/docs/xboxlive/rest/eds-apis.html
author: KevinAsgari
description: " EDS の補助 API"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 791ec5e593d90cf52b91cca863df02da2db97f5f
ms.sourcegitcommit: 086001cffaf436e6e4324761d59bcc5e598c15ea
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/27/2018
ms.locfileid: "5691851"
---
# <a name="auxiliary-eds-apis"></a><span data-ttu-id="2a7ff-104">EDS の補助 API</span><span class="sxs-lookup"><span data-stu-id="2a7ff-104">Auxiliary EDS APIs</span></span>

<span data-ttu-id="2a7ff-105">これにはいくつかのエンターテインメント探索サービス (EDS) については、コンテンツを直接指定しないが、サービスを使用して、またはドライブの一般的な UI モデルを支援する方法に関する一般的な情報を提供する Api があります。</span><span class="sxs-lookup"><span data-stu-id="2a7ff-105">There are several Entertainment Discovery Services (EDS) APIs that don't directly provide information about content, but give general information about how to use the service or help drive common UI models.</span></span>

<a id="ID4EQ"></a>


## <a name="auxiliary-apis"></a><span data-ttu-id="2a7ff-106">補助 Api</span><span class="sxs-lookup"><span data-stu-id="2a7ff-106">Auxiliary APIs</span></span>

| <span data-ttu-id="2a7ff-107">API</span><span class="sxs-lookup"><span data-stu-id="2a7ff-107">API</span></span>| <span data-ttu-id="2a7ff-108">URI</span><span class="sxs-lookup"><span data-stu-id="2a7ff-108">URI</span></span>| <span data-ttu-id="2a7ff-109">説明</span><span class="sxs-lookup"><span data-stu-id="2a7ff-109">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="2a7ff-110">API のパラメーター値</span><span class="sxs-lookup"><span data-stu-id="2a7ff-110">API Parameter Values</span></span>| <span data-ttu-id="2a7ff-111">/{ロケール}/メタデータ</span><span class="sxs-lookup"><span data-stu-id="2a7ff-111">/{locale}/metadata</span></span>| <span data-ttu-id="2a7ff-112">サービスへの呼び出しで使用できるパラメーターの値の列挙</span><span class="sxs-lookup"><span data-stu-id="2a7ff-112">Enumeration of possible values of parameters that can be used in calls to the service</span></span>|
| <span data-ttu-id="2a7ff-113">コンテンツの規制ジェネレーターを組み合わせる</span><span class="sxs-lookup"><span data-stu-id="2a7ff-113">Combined Content Rating Generator</span></span>| <span data-ttu-id="2a7ff-114">/{ロケール}/contentRating</span><span class="sxs-lookup"><span data-stu-id="2a7ff-114">/{locale}/contentRating</span></span>| <span data-ttu-id="2a7ff-115">可能性のある好ましくないまたは明示的なコンテンツをフィルター処理するための他の Api で使用できる値を作成します。</span><span class="sxs-lookup"><span data-stu-id="2a7ff-115">Creates a value that can be used in other APIs for filtering out potentially objectionable or explicit content.</span></span> <span data-ttu-id="2a7ff-116">詳細については以下をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="2a7ff-116">See below for more information.</span></span>|
| <span data-ttu-id="2a7ff-117">結合されたフィールド名ジェネレーター</span><span class="sxs-lookup"><span data-stu-id="2a7ff-117">Combined Field Name Generator</span></span>| <span data-ttu-id="2a7ff-118">/{ロケール}/fields</span><span class="sxs-lookup"><span data-stu-id="2a7ff-118">/{locale}/fields</span></span>| <span data-ttu-id="2a7ff-119">フィールドが返されるコントロールに詳細 Api で使用できる値を作成します。</span><span class="sxs-lookup"><span data-stu-id="2a7ff-119">Creates a value that can be used in the detail APIs to control which fields are returned.</span></span> <span data-ttu-id="2a7ff-120">詳細については以下をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="2a7ff-120">See below for more information.</span></span>|

<a id="ID4EBC"></a>


### <a name="api-parameter-values"></a><span data-ttu-id="2a7ff-121">API のパラメーター値</span><span class="sxs-lookup"><span data-stu-id="2a7ff-121">API Parameter Values</span></span>

<span data-ttu-id="2a7ff-122">この API では、サービスで使用できるパラメーターについて説明します。</span><span class="sxs-lookup"><span data-stu-id="2a7ff-122">This API describes parameters that can be used with the service.</span></span> <span data-ttu-id="2a7ff-123">返された情報は、ローカライズされたテキストには、各パラメーターが付属してためにクライアントが UI で使用可能です。</span><span class="sxs-lookup"><span data-stu-id="2a7ff-123">The returned information is usable by the client UI because localized text accompanies each parameter.</span></span>

<span data-ttu-id="2a7ff-124">None の下の Api は、クエリ パラメーターを受け入れます。</span><span class="sxs-lookup"><span data-stu-id="2a7ff-124">None of the APIs below accept any query parameters.</span></span>

| <span data-ttu-id="2a7ff-125">API</span><span class="sxs-lookup"><span data-stu-id="2a7ff-125">API</span></span>| <span data-ttu-id="2a7ff-126">URI</span><span class="sxs-lookup"><span data-stu-id="2a7ff-126">URI</span></span>| <span data-ttu-id="2a7ff-127">説明</span><span class="sxs-lookup"><span data-stu-id="2a7ff-127">Description</span></span>|
| --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="2a7ff-128">型</span><span class="sxs-lookup"><span data-stu-id="2a7ff-128">Types</span></span>| <span data-ttu-id="2a7ff-129">/{ロケール} メタデータ/mediaGroups</span><span class="sxs-lookup"><span data-stu-id="2a7ff-129">/{locale}/metadata/mediaGroups</span></span>| <span data-ttu-id="2a7ff-130">メディアのグループの完全な一覧</span><span class="sxs-lookup"><span data-stu-id="2a7ff-130">The full list of media groups</span></span>|
| <span data-ttu-id="2a7ff-131">メディア項目のメディアのグループごとの種類</span><span class="sxs-lookup"><span data-stu-id="2a7ff-131">Media item types per Media group</span></span>| <span data-ttu-id="2a7ff-132">/{ロケール}//metadata/mediagroups/{mediaItemTypeGroup}/mediaItemTypes</span><span class="sxs-lookup"><span data-stu-id="2a7ff-132">/{locale}/metadata/mediaGroups/{mediaItemTypeGroup}/mediaItemTypes</span></span>| <span data-ttu-id="2a7ff-133">メディアのリスト項目の種類のメディアの特定のグループに含まれます。</span><span class="sxs-lookup"><span data-stu-id="2a7ff-133">The list of media item types contained within the given media group.</span></span>|
| <span data-ttu-id="2a7ff-134">すべてのメディア項目の種類</span><span class="sxs-lookup"><span data-stu-id="2a7ff-134">All Media item types</span></span>| <span data-ttu-id="2a7ff-135">/{ロケール} メタデータ/mediaItemTypes</span><span class="sxs-lookup"><span data-stu-id="2a7ff-135">/{locale}/metadata/mediaItemTypes</span></span>| <span data-ttu-id="2a7ff-136">メディア項目の種類の完全な一覧</span><span class="sxs-lookup"><span data-stu-id="2a7ff-136">The full list of media item types</span></span>|
| <span data-ttu-id="2a7ff-137">メディア項目の種類ごとのフィールド</span><span class="sxs-lookup"><span data-stu-id="2a7ff-137">Fields per Media item type</span></span>| <span data-ttu-id="2a7ff-138">/{ロケール}//metadata/mediaitemtypes/{mediaItemType}/fields</span><span class="sxs-lookup"><span data-stu-id="2a7ff-138">/{locale}/metadata/mediaItemTypes/{mediaItemType}/fields</span></span>| <span data-ttu-id="2a7ff-139">1 つのメディア項目の種類のフィールドの一覧</span><span class="sxs-lookup"><span data-stu-id="2a7ff-139">The list of fields in a single media item type</span></span>|
| <span data-ttu-id="2a7ff-140">クエリの絞り込み条件</span><span class="sxs-lookup"><span data-stu-id="2a7ff-140">Query Refiners</span></span>| <span data-ttu-id="2a7ff-141">/{ロケール}//metadata/mediaitemtypes/{mediaItemType}/queryRefiners</span><span class="sxs-lookup"><span data-stu-id="2a7ff-141">/{locale}/metadata/mediaItemTypes/{mediaItemType}/queryRefiners</span></span>| <span data-ttu-id="2a7ff-142">指定したメディア項目の種類のサポートされているクエリの絞り込み条件の一覧</span><span class="sxs-lookup"><span data-stu-id="2a7ff-142">The list of query refiners supported for the given media item type</span></span>|
| <span data-ttu-id="2a7ff-143">すべてのクエリ絞り込み条件値</span><span class="sxs-lookup"><span data-stu-id="2a7ff-143">All Query Refiner Values</span></span>| <span data-ttu-id="2a7ff-144">/{ロケール}/メタデータ/metadata/mediaitemtypes/{mediaItemType}/queryrefiners/{queryRefiner}</span><span class="sxs-lookup"><span data-stu-id="2a7ff-144">/{locale}/metadata/mediaItemTypes/{mediaItemType}/queryRefiners/{queryRefiner}</span></span>| <span data-ttu-id="2a7ff-145">項目の種類を指定したメディアの指定されたクエリの絞り込み条件の値</span><span class="sxs-lookup"><span data-stu-id="2a7ff-145">The values for the specified query refiner for the given media item type</span></span>|
| <span data-ttu-id="2a7ff-146">絞り込み条件のサブ値を照会すべて</span><span class="sxs-lookup"><span data-stu-id="2a7ff-146">All Query Refiner Sub-Values</span></span>| <span data-ttu-id="2a7ff-147">/{ロケール}/メタデータ/metadata/mediaitemtypes/{mediaItemType}/queryrefiners/{queryRefiner}/subQueryRefinerValues</span><span class="sxs-lookup"><span data-stu-id="2a7ff-147">/{locale}/metadata/mediaItemTypes/{mediaItemType}/queryRefiners/{queryRefiner}/subQueryRefinerValues</span></span>| <span data-ttu-id="2a7ff-148">指定されたクエリの絞り込み条件値 ("subgenres には、指定されたジャンル"など) のサブ値の一覧。</span><span class="sxs-lookup"><span data-stu-id="2a7ff-148">The list of sub-values for a given query refiner value (e.g. "subgenres in a given genre").</span></span> <span data-ttu-id="2a7ff-149">クエリの絞り込み条件値でという名前の"queryRefinerValue"は、値を許可するクエリ絞り込み条件を渡すことが URI 語幹で禁止されている文字では、クエリ文字列パラメーターとして渡されます。</span><span class="sxs-lookup"><span data-stu-id="2a7ff-149">The query refiner value is passed in as a query string parameter named "queryRefinerValue", which is done to allow query refiner values with characters forbidden in URI stems to be passed.</span></span>|
| <span data-ttu-id="2a7ff-150">順に並べ替えます。</span><span class="sxs-lookup"><span data-stu-id="2a7ff-150">Sorts</span></span>| <span data-ttu-id="2a7ff-151">/{ロケール}//metadata/mediaitemtypes/{mediaItemType}/sortOrders</span><span class="sxs-lookup"><span data-stu-id="2a7ff-151">/{locale}/metadata/mediaItemTypes/{mediaItemType}/sortOrders</span></span>| <span data-ttu-id="2a7ff-152">指定したメディア項目の種類の並べ替え順序の一覧</span><span class="sxs-lookup"><span data-stu-id="2a7ff-152">The list of sort orders for the given media item type</span></span>|

<a id="ID4EEF"></a>


### <a name="combined-content-rating-generator"></a><span data-ttu-id="2a7ff-153">コンテンツの規制ジェネレーターを組み合わせる</span><span class="sxs-lookup"><span data-stu-id="2a7ff-153">Combined Content Rating Generator</span></span>

<span data-ttu-id="2a7ff-154">複雑なタスクがキッズ子が表示できるコンテンツを適用することです。</span><span class="sxs-lookup"><span data-stu-id="2a7ff-154">Enforcing parental controls over the content children are allowed to see is a complicated task.</span></span> <span data-ttu-id="2a7ff-155">だけでなく各メディア項目の種類は、独自の評価システムがそれらの評価システムは国によって異なることができます。</span><span class="sxs-lookup"><span data-stu-id="2a7ff-155">Not only does each media item type have its own rating system, but those rating systems can vary from country to country.</span></span> <span data-ttu-id="2a7ff-156">これはすべての項目を正しくフィルターを指定する必要があるデータの複数の異なる部分があることを意味します。</span><span class="sxs-lookup"><span data-stu-id="2a7ff-156">This means that there are several different pieces of data that need to be specified to properly filter all items.</span></span>

<span data-ttu-id="2a7ff-157">すべてのパラメーターを指定する、すべての API 呼び出しで、代わりは、この API は、その他の Api で combinedContentRating パラメーターに渡すし、同じ情報をまだ通信する値を生成します。</span><span class="sxs-lookup"><span data-stu-id="2a7ff-157">Instead of specifying all of the parameters in all API calls, this API generates a value to pass into combinedContentRating parameters in other APIs and still communicate the same information.</span></span> <span data-ttu-id="2a7ff-158">これは、この API に渡されるいくつかのパラメーターは、その他の Api の 1 つ、再利用可能な値に折りたたまれたとき、Api を使用し、保守、やすくするために設計されています。</span><span class="sxs-lookup"><span data-stu-id="2a7ff-158">This is designed to make the APIs easier to use and maintain, as the several parameters passed into this API are collapsed into a single, reusable value for the other APIs.</span></span>

<span data-ttu-id="2a7ff-159">頻繁に変更する必要がありますが、この API によって返される正確な値は変更が最終的に、(リリース EDS の間など)、そのため、長期間のキャッシュ可能性があります。</span><span class="sxs-lookup"><span data-stu-id="2a7ff-159">Although the exact values returned by this API may eventually change, they should change very infrequently (such as between releases of EDS) and thus could be cached for long periods of time.</span></span> <span data-ttu-id="2a7ff-160">CombinedContentRating パラメーターは、これを示すはわかりやすいエラー メッセージで渡した値が有効である場合、呼び出し元だけを受け入れ、いずれかの API は、更新された値を取得するには、もう一度この API を呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="2a7ff-160">Any API accepting a combinedContentRating parameter will give a meaningful error message if the value passed in is invalid, which is an indication the caller merely needs to call this API again to get an updated value.</span></span> <span data-ttu-id="2a7ff-161">指定されていなければ、API が combinedContentRating パラメーターを受け取る場合、コンテンツのフィルター処理は行われません保護者による制限に基づく</span><span class="sxs-lookup"><span data-stu-id="2a7ff-161">If an API accepts a combinedContentRating parameter, but one isn't provided, no filtering of content will take place based on parental controls</span></span>

> [!NOTE]
> <span data-ttu-id="2a7ff-162">これとは限りません。 のみ"安全"コンテンツが返されること - すべてのコンテンツが返されること、明示的な可能性のあるコンテンツを含むことを意味)。</span><span class="sxs-lookup"><span data-stu-id="2a7ff-162">This doesn't mean that only "safe" content is returned--it means that all content is returned, including potentially explicit content).</span></span>



<a id="ID4EWF"></a>


### <a name="combined-field-name"></a><span data-ttu-id="2a7ff-163">結合されたフィールド名</span><span class="sxs-lookup"><span data-stu-id="2a7ff-163">Combined Field Name</span></span>

<span data-ttu-id="2a7ff-164">EDS Api では、既定では、各項目のフィールドの場合は、非常に小さい最小セットを返します。</span><span class="sxs-lookup"><span data-stu-id="2a7ff-164">The EDS APIs, by default, return a very small minimum set of fields for each item:</span></span>

   * <span data-ttu-id="2a7ff-165">メディア項目の種類</span><span class="sxs-lookup"><span data-stu-id="2a7ff-165">Media item type</span></span>
   * <span data-ttu-id="2a7ff-166">メディア グループ</span><span class="sxs-lookup"><span data-stu-id="2a7ff-166">Media group</span></span>
   * <span data-ttu-id="2a7ff-167">ID</span><span class="sxs-lookup"><span data-stu-id="2a7ff-167">Id</span></span>
   * <span data-ttu-id="2a7ff-168">名前</span><span class="sxs-lookup"><span data-stu-id="2a7ff-168">Name</span></span>

<span data-ttu-id="2a7ff-169">詳細を取得するのには、Api は、する追加のデータの一部を返すように指定する「フィールド」パラメーターを受け入れます。</span><span class="sxs-lookup"><span data-stu-id="2a7ff-169">To get more information, the APIs accept a "fields" parameter that specifies which additional pieces of data should be returned.</span></span> <span data-ttu-id="2a7ff-170">多くの使用可能なフィールドがあるため、API 呼び出しごとに完全にその名前を指定することが大幅に膨張要求します。</span><span class="sxs-lookup"><span data-stu-id="2a7ff-170">Because there are many possible fields, specifying their name in full for each API call would greatly bloat the request.</span></span> <span data-ttu-id="2a7ff-171">代わりに、名前は、その他の Api に渡すことができるより小さい値を生成するこの API に渡すことができます。</span><span class="sxs-lookup"><span data-stu-id="2a7ff-171">Instead, the names can be passed into this API which will generate a much smaller value that can be passed into the other APIs.</span></span>

<span data-ttu-id="2a7ff-172">このパラメーターを受け取るいずれかの API、指定された値がすべて指定したメディア項目の種類のすべてのフィールドのスーパー セットである必要があります。</span><span class="sxs-lookup"><span data-stu-id="2a7ff-172">For any API that accepts this parameter, the provided value must be the superset of all fields in all specified media item types.</span></span> <span data-ttu-id="2a7ff-173">別のメディア項目の種類のフィールドの異なるセットを指定することはできません。</span><span class="sxs-lookup"><span data-stu-id="2a7ff-173">It's not possible to specify different sets of fields for different media item types.</span></span> <span data-ttu-id="2a7ff-174">ただし、フィールドは、1 つのメディア項目の種類がない別、それに適用する場合にのみ表示、メディア項目の種類のデータが存在する (例: AvatarItems のみ"AvatarBodyType"は、組み合わせることによりフィールド名 API への呼び出しに含まれている場合、は、フィールドが含まれて)。</span><span class="sxs-lookup"><span data-stu-id="2a7ff-174">However, if a field applies to one media item type but not another, it will only appear in the media item types where data exists (e.g. if "AvatarBodyType" is included in the call to the Combined Field Name API, only AvatarItems will contain the field).</span></span>

<span data-ttu-id="2a7ff-175">この API から返される値は、実際に強くキャッシュ--、それらは変更されませんを除く EDS の展開の間でします。</span><span class="sxs-lookup"><span data-stu-id="2a7ff-175">The values returned from this API are highly cacheable--in fact, they should not change except between deployments of EDS.</span></span> <span data-ttu-id="2a7ff-176">キャッシュが必要な場合、キャッシュ最後のユーザーのセッションしなくなったことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="2a7ff-176">It's recommended that, if caching is desired, the cache last no longer than the session of the user.</span></span>

<span data-ttu-id="2a7ff-177">実際のフィールド名を受け入れ、だけでなくこの API は、"all"を有効な値として受け取ります。</span><span class="sxs-lookup"><span data-stu-id="2a7ff-177">In addition to accepting the actual field names, this API accepts "all" as a valid value.</span></span> <span data-ttu-id="2a7ff-178">これにより、指定することは、各フィールドが含まれている値が生成されます。</span><span class="sxs-lookup"><span data-stu-id="2a7ff-178">This will generate a value that contains each field it's possible to specify.</span></span> <span data-ttu-id="2a7ff-179">"All"の値は、開発、デバッグ、テスト目的にのみ使用する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="2a7ff-179">The "all" value is likely to only be used for development, debugging, and testing purposes.</span></span>

<a id="ID4ERG"></a>


## <a name="see-also"></a><span data-ttu-id="2a7ff-180">関連項目</span><span class="sxs-lookup"><span data-stu-id="2a7ff-180">See also</span></span>

<a id="ID4ETG"></a>


##### <a name="parent"></a><span data-ttu-id="2a7ff-181">Parent</span><span class="sxs-lookup"><span data-stu-id="2a7ff-181">Parent</span></span>  

[<span data-ttu-id="2a7ff-182">その他の参照情報</span><span class="sxs-lookup"><span data-stu-id="2a7ff-182">Additional Reference</span></span>](atoc-xboxlivews-reference-additional.md)


<a id="ID4E6G"></a>


##### <a name="further-information"></a><span data-ttu-id="2a7ff-183">詳細情報</span><span class="sxs-lookup"><span data-stu-id="2a7ff-183">Further Information</span></span>

[<span data-ttu-id="2a7ff-184">マーケットプレース URI</span><span class="sxs-lookup"><span data-stu-id="2a7ff-184">Marketplace URIs</span></span>](../uri/marketplace/atoc-reference-marketplace.md)
