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
# <a name="python-sample-app-submission-with-game-options-and-trailers"></a><span data-ttu-id="e417a-104">Python のコード例: ゲーム オプションおよびトレーラーを含むアプリの申請</span><span class="sxs-lookup"><span data-stu-id="e417a-104">Python sample: app submission with game options and trailers</span></span>

<span data-ttu-id="e417a-105">この記事では、次のタスクの [Windows ストア申請 API](create-and-manage-submissions-using-windows-store-services.md) の使用方法を示す Python コード例を提供します。</span><span class="sxs-lookup"><span data-stu-id="e417a-105">This article provides Python code examples that demonstrate how to use the [Windows Store submission API](create-and-manage-submissions-using-windows-store-services.md) for these tasks:</span></span>

* <span data-ttu-id="e417a-106">Azure AD アクセス トークンを取得して、Windows ストア申請 API で使用します。</span><span class="sxs-lookup"><span data-stu-id="e417a-106">Obtain an Azure AD access token to use with the Windows Store submission API.</span></span>
* <span data-ttu-id="e417a-107">アプリの申請の作成</span><span class="sxs-lookup"><span data-stu-id="e417a-107">Create an app submission</span></span>
* <span data-ttu-id="e417a-108">[ゲーム](manage-app-submissions.md#gaming-options-object)と[トレーラー](manage-app-submissions.md#trailer-object)の高度な登録情報のオプションを含む、アプリの申請用のストア登録情報データを構成します。</span><span class="sxs-lookup"><span data-stu-id="e417a-108">Configure Store listing data for the app submission, including the [gaming](manage-app-submissions.md#gaming-options-object) and [trailers](manage-app-submissions.md#trailer-object) advanced listing options.</span></span>
* <span data-ttu-id="e417a-109">アプリの申請用のパッケージ、登録情報の画像、トレーラー ファイルが含まれた ZIP ファイルをアップロードします。</span><span class="sxs-lookup"><span data-stu-id="e417a-109">Upload the ZIP file containing the packages, listing images, and trailer files for the app submission.</span></span>
* <span data-ttu-id="e417a-110">アプリの申請をコミットします。</span><span class="sxs-lookup"><span data-stu-id="e417a-110">Commit the app submission.</span></span>

<span id="create-app-submission" />
## <a name="create-an-app-submission"></a><span data-ttu-id="e417a-111">アプリの申請の作成</span><span class="sxs-lookup"><span data-stu-id="e417a-111">Create an app submission</span></span>

<span data-ttu-id="e417a-112">このコードでは、他のサンプル クラスと関数を呼び出して、Windows ストア申請 API を使ってゲーム オプションとトレーラーを含むアプリの申請を作成、コミットします。</span><span class="sxs-lookup"><span data-stu-id="e417a-112">This code calls other example classes and functions to use the Windows Store submission API to create and commit an app submission that contains game options and a trailer.</span></span> <span data-ttu-id="e417a-113">このコードを採用するには、次の手順を実行してください。</span><span class="sxs-lookup"><span data-stu-id="e417a-113">To adapt this code for your own use:</span></span>

* <span data-ttu-id="e417a-114">```tenant``` 変数をアプリのテナント ID に割り当てて、```client``` 変数と ```secret``` 変数をアプリのクライアント ID とキーに割り当てます。</span><span class="sxs-lookup"><span data-stu-id="e417a-114">Assign the ```tenant``` variable to the tenant ID for your app, and assign the ```client``` and ```secret``` variables to the client ID and key for your app.</span></span> <span data-ttu-id="e417a-115">詳しくは、「[Azure AD アプリケーションを Windows デベロッパー センター アカウントに関連付ける方法](create-and-manage-submissions-using-windows-store-services.md#how-to-associate-an-azure-ad-application-with-your-windows-dev-center-account)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e417a-115">For more information, see [How to associate an Azure AD application with your Windows Dev Center account](create-and-manage-submissions-using-windows-store-services.md#how-to-associate-an-azure-ad-application-with-your-windows-dev-center-account)</span></span>
* <span data-ttu-id="e417a-116">```application_id``` 変数を、申請を作成するアプリの[ストア ID](in-app-purchases-and-trials.md#store_ids) に割り当てます。</span><span class="sxs-lookup"><span data-stu-id="e417a-116">Assign the ```application_id``` variable to the [Store ID](in-app-purchases-and-trials.md#store_ids) of the app for which you want to create a submission.</span></span>

> [!div class="tabbedCodeSnippets"]
[!code[SubmissionApi](./code/StoreServicesExamples_SubmissionAdvancedListings/python/CreateAndSubmitAppSubmissionExample.py#L1-L74)]

<span id="token" />
## <a name="obtain-an-azure-ad-access-token-and-invoke-the-submission-api"></a><span data-ttu-id="e417a-117">Azure AD アクセス トークンを取得して申請 API を呼び出す</span><span class="sxs-lookup"><span data-stu-id="e417a-117">Obtain an Azure AD access token and invoke the submission API</span></span>

<span data-ttu-id="e417a-118">次の例では、以下に示すクラスを定義します。</span><span class="sxs-lookup"><span data-stu-id="e417a-118">The following example defines the following classes:</span></span>

* <span data-ttu-id="e417a-119">```DevCenterAccessTokenClient``` クラスでは、```tenantId```、```clientId```、および ```clientSecret``` の値を使うヘルパー メソッドを定義して、Azure AD アクセス トークンを作成して Windows ストア申請 API で使用します。</span><span class="sxs-lookup"><span data-stu-id="e417a-119">The ```DevCenterAccessTokenClient``` class defines a helper method that uses the your ```tenantId```, ```clientId``` and ```clientSecret``` values to create an Azure AD access token to use with the Windows Store submission API.</span></span>
* <span data-ttu-id="e417a-120">```DevCenterClient``` クラスでは、Windows ストア申請 API のさまざまなメソッドを呼び出して、アプリの申請用のパッケージ、登録情報の画像、トレーラー ファイルを含む ZIP ファイルをアップロードするヘルパー メソッドを定義します。</span><span class="sxs-lookup"><span data-stu-id="e417a-120">The ```DevCenterClient``` class defines helper methods that invoke a variety of methods in the Windows Store submission API and upload the ZIP file containing the packages, listing images, and trailer files for the app submission.</span></span>

> [!div class="tabbedCodeSnippets"]
[!code[SubmissionApi](./code/StoreServicesExamples_SubmissionAdvancedListings/python/devcenterclient.py#L1-L126)]

<span id="token" />
## <a name="get-app-submission-listing-data"></a><span data-ttu-id="e417a-121">アプリの申請の登録情報データを取得する</span><span class="sxs-lookup"><span data-stu-id="e417a-121">Get app submission listing data</span></span>

<span data-ttu-id="e417a-122">次の例では、新しいサンプル アプリの申請用の JSON 形式の登録情報データを返すヘルパー関数を定義します。</span><span class="sxs-lookup"><span data-stu-id="e417a-122">The following example defines helper functions that return JSON-formatted listing data for a new sample app submission.</span></span>

> [!div class="tabbedCodeSnippets"]
[!code[SubmissionApi](./code/StoreServicesExamples_SubmissionAdvancedListings/python/submissiondatasamples.py#L1-L170)]

## <a name="related-topics"></a><span data-ttu-id="e417a-123">関連トピック</span><span class="sxs-lookup"><span data-stu-id="e417a-123">Related topics</span></span>

* [<span data-ttu-id="e417a-124">Windows ストア サービスを使用した申請の作成と管理</span><span class="sxs-lookup"><span data-stu-id="e417a-124">Create and manage submissions using Windows Store services</span></span>](create-and-manage-submissions-using-windows-store-services.md)
