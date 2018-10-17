---
title: Feedback (JSON)
assetID: 726117c1-f01b-18c0-3b75-a7a7d27d84a2
permalink: en-us/docs/xboxlive/rest/json-feedback.html
author: KevinAsgari
description: " Feedback (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: e9ef3bb19155199ae94b18b828fb40eb7a0a2ce6
ms.sourcegitcommit: 1c6325aa572868b789fcdd2efc9203f67a83872a
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/17/2018
ms.locfileid: "4744310"
---
# <a name="feedback-json"></a>Feedback (JSON)
プレイヤーに関するフィードバックの情報が含まれています。
<a id="ID4EN"></a>


## <a name="feedback"></a>フィードバック

Feedback オブジェクトでは、次の仕様があります。

| メンバー| 種類| 説明|
| --- | --- | --- |
| sessionRef| object | このフィードバックが関連している MPSD セッションを記述するオブジェクト、または null。 |
| feedbackType| string | フィードバックの種類。 使用可能な値は、 <b>Microsoft.Xbox.Services.Social.ReputationFeedbackType</b>で定義されます。 |
| textReason| string| フィードバックが送信された理由を説明するために送信側が追加したユーザー指定テキスト。 |
| voiceReasonId| string| フィードバックの理由を説明するための追加、送信元が Kinect から音声のユーザーが指定したファイルの ID は、(base-64) を送信します。 |
| evidenceId| string| 送信されたフィードバックの証拠として使用できるリソースの ID、たとえば、ビデオ ファイル中に記録されたゲーム プレイします。 |

<a id="ID4EVC"></a>


### <a name="feedback-types"></a>フィードバックの種類

「によって送信された」列は、フィードバックを送信していることを示します。

   * 「ユーザー」は、送信する、認証のため、XToken を使用してコンソールで**SubmitFeedback**を受け入れることができる API を意味します。
   * 「パートナー」では、送信するため、要求の証明書を使用してパートナーによって API が**SubmitBatchFeedback**を受け入れることができることを意味します。
   * 「プライバシー」は意味 SLS プライバシー サービスのみが、フィードバックを送信できます。
   * "None"には、フィードバックは、内部的に監査 SLS 評判サービスによって生成され、任意の呼び出し元によって送信されることはできませんを意味します。

| 種類| によって送信されました。| 説明|
| --- | --- | --- | --- | --- | --- |
| CommsAbusiveVoice| ユーザー| ユーザーは、タイトル内と Xbox ダッシュ ボードからレポート不適切な音声通信にフィードバックを送信します。 |
| CommsInappropriateVideo| ユーザー、パートナー| ユーザーやパートナーは、タイトル内と Xbox ダッシュ ボードからの不適切なビデオを報告するフィードバックを送信します。 |
| CommsMuted| プライバシー| ユーザーは、別のプレイヤーをミュート、プライバシーは評判サービスにフィードバックを送信します。 |
| CommsPhishing| ユーザー| ユーザーは、フィッシング詐欺を報告するには、このフィードバックを送信します。 |
| CommsPictureMessage| ユーザー| 受信トレイ サービスでは、画像の通信に基づいて、送信者の評判を更新すると、および執行チームにフィードバックを報告評判サービスを呼び出します。 |
| CommsSpam| ユーザー| ユーザーは、スパム メッセージを報告するには、このフィードバックを送信します。 |
| CommsTextMessage| ユーザー| 受信トレイ サービスでは、送信者の評判を更新すると、および執行チームにフィードバックを報告評判サービスを呼び出します。 **注:** 受信トレイ UI メッセージにフラグを設定できるようにするためのボタンが必要です。 |
  | CommsVoiceMessage | ユーザー | 受信トレイ サービスでは、音声メッセージの通信に基づいて、送信者の評判を更新すると、および執行チームにフィードバックを報告評判サービスを呼び出します。  |
  | FairPlayBlock | プライバシー | プライバシーは、ユーザーが別のプレイヤーをブロックしたときに、評判サービスにこのフィードバックを送信します。  |
  | FairPlayCheater | ユーザー、パートナー | ユーザーが不正行為さえ、特定のタイトルには、ユーザーの介入なしには、このフィードバックを送信できます。  |
  | FairPlayConsoleBanRequest | パートナー | パートナーは、Xbox Live からコンソールの使用を禁止することをお勧めとしてこのフィードバックを送信します。  |
  | FairPlayIdler | ユーザー、パートナー | タイトルのかどうか、ユーザーを表しますアイドル意図的にゲームでは後のラウンドで通常ラウンドを決定するには、ユーザーの介入なしには、このフィードバックを送信できます。  |
  | FairPlayKicked | ユーザー、パートナー | ユーザーが (kicked) ゲーム外投票を行うことを検出したタイトルは、ユーザーの介入なしには、このフィードバックを送信できます。  |
  | FairPlayKillsTeammates | ユーザー、パートナー | プレイヤー killls するときに自動的に決定できるタイトル自分のチームメイトは、ユーザーの介入なしには、このフィードバックを送信できます。  |
  | FairPlayQuitter | ユーザー、パートナー | ユーザーが初期ゲームを終了することを決定するタイトルでは、ユーザーの介入なしには、このフィードバックを送信できます。  |
  | FairPlayTampering | ユーザー、パートナー | ディスク上のコンテンツを持つユーザーが改ざんを決定するタイトルでは、ユーザーの介入なしには、このフィードバックを送信できます。  |
  | FairPlayUnblock | プライバシー | プライバシーは、ユーザー別のプレイヤーのブロックを解除するときに、評判サービスにフィードバックを送信します。  |
  | FairPlayUserBanRequest | パートナー | パートナーは、Xbox Live からユーザーのアクセスを禁止することをお勧めとしてこのフィードバックを送信します。  |
  | InternalAmbassadorScoreUpdated | なし | これは、呼び出し元によって使用ではなく、内部のフィードバックの種類です。  |
  | InternalReputationReset | なし | これは、呼び出し元によって使用ではなく、内部のフィードバックの種類です。  |
  | InternalReputationUpdated | なし | これは、呼び出し元によって使用ではなく、内部のフィードバックの種類です。  |
  | PositiveHelpfulPlayer | ユーザー、パートナー | ユーザーおよびパートナーは、ゲーム、フォーラム、内から役立つ仲間プレイヤーに関する情報を正の値を送信するには、このフィードバックを送信します。  |
  | PositiveHighQualityUGC | ユーザー、パートナー | ユーザーやパートナー フィードバックの送信このをタイトルでユーザーが、ゲーム内から共有 UGC に肯定的なフィードバックを送信する必要がありますできるようにすることを示すたとえば、Forza で設定を調整します。  |
  | PositiveSkilledPlayer | ユーザー、パートナー | ユーザーやパートナーをタイトルに MPSD セッションの終了時に行って MVP に投票をユーザーができるようにすることを示すフィードバックを送信します。  |
  | UserContentGamerpic | ユーザー | ユーザーは、ゲーマー カードから直接の不適切なゲーマー アイコンを報告するには、このフィードバックを送信します。  |
  | UserContentGamertag | ユーザー | ユーザーは、ゲーマー カードから直接、不適切なゲーマー タグを報告するには、このフィードバックを送信します。  |
  | UserContentInappropriateUGC | ユーザー、パートナー | ユーザーやパートナーは、タイトルが Forza でペイント ジョブなど、ゲーム内からの不適切な共有 UGC フラグを設定するユーザーを許可する必要がありますかを指定するには、このフィードバックを送信します。  |
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

[JavaScript Object Notation (JSON) オブジェクト リファレンス](atoc-xboxlivews-reference-json.md)
