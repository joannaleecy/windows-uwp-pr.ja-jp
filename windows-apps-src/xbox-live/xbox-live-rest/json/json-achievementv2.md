---
title: Achievement (JSON)
assetID: d3b52f66-ddc7-e676-b419-82209caf71d6
permalink: en-us/docs/xboxlive/rest/json-achievementv2.html
description: " Achievement (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: b0e20f46a0d97cba496df5c6fb9cda14fbeccccd
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57628477"
---
# <a name="achievement-json"></a><span data-ttu-id="c1945-104">Achievement (JSON)</span><span class="sxs-lookup"><span data-stu-id="c1945-104">Achievement (JSON)</span></span>
<span data-ttu-id="c1945-105">アチーブメント オブジェクト (バージョン 2)。</span><span class="sxs-lookup"><span data-stu-id="c1945-105">An Achievement object (version 2).</span></span>
<a id="ID4EN"></a>


## <a name="achievement"></a><span data-ttu-id="c1945-106">アチーブメントが獲得されました</span><span class="sxs-lookup"><span data-stu-id="c1945-106">Achievement</span></span>

<span data-ttu-id="c1945-107">アチーブメント オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="c1945-107">The Achievement object has the following specification.</span></span> <span data-ttu-id="c1945-108">すべてのメンバーが必要です。</span><span class="sxs-lookup"><span data-stu-id="c1945-108">All members are required.</span></span>

