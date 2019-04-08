---
ms.assetid: FA55C65C-584A-4B9B-8451-E9C659882EDE
description: 無料のアプリまたはアドオンを特定のユーザーに付与するには、Microsoft Store 購入 API の以下のメソッドを使います。
title: 無料の製品の付与
ms.date: 03/19/2018
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store 購入 API, 製品の付与
ms.localizationpriority: medium
ms.openlocfilehash: 957958891b1052be4ac9ae65d90f97ff8a44ef36
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57613197"
---
# <a name="grant-free-products"></a>無料の製品の付与

無料のアプリまたはアドオン (アプリ内製品または IAP とも呼ばれます) を特定のユーザーに付与するには、Microsoft Store 購入 API の以下のメソッドを使います。

現時点では、無料の製品のみを付与することができます。 サービスがこのメソッドを使用して無料でない製品を付与しようとすると、このメソッドはエラーを返します。

## <a name="prerequisites"></a>前提条件

このメソッドを使用するための要件:

* 対象ユーザー URI の値が `https://onestore.microsoft.com` の Azure AD アクセス トークン。
* 無料製品を付与するユーザーの ID を表す Microsoft Store ID キー。

詳しくは、「[サービスによる製品の権利の管理](view-and-grant-products-from-a-service.md)」をご覧ください。

## <a name="request"></a>要求


### <a name="request-syntax"></a>要求の構文

| メソッド | 要求 URI                                            |
|--------|--------------------------------------------------------|
| POST   | ```https://purchase.mp.microsoft.com/v6.0/purchases/grant``` |


### <a name="request-header"></a>要求ヘッダー

| Header         | 種類   | 説明                                                                                           |
|----------------|--------|-------------------------------------------------------------------------------------------------------|
| Authorization  | string | 必須。 **Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。                           |
| Host           | string | 値 **purchase.mp.microsoft.com** に設定する必要があります。                                            |
| Content-Length | number | 要求の本文の長さ。                                                                       |
| Content-Type   | string | 要求と応答の種類を指定します。 現時点では、サポートされている唯一の値は **application/json** です。 |


### <a name="request-body"></a>要求本文

