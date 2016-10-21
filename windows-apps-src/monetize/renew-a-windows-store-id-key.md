---
author: mcleanbyron
ms.assetid: 3569C505-8D8C-4D85-B383-4839F13B2466
description: "このメソッドを使って、Windows ストアのキーを更新します。"
title: "Windows ストア ID キーの更新"
translationtype: Human Translation
ms.sourcegitcommit: 5bf07d3001e92ed16931be516fe059ad33c08bb9
ms.openlocfilehash: 1a2cb625f95a5ad8e94911ead2402cb2589e209a

---

# Windows ストア ID キーの更新




このメソッドを使って、Windows ストアのキーを更新します。 [**GetCustomerCollectionsIdAsync**](https://msdn.microsoft.com/library/windows/apps/mt608674) メソッドまたは [**GetCustomerPurchaseIdAsync**](https://msdn.microsoft.com/library/windows/apps/mt608675) メソッドを呼び出して Windows ストア ID キーを生成すると、キーは 90 日間有効です。 キーの有効期限が切れた後で、有効期限が切れたキーとこのメソッドを使用して新しいキーを再ネゴシエートできます。

## 前提条件


このメソッドを使用するための要件:

-   `https://onestore.microsoft.com` 対象ユーザー URI を使用して作成した Azure AD アクセス トークン。
-   アプリのクライアント側コードから [**GetCustomerCollectionsIdAsync**](https://msdn.microsoft.com/library/windows/apps/mt608674) メソッドまたは [**GetCustomerPurchaseIdAsync**](https://msdn.microsoft.com/library/windows/apps/mt608675) メソッドを呼び出して生成された有効期限切れの Windows ストア ID キー。

詳しくは、「[サービスからの製品の表示と許可](view-and-grant-products-from-a-service.md)」をご覧ください。

## 要求


### 要求の構文

| キーの種類    | メソッド | 要求 URI                                              |
|-------------|--------|----------------------------------------------------------|
| コレクション | POST   | ```https://collections.mp.microsoft.com/v6.0/b2b/keys/renew``` |
| 購入    | POST   | ```https://purchase.mp.microsoft.com/v6.0/b2b/keys/renew```    |

<span/>

### 要求ヘッダー

| ヘッダー         | タイプ   | 説明                                                                                           |
|----------------|--------|-------------------------------------------------------------------------------------------------------|
| Host           | string | **collections.mp.microsoft.com** または **purchase.mp.microsoft.com** の値に設定する必要があります。           |
| Content-Length | number | 要求の本文の長さ。                                                                       |
| Content-Type   | string | 要求と応答の種類を指定します。 現時点では、サポートされている唯一の値は **application/json** です。 |

<span/>

### 要求本文

| パラメーター     | タイプ   | 説明                       | 必須かどうか |
|---------------|--------|-----------------------------------|----------|
| serviceTicket | string | Azure AD アクセス トークン。        | 必須      |
| key           | string | 有効期限が切れた Windows ストア ID キー。 | 省略可能       |

<span/> 

### 要求の例

```syntax
POST https://collections.mp.microsoft.com/v6.0/b2b/keys/renew HTTP/1.1
Content-Length: 2774
Content-Type: application/json
Host: collections.mp.microsoft.com

{
    "serviceTicket": "eyJ0eXAiOiJKV1QiLCJhb….",
    "Key": "eyJ0eXAiOiJKV1QiLCJhbG…."
}
```

## 応答


### 応答本文

| パラメーター | タイプ   | 説明                                                                                                            | 必須かどうか |
|-----------|--------|------------------------------------------------------------------------------------------------------------------------|----------|
| key       | string | 以降の Windows ストア コレクション API または Windows ストア購入 API に対する呼び出しで使用できる、更新された Windows ストアのキー。 | 省略可能       |

<span/>

### 応答の例

```syntax
HTTP/1.1 200 OK
Content-Length: 1646
Content-Type: application/json
MS-CorrelationId: bfebe80c-ff89-4c4b-8897-67b45b916e47
MS-RequestId: 1b5fa630-d672-4971-b2c0-3713f4ea6c85
MS-CV: xu2HW6SrSkyfHyFh.0.0
MS-ServerId: 030011428
Date: Tue, 13 Sep 2015 07:31:12 GMT

{
    "key":"eyJ0eXAi….."
}
```

## エラー コード


| コード | エラー        | 内部エラー コード           | 説明                                                                                                                                                                           |
|------|--------------|----------------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 401  | 権限がありません | AuthenticationTokenInvalid | Azure AD アクセス トークンが無効です。 場合によっては、ServiceError の詳細に追加情報が含まれていることがあります (トークンの有効期限切れや *appid* 要求の欠落など)。 |
| 401  | 権限がありません | InconsistentClientId       | Windows ストア ID キーの *clientId* 要求と Azure AD アクセス トークンの *appid* 要求が一致しません。                                                                     |

<span/>

## 関連トピック


* [サービスからの製品の表示と許可](view-and-grant-products-from-a-service.md)
* [製品の照会](query-for-products.md)
* [コンシューマブルな製品をフルフィルメント完了として報告する](report-consumable-products-as-fulfilled.md)
* [無料の製品の付与](grant-free-products.md)



<!--HONumber=Aug16_HO3-->


