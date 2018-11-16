---
author: Xansky
ms.assetid: D1F233EC-24B5-4F84-A92F-2030753E608E
description: Azure AD クライアント ID に関連付けられているアプリでユーザーが所有しているすべての製品を取得するには、Microsoft Store コレクション API の以下のメソッドを使います。 スコープを指定して特定の製品を照会したり、その他のフィルターを使用したりできます。
title: 製品の照会
ms.author: mhopkins
ms.date: 03/16/2018
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store コレクション API, 製品の表示
ms.localizationpriority: medium
ms.openlocfilehash: 3e5d6376420a1ee4ac166330371cf6e058d3476e
ms.sourcegitcommit: e2fca6c79f31e521ba76f7ecf343cf8f278e6a15
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/15/2018
ms.locfileid: "6969501"
---
# <a name="query-for-products"></a>製品の照会


Azure AD クライアント ID に関連付けられているアプリでユーザーが所有しているすべての製品を取得するには、Microsoft Store コレクション API の以下のメソッドを使います。 スコープを指定して特定の製品を照会したり、その他のフィルターを使用したりできます。

このメソッドは、アプリからのメッセージに対する応答としてサービスから呼び出されるように設計されています。 サービスで、スケジュールに従って定期的にすべてのユーザーをポーリングしないでください。

## <a name="prerequisites"></a>前提条件


このメソッドを使用するための要件:

* 対象ユーザー URI の値が `https://onestore.microsoft.com` の Azure AD アクセス トークン。
* 取得対象の製品を所有するユーザーの ID を表す Microsoft Store ID キー。

詳しくは、「[サービスによる製品の権利の管理](view-and-grant-products-from-a-service.md)」をご覧ください。

## <a name="request"></a>要求

### <a name="request-syntax"></a>要求の構文

| メソッド | 要求 URI                                                 |
|--------|-------------------------------------------------------------|
| POST   | ```https://collections.mp.microsoft.com/v6.0/collections/query``` |


### <a name="request-header"></a>要求ヘッダー

| ヘッダー         | 型   | 説明                                                                                           |
|----------------|--------|-------------------------------------------------------------------------------------------------------|
| Authorization  | string | 必須。 **Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。                           |
| Host           | string | 値 **collections.mp.microsoft.com** に設定する必要があります。                                            |
| Content-Length | number | 要求の本文の長さ。                                                                       |
| Content-Type   | string | 要求と応答の種類を指定します。 現時点では、サポートされている唯一の値は **application/json** です。 |


### <a name="request-body"></a>要求本文

| パラメーター         | 型         | 説明         | 必須かどうか |
|-------------------|--------------|---------------------|----------|
| beneficiaries     | UserIdentity | 製品照会の対象となるユーザーを表す UserIdentity オブジェクト。 詳細については、次の表をご覧ください。    | 必須      |
| continuationToken | string       | 製品のセットが複数ある場合、ページ制限に達すると、応答本文で継続トークンが返されます。 残りの製品を取得する後続の呼び出しで、この継続トークンを指定します。       | 省略可能       |
| maxPageSize       | number       | 1 つの応答で返す製品の最大数。 既定値および最大値は 100 です。                 | 省略可能       |
| modifiedAfter     | datetime     | 指定した場合、この日付以降に変更された製品だけがサービスから返されます。        | 省略可能       |
| parentProductId   | string       | 指定した場合、指定されたアプリに対応するアドオンだけがサービスから返されます。      | 省略可能       |
| productSkuIds     | list&lt;ProductSkuId&gt; | 指定した場合、指定された製品/SKU のペアに該当する製品だけがサービスから返されます。 詳細については、次の表をご覧ください。      | 省略可能       |
| productTypes      | string       | 指定した場合、指定された製品タイプに一致する製品だけがサービスから返されます。 サポートされている製品タイプは **Application**、**Durable**、および **UnmanagedConsumable** です。     | 省略可能       |
| validityType      | string       | **All** に設定した場合、有効期限が切れた項目を含む、ユーザーのすべての製品が返されます。 **Valid** に設定した場合、その時点で有効な製品だけが返されます (つまり、アクティブな状態で、開始日が現在より前、終了日が現在より後である製品)。 | 省略可能       |


