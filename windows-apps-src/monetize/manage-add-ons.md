---
author: mcleanbyron
ms.assetid: 4F9657E5-1AF8-45E0-9617-45AF64E144FC
description: "Windows デベロッパー センター アカウントに登録されているアプリのアドオンを管理するには、Windows ストア申請 API に含まれる以下のメソッドを使用します。"
title: "アドオンの管理"
ms.author: mcleans
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, Windows ストア申請 API, アドオン, アプリ内製品, IAP"
ms.openlocfilehash: 4e85c7506ed9a8f420d13075dc0023bdef2c786f
ms.sourcegitcommit: 6c6f3c265498d7651fcc4081c04c41fafcbaa5e7
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/09/2017
---
# <a name="manage-add-ons"></a>アドオンの管理

アプリのアドオンを管理するには、Windows ストア申請 API に含まれる以下のメソッドを使用します。 Windows ストア申請 API の概要については、「[Windows ストア サービスを使用した申請の作成と管理](create-and-manage-submissions-using-windows-store-services.md)」をご覧ください。この API を使用するための前提条件などの情報があります。

以下のメソッドは、アドオンの取得、作成、または削除にしか使用できません。 アドオンの申請を作成する方法については、「[アドオンの申請の管理](manage-add-on-submissions.md)」のメソッドをご覧ください。

<table>
<colgroup>
<col width="10%" />
<col width="30%" />
<col width="60%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">メソッド</th>
<th align="left">URI</th>
<th align="left">説明</th>
</tr>
</thead>
<tbody>
<tr>
<td align="left">GET</td>
<td align="left">```https://manage.devcenter.microsoft.com/v1.0/my/inappproducts```</td>
<td align="left">[アプリのすべてのアドオンを取得します](get-all-add-ons.md)</td>
</tr>
<tr>
<td align="left">GET</td>
<td align="left">```https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/{inAppProductId}```</td>
<td align="left">[特定のアドオンを取得します](get-an-add-on.md)</td>
</tr>
<tr>
<td align="left">POST</td>
<td align="left">```https://manage.devcenter.microsoft.com/v1.0/my/inappproducts```</td>
<td align="left">[アドオンを作成します](create-an-add-on.md)</td>
</tr>
<tr>
<td align="left">DELETE</td>
<td align="left">```https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/{inAppProductId}```</td>
<td align="left">[アドオンを削除します](delete-an-add-on.md)</td>
</tr>
</tbody>
</table>

## <a name="prerequisites"></a>前提条件

Windows ストア申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)がまだ満たされていない場合は、ここに記載されているメソッドを使用する前に前提条件を整えてください。

## <a name="data-resources"></a>データ リソース

アドオンを管理するための Windows ストア申請 API のメソッドでは、次の JSON データ リソースを使用します。

<span id="add-on-object" />
### <a name="add-on-resource"></a>アドオン リソース

このリソースは、アドオンを記述しています。

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

| 値      | 型   | 説明        |
|------------|--------|--------------|
| applications      | array  | このアドオンが関連付けられるアプリを表す 1 つの[アプリケーション リソース](#application-object)を格納する配列です。 この配列でサポートされる項目は 1 つのみです。  |
| id | string  | アドオンのストア ID です。 この値は、ストアによって提供されます。 ストア ID の例は 9NBLGGH4TNMP です。  |
| productId | string  | アドオンの製品 ID です。 これは、アドオンの作成時に開発者が指定した ID です。 詳しくは、「[IAP の製品の種類と製品 ID を設定する](https://msdn.microsoft.com/windows/uwp/publish/set-your-iap-product-id)」をご覧ください。 |
| productType | string  | アドオンの製品の種類です。 値 **Durable** と **Consumable** がサポートされています。  |
| lastPublishedInAppProductSubmission       | object | アドオンの最後に公開された申請に関する情報を提供する[申請のリソース](#submission-object)。         |
| pendingInAppProductSubmission        | object  |  アドオンの現在保留中の申請に関する情報を提供する[申請のリソース](#submission-object)。  |   |

<span id="application-object" />
### <a name="application-resource"></a>アプリケーション リソース

このリソースは、アドオンが関連付けられているアプリを説明します。 次の例は、このリソースの書式設定を示しています。

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

| 値           | 型    | 説明        |
|-----------------|---------|-----------|
| value            | object  |  次の値を格納するオブジェクトです。 <br/><br/> <ul><li>*id*。 アプリケーションのストア ID です。 ストア ID について詳しくは、「[アプリ ID の詳細の表示](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details)」をご覧ください。</li><li>*resourceLocation*。 アプリの完全なデータを取得するために基本 ```https://manage.devcenter.microsoft.com/v1.0/my/``` 要求 URI に付加できる相対パス。</li></ul>   |
| totalCount   | int  | 応答本文の *applications* 配列のアプリ オブジェクトの数。                                                                                                                                                 |

<span id="submission-object" />
### <a name="submission-resource"></a>申請のリソース

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

| 値           | 型    | 説明     |
|-----------------|---------|------------------|
| id            | string  | 申請 ID。    |
| resourceLocation   | string  | 申請の完全なデータを取得するために基本 ```https://manage.devcenter.microsoft.com/v1.0/my/``` 要求 URI に付加できる相対パス。     |
 
<span/>
## <a name="related-topics"></a>関連トピック

* [Windows ストア サービスを使用した申請の作成と管理](create-and-manage-submissions-using-windows-store-services.md)
* [Windows ストア申請 API を使用したアドオンの申請の管理](manage-add-on-submissions.md)
* [すべてのアドオンの入手](get-all-add-ons.md)
* [アドオンの入手](get-an-add-on.md)
* [アドオンの作成](create-an-add-on.md)
* [アドオンの削除](delete-an-add-on.md)
