---
ms.assetid: 5BD650D2-AA26-4DE9-8243-374FDB7D932B
description: Microsoft Store 送信 API でこのメソッドを使用すると、PartnerCenter アカウントに登録されているアプリ用のアドオンを作成できます。
title: アドオンの作成
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store 申請 API, アドオンの作成, アプリ内製品, IAP
ms.localizationpriority: medium
ms.openlocfilehash: b358eecd1799e76573cf6d254a80e7a7971bc123
ms.sourcegitcommit: 6a7dd4da2fc31ced7d1cdc6f7cf79c2e55dc5833
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/21/2019
ms.locfileid: "58334170"
---
# <a name="create-an-add-on"></a>アドオンの作成

Microsoft Store 送信 API でこのメソッドを使用すると、パートナー センター アカウントに登録されているアプリ用のアドオン (とも呼ばれるアプリ内製品または IAP) を作成できます。

> [!NOTE]
> このメソッドは、申請なしでアドオンを作成します。 アドオンの申請を作成する方法については、「[アドオンの申請の管理](manage-add-on-submissions.md)」のメソッドをご覧ください。

## <a name="prerequisites"></a>前提条件

このメソッドを使うには、最初に次の作業を行う必要があります。

* Microsoft Store 申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。
* このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら新しいトークンを取得できます。

## <a name="request"></a>要求

このメソッドの構文は次のとおりです。 ヘッダーと要求本文の使用例と説明については、次のセクションをご覧ください。

| メソッド | 要求 URI                                                      |
|--------|------------------------------------------------------------------|
| POST    | `https://manage.devcenter.microsoft.com/v1.0/my/inappproducts` |


### <a name="request-header"></a>要求ヘッダー

| Header        | 種類   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| Authorization | string | 必須。 **Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。 |


### <a name="request-body"></a>要求本文

要求本文には次のパラメーターがあります。

|  パラメーター  |  種類  |  説明  |  必須  |
|------|------|------|------|
|  applicationIds  |  array  |  このアドオンが関連付けられるアプリのストア ID を含む配列です。 この配列でサポートされる項目は 1 つのみです。   |  〇  |
|  productId  |  string  |  アドオンの製品 ID です。 これは、アドオンを参照する、コード内で使用できる識別子です。 詳しくは、「[IAP の製品の種類と製品 ID を設定する](https://msdn.microsoft.com/windows/uwp/publish/set-your-iap-product-id)」をご覧ください。  |  〇  |
|  productType  |  string  |  アドオンの製品の種類です。 次の値がサポートされています。**持続性のある**と**消耗**します。  |  〇  |


### <a name="request-example"></a>要求の例

次の例は、アプリの新しいコンシューマブルなアドオンを作成する方法を示しています。

```json
POST https://manage.devcenter.microsoft.com/v1.0/my/inappproducts HTTP/1.1
Authorization: Bearer eyJ0eXAiOiJKV1Q...
Content-Type: application/json
{
    "applicationIds": [  "9NBLGGH4R315"  ],
    "productId": "my-new-add-on",
    "productType": "Consumable",
}
```

## <a name="response"></a>応答

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

## <a name="error-codes"></a>エラー コード

要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。

| エラー コード |  説明                                                                                                                                                                           |
|--------|------------------|
| 400  | 要求が無効です。 |
| 409  | 現在の状態のため、アドオンを作成できませんでしたまたはアドオンであるパートナー センター機能を使用する[いない現在 Microsoft Store 送信 API ではサポートされて](create-and-manage-submissions-using-windows-store-services.md#not_supported)します。 |   


## <a name="related-topics"></a>関連トピック

* [作成し、Microsoft Store サービスを使用して送信の管理](create-and-manage-submissions-using-windows-store-services.md)
* [アドオンの送信を管理します。](manage-add-on-submissions.md)
* [すべてのアドオンを入手します。](get-all-add-ons.md)
* [アドオンを入手します。](get-an-add-on.md)
* [アドオンを削除します。](delete-an-add-on.md)
