---
author: mcleanbyron
ms.assetid: D677E126-C3D6-46B6-87A5-6237EBEDF1A9
description: "既存のアドオンの申請を削除するには、Windows ストア申請 API のこのメソッドを使います。"
title: "Windows ストア申請 API を使用したアドオンの申請の削除"
ms.author: mcleans
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, Windows ストア申請 API, アドオンの申請, 削除, アプリ内製品, IAP"
translationtype: Human Translation
ms.sourcegitcommit: c6b64cff1bbebc8ba69bc6e03d34b69f85e798fc
ms.openlocfilehash: 117ed98dc961231cdbc7258b1097b7e0452efe35
ms.lasthandoff: 02/07/2017

---

# <a name="delete-an-add-on-submission-using-the-windows-store-submission-api"></a>Windows ストア申請 API を使用したアドオンの申請の削除




既存のアドオン (アプリ内製品 (IAP) とも呼ばれます) を削除するには、Windows ストア申請 API 内のこのメソッドを使います。

## <a name="prerequisites"></a>前提条件

このメソッドを使うには、最初に次の作業を行う必要があります。

* Windows ストア申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。
* このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら新しいトークンを取得できます。

>**注:**&nbsp;&nbsp;このメソッドは、Windows ストア提出 API を使用するアクセス許可が付与された Windows デベロッパー センター アカウントにのみ使用できます。 すべてのアカウントでこのアクセス許可が有効になっているとは限りません。

## <a name="request"></a>要求

このメソッドの構文は次のとおりです。 ヘッダーと要求本文の使用例と説明については、次のセクションをご覧ください。

| メソッド | 要求 URI                                                      |
|--------|------------------------------------------------------------------|
| DELETE    | ```https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/{inAppProductId}/submissions/{submissionId}``` |

<span/>
 

### <a name="request-header"></a>要求ヘッダー

| ヘッダー        | 型   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| Authorization | string | 必須。 **Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。 |

<span/>

### <a name="request-parameters"></a>要求パラメーター

| 名前        | 型   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| inAppProductId | string | 必須。 削除する申請に含まれているアドオンのストア ID です。 ストア ID はデベロッパー センター ダッシュボードで確認できます。  |
| submissionId | string | 必須。 削除する申請の ID です。 この ID は、[アドオン申請の作成](create-an-add-on-submission.md)要求の応答データに含まれており、デベロッパー センター ダッシュボードで確認できます。  |

<span/>

### <a name="request-body"></a>要求本文

このメソッドでは要求本文を指定しないでください。

<span/>

### <a name="request-example"></a>要求の例

次の例は、アドオンの申請を削除する方法を示しています。

```
DELETE https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/9NBLGGH4TNMP/submissions/1152921504621230023 HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a>応答

成功した場合、このメソッドは空の応答の本文を返します。

## <a name="error-codes"></a>エラー コード

要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。

| エラー コード |  説明   |
|--------|------------------|
| 400  | 要求パラメーターが有効ではありません。 |
| 404  | 指定した申請は見つかりませんでした。 |
| 409  | 指定した申請は見つかりましたが、現在の状態で削除できなかったか、[Windows ストア申請 API で現在サポートされていない](create-and-manage-submissions-using-windows-store-services.md#not_supported)デベロッパー センター ダッシュボード機能がアドオンで使用されています。 |

<span/>

## <a name="related-topics"></a>関連トピック

* [Windows ストア サービスを使用した提出の作成と管理](create-and-manage-submissions-using-windows-store-services.md)
* [アドオンの提出の取得](get-an-add-on-submission.md)
* [アドオンの申請の作成](create-an-add-on-submission.md)
* [アドオンの申請のコミット](commit-an-add-on-submission.md)
* [アドオンの申請の更新](update-an-add-on-submission.md)
* [アドオンの申請の状態の取得](get-status-for-an-add-on-submission.md)