| <span data-ttu-id="c1945-109">メンバー</span><span class="sxs-lookup"><span data-stu-id="c1945-109">Member</span></span>| <span data-ttu-id="c1945-110">種類</span><span class="sxs-lookup"><span data-stu-id="c1945-110">Type</span></span>| <span data-ttu-id="c1945-111">説明</span><span class="sxs-lookup"><span data-stu-id="c1945-111">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="c1945-112">id</span><span class="sxs-lookup"><span data-stu-id="c1945-112">id</span></span>| <span data-ttu-id="c1945-113">string</span><span class="sxs-lookup"><span data-stu-id="c1945-113">string</span></span>| <span data-ttu-id="c1945-114">リソースの識別子です。</span><span class="sxs-lookup"><span data-stu-id="c1945-114">Resource identifier.</span></span>|
| <span data-ttu-id="c1945-115">serviceConfigId</span><span class="sxs-lookup"><span data-stu-id="c1945-115">serviceConfigId</span></span>| <span data-ttu-id="c1945-116">string</span><span class="sxs-lookup"><span data-stu-id="c1945-116">string</span></span>| <span data-ttu-id="c1945-117">このリソースの SCID します。</span><span class="sxs-lookup"><span data-stu-id="c1945-117">SCID for this resource.</span></span> <span data-ttu-id="c1945-118">この実績に関連するタイトルを識別します。</span><span class="sxs-lookup"><span data-stu-id="c1945-118">Identifies the title(s) this achievement is related to.</span></span> |
| <span data-ttu-id="c1945-119">name</span><span class="sxs-lookup"><span data-stu-id="c1945-119">name</span></span>| <span data-ttu-id="c1945-120">string</span><span class="sxs-lookup"><span data-stu-id="c1945-120">string</span></span>| <span data-ttu-id="c1945-121">ローカライズされたアチーブメント名前。</span><span class="sxs-lookup"><span data-stu-id="c1945-121">The localized Achievement name.</span></span>|
| <span data-ttu-id="c1945-122">titleAssociations</span><span class="sxs-lookup"><span data-stu-id="c1945-122">titleAssociations</span></span>| <span data-ttu-id="c1945-123">配列[TitleAssociation](json-titleassociation.md)</span><span class="sxs-lookup"><span data-stu-id="c1945-123">array of [TitleAssociation](json-titleassociation.md)</span></span>| <span data-ttu-id="c1945-124">TitleAssociation の配列。</span><span class="sxs-lookup"><span data-stu-id="c1945-124">An array of TitleAssociation.</span></span>|
| <span data-ttu-id="c1945-125">progressState</span><span class="sxs-lookup"><span data-stu-id="c1945-125">progressState</span></span>| <span data-ttu-id="c1945-126">**ProgressState**列挙型</span><span class="sxs-lookup"><span data-stu-id="c1945-126">**ProgressState** enumeration</span></span>| <span data-ttu-id="c1945-127">進行状況の状態。</span><span class="sxs-lookup"><span data-stu-id="c1945-127">The state of progression:</span></span> <ul><li><span data-ttu-id="c1945-128">(0) が無効です。アチーブメントの進行状況は、不明な状態です。</span><span class="sxs-lookup"><span data-stu-id="c1945-128">invalid (0): The achievement progression is in an unknown state.</span></span></li><li><span data-ttu-id="c1945-129">(1) を実現するには。アチーブメントのロックが解除されました。</span><span class="sxs-lookup"><span data-stu-id="c1945-129">achieved (1): The achievement has been unlocked.</span></span></li><li><span data-ttu-id="c1945-130">処理中 (2):実績はロックされていますが、ロックの解除に向けた進行状況をユーザーが行ったします。</span><span class="sxs-lookup"><span data-stu-id="c1945-130">inProgress (2): The achievement is locked but the user has made progress toward unlocking it.</span></span></li><li><span data-ttu-id="c1945-131">notStarted (3):実績がロックされているし、ユーザーがロックの解除進行を行っていません。</span><span class="sxs-lookup"><span data-stu-id="c1945-131">notStarted (3): The achievement is locked and the user has not made any progress toward unlocking it.</span></span></li></ul> | 
| <span data-ttu-id="c1945-132">進行状況</span><span class="sxs-lookup"><span data-stu-id="c1945-132">progression</span></span>| [<span data-ttu-id="c1945-133">進行状況</span><span class="sxs-lookup"><span data-stu-id="c1945-133">Progression</span></span>](json-progression.md)| <span data-ttu-id="c1945-134">アチーブメント内で、ユーザーの進行状況。</span><span class="sxs-lookup"><span data-stu-id="c1945-134">The user's progression within the achievement.</span></span>|
| <span data-ttu-id="c1945-135">mediaAssets</span><span class="sxs-lookup"><span data-stu-id="c1945-135">mediaAssets</span></span>| <span data-ttu-id="c1945-136">配列[MediaAsset](json-mediaasset.md)</span><span class="sxs-lookup"><span data-stu-id="c1945-136">array of [MediaAsset](json-mediaasset.md)</span></span>| <span data-ttu-id="c1945-137">イメージ Id など、実績に関連付けられているメディア資産。</span><span class="sxs-lookup"><span data-stu-id="c1945-137">The media assets associated with the achievement, such as image IDs.</span></span> |
| <span data-ttu-id="c1945-138">プラットフォーム</span><span class="sxs-lookup"><span data-stu-id="c1945-138">platform</span></span>| <span data-ttu-id="c1945-139">string</span><span class="sxs-lookup"><span data-stu-id="c1945-139">string</span></span>| <span data-ttu-id="c1945-140">プラットフォームの実績を獲得します。</span><span class="sxs-lookup"><span data-stu-id="c1945-140">The platform the achievement was earned on.</span></span>|
| <span data-ttu-id="c1945-141">isSecret</span><span class="sxs-lookup"><span data-stu-id="c1945-141">isSecret</span></span>| <span data-ttu-id="c1945-142">ブール値</span><span class="sxs-lookup"><span data-stu-id="c1945-142">Boolean value</span></span>| <span data-ttu-id="c1945-143">実績がシークレットかどうか。</span><span class="sxs-lookup"><span data-stu-id="c1945-143">Whether or not the achievement is secret.</span></span>|
| <span data-ttu-id="c1945-144">説明</span><span class="sxs-lookup"><span data-stu-id="c1945-144">description</span></span>| <span data-ttu-id="c1945-145">string</span><span class="sxs-lookup"><span data-stu-id="c1945-145">string</span></span>| <span data-ttu-id="c1945-146">ロック解除する場合は、実績の説明です。</span><span class="sxs-lookup"><span data-stu-id="c1945-146">The description of the achievement when unlocked.</span></span>|
| <span data-ttu-id="c1945-147">lockedDescription</span><span class="sxs-lookup"><span data-stu-id="c1945-147">lockedDescription</span></span>| <span data-ttu-id="c1945-148">string</span><span class="sxs-lookup"><span data-stu-id="c1945-148">string</span></span>| <span data-ttu-id="c1945-149">ロックが解除する前に、実績の説明です。</span><span class="sxs-lookup"><span data-stu-id="c1945-149">The description of the achievement before it is unlocked.</span></span>|
| <span data-ttu-id="c1945-150">productId</span><span class="sxs-lookup"><span data-stu-id="c1945-150">productId</span></span>| <span data-ttu-id="c1945-151">string</span><span class="sxs-lookup"><span data-stu-id="c1945-151">string</span></span>| <span data-ttu-id="c1945-152">ProductId 実績はと共にリリースされました。</span><span class="sxs-lookup"><span data-stu-id="c1945-152">The ProductId the achievement was released with.</span></span>|
| <span data-ttu-id="c1945-153">achievementType</span><span class="sxs-lookup"><span data-stu-id="c1945-153">achievementType</span></span>| <span data-ttu-id="c1945-154">**AchievementType**列挙型</span><span class="sxs-lookup"><span data-stu-id="c1945-154">**AchievementType** enumeration</span></span>| <span data-ttu-id="c1945-155">アチーブメントが獲得されました (いないと同じレガシ アチーブメントの前の型) の種類:</span><span class="sxs-lookup"><span data-stu-id="c1945-155">The type of achievement (not the same as the previous type on legacy achievements):</span></span> <ul><li><span data-ttu-id="c1945-156">(0) が無効です。不明なとサポート非対象のアチーブメント型の場合。</span><span class="sxs-lookup"><span data-stu-id="c1945-156">invalid (0): An unknown and unsupported achievement type.</span></span></li><li><span data-ttu-id="c1945-157">永続的な (1):終了日を持たず、任意の時点でロックできるを達成します。</span><span class="sxs-lookup"><span data-stu-id="c1945-157">persistent (1): An achievement that has no end-date and can be unlocked at any time.</span></span></li><li><span data-ttu-id="c1945-158">課題 (2):ない場合がロックされている特定の時間枠を持つ達成します。</span><span class="sxs-lookup"><span data-stu-id="c1945-158">challenge (2): An achievement that has a specific time window during which it can be unlocked.</span></span></li></ul> |
| <span data-ttu-id="c1945-159">participationType</span><span class="sxs-lookup"><span data-stu-id="c1945-159">participationType</span></span>| <span data-ttu-id="c1945-160">**ParticipationType**列挙型</span><span class="sxs-lookup"><span data-stu-id="c1945-160">**ParticipationType** enumeration</span></span>| <span data-ttu-id="c1945-161">アチーブメントの参加の種類。</span><span class="sxs-lookup"><span data-stu-id="c1945-161">The participation type for the achievement.</span></span> <span data-ttu-id="c1945-162">有効な値は、個人またはグループは。</span><span class="sxs-lookup"><span data-stu-id="c1945-162">Valid values are Individual or Group.</span></span>|
| <span data-ttu-id="c1945-163">Timewindow プロパティ</span><span class="sxs-lookup"><span data-stu-id="c1945-163">timeWindow</span></span>| <span data-ttu-id="c1945-164">Timewindow プロパティ</span><span class="sxs-lookup"><span data-stu-id="c1945-164">TimeWindow</span></span>| <span data-ttu-id="c1945-165">達成できない可能性がありますロックされた時間枠。</span><span class="sxs-lookup"><span data-stu-id="c1945-165">The time window during which the achievement may be unlocked.</span></span> <span data-ttu-id="c1945-166">課題のみサポートされます。</span><span class="sxs-lookup"><span data-stu-id="c1945-166">Only supported for Challenges.</span></span>|
| <span data-ttu-id="c1945-167">報酬</span><span class="sxs-lookup"><span data-stu-id="c1945-167">rewards</span></span>| <span data-ttu-id="c1945-168">配列の[報酬](json-reward.md)</span><span class="sxs-lookup"><span data-stu-id="c1945-168">array of [Reward](json-reward.md)</span></span>| <span data-ttu-id="c1945-169">ロック解除する場合に達成報酬のコレクション。</span><span class="sxs-lookup"><span data-stu-id="c1945-169">The collection of rewards earned when unlocked.</span></span>|
| <span data-ttu-id="c1945-170">EstimatedTime</span><span class="sxs-lookup"><span data-stu-id="c1945-170">estimatedTime</span></span>| <span data-ttu-id="c1945-171">TimeSpan</span><span class="sxs-lookup"><span data-stu-id="c1945-171">TimeSpan</span></span>| <span data-ttu-id="c1945-172">推定所要時間を獲得する実績になります。</span><span class="sxs-lookup"><span data-stu-id="c1945-172">The estimated time the achievement will take to earn.</span></span>|
| <span data-ttu-id="c1945-173">ディープ リンク</span><span class="sxs-lookup"><span data-stu-id="c1945-173">deeplink</span></span>| <span data-ttu-id="c1945-174">string</span><span class="sxs-lookup"><span data-stu-id="c1945-174">string</span></span>| <span data-ttu-id="c1945-175">タイトルにディープ リンク。</span><span class="sxs-lookup"><span data-stu-id="c1945-175">A deeplink into the title.</span></span>|
| <span data-ttu-id="c1945-176">isRevoked</span><span class="sxs-lookup"><span data-stu-id="c1945-176">isRevoked</span></span>| <span data-ttu-id="c1945-177">ブール値</span><span class="sxs-lookup"><span data-stu-id="c1945-177">Boolean value</span></span>| <span data-ttu-id="c1945-178">かどうか実績は、強制では失効します。</span><span class="sxs-lookup"><span data-stu-id="c1945-178">Whether or not the achievement is revoked by enforcement.</span></span>|

<a id="ID4EIAAC"></a>


## <a name="sample-json-syntax"></a><span data-ttu-id="c1945-179">サンプルの JSON の構文</span><span class="sxs-lookup"><span data-stu-id="c1945-179">Sample JSON syntax</span></span>


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
                "url":"https://www.xbox.com"
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


## <a name="see-also"></a><span data-ttu-id="c1945-180">関連項目</span><span class="sxs-lookup"><span data-stu-id="c1945-180">See also</span></span>

<a id="ID4ETAAC"></a>


##### <a name="parent"></a><span data-ttu-id="c1945-181">Parent</span><span class="sxs-lookup"><span data-stu-id="c1945-181">Parent</span></span>

[<span data-ttu-id="c1945-182">JavaScript Object Notation (JSON) オブジェクトの参照</span><span class="sxs-lookup"><span data-stu-id="c1945-182">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)
