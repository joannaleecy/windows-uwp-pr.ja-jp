---
author: mcleanbyron
ms.assetid: 16D4C3B9-FC9B-46ED-9F87-1517E1B549FA
description: Windows デベロッパー センター アカウントに登録されているアプリのアドオンを削除するには、Microsoft Store 申請 API の以下のメソッドを使います。
title: アドオンの削除
ms.author: mcleans
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, Microsoft Store 申請 API, アドオン, 削除, アプリ内製品, IAP
ms.localizationpriority: medium
ms.openlocfilehash: 95743f600b2f688a09f3fe96bd7e58acc93da5d2
ms.sourcegitcommit: 1773bec0f46906d7b4d71451ba03f47017a87fec
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/17/2018
ms.locfileid: "1661992"
---
# <a name="delete-an-add-on"></a>アドオンの削除

Windows デベロッパー センター アカウントに登録されているアプリのアドオン (アプリ内製品または IAP とも呼ばれます) を削除するには、Microsoft Store 申請 API の以下のメソッドを使います。

## <a name="prerequisites"></a>前提条件

このメソッドを使うには、最初に次の作業を行う必要があります。

* Microsoft Store 申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。
* このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら新しいトークンを取得できます。

## <a name="request"></a>要求

このメソッドの構文は次のとおりです。 ヘッダーと要求本文の使用例と説明については、次のセクションをご覧ください。

| メソッド | 要求 URI                                                      |
|--------|------------------------------------------------------------------|
| DELETE    | ```https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/{inAppProductId}``` |


### <a name="request-header"></a>要求ヘッダー

| ヘッダー        | 型   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| Authorization | 文字列 | 必須。 **Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。 |


### <a name="request-parameters"></a>要求パラメーター

| 名前        | 種類   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| id | string | 必須。 削除するアドオンのストア ID。 ストア ID はデベロッパー センター ダッシュボードで確認できます。  |


### <a name="request-body"></a>要求本文

このメソッドでは要求本文を指定しないでください。


### <a name="request-example"></a>要求の例

次の例は、アドオンを削除する方法を示しています。

```
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
| 409  | 指定したアドオンは見つかりましたが、現在の状態で削除できなかったか、[Microsoft Store 申請 API で現在サポートされていない](create-and-manage-submissions-using-windows-store-services.md#not_supported)デベロッパー センター ダッシュボード機能がアドオンで使用されています。 |   


## <a name="related-topics"></a>関連トピック

* [Microsoft Store サービスを使用した申請の作成と管理](create-and-manage-submissions-using-windows-store-services.md)
* [すべてのアドオンの取得](get-all-add-ons.md)
* [アドオンの取得](get-an-add-on.md)
* [アドオンの作成](create-an-add-on.md)
