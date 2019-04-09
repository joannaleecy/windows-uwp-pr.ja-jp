---
description: パッケージ フライトの申請に関するパッケージのロールアウトを完了するには、Microsoft Store 申請 API の以下のメソッドを使います。
title: フライトの申請に関するロールアウトを完了する
ms.date: 04/17/2018
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store 申請 API, パッケージのロールアウト, フライトの申請, 最終処理
ms.assetid: e4a645f6-1f00-4af5-80d6-d2ee179acc8a
ms.localizationpriority: medium
ms.openlocfilehash: c2864dae721d572ef9e340eddfed0149aa0b621f
ms.sourcegitcommit: 6a7dd4da2fc31ced7d1cdc6f7cf79c2e55dc5833
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/21/2019
ms.locfileid: "58334650"
---
# <a name="finalize-the-rollout-for-a-flight-submission"></a>フライトの申請に関するロールアウトを完了する


パッケージ フライトの申請に関する[パッケージのロールアウトを完了する](../publish/gradual-package-rollout.md#completing-the-rollout)には、Microsoft Store 申請 API の以下のメソッドを使います。 Microsoft Store 申請 API を使ったパッケージ フライトの申請の作成プロセスについて詳しくは、「[パッケージ フライトの申請の管理](manage-flight-submissions.md)」をご覧ください。


## <a name="prerequisites"></a>前提条件

このメソッドを使うには、最初に次の作業を行う必要があります。

* Microsoft Store 申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。
* このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら新しいトークンを取得できます。
* パートナー センターでアプリの提出を作成します。 パートナー センターでこれを行うかを使用してこれを行う、[アプリの提出を作成](create-an-app-submission.md)メソッド。
* 申請に関する段階的なパッケージのロールアウトを有効にします。 これを行う[パートナー センター](../publish/gradual-package-rollout.md)、これを行うまたは[Microsoft Store 送信 API を使用して](manage-flight-submissions.md#manage-gradual-package-rollout)します。

## <a name="request"></a>要求

このメソッドの構文は次のとおりです。 ヘッダーと要求のパラメーターの使用例と説明については、以下のセクションをご覧ください。

| メソッド | 要求 URI                                                      |
|--------|------------------------------------------------------------------|
| POST   | `https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions/{submissionId}/finalizepackagerollout` |


### <a name="request-header"></a>要求ヘッダー

| Header        | 種類   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| Authorization | string | 必須。 **Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。 |


### <a name="request-parameters"></a>要求パラメーター

| 名前        | 種類   | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| applicationId | string | 必須。 完了するパッケージのロールアウトの対象となるパッケージ フライトの申請が含まれているアプリのストア ID です。 ストア ID について詳しくは、「[アプリ ID の詳細の表示](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details)」をご覧ください。  |
| flightId | string | 必須。 完了するパッケージのロールアウトの対象となる申請が含まれているパッケージ フライトの ID です。 この ID は、[パッケージ フライトの作成](create-a-flight.md)要求と[アプリのパッケージ フライトの取得](get-flights-for-an-app.md)要求の応答データで確認できます。 パートナー センターで作成されたフライトはこの ID はパートナー センターでのフライトのページの URL で使用できるも。 |
| submissionId | string | 必須。 完了するパッケージのロールアウトの対象となる申請の ID です。 この ID は、[パッケージ フライトの申請の作成](create-a-flight-submission.md)要求に対する応答データで確認できます。 パートナー センターで作成された送信、この ID はパートナー センターでの送信 ページの URL で使用できるも。  |


### <a name="request-body"></a>要求本文

このメソッドでは要求本文を指定しないでください。

### <a name="request-example"></a>要求の例

パッケージ フライトの申請に関するパッケージのロールアウトを完了する方法の例を次に示します。

```json
POST https://manage.devcenter.microsoft.com/v1.0/my/applications/9NBLGGH4R315/flights/43e448df-97c9-4a43-a0bc-2a445e736bcd/submissions/1152921504621243680/finalizepackagerollout HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a>応答

次の例は、このメソッドが正常に呼び出された場合の JSON 応答本文を示しています。 応答本文の値について詳しくは、「[パッケージのロールアウトのリソース](manage-flight-submissions.md#package-rollout-object)」をご覧ください。

```json
{
    "isPackageRollout": true,
    "packageRolloutPercentage": 100.0,
    "packageRolloutStatus": "PackageRolloutComplete",
    "fallbackSubmissionId": "1212922684621243058"
}
```

## <a name="error-codes"></a>エラー コード

要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。

| エラー コード |  説明   |
|--------|------------------|
| 404  | パッケージ フライトの申請は見つかりませんでした。 |
| 409  | このコードは、次のエラーのいずれかを示します。<br/><br/><ul><li>申請が、段階的なロールアウト操作に対して有効な状態になっていません (このメソッドを呼び出す前に、申請を公開し、[packageRolloutStatus](manage-flight-submissions.md#package-rollout-object) の値を **PackageRolloutInProgress** に設定する必要があります)。</li><li>申請が、指定されたアプリに属していません。</li><li>アプリはパートナー センター機能を使用する[現在サポートされていません、Microsoft Store 送信 API](create-and-manage-submissions-using-windows-store-services.md#not_supported)します。</li></ul> |   


## <a name="related-topics"></a>関連トピック

* [パッケージの段階的なロールアウト](../publish/gradual-package-rollout.md)
* [Microsoft Store 送信 API を使用してパッケージのフライトの送信を管理します。](manage-flight-submissions.md)
* [作成し、Microsoft Store サービスを使用して送信の管理](create-and-manage-submissions-using-windows-store-services.md)
