---
title: SmartMatch マッチメイキングの使用
author: KevinAsgari
description: Xbox Live SmartMatch を使用してマルチプレイヤー ゲームでプレイヤーをマッチングする方法について説明します。
ms.assetid: 10b6413e-51d9-4fec-9110-5e258d291040
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, マルチプレイヤー, マッチメイキング, SmartMatch
ms.localizationpriority: medium
ms.openlocfilehash: 4594bd70c28729f38e0c0eaea7ea8ef7a905bbfe
ms.sourcegitcommit: c4d3115348c8b54fcc92aae8e18fdabc3deb301d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/22/2018
ms.locfileid: "5398479"
---
# <a name="using-smartmatch-matchmaking"></a>SmartMatch マッチメイキングの使用

次のフロー チャートは、SmartMatch マッチメイキングのプロセスを示しています。

![](../../images/multiplayer/Multiplayer_2015_SmartMatch_Matchmaking.png)

## <a name="creating-a-match-ticket-session-and-a-match-ticket"></a>マッチ チケット セッションとマッチ チケットの作成

マッチメイキングを開始する前に、マッチメイキング "スカウト" が、マッチメイキングに一緒に参加することを希望するユーザーのグループを表す、マッチ チケット セッションを設定します。 このグループ内のすべてのユーザーは、**MultiplayerSession.Join メソッド (String, Boolean, Boolean)** を使用してセッションに参加します。

チケット セッションが作成され、プレイヤーが設定されたら、タイトルは **MatchmakingService.CreateMatchTicketAsync メソッド**を使用してセッションをマッチメイキング サービスに送信します。 このメソッドは、チケット セッションを表すマッチ チケットを作成し、チケット セッションの /servers/matchmaking/properties/system/status フィールドを "searching" に更新します。 詳細については、「[方法: マッチ チケットの作成](multiplayer-how-tos.md)」を参照してください。

マッチ チケット作成メソッドからの応答は **CreateMatchTicketResponse クラス** オブジェクトです。 この応答には、マッチ チケット ID、チケットの削除によってマッチメイキングをキャンセルするために使用できる GUID が含まれます。 応答にはホッパーの平均待ち時間の情報も含まれ、この情報を使ってユーザーの期待を設定できます。


## <a name="setting-matchmaking-attributes-on-the-session-and-players"></a>セッションおよびプレイヤーでのマッチメイキング属性の設定

マッチメイキングへセッションを送信するとき、タイトルは、マッチメイキング サービスがセッションを他のセッションとグループ化するために使用する属性を設定できます。 属性は、チケット レベルまたはメンバーごとのレベルで指定できます。


### <a name="setting-matchmaking-attributes-at-the-match-ticket-level"></a>マッチ チケット レベルでのマッチメイキング属性の設定

タイトルは、**MatchmakingService.CreateMatchTicketAsync** メソッドの *ticketAttributesJson* パラメーターで、マッチ チケット レベルでの属性を送信します。 チケット レベルで指定された属性は、メンバーごとのレベルで指定された同じ属性をオーバーライドします。


### <a name="setting-matchmaking-attributes-at-the-per-member-level"></a>メンバーごとのレベルでのマッチメイキング属性の設定

タイトルは、マッチ チケット セッション内の各メンバーでメンバーごとの属性を指定します。 これらは、**MultiplayerSession.SetCurrentUserMemberCustomPropertyJson メソッド**を呼び出し、プロパティ名 "matchAttrs" を使用して設定されます。 この呼び出しは、属性をチケット セッション内の各プレイヤーの /members/{index}/properties/custom/matchAttrs フィールドに配置します。

