---
author: mcleanbyron
ms.assetid: E9BEB2D2-155F-45F6-95F8-6B36C3E81649
description: "Windows ストア コレクション API 内のこのメソッドを使用して、コンシューマブルな製品を特定の顧客についてフルフィルメント完了として報告します。 ユーザーがコンシューマブルな製品を再購入するには、アプリまたはサービスがコンシューマブルな製品をそのユーザーについてフルフィルメント完了と報告する必要があります。"
title: "コンシューマブルな製品をフルフィルメント完了として報告する"
translationtype: Human Translation
ms.sourcegitcommit: ac9c921c7f39a1bdc6dc9fc9283bc667f67cd820
ms.openlocfilehash: 54095c7fd3c29fe7596be4c4b5a7148d078a7091

---

# コンシューマブルな製品をフルフィルメント完了として報告する




Windows ストア コレクション API 内のこのメソッドを使用して、コンシューマブルな製品を特定の顧客についてフルフィルメント完了として報告します。 ユーザーがコンシューマブルな製品を再購入するには、アプリまたはサービスがコンシューマブルな製品をそのユーザーについてフルフィルメント完了と報告する必要があります。

このメソッドを使用してコンシューマブルな製品をフルフィルメント完了として報告するには、次の 2 つの方法があります。

* コンシューマブルの項目 ID ([製品の照会](query-for-products.md)で **itemId** パラメーターとして返されるもの)、およびユーザー指定の一意の追跡 ID を指定します。 複数の試行で同じ追跡 ID が使用される場合、項目が既に消費されている場合でも同じ結果が返されます。 消費要求が成功したかどうかがわからない場合は、サービスは同じ追跡 ID を使用して消費要求を再送信する必要があります。 追跡 ID は常にその消費要求に関連付けられており、無限に再送信できます。
* 製品 ID ([製品の照会](query-for-products.md)の **productId** パラメーターで返されるもの)、および以下の要求の本文セクションの **transactionId** パラメーターの記述にあるいずれかのソースから取得されるトランザクション ID を指定します。

## 前提条件


このメソッドを使用するための要件:

* `https://onestore.microsoft.com` 対象ユーザー URI を使用して作成した Azure AD アクセス トークン。
* [アプリのクライアント側コードから生成された](view-and-grant-products-from-a-service.md#step-4) Windows ストア ID キー。

詳しくは、「[サービスからの製品の表示と許可](view-and-grant-products-from-a-service.md)」をご覧ください。

## 要求


### 要求の構文

| メソッド | 要求 URI                                                   |
|--------|---------------------------------------------------------------|
| POST   | ```https://collections.mp.microsoft.com/v6.0/collections/consume``` |

<span/> 

### 要求ヘッダー

| ヘッダー         | タイプ   | 説明                                                                                           |
|----------------|--------|-------------------------------------------------------------------------------------------------------|
| Authorization  | string | 必須。 **Bearer** &lt;*token*&gt; という形式の Azure AD アクセス トークン。                           |
| Host           | string | 値 **collections.mp.microsoft.com** に設定する必要があります。                                            |
| Content-Length | number | 要求の本文の長さ。                                                                       |
| Content-Type   | string | 要求と応答の種類を指定します。 現時点では、サポートされている唯一の値は **application/json** です。 |

<span/>

### 要求本文

| パラメーター     | タイプ         | 説明         | 必須かどうか |
|---------------|--------------|---------------------|----------|
| beneficiary   | UserIdentity | この項目が使用されているユーザー。                                                                                                                                                                                                                                                                 | 必須      |
| itemId        | String       | [製品の照会](query-for-products.md)で返される itemId 値。 このパラメーターは trackingId と共に使用します。                                                                                                                                                                                                  | 省略可能       |
| trackingId    | Guid         | 開発者により指定される一意の追跡 ID。 このパラメーターは itemId と共に使用します。                                                                                                                                                                                                                                     | 省略可能       |
| productId     | String       | [製品の照会](query-for-products.md)で返される productId 値。 このパラメーターは transactionId と共に使用します。                                                                                                                                                                                            | なし       |
| transactionId | Guid         | 次のいずれかのソースから取得されるトランザクション ID 値。 このパラメーターは productId と共に使用します。  <br/><br/><ul><li>[PurchaseResults](https://msdn.microsoft.com/library/windows/apps/dn263392) クラスの [TransactionID](https://msdn.microsoft.com/library/windows/apps/dn263396) プロパティ。</li><li>[RequestProductPurchaseAsync](https://msdn.microsoft.com/library/windows/apps/dn263381)、[RequestAppPurchaseAsync](https://msdn.microsoft.com/library/windows/apps/hh967813)、または [GetAppReceiptAsync](https://msdn.microsoft.com/library/windows/apps/hh967811) から返されるアプリまたは製品の通知。</li><li>[製品の照会](query-for-products.md)で返される transactionId パラメーター。</li></ul>                                                                                                                                                                                                                                   | 省略可能       |

 
<span/>

UserIdentity オブジェクトには以下のパラメーターが含まれています。

| パラメーター            | タイプ   | 説明                                                                                                                                 | 必須かどうか |
|----------------------|--------|---------------------------------------------------------------------------------------------------------------------------------------------|----------|
| identityType         | string | 文字列値 **b2b** を指定します。                                                                                                           | 必須      |
| identityValue        | string | [アプリのクライアント側コードから生成された](view-and-grant-products-from-a-service.md#step-4) Windows ストア ID キー。                                                                                                   | 必須      |
| localTicketReference | string | 返された応答で必要な識別子。 Windows ストア ID キーの *userId* 要求と同じ値を使用することをお勧めします。 | 必須      |

<span/> 

### 要求の例

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

## 応答


使用が正常に実行された場合、コンテンツは返されません。

### 応答の例

```syntax
HTTP/1.1 204 No Content
Content-Length: 0
MS-CorrelationId: 386f733d-bc66-4bf9-9b6f-a1ad417f97f0
MS-RequestId: e488cd0a-9fb6-4c2c-bb77-e5100d3c15b1
MS-CV: 5.1
MS-ServerId: 030011326
Date: Tue, 22 Sep 2015 20:40:55 GMT
```

## エラー コード


| コード | エラー        | 内部エラー コード           | 説明                                                                                                                                                                           |
|------|--------------|----------------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 401  | 権限がありません | AuthenticationTokenInvalid | Azure AD アクセス トークンが無効です。 場合によっては、ServiceError の詳細に追加情報が含まれていることがあります (トークンの有効期限切れや *appid* 要求の欠落など)。 |
| 401  | 権限がありません | PartnerAadTicketRequired   | Azure AD アクセス トークンが承認ヘッダーでサービスに渡されませんでした。                                                                                                   |
| 401  | 権限がありません | InconsistentClientId       | 要求の本文の Windows ストア ID の *clientId* 要求と承認ヘッダーの Azure AD アクセス トークンの *appid* 要求が一致しません。                     |

<span/> 

## 関連トピック

* [サービスからの製品の表示と許可](view-and-grant-products-from-a-service.md)
* [製品の照会](query-for-products.md)
* [無料の製品の付与](grant-free-products.md)
* [Windows ストア ID キーの更新](renew-a-windows-store-id-key.md)
 

 



<!--HONumber=Nov16_HO1-->


