---
title: Xbox One マルチプレイヤー セッション ディレクトリ
author: KevinAsgari
description: Xbox Live マルチプレイヤー セッション ディレクトリ (MPSD) サービスを使用してマルチプレイヤー セッションを作成する方法について説明します。
ms.assetid: 70da1be3-5f39-4eed-b62d-9cdd47e413d2
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: c4e10d3a9c194ff5c191ccf33370bad2d9981650
ms.sourcegitcommit: 68fcac3288d5698a13dbcbd57f51b30592f24860
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/19/2018
ms.locfileid: "4057485"
---
# <a name="xbox-one-multiplayer-session-directory"></a>Xbox One マルチプレイヤー セッション ディレクトリ

このトピックでは、新しい Xbox One マルチプレイヤー セッション ディレクトリ (MPSD) サービスを使用するマルチプレイヤー セッション作成の概要を示します。 主な対象読者は、セッション テンプレートを Xbox デベロッパー ポータル (XDP) に直接提出する Xbox One タイトル デベロッパーです。 MPSD サービスでは、同様に、Windows デベロッパー センターで構成されていることができますが、この記事で重視されていません。 MPSD の構成に関連する用語と概念、使用方法、およびマルチプレイヤー セッションのトラブルシューティングについて理解を促進することを目的としています。

## <a name="revision-summary"></a>改訂のまとめ

