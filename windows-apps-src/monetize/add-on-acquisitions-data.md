---
description: Microsoft Store analytics API でこのメソッドを使用して、UWP アプリ、Xbox One のゲームを Xbox 開発者ポータル (XDP) を取り込んだと XDP Analytics パートナー センター ダッシュ ボードで使用できる JSON 形式で取得データの集計のアドオンを取得します。
title: アドオン買収データ、ゲームとアプリの取得します。
ms.date: 03/06/2019
ms.topic: article
keywords: Windows 10、UWP、広告ネットワーク、アプリのメタデータ
ms.localizationpriority: medium
ms.openlocfilehash: 518648d52c613a3dd5f1bca0d34a7f533b59733f
ms.sourcegitcommit: df8e4143e81a1c5fe1aa5f14407b8dd5f155a12e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/14/2019
ms.locfileid: "57829912"
---
# <a name="get-add-on-acquisitions-data-for-your-games-and-apps"></a>アドオン買収データ、ゲームとアプリの取得します。 
Microsoft Store analytics API でこのメソッドを使用して、UWP アプリ、Xbox One のゲームを Xbox 開発者ポータル (XDP) を取り込んだと XDP Analytics パートナー センター ダッシュ ボードで使用できる JSON 形式で取得データの集計のアドオンを取得します。 

## <a name="prerequisites"></a>前提条件
このメソッドを使うには、最初に次の作業を行う必要があります。 

* Microsoft Store 分析 API に関するすべての[前提条件](access-analytics-data-using-windows-store-services.md)を満たします (前提条件がまだ満たされていない場合)。 
* このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](access-analytics-data-using-windows-store-services.md)します。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら新しいトークンを取得できます。 

> [!NOTE]
> この API では、10 月 1 日 2016年より前に日単位の集計データは提供されません。 

## <a name="request"></a>要求

### <a name="request-syntax"></a>要求の構文
| メソッド | 要求 URI |
| --- | --- | 
| GET | `https://manage.devcenter.microsoft.com/v1.0/my/analytics/addonacquisitions` |

### <a name="request-header"></a>要求ヘッダー 
| Header | 種類 | 説明 | 
| --- | --- | --- |
| Authorization | string | 必須。 フォームの Azure AD アクセス トークン**ベアラー** `<token>`します。 |

### <a name="request-parameters"></a>要求パラメーター
*ApplicationId*または*addonProductId*パラメーターが必要です。 アプリに登録されたすべてのアドオンの入手データを取得するには、*applicationId* パラメーターを指定します。 1 つのアドオンの購入データを取得する指定、 *addonProductId*パラメーター。 両方を指定した場合、*applicationId* パラメーターは無視されます。 

