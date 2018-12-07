---
title: GET (media/{marketplaceId}/singleMediaGroupSearch)
assetID: 52096f6d-e670-dc07-b191-039ea80c6291
permalink: en-us/docs/xboxlive/rest/uri-medialocalesinglemediagroupsearchget.html
description: " GET (media/{marketplaceId}/singleMediaGroupSearch)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: e9295459c3eb715f1120d4287e69c596654d65fa
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/06/2018
ms.locfileid: "8742472"
---
# <a name="get-mediamarketplaceidsinglemediagroupsearch"></a><span data-ttu-id="81837-104">GET (media/{marketplaceId}/singleMediaGroupSearch)</span><span class="sxs-lookup"><span data-stu-id="81837-104">GET (media/{marketplaceId}/singleMediaGroupSearch)</span></span>
<span data-ttu-id="81837-105">1 つのメディア グループ内の項目を検索をできます。</span><span class="sxs-lookup"><span data-stu-id="81837-105">Allows search for items within a single media group.</span></span> <span data-ttu-id="81837-106">これらの Uri のドメインが`eds.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="81837-106">The domain for these URIs is `eds.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="81837-107">注釈</span><span class="sxs-lookup"><span data-stu-id="81837-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="81837-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="81837-108">URI parameters</span></span>](#ID4EEB)
  * [<span data-ttu-id="81837-109">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="81837-109">Query string parameters</span></span>](#ID4EPB)
  * [<span data-ttu-id="81837-110">応答本文</span><span class="sxs-lookup"><span data-stu-id="81837-110">Response body</span></span>](#ID4E5B)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a><span data-ttu-id="81837-111">注釈</span><span class="sxs-lookup"><span data-stu-id="81837-111">Remarks</span></span>
 
<span data-ttu-id="81837-112">非連続的に継続トークンを使用するのではなく skipItems パラメーターを使用してこの検索から返されるデータのページにアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="81837-112">Pages of data returned from this search can be accessed non-sequentially using the skipItems parameter instead of using the continuation token.</span></span> <span data-ttu-id="81837-113">この API は、クエリの絞り込み条件を受け取ります。</span><span class="sxs-lookup"><span data-stu-id="81837-113">This API accepts Query Refiners.</span></span> 
 
<span data-ttu-id="81837-114">**SandboxId**はここで、XToken で要求から取得され、適用されます。</span><span class="sxs-lookup"><span data-stu-id="81837-114">**SandboxId** is now retrieved from the claim in the XToken and enforced.</span></span> <span data-ttu-id="81837-115">**SandboxId**が存在しない場合は、エンターテインメント探索サービス (EDS) は、400 Bad request エラーをスローします。</span><span class="sxs-lookup"><span data-stu-id="81837-115">If the **SandboxId** is not present, then Entertainment Discovery Services (EDS) will throw a 400 Bad request error.</span></span>
  
<a id="ID4EEB"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="81837-116">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="81837-116">URI parameters</span></span>
 
| <span data-ttu-id="81837-117">パラメーター</span><span class="sxs-lookup"><span data-stu-id="81837-117">Parameter</span></span>| <span data-ttu-id="81837-118">型</span><span class="sxs-lookup"><span data-stu-id="81837-118">Type</span></span>| <span data-ttu-id="81837-119">説明</span><span class="sxs-lookup"><span data-stu-id="81837-119">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="81837-120">marketplaceId</span><span class="sxs-lookup"><span data-stu-id="81837-120">marketplaceId</span></span>| <span data-ttu-id="81837-121">string</span><span class="sxs-lookup"><span data-stu-id="81837-121">string</span></span>| <span data-ttu-id="81837-122">必須。</span><span class="sxs-lookup"><span data-stu-id="81837-122">Required.</span></span> <span data-ttu-id="81837-123"><b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>から取得した値の文字列を指定します。</span><span class="sxs-lookup"><span data-stu-id="81837-123">String value obtained from the <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>.</span></span>| 
  
<a id="ID4EPB"></a>

 
## <a name="query-string-parameters"></a><span data-ttu-id="81837-124">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="81837-124">Query string parameters</span></span>
 
<span data-ttu-id="81837-125">この API は、次のクエリ パラメーターを受け取る: combinedContentRating、desiredMediaItemTypes、フィールド、maxItems、preferredProvider、q、queryRefiners、skipItems、firstPartyOnly、freeOnly、hasTrailer、latestOnly、subscriptionLevel、および topRatedOnly.</span><span class="sxs-lookup"><span data-stu-id="81837-125">This API accepts the following query parameters: combinedContentRating, desiredMediaItemTypes, fields, maxItems, preferredProvider, q, queryRefiners, skipItems, firstPartyOnly, freeOnly, hasTrailer, latestOnly, subscriptionLevel, and topRatedOnly.</span></span>
 
<span data-ttu-id="81837-126">これらのパラメーターについて詳しくは、 [EDS パラメーター](../../additional/edsparameters.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="81837-126">See [EDS Parameters](../../additional/edsparameters.md) for more information on these parameters.</span></span>
  
<a id="ID4E5B"></a>

 
## <a name="response-body"></a><span data-ttu-id="81837-127">応答本文</span><span class="sxs-lookup"><span data-stu-id="81837-127">Response body</span></span>
 
<a id="ID4EEC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="81837-128">応答の例</span><span class="sxs-lookup"><span data-stu-id="81837-128">Sample response</span></span>
 
<span data-ttu-id="81837-129">次の JSON コードは、呼び出しへの応答で`/media/en-us/singleMediaGroupSearch?q=vector&desiredMediaItemTypes=DGame&fields=all`します。</span><span class="sxs-lookup"><span data-stu-id="81837-129">The JSON code below is in response to the call `/media/en-us/singleMediaGroupSearch?q=vector&desiredMediaItemTypes=DGame&fields=all`.</span></span>
 

```cpp
{
    "Items": [{
        "MediaGroup": "GameType",
        "MediaItemType": "DGame",
        "ID": "fd16e2fb-eca4-4182-8f69-a98fdd6e57a1",
        "Name": "Vector based massively multiplayer Tanks game.",
        "ReducedName": "Tanks",
        "ReleaseDate": "2013-03-15T00: 00: 00Z",
        "TitleId": "69A60C76",
        "VuiDisplayName": "Tanks",
        "DeveloperName": "Microsoft Studios",
        "Images": [{
            "ID": "32ebd9fe-6a22-4111-954e-564ec69d802a",
            "ResizeUrl": "http: //images-eds.dnet.xboxlive.com/image?url=RIJNAEIo6.u.tudW9rXJ2lWDOsMikqfNiHE2Sp4qbgNbH6_drY8Ek2cyHXEnnUKPUXAH_m8a3Oe4_wpV7CkKA0Snc9puIYOGxsIfyyncTBv.MIluDZX6UqAPsJYHE5go_J_BBfxNWW6yrK4.K75aMQ--",
            "Purposes": ["Box_Art"],
            "Purpose": "Box_Art",
            "Height": 300,
            "Width": 219,
            "Order": 1
        },
        {
            "ID": "32ebd9fe-6a22-4111-954e-564ec69d802a",
            "ResizeUrl": "http: //images-eds.dnet.xboxlive.com/image?url=RIJNAEIo6.u.tudW9rXJ2lWDOsMikqfNiHE2Sp4qbgNbH6_drY8Ek2cyHXEnnUKPUXAH_m8a3Oe4_wpV7CkKA0Snc9puIYOGxsIfyyncTBv.MIluDZX6UqAPsJYHE5go_J_BBfxNWW6yrK4.K75aMQ--",
            "Purposes": ["Box_Art"],
            "Purpose": "Box_Art",
            "Height": 120,
            "Width": 85,
            "Order": 1
        },
        {
            "ID": "32ebd9fe-6a22-4111-954e-564ec69d802a",
            "ResizeUrl": "http: //images-eds.dnet.xboxlive.com/image?url=RIJNAEIo6.u.tudW9rXJ2lWDOsMikqfNiHE2Sp4qbgNbH6_drY8Ek2cyHXEnnUKPUXAH_m8a3Oe4_wpV7CkKA0Snc9puIYOGxsIfyyncTBv.MIluDZX6UqAPsJYHE5go_J_BBfxNWW6yrK4.K75aMQ--",
            "Purposes": ["Image"],
            "Purpose": "Image",
            "Height": 720,
            "Width": 1280,
            "Order": 1
        }],
        "PublisherName": "Microsoft Studios",
        "RatingId": "10",
        "ParentalRating": "E",
        "ParentalRatingSystem": "ESRB",
        "SortName": "\n            Vector based massively multiplayer Tanks game.\n          ",
        "Capabilities": [{
            "NonLocalizedName": "onlineMultiplayerMin",
            "Value": "3"
        },
        {
            "NonLocalizedName": "onelineMultiplayerMax",
            "Value": "5"
        }],
        "KValue": "4",
        "KValueNamespace": "bingbox",
        "AllTimePlayCount": 30.0,
        "SevenDaysPlayCount": 30.0,
        "ThirtyDaysPlayCount": 30.0,
        "AllTimeRatingCount": 12.0,
        "ThirtyDaysRatingCount": 12.0,
        "SevenDaysRatingCount": 12.0,
        "AllTimeAverageRating": 0.8,
        "ThirtyDaysAverageRating": 0.8,
        "SevenDaysAverageRating": 0.8,
        "LegacyIds": [{
            "IdType": "TitleId",
            "Value": "69A60C76"
        }],
        "Availabilities": [{
            "AvailabilityID": "",
            "ContentId": "7AE9DAB2-1162-488D-9F80-B804EC5AF879",
            "Devices": [{
                "Name": "Durango"
            }]
        }],
        "Packages": [{
            "CdnFileLocation": [{
                "SortOrder": null,
                "Uri": "https: //update.dnet.xboxlive.com/test_cdn/tanks-randomkey.xvc"
            },
            {
                "SortOrder": null,
                "Uri": "https: //update.dnet.xboxlive.com/test_cdn/tanks-randomkey.xvc"
            },
            {
                "SortOrder": null,
                "Uri": "https: //update.dnet.xboxlive.com/test_cdn/tanks-randomkey.xvc"
            }],
            "ContentId": "7AE9DAB2-1162-488D-9F80-B804EC5AF879",
            "PackageType": "XVC",
            "LicenseType": "Xbox Live Games Machine and User"
        }],
        "SandboxId": "PART.Dev1"
    }],
    "ImpressionGuid": "840bae05-776e-4429-b522-e64543ac3a35"
}
         
```

   
<a id="ID4ETC"></a>

 
## <a name="see-also"></a><span data-ttu-id="81837-130">関連項目</span><span class="sxs-lookup"><span data-stu-id="81837-130">See also</span></span>
 
<a id="ID4EVC"></a>

 
##### <a name="parent"></a><span data-ttu-id="81837-131">Parent</span><span class="sxs-lookup"><span data-stu-id="81837-131">Parent</span></span> 

[<span data-ttu-id="81837-132">/media/{marketplaceId}/singleMediaGroupSearch</span><span class="sxs-lookup"><span data-stu-id="81837-132">/media/{marketplaceId}/singleMediaGroupSearch</span></span>](uri-medialocalesinglemediagroupsearch.md)

  
<a id="ID4E6C"></a>

 
##### <a name="further-information"></a><span data-ttu-id="81837-133">詳細情報</span><span class="sxs-lookup"><span data-stu-id="81837-133">Further Information</span></span> 

[<span data-ttu-id="81837-134">EDS 共通ヘッダー</span><span class="sxs-lookup"><span data-stu-id="81837-134">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="81837-135">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="81837-135">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="81837-136">EDS クエリの絞り込み条件</span><span class="sxs-lookup"><span data-stu-id="81837-136">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="81837-137">マーケットプレース URI</span><span class="sxs-lookup"><span data-stu-id="81837-137">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

 [<span data-ttu-id="81837-138">その他の参照情報</span><span class="sxs-lookup"><span data-stu-id="81837-138">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   