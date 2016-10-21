---
author: mcleanbyron
ms.assetid: 87708690-079A-443D-807E-D2BF9F614DDF
description: "Windows デベロッパー センター アカウントに登録するアプリのパッケージ フライトのデータを取得するには、Windows ストア提出 API 内の以下のメソッドを使用します。"
title: "Windows ストア提出 API を使用したパッケージ フライトの取得"
translationtype: Human Translation
ms.sourcegitcommit: 5f975d0a99539292e1ce91ca09dbd5fac11c4a49
ms.openlocfilehash: fb8328981a45e353987a62d7794158c2e1179087

---

# Windows ストア提出 API を使用したパッケージ フライトの取得




Windows デベロッパー センター アカウントに登録するアプリのパッケージ フライトのデータを取得するには、Windows ストア提出 API 内の以下のメソッドを使用します。

## 前提条件

このメソッドを使うには、最初に次の作業を行う必要があります。

* Windows ストア提出 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。
* このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら新しいトークンを取得できます。

>**注:**&nbsp;&nbsp;このメソッドは、Windows ストア提出 API を使用するアクセス許可が与えられた Windows デベロッパー センター アカウントにのみ使用できます。 すべてのアカウントでこのアクセス許可が有効になっているとは限りません。

## 要求

このメソッドの構文は次のとおりです。 ヘッダーと要求本文の使用例と説明については、次のセクションをご覧ください。

| メソッド | 要求 URI                                                      |
|--------|------------------------------------------------------------------|
| GET    | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}``` |

<span/>
 

### 要求ヘッダー

| ヘッダー        | 型   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| Authorization | string | 必須。 **Bearer** &lt;*token*&gt; という形式の Azure AD アクセス トークン。 |

<span/>

### 要求パラメーター


| 名前        | 型   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| applicationId | string | 必須。 取得するパッケージ フライトが含まれるアプリのストア ID。 アプリのストア ID は、デベロッパー センター ダッシュボードで確認できます。  |
| flightId | string | 必須。 取得するパッケージ フライトの ID。 この ID はデベロッパー センター ダッシュボードで確認でき、[パッケージ フライトの作成](create-a-flight.md)要求と[アプリのパッケージ フライトの取得](get-flights-for-an-app.md)要求の応答データに含まれています。  |

<span/>

### 要求本文

このメソッドでは要求本文を指定しないでください。

<span/>

### 要求の例

次の例は、ストア ID 値が 9WZDNCRD91MD で、アプリの ID が 43e448df-97c9-4a43-a0bc-2a445e736bcd であるパッケージ フライトに関する情報を取得する方法を示しています。

```
GET https://manage.devcenter.microsoft.com/v1.0/my/applications/9NBLGGH4R315/flights/43e448df-97c9-4a43-a0bc-2a445e736bcd HTTP/1.1
Authorization: Bearer <your access token>
```

## 応答

次の例は、このメソッドが正常に呼び出された場合の JSON 応答本文を示しています。 応答本文の値について詳しくは、次のセクションをご覧ください。

```json
{
  "flightId": "43e448df-97c9-4a43-a0bc-2a445e736bcd",
  "friendlyName": "myflight",
  "lastPublishedFlightSubmission": {
    "id": "1152921504621086517",
    "resourceLocation": "flights/43e448df-97c9-4a43-a0bc-2a445e736bcd/submissions/1152921504621086517"
  },
  "pendingFlightSubmission": {
    "id": "115292150462124364",
    "resourceLocation": "flights/43e448df-97c9-4a43-a0bc-2a445e736bcd/submissions/1152921504621243647"
  },
  "groupIds": [
    "0"
  ],
  "rankHigherThan": "671c2857-725e-4faf-9e9e-ea1191ef879c"
}
```

### 応答本文

| 値      | 型   | 説明                                                                                                                                                                                                                                                                         |
|------------|--------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| flightId            | string  | パッケージ フライトの ID。 この値は、デベロッパー センターによって提供されます。  |
| friendlyName           | string  | 開発者によって指定されているパッケージ フライトの名前。   |  
| lastPublishedFlightSubmission       | object | パッケージ フライトの最後に公開された提出に関する情報を提供するオブジェクト。 詳しくは、以下の「[提出オブジェクト](#submission_object)」セクションをご覧ください。  |
| pendingFlightSubmission        | object  |  パッケージ フライトの現在保留中の提出に関する情報を提供するオブジェクト。 詳しくは、以下の「[提出オブジェクト](#submission_object)」セクションをご覧ください。  |   
| groupIds           | array  | パッケージ フライトに関連付けられているフライト グループの ID を含む文字列の配列。 フライト グループについて詳しくは、「[パッケージ フライト](https://msdn.microsoft.com/windows/uwp/publish/package-flights)」をご覧ください。   |
| rankHigherThan           | string  | 現在のパッケージ フライトの次に低位のパッケージ フライトのフレンドリ名。 フライト グループのランク付けについて詳しくは、「[パッケージ フライト](https://msdn.microsoft.com/windows/uwp/publish/package-flights)」をご覧ください。  |

<span id="submission_object" />
### 提出オブジェクト

応答本文の *lastPublishedFlightSubmission* と *pendingFlightSubmission* の値には、パッケージ フライトの提出に関するリソース情報を提供するオブジェクトが含まれています。 これらのオブジェクトには、次の値があります。

| 値           | 型    | 説明                                                                                                                                                                                                                          |
|-----------------|---------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| id            | string  | 提出 ID。    |
| resourceLocation   | string  | 提出の完全なデータを取得するために基本 ```https://manage.devcenter.microsoft.com/v1.0/my/``` 要求 URI に付加できる相対パス。                                                                                                                                               |
 
<span/>

## エラー コード

要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。

| エラー コード |  説明     |
|--------|---------------------  |
| 400  | 要求が無効です。 |
| 404  | 指定されたパッケージ フライトは見つかりませんでした。   |   
| 409  | アプリは、[Windows ストア提出 API で現在サポートされていない](create-and-manage-submissions-using-windows-store-services.md#not_supported)デベロッパー センターのダッシュボード機能を使用します。 |                                                                                                 

<span/>

## 関連トピック

* [Windows ストア サービスを使用した提出の作成と管理](create-and-manage-submissions-using-windows-store-services.md)
* [パッケージ フライトの作成](create-a-flight.md)
* [パッケージ フライトの削除](delete-a-flight.md)



<!--HONumber=Aug16_HO5-->


