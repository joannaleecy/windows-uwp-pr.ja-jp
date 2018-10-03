---
title: Achievement (JSON)
assetID: d3b52f66-ddc7-e676-b419-82209caf71d6
permalink: en-us/docs/xboxlive/rest/json-achievementv2.html
author: KevinAsgari
description: " Achievement (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: e82306119e428dd9279e26d1497d44b371b9587e
ms.sourcegitcommit: 1938851dc132c60348f9722daf994b86f2ead09e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/03/2018
ms.locfileid: "4267280"
---
# <a name="achievement-json"></a><span data-ttu-id="481c8-104">Achievement (JSON)</span><span class="sxs-lookup"><span data-stu-id="481c8-104">Achievement (JSON)</span></span>
<span data-ttu-id="481c8-105">実績オブジェクト (バージョン 2)。</span><span class="sxs-lookup"><span data-stu-id="481c8-105">An Achievement object (version 2).</span></span>
<a id="ID4EN"></a>


## <a name="achievement"></a><span data-ttu-id="481c8-106">実績</span><span class="sxs-lookup"><span data-stu-id="481c8-106">Achievement</span></span>

<span data-ttu-id="481c8-107">実績のオブジェクトでは、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="481c8-107">The Achievement object has the following specification.</span></span> <span data-ttu-id="481c8-108">すべてのメンバーが必要です。</span><span class="sxs-lookup"><span data-stu-id="481c8-108">All members are required.</span></span>

