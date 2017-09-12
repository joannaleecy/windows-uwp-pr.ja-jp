---
author: mcleanbyron
ms.assetid: E8751EBF-AE0F-4107-80A1-23C186453B1C
description: "既存のアプリの申請を更新するには、Windows ストア申請 API に含まれる以下のメソッドを使用します。"
title: "アプリの申請の更新"
ms.author: mcleans
ms.date: 07/10/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, Windows ストア申請 API, アプリの申請, 更新"
ms.openlocfilehash: b3c071c0d4f070c1a0ac95d6f35c73fcbb4e0455
ms.sourcegitcommit: a7a1b41c7dce6d56250ce3113137391d65d9e401
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/11/2017
---
# <a name="update-an-app-submission"></a><span data-ttu-id="9e43d-104">アプリの申請の更新</span><span class="sxs-lookup"><span data-stu-id="9e43d-104">Update an app submission</span></span>

<span data-ttu-id="9e43d-105">既存のアプリの申請を更新するには、Windows ストア申請 API に含まれる以下のメソッドを使用します。</span><span class="sxs-lookup"><span data-stu-id="9e43d-105">Use this method in the Windows Store submission API to update an existing app submission.</span></span> <span data-ttu-id="9e43d-106">このメソッドを使って申請を正常に更新した後は、インジェストと公開のために[申請をコミット](commit-an-app-submission.md)する必要があります。</span><span class="sxs-lookup"><span data-stu-id="9e43d-106">After you successfully update a submission by using this method, you must [commit the submission](commit-an-app-submission.md) for ingestion and publishing.</span></span>

