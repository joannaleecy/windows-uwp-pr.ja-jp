---
author: mcleanbyron
ms.assetid: 5BD650D2-AA26-4DE9-8243-374FDB7D932B
description: "Windows ストア申請 API 内のこのメソッドを使用して、Windows デベロッパー センター アカウントに登録されいているアプリのアドオンを作成します。"
title: "Windows ストア申請 API を使用したアドオンの作成"
translationtype: Human Translation
ms.sourcegitcommit: 5f975d0a99539292e1ce91ca09dbd5fac11c4a49
ms.openlocfilehash: 11cf25fbeacbe3145c9cc3f4a80bdcce3028bf55

---

# Windows ストア申請 API を使用したアドオンの作成




Windows ストア申請 API 内のこのメソッドを使用して、Windows デベロッパー センター アカウントに登録されているアプリのアドオン (アプリ内製品または IAP とも呼ばれます) を作成します。

>**注:**&nbsp;&nbsp;このメソッドは、申請なしでアドオンを作成します。 アドオンの申請を作成する方法については、「[アドオンの申請の管理](manage-add-on-submissions.md)」のメソッドをご覧ください。

## 前提条件

このメソッドを使うには、最初に次の作業を行う必要があります。

* Windows ストア申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。
* このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら、新しいトークンを取得できます。

>**注:**&nbsp;&nbsp;このメソッドは、Windows ストア申請 API を使用するアクセス許可が付与された Windows デベロッパー センター アカウントにのみ使用できます。 すべてのアカウントでこのアクセス許可が有効になっているとは限りません。

## 要求

このメソッドの構文は次のとおりです。 ヘッダーと要求本文の使用例と説明については、次のセクションをご覧ください。

| メソッド | 要求 URI                                                      |
|--------|------------------------------------------------------------------|
| POST    | ```https://manage.devcenter.microsoft.com/v1.0/my/inappproducts``` |

<span/>
 

### 要求ヘッダー

| ヘッダー        | 型   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| Authorization | string | 必須。 **Bearer** &lt;*token*&gt; という形式の Azure AD アクセス トークン。 |

<span/>

### 要求本文

要求本文には次のパラメーターがあります。
 
|  パラメーター  |  型  |  説明  |  必須かどうか  |
|------|------|------|------|
|  applicationIds  |  array  |  このアドオンが関連付けられるアプリのストア ID を含む配列です。 この配列でサポートされる項目は 1 つのみです。   |  はい  |
|  productId  |  string  |  アドオンの製品 ID です。 これは、アドオンを参照する、コード内で使用できる識別子です。 詳しくは、「[IAP の製品の種類と製品 ID を設定する](https://msdn.microsoft.com/windows/uwp/publish/set-your-iap-product-id)」をご覧ください。  |  はい  |
|  productType  |  string  |  アドオンの製品の種類です。 値 **Durable** と **Consumable** がサポートされています。  |  はい  |

<span/>

### 要求の例

次の例は、アプリの新しいコンシューマブルなアドオンを作成する方法を示しています。

```syntax
POST https://manage.devcenter.microsoft.com/v1.0/my/inappproducts HTTP/1.1
Authorization: Bearer eyJ0eXAiOiJKV1Q...
Content-Type: application/json
{
    "applicationIds": [  "9NBLGGH4R315"  ],
    "productId": "my-new-add-on",
    "productType": "Consumable",
}
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
  "productId": "my-new-add-on",
  "productType": "Consumable",
}
```

## エラー コード

要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。

| エラー コード |  説明                                                                                                                                                                           |
|--------|------------------|
| 400  | 要求が無効です。 |
| 409  | 現在の状態が原因でアドオンを作成できませんでした。または、[Windows ストア申請 API で現在サポートされていない](create-and-manage-submissions-using-windows-store-services.md#not_supported)デベロッパー センター ダッシュボード機能がアドオンで使用されています。 |   

<span/>

## 関連トピック

* [Windows ストア サービスを使用した申請の作成と管理](create-and-manage-submissions-using-windows-store-services.md)
* [アドオンの申請の管理](manage-add-on-submissions.md)
* [すべてのアドオンの入手](get-all-add-ons.md)
* [アドオンの入手](get-an-add-on.md)
* [アドオンの削除](delete-an-add-on.md)



<!--HONumber=Aug16_HO5-->


