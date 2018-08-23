---
author: mcleanbyron
description: アプリのデータの分析結果を取得するのにでは、Microsoft ストア分析 API このメソッドを使用します。
title: データの分析結果を取得します。
ms.author: mcleans
ms.date: 07/31/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10、uwp、ストア サービス、Microsoft ストア分析 API、分析結果
ms.localizationpriority: medium
ms.openlocfilehash: 53fbd91437e5dc702f8672c6cbadeea32a8a96bf
ms.sourcegitcommit: 9c79fdab9039ff592edf7984732d300a14e81d92
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/23/2018
ms.locfileid: "2814584"
---
# <a name="get-insights-data"></a>データの分析結果を取得します。

指定された日付の範囲とその他のオプションのフィルターの中に、買収、性、アプリの使用指標に関連するこの方法でデータの分析結果を取得するには、Microsoft ストア分析 API を使用します。 この情報も Windows デベロッパー センターのダッシュ ボードの[分析レポート](../publish/insights-report.md)で使用できます。

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
| applicationId | string | データの分析結果を取得するアプリの[ストアの ID](in-app-purchases-and-trials.md#store-ids)です。 このパラメーターを指定しないと、応答本文が自分のアカウントに登録されているすべてのアプリのデータ分析にはが含まれます。  |  必須ではない  |
| startDate | date | 日付範囲内のデータの分析結果を取得する開始日です。 既定値は、現在の日付の 30 日前です。 |  必須ではない  |
| endDate | date | 日付範囲内のデータの分析結果を取得する終了日です。 既定値は現在の日付です。 |  必須ではない  |
| filter | string  | 応答内の行をフィルター処理する 1 つまたは複数のステートメントです。 各ステートメントには、応答本文からのフィールド名、および **eq** 演算子または **ne** 演算子と関連付けられる値が含まれており、**and** や **or** を使用してステートメントを組み合わせることができます。 *filter* パラメーターでは、文字列値を単一引用符で囲む必要があります。 たとえば、*フィルター = データ型 eq '取得'* します。 <p/><p/>次のフィルター フィールドを指定できます。<p/><ul><li><strong>取得</strong></li><li><strong>正常性</strong></li><li><strong>利用状況</strong></li></ul> | いいえ   |

### <a name="request-example"></a>要求の例

次の例では、データの分析結果を取得するための出席依頼を示します。 *applicationId* 値を、目的のアプリのストア ID に置き換えてください。

```syntax
GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/insights?applicationId=9NBLGGGZ5QDR&startDate=6/1/2018&endDate=6/15/2018&filter=dataType eq 'acquisition' or dataType eq 'health' HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a>応答

### <a name="response-body"></a>応答本文

| 値      | 型   | 説明                  |
|------------|--------|-------------------------------------------------------|
| Value      | array  | アプリのデータを分析結果を含むオブジェクトの配列します。 各オブジェクト内のデータの詳細については、次の[値を把握](#insight-values)セクションを参照してください。                                                                                                                      |
| TotalCount | int    | クエリの結果データ内の行の総数です。                 |


### <a name="insight-values"></a>値の把握

*Value* 配列の要素には、次の値が含まれます。

| 値               | 型   | 説明                           |
|---------------------|--------|-------------------------------------------|
| applicationId       | string | データの分析結果を取得しているアプリのストア ID。     |
| insightDate                | string | 特定のメトリックの変更わかりました日。 この日付は、大幅に増加が検出されたことを週の最後を表す前に、その曜日と比較してメトリックの増減します。 |
| データ型     | string | この情報を説明する一般的な分析領域を指定する次の文字列のいずれかを指定します。<p/><ul><li><strong>取得</strong></li><li><strong>正常性</strong></li><li><strong>利用状況</strong></li></ul>   |
| insightDetail          | array | 1 つまたは複数の[InsightDetail 値](#insightdetail-values)を現在の情報の詳細を表します。    |


### <a name="insightdetail-values"></a>InsightDetail 値

| 値               | 型   | 説明                           |
|---------------------|--------|-------------------------------------------|
| FactName           | string | 次の値を現在のディメンション、現在の情報は、次の説明、メートル法を示すのいずれかは、**データ型**の値に基づいています。<ul><li>**正常性**の場合は、この値は常に値が**ヒット数です**。</li><li>**取得**、この値は常に値が**AcquisitionQuantity です**。</li><li>**使用**の場合は、この値は文字列は、以下のいずれかを指定できます。<ul><li><strong>DailyActiveUsers</strong></li><li><strong>EngagementDurationMinutes</strong></li><li><strong>DailyActiveDevices</strong></li><li><strong>DailyNewUsers</strong></li><li><strong>DailySessionCount</strong></li></ul></ul>  |
| SubDimensions         | array |  情報を得ることの 1 つの指標を説明する 1 つまたは複数のオブジェクト   |
| PercentChange            | string |  全体の顧客ベースにわたって、メートル法が変更された割合です。  |
| DimensionName           | string |  現在のディメンションで説明するメトリックの名前。 例には、**イベントの種類**、**市場**、 **DeviceType**、 **PackageVersion**、 **AcquisitionType**、 **AgeGroup** 、**性別**が含まれます。   |
| DimensionValue              | string | 現在のディメンションに記載されているメトリックの値。 たとえば、 **DimensionName**が**イベントの種類**である場合は、**クラッシュ**または**ハング**が**DimensionValue**することがあります。   |
| FactValue     | string | 情報を得ることが検出された日付のメトリックの絶対値します。  |
| Direction | string |  方向変更 (**正**または**負の値**) です。   |
| Date              | string |  現在の理解または現在のディメンションに関連する変更わかりました日。   |

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
