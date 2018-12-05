---
ms.assetid: E8751EBF-AE0F-4107-80A1-23C186453B1C
description: 既存のアプリの申請を更新するには、Microsoft Store 申請 API の以下のメソッドを使います。
title: アプリの申請の更新
ms.date: 04/17/2018
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store 申請 API, アプリの申請, 更新
ms.localizationpriority: medium
ms.openlocfilehash: b61508edf2ebc2ab155110189fe67df63e2bab30
ms.sourcegitcommit: c01c29cd97f1cbf050950526e18e15823b6a12a0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/05/2018
ms.locfileid: "8701897"
---
# <a name="update-an-app-submission"></a><span data-ttu-id="3a348-104">アプリの申請の更新</span><span class="sxs-lookup"><span data-stu-id="3a348-104">Update an app submission</span></span>

<span data-ttu-id="3a348-105">既存のアプリの申請を更新するには、Microsoft Store 申請 API の以下のメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="3a348-105">Use this method in the Microsoft Store submission API to update an existing app submission.</span></span> <span data-ttu-id="3a348-106">このメソッドを使って申請を正常に更新した後は、インジェストと公開のために[申請をコミット](commit-an-app-submission.md)する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3a348-106">After you successfully update a submission by using this method, you must [commit the submission](commit-an-app-submission.md) for ingestion and publishing.</span></span>

