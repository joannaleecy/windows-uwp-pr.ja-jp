---
title: Achievement (JSON)
assetID: d3b52f66-ddc7-e676-b419-82209caf71d6
permalink: en-us/docs/xboxlive/rest/json-achievementv2.html
author: KevinAsgari
description: " Achievement (JSON)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 12a9cee88a2fdc5b0244119399620c3448f54f75
ms.sourcegitcommit: 086001cffaf436e6e4324761d59bcc5e598c15ea
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/27/2018
ms.locfileid: "5706829"
---
# <a name="achievement-json"></a><span data-ttu-id="9a0be-104">Achievement (JSON)</span><span class="sxs-lookup"><span data-stu-id="9a0be-104">Achievement (JSON)</span></span>
<span data-ttu-id="9a0be-105">実績オブジェクト (バージョン 2)。</span><span class="sxs-lookup"><span data-stu-id="9a0be-105">An Achievement object (version 2).</span></span>
<a id="ID4EN"></a>


## <a name="achievement"></a><span data-ttu-id="9a0be-106">実績</span><span class="sxs-lookup"><span data-stu-id="9a0be-106">Achievement</span></span>

<span data-ttu-id="9a0be-107">実績オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="9a0be-107">The Achievement object has the following specification.</span></span> <span data-ttu-id="9a0be-108">すべてのメンバーが必要です。</span><span class="sxs-lookup"><span data-stu-id="9a0be-108">All members are required.</span></span>

