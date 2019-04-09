---
ms.assetid: 16D4C3B9-FC9B-46ED-9F87-1517E1B549FA
description: Microsoft Store 送信 API でこのメソッドを使用すると、パートナー センター アカウントに登録されているアプリ用のアドオンを削除できます。
title: アドオンの削除
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store 申請 API, アドオン, 削除, アプリ内製品, IAP
ms.localizationpriority: medium
ms.openlocfilehash: 5540dfbdc185eae405b2cdde7f18faee0efd0cac
ms.sourcegitcommit: 6a7dd4da2fc31ced7d1cdc6f7cf79c2e55dc5833
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/21/2019
ms.locfileid: "58334621"
---
# <a name="delete-an-add-on"></a>アドオンの削除

Microsoft Store 送信 API でこのメソッドを使用すると、パートナー センター アカウントに登録されているアプリ用のアドオン (とも呼ばれるアプリ内製品または IAP) を削除できます。

## <a name="prerequisites"></a>前提条件

このメソッドを使うには、最初に次の作業を行う必要があります。

* Microsoft Store 申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。
* このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら新しいトークンを取得できます。

## <a name="request"></a>要求

このメソッドの構文は次のとおりです。 ヘッダーと要求本文の使用例と説明については、次のセクションをご覧ください。

| メソッド | 要求 URI                                                      |
|--------|------------------------------------------------------------------|
| Del    | `https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/{inAppProductId}` |


### <a name="request-header"></a>要求ヘッダー

| Header        | 種類   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| Authorization | string | 必須。 **Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。 |


### <a name="request-parameters"></a>要求パラメーター

| 名前        | 種類   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| id | string | 必須。 削除するアドオンのストア ID。 Store ID は、パートナー センターで使用できます。  |


### <a name="request-body"></a>要求本文

このメソッドでは要求本文を指定しないでください。


### <a name="request-example"></a>要求の例

次の例は、アドオンを削除する方法を示しています。

```json
DELETE https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/9NBLGGH4TNMP HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a>応答

成功した場合、このメソッドは空の応答の本文を返します。

## <a name="error-codes"></a>エラー コード

要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。

| エラー コード |  説明                                                                                                                                                                           |
|--------|------------------|
| 400  | 要求が無効です。 |
| 404  | 指定したアドオンは見つかりませんでした。  |
| 409  | 指定されたアドオンが見つかりましたが、現在の状態で削除できませんでしたまたはアドオンであるパートナー センターの機能を使用して[現在サポートされていません、Microsoft Store 送信 API](create-and-manage-submissions-using-windows-store-services.md#not_supported)します。 |   


## <a name="related-topics"></a>関連トピック

* [作成し、Microsoft Store サービスを使用して送信の管理](create-and-manage-submissions-using-windows-store-services.md)
* [すべてのアドオンを入手します。](get-all-add-ons.md)
* [アドオンを入手します。](get-an-add-on.md)
* [アドオンを作成します。](create-an-add-on.md)
