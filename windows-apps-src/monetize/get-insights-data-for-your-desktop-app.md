---
description: デスクトップ アプリケーションのインサイト データを取得するのに、Microsoft Store 分析 API の以下のメソッドを使用します。
title: デスクトップ アプリケーションのインサイト データの取得
ms.date: 07/31/2018
ms.topic: article
keywords: windows 10, uwp, Store サービス, Microsoft Store 分析 API, インサイト
ms.localizationpriority: medium
ms.custom: RS5
ms.openlocfilehash: 5545d27668b23e5b7ae91201421dfa4c92f9c8ed
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/05/2018
ms.locfileid: "8742994"
---
# <a name="get-insights-data-for-your-desktop-application"></a>デスクトップ アプリケーションのインサイト データの取得

[Windows デスクトップ アプリケーション プログラム](https://docs.microsoft.com/windows/desktop/appxpkg/windows-desktop-application-program)に追加したデスクトップ アプリケーションの正常性のメトリックに関連するデータについての洞察を Microsoft Store 分析 API でこのメソッドを使います。 このデータは、パートナー センターでデスクトップ アプリケーションの[正常性レポート](https://docs.microsoft.com/windows/desktop/appxpkg/windows-desktop-application-program#health-report)で利用可能なもできます。

## <a name="prerequisites"></a>前提条件

このメソッドを使うには、最初に次の作業を行う必要があります。

* Microsoft Store 分析 API に関するすべての[前提条件](access-analytics-data-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。
* このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら、新しいトークンを取得できます。

## <a name="request"></a>要求


### <a name="request-syntax"></a>要求の構文

| メソッド | 要求 URI       |
|--------|----------------------|
| GET    | ```https://manage.devcenter.microsoft.com/v1.0/my/analytics/desktop/insights``` |


### <a name="request-header"></a>要求ヘッダー

| ヘッダー        | 型   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| Authorization | string | 必須。 **Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。 |


### <a name="request-parameters"></a>要求パラメーター

| パラメーター        | 型   |  説明      |  必須かどうか  
|---------------|--------|---------------|------|
| applicationId | string | インサイト データを取得するデスクトップ アプリケーションの製品 ID です。 デスクトップ アプリケーションの製品 ID を取得するには、(などの**正常性レポート**で) すべての[パートナー センターで、デスクトップ アプリケーションの分析レポート](https://msdn.microsoft.com/library/windows/desktop/mt826504)を開き、URL から製品 ID を取得します。 このパラメーターを指定しない場合、応答本文にはアカウントに登録されているすべてのアプリのインサイト データが含まれます。  |  必須ではない  |
| startDate | date | 取得するインサイト データの日付範囲の開始日です。 既定値は、現在の日付の 30 日前です。 |  必須ではない  |
| endDate | date | 取得するインサイト データの日付範囲の終了日です。 既定値は現在の日付です。 |  必須ではない  |
| filter | string  | 応答内の行をフィルター処理する 1 つまたは複数のステートメントです。 各ステートメントには、応答本文からのフィールド名、および **eq** 演算子または **ne** 演算子と関連付けられる値が含まれており、**and** や **or** を使用してステートメントを組み合わせることができます。 *filter* パラメーターでは、文字列値を単一引用符で囲む必要があります。 たとえば、 *filter = dataType eq '入手'* します。 <p/><p/>現在このメソッドでは、フィルター**の正常性**のみがサポートされます。  | いいえ   |

### <a name="request-example"></a>要求の例

次の例では、インサイト データを取得する要求を示します。 *ApplicationId*値をデスクトップ アプリケーションの適切な値に置き換えます。

```syntax
GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/desktop/insights?applicationId=10238467886765136388&startDate=6/1/2018&endDate=6/15/2018&filter=dataType eq 'health' HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a>応答

### <a name="response-body"></a>応答本文

| 値      | 型   | 説明                  |
|------------|--------|-------------------------------------------------------|
| Value      | array  | アプリのインサイト データが含まれるオブジェクトの配列です。 各オブジェクトのデータについて詳しくは、後述の「[インサイトの値](#insight-values)を参照してください。                                                                                                                      |
| TotalCount | int    | クエリの結果データ内の行の総数です。                 |


### <a name="insight-values"></a>Insight 値

*Value* 配列の要素には、次の値が含まれます。

| 値               | 型   | 説明                           |
|---------------------|--------|-------------------------------------------|
| applicationId       | string | インサイト データを取得したデスクトップ アプリケーションの製品 ID です。     |
| insightDate                | string | 特定のメトリックの変更わかりました日です。 この日付またはそれより前に、の週との比較メトリックの短縮を大幅に増加を検出しました週の終わりを表します。 |
| データ型     | string | この情報に通知する一般的な分析領域を指定する文字列。 現時点では、このメソッドでは、**正常性**をのみがサポートされます。    |
| insightDetail          | array | 1 つまたは複数[InsightDetail 値](#insightdetail-values)を表す現在インサイトの詳細情報。    |


### <a name="insightdetail-values"></a>InsightDetail 値

| 値               | 型   | 説明                           |
|---------------------|--------|-------------------------------------------|
| FactName           | string | 現在の洞察または現在のディメンションを説明するメトリックを示す文字列です。 現時点では、このメソッドでは、**ヒット数**の値のみがサポートされます。  |
| SubDimensions         | array |  情報を得ることの 1 つのメトリックを記述する 1 つまたは複数のオブジェクトです。   |
| PercentChange            | string |  メトリックは、全体の顧客ベースの間で変更された割合。  |
| DimensionName           | string |  現在のディメンションで説明されているメトリックの名前です。 例についてには、**イベントの種類**、**市場**、 **DeviceType**、および**PackageVersion**が含まれます。   |
| DimensionValue              | string | 現在のディメンションに記載されているメトリックの値。 たとえば、 **DimensionName**が**イベントの種類**である場合は、**クラッシュ**や**ハング**が**DimensionValue**することがあります。   |
| FactValue     | string | 情報を得ることが検出された日付のメトリックの絶対値。  |
| Direction | string |  (**正**または**負**) の変更の方向です。   |
| Date              | string |  現在の分析情報と現在のディメンションに関連する変更わかりました日です。   |

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

* [Windows デスクトップ アプリケーション プログラム](https://docs.microsoft.com/windows/desktop/appxpkg/windows-desktop-application-program)
* [状態レポート](https://docs.microsoft.com/windows/desktop/appxpkg/windows-desktop-application-program#health-report)
* [Microsoft Store サービスを使った分析データへのアクセス](access-analytics-data-using-windows-store-services.md)
