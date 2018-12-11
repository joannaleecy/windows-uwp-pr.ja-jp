---
title: マルチプレイヤー セッションの詳細
description: Xbox Live マルチプレイヤー セッションの詳細について説明します。
ms.assetid: 5aeae339-4a97-45f4-b0e7-e669c994f249
ms.date: 04/04/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, マルチプレイヤー 2015, セッション テンプレート, MPSD
ms.localizationpriority: medium
ms.openlocfilehash: 175dddb79ed7e9d7cddc970e0b48efed11fbe0b6
ms.sourcegitcommit: 8921a9cc0dd3e5665345ae8eca7ab7aeb83ccc6f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8874493"
---
# <a name="mpsd-session-details"></a><span data-ttu-id="6698a-104">MPSD セッションの詳細</span><span class="sxs-lookup"><span data-stu-id="6698a-104">MPSD Session Details</span></span>

<span data-ttu-id="6698a-105">この記事は、次のセクションで構成されています。</span><span class="sxs-lookup"><span data-stu-id="6698a-105">This article contains the following sections:</span></span>
* <span data-ttu-id="6698a-106">セッションの概要</span><span class="sxs-lookup"><span data-stu-id="6698a-106">Session Overview</span></span>
* <span data-ttu-id="6698a-107">セッション機能</span><span class="sxs-lookup"><span data-stu-id="6698a-107">Session Capabilities</span></span>
* <span data-ttu-id="6698a-108">セッション サイズ</span><span class="sxs-lookup"><span data-stu-id="6698a-108">Session Size</span></span>
* <span data-ttu-id="6698a-109">セッションのユーザーの状態</span><span class="sxs-lookup"><span data-stu-id="6698a-109">Session User States</span></span>
* <span data-ttu-id="6698a-110">可視性と参加可能性</span><span class="sxs-lookup"><span data-stu-id="6698a-110">Visibility and Joinability</span></span>
* <span data-ttu-id="6698a-111">セッション タイムアウト</span><span class="sxs-lookup"><span data-stu-id="6698a-111">Session Timeouts</span></span>
* <span data-ttu-id="6698a-112">1 台の本体にサインインした複数のユーザー</span><span class="sxs-lookup"><span data-stu-id="6698a-112">Multiple Signed-in Users on a Single Console</span></span>
* <span data-ttu-id="6698a-113">プロセス ライフサイクル管理</span><span class="sxs-lookup"><span data-stu-id="6698a-113">Process Lifecycle Management</span></span>
* <span data-ttu-id="6698a-114">非アクティブなセッションのクリーンアップ</span><span class="sxs-lookup"><span data-stu-id="6698a-114">Cleanup of Inactive Sessions</span></span>
* <span data-ttu-id="6698a-115">セッション アービター</span><span class="sxs-lookup"><span data-stu-id="6698a-115">Session Arbiter</span></span>

## <a name="session-overview"></a><span data-ttu-id="6698a-116">セッションの概要</span><span class="sxs-lookup"><span data-stu-id="6698a-116">Session Overview</span></span>

