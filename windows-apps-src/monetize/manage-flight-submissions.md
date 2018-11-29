---
ms.assetid: 2A454057-FF14-40D2-8ED2-CEB5F27E0226
description: パートナー センター アカウントに登録されているアプリのパッケージ フライトの申請を管理するのに、Microsoft Store 申請 API でこれらのメソッドを使用します。
title: パッケージ フライトの申請の管理
ms.date: 04/16/2018
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store 申請 API, フライトの申請
ms.localizationpriority: medium
ms.openlocfilehash: 19ddd43d4e61480764882f1b10e6240aa2afeb8c
ms.sourcegitcommit: 89ff8ff88ef58f4fe6d3b1368fe94f62e59118ad
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/29/2018
ms.locfileid: "8189697"
---
# <a name="manage-package-flight-submissions"></a><span data-ttu-id="7af11-104">パッケージ フライトの申請の管理</span><span class="sxs-lookup"><span data-stu-id="7af11-104">Manage package flight submissions</span></span>

<span data-ttu-id="7af11-105">Microsoft Store 申請 API には、段階的なパッケージのロールアウトなど、アプリのパッケージ フライトの申請を管理するために使用できるメソッドが用意されています。</span><span class="sxs-lookup"><span data-stu-id="7af11-105">The Microsoft Store submission API provides methods you can use to manage package flight submissions for your apps, including gradual package rollouts.</span></span> <span data-ttu-id="7af11-106">Microsoft Store 申請 API の概要については、「[Microsoft Store サービスを使用した申請の作成と管理](create-and-manage-submissions-using-windows-store-services.md)」をご覧ください。この API を使用するための前提条件などの情報があります。</span><span class="sxs-lookup"><span data-stu-id="7af11-106">For an introduction to the Microsoft Store submission API, including prerequisites for using the API, see [Create and manage submissions using Microsoft Store services](create-and-manage-submissions-using-windows-store-services.md).</span></span>

> [!IMPORTANT]
> <span data-ttu-id="7af11-107">パッケージ フライトの申請を作成する、Microsoft Store 申請 API を使用する場合は、さらに変更する、申請を使ってパートナー センターではなく API のみを必ずします。</span><span class="sxs-lookup"><span data-stu-id="7af11-107">If you use the Microsoft Store submission API to create a submission for a package flight, be sure to make further changes to the submission only by using the API, rather than Partner Center.</span></span> <span data-ttu-id="7af11-108">最初に API を使って作成した申請を、ダッシュボードを使って変更した場合、API を使ってその申請を変更またはコミットすることができなくなります。</span><span class="sxs-lookup"><span data-stu-id="7af11-108">If you use the dashboard to change a submission that you originally created by using the API, you will no longer be able to change or commit that submission by using the API.</span></span> <span data-ttu-id="7af11-109">場合によっては、申請がエラー状態のままになり、申請プロセスを進めることができなくなります。</span><span class="sxs-lookup"><span data-stu-id="7af11-109">In some cases, the submission could be left in an error state where it cannot proceed in the submission process.</span></span> <span data-ttu-id="7af11-110">この場合、申請を削除して新しい申請を作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="7af11-110">If this occurs, you must delete the submission and create a new submission.</span></span>

<span id="methods-for-package-flight-submissions" />

## <a name="methods-for-managing-package-flight-submissions"></a><span data-ttu-id="7af11-111">パッケージ フライトの申請を管理するためのメソッド</span><span class="sxs-lookup"><span data-stu-id="7af11-111">Methods for managing package flight submissions</span></span>

