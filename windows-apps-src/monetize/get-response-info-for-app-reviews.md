---
author: mcleanbyron
ms.assetid: fb6bb856-7a1b-4312-a602-f500646a3119
description: "Windows ストア レビュー API のこのメソッドを使用して、特定のレビューに返信できるかどうかや、特定のアプリの任意のレビューに返信できるかどうかを特定します。"
title: "アプリのレビューへの返信情報の取得"
ms.author: mcleans
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, ストア サービス, Windowsストア レビュー API, 返信情報"
translationtype: Human Translation
ms.sourcegitcommit: 5645eee3dc2ef67b5263b08800b0f96eb8a0a7da
ms.openlocfilehash: 88e6158bfc5df23e5c2056624e353b38b39c7331
ms.lasthandoff: 02/08/2017

---

# <a name="get-response-info-for-app-reviews"></a>アプリのレビューへの返信情報の取得

アプリのユーザー レビューにプログラムで返信する場合は、Windows ストア レビュー API のこのメソッドを使用して、まずレビューに返信する権限があるかどうかを確認します。 レビューの返信を受け取らないことを選択している顧客が送信したレビューに返信することはできません。 レビューに返信できることを確認した後、[アプリのレビューに返信を送信する](submit-responses-to-app-reviews.md)メソッドを使って、プログラムでレビューに返信します。


## <a name="prerequisites"></a>前提条件

このメソッドを使うには、最初に次の作業を行う必要があります。

* Windows ストア分析 API に関するすべての[前提条件](respond-to-reviews-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。
* このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](respond-to-reviews-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら、新しいトークンを取得できます。
* 返信できるかどうかを確認するために、対象となるレビューの ID を取得します。 レビュー ID は、Windows ストア分析 API の[アプリ レビューの取得](get-app-reviews.md)メソッドの返信データ、および[レビュー レポート](../publish/reviews-report.md)の[オフライン ダウンロード](../publish/download-analytic-reports.md)で入手できます。

## <a name="request"></a>要求


### <a name="request-syntax"></a>要求の構文

| メソッド | 要求 URI                                                      |
|--------|------------------------------------------------------------------|
| GET    | ```https://manage.devcenter.microsoft.com/v1.0/my/reviews/{reviewId}/apps/{applicationId}/responses/info``` |

<span/> 

### <a name="request-header"></a>要求ヘッダー

| ヘッダー        | 型   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| Authorization | string | 必須。 **Bearer** &lt;*token*&gt; という形式の Azure AD アクセス トークン。 |

<span/> 

### <a name="request-parameters"></a>要求パラメーター

| パラメーター        | 型   | 説明                                     |  必須かどうか  |
|---------------|--------|--------------------------------------------------|--------------|
| applicationId | string | 返信できるかどうかを確認するレビューを含むアプリのストア ID です。 ストア ID は、デベロッパー センター ダッシュボードの[アプリ ID ページ](../publish/view-app-identity-details.md)で確認できます。 ストア ID は、たとえば 9WZDNCRFJ3Q8 のような文字列です。 |  必須  |
| reviewId | string | 返信するレビューの ID です (これは GUID です)。 レビュー ID は、Windows ストア分析 API の[アプリ レビューの取得](get-app-reviews.md)メソッドの返信データ、および[レビュー レポート](../publish/reviews-report.md)の[オフライン ダウンロード](../publish/download-analytic-reports.md)で入手できます。 <br/>このパラメーターを省略すると、このメソッドの応答の本文は、指定されたアプリの任意のレビューに返信する権限があるかどうかを示します。 |  必須ではない  |

<span/>

### <a name="request-example"></a>要求の例

次の例では、このメソッドを使って、特定のレビューに返信できるかどうかを判断する方法を示します。

```syntax
GET https://manage.devcenter.microsoft.com/v1.0/my/reviews/6be543ff-1c9c-4534-aced-af8b4fbe0316/apps/9WZDNCRFJ3Q8/responses/info HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a>応答


### <a name="response-body"></a>応答本文

| 設定値      | 型   | 説明    |  
|------------|--------|-----------------------|
| CanRespond      | ブール値  | 値が **true** の場合は、指定されたレビューに返信できること、または指定されたアプリのすべてのレビューに返信する権限があることを示します。 それ以外の場合、この値は **false** です。       |
| DefaultSupportEmail  | string |  アプリのストア登録情報で指定されているアプリの[サポート メール アドレス](../publish/create-app-store-listings.md#support-contact-info)です。 サポート メール アドレスを指定しなかった場合、このフィールドは空です。    |

<span/>
 
### <a name="response-example"></a>応答の例

この要求の JSON 応答の本文の例を次に示します。

```json
{
  "CanRespond": true,
  "DefaultSupportEmail": "support@contoso.com"
}
```

## <a name="related-topics"></a>関連トピック

* [Windows ストア分析 API を使ってレビューに返信を送信する](submit-responses-to-app-reviews.md)
* [デベロッパー センターのダッシュボードを使用して顧客のレビューに返信する](../publish/respond-to-customer-reviews.md)
* [Windows ストアのサービスを使ってレビューに返信する](respond-to-reviews-using-windows-store-services.md)
* [アプリのレビューの取得](get-app-reviews.md)

