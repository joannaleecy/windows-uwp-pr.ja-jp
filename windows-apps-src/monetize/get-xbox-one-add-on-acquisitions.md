---
author: Xansky
description: 集計アドオン入手データを取得するのに、Microsoft Store 分析 API の以下のメソッドを使用します。
title: Xbox One アドオンの入手数の取得
ms.author: mhopkins
ms.date: 10/18/2018
ms.topic: article
keywords: windows 10, uwp, Store サービス, Microsoft Store 分析 API, Xbox One のアドオンの入手数
ms.localizationpriority: medium
ms.openlocfilehash: e703c0c07e981ebf21ad3388ad178eabdd5c068d
ms.sourcegitcommit: 3257416aebb5a7b1515e107866806f8bd57845a8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/17/2018
ms.locfileid: "7158957"
---
# <a name="get-xbox-one-add-on-acquisitions"></a>Xbox One アドオンの入手数の取得

Microsoft Store 分析 API 集計アドオン入手データを取得する JSON 形式で、Xbox One ゲームを Xbox デベロッパー ポータル (XDP) を通じて取り込まれ、XDP 分析のパートナー センター ダッシュ ボードで利用するには、このメソッドを使います。

## <a name="prerequisites"></a>前提条件

このメソッドを使うには、最初に次の作業を行う必要があります。

