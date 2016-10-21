---
author: mcleanbyron
ms.assetid: 55315F38-6EC5-4889-A14E-7D8EC282FE98
description: "Windows ストア提出 API 内のこのメソッドを使用して、アドオンの提出ステータスを取得します。"
title: "Windows ストア提出 API を使用したアドオンの提出ステータスの取得"
translationtype: Human Translation
ms.sourcegitcommit: 5f975d0a99539292e1ce91ca09dbd5fac11c4a49
ms.openlocfilehash: e5be4ee466c204255a074adae4d150860286ba0a

---

# Windows ストア提出 API を使用したアドオンの提出ステータスの取得




アドオン (アプリ内製品 (IAP) とも呼ばれます) 提出のステータスを取得するには、Windows ストア提出 API 内のこのメソッドを使用します。 Windows ストア提出 API を使ったアドオンの提出の作成プロセスについて詳しくは、「[アドオンの提出の管理](manage-add-on-submissions.md)」をご覧ください。

## 前提条件

このメソッドを使うには、最初に次の作業を行う必要があります。

* Windows ストア提出 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。
* このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら、新しいトークンを取得できます。
* デベロッパー センター アカウントにアプリのアドオン提出を作成します。 この操作は、デベロッパー センター ダッシュボードまたは[アドオン提出の作成](create-an-add-on-submission.md)メソッドを使って実行できます。

>**注:**&nbsp;&nbsp;このメソッドは、Windows ストア提出 API を使用するアクセス許可が付与された Windows デベロッパー センター アカウントにのみ使用できます。 すべてのアカウントでこのアクセス許可が有効になっているとは限りません。

## 要求

このメソッドの構文は次のとおりです。 ヘッダーと要求本文の使用例と説明については、次のセクションをご覧ください。

| メソッド | 要求 URI                                                      |
|--------|------------------------------------------------------------------|
| GET   | ```https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/{inAppProductId}/submissions/{submissionId}/status``` |

<span/>
 

### 要求ヘッダー

| ヘッダー        | 型   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| Authorization | string | 必須。 **Bearer** &lt;*token*&gt; という形式の Azure AD アクセス トークン。 |

<span/>

### 要求パラメーター

| 名前        | 型   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| inAppProductId | string | 必須。 ステータスを取得する提出が含まれているアドオンのストア ID です。 ストア ID はデベロッパー センター ダッシュボードで確認できます。  |
| submissionId | string | 必須。 ステータスを取得する提出の ID です。 この ID は、[アドオン提出の作成](create-an-add-on-submission.md)要求の応答データに含まれており、デベロッパー センター ダッシュボードで確認できます。  |

<span/>

### 要求本文

このメソッドでは要求本文を指定しないでください。

### 要求の例

次の例は、アドオン提出のステータスを取得する方法を示しています。

```
GET https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/9NBLGGH4TNMP/submissions/1152921504621243680/status HTTP/1.1
Authorization: Bearer <your access token>
```

## 応答

次の例は、このメソッドが正常に呼び出された場合の JSON 応答本文を示しています。 応答本文には、指定された提出に関する情報が含まれています。 応答本文の値について詳しくは、次のセクションをご覧ください。

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

### 応答本文

| 値      | 型   | 説明                                                                                                                                                                                                                                                                         |
|------------|--------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| status           | string  | 提出の状態。 次のいずれかの値を使用できます。 <ul><li>None</li><li>Canceled</li><li>PendingCommit</li><li>CommitStarted</li><li>CommitFailed</li><li>PendingPublication</li><li>Publishing</li><li>Published</li><li>PublishFailed</li><li>PreProcessing</li><li>PreProcessingFailed</li><li>Certification</li><li>CertificationFailed</li><li>Release</li><li>ReleaseFailed</li></ul>   |
| statusDetails           | object  |  エラーに関する情報など、提出ステータスに関する追加詳細情報が含まれています。 詳しくは、[ステータスの詳細に関するリソース](manage-add-on-submissions.md#status-details-object)をご覧ください。 |

<span/>

## エラー コード

要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。

| エラー コード |  説明   |
|--------|------------------|
| 404  | 提出は見つかりませんでした。 |
| 409  | アドオンは、[Windows ストア提出 API で現在サポートされていない](create-and-manage-submissions-using-windows-store-services.md#not_supported)デベロッパー センターのダッシュボード機能を使用します。  |

<span/>


## 関連トピック

* [Windows ストア サービスを使用した提出の作成と管理](create-and-manage-submissions-using-windows-store-services.md)
* [アドオンの提出の取得](get-an-add-on-submission.md)
* [アドオンの提出の作成](create-an-add-on-submission.md)
* [アドオンの提出のコミット](commit-an-add-on-submission.md)
* [アドオンの提出の更新](update-an-add-on-submission.md)
* [アドオンの提出の削除](delete-an-add-on-submission.md)



<!--HONumber=Aug16_HO5-->