<span data-ttu-id="3a348-107">このメソッドが Microsoft Store 申請 API を使ったアプリの申請の作成プロセスにどのように適合するかについては、「[アプリの申請の管理](manage-app-submissions.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3a348-107">For more information about how this method fits into the process of creating an app submission by using the Microsoft Store submission API, see [Manage app submissions](manage-app-submissions.md).</span></span>

## <a name="prerequisites"></a><span data-ttu-id="3a348-108">前提条件</span><span class="sxs-lookup"><span data-stu-id="3a348-108">Prerequisites</span></span>

<span data-ttu-id="3a348-109">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="3a348-109">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="3a348-110">Microsoft Store 申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="3a348-110">If you have not done so already, complete all the [prerequisites](create-and-manage-submissions-using-windows-store-services.md#prerequisites) for the Microsoft Store submission API.</span></span>
* <span data-ttu-id="3a348-111">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="3a348-111">[Obtain an Azure AD access token](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="3a348-112">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="3a348-112">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="3a348-113">トークンの有効期限が切れたら、新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="3a348-113">After the token expires, you can obtain a new one.</span></span>
* <span data-ttu-id="3a348-114">アプリの 1 つの申請を作成します。</span><span class="sxs-lookup"><span data-stu-id="3a348-114">Create a submission for one of your apps.</span></span> <span data-ttu-id="3a348-115">パートナー センターで、これを行うか、[アプリの申請の作成](create-an-app-submission.md)方法を使用して、これを行うことができます。</span><span class="sxs-lookup"><span data-stu-id="3a348-115">You can do this in Partner Center, or you can do this by using the [create an app submission](create-an-app-submission.md) method.</span></span>

## <a name="request"></a><span data-ttu-id="3a348-116">要求</span><span class="sxs-lookup"><span data-stu-id="3a348-116">Request</span></span>

<span data-ttu-id="3a348-117">このメソッドの構文は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="3a348-117">This method has the following syntax.</span></span> <span data-ttu-id="3a348-118">ヘッダーと要求本文の使用例と説明については、次のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3a348-118">See the following sections for usage examples and descriptions of the header and request body.</span></span>

| <span data-ttu-id="3a348-119">メソッド</span><span class="sxs-lookup"><span data-stu-id="3a348-119">Method</span></span> | <span data-ttu-id="3a348-120">要求 URI</span><span class="sxs-lookup"><span data-stu-id="3a348-120">Request URI</span></span>                                                      |
|--------|------------------------------------------------------------------|
| <span data-ttu-id="3a348-121">PUT</span><span class="sxs-lookup"><span data-stu-id="3a348-121">PUT</span></span>   | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/submissions/{submissionId}  ``` |


### <a name="request-header"></a><span data-ttu-id="3a348-122">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="3a348-122">Request header</span></span>

| <span data-ttu-id="3a348-123">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="3a348-123">Header</span></span>        | <span data-ttu-id="3a348-124">型</span><span class="sxs-lookup"><span data-stu-id="3a348-124">Type</span></span>   | <span data-ttu-id="3a348-125">説明</span><span class="sxs-lookup"><span data-stu-id="3a348-125">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="3a348-126">Authorization</span><span class="sxs-lookup"><span data-stu-id="3a348-126">Authorization</span></span> | <span data-ttu-id="3a348-127">string</span><span class="sxs-lookup"><span data-stu-id="3a348-127">string</span></span> | <span data-ttu-id="3a348-128">必須。</span><span class="sxs-lookup"><span data-stu-id="3a348-128">Required.</span></span> <span data-ttu-id="3a348-129">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="3a348-129">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="3a348-130">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="3a348-130">Request parameters</span></span>

| <span data-ttu-id="3a348-131">名前</span><span class="sxs-lookup"><span data-stu-id="3a348-131">Name</span></span>        | <span data-ttu-id="3a348-132">種類</span><span class="sxs-lookup"><span data-stu-id="3a348-132">Type</span></span>   | <span data-ttu-id="3a348-133">説明</span><span class="sxs-lookup"><span data-stu-id="3a348-133">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="3a348-134">applicationId</span><span class="sxs-lookup"><span data-stu-id="3a348-134">applicationId</span></span> | <span data-ttu-id="3a348-135">string</span><span class="sxs-lookup"><span data-stu-id="3a348-135">string</span></span> | <span data-ttu-id="3a348-136">必須。</span><span class="sxs-lookup"><span data-stu-id="3a348-136">Required.</span></span> <span data-ttu-id="3a348-137">申請を更新するアプリのストア ID です。</span><span class="sxs-lookup"><span data-stu-id="3a348-137">The Store ID of the app for which you want to update a submission.</span></span> <span data-ttu-id="3a348-138">ストア ID について詳しくは、「[アプリ ID の詳細の表示](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3a348-138">For more information about the Store ID, see [View app identity details](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details).</span></span>  |
| <span data-ttu-id="3a348-139">submissionId</span><span class="sxs-lookup"><span data-stu-id="3a348-139">submissionId</span></span> | <span data-ttu-id="3a348-140">string</span><span class="sxs-lookup"><span data-stu-id="3a348-140">string</span></span> | <span data-ttu-id="3a348-141">必須。</span><span class="sxs-lookup"><span data-stu-id="3a348-141">Required.</span></span> <span data-ttu-id="3a348-142">更新する申請の ID です。</span><span class="sxs-lookup"><span data-stu-id="3a348-142">The ID of the submission to update.</span></span> <span data-ttu-id="3a348-143">この ID は、[アプリの申請の作成](create-an-app-submission.md)要求に対する応答データで確認できます。</span><span class="sxs-lookup"><span data-stu-id="3a348-143">This ID is available in the response data for requests to [create an app submission](create-an-app-submission.md).</span></span> <span data-ttu-id="3a348-144">パートナー センターで作成された申請ではこの ID はパートナー センターでの申請ページの URL で利用可能なもします。</span><span class="sxs-lookup"><span data-stu-id="3a348-144">For a submission that was created in Partner Center, this ID is also available in the URL for the submission page in Partner Center.</span></span>  |


### <a name="request-body"></a><span data-ttu-id="3a348-145">要求本文</span><span class="sxs-lookup"><span data-stu-id="3a348-145">Request body</span></span>

<span data-ttu-id="3a348-146">要求本文には次のパラメーターがあります。</span><span class="sxs-lookup"><span data-stu-id="3a348-146">The request body has the following parameters.</span></span>

| <span data-ttu-id="3a348-147">値</span><span class="sxs-lookup"><span data-stu-id="3a348-147">Value</span></span>      | <span data-ttu-id="3a348-148">型</span><span class="sxs-lookup"><span data-stu-id="3a348-148">Type</span></span>   | <span data-ttu-id="3a348-149">説明</span><span class="sxs-lookup"><span data-stu-id="3a348-149">Description</span></span>                                                                                                                                                                                                                                                                         |
|------------|--------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="3a348-150">applicationCategory</span><span class="sxs-lookup"><span data-stu-id="3a348-150">applicationCategory</span></span>           | <span data-ttu-id="3a348-151">string</span><span class="sxs-lookup"><span data-stu-id="3a348-151">string</span></span>  |   <span data-ttu-id="3a348-152">アプリの[カテゴリとサブカテゴリ](https://msdn.microsoft.com/windows/uwp/publish/category-and-subcategory-table)を指定する文字列です。</span><span class="sxs-lookup"><span data-stu-id="3a348-152">A string that specifies the [category and/or subcategory](https://msdn.microsoft.com/windows/uwp/publish/category-and-subcategory-table) for your app.</span></span> <span data-ttu-id="3a348-153">カテゴリとサブカテゴリは、アンダースコア "_" で 1 つの文字列に連結します (例: **BooksAndReference_EReader**)。</span><span class="sxs-lookup"><span data-stu-id="3a348-153">Categories and subcategories are combined into a single string with the underscore '_' character, such as **BooksAndReference_EReader**.</span></span>      |  
| <span data-ttu-id="3a348-154">pricing</span><span class="sxs-lookup"><span data-stu-id="3a348-154">pricing</span></span>           |  <span data-ttu-id="3a348-155">object</span><span class="sxs-lookup"><span data-stu-id="3a348-155">object</span></span>  | <span data-ttu-id="3a348-156">アプリの価格情報を含むオブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="3a348-156">An object that contains pricing info for the app.</span></span> <span data-ttu-id="3a348-157">詳しくは、「[価格リソース](manage-app-submissions.md#pricing-object)」セクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3a348-157">For more information, see the [Pricing resource](manage-app-submissions.md#pricing-object) section.</span></span>       |   
| <span data-ttu-id="3a348-158">visibility</span><span class="sxs-lookup"><span data-stu-id="3a348-158">visibility</span></span>           |  <span data-ttu-id="3a348-159">string</span><span class="sxs-lookup"><span data-stu-id="3a348-159">string</span></span>  |  <span data-ttu-id="3a348-160">アプリの表示です。</span><span class="sxs-lookup"><span data-stu-id="3a348-160">The visibility of the app.</span></span> <span data-ttu-id="3a348-161">次のいずれかの値を使用できます。</span><span class="sxs-lookup"><span data-stu-id="3a348-161">This can be one of the following values:</span></span> <ul><li><span data-ttu-id="3a348-162">Hidden</span><span class="sxs-lookup"><span data-stu-id="3a348-162">Hidden</span></span></li><li><span data-ttu-id="3a348-163">Public</span><span class="sxs-lookup"><span data-stu-id="3a348-163">Public</span></span></li><li><span data-ttu-id="3a348-164">Private</span><span class="sxs-lookup"><span data-stu-id="3a348-164">Private</span></span></li><li><span data-ttu-id="3a348-165">NotSet</span><span class="sxs-lookup"><span data-stu-id="3a348-165">NotSet</span></span></li></ul>       |   
| <span data-ttu-id="3a348-166">targetPublishMode</span><span class="sxs-lookup"><span data-stu-id="3a348-166">targetPublishMode</span></span>           | <span data-ttu-id="3a348-167">string</span><span class="sxs-lookup"><span data-stu-id="3a348-167">string</span></span>  | <span data-ttu-id="3a348-168">申請の公開モードです。</span><span class="sxs-lookup"><span data-stu-id="3a348-168">The publish mode for the submission.</span></span> <span data-ttu-id="3a348-169">次のいずれかの値を使用できます。</span><span class="sxs-lookup"><span data-stu-id="3a348-169">This can be one of the following values:</span></span> <ul><li><span data-ttu-id="3a348-170">Immediate</span><span class="sxs-lookup"><span data-stu-id="3a348-170">Immediate</span></span></li><li><span data-ttu-id="3a348-171">Manual</span><span class="sxs-lookup"><span data-stu-id="3a348-171">Manual</span></span></li><li><span data-ttu-id="3a348-172">SpecificDate</span><span class="sxs-lookup"><span data-stu-id="3a348-172">SpecificDate</span></span></li></ul> |
| <span data-ttu-id="3a348-173">targetPublishDate</span><span class="sxs-lookup"><span data-stu-id="3a348-173">targetPublishDate</span></span>           | <span data-ttu-id="3a348-174">string</span><span class="sxs-lookup"><span data-stu-id="3a348-174">string</span></span>  | <span data-ttu-id="3a348-175">*targetPublishMode* が SpecificDate に設定されている場合、ISO 8601 形式での申請の公開日です。</span><span class="sxs-lookup"><span data-stu-id="3a348-175">The publish date for the submission in ISO 8601 format, if the *targetPublishMode* is set to SpecificDate.</span></span>  |  
| <span data-ttu-id="3a348-176">listings</span><span class="sxs-lookup"><span data-stu-id="3a348-176">listings</span></span>           |   <span data-ttu-id="3a348-177">object</span><span class="sxs-lookup"><span data-stu-id="3a348-177">object</span></span>  |  <span data-ttu-id="3a348-178">キーと値のペアのディクショナリです。各キーは国コード、各値はアプリの登録情報を含む[登録情報リソース](manage-app-submissions.md#listing-object) オブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="3a348-178">A dictionary of key and value pairs, where each key is a country code and each value is a [Listing resource](manage-app-submissions.md#listing-object) object that contains listing info for the app.</span></span>       |   
| <span data-ttu-id="3a348-179">hardwarePreferences</span><span class="sxs-lookup"><span data-stu-id="3a348-179">hardwarePreferences</span></span>           |  <span data-ttu-id="3a348-180">array</span><span class="sxs-lookup"><span data-stu-id="3a348-180">array</span></span>  |   <span data-ttu-id="3a348-181">アプリの[ハードウェアの基本設定](https://msdn.microsoft.com/windows/uwp/publish/enter-app-properties#hardware_preferences)を定義する文字列の配列です。</span><span class="sxs-lookup"><span data-stu-id="3a348-181">An array of strings that define the [hardware preferences](https://msdn.microsoft.com/windows/uwp/publish/enter-app-properties#hardware_preferences) for your app.</span></span> <span data-ttu-id="3a348-182">次のいずれかの値を使用できます。</span><span class="sxs-lookup"><span data-stu-id="3a348-182">This can be one of the following values:</span></span> <ul><li><span data-ttu-id="3a348-183">Touch</span><span class="sxs-lookup"><span data-stu-id="3a348-183">Touch</span></span></li><li><span data-ttu-id="3a348-184">Keyboard</span><span class="sxs-lookup"><span data-stu-id="3a348-184">Keyboard</span></span></li><li><span data-ttu-id="3a348-185">Mouse</span><span class="sxs-lookup"><span data-stu-id="3a348-185">Mouse</span></span></li><li><span data-ttu-id="3a348-186">Camera</span><span class="sxs-lookup"><span data-stu-id="3a348-186">Camera</span></span></li><li><span data-ttu-id="3a348-187">NfcHce</span><span class="sxs-lookup"><span data-stu-id="3a348-187">NfcHce</span></span></li><li><span data-ttu-id="3a348-188">Nfc</span><span class="sxs-lookup"><span data-stu-id="3a348-188">Nfc</span></span></li><li><span data-ttu-id="3a348-189">BluetoothLE</span><span class="sxs-lookup"><span data-stu-id="3a348-189">BluetoothLE</span></span></li><li><span data-ttu-id="3a348-190">Telephony</span><span class="sxs-lookup"><span data-stu-id="3a348-190">Telephony</span></span></li></ul>     |   
| <span data-ttu-id="3a348-191">automaticBackupEnabled</span><span class="sxs-lookup"><span data-stu-id="3a348-191">automaticBackupEnabled</span></span>           |  <span data-ttu-id="3a348-192">boolean</span><span class="sxs-lookup"><span data-stu-id="3a348-192">boolean</span></span>  |   <span data-ttu-id="3a348-193">OneDrive への自動バックアップにアプリのデータを含めることができるかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="3a348-193">Indicates whether Windows can include your app's data in automatic backups to OneDrive.</span></span> <span data-ttu-id="3a348-194">詳しくは、「[アプリの宣言](https://msdn.microsoft.com/windows/uwp/publish/app-declarations)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3a348-194">For more information, see [App declarations](https://msdn.microsoft.com/windows/uwp/publish/app-declarations).</span></span>   |   
| <span data-ttu-id="3a348-195">canInstallOnRemovableMedia</span><span class="sxs-lookup"><span data-stu-id="3a348-195">canInstallOnRemovableMedia</span></span>           |  <span data-ttu-id="3a348-196">boolean</span><span class="sxs-lookup"><span data-stu-id="3a348-196">boolean</span></span>  |   <span data-ttu-id="3a348-197">ユーザーがアプリをリムーバブル記憶域にインストールできるかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="3a348-197">Indicates whether customers can install your app to removable storage.</span></span> <span data-ttu-id="3a348-198">詳しくは、「[アプリの宣言](https://msdn.microsoft.com/windows/uwp/publish/app-declarations)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3a348-198">For more information, see [App declarations](https://msdn.microsoft.com/windows/uwp/publish/app-declarations).</span></span>     |   
| <span data-ttu-id="3a348-199">isGameDvrEnabled</span><span class="sxs-lookup"><span data-stu-id="3a348-199">isGameDvrEnabled</span></span>           |  <span data-ttu-id="3a348-200">boolean</span><span class="sxs-lookup"><span data-stu-id="3a348-200">boolean</span></span> |   <span data-ttu-id="3a348-201">アプリのゲーム録画が有効になっているかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="3a348-201">Indicates whether game DVR is enabled for the app.</span></span>    |   
| <span data-ttu-id="3a348-202">gamingOptions</span><span class="sxs-lookup"><span data-stu-id="3a348-202">gamingOptions</span></span>           |  <span data-ttu-id="3a348-203">object</span><span class="sxs-lookup"><span data-stu-id="3a348-203">object</span></span> |   <span data-ttu-id="3a348-204">アプリのゲーム関連の設定を定義する 1 つの[ゲーム オプション リソース](manage-app-submissions.md#gaming-options-object)を格納する配列です。</span><span class="sxs-lookup"><span data-stu-id="3a348-204">An array that contains one [gaming options resource](manage-app-submissions.md#gaming-options-object) that defines game-related settings for the app.</span></span>     |   
| <span data-ttu-id="3a348-205">hasExternalInAppProducts</span><span class="sxs-lookup"><span data-stu-id="3a348-205">hasExternalInAppProducts</span></span>           |     <span data-ttu-id="3a348-206">boolean</span><span class="sxs-lookup"><span data-stu-id="3a348-206">boolean</span></span>          |   <span data-ttu-id="3a348-207">ユーザーが Microsoft Store コマース システムを使わないで購入することをアプリが許可するかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="3a348-207">Indicates whether your app allows users to make purchase outside the Microsoft Store commerce system.</span></span> <span data-ttu-id="3a348-208">詳しくは、「[アプリの宣言](https://msdn.microsoft.com/windows/uwp/publish/app-declarations)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3a348-208">For more information, see [App declarations](https://msdn.microsoft.com/windows/uwp/publish/app-declarations).</span></span>     |   
| <span data-ttu-id="3a348-209">meetAccessibilityGuidelines</span><span class="sxs-lookup"><span data-stu-id="3a348-209">meetAccessibilityGuidelines</span></span>           |    <span data-ttu-id="3a348-210">boolean</span><span class="sxs-lookup"><span data-stu-id="3a348-210">boolean</span></span>           |  <span data-ttu-id="3a348-211">アプリがアクセシビリティ ガイドラインを満たことをテストされているかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="3a348-211">Indicates whether your app has been tested to meet accessibility guidelines.</span></span> <span data-ttu-id="3a348-212">詳しくは、「[アプリの宣言](https://msdn.microsoft.com/windows/uwp/publish/app-declarations)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3a348-212">For more information, see [App declarations](https://msdn.microsoft.com/windows/uwp/publish/app-declarations).</span></span>      |   
| <span data-ttu-id="3a348-213">notesForCertification</span><span class="sxs-lookup"><span data-stu-id="3a348-213">notesForCertification</span></span>           |  <span data-ttu-id="3a348-214">string</span><span class="sxs-lookup"><span data-stu-id="3a348-214">string</span></span>  |   <span data-ttu-id="3a348-215">アプリの[認定の注意書き](https://msdn.microsoft.com/windows/uwp/publish/notes-for-certification)が含まれます。</span><span class="sxs-lookup"><span data-stu-id="3a348-215">Contains [notes for certification](https://msdn.microsoft.com/windows/uwp/publish/notes-for-certification) for your app.</span></span>    |    
| <span data-ttu-id="3a348-216">applicationPackages</span><span class="sxs-lookup"><span data-stu-id="3a348-216">applicationPackages</span></span>           |   <span data-ttu-id="3a348-217">array</span><span class="sxs-lookup"><span data-stu-id="3a348-217">array</span></span>  | <span data-ttu-id="3a348-218">申請の各パッケージに関する詳細を提供するオブジェクトが含まれています。</span><span class="sxs-lookup"><span data-stu-id="3a348-218">Contains objects that provide details about each package in the submission.</span></span> <span data-ttu-id="3a348-219">詳しくは、「[アプリ パッケージ](manage-app-submissions.md#application-package-object)」セクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3a348-219">For more information, see the [Application package](manage-app-submissions.md#application-package-object) section.</span></span> <span data-ttu-id="3a348-220">このメソッドを呼び出してアプリの申請を更新するとき、要求の本文では、これらのオブジェクトの値 *fileName*、*fileStatus*、*minimumDirectXVersion*、*minimumSystemRam* だけが必須です。</span><span class="sxs-lookup"><span data-stu-id="3a348-220">When calling this method to update an app submission, only the *fileName*, *fileStatus*, *minimumDirectXVersion*, and *minimumSystemRam* values of these objects are required in the request body.</span></span> <span data-ttu-id="3a348-221">パートナー センターによっては、他の値が設定されます。</span><span class="sxs-lookup"><span data-stu-id="3a348-221">The other values are populated by Partner Center.</span></span>   |    
| <span data-ttu-id="3a348-222">packageDeliveryOptions</span><span class="sxs-lookup"><span data-stu-id="3a348-222">packageDeliveryOptions</span></span>    | <span data-ttu-id="3a348-223">object</span><span class="sxs-lookup"><span data-stu-id="3a348-223">object</span></span>  | <span data-ttu-id="3a348-224">申請の段階的なパッケージのロールアウトと必須の更新の設定が含まれています。</span><span class="sxs-lookup"><span data-stu-id="3a348-224">Contains gradual package rollout and mandatory update settings for the submission.</span></span> <span data-ttu-id="3a348-225">詳しくは、「[パッケージの配信オプション オブジェクト](manage-app-submissions.md#package-delivery-options-object)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3a348-225">For more information, see [Package delivery options object](manage-app-submissions.md#package-delivery-options-object).</span></span>  |
| <span data-ttu-id="3a348-226">enterpriseLicensing</span><span class="sxs-lookup"><span data-stu-id="3a348-226">enterpriseLicensing</span></span>           |  <span data-ttu-id="3a348-227">string</span><span class="sxs-lookup"><span data-stu-id="3a348-227">string</span></span>  |  <span data-ttu-id="3a348-228">アプリのエンタープライズ ライセンス動作を示す[エンタープライズ ライセンス値](manage-app-submissions.md#enterprise-licensing)のいずれかです。</span><span class="sxs-lookup"><span data-stu-id="3a348-228">One of the [enterprise licensing values](manage-app-submissions.md#enterprise-licensing) values that indicate the enterprise licensing behavior for the app.</span></span>  |    
| <span data-ttu-id="3a348-229">allowMicrosftDecideAppAvailabilityToFutureDeviceFamilies</span><span class="sxs-lookup"><span data-stu-id="3a348-229">allowMicrosftDecideAppAvailabilityToFutureDeviceFamilies</span></span>           |  <span data-ttu-id="3a348-230">boolean</span><span class="sxs-lookup"><span data-stu-id="3a348-230">boolean</span></span>   |  <span data-ttu-id="3a348-231">[アプリを将来の Windows 10 デバイス ファミリで利用できるようにする](https://msdn.microsoft.com/windows/uwp/publish/set-app-pricing-and-availability#windows-10-device-families)ことを Microsoft が許可されているかどうかを示すします。</span><span class="sxs-lookup"><span data-stu-id="3a348-231">Indicates whether Microsoft is allowed to [make the app available to future Windows 10 device families](https://msdn.microsoft.com/windows/uwp/publish/set-app-pricing-and-availability#windows-10-device-families).</span></span>    |    
| <span data-ttu-id="3a348-232">allowTargetFutureDeviceFamilies</span><span class="sxs-lookup"><span data-stu-id="3a348-232">allowTargetFutureDeviceFamilies</span></span>           | <span data-ttu-id="3a348-233">boolean</span><span class="sxs-lookup"><span data-stu-id="3a348-233">boolean</span></span>   |  <span data-ttu-id="3a348-234">[将来の Windows 10 デバイス ファミリをターゲットにする](https://msdn.microsoft.com/windows/uwp/publish/set-app-pricing-and-availability#windows-10-device-families)ことをアプリが許可されているかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="3a348-234">Indicates whether your app is allowed to [target future Windows 10 device families](https://msdn.microsoft.com/windows/uwp/publish/set-app-pricing-and-availability#windows-10-device-families).</span></span>     |   
| <span data-ttu-id="3a348-235">trailers</span><span class="sxs-lookup"><span data-stu-id="3a348-235">trailers</span></span>           |  <span data-ttu-id="3a348-236">array</span><span class="sxs-lookup"><span data-stu-id="3a348-236">array</span></span> |   <span data-ttu-id="3a348-237">アプリの登録情報用のビデオ トレーラーを表す[トレーラー リソース](manage-app-submissions.md#trailer-object)を格納する配列です。格納できるトレーラー リソースの数には上限があります。</span><span class="sxs-lookup"><span data-stu-id="3a348-237">An array that contains up to [trailer resources](manage-app-submissions.md#trailer-object) that represent video trailers for the app listing.</span></span>   |   


### <a name="request-example"></a><span data-ttu-id="3a348-238">要求の例</span><span class="sxs-lookup"><span data-stu-id="3a348-238">Request example</span></span>

<span data-ttu-id="3a348-239">次の例は、アプリの申請を更新する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="3a348-239">The following example demonstrates how to update an app submission.</span></span>

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

## <a name="response"></a><span data-ttu-id="3a348-240">応答</span><span class="sxs-lookup"><span data-stu-id="3a348-240">Response</span></span>

<span data-ttu-id="3a348-241">次の例は、このメソッドが正常に呼び出された場合の JSON 応答本文を示しています。</span><span class="sxs-lookup"><span data-stu-id="3a348-241">The following example demonstrates the JSON response body for a successful call to this method.</span></span> <span data-ttu-id="3a348-242">応答本文には、更新された申請に関する情報が含まれています。</span><span class="sxs-lookup"><span data-stu-id="3a348-242">The response body contains information about the updated submission.</span></span> <span data-ttu-id="3a348-243">応答本文内の値について詳しくは、[アプリの申請のリソース](manage-app-submissions.md#app-submission-object)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3a348-243">For more details about the values in the response body, see [App submission resource](manage-app-submissions.md#app-submission-object).</span></span>

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

## <a name="error-codes"></a><span data-ttu-id="3a348-244">エラー コード</span><span class="sxs-lookup"><span data-stu-id="3a348-244">Error codes</span></span>

<span data-ttu-id="3a348-245">要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。</span><span class="sxs-lookup"><span data-stu-id="3a348-245">If the request cannot be successfully completed, the response will contain one of the following HTTP error codes.</span></span>

| <span data-ttu-id="3a348-246">エラー コード</span><span class="sxs-lookup"><span data-stu-id="3a348-246">Error code</span></span> |  <span data-ttu-id="3a348-247">説明</span><span class="sxs-lookup"><span data-stu-id="3a348-247">Description</span></span>   |
|--------|------------------|
| <span data-ttu-id="3a348-248">400</span><span class="sxs-lookup"><span data-stu-id="3a348-248">400</span></span>  | <span data-ttu-id="3a348-249">要求が無効なため、申請を更新できませんでした。</span><span class="sxs-lookup"><span data-stu-id="3a348-249">The submission could not be updated because the request is invalid.</span></span> |
| <span data-ttu-id="3a348-250">409</span><span class="sxs-lookup"><span data-stu-id="3a348-250">409</span></span>  | <span data-ttu-id="3a348-251">アプリの現在の状態があるため、申請を更新できませんでしたまたは[Microsoft Store 申請 API で現在サポートされている](create-and-manage-submissions-using-windows-store-services.md#not_supported)はパートナー センター機能、アプリで使用します。</span><span class="sxs-lookup"><span data-stu-id="3a348-251">The submission could not be updated because of the current state of the app, or the app uses a Partner Center feature that is [currently not supported by the Microsoft Store submission API](create-and-manage-submissions-using-windows-store-services.md#not_supported).</span></span> |   


## <a name="related-topics"></a><span data-ttu-id="3a348-252">関連トピック</span><span class="sxs-lookup"><span data-stu-id="3a348-252">Related topics</span></span>

* [<span data-ttu-id="3a348-253">Microsoft Store サービスを使用した申請の作成と管理</span><span class="sxs-lookup"><span data-stu-id="3a348-253">Create and manage submissions using Microsoft Store services</span></span>](create-and-manage-submissions-using-windows-store-services.md)
* [<span data-ttu-id="3a348-254">アプリの申請の取得</span><span class="sxs-lookup"><span data-stu-id="3a348-254">Get an app submission</span></span>](get-an-app-submission.md)
* [<span data-ttu-id="3a348-255">アプリの申請の作成</span><span class="sxs-lookup"><span data-stu-id="3a348-255">Create an app submission</span></span>](create-an-app-submission.md)
* [<span data-ttu-id="3a348-256">アプリの申請のコミット</span><span class="sxs-lookup"><span data-stu-id="3a348-256">Commit an app submission</span></span>](commit-an-app-submission.md)
* [<span data-ttu-id="3a348-257">アプリの申請の削除</span><span class="sxs-lookup"><span data-stu-id="3a348-257">Delete an app submission</span></span>](delete-an-app-submission.md)
* [<span data-ttu-id="3a348-258">アプリの申請の状態の取得</span><span class="sxs-lookup"><span data-stu-id="3a348-258">Get the status of an app submission</span></span>](get-status-for-an-app-submission.md)
