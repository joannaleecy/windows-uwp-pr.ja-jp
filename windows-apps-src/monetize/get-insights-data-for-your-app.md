---
description: Microsoft Store analytics API でこのメソッドを使用すると、アプリの insights のデータを取得できます。
title: Insights のデータを取得します。
ms.date: 07/31/2018
ms.topic: article
keywords: windows 10、uwp、Store services、Microsoft Store analytics API、insights
ms.localizationpriority: medium
ms.custom: RS5
ms.openlocfilehash: 1847f22f52eb066115b5681e745e74ec74f77f7d
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57662847"
---
# <a name="get-insights-data"></a>Insights のデータを取得します。

Insights データを取得するには、Microsoft Store analytics API では、このメソッドは、特定の日付範囲とその他のオプションのフィルターの中に、買収、ヘルス、およびアプリの使用状況メトリックに関連するを使用します。 この情報も記載されて、 [Insights レポート](../publish/insights-report.md)パートナー センターでします。

## <a name="prerequisites"></a>前提条件


このメソッドを使うには、最初に次の作業を行う必要があります。

* Microsoft Store 分析 API に関するすべての[前提条件](access-analytics-data-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。
* このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら新しいトークンを取得できます。

## <a name="request"></a>要求


### <a name="request-syntax"></a>要求の構文

| メソッド | 要求 URI       |
|--------|----------------------|
| GET    | ```https://manage.devcenter.microsoft.com/v1.0/my/analytics/insights``` |


### <a name="request-header"></a>要求ヘッダー

| Header        | 種類   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| Authorization | string | 必須。 **Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。 |


### <a name="request-parameters"></a>要求パラメーター

| パラメーター        | 種類   |  説明      |  必須  
|---------------|--------|---------------|------|
| applicationId | string | [Store ID](in-app-purchases-and-trials.md#store-ids) insights データを取得するアプリの。 このパラメーターを指定しないと、応答本文は、自分のアカウントに登録されているすべてのアプリの insights のデータが含まれます。  |  X  |
| startDate | date | 取得する insights データの日付範囲の開始日。 既定値は、現在の日付の 30 日前です。 |  X  |
| endDate | date | 取得する insights データの日付範囲の終了日。 既定値は現在の日付です。 |  X  |
| filter | string  | 応答内の行をフィルター処理する 1 つまたは複数のステートメントです。 各ステートメントには、応答本文からのフィールド名、および **eq** 演算子または **ne** 演算子と関連付けられる値が含まれており、**and** や **or** を使用してステートメントを組み合わせることができます。 *filter* パラメーターでは、文字列値を単一引用符で囲む必要があります。 たとえば、*フィルター = データ型 eq '買収'* します。 <p/><p/>次のフィルター フィールドを指定できます。<p/><ul><li><strong>acquisition</strong></li><li><strong>正常性</strong></li><li><strong>usage</strong></li></ul> | X   |

### <a name="request-example"></a>要求の例

次の例では、insights データを取得するための要求を示します。 *applicationId* 値を、目的のアプリのストア ID に置き換えてください。

```syntax
GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/insights?applicationId=9NBLGGGZ5QDR&startDate=6/1/2018&endDate=6/15/2018&filter=dataType eq 'acquisition' or dataType eq 'health' HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a>応答

### <a name="response-body"></a>応答本文

| Value      | 種類   | 説明                  |
|------------|--------|-------------------------------------------------------|
| Value      | array  | アプリの insights のデータを格納するオブジェクトの配列。 各オブジェクトのデータの詳細については、次を参照してください。、 [Insight 値](#insight-values)以下のセクション。                                                                                                                      |
| TotalCount | int    | クエリの結果データ内の行の総数です。                 |


### <a name="insight-values"></a>Insight 値

*Value* 配列の要素には、次の値が含まれます。

| Value               | 種類   | 説明                           |
|---------------------|--------|-------------------------------------------|
| applicationId       | string | Insights のデータを取得するアプリの Store ID。     |
| insightDate                | string | 日付が特定のメトリックの変化を特定しました。 この日付は、大幅な増加を検出しました週の終わりを表すと比較する前に、その週とメトリックに増減します。 |
| データ型     | string | この情報を表す一般的な分析の領域を指定する次の文字列のいずれか:<p/><ul><li><strong>acquisition</strong></li><li><strong>正常性</strong></li><li><strong>usage</strong></li></ul>   |
| insightDetail          | array | 1 つまたは複数[InsightDetail 値](#insightdetail-values)現在インサイトの詳細を表します。    |


### <a name="insightdetail-values"></a>InsightDetail 値

| Value               | 種類   | 説明                           |
|---------------------|--------|-------------------------------------------|
| FactName           | string | 現在 insight または現在のディメンションについて説明します、メトリックを示す値は次のいずれかに基づいて、 **dataType**値。<ul><li>**ヘルス**、この値は常に**ヒット カウント**します。</li><li>**買収**、この値は常に**取得数**します。</li><li>**使用状況**、この値は、次の文字列のいずれかを指定できます。<ul><li><strong>DailyActiveUsers</strong></li><li><strong>EngagementDurationMinutes</strong></li><li><strong>DailyActiveDevices</strong></li><li><strong>DailyNewUsers</strong></li><li><strong>DailySessionCount</strong></li></ul></ul>  |
| SubDimensions         | array |  情報を得ることの 1 つのメトリックを記述する 1 つまたは複数のオブジェクト。   |
| PercentChange            | string |  この割合は、全体の顧客ベースでメトリックを変更しました。  |
| DimensionName           | string |  現在のディメンションで説明されているメトリックの名前。 例としては、 **EventType**、**市場**、 **DeviceType**、 **PackageVersion**、 **AcquisitionType**、 **AgeGroup**と**性別**します。   |
| DimensionValue              | string | 現在のディメンションで説明されているメトリックの値。 たとえば場合、 **DimensionName**は**EventType**、 **DimensionValue**可能性があります**クラッシュ**または**ハング**.   |
| FactValue     | string | 情報を得ることが検出された日付のメトリックの絶対値。  |
| Direction | string |  変更の方向 (**正**または**負**)。   |
| 日付              | string |  日付、現在の情報または現在のディメンションに関連する変更を特定しました。   |

### <a name="response-example"></a>応答の例

この要求の JSON 返信の本文の例を次に示します。

```json
{
  "Value": [
    {
      "applicationId": "9NBLGGGZ5QDR",
      "insightDate": "2018-06-03T00:00:00",
      "dataType": "health",
      "insightDetail": [
        {
          "FactName": "HitCount",
          "SubDimensions": [
            {
              "FactName:": "HitCount",
              "PercentChange": "21",
              "DimensionValue:": "DE",
              "FactValue": "109",
              "Direction": "Positive",
              "Date": "6/3/2018 12:00:00 AM",
              "DimensionName": "Market"
            }
          ],
          "DimensionValue": "crash",
          "Date": "6/3/2018 12:00:00 AM",
          "DimensionName": "EventType"
        },
        {
          "FactName": "HitCount",
          "SubDimensions": [
            {
              "FactName:": "HitCount",
              "PercentChange": "71",
              "DimensionValue:": "JP",
              "FactValue": "112",
              "Direction": "Positive",
              "Date": "6/3/2018 12:00:00 AM",
              "DimensionName": "Market"
            }
          ],
          "DimensionValue": "hang",
          "Date": "6/3/2018 12:00:00 AM",
          "DimensionName": "EventType"
        },
      ],
      "insightId": "9CY0F3VBT1AS942AFQaeyO0k2zUKfyOhrOHc0036Iwc="
    }
  ],
  "@nextLink": null,
  "TotalCount": 2
}
```

## <a name="related-topics"></a>関連トピック

* [Insights のレポート](../publish/insights-report.md)
* [Microsoft Store サービスを使用して分析データにアクセス](access-analytics-data-using-windows-store-services.md)
