---
author: mcleanbyron
ms.assetid: BAC79A64-445D-4702-8E96-7727FF180245
description: "特定の日付範囲などのオプション フィルターを使って Windows 10 のドライバーに関する集計エラー報告データを取得するには、Windows ストア分析 API に含まれる以下のメソッドを使用します。 このメソッドは、IHV のみを対象としています。"
title: "Windows 10 のドライバーに関するエラー報告データを取得する"
ms.author: mcleans
ms.date: 03/17/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, ストア サービス, Windows ストア分析 API, エラー"
ms.openlocfilehash: ea2465feda869a07eef06b57a5ca8b4e04cf99f1
ms.sourcegitcommit: 64cfb79fd27b09d49df99e8c9c46792c884593a7
translationtype: HT
---
# <a name="get-error-reporting-data-for-windows-10-drivers"></a>Windows 10 のドライバーに関するエラー報告データを取得する

特定の日付範囲などのオプション フィルターを使って Windows 10 のドライバー エラーに関する集計報告データを取得するには、Windows ストア分析 API に含まれる以下のメソッドを使用します。 また、[Windows 10 のドライバー エラーに関する詳細を取得する](get-details-for-a-windows-10-driver-error.md)メソッドを利用すれば、追加のエラー情報を取得することもできます。

