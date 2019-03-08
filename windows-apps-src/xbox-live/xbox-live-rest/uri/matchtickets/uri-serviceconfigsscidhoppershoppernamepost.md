---
title: POST (/serviceconfigs/{scid}/hoppers/{hoppername})
assetID: 8cbf62aa-d639-e920-1e39-099133af17f8
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidhoppershoppernamepost.html
description: " POST (/serviceconfigs/{scid}/hoppers/{hoppername})"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 7682b92ec61c98679904825e360d73318e9fee90
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57659837"
---
# <a name="post-serviceconfigsscidhoppershoppername"></a><span data-ttu-id="7abfb-104">POST (/serviceconfigs/{scid}/hoppers/{hoppername})</span><span class="sxs-lookup"><span data-stu-id="7abfb-104">POST (/serviceconfigs/{scid}/hoppers/{hoppername})</span></span>

<span data-ttu-id="7abfb-105">指定した一致のチケットを作成します。</span><span class="sxs-lookup"><span data-stu-id="7abfb-105">Creates the specified match ticket.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="7abfb-106">このメソッドは、コントラクト 103 以降で使用するためのものがし、X Xbl コントラクト バージョンのヘッダー要素が必要です。要求ごとに 103 で以降。</span><span class="sxs-lookup"><span data-stu-id="7abfb-106">This method is intended for use with contract 103 or later, and requires a header element of X-Xbl-Contract-Version: 103 or later on every request.</span></span>

  * [<span data-ttu-id="7abfb-107">注釈</span><span class="sxs-lookup"><span data-stu-id="7abfb-107">Remarks</span></span>](#ID4ET)
  * [<span data-ttu-id="7abfb-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="7abfb-108">URI parameters</span></span>](#ID4E5)
  * [<span data-ttu-id="7abfb-109">承認</span><span class="sxs-lookup"><span data-stu-id="7abfb-109">Authorization</span></span>](#ID4EJB)
  * [<span data-ttu-id="7abfb-110">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="7abfb-110">HTTP status codes</span></span>](#ID4E3C)
  * [<span data-ttu-id="7abfb-111">要求本文</span><span class="sxs-lookup"><span data-stu-id="7abfb-111">Request body</span></span>](#ID4EFD)
  * [<span data-ttu-id="7abfb-112">応答本文</span><span class="sxs-lookup"><span data-stu-id="7abfb-112">Response body</span></span>](#ID4E3G)

<a id="ID4ET"></a>


## <a name="remarks"></a><span data-ttu-id="7abfb-113">注釈</span><span class="sxs-lookup"><span data-stu-id="7abfb-113">Remarks</span></span>

<span data-ttu-id="7abfb-114">この HTTP/REST メソッドでは、サービス構成の ID (SCID) レベルで特定の名前を hopper の一致のチケットを作成します。</span><span class="sxs-lookup"><span data-stu-id="7abfb-114">This HTTP/REST method creates a match ticket for a hopper with a particular name at the service configuration ID (SCID) level.</span></span> <span data-ttu-id="7abfb-115">このメソッドをラップすることができます、 **Microsoft.Xbox.Services.Matchmaking.MatchmakingService.CreateMatchTicketAsync**メソッド。</span><span class="sxs-lookup"><span data-stu-id="7abfb-115">This method can be wrapped by the **Microsoft.Xbox.Services.Matchmaking.MatchmakingService.CreateMatchTicketAsync** method.</span></span>  
<a id="ID4E5"></a>


## <a name="uri-parameters"></a><span data-ttu-id="7abfb-116">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="7abfb-116">URI parameters</span></span>

| <span data-ttu-id="7abfb-117">パラメーター</span><span class="sxs-lookup"><span data-stu-id="7abfb-117">Parameter</span></span>| <span data-ttu-id="7abfb-118">種類</span><span class="sxs-lookup"><span data-stu-id="7abfb-118">Type</span></span>| <span data-ttu-id="7abfb-119">説明</span><span class="sxs-lookup"><span data-stu-id="7abfb-119">Description</span></span>|
| --- | --- | --- | --- |
| <span data-ttu-id="7abfb-120">scid</span><span class="sxs-lookup"><span data-stu-id="7abfb-120">scid</span></span>| <span data-ttu-id="7abfb-121">GUID</span><span class="sxs-lookup"><span data-stu-id="7abfb-121">GUID</span></span>| <span data-ttu-id="7abfb-122">セッションのサービス構成識別子 (SCID)。</span><span class="sxs-lookup"><span data-stu-id="7abfb-122">The service configuration identifier (SCID) for the session.</span></span>|
| <span data-ttu-id="7abfb-123">hoppername</span><span class="sxs-lookup"><span data-stu-id="7abfb-123">hoppername</span></span> | <span data-ttu-id="7abfb-124">string</span><span class="sxs-lookup"><span data-stu-id="7abfb-124">string</span></span> | <span data-ttu-id="7abfb-125">Hopper の名前。</span><span class="sxs-lookup"><span data-stu-id="7abfb-125">The name of the hopper.</span></span> |

<a id="ID4EJB"></a>


## <a name="authorization"></a><span data-ttu-id="7abfb-126">Authorization</span><span class="sxs-lookup"><span data-stu-id="7abfb-126">Authorization</span></span>

| <span data-ttu-id="7abfb-127">種類</span><span class="sxs-lookup"><span data-stu-id="7abfb-127">Type</span></span>| <span data-ttu-id="7abfb-128">必須</span><span class="sxs-lookup"><span data-stu-id="7abfb-128">Required</span></span>| <span data-ttu-id="7abfb-129">説明</span><span class="sxs-lookup"><span data-stu-id="7abfb-129">Description</span></span>| <span data-ttu-id="7abfb-130">不足している場合の応答</span><span class="sxs-lookup"><span data-stu-id="7abfb-130">Response if missing</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="7abfb-131">特権とデバイスの種類</span><span class="sxs-lookup"><span data-stu-id="7abfb-131">Privileges and Device Type</span></span>| <span data-ttu-id="7abfb-132">○</span><span class="sxs-lookup"><span data-stu-id="7abfb-132">yes</span></span>| <span data-ttu-id="7abfb-133">ユーザーの deviceType は、コンソールに設定されている場合は、それぞれのクレームでマルチ プレーヤーの特権を持つユーザーのみがマッチメイ キング サービスを呼び出すことが許可されます。</span><span class="sxs-lookup"><span data-stu-id="7abfb-133">When the user's deviceType is set to console, only users with the multiplayer privilege in their claims are allowed to make calls to the matchmaking service.</span></span> | <span data-ttu-id="7abfb-134">403</span><span class="sxs-lookup"><span data-stu-id="7abfb-134">403</span></span>|
| <span data-ttu-id="7abfb-135">デバイスの種類</span><span class="sxs-lookup"><span data-stu-id="7abfb-135">Device Type</span></span>| <span data-ttu-id="7abfb-136">○</span><span class="sxs-lookup"><span data-stu-id="7abfb-136">yes</span></span>| <span data-ttu-id="7abfb-137">ときに、ユーザーの deviceType が存在しないまたはコンソール以外でに一致するタイトルに設定するには、コンソールのみのタイトルがすることはできません。</span><span class="sxs-lookup"><span data-stu-id="7abfb-137">When the user's deviceType is absent or set to non-console, the title being matched into must not be a console-only title.</span></span> | <span data-ttu-id="7abfb-138">403</span><span class="sxs-lookup"><span data-stu-id="7abfb-138">403</span></span>|
| <span data-ttu-id="7abfb-139">タイトルの購入/デバイスの種類 ID/実証</span><span class="sxs-lookup"><span data-stu-id="7abfb-139">Title ID/Proof of Purchase/Device Type</span></span>| <span data-ttu-id="7abfb-140">○</span><span class="sxs-lookup"><span data-stu-id="7abfb-140">yes</span></span>| <span data-ttu-id="7abfb-141">一致するタイトルは、指定されたタイトルの要求、デバイスの種類の組み合わせのマッチメイ キングを許可する必要があります。</span><span class="sxs-lookup"><span data-stu-id="7abfb-141">The title that is being matched into must allow matchmaking for the specified title claim, device type combination.</span></span> | <span data-ttu-id="7abfb-142">403</span><span class="sxs-lookup"><span data-stu-id="7abfb-142">403</span></span>|

<a id="ID4E3C"></a>


## <a name="http-status-codes"></a><span data-ttu-id="7abfb-143">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="7abfb-143">HTTP status codes</span></span>
<span data-ttu-id="7abfb-144">MPSD に適用される、サービスは、HTTP 状態コードを返します。</span><span class="sxs-lookup"><span data-stu-id="7abfb-144">The service returns an HTTP status code as it applies to MPSD.</span></span>  
<a id="ID4EFD"></a>


## <a name="request-body"></a><span data-ttu-id="7abfb-145">要求本文</span><span class="sxs-lookup"><span data-stu-id="7abfb-145">Request body</span></span>

<a id="ID4ELD"></a>


### <a name="required-members"></a><span data-ttu-id="7abfb-146">必須メンバー</span><span class="sxs-lookup"><span data-stu-id="7abfb-146">Required members</span></span>

| <span data-ttu-id="7abfb-147">メンバー</span><span class="sxs-lookup"><span data-stu-id="7abfb-147">Member</span></span>| <span data-ttu-id="7abfb-148">種類</span><span class="sxs-lookup"><span data-stu-id="7abfb-148">Type</span></span>| <span data-ttu-id="7abfb-149">説明</span><span class="sxs-lookup"><span data-stu-id="7abfb-149">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="7abfb-150">serviceConfig</span><span class="sxs-lookup"><span data-stu-id="7abfb-150">serviceConfig</span></span>| <span data-ttu-id="7abfb-151">GUID</span><span class="sxs-lookup"><span data-stu-id="7abfb-151">GUID</span></span>| <span data-ttu-id="7abfb-152">セッションの SCID します。</span><span class="sxs-lookup"><span data-stu-id="7abfb-152">SCID for the session.</span></span>|
| <span data-ttu-id="7abfb-153">hopperName</span><span class="sxs-lookup"><span data-stu-id="7abfb-153">hopperName</span></span>| <span data-ttu-id="7abfb-154">string</span><span class="sxs-lookup"><span data-stu-id="7abfb-154">string</span></span>| <span data-ttu-id="7abfb-155">Hopper の名前です。</span><span class="sxs-lookup"><span data-stu-id="7abfb-155">Name of the hopper.</span></span>|
| <span data-ttu-id="7abfb-156">giveUpDuration</span><span class="sxs-lookup"><span data-stu-id="7abfb-156">giveUpDuration</span></span>| <span data-ttu-id="7abfb-157">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="7abfb-157">32-bit signed integer</span></span>| <span data-ttu-id="7abfb-158">最大待機時間 (秒単位の整数)。</span><span class="sxs-lookup"><span data-stu-id="7abfb-158">Maximum wait time (integral number of seconds).</span></span>|
| <span data-ttu-id="7abfb-159">preserveSession</span><span class="sxs-lookup"><span data-stu-id="7abfb-159">preserveSession</span></span>| <span data-ttu-id="7abfb-160">列挙</span><span class="sxs-lookup"><span data-stu-id="7abfb-160">enumeration</span></span>| <span data-ttu-id="7abfb-161">かどうかに一致するセッションとセッションは再利用を示す値。</span><span class="sxs-lookup"><span data-stu-id="7abfb-161">A value indicating if the session is reused as the session into which to match.</span></span> <span data-ttu-id="7abfb-162">指定できる値は、"never"と「常に」です。</span><span class="sxs-lookup"><span data-stu-id="7abfb-162">Possible values are "always" and "never".</span></span> |
| <span data-ttu-id="7abfb-163">ticketSessionRef</span><span class="sxs-lookup"><span data-stu-id="7abfb-163">ticketSessionRef</span></span>| <span data-ttu-id="7abfb-164">MultiplayerSessionReference</span><span class="sxs-lookup"><span data-stu-id="7abfb-164">MultiplayerSessionReference</span></span>| <span data-ttu-id="7abfb-165">プレーヤーまたはグループが現在を再生中のセッションの MultiplayerSessionReference オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="7abfb-165">The MultiplayerSessionReference object for the session in which the player or group is currently playing.</span></span> |
| <span data-ttu-id="7abfb-166">ticketAttributes</span><span class="sxs-lookup"><span data-stu-id="7abfb-166">ticketAttributes</span></span>| <span data-ttu-id="7abfb-167">オブジェクトのコレクション</span><span class="sxs-lookup"><span data-stu-id="7abfb-167">collection of objects</span></span>| <span data-ttu-id="7abfb-168">属性とプレイヤーのグループについて、ユーザーによって提供される値。</span><span class="sxs-lookup"><span data-stu-id="7abfb-168">Attributes and values provided by the user about the group of players.</span></span>|

<a id="ID4EXF"></a>


### <a name="prohibited-members"></a><span data-ttu-id="7abfb-169">禁止されているメンバー</span><span class="sxs-lookup"><span data-stu-id="7abfb-169">Prohibited members</span></span>

<span data-ttu-id="7abfb-170">要求では、その他のすべてのメンバーが禁止されています。</span><span class="sxs-lookup"><span data-stu-id="7abfb-170">All other members are prohibited in a request.</span></span>

<a id="ID4ECG"></a>


### <a name="sample-request"></a><span data-ttu-id="7abfb-171">要求のサンプル</span><span class="sxs-lookup"><span data-stu-id="7abfb-171">Sample request</span></span>

<span data-ttu-id="7abfb-172">によって参照される、セッション、 **ticketSessionRef**一致チケットを作成して、セッションは、プレーヤーに固有の属性と、一致するプレーヤーを含める必要があります前に、オブジェクトを作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="7abfb-172">The session referred to by the **ticketSessionRef** object must be created before a match ticket can be created, and the session must contain the players to be matched, along with their player-specific attributes.</span></span> <span data-ttu-id="7abfb-173">各プレーヤーは、作成またはセッションに関連する一致属性を追加、MPSD に対してセッションに参加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="7abfb-173">Each player must create or join the session against the MPSD, adding associated match attributes to the session.</span></span> <span data-ttu-id="7abfb-174">一致する属性は、各プレーヤーの matchAttrs をという名前のカスタム プロパティ フィールドに配置されます。</span><span class="sxs-lookup"><span data-stu-id="7abfb-174">The match attributes are placed in a custom property field called matchAttrs on each player.</span></span>

<span data-ttu-id="7abfb-175">作成または参加要求が送信される**https://sessiondirectory.xboxlive.com/serviceconfigs/{scid}/sessiontemplates/{templatename}/sessions/{sessionname}** し、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="7abfb-175">A create or join request is submitted to **https://sessiondirectory.xboxlive.com/serviceconfigs/{scid}/sessiontemplates/{templatename}/sessions/{sessionname}** and might look like this:</span></span>


```cpp
{
   "members": {
     "me": {
       "constants": {
         "system": {
           "xuid": 2535285330879750
         }
      },
      "properties": {
         "custom": {
           "matchAttrs": {
             "skill": 5,
             "ageRange": "teenager"
           }
         }
      }
    }
  }
}

```


<span data-ttu-id="7abfb-176">セッションが作成されたら、タイトルは、そのセッションのチケットを作成するマッチメイ キング サービスを呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="7abfb-176">Once the session has been created, the title can call the matchmaking service to create the ticket for that session.</span></span>


> [!NOTE] 
> <span data-ttu-id="7abfb-177">タイトルは、この呼び出しを再試行するユーザーを有効にできますが、再試行できませんに自動的にデータが失敗した場合。</span><span class="sxs-lookup"><span data-stu-id="7abfb-177">A title can enable a user to retry this call, but should not retry it automatically if the data fails.</span></span>  



```cpp
POST /serviceconfigs/{scid}/hoppers/{hoppername}

{
  "giveUpDuration":10,
  "preserveSession": "never",
  "ticketSessionRef": {
     "scid": "ABBACDDC-0000-0000-0000-000000000001",  
     "templateName": "TestTemplate",
     "name": "5E55104-0000-0000-0000-000000000001"
  },
  "ticketAttributes": {
    "desiredMap": "Test Map",
    "desiredGameType": "Test GameType"
  }
}

```


<a id="ID4E3G"></a>


## <a name="response-body"></a><span data-ttu-id="7abfb-178">応答本文</span><span class="sxs-lookup"><span data-stu-id="7abfb-178">Response body</span></span>

| <span data-ttu-id="7abfb-179">メンバー</span><span class="sxs-lookup"><span data-stu-id="7abfb-179">Member</span></span>| <span data-ttu-id="7abfb-180">説明</span><span class="sxs-lookup"><span data-stu-id="7abfb-180">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="7abfb-181">TicketId</span><span class="sxs-lookup"><span data-stu-id="7abfb-181">ticketId</span></span>| <span data-ttu-id="7abfb-182">GUID</span><span class="sxs-lookup"><span data-stu-id="7abfb-182">GUID</span></span>| <span data-ttu-id="7abfb-183">作成されるチケットの ID。</span><span class="sxs-lookup"><span data-stu-id="7abfb-183">The ID for the ticket being created.</span></span>|
| <span data-ttu-id="7abfb-184">待機時間</span><span class="sxs-lookup"><span data-stu-id="7abfb-184">waitTime</span></span>| <span data-ttu-id="7abfb-185">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="7abfb-185">32-bit signed integer</span></span>| <span data-ttu-id="7abfb-186">平均の待機時間 (秒単位の整数) hopper。</span><span class="sxs-lookup"><span data-stu-id="7abfb-186">The average wait time for the hopper (integral number of seconds).</span></span>|


```cpp
{
  "ticketId":"0584338f-a2ff-4eb9-b167-c0e8ddecae72",
  "waitTime":60
}

```


<a id="ID4EHAAC"></a>


## <a name="see-also"></a><span data-ttu-id="7abfb-187">関連項目</span><span class="sxs-lookup"><span data-stu-id="7abfb-187">See also</span></span>

<a id="ID4EJAAC"></a>


##### <a name="parent"></a><span data-ttu-id="7abfb-188">Parent</span><span class="sxs-lookup"><span data-stu-id="7abfb-188">Parent</span></span>  

[<span data-ttu-id="7abfb-189">/serviceconfigs/{scid}/hoppers/{hoppername}</span><span class="sxs-lookup"><span data-stu-id="7abfb-189">/serviceconfigs/{scid}/hoppers/{hoppername}</span></span>](uri-serviceconfigsscidhoppershoppername.md)
