---
title: マルチプレイヤー セッション テンプレート
description: マルチプレイヤー セッション テンプレートについて説明します。
ms.assetid: 178c9863-0fce-4e6a-9147-a928110b53a2
ms.date: 04/04/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, マルチプレイヤー, セッション テンプレート
ms.localizationpriority: medium
ms.openlocfilehash: 0bbe4f6a3afe2d39fb18b4d4bad13e2aa91d246e
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/06/2018
ms.locfileid: "8729099"
---
# <a name="multiplayer-session-templates"></a><span data-ttu-id="c1314-104">マルチプレイヤー セッション テンプレート</span><span class="sxs-lookup"><span data-stu-id="c1314-104">Multiplayer session templates</span></span>

<span data-ttu-id="c1314-105">このトピックでは、マルチプレイヤー セッション テンプレートの概要について説明し、マルチプレイヤー セッション用に変更できるテンプレートの例を紹介します。</span><span class="sxs-lookup"><span data-stu-id="c1314-105">This topic gives a brief overview of multiplayer session templates and provides several examples of templates that you can copy and modify for your multiplayer sessions.</span></span>

<span data-ttu-id="c1314-106">マルチプレイヤー セッション テンプレートは、マルチプレイヤー セッションの作成に使用される設計図です。</span><span class="sxs-lookup"><span data-stu-id="c1314-106">A multiplayer session template is a blueprint that is used to create a multiplayer session.</span></span> <span data-ttu-id="c1314-107">すべてのセッションは、定義済みのテンプレートを基にして作成される必要があります。</span><span class="sxs-lookup"><span data-stu-id="c1314-107">All sessions must be created based on a predefined template.</span></span> <span data-ttu-id="c1314-108">テンプレートで定義されている定数は、そのテンプレートから作成されるすべてのセッションで同じになります。</span><span class="sxs-lookup"><span data-stu-id="c1314-108">A template defines constants that will be the same for any session that is created from the template.</span></span> <span data-ttu-id="c1314-109">テンプレートからセッションを作成したゲームは、セッションのデータの追加または変更を行うことはできますが、テンプレートで定義されていた定数を変更することはできません。</span><span class="sxs-lookup"><span data-stu-id="c1314-109">Once a game creates a session from a template, the game can add and modify additional data to the session, but cannot modify the constants that were defined in the template.</span></span>

 <span data-ttu-id="c1314-110">詳しくは、「[セッションの概要](../multiplayer-appendix/mpsd-session-details.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c1314-110">For more information, see [Session Overview](../multiplayer-appendix/mpsd-session-details.md).</span></span>

<span data-ttu-id="c1314-111">サービス構成 ID (SCID) に適用されるセッション テンプレートの一覧および特定のセッション テンプレートの内容は、マルチプレイヤー セッション ディレクトリ (MPSD) から取得できます。</span><span class="sxs-lookup"><span data-stu-id="c1314-111">The list of session templates that apply to a service configuration identifier (SCID), as well as the contents of specific session templates, can be retrieved from Multiplayer Session Directory (MPSD).</span></span>


## <a name="about-session-templates"></a><span data-ttu-id="c1314-112">セッション テンプレートについて</span><span class="sxs-lookup"><span data-stu-id="c1314-112">About session templates</span></span>

<span data-ttu-id="c1314-113">セッション テンプレートは、HTTP PUT 要求と同じ形式を使用してセッションを作成または変更します。</span><span class="sxs-lookup"><span data-stu-id="c1314-113">A session template uses the same format as an HTTP PUT request to create or modify a session.</span></span> <span data-ttu-id="c1314-114">違いは、テンプレートが定数に限られていることです (メンバー、サーバー、またはプロパティはありません)。</span><span class="sxs-lookup"><span data-stu-id="c1314-114">The difference is that the template is limited to constants (no members, servers, or properties).</span></span> <span data-ttu-id="c1314-115">定数には、カスタム セクションとすべてのシステム定数を含む、任意のセッション定数を使用できます。</span><span class="sxs-lookup"><span data-stu-id="c1314-115">The constants can be any session constants, including a custom section and the full range of system constants.</span></span>

### <a name="session-template-versions"></a><span data-ttu-id="c1314-116">セッション テンプレートのバージョン</span><span class="sxs-lookup"><span data-stu-id="c1314-116">Session template versions</span></span>

<span data-ttu-id="c1314-117">このトピックで定義されているセッションのテンプレートは、テンプレート コントラクト バージョン 107 を使用して構築されています。</span><span class="sxs-lookup"><span data-stu-id="c1314-117">The session templates defined in this topic are constructed using template contract version 107.</span></span> <span data-ttu-id="c1314-118">これらを使用して新しいテンプレートを作成するときは、コントラクト バージョンとして 107 が入力されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="c1314-118">When using them to create a new template, make sure that 107 is entered as the contract version.</span></span>

<span data-ttu-id="c1314-119">XSAPI を使用して、デバッガーで要求の結果を監視する場合は、要求がテンプレート コントラクト バージョン 105 を使用しているという通知が発生することがあります。</span><span class="sxs-lookup"><span data-stu-id="c1314-119">If you use XSAPI and watch the resulting requests in the debugger, you might notice that the requests use template contract version 105.</span></span> <span data-ttu-id="c1314-120">MPSD は実行時にこれらの要求のバージョンを 107 に事実上 "アップグレード" します。</span><span class="sxs-lookup"><span data-stu-id="c1314-120">MPSD effectively "upgrades" these requests to version 107 at run time.</span></span>

> <span data-ttu-id="c1314-121">**注意:** セッション テンプレートで使用されているものとは異なるコントラクト バージョンを要求で使用することは容認されています。</span><span class="sxs-lookup"><span data-stu-id="c1314-121">**Note:** It is permissible to use a different contract version in the request from what is used in the session template.</span></span>

<span data-ttu-id="c1314-122">必要に応じて、セッション テンプレートのバージョンを 104/105 から 107 に変更できます。</span><span class="sxs-lookup"><span data-stu-id="c1314-122">If necessary, you can change a session template from version 104/105 to version 107.</span></span> <span data-ttu-id="c1314-123">手順については、「[タイトルを 2015 マルチプレイヤーに適合させるときの一般的な問題](../multiplayer-appendix/common-issues-when-adapting-multiplayer.md)」の移行手順をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c1314-123">For instructions, see migrating instructions in [Common Issues When Adapting Your Titles for 2015 Multiplayer](../multiplayer-appendix/common-issues-when-adapting-multiplayer.md).</span></span>


## <a name="session-template-default-values"></a><span data-ttu-id="c1314-124">セッション テンプレートの既定値</span><span class="sxs-lookup"><span data-stu-id="c1314-124">Session template default values</span></span>

<span data-ttu-id="c1314-125">セッション テンプレートから作成される各セッションは、テンプレートのコピーが出発点となります。</span><span class="sxs-lookup"><span data-stu-id="c1314-125">Each session created from a session template starts as a copy of the template.</span></span> <span data-ttu-id="c1314-126">テンプレートに含まれていない値は、セッションの作成時に提供できます。</span><span class="sxs-lookup"><span data-stu-id="c1314-126">Values that the template does not include can be provided at session creation.</span></span> <span data-ttu-id="c1314-127">他の値が設定されない場合の既定値が提供されていることがあります。</span><span class="sxs-lookup"><span data-stu-id="c1314-127">Default values are provided in some cases when no other value is set.</span></span> <span data-ttu-id="c1314-128">たとえば、コントラクト バージョン 107 の既定のタイムアウト設定は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="c1314-128">For example, the default set of timeouts for contract version 107 is:</span></span>

```json
    {
      "constants": {
        "system": {
          "reservedRemovalTimeout": 30000,
          "inactiveRemovalTimeout": 0,
          "readyRemovalTimeout": 180000,
          "sessionEmptyTimeout": 0
        }
      }
    }
```
<span data-ttu-id="c1314-129">値を未設定のままにしておく場合は、null を指定します。</span><span class="sxs-lookup"><span data-stu-id="c1314-129">You can force a value to remain unset by specifying null.</span></span> <span data-ttu-id="c1314-130">これにより、既定の設定は無効になり、セッションの作成時に値を設定できなくなります。</span><span class="sxs-lookup"><span data-stu-id="c1314-130">This overrides any default setting and prevents the value from being set at session creation.</span></span> <span data-ttu-id="c1314-131">たとえば、空のセッションのタイムアウト (メンバーがだれもいなくてもセッションを無限に継続させることができる) を削除するには、セッション テンプレートに次のコードを追加します。</span><span class="sxs-lookup"><span data-stu-id="c1314-131">For example, to remove the session empty timeout, allowing sessions to continue indefinitely, even without any members, add the following to the session template:</span></span>
```json
    {
      "constants": {
        "system": {
          "sessionEmptyTimeout": null
        }
      }
    }
```
> <span data-ttu-id="c1314-132">**重要:** テンプレートを使用して設定された定数を MPSD への書き込みで変更することはできません。</span><span class="sxs-lookup"><span data-stu-id="c1314-132">**Important:** Constants that are set through a template cannot be changed through writes to MPSD.</span></span> <span data-ttu-id="c1314-133">値を変更するには、必要な変更を行った新しいテンプレートを作成し、送信する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c1314-133">To change the values, you must create and submit a new template with the required changes.</span></span>


## <a name="example-session-templates"></a><span data-ttu-id="c1314-134">セッション テンプレートの例</span><span class="sxs-lookup"><span data-stu-id="c1314-134">Example session templates</span></span>
<span data-ttu-id="c1314-135">このセクションでは、さまざまな目的およびネットワーク トポロジー用のセッション テンプレートの例をいくつか示します。</span><span class="sxs-lookup"><span data-stu-id="c1314-135">This section shows several examples of session templates for different purposes and networking topologies.</span></span> <span data-ttu-id="c1314-136">各テンプレートを確認してから、クライアントに最も適したものを選択してください。</span><span class="sxs-lookup"><span data-stu-id="c1314-136">Please examine each template before choosing the one most appropriate for your client.</span></span> <span data-ttu-id="c1314-137">テンプレートをコピーし、必要に応じて変更を加えてから、サービス構成に貼り付けることができます。</span><span class="sxs-lookup"><span data-stu-id="c1314-137">You can then copy and paste the template into your service configuration, potentially after making required changes.</span></span>

### <a name="standard-lobby-session"></a><span data-ttu-id="c1314-138">標準的なロビー セッション</span><span class="sxs-lookup"><span data-stu-id="c1314-138">Standard lobby session</span></span>
<span data-ttu-id="c1314-139">次のテンプレートをスターター テンプレートとして使用して、ゲームのロビー セッションを作成できます。</span><span class="sxs-lookup"><span data-stu-id="c1314-139">You can use the following template as a starter template to create a lobby session for your game:</span></span>

* <span data-ttu-id="c1314-140">`maxMembersCount` の値を、ロビー セッションでサポートするプレイヤーの最大数に変更します。</span><span class="sxs-lookup"><span data-stu-id="c1314-140">Change the `maxMembersCount` value to the maximum number of players that you want to support in your lobby session.</span></span>  
* <span data-ttu-id="c1314-141">異なるプラットフォーム (Xbox One と PC など) のプレイヤーが一緒にプレイすることをタイトルでサポートしない場合は、`crossPlay` 要素を削除できます。</span><span class="sxs-lookup"><span data-stu-id="c1314-141">If your title does not support players from different platforms (such as an Xbox One and a PC) playing together, you can remove the `crossPlay` element.</span></span>  
* <span data-ttu-id="c1314-142">他の値も変更できますが、何が必要かはっきりしない場合は、次の値が開始時の適切な値です。</span><span class="sxs-lookup"><span data-stu-id="c1314-142">You can change the other values as well, but the following values are good values to start with if you're not sure what you need.</span></span>


```json
{
   "constants": {
        "system": {
            "version": 1,
            "maxMembersCount": 8,
            "visibility": "open",
            "capabilities": {
                "connectivity": true,
                "connectionRequiredForActiveMembers": true,
                "crossPlay": true,
                "userAuthorizationStyle": true
            },
        },
        "custom": {}
    }
}
```

### <a name="standard-game-session-without-matchmaking"></a><span data-ttu-id="c1314-143">マッチメイキングのない標準的なゲーム セッション</span><span class="sxs-lookup"><span data-stu-id="c1314-143">Standard game session without matchmaking</span></span>
<span data-ttu-id="c1314-144">ゲームに匿名マッチメイキングが含まれず、必要なメンバー数が 100 人以下の場合、次のテンプレートをスターター テンプレートとして使用してゲームのゲーム セッションを作成できます。</span><span class="sxs-lookup"><span data-stu-id="c1314-144">You can use the following template as a starter template to create a game session for your game, if your game does not include anonymous matchmaking and does not require more than 100 members.</span></span>

<span data-ttu-id="c1314-145">標準ロビー セッション テンプレートから指定された新しい値は以下に示すものだけであることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="c1314-145">Note that the only new values specified from the standard lobby session template are the following:</span></span>
* `constants.system.inviteProtocol : "game"`
* `constants.system.capabilities.gameplay : true`

```json
{
   "constants": {
        "system": {
            "version": 1,
            "maxMembersCount": 8,
            "visibility": "open",
            "inviteProtocol": "game",
            "capabilities": {
                "connectivity": true,
                "connectionRequiredForActiveMembers": true,
                "gameplay" : true,
                "crossPlay": true,
                "userAuthorizationStyle": true
            }
        },
        "custom": {}
    }
}
```

### <a name="add-matchmaking-to-a-game-session-template-while-letting-the-multiplayer-service-handle-quality-of-service-checks"></a><span data-ttu-id="c1314-146">ゲーム セッション テンプレートにマッチメイキングを追加し、サービス品質のチェックはマルチプレイヤー サービスで処理する</span><span class="sxs-lookup"><span data-stu-id="c1314-146">Add matchmaking to a game session template, while letting the multiplayer service handle quality of service checks.</span></span>

<span data-ttu-id="c1314-147">マッチメイキングのサポートを追加するには、次の `memberInitialization` json 要素をゲームプレイ テンプレートに追加できます。</span><span class="sxs-lookup"><span data-stu-id="c1314-147">You can add the following `memberInitialization` json element to your gameplay template in order to add support for matchmaking.</span></span>

<span data-ttu-id="c1314-148">SmartMatch ホッパーを作成するときは、ホッパーのターゲット セッション テンプレートとしてこのテンプレートを使用します。</span><span class="sxs-lookup"><span data-stu-id="c1314-148">When you create your SmartMatch hopper, use this template as the target session template for your hopper.</span></span>

```json
{
   "constants": {
        "system": {
            "memberInitialization": {
               "joinTimeout": 20000,
               "measurementTimeout": 15000,
               "membersNeededToStart": 2
            }
        }
    }
}
```

### <a name="add-matchmaking-to-a-game-session-template-where-quality-of-service-checks-are-handled-by-a-title-managed-data-center"></a><span data-ttu-id="c1314-149">ゲーム セッション テンプレートにマッチメイキングを追加し、サービス品質のチェックはタイトルが管理するデータ センターで処理する</span><span class="sxs-lookup"><span data-stu-id="c1314-149">Add matchmaking to a game session template, where quality of service checks are handled by a title managed data center.</span></span>



```json
{
   "constants": {
        "system": {
            "peerToHostRequirements": {  
                "latencyMaximum": 250,
                "bandwidthDownMinimum": 256,
                "bandwidthUpMinimum": 256,
                "hostSelectionMetric": "latency"
            },
            "memberInitialization": {
               "joinTimeout": 15000,
               "measurementTimeout": 15000,
               "membersNeededToStart": 2
            }
        },
        "custom": {}
    }
}
```

### <a name="basic-session-template-for-client-server-game-session"></a><span data-ttu-id="c1314-150">クライアント/サーバー ゲーム セッションの基本的なセッション テンプレート</span><span class="sxs-lookup"><span data-stu-id="c1314-150">Basic session template for client-server game session</span></span>

<span data-ttu-id="c1314-151">ピア ツー ピア通信を実行せず、Xbox Live エンジンを使用しないが、クライアントがサードパーティーのホスティング サーバーに接続するタイトルには、このテンプレートを使用できます。</span><span class="sxs-lookup"><span data-stu-id="c1314-151">You can use this template for a title that does not perform peer-to-peer communication and does not use Xbox Live Compute, but instead has clients connect to a third-party hosted server.</span></span>
```json
    {
      "constants": {
        "system": {
          "version": 1,
          "maxMembersCount": 12,
          "visibility": "open",
          "inviteProtocol": "game",
          "capabilities": {
            "connectionRequiredForActiveMembers": true,
            "gameplay" : true,
          },
        },
        "custom": {}
      }
    }
```

### <a name="lobbysmartmatch-ticket-session-template-for-peer-based-networking"></a><span data-ttu-id="c1314-152">ピア ベースのネットワーク用のロビー/SmartMatch チケット セッション テンプレート</span><span class="sxs-lookup"><span data-stu-id="c1314-152">Lobby/SmartMatch ticket session template for peer-based networking</span></span>

<span data-ttu-id="c1314-153">このテンプレートは、プレイヤーのグループをマッチメイキングに送信するためにのみ使用されるロビー セッションまたは SmartMatch チケット セッションの作成に使用します。</span><span class="sxs-lookup"><span data-stu-id="c1314-153">Use this template for creating a lobby session or a SmartMatch ticket session that is only to be used to send a group of players into matchmaking.</span></span> <span data-ttu-id="c1314-154">このテンプレートは、ゲーム セッションの構成に使用するものではありません。</span><span class="sxs-lookup"><span data-stu-id="c1314-154">The template is not to be used to configure a game session.</span></span> <span data-ttu-id="c1314-155">ピア ツー ピアまたはピア ツー ホスト ネットワーク トポロジーを使用するクライアントによる使用を想定しています。</span><span class="sxs-lookup"><span data-stu-id="c1314-155">It is intended for use by clients using a peer-to-peer or peer-to-host network topology.</span></span>
```json
    {
      "constants": {
        "system": {
          "version": 1,
          "maxMembersCount": 10,
          "visibility": "open",
          "capabilities": {
            "connectionRequiredForActiveMembers": true,
          },
          "memberInitialization": {
            "membersNeededToStart": 1
          },
        },
        "custom": {}
      }
    }
```

### <a name="quality-of-service-qos-templates"></a><span data-ttu-id="c1314-156">サービス品質 (QoS) テンプレート</span><span class="sxs-lookup"><span data-stu-id="c1314-156">Quality of Service (QoS) templates</span></span>

<span data-ttu-id="c1314-157">クライアントがマッチメイキングを使用し、QoS を評価する場合は、セッション テンプレートにいくつかの定数を追加して、クライアントと調整してセッションに参加するユーザーを管理するよう MPSD に通知する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c1314-157">If your client is using matchmaking and evaluating QoS, you must add some constants to the session template to inform MPSD to coordinate with the client to manage users joining the session.</span></span> <span data-ttu-id="c1314-158">この調整は、ゲームを開始する準備ができていることをユーザーに通知する前に、接続状態の品質を検証します。</span><span class="sxs-lookup"><span data-stu-id="c1314-158">This coordination validates the quality of the connection state prior to informing users that the game is ready to start.</span></span> <span data-ttu-id="c1314-159">クライアント/サーバー ゲームでは、調整は、プレイヤーのグループがマッチメイキングに参加する前に、接続品質を検証します。</span><span class="sxs-lookup"><span data-stu-id="c1314-159">In the case of client-server games, the coordination validates connection quality before a group of players enters matchmaking.</span></span>

#### <a name="peer-to-host-game-session-template-with-qos"></a><span data-ttu-id="c1314-160">QoS のあるピア ツー ホスト ゲーム セッション テンプレート</span><span class="sxs-lookup"><span data-stu-id="c1314-160">Peer-to-host game session template with QoS</span></span>

<span data-ttu-id="c1314-161">次の例は、QoS を考慮したピア ツー ホスト ゲームのセッション テンプレートを表しています。</span><span class="sxs-lookup"><span data-stu-id="c1314-161">The following example presents a peer-to-host game session template with QoS.</span></span>
```json
    {
      "constants": {
        "system": {
          "version": 1,
          "maxMembersCount": 12,
          "visibility": "open",
          "inviteProtocol": "game",
          "capabilities": {
            "connectivity": true,
            "connectionRequiredForActiveMembers": true,
            "gameplay" : true
          },
          "memberInitialization": {
            "membersNeededToStart": 2
          },
          "peerToHostRequirements": {
            "latencyMaximum": 350,
            "bandwidthDownMinimum": 1000,
            "bandwidthUpMinimum": 1000,
            "hostSelectionMetric": "latency"
          }
        },
        "custom": { }
      }
    }
```

#### <a name="peer-to-peer-game-session-template-with-qos"></a><span data-ttu-id="c1314-162">QoS のあるピア ツー ピア ゲーム セッション テンプレート</span><span class="sxs-lookup"><span data-stu-id="c1314-162">Peer-to-peer game session template with QoS</span></span>

<span data-ttu-id="c1314-163">次の例は、QoS を考慮したピア ツー ホスト ゲームのセッション テンプレートを示します。</span><span class="sxs-lookup"><span data-stu-id="c1314-163">The following is an example of a peer-to-peer game session template with QoS.</span></span>
```json
    {
    "constants": {
      "system": {
        "version": 1,
        "maxMembersCount": 12,
        "visibility": "open",
        "inviteProtocol": "game",
        "capabilities": {
          "connectivity": true,
          "connectionRequiredForActiveMembers": true,
          "gameplay" : true
        },
        "memberInitialization": {
          "membersNeededToStart": 2
        },
        "peerToPeerRequirements": {
          "latencyMaximum": 250,
          "bandwidthMinimum": 10000
        }
      },
      "custom": { }
     }
    }
```

#### <a name="client-server-xbox-live-compute-lobbymatchmaking-session-template-with-qos"></a><span data-ttu-id="c1314-164">QoS のあるクライアント/サーバー (Xbox Live Compute) ロビー/マッチメイキング セッション テンプレート</span><span class="sxs-lookup"><span data-stu-id="c1314-164">Client-server (Xbox Live Compute) lobby/matchmaking session template with QoS</span></span>

<span data-ttu-id="c1314-165">このテンプレートを使用して、QoS を使用するロビー セッションまたはマッチメイキング セッションを作成します。</span><span class="sxs-lookup"><span data-stu-id="c1314-165">Use this template to create a lobby session or a matchmaking session using QoS.</span></span> <span data-ttu-id="c1314-166">このテンプレートは、ゲーム セッションの構成に使用するものではありません。</span><span class="sxs-lookup"><span data-stu-id="c1314-166">This template is not intended to be used to configure a game session.</span></span>
```json
    {
      "constants": {
        "system": {
          "version": 1,
          "maxMembersCount": 12,
          "visibility": "open",
          "memberInitialization": {
            "membersNeededToStart": 1
          }
        },
        "custom": {}
      }
    }
```

#### <a name="session-template-for-crossplay-between-xbox-one-and-windows-10"></a><span data-ttu-id="c1314-167">Xbox One と Windows 10 との間のクロスプレイ用セッション テンプレート</span><span class="sxs-lookup"><span data-stu-id="c1314-167">Session template for crossplay between Xbox One and Windows 10</span></span>

<span data-ttu-id="c1314-168">このテンプレートを使用して、Xbox One と Windows 10 との間のクロスプレイ マルチプレイヤーを有効にします。</span><span class="sxs-lookup"><span data-stu-id="c1314-168">Use this template to enable crossplay multiplayer between Xbox One and Windows 10.</span></span> <span data-ttu-id="c1314-169">userAuthorizationStyle 機能によって、Windows 10 へのアクセスが有効になります。</span><span class="sxs-lookup"><span data-stu-id="c1314-169">The userAuthorizationStyle capability enables access to Windows 10.</span></span> <span data-ttu-id="c1314-170">オプションの crossPlay 機能により、タイトルが、プラットフォーム間での招待や途中参加などの相互処理をサポートしていることが示されます。</span><span class="sxs-lookup"><span data-stu-id="c1314-170">The optional crossPlay capability signifies that your title supports interactions such as invites and join-in-progress between platforms.</span></span>
```json
    {
      "constants": {
        "system": {
          "capabilities": {
            "crossPlay": true,
            "userAuthorizationStyle": true
          },
        },
        "custom": {}
      }
    }
```
