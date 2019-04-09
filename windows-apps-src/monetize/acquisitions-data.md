---
description: Microsoft Store analytics API でこのメソッドを使用して、JSON 形式で UWP アプリ、Xbox One のゲームを Xbox 開発者ポータル (XDP) を取り込んだと XDP Analytics ダッシュ ボードで使用できる集計の取得データを取得します。
title: ゲームとアプリの買収データを取得します。
ms.date: 03/06/2019
ms.topic: article
keywords: Windows 10、UWP、広告ネットワーク、アプリのメタデータ
ms.localizationpriority: medium
ms.openlocfilehash: beca5620f25713e8a07e5dbaf64e955d920702a7
ms.sourcegitcommit: df8e4143e81a1c5fe1aa5f14407b8dd5f155a12e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/14/2019
ms.locfileid: "57829915"
---
# <a name="get-acquisitions-data-for-your-games-and-apps"></a>ゲームとアプリの買収データを取得します。 
Microsoft Store analytics API でこのメソッドを使用して、JSON 形式で UWP アプリ、Xbox One のゲームを Xbox 開発者ポータル (XDP) を取り込んだと XDP Analytics ダッシュ ボードで使用できる集計の取得データを取得します。 

> [!NOTE]
> この API では、10 月 1 日 2016年より前に日単位の集計データは提供されません。 

## <a name="prerequisites"></a>前提条件
このメソッドを使うには、最初に次の作業を行う必要があります。 

* Microsoft Store 分析 API に関するすべての[前提条件](access-analytics-data-using-windows-store-services.md)を満たします (前提条件がまだ満たされていない場合)。 
* このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](access-analytics-data-using-windows-store-services.md)します。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら新しいトークンを取得できます。 

## <a name="request"></a>要求
### <a name="request-syntax"></a>要求の構文

| メソッド | 要求 URI |
| --- | --- |
| GET | `https://manage.devcenter.microsoft.com/v1.0/my/analytics/acquisitions` |

### <a name="request-header"></a>要求ヘッダー

| Header | 種類 | 説明 |
| --- | --- | --- |
| Authorization | string | 必須。 フォームの Azure AD アクセス トークン**ベアラー** `<token>`します。 |

### <a name="request-parameters"></a>要求パラメーター

| パラメーター | 種類 | 説明 | 必須 |
| --- | --- | --- | --- |
| applicationId | string | 入手データを取得する Xbox One ゲームの製品 ID です。 ゲームの製品 ID を取得するには、XDP 分析プログラムでゲームに移動し、URL から、製品 ID を取得します。 または、パートナー センターの分析レポートから買収データをダウンロードする場合は、.tsv ファイルで製品 ID が含まれます。  | 〇 |
| startDate | date | 取得する入手データの日付範囲の開始日です。 既定値は現在の日付です。  | X |
| endDate | date | 取得する入手データの日付範囲終了日です。 既定値は現在の日付です。  | X |
| top | 整数 | 返すデータの行数です。 最大値および指定しない場合の既定値は 10000 です。 クエリにこれを上回る行がある場合は、応答本文に次リンクが含まれ、そのリンクを使ってデータの次のページを要求できます。  | X |
| skip | 整数 | クエリでスキップする行数です。 大きなデータ セットを操作するには、このパラメーターを使用します。 たとえば、*上部 = 10000 とスキップ = 0* 10000 最初の行のデータを取得します*上部 = 10000 とスキップ = 10000*データの次に 10000 行を取得します。  | X |
| filter | string | 応答内の行をフィルター処理する 1 つまたは複数のステートメントです。 各ステートメントには、応答本文からのフィールド名、および **eq** 演算子または **ne** 演算子と関連付けられる値が含まれており、**and** や **or** を使用してステートメントを組み合わせることができます。 文字列の値は、フィルター パラメーターで単一引用符で囲む必要があります。 たとえば、「*filter=market eq 'US' and gender eq 'm'*」のように指定します。  <br/> 応答本文から次のフィールドを指定することができます。 <ul><li>**acquisitionType**</li><li>**経過時間**</li><li>**storeClient**</li><li>**性別**</li><li>**market**</li><li>**osVersion**</li><li>**deviceType**</li><li>**sandboxId**</li></ul> | X |
| aggregationLevel | string | 集計データを取得する時間範囲を指定します。 次のいずれかの文字列を指定できます。**day**、**week**、または **month**。 指定しない場合、既定値は **day** です。  | いいえ |
| orderby | string | それぞれの入手数について結果データ値の順序を指定するステートメントです。 構文は*orderby フィールド [order]、[順序] フィールドを = しています.**field* パラメーターには、次のいずれかの文字列を指定できます。 <ul><li>**date**</li><li>**acquisitionType**</li><li>**経過時間**</li><li>**storeClient**</li><li>**性別**</li><li>**market**</li><li>**osVersion**</li><li>**deviceType**</li><li>**paymentInstrumentType**</li><li>**sandboxId**</li><li>**xboxTitleIdHex**</li></ul> *order* パラメーターは省略可能であり、**asc** または **desc** を指定して、各フィールドを昇順または降順にすることができます。 既定値は **asc** です。 *orderby* 文字列の例: *orderby=date,market*  | X |
| groupby | string | 指定したフィールドのみにデータ集計を適用するステートメントです。 次のフィールドを指定できます。 <ul><li>**date**</li><li>**applicationName**</li><li>**acquisitionType**</li><li>**ageGroup**</li><li>**storeClient**</li><li>**性別**</li><li>**market**</li><li>**osVersion**</li><li>**deviceType**</li><li>**paymentInstrumentType**</li><li>**sandboxId**</li><li>**xboxTitleIdHex**</li></ul> 返されるデータ行には、*groupby* パラメーターに指定したフィールドと次の値が含まれます。 <ul><li>**date**</li><li>**applicationId**</li><li>**acquisitionQuantity**</li></ul> *Groupby* aggregationLevel パラメーターでパラメーターを使用できます。 例: *& groupby = ageGroup、市場 aggregationLevel = 週*  | X |

