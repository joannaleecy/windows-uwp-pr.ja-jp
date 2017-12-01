---
title: "トーナメントへの参加"
author: KevinAsgari
description: "プレイヤーがゲームのトーナメントに参加するための UI の作成方法について説明します。"
ms.author: kevinasg
ms.date: 10-10-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, アリーナ, トーナメント, UX"
localizationpriority: medium
ms.openlocfilehash: 5403aed34a4e3fbadf0aa60dfc9da99cee7dd44c
ms.sourcegitcommit: 44a24b580feea0f188c7eae36e72e4a4f412802b
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/31/2017
---
# <a name="join-a-tournament-by-using-the-arena-ui"></a>アリーナ UI を使ってトーナメントに参加する

アリーナ API は、登録、チェックイン、チームに関する情報をタイトルに提供できますが、それに関する*タスクを実行する機能*は*備えていません*。 タイトルでは、アリーナ UI または第三者のトーナメント主催者 (TO) を使用するか、独自のトーナメント管理サポートを構築する必要があります。

## <a name="xbox-arena-ui-team-formation"></a>Xbox アリーナ UI: チームの編成

アリーナ UI は、ゲーマーがチームを編成したり、チームに参加したりする方法を提供します。 タイトルについての要件はありません。

###### <a name="ui-example-create-a-team"></a>UI の例: チームの作成

![チーム編成画面](../../images/arena/arena-ux-create-team.png)

#### <a name="when-forming-a-team-a-gamer-can"></a>チームの編成時に、ゲーマーは次の操作を実行できます。

* 1 人または複数のフレンドやクラブ メンバーに、参加の招待を送信する。
* LFG 広告を投稿して、チーム メンバーを募集する。
* チームを登録または登録解除する。
* チームのメンバーを削除する。

## <a name="xbox-arena-ui-registration"></a>Xbox アリーナ UI: 登録

アリーナ UI は、ゲーマーがチームを登録する方法を提供します。 タイトルについての要件はありません。

###### <a name="ui-example-register-a-team"></a>UI の例: チームの登録

![チーム登録画面](../../images/arena/arena-ux-register-team.png)

#### <a name="when-registering-for-a-tournament-a-user-can"></a>トーナメントへの登録時、ユーザーは次の操作を実行できます。

* 登録受付の*締め切り前*に、トーナメントへの登録を解除する。
* チェックイン時またはトーナメント進行中にチームの登録を解除する。
* チーム全体の登録を解除する。 *個別のユーザーがチームを離脱すると、チーム全体の登録が解除されることに注意してください。*
* キャプテンとして登録する。
* 登録前に、トーナメントの要件と交戦ルールを確認する。
* 登録が正常に完了したことの通知を受信する。
* トーナメントのステータスが "registered" (登録済み) に変更されたことをリアルタイムで確認する。
* トーナメントの開始時に、対戦表をプレビューする。
* トーナメントに登録済みのプレイヤーを参照する。
* それらのプレイヤーがトーナメントの条件を満たしていない場合、登録を拒否する。
* プレイヤーが登録を禁止されている場合、登録を拒否する。

> [!div class="nextstepaction"]
> [マッチの交戦](arena-ux-match-engagement.md)
