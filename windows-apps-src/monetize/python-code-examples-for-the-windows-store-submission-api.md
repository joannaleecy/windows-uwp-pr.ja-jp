---
author: Xansky
ms.assetid: 8AC56AAF-8D8C-4193-A6B3-BB5D0669D994
description: このセクションの Python コード例を使用して、Microsoft Store 申請 API を使用する方法をご確認ください。
title: 'Python のコード例: アプリ、アドオン、およびフライトの申請'
ms.author: mhopkins
ms.date: 07/10/2017
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store 申請 API, コード例, Python
ms.localizationpriority: medium
ms.openlocfilehash: 34d686b8e20d384da4a3db1ea3805ad082d5f8a8
ms.sourcegitcommit: 71e8eae5c077a7740e5606298951bb78fc42b22c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/13/2018
ms.locfileid: "6654271"
---
# <a name="python-sample-submissions-for-apps-add-ons-and-flights"></a><span data-ttu-id="23ab4-104">Python のコード例: アプリ、アドオン、およびフライトの申請</span><span class="sxs-lookup"><span data-stu-id="23ab4-104">Python sample: submissions for apps, add-ons, and flights</span></span>

<span data-ttu-id="23ab4-105">この記事では、次のタスクで [Microsoft Store 申請 API](create-and-manage-submissions-using-windows-store-services.md) を使用する方法を示す Python コード例を提供します。</span><span class="sxs-lookup"><span data-stu-id="23ab4-105">This article provides Python code examples that demonstrate how to use the [Microsoft Store submission API](create-and-manage-submissions-using-windows-store-services.md) for these tasks:</span></span>