| <span data-ttu-id="481c8-109">メンバー</span><span class="sxs-lookup"><span data-stu-id="481c8-109">Member</span></span>| <span data-ttu-id="481c8-110">種類</span><span class="sxs-lookup"><span data-stu-id="481c8-110">Type</span></span>| <span data-ttu-id="481c8-111">説明</span><span class="sxs-lookup"><span data-stu-id="481c8-111">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="481c8-112">id</span><span class="sxs-lookup"><span data-stu-id="481c8-112">id</span></span>| <span data-ttu-id="481c8-113">string</span><span class="sxs-lookup"><span data-stu-id="481c8-113">string</span></span>| <span data-ttu-id="481c8-114">リソース識別子です。</span><span class="sxs-lookup"><span data-stu-id="481c8-114">Resource identifier.</span></span>|
| <span data-ttu-id="481c8-115">serviceConfigId</span><span class="sxs-lookup"><span data-stu-id="481c8-115">serviceConfigId</span></span>| <span data-ttu-id="481c8-116">string</span><span class="sxs-lookup"><span data-stu-id="481c8-116">string</span></span>| <span data-ttu-id="481c8-117">このリソースの SCID です。</span><span class="sxs-lookup"><span data-stu-id="481c8-117">SCID for this resource.</span></span> <span data-ttu-id="481c8-118">この実績の関連するタイトルを識別します。</span><span class="sxs-lookup"><span data-stu-id="481c8-118">Identifies the title(s) this achievement is related to.</span></span> |
| <span data-ttu-id="481c8-119">name</span><span class="sxs-lookup"><span data-stu-id="481c8-119">name</span></span>| <span data-ttu-id="481c8-120">string</span><span class="sxs-lookup"><span data-stu-id="481c8-120">string</span></span>| <span data-ttu-id="481c8-121">ローカライズされた実績の名前です。</span><span class="sxs-lookup"><span data-stu-id="481c8-121">The localized Achievement name.</span></span>|
| <span data-ttu-id="481c8-122">titleAssociations</span><span class="sxs-lookup"><span data-stu-id="481c8-122">titleAssociations</span></span>| <span data-ttu-id="481c8-123">[TitleAssociation](json-titleassociation.md)の配列</span><span class="sxs-lookup"><span data-stu-id="481c8-123">array of [TitleAssociation](json-titleassociation.md)</span></span>| <span data-ttu-id="481c8-124">TitleAssociation の配列です。</span><span class="sxs-lookup"><span data-stu-id="481c8-124">An array of TitleAssociation.</span></span>|
| <span data-ttu-id="481c8-125">progressState</span><span class="sxs-lookup"><span data-stu-id="481c8-125">progressState</span></span>| <span data-ttu-id="481c8-126">**ProgressState**列挙</span><span class="sxs-lookup"><span data-stu-id="481c8-126">**ProgressState** enumeration</span></span>| <span data-ttu-id="481c8-127">進行状況の状態。</span><span class="sxs-lookup"><span data-stu-id="481c8-127">The state of progression:</span></span> <ul><li><span data-ttu-id="481c8-128">無効 (0): 実績の進行状況が不明な状態です。</span><span class="sxs-lookup"><span data-stu-id="481c8-128">invalid (0): The achievement progression is in an unknown state.</span></span></li><li><span data-ttu-id="481c8-129">(1) を実現: 実績がロック解除されました。</span><span class="sxs-lookup"><span data-stu-id="481c8-129">achieved (1): The achievement has been unlocked.</span></span></li><li><span data-ttu-id="481c8-130">inProgress (2): 実績がロックされているが、ユーザーは、ロック解除に向けた進行状況を行ったします。</span><span class="sxs-lookup"><span data-stu-id="481c8-130">inProgress (2): The achievement is locked but the user has made progress toward unlocking it.</span></span></li><li><span data-ttu-id="481c8-131">未開始 (3): 実績がロックされているし、ユーザーがロック解除に向けた任意の進行状況がまだ行われています。</span><span class="sxs-lookup"><span data-stu-id="481c8-131">notStarted (3): The achievement is locked and the user has not made any progress toward unlocking it.</span></span></li></ul> | 
| <span data-ttu-id="481c8-132">進行状況</span><span class="sxs-lookup"><span data-stu-id="481c8-132">progression</span></span>| [<span data-ttu-id="481c8-133">進行状況</span><span class="sxs-lookup"><span data-stu-id="481c8-133">Progression</span></span>](json-progression.md)| <span data-ttu-id="481c8-134">実績内のユーザーの進行状況です。</span><span class="sxs-lookup"><span data-stu-id="481c8-134">The user's progression within the achievement.</span></span>|
| <span data-ttu-id="481c8-135">mediaAssets</span><span class="sxs-lookup"><span data-stu-id="481c8-135">mediaAssets</span></span>| <span data-ttu-id="481c8-136">[MediaAsset](json-mediaasset.md)の配列</span><span class="sxs-lookup"><span data-stu-id="481c8-136">array of [MediaAsset](json-mediaasset.md)</span></span>| <span data-ttu-id="481c8-137">画像の Id など、実績に関連付けられているメディア アセット。</span><span class="sxs-lookup"><span data-stu-id="481c8-137">The media assets associated with the achievement, such as image IDs.</span></span> |
| <span data-ttu-id="481c8-138">プラットフォーム</span><span class="sxs-lookup"><span data-stu-id="481c8-138">platform</span></span>| <span data-ttu-id="481c8-139">string</span><span class="sxs-lookup"><span data-stu-id="481c8-139">string</span></span>| <span data-ttu-id="481c8-140">プラットフォーム、実績を獲得するとします。</span><span class="sxs-lookup"><span data-stu-id="481c8-140">The platform the achievement was earned on.</span></span>|
| <span data-ttu-id="481c8-141">isSecret</span><span class="sxs-lookup"><span data-stu-id="481c8-141">isSecret</span></span>| <span data-ttu-id="481c8-142">ブール値</span><span class="sxs-lookup"><span data-stu-id="481c8-142">Boolean value</span></span>| <span data-ttu-id="481c8-143">実績が秘密かどうか。</span><span class="sxs-lookup"><span data-stu-id="481c8-143">Whether or not the achievement is secret.</span></span>|
| <span data-ttu-id="481c8-144">description</span><span class="sxs-lookup"><span data-stu-id="481c8-144">description</span></span>| <span data-ttu-id="481c8-145">string</span><span class="sxs-lookup"><span data-stu-id="481c8-145">string</span></span>| <span data-ttu-id="481c8-146">実績のロックを解除するときの説明です。</span><span class="sxs-lookup"><span data-stu-id="481c8-146">The description of the achievement when unlocked.</span></span>|
| <span data-ttu-id="481c8-147">lockedDescription</span><span class="sxs-lookup"><span data-stu-id="481c8-147">lockedDescription</span></span>| <span data-ttu-id="481c8-148">string</span><span class="sxs-lookup"><span data-stu-id="481c8-148">string</span></span>| <span data-ttu-id="481c8-149">実績がロック解除する前に説明します。</span><span class="sxs-lookup"><span data-stu-id="481c8-149">The description of the achievement before it is unlocked.</span></span>|
| <span data-ttu-id="481c8-150">productId</span><span class="sxs-lookup"><span data-stu-id="481c8-150">productId</span></span>| <span data-ttu-id="481c8-151">string</span><span class="sxs-lookup"><span data-stu-id="481c8-151">string</span></span>| <span data-ttu-id="481c8-152">ProductId 実績でリリースされました。</span><span class="sxs-lookup"><span data-stu-id="481c8-152">The ProductId the achievement was released with.</span></span>|
| <span data-ttu-id="481c8-153">achievementType</span><span class="sxs-lookup"><span data-stu-id="481c8-153">achievementType</span></span>| <span data-ttu-id="481c8-154">**AchievementType**列挙</span><span class="sxs-lookup"><span data-stu-id="481c8-154">**AchievementType** enumeration</span></span>| <span data-ttu-id="481c8-155">実績 (しないと同じ以前の従来の実績の種類) の種類。</span><span class="sxs-lookup"><span data-stu-id="481c8-155">The type of achievement (not the same as the previous type on legacy achievements):</span></span> <ul><li><span data-ttu-id="481c8-156">無効 (0): 不明なおよびサポートされていない実績型です。</span><span class="sxs-lookup"><span data-stu-id="481c8-156">invalid (0): An unknown and unsupported achievement type.</span></span></li><li><span data-ttu-id="481c8-157">永続的な (1): 実績を終了日がないと、いつでもロックできます。</span><span class="sxs-lookup"><span data-stu-id="481c8-157">persistent (1): An achievement that has no end-date and can be unlocked at any time.</span></span></li><li><span data-ttu-id="481c8-158">チャレンジ (2): を間になる場合がロックされている特定の時間枠を持つ実績します。</span><span class="sxs-lookup"><span data-stu-id="481c8-158">challenge (2): An achievement that has a specific time window during which it can be unlocked.</span></span></li></ul> |
| <span data-ttu-id="481c8-159">participationType</span><span class="sxs-lookup"><span data-stu-id="481c8-159">participationType</span></span>| <span data-ttu-id="481c8-160">**ParticipationType**列挙</span><span class="sxs-lookup"><span data-stu-id="481c8-160">**ParticipationType** enumeration</span></span>| <span data-ttu-id="481c8-161">実績の参加の種類。</span><span class="sxs-lookup"><span data-stu-id="481c8-161">The participation type for the achievement.</span></span> <span data-ttu-id="481c8-162">有効な値は、個人またはグループはします。</span><span class="sxs-lookup"><span data-stu-id="481c8-162">Valid values are Individual or Group.</span></span>|
| <span data-ttu-id="481c8-163">時間</span><span class="sxs-lookup"><span data-stu-id="481c8-163">timeWindow</span></span>| <span data-ttu-id="481c8-164">時間</span><span class="sxs-lookup"><span data-stu-id="481c8-164">TimeWindow</span></span>| <span data-ttu-id="481c8-165">時に、実績がロックを解除する時間枠です。</span><span class="sxs-lookup"><span data-stu-id="481c8-165">The time window during which the achievement may be unlocked.</span></span> <span data-ttu-id="481c8-166">チャレンジのみサポートされます。</span><span class="sxs-lookup"><span data-stu-id="481c8-166">Only supported for Challenges.</span></span>|
| <span data-ttu-id="481c8-167">リワード</span><span class="sxs-lookup"><span data-stu-id="481c8-167">rewards</span></span>| <span data-ttu-id="481c8-168">[リワード](json-reward.md)の配列</span><span class="sxs-lookup"><span data-stu-id="481c8-168">array of [Reward](json-reward.md)</span></span>| <span data-ttu-id="481c8-169">リワードのロックを解除するときの原因のコレクションです。</span><span class="sxs-lookup"><span data-stu-id="481c8-169">The collection of rewards earned when unlocked.</span></span>|
| <span data-ttu-id="481c8-170">estimatedTime</span><span class="sxs-lookup"><span data-stu-id="481c8-170">estimatedTime</span></span>| <span data-ttu-id="481c8-171">TimeSpan</span><span class="sxs-lookup"><span data-stu-id="481c8-171">TimeSpan</span></span>| <span data-ttu-id="481c8-172">推定時間を獲得実績になります。</span><span class="sxs-lookup"><span data-stu-id="481c8-172">The estimated time the achievement will take to earn.</span></span>|
| <span data-ttu-id="481c8-173">deeplink</span><span class="sxs-lookup"><span data-stu-id="481c8-173">deeplink</span></span>| <span data-ttu-id="481c8-174">string</span><span class="sxs-lookup"><span data-stu-id="481c8-174">string</span></span>| <span data-ttu-id="481c8-175">タイトルに deeplink します。</span><span class="sxs-lookup"><span data-stu-id="481c8-175">A deeplink into the title.</span></span>|
| <span data-ttu-id="481c8-176">isRevoked</span><span class="sxs-lookup"><span data-stu-id="481c8-176">isRevoked</span></span>| <span data-ttu-id="481c8-177">ブール値</span><span class="sxs-lookup"><span data-stu-id="481c8-177">Boolean value</span></span>| <span data-ttu-id="481c8-178">かどうかの実施によって、実績が失効します。</span><span class="sxs-lookup"><span data-stu-id="481c8-178">Whether or not the achievement is revoked by enforcement.</span></span>|

