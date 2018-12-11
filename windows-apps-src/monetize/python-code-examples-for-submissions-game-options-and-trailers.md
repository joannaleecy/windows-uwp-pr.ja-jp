---
description: このセクションの Python コード例を使用して、Microsoft Store 申請 API を使用したゲーム オプションおよびトレーラーの申請方法をご確認ください。
title: 'Python のコード例: ゲーム オプションおよびトレーラーを含むアプリの申請'
ms.date: 07/10/2017
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store 申請 API, コード例, ゲーム オプション, トレーラー, 詳細な登録情報, python
ms.localizationpriority: medium
ms.openlocfilehash: 59306e32fe1fcc68978c977b89934e64d85b8cc8
ms.sourcegitcommit: 8921a9cc0dd3e5665345ae8eca7ab7aeb83ccc6f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8880400"
---
# <a name="python-sample-app-submission-with-game-options-and-trailers"></a><span data-ttu-id="19580-104">Python のコード例: ゲーム オプションおよびトレーラーを含むアプリの申請</span><span class="sxs-lookup"><span data-stu-id="19580-104">Python sample: app submission with game options and trailers</span></span>

<span data-ttu-id="19580-105">この記事では、次のタスクで [Microsoft Store 申請 API](create-and-manage-submissions-using-windows-store-services.md) を使用する方法を示す Python コード例を提供します。</span><span class="sxs-lookup"><span data-stu-id="19580-105">This article provides Python code examples that demonstrate how to use the [Microsoft Store submission API](create-and-manage-submissions-using-windows-store-services.md) for these tasks:</span></span>

