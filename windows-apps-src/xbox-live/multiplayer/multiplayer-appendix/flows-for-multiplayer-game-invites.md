---
title: マルチプレイヤー ゲームへの招待に関する更新されたフロー
author: KevinAsgari
description: Xbox Live のマルチプレイヤー ゲームへの招待を改善するために更新されたフローを説明します。
ms.assetid: 1569588e-3bbc-47d3-8b7d-cc9774071adc
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, マルチプレイヤー 2015
ms.localizationpriority: medium
ms.openlocfilehash: 257dea8d3a69195b81e23dd43f304eabf99779ca
ms.sourcegitcommit: 3257416aebb5a7b1515e107866806f8bd57845a8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/17/2018
ms.locfileid: "7173342"
---
# <a name="updated-flows-for-multiplayer-game-invites"></a>マルチプレイヤー ゲームへの招待に関する更新されたフロー

Xbox One ベータ フィードバックの結果として、2013 年 11 月 6 日にリリースされた Xbox One Recovery Update 24 で、マルチプレイヤー ゲームへの招待のユーザー エクスペリエンス フローが変更されました。この変更は**ユーザー エクスペリエンス (UX) のみ**に限定され、ゲーム タイトルから見た動作や機能には影響しません。 タイトル デベロッパーがコードを変更する必要はありません。

## <a name="summary-of-changes"></a>変更の概要

-   最初の招待トーストが [join my party] (パーティーに参加) から [&lt;ゲーム タイトル&gt; Let’s Play] (プレイしよう) に変更され、ユーザーがゲームプレイをすぐに開始できるボタンが用意されました。

-   ユーザーが新しい [&lt;ゲーム タイトル&gt; Let’s Play] (プレイしよう) オプションを選択した場合、パーティー アプリは既定ではスナップされません。 この変更のもう 1 つの目的は、ユーザーがゲームプレイにすぐに参加できるようにすることです。

-   送信者側には、[Adding \[*人数*\] friends to the game] ([人数] 人のフレンドをゲームに追加) という新しいトーストが追加されました。 これにより、ゲーム セッションがユーザーのパーティーと関連付けられている場合、招待が送信されたことがはっきりわかるようになります。

以下の例では、詳細なユーザー エクスペリエンス フローについて説明します。 各表では、2 人のユーザー David と Laura に関するフローの例を示します。 これらフローは各列で示されており、並行して行われます。 <b style="background-color: #FFFF00">強調表示されているテキスト</b>は、以前の UX フローから調整が行われたことを示します。

## <a name="inviting-users-from-within-a-game"></a>ゲーム内からのユーザーの招待

<table>
  <tr>
    <td style="border-bottom:solid 1px #fff">
David は、自分がプレイしているゲームのマルチプレイヤー ロビーにいます。<p><br>David は <b>[Invite a Friend]</b> (フレンドを招待する) を選択します。<p><br>David は Laura を選択します。<p><br>招待が送信されたことを示すトーストが表示されます。 | Laura は別のゲームをプレイしています。
    </td>
    <td style="border-bottom:solid 1px #fff">
Laura は別のゲームをプレイしています。
    </td>
  </tr>
  <tr>
    <td></td>
    <td>
David からの招待を示すトーストが表示され、<b style="background-color: #FFFF00">ゲームの名前とアイコンが表示されます</b>  (パーティー アプリは自動スナップしません)。 <p><br>
通知センターで、Laura は <b style="background-color: #FFFF00">[Launch and accept invite] (起動して招待を受ける)</b>、<b>[Accept invite] (招待を受ける)</b>、または <b style="background-color: #FFFF00">[Decline Invite] (招待を断る)</b>を選択できます。
    </td>
  </tr>
  <tr>
    <td colspan="2" style="text-align:center"><b style="background-color: #FFFF00">ケース 1: Laura が [Launch and accept invite] (起動して招待を承諾) を選択する</b> (これは新しいオプションです)</td>
  </tr>
  <tr>
    <td>
Laura が David のパーティーに参加したことを示すトーストが表示されます。             
    <p><br>
David はマルチプレイヤー ロビーからゲームを開始します。                              
    <p><br>
    <b style="background-color: #FFFF00">ゲームへの招待が Laura に送信されたことを示すトーストが表示されます。</b>
    </td>
    <td>
ゲームが起動し、パーティー アプリはスナップしません。
    </td>
  </tr>
  <tr>
    <td colspan="2" style="text-align:center"><b>ケース 2: Laura が [Accept invite] (招待を受ける) を選択する</b></td>
  </tr>
  <tr>
    <td style="border-bottom:solid 1px #fff"></td>
    <td style="border-bottom:solid 1px #fff">Laura がパーティーに参加します。</td>
  </tr>
  <tr>
    <td style="border-bottom:solid 1px #fff"><b style="background-color: #FFFF00">ゲームへの招待が Laura に送信されたことを示すトーストが表示されます。</b></td>
    <td style="border-bottom:solid 1px #fff"></td>
  </tr>
  <tr>
    <td></td>
    <td>そのパーティーに対するゲームが見つかったことを示すトーストが表示されます。
    <p><br>
