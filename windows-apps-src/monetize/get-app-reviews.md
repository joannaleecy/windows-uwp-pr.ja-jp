---
author: mcleanbyron
ms.assetid: 2967C757-9D8A-4B37-8AA4-A325F7A060C5
description: "特定の日付範囲などのオプション フィルターを使ってレビュー データを取得するには、Windows ストア分析 API でこのメソッドを使います。"
title: "アプリのレビューの取得"
ms.sourcegitcommit: 02131e641cdaa76256845b38bcc50aa42d718601
ms.openlocfilehash: bb0f912bd3380e21e04fa44f2c75244c6585f03a

---

# アプリのレビューの取得


\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください \]

特定の日付範囲などのオプション フィルターを使ってレビュー データを取得するには、Windows ストア分析 API でこのメソッドを使います。 このメソッドは、データを JSON 形式で返します。

## 前提条件


このメソッドを使うには、次の作業が必要です。

-   このメソッドの呼び出しに使う Azure AD アプリケーションをデベロッパー センター アカウントに関連付けます。

-   アプリケーションの Azure AD アクセス トークンを取得します。

詳しくは、「[Windows ストア サービスを使った分析データへのアクセス](access-analytics-data-using-windows-store-services.md)」をご覧ください。

## 要求


### 要求の構文

| メソッド | 要求 URI                                                      |
|--------|------------------------------------------------------------------|
| GET    | https://manage.devcenter.microsoft.com/v1.0/my/analytics/reviews |

 

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
<td align="left">レビュー データを取得するアプリのストア ID です。 ストア ID は、デベロッパー センター ダッシュボードの[アプリ ID ページ](../publish/view-app-identity-details.md)で確認できます。 ストア ID の例は 9WZDNCRFJ3Q8 です。</td>
<td align="left">○</td>
</tr>
<tr class="even">
<td align="left">startDate</td>
<td align="left">date</td>
<td align="left">取得するレビュー データの日付範囲の開始日です。 既定値は現在の日付です。</td>
<td align="left">×</td>
</tr>
<tr class="odd">
<td align="left">endDate</td>
<td align="left">date</td>
<td align="left">取得するレビュー データの日付範囲の終了日です。 既定値は現在の日付です。</td>
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
<td align="left">orderby</td>
<td align="left">string</td>
<td align="left">各評価の結果データ値の順序を指定するステートメントです。 構文は <em>orderby=field [order],field [order],...</em> です。 <em>field</em> パラメーターには、次のいずれかの文字列を指定できます。
<ul>
<li><strong>date</strong></li>
<li><strong>osVersion</strong></li>
<li><strong>market</strong></li>
<li><strong>deviceType</strong></li>
<li><strong>isRevised</strong></li>
<li><strong>packageVersion</strong></li>
<li><strong>deviceModel</strong></li>
<li><strong>productFamily</strong></li>
<li><strong>deviceScreenResolution</strong></li>
<li><strong>isTouchEnabled</strong></li>
<li><strong>reviewerName</strong></li>
<li><strong>reviewTitle</strong></li>
<li><strong>reviewText</strong></li>
<li><strong>helpfulCount</strong></li>
<li><strong>notHelpfulCount</strong></li>
<li><strong>responseDate</strong></li>
<li><strong>responseText</strong></li>
<li><strong>deviceRAM</strong></li>
<li><strong>deviceStorageCapacity</strong></li>
<li><strong>rating</strong></li>
</ul>
<p><em>order</em> パラメーターは省略可能であり、<strong>asc</strong> または <strong>desc</strong> を指定して、各フィールドを昇順または降順にすることができます。 既定値は <strong>asc</strong> です。</p>
<p>例: <em>orderby</em> string: <em>orderby=date,market</em></p></td>
<td align="left">×</td>
</tr>
</tbody>
</table>

 
### フィルター フィールド

要求本文の *filter* パラメーターには、応答内の行をフィルター処理する 1 つまたは複数のステートメントが含まれます。 各ステートメントには **eq** または **ne** 演算子と関連付けられるフィールドと値が含まれ、一部のフィールドでは **contains**、**gt**、**lt**、**ge**、および **le** 演算子もサポートします。 **and** または **or** を使ってステートメントを組み合わせることができます。

*filter* 文字列の例は次のとおりです。*filter=contains(reviewText,'great') and contains(reviewText,'ads') and deviceRAM lt 2048 and market eq 'US'*

サポートされているフィールドと各フィールドでサポートされている演算子の一覧については、次の表をご覧ください。 *filter* パラメーターでは、文字列値は単一引用符で囲む必要があります。

