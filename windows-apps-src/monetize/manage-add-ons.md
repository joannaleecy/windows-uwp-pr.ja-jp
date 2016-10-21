---
author: mcleanbyron
ms.assetid: 4F9657E5-1AF8-45E0-9617-45AF64E144FC
description: "Windows デベロッパー センター アカウントに登録するアプリのアドオンを管理するには、以下の Windows ストア申請 API のメソッドを使います。"
title: "Windows ストア申請 API を使用したアドオンの管理"
translationtype: Human Translation
ms.sourcegitcommit: 5f975d0a99539292e1ce91ca09dbd5fac11c4a49
ms.openlocfilehash: 75548ee4689fd31d734c570f8e3eca5d33a6181f

---

# Windows ストア申請 API を使用したアドオンの管理




Windows デベロッパー センター アカウントに登録するアプリのアドオン (アプリ内製品または IAP ともいう) を管理するには、Windows ストア申請 API の以下のメソッドを使用します。 Windows ストア申請 API の概要については、「[Windows ストア サービスを使用した申請の作成と管理](create-and-manage-submissions-using-windows-store-services.md)」をご覧ください。

>**注:**&nbsp;&nbsp;これらのメソッドは、Windows ストア申請 API を使用するアクセス許可が付与された Windows デベロッパー センター アカウントにのみ使用できます。 すべてのアカウントでこのアクセス許可が有効になっているとは限りません。 以下のメソッドは、アドオンの取得、作成、または削除にしか使用できません。 アドオンの申請を作成する方法については、「[アドオンの申請の管理](manage-add-on-submissions.md)」のメソッドをご覧ください。

| メソッド        | URI    | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| GET | ```https://manage.devcenter.microsoft.com/v1.0/my/inappproducts``` | Windows デベロッパー センター アカウントに登録するすべてのアプリのすべてのアドオンについてのデータを取得します。 詳しくは、「[すべてのアドオンの入手](get-all-add-ons.md)」をご覧ください。 |
| GET | ```https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/{inAppProductId} ``` | 特定のアドオンについてのデータを取得します。 詳しくは、「[アドオンの入手](get-an-add-on.md)」をご覧ください。 |
| POST | ```https://manage.devcenter.microsoft.com/v1.0/my/inappproducts``` | 新しいアドオンを作成します。 詳しくは、「[アドオンの作成](create-an-add-on.md)」をご覧ください。  |
| DELETE | ```https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/{inAppProductId}``` | アドオンを削除します。 詳しくは、「[アドオンの削除](delete-an-add-on.md)」をご覧ください。 |

## 前提条件

Windows ストア申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)がまだ満たされていない場合は、ここに記載されているメソッドを使用する前に前提条件を整えてください。

## リソース

これらのメソッドでは、次のリソースを使用してデータの書式を設定します。

<span id="add-on-object" />
### アドオン

このリソースは、アドオンを表します。 次の例は、このリソースの書式設定を示しています。

```json
{
  "applications": {
    "value": [
      {
        "id": "9NBLGGH4R315",
        "resourceLocation": "applications/9NBLGGH4R315"
      }
    ],
    "totalCount": 1
  },
  "id": "9NBLGGH4TNMP",
  "productId": "TestAddOn",
  "productType": "Durable",
  "pendingInAppProductSubmission": {
    "id": "1152921504621243619",
    "resourceLocation": "inappproducts/9NBLGGH4TNMP/submissions/1152921504621243619"
  },
  "lastPublishedInAppProductSubmission": {
    "id": "1152921504621243705",
    "resourceLocation": "inappproducts/9NBLGGH4TNMP/submissions/1152921504621243705"
  }
}
```

このリソースには、次の値があります。

| 値      | 型   | 説明                                                                                                                                                                                                                                                                         |
|------------|--------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| applications      | array  | このアドオンが関連付けられるアプリを表すオブジェクトを格納する配列です。 このオブジェクトのデータについて詳しくは、以下の「[Application オブジェクト](#application-object)」のセクションをご覧ください。 この配列でサポートされる項目は 1 つのみです。  |
| id | string  | アドオンのストア ID です。 この値は、ストアによって提供されます。 ストア ID の例は 9NBLGGH4TNMP です。  |
| productId | string  | アドオンの製品 ID です。 これは、アドオンの作成時に開発者が指定した ID です。 詳しくは、「[IAP の製品の種類と製品 ID を設定する](https://msdn.microsoft.com/windows/uwp/publish/set-your-iap-product-id)」をご覧ください。 |
| productType | string  | アドオンの製品の種類です。 値 **Durable** と **Consumable** がサポートされています。  |
| lastPublishedInAppProductSubmission       | object | アドオンの最後に公開された申請に関する情報を提供するオブジェクト。 詳しくは、以下の「[申請](#submission-object)」のセクションをご覧ください。                                                                                                                                                          |
| pendingInAppProductSubmission        | object  |  アドオンの現在保留中の申請に関する情報を提供するオブジェクト。 詳しくは、以下の「[申請](#submission-object)」のセクションをご覧ください。  |   |

<span id="application-object" />
### Application

このリソースは、アドオンが関連付けられているアプリを表します。 次の例は、このリソースの書式設定を示しています。

```json
{
  "applications": {
    "value": [
      {
        "id": "9NBLGGH4R315",
        "resourceLocation": "applications/9NBLGGH4R315"
      }
    ],
    "totalCount": 1
  },
}
```

このリソースには、次の値があります。

| 値           | 型    | 説明                                                                                                                                                                                                                          |
|-----------------|---------|-----------|
| value            | object  |  次の値を格納するオブジェクトです。 <br/><br/> <ul><li>*id*。 アプリケーションのストア ID です。 ストア ID について詳しくは、「[アプリ ID の詳細の表示](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details)」をご覧ください。</li><li>*resourceLocation*。 アプリの完全なデータを取得するために基本 ```https://manage.devcenter.microsoft.com/v1.0/my/``` 要求 URI に付加できる相対パス。</li></ul>   |
| totalCount   | int  | 応答本文の *applications* 配列のアプリ オブジェクトの数。                                                                                                                                                 |

<span id="submission-object" />
### 申請

このリソースは、アドオンの申請に関する情報を提供します。 次の例は、このリソースの書式設定を示しています。

```json
{
  "pendingInAppProductSubmission": {
    "id": "1152921504621243619",
    "resourceLocation": "inappproducts/9NBLGGH4TNMP/submissions/1152921504621243619"
  },
}
```

このリソースには、次の値があります。

| 値           | 型    | 説明                                                                                                                                                                                                                          |
|-----------------|---------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| id            | string  | 申請 ID。    |
| resourceLocation   | string  | 申請の完全なデータを取得するために基本 ```https://manage.devcenter.microsoft.com/v1.0/my/``` 要求 URI に付加できる相対パス。                                                                                                                                               |
 
<span/>

## 関連トピック

* [Windows ストア サービスを使用した申請の作成と管理](create-and-manage-submissions-using-windows-store-services.md)
* [Windows ストア申請 API を使用したアドオンの申請の管理](manage-add-on-submissions.md)
* [すべてのアドオンの入手](get-all-add-ons.md)
* [アドオンの入手](get-an-add-on.md)
* [アドオンの作成](create-an-add-on.md)
* [アドオンの削除](delete-an-add-on.md)



<!--HONumber=Aug16_HO5-->


