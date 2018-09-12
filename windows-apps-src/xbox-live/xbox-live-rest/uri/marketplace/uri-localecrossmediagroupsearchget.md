---
title: 取得する (/media/{marketplaceId}/crossMediaGroupSearch)
assetID: 7c509af1-8dce-f419-c4de-2fad54fd1edb
permalink: en-us/docs/xboxlive/rest/uri-localecrossmediagroupsearchget.html
author: KevinAsgari
description: " 取得する (/media/{marketplaceId}/crossMediaGroupSearch)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 430dbce8b3ac2a79709c5f0761124aa7a78cab5e
ms.sourcegitcommit: 2a63ee6770413bc35ace09b14f56b60007be7433
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3928867"
---
# <a name="get-mediamarketplaceidcrossmediagroupsearch"></a><span data-ttu-id="a87a1-104">取得する (/media/{marketplaceId}/crossMediaGroupSearch)</span><span class="sxs-lookup"><span data-stu-id="a87a1-104">GET (/media/{marketplaceId}/crossMediaGroupSearch)</span></span>
<span data-ttu-id="a87a1-105">いくつかの異なるメディア グループから項目を取得します。</span><span class="sxs-lookup"><span data-stu-id="a87a1-105">Gets items from several different media groups.</span></span> <span data-ttu-id="a87a1-106">これらの Uri のドメインが`eds.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="a87a1-106">The domain for these URIs is `eds.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="a87a1-107">注釈</span><span class="sxs-lookup"><span data-stu-id="a87a1-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="a87a1-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="a87a1-108">URI parameters</span></span>](#ID4EEB)
  * [<span data-ttu-id="a87a1-109">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="a87a1-109">Query string parameters</span></span>](#ID4EPB)
  * [<span data-ttu-id="a87a1-110">応答本文</span><span class="sxs-lookup"><span data-stu-id="a87a1-110">Response body</span></span>](#ID4ETC)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a><span data-ttu-id="a87a1-111">注釈</span><span class="sxs-lookup"><span data-stu-id="a87a1-111">Remarks</span></span>
 
<span data-ttu-id="a87a1-112">グループ間の API は、いくつかの異なるメディア グループから項目を検索するクライアントを許可します。</span><span class="sxs-lookup"><span data-stu-id="a87a1-112">The cross-group API allows clients to search for items from several different media groups.</span></span> <span data-ttu-id="a87a1-113">この API では、結果のページングの前方の継続トークンの使用が必要です。</span><span class="sxs-lookup"><span data-stu-id="a87a1-113">This API requires the use of a forward-only continuation token for paging through results.</span></span> <span data-ttu-id="a87a1-114">この API は、絞り込み条件のクエリを受け取ります。</span><span class="sxs-lookup"><span data-stu-id="a87a1-114">This API accepts Query Refiners.</span></span>
 
<span data-ttu-id="a87a1-115">**SandboxId**は今すぐ、XToken で要求から取得され、適用されます。</span><span class="sxs-lookup"><span data-stu-id="a87a1-115">**SandboxId** is now retrieved from the claim in the XToken and enforced.</span></span> <span data-ttu-id="a87a1-116">**SandboxId**が存在しない場合のエンターテインメント探索サービス (EDS) は、400 Bad request エラーをスローします。</span><span class="sxs-lookup"><span data-stu-id="a87a1-116">If the **SandboxId** is not present, then Entertainment Discovery Services (EDS) will throw a 400 Bad request error.</span></span>
  
<a id="ID4EEB"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="a87a1-117">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="a87a1-117">URI parameters</span></span>
 
| <span data-ttu-id="a87a1-118">パラメーター</span><span class="sxs-lookup"><span data-stu-id="a87a1-118">Parameter</span></span>| <span data-ttu-id="a87a1-119">型</span><span class="sxs-lookup"><span data-stu-id="a87a1-119">Type</span></span>| <span data-ttu-id="a87a1-120">説明</span><span class="sxs-lookup"><span data-stu-id="a87a1-120">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="a87a1-121">marketplaceId</span><span class="sxs-lookup"><span data-stu-id="a87a1-121">marketplaceId</span></span>| <span data-ttu-id="a87a1-122">string</span><span class="sxs-lookup"><span data-stu-id="a87a1-122">string</span></span>| <span data-ttu-id="a87a1-123">必須。</span><span class="sxs-lookup"><span data-stu-id="a87a1-123">Required.</span></span> <span data-ttu-id="a87a1-124">文字列<b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>から取得した値です。</span><span class="sxs-lookup"><span data-stu-id="a87a1-124">String value obtained from the <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>.</span></span>| 
  
<a id="ID4EPB"></a>

 
## <a name="query-string-parameters"></a><span data-ttu-id="a87a1-125">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="a87a1-125">Query string parameters</span></span>
 
| <span data-ttu-id="a87a1-126">パラメーター</span><span class="sxs-lookup"><span data-stu-id="a87a1-126">Parameter</span></span>| <span data-ttu-id="a87a1-127">型</span><span class="sxs-lookup"><span data-stu-id="a87a1-127">Type</span></span>| <span data-ttu-id="a87a1-128">説明</span><span class="sxs-lookup"><span data-stu-id="a87a1-128">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="a87a1-129">continuationToken</span><span class="sxs-lookup"><span data-stu-id="a87a1-129">continuationToken</span></span>| <span data-ttu-id="a87a1-130">文字列</span><span class="sxs-lookup"><span data-stu-id="a87a1-130">string</span></span>| <span data-ttu-id="a87a1-131">省略可能。</span><span class="sxs-lookup"><span data-stu-id="a87a1-131">Optional.</span></span> <span data-ttu-id="a87a1-132">ContinuationToken パラメーターを参照してください。</span><span class="sxs-lookup"><span data-stu-id="a87a1-132">See the ContinuationToken parameter.</span></span>| 
| <span data-ttu-id="a87a1-133">q</span><span class="sxs-lookup"><span data-stu-id="a87a1-133">q</span></span>| <span data-ttu-id="a87a1-134">string</span><span class="sxs-lookup"><span data-stu-id="a87a1-134">string</span></span>| <span data-ttu-id="a87a1-135">必須。</span><span class="sxs-lookup"><span data-stu-id="a87a1-135">Required.</span></span> <span data-ttu-id="a87a1-136">検索で使用される用語を照会します。</span><span class="sxs-lookup"><span data-stu-id="a87a1-136">Query term used in search.</span></span>| 
  
<a id="ID4ETC"></a>

 
## <a name="response-body"></a><span data-ttu-id="a87a1-137">応答本文</span><span class="sxs-lookup"><span data-stu-id="a87a1-137">Response body</span></span>
 
<a id="ID4EZC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="a87a1-138">応答の例</span><span class="sxs-lookup"><span data-stu-id="a87a1-138">Sample response</span></span>
 
<span data-ttu-id="a87a1-139">次の JSON コードは、呼び出しへの応答で、`/media/en-us/crossMediaGroupSearch?q=vector&maxItems=25&fields=all`します。</span><span class="sxs-lookup"><span data-stu-id="a87a1-139">The JSON code below is in response to the call `/media/en-us/crossMediaGroupSearch?q=vector&maxItems=25&fields=all`.</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="a87a1-140">関連項目</span><span class="sxs-lookup"><span data-stu-id="a87a1-140">See also</span></span>
 
<a id="ID4EKD"></a>

 
##### <a name="parent"></a><span data-ttu-id="a87a1-141">Parent</span><span class="sxs-lookup"><span data-stu-id="a87a1-141">Parent</span></span> 

[<span data-ttu-id="a87a1-142">/media/{marketplaceId}/crossMediaGroupSearch</span><span class="sxs-lookup"><span data-stu-id="a87a1-142">/media/{marketplaceId}/crossMediaGroupSearch</span></span>](uri-localecrossmediagroupsearch.md)

  
<a id="ID4EUD"></a>

 
##### <a name="further-information"></a><span data-ttu-id="a87a1-143">詳細情報</span><span class="sxs-lookup"><span data-stu-id="a87a1-143">Further Information</span></span> 

[<span data-ttu-id="a87a1-144">EDS 一般的なヘッダー</span><span class="sxs-lookup"><span data-stu-id="a87a1-144">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="a87a1-145">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="a87a1-145">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="a87a1-146">EDS は、絞り込み条件をクエリします。</span><span class="sxs-lookup"><span data-stu-id="a87a1-146">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="a87a1-147">Marketplace Uri</span><span class="sxs-lookup"><span data-stu-id="a87a1-147">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

 [<span data-ttu-id="a87a1-148">その他の参照</span><span class="sxs-lookup"><span data-stu-id="a87a1-148">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   