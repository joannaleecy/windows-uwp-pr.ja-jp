---
author: mcleanbyron
ms.assetid: 8D4AE532-22EF-4743-9555-A828B24B8F16
description: "Windows デベロッパー センター アカウントに登録するアプリのデータを取得するには、Windows ストア提出 API 内のこれらのメソッドを使用します。"
title: "Windows ストア提出 API を使用したアプリ データの取得"
translationtype: Human Translation
ms.sourcegitcommit: 5f975d0a99539292e1ce91ca09dbd5fac11c4a49
ms.openlocfilehash: 99d609decc8c38952961deac5bb8ec6926d91c88

---

# Windows ストア提出 API を使用したアプリ データの取得

Windows デベロッパー センター アカウントに登録するアプリのデータを取得するには、Windows ストア提出 API 内の次のメソッドを使用します。 Windows ストア提出 API の概要については、「[Windows ストア サービスを使用した提出の作成と管理](create-and-manage-submissions-using-windows-store-services.md)」をご覧ください。

>**注:**&nbsp;&nbsp;これらのメソッドは、Windows ストア提出 API を使用するアクセス許可が付与された Windows デベロッパー センター アカウントにのみ使用できます。 すべてのアカウントでこのアクセス許可が有効になっているとは限りません。 これらのメソッドは、アプリのデータを取得する場合にのみ使用できます。 アプリの提出を作成または管理する方法については、「[アプリ提出の管理](manage-app-submissions.md)」のメソッドを参照してください。

