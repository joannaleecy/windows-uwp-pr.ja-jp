---
author: mcleanbyron
description: デスクトップ アプリケーションの特定のエラーに関する詳細データを取得するには、Microsoft Store 分析 API の以下のメソッドを使います。
title: デスクトップ アプリケーションのエラーに関する詳細情報の取得
ms.author: mcleans
ms.date: 06/05/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, Store サービス, Microsoft Store 分析 API, エラー, 詳細, デスクトップ アプリケーション
ms.localizationpriority: medium
ms.openlocfilehash: 31b7684878eb0f8921d81c8fda9d262a21e12132
ms.sourcegitcommit: 9c79fdab9039ff592edf7984732d300a14e81d92
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/23/2018
ms.locfileid: "2816404"
---
# <a name="get-details-for-an-error-in-your-desktop-application"></a>デスクトップ アプリケーションのエラーに関する詳細情報の取得

アプリの特定のエラーに関する詳細データを JSON 形式で取得するには、Microsoft Store 分析 API の以下のメソッドを使います。 このメソッドで取得できるのは、過去 30 日以内に発生したエラーの詳細のみです。 詳細なエラー データは、Windows デベロッパー センター ダッシュボードにあるデスクトップ アプリケーションの[正常性レポート](https://msdn.microsoft.com/library/windows/desktop/mt826504)でも確認できます。

このメソッドを使うには、その前にまず「[エラー報告データの取得](get-error-reporting-data.md)」のメソッドを使って、詳細情報を取得するエラーの ID を取得する必要があります。

## <a name="prerequisites"></a>前提条件


このメソッドを使うには、最初に次の作業を行う必要があります。

* Microsoft Store 分析 API に関するすべての[前提条件](access-analytics-data-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。
* このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら、新しいトークンを取得できます。
* 詳細情報を取得するエラーの ID を取得します。 この ID を取得するには、「[エラー報告データの取得](get-error-reporting-data.md)」のメソッドを使い、そのメソッドの応答本文で **failureHash** の値を使います。

## <a name="request"></a>要求


### <a name="request-syntax"></a>要求の構文

| メソッド | 要求 URI                                                          |
|--------|----------------------------------------------------------------------|
| GET    | ```https://manage.devcenter.microsoft.com/v1.0/my/analytics/desktop/failuredetails``` |


### <a name="request-header"></a>要求ヘッダー

| ヘッダー        | 型   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| Authorization | string | 必須。 **Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。 |


### <a name="request-parameters"></a>要求パラメーター

| パラメーター        | 型   |  説明      |  必須かどうか  
|---------------|--------|---------------|------|
| applicationId | string | エラーの詳細を取得するデスクトップ アプリケーションの製品 ID です。 デスクトップ アプリケーションの製品 ID を取得するには、[デベロッパー センターでデスクトップ アプリケーションの分析レポート](https://msdn.microsoft.com/library/windows/desktop/mt826504)のいずれか (**正常性レポート**など) を開き、URL から製品 ID を取得します。 |  必須  |
| failureHash | string | 取得する詳細情報の対象となるエラーの一意の ID です。 目的のエラーについてこの ID を取得するには、「[エラー報告データの取得](get-error-reporting-data.md)」のメソッドを使い、そのメソッドの応答本文で **failureHash** の値を使います。 |  必須  |
| startDate | date | 取得する詳細なエラー データの日付範囲の開始日です。 既定値は、現在の日付の 30 日前です。<p/><p/>**メモ:**&nbsp;&nbsp;この方法では、過去 30 日間で発生したエラーの詳細情報を取得できるだけです。 |  必須ではない  |
| endDate | date | 取得する詳細なエラー データの日付範囲の終了日です。 既定値は現在の日付です。 |  必須ではない  |
| top | int | 要求で返すデータの行数です。 指定されない場合の既定値は、最大値でもある 10000 です。 クエリにこれを上回る行がある場合は、応答本文に次リンクが含まれ、そのリンクを使ってデータの次のページを要求できます。 |  必須ではない  |
| skip | int | クエリでスキップする行数です。 大きなデータ セットを操作するには、このパラメーターを使用します。 たとえば、top=10 と skip=0 を指定すると、データの最初の 10 行が取得され、top=10 と skip=10 を指定すると、データの次の 10 行が取得されます。 |  必須ではない  |
| filter |string  | 応答内の行をフィルター処理する 1 つまたは複数のステートメントです。 各ステートメントには、応答本文からのフィールド名、および **eq** 演算子または **ne** 演算子と関連付けられる値が含まれており、**and** や **or** を使用してステートメントを組み合わせることができます。 *filter* パラメーターでは、文字列値を単一引用符で囲む必要があります。 応答本文から次のフィールドを指定することができます。<p/><ul><li><strong>market</strong></li><li><strong>date</strong></li><li><strong>cabIdHash</strong></li><li><strong>cabExpirationTime</strong></li><li><strong>deviceType</strong></li><li><strong>deviceModel</strong></li><li><strong>osVersion</strong></li><li><strong>osRelease</strong></li><li><strong>applicationVersion</strong></li><li><strong>osBuild</strong></li><li><strong>fileName</strong></li></ul> | 必須ではない   |
| orderby | string | 結果データ値の順序を指定するステートメントです。 構文は <em>orderby=field [order],field [order],...</em> です。<em>field</em> パラメーターは次のいずれかの文字列になります。<ul><li><strong>market</strong></li><li><strong>date</strong></li><li><strong>cabIdHash</strong></li><li><strong>cabExpirationTime</strong></li><li><strong>deviceType</strong></li><li><strong>deviceModel</strong></li><li><strong>osVersion</strong></li><li><strong>osRelease</strong></li><li><strong>applicationVersion</strong></li><li><strong>osBuild</strong></li><li><strong>fileName</strong></li></ul><p><em>order</em> パラメーターは省略可能であり、<strong>asc</strong> または <strong>desc</strong> を指定して、各フィールドを昇順または降順にすることができます。 既定値は <strong>asc</strong> です。</p><p><em>orderby</em> 文字列の例: <em>orderby=date,market</em></p> |  必須ではない  |


### <a name="request-example"></a>要求の例

詳細なエラー データを取得するための要求の例を次に示します。 *applicationId* の値は、デスクトップ アプリケーションの製品 ID に置き換えてください。

```syntax
GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/desktop/failuredetails?applicationId=10238467886765136388&failureHash=012e33e3-dbc9-b12f-c124-9d9810f05d8b&startDate=2016-11-05&endDate=2016-11-06&top=10&skip=0 HTTP/1.1
Authorization: Bearer <your access token>

GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/desktop/failuredetails?applicationId=10238467886765136388&failureHash=012e33e3-dbc9-b12f-c124-9d9810f05d8b&startDate=2016-11-05&endDate=2016-11-06&top=10&skip=0&filter=market eq 'US' and deviceType eq 'PC' HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a>応答


### <a name="response-body"></a>応答本文

| 値      | 型    | 説明    |
|------------|---------|------------|
| Value      | array   | 詳細なエラー データが含まれているオブジェクトの配列です。 各オブジェクトのデータについて詳しくは、次の「[エラーの詳細情報の値](#error-detail-values)」セクションをご覧ください。          |
| @nextLink  | string  | データの追加ページがある場合、この文字列には、データの次のページを要求するために使用できる URI が含まれます。 たとえば、要求の **top** パラメーターを 10 に設定した場合、クエリに適合するエラーが 10 行を超えると、この値が返されます。 |
| TotalCount | 整数 | クエリの結果データ内の行の総数です。        |


<span id="error-detail-values"/>

### <a name="error-detail-values"></a>エラーの詳細情報の値

*Value* 配列の要素には、次の値が含まれます。

| 値           | 型    | 説明     |
|-----------------|---------|----------------------------|
| applicationId   | string  | エラーの詳細を取得したデスクトップ アプリケーションの製品 ID です。      |
| failureHash     | string  | エラーの一意の識別子です。     |
| failureName     | string  | 4 つの部分から成るエラーの名前です。問題が発生した 1 つ以上のクラス、例外/バグ チェック コード、障害が発生したイメージの名前、関連する関数の名前で構成されます。           |
| date            | string  | エラー データの日付範囲の最初の日付です。 要求に日付を指定した場合、この値はその日付になります。 要求に週、月、またはその他の日付範囲を指定した場合、この値はその日付範囲の最初の日付になります。 |
| cabIdHash           | string  | このエラーに関連付けられている CAB ファイルの一意の ID ハッシュです。   |
| cabExpirationTime  | string  | CAB ファイルの有効期限が切れ、ダウンロードできなくなる日付と時刻 (ISO 8601 形式) です。   |
| market          | string  | デバイスの市場の ISO 3166 国コードです。     |
| osBuild         | string  | エラーが発生した OS のビルド番号です。       |
| applicationVersion         | string  |   エラーが発生したアプリケーションの実行可能ファイルのバージョンです。     |
| deviceModel           | string  | エラーが発生したときにアプリを実行していたデバイスのモデルを指定する文字列です。   |
| osVersion       | string  | デスクトップ アプリケーションがインストールされている OS のバージョンを示す、以下のいずれかの文字列です。<p/><ul><li><strong>Windows 7</strong></li><li><strong>Windows 8.1</strong></li><li><strong>Windows 10</strong></li><li><strong>Windows Server 2016</strong></li><li><strong>Windows Server 1709</strong></li><li><strong>Unknown</strong></li></ul>    |
| osRelease       | string  |  エラーが発生した OS リリースまたはフライティング リングを (OS バージョン内のサブグループとして) 指定する、以下のいずれかの文字列です。<p/><p>Windows 10 の場合:</p><ul><li><strong>Version 1507</strong></li><li><strong>Version 1511</strong></li><li><strong>Version 1607</strong></li><li><strong>Version 1703</strong></li><li><strong>Version 1709</strong></li><li><strong>バージョン 1803</strong></li><li><strong>リリース プレビュー</strong></li><li><strong>Insider Fast</strong></li><li><strong>Insider Slow</strong></li></ul><p/><p>Windows Server 1709 の場合:</p><ul><li><strong>RTM</strong></li></ul><p>Windows Server 2016 の場合:</p><ul><li><strong>Version 1607</strong></li></ul><p>Windows 8.1 の場合:</p><ul><li><strong>Update 1</strong></li></ul><p>Windows 7 の場合:</p><ul><li><strong>Service Pack 1</strong></li></ul><p>OS リリースまたはフライティング リングが不明な場合、このフィールドは値 <strong>Unknown</strong> になります。</p>    |
| deviceType      | string  | エラーが発生したデバイスの種類を示す、以下のいずれかの文字列です。 <p/><ul><li><strong>PC</strong></li><li><strong>Server</strong></li><li><strong>Unknown</strong></li></ul>     |
| cabDownloadable           | Boolean  | このユーザーが CAB ファイルをダウンロードできるかどうかを示します。   |
| fileName           | string  | エラーの詳細を取得したデスクトップ アプリケーションの実行可能ファイルの名前です。  |


### <a name="response-example"></a>応答の例

この要求の JSON 応答の本文の例を次に示します。

```json
{
  "Value": [
    {
      "applicationId": "10238467886765136388",
      "failureHash": "012345-5dbc9-b12f-c124-9d9810f05d8b",
      "failureName": "NULL_CLASS_PTR_WRITE_c0000005_contoso.exe!unknown_error_in_process",
      "date": "2018-01-28 23:55:29",
      "cabIdHash": "54ffb83a-e159-41d2-8158-f36f306cc01e",
      "cabExpirationTime": "2018-02-27 23:55:29",
      "market": "US",
      "osBuild": "10.0.10240",
      "applicationVersion": "2.2.2.0",
      "deviceModel": "Contoso All-in-one",
      "osVersion": "Windows 10",
      "osRelease": "Version 1703",
      "deviceType": "PC",
      "cabDownloadable": false,
      "fileName": "contosodemo.exe"
    }
  ],
  "@nextLink": null,
  "TotalCount": 1
}
```

## <a name="related-topics"></a>関連トピック

* [[正常性] レポート](../publish/health-report.md)
* [Microsoft Store サービスを使った分析データへのアクセス](access-analytics-data-using-windows-store-services.md)
* [デスクトップ アプリケーションのエラー報告データの取得](get-desktop-application-error-reporting-data.md)
* [デスクトップ アプリケーションのエラーに関するスタック トレースの取得](get-the-stack-trace-for-an-error-in-your-desktop-application.md)
* [デスクトップ アプリケーションのエラーの CAB ファイルをダウンロードする](download-the-cab-file-for-an-error-in-your-desktop-application.md)
