---
title: タイトルからのプレイヤー フィードバックの送信
author: KevinAsgari
description: プレイヤー フィードバックを Xbox Live 評判サービスに送信することによって、タイトルで前向きなプレイヤー エクスペリエンスを推進する方法について説明します。
ms.assetid: 49f8eb44-1e31-4248-b645-9123df6f8689
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, 評判, プレイヤー フィードバック
ms.localizationpriority: medium
ms.openlocfilehash: e5239c04bd6a178133129f43fcd8a71c8e532b01
ms.sourcegitcommit: 49aab071aa2bd88f1c165438ee7e5c854b3e4f61
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/09/2018
ms.locfileid: "4463701"
---
# <a name="sending-player-feedback-from-your-title"></a>タイトルからのプレイヤー フィードバックの送信
Xbox Live メンバーの大多数は良いプレイヤーですが、他のプレイヤーのゲーム エクスペリエンスを不愉快なものにする "悪いプレイヤー" もわずかとはいえ存在します。 こうした少数のユーザーは、ユーザーとタイトルから送信されたフィードバックによって識別されます。 このような "悪いプレイヤー" に対しては、良いプレイヤーを妨害できないようにマルチプレイヤー エクスペリエンスを制限することにより、良いプレイヤーを保護します。 Xbox ではシステムで他のユーザーの情報を正確に保つためにユーザーからの報告に大きく依存していますが、Xbox One のタイトルもユーザーの評判や評価の正確さを大幅に向上させるのに直接貢献できます。

## <a name="steps-to-submit-feedback-from-title-or-title-service"></a>タイトルまたはタイトル サービスからフィードバックを送信する手順
1. タイトルまたはタイトル サービスにフィードバック モーメントを追加する
2. 適切なフィードバック タイプを決定する
3. フィードバックで Reputation Feedback API を呼び出す

### <a name="adding-feedback-moments-to-title-or-title-service"></a>タイトルまたはタイトル サービスへのフィードバック モーメントの追加
どのようなゲーマーにも、味方を妨害するチームメイト、積極的にプレイしないで傍観しているプレイヤー、ゲームを台無しにする詐欺師などに出会ったいやな経験があります。 Xbox Live では、ユーザーはこのような問題のあるプレイヤーを直接報告できますが、ユーザーのフィードバックだけでは完全ではありません。 タイトルでは、ゲームでのプレイヤーの怠慢や途中での放棄などの単純な行為を簡単に判別できます。さらに、不正行為さえ特定することもできます。 タイトルはさまざまなフィードバック モーメントでフィードバックを送信でき、それはすべての良いプレイヤーのエクスペリエンスの向上につながります。

### <a name="determining-the-correct-feedback-type"></a>適切なフィードバック タイプの決定
評判システムには、ユーザーがさまざまな機会にフィードバックを提供できるようにするための多くのフィードバック タイプがあります。 その詳細な一覧を次の表 1 に示します。 これらの多くは否定的なものですが、肯定的なフィードバックでユーザーの評判を高めることもできます。

Xbox システムの UI では、プレイヤーがゲーム内での他のユーザーについてのフィードバックを送信する方法が提供されています。 ユーザーは勝負に負けると他のユーザーに不満を持つ傾向があるので、このようなユーザー間のフィードバックには大きな比重は与えられません。 タイトルでシステム UI の追加として、他のユーザーについてのフィードバックを直接送信できる UI を提供できますが、それよりも、タイトルがパートナー フィードバックを使用して代わりにフィードバックを送信する方をお勧めします。 パートナー フィードバックには高い信頼性があります。

## <a name="example-partner-feedback-usage-scenarios"></a>パートナー フィードバック使用シナリオの例

### <a name="user-quitting-a-game-in-the-middle-of-a-match"></a>マッチの途中でゲームを放棄するユーザー
あるプレイヤーはゲームに負けているとゲームのメニューを使ってゲームを終了し、チームメイトを見捨てます。 この行動を検出したタイトルは、**FairPlayQuitter** を使用して報告できます。

