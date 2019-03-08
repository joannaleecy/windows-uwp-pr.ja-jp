---
title: Feedback (JSON)
assetID: 726117c1-f01b-18c0-3b75-a7a7d27d84a2
permalink: en-us/docs/xboxlive/rest/json-feedback.html
description: " Feedback (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 9cc1cb4ecc12219d54af1c4ab420671f2bbfa81f
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57644767"
---
# <a name="feedback-json"></a>Feedback (JSON)
プレーヤーのフィードバックについてを説明します。
<a id="ID4EN"></a>


## <a name="feedback"></a>Feedback

フィードバックのオブジェクトには、次の仕様があります。

| メンバー| 種類| 説明|
| --- | --- | --- |
| sessionRef| オブジェクト | このフィードバックが関連している MPSD セッションを記述するオブジェクト、または null。 |
| feedbackType| string | フィードバックの種類。 使用可能な値が定義されている、 <b>Microsoft.Xbox.Services.Social.ReputationFeedbackType</b>します。 |
| textReason| string| フィードバックが送信された理由を説明するために送信側が追加したユーザー指定テキスト。 |
| voiceReasonId| string| フィードバックの理由を説明する追加の送信者が Kinect の音声のユーザーが指定したファイルの ID は送信 (base-64) です。 |
| evidenceId| string| フィードバックの送信中の証拠として使用できるリソースの ID、たとえば、ビデオ ファイル記録ゲーム プレイ中にします。 |

<a id="ID4EVC"></a>


### <a name="feedback-types"></a>フィードバックの種類

「によって送信される」列は、フィードバックを送信することを示します。

   * "User"では、認証、XToken を使用して、コンソールで送信することを意味、そのため、API できる**SubmitFeedback**します。
   * 「パートナー」を意味のパートナーから送信する要求の証明書を使用して、そのため、API できる**SubmitBatchFeedback**します。
   * [プライバシー] では、SLS プライバシー サービスのみが、フィードバックを送信できますを意味します。
   * "None"は、フィードバックを監査するため、SLS reputation service によって内部的に生成される、呼び出し元を送信できませんを意味します。

