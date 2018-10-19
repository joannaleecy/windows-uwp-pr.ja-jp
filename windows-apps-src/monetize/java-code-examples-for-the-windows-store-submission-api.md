---
author: Xansky
ms.assetid: 4920D262-B810-409E-BA3A-F68AADF1B1BC
description: このセクションの Java コード例を使用して、Microsoft Store 申請 API を使用する方法をご確認ください。
title: Java のコード例 - アプリ、アドオン、およびフライトの申請
ms.author: mhopkins
ms.date: 07/10/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, Microsoft Store 申請 API, コード例, Java
ms.localizationpriority: medium
ms.openlocfilehash: e058e456b16b5415984e6cf8de0a0fdb68159f07
ms.sourcegitcommit: e16c9845b52d5bd43fc02bbe92296a9682d96926
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/19/2018
ms.locfileid: "4949005"
---
# <a name="java-sample-submissions-for-apps-add-ons-and-flights"></a><span data-ttu-id="b8cdc-104">Java のコード例: アプリ、アドオン、およびフライトの申請</span><span class="sxs-lookup"><span data-stu-id="b8cdc-104">Java sample: submissions for apps, add-ons, and flights</span></span>

<span data-ttu-id="b8cdc-105">この記事では、次のタスクで [Microsoft Store 申請 API](create-and-manage-submissions-using-windows-store-services.md) を使用する方法を示す Java コード例を提供します。</span><span class="sxs-lookup"><span data-stu-id="b8cdc-105">This article provides Java code examples that demonstrate how to use the [Microsoft Store submission API](create-and-manage-submissions-using-windows-store-services.md) for these tasks:</span></span>

