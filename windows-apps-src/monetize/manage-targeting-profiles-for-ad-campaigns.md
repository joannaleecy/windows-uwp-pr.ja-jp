---
ms.assetid: d305746a-d370-4404-8cde-c85765bf3578
description: プロモーション用の広告キャンペーンのターゲット プロファイルを管理するには、Microsoft Store プロモーション API の以下のメソッドを使います。
title: ターゲット プロファイルの管理
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store プロモーション API, 広告キャンペーン
ms.localizationpriority: medium
ms.openlocfilehash: 0d84c6eb678bf884709e13ecefd81e64097ee738
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57630207"
---
# <a name="manage-targeting-profiles"></a>ターゲット プロファイルの管理


プロモーション用の広告キャンペーンの各配信ラインで対象とするユーザー、地域、インベントリの種類を選択するには、Microsoft Store プロモーション API の以下のメソッドを使います。 ターゲット プロファイルは、複数の配信ライン間で作成して再利用できます。

ターゲット プロファイルと広告キャンペーン、配信ライン、クリエイティブとの関係について詳しくは、「[Microsoft Store サービスを使用した広告キャンペーンの実行](run-ad-campaigns-using-windows-store-services.md#call-the-windows-store-promotions-api)」をご覧ください。

## <a name="prerequisites"></a>前提条件

これらのメソッドを使うには、最初に次の作業を行う必要があります。

* Microsoft Store プロモーション API に関するすべての[前提条件](run-ad-campaigns-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。
* これらのメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](run-ad-campaigns-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら新しいトークンを取得できます。

## <a name="request"></a>要求

これらのメソッドでは、次の URL が使用されます。

| メソッドの種類 | 要求 URI                                                      |  説明  |
|--------|------------------------------------------------------------------|---------------|
| POST   | ```https://manage.devcenter.microsoft.com/v1.0/my/promotion/targeting-profile``` |  新しいターゲット プロファイルを作成します。  |
| PUT    | ```https://manage.devcenter.microsoft.com/v1.0/my/promotion/targeting-profile/{targetingProfileId}``` |  *targetingProfileId* により指定されたターゲット プロファイルを編集します。  |
| GET    | ```https://manage.devcenter.microsoft.com/v1.0/my/promotion/targeting-profile/{targetingProfileId}``` |  *targetingProfileId* により指定されたターゲット プロファイルを取得します。  |


### <a name="header"></a>Header

| Header        | 種類   | 説明         |
|---------------|--------|---------------------|
| Authorization | string | 必須。 **Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。 |
| 追跡 ID   | GUID   | (省略可能)。 呼び出しフローを追跡する ID。                                  |


### <a name="request-body"></a>要求本文

POST メソッドと PUT メソッドには、[ターゲット プロファイル](#targeting-profile) オブジェクトの必須フィールドと設定または変更する追加フィールドを持つ JSON 要求本文が必要です。


### <a name="request-examples"></a>要求の例

次の例は、POST メソッドを呼び出してターゲット プロファイルを作成する方法を示しています。

```json
POST https://manage.devcenter.microsoft.com/v1.0/my/promotion/targeting-profile HTTP/1.1
Authorization: Bearer <your access token>

{
    "name": "Contoso App Campaign - Targeting Profile 1",
    "targetingType": "Manual",
    "age": [
      651,
      652],
    "gender": [
      700
    ],
    "country": [
      11,
      12
    ],
    "osVersion": [
      504
    ],
    "deviceType": [
      710
    ],
    "supplyType": [
      11470
    ]
}
```

次の例は、GET メソッドを呼び出してターゲット プロファイルを取得する方法を示しています。

```json
GET https://manage.devcenter.microsoft.com/v1.0/my/promotion/targeting-profile/310023951  HTTP/1.1
Authorization: Bearer <your access token>
```

<span/>

## <a name="response"></a>応答

これらのメソッドは、作成、更新、または取得されたターゲット プロファイルに関する情報を含む[ターゲット プロファイル](#targeting-profile) オブジェクトを持つ JSON 応答本文を返します。 これらのメソッドの応答本文を次の例に示します。

```json
{
  "Data": {
    "id": 310021746,
    "name": "Contoso App Campaign - Targeting Profile 1",
    "targetingType": "Manual",
    "age": [
      651,
      652
    ],
    "gender": [
      700
    ],
    "country": [
      6,
      13,
      29
    ],
    "osVersion": [
      504,
      505,
      506,
      507,
      508
    ],
    "deviceType": [
      710,
      711
    ],
    "supplyType": [
      11470
    ]
  }
}
```

<span id="targeting-profile"/>

## <a name="targeting-profile-object"></a>ターゲット プロファイル オブジェクト

これらのメソッドの要求本文と応答本文には、次のフィールドが含まれています。 この表は、読み取り専用のフィールド (つまり、PUT メソッドで変更できない) と POST メソッドの要求本文で必須のフィールドを示しています。

| フィールド        | 種類   |  説明      |  読み取り専用かどうか  | Default  | POST に必須かどうか |  
|--------------|--------|---------------|------|-------------|------------|
|  id   |  整数   |  ターゲット プロファイルの ID。     |   〇    |       |   X      |       
|  name   |  string   |   ターゲット プロファイルの名前。    |    X   |      |  〇     |       
|  targetingType   |  string   |  次のいずれかの値です。 <ul><li>**自動**:Microsoft パートナー センターでアプリの設定に基づいて対象とするプロファイルを選択することを許可するには、この値を指定します。</li><li>**手動**:独自のプロファイルのターゲットを定義するには、この値を指定します。</li></ul>     |  X     |  Auto    |   〇    |       
|  age   |  array   |   対象とするユーザーの年齢範囲を識別する 1 つ以上の整数です。 整数の詳しい一覧については、この記事の「[年齢の値](#age-values)」をご覧ください。    |    X    |  null    |     X    |       
|  gender   |  array   |  対象とするユーザーの性別を識別する 1 つ以上の整数です。 整数の詳しい一覧については、この記事の「[性別の値](#gender-values)」をご覧ください。       |  X    |  null    |     X    |       
|  country   |  array   |  対象とするユーザーの国コードを識別する 1 つ以上の整数です。 整数の詳しい一覧については、この記事の「[国コードの値](#country-code-values)」をご覧ください。    |  X    |  null   |      X   |       
|  osVersion   |  array   |   対象とするユーザーの OS バージョンを識別する 1 つ以上の整数です。 整数の詳しい一覧については、この記事の「[OS バージョンの値](#osversion-values)」をご覧ください。     |   X    |  null   |     X    |       
|  deviceType   | array    |  対象とするユーザーのデバイスの種類を識別する 1 つ以上の整数です。 整数の詳しい一覧については、この記事の「[デバイスの種類の値](#devicetype-values)」をご覧ください。       |   X    |  null    |    X     |       
|  supplyType   |  array   |  キャンペーンの広告が表示されるインベントリの種類を識別する 1 つ以上の整数です。 整数の詳しい一覧については、この記事の「[サプライの種類の値](#supplytype-values)」をご覧ください。      |   X    |  null   |     X    |   |  


<span id="age-values"/>

### <a name="age-values"></a>年齢の値

[TargetingProfile](#targeting-profile) オブジェクトの *age* フィールドには、対象とするユーザーの年齢範囲を識別する次の整数が 1 つ以上含まれています。

|  *age* フィールドの整数値  |  対応する年齢範囲  |  
|---------------------------------|---------------------------|
|     651     |            13 ～ 17             |
|     652     |           18 ～ 24             |
|     653     |            25 ～ 34             |
|     654     |            35 ～ 49             |
|     655     |            50 以上             |

*age* フィールドでサポートされる値をプログラムにより取得するには、次の GET メソッドを呼び出します。  ```Authorization```ヘッダー形式で Azure AD アクセス トークンを渡す**ベアラー** &lt;*トークン*&gt;します。

```json
GET https://manage.devcenter.microsoft.com/v1.0/my/promotion/reference/age
Authorization: Bearer <your access token>
```

次の例は、このメソッドの応答本文を示します。

```json
{
  "Data": {
    "Age": {
      "651": "Age13To17",
      "652": "Age18To24",
      "653": "Age25To34",
      "654": "Age35To49",
      "655": "Age50AndAbove"
    }
  }
}
```

<span id="gender-values"/>

### <a name="gender-values"></a>性別の値

[TargetingProfile](#targeting-profile) オブジェクトの *gender* フィールドには、対象とするユーザーの性別を識別する次の整数が 1 つ以上含まれています。

|  *gender* フィールドの整数値  |  対応する性別  |  
|---------------------------------|---------------------------|
|     700     |            男性             |
|     701     |           女性             |

*gender* フィールドでサポートされる値をプログラムにより取得するには、次の GET メソッドを呼び出します。  ```Authorization```ヘッダー形式で Azure AD アクセス トークンを渡す**ベアラー** &lt;*トークン*&gt;します。

```json
GET https://manage.devcenter.microsoft.com/v1.0/my/promotion/reference/gender
Authorization: Bearer <your access token>
```

次の例は、このメソッドの応答本文を示します。

```json
{
  "Data": {
    "Gender": {
      "700": "Male",
      "701": "Female"
    }
  }
}
```


<span id="osversion-values"/>

### <a name="os-version-values"></a>OS バージョンの値

[TargetingProfile](#targeting-profile) オブジェクトの *osVersion* フィールドには、対象とするユーザーの OS バージョンを識別する次の整数が 1 つ以上含まれています。

|  *osVersion* フィールドの整数値  |  対応する OS バージョン  |  
|---------------------------------|---------------------------|
|     500     |            Windows Phone 7             |
|     501     |           Windows Phone 7.1             |
|     502     |           Windows Phone 7.5             |
|     503     |           Windows Phone 7.8             |
|     504     |           Windows Phone 8.0             |
|     505     |           Windows Phone 8.1             |
|     506     |           Windows 8.0             |
|     507     |           Windows 8.1             |
|     508     |           Windows 10             |
|     509     |           Windows 10 Mobile             |

*osVersion* フィールドでサポートされる値をプログラムにより取得するには、次の GET メソッドを呼び出します。  ```Authorization```ヘッダー形式で Azure AD アクセス トークンを渡す**ベアラー** &lt;*トークン*&gt;します。

```json
GET https://manage.devcenter.microsoft.com/v1.0/my/promotion/reference/osversion
Authorization: Bearer <your access token>
```

次の例は、このメソッドの応答本文を示します。

```json
{
  "Data": {
    "OsVersion": {
      "500": "WindowsPhone70",
      "501": "WindowsPhone71",
      "502": "WindowsPhone75",
      "503": "WindowsPhone78",
      "504": "WindowsPhone80",
      "505": "WindowsPhone81",
      "506": "Windows80",
      "507": "Windows81",
      "508": "Windows10",
      "509": "WindowsPhone10"
    }
  }
}
```


<span id="devicetype-values"/>

### <a name="device-type-values"></a>デバイスの種類の値

[TargetingProfile](#targeting-profile) オブジェクトの *deviceType* フィールドには、対象とするユーザーのデバイスの種類を識別する次の整数が 1 つ以上含まれています。

|  *deviceType* フィールドの整数値  |  対応するデバイスの種類  |  説明  |
|---------------------------------|---------------------------|---------------------------|
|     710     |  Windows   |  これは、Windows 10 または Windows 8.x のデスクトップ バージョンを実行しているデバイスを表しています。  |
|     711     |  Phone     |  これは、Windows 10 Mobile、Windows Phone 8.x、Windows Phone 7.x を実行しているデバイスを表しています。

*deviceType* フィールドでサポートされる値をプログラムにより取得するには、次の GET メソッドを呼び出します。  ```Authorization```ヘッダー形式で Azure AD アクセス トークンを渡す**ベアラー** &lt;*トークン*&gt;します。

```json
GET https://manage.devcenter.microsoft.com/v1.0/my/promotion/reference/devicetype
Authorization: Bearer <your access token>
```

次の例は、このメソッドの応答本文を示します。

```json
{
  "Data": {
    "DeviceType": {
      "710": "Windows",
      "711": "Phone"
    }
  }
}
```


<span id="supplytype-values"/>

### <a name="supply-type-values"></a>サプライの種類の値

[TargetingProfile](#targeting-profile) オブジェクトの *supplyType* フィールドには、キャンペーンの広告が表示されるインベントリの種類を識別する次の整数が 1 つ以上含まれています。

|  *supplyType* フィールドの整数値  |  対応するサプライの種類  |  説明  |
|---------------------------------|---------------------------|---------------------------|
|     11470     |  App        |  これは、アプリにのみ表示される広告を示しています。  |
|     11471     |  ユニバーサル        |  これは、アプリ、Web、および他のディスプレイ サーフェスに表示される広告を示しています。  |

*supplyType* フィールドでサポートされる値をプログラムにより取得するには、次の GET メソッドを呼び出します。  ```Authorization```ヘッダー形式で Azure AD アクセス トークンを渡す**ベアラー** &lt;*トークン*&gt;します。

```json
GET https://manage.devcenter.microsoft.com/v1.0/my/promotion/reference/supplytype
Authorization: Bearer <your access token>
```

次の例は、このメソッドの応答本文を示します。

```json
{
  "Data": {
    "SupplyType": {
      "11470": "App",
      "11471": "Universal"
    }
  }
}
```

<span id="country-code-values"/>

### <a name="country-code-values"></a>国コードの値

[TargetingProfile](#targeting-profile) オブジェクトの *country* フィールドには、対象とするユーザーの [ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2) 国コードを識別する次の整数が 1 つ以上含まれています。

|  *country* フィールドの整数値  |  対応する国コード  |  
|-------------------------------------|------------------------------|
|     1      |            US                  |
|     2      |            AU                  |
|     3      |            AT                  |
|     4      |            BE                  |
|     5      |            BR                  |
|     6      |            CA                  |
|     7      |            DK                  |
|     8      |            FI                  |
|     9      |            FR                  |
|     10      |            DE                  |
|     11      |            GR                  |
|     12      |            HK                  |
|     13      |            IN                  |
|     14      |            Internet Explorer                  |
|     15      |            IT                  |
|     16      |            JP                  |
|     17      |            LU                  |
|     18      |            MX                  |
|     19      |            NL                  |
|     20      |            NZ                  |
|     21      |            使用不可                  |
|     22      |            PL                  |
|     23      |            PT                  |
|     24      |            SG                  |
|     25      |            ES                  |
|     26      |            SE                  |
|     27      |            CH                  |
|     28      |            TW                  |
|     29      |            GB                  |
|     30      |            RU                  |
|     31      |            CL                  |
|     32      |            CO                  |
|     33      |            CZ                  |
|     34      |            HU                  |
|     35      |            ZA                  |
|     36      |            KR                  |
|     37      |            CN                  |
|     38      |            RO                  |
|     39      |            TR                  |
|     40      |            SK                  |
|     41      |            IL                  |
|     42      |            ID                  |
|     43      |            AR                  |
|     44      |            MY                  |
|     45      |            PH                  |
|     46      |            PE                  |
|     47      |            UA                  |
|     48      |            AE                  |
|     49      |            TH                  |
|     50      |            IQ                  |
|     51      |            VN                  |
|     52      |            CR                  |
|     53      |            VE                  |
|     54      |            QA                  |
|     55      |            SI                  |
|     56      |            BG                  |
|     57      |            LT                  |
|     58      |            RS                  |
|     59      |            HR                  |
|     60      |            HR                  |
|     61      |            LV                  |
|     62      |            EE                  |
|     63      |            IS                  |
|     64      |            KZ                  |
|     65      |            SA                  |
|     67      |            AL                  |
|     68      |            DZ                  |
|     70      |            AO                  |
|     72      |            AM                  |
|     73      |            AZ                  |
|     74      |            BS                  |
|     75      |            BD                  |
|     76      |            BB                  |
|     77      |            BY                  |
|     81      |            BO                  |
|     82      |            BA                  |
|     83      |            BW                  |
|     87      |            KH                  |
|     88      |            CM                  |
|     94      |            CD                  |
|     95      |            CI                  |
|     96      |            CY                  |
|     99      |            DO                  |
|     100      |            EC                  |
|     101      |            EG                  |
|     102      |            SV                  |
|     107      |            FJ                  |
|     108      |            GA                  |
|     110      |            GE                  |
|     111      |            GH                  |
|     114      |            GT                  |
|     118      |            HT                  |
|     119      |            HN                  |
|     120      |            JM                  |
|     121      |            JO                  |
|     122      |            KE                  |
|     124      |            KW                  |
|     125      |            KG                  |
|     126      |            LA                  |
|     127      |            LB                  |
|     133      |            MK                  |
|     135      |            MW                  |
|     138      |            MT                  |
|     141      |            MU                  |
|     145      |            ME                  |
|     146      |            MA                  |
|     147      |            MZ                  |
|     148      |            該当なし                  |
|     150      |            NP                  |
|     151      |            NI                  |
|     153      |            NG                  |
|     154      |            OM                  |
|     155      |            PK                  |
|     157      |            PA                  |
|     159      |            PY                  |
|     167      |            SN                  |
|     172      |            LK                  |
|     176      |            TZ                  |
|     180      |            TT                  |
|     181      |            TN                  |
|     184      |            UG                  |
|     185      |            UY                  |
|     186      |            UZ                  |
|     189      |            ZM                  |
|     190      |            ZW                  |
|     219      |            MD                  |
|     224      |            PS                  |
|     225      |            RE                  |
|     246      |            PR                  |

*country* フィールドでサポートされる値をプログラムにより取得するには、次の GET メソッドを呼び出します。  ```Authorization```ヘッダー形式で Azure AD アクセス トークンを渡す**ベアラー** &lt;*トークン*&gt;します。

```json
GET https://manage.devcenter.microsoft.com/v1.0/my/promotion/reference/country
Authorization: Bearer <your access token>
```

次の例は、このメソッドの応答本文を示します。

```json
{
  "Data": {
    "Country": {
      "1": "US",
      "2": "AU",
      "3": "AT",
      "4": "BE",
      "5": "BR",
      "6": "CA",
      "7": "DK",
      "8": "FI",
      "9": "FR",
      "10": "DE",
      "11": "GR",
      "12": "HK",
      "13": "IN",
      "14": "IE",
      "15": "IT",
      "16": "JP",
      "17": "LU",
      "18": "MX",
      "19": "NL",
      "20": "NZ",
      "21": "NO",
      "22": "PL",
      "23": "PT",
      "24": "SG",
      "25": "ES",
      "26": "SE",
      "27": "CH",
      "28": "TW",
      "29": "GB",
      "30": "RU",
      "31": "CL",
      "32": "CO",
      "33": "CZ",
      "34": "HU",
      "35": "ZA",
      "36": "KR",
      "37": "CN",
      "38": "RO",
      "39": "TR",
      "40": "SK",
      "41": "IL",
      "42": "ID",
      "43": "AR",
      "44": "MY",
      "45": "PH",
      "46": "PE",
      "47": "UA",
      "48": "AE",
      "49": "TH",
      "50": "IQ",
      "51": "VN",
      "52": "CR",
      "53": "VE",
      "54": "QA",
      "55": "SI",
      "56": "BG",
      "57": "LT",
      "58": "RS",
      "59": "HR",
      "60": "BH",
      "61": "LV",
      "62": "EE",
      "63": "IS",
      "64": "KZ",
      "65": "SA",
      "67": "AL",
      "68": "DZ",
      "70": "AO",
      "72": "AM",
      "73": "AZ",
      "74": "BS",
      "75": "BD",
      "76": "BB",
      "77": "BY",
      "81": "BO",
      "82": "BA",
      "83": "BW",
      "87": "KH",
      "88": "CM",
      "94": "CD",
      "95": "CI",
      "96": "CY",
      "99": "DO",
      "100": "EC",
      "101": "EG",
      "102": "SV",
      "107": "FJ",
      "108": "GA",
      "110": "GE",
      "111": "GH",
      "114": "GT",
      "118": "HT",
      "119": "HN",
      "120": "JM",
      "121": "JO",
      "122": "KE",
      "124": "KW",
      "125": "KG",
      "126": "LA",
      "127": "LB",
      "133": "MK",
      "135": "MW",
      "138": "MT",
      "141": "MU",
      "145": "ME",
      "146": "MA",
      "147": "MZ",
      "148": "NA",
      "150": "NP",
      "151": "NI",
      "153": "NG",
      "154": "OM",
      "155": "PK",
      "157": "PA",
      "159": "PY",
      "167": "SN",
      "172": "LK",
      "176": "TZ",
      "180": "TT",
      "181": "TN",
      "184": "UG",
      "185": "UY",
      "186": "UZ",
      "189": "ZM",
      "190": "ZW",
      "219": "MD",
      "224": "PS",
      "225": "RE",
      "246": "PR"
    }
  }
}
```

## <a name="related-topics"></a>関連トピック

* [Microsoft ストアのサービスを使用して広告キャンペーンを実行します。](run-ad-campaigns-using-windows-store-services.md)
* [広告キャンペーンを管理します。](manage-ad-campaigns.md)
* [広告キャンペーンの配信の線を管理します。](manage-delivery-lines-for-ad-campaigns.md)
* [広告キャンペーンのクリエイティブを管理します。](manage-creatives-for-ad-campaigns.md)
* [広告キャンペーンのパフォーマンス データを取得します。](get-ad-campaign-performance-data.md)
