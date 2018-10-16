---
title: リッチ プレゼンスの文字列の更新
author: KevinAsgari
description: Xbox Live のリッチ プレゼンス文字列を更新する方法について説明します。
ms.assetid: eb2bb82e-8730-4d74-9b33-95d133360e44
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one, リッチ プレゼンス
ms.localizationpriority: medium
ms.openlocfilehash: 9e43cacf9a3fcaedd3829a690441dd28be935339
ms.sourcegitcommit: 9354909f9351b9635bee9bb2dc62db60d2d70107
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/16/2018
ms.locfileid: "4683772"
---
# <a name="rich-presence-updating-strings"></a><span data-ttu-id="7420a-104">リッチ プレゼンスの文字列の更新</span><span class="sxs-lookup"><span data-stu-id="7420a-104">Rich Presence updating strings</span></span>

<span data-ttu-id="7420a-105">タイトルでリッチ プレゼンス文字列を更新するために、JSON オブジェクトで適切なパラメーターを指定して Write Title URI を呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="7420a-105">To update the Rich Presence string in your title, you can call the Write Title URI with the appropriate parameters in a JSON object.</span></span> <span data-ttu-id="7420a-106">この RESTful 呼び出しは Xbox Service API によってもラップされます。</span><span class="sxs-lookup"><span data-stu-id="7420a-106">This restful call is also wrapped by Xbox Service APIs.</span></span> <span data-ttu-id="7420a-107">関連する API については「**Microsoft.Xbox.Services.Presence 名前空間**」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="7420a-107">See **Microsoft.Xbox.Services.Presence Namespace** for information on the related API.</span></span>

<span data-ttu-id="7420a-108">URI は次のように表示されます。</span><span class="sxs-lookup"><span data-stu-id="7420a-108">The URI looks like this:</span></span>

          POST /users/xuid({xuid})/devices/current/titles/current

<span data-ttu-id="7420a-109">以下では、リッチ プレゼンス文字列を設定するためのフィールドのみを示しています。</span><span class="sxs-lookup"><span data-stu-id="7420a-109">Below are only the fields for setting Rich Presence strings.</span></span> <span data-ttu-id="7420a-110">ここに示されていない、タイトルのプレゼンスの記述に関連するその他のオプションのフィールドもあります。</span><span class="sxs-lookup"><span data-stu-id="7420a-110">There are other optional fields related to the writing presence for a title not listed here.</span></span>

## <a name="titlerequest-object"></a><span data-ttu-id="7420a-111">TitleRequest オブジェクト</span><span class="sxs-lookup"><span data-stu-id="7420a-111">TitleRequest Object</span></span>

<span data-ttu-id="7420a-112">プロパティ</span><span class="sxs-lookup"><span data-stu-id="7420a-112">Property</span></span> | <span data-ttu-id="7420a-113">種類</span><span class="sxs-lookup"><span data-stu-id="7420a-113">Type</span></span> | <span data-ttu-id="7420a-114">必須</span><span class="sxs-lookup"><span data-stu-id="7420a-114">Req'd</span></span> | <span data-ttu-id="7420a-115">説明</span><span class="sxs-lookup"><span data-stu-id="7420a-115">Description</span></span>
---|---|---|---
<span data-ttu-id="7420a-116">Activity</span><span class="sxs-lookup"><span data-stu-id="7420a-116">Activity</span></span>|<span data-ttu-id="7420a-117">ActivityRequest</span><span class="sxs-lookup"><span data-stu-id="7420a-117">ActivityRequest</span></span>|<span data-ttu-id="7420a-118">N</span><span class="sxs-lookup"><span data-stu-id="7420a-118">N</span></span>|<span data-ttu-id="7420a-119">タイトル内情報 (リッチ プレゼンスおよびメディア情報 (使用可能な場合)) を記述するレコード</span><span class="sxs-lookup"><span data-stu-id="7420a-119">Record that describes in-title information (Rich Presence and media info, if available)</span></span>

## <a name="activityrequest-object"></a><span data-ttu-id="7420a-120">ActivityRequest オブジェクト</span><span class="sxs-lookup"><span data-stu-id="7420a-120">ActivityRequest Object</span></span>

