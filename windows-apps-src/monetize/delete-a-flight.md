---
ms.assetid: AD80F9B3-CED0-40BD-A199-AB81CDAE466C
description: パートナー センター アカウントに登録されているアプリのパッケージ フライトを削除する、Microsoft Store 申請 API でこのメソッドを使います。
title: パッケージ フライトの削除
ms.date: 04/17/2018
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store 申請 API, フライトの削除
ms.localizationpriority: medium
ms.openlocfilehash: fa3fa78c695538ec13dbd20d38a24224c560463e
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8930156"
---
# <a name="delete-a-package-flight"></a>パッケージ フライトの削除

パートナー センター アカウントに登録されているアプリのパッケージ フライトを削除する、Microsoft Store 申請 API でこのメソッドを使います。


## <a name="prerequisites"></a>前提条件

このメソッドを使うには、最初に次の作業を行う必要があります。

* Microsoft Store 申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。
* このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら、新しいトークンを取得できます。

## <a name="request"></a>要求

このメソッドの構文は次のとおりです。 ヘッダーと要求本文の使用例と説明については、次のセクションをご覧ください。

| メソッド | 要求 URI                                                      |
|--------|------------------------------------------------------------------|
| DELETE    | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}``` |


### <a name="request-header"></a>要求ヘッダー

| ヘッダー        | 型   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| Authorization | string | 必須。 **Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。 |


### <a name="request-parameters"></a>要求パラメーター

| 名前        | 種類   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| applicationId | string | 必須。 削除するパッケージ フライトが含まれるアプリのストア ID。 アプリのストア ID は、パートナー センターで利用できます。  |
| flightId | string | 必須。 削除するパッケージ フライトの ID。 この ID は、[パッケージ フライトの作成](create-a-flight.md)要求と[アプリのパッケージ フライトの取得](get-flights-for-an-app.md)要求の応答データで確認できます。 パートナー センターで作成されたフライトはこの ID はパートナー センターでのフライト ページの URL で利用可能なもします。  |


### <a name="request-body"></a>要求本文

このメソッドでは要求本文を指定しないでください。


### <a name="request-example"></a>要求の例

次の例は、新しいパッケージ フライトを削除する方法を示しています。

```
DELETE https://manage.devcenter.microsoft.com/v1.0/my/applications/9NBLGGH4R315/flights/43e448df-97c9-4a43-a0bc-2a445e736bcd HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a>応答

成功した場合、このメソッドは空の応答の本文を返します。

## <a name="error-codes"></a>エラー コード

要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。

| エラー コード |  説明                                                                                                                                                                           |
|--------|------------------|
| 400  | 要求パラメーターが有効ではありません。 |
| 404  | 指定されたパッケージ フライトは見つかりませんでした。  |
| 409  | 指定されたパッケージ フライトは見つかりましたが、現在の状態で削除できなかった可能性がありますか、アプリが[Microsoft Store 申請 API で現在サポートされている](create-and-manage-submissions-using-windows-store-services.md#not_supported)はパートナー センター機能を使用します。 |   


## <a name="related-topics"></a>関連トピック

* [Microsoft Store サービスを使用した申請の作成と管理](create-and-manage-submissions-using-windows-store-services.md)
* [パッケージ フライトの作成](create-a-flight.md)
* [パッケージ フライトの取得](get-a-flight.md)
