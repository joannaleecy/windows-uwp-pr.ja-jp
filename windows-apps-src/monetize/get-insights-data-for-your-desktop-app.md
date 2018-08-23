---
author: mcleanbyron
description: Microsoft ストア分析 API でこのメソッドを使用すると、デスクトップ アプリケーションのデータの分析結果を取得します。
title: デスクトップ アプリケーションのデータの分析結果を取得します。
ms.author: mcleans
ms.date: 07/31/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10、uwp、ストア サービス、Microsoft ストア分析 API、分析結果
ms.localizationpriority: medium
ms.openlocfilehash: e7ca6eed40af37276b5b4c98ec7b1b709bdadfb9
ms.sourcegitcommit: 9c79fdab9039ff592edf7984732d300a14e81d92
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/23/2018
ms.locfileid: "2820121"
---
# <a name="get-insights-data-for-your-desktop-application"></a>デスクトップ アプリケーションのデータの分析結果を取得します。

[Windows デスクトップ アプリケーション](https://docs.microsoft.com/windows/desktop/appxpkg/windows-desktop-application-program)に追加したデスクトップ アプリケーションの正常性指標に関連するデータの分析結果を取得するには、Microsoft ストア分析 API このメソッドを使います。 このデータも Windows デベロッパー センターのダッシュ ボードでのデスクトップ アプリケーションの[正常性レポート](https://docs.microsoft.com/windows/desktop/appxpkg/windows-desktop-application-program#health-report)で使用できます。

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
| applicationId | string | データの分析結果を取得するデスクトップ アプリケーションのプロダクト ID。 デスクトップ アプリケーションの製品 ID を取得するには、[デベロッパー センターでデスクトップ アプリケーションの分析レポート](https://msdn.microsoft.com/library/windows/desktop/mt826504)のいずれか (**正常性レポート**など) を開き、URL から製品 ID を取得します。 このパラメーターを指定しないと、応答本文が自分のアカウントに登録されているすべてのアプリのデータ分析にはが含まれます。  |  必須ではない  |
| startDate | date | 日付範囲内のデータの分析結果を取得する開始日です。 既定値は、現在の日付の 30 日前です。 |  必須ではない  |
| endDate | date | 日付範囲内のデータの分析結果を取得する終了日です。 既定値は現在の日付です。 |  必須ではない  |
| filter | string  | 応答内の行をフィルター処理する 1 つまたは複数のステートメントです。 各ステートメントには、応答本文からのフィールド名、および **eq** 演算子または **ne** 演算子と関連付けられる値が含まれており、**and** や **or** を使用してステートメントを組み合わせることができます。 *filter* パラメーターでは、文字列値を単一引用符で囲む必要があります。 たとえば、*フィルター = データ型 eq '取得'* します。 <p/><p/>現在この方法は、フィルター処理**の正常性**のみをサポートします。  | いいえ   |

### <a name="request-example"></a>要求の例

次の例では、データの分析結果を取得するための出席依頼を示します。 デスクトップ アプリケーションの適切な値を持つ*付きアプリケーション Id*の値を置き換えます。

```syntax
GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/desktop/insights?applicationId=10238467886765136388&startDate=6/1/2018&endDate=6/15/2018&filter=dataType eq 'health' HTTP/1.1
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
| applicationId       | string | データの分析結果を取得するデスクトップ アプリケーションのプロダクト ID。     |
| insightDate                | string | 特定のメトリックの変更わかりました日。 この日付は、大幅に増加が検出されたことを週の最後を表す前に、その曜日と比較してメトリックの増減します。 |
| データ型     | string | この情報を通知する一般的な分析領域を指定する文字列。 現在、この方法は、**正常性**をのみをサポートします。    |
| insightDetail          | array | 1 つまたは複数の[InsightDetail 値](#insightdetail-values)を現在の情報の詳細を表します。    |


### <a name="insightdetail-values"></a>InsightDetail 値

| 値               | 型   | 説明                           |
|---------------------|--------|-------------------------------------------|
| FactName           | string | 現在の理解または現在のディメンションについて説明するメトリックを示す文字列。 現在、この方法は、**ヒット カウント**] の値のみをサポートします。  |
| SubDimensions         | array |  情報を得ることの 1 つの指標を説明する 1 つまたは複数のオブジェクト   |
| PercentChange            | string |  全体の顧客ベースにわたって、メートル法が変更された割合です。  |
| DimensionName           | string |  現在のディメンションで説明するメトリックの名前。 **イベントの種類**、**市場**、 **DeviceType**、および**PackageVersion**例が含まれます。   |
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

* [Windows デスクトップ アプリケーション](https://docs.microsoft.com/windows/desktop/appxpkg/windows-desktop-application-program)
* [状態レポート](https://docs.microsoft.com/windows/desktop/appxpkg/windows-desktop-application-program#health-report)
* [Microsoft Store サービスを使った分析データへのアクセス](access-analytics-data-using-windows-store-services.md)