<a id="ID4EIAAC"></a>


## <a name="sample-json-syntax"></a><span data-ttu-id="481c8-179">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="481c8-179">Sample JSON syntax</span></span>


```json
{
        "id":"3",
        "serviceConfigId":"b5dd9daf-0000-0000-0000-000000000000",
        "name":"Default NameString for Microsoft Achievements Sample Achievement 3",
        "titleAssociations":
        [{
                "name":"Microsoft Achievements Sample",
                "id":3051199919,
                "version":"abc"
        }],
        "progressState":"Achieved",
        "progression":
        {
          "requirements":
          [{
            "id":"12345678-1234-1234-1234-123456789012",
            "current":null,
            "target":"100"
          }],
          "timeUnlocked":"2013-01-17T03:19:00.3087016Z",
        },
        "mediaAssets":
        [{
                "name":"Icon Name",
                "type":"Icon",
                "url":"http://www.xbox.com"
        }],
        "platform":"D",
        "isSecret":true,
        "description":"Default DescriptionString for Microsoft Achievements Sample Achievement 3",
        "lockedDescription":"Default UnachievedString for Microsoft Achievements Sample Achievement 3",
        "productId":"12345678-1234-1234-1234-123456789012",
        "achievementType":"Challenge",
        "participationType":"Individual",
        "timeWindow":
        {
                "startDate":"2013-02-01T00:00:00Z",
                "endDate":"2100-07-01T00:00:00Z"
        },
        "rewards":
        [{
                "name":null,
                "description":null,
                "value":"10",
                "type":"Gamerscore",
                "valueType":"Int"
        },
        {
                "name":"Default Name for InAppReward for Microsoft Achievements Sample Achievement 3",
                "description":"Default Description for InAppReward for Microsoft Achievements Sample Achievement 3",
                "value":"1",
                "type":"InApp",
                "valueType":"String"
        }],
        "estimatedTime":"06:12:14",
        "deeplink":"aWFtYWRlZXBsaW5r",
        "isRevoked":false
    }

```


<a id="ID4ERAAC"></a>


## <a name="see-also"></a><span data-ttu-id="481c8-180">関連項目</span><span class="sxs-lookup"><span data-stu-id="481c8-180">See also</span></span>

<a id="ID4ETAAC"></a>


##### <a name="parent"></a><span data-ttu-id="481c8-181">Parent</span><span class="sxs-lookup"><span data-stu-id="481c8-181">Parent</span></span>

[<span data-ttu-id="481c8-182">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="481c8-182">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)