<span data-ttu-id="9e43d-107">このメソッドが Windows ストア申請 API を使ったアプリの申請の作成プロセスにどのように適合するかについては、「[アプリの申請の管理](manage-app-submissions.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9e43d-107">For more information about how this method fits into the process of creating an app submission by using the Windows Store submission API, see [Manage app submissions](manage-app-submissions.md).</span></span>

## <a name="prerequisites"></a><span data-ttu-id="9e43d-108">前提条件</span><span class="sxs-lookup"><span data-stu-id="9e43d-108">Prerequisites</span></span>

<span data-ttu-id="9e43d-109">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="9e43d-109">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="9e43d-110">Windows ストア申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="9e43d-110">If you have not done so already, complete all the [prerequisites](create-and-manage-submissions-using-windows-store-services.md#prerequisites) for the Windows Store submission API.</span></span>
* <span data-ttu-id="9e43d-111">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="9e43d-111">[Obtain an Azure AD access token](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="9e43d-112">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="9e43d-112">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="9e43d-113">トークンの有効期限が切れたら、新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="9e43d-113">After the token expires, you can obtain a new one.</span></span>
* <span data-ttu-id="9e43d-114">デベロッパー センターのアカウントでアプリの申請を作成します。</span><span class="sxs-lookup"><span data-stu-id="9e43d-114">Create a submission for an app in your Dev Center account.</span></span> <span data-ttu-id="9e43d-115">この操作は、デベロッパー センター ダッシュボードまたは[アプリ申請の作成](create-an-app-submission.md)メソッドを使って実行できます。</span><span class="sxs-lookup"><span data-stu-id="9e43d-115">You can do this in the Dev Center dashboard, or you can do this by using the [create an app submission](create-an-app-submission.md) method.</span></span>

## <a name="request"></a><span data-ttu-id="9e43d-116">要求</span><span class="sxs-lookup"><span data-stu-id="9e43d-116">Request</span></span>

<span data-ttu-id="9e43d-117">このメソッドの構文は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="9e43d-117">This method has the following syntax.</span></span> <span data-ttu-id="9e43d-118">ヘッダーと要求本文の使用例と説明については、次のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9e43d-118">See the following sections for usage examples and descriptions of the header and request body.</span></span>

| <span data-ttu-id="9e43d-119">メソッド</span><span class="sxs-lookup"><span data-stu-id="9e43d-119">Method</span></span> | <span data-ttu-id="9e43d-120">要求 URI</span><span class="sxs-lookup"><span data-stu-id="9e43d-120">Request URI</span></span>                                                      |
|--------|------------------------------------------------------------------|
| <span data-ttu-id="9e43d-121">PUT</span><span class="sxs-lookup"><span data-stu-id="9e43d-121">PUT</span></span>   | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/submissions/{submissionId}  ``` |

<span/>
 

### <a name="request-header"></a><span data-ttu-id="9e43d-122">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="9e43d-122">Request header</span></span>

| <span data-ttu-id="9e43d-123">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="9e43d-123">Header</span></span>        | <span data-ttu-id="9e43d-124">型</span><span class="sxs-lookup"><span data-stu-id="9e43d-124">Type</span></span>   | <span data-ttu-id="9e43d-125">説明</span><span class="sxs-lookup"><span data-stu-id="9e43d-125">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="9e43d-126">Authorization</span><span class="sxs-lookup"><span data-stu-id="9e43d-126">Authorization</span></span> | <span data-ttu-id="9e43d-127">string</span><span class="sxs-lookup"><span data-stu-id="9e43d-127">string</span></span> | <span data-ttu-id="9e43d-128">必須。</span><span class="sxs-lookup"><span data-stu-id="9e43d-128">Required.</span></span> <span data-ttu-id="9e43d-129">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="9e43d-129">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |

<span/>

### <a name="request-parameters"></a><span data-ttu-id="9e43d-130">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="9e43d-130">Request parameters</span></span>

| <span data-ttu-id="9e43d-131">名前</span><span class="sxs-lookup"><span data-stu-id="9e43d-131">Name</span></span>        | <span data-ttu-id="9e43d-132">種類</span><span class="sxs-lookup"><span data-stu-id="9e43d-132">Type</span></span>   | <span data-ttu-id="9e43d-133">説明</span><span class="sxs-lookup"><span data-stu-id="9e43d-133">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="9e43d-134">applicationId</span><span class="sxs-lookup"><span data-stu-id="9e43d-134">applicationId</span></span> | <span data-ttu-id="9e43d-135">string</span><span class="sxs-lookup"><span data-stu-id="9e43d-135">string</span></span> | <span data-ttu-id="9e43d-136">必須。</span><span class="sxs-lookup"><span data-stu-id="9e43d-136">Required.</span></span> <span data-ttu-id="9e43d-137">申請を更新するアプリのストア ID です。</span><span class="sxs-lookup"><span data-stu-id="9e43d-137">The Store ID of the app for which you want to update a submission.</span></span> <span data-ttu-id="9e43d-138">ストア ID について詳しくは、「[アプリ ID の詳細の表示](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9e43d-138">For more information about the Store ID, see [View app identity details](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details).</span></span>  |
| <span data-ttu-id="9e43d-139">submissionId</span><span class="sxs-lookup"><span data-stu-id="9e43d-139">submissionId</span></span> | <span data-ttu-id="9e43d-140">string</span><span class="sxs-lookup"><span data-stu-id="9e43d-140">string</span></span> | <span data-ttu-id="9e43d-141">必須。</span><span class="sxs-lookup"><span data-stu-id="9e43d-141">Required.</span></span> <span data-ttu-id="9e43d-142">更新する申請の ID です。</span><span class="sxs-lookup"><span data-stu-id="9e43d-142">The ID of the submission to update.</span></span> <span data-ttu-id="9e43d-143">この ID は、[アプリの申請の作成](create-an-app-submission.md)要求の応答データに含まれており、デベロッパー センター ダッシュボードで確認できます。</span><span class="sxs-lookup"><span data-stu-id="9e43d-143">This ID is available in the Dev Center dashboard, and it is included in the response data for requests to [create an app submission](create-an-app-submission.md).</span></span>  |

<span/>

### <a name="request-body"></a><span data-ttu-id="9e43d-144">要求本文</span><span class="sxs-lookup"><span data-stu-id="9e43d-144">Request body</span></span>

<span data-ttu-id="9e43d-145">要求本文には次のパラメーターがあります。</span><span class="sxs-lookup"><span data-stu-id="9e43d-145">The request body has the following parameters.</span></span>

| <span data-ttu-id="9e43d-146">値</span><span class="sxs-lookup"><span data-stu-id="9e43d-146">Value</span></span>      | <span data-ttu-id="9e43d-147">型</span><span class="sxs-lookup"><span data-stu-id="9e43d-147">Type</span></span>   | <span data-ttu-id="9e43d-148">説明</span><span class="sxs-lookup"><span data-stu-id="9e43d-148">Description</span></span>                                                                                                                                                                                                                                                                         |
|------------|--------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="9e43d-149">applicationCategory</span><span class="sxs-lookup"><span data-stu-id="9e43d-149">applicationCategory</span></span>           | <span data-ttu-id="9e43d-150">string</span><span class="sxs-lookup"><span data-stu-id="9e43d-150">string</span></span>  |   <span data-ttu-id="9e43d-151">アプリの[カテゴリとサブカテゴリ](https://msdn.microsoft.com/windows/uwp/publish/category-and-subcategory-table)を指定する文字列です。</span><span class="sxs-lookup"><span data-stu-id="9e43d-151">A string that specifies the [category and/or subcategory](https://msdn.microsoft.com/windows/uwp/publish/category-and-subcategory-table) for your app.</span></span> <span data-ttu-id="9e43d-152">カテゴリとサブカテゴリは、アンダースコア "_" で 1 つの文字列に連結します (例: **BooksAndReference_EReader**)。</span><span class="sxs-lookup"><span data-stu-id="9e43d-152">Categories and subcategories are combined into a single string with the underscore '_' character, such as **BooksAndReference_EReader**.</span></span>      |  
| <span data-ttu-id="9e43d-153">pricing</span><span class="sxs-lookup"><span data-stu-id="9e43d-153">pricing</span></span>           |  <span data-ttu-id="9e43d-154">object</span><span class="sxs-lookup"><span data-stu-id="9e43d-154">object</span></span>  | <span data-ttu-id="9e43d-155">アプリの価格情報を含むオブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="9e43d-155">An object that contains pricing info for the app.</span></span> <span data-ttu-id="9e43d-156">詳しくは、「[価格リソース](manage-app-submissions.md#pricing-object)」セクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9e43d-156">For more information, see the [Pricing resource](manage-app-submissions.md#pricing-object) section.</span></span>       |   
| <span data-ttu-id="9e43d-157">visibility</span><span class="sxs-lookup"><span data-stu-id="9e43d-157">visibility</span></span>           |  <span data-ttu-id="9e43d-158">string</span><span class="sxs-lookup"><span data-stu-id="9e43d-158">string</span></span>  |  <span data-ttu-id="9e43d-159">アプリの表示です。</span><span class="sxs-lookup"><span data-stu-id="9e43d-159">The visibility of the app.</span></span> <span data-ttu-id="9e43d-160">次のいずれかの値を使用できます。</span><span class="sxs-lookup"><span data-stu-id="9e43d-160">This can be one of the following values:</span></span> <ul><li><span data-ttu-id="9e43d-161">Hidden</span><span class="sxs-lookup"><span data-stu-id="9e43d-161">Hidden</span></span></li><li><span data-ttu-id="9e43d-162">Public</span><span class="sxs-lookup"><span data-stu-id="9e43d-162">Public</span></span></li><li><span data-ttu-id="9e43d-163">Private</span><span class="sxs-lookup"><span data-stu-id="9e43d-163">Private</span></span></li><li><span data-ttu-id="9e43d-164">NotSet</span><span class="sxs-lookup"><span data-stu-id="9e43d-164">NotSet</span></span></li></ul>       |   
| <span data-ttu-id="9e43d-165">targetPublishMode</span><span class="sxs-lookup"><span data-stu-id="9e43d-165">targetPublishMode</span></span>           | <span data-ttu-id="9e43d-166">string</span><span class="sxs-lookup"><span data-stu-id="9e43d-166">string</span></span>  | <span data-ttu-id="9e43d-167">申請の公開モードです。</span><span class="sxs-lookup"><span data-stu-id="9e43d-167">The publish mode for the submission.</span></span> <span data-ttu-id="9e43d-168">次のいずれかの値を使用できます。</span><span class="sxs-lookup"><span data-stu-id="9e43d-168">This can be one of the following values:</span></span> <ul><li><span data-ttu-id="9e43d-169">Immediate</span><span class="sxs-lookup"><span data-stu-id="9e43d-169">Immediate</span></span></li><li><span data-ttu-id="9e43d-170">Manual</span><span class="sxs-lookup"><span data-stu-id="9e43d-170">Manual</span></span></li><li><span data-ttu-id="9e43d-171">SpecificDate</span><span class="sxs-lookup"><span data-stu-id="9e43d-171">SpecificDate</span></span></li></ul> |
| <span data-ttu-id="9e43d-172">targetPublishDate</span><span class="sxs-lookup"><span data-stu-id="9e43d-172">targetPublishDate</span></span>           | <span data-ttu-id="9e43d-173">string</span><span class="sxs-lookup"><span data-stu-id="9e43d-173">string</span></span>  | <span data-ttu-id="9e43d-174">*targetPublishMode* が SpecificDate に設定されている場合、ISO 8601 形式での申請の公開日です。</span><span class="sxs-lookup"><span data-stu-id="9e43d-174">The publish date for the submission in ISO 8601 format, if the *targetPublishMode* is set to SpecificDate.</span></span>  |  
| <span data-ttu-id="9e43d-175">listings</span><span class="sxs-lookup"><span data-stu-id="9e43d-175">listings</span></span>           |   <span data-ttu-id="9e43d-176">object</span><span class="sxs-lookup"><span data-stu-id="9e43d-176">object</span></span>  |  <span data-ttu-id="9e43d-177">キーと値のペアのディクショナリです。各キーは国コード、各値はアプリの登録情報を含む[登録情報リソース](manage-app-submissions.md#listing-object) オブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="9e43d-177">A dictionary of key and value pairs, where each key is a country code and each value is a [Listing resource](manage-app-submissions.md#listing-object) object that contains listing info for the app.</span></span>       |   
| <span data-ttu-id="9e43d-178">hardwarePreferences</span><span class="sxs-lookup"><span data-stu-id="9e43d-178">hardwarePreferences</span></span>           |  <span data-ttu-id="9e43d-179">array</span><span class="sxs-lookup"><span data-stu-id="9e43d-179">array</span></span>  |   <span data-ttu-id="9e43d-180">アプリの[ハードウェアの基本設定](https://msdn.microsoft.com/windows/uwp/publish/enter-app-properties#hardware_preferences)を定義する文字列の配列です。</span><span class="sxs-lookup"><span data-stu-id="9e43d-180">An array of strings that define the [hardware preferences](https://msdn.microsoft.com/windows/uwp/publish/enter-app-properties#hardware_preferences) for your app.</span></span> <span data-ttu-id="9e43d-181">次のいずれかの値を使用できます。</span><span class="sxs-lookup"><span data-stu-id="9e43d-181">This can be one of the following values:</span></span> <ul><li><span data-ttu-id="9e43d-182">Touch</span><span class="sxs-lookup"><span data-stu-id="9e43d-182">Touch</span></span></li><li><span data-ttu-id="9e43d-183">Keyboard</span><span class="sxs-lookup"><span data-stu-id="9e43d-183">Keyboard</span></span></li><li><span data-ttu-id="9e43d-184">Mouse</span><span class="sxs-lookup"><span data-stu-id="9e43d-184">Mouse</span></span></li><li><span data-ttu-id="9e43d-185">Camera</span><span class="sxs-lookup"><span data-stu-id="9e43d-185">Camera</span></span></li><li><span data-ttu-id="9e43d-186">NfcHce</span><span class="sxs-lookup"><span data-stu-id="9e43d-186">NfcHce</span></span></li><li><span data-ttu-id="9e43d-187">Nfc</span><span class="sxs-lookup"><span data-stu-id="9e43d-187">Nfc</span></span></li><li><span data-ttu-id="9e43d-188">BluetoothLE</span><span class="sxs-lookup"><span data-stu-id="9e43d-188">BluetoothLE</span></span></li><li><span data-ttu-id="9e43d-189">Telephony</span><span class="sxs-lookup"><span data-stu-id="9e43d-189">Telephony</span></span></li></ul>     |   
| <span data-ttu-id="9e43d-190">automaticBackupEnabled</span><span class="sxs-lookup"><span data-stu-id="9e43d-190">automaticBackupEnabled</span></span>           |  <span data-ttu-id="9e43d-191">boolean</span><span class="sxs-lookup"><span data-stu-id="9e43d-191">boolean</span></span>  |   <span data-ttu-id="9e43d-192">OneDrive への自動バックアップにアプリのデータを含めることができるかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="9e43d-192">Indicates whether Windows can include your app's data in automatic backups to OneDrive.</span></span> <span data-ttu-id="9e43d-193">詳しくは、「[アプリの宣言](https://msdn.microsoft.com/windows/uwp/publish/app-declarations)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9e43d-193">For more information, see [App declarations](https://msdn.microsoft.com/windows/uwp/publish/app-declarations).</span></span>   |   
| <span data-ttu-id="9e43d-194">canInstallOnRemovableMedia</span><span class="sxs-lookup"><span data-stu-id="9e43d-194">canInstallOnRemovableMedia</span></span>           |  <span data-ttu-id="9e43d-195">boolean</span><span class="sxs-lookup"><span data-stu-id="9e43d-195">boolean</span></span>  |   <span data-ttu-id="9e43d-196">ユーザーがアプリをリムーバブル記憶域にインストールできるかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="9e43d-196">Indicates whether customers can install your app to removable storage.</span></span> <span data-ttu-id="9e43d-197">詳しくは、「[アプリの宣言](https://msdn.microsoft.com/windows/uwp/publish/app-declarations)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9e43d-197">For more information, see [App declarations](https://msdn.microsoft.com/windows/uwp/publish/app-declarations).</span></span>     |   
| <span data-ttu-id="9e43d-198">isGameDvrEnabled</span><span class="sxs-lookup"><span data-stu-id="9e43d-198">isGameDvrEnabled</span></span>           |  <span data-ttu-id="9e43d-199">boolean</span><span class="sxs-lookup"><span data-stu-id="9e43d-199">boolean</span></span> |   <span data-ttu-id="9e43d-200">アプリのゲーム録画が有効になっているかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="9e43d-200">Indicates whether game DVR is enabled for the app.</span></span>    |   
| <span data-ttu-id="9e43d-201">gamingOptions</span><span class="sxs-lookup"><span data-stu-id="9e43d-201">gamingOptions</span></span>           |  <span data-ttu-id="9e43d-202">object</span><span class="sxs-lookup"><span data-stu-id="9e43d-202">object</span></span> |   <span data-ttu-id="9e43d-203">アプリのゲーム関連の設定を定義する 1 つの[ゲーム オプション リソース](manage-app-submissions.md#gaming-options-object)を格納する配列です。</span><span class="sxs-lookup"><span data-stu-id="9e43d-203">An array that contains one [gaming options resource](manage-app-submissions.md#gaming-options-object) that defines game-related settings for the app.</span></span><br/><br/><span data-ttu-id="9e43d-204">**注:**&nbsp;&nbsp;この API を使ってゲーム オプションを構成する機能は、現在すべての開発者アカウントで利用できるわけではありません。</span><span class="sxs-lookup"><span data-stu-id="9e43d-204">**Note:**&nbsp;&nbsp;The ability to configure gaming options using this API is currently not available to all developer accounts.</span></span> <span data-ttu-id="9e43d-205">ご自分のアカウントにこのリソースへのアクセス権がない場合、*gamingOptions* 値は null です。</span><span class="sxs-lookup"><span data-stu-id="9e43d-205">If your account does not have access to this resource, the *gamingOptions* value is null.</span></span>     |   
| <span data-ttu-id="9e43d-206">hasExternalInAppProducts</span><span class="sxs-lookup"><span data-stu-id="9e43d-206">hasExternalInAppProducts</span></span>           |     <span data-ttu-id="9e43d-207">boolean</span><span class="sxs-lookup"><span data-stu-id="9e43d-207">boolean</span></span>          |   <span data-ttu-id="9e43d-208">ユーザーが Windows ストア コマース システムを使わないで購入することをアプリが許可するかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="9e43d-208">Indicates whether your app allows users to make purchase outside the Windows Store commerce system.</span></span> <span data-ttu-id="9e43d-209">詳しくは、「[アプリの宣言](https://msdn.microsoft.com/windows/uwp/publish/app-declarations)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9e43d-209">For more information, see [App declarations](https://msdn.microsoft.com/windows/uwp/publish/app-declarations).</span></span>     |   
| <span data-ttu-id="9e43d-210">meetAccessibilityGuidelines</span><span class="sxs-lookup"><span data-stu-id="9e43d-210">meetAccessibilityGuidelines</span></span>           |    <span data-ttu-id="9e43d-211">boolean</span><span class="sxs-lookup"><span data-stu-id="9e43d-211">boolean</span></span>           |  <span data-ttu-id="9e43d-212">アプリがアクセシビリティ ガイドラインを満たことをテストされているかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="9e43d-212">Indicates whether your app has been tested to meet accessibility guidelines.</span></span> <span data-ttu-id="9e43d-213">詳しくは、「[アプリの宣言](https://msdn.microsoft.com/windows/uwp/publish/app-declarations)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9e43d-213">For more information, see [App declarations](https://msdn.microsoft.com/windows/uwp/publish/app-declarations).</span></span>      |   
| <span data-ttu-id="9e43d-214">notesForCertification</span><span class="sxs-lookup"><span data-stu-id="9e43d-214">notesForCertification</span></span>           |  <span data-ttu-id="9e43d-215">string</span><span class="sxs-lookup"><span data-stu-id="9e43d-215">string</span></span>  |   <span data-ttu-id="9e43d-216">アプリの[認定の注意書き](https://msdn.microsoft.com/windows/uwp/publish/notes-for-certification)が含まれます。</span><span class="sxs-lookup"><span data-stu-id="9e43d-216">Contains [notes for certification](https://msdn.microsoft.com/windows/uwp/publish/notes-for-certification) for your app.</span></span>    |    
| <span data-ttu-id="9e43d-217">applicationPackages</span><span class="sxs-lookup"><span data-stu-id="9e43d-217">applicationPackages</span></span>           |   <span data-ttu-id="9e43d-218">array</span><span class="sxs-lookup"><span data-stu-id="9e43d-218">array</span></span>  | <span data-ttu-id="9e43d-219">申請の各パッケージに関する詳細を提供するオブジェクトが含まれています。</span><span class="sxs-lookup"><span data-stu-id="9e43d-219">Contains objects that provide details about each package in the submission.</span></span> <span data-ttu-id="9e43d-220">詳しくは、「[アプリ パッケージ](manage-app-submissions.md#application-package-object)」セクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9e43d-220">For more information, see the [Application package](manage-app-submissions.md#application-package-object) section.</span></span> <span data-ttu-id="9e43d-221">このメソッドを呼び出してアプリの申請を更新するとき、要求の本文では、これらのオブジェクトの値 *fileName*、*fileStatus*、*minimumDirectXVersion*、*minimumSystemRam* だけが必須です。</span><span class="sxs-lookup"><span data-stu-id="9e43d-221">When calling this method to update an app submission, only the *fileName*, *fileStatus*, *minimumDirectXVersion*, and *minimumSystemRam* values of these objects are required in the request body.</span></span> <span data-ttu-id="9e43d-222">他の値はデベロッパー センターによって設定されます。</span><span class="sxs-lookup"><span data-stu-id="9e43d-222">The other values are populated by Dev Center.</span></span>   |    
| <span data-ttu-id="9e43d-223">packageDeliveryOptions</span><span class="sxs-lookup"><span data-stu-id="9e43d-223">packageDeliveryOptions</span></span>    | <span data-ttu-id="9e43d-224">object</span><span class="sxs-lookup"><span data-stu-id="9e43d-224">object</span></span>  | <span data-ttu-id="9e43d-225">申請の段階的なパッケージのロールアウトと必須の更新の設定が含まれています。</span><span class="sxs-lookup"><span data-stu-id="9e43d-225">Contains gradual package rollout and mandatory update settings for the submission.</span></span> <span data-ttu-id="9e43d-226">詳しくは、「[パッケージの配信オプション オブジェクト](manage-app-submissions.md#package-delivery-options-object)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9e43d-226">For more information, see [Package delivery options object](manage-app-submissions.md#package-delivery-options-object).</span></span>  |
| <span data-ttu-id="9e43d-227">enterpriseLicensing</span><span class="sxs-lookup"><span data-stu-id="9e43d-227">enterpriseLicensing</span></span>           |  <span data-ttu-id="9e43d-228">string</span><span class="sxs-lookup"><span data-stu-id="9e43d-228">string</span></span>  |  <span data-ttu-id="9e43d-229">アプリのエンタープライズ ライセンス動作を示す[エンタープライズ ライセンス値](manage-app-submissions.md#enterprise-licensing)のいずれかです。</span><span class="sxs-lookup"><span data-stu-id="9e43d-229">One of the [enterprise licensing values](manage-app-submissions.md#enterprise-licensing) values that indicate the enterprise licensing behavior for the app.</span></span>  |    
| <span data-ttu-id="9e43d-230">allowMicrosftDecideAppAvailabilityToFutureDeviceFamilies</span><span class="sxs-lookup"><span data-stu-id="9e43d-230">allowMicrosftDecideAppAvailabilityToFutureDeviceFamilies</span></span>           |  <span data-ttu-id="9e43d-231">boolean</span><span class="sxs-lookup"><span data-stu-id="9e43d-231">boolean</span></span>   |  <span data-ttu-id="9e43d-232">[アプリを将来の Windows 10 デバイス ファミリで利用できるようにする](https://msdn.microsoft.com/windows/uwp/publish/set-app-pricing-and-availability#windows-10-device-families)ことを Microsoft が許可されているかどうかを示すします。</span><span class="sxs-lookup"><span data-stu-id="9e43d-232">Indicates whether Microsoft is allowed to [make the app available to future Windows 10 device families](https://msdn.microsoft.com/windows/uwp/publish/set-app-pricing-and-availability#windows-10-device-families).</span></span>    |    
| <span data-ttu-id="9e43d-233">allowTargetFutureDeviceFamilies</span><span class="sxs-lookup"><span data-stu-id="9e43d-233">allowTargetFutureDeviceFamilies</span></span>           | <span data-ttu-id="9e43d-234">boolean</span><span class="sxs-lookup"><span data-stu-id="9e43d-234">boolean</span></span>   |  <span data-ttu-id="9e43d-235">[将来の Windows 10 デバイス ファミリをターゲットにする](https://msdn.microsoft.com/windows/uwp/publish/set-app-pricing-and-availability#windows-10-device-families)ことをアプリが許可されているかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="9e43d-235">Indicates whether your app is allowed to [target future Windows 10 device families](https://msdn.microsoft.com/windows/uwp/publish/set-app-pricing-and-availability#windows-10-device-families).</span></span>     |   
| <span data-ttu-id="9e43d-236">trailers</span><span class="sxs-lookup"><span data-stu-id="9e43d-236">trailers</span></span>           |  <span data-ttu-id="9e43d-237">array</span><span class="sxs-lookup"><span data-stu-id="9e43d-237">array</span></span> |   <span data-ttu-id="9e43d-238">アプリの登録情報用のビデオ トレーラーを表す[トレーラー リソース](manage-app-submissions.md#trailer-object)を格納する配列です。格納できるトレーラー リソースの数には上限があります。</span><span class="sxs-lookup"><span data-stu-id="9e43d-238">An array that contains up to [trailer resources](manage-app-submissions.md#trailer-object) that represent video trailers for the app listing.</span></span> <br/><br/><span data-ttu-id="9e43d-239">**注:**&nbsp;&nbsp;この API を使ってアプリの申請用にトレーラーを提出する機能は、現在すべての開発者アカウントで利用できるわけではありません。</span><span class="sxs-lookup"><span data-stu-id="9e43d-239">**Note:**&nbsp;&nbsp;The ability to submit a trailer for your app submission using this API is currently not available to all developer accounts.</span></span> <span data-ttu-id="9e43d-240">ご自分のアカウントにこのリソースへのアクセス権がない場合、*trailers* 値は null です。</span><span class="sxs-lookup"><span data-stu-id="9e43d-240">If your account does not have access to this resource, the *trailers* value is null.</span></span>  |   

<span/>

### <a name="request-example"></a><span data-ttu-id="9e43d-241">要求の例</span><span class="sxs-lookup"><span data-stu-id="9e43d-241">Request example</span></span>

<span data-ttu-id="9e43d-242">次の例は、アプリの申請を更新する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="9e43d-242">The following example demonstrates how to update an app submission.</span></span>

```json
PUT https://manage.devcenter.microsoft.com/v1.0/my/applications/9NBLGGH4R315/submissions/1152921504621230023 HTTP/1.1
Authorization: Bearer <your access token>
Content-Type: application/json
{
  "applicationCategory": "BooksAndReference_EReader",
  "pricing": {
    "trialPeriod": "FifteenDays",
    "marketSpecificPricings": {},
    "sales": [],
    "priceId": "Tier2"
  },
  "visibility": "Public",
  "targetPublishMode": "Manual",
  "targetPublishDate": "1601-01-01T00:00:00Z",
  "listings": {
    "en-us": {
      "baseListing": {
        "copyrightAndTrademarkInfo": "",
        "keywords": [
              "epub"
            ],
        "licenseTerms": "",
        "privacyPolicy": "",
        "supportContact": "",
        "websiteUrl": "",
        "description": "Description",
        "features": [
              "Free ebook reader"
            ],
        "releaseNotes": "",
        "images": [
          {
            "fileName": "contoso.png",
            "fileStatus": "Uploaded",
            "id": "1152921504672272757",
            "imageType": "Screenshot"
          }
        ],
        "recommendedHardware": [],
        "title": "Contoso ebook reader"
      },
      "platformOverrides": {
        "Windows81": {
          "description": "Ebook reader for Windows 8.1"
        }
      }
    }
  },
  "hardwarePreferences": [
    "Touch"
  ],
  "automaticBackupEnabled": false,
  "canInstallOnRemovableMedia": true,
  "isGameDvrEnabled": false,
  "gamingOptions": [],
  "hasExternalInAppProducts": false,
  "meetAccessibilityGuidelines": true,
  "notesForCertification": "",
  "applicationPackages": [
    {
      "fileName": "contoso_app.appx",
      "fileStatus": "PendingUpload",
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
  "enterpriseLicensing": "Online",
  "allowMicrosoftDecideAppAvailabilityToFutureDeviceFamilies": true,
  "allowTargetFutureDeviceFamilies": {
    "Desktop": false,
    "Mobile": true,
    "Holographic": true,
    "Xbox": false,
    "Team": true
  },
  "trailers": []
}
```

## <a name="response"></a><span data-ttu-id="9e43d-243">応答</span><span class="sxs-lookup"><span data-stu-id="9e43d-243">Response</span></span>

<span data-ttu-id="9e43d-244">次の例は、このメソッドが正常に呼び出された場合の JSON 応答本文を示しています。</span><span class="sxs-lookup"><span data-stu-id="9e43d-244">The following example demonstrates the JSON response body for a successful call to this method.</span></span> <span data-ttu-id="9e43d-245">応答本文には、更新された申請に関する情報が含まれています。</span><span class="sxs-lookup"><span data-stu-id="9e43d-245">The response body contains information about the updated submission.</span></span> <span data-ttu-id="9e43d-246">応答本文内の値について詳しくは、[アプリの申請のリソース](manage-app-submissions.md#app-submission-object)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9e43d-246">For more details about the values in the response body, see [App submission resource](manage-app-submissions.md#app-submission-object).</span></span>

```json
{
  "id": "1152921504621243540",
  "applicationCategory": "BooksAndReference_EReader",
  "pricing": {
    "trialPeriod": "FifteenDays",
    "marketSpecificPricings": {},
    "sales": [],
    "priceId": "Tier2"
  },
  "visibility": "Public",
  "targetPublishMode": "Manual",
  "targetPublishDate": "1601-01-01T00:00:00Z",
  "listings": {
    "en-us": {
      "baseListing": {
        "copyrightAndTrademarkInfo": "",
        "keywords": [
           "epub"
        ],
        "licenseTerms": "",
        "privacyPolicy": "",
        "supportContact": "",
        "websiteUrl": "",
        "description": "Description",
        "features": [
          "Free ebook reader"
        ],
        "releaseNotes": "",
        "images": [
          {
            "fileName": "contoso.png",
            "fileStatus": "Uploaded",
            "id": "1152921504672272757",
            "imageType": "Screenshot"
          }
        ],
        "recommendedHardware": [],
        "title": "Contoso ebook reader"
      },
      "platformOverrides": {
        "Windows81": {
          "description": "Ebook reader for Windows 8.1",
        }
      }
    }
  },
  "hardwarePreferences": [
    "Touch"
  ],
  "automaticBackupEnabled": false,
  "canInstallOnRemovableMedia": true,
  "isGameDvrEnabled": false,
  "gamingOptions": [],
  "hasExternalInAppProducts": false,
  "meetAccessibilityGuidelines": true,
  "notesForCertification": "",
  "status": "PendingCommit",
  "statusDetails": {
    "errors": [],
    "warnings": [],
    "certificationReports": []
  },
  "fileUploadUrl": "https://productingestionbin1.blob.core.windows.net/ingestion/387a9ea8-a412-43a9-8fb3-a38d03eb483d?sv=2014-02-14&sr=b&sig=sdd12JmoaT6BhvC%2BZUrwRweA%2Fkvj%2BEBCY09C2SZZowg%3D&se=2016-06-17T18:32:26Z&sp=rwl",
  "applicationPackages": [
    {
      "fileName": "contoso_app.appx",
      "fileStatus": "PendingUpload",
      "id": "1152921504620138797",
      "version": "1.0.0.0",
      "architecture": "ARM",
      "languages": [
        "en-US"
      ],
      "capabilities": [
        "ID_RESOLUTION_HD720P",
        "ID_RESOLUTION_WVGA",
        "ID_RESOLUTION_WXGA"
      ],
      "minimumDirectXVersion": "None",
      "minimumSystemRam": "None",
      "targetDeviceFamilies": [
        "Windows.Mobile min version 10.0.10240.0"
      ]
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
  "enterpriseLicensing": "Online",
  "allowMicrosoftDecideAppAvailabilityToFutureDeviceFamilies": true,
  "allowTargetFutureDeviceFamilies": {
    "Desktop": false,
    "Mobile": true,
    "Holographic": true,
    "Xbox": false,
    "Team": true
  },
  "friendlyName": "Submission 2",
  "trailers": []
}
```

## <a name="error-codes"></a><span data-ttu-id="9e43d-247">エラー コード</span><span class="sxs-lookup"><span data-stu-id="9e43d-247">Error codes</span></span>

<span data-ttu-id="9e43d-248">要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。</span><span class="sxs-lookup"><span data-stu-id="9e43d-248">If the request cannot be successfully completed, the response will contain one of the following HTTP error codes.</span></span>

| <span data-ttu-id="9e43d-249">エラー コード</span><span class="sxs-lookup"><span data-stu-id="9e43d-249">Error code</span></span> |  <span data-ttu-id="9e43d-250">説明</span><span class="sxs-lookup"><span data-stu-id="9e43d-250">Description</span></span>   |
|--------|------------------|
| <span data-ttu-id="9e43d-251">400</span><span class="sxs-lookup"><span data-stu-id="9e43d-251">400</span></span>  | <span data-ttu-id="9e43d-252">要求が無効なため、申請を更新できませんでした。</span><span class="sxs-lookup"><span data-stu-id="9e43d-252">The submission could not be updated because the request is invalid.</span></span> |
| <span data-ttu-id="9e43d-253">409</span><span class="sxs-lookup"><span data-stu-id="9e43d-253">409</span></span>  | <span data-ttu-id="9e43d-254">アプリの現在の状態が原因で申請を更新できませんでした。または、[Windows ストア申請 API で現在サポートされていない](create-and-manage-submissions-using-windows-store-services.md#not_supported)デベロッパー センター ダッシュボード機能がアプリで使用されています。</span><span class="sxs-lookup"><span data-stu-id="9e43d-254">The submission could not be updated because of the current state of the app, or the app uses a Dev Center dashboard feature that is [currently not supported by the Windows Store submission API](create-and-manage-submissions-using-windows-store-services.md#not_supported).</span></span> |   

<span/>


## <a name="related-topics"></a><span data-ttu-id="9e43d-255">関連トピック</span><span class="sxs-lookup"><span data-stu-id="9e43d-255">Related topics</span></span>

* [<span data-ttu-id="9e43d-256">Windows ストア サービスを使用した申請の作成と管理</span><span class="sxs-lookup"><span data-stu-id="9e43d-256">Create and manage submissions using Windows Store services</span></span>](create-and-manage-submissions-using-windows-store-services.md)
* [<span data-ttu-id="9e43d-257">アプリの申請の取得</span><span class="sxs-lookup"><span data-stu-id="9e43d-257">Get an app submission</span></span>](get-an-app-submission.md)
* [<span data-ttu-id="9e43d-258">アプリの申請の作成</span><span class="sxs-lookup"><span data-stu-id="9e43d-258">Create an app submission</span></span>](create-an-app-submission.md)
* [<span data-ttu-id="9e43d-259">アプリの申請のコミット</span><span class="sxs-lookup"><span data-stu-id="9e43d-259">Commit an app submission</span></span>](commit-an-app-submission.md)
* [<span data-ttu-id="9e43d-260">アプリの申請の削除</span><span class="sxs-lookup"><span data-stu-id="9e43d-260">Delete an app submission</span></span>](delete-an-app-submission.md)
* [<span data-ttu-id="9e43d-261">アプリの申請の状態の取得</span><span class="sxs-lookup"><span data-stu-id="9e43d-261">Get the status of an app submission</span></span>](get-status-for-an-app-submission.md)
