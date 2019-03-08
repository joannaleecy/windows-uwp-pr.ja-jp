---
title: EDS の補助 API
assetID: 5729ab80-e88d-0190-fb61-bd0cc4f134f6
permalink: en-us/docs/xboxlive/rest/eds-apis.html
description: " EDS の補助 API"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 3f2f729359f52b09879e7227ede71e238fe63801
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57603237"
---
# <a name="auxiliary-eds-apis"></a><span data-ttu-id="9d498-104">EDS の補助 API</span><span class="sxs-lookup"><span data-stu-id="9d498-104">Auxiliary EDS APIs</span></span>

<span data-ttu-id="9d498-105">これにはいくつかエンターテイメント検出サービス (EDS)、コンテンツに関する情報を直接提供はありませんが、ドライブの一般的な UI モデルをしたり、サービスを使用する方法に関する一般的な情報を提供する Api があります。</span><span class="sxs-lookup"><span data-stu-id="9d498-105">There are several Entertainment Discovery Services (EDS) APIs that don't directly provide information about content, but give general information about how to use the service or help drive common UI models.</span></span>

<a id="ID4EQ"></a>


## <a name="auxiliary-apis"></a><span data-ttu-id="9d498-106">補助 Api</span><span class="sxs-lookup"><span data-stu-id="9d498-106">Auxiliary APIs</span></span>

| <span data-ttu-id="9d498-107">API</span><span class="sxs-lookup"><span data-stu-id="9d498-107">API</span></span>| <span data-ttu-id="9d498-108">URI</span><span class="sxs-lookup"><span data-stu-id="9d498-108">URI</span></span>| <span data-ttu-id="9d498-109">説明</span><span class="sxs-lookup"><span data-stu-id="9d498-109">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="9d498-110">API パラメーターの値</span><span class="sxs-lookup"><span data-stu-id="9d498-110">API Parameter Values</span></span>| <span data-ttu-id="9d498-111">/{locale}/metadata</span><span class="sxs-lookup"><span data-stu-id="9d498-111">/{locale}/metadata</span></span>| <span data-ttu-id="9d498-112">サービスの呼び出しで使用できるパラメーターの使用可能な値の列挙体</span><span class="sxs-lookup"><span data-stu-id="9d498-112">Enumeration of possible values of parameters that can be used in calls to the service</span></span>|
| <span data-ttu-id="9d498-113">コンテンツのレーティングのジェネレーターを組み合わせる</span><span class="sxs-lookup"><span data-stu-id="9d498-113">Combined Content Rating Generator</span></span>| <span data-ttu-id="9d498-114">/{locale}/contentRating</span><span class="sxs-lookup"><span data-stu-id="9d498-114">/{locale}/contentRating</span></span>| <span data-ttu-id="9d498-115">好ましくないまたは明示的な可能性があるコンテンツをフィルター処理するため、他の Api で使用できる値を作成します。</span><span class="sxs-lookup"><span data-stu-id="9d498-115">Creates a value that can be used in other APIs for filtering out potentially objectionable or explicit content.</span></span> <span data-ttu-id="9d498-116">詳細については、以下を参照してください。</span><span class="sxs-lookup"><span data-stu-id="9d498-116">See below for more information.</span></span>|
| <span data-ttu-id="9d498-117">結合されたフィールド名ジェネレーター</span><span class="sxs-lookup"><span data-stu-id="9d498-117">Combined Field Name Generator</span></span>| <span data-ttu-id="9d498-118">/{locale}/fields</span><span class="sxs-lookup"><span data-stu-id="9d498-118">/{locale}/fields</span></span>| <span data-ttu-id="9d498-119">どのフィールドが返されるコントロールに Api の詳細に使用できる値を作成します。</span><span class="sxs-lookup"><span data-stu-id="9d498-119">Creates a value that can be used in the detail APIs to control which fields are returned.</span></span> <span data-ttu-id="9d498-120">詳細については、以下を参照してください。</span><span class="sxs-lookup"><span data-stu-id="9d498-120">See below for more information.</span></span>|

<a id="ID4EBC"></a>


### <a name="api-parameter-values"></a><span data-ttu-id="9d498-121">API パラメーターの値</span><span class="sxs-lookup"><span data-stu-id="9d498-121">API Parameter Values</span></span>

