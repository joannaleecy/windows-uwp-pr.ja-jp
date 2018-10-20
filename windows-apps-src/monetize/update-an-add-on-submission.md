---
author: Xansky
ms.assetid: 8C63D33B-557D-436E-9DDA-11F7A5BFA2D7
description: 既存のアドオンの申請を更新するには、Microsoft Store 申請 API の以下のメソッドを使います。
title: アドオンの申請の更新
ms.author: mhopkins
ms.date: 04/17/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, Microsoft Store 申請 API, アドオンの申請, 更新, アプリ内製品, IAP
ms.localizationpriority: medium
ms.openlocfilehash: 9126bae03644fb22f773cbd69cc397456a4cd48f
ms.sourcegitcommit: 72835733ec429a5deb6a11da4112336746e5e9cf
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/20/2018
ms.locfileid: "5171263"
---
# <a name="update-an-add-on-submission"></a><span data-ttu-id="8aa0f-104">アドオンの申請の更新</span><span class="sxs-lookup"><span data-stu-id="8aa0f-104">Update an add-on submission</span></span>


<span data-ttu-id="8aa0f-105">既存のアドオン (アプリ内製品または IAP とも呼ばれます) の申請を更新するには、Microsoft Store 申請 API の以下のメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="8aa0f-105">Use this method in the Microsoft Store submission API to update an existing add-on (also known as in-app product or IAP) submission.</span></span> <span data-ttu-id="8aa0f-106">このメソッドを使って申請を正常に更新した後は、インジェストと公開のために[申請をコミット](commit-an-add-on-submission.md)する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8aa0f-106">After you successfully update a submission by using this method, you must [commit the submission](commit-an-add-on-submission.md) for ingestion and publishing.</span></span>

