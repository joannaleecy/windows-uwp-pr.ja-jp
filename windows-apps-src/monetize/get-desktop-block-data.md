---
description: この REST URI を使用して、特定の日付範囲とその他のオプションのフィルターの中にデスクトップ アプリケーションのブロックのデータを取得します。
title: デスクトップ アプリケーションのアップグレード ブロックの取得
ms.date: 07/11/2018
ms.topic: article
keywords: windows 10、デスクトップ アプリのブロック、Windows デスクトップ アプリケーション プログラム
localizationpriority: medium
ms.custom: RS5
ms.openlocfilehash: 08c3265fd0ff908c210a6586f561aba62ba9155a
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57641107"
---
# <a name="get-upgrade-blocks-for-your-desktop-application"></a>デスクトップ アプリケーションのアップグレード ブロックの取得

この REST URI を使用して、お客様のデスクトップ アプリケーションが、Windows 10 アップグレードの実行をブロックは、Windows 10 デバイスに関する情報を取得します。 この URI を使用して、デスクトップ アプリケーションに追加するだけで、 [Windows デスクトップ アプリケーション プログラム](https://docs.microsoft.com/windows/desktop/appxpkg/windows-desktop-application-program)します。 この情報も記載されて、[アプリケーション ブロック レポート](https://docs.microsoft.com/windows/desktop/appxpkg/windows-desktop-application-program#application-blocks-report)パートナー センターでのデスクトップ アプリケーションです。

デバイスのブロックに関する詳細、デスクトップ アプリケーションで特定された実行可能ファイルを取得する、次を参照してください。 [Get アップグレードはブロックのデスクトップ アプリケーションの詳細を](get-desktop-block-data-details.md)します。

## <a name="prerequisites"></a>前提条件

このメソッドを使うには、最初に次の作業を行う必要があります。

* Microsoft Store 分析 API に関するすべての[前提条件](access-analytics-data-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。
* このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら新しいトークンを取得できます。

## <a name="request"></a>要求


### <a name="request-syntax"></a>要求の構文

| メソッド | 要求 URI       |
|--------|----------------------|
| GET    | ```https://manage.devcenter.microsoft.com/v1.0/my/analytics/desktop/blockhits```|


### <a name="request-header"></a>要求ヘッダー

| Header        | 種類   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| Authorization | string | 必須。 **Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。 |


### <a name="request-parameters"></a>要求パラメーター

| パラメーター        | 種類   |  説明      |  必須  
|---------------|--------|---------------|------|
| applicationId | string | ブロックのデータを取得するデスクトップ アプリケーションの製品の ID。 デスクトップ アプリケーションの製品 ID を取得するには、いずれかを開く[analytics は、パートナー センターでデスクトップ アプリケーションのレポート](https://msdn.microsoft.com/library/windows/desktop/mt826504)(など、**ブロック レポート**) し、URL から、製品 ID を取得します。 |  〇  |
| startDate | date | 取得するデータ ブロックの日付範囲の開始日。 既定では、現在の日付の前に 90 日間です。 |  X  |
| endDate | date | 取得するデータ ブロックの日付範囲の終了日。 既定値は現在の日付です。 |  X  |
| top | int | 要求で返すデータの行数です。 最大値および指定しない場合の既定値は 10000 です。 クエリにこれを上回る行がある場合は、応答本文に次リンクが含まれ、そのリンクを使ってデータの次のページを要求できます。 |  X  |
| skip | int | クエリでスキップする行数です。 大きなデータ セットを操作するには、このパラメーターを使用します。 たとえば、top=10000 と skip=0 を指定すると、データの最初の 10,000 行が取得され、top=10000 と skip=10000 を指定すると、データの次の 10,000 行が取得されます。 |  X  |
| filter | string  | 応答内の行をフィルター処理する 1 つまたは複数のステートメントです。 各ステートメントには、応答本文からのフィールド名、および **eq** 演算子または **ne** 演算子と関連付けられる値が含まれており、**and** や **or** を使用してステートメントを組み合わせることができます。 *filter* パラメーターでは、文字列値を単一引用符で囲む必要があります。 応答本文から次のフィールドを指定することができます。<p/><ul><li><strong>applicationVersion</strong></li><li><strong>architecture</strong></li><li><strong>blockType</strong></li><li><strong>deviceType</strong></li><li><strong>fileName</strong></li><li><strong>market</strong></li><li><strong>osRelease</strong></li><li><strong>osVersion</strong></li><li><strong>ProductName</strong></li><li><strong>targetOs</strong></li></ul> | X   |
| orderby | string | 各ブロックのデータ値の結果を注文するステートメント。 構文は <em>orderby=field [order],field [order],...</em> です。<em>field</em> パラメーターには、応答本文から次のフィールドのいずれかを指定できます。<p/><ul><li><strong>applicationVersion</strong></li><li><strong>architecture</strong></li><li><strong>blockType</strong></li><li><strong>date</strong><li><strong>deviceType</strong></li><li><strong>fileName</strong></li><li><strong>market</strong></li><li><strong>osRelease</strong></li><li><strong>osVersion</strong></li><li><strong>ProductName</strong></li><li><strong>targetOs</strong></li><li><strong>deviceCount</strong></li></ul><p><em>order</em> パラメーターは省略可能であり、<strong>asc</strong> または <strong>desc</strong> を指定して、各フィールドを昇順または降順にすることができます。 既定値は <strong>asc</strong> です。</p><p><em>orderby</em> 文字列の例: <em>orderby=date,market</em></p> |  X  |
| groupby | string | 指定したフィールドのみにデータ集計を適用するステートメントです。 応答本文から次のフィールドを指定することができます。<p/><ul><li><strong>applicationVersion</strong></li><li><strong>architecture</strong></li><li><strong>blockType</strong></li><li><strong>deviceType</strong></li><li><strong>fileName</strong></li><li><strong>market</strong></li><li><strong>osRelease</strong></li><li><strong>osVersion</strong></li><li><strong>targetOs</strong></li></ul><p>返されるデータ行には、<em>groupby</em> パラメーターに指定したフィールドと次の値が含まれます。</p><ul><li><strong>applicationId</strong></li><li><strong>date</strong></li><li><strong>ProductName</strong></li><li><strong>deviceCount</strong></li></ul></p> |  X  |


### <a name="request-example"></a>要求の例

次の例では、デスクトップ アプリケーション ブロックのデータを取得するためのいくつかの要求を示します。 置換、 *applicationId*デスクトップ アプリケーションの製品 ID を持つ値。

```syntax
GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/desktop/blockhits?applicationId=5126873772241846776&startDate=2018-05-01&endDate=2018-06-07&skip=0 HTTP/1.1
Authorization: Bearer <your access token>

GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/desktop/blockhits?applicationId=5126873772241846776&startDate=2018-05-01&endDate=2018-06-07&filter=market eq 'US' and deviceType eq 'PC' HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a>応答


### <a name="response-body"></a>応答本文

| Value      | 種類   | 説明                  |
|------------|--------|-------------------------------------------------------|
| Value      | array  | 集計のブロックでデータを格納するオブジェクトの配列。 各オブジェクトのデータの詳細については、以下の表を参照してください。 |
| @nextLink  | string | データの追加ページがある場合、この文字列には、データの次のページを要求するために使用できる URI が含まれます。 この値が返される場合など、**上部**10000 に、要求のパラメーターが設定されているが、クエリのブロックでデータの 10000 個を超える行があります。 |
| TotalCount | int    | クエリの結果データ内の行の総数です。 |


*Value* 配列の要素には、次の値が含まれます。

| Value               | 種類   | 説明                           |
|---------------------|--------|-------------------------------------------|
| applicationId       | string | ブロックでデータを取得し、デスクトップ アプリケーションの製品の ID。 |
| date                | string | ブロックのヒット数の値に関連付けられた日付。 |
| productName         | string | デスクトップ アプリケーションの表示名です。アプリケーションに関連付けられている実行可能ファイルのメタデータから取得されます。 |
| fileName            | string | ブロックされた実行可能ファイル。 |
| applicationVersion  | string | ブロックされたアプリケーションの実行可能ファイルのバージョン。 |
| osVersion           | string | デスクトップ アプリケーションが現在実行されている OS バージョンを指定する次の文字列のいずれか:<p/><ul><li><strong>Windows 7</strong></li><li><strong>Windows 8.1</strong></li><li><strong>Windows 10</strong></li><li><strong>Windows Server 2016</strong></li><li><strong>Windows Server 1709</strong></li><li><strong>Unknown</strong></li></ul>   |
| osRelease           | string | (OS のバージョン内で subpopulation) として、デスクトップ アプリケーションが現在実行されている OS のリリースまたはフライト リングを指定する次の文字列の 1 つ。<p/><p>Windows 10 の場合:</p><ul><li><strong>バージョン 1507</strong></li><li><strong>バージョン 1511</strong></li><li><strong>バージョン 1607</strong></li><li><strong>バージョン 1703</strong></li><li><strong>バージョン 1709</strong></li><li><strong>Release Preview</strong></li><li><strong>Insider Fast</strong></li><li><strong>低速 insider</strong></li></ul><p/><p>Windows Server 1709 の場合:</p><ul><li><strong>RTM</strong></li></ul><p>Windows Server 2016 の場合:</p><ul><li><strong>バージョン 1607</strong></li></ul><p>Windows 8.1 の場合:</p><ul><li><strong>更新プログラム 1</strong></li></ul><p>Windows 7 の場合:</p><ul><li><strong>Service Pack 1</strong></li></ul><p>OS リリースまたはフライティング リングが不明な場合、このフィールドは値 <strong>Unknown</strong> になります。</p> |
| market              | string | デスクトップ アプリケーションがブロックされている市場の ISO 3166 国コード。 |
| deviceType          | string | デスクトップ アプリケーションがブロックされているデバイスの種類を指定する次の文字列のいずれか:<p/><ul><li><strong>PC</strong></li><li><strong>サーバー</strong></li><li><strong>タブレット</strong></li><li><strong>Unknown</strong></li></ul> |
| blockType            | string | 次のブロックは、デバイスの種類を指定する文字列のいずれか:<p/><ul><li><strong>潜在的な Sediment</strong></li><li><strong>一時 Sediment</strong></li><li><strong>実行時の通知</strong></li></ul><p/><p/>これらのブロック型と、開発者とユーザーへの影響の詳細については、の説明を参照して、[アプリケーション ブロック レポート](https://docs.microsoft.com/windows/desktop/appxpkg/windows-desktop-application-program#application-blocks-report)します。  |
| architecture        | string | ブロックが存在するデバイスのアーキテクチャ: <p/><ul><li><strong>ARM64</strong></li><li><strong>X86</strong></li></ul> |
| targetOs            | string | 実行するデスクトップ アプリケーションがブロックされている Windows 10 の OS のリリースを指定します、次の文字列のいずれか: <p/><ul><li><strong>バージョン 1709</strong></li><li><strong>バージョン 1803</strong></li></ul> |
| deviceCount         | number | 指定された集計レベルでブロックがある個別のデバイスの数。 |


### <a name="response-example"></a>応答の例

この要求の JSON 返信の本文の例を次に示します。

```json
{
  "Value": [
    {
     "applicationId": "10238467886765136388",
     "date": "2018-06-03",
     "productName": "Contoso Demo",
     "fileName": "contosodemo.exe",
     "applicationVersion": "2.2.2.0",
     "osVersion": "Windows 8.1",
     "osRelease": "Update 1",
     "market": "ZA",
     "deviceType": "All",
     "blockType": "Runtime Notification",
     "architecture": "X86",
     "targetOs": "RS4",
     "deviceCount": 120
    }
  ],
  "@nextLink": "desktop/blockhits?applicationId=123456789&startDate=2018-01-01&endDate=2018-02-01&top=10000&skip=10000&groupby=applicationVersion,deviceType,osVersion,osRelease",
  "TotalCount": 23012
}
```

## <a name="related-topics"></a>関連トピック

* [Windows デスクトップ アプリケーション プログラム](https://docs.microsoft.com/windows/desktop/appxpkg/windows-desktop-application-program)
* [お客様のデスクトップ アプリケーションのアップグレードはブロックの詳細を取得します。](get-desktop-block-data-details.md)
