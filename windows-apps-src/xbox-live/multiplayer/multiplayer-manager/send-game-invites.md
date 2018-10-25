---
title: ゲームへの招待を送信する
author: KevinAsgari
description: Xbox Live Multiplayer Manager を使用して、プレイヤーにゲームの招待の送信を許可する方法について説明します。
ms.assetid: 8b9a98af-fb78-431b-9a2a-876168e2fd76
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, マルチプレイヤー, Multiplayer Manager, フローチャート, ゲームへの招待
ms.localizationpriority: medium
ms.openlocfilehash: b14ff62d1bb08c5115e5fa766b1b56abf37cbff2
ms.sourcegitcommit: 82c3fc0b06ad490c3456ad18180a6b23ecd9c1a7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/24/2018
ms.locfileid: "5479290"
---
# <a name="send-game-invites"></a>ゲームへの招待を送信する

簡単なマルチプレイヤー シナリオの 1 つは、ゲーマーにフレンドとのオンラインでのゲーム プレイを許可することです。 このシナリオには、ゲームへの参加の招待を別のプレイヤーに送信するために必要な手順が含まれます。

[Multiplayer Manager を初期化](play-multiplayer-with-friends.md)し、[ローカル ユーザーを追加することでロビー セッションを作成](play-multiplayer-with-friends.md)した後は、`user_added` イベントを受け取るまで待ってから、招待の送信を始める必要があります。

招待を送信するには 2 つの方法があります。

1. [Xbox プラットフォームの招待 TCUI](#xbox-platform-invite-tcui)
2. [タイトルで実装したカスタム UI](#title-implemented-custom-ui)

プロセスのフローチャートについては、「[フローチャート - 別のプレイヤーに招待を送信する](mpm-flowcharts/mpm-send-invites.md)」を参照してください。

### <a name="1-xbox-platform-invite-tcui-a-namexbox-platform-invite-tcui"></a>1) Xbox プラットフォームの招待 TCUI <a name="xbox-platform-invite-tcui">

| メソッド | トリガーされるイベント |
| -----|----------------|
| `multiplayer_lobby_session::invite_friends()` | `invite_sent` |

`invite_friends()` を呼び出すと、フレンド招待用の標準の Xbox UI が表示されます。 表示される UI を使用することでプレイヤーは、フレンドまたは最近のプレイヤーを選択し、ゲームに招待できます。 プレイヤーの確認が得られたら、Multiplayer Manager は選択されたプレイヤーに招待を送信します。

**例:**

```cpp
auto result = mpInstance->lobby_session()->invite_friends(xboxLiveContext);
if (result.err())
{
  // handle error
}
```

**Multiplayer Manager によって実行される機能**

* Xbox ストックのタイトルが呼び出せる UI (TCUI) を表示する
* 選択されたプレイヤーに直接、招待を送信する

### <a name="2-title-implemented-custom-uia-nametitle-implemented-custom-ui"></a>2) タイトルで実装したカスタム UI<a name="title-implemented-custom-ui">

| メソッド | トリガーされるイベント |
|-----|----------------|
| `multiplayer_lobby_session::invite_users()` | `invite_sent` |

タイトルでは、オンラインのフレンドを表示して招待するためのカスタム TCUI を実装できます。 ゲームでは、`invite_users()` メソッドを使用し、Xbox Live ユーザー ID によって定義された一連のユーザーに招待を送信できます。 これは、ストック Xbox UI の代わりに独自のゲーム内 UI を使用する場合に役立ちます。

**例:**

```cpp
std::vector<string_t>& xboxUserIds;
xboxUserIds.push_back();  // Add xbox_user_ids from your in-game roster list

auto result = mpInstance->lobby_session()->invite_users(xboxUserIds);
if (result.err())
{
  // handle error
}
```

**Multiplayer Manager によって実行される機能**

* 選択されたプレイヤーに直接、招待を送信する
