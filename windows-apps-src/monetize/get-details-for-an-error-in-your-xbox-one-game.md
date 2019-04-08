---
description: Microsoft Store analytics API の詳細なデータを取得する、特定のエラー、Xbox One 向けゲームのこのメソッドを使用します。
title: Xbox One ゲームのエラーに関する詳細情報の取得
ms.date: 11/06/2018
ms.topic: article
keywords: Windows 10, UWP, Store サービス, Microsoft Store 分析 API, エラー, 詳細
ms.localizationpriority: medium
ms.openlocfilehash: da3252c42a0c2e2bd02465985737125cc053a616
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57589967"
---
# <a name="get-details-for-an-error-in-your-xbox-one-game"></a>Xbox One ゲームのエラーに関する詳細情報の取得

Microsoft Store analytics API 詳細なデータの取得、特定のエラー、Xbox One のゲームを Xbox 開発者ポータル (XDP) を取り込んだして XDP Analytics パートナー センター ダッシュ ボードで使用できる、このメソッドを使用します。 このメソッドで取得できるのは、過去 30 日以内に発生したエラーの詳細のみです。

最初に使用する必要があるこのメソッドを使用する前に、 [、Xbox One のデータを報告するエラーが発生するゲーム](get-error-reporting-data-for-your-xbox-one-game.md)詳細情報を取得するエラーの ID を取得します。

## <a name="prerequisites"></a>前提条件


このメソッドを使うには、最初に次の作業を行う必要があります。