| 種類| によって送信されます。| 説明|
| --- | --- | --- | --- | --- | --- |
| CommsAbusiveVoice| ユーザー| ユーザーは、タイトルに、および Xbox ダッシュ ボードからレポート不適切な音声通信にフィードバックを送信します。 |
| CommsInappropriateVideo| ユーザー、パートナー| ユーザーとパートナーは、レポートにタイトル、および Xbox ダッシュ ボードから不適切なビデオへのフィードバックを送信します。 |
| CommsMuted| プライバシー| ユーザーは、別のプレーヤーをミュート、プライバシーに関するこのフィードバック reputation service に送信します。 |
| CommsPhishing| ユーザー| ユーザーは、フィッシング メッセージを報告するには、このフィードバックを送信します。 |
| CommsPictureMessage| ユーザー| 画像の通信に基づいて、送信者の評価を更新し、強制チームにフィードバックを報告する評価サービスを呼び出し、受信トレイ サービス。 |
| CommsSpam| ユーザー| ユーザーは、スパム メッセージを報告するには、このフィードバックを送信します。 |
| CommsTextMessage| ユーザー| 送信者の評価を更新し、強制チームにフィードバックを報告する評価サービスを呼び出し、受信トレイ サービス。 **注:** 受信トレイの UI メッセージにフラグを設定できるようにするためのボタンがあります。 |
  | CommsVoiceMessage | ユーザー | 音声メッセージの通信に基づいて、送信者の評価を更新し、強制チームにフィードバックを報告する評価サービスを呼び出し、受信トレイ サービス。  |
  | FairPlayBlock | プライバシー | プライバシーは、ユーザーが別のプレーヤーをブロックする場合に、reputation service にこのフィードバックを送信します。  |
  | FairPlayCheater | ユーザー、パートナー | ユーザーが不正であるかを決定するタイトルは、ユーザーの介入なしには、このフィードバックを送信できます。  |
  | FairPlayConsoleBanRequest | パートナー | パートナーは、Xbox Live からのコンソールのアクセスを禁止する推奨事項として、このフィードバックを送信します。  |
  | FairPlayIdler | ユーザー、パートナー | タイトルのかどうか、ユーザーの代理としてアイドル意図的にゲーム、round 後、は、通常ラウンドを決定するには、ユーザーの介入なしには、このフィードバックを送信できます。  |
  | FairPlayKicked | ユーザー、パートナー | タイトル (開始) ゲームから、ユーザーが投票されたことを検出するには、ユーザーの介入なしには、このフィードバックを送信できます。  |
  | FairPlayKillsTeammates | ユーザー、パートナー | Player killls ときに自動的に決定できるタイトル チームメイト彼は、ユーザーの介入なしには、このフィードバックを送信できます。  |
  | FairPlayQuitter | ユーザー、パートナー | タイトル、ユーザーが早期ゲームを終了することを決定するには、ユーザーの介入なしには、このフィードバックを送信できます。  |
  | FairPlayTampering | ユーザー、パートナー | タイトル、ユーザーがディスク上のコンテンツを改ざんするのかを決定するには、ユーザーの介入なしには、このフィードバックを送信できます。  |
  | FairPlayUnblock | プライバシー | プライバシーは、別のプレーヤーのブロックを解除するときに、reputation service にこのフィードバックを送信します。  |
  | FairPlayUserBanRequest | パートナー | パートナーは、Xbox Live のユーザーのアクセスを禁止する推奨事項として、このフィードバックを送信します。  |
  | InternalAmbassadorScoreUpdated | なし | これは、呼び出し元が使用ではなく、内部のフィードバックの種類です。  |
  | InternalReputationReset | なし | これは、呼び出し元が使用ではなく、内部のフィードバックの種類です。  |
  | InternalReputationUpdated | なし | これは、呼び出し元が使用ではなく、内部のフィードバックの種類です。  |
  | PositiveHelpfulPlayer | ユーザー、パートナー | ユーザーとパートナーは、ゲーム、フォーラム、および具合内から便利な仲間プレイヤーに関する情報を正の値を送信するには、このフィードバックを送信します。  |
  | PositiveHighQualityUGC | ユーザー、パートナー | ユーザーとパートナー フィードバックの送信このを示すタイトルが、ゲーム内から共有 UGC の正のフィードバックを送信するユーザーを許可する必要がありますなど、Forza で設定をチューニングします。  |
  | PositiveSkilledPlayer | ユーザー、パートナー | ユーザーとパートナーは、タイトルに MPSD セッションの最後に、MVP に投票するユーザーができるようにすることを示すには、このフィードバックを送信します。  |
  | UserContentGamerpic | ユーザー | ユーザーは、ゲーマーのカードから直接の不適切なゲーマー画像をレポートするには、このフィードバックを送信します。  |
  | UserContentGamertag | ユーザー | ユーザーは、ゲーマーのカードから直接の不適切なゲーマー タグを報告するには、このフィードバックを送信します。  |
  | UserContentInappropriateUGC | ユーザー、パートナー | ユーザーとパートナーは、タイトルが Forza でペイント ジョブなど、ゲーム内から不適切な共有 UGC フラグを設定するユーザーを許可する必要がありますを指定するには、このフィードバックを送信します。  |
  | UserContentPersonalInfo | ユーザー | ユーザーは、自己紹介およびゲーマーのカードから直接他の個人情報を報告するには、このフィードバックを送信します。  |

<a id="ID4EFEAC"></a>


## <a name="sample-json-syntax"></a>サンプルの JSON の構文


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

[JavaScript Object Notation (JSON) オブジェクトの参照](atoc-xboxlivews-reference-json.md)