* <span data-ttu-id="19580-106">Microsoft Store 申請 API で使用する Azure AD アクセス トークンを取得します。</span><span class="sxs-lookup"><span data-stu-id="19580-106">Obtain an Azure AD access token to use with the Microsoft Store submission API.</span></span>
* <span data-ttu-id="19580-107">アプリの申請の作成</span><span class="sxs-lookup"><span data-stu-id="19580-107">Create an app submission</span></span>
* <span data-ttu-id="19580-108">[ゲーム](manage-app-submissions.md#gaming-options-object)と[トレーラー](manage-app-submissions.md#trailer-object)の詳細な登録情報のオプションを含む、アプリの申請用のストア登録情報データを構成します。</span><span class="sxs-lookup"><span data-stu-id="19580-108">Configure Store listing data for the app submission, including the [gaming](manage-app-submissions.md#gaming-options-object) and [trailers](manage-app-submissions.md#trailer-object) advanced listing options.</span></span>
* <span data-ttu-id="19580-109">アプリの申請用のパッケージ、登録情報の画像、トレーラー ファイルが含まれた ZIP ファイルをアップロードします。</span><span class="sxs-lookup"><span data-stu-id="19580-109">Upload the ZIP file containing the packages, listing images, and trailer files for the app submission.</span></span>
* <span data-ttu-id="19580-110">アプリの申請をコミットします。</span><span class="sxs-lookup"><span data-stu-id="19580-110">Commit the app submission.</span></span>

<span id="create-app-submission" />

## <a name="create-an-app-submission"></a><span data-ttu-id="19580-111">アプリの申請の作成</span><span class="sxs-lookup"><span data-stu-id="19580-111">Create an app submission</span></span>

<span data-ttu-id="19580-112">このコードでは、他のサンプル クラスと関数を呼び出して、Microsoft Store 申請 API を使ってゲーム オプションとトレーラーを含むアプリの申請を作成し、コミットします。</span><span class="sxs-lookup"><span data-stu-id="19580-112">This code calls other example classes and functions to use the Microsoft Store submission API to create and commit an app submission that contains game options and a trailer.</span></span> <span data-ttu-id="19580-113">このコードを採用するには、次の手順を実行してください。</span><span class="sxs-lookup"><span data-stu-id="19580-113">To adapt this code for your own use:</span></span>

* <span data-ttu-id="19580-114">```tenant``` 変数をアプリのテナント ID に割り当てて、```client``` 変数と ```secret``` 変数をアプリのクライアント ID とキーに割り当てます。</span><span class="sxs-lookup"><span data-stu-id="19580-114">Assign the ```tenant``` variable to the tenant ID for your app, and assign the ```client``` and ```secret``` variables to the client ID and key for your app.</span></span> <span data-ttu-id="19580-115">詳細については、 [Azure AD アプリケーションをパートナー センター アカウントに関連付ける方法](create-and-manage-submissions-using-windows-store-services.md#how-to-associate-an-azure-ad-application-with-your-partner-center-account)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="19580-115">For more information, see [How to associate an Azure AD application with your Partner Center account](create-and-manage-submissions-using-windows-store-services.md#how-to-associate-an-azure-ad-application-with-your-partner-center-account)</span></span>
* <span data-ttu-id="19580-116">```application_id``` 変数を、申請を作成するアプリの[ストア ID](in-app-purchases-and-trials.md#store-ids) に割り当てます。</span><span class="sxs-lookup"><span data-stu-id="19580-116">Assign the ```application_id``` variable to the [Store ID](in-app-purchases-and-trials.md#store-ids) of the app for which you want to create a submission.</span></span>

> [!div class="tabbedCodeSnippets"]
[!code[SubmissionApi](./code/StoreServicesExamples_SubmissionAdvancedListings/python/CreateAndSubmitAppSubmissionExample.py#L1-L74)]

<span id="token" />

## <a name="obtain-an-azure-ad-access-token-and-invoke-the-submission-api"></a><span data-ttu-id="19580-117">Azure AD アクセス トークンを取得して申請 API を呼び出す</span><span class="sxs-lookup"><span data-stu-id="19580-117">Obtain an Azure AD access token and invoke the submission API</span></span>

<span data-ttu-id="19580-118">次の例では、以下に示すクラスを定義します。</span><span class="sxs-lookup"><span data-stu-id="19580-118">The following example defines the following classes:</span></span>

* <span data-ttu-id="19580-119">```DevCenterAccessTokenClient``` クラスでは、指定された ```tenantId```、```clientId```、```clientSecret``` の値を使って、Microsoft Store 申請 API で使用する Azure AD アクセス トークンを作成するヘルパー メソッドを定義します。</span><span class="sxs-lookup"><span data-stu-id="19580-119">The ```DevCenterAccessTokenClient``` class defines a helper method that uses the your ```tenantId```, ```clientId``` and ```clientSecret``` values to create an Azure AD access token to use with the Microsoft Store submission API.</span></span>
* <span data-ttu-id="19580-120">```DevCenterClient``` クラスでは、Microsoft Store 申請 API のさまざまなメソッドを呼び出して、アプリの申請用のパッケージ、登録情報の画像、トレーラー ファイルを含む ZIP ファイルをアップロードするヘルパー メソッドを定義します。</span><span class="sxs-lookup"><span data-stu-id="19580-120">The ```DevCenterClient``` class defines helper methods that invoke a variety of methods in the Microsoft Store submission API and upload the ZIP file containing the packages, listing images, and trailer files for the app submission.</span></span>

> [!div class="tabbedCodeSnippets"]
[!code[SubmissionApi](./code/StoreServicesExamples_SubmissionAdvancedListings/python/devcenterclient.py#L1-L126)]

<span id="token" />

## <a name="get-app-submission-listing-data"></a><span data-ttu-id="19580-121">アプリの申請の登録情報データを取得する</span><span class="sxs-lookup"><span data-stu-id="19580-121">Get app submission listing data</span></span>

<span data-ttu-id="19580-122">次の例では、新しいサンプル アプリの申請用の JSON 形式の登録情報データを返すヘルパー関数を定義します。</span><span class="sxs-lookup"><span data-stu-id="19580-122">The following example defines helper functions that return JSON-formatted listing data for a new sample app submission.</span></span>

> [!div class="tabbedCodeSnippets"]
[!code[SubmissionApi](./code/StoreServicesExamples_SubmissionAdvancedListings/python/submissiondatasamples.py#L1-L170)]

## <a name="related-topics"></a><span data-ttu-id="19580-123">関連トピック</span><span class="sxs-lookup"><span data-stu-id="19580-123">Related topics</span></span>

* [<span data-ttu-id="19580-124">Microsoft Store サービスを使用した申請の作成と管理</span><span class="sxs-lookup"><span data-stu-id="19580-124">Create and manage submissions using Microsoft Store services</span></span>](create-and-manage-submissions-using-windows-store-services.md)
