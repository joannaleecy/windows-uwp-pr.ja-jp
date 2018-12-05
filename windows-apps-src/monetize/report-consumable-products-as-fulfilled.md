---
ms.assetid: E9BEB2D2-155F-45F6-95F8-6B36C3E81649
description: 特定のユーザーについてコンシューマブルな製品をフルフィルメント完了として報告するには、Microsoft Store コレクション API の以下のメソッドを使います。 ユーザーがコンシューマブルな製品を再購入するには、アプリまたはサービスが、そのユーザーについてコンシューマブルな製品をフルフィルメント完了と報告している必要があります。
title: コンシューマブルな製品のフルフィルメント完了の報告
ms.date: 03/16/2018
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store コレクション API, フルフィルメント, コンシューマブル
ms.localizationpriority: medium
ms.openlocfilehash: e3271dd26a4e7eaa23d63efa3b75cf321480528d
ms.sourcegitcommit: c01c29cd97f1cbf050950526e18e15823b6a12a0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/05/2018
ms.locfileid: "8698428"
---
# <a name="report-consumable-products-as-fulfilled"></a>コンシューマブルな製品のフルフィルメント完了の報告

特定のユーザーについてコンシューマブルな製品をフルフィルメント完了として報告するには、Microsoft Store コレクション API の以下のメソッドを使います。 ユーザーがコンシューマブルな製品を再購入するには、アプリまたはサービスが、そのユーザーについてコンシューマブルな製品をフルフィルメント完了と報告している必要があります。

このメソッドを使用してコンシューマブルな製品をフルフィルメント完了として報告するには、次の 2 つの方法があります。

* コンシューマブルの項目 ID ([製品の照会](query-for-products.md)で **itemId** パラメーターとして返されるもの)、およびユーザー指定の一意の追跡 ID を指定します。 複数の試行で同じ追跡 ID が使用される場合、項目が既に消費されている場合でも同じ結果が返されます。 消費要求が成功したかどうかがわからない場合は、サービスは同じ追跡 ID を使用して消費要求を再送信する必要があります。 追跡 ID は常にその消費要求に関連付けられており、無限に再送信できます。
* 製品 ID ([製品の照会](query-for-products.md)の **productId** パラメーターで返されるもの)、および以下の要求の本文セクションの **transactionId** パラメーターの記述にあるいずれかのソースから取得されるトランザクション ID を指定します。

## <a name="prerequisites"></a>前提条件


このメソッドを使用するための要件:

* 対象ユーザー URI の値が `https://onestore.microsoft.com` の Azure AD アクセス トークン。
* コンシューマブルな製品をフルフィルメント完了として報告するユーザーの ID を表す Microsoft Store ID キー。

詳しくは、「[サービスによる製品の権利の管理](view-and-grant-products-from-a-service.md)」をご覧ください。

## <a name="request"></a>要求


### <a name="request-syntax"></a>要求の構文

| メソッド | 要求 URI                                                   |
|--------|---------------------------------------------------------------|
| POST   | ```https://collections.mp.microsoft.com/v6.0/collections/consume``` |


### <a name="request-header"></a>要求ヘッダー

| ヘッダー         | 型   | 説明                                                                                           |
|----------------|--------|-------------------------------------------------------------------------------------------------------|
| Authorization  | string | 必須。 **Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。                           |
| Host           | string | 値 **collections.mp.microsoft.com** に設定する必要があります。                                            |
| Content-Length | number | 要求の本文の長さ。                                                                       |
| Content-Type   | string | 要求と応答の種類を指定します。 現時点では、サポートされている唯一の値は **application/json** です。 |


### <a name="request-body"></a>要求本文

