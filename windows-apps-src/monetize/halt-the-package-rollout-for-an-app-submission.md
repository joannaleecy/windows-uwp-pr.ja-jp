---
author: mcleanbyron
description: "アプリの申請に関するパッケージのロールアウトを停止するには、Windows ストア申請 API に含まれる以下のメソッドを使用します。"
title: "Windows ストア申請 API を使用して、アプリの申請に関するパッケージのロールアウトを停止する"
ms.author: mcleans
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, Windowsストア申請 API, パッケージのロールアウト, アプリの申請, 停止"
ms.assetid: 4ce79fe3-deda-4d31-b938-d672c3869051
translationtype: Human Translation
ms.sourcegitcommit: 5645eee3dc2ef67b5263b08800b0f96eb8a0a7da
ms.openlocfilehash: a0da2fe0b8c859a774588d27d12ce3c9e3f24d9b
ms.lasthandoff: 02/08/2017

---

# <a name="halt-the-package-rollout-for-an-app-submission-using-the-windows-store-submission-api"></a>Windows ストア申請 API を使用して、アプリの申請に関するパッケージのロールアウトを停止する


アプリの申請に関する[パッケージのロールアウトを停止する](../publish/gradual-package-rollout.md#completing-the-rollout)には、Windows ストア申請 API に含まれる以下のメソッドを使用します。 Windows ストア申請 API を使ったアプリの申請の作成プロセスについて詳しくは、「[アプリの申請の管理](manage-app-submissions.md)」をご覧ください。


## <a name="prerequisites"></a>前提条件

このメソッドを使うには、最初に次の作業を行う必要があります。

* Windows ストア申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。
* このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら、新しいトークンを取得できます。
* デベロッパー センターのアカウントでアプリの申請を作成します。 この操作は、デベロッパー センター ダッシュボードまたは[アプリ申請の作成](create-an-app-submission.md)メソッドを使って実行できます。
* 申請に関する段階的なパッケージのロールアウトを有効にします。 これは、[デベロッパー センター ダッシュボード](../publish/gradual-package-rollout.md)で行うことも、[Windows ストア申請 API](manage-app-submissions.md#manage-gradual-package-rollout) を使用して行うこともできます。

>**注:**&nbsp;&nbsp;このメソッドは、Windows ストア申請 API を使用するためのアクセス許可が付与された Windows デベロッパー センター アカウントでのみ使用できます。 すべてのアカウントでこのアクセス許可が有効になっているとは限りません。

## <a name="request"></a>要求

このメソッドの構文は次のとおりです。 ヘッダーと要求のパラメーターの使用例と説明については、以下のセクションをご覧ください。

| メソッド | 要求 URI                                                      |
|--------|------------------------------------------------------------------|
| POST   | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/submissions/{submissionId}/haltpackagerollout``` |

<span/>
 

### <a name="request-header"></a>要求ヘッダー

| ヘッダー        | 型   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| Authorization | string | 必須。 **Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。 |

<span/>

### <a name="request-parameters"></a>要求パラメーター

| 名前        | 型   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| applicationId | string | 必須。 停止するパッケージのロールアウトの対象となる申請が含まれているアプリのストア ID です。 ストア ID について詳しくは、「[アプリ ID の詳細の表示](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details)」をご覧ください。  |
| submissionId | string | 必須。 停止するパッケージのロールアウトの対象となる申請の ID です。 この ID はデベロッパー センター ダッシュボードで確認でき、[アプリの申請の作成](create-an-app-submission.md)要求の応答データに含まれています。  |

<span/>

### <a name="request-body"></a>要求本文

このメソッドでは要求本文を指定しないでください。

### <a name="request-example"></a>要求の例

アプリの申請に関するパッケージのロールアウトを停止する方法の例を次に示します。

```
POST https://manage.devcenter.microsoft.com/v1.0/my/applications/9NBLGGH4R315/submissions/1152921504621243680/haltpackagerollout HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a>応答

次の例は、このメソッドが正常に呼び出された場合の JSON 応答本文を示しています。 応答本文の値について詳しくは、「[パッケージのロールアウトのリソース](manage-app-submissions.md#package-rollout-object)」をご覧ください。

```json
{
    "isPackageRollout": true,
    "packageRolloutPercentage": 0,
    "packageRolloutStatus": "PackageRolloutStopped",
    "fallbackSubmissionId": "1212922684621243058"
}
```

## <a name="error-codes"></a>エラー コード

要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。

| エラー コード |  説明   |
|--------|------------------|
| 404  | 申請は見つかりませんでした。 |
| 409  | このコードは、次のエラーのいずれかを示します。<br/><br/><ul><li>申請が、段階的なロールアウト操作に対して有効な状態になっていません (このメソッドを呼び出す前に、申請を公開し、[packageRolloutStatus](manage-app-submissions.md#package-rollout-object) の値を **PackageRolloutInProgress** に設定する必要があります)。</li><li>申請が、指定されたアプリに属していません。</li><li>アプリは、[Windows ストア申請 API で現在サポートされていない](create-and-manage-submissions-using-windows-store-services.md#not_supported)デベロッパー センターのダッシュボード機能を使用します。</li></ul> |   

<span/>


## <a name="related-topics"></a>関連トピック

* [段階的なパッケージのロールアウト](../publish/gradual-package-rollout.md)
* [Windows ストア申請 API を使用したアプリの申請の管理](manage-app-submissions.md)
* [Windows ストア サービスを使用した申請の作成と管理](create-and-manage-submissions-using-windows-store-services.md)

