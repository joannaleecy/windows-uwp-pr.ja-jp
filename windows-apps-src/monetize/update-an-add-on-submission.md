---
ms.assetid: 8C63D33B-557D-436E-9DDA-11F7A5BFA2D7
description: 既存のアドオンの申請を更新するには、Microsoft Store 申請 API の以下のメソッドを使います。
title: アドオンの申請の更新
ms.date: 04/17/2018
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store 申請 API, アドオンの申請, 更新, アプリ内製品, IAP
ms.localizationpriority: medium
ms.openlocfilehash: fd0bb8df9b9fc36216da72e4ad01ebd2e650ad1a
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57620617"
---
# <a name="update-an-add-on-submission"></a>アドオンの申請の更新


既存のアドオン (アプリ内製品または IAP とも呼ばれます) の申請を更新するには、Microsoft Store 申請 API の以下のメソッドを使います。 このメソッドを使って申請を正常に更新した後は、インジェストと公開のために[申請をコミット](commit-an-add-on-submission.md)する必要があります。

このメソッドが Microsoft Store 申請 API を使ったアドオンの申請の作成プロセスにどのように適合するかについては、「[アドオンの申請の管理](manage-add-on-submissions.md)」をご覧ください。

## <a name="prerequisites"></a>前提条件

このメソッドを使うには、最初に次の作業を行う必要があります。

* Microsoft Store 申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。
* このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら新しいトークンを取得できます。
* アプリのいずれかのアドオン送信を作成します。 パートナー センターでこれを行うかを使用してこれを行う、 [、アドオンの提出の作成](create-an-add-on-submission.md)メソッド。

## <a name="request"></a>要求

このメソッドの構文は次のとおりです。 ヘッダーと要求本文の使用例と説明については、次のセクションをご覧ください。

| メソッド | 要求 URI                                                      |
|--------|------------------------------------------------------------------|
| PUT    | ```https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/{inAppProductId}/submissions/{submissionId} ``` |


### <a name="request-header"></a>要求ヘッダー

| Header        | 種類   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| Authorization | string | 必須。 **Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。 |


### <a name="request-parameters"></a>要求パラメーター

| 名前        | 種類   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| inAppProductId | string | 必須。 申請を更新するアドオンのストア ID です。 Store ID は、パートナー センターで利用できるとするための要求応答のデータに含まれる[アドオンを作成](create-an-add-on.md)または[アドオンの詳細の取得](get-all-add-ons.md)します。  |
| submissionId | string | 必須。 更新する申請の ID です。 この ID は、[アドオンの申請の作成](create-an-add-on-submission.md)要求に対する応答データで確認できます。 パートナー センターで作成された送信、この ID はパートナー センターでの送信 ページの URL で使用できるも。  |


### <a name="request-body"></a>要求本文

要求本文には次のパラメーターがあります。

| Value      | 種類   | 説明                                                                                                                                                                                                                                                                         |
|------------|--------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| contentType           | string  |  アドオンで提供されている[コンテンツの種類](../publish/enter-add-on-properties.md#content-type)です。 次のいずれかの値を使用できます。 <ul><li>NotSet</li><li>BookDownload</li><li>EMagazine</li><li>ENewspaper</li><li>MusicDownload</li><li>MusicStream</li><li>OnlineDataStorage</li><li>VideoDownload</li><li>VideoStream</li><li>Asp</li><li>OnlineDownload</li></ul> |  
| keywords           | array  | アドオンの[キーワード](../publish/enter-add-on-properties.md#keywords)の文字列を最大 10 個含む配列です。 アプリでは、これらのキーワードを使ってアドオンを照会できます。   |
| lifetime           | string  |  アドオンの有効期間です。 次のいずれかの値を使用できます。 <ul><li>Forever</li><li>OneDay</li><li>ThreeDays</li><li>FiveDays</li><li>OneWeek</li><li>TwoWeeks</li><li>OneMonth</li><li>TwoMonths</li><li>ThreeMonths</li><li>SixMonths</li><li>OneYear</li></ul> |
| listings           | オブジェクト  | アドオンの表示内容を含むオブジェクトです。 詳しくは、「[表示リソース](manage-add-on-submissions.md#listing-object)」をご覧ください。  |
| pricing           | オブジェクト  | アドオンの価格情報を含むオブジェクトです。 詳しくは、「[価格リソース](manage-add-on-submissions.md#pricing-object)」をご覧ください。  |
| targetPublishMode           | string  | 申請の公開モードです。 次のいずれかの値を使用できます。 <ul><li>即時</li><li>Manual</li><li>SpecificDate</li></ul> |
| targetPublishDate           | string  | *targetPublishMode* が SpecificDate に設定されている場合、ISO 8601 形式での申請の公開日です。  |
| tag           | string  |  アドオンの[カスタムの開発者データ](../publish/enter-add-on-properties.md#custom-developer-data)(この情報は従来*タグ*と呼ばれていました)。   |
| visibility  | string  |  アドオンの可視性です。 次のいずれかの値を使用できます。 <ul><li>Hidden</li><li>パブリック</li><li>Private</li><li>NotSet</li></ul>  |


### <a name="request-example"></a>要求の例

次の例は、アドオンの申請を更新する方法を示しています。

```json
PUT https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/9NBLGGH4TNMP/submissions/1152921504621230023 HTTP/1.1
Authorization: Bearer <your access token>
Content-Type: application/json
{
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
    "sales": [],
    "priceId": "Free"
  },
  "targetPublishDate": "2016-03-15T05:10:58.047Z",
  "targetPublishMode": "Immediate",
  "tag": "SampleTag",
  "visibility": "Public",
}
```

## <a name="response"></a>応答

次の例は、このメソッドが正常に呼び出された場合の JSON 応答本文を示しています。 応答本文には、更新された申請に関する情報が含まれています。 応答本文内の値について詳しくは、「[アドオンの申請のリソース](manage-add-on-submissions.md#add-on-submission-object)」をご覧ください。

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
    "sales": [],
    "priceId": "Free"
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
| 400  | 要求が無効なため、申請を更新できませんでした。 |
| 409  | アドオンでは、現在の状態であるため、送信を更新できませんでしたまたはアドオンであるパートナー センターの機能を使用して[現在サポートされていません、Microsoft Store 送信 API](create-and-manage-submissions-using-windows-store-services.md#not_supported)します。 |   


## <a name="related-topics"></a>関連トピック

* [作成し、Microsoft Store サービスを使用して送信の管理](create-and-manage-submissions-using-windows-store-services.md)
* [アドオンの送信を管理します。](manage-add-on-submissions.md)
* [取得するアドオンの送信](get-an-add-on-submission.md)
* [アドオンを提出を作成します。](create-an-add-on-submission.md)
* [コミット、アドオンの送信](commit-an-add-on-submission.md)
* [削除するアドオンの送信](delete-an-add-on-submission.md)
* [アドオンの提出パッケージのステータスを取得します。](get-status-for-an-add-on-submission.md)
