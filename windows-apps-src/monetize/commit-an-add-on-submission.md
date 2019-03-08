---
ms.assetid: AC74B4FA-5554-4C03-9683-86EE48546C05
description: Microsoft Store 送信 API でこのメソッドを使用して、パートナー センターに送信する新しいまたは更新されたアドオンをコミットします。
title: アドオンの申請のコミット
ms.date: 04/17/2018
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store 申請 API, アドオンの申請のコミット, アプリ内製品, IAP
ms.localizationpriority: medium
ms.openlocfilehash: efab4412486566ae817eb66e78f5407533a30d5b
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57608217"
---
# <a name="commit-an-add-on-submission"></a>アドオンの申請のコミット

Microsoft Store 送信 API でこのメソッドを使用して、パートナー センターに送信する新規または更新済みのアドオン (とも呼ばれるアプリ内製品または IAP) をコミットします。 コミット アクション アラート パートナー センター (すべての関連するアイコンを含む) の送信データがアップロードされています。 応答では、パートナー センターは、送信データの取り込みおよび発行に変更をコミットします。 コミット操作が成功すると、パートナー センターで、送信への変更が表示されます。

コミット操作が Microsoft Store 申請 API を使ったアドオンの申請プロセスにどのように適合するかについては、「[アドオンの申請の管理](manage-add-on-submissions.md)」をご覧ください。

## <a name="prerequisites"></a>前提条件

このメソッドを使うには、最初に次の作業を行う必要があります。

* Microsoft Store 申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。
* このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら新しいトークンを取得できます。
* [アドオンの申請を作成](create-an-add-on-submission.md)し、申請データを必要に応じて変更して[申請を更新](update-an-add-on-submission.md)します。

## <a name="request"></a>要求

このメソッドの構文は次のとおりです。 ヘッダーと要求本文の使用例と説明については、次のセクションをご覧ください。

| メソッド | 要求 URI                                                      |
|--------|------------------------------------------------------------------|
| POST    | ```https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/{inAppProductId}/submissions/{submissionId}/commit``` |


### <a name="request-header"></a>要求ヘッダー

| Header        | 種類   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| Authorization | string | 必須。 **Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。 |


### <a name="request-parameters"></a>要求パラメーター

| 名前        | 種類   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| inAppProductId | string | 必須。 コミットする申請が含まれるアドオンのストア ID です。 Store ID は、パートナー センターで利用できるとするための要求応答のデータに含まれる[すべてのアドオンを入手する](get-all-add-ons.md)と[アドオンを作成](create-an-add-on.md)です。 |
| submissionId | string | 必須。 コミットする申請の ID です。 この ID は、[アドオンの申請の作成](create-an-add-on-submission.md)要求に対する応答データで確認できます。 パートナー センターで作成された送信、この ID はパートナー センターでの送信 ページの URL で使用できるも。  |


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

| Value      | 種類   | 説明                                                                                                                                                                                                                                                                         |
|------------|--------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| status           | string  | 申請の状態。 次のいずれかの値を使用できます。 <ul><li>なし</li><li>Canceled</li><li>PendingCommit</li><li>CommitStarted</li><li>CommitFailed</li><li>PendingPublication</li><li>公開</li><li>公開済み</li><li>PublishFailed</li><li>PreProcessing</li><li>PreProcessingFailed</li><li>認定</li><li>CertificationFailed</li><li>リリース</li><li>ReleaseFailed</li></ul>  |


## <a name="error-codes"></a>エラー コード

要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。

| エラー コード |  説明   |
|--------|------------------|
| 400  | 要求パラメーターが有効ではありません。 |
| 404  | 指定した申請は見つかりませんでした。 |
| 409  | 指定した送信が見つかりましたが、現在の状態で、コミットできなかったまたはアドオンであるパートナー センター機能を使用する[現在サポートされていません、Microsoft Store 送信 API](create-and-manage-submissions-using-windows-store-services.md#not_supported)します。 |


## <a name="related-topics"></a>関連トピック

* [作成し、Microsoft Store サービスを使用して送信の管理](create-and-manage-submissions-using-windows-store-services.md)
* [取得するアドオンの送信](get-an-add-on-submission.md)
* [アドオンを提出を作成します。](create-an-add-on-submission.md)
* [アドオンを申請を更新します。](update-an-add-on-submission.md)
* [削除するアドオンの送信](delete-an-add-on-submission.md)
* [アドオンの提出パッケージのステータスを取得します。](get-status-for-an-add-on-submission.md)