### <a name="idling-after-match-found-in-game"></a>ゲーム内で見つかったマッチの後のアイドル状態
プレイヤーは、プレイする他のプレイヤーとマッチされましたが、チームに参加せずにいつまでもゲーム内でアイドル状態のままでいます。 タイトルは **FairplayIdler** を使用してプレイヤーの行動を報告できます。

### <a name="killing-teammates-in-game"></a>ゲーム内でチームメイトを倒す
プレイヤーは面白半分でいつもチームメイトを倒しています。 いつもチームメイトを倒しているユーザーを検出したタイトルは、**FairPlayKillsTeammates** を使用してプレイヤーを報告できます。

### <a name="title-has-community-kickvote-feature"></a>タイトルにコミュニティ キック/投票機能がある
あるプレイヤーは、ラウンド中に他のプレイヤーによる投票によって、悪い行動によりセッションから削除されました。 セッションからプレイヤーを削除したタイトルは、**FairPlayKicked** でそのユーザーを報告できます。

### <a name="helpful-player-community-vote"></a>役に立つプレイヤーのコミュニティ投票
ゲームが数ラウンド終了すると、タイトルは最も優秀なプレイヤーを選ぶオプションを提供します。 このアクションの結果を、タイトルは **PositiveHelpfulPlayer** を使用して報告できます。

### <a name="high-quality-ugc-user-generated-content"></a>高品質の UGC (ユーザー作成コンテンツ)
タイトルには、プレイヤーが車両の最も優れたデザインを選択できるシーンがあります。 このアクションの結果を、タイトルは **PositiveHighQualityUGC** を使用して報告できます。

### <a name="skilled-player"></a>高いスキルを持つプレイヤー
ゲームの数ラウンドの後、最高のプレイをした MVP プレイヤーを選ぶオプションを提供します。 いつも MVP ステータスを獲得するプレイヤーを、タイトルは **PositiveSkilledPlayer** を使用して報告できます。

### <a name="user-reports-questionable-ugc-in-title"></a>ユーザーがタイトル内で問題のある UGC を報告する
タイトルには、プレイヤーが車両のデザインを見ることができるシーンがあります。 プレイヤーは不快なデザインに気付き、それを報告したいと考えます。 このアクションを認識したタイトルは、**UserContentInappropriateUGC** を使用して違反者を報告できます。

### <a name="title-wants-to-request-an-xbl-ban-review-of-a-player-in-their-title"></a>タイトルはタイトル内でのプレイヤーの XBL 違反レビューを要求する
タイトルのコミュニティ マネージャーは、ゲーム内でいつもトラブルの原因になっている低評価プレイヤーに気付いてます。 タイトルは、**FairPlayUserBanRequest** を使用して XBL ポリシーおよび執行チーム レビューを要求できます。

## <a name="complete-behavior-feedback-options"></a>詳細な動作フィードバック オプション
次の表では、タイトルに代わってユーザー フィードバックを送信するために使用できるフィードバックの種類の一覧を示します。 評判サービスは柔軟に変更でき、タイトルのニーズを満たさない場合は新しいフィードバックの種類を簡単に追加できます。 新しいフィードバックの種類が追加されたことを確認したい場合は、担当のアカウント マネージャーに連絡してください。

表 1: 評判サービスがサポートするさまざまなパートナー フィードバックの種類

