---
description: このセクションの Java コード例を使用して、Microsoft Store 申請 API を使用したゲーム オプションおよびトレーラーの申請方法をご確認ください。
title: Java のコード例 - ゲーム オプションおよびトレーラーを含むアプリの申請
ms.date: 07/10/2017
ms.topic: article
keywords: windows 10, uwp, Microsoft Store 申請 API, コード例, ゲーム オプション, トレーラー, 詳細な登録情報, Java
ms.localizationpriority: medium
ms.openlocfilehash: 93c629d509aaf3f92c3010e18077270339c7d332
ms.sourcegitcommit: 6a7dd4da2fc31ced7d1cdc6f7cf79c2e55dc5833
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/21/2019
ms.locfileid: "58334300"
---
# <a name="java-sample-app-submission-with-game-options-and-trailers"></a>Java のコード例: ゲーム オプションおよびトレーラーを含むアプリの申請

この記事では、次のタスクで [Microsoft Store 申請 API](create-and-manage-submissions-using-windows-store-services.md) を使用する方法を示す Java コード例を提供します。

* Microsoft Store 申請 API で使用する Azure AD アクセス トークンを取得します。
* アプリの申請の作成
* [ゲーム](manage-app-submissions.md#gaming-options-object)と[トレーラー](manage-app-submissions.md#trailer-object)の高度な登録情報のオプションを含む、アプリの申請用のストア登録情報データを構成します。
* アプリの申請用のパッケージ、登録情報の画像、トレーラー ファイルが含まれた ZIP ファイルをアップロードします。
* アプリの申請をコミットします。

<span id="create-app-submission" />

## <a name="create-an-app-submission"></a>アプリの申請の作成

`CreateAndSubmitSubmissionExample` クラスが実装する `main` プログラムでは、他のサンプル メソッドを呼び出し、Microsoft Store 申請 API を使って、ゲーム オプションとトレーラーを含むアプリの申請を作成およびコミットします。 このコードを採用するには、次の手順を実行してください。

* `tenantId` 変数をアプリのテナント ID に割り当てて、`clientId` 変数と `clientSecret` 変数をアプリのクライアント ID とキーに割り当てます。 詳細については、次を参照してください[に Azure AD アプリケーションを、パートナー センター アカウントに関連付ける方法。](create-and-manage-submissions-using-windows-store-services.md#how-to-associate-an-azure-ad-application-with-your-partner-center-account)
* `applicationId` 変数を、申請を作成するアプリの[ストア ID](in-app-purchases-and-trials.md#store-ids) に割り当てます。

> [!div class="tabbedCodeSnippets"]
[!code-java[SubmissionApi](./code/StoreServicesExamples_SubmissionAdvancedListings/java/CreateAndSubmitSubmissionExample.java#L1-L313)]

<span id="token" />

## <a name="obtain-an-azure-ad-access-token"></a>Azure AD アクセス トークンの取得

`DevCenterAccessTokenClient` クラスでは、指定された `tenantId`、`clientId`、`clientSecret` の値を使って、Microsoft Store 申請 API で使用する Azure AD アクセス トークンを作成するヘルパー メソッドを定義します。

> [!div class="tabbedCodeSnippets"]
[!code[SubmissionApi](./code/StoreServicesExamples_SubmissionAdvancedListings/java/DevCenterAccessTokenClient.java#L1-L69)]

<span id="utilities" />

## <a name="helper-methods-to-invoke-the-submission-api-and-upload-submission-files"></a>申請 API を呼び出して申請ファイルをアップロードするヘルパー メソッド

`DevCenterClient` クラスでは、Microsoft Store 申請 API のさまざまなメソッドを呼び出して、アプリの申請用のパッケージ、登録情報の画像、トレーラー ファイルを含む ZIP ファイルをアップロードするヘルパー メソッドを定義します。

> [!div class="tabbedCodeSnippets"]
[!code-java[SubmissionApi](./code/StoreServicesExamples_SubmissionAdvancedListings/java/DevCenterClient.java#L1-L224)]

## <a name="related-topics"></a>関連トピック

* [作成し、Microsoft Store サービスを使用して送信の管理](create-and-manage-submissions-using-windows-store-services.md)
