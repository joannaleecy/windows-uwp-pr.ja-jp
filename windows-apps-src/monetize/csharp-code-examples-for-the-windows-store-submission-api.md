---
ms.assetid: FABA802F-9CB2-4894-9848-9BB040F9851F
description: このセクションの C# コード例を使用して、Microsoft Store 申請 API を使用する方法をご確認ください。
title: C# のコード例 - アプリ、アドオン、およびフライトの申請
ms.date: 08/03/2017
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store 申請 API, コード例, C#
ms.localizationpriority: medium
ms.openlocfilehash: 19cfec890d6a434a392ce08257cad6bbeee4cda1
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57627517"
---
# <a name="c-sample-submissions-for-apps-add-ons-and-flights"></a><span data-ttu-id="8089d-104">C\#サンプル: アプリ、アドオン、および便の送信</span><span class="sxs-lookup"><span data-stu-id="8089d-104">C\# sample: submissions for apps, add-ons, and flights</span></span>

<span data-ttu-id="8089d-105">この記事では、次のタスクで [Microsoft Store 申請 API](create-and-manage-submissions-using-windows-store-services.md) を使用する方法を示す C# コード例を提供します。</span><span class="sxs-lookup"><span data-stu-id="8089d-105">This article provides C# code examples that demonstrate how to use the [Microsoft Store submission API](create-and-manage-submissions-using-windows-store-services.md) for these tasks:</span></span>

