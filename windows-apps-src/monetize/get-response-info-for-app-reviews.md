---
ms.assetid: fb6bb856-7a1b-4312-a602-f500646a3119
description: 特定のレビューに返信できるかどうかを判断したり、特定のアプリに関するいずれかのレビューに返信できるかどうかを判断したりするには、Microsoft Store レビュー API の以下のメソッドを使います。
title: レビューへの返信情報の取得
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, Store サービス, Microsoft Store レビュー API, 返信情報
ms.localizationpriority: medium
ms.openlocfilehash: 095afd1eab9b7bd0acdac7c38d9e8e99dd59f38c
ms.sourcegitcommit: fca0132794ec187e90b2ebdad862f22d9f6c0db8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/24/2019
ms.locfileid: "63785760"
---
# <a name="get-response-info-for-reviews"></a>レビューへの返信情報の取得

アプリのユーザー レビューにプログラムで返信する場合は、Microsoft Store レビュー API の以下のメソッドを使って、まずレビューに返信する権限があるかどうかを確認します。 レビューの返信を受け取らないことを選択している顧客が送信したレビューに返信することはできません。 レビューに返信できることを確認した後、[アプリのレビューに返信を送信する](submit-responses-to-app-reviews.md)メソッドを使って、プログラムでレビューに返信します。


## <a name="prerequisites"></a>前提条件

このメソッドを使うには、最初に次の作業を行う必要があります。

* Microsoft Store 分析 API に関するすべての[前提条件](respond-to-reviews-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。
* このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](respond-to-reviews-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら新しいトークンを取得できます。
* 返信できるかどうかを確認するために、対象となるレビューの ID を取得します。 レビュー ID は、Microsoft Store 分析 API の[アプリのレビューの取得](get-app-reviews.md)メソッドの応答データ、および[レビュー レポート](../publish/reviews-report.md)の[オフライン ダウンロード](../publish/download-analytic-reports.md)で取得できます。

## <a name="request"></a>要求


### <a name="request-syntax"></a>要求の構文

| メソッド | 要求 URI                                                      |
|--------|------------------------------------------------------------------|
| GET    | ```https://manage.devcenter.microsoft.com/v1.0/my/reviews/{reviewId}/apps/{applicationId}/responses/info``` |


### <a name="request-header"></a>要求ヘッダー

| Header        | 種類   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| Authorization | string | 必須。 **Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。 |


### <a name="request-parameters"></a>要求パラメーター

| パラメーター        | 種類   | 説明                                     |  必須  |
|---------------|--------|--------------------------------------------------|--------------|
| applicationId | string | 返信できるかどうかを確認するレビューを含むアプリのストア ID です。 Store ID は、[アプリ id のページ](../publish/view-app-identity-details.md)パートナー センターでします。 ストア ID は、たとえば 9WZDNCRFJ3Q8 のような文字列です。 |  〇  |
| reviewId | string | 返信するレビューの ID です (これは GUID です)。 レビュー ID は、Microsoft Store 分析 API の[アプリのレビューの取得](get-app-reviews.md)メソッドの応答データ、および[レビュー レポート](../publish/reviews-report.md)の[オフライン ダウンロード](../publish/download-analytic-reports.md)で取得できます。 <br/>このパラメーターを省略すると、このメソッドの応答の本文は、指定されたアプリの任意のレビューに返信する権限があるかどうかを示します。 |  X  |


### <a name="request-example"></a>要求の例

次の例では、このメソッドを使って、特定のレビューに返信できるかどうかを判断する方法を示します。

```syntax
GET https://manage.devcenter.microsoft.com/v1.0/my/reviews/6be543ff-1c9c-4534-aced-af8b4fbe0316/apps/9WZDNCRFJ3Q8/responses/info HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a>応答


### <a name="response-body"></a>応答本文

| Value      | 種類   | 説明    |  
|------------|--------|-----------------------|
| CanRespond      | ブール値  | 値が **true** の場合は、指定されたレビューに返信できること、または指定されたアプリのすべてのレビューに返信する権限があることを示します。 それ以外の場合、この値は **false** です。       |
| DefaultSupportEmail  | string |  アプリのストア登録情報で指定されているアプリの[サポート メール アドレス](../publish/enter-app-properties.md#support-contact-info)です。 サポート メール アドレスを指定しなかった場合、このフィールドは空です。    |

 
### <a name="response-example"></a>応答の例

この要求の JSON 返信の本文の例を次に示します。

```json
{
  "CanRespond": true,
  "DefaultSupportEmail": "support@contoso.com"
}
```

## <a name="related-topics"></a>関連トピック

* [Microsoft Store analytics API を使用してレビューへの応答を送信します。](submit-responses-to-app-reviews.md)
* [パートナー センターを使用して顧客レビューに応答します。](../publish/respond-to-customer-reviews.md)
* [Microsoft Store サービスを使用してレビューに応答します。](respond-to-reviews-using-windows-store-services.md)
* [アプリのレビューを取得します。](get-app-reviews.md)
