---
author: Xansky
description: このセクションの Java コード例を使用して、Microsoft Store 申請 API を使用したゲーム オプションおよびトレーラーの申請方法をご確認ください。
title: Java のコード例 - ゲーム オプションおよびトレーラーを含むアプリの申請
ms.author: mhopkins
ms.date: 07/10/2017
ms.topic: article
keywords: windows 10, uwp, Microsoft Store 申請 API, コード例, ゲーム オプション, トレーラー, 詳細な登録情報, Java
ms.localizationpriority: medium
ms.openlocfilehash: d6d64e317d2ff75be4aeb1f0e7df512287ae914a
ms.sourcegitcommit: 086001cffaf436e6e4324761d59bcc5e598c15ea
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/27/2018
ms.locfileid: "5692764"
---
# <a name="java-sample-app-submission-with-game-options-and-trailers"></a><span data-ttu-id="88afb-104">Java のコード例: ゲーム オプションおよびトレーラーを含むアプリの申請</span><span class="sxs-lookup"><span data-stu-id="88afb-104">Java sample: app submission with game options and trailers</span></span>

<span data-ttu-id="88afb-105">この記事では、次のタスクで [Microsoft Store 申請 API](create-and-manage-submissions-using-windows-store-services.md) を使用する方法を示す Java コード例を提供します。</span><span class="sxs-lookup"><span data-stu-id="88afb-105">This article provides Java code examples that demonstrate how to use the [Microsoft Store submission API](create-and-manage-submissions-using-windows-store-services.md) for these tasks:</span></span>

