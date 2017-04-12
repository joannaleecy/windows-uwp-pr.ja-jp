---
author: mcleanbyron
ms.assetid: 79DC7C99-70F1-499A-856B-D2A83FC6F867
description: "Windows 10 のドライバー エラーに関する詳細データを取得するには、Windows ストア分析 API に含まれる以下のメソッドを使用します。 このメソッドは、IHV のみを対象としています。"
title: "Windows 10 のドライバー エラーに関する詳細を取得する"
ms.author: mcleans
ms.date: 03/17/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, ストア サービス, Windows ストア分析 API, エラー, 詳細"
ms.openlocfilehash: faa298a582535d4371140aad08c7e75d5f8515cc
ms.sourcegitcommit: 64cfb79fd27b09d49df99e8c9c46792c884593a7
translationtype: HT
---
# <a name="get-details-for-a-windows-10-driver-error"></a>Windows 10 のドライバー エラーに関する詳細を取得する

Windows 10 の特定のドライバー エラーに関する詳細データを JSON 形式で取得するには、Windows ストア分析 API に含まれる以下のメソッドを使用します。 このメソッドを使うには、事前に[ Windows 10 のドライバーに関するエラー報告データを取得する](get-error-reporting-data-for-windows-10-drivers.md)メソッドを使用し、必要な詳細情報の対象となるエラーの ID を取得しておく必要があります。

