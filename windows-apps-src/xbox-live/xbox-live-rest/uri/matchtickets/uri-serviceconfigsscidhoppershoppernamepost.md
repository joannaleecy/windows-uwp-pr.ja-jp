---
title: POST (/serviceconfigs/{scid}/hoppers/{hoppername})
assetID: 8cbf62aa-d639-e920-1e39-099133af17f8
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidhoppershoppernamepost.html
author: KevinAsgari
description: " POST (/serviceconfigs/{scid}/hoppers/{hoppername})"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 089aba60b80e629a8068bcf39f009ac97fc6ad66
ms.sourcegitcommit: 72835733ec429a5deb6a11da4112336746e5e9cf
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/21/2018
ms.locfileid: "5160446"
---
# <a name="post-serviceconfigsscidhoppershoppername"></a><span data-ttu-id="8b39a-104">POST (/serviceconfigs/{scid}/hoppers/{hoppername})</span><span class="sxs-lookup"><span data-stu-id="8b39a-104">POST (/serviceconfigs/{scid}/hoppers/{hoppername})</span></span>

<span data-ttu-id="8b39a-105">指定したマッチ チケットを作成します。</span><span class="sxs-lookup"><span data-stu-id="8b39a-105">Creates the specified match ticket.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="8b39a-106">このメソッドはコントラクト 103 以降で使用するものでは、X Xbl コントラクト バージョンのヘッダーの要素が必要です。 103 または後ですべての要求します。</span><span class="sxs-lookup"><span data-stu-id="8b39a-106">This method is intended for use with contract 103 or later, and requires a header element of X-Xbl-Contract-Version: 103 or later on every request.</span></span>

  * [<span data-ttu-id="8b39a-107">注釈</span><span class="sxs-lookup"><span data-stu-id="8b39a-107">Remarks</span></span>](#ID4ET)
  * [<span data-ttu-id="8b39a-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="8b39a-108">URI parameters</span></span>](#ID4E5)
  * [<span data-ttu-id="8b39a-109">Authorization</span><span class="sxs-lookup"><span data-stu-id="8b39a-109">Authorization</span></span>](#ID4EJB)
  * [<span data-ttu-id="8b39a-110">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="8b39a-110">HTTP status codes</span></span>](#ID4E3C)
  * [<span data-ttu-id="8b39a-111">要求本文</span><span class="sxs-lookup"><span data-stu-id="8b39a-111">Request body</span></span>](#ID4EFD)
  * [<span data-ttu-id="8b39a-112">応答本文</span><span class="sxs-lookup"><span data-stu-id="8b39a-112">Response body</span></span>](#ID4E3G)

<a id="ID4ET"></a>


## <a name="remarks"></a><span data-ttu-id="8b39a-113">注釈</span><span class="sxs-lookup"><span data-stu-id="8b39a-113">Remarks</span></span>

<span data-ttu-id="8b39a-114">この HTTP/REST メソッドでは、サービス構成 ID (SCID) レベルでの特定の名前をホッパーのマッチ チケットを作成します。</span><span class="sxs-lookup"><span data-stu-id="8b39a-114">This HTTP/REST method creates a match ticket for a hopper with a particular name at the service configuration ID (SCID) level.</span></span> <span data-ttu-id="8b39a-115">このメソッドは、 **Microsoft.Xbox.Services.Matchmaking.MatchmakingService.CreateMatchTicketAsync**メソッドでラップすることができます。</span><span class="sxs-lookup"><span data-stu-id="8b39a-115">This method can be wrapped by the **Microsoft.Xbox.Services.Matchmaking.MatchmakingService.CreateMatchTicketAsync** method.</span></span>  
<a id="ID4E5"></a>


## <a name="uri-parameters"></a><span data-ttu-id="8b39a-116">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="8b39a-116">URI parameters</span></span>

| <span data-ttu-id="8b39a-117">パラメーター</span><span class="sxs-lookup"><span data-stu-id="8b39a-117">Parameter</span></span>| <span data-ttu-id="8b39a-118">型</span><span class="sxs-lookup"><span data-stu-id="8b39a-118">Type</span></span>| <span data-ttu-id="8b39a-119">説明</span><span class="sxs-lookup"><span data-stu-id="8b39a-119">Description</span></span>|
| --- | --- | --- | --- |
| <span data-ttu-id="8b39a-120">scid</span><span class="sxs-lookup"><span data-stu-id="8b39a-120">scid</span></span>| <span data-ttu-id="8b39a-121">GUID</span><span class="sxs-lookup"><span data-stu-id="8b39a-121">GUID</span></span>| <span data-ttu-id="8b39a-122">セッションのサービス構成 id (SCID)。</span><span class="sxs-lookup"><span data-stu-id="8b39a-122">The service configuration identifier (SCID) for the session.</span></span>|
| <span data-ttu-id="8b39a-123">hoppername</span><span class="sxs-lookup"><span data-stu-id="8b39a-123">hoppername</span></span> | <span data-ttu-id="8b39a-124">string</span><span class="sxs-lookup"><span data-stu-id="8b39a-124">string</span></span> | <span data-ttu-id="8b39a-125">ホッパーの名前。</span><span class="sxs-lookup"><span data-stu-id="8b39a-125">The name of the hopper.</span></span> |

<a id="ID4EJB"></a>


## <a name="authorization"></a><span data-ttu-id="8b39a-126">Authorization</span><span class="sxs-lookup"><span data-stu-id="8b39a-126">Authorization</span></span>

| <span data-ttu-id="8b39a-127">型</span><span class="sxs-lookup"><span data-stu-id="8b39a-127">Type</span></span>| <span data-ttu-id="8b39a-128">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="8b39a-128">Required</span></span>| <span data-ttu-id="8b39a-129">説明</span><span class="sxs-lookup"><span data-stu-id="8b39a-129">Description</span></span>| <span data-ttu-id="8b39a-130">不足している場合、応答</span><span class="sxs-lookup"><span data-stu-id="8b39a-130">Response if missing</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="8b39a-131">特権とデバイスの種類</span><span class="sxs-lookup"><span data-stu-id="8b39a-131">Privileges and Device Type</span></span>| <span data-ttu-id="8b39a-132">必須</span><span class="sxs-lookup"><span data-stu-id="8b39a-132">yes</span></span>| <span data-ttu-id="8b39a-133">ユーザーの deviceType がコンソールに設定されている場合、マッチメイ キング サービスへの呼び出しは、要求のマルチプレイヤー権限を持つユーザーのみが許可されています。</span><span class="sxs-lookup"><span data-stu-id="8b39a-133">When the user's deviceType is set to console, only users with the multiplayer privilege in their claims are allowed to make calls to the matchmaking service.</span></span> | <span data-ttu-id="8b39a-134">403</span><span class="sxs-lookup"><span data-stu-id="8b39a-134">403</span></span>|
| <span data-ttu-id="8b39a-135">デバイスの種類</span><span class="sxs-lookup"><span data-stu-id="8b39a-135">Device Type</span></span>| <span data-ttu-id="8b39a-136">必須</span><span class="sxs-lookup"><span data-stu-id="8b39a-136">yes</span></span>| <span data-ttu-id="8b39a-137">とき、ユーザーの deviceType が存在しないか、以外のコンソールに一致するタイトルに設定するには、コンソール専用のタイトルする必要がありますできません。</span><span class="sxs-lookup"><span data-stu-id="8b39a-137">When the user's deviceType is absent or set to non-console, the title being matched into must not be a console-only title.</span></span> | <span data-ttu-id="8b39a-138">403</span><span class="sxs-lookup"><span data-stu-id="8b39a-138">403</span></span>|
| <span data-ttu-id="8b39a-139">タイトル ID/実証購入/デバイスの種類</span><span class="sxs-lookup"><span data-stu-id="8b39a-139">Title ID/Proof of Purchase/Device Type</span></span>| <span data-ttu-id="8b39a-140">必須</span><span class="sxs-lookup"><span data-stu-id="8b39a-140">yes</span></span>| <span data-ttu-id="8b39a-141">タイトルに一致するには、指定されたタイトルの要求、デバイスの種類の組み合わせのマッチメイ キングを許可する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8b39a-141">The title that is being matched into must allow matchmaking for the specified title claim, device type combination.</span></span> | <span data-ttu-id="8b39a-142">403</span><span class="sxs-lookup"><span data-stu-id="8b39a-142">403</span></span>|

<a id="ID4E3C"></a>


## <a name="http-status-codes"></a><span data-ttu-id="8b39a-143">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="8b39a-143">HTTP status codes</span></span>
<span data-ttu-id="8b39a-144">サービスは、MPSD に適用される、HTTP ステータス コードを返します。</span><span class="sxs-lookup"><span data-stu-id="8b39a-144">The service returns an HTTP status code as it applies to MPSD.</span></span>  
<a id="ID4EFD"></a>


## <a name="request-body"></a><span data-ttu-id="8b39a-145">要求本文</span><span class="sxs-lookup"><span data-stu-id="8b39a-145">Request body</span></span>

<a id="ID4ELD"></a>


### <a name="required-members"></a><span data-ttu-id="8b39a-146">必要なメンバー</span><span class="sxs-lookup"><span data-stu-id="8b39a-146">Required members</span></span>

| <span data-ttu-id="8b39a-147">メンバー</span><span class="sxs-lookup"><span data-stu-id="8b39a-147">Member</span></span>| <span data-ttu-id="8b39a-148">種類</span><span class="sxs-lookup"><span data-stu-id="8b39a-148">Type</span></span>| <span data-ttu-id="8b39a-149">説明</span><span class="sxs-lookup"><span data-stu-id="8b39a-149">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="8b39a-150">serviceConfig</span><span class="sxs-lookup"><span data-stu-id="8b39a-150">serviceConfig</span></span>| <span data-ttu-id="8b39a-151">GUID</span><span class="sxs-lookup"><span data-stu-id="8b39a-151">GUID</span></span>| <span data-ttu-id="8b39a-152">セッションの SCID です。</span><span class="sxs-lookup"><span data-stu-id="8b39a-152">SCID for the session.</span></span>|
| <span data-ttu-id="8b39a-153">hopperName</span><span class="sxs-lookup"><span data-stu-id="8b39a-153">hopperName</span></span>| <span data-ttu-id="8b39a-154">string</span><span class="sxs-lookup"><span data-stu-id="8b39a-154">string</span></span>| <span data-ttu-id="8b39a-155">ホッパーの名前です。</span><span class="sxs-lookup"><span data-stu-id="8b39a-155">Name of the hopper.</span></span>|
| <span data-ttu-id="8b39a-156">giveUpDuration</span><span class="sxs-lookup"><span data-stu-id="8b39a-156">giveUpDuration</span></span>| <span data-ttu-id="8b39a-157">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="8b39a-157">32-bit signed integer</span></span>| <span data-ttu-id="8b39a-158">最大待機時間 (秒の整数)。</span><span class="sxs-lookup"><span data-stu-id="8b39a-158">Maximum wait time (integral number of seconds).</span></span>|
| <span data-ttu-id="8b39a-159">preserveSession</span><span class="sxs-lookup"><span data-stu-id="8b39a-159">preserveSession</span></span>| <span data-ttu-id="8b39a-160">列挙型</span><span class="sxs-lookup"><span data-stu-id="8b39a-160">enumeration</span></span>| <span data-ttu-id="8b39a-161">かどうかには、セッションに一致するセッションとして再利用を示す値。</span><span class="sxs-lookup"><span data-stu-id="8b39a-161">A value indicating if the session is reused as the session into which to match.</span></span> <span data-ttu-id="8b39a-162">可能な値は、「ことはありません」と「常に」です。</span><span class="sxs-lookup"><span data-stu-id="8b39a-162">Possible values are "always" and "never".</span></span> |
| <span data-ttu-id="8b39a-163">ticketSessionRef</span><span class="sxs-lookup"><span data-stu-id="8b39a-163">ticketSessionRef</span></span>| <span data-ttu-id="8b39a-164">MultiplayerSessionReference</span><span class="sxs-lookup"><span data-stu-id="8b39a-164">MultiplayerSessionReference</span></span>| <span data-ttu-id="8b39a-165">プレイヤーまたはグループは、現在再生中のセッションの MultiplayerSessionReference オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="8b39a-165">The MultiplayerSessionReference object for the session in which the player or group is currently playing.</span></span> |
| <span data-ttu-id="8b39a-166">ticketAttributes</span><span class="sxs-lookup"><span data-stu-id="8b39a-166">ticketAttributes</span></span>| <span data-ttu-id="8b39a-167">オブジェクトのコレクション</span><span class="sxs-lookup"><span data-stu-id="8b39a-167">collection of objects</span></span>| <span data-ttu-id="8b39a-168">属性とプレイヤーのグループのユーザーが指定した値です。</span><span class="sxs-lookup"><span data-stu-id="8b39a-168">Attributes and values provided by the user about the group of players.</span></span>|

<a id="ID4EXF"></a>


### <a name="prohibited-members"></a><span data-ttu-id="8b39a-169">禁止されているメンバー</span><span class="sxs-lookup"><span data-stu-id="8b39a-169">Prohibited members</span></span>

<span data-ttu-id="8b39a-170">要求では、他のすべてのメンバーが禁止されています。</span><span class="sxs-lookup"><span data-stu-id="8b39a-170">All other members are prohibited in a request.</span></span>

<a id="ID4ECG"></a>


### <a name="sample-request"></a><span data-ttu-id="8b39a-171">要求の例</span><span class="sxs-lookup"><span data-stu-id="8b39a-171">Sample request</span></span>

<span data-ttu-id="8b39a-172">マッチ チケットを作成して、セッションは、プレイヤーに固有の属性と共に、一致するプレイヤーを含める必要があります前に、 **ticketSessionRef**オブジェクトによって参照されるセッションを作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8b39a-172">The session referred to by the **ticketSessionRef** object must be created before a match ticket can be created, and the session must contain the players to be matched, along with their player-specific attributes.</span></span> <span data-ttu-id="8b39a-173">各プレイヤーは、作成またはセッションに関連付けられているマッチ属性を追加する、MPSD からセッションに参加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8b39a-173">Each player must create or join the session against the MPSD, adding associated match attributes to the session.</span></span> <span data-ttu-id="8b39a-174">マッチの属性は、プレイヤーごとに matchAttrs と呼ばれるカスタム プロパティのフィールドに配置されます。</span><span class="sxs-lookup"><span data-stu-id="8b39a-174">The match attributes are placed in a custom property field called matchAttrs on each player.</span></span>

<span data-ttu-id="8b39a-175">作成または参加要求を提出する**http://sessiondirectory.xboxlive.com/serviceconfigs/{scid}/sessiontemplates/{templatename}/sessions/{sessionname}** し、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="8b39a-175">A create or join request is submitted to **http://sessiondirectory.xboxlive.com/serviceconfigs/{scid}/sessiontemplates/{templatename}/sessions/{sessionname}** and might look like this:</span></span>


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


<span data-ttu-id="8b39a-176">セッションが作成されたら、タイトルはそのセッションのチケットを作成するマッチメイ キング サービスを呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="8b39a-176">Once the session has been created, the title can call the matchmaking service to create the ticket for that session.</span></span>


> [!NOTE] 
> <span data-ttu-id="8b39a-177">タイトルでは、この呼び出しを再試行するユーザーを有効にすることができますが、再試行しないでください。 それに自動的にデータが失敗した場合。</span><span class="sxs-lookup"><span data-stu-id="8b39a-177">A title can enable a user to retry this call, but should not retry it automatically if the data fails.</span></span>  



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


## <a name="response-body"></a><span data-ttu-id="8b39a-178">応答本文</span><span class="sxs-lookup"><span data-stu-id="8b39a-178">Response body</span></span>

| <span data-ttu-id="8b39a-179">メンバー</span><span class="sxs-lookup"><span data-stu-id="8b39a-179">Member</span></span>| <span data-ttu-id="8b39a-180">説明</span><span class="sxs-lookup"><span data-stu-id="8b39a-180">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="8b39a-181">ticketId</span><span class="sxs-lookup"><span data-stu-id="8b39a-181">ticketId</span></span>| <span data-ttu-id="8b39a-182">GUID</span><span class="sxs-lookup"><span data-stu-id="8b39a-182">GUID</span></span>| <span data-ttu-id="8b39a-183">チケットの作成中の ID です。</span><span class="sxs-lookup"><span data-stu-id="8b39a-183">The ID for the ticket being created.</span></span>|
| <span data-ttu-id="8b39a-184">待機時間</span><span class="sxs-lookup"><span data-stu-id="8b39a-184">waitTime</span></span>| <span data-ttu-id="8b39a-185">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="8b39a-185">32-bit signed integer</span></span>| <span data-ttu-id="8b39a-186">平均の待機時間 (秒の整数)、ホッパー。</span><span class="sxs-lookup"><span data-stu-id="8b39a-186">The average wait time for the hopper (integral number of seconds).</span></span>|


```cpp
{
  "ticketId":"0584338f-a2ff-4eb9-b167-c0e8ddecae72",
  "waitTime":60
}

```


<a id="ID4EHAAC"></a>


## <a name="see-also"></a><span data-ttu-id="8b39a-187">関連項目</span><span class="sxs-lookup"><span data-stu-id="8b39a-187">See also</span></span>

<a id="ID4EJAAC"></a>


##### <a name="parent"></a><span data-ttu-id="8b39a-188">Parent</span><span class="sxs-lookup"><span data-stu-id="8b39a-188">Parent</span></span>  

[<span data-ttu-id="8b39a-189">/serviceconfigs/{scid}/hoppers/{hoppername}</span><span class="sxs-lookup"><span data-stu-id="8b39a-189">/serviceconfigs/{scid}/hoppers/{hoppername}</span></span>](uri-serviceconfigsscidhoppershoppername.md)
