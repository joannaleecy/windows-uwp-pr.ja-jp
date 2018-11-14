---
author: Xansky
ms.assetid: 87708690-079A-443D-807E-D2BF9F614DDF
description: パートナー センター アカウントに登録されているアプリのパッケージ フライトのデータを取得する、Microsoft Store 申請 API でこのメソッドを使います。
title: パッケージ フライトの取得
ms.author: mhopkins
ms.date: 04/17/2018
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store 申請 API, フライト, パッケージ フライト
ms.localizationpriority: medium
ms.openlocfilehash: 09fd5c703e4a601ad28a05156aec9133444cfd9e
ms.sourcegitcommit: 4d88adfaf544a3dab05f4660e2f59bbe60311c00
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/12/2018
ms.locfileid: "6447663"
---
# <a name="get-a-package-flight"></a>パッケージ フライトの取得

パートナー センター アカウントに登録されているアプリのパッケージ フライトのデータを取得する、Microsoft Store 申請 API でこのメソッドを使います。

## <a name="prerequisites"></a>前提条件

このメソッドを使うには、最初に次の作業を行う必要があります。

* Microsoft Store 申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。
* このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら、新しいトークンを取得できます。

## <a name="request"></a>要求

このメソッドの構文は次のとおりです。 ヘッダーと要求本文の使用例と説明については、次のセクションをご覧ください。

| メソッド | 要求 URI                                                      |
|--------|------------------------------------------------------------------|
| GET    | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}``` |


### <a name="request-header"></a>要求ヘッダー

| ヘッダー        | 型   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| Authorization | string | 必須。 **Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。 |


### <a name="request-parameters"></a>要求パラメーター

| 名前        | 種類   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| applicationId | string | 必須。 取得するパッケージ フライトが含まれるアプリのストア ID。 アプリのストア ID は、パートナー センターで利用できます。  |
| flightId | string | 必須。 取得するパッケージ フライトの ID。 この ID は、[パッケージ フライトの作成](create-a-flight.md)要求と[アプリのパッケージ フライトの取得](get-flights-for-an-app.md)要求の応答データで確認できます。 パートナー センターで作成されたフライト、この ID はパートナー センターでのフライト ページの URL で利用可能なもします。  |


### <a name="request-body"></a>要求本文

このメソッドでは要求本文を指定しないでください。

### <a name="request-example"></a>要求の例

次の例は、ストア ID 値が 9WZDNCRD91MD で、アプリの ID が 43e448df-97c9-4a43-a0bc-2a445e736bcd であるパッケージ フライトに関する情報を取得する方法を示しています。

```
GET https://manage.devcenter.microsoft.com/v1.0/my/applications/9NBLGGH4R315/flights/43e448df-97c9-4a43-a0bc-2a445e736bcd HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a>応答

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

### <a name="response-body"></a>応答本文

| 値      | 型   | 説明                                                                                                                                                                                                                                                                         |
|------------|--------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| flightId            | string  | パッケージ フライトの ID。 この値は、パートナー センターによって提供されます。  |
| friendlyName           | string  | 開発者によって指定されているパッケージ フライトの名前。   |  
| lastPublishedFlightSubmission       | object | パッケージ フライトの最後に公開された申請に関する情報を提供するオブジェクト。 詳しくは、以下の「[申請オブジェクト](#submission_object)」セクションをご覧ください。  |
| pendingFlightSubmission        | object  |  パッケージ フライトの現在保留中の申請に関する情報を提供するオブジェクト。 詳しくは、以下の「[申請オブジェクト](#submission_object)」セクションをご覧ください。  |   
| groupIds           | array  | パッケージ フライトに関連付けられているフライト グループの ID を含む文字列の配列。 フライト グループについて詳しくは、「[パッケージ フライト](https://msdn.microsoft.com/windows/uwp/publish/package-flights)」をご覧ください。   |
| rankHigherThan           | string  | 現在のパッケージ フライトの次に低位のパッケージ フライトのフレンドリ名。 フライト グループのランク付けについて詳しくは、「[パッケージ フライト](https://msdn.microsoft.com/windows/uwp/publish/package-flights)」をご覧ください。  |


<span id="submission_object" />

### <a name="submission-object"></a>申請オブジェクト

応答本文の *lastPublishedFlightSubmission* と *pendingFlightSubmission* の値には、パッケージ フライトの申請に関するリソース情報を提供するオブジェクトが含まれています。 これらのオブジェクトには、次の値があります。

| 値           | 型    | 説明                                                                                                                                                                                                                          |
|-----------------|---------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| id            | string  | 申請 ID。    |
| resourceLocation   | string  | 申請の完全なデータを取得するために、ベースとなる ```https://manage.devcenter.microsoft.com/v1.0/my/``` 要求 URI に付加できる相対パス。               |


## <a name="error-codes"></a>エラー コード

要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。

| エラー コード |  説明     |
|--------|---------------------  |
| 400  | 要求が無効です。 |
| 404  | 指定されたパッケージ フライトは見つかりませんでした。   |   
| 409  | アプリでは、 [Microsoft Store 申請 API で現在サポートされている](create-and-manage-submissions-using-windows-store-services.md#not_supported)はパートナー センターの機能を使用します。 |                                                                                                 


## <a name="related-topics"></a>関連トピック

* [Microsoft Store サービスを使用した申請の作成と管理](create-and-manage-submissions-using-windows-store-services.md)
* [パッケージ フライトの作成](create-a-flight.md)
* [パッケージ フライトの削除](delete-a-flight.md)