<span data-ttu-id="9d498-122">この API では、サービスで使用できるパラメーターについて説明します。</span><span class="sxs-lookup"><span data-stu-id="9d498-122">This API describes parameters that can be used with the service.</span></span> <span data-ttu-id="9d498-123">返される情報は、ローカライズされたテキストには、各パラメーターが付属しているためにクライアント UI で使用可能です。</span><span class="sxs-lookup"><span data-stu-id="9d498-123">The returned information is usable by the client UI because localized text accompanies each parameter.</span></span>

<span data-ttu-id="9d498-124">以下に示した Api のいずれもには、すべてのクエリ パラメーターがそのまま使用します。</span><span class="sxs-lookup"><span data-stu-id="9d498-124">None of the APIs below accept any query parameters.</span></span>

| <span data-ttu-id="9d498-125">API</span><span class="sxs-lookup"><span data-stu-id="9d498-125">API</span></span>| <span data-ttu-id="9d498-126">URI</span><span class="sxs-lookup"><span data-stu-id="9d498-126">URI</span></span>| <span data-ttu-id="9d498-127">説明</span><span class="sxs-lookup"><span data-stu-id="9d498-127">Description</span></span>|
| --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="9d498-128">型</span><span class="sxs-lookup"><span data-stu-id="9d498-128">Types</span></span>| <span data-ttu-id="9d498-129">/{locale}/metadata/mediaGroups</span><span class="sxs-lookup"><span data-stu-id="9d498-129">/{locale}/metadata/mediaGroups</span></span>| <span data-ttu-id="9d498-130">メディアのグループの完全な一覧</span><span class="sxs-lookup"><span data-stu-id="9d498-130">The full list of media groups</span></span>|
| <span data-ttu-id="9d498-131">メディア アイテムの 1 つのメディアのグループの種類</span><span class="sxs-lookup"><span data-stu-id="9d498-131">Media item types per Media group</span></span>| <span data-ttu-id="9d498-132">/{locale}/metadata/mediaGroups/{mediaItemTypeGroup}/mediaItemTypes</span><span class="sxs-lookup"><span data-stu-id="9d498-132">/{locale}/metadata/mediaGroups/{mediaItemTypeGroup}/mediaItemTypes</span></span>| <span data-ttu-id="9d498-133">メディアの一覧は、型指定されたメディアのグループに含まれる項目します。</span><span class="sxs-lookup"><span data-stu-id="9d498-133">The list of media item types contained within the given media group.</span></span>|
| <span data-ttu-id="9d498-134">すべてのメディア アイテムの種類</span><span class="sxs-lookup"><span data-stu-id="9d498-134">All Media item types</span></span>| <span data-ttu-id="9d498-135">/{locale}/metadata/mediaItemTypes</span><span class="sxs-lookup"><span data-stu-id="9d498-135">/{locale}/metadata/mediaItemTypes</span></span>| <span data-ttu-id="9d498-136">メディア項目の種類の完全な一覧</span><span class="sxs-lookup"><span data-stu-id="9d498-136">The full list of media item types</span></span>|
| <span data-ttu-id="9d498-137">メディア項目の種類ごとのフィールド</span><span class="sxs-lookup"><span data-stu-id="9d498-137">Fields per Media item type</span></span>| <span data-ttu-id="9d498-138">/{locale}/metadata/mediaItemTypes/{mediaItemType}/fields</span><span class="sxs-lookup"><span data-stu-id="9d498-138">/{locale}/metadata/mediaItemTypes/{mediaItemType}/fields</span></span>| <span data-ttu-id="9d498-139">1 つのメディア項目の種類のフィールドの一覧</span><span class="sxs-lookup"><span data-stu-id="9d498-139">The list of fields in a single media item type</span></span>|
| <span data-ttu-id="9d498-140">クエリの絞り込み条件</span><span class="sxs-lookup"><span data-stu-id="9d498-140">Query Refiners</span></span>| <span data-ttu-id="9d498-141">/{locale}/metadata/mediaItemTypes/{mediaItemType}/queryRefiners</span><span class="sxs-lookup"><span data-stu-id="9d498-141">/{locale}/metadata/mediaItemTypes/{mediaItemType}/queryRefiners</span></span>| <span data-ttu-id="9d498-142">特定のメディア項目の種類のサポートされているクエリの絞り込み条件の一覧</span><span class="sxs-lookup"><span data-stu-id="9d498-142">The list of query refiners supported for the given media item type</span></span>|
| <span data-ttu-id="9d498-143">すべてのクエリの調整値</span><span class="sxs-lookup"><span data-stu-id="9d498-143">All Query Refiner Values</span></span>| <span data-ttu-id="9d498-144">/{locale}/metadata/mediaItemTypes/{mediaItemType}/queryRefiners/{queryRefiner}</span><span class="sxs-lookup"><span data-stu-id="9d498-144">/{locale}/metadata/mediaItemTypes/{mediaItemType}/queryRefiners/{queryRefiner}</span></span>| <span data-ttu-id="9d498-145">指定されたメディアの指定されたクエリの絞り込み条件の値は、項目の種類</span><span class="sxs-lookup"><span data-stu-id="9d498-145">The values for the specified query refiner for the given media item type</span></span>|
| <span data-ttu-id="9d498-146">すべてのクエリの絞り込み条件のサブ値</span><span class="sxs-lookup"><span data-stu-id="9d498-146">All Query Refiner Sub-Values</span></span>| <span data-ttu-id="9d498-147">/{locale}/metadata/mediaItemTypes/{mediaItemType}/queryRefiners/{queryRefiner}/subQueryRefinerValues</span><span class="sxs-lookup"><span data-stu-id="9d498-147">/{locale}/metadata/mediaItemTypes/{mediaItemType}/queryRefiners/{queryRefiner}/subQueryRefinerValues</span></span>| <span data-ttu-id="9d498-148">指定されたクエリの調整値 ("subgenres には、特定のジャンル"など) のサブの値のリスト。</span><span class="sxs-lookup"><span data-stu-id="9d498-148">The list of sub-values for a given query refiner value (e.g. "subgenres in a given genre").</span></span> <span data-ttu-id="9d498-149">クエリの絞り込み条件値でという名前の"queryRefinerValue"は、クエリに渡される URI のステムで禁止された文字を含むの絞り込み条件値を許可するには、クエリ文字列パラメーターとして渡されます。</span><span class="sxs-lookup"><span data-stu-id="9d498-149">The query refiner value is passed in as a query string parameter named "queryRefinerValue", which is done to allow query refiner values with characters forbidden in URI stems to be passed.</span></span>|
| <span data-ttu-id="9d498-150">並べ替え</span><span class="sxs-lookup"><span data-stu-id="9d498-150">Sorts</span></span>| <span data-ttu-id="9d498-151">/{locale}/metadata/mediaItemTypes/{mediaItemType}/sortOrders</span><span class="sxs-lookup"><span data-stu-id="9d498-151">/{locale}/metadata/mediaItemTypes/{mediaItemType}/sortOrders</span></span>| <span data-ttu-id="9d498-152">特定のメディア項目の種類で並べ替え順の一覧</span><span class="sxs-lookup"><span data-stu-id="9d498-152">The list of sort orders for the given media item type</span></span>|