UserIdentity オブジェクトには以下のパラメーターが含まれています。

| パラメーター            | 型   |  説明      | 必須かどうか |
|----------------------|--------|----------------|----------|
| identityType         | string | 文字列値 **b2b** を指定します。    | 必須      |
| identityValue        | string | 照会する製品のユーザーの ID を表す [Microsoft Store ID キー](view-and-grant-products-from-a-service.md#step-4)。  | 必須      |
| localTicketReference | string | 返された製品で必要な識別子。 応答本文で返された項目には、一致する *localTicketReference* があります。 Microsoft Store ID キーの *userId* 要求と同じ値を使用することをお勧めします。 | 必須      |


ProductSkuId オブジェクトには以下のパラメーターが含まれています。

| パラメーター | 型   | 説明          | 必須かどうか |
|-----------|--------|----------------------|----------|
| productId | string | Microsoft Store カタログ内の[製品](in-app-purchases-and-trials.md#products-skus-and-availabilities)の [Store ID](in-app-purchases-and-trials.md#store-ids)。 製品の Store ID の例は、9NBLGGH42CFD です。 | 必須      |
| skuID     | string | Microsoft Store カタログ内の製品の [SKU](in-app-purchases-and-trials.md#products-skus-and-availabilities) の [Store ID](in-app-purchases-and-trials.md#store-ids)。 SKU の Store ID の例は、0010 です。       | 必須      |


### <a name="request-example"></a>要求の例

```syntax
POST https://collections.mp.microsoft.com/v6.0/collections/query HTTP/1.1
Authorization: Bearer eyJ0eXAiOiJKV1Q…….
Host: collections.mp.microsoft.com
Content-Length: 2531
Content-Type: application/json

{
  "maxPageSize": 100,
  "beneficiaries": [
    {
      "localTicketReference": "1055521810674918",
      "identityValue": "eyJ0eXAiOiJ……",
      "identityType": "b2b"
    }
  ],
  "modifiedAfter": "\/Date(-62135568000000)\/",
  "productSkuIds": [
    {
      "productId": "9NBLGGH5WVP6",
      "skuId": "0010"
    }
  ],
  "productTypes": [
    "UnmanagedConsumable"
  ],
  "validityType": "All"
}
```

## <a name="response"></a>応答


### <a name="response-body"></a>応答本文

| パラメーター         | 型                     | 説明          | 必須かどうか |
|-------------------|--------------------------|-----------------------|----------|
| continuationToken | string                   | 製品のセットが複数ある場合、ページ制限に達すると、このトークンが返されます。 残りの製品を取得する後続の呼び出しで、この継続トークンを指定できます。 | 省略可能       |
| items             | CollectionItemContractV6 | 指定したユーザーの製品の配列。 詳細については、次の表をご覧ください。        | 省略可能       |


CollectionItemContractV6 オブジェクトには以下のパラメーターが含まれています。

| パラメーター            | 型               | 説明            | 必須かどうか |
|----------------------|--------------------|-------------------------|----------|
| acquiredDate         | datetime           | ユーザーが項目を取得した日付。                  | 必須      |
| campaignId           | string             | この項目の購入時に提供されたキャンペーン ID。                  | 省略可能       |
| devOfferId           | string             | アプリ内購入からのプラン ID。              | 省略可能       |
| endDate              | datetime           | 項目の終了日。              | 必須      |
| fulfillmentData      | string             | 該当なし         | 省略可能       |
| inAppOfferToken      | string             | パートナー センターでの項目に割り当てられている開発者が指定した製品 ID の文字列。 製品 ID の例では、 *product123*です。 | 省略可能       |
| itemId               | string             | ユーザーが所有する他の項目からこのコレクション項目を識別する ID。 この ID は製品ごとに一意です。   | 必須      |
| localTicketReference | string             | 要求本文の *localTicketReference* で指定された ID。                  | 必須      |
| modifiedDate         | datetime           | この項目が最後に更新された日付。              | 必須      |
| orderId              | string             | 存在する場合、この項目が取得された注文 ID。              | 省略可能       |
| orderLineItemId      | string             | 存在する場合、この項目が取得された特定の注文の行項目。              | 省略可能       |
| ownershipType        | string             | 文字列 *OwnedByBeneficiary*。   | 必須      |
| productId            | string             | Microsoft Store カタログ内の[製品](in-app-purchases-and-trials.md#products-skus-and-availabilities)の [Store ID](in-app-purchases-and-trials.md#store-ids)。 製品の Store ID の例は、9NBLGGH42CFD です。          | 必須      |
| productType          | string             | **Application**、**Durable**、および **UnmanagedConsumable** の製品タイプのいずれか。        | 必須      |
| purchasedCountry     | string             | 該当なし   | 省略可能       |
| purchaser            | IdentityContractV6 | 存在する場合、項目の購入者の ID を表します。 下記に示すこのオブジェクトの詳細を参照してください。        | 省略可能       |
| quantity             | number             | 項目の数量。 現在、これは常に 1 になります。      | 省略可能       |
| skuId                | string             | Microsoft Store カタログ内の製品の [SKU](in-app-purchases-and-trials.md#products-skus-and-availabilities) の [Store ID](in-app-purchases-and-trials.md#store-ids)。 SKU の Store ID の例は、0010 です。     | 必須      |
| skuType              | string             | SKU のタイプ。 可能な値は **Trial**、**Full**、および **Rental** です。        | 必須      |
| startDate            | datetime           | 項目の有効期間の開始日。       | 必須      |
| status               | string             | アイテムの状態。 可能な値は **Active**、**Expired**、**Revoked**、および **Banned** です。    | 必須      |
| tags                 | string             | 該当なし。    | 必須      |
| transactionId        | guid               | この項目の購入の結果としてのトランザクション ID。 フルフィルメント完了として項目を報告するのに使用できます。      | 必須      |


IdentityContractV6 オブジェクトには以下のパラメーターが含まれています。

| パラメーター     | 型   | 説明                                                                        | 必須かどうか |
|---------------|--------|------------------------------------------------------------------------------------|----------|
| identityType  | string | 値 *pub* を格納します。                                                      | 必須      |
| identityValue | string | 指定された Microsoft Store ID キーの *publisherUserId* の文字列値。 | 必須      |


### <a name="response-example"></a>応答の例

```syntax
HTTP/1.1 200 OK
Content-Length: 7241
Content-Type: application/json
MS-CorrelationId: 699681ce-662c-4841-920a-f2269b2b4e6c
MS-RequestId: a9988cf9-652b-4791-beba-b0e732121a12
MS-CV: xu2HW6SrSkyfHyFh.0.1
MS-ServerId: 020022359
Date: Tue, 22 Sep 2015 20:28:18 GMT

{
  "items" : [
    {
      "acquiredDate" : "2015-09-22T19:22:51.2068724+00:00",
      "devOfferId" : "f9587c53-540a-498b-a281-8a349491ed47",
      "endDate" : "9999-12-31T23:59:59.9999999+00:00",
      "fulfillmentData" : [],
      "inAppOfferToken" : "consumable2",
      "itemId" : "4b8fbb13127a41f299270ea668681c1d",
      "localTicketReference" : "1055521810674918",
      "modifiedDate" : "2015-09-22T19:22:51.2513155+00:00",
      "orderId" : "4ba5960d-4ec6-4a81-ac20-aafce02ddf31",
      "ownershipType" : "OwnedByBeneficiary",
      "productId" : "9NBLGGH5WVP6",
      "productType" : "UnmanagedConsumable",
      "purchaser" : {
        "identityType" : "pub",
        "identityValue" : "user123"
      },
      "skuId" : "0010",
      "skuType" : "Full",
      "startDate" : "2015-09-22T19:22:51.2068724+00:00",
      "status" : "Active",
      "tags" : [],
      "transactionId" : "4ba5960d-4ec6-4a81-ac20-aafce02ddf31"
    }
  ]
}
```

## <a name="related-topics"></a>関連トピック

* [サービスから製品の権利を管理する](view-and-grant-products-from-a-service.md)
* [コンシューマブルな製品をフルフィルメント完了として報告する](report-consumable-products-as-fulfilled.md)
* [無料の製品の付与](grant-free-products.md)
* [Microsoft Store ID キーの更新](renew-a-windows-store-id-key.md)
