---
author: mcleanbyron
description: "このセクションの C# コード例を使用して、Windows ストア申請 API を使用したゲーム オプションおよびトレーラーの申請方法をご確認ください。"
title: "C# のコード例 - ゲーム オプションおよびトレーラーを含むアプリの申請"
ms.author: mcleans
ms.date: 07/10/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "windows 10, uwp, Windows ストア申請 API, コード例, ゲーム オプション, トレーラー, 詳細な登録情報, C#"
ms.openlocfilehash: 2020d280d7b4ffa3cede11b089f808920ddf46b9
ms.sourcegitcommit: a7a1b41c7dce6d56250ce3113137391d65d9e401
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/11/2017
---
# <a name="c-sample-app-submission-with-game-options-and-trailers"></a>C# のコード例 : ゲーム オプションおよびトレーラーを含むアプリの申請

この記事では、これらのタスクの [Windows ストア申請 API](create-and-manage-submissions-using-windows-store-services.md) の使用方法を示す C# コード例を提供します。

* Azure AD アクセス トークンを取得して、Windows ストア申請 API で使用します。
* アプリの申請の作成
* [ゲーム](manage-app-submissions.md#gaming-options-object)と[トレーラー](manage-app-submissions.md#trailer-object)の詳細な登録情報のオプションを含む、アプリの申請用のストア登録情報データを構成します。
* アプリの申請用のパッケージ、登録情報の画像、トレーラー ファイルが含まれた ZIP ファイルをアップロードします。
* アプリの申請をコミットします。

各例を確認して、それぞれが対応するタスクについて詳しく知ることができます。また、この記事のすべてのコード例を使って、コンソール アプリケーションをビルドすることもできます。 サンプルをビルドするには、Visual Studio で **DevCenterApiSample** という名前の C# コンソール アプリケーションを作成し、各サンプルをプロジェクトの別のコード ファイルにコピーして、プロジェクトをビルドします。

## <a name="prerequisites"></a>前提条件

これらの例には、次の要件があります。

* プロジェクトに System.Web アセンブリへの参照を追加します。
* Newtonsoft の [Newtonsoft.Json](http://www.newtonsoft.com/json) NuGet パッケージをプロジェクトにインストールします。

<span id="create-app-submission" />
## <a name="create-an-app-submission"></a>アプリの申請の作成

```CreateAndSubmitSubmissionExample``` クラスは他のメソッドの例を呼び出すパブリック メソッド ```Execute``` を定義し、Windows ストア申請 API を使用してゲーム オプションとトレーラーを含むアプリの申請を作成およびコミットします。 このコードを採用するには、次の手順を実行してください。

* ```tenantId``` 変数をアプリのテナント ID に割り当てて、```clientId``` 変数と ```clientSecret``` 変数をアプリのクライアント ID とキーに割り当てます。 詳しくは、[Azure AD アプリケーションを Windows デベロッパー センター アカウントに関連付ける方法](create-and-manage-submissions-using-windows-store-services.md#how-to-associate-an-azure-ad-application-with-your-windows-dev-center-account)をご覧ください。
* ```applicationId``` 変数を、申請を作成するアプリの[ストア ID](in-app-purchases-and-trials.md#store_ids) に割り当てます。

> [!div class="tabbedCodeSnippets"]
[!code-cs[SubmissionApi](./code/StoreServicesExamples_SubmissionAdvancedListings/cs/CreateAndSubmitSubmissionExample.cs#CreateAndSubmitSubmissionExample)]

<span id="token" />
## <a name="obtain-an-azure-ad-access-token"></a>Azure AD アクセス トークンの取得

```DevCenterAccessTokenClient``` クラスでは、```tenantId```、```clientId```、および ```clientSecret``` の値を使うヘルパー メソッドを定義して、Azure AD アクセス トークンを作成して Windows ストア申請 API で使用します。

> [!div class="tabbedCodeSnippets"]
[!code-cs[SubmissionApi](./code/StoreServicesExamples_SubmissionAdvancedListings/cs/DevCenterAccessTokenClient.cs#DevCenterAccessTokenClient)]

<span id="utilities" />
## <a name="helper-methods-to-invoke-the-submission-api-and-upload-submission-files"></a>申請 API を呼び出して申請ファイルをアップロードするヘルパー メソッド

```DevCenterClient``` クラスでは、Windows ストア申請 API のさまざまなメソッドを呼び出して、アプリの申請用のパッケージ、登録情報の画像、トレーラー ファイルを含む ZIP ファイルをアップロードするヘルパー メソッドを定義します。

> [!div class="tabbedCodeSnippets"]
[!code-cs[SubmissionApi](./code/StoreServicesExamples_SubmissionAdvancedListings/cs/DevCenterClient.cs#DevCenterClient)]

## <a name="related-topics"></a>関連トピック

* [Windows ストア サービスを使用した申請の作成と管理](create-and-manage-submissions-using-windows-store-services.md)