**フェアプレイに関するフィードバックの種類**               | **説明**
----------------------------------------- | -------------------------------------------------------------------------------------------------------------------------
FairplayKillsTeammates                    | 意図的に自分のチームメイトを倒しているプレイヤーを報告します
FairplayCheater                           | 不正行為を行っていることが確実なプレイヤーを報告します
FairplayTampering                         | 必ずゲーム ディスクにやたら文句を言ったり、ゲームのソフトウェアやハードウェアにその他の干渉を行うプレイヤーを報告します
FairplayUserBanRequest                    | 一時停止の原因になったと考えられるプレイヤーを報告します
FairplayConsoleBanRequest                 | Xbox Live への接続を禁止すべきであると考える本体を報告します
FairplayUnsporting                        | プレイヤーにふさわしくない行動に関わっていることが確実なプレイヤーを報告します
FairplayIdler                             | マルチプレイヤー マッチに参加しているにもかかわらず積極的にプレイしていないプレイヤーを報告します
FairplayLeaderboardCheater                | ランキング上位になるために不正行為を行っていることが確実なプレイヤーを報告します
**コミュニケーションに関するフィードバックの種類**         |
CommsInappropriateVideo                   | ビデオ チャットに不適切なプレイヤーを報告します
**ユーザー作成コンテンツ タイプに関するフィードバックの種類** |
UserContentInappropriateUGC               | タイトルでプレイヤーが作成した不適切なコンテンツを報告します
UserContentReviewRequest                  | XBLPET チームがレビューできるように、問題が起こる前にコンテンツの一部を報告します
UserContentReviewRequestBroadcast         | XBLPET チームがレビューできるように、問題が起こる前にブロードキャストを報告します
UserContentReviewRequestGameDVR           | XBLPET チームがレビューできるように、問題が起こる前に GameDVR クリップを報告します
UserContentReviewRequestScreenshot        | XBLPET チームがレビューできるように、問題が起こる前にスクリーンショットを報告します
**肯定的なフィードバック**                     |
PositiveSkilledPlayer                     | ユーザーが投票を行って MVP を決定できる場合、肯定的なフィードバックに値することが確実なスキルの高いプレイヤーを報告します
PositiveHelpfulPlayer                     | 貢献した別のプレイヤーを報告する UI がゲームにある場合、貢献したプレイヤーを報告します
PositiveHighQualityUGC                    | 別のユーザーのコンテンツを賞賛するための UI がゲームにある場合、コンテンツを肯定的に報告します

## <a name="feedback-api-calls"></a>フィードバック API の呼び出し
タイトルは 2 つの方法を使って評判サービスを呼び出すことができます。 推奨される方法は、認証用のサービス トークンを使用してパートナー サービスからまとめて報告する方法です。 タイトルでは、クライアントから直接ユーザーを報告することもできます。 クライアント API には不正行為対策テクノロジーが組み込まれており、有効であると見なされるにはユーザーについて複数の報告が必要です。 どちらの API もバッチ形式であり、同時に複数のユーザーを報告できます。

タイトルは、以下の Xbox Live API を使用してプレイヤーの評判フィードバックを送信できます。

言語 | API
-------- | --------------------------------------------------------------------------------------------
WinRT    | Microsoft::Xbox::Services::Social::ReputationService.SubmitBatchReputationFeedbackAsync(...)
C++      | xbox::services::social::reputation_service.submit_batch_reputation_feedback(...)

または、タイトルは次に示す直接 REST メソッドを使用することもできます。

API          | URL                                                      | 認証要件
------------ | -------------------------------------------------------- | ---------------------------------------
サービスの POST | https://reputation.xboxlive.com/users/batchfeedback      | パートナーとサンドボックスの要求を含む S トークン
Client POST  | https://reputation.xboxlive.com/users/batchtitlefeedback | タイトルとサンドボックスの要求を含む Xtoken

## <a name="feedback-object"></a>Feedback オブジェクト
Feedback オブジェクトの最新バージョンは 101 で、次の仕様があります。 両方の API では、次のオブジェクト群を想定しています。

メンバー       | 種類   | 説明
------------ | ------ | -----------------------------------------------------------------------------------------------------------------------------------------------------------------
sessionRef   | object | このフィードバックが関連している MPSD セッションを記述するオブジェクト、または null。
feedbackType | string | フィードバックの種類。 設定できる値は ReputationFeedbackType 列挙型で定義されています。
textReason   | string | フィードバックが送信された理由を説明するために送信側が追加したユーザー指定テキスト。 これは、ポリシー実施チームにとって非常に価値があります。
evidenceId   | string | 送信されたフィードバックの証拠として使用できるリソース (例: ゲーム プレイ中に記録されたビデオ ファイル) またはアクティビティ フィード項目の ID。
titleID      | String | プレイされたタイトルのタイトル ID。トークン内に存在しない場合にのみ必要です。
targetXuid   | String | 報告対象のプレイヤーの XUID。

