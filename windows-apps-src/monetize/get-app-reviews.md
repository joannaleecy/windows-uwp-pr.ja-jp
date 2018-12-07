---
ms.assetid: 2967C757-9D8A-4B37-8AA4-A325F7A060C5
description: 日付範囲やその他のオプション フィルターを指定してレビュー データを取得するには、Microsoft Store 分析 API の以下のメソッドを使います。
title: アプリのレビューの取得
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, Store サービス, Microsoft Store 分析 API, レビュー
ms.localizationpriority: medium
ms.openlocfilehash: 084158c0eb20f1d2a03c0e178064ac168c689872
ms.sourcegitcommit: a3dc929858415b933943bba5aa7487ffa721899f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/07/2018
ms.locfileid: "8781164"
---
# <a name="get-app-reviews"></a>アプリのレビューの取得


日付範囲やその他のオプション フィルターを指定して、レビュー データを JSON 形式で取得するには、Microsoft Store 分析 API の以下のメソッドを使います。 この情報は、 [[レビュー] レポート](../publish/reviews-report.md)では、パートナー センターで利用可能なもできます。

レビューを取得した後、Microsoft Store レビュー API の[アプリのレビューへの返信情報の取得](get-response-info-for-app-reviews.md)メソッドと[アプリ レビューへの返信の提出](submit-responses-to-app-reviews.md)のメソッドを使って、プログラムでレビューに返信できます。

## <a name="prerequisites"></a>前提条件

このメソッドを使うには、最初に次の作業を行う必要があります。