クライアント側 XSAPI (Xbox Services API) ライブラリは現在、MPSD サービスとの通信時にコントラクト バージョン 104 を使用します。 ドキュメントのこのバージョンでは、セッション テンプレート スキーマをコントラクト バージョン 107 に更新します。これは、MPSD サービスでサポートされている最新のコントラクト バージョンです。 バージョン 104 から 107 までの間の変更について、「[コントラクト スキーマの変更](#_Contract_schema_update)」セクションにまとめています。

コントラクト バージョン 104 に合わせて記述されたテンプレートは、107 として再発行する場合は更新が必要なことに注意してください。 ただし、サービスは後方互換性があるので、現在のライブラリ (将来の XDK リリースで更新予定) を使用し続けることができます。

このドキュメントの前回の改訂では、サーバー セッションに関する情報を更新し、Xbox Live Service API と RESTful サービス呼び出しに関する新しいセクションを追加しました。 また、「セッション状態情報のクエリ」セクションの表が更新され、「サービス品質 (QoS) テンプレート」セクションが改訂されました。

## <a name="introduction"></a>概要

Xbox One のマルチプレイヤー セッションは、クラウドのマルチプレイヤー セッション ディレクトリ (MPSD) に保存されるセキュリティで保護されたドキュメントであり、このドキュメントはゲームをプレイしているユーザーのグループを表します。 マルチプレイヤー セッションの具体的な性質を以下に示します。

-   各セッションが一意の URI を持つ。

-   セッション ドキュメントには、現在のメンバー、ゲーム設定、ブートストラップ データ、およびゲーム サーバー情報が含まれる。

-   タイトルがそれぞれのセッションを作成および管理する。

-   セッションがそのメンバー間の接続を実現する。

マルチプレイヤー セッション ディレクトリは、すべてのクライアントにわたってゲーム セッションのメタデータを集中管理します。 セッションに関して必要な基本情報を提供することによって、クライアント間のセキュア デバイス アソシエーションのセットアップを支援します。 また、基本的な初回起動のメタデータも提供します。このメタデータは、より具体的なゲーム データの受け渡しを開始する前に、クライアントがゲームに接続するために使用されます。 プロセス ライフタイム管理 (PLM) と Xbox One アプリケーションのタスク切り替えの性質のため、MPSD は、アクティブなゲーム セッションの一部として識別されるピアおよびサーバーと通信するための正しい情報がクライアントにあることを確実にし、シェルおよびコンソール オペレーティング システムと調整を図ってゲーム セッションにおけるプレイヤーの有効期間を予約、アクティブ化、および管理します。

## <a name="terminology-used-in-this-document"></a>このドキュメントで使用されている用語

| 用語                 | 説明                                                                                                                                                                                                                                                                                  |
|----------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| マルチプレイヤー セッション  | Xbox Live クラウドに配置され、Xbox One でタイトルをプレイするときに結び付けられる (または結び付けられる予定の) ユーザーのグループを表すセキュリティで保護されたドキュメントです。 マルチプレイヤーのすべての側面 (マッチメイキング、パーティー、途中参加など) で、マルチプレイヤー セッションが利用されます。 |
| ゲーム セッション         | MPSD 内で公開される、ユーザーが一緒にプレイしている実際のゲーム セッションです。 マルチプレイヤーのすべてのシナリオは、最終的にはゲーム セッションになります。                                                                                                                               |
| マッチ チケット セッション | マッチメイキング中にマッチ チケットの送信を追跡するために使用されるセッションです。                                                                                                                                                                                                                 |
| 非アクティブなプレイヤー      | セッション内で Inactive 状態に設定されているプレイヤーです。 ゲームが制限モードである、一時停止されている、またはタイトルで定義されているそれ以外の非アクティブ状態であるときに、タイトルがユーザーを Inactive 状態に設定します。                                                                                     |

## <a name="the-multiplayer-session-directory"></a>マルチプレイヤー セッション ディレクトリ

タイトルでは、MPSD を利用して、オンラインのプレイヤーの間でセッション情報を調整します。 マルチプレイヤー プレイのさまざまなタスクを実行するために、さまざまな種類のセッションが作成される可能性があります。 次の表で、Xbox 360 と Xbox One のタスク実行方式の違いについて説明しています。

| 機能またはタスク                     | Xbox 360                                                                                                        | Xbox One                                                                                                   |
|--------------------------------------|-----------------------------------------------------------------------------------------------------------------|------------------------------------------------------------------------------------------------------------|
| **ゲーム セッション情報の取得**     | **XSessionGetDetails**、**XSessionSearchByID**、または独自に追跡。                                              | サービスからセッション情報を要求する。                                                          |
| **ホストの移行**                     | 必要なときにタイトルが **XSessionMigrateHost** を呼び出す。                                                           | 新しいセッションの作成は不要、SessionID に新しいホストを割り当てるだけ。                                  |
| **複数のプレイヤー セッションの管理**  | 複数のセッションを一度に扱うことが難しい。 たとえば、**XNetReplaceKey** と **XNetUnregisterKey** のどちらが適切か。 | サービス ベースのセッションにより、1 つのセッションの管理がより整理され、複数のセッションの扱いが容易になる。    |
| **サインアウトと切断の処理** | それぞれ **XCloseHandle** または **XSessionDelete** によって切断とサインアウトを別々に処理する必要がある。 | 集中管理されたサービスがサインアウトと切断の処理を簡素化し、タイムアウトはゲーム構成内で設定される。 |

### <a name="session-patterns"></a>セッションのパターン

-   ゲーム セッション

    -   プレイヤーの XUID、セキュリティで保護されたデバイス アドレス データ、およびプロパティ状態を保持するセッション。 これが、実際のゲームプレイ セッションと見なされます。

    -   ピアツーピア、ピアツーホスト、ピアツーサーバー、またはハイブリッドの構成が可能です。

-   マッチ チケット セッション

    -   一緒にプレイする他のプレイヤーを見つけるためにマッチメイキングに送信されるセッション。 ゲームで追加のプレイヤーを探している場合は、ゲーム セッションがチケット セッションでもある場合があります。

-   サーバー セッション

    -   Xbox Live エンジンの処理を通じて作成および使用されるゲーム セッション。

図 1 は MPSD セッションの使用法を示しています。青のボックスは MPSD セッションを表し、赤のボックスはそれらを使用しているサービスです。

図 1:  MPSD セッションの使用

## <a name="mpsd-sessions"></a>MPSD セッション

セッションは関連するエンティティの 2 つのリストを維持しています。

1.  セッションに参加したか、または招待されたメンバー (ユーザー)

2.  セッションに参加したサーバー (クラウド サーバーまたは専用サーバー)

各エンティティには以下のデータが含まれます。

1.  作成時に設定される定数値

2.  可変プロパティ

3.  読み取り専用のメタデータ

### <a name="xbox-live-service-apis-and-restful-service-calls"></a>Xbox Live Service API と RESTful サービスの呼び出し

Xbox One のセッションおよびマッチメイキング サービスとインターフェイスで接続するための方法は 2 つあります。 1 つ目の方法は、RESTful Xbox Live サービス URI の標準 HTTPS を呼び出すものです。 これにより、タイトルはサーバー構成およびゲーム構成に応じて、柔軟にこれらのサービスを呼び出し、連動することができます。 これらの URI の一覧については、「Xbox Live サービス RESTful リファレンス」以下の [Xbox One 開発キット (XDK) ドキュメント](https://developer.xboxlive.com/en-us/platform/development/documentation/software/Pages/home.aspx)を参照してください。[1]

2 つ目の方法は、RESTful サービス URI のラッパーとして機能する Xbox Live Service API を使用するものです。 これらによって、コードではより従来的なアプローチで API を使用することができ、呼び出しごとに HTTPS トラフィックを処理する必要はありません。 Xbox Live Service API のソース コードは Xbox 開発キット (XDK) に付属しており、必要に応じて、修正を加えてタイトルに取り込むことができます。 サンプルは Xbox Live Service API を使用して記述されています。 Xbox Live Service API の詳細については、「Xbox Live サービス リファレンス」以下の Xbox One [XDK ドキュメント](https://developer.xboxlive.com/en-us/platform/development/documentation/software/Pages/home.aspx)を参照してください。[2]

### <a name="mpsd-sessions-and-templates"></a>MPSD セッションとテンプレート

MPSD セッションは、Xbox デベロッパー ポータル (XDP) から取り込まれるテンプレートを使用して作成されます。 テンプレートは、作成中のセッションのフレームワークを定義する JSON ドキュメントです。 テンプレートでは、新しいセッションの定数が提供されます。

次に示すテンプレート構成の例は [Player Rendezvous コード サンプル](https://developer.xboxlive.com/en-us/platform/development/education/Pages/Samples.aspx)から引用したものです。

```json
// Used for creating the session that you then pass into your match ticket request. This *should* not have any QoS requirements.
MatchTicketSession (Contract Version: 107)
{
    "constants": {
        "system": {
            "version": 1,
            "maxMembersCount": 10,
            "visibility": "private",
            "capabilities": {},
            "memberInitialization": {
                "joinTimeout": 20000,
                "externalEvaluation": false,
                "membersNeededToStart": 1
            }
        },
        "custom": {}
    }
}

// This is the new game session that is returned after you’ve been matched.
// Note: This is used for in-game QoS. For out-of-game QoS, you will need P2P/HTP requirements.
GameSession (Contract Version:107)
{
    "constants": {
        "system": {
            "maxMembersCount": 12,
            "capabilities": {"connectivity": true }
        },
        "memberInitialization": {
         "joinTimeout": 20000,
         "measurementTimeout": 15000,
         "externalEvaluation": false,
         "membersNeededToStart": 4
         },

   "custom": {}
  }
}
```

マッチ チケット セッションは、**memberInitialization** オブジェクトに QoS タイムアウト値が設定されたゲーム セッション テンプレートと共に使用してください。

図 2:  サンプル ホッパー

![](../../images/whitepapers/mpsd_image1.png)

次に引用するコードは、ピア ツー ピア ゲーム セッション テンプレート (タイトル管理 QoS) の例です。

```
{
    "constants": {
        "system": {
            "version": 1,
            "maxMembersCount": 10,
            "visibility": "private",
            "capabilities": {
                "connectivity": true
            },
            "memberInitialization": {
                "joinTimeout": 20000,
                "externalEvaluation": false,
                "membersNeededToStart": 2
            }
        },
        "custom": {}
    }
}

```

次に示すのは、ピア ツー サーバー セッションと RAW テンプレートの例です。

```
{
    "constants": {
        "system": {
            "version": 1,
            "maxMembersCount": 10,
            "visibility": "private",
            "capabilities": {}
        },
        "custom": {}
    }
}
```

次のコードは、スマート マッチに使用されるマッチ チケット セッション テンプレートの例を示します。

```
{
    "constants": {
        "system": {
            "version": 1,
            "maxMembersCount": 10,
            "visibility": "private",
            "capabilities": {},
            "memberInitialization": {
                "joinTimeout": 20000,
                "externalEvaluation": false,
                "membersNeededToStart": 1
            }
        },
        "custom": {}
    }
}

```

### <a name="checking-which-templates-are-configured-for-your-scid"></a>どのテンプレートが SCID に設定されているかを確認

#### <a name="session-templates"></a>セッション テンプレート

SCID 内に存在するセッション テンプレートのリストと、特定のセッション テンプレートの詳細を MPSD から取得できます。

```
GET /serviceconfigs/{scid}/sessiontemplates

GET /serviceconfigs/{scid}/sessiontemplates/{session-template-name}
```

#### <a name="query-for-session-state-information"></a>セッション状態情報のクエリ

セッションのクエリは、サービス構成レベルおよびセッション テンプレート レベルで行えます。

```
GET /serviceconfigs/{scid}/sessions

GET /serviceconfigs/{scid}/sessiontemplates/{session-template-name}/sessions
```

既定では、最大 100 件の非プライベート セッションが返されます。 以下のクエリ文字列パラメーターを使用してクエリを修正できます。

| クエリ文字列             | 効果                                                                                                         | 説明                                                                                         |
|--------------------------|----------------------------------------------------------------------------------------------------------------|-----------------------------------------------------------------------------------------------------|
| keyword=foo              | "foo" というキーワードがあるセッションのみを含めます。                                                             |                                                                                                     |
| XUID=123                 | ユーザー "123" が参加しているセッションのみを含めます。                                                               | 既定では、含まれるユーザーはセッション内でアクティブである必要があります。                                  |
| *reservations*=**true** | ユーザーが予約済みプレイヤーとして設定されているが、まだ参加しておらずアクティブ プレイヤーになっていないセッションを含めます。 | 自分自身のセッションをクエリするとき、または特定ユーザーのセッションをサーバー間でクエリするときに限定されます。 |
| *inactive*=**true**      | ユーザーが受け入れたがアクティブにプレイしていないセッションを含めます。                                     | ユーザーが "準備完了" しているが "アクティブ" ではないセッションは非アクティブとしてカウントされます。                           |
| *private*=**true**       | プライベート セッションを含めます。                                                                                      | 自分自身のセッションをクエリするとき、またはサーバー間でクエリするときに限定されます。                            |
| *visibility*=open        | "open" であるセッションのみを含めます。                                                                         | "private" に設定する場合、"private=true" ディレクティブも設定する必要があります。                                 |
| *take*=5                 | 最大 5 つのセッションを返します。                                                                                    | 0 ～ 100 の範囲で指定します。                                                                          |

結果はセッション参照の JSON 配列です。 一部のセッション データがインラインで含まれます。

**注意** すべてのクエリにキーワード フィルターと XUID フィルターのどちらかまたは両方を含める必要があります。

*private* (プライベート セッションを返す) または *reservations* (ユーザーが参加していないセッションを返す) を **true** に設定するには、呼び出し元がサーバー レベルでセッションにアクセスできるか、または呼び出し元の XUID クレームが URI の XUID フィルターに一致する必要があります。 それ以外の場合は、(そのようなセッションが実際に存在するかどうかに関係なく) 403 Forbidden が返されます。

次に引用するコードはクエリ応答の例を示します。

```
{
"results": [ {
"xuid": "9876",  // If the session was found from a xuid, that xuid.
"startTime": "2009-06-15T13:45:30.0900000Z",
"sessionRef": {
  "scid": "foo",
  "templateName": "bar",
  "name": "session-seven"
},
"accepted": 4,        // Approximate number of non-reserved members.
"status": "active",   // or "reserved" or "inactive". This is the state of the user in the session, not the session itself. Only present if the session was found using a xuid.
"visibility": "open", // or "private", "visible", or "full"
"myTurn": true,       // Not present is the same as 'false'. Only present if the session was found using a xuid.
"keywords": [ "one", "two" ]
} ]
}

```

## <a name="session-template-attributes"></a>セッション テンプレートの属性

<div id="_Contract_schema_update"/>

## <a name="contract-schema-update"></a>コントラクト スキーマの更新

このドキュメントで最初に述べたように、最新のセッション テンプレート コントラクト バージョンは 107 であり、前のバージョン 104 と比べてスキーマにいくつかの変更点があります。 コントラクト バージョン 104 に合わせて記述されたテンプレートを、107 として再発行する場合は更新が必要です。 変更内容の概要は以下のとおりです。

-   **/constants/system/managedInitialization** の名前が **/constants/system/memberInitialization** に変更されます。

    -   **autoEvaluate** フィールドの名前が **externalEvaluation** に変更され、**false** が既定のままであることを除いて、その極性が変わります。

    -   **membersNeededToStart** の既定値を 2 から 1 に変更します。

    -   **joinTimeout** の既定値を 5 秒から 10 秒に変更します。

    -   **measurementTimeout** の既定値を 5 秒から 30 秒に変更します。

-   **/constants/system/timeouts** は削除され、タイムアウトの名前は変更され、**/constants/system** に再配置されます。

    -   **reserved** タイムアウトは **reservedRemovalTimeout** になります。

    -   **inactive** タイムアウトは **inactiveRemovalTimeout** になり、その新しい既定値は 2 時間ではなく 0 になります。

    -   **ready** タイムアウトは **readyRemovalTimeout** になります。

    -   **sessionEmpty** タイムアウトは **sessionEmptyTimeout** になります。

-   **/constants/system/capabilities/gameplay** を **true** と指定する必要があります。対象となるのは、(マッチ セッションやロビー セッションのようなヘルパー セッションと異なり) 実際のゲームプレイを表すセッションであり、この指定は最近のプレイヤーおよび評判レポートを有効にするために必要です。

### <a name="system-objects"></a>システム オブジェクト

セッション ドキュメント内の各システム オブジェクトには固定スキーマがあり、MPSD によって適用および解釈されます。

PUT 要求の本体内で、システム オブジェクトは検証されてカスタム オブジェクトと同様に結合されます。 ただし、カスタム オブジェクトと異なり、システム オブジェクトは結合された後も、これらのスキーマに基づいてさらに検証および処理されます。

**/constants/system**

```json
{
"version": 1,  //Document Version (FAL release version 1, service contract 107)
"maxMembersCount": 100,  // Defaults to 100 if not set on creation. Must be between 1 and 100.
"visibility": "private",  // Or "visible" or "open", defaults to "open" if not set on creation.

"initiators": [ "1234" ],  // If specified on a new session, the creators xuid must be in the list (or the creator must be a server).
"inviteProtocol": "party",  // Optional URI scheme of the launch URI for invite toasts.

"reservedRemovalTimeout": 10000, // Default is 30 seconds. Member is removed from the session.
"inactiveRemovalTimeout": 0, // Default is zero. Member is removed from the session.
"readyRemovalTimeout": 60000, // Default is three minutes. Member is removed from the session.
"sessionEmptyTimeout": 0, // Default is zero. Session is deleted.

// Capabilities are boolean values that are optionally set in the session template. If no capabilities are needed, an empty "capabilities" object should be in the template in order to prevent capabilities from being specified on session creation, unless the title desires dynamic session capabilities.
"capabilities": {
"clientMatchmaking": true,
"connectivity": true, // Cannot be set if ‘large’ is specified.
     "suppressPresenceActivityCheck": false,
     "gameplay": false,
     "large": false
},
/* If a "memberInitialization" object is set, the session expects the client system or title to perform initialization following session creation and/or as new members join the session. The timeouts and initialization stages are automatically tracked by the session, including QoS measurements if any metrics are set. These timeouts override the session's reservation and ready timeouts for members that have 'initializationEpisode' set. */
"memberInitialization": {
"joinTimeout": 20000,  // Milliseconds. Unspecified counts as 10 seconds.
"externalEvaluation": false,
"membersNeededToStart": 2  // Unspecified counts as 1. Must be between 0 and maxMembersCount. Only applies to episode 1. If 00 and the session is created with no members to initialize, episode 1 is skipped..
},
```

**/properties/system**

```
{
// Optional array of case-insensitive strings. Cannot be set if the session's visibility is "private".
"keywords": [ "hello" ],

// Array of integer indices of members whose turn it is. Defaults to empty. Can't be set (and doesn't appear) on large sessions.
"turn": [ 0 ],

/* Restricts who can join "open" sessions. (Has no effect on reservations, which means it has no impact on "private" and "visible" sessions.) Defaults to "none". On large sessions, "none" is the only valid value.
If "local", only users whose token's DeviceId matches someone else already in the session and "active": true.
If "followed", only local users (as defined above) and users who are followed by an existing (not reserved) member of the session can join without a reservation. */
"joinRestriction": "none",

// Device token of the host. Must match the "deviceToken" of at least one member, otherwise this field is deleted.
// If "peerToHostRequirements" is set and "host" is set, the measurement stage assumes the given host is the correct host and only measures metrics to that host.
// Can't be set on large sessions.
"host": "99e4c701",

// Can only be set while "initializing/stage" is "evaluating". True indicates success, and false indicates failure. Once set, "initializing/stage" is immediately updated, and this field is removed.
"initializationSucceeded": true,

/* The ordered list of case-insensitive connection strings that the session could use to connect to a game server. Generally titles should use the first on the list, but sophisticated titles could use a custom mechanism (e.g. Thunderhead) for choosing one of the others (e.g. based on load). */
"serverConnectionStringCandidates": [ "datacenter b", "serverfarm a" ],

"matchmaking": {
    "targetSessionConstants": { },
    // Force a specific connection string to be used (useful in preserveSession=always cases).
    "serverConnectionString": "datacenter b",
},

// True if the match that was found didn't work out and needs to be resubmitted. Set to false to signal that the match did work, and the matchmaking service can release the session.
"matchmakingResubmit": true
}

```

### <a name="timeouts"></a>タイムアウト

タイマーおよびその他の外部イベントによってセッションを変更できます。 MPSD の **Timeouts** オブジェクトは、セッションの有効期間とメンバーを管理するための基本的なメカニズムを提供します。

セッションの **nextTimer** フィールドは次のタイマーの日時を表します。 クライアントは、この情報を使用して、次のポーリングの適切な間隔を選択できます。 この値は **Expires** HTTP ヘッダーでも返されます。

タイムアウトはミリ秒単位で指定します。 タイムアウトが即時であることを示す 0 を指定できます。 特定のタイムアウトが指定されない場合は、無期限と見なされます。 タイムアウトには既定値があるため、タイムアウトを無期限にするにはセッション テンプレートで "null" を明示的に指定してください。

#### <a name="sessionemptytimeout"></a>SessionEmptyTimeout

**/constants/system/sessionEmptyTimeout** の値は、セッションが空になってから削除されるまでのミリ秒数を構成します。 既定値は 0 であり、セッションは直ちに削除されます。 値を指定しないと、空のセッションは無期限に存在します。

#### <a name="member-timeouts"></a>メンバー タイムアウト

**/constants/system** に含まれる他の 3 つのタイムアウトは、メンバーが特定の状態にとどまることができる時間を制御します。

-   **reservedRemovalTimeout**

    -   タイムアウト期限が過ぎると予約は削除されます。 既定は 30 秒です。

-   **inactiveRemovalTimeout**

    -   非アクティブ メンバーは、既定では 2 時間後にセッションから削除されます。

-   **readyRemovalTimeout**

    -   "ready" のメンバーは、既定では 3 分後に非アクティブ状態に戻ります。

<div id="_Member_initialization_in"/>

## <a name="member-initialization-in-session-documents"></a>セッション ドキュメントでのメンバー初期化

### <a name="member-initialization"></a>メンバー初期化


**memberInitialization** オブジェクトは、セッションの作成後と新しいメンバーのセッション参加時のいずれかまたは両方の初期化ステージを制御します。 タイムアウトおよび初期化ステージは、セッションによって自動的に追跡されます。これには、メトリックが設定されている場合の QoS 測定が含まれます。

これらのタイムアウト値は、**initializationEpisode** プロパティが設定されたメンバーに関して、セッションの予約タイムアウトおよび準備完了タイムアウトを上書きします。

以下に例を示します。

```
"memberInitialization": {
        "joinTimeout": 5000,
        "measurementTimeout": 5000,
        "evaluationTimeout": 5000,  // only specify for external evaluation
        "externalEvaluation": true,
       "membersNeededToStart": 2
    },
```


![](../../images/whitepapers/mpsd_image2.png)

**図 3:  メンバー初期化フロー**

メンバー初期化の 3 つの各ステージで、以下のようにタイムアウトする可能性があります。

1.  **joiningTimeout**

    -   ユーザーがセッションに参加しなければならない時間 (ミリ秒)。 参加に失敗したメンバーの予約は削除されます。

2.  **measuringTimeout**

    -   メンバーが測定値をアップロードしなければならない時間。 測定値をアップロードできなかったメンバーは *failureReason* が "timeout" に設定されます。

3.  **evaluationTimeout**

    -   メンバーが評価を決定してアップロードしなければならない時間。 決定が受信されない場合、失敗としてカウントされます。

**externalEvaluation**

-   MPSD は、セッション テンプレートで定義された要件に基づいて自動 QoS 評価を実行できます。 評価は externalEvaluation が false に設定されている場合に実行されます。 **evaluationTimeout** が設定されている場合は、**externalEvaluation** は **true** である必要があります。 2 つのピア ツー ピアまたはピア ツー ホスト要件が存在する場合は、セッションに自動で初期化を完了させるために、引き続き **externalEvaluation** を **false** に設定してください。

**membersNeededToStart**

-   これは、"initialize":"true" のときに、QoS に合格して自動評価が成功するために存在する必要があるメンバー予約数の下限です。

### <a name="initialization-episodes"></a>初期化エピソード


**memberInitialization** オブジェクトが設定されているとき、MPSD は初期化フェーズをエピソード単位で進めます。 最初のエピソードはセッションが作成されたときに開始され、テンプレートで定義されているすべてのフェーズを含みます。

エピソードが既に実行されているときに招待されたか参加した新しいメンバーは、次のエピソードに対してマークされます。 エピソードまたは **memberInitialization** 全般の状態は、セッションの **initializing** オブジェクトから取得できます。

**注意** このオブジェクトは初期化が完了した後に削除されます。

以下に例を示します。

```
"initializing": {
    "stage": "measuring",
    "stageStartTime": "2009-06-15T13:45:30.0900000Z",
    "episode": 1
},

```

ステージは、参加、測定、評価の順に遷移します。 エピソードが失敗した場合、ステージは *failed* に設定され、セッションは初期化できません。 それ以外の場合、初期化エピソードが完了すると、**initializing** オブジェクトは削除されます。

初期化の失敗は、各メンバーについても追跡できます。 joining または measuring ステージからの遷移時にこのメンバーが成功しなかった場合に設定されます。

以下に例を示します。
```
"initializationFailure": "latency",
```
優先度順に、この属性の値は *timeout、latency、bandwidthdown、bandwidthup、network、group*、または *episode* に設定できます。 network の値は、ネットワークの構成や、状況 (ネットワーク アドレス変換 \[NAT\] の競合など) が原因で QoS メトリックを測定できなかったことを意味します。 joining の終了時の値として可能性があるのは *group* だけです  (joining からのタイムアウト時に予約は削除されます)。

**memberInitialization** が設定されていて、メンバーに "initialize": true が追加された場合、これはメンバーが参加しようとしている初期化エピソードに追加されます。 値 1 は、その作成時に新しいセッションに追加されるメンバーに使用され、初期化エピソードの終了時に削除されます。
```
"initializationEpisode": 1,
```

## <a name="match-ticket-session"></a>マッチ チケット セッション

MPSD セッションがマッチ チケット セッションとして使用されているとき、いくつかの特別なセッション プロパティおよび定数が使用されます。

**/members/{index}/constants/system**

```json
{

  {
  "xuid": "12345678",

  "initialize": "false", // Run initialization for this user (if “memberInitialization” is set). Defaults to false.

```

マッチメイキング サービスでユーザーがセッションに追加されるとき、ユーザーがセッションにマッチングされた過程および理由に関するいくつかのコンテキストが **matchmakingResult** フィールドで提供されます。

```
"matchmakingResult": {
```

これは、マッチメイキング セッションから抜粋したユーザーの **serverMeasurements** のコピーです。

```json
"serverMeasurements": {
    "east.thunderhead.azure.com": {
        "latency": 233  // Milliseconds
      }
    }
  }
}

```

## <a name="quality-of-service-qos-templates"></a>サービス品質 (QoS) テンプレート

MPSD がネットワーク レイヤーおよび本体のソーシャル プラットフォームと調整を行うために必要な値をゲーム セッション テンプレートに追加することができます。 この調整の目的は、セッションが作成される前と、ゲームの参加準備が整ったことがユーザーに通知される前に、接続状態の品質を検証することです。

次に引用するコードは、QoS 付きピア ツー ホスト ゲーム セッション テンプレートの例です。

```json
{
    "constants": {
        "system": {
            "version": 1,
            "maxMembersCount": 20,
            "visibility": "private",
            "capabilities": {
                "connectivity": true
            },
            "memberInitialization": {
                "joinTimeout": 20000,
                "externalEvaluation": false,
                "membersNeededToStart": 1
            },
            "peerToHostRequirements": {
                "latencyMaximum": 350,
                "bandwidthDownMinimum": 1000,
                "bandwidthUpMinimum": 100,
                "hostSelectionMetric": "latency"
            }
        },
        "custom": {}
    }
}
```

次に引用するコードは、QoS 付きピア ツー ピア ゲーム セッション テンプレートの例です。

```json
{
    "constants": {
        "system": {
            "version": 1,
            "maxMembersCount": 20,
            "visibility": "private",
            "capabilities": {
                "connectivity": true
            },
            "memberInitialization": {
                "joinTimeout": 20000,
                "externalEvaluation": false,
                "membersNeededToStart": 1
            },
            "peerToPeerRequirements": {
                "latencyMaximum": 250,
                "bandwidthMinimum": 10000
            }
        },
        "custom": {}
    }
}

```

### <a name="qos-session-template-attributes"></a>QoS セッション テンプレート属性

**memberInitialization** オブジェクトが設定されている場合、セッションの作成後と新しいメンバーのセッション参加時のいずれかまたは両方で、クライアント システムまたはタイトルが初期化を実行することが期待されます。

タイムアウトおよび初期化ステージは、セッションによって自動的に追跡されます。これには、メトリックが設定されている場合の QoS 測定が含まれます。

これらのタイムアウト値は、**initializationEpisode** プロパティが設定されたメンバーに関して、セッションの予約タイムアウトおよび準備完了タイムアウトを上書きします。

```json
"memberInitialization": {
"joinTimeout": 5000,  // Milliseconds. Unspecified counts as 10 seconds.
"measurementTimeout": 5000,  // Milliseconds. Unspecified counts as 30 seconds.
"evaluationTimeout": 5000,  // Milliseconds. Can only be set if 'externalEvaluation' is true. Unspecified counts as 5 seconds.
"externalEvaluation": true,
"membersNeededToStart": 2  // Unspecified counts as 1. Must be between 0 and maxMembersCount. Only applies to episode 1. If 0 and the session is created with no members to initialize, episode 1 is skipped.
},

```

QoS のあるゲーム セッションには接続機能が必要です。 metrics を指定しない場合、QoS 要件を満たすために必要な既定値が使用されます。 "metrics" が指定されている場合は、QoS 要件を満たすために十分なものである必要があります。

```json
"metrics": {
    "latency": true,
    "bandwidthDown": true,
    "bandwidthUp": true,
    "custom": true

```

以下のしきい値は、セッション内のすべてのメンバーのペアになっている接続ごとに適用されます。

```json
"peerToPeerRequirements": {
    "latencyMaximum": 250,  // Milliseconds
    "bandwidthMinimum": 10000  // Kilobits per second
},

```

以下のしきい値は、ホスト候補からの接続ごとに適用されます。

```json
"peerToHostRequirements": {
    "latencyMaximum": 250,  // Milliseconds
    "bandwidthDownMinimum": 100000,  // Kilobits per second
    "bandwidthUpMinimum": 1000,  // Kilobits per second
    "hostSelectionMetric": "bandwidthup"  // Or "bandwidthdown" or "latency". Not specified is the same as "latency".
},

```

以下の潜在的なサーバー接続文字列が評価される必要があります (接続文字列は小文字でなければならない点に注意してください)。

```json
"measurementServerAddresses": {
        "east.thunderhead.azure.com": {
            "secureDeviceAddress": "r5Y="  // Base-64 encoded secure-device-address
        },
        "west.thunderhead.azure.com": {
            "secureDeviceAddress": "rwY="
        }
    }
}

```

**members/{index}/properties/system**

これらのフラグはメンバーの状態と **activeTitle** を制御し、相互に排他的です (両方を **true** に設定するとエラーになります)。 それぞれ、**false** は "存在しない" ことと同じです。 既定の状態は "inactive" であり、どちらも存在しないことを意味します。

```json
"ready": true,
"active": false,

// Base-64 blob, or not present. Empty-string is the same as not present.
// 'capabilities/connectivity' must be enabled in order for this to be set.
"secureDeviceAddress": "ryY=",

// List of members in my group, by index. Each element must be an integer 0 <= n < 'membersInfo/next'.  
// During member initialization, if any members in the list fail, this member will also fail.
"group": [ 5 ],

// QoS measurements by lower-case device token.
// Like all fields, "measurements" must be updated as a whole. It should be set once when measurement is complete, not incrementally.
// Metrics can me omitted if they weren't successfully measured, i.e. the peer is unreachable.
// If a "measurements" object is set, it can't contain an entry for the member's own address.
"measurements": {
"e69c43a8": {
"latency": 5953,  // Milliseconds
"bandwidthDown": 19342,  // Kilobits per second
"bandwidthUp": 944,  // Kilobits per second
"custom": { }
     }
},

// QoS measurements by game-server connection string. Like all fields, "serverMeasurements" must be updated as a whole, so it should be set once when measurement is complete.
// If empty, it means that none of the measurements completed within the "serverMeasurementTimeout".
    "serverMeasurements": {
        "east.thunderhead.azure.com": {
            "latency": 233  // Milliseconds
        }
    },

// Subscriptions for shoulder taps on session changes. The 'profile' indicates which session changes to tap as well as other properties of the registration like the min time between taps.
// The subscription is named with a client-generated GUID that is also sent back with the tap as a context ID.
// Subscriptions can be added and removed individually, without affecting other subscriptions in the "subscriptions" object.
// To remove a subscription, set its context ID to null.
// (Like the "ready" and "active" flags, the "subscriptions" data is copied out and maintained internally, so the normal replace-all rule on system fields doesn't apply to "subscriptions".)
"subscriptions": {
"961dc162-3a8c-4982-b58b-0347ed086bc9": {
"profile": "party",  // Or "matchmaking", "initialization", "roster", "queueHost", or "queue"
"onBehalfOfTitleId": "3948320593",  // Optional decimal title ID of the registered channel.  If not set the title ID is taken from the token.
},
"709fef70-4638-4b94-905b-24cb02706eb5": null
}
}

```

## <a name="qos-phase-and-session-initialization-details"></a>QoS フェーズとセッション初期化の詳細

テンプレートがメンバー初期化を完了した後、MPSD がゲーム作成の QoS 結果を追跡し、レポートします。 この処理の進行状況は、前の「[メンバー初期化](#_Member_initialization_in)」のセクションで説明したように、セッション ドキュメントの *initializing* オブジェクトによって表されます。 *initializing* オブジェクトには、初期化の現在のステージを表す *stage* 属性があります。 ステージは *joining* から *measuring*、*evaluating* の順に進行します。

-   エピソード \#1 の初期化が失敗した場合、ステージは *failed* に設定され、セッションは初期化できません。 それ以外の場合、初期化エピソードが完了すると、"initializing" オブジェクトは削除されます。 **externalEvaluation** が **false** に設定されている場合、evaluating ステージはスキップされます。 **metrics** と **measurementServerAddresses** のどちらも設定されていない場合、measuring ステージはスキップされます。

```json
"initializing": {
    "stage": "measuring",
    "stageStartTime": "2009-06-15T13:45:30.0900000Z",
    "episode": 1
},

```

-   ホスト候補はデバイス トークンを優先度順に列挙したものです。 **peerToHostRequirements** が設定されており、**/properties/system/host** が設定されていない場合、初期化エピソード \#1 の *measuring* ステージの後に設定されます。 **/properties/system/host** オブジェクトが設定された後にクリアされます。

```json
"hostCandidates": [ "ab90a362", "99582e67" ],

"constants": { /* Property Bag */ },
"properties": { /* Property Bag */ },
"members": {
    "1": {
        "constants": { /* Property Bag */ },
        "properties": { /* Property Bag */ },

```

-   *gamertag* 属性は、メンバーが受け入れた場合と、そのメンバーのゲーマータグ クレームが見つかった場合にのみ設定されます。

```json
"gamertag": "stacy",
```

-   *deviceToken* 属性は、メンバーがセキュア デバイス アドレスをアップロードするときに設定されます。 同等比較に使用できる、大文字と小文字を区別しない文字列です。

```json
"deviceToken": "9f4032ba7",
```

-   *reserved* の値は、ユーザーがセッション ドキュメントへの最初の PUT 要求を実行した後に削除されます。 プレイヤーが予約されているとき、それは、プレイヤーがゲーム セッションに招待されたが、招待を受け入れておらず、プレイヤーの接続も評価されていないことを意味します。

```json
"reserved": true,
```

-   メンバーがアクティブな場合、*activeTitleId* はメンバーがアクティブであるタイトルです。10 進数で示されます。

```json
"activeTitleId": "8397267",
```

-   次の属性は、ユーザーがセッションに参加した日時を指します。 *reserved* が **true** の場合、*joinTime* は予約が行われた日時になります。

```json
"joinTime": "2009-06-15T13:45:30.0900000Z",
```

-   このメンバーが properties/system/turn 配列内にある場合に存在し、それ以外の場合は存在しません。

```json
"turn": true,
```

-   メンバーがステージを正常に通過しなかった場合、joining または measuring ステージからの遷移時に、メンバー オブジェクトの *initializationFailure* 属性が設定されます。 優先順位に従って、*timeout*、*latency*、*bandwidthdown*、*bandwidthup*、*network*、*group*、または *episode* に設定できます。
    *network* の値は、ネットワークの構成や、状況 (ネットワーク アドレス変換 \[NATs\] の競合など) が原因で QoS メトリックを測定できなかったことを意味します。 joining の終了時の値として可能性があるのは *group* だけです  (joining からのタイムアウト時に予約は削除されます)。*episode* の値は、joining または measuring の間に失敗しなかった初期化エピソードのすべてのメンバーについて "evaluation" ステージが失敗した後に設定されます。

```json
"initializationFailure": "latency",
```

-   **memberInitialization** が設定されていて、メンバーに "initialize": true が追加された場合、これはメンバーが参加しようとしている初期化エピソードに追加されます。 1 の値は、作成時に新しいセッションに追加されるメンバーに対して使用されます。 初期化エピソードが終了すると削除されます。

```json
"initializationEpisode": 1,
```

-   *next* 属性は、セッション内の次のメンバーのインデックス値を表します。 追加するメンバーがもういない場合、後続の **membersInfo** オブジェクトの *next* 属性と同じ値になります。

```json
            "next": 4
        },
        "4": { "next": 5 /* etc */ }
    },
    "membersInfo": {
        "first": 1,  // The first member's index.
        "next": 5,  // The index that the next member added will get.
        "count": 2,  // The number of members.
        "accepted": 1  // The number of members that are no longer 'pending'.
    },
    "servers": {
        "name": {
            "constants": { /* Property Bag */ },
            "properties": { /* Property Bag */ }
        }
    }
}

```

## <a name="xbox-cloud-compute-session"></a>Xbox クラウド コンピューティング セッション

Xbox クラウド コンピューティング セッションには、セッションがゲーム サーバーに接続するために使用できる、大文字と小文字を区別しない接続文字列の順序付きリストが含まれます。 一般的に、タイトルはリストの最初の文字列を使用してください。ただし、高度なタイトルでは、(負荷などの条件に基づいて) 他のいずれかを選択するための (Xbox Live Compute のような) カスタム メカニズムを使用することもできます。

```json
    "serverConnectionStringCandidates": [ "west.thunderhead.azure.com", "east.thunderhead.azure.com" ],

    "matchmaking": {
        "clientResult": {  // Requires the clientMatchmaking property.
            "status": "searching",  // Or "expired", "found", "failed", or "canceled".
            "statusDetails": "Description",  // Default is empty string.
            "typicalWait": 30,  // The expected number of seconds waiting as a non-negative integer.
            "targetSessionRef": {
                "scid": "1ECFDB89-36EB-4E59-8901-11F7393689AE",
                "templateName": "capture-the-flag",
                "name": "2D58F65F-0E3C-4F1F-8277-2BC9873FDB23"
            }
        },

        "targetSessionConstants": { },

        // Force a specific connection string to be used (useful in preserveSession=always cases).
        "serverConnectionString": "west.thunderhead.azure.com",

        // True if the match that was found didn't work out and needs to be resubmitted. Set to false
        // to signal that the match did work, and the matchmaking service can release the session.
        "resubmit": true
    }
}

```

**/servers/{server-name}/properties/system **

```json
{
    "lockId": "opaque56789",  // If set, a matchmaking service is servicing this session.
    "status": "searching",  // Or "expired", "found", "failed", or "canceled". Optional.
    "statusDetails": "Description",  // Optional free-form text. Default is empty string.
    "typicalWait": 30,  // Optional. The expected number of seconds waiting as a non-negative integer.
    "targetSessionRef": {  // Optional.
        "scid": "1ECFDB89-36EB-4E59-8901-11F7393689AE",
        "templateName": "capture-the-flag",
        "name": "2D58F65F-0E3C-4F1F-8277-2BC9873FDB23"
    }
}

```

## <a name="raw-session-and-custom-title-properties"></a>RAW セッションとカスタム タイトル プロパティ

マルチプレイヤー ゲームに関連したカスタムのハウスキーピング情報 (メタデータ) を格納するためにセッションを使用できます。 ゲーム データまたは保存される情報は TMS++ に格納される必要があります。

### <a name="property-bags"></a>プロパティ バッグ

これまでの例で "プロパティ バッグ" の注記が付いた各オブジェクトは、オプションの内部オブジェクトである system と custom の 2 種類から構成されます。

custom オブジェクトには任意の JSON を含めることができます。

```json
"custom": {
    "myField1": true,
    "myField2": "string",
    "myField3": 5.5,
    "myField4": { "myObject": null },
    "myField5": [ "my", "array" ]
}

```

## <a name="active-member-decay"></a>アクティブ メンバーの無効化

MPSD は、ユーザーがタイトルに参加していないことを検出すると、アクティブなメンバーを自動的に非アクティブとしてマークします。 たとえば、プレゼンスがユーザー レコードをタイムアウトすると、このようなことが起きる場合があります。 このメカニズムは単なる安全装置です。つまり、メンバーがタイトルを終了するか切り替えたとき、サインアウトしたとき、または他の何らかの形で関与しなくなったときに、タイトルが事前にメンバーを非アクティブとしてマークする (または、メンバーをセッションから削除する) 必要があることには変わりありません。

## <a name="faq-and-troubleshooting"></a>FAQ とトラブルシューティング

### <a name="how-do-i-call-mpsd-"></a>MPSD はどのように呼び出しますか。

証明書認証の使用: client-sessiondirectory.xboxlive.com

以下に例を示します。

```
PUT https://client-sessiondirectory-stress.xboxlive.com/serviceconfigs/8cvda84-2606-4bab-8eda-d12313e65143/sessiontemplates/teamDeathmatch/sessions/3baafc35-816d-49cd-9656-5772506c988a
```

XToken 認証の使用: sessiondirectory.xboxlive.com

以下に例を示します。

```
PUT https://sessiondirectory-stress.xboxlive.com/serviceconfigs/8cvda84-2606-4bab-8eda-d12313e65143/sessiontemplates/teamDeathmatch/sessions/3baafc35-816d-49cd-9656-5772506c988a
```

### <a name="how-do-i-find-out-what-scid-session-template-and-sandbox-to-use"></a>使用する SCID、セッション テンプレート、サンドボックスを調べる方法を教えてください。

この情報はタイトルの XDP サイトで調べることができます。 まだ XDP にアクセスできない場合は、情報の入手を支援できる、担当のデベロッパー アカウント マネージャーに問い合わせてください。

### <a name="is-there-an-example-of-a-request-body-that-i-can-compare-my-own-to"></a>自分のものと比較できる要求本文の例はありますか。


### <a name="i-am-getting-a-404-error-when-calling-mpsd"></a>MPSD の呼び出し時に 404 エラーが発生します。

Fiddler トレースを収集して詳細な情報を取得した後、次のことを行います。

1.  一般的な 404 メッセージの HttpResponse 本文の一部として返されたメッセージを確認します。

    -   *要求されたサービス構成は無効であるか、またはセッション用に構成されていません。* 正しい SCID を使用していることを確認します。

    -   *要求されたセッションが見つかりませんでした。* セッションを取得する前に、セッションが作成されておりセッション テンプレートが正しいことを確認します。 PUT 呼び出しを使用してセッションを作成できます。

2.  使用している URI を確認します。

3.  本体を再起動するか、新しいユーザーで試行するか、その両方を行います。

4.  エラー コードやその他の可能な解決方法を[エンターテイメント デベロッパー フォーラム](https://developer.xboxlive.com/en-us/platform/community/forums/Pages/home.aspx)で検索します。

### <a name="i-am-getting-a-403-error-when-calling-mpsd"></a>MPSD の呼び出し時に 403 エラーが発生します。

通常、これはアクセス許可またはスコープの問題です。 Fiddler トレースを収集して詳細な情報を取得した後、次のことを行います。

1.  一般的な 403 メッセージの HttpResponse の本文の一部として返されるメッセージを確認します。

-   *要求されたサービス構成にアクセスできません。 *

    -   サンドボックスにアクセスできるアカウントを使用していることを確認します。

    -   正しいサンドボックス内にいることを確認します。

    -   証明書認証を使用していてこのエラーが発生する場合は、担当の DAM に問い合わせてください。

-   *要求されたセッションにアクセスできません。 Private Sessions can only be read by members of the session. (プライベート セッションは、セッションのメンバーによってのみ読み取り可能です。)*

    -   可視性が "private" のセッションにアクセスしようとしています。 セッション内のメンバーのみがセッション ドキュメントを読むことができます。

-   *認証プリンシパルにサーバーが含まれていない場合、要求本文に既存メンバーの参照を含めることはできません。*

    -   ユーザーの代わりに別のユーザーをセッションに参加させることはできません。 招待のみ可能です。 プレイヤーを招待するには、インデックスを “reserve\_&lt;number&gt;” に設定します。

### <a name="i-am-getting-a-412-precondition-failed-error"></a>412 Precondition Failed エラーが発生します。

次の例は、セッションが既に存在する場合に 412 Precondition Failed を返します。

> PUT /serviceconfigs/00000000-0000-0000-0000-000000000000/sessiontemplates/quick/sessions/foo HTTP/1.1 Content-Type: application/json If-None-Match: \*

次の例は、セッションの etag が If-Match ヘッダーと一致しない場合に 412 Precondition Failed を返します。

> PUT /serviceconfigs/00000000-0000-0000-0000-000000000000/sessiontemplates/quick/sessions/foo HTTP/1.1 Content-Type: application/json If--Match: 9555A7DE-8B91-40E4-8CFB-0629312C9C7D

### <a name="i-am-getting-errors-such-as-405-409-503-and-400when-calling-mpsd"></a>MPSD の呼び出し時に 405、409、503、400 などのエラーが発生します。

Fiddler トレースを収集して詳しい情報を入手した後、HttpResponse の本文の一部として返されるメッセージを確認します。 これにより、エラーを識別して修正したり、可能な解決方法を[エンターテイメント デベロッパー フォーラム](https://developer.xboxlive.com/en-us/platform/community/forums/Pages/home.aspx)で検索したりするための十分な情報が得られるはずです。

Xbox Live Service API を使用している場合は **DiagnosticsTraceLevel** プロパティを Error (デバッグ出力に情報を出力する) に設定することで、応答本文を取得することもできます。または、いくつかのサンプルで例を示しているように、**XboxLiveContextSettings.ServiceCallRouted** イベントを使用してタイトルの UI に出力できます。

### <a name="what-can-or-should-i-change-in-the-templates-for-my-title"></a>タイトルのテンプレートでは何を変更できますか、または何を変更する必要がありますか。

セッション テンプレートは既定値ではなく鋳型のようなものです。 ただし、テンプレートに定数を追加することは可能ですが、既に設定されている定数を上書きすることはできません。

### <a name="im-getting-an-error-that-is-saying-my-session-isnt-initialized"></a>セッションが初期化されていないことを示すエラーが示されます。

この問題を修正するには、(通常はゲーム、パーティー、およびマッチ チケットの各シナリオで) メンバー初期化がテンプレートに存在する場合に、QoS に合格するために十分なメンバー予約 (開始するために必要なメンバー数) の分だけ "initialize=true" が設定されていることを確認する必要があります。

### <a name="my-session-is-not-being-created-and-im-getting-an-http-204-error"></a>セッションが作成されず HTTP 204 エラーが発生します。

これは、セッションを作成したときにセッションにユーザーが追加されなかったことを示します。 作成の時点でセッションのユーザーがいない場合、セッションは作成されません。 必ず、少なくとも 1 人のプレイヤーを作成時にセッションに追加してください。 専用サーバーのシナリオの場合は、マッチを作成しようとしているプレイヤーか、マッチを作成する必要があるユーザーを識別して、そのユーザーをマッチ内の最初のプレイヤーにします。 別の方法として、**sessionEmptyTimeout** を変更または削除できます。

### <a name="when-should-i-poll-the-mpsd"></a>MPSD をポーリングすべきタイミングを教えてください。

MPSD セッションのポーリングは避ける必要があります。 一般に、各クライアントのネットワーク接続の初期確立と、接続を失った 1 つまたは複数のクライアントのネットワーク状態の再確立のみに MPSD セッションを利用するようにコードを設計することによって、この指針に従うことができます。 競合状態を解決するためにセッション状態をリフレッシュする必要性を排除するために、MPSD の etag ベースの同期プリミティブを利用することも重要です。

N 個のクライアントの集合が存在し、すべてのクライアントが相互接続してピア ツー ピア メッシュでプレイする必要がある場合に、これらの原則がよく適用されます。 セッションを定期的にクエリして新しいメンバーを検出しなくても、それぞれのメンバーは、セッションに参加したり、セッションに参加中のメンバーに接続したり、後続の参加者が同じ行動をすると想定したりできます。 これを実装する方法の例については、Chat サンプルおよび Player Rendezvous サンプルを参照してください。

ごく一部の状況で、短期間のポーリングが必要な場合があります。ポーリングが必要と思われる場合は、担当のデベロッパー アカウント マネージャーに問い合わせてください。