<a id="ID4EEF"></a>


### <a name="combined-content-rating-generator"></a><span data-ttu-id="9d498-153">コンテンツのレーティングのジェネレーターを組み合わせる</span><span class="sxs-lookup"><span data-stu-id="9d498-153">Combined Content Rating Generator</span></span>

<span data-ttu-id="9d498-154">複雑なタスクは、子が参照を許可するコンテンツに対する保護者による制御を適用します。</span><span class="sxs-lookup"><span data-stu-id="9d498-154">Enforcing parental controls over the content children are allowed to see is a complicated task.</span></span> <span data-ttu-id="9d498-155">だけでなくは各メディア項目の種類が、独自の評価システムが、これらの評価システムは、国を変更できます。</span><span class="sxs-lookup"><span data-stu-id="9d498-155">Not only does each media item type have its own rating system, but those rating systems can vary from country to country.</span></span> <span data-ttu-id="9d498-156">これはすべての項目を適切にフィルターを指定する必要があるデータのいくつかの異なる部分があることを意味します。</span><span class="sxs-lookup"><span data-stu-id="9d498-156">This means that there are several different pieces of data that need to be specified to properly filter all items.</span></span>

<span data-ttu-id="9d498-157">すべてのパラメーターを指定する、すべての API 呼び出しで、代わりには、この API は、他の Api で combinedContentRating パラメーターに渡すし、も同じ情報を通信に値を生成します。</span><span class="sxs-lookup"><span data-stu-id="9d498-157">Instead of specifying all of the parameters in all API calls, this API generates a value to pass into combinedContentRating parameters in other APIs and still communicate the same information.</span></span> <span data-ttu-id="9d498-158">これは、やすく Api を使用して、保守がその他の Api の 1 つの再利用可能な値にこの API に渡されるいくつかのパラメーターが折りたたまれている設計されています。</span><span class="sxs-lookup"><span data-stu-id="9d498-158">This is designed to make the APIs easier to use and maintain, as the several parameters passed into this API are collapsed into a single, reusable value for the other APIs.</span></span>