<table>
<colgroup>
<col width="33%" />
<col width="33%" />
<col width="33%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">フィールド</th>
<th align="left">サポートされている演算子</th>
<th align="left">説明</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left">market</td>
<td align="left">eq、ne</td>
<td align="left">デバイス市場の ISO 3166 国コードを含む文字列です。</td>
</tr>
<tr class="even">
<td align="left">osVersion</td>
<td align="left">eq、ne</td>
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
<td align="left">eq、ne</td>
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
<td align="left">eq、ne</td>
<td align="left">更新されているレビューをフィルター処理するには <strong>true</strong> を指定します。それ以外の場合は <strong>false</strong> を指定します。</td>
</tr>
<tr class="odd">
<td align="left">packageVersion</td>
<td align="left">eq、ne</td>
<td align="left">レビューされたアプリ パッケージのバージョンです。</td>
</tr>
<tr class="even">
<td align="left">deviceModel</td>
<td align="left">eq、ne</td>
<td align="left">アプリがレビューされたデバイスの種類です。</td>
</tr>
<tr class="odd">
<td align="left">productFamily</td>
<td align="left">eq、ne</td>
<td align="left">次のいずれかの文字列です。
<ul>
<li><strong>PC</strong></li>
<li><strong>Tablet</strong></li>
<li><strong>Phone</strong></li>
<li><strong>Wearable</strong></li>
<li><strong>Server</strong></li>
<li><strong>Collaborative</strong></li>
<li><strong>Other</strong></li>
</ul></td>
</tr>
<tr class="even">
<td align="left">deviceScreenResolution</td>
<td align="left">eq、ne</td>
<td align="left">&quot;<em>幅</em> x <em>高さ</em>&quot; 形式のデバイスの画面解像度です。</td>
</tr>
<tr class="odd">
<td align="left">isTouchEnabled</td>
<td align="left">eq、ne</td>
<td align="left">タッチ対応デバイスをフィルター処理するには <strong>true</strong> を指定します。それ以外の場合は <strong>false</strong> を指定します。</td>
</tr>
<tr class="even">
<td align="left">reviewerName</td>
<td align="left">eq、ne</td>
<td align="left">レビュー担当者名です。</td>
</tr>
<tr class="odd">
<td align="left">helpfulCount</td>
<td align="left">eq、ne</td>
<td align="left">レビューが役に立つとマークされた回数です。</td>
</tr>
<tr class="even">
<td align="left">notHelpfulCount</td>
<td align="left">eq、ne</td>
<td align="left">レビューが役に立たないとマークされた回数です。</td>
</tr>
<tr class="odd">
<td align="left">reviewTitle</td>
<td align="left">eq、ne、contains</td>
<td align="left">レビューのタイトルです。</td>
</tr>
<tr class="even">
<td align="left">reviewText</td>
<td align="left">eq、ne、contains</td>
<td align="left">レビューのテキスト コンテンツです。</td>
</tr>
<tr class="odd">
<td align="left">responseText</td>
<td align="left">eq、ne、contains</td>
<td align="left">応答のテキスト コンテンツです。</td>
</tr>
<tr class="even">
<td align="left">responseDate</td>
<td align="left">eq、ne</td>
<td align="left">応答が送信された日付です。</td>
</tr>
<tr class="odd">
<td align="left">deviceRAM</td>
<td align="left">eq、ne、gt、lt、ge、le</td>
<td align="left">物理 RAM (MB 単位) です。</td>
</tr>
<tr class="even">
<td align="left">deviceStorageCapacity</td>
<td align="left">eq、ne、gt、lt、ge、le</td>
<td align="left">主記憶域ディスクの容量 (GB 単位) です。</td>
</tr>
<tr class="odd">
<td align="left">rating</td>
<td align="left">eq、ne、gt、lt、ge、le</td>
<td align="left">星で表現したアプリの評価です。</td>
</tr>
</tbody>
</table>

 

### 要求の例

レビュー データを取得するためのいくつかの要求の例を次に示します。 *applicationId* 値を、目的のアプリのストア ID に置き換えてください。

```syntax
GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/reviews?applicationId=9NBLGGGZ5QDR&startDate=1/1/2015&endDate=2/1/2015&top=10&skip=0 HTTP/1.1
Authorization: Bearer <your access token>

GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/reviews?applicationId=9NBLGGGZ5QDR&startDate=8/1/2015&endDate=8/31/2015&skip=0&filter=contains(reviewText,'great') and contains(reviewText,'ads') and deviceRAM lt 2048 and market eq 'US' HTTP/1.1
Authorization: Bearer <your access token>
```

## 応答


### 応答本文

