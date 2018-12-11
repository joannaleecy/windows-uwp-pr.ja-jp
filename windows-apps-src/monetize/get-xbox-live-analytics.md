---
description: Xbox Live の分析データを取得するには、Microsoft Store 分析 API の以下のメソッドを使います。
title: Xbox Live の分析データの取得
ms.date: 06/04/2018
ms.topic: article
keywords: Windows 10, UWP, Store サービス, Microsoft Store 分析 API, Xbox Live 分析
ms.localizationpriority: medium
ms.openlocfilehash: 74c898630641e8b0d53a181d1874c6df62baaa78
ms.sourcegitcommit: 231065c899d0de285584d41e6335251e0c2c4048
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/10/2018
ms.locfileid: "8826104"
---
# <a name="get-xbox-live-analytics-data"></a>Xbox Live の分析データの取得

[Xbox Live 対応ゲーム](../xbox-live/index.md)をプレイしているユーザーに関する過去 30 日間の一般的な分析データを取得するには、Microsoft Store 分析 API の次のメソッドを使います。取得できるデータには、デバイス アクセサリの使用状況、インターネット接続の種類、ゲーマースコアの分布、ゲームの統計情報、フレンドとフォロワーのデータが含まれます。 この情報は、パートナー センターで[Xbox 分析レポート](../publish/xbox-analytics-report.md)で利用可能なもできます。

