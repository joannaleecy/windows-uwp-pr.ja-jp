---
description: このセクションの C# コード例を使用して、Microsoft Store 申請 API を使用したゲーム オプションおよびトレーラーの申請方法をご確認ください。
title: C# のコード例 - ゲーム オプションおよびトレーラーを含むアプリの申請
ms.date: 07/10/2017
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store 申請 API, コード例, ゲーム オプション, トレーラー, 詳細な登録情報, C#
ms.localizationpriority: medium
ms.openlocfilehash: 041f07fd6b24af3658bc9cfffe07117e4b353831
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/30/2018
ms.locfileid: "8323496"
---
# <a name="c-sample-app-submission-with-game-options-and-trailers"></a><span data-ttu-id="4800b-104">C# のコード例 : ゲーム オプションおよびトレーラーを含むアプリの申請</span><span class="sxs-lookup"><span data-stu-id="4800b-104">C\# sample: app submission with game options and trailers</span></span>

<span data-ttu-id="4800b-105">この記事では、次のタスクで [Microsoft Store 申請 API](create-and-manage-submissions-using-windows-store-services.md) を使用する方法を示す C# コード例を提供します。</span><span class="sxs-lookup"><span data-stu-id="4800b-105">This article provides C# code examples that demonstrate how to use the [Microsoft Store submission API](create-and-manage-submissions-using-windows-store-services.md) for these tasks:</span></span>