> [!NOTE]
> このメソッドは、[Windows ハードウェア デベロッパー センター プログラム](https://msdn.microsoft.com/windows/hardware/drivers/dashboard/get-started-with-the-hardware-dashboard)に参加している開発者アカウントでのみ使用できます。

## <a name="prerequisites"></a>前提条件


このメソッドを使うには、最初に次の作業を行う必要があります。

* Windows ストア分析 API に関するすべての[前提条件](access-analytics-data-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。
* このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら、新しいトークンを取得できます。
* 詳細情報を取得するエラーの ID を取得します。 この ID を取得するには、[Windows 10 のドライバーに関するエラー報告データを取得する](get-error-reporting-data-for-windows-10-drivers.md)メソッドを使用し、そのメソッドの応答本文にある **failureHash** の値を使います。

## <a name="request"></a>要求


### <a name="request-syntax"></a>要求の構文

| メソッド | 要求 URI                                                          |
|--------|----------------------------------------------------------------------|
| GET    | ```https://manage.devcenter.microsoft.com/v1.0/my/analytics/driver/failuredetails``` |

<span/> 

### <a name="request-header"></a>要求ヘッダー

| ヘッダー        | 型   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| Authorization | string | 必須。 **Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。 |

<span/> 

### <a name="request-parameters"></a>要求パラメーター

| パラメーター        | 型   |  説明      |  必須かどうか  
|---------------|--------|---------------|------|
| applicationId | string | エラー データを取得するドライバーの製品 ID です。 |  必須  |
| failureHash | string | 取得する詳細情報の対象となるエラーの一意の ID です。 対象となるエラーの ID 値を取得するには、[OEM ハードウェア エラー報告データを取得する](get-oem-hardware-error-reporting-data.md)メソッドを使用し、そのメソッドの応答本文にある **failureHash** の値を使います。 |  必須  |
| startDate | date | 取得する詳細なエラー データの日付範囲の開始日です。 既定値は、現在の日付の 30 日前です。 |  必須ではない  |
| endDate | date | 取得する詳細なエラー データの日付範囲の終了日です。 既定値は現在の日付です。 |  必須ではない  |
| top | int | 要求で返すデータの行数です。 指定されない場合の既定値は、最大値でもある 10000 です。 クエリにこれを上回る行がある場合は、応答本文に次リンクが含まれ、そのリンクを使ってデータの次のページを要求できます。 |  必須ではない  |
| skip | int | クエリでスキップする行数です。 大きなデータ セットを操作するには、このパラメーターを使用します。 たとえば、top=10 と skip=0 を指定すると、データの最初の 10 行が取得され、top=10 と skip=10 を指定すると、データの次の 10 行が取得されます。 |  必須ではない  |
| filter |string  | 応答内の行をフィルター処理する 1 つまたは複数のステートメントです。 各ステートメントには、応答本文からのフィールド名、および **eq** 演算子または **ne** 演算子と関連付けられる値が含まれており、**and** や **or** を使用してステートメントを組み合わせることができます。 *filter* パラメーターでは、文字列値を単一引用符で囲む必要があります。 応答本文から次のフィールドを指定することができます。<p/><ul><li><strong>date</strong></li><li><strong>submissionId</strong></li><li><strong>failureName</strong></li><li><strong>failureHash</strong></li><li><strong>symbol</strong></li><li><strong>osVersion</strong></li><li><strong>osName</strong></li><li><strong>eventType</strong></li><li><strong>market</strong></li><li><strong>deviceType</strong></li><li><strong>driverName</strong></li><li><strong>driverVersion</strong></li><li><strong>oemName</strong></li><li><strong>oemModel</strong></li><li><strong>architecture</strong></li><li><strong>cabIdHash</strong></li><li><strong>clientDeviceId</strong></li><li><strong>cabType</strong></li><li><strong>cabExpirationTime</strong></li></ul> | 必須ではない   |
| orderby | string | 結果データ値の順序を指定するステートメントです。 構文は <em>orderby=field [order],field [order],...</em> です。 応答本文から次のフィールドを指定することができます。<p/><ul><li><strong>date</strong></li><li><strong>submissionId</strong></li><li><strong>failureName</strong></li><li><strong>failureHash</strong></li><li><strong>symbol</strong></li><li><strong>osVersion</strong></li><li><strong>osName</strong></li><li><strong>eventType</strong></li><li><strong>market</strong></li><li><strong>deviceType</strong></li><li><strong>driverName</strong></li><li><strong>driverVersion</strong></li><li><strong>oemName</strong></li><li><strong>oemModel</strong></li><li><strong>flightRing</strong></li><li><strong>architecture</strong></li><li><strong>cabType</strong></li><li><strong>cabExpirationTime</strong></li></ul><p><em>order</em> パラメーターは省略可能であり、<strong>asc</strong> または <strong>desc</strong> を指定して、各フィールドを昇順または降順にすることができます。 既定値は <strong>asc</strong> です。</p><p><em>orderby</em> 文字列の例: <em>orderby=date,market</em></p> |  必須ではない  |

<span/> 

### <a name="request-example"></a>要求の例

詳細なエラー データを取得するための要求の例を次に示します。

```syntax
GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/driver/failuredetails?applicationId=18430592857500421&failureHash=012e33e3-dbc9-b12f-c124-9d9810f05d8b&startDate=2016-11-05&endDate=2016-11-06&top=10&skip=0 HTTP/1.1
Authorization: Bearer <your access token>

GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/driver/failuredetails?applicationId=18430592857500421&failureHash=012e33e3-dbc9-b12f-c124-9d9810f05d8b&startDate=2016-11-05&endDate=2016-11-06&top=10&skip=0&filter=market eq 'US' and deviceType eq 'PC' HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a>応答


### <a name="response-body"></a>応答本文

| 値      | 型    | 説明    |
|------------|---------|------------|
| Value      | array   | 詳細なエラー データが含まれているオブジェクトの配列です。 各オブジェクトのデータの詳細については、以下の表を参照してください。          |
| @nextLink  | string  | データの追加ページがある場合、この文字列には、データの次のページを要求するために使用できる URI が含まれます。 たとえば、要求の **top** パラメーターを 10 に設定した場合、クエリに適合するエラーが 10 行を超えると、この値が返されます。 |
| TotalCount | inumber | クエリの結果データ内の行の総数です。        |

<span/>

*Value* 配列の要素には、次の値が含まれます。

| 値           | 型    | 説明     |
|-----------------|---------|----------------------------|
| date            | string  | エラー データの日付範囲の最初の日付です。 要求に日付を指定した場合、この値はその日付になります。 要求に週、月、またはその他の日付範囲を指定した場合、この値はその日付範囲の最初の日付になります。 |
| applicationId   | string  | エラー データを取得するドライバーの製品 ID です。 |
| submissionId   | string  | ドライバーに関連付けられている申請 ID です。 |
| failureName     | string  | エラーの名前です。             |
| failureHash     | string  | エラーの一意の識別子です。     |
| symbol     | string  | このエラーに割り当てられた記号です。     |
| osVersion       | string  | エラーが発生した OS のビルド バージョンです。4 つの部分から構成されます。    |
| osName       | string  | エラーが発生した OS の名前です。  |
| eventType       | string  | 発生したエラーの種類です。      |
| market          | string  | デバイスの市場の ISO 3166 国コードです。     |
| deviceType      | string  | エラーが発生したデバイスの種類を指定する、以下のいずれかの文字列です。<p/><ul><li><strong>PC</strong></li><li><strong>Phone</strong></li><li><strong>Console</strong></li><li><strong>IoT</strong></li><li><strong>Holographic</strong></li><li><strong>Unknown</strong></li></ul>     |
| driverName     | string  | このエラーに関連付けられているドライバーの一意の名前です。      |
| driverVersion  | string  | このエラーに関連付けられているドライバーのバージョンです。   |
| architecture | string |  エラーが発生したデバイスのアーキテクチャです。  |
| oemName | string | エラーが発生したデバイスの OEM の名前です。 |
| oemModel | string | エラーが発生したデバイス モデルの名前です。 |
| flightRing | string | エラーが発生した OS フライトの名前です。 |
| clientDeviceId | string | エラーが発生したデバイスの ID です。 |
| cabIdHash         | string  | このエラーに関連付けられている CAB ファイルの一意の ID です。   |
| cabType         | string  | CAB ファイルの種類です。   |
| cabExpirationTime  | string  | CAB ファイルの有効期限が切れ、ダウンロードできなくなる日付と時刻 (ISO 8601形式) です。   |

<span/> 

### <a name="response-example"></a>応答の例

この要求の JSON 応答の本文の例を次に示します。

```json
{
  "Value": [
    {   
      "submissionId":"29989500_13736592797500435_1152921504626321174",
      "applicationId":"18430592857500421",
      "architecture": "x64",
      "cabExpirationTime": "2017-03-16 01:04:55",
      "cabIdHash": "1d7b4184-8f18-4207-88b5-36b276363eb5",
      "cabType": "MINI",
      "clientDeviceId": null,
      "date": "2017-02-14 01:04:55",
      "deviceType": "Unknown",
      "driverName": "fastboot.sys",
      "driverVersion": "2.1.1.0",
      "failureHash": "0d901479-bf1f-b842-76f2-3db7e4feaedd",
      "failureName": "AV_fastboot!unknown_function",
      "market": "US",
      "oemModel": "C-122",
      "oemName": "Contoso",
      "osName": "Windows 10",
      "osVersion": "10.0.14393.693"
    }]
}
```

## <a name="related-topics"></a>関連トピック

* [Windows 10 のドライバーに関するエラー報告データを取得する](get-error-reporting-data-for-windows-10-drivers.md)
* [Windows 10 のドライバー エラーに関する CAB ファイルをダウンロードする](download-the-cab-file-for-a-windows-10-driver-error.md)
