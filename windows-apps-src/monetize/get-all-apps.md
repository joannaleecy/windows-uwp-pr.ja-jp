---
author: mcleanbyron
ms.assetid: 2BCFF687-DC12-49CA-97E4-ACEC72BFCD9B
description: "Windows デベロッパー センター アカウントに登録されているすべてのアプリに関する情報を取得するには、Windows ストア申請 API 内のこのメソッドを使用します。"
title: "Windows ストア申請 API を使用したすべてのアプリの取得"
ms.author: mcleans
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, Windows ストア申請 API, アプリ"
translationtype: Human Translation
ms.sourcegitcommit: c6b64cff1bbebc8ba69bc6e03d34b69f85e798fc
ms.openlocfilehash: 12466a50c6cabe5ceca907cdd2f0d600ec95121f
ms.lasthandoff: 02/07/2017

---

# <a name="get-all-apps-using-the-windows-store-submission-api"></a>Windows ストア申請 API を使用したすべてのアプリの取得




Windows デベロッパー センター アカウントに登録されているすべてのアプリのデータを取得するには、Windows ストア申請 API 内のこのメソッドを使用します。

## <a name="prerequisites"></a>前提条件

このメソッドを使うには、最初に次の作業を行う必要があります。

* Windows ストア申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。
* このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら新しいトークンを取得できます。

>**注:**&nbsp;&nbsp;このメソッドは、Windows ストア提出 API を使用するアクセス許可が付与された Windows デベロッパー センター アカウントにのみ使用できます。 すべてのアカウントでこのアクセス許可が有効になっているとは限りません。

## <a name="request"></a>要求

このメソッドの構文は次のとおりです。 ヘッダーと要求本文の使用例と説明については、次のセクションをご覧ください。

| メソッド | 要求 URI                                                      |
|--------|------------------------------------------------------------------|
| GET    | ```https://manage.devcenter.microsoft.com/v1.0/my/applications``` |

<span/>
 

### <a name="request-header"></a>要求ヘッダー

| ヘッダー        | 型   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| Authorization | string | 必須。 **Bearer** &lt;*token*&gt; という形式の Azure AD アクセス トークン。 |

<span/>

### <a name="request-parameters"></a>要求パラメーター

このメソッドでは、要求パラメーターはすべてオプションです。 パラメーターを指定せずにこのメソッドを呼び出す場合、応答には、アカウントに登録するすべてのアプリのデータが含まれます。
 
|  パラメーター  |  型  |  説明  |  必須かどうか  |
|------|------|------|------|
|  top  |  int  |  要求で返される項目の数 (つまり、返されるアプリの数)。 クエリで指定した値よりアカウントのアプリの数が多い場合、応答本文には、データの次のページを要求するためにメソッド URI に追加できる相対 URI パスが含まれます。  |  必須ではない  |
|  skip  |  int  |  残りの項目を返す前にクエリでバイパスする項目の数。 データ セットを操作するには、このパラメーターを使用します。 たとえば、top = 10 と skip = 0 は、1 から 10 の項目を取得し、top=10 と skip=10 は 11 から 20 の項目を取得するという具合です。  |  必須ではない  |

<span/>

### <a name="request-body"></a>要求本文

このメソッドでは要求本文を指定しないでください。

### <a name="request-examples"></a>要求の例

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

## <a name="response"></a>応答

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

### <a name="response-body"></a>応答本文

| 値      | 型   | 説明                                                                                                                                                                                                                                                                         |
|------------|--------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| value      | array  | アカウントに登録されている各アプリについての情報が含まれるオブジェクトの配列。 各オブジェクトのデータについて詳しくは、「[アプリケーション リソース](get-app-data.md#application_object)」をご覧ください。                                                                                                                           |
| @nextLink  | string | データの追加ページが存在する場合、この文字列には、データの次のページを要求するために基本 ```https://manage.devcenter.microsoft.com/v1.0/my/``` 要求 URI に追加できる相対パスが含まれます。 たとえば、最初の要求本文の *top* パラメーターが 10 に設定されていて、アカウントには 20 個のアプリが登録されている場合、応答本文には ```applications?skip=10&top=10``` の @nextLink 値が含まれます。これは、次の 10 個のアプリを要求するために ```https://manage.devcenter.microsoft.com/v1.0/my/applications?skip=10&top=10``` を呼び出すことができることを示しています。 |
| totalCount | int    | クエリの結果データ内の行の総数 (つまり、自分のアカウントに登録されているアプリの合計数)。                                                                                                                                                                                                                             |

<span/>

## <a name="error-codes"></a>エラー コード

要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。

| エラー コード |  説明   |
|--------|------------------|
| 404  | アプリが見つかりませんでした。 |
| 409  | アプリは、[Windows ストア提出 API で現在サポートされていない](create-and-manage-submissions-using-windows-store-services.md#not_supported)デベロッパー センターのダッシュボード機能を使用します。  |

<span/>

## <a name="related-topics"></a>関連トピック

* [Windows ストア サービスを使用した提出の作成と管理](create-and-manage-submissions-using-windows-store-services.md)
* [アプリの入手](get-an-app.md)
* [アプリのパッケージ フライトの入手](get-flights-for-an-app.md)
* [アプリのアドオンの入手](get-add-ons-for-an-app.md)

