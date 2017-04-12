---
author: mcleanbyron
ms.assetid: AC74B4FA-5554-4C03-9683-86EE48546C05
description: "新しいアドオンの申請または更新されたアドオンの申請を Windows デベロッパー センターにコミットするには、Windows ストア申請 API に含まれる以下のメソッドを使用します。"
title: "アドオンの申請のコミット"
ms.author: mcleans
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10、UWP、Windows ストア申請 API、アドオンの申請のコミット、アプリ内製品、IAP"
ms.openlocfilehash: 3ab65675822f9b9c88e5c613c4394b295e7430e1
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="commit-an-add-on-submission"></a>アドオンの申請のコミット




新しいアドオンの申請または更新されたアドオン (アプリ内製品または IAP とも呼ばれます) の申請を Windows デベロッパー センターにコミットするには、Windows ストア申請 API に含まれる以下のメソッドを使用します。 コミット アクションにより、申請データ (関連アイコンを含む) がアップロードされたことがデベロッパー センターに通知されます。 通知を受けたデベロッパー センターは、申請データに対する変更をインジェストと公開のためにコミットします。 適切にコミットされると、申請に対する変更はデベロッパー センター ダッシュボードに表示されます。

コミット操作が Windows ストア申請 API を使ったアドオン申請プロセスにどのように適合するかについては、[アドオン申請の管理に関するページ](manage-add-on-submissions.md)をご覧ください。

## <a name="prerequisites"></a>前提条件

このメソッドを使うには、最初に次の作業を行う必要があります。

* Windows ストア申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。
* このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら新しいトークンを取得できます。
* [アドオンの申請を作成](create-an-add-on-submission.md)し、申請データを必要に応じて変更して[申請を更新](update-an-add-on-submission.md)します。

>**注:**&nbsp;&nbsp;このメソッドは、Windows ストア申請 API を使用するアクセス許可が付与された Windows デベロッパー センター アカウントにのみ使用できます。 すべてのアカウントでこのアクセス許可が有効になっているとは限りません。

## <a name="request"></a>要求

このメソッドの構文は次のとおりです。 ヘッダーと要求本文の使用例と説明については、次のセクションをご覧ください。

| メソッド | 要求 URI                                                      |
|--------|------------------------------------------------------------------|
| POST    | ```https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/{inAppProductId}/submissions/{submissionId}/commit``` |

<span/>
 

### <a name="request-header"></a>要求ヘッダー

| ヘッダー        | 型   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| Authorization | string | 必須。 **Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。 |

<span/>

### <a name="request-parameters"></a>要求パラメーター

| 名前        | 型   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| inAppProductId | string | 必須。 コミットする申請が含まれるアドオンのストア ID です。 ストア ID は、[すべてのアドオン取得](get-all-add-ons.md)要求と[アドオン作成](create-an-add-on.md)要求の応答データに含まれており、デベロッパー センター ダッシュボードで確認できます。 |
| submissionId | string | 必須。 コミットする申請の ID です。 この ID は、[アドオン申請の作成](create-an-add-on-submission.md)要求の応答データに含まれており、デベロッパー センター ダッシュボードで確認できます。  |

<span/>

### <a name="request-body"></a>要求本文

このメソッドでは要求本文を指定しないでください。

### <a name="request-example"></a>要求の例

次の例は、アドオンの申請をコミットする方法を示しています。

```
POST https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/9NBLGGH4TNMP/submissions/1152921504621230023/commit HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a>応答

次の例は、このメソッドが正常に呼び出された場合の JSON 応答本文を示しています。 応答本文の値について詳しくは、次のセクションをご覧ください。

```json
{
  "status": "CommitStarted"
}
```

### <a name="response-body"></a>応答本文

| 値      | 型   | 説明                                                                                                                                                                                                                                                                         |
|------------|--------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| status           | string  | 申請の状態。 次のいずれかの値を使用できます。 <ul><li>None</li><li>Canceled</li><li>PendingCommit</li><li>CommitStarted</li><li>CommitFailed</li><li>PendingPublication</li><li>Publishing</li><li>Published</li><li>PublishFailed</li><li>PreProcessing</li><li>PreProcessingFailed</li><li>Certification</li><li>CertificationFailed</li><li>Release</li><li>ReleaseFailed</li></ul>  |

<span/>

## <a name="error-codes"></a>エラー コード

要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。

| エラー コード |  説明   |
|--------|------------------|
| 400  | 要求パラメーターが有効ではありません。 |
| 404  | 指定した申請は見つかりませんでした。 |
| 409  | 指定した申請は見つかりましたが、現在の状態でコミットできなかったか、[Windows ストア申請 API で現在サポートされていない](create-and-manage-submissions-using-windows-store-services.md#not_supported)デベロッパー センター ダッシュボード機能がアドオンで使用されています。 |

<span/>


## <a name="related-topics"></a>関連トピック

* [Windows ストア サービスを使用した申請の作成と管理](create-and-manage-submissions-using-windows-store-services.md)
* [アドオンの申請の取得](get-an-add-on-submission.md)
* [アドオンの申請の作成](create-an-add-on-submission.md)
* [アドオンの申請の更新](update-an-add-on-submission.md)
* [アドオンの申請の削除](delete-an-add-on-submission.md)
* [アドオンの申請の状態の取得](get-status-for-an-add-on-submission.md)
