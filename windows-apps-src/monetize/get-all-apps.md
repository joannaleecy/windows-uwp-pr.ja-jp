---
author: mcleanbyron
ms.assetid: 2BCFF687-DC12-49CA-97E4-ACEC72BFCD9B
description: "Windows デベロッパー センター アカウントに登録するすべてのアプリに関する情報を取得するには、Windows ストア提出 API 内のこのメソッドを使用します。"
title: "Windows ストア提出 API を使用したすべてのアプリの取得"
translationtype: Human Translation
ms.sourcegitcommit: 5f975d0a99539292e1ce91ca09dbd5fac11c4a49
ms.openlocfilehash: 6180cc4ef94df3e28af4843685e16f2d1fdfa7ac

---

# Windows ストア提出 API を使用したすべてのアプリの取得




Windows デベロッパー センター アカウントに登録するすべてのアプリのデータを取得するには、Windows ストア提出 API 内のこのメソッドを使用します。

## 前提条件

このメソッドを使うには、最初に次の作業を行う必要があります。

* Windows ストア提出 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。
* このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら、新しいトークンを取得できます。

>**注:**&nbsp;&nbsp;このメソッドは、Windows ストア提出 API を使用するアクセス許可が与えられた Windows デベロッパー センター アカウントにのみ使用できます。 すべてのアカウントでこのアクセス許可が有効になっているとは限りません。

## 要求

このメソッドの構文は次のとおりです。 ヘッダーと要求本文の使用例と説明については、次のセクションをご覧ください。

| メソッド | 要求 URI                                                      |
|--------|------------------------------------------------------------------|
| GET    | ```https://manage.devcenter.microsoft.com/v1.0/my/applications``` |

<span/>
 

### 要求ヘッダー

| ヘッダー        | 型   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| Authorization | string | 必須。 **Bearer** &lt;*token*&gt; という形式の Azure AD アクセス トークン。 |

<span/>

### 要求パラメーター

このメソッドでは、要求パラメーターはすべてオプションです。 パラメーターを指定せずにこのメソッドを呼び出す場合、応答には、アカウントに登録するすべてのアプリのデータが含まれます。
 
|  パラメーター  |  型  |  説明  |  必須かどうか  |
|------|------|------|------|
|  top  |  int  |  要求で返される項目の数 (つまり、返されるアプリの数)。 クエリで指定した値よりアカウントのアプリの数が多い場合、応答本文には、データの次のページを要求するためにメソッド URI に追加できる相対 URI パスが含まれます。  |  必須ではない  |
|  skip  |  int  |  残りの項目を返す前にクエリでバイパスする項目の数。 データ セットを操作するには、このパラメーターを使用します。 たとえば、top = 10 と skip = 0 は、1 から 10 の項目を取得し、top=10 と skip=10 は 11 から 20 の項目を取得するという具合です。  |  必須ではない  |

<span/>

### 要求本文

このメソッドでは要求本文を指定しないでください。

### 要求の例

次の例は、アカウントに登録するすべてのアプリに関する情報を取得する方法を示しています。

```
GET https://manage.devcenter.microsoft.com/v1.0/my/applications HTTP/1.1
Authorization: Bearer <your access token>
```

次の例は、アカウントに登録されている最初の 10 個のアプリを取得する方法を示しています。

```
GET https://manage.devcenter.microsoft.com/v1.0/my/applications?top=10 HTTP/1.1
Authorization: Bearer <your access token>
```

## 応答

次の例は、合計 21 個のアプリがある開発者アカウントに登録されている、最初の 10 個のアプリに対する要求が成功した場合に返される JSON 応答本文を示しています。 簡潔にするために、この例では、要求によって返される最初の 2 つのアプリのデータのみが示されています。 応答本文の値について詳しくは、次のセクションをご覧ください。

```json
{
  "@nextLink": "applications?skip=10&top=10",
  "value": [
    {
      "id": "9NBLGGH4R315",
      "primaryName": "Contoso sample app",
      "packageFamilyName": "5224ContosoDeveloper.ContosoSampleApp_ng6try80pwt52",
      "packageIdentityName": "5224ContosoDeveloper.ContosoSampleApp",
      "publisherName": "CN=…",
      "firstPublishedDate": "2016-03-11T01:32:11.0747851Z",
      "pendingApplicationSubmission": {
        "id": "1152921504621134883",
        "resourceLocation": "applications/9NBLGGH4R315/submissions/1152921504621134883"
      }
    },
    {
      "id": "9NBLGGH29DM8",
      "primaryName": "Contoso sample app 2",
      "packageFamilyName": "5224ContosoDeveloper.ContosoSampleApp2_ng6try80pwt52",
      "packageIdentityName": "5224ContosoDeveloper.ContosoSampleApp2",
      "publisherName": "CN=…",
      "firstPublishedDate": "2016-03-12T01:49:11.0747851Z",
      "lastPublishedApplicationSubmission": {
        "id": "1152921504621225621",
        "resourceLocation": "applications/9NBLGGH29DM8/submissions/1152921504621225621"
      }
      // Next 8 apps are omitted for brevity ...
    }
  ],
  "totalCount": 21
}
```

### 応答本文

| 値      | 型   | 説明                                                                                                                                                                                                                                                                         |
|------------|--------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| value      | array  | アカウントに登録されている各アプリについての情報が含まれるオブジェクトの配列。 各オブジェクトのデータについて詳しくは、「[アプリケーション リソース](get-app-data.md#application_object)」をご覧ください。                                                                                                                           |
| @nextLink  | string | データの追加ページが存在する場合、この文字列には、データの次のページを要求するために基本 ```https://manage.devcenter.microsoft.com/v1.0/my/``` 要求 URI に追加できる相対パスが含まれます。 たとえば、最初の要求本文の *top* パラメーターが 10 に設定されていて、アカウントには 20 個のアプリが登録されている場合、応答本文には ```applications?skip=10&top=10``` の @nextLink 値が含まれます。これは、次の 10 個のアプリを要求するために ```https://manage.devcenter.microsoft.com/v1.0/my/applications?skip=10&top=10``` を呼び出すことができることを示しています。 |
| totalCount | int    | クエリの結果データ内の行の総数 (つまり、自分のアカウントに登録されているアプリの合計数)。                                                                                                                                                                                                                             |

<span/>

## エラー コード

要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。

| エラー コード |  説明   |
|--------|------------------|
| 404  | アプリが見つかりませんでした。 |
| 409  | アプリは、[Windows ストア提出 API で現在サポートされていない](create-and-manage-submissions-using-windows-store-services.md#not_supported)デベロッパー センターのダッシュボード機能を使用します。  |

<span/>

## 関連トピック

* [Windows ストア サービスを使用した提出の作成と管理](create-and-manage-submissions-using-windows-store-services.md)
* [アプリの入手](get-an-app.md)
* [アプリのパッケージ フライトの入手](get-flights-for-an-app.md)
* [アプリのアドオンの入手](get-add-ons-for-an-app.md)



<!--HONumber=Aug16_HO5-->


