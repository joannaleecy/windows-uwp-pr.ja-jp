---
description: Microsoft Store analytics API でこのメソッドを使用すると、集計のアドオン購入データを取得できます。
title: Xbox One アドオンの入手数の取得
ms.date: 10/18/2018
ms.topic: article
keywords: windows 10、uwp、Store services、Microsoft Store analytics API、Xbox One のアドオンの取得
ms.localizationpriority: medium
ms.openlocfilehash: f102d2d692a2307c25dcb95e66d612fc561dec70
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57633297"
---
# <a name="get-xbox-one-add-on-acquisitions"></a>Xbox One アドオンの入手数の取得

このメソッドを使用して、Microsoft Store analytics API 集計のアドオン購入データを取得する JSON 形式で、Xbox One ゲーム Xbox 開発者ポータル (XDP) を取り込んだして XDP Analytics パートナー センター ダッシュ ボードに表示します。

## <a name="prerequisites"></a>前提条件

このメソッドを使うには、最初に次の作業を行う必要があります。

* Microsoft Store 分析 API に関するすべての[前提条件](access-analytics-data-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。
* このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら新しいトークンを取得できます。

## <a name="request"></a>要求


### <a name="request-syntax"></a>要求の構文

| メソッド | 要求 URI                                                                |
|--------|----------------------------------------------------------------------------|
| GET    | ```https://manage.devcenter.microsoft.com/v1.0/my/analytics/xbox/addonacquisitions``` |


### <a name="request-header"></a>要求ヘッダー

| Header        | 種類   | 説明          |
|---------------|--------|--------------|
| Authorization | string | 必須。 **Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。 |


### <a name="request-parameters"></a>要求パラメーター

*ApplicationId*または*addonProductId*パラメーターが必要です。 アプリに登録されたすべてのアドオンの入手データを取得するには、*applicationId* パラメーターを指定します。 1 つのアドオンの購入データを取得する指定、 *addonProductId*パラメーター。 両方を指定した場合、*applicationId* パラメーターは無視されます。

| パラメーター        | 種類   |  説明      |  必須  |
|---------------|--------|---------------|------|
| applicationId | string | *ProductId*取得データを取得する Xbox One のゲームの。 取得する、 *productId* XDP 分析プログラムでゲームに移動し、ゲームの取得、 *productId* URL から。 また、パートナー センターの analytics レポートから買収データをダウンロードする場合は、 *productId* .tsv ファイルに挿入されます。 |  〇  |
| addonProductId | string | *ProductId*取得データを取得するアドオンの。  | 〇  |
| startDate | date | 取得するアドオン入手データの日付範囲の開始日です。 既定値は現在の日付です。 |  X  |
| endDate | date | 取得するアドオン入手データの日付範囲終了日です。 既定値は現在の日付です。 |  X  |
| top | int | 要求で返すデータの行数です。 最大値および指定しない場合の既定値は 10000 です。 クエリにこれを上回る行がある場合は、応答本文に次リンクが含まれ、そのリンクを使ってデータの次のページを要求できます。 |  X  |
| skip | int | クエリでスキップする行数です。 大きなデータ セットを操作するには、このパラメーターを使用します。 たとえば、top=10000 と skip=0 を指定すると、データの最初の 10,000 行が取得され、top=10000 と skip=10000 を指定すると、データの次の 10,000 行が取得されます。 |  X  |
| filter |string  | <p>応答内の行をフィルター処理する 1 つまたは複数のステートメントです。 各ステートメントには、応答本文と、eq、ne または演算子に関連付けられている値からフィールド名が含まれていますとを使用してステートメントを組み合わせることができますとまたはまたはします。 文字列の値は、フィルター パラメーターで単一引用符で囲む必要があります。 たとえば、フィルター処理 = 市場 eq '米国'] と [性別の eq います '。</p> <p>応答本文から次のフィールドを指定することができます。</p> <ul><li><strong>acquisitionType</strong></li><li><strong>経過時間</strong></li><li><strong>storeClient</strong></li><li><strong>性別</strong></li><li><strong>market</strong></li><li><strong>osVersion</strong></li><li><strong>deviceType</strong></li><li><strong>sandboxId</strong></li></ul>| X   |
| aggregationLevel | string | 集計データを取得する時間範囲を指定します。 次のいずれかの文字列を指定できます。<strong>day</strong>、<strong>week</strong>、または <strong>month</strong>。 指定しない場合、既定値は <strong>day</strong> です。 | X |
| orderby | string | それぞれのアドオン入手数について結果データ値の順序を指定するステートメントです。 構文は<em>orderby フィールド [order]、[順序] フィールドを = しています.</em><em>field</em> パラメーターには、次のいずれかの文字列を指定できます。<ul><li><strong>date</strong></li><li><strong>acquisitionType</strong></li><li><strong>経過時間</strong></li><li><strong>storeClient</strong></li><li><strong>性別</strong></li><li><strong>market</strong></li><li><strong>osVersion</strong></li><li><strong>deviceType</strong></li><li><strong>orderName</strong></li></ul><p><em>order</em> パラメーターは省略可能であり、<strong>asc</strong> または <strong>desc</strong> を指定して、各フィールドを昇順または降順にすることができます。 既定値は <strong>asc</strong> です。</p><p><em>orderby</em> 文字列の例: <em>orderby=date,market</em></p> |  X  |
| groupby | string | 指定したフィールドのみにデータ集計を適用するステートメントです。 次のフィールドを指定できます。<ul><li><strong>date</strong></li><li><strong>applicationName</strong></li><li><strong>addonProductName</strong></li><li><strong>acquisitionType</strong></li><li><strong>経過時間</strong></li><li><strong>storeClient</strong></li><li><strong>性別</strong></li><li><strong>market</strong></li><li><strong>osVersion</strong></li><li><strong>deviceType</strong></li><li><strong>paymentInstrumentType</strong></li><li><strong>sandboxId</strong></li><li><strong>xboxTitleIdHex</strong></li></ul><p>返されるデータ行には、<em>groupby</em> パラメーターに指定したフィールドと次の値が含まれます。</p><ul><li><strong>date</strong></li><li><strong>applicationId</strong></li><li><strong>addonProductId</strong></li><li><strong>acquisitionQuantity</strong></li></ul><p><em>groupby</em> パラメーターは、<em>aggregationLevel</em> パラメーターと同時に使用できます。 例:  <em>&amp;groupby 年齢、市場を =&amp;aggregationLevel = 週</em></p> |  X  |


### <a name="request-example"></a>要求の例

アドオン入手データを取得するためのいくつかの要求の例を次に示します。 置換、 *addonProductId*と*applicationId*アドオンまたはアプリの適切な Store ID の値。

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

| Value      | 種類   | 説明         |
|------------|--------|------------------|
| Value      | array  | 集計アドオン入手データが含まれるオブジェクトの配列です。 各オブジェクトのデータについて詳しくは、次の「[アドオン入手値](#add-on-acquisition-values)」セクションをご覧ください。                                                                                                              |
| @nextLink  | string | データの追加ページがある場合、この文字列には、データの次のページを要求するために使用できる URI が含まれます。 たとえば、要求の **top** パラメーターが 10000 に設定されたが、クエリのアドオン入手データに 10,000 を超える行が含まれている場合に、この値が返されます。 |
| TotalCount | int    | クエリの結果データ内の行の総数です。    |


<span id="add-on-acquisition-values" />

### <a name="add-on-acquisition-values"></a>アドオン入手値

*Value* 配列の要素には、次の値が含まれます。

| Value               | 種類    | 説明        |
|---------------------|---------|---------------------|
| date                | string  | 入手データの日付範囲の最初の日付です。 要求に日付を指定した場合、この値はその日付になります。 要求に週、月、またはその他の日付範囲を指定した場合、この値はその日付範囲の最初の日付になります。 |
| addonProductId      | string  | *ProductId*取得データを取得するアドオンの。                                                                                                                                                                 |
| addonProductName    | string  | アドオンの表示名です。 この値のみが表示されます、応答データの場合、 *aggregationLevel*パラメーターに設定されて**日**指定しない限り、 **addonProductName**フィールド、に*groupby*パラメーター。                                                                                                                                                                                                            |
| applicationId       | string  | *ProductId*のアドオン購入データを取得するアプリです。                                                                                                                                                           |
| applicationName     | string  | ゲームの表示名です。                                                                                                                                                                                                             |
| deviceType          | string  | <p>入手が完了したデバイスの種類を指定する、以下のいずれかの文字列です。</p> <ul><li>"PC"</li><li>「電話」</li><li>「コンソール」</li><li>"IoT"</li><li>"Server"</li><li>"Tablet"</li><li>"Holographic"</li><li>「不明」</li></ul>                                                                                                  |
| storeClient         | string  | <p>入手が発生した Store のバージョンを示す、以下のいずれかの文字列です。</p> <ul><li>「Windows Phone ストア (クライアント)」</li><li>"Microsoft Store (クライアント)"(または「Windows ストア (クライアント)」、2018 年 3 月 23 日の前にデータのクエリを実行する場合)</li><li>"Microsoft Store (web)"(または"Windows Store (web)"の場合は、2018 年 3 月 23 日の前にデータの照会)</li><li>組織でボリューム購入"</li><li>「その他」</li></ul>                                                                                            |
| osVersion           | string  | 入手が発生した OS のバージョンです。 このメソッドは、この値は常に値が"Windows 10"です。                                                                                                   |
| market              | string  | 入手が発生した市場の ISO 3166 国コードです。                                                                                                                                                                  |
| gender              | string  | <p>入手したユーザーの性別を指定する、以下のいずれかの文字列です。</p> <ul><li>"m"</li><li>"f"</li><li>「不明」</li></ul>                                                                                                    |
| age            | string  | <p>入手したユーザーの年齢グループを示す、以下のいずれかの文字列です。</p> <ul><li>「より小さい 13」</li><li>"13-17"</li><li>"18-24"</li><li>"25-34"</li><li>"35-44"</li><li>"44-55"</li><li>「55 より大きい」</li><li>「不明」</li></ul>                                                                                                 |
| acquisitionType     | string  | <p>入手の種類を示す、以下のいずれかの文字列です。</p> <ul><li>「無料」</li><li>「試用版」</li><li>「有料」</li><li>「プロモーション コード」</li><li>"Iap"</li><li>"サブスクリプション Iap"</li><li>"プライベート Audience"</li><li>「より前の順序」</li><li>"Xbox Game Pass"(または「ゲーム パス」が、2018 年 3 月 23 日の前にデータの照会)</li><li>"Disk"</li><li>「プリペイド コード」</li><li>「以前の注文を課金」</li><li>「以前の注文をキャンセル」</li><li>「以前の注文に失敗しました」</li></ul>                                                                                                    |
| acquisitionQuantity | 整数 | 発生した入手の数です。                        |


### <a name="response-example"></a>応答の例

この要求の JSON 返信の本文の例を次に示します。

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
