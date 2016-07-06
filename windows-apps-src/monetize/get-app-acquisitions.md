---
author: mcleanbyron
ms.assetid: C1E42E8B-B97D-4B09-9326-25E968680A0F
description: "特定の日付範囲などのオプション フィルターを使ってアプリケーションの集計入手データを取得するには、Windows ストア分析 API でこのメソッドを使います。"
title: "アプリの入手数の取得"
ms.sourcegitcommit: 02131e641cdaa76256845b38bcc50aa42d718601
ms.openlocfilehash: 7f87f931c92eca1f64fbd23b4fcba3359293f94a

---

# アプリの入手数の取得


\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください \]

特定の日付範囲などのオプション フィルターを使ってアプリケーションの集計入手データを取得するには、Windows ストア分析 API でこのメソッドを使います。 このメソッドは、データを JSON 形式で返します。

## 前提条件


このメソッドを使うには、次の作業が必要です。

-   このメソッドの呼び出しに使う Azure AD アプリケーションをデベロッパー センター アカウントに関連付けます。

-   アプリケーションの Azure AD アクセス トークンを取得します。

詳しくは、「[Windows ストア サービスを使った分析データへのアクセス](access-analytics-data-using-windows-store-services.md)」をご覧ください。

## 要求


### 要求の構文

| メソッド | 要求 URI                                                              |
|--------|--------------------------------------------------------------------------|
| GET    | https://manage.devcenter.microsoft.com/v1.0/my/analytics/appacquisitions |

 

### 要求ヘッダー

