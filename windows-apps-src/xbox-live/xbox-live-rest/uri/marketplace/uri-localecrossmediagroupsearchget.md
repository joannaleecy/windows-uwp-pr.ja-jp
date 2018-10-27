---
title: GET (/media/{marketplaceId}/crossMediaGroupSearch)
assetID: 7c509af1-8dce-f419-c4de-2fad54fd1edb
permalink: en-us/docs/xboxlive/rest/uri-localecrossmediagroupsearchget.html
author: KevinAsgari
description: " GET (/media/{marketplaceId}/crossMediaGroupSearch)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 16baf465eb534e40854fcda1df7abb8c10ff2fbe
ms.sourcegitcommit: 086001cffaf436e6e4324761d59bcc5e598c15ea
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/27/2018
ms.locfileid: "5705156"
---
# <a name="get-mediamarketplaceidcrossmediagroupsearch"></a><span data-ttu-id="ce0c4-104">GET (/media/{marketplaceId}/crossMediaGroupSearch)</span><span class="sxs-lookup"><span data-stu-id="ce0c4-104">GET (/media/{marketplaceId}/crossMediaGroupSearch)</span></span>
<span data-ttu-id="ce0c4-105">いくつかの異なるメディア グループから項目を取得します。</span><span class="sxs-lookup"><span data-stu-id="ce0c4-105">Gets items from several different media groups.</span></span> <span data-ttu-id="ce0c4-106">これらの Uri のドメインが`eds.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="ce0c4-106">The domain for these URIs is `eds.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="ce0c4-107">注釈</span><span class="sxs-lookup"><span data-stu-id="ce0c4-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="ce0c4-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="ce0c4-108">URI parameters</span></span>](#ID4EEB)
  * [<span data-ttu-id="ce0c4-109">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="ce0c4-109">Query string parameters</span></span>](#ID4EPB)
  * [<span data-ttu-id="ce0c4-110">応答本文</span><span class="sxs-lookup"><span data-stu-id="ce0c4-110">Response body</span></span>](#ID4ETC)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a><span data-ttu-id="ce0c4-111">注釈</span><span class="sxs-lookup"><span data-stu-id="ce0c4-111">Remarks</span></span>
 
<span data-ttu-id="ce0c4-112">グループ間の API は、いくつかの異なるメディア グループから項目を検索するクライアントを許可します。</span><span class="sxs-lookup"><span data-stu-id="ce0c4-112">The cross-group API allows clients to search for items from several different media groups.</span></span> <span data-ttu-id="ce0c4-113">この API では、結果のページングの前方の継続トークンの使用が必要です。</span><span class="sxs-lookup"><span data-stu-id="ce0c4-113">This API requires the use of a forward-only continuation token for paging through results.</span></span> <span data-ttu-id="ce0c4-114">この API は、クエリの絞り込み条件を受け取ります。</span><span class="sxs-lookup"><span data-stu-id="ce0c4-114">This API accepts Query Refiners.</span></span>
 
<span data-ttu-id="ce0c4-115">**SandboxId**はできるようになりました、XToken で要求から取得し、適用します。</span><span class="sxs-lookup"><span data-stu-id="ce0c4-115">**SandboxId** is now retrieved from the claim in the XToken and enforced.</span></span> <span data-ttu-id="ce0c4-116">**SandboxId**が存在しない場合のエンターテインメント探索サービス (EDS) は、400 Bad request エラーをスローします。</span><span class="sxs-lookup"><span data-stu-id="ce0c4-116">If the **SandboxId** is not present, then Entertainment Discovery Services (EDS) will throw a 400 Bad request error.</span></span>
  
<a id="ID4EEB"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="ce0c4-117">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="ce0c4-117">URI parameters</span></span>
 
| <span data-ttu-id="ce0c4-118">パラメーター</span><span class="sxs-lookup"><span data-stu-id="ce0c4-118">Parameter</span></span>| <span data-ttu-id="ce0c4-119">型</span><span class="sxs-lookup"><span data-stu-id="ce0c4-119">Type</span></span>| <span data-ttu-id="ce0c4-120">説明</span><span class="sxs-lookup"><span data-stu-id="ce0c4-120">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="ce0c4-121">marketplaceId</span><span class="sxs-lookup"><span data-stu-id="ce0c4-121">marketplaceId</span></span>| <span data-ttu-id="ce0c4-122">string</span><span class="sxs-lookup"><span data-stu-id="ce0c4-122">string</span></span>| <span data-ttu-id="ce0c4-123">必須。</span><span class="sxs-lookup"><span data-stu-id="ce0c4-123">Required.</span></span> <span data-ttu-id="ce0c4-124">文字列<b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>から取得した値です。</span><span class="sxs-lookup"><span data-stu-id="ce0c4-124">String value obtained from the <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>.</span></span>| 
  
<a id="ID4EPB"></a>

 
## <a name="query-string-parameters"></a><span data-ttu-id="ce0c4-125">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="ce0c4-125">Query string parameters</span></span>
 
| <span data-ttu-id="ce0c4-126">パラメーター</span><span class="sxs-lookup"><span data-stu-id="ce0c4-126">Parameter</span></span>| <span data-ttu-id="ce0c4-127">型</span><span class="sxs-lookup"><span data-stu-id="ce0c4-127">Type</span></span>| <span data-ttu-id="ce0c4-128">説明</span><span class="sxs-lookup"><span data-stu-id="ce0c4-128">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="ce0c4-129">continuationToken</span><span class="sxs-lookup"><span data-stu-id="ce0c4-129">continuationToken</span></span>| <span data-ttu-id="ce0c4-130">文字列</span><span class="sxs-lookup"><span data-stu-id="ce0c4-130">string</span></span>| <span data-ttu-id="ce0c4-131">省略可能。</span><span class="sxs-lookup"><span data-stu-id="ce0c4-131">Optional.</span></span> <span data-ttu-id="ce0c4-132">ContinuationToken パラメーターを参照してください。</span><span class="sxs-lookup"><span data-stu-id="ce0c4-132">See the ContinuationToken parameter.</span></span>| 
| <span data-ttu-id="ce0c4-133">q</span><span class="sxs-lookup"><span data-stu-id="ce0c4-133">q</span></span>| <span data-ttu-id="ce0c4-134">string</span><span class="sxs-lookup"><span data-stu-id="ce0c4-134">string</span></span>| <span data-ttu-id="ce0c4-135">必須。</span><span class="sxs-lookup"><span data-stu-id="ce0c4-135">Required.</span></span> <span data-ttu-id="ce0c4-136">検索で使用される用語を照会します。</span><span class="sxs-lookup"><span data-stu-id="ce0c4-136">Query term used in search.</span></span>| 
  
<a id="ID4ETC"></a>

 
## <a name="response-body"></a><span data-ttu-id="ce0c4-137">応答本文</span><span class="sxs-lookup"><span data-stu-id="ce0c4-137">Response body</span></span>
 
<a id="ID4EZC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="ce0c4-138">応答の例</span><span class="sxs-lookup"><span data-stu-id="ce0c4-138">Sample response</span></span>
 
<span data-ttu-id="ce0c4-139">次の JSON コードは、呼び出しへの応答で、`/media/en-us/crossMediaGroupSearch?q=vector&maxItems=25&fields=all`します。</span><span class="sxs-lookup"><span data-stu-id="ce0c4-139">The JSON code below is in response to the call `/media/en-us/crossMediaGroupSearch?q=vector&maxItems=25&fields=all`.</span></span>
 

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
        "KValue": "30",
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
    },
    {
        "MediaGroup": "MusicArtistType",
        "MediaItemType": "MusicArtist",
        "ID": "61cdf888-7b2b-5111-82f4-87e9c7a86504",
        "Name": "Vector",
        "Genres": [{
            "Name": "Hip Hop"
        }],
        "SortName": "Vector [2]",
        "KValue": "28",
        "KValueNamespace": "bingbox",
        "AmgId": "P   362877",
        "ZuneId": "89C90600-0200-11DB-89CA-0019B92A3933",
        "SubGenres": [{
            "Name": "Contemporary Hip Hop"
        }],
        "AllTimePlayCount": 995.0,
        "SevenDaysPlayCount": 2.0,
        "ThirtyDaysPlayCount": 57.0,
        "LegacyAmgId": "7D890500-0600-11DB-89CA-0019B92A3933",
        "LegacyIds": [{
            "IdType": "AmgId",
            "Value": "P   362877"
        },
        {
            "IdType": "ZuneId",
            "Value": "89C90600-0200-11DB-89CA-0019B92A3933"
        },
        {
            "IdType": "LegacyAmgId",
            "Value": "7D890500-0600-11DB-89CA-0019B92A3933"
        },
        {
            "IdType": "ArtistId",
            "Value": "444809"
        }]
    }],
    "ContinuationToken": "1-----1",
    "ImpressionGuid": "9e41e6e4-1b2e-4710-abe4-b01ffbaa7605"
}
         