* [<span data-ttu-id="8089d-106">アプリの提出を作成します。</span><span class="sxs-lookup"><span data-stu-id="8089d-106">Create an app submission</span></span>](#create-app-submission)
* [<span data-ttu-id="8089d-107">アドオンを提出を作成します。</span><span class="sxs-lookup"><span data-stu-id="8089d-107">Create an add-on submission</span></span>](#create-add-on-submission)
* [<span data-ttu-id="8089d-108">アドオンを申請を更新します。</span><span class="sxs-lookup"><span data-stu-id="8089d-108">Update an add-on submission</span></span>](#update-add-on-submission)
* [<span data-ttu-id="8089d-109">パッケージのフライトの提出を作成します。</span><span class="sxs-lookup"><span data-stu-id="8089d-109">Create a package flight submission</span></span>](#create-flight-submission)

<span data-ttu-id="8089d-110">各例を確認して、それぞれが対応するタスクについて詳しく知ることができます。また、この記事のすべてのコード例を使って、コンソール アプリケーションをビルドすることもできます。</span><span class="sxs-lookup"><span data-stu-id="8089d-110">You can review each example to learn more about the task it demonstrates, or you can build all the code examples in this article into a console application.</span></span> <span data-ttu-id="8089d-111">サンプルをビルドするには、Visual Studio で**DeveloperApiCSharpSample** という名前の C# コンソール アプリケーションを作成し、各サンプルをプロジェクトの別のコード ファイルにコピーして、プロジェクトをビルドします。</span><span class="sxs-lookup"><span data-stu-id="8089d-111">To build the examples, create a C# console application named **DeveloperApiCSharpSample** in Visual Studio, copy each example to a separate code file in the project, and build the project.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="8089d-112">前提条件</span><span class="sxs-lookup"><span data-stu-id="8089d-112">Prerequisites</span></span>

<span data-ttu-id="8089d-113">以下の例では、次のライブラリを使用します。</span><span class="sxs-lookup"><span data-stu-id="8089d-113">These examples use the following libraries:</span></span>

* <span data-ttu-id="8089d-114">Microsoft.WindowsAzure.Storage.dll。</span><span class="sxs-lookup"><span data-stu-id="8089d-114">Microsoft.WindowsAzure.Storage.dll.</span></span> <span data-ttu-id="8089d-115">このライブラリは、[Azure SDK for .NET](https://azure.microsoft.com/downloads/) に含まれています。または [WindowsAzure.Storage NuGet パッケージ](https://www.nuget.org/packages/WindowsAzure.Storage)をインストールすると入手できます。</span><span class="sxs-lookup"><span data-stu-id="8089d-115">This library is available in the [Azure SDK for .NET](https://azure.microsoft.com/downloads/), or you can obtain it by installing the [WindowsAzure.Storage NuGet package](https://www.nuget.org/packages/WindowsAzure.Storage).</span></span>
* <span data-ttu-id="8089d-116">Newtonsoft の [Newtonsoft.Json](https://www.newtonsoft.com/json) NuGet パッケージ。</span><span class="sxs-lookup"><span data-stu-id="8089d-116">[Newtonsoft.Json](https://www.newtonsoft.com/json) NuGet package from Newtonsoft.</span></span>

## <a name="main-program"></a><span data-ttu-id="8089d-117">メイン プログラム</span><span class="sxs-lookup"><span data-stu-id="8089d-117">Main program</span></span>

<span data-ttu-id="8089d-118">次の例では、コマンド ライン プログラムを実装し、この記事の他のサンプル メソッドを呼び出して、Microsoft Store 申請 API のさまざまな使用方法を示します。</span><span class="sxs-lookup"><span data-stu-id="8089d-118">The following example implements a command line program that calls the other example methods in this article to demonstrate different ways to use the Microsoft Store submission API.</span></span> <span data-ttu-id="8089d-119">このプログラムを採用するには、次の手順を実行してください。</span><span class="sxs-lookup"><span data-stu-id="8089d-119">To adapt this program for your own use:</span></span>

* <span data-ttu-id="8089d-120">```ApplicationId```、```InAppProductId```、および ```FlightId``` プロパティを、管理するアプリ、アドオン、およびパッケージ フライトの ID に割り当てます。</span><span class="sxs-lookup"><span data-stu-id="8089d-120">Assign the ```ApplicationId```, ```InAppProductId```, and ```FlightId``` properties to the ID of the app, add-on, and package flight you want to manage.</span></span>
* <span data-ttu-id="8089d-121">```ClientId``` および ```ClientSecret``` プロパティをアプリのクライアント ID とキーに割り当て、```TokenEndpoint``` URL 内の文字列 *tenantid* をアプリのテナント ID に置き換えます。</span><span class="sxs-lookup"><span data-stu-id="8089d-121">Assign the ```ClientId``` and ```ClientSecret``` properties to the client ID and key for your app, and replace the *tenantid* string in the ```TokenEndpoint``` URL with the tenant ID for your app.</span></span> <span data-ttu-id="8089d-122">詳細については、次を参照してください[に Azure AD アプリケーションを、パートナー センター アカウントに関連付ける方法。](create-and-manage-submissions-using-windows-store-services.md#how-to-associate-an-azure-ad-application-with-your-partner-center-account)</span><span class="sxs-lookup"><span data-stu-id="8089d-122">For more information, see [How to associate an Azure AD application with your Partner Center account](create-and-manage-submissions-using-windows-store-services.md#how-to-associate-an-azure-ad-application-with-your-partner-center-account)</span></span>

> [!div class="tabbedCodeSnippets"]
[!code-cs[SubmissionApi](./code/StoreServicesExamples_Submission/cs/Program.cs#Main)]

<span id="clientconfiguration" />

## <a name="clientconfiguration-helper-class"></a><span data-ttu-id="8089d-123">ClientConfiguration ヘルパー クラス</span><span class="sxs-lookup"><span data-stu-id="8089d-123">ClientConfiguration helper class</span></span>

<span data-ttu-id="8089d-124">サンプル アプリでは、Microsoft Store 申請 API を使用する各サンプル メソッドに Azure Active Directory データとアプリ データを渡すために、```ClientConfiguration``` ヘルパー クラスが使われています。</span><span class="sxs-lookup"><span data-stu-id="8089d-124">The sample app uses the ```ClientConfiguration``` helper class to pass Azure Active Directory data and app data to each of the example methods that use the Microsoft Store submission API.</span></span>

> [!div class="tabbedCodeSnippets"]
[!code-cs[SubmissionApi](./code/StoreServicesExamples_Submission/cs/ClientConfiguration.cs#ClientConfiguration)]

<span id="create-app-submission" />

## <a name="create-an-app-submission"></a><span data-ttu-id="8089d-125">アプリの申請の作成</span><span class="sxs-lookup"><span data-stu-id="8089d-125">Create an app submission</span></span>

<span data-ttu-id="8089d-126">次の例では、Microsoft Store 申請 API のいくつかのメソッドを使ってアプリの申請を更新するクラスを実装します。</span><span class="sxs-lookup"><span data-stu-id="8089d-126">The following example implements a class that uses several methods in the Microsoft Store submission API to update an app submission.</span></span> <span data-ttu-id="8089d-127">```RunAppSubmissionUpdateSample```クラスのメソッドは、パブリッシュされた最後の送信の複製として新しい送信を作成し、更新し、パートナー センターに複製された送信をコミットします。</span><span class="sxs-lookup"><span data-stu-id="8089d-127">The ```RunAppSubmissionUpdateSample``` method in the class creates a new submission as a clone of the last published submission, and then it updates and commits the cloned submission to Partner Center.</span></span> <span data-ttu-id="8089d-128">具体的には、```RunAppSubmissionUpdateSample``` メソッドは次のタスクを実行します。</span><span class="sxs-lookup"><span data-stu-id="8089d-128">Specifically, the ```RunAppSubmissionUpdateSample``` method performs these tasks:</span></span>

1. <span data-ttu-id="8089d-129">まず、メソッドは[指定されたアプリのデータを取得](get-an-app.md)します。</span><span class="sxs-lookup"><span data-stu-id="8089d-129">To begin, the method [gets data for the specified app](get-an-app.md).</span></span>
2. <span data-ttu-id="8089d-130">次に、[アプリの保留中の申請を削除](delete-an-app-submission.md)します (存在する場合)。</span><span class="sxs-lookup"><span data-stu-id="8089d-130">Next, it [deletes the pending submission for the app](delete-an-app-submission.md), if one exists.</span></span>
3. <span data-ttu-id="8089d-131">その後、[アプリの新しい申請を作成](create-an-app-submission.md)します (新しい申請は、最後に公開された申請のコピーです)。</span><span class="sxs-lookup"><span data-stu-id="8089d-131">It then [creates a new submission for the app](create-an-app-submission.md) (the new submission is a copy of the last published submission).</span></span>
4. <span data-ttu-id="8089d-132">新しい申請の詳細を変更し、申請の新しいパッケージを Azure Blob Storage にアップロードします。</span><span class="sxs-lookup"><span data-stu-id="8089d-132">It changes some details for the new submission and upload a new package for the submission to Azure Blob storage.</span></span>
5. <span data-ttu-id="8089d-133">次に、その[更新](update-an-app-submission.md)し[コミット](commit-an-app-submission.md)パートナー センターに新しい送信します。</span><span class="sxs-lookup"><span data-stu-id="8089d-133">Next, it [updates](update-an-app-submission.md) and then [commits](commit-an-app-submission.md) the new submission to Partner Center.</span></span>
6. <span data-ttu-id="8089d-134">最後に、申請が正常にコミットされるまで、定期的に[新しい申請の状態をチェック](get-status-for-an-app-submission.md)します。</span><span class="sxs-lookup"><span data-stu-id="8089d-134">Finally, it periodically [checks the status of the new submission](get-status-for-an-app-submission.md) until the submission is successfully committed.</span></span>

> [!div class="tabbedCodeSnippets"]
[!code-cs[SubmissionApi](./code/StoreServicesExamples_Submission/cs/AppSubmissionUpdateSample.cs#AppSubmissionUpdateSample)]

<span id="create-add-on-submission" />

## <a name="create-an-add-on-submission"></a><span data-ttu-id="8089d-135">アドオンの申請の作成</span><span class="sxs-lookup"><span data-stu-id="8089d-135">Create an add-on submission</span></span>

<span data-ttu-id="8089d-136">次の例では、Microsoft Store 申請 API のいくつかのメソッドを使って新しいアドオンの申請を作成するクラスを実装します。</span><span class="sxs-lookup"><span data-stu-id="8089d-136">The following example implements a class that uses several methods in the Microsoft Store submission API to create a new add-on submission.</span></span> <span data-ttu-id="8089d-137">クラスの ```RunInAppProductSubmissionCreateSample``` メソッドは、次のタスクを実行します。</span><span class="sxs-lookup"><span data-stu-id="8089d-137">The ```RunInAppProductSubmissionCreateSample``` method in the class performs these tasks:</span></span>

1. <span data-ttu-id="8089d-138">まず、メソッドは[新しアドオンを作成](create-an-add-on.md)します。</span><span class="sxs-lookup"><span data-stu-id="8089d-138">To begin, the method [creates a new add-on](create-an-add-on.md).</span></span>
2. <span data-ttu-id="8089d-139">次に、その[アドオンの新しい申請を作成](create-an-add-on-submission.md)します。</span><span class="sxs-lookup"><span data-stu-id="8089d-139">Next, it [creates a new submission for the add-on](create-an-add-on-submission.md).</span></span>
3. <span data-ttu-id="8089d-140">申請のアイコンが含まれた ZIP アーカイブを Azure Blob Storage にアップロードします。</span><span class="sxs-lookup"><span data-stu-id="8089d-140">It uploads a ZIP archive that contains icons for the submission to Azure Blob storage.</span></span>
4. <span data-ttu-id="8089d-141">次に、その[パートナー センターに新しい送信コミット](commit-an-add-on-submission.md)します。</span><span class="sxs-lookup"><span data-stu-id="8089d-141">Next, it [commits the new submission to Partner Center](commit-an-add-on-submission.md).</span></span>
5. <span data-ttu-id="8089d-142">最後に、申請が正常にコミットされるまで、定期的に[新しい申請の状態をチェック](get-status-for-an-add-on-submission.md)します。</span><span class="sxs-lookup"><span data-stu-id="8089d-142">Finally, it periodically [checks the status of the new submission](get-status-for-an-add-on-submission.md) until the submission is successfully committed.</span></span>

> [!div class="tabbedCodeSnippets"]
[!code-cs[SubmissionApi](./code/StoreServicesExamples_Submission/cs/InAppProductSubmissionCreateSample.cs#InAppProductSubmissionCreateSample)]

<span id="update-add-on-submission" />

## <a name="update-an-add-on-submission"></a><span data-ttu-id="8089d-143">アドオンの申請の更新</span><span class="sxs-lookup"><span data-stu-id="8089d-143">Update an add-on submission</span></span>

<span data-ttu-id="8089d-144">次の例では、Microsoft Store 申請 API のいくつかのメソッドを使って既存のアドオンの申請を更新するクラスを実装します。</span><span class="sxs-lookup"><span data-stu-id="8089d-144">The following example implements a class that uses several methods in the Microsoft Store submission API to update an existing add-on submission.</span></span> <span data-ttu-id="8089d-145">```RunInAppProductSubmissionUpdateSample```クラスのメソッドは、パブリッシュされた最後の送信の複製として新しい送信を作成し、更新し、パートナー センターに複製された送信をコミットします。</span><span class="sxs-lookup"><span data-stu-id="8089d-145">The ```RunInAppProductSubmissionUpdateSample``` method in the class creates a new submission as a clone of the last published submission, and then it updates and commits the cloned submission to Partner Center.</span></span> <span data-ttu-id="8089d-146">具体的には、```RunInAppProductSubmissionUpdateSample``` メソッドは次のタスクを実行します。</span><span class="sxs-lookup"><span data-stu-id="8089d-146">Specifically, the ```RunInAppProductSubmissionUpdateSample``` method performs these tasks:</span></span>

1. <span data-ttu-id="8089d-147">まず、メソッドは[指定されたアドオンのデータを取得](get-an-add-on.md)します。</span><span class="sxs-lookup"><span data-stu-id="8089d-147">To begin, the method [gets data for the specified add-on](get-an-add-on.md).</span></span>
2. <span data-ttu-id="8089d-148">次に、[アドオンの保留中の申請を削除](delete-an-add-on-submission.md)します (存在する場合)。</span><span class="sxs-lookup"><span data-stu-id="8089d-148">Next, it [deletes the pending submission for the add-on](delete-an-add-on-submission.md), if one exists.</span></span>
3. <span data-ttu-id="8089d-149">その後、[アドオンの新しい申請を作成](create-an-add-on-submission.md)します (新しい申請は、最後に公開された申請のコピーです)。</span><span class="sxs-lookup"><span data-stu-id="8089d-149">It then [creates a new submission for the add-on](create-an-add-on-submission.md) (the new submission is a copy of the last published submission).</span></span>
5. <span data-ttu-id="8089d-150">次に、その[更新](update-an-add-on-submission.md)し[コミット](commit-an-add-on-submission.md)パートナー センターに新しい送信します。</span><span class="sxs-lookup"><span data-stu-id="8089d-150">Next, it [updates](update-an-add-on-submission.md) and then [commits](commit-an-add-on-submission.md) the new submission to Partner Center.</span></span>
6. <span data-ttu-id="8089d-151">最後に、申請が正常にコミットされるまで、定期的に[新しい申請の状態をチェック](get-status-for-an-add-on-submission.md)します。</span><span class="sxs-lookup"><span data-stu-id="8089d-151">Finally, it periodically [checks the status of the new submission](get-status-for-an-add-on-submission.md) until the submission is successfully committed.</span></span>

> [!div class="tabbedCodeSnippets"]
[!code-cs[SubmissionApi](./code/StoreServicesExamples_Submission/cs/InAppProductSubmissionUpdateSample.cs#InAppProductSubmissionUpdateSample)]

<span id="create-flight-submission" />

## <a name="create-a-package-flight-submission"></a><span data-ttu-id="8089d-152">パッケージ フライトの申請の作成</span><span class="sxs-lookup"><span data-stu-id="8089d-152">Create a package flight submission</span></span>

<span data-ttu-id="8089d-153">次の例では、Microsoft Store 申請 API のいくつかのメソッドを使ってパッケージ フライトの申請を更新するクラスを実装します。</span><span class="sxs-lookup"><span data-stu-id="8089d-153">The following example implements a class that uses several methods in the Microsoft Store submission API to update a package flight submission.</span></span> <span data-ttu-id="8089d-154">```RunFlightSubmissionUpdateSample```クラスのメソッドは、パブリッシュされた最後の送信の複製として新しい送信を作成し、更新し、パートナー センターに複製された送信をコミットします。</span><span class="sxs-lookup"><span data-stu-id="8089d-154">The ```RunFlightSubmissionUpdateSample``` method in the class creates a new submission as a clone of the last published submission, and then it updates and commits the cloned submission to Partner Center.</span></span> <span data-ttu-id="8089d-155">具体的には、```RunFlightSubmissionUpdateSample``` メソッドは次のタスクを実行します。</span><span class="sxs-lookup"><span data-stu-id="8089d-155">Specifically, the ```RunFlightSubmissionUpdateSample``` method performs these tasks:</span></span>

1. <span data-ttu-id="8089d-156">まず、メソッドは[指定されたパッケージ フライトのデータを取得](get-a-flight.md)します。</span><span class="sxs-lookup"><span data-stu-id="8089d-156">To begin, the method [gets data for the specified package flight](get-a-flight.md).</span></span>
2. <span data-ttu-id="8089d-157">次に、[パッケージ フライトの保留中の申請を削除](delete-a-flight-submission.md)します (存在する場合)。</span><span class="sxs-lookup"><span data-stu-id="8089d-157">Next, it [deletes the pending submission for the package flight](delete-a-flight-submission.md), if one exists.</span></span>
3. <span data-ttu-id="8089d-158">その後、[パッケージ フライトの新しい申請を作成](create-a-flight-submission.md)します (新しい申請は、最後に公開された申請のコピーです)。</span><span class="sxs-lookup"><span data-stu-id="8089d-158">It then [creates a new submission for the package flight](create-a-flight-submission.md) (the new submission is a copy of the last published submission).</span></span>
4. <span data-ttu-id="8089d-159">申請の新しいパッケージを Azure Blob Storage にアップロードします。</span><span class="sxs-lookup"><span data-stu-id="8089d-159">It uploads a new package for the submission to Azure Blob storage.</span></span>
5. <span data-ttu-id="8089d-160">次に、その[更新](update-a-flight-submission.md)し[コミット](commit-a-flight-submission.md)パートナー センターに新しい送信します。</span><span class="sxs-lookup"><span data-stu-id="8089d-160">Next, it [updates](update-a-flight-submission.md) and then [commits](commit-a-flight-submission.md) the new submission to Partner Center.</span></span>
6. <span data-ttu-id="8089d-161">最後に、申請が正常にコミットされるまで、定期的に[新しい申請の状態をチェック](get-status-for-a-flight-submission.md)します。</span><span class="sxs-lookup"><span data-stu-id="8089d-161">Finally, it periodically [checks the status of the new submission](get-status-for-a-flight-submission.md) until the submission is successfully committed.</span></span>

> [!div class="tabbedCodeSnippets"]
[!code-cs[SubmissionApi](./code/StoreServicesExamples_Submission/cs/FlightSubmissionUpdateSample.cs#FlightSubmissionUpdateSample)]

<span id="ingestionclient" />

## <a name="ingestionclient-helper-class"></a><span data-ttu-id="8089d-162">IngestionClient ヘルパー クラス</span><span class="sxs-lookup"><span data-stu-id="8089d-162">IngestionClient helper class</span></span>

<span data-ttu-id="8089d-163">```IngestionClient``` クラスは、サンプル アプリのその他のメソッドが使用して、次のタスクを実行するヘルパー メソッドを提供します。</span><span class="sxs-lookup"><span data-stu-id="8089d-163">The ```IngestionClient``` class provides helper methods that are used by other methods in the sample app to perform the following tasks:</span></span>

* <span data-ttu-id="8089d-164">Microsoft Store 申請 API のメソッドの呼び出しに使用できる [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="8089d-164">[Obtain an Azure AD access token](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token) that can be used to call methods in the Microsoft Store submission API.</span></span> <span data-ttu-id="8089d-165">トークンを取得した後、Microsoft Store 申請 API の呼び出しでこのトークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="8089d-165">After you obtain a token, you have 60 minutes to use this token in calls to the Microsoft Store submission API before the token expires.</span></span> <span data-ttu-id="8089d-166">トークンの有効期限が切れた後は、新しいトークンを生成できます。</span><span class="sxs-lookup"><span data-stu-id="8089d-166">After the token expires, you can generate a new token.</span></span>
* <span data-ttu-id="8089d-167">アプリまたはアドオンの申請の新しいアセットが含まれた ZIP アーカイブを Azure Blob Storage にアップロードします。</span><span class="sxs-lookup"><span data-stu-id="8089d-167">Upload a ZIP archive containing new assets for an app or add-on submission to Azure Blob storage.</span></span> <span data-ttu-id="8089d-168">アプリとアドオンの申請のために Azure Blob Storage に ZIP アーカイブをアップロードする方法について詳しくは、「[アプリの申請の作成](manage-app-submissions.md#create-an-app-submission)」と「[アドオンの申請の作成](manage-add-on-submissions.md#create-an-add-on-submission)」の関連する手順をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8089d-168">For more information about uploading a ZIP archive to Azure Blob storage for app and add-on submissions, see the relevant instructions in [Create an app submission](manage-app-submissions.md#create-an-app-submission) and [Create an add-on submission](manage-add-on-submissions.md#create-an-add-on-submission).</span></span>
* <span data-ttu-id="8089d-169">Microsoft Store 申請 API の HTTP 要求を処理します。</span><span class="sxs-lookup"><span data-stu-id="8089d-169">Process the HTTP requests for the Microsoft Store submission API.</span></span>

> [!div class="tabbedCodeSnippets"]
[!code-cs[SubmissionApi](./code/StoreServicesExamples_Submission/cs/IngestionClient.cs#IngestionClient)]

## <a name="related-topics"></a><span data-ttu-id="8089d-170">関連トピック</span><span class="sxs-lookup"><span data-stu-id="8089d-170">Related topics</span></span>

* [<span data-ttu-id="8089d-171">作成し、Microsoft Store サービスを使用して送信の管理</span><span class="sxs-lookup"><span data-stu-id="8089d-171">Create and manage submissions using Microsoft Store services</span></span>](create-and-manage-submissions-using-windows-store-services.md)
