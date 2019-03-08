---
ms.assetid: c5246681-82c7-44df-87e1-a84a926e6496
description: プロモーション用の広告キャンペーンのクリエイティブを管理するには、Microsoft Store プロモーション API の以下のメソッドを使います。
title: クリエイティブの管理
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store プロモーション API, 広告キャンペーン
ms.localizationpriority: medium
ms.openlocfilehash: 41c11ee9c5decffff57a2d443e1385398ce40d89
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57658467"
---
# <a name="manage-creatives"></a>クリエイティブの管理

プロモーション用の広告キャンペーンで使う独自のカスタム クリエイティブをアップロードしたり、既存のクリエイティブを取得したりするには、Microsoft Store プロモーション API の以下のメソッドを使います。 クリエイティブは、常に同じアプリを表す場合は、同一の広告キャンペーンでなくても、1 つ以上の配信ラインに関連付けることができます。

クリエイティブと広告キャンペーン、配信ライン、ターゲット プロファイルとの関係について詳しくは、「[Microsoft Store サービスを使用した広告キャンペーンの実行](run-ad-campaigns-using-windows-store-services.md#call-the-windows-store-promotions-api)」をご覧ください。

> [!NOTE]
> この API を使って独自のクリエイティブをアップロードする場合、クリエイティブの最大許容サイズは 40 KB です。 これよりも大きいクリエイティブ ファイルを送信しても、この API からはエラーが返されず、キャンペーンは正しく作成されません。

## <a name="prerequisites"></a>前提条件

これらのメソッドを使うには、最初に次の作業を行う必要があります。

* Microsoft Store プロモーション API に関するすべての[前提条件](run-ad-campaigns-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。
* これらのメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](run-ad-campaigns-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら新しいトークンを取得できます。


## <a name="request"></a>要求

これらのメソッドでは、次の URL が使用されます。

| メソッドの種類 | 要求 URI     |  説明  |
|--------|-----------------------------|---------------|
| POST   | ```https://manage.devcenter.microsoft.com/v1.0/my/promotion/creative``` |  新しいクリエイティブを作成します。  |
| GET    | ```https://manage.devcenter.microsoft.com/v1.0/my/promotion/creative/{creativeId}``` |  *creativeId* で指定されたクリエイティブを取得します。  |

> [!NOTE]
> 現在、この API は PUT メソッドをサポートしていません。


### <a name="header"></a>Header

| Header        | 種類   | 説明         |
|---------------|--------|---------------------|
| Authorization | string | 必須。 **Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。 |
| 追跡 ID   | GUID   | (省略可能)。 呼び出しフローを追跡する ID。                                  |


### <a name="request-body"></a>要求本文

POST メソッドには、[クリエイティブ](#creative) オブジェクトの必須フィールドを含む JSON 要求本文が必要です。


### <a name="request-examples"></a>要求の例

次の例は、POST メソッドを呼び出してクリエイティブを作成する方法を示しています。 この例では、簡潔にするために *content* 値が短縮されています。

```json
POST https://manage.devcenter.microsoft.com/v1.0/my/promotion/creative HTTP/1.1
Authorization: Bearer <your access token>

{
  "name": "Contoso App Campaign - Creative 1",
  "content": "data:image/jpeg;base64,/9j/4AAQSkZJRgABAQEAAQABAAD/2wBDAAgGB...other base64 data shortened for brevity...",
  "height": 80,
  "width": 480,
  "imageAttributes":
  {
    "imageExtension": "PNG"
  }
}
```

次の例は、GET メソッドを呼び出してクリエイティブを取得する方法を示しています。

```json
GET https://manage.devcenter.microsoft.com/v1.0/my/promotion/creative/106851  HTTP/1.1
Authorization: Bearer <your access token>
```


## <a name="response"></a>応答

これらのメソッドは、作成または取得されたクリエイティブに関する情報を含む[クリエイティブ](#creative) オブジェクトを持つ JSON 応答本文を返します。 これらのメソッドの応答本文を次の例に示します。 この例では、簡潔にするために *content* 値が短縮されています。

```json
{
    "Data": {
        "id": 106126,
        "name": "Contoso App Campaign - Creative 2",
        "content": "data:image/jpeg;base64,/9j/4AAQSkZJRgABAQEAAQABAAD/2wBDAAgGB...other base64 data shortened for brevity...",
        "height": 50,
        "width": 300,
        "format": "Banner",
        "imageAttributes":
        {
          "imageExtension": "PNG"
        },
        "storeProductId": "9nblggh42cfd"
    }
}
```


<span id="creative"/>

## <a name="creative-object"></a>クリエイティブ オブジェクト

これらのメソッドの要求本文と応答本文には、次のフィールドが含まれています。 この表は、読み取り専用のフィールド (つまり、PUT メソッドで変更できない) と POST メソッドの要求本文で必須のフィールドを示しています。

| フィールド        | 種類   |  説明      |  読み取り専用かどうか  | Default  |  POST に必須かどうか |  
|--------------|--------|---------------|------|-------------|------------|
|  id   |  整数   |  クリエイティブの ID です。     |   〇    |      |    X   |       
|  name   |  string   |   クリエイティブの名前です。    |    X   |      |  〇     |       
|  content   |  string   |  クリエイティブ イメージのコンテンツです (Base64 でエンコードされた形式)。<br/><br/>**注**&nbsp;&nbsp;クリエイティブの最大許容サイズは 40 KB です。 これよりも大きいクリエイティブ ファイルを送信しても、この API からはエラーが返されず、キャンペーンは正しく作成されません。     |  X     |      |   〇    |       
|  height   |  整数   |   クリエイティブの高さです。    |    X    |      |   〇    |       
|  width   |  整数   |  クリエイティブの幅です。     |  X    |     |    〇   |       
|  landingUrl   |  string   |  Kochava、AppsFlyer、Tune などのキャンペーン追跡サービスを使用して、アプリのインストール分析を行う場合、POST メソッドを呼び出すときに、このフィールドの追跡 URL を割り当てます (このフィールドを指定する場合、値は有効な URI であることが必要です)。 キャンペーン追跡サービスを使用していない場合、POST メソッドを呼び出すときには、この値を省略します (その場合、この URL は自動的に作成されます)。   |  X    |     |   〇    |       
|  format   |  string   |   広告形式です。 現時点では、サポートされている唯一の値は **Banner** です。    |   X    |  バナー   |  X     |       
|  imageAttributes   | [ImageAttributes](#image-attributes)    |   クリエイティブの属性を指定します。     |   X    |      |   〇    |       
|  storeProductId   |  string   |   この広告キャンペーンが関連付けられているアプリの[ストア ID](in-app-purchases-and-trials.md#store-ids) です。 製品のストア ID の例は、9nblggh42cfd です。    |   X    |    |  X     |   |  


<span id="image-attributes"/>

## <a name="imageattributes-object"></a>ImageAttributes オブジェクト

| フィールド        | 種類   |  説明      |  読み取り専用かどうか  | 既定値  | POST に必須かどうか |  
|--------------|--------|---------------|------|-------------|------------|
|  imageExtension   |   string  |   次のいずれかの値です。**PNG**または**JPG**します。    |    X   |      |   〇    |       |


## <a name="related-topics"></a>関連トピック

* [Microsoft ストアのサービスを使用して広告キャンペーンを実行します。](run-ad-campaigns-using-windows-store-services.md)
* [広告キャンペーンを管理します。](manage-ad-campaigns.md)
* [広告キャンペーンの配信の線を管理します。](manage-delivery-lines-for-ad-campaigns.md)
* [広告キャンペーンの対象とするプロファイルを管理します。](manage-targeting-profiles-for-ad-campaigns.md)
* [広告キャンペーンのパフォーマンス データを取得します。](get-ad-campaign-performance-data.md)
