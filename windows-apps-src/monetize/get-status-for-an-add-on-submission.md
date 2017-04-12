---
author: mcleanbyron
ms.assetid: 55315F38-6EC5-4889-A14E-7D8EC282FE98
description: "アドオンの申請の状態を取得するには、Windows ストア申請 API に含まれる以下のメソッドを使用します。"
title: "アドオンの申請の状態の取得"
ms.author: mcleans
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, Windows ストア申請 API, アドオンの申請, 状態"
ms.openlocfilehash: 691e512c2a072748434d092286f0ab36a90f91f2
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="get-the-status-of-an-add-on-submission"></a>アドオンの申請の状態の取得




アドオン (アプリ内製品または IAP とも呼ばれます) の申請の状態を取得するには、Windows ストア申請 API に含まれる以下のメソッドを使用します。 Windows ストア申請 API を使ったアドオンの申請の作成プロセスについて詳しくは、「[アドオンの申請の管理](manage-add-on-submissions.md)」をご覧ください。

## <a name="prerequisites"></a>前提条件

このメソッドを使うには、最初に次の作業を行う必要があります。

* Windows ストア申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。
* このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら新しいトークンを取得できます。
* デベロッパー センター アカウントにアドオン申請を作成します。 この操作は、デベロッパー センター ダッシュボードまたは[アドオン申請の作成](create-an-add-on-submission.md)メソッドを使って実行できます。

>**注:**&nbsp;&nbsp;このメソッドは、Windows ストア申請 API を使用するアクセス許可が付与された Windows デベロッパー センター アカウントにのみ使用できます。 すべてのアカウントでこのアクセス許可が有効になっているとは限りません。

## <a name="request"></a>要求

このメソッドの構文は次のとおりです。 ヘッダーと要求本文の使用例と説明については、次のセクションをご覧ください。

| メソッド | 要求 URI                                                      |
|--------|------------------------------------------------------------------|
| GET   | ```https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/{inAppProductId}/submissions/{submissionId}/status``` |

<span/>
 

### <a name="request-header"></a>要求ヘッダー

| ヘッダー        | 型   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| Authorization | string | 必須。 **Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。 |

<span/>

### <a name="request-parameters"></a>要求パラメーター

| 名前        | 型   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| inAppProductId | string | 必須。 状態を取得する申請が含まれているアドオンのストア ID です。 ストア ID はデベロッパー センター ダッシュボードで確認できます。  |
| submissionId | string | 必須。 状態を取得する申請の ID です。 この ID は、[アドオンの申請を作成する](create-an-add-on-submission.md)要求の応答データに含まれており、デベロッパー センター ダッシュボードで確認できます。  |

<span/>

### <a name="request-body"></a>要求本文

このメソッドでは要求本文を指定しないでください。

### <a name="request-example"></a>要求の例

次の例は、アドオン申請の状態を取得する方法を示しています。

```
GET https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/9NBLGGH4TNMP/submissions/1152921504621243680/status HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a>応答

次の例は、このメソッドが正常に呼び出された場合の JSON 応答本文を示しています。 応答本文には、指定された申請に関する情報が含まれています。 応答本文の値について詳しくは、次のセクションをご覧ください。

```json
{
  "status": "PendingCommit",
  "statusDetails": {
    "errors": [],
    "warnings": [],
    "certificationReports": []
  },
}
```

### <a name="response-body"></a>応答本文

| 値      | 型   | 説明                                                                                                                                                                                                                                                                         |
|------------|--------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| status           | string  | 申請の状態。 次のいずれかの値を使用できます。 <ul><li>None</li><li>Canceled</li><li>PendingCommit</li><li>CommitStarted</li><li>CommitFailed</li><li>PendingPublication</li><li>Publishing</li><li>Published</li><li>PublishFailed</li><li>PreProcessing</li><li>PreProcessingFailed</li><li>Certification</li><li>CertificationFailed</li><li>Release</li><li>ReleaseFailed</li></ul>   |
| statusDetails           | object  |  エラーに関する情報など、申請の状態に関する追加詳細情報が含まれています。 詳しくは、[ステータスの詳細に関するリソース](manage-add-on-submissions.md#status-details-object)をご覧ください。 |

<span/>

## <a name="error-codes"></a>エラー コード

要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。

| エラー コード |  説明   |
|--------|------------------|
| 404  | 申請は見つかりませんでした。 |
| 409  | アドオンは、[Windows ストア申請 API で現在サポートされていない](create-and-manage-submissions-using-windows-store-services.md#not_supported)デベロッパー センターのダッシュボード機能を使用します。  |

<span/>


## <a name="related-topics"></a>関連トピック

* [Windows ストア サービスを使用した申請の作成と管理](create-and-manage-submissions-using-windows-store-services.md)
* [アドオンの申請の取得](get-an-add-on-submission.md)
* [アドオンの申請の作成](create-an-add-on-submission.md)
* [アドオンの申請のコミット](commit-an-add-on-submission.md)
* [アドオンの申請の更新](update-an-add-on-submission.md)
* [アドオンの申請の削除](delete-an-add-on-submission.md)