<span data-ttu-id="7420a-121">プロパティ</span><span class="sxs-lookup"><span data-stu-id="7420a-121">Property</span></span> | <span data-ttu-id="7420a-122">種類</span><span class="sxs-lookup"><span data-stu-id="7420a-122">Type</span></span> | <span data-ttu-id="7420a-123">必須</span><span class="sxs-lookup"><span data-stu-id="7420a-123">Req'd</span></span> | <span data-ttu-id="7420a-124">説明</span><span class="sxs-lookup"><span data-stu-id="7420a-124">Description</span></span>
---|---|---|---
<span data-ttu-id="7420a-125">richPresence</span><span class="sxs-lookup"><span data-stu-id="7420a-125">richPresence</span></span>|<span data-ttu-id="7420a-126">RichPresenceRequest</span><span class="sxs-lookup"><span data-stu-id="7420a-126">RichPresenceRequest</span></span>|<span data-ttu-id="7420a-127">N</span><span class="sxs-lookup"><span data-stu-id="7420a-127">N</span></span>|<span data-ttu-id="7420a-128">使用するリッチ プレゼンス文字列のフレンドリ名。</span><span class="sxs-lookup"><span data-stu-id="7420a-128">The friendlyName of the Rich Presence string that should be used.</span></span>

## <a name="richpresencerequest-object"></a><span data-ttu-id="7420a-129">RichPresenceRequest オブジェクト</span><span class="sxs-lookup"><span data-stu-id="7420a-129">RichPresenceRequest Object</span></span>

<span data-ttu-id="7420a-130">プロパティ</span><span class="sxs-lookup"><span data-stu-id="7420a-130">Property</span></span> | <span data-ttu-id="7420a-131">種類</span><span class="sxs-lookup"><span data-stu-id="7420a-131">Type</span></span> | <span data-ttu-id="7420a-132">必須</span><span class="sxs-lookup"><span data-stu-id="7420a-132">Req'd</span></span> | <span data-ttu-id="7420a-133">説明</span><span class="sxs-lookup"><span data-stu-id="7420a-133">Description</span></span>
---|---|---|---
<span data-ttu-id="7420a-134">ID</span><span class="sxs-lookup"><span data-stu-id="7420a-134">Id</span></span>|<span data-ttu-id="7420a-135">String</span><span class="sxs-lookup"><span data-stu-id="7420a-135">String</span></span>|<span data-ttu-id="7420a-136">Y</span><span class="sxs-lookup"><span data-stu-id="7420a-136">Y</span></span>|<span data-ttu-id="7420a-137">使用するリッチ プレゼンス文字列のフレンドリ名</span><span class="sxs-lookup"><span data-stu-id="7420a-137">The friendlyName of the Rich Presence string that should be used</span></span>
<span data-ttu-id="7420a-138">Scid</span><span class="sxs-lookup"><span data-stu-id="7420a-138">Scid</span></span>|<span data-ttu-id="7420a-139">String</span><span class="sxs-lookup"><span data-stu-id="7420a-139">String</span></span>|<span data-ttu-id="7420a-140">Y</span><span class="sxs-lookup"><span data-stu-id="7420a-140">Y</span></span>|<span data-ttu-id="7420a-141">リッチ プレゼンス文字列が定義されている場所を示す scid</span><span class="sxs-lookup"><span data-stu-id="7420a-141">Scid that tells us where the Rich Presence strings are defined.</span></span>

<span data-ttu-id="7420a-142">たとえば、xuid が 12345 のユーザーのリッチ プレゼンスを更新する場合、呼び出しは次のようになります。</span><span class="sxs-lookup"><span data-stu-id="7420a-142">For example, if I wanted to update the Rich Presence for user whose xuid is 12345, my call would look as follows:</span></span>

          POST /users/xuid(12345)/devices/current/titles/current


<span data-ttu-id="7420a-143">次のような JSON 本文があるものとします。</span><span class="sxs-lookup"><span data-stu-id="7420a-143">With the following JSON body:</span></span>

```json
          {
            activity:
            {
              richPresence:
              {
                id:"playingMap",
                scid:"0000-0000-0000-0000-01010101"
              }
            }
          }
```

<span data-ttu-id="7420a-144">ラッパー API を使用することで、これは **PresenceService.SetPresenceAsync メソッド**の呼び出しになります。</span><span class="sxs-lookup"><span data-stu-id="7420a-144">Using the wrapper API, this would be a call to **PresenceService.SetPresenceAsync Method**</span></span>

