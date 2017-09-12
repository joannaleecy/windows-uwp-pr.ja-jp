---
author: mcleanbyron
description: "このセクションの Python コード例を使用して、Windows ストア申請 API を使用したゲーム オプションおよびトレーラーの申請方法をご確認ください。"
title: "Python のコード例: ゲーム オプションおよびトレーラーを含むアプリの申請"
ms.author: mcleans
ms.date: 07/10/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "windows 10, uwp, Windows ストア申請 API, コード例, ゲーム オプション, トレーラー, 詳細な登録情報, python"
ms.openlocfilehash: 225d6721760737388c0a14a3a63cc0c9608d53a9
ms.sourcegitcommit: a7a1b41c7dce6d56250ce3113137391d65d9e401
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/11/2017
---
# <a name="python-sample-app-submission-with-game-options-and-trailers"></a>Python のコード例: ゲーム オプションおよびトレーラーを含むアプリの申請

この記事では、次のタスクの [Windows ストア申請 API](create-and-manage-submissions-using-windows-store-services.md) の使用方法を示す Python コード例を提供します。

* Azure AD アクセス トークンを取得して、Windows ストア申請 API で使用します。
* アプリの申請の作成
* [ゲーム](manage-app-submissions.md#gaming-options-object)と[トレーラー](manage-app-submissions.md#trailer-object)の高度な登録情報のオプションを含む、アプリの申請用のストア登録情報データを構成します。
* アプリの申請用のパッケージ、登録情報の画像、トレーラー ファイルが含まれた ZIP ファイルをアップロードします。
* アプリの申請をコミットします。

<span id="create-app-submission" />
## <a name="create-an-app-submission"></a>アプリの申請の作成

このコードでは、他のサンプル クラスと関数を呼び出して、Windows ストア申請 API を使ってゲーム オプションとトレーラーを含むアプリの申請を作成、コミットします。 このコードを採用するには、次の手順を実行してください。

* ```tenant``` 変数をアプリのテナント ID に割り当てて、```client``` 変数と ```secret``` 変数をアプリのクライアント ID とキーに割り当てます。 詳しくは、「[Azure AD アプリケーションを Windows デベロッパー センター アカウントに関連付ける方法](create-and-manage-submissions-using-windows-store-services.md#how-to-associate-an-azure-ad-application-with-your-windows-dev-center-account)」をご覧ください。
* ```application_id``` 変数を、申請を作成するアプリの[ストア ID](in-app-purchases-and-trials.md#store_ids) に割り当てます。

> [!div class="tabbedCodeSnippets"]
[!code[SubmissionApi](./code/StoreServicesExamples_SubmissionAdvancedListings/python/CreateAndSubmitAppSubmissionExample.py#L1-L74)]

<span id="token" />
## <a name="obtain-an-azure-ad-access-token-and-invoke-the-submission-api"></a>Azure AD アクセス トークンを取得して申請 API を呼び出す

次の例では、以下に示すクラスを定義します。

* ```DevCenterAccessTokenClient``` クラスでは、```tenantId```、```clientId```、および ```clientSecret``` の値を使うヘルパー メソッドを定義して、Azure AD アクセス トークンを作成して Windows ストア申請 API で使用します。
* ```DevCenterClient``` クラスでは、Windows ストア申請 API のさまざまなメソッドを呼び出して、アプリの申請用のパッケージ、登録情報の画像、トレーラー ファイルを含む ZIP ファイルをアップロードするヘルパー メソッドを定義します。

> [!div class="tabbedCodeSnippets"]
[!code[SubmissionApi](./code/StoreServicesExamples_SubmissionAdvancedListings/python/devcenterclient.py#L1-L126)]

<span id="token" />
## <a name="get-app-submission-listing-data"></a>アプリの申請の登録情報データを取得する

次の例では、新しいサンプル アプリの申請用の JSON 形式の登録情報データを返すヘルパー関数を定義します。

> [!div class="tabbedCodeSnippets"]
[!code[SubmissionApi](./code/StoreServicesExamples_SubmissionAdvancedListings/python/submissiondatasamples.py#L1-L170)]

## <a name="related-topics"></a>関連トピック

* [Windows ストア サービスを使用した申請の作成と管理](create-and-manage-submissions-using-windows-store-services.md)
