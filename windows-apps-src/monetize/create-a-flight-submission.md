---
author: mcleanbyron
ms.assetid: CD866083-EB7F-4389-A907-FC43DC2FCB5E
description: "Windows ストア申請 API 内のこのメソッドを使用して、Windows デベロッパー センター アカウントに登録されているアプリの新しいパッケージ フライトの申請を作成します。"
title: "Windows ストア申請 API を使用したパッケージ フライト申請の作成"
translationtype: Human Translation
ms.sourcegitcommit: 27d8385c7250feba89c6970033ad7ec170f0646c
ms.openlocfilehash: 8689fa9d314d2ba1d31a16c47aa4c7168e44c69f

---

# Windows ストア申請 API を使用したパッケージ フライト申請の作成




Windows ストア申請 API 内のこのメソッドを使用して、アプリのパッケージ フライトの新しい申請を作成します。 このメソッドを使って新しい申請を正常に作成したら、[申請を更新](update-a-flight-submission.md)して申請データに必要な変更を加え、取り込んで公開するために[申請をコミット](commit-a-flight-submission.md)します。

このメソッドが Windows ストア申請 API を使ったパッケージ フライト申請の作成プロセスにどのように適合するかについては、[パッケージ フライト申請の管理に関するページ](manage-flight-submissions.md)をご覧ください。

>**注:**&nbsp;&nbsp;このメソッドは、既存のパッケージ フライトの申請を作成します。 パッケージ フライトを作成するには、[パッケージ フライトの作成](create-a-flight.md)のメソッドを使用してください。

## 前提条件

このメソッドを使うには、最初に次の作業を行う必要があります。

* Windows ストア申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。
* このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら新しいトークンを取得できます。
* デベロッパー センター アカウントでアプリのパッケージ フライトを作成します。 これは、デベロッパー センター ダッシュボードで行うことも、[パッケージ フライトの作成](create-a-flight.md)のメソッドを使って行うこともできます。

>**注:**&nbsp;&nbsp;このメソッドは、Windows ストア申請 API を使用するアクセス許可が付与された Windows デベロッパー センター アカウントにのみ使用できます。 すべてのアカウントでこのアクセス許可が有効になっているとは限りません。

## 要求

このメソッドの構文は次のとおりです。 ヘッダーと要求本文の使用例と説明については、次のセクションをご覧ください。

| メソッド | 要求 URI                                                      |
|--------|------------------------------------------------------------------|
| POST    | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions``` |

<span/>
 

### 要求ヘッダー

| ヘッダー        | 型   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| Authorization | string | 必須。 **Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。 |

<span/>

### 要求パラメーター

| 名前        | 型   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| applicationId | string | 必須。 パッケージ フライトの申請を作成するアプリのストア ID です。 ストア ID について詳しくは、「[アプリ ID の詳細の表示](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details)」をご覧ください。  |
| flightId | string | 必須。 申請を追加するパッケージ フライトの ID です。 この ID は、[パッケージ フライトの作成](create-a-flight.md)要求と[アプリのパッケージ フライトの取得](get-flights-for-an-app.md)要求の応答データに含まれており、デベロッパー センター ダッシュボードで確認できます。  |

<span/>

### 要求本文

このメソッドでは要求本文を指定しないでください。

### 要求の例

次の例は、ストア ID 9WZDNCRD91MD を持つアプリの新しいパッケージ フライトの申請を作成する方法を示しています。

```
POST https://manage.devcenter.microsoft.com/v1.0/my/applications/9NBLGGH4R315/flights/43e448df-97c9-4a43-a0bc-2a445e736bcd/submissions HTTP/1.1
Authorization: Bearer <your access token>
```

## 応答

次の例は、このメソッドが正常に呼び出された場合の JSON 応答本文を示しています。 応答本文には、新しい申請に関する情報が含まれています。 応答本文の値について詳しくは、[パッケージ フライトの申請のリソース](manage-flight-submissions.md#flight-submission-object)を参照してください。

```json
{
  "id": "1152921504621243649",
  "flightId": "cd2e368a-0da5-4026-9f34-0e7934bc6f23",
  "status": "PendingCommit",
  "statusDetails": {
    "errors": [],
    "warnings": [],
    "certificationReports": []
  },
  "flightPackages": [
    {
      "fileName": "newPackage.appx",
      "fileStatus": "PendingUpload",
      "id": "",
      "version": "1.0.0.0",
      "languages": ["en-us"],
      "capabilities": [],
      "minimumDirectXVersion": "None",
      "minimumSystemRam": "None"
    }
  ],
  "packageDeliveryOptions": {
    "packageRollout": {
        "isPackageRollout": false,
        "packageRolloutPercentage": 0,
        "packageRolloutStatus": "PackageRolloutNotStarted",
        "fallbackSubmissionId": "0"
    },
    "isMandatoryUpdate": false,
    "mandatoryUpdateEffectiveDate": "1601-01-01T00:00:00.0000000Z"
  },
  "fileUploadUrl": "https://productingestionbin1.blob.core.windows.net/ingestion/8b389577-5d5e-4cbe-a744-1ff2e97a9eb8?sv=2014-02-14&sr=b&sig=wgMCQPjPDkuuxNLkeG35rfHaMToebCxBNMPw7WABdXU%3D&se=2016-06-17T21:29:44Z&sp=rwl",
  "targetPublishMode": "Immediate",
  "targetPublishDate": "",
  "notesForCertification": "No special steps are required for certification of this app."
}
```

## エラー コード

要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。

| エラー コード |  説明   |
|--------|------------------|
| 400  | 要求が無効なため、パッケージ フライトの申請を作成できませんでした。 |
| 409  | アプリの現在の状態が原因でパッケージ フライトの申請を作成できませんでした。または、[Windows ストア申請 API で現在サポートされていない](create-and-manage-submissions-using-windows-store-services.md#not_supported)デベロッパー センター ダッシュボード機能がアプリで使用されています。 |   

<span/>

## 関連トピック

* [Windows ストア サービスを使用した申請の作成と管理](create-and-manage-submissions-using-windows-store-services.md)
* [パッケージ フライトの申請の管理](manage-flight-submissions.md)
* [パッケージ フライトの申請の取得](get-a-flight-submission.md)
* [パッケージ フライトの申請のコミット](commit-a-flight-submission.md)
* [パッケージ フライトの申請の更新](update-a-flight-submission.md)
* [パッケージ フライトの申請の削除](delete-a-flight-submission.md)
* [パッケージ フライトの申請の状態の取得](get-status-for-a-flight-submission.md)



<!--HONumber=Nov16_HO1-->