* Microsoft Store 分析 API に関するすべての[前提条件](access-analytics-data-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。
* このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら、新しいトークンを取得できます。

## <a name="request"></a>要求


### <a name="request-syntax"></a>要求の構文

| メソッド | 要求 URI                                                                |
|--------|----------------------------------------------------------------------------|
| GET    | ```https://manage.devcenter.microsoft.com/v1.0/my/analytics/xbox/addonacquisitions``` |


### <a name="request-header"></a>要求ヘッダー

| ヘッダー        | 型   | 説明          |
|---------------|--------|--------------|
| Authorization | string | 必須。 **Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。 |


### <a name="request-parameters"></a>要求パラメーター

*ApplicationId*または*addonProductId*パラメーターが必要です。 アプリに登録されたすべてのアドオンの入手データを取得するには、*applicationId* パラメーターを指定します。 1 つのアドオンの入手データを取得するには、 *addonProductId*パラメーターを指定します。 両方を指定した場合、*applicationId* パラメーターは無視されます。

| パラメーター        | 型   |  説明      |  必須かどうか  |
|---------------|--------|---------------|------|
| applicationId | string | 入手データを取得する Xbox One ゲームの*productId*します。 ゲームの*productId*を取得するには、XDP 分析プログラムでゲームに移動し、URL から*productId*を取得します。 また、パートナー センターの分析レポートから入手データをダウンロードする場合*productId*は、.tsv ファイルに含まれています。 |  はい  |
| addonProductId | string | 入手データを取得するアドオンの*productId*します。  | 必須  |
| startDate | date | 取得するアドオン入手データの日付範囲の開始日です。 既定値は現在の日付です。 |  必須ではない  |
| endDate | date | 取得するアドオン入手データの日付範囲終了日です。 既定値は現在の日付です。 |  必須ではない  |
| top | int | 要求で返すデータの行数です。 指定されない場合の既定値は、最大値でもある 10000 です。 クエリにこれを上回る行がある場合は、応答本文に次リンクが含まれ、そのリンクを使ってデータの次のページを要求できます。 |  必須ではない  |
| skip | int | クエリでスキップする行数です。 大きなデータ セットを操作するには、このパラメーターを使用します。 たとえば、top=10000 と skip=0 を指定すると、データの最初の 10,000 行が取得され、top=10000 と skip=10000 を指定すると、データの次の 10,000 行が取得されます。 |  必須ではない  |
| filter |string  | <p>応答内の行をフィルター処理する 1 つまたは複数のステートメントです。 各ステートメントには、応答本文からのフィールド名、および eq 演算子または ne 演算子と関連付けられる値が含まれており、and や or を使用してステートメントを組み合わせることができます。 filter パラメーターでは、文字列値を単一引用符で囲む必要があります。 たとえば、「filter=market eq 'US' and gender eq 'm'」のように指定します。</p> <p>応答本文から次のフィールドを指定することができます。</p> <ul><li><strong>acquisitionType</strong></li><li><strong>age</strong></li><li><strong>storeClient</strong></li><li><strong>gender</strong></li><li><strong>market</strong></li><li><strong>osVersion</strong></li><li><strong>deviceType</strong></li><li><strong>sandboxId</strong></li></ul>| 必須ではない   |
| aggregationLevel | string | 集計データを取得する時間範囲を指定します。 次のいずれかの文字列を指定できます。<strong>day</strong>、<strong>week</strong>、または <strong>month</strong>。 指定されていない場合、既定値は <strong>day</strong> です。 | 必須ではない |
| orderby | string | それぞれのアドオン入手数について結果データ値の順序を指定するステートメントです。 構文は<em>orderby フィールド [order], [order], を… =</em><em>フィールド</em>のパラメーターには、次の文字列のいずれかを指定できます。<ul><li><strong>date</strong></li><li><strong>acquisitionType</strong></li><li><strong>age</strong></li><li><strong>storeClient</strong></li><li><strong>gender</strong></li><li><strong>market</strong></li><li><strong>osVersion</strong></li><li><strong>deviceType</strong></li><li><strong>orderName</strong></li></ul><p><em>order</em> パラメーターは省略可能であり、<strong>asc</strong> または <strong>desc</strong> を指定して、各フィールドを昇順または降順にすることができます。 既定値は <strong>asc</strong> です。</p><p><em>orderby</em> 文字列の例: <em>orderby=date,market</em></p> |  必須ではない  |
| groupby | string | 指定したフィールドのみにデータ集計を適用するステートメントです。 次のフィールドを指定できます。<ul><li><strong>date</strong></li><li><strong>applicationName</strong></li><li><strong>addonProductName</strong></li><li><strong>acquisitionType</strong></li><li><strong>age</strong></li><li><strong>storeClient</strong></li><li><strong>gender</strong></li><li><strong>market</strong></li><li><strong>osVersion</strong></li><li><strong>deviceType</strong></li><li><strong>paymentInstrumentType</strong></li><li><strong>sandboxId</strong></li><li><strong>xboxTitleIdHex</strong></li></ul><p>返されるデータ行には、<em>groupby</em> パラメーターに指定したフィールドと次の値が含まれます。</p><ul><li><strong>date</strong></li><li><strong>applicationId</strong></li><li><strong>addonProductId</strong></li><li><strong>acquisitionQuantity</strong></li></ul><p><em>groupby</em> パラメーターは、<em>aggregationLevel</em> パラメーターと同時に使用できます。 例: <em> &amp;groupby = 年齢、市場&amp;aggregationLevel = week</em></p> |  いいえ  |


### <a name="request-example"></a>要求の例

アドオン入手データを取得するためのいくつかの要求の例を次に示します。 *AddonProductId*と*applicationId*の値をアドオンまたはアプリの適切なストア ID に置き換えます。

```syntax
GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/xbox/addonacquisitions?addonProductId=BRRT4NJ9B3D2&startDate=1/1/2015&endDate=2/1/2015&top=10&skip=0 HTTP/1.1
Authorization: Bearer <your access token>

GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/xbox/addonacquisitions?applicationId=BRRT4NJ9B3D1&startDate=1/1/2015&endDate=2/1/2015&top=10&skip=0 HTTP/1.1
Authorization: Bearer <your access token>

GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/xbox/addonacquisitions?addonProductId=BRRT4NJ9B3D2&startDate=1/1/2015&endDate=7/3/2015&top=100&skip=0&filter=market ne 'US' and gender ne 'Unknown' and gender ne 'm' and market ne 'NO' and age ne '>55' HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a>応答


### <a name="response-body"></a>応答本文

| 値      | 型   | 説明         |
|------------|--------|------------------|
| Value      | array  | 集計アドオン入手データが含まれるオブジェクトの配列です。 各オブジェクトのデータについて詳しくは、次の「[アドオン入手値](#add-on-acquisition-values)」セクションをご覧ください。                                                                                                              |
| @nextLink  | string | データの追加ページがある場合、この文字列には、データの次のページを要求するために使用できる URI が含まれます。 たとえば、要求の **top** パラメーターが 10000 に設定されたが、クエリのアドオン入手データに 10,000 を超える行が含まれている場合に、この値が返されます。 |
| TotalCount | int    | クエリの結果データ内の行の総数です。    |


<span id="add-on-acquisition-values" />

### <a name="add-on-acquisition-values"></a>アドオン入手値

*Value* 配列の要素には、次の値が含まれます。

| 値               | 型    | 説明        |
|---------------------|---------|---------------------|
| date                | string  | 入手データの日付範囲の最初の日付です。 要求に日付を指定した場合、この値はその日付になります。 要求に週、月、またはその他の日付範囲を指定した場合、この値はその日付範囲の最初の日付になります。 |
| addonProductId      | string  | 入手データを取得するアドオンの*productId*します。                                                                                                                                                                 |
| addonProductName    | string  | アドオンの表示名です。 この値のみが表示されます応答データで*aggregationLevel*パラメーターは、1**日**に設定されている場合、 *groupby*パラメーターで**addonProductName**フィールドを指定しない限り。                                                                                                                                                                                                            |
| applicationId       | string  | アドオン入手データを取得するアプリの*productId*します。                                                                                                                                                           |
| applicationName     | string  | ゲームの表示名です。                                                                                                                                                                                                             |
| deviceType          | string  | <p>入手が完了したデバイスの種類を指定する、以下のいずれかの文字列です。</p> <ul><li>"PC"</li><li>「電話」</li><li>「コンソール」</li><li>"IoT"</li><li>「サーバー」</li><li>"Tablet"</li><li>"Holographic"</li><li>「不明」</li></ul>                                                                                                  |
| storeClient         | string  | <p>入手が発生した Store のバージョンを示す、以下のいずれかの文字列です。</p> <ul><li>"Windows Phone Store (client)"</li><li>"Microsoft Store (client)"(または"Windows Store (client)"2018 年 3 月 23日する前に、データの照会した場合)</li><li>"Microsoft Store (web)"(または"Windows Store (web)"2018 年 3 月 23日する前に、データの照会した場合)</li><li>"Volume purchase by organizations"</li><li>「その他の」</li></ul>                                                                                            |
| osVersion           | string  | 入手が発生した OS のバージョンです。 このメソッドは、この値は常に値が"Windows 10"です。                                                                                                   |
| market              | string  | 入手が発生した市場の ISO 3166 国コードです。                                                                                                                                                                  |
| gender              | string  | <p>入手したユーザーの性別を指定する、以下のいずれかの文字列です。</p> <ul><li>"m"</li><li>"f"</li><li>「不明」</li></ul>                                                                                                    |
| age            | string  | <p>入手したユーザーの年齢グループを示す、以下のいずれかの文字列です。</p> <ul><li>「未満 13」</li><li>「13 17」</li><li>「18 ~ 24」</li><li>「25 34」</li><li>「35 44」</li><li>「44-55」</li><li>「55 より大きい」</li><li>「不明」</li></ul>                                                                                                 |
| acquisitionType     | string  | <p>入手の種類を示す、以下のいずれかの文字列です。</p> <ul><li>「無料」</li><li>「試用版」</li><li>「有料」</li><li>「プロモーション コード」</li><li>"Iap"</li><li>"サブスクリプション Iap"</li><li>「プライベート対象ユーザー」</li><li>「事前順序」</li><li>"Xbox Game Pass"(または"Game Pass"2018 年 3 月 23日する前に、データの照会した場合)</li><li>「ディスク」</li><li>"Prepaid Code"</li><li>「より前の順序を請求」</li><li>「より前の順序がキャンセル」</li><li>「より前の順序が失敗しました」</li></ul>                                                                                                    |
| acquisitionQuantity | 整数 | 発生した入手の数です。                        |


### <a name="response-example"></a>応答の例

この要求の JSON 応答の本文の例を次に示します。

```json
{
  "Value": [
    {
      "date": "2018-10-18",
      "addonProductId": " BRRT4NJ9B3D2",
      "addonProductName": "Contoso add-on 7",
      "applicationId": "BRRT4NJ9B3D1",
      "applicationName": "Contoso Demo",
      "deviceType": "Console",
      "storeClient": "Windows Phone Store (client)",
      "osVersion": "Windows 10",
      "market": "GB",
      "gender": "m",
      "age": "50orover",
      "acquisitionType": "iap",
      "acquisitionQuantity": 1
    }
  ],
  "@nextLink": "addonacquisitions?applicationId=BRRT4NJ9B3D1&addonProductId=&aggregationLevel=day&startDate=2015/01/01&endDate=2016/02/01&top=1&skip=1",
  "TotalCount": 33677
}
```
