---
author: Xansky
ms.assetid: 66400066-24BF-4AF2-B52A-577F5C3CA474
description: Windows デベロッパー センター アカウントに登録されているアプリのアドオンの申請を管理するには、Microsoft Store 申請 API の以下のメソッドを使います。
title: アドオンの申請の管理
ms.author: mhopkins
ms.date: 04/17/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, Microsoft Store 申請 API, アドオンの申請, アプリ内製品, IAP
ms.localizationpriority: medium
ms.openlocfilehash: 78c4f1603b921320009305e9646a7227ff47e8e3
ms.sourcegitcommit: 72835733ec429a5deb6a11da4112336746e5e9cf
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/20/2018
ms.locfileid: "5171516"
---
# <a name="manage-add-on-submissions"></a><span data-ttu-id="d537e-104">アドオンの申請の管理</span><span class="sxs-lookup"><span data-stu-id="d537e-104">Manage add-on submissions</span></span>

<span data-ttu-id="d537e-105">Microsoft Store 申請 API には、アプリのアドオン (アプリ内製品または IAP とも呼ばれます) 申請を管理するために使用できるメソッドが用意されています。</span><span class="sxs-lookup"><span data-stu-id="d537e-105">The Microsoft Store submission API provides methods you can use to manage add-on (also known as in-app product or IAP) submissions for your apps.</span></span> <span data-ttu-id="d537e-106">Microsoft Store 申請 API の概要については、「[Microsoft Store サービスを使用した申請の作成と管理](create-and-manage-submissions-using-windows-store-services.md)」をご覧ください。この API を使用するための前提条件などの情報があります。</span><span class="sxs-lookup"><span data-stu-id="d537e-106">For an introduction to the Microsoft Store submission API, including prerequisites for using the API, see [Create and manage submissions using Microsoft Store services](create-and-manage-submissions-using-windows-store-services.md).</span></span>

> [!IMPORTANT]
> <span data-ttu-id="d537e-107">Microsoft Store 申請 API を使ってアドオンの提出を作成する場合、申請にさらに変更を加えるには、必ずデベロッパー センター ダッシュボードではなく API のみを使用してください。</span><span class="sxs-lookup"><span data-stu-id="d537e-107">If you use the Microsoft Store submission API to create a submission for an add-on, be sure to make further changes to the submission only by using the API, rather than the Dev Center dashboard.</span></span> <span data-ttu-id="d537e-108">最初に API を使って作成した申請を、ダッシュボードを使って変更した場合、API を使ってその申請を変更またはコミットすることができなくなります。</span><span class="sxs-lookup"><span data-stu-id="d537e-108">If you use the dashboard to change a submission that you originally created by using the API, you will no longer be able to change or commit that submission by using the API.</span></span> <span data-ttu-id="d537e-109">場合によっては、申請がエラー状態のままになり、申請プロセスを進めることができなくなります。</span><span class="sxs-lookup"><span data-stu-id="d537e-109">In some cases, the submission could be left in an error state where it cannot proceed in the submission process.</span></span> <span data-ttu-id="d537e-110">この場合、申請を削除して新しい申請を作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d537e-110">If this occurs, you must delete the submission and create a new submission.</span></span>

<span id="methods-for-add-on-submissions" />

## <a name="methods-for-managing-add-on-submissions"></a><span data-ttu-id="d537e-111">アドオンの申請を管理するためのメソッド</span><span class="sxs-lookup"><span data-stu-id="d537e-111">Methods for managing add-on submissions</span></span>

<span data-ttu-id="d537e-112">アドオンの申請を取得、作成、更新、コミット、または削除するには、次のメソッドを使用します。</span><span class="sxs-lookup"><span data-stu-id="d537e-112">Use the following methods to get, create, update, commit, or delete an add-on submission.</span></span> <span data-ttu-id="d537e-113">これらのメソッドを使用するには、アドオンをお客様自身のデベロッパー センター アカウントに用意しておく必要があります。</span><span class="sxs-lookup"><span data-stu-id="d537e-113">Before you can use these methods, the add-on must already exist in your Dev Center account.</span></span> <span data-ttu-id="d537e-114">アドオンは、[製品の種類と製品 ID を定義する](../publish/set-your-add-on-product-id.md)か、「[アドオンの管理](manage-add-ons.md)」で説明されている Microsoft Store 申請 API のメソッドを使って、ダッシュボードで作成できます。</span><span class="sxs-lookup"><span data-stu-id="d537e-114">You can create an add-on in the dashboard by [defining its product type and product ID](../publish/set-your-add-on-product-id.md) or by using the Microsoft Store submission API methods in described in [Manage add-ons](manage-add-ons.md).</span></span>

<table>
<colgroup>
<col width="10%" />
<col width="30%" />
<col width="60%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="d537e-115">メソッド</span><span class="sxs-lookup"><span data-stu-id="d537e-115">Method</span></span></th>
<th align="left"><span data-ttu-id="d537e-116">URI</span><span class="sxs-lookup"><span data-stu-id="d537e-116">URI</span></span></th>
<th align="left"><span data-ttu-id="d537e-117">説明</span><span class="sxs-lookup"><span data-stu-id="d537e-117">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr>
<td align="left"><span data-ttu-id="d537e-118">GET</span><span class="sxs-lookup"><span data-stu-id="d537e-118">GET</span></span></td>
<td align="left">https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/{id}/submissions/{submissionId}</td>
<td align="left"><a href="get-an-add-on-submission.md"><span data-ttu-id="d537e-119">既存のアドオンの申請を取得します</span><span class="sxs-lookup"><span data-stu-id="d537e-119">Get an existing add-on submission</span></span></a></td>
</tr>
<tr>
<td align="left"><span data-ttu-id="d537e-120">GET</span><span class="sxs-lookup"><span data-stu-id="d537e-120">GET</span></span></td>
<td align="left">https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/{id}/submissions/{submissionId}/status</td>
<td align="left"><a href="get-status-for-an-add-on-submission.md"><span data-ttu-id="d537e-121">既存のアドオンの申請の状態を取得します</span><span class="sxs-lookup"><span data-stu-id="d537e-121">Get the status of an existing add-on submission</span></span></a></td>
</tr>
<tr>
<td align="left"><span data-ttu-id="d537e-122">POST</span><span class="sxs-lookup"><span data-stu-id="d537e-122">POST</span></span></td>
<td align="left">https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/{id}/submissions</td>
<td align="left"><a href="create-an-add-on-submission.md"><span data-ttu-id="d537e-123">新しいアドオンの申請を作成します</span><span class="sxs-lookup"><span data-stu-id="d537e-123">Create a new add-on submission</span></span></a></td>
</tr>
<tr>
<td align="left"><span data-ttu-id="d537e-124">PUT</span><span class="sxs-lookup"><span data-stu-id="d537e-124">PUT</span></span></td>
<td align="left">https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/{id}/submissions/{submissionId}</td>
<td align="left"><a href="update-an-add-on-submission.md"><span data-ttu-id="d537e-125">既存のアドオンの申請を更新します</span><span class="sxs-lookup"><span data-stu-id="d537e-125">Update an existing add-on submission</span></span></a></td>
</tr>
<tr>
<td align="left"><span data-ttu-id="d537e-126">POST</span><span class="sxs-lookup"><span data-stu-id="d537e-126">POST</span></span></td>
<td align="left">https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/{id}/submissions/{submissionId}/commit</td>
<td align="left"><a href="commit-an-add-on-submission.md"><span data-ttu-id="d537e-127">新しいアドオンの申請または更新されたアドオンの申請をコミットします</span><span class="sxs-lookup"><span data-stu-id="d537e-127">Commit a new or updated add-on submission</span></span></a></td>
</tr>
<tr>
<td align="left"><span data-ttu-id="d537e-128">DELETE</span><span class="sxs-lookup"><span data-stu-id="d537e-128">DELETE</span></span></td>
<td align="left">https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/{id}/submissions/{submissionId}</td>
<td align="left"><a href="delete-an-add-on-submission.md"><span data-ttu-id="d537e-129">アドオンの申請を削除します</span><span class="sxs-lookup"><span data-stu-id="d537e-129">Delete an add-on submission</span></span></a></td>
</tr>
</tbody>
</table>

<span id="create-an-add-on-submission">

## <a name="create-an-add-on-submission"></a><span data-ttu-id="d537e-130">アドオンの申請の作成</span><span class="sxs-lookup"><span data-stu-id="d537e-130">Create an add-on submission</span></span>

<span data-ttu-id="d537e-131">アドオンの申請を作成するには、次のプロセスに従います。</span><span class="sxs-lookup"><span data-stu-id="d537e-131">To create a submission for an add-on, follow this process.</span></span>

1. <span data-ttu-id="d537e-132">「[Microsoft Store サービスを使用した申請の作成と管理](create-and-manage-submissions-using-windows-store-services.md)」に記載されている前提条件が満たされていない場合は、前提条件を整えてください。これには、Azure AD アプリケーションの Windows デベロッパー センター アカウントへの関連付けや、クライアント ID およびキーの取得が含まれます。</span><span class="sxs-lookup"><span data-stu-id="d537e-132">If you have not yet done so, complete the prerequisites described in [Create and manage submissions using Microsoft Store services](create-and-manage-submissions-using-windows-store-services.md), including associating an Azure AD application with your Windows Dev Center account and obtaining your client ID and key.</span></span> <span data-ttu-id="d537e-133">この作業は 1 度行うだけでよく、クライアント ID とキーを入手したら、新しい Azure AD アクセス トークンの作成が必要になったときに、いつでもそれらを再利用できます。</span><span class="sxs-lookup"><span data-stu-id="d537e-133">You only need to do this one time; after you have the client ID and key, you can reuse them any time you need to create a new Azure AD access token.</span></span>  

2. <span data-ttu-id="d537e-134">[Azure AD アクセス トークンを取得します](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)。</span><span class="sxs-lookup"><span data-stu-id="d537e-134">[Obtain an Azure AD access token](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token).</span></span> <span data-ttu-id="d537e-135">このアクセス トークンを Microsoft Store 申請 API のメソッドに渡す必要があります。</span><span class="sxs-lookup"><span data-stu-id="d537e-135">You must pass this access token to the methods in the Microsoft Store submission API.</span></span> <span data-ttu-id="d537e-136">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="d537e-136">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="d537e-137">トークンの有効期限が切れたら新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="d537e-137">After the token expires, you can obtain a new one.</span></span>