* [<span data-ttu-id="23ab4-106">Azure AD アクセス トークンの取得</span><span class="sxs-lookup"><span data-stu-id="23ab4-106">Obtain an Azure AD access token</span></span>](#token)
* [<span data-ttu-id="23ab4-107">アドオンの作成</span><span class="sxs-lookup"><span data-stu-id="23ab4-107">Create an add-on</span></span>](#create-add-on)
* [<span data-ttu-id="23ab4-108">パッケージ フライトの作成</span><span class="sxs-lookup"><span data-stu-id="23ab4-108">Create a package flight</span></span>](#create-package-flight)
* [<span data-ttu-id="23ab4-109">アプリの申請の作成</span><span class="sxs-lookup"><span data-stu-id="23ab4-109">Create an app submission</span></span>](#create-app-submission)
* [<span data-ttu-id="23ab4-110">アドオンの申請の作成</span><span class="sxs-lookup"><span data-stu-id="23ab4-110">Create an add-on submission</span></span>](#create-add-on-submission)
* [<span data-ttu-id="23ab4-111">パッケージ フライトの申請の作成</span><span class="sxs-lookup"><span data-stu-id="23ab4-111">Create a package flight submission</span></span>](#create-flight-submission)

<span id="token" />

## <a name="obtain-an-azure-ad-access-token"></a><span data-ttu-id="23ab4-112">Azure AD アクセス トークンの取得</span><span class="sxs-lookup"><span data-stu-id="23ab4-112">Obtain an Azure AD access token</span></span>

<span data-ttu-id="23ab4-113">次の例は、Microsoft Store 申請 API のメソッドを呼び出すために使用できる [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="23ab4-113">The following example demonstrates how to [obtain an Azure AD access token](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token) that you can use to call methods in the Microsoft Store submission API.</span></span> <span data-ttu-id="23ab4-114">トークンを取得した後、Microsoft Store 申請 API の呼び出しでこのトークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="23ab4-114">After you obtain a token, you have 60 minutes to use this token in calls to the Microsoft Store submission API before the token expires.</span></span> <span data-ttu-id="23ab4-115">トークンの有効期限が切れた後は、新しいトークンを生成できます。</span><span class="sxs-lookup"><span data-stu-id="23ab4-115">After the token expires, you can generate a new token..</span></span>

[!code[SubmissionApi](./code/StoreServicesExamples_Submission/python/Examples.py#L1-L20)]

<span id="create-add-on" />

## <a name="create-an-add-on"></a><span data-ttu-id="23ab4-116">アドオンの作成</span><span class="sxs-lookup"><span data-stu-id="23ab4-116">Create an add-on</span></span>

<span data-ttu-id="23ab4-117">次の例は、アドオンを[作成](create-an-add-on.md)してから[削除](delete-an-add-on.md)する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="23ab4-117">The following example demonstrates how to [create](create-an-add-on.md) and then [delete](delete-an-add-on.md) an add-on.</span></span>

[!code[SubmissionApi](./code/StoreServicesExamples_Submission/python/Examples.py#L26-L52)]

<span id="create-package-flight" />

## <a name="create-a-package-flight"></a><span data-ttu-id="23ab4-118">パッケージ フライトの作成</span><span class="sxs-lookup"><span data-stu-id="23ab4-118">Create a package flight</span></span>

<span data-ttu-id="23ab4-119">次の例は、パッケージ フライトを[作成](create-a-flight.md)してから[削除](delete-a-flight.md)する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="23ab4-119">The following example demonstrates how to [create](create-a-flight.md) and then [delete](delete-a-flight.md) a package flight.</span></span>

[!code[SubmissionApi](./code/StoreServicesExamples_Submission/python/Examples.py#L58-L87)]

<span id="create-app-submission" />

## <a name="create-an-app-submission"></a><span data-ttu-id="23ab4-120">アプリの申請の作成</span><span class="sxs-lookup"><span data-stu-id="23ab4-120">Create an app submission</span></span>

<span data-ttu-id="23ab4-121">次の例は、Microsoft Store 申請 API のいくつかのメソッドを使用して、アプリの申請を作成する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="23ab4-121">The following example shows how to use several methods in the Microsoft Store submission API to create an app submission.</span></span> <span data-ttu-id="23ab4-122">これを行うには、コード最後に公開された申請の複製として新しい申請を作成し、更新プログラムし、パートナー センターに複製された申請をコミットします。</span><span class="sxs-lookup"><span data-stu-id="23ab4-122">To do this, the code creates a new submission as a clone of the last published submission, and then updates and commits the cloned submission to Partner Center.</span></span> <span data-ttu-id="23ab4-123">具体的には、この例では次のタスクを実行します。</span><span class="sxs-lookup"><span data-stu-id="23ab4-123">Specifically, the example performs these tasks:</span></span>

1. <span data-ttu-id="23ab4-124">まず、例では[指定されたアプリのデータを取得](get-an-app.md)します。</span><span class="sxs-lookup"><span data-stu-id="23ab4-124">To begin, the example [gets data for the specified app](get-an-app.md).</span></span>
2. <span data-ttu-id="23ab4-125">次に、[アプリの保留中の申請を削除](delete-an-app-submission.md)します (存在する場合)。</span><span class="sxs-lookup"><span data-stu-id="23ab4-125">Next, it [deletes the pending submission for the app](delete-an-app-submission.md), if one exists.</span></span>
3. <span data-ttu-id="23ab4-126">その後、[アプリの新しい申請を作成](create-an-app-submission.md)します (新しい申請は、最後に公開された申請のコピーです)。</span><span class="sxs-lookup"><span data-stu-id="23ab4-126">It then [creates a new submission for the app](create-an-app-submission.md) (the new submission is a copy of the last published submission).</span></span>
4. <span data-ttu-id="23ab4-127">新しい申請の詳細を変更し、申請の新しいパッケージを Azure Blob Storage にアップロードします。</span><span class="sxs-lookup"><span data-stu-id="23ab4-127">It changes some details for the new submission and upload a new package for the submission to Azure Blob storage.</span></span>
5. <span data-ttu-id="23ab4-128">次に、その[更新プログラム](update-an-app-submission.md)とし、パートナー センターに新しい申請を[コミット](commit-an-app-submission.md)します。</span><span class="sxs-lookup"><span data-stu-id="23ab4-128">Next, it [updates](update-an-app-submission.md) and then [commits](commit-an-app-submission.md) the new submission to Partner Center.</span></span>
6. <span data-ttu-id="23ab4-129">最後に、申請が正常にコミットされるまで、定期的に[新しい申請の状態をチェック](get-status-for-an-app-submission.md)します。</span><span class="sxs-lookup"><span data-stu-id="23ab4-129">Finally, it periodically [checks the status of the new submission](get-status-for-an-app-submission.md) until the submission is successfully committed.</span></span>

[!code[SubmissionApi](./code/StoreServicesExamples_Submission/python/Examples.py#L93-L166)]

<span id="create-add-on-submission" />

## <a name="create-an-add-on-submission"></a><span data-ttu-id="23ab4-130">アドオンの申請の作成</span><span class="sxs-lookup"><span data-stu-id="23ab4-130">Create an add-on submission</span></span>

<span data-ttu-id="23ab4-131">次の例は、Microsoft Store 申請 API のいくつかのメソッドを使用して、アドオンの申請を作成する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="23ab4-131">The following example shows how to use several methods in the Microsoft Store submission API to create an add-on submission.</span></span> <span data-ttu-id="23ab4-132">これを行うには、コード最後に公開された申請の複製として新しい申請を作成し、更新プログラムし、パートナー センターに複製された申請をコミットします。</span><span class="sxs-lookup"><span data-stu-id="23ab4-132">To do this, the code creates a new submission as a clone of the last published submission, and then updates and commits the cloned submission to Partner Center.</span></span> <span data-ttu-id="23ab4-133">具体的には、この例では次のタスクを実行します。</span><span class="sxs-lookup"><span data-stu-id="23ab4-133">Specifically, the example performs these tasks:</span></span>

1. <span data-ttu-id="23ab4-134">まず、例では[指定されたアドオンのデータを取得](get-an-add-on.md)します。</span><span class="sxs-lookup"><span data-stu-id="23ab4-134">To begin, the example [gets data for the specified add-on](get-an-add-on.md).</span></span>
2. <span data-ttu-id="23ab4-135">次に、[アドオンの保留中の申請を削除](delete-an-add-on-submission.md)します (存在する場合)。</span><span class="sxs-lookup"><span data-stu-id="23ab4-135">Next, it [deletes the pending submission for the add-on](delete-an-add-on-submission.md), if one exists.</span></span>
3. <span data-ttu-id="23ab4-136">その後、[アドオンの新しい申請を作成](create-an-add-on-submission.md)します (新しい申請は、最後に公開された申請のコピーです)。</span><span class="sxs-lookup"><span data-stu-id="23ab4-136">It then [creates a new submission for the add-on](create-an-add-on-submission.md) (the new submission is a copy of the last published submission).</span></span>
4. <span data-ttu-id="23ab4-137">申請のアイコンが含まれた ZIP アーカイブを Azure Blob Storage にアップロードします。</span><span class="sxs-lookup"><span data-stu-id="23ab4-137">It uploads a ZIP archive that contains icons for the submission to Azure Blob storage.</span></span> <span data-ttu-id="23ab4-138">詳しくは、「[アドオンの申請の作成](manage-add-on-submissions.md#create-an-add-on-submission)」の Azure Blob Storage に ZIP アーカイブをアップロードする方法について関連する手順をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="23ab4-138">For more information, see the relevant instructions about uploading a ZIP archive to Azure Blob storage in [Create an add-on submission](manage-add-on-submissions.md#create-an-add-on-submission).</span></span>
5. <span data-ttu-id="23ab4-139">次に、その[更新プログラム](update-an-add-on-submission.md)とし、パートナー センターに新しい申請を[コミット](commit-an-add-on-submission.md)します。</span><span class="sxs-lookup"><span data-stu-id="23ab4-139">Next, it [updates](update-an-add-on-submission.md) and then [commits](commit-an-add-on-submission.md) the new submission to Partner Center.</span></span>
6. <span data-ttu-id="23ab4-140">最後に、申請が正常にコミットされるまで、定期的に[新しい申請の状態をチェック](get-status-for-an-add-on-submission.md)します。</span><span class="sxs-lookup"><span data-stu-id="23ab4-140">Finally, it periodically [checks the status of the new submission](get-status-for-an-add-on-submission.md) until the submission is successfully committed.</span></span>

[!code[SubmissionApi](./code/StoreServicesExamples_Submission/python/Examples.py#L172-L245)]

<span id="create-flight-submission" />

## <a name="create-a-package-flight-submission"></a><span data-ttu-id="23ab4-141">パッケージ フライトの申請の作成</span><span class="sxs-lookup"><span data-stu-id="23ab4-141">Create a package flight submission</span></span>

<span data-ttu-id="23ab4-142">次の例は、Microsoft Store 申請 API のいくつかのメソッドを使用して、パッケージ フライトの申請を作成する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="23ab4-142">The following example shows how to use several methods in the Microsoft Store submission API to create a package flight submission.</span></span> <span data-ttu-id="23ab4-143">これを行うには、コード最後に公開された申請の複製として新しい申請を作成し、更新プログラムし、パートナー センターに複製された申請をコミットします。</span><span class="sxs-lookup"><span data-stu-id="23ab4-143">To do this, the code creates a new submission as a clone of the last published submission, and then updates and commits the cloned submission to Partner Center.</span></span> <span data-ttu-id="23ab4-144">具体的には、この例では次のタスクを実行します。</span><span class="sxs-lookup"><span data-stu-id="23ab4-144">Specifically, the example performs these tasks:</span></span>

1. <span data-ttu-id="23ab4-145">まず、例では[指定されたパッケージ フライトのデータを取得](get-a-flight.md)します。</span><span class="sxs-lookup"><span data-stu-id="23ab4-145">To begin, the example [gets data for the specified package flight](get-a-flight.md).</span></span>
2. <span data-ttu-id="23ab4-146">次に、[パッケージ フライトの保留中の申請を削除](delete-a-flight-submission.md)します (存在する場合)。</span><span class="sxs-lookup"><span data-stu-id="23ab4-146">Next, it [deletes the pending submission for the package flight](delete-a-flight-submission.md), if one exists.</span></span>
3. <span data-ttu-id="23ab4-147">その後、[パッケージ フライトの新しい申請を作成](create-a-flight-submission.md)します (新しい申請は、最後に公開された申請のコピーです)。</span><span class="sxs-lookup"><span data-stu-id="23ab4-147">It then [creates a new submission for the package flight](create-a-flight-submission.md) (the new submission is a copy of the last published submission).</span></span>
4. <span data-ttu-id="23ab4-148">申請の新しいパッケージを Azure Blob Storage にアップロードします。</span><span class="sxs-lookup"><span data-stu-id="23ab4-148">It uploads a new package for the submission to Azure Blob storage.</span></span> <span data-ttu-id="23ab4-149">詳しくは、「[パッケージ フライトの申請の作成](manage-flight-submissions.md#create-a-package-flight-submission)」の Azure Blob Storage に ZIP アーカイブをアップロードする方法について関連する手順をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="23ab4-149">For more information, see the relevant instructions about uploading a ZIP archive to Azure Blob storage in [Create a package flight submission](manage-flight-submissions.md#create-a-package-flight-submission).</span></span>
5. <span data-ttu-id="23ab4-150">次に、その[更新プログラム](update-a-flight-submission.md)とし、パートナー センターに新しい申請を[コミット](commit-a-flight-submission.md)します。</span><span class="sxs-lookup"><span data-stu-id="23ab4-150">Next, it [updates](update-a-flight-submission.md) and then [commits](commit-a-flight-submission.md) the new submission to Partner Center.</span></span>
6. <span data-ttu-id="23ab4-151">最後に、申請が正常にコミットされるまで、定期的に[新しい申請の状態をチェック](get-status-for-a-flight-submission.md)します。</span><span class="sxs-lookup"><span data-stu-id="23ab4-151">Finally, it periodically [checks the status of the new submission](get-status-for-a-flight-submission.md) until the submission is successfully committed.</span></span>

[!code[SubmissionApi](./code/StoreServicesExamples_Submission/python/Examples.py#L251-L325)]

## <a name="related-topics"></a><span data-ttu-id="23ab4-152">関連トピック</span><span class="sxs-lookup"><span data-stu-id="23ab4-152">Related topics</span></span>

* [<span data-ttu-id="23ab4-153">Microsoft Store サービスを使用した申請の作成と管理</span><span class="sxs-lookup"><span data-stu-id="23ab4-153">Create and manage submissions using Microsoft Store services</span></span>](create-and-manage-submissions-using-windows-store-services.md)
