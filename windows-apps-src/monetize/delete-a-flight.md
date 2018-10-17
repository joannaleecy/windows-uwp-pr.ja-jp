---
author: Xansky
ms.assetid: AD80F9B3-CED0-40BD-A199-AB81CDAE466C
description: Windows デベロッパー センター アカウントに登録されているアプリのパッケージ フライトを削除するには、Microsoft Store 申請 API の以下のメソッドを使います。
title: パッケージ フライトの削除
ms.author: mhopkins
ms.date: 04/17/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, Microsoft Store 申請 API, フライトの削除
ms.localizationpriority: medium
ms.openlocfilehash: 436a28cc1be0c106928784086731fe078d789527
ms.sourcegitcommit: 1c6325aa572868b789fcdd2efc9203f67a83872a
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/17/2018
ms.locfileid: "4746283"
---
# <a name="delete-a-package-flight"></a>パッケージ フライトの削除

Windows デベロッパー センター アカウントに登録されているアプリのパッケージ フライトを削除するには、Microsoft Store 申請 API の以下のメソッドを使います。


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
| applicationId | string | 必須。 削除するパッケージ フライトが含まれるアプリのストア ID。 アプリのストア ID は、デベロッパー センター ダッシュボードで確認できます。  |
| flightId | string | 必須。 削除するパッケージ フライトの ID。 この ID は、[パッケージ フライトの作成](create-a-flight.md)要求と[アプリのパッケージ フライトの取得](get-flights-for-an-app.md)要求の応答データで確認できます。 デベロッパー センター ダッシュボードで作成されたフライトの場合、この ID はダッシュボードのフライト ページの URL にも含まれています。  |


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
| 409  | 指定したパッケージ フライトは見つかりましたが、現在の状態で削除できなかったか、[Microsoft Store 申請 API で現在サポートされていない](create-and-manage-submissions-using-windows-store-services.md#not_supported)デベロッパー センター ダッシュボード機能がアプリで使用されています。 |   


## <a name="related-topics"></a>関連トピック

* [Microsoft Store サービスを使用した申請の作成と管理](create-and-manage-submissions-using-windows-store-services.md)
* [パッケージ フライトの作成](create-a-flight.md)
* [パッケージ フライトの取得](get-a-flight.md)
