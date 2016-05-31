---
author: mcleanbyron
ms.assetid: DD4F6BC4-67CD-4AEF-9444-F184353B0072
description: 特定の日付範囲などのオプション フィルターを使って集計評価データを取得するには、Windows ストア分析 API でこのメソッドを使います。
title: アプリの評価の取得
---

# アプリの評価の取得


\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください \]

特定の日付範囲などのオプション フィルターを使って集計評価データを取得するには、Windows ストア分析 API でこのメソッドを使います。 このメソッドは、データを JSON 形式で返します。

## 前提条件


このメソッドを使うには、次の作業が必要です。

-   このメソッドの呼び出しに使う Azure AD アプリケーションをデベロッパー センター アカウントに関連付けます。

-   アプリケーションの Azure AD アクセス トークンを取得します。

詳しくは、「[Windows ストア サービスを使った分析データへのアクセス](access-analytics-data-using-windows-store-services.md)」をご覧ください。

## 要求


### 要求の構文

| メソッド | 要求 URI                                                      |
|--------|------------------------------------------------------------------|
| GET    | https://manage.devcenter.microsoft.com/v1.0/my/analytics/ratings |

 

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
<th align="left">必須かどうか</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left">applicationId</td>
<td align="left">string</td>
<td align="left">評価データを取得するアプリの製品 ID です。 製品 ID は、デベロッパー センター ダッシュボードの [[アプリ ID] ページ](https://msdn.microsoft.com/library/windows/apps/mt148561)に表示されるアプリの内容へのリンクに埋め込まれています。 製品 ID の例は 9WZDNCRFJ3Q8 です。</td>
<td align="left">○</td>
</tr>
<tr class="even">
<td align="left">startDate</td>
<td align="left">date</td>
<td align="left">取得する評価データの日付範囲の開始日です。 既定値は現在の日付です。</td>
<td align="left">×</td>
</tr>
<tr class="odd">
<td align="left">endDate</td>
<td align="left">date</td>
<td align="left">取得する評価データの日付範囲の終了日です。 既定値は現在の日付です。</td>
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
<td align="left">各評価の結果データ値の順序を指定するステートメントです。 構文は <em>orderby=field [order],field [order],...</em> です。 <em>field</em> パラメーターには、次のいずれかの文字列を指定できます。
<ul>
<li><strong>date</strong></li>
<li><strong>osVersion</strong></li>
<li><strong>market</strong></li>
<li><strong>deviceType</strong></li>
<li><strong>isRevised</strong></li>
</ul>
<p><em>order</em> パラメーターは省略可能であり、<strong>asc</strong> または <strong>desc</strong> を指定して、各フィールドを昇順または降順にすることができます。 既定値は <strong>asc</strong> です。</p>
<p>例: <em>orderby</em> string: <em>orderby=date,market</em></p></td>
<td align="left">×</td>
</tr>
</tbody>
</table>

 
### フィルター フィールド

要求本文の *filter* パラメーターには、応答内の行をフィルター処理する 1 つまたは複数のステートメントが含まれます。 各ステートメントには **eq** 演算子または **ne** 演算子と関連付けられるフィールドと値が含まれ、**and** または **or** を使ってステートメントを組み合わせることができます。

*filter* 文字列の例は次のとおりです。*filter=market eq 'US' and deviceType eq 'phone' and isRevised eq true*

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
<td align="left">market</td>
<td align="left">デバイス市場の ISO 3166 国コードを含む文字列です。</td>
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
<td align="left">isRevised</td>
<td align="left">更新されている評価をフィルター処理するには <strong>true</strong> を指定します。それ以外の場合は <strong>false</strong> を指定します。</td>
</tr>
</tbody>
</table>

 

### 要求の例

評価データを取得するためのいくつかの要求の例を次に示します。 *applicationId* 値を、目的のアプリの製品 ID に置き換えてください。

```syntax
GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/ratings?applicationId=9NBLGGGZ5QDR&startDate=1/1/2015&endDate=2/1/2015&top=10&skip=0 HTTP/1.1
Authorization: Bearer <your access token>

GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/ratings?applicationId=9NBLGGGZ5QDR&startDate=8/1/2015&endDate=8/31/2015&skip=0&filter=market eq 'US' and deviceType eq 'phone' HTTP/1.1
Authorization: Bearer <your access token>
```

## 応答


### 応答本文

| 値      | 型   | 説明                                                                                                                                                                                                                                                                            |
|------------|--------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Value      | array  | 集計評価データが含まれるオブジェクトの配列です。 各オブジェクトのデータについて詳しくは、次の「[評価値](#rating-values)」セクションをご覧ください。                                                                                                                           |
| @nextLink  | string | データの追加ページがある場合、この文字列には、データの次のページを要求するために使用できる URI が含まれます。 たとえば、要求の **top** パラメーターが 10000 に設定されたが、クエリの入手データに 10,000 を超える行が含まれている場合に、この値が返されます。 |
| TotalCount | int    | クエリの結果データ内の行の総数です。                                                                                                                                                                                                                             |

 
### 評価値

*Value* 配列の要素には、次の値が含まれます。

| 値           | 型    | 説明                                                                                                                                                                                                                          |
|-----------------|---------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| date            | string  | 評価データの日付範囲の最初の日付です。 要求に日付を指定した場合、この値はその日付になります。 要求に週、月、またはその他の日付範囲を指定した場合、この値はその日付範囲の最初の日付になります。 |
| applicationId   | string  | 評価データを取得するアプリの製品 ID です。                                                                                                                                                                 |
| applicationName | string  | アプリの表示名です。                                                                                                                                                                                                         |
| market          | string  | 評価が送信された市場の ISO 3166 国コードです。                                                                                                                                                              |
| osVersion       | string  | 評価が送信された OS バージョンです。 サポートされる文字列の一覧については、前の「[フィルター フィールド](#filter-fields)」セクションをご覧ください。                                                                                               |
| deviceType      | string  | 評価が送信されたデバイスの種類です。 サポートされる文字列の一覧については、前の「[フィルター フィールド](#filter-fields)」セクションをご覧ください。                                                                                           |
| isRevised       | Boolean | 値 **true** は、評価が更新済みであることを示します。それ以外の場合は **false** です。                                                                                                                                                       |
| oneStar         | number  | 1 つ星評価の数です。                                                                                                                                                                                                      |
| twoStars        | number  | 2 つ星評価の数です。                                                                                                                                                                                                      |
| threeStars      | number  | 3 つ星評価の数です。                                                                                                                                                                                                    |
| fourStars       | number  | 4 つ星評価の数です。                                                                                                                                                                                                     |
| fiveStars       | number  | 5 つ星評価の数です。                                                                                                                                                                                                     |

 

### 応答の例

この要求の JSON 応答の本文の例を次に示します。

```json
{
  "Value": [
    {
      "date": "2015-02-13",
      "applicationId": "9NBLGGGZ5QDR",
      "applicationName": "Contoso demo",
      "market": "CN",
      "osVersion": "8.0.10517.0",
      "deviceType": "Phone",
      "isRevised": false,
      "oneStar": 0,
      "twoStars": 0,
      "threeStars": 0,
      "fourStars": 0,
      "fiveStars": 2
    }
  ],
  "@nextLink": "ratings?applicationId=9NBLGGGZ5QDR&aggregationLevel=day&startDate=2015/01/01&endDate=2016/02/01&top=1&skip=1",
  "TotalCount": 15242
} 

```

## 関連トピック

* [Windows ストア サービスを使った分析データへのアクセス](access-analytics-data-using-windows-store-services.md)
* [アプリの入手数の取得](get-app-acquisitions.md)
* [IAP の入手数の取得](get-in-app-acquisitions.md)
* [エラー報告データの取得](get-error-reporting-data.md)
* [アプリのレビューの取得](get-app-reviews.md)




<!--HONumber=May16_HO2-->


