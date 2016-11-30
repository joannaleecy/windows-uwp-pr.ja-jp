---
author: mcleanbyron
description: "アプリの申請に関するパッケージのロールアウトの情報を取得するには、Windows ストア申請 API に含まれる以下のメソッドを使用します。"
title: "Windows ストア申請 API を使用して、アプリの申請に関するパッケージのロールアウトの情報を取得する"
translationtype: Human Translation
ms.sourcegitcommit: 9b76a11adfab838b21713cb384cdf31eada3286e
ms.openlocfilehash: c7a3a12625594533af550921ae580842fa59be08

---

# Windows ストア申請 API を使用して、アプリの申請に関するパッケージのロールアウトの情報を取得する


パッケージ フライトの申請に関する[パッケージのロールアウト](../publish/gradual-package-rollout.md)の情報を取得するには、Windows ストア申請 API に含まれる以下のメソッドを使用します。 Windows ストア申請 API を使ったアプリの申請の作成プロセスについて詳しくは、「[アプリの申請の管理](manage-app-submissions.md)」をご覧ください。

## 前提条件

このメソッドを使うには、最初に次の作業を行う必要があります。

* Windows ストア申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。
* このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら、新しいトークンを取得できます。
* デベロッパー センターのアカウントでアプリの申請を作成します。 この操作は、デベロッパー センター ダッシュボードまたは[アプリ申請の作成](create-an-app-submission.md)メソッドを使って実行できます。

>**注:**&nbsp;&nbsp;このメソッドは、Windows ストア申請 API を使用するアクセス許可が付与された Windows デベロッパー センター アカウントにのみ使用できます。 すべてのアカウントでこのアクセス許可が有効になっているとは限りません。

## 要求

このメソッドの構文は次のとおりです。 ヘッダーと要求のパラメーターの使用例と説明については、以下のセクションをご覧ください。

| メソッド | 要求 URI                                                      |
|--------|------------------------------------------------------------------|
| GET   | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/submissions/{submissionId}/packagerollout   ``` |

<span/>
 

### 要求ヘッダー

| ヘッダー        | 型   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| Authorization | string | 必須。 **Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。 |

<span/>

### 要求パラメーター

| 名前        | 型   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| applicationId | string | 必須。 取得するパッケージのロールアウトの情報を持つ申請が含まれているアプリのストア ID です。 ストア ID について詳しくは、「[アプリ ID の詳細の表示](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details)」をご覧ください。  |
| submissionId | string | 必須。 取得するパッケージのロールアウトの情報を持つ申請の ID です。 この ID はデベロッパー センター ダッシュボードで確認でき、[アプリの申請の作成](create-an-app-submission.md)要求の応答データに含まれています。  |

<span/>

### 要求本文

このメソッドでは要求本文を指定しないでください。

### 要求の例

アプリの申請に関するパッケージのロールアウトの情報を取得する方法の例を次に示します。

```
GET https://manage.devcenter.microsoft.com/v1.0/my/applications/9NBLGGH4R315/submissions/1152921504621243649/packagerollout HTTP/1.1
Authorization: Bearer <your access token>
```

## 応答

次の例は、段階的なパッケージのロールアウトが有効になっているアプリの申請に対して、このメソッドが正常に呼び出された場合の JSON 応答本文を示しています。 応答本文の値について詳しくは、「[パッケージのロールアウトのリソース](manage-app-submissions.md#package-rollout-object)」をご覧ください。

```json
{
    "isPackageRollout": true,
    "packageRolloutPercentage": 25,
    "packageRolloutStatus": "PackageRolloutInProgress",
    "fallbackSubmissionId": "1212922684621243058"
}
```

アプリの申請で段階的なパッケージのロールアウトが有効になっていない場合は、次の応答の本文が返されます。

```json
{
    "isPackageRollout": false,
    "packageRolloutPercentage": 0,
    "packageRolloutStatus": "PackageRolloutNotStarted",
    "fallbackSubmissionId": "0"
}
```

## エラー コード

要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。

| エラー コード |  説明   |
|--------|------------------|
| 404  | 提出は見つかりませんでした。 |
| 409  | 指定されたアプリに申請が属していないか、[Windows ストア申請 API で現在サポートされていない](create-and-manage-submissions-using-windows-store-services.md#not_supported)デベロッパー センター ダッシュボード機能をアプリが使用しています。 |   

<span/>


## 関連トピック

* [段階的なパッケージのロールアウト](../publish/gradual-package-rollout.md)
* [Windows ストア申請 API を使用したアプリの申請の管理](manage-app-submissions.md)
* [Windows ストア サービスを使用した申請の作成と管理](create-and-manage-submissions-using-windows-store-services.md)



<!--HONumber=Nov16_HO1-->


