---
ms.assetid: F94AF8F6-0742-4A3F-938E-177472F96C00
description: Microsoft Store 送信 API でこのメソッドを使用して、パートナー センターに新しいまたは更新されたパッケージのフライトの送信をコミットします。
title: パッケージ フライトの申請のコミット
ms.date: 04/17/2018
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store 申請 API, フライトの申請のコミット
ms.localizationpriority: medium
ms.openlocfilehash: 820e10695cce2d6242a51b0017d2fe3981cf77b1
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57603477"
---
# <a name="commit-a-package-flight-submission"></a>パッケージ フライトの申請のコミット

Microsoft Store 送信 API でこのメソッドを使用して、パートナー センターに新しいまたは更新されたパッケージのフライトの送信をコミットします。 コミット アクション アラート パートナー センター (関連するパッケージを含む) の送信データがアップロードされています。 応答では、パートナー センターは、送信データの取り込みおよび発行に変更をコミットします。 コミット操作が成功すると、パートナー センターで、送信への変更が表示されます。

コミット操作が Microsoft Store 申請 API を使ったパッケージ フライト申請の作成プロセスにどのように適合するかについては、「[パッケージ フライト申請の管理](manage-flight-submissions.md)」をご覧ください。

## <a name="prerequisites"></a>前提条件

このメソッドを使うには、最初に次の作業を行う必要があります。

* Microsoft Store 申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。
* このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら新しいトークンを取得できます。
* [パッケージ フライトの申請を作成](create-a-flight-submission.md)し、申請データを必要に応じて変更して[申請を更新](update-a-flight-submission.md)します。

## <a name="request"></a>要求

このメソッドの構文は次のとおりです。 ヘッダーと要求本文の使用例と説明については、次のセクションをご覧ください。

| メソッド | 要求 URI                                                      |
|--------|------------------------------------------------------------------|
| POST    | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions/{submissionId}/commit``` |


### <a name="request-header"></a>要求ヘッダー

| Header        | 種類   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| Authorization | string | 必須。 **Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。 |


### <a name="request-parameters"></a>要求パラメーター

| 名前        | 種類   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| applicationId | string | 必須。 コミットするパッケージ フライトの申請が含まれるアプリのストア ID です。 アプリの Store ID は、パートナー センターで使用できます。  |
| flightId | string | 必須。 コミットする申請が含まれるパッケージ フライトの ID です。 この ID は、[パッケージ フライトの作成](create-a-flight.md)要求と[アプリのパッケージ フライトの取得](get-flights-for-an-app.md)要求の応答データで確認できます。 パートナー センターで作成されたフライトはこの ID はパートナー センターでのフライトのページの URL で使用できるも。  |
| submissionId | string | 必須。 コミットする申請の ID です。 この ID は、[パッケージ フライトの申請の作成](create-a-flight-submission.md)要求に対する応答データで確認できます。 パートナー センターで作成された送信、この ID はパートナー センターでの送信 ページの URL で使用できるも。  |


### <a name="request-body"></a>要求本文

このメソッドでは要求本文を指定しないでください。

### <a name="request-example"></a>要求の例

次の例は、パッケージ フライトの申請をコミットする方法を示しています。

```
POST https://manage.devcenter.microsoft.com/v1.0/my/applications/9NBLGGH4R315/flights/43e448df-97c9-4a43-a0bc-2a445e736bcd/submissions/1152921504621243649/commit HTTP/1.1
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
| 409  | 指定した送信が見つかりましたが、現在の状態で、コミットできなかったまたは、アプリはパートナー センター機能を使用する[現在サポートされていません、Microsoft Store 送信 API](create-and-manage-submissions-using-windows-store-services.md#not_supported)します。 |


## <a name="related-topics"></a>関連トピック

* [作成し、Microsoft Store サービスを使用して送信の管理](create-and-manage-submissions-using-windows-store-services.md)
* [パッケージのフライトの送信を管理します。](manage-flight-submissions.md)
* [パッケージのフライトの送信を取得します。](get-a-flight-submission.md)
* [パッケージのフライトの提出を作成します。](create-a-flight-submission.md)
* [更新プログラム パッケージのフライトの送信](update-a-flight-submission.md)
* [パッケージのフライトの送信を削除します。](delete-a-flight-submission.md)
* [パッケージのフライトの送信の状態を取得します。](get-status-for-a-flight-submission.md)