マッチメイ キング プロセス均一メンバーごとの各ホッパーの Xbox Live 構成でその属性に対して指定した均一化メソッドに基づいて、単一のチケット レベル属性です。 これは、 [XDP](https://xdp.xboxlive.com)または[Windows デベロッパー センター](https://developer.microsoft.com/dashboard/windows/overview)で構成できます。


## <a name="making-the-match"></a>マッチの実行

設定されたチケット セッションとマッチ チケットを使用して、マッチメイキング サービスは、表されたチケット セッションを他のグループを表す他のチケット セッションとマッチさせ、マッチ ターゲット セッションを作成または識別します。 また、サービスは、ターゲット セッションでマッチされたプレイヤーの予約を作成し、チケット セッションをマッチ済みとしてマークします。 MPSD は、チケット セッションへのこの変更をタイトルに通知します。

次に、タイトルは、十分なプレイヤーが現れたことを確認するためにターゲット セッションを初期化し、サービスの品質 (QoS) チェックを実行してプレイヤーが互いに正しく接続できることを確認するための手順を実行する必要があります。 初期化や QoS が失敗した場合、タイトルは、別のグループを見つけることができるよう、マッチメイキングに再送信するようにチケット セッションをマークします。 プロセスの詳細については、「[ターゲット セッションの初期化と QoS](smartmatch-matchmaking.md)」を参照してください。

マッチ アクティビティ中、以下の変更がセッションの JSON オブジェクトに対して行われます。

-   /servers/matchmaking/properties/system/status フィールドが "found" に設定されます。
-   /servers/matchmaking/properties/system/targetSessionRef フィールドがターゲット セッションに設定されます。
-   各チケット セッションの /members/{index}/properties/custom/matchAttrs フィールドが /members/{index}/constants/custom/matchmakingResult/playerAttrs フィールドにコピーされます。
-   各プレイヤーについて、チケット属性がマッチ チケット内の ticketAttributes フィールドから /members/{index}/constants/custom/matchmakingResult/ticketAttrs フィールドにコピーされます。


## <a name="maintaining-the-match-ticket"></a>マッチ チケットの維持

マッチメイキング サービスは、マッチ チケットがセッションに対して作成されたときのチケット セッションのスナップショットを使用します。 したがって、プレイヤーがチケット セッションに参加した場合やマッチ チケット セッションを抜けた場合、タイトルはマッチメイキング サービスを使用してマッチ チケットを削除し作成しなおす必要があります。


## <a name="reusing-the-game-session-as-a-match-ticket-session"></a>マッチ チケット セッションとしてのゲーム セッションの再利用

| 重要                                                                                                                                                                                                                       |
|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| *preserveSession* が Always に設定された 2 つのセッションは、組み合わせることができないので、互いにマッチングすることができません。 タイトルで使用されるマッチメイキング フローではこの事実を考慮に入れる必要があります。 |

タイトルはマッチ チケット セッションとしての既存のゲーム セッションを再利用し、既に進行中のゲームに参加する追加のプレイヤーを見つけることができます。 これを実行できるようにするには、タイトルは、*preserveSession* パラメーターを **PreserveSessionMode.Always** に設定して **CreateMatchTicketAsync** を呼び出すことによってマッチ チケットを作成する必要があります。 これにより、マッチメイキング サービスは、チケットに使用されている既存のセッションがマッチメイキング プロセス全体を通じて保持され、結果としてターゲット セッションになるようにします。


## <a name="deleting-the-match-ticket"></a>マッチ チケットの削除

マッチ チケットを削除するには、タイトルで **MatchmakingService.DeleteMatchTicketAsync メソッド**を呼び出します。 チケットの削除:

1.  チケット セッションでユーザーのマッチメイキングを停止します。
2.  チケット セッションの /servers/matchmaking/properties/system/status フィールドを "canceled" に更新します。


## <a name="performing-matchmaking-for-games-using-xbox-live-compute"></a>Xbox Live エンジンを使用したゲームのマッチメイキングの実行

ここでは、Xbox Live Compute ベース ゲームでユーザーをマッチメイキングする際に行われる手順の概要を示します。 サード パーティーによってホストされるゲームにも、類似のフローが当てはまるはずです。
1.  スカウトは、グループを表すためのチケット セッションを作成します。 このセッションには、候補となるデータセンターのリストが含まれます。このリストは、/constants/system/measurementServerAddresses のセッション構成内にあります。 このリストは、セッション テンプレート (データセンター リストが静的である場合) から取得されるか、最初に Xbox Live エンジンからリストを取得した後のセッションの作成時にリストを記述したクライアントから取得されます。 このセッションの targetSessionConstants/custom/gameServerPlatform オブジェクトには、gsiSetId、gameVariantId、および maxAllowedPlayers の値も含まれています。
2.  グループに属する他のすべてのクライアントがチケット セッションに参加します。
3.  グループのすべてのメンバーは、/members/{index}/properties/system/serverMeasurements で定義されているように、チケット セッションの /constants/system オブジェクトから measurementServerAddresses 値をダウンロードし、プラットフォーム API を使用してそれらに ping を実行して、優先するデータセンターの順序付きリストをセッションにアップロードします。

| 注意                                                                                                                                                                                                                                                                                                     |
|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| タイトルは、セッションの measurementServerAddresses 値を **MultiplayerSession.SetMeasurementServerAddresses** メソッドおよび **MultiplayerSessionConstants.MeasurementServerAddressesJson プロパティ**を使用して設定および取得できます。 |

4.  スカウトは、チケット セッションへの参照を渡して **CreateMatchTicketAsync** を呼び出します。

| 注意                                                                                                                                                                                                         |
|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| チケット セッション オブジェクトの定数が一致していない場合、チケット作成メソッドは失敗する可能性があります。 これは、ホッパーに必須ルールを追加し、定数が一致しないプレイヤーのマッチを防止することで回避できます。 |

**MatchTicketDetailsResponse.PreserveSession プロパティ**が Never に設定されている場合、マッチメイキング サービスは各メンバーからのサーバー測定値をチケットの内部表現にコピーします。 サービスは、チケットのメンバーのサーバー測定値を、チケットの単一のサーバー測定値コレクションに均一化します。このコレクションは、特別なチケット属性としてチケットの内部表現に格納されます。

**MatchTicketDetailsResponse.PreserveSession** が Always に設定されている場合、サーバー測定値は使用されません。 代わりに、マッチメイキング サービスは、セッションの /properties/system/matchmaking/serverConnectionString 値を、サイズ 1 で遅延ゼロの serverMeasurements コレクションとしてチケットの内部表現にコピーします。

5.  マッチメイキング サービスでは、サーバー測定値コレクションを考慮に入れて、チケット セッションが他のグループを表すその他のチケット セッションとマッチングされます。 同じデータセンターの優先度が高いグループ間でのマッチングが試行されます。
6.  マッチしたグループが見つかったら、マッチメイキング サービスではターゲット セッションが作成または識別され、一緒にマッチされたチケット セッションのすべてのプレイヤーが追加されます。 サービスでは、マッチされたグループの最終的に均一化されたサーバー測定値が /properties/system/serverConnectionStringCandidates に書き込まれます。 ターゲット セッションで新しく追加されたメンバーごとに、最初に送信されたサーバー測定値が /members/{index}/constants/system/matchmakingResult/serverMeasurements に書き込まれます。
7.  すべてのクライアントは、前述のように、ターゲット セッションで初期化を実行します。 ただし、クライアントは Xbox Live エンジンに接続するため、接続確認のための QoS を互いに実行しません。
8.  一部またはすべてのクライアントが **GameServerPlatformService.AllocateClusterAsync メソッド**を呼び出します。 最初の呼び出しによって割り当てがトリガーされ、それ以外の呼び出しでは受信確認のみを受け取ります。 このメソッドによって、MPSD からターゲット セッションが取得され、負荷などの Xbox Live エンジン固有の情報やターゲット セッション内のデータセンター優先順位に基づいて、データセンターが選択されます。
9.  すべてのクライアントがプレイします。


## <a name="see-also"></a>関連項目

[SmartMatch のランタイム操作](smartmatch-matchmaking.md)

[SmartMatch マッチメイキング](smartmatch-matchmaking.md)

**Microsoft.Xbox.Services.Matchmaking 名前空間**

**Microsoft.Xbox.Services.Multiplayer 名前空間**