<span data-ttu-id="9d498-159">頻繁に変更する必要がありますが、この API によって返される正確な値は変更が最終的に、(EDS のリリース間など)、したがって、長期間のキャッシュ可能性があります。</span><span class="sxs-lookup"><span data-stu-id="9d498-159">Although the exact values returned by this API may eventually change, they should change very infrequently (such as between releases of EDS) and thus could be cached for long periods of time.</span></span> <span data-ttu-id="9d498-160">CombinedContentRating パラメーターは、これを示す値には意味のあるエラー メッセージに渡された値が有効でない場合、呼び出し元だけを受け入れる任意の API は、更新された値を取得するには、もう一度この API を呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="9d498-160">Any API accepting a combinedContentRating parameter will give a meaningful error message if the value passed in is invalid, which is an indication the caller merely needs to call this API again to get an updated value.</span></span> <span data-ttu-id="9d498-161">API が受け取る combinedContentRating パラメーターでは、いずれかが指定されない場合、コンテンツのフィルター処理は行われません保護者による制限に基づく</span><span class="sxs-lookup"><span data-stu-id="9d498-161">If an API accepts a combinedContentRating parameter, but one isn't provided, no filtering of content will take place based on parental controls</span></span>

> [!NOTE]
> <span data-ttu-id="9d498-162">唯一の「安全な」コンテンツが返されるか--すべてのコンテンツが返されるか、明示的な可能性のあるコンテンツを含むことを意味からといって)。</span><span class="sxs-lookup"><span data-stu-id="9d498-162">This doesn't mean that only "safe" content is returned--it means that all content is returned, including potentially explicit content).</span></span>



<a id="ID4EWF"></a>


### <a name="combined-field-name"></a><span data-ttu-id="9d498-163">結合されたフィールド名</span><span class="sxs-lookup"><span data-stu-id="9d498-163">Combined Field Name</span></span>

<span data-ttu-id="9d498-164">EDS Api では、既定では、各項目のフィールドの場合は、非常に小さい最小セットを返します。</span><span class="sxs-lookup"><span data-stu-id="9d498-164">The EDS APIs, by default, return a very small minimum set of fields for each item:</span></span>

   * <span data-ttu-id="9d498-165">メディア項目の種類</span><span class="sxs-lookup"><span data-stu-id="9d498-165">Media item type</span></span>
   * <span data-ttu-id="9d498-166">メディアのグループ</span><span class="sxs-lookup"><span data-stu-id="9d498-166">Media group</span></span>
   * <span data-ttu-id="9d498-167">ID</span><span class="sxs-lookup"><span data-stu-id="9d498-167">Id</span></span>
   * <span data-ttu-id="9d498-168">名前</span><span class="sxs-lookup"><span data-stu-id="9d498-168">Name</span></span>

