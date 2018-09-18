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
ms.sourcegitcommit: f5321b525034e2b3af202709e9b942ad5557e193
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/18/2018
ms.locfileid: "4014791"
---
# <a name="post-serviceconfigsscidhoppershoppername"></a><span data-ttu-id="1be93-104">POST (/serviceconfigs/{scid}/hoppers/{hoppername})</span><span class="sxs-lookup"><span data-stu-id="1be93-104">POST (/serviceconfigs/{scid}/hoppers/{hoppername})</span></span>

<span data-ttu-id="1be93-105">指定したマッチ チケットを作成します。</span><span class="sxs-lookup"><span data-stu-id="1be93-105">Creates the specified match ticket.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="1be93-106">このメソッドは、コントラクト 103 以降で使用するものでは、X Xbl コントラクト バージョンのヘッダーの要素が必要です: 103 または後ですべての要求します。</span><span class="sxs-lookup"><span data-stu-id="1be93-106">This method is intended for use with contract 103 or later, and requires a header element of X-Xbl-Contract-Version: 103 or later on every request.</span></span>

  * [<span data-ttu-id="1be93-107">注釈</span><span class="sxs-lookup"><span data-stu-id="1be93-107">Remarks</span></span>](#ID4ET)
  * [<span data-ttu-id="1be93-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="1be93-108">URI parameters</span></span>](#ID4E5)
  * [<span data-ttu-id="1be93-109">Authorization</span><span class="sxs-lookup"><span data-stu-id="1be93-109">Authorization</span></span>](#ID4EJB)
  * [<span data-ttu-id="1be93-110">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="1be93-110">HTTP status codes</span></span>](#ID4E3C)
  * [<span data-ttu-id="1be93-111">要求本文</span><span class="sxs-lookup"><span data-stu-id="1be93-111">Request body</span></span>](#ID4EFD)
  * [<span data-ttu-id="1be93-112">応答本文</span><span class="sxs-lookup"><span data-stu-id="1be93-112">Response body</span></span>](#ID4E3G)

<a id="ID4ET"></a>


## <a name="remarks"></a><span data-ttu-id="1be93-113">注釈</span><span class="sxs-lookup"><span data-stu-id="1be93-113">Remarks</span></span>

<span data-ttu-id="1be93-114">この HTTP/REST メソッドは、サービス構成 ID (SCID) レベルで特定の名前をホッパーのマッチ チケットを作成します。</span><span class="sxs-lookup"><span data-stu-id="1be93-114">This HTTP/REST method creates a match ticket for a hopper with a particular name at the service configuration ID (SCID) level.</span></span> <span data-ttu-id="1be93-115">**Microsoft.Xbox.Services.Matchmaking.MatchmakingService.CreateMatchTicketAsync**メソッドでは、以下のメソッドをラップすることができます。</span><span class="sxs-lookup"><span data-stu-id="1be93-115">This method can be wrapped by the **Microsoft.Xbox.Services.Matchmaking.MatchmakingService.CreateMatchTicketAsync** method.</span></span>  
<a id="ID4E5"></a>


## <a name="uri-parameters"></a><span data-ttu-id="1be93-116">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="1be93-116">URI parameters</span></span>

| <span data-ttu-id="1be93-117">パラメーター</span><span class="sxs-lookup"><span data-stu-id="1be93-117">Parameter</span></span>| <span data-ttu-id="1be93-118">型</span><span class="sxs-lookup"><span data-stu-id="1be93-118">Type</span></span>| <span data-ttu-id="1be93-119">説明</span><span class="sxs-lookup"><span data-stu-id="1be93-119">Description</span></span>|
| --- | --- | --- | --- |
| <span data-ttu-id="1be93-120">scid</span><span class="sxs-lookup"><span data-stu-id="1be93-120">scid</span></span>| <span data-ttu-id="1be93-121">GUID</span><span class="sxs-lookup"><span data-stu-id="1be93-121">GUID</span></span>| <span data-ttu-id="1be93-122">セッションのサービス構成 id (SCID)。</span><span class="sxs-lookup"><span data-stu-id="1be93-122">The service configuration identifier (SCID) for the session.</span></span>|
| <span data-ttu-id="1be93-123">hoppername</span><span class="sxs-lookup"><span data-stu-id="1be93-123">hoppername</span></span> | <span data-ttu-id="1be93-124">string</span><span class="sxs-lookup"><span data-stu-id="1be93-124">string</span></span> | <span data-ttu-id="1be93-125">ホッパーの名前です。</span><span class="sxs-lookup"><span data-stu-id="1be93-125">The name of the hopper.</span></span> |

<a id="ID4EJB"></a>


## <a name="authorization"></a><span data-ttu-id="1be93-126">Authorization</span><span class="sxs-lookup"><span data-stu-id="1be93-126">Authorization</span></span>

| <span data-ttu-id="1be93-127">型</span><span class="sxs-lookup"><span data-stu-id="1be93-127">Type</span></span>| <span data-ttu-id="1be93-128">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="1be93-128">Required</span></span>| <span data-ttu-id="1be93-129">説明</span><span class="sxs-lookup"><span data-stu-id="1be93-129">Description</span></span>| <span data-ttu-id="1be93-130">不足している場合、応答</span><span class="sxs-lookup"><span data-stu-id="1be93-130">Response if missing</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="1be93-131">特権とデバイスの種類</span><span class="sxs-lookup"><span data-stu-id="1be93-131">Privileges and Device Type</span></span>| <span data-ttu-id="1be93-132">必須</span><span class="sxs-lookup"><span data-stu-id="1be93-132">yes</span></span>| <span data-ttu-id="1be93-133">ユーザーの deviceType がコンソールに設定されている場合、マッチメイ キング サービスへの呼び出しには主張でマルチプレイヤー権限を持つユーザーのみが許可されています。</span><span class="sxs-lookup"><span data-stu-id="1be93-133">When the user's deviceType is set to console, only users with the multiplayer privilege in their claims are allowed to make calls to the matchmaking service.</span></span> | <span data-ttu-id="1be93-134">403</span><span class="sxs-lookup"><span data-stu-id="1be93-134">403</span></span>|
| <span data-ttu-id="1be93-135">デバイスの種類</span><span class="sxs-lookup"><span data-stu-id="1be93-135">Device Type</span></span>| <span data-ttu-id="1be93-136">必須</span><span class="sxs-lookup"><span data-stu-id="1be93-136">yes</span></span>| <span data-ttu-id="1be93-137">とき、ユーザーの deviceType が省略されてか以外のコンソールに一致するタイトルに設定する必要がありますないコンソール専用のタイトル。</span><span class="sxs-lookup"><span data-stu-id="1be93-137">When the user's deviceType is absent or set to non-console, the title being matched into must not be a console-only title.</span></span> | <span data-ttu-id="1be93-138">403</span><span class="sxs-lookup"><span data-stu-id="1be93-138">403</span></span>|
| <span data-ttu-id="1be93-139">タイトル ID/実証購入/デバイスの種類</span><span class="sxs-lookup"><span data-stu-id="1be93-139">Title ID/Proof of Purchase/Device Type</span></span>| <span data-ttu-id="1be93-140">必須</span><span class="sxs-lookup"><span data-stu-id="1be93-140">yes</span></span>| <span data-ttu-id="1be93-141">タイトルに一致するには、指定されたタイトルの要求、デバイスの種類の組み合わせのマッチメイ キングを許可する必要があります。</span><span class="sxs-lookup"><span data-stu-id="1be93-141">The title that is being matched into must allow matchmaking for the specified title claim, device type combination.</span></span> | <span data-ttu-id="1be93-142">403</span><span class="sxs-lookup"><span data-stu-id="1be93-142">403</span></span>|

<a id="ID4E3C"></a>


## <a name="http-status-codes"></a><span data-ttu-id="1be93-143">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="1be93-143">HTTP status codes</span></span>
<span data-ttu-id="1be93-144">サービスは、MPSD に適用される HTTP ステータス コードを返します。</span><span class="sxs-lookup"><span data-stu-id="1be93-144">The service returns an HTTP status code as it applies to MPSD.</span></span>  
<a id="ID4EFD"></a>


## <a name="request-body"></a><span data-ttu-id="1be93-145">要求本文</span><span class="sxs-lookup"><span data-stu-id="1be93-145">Request body</span></span>

<a id="ID4ELD"></a>


### <a name="required-members"></a><span data-ttu-id="1be93-146">必要なメンバー</span><span class="sxs-lookup"><span data-stu-id="1be93-146">Required members</span></span>

| <span data-ttu-id="1be93-147">メンバー</span><span class="sxs-lookup"><span data-stu-id="1be93-147">Member</span></span>| <span data-ttu-id="1be93-148">種類</span><span class="sxs-lookup"><span data-stu-id="1be93-148">Type</span></span>| <span data-ttu-id="1be93-149">説明</span><span class="sxs-lookup"><span data-stu-id="1be93-149">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="1be93-150">serviceConfig</span><span class="sxs-lookup"><span data-stu-id="1be93-150">serviceConfig</span></span>| <span data-ttu-id="1be93-151">GUID</span><span class="sxs-lookup"><span data-stu-id="1be93-151">GUID</span></span>| <span data-ttu-id="1be93-152">セッションの SCID です。</span><span class="sxs-lookup"><span data-stu-id="1be93-152">SCID for the session.</span></span>|
| <span data-ttu-id="1be93-153">hopperName</span><span class="sxs-lookup"><span data-stu-id="1be93-153">hopperName</span></span>| <span data-ttu-id="1be93-154">string</span><span class="sxs-lookup"><span data-stu-id="1be93-154">string</span></span>| <span data-ttu-id="1be93-155">ホッパーの名前です。</span><span class="sxs-lookup"><span data-stu-id="1be93-155">Name of the hopper.</span></span>|
| <span data-ttu-id="1be93-156">giveUpDuration</span><span class="sxs-lookup"><span data-stu-id="1be93-156">giveUpDuration</span></span>| <span data-ttu-id="1be93-157">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="1be93-157">32-bit signed integer</span></span>| <span data-ttu-id="1be93-158">最大待機時間 (秒の整数)。</span><span class="sxs-lookup"><span data-stu-id="1be93-158">Maximum wait time (integral number of seconds).</span></span>|
| <span data-ttu-id="1be93-159">preserveSession</span><span class="sxs-lookup"><span data-stu-id="1be93-159">preserveSession</span></span>| <span data-ttu-id="1be93-160">列挙値</span><span class="sxs-lookup"><span data-stu-id="1be93-160">enumeration</span></span>| <span data-ttu-id="1be93-161">かどうかには、セッションに一致するセッションとして再利用を示す値。</span><span class="sxs-lookup"><span data-stu-id="1be93-161">A value indicating if the session is reused as the session into which to match.</span></span> <span data-ttu-id="1be93-162">値は、「しない」と"always"します。</span><span class="sxs-lookup"><span data-stu-id="1be93-162">Possible values are "always" and "never".</span></span> |
| <span data-ttu-id="1be93-163">ticketSessionRef</span><span class="sxs-lookup"><span data-stu-id="1be93-163">ticketSessionRef</span></span>| <span data-ttu-id="1be93-164">MultiplayerSessionReference</span><span class="sxs-lookup"><span data-stu-id="1be93-164">MultiplayerSessionReference</span></span>| <span data-ttu-id="1be93-165">されるプレイヤーまたはグループは、現在再生中のセッションの MultiplayerSessionReference オブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="1be93-165">The MultiplayerSessionReference object for the session in which the player or group is currently playing.</span></span> |
| <span data-ttu-id="1be93-166">ticketAttributes</span><span class="sxs-lookup"><span data-stu-id="1be93-166">ticketAttributes</span></span>| <span data-ttu-id="1be93-167">オブジェクトのコレクション</span><span class="sxs-lookup"><span data-stu-id="1be93-167">collection of objects</span></span>| <span data-ttu-id="1be93-168">属性とプレイヤーのグループのユーザーが指定した値です。</span><span class="sxs-lookup"><span data-stu-id="1be93-168">Attributes and values provided by the user about the group of players.</span></span>|

<a id="ID4EXF"></a>


### <a name="prohibited-members"></a><span data-ttu-id="1be93-169">禁止されているメンバー</span><span class="sxs-lookup"><span data-stu-id="1be93-169">Prohibited members</span></span>

<span data-ttu-id="1be93-170">要求では、その他のすべてのメンバーが禁止されています。</span><span class="sxs-lookup"><span data-stu-id="1be93-170">All other members are prohibited in a request.</span></span>

<a id="ID4ECG"></a>


### <a name="sample-request"></a><span data-ttu-id="1be93-171">要求の例</span><span class="sxs-lookup"><span data-stu-id="1be93-171">Sample request</span></span>

<span data-ttu-id="1be93-172">マッチ チケットを作成して、セッションは、そのプレイヤー固有の属性と共に、一致するプレイヤーを含める必要があります前に、 **ticketSessionRef**オブジェクトによって参照されるセッションを作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="1be93-172">The session referred to by the **ticketSessionRef** object must be created before a match ticket can be created, and the session must contain the players to be matched, along with their player-specific attributes.</span></span> <span data-ttu-id="1be93-173">各プレイヤーは、作成またはに対するセッションにマッチが関連付けられている属性の追加、MPSD セッションに参加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="1be93-173">Each player must create or join the session against the MPSD, adding associated match attributes to the session.</span></span> <span data-ttu-id="1be93-174">マッチの属性は、プレイヤーごとに matchAttrs と呼ばれるカスタム プロパティのフィールドに配置されます。</span><span class="sxs-lookup"><span data-stu-id="1be93-174">The match attributes are placed in a custom property field called matchAttrs on each player.</span></span>

<span data-ttu-id="1be93-175">作成または参加要求を提出する**http://sessiondirectory.xboxlive.com/serviceconfigs/{scid}/sessiontemplates/{templatename}/sessions/{sessionname}** し、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="1be93-175">A create or join request is submitted to **http://sessiondirectory.xboxlive.com/serviceconfigs/{scid}/sessiontemplates/{templatename}/sessions/{sessionname}** and might look like this:</span></span>


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


<span data-ttu-id="1be93-176">セッションが作成されたら、タイトルはそのセッションのチケットを作成するマッチメイ キング サービスを呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="1be93-176">Once the session has been created, the title can call the matchmaking service to create the ticket for that session.</span></span>


> [!NOTE] 
> <span data-ttu-id="1be93-177">タイトルは、この呼び出しを再試行するユーザーを有効にすることができますが、再試行しないでください。 それに自動的にデータが失敗した場合。</span><span class="sxs-lookup"><span data-stu-id="1be93-177">A title can enable a user to retry this call, but should not retry it automatically if the data fails.</span></span>  



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


## <a name="response-body"></a><span data-ttu-id="1be93-178">応答本文</span><span class="sxs-lookup"><span data-stu-id="1be93-178">Response body</span></span>

| <span data-ttu-id="1be93-179">メンバー</span><span class="sxs-lookup"><span data-stu-id="1be93-179">Member</span></span>| <span data-ttu-id="1be93-180">説明</span><span class="sxs-lookup"><span data-stu-id="1be93-180">Description</span></span>|
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="1be93-181">ticketId</span><span class="sxs-lookup"><span data-stu-id="1be93-181">ticketId</span></span>| <span data-ttu-id="1be93-182">GUID</span><span class="sxs-lookup"><span data-stu-id="1be93-182">GUID</span></span>| <span data-ttu-id="1be93-183">チケットの作成中の ID です。</span><span class="sxs-lookup"><span data-stu-id="1be93-183">The ID for the ticket being created.</span></span>|
| <span data-ttu-id="1be93-184">待機時間</span><span class="sxs-lookup"><span data-stu-id="1be93-184">waitTime</span></span>| <span data-ttu-id="1be93-185">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="1be93-185">32-bit signed integer</span></span>| <span data-ttu-id="1be93-186">平均の待機時間 (秒の整数)、ホッパー。</span><span class="sxs-lookup"><span data-stu-id="1be93-186">The average wait time for the hopper (integral number of seconds).</span></span>|


```cpp
{
  "ticketId":"0584338f-a2ff-4eb9-b167-c0e8ddecae72",
  "waitTime":60
}

```


<a id="ID4EHAAC"></a>


## <a name="see-also"></a><span data-ttu-id="1be93-187">関連項目</span><span class="sxs-lookup"><span data-stu-id="1be93-187">See also</span></span>

<a id="ID4EJAAC"></a>


##### <a name="parent"></a><span data-ttu-id="1be93-188">Parent</span><span class="sxs-lookup"><span data-stu-id="1be93-188">Parent</span></span>  

[<span data-ttu-id="1be93-189">/serviceconfigs/{scid}/hoppers/{hoppername}</span><span class="sxs-lookup"><span data-stu-id="1be93-189">/serviceconfigs/{scid}/hoppers/{hoppername}</span></span>](uri-serviceconfigsscidhoppershoppername.md)