> [!NOTE]
> このメソッドは、[Windows ハードウェア デベロッパー センター プログラム](https://msdn.microsoft.com/windows/hardware/drivers/dashboard/get-started-with-the-hardware-dashboard)に参加している開発者アカウントでのみ使用できます。

## <a name="prerequisites"></a>前提条件

このメソッドを使うには、最初に次の作業を行う必要があります。

* Windows ストア分析 API に関するすべての[前提条件](access-analytics-data-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。
* このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら新しいトークンを取得できます。

## <a name="request"></a>要求


### <a name="request-syntax"></a>要求の構文

| メソッド | 要求 URI                                                          |
|--------|----------------------------------------------------------------------|
| GET    | ```https://manage.devcenter.microsoft.com/v1.0/my/analytics/driver/failurehits``` |

<span/> 

### <a name="request-header"></a>要求ヘッダー

| ヘッダー        | 型   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| Authorization | string | 必須。 **Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。 |

<span/> 

### <a name="request-parameters"></a>要求パラメーター

| パラメーター        | 型   |  説明      |  必須かどうか  
|---------------|--------|---------------|------|
| applicationId   | string  | エラー データを取得するドライバーの製品 ID です。 | 必須  |
| startDate | date | 取得するエラー報告データの日付範囲の開始日です。 既定値は現在の日付です。 |  必須ではない  |
| endDate | date | 取得するエラー報告データの日付範囲の終了日です。 既定値は現在の日付です。 |  必須ではない  |
| top | int | 要求で返すデータの行数です。 指定されない場合の既定値は、最大値でもある 10000 です。 クエリにこれを上回る行がある場合は、応答本文に次リンクが含まれ、そのリンクを使ってデータの次のページを要求できます。 |  必須ではない  |
| skip | int | クエリでスキップする行数です。 大きなデータ セットを操作するには、このパラメーターを使用します。 たとえば、top=10000 と skip=0 を指定すると、データの最初の 10,000 行が取得され、top=10000 と skip=10000 を指定すると、データの次の 10,000 行が取得されます。 |  必須ではない  |
| filter |string  | 応答内の行をフィルター処理する 1 つまたは複数のステートメントです。 各ステートメントには、応答本文からのフィールド名、および **eq** 演算子または **ne** 演算子と関連付けられる値が含まれており、**and** や **or** を使用してステートメントを組み合わせることができます。 *filter* パラメーターでは、文字列値を単一引用符で囲む必要があります。 応答本文から次のフィールドを指定することができます。<p/><ul><li><strong>date</strong></li><li><strong>submissionId</strong></li><li><strong>failureName</strong></li><li><strong>failureHash</strong></li><li><strong>symbol</strong></li><li><strong>osVersion</strong></li><li><strong>osName</strong></li><li><strong>eventType</strong></li><li><strong>market</strong></li><li><strong>deviceType</strong></li><li><strong>driverName</strong></li><li><strong>driverVersion</strong></li><li><strong>oemName</strong></li><li><strong>oemModel</strong></li><li><strong>flightRing</strong></li><li><strong>architecture</strong></li></ul> | 必須ではない   |
| aggregationLevel | string | 集計データを取得する時間範囲を指定します。 次のいずれかの文字列を指定できます。<strong>day</strong>、<strong>week</strong>、または <strong>month</strong>。 指定されていない場合、既定値は <strong>day</strong> です。 <strong>week</strong> または <strong>month</strong> を指定した場合、<em>failureName</em> と <em>failureHash</em> の値は 1,000 バケットに制限されます。 | 必須ではない |
| orderby | string | 結果データ値の順序を指定するステートメントです。 構文は <em>orderby=field [order],field [order],...</em> です。 応答本文から次のフィールドを指定することができます。<p/><ul><li><strong>date</strong></li><li><strong>submissionId</strong></li><li><strong>failureName</strong></li><li><strong>failureHash</strong></li><li><strong>symbol</strong></li><li><strong>osVersion</strong></li><li><strong>osName</strong></li><li><strong>eventType</strong></li><li><strong>market</strong></li><li><strong>deviceType</strong></li><li><strong>driverName</strong></li><li><strong>driverVersion</strong></li><li><strong>oemName</strong></li><li><strong>oemModel</strong></li><li><strong>flightRing</strong></li><li><strong>architecture</strong></li></ul><p><em>order</em> パラメーターは省略可能であり、<strong>asc</strong> または <strong>desc</strong> を指定して、各フィールドを昇順または降順にすることができます。 既定値は <strong>asc</strong> です。</p><p><em>orderby</em> 文字列の例: <em>orderby=date,market</em></p> |  必須ではない  |
| groupby | string | 指定したフィールドのみにデータ集計を適用するステートメントです。 応答本文から次のフィールドを指定することができます。<p/><ul><li><strong>submissionId</strong></li><li><strong>failureName</strong></li><li><strong>failureHash</strong></li><li><strong>symbol</strong></li><li><strong>osVersion</strong></li><li><strong>eventType</strong></li><li><strong>market</strong></li><li><strong>deviceType</strong></li><li><strong>driverName</strong></li><li><strong>driverVersion</strong></li><li><strong>oemName</strong></li><li><strong>oemModel</strong></li><li><strong>flightRing</strong></li><li><strong>architecture</strong></li></ul><p>返されるデータ行には、<em>groupby</em> パラメーターに指定したフィールドと次の値が含まれます。</p><ul><li><strong>date</strong></li><li><strong>applicationId</strong></li><li><strong>eventCount</strong></li></ul><p><em>groupby</em> パラメーターは、<em>aggregationLevel</em> パラメーターと同時に使用できます。 例: <em>&amp;groupby=failureName,market&amp;aggregationLevel=week</em></p></p> |  必須ではない  |

<span/>


### <a name="request-example"></a>要求の例

OEM ハードウェア エラー報告データを取得するための要求の例をいくつか次に示します。

```syntax
GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/driver/failurehits?applicationId=18430592857500421&startDate=1/1/2015&endDate=2/1/2015&top=10&skip=0 HTTP/1.1
Authorization: Bearer <your access token>

GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/driver/failurehits?applicationId=18430592857500421&startDate=8/1/2015&endDate=8/31/2015&skip=0&filter=market eq 'US' and deviceType eq 'PC' HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a>応答


### <a name="response-body"></a>応答本文

| 値      | 型    | 説明     |
|------------|---------|--------------|
| Value      | array   | 集計エラー報告データが含まれるオブジェクトの配列です。 各オブジェクトのデータの詳細については、以下の表を参照してください。     |
| @nextLink  | string  | データの追加ページがある場合、この文字列には、データの次のページを要求するために使用できる URI が含まれます。 たとえば、要求の **top** パラメーターが 10000 に設定されたが、クエリの入手データに 10,000 を超えるエラー行が含まれている場合に、この値が返されます。 |
| TotalCount | inumber | クエリの結果データ内の行の総数です。     |

<span/>

*Value* 配列の要素には、次の値が含まれます。

| 値           | 型    | 説明        |
|-----------------|---------|---------------------|
| date            | string  | エラー データの日付範囲の最初の日付です。 要求に日付を指定した場合、この値はその日付になります。 要求に週、月、またはその他の日付範囲を指定した場合、この値はその日付範囲の最初の日付になります。 |
| applicationId   | string  | エラー データを取得するドライバーの製品 ID です。 |
| submissionId   | string  | ドライバーに関連付けられている申請 ID です。 |
| failureName     | string  | エラーの名前です。  |
| failureHash     | string  | エラーの一意の識別子です。   |
| symbol          | string  | このエラーに割り当てられた記号です。 |
| osVersion       | string  | エラーが発生した OS のビルド バージョンです。4 つの部分から構成されます。  |
| osName       | string  | エラーが発生した OS の名前です。  |
| eventType       | string  | 発生したエラーの種類です。      |
| market          | string  | デバイスの市場の ISO 3166 国コードです。   |
| deviceType      | string  | エラーが発生したデバイスの種類を指定する、以下のいずれかの文字列です。<p/><ul><li><strong>PC</strong></li><li><strong>Phone</strong></li><li><strong>Console</strong></li><li><strong>IoT</strong></li><li><strong>Holographic</strong></li><li><strong>Unknown</strong></li></ul>    |
| driverName     | string  | このエラーに関連付けられているドライバーの一意の名前です。      |
| driverVersion  | string  | このエラーに関連付けられているドライバーのバージョンです。   |
| architecture | string |  エラーが発生したデバイスのアーキテクチャです。  |
| oemName | string | エラーが発生したデバイスの OEM の名前です。 |
| oemModel | string | エラーが発生したデバイス モデルの名前です。 |
| flightRing | string | エラーが発生した OS フライトの名前です。 |
| eventCount      | inumber | 指定した集計レベルでこのエラーに起因すると考えられるイベントの数です。      |

<span/> 

### <a name="response-example"></a>応答の例

この要求の JSON 応答の本文の例を次に示します。

```json
{
  "Value": [
    {
      "date": "2017-02-26",
      "submissionId":"29989500_13736592797500435_1152921504626321174",
      "applicationId":"18430592857500421",
      "driverName": "fastboot.sys",
      "osVersion": "10.0.14393.693",
      "osName": "Windows 10",
      "flightRing": "Windows 10 Retail",
      "oemName": "Contoso",
      "oemModel": "C-122",
      "market": "US",
      "symbol": "fastboot",
      "failureName": "AV_fastboot!unknown_function",
      "failureHash": "f060c0b6-fbe6-463f-a9f1-b7ebc1cc722f",
      "architecture": "x64",
      "driverVersion": "2.1.1.0",
      "deviceType": "Unknown",
      "eventType": "System crash",
      "deviceCount": 1.0,
      "eventCount": 1.0
    }]
}
```

## <a name="related-topics"></a>関連トピック

* [Windows 10 のドライバー エラーに関する詳細を取得する](get-details-for-a-windows-10-driver-error.md)
* [Windows 10 のドライバー エラーに関する CAB ファイルをダウンロードする](download-the-cab-file-for-a-windows-10-driver-error.md)