* <span data-ttu-id="88afb-106">Microsoft Store 申請 API で使用する Azure AD アクセス トークンを取得します。</span><span class="sxs-lookup"><span data-stu-id="88afb-106">Obtain an Azure AD access token to use with the Microsoft Store submission API.</span></span>
* <span data-ttu-id="88afb-107">アプリの申請の作成</span><span class="sxs-lookup"><span data-stu-id="88afb-107">Create an app submission</span></span>
* <span data-ttu-id="88afb-108">[ゲーム](manage-app-submissions.md#gaming-options-object)と[トレーラー](manage-app-submissions.md#trailer-object)の詳細な登録情報のオプションを含む、アプリの申請用のストア登録情報データを構成します。</span><span class="sxs-lookup"><span data-stu-id="88afb-108">Configure Store listing data for the app submission, including the [gaming](manage-app-submissions.md#gaming-options-object) and [trailers](manage-app-submissions.md#trailer-object) advanced listing options.</span></span>
* <span data-ttu-id="88afb-109">アプリの申請用のパッケージ、登録情報の画像、トレーラー ファイルが含まれた ZIP ファイルをアップロードします。</span><span class="sxs-lookup"><span data-stu-id="88afb-109">Upload the ZIP file containing the packages, listing images, and trailer files for the app submission.</span></span>
* <span data-ttu-id="88afb-110">アプリの申請をコミットします。</span><span class="sxs-lookup"><span data-stu-id="88afb-110">Commit the app submission.</span></span>

<span id="create-app-submission" />

## <a name="create-an-app-submission"></a><span data-ttu-id="88afb-111">アプリの申請の作成</span><span class="sxs-lookup"><span data-stu-id="88afb-111">Create an app submission</span></span>

<span data-ttu-id="88afb-112">```CreateAndSubmitSubmissionExample``` クラスが実装する ```main``` プログラムでは、他のサンプル メソッドを呼び出し、Microsoft Store 申請 API を使って、ゲーム オプションとトレーラーを含むアプリの申請を作成およびコミットします。</span><span class="sxs-lookup"><span data-stu-id="88afb-112">The ```CreateAndSubmitSubmissionExample``` class implements a ```main``` program that calls other example methods to use the Microsoft Store submission API to create and commit an app submission that contains game options and a trailer.</span></span> <span data-ttu-id="88afb-113">このコードを採用するには、次の手順を実行してください。</span><span class="sxs-lookup"><span data-stu-id="88afb-113">To adapt this code for your own use:</span></span>

* <span data-ttu-id="88afb-114">```tenantId``` 変数をアプリのテナント ID に割り当てて、```clientId``` 変数と ```clientSecret``` 変数をアプリのクライアント ID とキーに割り当てます。</span><span class="sxs-lookup"><span data-stu-id="88afb-114">Assign the ```tenantId``` variable to the tenant ID for your app, and assign the ```clientId``` and ```clientSecret``` variables to the client ID and key for your app.</span></span> <span data-ttu-id="88afb-115">詳しくは、[Azure AD アプリケーションを Windows デベロッパー センター アカウントに関連付ける方法](create-and-manage-submissions-using-windows-store-services.md#how-to-associate-an-azure-ad-application-with-your-windows-dev-center-account)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="88afb-115">For more information, see [How to associate an Azure AD application with your Windows Dev Center account](create-and-manage-submissions-using-windows-store-services.md#how-to-associate-an-azure-ad-application-with-your-windows-dev-center-account)</span></span>
* <span data-ttu-id="88afb-116">```applicationId``` 変数を、申請を作成するアプリの[ストア ID](in-app-purchases-and-trials.md#store-ids) に割り当てます。</span><span class="sxs-lookup"><span data-stu-id="88afb-116">Assign the ```applicationId``` variable to the [Store ID](in-app-purchases-and-trials.md#store-ids) of the app for which you want to create a submission.</span></span>

> [!div class="tabbedCodeSnippets"]
[!code[SubmissionApi](./code/StoreServicesExamples_SubmissionAdvancedListings/java/CreateAndSubmitSubmissionExample.java#L1-L313)]

<span id="token" />

## <a name="obtain-an-azure-ad-access-token"></a><span data-ttu-id="88afb-117">Azure AD アクセス トークンの取得</span><span class="sxs-lookup"><span data-stu-id="88afb-117">Obtain an Azure AD access token</span></span>

<span data-ttu-id="88afb-118">```DevCenterAccessTokenClient``` クラスでは、指定された ```tenantId```、```clientId```、```clientSecret``` の値を使って、Microsoft Store 申請 API で使用する Azure AD アクセス トークンを作成するヘルパー メソッドを定義します。</span><span class="sxs-lookup"><span data-stu-id="88afb-118">The ```DevCenterAccessTokenClient``` class defines a helper method that uses the your ```tenantId```, ```clientId``` and ```clientSecret``` values to create an Azure AD access token to use with the Microsoft Store submission API.</span></span>

> [!div class="tabbedCodeSnippets"]
[!code[SubmissionApi](./code/StoreServicesExamples_SubmissionAdvancedListings/java/DevCenterAccessTokenClient.java#L1-L69)]

<span id="utilities" />

## <a name="helper-methods-to-invoke-the-submission-api-and-upload-submission-files"></a><span data-ttu-id="88afb-119">申請 API を呼び出して申請ファイルをアップロードするヘルパー メソッド</span><span class="sxs-lookup"><span data-stu-id="88afb-119">Helper methods to invoke the submission API and upload submission files</span></span>

<span data-ttu-id="88afb-120">```DevCenterClient``` クラスでは、Microsoft Store 申請 API のさまざまなメソッドを呼び出して、アプリの申請用のパッケージ、登録情報の画像、トレーラー ファイルを含む ZIP ファイルをアップロードするヘルパー メソッドを定義します。</span><span class="sxs-lookup"><span data-stu-id="88afb-120">The ```DevCenterClient``` class defines helper methods that invoke a variety of methods in the Microsoft Store submission API and upload the ZIP file containing the packages, listing images, and trailer files for the app submission.</span></span>

> [!div class="tabbedCodeSnippets"]
[!code[SubmissionApi](./code/StoreServicesExamples_SubmissionAdvancedListings/java/DevCenterClient.java#L1-L224)]

## <a name="related-topics"></a><span data-ttu-id="88afb-121">関連トピック</span><span class="sxs-lookup"><span data-stu-id="88afb-121">Related topics</span></span>

* [<span data-ttu-id="88afb-122">Microsoft Store サービスを使用した申請の作成と管理</span><span class="sxs-lookup"><span data-stu-id="88afb-122">Create and manage submissions using Microsoft Store services</span></span>](create-and-manage-submissions-using-windows-store-services.md)