3. <span data-ttu-id="d537e-138">Microsoft Store 申請 API の次のメソッドを実行します。</span><span class="sxs-lookup"><span data-stu-id="d537e-138">Execute the following method in the Microsoft Store submission API.</span></span> <span data-ttu-id="d537e-139">このメソッドによって、新しい申請が作成され、審議中になります。これは、前回発行した申請のコピーです。</span><span class="sxs-lookup"><span data-stu-id="d537e-139">This method creates a new in-progress submission, which is a copy of your last published submission.</span></span> <span data-ttu-id="d537e-140">詳しくは、「[アドオンの申請の作成](create-an-add-on-submission.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d537e-140">For more information, see [Create an add-on submission](create-an-add-on-submission.md).</span></span>

    ```
    POST https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/{id}/submissions
    ```

    <span data-ttu-id="d537e-141">応答本文には、新しい申請の ID、申請用のアドオン アイコンを Azure Blob Storage にアップロードするための共有アクセス署名 (SAS) URI、および新しい申請のためのすべてのデータ (登録情報や料金情報など) を含む[アドオンの申請](#add-on-submission-object) リソースが含まれます。</span><span class="sxs-lookup"><span data-stu-id="d537e-141">The response body contains an [add-on submission](#add-on-submission-object) resource that includes the ID of the new submission, the shared access signature (SAS) URI for uploading any add-on icons for the submission to Azure Blob storage, and all of the data for the new submission (such as the listings and pricing information).</span></span>

    > [!NOTE]
    > <span data-ttu-id="d537e-142">SAS URI では、アカウント キーを必要とせずに、Azure Storage 内のセキュリティで保護されたリソースにアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="d537e-142">A SAS URI provides access to a secure resource in Azure storage without requiring account keys.</span></span> <span data-ttu-id="d537e-143">SAS URI の背景情報と Azure Blob Storage での SAS URI の使用については、「[Shared Access Signatures (SAS) の使用](https://azure.microsoft.com/documentation/articles/storage-dotnet-shared-access-signature-part-1)」と「[Shared Access Signature、第 2 部: BLOB ストレージでの SAS の作成と使用](https://azure.microsoft.com/documentation/articles/storage-dotnet-shared-access-signature-part-2/)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d537e-143">For background information about SAS URIs and their use with Azure Blob storage, see [Shared Access Signatures, Part 1: Understanding the SAS model](https://azure.microsoft.com/documentation/articles/storage-dotnet-shared-access-signature-part-1) and [Shared Access Signatures, Part 2: Create and use a SAS with Blob storage](https://azure.microsoft.com/documentation/articles/storage-dotnet-shared-access-signature-part-2/).</span></span>

4. <span data-ttu-id="d537e-144">申請用に新しいアイコンを追加する場合は、[アイコンを準備](https://msdn.microsoft.com/windows/uwp/publish/create-iap-descriptions#icon)して、ZIP アーカイブに追加します。</span><span class="sxs-lookup"><span data-stu-id="d537e-144">If you are adding new icons for the submission, [prepare the icons](https://msdn.microsoft.com/windows/uwp/publish/create-iap-descriptions#icon) and add them to a ZIP archive.</span></span>

5. <span data-ttu-id="d537e-145">新しい申請用に必要な変更を行って[アドオンの申請](#add-on-submission-object)データを更新し、次のメソッドを実行して申請を更新します。</span><span class="sxs-lookup"><span data-stu-id="d537e-145">Update the [add-on submission](#add-on-submission-object) data with any required changes for the new submission, and execute the following method to update the submission.</span></span> <span data-ttu-id="d537e-146">詳しくは、「[アドオンの申請の更新](update-an-add-on-submission.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d537e-146">For more information, see [Update an add-on submission](update-an-add-on-submission.md).</span></span>

    ```
    PUT https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/{id}/submissions/{submissionId}
    ```
      > [!NOTE]
      > <span data-ttu-id="d537e-147">申請用に新しいアイコンを追加する場合、ZIP アーカイブ内のアイコンのファイルの名前と相対パスを参照するように、申請データを更新してください。</span><span class="sxs-lookup"><span data-stu-id="d537e-147">If you are adding new icons for the submission, make sure you update the submission data to refer to the name and relative path of these files in the ZIP archive.</span></span>

4. <span data-ttu-id="d537e-148">申請用に新しいアイコンを追加する場合は、上記で呼び出した POST メソッドの応答本文に含まれていた SAS URI を使用して、ZIP アーカイブを [Azure Blob Storage](https://docs.microsoft.com/azure/storage/storage-introduction#blob-storage) にアップロードします。</span><span class="sxs-lookup"><span data-stu-id="d537e-148">If you are adding new icons for the submission, upload the ZIP archive to [Azure Blob storage](https://docs.microsoft.com/azure/storage/storage-introduction#blob-storage) using the SAS URI that was provided in the response body of the POST method you called earlier.</span></span> <span data-ttu-id="d537e-149">さまざまなプラットフォームでこれを行うために使用できる、次のようなさまざまな Azure ライブラリがあります。</span><span class="sxs-lookup"><span data-stu-id="d537e-149">There are different Azure libraries you can use to do this on a variety of platforms, including:</span></span>

    * [<span data-ttu-id="d537e-150">.NET 用 Azure Storage クライアント ライブラリ</span><span class="sxs-lookup"><span data-stu-id="d537e-150">Azure Storage Client Library for .NET</span></span>](https://docs.microsoft.com/azure/storage/storage-dotnet-how-to-use-blobs)
    * [<span data-ttu-id="d537e-151">Azure Storage SDK for Java</span><span class="sxs-lookup"><span data-stu-id="d537e-151">Azure Storage SDK for Java</span></span>](https://docs.microsoft.com/azure/storage/storage-java-how-to-use-blob-storage)
    * [<span data-ttu-id="d537e-152">Azure Storage SDK for Python</span><span class="sxs-lookup"><span data-stu-id="d537e-152">Azure Storage SDK for Python</span></span>](https://docs.microsoft.com/azure/storage/storage-python-how-to-use-blob-storage)

    <span data-ttu-id="d537e-153">次の C# コード例は、.NET 用 Azure Storage クライアント ライブラリの [CloudBlockBlob](https://msdn.microsoft.com/library/azure/microsoft.windowsazure.storage.blob.cloudblockblob.aspx) クラスを使用して ZIP アーカイブを Azure Blob Storage にアップロードする方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="d537e-153">The following C# code example demonstrates how to upload a ZIP archive to Azure Blob storage using the [CloudBlockBlob](https://msdn.microsoft.com/library/azure/microsoft.windowsazure.storage.blob.cloudblockblob.aspx) class in the Azure Storage Client Library for .NET.</span></span> <span data-ttu-id="d537e-154">この例では、ZIP アーカイブが既にストリーム オブジェクトに書き込まれていることを前提としています。</span><span class="sxs-lookup"><span data-stu-id="d537e-154">This example assumes that the ZIP archive has already been written to a stream object.</span></span>

    ```csharp
    string sasUrl = "https://productingestionbin1.blob.core.windows.net/ingestion/26920f66-b592-4439-9a9d-fb0f014902ec?sv=2014-02-14&sr=b&sig=usAN0kNFNnYE2tGQBI%2BARQWejX1Guiz7hdFtRhyK%2Bog%3D&se=2016-06-17T20:45:51Z&sp=rwl";
    Microsoft.WindowsAzure.Storage.Blob.CloudBlockBlob blockBob =
      new Microsoft.WindowsAzure.Storage.Blob.CloudBlockBlob(new System.Uri(sasUrl));
    await blockBob.UploadFromStreamAsync(stream);
    ```

5. <span data-ttu-id="d537e-155">次のメソッドを実行して、申請をコミットします。</span><span class="sxs-lookup"><span data-stu-id="d537e-155">Commit the submission by executing the following method.</span></span> <span data-ttu-id="d537e-156">これで、申請が完了し、更新がアカウントに適用されていることがデベロッパー センターに通知されます。</span><span class="sxs-lookup"><span data-stu-id="d537e-156">This will alert Dev Center that you are done with your submission and that your updates should now be applied to your account.</span></span> <span data-ttu-id="d537e-157">詳しくは、「[アドオンの申請のコミット](commit-an-add-on-submission.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d537e-157">For more information, see [Commit an add-on submission](commit-an-add-on-submission.md).</span></span>

    ```
    POST https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/{id}/submissions/{submissionId}/commit
    ```

6. <span data-ttu-id="d537e-158">次のメソッドを実行して、コミットの状態を確認します。</span><span class="sxs-lookup"><span data-stu-id="d537e-158">Check on the commit status by executing the following method.</span></span> <span data-ttu-id="d537e-159">詳しくは、「[アドオンの申請の状態の取得](get-status-for-an-add-on-submission.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d537e-159">For more information, see [Get the status of an add-on submission](get-status-for-an-add-on-submission.md).</span></span>

    ```
    GET https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/{id}/submissions/{submissionId}/status
    ```

    <span data-ttu-id="d537e-160">申請の状態を確認するには、応答本文の *status* の値を確認します。</span><span class="sxs-lookup"><span data-stu-id="d537e-160">To confirm the submission status, review the *status* value in the response body.</span></span> <span data-ttu-id="d537e-161">この値が **CommitStarted** から **PreProcessing** (要求が成功した場合) または **CommitFailed** (要求でエラーが発生した場合) に変わっています。</span><span class="sxs-lookup"><span data-stu-id="d537e-161">This value should change from **CommitStarted** to either **PreProcessing** if the request succeeds or to **CommitFailed** if there are errors in the request.</span></span> <span data-ttu-id="d537e-162">エラーがある場合は、*statusDetails* フィールドにエラーについての詳細情報が含まれています。</span><span class="sxs-lookup"><span data-stu-id="d537e-162">If there are errors, the *statusDetails* field contains further details about the error.</span></span>

7. <span data-ttu-id="d537e-163">コミットが正常に処理されると、インジェストのために申請がストアに送信されます。</span><span class="sxs-lookup"><span data-stu-id="d537e-163">After the commit has successfully completed, the submission is sent to the Store for ingestion.</span></span> <span data-ttu-id="d537e-164">上記のメソッドを使うか、デベロッパー センターのダッシュボードから、申請の進行状況を引き続き監視できます。</span><span class="sxs-lookup"><span data-stu-id="d537e-164">You can continue to monitor the submission progress by using the previous method, or by visiting the Dev Center dashboard.</span></span>

<span/>

## <a name="code-examples"></a><span data-ttu-id="d537e-165">コード例</span><span class="sxs-lookup"><span data-stu-id="d537e-165">Code examples</span></span>

<span data-ttu-id="d537e-166">次の記事では、さまざまなプログラミング言語でアドオンの申請を作成する方法を説明する詳しいコード例を紹介します。</span><span class="sxs-lookup"><span data-stu-id="d537e-166">The following articles provide detailed code examples that demonstrate how to create an add-on submission in several different programming languages:</span></span>

* [<span data-ttu-id="d537e-167">C# のコード例</span><span class="sxs-lookup"><span data-stu-id="d537e-167">C# code examples</span></span>](csharp-code-examples-for-the-windows-store-submission-api.md)
* [<span data-ttu-id="d537e-168">Java のコード例</span><span class="sxs-lookup"><span data-stu-id="d537e-168">Java code examples</span></span>](java-code-examples-for-the-windows-store-submission-api.md)
* [<span data-ttu-id="d537e-169">Python のコード例</span><span class="sxs-lookup"><span data-stu-id="d537e-169">Python code examples</span></span>](python-code-examples-for-the-windows-store-submission-api.md)

## <a name="storebroker-powershell-module"></a><span data-ttu-id="d537e-170">StoreBroker PowerShell モジュール</span><span class="sxs-lookup"><span data-stu-id="d537e-170">StoreBroker PowerShell module</span></span>

<span data-ttu-id="d537e-171">Microsoft Store 申請 API を直接呼び出す代わりに、API の上にコマンド ライン インターフェイスを実装するオープンソースの PowerShell モジュールも用意されています。</span><span class="sxs-lookup"><span data-stu-id="d537e-171">As an alternative to calling the Microsoft Store submission API directly, we also provide an open-source PowerShell module which implements a command-line interface on top of the API.</span></span> <span data-ttu-id="d537e-172">このモジュールは、[StoreBroker](https://aka.ms/storebroker) と呼ばれています。</span><span class="sxs-lookup"><span data-stu-id="d537e-172">This module is called [StoreBroker](https://aka.ms/storebroker).</span></span> <span data-ttu-id="d537e-173">このモジュールを使うと、Microsoft Store 申請 API を直接呼び出さずに、コマンド ラインからアプリ、フライト、アドオンの申請を管理できます。また、ソースを参照して、この API を呼び出す方法の例を確認することもできます。</span><span class="sxs-lookup"><span data-stu-id="d537e-173">You can use this module to manage your app, flight, and add-on submissions from the command line instead of calling the Microsoft Store submission API directly, or you can simply browse the source to see more examples for how to call this API.</span></span> <span data-ttu-id="d537e-174">StoreBroker モジュールは、多くのファースト パーティ アプリケーションをストアに申請する主要な方法として Microsoft 内で積極的に使っています。</span><span class="sxs-lookup"><span data-stu-id="d537e-174">The StoreBroker module is actively used within Microsoft as the primary way that many first-party applications are submitted to the Store.</span></span>

<span data-ttu-id="d537e-175">詳しくは、[GitHub の StoreBroker に関するページ](https://aka.ms/storebroker)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d537e-175">For more information, see our [StoreBroker page on GitHub](https://aka.ms/storebroker).</span></span>

<span/>

## <a name="data-resources"></a><span data-ttu-id="d537e-176">データ リソース</span><span class="sxs-lookup"><span data-stu-id="d537e-176">Data resources</span></span>

<span data-ttu-id="d537e-177">アドオンの申請を管理するための Microsoft Store 申請 API のメソッドでは、次の JSON データ リソースが使われます。</span><span class="sxs-lookup"><span data-stu-id="d537e-177">The Microsoft Store submission API methods for managing add-on submissions use the following JSON data resources.</span></span>

<span id="add-on-submission-object" />

### <a name="add-on-submission-resource"></a><span data-ttu-id="d537e-178">アドオンの申請のリソース</span><span class="sxs-lookup"><span data-stu-id="d537e-178">Add-on submission resource</span></span>

<span data-ttu-id="d537e-179">このリソースは、アドオンの申請を記述しています。</span><span class="sxs-lookup"><span data-stu-id="d537e-179">This resource describes an add-on submission.</span></span>

```json
{
  "id": "1152921504621243680",
  "contentType": "EMagazine",
  "keywords": [
    "books"
  ],
  "lifetime": "FiveDays",
  "listings": {
    "en": {
      "description": "English add-on description",
      "icon": {
        "fileName": "add-on-en-us-listing2.png",
        "fileStatus": "Uploaded"
      },
      "title": "Add-on Title (English)"
    },
    "ru": {
      "description": "Russian add-on description",
      "icon": {
        "fileName": "add-on-ru-listing.png",
        "fileStatus": "Uploaded"
      },
      "title": "Add-on Title (Russian)"
    }
  },
  "pricing": {
    "marketSpecificPricings": {
      "RU": "Tier3",
      "US": "Tier4",
    },
    "sales": [],
    "priceId": "Free",
    "isAdvancedPricingModel": true
  },
  "targetPublishDate": "2016-03-15T05:10:58.047Z",
  "targetPublishMode": "Immediate",
  "tag": "SampleTag",
  "visibility": "Public",
  "status": "PendingCommit",
  "statusDetails": {
    "errors": [
      {
        "code": "None",
        "details": "string"
      }
    ],
    "warnings": [
      {
        "code": "ListingOptOutWarning",
        "details": "You have removed listing language(s): []"
      }
    ],
    "certificationReports": [
      {
      }
    ]
  },
  "fileUploadUrl": "https://productingestionbin1.blob.core.windows.net/ingestion/26920f66-b592-4439-9a9d-fb0f014902ec?sv=2014-02-14&sr=b&sig=usAN0kNFNnYE2tGQBI%2BARQWejX1Guiz7hdFtRhyK%2Bog%3D&se=2016-06-17T20:45:51Z&sp=rwl",
  "friendlyName": "Submission 2"
}
```

<span data-ttu-id="d537e-180">このリソースには、次の値があります。</span><span class="sxs-lookup"><span data-stu-id="d537e-180">This resource has the following values.</span></span>

| <span data-ttu-id="d537e-181">値</span><span class="sxs-lookup"><span data-stu-id="d537e-181">Value</span></span>      | <span data-ttu-id="d537e-182">型</span><span class="sxs-lookup"><span data-stu-id="d537e-182">Type</span></span>   | <span data-ttu-id="d537e-183">説明</span><span class="sxs-lookup"><span data-stu-id="d537e-183">Description</span></span>        |
|------------|--------|----------------------|
| <span data-ttu-id="d537e-184">id</span><span class="sxs-lookup"><span data-stu-id="d537e-184">id</span></span>            | <span data-ttu-id="d537e-185">string</span><span class="sxs-lookup"><span data-stu-id="d537e-185">string</span></span>  | <span data-ttu-id="d537e-186">申請 ID。</span><span class="sxs-lookup"><span data-stu-id="d537e-186">The ID of the submission.</span></span> <span data-ttu-id="d537e-187">この ID は、[アドオンの申請の作成](create-an-add-on-submission.md)要求、[すべてのアドオンの取得](get-all-add-ons.md)要求、[アドオンの取得](get-an-add-on.md)要求に対する応答データで確認できます。</span><span class="sxs-lookup"><span data-stu-id="d537e-187">This ID is available in the response data for requests to [create an add-on submission](create-an-add-on-submission.md), [get all add-ons](get-all-add-ons.md), and [get an add-on](get-an-add-on.md).</span></span> <span data-ttu-id="d537e-188">デベロッパー センター ダッシュボードで作成された申請の場合、この ID はダッシュボードの申請ページの URL にも含まれています。</span><span class="sxs-lookup"><span data-stu-id="d537e-188">For a submission that was created in the Dev Center dashboard, this ID is also available in the URL for the submission page in the dashboard.</span></span>  |
| <span data-ttu-id="d537e-189">contentType</span><span class="sxs-lookup"><span data-stu-id="d537e-189">contentType</span></span>           | <span data-ttu-id="d537e-190">string</span><span class="sxs-lookup"><span data-stu-id="d537e-190">string</span></span>  |  <span data-ttu-id="d537e-191">アドオンで提供されている[コンテンツの種類](../publish/enter-add-on-properties.md#content-type)です。</span><span class="sxs-lookup"><span data-stu-id="d537e-191">The [type of content](../publish/enter-add-on-properties.md#content-type) that is provided in the add-on.</span></span> <span data-ttu-id="d537e-192">次のいずれかの値を使用できます。</span><span class="sxs-lookup"><span data-stu-id="d537e-192">This can be one of the following values:</span></span> <ul><li><span data-ttu-id="d537e-193">NotSet</span><span class="sxs-lookup"><span data-stu-id="d537e-193">NotSet</span></span></li><li><span data-ttu-id="d537e-194">BookDownload</span><span class="sxs-lookup"><span data-stu-id="d537e-194">BookDownload</span></span></li><li><span data-ttu-id="d537e-195">EMagazine</span><span class="sxs-lookup"><span data-stu-id="d537e-195">EMagazine</span></span></li><li><span data-ttu-id="d537e-196">ENewspaper</span><span class="sxs-lookup"><span data-stu-id="d537e-196">ENewspaper</span></span></li><li><span data-ttu-id="d537e-197">MusicDownload</span><span class="sxs-lookup"><span data-stu-id="d537e-197">MusicDownload</span></span></li><li><span data-ttu-id="d537e-198">MusicStream</span><span class="sxs-lookup"><span data-stu-id="d537e-198">MusicStream</span></span></li><li><span data-ttu-id="d537e-199">OnlineDataStorage</span><span class="sxs-lookup"><span data-stu-id="d537e-199">OnlineDataStorage</span></span></li><li><span data-ttu-id="d537e-200">VideoDownload</span><span class="sxs-lookup"><span data-stu-id="d537e-200">VideoDownload</span></span></li><li><span data-ttu-id="d537e-201">VideoStream</span><span class="sxs-lookup"><span data-stu-id="d537e-201">VideoStream</span></span></li><li><span data-ttu-id="d537e-202">Asp</span><span class="sxs-lookup"><span data-stu-id="d537e-202">Asp</span></span></li><li><span data-ttu-id="d537e-203">OnlineDownload</span><span class="sxs-lookup"><span data-stu-id="d537e-203">OnlineDownload</span></span></li></ul> |  
| <span data-ttu-id="d537e-204">keywords</span><span class="sxs-lookup"><span data-stu-id="d537e-204">keywords</span></span>           | <span data-ttu-id="d537e-205">array</span><span class="sxs-lookup"><span data-stu-id="d537e-205">array</span></span>  | <span data-ttu-id="d537e-206">アドオンの[キーワード](../publish/enter-add-on-properties.md#keywords)の文字列を最大 10 個含む配列です。</span><span class="sxs-lookup"><span data-stu-id="d537e-206">An array of strings that contain up to 10 [keywords](../publish/enter-add-on-properties.md#keywords) for the add-on.</span></span> <span data-ttu-id="d537e-207">アプリでは、これらのキーワードを使ってアドオンを照会できます。</span><span class="sxs-lookup"><span data-stu-id="d537e-207">Your app can query for add-ons using these keywords.</span></span>   |
| <span data-ttu-id="d537e-208">lifetime</span><span class="sxs-lookup"><span data-stu-id="d537e-208">lifetime</span></span>           | <span data-ttu-id="d537e-209">string</span><span class="sxs-lookup"><span data-stu-id="d537e-209">string</span></span>  |  <span data-ttu-id="d537e-210">アドオンの有効期間です。</span><span class="sxs-lookup"><span data-stu-id="d537e-210">The lifetime of the add-on.</span></span> <span data-ttu-id="d537e-211">次のいずれかの値を使用できます。</span><span class="sxs-lookup"><span data-stu-id="d537e-211">This can be one of the following values:</span></span> <ul><li><span data-ttu-id="d537e-212">Forever</span><span class="sxs-lookup"><span data-stu-id="d537e-212">Forever</span></span></li><li><span data-ttu-id="d537e-213">OneDay</span><span class="sxs-lookup"><span data-stu-id="d537e-213">OneDay</span></span></li><li><span data-ttu-id="d537e-214">ThreeDays</span><span class="sxs-lookup"><span data-stu-id="d537e-214">ThreeDays</span></span></li><li><span data-ttu-id="d537e-215">FiveDays</span><span class="sxs-lookup"><span data-stu-id="d537e-215">FiveDays</span></span></li><li><span data-ttu-id="d537e-216">OneWeek</span><span class="sxs-lookup"><span data-stu-id="d537e-216">OneWeek</span></span></li><li><span data-ttu-id="d537e-217">TwoWeeks</span><span class="sxs-lookup"><span data-stu-id="d537e-217">TwoWeeks</span></span></li><li><span data-ttu-id="d537e-218">OneMonth</span><span class="sxs-lookup"><span data-stu-id="d537e-218">OneMonth</span></span></li><li><span data-ttu-id="d537e-219">TwoMonths</span><span class="sxs-lookup"><span data-stu-id="d537e-219">TwoMonths</span></span></li><li><span data-ttu-id="d537e-220">ThreeMonths</span><span class="sxs-lookup"><span data-stu-id="d537e-220">ThreeMonths</span></span></li><li><span data-ttu-id="d537e-221">SixMonths</span><span class="sxs-lookup"><span data-stu-id="d537e-221">SixMonths</span></span></li><li><span data-ttu-id="d537e-222">OneYear</span><span class="sxs-lookup"><span data-stu-id="d537e-222">OneYear</span></span></li></ul> |
| <span data-ttu-id="d537e-223">listings</span><span class="sxs-lookup"><span data-stu-id="d537e-223">listings</span></span>           | <span data-ttu-id="d537e-224">object</span><span class="sxs-lookup"><span data-stu-id="d537e-224">object</span></span>  |  <span data-ttu-id="d537e-225">キーと値のペアのディクショナリです。各キーは 2 文字の ISO 3166-1 alpha-2 の国コードで、各値はアドオンの登録情報が保持される[登録情報リソース](#listing-object)です。</span><span class="sxs-lookup"><span data-stu-id="d537e-225">A dictionary of key and value pairs, where each key is a two-letter ISO 3166-1 alpha-2 country code and each value is a [listing resource](#listing-object) that contains listing info for the add-on.</span></span>  |
| <span data-ttu-id="d537e-226">pricing</span><span class="sxs-lookup"><span data-stu-id="d537e-226">pricing</span></span>           | <span data-ttu-id="d537e-227">object</span><span class="sxs-lookup"><span data-stu-id="d537e-227">object</span></span>  | <span data-ttu-id="d537e-228">アドオンの価格設定情報が保持される[価格リソース](#pricing-object)です。</span><span class="sxs-lookup"><span data-stu-id="d537e-228">A [pricing resource](#pricing-object) that contains pricing info for the add-on.</span></span>   |
| <span data-ttu-id="d537e-229">targetPublishMode</span><span class="sxs-lookup"><span data-stu-id="d537e-229">targetPublishMode</span></span>           | <span data-ttu-id="d537e-230">string</span><span class="sxs-lookup"><span data-stu-id="d537e-230">string</span></span>  | <span data-ttu-id="d537e-231">申請の公開モードです。</span><span class="sxs-lookup"><span data-stu-id="d537e-231">The publish mode for the submission.</span></span> <span data-ttu-id="d537e-232">次のいずれかの値を使用できます。</span><span class="sxs-lookup"><span data-stu-id="d537e-232">This can be one of the following values:</span></span> <ul><li><span data-ttu-id="d537e-233">Immediate</span><span class="sxs-lookup"><span data-stu-id="d537e-233">Immediate</span></span></li><li><span data-ttu-id="d537e-234">Manual</span><span class="sxs-lookup"><span data-stu-id="d537e-234">Manual</span></span></li><li><span data-ttu-id="d537e-235">SpecificDate</span><span class="sxs-lookup"><span data-stu-id="d537e-235">SpecificDate</span></span></li></ul> |
| <span data-ttu-id="d537e-236">targetPublishDate</span><span class="sxs-lookup"><span data-stu-id="d537e-236">targetPublishDate</span></span>           | <span data-ttu-id="d537e-237">string</span><span class="sxs-lookup"><span data-stu-id="d537e-237">string</span></span>  | <span data-ttu-id="d537e-238">*targetPublishMode* が SpecificDate に設定されている場合、ISO 8601 形式での申請の公開日です。</span><span class="sxs-lookup"><span data-stu-id="d537e-238">The publish date for the submission in ISO 8601 format, if the *targetPublishMode* is set to SpecificDate.</span></span>  |
| <span data-ttu-id="d537e-239">tag</span><span class="sxs-lookup"><span data-stu-id="d537e-239">tag</span></span>           | <span data-ttu-id="d537e-240">string</span><span class="sxs-lookup"><span data-stu-id="d537e-240">string</span></span>  |  <span data-ttu-id="d537e-241">アドオンの[カスタムの開発者データ](../publish/enter-add-on-properties.md#custom-developer-data)(この情報は従来*タグ*と呼ばれていました)。</span><span class="sxs-lookup"><span data-stu-id="d537e-241">The [custom developer data](../publish/enter-add-on-properties.md#custom-developer-data) for the add-on (this information was previously called the *tag*).</span></span>   |
| <span data-ttu-id="d537e-242">visibility</span><span class="sxs-lookup"><span data-stu-id="d537e-242">visibility</span></span>  | <span data-ttu-id="d537e-243">string</span><span class="sxs-lookup"><span data-stu-id="d537e-243">string</span></span>  |  <span data-ttu-id="d537e-244">アドオンの可視性です。</span><span class="sxs-lookup"><span data-stu-id="d537e-244">The visibility of the add-on.</span></span> <span data-ttu-id="d537e-245">次のいずれかの値を使用できます。</span><span class="sxs-lookup"><span data-stu-id="d537e-245">This can be one of the following values:</span></span> <ul><li><span data-ttu-id="d537e-246">Hidden</span><span class="sxs-lookup"><span data-stu-id="d537e-246">Hidden</span></span></li><li><span data-ttu-id="d537e-247">Public</span><span class="sxs-lookup"><span data-stu-id="d537e-247">Public</span></span></li><li><span data-ttu-id="d537e-248">Private</span><span class="sxs-lookup"><span data-stu-id="d537e-248">Private</span></span></li><li><span data-ttu-id="d537e-249">NotSet</span><span class="sxs-lookup"><span data-stu-id="d537e-249">NotSet</span></span></li></ul>  |
| <span data-ttu-id="d537e-250">status</span><span class="sxs-lookup"><span data-stu-id="d537e-250">status</span></span>  | <span data-ttu-id="d537e-251">string</span><span class="sxs-lookup"><span data-stu-id="d537e-251">string</span></span>  |  <span data-ttu-id="d537e-252">申請の状態。</span><span class="sxs-lookup"><span data-stu-id="d537e-252">The status of the submission.</span></span> <span data-ttu-id="d537e-253">次のいずれかの値を使用できます。</span><span class="sxs-lookup"><span data-stu-id="d537e-253">This can be one of the following values:</span></span> <ul><li><span data-ttu-id="d537e-254">None</span><span class="sxs-lookup"><span data-stu-id="d537e-254">None</span></span></li><li><span data-ttu-id="d537e-255">Canceled</span><span class="sxs-lookup"><span data-stu-id="d537e-255">Canceled</span></span></li><li><span data-ttu-id="d537e-256">PendingCommit</span><span class="sxs-lookup"><span data-stu-id="d537e-256">PendingCommit</span></span></li><li><span data-ttu-id="d537e-257">CommitStarted</span><span class="sxs-lookup"><span data-stu-id="d537e-257">CommitStarted</span></span></li><li><span data-ttu-id="d537e-258">CommitFailed</span><span class="sxs-lookup"><span data-stu-id="d537e-258">CommitFailed</span></span></li><li><span data-ttu-id="d537e-259">PendingPublication</span><span class="sxs-lookup"><span data-stu-id="d537e-259">PendingPublication</span></span></li><li><span data-ttu-id="d537e-260">Publishing</span><span class="sxs-lookup"><span data-stu-id="d537e-260">Publishing</span></span></li><li><span data-ttu-id="d537e-261">Published</span><span class="sxs-lookup"><span data-stu-id="d537e-261">Published</span></span></li><li><span data-ttu-id="d537e-262">PublishFailed</span><span class="sxs-lookup"><span data-stu-id="d537e-262">PublishFailed</span></span></li><li><span data-ttu-id="d537e-263">PreProcessing</span><span class="sxs-lookup"><span data-stu-id="d537e-263">PreProcessing</span></span></li><li><span data-ttu-id="d537e-264">PreProcessingFailed</span><span class="sxs-lookup"><span data-stu-id="d537e-264">PreProcessingFailed</span></span></li><li><span data-ttu-id="d537e-265">Certification</span><span class="sxs-lookup"><span data-stu-id="d537e-265">Certification</span></span></li><li><span data-ttu-id="d537e-266">CertificationFailed</span><span class="sxs-lookup"><span data-stu-id="d537e-266">CertificationFailed</span></span></li><li><span data-ttu-id="d537e-267">Release</span><span class="sxs-lookup"><span data-stu-id="d537e-267">Release</span></span></li><li><span data-ttu-id="d537e-268">ReleaseFailed</span><span class="sxs-lookup"><span data-stu-id="d537e-268">ReleaseFailed</span></span></li></ul>   |
| <span data-ttu-id="d537e-269">statusDetails</span><span class="sxs-lookup"><span data-stu-id="d537e-269">statusDetails</span></span>           | <span data-ttu-id="d537e-270">object</span><span class="sxs-lookup"><span data-stu-id="d537e-270">object</span></span>  |  <span data-ttu-id="d537e-271">エラーに関する情報など、申請のステータスに関する追加情報が保持される[ステータスの詳細に関するリソース](#status-details-object)です。</span><span class="sxs-lookup"><span data-stu-id="d537e-271">A [status details resource](#status-details-object) that contains additional details about the status of the submission, including information about any errors.</span></span> |
| <span data-ttu-id="d537e-272">fileUploadUrl</span><span class="sxs-lookup"><span data-stu-id="d537e-272">fileUploadUrl</span></span>           | <span data-ttu-id="d537e-273">string</span><span class="sxs-lookup"><span data-stu-id="d537e-273">string</span></span>  | <span data-ttu-id="d537e-274">申請のパッケージのアップロードに使用する共有アクセス署名 (SAS) URI です。</span><span class="sxs-lookup"><span data-stu-id="d537e-274">The shared access signature (SAS) URI for uploading any packages for the submission.</span></span> <span data-ttu-id="d537e-275">申請用に新しいパッケージを追加する場合は、パッケージを含む ZIP アーカイブをこの URI にアップロードします。</span><span class="sxs-lookup"><span data-stu-id="d537e-275">If you are adding new packages for the submission, upload the ZIP archive that contains the packages to this URI.</span></span> <span data-ttu-id="d537e-276">詳しくは、「[アドオンの申請の作成](#create-an-add-on-submission)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d537e-276">For more information, see [Create an add-on submission](#create-an-add-on-submission).</span></span>  |
| <span data-ttu-id="d537e-277">friendlyName</span><span class="sxs-lookup"><span data-stu-id="d537e-277">friendlyName</span></span>  | <span data-ttu-id="d537e-278">文字列</span><span class="sxs-lookup"><span data-stu-id="d537e-278">string</span></span>  |  <span data-ttu-id="d537e-279">デベロッパー センター ダッシュボードに表示される申請のフレンドリ名です。</span><span class="sxs-lookup"><span data-stu-id="d537e-279">The friendly name of the submission, as shown in the Dev Center dashboard.</span></span> <span data-ttu-id="d537e-280">この値は、申請を作成するときに生成されます。</span><span class="sxs-lookup"><span data-stu-id="d537e-280">This value is generated for you when you create the submission.</span></span>  |

<span id="listing-object" />

### <a name="listing-resource"></a><span data-ttu-id="d537e-281">登録情報リソース</span><span class="sxs-lookup"><span data-stu-id="d537e-281">Listing resource</span></span>

<span data-ttu-id="d537e-282">このリソースには[アドオンの登録情報](../publish/create-add-on-store-listings.md)が保持されます。</span><span class="sxs-lookup"><span data-stu-id="d537e-282">This resource contains [listing info for an add-on](../publish/create-add-on-store-listings.md).</span></span> <span data-ttu-id="d537e-283">このリソースには、次の値があります。</span><span class="sxs-lookup"><span data-stu-id="d537e-283">This resource has the following values.</span></span>

| <span data-ttu-id="d537e-284">値</span><span class="sxs-lookup"><span data-stu-id="d537e-284">Value</span></span>           | <span data-ttu-id="d537e-285">型</span><span class="sxs-lookup"><span data-stu-id="d537e-285">Type</span></span>    | <span data-ttu-id="d537e-286">説明</span><span class="sxs-lookup"><span data-stu-id="d537e-286">Description</span></span>       |
|-----------------|---------|------|
|  <span data-ttu-id="d537e-287">description</span><span class="sxs-lookup"><span data-stu-id="d537e-287">description</span></span>               |    <span data-ttu-id="d537e-288">string</span><span class="sxs-lookup"><span data-stu-id="d537e-288">string</span></span>     |   <span data-ttu-id="d537e-289">アドオンの登録情報についての説明です。</span><span class="sxs-lookup"><span data-stu-id="d537e-289">The description for the add-on listing.</span></span>   |     
|  <span data-ttu-id="d537e-290">icon</span><span class="sxs-lookup"><span data-stu-id="d537e-290">icon</span></span>               |   <span data-ttu-id="d537e-291">object</span><span class="sxs-lookup"><span data-stu-id="d537e-291">object</span></span>      |<span data-ttu-id="d537e-292">アドオンの登録情報に使用されるアイコンのデータが保持される[アイコン リソース](#icon-object)です。</span><span class="sxs-lookup"><span data-stu-id="d537e-292">An [icon resource](#icon-object) that contains data for the icon for the add-on listing.</span></span>    |
|  <span data-ttu-id="d537e-293">title</span><span class="sxs-lookup"><span data-stu-id="d537e-293">title</span></span>               |     <span data-ttu-id="d537e-294">string</span><span class="sxs-lookup"><span data-stu-id="d537e-294">string</span></span>    |   <span data-ttu-id="d537e-295">アドオンの登録情報のタイトルです。</span><span class="sxs-lookup"><span data-stu-id="d537e-295">The title for the add-on listing.</span></span>   |  

<span id="icon-object" />

### <a name="icon-resource"></a><span data-ttu-id="d537e-296">アイコン リソース</span><span class="sxs-lookup"><span data-stu-id="d537e-296">Icon resource</span></span>

<span data-ttu-id="d537e-297">このリソースにはアドオンの登録情報のアイコン データが保持されます。</span><span class="sxs-lookup"><span data-stu-id="d537e-297">This resource contains icon data for an add-on listing.</span></span> <span data-ttu-id="d537e-298">このリソースには、次の値があります。</span><span class="sxs-lookup"><span data-stu-id="d537e-298">This resource has the following values.</span></span>

| <span data-ttu-id="d537e-299">値</span><span class="sxs-lookup"><span data-stu-id="d537e-299">Value</span></span>           | <span data-ttu-id="d537e-300">型</span><span class="sxs-lookup"><span data-stu-id="d537e-300">Type</span></span>    | <span data-ttu-id="d537e-301">説明</span><span class="sxs-lookup"><span data-stu-id="d537e-301">Description</span></span>     |
|-----------------|---------|------|
|  <span data-ttu-id="d537e-302">fileName</span><span class="sxs-lookup"><span data-stu-id="d537e-302">fileName</span></span>               |    <span data-ttu-id="d537e-303">string</span><span class="sxs-lookup"><span data-stu-id="d537e-303">string</span></span>     |   <span data-ttu-id="d537e-304">申請用にアップロードした ZIP アーカイブに含まれているアイコン ファイルの名前です。</span><span class="sxs-lookup"><span data-stu-id="d537e-304">The name of the icon file in the ZIP archive that you uploaded for the submission.</span></span> <span data-ttu-id="d537e-305">このアイコンには、300 x 300 ピクセルの .png ファイルを使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d537e-305">The icon must be a .png file that measures exactly 300 x 300 pixels.</span></span>   |     
|  <span data-ttu-id="d537e-306">fileStatus</span><span class="sxs-lookup"><span data-stu-id="d537e-306">fileStatus</span></span>               |   <span data-ttu-id="d537e-307">string</span><span class="sxs-lookup"><span data-stu-id="d537e-307">string</span></span>      |  <span data-ttu-id="d537e-308">アイコン ファイルの状態です。</span><span class="sxs-lookup"><span data-stu-id="d537e-308">The status of the icon file.</span></span> <span data-ttu-id="d537e-309">次のいずれかの値を使用できます。</span><span class="sxs-lookup"><span data-stu-id="d537e-309">This can be one of the following values:</span></span> <ul><li><span data-ttu-id="d537e-310">None</span><span class="sxs-lookup"><span data-stu-id="d537e-310">None</span></span></li><li><span data-ttu-id="d537e-311">PendingUpload</span><span class="sxs-lookup"><span data-stu-id="d537e-311">PendingUpload</span></span></li><li><span data-ttu-id="d537e-312">Uploaded</span><span class="sxs-lookup"><span data-stu-id="d537e-312">Uploaded</span></span></li><li><span data-ttu-id="d537e-313">PendingDelete</span><span class="sxs-lookup"><span data-stu-id="d537e-313">PendingDelete</span></span></li></ul>   |

<span id="pricing-object" />

### <a name="pricing-resource"></a><span data-ttu-id="d537e-314">価格リソース</span><span class="sxs-lookup"><span data-stu-id="d537e-314">Pricing resource</span></span>

<span data-ttu-id="d537e-315">このリソースにはアドオンの価格設定情報が保持されます。</span><span class="sxs-lookup"><span data-stu-id="d537e-315">This resource contains pricing info for the add-on.</span></span> <span data-ttu-id="d537e-316">このリソースには、次の値があります。</span><span class="sxs-lookup"><span data-stu-id="d537e-316">This resource has the following values.</span></span>

| <span data-ttu-id="d537e-317">値</span><span class="sxs-lookup"><span data-stu-id="d537e-317">Value</span></span>           | <span data-ttu-id="d537e-318">型</span><span class="sxs-lookup"><span data-stu-id="d537e-318">Type</span></span>    | <span data-ttu-id="d537e-319">説明</span><span class="sxs-lookup"><span data-stu-id="d537e-319">Description</span></span>    |
|-----------------|---------|------|
|  <span data-ttu-id="d537e-320">marketSpecificPricings</span><span class="sxs-lookup"><span data-stu-id="d537e-320">marketSpecificPricings</span></span>               |    <span data-ttu-id="d537e-321">object</span><span class="sxs-lookup"><span data-stu-id="d537e-321">object</span></span>     |  <span data-ttu-id="d537e-322">キーと値のペアのディクショナリです。各キーは 2 文字の ISO 3166-1 alpha-2 の国コードで、各値は[価格帯](#price-tiers)です。</span><span class="sxs-lookup"><span data-stu-id="d537e-322">A dictionary of key and value pairs, where each key is a two-letter ISO 3166-1 alpha-2 country code and each value is a [price tier](#price-tiers).</span></span> <span data-ttu-id="d537e-323">これらの項目は、[特定の市場でのアドオンのカスタム価格](https://msdn.microsoft.com/windows/uwp/publish/set-iap-pricing-and-availability#markets-and-custom-prices)を表します。</span><span class="sxs-lookup"><span data-stu-id="d537e-323">These items represent the [custom prices for your add-on in specific markets](https://msdn.microsoft.com/windows/uwp/publish/set-iap-pricing-and-availability#markets-and-custom-prices).</span></span> <span data-ttu-id="d537e-324">このディクショナリに含まれる項目は、指定された市場の *priceId* の値によって指定されている基本価格を上書きします。</span><span class="sxs-lookup"><span data-stu-id="d537e-324">Any items in this dictionary override the base price specified by the *priceId* value for the specified market.</span></span>     |     
|  <span data-ttu-id="d537e-325">sales</span><span class="sxs-lookup"><span data-stu-id="d537e-325">sales</span></span>               |   <span data-ttu-id="d537e-326">array</span><span class="sxs-lookup"><span data-stu-id="d537e-326">array</span></span>      |  <span data-ttu-id="d537e-327">**推奨されなくなった値**です。</span><span class="sxs-lookup"><span data-stu-id="d537e-327">**Deprecated**.</span></span> <span data-ttu-id="d537e-328">アドオンの販売情報が保持される[セール リソース](#sale-object)の配列です。</span><span class="sxs-lookup"><span data-stu-id="d537e-328">An array of [sale resources](#sale-object) that contain sales information for the add-on.</span></span>     |     
|  <span data-ttu-id="d537e-329">priceId</span><span class="sxs-lookup"><span data-stu-id="d537e-329">priceId</span></span>               |   <span data-ttu-id="d537e-330">文字列</span><span class="sxs-lookup"><span data-stu-id="d537e-330">string</span></span>      |  <span data-ttu-id="d537e-331">アドオンの[基本価格](https://msdn.microsoft.com/windows/uwp/publish/set-iap-pricing-and-availability#base-price)を規定する[価格帯](#price-tiers)です。</span><span class="sxs-lookup"><span data-stu-id="d537e-331">A [price tier](#price-tiers) that specifies the [base price](https://msdn.microsoft.com/windows/uwp/publish/set-iap-pricing-and-availability#base-price) for the add-on.</span></span>    |    
|  <span data-ttu-id="d537e-332">isAdvancedPricingModel</span><span class="sxs-lookup"><span data-stu-id="d537e-332">isAdvancedPricingModel</span></span>               |   <span data-ttu-id="d537e-333">ブール値</span><span class="sxs-lookup"><span data-stu-id="d537e-333">boolean</span></span>      |  <span data-ttu-id="d537e-334">**true** の場合、開発者アカウントは 0.99 USD ～ 1999.99 USD の拡張された価格セットにアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="d537e-334">If **true**, your developer account has access to the expanded set of price tiers from .99 USD to 1999.99 USD.</span></span> <span data-ttu-id="d537e-335">**false** の場合、開発者アカウントは 0.99 USD ～ 999.99 USD の元の価格帯セットにアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="d537e-335">If **false**, your developer account has access to the original set of price tiers from .99 USD to 999.99 USD.</span></span> <span data-ttu-id="d537e-336">各種価格帯について詳しくは、「[価格帯](#price-tiers)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d537e-336">For more information about the different tiers, see [price tiers](#price-tiers).</span></span><br/><br/><span data-ttu-id="d537e-337">**注**&nbsp;&nbsp;このフィールドは読み取り専用です。</span><span class="sxs-lookup"><span data-stu-id="d537e-337">**Note**&nbsp;&nbsp;This field is read-only.</span></span>   |


<span id="sale-object" />

### <a name="sale-resource"></a><span data-ttu-id="d537e-338">セール リソース</span><span class="sxs-lookup"><span data-stu-id="d537e-338">Sale resource</span></span>

<span data-ttu-id="d537e-339">このリソースにはアドオンのセール情報が保持されます。</span><span class="sxs-lookup"><span data-stu-id="d537e-339">This resources contains sale info for an add-on.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="d537e-340">**セール** リソースはサポートを終了しました。現在、Microsoft Store 申請 API を使ってアドオンの申請の販売データを取得または変更することはできません。</span><span class="sxs-lookup"><span data-stu-id="d537e-340">The **Sale** resource is no longer supported, and currently you cannot get or modify the sale data for an add-on submission using the Microsoft Store submission API.</span></span> <span data-ttu-id="d537e-341">将来的には、Microsoft Store 申請 API を更新して、アドオンの申請のセール情報にプログラムでアクセスする新しい方法を導入する予定です。</span><span class="sxs-lookup"><span data-stu-id="d537e-341">In the future, we will update the Microsoft Store submission API to introduce a new way to programmatically access sales information for add-on submissions.</span></span>
>    * <span data-ttu-id="d537e-342">[アドオンの申請を取得する GET メソッド](get-an-add-on-submission.md)を呼び出すと、*セール* リソースは空になります。</span><span class="sxs-lookup"><span data-stu-id="d537e-342">After calling the [GET method to get an add-on submission](get-an-add-on-submission.md), the *sales* value will be empty.</span></span> <span data-ttu-id="d537e-343">引き続きデベロッパー センター ダッシュボードを使って、アドオンの申請のセール データを取得することができます。</span><span class="sxs-lookup"><span data-stu-id="d537e-343">You can continue to use the Dev Center dashboard to get the sale data for your add-on submission.</span></span>
>    * <span data-ttu-id="d537e-344">[アドオンの申請を更新する PUT メソッド](update-an-add-on-submission.md)を呼び出すとき、*セール*の値に含まれた情報は無視されます。</span><span class="sxs-lookup"><span data-stu-id="d537e-344">When calling the [PUT method to update an add-on submission](update-an-add-on-submission.md), the information in the *sales* value is ignored.</span></span> <span data-ttu-id="d537e-345">引き続きデベロッパー センター ダッシュボードを使って、アドオンの申請のセール データを変更することができます。</span><span class="sxs-lookup"><span data-stu-id="d537e-345">You can continue to use the Dev Center dashboard to change the sale data for your add-on submission.</span></span>

<span data-ttu-id="d537e-346">このリソースには、次の値があります。</span><span class="sxs-lookup"><span data-stu-id="d537e-346">This resource has the following values.</span></span>

| <span data-ttu-id="d537e-347">値</span><span class="sxs-lookup"><span data-stu-id="d537e-347">Value</span></span>           | <span data-ttu-id="d537e-348">型</span><span class="sxs-lookup"><span data-stu-id="d537e-348">Type</span></span>    | <span data-ttu-id="d537e-349">説明</span><span class="sxs-lookup"><span data-stu-id="d537e-349">Description</span></span>           |
|-----------------|---------|------|
|  <span data-ttu-id="d537e-350">name</span><span class="sxs-lookup"><span data-stu-id="d537e-350">name</span></span>               |    <span data-ttu-id="d537e-351">string</span><span class="sxs-lookup"><span data-stu-id="d537e-351">string</span></span>     |   <span data-ttu-id="d537e-352">セールの名前です。</span><span class="sxs-lookup"><span data-stu-id="d537e-352">The name of the sale.</span></span>    |     
|  <span data-ttu-id="d537e-353">basePriceId</span><span class="sxs-lookup"><span data-stu-id="d537e-353">basePriceId</span></span>               |   <span data-ttu-id="d537e-354">string</span><span class="sxs-lookup"><span data-stu-id="d537e-354">string</span></span>      |  <span data-ttu-id="d537e-355">セールの基本価格として使用する[価格帯](#price-tiers)です。</span><span class="sxs-lookup"><span data-stu-id="d537e-355">The [price tier](#price-tiers) to use for the base price of the sale.</span></span>    |     
|  <span data-ttu-id="d537e-356">startDate</span><span class="sxs-lookup"><span data-stu-id="d537e-356">startDate</span></span>               |   <span data-ttu-id="d537e-357">string</span><span class="sxs-lookup"><span data-stu-id="d537e-357">string</span></span>      |   <span data-ttu-id="d537e-358">ISO 8601 形式で表したセールの開始日です。</span><span class="sxs-lookup"><span data-stu-id="d537e-358">The start date for the sale in ISO 8601 format.</span></span>  |     
|  <span data-ttu-id="d537e-359">endDate</span><span class="sxs-lookup"><span data-stu-id="d537e-359">endDate</span></span>               |   <span data-ttu-id="d537e-360">string</span><span class="sxs-lookup"><span data-stu-id="d537e-360">string</span></span>      |  <span data-ttu-id="d537e-361">ISO 8601 形式で表したセールの終了日です。</span><span class="sxs-lookup"><span data-stu-id="d537e-361">The end date for the sale in ISO 8601 format.</span></span>      |     
|  <span data-ttu-id="d537e-362">marketSpecificPricings</span><span class="sxs-lookup"><span data-stu-id="d537e-362">marketSpecificPricings</span></span>               |   <span data-ttu-id="d537e-363">object</span><span class="sxs-lookup"><span data-stu-id="d537e-363">object</span></span>      |   <span data-ttu-id="d537e-364">キーと値のペアのディクショナリです。各キーは 2 文字の ISO 3166-1 alpha-2 の国コードで、各値は[価格帯](#price-tiers)です。</span><span class="sxs-lookup"><span data-stu-id="d537e-364">A dictionary of key and value pairs, where each key is a two-letter ISO 3166-1 alpha-2 country code and each value is a [price tier](#price-tiers).</span></span> <span data-ttu-id="d537e-365">これらの項目は、[特定の市場でのアドオンのカスタム価格](https://msdn.microsoft.com/windows/uwp/publish/set-iap-pricing-and-availability#markets-and-custom-pricess)を表します。</span><span class="sxs-lookup"><span data-stu-id="d537e-365">These items represent the [custom prices for your add-on in specific markets](https://msdn.microsoft.com/windows/uwp/publish/set-iap-pricing-and-availability#markets-and-custom-pricess).</span></span> <span data-ttu-id="d537e-366">このディクショナリに含まれる項目は、指定された市場の *basePriceId* の値によって指定されている基本価格を上書きします。</span><span class="sxs-lookup"><span data-stu-id="d537e-366">Any items in this dictionary override the base price specified by the *basePriceId* value for the specified market.</span></span>    |

<span id="status-details-object" />

### <a name="status-details-resource"></a><span data-ttu-id="d537e-367">ステータスの詳細に関するリソース</span><span class="sxs-lookup"><span data-stu-id="d537e-367">Status details resource</span></span>

<span data-ttu-id="d537e-368">このリソースには、申請の状態についての追加情報が保持されます。</span><span class="sxs-lookup"><span data-stu-id="d537e-368">This resource contains additional details about the status of a submission.</span></span> <span data-ttu-id="d537e-369">このリソースには、次の値があります。</span><span class="sxs-lookup"><span data-stu-id="d537e-369">This resource has the following values.</span></span>

| <span data-ttu-id="d537e-370">値</span><span class="sxs-lookup"><span data-stu-id="d537e-370">Value</span></span>           | <span data-ttu-id="d537e-371">型</span><span class="sxs-lookup"><span data-stu-id="d537e-371">Type</span></span>    | <span data-ttu-id="d537e-372">説明</span><span class="sxs-lookup"><span data-stu-id="d537e-372">Description</span></span>       |
|-----------------|---------|------|
|  <span data-ttu-id="d537e-373">errors</span><span class="sxs-lookup"><span data-stu-id="d537e-373">errors</span></span>               |    <span data-ttu-id="d537e-374">object</span><span class="sxs-lookup"><span data-stu-id="d537e-374">object</span></span>     |   <span data-ttu-id="d537e-375">申請のエラーの詳細が保持される[ステータスの詳細リソース](#status-detail-object)の配列です。</span><span class="sxs-lookup"><span data-stu-id="d537e-375">An array of [status detail resources](#status-detail-object) that contain error details for the submission.</span></span>   |     
|  <span data-ttu-id="d537e-376">warnings</span><span class="sxs-lookup"><span data-stu-id="d537e-376">warnings</span></span>               |   <span data-ttu-id="d537e-377">object</span><span class="sxs-lookup"><span data-stu-id="d537e-377">object</span></span>      | <span data-ttu-id="d537e-378">申請の警告の詳細が保持される[ステータスの詳細リソース](#status-detail-object)の配列です。</span><span class="sxs-lookup"><span data-stu-id="d537e-378">An array of [status detail resources](#status-detail-object) that contain warning details for the submission.</span></span>     |
|  <span data-ttu-id="d537e-379">certificationReports</span><span class="sxs-lookup"><span data-stu-id="d537e-379">certificationReports</span></span>               |     <span data-ttu-id="d537e-380">object</span><span class="sxs-lookup"><span data-stu-id="d537e-380">object</span></span>    |   <span data-ttu-id="d537e-381">申請の認定レポート データへのアクセスを提供する[認定レポート リソース](#certification-report-object)です。</span><span class="sxs-lookup"><span data-stu-id="d537e-381">An array of [certification report resources](#certification-report-object) that provide access to the certification report data for the submission.</span></span> <span data-ttu-id="d537e-382">認定されなかった場合に、これらのレポートから詳しい情報を知ることができます。</span><span class="sxs-lookup"><span data-stu-id="d537e-382">You can examine these reports for more information if the certification fails.</span></span>    |  

<span id="status-detail-object" />

### <a name="status-detail-resource"></a><span data-ttu-id="d537e-383">ステータスの詳細に関するリソース</span><span class="sxs-lookup"><span data-stu-id="d537e-383">Status detail resource</span></span>

<span data-ttu-id="d537e-384">このリソースには、申請に関連するエラーや警告についての追加情報が保持されます。</span><span class="sxs-lookup"><span data-stu-id="d537e-384">This resource contains additional information about any related errors or warnings for a submission.</span></span> <span data-ttu-id="d537e-385">このリソースには、次の値があります。</span><span class="sxs-lookup"><span data-stu-id="d537e-385">This resource has the following values.</span></span>

| <span data-ttu-id="d537e-386">値</span><span class="sxs-lookup"><span data-stu-id="d537e-386">Value</span></span>           | <span data-ttu-id="d537e-387">型</span><span class="sxs-lookup"><span data-stu-id="d537e-387">Type</span></span>    | <span data-ttu-id="d537e-388">説明</span><span class="sxs-lookup"><span data-stu-id="d537e-388">Description</span></span>    |
|-----------------|---------|------|
|  <span data-ttu-id="d537e-389">code</span><span class="sxs-lookup"><span data-stu-id="d537e-389">code</span></span>               |    <span data-ttu-id="d537e-390">string</span><span class="sxs-lookup"><span data-stu-id="d537e-390">string</span></span>     |   <span data-ttu-id="d537e-391">エラーや警告の種類を説明する[申請ステータス コード](#submission-status-code)です。</span><span class="sxs-lookup"><span data-stu-id="d537e-391">A [submission status code](#submission-status-code) that describes the type of error or warning.</span></span>   |     
|  <span data-ttu-id="d537e-392">details</span><span class="sxs-lookup"><span data-stu-id="d537e-392">details</span></span>               |     <span data-ttu-id="d537e-393">string</span><span class="sxs-lookup"><span data-stu-id="d537e-393">string</span></span>    |  <span data-ttu-id="d537e-394">問題についての詳細が含まれるメッセージです。</span><span class="sxs-lookup"><span data-stu-id="d537e-394">A message with more details about the issue.</span></span>     |

<span id="certification-report-object" />

### <a name="certification-report-resource"></a><span data-ttu-id="d537e-395">認定レポート リソース</span><span class="sxs-lookup"><span data-stu-id="d537e-395">Certification report resource</span></span>

<span data-ttu-id="d537e-396">このリソースは、申請の認定レポート データへのアクセスを提供します。</span><span class="sxs-lookup"><span data-stu-id="d537e-396">This resource provides access to the certification report data for a submission.</span></span> <span data-ttu-id="d537e-397">このリソースには、次の値があります。</span><span class="sxs-lookup"><span data-stu-id="d537e-397">This resource has the following values.</span></span>

| <span data-ttu-id="d537e-398">値</span><span class="sxs-lookup"><span data-stu-id="d537e-398">Value</span></span>           | <span data-ttu-id="d537e-399">型</span><span class="sxs-lookup"><span data-stu-id="d537e-399">Type</span></span>    | <span data-ttu-id="d537e-400">説明</span><span class="sxs-lookup"><span data-stu-id="d537e-400">Description</span></span>               |
|-----------------|---------|------|
|     <span data-ttu-id="d537e-401">date</span><span class="sxs-lookup"><span data-stu-id="d537e-401">date</span></span>            |    <span data-ttu-id="d537e-402">string</span><span class="sxs-lookup"><span data-stu-id="d537e-402">string</span></span>     |  <span data-ttu-id="d537e-403">ISO 8601 形式で表された、レポートが生成された日付と時刻です。</span><span class="sxs-lookup"><span data-stu-id="d537e-403">The date and time the report was generated, in in ISO 8601 format.</span></span>    |
|     <span data-ttu-id="d537e-404">reportUrl</span><span class="sxs-lookup"><span data-stu-id="d537e-404">reportUrl</span></span>            |    <span data-ttu-id="d537e-405">string</span><span class="sxs-lookup"><span data-stu-id="d537e-405">string</span></span>     |  <span data-ttu-id="d537e-406">レポートにアクセスできる URL です。</span><span class="sxs-lookup"><span data-stu-id="d537e-406">The URL at which you can access the report.</span></span>    |

## <a name="enums"></a><span data-ttu-id="d537e-407">列挙型</span><span class="sxs-lookup"><span data-stu-id="d537e-407">Enums</span></span>

<span data-ttu-id="d537e-408">これらのメソッドでは、次の列挙型が使用されます。</span><span class="sxs-lookup"><span data-stu-id="d537e-408">These methods use the following enums.</span></span>

<span id="price-tiers" />

### <a name="price-tiers"></a><span data-ttu-id="d537e-409">価格帯</span><span class="sxs-lookup"><span data-stu-id="d537e-409">Price tiers</span></span>

<span data-ttu-id="d537e-410">次の値は、[価格リソース](#pricing-object)における、アドオンの申請に利用できる価格帯を表します。</span><span class="sxs-lookup"><span data-stu-id="d537e-410">The following values represent available price tiers in the [pricing resource](#pricing-object) resource for an add-on submission.</span></span>

| <span data-ttu-id="d537e-411">値</span><span class="sxs-lookup"><span data-stu-id="d537e-411">Value</span></span>           | <span data-ttu-id="d537e-412">説明</span><span class="sxs-lookup"><span data-stu-id="d537e-412">Description</span></span>       |
|-----------------|------|
|  <span data-ttu-id="d537e-413">Base</span><span class="sxs-lookup"><span data-stu-id="d537e-413">Base</span></span>               |   <span data-ttu-id="d537e-414">価格帯が設定されていない場合、アドオンの基本価格が使用されます。</span><span class="sxs-lookup"><span data-stu-id="d537e-414">The price tier is not set; use the base price for the add-on.</span></span>      |     
|  <span data-ttu-id="d537e-415">NotAvailable</span><span class="sxs-lookup"><span data-stu-id="d537e-415">NotAvailable</span></span>              |   <span data-ttu-id="d537e-416">アドオンは指定された地域で提供されていません。</span><span class="sxs-lookup"><span data-stu-id="d537e-416">The add-on is not available in the specified region.</span></span>    |     
|  <span data-ttu-id="d537e-417">Free</span><span class="sxs-lookup"><span data-stu-id="d537e-417">Free</span></span>              |   <span data-ttu-id="d537e-418">アドオンは無償です。</span><span class="sxs-lookup"><span data-stu-id="d537e-418">The add-on is free.</span></span>    |    
|  <span data-ttu-id="d537e-419">Tier*xxxx*</span><span class="sxs-lookup"><span data-stu-id="d537e-419">Tier*xxxx*</span></span>               |   <span data-ttu-id="d537e-420">アドオンの価格帯を指定する文字列 (**Tier<em>xxxx</em>** の形式)。</span><span class="sxs-lookup"><span data-stu-id="d537e-420">A string that specifies the price tier for the add-on, in the format **Tier<em>xxxx</em>**.</span></span> <span data-ttu-id="d537e-421">現在のところ、次の範囲の価格帯がサポートされています。</span><span class="sxs-lookup"><span data-stu-id="d537e-421">Currently, the following ranges of price tiers are supported:</span></span><br/><br/><ul><li><span data-ttu-id="d537e-422">[価格リソース](#pricing-object)の *isAdvancedPricingModel* 値が **true** の場合、アカウントで利用可能な価格帯値は **Tier1012** - **Tier1424** です。</span><span class="sxs-lookup"><span data-stu-id="d537e-422">If the *isAdvancedPricingModel* value of the [pricing resource](#pricing-object) is **true**, the available price tier values for your account are **Tier1012** - **Tier1424**.</span></span></li><li><span data-ttu-id="d537e-423">[価格リソース](#pricing-object)の *isAdvancedPricingModel* 値が **false** の場合、アカウントで利用可能な価格帯値は **Tier2** - **Tier96** です。</span><span class="sxs-lookup"><span data-stu-id="d537e-423">If the *isAdvancedPricingModel* value of the [pricing resource](#pricing-object) is **false**, the available price tier values for your account are **Tier2** - **Tier96**.</span></span></li></ul><span data-ttu-id="d537e-424">各価格帯に関連付けられた市場固有の価格を含む、開発者アカウントで利用可能な価格帯の詳しい表を参照するには、デベロッパー センター ダッシュボードでいずれかのアプリ申請の **[価格と使用可能状況]** ページにアクセスし、**[市場と特別価格]** セクションで **[view table]** (表を表示) リンクをクリックします (一部の開発者アカウントでは、このリンクは **[Pricing]** (価格) セクションにあります)。</span><span class="sxs-lookup"><span data-stu-id="d537e-424">To see the complete table of price tiers that are available for your developer account, including the market-specific prices that are associated with each tier, go to the **Pricing and availability** page for any of your app submissions in the Dev Center dashboard and click the **view table** link in the **Markets and custom prices** section (for some developer accounts, this link is in the **Pricing** section).</span></span>     |

<span id="submission-status-code" />

### <a name="submission-status-code"></a><span data-ttu-id="d537e-425">申請の状態コード</span><span class="sxs-lookup"><span data-stu-id="d537e-425">Submission status code</span></span>

<span data-ttu-id="d537e-426">次の値は、申請の状態コードを表します。</span><span class="sxs-lookup"><span data-stu-id="d537e-426">The following values represent the status code of a submission.</span></span>

| <span data-ttu-id="d537e-427">値</span><span class="sxs-lookup"><span data-stu-id="d537e-427">Value</span></span>           |  <span data-ttu-id="d537e-428">説明</span><span class="sxs-lookup"><span data-stu-id="d537e-428">Description</span></span>      |
|-----------------|---------------|
|  <span data-ttu-id="d537e-429">None</span><span class="sxs-lookup"><span data-stu-id="d537e-429">None</span></span>            |     <span data-ttu-id="d537e-430">コードが指定されていません。</span><span class="sxs-lookup"><span data-stu-id="d537e-430">No code was specified.</span></span>         |     
|      <span data-ttu-id="d537e-431">InvalidArchive</span><span class="sxs-lookup"><span data-stu-id="d537e-431">InvalidArchive</span></span>        |     <span data-ttu-id="d537e-432">パッケージが含まれる ZIP アーカイブは無効であるか、認識できないアーカイブ形式です。</span><span class="sxs-lookup"><span data-stu-id="d537e-432">The ZIP archive containing the package is invalid or has an unrecognized archive format.</span></span>  |
| <span data-ttu-id="d537e-433">MissingFiles</span><span class="sxs-lookup"><span data-stu-id="d537e-433">MissingFiles</span></span> | <span data-ttu-id="d537e-434">ZIP アーカイブに、申請データで指定されているすべてのファイルが含まれていないか、ファイルのアーカイブ内の場所が正しくありません。</span><span class="sxs-lookup"><span data-stu-id="d537e-434">The ZIP archive does not have all files which were listed in your submission data, or they are in the wrong location in the archive.</span></span> |
| <span data-ttu-id="d537e-435">PackageValidationFailed</span><span class="sxs-lookup"><span data-stu-id="d537e-435">PackageValidationFailed</span></span> | <span data-ttu-id="d537e-436">申請の 1 つ以上のパッケージを検証できませんでした。</span><span class="sxs-lookup"><span data-stu-id="d537e-436">One or more packages in your submission failed to validate.</span></span> |
| <span data-ttu-id="d537e-437">InvalidParameterValue</span><span class="sxs-lookup"><span data-stu-id="d537e-437">InvalidParameterValue</span></span> | <span data-ttu-id="d537e-438">要求本文に含まれるパラメーターの 1 つが無効です。</span><span class="sxs-lookup"><span data-stu-id="d537e-438">One of the parameters in the request body is invalid.</span></span> |
| <span data-ttu-id="d537e-439">InvalidOperation</span><span class="sxs-lookup"><span data-stu-id="d537e-439">InvalidOperation</span></span> | <span data-ttu-id="d537e-440">実行された操作は無効です。</span><span class="sxs-lookup"><span data-stu-id="d537e-440">The operation you attempted is invalid.</span></span> |
| <span data-ttu-id="d537e-441">InvalidState</span><span class="sxs-lookup"><span data-stu-id="d537e-441">InvalidState</span></span> | <span data-ttu-id="d537e-442">実行された操作は、パッケージ フライトの現在の状態では無効です。</span><span class="sxs-lookup"><span data-stu-id="d537e-442">The operation you attempted is not valid for the current state of the package flight.</span></span> |
| <span data-ttu-id="d537e-443">ResourceNotFound</span><span class="sxs-lookup"><span data-stu-id="d537e-443">ResourceNotFound</span></span> | <span data-ttu-id="d537e-444">指定されたパッケージ フライトは見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="d537e-444">The specified package flight could not be found.</span></span> |
| <span data-ttu-id="d537e-445">ServiceError</span><span class="sxs-lookup"><span data-stu-id="d537e-445">ServiceError</span></span> | <span data-ttu-id="d537e-446">内部サービス エラーのため、要求を処理できませんでした。</span><span class="sxs-lookup"><span data-stu-id="d537e-446">An internal service error prevented the request from succeeding.</span></span> <span data-ttu-id="d537e-447">もう一度要求を行ってください。</span><span class="sxs-lookup"><span data-stu-id="d537e-447">Try the request again.</span></span> |
| <span data-ttu-id="d537e-448">ListingOptOutWarning</span><span class="sxs-lookup"><span data-stu-id="d537e-448">ListingOptOutWarning</span></span> | <span data-ttu-id="d537e-449">開発者が以前の申請の登録情報を削除しているか、パッケージによってサポートされる登録情報を含めていませんでした。</span><span class="sxs-lookup"><span data-stu-id="d537e-449">The developer removed a listing from a previous submission, or did not include listing information that is supported by the package.</span></span> |
| <span data-ttu-id="d537e-450">ListingOptInWarning</span><span class="sxs-lookup"><span data-stu-id="d537e-450">ListingOptInWarning</span></span>  | <span data-ttu-id="d537e-451">開発者が登録情報を追加しました。</span><span class="sxs-lookup"><span data-stu-id="d537e-451">The developer added a listing.</span></span> |
| <span data-ttu-id="d537e-452">UpdateOnlyWarning</span><span class="sxs-lookup"><span data-stu-id="d537e-452">UpdateOnlyWarning</span></span> | <span data-ttu-id="d537e-453">開発者が、更新サポートしかないものを挿入しようとしています。</span><span class="sxs-lookup"><span data-stu-id="d537e-453">The developer is trying to insert something that only has update support.</span></span> |
| <span data-ttu-id="d537e-454">Other</span><span class="sxs-lookup"><span data-stu-id="d537e-454">Other</span></span>  | <span data-ttu-id="d537e-455">申請が非認識または未分類の状態です。</span><span class="sxs-lookup"><span data-stu-id="d537e-455">The submission is in an unrecognized or uncategorized state.</span></span> |
| <span data-ttu-id="d537e-456">PackageValidationWarning</span><span class="sxs-lookup"><span data-stu-id="d537e-456">PackageValidationWarning</span></span> | <span data-ttu-id="d537e-457">パッケージ検証プロセスの結果、警告が生成されました。</span><span class="sxs-lookup"><span data-stu-id="d537e-457">The package validation process resulted in a warning.</span></span> |

<span/>

## <a name="related-topics"></a><span data-ttu-id="d537e-458">関連トピック</span><span class="sxs-lookup"><span data-stu-id="d537e-458">Related topics</span></span>

* [<span data-ttu-id="d537e-459">Microsoft Store サービスを使用した申請の作成と管理</span><span class="sxs-lookup"><span data-stu-id="d537e-459">Create and manage submissions using Microsoft Store services</span></span>](create-and-manage-submissions-using-windows-store-services.md)
* [<span data-ttu-id="d537e-460">Microsoft Store 申請 API を使用したアドオンの管理</span><span class="sxs-lookup"><span data-stu-id="d537e-460">Manage add-ons using the Microsoft Store submission API</span></span>](manage-add-ons.md)
* [<span data-ttu-id="d537e-461">デベロッパー センター ダッシュボードからのアドオンの申請</span><span class="sxs-lookup"><span data-stu-id="d537e-461">Add-on submissions in the Dev Center dashboard</span></span>](https://msdn.microsoft.com/windows/uwp/publish/iap-submissions)
