---
ms.assetid: E59FB6FE-5318-46DF-B050-73F599C3972A
description: Microsoft Store 送信 API でこのメソッドを使用して、パートナー センターに登録されているアプリのアプリ内購入に関する情報を取得します。
title: アプリのアドオンの取得
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store 申請 API, アドオン, アプリ内製品, IAP
ms.localizationpriority: medium
ms.openlocfilehash: 8211d65f04b7487aeca6f683375fe87b80d1b9a9
ms.sourcegitcommit: 6a7dd4da2fc31ced7d1cdc6f7cf79c2e55dc5833
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/21/2019
ms.locfileid: "58335000"
---
# <a name="get-add-ons-for-an-app"></a>アプリのアドオンの取得

Microsoft Store 送信 API でこのメソッドを使用すると、パートナー センター アカウントに登録されているアプリのアドオンの一覧を表示します。

## <a name="prerequisites"></a>前提条件

このメソッドを使うには、最初に次の作業を行う必要があります。

* Microsoft Store 申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。
* このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら新しいトークンを取得できます。

## <a name="request"></a>要求

このメソッドの構文は次のとおりです。 ヘッダーと要求本文の使用例と説明については、次のセクションをご覧ください。

| メソッド | 要求 URI                                                      |
|--------|------------------------------------------------------------------|
| GET    | `https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/listinappproducts` |


### <a name="request-header"></a>要求ヘッダー

| Header        | 種類   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| Authorization | string | 必須。 **Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。 |


### <a name="request-parameters"></a>要求パラメーター


|  名前  |  種類  |  説明  |  必須  |
|------|------|------|------|
|  applicationId  |  string  |  アドオンを取得するアプリのストア ID です。 ストア ID について詳しくは、「[アプリ ID の詳細の表示](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details)」をご覧ください。  |  〇  |
|  top  |  int  |  要求で返される項目の数 (つまり、返されるアドオンの数)。 クエリで指定した値よりアプリのアドオンの数が多い場合、応答本文には、データの次のページを要求するためにメソッド URI に追加できる相対 URI パスが含まれます。  |  X  |
|  skip |  int  | 残りの項目を返す前にクエリでバイパスする項目の数。 データ セットを操作するには、このパラメーターを使用します。 たとえば、top = 10 と skip = 0 は、1 から 10 の項目を取得し、top=10 と skip=10 は 11 から 20 の項目を取得するという具合です。   |  いいえ  |


### <a name="request-body"></a>要求本文

このメソッドでは要求本文を指定しないでください。

### <a name="request-examples"></a>要求の例

次の例は、アプリのすべてのアドオンを一覧表示する方法を示しています。

```json
GET https://manage.devcenter.microsoft.com/v1.0/my/applications/9NBLGGH4R315/listinappproducts HTTP/1.1
Authorization: Bearer <your access token>
```

次の例は、アプリの最初の 10 個のアドオンを一覧表示する方法を示しています。

```json
GET https://manage.devcenter.microsoft.com/v1.0/my/applications/9NBLGGH4R315/listinappproducts?top=10 HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a>応答

次の例は、合計 53 個のアドオンがあるアプリの、最初の 10 個のアドオンに対する要求が成功した場合に返される JSON 応答本文を示しています。 簡潔にするために、この例では、要求によって返される最初の 3 つのアドオンのデータのみが示されています。 応答本文の値について詳しくは、次のセクションをご覧ください。

```json
{
  "@nextLink": "applications/9NBLGGH4R315/listinappproducts/?skip=10&top=10",
  "value": [
    {
      "inAppProductId": "9NBLGGH4TNMP"
    },
    {
      "inAppProductId": "9NBLGGH4TNMN"
    },
    {
      "inAppProductId": "9NBLGGH4TNNR"
    },
    // Next 7 add-ons  are omitted for brevity ...
  ],
  "totalCount": 53
}
```

### <a name="response-body"></a>応答本文

| Value      | 種類   | 説明                                                                                                                                                                                                                                                                         |
|------------|--------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| @nextLink  | string | データの追加ページが存在する場合、この文字列には、データの次のページを要求するために、ベースとなる `https://manage.devcenter.microsoft.com/v1.0/my/` 要求 URI に追加できる相対パスが含まれます。 たとえば、最初の要求本文の *top* パラメーターが 10 に設定されていて、アプリには 50 個のアドオンが存在する場合、応答本文には、`applications/{applicationid}/listinappproducts/?skip=10&top=10` という @nextLink 値が含まれます。これは、次の 10 個のアドオンを要求するために、`https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationid}/listinappproducts/?skip=10&top=10` を呼び出すことができることを示しています。 |
| value      | array  | 指定されたアプリの各アドオンのストア ID を一覧表示するオブジェクトの配列です。 各オブジェクトのデータについて詳しくは、「[アドオン リソース](get-app-data.md#add-on-object)」をご覧ください。                                                                                                                           |
| totalCount | int    | クエリのデータ結果の行の合計 (つまり、指定されたアプリのアドオンの合計)。    |


## <a name="error-codes"></a>エラー コード

要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。

| エラー コード |  説明   |
|--------|------------------|
| 404  | アドオンは見つかりませんでした。 |
| 409  | アドオンはパートナー センターの機能を使用して、[現在サポートされていません、Microsoft Store 送信 API](create-and-manage-submissions-using-windows-store-services.md#not_supported)します。  |


## <a name="related-topics"></a>関連トピック

* [作成し、Microsoft Store サービスを使用して送信の管理](create-and-manage-submissions-using-windows-store-services.md)
* [すべてのアプリを入手します。](get-all-apps.md)
* [アプリを取得します。](get-an-app.md)
* [アプリのパッケージのフライトを取得します。](get-flights-for-an-app.md)