以下に例を示します。

```json
POST https://reputation.xboxlive.com/users/batchtitlefeedback
{
    "items" :
    [
        {
            "targetXuid": "33445566778899",
            "titleId" : null,
            "sessionRef": {
  "scid": "372D829B-FA8E-471F-B696-07B61F09EC20",
  "templateName": "CaptureFlag5",
  "name": "Title56932",
           },
            "feedbackType": "FairPlayKillsTeammates",
            "textReason": "Title detected this player killing team members 19 times",
            "evidenceId": null
        }
    ]
}
```

## <a name="feedback-qa"></a>フィードバックに関する Q&A

### <a name="q-can-i-send-a-hint-to-the-system-to-help-with-humans-that-might-be-looking-at-the-player-report"></a>Q: プレイヤー報告を見る人に役立つヒントをシステムに送信できますか。
A: はい、そうしていただけるととても役に立ちます。 提出されたフィードバックを最終的に確認する責任者に役立つ情報を送るには、"textReason" パラメーターを使用してください。 たとえば、怠けているプレイヤーについては、"ゲームが開始して 5 秒経ってもこのプレイヤーからはユーザー入力を受け取りませんでした" などといった理由を追加できます。 このような理由は XBLPET 実施担当者にとって非常に貴重な情報となります。有用でわかりやすい説明のご提供をお願いします。

### <a name="q-should-i-worry-about-how-often-i-send-in-feedback-on-a-user"></a>Q: ユーザーについてのフィードバックを送信する頻度に注意する必要がありますか。
A: タイトルでは、ユーザーがフィードバックの原因となることが確実な場合に評判サービスを呼び出す必要があります。 システムには、タイトルやユーザーがユーザーに過剰な影響を与えるのを防ぐための複数の安全措置が講じられています。

### <a name="q-can-i-adjust-the-weight-of-the-feedback-being-sent"></a>Q: 送信されるフィードバックのウェイトを調節できますか。
A: いいえ、フィードバックのウェイトは評判サービスが決定します。 システムをよいものにするため、ウェイトは常に調整されています。

### <a name="q-can-i-undo-feedback-ive-sent-on-a-user"></a>Q: ユーザーについて送信したフィードバックを取り消すことはできますか。
A: いいえ、フィードバックは最終的なものです。 タイトルにバグがあり、誤ってフィードバックが送信されている疑いがある場合はご連絡ください。バグが修正されるまで、タイトルはブラックリストに登録されます。

### <a name="q-can-i-see-the-feedback-sent-for-my-title-from-users"></a>Q: ユーザーからタイトルについて送信されたフィードバックを見ることはできますか。
A: 現在、その情報はセルフサービスでは利用できません。 ただし、担当のアカウント マネージャーに問い合わせていただければ、タイトルに固有のデータを提供することができます。 近いうちに、この情報を直接利用できるようにする予定です。そのときは、タイトルを使用する評判の悪いユーザーについての情報も提供します。

### <a name="q-when-i-send-in-console-or-user-ban-review-request-how-do-i-know-what-happened"></a>Q: 本体またはユーザー違反レビュー要求で送信した場合、どうすれば起きたことを確認できますか。
A: 現在、レビューのための情報は XBL ポリシーおよび実施チームに送信されますが、違反レビューについての最新情報を知ることはできません。

### <a name="q-is-there-a-reputation-score-per-title"></a>Q: タイトルごとの評判スコアはありますか。
A: いいえ。 現在、フェアプレイ、コミュニケーション、ユーザー作成コンテンツについての評判のサブスコアはありますが、タイトルごとのスコアはありません。 十分な需要がある場合は将来的にこの機能が追加される可能性はあるので、この機能を要求する場合は担当のアカウント マネージャーに連絡してください。
