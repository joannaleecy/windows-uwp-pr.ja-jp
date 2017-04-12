---
author: mcleanbyron
description: "パッケージ フライトの申請に関するパッケージのロールアウトの情報を取得するには、Windows ストア申請 API に含まれる以下のメソッドを使用します。"
title: "パッケージ フライトの申請に関するロールアウトの情報を取得する"
ms.author: mcleans
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, Windows ストア申請 API, パッケージのロールアウト, フライトの申請"
ms.assetid: 397f1b99-2be7-4f65-bcf1-9433a3d496ad
ms.openlocfilehash: a1c12c7cb0e9a32502396bfa1da49351f63163e0
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="get-rollout-info-for-a-flight-submission"></a>パッケージ フライトの申請に関するロールアウトの情報を取得する


パッケージ フライトの申請に関する[パッケージのロールアウト](../publish/gradual-package-rollout.md)の情報を取得するには、Windows ストア申請 API に含まれる以下のメソッドを使用します。 Windows ストア申請 API を使ったパッケージ フライトの申請の作成プロセスについて詳しくは、「[パッケージ フライトの申請の管理](manage-flight-submissions.md)」をご覧ください。

## <a name="prerequisites"></a>前提条件

このメソッドを使うには、最初に次の作業を行う必要があります。

* Windows ストア申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。
* このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら新しいトークンを取得できます。
* デベロッパー センターのアカウントでアプリのパッケージ フライトの申請を作成します。 これは、デベロッパー センターのダッシュボードで行うことも、[パッケージ フライトの申請の作成](create-a-flight-submission.md)メソッドを使って行うこともできます。

>**注:**&nbsp;&nbsp;このメソッドは、Windows ストア申請 API を使用するアクセス許可が付与された Windows デベロッパー センター アカウントにのみ使用できます。 すべてのアカウントでこのアクセス許可が有効になっているとは限りません。

## <a name="request"></a>要求

このメソッドの構文は次のとおりです。 ヘッダーと要求のパラメーターの使用例と説明については、以下のセクションをご覧ください。

| メソッド | 要求 URI                                                      |
|--------|------------------------------------------------------------------|
| GET   | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions/{submissionId}/packagerollout   ``` |

<span/>
 

### <a name="request-header"></a>要求ヘッダー

| ヘッダー        | 型   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| Authorization | string | 必須。 **Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。 |

<span/>

### <a name="request-parameters"></a>要求パラメーター

| 名前        | 型   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| applicationId | string | 必須。 取得するパッケージのロールアウトの情報を持つパッケージ フライトの申請が含まれているアプリのストア ID です。 ストア ID について詳しくは、「[アプリ ID の詳細の表示](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details)」をご覧ください。  |
| flightId | string | 必須。 取得するパッケージのロールアウトの情報を持つ申請が含まれているパッケージ フライトの ID です。 この ID はデベロッパー センター ダッシュボードで確認でき、[パッケージ フライトの作成](create-a-flight.md)要求と[アプリのパッケージ フライトの取得](get-flights-for-an-app.md)要求の応答データに含まれています。  |
| submissionId | string | 必須。 取得するパッケージのロールアウトの情報を持つ申請の ID です。 この ID はデベロッパー センター ダッシュボードで確認でき、[パッケージ フライトの申請の作成](create-a-flight-submission.md)要求の応答データに含まれています。  |

<span/>

### <a name="request-body"></a>要求本文

このメソッドでは要求本文を指定しないでください。

### <a name="request-example"></a>要求の例

パッケージ フライトの申請に関するパッケージのロールアウトの情報を取得する方法の例を次に示します。

```
GET https://manage.devcenter.microsoft.com/v1.0/my/applications/9NBLGGH4R315/flights/43e448df-97c9-4a43-a0bc-2a445e736bcd/submissions/1152921504621243649/packagerollout HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a>応答

次の例は、段階的なパッケージのロールアウトが有効になっているパッケージ フライトの申請に対して、このメソッドが正常に呼び出された場合の JSON 応答本文を示しています。 応答本文の値について詳しくは、「[パッケージのロールアウトのリソース](manage-flight-submissions.md#package-rollout-object)」をご覧ください。

```json
{
    "isPackageRollout": true,
    "packageRolloutPercentage": 25.0,
    "packageRolloutStatus": "PackageRolloutInProgress",
    "fallbackSubmissionId": "1212922684621243058"
}
```

パッケージ フライトの申請で段階的なパッケージのロールアウトが有効になっていない場合は、次の応答の本文が返されます。

```json
{
    "isPackageRollout": false,
    "packageRolloutPercentage": 0.0,
    "packageRolloutStatus": "PackageRolloutNotStarted",
    "fallbackSubmissionId": "0"
}
```

## <a name="error-codes"></a>エラー コード

要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。

| エラー コード |  説明   |
|--------|------------------|
| 404  | パッケージ フライトの申請は見つかりませんでした。 |
| 409  | 指定されたパッケージ フライトにパッケージ フライトの申請が属していないか、[Windows ストア申請 API で現在サポートされていない](create-and-manage-submissions-using-windows-store-services.md#not_supported)デベロッパー センター ダッシュボード機能をアプリが使用しています。 |   

<span/>


## <a name="related-topics"></a>関連トピック

* [段階的なパッケージのロールアウト](../publish/gradual-package-rollout.md)
* [Windows ストア申請 API を使用したパッケージ フライトの申請の管理](manage-flight-submissions.md)
* [Windows ストア サービスを使用した申請の作成と管理](create-and-manage-submissions-using-windows-store-services.md)
