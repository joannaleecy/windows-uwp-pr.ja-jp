---
ms.assetid: 2A454057-FF14-40D2-8ED2-CEB5F27E0226
description: Microsoft Store 送信 API でこれらのメソッドを使用すると、パートナー センター アカウントに登録されているアプリのパッケージのフライトの送信を管理できます。
title: パッケージ フライトの申請の管理
ms.date: 04/16/2018
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store 申請 API, フライトの申請
ms.localizationpriority: medium
ms.openlocfilehash: 19ddd43d4e61480764882f1b10e6240aa2afeb8c
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57662727"
---
# <a name="manage-package-flight-submissions"></a><span data-ttu-id="d63c8-104">パッケージ フライトの申請の管理</span><span class="sxs-lookup"><span data-stu-id="d63c8-104">Manage package flight submissions</span></span>

<span data-ttu-id="d63c8-105">Microsoft Store 申請 API には、段階的なパッケージのロールアウトなど、アプリのパッケージ フライトの申請を管理するために使用できるメソッドが用意されています。</span><span class="sxs-lookup"><span data-stu-id="d63c8-105">The Microsoft Store submission API provides methods you can use to manage package flight submissions for your apps, including gradual package rollouts.</span></span> <span data-ttu-id="d63c8-106">Microsoft Store 申請 API の概要については、「[Microsoft Store サービスを使用した申請の作成と管理](create-and-manage-submissions-using-windows-store-services.md)」をご覧ください。この API を使用するための前提条件などの情報があります。</span><span class="sxs-lookup"><span data-stu-id="d63c8-106">For an introduction to the Microsoft Store submission API, including prerequisites for using the API, see [Create and manage submissions using Microsoft Store services](create-and-manage-submissions-using-windows-store-services.md).</span></span>

> [!IMPORTANT]
> <span data-ttu-id="d63c8-107">Microsoft Store 送信 API を使用してパッケージ フライトの提出を作成すると、必ず変更を加える提出にパートナー センターではなく、API を使用してのみ。</span><span class="sxs-lookup"><span data-stu-id="d63c8-107">If you use the Microsoft Store submission API to create a submission for a package flight, be sure to make further changes to the submission only by using the API, rather than Partner Center.</span></span> <span data-ttu-id="d63c8-108">最初に API を使って作成した申請を、ダッシュボードを使って変更した場合、API を使ってその申請を変更またはコミットすることができなくなります。</span><span class="sxs-lookup"><span data-stu-id="d63c8-108">If you use the dashboard to change a submission that you originally created by using the API, you will no longer be able to change or commit that submission by using the API.</span></span> <span data-ttu-id="d63c8-109">場合によっては、申請がエラー状態のままになり、申請プロセスを進めることができなくなります。</span><span class="sxs-lookup"><span data-stu-id="d63c8-109">In some cases, the submission could be left in an error state where it cannot proceed in the submission process.</span></span> <span data-ttu-id="d63c8-110">この場合、申請を削除して新しい申請を作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d63c8-110">If this occurs, you must delete the submission and create a new submission.</span></span>

<span id="methods-for-package-flight-submissions" />

## <a name="methods-for-managing-package-flight-submissions"></a><span data-ttu-id="d63c8-111">パッケージ フライトの申請を管理するためのメソッド</span><span class="sxs-lookup"><span data-stu-id="d63c8-111">Methods for managing package flight submissions</span></span>

<span data-ttu-id="d63c8-112">パッケージ フライトの申請を取得、作成、更新、コミット、または削除するには、次のメソッドを使用します。</span><span class="sxs-lookup"><span data-stu-id="d63c8-112">Use the following methods to get, create, update, commit, or delete a package flight submission.</span></span> <span data-ttu-id="d63c8-113">これらのメソッドを使用するには、パッケージ フライトが、パートナー センター既に存在する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d63c8-113">Before you can use these methods, the package flight must already exist in Partner Center.</span></span> <span data-ttu-id="d63c8-114">パッケージ フライトを作成することができます[パートナー センターで](https://msdn.microsoft.com/windows/uwp/publish/package-flights)で説明されている Microsoft Store の送信 API メソッドを使用してまたは[管理パッケージ フライト](manage-flights.md)。</span><span class="sxs-lookup"><span data-stu-id="d63c8-114">You can create a package flight [in Partner Center](https://msdn.microsoft.com/windows/uwp/publish/package-flights) or by using the Microsoft Store submission API methods in described in [Manage package flights](manage-flights.md).</span></span>

<table>
<colgroup>
<col width="10%" />
<col width="30%" />
<col width="60%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="d63c8-115">メソッド</span><span class="sxs-lookup"><span data-stu-id="d63c8-115">Method</span></span></th>
<th align="left"><span data-ttu-id="d63c8-116">URI</span><span class="sxs-lookup"><span data-stu-id="d63c8-116">URI</span></span></th>
<th align="left"><span data-ttu-id="d63c8-117">説明</span><span class="sxs-lookup"><span data-stu-id="d63c8-117">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr>
<td align="left"><span data-ttu-id="d63c8-118">GET</span><span class="sxs-lookup"><span data-stu-id="d63c8-118">GET</span></span></td>
<td align="left">https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions/{submissionId}</td>
<td align="left"><span data-ttu-id="d63c8-119"><a href="get-a-flight-submission.md">既存のパッケージのフライトの送信を取得します。</a></span><span class="sxs-lookup"><span data-stu-id="d63c8-119"><a href="get-a-flight-submission.md">Get an existing package flight submission</a></span></span></td>
</tr>
<tr>
<td align="left"><span data-ttu-id="d63c8-120">GET</span><span class="sxs-lookup"><span data-stu-id="d63c8-120">GET</span></span></td>
<td align="left">https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions/{submissionId}/status</td>
<td align="left"><span data-ttu-id="d63c8-121"><a href="get-status-for-a-flight-submission.md">既存のパッケージのフライトの送信の状態を取得します。</a></span><span class="sxs-lookup"><span data-stu-id="d63c8-121"><a href="get-status-for-a-flight-submission.md">Get the status of an existing package flight submission</a></span></span></td>
</tr>
<tr>
<td align="left"><span data-ttu-id="d63c8-122">POST</span><span class="sxs-lookup"><span data-stu-id="d63c8-122">POST</span></span></td>
<td align="left">https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions</td>
<td align="left"><span data-ttu-id="d63c8-123"><a href="create-a-flight-submission.md">新しいパッケージのフライトの提出を作成します。</a></span><span class="sxs-lookup"><span data-stu-id="d63c8-123"><a href="create-a-flight-submission.md">Create a new package flight submission</a></span></span></td>
</tr>
<tr>
<td align="left"><span data-ttu-id="d63c8-124">PUT</span><span class="sxs-lookup"><span data-stu-id="d63c8-124">PUT</span></span></td>
<td align="left">https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions/{submissionId}</td>
<td align="left"><span data-ttu-id="d63c8-125"><a href="update-a-flight-submission.md">既存のパッケージのフライト申請を更新します。</a></span><span class="sxs-lookup"><span data-stu-id="d63c8-125"><a href="update-a-flight-submission.md">Update an existing package flight submission</a></span></span></td>
</tr>
<tr>
<td align="left"><span data-ttu-id="d63c8-126">POST</span><span class="sxs-lookup"><span data-stu-id="d63c8-126">POST</span></span></td>
<td align="left">https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions/{submissionId}/commit</td>
<td align="left"><span data-ttu-id="d63c8-127"><a href="commit-a-flight-submission.md">新しいまたは更新されたパッケージのフライト送信をコミットします。</a></span><span class="sxs-lookup"><span data-stu-id="d63c8-127"><a href="commit-a-flight-submission.md">Commit a new or updated package flight submission</a></span></span></td>
</tr>
<tr>
<td align="left"><span data-ttu-id="d63c8-128">DELETE</span><span class="sxs-lookup"><span data-stu-id="d63c8-128">DELETE</span></span></td>
<td align="left">https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions/{submissionId}</td>
<td align="left"><span data-ttu-id="d63c8-129"><a href="delete-a-flight-submission.md">パッケージのフライトの送信を削除します。</a></span><span class="sxs-lookup"><span data-stu-id="d63c8-129"><a href="delete-a-flight-submission.md">Delete a package flight submission</a></span></span></td>
</tr>
</tbody>
</table>

<span id="create-a-package-flight-submission">

## <a name="create-a-package-flight-submission"></a><span data-ttu-id="d63c8-130">パッケージ フライトの申請の作成</span><span class="sxs-lookup"><span data-stu-id="d63c8-130">Create a package flight submission</span></span>

<span data-ttu-id="d63c8-131">パッケージ フライトの申請を作成するには、次のプロセスに従います。</span><span class="sxs-lookup"><span data-stu-id="d63c8-131">To create a submission for a package flight, follow this process.</span></span>

1. <span data-ttu-id="d63c8-132">まだ行っていないため、完全な前提条件に記載されている[作成 Microsoft Store サービスを使用して送信の管理と](create-and-manage-submissions-using-windows-store-services.md)(パートナー センター アカウントと Azure AD アプリケーションの関連付けを取得するなど)、クライアント ID とキー。</span><span class="sxs-lookup"><span data-stu-id="d63c8-132">If you have not yet done so, complete the prerequisites described in [Create and manage submissions using Microsoft Store services](create-and-manage-submissions-using-windows-store-services.md), including associating an Azure AD application with your Partner Center account and obtaining your client ID and key.</span></span> <span data-ttu-id="d63c8-133">この作業は 1 度行うだけでよく、クライアント ID とキーを入手したら、新しい Azure AD アクセス トークンの作成が必要になったときに、いつでもそれらを再利用できます。</span><span class="sxs-lookup"><span data-stu-id="d63c8-133">You only need to do this one time; after you have the client ID and key, you can reuse them any time you need to create a new Azure AD access token.</span></span>  