<span data-ttu-id="8aa0f-107">このメソッドが Microsoft Store 申請 API を使ったアドオンの申請の作成プロセスにどのように適合するかについては、「[アドオンの申請の管理](manage-add-on-submissions.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8aa0f-107">For more information about how this method fits into the process of creating an add-on submission by using the Microsoft Store submission API, see [Manage add-on submissions](manage-add-on-submissions.md).</span></span>

## <a name="prerequisites"></a><span data-ttu-id="8aa0f-108">前提条件</span><span class="sxs-lookup"><span data-stu-id="8aa0f-108">Prerequisites</span></span>

<span data-ttu-id="8aa0f-109">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="8aa0f-109">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="8aa0f-110">Microsoft Store 申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="8aa0f-110">If you have not done so already, complete all the [prerequisites](create-and-manage-submissions-using-windows-store-services.md#prerequisites) for the Microsoft Store submission API.</span></span>
* <span data-ttu-id="8aa0f-111">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="8aa0f-111">[Obtain an Azure AD access token](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="8aa0f-112">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="8aa0f-112">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="8aa0f-113">トークンの有効期限が切れたら新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="8aa0f-113">After the token expires, you can obtain a new one.</span></span>
* <span data-ttu-id="8aa0f-114">デベロッパー センター アカウントにアドオン申請を作成します。</span><span class="sxs-lookup"><span data-stu-id="8aa0f-114">Create an add-on submission for an app in your Dev Center account.</span></span> <span data-ttu-id="8aa0f-115">この操作は、デベロッパー センター ダッシュボードまたは[アドオン申請の作成](create-an-add-on-submission.md)メソッドを使って実行できます。</span><span class="sxs-lookup"><span data-stu-id="8aa0f-115">You can do this in the Dev Center dashboard, or you can do this by using the [Create an add-on submission](create-an-add-on-submission.md) method.</span></span>

## <a name="request"></a><span data-ttu-id="8aa0f-116">要求</span><span class="sxs-lookup"><span data-stu-id="8aa0f-116">Request</span></span>

<span data-ttu-id="8aa0f-117">このメソッドの構文は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="8aa0f-117">This method has the following syntax.</span></span> <span data-ttu-id="8aa0f-118">ヘッダーと要求本文の使用例と説明については、次のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8aa0f-118">See the following sections for usage examples and descriptions of the header and request body.</span></span>

| <span data-ttu-id="8aa0f-119">メソッド</span><span class="sxs-lookup"><span data-stu-id="8aa0f-119">Method</span></span> | <span data-ttu-id="8aa0f-120">要求 URI</span><span class="sxs-lookup"><span data-stu-id="8aa0f-120">Request URI</span></span>                                                      |
|--------|------------------------------------------------------------------|
| <span data-ttu-id="8aa0f-121">PUT</span><span class="sxs-lookup"><span data-stu-id="8aa0f-121">PUT</span></span>    | ```https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/{inAppProductId}/submissions/{submissionId} ``` |


### <a name="request-header"></a><span data-ttu-id="8aa0f-122">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="8aa0f-122">Request header</span></span>

| <span data-ttu-id="8aa0f-123">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="8aa0f-123">Header</span></span>        | <span data-ttu-id="8aa0f-124">型</span><span class="sxs-lookup"><span data-stu-id="8aa0f-124">Type</span></span>   | <span data-ttu-id="8aa0f-125">説明</span><span class="sxs-lookup"><span data-stu-id="8aa0f-125">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="8aa0f-126">Authorization</span><span class="sxs-lookup"><span data-stu-id="8aa0f-126">Authorization</span></span> | <span data-ttu-id="8aa0f-127">string</span><span class="sxs-lookup"><span data-stu-id="8aa0f-127">string</span></span> | <span data-ttu-id="8aa0f-128">必須。</span><span class="sxs-lookup"><span data-stu-id="8aa0f-128">Required.</span></span> <span data-ttu-id="8aa0f-129">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="8aa0f-129">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="8aa0f-130">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="8aa0f-130">Request parameters</span></span>

| <span data-ttu-id="8aa0f-131">名前</span><span class="sxs-lookup"><span data-stu-id="8aa0f-131">Name</span></span>        | <span data-ttu-id="8aa0f-132">種類</span><span class="sxs-lookup"><span data-stu-id="8aa0f-132">Type</span></span>   | <span data-ttu-id="8aa0f-133">説明</span><span class="sxs-lookup"><span data-stu-id="8aa0f-133">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="8aa0f-134">inAppProductId</span><span class="sxs-lookup"><span data-stu-id="8aa0f-134">inAppProductId</span></span> | <span data-ttu-id="8aa0f-135">string</span><span class="sxs-lookup"><span data-stu-id="8aa0f-135">string</span></span> | <span data-ttu-id="8aa0f-136">必須。</span><span class="sxs-lookup"><span data-stu-id="8aa0f-136">Required.</span></span> <span data-ttu-id="8aa0f-137">申請を更新するアドオンのストア ID です。</span><span class="sxs-lookup"><span data-stu-id="8aa0f-137">The Store ID of the add-on for which you want to update a submission.</span></span> <span data-ttu-id="8aa0f-138">ストア ID はデベロッパー センター ダッシュボードで取得でき、[アドオンを作成](create-an-add-on.md)または[アドオンの詳細を取得](get-all-add-ons.md)する要求に対する応答データに含まれます。</span><span class="sxs-lookup"><span data-stu-id="8aa0f-138">The Store ID is available on the Dev Center dashboard, and it is included in the response data for requests to [Create an add-on](create-an-add-on.md) or [get add-on details](get-all-add-ons.md).</span></span>  |
| <span data-ttu-id="8aa0f-139">submissionId</span><span class="sxs-lookup"><span data-stu-id="8aa0f-139">submissionId</span></span> | <span data-ttu-id="8aa0f-140">string</span><span class="sxs-lookup"><span data-stu-id="8aa0f-140">string</span></span> | <span data-ttu-id="8aa0f-141">必須。</span><span class="sxs-lookup"><span data-stu-id="8aa0f-141">Required.</span></span> <span data-ttu-id="8aa0f-142">更新する申請の ID です。</span><span class="sxs-lookup"><span data-stu-id="8aa0f-142">The ID of the submission to update.</span></span> <span data-ttu-id="8aa0f-143">この ID は、[アドオンの申請の作成](create-an-add-on-submission.md)要求に対する応答データで確認できます。</span><span class="sxs-lookup"><span data-stu-id="8aa0f-143">This ID is available in the response data for requests to [create an add-on submission](create-an-add-on-submission.md).</span></span> <span data-ttu-id="8aa0f-144">デベロッパー センター ダッシュボードで作成された申請の場合、この ID はダッシュボードの申請ページの URL にも含まれています。</span><span class="sxs-lookup"><span data-stu-id="8aa0f-144">For a submission that was created in the Dev Center dashboard, this ID is also available in the URL for the submission page in the dashboard.</span></span>  |


### <a name="request-body"></a><span data-ttu-id="8aa0f-145">要求本文</span><span class="sxs-lookup"><span data-stu-id="8aa0f-145">Request body</span></span>

<span data-ttu-id="8aa0f-146">要求本文には次のパラメーターがあります。</span><span class="sxs-lookup"><span data-stu-id="8aa0f-146">The request body has the following parameters.</span></span>

| <span data-ttu-id="8aa0f-147">値</span><span class="sxs-lookup"><span data-stu-id="8aa0f-147">Value</span></span>      | <span data-ttu-id="8aa0f-148">型</span><span class="sxs-lookup"><span data-stu-id="8aa0f-148">Type</span></span>   | <span data-ttu-id="8aa0f-149">説明</span><span class="sxs-lookup"><span data-stu-id="8aa0f-149">Description</span></span>                                                                                                                                                                                                                                                                         |
|------------|--------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="8aa0f-150">contentType</span><span class="sxs-lookup"><span data-stu-id="8aa0f-150">contentType</span></span>           | <span data-ttu-id="8aa0f-151">string</span><span class="sxs-lookup"><span data-stu-id="8aa0f-151">string</span></span>  |  <span data-ttu-id="8aa0f-152">アドオンで提供されている[コンテンツの種類](../publish/enter-add-on-properties.md#content-type)です。</span><span class="sxs-lookup"><span data-stu-id="8aa0f-152">The [type of content](../publish/enter-add-on-properties.md#content-type) that is provided in the add-on.</span></span> <span data-ttu-id="8aa0f-153">次のいずれかの値を使用できます。</span><span class="sxs-lookup"><span data-stu-id="8aa0f-153">This can be one of the following values:</span></span> <ul><li><span data-ttu-id="8aa0f-154">NotSet</span><span class="sxs-lookup"><span data-stu-id="8aa0f-154">NotSet</span></span></li><li><span data-ttu-id="8aa0f-155">BookDownload</span><span class="sxs-lookup"><span data-stu-id="8aa0f-155">BookDownload</span></span></li><li><span data-ttu-id="8aa0f-156">EMagazine</span><span class="sxs-lookup"><span data-stu-id="8aa0f-156">EMagazine</span></span></li><li><span data-ttu-id="8aa0f-157">ENewspaper</span><span class="sxs-lookup"><span data-stu-id="8aa0f-157">ENewspaper</span></span></li><li><span data-ttu-id="8aa0f-158">MusicDownload</span><span class="sxs-lookup"><span data-stu-id="8aa0f-158">MusicDownload</span></span></li><li><span data-ttu-id="8aa0f-159">MusicStream</span><span class="sxs-lookup"><span data-stu-id="8aa0f-159">MusicStream</span></span></li><li><span data-ttu-id="8aa0f-160">OnlineDataStorage</span><span class="sxs-lookup"><span data-stu-id="8aa0f-160">OnlineDataStorage</span></span></li><li><span data-ttu-id="8aa0f-161">VideoDownload</span><span class="sxs-lookup"><span data-stu-id="8aa0f-161">VideoDownload</span></span></li><li><span data-ttu-id="8aa0f-162">VideoStream</span><span class="sxs-lookup"><span data-stu-id="8aa0f-162">VideoStream</span></span></li><li><span data-ttu-id="8aa0f-163">Asp</span><span class="sxs-lookup"><span data-stu-id="8aa0f-163">Asp</span></span></li><li><span data-ttu-id="8aa0f-164">OnlineDownload</span><span class="sxs-lookup"><span data-stu-id="8aa0f-164">OnlineDownload</span></span></li></ul> |  
| <span data-ttu-id="8aa0f-165">keywords</span><span class="sxs-lookup"><span data-stu-id="8aa0f-165">keywords</span></span>           | <span data-ttu-id="8aa0f-166">array</span><span class="sxs-lookup"><span data-stu-id="8aa0f-166">array</span></span>  | <span data-ttu-id="8aa0f-167">アドオンの[キーワード](../publish/enter-add-on-properties.md#keywords)の文字列を最大 10 個含む配列です。</span><span class="sxs-lookup"><span data-stu-id="8aa0f-167">An array of strings that contain up to 10 [keywords](../publish/enter-add-on-properties.md#keywords) for the add-on.</span></span> <span data-ttu-id="8aa0f-168">アプリでは、これらのキーワードを使ってアドオンを照会できます。</span><span class="sxs-lookup"><span data-stu-id="8aa0f-168">Your app can query for add-ons using these keywords.</span></span>   |
| <span data-ttu-id="8aa0f-169">lifetime</span><span class="sxs-lookup"><span data-stu-id="8aa0f-169">lifetime</span></span>           | <span data-ttu-id="8aa0f-170">string</span><span class="sxs-lookup"><span data-stu-id="8aa0f-170">string</span></span>  |  <span data-ttu-id="8aa0f-171">アドオンの有効期間です。</span><span class="sxs-lookup"><span data-stu-id="8aa0f-171">The lifetime of the add-on.</span></span> <span data-ttu-id="8aa0f-172">次のいずれかの値を使用できます。</span><span class="sxs-lookup"><span data-stu-id="8aa0f-172">This can be one of the following values:</span></span> <ul><li><span data-ttu-id="8aa0f-173">Forever</span><span class="sxs-lookup"><span data-stu-id="8aa0f-173">Forever</span></span></li><li><span data-ttu-id="8aa0f-174">OneDay</span><span class="sxs-lookup"><span data-stu-id="8aa0f-174">OneDay</span></span></li><li><span data-ttu-id="8aa0f-175">ThreeDays</span><span class="sxs-lookup"><span data-stu-id="8aa0f-175">ThreeDays</span></span></li><li><span data-ttu-id="8aa0f-176">FiveDays</span><span class="sxs-lookup"><span data-stu-id="8aa0f-176">FiveDays</span></span></li><li><span data-ttu-id="8aa0f-177">OneWeek</span><span class="sxs-lookup"><span data-stu-id="8aa0f-177">OneWeek</span></span></li><li><span data-ttu-id="8aa0f-178">TwoWeeks</span><span class="sxs-lookup"><span data-stu-id="8aa0f-178">TwoWeeks</span></span></li><li><span data-ttu-id="8aa0f-179">OneMonth</span><span class="sxs-lookup"><span data-stu-id="8aa0f-179">OneMonth</span></span></li><li><span data-ttu-id="8aa0f-180">TwoMonths</span><span class="sxs-lookup"><span data-stu-id="8aa0f-180">TwoMonths</span></span></li><li><span data-ttu-id="8aa0f-181">ThreeMonths</span><span class="sxs-lookup"><span data-stu-id="8aa0f-181">ThreeMonths</span></span></li><li><span data-ttu-id="8aa0f-182">SixMonths</span><span class="sxs-lookup"><span data-stu-id="8aa0f-182">SixMonths</span></span></li><li><span data-ttu-id="8aa0f-183">OneYear</span><span class="sxs-lookup"><span data-stu-id="8aa0f-183">OneYear</span></span></li></ul> |
| <span data-ttu-id="8aa0f-184">listings</span><span class="sxs-lookup"><span data-stu-id="8aa0f-184">listings</span></span>           | <span data-ttu-id="8aa0f-185">object</span><span class="sxs-lookup"><span data-stu-id="8aa0f-185">object</span></span>  | <span data-ttu-id="8aa0f-186">アドオンの表示内容を含むオブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="8aa0f-186">An object that contains listing info for the add-on.</span></span> <span data-ttu-id="8aa0f-187">詳しくは、「[表示リソース](manage-add-on-submissions.md#listing-object)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8aa0f-187">For more information, see [Listing resource](manage-add-on-submissions.md#listing-object).</span></span>  |
| <span data-ttu-id="8aa0f-188">pricing</span><span class="sxs-lookup"><span data-stu-id="8aa0f-188">pricing</span></span>           | <span data-ttu-id="8aa0f-189">object</span><span class="sxs-lookup"><span data-stu-id="8aa0f-189">object</span></span>  | <span data-ttu-id="8aa0f-190">アドオンの価格情報を含むオブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="8aa0f-190">An object that contains pricing info for the add-on.</span></span> <span data-ttu-id="8aa0f-191">詳しくは、「[価格リソース](manage-add-on-submissions.md#pricing-object)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8aa0f-191">For more information, see [Pricing resource](manage-add-on-submissions.md#pricing-object).</span></span>  |
| <span data-ttu-id="8aa0f-192">targetPublishMode</span><span class="sxs-lookup"><span data-stu-id="8aa0f-192">targetPublishMode</span></span>           | <span data-ttu-id="8aa0f-193">string</span><span class="sxs-lookup"><span data-stu-id="8aa0f-193">string</span></span>  | <span data-ttu-id="8aa0f-194">申請の公開モードです。</span><span class="sxs-lookup"><span data-stu-id="8aa0f-194">The publish mode for the submission.</span></span> <span data-ttu-id="8aa0f-195">次のいずれかの値を使用できます。</span><span class="sxs-lookup"><span data-stu-id="8aa0f-195">This can be one of the following values:</span></span> <ul><li><span data-ttu-id="8aa0f-196">Immediate</span><span class="sxs-lookup"><span data-stu-id="8aa0f-196">Immediate</span></span></li><li><span data-ttu-id="8aa0f-197">Manual</span><span class="sxs-lookup"><span data-stu-id="8aa0f-197">Manual</span></span></li><li><span data-ttu-id="8aa0f-198">SpecificDate</span><span class="sxs-lookup"><span data-stu-id="8aa0f-198">SpecificDate</span></span></li></ul> |
| <span data-ttu-id="8aa0f-199">targetPublishDate</span><span class="sxs-lookup"><span data-stu-id="8aa0f-199">targetPublishDate</span></span>           | <span data-ttu-id="8aa0f-200">string</span><span class="sxs-lookup"><span data-stu-id="8aa0f-200">string</span></span>  | <span data-ttu-id="8aa0f-201">*targetPublishMode* が SpecificDate に設定されている場合、ISO 8601 形式での申請の公開日です。</span><span class="sxs-lookup"><span data-stu-id="8aa0f-201">The publish date for the submission in ISO 8601 format, if the *targetPublishMode* is set to SpecificDate.</span></span>  |
| <span data-ttu-id="8aa0f-202">tag</span><span class="sxs-lookup"><span data-stu-id="8aa0f-202">tag</span></span>           | <span data-ttu-id="8aa0f-203">string</span><span class="sxs-lookup"><span data-stu-id="8aa0f-203">string</span></span>  |  <span data-ttu-id="8aa0f-204">アドオンの[カスタムの開発者データ](../publish/enter-add-on-properties.md#custom-developer-data)(この情報は従来*タグ*と呼ばれていました)。</span><span class="sxs-lookup"><span data-stu-id="8aa0f-204">The [custom developer data](../publish/enter-add-on-properties.md#custom-developer-data) for the add-on (this information was previously called the *tag*).</span></span>   |
| <span data-ttu-id="8aa0f-205">visibility</span><span class="sxs-lookup"><span data-stu-id="8aa0f-205">visibility</span></span>  | <span data-ttu-id="8aa0f-206">string</span><span class="sxs-lookup"><span data-stu-id="8aa0f-206">string</span></span>  |  <span data-ttu-id="8aa0f-207">アドオンの可視性です。</span><span class="sxs-lookup"><span data-stu-id="8aa0f-207">The visibility of the add-on.</span></span> <span data-ttu-id="8aa0f-208">次のいずれかの値を使用できます。</span><span class="sxs-lookup"><span data-stu-id="8aa0f-208">This can be one of the following values:</span></span> <ul><li><span data-ttu-id="8aa0f-209">Hidden</span><span class="sxs-lookup"><span data-stu-id="8aa0f-209">Hidden</span></span></li><li><span data-ttu-id="8aa0f-210">Public</span><span class="sxs-lookup"><span data-stu-id="8aa0f-210">Public</span></span></li><li><span data-ttu-id="8aa0f-211">Private</span><span class="sxs-lookup"><span data-stu-id="8aa0f-211">Private</span></span></li><li><span data-ttu-id="8aa0f-212">NotSet</span><span class="sxs-lookup"><span data-stu-id="8aa0f-212">NotSet</span></span></li></ul>  |


### <a name="request-example"></a><span data-ttu-id="8aa0f-213">要求の例</span><span class="sxs-lookup"><span data-stu-id="8aa0f-213">Request example</span></span>

<span data-ttu-id="8aa0f-214">次の例は、アドオンの申請を更新する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="8aa0f-214">The following example demonstrates how to update an add-on submission.</span></span>

```json
PUT https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/9NBLGGH4TNMP/submissions/1152921504621230023 HTTP/1.1
Authorization: Bearer <your access token>
Content-Type: application/json
{
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
    "priceId": "Free"
  },
  "targetPublishDate": "2016-03-15T05:10:58.047Z",
  "targetPublishMode": "Immediate",
  "tag": "SampleTag",
  "visibility": "Public",
}
```

## <a name="response"></a><span data-ttu-id="8aa0f-215">応答</span><span class="sxs-lookup"><span data-stu-id="8aa0f-215">Response</span></span>

<span data-ttu-id="8aa0f-216">次の例は、このメソッドが正常に呼び出された場合の JSON 応答本文を示しています。</span><span class="sxs-lookup"><span data-stu-id="8aa0f-216">The following example demonstrates the JSON response body for a successful call to this method.</span></span> <span data-ttu-id="8aa0f-217">応答本文には、更新された申請に関する情報が含まれています。</span><span class="sxs-lookup"><span data-stu-id="8aa0f-217">The response body contains information about the updated submission.</span></span> <span data-ttu-id="8aa0f-218">応答本文内の値について詳しくは、「[アドオンの申請のリソース](manage-add-on-submissions.md#add-on-submission-object)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8aa0f-218">For more details about the values in the response body, see [Add-on submission resource](manage-add-on-submissions.md#add-on-submission-object).</span></span>

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
    "priceId": "Free"
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

## <a name="error-codes"></a><span data-ttu-id="8aa0f-219">エラー コード</span><span class="sxs-lookup"><span data-stu-id="8aa0f-219">Error codes</span></span>

<span data-ttu-id="8aa0f-220">要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。</span><span class="sxs-lookup"><span data-stu-id="8aa0f-220">If the request cannot be successfully completed, the response will contain one of the following HTTP error codes.</span></span>

| <span data-ttu-id="8aa0f-221">エラー コード</span><span class="sxs-lookup"><span data-stu-id="8aa0f-221">Error code</span></span> |  <span data-ttu-id="8aa0f-222">説明</span><span class="sxs-lookup"><span data-stu-id="8aa0f-222">Description</span></span>   |
|--------|------------------|
| <span data-ttu-id="8aa0f-223">400</span><span class="sxs-lookup"><span data-stu-id="8aa0f-223">400</span></span>  | <span data-ttu-id="8aa0f-224">要求が無効なため、申請を更新できませんでした。</span><span class="sxs-lookup"><span data-stu-id="8aa0f-224">The submission could not be updated because the request is invalid.</span></span> |
| <span data-ttu-id="8aa0f-225">409</span><span class="sxs-lookup"><span data-stu-id="8aa0f-225">409</span></span>  | <span data-ttu-id="8aa0f-226">アドオンの現在の状態が原因で申請を更新できませんでした。または、[Microsoft Store 申請 API で現在サポートされていない](create-and-manage-submissions-using-windows-store-services.md#not_supported)デベロッパー センター ダッシュボード機能がアドオンで使用されています。</span><span class="sxs-lookup"><span data-stu-id="8aa0f-226">The submission could not be updated because of the current state of the add-on, or the add-on uses a Dev Center dashboard feature that is [currently not supported by the Microsoft Store submission API](create-and-manage-submissions-using-windows-store-services.md#not_supported).</span></span> |   


## <a name="related-topics"></a><span data-ttu-id="8aa0f-227">関連トピック</span><span class="sxs-lookup"><span data-stu-id="8aa0f-227">Related topics</span></span>

* [<span data-ttu-id="8aa0f-228">Microsoft Store サービスを使用した申請の作成と管理</span><span class="sxs-lookup"><span data-stu-id="8aa0f-228">Create and manage submissions using Microsoft Store services</span></span>](create-and-manage-submissions-using-windows-store-services.md)
* [<span data-ttu-id="8aa0f-229">アドオンの申請の管理</span><span class="sxs-lookup"><span data-stu-id="8aa0f-229">Manage add-on submissions</span></span>](manage-add-on-submissions.md)
* [<span data-ttu-id="8aa0f-230">アドオンの申請の取得</span><span class="sxs-lookup"><span data-stu-id="8aa0f-230">Get an add-on submission</span></span>](get-an-add-on-submission.md)
* [<span data-ttu-id="8aa0f-231">アドオンの申請の作成</span><span class="sxs-lookup"><span data-stu-id="8aa0f-231">Create an add-on submission</span></span>](create-an-add-on-submission.md)
* [<span data-ttu-id="8aa0f-232">アドオンの申請のコミット</span><span class="sxs-lookup"><span data-stu-id="8aa0f-232">Commit an add-on submission</span></span>](commit-an-add-on-submission.md)
* [<span data-ttu-id="8aa0f-233">アドオンの申請の削除</span><span class="sxs-lookup"><span data-stu-id="8aa0f-233">Delete an add-on submission</span></span>](delete-an-add-on-submission.md)
* [<span data-ttu-id="8aa0f-234">アドオンの申請の状態の取得</span><span class="sxs-lookup"><span data-stu-id="8aa0f-234">Get the status of an add-on submission</span></span>](get-status-for-an-add-on-submission.md)
