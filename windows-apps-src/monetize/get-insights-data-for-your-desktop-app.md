---
description: Microsoft Store analytics API でこのメソッドを使用すると、お客様のデスクトップ アプリケーションの insights のデータを取得できます。
title: デスクトップ アプリケーションのインサイト データの取得
ms.date: 07/31/2018
ms.topic: article
keywords: windows 10、uwp、Store services、Microsoft Store analytics API、insights
ms.localizationpriority: medium
ms.custom: RS5
ms.openlocfilehash: 5545d27668b23e5b7ae91201421dfa4c92f9c8ed
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57618137"
---
# <a name="get-insights-data-for-your-desktop-application"></a>デスクトップ アプリケーションのインサイト データの取得

Insights データを取得するには、Microsoft Store analytics API では、このメソッドに関連する正常性メトリックを追加したデスクトップ アプリケーションを使用して、 [Windows デスクトップ アプリケーション プログラム](https://docs.microsoft.com/windows/desktop/appxpkg/windows-desktop-application-program)します。 このデータも記載されて、[正常性レポート](https://docs.microsoft.com/windows/desktop/appxpkg/windows-desktop-application-program#health-report)パートナー センターでのデスクトップ アプリケーションです。

## <a name="prerequisites"></a>前提条件

このメソッドを使うには、最初に次の作業を行う必要があります。

* Microsoft Store 分析 API に関するすべての[前提条件](access-analytics-data-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。
* このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら新しいトークンを取得できます。

## <a name="request"></a>要求


### <a name="request-syntax"></a>要求の構文

| メソッド | 要求 URI       |
|--------|----------------------|
| GET    | ```https://manage.devcenter.microsoft.com/v1.0/my/analytics/desktop/insights``` |


### <a name="request-header"></a>要求ヘッダー

| Header        | 種類   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| Authorization | string | 必須。 **Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。 |


### <a name="request-parameters"></a>要求パラメーター

| パラメーター        | 種類   |  説明      |  必須  
|---------------|--------|---------------|------|
| applicationId | string | Insights のデータを取得するデスクトップ アプリケーションの製品の ID。 デスクトップ アプリケーションの製品 ID を取得するには、いずれかを開く[analytics は、パートナー センターでデスクトップ アプリケーションのレポート](https://msdn.microsoft.com/library/windows/desktop/mt826504)(など、**正常性レポート**) し、URL から、製品 ID を取得します。 このパラメーターを指定しないと、応答本文は、自分のアカウントに登録されているすべてのアプリの insights のデータが含まれます。  |  X  |
| startDate | date | 取得する insights データの日付範囲の開始日。 既定値は、現在の日付の 30 日前です。 |  X  |
| endDate | date | 取得する insights データの日付範囲の終了日。 既定値は現在の日付です。 |  いいえ  |
| filter | string  | 応答内の行をフィルター処理する 1 つまたは複数のステートメントです。 各ステートメントには、応答本文からのフィールド名、および **eq** 演算子または **ne** 演算子と関連付けられる値が含まれており、**and** や **or** を使用してステートメントを組み合わせることができます。 *filter* パラメーターでは、文字列値を単一引用符で囲む必要があります。 たとえば、*フィルター = データ型 eq '買収'* します。 <p/><p/>現在このメソッドは、フィルターのみをサポート**ヘルス**します。  | いいえ   |

### <a name="request-example"></a>要求の例

次の例では、insights データを取得するための要求を示します。 置換、 *applicationId*デスクトップ アプリケーションの適切な値を持つ値。

```syntax
GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/desktop/insights?applicationId=10238467886765136388&startDate=6/1/2018&endDate=6/15/2018&filter=dataType eq 'health' HTTP/1.1
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
| applicationId       | string | Insights のデータを取得し、デスクトップ アプリケーションの製品の ID。     |
| insightDate                | string | 日付が特定のメトリックの変化を特定しました。 この日付は、大幅な増加を検出しました週の終わりを表すと比較する前に、その週とメトリックに増減します。 |
| データ型     | string | この情報に通知する一般的な分析の領域を指定する文字列。 現時点では、このメソッドは**ヘルス**します。    |
| insightDetail          | array | 1 つまたは複数[InsightDetail 値](#insightdetail-values)現在インサイトの詳細を表します。    |


### <a name="insightdetail-values"></a>InsightDetail 値

| Value               | 種類   | 説明                           |
|---------------------|--------|-------------------------------------------|
| FactName           | string | 現在 insight または現在のディメンションについて説明するメトリックを示す文字列。 現時点では、このメソッドは、値のみをサポート**ヒット カウント**します。  |
| SubDimensions         | array |  情報を得ることの 1 つのメトリックを記述する 1 つまたは複数のオブジェクト。   |
| PercentChange            | string |  この割合は、全体の顧客ベースでメトリックを変更しました。  |
| DimensionName           | string |  現在のディメンションで説明されているメトリックの名前。 例としては、 **EventType**、**市場**、 **DeviceType**、および**PackageVersion**します。   |
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

* [Windows デスクトップ アプリケーション プログラム](https://docs.microsoft.com/windows/desktop/appxpkg/windows-desktop-application-program)
* [正常性レポート](https://docs.microsoft.com/windows/desktop/appxpkg/windows-desktop-application-program#health-report)
* [Microsoft Store サービスを使用して分析データにアクセス](access-analytics-data-using-windows-store-services.md)