<span data-ttu-id="9d498-169">詳細を取得するには、Api は、する追加のデータを返す必要があるかを示す"fields"パラメーターを受け取ります。</span><span class="sxs-lookup"><span data-stu-id="9d498-169">To get more information, the APIs accept a "fields" parameter that specifies which additional pieces of data should be returned.</span></span> <span data-ttu-id="9d498-170">多くの使用可能なフィールドがあるため、各 API 呼び出しの場合は full での名前を指定することは大幅に膨張要求。</span><span class="sxs-lookup"><span data-stu-id="9d498-170">Because there are many possible fields, specifying their name in full for each API call would greatly bloat the request.</span></span> <span data-ttu-id="9d498-171">代わりに、名前は、他の Api に渡すことができるくらい小さな値を生成するこの API に渡すことができます。</span><span class="sxs-lookup"><span data-stu-id="9d498-171">Instead, the names can be passed into this API which will generate a much smaller value that can be passed into the other APIs.</span></span>

<span data-ttu-id="9d498-172">このパラメーターを受け取る任意の API、指定された値は指定されたメディアのすべての項目の種類のすべてのフィールドのスーパー セットである必要があります。</span><span class="sxs-lookup"><span data-stu-id="9d498-172">For any API that accepts this parameter, the provided value must be the superset of all fields in all specified media item types.</span></span> <span data-ttu-id="9d498-173">場合によっては、別のメディア項目の種類のフィールドのセットを指定することはできません。</span><span class="sxs-lookup"><span data-stu-id="9d498-173">It's not possible to specify different sets of fields for different media item types.</span></span> <span data-ttu-id="9d498-174">ただし、フィールドが 1 つのメディア項目の種類がない別、それに適用される場合にのみ表示されます、メディア項目の種類のデータが存在します (例:"AvatarBodyType"は、フィールド名の組み合わせ API の呼び出しに含まれますが、AvatarItems のみ、フィールドが含まれます)。</span><span class="sxs-lookup"><span data-stu-id="9d498-174">However, if a field applies to one media item type but not another, it will only appear in the media item types where data exists (e.g. if "AvatarBodyType" is included in the call to the Combined Field Name API, only AvatarItems will contain the field).</span></span>

<span data-ttu-id="9d498-175">この API から返される値は、実際にキャッシュ可能-、EDS のデプロイの間を除く、変更する必要がありますされません。</span><span class="sxs-lookup"><span data-stu-id="9d498-175">The values returned from this API are highly cacheable--in fact, they should not change except between deployments of EDS.</span></span> <span data-ttu-id="9d498-176">キャッシュが必要な場合、キャッシュいいえよりも長く、ユーザーのセッションをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="9d498-176">It's recommended that, if caching is desired, the cache last no longer than the session of the user.</span></span>

<span data-ttu-id="9d498-177">実際のフィールド名を受け入れるだけでなくこの API は、"all"を有効な値として受け取ります。</span><span class="sxs-lookup"><span data-stu-id="9d498-177">In addition to accepting the actual field names, this API accepts "all" as a valid value.</span></span> <span data-ttu-id="9d498-178">これにより、指定することは、各フィールドが含まれる値が生成されます。</span><span class="sxs-lookup"><span data-stu-id="9d498-178">This will generate a value that contains each field it's possible to specify.</span></span> <span data-ttu-id="9d498-179">「すべて」の値は、開発、デバッグ、およびテスト目的でのみ使用される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="9d498-179">The "all" value is likely to only be used for development, debugging, and testing purposes.</span></span>

<a id="ID4ERG"></a>


## <a name="see-also"></a><span data-ttu-id="9d498-180">関連項目</span><span class="sxs-lookup"><span data-stu-id="9d498-180">See also</span></span>

<a id="ID4ETG"></a>


##### <a name="parent"></a><span data-ttu-id="9d498-181">Parent</span><span class="sxs-lookup"><span data-stu-id="9d498-181">Parent</span></span>  

[<span data-ttu-id="9d498-182">その他の参照</span><span class="sxs-lookup"><span data-stu-id="9d498-182">Additional Reference</span></span>](atoc-xboxlivews-reference-additional.md)


<a id="ID4E6G"></a>


##### <a name="further-information"></a><span data-ttu-id="9d498-183">詳細情報</span><span class="sxs-lookup"><span data-stu-id="9d498-183">Further Information</span></span>

[<span data-ttu-id="9d498-184">Marketplace の Uri</span><span class="sxs-lookup"><span data-stu-id="9d498-184">Marketplace URIs</span></span>](../uri/marketplace/atoc-reference-marketplace.md)