| ヘッダー        | 型   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| Authorization | string | 必須。 **Bearer**&lt;*token*&gt; という形式の Azure AD アクセス トークン。 |

 

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
<td align="left">入手データを取得するアプリのストア ID です。 ストア ID は、デベロッパー センター ダッシュボードの[アプリ ID ページ](../publish/view-app-identity-details.md)で確認できます。 ストア ID の例は 9WZDNCRFJ3Q8 です。</td>
<td align="left">○</td>
</tr>
<tr class="even">
<td align="left">startDate</td>
<td align="left">date</td>
<td align="left">取得する入手データの日付範囲の開始日です。 既定値は現在の日付です。</td>
<td align="left">×</td>
</tr>
<tr class="odd">
<td align="left">endDate</td>
<td align="left">date</td>
<td align="left">取得する入手データの日付範囲終了日です。 既定値は現在の日付です。</td>
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
<td align="left">応答内の行をフィルター処理する 1 つまたは複数のステートメントです。 詳しくは、次の「[フィルター フィールド](#filter-fields)」セクションをご覧ください。</td>
<td align="left">いいえ</td>
</tr>
<tr class="odd">
<td align="left">aggregationLevel</td>
<td align="left">string</td>
<td align="left">集計データを取得する時間範囲を指定します。 次のいずれかの文字列を指定できます。<strong>day</strong>、<strong>week</strong>、または <strong>month</strong>。 指定されていない場合、既定値は <strong>day</strong> です。</td>
<td align="left">×</td>
</tr>
<tr class="even">
<td align="left">orderby</td>
<td align="left">string</td>
<td align="left">それぞれの入手数について結果データ値の順序を指定するステートメントです。 構文は <em>orderby=field [order],field [order],...</em> です。 <em>field</em> パラメーターには、次のいずれかの文字列を指定できます。
<ul>
<li><strong>date</strong></li>
<li><strong>acquisitionType</strong></li>
<li><strong>ageGroup</strong></li>
<li><strong>storeClient</strong></li>
<li><strong>gender</strong></li>
<li><strong>market</strong></li>
<li><strong>osVersion</strong></li>
<li><strong>deviceType</strong></li>
<li><strong>orderName</strong></li>
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
<td align="left">acquisitionType</td>
<td align="left">次のいずれかの文字列です。
<ul>
<li><strong>free</strong></li>
<li><strong>trial</strong></li>
<li><strong>paid</strong></li>
<li><strong>promotional code</strong></li>
<li><strong>iap</strong></li>
</ul></td>
</tr>
<tr class="even">
<td align="left">ageGroup</td>
<td align="left">次のいずれかの文字列です。
<ul>
<li><strong>less than 13</strong></li>
<li><strong>13-17</strong></li>
<li><strong>18-24</strong></li>
<li><strong>25-34</strong></li>
<li><strong>35-44</strong></li>
<li><strong>44-55</strong></li>
<li><strong>greater than 55</strong></li>
<li><strong>Unknown</strong></li>
</ul></td>
</tr>
<tr class="odd">
<td align="left">storeClient</td>
<td align="left">次のいずれかの文字列です。
<ul>
<li><strong>Windows Phone Store (client)</strong></li>
<li><strong>Windows Store (client)</strong></li>
<li><strong>Windows Store (web)</strong></li>
<li><strong>Volume purchase by organizations</strong></li>
<li><strong>Other</strong></li>
</ul></td>
</tr>
<tr class="even">
<td align="left">gender</td>
<td align="left">次のいずれかの文字列です。
<ul>
<li><strong>m</strong></li>
<li><strong>f</strong></li>
<li><strong>Unknown</strong></li>
</ul></td>
</tr>
<tr class="odd">
<td align="left">market</td>
<td align="left">入手が発生した市場の ISO 3166 国コードを含む文字列です。</td>
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
<td align="left">orderName</td>
<td align="left">アプリを入手するために使用されたプロモーション コードの注文の名前を指定する文字列です (このフィールドは、ユーザーがプロモーション コードを利用してアプリを入手した場合のみに適用されます)。</td>
</tr>
</tbody>
</table>

 

### 要求の例

アプリの入手データを取得するためのいくつかの要求の例を次に示します。 *applicationId* 値を、目的のアプリのストア ID に置き換えてください。

```syntax
GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/appacquisitions?applicationId=9NBLGGGZ5QDR&startDate=1/1/2015&endDate=2/1/2015&top=10&skip=0  HTTP/1.1
Authorization: Bearer <your access token>

GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/appacquisitions?applicationId=9NBLGGGZ5QDR&startDate=8/1/2015&endDate=8/31/2015&skip=0&filter=market eq 'US'; and gender eq 'm'  HTTP/1.1
Authorization: Bearer <your access token>
```

## 応答


### 応答本文

| 値      | 型   | 説明                                                                                                                                                                                                                                                                            |
|------------|--------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Value      | array  | 集計評価データが含まれるオブジェクトの配列です。 各オブジェクトのデータについて詳しくは、次の「[入手値](#acquisition-values)」セクションをご覧ください。                                                                                                                      |
| @nextLink  | string | データの追加ページがある場合、この文字列には、データの次のページを要求するために使用できる URI が含まれます。 たとえば、要求の **top** パラメーターが 10000 に設定されたが、クエリの入手データに 10,000 を超える行が含まれている場合に、この値が返されます。 |
| TotalCount | int    | クエリの結果データ内の行の総数です。                                                                                                                                                                                                                             |

 
### 入手値

*Value* 配列の要素には、次の値が含まれます。

| 値               | 型   | 説明                                                                                                                                                                                                                              |
|---------------------|--------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| date                | string | 入手データの日付範囲の最初の日付です。 要求に日付を指定した場合、この値はその日付になります。 要求に週、月、またはその他の日付範囲を指定した場合、この値はその日付範囲の最初の日付になります。 |
| applicationId       | string | 入手データを取得するアプリのストア ID です。                                                                                                                                                                 |
| applicationName     | string | アプリの表示名です。                                                                                                                                                                                                             |
| deviceType          | string | 入手を完了したデバイスの種類です。 サポートされる文字列の一覧については、前の「[フィルター フィールド](#filter-fields)」セクションをご覧ください。                                                                                                  |
| orderName           | string | 注文の名前。                                                                                                                                                                                                                   |
| storeClient         | string | 入手が発生したストアのバージョンです。 サポートされる文字列の一覧については、前の「[フィルター フィールド](#filter-fields)」セクションをご覧ください。                                                                                            |
| osVersion           | string | 入手が発生した OS のバージョンです。 サポートされる文字列の一覧については、前の「[フィルター フィールド](#filter-fields)」セクションをご覧ください。                                                                                                   |
| market              | string | 入手が発生した市場の ISO 3166 国コードです。                                                                                                                                                                  |
| gender              | string | 入手を行ったユーザーの性別です。 サポートされる文字列の一覧については、前の「[フィルター フィールド](#filter-fields)」セクションをご覧ください。                                                                                                    |
| ageGroup            | string | 入手を行ったユーザーの年齢グループです。 サポートされる文字列の一覧については、前の「[フィルター フィールド](#filter-fields)」セクションをご覧ください。                                                                                                 |
| acquisitionType     | string | 入手の種類です (無料、有料など)。 サポートされる文字列の一覧については、前の「[フィルター フィールド](#filter-fields)」セクションをご覧ください。                                                                                                    |
| acquisitionQuantity | number | 指定された集計レベルで発生した入手の数です。                                                                                                                                                         |

 

### 応答の例

この要求の JSON 応答の本文の例を次に示します。

```json
{
  "Value": [
    {
      "date": "2016-02-01",
      "applicationId": "9NBLGGGZ5QDR",
      "applicationName": "Contoso Demo",
      "deviceType": "Phone",
      "orderName": "",
      "storeClient": "Windows Phone Store (client)",
      "osVersion": "Windows Phone 8.1",
      "market": "IT",
      "gender": "m",
      "ageGroup": "0-17",
      "acquisitionType": "Free",
      "acquisitionQuantity": 1
    }
  ],
  "@nextLink": "appacquisitions?applicationId=9NBLGGGZ5QDR&aggregationLevel=day&startDate=2015/01/01&endDate=2016/02/01&top=1&skip=1&orderby=date desc",
  "TotalCount": 466766
}
```

## 関連トピック

* [Windows ストア サービスを使った分析データへのアクセス](access-analytics-data-using-windows-store-services.md)
* [IAP の入手数の取得](get-in-app-acquisitions.md)
* [エラー報告データの取得](get-error-reporting-data.md)
* [アプリの評価の取得](get-app-ratings.md)
* [アプリのレビューの取得](get-app-reviews.md)



<!--HONumber=Jun16_HO5-->