<span data-ttu-id="7420a-145">データ プラットフォームを最新の状態に維持している場合、空白に入力されるデータが変更されるたびにリッチ プレゼンス文字列をリセットする必要はありません。</span><span class="sxs-lookup"><span data-stu-id="7420a-145">If you're keeping the data platform up-to-date, then you don't have to reset the Rich Presence String every time the data to fill in the blank changes.</span></span> <span data-ttu-id="7420a-146">上記の例では、現在のマップを使用することがわかっています。</span><span class="sxs-lookup"><span data-stu-id="7420a-146">In the example above we know that you want to use the current map.</span></span> <span data-ttu-id="7420a-147">ユーザーが文字列を読み取ろうとしたときに、プレゼンスがデータ プラットフォームのデータをルックアップして、現在の値を入力します。</span><span class="sxs-lookup"><span data-stu-id="7420a-147">Presence will look up the data in the data platform when a user tries to read the string to fill in the current value.</span></span> <span data-ttu-id="7420a-148">そのため、プレイヤーがマップを切り替えた場合でも、適切なイベントをデータ プラットフォームに送信している限り、ゲームのリッチ プレゼンス文字列をリセットする必要はありません。</span><span class="sxs-lookup"><span data-stu-id="7420a-148">So even if the player is switching from map to map to map, you don't have to reset the Rich Presence string in your game as long as you're sending the appropriate events to the data platform.</span></span> <span data-ttu-id="7420a-149">データがデータ プラットフォームに送信されるまで数秒かかる場合がある点に留意してください。</span><span class="sxs-lookup"><span data-stu-id="7420a-149">Keep in mind that it may take a few seconds for the data to find its way through the Data Platform.</span></span>

<span data-ttu-id="7420a-150">そして、だれかがユーザー 12345 のリッチ プレゼンスを読み取ろうとすると、サービスが、どのロケールが要求されているかを調べ、文字列を返す前に適切な書式を設定します。</span><span class="sxs-lookup"><span data-stu-id="7420a-150">Then, when someone attempts to read user 12345's Rich Presence, the service will look at what locale is being requested and format the string appropriately before returning.</span></span>

<span data-ttu-id="7420a-151">ここでは、ユーザーが en-US の文字列を読み取ろうとしているものとします。</span><span class="sxs-lookup"><span data-stu-id="7420a-151">In this case, let's say that a user wants to read the en-US string.</span></span> <span data-ttu-id="7420a-152">リッチ プレゼンスの読み取りは次のようになります (この呼び出しの詳細については、「**GET (/users/xuid({xuid}))**」を参照してください)。</span><span class="sxs-lookup"><span data-stu-id="7420a-152">Reading rich presence would work as follows (for more information about this call, see **GET (/users/xuid({xuid}))**</span></span>

          GET /users/xuid(12345)?level=all

<span data-ttu-id="7420a-153">これのラッパー API は **PresenceService.GetPresenceAsync メソッド**です。</span><span class="sxs-lookup"><span data-stu-id="7420a-153">The wrapper API for this is **PresenceService.GetPresenceAsync Method**</span></span>

<span data-ttu-id="7420a-154">ここでは、xuid が 12345 である、ユーザーの PresenceRecord を要求しています。</span><span class="sxs-lookup"><span data-stu-id="7420a-154">What's happening here is that you're asking for the PresenceRecord of the user, whose xuid is 12345.</span></span> <span data-ttu-id="7420a-155">さらにその詳細レベルを "all" にすることを要求しています。</span><span class="sxs-lookup"><span data-stu-id="7420a-155">And you're requesting that the level of detail be "all".</span></span> <span data-ttu-id="7420a-156">"all" が指定されなかった場合、リッチ プレゼンスは返されません。</span><span class="sxs-lookup"><span data-stu-id="7420a-156">If "all" wasn't specified, Rich Presence would not be returned.</span></span>

<span data-ttu-id="7420a-157">JSON 応答で以下が返されます。</span><span class="sxs-lookup"><span data-stu-id="7420a-157">And it would return the following in the JSON response:</span></span>

```json
          {
            xuid:"12345",
            state:"online",
            devices:
            [
              {
                type:"D",
                titles:
                [
                  {
                    id:"12345",
                    name:"Buckets are Awesome",
                    lastModified:"2012-09-17T07:15:23.4930000",
                    placement: "full",
                    state:"active",
                    activity:
                    {
                      richPresence:"Playing on map:Mountains"
                    }
                  }
                ]
              }
            ]
          }
```
