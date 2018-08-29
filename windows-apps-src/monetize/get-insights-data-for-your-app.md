---
author: mcleanbyron
description: Microsoft ストア分析 API でこのメソッドを使用すると、アプリの分析データを取得します。
title: 分析データを取得します。
ms.author: mcleans
ms.date: 07/31/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10、uwp、ストア サービス、Microsoft ストア分析 API、洞察
ms.localizationpriority: medium
ms.openlocfilehash: 53fbd91437e5dc702f8672c6cbadeea32a8a96bf
ms.sourcegitcommit: 3727445c1d6374401b867c78e4ff8b07d92b7adc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/29/2018
ms.locfileid: "2916640"
---
# <a name="get-insights-data"></a>分析データを取得します。

指定した日付の範囲およびその他の省略可能なフィルターの中に買収、稼働状態、およびアプリケーションの使用状況の測定基準に関連して情報データを取得するには、Microsoft ストア分析 API では、このメソッドを使用します。 この情報は、Windows デベロッパー センターのダッシュ ボード[の分析レポート](../publish/insights-report.md)で使用できるも。

## <a name="prerequisites"></a>前提条件


このメソッドを使うには、最初に次の作業を行う必要があります。

* Microsoft Store 分析 API に関するすべての[前提条件](access-analytics-data-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。
* このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら、新しいトークンを取得できます。

## <a name="request"></a>要求


### <a name="request-syntax"></a>要求の構文

| メソッド | 要求 URI       |
|--------|----------------------|
| GET    | ```https://manage.devcenter.microsoft.com/v1.0/my/analytics/insights``` |


### <a name="request-header"></a>要求ヘッダー

| ヘッダー        | 型   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| Authorization | string | 必須。 **Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。 |


### <a name="request-parameters"></a>要求パラメーター

| パラメーター        | 型   |  説明      |  必須かどうか  
|---------------|--------|---------------|------|
| applicationId | string | 分析データを取得するアプリケーションの[ストアの ID](in-app-purchases-and-trials.md#store-ids)です。 このパラメーターを指定しないと、応答の本体に自分のアカウントに登録されているすべてのアプリケーションの情報データが含まれます。  |  必須ではない  |
| startDate | date | 取得する情報のデータの日付範囲の開始日です。 既定値は、現在の日付の 30 日前です。 |  必須ではない  |
| endDate | date | 取得する情報のデータの日付範囲の終了日です。 既定値は現在の日付です。 |  必須ではない  |
| filter | string  | 応答内の行をフィルター処理する 1 つまたは複数のステートメントです。 各ステートメントには、応答本文からのフィールド名、および **eq** 演算子または **ne** 演算子と関連付けられる値が含まれており、**and** や **or** を使用してステートメントを組み合わせることができます。 *filter* パラメーターでは、文字列値を単一引用符で囲む必要があります。 たとえば、*フィルター型 eq '取得' を =*。 <p/><p/>次のフィルター フィールドを指定できます。<p/><ul><li><strong>買収</strong></li><li><strong>稼働状態</strong></li><li><strong>使用法</strong></li></ul> | いいえ   |

### <a name="request-example"></a>要求の例

次の使用例は、分析データを取得するための要求を示します。 *applicationId* 値を、目的のアプリのストア ID に置き換えてください。

```syntax
GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/insights?applicationId=9NBLGGGZ5QDR&startDate=6/1/2018&endDate=6/15/2018&filter=dataType eq 'acquisition' or dataType eq 'health' HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a>応答

### <a name="response-body"></a>応答本文

| 値      | 型   | 説明                  |
|------------|--------|-------------------------------------------------------|
| Value      | array  | アプリケーションの情報データを格納するオブジェクトの配列。 各オブジェクト内のデータの詳細については、後述の「[情報の値](#insight-values)を参照してください。                                                                                                                      |
| TotalCount | int    | クエリの結果データ内の行の総数です。                 |


### <a name="insight-values"></a>値の把握

*Value* 配列の要素には、次の値が含まれます。

| 値               | 型   | 説明                           |
|---------------------|--------|-------------------------------------------|
| applicationId       | string | 分析データを取得する対象のアプリケーションのストア ID です。     |
| insightDate                | string | わかりましたが、特定のメトリックの変更をする日です。 この日付は、大幅に増加を検出しましたが週の終わりを表します、その前に、の週と比較して、メートル法でを調整します。 |
| データ型     | string | この見解を説明する一般的な分析の領域を指定する次の文字列のいずれかです。<p/><ul><li><strong>買収</strong></li><li><strong>稼働状態</strong></li><li><strong>使用法</strong></li></ul>   |
| insightDetail          | array | 1 つまたは複数[InsightDetail の値](#insightdetail-values)を現在の力の詳細を表します。    |


### <a name="insightdetail-values"></a>InsightDetail 値

| 値               | 型   | 説明                           |
|---------------------|--------|-------------------------------------------|
| FactName           | string | 示す現在の情報または現在のディメンション、指標を示す次の値の 1 つは、**データ型**の値に基づいています。<ul><li>**状態**では、この値は常に**ヒット カウントです。**</li><li>**買収**、この値は常に値が**AcquisitionQuantity です**。</li><li>**使用法**では、この値は次の文字列のいずれかを指定できます。<ul><li><strong>DailyActiveUsers</strong></li><li><strong>EngagementDurationMinutes</strong></li><li><strong>DailyActiveDevices</strong></li><li><strong>DailyNewUsers</strong></li><li><strong>DailySessionCount</strong></li></ul></ul>  |
| SubDimensions         | array |  情報を得ることの 1 つの指標を説明する 1 つまたは複数のオブジェクトです。   |
| PercentChange            | string |  メトリックが全体の顧客基盤の間で変更された割合です。  |
| DimensionName           | string |  現在の分析コードに記載されているメトリックの名前です。 例には、**イベントの種類**、**市場**、 **DeviceType**、 **PackageVersion**、 **AcquisitionType**、 **AgeGroup** 、**性別**が含まれます。   |
| DimensionValue              | string | 現在の分析コードに記載されているメトリックの値です。 たとえば、 **DimensionName**が**イベントの種類**の場合は、**クラッシュ**または**ハング**が**DimensionValue**することがあります。   |
| FactValue     | string | 情報を得ることが検出された日の指標の絶対値。  |
| Direction | string |  (**正**または**負の値**)、変更の方向です。   |
| Date              | string |  日付に現在情報を得ること、または現在のディメンションに関連する変更を特定しました。   |

### <a name="response-example"></a>応答の例

この要求の JSON 応答の本文の例を次に示します。

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

* [分析レポート](../publish/insights-report.md)
* [Microsoft Store サービスを使った分析データへのアクセス](access-analytics-data-using-windows-store-services.md)
