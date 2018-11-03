---
title: セッション テンプレートの定数
author: KevinAsgari
description: Xbox Live マルチプレイヤー セッション テンプレートで定義されているシステム定数について説明します。
ms.assetid: d51b2f12-1c56-4261-8692-8f73459dc462
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, マルチプレイヤー, セッション テンプレート
ms.localizationpriority: medium
ms.openlocfilehash: 17c7fa48ee637dbca20b67872113a8d43e04da84
ms.sourcegitcommit: 144f5f127fc4fbd852f2f6780ef26054192d68fc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/03/2018
ms.locfileid: "5974609"
---
# <a name="session-template-constants"></a>セッション テンプレートの定数

次の表では、セッション テンプレート バージョン 107 を使用するマルチプレイヤー セッション テンプレートの定義済み要素について説明します。

## <a name="system"></a>システム

システム定数  | 説明 | 有効値 | 既定値
--|-- | -- | --
version | セッション テンプレートのバージョン。 | 1 から n | なし
maxMembersCount | マルチプレイヤー アクティビティでサポートされるセッション メンバー スロットの合計数。 | 通常のセッションの場合は 1 から 100、大規模なセッションの場合は 101 以上 | 100
visibility | 他のユーザーによるセッションの表示や参加が可能かどうかを示すセッションの可視性の状態。 | private、visible、open | open
inviteProtocol | この定数を "game" に設定すると、招待されたユーザーはセッションに招待されたときにトースト通知を受け取ることができます。 | game、tournamentgame、chat、gameparty | なし
reservedRemovalTimeout  | メンバー予約のタイムアウト (ミリ秒単位)。 値 0 は、即時タイムアウトを示します。 タイムアウトが null の場合は、無限と見なされます。 | 0 から n、null | 30000
inactiveRemovalTimeout  | メンバーが非アクティブと見なされるタイムアウト (ミリ秒単位)。 値 0 は、即時タイムアウトを示します。 タイムアウトが null の場合は、無限と見なされます。 | 0 から n、null | 0
readyRemovalTimeout | メンバーが準備完了と見なされるタイムアウト (ミリ秒単位)。 値 0 は、即時タイムアウトを示します。 タイムアウトが null の場合は、無限と見なされます。 | 0 から n、null | 180000
sessionEmptyTimeout | 空のセッションのタイムアウト (ミリ秒単位)。 値 0 は、即時タイムアウトを示します。 タイムアウトが null の場合は、無限と見なされます。 | 0 から n、null | 0
[**capabilities**](#capabilities) | セッションの機能を指定します。 後の「capabilities」セクションを参照してください。 | 該当なし | 該当なし
[**metrics**](#metrics) | セッションのメンバーが満たす必要のある、遅延や帯域幅速度などの、タイトルで定義されているサービス品質要件のセットを指定します。  | 該当なし | 該当なし
[**memberInitialization**](#memberInitialization) | 新しいメンバーがセッションの参加するときに適用されるタイムアウトと初期化の要件を指定します。 後の「memberInitialization」セクションを参照してください。 | 該当なし | 該当なし
[**peerToPeerRequirements**](#peerToPeerRequirements) | ピア ツー ピア メッシュ接続のサービス要件のネットワーク品質を指定します。 後の「peerToPeerRequirements」セクションを参照してください。 |該当なし | 該当なし
[**peerToHostRequirements**](#peerToHostRequirements) | ピア ツー ホスト接続のサービス要件のネットワーク品質を指定します。 後の「peerToHostRequirements」セクションを参照してください。 | 該当なし | 該当なし
[**measurementServerAddresses**](#measurementserveraddresses) | QoS 測定の決定に使用される可能性のあるデータセンターのコレクションを指定します。 後の「measurementServerAddresses」セクションを参照してください。 | 該当なし | 該当なし
[**cloudComputePackage**](#cloudComputePackage) | ? | 該当なし | 該当なし
[**arbitration**](#arbitration) | トーナメントで調停結果を送信するためのメンバーのタイムアウトを指定します。 後の「cloudComputePackage」セクションを参照してください。 | 該当なし | 該当なし
[**broadcastViewerTitleIds**](#broadcastViewerTitleIds) | セッションの読み取りアクセス権を常に持つ必要があるタイトル ID のリストを指定します。 後の「broadcastViewerTitleIds」セクションを参照してください。 | 該当なし | 該当なし
[**ownershipPolicies**](#ownershipPolicies) | セッションの所有権に関連するポリシーを指定します。 後の「OwnershipPolicies」セクションを参照してください。 | 該当なし | 該当なし


## <a name="capabilities"></a>capabilities
capabilities は、必要に応じてセッション テンプレートに設定されるブール値です。 必要な機能がない場合は、タイトルで動的セッション機能を使用する場合を除いて、セッション作成時に機能が指定されることを防ぐために、空の 'capabilities' オブジェクトをテンプレートに含める必要があります。

機能 |  説明 | 有効値 | 既定値
-- | -- | -- | -- |
connectivity | セッションがピア接続をサポートするかどうかを示します。 この値が false の場合、セッションはメトリックを有効にできず、セッション メンバーはその SecureDeviceAddress を設定できません。 大規模なセッションでは設定できません。 | true、false | false
suppressPresenceActivityCheck | true の場合、プレゼンス チェックを無効にします。 | true、false | false
gameplay | ロビーやマッチメイキングなどのセットアップ/メニュー時間ではなく実際のゲームプレイをセッションが表しているかどうかを示します。 true の場合、セッションはゲームプレイ モードです。 | true、false | false
large | セッションが大規模なセッション (100 メンバーより多い) かどうかを示します。 Multiplayer Manager では大規模なセッションの使用はサポートされていません。 | true、false | false
connectionRequiredForActiveMembers | メンバーがアクティブになるために接続が必要かどうかを示します。 | true、false | false
cloudCompute | クライアントがセッションに代わってクラウド コンピューティング インスタンスの割り当てを要求できるようにします。 | true、false | false
autoPopulateServerCandidates | 'serverMeasurements' から 'serverConnectionStringCandidates' を自動的に計算して設定します。 この機能は大きなセッションには設定できません。 | true、false | false
userAuthorizationStyle | セッションが強力なタイトル識別なしでプラットフォームからの呼び出しをサポートするかどうかを示します。 この機能は大きなセッションには設定できません。</br></br>`userAuthorizationStyle` 機能を `true` に設定すると、既定でセッションの `readRestriction` と `joinRestriction` が `none` ではなく `local` になります。 つまり、ゲーム セッションに参加するには、タイトルで検索ハンドルまたは転送ハンドルを使う必要があります。| true、false | false
crossplay | セッションが PC と Xbox One デバイスの間のクロスプレイをサポートすることを示します。 | true、false | false
broadcast | セッションがブロードキャストを表すことを示します。 セッションの名前は、ブロードキャストの xuid にする必要があります。 "large" 機能が必要です。 | true、false | false
team | セッションがトーナメント チームを表すことを示します。 この機能は、"large" または "gameplay" のセッションには設定できません。 | true、false | false
arbitration | "arbitration" サーバー エントリを追加するサービス プリンシパルによってセッションが作成される必要があることを示します。 "large" セッションには設定できません。"gameplay" が必要です。 | true、false | false
hasOwners | 特定のメンバーが所有者であることに基づくセキュリティ ポリシーがセッションにあることを示します。 | true、false | false
searchable | セッションを検索ハンドルのターゲット セッションにできることを示します。 "userAuthorizationStyle" 機能が設定されていて "hasOwners" 機能が設定されていない場合は、"searchable" 機能を設定できません。 | true、false | false

例:

```json
"capabilities": {
    "connectivity": true,  
    "suppressPresenceActivityCheck": true,
    "gameplay": true,
    "large": true,
    "connectionRequiredForActiveMembers": true,
    "cloudCompute": true,
    "autoPopulateServerCandidates": true,
    "userAuthorizationStyle": true,
    "crossPlay": true,  
    "broadcast": true,  
    "team": true,   
    "arbitration": true,   
    "hasOwners": true,   
    "searchable": true  
},
```

## <a name="metrics"></a>metrics
`metrics` プロパティが指定されていない場合は、サービス品質要件を満たすために必要な値が既定で設定されます。  
metrics プロパティを指定する場合は、サービス品質要件を満たすために十分な値にする必要があります。
この要素は、セッションに `connectivity` 機能が設定されている場合にのみ有効です。

メトリック | 説明 | 有効値 | 既定値
-- | -- | -- | --
latency | | true、false | 「説明」を参照
bandwidthDown | | true、false | 「説明」を参照
bandwidthUp | | true、false | 「説明」を参照
custom | | true、false | 「説明」を参照

例:
```json
"metrics": {
    "latency": true,
    "bandwidthDown": true,
    "bandwidthUp": true,
    "custom": true
},
```

## <a name="memberinitialization"></a>memberInitialization
`memberInitialization` オブジェクトが設定されている場合、セッションでは、セッションが作成された後、または新しいメンバーがセッションに参加した後、クライアント システムまたはタイトルで初期化が実行されるものと想定されます。  
タイムアウトおよび初期化ステージは、セッションによって自動的に追跡されます。これには、メトリックが設定されている場合の QoS 測定が含まれます。  
これらのタイムアウトは、"initializationEpisode" が設定されているメンバーの予約および準備完了タイムアウトをオーバーライドします。  
大規模なセッションでは指定できません。

要素  | 説明 | 有効値 | 既定値
-- | -- | -- | --
joinTimeout | メンバーがセッションに参加するまでに使用できるミリ秒数を示します。 参加に失敗したユーザーの予約は削除されます。</br>**注:** 既定の時間は通常のタイトル実行には十分ですが、MPSD フローでタイトルがデバッグ中である場合には参加タイムアウトになる可能性があります。 このような場合、セッションのこの既定値をオーバーライドし、値を増やしてください。| 0 から n | 10000
measurementTimeout | セッション メンバーが測定値をアップロードするまでに使用できるミリ秒数を示します。 測定値のアップロードに失敗したメンバーには、失敗理由として "タイムアウト" が設定されます。  | 0 から n | 30000
evaluationTimeout | 外部評価が測定値をアップロードするまでに使用できるミリ秒数を示します。 | 0 から n | 5000
externalEvaluation | true の場合は、QoS の測定値に基づいて参加するメンバーの評価をタイトル コードが実行することを示します。 マルチプレイヤー サービスはどのような QoS ロジックも実行せず、初期化ステージを進める責任はタイトルにあります。 通常、タイトルはこれを行う必要はありません。 | true、false | false
membersNeededToStart | セッションを開始するために必要なメンバーの数 (初期化エピソードの場合は 0 のみ)。 | 1 - maxMembersCount | 1

例:
```json
"memberInitialization": {
    "joinTimeout": 10000,  
    "measurementTimeout": 30000,  
    "evaluationTimeout": 5000,
    "externalEvaluation": false,
    "membersNeededToStart": 1
},
```


## <a name="peertopeerrequirements"></a>peerToPeerRequirements

ピア ツー ピア ネットワーク要件 | 説明 | 既定値
-- | -- |--
latencyMaximum | 2 つのクライアント間の最大遅延 (ミリ秒単位)。 | 250
bandwidthMinimum | 2 つのクライアント間の最小帯域幅 (kbps 単位)。 | 10000

例:
```json
"peerToPeerRequirements": {
    "latencyMaximum": 250,  
    "bandwidthMinimum": 10000
},
```


## <a name="peertohostrequirements"></a>peerToHostRequirements

ピア ツー ホスト ネットワーク要件 | 説明 | 有効値 | 既定値
-- | -- | -- | --
latencyMaximum | ピアからホストへの接続の最大遅延 (ミリ秒単位)。 | | 250
bandwidthDownMinimum | ホストからピアに送信される情報の最小帯域幅 (kbps 単位)。 | | 100000
bandwidthUpMinimum | ピアからホストに送信される情報の最小帯域幅 (kbps 単位)。 | | 1000
hostSelectionMetric | ホストを選択するのにどのメトリックが使用されるかを示します。ホストを選択するために使用されるメトリックの種類を示します。 | bandwidthup、bandwidthdown、bandwidth、latency | latency

例:
```json
"peerToHostRequirements": {
    "latencyMaximum": 250,
    "bandwidthDownMinimum": 100000,
    "bandwidthUpMinimum": 1000,  
    "hostSelectionMetric": "bandwidthup"
},
```

## <a name="measurementserveraddresses"></a>measurementServerAddresses
評価する必要のある潜在的サーバー接続文字列のセット。 接続文字列は小文字にする必要があります。
大規模なセッションでは指定できません。

接続文字列は次の形式で定義されます。

`"<server name>" : {deviceAddress}`

デバイス アドレスの説明は次のとおりです。

サーバー接続文字列 | 説明
-- | --
secureDeviceAddress | サーバーの base-64 でエンコードされたセキュア デバイス アドレス

例:
```json
"measurementServerAddresses": {
    "server farm a": {
        "secureDeviceAddress": "r5Y="
    },
    "datacenter b": {
        "secureDeviceAddress": "rwY="
    }
},
```

## <a name="cloudcomputepackage"></a>cloudComputePackage
割り当てるクラウド コンピューティング パッケージのプロパティを指定します。 `cloudCompute` 機能が設定されている必要があります。

クラウド コンピューティングのプロパティ | 説明
-- | -- | -- | --
titleId | 割り当てるクラウド コンピューティング パッケージのタイトル ID を示します。
gsiSet | 割り当てるクラウド コンピューティング パッケージの GSI セットを示します。
variant | 割り当てるクラウド コンピューティング パッケージのバリアントを示します。

例:
```json
"cloudComputePackage": {
    "titleId": "4567",
    "gsiSet": "128ce92a-45d0-4319-8a7e-bd8e940114ec",
    "vaiant": "30ebca60-d96e-4629-930b-6957aa6bfbfa"
},
```

## <a name="arbitration"></a>arbitration
判定プロセスのタイムアウトを指定します。 `arbitration` 機能が設定されている必要があります。 判定の開始時刻は、セッションの */servers/arbitration/constants/system/startTime* 要素で定義されています。

タイムアウト | 説明 | 有効値 | 既定値
-- | -- | -- | --
forfeitTimeout | 判定開始時刻 (TBD) からの時間を示します (ミリ秒単位)。 | 0 から n | 60000
arbitrationTimeout | 判定結果がタイムアウトするまでの判定開始時刻からの時間を示します (ミリ秒単位)。この値を `forfeitTimeout` の値より小さくすることはできません。 | 0 から n | 300000

例:
```json
"arbitration": {
    "forfeitTimeout": 60000,
    "arbitrationTimeout": 300000
},
```

## <a name="broadcastviewertitleids"></a>broadcastViewerTitleIds

ブロードキャスト セッションの読み取りアクセス権を常に持つ必要があるタイトルのタイトル ID の配列を指定します。

例:
```json
"broadcastViewerTitleIds" : ["34567", "8910"],
```

## <a name="ownershippolicies"></a>ownershipPolicies
最後の所有者がセッションを離れたときのセッションの処理方法を指定します。 `hasOwners` 機能が設定されている必要があります。

所有権ポリシー | 説明 | 有効値 | 既定値
-- | -- | -- | --
Migration | 最後の所有者がセッションを離れたときに発生する動作を示します。 移行ポリシーが "endsession" に設定されている場合、セッションは期限切れになります。 移行ポリシーが "oldest" に設定されている場合、参加時刻が最も古いメンバーがセッションの新しい所有者になります。 | "oldest"、"endsession" | "endsession"

例:
```json
"ownershipPolicies": {
     "migration": "oldest"
}
```