> [!IMPORTANT]
> このメソッドは、Xbox のゲームまたは Xbox Live サービスを使用するゲームのみサポートします。 これらのゲームは、[概念の承認プロセス](../gaming/concept-approval.md)を完了する必要があります。これには、[Microsoft パートナー](../xbox-live/developer-program-overview.md#microsoft-partners)が発行したゲームと [ID@Xbox プログラム](../xbox-live/developer-program-overview.md#id)を介して申請されたゲームが含まれます。 このメソッドでは、[Xbox Live クリエーターズ プログラム](../xbox-live/get-started-with-creators/get-started-with-xbox-live-creators.md)を介して発行されたゲームは現在サポートされていません。

Xbox Live 対応ゲームに関するその他の分析データは、次のメソッドを通じて取得できます。
* [Xbox Live の実績データの取得](get-xbox-live-achievements-data.md)
* [Xbox Live の正常性データの取得](get-xbox-live-health-data.md)
* [Xbox Live ゲーム ハブのデータの取得](get-xbox-live-game-hub-data.md)
* [Xbox Live クラブのデータの取得](get-xbox-live-club-data.md)
* [Xbox Live のマルチプレイヤー データの取得](get-xbox-live-multiplayer-data.md)
* [Xbox Live の同時使用状況データの取得](get-xbox-live-concurrent-usage-data.md)

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
| applicationId | string | Xbox Live の分析データを取得するゲームの [Store ID](in-app-purchases-and-trials.md#store-ids) です。  |  必須  |
| metricType | string | 取得する Xbox Live 分析データの種類を指定する文字列です。 このメソッドでは、値 **productvalues** を指定します。  |  必須  |


### <a name="request-example"></a>要求の例

次の例では、Xbox Live 対応ゲームをプレイしているユーザーに関する一般的な分析データを取得する要求を示します。 *applicationId* の値は、ゲームの Store ID に置き換えてください。

```syntax
GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/gameanalytics?applicationId=9NBLGGGZ5QDR&metrictype=productvalues HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a>応答

このメソッドは、次のオブジェクトを含む *Value* 配列を返します。

| オブジェクト      | 説明                  |
|-------------|---------------------------------------------------|
| ProductData   |   1 つの [DeviceProperties](#deviceproperties) オブジェクトと 1 つの [UserProperties](#userproperties) オブジェクトが含まれます。それぞれには、対象ゲームに関する過去 30 日間のデバイス分析データとユーザー分析データが格納されます。    |  
| XboxwideData   |  1 つの [DeviceProperties](#deviceproperties) オブジェクトと 1 つの [UserProperties](#userproperties) オブジェクトが含まれます。それぞれには、すべての Xbox Live ユーザーを対象とした過去 30 日間の平均的なデバイス分析データとユーザー分析データが、パーセンテージとして格納されます。 このデータは、対象ゲームのデータとの比較のために用意されています。   |                                           


### <a name="deviceproperties"></a>DeviceProperties

このリソースには、過去 30 日間について、対象ゲームに関するデバイス使用状況データ、またはすべての Xbox Live ユーザーを対象とした平均的なデバイス使用状況データが格納されます。

| 値           | 型    | 説明        |
|-----------------|---------|------|
|  applicationId               |    string     |  分析データを取得したゲームの [Store ID](in-app-purchases-and-trials.md#store-ids) です。   |
|  connectionTypeDistribution               |    array     |   Xbox でワイヤード (有線) インターネット接続とワイヤレス インターネット接続を使っているユーザーの数を示すオブジェクトが含まれます。 各オブジェクトには、次の 2 つの文字列フィールドがあります。 <ul><li>**conType**: 接続の種類を指定します。</li><li>**deviceCount**: **ProductData** オブジェクトの場合、このフィールドは、対象ゲームのユーザーのうち、指定の接続の種類を使っているユーザーの数を示します。 **XboxwideData** オブジェクトの場合、このフィールドは、すべての Xbox Live ユーザーのうち、指定の接続の種類を使っているユーザーの割合を示します。</li></ul>   |     
|  deviceCount               |   string      |  **ProductData** オブジェクトの場合、このフィールドは、過去 30 日間に対象ゲームがプレイされたユーザー デバイスの数を示します。 **XboxwideData** オブジェクトの場合、このフィールドは常に 1 になり、すべての Xbox Live ユーザーを対象としたデータの開始パーセンテージである 100% を示します。   |     
|  eliteControllerPresentDeviceCount               |   string      |  **ProductData** オブジェクトの場合、このフィールドは、対象ゲームのユーザーのうち、Xbox Elite ワイヤレス コントローラーを使っているユーザーの数を示します。 **XboxwideData** オブジェクトの場合、このフィールドは、すべての Xbox Live ユーザーのうち、Xbox Elite ワイヤレス コントローラーを使っているユーザーの割合を示します。  |     
|  externalDrivePresentDeviceCount               |   string      |  **ProductData** オブジェクトの場合、このフィールドは、対象ゲームのユーザーのうち、Xbox で外部ハード ドライブを使っているユーザーの数を示します。 **XboxwideData** オブジェクトの場合、このフィールドは、すべての Xbox Live ユーザーのうち、Xbox で外部ハード ドライブを使っているユーザーの割合を示します。  |


### <a name="userproperties"></a>UserProperties

このリソースには、過去 30 日間について、対象ゲームに関するユーザー データ、またはすべての Xbox Live ユーザーを対象とした平均的なユーザー データが格納されます。

| 値           | 型    | 説明        |
|-----------------|---------|------|
|  applicationId               |    string     |   分析データを取得したゲームの [Store ID](in-app-purchases-and-trials.md#store-ids) です。  |
|  userCount               |    string     |   **ProductData** オブジェクトの場合、このフィールドは、過去 30 日間に対象ゲームをプレイしたユーザーの数を示します。 **XboxwideData** オブジェクトの場合、このフィールドは常に 1 になり、すべての Xbox Live ユーザーを対象としたデータの開始パーセンテージである 100% を示します。   |     
|  dvrUsageCounts               |   array      |  ゲーム録画を使ってゲームプレイを録画および表示したユーザーの数を示すオブジェクトが含まれます。 各オブジェクトには、次の 2 つの文字列フィールドがあります。 <ul><li>**dvrName**: 使用されたゲーム録画機能を指定します。 取り得る値は、**gameClipUploads**、**gameClipViews**、**screenshotUploads**、**screenshotViews** です。</li><li>**userCount**: **ProductData** オブジェクトの場合、このフィールドは、対象ゲームのユーザーのうち、指定のゲーム録画機能を使用したユーザーの数を示します。 **XboxwideData** オブジェクトの場合、このフィールドは、すべての Xbox Live ユーザーのうち、指定のゲーム録画機能を使用したユーザーの割合を示します。</li></ul>   |     
|  followerCountPercentiles               |   array      |  ユーザーのフォロワー数に関する詳細を提供するオブジェクトが含まれます。 各オブジェクトには、次の 2 つの文字列フィールドがあります。 <ul><li>**percentage**: 現在、この値は常に 50 になり、フォロワー データが中央値として提供されることを示します。</li><li>**value**: **ProductData** オブジェクトの場合、このフィールドは、対象ゲームのユーザーのフォロワー数の中央値を示します。 **XboxwideData** オブジェクトの場合、このフィールドは、すべての Xbox Live ユーザーのフォロワー数の中央値を示します。</li></ul>  |   
|  friendCountPercentiles               |   array      |  ユーザーのフレンド数に関する詳細を提供するオブジェクトが含まれます。 各オブジェクトには、次の 2 つの文字列フィールドがあります。 <ul><li>**percentage**: 現在、この値は常に 50 になり、フレンド データが中央値として提供されることを示します。</li><li>**value**: **ProductData** オブジェクトの場合、このフィールドは、対象ゲームのユーザーのフレンド数の中央値を示します。 **XboxwideData** オブジェクトの場合、このフィールドは、すべての Xbox Live ユーザーのフレンド数の中央値を示します。</li></ul>  |     
|  gamerScoreRangeDistribution               |   array      |  ユーザーのゲーマースコアの分布に関する詳細を提供するオブジェクトが含まれます。 各オブジェクトには、次の 2 つの文字列フィールドがあります。 <ul><li>**scoreRange**: 次のフィールドで使用状況データが提供されるゲーマースコアの範囲です。 たとえば、**10K-25K** のように指定されます。</li><li>**userCount**: **ProductData** オブジェクトの場合、このフィールドは、対象ゲームのユーザーのうち、プレイしたすべてのゲームに対するゲーマースコアが指定範囲に含まれているユーザーの数を示します。 **XboxwideData** オブジェクトの場合、このフィールドは、すべての Xbox Live ユーザーのうち、プレイしたすべてのゲームに対するゲーマースコアが指定範囲に含まれているユーザーの割合を示します。</li></ul>  |
|  titleGamerScoreRangeDistribution               |   array      |  対象ゲームのゲーマースコアの分布に関する詳細を提供するオブジェクトが含まれます。 各オブジェクトには、次の 2 つの文字列フィールドがあります。 <ul><li>**scoreRange**: 次のフィールドで使用状況データが提供されるゲーマースコアの範囲です。 たとえば、**100-200** のように指定されます。</li><li>**userCount**: **ProductData** オブジェクトの場合、このフィールドは、対象ゲームのユーザーのうち、対象ゲームのゲーマースコアが指定範囲に含まれているユーザーの数を示します。 **XboxwideData** オブジェクトの場合、このフィールドは、すべての Xbox Live ユーザーのうち、対象ゲームのゲーマースコアが指定範囲に含まれているユーザーの割合を示します。</li></ul>   |
|  socialUsageCounts               |   array      |  ユーザーのソーシャル利用状況に関する詳細を提供するオブジェクトが含まれます。 各オブジェクトには、次の 2 つの文字列フィールドがあります。 <ul><li>**scName**: ソーシャル利用状況の種類です。 たとえば、**gameInvites** や **textMessages** のように指定されます。</li><li>**userCount**: **ProductData** オブジェクトの場合、このフィールドは、対象ゲームのユーザーのうち、指定の種類のソーシャル利用状況に含まれるユーザーの数を示します。 **XboxwideData** オブジェクトの場合、このフィールドは、すべての Xbox Live ユーザーのうち、指定の種類のソーシャル利用状況に含まれるユーザーの割合を示します。</li></ul>   |
|  streamingUsageCounts               |   array      |  ユーザーのストリーミング利用状況に関する詳細を提供するオブジェクトが含まれます。 各オブジェクトには、次の 2 つの文字列フィールドがあります。 <ul><li>**stName**: ストリーミング プラットフォームの種類です。 たとえば、**youtubeUsage**、**twitchUsage**、**mixerUsage** のように指定されます。</li><li>**userCount**: **ProductData** オブジェクトの場合、このフィールドは、対象ゲームのユーザーのうち、指定のストリーミング プラットフォームを使用したユーザーの数を示します。 **XboxwideData** オブジェクトの場合、このフィールドは、すべての Xbox Live ユーザーのうち、指定のストリーミング プラットフォームを使用したユーザーの割合を示します。</li></ul>  |


### <a name="response-example"></a>応答の例

この要求の JSON 応答の本文の例を次に示します。

```json
{
  "Value": [
    {
      "ProductData": {
        "DeviceProperties": [
          {
            "applicationId": "9NBLGGGZ5QDR",
            "connectionTypeDistribution": [
              {
                "conType": "WIRED",
                "deviceCount": "43806"
              },
              {
                "conType": "WIRELESS",
                "deviceCount": "104035"
              }
            ],
            "deviceCount": "148063",
            "eliteControllerPresentDeviceCount": "10615",
            "externalDrivePresentDeviceCount": "46388"
          }
        ],
        "UserProperties": [
          {
            "applicationId": "9NBLGGGZ5QDR",
            "userCount": "142345",
            "dvrUsageCounts": [
              {
                "dvrName": "gameClipUploads",
                "userCount": "31264"
              },
              {
                "dvrName": "gameClipViews",
                "userCount": "52236"
              },
              {
                "dvrName": "screenshotUploads",
                "userCount": "27051"
              },
              {
                "dvrName": "screenshotViews",
                "userCount": "45640"
              }
            ],
            "followerCountPercentiles": [
              {
                "percentage": "50",
                "value": "11"
              }
            ],
            "friendCountPercentiles": [
              {
                "percentage": "50",
                "value": "11"
              }
            ],
            "gamerScoreRangeDistribution": [
              {
                "scoreRange": "10K-25K",
                "userCount": "30015"
              },
              {
                "scoreRange": "25K-50K",
                "userCount": "20495"
              },
              {
                "scoreRange": "3K-10K",
                "userCount": "32438"
              },
              {
                "scoreRange": "50K-100K",
                "userCount": "10608"
              },
              {
                "scoreRange": "<3K",
                "userCount": "45726"
              },
              {
                "scoreRange": ">100K",
                "userCount": "3063"
              }
            ],
            "titleGamerScoreRangeDistribution": [
              {
                "scoreRange": "400-600",
                "userCount": "133875"
              },
              {
                "scoreRange": "800-1000",
                "userCount": "45960"
              },
              {
                "scoreRange": "<100",
                "userCount": "269137"
              },
              {
                "scoreRange": "≥1K",
                "userCount": "11634"
              },
              {
                "scoreRange": "100-200",
                "userCount": "334471"
              },
              {
                "scoreRange": "600-800",
                "userCount": "123044"
              },
              {
                "scoreRange": "200-400",
                "userCount": "396725"
              }
            ],
            "socialUsageCounts": [
              {
                "scName": "gameInvites",
                "userCount": "82390"
              },
              {
                "scName": "textMessages",
                "userCount": "91880"
              },
              {
                "scName": "partySessionCount",
                "userCount": "68129"
              }
            ],
            "streamingUsageCounts": [
              {
                "stName": "youtubeUsage",
                "userCount": "74092"
              },
              {
                "stName": "twitchUsage",
                "userCount": "13401"
              }
              {
                "stName": "mixerUsage",
                "userCount": "22907"
              }
            ]
          }
        ]
      },
      "XboxwideData": {
        "DeviceProperties": [
          {
            "applicationId": "XBOXWIDE",
            "connectionTypeDistribution": [
              {
                "conType": "WIRED",
                "deviceCount": "0.213677732584786"
              },
              {
                "conType": "WIRELESS",
                "deviceCount": "0.786322267415214"
              }
            ],
            "deviceCount": "1",
            "eliteControllerPresentDeviceCount": "0.0476609278128012",
            "externalDrivePresentDeviceCount": "0.173747147416134"
          }
        ],
        "UserProperties": [
          {
            "applicationId": "XBOXWIDE",
            "userCount": "1",
            "dvrUsageCounts": [
              {
                "dvrName": "gameClipUploads",
                "userCount": "0.173210623993245"
              },
              {
                "dvrName": "gameClipViews",
                "userCount": "0.202104713778096"
              },
              {
                "dvrName": "screenshotUploads",
                "userCount": "0.136682414274251"
              },
              {
                "dvrName": "screenshotViews",
                "userCount": "0.158057895120314"
              }
            ],
            "followerCountPercentiles": [
              {
                "percentage": "50",
                "value": "5"
              }
            ],
            "friendCountPercentiles": [
              {
                "percentage": "50",
                "value": "5"
              }
            ],
            "gamerScoreRangeDistribution": [
              {
                "scoreRange": "10K-25K",
                "userCount": "0.134709282586519"
              },
              {
                "scoreRange": "25K-50K",
                "userCount": "0.0549468789343825"
              },
              {
                "scoreRange": "50K-100K",
                "userCount": "0.017301313342277"
              },
              {
                "scoreRange": "3K-10K",
                "userCount": "0.216512780268453"
              },
              {
                "scoreRange": "<3K",
                "userCount": "0.573515440094644"
              },
              {
                "scoreRange": ">100K",
                "userCount": "0.00301430477372488"
              }
            ],
            "titleGamerScoreRangeDistribution": [
              {
                "scoreRange": "100-200",
                "userCount": "0.178055695637076"
              },
              {
                "scoreRange": "200-400",
                "userCount": "0.173283639825241"
              },
              {
                "scoreRange": "400-600",
                "userCount": "0.0986865193958259"
              },
              {
                "scoreRange": "600-800",
                "userCount": "0.0506375775462092"
              },
              {
                "scoreRange": "800-1000",
                "userCount": "0.0232398822856435"
              },
              {
                "scoreRange": "<100",
                "userCount": "0.456443551582991"
              },
              {
                "scoreRange": "≥1K",
                "userCount": "0.0196531337270126"
              }
            ],
            "socialUsageCounts": [
              {
                "scName": "gameInvites",
                "userCount": "0.460375855738335"
              },
              {
                "scName": "textMessages",
                "userCount": "0.429256324070832"
              },
              {
                "scName": "partySessionCount",
                "userCount": "0.378446577751268"
              },
              {
                "scName": "gamehubViews",
                "userCount": "0.000197115778147329"
              }
            ],
            "streamingUsageCounts": [
              {
                "stName": "youtubeUsage",
                "userCount": "0.330320919178683"
              },
              {
                "stName": "twitchUsage",
                "userCount": "0.040666241835399"
              }
              {
                "stName": "mixerUsage",
                "userCount": "0.140193816053558"
              }
            ]
          }
        ]
      }
    }
  ],
  "@nextLink": null,
  "TotalCount": 4
}
```

## <a name="related-topics"></a>関連トピック

* [Microsoft Store サービスを使った分析データへのアクセス](access-analytics-data-using-windows-store-services.md)
* [Xbox Live の実績データの取得](get-xbox-live-achievements-data.md)
* [Xbox Live の正常性データの取得](get-xbox-live-health-data.md)
* [Xbox Live ゲーム ハブのデータの取得](get-xbox-live-game-hub-data.md)
* [Xbox Live クラブのデータの取得](get-xbox-live-club-data.md)
* [Xbox Live のマルチプレイヤー データの取得](get-xbox-live-multiplayer-data.md)
* [Xbox Live の同時使用状況データの取得](get-xbox-live-concurrent-usage-data.md)
