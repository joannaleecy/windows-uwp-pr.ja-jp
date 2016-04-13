---
ms.assetid: 252C44DF-A2B8-4F4F-9D47-33E423F48584
description: 特定の日付範囲などのオプション フィルターを使って集計エラー報告データを取得するには、Windows ストア分析 API でこのメソッドを使います。
title: エラー報告データの取得
---

# エラー報告データの取得


\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください \]

特定の日付範囲などのオプション フィルターを使って集計エラー報告データを取得するには、Windows ストア分析 API でこのメソッドを使います。 このメソッドは、データを JSON 形式で返します。

## 前提条件


このメソッドを使うには、次の作業が必要です。

-   このメソッドの呼び出しに使う Azure AD アプリケーションをデベロッパー センター アカウントに関連付けます。

-   アプリケーションの Azure AD アクセス トークンを取得します。

詳しくは、「[Windows ストア サービスを使った分析データへのアクセス](access-analytics-data-using-windows-store-services.md)」をご覧ください。

## 要求


### 要求の構文

| メソッド | 要求 URI                                                          |
|--------|----------------------------------------------------------------------|
| GET    | https://manage.devcenter.microsoft.com/v1.0/my/analytics/failurehits |

 

### 要求ヘッダー

| ヘッダー        | 型   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| Authorization | string | 必須。 **ベアラー** &lt;*トークン*&gt; 形式の Azure AD アクセス トークンです。 |

 

### 要求本文

