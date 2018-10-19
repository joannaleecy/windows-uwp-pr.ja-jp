---
author: Xansky
ms.assetid: C09F4B7C-6324-4973-980A-A60035792EFC
description: Windows デベロッパー センター アカウントに登録されているアプリの新しいアドオンの申請を作成するには、Microsoft Store 申請 API の以下のメソッドを使います。
title: アドオンの申請の作成
ms.author: mhopkins
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, Microsoft Store 申請 API, アドオンの申請の作成, アプリ内製品, IAP
ms.localizationpriority: medium
ms.openlocfilehash: 39af744d8c8e4b9d26cd9d82a9489396857ffa5b
ms.sourcegitcommit: e16c9845b52d5bd43fc02bbe92296a9682d96926
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/19/2018
ms.locfileid: "4958444"
---
# <a name="create-an-add-on-submission"></a>アドオンの申請の作成


Windows デベロッパー センター アカウントに登録されているアプリの新しいアドオン (アプリ内製品または IAP とも呼ばれます) の申請を作成するには、Microsoft Store 申請 API の以下のメソッドを使います。 このメソッドを使って新しい申請を正常に作成したら、[申請を更新](update-an-add-on-submission.md)して申請データに必要な変更を加え、取り込んで公開するために[申請をコミット](commit-an-add-on-submission.md)します。

このメソッドが Microsoft Store 申請 API を使ったアドオンの申請の作成プロセスにどのように適合するかについては、「[アドオンの申請の管理](manage-add-on-submissions.md)」をご覧ください。

> [!NOTE]
> このメソッドは、既存のアドオンの申請を作成します。 アドオンを作成するには、[アドオンの作成](create-an-add-on.md)メソッドを使います。

## <a name="prerequisites"></a>前提条件

このメソッドを使うには、最初に次の作業を行う必要があります。

* Microsoft Store 申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。
* このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら新しいトークンを取得できます。
* デベロッパー センター アカウントでアプリのアドオンを作成します。 これは、デベロッパー センター ダッシュボードで行うことも、[アドオンの作成](create-an-add-on.md)メソッドを使って行うこともできます。

## <a name="request"></a>要求

このメソッドの構文は次のとおりです。 ヘッダーと要求本文の使用例と説明については、次のセクションをご覧ください。

| メソッド | 要求 URI                                                      |
|--------|------------------------------------------------------------------|
| POST    | ```https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/{inAppProductId}/submissions``` |


### <a name="request-header"></a>要求ヘッダー

| ヘッダー        | 型   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| Authorization | string | 必須。 **Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。 |


### <a name="request-parameters"></a>要求パラメーター

| 名前        | 種類   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| inAppProductId | string | 必須。 申請を作成するアドオンのストア ID です。 ストア ID はデベロッパー センター ダッシュボードで利用できます。また、[アドオンの作成](create-an-add-on.md)または[アドオンの詳細の取得](get-all-add-ons.md)要求の応答データに含まれています。  |


### <a name="request-body"></a>要求本文

このメソッドでは要求本文を指定しないでください。

### <a name="request-example"></a>要求の例

次の例は、アドオンの新しい申請を作成する方法を示しています。

```
POST https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/9NBLGGH4TNMP/submissions HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a>応答

次の例は、このメソッドが正常に呼び出された場合の JSON 応答本文を示しています。 応答本文には、新しい申請に関する情報が含まれています。 応答本文内の値について詳しくは、[アドオンの申請のリソース](manage-add-on-submissions.md#add-on-submission-object)をご覧ください。

```json
{
  "id": "1152921504621243680",
  "contentType": "EMagazine",
  "keywords": [
    "books"
  ],
  "lifetime": "FiveDays",
  "listings": {
    "en": {
      "description": "English add-on description",
      "icon": {
        "fileName": "add-on-en-us-listing2.png",
        "fileStatus": "Uploaded"
      },
      "title": "Add-on Title (English)"
    },
    "ru": {
      "description": "Russian add-on description",
      "icon": {
        "fileName": "add-on-ru-listing.png",
        "fileStatus": "Uploaded"
      },
      "title": "Add-on Title (Russian)"
    }
  },
  "pricing": {
    "marketSpecificPricings": {
      "RU": "Tier3",
      "US": "Tier4",
    },
    "sales": [
      {
         "name": "Sale1",
         "basePriceId": "Free",
         "startDate": "2016-05-21T18:40:11.7369008Z",
         "endDate": "2016-05-22T18:40:11.7369008Z",
         "marketSpecificPricings": {
            "RU": "NotAvailable"
         }
      }
    ],
    "priceId": "Free",
    "isAdvancedPricingModel": true
  },
  "targetPublishDate": "2016-03-15T05:10:58.047Z",
  "targetPublishMode": "Immediate",
  "tag": "SampleTag",
  "visibility": "Public",
  "status": "PendingCommit",
  "statusDetails": {
    "errors": [
      {
        "code": "None",
        "details": "string"
      }
    ],
    "warnings": [
      {
        "code": "ListingOptOutWarning",
        "details": "You have removed listing language(s): []"
      }
    ],
    "certificationReports": [
      {
      }
    ]
  },
  "fileUploadUrl": "https://productingestionbin1.blob.core.windows.net/ingestion/26920f66-b592-4439-9a9d-fb0f014902ec?sv=2014-02-14&sr=b&sig=usAN0kNFNnYE2tGQBI%2BARQWejX1Guiz7hdFtRhyK%2Bog%3D&se=2016-06-17T20:45:51Z&sp=rwl",
  "friendlyName": "Submission 2"
}
```

## <a name="error-codes"></a>エラー コード

要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。

| エラー コード |  説明   |
|--------|------------------|
| 400  | 要求が無効なため、申請を作成できませんでした。 |
| 409  | アプリの現在の状態が原因で申請を作成できませんでした。または、[Microsoft Store 申請 API で現在サポートされていない](create-and-manage-submissions-using-windows-store-services.md#not_supported)デベロッパー センター ダッシュボード機能がアプリで使用されています。 |   


## <a name="related-topics"></a>関連トピック

* [Microsoft Store サービスを使用した申請の作成と管理](create-and-manage-submissions-using-windows-store-services.md)
* [アドオンの申請の管理](manage-add-on-submissions.md)
* [アドオンの申請の取得](get-an-add-on-submission.md)
* [アドオンの申請のコミット](commit-an-add-on-submission.md)
* [アドオンの申請の更新](update-an-add-on-submission.md)
* [アドオンの申請の削除](delete-an-add-on-submission.md)
* [アドオンの申請の状態の取得](get-status-for-an-add-on-submission.md)