| パラメーター     | 型         | 説明         | 必須かどうか |
|---------------|--------------|---------------------|----------|
| beneficiary   | UserIdentity | この項目が消費されているユーザー。 詳細については、次の表を参照してください。        | 必須      |
| itemId        | string       | [製品の照会](query-for-products.md)で返される *itemId* 値。 このパラメーターは *trackingId* と共に使用します。      | 省略可能       |
| trackingId    | guid         | 開発者により指定される一意の追跡 ID。 このパラメーターは *itemId* と共に使用します。         | 必須ではない       |
| productId     | string       | [製品の照会](query-for-products.md)で返される *productId* 値。 このパラメーターは *transactionId* と共に使用します。   | 必須ではない       |
| transactionId | guid         | 次のいずれかのソースから取得されるトランザクション ID 値。 このパラメーターは *productId* と共に使用します。<ul><li>[PurchaseResults](https://msdn.microsoft.com/library/windows/apps/dn263392) クラスの [TransactionID](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.purchaseresults.transactionid) プロパティ。</li><li>[RequestProductPurchaseAsync](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.currentapp.requestproductpurchaseasync)、[RequestAppPurchaseAsync](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.currentapp.requestapppurchaseasync)、または [GetAppReceiptAsync](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.currentapp.getappreceiptasync) から返されるアプリまたは製品の通知。</li><li>[製品の照会](query-for-products.md)で返される *transactionId* パラメーター。</li></ul>   | 省略可能       |


UserIdentity オブジェクトには以下のパラメーターが含まれています。

| パラメーター            | 型   | 説明       | 必須かどうか |
|----------------------|--------|-------------------|----------|
| identityType         | string | 文字列値 **b2b** を指定します。    | 必須      |
| identityValue        | string | コンシューマブルな製品をフルフィルメント完了として報告するユーザーの ID を表す [Microsoft Store ID キー](view-and-grant-products-from-a-service.md#step-4)。      | 必須      |
| localTicketReference | string | 返された応答で必要な識別子。 Microsoft Store ID キーの *userId* [要求](view-and-grant-products-from-a-service.md#claims-in-a-microsoft-store-id-key)と同じ値を使用することをお勧めします。 | 必須      |


### <a name="request-examples"></a>要求の例

次の例では、*itemId* と *trackingId* を使用します。

```syntax
POST https://collections.mp.microsoft.com/v6.0/collections/consume HTTP/1.1
Authorization: Bearer eyJ0eXAiOiJKV1…..
Host: collections.mp.microsoft.com
Content-Length: 2050
Content-Type: application/json

{
    "beneficiary": {
        "localTicketReference": "testreference",
        "identityValue": "eyJ0eXAiOi…..",
        "identityType": "b2b"
    },
    "itemId": "44c26106-4979-457b-af34-609ae97a084f",
    "trackingId": "44db79ca-e31d-49e9-8896-fa5c7f892b40"
}
```

次の例では、*productId* と *transactionId* を使用します。

```syntax
POST https://collections.mp.microsoft.com/v6.0/collections/consume HTTP/1.1
Authorization: Bearer eyJ0eXAiOiJKV1……
Content-Length: 1880
Content-Type: application/json
Host: collections.md.mp.microsoft.com

{
    "beneficiary" : {
        "localTicketReference" : "testReference",
        "identityValue" : "eyJ0eXAiOiJ…..",
        "identitytype" : "b2b"
    },
    "productId" : "9NBLGGH5WVP6",
    "transactionId" : "08a14c7c-1892-49fc-9135-190ca4f10490"
}
```


## <a name="response"></a>応答

使用が正常に実行された場合、コンテンツは返されません。

### <a name="response-example"></a>応答の例

```syntax
HTTP/1.1 204 No Content
Content-Length: 0
MS-CorrelationId: 386f733d-bc66-4bf9-9b6f-a1ad417f97f0
MS-RequestId: e488cd0a-9fb6-4c2c-bb77-e5100d3c15b1
MS-CV: 5.1
MS-ServerId: 030011326
Date: Tue, 22 Sep 2015 20:40:55 GMT
```

## <a name="error-codes"></a>エラー コード


| コード | エラー        | 内部エラー コード           | 説明           |
|------|--------------|----------------------------|-----------------------|
| 401  | 権限がありません | AuthenticationTokenInvalid | Azure AD アクセス トークンが無効です。 場合によっては、ServiceError の詳細に追加情報が含まれていることがあります (トークンの有効期限切れや *appid* 要求の欠落など)。 |
| 401  | 権限がありません | PartnerAadTicketRequired   | Azure AD アクセス トークンが承認ヘッダーでサービスに渡されませんでした。                                                                                                   |
| 401  | 権限がありません | InconsistentClientId       | 要求本文の Microsoft Store ID の *clientId* 要求と承認ヘッダーの Azure AD アクセス トークンの *appid* 要求が一致しません。                     |

<span/> 

## <a name="related-topics"></a>関連トピック

* [サービスから製品の権利を管理する](view-and-grant-products-from-a-service.md)
* [製品の照会](query-for-products.md)
* [無料の製品の付与](grant-free-products.md)
* [Microsoft Store ID キーの更新](renew-a-windows-store-id-key.md)