2. <span data-ttu-id="d63c8-134">[Azure AD のアクセス トークンを取得します](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)。</span><span class="sxs-lookup"><span data-stu-id="d63c8-134">[Obtain an Azure AD access token](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token).</span></span> <span data-ttu-id="d63c8-135">このアクセス トークンを Microsoft Store 申請 API のメソッドに渡す必要があります。</span><span class="sxs-lookup"><span data-stu-id="d63c8-135">You must pass this access token to the methods in the Microsoft Store submission API.</span></span> <span data-ttu-id="d63c8-136">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="d63c8-136">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="d63c8-137">トークンの有効期限が切れたら新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="d63c8-137">After the token expires, you can obtain a new one.</span></span>

3. <span data-ttu-id="d63c8-138">Microsoft Store 申請 API の次のメソッドを実行して、[パッケージ フライトの申請を作成](create-a-flight-submission.md)します。</span><span class="sxs-lookup"><span data-stu-id="d63c8-138">[Create a package flight submission](create-a-flight-submission.md) by executing the following method in the Microsoft Store submission API.</span></span> <span data-ttu-id="d63c8-139">このメソッドによって、新しい申請が作成され、審査中になります。これは、前回発行した申請のコピーです。</span><span class="sxs-lookup"><span data-stu-id="d63c8-139">This method creates a new in-progress submission, which is a copy of your last published submission.</span></span>

    ```
    POST https://manage.devcenter.microsoft.com/v1.0/my/applications{applicationId}/flights/{flightId}/submissions
    ```

    <span data-ttu-id="d63c8-140">応答本文には、新しい申請の ID、申請用のパッケージを Azure Blob Storage にアップロードするための共有アクセス署名 (SAS) URI、および新しい申請のデータ (すべての登録情報と価格情報が含まれます) を含む[フライトの申請](#flight-submission-object)リソースが含まれます。</span><span class="sxs-lookup"><span data-stu-id="d63c8-140">The response body contains a [flight submission](#flight-submission-object) resource that includes the ID of the new submission, the shared access signature (SAS) URI for uploading any packages for the submission to Azure Blob storage, and the data for the new submission (including all the listings and pricing information).</span></span>

    > [!NOTE]
    > <span data-ttu-id="d63c8-141">SAS URI では、アカウント キーを必要とせずに、Azure Storage 内のセキュリティで保護されたリソースにアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="d63c8-141">A SAS URI provides access to a secure resource in Azure storage without requiring account keys.</span></span> <span data-ttu-id="d63c8-142">SAS URI の背景情報と Azure Blob Storage での SAS URI の使用については、[Shared Access Signature 第 1 部: SAS モデルについて](https://azure.microsoft.com/documentation/articles/storage-dotnet-shared-access-signature-part-1)と[Shared Access Signature、第 2 部。作成し、Blob storage では、SAS を使用して](https://azure.microsoft.com/documentation/articles/storage-dotnet-shared-access-signature-part-2/)します。</span><span class="sxs-lookup"><span data-stu-id="d63c8-142">For background information about SAS URIs and their use with Azure Blob storage, see [Shared Access Signatures, Part 1: Understanding the SAS model](https://azure.microsoft.com/documentation/articles/storage-dotnet-shared-access-signature-part-1) and [Shared Access Signatures, Part 2: Create and use a SAS with Blob storage](https://azure.microsoft.com/documentation/articles/storage-dotnet-shared-access-signature-part-2/).</span></span>

4. <span data-ttu-id="d63c8-143">申請用に新しいパッケージを追加する場合は、[パッケージを準備](https://msdn.microsoft.com/windows/uwp/publish/app-package-requirements)して、ZIP アーカイブに追加します。</span><span class="sxs-lookup"><span data-stu-id="d63c8-143">If you are adding new packages for the submission, [prepare the packages](https://msdn.microsoft.com/windows/uwp/publish/app-package-requirements) and add them to a ZIP archive.</span></span>

5. <span data-ttu-id="d63c8-144">新しい申請用に必要な変更を行って[フライトの申請](#flight-submission-object)のデータを更新し、次のメソッドを実行して[パッケージ フライトの申請を更新](update-a-flight-submission.md)します。</span><span class="sxs-lookup"><span data-stu-id="d63c8-144">Revise the [flight submission](#flight-submission-object) data with any required changes for the new submission, and execute the following method to [update the package flight submission](update-a-flight-submission.md).</span></span>

    ```
    PUT https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions/{submissionId}
    ```
      > [!NOTE]
      > <span data-ttu-id="d63c8-145">申請用に新しいパッケージを追加する場合、ZIP アーカイブ内のアイコンのファイルの名前と相対パスを参照するように、申請データを更新してください。</span><span class="sxs-lookup"><span data-stu-id="d63c8-145">If you are adding new packages for the submission, make sure you update the submission data to refer to the name and relative path of these files in the ZIP archive.</span></span>

4. <span data-ttu-id="d63c8-146">申請用に新しいパッケージを追加する場合は、上記で呼び出した POST メソッドの応答本文に含まれていた SAS URI を使用して、ZIP アーカイブを [Azure Blob Storage](https://docs.microsoft.com/azure/storage/storage-introduction#blob-storage) にアップロードします。</span><span class="sxs-lookup"><span data-stu-id="d63c8-146">If you are adding new packages for the submission, upload the ZIP archive to [Azure Blob storage](https://docs.microsoft.com/azure/storage/storage-introduction#blob-storage) using the SAS URI that was provided in the response body of the POST method you called earlier.</span></span> <span data-ttu-id="d63c8-147">さまざまなプラットフォームでこれを行うために使用できる、次のようなさまざまな Azure ライブラリがあります。</span><span class="sxs-lookup"><span data-stu-id="d63c8-147">There are different Azure libraries you can use to do this on a variety of platforms, including:</span></span>

    * [<span data-ttu-id="d63c8-148">.NET 用 azure Storage クライアント ライブラリ</span><span class="sxs-lookup"><span data-stu-id="d63c8-148">Azure Storage Client Library for .NET</span></span>](https://docs.microsoft.com/azure/storage/storage-dotnet-how-to-use-blobs)
    * [<span data-ttu-id="d63c8-149">Azure Storage SDK for Java</span><span class="sxs-lookup"><span data-stu-id="d63c8-149">Azure Storage SDK for Java</span></span>](https://docs.microsoft.com/azure/storage/storage-java-how-to-use-blob-storage)
    * [<span data-ttu-id="d63c8-150">Azure Storage SDK for Python</span><span class="sxs-lookup"><span data-stu-id="d63c8-150">Azure Storage SDK for Python</span></span>](https://docs.microsoft.com/azure/storage/storage-python-how-to-use-blob-storage)

    <span data-ttu-id="d63c8-151">次の C# コード例は、.NET 用 Azure Storage クライアント ライブラリの [CloudBlockBlob](https://msdn.microsoft.com/library/azure/microsoft.windowsazure.storage.blob.cloudblockblob.aspx) クラスを使用して ZIP アーカイブを Azure Blob Storage にアップロードする方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="d63c8-151">The following C# code example demonstrates how to upload a ZIP archive to Azure Blob storage using the [CloudBlockBlob](https://msdn.microsoft.com/library/azure/microsoft.windowsazure.storage.blob.cloudblockblob.aspx) class in the Azure Storage Client Library for .NET.</span></span> <span data-ttu-id="d63c8-152">この例では、ZIP アーカイブが既にストリーム オブジェクトに書き込まれていることを前提としています。</span><span class="sxs-lookup"><span data-stu-id="d63c8-152">This example assumes that the ZIP archive has already been written to a stream object.</span></span>

    ```csharp
    string sasUrl = "https://productingestionbin1.blob.core.windows.net/ingestion/26920f66-b592-4439-9a9d-fb0f014902ec?sv=2014-02-14&sr=b&sig=usAN0kNFNnYE2tGQBI%2BARQWejX1Guiz7hdFtRhyK%2Bog%3D&se=2016-06-17T20:45:51Z&sp=rwl";
    Microsoft.WindowsAzure.Storage.Blob.CloudBlockBlob blockBob =
        new Microsoft.WindowsAzure.Storage.Blob.CloudBlockBlob(new System.Uri(sasUrl));
    await blockBob.UploadFromStreamAsync(stream);
    ```

5. <span data-ttu-id="d63c8-153">次のメソッドを実行して、[パッケージ フライトの申請をコミット](commit-a-flight-submission.md)します。</span><span class="sxs-lookup"><span data-stu-id="d63c8-153">[Commit the package flight submission](commit-a-flight-submission.md) by executing the following method.</span></span> <span data-ttu-id="d63c8-154">お客様の提出を終了することと、自分のアカウントに、更新プログラムが適用されるようになりましたことは、パートナー センターが警告されます。</span><span class="sxs-lookup"><span data-stu-id="d63c8-154">This will alert Partner Center that you are done with your submission and that your updates should now be applied to your account.</span></span>

    ```
    POST https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions/{submissionId}/commit
    ```

6. <span data-ttu-id="d63c8-155">次のメソッドを実行して[パッケージ フライトの申請の状態を取得](get-status-for-a-flight-submission.md)して、コミット状態を確認します。</span><span class="sxs-lookup"><span data-stu-id="d63c8-155">Check on the commit status by executing the following method to [get the status of the package flight submission](get-status-for-a-flight-submission.md).</span></span>

    ```
    GET https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions/{submissionId}/status
    ```

    <span data-ttu-id="d63c8-156">申請の状態を確認するには、応答本文の *status* の値を確認します。</span><span class="sxs-lookup"><span data-stu-id="d63c8-156">To confirm the submission status, review the *status* value in the response body.</span></span> <span data-ttu-id="d63c8-157">この値が **CommitStarted** から **PreProcessing** (要求が成功した場合) または **CommitFailed** (要求でエラーが発生した場合) に変わっています。</span><span class="sxs-lookup"><span data-stu-id="d63c8-157">This value should change from **CommitStarted** to either **PreProcessing** if the request succeeds or to **CommitFailed** if there are errors in the request.</span></span> <span data-ttu-id="d63c8-158">エラーがある場合は、*statusDetails* フィールドにエラーについての詳細情報が含まれています。</span><span class="sxs-lookup"><span data-stu-id="d63c8-158">If there are errors, the *statusDetails* field contains further details about the error.</span></span>

7. <span data-ttu-id="d63c8-159">コミットが正常に処理されると、インジェストのために申請がストアに送信されます。</span><span class="sxs-lookup"><span data-stu-id="d63c8-159">After the commit has successfully completed, the submission is sent to the Store for ingestion.</span></span> <span data-ttu-id="d63c8-160">前のメソッドを使用するか、パートナー センターにアクセスして、送信進行状況を監視できます。</span><span class="sxs-lookup"><span data-stu-id="d63c8-160">You can continue to monitor the submission progress by using the previous method, or by visiting Partner Center.</span></span>

<span/>

## <a name="code-examples"></a><span data-ttu-id="d63c8-161">コード例</span><span class="sxs-lookup"><span data-stu-id="d63c8-161">Code examples</span></span>

<span data-ttu-id="d63c8-162">次の記事では、さまざまなプログラミング言語でパッケージ フライトの申請を作成する方法を説明する詳しいコード例を紹介します。</span><span class="sxs-lookup"><span data-stu-id="d63c8-162">The following articles provide detailed code examples that demonstrate how to create a package flight submission in several different programming languages:</span></span>

* [<span data-ttu-id="d63c8-163">C#コード例</span><span class="sxs-lookup"><span data-stu-id="d63c8-163">C# code examples</span></span>](csharp-code-examples-for-the-windows-store-submission-api.md)
* [<span data-ttu-id="d63c8-164">Java のコード例</span><span class="sxs-lookup"><span data-stu-id="d63c8-164">Java code examples</span></span>](java-code-examples-for-the-windows-store-submission-api.md)
* [<span data-ttu-id="d63c8-165">Python のコード例</span><span class="sxs-lookup"><span data-stu-id="d63c8-165">Python code examples</span></span>](python-code-examples-for-the-windows-store-submission-api.md)

## <a name="storebroker-powershell-module"></a><span data-ttu-id="d63c8-166">StoreBroker PowerShell モジュール</span><span class="sxs-lookup"><span data-stu-id="d63c8-166">StoreBroker PowerShell module</span></span>

<span data-ttu-id="d63c8-167">Microsoft Store 申請 API を直接呼び出す代わりに、API の上にコマンド ライン インターフェイスを実装するオープンソースの PowerShell モジュールも用意されています。</span><span class="sxs-lookup"><span data-stu-id="d63c8-167">As an alternative to calling the Microsoft Store submission API directly, we also provide an open-source PowerShell module which implements a command-line interface on top of the API.</span></span> <span data-ttu-id="d63c8-168">このモジュールは、[StoreBroker](https://aka.ms/storebroker) と呼ばれています。</span><span class="sxs-lookup"><span data-stu-id="d63c8-168">This module is called [StoreBroker](https://aka.ms/storebroker).</span></span> <span data-ttu-id="d63c8-169">このモジュールを使うと、Microsoft Store 申請 API を直接呼び出さずに、コマンド ラインからアプリ、フライト、アドオンの申請を管理できます。また、ソースを参照して、この API を呼び出す方法の例を確認することもできます。</span><span class="sxs-lookup"><span data-stu-id="d63c8-169">You can use this module to manage your app, flight, and add-on submissions from the command line instead of calling the Microsoft Store submission API directly, or you can simply browse the source to see more examples for how to call this API.</span></span> <span data-ttu-id="d63c8-170">StoreBroker モジュールは、多くのファースト パーティ アプリケーションをストアに申請する主要な方法として Microsoft 内で積極的に使っています。</span><span class="sxs-lookup"><span data-stu-id="d63c8-170">The StoreBroker module is actively used within Microsoft as the primary way that many first-party applications are submitted to the Store.</span></span>

<span data-ttu-id="d63c8-171">詳しくは、[GitHub の StoreBroker に関するページ](https://aka.ms/storebroker)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d63c8-171">For more information, see our [StoreBroker page on GitHub](https://aka.ms/storebroker).</span></span>

<span id="manage-gradual-package-rollout">

## <a name="manage-a-gradual-package-rollout-for-a-package-flight-submission"></a><span data-ttu-id="d63c8-172">パッケージ フライトの申請の段階的なパッケージのロールアウトを管理する</span><span class="sxs-lookup"><span data-stu-id="d63c8-172">Manage a gradual package rollout for a package flight submission</span></span>

<span data-ttu-id="d63c8-173">パッケージ フライトの申請で更新されたパッケージを、アプリの Windows 10 のユーザーの一部に、段階的にロールアウトできます。</span><span class="sxs-lookup"><span data-stu-id="d63c8-173">You can gradually roll out the updated packages in a package flight submission to a percentage of your app’s customers on Windows 10.</span></span> <span data-ttu-id="d63c8-174">これにより、更新に確信が持てるよう、特定のパッケージのフィードバックと分析データを監視してから、より広くロールアウトできます。</span><span class="sxs-lookup"><span data-stu-id="d63c8-174">This allows you to monitor feedback and analytic data for the specific packages to make sure you’re confident about the update before rolling it out more broadly.</span></span> <span data-ttu-id="d63c8-175">新しい申請を作成することなく、公開された申請のロールアウトの割合を変更する (または更新を停止する) ことができます。</span><span class="sxs-lookup"><span data-stu-id="d63c8-175">You can change the rollout percentage (or halt the update) for a published submission without having to create a new submission.</span></span> <span data-ttu-id="d63c8-176">詳細については、有効にして、パートナー センターでのパッケージを段階的なロールアウトを管理する方法の手順などを参照してください[今回](../publish/gradual-package-rollout.md)します。</span><span class="sxs-lookup"><span data-stu-id="d63c8-176">For more details, including instructions for how to enable and manage a gradual package rollout in Partner Center, see [this article](../publish/gradual-package-rollout.md).</span></span>

<span data-ttu-id="d63c8-177">パッケージ フライトの申請の段階的なパッケージのロールアウトをプログラムによって有効化するには、Microsoft Store 申請 API のメソッドを使用して、次の手順に従います。</span><span class="sxs-lookup"><span data-stu-id="d63c8-177">To programmatically enable a gradual package rollout for a package flight submission, follow this process using methods in the Microsoft Store submission API:</span></span>

  1. <span data-ttu-id="d63c8-178">[パッケージ フライトの申請の作成](create-a-flight-submission.md)、または[パッケージ フライトの申請の取得](get-a-flight-submission.md)を行います。</span><span class="sxs-lookup"><span data-stu-id="d63c8-178">[Create a package flight submission](create-a-flight-submission.md) or [get a package flight submission](get-a-flight-submission.md).</span></span>
  2. <span data-ttu-id="d63c8-179">応答データで、[packageRollout](#package-rollout-object) リソースを探し、*[isPackageRollout]* フィールドを [true] に設定し、*[packageRolloutPercentage]* フィールドに、アプリのユーザーが更新されたパッケージを取得する割合を設定します。</span><span class="sxs-lookup"><span data-stu-id="d63c8-179">In the response data, locate the [packageRollout](#package-rollout-object) resource, set the *isPackageRollout* field to true, and set the *packageRolloutPercentage* field to the percentage of your app's customers who should get the updated packages.</span></span>
  3. <span data-ttu-id="d63c8-180">更新されたパッケージ フライトの申請のデータを[パッケージ フライトの申請を更新する](update-a-flight-submission.md)メソッドに渡します。</span><span class="sxs-lookup"><span data-stu-id="d63c8-180">Pass the updated package flight submission data to the [update a package flight submission](update-a-flight-submission.md) method.</span></span>

<span data-ttu-id="d63c8-181">パッケージ フライトの申請の段階的なパッケージのロールアウトが有効化された後、段階的なロールアウトをプログラムで取得、更新、停止、または完了するには、次のメソッドを使用できます。</span><span class="sxs-lookup"><span data-stu-id="d63c8-181">After a gradual package rollout is enabled for a package flight submission, you can use the following methods to programmatically get, update, halt, or finalize the gradual rollout.</span></span>

<table>
<colgroup>
<col width="10%" />
<col width="30%" />
<col width="60%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="d63c8-182">メソッド</span><span class="sxs-lookup"><span data-stu-id="d63c8-182">Method</span></span></th>
<th align="left"><span data-ttu-id="d63c8-183">URI</span><span class="sxs-lookup"><span data-stu-id="d63c8-183">URI</span></span></th>
<th align="left"><span data-ttu-id="d63c8-184">説明</span><span class="sxs-lookup"><span data-stu-id="d63c8-184">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr>
<td align="left"><span data-ttu-id="d63c8-185">GET</span><span class="sxs-lookup"><span data-stu-id="d63c8-185">GET</span></span></td>
<td align="left">https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions/{submissionId}/packagerollout</td>
<td align="left"><span data-ttu-id="d63c8-186"><a href="get-package-rollout-info-for-a-flight-submission.md">パッケージのフライトの送信の段階的なロールアウト情報を取得します。</a></span><span class="sxs-lookup"><span data-stu-id="d63c8-186"><a href="get-package-rollout-info-for-a-flight-submission.md">Get the gradual rollout info for a package flight submission</a></span></span></td>
</tr>
<tr>
<td align="left"><span data-ttu-id="d63c8-187">POST</span><span class="sxs-lookup"><span data-stu-id="d63c8-187">POST</span></span></td>
<td align="left">https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions/{submissionId}/updatepackagerolloutpercentage</td>
<td align="left"><span data-ttu-id="d63c8-188"><a href="update-the-package-rollout-percentage-for-a-flight-submission.md">更新プログラム パッケージのフライトの段階的なロールアウトの割合</a></span><span class="sxs-lookup"><span data-stu-id="d63c8-188"><a href="update-the-package-rollout-percentage-for-a-flight-submission.md">Update the gradual rollout percentage for a package flight submission</a></span></span></td>
</tr>
<tr>
<td align="left"><span data-ttu-id="d63c8-189">POST</span><span class="sxs-lookup"><span data-stu-id="d63c8-189">POST</span></span></td>
<td align="left">https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions/{submissionId}/haltpackagerollout</td>
<td align="left"><span data-ttu-id="d63c8-190"><a href="halt-the-package-rollout-for-a-flight-submission.md">パッケージのフライトの段階的なロールアウトを停止します。</a></span><span class="sxs-lookup"><span data-stu-id="d63c8-190"><a href="halt-the-package-rollout-for-a-flight-submission.md">Halt the gradual rollout for a package flight submission</a></span></span></td>
</tr>
<tr>
<td align="left"><span data-ttu-id="d63c8-191">POST</span><span class="sxs-lookup"><span data-stu-id="d63c8-191">POST</span></span></td>
<td align="left">https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions/{submissionId}/finalizepackagerollout</td>
<td align="left"><span data-ttu-id="d63c8-192"><a href="finalize-the-package-rollout-for-a-flight-submission.md">パッケージのフライトの段階的なロールアウトを最終処理します。</a></span><span class="sxs-lookup"><span data-stu-id="d63c8-192"><a href="finalize-the-package-rollout-for-a-flight-submission.md">Finalize the gradual rollout for a package flight submission</a></span></span></td>
</tr>
</tbody>
</table>

<span/>

## <a name="data-resources"></a><span data-ttu-id="d63c8-193">データ リソース</span><span class="sxs-lookup"><span data-stu-id="d63c8-193">Data resources</span></span>

<span data-ttu-id="d63c8-194">パッケージ フライトの申請を管理するための Microsoft Store 申請 API のメソッドでは、次の JSON データ リソースが使われます。</span><span class="sxs-lookup"><span data-stu-id="d63c8-194">The Microsoft Store submission API methods for managing package flight submissions use the following JSON data resources.</span></span>

<span id="flight-submission-object" />

### <a name="flight-submission-resource"></a><span data-ttu-id="d63c8-195">フライトの申請のリソース</span><span class="sxs-lookup"><span data-stu-id="d63c8-195">Flight submission resource</span></span>

<span data-ttu-id="d63c8-196">このリソースは、パッケージ フライトの申請を記述しています。</span><span class="sxs-lookup"><span data-stu-id="d63c8-196">This resource describes a package flight submission.</span></span>

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

<span data-ttu-id="d63c8-197">このリソースには、次の値があります。</span><span class="sxs-lookup"><span data-stu-id="d63c8-197">This resource has the following values.</span></span>

| <span data-ttu-id="d63c8-198">Value</span><span class="sxs-lookup"><span data-stu-id="d63c8-198">Value</span></span>      | <span data-ttu-id="d63c8-199">種類</span><span class="sxs-lookup"><span data-stu-id="d63c8-199">Type</span></span>   | <span data-ttu-id="d63c8-200">説明</span><span class="sxs-lookup"><span data-stu-id="d63c8-200">Description</span></span>              |
|------------|--------|------------------------------|
| <span data-ttu-id="d63c8-201">id</span><span class="sxs-lookup"><span data-stu-id="d63c8-201">id</span></span>            | <span data-ttu-id="d63c8-202">string</span><span class="sxs-lookup"><span data-stu-id="d63c8-202">string</span></span>  | <span data-ttu-id="d63c8-203">申請の ID です。</span><span class="sxs-lookup"><span data-stu-id="d63c8-203">The ID for the submission.</span></span>  |
| <span data-ttu-id="d63c8-204">flightId</span><span class="sxs-lookup"><span data-stu-id="d63c8-204">flightId</span></span>           | <span data-ttu-id="d63c8-205">string</span><span class="sxs-lookup"><span data-stu-id="d63c8-205">string</span></span>  |  <span data-ttu-id="d63c8-206">申請が関連付けられているパッケージ フライトの ID です。</span><span class="sxs-lookup"><span data-stu-id="d63c8-206">The ID of the package flight that the submission is associated with.</span></span>  |  
| <span data-ttu-id="d63c8-207">status</span><span class="sxs-lookup"><span data-stu-id="d63c8-207">status</span></span>           | <span data-ttu-id="d63c8-208">string</span><span class="sxs-lookup"><span data-stu-id="d63c8-208">string</span></span>  | <span data-ttu-id="d63c8-209">申請の状態。</span><span class="sxs-lookup"><span data-stu-id="d63c8-209">The status of the submission.</span></span> <span data-ttu-id="d63c8-210">次のいずれかの値を使用できます。</span><span class="sxs-lookup"><span data-stu-id="d63c8-210">This can be one of the following values:</span></span> <ul><li><span data-ttu-id="d63c8-211">なし</span><span class="sxs-lookup"><span data-stu-id="d63c8-211">None</span></span></li><li><span data-ttu-id="d63c8-212">Canceled</span><span class="sxs-lookup"><span data-stu-id="d63c8-212">Canceled</span></span></li><li><span data-ttu-id="d63c8-213">PendingCommit</span><span class="sxs-lookup"><span data-stu-id="d63c8-213">PendingCommit</span></span></li><li><span data-ttu-id="d63c8-214">CommitStarted</span><span class="sxs-lookup"><span data-stu-id="d63c8-214">CommitStarted</span></span></li><li><span data-ttu-id="d63c8-215">CommitFailed</span><span class="sxs-lookup"><span data-stu-id="d63c8-215">CommitFailed</span></span></li><li><span data-ttu-id="d63c8-216">PendingPublication</span><span class="sxs-lookup"><span data-stu-id="d63c8-216">PendingPublication</span></span></li><li><span data-ttu-id="d63c8-217">公開</span><span class="sxs-lookup"><span data-stu-id="d63c8-217">Publishing</span></span></li><li><span data-ttu-id="d63c8-218">公開済み</span><span class="sxs-lookup"><span data-stu-id="d63c8-218">Published</span></span></li><li><span data-ttu-id="d63c8-219">PublishFailed</span><span class="sxs-lookup"><span data-stu-id="d63c8-219">PublishFailed</span></span></li><li><span data-ttu-id="d63c8-220">PreProcessing</span><span class="sxs-lookup"><span data-stu-id="d63c8-220">PreProcessing</span></span></li><li><span data-ttu-id="d63c8-221">PreProcessingFailed</span><span class="sxs-lookup"><span data-stu-id="d63c8-221">PreProcessingFailed</span></span></li><li><span data-ttu-id="d63c8-222">認定</span><span class="sxs-lookup"><span data-stu-id="d63c8-222">Certification</span></span></li><li><span data-ttu-id="d63c8-223">CertificationFailed</span><span class="sxs-lookup"><span data-stu-id="d63c8-223">CertificationFailed</span></span></li><li><span data-ttu-id="d63c8-224">リリース</span><span class="sxs-lookup"><span data-stu-id="d63c8-224">Release</span></span></li><li><span data-ttu-id="d63c8-225">ReleaseFailed</span><span class="sxs-lookup"><span data-stu-id="d63c8-225">ReleaseFailed</span></span></li></ul>   |
| <span data-ttu-id="d63c8-226">statusDetails</span><span class="sxs-lookup"><span data-stu-id="d63c8-226">statusDetails</span></span>           | <span data-ttu-id="d63c8-227">オブジェクト</span><span class="sxs-lookup"><span data-stu-id="d63c8-227">object</span></span>  |  <span data-ttu-id="d63c8-228">エラーに関する情報など、申請のステータスに関する追加情報が保持される[ステータスの詳細に関するリソース](#status-details-object)です。</span><span class="sxs-lookup"><span data-stu-id="d63c8-228">A [status details resource](#status-details-object) that contains additional details about the status of the submission, including information about any errors.</span></span>  |
| <span data-ttu-id="d63c8-229">flightPackages</span><span class="sxs-lookup"><span data-stu-id="d63c8-229">flightPackages</span></span>           | <span data-ttu-id="d63c8-230">array</span><span class="sxs-lookup"><span data-stu-id="d63c8-230">array</span></span>  | <span data-ttu-id="d63c8-231">申請の各パッケージに関する詳細を提供する[フライト パッケージ リソース](#flight-package-object)が含まれています。</span><span class="sxs-lookup"><span data-stu-id="d63c8-231">Contains [flight package resources](#flight-package-object) that provide details about each package in the submission.</span></span>   |
| <span data-ttu-id="d63c8-232">packageDeliveryOptions</span><span class="sxs-lookup"><span data-stu-id="d63c8-232">packageDeliveryOptions</span></span>    | <span data-ttu-id="d63c8-233">オブジェクト</span><span class="sxs-lookup"><span data-stu-id="d63c8-233">object</span></span>  | <span data-ttu-id="d63c8-234">申請の段階的なパッケージのロールアウトと必須の更新の設定が含まれた[パッケージ配布オプション リソース](#package-delivery-options-object)です。</span><span class="sxs-lookup"><span data-stu-id="d63c8-234">A [package delivery options resource](#package-delivery-options-object) that contains gradual package rollout and mandatory update settings for the submission.</span></span>   |
| <span data-ttu-id="d63c8-235">fileUploadUrl</span><span class="sxs-lookup"><span data-stu-id="d63c8-235">fileUploadUrl</span></span>           | <span data-ttu-id="d63c8-236">string</span><span class="sxs-lookup"><span data-stu-id="d63c8-236">string</span></span>  | <span data-ttu-id="d63c8-237">申請のパッケージのアップロードに使用する共有アクセス署名 (SAS) URI です。</span><span class="sxs-lookup"><span data-stu-id="d63c8-237">The shared access signature (SAS) URI for uploading any packages for the submission.</span></span> <span data-ttu-id="d63c8-238">申請用に新しいパッケージを追加する場合は、パッケージを含む ZIP アーカイブをこの URI にアップロードします。</span><span class="sxs-lookup"><span data-stu-id="d63c8-238">If you are adding new packages for the submission, upload the ZIP archive that contains the packages to this URI.</span></span> <span data-ttu-id="d63c8-239">詳しくは、「[パッケージ フライトの申請の作成](#create-a-package-flight-submission)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d63c8-239">For more information, see [Create a package flight submission](#create-a-package-flight-submission).</span></span>  |
| <span data-ttu-id="d63c8-240">targetPublishMode</span><span class="sxs-lookup"><span data-stu-id="d63c8-240">targetPublishMode</span></span>           | <span data-ttu-id="d63c8-241">string</span><span class="sxs-lookup"><span data-stu-id="d63c8-241">string</span></span>  | <span data-ttu-id="d63c8-242">申請の公開モードです。</span><span class="sxs-lookup"><span data-stu-id="d63c8-242">The publish mode for the submission.</span></span> <span data-ttu-id="d63c8-243">次のいずれかの値を使用できます。</span><span class="sxs-lookup"><span data-stu-id="d63c8-243">This can be one of the following values:</span></span> <ul><li><span data-ttu-id="d63c8-244">即時</span><span class="sxs-lookup"><span data-stu-id="d63c8-244">Immediate</span></span></li><li><span data-ttu-id="d63c8-245">Manual</span><span class="sxs-lookup"><span data-stu-id="d63c8-245">Manual</span></span></li><li><span data-ttu-id="d63c8-246">SpecificDate</span><span class="sxs-lookup"><span data-stu-id="d63c8-246">SpecificDate</span></span></li></ul> |
| <span data-ttu-id="d63c8-247">targetPublishDate</span><span class="sxs-lookup"><span data-stu-id="d63c8-247">targetPublishDate</span></span>           | <span data-ttu-id="d63c8-248">string</span><span class="sxs-lookup"><span data-stu-id="d63c8-248">string</span></span>  | <span data-ttu-id="d63c8-249">*targetPublishMode* が SpecificDate に設定されている場合、ISO 8601 形式での申請の公開日です。</span><span class="sxs-lookup"><span data-stu-id="d63c8-249">The publish date for the submission in ISO 8601 format, if the *targetPublishMode* is set to SpecificDate.</span></span>  |
| <span data-ttu-id="d63c8-250">notesForCertification</span><span class="sxs-lookup"><span data-stu-id="d63c8-250">notesForCertification</span></span>           | <span data-ttu-id="d63c8-251">string</span><span class="sxs-lookup"><span data-stu-id="d63c8-251">string</span></span>  |  <span data-ttu-id="d63c8-252">テスト アカウントの資格情報や、機能のアクセスおよび検証手順など、審査担当者に対して追加情報を提供します。</span><span class="sxs-lookup"><span data-stu-id="d63c8-252">Provides additional info for the certification testers, such as test account credentials and steps to access and verify features.</span></span> <span data-ttu-id="d63c8-253">詳しくは、「[認定の注意書き](https://msdn.microsoft.com/windows/uwp/publish/notes-for-certification)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d63c8-253">For more information, see [Notes for certification](https://msdn.microsoft.com/windows/uwp/publish/notes-for-certification).</span></span> |

<span id="status-details-object" />

### <a name="status-details-resource"></a><span data-ttu-id="d63c8-254">ステータスの詳細に関するリソース</span><span class="sxs-lookup"><span data-stu-id="d63c8-254">Status details resource</span></span>

<span data-ttu-id="d63c8-255">このリソースには、申請の状態についての追加情報が保持されます。</span><span class="sxs-lookup"><span data-stu-id="d63c8-255">This resource contains additional details about the status of a submission.</span></span> <span data-ttu-id="d63c8-256">このリソースには、次の値があります。</span><span class="sxs-lookup"><span data-stu-id="d63c8-256">This resource has the following values.</span></span>

| <span data-ttu-id="d63c8-257">Value</span><span class="sxs-lookup"><span data-stu-id="d63c8-257">Value</span></span>           | <span data-ttu-id="d63c8-258">種類</span><span class="sxs-lookup"><span data-stu-id="d63c8-258">Type</span></span>    | <span data-ttu-id="d63c8-259">説明</span><span class="sxs-lookup"><span data-stu-id="d63c8-259">Description</span></span>                   |
|-----------------|---------|------|
|  <span data-ttu-id="d63c8-260">errors</span><span class="sxs-lookup"><span data-stu-id="d63c8-260">errors</span></span>               |    <span data-ttu-id="d63c8-261">オブジェクト</span><span class="sxs-lookup"><span data-stu-id="d63c8-261">object</span></span>     |   <span data-ttu-id="d63c8-262">申請のエラーの詳細が保持される[ステータスの詳細リソース](#status-detail-object)の配列です。</span><span class="sxs-lookup"><span data-stu-id="d63c8-262">An array of [status detail resources](#status-detail-object) that contain error details for the submission.</span></span>   |     
|  <span data-ttu-id="d63c8-263">warnings</span><span class="sxs-lookup"><span data-stu-id="d63c8-263">warnings</span></span>               |   <span data-ttu-id="d63c8-264">オブジェクト</span><span class="sxs-lookup"><span data-stu-id="d63c8-264">object</span></span>      | <span data-ttu-id="d63c8-265">申請の警告の詳細が保持される[ステータスの詳細リソース](#status-detail-object)の配列です。</span><span class="sxs-lookup"><span data-stu-id="d63c8-265">An array of [status detail resources](#status-detail-object) that contain warning details for the submission.</span></span>     |
|  <span data-ttu-id="d63c8-266">certificationReports</span><span class="sxs-lookup"><span data-stu-id="d63c8-266">certificationReports</span></span>               |     <span data-ttu-id="d63c8-267">オブジェクト</span><span class="sxs-lookup"><span data-stu-id="d63c8-267">object</span></span>    |   <span data-ttu-id="d63c8-268">申請の認定レポート データへのアクセスを提供する[認定レポート リソース](#certification-report-object)です。</span><span class="sxs-lookup"><span data-stu-id="d63c8-268">An array of [certification report resources](#certification-report-object) that provide access to the certification report data for the submission.</span></span> <span data-ttu-id="d63c8-269">認定されなかった場合に、これらのレポートから詳しい情報を知ることができます。</span><span class="sxs-lookup"><span data-stu-id="d63c8-269">You can examine these reports for more information if the certification fails.</span></span>    |  


<span id="status-detail-object" />

### <a name="status-detail-resource"></a><span data-ttu-id="d63c8-270">ステータスの詳細に関するリソース</span><span class="sxs-lookup"><span data-stu-id="d63c8-270">Status detail resource</span></span>

<span data-ttu-id="d63c8-271">このリソースには、申請に関連するエラーや警告についての追加情報が保持されます。</span><span class="sxs-lookup"><span data-stu-id="d63c8-271">This resource contains additional information about any related errors or warnings for a submission.</span></span> <span data-ttu-id="d63c8-272">このリソースには、次の値があります。</span><span class="sxs-lookup"><span data-stu-id="d63c8-272">This resource has the following values.</span></span>

| <span data-ttu-id="d63c8-273">Value</span><span class="sxs-lookup"><span data-stu-id="d63c8-273">Value</span></span>           | <span data-ttu-id="d63c8-274">種類</span><span class="sxs-lookup"><span data-stu-id="d63c8-274">Type</span></span>    | <span data-ttu-id="d63c8-275">説明</span><span class="sxs-lookup"><span data-stu-id="d63c8-275">Description</span></span>       |
|-----------------|---------|------|
|  <span data-ttu-id="d63c8-276">code</span><span class="sxs-lookup"><span data-stu-id="d63c8-276">code</span></span>               |    <span data-ttu-id="d63c8-277">string</span><span class="sxs-lookup"><span data-stu-id="d63c8-277">string</span></span>     |   <span data-ttu-id="d63c8-278">エラーや警告の種類を説明する[申請ステータス コード](#submission-status-code)です。</span><span class="sxs-lookup"><span data-stu-id="d63c8-278">A [submission status code](#submission-status-code) that describes the type of error or warning.</span></span> |  
|  <span data-ttu-id="d63c8-279">details</span><span class="sxs-lookup"><span data-stu-id="d63c8-279">details</span></span>               |     <span data-ttu-id="d63c8-280">string</span><span class="sxs-lookup"><span data-stu-id="d63c8-280">string</span></span>    |  <span data-ttu-id="d63c8-281">問題についての詳細が含まれるメッセージです。</span><span class="sxs-lookup"><span data-stu-id="d63c8-281">A message with more details about the issue.</span></span>     |


<span id="certification-report-object" />

### <a name="certification-report-resource"></a><span data-ttu-id="d63c8-282">認定レポート リソース</span><span class="sxs-lookup"><span data-stu-id="d63c8-282">Certification report resource</span></span>

<span data-ttu-id="d63c8-283">このリソースは、申請の認定レポート データへのアクセスを提供します。</span><span class="sxs-lookup"><span data-stu-id="d63c8-283">This resource provides access to the certification report data for a submission.</span></span> <span data-ttu-id="d63c8-284">このリソースには、次の値があります。</span><span class="sxs-lookup"><span data-stu-id="d63c8-284">This resource has the following values.</span></span>

| <span data-ttu-id="d63c8-285">Value</span><span class="sxs-lookup"><span data-stu-id="d63c8-285">Value</span></span>           | <span data-ttu-id="d63c8-286">種類</span><span class="sxs-lookup"><span data-stu-id="d63c8-286">Type</span></span>    | <span data-ttu-id="d63c8-287">説明</span><span class="sxs-lookup"><span data-stu-id="d63c8-287">Description</span></span>         |
|-----------------|---------|------|
|     <span data-ttu-id="d63c8-288">date</span><span class="sxs-lookup"><span data-stu-id="d63c8-288">date</span></span>            |    <span data-ttu-id="d63c8-289">string</span><span class="sxs-lookup"><span data-stu-id="d63c8-289">string</span></span>     |  <span data-ttu-id="d63c8-290">日付と ISO 8601 形式でレポートが生成された時刻。</span><span class="sxs-lookup"><span data-stu-id="d63c8-290">The date and time the report was generated, in ISO 8601 format.</span></span>    |
|     <span data-ttu-id="d63c8-291">reportUrl</span><span class="sxs-lookup"><span data-stu-id="d63c8-291">reportUrl</span></span>            |    <span data-ttu-id="d63c8-292">string</span><span class="sxs-lookup"><span data-stu-id="d63c8-292">string</span></span>     |  <span data-ttu-id="d63c8-293">レポートにアクセスできる URL です。</span><span class="sxs-lookup"><span data-stu-id="d63c8-293">The URL at which you can access the report.</span></span>    |


<span id="flight-package-object" />

### <a name="flight-package-resource"></a><span data-ttu-id="d63c8-294">フライト パッケージ リソース</span><span class="sxs-lookup"><span data-stu-id="d63c8-294">Flight package resource</span></span>

<span data-ttu-id="d63c8-295">このリソースは、申請に含まれるパッケージについての詳細情報を提供します。</span><span class="sxs-lookup"><span data-stu-id="d63c8-295">This resource provides details about a package in a submission.</span></span>

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

<span data-ttu-id="d63c8-296">このリソースには、次の値があります。</span><span class="sxs-lookup"><span data-stu-id="d63c8-296">This resource has the following values.</span></span>

> [!NOTE]
> <span data-ttu-id="d63c8-297">[パッケージ フライトの申請の更新](update-a-flight-submission.md)のメソッドを呼び出す場合、要求本文に必要なのは、このオブジェクトの *fileName*、*fileStatus*、*minimumDirectXVersion*、*minimumSystemRam* の値のみです。</span><span class="sxs-lookup"><span data-stu-id="d63c8-297">When calling the [update a package flight submission](update-a-flight-submission.md) method, only the *fileName*, *fileStatus*, *minimumDirectXVersion*, and *minimumSystemRam* values of this object are required in the request body.</span></span> <span data-ttu-id="d63c8-298">パートナー センターでは、その他の値が設定されます。</span><span class="sxs-lookup"><span data-stu-id="d63c8-298">The other values are populated by Partner Center.</span></span>

| <span data-ttu-id="d63c8-299">Value</span><span class="sxs-lookup"><span data-stu-id="d63c8-299">Value</span></span>           | <span data-ttu-id="d63c8-300">種類</span><span class="sxs-lookup"><span data-stu-id="d63c8-300">Type</span></span>    | <span data-ttu-id="d63c8-301">説明</span><span class="sxs-lookup"><span data-stu-id="d63c8-301">Description</span></span>              |
|-----------------|---------|------|
| <span data-ttu-id="d63c8-302">fileName</span><span class="sxs-lookup"><span data-stu-id="d63c8-302">fileName</span></span>   |   <span data-ttu-id="d63c8-303">string</span><span class="sxs-lookup"><span data-stu-id="d63c8-303">string</span></span>      |  <span data-ttu-id="d63c8-304">パッケージの名前。</span><span class="sxs-lookup"><span data-stu-id="d63c8-304">The name of the package.</span></span>    |  
| <span data-ttu-id="d63c8-305">fileStatus</span><span class="sxs-lookup"><span data-stu-id="d63c8-305">fileStatus</span></span>    | <span data-ttu-id="d63c8-306">string</span><span class="sxs-lookup"><span data-stu-id="d63c8-306">string</span></span>    |  <span data-ttu-id="d63c8-307">パッケージの状態です。</span><span class="sxs-lookup"><span data-stu-id="d63c8-307">The status of the package.</span></span> <span data-ttu-id="d63c8-308">次のいずれかの値を使用できます。</span><span class="sxs-lookup"><span data-stu-id="d63c8-308">This can be one of the following values:</span></span> <ul><li><span data-ttu-id="d63c8-309">なし</span><span class="sxs-lookup"><span data-stu-id="d63c8-309">None</span></span></li><li><span data-ttu-id="d63c8-310">PendingUpload</span><span class="sxs-lookup"><span data-stu-id="d63c8-310">PendingUpload</span></span></li><li><span data-ttu-id="d63c8-311">Uploaded</span><span class="sxs-lookup"><span data-stu-id="d63c8-311">Uploaded</span></span></li><li><span data-ttu-id="d63c8-312">PendingDelete</span><span class="sxs-lookup"><span data-stu-id="d63c8-312">PendingDelete</span></span></li></ul>    |  
| <span data-ttu-id="d63c8-313">id</span><span class="sxs-lookup"><span data-stu-id="d63c8-313">id</span></span>    |  <span data-ttu-id="d63c8-314">string</span><span class="sxs-lookup"><span data-stu-id="d63c8-314">string</span></span>   |  <span data-ttu-id="d63c8-315">パッケージを一意に識別する ID です。</span><span class="sxs-lookup"><span data-stu-id="d63c8-315">An ID that uniquely identifies the package.</span></span> <span data-ttu-id="d63c8-316">この値は、パートナー センターで使用されます。</span><span class="sxs-lookup"><span data-stu-id="d63c8-316">This value is used by Partner Center.</span></span>   |     
| <span data-ttu-id="d63c8-317">version</span><span class="sxs-lookup"><span data-stu-id="d63c8-317">version</span></span>    |  <span data-ttu-id="d63c8-318">string</span><span class="sxs-lookup"><span data-stu-id="d63c8-318">string</span></span>   |  <span data-ttu-id="d63c8-319">アプリ パッケージのバージョンです。</span><span class="sxs-lookup"><span data-stu-id="d63c8-319">The version of the app package.</span></span> <span data-ttu-id="d63c8-320">詳しくは、「[パッケージ バージョンの番号付け](https://msdn.microsoft.com/windows/uwp/publish/package-version-numbering)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d63c8-320">For more information, see [Package version numbering](https://msdn.microsoft.com/windows/uwp/publish/package-version-numbering).</span></span>   |   
| <span data-ttu-id="d63c8-321">architecture</span><span class="sxs-lookup"><span data-stu-id="d63c8-321">architecture</span></span>    |  <span data-ttu-id="d63c8-322">string</span><span class="sxs-lookup"><span data-stu-id="d63c8-322">string</span></span>   |  <span data-ttu-id="d63c8-323">アプリ パッケージのアーキテクチャ (ARM など) です。</span><span class="sxs-lookup"><span data-stu-id="d63c8-323">The architecture of the app package (for example, ARM).</span></span>   |     
| <span data-ttu-id="d63c8-324">languages</span><span class="sxs-lookup"><span data-stu-id="d63c8-324">languages</span></span>    | <span data-ttu-id="d63c8-325">array</span><span class="sxs-lookup"><span data-stu-id="d63c8-325">array</span></span>    |  <span data-ttu-id="d63c8-326">アプリがサポートする言語の言語コードの配列です。</span><span class="sxs-lookup"><span data-stu-id="d63c8-326">An array of language codes for the languages the app supports.</span></span> <span data-ttu-id="d63c8-327">詳しくは、「[サポートされる言語パックと既定の](https://msdn.microsoft.com/windows/uwp/publish/supported-languages)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d63c8-327">For more information, see For more information, see [Supported languages](https://msdn.microsoft.com/windows/uwp/publish/supported-languages).</span></span>    |     
| <span data-ttu-id="d63c8-328">capabilities</span><span class="sxs-lookup"><span data-stu-id="d63c8-328">capabilities</span></span>    |  <span data-ttu-id="d63c8-329">array</span><span class="sxs-lookup"><span data-stu-id="d63c8-329">array</span></span>   |  <span data-ttu-id="d63c8-330">パッケージに必要な機能の配列です。</span><span class="sxs-lookup"><span data-stu-id="d63c8-330">An array of capabilities required by the package.</span></span> <span data-ttu-id="d63c8-331">機能について詳しくは、「[アプリ機能の宣言](https://msdn.microsoft.com/windows/uwp/packaging/app-capability-declarations)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d63c8-331">For more information about capabilities, see [App capability declarations](https://msdn.microsoft.com/windows/uwp/packaging/app-capability-declarations).</span></span>   |     
| <span data-ttu-id="d63c8-332">minimumDirectXVersion</span><span class="sxs-lookup"><span data-stu-id="d63c8-332">minimumDirectXVersion</span></span>    |  <span data-ttu-id="d63c8-333">string</span><span class="sxs-lookup"><span data-stu-id="d63c8-333">string</span></span>   |  <span data-ttu-id="d63c8-334">アプリ パッケージによってサポートされる DirectX の最小バージョンです。</span><span class="sxs-lookup"><span data-stu-id="d63c8-334">The minimum DirectX version that is supported by the app package.</span></span> <span data-ttu-id="d63c8-335">これは Windows 8.x をターゲットにするアプリにしか設定できません。その他バージョンをターゲットにするアプリでは無視されます。</span><span class="sxs-lookup"><span data-stu-id="d63c8-335">This can be set only for apps that target Windows 8.x; it is ignored for apps that target other versions.</span></span> <span data-ttu-id="d63c8-336">次のいずれかの値を使用できます。</span><span class="sxs-lookup"><span data-stu-id="d63c8-336">This can be one of the following values:</span></span> <ul><li><span data-ttu-id="d63c8-337">なし</span><span class="sxs-lookup"><span data-stu-id="d63c8-337">None</span></span></li><li><span data-ttu-id="d63c8-338">DirectX93</span><span class="sxs-lookup"><span data-stu-id="d63c8-338">DirectX93</span></span></li><li><span data-ttu-id="d63c8-339">DirectX100</span><span class="sxs-lookup"><span data-stu-id="d63c8-339">DirectX100</span></span></li></ul>   |     
| <span data-ttu-id="d63c8-340">minimumSystemRam</span><span class="sxs-lookup"><span data-stu-id="d63c8-340">minimumSystemRam</span></span>    | <span data-ttu-id="d63c8-341">string</span><span class="sxs-lookup"><span data-stu-id="d63c8-341">string</span></span>    |  <span data-ttu-id="d63c8-342">アプリ パッケージに必要な RAM の最小サイズです。</span><span class="sxs-lookup"><span data-stu-id="d63c8-342">The minimum RAM that is required by the app package.</span></span> <span data-ttu-id="d63c8-343">これは Windows 8.x をターゲットにするアプリにしか設定できません。その他バージョンをターゲットにするアプリでは無視されます。</span><span class="sxs-lookup"><span data-stu-id="d63c8-343">This can be set only for apps that target Windows 8.x; it is ignored for apps that target other versions.</span></span> <span data-ttu-id="d63c8-344">次のいずれかの値を使用できます。</span><span class="sxs-lookup"><span data-stu-id="d63c8-344">This can be one of the following values:</span></span> <ul><li><span data-ttu-id="d63c8-345">なし</span><span class="sxs-lookup"><span data-stu-id="d63c8-345">None</span></span></li><li><span data-ttu-id="d63c8-346">Memory2GB</span><span class="sxs-lookup"><span data-stu-id="d63c8-346">Memory2GB</span></span></li></ul>   |    


<span id="package-delivery-options-object" />

### <a name="package-delivery-options-resource"></a><span data-ttu-id="d63c8-347">パッケージの配信オプション リソース</span><span class="sxs-lookup"><span data-stu-id="d63c8-347">Package delivery options resource</span></span>

<span data-ttu-id="d63c8-348">このリソースには、申請の段階的なパッケージのロールアウトと必須の更新の設定が含まれています。</span><span class="sxs-lookup"><span data-stu-id="d63c8-348">This resource contains gradual package rollout and mandatory update settings for the submission.</span></span>

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

<span data-ttu-id="d63c8-349">このリソースには、次の値があります。</span><span class="sxs-lookup"><span data-stu-id="d63c8-349">This resource has the following values.</span></span>

| <span data-ttu-id="d63c8-350">Value</span><span class="sxs-lookup"><span data-stu-id="d63c8-350">Value</span></span>           | <span data-ttu-id="d63c8-351">種類</span><span class="sxs-lookup"><span data-stu-id="d63c8-351">Type</span></span>    | <span data-ttu-id="d63c8-352">説明</span><span class="sxs-lookup"><span data-stu-id="d63c8-352">Description</span></span>        |
|-----------------|---------|------|
| <span data-ttu-id="d63c8-353">packageRollout</span><span class="sxs-lookup"><span data-stu-id="d63c8-353">packageRollout</span></span>   |   <span data-ttu-id="d63c8-354">オブジェクト</span><span class="sxs-lookup"><span data-stu-id="d63c8-354">object</span></span>      |   <span data-ttu-id="d63c8-355">申請の段階的なパッケージのロールアウトの設定が含まれた[パッケージのロールアウトのリソース](#package-rollout-object)です。</span><span class="sxs-lookup"><span data-stu-id="d63c8-355">A [package rollout resource](#package-rollout-object) that contains gradual package rollout settings for the submission.</span></span>    |  
| <span data-ttu-id="d63c8-356">isMandatoryUpdate</span><span class="sxs-lookup"><span data-stu-id="d63c8-356">isMandatoryUpdate</span></span>    | <span data-ttu-id="d63c8-357">boolean</span><span class="sxs-lookup"><span data-stu-id="d63c8-357">boolean</span></span>    |  <span data-ttu-id="d63c8-358">この申請のパッケージを自己インストールのアプリの更新のために必須として扱うかどうかを指定します。</span><span class="sxs-lookup"><span data-stu-id="d63c8-358">Indicates whether you want to treat the packages in this submission as mandatory for self-installing app updates.</span></span> <span data-ttu-id="d63c8-359">自己インストールのアプリの更新のために必須なパッケージについて詳しくは、「[アプリのパッケージの更新をダウンロードしてインストールする](../packaging/self-install-package-updates.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d63c8-359">For more information about mandatory packages for self-installing app updates, see [Download and install package updates for your app](../packaging/self-install-package-updates.md).</span></span>    |  
| <span data-ttu-id="d63c8-360">mandatoryUpdateEffectiveDate</span><span class="sxs-lookup"><span data-stu-id="d63c8-360">mandatoryUpdateEffectiveDate</span></span>    |  <span data-ttu-id="d63c8-361">date</span><span class="sxs-lookup"><span data-stu-id="d63c8-361">date</span></span>   |  <span data-ttu-id="d63c8-362">この申請のパッケージが必須となる日時 (ISO 8601 形式、UTC タイムゾーン)。</span><span class="sxs-lookup"><span data-stu-id="d63c8-362">The date and time when the packages in this submission become mandatory, in ISO 8601 format and UTC time zone.</span></span>   |        

<span id="package-rollout-object" />

### <a name="package-rollout-resource"></a><span data-ttu-id="d63c8-363">パッケージのロールアウトのリソース</span><span class="sxs-lookup"><span data-stu-id="d63c8-363">Package rollout resource</span></span>

<span data-ttu-id="d63c8-364">このリソースには、申請の段階的な[パッケージのロールアウトの設定](#manage-gradual-package-rollout)が含まれています。</span><span class="sxs-lookup"><span data-stu-id="d63c8-364">This resource contains gradual [package rollout settings](#manage-gradual-package-rollout) for the submission.</span></span> <span data-ttu-id="d63c8-365">このリソースには、次の値があります。</span><span class="sxs-lookup"><span data-stu-id="d63c8-365">This resource has the following values.</span></span>

| <span data-ttu-id="d63c8-366">Value</span><span class="sxs-lookup"><span data-stu-id="d63c8-366">Value</span></span>           | <span data-ttu-id="d63c8-367">種類</span><span class="sxs-lookup"><span data-stu-id="d63c8-367">Type</span></span>    | <span data-ttu-id="d63c8-368">説明</span><span class="sxs-lookup"><span data-stu-id="d63c8-368">Description</span></span>        |
|-----------------|---------|------|
| <span data-ttu-id="d63c8-369">isPackageRollout</span><span class="sxs-lookup"><span data-stu-id="d63c8-369">isPackageRollout</span></span>   |   <span data-ttu-id="d63c8-370">boolean</span><span class="sxs-lookup"><span data-stu-id="d63c8-370">boolean</span></span>      |  <span data-ttu-id="d63c8-371">申請の段階的なパッケージのロールアウトが有効化されているかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="d63c8-371">Indicates whether gradual package rollout is enabled for the submission.</span></span>    |  
| <span data-ttu-id="d63c8-372">packageRolloutPercentage</span><span class="sxs-lookup"><span data-stu-id="d63c8-372">packageRolloutPercentage</span></span>    | <span data-ttu-id="d63c8-373">float</span><span class="sxs-lookup"><span data-stu-id="d63c8-373">float</span></span>    |  <span data-ttu-id="d63c8-374">段階的なロールアウトでパッケージを受信するユーザーの割合。</span><span class="sxs-lookup"><span data-stu-id="d63c8-374">The percentage of users who will receive the packages in the gradual rollout.</span></span>    |  
| <span data-ttu-id="d63c8-375">packageRolloutStatus</span><span class="sxs-lookup"><span data-stu-id="d63c8-375">packageRolloutStatus</span></span>    |  <span data-ttu-id="d63c8-376">string</span><span class="sxs-lookup"><span data-stu-id="d63c8-376">string</span></span>   |  <span data-ttu-id="d63c8-377">段階的なパッケージのロールアウトの状態を示す、次の文字列のいずれかです。</span><span class="sxs-lookup"><span data-stu-id="d63c8-377">One of the following strings that indicates the status of the gradual package rollout:</span></span> <ul><li><span data-ttu-id="d63c8-378">PackageRolloutNotStarted</span><span class="sxs-lookup"><span data-stu-id="d63c8-378">PackageRolloutNotStarted</span></span></li><li><span data-ttu-id="d63c8-379">PackageRolloutInProgress</span><span class="sxs-lookup"><span data-stu-id="d63c8-379">PackageRolloutInProgress</span></span></li><li><span data-ttu-id="d63c8-380">PackageRolloutComplete</span><span class="sxs-lookup"><span data-stu-id="d63c8-380">PackageRolloutComplete</span></span></li><li><span data-ttu-id="d63c8-381">PackageRolloutStopped</span><span class="sxs-lookup"><span data-stu-id="d63c8-381">PackageRolloutStopped</span></span></li></ul>  |  
| <span data-ttu-id="d63c8-382">fallbackSubmissionId</span><span class="sxs-lookup"><span data-stu-id="d63c8-382">fallbackSubmissionId</span></span>    |  <span data-ttu-id="d63c8-383">string</span><span class="sxs-lookup"><span data-stu-id="d63c8-383">string</span></span>   |  <span data-ttu-id="d63c8-384">段階的なロールアウトのパッケージを入手しないユーザーが受信する申請のID。</span><span class="sxs-lookup"><span data-stu-id="d63c8-384">The ID of the submission that will be received by customers who do not get the gradual rollout packages.</span></span>   |          

> [!NOTE]
> <span data-ttu-id="d63c8-385">*PackageRolloutStatus*と*fallbackSubmissionId*値は、パートナー センターで割り当てられているし、開発者によって設定するためのものはありません。</span><span class="sxs-lookup"><span data-stu-id="d63c8-385">The *packageRolloutStatus* and *fallbackSubmissionId* values are assigned by Partner Center, and are not intended to be set by the developer.</span></span> <span data-ttu-id="d63c8-386">これらの値を要求本文に含めると、これらの値は無視されます。</span><span class="sxs-lookup"><span data-stu-id="d63c8-386">If you include these values in a request body, these values will be ignored.</span></span>

<span/>

## <a name="enums"></a><span data-ttu-id="d63c8-387">列挙型</span><span class="sxs-lookup"><span data-stu-id="d63c8-387">Enums</span></span>

<span data-ttu-id="d63c8-388">これらのメソッドでは、次の列挙型が使用されます。</span><span class="sxs-lookup"><span data-stu-id="d63c8-388">These methods use the following enums.</span></span>

<span id="submission-status-code" />

### <a name="submission-status-code"></a><span data-ttu-id="d63c8-389">申請の状態コード</span><span class="sxs-lookup"><span data-stu-id="d63c8-389">Submission status code</span></span>

<span data-ttu-id="d63c8-390">次のコードは、申請の状態を表します。</span><span class="sxs-lookup"><span data-stu-id="d63c8-390">The following codes represent the status of a submission.</span></span>

| <span data-ttu-id="d63c8-391">コード</span><span class="sxs-lookup"><span data-stu-id="d63c8-391">Code</span></span>           |  <span data-ttu-id="d63c8-392">説明</span><span class="sxs-lookup"><span data-stu-id="d63c8-392">Description</span></span>      |
|-----------------|---------------|
|  <span data-ttu-id="d63c8-393">なし</span><span class="sxs-lookup"><span data-stu-id="d63c8-393">None</span></span>            |     <span data-ttu-id="d63c8-394">コードが指定されていません。</span><span class="sxs-lookup"><span data-stu-id="d63c8-394">No code was specified.</span></span>         |     
|      <span data-ttu-id="d63c8-395">InvalidArchive</span><span class="sxs-lookup"><span data-stu-id="d63c8-395">InvalidArchive</span></span>        |     <span data-ttu-id="d63c8-396">パッケージが含まれる ZIP アーカイブは無効であるか、認識できないアーカイブ形式です。</span><span class="sxs-lookup"><span data-stu-id="d63c8-396">The ZIP archive containing the package is invalid or has an unrecognized archive format.</span></span>  |
| <span data-ttu-id="d63c8-397">MissingFiles</span><span class="sxs-lookup"><span data-stu-id="d63c8-397">MissingFiles</span></span> | <span data-ttu-id="d63c8-398">ZIP アーカイブに、申請データで指定されているすべてのファイルが含まれていないか、ファイルのアーカイブ内の場所が正しくありません。</span><span class="sxs-lookup"><span data-stu-id="d63c8-398">The ZIP archive does not have all files which were listed in your submission data, or they are in the wrong location in the archive.</span></span> |
| <span data-ttu-id="d63c8-399">PackageValidationFailed</span><span class="sxs-lookup"><span data-stu-id="d63c8-399">PackageValidationFailed</span></span> | <span data-ttu-id="d63c8-400">申請の 1 つ以上のパッケージを検証できませんでした。</span><span class="sxs-lookup"><span data-stu-id="d63c8-400">One or more packages in your submission failed to validate.</span></span> |
| <span data-ttu-id="d63c8-401">InvalidParameterValue</span><span class="sxs-lookup"><span data-stu-id="d63c8-401">InvalidParameterValue</span></span> | <span data-ttu-id="d63c8-402">要求本文に含まれるパラメーターの 1 つが無効です。</span><span class="sxs-lookup"><span data-stu-id="d63c8-402">One of the parameters in the request body is invalid.</span></span> |
| <span data-ttu-id="d63c8-403">InvalidOperation</span><span class="sxs-lookup"><span data-stu-id="d63c8-403">InvalidOperation</span></span> | <span data-ttu-id="d63c8-404">実行された操作は無効です。</span><span class="sxs-lookup"><span data-stu-id="d63c8-404">The operation you attempted is invalid.</span></span> |
| <span data-ttu-id="d63c8-405">InvalidState</span><span class="sxs-lookup"><span data-stu-id="d63c8-405">InvalidState</span></span> | <span data-ttu-id="d63c8-406">実行された操作は、パッケージ フライトの現在の状態では無効です。</span><span class="sxs-lookup"><span data-stu-id="d63c8-406">The operation you attempted is not valid for the current state of the package flight.</span></span> |
| <span data-ttu-id="d63c8-407">ResourceNotFound</span><span class="sxs-lookup"><span data-stu-id="d63c8-407">ResourceNotFound</span></span> | <span data-ttu-id="d63c8-408">指定されたパッケージ フライトは見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="d63c8-408">The specified package flight could not be found.</span></span> |
| <span data-ttu-id="d63c8-409">ServiceError</span><span class="sxs-lookup"><span data-stu-id="d63c8-409">ServiceError</span></span> | <span data-ttu-id="d63c8-410">内部サービス エラーのため、要求を処理できませんでした。</span><span class="sxs-lookup"><span data-stu-id="d63c8-410">An internal service error prevented the request from succeeding.</span></span> <span data-ttu-id="d63c8-411">もう一度要求を行ってください。</span><span class="sxs-lookup"><span data-stu-id="d63c8-411">Try the request again.</span></span> |
| <span data-ttu-id="d63c8-412">ListingOptOutWarning</span><span class="sxs-lookup"><span data-stu-id="d63c8-412">ListingOptOutWarning</span></span> | <span data-ttu-id="d63c8-413">開発者が以前の申請の登録情報を削除しているか、パッケージによってサポートされる登録情報を含めていませんでした。</span><span class="sxs-lookup"><span data-stu-id="d63c8-413">The developer removed a listing from a previous submission, or did not include listing information that is supported by the package.</span></span> |
| <span data-ttu-id="d63c8-414">ListingOptInWarning</span><span class="sxs-lookup"><span data-stu-id="d63c8-414">ListingOptInWarning</span></span>  | <span data-ttu-id="d63c8-415">開発者が登録情報を追加しました。</span><span class="sxs-lookup"><span data-stu-id="d63c8-415">The developer added a listing.</span></span> |
| <span data-ttu-id="d63c8-416">UpdateOnlyWarning</span><span class="sxs-lookup"><span data-stu-id="d63c8-416">UpdateOnlyWarning</span></span> | <span data-ttu-id="d63c8-417">開発者が、更新サポートしかないものを挿入しようとしています。</span><span class="sxs-lookup"><span data-stu-id="d63c8-417">The developer is trying to insert something that only has update support.</span></span> |
| <span data-ttu-id="d63c8-418">その他</span><span class="sxs-lookup"><span data-stu-id="d63c8-418">Other</span></span>  | <span data-ttu-id="d63c8-419">申請が非認識または未分類の状態です。</span><span class="sxs-lookup"><span data-stu-id="d63c8-419">The submission is in an unrecognized or uncategorized state.</span></span> |
| <span data-ttu-id="d63c8-420">PackageValidationWarning</span><span class="sxs-lookup"><span data-stu-id="d63c8-420">PackageValidationWarning</span></span> | <span data-ttu-id="d63c8-421">パッケージ検証プロセスの結果、警告が生成されました。</span><span class="sxs-lookup"><span data-stu-id="d63c8-421">The package validation process resulted in a warning.</span></span> |

<span/>

## <a name="related-topics"></a><span data-ttu-id="d63c8-422">関連トピック</span><span class="sxs-lookup"><span data-stu-id="d63c8-422">Related topics</span></span>

* [<span data-ttu-id="d63c8-423">作成し、Microsoft Store サービスを使用して送信の管理</span><span class="sxs-lookup"><span data-stu-id="d63c8-423">Create and manage submissions using Microsoft Store services</span></span>](create-and-manage-submissions-using-windows-store-services.md)
* [<span data-ttu-id="d63c8-424">Microsoft Store 送信 API を使用してパッケージのフライトを管理します。</span><span class="sxs-lookup"><span data-stu-id="d63c8-424">Manage package flights using the Microsoft Store submission API</span></span>](manage-flights.md)
* [<span data-ttu-id="d63c8-425">パッケージのフライトの送信を取得します。</span><span class="sxs-lookup"><span data-stu-id="d63c8-425">Get a package flight submission</span></span>](get-a-flight-submission.md)
* [<span data-ttu-id="d63c8-426">パッケージのフライトの提出を作成します。</span><span class="sxs-lookup"><span data-stu-id="d63c8-426">Create a package flight submission</span></span>](create-a-flight-submission.md)
* [<span data-ttu-id="d63c8-427">更新プログラム パッケージのフライトの送信</span><span class="sxs-lookup"><span data-stu-id="d63c8-427">Update a package flight submission</span></span>](update-a-flight-submission.md)
* [<span data-ttu-id="d63c8-428">パッケージのフライトの送信をコミットします。</span><span class="sxs-lookup"><span data-stu-id="d63c8-428">Commit a package flight submission</span></span>](commit-a-flight-submission.md)
* [<span data-ttu-id="d63c8-429">パッケージのフライトの送信を削除します。</span><span class="sxs-lookup"><span data-stu-id="d63c8-429">Delete a package flight submission</span></span>](delete-a-flight-submission.md)
* [<span data-ttu-id="d63c8-430">パッケージのフライトの送信の状態を取得します。</span><span class="sxs-lookup"><span data-stu-id="d63c8-430">Get the status of a package flight submission</span></span>](get-status-for-a-flight-submission.md)