通知センターで、Laura は以下を選択できます。 <ul>
    <li>   <b>[ゲームへの招待を受ける]:</b> ゲームが起動します。
    <li>   <b>[ゲームへの招待を断る]:</b> ゲームは起動しません。Laura はまだパーティー内にいて、その後のゲームへの招待を受け取ります。         
    <li>   <b style="background-color: #FFFF00">[パーティーから出る]: ゲームは起動しません。Laura はパーティーから削除されます。</b>
    </ul>
    </td>
  </tr>
</table>

## <a name="in-game-invite-flow-in-a-party-and-switching-titles"></a>ゲーム内招待のフロー: パーティー内でのタイトルの切り替え

<table>
  <tr>
    <td>
一緒にゲームをプレイしています。
    <p><br>
David は異なるゲームに切り替えて、マルチプレイヤー メニューに移動します。
     <p><br>
Xbox システム UI で David に対してパーティーを新しいゲームに切り替えるかどうかが確認され、David は <b>[はい]</b> または <b>[いいえ]</b> を選択できます。
    </td>
    <td style="text-align:top">
一緒にゲームをプレイしています。
    </td>
  </tr>
  <tr>
    <td colspan=2 style="text-align:center">
      <b>ケース 1: [はい]</b>
    </td>
  </tr>
  <tr>
    <td style="border-bottom:solid 1px #fff">
パーティーは新しいタイトルに移行します。
    <p><br>
David はマルチプレイヤー ロビーからゲームを開始します。
    <p><br>
    <b style="background-color: #FFFF00">ゲームへの招待が Laura に送信されたことを示すトーストが表示されます。
    </td>
    <td style="border-bottom:solid 1px #fff">
    </td>
  </tr>
  <tr>
    <td></td>
    <td>そのパーティーに対するゲームが見つかったことを示すトーストが表示されます。
    <p><br>
通知センターで、Laura は以下を選択できます。 <ul>
     <li><b>[ゲームへの招待を受ける]:</b> 新しいゲームが起動します。 <li><b>[ゲームへの招待を断る]:</b> ゲームは起動しませんが、Laura はまだパーティー内にいて、それ以降のゲームへの招待を受け取ります。
     <li><b style="background-color: #FFFF00"><b>[パーティーから出る]:</b> ゲームは起動せず、Laura はパーティーから削除されます。</b>
     </ul>
     </td>
  </tr>
  <tr>
    <td colspan=2 style="text-align:center">
      <b>ケース 2: [いいえ]</b>
    </td>
  </tr>
  <tr>
    <td>
パーティーは新しいタイトルに移行しません。
David は、パーティー メンバーのいないマルチプレイヤー モードでプレイします。
David はまだパーティー内にいます。
    </td>
    <td>
    </td>
  </tr>
</table>

## <a name="invite-flow-from-home"></a>ホームからの招待のフロー

<table>
  <tr>
    <td>
David は <b>[ホーム]</b> を表示しており、<b>[フレンド]</b> のリストでは Laura がオンラインであることがわかります。
    <p><br>
David は Laura をパーティーに招待することを選択します。 招待が送信されたことを示すトーストが表示されます。 パーティー アプリは David にスナップされます。
    </td>
    <td>
Laura はゲームをプレイしています。
    </td>
  </tr>
  <tr>
    <td></td>
    <td>
David が自分のパーティーに Laura を招待したことを示すトーストが表示されます。
    <p><br>
通知センターで、Laura には <b>[Accept the invite] (招待を受ける)</b> オプションがあります。
    <p><br>
Laura が招待を受けると、パーティー アプリがスナップします。                                                                         </td>
  </tr>
  <tr>
    <td>
Laura がパーティーに参加したことを示すトーストが表示されます。
    <p><br>
David と Laura はプレイするゲームを相談します。 David はゲームを起動し、マルチプレイヤー ゲーム モードに入ります。
    <p><br>
ゲームでは、フレンドを招待するか、またはパーティー メンバーを自動的にプルするオプションが提供されます。
    <p><br>
    <b style="background-color: #FFFF00">ゲームへの招待が送信されたことを示すトーストが表示されます。</b>
    </td>
    <td>
そのパーティーに対するゲームが見つかったことを示すトーストが表示されます。
    <p><br>
通知センターで、Laura は以下を選択できます。 <ul>
    <li>   <b>[ゲームへの招待を受ける]:</b> ゲームが起動します。 <li>   <b>[ゲームへの招待を断る]:</b> ゲームは起動せず、Laura はまだパーティー内にいて、それ以降の招待を受け取ります。
    <li>   <b style="background-color: #FFFF00">[パーティーから出る]: ゲームは起動せず、Laura はパーティーから削除されます。</b>
    </ul>  
    </td>
  </tr>
</table>


## <a name="more-about-the-game-invite-sent-toast"></a>[ゲームへ招待しました] トーストの詳細

**[ゲームへ招待しました]** トーストは、リモート パーティー メンバーとのゲーム セッションが初めて確立されたときにのみ表示されます。 それ以降にリモート パーティー メンバーに送信される要求では、このトーストは生成されません。 これにより、タイトルが **PullReservedPlayersAsync** を複数回呼び出した場合にユーザーが **[ゲームへ招待しました]** トーストを何度も受け取ることがなくなります。

**注意  ** ベスト プラクティスとしては、招待するすべてのフレンドを予約済みにして追加した後、**PullReservedPlayersAsync** を 1 回だけ呼び出します。
