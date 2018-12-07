---
title: GET (/media/{marketplaceId}/details)
assetID: 7c222fc7-d70a-84ac-5aaf-f22d186f7a43
permalink: en-us/docs/xboxlive/rest/uri-medialocaledetailsget.html
description: " GET (/media/{marketplaceId}/details)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 5c5be8f144f9c39076ba880223af08a30404c759
ms.sourcegitcommit: a3dc929858415b933943bba5aa7487ffa721899f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/07/2018
ms.locfileid: "8797319"
---
# <a name="get-mediamarketplaceiddetails"></a><span data-ttu-id="61317-104">GET (/media/{marketplaceId}/details)</span><span class="sxs-lookup"><span data-stu-id="61317-104">GET (/media/{marketplaceId}/details)</span></span>
<span data-ttu-id="61317-105">返します提供の詳細とメタデータについての 1 つまたは複数の項目です。</span><span class="sxs-lookup"><span data-stu-id="61317-105">Returns offer details and metadata about one or more items.</span></span>
<span data-ttu-id="61317-106">これらの Uri のドメインが`eds.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="61317-106">The domain for these URIs is `eds.xboxlive.com`.</span></span>

  * [<span data-ttu-id="61317-107">注釈</span><span class="sxs-lookup"><span data-stu-id="61317-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="61317-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="61317-108">URI parameters</span></span>](#ID4ECB)
  * [<span data-ttu-id="61317-109">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="61317-109">Query string parameters</span></span>](#ID4ERB)
  * [<span data-ttu-id="61317-110">応答本文</span><span class="sxs-lookup"><span data-stu-id="61317-110">Response body</span></span>](#ID4EYF)

<a id="ID4EV"></a>


## <a name="remarks"></a><span data-ttu-id="61317-111">注釈</span><span class="sxs-lookup"><span data-stu-id="61317-111">Remarks</span></span>

<span data-ttu-id="61317-112">**SandboxId**はここで、XToken で要求から取得され、適用されます。</span><span class="sxs-lookup"><span data-stu-id="61317-112">**SandboxId** is now retrieved from the claim in the XToken and enforced.</span></span> <span data-ttu-id="61317-113">**SandboxId**が存在しない場合は、エンターテインメント探索サービス (EDS) は、400 Bad request エラーをスローします。</span><span class="sxs-lookup"><span data-stu-id="61317-113">If the **SandboxId** is not present, then Entertainment Discovery Services (EDS) will throw a 400 Bad request error.</span></span>

<a id="ID4ECB"></a>


## <a name="uri-parameters"></a><span data-ttu-id="61317-114">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="61317-114">URI parameters</span></span>

| <span data-ttu-id="61317-115">パラメーター</span><span class="sxs-lookup"><span data-stu-id="61317-115">Parameter</span></span>| <span data-ttu-id="61317-116">型</span><span class="sxs-lookup"><span data-stu-id="61317-116">Type</span></span>| <span data-ttu-id="61317-117">説明</span><span class="sxs-lookup"><span data-stu-id="61317-117">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="61317-118">marketplaceId</span><span class="sxs-lookup"><span data-stu-id="61317-118">marketplaceId</span></span>| <span data-ttu-id="61317-119">string</span><span class="sxs-lookup"><span data-stu-id="61317-119">string</span></span>| <span data-ttu-id="61317-120">必須。</span><span class="sxs-lookup"><span data-stu-id="61317-120">Required.</span></span> <span data-ttu-id="61317-121"><b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>から取得した値の文字列を指定します。</span><span class="sxs-lookup"><span data-stu-id="61317-121">String value obtained from the <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>.</span></span>|

<a id="ID4ERB"></a>


## <a name="query-string-parameters"></a><span data-ttu-id="61317-122">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="61317-122">Query string parameters</span></span>

| <span data-ttu-id="61317-123">パラメーター</span><span class="sxs-lookup"><span data-stu-id="61317-123">Parameter</span></span>| <span data-ttu-id="61317-124">型</span><span class="sxs-lookup"><span data-stu-id="61317-124">Type</span></span>| <span data-ttu-id="61317-125">説明</span><span class="sxs-lookup"><span data-stu-id="61317-125">Description</span></span>|
| --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="61317-126">id</span><span class="sxs-lookup"><span data-stu-id="61317-126">ids</span></span>| <span data-ttu-id="61317-127">string[]</span><span class="sxs-lookup"><span data-stu-id="61317-127">string[]</span></span>| <span data-ttu-id="61317-128">必須。</span><span class="sxs-lookup"><span data-stu-id="61317-128">Required.</span></span> <span data-ttu-id="61317-129">すべての詳細が返されます (最大 10) の Id。</span><span class="sxs-lookup"><span data-stu-id="61317-129">All of the IDs (up to 10) for which details will be returned.</span></span> <span data-ttu-id="61317-130">注、いずれかの ID を URL に配置する不正な文字が含まれています (Id は通常、ProviderContentId 型は、完全な Url 自体と、無効な文字を含めるため) <b>URL エンコード エンターテイメント探索サービス (EDS) に正常に送信する必要があります</b>。</span><span class="sxs-lookup"><span data-stu-id="61317-130">Note that any ID that contains characters illegal to put in a URL (the ProviderContentId type IDs are normally full URLs themselves and thus contain illegal characters) <b>MUST</b> be URL-encoded to be properly sent to Entertainment Discovery Services (EDS).</span></span> <span data-ttu-id="61317-131">こののみできる 1 つの値 ID の種類が ProviderContentId である場合にも注意してください。</span><span class="sxs-lookup"><span data-stu-id="61317-131">Also note that this can only be a single value if the ID type is ProviderContentId.</span></span> <span data-ttu-id="61317-132">1 つ以上の ProviderContentId を使用する場合は、複数の呼び出しを eds でなければなりません。</span><span class="sxs-lookup"><span data-stu-id="61317-132">If more than one ProviderContentId is desired, multiple calls must be made to EDS.</span></span>|
| <span data-ttu-id="61317-133">IdType</span><span class="sxs-lookup"><span data-stu-id="61317-133">IdType</span></span>| <span data-ttu-id="61317-134">string</span><span class="sxs-lookup"><span data-stu-id="61317-134">string</span></span>| <span data-ttu-id="61317-135">省略可能。</span><span class="sxs-lookup"><span data-stu-id="61317-135">Optional.</span></span> <span data-ttu-id="61317-136">'Id' のパラメーターに渡された Id の種類です。</span><span class="sxs-lookup"><span data-stu-id="61317-136">The type of the IDs which are passed in to the 'ids' parameter.</span></span> <span data-ttu-id="61317-137">有効な値は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="61317-137">Valid values are:</span></span> <ul><li><span data-ttu-id="61317-138"><b>正規</b>(Bing/Marketplace)</span><span class="sxs-lookup"><span data-stu-id="61317-138"><b>Canonical</b> (Bing/Marketplace)</span></span> </li><li><b><span data-ttu-id="61317-139">ZuneCatalog</span><span class="sxs-lookup"><span data-stu-id="61317-139">ZuneCatalog</span></span></b></li><li><span data-ttu-id="61317-140"><b>ZuneMediaInstance</b>(たとえば、1 ~ 32 kb WMA 音楽ファイル)</span><span class="sxs-lookup"><span data-stu-id="61317-140"><b>ZuneMediaInstance</b> (eg 132 kb WMA music file)</span></span> </li><li><b><span data-ttu-id="61317-141">AMG</span><span class="sxs-lookup"><span data-stu-id="61317-141">AMG</span></span></b></li><li><span data-ttu-id="61317-142"><b>MediaNet</b>(事前 MusiWave)</span><span class="sxs-lookup"><span data-stu-id="61317-142"><b>MediaNet</b> (pre-MusiWave)</span></span> </li><li><span data-ttu-id="61317-143"><b>XboxHexTitle</b>(アプリ、本体でプレイ)</span><span class="sxs-lookup"><span data-stu-id="61317-143"><b>XboxHexTitle</b> (App playing on the console)</span></span> </li></ul>|
| <span data-ttu-id="61317-144">DesiredMediaItemTypes</span><span class="sxs-lookup"><span data-stu-id="61317-144">DesiredMediaItemTypes</span></span>| <span data-ttu-id="61317-145">string</span><span class="sxs-lookup"><span data-stu-id="61317-145">string</span></span>| <b><span data-ttu-id="61317-146">MediaGroup が渡されないかどうかが必要です。</span><span class="sxs-lookup"><span data-stu-id="61317-146">Required if MediaGroup is not passed.</span></span> <span data-ttu-id="61317-147">両方は渡されませんする必要があります。</span><span class="sxs-lookup"><span data-stu-id="61317-147">Both should not be passed.</span></span></b> <span data-ttu-id="61317-148">メディア項目の Id の種類。</span><span class="sxs-lookup"><span data-stu-id="61317-148">The media item typs of the IDs.</span></span> <span data-ttu-id="61317-149">すべて指定 Id は、同じ型を共有する必要があります。</span><span class="sxs-lookup"><span data-stu-id="61317-149">All provided IDs must share the same type.</span></span> <span data-ttu-id="61317-150">複数の種類が必要な場合は、IdType 上記で説明したよう使用可能なすべての型に渡します。</span><span class="sxs-lookup"><span data-stu-id="61317-150">If multiple types are desired, pass in all possible types as described in the IdType above.</span></span> <span data-ttu-id="61317-151">この値は、既定では"Unknown"が存在しない場合ができない可能性があるすべての ID の種類の valied します。</span><span class="sxs-lookup"><span data-stu-id="61317-151">This value defaults to "Unknown" if it is not present, which may not be valied for all ID types.</span></span> |
| <span data-ttu-id="61317-152">MediaGroup</span><span class="sxs-lookup"><span data-stu-id="61317-152">MediaGroup</span></span>| <span data-ttu-id="61317-153">string</span><span class="sxs-lookup"><span data-stu-id="61317-153">string</span></span>| <b><span data-ttu-id="61317-154">DesiredMediaItemTypes が渡されないかどうかが必要です。</span><span class="sxs-lookup"><span data-stu-id="61317-154">Required if DesiredMediaItemTypes is not passed.</span></span> <span data-ttu-id="61317-155">両方は渡されませんする必要があります。</span><span class="sxs-lookup"><span data-stu-id="61317-155">Both should not be passed.</span></span></b>|
| <span data-ttu-id="61317-156">ConditionSets</span><span class="sxs-lookup"><span data-stu-id="61317-156">ConditionSets</span></span>| <span data-ttu-id="61317-157">string</span><span class="sxs-lookup"><span data-stu-id="61317-157">string</span></span>| <span data-ttu-id="61317-158"><b>省略可能です</b>。</span><span class="sxs-lookup"><span data-stu-id="61317-158"><b>Optional</b>.</span></span> <span data-ttu-id="61317-159">クライアントは、条件セットは、このクエリ文字列を使用して指定キー/値ペアに基づく<b>可用性</b>の排除を要求できます。</span><span class="sxs-lookup"><span data-stu-id="61317-159">Clients may request <b>Availability</b> pruning based on condition sets, which are key-value pairs specified through this query string.</span></span> <span data-ttu-id="61317-160">これらは、使用可能状況の条件セットに一致するように使用されます。</span><span class="sxs-lookup"><span data-stu-id="61317-160">They are used to match on the condition sets of an availability.</span></span> <span data-ttu-id="61317-161">条件セットと一致するために使用できるキーの一覧は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="61317-161">The list of keys that can be used to match the condition sets is as follows.</span></span> <ul><li><span data-ttu-id="61317-162"><b>プラットフォーム</b>: 製品が、構築され、再生されることができます。</span><span class="sxs-lookup"><span data-stu-id="61317-162"><b>Platforms</b>: Where the product is built and can be played.</span></span></li><li><span data-ttu-id="61317-163"><b>サブスクリプション</b>: (Gold または Silver) は、この可用性のサポートされているサブスクリプションの一覧。</span><span class="sxs-lookup"><span data-stu-id="61317-163"><b>Subscriptions</b>: List of supported subscriptions for this availability (Gold or Silver).</span></span></li><li><span data-ttu-id="61317-164"><b>EntitlementIds</b>: ユーザーがゲームを購入後に追跡します。</span><span class="sxs-lookup"><span data-stu-id="61317-164"><b>EntitlementIds</b>: Tracked after users buy the game.</span></span></li></ul> | 

<a id="ID4EYF"></a>


## <a name="response-body"></a><span data-ttu-id="61317-165">応答本文</span><span class="sxs-lookup"><span data-stu-id="61317-165">Response body</span></span>

<a id="ID4E5F"></a>


### <a name="sample-response"></a><span data-ttu-id="61317-166">応答の例</span><span class="sxs-lookup"><span data-stu-id="61317-166">Sample response</span></span>

<span data-ttu-id="61317-167">次の JSON コードは、呼び出しへの応答で`/media/en-us/details?ids=6c5402e4-3cd5-4b29-a9c4-bec7d2c7514a&mediaGroup=GameType`します。</span><span class="sxs-lookup"><span data-stu-id="61317-167">The JSON code below is in response to the call `/media/en-us/details?ids=6c5402e4-3cd5-4b29-a9c4-bec7d2c7514a&mediaGroup=GameType`.</span></span>


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
            }],
            "LicensePolicyTicket": "eyJhbGciOiJIUzI1NiIsImtpZCI6IlYxIn0.eyJhbGxvd1BlcnNpc3RlbnRSb290IjpmYWxzZSwiYmxvY2tlZENvdW50cmllcyI6bnVsbCwiZW50aXRsZWRDb3VudHJpZXMiOm51bGwsImVzY3Jvd2VkQ29udGVudEtleSI6IlJVdENNY3NCQUFBQkFBSUFBQUFGQUFJQUlBQUFBREpsWlRKaVpERTFORGhsT1RZMk5EZGhOVEEyWW1ZeVkyVmpZek5sTVRGa0F3QUNBQUFBQmdBRUFBRUFBQUF4QlFBQ0FBQUFBUUFIQUlBQkFBQzJxb0Vsbm83eWNaZ05iY2R0dFB0TXBlZW95VEVjVUorSmF1WlhmSU9xRFRiV09ud2x1anZEZzU1YzFJby94Q1llTzYxd0VkYTdyZmQ3bVZWMFdTVmNXQUZ2OHplK2toMG1VZVcyUkU3MDd6S05GYzllanVLWlhoY0dkQ1RBYmdVYzJQUVlFNkZOZDJtaWEzdDgyaXlPam9UeGcxWkNaaUR1LzFZaUJ1ZzE1R3BvWVZZREpIbkt5K3NuaEZMdEFKcEI0cER3VXhkVTcvZlV6Y0dvdEtyUW12VDJRQVk5d1NxM0d4WWJ3a1RnVnRrUHVzNTdsN1FVSmp6clBiYkpzeWk5UjhaKzN5RE1EM1JoN0NmekhtVGx3NnBaclFMbnhTTHM0bldPQS92eGo5WS9aN25EM2NJRWlScUhMUU9LSE9GOXVqL0pOOUxtT1FqVkNaaHpLekhRMk5sVURBWmFzYkZ4ZnZjOVh1bDZqZVNCamJsR2xCMlRpZUlTemdPSDh3V0lRWmFGZTMwcVd0a2d4dC9MOEhwTmRwWkwzbG1mcU0vcmswMEtFWUtLaGI4K0E1TGMzeEd2clg3TW9GcmdTUGFONE4xMUNSRVdFZkFGOGc5WWdROEt4R3B0SzdKc0ZpR0NDUmVOeXVYYTQ0NU9NMFNCSFFHVXVMTjl1R0RVTVNNPSIsImV4cGlyYXRpb24iOiIyMDEzLTA4LTEyVDIyOjE3OjI4Ljg2MTYzNzhaIiwibWlpZCI6IjAwMDAwMDAwLTAwMDAtMDAwMC0wMDAwLTAwMDAwMDAwMDAwMCIsIm9paWQiOiIwMDAwMDAwMC0wMDAwLTAwMDAtMDAwMC0wMDAwMDAwMDAwMDAiLCJwb2xpY3lDYXJkSWRzIjpbImdhbWVzOjhmY2UwMjkyLTgyZDUtNDFhNi1hN2IzLTM5NzNkOGM5MWZiNyJdLCJwcm9kdWN0SWQiOiIzMmViZDlmZS02YTIyLTQxMTEtOTU0ZS01NjRlYzY5ZDgwMmEiLCJzZSI6WyJHYW1lOzMyZWJkOWZlLTZhMjItNDExMS05NTRlLTU2NGVjNjlkODAyYSJdLCJ2ZXJzaW9uIjoiMiJ9.T0vaH03VDHr913_PRYVBaOXb3XcHX7AwfXNG2rxcVI8",
            "OfferDisplayData": "{
                \"acceptablePaymentInstrumentTypes\": [\"CreditCard\"],
                \"availabilityDescription\": \"AvailabilityDescription for bc545b24-a8e5-422d-bcca-ed1ed5c1dfbc\",
                \"currencyCode\": \"USD\",
                \"displayPrice\": \"$0.00\",
                \"displayListPrice\": \"$0.00\",
                \"distributionType\": \"Full\",
                \"isPurchasable\": true,
                \"listPrice\": 0.0,
                \"price\": 0.0
            }",
            "SignedOffer": "eyJhbGciOiJSUzI1NiIsImtpZCI6IjIzMUZBNzkzQTRENUY3ODc4NUFGQ0FEMEExNTEwRUMwOEJDQURDNTMifQ.eyIkdHlwZSI6Ik9mZmVycy5Db250cmFjdHMuVjMuT2ZmZXIiLCJhY2NlcHRhYmxlUGF5bWVudEluc3RydW1lbnRUeXBlcyI6WyJDcmVkaXRDYXJkIl0sImF2YWlsYWJpbGl0eURlc2NyaXB0aW9uIjoiQXZhaWxhYmlsaXR5RGVzY3JpcHRpb24gZm9yIGJjNTQ1YjI0LWE4ZTUtNDIyZC1iY2NhLWVkMWVkNWMxZGZiYyIsImF2YWlsYWJpbGl0eUlkIjoiN2Q5YWJmOWUtOGQxYy00MWVjLWIxYjAtN2IyMDQ1MTU3MzM2IiwiY3JlYXRlZCI6IjIwMTMtMDQtMTRUMjI6MTc6MjguODYxNjM3OFoiLCJleHBpcmVzIjoiMjAxMy0wOC0xMlQyMjoxNzoyOC44NjE2Mzc4WiIsImlkIjoiZDIwMzljMDctMzBjZi00MzBiLTgxNTQtYjliN2JkNzFiYjY0IiwicHJvZHVjdERlc2NyaXB0aW9uIjp7IiR0eXBlIjoiT2ZmZXJzLkNvbnRyYWN0cy5WMy5Qcm9kdWN0RGVzY3JpcHRpb24iLCJkaXN0cmlidXRpb25UeXBlIjoiRnVsbCIsImdyYW50ZWRFbnRpdGxlbWVudHMiOlt7IiR0eXBlIjoiT2ZmZXJzLkNvbnRyYWN0cy5WMy5FbnRpdGxlbWVudERlc2NyaXB0aW9uIiwiYmlsbGluZ09mZmVySWQiOm51bGwsImNhdGFsb2dPZmZlcklkIjoiMzJlYmQ5ZmUtNmEyMi00MTExLTk1NGUtNTY0ZWM2OWQ4MDJhIiwiY2F0YWxvZ09mZmVySW5zdGFuY2VJZCI6IjMyZWJkOWZlLTZhMjItNDExMS05NTRlLTU2NGVjNjlkODAyYSIsImNvbnRhaW5lcnMiOm51bGwsImRpc3RyaWJ1dGlvblR5cGUiOiJGdWxsIiwiZHVyYXRpb24iOiIxMDY3NTE5OTowMjo0ODowNS40Nzc1ODA3IiwiZW50aXRsZW1lbnRJZCI6IkdhbWU7MzJlYmQ5ZmUtNmEyMi00MTExLTk1NGUtNTY0ZWM2OWQ4MDJhIiwiZW50aXRsZW1lbnRUeXBlIjoiR2FtZSIsInByb2R1Y3RJZCI6IjMyZWJkOWZlLTZhMjItNDExMS05NTRlLTU2NGVjNjlkODAyYSIsInF1YW50aXR5IjpudWxsLCJzYW5kYm94SWQiOiJQQVJULkRldjEiLCJ0aXRsZUlkIjoiMHhGRkZFMDdEMSIsInVvZGJPZmZlcklkIjpudWxsfV0sInByb2R1Y3RJZCI6IjMyZWJkOWZlLTZhMjItNDExMS05NTRlLTU2NGVjNjlkODAyYSIsInByb2R1Y3RUeXBlIjoiREdhbWUiLCJyZWR1Y2VkVGl0bGUiOiJUYW5rcyIsInN1YnNjcmlwdGlvblBvbGljeUlkIjpudWxsfSwicHJpY2UiOnsiJHR5cGUiOiJPZmZlcnMuQ29udHJhY3RzLlYzLlByaWNlIiwiY2FtcGFpZ25TZWdtZW50ZElkIjpudWxsLCJjdXJyZW5jeUNvZGUiOiJVU0QiLCJpc1RheEluY2x1ZGVkIjpmYWxzZSwicHJpY2VDYW1wYWlnbmRJZCI6bnVsbCwicHJpY2VDYXJkSWQiOiI4OTZjZTNhMy0wMDAwLTAwMDAtYWFhYS0wMDE1NWQyNDFjMTgiLCJwcmljZUNvZGUiOm51bGwsInJldGFpbEFtb3VudCI6MC4wLCJza3VzIjpbeyIkdHlwZSI6Ik9mZmVycy5Db250cmFjdHMuVjMuU2t1IiwiYWNjb3VudCI6Ilplcm9Eb2xsYXJTa3UiLCJhbW91bnQiOjAuMCwiYWNjb3VudFR5cGUiOiJSZXZlbnVlIn1dLCJ3aG9sZXNhbGVBbW91bnQiOjAuMH0sInh1aWQiOm51bGx9.LFX_eBwjspSl_n52ysv5avxcDymWFKH2UyJ517D9I6jbkCS9HyEGmqZxmbDPg88qQnRv1Uq0MEvA0v6jjWCKdxYmmjK4PubgmbTQYdgKfas6AjI2P4jQGQILduhgO9YZ6v8DEmihigfanjRwPTi5WhE_2x1mau51mrZBtDERstL9w-mBSkP3Kgu3FT09MNTbqCdDGH1iSpgvNxaXrs336CtEsTLeuy_yvyRvBR-hjxBTo2JH09v5RYQWA8sJ3zmuYxLVe_Cs55DoyCwMwBXbw1tAZE91uyXwQJUFVmZnVxVx9MLQ8EgePJ6BoUpUasp6Jax-mHiBRswsM1V0STGrxQ"
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
    "ImpressionGuid": "8e6bddc2-ded7-4921-b766-b3a887381caa"
}

```