* Microsoft Store 分析 API に関するすべての[前提条件](access-analytics-data-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。
* このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら新しいトークンを取得できます。
* 詳細情報を取得するエラーの ID を取得します。 この ID を取得するには、使用、 [、Xbox One のデータを報告するエラーが発生するゲーム](get-error-reporting-data-for-your-xbox-one-game.md)メソッドを使用して、 **failureHash**メソッドの応答本文内の値。

## <a name="request"></a>要求


### <a name="request-syntax"></a>要求の構文

| メソッド | 要求 URI                                                          |
|--------|----------------------------------------------------------------------|
| GET    | ```https://manage.devcenter.microsoft.com/v1.0/my/analytics/xbox/failuredetails``` |


### <a name="request-header"></a>要求ヘッダー

| Header        | 種類   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| Authorization | string | 必須。 **Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。 |


### <a name="request-parameters"></a>要求パラメーター

| パラメーター        | 種類   |  説明      |  必須  
|---------------|--------|---------------|------|
| applicationId | string | **Store ID**エラーの詳細を取得する Xbox One のゲームの。 **Store ID**はパートナー センターでアプリ id のページで使用できます。 例**Store ID** 9WZDNCRFJ3Q8 です。 |  〇  |
| failureHash | string | 取得する詳細情報の対象となるエラーの一意の ID です。 興味のあるエラーのこの値を取得する、 [、Xbox One のデータを報告するエラーが発生するゲーム](get-error-reporting-data-for-your-xbox-one-game.md)メソッドを使用して、 **failureHash**メソッドの応答本文内の値。 |  〇  |
| startDate | date | 取得する詳細なエラー データの日付範囲の開始日です。 既定値は、現在の日付の 30 日前です。 |  X  |
| endDate | date | 取得する詳細なエラー データの日付範囲の終了日です。 既定値は現在の日付です。 |  X  |
| top | int | 要求で返すデータの行数です。 最大値および指定しない場合の既定値は 10000 です。 クエリにこれを上回る行がある場合は、応答本文に次リンクが含まれ、そのリンクを使ってデータの次のページを要求できます。 |  X  |
| skip | int | クエリでスキップする行数です。 大きなデータ セットを操作するには、このパラメーターを使用します。 たとえば、top=10 と skip=0 を指定すると、データの最初の 10 行が取得され、top=10 と skip=10 を指定すると、データの次の 10 行が取得されます。 |  X  |
| filter |string  | 応答内の行をフィルター処理する 1 つまたは複数のステートメントです。 各ステートメントには、応答本文からのフィールド名、および **eq** 演算子または **ne** 演算子と関連付けられる値が含まれており、**and** や **or** を使用してステートメントを組み合わせることができます。 *filter* パラメーターでは、文字列値を単一引用符で囲む必要があります。 応答本文から次のフィールドを指定することができます。<p/><ul><li><strong>market</strong></li><li><strong>date</strong></li><li><strong>cabId</strong></li><li><strong>cabExpirationTime</strong></li><li><strong>deviceType</strong></li><li><strong>DeviceModel</strong></li><li><strong>osVersion</strong></li><li><strong>osRelease</strong></li><li><strong>packageVersion</strong></li><li><strong>osBuild</strong></li></ul> | X   |
| orderby | string | 結果データ値の順序を指定するステートメントです。 構文は <em>orderby=field [order],field [order],...</em> です。<em>field</em> パラメーターには、次のいずれかの文字列を指定できます。<ul><li><strong>market</strong></li><li><strong>date</strong></li><li><strong>cabId</strong></li><li><strong>cabExpirationTime</strong></li><li><strong>deviceType</strong></li><li><strong>DeviceModel</strong></li><li><strong>osVersion</strong></li><li><strong>osRelease</strong></li><li><strong>packageVersion</strong></li><li><strong>osBuild</strong></li></ul><p><em>order</em> パラメーターは省略可能であり、<strong>asc</strong> または <strong>desc</strong> を指定して、各フィールドを昇順または降順にすることができます。 既定値は <strong>asc</strong> です。</p><p><em>orderby</em> 文字列の例: <em>orderby=date,market</em></p> |  いいえ  |


### <a name="request-example"></a>要求の例

次の例では、ゲームを Xbox One の詳細なエラー データを取得するためのいくつかの要求を示します。 置換、 *applicationId*値を**Store ID**ゲームにします。

```syntax
GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/xbox/failuredetails?applicationId=BRRT4NJ9B3D1&failureHash=012e33e3-dbc9-b12f-c124-9d9810f05d8b&startDate=2016-11-05&endDate=2016-11-06&top=10&skip=0 HTTP/1.1
Authorization: Bearer <your access token>

GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/xbox/failuredetails?applicationId=BRRT4NJ9B3D1&failureHash=012e33e3-dbc9-b12f-c124-9d9810f05d8b&startDate=2016-11-05&endDate=2016-11-06&top=10&skip=0&filter=market eq 'US' and deviceType eq 'Windows.Desktop' HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a>応答


### <a name="response-body"></a>応答本文

| Value      | 種類    | 説明    |
|------------|---------|------------|
| Value      | array   | 詳細なエラー データが含まれているオブジェクトの配列です。 各オブジェクトのデータについて詳しくは、次の「[エラーの詳細情報の値](#error-detail-values)」セクションをご覧ください。          |
| @nextLink  | string  | データの追加ページがある場合、この文字列には、データの次のページを要求するために使用できる URI が含まれます。 たとえば、要求の **top** パラメーターを 10 に設定した場合、クエリに適合するエラーが 10 行を超えると、この値が返されます。 |
| TotalCount | 整数 | クエリの結果データ内の行の総数です。        |


<span id="error-detail-values"/>

### <a name="error-detail-values"></a>エラーの詳細情報の値

*Value* 配列の要素には、次の値が含まれます。

| Value           | 種類    | 説明     |
|-----------------|---------|----------------------------|
| applicationId   | string  | **Store ID** Xbox One ゲーム詳細なエラー データを取得します。      |
| failureHash     | string  | エラーの一意の識別子です。     |
| failureName     | string  | 4 つの部分から成るエラーの名前です。問題が発生した 1 つ以上のクラス、例外/バグ チェック コード、障害が発生したイメージの名前、関連する関数の名前で構成されます。           |
| date            | string  | エラー データの日付範囲の最初の日付です。 要求に日付を指定した場合、この値はその日付になります。 要求に週、月、またはその他の日付範囲を指定した場合、この値はその日付範囲の最初の日付になります。 |
| cabId           | string  | このエラーに関連付けられている CAB ファイルの一意の ID です。   |
| cabExpirationTime  | string  | CAB ファイルの有効期限が切れ、ダウンロードできなくなる日付と時刻 (ISO 8601形式) です。   |
| market          | string  | デバイス市場の ISO 3166 国コードです。     |
| osBuild         | string  | エラーが発生した OS のビルド番号です。       |
| packageVersion  | string  | このエラーに関連付けられているゲームのパッケージのバージョン。    |
| deviceModel           | string  | ゲームが実行されているエラーが発生したときに、Xbox One のコンソールを指定する次の文字列の 1 つ。<p/><ul><li><strong>Microsoft Xbox いずれか</strong></li><li><strong>Microsoft Xbox の 1 つの S</strong></li><li><strong>Microsoft Xbox One X</strong></li></ul>  |
| osVersion       | string  | エラーが発生した OS のバージョンです。 これは、値は常に**Windows 10**します。    |
| osRelease       | string  |  次のエラーが発生した (OS のバージョン内で subpopulation) として Windows 10 の OS のリリースまたはフライト リングを指定する文字列の 1 つ。<p/><ul><li><strong>バージョン 1507</strong></li><li><strong>バージョン 1511</strong></li><li><strong>バージョン 1607</strong></li><li><strong>バージョン 1703</strong></li><li><strong>バージョン 1709</strong></li><li><strong>バージョン 1803</strong></li><li><strong>Release Preview</strong></li><li><strong>Insider Fast</strong></li><li><strong>低速 insider</strong></li></ul><p>OS リリースまたはフライティング リングが不明な場合、このフィールドは値 <strong>Unknown</strong> になります。</p>    |
| deviceType      | string  | エラーが発生したデバイスの種類です。 これは、値は常に**コンソール**します。     |
| cabDownloadable           | ブール値  | このユーザーが CAB ファイルをダウンロードできるかどうかを示します。   |


### <a name="response-example"></a>応答の例

この要求の JSON 返信の本文の例を次に示します。

```json
{
  "Value": [
    {
      "applicationId": "BRRT4NJ9B3D1",
      "failureHash": "012345-5dbc9-b12f-c124-9d9810f05d8b",
      "failureName": "STOWED_EXCEPTION_System.UriFormatException_exe!ContosoSports.GroupedItems+_ItemView_ItemClick_d__9.MoveNext",
      "date": "2018-02-05 09:11:25",
      "cabId": "133637331323",
      "cabExpirationTime": "2016-12-05 09:11:25",
      "market": "US",
      "osBuild": "10.0.17134",
      "packageVersion": "1.0.2.6",
      "deviceModel": "Microsoft-Xbox One",
      "osVersion": "Windows 10",
      "osRelease": "Version 1803",
      "deviceType": "Console",
      "cabDownloadable": false
    }
  ],
  "@nextLink": null,
  "TotalCount": 1
}
```

## <a name="related-topics"></a>関連トピック

* [Microsoft Store サービスを使用して分析データにアクセス](access-analytics-data-using-windows-store-services.md)
* [レポート データを Xbox One のエラーが発生するゲーム](get-error-reporting-data-for-your-xbox-one-game.md)
* [ゲーム、Xbox One でエラーのスタック トレースを取得します。](get-the-stack-trace-for-an-error-in-your-xbox-one-game.md)
* [Xbox One、ゲームでエラー用の CAB ファイルをダウンロードします。](download-the-cab-file-for-an-error-in-your-xbox-one-game.md)
