---
author: Xansky
description: 日付範囲やその他のオプション フィルターを指定して、デスクトップ アプリケーションに関する集計エラー報告データを取得するには、Microsoft Store 分析 API の以下のメソッドを使います。
title: デスクトップ アプリケーションのエラー報告データの取得
ms.author: mhopkins
ms.date: 09/04/2018
ms.topic: article
keywords: Windows 10, UWP, Store サービス, Microsoft Store 分析 API, エラー, デスクトップ アプリケーション
ms.localizationpriority: medium
ms.openlocfilehash: eb0081024f59af5180f5018664934277e7fad835
ms.sourcegitcommit: 144f5f127fc4fbd852f2f6780ef26054192d68fc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/02/2018
ms.locfileid: "5983141"
---
# <a name="get-error-reporting-data-for-your-desktop-application"></a>デスクトップ アプリケーションのエラー報告データの取得

[Windows デスクトップ アプリケーション プログラム](https://msdn.microsoft.com/library/windows/desktop/mt826504)に追加したデスクトップ アプリケーションに関する集計エラー報告データを取得するには、Microsoft Store 分析 API の以下のメソッドを使います。 このメソッドは、過去 30 日以内に発生したエラーをのみ取得できます。 この情報は、パートナー センターでのデスクトップ アプリケーションの[正常性レポート](https://msdn.microsoft.com/library/windows/desktop/mt826504)で利用可能なもできます。

## <a name="prerequisites"></a>前提条件

このメソッドを使うには、最初に次の作業を行う必要があります。

* Microsoft Store 分析 API に関するすべての[前提条件](access-analytics-data-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。
* このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら、新しいトークンを取得できます。

## <a name="request"></a>要求


### <a name="request-syntax"></a>要求の構文

| メソッド | 要求 URI                                                          |
|--------|----------------------------------------------------------------------|
| GET    | ```https://manage.devcenter.microsoft.com/v1.0/my/analytics/desktop/failurehits``` |


### <a name="request-header"></a>要求ヘッダー

| ヘッダー        | 型   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| Authorization | string | 必須。 **Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。 |


### <a name="request-parameters"></a>要求パラメーター

| パラメーター        | 型   |  説明      |  必須かどうか  
|---------------|--------|---------------|------|
| applicationId | string | エラー報告データを取得するデスクトップ アプリケーションの製品 ID です。 デスクトップ アプリケーションの製品 ID を取得するには、(などの**正常性レポート**で) すべての[パートナー センターで、デスクトップ アプリケーションの分析レポート](https://msdn.microsoft.com/library/windows/desktop/mt826504)を開き、URL から製品 ID を取得します。 |  必須  |
| startDate | date | 取得するエラー報告データの日付範囲の開始日を ```mm/dd/yyyy``` の形式で指定します。 既定値は現在の日付です。<p/><p/>**注:**&nbsp;&nbsp;以下のメソッドは、過去 30 日以内に発生したエラーのみを取得できます。  |  必須ではない  |
| endDate | date | 取得するエラー報告データの日付範囲の終了日を ```mm/dd/yyyy``` の形式で指定します。 既定値は現在の日付です。   |  必須ではない  |
| top | int | 要求で返すデータの行数です。 指定されない場合の既定値は、最大値でもある 10000 です。 クエリにこれを上回る行がある場合は、応答本文に次リンクが含まれ、そのリンクを使ってデータの次のページを要求できます。 |  必須ではない  |
| skip | int | クエリでスキップする行数です。 大きなデータ セットを操作するには、このパラメーターを使用します。 たとえば、top=10000 と skip=0 を指定すると、データの最初の 10,000 行が取得され、top=10000 と skip=10000 を指定すると、データの次の 10,000 行が取得されます。 |  必須ではない  |
| filter |string  | 応答内の行をフィルター処理する 1 つまたは複数のステートメントです。 各ステートメントには、応答本文からのフィールド名、および **eq** 演算子または **ne** 演算子と関連付けられる値が含まれており、**and** や **or** を使用してステートメントを組み合わせることができます。 *filter* パラメーターでは、文字列値を単一引用符で囲む必要があります。 応答本文から次のフィールドを指定することができます。<p/><ul><li><strong>fileName</strong></li><li><strong>applicationVersion</strong></li><li><strong>failureName</strong></li><li><strong>failureHash</strong></li><li><strong>symbol</strong></li><li><strong>osVersion</strong></li><li><strong>osBuild</strong></li><li><strong>osRelease</strong></li><li><strong>eventType</strong></li><li><strong>market</strong></li><li><strong>deviceType</strong></li><li><strong>productName</strong></li><li><strong>date</strong></li></ul> | 必須ではない   |
| aggregationLevel | string | 集計データを取得する時間範囲を指定します。 次のいずれかの文字列を指定できます。**day**、**week**、または **month**。 指定されていない場合、既定値は **day** です。 **week** または **month** を指定した場合、*failureName* と *failureHash* の値は 1,000 バケットに制限されます。<p/>  | 必須ではない |
| orderby | string | 結果データ値の順序を指定するステートメントです。 構文は *orderby=field [order],field [order],...* です。*field* パラメーターは次のいずれかの文字列になります。<ul><li><strong>fileName</strong></li><li><strong>applicationVersion</strong></li><li><strong>failureName</strong></li><li><strong>failureHash</strong></li><li><strong>symbol</strong></li><li><strong>osVersion</strong></li><li><strong>osBuild</strong></li><li><strong>osRelease</strong></li><li><strong>eventType</strong></li><li><strong>market</strong></li><li><strong>deviceType</strong></li><li><strong>productName</strong></li><li><strong>date</strong></li></ul>*order* パラメーターは省略可能であり、**asc** または **desc** を指定して、各フィールドを昇順または降順にすることができます。 既定値は **asc** です。</p><p>*orderby* 文字列の例: *orderby=date,market*</p> |  必須ではない  |
| groupby | string | 指定したフィールドのみにデータ集計を適用するステートメントです。 次のフィールドを指定できます。<ul><li>**failureName**</li><li>**failureHash**</li><li>**symbol**</li><li>**osVersion**</li><li>**eventType**</li><li>**market**</li><li>**deviceType**</li></ul><p>返されるデータ行には、*groupby* パラメーターに指定したフィールドと次の値が含まれます。</p><ul><li>**date**</li><li>**applicationId**</li><li>**applicationName**</li><li>**eventCount**</li></ul><p>*groupby* パラメーターは、*aggregationLevel* パラメーターと同時に使用できます。 例: *&amp;groupby=failureName,market&amp;aggregationLevel=week*</p></p> |  必須ではない  |


### <a name="request-example"></a>要求の例

エラー報告データを取得するためのいくつかの要求の例を次に示します。 *applicationId* の値は、デスクトップ アプリケーションの製品 ID に置き換えてください。

```syntax
GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/desktop/failurehits?applicationId=10238467886765136388&startDate=1/1/2018&endDate=2/1/2018&top=10&skip=0 HTTP/1.1
Authorization: Bearer <your access token>

GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/desktop/failurehits?applicationId=10238467886765136388&startDate=8/1/2017&endDate=8/31/2017&skip=0&filter=market eq 'US' and deviceType eq 'PC' HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a>応答


### <a name="response-body"></a>応答本文

| 値      | 型    | 説明     |
|------------|---------|--------------|
| Value      | array   | 集計エラー報告データが含まれるオブジェクトの配列です。 各オブジェクトのデータについて詳しくは、次の「[エラー値](#error-values)」セクションをご覧ください。     |
| @nextLink  | string  | データの追加ページがある場合、この文字列には、データの次のページを要求するために使用できる URI が含まれます。 たとえば、要求の **top** パラメーターが 10000 に設定されたが、クエリの入手データに 10,000 を超えるエラー行が含まれている場合に、この値が返されます。 |
| TotalCount | 整数 | クエリの結果データ内の行の総数です。     |


### <a name="error-values"></a>エラー値

*Value* 配列の要素には、次の値が含まれます。

| 値           | 型    | 説明        |
|-----------------|---------|---------------------|
| date            | string  | エラー データの日付範囲の最初の日付を ```yyyy-mm-dd``` の形式で示します。 要求に単一の日付を指定した場合、この値はその日付になります。 要求に日付範囲を指定した場合、この値はその日付範囲の最初の日付になります。 *aggregationLevel* 値に **hour** が指定されている要求の場合、この値には ```hh:mm:ss``` 形式の時刻値も含まれます。  |
| applicationId   | string  | エラー データを取得したデスクトップ アプリケーションの製品 ID です。    |
| productName | string  | デスクトップ アプリケーションの表示名です。アプリケーションに関連付けられている実行可能ファイルのメタデータから取得されます。   |
| appName | string  |  TBD  |
| fileName | string  | デスクトップ アプリケーションの実行可能ファイルの名前です。   |
| failureName     | string  | 4 つの部分から成るエラーの名前です。問題が発生した 1 つ以上のクラス、例外/バグ チェック コード、障害が発生したイメージの名前、関連する関数の名前で構成されます。  |
| failureHash     | string  | エラーの一意の識別子です。   |
| symbol          | string  | このエラーに割り当てられた記号です。 |
| osBuild       | string  | エラーが発生した OS のビルド番号です。4 つの部分から構成されます。  |
| osVersion       | string  | デスクトップ アプリケーションがインストールされている OS のバージョンを示す、以下のいずれかの文字列です。<p/><ul><li><strong>Windows 7</strong></li><li><strong>Windows 8.1</strong></li><li><strong>Windows 10</strong></li><li><strong>Windows Server 2016</strong></li><li><strong>Windows Server 1709</strong></li><li><strong>Unknown</strong></li></ul>   |   
| osRelease | string  | エラーが発生した OS リリースまたはフライティング リングを (OS バージョン内のサブグループとして) 指定する、以下のいずれかの文字列です。<p/><p>Windows 10 の場合:</p><ul><li><strong>Version 1507</strong></li><li><strong>Version 1511</strong></li><li><strong>Version 1607</strong></li><li><strong>Version 1703</strong></li><li><strong>Version 1709</strong></li><li><strong>バージョン 1803</strong></li><li><strong>リリース プレビュー</strong></li><li><strong>Insider Fast</strong></li><li><strong>Insider Slow</strong></li></ul><p/><p>Windows Server 1709 の場合:</p><ul><li><strong>RTM</strong></li></ul><p>Windows Server 2016 の場合:</p><ul><li><strong>Version 1607</strong></li></ul><p>Windows 8.1 の場合:</p><ul><li><strong>Update 1</strong></li></ul><p>Windows 7 の場合:</p><ul><li><strong>Service Pack 1</strong></li></ul><p>OS リリースまたはフライティング リングが不明な場合、このフィールドは値 <strong>Unknown</strong> になります。</p> |
| eventType       | string  | エラー イベントの種類を示す、以下のいずれかの文字列です。<ul><li>**crash**</li><li>**hang**</li><li>**memory**</li><li>**jse**</li></ul>       |
| market          | string  | デバイスの市場の ISO 3166 国コードです。   |
| deviceType      | string  | エラーが発生したデバイスの種類を指定する、以下のいずれかの文字列です。<p/><ul><li><strong>PC</strong></li><li><strong>Server</strong></li><li><strong>Tablet</strong></li><li><strong>Unknown</strong></li></ul>    |
| applicationVersion     | string  |   エラーが発生したアプリケーションの実行可能ファイルのバージョンです。    |
| eventCount      | number | 指定した集計レベルでこのエラーに起因すると考えられるイベントの数です。      |


### <a name="response-example"></a>応答の例

この要求の JSON 応答の本文の例を次に示します。

```json
{
  "Value": [
    {
      "date": "2018-02-01",
      "applicationId": "10238467886765136388",
      "productName": "Contoso Demo",
      "appName": "Contoso Demo",
      "fileName": "contosodemo.exe",
      "failureName": "SVCHOSTGROUP_localservice_IN_PAGE_ERROR_c0000006_hardware_disk!Unknown",
      "failureHash": "11242ef3-ebd8-d525-838d-b5497b225695",
      "symbol": "hardware_disk!Unknown",
      "osBuild": "10.0.15063.850",
      "osVersion": "Windows 10",
      "osRelease": "Version 1703",
      "eventType": "crash",
      "market": "US",
      "deviceType": "PC",
      "applicationVersion": "2.2.2.0",
      "eventCount": 0.0012422360248447205
    }
  ],
  "@nextLink": "desktop/failurehits?applicationId=10238467886765136388&aggregationLevel=week&startDate=2018/02/01&endDate2018/02/08&top=1&skip=1",
  "TotalCount": 21
}

```

## <a name="related-topics"></a>関連トピック

* [[正常性] レポート](../publish/health-report.md)
* [Microsoft Store サービスを使った分析データへのアクセス](access-analytics-data-using-windows-store-services.md)
* [デスクトップ アプリケーションのエラーに関する詳細情報の取得](get-details-for-an-error-in-your-desktop-application.md)
* [デスクトップ アプリケーションのエラーに関するスタック トレースの取得](get-the-stack-trace-for-an-error-in-your-desktop-application.md)
* [デスクトップ アプリケーションのエラーの CAB ファイルをダウンロードする](download-the-cab-file-for-an-error-in-your-desktop-application.md)
