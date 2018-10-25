---
author: Xansky
description: Xbox Live クラブのデータを取得するには、Microsoft Store 分析 API の以下のメソッドを使います。
title: Xbox Live クラブのデータの取得
ms.author: mhopkins
ms.date: 06/04/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, Store サービス, Microsoft Store 分析 API, Xbox Live 分析, クラブ
ms.localizationpriority: medium
ms.openlocfilehash: f9f901ce5a91443321f7cc5b182a5ea64279dbfb
ms.sourcegitcommit: 2c4daa36fb9fd3e8daa83c2bd0825f3989d24be8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/25/2018
ms.locfileid: "5519153"
---
# <a name="get-xbox-live-club-data"></a>Xbox Live クラブのデータの取得

[Xbox Live 対応ゲーム](../xbox-live/index.md)のクラブ データを取得するには、Microsoft Store 分析 API の以下のメソッドを使います。 この情報は、Windows デベロッパー センター ダッシュボードの [Xbox 分析レポート](../publish/xbox-analytics-report.md)でも確認できます。

> [!IMPORTANT]
> このメソッドは、Xbox のゲームまたは Xbox Live サービスを使用するゲームのみサポートします。 これらのゲームは、[概念の承認プロセス](../gaming/concept-approval.md)を完了する必要があります。これには、[Microsoft パートナー](../xbox-live/developer-program-overview.md#microsoft-partners)が発行したゲームと [ID@Xbox プログラム](../xbox-live/developer-program-overview.md#id)を介して申請されたゲームが含まれます。 このメソッドでは、[Xbox Live クリエーターズ プログラム](../xbox-live/get-started-with-creators/get-started-with-xbox-live-creators.md)を介して発行されたゲームは現在サポートされていません。

## <a name="prerequisites"></a>前提条件

このメソッドを使うには、最初に次の作業を行う必要があります。

* Microsoft Store 分析 API に関するすべての[前提条件](access-analytics-data-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。
* このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら、新しいトークンを取得できます。

## <a name="request"></a>要求


### <a name="request-syntax"></a>要求の構文

| メソッド | 要求 URI       |
|--------|----------------------|
| GET    | ```https://manage.devcenter.microsoft.com/v1.0/my/analytics/gameanalytics``` |


### <a name="request-header"></a>要求ヘッダー

| ヘッダー        | 型   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| Authorization | string | 必須。 **Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。 |


### <a name="request-parameters"></a>要求パラメーター


| パラメーター        | 型   |  説明      |  必須かどうか  
|---------------|--------|---------------|------|
| applicationId | string | Xbox Live クラブのデータを取得するゲームの [Store ID](in-app-purchases-and-trials.md#store-ids) です。  |  必須  |
| metricType | string | 取得する Xbox Live 分析データの種類を指定する文字列です。 このメソッドでは、値 **communitymanagerclub** を指定します。  |  必須  |
| startDate | date | 取得するクラブ データの日付範囲の開始日です。 既定値は、現在の日付の 30 日前です。 |  必須ではない  |
| endDate | date | 取得するクラブ データの日付範囲の終了日です。 既定値は現在の日付です。 |  必須ではない  |
| top | int | 要求で返すデータの行数です。 指定されない場合の既定値は、最大値でもある 10000 です。 クエリにこれを上回る行がある場合は、応答本文に次リンクが含まれ、そのリンクを使ってデータの次のページを要求できます。 |  必須ではない  |
| skip | int | クエリでスキップする行数です。 大きなデータ セットを操作するには、このパラメーターを使用します。 たとえば、top=10000 と skip=0 を指定すると、データの最初の 10,000 行が取得され、top=10000 と skip=10000 を指定すると、データの次の 10,000 行が取得されます。 |  必須ではない  |


### <a name="request-example"></a>要求の例

次の例では、Xbox Live 対応ゲームのクラブ データを取得する要求を示します。 *applicationId* の値は、ゲームの Store ID に置き換えてください。

```syntax
GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/gameanalytics?applicationId=9NBLGGGZ5QDR&metrictype=communitymanagerclub&top=10&skip=0 HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a>応答

| 値      | 型   | 説明                  |
|------------|--------|-------------------------------------------------------|
| Value      | array  | 対象ゲームに関連するクラブのデータを含む 1 つの [ProductData](#productdata) オブジェクトと、すべての Xbox Live ユーザーに関するクラブ データを含む 1 つの [XboxwideData](#xboxwidedata) オブジェクトを格納する配列です。 このデータは、対象ゲームのデータとの比較のために用意されています。  |
| @nextLink  | string | データの追加ページがある場合、この文字列には、データの次のページを要求するために使用できる URI が含まれます。 たとえば、要求の **top** パラメーターが 10000 に設定されていたとき、クエリに対して 10000 行を超えるデータが一致すると、この値が返されます。 |
| TotalCount | int    | クエリの結果データ内の行の総数です。 |


### <a name="productdata"></a>ProductData

このリソースには、対象ゲームのクラブ データが含まれます。

| 値           | 型    | 説明        |
|-----------------|---------|------|
| date            |  string |   クラブ データの日付です。   |
|  applicationId               |    string     |  クラブ データを取得したゲームの [Store ID](in-app-purchases-and-trials.md#store-ids) です。   |
|  clubsWithTitleActivity               |    int     |  対象ゲームにソーシャルに関与しているクラブの数です。   |     
|  clubsExclusiveToGame               |   int      |  対象ゲームだけにソーシャルに関与しているクラブの数です。   |     
|  clubFacts               |   array      |   対象ゲームにソーシャルに関与している各クラブの情報を格納する [ClubFacts](#clubfacts) オブジェクトが 1 つ以上含まれます。   |


### <a name="xboxwidedata"></a>XboxwideData

このリソースには、すべての Xbox Live ユーザーを対象とした平均的なクラブ データが含まれます。

| 値           | 型    | 説明        |
|-----------------|---------|------|
| date            |  string |   クラブ データの日付です。   |
|  applicationId  |    string     |   **XboxwideData** オブジェクトの場合、この文字列は常に値 **XBOXWIDE** になります。  |
|  clubsWithTitleActivity               |   int     |  Xbox Live 対応ゲームにソーシャルに関与しているユーザーのいるクラブの平均数です。    |     
|  clubsExclusiveToGame               |   int      |  1 つの Xbox Live 対応ゲームだけにソーシャルに関与しているクラブの平均数です。   |     
|  clubFacts               |   object      |  1 つの [ClubFacts](#clubfacts) オブジェクトが含まれます。 このオブジェクトは、**XboxwideData** オブジェクトのコンテキストでは意味を持たず、既定値が設定されます。  |


### <a name="clubfacts"></a>ClubFacts

**ProductData** オブジェクトの場合、このオブジェクトには、対象ゲームに関連するアクティビティのある特定のクラブのデータが含まれます。 **XboxwideData** オブジェクトの場合、このオブジェクトは意味を持たず、既定値が含まれます。

| 値           | 型    | 説明        |
|-----------------|---------|--------------------|
|  name            |  string  |   **ProductData** オブジェクトの場合、これはクラブの名前です。 **XboxwideData** オブジェクトの場合、これは常に値 **XBOXWIDE** になります。           |
|  memberCount               |    int     | **ProductData** オブジェクトの場合、これはクラブ内のメンバーの数です。クラブを参照しただけの非メンバーは除外されます。 **XboxwideData** オブジェクトの場合、これは常に 0 になります。    |
|  titleSocialActionsCount               |    int     |  **ProductData** オブジェクトの場合、これはクラブ内のメンバーが実行した、対象ゲームに関連するソーシャル活動の数です。 **XboxwideData** オブジェクトの場合、これは常に 0 になります。   |
|  isExclusiveToGame               |    Boolean     |  **ProductData** オブジェクトの場合、これは現在のクラブが対象ゲームにソーシャルに関与しているかどうかを示します。 **XboxwideData** オブジェクトの場合、これは常に true になります。  |


### <a name="response-example"></a>応答の例

この要求の JSON 応答の本文の例を次に示します。

```json
{
  "Value": [
    {
      "ProductData": [
        {
          "date": "2018-01-30",
          "applicationId": "9NBLGGGZ5QDR",
          "clubsWithTitleActivity": 3,
          "clubsExclusiveToGame": 1,
          "clubFacts": [
            {
              "name": "Club Contoso Racing",
              "memberCount": 1,
              "titleSocialActionsCount": 1,
              "isExclusiveToGame": false
            },
            {
              "name": "Club Contoso Sports",
              "memberCount": 12,
              "titleSocialActionsCount": 9,
              "isExclusiveToGame": false
            },
            {
              "name": "Club Contoso Maze",
              "memberCount": 4,
              "titleSocialActionsCount": 2,
              "isExclusiveToGame": false
            }
          ]
        }
      ],
      "XboxwideData": [
        {
          "date": "2018-01-30",
          "applicationId": "XBOXWIDE",
          "clubsWithTitleActivity": 25,
          "clubsExclusiveToGame": 3,
          "clubFacts": [
            {
              "name": "XBOXWIDE",
              "memberCount": 0,
              "titleSocialActionsCount": 0,
              "isExclusiveToGame": true
            }
          ]
        }
      ]
    }
  ],
  "@nextLink": "gameanalytics?applicationId=9NBLGGGZ5QDR&metricType=communitymanagerclub&top=1&skip=1&startDate=2018/01/04&endDate=2018/02/02&orderby=date desc",
  "TotalCount": 27
}
```

## <a name="related-topics"></a>関連トピック

* [Microsoft Store サービスを使った分析データへのアクセス](access-analytics-data-using-windows-store-services.md)
* [Xbox Live の分析データの取得](get-xbox-live-analytics.md)
* [Xbox Live の実績データの取得](get-xbox-live-achievements-data.md)
* [Xbox Live の正常性データの取得](get-xbox-live-health-data.md)
* [Xbox Live ゲーム ハブのデータの取得](get-xbox-live-game-hub-data.md)
* [Xbox Live のマルチプレイヤー データの取得](get-xbox-live-multiplayer-data.md)