| メソッド        | URI    | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| GET | ```https://manage.devcenter.microsoft.com/v1.0/my/applications``` | Windows デベロッパー センター アカウントに登録されているすべてのアプリのデータを取得します。 詳しくは、「[すべてのアプリの入手](get-all-apps.md)」をご覧ください。 |
| GET | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}``` | Windows デベロッパー センター アカウントに登録されている特定のアプリに関するデータを取得します。 詳しくは、「[アプリの入手](get-an-app.md)」をご覧ください。 |
| GET | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/listinappproducts``` | Windows デベロッパー センター アカウントに登録されているアプリのアドオン (アプリ内製品または IAP とも呼ばれる) の一覧を示します。 詳しくは、「[アプリのアドオンの入手](get-add-ons-for-an-app.md)」をご覧ください。 |
| GET | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/listflights``` | Windows デベロッパー センター アカウントに登録されているアプリのパッケージ フライトの一覧を示します。 詳しくは、「[アプリのパッケージ フライトの入手](get-flights-for-an-app.md)」をご覧ください。 |

<span/>

## 前提条件

Windows ストア提出 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)がまだ満たされていない場合は、ここに記載されているメソッドを使用する前に前提条件を整えてください。

## リソース

これらのメソッドでは、次のリソースを使用してデータの書式を設定します。

<span id="application_object" />
### アプリケーション

このリソースは、アカウントに登録されているアプリを表します。 次の例は、このリソースの書式設定を示しています。

```json
{
  "id": "9NBLGGH4R315",
  "primaryName": "ApiTestApp",
  "packageFamilyName": "30481DevCenterAPITester.ApiTestAppForDevbox_ng6try80pwt52",
  "packageIdentityName": "30481DevCenterAPITester.ApiTestAppForDevbox",
  "publisherName": "CN=…",
  "firstPublishedDate": "1601-01-01T00:00:00Z",
  "lastPublishedApplicationSubmission": {
    "id": "1152921504621086517",
    "resourceLocation": "applications/9NBLGGH4R315/submissions/1152921504621086517"
  },
  "pendingApplicationSubmission": {
    "id": "1152921504621243487",
    "resourceLocation": "applications/9NBLGGH4R315/submissions/1152921504621243487"
  }
}
```

このリソースには、次の値があります。

| 値           | 型    | 説明                                                                                                                                                                                                                          |
|-----------------|---------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| id            | string  | アプリのストア ID です。 ストア ID について詳しくは、「[アプリ ID の詳細の表示](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details)」をご覧ください。   |
| primaryName   | string  | アプリのプライマリ名です。                                                                                                                                                   |
| packageFamilyName | string  | アプリのパッケージ ファミリ名です。                                                                                                                                                                                                         |
| packageIdentityName          | string  | アプリのパッケージ ID 名です。                                                                                                                                                              |
| publisherName       | string  | アプリに関連付けられている Windows 発行元 ID です。 これは、Windows デベロッパー センター ダッシュボードのアプリの「[アプリ ID](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details)」ページに表示される「**パッケージ/ID/発行者**」値と同じです。                                                                                             |
| firstPublishedDate      | string  | アプリが最初に発行された日付 (ISO 8601 形式)。                                                                                         |
| lastPublishedApplicationSubmission       | object | アプリの最後に公開された提出に関する情報を提供するオブジェクト。 詳しくは、以下の「[提出](#submission_object)」のセクションをご覧ください。                                                                                                                                                          |
| pendingApplicationSubmission        | object  |  アプリの現在保留中の提出に関する情報を提供するオブジェクト。 詳しくは、以下の「[提出](#submission_object)」のセクションをご覧ください。  |   |


<span id="add-on-object" />
### アドオン

このリソースは、アドオンに関する情報を提供します。 次の例は、このリソースの書式設定を示しています。

```json
{
    "inAppProductId": "9WZDNCRD7DLK"
}
```

このリソースには、次の値があります。

| 値           | 型    | 説明                                                                                                                                                                                                                          |
|-----------------|---------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| inAppProductId            | string  | アドオンのストア ID です。 この値は、ストアによって提供されます。 ストア ID の例は 9NBLGGH4TNMP です。   |


<span id="flight-object" />
### フライト

このリソースは、アプリのパッケージ フライトに関する情報を提供します。 次の例は、このリソースの書式設定を示しています。

```json
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
```

このリソースには、次の値があります。

| 値           | 型    | 説明                                                                                                                                                                                                                          |
|-----------------|---------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| flightId            | string  | パッケージ フライトの ID。 この値は、デベロッパー センターによって提供されます。  |
| friendlyName           | string  | 開発者によって指定されているパッケージ フライトの名前。   |
| lastPublishedFlightSubmission       | object | パッケージ フライトの最後に公開された提出に関する情報を提供するオブジェクト。 詳しくは、以下の「[提出](#submission_object)」のセクションをご覧ください。  |
| pendingFlightSubmission        | object  |  パッケージ フライトの現在保留中の提出に関する情報を提供するオブジェクト。 詳しくは、以下の「[提出](#submission_object)」のセクションをご覧ください。  |    
| groupIds           | array  | パッケージ フライトに関連付けられているフライト グループの ID を含む文字列の配列。 フライト グループについて詳しくは、「[パッケージ フライト](https://msdn.microsoft.com/windows/uwp/publish/package-flights)」をご覧ください。   |
| rankHigherThan           | string  | 現在のパッケージ フライトの次に低位のパッケージ フライトのフレンドリ名。 フライト グループのランク付けについて詳しくは、「[パッケージ フライト](https://msdn.microsoft.com/windows/uwp/publish/package-flights)」をご覧ください。  |


<span id="submission_object" />
### 提出

このリソースは、提出に関する情報を提供します。 次の例は、このリソースの書式設定を示しています。

```json
{
  "pendingApplicationSubmission": {
    "id": "1152921504621243487",
    "resourceLocation": "applications/9WZDNCRD9MMD/submissions/1152921504621243487"
  }
}
```

このリソースには、次の値があります。

| 値           | 型    | 説明                                                                                                                                                                                                                          |
|-----------------|---------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| id            | string  | 提出 ID。    |
| resourceLocation   | string  | 提出の完全なデータを取得するために基本 ```https://manage.devcenter.microsoft.com/v1.0/my/``` 要求 URI に付加できる相対パス。                                                                                                                                               |
 
<span/>

## 関連トピック

* [Windows ストア サービスを使用した提出の作成と管理](create-and-manage-submissions-using-windows-store-services.md)
* [Windows ストア提出 API を使用したアプリの提出の管理](manage-app-submissions.md)
* [すべてのアプリの入手](get-all-apps.md)
* [アプリの入手](get-an-app.md)
* [アプリのアドオンの入手](get-add-ons-for-an-app.md)
* [アプリのパッケージ フライトの入手](get-flights-for-an-app.md)



<!--HONumber=Aug16_HO5-->