* Microsoft Store 分析 API に関するすべての[前提条件](access-analytics-data-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。
* このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら、新しいトークンを取得できます。

## <a name="request"></a>要求

### <a name="request-syntax"></a>要求の構文

| メソッド | 要求 URI                                                      |
|--------|------------------------------------------------------------------|
| GET    | ```https://manage.devcenter.microsoft.com/v1.0/my/analytics/reviews``` |


### <a name="request-header"></a>要求ヘッダー

| ヘッダー        | 型   | 説明                                                                 |
|---------------|--------|---------------------|
| Authorization | string | 必須。 **Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。 |


### <a name="request-parameters"></a>要求パラメーター

| パラメーター        | 型   |  説明      |  必須かどうか  
|---------------|--------|---------------|------|
| applicationId | string | レビュー データを取得するアプリの [Store ID](in-app-purchases-and-trials.md#store-ids) です。  |  必須  |
| startDate | date | 取得するレビュー データの日付範囲の開始日です。 既定値は現在の日付です。 |  必須ではない  |
| endDate | date | 取得するレビュー データの日付範囲の終了日です。 既定値は現在の日付です。 |  必須ではない  |
| top | int | 要求で返すデータの行数です。 指定されない場合の既定値は、最大値でもある 10000 です。 クエリにこれを上回る行がある場合は、応答本文に次リンクが含まれ、そのリンクを使ってデータの次のページを要求できます。 |  必須ではない  |
| skip | int | クエリでスキップする行数です。 大きなデータ セットを操作するには、このパラメーターを使用します。 たとえば、top=10000 と skip=0 を指定すると、データの最初の 10,000 行が取得され、top=10000 と skip=10000 を指定すると、データの次の 10,000 行が取得されます。 |  必須ではない  |
| filter |string  | 応答内の行をフィルター処理する 1 つまたは複数のステートメントです。 詳しくは、次の「[フィルター フィールド](#filter-fields)」セクションをご覧ください。 | 必須ではない   |
| orderby | string | 結果データ値の順序を指定するステートメントです。 構文は <em>orderby=field [order],field [order],...</em> です。<em>field</em> パラメーターは次のいずれかの文字列になります。<ul><li><strong>date</strong></li><li><strong>osVersion</strong></li><li><strong>market</strong></li><li><strong>deviceType</strong></li><li><strong>isRevised</strong></li><li><strong>packageVersion</strong></li><li><strong>deviceModel</strong></li><li><strong>productFamily</strong></li><li><strong>deviceScreenResolution</strong></li><li><strong>isTouchEnabled</strong></li><li><strong>reviewerName</strong></li><li><strong>reviewTitle</strong></li><li><strong>reviewText</strong></li><li><strong>helpfulCount</strong></li><li><strong>notHelpfulCount</strong></li><li><strong>responseDate</strong></li><li><strong>responseText</strong></li><li><strong>deviceRAM</strong></li><li><strong>deviceStorageCapacity</strong></li><li><strong>rating</strong></li></ul><p><em>order</em> パラメーターは省略可能であり、<strong>asc</strong> または <strong>desc</strong> を指定して、各フィールドを昇順または降順にすることができます。 既定値は <strong>asc</strong> です。</p><p><em>orderby</em> 文字列の例: <em>orderby=date,market</em></p> |  必須ではない  |


### <a name="filter-fields"></a>フィルター フィールド

要求の *filter* パラメーターには、応答内の行をフィルター処理する 1 つまたは複数のステートメントが含まれます。 各ステートメントには **eq** または **ne** 演算子と関連付けられるフィールドと値が含まれ、一部のフィールドでは **contains**、**gt**、**lt**、**ge**、および **le** 演算子もサポートします。 **and** または **or** を使ってステートメントを組み合わせることができます。

*filter* 文字列の例は次のとおりです。*filter=contains(reviewText,'great') and contains(reviewText,'ads') and deviceRAM lt 2048 and market eq 'US'*

サポートされているフィールドと各フィールドでサポートされている演算子の一覧については、次の表をご覧ください。 *filter* パラメーターでは、文字列値を単一引用符で囲む必要があります。

| フィールド        | サポートされている演算子   |  説明        |
|---------------|--------|-----------------|
| market | eq、ne | デバイス市場の ISO 3166 国コードを含む文字列です。 |
| osVersion  | eq、ne  | 次のいずれかの文字列です。<ul><li><strong>Windows Phone 7.5</strong></li><li><strong>Windows Phone 8</strong></li><li><strong>Windows Phone 8.1</strong></li><li><strong>Windows Phone 10</strong></li><li><strong>Windows 8</strong></li><li><strong>Windows 8.1</strong></li><li><strong>Windows 10</strong></li><li><strong>Unknown</strong></li></ul>  |
| deviceType  | eq、ne  | 次のいずれかの文字列です。<ul><li><strong>PC</strong></li><li><strong>Phone</strong></li><li><strong>Console</strong></li><li><strong>IoT</strong></li><li><strong>Holographic</strong></li><li><strong>Unknown</strong></li></ul>  |
| isRevised  | eq、ne  | 更新されているレビューをフィルター処理するには <strong>true</strong> を指定します。それ以外の場合は <strong>false</strong> を指定します。  |
| packageVersion  | eq、ne  | レビューされたアプリ パッケージのバージョンです。  |
| deviceModel  | eq、ne  | アプリがレビューされたデバイスの種類です。  |
| productFamily  | eq、ne  | 次のいずれかの文字列です。<ul><li><strong>PC</strong></li><li><strong>Tablet</strong></li><li><strong>Phone</strong></li><li><strong>Wearable</strong></li><li><strong>Server</strong></li><li><strong>Collaborative</strong></li><li><strong>Other</strong></li></ul>  |
| deviceRAM  | eq、ne、gt、lt、ge、le  | 物理 RAM (MB 単位) です。  |
| deviceScreenResolution  | eq、ne  | &quot;<em>幅</em> x <em>高さ</em>&quot; 形式のデバイスの画面解像度です。   |
| deviceStorageCapacity  | eq、ne、gt、lt、ge、le   | 主記憶域ディスクの容量 (GB 単位) です。  |
| isTouchEnabled  | eq、ne  | タッチ対応デバイスをフィルター処理するには <strong>true</strong> を指定します。それ以外の場合は <strong>false</strong> を指定します。   |
| reviewerName  | eq、ne  |  レビュー担当者名です。 |
| rating  | eq、ne、gt、lt、ge、le  | 星で表現したアプリの評価です。  |
| reviewTitle  | eq、ne、contains  | レビューのタイトルです。  |
| reviewText  | eq、ne、contains  |  レビューのテキスト コンテンツです。 |
| helpfulCount  | eq、ne  |  レビューが役に立つとマークされた回数です。 |
| notHelpfulCount  | eq、ne  | レビューが役に立たないとマークされた回数です。  |
| responseDate  | eq、ne  | 応答が送信された日付です。  |
| responseText  | eq、ne、contains  | 応答のテキスト コンテンツです。  |
| id  | eq、ne  | レビューの ID です (これは GUID です)。        |


### <a name="request-example"></a>要求の例

レビュー データを取得するためのいくつかの要求の例を次に示します。 *applicationId* 値を、目的のアプリのストア ID に置き換えてください。

```syntax
GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/reviews?applicationId=9NBLGGGZ5QDR&startDate=1/1/2015&endDate=2/1/2015&top=10&skip=0 HTTP/1.1
Authorization: Bearer <your access token>

GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/reviews?applicationId=9NBLGGGZ5QDR&startDate=8/1/2015&endDate=8/31/2015&skip=0&filter=contains(reviewText,'great') and contains(reviewText,'ads') and deviceRAM lt 2048 and market eq 'US' HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a>応答


### <a name="response-body"></a>応答本文

| 値      | 型   | 説明      |
|------------|--------|------------------|
| Value      | array  | レビュー データを含むオブジェクトの配列です。 各オブジェクトのデータについて詳しくは、次の「[レビュー値](#review-values)」セクションをご覧ください。       |
| @nextLink  | string | データの追加ページがある場合、この文字列には、データの次のページを要求するために使用できる URI が含まれます。 たとえば、要求の **top** パラメーターを 10000 に設定した場合、クエリに適合するレビュー データが 10,000 行を超えると、この値が返されます。 |
| TotalCount | int    | クエリの結果データ内の行の総数です。  |

 
### <a name="review-values"></a>レビュー値

*Value* 配列の要素には、次の値が含まれます。

| 値           | 型    | 説明       |
|-----------------|---------|-------------------|
| date            | string  | レビュー データの日付範囲の最初の日付です。 要求に日付を指定した場合、この値はその日付になります。 要求に週、月、またはその他の日付範囲を指定した場合、この値はその日付範囲の最初の日付になります。 |
| applicationId   | string  | レビュー データを取得するアプリのストア ID です。         |
| applicationName | string  | アプリの表示名です。    |
| market          | string  | レビューが送信された市場の ISO 3166 国コードです。        |
| osVersion       | string  | レビューが送信された OS バージョンです。 サポートされる文字列の一覧については、上記の「[フィルター フィールド](#filter-fields)」セクションをご覧ください。            |
| deviceType      | string  | レビューが送信されたデバイスの種類です。 サポートされる文字列の一覧については、上記の「[フィルター フィールド](#filter-fields)」セクションをご覧ください。            |
| isRevised       | Boolean | 値 **true** は、レビューが更新済みであることを示します。それ以外の場合は **false** です。   |
| packageVersion  | string  | レビューされたアプリ パッケージのバージョンです。        |
| deviceModel        | string  |アプリがレビューされたデバイスの種類です。     |
| productFamily      | string  | デバイス ファミリの名前です。 サポートされる文字列の一覧については、上記の「[フィルター フィールド](#filter-fields)」セクションをご覧ください。   |
| deviceRAM       | number  | 物理 RAM (MB 単位) です。    |
| deviceScreenResolution       | string  | "*幅* x *高さ*" 形式のデバイスの画面解像度です。    |
| deviceStorageCapacity | number | 主記憶域ディスクの容量 (GB 単位) です。 |
| isTouchEnabled | Boolean | 値 **true** は、タッチ対応であることを示します。それ以外の場合は **false** です。 |
| reviewerName | string | レビュー担当者名です。 |
| rating | number | 星で表現したアプリの評価です。 |
| reviewTitle | string | レビューのタイトルです。 |
| reviewText | string | レビューのテキスト コンテンツです。 |
| helpfulCount | number | レビューが役に立つとマークされた回数です。 |
| notHelpfulCount | number | レビューが役に立たないとマークされた回数です。 |
| responseDate | string | 応答が送信された日付です。 |
| responseText | string | 応答のテキスト コンテンツです。 |
| id | string | レビューの ID です (これは GUID です)。 この ID は、[アプリのレビューへの返信情報の取得](get-response-info-for-app-reviews.md)と[アプリ レビューへの返信の提出](submit-responses-to-app-reviews.md)メソッドで使用できます。 |


### <a name="response-example"></a>応答の例

この要求の JSON 応答の本文の例を次に示します。

```json
{
  "Value": [
    {
      "date": "2015-07-29",
      "applicationId": "9NBLGGGZ5QDR",
      "applicationName": "Contoso demo",
      "market": "US",
      "osVersion": "10.0.10240.16410",
      "deviceType": "PC",
      "isRevised": true,
      "packageVersion": "",
      "deviceModel": "Microsoft Corporation-Virtual Machine",
      "productFamily": "PC",
      "deviceRAM": -1,
      "deviceScreenResolution": "1024 x 768",
      "deviceStorageCapacity": 51200,
      "isTouchEnabled": false,
      "reviewerName": "ALeksandra",
      "rating": 5,
      "reviewTitle": "Love it",
      "reviewText": "Great app for demos and great dev response.",
      "helpfulCount": 0,
      "notHelpfulCount": 0,
      "responseDate": "2015-08-07T01:50:22.9874488Z",
      "responseText": "1",
      "id": "6be543ff-1c9c-4534-aced-af8b4fbe0316"
    }
  ],
  "@nextLink": null,
  "TotalCount": 1
}
```

## <a name="related-topics"></a>関連トピック

* [[レビュー] レポート](../publish/reviews-report.md)
* [Microsoft Store サービスを使った分析データへのアクセス](access-analytics-data-using-windows-store-services.md)
* [アプリのレビューへの返信情報の取得](get-response-info-for-app-reviews.md)
* [アプリのレビューへの返信の提出](submit-responses-to-app-reviews.md)
* [アプリの入手数の取得](get-app-acquisitions.md)
* [アドオンの入手数の取得](get-in-app-acquisitions.md)
* [エラー報告データの取得](get-error-reporting-data.md)
* [アプリの評価の取得](get-app-ratings.md)