<span data-ttu-id="6698a-117">マルチプレイヤー セッション ディレクトリ (MPSD) セッションはセッションの名前を持つし、は、セッションの既定の設定を提供する JSON ドキュメントは、セッション テンプレートのインスタンスとして識別されます。</span><span class="sxs-lookup"><span data-stu-id="6698a-117">A Multiplayer Session Directory (MPSD) session has a session name and is identified as an instance of a session template, which is a JSON document that provides default settings for the session.</span></span> <span data-ttu-id="6698a-118">テンプレートは、サービス構成 id (SCID) でサービス構成の一部は GUID です。</span><span class="sxs-lookup"><span data-stu-id="6698a-118">The template is part of a service configuration with a service configuration identifier (SCID), which is a GUID.</span></span> <span data-ttu-id="6698a-119">[Xbox デベロッパー ポータル (XDP)](https://xdp.xboxlive.com)と[パートナー センター](https://partner.microsoft.com/dashboard)では、このテンプレートを調べることができます。</span><span class="sxs-lookup"><span data-stu-id="6698a-119">This template can be found on [Xbox Developer Portal (XDP)](https://xdp.xboxlive.com) and [Partner Center](https://partner.microsoft.com/dashboard).</span></span> <span data-ttu-id="6698a-120">サービス構成は、同様の取り込み、管理、およびセキュリティ ポリシーに使用する開発者向けリソースです。</span><span class="sxs-lookup"><span data-stu-id="6698a-120">Service configurations are the developer-facing resources used for ingestion, management, and security policy.</span></span> <span data-ttu-id="6698a-121">セッションを MPSD を介してアクセスすると、XDP またはパートナー センターを通じてデベロッパーが設定したアクセス ポリシーに従って、サービス構成に対してプリンシパルの承認が実行されます。</span><span class="sxs-lookup"><span data-stu-id="6698a-121">When a session is accessed through MPSD, principal authorization is performed against the service configuration according to the access policies set by the developer through XDP or Partner Center.</span></span> <span data-ttu-id="6698a-122">サービス構成へのアクセスが承認された後にセッションが読み込まれると、セッションのメンバーシップ検証などのセカンダリー アクセス チェックがセッション レベルで実行されます。</span><span class="sxs-lookup"><span data-stu-id="6698a-122">Secondary access checks, such as session membership validation, are performed at the session level when the session is loaded after access to the service configuration is authorized.</span></span>

<span data-ttu-id="6698a-123">ここでは、テンプレートでコントラクト バージョン 107 を使用していると仮定します。このコントラクト バージョンは、Xbox One の現在の MPSD で使用されているバージョンです。</span><span class="sxs-lookup"><span data-stu-id="6698a-123">This topic assumes that your template uses contract version 107, which is the version used by the current MPSD for Xbox One.</span></span> <span data-ttu-id="6698a-124">コントラクト バージョン 105 (104 と同じ) に基づいてテンプレートを定義した場合は、バージョン 107 をサポートするためにこれらを変更してください。</span><span class="sxs-lookup"><span data-stu-id="6698a-124">If you have defined templates based on contract version 105 (identical to 104), you must change these to support version 107.</span></span> <span data-ttu-id="6698a-125">手順については、「[マルチプレイヤー 2015 での移行における一般的な問題](common-issues-when-adapting-multiplayer.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="6698a-125">For instructions, see [Common Multiplayer 2015 migration issues](common-issues-when-adapting-multiplayer.md).</span></span>

| <span data-ttu-id="6698a-126">重要</span><span class="sxs-lookup"><span data-stu-id="6698a-126">Important</span></span>                                                                                                                                                                                                                                                      |
|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="6698a-127">テンプレートを使用して設定された機能は、MPSD への書き込みによって変更できません。</span><span class="sxs-lookup"><span data-stu-id="6698a-127">Functionality that is set through a template cannot be changed through writes to the MPSD.</span></span> <span data-ttu-id="6698a-128">値を変更するには、必要な変更を行った新しいテンプレートを作成し、送信する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6698a-128">To change the values, you must create and submit a new template with the necessary changes.</span></span> <span data-ttu-id="6698a-129">テンプレートで設定されない項目はすべて、MPSD への書き込みによって変更できます。</span><span class="sxs-lookup"><span data-stu-id="6698a-129">Any items that are not set through a template can be changed through writes to MPSD.</span></span> |

### <a name="session-reference"></a><span data-ttu-id="6698a-130">セッション参照</span><span class="sxs-lookup"><span data-stu-id="6698a-130">Session Reference</span></span>

<span data-ttu-id="6698a-131">各 MPSD セッションは、セッション参照によって一意に参照され、**MultiplayerSessionReference クラス**によってマルチプレイヤー WinRT API で表されます。</span><span class="sxs-lookup"><span data-stu-id="6698a-131">Each MPSD session is uniquely referred to by a session reference, represented in the multiplayer WinRT API by the **MultiplayerSessionReference Class**.</span></span> <span data-ttu-id="6698a-132">セッション参照には以下の文字列値が含まれています。</span><span class="sxs-lookup"><span data-stu-id="6698a-132">The session reference contains these string values:</span></span>

-   <span data-ttu-id="6698a-133">サービス構成 ID (SCID)</span><span class="sxs-lookup"><span data-stu-id="6698a-133">Service configuration identifier (SCID)</span></span>
-   <span data-ttu-id="6698a-134">セッション テンプレート名</span><span class="sxs-lookup"><span data-stu-id="6698a-134">Session template name</span></span>
-   <span data-ttu-id="6698a-135">セッション名</span><span class="sxs-lookup"><span data-stu-id="6698a-135">Session name</span></span>

<span data-ttu-id="6698a-136">セッション参照は、次に示すように、セッションを識別するための URI にマップします。</span><span class="sxs-lookup"><span data-stu-id="6698a-136">The session reference maps into the URI for identifying sessions as shown below.</span></span> <span data-ttu-id="6698a-137">次のマッピング例では、"authority" は sessiondirectory.xboxlive.com です。</span><span class="sxs-lookup"><span data-stu-id="6698a-137">In the following example mapping, "authority" is sessiondirectory.xboxlive.com.</span></span>

```HTTP
https://{authority}/serviceconfigs/{service-config-id}/sessiontemplates/{session-template-name}/sessions/{session-name}
```

### <a name="elements-of-a-session"></a><span data-ttu-id="6698a-138">セッションの要素</span><span class="sxs-lookup"><span data-stu-id="6698a-138">Elements of a Session</span></span>

<span data-ttu-id="6698a-139">各セッションには、セッションの要素ごとに異なる変更可能性およびセキュリティ規則を適用する要素のグループと、読み取り専用のハウスキーピング情報 (メタデータ) が含まれています。</span><span class="sxs-lookup"><span data-stu-id="6698a-139">Each session contains groups of elements that enforce mutability and security rules, which vary by session element, along with read-only housekeeping information (metadata).</span></span> <span data-ttu-id="6698a-140">ここでは、セッションを構成するために JSON ファイルに含まれるセッション要素のグループと、選択したテンプレートの JSON ファイルに含まれるセッション要素のグループについて説明します。</span><span class="sxs-lookup"><span data-stu-id="6698a-140">This section describes the groups of session elements included in the JSON files to configure your session, and in the JSON file for the template that you choose.</span></span>

| <span data-ttu-id="6698a-141">注意</span><span class="sxs-lookup"><span data-stu-id="6698a-141">Note</span></span>                                                                                                                                                   |
|---------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="6698a-142">HTTP/REST 実装に WinRT ラッパーを使用している場合は、セッションおよびテンプレートで、WinRT の機能を正確に反映する JSON オブジェクトを定義する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6698a-142">If you are using WinRT wrappers for an HTTP/REST implementation, your session and template must define JSON objects that precisely reflect the WinRT functionality.</span></span> |

<span data-ttu-id="6698a-143">各要素グループ内には、次の 2 つの内部オブジェクトがあります。</span><span class="sxs-lookup"><span data-stu-id="6698a-143">Inside each of the element groups, there are two inner objects:</span></span>

-   <span data-ttu-id="6698a-144">システム オブジェクト - これらのオブジェクトには、MPSD によって適用および解釈される固定のスキーマがあります。</span><span class="sxs-lookup"><span data-stu-id="6698a-144">System objects -- these objects have a fixed schema that is enforced and interpreted by MPSD.</span></span> <span data-ttu-id="6698a-145">システム オブジェクトは検証およびマージされます。</span><span class="sxs-lookup"><span data-stu-id="6698a-145">They are validated and merged.</span></span> <span data-ttu-id="6698a-146">MPSD は、システム オブジェクトの意味を定義し、把握しているので、それらに従って動作することができます。</span><span class="sxs-lookup"><span data-stu-id="6698a-146">Since MPSD defines and knows what they mean, it can act upon them.</span></span> <span data-ttu-id="6698a-147">各システム オブジェクトの完全な定義については、「**MultiplayerSession クラス**」のリファレンスおよび「**セッション ディレクトリ URI**」のリファレンスを参照してください。</span><span class="sxs-lookup"><span data-stu-id="6698a-147">For the full definition of each of the system objects, see the references for the **MultiplayerSession Class** and the references for the **Session Directory URIs**.</span></span>
-   <span data-ttu-id="6698a-148">カスタム オブジェクト - これらのオブジェクトはオプションであり、スキーマはありません。</span><span class="sxs-lookup"><span data-stu-id="6698a-148">Custom objects -- these objects are optional, and have no schema.</span></span> <span data-ttu-id="6698a-149">マルチプレイヤー ゲームに関するメタデータを格納するために使用されます。</span><span class="sxs-lookup"><span data-stu-id="6698a-149">They are used to store metadata concerning a multiplayer game.</span></span> <span data-ttu-id="6698a-150">MPSD はこのデータを解釈できないので、それらに従って動作しません。</span><span class="sxs-lookup"><span data-stu-id="6698a-150">Since MPSD cannot interpret this data, it is not acted upon.</span></span> <span data-ttu-id="6698a-151">ゲーム データまたは保存される情報はタイトル管理ストレージ (TMS) に格納される必要があります。</span><span class="sxs-lookup"><span data-stu-id="6698a-151">Game data or saved information should be stored in title-managed storage (TMS).</span></span> <span data-ttu-id="6698a-152">TMS の詳細については、「**Xbox Live タイトル ストレージ**」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="6698a-152">For more about TMS, see **Xbox Live Title Storage**.</span></span>

<span data-ttu-id="6698a-153">カスタム JSON オブジェクトの例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="6698a-153">Here's an example of a custom JSON object:</span></span>
```JSON
    "custom": {
      "myField1": true,
      "myField2": "string",
      "myField3": 5.5,
      "myField4": { "myObject": null },
      "myField5": [ "my", "array" ]
    }
```

#### <a name="session-constants"></a><span data-ttu-id="6698a-154">セッション定数</span><span class="sxs-lookup"><span data-stu-id="6698a-154">Session Constants</span></span>

<span data-ttu-id="6698a-155">セッション定数は、作成時にのみ、作成者またはセッション テンプレートによって設定されます。</span><span class="sxs-lookup"><span data-stu-id="6698a-155">Session constants are set only at creation time, by the creator or by the session template.</span></span> <span data-ttu-id="6698a-156">/constants/system オブジェクトは、MPSD を介して認識され、マルチプレイヤー システムの定数を定義するために使用されます。</span><span class="sxs-lookup"><span data-stu-id="6698a-156">The /constants/system object is used to define constants for the multiplayer system as it is known through the MPSD.</span></span> <span data-ttu-id="6698a-157">このオブジェクトに関連付けられている WinRT ラッパーは、**MultiplayerSessionConstants クラス**によって表されます。</span><span class="sxs-lookup"><span data-stu-id="6698a-157">The WinRT wrapper associated with this object is represented by the **MultiplayerSessionConstants Class**.</span></span>

<span data-ttu-id="6698a-158">/constants/system オブジェクトは、capabilities オブジェクト、metrics オブジェクト、managedInitialization (テンプレート コントラクト バージョン 104/105) または memberInitialization (コントラクト バージョン 107) オブジェクト、peerToPeerRequirements オブジェクト、peerToHostRequirements オブジェクト、measurementsServerAddresses オブジェクトなど、多数の項目を定義できます。</span><span class="sxs-lookup"><span data-stu-id="6698a-158">The /constants/system object can define a number of items, including a capabilities object, a metrics object, a managedInitialization (template contract version 104/105) or memberInitialization (contract version 107) object, a peerToPeerRequirements object, a peerToHostRequirements object, and a measurementsServerAddresses object.</span></span>


#### <a name="session-properties"></a><span data-ttu-id="6698a-159">セッションのプロパティ</span><span class="sxs-lookup"><span data-stu-id="6698a-159">Session Properties</span></span>

<span data-ttu-id="6698a-160">/properties/system オブジェクトを使用して MPSD 用のセッションのプロパティを定義します。</span><span class="sxs-lookup"><span data-stu-id="6698a-160">Use the /properties/system object to define session properties for MPSD.</span></span> <span data-ttu-id="6698a-161">このオブジェクトに関連付けられている WinRT ラッパーは、**MultiplayerSessionProperties クラス**です。</span><span class="sxs-lookup"><span data-stu-id="6698a-161">The WinRT wrapper associated with this object is the **MultiplayerSessionProperties Class**.</span></span> <span data-ttu-id="6698a-162">セッションのプロパティは、いつでもセッション メンバーによる書き込みが可能です。</span><span class="sxs-lookup"><span data-stu-id="6698a-162">Session properties are writable by session members at any time.</span></span> <span data-ttu-id="6698a-163">JSON 形式によるセッションのプロパティの例には、joinRestriction、initializationSucceeded、マッチメイキング オブジェクトなどがあります。</span><span class="sxs-lookup"><span data-stu-id="6698a-163">Examples of session properties in JSON format are: joinRestriction, initializationSucceeded, and the matchmaking object.</span></span> <span data-ttu-id="6698a-164">この要素グループの使用例については、「[ターゲット セッションの初期化と QoS](smartmatch-matchmaking.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="6698a-164">For an example of the use of this element group, see [Target Session Initialization and QoS](smartmatch-matchmaking.md).</span></span>


#### <a name="member-constants"></a><span data-ttu-id="6698a-165">メンバー定数</span><span class="sxs-lookup"><span data-stu-id="6698a-165">Member Constants</span></span>

<span data-ttu-id="6698a-166">各セッション メンバーの参加時にメンバー定数を設定します。</span><span class="sxs-lookup"><span data-stu-id="6698a-166">Set the member constants at join time for each session member.</span></span> <span data-ttu-id="6698a-167">JSON オブジェクトは /members/{index}/constants/system です。</span><span class="sxs-lookup"><span data-stu-id="6698a-167">The JSON object is /members/{index}/constants/system.</span></span> <span data-ttu-id="6698a-168">セッション メンバーを表す WinRT のラッパー クラスは、**MultiplayerSessionMember クラス**です。</span><span class="sxs-lookup"><span data-stu-id="6698a-168">The WinRT wrapper class representing a session member is the **MultiplayerSessionMember Class**.</span></span>


## <a name="member-properties"></a><span data-ttu-id="6698a-169">メンバーのプロパティ</span><span class="sxs-lookup"><span data-stu-id="6698a-169">Member Properties</span></span>

<span data-ttu-id="6698a-170">メンバーのプロパティはセッション メンバーのみが書き込み可能です。</span><span class="sxs-lookup"><span data-stu-id="6698a-170">Member properties are writable only by a session member.</span></span> <span data-ttu-id="6698a-171">/members/{index}/properties/system オブジェクトで設定され、**MultiplayerSessionMember クラス**の要素が反映されます。</span><span class="sxs-lookup"><span data-stu-id="6698a-171">They are set in the /members/{index}/properties/system object and reflect the elements of the **MultiplayerSessionMember Class**.</span></span> <span data-ttu-id="6698a-172">以下に例を示します。</span><span class="sxs-lookup"><span data-stu-id="6698a-172">Here is an example:</span></span>

```
    {
      // These flags control the member status and "activeTitle", and are mutually exclusive (it's an error to set both to true).
      // For each, false is the same as not present. The default status is "inactive", i.e. neither present.
      "ready": true,
      "active": false,

      // Base-64 blob, or not present. Empty string is the same as not present.
      "secureDeviceAddress": "ryY=",

      // During member initialization, if any members in the list fail, this member will also fail.
      // Can't be set on large sessions.
      "initializationGroup": [ 5 ],

      // List of the groups I'm in and the encounters I just had.
      // An encounter is a brief interaction with a group. When an encounter is reported, it counts as retroactively joining the group 30 seconds ago and just now leaving.
      // Group names use the session name validation rules (e.g. case-insensitive).
      // On large sessions, groups are used to report who played with who (rather than just session membership). Members
      // that are active in at least one group together at the same time are counted as playing together.
      // Empty lists are the same as no value specified.
      // The set of encounters is a point-in-time property, so it's immediately consumed and will never appear on a response.
      "groups": [ "team-buzz", "posse.99" ],
      "encounters": [ "CoffeeShop-757093D8-E41F-49D0-BB13-17A49B20C6B9" ],

      // Optional list of role preferences the player has specified for role-based game modes.
      // All role names have to match across all members in the session. Role weights are
      // defined from 0-100.
      "RolePreference": { "medic": 75, "sniper": 25, "assault": 50, "support": 100 },

      // QoS measurements by lower-case device token.
      // Like all fields, "measurements" must be updated as a whole. It should be set once when measurement is complete, not incrementally.
      // Metrics can be omitted if they weren't successfully measured, i.e. the peer is unreachable.
      // If a "measurements" object is set, it can't contain an entry for the member's own address.
      "measurements": {
        "e69c43a8": {
          "bandwidthDown": 19342,  // Kilobits per second
          "bandwidthUp": 944,  // Kilobits per second
          "custom": { }
        }

      // QoS measurements by game-server connection string. Like all fields, "serverMeasurements" must be updated as a whole, so it should be set once when measurement is complete.
      // If empty, it means that none of the measurements completed within the "serverMeasurementTimeout".
      "serverMeasurements": {
        "server farm a": {
          "latency": 233  // Milliseconds
        }
      },

      // Subscriptions for shoulder taps on session changes. The "profile" indicates which session changes to tap as well as other properties of the registration like the min time between taps.
      // The subscription is named with a title-generated GUID that is also sent back with the tap as a context ID.
      // Subscriptions can be added and removed individually, without affecting other subscriptions in the "subscriptions" object.
      // To remove a subscription, set its context ID to null.
      // (Like the "ready" and "active" flags, the "subscriptions" data is copied out and maintained internally, so the normal replace-all rule on system fields doesn't apply to "subscriptions".)
      // Can't be set on large sessions.
      "subscriptions": {
        "961dc162-3a8c-4982-b58b-0347ed086bc9": {
          "profile": "party",  // Or "matchmaking", "initialization", "roster", "queuehost", or "queue"
          "onBehalfOfTitleId": "3948320593",  // Optional decimal title ID of the registered channel.  If not set the title ID is taken from the token.
        },
        "709fef70-4638-4b94-905b-24cb02706eb5": null
      }
    }
```

#### <a name="server-elements"></a><span data-ttu-id="6698a-173">サーバー要素</span><span class="sxs-lookup"><span data-stu-id="6698a-173">Server Elements</span></span>

<span data-ttu-id="6698a-174">サーバーは、セッションに参加した、または招待された、ユーザーではないメンバーです。</span><span class="sxs-lookup"><span data-stu-id="6698a-174">Servers are non-users that have joined or been invited into a session.</span></span> <span data-ttu-id="6698a-175">関連付けられている JSON オブジェクトは、/servers/{server-name}/constants/system と /servers/{server-name}/properties/system です。</span><span class="sxs-lookup"><span data-stu-id="6698a-175">The associated JSON objects are /servers/{server-name}/constants/system and /servers/{server-name}/properties/system.</span></span> <span data-ttu-id="6698a-176">これらのオブジェクトはサーバーのみが書き込み可能です。</span><span class="sxs-lookup"><span data-stu-id="6698a-176">These objects are writable only by servers.</span></span>

| <span data-ttu-id="6698a-177">注意</span><span class="sxs-lookup"><span data-stu-id="6698a-177">Note</span></span>                                                         |
|---------------------------------------------------------------------------|
| <span data-ttu-id="6698a-178">/servers/{server-name}/constants/system オブジェクトは現在使用されていません。</span><span class="sxs-lookup"><span data-stu-id="6698a-178">The /servers/{server-name}/constants/system object is not currently used.</span></span> |


### <a name="session-configuration"></a><span data-ttu-id="6698a-179">セッションの構成</span><span class="sxs-lookup"><span data-stu-id="6698a-179">Session Configuration</span></span>

<span data-ttu-id="6698a-180">セッションの構成を制御するには、次の 2 つの方法があります。</span><span class="sxs-lookup"><span data-stu-id="6698a-180">There are two ways to control the configuration of sessions:</span></span>

-   <span data-ttu-id="6698a-181">XDP またはパートナー センターを通じて取り込まれたセッション テンプレートを使用します。</span><span class="sxs-lookup"><span data-stu-id="6698a-181">Use session templates ingested through XDP or Partner Center.</span></span>
-   <span data-ttu-id="6698a-182">Multiplayer および Matchmaking WinRT API または REST API への呼び出しを使用します。</span><span class="sxs-lookup"><span data-stu-id="6698a-182">Use calls to the multiplayer and matchmaking WinRT APIs or REST APIs.</span></span> <span data-ttu-id="6698a-183">この場合もテンプレートを使用する必要がありますが、構成する値がテンプレートに含まれている必要はありません。</span><span class="sxs-lookup"><span data-stu-id="6698a-183">You must still use a template but the template does not have to contain the values you want to configure.</span></span> <span data-ttu-id="6698a-184">タイトルは、テンプレートで既に設定されている定数をオーバーライドできないことに注意してください。</span><span class="sxs-lookup"><span data-stu-id="6698a-184">Note that your title cannot override the constants already set in the template.</span></span>

<span data-ttu-id="6698a-185">セッション自体を定義するために別の JSON ドキュメントが提供されます。</span><span class="sxs-lookup"><span data-stu-id="6698a-185">A separate JSON document is provided to define the session itself.</span></span> <span data-ttu-id="6698a-186">さらに、デベロッパーは、特定のタイトルに必要な WinRT ラッパー機能を実装する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6698a-186">In addition, the developer must implement any WinRT wrapper functionality required for a particular title.</span></span> <span data-ttu-id="6698a-187">JSON ドキュメントとすべての WinRT ラッパー コードの内容は、お互いを正確に反映する必要があり、最新のテンプレート コントラクト バージョンを反映する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6698a-187">The contents of the JSON documents and any WinRT wrapper code must reflect each other precisely, and must reflect the latest template contract version.</span></span>

<span data-ttu-id="6698a-188">セッションのスキーマは、セッションのバージョン (メジャー バージョン) とプロトコルのバージョン (マイナー バージョン) によってバージョン管理されます。</span><span class="sxs-lookup"><span data-stu-id="6698a-188">The schema for a session is versioned with the session version (major version) and the protocol revision (minor version).</span></span> <span data-ttu-id="6698a-189">バージョンは、"100 \* メジャー + マイナー" として X-Xbl-Contract-Version ヘッダーにまとめられます。</span><span class="sxs-lookup"><span data-stu-id="6698a-189">The versions are combined into the X-Xbl-Contract-Version header as "100 \* major + minor".</span></span> <span data-ttu-id="6698a-190">たとえば、v1.7 タイトルには、最新のテンプレート コントラクト バージョンが 107 であると仮定して、すべての REST 要求に X-Xbl-Contract-Version: 107 のヘッダーが含まれます。</span><span class="sxs-lookup"><span data-stu-id="6698a-190">For example, a v1.7 title includes the following header on every REST request, assuming the latest template contract version of 107: X-Xbl-Contract-Version: 107.</span></span>

| <span data-ttu-id="6698a-191">注意</span><span class="sxs-lookup"><span data-stu-id="6698a-191">Note</span></span>                                                                                              |
|----------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="6698a-192">(XSAPI を使用する) ほとんどのタイトルで、コントラクト バージョン 105 とセッション テンプレート バージョン 107 を使用することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="6698a-192">It is recommended for most titles (using XSAPI) to use contract version 105, and session template version 107.</span></span> |


### <a name="session-templates"></a><span data-ttu-id="6698a-193">セッション テンプレート</span><span class="sxs-lookup"><span data-stu-id="6698a-193">Session Templates</span></span>

<span data-ttu-id="6698a-194">各セッション テンプレートは、サービス構成に含まれる JSON ドキュメントであり、作成するセッションのフレームワークを定義し、新しいセッションに定数を提供します。</span><span class="sxs-lookup"><span data-stu-id="6698a-194">Each session template is a JSON document, part of the service configuration, that defines the framework for the session being created and provides constants for the new session.</span></span> <span data-ttu-id="6698a-195">詳細については、「[MPSD セッション テンプレート](../service-configuration/session-templates.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="6698a-195">For more information, see [MPSD Session Templates](../service-configuration/session-templates.md).</span></span>

## <a name="session-capabilities"></a><span data-ttu-id="6698a-196">セッション機能</span><span class="sxs-lookup"><span data-stu-id="6698a-196">Session Capabilities</span></span>

<span data-ttu-id="6698a-197">機能は、MPSD がそのセッションに適用する動作を構成する、MPSD セッション内の定数です。</span><span class="sxs-lookup"><span data-stu-id="6698a-197">Capabilities are constants in the MPSD session that configure behavior that the MPSD should apply to that session.</span></span> <span data-ttu-id="6698a-198">最もよく使用される XDP とパートナー センター機能は、セッション テンプレートで設定します。</span><span class="sxs-lookup"><span data-stu-id="6698a-198">You most commonly use XDP and Partner Center to set capabilities in the session template.</span></span> <span data-ttu-id="6698a-199">/constants/system/capabilities オブジェクトに設定されます。</span><span class="sxs-lookup"><span data-stu-id="6698a-199">They are set in the /constants/system/capabilities object.</span></span> <span data-ttu-id="6698a-200">機能が必要ない場合は、空の capabilities オブジェクトを使用します。</span><span class="sxs-lookup"><span data-stu-id="6698a-200">If no capabilities are needed, use an empty capabilities object.</span></span>

| <span data-ttu-id="6698a-201">注意</span><span class="sxs-lookup"><span data-stu-id="6698a-201">Note</span></span>                                                                                                       |
|-------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="6698a-202">タイトルが Multiplayer WinRT API または Matchmaking WinRT API を使用してセッション機能を変更またはアクセスすることはほとんどありません。</span><span class="sxs-lookup"><span data-stu-id="6698a-202">Titles almost never change or access session capabilities using the multiplayer WinRT API or the matchmaking WinRT API.</span></span> |

<span data-ttu-id="6698a-203">セッション機能は、**MultiplayerSessionCapabilities クラス**によって表されます。</span><span class="sxs-lookup"><span data-stu-id="6698a-203">Session capabilities are represented by the **MultiplayerSessionCapabilities Class**.</span></span> <span data-ttu-id="6698a-204">これらはセッションがサポートできるものを示すブール値です。</span><span class="sxs-lookup"><span data-stu-id="6698a-204">They are boolean values that indicate what the session can support:</span></span>

-   <span data-ttu-id="6698a-205">接続</span><span class="sxs-lookup"><span data-stu-id="6698a-205">Connectivity</span></span>
-   <span data-ttu-id="6698a-206">ゲーム プレイ</span><span class="sxs-lookup"><span data-stu-id="6698a-206">Game play</span></span>
-   <span data-ttu-id="6698a-207">大きいサイズ</span><span class="sxs-lookup"><span data-stu-id="6698a-207">Large size</span></span>
-   <span data-ttu-id="6698a-208">アクティブなメンバーに必要な接続</span><span class="sxs-lookup"><span data-stu-id="6698a-208">Connection required for active members</span></span>

<span data-ttu-id="6698a-209">**MultiplayerSessionConstants クラス**は、セッション機能に関連する以下のプロパティを定義します。</span><span class="sxs-lookup"><span data-stu-id="6698a-209">The **MultiplayerSessionConstants Class** defines the following properties that concern session capabilities:</span></span>

-   **<span data-ttu-id="6698a-210">CapabilitiesConnectivity</span><span class="sxs-lookup"><span data-stu-id="6698a-210">CapabilitiesConnectivity</span></span>**
-   **<span data-ttu-id="6698a-211">CapabilitiesGameplay</span><span class="sxs-lookup"><span data-stu-id="6698a-211">CapabilitiesGameplay</span></span>**
-   **<span data-ttu-id="6698a-212">CapabilitiesLarge</span><span class="sxs-lookup"><span data-stu-id="6698a-212">CapabilitiesLarge</span></span>**

| <span data-ttu-id="6698a-213">注意</span><span class="sxs-lookup"><span data-stu-id="6698a-213">Note</span></span>                                                                                                   |
|---------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="6698a-214">タイトルで動的なセッション機能を定義する場合は、セッション定数の対応するプロパティを true に設定します。</span><span class="sxs-lookup"><span data-stu-id="6698a-214">If the title defines a dynamic session capability, the corresponding property is set to true for session constants.</span></span> |

## <a name="session-size"></a><span data-ttu-id="6698a-215">セッション サイズ</span><span class="sxs-lookup"><span data-stu-id="6698a-215">Session Size</span></span>

<span data-ttu-id="6698a-216">MPSD セッションのサイズは、そのセッション内のメンバーの数によって決まります。</span><span class="sxs-lookup"><span data-stu-id="6698a-216">The size of an MPSD session is determined by the number of members in that session.</span></span>


### <a name="maximum-session-size"></a><span data-ttu-id="6698a-217">セッションの最大サイズ</span><span class="sxs-lookup"><span data-stu-id="6698a-217">Maximum Session Size</span></span>

<span data-ttu-id="6698a-218">セッションの最大サイズは対応できるセッション メンバーの最大数です。</span><span class="sxs-lookup"><span data-stu-id="6698a-218">The maximum size of a session is the maximum number of session members it can accommodate.</span></span> <span data-ttu-id="6698a-219">これは **MultiplayerSessionConstants.MaxMembersInSession プロパティ**で表されます。</span><span class="sxs-lookup"><span data-stu-id="6698a-219">It is represented by the **MultiplayerSessionConstants.MaxMembersInSession Property**.</span></span> <span data-ttu-id="6698a-220">最大メンバー サイズは、/constants/system オブジェクトで設定されています。</span><span class="sxs-lookup"><span data-stu-id="6698a-220">The maximum member size is set in the /constants/system object.</span></span>

<span data-ttu-id="6698a-221">最大セッション サイズは 1 ～ 100 の範囲であり、作成時に設定しなければ、既定値の 100 になります。</span><span class="sxs-lookup"><span data-stu-id="6698a-221">The maximum session size is between 1 and 100 session members, and defaults to 100 if not set on creation.</span></span> <span data-ttu-id="6698a-222">必要なサイズが 100 を超える場合、セッションは「大きな」セッションと呼ばれ、特別な方法で設定されます。</span><span class="sxs-lookup"><span data-stu-id="6698a-222">If the required size is over 100, the session is called a "large" session and is set in a special way.</span></span>

<span data-ttu-id="6698a-223">セッションの最大サイズを設定すると、特定の切断シナリオで、空きスロットが埋まっているように見える可能性があります。</span><span class="sxs-lookup"><span data-stu-id="6698a-223">Setting a maximum size for a session can cause an open slot to appear as full during certain disconnect scenarios.</span></span> <span data-ttu-id="6698a-224">たとえば、ネットワークまたは電源の障害によりプレイヤーが切断された場合、遅延はセッションに直ちに反映されません。</span><span class="sxs-lookup"><span data-stu-id="6698a-224">For example, if a player becomes disconnected as a result of a network or power failure, the delay is not immediately reflected in the session.</span></span> <span data-ttu-id="6698a-225">メンバーは、「[MPSD の変更通知処理および切断検出](multiplayer-session-directory.md)」で説明されている切断検出機能を使用して非アクティブに設定されます。</span><span class="sxs-lookup"><span data-stu-id="6698a-225">The member is set to inactive using the disconnect detection feature described in [MPSD Change Notification Handling and Disconnect Detection](multiplayer-session-directory.md).</span></span>

<span data-ttu-id="6698a-226">それに対し、ハートビートを使用して切断を検出するピア メッシュは、多くの場合、2 ～ 3 秒以内に切断を認識し、プレイヤー スロットを即時に開くことができます。</span><span class="sxs-lookup"><span data-stu-id="6698a-226">In comparison, a peer mesh that uses a heartbeat to detect a disconnection is often aware of a disconnect within two to three seconds and can open up the player slot immediately.</span></span> <span data-ttu-id="6698a-227">しかし、アービターは他のメンバーを削除できません。</span><span class="sxs-lookup"><span data-stu-id="6698a-227">However, the arbiter cannot remove other members.</span></span>

### <a name="large-sessions"></a><span data-ttu-id="6698a-228">大きなセッション</span><span class="sxs-lookup"><span data-stu-id="6698a-228">Large Sessions</span></span>

<span data-ttu-id="6698a-229">大きな MPSD セッションは最大 1000 のメンバーを持つことができますが、すべてのメンバー一覧の取得など、いくつかのセッション機能が無効になります。</span><span class="sxs-lookup"><span data-stu-id="6698a-229">A large MPSD session can have up to 1000 members, but it has some session features disabled, such as getting a list of all members.</span></span> <span data-ttu-id="6698a-230">セッションの大きさは、**MultiplayerSessionCapabilities.Large プロパティ**によって表されます。</span><span class="sxs-lookup"><span data-stu-id="6698a-230">Session largeness is represented by the **MultiplayerSessionCapabilities.Large Property**.</span></span> <span data-ttu-id="6698a-231">大きなセッションを指定する場合はこのプロパティが true に設定され、"大きな" 機能は /constants/system/capabilities オブジェクトで示されます。</span><span class="sxs-lookup"><span data-stu-id="6698a-231">This property is set to true to indicate a large session, and the "large" capability is indicated in the /constants/system/capabilities object.</span></span> <span data-ttu-id="6698a-232">詳細については、「[セッション機能]()」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="6698a-232">For more information, see [Session Capabilities]().</span></span>

## <a name="session-user-states"></a><span data-ttu-id="6698a-233">セッションのユーザーの状態</span><span class="sxs-lookup"><span data-stu-id="6698a-233">Session User States</span></span>



<span data-ttu-id="6698a-234">MPSD では、ユーザーの状態を、セッションに追加されたユーザーのステータスとして定義します。</span><span class="sxs-lookup"><span data-stu-id="6698a-234">MPSD defines a user state as the status of a user who has been added to a session.</span></span> <span data-ttu-id="6698a-235">ユーザーの状態は、**MultiplayerSessionStatus 列挙型**で定義されています。</span><span class="sxs-lookup"><span data-stu-id="6698a-235">Possible user states are defined by the **MultiplayerSessionStatus Enumeration**.</span></span> <span data-ttu-id="6698a-236">また、ユーザーは、セッションに追加される前に "参加可能" のステータスを持つと見なされます。</span><span class="sxs-lookup"><span data-stu-id="6698a-236">The user also is considered to have a status of "available" before being added to a session.</span></span>

<span data-ttu-id="6698a-237">**MultiplayerSession.SetCurrentUserStatus メソッド**を使用して、セッションのユーザーの状態を変更できます。</span><span class="sxs-lookup"><span data-stu-id="6698a-237">The **MultiplayerSession.SetCurrentUserStatus Method** can be used to change the session user state.</span></span> <span data-ttu-id="6698a-238">この変更は、REST に対して、ゲーム セッションの JSON ドキュメントで /members/{index}/properties/system を正しく設定することによって実行できます。</span><span class="sxs-lookup"><span data-stu-id="6698a-238">This change can be made for REST by setting /members/{index}/properties/system correctly in the game session JSON document.</span></span>


### <a name="reserved-user-state"></a><span data-ttu-id="6698a-239">予約済みのユーザーの状態</span><span class="sxs-lookup"><span data-stu-id="6698a-239">Reserved User State</span></span>

<span data-ttu-id="6698a-240">アービターがセッション内の空きスロットの 1 つを埋めるためにユーザーを選択したとき、そのユーザーは予約済みのユーザーの状態になります。</span><span class="sxs-lookup"><span data-stu-id="6698a-240">The user is placed in the Reserved user state when the arbiter has selected the user to fill one of the open slots within the session.</span></span> <span data-ttu-id="6698a-241">この状態では、ユーザーはまだセッションへの招待を正式に受け入れていないか、またはピアとの接続を開始するためのセッションに参加していません。</span><span class="sxs-lookup"><span data-stu-id="6698a-241">In this state, the user has not yet officially accepted the invite to the session or joined the session to begin connecting with peers.</span></span>


### <a name="active-user-state"></a><span data-ttu-id="6698a-242">アクティブなユーザーの状態</span><span class="sxs-lookup"><span data-stu-id="6698a-242">Active User State</span></span>

<span data-ttu-id="6698a-243">ユーザーがアクティブな状態の場合、タイトルがユーザーの代わりにセッションに参加し、ユーザーはセッションにアクティブに参加します。</span><span class="sxs-lookup"><span data-stu-id="6698a-243">When a user is in the Active state, the title has joined the session on behalf of the user, and the user is actively participating in the session.</span></span> <span data-ttu-id="6698a-244">ユーザーがゲームをプレイしている限り、この状態が継続されます。</span><span class="sxs-lookup"><span data-stu-id="6698a-244">The user continues in this state as long as he/she is playing the game.</span></span>

<span data-ttu-id="6698a-245">タイトルでは、最初に起動したとき、通常はセッションの状態をチェックすることによって、ユーザーが既にいずれかのセッションのメンバーかどうかを確認する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6698a-245">When a title is first launched, it should check to see if the user is already a member of any sessions, typically by checking the session state.</span></span> <span data-ttu-id="6698a-246">ユーザーがセッション メンバーである場合、タイトルはすぐにゲームに移行し、参加しているすべてのローカル メンバーのユーザーの状態をアクティブに設定することができます。</span><span class="sxs-lookup"><span data-stu-id="6698a-246">If the user is a session member, the title can jump straight into the game, and set any participating local members to user state Active.</span></span>

<span data-ttu-id="6698a-247">ユーザーは、セッションでプレイしている間はアクティブ状態を維持する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6698a-247">A user should remain in the Active state while playing in the session.</span></span> <span data-ttu-id="6698a-248">ユーザーがゲーム内 UI でセッションを離れた場合、**MultiplayerSession.Leave メソッド**によってそのユーザーをセッションから削除する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6698a-248">If a user leaves the session through the in-game UI, the user should be removed from the session with the **MultiplayerSession.Leave Method**.</span></span> <span data-ttu-id="6698a-249">ユーザーが一時的にゲームを離れただけの場合は (タイトルが制限されたときのように)、タイトルは適切な時間だけユーザーをアクティブ状態に保つ必要があります。</span><span class="sxs-lookup"><span data-stu-id="6698a-249">If the user is only temporarily away from the game, as when the title is constrained, the title should keep the user in the Active state for a reasonable amount of time.</span></span> <span data-ttu-id="6698a-250">タイトルで指定されている時間が経過してもユーザーが戻らない場合は、ユーザーの状態を非アクティブに変更してください。</span><span class="sxs-lookup"><span data-stu-id="6698a-250">It is appropriate to change the user state to Inactive if the user has not returned after a title-specified period of time.</span></span>


### <a name="inactive-user-state"></a><span data-ttu-id="6698a-251">非アクティブなユーザーの状態</span><span class="sxs-lookup"><span data-stu-id="6698a-251">Inactive User State</span></span>

<span data-ttu-id="6698a-252">非アクティブ状態では、ユーザーは現在はゲームに参加していませんが、まだセッション内のスロットを確保しています。</span><span class="sxs-lookup"><span data-stu-id="6698a-252">In the Inactive state, the user is not currently engaged with the game but still has a saved slot in the session.</span></span> <span data-ttu-id="6698a-253">つまり、ユーザーは、"アクティブではない" 状態です。</span><span class="sxs-lookup"><span data-stu-id="6698a-253">In other words, the user is "not active."</span></span>

<span data-ttu-id="6698a-254">ユーザーをセッションで非アクティブなユーザーの状態に設定する責任があるのは、そのユーザー自身の本体です。</span><span class="sxs-lookup"><span data-stu-id="6698a-254">It is the user's own console that has responsibility for setting that user to user state Inactive in the session.</span></span> <span data-ttu-id="6698a-255">アービターはこの処理を実行できません。</span><span class="sxs-lookup"><span data-stu-id="6698a-255">The arbiter cannot perform this action.</span></span> <span data-ttu-id="6698a-256">ユーザーが非アクティブ状態になるシナリオの例を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="6698a-256">Example scenarios in which a user is put into the Inactive state include:</span></span>

-   <span data-ttu-id="6698a-257">タイトルが Suspending イベントを受け取る。</span><span class="sxs-lookup"><span data-stu-id="6698a-257">The title receives a Suspending event.</span></span>
-   <span data-ttu-id="6698a-258">タイトルによって定義された時間に渡ってユーザーの非アクティブ状態が続いた (入力またはコントローラーの応答がなかった)。</span><span class="sxs-lookup"><span data-stu-id="6698a-258">The user has been inactive (no input or controller response) for a period of time defined by the title.</span></span> <span data-ttu-id="6698a-259">対戦型マルチプレイヤーの場合の推奨値は 2 分です。</span><span class="sxs-lookup"><span data-stu-id="6698a-259">We recommend two minutes for a competitive multiplayer.</span></span>
-   <span data-ttu-id="6698a-260">タイトルが、2 分、またはタイトルで定義されている時間より長く制限モードになっている。</span><span class="sxs-lookup"><span data-stu-id="6698a-260">The title has been in constrained mode for more than two minutes, or for a period defined by the title.</span></span> <span data-ttu-id="6698a-261">この制限モードのタイムアウト時間は、ユーザーが関連アプリまたはタイトルに関係する他のエクスペリエンスを使用してタイトルから離れると予想される時間です。</span><span class="sxs-lookup"><span data-stu-id="6698a-261">This constrained mode timeout period is the expected amount of time for which a user might be away from the title using a related app or other experience related to the title.</span></span>
-   <span data-ttu-id="6698a-262">ユーザーがセッションから異常切断された。</span><span class="sxs-lookup"><span data-stu-id="6698a-262">The user has been disconnected ungracefully from the session.</span></span> <span data-ttu-id="6698a-263">「[MPSD の変更通知処理および切断検出](multiplayer-session-directory.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="6698a-263">See [MPSD Change Notification Handling and Disconnect Detection](multiplayer-session-directory.md).</span></span>

<span data-ttu-id="6698a-264">タイトルが起動し、特定のセッション メンバーのユーザーの状態が非アクティブに設定されている場合、タイトルが一時停止されているか、セッションでユーザーが長い間非アクティブになっています。</span><span class="sxs-lookup"><span data-stu-id="6698a-264">If the title starts and the user state for a particular session member is set to Inactive, the title has been suspended or the user has been inactive for too long in the session.</span></span> <span data-ttu-id="6698a-265">タイトルが再び起動しようとしているので、ユーザーが、自分が所属するゲーム セッションの続行を望んでいることを示しています。</span><span class="sxs-lookup"><span data-stu-id="6698a-265">Because the title is launching again, the indication is that the user wants to continue with the game session to which he or she belongs.</span></span> <span data-ttu-id="6698a-266">タイトルの起動時にユーザーの状態がアクティブの場合は、おそらく、ネットワークの切断、またはタイトルが中断される前にユーザーを非アクティブに設定できなかった他のシナリオが原因です。</span><span class="sxs-lookup"><span data-stu-id="6698a-266">If the user's state is Active on title launch, this situation is probably due to a network disconnect or another scenario where the title was unable to set the user to Inactive before being interrupted.</span></span> <span data-ttu-id="6698a-267">タイトルではどちらの場合も、ユーザーをゲームおよび他のユーザーと再接続してプレイを続けさせるか、ユーザーをセッションから削除するよう試みる必要があります。</span><span class="sxs-lookup"><span data-stu-id="6698a-267">In both of these cases, your title should attempt to reconnect the user with the game and the other users to continue playing, or remove the user from the session.</span></span>

### <a name="user-state-when-the-session-is-over"></a><span data-ttu-id="6698a-268">セッション終了時のユーザーの状態</span><span class="sxs-lookup"><span data-stu-id="6698a-268">User State When the Session is Over</span></span>

<span data-ttu-id="6698a-269">セッションが終了すると、ゲーム プレイは中止されます。</span><span class="sxs-lookup"><span data-stu-id="6698a-269">When the session is over, game play is discontinued.</span></span> <span data-ttu-id="6698a-270">タイトルは、**MultiplayerSession.Leave メソッド**を使用して、すべてのユーザーが自分自身を削除できるようにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="6698a-270">The title must allow all users to remove themselves using the **MultiplayerSession.Leave Method**.</span></span> <span data-ttu-id="6698a-271">セッションから抜けた場合、ユーザーに関連付けられているセッションのアクティビティは自動的にクリアされます。</span><span class="sxs-lookup"><span data-stu-id="6698a-271">The session activities associated with the users are automatically cleared when they leave the session.</span></span>

## <a name="visibility-and-joinability"></a><span data-ttu-id="6698a-272">可視性と参加可能性</span><span class="sxs-lookup"><span data-stu-id="6698a-272">Visibility and Joinability</span></span>

<span data-ttu-id="6698a-273">セッション アクセスは、セッションの可視性およびセッションの参加可能性という 2 つの設定によって MPSD レベルで制御されます。</span><span class="sxs-lookup"><span data-stu-id="6698a-273">Session access is controlled at the MPSD level by two settings: session visibility and session joinability.</span></span> <span data-ttu-id="6698a-274">ここで示す可視性と参加可能性に関する推奨事項は、最も一般的なタイトル シナリオに適用されます。</span><span class="sxs-lookup"><span data-stu-id="6698a-274">The visibility and joinability recommendations in this topic apply for the most common title scenarios.</span></span> <span data-ttu-id="6698a-275">タイトルでは、可能な限りこれらの設定に従うようにし、新しいプレイヤーにセッションへの参加を許可するかどうかについての最終的な正式決定をタイトル内ロジックを使用して行うようにします。</span><span class="sxs-lookup"><span data-stu-id="6698a-275">Titles should follow these settings, if possible, and they should use in-title logic to make the final, authoritative determination as to whether a new player is admitted into a session.</span></span>


### <a name="session-visibility"></a><span data-ttu-id="6698a-276">セッション可視性</span><span class="sxs-lookup"><span data-stu-id="6698a-276">Session Visibility</span></span>

<span data-ttu-id="6698a-277">セッションの可視性は、セッションの作成時に設定される定数で表されます。</span><span class="sxs-lookup"><span data-stu-id="6698a-277">Session visibility is represented by a constant that is set at session creation.</span></span> <span data-ttu-id="6698a-278">この定数は、通常、セッション テンプレートで定義され、セッションに対する読み取りアクセスと書き込みアクセスができるユーザーの種類を決定します。</span><span class="sxs-lookup"><span data-stu-id="6698a-278">It is typically defined in the session template and determines which types of users have read and write access to a session.</span></span> <span data-ttu-id="6698a-279">セッションの可視性で使用できる値は、**MultiplayerSessionVisibility 列挙型**によって定義されます。</span><span class="sxs-lookup"><span data-stu-id="6698a-279">The possible values for session visibility are defined by the **MultiplayerSessionVisibility Enumeration**.</span></span> <span data-ttu-id="6698a-280">JSON ファイルで可視性定数に許可される設定は、open、visible、および private です。</span><span class="sxs-lookup"><span data-stu-id="6698a-280">The settings permitted for the visibility constant in a JSON file are open, visible, and private.</span></span>


#### <a name="recommended-game-session-visibility-open"></a><span data-ttu-id="6698a-281">ゲーム セッションの推奨される可視性: open</span><span class="sxs-lookup"><span data-stu-id="6698a-281">Recommended game session visibility: open</span></span>

<span data-ttu-id="6698a-282">オープン状態のゲーム セッションでは、プレイヤーの予約を必要としないため、招待プロセスが簡素化されます。</span><span class="sxs-lookup"><span data-stu-id="6698a-282">Open game sessions do not require player reservations, which simplifies the invite process.</span></span> <span data-ttu-id="6698a-283">アービターは、招待が送信された後に MPSD でプレイヤーを予約せず、招待されたプレイヤーのローカルでの追跡のみを行います。</span><span class="sxs-lookup"><span data-stu-id="6698a-283">The arbiter does not reserve players in MPSD after an invite has been sent, but only tracks invited players locally.</span></span> <span data-ttu-id="6698a-284">したがって、プレイヤーはすぐにアービターに接続して、セッションに参加するか、拒否されるか、待機するか (待機中のプレイヤーがサポートされている場合) を判断できます。</span><span class="sxs-lookup"><span data-stu-id="6698a-284">Thus, players can immediately connect to the arbiter and determine whether they should join a session, are rejected, or should wait (if waiting players are supported).</span></span> <span data-ttu-id="6698a-285">アービターは最終的な権限を持っており、新しいメンバーに応答してセッションにとどまるか離れるかを指示します。</span><span class="sxs-lookup"><span data-stu-id="6698a-285">The arbiter is the ultimate authority and responds and instructs the new member to either stay in or leave the session.</span></span>

<span data-ttu-id="6698a-286">ゲーム セッションの可視性に open を使用すると、招待されたプレイヤーは、最終決定が行われる前にタイトルを起動してアービターに接続する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6698a-286">Using open game session visibility requires the invited player to launch a title and connect to the arbiter before the final decision has been made.</span></span> <span data-ttu-id="6698a-287">セッションがいっぱいの場合、または招待が拒否された場合は、ユーザーにエラー メッセージを表示することができます。</span><span class="sxs-lookup"><span data-stu-id="6698a-287">It is acceptable to display an error message to the user if a session is full or if an invite has been rejected.</span></span>

<span data-ttu-id="6698a-288">アービターへの接続を確立するには、セキュア デバイス アドレスが必要です。</span><span class="sxs-lookup"><span data-stu-id="6698a-288">To establish a connection to the arbiter, a secure device address is required.</span></span> <span data-ttu-id="6698a-289">**MultiplayerSessionProperties.HostDeviceToken プロパティ**は、どのセッション メンバーがセッションの現在のアービターであるか、および招待されたプレイヤーが接続にどのセキュア デバイス アドレスを使用する必要があるかを確認するために使用されます。</span><span class="sxs-lookup"><span data-stu-id="6698a-289">The **MultiplayerSessionProperties.HostDeviceToken Property** is used to find out which session member is the current arbiter of a session, and which secure device address an invited player should use for connection.</span></span>

### <a name="session-joinability"></a><span data-ttu-id="6698a-290">セッションの参加可能性</span><span class="sxs-lookup"><span data-stu-id="6698a-290">Session Joinability</span></span>

<span data-ttu-id="6698a-291">セッションの参加可能性は、セッションに参加できるユーザーの種類を決定します。</span><span class="sxs-lookup"><span data-stu-id="6698a-291">Session joinability determines which types of users can join a session.</span></span> <span data-ttu-id="6698a-292">これはセッション中に動的に設定できます。</span><span class="sxs-lookup"><span data-stu-id="6698a-292">It can be set dynamically during a session.</span></span> <span data-ttu-id="6698a-293">セッションの参加可能性で使用できる値は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="6698a-293">The possible values for session joinability are:</span></span>

-   <span data-ttu-id="6698a-294">None (既定) -- セッションに参加できるユーザーに関する制限はありません。</span><span class="sxs-lookup"><span data-stu-id="6698a-294">None (default) -- there are no restrictions on who can join the session.</span></span>
-   <span data-ttu-id="6698a-295">Local -- ローカル ユーザーのみがセッションに参加できます。</span><span class="sxs-lookup"><span data-stu-id="6698a-295">Local -- only local users can join the session.</span></span>
-   <span data-ttu-id="6698a-296">Followed -- ローカル ユーザーおよび他のセッション メンバーによってフォローされているユーザーのみが予約なしでセッションに参加できます。</span><span class="sxs-lookup"><span data-stu-id="6698a-296">Followed -- only local users and users who are followed by other session members can join the session without a reservation.</span></span>

<span data-ttu-id="6698a-297">セッションのアービターは、参加可能性の設定によってプライベート セッションを作成できます。</span><span class="sxs-lookup"><span data-stu-id="6698a-297">A session arbiter can create a private session through the joinability setting.</span></span> <span data-ttu-id="6698a-298">参加可能性を Local または Followed にすると、セッションへのアクセスが制限され、そのセッションはプライベートになります。</span><span class="sxs-lookup"><span data-stu-id="6698a-298">Making joinability either local or followed restricts access to the session and makes it private.</span></span>

<span data-ttu-id="6698a-299">さらに、アービターは必要に応じて、セッションの参加可能性を追跡してホスト レベルで古いセッションへの招待を拒否できるようにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="6698a-299">Additionally, the arbiter should keep track of session joinability so that older session invites can be rejected at the host level if needed.</span></span> <span data-ttu-id="6698a-300">たとえば、セッションがいっぱいになるまで招待されたプレイヤーがセッションへの参加に至らなかった場合、アービターは、セッションがロックされており、セッションを離れる必要があることを、これから参加するプレイヤーに自動的に指示できます。</span><span class="sxs-lookup"><span data-stu-id="6698a-300">For example, if any invited players have not arrived to join a session until the session is already full, the arbiter can instruct the joining players that the session has been locked and they need to leave the session automatically.</span></span>

## <a name="session-timeouts"></a><span data-ttu-id="6698a-301">セッション タイムアウト</span><span class="sxs-lookup"><span data-stu-id="6698a-301">Session Timeouts</span></span>

<span data-ttu-id="6698a-302">タイマーおよびその他の外部イベントによってセッションを変更できます。</span><span class="sxs-lookup"><span data-stu-id="6698a-302">Sessions can be changed by timers and other external events.</span></span> <span data-ttu-id="6698a-303">セッション タイムアウトでは、自動的に非アクティブになる、またはセッションから削除される前に、セッション メンバーが特定の状態を維持できる期間を定義します。</span><span class="sxs-lookup"><span data-stu-id="6698a-303">Session timeouts define the periods for which session members can remain in specific states before they are automatically made inactive or removed from the session.</span></span> <span data-ttu-id="6698a-304">MPSD では、セッションの有効期間を管理するためのタイムアウトもサポートされます。</span><span class="sxs-lookup"><span data-stu-id="6698a-304">MPSD also supports timeouts to manage session lifetime.</span></span>

| <span data-ttu-id="6698a-305">注意</span><span class="sxs-lookup"><span data-stu-id="6698a-305">Note</span></span>                                                                                                                                                                                                                                                           |
|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="6698a-306">テンプレート コントラクト バージョン 104/105 の場合、タイムアウトの設定は \constants\system\timeouts または初期化の管理オブジェクト内で行います。</span><span class="sxs-lookup"><span data-stu-id="6698a-306">Timeout settings are made in /constants/system/timeouts, or within the managed initialization object, for template contract version 104/105.</span></span> <span data-ttu-id="6698a-307">107 以降のバージョンの場合、設定は \constants\system または初期化の管理オブジェクト内で個別に行います。</span><span class="sxs-lookup"><span data-stu-id="6698a-307">For version 107 or later, the settings are made individually in /constants/system or within the managed initialization object.</span></span> |

<span data-ttu-id="6698a-308">タイマーの期限が切れると、MPSD は自動的にはセッションを更新せず、変化が起きたその時点でアービターに通知します。</span><span class="sxs-lookup"><span data-stu-id="6698a-308">When a timer expires, MPSD does not automatically update the session and notify the arbiter at that instant of any changes.</span></span> <span data-ttu-id="6698a-309">セッションおよびタイムアウト状態は、読み取りまたは書き込み要求が送信される直前にだけ更新されます。</span><span class="sxs-lookup"><span data-stu-id="6698a-309">The session and timeout states are only updated immediately before a read or write request is sent.</span></span> <span data-ttu-id="6698a-310">直前に更新することで、返されるデータが確実に最新のものになります。</span><span class="sxs-lookup"><span data-stu-id="6698a-310">Immediate update ensures that the data returned is the most up to date.</span></span>

| <span data-ttu-id="6698a-311">注意</span><span class="sxs-lookup"><span data-stu-id="6698a-311">Note</span></span>                                                                                                          |
|----------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="6698a-312">セッション タイムアウトはスタックされず、各セッション メンバーの更新時の状態遷移に対して 1 回だけ適用されます。</span><span class="sxs-lookup"><span data-stu-id="6698a-312">Session timeouts are not stacked, and only one is applied for a state transition against each session member on an update.</span></span> |


### <a name="currently-defined-timeouts"></a><span data-ttu-id="6698a-313">現在定義されているタイムアウト</span><span class="sxs-lookup"><span data-stu-id="6698a-313">Currently Defined Timeouts</span></span>

<span data-ttu-id="6698a-314">ここでは、MPSD で現在定義されているタイムアウトについて説明します。</span><span class="sxs-lookup"><span data-stu-id="6698a-314">This section describes the timeouts that are currently defined by MPSD.</span></span> <span data-ttu-id="6698a-315">すべてのタイムアウトはミリ秒単位で指定します。</span><span class="sxs-lookup"><span data-stu-id="6698a-315">All timeouts are specified in milliseconds.</span></span> <span data-ttu-id="6698a-316">即時のタイムアウトを示す 値 0 を指定できます。</span><span class="sxs-lookup"><span data-stu-id="6698a-316">A value of 0 is allowed and indicates an immediate timeout.</span></span> <span data-ttu-id="6698a-317">値を持たないタイムアウトは無制限と見なされます。</span><span class="sxs-lookup"><span data-stu-id="6698a-317">A timeout with no value is considered infinite.</span></span> <span data-ttu-id="6698a-318">タイムアウトには既定値があるため、タイムアウトを無期限にするには、null を明示的に指定してください。</span><span class="sxs-lookup"><span data-stu-id="6698a-318">Since the timeouts have defaults, you should explicitly specify null for an infinite timeout.</span></span>
#### <a name="evaluationtimeout"></a><span data-ttu-id="6698a-319">evaluationTimeout</span><span class="sxs-lookup"><span data-stu-id="6698a-319">evaluationTimeout</span></span>

<span data-ttu-id="6698a-320">このタイムアウトは、セッション メンバーが評価の決定を行ってアップロードしなければならない時間を示します。</span><span class="sxs-lookup"><span data-stu-id="6698a-320">This timeout indicates the amount of time for a session member to make and upload the evaluation decision.</span></span> <span data-ttu-id="6698a-321">決定が受信されない場合、失敗としてカウントされます。</span><span class="sxs-lookup"><span data-stu-id="6698a-321">If no decision is received, the decision counts as a failure.</span></span> <span data-ttu-id="6698a-322">このタイムアウトは、初期化の管理オブジェクトに配置されます。</span><span class="sxs-lookup"><span data-stu-id="6698a-322">This timeout is placed in the managed initialization object.</span></span>


#### <a name="inactiveremovaltimeout"></a><span data-ttu-id="6698a-323">inactiveRemovalTimeout</span><span class="sxs-lookup"><span data-stu-id="6698a-323">inactiveRemovalTimeout</span></span>

<span data-ttu-id="6698a-324">このタイムアウトは、セッションに参加しているが、現在はゲームに参加していないセッション メンバーに対して設定されます。</span><span class="sxs-lookup"><span data-stu-id="6698a-324">This timeout is set for a session member who has joined a session but is not currently engaged in the game.</span></span> <span data-ttu-id="6698a-325">メンバーは、既定では 2 時間後にセッションから削除されます。</span><span class="sxs-lookup"><span data-stu-id="6698a-325">The member is removed from the session after 2 hours, by default.</span></span>

| <span data-ttu-id="6698a-326">注意</span><span class="sxs-lookup"><span data-stu-id="6698a-326">Note</span></span>                                                                      |
|----------------------------------------------------------------------------------------|
| <span data-ttu-id="6698a-327">このタイムアウトは、テンプレート コントラクト バージョン 104/105 では非アクティブ タイムアウトと呼ばれています。</span><span class="sxs-lookup"><span data-stu-id="6698a-327">This timeout is designated the inactive timeout for template contract version 104/105.</span></span> |

<span data-ttu-id="6698a-328">多くの場合、非アクティブ タイムアウトは 0 に設定することをお勧めします。これにより、非アクティブ状態に設定されたユーザーは、すぐにセッションから削除されて、対応するスロットはクリアされます。</span><span class="sxs-lookup"><span data-stu-id="6698a-328">In many cases, we recommend setting the inactive timeout to 0, causing any user who is set to the inactive state to be removed immediately from the session and the corresponding slot to be cleared.</span></span> <span data-ttu-id="6698a-329">この動作は、ユーザーが非アクティブになるか非アクティブ状態に達した場合に、新しいプレイヤーをすぐに追加できるので、ほとんどの対戦型マルチプレイヤー ゲームに適しています。</span><span class="sxs-lookup"><span data-stu-id="6698a-329">This behavior is desirable for most competitive multiplayer games so that, if a user has gone inactive or reached an inactive state, a new player can be added quickly.</span></span> <span data-ttu-id="6698a-330">協力型またはその他のマルチプレイヤー設計のタイトルでは、ユーザーが切断された場合またはしばらくタイトルに参加していない場合に、ユーザーが再接続できる時間をもう少し長くすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="6698a-330">For co-op or other multiplayer designs, you might want your title to allow users more time to reconnect if they are disconnected or not engaged in the title for periods of time.</span></span> <span data-ttu-id="6698a-331">すべての設計シナリオに適合する単一のソリューションはありません。</span><span class="sxs-lookup"><span data-stu-id="6698a-331">Note that no single solution fits all design scenarios.</span></span>

#### <a name="jointimeout"></a><span data-ttu-id="6698a-332">joinTimeout</span><span class="sxs-lookup"><span data-stu-id="6698a-332">joinTimeout</span></span>

<span data-ttu-id="6698a-333">このタイムアウトは、ユーザーがセッションに参加しなければならないミリ秒数を示します。</span><span class="sxs-lookup"><span data-stu-id="6698a-333">This timeout indicates the number of milliseconds that a user has to join the session.</span></span> <span data-ttu-id="6698a-334">参加に失敗したユーザーの予約は削除されます。</span><span class="sxs-lookup"><span data-stu-id="6698a-334">Reservations of users who fail to join are removed.</span></span> <span data-ttu-id="6698a-335">このタイムアウトは、初期化の管理オブジェクトに配置されます。</span><span class="sxs-lookup"><span data-stu-id="6698a-335">This timeout is placed in the managed initialization object.</span></span>


#### <a name="measurementtimeout"></a><span data-ttu-id="6698a-336">measurementTimeout</span><span class="sxs-lookup"><span data-stu-id="6698a-336">measurementTimeout</span></span>

<span data-ttu-id="6698a-337">このタイムアウトは、セッション メンバーが測定値をアップロードしなければならない時間を示します。</span><span class="sxs-lookup"><span data-stu-id="6698a-337">This timeout indicates the amount of time a session member has to upload measurements.</span></span> <span data-ttu-id="6698a-338">測定値のアップロードに失敗したメンバーには、失敗理由として "タイムアウト" が設定されます。</span><span class="sxs-lookup"><span data-stu-id="6698a-338">A member who fails to upload measurements is marked with a failure reason of "timeout".</span></span> <span data-ttu-id="6698a-339">このタイムアウトは、初期化の管理オブジェクトに配置されます。</span><span class="sxs-lookup"><span data-stu-id="6698a-339">This timeout is placed in the managed initialization object.</span></span>

| <span data-ttu-id="6698a-340">注意</span><span class="sxs-lookup"><span data-stu-id="6698a-340">Note</span></span>                                                                                                                                                                              |
|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="6698a-341">マッチメイキング中に、QoS 測定に 45 秒間のタイムアウトが適用されます。</span><span class="sxs-lookup"><span data-stu-id="6698a-341">During matchmaking, a 45-second timeout for QoS measurements is enforced.</span></span> <span data-ttu-id="6698a-342">したがって、マッチメイキング中に 30 秒以内の測定タイムアウトを使用することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="6698a-342">Therefore we recommend the use of a measurement timeout that is less than or equal to 30 seconds during matchmaking.</span></span> |


#### <a name="readyremovaltimeout"></a><span data-ttu-id="6698a-343">readyRemovalTimeout</span><span class="sxs-lookup"><span data-stu-id="6698a-343">readyRemovalTimeout</span></span>

<span data-ttu-id="6698a-344">このタイムアウトは、セッションに参加していて、ゲームに参加しようとしているセッション メンバーに対して設定されます。</span><span class="sxs-lookup"><span data-stu-id="6698a-344">This timeout is set for a session member who has joined the session and is trying to get into the game.</span></span> <span data-ttu-id="6698a-345">これは通常、シェルがタイトルに代わってユーザーを参加させ、タイトルが起動中であることを意味します。</span><span class="sxs-lookup"><span data-stu-id="6698a-345">This usually means that the shell has joined the user on behalf of the title and the title is being launched.</span></span> <span data-ttu-id="6698a-346">メンバーは、セッションから削除され、既定では、3 分後に非アクティブ状態になります。</span><span class="sxs-lookup"><span data-stu-id="6698a-346">The member is removed from the session and placed in the inactive state after 3 minutes, by default.</span></span>

| <span data-ttu-id="6698a-347">注意</span><span class="sxs-lookup"><span data-stu-id="6698a-347">Note</span></span>                                                          |
|----------------------------------------------------------------------------|
| <span data-ttu-id="6698a-348">このタイムアウトは、コントラクト バージョン 104/105 では準備完了タイムアウトと呼ばれています。</span><span class="sxs-lookup"><span data-stu-id="6698a-348">This timeout is designated the ready timeout for contract version 104/105.</span></span> |


#### <a name="reservedremovaltimeout"></a><span data-ttu-id="6698a-349">reservedRemovalTimeout</span><span class="sxs-lookup"><span data-stu-id="6698a-349">reservedRemovalTimeout</span></span>

<span data-ttu-id="6698a-350">このタイムアウトは、他のユーザーによってセッションに追加されたが、まだセッションに参加していないセッション メンバーに対して設定されます。</span><span class="sxs-lookup"><span data-stu-id="6698a-350">This timeout is set for a session member who has been added to the session by someone else, but has not yet joined the session.</span></span> <span data-ttu-id="6698a-351">タイムアウト時間が経過すると、予約は削除され、メンバーは非アクティブと見なされます。</span><span class="sxs-lookup"><span data-stu-id="6698a-351">The reservation is deleted and the member is considered inactive when the timeout expires.</span></span> <span data-ttu-id="6698a-352">既定値は 30 秒です。</span><span class="sxs-lookup"><span data-stu-id="6698a-352">The default value is 30 seconds.</span></span>

| <span data-ttu-id="6698a-353">注意</span><span class="sxs-lookup"><span data-stu-id="6698a-353">Note</span></span>                                                             |
|-------------------------------------------------------------------------------|
| <span data-ttu-id="6698a-354">このタイムアウトは、コントラクト バージョン 104/105 では予約タイムアウトと呼ばれています。</span><span class="sxs-lookup"><span data-stu-id="6698a-354">This timeout is designated the reserved timeout for contract version 104/105.</span></span> |


#### <a name="sessionemptytimeout"></a><span data-ttu-id="6698a-355">sessionEmptyTimeout</span><span class="sxs-lookup"><span data-stu-id="6698a-355">sessionEmptyTimeout</span></span>

<span data-ttu-id="6698a-356">このタイムアウトは、セッションが空になってから削除されるまでのミリ秒数を示します。</span><span class="sxs-lookup"><span data-stu-id="6698a-356">This timeout indicates the number of milliseconds after a session becomes empty when it is deleted.</span></span> <span data-ttu-id="6698a-357">既定値は 0 です。</span><span class="sxs-lookup"><span data-stu-id="6698a-357">The default value is 0.</span></span>

| <span data-ttu-id="6698a-358">注意</span><span class="sxs-lookup"><span data-stu-id="6698a-358">Note</span></span>                                                                 |
|-----------------------------------------------------------------------------------|
| <span data-ttu-id="6698a-359">このタイムアウトは、コントラクト バージョン 104/105 では sessionEmpty タイムアウトと呼ばれています。</span><span class="sxs-lookup"><span data-stu-id="6698a-359">This timeout is designated the sessionEmpty timeout for contract version 104/105.</span></span> |


### <a name="session-timeout-example"></a><span data-ttu-id="6698a-360">セッション タイムアウトの例</span><span class="sxs-lookup"><span data-stu-id="6698a-360">Session Timeout Example</span></span>

1.  <span data-ttu-id="6698a-361">4 人のプレイヤーでセッションが開始されます。</span><span class="sxs-lookup"><span data-stu-id="6698a-361">A session is started with four players.</span></span>
2.  <span data-ttu-id="6698a-362">2 人のプレイヤー A と B が電源障害によって切断されます。</span><span class="sxs-lookup"><span data-stu-id="6698a-362">Two players, A and B, are disconnected due to a power failure.</span></span> <span data-ttu-id="6698a-363">ゲーム内で A と B の状態は Active のままです。</span><span class="sxs-lookup"><span data-stu-id="6698a-363">Their status in the game remains Active.</span></span>
3.  <span data-ttu-id="6698a-364">他の 2 人のプレイヤー C と D は、**MultiplayerSession.Leave メソッド**を使用して正しく終了します。</span><span class="sxs-lookup"><span data-stu-id="6698a-364">The other two players, C and D, quit properly using the **MultiplayerSession.Leave Method**.</span></span>
4.  <span data-ttu-id="6698a-365">プレイヤー A と B は切断されていますがまだ Active 状態であるため、セッションは開いたままになります。</span><span class="sxs-lookup"><span data-stu-id="6698a-365">The session remains open, with Players A and B disconnected but still in the Active state.</span></span>
5.  <span data-ttu-id="6698a-366">数日後、プレイヤー A が戻ってゲームを開始します。</span><span class="sxs-lookup"><span data-stu-id="6698a-366">A few days later, Player A returns and starts the game.</span></span>
6.  <span data-ttu-id="6698a-367">プレイヤー A のゲームは、A がメンバーであるセッションをチェックし (読み取りを実行し)、孤立した数日前のセッションを見つけます。</span><span class="sxs-lookup"><span data-stu-id="6698a-367">Player A's game checks for sessions that A is a member of (performs a read) and finds the orphaned session from a few days ago.</span></span>
7.  <span data-ttu-id="6698a-368">セッションは、まだセッション内にいる 2 人のプレイヤー (A および B) に対して、プレゼンスのチェックを行います。</span><span class="sxs-lookup"><span data-stu-id="6698a-368">The session does a presence check against the two players who are still in the session (A and B).</span></span>
    1.  <span data-ttu-id="6698a-369">プレイヤー A はタイトルを実行しているので、プレイヤー A に対するプレゼンス チェックは成功し、マッチ内のプレイヤーの Active 状態は変わりません。</span><span class="sxs-lookup"><span data-stu-id="6698a-369">Because Player A is running the title, the presence check against Player A succeeds, and the player's Active state in the match stays the same.</span></span>
    2.  <span data-ttu-id="6698a-370">プレイヤー B は、タイトルを実行していません。</span><span class="sxs-lookup"><span data-stu-id="6698a-370">Player B is not running the title.</span></span> <span data-ttu-id="6698a-371">したがって、プレイヤー B のプレゼンス チェックは失敗し、サービスはプレイヤー B の状態を非アクティブに設定します。</span><span class="sxs-lookup"><span data-stu-id="6698a-371">Thus, the presence check for Player B fails and the service sets Player B's state to Inactive.</span></span> <span data-ttu-id="6698a-372">この時点で、プレイヤー B に対する非アクティブ タイムアウトが開始します。</span><span class="sxs-lookup"><span data-stu-id="6698a-372">At this point, the inactive timeout starts for Player B.</span></span>

8.  <span data-ttu-id="6698a-373">プレイヤー A は、**Leave** メソッドを使用して正しくセッションを終了します。</span><span class="sxs-lookup"><span data-stu-id="6698a-373">Player A exits the session properly using the **Leave** method.</span></span>
9.  <span data-ttu-id="6698a-374">プレイヤー B の非アクティブ タイムアウトが経過し、プレイヤー B はだれかによる次の読み取りまたは書き込み時にセッションから削除されます。</span><span class="sxs-lookup"><span data-stu-id="6698a-374">The inactive timeout expires for Player B, who is removed from the session on the next read or write by anyone.</span></span>
10. <span data-ttu-id="6698a-375">セッションは、メンバーが 0 になったので、サービスから削除されます。</span><span class="sxs-lookup"><span data-stu-id="6698a-375">The session now has zero members and is removed from the service.</span></span>

<span data-ttu-id="6698a-376">例のセッションの非アクティブ タイムアウトが 0 に設定されている場合、プレイヤー B は、手順 7a でのプレゼンス チェックの直後にタイムアウトし、セッション書き込みによっておそらく削除されます。</span><span class="sxs-lookup"><span data-stu-id="6698a-376">If the inactive timeout for the example session is set to 0, Player B times out immediately after the presence check in step 7a and is probably removed by the session write.</span></span> <span data-ttu-id="6698a-377">この場合、セッションは、セッションへの追加の読み取りまたは書き込みがなくても閉じられます。</span><span class="sxs-lookup"><span data-stu-id="6698a-377">In this case, the session closes without the need of an additional read from or write to the session.</span></span>


## <a name="multiple-signed-in-users-on-a-single-console"></a><span data-ttu-id="6698a-378">1 台の本体にサインインした複数のユーザー</span><span class="sxs-lookup"><span data-stu-id="6698a-378">Multiple Signed-in Users on a Single Console</span></span>


<span data-ttu-id="6698a-379">同じ本体に複数のユーザーがサインインした場合、ゲーム セッションに含まれるユーザーと、ゲーム セッションに含まれないユーザー、または現在のタイトルでアクティブではないユーザーが混在することがあります。</span><span class="sxs-lookup"><span data-stu-id="6698a-379">When multiple users are signed in on the same console, it's possible for some users to be in a game session while other users are not in the session or are not active in the current title.</span></span> <span data-ttu-id="6698a-380">複数のユーザーがゲームの招待を受け取って受け入れる場合もあり、ゲーム セッションのメンバーシップに影響があります。</span><span class="sxs-lookup"><span data-stu-id="6698a-380">Game invites can also be received and accepted for multiple users, having an impact on game session membership.</span></span> <span data-ttu-id="6698a-381">タイトルでは、これらの点を考慮し、セッション メンバーシップのすべてのシナリオを正しく処理できる必要があります。</span><span class="sxs-lookup"><span data-stu-id="6698a-381">A title needs to consider these points to be able to handle all session membership scenarios correctly.</span></span>

<span data-ttu-id="6698a-382">一般的なシナリオでは、新しいプレイヤーがサインインし、ゲームでアクティブになり、既存のゲーム セッションに追加される必要があります。</span><span class="sxs-lookup"><span data-stu-id="6698a-382">In a common scenario, a new player signs in, becomes active in the game, and needs to be added to an existing game session.</span></span> <span data-ttu-id="6698a-383">新しいゲーム セッションの作成と同様に、タイトルはゲーム プレイ中の適切なときにのみ、ユーザーを追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6698a-383">As with creating a new game session, a title should only add a user when it is appropriate during game play.</span></span>

<span data-ttu-id="6698a-384">サインインしたユーザーが複数いる場合、その中の 1 人以上が別のゲーム セッションへの招待を受け取ることもあります。</span><span class="sxs-lookup"><span data-stu-id="6698a-384">With multiple signed-in users, one or more users can also receive invites to another game session.</span></span> <span data-ttu-id="6698a-385">タイトルではこのようなシナリオを特定の方法で処理する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="6698a-385">Titles do not need to handle these scenarios in any specific way.</span></span> <span data-ttu-id="6698a-386">セッションの状態およびメンバーのイベントが、ゲーム セッションおよびユーザー メンバーシップに対するすべての更新をタイトルに通知します。</span><span class="sxs-lookup"><span data-stu-id="6698a-386">Session state and member events notify the title of any updates to the game session and user membership.</span></span>

<span data-ttu-id="6698a-387">オンライン セッションにサインインした複数のユーザーを処理するために、タイトルはユーザーごとに別々の **XboxLiveContext クラス** オブジェクトを使用して、すべてのユーザーについてショルダー タップをサブスクライブします。</span><span class="sxs-lookup"><span data-stu-id="6698a-387">To handle multiple signed-in users for an online session, the title subscribes for shoulder taps for all users, using a separate **XboxLiveContext Class** object for each user.</span></span> <span data-ttu-id="6698a-388">タイトルは **MultiplayerSession.ChangeNumber プロパティ**を使用してセッションの特定の変更を確認して、重複ショルダー タップを無視します。</span><span class="sxs-lookup"><span data-stu-id="6698a-388">The title uses the **MultiplayerSession.ChangeNumber Property** to determine particular changes in the session and ignore duplicate shoulder taps.</span></span>


## <a name="process-lifecycle-management"></a><span data-ttu-id="6698a-389">プロセス ライフサイクル管理</span><span class="sxs-lookup"><span data-stu-id="6698a-389">Process Lifecycle Management</span></span>


<span data-ttu-id="6698a-390">非マルチプレイヤー タイトルと同様に、マルチプレイヤー セッション内のタイトルで、タイトルの一時停止やプロセス ライフサイクル イベントの終了が発生することがあります。</span><span class="sxs-lookup"><span data-stu-id="6698a-390">Just like a non-multiplayer title, a title in a multiplayer session can encounter title suspension and termination of process lifecycle events.</span></span> <span data-ttu-id="6698a-391">したがって、セッション アービターは定期的にセッション状態を保存する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6698a-391">The session arbiter should therefore save session state periodically.</span></span> <span data-ttu-id="6698a-392">アービターが一時停止された場合、タイトルはアービターの移行を試みて、新しいアービターがセッションの状態を復元できるように、必要に応じてゲーム状態を保存する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6698a-392">In case the arbiter is suspended, the title should attempt arbiter migration and save the game state as appropriate, so that a new arbiter can restore session state.</span></span> <span data-ttu-id="6698a-393">セッションが MPSD でまだ有効である限り、マルチプレイヤー セッション全体を一時停止し、後で再開することができます。</span><span class="sxs-lookup"><span data-stu-id="6698a-393">It is then possible for a full multiplayer session to be suspended and resumed later, as long as the session is still valid in MPSD.</span></span> <span data-ttu-id="6698a-394">指定されているただ 1 つのピア (通常はゲーム ホスト) が、グローバルなゲーム状態を更新する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6698a-394">Only one designated peer, typically the game host, should update the global game state.</span></span>


### <a name="storage-of-game-metadata"></a><span data-ttu-id="6698a-395">ゲーム メタデータのストレージ</span><span class="sxs-lookup"><span data-stu-id="6698a-395">Storage of Game Metadata</span></span>

<span data-ttu-id="6698a-396">タイトルは、MPSD セッション内にゲーム メタデータを格納します。</span><span class="sxs-lookup"><span data-stu-id="6698a-396">A title stores game metadata in the MPSD session.</span></span> <span data-ttu-id="6698a-397">ゲーム メタデータは、セッション データを表示し、タイトルがゲーム セッションを見つけて参加できるようにするために必要な情報です。</span><span class="sxs-lookup"><span data-stu-id="6698a-397">Game metadata is the information needed to display session data and enable the title to find and join the game session.</span></span> <span data-ttu-id="6698a-398">タイトルはプレイヤー固有のメタデータ (プレイヤーの色、プレイヤーがセッションで優先的に使用する武器など) をそのセッション メンバーのカスタム プロパティ セクションに保存します。現在のマップなどのセッション全体のメタデータは、MPSD セッションのグローバル カスタム プロパティ セクションに保存されます。</span><span class="sxs-lookup"><span data-stu-id="6698a-398">The title stores player-specific metadata in the custom properties section for the session member, for example, player color, preferred player weapon for the session, etc. Session-wide metadata, for example, current map, is stored in the global custom properties section of the MPSD session.</span></span>


### <a name="storage-of-game-state"></a><span data-ttu-id="6698a-399">ゲーム状態のストレージ</span><span class="sxs-lookup"><span data-stu-id="6698a-399">Storage of Game State</span></span>

<span data-ttu-id="6698a-400">ゲームの状態は、**タイトル ストレージ サービス**を使用してタイトル管理ストレージ (TMS) に保存されます。</span><span class="sxs-lookup"><span data-stu-id="6698a-400">Game state is stored in title-managed storage (TMS), using the **title storage service**.</span></span> <span data-ttu-id="6698a-401">この場所を使用するストレージにより、タイトルはアクセス許可の問題なしにアービターを移行できます。</span><span class="sxs-lookup"><span data-stu-id="6698a-401">Storage using this location allows a title to migrate the arbiter without permission concerns.</span></span> <span data-ttu-id="6698a-402">「[アービターの移行](migrating-an-arbiter.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="6698a-402">See [Migrating an Arbiter](migrating-an-arbiter.md).</span></span>

| <span data-ttu-id="6698a-403">注意</span><span class="sxs-lookup"><span data-stu-id="6698a-403">Note</span></span>                                                                                                               |
|---------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="6698a-404">タイトルが、一時停止されている場合を除き、5 分に 1 回よりも高い頻度で TMS にゲーム状態を保存しないようにしてください。</span><span class="sxs-lookup"><span data-stu-id="6698a-404">The title should not attempt to save game state to TMS more frequently than once every 5 minutes, unless it is being suspended.</span></span> |

## <a name="cleanup-of-inactive-sessions"></a><span data-ttu-id="6698a-405">非アクティブなセッションのクリーンアップ</span><span class="sxs-lookup"><span data-stu-id="6698a-405">Cleanup of Inactive Sessions</span></span>

<span data-ttu-id="6698a-406">sessionEmptyTimeout が 0 に設定されている場合、最後のプレイヤーがセッションを離れると、MPSD セッションは自動的に削除されます。</span><span class="sxs-lookup"><span data-stu-id="6698a-406">If the sessionEmptyTimeout is set to 0, an MPSD session is automatically deleted when the last player leaves the session.</span></span> <span data-ttu-id="6698a-407">クラッシュ後または切断後に未使用のセッションにプレイヤーが含まれないようにする方法を調べるには、「[MPSD の変更通知処理および切断検出](multiplayer-session-directory.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="6698a-407">To learn how to prevent an unused sessions from containing players after crash or disconnection, see [MPSD Change Notification Handling and Disconnect Detection.](multiplayer-session-directory.md).</span></span> <span data-ttu-id="6698a-408">クラッシュ後または切断後に未使用のセッションが不適切に処理されると、タイトルがプレイヤーのセッションをクエリするときに問題が発生する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="6698a-408">Improper handling of unused sessions after crash or disconnect can cause issues when a title is querying sessions for a player.</span></span>

<span data-ttu-id="6698a-409">非アクティブなセッションをクリーンアップするための推奨される方法は、タイトルで **MultiplayerService.GetSessionsAsync メソッド**を呼び出してからセッションを評価することによって、特定のユーザーのすべてのセッションをクエリすることです。</span><span class="sxs-lookup"><span data-stu-id="6698a-409">The recommended way to clean up inactive sessions is to have the title query all sessions for a particular user by calling the **MultiplayerService.GetSessionsAsync Method** and then evaluating the sessions.</span></span> <span data-ttu-id="6698a-410">古いセッションを検出すると、タイトルはセッション内のすべてのローカル プレイヤーに対して **MultiplayerSession.Leave メソッド**を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="6698a-410">When it encounters a stale session, the title calls the **MultiplayerSession.Leave Method** for all local players in the session.</span></span> <span data-ttu-id="6698a-411">この呼び出しは最終的にメンバー数を 0 まで減らし、セッションをクリーンアップします。</span><span class="sxs-lookup"><span data-stu-id="6698a-411">This call drops the member count to 0 eventually and cleans up the sessions.</span></span>

## <a name="session-arbiter"></a><span data-ttu-id="6698a-412">セッション アービター</span><span class="sxs-lookup"><span data-stu-id="6698a-412">Session Arbiter</span></span>


<span data-ttu-id="6698a-413">一部のマルチプレイヤー メソッドは、ゲーム セッション内の 1 つのクライアントによってのみ呼び出される必要があります。</span><span class="sxs-lookup"><span data-stu-id="6698a-413">Some multiplayer methods should only be called by one client within a game session.</span></span> <span data-ttu-id="6698a-414">このクライアントは、セッションに参加している本体の 1 つで、アービター、またはホストと呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="6698a-414">This client is one of the consoles participating in the session, called the arbiter, or the host.</span></span> <span data-ttu-id="6698a-415">少なくとも 1 人のセッション メンバーがゲームにいる場合、セッションには途中参加を監視するアービターが必要です。</span><span class="sxs-lookup"><span data-stu-id="6698a-415">If at least one session member is in a game, the session should have an arbiter to monitor joins in progress.</span></span>


### <a name="setting-the-arbiter"></a><span data-ttu-id="6698a-416">アービターの設定</span><span class="sxs-lookup"><span data-stu-id="6698a-416">Setting the Arbiter</span></span>

<span data-ttu-id="6698a-417">セッションの作成時に、クライアントはアービターとして 1 つの本体を指定します。</span><span class="sxs-lookup"><span data-stu-id="6698a-417">When it creates a session, the client designates one console as the arbiter.</span></span> <span data-ttu-id="6698a-418">「[方法: MPSD セッションのアービターの設定](multiplayer-how-tos.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="6698a-418">See [How to: Set an Arbiter for an MPSD Session](multiplayer-how-tos.md).</span></span>


### <a name="saving-session-state"></a><span data-ttu-id="6698a-419">セッション状態の保存</span><span class="sxs-lookup"><span data-stu-id="6698a-419">Saving Session State</span></span>

<span data-ttu-id="6698a-420">「**プロセス ライフサイクル管理**」で説明されているように、アービターはセッション状態を定期的に保存する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6698a-420">As discussed in **Process Lifecycle Management**, the arbiter should save session state periodically.</span></span> <span data-ttu-id="6698a-421">タイトルによるアービターの移行の場合、新規のアービターはセッション状態を復元できる必要があります。</span><span class="sxs-lookup"><span data-stu-id="6698a-421">A new arbiter must be able to restore session state in the case of arbiter migration by the title.</span></span> <span data-ttu-id="6698a-422">詳細については、「[アービターの移行](multiplayer-how-tos.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="6698a-422">For more information, see [Migrating an Arbiter](multiplayer-how-tos.md).</span></span>


### <a name="managing-game-session-members-and-joins-in-progress"></a><span data-ttu-id="6698a-423">ゲーム セッションのメンバーと途中参加の管理</span><span class="sxs-lookup"><span data-stu-id="6698a-423">Managing Game Session Members and Joins in Progress</span></span>

<span data-ttu-id="6698a-424">セッション アービターの最も重要な役割は、プレイするためにゲーム セッションに新しく加わるユーザーの管理です。</span><span class="sxs-lookup"><span data-stu-id="6698a-424">The most important role of the session arbiter is to manage users coming into the game session to play.</span></span> <span data-ttu-id="6698a-425">これには、ゲームへの招待の処理、待機中のプレイヤーへの通知、ゲームを終了するプレイヤーに対する操作が含まれます。</span><span class="sxs-lookup"><span data-stu-id="6698a-425">This includes handling game invites, notifying waiting players, and working with players who quit the game.</span></span>


#### <a name="receiving-notifications"></a><span data-ttu-id="6698a-426">通知の受信</span><span class="sxs-lookup"><span data-stu-id="6698a-426">Receiving Notifications</span></span>

<span data-ttu-id="6698a-427">アービターは、**RealTimeActivityService.MultiplayerSessionChanged イベント**で、ゲーム セッションへの参加を希望している新しいプレイヤーをリッスンする必要があります。</span><span class="sxs-lookup"><span data-stu-id="6698a-427">The arbiter must listen for new players who want to join the game session with the **RealTimeActivityService.MultiplayerSessionChanged Event**.</span></span>


#### <a name="finding-players-to-fill-empty-game-session-slots"></a><span data-ttu-id="6698a-428">ゲーム セッションの空スロットを埋めるプレイヤーの検索</span><span class="sxs-lookup"><span data-stu-id="6698a-428">Finding Players to Fill Empty Game Session Slots</span></span>

<span data-ttu-id="6698a-429">アービターは以下のいずれかの操作を行って、ゲーム セッションの空スロットを埋めるプレイヤーを検索します。タイトルがロビー セッションまたは別のメカニズムを使用して途中参加を許可する場合は、そのメカニズムを使用して新しいセッション メンバーを検索します。</span><span class="sxs-lookup"><span data-stu-id="6698a-429">The arbiter finds players to fill empty game session slots by one of these operations:   If your title uses a lobby session or another mechanism to allow delayed joins, find new session members using that mechanism.</span></span>
-   <span data-ttu-id="6698a-430">別のマッチ チケット セッションを作成します。</span><span class="sxs-lookup"><span data-stu-id="6698a-430">Create another match ticket session.</span></span>

<span data-ttu-id="6698a-431">詳細については、「[方法: マッチメイキング中に空きセッション スロットを埋める](multiplayer-how-tos.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="6698a-431">See also [How to: Fill Open Session Slots During Matchmaking](multiplayer-how-tos.md).</span></span>


#### <a name="handling-invited-session-members"></a><span data-ttu-id="6698a-432">招待されたセッション メンバーの処理</span><span class="sxs-lookup"><span data-stu-id="6698a-432">Handling Invited Session Members</span></span>

<span data-ttu-id="6698a-433">アービターは、招待されたセッション メンバーを監視し、1 人のユーザーに対する招待間の最小間隔を適用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6698a-433">The arbiter must monitor invited session members and apply a minimum interval between invites to a single user.</span></span> <span data-ttu-id="6698a-434">「[方法: ゲームへの招待の送信](multiplayer-how-tos.md)」も参照してください。</span><span class="sxs-lookup"><span data-stu-id="6698a-434">See also [How to: Send Game Invites](multiplayer-how-tos.md).</span></span>