| パラメーター      | 種類   | 説明        | 必須 |
|----------------|--------|---------------------|----------|
| availabilityId | string | Microsoft Store カタログから付与される製品の可用性 ID。         | 〇      |
| b2bKey         | string | 製品を付与するユーザーの ID を表す [Microsoft Store ID キー](view-and-grant-products-from-a-service.md#step-4)。    | 〇      |
| devOfferId     | string | 購入後にコレクション項目に表示される開発者指定のプラン ID。        |
| 言語       | string | ユーザーの言語。  | 〇      |
| market         | string | ユーザーの市場。       | 〇      |
| orderId        | guid   | 注文に対して生成された GUID。 この値はそのユーザーに関して一意ですが、すべての注文にわたって一意である必要はありません。    | 〇      |
| productId      | string | Microsoft Store カタログ内の[製品](in-app-purchases-and-trials.md#products-skus-and-availabilities)の [Store ID](in-app-purchases-and-trials.md#store-ids)。 製品のストア ID の例は、9NBLGGH42CFD です。 | 〇      |
| quantity       | int    | 購入する数量。 現時点では、サポートされている唯一の値は 1 です。 指定されていない場合は、既定値は 1 です。   | X       |
| skuId          | string | Microsoft Store カタログ内の製品の [SKU](in-app-purchases-and-trials.md#products-skus-and-availabilities) の [Store ID](in-app-purchases-and-trials.md#store-ids)。 SKU の Store ID の例は、0010 です。     | 〇      |


### <a name="request-example"></a>要求の例

```syntax
POST https://purchase.mp.microsoft.com/v6.0/purchases/grant HTTP/1.1
Authorization: Bearer eyJ0eXAiOiJK……
Content-Length: 1863
Content-Type: application/json

{
    "b2bKey" : "eyJ0eXAiOiJK……",
    "availabilityId" : "9RT7C09D5J3W",
    "productId" : "9NBLGGH5WVP6",
    "skuId" : "0010",
    "language" : "en-us",
    "market" : "us",
    "orderId" : "3eea1529-611e-4aee-915c-345494e4ee76",
}
```

## <a name="response"></a>応答


### <a name="response-body"></a>応答本文

| パラメーター                 | 種類                        | 説明             | 必須 |
|---------------------------|-----------------------------|-----------------------|----------|
| clientContext             | ClientContextV6             | この注文に対するクライアントのコンテキスト情報。 これは、Azure AD トークンの *clientID* 値に割り当てられます。    | 〇      |
| createdtime               | datetimeoffset              | 注文が作成された時刻。         | 〇      |
| currencyCode              | string                      | *totalAmount* と *totalTaxAmount* の通貨コード。 無料の項目の場合は該当なし。     | 〇      |
| friendlyName              | string                      | 注文のフレンドリ名。 Microsoft Store 購入 API を使用した注文の場合は該当なし。 | 〇      |
| isPIRequired              | boolean                     | 注文の一部として支払い方法 (PI) が必要かどうかを示します。  | 〇      |
| 言語                  | string                      | 注文の言語 ID (たとえば “en”)。       | 〇      |
| market                    | string                      | 注文の市場 ID (たとえば “US”)。  | 〇      |
| orderId                   | string                      | 特定のユーザーの注文を識別する ID。                | 〇      |
| orderLineItems            | list&lt;OrderLineItemV6&gt; | 注文の行項目の一覧。 通常は、注文あたり 1 つの行項目があります。       | 〇      |
| orderState                | string                      | 注文の状態。 有効な状態は、**Editing**、**CheckingOut**、**Pending**、**Purchased**、**Refunded**、**ChargedBack**、および **Cancelled** です。 | 〇      |
| orderValidityEndTime      | string                      | 注文を送信する前の、注文の価格が有効である最後の時刻。 無料アプリの場合は該当なし。      | 〇      |
| orderValidityStartTime    | string                      | 注文を送信する前の、注文の価格が有効である最初の時刻。 無料アプリの場合は該当なし。          | 〇      |
| purchaser                 | IdentityV6                  | 購入者の ID を表すオブジェクト。       | 〇      |
| totalAmount               | decimal                     | 注文のすべての項目の税込みの合計購入金額。       | 〇      |
| totalAmountBeforeTax      | decimal                     | 注文のすべての項目の税抜きの合計購入金額。      | 〇      |
| totalChargedToCsvTopOffPI | decimal                     | 個別の支払い方法とストアド バリュー (CSV) を使っている場合に、CSV に請求する金額。            | 〇      |
| totalTaxAmount            | decimal                     | すべての行項目に対する税の合計金額。    | 〇      |


ClientContext オブジェクトには以下のパラメーターが含まれています。

| パラメーター | 種類   | 説明                           | 必須 |
|-----------|--------|---------------------------------------|----------|
| client    | string | 注文を作成したクライアント ID。 | いいえ       |


OrderLineItemV6 オブジェクトには以下のパラメーターが含まれています。

| パラメーター               | 種類           | 説明                                                                                                  | 必須 |
|-------------------------|----------------|--------------------------------------------------------------------------------------------------------------|----------|
| agent                   | IdentityV6     | 行項目を最後に編集したエージェント。 このオブジェクトについて詳しくは、次の表をご覧ください。       | X       |
| availabilityId          | string         | Microsoft Store カタログから購入される製品の可用性 ID。                           | 〇      |
| beneficiary             | IdentityV6     | 注文の受益者の ID。                                                                | X       |
| billingState            | string         | 注文の請求の状態。 完了すると、これは **Charged** に設定されます。                                   | X       |
| campaignId              | string         | この注文のキャンペーン ID。                                                                              | X       |
| currencyCode            | string         | 価格の詳細に使用される通貨コード。                                                                    | 〇      |
| 説明             | string         | 行項目のローカライズされた説明。                                                                    | 〇      |
| devofferId              | string         | 特定の注文のプラン ID (該当する場合)。                                                           | いいえ       |
| fulfillmentDate         | datetimeoffset | フルフィルメントが発生した日付。                                                                           | X       |
| fulfillmentState        | string         | この項目のフルフィルメントの状態。 完了すると、これは **Fulfilled** に設定されます。                      | いいえ       |
| isPIRequired            | boolean        | この行項目について支払い方法が必要であるかどうかを示します。                                       | 〇      |
| isTaxIncluded           | boolean        | 項目の価格の詳細に税が含まれているかどうかを示します。                                        | 〇      |
| legacyBillingOrderId    | string         | 従来の課金 ID。                                                                                       | X       |
| lineItemId              | string         | この注文の項目の行項目 ID。                                                                 | 〇      |
| listPrice               | decimal        | この注文の項目の定価。                                                                    | 〇      |
| productId               | string         | Microsoft Store カタログでの行項目を表す[製品](in-app-purchases-and-trials.md#products-skus-and-availabilities)の [Store ID](in-app-purchases-and-trials.md#store-ids)。 製品のストア ID の例は、9NBLGGH42CFD です。   | 〇      |
| productType             | string         | 製品の種類。 サポートされる値は、**Durable**、**Application**、および **UnmanagedConsumable** です。 | 〇      |
| quantity                | int            | 注文された項目の数量。                                                                            | 〇      |
| retailPrice             | decimal        | 注文された項目の小売価格。                                                                        | 〇      |
| revenueRecognitionState | string         | 収益認識の状態。                                                                               | 〇      |
| skuId                   | string         | Microsoft Store カタログ内の品目の [SKU](in-app-purchases-and-trials.md#products-skus-and-availabilities) の [Store ID](in-app-purchases-and-trials.md#store-ids)。 SKU の Store ID の例は、0010 です。                                                                   | 〇      |
| taxAmount               | decimal        | 行項目の税額。                                                                            | 〇      |
| taxType                 | string         | 適用される税金の種類。                                                                       | 〇      |
| タイトル                   | string         | 行項目のローカライズされたタイトル。                                                                        | 〇      |
| totalAmount             | decimal        | 行項目の税込みの合計購入金額。                                                    | 〇      |


IdentityV6 オブジェクトには以下のパラメーターが含まれています。

| パラメーター     | 種類   | 説明                                                                        | 必須 |
|---------------|--------|------------------------------------------------------------------------------------|----------|
| identityType  | string | 値 **"pub"** を格納します。                                                      | 〇      |
| identityValue | string | 指定された Microsoft Store ID キーの *publisherUserId* の文字列値。 | 〇      |


### <a name="response-example"></a>応答の例

```syntax
Content-Length: 1203
Content-Type: application/json
MS-CorrelationId: fb2e69bc-f26a-4aab-a823-7586c19f5762
MS-RequestId: c1bc832c-f742-47e4-a76c-cf061402f698
MS-CV: XjfuNWLQlEuxj6Mt.8
MS-ServerId: 030032362
Date: Tue, 13 Oct 2015 21:21:51 GMT

{
    "clientContext": {
        "client": "86b78998-d05a-487b-b380-6c738f6553ea"
    },
    "createdTime": "2015-10-13T21:21:51.1863494+00:00",
    "currencyCode": "USD",
    "isPIRequired": false,
    "language": "en-us",
    "market": "us",
    "orderId": "3eea1529-611e-4aee-915c-345494e4ee76",
    "orderLineItems": [{
        "availabilityId": "9RT7C09D5J3W",
        "beneficiary": {
            "identityType": "pub",
            "identityValue": "user1"
        },
        "billingState": "Charged",
        "currencyCode": "USD",
        "description": "Jewels, Jewels, Jewels - Consumable 2",
        "fulfillmentDate": "2015-10-13T21:21:51.639478+00:00",
        "fulfillmentState": "Fulfilled",
        "isPIRequired": false,
        "isTaxIncluded": true,
        "lineItemId": "2814d758-3ee3-46b3-9671-4fb3bdae9ffe",
        "listPrice": 0.0,
        "payments": [],
        "productId": "9NBLGGH5WVP6",
        "productType": "UnmanagedConsumable",
        "quantity": 1,
        "retailPrice": 0.0,
        "revenueRecognitionState": "None",
        "skuId": "0010",
        "taxAmount": 0.0,
        "taxType": "NoApplicableTaxes",
        "title": "Jewels, Jewels, Jewels - Consumable 2",
        "totalAmount": 0.0
    }],
    "orderState": "Purchased",
    "orderValidityEndTime": "2015-10-14T21:21:51.1863494+00:00",
    "orderValidityStartTime": "2015-10-13T21:21:51.1863494+00:00",
    "purchaser": {
        "identityType": "pub",
        "identityValue": "user1"
    },
    "testScenarios": "None",
    "totalAmount": 0.0,
    "totalTaxAmount": 0.0
}
```

## <a name="error-codes"></a>エラー コード


| コード | エラー        | 内部エラー コード           | 説明   |
|------|--------------|----------------------------|----------------|
| 401  | 権限がありません | AuthenticationTokenInvalid | Azure AD アクセス トークンが無効です。 場合によっては、ServiceError の詳細に追加情報が含まれていることがあります (トークンの有効期限切れや *appid* 要求の欠落など)。 |
| 401  | 権限がありません | PartnerAadTicketRequired   | Azure AD アクセス トークンが承認ヘッダーでサービスに渡されませんでした。   |
| 401  | 権限がありません | InconsistentClientId       | 要求本文の Microsoft Store ID の *clientId* 要求と承認ヘッダーの Azure AD アクセス トークンの *appid* 要求が一致しません。       |
| 400  | BadRequest   | InvalidParameter           | 詳細情報に、要求の本文と無効な値を含むフィールドに関する情報が含まれます。           |

<span/> 

## <a name="related-topics"></a>関連トピック

* [サービスからの製品の利用資格を管理します。](view-and-grant-products-from-a-service.md)
* [製品のクエリ](query-for-products.md)
* [Fulfilled コンシューマブル製品をレポートします。](report-consumable-products-as-fulfilled.md)
* [Microsoft Store の ID キーを更新します。](renew-a-windows-store-id-key.md)
