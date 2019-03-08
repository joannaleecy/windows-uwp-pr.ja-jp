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
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57622717"
---
# <a name="get-mediamarketplaceiddetails"></a><span data-ttu-id="2cd69-104">GET (/media/{marketplaceId}/details)</span><span class="sxs-lookup"><span data-stu-id="2cd69-104">GET (/media/{marketplaceId}/details)</span></span>
<span data-ttu-id="2cd69-105">プランの詳細、メタデータを返しますについて 1 つまたは複数の項目。</span><span class="sxs-lookup"><span data-stu-id="2cd69-105">Returns offer details and metadata about one or more items.</span></span>
<span data-ttu-id="2cd69-106">これらの Uri のドメインが`eds.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="2cd69-106">The domain for these URIs is `eds.xboxlive.com`.</span></span>

  * [<span data-ttu-id="2cd69-107">注釈</span><span class="sxs-lookup"><span data-stu-id="2cd69-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="2cd69-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="2cd69-108">URI parameters</span></span>](#ID4ECB)
  * [<span data-ttu-id="2cd69-109">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="2cd69-109">Query string parameters</span></span>](#ID4ERB)
  * [<span data-ttu-id="2cd69-110">応答本文</span><span class="sxs-lookup"><span data-stu-id="2cd69-110">Response body</span></span>](#ID4EYF)

<a id="ID4EV"></a>


## <a name="remarks"></a><span data-ttu-id="2cd69-111">注釈</span><span class="sxs-lookup"><span data-stu-id="2cd69-111">Remarks</span></span>

<span data-ttu-id="2cd69-112">**SandboxId**今すぐ、XToken 内の要求から取得され、適用します。</span><span class="sxs-lookup"><span data-stu-id="2cd69-112">**SandboxId** is now retrieved from the claim in the XToken and enforced.</span></span> <span data-ttu-id="2cd69-113">場合、 **SandboxId**エンターテイメント検出サービス (EDS) は 400 Bad request エラーをスローしが存在しません。</span><span class="sxs-lookup"><span data-stu-id="2cd69-113">If the **SandboxId** is not present, then Entertainment Discovery Services (EDS) will throw a 400 Bad request error.</span></span>

<a id="ID4ECB"></a>


## <a name="uri-parameters"></a><span data-ttu-id="2cd69-114">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="2cd69-114">URI parameters</span></span>

| <span data-ttu-id="2cd69-115">パラメーター</span><span class="sxs-lookup"><span data-stu-id="2cd69-115">Parameter</span></span>| <span data-ttu-id="2cd69-116">種類</span><span class="sxs-lookup"><span data-stu-id="2cd69-116">Type</span></span>| <span data-ttu-id="2cd69-117">説明</span><span class="sxs-lookup"><span data-stu-id="2cd69-117">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="2cd69-118">marketplaceId</span><span class="sxs-lookup"><span data-stu-id="2cd69-118">marketplaceId</span></span>| <span data-ttu-id="2cd69-119">string</span><span class="sxs-lookup"><span data-stu-id="2cd69-119">string</span></span>| <span data-ttu-id="2cd69-120">必須。</span><span class="sxs-lookup"><span data-stu-id="2cd69-120">Required.</span></span> <span data-ttu-id="2cd69-121">文字列から取得した値、 <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>します。</span><span class="sxs-lookup"><span data-stu-id="2cd69-121">String value obtained from the <b>Windows.Xbox.ApplicationModel.Store.Configuration.MarketplaceId</b>.</span></span>|

<a id="ID4ERB"></a>


## <a name="query-string-parameters"></a><span data-ttu-id="2cd69-122">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="2cd69-122">Query string parameters</span></span>

| <span data-ttu-id="2cd69-123">パラメーター</span><span class="sxs-lookup"><span data-stu-id="2cd69-123">Parameter</span></span>| <span data-ttu-id="2cd69-124">種類</span><span class="sxs-lookup"><span data-stu-id="2cd69-124">Type</span></span>| <span data-ttu-id="2cd69-125">説明</span><span class="sxs-lookup"><span data-stu-id="2cd69-125">Description</span></span>|
| --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="2cd69-126">id</span><span class="sxs-lookup"><span data-stu-id="2cd69-126">ids</span></span>| <span data-ttu-id="2cd69-127">string[]</span><span class="sxs-lookup"><span data-stu-id="2cd69-127">string[]</span></span>| <span data-ttu-id="2cd69-128">必須。</span><span class="sxs-lookup"><span data-stu-id="2cd69-128">Required.</span></span> <span data-ttu-id="2cd69-129">すべての詳細情報が返されます (最大 10) の Id。</span><span class="sxs-lookup"><span data-stu-id="2cd69-129">All of the IDs (up to 10) for which details will be returned.</span></span> <span data-ttu-id="2cd69-130">注、いずれかの ID を URL に無効な文字が含まれています (Id は通常、ProviderContentId 型は、完全な Url 自体と、したがって無効な文字を含む)<b>する必要があります</b>エンターテイメントに正しく送信される URL でエンコードします。探索サービス (EDS)。</span><span class="sxs-lookup"><span data-stu-id="2cd69-130">Note that any ID that contains characters illegal to put in a URL (the ProviderContentId type IDs are normally full URLs themselves and thus contain illegal characters) <b>MUST</b> be URL-encoded to be properly sent to Entertainment Discovery Services (EDS).</span></span> <span data-ttu-id="2cd69-131">これのみできる単一の値を ID の種類が ProviderContentId 場合にも注意してください。</span><span class="sxs-lookup"><span data-stu-id="2cd69-131">Also note that this can only be a single value if the ID type is ProviderContentId.</span></span> <span data-ttu-id="2cd69-132">ProviderContentId の 1 つ以上が必要な場合、EDS に複数の呼び出しを行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="2cd69-132">If more than one ProviderContentId is desired, multiple calls must be made to EDS.</span></span>|
| <span data-ttu-id="2cd69-133">idType</span><span class="sxs-lookup"><span data-stu-id="2cd69-133">IdType</span></span>| <span data-ttu-id="2cd69-134">string</span><span class="sxs-lookup"><span data-stu-id="2cd69-134">string</span></span>| <span data-ttu-id="2cd69-135">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="2cd69-135">Optional.</span></span> <span data-ttu-id="2cd69-136">'Id' パラメーターに渡された Id の型。</span><span class="sxs-lookup"><span data-stu-id="2cd69-136">The type of the IDs which are passed in to the 'ids' parameter.</span></span> <span data-ttu-id="2cd69-137">有効な値は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="2cd69-137">Valid values are:</span></span> <ul><li><span data-ttu-id="2cd69-138"><b>正規</b>(Bing と Marketplace)</span><span class="sxs-lookup"><span data-stu-id="2cd69-138"><b>Canonical</b> (Bing/Marketplace)</span></span> </li><li><span data-ttu-id="2cd69-139"><b>ZuneCatalog</b></span><span class="sxs-lookup"><span data-stu-id="2cd69-139"><b>ZuneCatalog</b></span></span></li><li><span data-ttu-id="2cd69-140"><b>ZuneMediaInstance</b> (例: 1 ~ 32 kb WMA 音楽ファイル)</span><span class="sxs-lookup"><span data-stu-id="2cd69-140"><b>ZuneMediaInstance</b> (eg 132 kb WMA music file)</span></span> </li><li><span data-ttu-id="2cd69-141"><b>AMG</b></span><span class="sxs-lookup"><span data-stu-id="2cd69-141"><b>AMG</b></span></span></li><li><span data-ttu-id="2cd69-142"><b>MediaNet</b> (MusiWave 前)</span><span class="sxs-lookup"><span data-stu-id="2cd69-142"><b>MediaNet</b> (pre-MusiWave)</span></span> </li><li><span data-ttu-id="2cd69-143"><b>XboxHexTitle</b> (アプリ、コンソールでの再生)</span><span class="sxs-lookup"><span data-stu-id="2cd69-143"><b>XboxHexTitle</b> (App playing on the console)</span></span> </li></ul>|
| <span data-ttu-id="2cd69-144">desiredMediaItemTypes</span><span class="sxs-lookup"><span data-stu-id="2cd69-144">DesiredMediaItemTypes</span></span>| <span data-ttu-id="2cd69-145">string</span><span class="sxs-lookup"><span data-stu-id="2cd69-145">string</span></span>| <span data-ttu-id="2cd69-146"><b>MediaGroup が渡されないかどうかに必要です。どちらも渡すことはできません。</b></span><span class="sxs-lookup"><span data-stu-id="2cd69-146"><b>Required if MediaGroup is not passed. Both should not be passed.</b></span></span> <span data-ttu-id="2cd69-147">メディア項目の種類の Id。</span><span class="sxs-lookup"><span data-stu-id="2cd69-147">The media item typs of the IDs.</span></span> <span data-ttu-id="2cd69-148">すべて提供される Id が同じ型を共有する必要があります。</span><span class="sxs-lookup"><span data-stu-id="2cd69-148">All provided IDs must share the same type.</span></span> <span data-ttu-id="2cd69-149">複数の種類が必要な場合は、IdType 上記で説明されている、すべての使用可能な型で渡します。</span><span class="sxs-lookup"><span data-stu-id="2cd69-149">If multiple types are desired, pass in all possible types as described in the IdType above.</span></span> <span data-ttu-id="2cd69-150">この値の既定値は「不明」が存在しない場合ができない可能性があります valied のすべての ID の種類。</span><span class="sxs-lookup"><span data-stu-id="2cd69-150">This value defaults to "Unknown" if it is not present, which may not be valied for all ID types.</span></span> |
| <span data-ttu-id="2cd69-151">mediaGroup</span><span class="sxs-lookup"><span data-stu-id="2cd69-151">MediaGroup</span></span>| <span data-ttu-id="2cd69-152">string</span><span class="sxs-lookup"><span data-stu-id="2cd69-152">string</span></span>| <span data-ttu-id="2cd69-153"><b>DesiredMediaItemTypes が渡されないかどうかに必要です。どちらも渡すことはできません。</b></span><span class="sxs-lookup"><span data-stu-id="2cd69-153"><b>Required if DesiredMediaItemTypes is not passed. Both should not be passed.</b></span></span>|
| <span data-ttu-id="2cd69-154">ConditionSets</span><span class="sxs-lookup"><span data-stu-id="2cd69-154">ConditionSets</span></span>| <span data-ttu-id="2cd69-155">string</span><span class="sxs-lookup"><span data-stu-id="2cd69-155">string</span></span>| <span data-ttu-id="2cd69-156"><b>省略可能な</b>します。</span><span class="sxs-lookup"><span data-stu-id="2cd69-156"><b>Optional</b>.</span></span> <span data-ttu-id="2cd69-157">クライアントが要求<b>可用性</b>条件のセットは、このクエリ文字列で指定されたキーと値のペアがに基づいて、排除します。</span><span class="sxs-lookup"><span data-stu-id="2cd69-157">Clients may request <b>Availability</b> pruning based on condition sets, which are key-value pairs specified through this query string.</span></span> <span data-ttu-id="2cd69-158">可用性の条件セットで一致するように使用されます。</span><span class="sxs-lookup"><span data-stu-id="2cd69-158">They are used to match on the condition sets of an availability.</span></span> <span data-ttu-id="2cd69-159">条件のセットを一致するように使用できるキーの一覧は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="2cd69-159">The list of keys that can be used to match the condition sets is as follows.</span></span> <ul><li><span data-ttu-id="2cd69-160"><b>プラットフォーム</b>:場所、製品は、構築され、再生できます。</span><span class="sxs-lookup"><span data-stu-id="2cd69-160"><b>Platforms</b>: Where the product is built and can be played.</span></span></li><li><span data-ttu-id="2cd69-161"><b>サブスクリプション</b>:この可用性 (Gold または Silver) のサポートされているサブスクリプションの一覧です。</span><span class="sxs-lookup"><span data-stu-id="2cd69-161"><b>Subscriptions</b>: List of supported subscriptions for this availability (Gold or Silver).</span></span></li><li><span data-ttu-id="2cd69-162"><b>EntitlementIds</b>:ユーザーがゲームを購入後に追跡します。</span><span class="sxs-lookup"><span data-stu-id="2cd69-162"><b>EntitlementIds</b>: Tracked after users buy the game.</span></span></li></ul> | 

<a id="ID4EYF"></a>


## <a name="response-body"></a><span data-ttu-id="2cd69-163">応答本文</span><span class="sxs-lookup"><span data-stu-id="2cd69-163">Response body</span></span>

<a id="ID4E5F"></a>


### <a name="sample-response"></a><span data-ttu-id="2cd69-164">応答のサンプル</span><span class="sxs-lookup"><span data-stu-id="2cd69-164">Sample response</span></span>

<span data-ttu-id="2cd69-165">次の JSON コードが呼び出しへの応答では`/media/en-us/details?ids=6c5402e4-3cd5-4b29-a9c4-bec7d2c7514a&mediaGroup=GameType`します。</span><span class="sxs-lookup"><span data-stu-id="2cd69-165">The JSON code below is in response to the call `/media/en-us/details?ids=6c5402e4-3cd5-4b29-a9c4-bec7d2c7514a&mediaGroup=GameType`.</span></span>


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


## <a name="see-also"></a><span data-ttu-id="2cd69-166">関連項目</span><span class="sxs-lookup"><span data-stu-id="2cd69-166">See also</span></span>

<a id="ID4EPG"></a>


##### <a name="parent"></a><span data-ttu-id="2cd69-167">Parent</span><span class="sxs-lookup"><span data-stu-id="2cd69-167">Parent</span></span>

[<span data-ttu-id="2cd69-168">/media/{marketplaceId}/details</span><span class="sxs-lookup"><span data-stu-id="2cd69-168">/media/{marketplaceId}/details</span></span>](uri-medialocaledetails.md)


<a id="ID4EZG"></a>


##### <a name="further-information"></a><span data-ttu-id="2cd69-169">詳細情報</span><span class="sxs-lookup"><span data-stu-id="2cd69-169">Further Information</span></span>

[<span data-ttu-id="2cd69-170">EDS の一般的なヘッダー</span><span class="sxs-lookup"><span data-stu-id="2cd69-170">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="2cd69-171">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="2cd69-171">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="2cd69-172">EDS は、絞り込み条件をクエリします。</span><span class="sxs-lookup"><span data-stu-id="2cd69-172">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="2cd69-173">Marketplace の Uri</span><span class="sxs-lookup"><span data-stu-id="2cd69-173">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

 [<span data-ttu-id="2cd69-174">その他の参照</span><span class="sxs-lookup"><span data-stu-id="2cd69-174">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)
