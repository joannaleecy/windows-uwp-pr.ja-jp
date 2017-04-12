---
author: mcleanbyron
ms.assetid: 038903d6-efab-4da6-96b5-046c7431e6e7
description: "アプリのレビューに返信を送るには、Windows ストア レビュー API に含まれる以下のメソッドを使用します。"
title: "レビューに対する返信の送信"
ms.author: mcleans
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, ストア サービス, Windows ストアレビュー API, アドオンの取得数"
ms.openlocfilehash: d418e64bf1608591e877da8339d1dda308611285
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="submit-responses-to-reviews"></a>レビューに対する返信の送信


アプリのレビューにプログラムで返信するには、Windows ストア レビュー API に含まれる以下のメソッドを使用します。 このメソッドを呼び出すときは、返信するレビューの ID を指定する必要があります。 レビュー ID は、Windows ストア分析 API の[アプリ レビューの取得](get-app-reviews.md)メソッドの返信データ、および[レビュー レポート](../publish/reviews-report.md)の[オフライン ダウンロード](../publish/download-analytic-reports.md)で入手できます。

顧客はレビューを送信するときに、レビューへの返信を受け取らないことを選択できます。 顧客が返信を受け取らないように指定しているレビューに返信すると、このメソッドの返信の本文には、返信ができなかったことが示されます。 このメソッドを呼び出す前に、任意で、[アプリのレビューへの返信情報の取得](get-response-info-for-app-reviews.md)メソッドを使用して、特定のレビューへの返信が許可されているかどうかを確認できます。

>**注**&nbsp;&nbsp;このメソッドを使用してプログラムによりレビューに返信するだけでなく、[Windows デベロッパー センター ダッシュボードを使用](../publish/respond-to-customer-reviews.md)して、レビューに返信することもできます。

## <a name="prerequisites"></a>前提条件

このメソッドを使うには、最初に次の作業を行う必要があります。

