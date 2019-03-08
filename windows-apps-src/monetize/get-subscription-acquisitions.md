---
description: Microsoft Store analytics API でこのメソッドを使用して、中に特定の日付範囲とその他のオプションのフィルターがアドオンのサブスクリプションの購入データを取得します。
title: サブスクリプション アドオンの取得数の取得
ms.date: 01/25/18
ms.topic: article
keywords: windows 10、uwp、Store services、Microsoft Store analytics API, サブスクリプション
ms.openlocfilehash: e33a3ded219fb4d223137b40ebe871f66589addf
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57594777"
---
# <a name="get-subscription-add-on-acquisitions"></a>サブスクリプション アドオンの取得数の取得

Microsoft Store analytics API でこのメソッドを使用して、集計の取得データを特定の日付範囲とその他のオプションのフィルターの中に、アプリのアドオンのサブスクリプションを取得します。

## <a name="prerequisites"></a>前提条件

このメソッドを使うには、最初に次の作業を行う必要があります。

* Microsoft Store 分析 API に関するすべての[前提条件](access-analytics-data-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。
* このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら新しいトークンを取得できます。

## <a name="request"></a>要求


### <a name="request-syntax"></a>要求の構文

| メソッド | 要求 URI                                                                |
|--------|----------------------------------------------------------------------------|
| GET    | ```https://manage.devcenter.microsoft.com/v1.0/my/analytics/subscriptions``` |


### <a name="request-header"></a>要求ヘッダー

| Header        | 種類   | 説明          |
|---------------|--------|--------------|
| Authorization | string | 必須。 **Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。 |


### <a name="request-parameters"></a>要求パラメーター

| パラメーター        | 種類   |  説明      |  必須  
|---------------|--------|---------------|------|
| applicationId | string | [Store ID](in-app-purchases-and-trials.md#store-ids)のサブスクリプションのアドオン購入データを取得するアプリです。 |  〇  |
| subscriptionProductId  | string | [Store ID](in-app-purchases-and-trials.md#store-ids)取得データを取得するサブスクリプションのアドオンです。 この値を指定しない場合、このメソッドは、指定したアプリのすべてのサブスクリプションのアドオンの購入データを返します。  | X  |
| startDate | date | 取得するアドオンのサブスクリプションの取得データの日付範囲の開始日。 既定値は現在の日付です。 |  X  |
| endDate | date | 取得するアドオンのサブスクリプションの取得データの日付範囲の終了日。 既定値は現在の日付です。 |  X  |
| top | int | 要求で返すデータの行数です。 最大値および指定しない場合の既定値は 100 です。 クエリにこれを上回る行がある場合は、応答本文に次リンクが含まれ、そのリンクを使ってデータの次のページを要求できます。 |  X  |
| skip | int | クエリでスキップする行数です。 大きなデータ セットを操作するには、このパラメーターを使用します。 たとえば、top=100 と skip=0 を指定すると、データの最初の 100 行が取得され、top=100 と skip=100 を指定すると、データの次の 100 行が取得されます。 |  X  |
| filter | string  | 応答本文をフィルター処理する 1 つまたは複数のステートメントです。 各ステートメントでは **eq** や **ne** 演算子を使用できます。また、ステートメントを **and** や **or** で結合することもできます。 フィルター ステートメントでは、次の文字列を指定できます (これらに対応して[応答本文で値を](#subscription-acquisition-values))。 <ul><li><strong>date</strong></li><li><strong>subscriptionProductName</strong></li><li><strong>applicationName</strong></li><li><strong>skuId</strong></li><li><strong>market</strong></li><li><strong>deviceType</strong></li></ul><p>例を次に示します*フィルター*パラメーター:<em>フィルター = 日付 eq ' 2017-07-08'</em>します。</p> | X   |
| aggregationLevel | string | 集計データを取得する時間範囲を指定します。 次のいずれかの文字列を指定できます。<strong>day</strong>、<strong>week</strong>、または <strong>month</strong>。 指定しない場合、既定値は <strong>day</strong> です。 | X |
| orderby | string | 各サブスクリプションのアドオン購入のデータ値の結果を注文するステートメント。 構文は <em>orderby=field [order],field [order],...</em> です。<em>field</em> パラメーターには、次のいずれかの文字列を指定できます。<ul><li><strong>date</strong></li><li><strong>subscriptionProductName</strong></li><li><strong>applicationName</strong></li><li><strong>skuId</strong></li><li><strong>market</strong></li><li><strong>deviceType</strong></li></ul><p><em>order</em> パラメーターは省略可能であり、<strong>asc</strong> または <strong>desc</strong> を指定して、各フィールドを昇順または降順にすることができます。 既定値は <strong>asc</strong> です。</p><p><em>orderby</em> 文字列の例: <em>orderby=date,market</em></p> |  X  |
| groupby | string | 指定したフィールドのみにデータ集計を適用するステートメントです。 次のフィールドを指定できます。<ul><li><strong>date</strong></li><li><strong>subscriptionProductName</strong></li><li><strong>applicationName</strong></li><li><strong>skuId</strong></li><li><strong>market</strong></li><li><strong>deviceType</strong></li></ul><p><em>groupby</em> パラメーターは、<em>aggregationLevel</em> パラメーターと同時に使用できます。 例: <em>groupby = 市場&amp;aggregationLevel = 週</em></p> |  X  |


### <a name="request-example"></a>要求の例

次の例では、サブスクリプションのアドオン購入データを取得する方法を示します。 置換、 *applicationId*アプリの適切な Store ID を持つ値。

```syntax
GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/subscriptions?applicationId=9NBLGGGZ5QDR&startDate=2017-07-07&endDate=2017-07-08 HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a>応答


### <a name="response-body"></a>応答本文

| Value      | 種類   | 説明         |
|------------|--------|------------------|
| Value      | array  | 集計のサブスクリプションのアドオン購入データを格納するオブジェクトの配列。 各オブジェクトのデータの詳細については、次を参照してください。、[サブスクリプション購入値](#subscription-acquisition-values)以下のセクション。             |
| @nextLink  | string | データの追加ページがある場合、この文字列には、データの次のページを要求するために使用できる URI が含まれます。 この値が返される場合など、**上部**要求のパラメーターは 100 に設定されますが、クエリのサブスクリプションのアドオン購入データの 100 を超える行があります。 |
| TotalCount | int    | クエリの結果データ内の行の総数です。       |


<span id="subscription-acquisition-values" />

### <a name="subscription-acquisition-values"></a>サブスクリプションの取得の値

*Value* 配列の要素には、次の値が含まれます。

| Value               | 種類    | 説明        |
|---------------------|---------|---------------------|
| date                | string  | 入手データの日付範囲の最初の日付です。 要求に日付を指定した場合、この値はその日付になります。 要求に週、月、またはその他の日付範囲を指定した場合、この値はその日付範囲の最初の日付になります。 |
| subscriptionProductId      | string  | [Store ID](in-app-purchases-and-trials.md#store-ids)取得データを取得するサブスクリプションのアドオンです。    |
| subscriptionProductName    | string  | サブスクリプションのアドオンの表示名。         |
| applicationId       | string  | [Store ID](in-app-purchases-and-trials.md#store-ids)のサブスクリプションのアドオン購入データを取得するアプリです。   |
| applicationName     | string  | アプリの表示名です。     |
| skuId     | string  | ID、 [SKU](in-app-purchases-and-trials.md#products-skus)取得データを取得するサブスクリプションのアドオンです。     |
| deviceType          | string  |  入手が完了したデバイスの種類を指定する、以下のいずれかの文字列です。<ul><li><strong>PC</strong></li><li><strong>Phone</strong></li><li><strong>Console</strong></li><li><strong>IoT</strong></li><li><strong>Holographic</strong></li><li><strong>Unknown</strong></li></ul>       |
| market           | string  | 入手が発生した市場の ISO 3166 国コードです。     |
| currencyCode         | string  | 税引き前に、の総売り上げの ISO 4217 形式で通貨コード。       |
| grossSalesBeforeTax           | 整数  | 指定された現地通貨での総売り上げ、 *currencyCode*値。     |
| totalActiveCount             | 整数  | 指定した期間中にアクティブなサブスクリプションの合計数。 これは、合計に、 *goodStandingActiveCount*、 *pendingGraceActiveCount*、 *graceActiveCount*、および*lockedActiveCount*値。  |
| totalChurnCount              | 整数  | 指定した期間中に非アクティブ化されたサブスクリプションの合計数。 これは、合計に、 *billingChurnCount*、 *nonRenewalChurnCount*、 *refundChurnCount*、 *chargebackChurnCount*、 *earlyChurnCount*、および*otherChurnCount*値。   |
| newCount            | 整数  | 試用版を含む、指定した期間内に新しいサブスクリプションの買収の数。    |
| renewCount     | 整数  | ユーザーが開始したの更新と自動更新を含む、指定した期間内にサブスクリプションの更新の数。        |
| goodStandingActiveCount | 整数 | 指定した期間中にアクティブだったして、有効期限日があるサブスクリプションの数 > =、 *endDate*クエリの値。    |
| pendingGraceActiveCount | 整数 | サブスクリプションの有効期限日があると、指定された期間中にアクティブだったが、課金の失敗したサブスクリプションの数 > =、 *endDate*クエリの値。     |
| graceActiveCount | 整数 | 指定した期間中にアクティブだったが、課金の失敗したサブスクリプションの数と場所。<ul><li>サブスクリプションの有効期限が <、 *endDate*クエリの値。</li><li>猶予期間の終了は > =、 *endDate*値。</li></ul>        |
| lockedActiveCount | 整数 | サブスクリプションに含まれていた数*dunning* (つまり、サブスクリプションの有効期限が近づいていると Microsoft は、自動的にサブスクリプションを更新するための資金を取得しようとしています) 中に、指定した期間と場所を時間します。<ul><li>サブスクリプションの有効期限が <、 *endDate*クエリの値。</li><li>猶予期間の終了は、< =、 *endDate*値。</li></ul>        |
| billingChurnCount | 整数 | 場所、サブスクリプションであった dunning するされた請求料金を処理できないのため、指定した期間中に非アクティブ化されたサブスクリプションの数。        |
| nonRenewalChurnCount | 整数 | 指定された期間中に非アクティブ化が更新されたされないため、サブスクリプションの数。        |
| refundChurnCount | 整数 | 返金したために、指定した期間中に非アクティブ化されたサブスクリプションの数。        |
| chargebackChurnCount | 整数 | チャージ バックのために、指定した期間中に非アクティブ化されたサブスクリプションの数。        |
| earlyChurnCount | 整数 | 良好な状態であるときに、指定した期間中に非アクティブ化されたされたサブスクリプションの数。        |
| otherChurnCount | 整数 | 他の理由から、指定した期間中に非アクティブ化されたサブスクリプションの数。        |


### <a name="response-example"></a>応答の例

この要求の JSON 返信の本文の例を次に示します。

```json
{
  "Value": [
    {
      "date": "2017-07-08",
      "subscriptionProductId": "9KDLGHH6R365",
      "subscriptionProductName": "Contoso App Subscription with One Month Free Trial",
      "applicationId": "9NBLGGH4R315",
      "applicationName": "Contoso App",
      "skuId": "0020",
      "market": "Unknown",
      "deviceType": "PC",
      "currencyCode": "USD",
      "grossSalesBeforeTax": 0.0,
      "totalActiveCount": 1,
      "totalChurnCount": 0,
      "newCount": 0,
      "renewCount": 0,
      "goodStandingActiveCount": 1,
      "pendingGraceActiveCount": 0,
      "graceActiveCount": 0,
      "lockedActiveCount": 0,
      "billingChurnCount": 0,
      "nonRenewalChurnCount": 0,
      "refundChurnCount": 0,
      "chargebackChurnCount": 0,
      "earlyChurnCount": 0,
      "otherChurnCount": 0
    },
    {
      "date": "2017-07-08",
      "subscriptionProductId": "9JJFDHG4R478",
      "subscriptionProductName": "Contoso App Monthly Subscription",
      "applicationId": "9NBLGGH4R315",
      "applicationName": "Contoso App",
      "skuId": "0020",
      "market": "US",
      "deviceType": "PC",
      "currencyCode": "USD",
      "grossSalesBeforeTax": 0.0,
      "totalActiveCount": 1,
      "totalChurnCount": 0,
      "newCount": 0,
      "renewCount": 0,
      "goodStandingActiveCount": 1,
      "pendingGraceActiveCount": 0,
      "graceActiveCount": 0,
      "lockedActiveCount": 0,
      "billingChurnCount": 0,
      "nonRenewalChurnCount": 0,
      "refundChurnCount": 0,
      "chargebackChurnCount": 0,
      "earlyChurnCount": 0,
      "otherChurnCount": 0
    }
  ],
  "@nextLink": null,
  "TotalCount": 2
}
```

## <a name="related-topics"></a>関連トピック

* [アドオン取得レポート](../publish/add-on-acquisitions-report.md)
* [Microsoft Store サービスを使用して分析データにアクセス](access-analytics-data-using-windows-store-services.md)

 

 