<table>
<colgroup>
<col width="25%" />
<col width="25%" />
<col width="25%" />
<col width="25%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">パラメーター</th>
<th align="left">型</th>
<th align="left">説明</th>
<th align="left">必須</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left">applicationId</td>
<td align="left">string</td>
<td align="left">エラー報告データを取得するアプリの製品 ID です。 製品 ID は、デベロッパー センター ダッシュボードの [App identity page](https://msdn.microsoft.com/library/windows/apps/mt148561)に表示されるアプリの内容へのリンクに埋め込まれています。 製品 ID の例は 9WZDNCRFJ3Q8 です。</td>
<td align="left">○</td>
</tr>
<tr class="even">
<td align="left">startDate</td>
<td align="left">date</td>
<td align="left">取得するエラー報告データの日付範囲の開始日です。 既定値は現在の日付です。</td>
<td align="left">×</td>
</tr>
<tr class="odd">
<td align="left">endDate</td>
<td align="left">date</td>
<td align="left">取得するエラー報告データの日付範囲の終了日です。 既定値は現在の日付です。</td>
<td align="left">×</td>
</tr>
<tr class="even">
<td align="left">top</td>
<td align="left">int</td>
<td align="left">要求で返すデータの行数です。 指定されない場合の既定値は、最大値でもある 10000 です。 クエリにこれを上回る行がある場合は、応答本文に次リンクが含まれ、そのリンクを使ってデータの次のページを要求できます。</td>
<td align="left">×</td>
</tr>
<tr class="odd">
<td align="left">skip</td>
<td align="left">int</td>
<td align="left">クエリでスキップする行数です。 大きなデータ セットを操作するには、このパラメーターを使用します。 たとえば、top=10000 と skip=0 を指定すると、データの最初の 10,000 行が取得され、top=10000 と skip=10000 を指定すると、データの次の 10,000 行が取得されます。</td>
<td align="left">×</td>
</tr>
<tr class="even">
<td align="left">filter</td>
<td align="left">string</td>
<td align="left">応答内の行をフィルター処理する 1 つまたは複数のステートメントです。 詳しくは、次の「[filter fields](#filter-fields)」セクションをご覧ください。</td>
<td align="left">×</td>
</tr>
<tr class="odd">
<td align="left">aggregationLevel</td>
<td align="left">string</td>
<td align="left">集計データを取得する時間範囲を指定します。 次のいずれかの文字列を指定できます。<strong>day</strong>、<strong>week</strong>、または <strong>month</strong>。 指定されていない場合、既定値は <strong>day</strong> です。 <strong>week</strong> または <strong>month</strong> を指定した場合、<em>failureName</em> と <em>failureHash</em> の値は 1,000 バケットに制限されます。</td>
<td align="left">×</td>
</tr>
<tr class="even">
<td align="left">groupby</td>
<td align="left">string</td>
<td align="left">データ集計を指定したフィールドのみに適用するステートメントです。 次のフィールドを指定できます。
<ul>
<li><strong>failureName</strong></li>
<li><strong>failureHash</strong></li>
<li><strong>symbol</strong></li>
<li><strong>osVersion</strong></li>
<li><strong>eventType</strong></li>
<li><strong>market</strong></li>
<li><strong>deviceType</strong></li>
<li><strong>packageName</strong></li>
<li><strong>packageVersion</strong></li>
</ul>
<p>返されるデータ行には、<em>groupby</em> パラメーターに指定したフィールドと次の値が含まれます。</p>
<ul>
<li><strong>date</strong></li>
<li><strong>applicationId</strong></li>
<li><strong>applicationName</strong></li>
<li><strong>deviceCount</strong></li>
<li><strong>eventCount</strong></li>
</ul>
<p><em>groupby</em> パラメーターは、<em>aggregationLevel</em> パラメーターと同時に使用できます。 例: <em>&amp;groupby=failureName,market&amp;aggregationLevel=week</em></p></td>
<td align="left"></td>
</tr>
<tr class="odd">
<td align="left">orderby</td>
<td align="left">string</td>
<td align="left">それぞれの入手数について結果データ値の順序を指定するステートメントです。 構文は <em>orderby=field [order],field [order],...</em> です。 <em>field</em> パラメーターには、次のいずれかの文字列を指定できます。
<ul>
<li><strong>date</strong></li>
<li><strong>failureName</strong></li>
<li><strong>failureHash</strong></li>
<li><strong>symbol</strong></li>
<li><strong>osVersion</strong></li>
<li><strong>eventType</strong></li>
<li><strong>market</strong></li>
<li><strong>deviceType</strong></li>
<li><strong>packageName</strong></li>
<li><strong>packageVersion</strong></li>
</ul>
<p><em>order</em> パラメーターは省略可能であり、<strong>asc</strong> または <strong>desc</strong> を指定して、各フィールドを昇順または降順にすることができます。 既定値は <strong>asc</strong> です。</p>
<p>例: <em>orderby</em> string: <em>orderby=date,market</em></p></td>
<td align="left">×</td>
</tr>
</tbody>
</table>

 
### フィルター フィールド

要求本文の *filter* パラメーターには、応答内の行をフィルター処理する 1 つまたは複数のステートメントが含まれます。 各ステートメントには **eq** 演算子または **ne** 演算子と関連付けられるフィールドと値が含まれ、**and** または **or** を使ってステートメントを組み合わせることができます。 *filter* パラメーターの例を次に示します。

-   *filter=market eq 'US' and gender eq 'm'*
-   *filter=(market ne 'US') and (gender ne 'Unknown') and (gender ne 'm') and (market ne 'NO') and (ageGroup ne 'greater than 55' or ageGroup ne ‘less than 13’)*

サポートされているフィールドの一覧については、次の表をご覧ください。 *filter* パラメーターでは、文字列値は単一引用符で囲む必要があります。

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">フィールド</th>
<th align="left">説明</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left">failureName</td>
<td align="left">エラーの名前です。</td>
</tr>
<tr class="even">
<td align="left">failureHash</td>
<td align="left">エラーの一意の識別子です。</td>
</tr>
<tr class="odd">
<td align="left">symbol</td>
<td align="left">このエラーに割り当てられた記号です。</td>
</tr>
<tr class="even">
<td align="left">osVersion</td>
<td align="left">次のいずれかの文字列です。
<ul>
<li><strong>Windows Phone 7.5</strong></li>
<li><strong>Windows Phone 8</strong></li>
<li><strong>Windows Phone 8.1</strong></li>
<li><strong>Windows Phone 10</strong></li>
<li><strong>Windows 8</strong></li>
<li><strong>Windows 8.1</strong></li>
<li><strong>Windows 10</strong></li>
<li><strong>Unknown</strong></li>
</ul></td>
</tr>
<tr class="odd">
<td align="left">eventType</td>
<td align="left">次のいずれかの文字列です。
<ul>
<li><strong>crash</strong></li>
<li><strong>hang</strong></li>
<li><strong>memory</strong></li>
<li><strong>jse</strong></li>
</ul></td>
</tr>
<tr class="even">
<td align="left">market</td>
<td align="left">デバイス市場の ISO 3166 国コードを含む文字列です。</td>
</tr>
<tr class="odd">
<td align="left">deviceType</td>
<td align="left">次のいずれかの文字列です。
<ul>
<li><strong>PC</strong></li>
<li><strong>Tablet</strong></li>
<li><strong>Phone</strong></li>
<li><strong>IoT</strong></li>
<li><strong>Wearable</strong></li>
<li><strong>Server</strong></li>
<li><strong>Collaborative</strong></li>
<li><strong>Other</strong></li>
</ul></td>
</tr>
<tr class="even">
<td align="left">packageName</td>
<td align="left">このエラーに関連付けられているアプリ パッケージの一意の名前です。</td>
</tr>
<tr class="odd">
<td align="left">packageVersion</td>
<td align="left">このエラーに関連付けられているアプリ パッケージのバージョンです。</td>
</tr>
</tbody>
</table>

 

### 要求の例

エラー報告データを取得するためのいくつかの要求の例を次に示します。 *applicationId* 値を、目的のアプリの製品 ID に置き換えてください。

```
GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/failurehits?applicationId=9NBLGGGZ5QDR&startDate=1/1/2015&endDate=2/1/2015&top=10&skip=0 HTTP/1.1
Authorization: Bearer <your access token>

GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/failurehits?applicationId=9NBLGGGZ5QDR&startDate=8/1/2015&endDate=8/31/2015&skip=0&filter=market eq 'US' and deviceType eq 'phone' HTTP/1.1
Authorization: Bearer <your access token>
```

## 応答


### 応答本文

| 値      | 型    | 説明                                                                                                                                                                                                                                                                    |
|------------|---------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Value      | array   | 集計エラー報告データが含まれるオブジェクトの配列です。 各オブジェクトのデータについて詳しくは、次の「[エラー値](#error-values)」セクションをご覧ください。                                                                                                          |
| @nextLink  | string  | データの追加ページがある場合、この文字列には、データの次のページを要求するために使用できる URI が含まれます。 たとえば、要求の **top** パラメーターが 10000 に設定されたが、クエリの入手データに 10,000 を超えるエラー行が含まれている場合に、この値が返されます。 |
| TotalCount | inumber | クエリの結果データ内の行の総数です。                                                                                                                                                                                                                     |

 
### エラー値

*Value* 配列の要素には、次の値が含まれます。

| 値           | 型    | 説明                                                                                                                                                                                                                              |
|-----------------|---------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| date            | string  | 入手データの日付範囲の最初の日付です。 要求に日付を指定した場合、この値はその日付になります。 要求に週、月、またはその他の日付範囲を指定した場合、この値はその日付範囲の最初の日付になります。 |
| applicationId   | string  | IAP 入手データを取得するアプリの製品 ID です。                                                                                                                                                           |
| applicationName | string  | アプリの表示名です。                                                                                                                                                                                                             |
| failureName     | string  | エラーの名前です。                                                                                                                                                                                                                 |
| failureHash     | string  | エラーの一意の識別子です。                                                                                                                                                                                                   |
| symbol          | string  | このエラーに割り当てられた記号です。                                                                                                                                                                                                       |
| osVersion       | string  | エラーが発生した OS のバージョンです。 サポートされる文字列の一覧については、前の「[フィルター フィールド](#filter-fields)」セクションをご覧ください。                                                                                                       |
| eventType       | string  | エラー イベントの種類です。 サポートされる文字列の一覧については、前の「[フィルター フィールド](#filter-fields)」セクションをご覧ください。                                                                                                                          |
| market          | string  | デバイス市場の ISO 3166 国コードです。                                                                                                                                                                                          |
| deviceType      | string  | 入手を完了したデバイスの種類です。 サポートされる文字列の一覧については、前の「[フィルター フィールド](#filter-fields)」セクションをご覧ください。                                                                                                  |
| packageName     | string  | このエラーに関連付けられているアプリ パッケージの一意の名前です。                                                                                                                                                                 |
| packageVersion  | string  | このエラーに関連付けられているアプリ パッケージのバージョンです。                                                                                                                                                                     |
| eventCount      | inumber | 指定した集計レベルでこのエラーに起因すると考えられるイベントの数です。                                                                                                                                            |
| deviceCount     | inumber | 指定した集計レベルでこのエラーに対応する一意のデバイスの数です。                                                                                                                                        |

 

### 応答の例

この要求の JSON 応答の本文の例を次に示します。

```json
{
  "Value": [
    {
      "date": "2015-03-09",
      "applicationId": "9NBLGGGZ5QDR",
      "applicationName": "Contoso Demo",
      "failureName": "APPLICATION_FAULT_8013150a_StoreWrapper.ni.DLL!70475e55",
      "failureHash": "5a6b2170-1661-ed47-24d7-230fed0077af",
      "symbol": "storewrapper_ni!70475e55",
      "osVersion": "Windows Phone 8",
      "eventType": "crash",
      "market": "US",
      "deviceType": "mobile",
      "packageName": "",
      "packageVersion": "0.0.0.0",
      "deviceCount": 0.0,
      "eventCount": 1.0
    }
  ],
  "@nextLink": "failurehits?applicationId=9NBLGGGZ5QDR&aggregationLevel=week&startDate=2015/03/01&endDate=2016/02/01&top=1&skip=1",
  "TotalCount": 191753
}

```

## 関連トピック

* [Windows ストア サービスを使った分析データへのアクセス](access-analytics-data-using-windows-store-services.md)
* [アプリの入手数の取得](get-app-acquisitions.md)
* [IAP の入手数の取得](get-in-app-acquisitions.md)
* [アプリの評価の取得](get-app-ratings.md)
* [アプリのレビューの取得](get-app-reviews.md)


<!--HONumber=Mar16_HO2-->