* Windows ストア レビュー API に関するすべての[前提条件](respond-to-reviews-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。
* このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](respond-to-reviews-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら、新しいトークンを取得できます。
* 返信するレビューの ID を取得します。 レビュー ID は、Windows ストア分析 API の[アプリ レビューの取得](get-app-reviews.md)メソッドの返信データ、および[レビュー レポート](../publish/reviews-report.md)の[オフライン ダウンロード](../publish/download-analytic-reports.md)で入手できます。

## <a name="request"></a>要求

### <a name="request-syntax"></a>要求の構文

| メソッド | 要求 URI                                                      |
|--------|------------------------------------------------------------------|
| POST    | ```https://manage.devcenter.microsoft.com/v1.0/my/reviews/responses``` |

<span/> 

### <a name="request-header"></a>要求ヘッダー

| ヘッダー        | 型   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| Authorization | string | 必須。 **Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。 |

<span/> 

### <a name="request-parameters"></a>要求パラメーター

このメソッドには要求パラメーターはありません。

<span/> 

### <a name="request-body"></a>要求本文

要求本文には次の値が含まれます。

| 値        | 型   | 説明                                                                 |
|---------------|--------|-----------------------------------------|
| Responses | array | 提出する返信を含むオブジェクトの配列です。 各オブジェクトのデータの詳細については、以下の表を参照してください。 |

*Responses* 配列内の各オブジェクトには、次の値が保持されています。

| 値        | 型   | 説明           |  必須かどうか  |
|---------------|--------|-----------------------------|-----|
| ApplicationId | string |  返信対象のレビューがあるアプリのストア ID です。 ストア ID は、デベロッパー センター ダッシュボードの[アプリ ID ページ](../publish/view-app-identity-details.md)で確認できます。 ストア ID は、たとえば 9WZDNCRFJ3Q8 のような文字列です。   |  〇  |
| ReviewId | string |  返信するレビューの ID です (これは GUID です)。 レビュー ID は、Windows ストア分析 API の[アプリ レビューの取得](get-app-reviews.md)メソッドの返信データ、および[レビュー レポート](../publish/reviews-report.md)の[オフライン ダウンロード](../publish/download-analytic-reports.md)で入手できます。   |  〇  |
| ResponseText | string | 提出する返信です。 返信は、[こちらのガイドライン](../publish/respond-to-customer-reviews.md#guidelines-for-responses)に従う必要があります。   |  〇  |
| SupportEmail | string | アプリのサポート メール アドレスです。顧客はこのアドレスを使用して、直接連絡できます。 したがって、有効なメール アドレスである必要があります。     |  〇  |
| IsPublic | Boolean |  値が **true** の場合、返信はアプリのストア登録情報の顧客のレビューのすぐ下に表示され、すべての顧客から見える状態になることを示します。 値が **false** の場合は、返信はメールで顧客に送信され、アプリのストア登録情報内で他の顧客には見える状態でないことを示します。     |  〇  |

### <a name="request-example"></a>要求の例

次の例は、このメソッドを使用して、いくつかのレビューに返信を提出する方法を示しています。

```json
POST https://manage.devcenter.microsoft.com/v1.0/my/reviews/responses HTTP/1.1
Authorization: Bearer <your access token>
Content-Type: application/json
{
  "Responses": [
    {
      "ApplicationId": "9WZDNCRFJ3Q8",
      "ReviewId": "6be543ff-1c9c-4534-aced-af8b4fbe0316",
      "ResponseText": "Thank you for pointing out this bug. I fixed it and published an update, you should have the fix soon",
      "SupportEmail": "support@contoso.com",
      "IsPublic": "true"
    },
    {
      "ApplicationId": "9NBLGGH1RP08",
      "ReviewId": "80c9671a-96c2-4278-bcbc-be0ce5a32a7c",
      "ResponseText": "Thank you for submitting your review. Can you tell more about what you were doing in the app when it froze? Thanks very much for your help.",
      "SupportEmail": "support@contoso.com",
      "IsPublic": "false"
    }
  ]
}
```

## <a name="response"></a>返信

### <a name="response-body"></a>返信本文

| 値        | 型   | 説明            |
|---------------|--------|---------------------|
| Result | array | 提出した各返信についてのデータを保持するオブジェクトの配列です。 各オブジェクトのデータの詳細については、以下の表を参照してください。  |

*Result* 配列内の各オブジェクトには、次の値が保持されています。

| 値        | 型   | 説明                                                                 |
|---------------|--------|-----------------------------------------------|
| ApplicationId | string |  返信対象のレビューがあるアプリのストア ID です。 ストア ID は、たとえば 9WZDNCRFJ3Q8 のような文字列です。   |
| ReviewId | string |  返信するレビューの ID です。 これは GUID です。   |
| Successful | string | 値が **true** の場合、返信が正常に送信されたことを示します。 値が **false** の場合、返信は提出できなかったことを示します。    |
| FailureReason | string | **Successful** が **false** の場合、この値には失敗の理由が含まれます。 **Successful** が **true** の場合、この値は空です。      |

### <a name="response-example"></a>返信の例

この要求の JSON 返信の本文の例を次に示します。

```json
{
  "Result": [
    {
      "ApplicationId": "9WZDNCRFJ3Q8",
      "ReviewId": "6be543ff-1c9c-4534-aced-af8b4fbe0316",
      "Successful": "true",
      "FailureReason": ""
    },
    {
      "ApplicationId": "9NBLGGH1RP08",
      "ReviewId": "80c9671a-96c2-4278-bcbc-be0ce5a32a7c",
      "Successful": "false",
      "FailureReason": "No Permission"
    }
  ]
}
```

## <a name="related-topics"></a>関連トピック

* [デベロッパー センターのダッシュボードを使用して顧客のレビューに返信する](../publish/respond-to-customer-reviews.md)
* [Windows ストアのサービスを使ってレビューに返信する](respond-to-reviews-using-windows-store-services.md)
* [アプリのレビューへの返信情報の取得](get-response-info-for-app-reviews.md)
* [アプリのレビューの取得](get-app-reviews.md)
