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
# <a name="c-sample-app-submission-with-game-options-and-trailers"></a><span data-ttu-id="9fe6e-104">C# のコード例 : ゲーム オプションおよびトレーラーを含むアプリの申請</span><span class="sxs-lookup"><span data-stu-id="9fe6e-104">C\# sample: app submission with game options and trailers</span></span>

<span data-ttu-id="9fe6e-105">この記事では、これらのタスクの [Windows ストア申請 API](create-and-manage-submissions-using-windows-store-services.md) の使用方法を示す C# コード例を提供します。</span><span class="sxs-lookup"><span data-stu-id="9fe6e-105">This article provides C# code examples that demonstrate how to use the [Windows Store submission API](create-and-manage-submissions-using-windows-store-services.md) for these tasks:</span></span>

* <span data-ttu-id="9fe6e-106">Azure AD アクセス トークンを取得して、Windows ストア申請 API で使用します。</span><span class="sxs-lookup"><span data-stu-id="9fe6e-106">Obtain an Azure AD access token to use with the Windows Store submission API.</span></span>
* <span data-ttu-id="9fe6e-107">アプリの申請の作成</span><span class="sxs-lookup"><span data-stu-id="9fe6e-107">Create an app submission</span></span>
* <span data-ttu-id="9fe6e-108">[ゲーム](manage-app-submissions.md#gaming-options-object)と[トレーラー](manage-app-submissions.md#trailer-object)の詳細な登録情報のオプションを含む、アプリの申請用のストア登録情報データを構成します。</span><span class="sxs-lookup"><span data-stu-id="9fe6e-108">Configure Store listing data for the app submission, including the [gaming](manage-app-submissions.md#gaming-options-object) and [trailers](manage-app-submissions.md#trailer-object) advanced listing options.</span></span>
* <span data-ttu-id="9fe6e-109">アプリの申請用のパッケージ、登録情報の画像、トレーラー ファイルが含まれた ZIP ファイルをアップロードします。</span><span class="sxs-lookup"><span data-stu-id="9fe6e-109">Upload the ZIP file containing the packages, listing images, and trailer files for the app submission.</span></span>
* <span data-ttu-id="9fe6e-110">アプリの申請をコミットします。</span><span class="sxs-lookup"><span data-stu-id="9fe6e-110">Commit the app submission.</span></span>

<span data-ttu-id="9fe6e-111">各例を確認して、それぞれが対応するタスクについて詳しく知ることができます。また、この記事のすべてのコード例を使って、コンソール アプリケーションをビルドすることもできます。</span><span class="sxs-lookup"><span data-stu-id="9fe6e-111">You can review each example to learn more about the task it demonstrates, or you can build all the code examples in this article into a console application.</span></span> <span data-ttu-id="9fe6e-112">サンプルをビルドするには、Visual Studio で **DevCenterApiSample** という名前の C# コンソール アプリケーションを作成し、各サンプルをプロジェクトの別のコード ファイルにコピーして、プロジェクトをビルドします。</span><span class="sxs-lookup"><span data-stu-id="9fe6e-112">To build the examples, create a C# console application named **DevCenterApiSample** in Visual Studio, copy each example to a separate code file in the project, and build the project.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="9fe6e-113">前提条件</span><span class="sxs-lookup"><span data-stu-id="9fe6e-113">Prerequisites</span></span>

<span data-ttu-id="9fe6e-114">これらの例には、次の要件があります。</span><span class="sxs-lookup"><span data-stu-id="9fe6e-114">These examples have the following requirements:</span></span>

* <span data-ttu-id="9fe6e-115">プロジェクトに System.Web アセンブリへの参照を追加します。</span><span class="sxs-lookup"><span data-stu-id="9fe6e-115">Add a reference to the System.Web assembly in your project.</span></span>
* <span data-ttu-id="9fe6e-116">Newtonsoft の [Newtonsoft.Json](http://www.newtonsoft.com/json) NuGet パッケージをプロジェクトにインストールします。</span><span class="sxs-lookup"><span data-stu-id="9fe6e-116">Install the [Newtonsoft.Json](http://www.newtonsoft.com/json) NuGet package from Newtonsoft to your project.</span></span>

<span id="create-app-submission" />
## <a name="create-an-app-submission"></a><span data-ttu-id="9fe6e-117">アプリの申請の作成</span><span class="sxs-lookup"><span data-stu-id="9fe6e-117">Create an app submission</span></span>

<span data-ttu-id="9fe6e-118">```CreateAndSubmitSubmissionExample``` クラスは他のメソッドの例を呼び出すパブリック メソッド ```Execute``` を定義し、Windows ストア申請 API を使用してゲーム オプションとトレーラーを含むアプリの申請を作成およびコミットします。</span><span class="sxs-lookup"><span data-stu-id="9fe6e-118">The ```CreateAndSubmitSubmissionExample``` class defines a public ```Execute``` method that calls other example methods to use the Windows Store submission API to create and commit an app submission that contains game options and a trailer.</span></span> <span data-ttu-id="9fe6e-119">このコードを採用するには、次の手順を実行してください。</span><span class="sxs-lookup"><span data-stu-id="9fe6e-119">To adapt this code for your own use:</span></span>

* <span data-ttu-id="9fe6e-120">```tenantId``` 変数をアプリのテナント ID に割り当てて、```clientId``` 変数と ```clientSecret``` 変数をアプリのクライアント ID とキーに割り当てます。</span><span class="sxs-lookup"><span data-stu-id="9fe6e-120">Assign the ```tenantId``` variable to the tenant ID for your app, and assign the ```clientId``` and ```clientSecret``` variables to the client ID and key for your app.</span></span> <span data-ttu-id="9fe6e-121">詳しくは、[Azure AD アプリケーションを Windows デベロッパー センター アカウントに関連付ける方法](create-and-manage-submissions-using-windows-store-services.md#how-to-associate-an-azure-ad-application-with-your-windows-dev-center-account)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9fe6e-121">For more information, see [How to associate an Azure AD application with your Windows Dev Center account](create-and-manage-submissions-using-windows-store-services.md#how-to-associate-an-azure-ad-application-with-your-windows-dev-center-account)</span></span>
* <span data-ttu-id="9fe6e-122">```applicationId``` 変数を、申請を作成するアプリの[ストア ID](in-app-purchases-and-trials.md#store_ids) に割り当てます。</span><span class="sxs-lookup"><span data-stu-id="9fe6e-122">Assign the ```applicationId``` variable to the [Store ID](in-app-purchases-and-trials.md#store_ids) of the app for which you want to create a submission.</span></span>

> [!div class="tabbedCodeSnippets"]
[!code-cs[<span data-ttu-id="9fe6e-123">SubmissionApi</span><span class="sxs-lookup"><span data-stu-id="9fe6e-123">SubmissionApi</span></span>](./code/StoreServicesExamples_SubmissionAdvancedListings/cs/CreateAndSubmitSubmissionExample.cs#CreateAndSubmitSubmissionExample)]

<span id="token" />
## <a name="obtain-an-azure-ad-access-token"></a><span data-ttu-id="9fe6e-124">Azure AD アクセス トークンの取得</span><span class="sxs-lookup"><span data-stu-id="9fe6e-124">Obtain an Azure AD access token</span></span>

<span data-ttu-id="9fe6e-125">```DevCenterAccessTokenClient``` クラスでは、```tenantId```、```clientId```、および ```clientSecret``` の値を使うヘルパー メソッドを定義して、Azure AD アクセス トークンを作成して Windows ストア申請 API で使用します。</span><span class="sxs-lookup"><span data-stu-id="9fe6e-125">The ```DevCenterAccessTokenClient``` class defines a helper method that uses the your ```tenantId```, ```clientId``` and ```clientSecret``` values to create an Azure AD access token to use with the Windows Store submission API.</span></span>

> [!div class="tabbedCodeSnippets"]
[!code-cs[<span data-ttu-id="9fe6e-126">SubmissionApi</span><span class="sxs-lookup"><span data-stu-id="9fe6e-126">SubmissionApi</span></span>](./code/StoreServicesExamples_SubmissionAdvancedListings/cs/DevCenterAccessTokenClient.cs#DevCenterAccessTokenClient)]

<span id="utilities" />
## <a name="helper-methods-to-invoke-the-submission-api-and-upload-submission-files"></a><span data-ttu-id="9fe6e-127">申請 API を呼び出して申請ファイルをアップロードするヘルパー メソッド</span><span class="sxs-lookup"><span data-stu-id="9fe6e-127">Helper methods to invoke the submission API and upload submission files</span></span>

<span data-ttu-id="9fe6e-128">```DevCenterClient``` クラスでは、Windows ストア申請 API のさまざまなメソッドを呼び出して、アプリの申請用のパッケージ、登録情報の画像、トレーラー ファイルを含む ZIP ファイルをアップロードするヘルパー メソッドを定義します。</span><span class="sxs-lookup"><span data-stu-id="9fe6e-128">The ```DevCenterClient``` class defines helper methods that invoke a variety of methods in the Windows Store submission API and upload the ZIP file containing the packages, listing images, and trailer files for the app submission.</span></span>

> [!div class="tabbedCodeSnippets"]
[!code-cs[<span data-ttu-id="9fe6e-129">SubmissionApi</span><span class="sxs-lookup"><span data-stu-id="9fe6e-129">SubmissionApi</span></span>](./code/StoreServicesExamples_SubmissionAdvancedListings/cs/DevCenterClient.cs#DevCenterClient)]

## <a name="related-topics"></a><span data-ttu-id="9fe6e-130">関連トピック</span><span class="sxs-lookup"><span data-stu-id="9fe6e-130">Related topics</span></span>

* [<span data-ttu-id="9fe6e-131">Windows ストア サービスを使用した申請の作成と管理</span><span class="sxs-lookup"><span data-stu-id="9fe6e-131">Create and manage submissions using Windows Store services</span></span>](create-and-manage-submissions-using-windows-store-services.md)
