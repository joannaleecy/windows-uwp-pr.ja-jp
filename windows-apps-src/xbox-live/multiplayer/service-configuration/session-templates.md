---
title: "マルチプレイヤー セッション テンプレート"
author: KevinAsgari
description: "マルチプレイヤー セッション テンプレートについて説明します。"
ms.assetid: 178c9863-0fce-4e6a-9147-a928110b53a2
ms.author: kevinasg
ms.date: 04-04-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, マルチプレイヤー, セッション テンプレート"
ms.openlocfilehash: 2162b1aeb422dc5f08d4b2c6a06e57a5b7474855
ms.sourcegitcommit: 90fbdc0e25e0dff40c571d6687143dd7e16ab8a8
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/06/2017
---
# <a name="multiplayer-session-templates"></a>マルチプレイヤー セッション テンプレート

このトピックでは、マルチプレイヤー セッション テンプレートの概要について説明し、マルチプレイヤー セッション用に変更できるテンプレートの例を紹介します。

マルチプレイヤー セッション テンプレートは、マルチプレイヤー セッションの作成に使用される設計図です。 すべてのセッションは、定義済みのテンプレートを基にして作成される必要があります。 テンプレートで定義されている定数は、そのテンプレートから作成されるすべてのセッションで同じになります。 テンプレートからセッションを作成したゲームは、セッションのデータの追加または変更を行うことはできますが、テンプレートで定義されていた定数を変更することはできません。

 詳しくは、「[セッションの概要](../multiplayer-appendix/mpsd-session-details.md)」をご覧ください。

サービス構成 ID (SCID) に適用されるセッション テンプレートの一覧および特定のセッション テンプレートの内容は、マルチプレイヤー セッション ディレクトリ (MPSD) から取得できます。


## <a name="about-session-templates"></a>セッション テンプレートについて

セッション テンプレートは、HTTP PUT 要求と同じ形式を使用してセッションを作成または変更します。 違いは、テンプレートが定数に限られていることです (メンバー、サーバー、またはプロパティはありません)。 定数には、カスタム セクションとすべてのシステム定数を含む、任意のセッション定数を使用できます。

### <a name="session-template-versions"></a>セッション テンプレートのバージョン

このトピックで定義されているセッションのテンプレートは、テンプレート コントラクト バージョン 107 を使用して構築されています。 これらを使用して新しいテンプレートを作成するときは、コントラクト バージョンとして 107 が入力されていることを確認します。

XSAPI を使用して、デバッガーで要求の結果を監視する場合は、要求がテンプレート コントラクト バージョン 105 を使用しているという通知が発生することがあります。 MPSD は実行時にこれらの要求のバージョンを 107 に事実上 "アップグレード" します。

> **注意:** セッション テンプレートで使用されているものとは異なるコントラクト バージョンを要求で使用することは容認されています。

必要に応じて、セッション テンプレートのバージョンを 104/105 から 107 に変更できます。 手順については、「[タイトルを 2015 マルチプレイヤーに適合させるときの一般的な問題](../multiplayer-appendix/common-issues-when-adapting-multiplayer.md)」の移行手順をご覧ください。


## <a name="session-template-default-values"></a>セッション テンプレートの既定値

セッション テンプレートから作成される各セッションは、テンプレートのコピーが出発点となります。 テンプレートに含まれていない値は、セッションの作成時に提供できます。 他の値が設定されない場合の既定値が提供されていることがあります。 たとえば、コントラクト バージョン 107 の既定のタイムアウト設定は次のとおりです。

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
値を未設定のままにしておく場合は、null を指定します。 これにより、既定の設定は無効になり、セッションの作成時に値を設定できなくなります。 たとえば、空のセッションのタイムアウト (メンバーがだれもいなくてもセッションを無限に継続させることができる) を削除するには、セッション テンプレートに次のコードを追加します。
```json
    {
      "constants": {
        "system": {
          "sessionEmptyTimeout": null
        }
      }
    }
```
> **重要:** テンプレートを使用して設定された定数を MPSD への書き込みで変更することはできません。 値を変更するには、必要な変更を行った新しいテンプレートを作成し、送信する必要があります。


## <a name="example-session-templates"></a>セッション テンプレートの例
このセクションでは、さまざまな目的およびネットワーク トポロジー用のセッション テンプレートの例をいくつか示します。 各テンプレートを確認してから、クライアントに最も適したものを選択してください。 テンプレートをコピーし、必要に応じて変更を加えてから、サービス構成に貼り付けることができます。

### <a name="standard-lobby-session"></a>標準的なロビー セッション
次のテンプレートをスターター テンプレートとして使用して、ゲームのロビー セッションを作成できます。