<span data-ttu-id="7af11-112">パッケージ フライトの申請を取得、作成、更新、コミット、または削除するには、次のメソッドを使用します。</span><span class="sxs-lookup"><span data-stu-id="7af11-112">Use the following methods to get, create, update, commit, or delete a package flight submission.</span></span> <span data-ttu-id="7af11-113">これらのメソッドを使用することができます前に、パッケージ フライトはパートナー センターで既に存在する必要があります。</span><span class="sxs-lookup"><span data-stu-id="7af11-113">Before you can use these methods, the package flight must already exist in Partner Center.</span></span> <span data-ttu-id="7af11-114">パッケージを作成する[パートナー センターで](https://msdn.microsoft.com/windows/uwp/publish/package-flights)フライトまたは Microsoft Store 申請 API のメソッドを使用して[管理パッケージ フライト](manage-flights.md)で説明されています。</span><span class="sxs-lookup"><span data-stu-id="7af11-114">You can create a package flight [in Partner Center](https://msdn.microsoft.com/windows/uwp/publish/package-flights) or by using the Microsoft Store submission API methods in described in [Manage package flights](manage-flights.md).</span></span>

<table>
<colgroup>
<col width="10%" />
<col width="30%" />
<col width="60%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="7af11-115">メソッド</span><span class="sxs-lookup"><span data-stu-id="7af11-115">Method</span></span></th>
<th align="left"><span data-ttu-id="7af11-116">URI</span><span class="sxs-lookup"><span data-stu-id="7af11-116">URI</span></span></th>
<th align="left"><span data-ttu-id="7af11-117">説明</span><span class="sxs-lookup"><span data-stu-id="7af11-117">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr>
<td align="left"><span data-ttu-id="7af11-118">GET</span><span class="sxs-lookup"><span data-stu-id="7af11-118">GET</span></span></td>
<td align="left">https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions/{submissionId}</td>
<td align="left"><a href="get-a-flight-submission.md"><span data-ttu-id="7af11-119">既存のパッケージ フライトの申請を更新します</span><span class="sxs-lookup"><span data-stu-id="7af11-119">Get an existing package flight submission</span></span></a></td>
</tr>
<tr>
<td align="left"><span data-ttu-id="7af11-120">GET</span><span class="sxs-lookup"><span data-stu-id="7af11-120">GET</span></span></td>
<td align="left">https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions/{submissionId}/status</td>
<td align="left"><a href="get-status-for-a-flight-submission.md"><span data-ttu-id="7af11-121">既存のパッケージ フライトの申請の状態を取得します</span><span class="sxs-lookup"><span data-stu-id="7af11-121">Get the status of an existing package flight submission</span></span></a></td>
</tr>
<tr>
<td align="left"><span data-ttu-id="7af11-122">POST</span><span class="sxs-lookup"><span data-stu-id="7af11-122">POST</span></span></td>
<td align="left">https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions</td>
<td align="left"><a href="create-a-flight-submission.md"><span data-ttu-id="7af11-123">新しいパッケージ フライトの申請を作成します</span><span class="sxs-lookup"><span data-stu-id="7af11-123">Create a new package flight submission</span></span></a></td>
</tr>
<tr>
<td align="left"><span data-ttu-id="7af11-124">PUT</span><span class="sxs-lookup"><span data-stu-id="7af11-124">PUT</span></span></td>
<td align="left">https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions/{submissionId}</td>
<td align="left"><a href="update-a-flight-submission.md"><span data-ttu-id="7af11-125">既存のパッケージ フライトの申請を更新します</span><span class="sxs-lookup"><span data-stu-id="7af11-125">Update an existing package flight submission</span></span></a></td>
</tr>
<tr>
<td align="left"><span data-ttu-id="7af11-126">POST</span><span class="sxs-lookup"><span data-stu-id="7af11-126">POST</span></span></td>
<td align="left">https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions/{submissionId}/commit</td>
<td align="left"><a href="commit-a-flight-submission.md"><span data-ttu-id="7af11-127">新しいパッケージ フライトの申請または更新されたパッケージ フライトの申請をコミットします</span><span class="sxs-lookup"><span data-stu-id="7af11-127">Commit a new or updated package flight submission</span></span></a></td>
</tr>
<tr>
<td align="left"><span data-ttu-id="7af11-128">DELETE</span><span class="sxs-lookup"><span data-stu-id="7af11-128">DELETE</span></span></td>
<td align="left">https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions/{submissionId}</td>
<td align="left"><a href="delete-a-flight-submission.md"><span data-ttu-id="7af11-129">パッケージ フライトの申請を削除します</span><span class="sxs-lookup"><span data-stu-id="7af11-129">Delete a package flight submission</span></span></a></td>
</tr>
</tbody>
</table>

<span id="create-a-package-flight-submission">

## <a name="create-a-package-flight-submission"></a><span data-ttu-id="7af11-130">パッケージ フライトの申請の作成</span><span class="sxs-lookup"><span data-stu-id="7af11-130">Create a package flight submission</span></span>

<span data-ttu-id="7af11-131">パッケージ フライトの申請を作成するには、次のプロセスに従います。</span><span class="sxs-lookup"><span data-stu-id="7af11-131">To create a submission for a package flight, follow this process.</span></span>

1. <span data-ttu-id="7af11-132">場合はまだ準備ができていないため、完全な前提条件で説明されている[作成し、Microsoft Store サービスを使用した申請の管理](create-and-manage-submissions-using-windows-store-services.md)Azure AD アプリケーションをパートナー センター アカウントに関連付けると、ID とキー、クライアントの取得を含めて、します。</span><span class="sxs-lookup"><span data-stu-id="7af11-132">If you have not yet done so, complete the prerequisites described in [Create and manage submissions using Microsoft Store services](create-and-manage-submissions-using-windows-store-services.md), including associating an Azure AD application with your Partner Center account and obtaining your client ID and key.</span></span> <span data-ttu-id="7af11-133">この作業は 1 度行うだけでよく、クライアント ID とキーを入手したら、新しい Azure AD アクセス トークンの作成が必要になったときに、いつでもそれらを再利用できます。</span><span class="sxs-lookup"><span data-stu-id="7af11-133">You only need to do this one time; after you have the client ID and key, you can reuse them any time you need to create a new Azure AD access token.</span></span>  

2. <span data-ttu-id="7af11-134">[Azure AD アクセス トークンを取得します](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)。</span><span class="sxs-lookup"><span data-stu-id="7af11-134">[Obtain an Azure AD access token](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token).</span></span> <span data-ttu-id="7af11-135">このアクセス トークンを Microsoft Store 申請 API のメソッドに渡す必要があります。</span><span class="sxs-lookup"><span data-stu-id="7af11-135">You must pass this access token to the methods in the Microsoft Store submission API.</span></span> <span data-ttu-id="7af11-136">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="7af11-136">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="7af11-137">トークンの有効期限が切れたら、新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="7af11-137">After the token expires, you can obtain a new one.</span></span>

3. <span data-ttu-id="7af11-138">Microsoft Store 申請 API の次のメソッドを実行して、[パッケージ フライトの申請を作成](create-a-flight-submission.md)します。</span><span class="sxs-lookup"><span data-stu-id="7af11-138">[Create a package flight submission](create-a-flight-submission.md) by executing the following method in the Microsoft Store submission API.</span></span> <span data-ttu-id="7af11-139">このメソッドによって、新しい申請が作成され、審議中になります。これは、前回発行した申請のコピーです。</span><span class="sxs-lookup"><span data-stu-id="7af11-139">This method creates a new in-progress submission, which is a copy of your last published submission.</span></span>

    ```
    POST https://manage.devcenter.microsoft.com/v1.0/my/applications{applicationId}/flights/{flightId}/submissions
    ```

    <span data-ttu-id="7af11-140">応答本文には、新しい申請の ID、申請用のパッケージを Azure Blob Storage にアップロードするための共有アクセス署名 (SAS) URI、および新しい申請のデータ (すべての登録情報と価格情報が含まれます) を含む[フライトの申請](#flight-submission-object)リソースが含まれます。</span><span class="sxs-lookup"><span data-stu-id="7af11-140">The response body contains a [flight submission](#flight-submission-object) resource that includes the ID of the new submission, the shared access signature (SAS) URI for uploading any packages for the submission to Azure Blob storage, and the data for the new submission (including all the listings and pricing information).</span></span>

    > [!NOTE]
    > <span data-ttu-id="7af11-141">SAS URI では、アカウント キーを必要とせずに、Azure Storage 内のセキュリティで保護されたリソースにアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="7af11-141">A SAS URI provides access to a secure resource in Azure storage without requiring account keys.</span></span> <span data-ttu-id="7af11-142">SAS URI の背景情報と Azure Blob Storage での SAS URI の使用については、「[Shared Access Signatures (SAS) の使用](https://azure.microsoft.com/documentation/articles/storage-dotnet-shared-access-signature-part-1)」と「[Shared Access Signature、第 2 部: BLOB ストレージでの SAS の作成と使用](https://azure.microsoft.com/documentation/articles/storage-dotnet-shared-access-signature-part-2/)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7af11-142">For background information about SAS URIs and their use with Azure Blob storage, see [Shared Access Signatures, Part 1: Understanding the SAS model](https://azure.microsoft.com/documentation/articles/storage-dotnet-shared-access-signature-part-1) and [Shared Access Signatures, Part 2: Create and use a SAS with Blob storage](https://azure.microsoft.com/documentation/articles/storage-dotnet-shared-access-signature-part-2/).</span></span>

4. <span data-ttu-id="7af11-143">申請用に新しいパッケージを追加する場合は、[パッケージを準備](https://msdn.microsoft.com/windows/uwp/publish/app-package-requirements)して、ZIP アーカイブに追加します。</span><span class="sxs-lookup"><span data-stu-id="7af11-143">If you are adding new packages for the submission, [prepare the packages](https://msdn.microsoft.com/windows/uwp/publish/app-package-requirements) and add them to a ZIP archive.</span></span>

5. <span data-ttu-id="7af11-144">新しい申請用に必要な変更を行って[フライトの申請](#flight-submission-object)のデータを更新し、次のメソッドを実行して[パッケージ フライトの申請を更新](update-a-flight-submission.md)します。</span><span class="sxs-lookup"><span data-stu-id="7af11-144">Revise the [flight submission](#flight-submission-object) data with any required changes for the new submission, and execute the following method to [update the package flight submission](update-a-flight-submission.md).</span></span>

    ```
    PUT https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions/{submissionId}
    ```
      > [!NOTE]
      > <span data-ttu-id="7af11-145">申請用に新しいパッケージを追加する場合、ZIP アーカイブ内のアイコンのファイルの名前と相対パスを参照するように、申請データを更新してください。</span><span class="sxs-lookup"><span data-stu-id="7af11-145">If you are adding new packages for the submission, make sure you update the submission data to refer to the name and relative path of these files in the ZIP archive.</span></span>

4. <span data-ttu-id="7af11-146">申請用に新しいパッケージを追加する場合は、上記で呼び出した POST メソッドの応答本文に含まれていた SAS URI を使用して、ZIP アーカイブを [Azure Blob Storage](https://docs.microsoft.com/azure/storage/storage-introduction#blob-storage) にアップロードします。</span><span class="sxs-lookup"><span data-stu-id="7af11-146">If you are adding new packages for the submission, upload the ZIP archive to [Azure Blob storage](https://docs.microsoft.com/azure/storage/storage-introduction#blob-storage) using the SAS URI that was provided in the response body of the POST method you called earlier.</span></span> <span data-ttu-id="7af11-147">さまざまなプラットフォームでこれを行うために使用できる、次のようなさまざまな Azure ライブラリがあります。</span><span class="sxs-lookup"><span data-stu-id="7af11-147">There are different Azure libraries you can use to do this on a variety of platforms, including:</span></span>

    * [<span data-ttu-id="7af11-148">.NET 用 Azure Storage クライアント ライブラリ</span><span class="sxs-lookup"><span data-stu-id="7af11-148">Azure Storage Client Library for .NET</span></span>](https://docs.microsoft.com/azure/storage/storage-dotnet-how-to-use-blobs)
    * [<span data-ttu-id="7af11-149">Azure Storage SDK for Java</span><span class="sxs-lookup"><span data-stu-id="7af11-149">Azure Storage SDK for Java</span></span>](https://docs.microsoft.com/azure/storage/storage-java-how-to-use-blob-storage)
    * [<span data-ttu-id="7af11-150">Azure Storage SDK for Python</span><span class="sxs-lookup"><span data-stu-id="7af11-150">Azure Storage SDK for Python</span></span>](https://docs.microsoft.com/azure/storage/storage-python-how-to-use-blob-storage)

    <span data-ttu-id="7af11-151">次の C# コード例は、.NET 用 Azure Storage クライアント ライブラリの [CloudBlockBlob](https://msdn.microsoft.com/library/azure/microsoft.windowsazure.storage.blob.cloudblockblob.aspx) クラスを使用して ZIP アーカイブを Azure Blob Storage にアップロードする方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="7af11-151">The following C# code example demonstrates how to upload a ZIP archive to Azure Blob storage using the [CloudBlockBlob](https://msdn.microsoft.com/library/azure/microsoft.windowsazure.storage.blob.cloudblockblob.aspx) class in the Azure Storage Client Library for .NET.</span></span> <span data-ttu-id="7af11-152">この例では、ZIP アーカイブが既にストリーム オブジェクトに書き込まれていることを前提としています。</span><span class="sxs-lookup"><span data-stu-id="7af11-152">This example assumes that the ZIP archive has already been written to a stream object.</span></span>

    ```csharp
    string sasUrl = "https://productingestionbin1.blob.core.windows.net/ingestion/26920f66-b592-4439-9a9d-fb0f014902ec?sv=2014-02-14&sr=b&sig=usAN0kNFNnYE2tGQBI%2BARQWejX1Guiz7hdFtRhyK%2Bog%3D&se=2016-06-17T20:45:51Z&sp=rwl";
    Microsoft.WindowsAzure.Storage.Blob.CloudBlockBlob blockBob =
        new Microsoft.WindowsAzure.Storage.Blob.CloudBlockBlob(new System.Uri(sasUrl));
    await blockBob.UploadFromStreamAsync(stream);
    ```

5. <span data-ttu-id="7af11-153">次のメソッドを実行して、[パッケージ フライトの申請をコミット](commit-a-flight-submission.md)します。</span><span class="sxs-lookup"><span data-stu-id="7af11-153">[Commit the package flight submission](commit-a-flight-submission.md) by executing the following method.</span></span> <span data-ttu-id="7af11-154">これでパートナー センターに通知が申請に完了したことと、更新がアカウントに適用できるようになりましたする必要があります。</span><span class="sxs-lookup"><span data-stu-id="7af11-154">This will alert Partner Center that you are done with your submission and that your updates should now be applied to your account.</span></span>

    ```
    POST https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions/{submissionId}/commit
    ```

6. <span data-ttu-id="7af11-155">次のメソッドを実行して[パッケージ フライトの申請の状態を取得](get-status-for-a-flight-submission.md)して、コミット状態を確認します。</span><span class="sxs-lookup"><span data-stu-id="7af11-155">Check on the commit status by executing the following method to [get the status of the package flight submission](get-status-for-a-flight-submission.md).</span></span>

    ```
    GET https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions/{submissionId}/status
    ```

    <span data-ttu-id="7af11-156">申請の状態を確認するには、応答本文の *status* の値を確認します。</span><span class="sxs-lookup"><span data-stu-id="7af11-156">To confirm the submission status, review the *status* value in the response body.</span></span> <span data-ttu-id="7af11-157">この値が **CommitStarted** から **PreProcessing** (要求が成功した場合) または **CommitFailed** (要求でエラーが発生した場合) に変わっています。</span><span class="sxs-lookup"><span data-stu-id="7af11-157">This value should change from **CommitStarted** to either **PreProcessing** if the request succeeds or to **CommitFailed** if there are errors in the request.</span></span> <span data-ttu-id="7af11-158">エラーがある場合は、*statusDetails* フィールドにエラーについての詳細情報が含まれています。</span><span class="sxs-lookup"><span data-stu-id="7af11-158">If there are errors, the *statusDetails* field contains further details about the error.</span></span>

7. <span data-ttu-id="7af11-159">コミットが正常に処理されると、インジェストのために申請がストアに送信されます。</span><span class="sxs-lookup"><span data-stu-id="7af11-159">After the commit has successfully completed, the submission is sent to the Store for ingestion.</span></span> <span data-ttu-id="7af11-160">引き続き、以前のメソッドを使用するか、パートナー センターにアクセスして申請進行状況を監視できます。</span><span class="sxs-lookup"><span data-stu-id="7af11-160">You can continue to monitor the submission progress by using the previous method, or by visiting Partner Center.</span></span>

<span/>

## <a name="code-examples"></a><span data-ttu-id="7af11-161">コード例</span><span class="sxs-lookup"><span data-stu-id="7af11-161">Code examples</span></span>

<span data-ttu-id="7af11-162">次の記事では、さまざまなプログラミング言語でパッケージ フライトの申請を作成する方法を説明する詳しいコード例を紹介します。</span><span class="sxs-lookup"><span data-stu-id="7af11-162">The following articles provide detailed code examples that demonstrate how to create a package flight submission in several different programming languages:</span></span>

* [<span data-ttu-id="7af11-163">C# のコード例</span><span class="sxs-lookup"><span data-stu-id="7af11-163">C# code examples</span></span>](csharp-code-examples-for-the-windows-store-submission-api.md)
* [<span data-ttu-id="7af11-164">Java のコード例</span><span class="sxs-lookup"><span data-stu-id="7af11-164">Java code examples</span></span>](java-code-examples-for-the-windows-store-submission-api.md)
* [<span data-ttu-id="7af11-165">Python のコード例</span><span class="sxs-lookup"><span data-stu-id="7af11-165">Python code examples</span></span>](python-code-examples-for-the-windows-store-submission-api.md)

## <a name="storebroker-powershell-module"></a><span data-ttu-id="7af11-166">StoreBroker PowerShell モジュール</span><span class="sxs-lookup"><span data-stu-id="7af11-166">StoreBroker PowerShell module</span></span>

<span data-ttu-id="7af11-167">Microsoft Store 申請 API を直接呼び出す代わりに、API の上にコマンド ライン インターフェイスを実装するオープンソースの PowerShell モジュールも用意されています。</span><span class="sxs-lookup"><span data-stu-id="7af11-167">As an alternative to calling the Microsoft Store submission API directly, we also provide an open-source PowerShell module which implements a command-line interface on top of the API.</span></span> <span data-ttu-id="7af11-168">このモジュールは、[StoreBroker](https://aka.ms/storebroker) と呼ばれています。</span><span class="sxs-lookup"><span data-stu-id="7af11-168">This module is called [StoreBroker](https://aka.ms/storebroker).</span></span> <span data-ttu-id="7af11-169">このモジュールを使うと、Microsoft Store 申請 API を直接呼び出さずに、コマンド ラインからアプリ、フライト、アドオンの申請を管理できます。また、ソースを参照して、この API を呼び出す方法の例を確認することもできます。</span><span class="sxs-lookup"><span data-stu-id="7af11-169">You can use this module to manage your app, flight, and add-on submissions from the command line instead of calling the Microsoft Store submission API directly, or you can simply browse the source to see more examples for how to call this API.</span></span> <span data-ttu-id="7af11-170">StoreBroker モジュールは、多くのファースト パーティ アプリケーションをストアに申請する主要な方法として Microsoft 内で積極的に使っています。</span><span class="sxs-lookup"><span data-stu-id="7af11-170">The StoreBroker module is actively used within Microsoft as the primary way that many first-party applications are submitted to the Store.</span></span>

<span data-ttu-id="7af11-171">詳しくは、[GitHub の StoreBroker に関するページ](https://aka.ms/storebroker)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7af11-171">For more information, see our [StoreBroker page on GitHub](https://aka.ms/storebroker).</span></span>

<span id="manage-gradual-package-rollout">

## <a name="manage-a-gradual-package-rollout-for-a-package-flight-submission"></a><span data-ttu-id="7af11-172">パッケージ フライトの申請の段階的なパッケージのロールアウトを管理する</span><span class="sxs-lookup"><span data-stu-id="7af11-172">Manage a gradual package rollout for a package flight submission</span></span>

<span data-ttu-id="7af11-173">パッケージ フライトの申請で更新されたパッケージを、アプリの Windows 10 のユーザーの一部に、段階的にロールアウトできます。</span><span class="sxs-lookup"><span data-stu-id="7af11-173">You can gradually roll out the updated packages in a package flight submission to a percentage of your app’s customers on Windows 10.</span></span> <span data-ttu-id="7af11-174">これにより、更新に確信が持てるよう、特定のパッケージのフィードバックと分析データを監視してから、より広くロールアウトできます。</span><span class="sxs-lookup"><span data-stu-id="7af11-174">This allows you to monitor feedback and analytic data for the specific packages to make sure you’re confident about the update before rolling it out more broadly.</span></span> <span data-ttu-id="7af11-175">新しい申請を作成することなく、公開された申請のロールアウトの割合を変更する (または更新を停止する) ことができます。</span><span class="sxs-lookup"><span data-stu-id="7af11-175">You can change the rollout percentage (or halt the update) for a published submission without having to create a new submission.</span></span> <span data-ttu-id="7af11-176">詳細についてなどを有効にして、パートナー センターで、段階的なパッケージのロールアウトを管理する方法については、[この記事](../publish/gradual-package-rollout.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="7af11-176">For more details, including instructions for how to enable and manage a gradual package rollout in Partner Center, see [this article](../publish/gradual-package-rollout.md).</span></span>

<span data-ttu-id="7af11-177">パッケージ フライトの申請の段階的なパッケージのロールアウトをプログラムによって有効化するには、Microsoft Store 申請 API のメソッドを使用して、次の手順に従います。</span><span class="sxs-lookup"><span data-stu-id="7af11-177">To programmatically enable a gradual package rollout for a package flight submission, follow this process using methods in the Microsoft Store submission API:</span></span>

  1. <span data-ttu-id="7af11-178">[パッケージ フライトの申請を作成](create-a-flight-submission.md)するか、[パッケージ フライトの申請を取得](get-a-flight-submission.md)します。</span><span class="sxs-lookup"><span data-stu-id="7af11-178">[Create a package flight submission](create-a-flight-submission.md) or [get a package flight submission](get-a-flight-submission.md).</span></span>
  2. <span data-ttu-id="7af11-179">応答データで、[packageRollout](#package-rollout-object) リソースを探し、*[isPackageRollout]* フィールドを [true] に設定し、*[packageRolloutPercentage]* フィールドに、アプリのユーザーが更新されたパッケージを取得する割合を設定します。</span><span class="sxs-lookup"><span data-stu-id="7af11-179">In the response data, locate the [packageRollout](#package-rollout-object) resource, set the *isPackageRollout* field to true, and set the *packageRolloutPercentage* field to the percentage of your app's customers who should get the updated packages.</span></span>
  3. <span data-ttu-id="7af11-180">更新されたパッケージ フライトの申請のデータを[パッケージ フライトの申請を更新する](update-a-flight-submission.md)メソッドに渡します。</span><span class="sxs-lookup"><span data-stu-id="7af11-180">Pass the updated package flight submission data to the [update a package flight submission](update-a-flight-submission.md) method.</span></span>

<span data-ttu-id="7af11-181">パッケージ フライトの申請の段階的なパッケージのロールアウトが有効化された後、段階的なロールアウトをプログラムで取得、更新、停止、または完了するには、次のメソッドを使用できます。</span><span class="sxs-lookup"><span data-stu-id="7af11-181">After a gradual package rollout is enabled for a package flight submission, you can use the following methods to programmatically get, update, halt, or finalize the gradual rollout.</span></span>

<table>
<colgroup>
<col width="10%" />
<col width="30%" />
<col width="60%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="7af11-182">メソッド</span><span class="sxs-lookup"><span data-stu-id="7af11-182">Method</span></span></th>
<th align="left"><span data-ttu-id="7af11-183">URI</span><span class="sxs-lookup"><span data-stu-id="7af11-183">URI</span></span></th>
<th align="left"><span data-ttu-id="7af11-184">説明</span><span class="sxs-lookup"><span data-stu-id="7af11-184">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr>
<td align="left"><span data-ttu-id="7af11-185">GET</span><span class="sxs-lookup"><span data-stu-id="7af11-185">GET</span></span></td>
<td align="left">https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions/{submissionId}/packagerollout</td>
<td align="left"><a href="get-package-rollout-info-for-a-flight-submission.md"><span data-ttu-id="7af11-186">パッケージ フライトの申請の段階的なロールアウトの情報を取得します</span><span class="sxs-lookup"><span data-stu-id="7af11-186">Get the gradual rollout info for a package flight submission</span></span></a></td>
</tr>
<tr>
<td align="left"><span data-ttu-id="7af11-187">POST</span><span class="sxs-lookup"><span data-stu-id="7af11-187">POST</span></span></td>
<td align="left">https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions/{submissionId}/updatepackagerolloutpercentage</td>
<td align="left"><a href="update-the-package-rollout-percentage-for-a-flight-submission.md"><span data-ttu-id="7af11-188">パッケージ フライトの申請の段階的なロールアウトの割合を更新します</span><span class="sxs-lookup"><span data-stu-id="7af11-188">Update the gradual rollout percentage for a package flight submission</span></span></a></td>
</tr>
<tr>
<td align="left"><span data-ttu-id="7af11-189">POST</span><span class="sxs-lookup"><span data-stu-id="7af11-189">POST</span></span></td>
<td align="left">https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions/{submissionId}/haltpackagerollout</td>
<td align="left"><a href="halt-the-package-rollout-for-a-flight-submission.md"><span data-ttu-id="7af11-190">パッケージ フライトの申請の段階的なロールアウトを停止します</span><span class="sxs-lookup"><span data-stu-id="7af11-190">Halt the gradual rollout for a package flight submission</span></span></a></td>
</tr>
<tr>
<td align="left"><span data-ttu-id="7af11-191">POST</span><span class="sxs-lookup"><span data-stu-id="7af11-191">POST</span></span></td>
<td align="left">https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions/{submissionId}/finalizepackagerollout</td>
<td align="left"><a href="finalize-the-package-rollout-for-a-flight-submission.md"><span data-ttu-id="7af11-192">パッケージ フライトの申請の段階的なロールアウトの情報を完了します</span><span class="sxs-lookup"><span data-stu-id="7af11-192">Finalize the gradual rollout for a package flight submission</span></span></a></td>
</tr>
</tbody>
</table>

<span/>

## <a name="data-resources"></a><span data-ttu-id="7af11-193">データ リソース</span><span class="sxs-lookup"><span data-stu-id="7af11-193">Data resources</span></span>

<span data-ttu-id="7af11-194">パッケージ フライトの申請を管理するための Microsoft Store 申請 API のメソッドでは、次の JSON データ リソースが使われます。</span><span class="sxs-lookup"><span data-stu-id="7af11-194">The Microsoft Store submission API methods for managing package flight submissions use the following JSON data resources.</span></span>

<span id="flight-submission-object" />

### <a name="flight-submission-resource"></a><span data-ttu-id="7af11-195">フライトの申請のリソース</span><span class="sxs-lookup"><span data-stu-id="7af11-195">Flight submission resource</span></span>

<span data-ttu-id="7af11-196">このリソースは、パッケージ フライトの申請を記述しています。</span><span class="sxs-lookup"><span data-stu-id="7af11-196">This resource describes a package flight submission.</span></span>

```json
{
  "id": "1152921504621243649",
  "flightId": "cd2e368a-0da5-4026-9f34-0e7934bc6f23",
  "status": "PendingCommit",
  "statusDetails": {
    "errors": [],
    "warnings": [],
    "certificationReports": []
  },
  "flightPackages": [
    {
      "fileName": "newPackage.appx",
      "fileStatus": "PendingUpload",
      "id": "",
      "version": "1.0.0.0",
      "languages": ["en-us"],
      "capabilities": [],
      "minimumDirectXVersion": "None",
      "minimumSystemRam": "None"
    }
  ],
  "packageDeliveryOptions": {
    "packageRollout": {
        "isPackageRollout": false,
        "packageRolloutPercentage": 0.0,
        "packageRolloutStatus": "PackageRolloutNotStarted",
        "fallbackSubmissionId": "0"
    },
    "isMandatoryUpdate": false,
    "mandatoryUpdateEffectiveDate": "1601-01-01T00:00:00.0000000Z"
  },
  "fileUploadUrl": "https://productingestionbin1.blob.core.windows.net/ingestion/8b389577-5d5e-4cbe-a744-1ff2e97a9eb8?sv=2014-02-14&sr=b&sig=wgMCQPjPDkuuxNLkeG35rfHaMToebCxBNMPw7WABdXU%3D&se=2016-06-17T21:29:44Z&sp=rwl",
  "targetPublishMode": "Immediate",
  "targetPublishDate": "",
  "notesForCertification": "No special steps are required for certification of this app."
}
```

<span data-ttu-id="7af11-197">このリソースには、次の値があります。</span><span class="sxs-lookup"><span data-stu-id="7af11-197">This resource has the following values.</span></span>

| <span data-ttu-id="7af11-198">値</span><span class="sxs-lookup"><span data-stu-id="7af11-198">Value</span></span>      | <span data-ttu-id="7af11-199">型</span><span class="sxs-lookup"><span data-stu-id="7af11-199">Type</span></span>   | <span data-ttu-id="7af11-200">説明</span><span class="sxs-lookup"><span data-stu-id="7af11-200">Description</span></span>              |
|------------|--------|------------------------------|
| <span data-ttu-id="7af11-201">id</span><span class="sxs-lookup"><span data-stu-id="7af11-201">id</span></span>            | <span data-ttu-id="7af11-202">string</span><span class="sxs-lookup"><span data-stu-id="7af11-202">string</span></span>  | <span data-ttu-id="7af11-203">申請の ID です。</span><span class="sxs-lookup"><span data-stu-id="7af11-203">The ID for the submission.</span></span>  |
| <span data-ttu-id="7af11-204">flightId</span><span class="sxs-lookup"><span data-stu-id="7af11-204">flightId</span></span>           | <span data-ttu-id="7af11-205">string</span><span class="sxs-lookup"><span data-stu-id="7af11-205">string</span></span>  |  <span data-ttu-id="7af11-206">申請が関連付けられているパッケージ フライトの ID です。</span><span class="sxs-lookup"><span data-stu-id="7af11-206">The ID of the package flight that the submission is associated with.</span></span>  |  
| <span data-ttu-id="7af11-207">status</span><span class="sxs-lookup"><span data-stu-id="7af11-207">status</span></span>           | <span data-ttu-id="7af11-208">string</span><span class="sxs-lookup"><span data-stu-id="7af11-208">string</span></span>  | <span data-ttu-id="7af11-209">申請の状態。</span><span class="sxs-lookup"><span data-stu-id="7af11-209">The status of the submission.</span></span> <span data-ttu-id="7af11-210">次のいずれかの値を使用できます。</span><span class="sxs-lookup"><span data-stu-id="7af11-210">This can be one of the following values:</span></span> <ul><li><span data-ttu-id="7af11-211">None</span><span class="sxs-lookup"><span data-stu-id="7af11-211">None</span></span></li><li><span data-ttu-id="7af11-212">Canceled</span><span class="sxs-lookup"><span data-stu-id="7af11-212">Canceled</span></span></li><li><span data-ttu-id="7af11-213">PendingCommit</span><span class="sxs-lookup"><span data-stu-id="7af11-213">PendingCommit</span></span></li><li><span data-ttu-id="7af11-214">CommitStarted</span><span class="sxs-lookup"><span data-stu-id="7af11-214">CommitStarted</span></span></li><li><span data-ttu-id="7af11-215">CommitFailed</span><span class="sxs-lookup"><span data-stu-id="7af11-215">CommitFailed</span></span></li><li><span data-ttu-id="7af11-216">PendingPublication</span><span class="sxs-lookup"><span data-stu-id="7af11-216">PendingPublication</span></span></li><li><span data-ttu-id="7af11-217">Publishing</span><span class="sxs-lookup"><span data-stu-id="7af11-217">Publishing</span></span></li><li><span data-ttu-id="7af11-218">Published</span><span class="sxs-lookup"><span data-stu-id="7af11-218">Published</span></span></li><li><span data-ttu-id="7af11-219">PublishFailed</span><span class="sxs-lookup"><span data-stu-id="7af11-219">PublishFailed</span></span></li><li><span data-ttu-id="7af11-220">PreProcessing</span><span class="sxs-lookup"><span data-stu-id="7af11-220">PreProcessing</span></span></li><li><span data-ttu-id="7af11-221">PreProcessingFailed</span><span class="sxs-lookup"><span data-stu-id="7af11-221">PreProcessingFailed</span></span></li><li><span data-ttu-id="7af11-222">Certification</span><span class="sxs-lookup"><span data-stu-id="7af11-222">Certification</span></span></li><li><span data-ttu-id="7af11-223">CertificationFailed</span><span class="sxs-lookup"><span data-stu-id="7af11-223">CertificationFailed</span></span></li><li><span data-ttu-id="7af11-224">Release</span><span class="sxs-lookup"><span data-stu-id="7af11-224">Release</span></span></li><li><span data-ttu-id="7af11-225">ReleaseFailed</span><span class="sxs-lookup"><span data-stu-id="7af11-225">ReleaseFailed</span></span></li></ul>   |
| <span data-ttu-id="7af11-226">statusDetails</span><span class="sxs-lookup"><span data-stu-id="7af11-226">statusDetails</span></span>           | <span data-ttu-id="7af11-227">object</span><span class="sxs-lookup"><span data-stu-id="7af11-227">object</span></span>  |  <span data-ttu-id="7af11-228">エラーに関する情報など、申請のステータスに関する追加情報が保持される[ステータスの詳細に関するリソース](#status-details-object)です。</span><span class="sxs-lookup"><span data-stu-id="7af11-228">A [status details resource](#status-details-object) that contains additional details about the status of the submission, including information about any errors.</span></span>  |
| <span data-ttu-id="7af11-229">flightPackages</span><span class="sxs-lookup"><span data-stu-id="7af11-229">flightPackages</span></span>           | <span data-ttu-id="7af11-230">array</span><span class="sxs-lookup"><span data-stu-id="7af11-230">array</span></span>  | <span data-ttu-id="7af11-231">申請の各パッケージに関する詳細を提供する[フライト パッケージ リソース](#flight-package-object)が含まれています。</span><span class="sxs-lookup"><span data-stu-id="7af11-231">Contains [flight package resources](#flight-package-object) that provide details about each package in the submission.</span></span>   |
| <span data-ttu-id="7af11-232">packageDeliveryOptions</span><span class="sxs-lookup"><span data-stu-id="7af11-232">packageDeliveryOptions</span></span>    | <span data-ttu-id="7af11-233">object</span><span class="sxs-lookup"><span data-stu-id="7af11-233">object</span></span>  | <span data-ttu-id="7af11-234">申請の段階的なパッケージのロールアウトと必須の更新の設定が含まれた[パッケージ配布オプション リソース](#package-delivery-options-object)です。</span><span class="sxs-lookup"><span data-stu-id="7af11-234">A [package delivery options resource](#package-delivery-options-object) that contains gradual package rollout and mandatory update settings for the submission.</span></span>   |
| <span data-ttu-id="7af11-235">fileUploadUrl</span><span class="sxs-lookup"><span data-stu-id="7af11-235">fileUploadUrl</span></span>           | <span data-ttu-id="7af11-236">string</span><span class="sxs-lookup"><span data-stu-id="7af11-236">string</span></span>  | <span data-ttu-id="7af11-237">申請のパッケージのアップロードに使用する共有アクセス署名 (SAS) URI です。</span><span class="sxs-lookup"><span data-stu-id="7af11-237">The shared access signature (SAS) URI for uploading any packages for the submission.</span></span> <span data-ttu-id="7af11-238">申請用に新しいパッケージを追加する場合は、パッケージを含む ZIP アーカイブをこの URI にアップロードします。</span><span class="sxs-lookup"><span data-stu-id="7af11-238">If you are adding new packages for the submission, upload the ZIP archive that contains the packages to this URI.</span></span> <span data-ttu-id="7af11-239">詳しくは、「[パッケージ フライトの申請の作成](#create-a-package-flight-submission)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7af11-239">For more information, see [Create a package flight submission](#create-a-package-flight-submission).</span></span>  |
| <span data-ttu-id="7af11-240">targetPublishMode</span><span class="sxs-lookup"><span data-stu-id="7af11-240">targetPublishMode</span></span>           | <span data-ttu-id="7af11-241">string</span><span class="sxs-lookup"><span data-stu-id="7af11-241">string</span></span>  | <span data-ttu-id="7af11-242">申請の公開モードです。</span><span class="sxs-lookup"><span data-stu-id="7af11-242">The publish mode for the submission.</span></span> <span data-ttu-id="7af11-243">次のいずれかの値を使用できます。</span><span class="sxs-lookup"><span data-stu-id="7af11-243">This can be one of the following values:</span></span> <ul><li><span data-ttu-id="7af11-244">Immediate</span><span class="sxs-lookup"><span data-stu-id="7af11-244">Immediate</span></span></li><li><span data-ttu-id="7af11-245">Manual</span><span class="sxs-lookup"><span data-stu-id="7af11-245">Manual</span></span></li><li><span data-ttu-id="7af11-246">SpecificDate</span><span class="sxs-lookup"><span data-stu-id="7af11-246">SpecificDate</span></span></li></ul> |
| <span data-ttu-id="7af11-247">targetPublishDate</span><span class="sxs-lookup"><span data-stu-id="7af11-247">targetPublishDate</span></span>           | <span data-ttu-id="7af11-248">string</span><span class="sxs-lookup"><span data-stu-id="7af11-248">string</span></span>  | <span data-ttu-id="7af11-249">*targetPublishMode* が SpecificDate に設定されている場合、ISO 8601 形式での申請の公開日です。</span><span class="sxs-lookup"><span data-stu-id="7af11-249">The publish date for the submission in ISO 8601 format, if the *targetPublishMode* is set to SpecificDate.</span></span>  |
| <span data-ttu-id="7af11-250">notesForCertification</span><span class="sxs-lookup"><span data-stu-id="7af11-250">notesForCertification</span></span>           | <span data-ttu-id="7af11-251">string</span><span class="sxs-lookup"><span data-stu-id="7af11-251">string</span></span>  |  <span data-ttu-id="7af11-252">テスト アカウントの資格情報や、機能のアクセスおよび検証手順など、審査担当者に対して追加情報を提供します。</span><span class="sxs-lookup"><span data-stu-id="7af11-252">Provides additional info for the certification testers, such as test account credentials and steps to access and verify features.</span></span> <span data-ttu-id="7af11-253">詳しくは、「[認定の注意書き](https://msdn.microsoft.com/windows/uwp/publish/notes-for-certification)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7af11-253">For more information, see [Notes for certification](https://msdn.microsoft.com/windows/uwp/publish/notes-for-certification).</span></span> |

<span id="status-details-object" />

### <a name="status-details-resource"></a><span data-ttu-id="7af11-254">ステータスの詳細に関するリソース</span><span class="sxs-lookup"><span data-stu-id="7af11-254">Status details resource</span></span>

<span data-ttu-id="7af11-255">このリソースには、申請の状態についての追加情報が保持されます。</span><span class="sxs-lookup"><span data-stu-id="7af11-255">This resource contains additional details about the status of a submission.</span></span> <span data-ttu-id="7af11-256">このリソースには、次の値があります。</span><span class="sxs-lookup"><span data-stu-id="7af11-256">This resource has the following values.</span></span>

| <span data-ttu-id="7af11-257">値</span><span class="sxs-lookup"><span data-stu-id="7af11-257">Value</span></span>           | <span data-ttu-id="7af11-258">型</span><span class="sxs-lookup"><span data-stu-id="7af11-258">Type</span></span>    | <span data-ttu-id="7af11-259">説明</span><span class="sxs-lookup"><span data-stu-id="7af11-259">Description</span></span>                   |
|-----------------|---------|------|
|  <span data-ttu-id="7af11-260">errors</span><span class="sxs-lookup"><span data-stu-id="7af11-260">errors</span></span>               |    <span data-ttu-id="7af11-261">object</span><span class="sxs-lookup"><span data-stu-id="7af11-261">object</span></span>     |   <span data-ttu-id="7af11-262">申請のエラーの詳細が保持される[ステータスの詳細リソース](#status-detail-object)の配列です。</span><span class="sxs-lookup"><span data-stu-id="7af11-262">An array of [status detail resources](#status-detail-object) that contain error details for the submission.</span></span>   |     
|  <span data-ttu-id="7af11-263">warnings</span><span class="sxs-lookup"><span data-stu-id="7af11-263">warnings</span></span>               |   <span data-ttu-id="7af11-264">object</span><span class="sxs-lookup"><span data-stu-id="7af11-264">object</span></span>      | <span data-ttu-id="7af11-265">申請の警告の詳細が保持される[ステータスの詳細リソース](#status-detail-object)の配列です。</span><span class="sxs-lookup"><span data-stu-id="7af11-265">An array of [status detail resources](#status-detail-object) that contain warning details for the submission.</span></span>     |
|  <span data-ttu-id="7af11-266">certificationReports</span><span class="sxs-lookup"><span data-stu-id="7af11-266">certificationReports</span></span>               |     <span data-ttu-id="7af11-267">object</span><span class="sxs-lookup"><span data-stu-id="7af11-267">object</span></span>    |   <span data-ttu-id="7af11-268">申請の認定レポート データへのアクセスを提供する[認定レポート リソース](#certification-report-object)です。</span><span class="sxs-lookup"><span data-stu-id="7af11-268">An array of [certification report resources](#certification-report-object) that provide access to the certification report data for the submission.</span></span> <span data-ttu-id="7af11-269">認定されなかった場合に、これらのレポートから詳しい情報を知ることができます。</span><span class="sxs-lookup"><span data-stu-id="7af11-269">You can examine these reports for more information if the certification fails.</span></span>    |  


<span id="status-detail-object" />

### <a name="status-detail-resource"></a><span data-ttu-id="7af11-270">ステータスの詳細に関するリソース</span><span class="sxs-lookup"><span data-stu-id="7af11-270">Status detail resource</span></span>

<span data-ttu-id="7af11-271">このリソースには、申請に関連するエラーや警告についての追加情報が保持されます。</span><span class="sxs-lookup"><span data-stu-id="7af11-271">This resource contains additional information about any related errors or warnings for a submission.</span></span> <span data-ttu-id="7af11-272">このリソースには、次の値があります。</span><span class="sxs-lookup"><span data-stu-id="7af11-272">This resource has the following values.</span></span>

| <span data-ttu-id="7af11-273">値</span><span class="sxs-lookup"><span data-stu-id="7af11-273">Value</span></span>           | <span data-ttu-id="7af11-274">型</span><span class="sxs-lookup"><span data-stu-id="7af11-274">Type</span></span>    | <span data-ttu-id="7af11-275">説明</span><span class="sxs-lookup"><span data-stu-id="7af11-275">Description</span></span>       |
|-----------------|---------|------|
|  <span data-ttu-id="7af11-276">code</span><span class="sxs-lookup"><span data-stu-id="7af11-276">code</span></span>               |    <span data-ttu-id="7af11-277">string</span><span class="sxs-lookup"><span data-stu-id="7af11-277">string</span></span>     |   <span data-ttu-id="7af11-278">エラーや警告の種類を説明する[申請ステータス コード](#submission-status-code)です。</span><span class="sxs-lookup"><span data-stu-id="7af11-278">A [submission status code](#submission-status-code) that describes the type of error or warning.</span></span> |  
|  <span data-ttu-id="7af11-279">details</span><span class="sxs-lookup"><span data-stu-id="7af11-279">details</span></span>               |     <span data-ttu-id="7af11-280">string</span><span class="sxs-lookup"><span data-stu-id="7af11-280">string</span></span>    |  <span data-ttu-id="7af11-281">問題についての詳細が含まれるメッセージです。</span><span class="sxs-lookup"><span data-stu-id="7af11-281">A message with more details about the issue.</span></span>     |


<span id="certification-report-object" />

### <a name="certification-report-resource"></a><span data-ttu-id="7af11-282">認定レポート リソース</span><span class="sxs-lookup"><span data-stu-id="7af11-282">Certification report resource</span></span>

<span data-ttu-id="7af11-283">このリソースは、申請の認定レポート データへのアクセスを提供します。</span><span class="sxs-lookup"><span data-stu-id="7af11-283">This resource provides access to the certification report data for a submission.</span></span> <span data-ttu-id="7af11-284">このリソースには、次の値があります。</span><span class="sxs-lookup"><span data-stu-id="7af11-284">This resource has the following values.</span></span>

| <span data-ttu-id="7af11-285">値</span><span class="sxs-lookup"><span data-stu-id="7af11-285">Value</span></span>           | <span data-ttu-id="7af11-286">型</span><span class="sxs-lookup"><span data-stu-id="7af11-286">Type</span></span>    | <span data-ttu-id="7af11-287">説明</span><span class="sxs-lookup"><span data-stu-id="7af11-287">Description</span></span>         |
|-----------------|---------|------|
|     <span data-ttu-id="7af11-288">date</span><span class="sxs-lookup"><span data-stu-id="7af11-288">date</span></span>            |    <span data-ttu-id="7af11-289">string</span><span class="sxs-lookup"><span data-stu-id="7af11-289">string</span></span>     |  <span data-ttu-id="7af11-290">日付と ISO 8601 形式でレポートが生成された時刻。</span><span class="sxs-lookup"><span data-stu-id="7af11-290">The date and time the report was generated, in ISO 8601 format.</span></span>    |
|     <span data-ttu-id="7af11-291">reportUrl</span><span class="sxs-lookup"><span data-stu-id="7af11-291">reportUrl</span></span>            |    <span data-ttu-id="7af11-292">string</span><span class="sxs-lookup"><span data-stu-id="7af11-292">string</span></span>     |  <span data-ttu-id="7af11-293">レポートにアクセスできる URL です。</span><span class="sxs-lookup"><span data-stu-id="7af11-293">The URL at which you can access the report.</span></span>    |


<span id="flight-package-object" />

### <a name="flight-package-resource"></a><span data-ttu-id="7af11-294">フライト パッケージ リソース</span><span class="sxs-lookup"><span data-stu-id="7af11-294">Flight package resource</span></span>

<span data-ttu-id="7af11-295">このリソースは、申請に含まれるパッケージについての詳細情報を提供します。</span><span class="sxs-lookup"><span data-stu-id="7af11-295">This resource provides details about a package in a submission.</span></span>

```json
{
  "flightPackages": [
    {
      "fileName": "newPackage.appx",
      "fileStatus": "PendingUpload",
      "id": "",
      "version": "1.0.0.0",
      "languages": ["en-us"],
      "capabilities": [],
      "minimumDirectXVersion": "None",
      "minimumSystemRam": "None"
    }
  ],
}
```

<span data-ttu-id="7af11-296">このリソースには、次の値があります。</span><span class="sxs-lookup"><span data-stu-id="7af11-296">This resource has the following values.</span></span>

> [!NOTE]
> <span data-ttu-id="7af11-297">[パッケージ フライトの申請の更新](update-a-flight-submission.md)のメソッドを呼び出す場合、要求本文に必要なのは、このオブジェクトの *fileName*、*fileStatus*、*minimumDirectXVersion*、*minimumSystemRam* の値のみです。</span><span class="sxs-lookup"><span data-stu-id="7af11-297">When calling the [update a package flight submission](update-a-flight-submission.md) method, only the *fileName*, *fileStatus*, *minimumDirectXVersion*, and *minimumSystemRam* values of this object are required in the request body.</span></span> <span data-ttu-id="7af11-298">パートナー センターによっては、他の値が設定されます。</span><span class="sxs-lookup"><span data-stu-id="7af11-298">The other values are populated by Partner Center.</span></span>

| <span data-ttu-id="7af11-299">値</span><span class="sxs-lookup"><span data-stu-id="7af11-299">Value</span></span>           | <span data-ttu-id="7af11-300">型</span><span class="sxs-lookup"><span data-stu-id="7af11-300">Type</span></span>    | <span data-ttu-id="7af11-301">説明</span><span class="sxs-lookup"><span data-stu-id="7af11-301">Description</span></span>              |
|-----------------|---------|------|
| <span data-ttu-id="7af11-302">fileName</span><span class="sxs-lookup"><span data-stu-id="7af11-302">fileName</span></span>   |   <span data-ttu-id="7af11-303">string</span><span class="sxs-lookup"><span data-stu-id="7af11-303">string</span></span>      |  <span data-ttu-id="7af11-304">パッケージの名前。</span><span class="sxs-lookup"><span data-stu-id="7af11-304">The name of the package.</span></span>    |  
| <span data-ttu-id="7af11-305">fileStatus</span><span class="sxs-lookup"><span data-stu-id="7af11-305">fileStatus</span></span>    | <span data-ttu-id="7af11-306">string</span><span class="sxs-lookup"><span data-stu-id="7af11-306">string</span></span>    |  <span data-ttu-id="7af11-307">パッケージの状態です。</span><span class="sxs-lookup"><span data-stu-id="7af11-307">The status of the package.</span></span> <span data-ttu-id="7af11-308">次のいずれかの値を使用できます。</span><span class="sxs-lookup"><span data-stu-id="7af11-308">This can be one of the following values:</span></span> <ul><li><span data-ttu-id="7af11-309">None</span><span class="sxs-lookup"><span data-stu-id="7af11-309">None</span></span></li><li><span data-ttu-id="7af11-310">PendingUpload</span><span class="sxs-lookup"><span data-stu-id="7af11-310">PendingUpload</span></span></li><li><span data-ttu-id="7af11-311">Uploaded</span><span class="sxs-lookup"><span data-stu-id="7af11-311">Uploaded</span></span></li><li><span data-ttu-id="7af11-312">PendingDelete</span><span class="sxs-lookup"><span data-stu-id="7af11-312">PendingDelete</span></span></li></ul>    |  
| <span data-ttu-id="7af11-313">id</span><span class="sxs-lookup"><span data-stu-id="7af11-313">id</span></span>    |  <span data-ttu-id="7af11-314">string</span><span class="sxs-lookup"><span data-stu-id="7af11-314">string</span></span>   |  <span data-ttu-id="7af11-315">パッケージを一意に識別する ID です。</span><span class="sxs-lookup"><span data-stu-id="7af11-315">An ID that uniquely identifies the package.</span></span> <span data-ttu-id="7af11-316">この値は、パートナー センターによって使用されます。</span><span class="sxs-lookup"><span data-stu-id="7af11-316">This value is used by Partner Center.</span></span>   |     
| <span data-ttu-id="7af11-317">version</span><span class="sxs-lookup"><span data-stu-id="7af11-317">version</span></span>    |  <span data-ttu-id="7af11-318">string</span><span class="sxs-lookup"><span data-stu-id="7af11-318">string</span></span>   |  <span data-ttu-id="7af11-319">アプリ パッケージのバージョンです。</span><span class="sxs-lookup"><span data-stu-id="7af11-319">The version of the app package.</span></span> <span data-ttu-id="7af11-320">詳しくは、「[パッケージ バージョンの番号付け](https://msdn.microsoft.com/windows/uwp/publish/package-version-numbering)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7af11-320">For more information, see [Package version numbering](https://msdn.microsoft.com/windows/uwp/publish/package-version-numbering).</span></span>   |   
| <span data-ttu-id="7af11-321">architecture</span><span class="sxs-lookup"><span data-stu-id="7af11-321">architecture</span></span>    |  <span data-ttu-id="7af11-322">string</span><span class="sxs-lookup"><span data-stu-id="7af11-322">string</span></span>   |  <span data-ttu-id="7af11-323">アプリ パッケージのアーキテクチャ (ARM など) です。</span><span class="sxs-lookup"><span data-stu-id="7af11-323">The architecture of the app package (for example, ARM).</span></span>   |     
| <span data-ttu-id="7af11-324">languages</span><span class="sxs-lookup"><span data-stu-id="7af11-324">languages</span></span>    | <span data-ttu-id="7af11-325">array</span><span class="sxs-lookup"><span data-stu-id="7af11-325">array</span></span>    |  <span data-ttu-id="7af11-326">アプリがサポートする言語の言語コードの配列です。</span><span class="sxs-lookup"><span data-stu-id="7af11-326">An array of language codes for the languages the app supports.</span></span> <span data-ttu-id="7af11-327">詳しくは、「[サポートされる言語パックと既定の](https://msdn.microsoft.com/windows/uwp/publish/supported-languages)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7af11-327">For more information, see For more information, see [Supported languages](https://msdn.microsoft.com/windows/uwp/publish/supported-languages).</span></span>    |     
| <span data-ttu-id="7af11-328">capabilities</span><span class="sxs-lookup"><span data-stu-id="7af11-328">capabilities</span></span>    |  <span data-ttu-id="7af11-329">array</span><span class="sxs-lookup"><span data-stu-id="7af11-329">array</span></span>   |  <span data-ttu-id="7af11-330">パッケージに必要な機能の配列です。</span><span class="sxs-lookup"><span data-stu-id="7af11-330">An array of capabilities required by the package.</span></span> <span data-ttu-id="7af11-331">機能について詳しくは、「[アプリ機能の宣言](https://msdn.microsoft.com/windows/uwp/packaging/app-capability-declarations)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7af11-331">For more information about capabilities, see [App capability declarations](https://msdn.microsoft.com/windows/uwp/packaging/app-capability-declarations).</span></span>   |     
| <span data-ttu-id="7af11-332">minimumDirectXVersion</span><span class="sxs-lookup"><span data-stu-id="7af11-332">minimumDirectXVersion</span></span>    |  <span data-ttu-id="7af11-333">string</span><span class="sxs-lookup"><span data-stu-id="7af11-333">string</span></span>   |  <span data-ttu-id="7af11-334">アプリ パッケージによってサポートされる DirectX の最小バージョンです。</span><span class="sxs-lookup"><span data-stu-id="7af11-334">The minimum DirectX version that is supported by the app package.</span></span> <span data-ttu-id="7af11-335">これは Windows 8.x をターゲットにするアプリにしか設定できません。その他バージョンをターゲットにするアプリでは無視されます。</span><span class="sxs-lookup"><span data-stu-id="7af11-335">This can be set only for apps that target Windows 8.x; it is ignored for apps that target other versions.</span></span> <span data-ttu-id="7af11-336">次のいずれかの値を使用できます。</span><span class="sxs-lookup"><span data-stu-id="7af11-336">This can be one of the following values:</span></span> <ul><li><span data-ttu-id="7af11-337">None</span><span class="sxs-lookup"><span data-stu-id="7af11-337">None</span></span></li><li><span data-ttu-id="7af11-338">DirectX93</span><span class="sxs-lookup"><span data-stu-id="7af11-338">DirectX93</span></span></li><li><span data-ttu-id="7af11-339">DirectX100</span><span class="sxs-lookup"><span data-stu-id="7af11-339">DirectX100</span></span></li></ul>   |     
| <span data-ttu-id="7af11-340">minimumSystemRam</span><span class="sxs-lookup"><span data-stu-id="7af11-340">minimumSystemRam</span></span>    | <span data-ttu-id="7af11-341">string</span><span class="sxs-lookup"><span data-stu-id="7af11-341">string</span></span>    |  <span data-ttu-id="7af11-342">アプリ パッケージに必要な RAM の最小サイズです。</span><span class="sxs-lookup"><span data-stu-id="7af11-342">The minimum RAM that is required by the app package.</span></span> <span data-ttu-id="7af11-343">これは Windows 8.x をターゲットにするアプリにしか設定できません。その他バージョンをターゲットにするアプリでは無視されます。</span><span class="sxs-lookup"><span data-stu-id="7af11-343">This can be set only for apps that target Windows 8.x; it is ignored for apps that target other versions.</span></span> <span data-ttu-id="7af11-344">次のいずれかの値を使用できます。</span><span class="sxs-lookup"><span data-stu-id="7af11-344">This can be one of the following values:</span></span> <ul><li><span data-ttu-id="7af11-345">None</span><span class="sxs-lookup"><span data-stu-id="7af11-345">None</span></span></li><li><span data-ttu-id="7af11-346">Memory2GB</span><span class="sxs-lookup"><span data-stu-id="7af11-346">Memory2GB</span></span></li></ul>   |    


<span id="package-delivery-options-object" />

### <a name="package-delivery-options-resource"></a><span data-ttu-id="7af11-347">パッケージの配信オプション リソース</span><span class="sxs-lookup"><span data-stu-id="7af11-347">Package delivery options resource</span></span>

<span data-ttu-id="7af11-348">このリソースには、申請の段階的なパッケージのロールアウトと必須の更新の設定が含まれています。</span><span class="sxs-lookup"><span data-stu-id="7af11-348">This resource contains gradual package rollout and mandatory update settings for the submission.</span></span>

```json
{
  "packageDeliveryOptions": {
    "packageRollout": {
        "isPackageRollout": false,
        "packageRolloutPercentage": 0.0,
        "packageRolloutStatus": "PackageRolloutNotStarted",
        "fallbackSubmissionId": "0"
    },
    "isMandatoryUpdate": false,
    "mandatoryUpdateEffectiveDate": "1601-01-01T00:00:00.0000000Z"
  },
}
```

<span data-ttu-id="7af11-349">このリソースには、次の値があります。</span><span class="sxs-lookup"><span data-stu-id="7af11-349">This resource has the following values.</span></span>

| <span data-ttu-id="7af11-350">値</span><span class="sxs-lookup"><span data-stu-id="7af11-350">Value</span></span>           | <span data-ttu-id="7af11-351">型</span><span class="sxs-lookup"><span data-stu-id="7af11-351">Type</span></span>    | <span data-ttu-id="7af11-352">説明</span><span class="sxs-lookup"><span data-stu-id="7af11-352">Description</span></span>        |
|-----------------|---------|------|
| <span data-ttu-id="7af11-353">packageRollout</span><span class="sxs-lookup"><span data-stu-id="7af11-353">packageRollout</span></span>   |   <span data-ttu-id="7af11-354">object</span><span class="sxs-lookup"><span data-stu-id="7af11-354">object</span></span>      |   <span data-ttu-id="7af11-355">申請の段階的なパッケージのロールアウトの設定が含まれた[パッケージのロールアウトのリソース](#package-rollout-object)です。</span><span class="sxs-lookup"><span data-stu-id="7af11-355">A [package rollout resource](#package-rollout-object) that contains gradual package rollout settings for the submission.</span></span>    |  
| <span data-ttu-id="7af11-356">isMandatoryUpdate</span><span class="sxs-lookup"><span data-stu-id="7af11-356">isMandatoryUpdate</span></span>    | <span data-ttu-id="7af11-357">boolean</span><span class="sxs-lookup"><span data-stu-id="7af11-357">boolean</span></span>    |  <span data-ttu-id="7af11-358">この申請のパッケージを自己インストールのアプリの更新のために必須として扱うかどうかを指定します。</span><span class="sxs-lookup"><span data-stu-id="7af11-358">Indicates whether you want to treat the packages in this submission as mandatory for self-installing app updates.</span></span> <span data-ttu-id="7af11-359">自己インストールのアプリの更新のために必須なパッケージについて詳しくは、「[アプリのパッケージの更新をダウンロードしてインストールする](../packaging/self-install-package-updates.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7af11-359">For more information about mandatory packages for self-installing app updates, see [Download and install package updates for your app](../packaging/self-install-package-updates.md).</span></span>    |  
| <span data-ttu-id="7af11-360">mandatoryUpdateEffectiveDate</span><span class="sxs-lookup"><span data-stu-id="7af11-360">mandatoryUpdateEffectiveDate</span></span>    |  <span data-ttu-id="7af11-361">date</span><span class="sxs-lookup"><span data-stu-id="7af11-361">date</span></span>   |  <span data-ttu-id="7af11-362">この申請のパッケージが必須となる日時 (ISO 8601 形式、UTC タイムゾーン)。</span><span class="sxs-lookup"><span data-stu-id="7af11-362">The date and time when the packages in this submission become mandatory, in ISO 8601 format and UTC time zone.</span></span>   |        

<span id="package-rollout-object" />

### <a name="package-rollout-resource"></a><span data-ttu-id="7af11-363">パッケージのロールアウトのリソース</span><span class="sxs-lookup"><span data-stu-id="7af11-363">Package rollout resource</span></span>

<span data-ttu-id="7af11-364">このリソースには、申請の段階的な[パッケージのロールアウトの設定](#manage-gradual-package-rollout)が含まれています。</span><span class="sxs-lookup"><span data-stu-id="7af11-364">This resource contains gradual [package rollout settings](#manage-gradual-package-rollout) for the submission.</span></span> <span data-ttu-id="7af11-365">このリソースには、次の値があります。</span><span class="sxs-lookup"><span data-stu-id="7af11-365">This resource has the following values.</span></span>

| <span data-ttu-id="7af11-366">値</span><span class="sxs-lookup"><span data-stu-id="7af11-366">Value</span></span>           | <span data-ttu-id="7af11-367">型</span><span class="sxs-lookup"><span data-stu-id="7af11-367">Type</span></span>    | <span data-ttu-id="7af11-368">説明</span><span class="sxs-lookup"><span data-stu-id="7af11-368">Description</span></span>        |
|-----------------|---------|------|
| <span data-ttu-id="7af11-369">isPackageRollout</span><span class="sxs-lookup"><span data-stu-id="7af11-369">isPackageRollout</span></span>   |   <span data-ttu-id="7af11-370">boolean</span><span class="sxs-lookup"><span data-stu-id="7af11-370">boolean</span></span>      |  <span data-ttu-id="7af11-371">申請の段階的なパッケージのロールアウトが有効化されているかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="7af11-371">Indicates whether gradual package rollout is enabled for the submission.</span></span>    |  
| <span data-ttu-id="7af11-372">packageRolloutPercentage</span><span class="sxs-lookup"><span data-stu-id="7af11-372">packageRolloutPercentage</span></span>    | <span data-ttu-id="7af11-373">float</span><span class="sxs-lookup"><span data-stu-id="7af11-373">float</span></span>    |  <span data-ttu-id="7af11-374">段階的なロールアウトでパッケージを受信するユーザーの割合。</span><span class="sxs-lookup"><span data-stu-id="7af11-374">The percentage of users who will receive the packages in the gradual rollout.</span></span>    |  
| <span data-ttu-id="7af11-375">packageRolloutStatus</span><span class="sxs-lookup"><span data-stu-id="7af11-375">packageRolloutStatus</span></span>    |  <span data-ttu-id="7af11-376">string</span><span class="sxs-lookup"><span data-stu-id="7af11-376">string</span></span>   |  <span data-ttu-id="7af11-377">段階的なパッケージのロールアウトの状態を示す、次の文字列のいずれかです。</span><span class="sxs-lookup"><span data-stu-id="7af11-377">One of the following strings that indicates the status of the gradual package rollout:</span></span> <ul><li><span data-ttu-id="7af11-378">PackageRolloutNotStarted</span><span class="sxs-lookup"><span data-stu-id="7af11-378">PackageRolloutNotStarted</span></span></li><li><span data-ttu-id="7af11-379">PackageRolloutInProgress</span><span class="sxs-lookup"><span data-stu-id="7af11-379">PackageRolloutInProgress</span></span></li><li><span data-ttu-id="7af11-380">PackageRolloutComplete</span><span class="sxs-lookup"><span data-stu-id="7af11-380">PackageRolloutComplete</span></span></li><li><span data-ttu-id="7af11-381">PackageRolloutStopped</span><span class="sxs-lookup"><span data-stu-id="7af11-381">PackageRolloutStopped</span></span></li></ul>  |  
| <span data-ttu-id="7af11-382">fallbackSubmissionId</span><span class="sxs-lookup"><span data-stu-id="7af11-382">fallbackSubmissionId</span></span>    |  <span data-ttu-id="7af11-383">string</span><span class="sxs-lookup"><span data-stu-id="7af11-383">string</span></span>   |  <span data-ttu-id="7af11-384">段階的なロールアウトのパッケージを入手しないユーザーが受信する申請の ID。</span><span class="sxs-lookup"><span data-stu-id="7af11-384">The ID of the submission that will be received by customers who do not get the gradual rollout packages.</span></span>   |          

> [!NOTE]
> <span data-ttu-id="7af11-385">*PackageRolloutStatus*と*fallbackSubmissionId*の値は、パートナー センターで割り当てられているし、開発者が設定するものではありません。</span><span class="sxs-lookup"><span data-stu-id="7af11-385">The *packageRolloutStatus* and *fallbackSubmissionId* values are assigned by Partner Center, and are not intended to be set by the developer.</span></span> <span data-ttu-id="7af11-386">これらの値を要求本文に含めると、これらの値は無視されます。</span><span class="sxs-lookup"><span data-stu-id="7af11-386">If you include these values in a request body, these values will be ignored.</span></span>

<span/>

## <a name="enums"></a><span data-ttu-id="7af11-387">列挙型</span><span class="sxs-lookup"><span data-stu-id="7af11-387">Enums</span></span>

<span data-ttu-id="7af11-388">これらのメソッドでは、次の列挙型が使用されます。</span><span class="sxs-lookup"><span data-stu-id="7af11-388">These methods use the following enums.</span></span>

<span id="submission-status-code" />

### <a name="submission-status-code"></a><span data-ttu-id="7af11-389">申請の状態コード</span><span class="sxs-lookup"><span data-stu-id="7af11-389">Submission status code</span></span>

<span data-ttu-id="7af11-390">次のコードは、申請の状態を表します。</span><span class="sxs-lookup"><span data-stu-id="7af11-390">The following codes represent the status of a submission.</span></span>

| <span data-ttu-id="7af11-391">コード</span><span class="sxs-lookup"><span data-stu-id="7af11-391">Code</span></span>           |  <span data-ttu-id="7af11-392">説明</span><span class="sxs-lookup"><span data-stu-id="7af11-392">Description</span></span>      |
|-----------------|---------------|
|  <span data-ttu-id="7af11-393">None</span><span class="sxs-lookup"><span data-stu-id="7af11-393">None</span></span>            |     <span data-ttu-id="7af11-394">コードが指定されていません。</span><span class="sxs-lookup"><span data-stu-id="7af11-394">No code was specified.</span></span>         |     
|      <span data-ttu-id="7af11-395">InvalidArchive</span><span class="sxs-lookup"><span data-stu-id="7af11-395">InvalidArchive</span></span>        |     <span data-ttu-id="7af11-396">パッケージが含まれる ZIP アーカイブは無効であるか、認識できないアーカイブ形式です。</span><span class="sxs-lookup"><span data-stu-id="7af11-396">The ZIP archive containing the package is invalid or has an unrecognized archive format.</span></span>  |
| <span data-ttu-id="7af11-397">MissingFiles</span><span class="sxs-lookup"><span data-stu-id="7af11-397">MissingFiles</span></span> | <span data-ttu-id="7af11-398">ZIP アーカイブに、申請データで指定されているすべてのファイルが含まれていないか、ファイルのアーカイブ内の場所が正しくありません。</span><span class="sxs-lookup"><span data-stu-id="7af11-398">The ZIP archive does not have all files which were listed in your submission data, or they are in the wrong location in the archive.</span></span> |
| <span data-ttu-id="7af11-399">PackageValidationFailed</span><span class="sxs-lookup"><span data-stu-id="7af11-399">PackageValidationFailed</span></span> | <span data-ttu-id="7af11-400">申請の 1 つ以上のパッケージを検証できませんでした。</span><span class="sxs-lookup"><span data-stu-id="7af11-400">One or more packages in your submission failed to validate.</span></span> |
| <span data-ttu-id="7af11-401">InvalidParameterValue</span><span class="sxs-lookup"><span data-stu-id="7af11-401">InvalidParameterValue</span></span> | <span data-ttu-id="7af11-402">要求本文に含まれるパラメーターの 1 つが無効です。</span><span class="sxs-lookup"><span data-stu-id="7af11-402">One of the parameters in the request body is invalid.</span></span> |
| <span data-ttu-id="7af11-403">InvalidOperation</span><span class="sxs-lookup"><span data-stu-id="7af11-403">InvalidOperation</span></span> | <span data-ttu-id="7af11-404">実行された操作は無効です。</span><span class="sxs-lookup"><span data-stu-id="7af11-404">The operation you attempted is invalid.</span></span> |
| <span data-ttu-id="7af11-405">InvalidState</span><span class="sxs-lookup"><span data-stu-id="7af11-405">InvalidState</span></span> | <span data-ttu-id="7af11-406">実行された操作は、パッケージ フライトの現在の状態では無効です。</span><span class="sxs-lookup"><span data-stu-id="7af11-406">The operation you attempted is not valid for the current state of the package flight.</span></span> |
| <span data-ttu-id="7af11-407">ResourceNotFound</span><span class="sxs-lookup"><span data-stu-id="7af11-407">ResourceNotFound</span></span> | <span data-ttu-id="7af11-408">指定されたパッケージ フライトは見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="7af11-408">The specified package flight could not be found.</span></span> |
| <span data-ttu-id="7af11-409">ServiceError</span><span class="sxs-lookup"><span data-stu-id="7af11-409">ServiceError</span></span> | <span data-ttu-id="7af11-410">内部サービス エラーのため、要求を処理できませんでした。</span><span class="sxs-lookup"><span data-stu-id="7af11-410">An internal service error prevented the request from succeeding.</span></span> <span data-ttu-id="7af11-411">もう一度要求を行ってください。</span><span class="sxs-lookup"><span data-stu-id="7af11-411">Try the request again.</span></span> |
| <span data-ttu-id="7af11-412">ListingOptOutWarning</span><span class="sxs-lookup"><span data-stu-id="7af11-412">ListingOptOutWarning</span></span> | <span data-ttu-id="7af11-413">開発者が以前の申請の登録情報を削除しているか、パッケージによってサポートされる登録情報を含めていませんでした。</span><span class="sxs-lookup"><span data-stu-id="7af11-413">The developer removed a listing from a previous submission, or did not include listing information that is supported by the package.</span></span> |
| <span data-ttu-id="7af11-414">ListingOptInWarning</span><span class="sxs-lookup"><span data-stu-id="7af11-414">ListingOptInWarning</span></span>  | <span data-ttu-id="7af11-415">開発者が登録情報を追加しました。</span><span class="sxs-lookup"><span data-stu-id="7af11-415">The developer added a listing.</span></span> |
| <span data-ttu-id="7af11-416">UpdateOnlyWarning</span><span class="sxs-lookup"><span data-stu-id="7af11-416">UpdateOnlyWarning</span></span> | <span data-ttu-id="7af11-417">開発者が、更新サポートしかないものを挿入しようとしています。</span><span class="sxs-lookup"><span data-stu-id="7af11-417">The developer is trying to insert something that only has update support.</span></span> |
| <span data-ttu-id="7af11-418">Other</span><span class="sxs-lookup"><span data-stu-id="7af11-418">Other</span></span>  | <span data-ttu-id="7af11-419">申請が非認識または未分類の状態です。</span><span class="sxs-lookup"><span data-stu-id="7af11-419">The submission is in an unrecognized or uncategorized state.</span></span> |
| <span data-ttu-id="7af11-420">PackageValidationWarning</span><span class="sxs-lookup"><span data-stu-id="7af11-420">PackageValidationWarning</span></span> | <span data-ttu-id="7af11-421">パッケージ検証プロセスの結果、警告が生成されました。</span><span class="sxs-lookup"><span data-stu-id="7af11-421">The package validation process resulted in a warning.</span></span> |

<span/>

## <a name="related-topics"></a><span data-ttu-id="7af11-422">関連トピック</span><span class="sxs-lookup"><span data-stu-id="7af11-422">Related topics</span></span>

* [<span data-ttu-id="7af11-423">Microsoft Store サービスを使用した申請の作成と管理</span><span class="sxs-lookup"><span data-stu-id="7af11-423">Create and manage submissions using Microsoft Store services</span></span>](create-and-manage-submissions-using-windows-store-services.md)
* [<span data-ttu-id="7af11-424">Microsoft Store 申請 API を使用したパッケージ フライトの管理</span><span class="sxs-lookup"><span data-stu-id="7af11-424">Manage package flights using the Microsoft Store submission API</span></span>](manage-flights.md)
* [<span data-ttu-id="7af11-425">パッケージ フライトの申請の取得</span><span class="sxs-lookup"><span data-stu-id="7af11-425">Get a package flight submission</span></span>](get-a-flight-submission.md)
* [<span data-ttu-id="7af11-426">パッケージ フライトの申請の作成</span><span class="sxs-lookup"><span data-stu-id="7af11-426">Create a package flight submission</span></span>](create-a-flight-submission.md)
* [<span data-ttu-id="7af11-427">パッケージ フライトの申請の更新</span><span class="sxs-lookup"><span data-stu-id="7af11-427">Update a package flight submission</span></span>](update-a-flight-submission.md)
* [<span data-ttu-id="7af11-428">パッケージ フライトの申請のコミット</span><span class="sxs-lookup"><span data-stu-id="7af11-428">Commit a package flight submission</span></span>](commit-a-flight-submission.md)
* [<span data-ttu-id="7af11-429">パッケージ フライトの申請の削除</span><span class="sxs-lookup"><span data-stu-id="7af11-429">Delete a package flight submission</span></span>](delete-a-flight-submission.md)
* [<span data-ttu-id="7af11-430">パッケージ フライトの申請の状態の取得</span><span class="sxs-lookup"><span data-stu-id="7af11-430">Get the status of a package flight submission</span></span>](get-status-for-a-flight-submission.md)