<a id="ID4ENG"></a>


## <a name="see-also"></a><span data-ttu-id="61317-168">関連項目</span><span class="sxs-lookup"><span data-stu-id="61317-168">See also</span></span>

<a id="ID4EPG"></a>


##### <a name="parent"></a><span data-ttu-id="61317-169">Parent</span><span class="sxs-lookup"><span data-stu-id="61317-169">Parent</span></span>

[<span data-ttu-id="61317-170">/media/{marketplaceId}/details</span><span class="sxs-lookup"><span data-stu-id="61317-170">/media/{marketplaceId}/details</span></span>](uri-medialocaledetails.md)


<a id="ID4EZG"></a>


##### <a name="further-information"></a><span data-ttu-id="61317-171">詳細情報</span><span class="sxs-lookup"><span data-stu-id="61317-171">Further Information</span></span>

[<span data-ttu-id="61317-172">EDS 共通ヘッダー</span><span class="sxs-lookup"><span data-stu-id="61317-172">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="61317-173">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="61317-173">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="61317-174">EDS クエリの絞り込み条件</span><span class="sxs-lookup"><span data-stu-id="61317-174">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="61317-175">マーケットプレース URI</span><span class="sxs-lookup"><span data-stu-id="61317-175">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

 [<span data-ttu-id="61317-176">その他の参照情報</span><span class="sxs-lookup"><span data-stu-id="61317-176">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)
