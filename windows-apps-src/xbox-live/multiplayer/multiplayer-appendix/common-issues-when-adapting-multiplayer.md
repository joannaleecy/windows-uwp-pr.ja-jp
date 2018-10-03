---
title: マルチプレイヤー 2015 への移行に関する一般的な問題
author: KevinAsgari
description: マルチプレイヤー 2014 のタイトルを 2015 マルチプレイヤーに適合させるときに発生する可能性のある一般的な問題について説明します。
ms.assetid: 206f8fe4-c7aa-44b8-923b-18f679d8439f
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 5ada600bbfec4b8a1a8faa03ac3b71c6fc2d8fff
ms.sourcegitcommit: 1938851dc132c60348f9722daf994b86f2ead09e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/03/2018
ms.locfileid: "4260448"
---
# <a name="common-issues-when-adapting-your-multiplayer-2014-title-to-multiplayer-2015"></a>マルチプレイヤー 2014 のタイトルをマルチプレイヤー 2015 に適合させるときの一般的な問題

ここでは、2014 マルチプレイヤー タイトルを 2015 マルチプレイヤーに適合させるときに考慮する必要がある問題について説明します。


## <a name="configuration-changes-to-make-for-2015-multiplayer"></a>2015 マルチプレイヤーに適合させるための構成の変更

ここでは、2015 マルチプレイヤーのセッションとテンプレートを構成するときに注意する必要がある変更について説明します。 説明している各項目の例については、「[MPSD セッション テンプレート](multiplayer-session-directory.md)」をご覧ください。

### <a name="add-a-capability-for-active-member-connection"></a>アクティブ メンバー接続の機能の追加

connectionRequiredForActiveMembers 機能により、2015 マルチプレイヤーの切断検出機能とセッション変更サブスクリプション機能が有効になります。 すべてのセッション テンプレートの /constants/system/capabilities オブジェクトにこの機能を追加してください。


### <a name="add-a-system-constant-for-invite-protocol"></a>招待プロトコルのシステム定数の追加

inviteProtocol システム定数を追加すると、送信者のタイトルで **MultiplayerService.SendInvitesAsync メソッド**または **SystemUI.ShowSendGameInvitesAsync メソッド (IUser, IMultiplayerSessionReference, String)** が呼び出されたときに、招待の受信者がトーストを受信できるようになります。 タイトルでプレイヤーを招待するセッションについて、すべてのテンプレートの /constants/system オブジェクトにこの定数 ("game" に設定) を追加してください。


## <a name="runtime-considerations-for-2015-multiplayer"></a>2015 マルチプレイヤーに関する実行時の考慮事項

2015 マルチプレイヤー用のタイトルでは、タイトル コードのマルチプレイヤー エリアに入る前に必ず **MultiplayerService.EnableMultiplayerSubscriptions メソッド**を呼び出す必要があります。 この呼び出しによって、セッション変更のサブスクリプションと切断検出の両方が有効になります。
-   同じユーザーによる呼び出しには必ず同じ **XboxLiveContext クラス**のオブジェクトを使用する必要があります。 このコンテキストには、マルチプレイヤーのサブスクリプションと切断検出で使用される接続の管理に関連する状態が含まれます。
-   複数のローカル ユーザーが存在する場合は、ユーザーごとに個別の **XboxLiveContext** オブジェクトを使用します。


## <a name="migrating-a-session-template-from-contract-version-104105-to-107"></a>コントラクト バージョン 104/105 から 107 へのセッション テンプレートの移行

セッション テンプレート コントラクトの最新バージョンは 107 で、MPSD に使用されるスキーマの一部に変更があります。 セッション テンプレート コントラクト バージョン 104/105 に合わせて作成したテンプレートを再発行してバージョン 107 を使用する場合は、そのテンプレートを更新する必要があります。 ここでは、テンプレートを最新バージョンに移行するときに行う変更の概要について説明します。 テンプレートについては、「[MPSD セッション テンプレート](multiplayer-session-directory.md)」をご覧ください。

| 重要                                                                                                                                                                                                                                                      |
|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| テンプレートを使用して設定された機能は、MPSD への書き込みによって変更できません。 値を変更するには、必要な変更を行った新しいテンプレートを作成し、送信する必要があります。 テンプレートで設定されない項目はすべて、MPSD への書き込みによって変更できます。 |


### <a name="changes-to-the-constantssystemmanagedinitialization-object"></a>/constants/system/managedInitialization オブジェクトへの変更

/constants/system/managedInitialization オブジェクトの名前は /constants/system/memberInitialization に変更されています。 このオブジェクトの名前/値ペアに行う変更は次のとおりです。autoEvaluate は externalEvaluation に名前を変更します。 その極性が変化します。ただし、false は既定値のままです。
-   membersNeededToStart の既定値を 2 から 1 に変更します。
-   joinTimeout の既定値を 5 秒から 10 秒に変更します。
-   measurementTimeout の既定値を 5 秒から 30 秒に変更します。


### <a name="changes-to-the-constantssystemtimeouts-object"></a>/constants/system/timeouts オブジェクトへの変更

/constants/system/timeouts オブジェクトは削除され、timeouts の名前は変更され、/constants/system に再配置されます。 このオブジェクトの名前/値ペアに行う変更は次のとおりです。予約タイムアウトは reservedRemovalTimeout になります。
-   非アクティブ タイムアウトは inactiveRemovalTimeout になります。 新しい既定値は 0 (時間単位) です。
-   ready タイムアウトは readyRemovalTimeout になります。
-   sessionEmpty タイムアウトは sessionEmptyTimeout になります。

タイムアウトの詳細については、「[セッション タイムアウト](mpsd-session-details.md)」に記載されています。


### <a name="change-to-the-game-play-capability"></a>ゲーム プレイ機能への変更

ゲーム プレイ機能は、最近のプレイヤーと評判のレポートを有効にします。 マッチ セッション、ロビー セッションなどのヘルパー セッションとは対照的に、実際のゲーム プレイを表すセッションでは、/constants/system/capabilities/gameplay フィールドを true に指定する必要があります。


## <a name="see-also"></a>関連項目

[MPSD セッション テンプレート](mpsd-session-details.md)