| パラメーター | 種類 | 説明 | 必須 | 
| --- | --- | --- | --- |
| applicationId | string | *ProductId*取得データを取得する Xbox One のゲームの。 取得する、 *productId* XDP 分析プログラムでゲームに移動し、ゲームの取得、 *productId* URL から。 また、パートナー センターの analytics レポートから買収データをダウンロードする場合は、 *productId* .tsv ファイルに挿入されます。 | 〇 |
| addonProductId | string | *ProductId*取得データを取得するアドオンの。 | 〇 |
| startDate | date | 取得するアドオン入手データの日付範囲の開始日です。 既定値は現在の日付です。 | X |
| endDate | date | 取得するアドオン入手データの日付範囲終了日です。 既定値は現在の日付です。 | X |
| top | int | 要求で返すデータの行数です。 最大値および指定しない場合の既定値は 10000 です。 クエリにこれを上回る行がある場合は、応答本文に次リンクが含まれ、そのリンクを使ってデータの次のページを要求できます。 | X |
| skip | int | クエリでスキップする行数です。 大きなデータ セットを操作するには、このパラメーターを使用します。 たとえば、top=10000 と skip=0 を指定すると、データの最初の 10,000 行が取得され、top=10000 と skip=10000 を指定すると、データの次の 10,000 行が取得されます。 | X |
| filter | string | 応答内の行をフィルター処理する 1 つまたは複数のステートメントです。 各ステートメントには、応答本文と、eq、ne または演算子に関連付けられている値からフィールド名が含まれていますとを使用してステートメントを組み合わせることができますとまたはまたはします。 文字列の値は、フィルター パラメーターで単一引用符で囲む必要があります。 たとえば、フィルター処理 = 市場 eq '米国'] と [性別の eq います '。 <br/> 応答本文から次のフィールドを指定することができます。 <ul><li>**acquisitionType**</li><li>**経過時間**</li><li>**storeClient**</li><li>**性別**</li><li>**market**</li><li>**osVersion**</li><li>**deviceType**</li><li>**sandboxId**</li></ul> | X |
| aggregationLevel | string | 集計データを取得する時間範囲を指定します。 次のいずれかの文字列を指定できます。**day**、**week**、または **month**。 指定しない場合、既定値は **day** です。 | X |
| orderby | string | それぞれのアドオン入手数について結果データ値の順序を指定するステートメントです。 構文は*orderby フィールド [order]、[順序] フィールドを = しています.**field* パラメーターには、次のいずれかの文字列を指定できます。 <ul><li>**date**</li><li>**acquisitionType**</li><li>**経過時間**</li><li>**storeClient**</li><li>**性別**</li><li>**market**</li><li>**osVersion**</li><li>**deviceType**</li><li>**orderName**</li></ul> 順序パラメーターは省略可能で、できる**asc**または**desc**を昇順または降順の各フィールドの順序を指定します。 既定値は **asc** です。 <br/> *orderby* 文字列の例: *orderby=date,market* | X |
| groupby | string | 指定したフィールドのみにデータ集計を適用するステートメントです。 次のフィールドを指定できます。 <ul><li>**date**</li><li>**applicationName**</li><li>**addonProductName**</li> <li>**acquisitionType**</li><li>**経過時間**</li> <li>**storeClient**</li><li>**性別**</li> <li>**market**</li> <li>**osVersion**</li><li>**deviceType**</li><li>**paymentInstrumentType**</li><li>**sandboxId**</li><li>**xboxTitleIdHex**</li></ul> 返されるデータ行には、*groupby* パラメーターに指定したフィールドと次の値が含まれます。 <ul><li>**date**</li><li>**applicationId**</li><li>**addonProductId**</li><li>**acquisitionQuantity**</li></ul> Groupby パラメーターで使用できる、 *aggregationLevel*パラメーター。 例: *& groupby = 年齢、市場 aggregationLevel = 週* | いいえ |

### <a name="request-example"></a>要求の例
アドオン入手データを取得するためのいくつかの要求の例を次に示します。 置換、 *addonProductId*と*applicationId*アドオンまたはアプリの適切な Store ID の値。 

```syntax
GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/addonacquisitions?applicationId=9WZDNCRFJ314&startDate=1/1/2015&endDate=2/1/2015&skip=0 HTTP/1.1 

Authorization: Bearer <your access token> 

 

GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/addonacquisitions?applicationId=9WZDNCRFJ314&startDate=1/1/2015&endDate=2/1/2015&skip=0&filter=market eq 'GB' and gender eq 'm' HTTP/1.1 

Authorization: Bearer <your access token>
```

## <a name="response"></a>応答

### <a name="response-body"></a>応答本文

| Value | 種類 | 説明 |
| --- | --- | --- |
| Value | array | 集計アドオン入手データが含まれるオブジェクトの配列です。 各オブジェクトのデータについて詳しくは、次の「[アドオン入手値](#add-on-acquisition-values)」セクションをご覧ください。 |
| @nextLink | string | データの追加ページがある場合、この文字列には、データの次のページを要求するために使用できる URI が含まれます。 たとえば、要求の **top** パラメーターが 10000 に設定されたが、クエリのアドオン入手データに 10,000 を超える行が含まれている場合に、この値が返されます。 |
| TotalCount | int | クエリの結果データ内の行の総数です。 |

### <a name="add-on-acquisition-values"></a>アドオン入手値
値の配列内の要素には、次の値が含まれます。

| 値 | 種類 | 説明 | 
| --- | --- | --- |
| date | string | 入手データの日付範囲の最初の日付です。 要求に日付を指定した場合、この値はその日付になります。 要求に週、月、またはその他の日付範囲を指定した場合、この値はその日付範囲の最初の日付になります。 |
| addonProductId | string | *ProductId*取得データを取得するアドオンの。 |
| addonProductName | string | アドオンの表示名です。 この値のみが表示されます、応答データの場合、 *aggregationLevel*パラメーターに設定されて**日**指定しない限り、 **addonProductName**フィールド、に*groupby*パラメーター。 |
| applicationId | string | *ProductId*のアドオン購入データを取得するアプリです。 |
| applicationName | string | ゲームの表示名です。 |
| deviceType | string | 入手が完了したデバイスの種類を指定する、以下のいずれかの文字列です。 <ul><li>"PC"</li><li>「電話」</li><li>「コンソール」</li><li>"IoT"</li><li>"Server"</li><li>"Tablet"</li><li>"Holographic"</li><li>「不明」</li></ul> |
| storeClient | string | 入手が発生した Store のバージョンを示す、以下のいずれかの文字列です。 <ul><li>「Windows Phone ストア (クライアント)」</li><li>"Microsoft Store (クライアント)"(または「Windows ストア (クライアント)」、2018 年 3 月 23 日の前にデータのクエリを実行する場合)</li><li>"Microsoft Store (web)"(または"Windows Store (web)"の場合は、2018 年 3 月 23 日の前にデータの照会)</li><li>組織でボリューム購入"</li><li>「その他」</li></ul> |
| osVersion | string | 入手が発生した OS のバージョンです。 このメソッドは、この値は常に値が"Windows 10"です。 |
| market | string | 入手が発生した市場の ISO 3166 国コードです。 |
| gender | string | 入手したユーザーの性別を指定する、以下のいずれかの文字列です。 <ul><li>"m"</li><li>"f"</li><li>「不明」</li></ul> |
| age | string | 入手したユーザーの年齢グループを示す、以下のいずれかの文字列です。 <ul><li>「より小さい 13」</li><li>"13-17"</li><li>"18-24"</li><li>"25-34"</li><li>"35-44"</li><li>"44-55"</li><li>「55 より大きい」</li><li>「不明」</li></ul> |
| acquisitionType | string | 入手の種類を示す、以下のいずれかの文字列です。 <ul><li>「無料」 </li><li>「試用版」 </li><li>「有料」</li><li>「プロモーション コード」 </li><li>"Iap"</li><li>"サブスクリプション Iap"</li><li>"プライベート Audience"</li><li>「より前の順序」</li><li>"Xbox Game Pass"(または「ゲーム パス」が、2018 年 3 月 23 日の前にデータの照会)</li><li>"Disk"</li><li>「プリペイド コード」</li><li>「以前の注文を課金」</li><li>「以前の注文をキャンセル」</li><li>「以前の注文に失敗しました」</li></ul> |
| acquisitionQuantity | 整数 | 発生した入手の数です。 |
| inAppProductId | string | このアドオンが使用されている製品のプロダクト ID。  |
| inAppProductName | string | このアドオンが使用されている製品の製品名。  |
| paymentInstrumentType | string | 支払い方法タイプは、取得のために使用します。  |
| sandboxId | string | ゲーム用に作成されたサンド ボックス ID。 値を指定できます**小売**またはプライベートのサンド ボックス id。  |
| xboxTitleId | string | 該当する場合、XDP から製品の Xbox タイトル ID です。  |
| localCurrencyCode | string | パートナー センター アカウントの国に基づくローカルの通貨コード。  |
| xboxProductId | string | 該当する場合、XDP から製品の Xbox 製品 ID です。  |
| availabilityId | string | 該当する場合、XDP から製品の可用性の ID。  |
| skuId | string | 該当する場合、XDP から製品の SKU ID です。  |
| skuDisplayName | string | 該当する場合、XDP から製品の SKU 表示名。  |
| xboxParentProductId | string | 該当する場合、XDP から製品の Xbox 親プロダクト ID。  |
| parentProductName | string | 該当する場合、XDP から製品の親製品名。  |
| productTypeName | string | 該当する場合、XDP から製品の製品の種類名。  |
| purchaseTaxType | string | 該当する場合は、XDP から税の種類の製品を購入します。  |
| purchasePriceUSDAmount | number | アドオンには、顧客が支払った金額は、米国ドルに変換されます。  |
| purchasePriceLocalAmount | number | アドオンに適用される税額。  |
| purchaseTaxUSDAmount | number | アドオンに適用される税額は米国ドルに変換されます。  |
| purchaseTaxLocalAmount | number | 該当する場合は、XDP からローカルに税額製品を購入します。  |

### <a name="response-example"></a>応答の例
この要求の JSON 返信の本文の例を次に示します。 

```JSON
{ 
  "Value": [ 
    { 
            "inAppProductId": "9NBLGGH1864K", 
            "inAppProductName": "866879", 
            "addonProductId": "9NBLGGH1864K", 
            "addonProductName": "866879", 
            "date": "2017-11-05", 
            "applicationId": "9WZDNCRFJ314", 
            "applicationName": "Tetris Blitz", 
            "acquisitionType": "Iap", 
            "age": "35-49", 
            "deviceType": "Phone", 
            "gender": "m", 
            "market": "US", 
            "osVersion": "Windows Phone 8.1", 
            "paymentInstrumentType": "Credit Card", 
            "sandboxId": "RETAIL", 
            "storeClient": "Windows Phone Store (client)", 
            "xboxTitleId": "", 
            "localCurrencyCode": "USD", 
            "xboxProductId": "00000000-0000-0000-0000-000000000000", 
            "availabilityId": "", 
            "skuId": "", 
            "skuDisplayName": "Full", 
            "xboxParentProductId": "", 
            "parentProductName": "Tetris Blitz", 
            "productTypeName": "Add-On", 
            "purchaseTaxType": "", 
            "acquisitionQuantity": 1, 
            "purchasePriceUSDAmount": 1.08, 
            "purchasePriceLocalAmount": 0.09, 
            "purchaseTaxUSDAmount": 1.08, 
            "purchaseTaxLocalAmount": 0.09 
        } 
    ], 

    "@nextLink": null, 
    
    "TotalCount": 7601 
} 
```