| 値      | 型   | 説明                                                                                                                                                                                                                                                                            |
|------------|--------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Value      | array  | レビュー データを含むオブジェクトの配列です。 各オブジェクトのデータについて詳しくは、次の「[レビュー値](#review-values)」セクションをご覧ください。                                                                                                                                      |
| @nextLink  | string | データの追加ページがある場合、この文字列には、データの次のページを要求するために使用できる URI が含まれます。 たとえば、要求の **top** パラメーターが 10000 に設定されたが、クエリの入手データに 10,000 を超える行が含まれている場合に、この値が返されます。 |
| TotalCount | int    | クエリの結果データ内の行の総数です。                                                                                                                                                                                                                             |

 
### レビュー値

*Value* 配列の要素には、次の値が含まれます。

| 値                  | 型    | 説明                                                                                                                                                                                                                          |
|------------------------|---------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| date                   | string  | 評価データの日付範囲の最初の日付です。 要求に日付を指定した場合、この値はその日付になります。 要求に週、月、またはその他の日付範囲を指定した場合、この値はその日付範囲の最初の日付になります。 |
| applicationId          | string  | 評価データを取得するアプリのストア ID です。                                                                                                                                                                 |
| applicationName        | string  | アプリの表示名です。                                                                                                                                                                                                         |
| market                 | string  | 評価が送信された市場の ISO 3166 国コードです。                                                                                                                                                              |
| osVersion              | string  | 評価が送信された OS バージョンです。 サポートされる文字列の一覧については、前の「[フィルター フィールド](#filter-fields)」セクションをご覧ください。                                                                                               |
| deviceType             | string  | 評価が送信されたデバイスの種類です。 サポートされる文字列の一覧については、前の「[フィルター フィールド](#filter-fields)」セクションをご覧ください。                                                                                           |
| isRevised              | Boolean | 値 **true** は、レビューが更新済みであることを示します。それ以外の場合は **false** です。                                                                                                                                                       |
| packageVersion         | string  | レビューされたアプリ パッケージのバージョンです。                                                                                                                                                                                    |
| deviceModel            | string  | アプリがレビューされたデバイスの種類です。                                                                                                                                                                                    |
| productFamily          | string  | デバイス ファミリの名前です。 サポートされる文字列の一覧については、前の「[フィルター フィールド](#filter-fields)」セクションをご覧ください。                                                                                                                         |
| deviceScreenResolution | string  | "*幅* x *高さ*" 形式のデバイスの画面解像度です。                                                                                                                                                                     |
| isTouchEnabled         | Boolean | 値 **true** は、タッチ対応であることを示します。それ以外の場合は **false** です。                                                                                                                                                             |
| reviewerName           | string  | レビュー担当者名です。                                                                                                                                                                                                                   |
| helpfulCount           | number  | レビューが役に立つとマークされた回数です。                                                                                                                                                                                   |
| notHelpfulCount        | number  | レビューが役に立たないとマークされた回数です。                                                                                                                                                                               |
| reviewTitle            | string  | レビューのタイトルです。                                                                                                                                                                                                             |
| reviewText             | string  | レビューのテキスト コンテンツです。                                                                                                                                                                                                     |
| responseText           | string  | 応答のテキスト コンテンツです。                                                                                                                                                                                                   |
| responseDate           | string  | 応答が送信された日付です。                                                                                                                                                                                                   |
| deviceRAM              | number  | 物理 RAM (MB 単位) です。                                                                                                                                                                                                             |
| deviceStorageCapacity  | number  | 主記憶域ディスクの容量 (GB 単位) です。                                                                                                                                                                                     |
| rating                 | number  | 星で表現したアプリの評価です。                                                                                                                                                                                                            |

 

### 応答の例

この要求の JSON 応答の本文の例を次に示します。

```json
{
  "Value": [
    {
      "date": "2015-07-29",
      "applicationId": "9NBLGGGZ5QDR",
      "applicationName": "Contoso demo",
      "market": "US",
      "osVersion": "10.0.10240.16410",
      "deviceType": "PC",
      "isRevised": true,
      "packageVersion": "",
      "deviceModel": "Microsoft Corporation-Virtual Machine",
      "productFamily": "PC",
      "deviceRAM": -1,
      "deviceScreenResolution": "1024 x 768",
      "deviceStorageCapacity": 51200,
      "isTouchEnabled": false,
      "reviewerName": "ALeksandra",
      "rating": 5,
      "reviewTitle": "Love it",
      "reviewText": "Great app for demos and great dev response.",
      "helpfulCount": 0,
      "notHelpfulCount": 0,
      "responseDate": "2015-08-07T01:50:22.9874488Z",
      "responseText": "1"
    }
  ],
  "@nextLink": null,
  "TotalCount": 1
}
```

## 関連トピック

* [Windows ストア サービスを使った分析データへのアクセス](access-analytics-data-using-windows-store-services.md)
* [アプリの入手数の取得](get-app-acquisitions.md)
* [IAP の入手数の取得](get-in-app-acquisitions.md)
* [エラー報告データの取得](get-error-reporting-data.md)
* [アプリの評価の取得](get-app-ratings.md)



<!--HONumber=Jun16_HO5-->


