---
author: mcleanbyron
ms.assetid: B0AD0B8E-867E-4403-9CF6-43C81F3C30CA
description: "Windows ストア提出 API のこのメソッドを使用して、Windows デベロッパー センター アカウントに登録されているアプリのパッケージ フライト情報を取得します。"
title: "Windows ストア提出 API を使用したアプリのパッケージ フライトの取得"
translationtype: Human Translation
ms.sourcegitcommit: 5f975d0a99539292e1ce91ca09dbd5fac11c4a49
ms.openlocfilehash: a49e4f2cf7110e12dd33a5baa37e328a39bae348

---

# Windows ストア提出 API を使用したアプリのパッケージ フライトの取得




Windows デベロッパー センター アカウントに登録するアプリのパッケージ フライトを一覧表示するには、Windows ストア提出 API 内の以下のメソッドを使用します。 パッケージ フライトについて詳しくは、「[パッケージ フライト](https://msdn.microsoft.com/windows/uwp/publish/package-flights)」をご覧ください。

## 前提条件

このメソッドを使うには、最初に次の作業を行う必要があります。

* Windows ストア提出 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。
* このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら新しいトークンを取得できます。

>**注:**&nbsp;&nbsp;このメソッドは、Windows ストア提出 API を使用するアクセス許可が付与された Windows デベロッパー センター アカウントにのみ使用できます。 すべてのアカウントでこのアクセス許可が有効になっているとは限りません。

## 要求

このメソッドの構文は次のとおりです。 ヘッダーと要求本文の使用例と説明については、次のセクションをご覧ください。

| メソッド | 要求 URI                                                      |
|--------|------------------------------------------------------------------|
| GET    | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/listflights``` |

<span/>
 
### 要求ヘッダー

| ヘッダー        | 型   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| Authorization | string | 必須。 **Bearer** &lt;*token*&gt; という形式の Azure AD アクセス トークン。 |

<span/>

### 要求パラメーター

| 名前        | 型   | 説明  |  必須かどうか  |    
|---------------|--------|----------------------------------|
| applicationId | string | 必須。 パッケージ フライトを取得するアプリのストア ID です。 ストア ID について詳しくは、「[アプリ ID の詳細の表示](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details)」をご覧ください。  |  必須  |
|  top  |  int  |  要求で返される項目の数 (つまり、返されるパッケージ フライトの数)。 クエリで指定した値よりアプリのパッケージ フライトの数が多い場合、応答本文には、データの次のページを要求するためにメソッド URI に追加できる相対 URI パスが含まれます。  |  必須ではない  |
|  skip  |  int  |  残りの項目を返す前にクエリでバイパスする項目の数。 データ セットを操作するには、このパラメーターを使用します。 たとえば、top = 10 と skip = 0 は、1 から 10 の項目を取得し、top=10 と skip=10 は 11 から 20 の項目を取得するという具合です。  |  必須ではない  |

<span/>

### 要求本文

このメソッドでは要求本文を指定しないでください。

### 要求の例

次の例は、アプリのすべてのパッケージ フライトを一覧表示する方法を示しています。

```
GET https://manage.devcenter.microsoft.com/v1.0/my/applications/9NBLGGH4R315/listflights HTTP/1.1
Authorization: Bearer <your access token>
```

次の例は、アプリの 1 番目のパッケージ フライトを表示する方法を示しています。

```
GET https://manage.devcenter.microsoft.com/v1.0/my/applications/9NBLGGH4R315/listflights?top=1 HTTP/1.1
Authorization: Bearer <your access token>
```

## 応答

次の例は、合計 3 個のパッケージ フライトがあるアプリの、1 番目のパッケージ フライトに対する要求が成功した場合に返される JSON 応答本文を示しています。 応答本文の値について詳しくは、次のセクションをご覧ください。

```json
{
  "value": [
    {
      "flightId": "7bfc11d5-f710-47c5-8a98-e04bb5aad310",
      "friendlyName": "myflight",
      "lastPublishedFlightSubmission": {
        "id": "1152921504621086517",
        "resourceLocation": "flights/7bfc11d5-f710-47c5-8a98-e04bb5aad310/submissions/1152921504621086517"
      },
      "pendingFlightSubmission": {
        "id": "1152921504621215786",
        "resourceLocation": "flights/7bfc11d5-f710-47c5-8a98-e04bb5aad310/submissions/1152921504621215786"
      },
      "groupIds": [
        "1152921504606962205"
      ],
      "rankHigherThan": "Non-flighted submission"
    }
  ],
  "totalCount": 3
}
```

### 応答本文

| 値      | 型   | 説明                                                                                                                                                                                                                                                                         |
|------------|--------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| @nextLink  | string | データの追加ページが存在する場合、この文字列には、データの次のページを要求するために基本 ```https://manage.devcenter.microsoft.com/v1.0/my/``` 要求 URI に追加できる相対パスが含まれます。 たとえば、最初の要求本文の *top* パラメーターが 2 に設定されていて、アプリには 4 個のパッケージ フライトが存在する場合、応答本文には ```applications/{applicationid}/listflights/?skip=2&top=2``` の @nextLink 値が含まれます。これは、次の 2 個のパッケージ フライトを要求するために ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationid}/listflights/?skip=2&top=2``` を呼び出すことができることを示しています。 |
| value      | array  | 指定されたアプリのパッケージ フライトに関する情報を提供するオブジェクトの配列。 各オブジェクトのデータについて詳しくは、「[フライト リソース](get-app-data.md#flight-object)」をご覧ください。                                                                                                                           |
| totalCount | int    | クエリのデータ結果の行の合計数 (つまり、指定されたアプリのパッケージ フライトの合計数)。                                                                                                                                                                                                                             |

<span/>

## エラー コード

要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。

| エラー コード |  説明   |
|--------|------------------|
| 404  | パッケージ フライトは見つかりませんでした。 |
| 409  | アプリは、[Windows ストア提出 API で現在サポートされていない](create-and-manage-submissions-using-windows-store-services.md#not_supported)デベロッパー センターのダッシュボード機能を使用します。  |

<span/>

## 関連トピック

* [Windows ストア サービスを使用した提出の作成と管理](create-and-manage-submissions-using-windows-store-services.md)
* [すべてのアプリの入手](get-all-apps.md)
* [アプリの入手](get-an-app.md)
* [アプリのアドオンの入手](get-add-ons-for-an-app.md)



<!--HONumber=Aug16_HO5-->