* `maxMembersCount` の値を、ロビー セッションでサポートするプレイヤーの最大数に変更します。  
* 異なるプラットフォーム (Xbox One と PC など) のプレイヤーが一緒にプレイすることをタイトルでサポートしない場合は、`crossPlay` 要素を削除できます。  
* 他の値も変更できますが、何が必要かはっきりしない場合は、次の値が開始時の適切な値です。


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

### <a name="standard-game-session-without-matchmaking"></a>マッチメイキングのない標準的なゲーム セッション
ゲームに匿名マッチメイキングが含まれず、必要なメンバー数が 100 人以下の場合、次のテンプレートをスターター テンプレートとして使用してゲームのゲーム セッションを作成できます。

標準ロビー セッション テンプレートから指定された新しい値は以下に示すものだけであることに注意してください。
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

### <a name="add-matchmaking-to-a-game-session-template-while-letting-the-multiplayer-service-handle-quality-of-service-checks"></a>ゲーム セッション テンプレートにマッチメイキングを追加し、サービス品質のチェックはマルチプレイヤー サービスで処理する

マッチメイキングのサポートを追加するには、次の `memberInitialization` json 要素をゲームプレイ テンプレートに追加できます。

SmartMatch ホッパーを作成するときは、ホッパーのターゲット セッション テンプレートとしてこのテンプレートを使用します。

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

### <a name="add-matchmaking-to-a-game-session-template-where-quality-of-service-checks-are-handled-by-a-title-managed-data-center"></a>ゲーム セッション テンプレートにマッチメイキングを追加し、サービス品質のチェックはタイトルが管理するデータ センターで処理する



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

### <a name="basic-session-template-for-client-server-game-session"></a>クライアント/サーバー ゲーム セッションの基本的なセッション テンプレート

ピア ツー ピア通信を実行せず、Xbox Live エンジンを使用しないが、クライアントがサードパーティーのホスティング サーバーに接続するタイトルには、このテンプレートを使用できます。
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

### <a name="lobbysmartmatch-ticket-session-template-for-peer-based-networking"></a>ピア ベースのネットワーク用のロビー/SmartMatch チケット セッション テンプレート

このテンプレートは、プレイヤーのグループをマッチメイキングに送信するためにのみ使用されるロビー セッションまたは SmartMatch チケット セッションの作成に使用します。 このテンプレートは、ゲーム セッションの構成に使用するものではありません。 ピア ツー ピアまたはピア ツー ホスト ネットワーク トポロジーを使用するクライアントによる使用を想定しています。
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

### <a name="quality-of-service-qos-templates"></a>サービス品質 (QoS) テンプレート

クライアントがマッチメイキングを使用し、QoS を評価する場合は、セッション テンプレートにいくつかの定数を追加して、クライアントと調整してセッションに参加するユーザーを管理するよう MPSD に通知する必要があります。 この調整は、ゲームを開始する準備ができていることをユーザーに通知する前に、接続状態の品質を検証します。 クライアント/サーバー ゲームでは、調整は、プレイヤーのグループがマッチメイキングに参加する前に、接続品質を検証します。

#### <a name="peer-to-host-game-session-template-with-qos"></a>QoS のあるピア ツー ホスト ゲーム セッション テンプレート

次の例は、QoS を考慮したピア ツー ホスト ゲームのセッション テンプレートを表しています。
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

#### <a name="peer-to-peer-game-session-template-with-qos"></a>QoS のあるピア ツー ピア ゲーム セッション テンプレート

次の例は、QoS を考慮したピア ツー ホスト ゲームのセッション テンプレートを示します。
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

#### <a name="client-server-xbox-live-compute-lobbymatchmaking-session-template-with-qos"></a>QoS のあるクライアント/サーバー (Xbox Live Compute) ロビー/マッチメイキング セッション テンプレート

このテンプレートを使用して、QoS を使用するロビー セッションまたはマッチメイキング セッションを作成します。 このテンプレートは、ゲーム セッションの構成に使用するものではありません。
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

#### <a name="session-template-for-crossplay-between-xbox-one-and-windows-10"></a>Xbox One と Windows 10 との間のクロスプレイ用セッション テンプレート

このテンプレートを使用して、Xbox One と Windows 10 との間のクロスプレイ マルチプレイヤーを有効にします。 userAuthorizationStyle 機能によって、Windows 10 へのアクセスが有効になります。 オプションの crossPlay 機能により、タイトルが、プラットフォーム間での招待や途中参加などの相互処理をサポートしていることが示されます。
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