* [<span data-ttu-id="b8cdc-106">Azure AD アクセス トークンの取得</span><span class="sxs-lookup"><span data-stu-id="b8cdc-106">Obtain an Azure AD access token</span></span>](#token)
* [<span data-ttu-id="b8cdc-107">アドオンの作成</span><span class="sxs-lookup"><span data-stu-id="b8cdc-107">Create an add-on</span></span>](#create-add-on)
* [<span data-ttu-id="b8cdc-108">パッケージ フライトの作成</span><span class="sxs-lookup"><span data-stu-id="b8cdc-108">Create a package flight</span></span>](#create-package-flight)
* [<span data-ttu-id="b8cdc-109">アプリの申請の作成</span><span class="sxs-lookup"><span data-stu-id="b8cdc-109">Create an app submission</span></span>](#create-app-submission)
* [<span data-ttu-id="b8cdc-110">アドオンの申請の作成</span><span class="sxs-lookup"><span data-stu-id="b8cdc-110">Create an add-on submission</span></span>](#create-add-on-submission)
* [<span data-ttu-id="b8cdc-111">パッケージ フライトの申請の作成</span><span class="sxs-lookup"><span data-stu-id="b8cdc-111">Create a package flight submission</span></span>](#create-flight-submission)

<span data-ttu-id="b8cdc-112">各例を確認して、それぞれが対応するタスクについて詳しく知ることができます。また、この記事のすべてのコード例を使って、コンソール アプリケーションをビルドすることもできます。</span><span class="sxs-lookup"><span data-stu-id="b8cdc-112">You can review each example to learn more about the task it demonstrates, or you can build all the code examples in this article into a console application.</span></span> <span data-ttu-id="b8cdc-113">完全なコードについては、この記事の最後の「[完全なコード](java-code-examples-for-the-windows-store-submission-api.md#code-listing)」のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b8cdc-113">For the complete code listing, see the [code listing](java-code-examples-for-the-windows-store-submission-api.md#code-listing) section at the end of this article.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="b8cdc-114">前提条件</span><span class="sxs-lookup"><span data-stu-id="b8cdc-114">Prerequisites</span></span>

<span data-ttu-id="b8cdc-115">以下の例では、次のライブラリを使用します。</span><span class="sxs-lookup"><span data-stu-id="b8cdc-115">These examples use the following libraries:</span></span>

* <span data-ttu-id="b8cdc-116">[Apache Commons Logging 1.2](http://commons.apache.org/proper/commons-logging)  (commons-logging-1.2.jar)。</span><span class="sxs-lookup"><span data-stu-id="b8cdc-116">[Apache Commons Logging 1.2](http://commons.apache.org/proper/commons-logging)  (commons-logging-1.2.jar).</span></span>
* <span data-ttu-id="b8cdc-117">[Apache HttpComponents Core 4.4.5 および Apache HttpComponents Client 4.5.2](https://hc.apache.org/) (httpcore-4.4.5.jar and httpclient-4.5.2.jar)。</span><span class="sxs-lookup"><span data-stu-id="b8cdc-117">[Apache HttpComponents Core 4.4.5 and Apache HttpComponents Client 4.5.2](https://hc.apache.org/) (httpcore-4.4.5.jar and httpclient-4.5.2.jar).</span></span>
* <span data-ttu-id="b8cdc-118">[JSR 353 JSON Processing API 1.0](https://mvnrepository.com/artifact/javax.json/javax.json-api/1.0) および [JSR 353 JSON Processing Default Provider API 1.0.4](https://mvnrepository.com/artifact/org.glassfish/javax.json/1.0.4) (javax.json-api-1.0.jar and javax.json-1.0.4.jar)。</span><span class="sxs-lookup"><span data-stu-id="b8cdc-118">[JSR 353 JSON Processing API 1.0](https://mvnrepository.com/artifact/javax.json/javax.json-api/1.0) and [JSR 353 JSON Processing Default Provider API 1.0.4](https://mvnrepository.com/artifact/org.glassfish/javax.json/1.0.4) (javax.json-api-1.0.jar and javax.json-1.0.4.jar).</span></span>

## <a name="main-program-and-imports"></a><span data-ttu-id="b8cdc-119">メイン プログラムとインポート</span><span class="sxs-lookup"><span data-stu-id="b8cdc-119">Main program and imports</span></span>

<span data-ttu-id="b8cdc-120">次の例は、この記事のすべてのコード例で使用されている import ステートメントを示しています。このコード例によって、他のメソッドの例を呼び出すコマンド ライン プログラムが実装されます。</span><span class="sxs-lookup"><span data-stu-id="b8cdc-120">The following example shows the imports statements used by all of the code examples and implements a command line program that calls the other example methods.</span></span>

[!code[SubmissionApi](./code/StoreServicesExamples_Submission/java/MainExample.java#L1-L64)]

<span id="token" />

## <a name="obtain-an-azure-ad-access-token"></a><span data-ttu-id="b8cdc-121">Azure AD アクセス トークンの取得</span><span class="sxs-lookup"><span data-stu-id="b8cdc-121">Obtain an Azure AD access token</span></span>

<span data-ttu-id="b8cdc-122">次の例は、Microsoft Store 申請 API のメソッドを呼び出すために使用できる [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="b8cdc-122">The following example demonstrates how to [obtain an Azure AD access token](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token) that you can use to call methods in the Microsoft Store submission API.</span></span> <span data-ttu-id="b8cdc-123">トークンを取得した後、Microsoft Store 申請 API の呼び出しでこのトークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="b8cdc-123">After you obtain a token, you have 60 minutes to use this token in calls to the Microsoft Store submission API before the token expires.</span></span> <span data-ttu-id="b8cdc-124">トークンの有効期限が切れた後は、新しいトークンを生成できます。</span><span class="sxs-lookup"><span data-stu-id="b8cdc-124">After the token expires, you can generate a new token.</span></span>

[!code[SubmissionApi](./code/StoreServicesExamples_Submission/java/CompleteExample.java#L65-L95)]

<span id="create-add-on" />

## <a name="create-an-add-on"></a><span data-ttu-id="b8cdc-125">アドオンの作成</span><span class="sxs-lookup"><span data-stu-id="b8cdc-125">Create an add-on</span></span>

<span data-ttu-id="b8cdc-126">次の例は、アドオンを[作成](create-an-add-on.md)してから[削除](delete-an-add-on.md)する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="b8cdc-126">The following example demonstrates how to [create](create-an-add-on.md) and then [delete](delete-an-add-on.md) an add-on.</span></span>

[!code[SubmissionApi](./code/StoreServicesExamples_Submission/java/CompleteExample.java#L310-L345)]

<span id="create-package-flight" />

## <a name="create-a-package-flight"></a><span data-ttu-id="b8cdc-127">パッケージ フライトの作成</span><span class="sxs-lookup"><span data-stu-id="b8cdc-127">Create a package flight</span></span>

<span data-ttu-id="b8cdc-128">次の例は、パッケージ フライトを[作成](create-a-flight.md)してから[削除](delete-a-flight.md)する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="b8cdc-128">The following example demonstrates how to [create](create-a-flight.md) and then [delete](delete-a-flight.md) a package flight.</span></span>

[!code[SubmissionApi](./code/StoreServicesExamples_Submission/java/CompleteExample.java#L185-L221)]

<span id="create-app-submission" />

## <a name="create-an-app-submission"></a><span data-ttu-id="b8cdc-129">アプリの申請の作成</span><span class="sxs-lookup"><span data-stu-id="b8cdc-129">Create an app submission</span></span>

<span data-ttu-id="b8cdc-130">次の例は、Microsoft Store 申請 API のいくつかのメソッドを使用して、アプリの申請を作成する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="b8cdc-130">The following example shows how to use several methods in the Microsoft Store submission API to create an app submission.</span></span> <span data-ttu-id="b8cdc-131">これを行うために、```SubmitNewApplicationSubmission``` メソッドは、新しい申請を最後に公開された申請の複製として作成し、複製された申請を更新して Windows デベロッパー センターにコミットします。</span><span class="sxs-lookup"><span data-stu-id="b8cdc-131">To do this, the ```SubmitNewApplicationSubmission``` method creates a new submission as a clone of the last published submission, and then it updates and commits the cloned submission to Windows Dev Center.</span></span> <span data-ttu-id="b8cdc-132">具体的には、```SubmitNewApplicationSubmission``` メソッドは次のタスクを実行します。</span><span class="sxs-lookup"><span data-stu-id="b8cdc-132">Specifically, the ```SubmitNewApplicationSubmission``` method performs these tasks:</span></span>

1. <span data-ttu-id="b8cdc-133">まず、メソッドは[指定されたアプリのデータを取得](get-an-app.md)します。</span><span class="sxs-lookup"><span data-stu-id="b8cdc-133">To begin, the method [gets data for the specified app](get-an-app.md).</span></span>
2. <span data-ttu-id="b8cdc-134">次に、[アプリの保留中の申請を削除](delete-an-app-submission.md)します (存在する場合)。</span><span class="sxs-lookup"><span data-stu-id="b8cdc-134">Next, it [deletes the pending submission for the app](delete-an-app-submission.md), if one exists.</span></span>
3. <span data-ttu-id="b8cdc-135">その後、[アプリの新しい申請を作成](create-an-app-submission.md)します (新しい申請は、最後に公開された申請のコピーです)。</span><span class="sxs-lookup"><span data-stu-id="b8cdc-135">It then [creates a new submission for the app](create-an-app-submission.md) (the new submission is a copy of the last published submission).</span></span>
4. <span data-ttu-id="b8cdc-136">新しい申請の詳細を変更し、申請の新しいパッケージを Azure Blob Storage にアップロードします。</span><span class="sxs-lookup"><span data-stu-id="b8cdc-136">It changes some details for the new submission and upload a new package for the submission to Azure Blob storage.</span></span>
5. <span data-ttu-id="b8cdc-137">次に、新しい申請を[更新](update-an-app-submission.md)してから Windows デベロッパー センターに[コミット](commit-an-app-submission.md)します。</span><span class="sxs-lookup"><span data-stu-id="b8cdc-137">Next, it [updates](update-an-app-submission.md) and then [commits](commit-an-app-submission.md) the new submission to Windows Dev Center.</span></span>
6. <span data-ttu-id="b8cdc-138">最後に、申請が正常にコミットされるまで、定期的に[新しい申請の状態をチェック](get-status-for-an-app-submission.md)します。</span><span class="sxs-lookup"><span data-stu-id="b8cdc-138">Finally, it periodically [checks the status of the new submission](get-status-for-an-app-submission.md) until the submission is successfully committed.</span></span>

[!code[SubmissionApi](./code/StoreServicesExamples_Submission/java/CompleteExample.java#L97-L183)]

<span id="create-add-on-submission" />

## <a name="create-an-add-on-submission"></a><span data-ttu-id="b8cdc-139">アドオンの申請の作成</span><span class="sxs-lookup"><span data-stu-id="b8cdc-139">Create an add-on submission</span></span>

<span data-ttu-id="b8cdc-140">次の例は、Microsoft Store 申請 API のいくつかのメソッドを使用して、アドオンの申請を作成する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="b8cdc-140">The following example shows how to use several methods in the Microsoft Store submission API to create an add-on submission.</span></span> <span data-ttu-id="b8cdc-141">これを行うために、```SubmitNewInAppProductSubmission``` メソッドは、新しい申請を最後に公開された申請の複製として作成し、複製された申請を更新して Windows デベロッパー センターにコミットします。</span><span class="sxs-lookup"><span data-stu-id="b8cdc-141">To do this, the ```SubmitNewInAppProductSubmission``` method creates a new submission as a clone of the last published submission, and then updates and commits the cloned submission to Windows Dev Center.</span></span> <span data-ttu-id="b8cdc-142">具体的には、```SubmitNewInAppProductSubmission``` メソッドは次のタスクを実行します。</span><span class="sxs-lookup"><span data-stu-id="b8cdc-142">Specifically, the ```SubmitNewInAppProductSubmission``` method performs these tasks:</span></span>

1. <span data-ttu-id="b8cdc-143">まず、メソッドは[指定されたアドオンのデータを取得](get-an-add-on.md)します。</span><span class="sxs-lookup"><span data-stu-id="b8cdc-143">To begin, the method [gets data for the specified add-on](get-an-add-on.md).</span></span>
2. <span data-ttu-id="b8cdc-144">次に、[アドオンの保留中の申請を削除](delete-an-add-on-submission.md)します (存在する場合)。</span><span class="sxs-lookup"><span data-stu-id="b8cdc-144">Next, it [deletes the pending submission for the add-on](delete-an-add-on-submission.md), if one exists.</span></span>
3. <span data-ttu-id="b8cdc-145">その後、[アドオンの新しい申請を作成](create-an-add-on-submission.md)します (新しい申請は、最後に公開された申請のコピーです)。</span><span class="sxs-lookup"><span data-stu-id="b8cdc-145">It then [creates a new submission for the add-on](create-an-add-on-submission.md) (the new submission is a copy of the last published submission).</span></span>
4. <span data-ttu-id="b8cdc-146">申請のアイコンが含まれた ZIP アーカイブを Azure Blob Storage にアップロードします。</span><span class="sxs-lookup"><span data-stu-id="b8cdc-146">It uploads a ZIP archive that contains icons for the submission to Azure Blob storage.</span></span>
5. <span data-ttu-id="b8cdc-147">次に、新しい申請を[更新](update-an-add-on-submission.md)してから Windows デベロッパー センターに[コミット](commit-an-add-on-submission.md)します。</span><span class="sxs-lookup"><span data-stu-id="b8cdc-147">Next, it [updates](update-an-add-on-submission.md) and then [commits](commit-an-add-on-submission.md) the new submission to Windows Dev Center.</span></span>
6. <span data-ttu-id="b8cdc-148">最後に、申請が正常にコミットされるまで、定期的に[新しい申請の状態をチェック](get-status-for-an-add-on-submission.md)します。</span><span class="sxs-lookup"><span data-stu-id="b8cdc-148">Finally, it periodically [checks the status of the new submission](get-status-for-an-add-on-submission.md) until the submission is successfully committed.</span></span>

[!code[SubmissionApi](./code/StoreServicesExamples_Submission/java/CompleteExample.java#L347-L431)]

<span id="create-flight-submission" />

## <a name="create-a-package-flight-submission"></a><span data-ttu-id="b8cdc-149">パッケージ フライトの申請の作成</span><span class="sxs-lookup"><span data-stu-id="b8cdc-149">Create a package flight submission</span></span>

<span data-ttu-id="b8cdc-150">次の例は、Microsoft Store 申請 API のいくつかのメソッドを使用して、パッケージ フライトの申請を作成する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="b8cdc-150">The following example shows how to use several methods in the Microsoft Store submission API to create a package flight submission.</span></span> <span data-ttu-id="b8cdc-151">これを行うために、```SubmitNewFlightSubmission``` メソッドは、新しい申請を最後に公開された申請の複製として作成し、複製された申請を更新して Windows デベロッパー センターにコミットします。</span><span class="sxs-lookup"><span data-stu-id="b8cdc-151">To do this, the ```SubmitNewFlightSubmission``` method creates a new submission as a clone of the last published submission, and then updates and commits the cloned submission to Windows Dev Center.</span></span> <span data-ttu-id="b8cdc-152">具体的には、```SubmitNewFlightSubmission``` メソッドは次のタスクを実行します。</span><span class="sxs-lookup"><span data-stu-id="b8cdc-152">Specifically, the ```SubmitNewFlightSubmission``` method performs these tasks:</span></span>

1. <span data-ttu-id="b8cdc-153">まず、メソッドは[指定されたパッケージ フライトのデータを取得](get-a-flight.md)します。</span><span class="sxs-lookup"><span data-stu-id="b8cdc-153">To begin, the method [gets data for the specified package flight](get-a-flight.md).</span></span>
2. <span data-ttu-id="b8cdc-154">次に、[パッケージ フライトの保留中の申請を削除](delete-a-flight-submission.md)します (存在する場合)。</span><span class="sxs-lookup"><span data-stu-id="b8cdc-154">Next, it [deletes the pending submission for the package flight](delete-a-flight-submission.md), if one exists.</span></span>
3. <span data-ttu-id="b8cdc-155">その後、[パッケージ フライトの新しい申請を作成](create-a-flight-submission.md)します (新しい申請は、最後に公開された申請のコピーです)。</span><span class="sxs-lookup"><span data-stu-id="b8cdc-155">It then [creates a new submission for the package flight](create-a-flight-submission.md) (the new submission is a copy of the last published submission).</span></span>
4. <span data-ttu-id="b8cdc-156">申請の新しいパッケージを Azure Blob Storage にアップロードします。</span><span class="sxs-lookup"><span data-stu-id="b8cdc-156">It uploads a new package for the submission to Azure Blob storage.</span></span>
5. <span data-ttu-id="b8cdc-157">次に、新しい申請を[更新](update-a-flight-submission.md)してから Windows デベロッパー センターに[コミット](commit-a-flight-submission.md)します。</span><span class="sxs-lookup"><span data-stu-id="b8cdc-157">Next, it [updates](update-a-flight-submission.md) and then [commits](commit-a-flight-submission.md) the new submission to Windows Dev Center.</span></span>
6. <span data-ttu-id="b8cdc-158">最後に、申請が正常にコミットされるまで、定期的に[新しい申請の状態をチェック](get-status-for-a-flight-submission.md)します。</span><span class="sxs-lookup"><span data-stu-id="b8cdc-158">Finally, it periodically [checks the status of the new submission](get-status-for-a-flight-submission.md) until the submission is successfully committed.</span></span>

[!code[SubmissionApi](./code/StoreServicesExamples_Submission/java/CompleteExample.java#L223-L308)]

<span id="utilities" />

## <a name="utility-methods-to-upload-submission-files-and-handle-request-responses"></a><span data-ttu-id="b8cdc-159">申請ファイルをアップロードし要求の応答を処理するユーティリティ メソッド</span><span class="sxs-lookup"><span data-stu-id="b8cdc-159">Utility methods to upload submission files and handle request responses</span></span>

<span data-ttu-id="b8cdc-160">ここでは、次のタスクに対応するユーティリティ メソッドを示します。</span><span class="sxs-lookup"><span data-stu-id="b8cdc-160">The following utility methods demonstrate these tasks:</span></span>

* <span data-ttu-id="b8cdc-161">アプリまたはアドオンの申請の新しいアセットが含まれた ZIP アーカイブを Azure Blob Storage にアップロードする方法。</span><span class="sxs-lookup"><span data-stu-id="b8cdc-161">How to upload a ZIP archive containing new assets for an app or add-on submission to Azure Blob storage.</span></span> <span data-ttu-id="b8cdc-162">アプリとアドオンの申請のために Azure Blob Storage に ZIP アーカイブをアップロードする方法について詳しくは、「[アプリの申請の作成](manage-app-submissions.md#create-an-app-submission)」、「[アドオンの申請の作成](manage-add-on-submissions.md#create-an-add-on-submission)」、「[パッケージ フライトの申請の作成](manage-flight-submissions.md#create-a-package-flight-submission)」の関連する手順をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b8cdc-162">For more information about uploading a ZIP archive to Azure Blob storage for app and add-on submissions, see the relevant instructions in [Create an app submission](manage-app-submissions.md#create-an-app-submission), [Create an add-on submission](manage-add-on-submissions.md#create-an-add-on-submission), and [Create a package flight submission](manage-flight-submissions.md#create-a-package-flight-submission).</span></span>
* <span data-ttu-id="b8cdc-163">要求の応答を処理する方法。</span><span class="sxs-lookup"><span data-stu-id="b8cdc-163">How to handle request responses.</span></span>

[!code[SubmissionApi](./code/StoreServicesExamples_Submission/java/CompleteExample.java#L433-L490)]

<span id="code-listing" />

## <a name="complete-code-listing"></a><span data-ttu-id="b8cdc-164">完全なコード</span><span class="sxs-lookup"><span data-stu-id="b8cdc-164">Complete code listing</span></span>

<span data-ttu-id="b8cdc-165">次のコードは、上記のすべての例を 1 つのソース ファイルにまとめた状態です。</span><span class="sxs-lookup"><span data-stu-id="b8cdc-165">The following code listing contains all of the previous examples organized into one source file.</span></span>

[!code[SubmissionApi](./code/StoreServicesExamples_Submission/java/CompleteExample.java#L1-L491)]

## <a name="related-topics"></a><span data-ttu-id="b8cdc-166">関連トピック</span><span class="sxs-lookup"><span data-stu-id="b8cdc-166">Related topics</span></span>

* [<span data-ttu-id="b8cdc-167">Microsoft Store サービスを使用した申請の作成と管理</span><span class="sxs-lookup"><span data-stu-id="b8cdc-167">Create and manage submissions using Microsoft Store services</span></span>](create-and-manage-submissions-using-windows-store-services.md)
