---
author: mcleanbyron
ms.assetid: 78278741-09A4-4406-A112-9AF3C73F5C16
description: "Windows ストア提出 API のこのメソッドを使用して、Windows デベロッパー センター アカウントに登録されているアプリのアドオンに関する情報を取得します。"
title: "Windows ストア提出 API を使用したアドオンの取得"
translationtype: Human Translation
ms.sourcegitcommit: 5f975d0a99539292e1ce91ca09dbd5fac11c4a49
ms.openlocfilehash: 20da33d3e06ca97613f4bc317fe8e8fdc9bc73b6

---

# Windows ストア提出 API を使用したアドオンの取得




Windows ストア提出 API 内のこのメソッドを使用して、Windows デベロッパー センター アカウントに登録されているアプリのアドオン (アプリ内製品または IAP とも呼ばれます) に関する情報を取得します。

## 前提条件

このメソッドを使うには、最初に次の作業を行う必要があります。

* Windows ストア提出 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。
* このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら、新しいトークンを取得できます。

>**注:**&nbsp;&nbsp;このメソッドは、Windows ストア提出 API を使用するアクセス許可が与えられた Windows デベロッパー センター アカウントにのみ使用できます。 すべてのアカウントでこのアクセス許可が有効になっているとは限りません。

## 要求

このメソッドの構文は次のとおりです。 ヘッダーと要求本文の使用例と説明については、次のセクションをご覧ください。

| メソッド | 要求 URI                                                      |
|--------|------------------------------------------------------------------|
| GET    | ```https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/{inAppProductId}``` |

<span/>
 

### 要求ヘッダー

| ヘッダー        | 型   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| Authorization | string | 必須。 **Bearer** &lt;*token*&gt; という形式の Azure AD アクセス トークン。 |

<span/>

### 要求パラメーター

| 名前        | 型   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| id | string | 必須。 取得するアドオンのストア ID。 ストア ID はデベロッパー センター ダッシュボードで確認できます。  |

<span/>

### 要求本文

このメソッドでは要求本文を指定しないでください。

<span/>

### 要求の例

次の例は、アドオンの情報を取得する方法を示しています。

```
GET https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/9NBLGGH4TNMP HTTP/1.1
Authorization: Bearer <your access token>
```

## 応答

次の例は、このメソッドが正常に呼び出された場合の JSON 応答本文を示しています。 応答の本文内の値について詳しくは、[アドオンのリソース](manage-add-ons.md#add-on-object)をご覧ください。

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
  "productId": "Test-add-on",
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

## エラー コード

要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。

| エラー コード |  説明   |
|--------|------------------|
| 404  | 指定したアドオンは見つかりませんでした。 |
| 409  | アドオンは、[Windows ストア提出 API で現在サポートされていない](create-and-manage-submissions-using-windows-store-services.md#not_supported)デベロッパー センターのダッシュボード機能を使用します。  |

<span/>

## 関連トピック

* [Windows ストア サービスを使用した提出の作成と管理](create-and-manage-submissions-using-windows-store-services.md)
* [アドオンの提出の管理](manage-add-on-submissions.md)
* [すべてのアドオンの入手](get-all-add-ons.md)
* [アドオンの作成](create-an-add-on.md)
* [アドオンの削除](delete-an-add-on.md)



<!--HONumber=Aug16_HO5-->


