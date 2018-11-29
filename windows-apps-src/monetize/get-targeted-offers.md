---
ms.assetid: A4C6098B-6CB9-4FAF-B2EA-50B03D027FF1
description: 現在のアプリのコンテキストで現在のユーザーが利用できるターゲット オファーを取得するには、Microsoft Store ターゲット オファー API の以下のメソッドを使います。
title: ターゲット オファーを取得する
ms.date: 10/10/2017
ms.topic: article
keywords: Windows 10, UWP, Store サービス, Microsoft Store ターゲット オファー API, ターゲット オファーの取得
ms.localizationpriority: medium
ms.openlocfilehash: 71cd6ce3b9736b812f8ccdf4d21d35357928c63c
ms.sourcegitcommit: b5c9c18e70625ab770946b8243f3465ee1013184
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/29/2018
ms.locfileid: "7989801"
---
# <a name="get-targeted-offers"></a>ターゲット オファーを取得する

ユーザーがターゲット オファーの顧客セグメントの一部であるかどうか基づいて、現在のユーザーが利用可能なターゲット オファーを取得するには、このメソッドを使います。 詳しくは、「[ストア サービスを使用したターゲット オファーの管理](manage-targeted-offers-using-windows-store-services.md)」をご覧ください。

## <a name="prerequisites"></a>前提条件

このメソッドを使うには、まずアプリの現在のサインインしているユーザーの [Microsoft アカウント トークンを取得](manage-targeted-offers-using-windows-store-services.md#obtain-a-microsoft-account-token)する必要があります。 このトークンを、このメソッドの ```Authorization``` 要求ヘッダーで渡す必要があります。 このトークンは、現在のユーザーのターゲット オファーを取得するために Store によって使われます。

## <a name="request"></a>要求


### <a name="request-syntax"></a>要求の構文

| メソッド | 要求 URI                                                                |
|--------|----------------------------------------------------------------------------|
| GET    | ```https://manage.devcenter.microsoft.com/v2.0/my/storeoffers/user``` |


### <a name="request-header"></a>要求ヘッダー

| ヘッダー        | 型   | 説明  |
|---------------|--------|--------------|
| Authorization | string | 必須。 アプリの現在のサインインしているユーザーの Microsoft アカウント トークン (**Bearer** &lt;*トークン*&gt; の形式)。 |


### <a name="request-parameters"></a>要求パラメーター

このメソッドには URI またはクエリ パラメーターはありません。

### <a name="request-example"></a>要求の例

```syntax
GET https://manage.devcenter.microsoft.com/v2.0/my/storeoffers/user HTTP/1.1
Authorization: Bearer <Microsoft Account token>
```

## <a name="response"></a>応答

このメソッドは、次のフィールドを持つオブジェクトの配列を含む JSON 形式の応答本文を返します。 配列内の各オブジェクトは、特定の顧客セグメントの一部として指定されたユーザーが利用可能なターゲット オファーを表します。

| フィールド      | 型   | 説明         |
|------------|--------|------------------|
| offers      | array  | 現在のユーザーが利用できるターゲット オファーに関連付けられているアドオンの製品 ID の配列。 これらの製品 Id は、パートナー センターでのアプリの**対象のプラン**] ページで指定されます。            |
| trackingId  | string | 必要に応じて独自のコードまたはサービスでターゲット オファーの追跡に使用できる GUID です。 |


### <a name="example"></a>例

この要求の JSON 応答の本文の例を次に示します。

```json
[
  {
    "offers": [
      "10x gold coins",
      "100x gold coins"
    ],
    "trackingId": "5de5dd29-6dce-4e68-b45e-d8ee6c2cd203"
  }
]
```

## <a name="related-topics"></a>関連トピック

* [Store サービスを使ってターゲット オファーを管理する](manage-targeted-offers-using-windows-store-services.md)

 

 
