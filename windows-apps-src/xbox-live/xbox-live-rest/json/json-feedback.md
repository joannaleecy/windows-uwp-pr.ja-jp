---
title: フィードバック (JSON)
assetID: 726117c1-f01b-18c0-3b75-a7a7d27d84a2
permalink: en-us/docs/xboxlive/rest/json-feedback.html
author: KevinAsgari
description: " フィードバック (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: e9ef3bb19155199ae94b18b828fb40eb7a0a2ce6
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3881654"
---
# <a name="feedback-json"></a>フィードバック (JSON)
プレイヤーに関するフィードバックの情報が含まれています。
<a id="ID4EN"></a>


## <a name="feedback"></a>フィードバック

Feedback オブジェクトには、次の仕様があります。

| メンバー| 種類| 説明|
| --- | --- | --- |
| sessionRef| object | このフィードバックが関連している MPSD セッションを記述するオブジェクト、または null。 |
| feedbackType| string | フィードバックの種類。 設定可能な値は、 <b>Microsoft.Xbox.Services.Social.ReputationFeedbackType</b>で定義されます。 |
| textReason| string| フィードバックが送信された理由を説明するために送信側が追加したユーザー指定テキスト。 |
| voiceReasonId| string| 送信者の理由、フィードバックの説明に追加された Kinect から音声のユーザーが指定したファイルの ID は、(base-64) を送信します。 |
| evidenceId| string| 送信されたフィードバックの証拠として使用できるリソースの ID、たとえば、ビデオ ファイル中に記録されたゲーム プレイします。 |

<a id="ID4EVC"></a>


### <a name="feedback-types"></a>フィードバックの種類

「によって送信された」列は、フィードバックを送信していることを示します。

   * 「ユーザー」できます提出することを使って、XToken 認証、そのため、コンソールで、API が**SubmitFeedback**を受け入れることができることを意味します。
   * 「パートナー」は、送信するため、要求の証明書を使用してパートナー **SubmitBatchFeedback**を受け入れることができる API を意味します。
   * 「プライバシー」は意味 SLS プライバシー サービスのみが、フィードバックを送信できます。
   * "None"を示し、フィードバック SLS 評判サービスの監査を内部的に生成された任意の呼び出しによって送信されることはできません。