### <a name="request-example"></a>要求の例
Xbox One ゲームの入手データを取得するための要求の例を、いくつか次に示します。 置換、 *applicationId*ゲームの製品 ID を持つ値。  

```syntax
GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/acquisitions?applicationId=9WZDNCRFHXHT&startDate=1/1/2017&endDate=2/1/2019&top=10&skip=0 HTTP/1.1 
Authorization: Bearer <your access token> 

GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/acquisitions?applicationId=9WZDNCRFHXHT&startDate=1/1/2017&endDate=2/1/2019&skip=0&filter=market eq 'US' and gender eq 'm' HTTP/1.1 
Authorization: Bearer <your access token> 
```

## <a name="response"></a>応答

### <a name="response-body"></a>応答本文
| Value | 種類 | 説明 |
| --- | --- | --- |
| Value | array | ゲームに関する集計入手データを含むオブジェクトの配列です。 各オブジェクト内のデータについて詳しくは、後の「[入手値](#acquisition-values)」セクションをご覧ください。 |
| @nextLink | string | データの追加ページがある場合、この文字列には、データの次のページを要求するために使用できる URI が含まれます。 たとえば、要求の **top** パラメーターが 10000 に設定されたが、クエリの入手データに 10,000 を超える行が含まれている場合に、この値が返されます。 |
| TotalCount | 整数 | クエリの結果データ内の行の総数です。 |

### <a name="acquisition-values"></a>入手値 
*Value* 配列の要素には、次の値が含まれます。 

| Value | 種類 | 説明 |
| --- | --- | --- |
| date | string | 入手データの日付範囲の最初の日付です。 要求に日付を指定した場合、この値はその日付になります。 要求に週、月、またはその他の日付範囲を指定した場合、この値はその日付範囲の最初の日付になります。 |
| applicationId | string | 入手データを取得する Xbox One ゲームの製品 ID です。 |
| applicationName | string | ゲームの表示名です。 |
| acquisitionType | string | 入手の種類を示す、以下のいずれかの文字列です。  <ul><li>**無料**</li><li>**試用版**</li><li>**有料**</li><li>**プロモーション コード**</li><li>**Iap**</li><li>**サブスクリプション Iap**</li><li>**プライベートの対象ユーザー**</li><li>**前の順序**</li><li>**Xbox Game Pass** (または、2018 年 3 月 23 日より前のデータを照会した場合は **Game Pass**)</li><li>**Disk**</li><li>**前払いコード**</li><li>**課金の事前注文**</li><li>**前の取り消された順序**</li><li>**障害が発生した以前の注文**</li></ul> |
| age | string | 入手したユーザーの年齢グループを示す、以下のいずれかの文字列です。 <ul><li>**小さい 13**</li><li>**13-17**</li><li>**18-24**</li><li>**25-34**</li><li>**35-44**</li><li>**44-55**</li><li>**55 より大きい**</li><li>**Unknown**</li></ul> |
| deviceType | string | 入手が完了したデバイスの種類を指定する、以下のいずれかの文字列です。 <ul><li>**PC**</li><li>**Phone**</li><li>**Console**</li><li>**IoT**</li><li>**[サーバー]**</li><li>**タブレット**</li><li>**Holographic**</li><li>**Unknown**</li></ul> |
| gender | string | 入手したユーザーの性別を指定する、以下のいずれかの文字列です。 <ul><li>**m**</li><li>**f**</li><li>**Unknown**</li></ul> |
| market | string | 入手が発生した市場の ISO 3166 国コードです。 |
| osVersion | string | 入手が発生した OS のバージョンです。 このメソッドでは、この値は常に **Windows 10** になります。 |
| paymentInstrumentType | string | 入手に使われた支払い方法を示す、以下のいずれかの文字列です。 <ul><li>**クレジット_カード**</li><li>**直接デビット カード**</li><li>**推論による発注**</li><li>**MS 分散**</li><li>**通信事業者**</li><li>**オンライン銀行振込**</li><li>**PayPal**</li><li>**分割されたトランザクション**</li><li>**トークンの引き換え**</li><li>**0 個の支払額**</li><li>**eWallet**</li><li>**Unknown**</li></ul> |
| sandboxId | string | ゲーム用に作成されたサンドボックス ID です。 値を指定できます**小売**またはプライベートのサンド ボックス id。 |
| storeClient | string | 入手が発生した Store のバージョンを示す、以下のいずれかの文字列です。 <ul><li>**Windows Phone ストア (クライアント)**</li><li>**Microsoft Store (client)** (または、2018 年 3 月 23 日より前のデータを照会した場合は **Windows Store (client)**) </li><li>**Microsoft Store (web)** (または、2018 年 3 月 23 日より前のデータを照会した場合は **Windows Store (web)**) </li><li>**組織でボリューム購入**</li><li>**その他**</li></ul> |
| xboxTitleId | string | Xbox デベロッパー ポータル (XDP) によって Xbox Live 対応ゲームに割り当てられた Xbox Live タイトル ID (16 進数表記) です。 |
| acquisitionQuantity | number | 指定された集計レベルで発生した入手の数です。 |
| purchasePriceUSDAmount | number | 入手時にユーザーが支払った金額を、月ごとの為替レートを使って米国ドルに換算した値です。 |
| purchaseTaxUSDAmount | number | 入手時に適用された税額を米国ドルに換算した値です。 |
| localCurrencyCode | string | パートナー センター アカウントの国に基づくローカルの通貨コード。  |
| xboxProductId | string | 該当する場合、XDP から製品の Xbox 製品 ID です。  |
| availabilityId | string | 該当する場合、XDP から製品の可用性の ID。  |
| skuId | string | 該当する場合、XDP から製品の SKU ID です。  |
| skuDisplayName  | string | SKU は、該当する場合に、XDP から製品の名前を表示します。  |
| xboxParentProductId | string | 該当する場合、XDP から製品の Xbox 親プロダクト ID。  |
| parentProductName | string | 該当する場合、XDP から製品の親製品名。  |
| productTypeName | string | 該当する場合、XDP から製品の製品の種類名。  |
| purchaseTaxType | string | 該当する場合は、XDP から税の種類の製品を購入します。  |
| purchasePriceLocalAmount | number | 該当する場合は、XDP から、製品の価格のローカル容量を購入します。  |
| purchaseTaxLocalAmount | number | 該当する場合は、XDP からローカルに税額製品を購入します。  |

### <a name="response-example"></a>応答の例
この要求の JSON 返信の本文の例を次に示します。 

```JSON
{ 
    "Value": [ 
        { 
            "date": "2019-01-15T01:00:00.0000000Z", 
            "applicationId": "9WZDNCRFHXHT", 
            "applicationName": null, 
            "acquisitionType": "Paid", 
            "age": null, 
            "deviceType": "Phone", 
            "gender": null, 
            "market": "US", 
            "osVersion": "Windows 10", 
            "paymentInstrumentType": null, 
            "sandboxId": "RETAIL", 
            "storeClient": "Microsoft Store (client)", 
            "xboxTitleId": null, 
            "localCurrencyCode": "USD", 
            "xboxProductId": null, 
            "availabilityId": "B42LRTSZ2MCJ", 
            "skuId": "0010", 
            "skuDisplayName": null, 
            "xboxParentProductId": null, 
            "parentProductName": null, 
            "productTypeName": "Game", 
            "purchaseTaxType": "TaxesNotIncluded", 
            "acquisitionQuantity": 1, 
            "purchasePriceUSDAmount": 3.08, 
            "purchasePriceLocalAmount": 3.08, 
            "purchaseTaxUSDAmount": 0.09, 
            "purchaseTaxLocalAmount": 0.09 
        } 
    ], 

    "@nextLink": "acquisitions?applicationId=9WZDNCRFHXHT&aggregationLevel=day&startDate=2017-01-01T08:00:00.0000000Z&endDate=2019-01-16T08:44:15.6045249Z&top=1&skip=1", 
    
    "TotalCount": 12221 
} 
```

 
