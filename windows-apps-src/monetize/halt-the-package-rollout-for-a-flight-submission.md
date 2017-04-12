---
author: mcleanbyron
description: "パッケージ フライトに関するパッケージのロールアウトを停止するには、Windows ストア申請 API に含まれる以下のメソッドを使用します。"
title: "フライトに関するロールアウトを停止する"
ms.author: mcleans
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, Windows ストア申請 API, パッケージのロールアウト, フライトの申請, 停止"
ms.assetid: f8ee0687-a421-48e7-a6eb-3fd5633c352b
ms.openlocfilehash: 804e447f5b650a986580752fcba2a29014560e98
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="halt-the-rollout-for-a-flight"></a>フライトに関するロールアウトを停止する

パッケージ フライトの申請に関する[ロールアウトを停止する](../publish/gradual-package-rollout.md#completing-the-rollout)には、Windows ストア申請 API に含まれる以下のメソッドを使用します。 Windows ストア申請 API を使ったパッケージ フライトの申請の作成プロセスについて詳しくは、「[パッケージ フライトの申請の管理](manage-flight-submissions.md)」をご覧ください。

>**注**&nbsp;&nbsp;パッケージ フライトの申請に関するロールアウトを停止してから、[新しいパッケージ フライトの申請を作成する](create-a-flight-submission.md)場合、新しい申請は停止した申請を複製したものになります。

## <a name="prerequisites"></a>前提条件

このメソッドを使うには、最初に次の作業を行う必要があります。

* Windows ストア申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。
* このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら、新しいトークンを取得できます。
* デベロッパー センターのアカウントでアプリの申請を作成します。 この操作は、デベロッパー センター ダッシュボードまたは[アプリ申請の作成](create-an-app-submission.md)メソッドを使って実行できます。
* 申請に関する段階的なパッケージのロールアウトを有効にします。 これは、[デベロッパー センター ダッシュボード](../publish/gradual-package-rollout.md)で行うことも、[Windows ストア申請 API](manage-flight-submissions.md#manage-gradual-package-rollout) を使用して行うこともできます。

>**注:**&nbsp;&nbsp;このメソッドは、Windows ストア申請 API を使用するためのアクセス許可が付与された Windows デベロッパー センター アカウントでのみ使用できます。 すべてのアカウントでこのアクセス許可が有効になっているとは限りません。

## <a name="request"></a>要求

このメソッドの構文は次のとおりです。 ヘッダーと要求のパラメーターの使用例と説明については、以下のセクションをご覧ください。

| メソッド | 要求 URI                                                      |
|--------|------------------------------------------------------------------|
| POST   | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions/{submissionId}/haltpackagerollout``` |

<span/>
 

### <a name="request-header"></a>要求ヘッダー

| ヘッダー        | 型   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| Authorization | string | 必須。 **Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。 |

<span/>

### <a name="request-parameters"></a>要求パラメーター

| 名前        | 型   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| applicationId | string | 必須。 停止するパッケージのロールアウトの対象となるパッケージ フライトの申請が含まれているアプリのストア ID です。 ストア ID について詳しくは、「[アプリ ID の詳細の表示](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details)」をご覧ください。  |
| flightId | string | 必須。 停止するパッケージのロールアウトの対象となる申請が含まれているパッケージ フライトの ID です。 この ID はデベロッパー センター ダッシュボードで確認でき、[パッケージ フライトの作成](create-a-flight.md)要求と[アプリのパッケージ フライトの取得](get-flights-for-an-app.md)要求の応答データに含まれています。  |
| submissionId | string | 必須。 停止するパッケージのロールアウトの対象となる申請の ID です。 この ID はデベロッパー センター ダッシュボードで確認でき、[パッケージ フライトの申請の作成](create-a-flight-submission.md)要求の応答データに含まれています。  |

<span/>

### <a name="request-body"></a>要求本文

このメソッドでは要求本文を指定しないでください。

### <a name="request-example"></a>要求の例

パッケージ フライトの申請に関するパッケージのロールアウトを停止する方法の例を次に示します。

```
POST https://manage.devcenter.microsoft.com/v1.0/my/applications/9NBLGGH4R315/flights/43e448df-97c9-4a43-a0bc-2a445e736bcd/submissions/1152921504621243680/haltpackagerollout HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a>応答

次の例は、このメソッドが正常に呼び出された場合の JSON 応答本文を示しています。 応答本文の値について詳しくは、「[パッケージのロールアウトのリソース](manage-flight-submissions.md#package-rollout-object)」をご覧ください。

```json
{
    "isPackageRollout": true,
    "packageRolloutPercentage": 0.0,
    "packageRolloutStatus": "PackageRolloutStopped",
    "fallbackSubmissionId": "1212922684621243058"
}
```

## <a name="error-codes"></a>エラー コード

要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。

| エラー コード |  説明   |
|--------|------------------|
| 404  | パッケージ フライトの申請は見つかりませんでした。 |
| 409  | このコードは、次のエラーのいずれかを示します。<br/><br/><ul><li>申請が、段階的なロールアウト操作に対して有効な状態になっていません (このメソッドを呼び出す前に、申請を公開し、[packageRolloutStatus](manage-flight-submissions.md#package-rollout-object) の値を **PackageRolloutInProgress** に設定する必要があります)。</li><li>申請が、指定されたアプリに属していません。</li><li>アプリは、[Windows ストア申請 API で現在サポートされていない](create-and-manage-submissions-using-windows-store-services.md#not_supported)デベロッパー センターのダッシュボード機能を使用します。</li></ul> |   

<span/>


## <a name="related-topics"></a>関連トピック

* [段階的なパッケージのロールアウト](../publish/gradual-package-rollout.md)
* [Windows ストア申請 API を使用したパッケージ フライトの申請の管理](manage-flight-submissions.md)
* [Windows ストア サービスを使用した申請の作成と管理](create-and-manage-submissions-using-windows-store-services.md)