| 種類| によってを送信| 説明|
| --- | --- | --- | --- | --- | --- |
| CommsAbusiveVoice| ユーザー| ユーザーは、タイトル内と Xbox ダッシュ ボードからレポート不適切な音声通信をフィードバックを送信します。 |
| CommsInappropriateVideo| ユーザーは、パートナー| ユーザーやパートナーは、タイトル内と Xbox ダッシュ ボードからの不適切なビデオを報告するフィードバックを送信します。 |
| CommsMuted| プライバシー| ユーザーは、別のプレイヤーをミュート、プライバシーは評判サービスにこのフィードバックを送信します。 |
| CommsPhishing| ユーザー| ユーザーは、フィッシング詐欺を報告するには、このフィードバックを送信します。 |
| CommsPictureMessage| ユーザー| インボックス サービスは、画像の通信に基づく、送信者の評判を更新すると、および執行チームにフィードバックを報告評判サービスを呼び出します。 |
| CommsSpam| ユーザー| ユーザーは、スパム メッセージを報告するには、このフィードバックを送信します。 |
| CommsTextMessage| ユーザー| インボックス サービスは、送信者の評判を更新すると、および執行チームにフィードバックを報告評判サービスを呼び出します。 **注:** 受信トレイ UI メッセージにフラグを設定できるようにするためのボタンがあります。 |
  | CommsVoiceMessage | ユーザー | インボックス サービスは、音声メッセージの通信に基づく、送信者の評判を更新すると、および執行チームにフィードバックを報告評判サービスを呼び出します。  |
  | FairPlayBlock | プライバシー | プライバシーは、ユーザーが別のプレイヤーをブロックしたときに、評判サービスにこのフィードバックを送信します。  |
  | FairPlayCheater | ユーザーは、パートナー | ユーザーが不正行為さえ、特定のタイトルには、ユーザーの介入なしには、このフィードバックを送信できます。  |
  | FairPlayConsoleBanRequest | パートナー | パートナーは、Xbox Live からのコンソールを禁止することをお勧めとしてこのフィードバックを送信します。  |
  | FairPlayIdler | ユーザーは、パートナー | タイトルのかどうか、ユーザーを表しますアイドル状態にゲームでは、ラウンドの後に通常ラウンドを決定するには、ユーザーの介入なしには、このフィードバックを送信できます。  |
  | FairPlayKicked | ユーザーは、パートナー | ユーザーが (開始) ゲーム外投票を行うことを検出するためのタイトルでは、ユーザーの介入なしには、このフィードバックを送信できます。  |
  | FairPlayKillsTeammates | ユーザーは、パートナー | タイトルでプレイヤー killls ときに自動的に決定できる自分のチームメイトは、ユーザーの介入なしには、このフィードバックを送信できます。  |
  | FairPlayQuitter | ユーザーは、パートナー | ユーザーが初期ゲームを終了することを決定するタイトルでは、ユーザーの介入なしには、このフィードバックを送信できます。  |
  | FairPlayTampering | ユーザーは、パートナー | ユーザーがディスク上のコンテンツを改ざんことを決定するタイトルでは、ユーザーの介入なしには、このフィードバックを送信できます。  |
  | FairPlayUnblock | プライバシー | プライバシーは、ユーザー別のプレイヤーのブロックを解除するときに、評判サービスにこのフィードバックを送信します。  |
  | FairPlayUserBanRequest | パートナー | パートナーは、Xbox Live からユーザーを禁止することをお勧めとしてこのフィードバックを送信します。  |
  | InternalAmbassadorScoreUpdated | なし | これは、呼び出し元が使うのではなく、内部のフィードバックの種類です。  |
  | InternalReputationReset | なし | これは、呼び出し元が使うのではなく、内部のフィードバックの種類です。  |
  | InternalReputationUpdated | なし | これは、呼び出し元が使うのではなく、内部のフィードバックの種類です。  |
  | PositiveHelpfulPlayer | ユーザーは、パートナー | ユーザーやパートナーは、ゲーム、フォーラム、内から、職場のプレイヤーの役立つに関する正の情報を送信するには、このフィードバックを送信します。  |
  | PositiveHighQualityUGC | ユーザーは、パートナー | ユーザーやパートナー フィードバックを送信このをタイトルでユーザーに、ゲーム内から共有 UGC 肯定的なフィードバックを送信する必要がありますできるようにすることを示すたとえば、Forza で設定を調整します。  |
  | PositiveSkilledPlayer | ユーザーは、パートナー | ユーザーやパートナーは、タイトルが MPSD セッションの終了時に行って MVP に投票ユーザーにできることを示すには、このフィードバックを送信します。  |
  | UserContentGamerpic | ユーザー | ユーザーは、ゲーマー カードから直接の不適切なゲーマー アイコンを報告するには、このフィードバックを送信します。  |
  | UserContentGamertag | ユーザー | ユーザーは、ゲーマー カードから直接、不適切なゲーマー タグを報告するには、このフィードバックを送信します。  |
  | UserContentInappropriateUGC | ユーザーは、パートナー | ユーザーやパートナーは、タイトルが Forza でペイント ジョブなど、ゲーム内からの不適切な共有 UGC フラグを設定するユーザーを許可する必要がありますかを指定するには、このフィードバックを送信します。  |
  | UserContentPersonalInfo | ユーザー | ユーザーは、自己紹介およびゲーマー カードから直接、他の個人情報を報告するには、このフィードバックを送信します。  |

<a id="ID4EFEAC"></a>


## <a name="sample-json-syntax"></a>JSON 構文の例


```json
{
"sessionRef": {
  "scid": "372D829B-FA8E-471F-B696-07B61F09EC20",
  "templateName": "CaptureFlag5",
  "name": "Halo556932",
  },
  "feedbackType": "CommsAbusiveVoice",
  "textReason": "He called me a doodoo-head!",
  "voiceReasonId": null,
  "evidenceId": null
}

```


<a id="ID4EOEAC"></a>


## <a name="see-also"></a>関連項目

<a id="ID4EQEAC"></a>


##### <a name="parent"></a>Parent

[JavaScript オブジェクト Notation (JSON) オブジェクト リファレンス](atoc-xboxlivews-reference-json.md)