| <span data-ttu-id="9a0be-109">メンバー</span><span class="sxs-lookup"><span data-stu-id="9a0be-109">Member</span></span>| <span data-ttu-id="9a0be-110">種類</span><span class="sxs-lookup"><span data-stu-id="9a0be-110">Type</span></span>| <span data-ttu-id="9a0be-111">説明</span><span class="sxs-lookup"><span data-stu-id="9a0be-111">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="9a0be-112">id</span><span class="sxs-lookup"><span data-stu-id="9a0be-112">id</span></span>| <span data-ttu-id="9a0be-113">string</span><span class="sxs-lookup"><span data-stu-id="9a0be-113">string</span></span>| <span data-ttu-id="9a0be-114">リソース識別子です。</span><span class="sxs-lookup"><span data-stu-id="9a0be-114">Resource identifier.</span></span>|
| <span data-ttu-id="9a0be-115">serviceConfigId</span><span class="sxs-lookup"><span data-stu-id="9a0be-115">serviceConfigId</span></span>| <span data-ttu-id="9a0be-116">string</span><span class="sxs-lookup"><span data-stu-id="9a0be-116">string</span></span>| <span data-ttu-id="9a0be-117">このリソースの SCID です。</span><span class="sxs-lookup"><span data-stu-id="9a0be-117">SCID for this resource.</span></span> <span data-ttu-id="9a0be-118">この実績の関連するタイトルを識別します。</span><span class="sxs-lookup"><span data-stu-id="9a0be-118">Identifies the title(s) this achievement is related to.</span></span> |
| <span data-ttu-id="9a0be-119">name</span><span class="sxs-lookup"><span data-stu-id="9a0be-119">name</span></span>| <span data-ttu-id="9a0be-120">string</span><span class="sxs-lookup"><span data-stu-id="9a0be-120">string</span></span>| <span data-ttu-id="9a0be-121">ローカライズされた実績の名前。</span><span class="sxs-lookup"><span data-stu-id="9a0be-121">The localized Achievement name.</span></span>|
| <span data-ttu-id="9a0be-122">titleAssociations</span><span class="sxs-lookup"><span data-stu-id="9a0be-122">titleAssociations</span></span>| <span data-ttu-id="9a0be-123">[TitleAssociation](json-titleassociation.md)の配列</span><span class="sxs-lookup"><span data-stu-id="9a0be-123">array of [TitleAssociation](json-titleassociation.md)</span></span>| <span data-ttu-id="9a0be-124">TitleAssociation の配列です。</span><span class="sxs-lookup"><span data-stu-id="9a0be-124">An array of TitleAssociation.</span></span>|
| <span data-ttu-id="9a0be-125">progressState</span><span class="sxs-lookup"><span data-stu-id="9a0be-125">progressState</span></span>| <span data-ttu-id="9a0be-126">**ProgressState**列挙型</span><span class="sxs-lookup"><span data-stu-id="9a0be-126">**ProgressState** enumeration</span></span>| <span data-ttu-id="9a0be-127">進行状況の状態。</span><span class="sxs-lookup"><span data-stu-id="9a0be-127">The state of progression:</span></span> <ul><li><span data-ttu-id="9a0be-128">無効な (0): 実績の進行状況が不明な状態です。</span><span class="sxs-lookup"><span data-stu-id="9a0be-128">invalid (0): The achievement progression is in an unknown state.</span></span></li><li><span data-ttu-id="9a0be-129">(1) を実現します。 実績がロック解除されました。</span><span class="sxs-lookup"><span data-stu-id="9a0be-129">achieved (1): The achievement has been unlocked.</span></span></li><li><span data-ttu-id="9a0be-130">inProgress (2): 実績がロックされているが、ユーザーは、ロック解除に向けた進行状況を行ったします。</span><span class="sxs-lookup"><span data-stu-id="9a0be-130">inProgress (2): The achievement is locked but the user has made progress toward unlocking it.</span></span></li><li><span data-ttu-id="9a0be-131">未開始 (3): 実績がロックされているし、ユーザーがロック解除に向けた任意の進行状況がまだ行われています。</span><span class="sxs-lookup"><span data-stu-id="9a0be-131">notStarted (3): The achievement is locked and the user has not made any progress toward unlocking it.</span></span></li></ul> | 
| <span data-ttu-id="9a0be-132">進行状況</span><span class="sxs-lookup"><span data-stu-id="9a0be-132">progression</span></span>| [<span data-ttu-id="9a0be-133">進行状況</span><span class="sxs-lookup"><span data-stu-id="9a0be-133">Progression</span></span>](json-progression.md)| <span data-ttu-id="9a0be-134">実績内で、ユーザーの進行します。</span><span class="sxs-lookup"><span data-stu-id="9a0be-134">The user's progression within the achievement.</span></span>|
| <span data-ttu-id="9a0be-135">mediaAssets</span><span class="sxs-lookup"><span data-stu-id="9a0be-135">mediaAssets</span></span>| <span data-ttu-id="9a0be-136">[MediaAsset](json-mediaasset.md)の配列</span><span class="sxs-lookup"><span data-stu-id="9a0be-136">array of [MediaAsset](json-mediaasset.md)</span></span>| <span data-ttu-id="9a0be-137">画像の Id など、実績に関連付けられているメディア アセット。</span><span class="sxs-lookup"><span data-stu-id="9a0be-137">The media assets associated with the achievement, such as image IDs.</span></span> |
| <span data-ttu-id="9a0be-138">プラットフォーム</span><span class="sxs-lookup"><span data-stu-id="9a0be-138">platform</span></span>| <span data-ttu-id="9a0be-139">string</span><span class="sxs-lookup"><span data-stu-id="9a0be-139">string</span></span>| <span data-ttu-id="9a0be-140">プラットフォーム、実績を獲得します。</span><span class="sxs-lookup"><span data-stu-id="9a0be-140">The platform the achievement was earned on.</span></span>|
| <span data-ttu-id="9a0be-141">isSecret</span><span class="sxs-lookup"><span data-stu-id="9a0be-141">isSecret</span></span>| <span data-ttu-id="9a0be-142">ブール値</span><span class="sxs-lookup"><span data-stu-id="9a0be-142">Boolean value</span></span>| <span data-ttu-id="9a0be-143">実績が秘密かどうか。</span><span class="sxs-lookup"><span data-stu-id="9a0be-143">Whether or not the achievement is secret.</span></span>|
| <span data-ttu-id="9a0be-144">description</span><span class="sxs-lookup"><span data-stu-id="9a0be-144">description</span></span>| <span data-ttu-id="9a0be-145">string</span><span class="sxs-lookup"><span data-stu-id="9a0be-145">string</span></span>| <span data-ttu-id="9a0be-146">実績のロックを解除するときの説明です。</span><span class="sxs-lookup"><span data-stu-id="9a0be-146">The description of the achievement when unlocked.</span></span>|
| <span data-ttu-id="9a0be-147">lockedDescription</span><span class="sxs-lookup"><span data-stu-id="9a0be-147">lockedDescription</span></span>| <span data-ttu-id="9a0be-148">string</span><span class="sxs-lookup"><span data-stu-id="9a0be-148">string</span></span>| <span data-ttu-id="9a0be-149">実績がロック解除する前の説明です。</span><span class="sxs-lookup"><span data-stu-id="9a0be-149">The description of the achievement before it is unlocked.</span></span>|
| <span data-ttu-id="9a0be-150">productId</span><span class="sxs-lookup"><span data-stu-id="9a0be-150">productId</span></span>| <span data-ttu-id="9a0be-151">string</span><span class="sxs-lookup"><span data-stu-id="9a0be-151">string</span></span>| <span data-ttu-id="9a0be-152">ProductId 実績でリリースされました。</span><span class="sxs-lookup"><span data-stu-id="9a0be-152">The ProductId the achievement was released with.</span></span>|
| <span data-ttu-id="9a0be-153">achievementType</span><span class="sxs-lookup"><span data-stu-id="9a0be-153">achievementType</span></span>| <span data-ttu-id="9a0be-154">**AchievementType**列挙型</span><span class="sxs-lookup"><span data-stu-id="9a0be-154">**AchievementType** enumeration</span></span>| <span data-ttu-id="9a0be-155">実績 (しないと同じ前の従来の実績の種類) の種類。</span><span class="sxs-lookup"><span data-stu-id="9a0be-155">The type of achievement (not the same as the previous type on legacy achievements):</span></span> <ul><li><span data-ttu-id="9a0be-156">無効な (0): 不明なおよびサポートされていない実績の種類。</span><span class="sxs-lookup"><span data-stu-id="9a0be-156">invalid (0): An unknown and unsupported achievement type.</span></span></li><li><span data-ttu-id="9a0be-157">永続的な (1): 実績を終了日を持たず、いつでもでもロックできます。</span><span class="sxs-lookup"><span data-stu-id="9a0be-157">persistent (1): An achievement that has no end-date and can be unlocked at any time.</span></span></li><li><span data-ttu-id="9a0be-158">チャレンジ (2): を間になる場合がロックされている特定の時間枠を持つ実績します。</span><span class="sxs-lookup"><span data-stu-id="9a0be-158">challenge (2): An achievement that has a specific time window during which it can be unlocked.</span></span></li></ul> |
| <span data-ttu-id="9a0be-159">participationType</span><span class="sxs-lookup"><span data-stu-id="9a0be-159">participationType</span></span>| <span data-ttu-id="9a0be-160">**ParticipationType**列挙型</span><span class="sxs-lookup"><span data-stu-id="9a0be-160">**ParticipationType** enumeration</span></span>| <span data-ttu-id="9a0be-161">実績の参加の種類。</span><span class="sxs-lookup"><span data-stu-id="9a0be-161">The participation type for the achievement.</span></span> <span data-ttu-id="9a0be-162">有効な値は、個人またはグループはします。</span><span class="sxs-lookup"><span data-stu-id="9a0be-162">Valid values are Individual or Group.</span></span>|
| <span data-ttu-id="9a0be-163">時間</span><span class="sxs-lookup"><span data-stu-id="9a0be-163">timeWindow</span></span>| <span data-ttu-id="9a0be-164">時間</span><span class="sxs-lookup"><span data-stu-id="9a0be-164">TimeWindow</span></span>| <span data-ttu-id="9a0be-165">によって、実績ない可能性がありますロックされている時間枠です。</span><span class="sxs-lookup"><span data-stu-id="9a0be-165">The time window during which the achievement may be unlocked.</span></span> <span data-ttu-id="9a0be-166">課題用のみサポートされます。</span><span class="sxs-lookup"><span data-stu-id="9a0be-166">Only supported for Challenges.</span></span>|
| <span data-ttu-id="9a0be-167">リワード</span><span class="sxs-lookup"><span data-stu-id="9a0be-167">rewards</span></span>| <span data-ttu-id="9a0be-168">[リワード](json-reward.md)の配列</span><span class="sxs-lookup"><span data-stu-id="9a0be-168">array of [Reward](json-reward.md)</span></span>| <span data-ttu-id="9a0be-169">リワードのロックを解除するときの原因のコレクションです。</span><span class="sxs-lookup"><span data-stu-id="9a0be-169">The collection of rewards earned when unlocked.</span></span>|
| <span data-ttu-id="9a0be-170">estimatedTime</span><span class="sxs-lookup"><span data-stu-id="9a0be-170">estimatedTime</span></span>| <span data-ttu-id="9a0be-171">TimeSpan</span><span class="sxs-lookup"><span data-stu-id="9a0be-171">TimeSpan</span></span>| <span data-ttu-id="9a0be-172">推定時間を獲得実績になります。</span><span class="sxs-lookup"><span data-stu-id="9a0be-172">The estimated time the achievement will take to earn.</span></span>|
| <span data-ttu-id="9a0be-173">deeplink</span><span class="sxs-lookup"><span data-stu-id="9a0be-173">deeplink</span></span>| <span data-ttu-id="9a0be-174">string</span><span class="sxs-lookup"><span data-stu-id="9a0be-174">string</span></span>| <span data-ttu-id="9a0be-175">タイトルに deeplink します。</span><span class="sxs-lookup"><span data-stu-id="9a0be-175">A deeplink into the title.</span></span>|
| <span data-ttu-id="9a0be-176">isRevoked</span><span class="sxs-lookup"><span data-stu-id="9a0be-176">isRevoked</span></span>| <span data-ttu-id="9a0be-177">ブール値</span><span class="sxs-lookup"><span data-stu-id="9a0be-177">Boolean value</span></span>| <span data-ttu-id="9a0be-178">かどうか、実績が実施で失効します。</span><span class="sxs-lookup"><span data-stu-id="9a0be-178">Whether or not the achievement is revoked by enforcement.</span></span>|

<a id="ID4EIAAC"></a>


## <a name="sample-json-syntax"></a><span data-ttu-id="9a0be-179">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="9a0be-179">Sample JSON syntax</span></span>


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


## <a name="see-also"></a><span data-ttu-id="9a0be-180">関連項目</span><span class="sxs-lookup"><span data-stu-id="9a0be-180">See also</span></span>

<a id="ID4ETAAC"></a>


##### <a name="parent"></a><span data-ttu-id="9a0be-181">Parent</span><span class="sxs-lookup"><span data-stu-id="9a0be-181">Parent</span></span>

[<span data-ttu-id="9a0be-182">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="9a0be-182">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)