```

   
<a id="ID4EID"></a>

 
## <a name="see-also"></a><span data-ttu-id="ce0c4-140">関連項目</span><span class="sxs-lookup"><span data-stu-id="ce0c4-140">See also</span></span>
 
<a id="ID4EKD"></a>

 
##### <a name="parent"></a><span data-ttu-id="ce0c4-141">Parent</span><span class="sxs-lookup"><span data-stu-id="ce0c4-141">Parent</span></span> 

[<span data-ttu-id="ce0c4-142">/media/{marketplaceId}/crossMediaGroupSearch</span><span class="sxs-lookup"><span data-stu-id="ce0c4-142">/media/{marketplaceId}/crossMediaGroupSearch</span></span>](uri-localecrossmediagroupsearch.md)

  
<a id="ID4EUD"></a>

 
##### <a name="further-information"></a><span data-ttu-id="ce0c4-143">詳細情報</span><span class="sxs-lookup"><span data-stu-id="ce0c4-143">Further Information</span></span> 

[<span data-ttu-id="ce0c4-144">EDS 共通ヘッダー</span><span class="sxs-lookup"><span data-stu-id="ce0c4-144">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="ce0c4-145">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="ce0c4-145">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="ce0c4-146">EDS クエリの絞り込み条件</span><span class="sxs-lookup"><span data-stu-id="ce0c4-146">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="ce0c4-147">マーケットプレース URI</span><span class="sxs-lookup"><span data-stu-id="ce0c4-147">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

 [<span data-ttu-id="ce0c4-148">その他の参照情報</span><span class="sxs-lookup"><span data-stu-id="ce0c4-148">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   