* <span data-ttu-id="4800b-106">Microsoft Store 申請 API で使用する Azure AD アクセス トークンを取得します。</span><span class="sxs-lookup"><span data-stu-id="4800b-106">Obtain an Azure AD access token to use with the Microsoft Store submission API.</span></span>
* <span data-ttu-id="4800b-107">アプリの申請の作成</span><span class="sxs-lookup"><span data-stu-id="4800b-107">Create an app submission</span></span>
* <span data-ttu-id="4800b-108">[ゲーム](manage-app-submissions.md#gaming-options-object)と[トレーラー](manage-app-submissions.md#trailer-object)の詳細な登録情報のオプションを含む、アプリの申請用のストア登録情報データを構成します。</span><span class="sxs-lookup"><span data-stu-id="4800b-108">Configure Store listing data for the app submission, including the [gaming](manage-app-submissions.md#gaming-options-object) and [trailers](manage-app-submissions.md#trailer-object) advanced listing options.</span></span>
* <span data-ttu-id="4800b-109">アプリの申請用のパッケージ、登録情報の画像、トレーラー ファイルが含まれた ZIP ファイルをアップロードします。</span><span class="sxs-lookup"><span data-stu-id="4800b-109">Upload the ZIP file containing the packages, listing images, and trailer files for the app submission.</span></span>
* <span data-ttu-id="4800b-110">アプリの申請をコミットします。</span><span class="sxs-lookup"><span data-stu-id="4800b-110">Commit the app submission.</span></span>

<span data-ttu-id="4800b-111">各例を確認して、それぞれが対応するタスクについて詳しく知ることができます。また、この記事のすべてのコード例を使って、コンソール アプリケーションをビルドすることもできます。</span><span class="sxs-lookup"><span data-stu-id="4800b-111">You can review each example to learn more about the task it demonstrates, or you can build all the code examples in this article into a console application.</span></span> <span data-ttu-id="4800b-112">サンプルをビルドするには、Visual Studio で **DevCenterApiSample** という名前の C# コンソール アプリケーションを作成し、各サンプルをプロジェクトの別のコード ファイルにコピーして、プロジェクトをビルドします。</span><span class="sxs-lookup"><span data-stu-id="4800b-112">To build the examples, create a C# console application named **DevCenterApiSample** in Visual Studio, copy each example to a separate code file in the project, and build the project.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="4800b-113">前提条件</span><span class="sxs-lookup"><span data-stu-id="4800b-113">Prerequisites</span></span>

<span data-ttu-id="4800b-114">これらの例には、次の要件があります。</span><span class="sxs-lookup"><span data-stu-id="4800b-114">These examples have the following requirements:</span></span>

* <span data-ttu-id="4800b-115">プロジェクトに System.Web アセンブリへの参照を追加します。</span><span class="sxs-lookup"><span data-stu-id="4800b-115">Add a reference to the System.Web assembly in your project.</span></span>
* <span data-ttu-id="4800b-116">Newtonsoft の [Newtonsoft.Json](http://www.newtonsoft.com/json) NuGet パッケージをプロジェクトにインストールします。</span><span class="sxs-lookup"><span data-stu-id="4800b-116">Install the [Newtonsoft.Json](http://www.newtonsoft.com/json) NuGet package from Newtonsoft to your project.</span></span>

<span id="create-app-submission" />

## <a name="create-an-app-submission"></a><span data-ttu-id="4800b-117">アプリの申請の作成</span><span class="sxs-lookup"><span data-stu-id="4800b-117">Create an app submission</span></span>

<span data-ttu-id="4800b-118">```CreateAndSubmitSubmissionExample``` クラスでは、```Execute``` というパブリック メソッドを定義します。このメソッドは、他のサンプル メソッドを呼び出し、Microsoft Store 申請 API を使って、ゲーム オプションとトレーラーを含むアプリの申請を作成およびコミットします。</span><span class="sxs-lookup"><span data-stu-id="4800b-118">The ```CreateAndSubmitSubmissionExample``` class defines a public ```Execute``` method that calls other example methods to use the Microsoft Store submission API to create and commit an app submission that contains game options and a trailer.</span></span> <span data-ttu-id="4800b-119">このコードを採用するには、次の手順を実行してください。</span><span class="sxs-lookup"><span data-stu-id="4800b-119">To adapt this code for your own use:</span></span>

* <span data-ttu-id="4800b-120">```tenantId``` 変数をアプリのテナント ID に割り当てて、```clientId``` 変数と ```clientSecret``` 変数をアプリのクライアント ID とキーに割り当てます。</span><span class="sxs-lookup"><span data-stu-id="4800b-120">Assign the ```tenantId``` variable to the tenant ID for your app, and assign the ```clientId``` and ```clientSecret``` variables to the client ID and key for your app.</span></span> <span data-ttu-id="4800b-121">詳細については、 [Azure AD アプリケーションをパートナー センター アカウントに関連付ける方法](create-and-manage-submissions-using-windows-store-services.md#how-to-associate-an-azure-ad-application-with-your-partner-center-account)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4800b-121">For more information, see [How to associate an Azure AD application with your Partner Center account](create-and-manage-submissions-using-windows-store-services.md#how-to-associate-an-azure-ad-application-with-your-partner-center-account)</span></span>
* <span data-ttu-id="4800b-122">```applicationId``` 変数を、申請を作成するアプリの[ストア ID](in-app-purchases-and-trials.md#store-ids) に割り当てます。</span><span class="sxs-lookup"><span data-stu-id="4800b-122">Assign the ```applicationId``` variable to the [Store ID](in-app-purchases-and-trials.md#store-ids) of the app for which you want to create a submission.</span></span>

> [!div class="tabbedCodeSnippets"]
[!code-cs[SubmissionApi](./code/StoreServicesExamples_SubmissionAdvancedListings/cs/CreateAndSubmitSubmissionExample.cs#CreateAndSubmitSubmissionExample)]

<span id="token" />

## <a name="obtain-an-azure-ad-access-token"></a><span data-ttu-id="4800b-123">Azure AD アクセス トークンの取得</span><span class="sxs-lookup"><span data-stu-id="4800b-123">Obtain an Azure AD access token</span></span>

<span data-ttu-id="4800b-124">```DevCenterAccessTokenClient``` クラスでは、指定された ```tenantId```、```clientId```、```clientSecret``` の値を使って、Microsoft Store 申請 API で使用する Azure AD アクセス トークンを作成するヘルパー メソッドを定義します。</span><span class="sxs-lookup"><span data-stu-id="4800b-124">The ```DevCenterAccessTokenClient``` class defines a helper method that uses the your ```tenantId```, ```clientId``` and ```clientSecret``` values to create an Azure AD access token to use with the Microsoft Store submission API.</span></span>

> [!div class="tabbedCodeSnippets"]
[!code-cs[SubmissionApi](./code/StoreServicesExamples_SubmissionAdvancedListings/cs/DevCenterAccessTokenClient.cs#DevCenterAccessTokenClient)]

<span id="utilities" />

## <a name="helper-methods-to-invoke-the-submission-api-and-upload-submission-files"></a><span data-ttu-id="4800b-125">申請 API を呼び出して申請ファイルをアップロードするヘルパー メソッド</span><span class="sxs-lookup"><span data-stu-id="4800b-125">Helper methods to invoke the submission API and upload submission files</span></span>

<span data-ttu-id="4800b-126">```DevCenterClient``` クラスでは、Microsoft Store 申請 API のさまざまなメソッドを呼び出して、アプリの申請用のパッケージ、登録情報の画像、トレーラー ファイルを含む ZIP ファイルをアップロードするヘルパー メソッドを定義します。</span><span class="sxs-lookup"><span data-stu-id="4800b-126">The ```DevCenterClient``` class defines helper methods that invoke a variety of methods in the Microsoft Store submission API and upload the ZIP file containing the packages, listing images, and trailer files for the app submission.</span></span>

> [!div class="tabbedCodeSnippets"]
[!code-cs[SubmissionApi](./code/StoreServicesExamples_SubmissionAdvancedListings/cs/DevCenterClient.cs#DevCenterClient)]

## <a name="related-topics"></a><span data-ttu-id="4800b-127">関連トピック</span><span class="sxs-lookup"><span data-stu-id="4800b-127">Related topics</span></span>

* [<span data-ttu-id="4800b-128">Microsoft Store サービスを使用した申請の作成と管理</span><span class="sxs-lookup"><span data-stu-id="4800b-128">Create and manage submissions using Microsoft Store services</span></span>](create-and-manage-submissions-using-windows-store-services.md)
