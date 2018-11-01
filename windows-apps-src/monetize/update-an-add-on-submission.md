---
author: Xansky
ms.assetid: 8C63D33B-557D-436E-9DDA-11F7A5BFA2D7
description: 既存のアドオンの申請を更新するには、Microsoft Store 申請 API の以下のメソッドを使います。
title: アドオンの申請の更新
ms.author: mhopkins
ms.date: 04/17/2018
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store 申請 API, アドオンの申請, 更新, アプリ内製品, IAP
ms.localizationpriority: medium
ms.openlocfilehash: a8c3faf3b3be554e3cbb5bc4891887559ac14ea2
ms.sourcegitcommit: cd00bb829306871e5103db481cf224ea7fb613f0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/31/2018
ms.locfileid: "5872093"
---
# <a name="update-an-add-on-submission"></a><span data-ttu-id="cba30-104">アドオンの申請の更新</span><span class="sxs-lookup"><span data-stu-id="cba30-104">Update an add-on submission</span></span>


<span data-ttu-id="cba30-105">既存のアドオン (アプリ内製品または IAP とも呼ばれます) の申請を更新するには、Microsoft Store 申請 API の以下のメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="cba30-105">Use this method in the Microsoft Store submission API to update an existing add-on (also known as in-app product or IAP) submission.</span></span> <span data-ttu-id="cba30-106">このメソッドを使って申請を正常に更新した後は、インジェストと公開のために[申請をコミット](commit-an-add-on-submission.md)する必要があります。</span><span class="sxs-lookup"><span data-stu-id="cba30-106">After you successfully update a submission by using this method, you must [commit the submission](commit-an-add-on-submission.md) for ingestion and publishing.</span></span>

<span data-ttu-id="cba30-107">このメソッドが Microsoft Store 申請 API を使ったアドオンの申請の作成プロセスにどのように適合するかについては、「[アドオンの申請の管理](manage-add-on-submissions.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="cba30-107">For more information about how this method fits into the process of creating an add-on submission by using the Microsoft Store submission API, see [Manage add-on submissions](manage-add-on-submissions.md).</span></span>

## <a name="prerequisites"></a><span data-ttu-id="cba30-108">前提条件</span><span class="sxs-lookup"><span data-stu-id="cba30-108">Prerequisites</span></span>

<span data-ttu-id="cba30-109">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="cba30-109">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="cba30-110">Microsoft Store 申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="cba30-110">If you have not done so already, complete all the [prerequisites](create-and-manage-submissions-using-windows-store-services.md#prerequisites) for the Microsoft Store submission API.</span></span>
* <span data-ttu-id="cba30-111">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="cba30-111">[Obtain an Azure AD access token](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="cba30-112">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="cba30-112">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="cba30-113">トークンの有効期限が切れたら新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="cba30-113">After the token expires, you can obtain a new one.</span></span>
* <span data-ttu-id="cba30-114">デベロッパー センター アカウントにアドオン申請を作成します。</span><span class="sxs-lookup"><span data-stu-id="cba30-114">Create an add-on submission for an app in your Dev Center account.</span></span> <span data-ttu-id="cba30-115">この操作は、デベロッパー センター ダッシュボードまたは[アドオン申請の作成](create-an-add-on-submission.md)メソッドを使って実行できます。</span><span class="sxs-lookup"><span data-stu-id="cba30-115">You can do this in the Dev Center dashboard, or you can do this by using the [Create an add-on submission](create-an-add-on-submission.md) method.</span></span>

## <a name="request"></a><span data-ttu-id="cba30-116">要求</span><span class="sxs-lookup"><span data-stu-id="cba30-116">Request</span></span>

<span data-ttu-id="cba30-117">このメソッドの構文は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="cba30-117">This method has the following syntax.</span></span> <span data-ttu-id="cba30-118">ヘッダーと要求本文の使用例と説明については、次のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="cba30-118">See the following sections for usage examples and descriptions of the header and request body.</span></span>

| <span data-ttu-id="cba30-119">メソッド</span><span class="sxs-lookup"><span data-stu-id="cba30-119">Method</span></span> | <span data-ttu-id="cba30-120">要求 URI</span><span class="sxs-lookup"><span data-stu-id="cba30-120">Request URI</span></span>                                                      |
|--------|------------------------------------------------------------------|
| <span data-ttu-id="cba30-121">PUT</span><span class="sxs-lookup"><span data-stu-id="cba30-121">PUT</span></span>    | ```https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/{inAppProductId}/submissions/{submissionId} ``` |


### <a name="request-header"></a><span data-ttu-id="cba30-122">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="cba30-122">Request header</span></span>

| <span data-ttu-id="cba30-123">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="cba30-123">Header</span></span>        | <span data-ttu-id="cba30-124">型</span><span class="sxs-lookup"><span data-stu-id="cba30-124">Type</span></span>   | <span data-ttu-id="cba30-125">説明</span><span class="sxs-lookup"><span data-stu-id="cba30-125">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="cba30-126">Authorization</span><span class="sxs-lookup"><span data-stu-id="cba30-126">Authorization</span></span> | <span data-ttu-id="cba30-127">string</span><span class="sxs-lookup"><span data-stu-id="cba30-127">string</span></span> | <span data-ttu-id="cba30-128">必須。</span><span class="sxs-lookup"><span data-stu-id="cba30-128">Required.</span></span> <span data-ttu-id="cba30-129">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="cba30-129">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="cba30-130">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="cba30-130">Request parameters</span></span>

| <span data-ttu-id="cba30-131">名前</span><span class="sxs-lookup"><span data-stu-id="cba30-131">Name</span></span>        | <span data-ttu-id="cba30-132">種類</span><span class="sxs-lookup"><span data-stu-id="cba30-132">Type</span></span>   | <span data-ttu-id="cba30-133">説明</span><span class="sxs-lookup"><span data-stu-id="cba30-133">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="cba30-134">inAppProductId</span><span class="sxs-lookup"><span data-stu-id="cba30-134">inAppProductId</span></span> | <span data-ttu-id="cba30-135">string</span><span class="sxs-lookup"><span data-stu-id="cba30-135">string</span></span> | <span data-ttu-id="cba30-136">必須。</span><span class="sxs-lookup"><span data-stu-id="cba30-136">Required.</span></span> <span data-ttu-id="cba30-137">申請を更新するアドオンのストア ID です。</span><span class="sxs-lookup"><span data-stu-id="cba30-137">The Store ID of the add-on for which you want to update a submission.</span></span> <span data-ttu-id="cba30-138">ストア ID はデベロッパー センター ダッシュボードで取得でき、[アドオンを作成](create-an-add-on.md)または[アドオンの詳細を取得](get-all-add-ons.md)する要求に対する応答データに含まれます。</span><span class="sxs-lookup"><span data-stu-id="cba30-138">The Store ID is available on the Dev Center dashboard, and it is included in the response data for requests to [Create an add-on](create-an-add-on.md) or [get add-on details](get-all-add-ons.md).</span></span>  |
| <span data-ttu-id="cba30-139">submissionId</span><span class="sxs-lookup"><span data-stu-id="cba30-139">submissionId</span></span> | <span data-ttu-id="cba30-140">string</span><span class="sxs-lookup"><span data-stu-id="cba30-140">string</span></span> | <span data-ttu-id="cba30-141">必須。</span><span class="sxs-lookup"><span data-stu-id="cba30-141">Required.</span></span> <span data-ttu-id="cba30-142">更新する申請の ID です。</span><span class="sxs-lookup"><span data-stu-id="cba30-142">The ID of the submission to update.</span></span> <span data-ttu-id="cba30-143">この ID は、[アドオンの申請の作成](create-an-add-on-submission.md)要求に対する応答データで確認できます。</span><span class="sxs-lookup"><span data-stu-id="cba30-143">This ID is available in the response data for requests to [create an add-on submission](create-an-add-on-submission.md).</span></span> <span data-ttu-id="cba30-144">デベロッパー センター ダッシュボードで作成された申請の場合、この ID はダッシュボードの申請ページの URL にも含まれています。</span><span class="sxs-lookup"><span data-stu-id="cba30-144">For a submission that was created in the Dev Center dashboard, this ID is also available in the URL for the submission page in the dashboard.</span></span>  |


### <a name="request-body"></a><span data-ttu-id="cba30-145">要求本文</span><span class="sxs-lookup"><span data-stu-id="cba30-145">Request body</span></span>

<span data-ttu-id="cba30-146">要求本文には次のパラメーターがあります。</span><span class="sxs-lookup"><span data-stu-id="cba30-146">The request body has the following parameters.</span></span>

| <span data-ttu-id="cba30-147">値</span><span class="sxs-lookup"><span data-stu-id="cba30-147">Value</span></span>      | <span data-ttu-id="cba30-148">型</span><span class="sxs-lookup"><span data-stu-id="cba30-148">Type</span></span>   | <span data-ttu-id="cba30-149">説明</span><span class="sxs-lookup"><span data-stu-id="cba30-149">Description</span></span>                                                                                                                                                                                                                                                                         |
|------------|--------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="cba30-150">contentType</span><span class="sxs-lookup"><span data-stu-id="cba30-150">contentType</span></span>           | <span data-ttu-id="cba30-151">string</span><span class="sxs-lookup"><span data-stu-id="cba30-151">string</span></span>  |  <span data-ttu-id="cba30-152">アドオンで提供されている[コンテンツの種類](../publish/enter-add-on-properties.md#content-type)です。</span><span class="sxs-lookup"><span data-stu-id="cba30-152">The [type of content](../publish/enter-add-on-properties.md#content-type) that is provided in the add-on.</span></span> <span data-ttu-id="cba30-153">次のいずれかの値を使用できます。</span><span class="sxs-lookup"><span data-stu-id="cba30-153">This can be one of the following values:</span></span> <ul><li><span data-ttu-id="cba30-154">NotSet</span><span class="sxs-lookup"><span data-stu-id="cba30-154">NotSet</span></span></li><li><span data-ttu-id="cba30-155">BookDownload</span><span class="sxs-lookup"><span data-stu-id="cba30-155">BookDownload</span></span></li><li><span data-ttu-id="cba30-156">EMagazine</span><span class="sxs-lookup"><span data-stu-id="cba30-156">EMagazine</span></span></li><li><span data-ttu-id="cba30-157">ENewspaper</span><span class="sxs-lookup"><span data-stu-id="cba30-157">ENewspaper</span></span></li><li><span data-ttu-id="cba30-158">MusicDownload</span><span class="sxs-lookup"><span data-stu-id="cba30-158">MusicDownload</span></span></li><li><span data-ttu-id="cba30-159">MusicStream</span><span class="sxs-lookup"><span data-stu-id="cba30-159">MusicStream</span></span></li><li><span data-ttu-id="cba30-160">OnlineDataStorage</span><span class="sxs-lookup"><span data-stu-id="cba30-160">OnlineDataStorage</span></span></li><li><span data-ttu-id="cba30-161">VideoDownload</span><span class="sxs-lookup"><span data-stu-id="cba30-161">VideoDownload</span></span></li><li><span data-ttu-id="cba30-162">VideoStream</span><span class="sxs-lookup"><span data-stu-id="cba30-162">VideoStream</span></span></li><li><span data-ttu-id="cba30-163">Asp</span><span class="sxs-lookup"><span data-stu-id="cba30-163">Asp</span></span></li><li><span data-ttu-id="cba30-164">OnlineDownload</span><span class="sxs-lookup"><span data-stu-id="cba30-164">OnlineDownload</span></span></li></ul> |  
| <span data-ttu-id="cba30-165">keywords</span><span class="sxs-lookup"><span data-stu-id="cba30-165">keywords</span></span>           | <span data-ttu-id="cba30-166">array</span><span class="sxs-lookup"><span data-stu-id="cba30-166">array</span></span>  | <span data-ttu-id="cba30-167">アドオンの[キーワード](../publish/enter-add-on-properties.md#keywords)の文字列を最大 10 個含む配列です。</span><span class="sxs-lookup"><span data-stu-id="cba30-167">An array of strings that contain up to 10 [keywords](../publish/enter-add-on-properties.md#keywords) for the add-on.</span></span> <span data-ttu-id="cba30-168">アプリでは、これらのキーワードを使ってアドオンを照会できます。</span><span class="sxs-lookup"><span data-stu-id="cba30-168">Your app can query for add-ons using these keywords.</span></span>   |
| <span data-ttu-id="cba30-169">lifetime</span><span class="sxs-lookup"><span data-stu-id="cba30-169">lifetime</span></span>           | <span data-ttu-id="cba30-170">string</span><span class="sxs-lookup"><span data-stu-id="cba30-170">string</span></span>  |  <span data-ttu-id="cba30-171">アドオンの有効期間です。</span><span class="sxs-lookup"><span data-stu-id="cba30-171">The lifetime of the add-on.</span></span> <span data-ttu-id="cba30-172">次のいずれかの値を使用できます。</span><span class="sxs-lookup"><span data-stu-id="cba30-172">This can be one of the following values:</span></span> <ul><li><span data-ttu-id="cba30-173">Forever</span><span class="sxs-lookup"><span data-stu-id="cba30-173">Forever</span></span></li><li><span data-ttu-id="cba30-174">OneDay</span><span class="sxs-lookup"><span data-stu-id="cba30-174">OneDay</span></span></li><li><span data-ttu-id="cba30-175">ThreeDays</span><span class="sxs-lookup"><span data-stu-id="cba30-175">ThreeDays</span></span></li><li><span data-ttu-id="cba30-176">FiveDays</span><span class="sxs-lookup"><span data-stu-id="cba30-176">FiveDays</span></span></li><li><span data-ttu-id="cba30-177">OneWeek</span><span class="sxs-lookup"><span data-stu-id="cba30-177">OneWeek</span></span></li><li><span data-ttu-id="cba30-178">TwoWeeks</span><span class="sxs-lookup"><span data-stu-id="cba30-178">TwoWeeks</span></span></li><li><span data-ttu-id="cba30-179">OneMonth</span><span class="sxs-lookup"><span data-stu-id="cba30-179">OneMonth</span></span></li><li><span data-ttu-id="cba30-180">TwoMonths</span><span class="sxs-lookup"><span data-stu-id="cba30-180">TwoMonths</span></span></li><li><span data-ttu-id="cba30-181">ThreeMonths</span><span class="sxs-lookup"><span data-stu-id="cba30-181">ThreeMonths</span></span></li><li><span data-ttu-id="cba30-182">SixMonths</span><span class="sxs-lookup"><span data-stu-id="cba30-182">SixMonths</span></span></li><li><span data-ttu-id="cba30-183">OneYear</span><span class="sxs-lookup"><span data-stu-id="cba30-183">OneYear</span></span></li></ul> |
| <span data-ttu-id="cba30-184">listings</span><span class="sxs-lookup"><span data-stu-id="cba30-184">listings</span></span>           | <span data-ttu-id="cba30-185">object</span><span class="sxs-lookup"><span data-stu-id="cba30-185">object</span></span>  | <span data-ttu-id="cba30-186">アドオンの表示内容を含むオブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="cba30-186">An object that contains listing info for the add-on.</span></span> <span data-ttu-id="cba30-187">詳しくは、「[表示リソース](manage-add-on-submissions.md#listing-object)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="cba30-187">For more information, see [Listing resource](manage-add-on-submissions.md#listing-object).</span></span>  |
| <span data-ttu-id="cba30-188">pricing</span><span class="sxs-lookup"><span data-stu-id="cba30-188">pricing</span></span>           | <span data-ttu-id="cba30-189">object</span><span class="sxs-lookup"><span data-stu-id="cba30-189">object</span></span>  | <span data-ttu-id="cba30-190">アドオンの価格情報を含むオブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="cba30-190">An object that contains pricing info for the add-on.</span></span> <span data-ttu-id="cba30-191">詳しくは、「[価格リソース](manage-add-on-submissions.md#pricing-object)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="cba30-191">For more information, see [Pricing resource](manage-add-on-submissions.md#pricing-object).</span></span>  |
| <span data-ttu-id="cba30-192">targetPublishMode</span><span class="sxs-lookup"><span data-stu-id="cba30-192">targetPublishMode</span></span>           | <span data-ttu-id="cba30-193">string</span><span class="sxs-lookup"><span data-stu-id="cba30-193">string</span></span>  | <span data-ttu-id="cba30-194">申請の公開モードです。</span><span class="sxs-lookup"><span data-stu-id="cba30-194">The publish mode for the submission.</span></span> <span data-ttu-id="cba30-195">次のいずれかの値を使用できます。</span><span class="sxs-lookup"><span data-stu-id="cba30-195">This can be one of the following values:</span></span> <ul><li><span data-ttu-id="cba30-196">Immediate</span><span class="sxs-lookup"><span data-stu-id="cba30-196">Immediate</span></span></li><li><span data-ttu-id="cba30-197">Manual</span><span class="sxs-lookup"><span data-stu-id="cba30-197">Manual</span></span></li><li><span data-ttu-id="cba30-198">SpecificDate</span><span class="sxs-lookup"><span data-stu-id="cba30-198">SpecificDate</span></span></li></ul> |
| <span data-ttu-id="cba30-199">targetPublishDate</span><span class="sxs-lookup"><span data-stu-id="cba30-199">targetPublishDate</span></span>           | <span data-ttu-id="cba30-200">string</span><span class="sxs-lookup"><span data-stu-id="cba30-200">string</span></span>  | <span data-ttu-id="cba30-201">*targetPublishMode* が SpecificDate に設定されている場合、ISO 8601 形式での申請の公開日です。</span><span class="sxs-lookup"><span data-stu-id="cba30-201">The publish date for the submission in ISO 8601 format, if the *targetPublishMode* is set to SpecificDate.</span></span>  |
| <span data-ttu-id="cba30-202">tag</span><span class="sxs-lookup"><span data-stu-id="cba30-202">tag</span></span>           | <span data-ttu-id="cba30-203">string</span><span class="sxs-lookup"><span data-stu-id="cba30-203">string</span></span>  |  <span data-ttu-id="cba30-204">アドオンの[カスタムの開発者データ](../publish/enter-add-on-properties.md#custom-developer-data)(この情報は従来*タグ*と呼ばれていました)。</span><span class="sxs-lookup"><span data-stu-id="cba30-204">The [custom developer data](../publish/enter-add-on-properties.md#custom-developer-data) for the add-on (this information was previously called the *tag*).</span></span>   |
| <span data-ttu-id="cba30-205">visibility</span><span class="sxs-lookup"><span data-stu-id="cba30-205">visibility</span></span>  | <span data-ttu-id="cba30-206">string</span><span class="sxs-lookup"><span data-stu-id="cba30-206">string</span></span>  |  <span data-ttu-id="cba30-207">アドオンの可視性です。</span><span class="sxs-lookup"><span data-stu-id="cba30-207">The visibility of the add-on.</span></span> <span data-ttu-id="cba30-208">次のいずれかの値を使用できます。</span><span class="sxs-lookup"><span data-stu-id="cba30-208">This can be one of the following values:</span></span> <ul><li><span data-ttu-id="cba30-209">Hidden</span><span class="sxs-lookup"><span data-stu-id="cba30-209">Hidden</span></span></li><li><span data-ttu-id="cba30-210">Public</span><span class="sxs-lookup"><span data-stu-id="cba30-210">Public</span></span></li><li><span data-ttu-id="cba30-211">Private</span><span class="sxs-lookup"><span data-stu-id="cba30-211">Private</span></span></li><li><span data-ttu-id="cba30-212">NotSet</span><span class="sxs-lookup"><span data-stu-id="cba30-212">NotSet</span></span></li></ul>  |


### <a name="request-example"></a><span data-ttu-id="cba30-213">要求の例</span><span class="sxs-lookup"><span data-stu-id="cba30-213">Request example</span></span>

<span data-ttu-id="cba30-214">次の例は、アドオンの申請を更新する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="cba30-214">The following example demonstrates how to update an add-on submission.</span></span>

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

## <a name="response"></a><span data-ttu-id="cba30-215">応答</span><span class="sxs-lookup"><span data-stu-id="cba30-215">Response</span></span>

<span data-ttu-id="cba30-216">次の例は、このメソッドが正常に呼び出された場合の JSON 応答本文を示しています。</span><span class="sxs-lookup"><span data-stu-id="cba30-216">The following example demonstrates the JSON response body for a successful call to this method.</span></span> <span data-ttu-id="cba30-217">応答本文には、更新された申請に関する情報が含まれています。</span><span class="sxs-lookup"><span data-stu-id="cba30-217">The response body contains information about the updated submission.</span></span> <span data-ttu-id="cba30-218">応答本文内の値について詳しくは、「[アドオンの申請のリソース](manage-add-on-submissions.md#add-on-submission-object)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="cba30-218">For more details about the values in the response body, see [Add-on submission resource](manage-add-on-submissions.md#add-on-submission-object).</span></span>

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

## <a name="error-codes"></a><span data-ttu-id="cba30-219">エラー コード</span><span class="sxs-lookup"><span data-stu-id="cba30-219">Error codes</span></span>

<span data-ttu-id="cba30-220">要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。</span><span class="sxs-lookup"><span data-stu-id="cba30-220">If the request cannot be successfully completed, the response will contain one of the following HTTP error codes.</span></span>

| <span data-ttu-id="cba30-221">エラー コード</span><span class="sxs-lookup"><span data-stu-id="cba30-221">Error code</span></span> |  <span data-ttu-id="cba30-222">説明</span><span class="sxs-lookup"><span data-stu-id="cba30-222">Description</span></span>   |
|--------|------------------|
| <span data-ttu-id="cba30-223">400</span><span class="sxs-lookup"><span data-stu-id="cba30-223">400</span></span>  | <span data-ttu-id="cba30-224">要求が無効なため、申請を更新できませんでした。</span><span class="sxs-lookup"><span data-stu-id="cba30-224">The submission could not be updated because the request is invalid.</span></span> |
| <span data-ttu-id="cba30-225">409</span><span class="sxs-lookup"><span data-stu-id="cba30-225">409</span></span>  | <span data-ttu-id="cba30-226">アドオンの現在の状態が原因で申請を更新できませんでした。または、[Microsoft Store 申請 API で現在サポートされていない](create-and-manage-submissions-using-windows-store-services.md#not_supported)デベロッパー センター ダッシュボード機能がアドオンで使用されています。</span><span class="sxs-lookup"><span data-stu-id="cba30-226">The submission could not be updated because of the current state of the add-on, or the add-on uses a Dev Center dashboard feature that is [currently not supported by the Microsoft Store submission API](create-and-manage-submissions-using-windows-store-services.md#not_supported).</span></span> |   


## <a name="related-topics"></a><span data-ttu-id="cba30-227">関連トピック</span><span class="sxs-lookup"><span data-stu-id="cba30-227">Related topics</span></span>

* [<span data-ttu-id="cba30-228">Microsoft Store サービスを使用した申請の作成と管理</span><span class="sxs-lookup"><span data-stu-id="cba30-228">Create and manage submissions using Microsoft Store services</span></span>](create-and-manage-submissions-using-windows-store-services.md)
* [<span data-ttu-id="cba30-229">アドオンの申請の管理</span><span class="sxs-lookup"><span data-stu-id="cba30-229">Manage add-on submissions</span></span>](manage-add-on-submissions.md)
* [<span data-ttu-id="cba30-230">アドオンの申請の取得</span><span class="sxs-lookup"><span data-stu-id="cba30-230">Get an add-on submission</span></span>](get-an-add-on-submission.md)
* [<span data-ttu-id="cba30-231">アドオンの申請の作成</span><span class="sxs-lookup"><span data-stu-id="cba30-231">Create an add-on submission</span></span>](create-an-add-on-submission.md)
* [<span data-ttu-id="cba30-232">アドオンの申請のコミット</span><span class="sxs-lookup"><span data-stu-id="cba30-232">Commit an add-on submission</span></span>](commit-an-add-on-submission.md)
* [<span data-ttu-id="cba30-233">アドオンの申請の削除</span><span class="sxs-lookup"><span data-stu-id="cba30-233">Delete an add-on submission</span></span>](delete-an-add-on-submission.md)
* [<span data-ttu-id="cba30-234">アドオンの申請の状態の取得</span><span class="sxs-lookup"><span data-stu-id="cba30-234">Get the status of an add-on submission</span></span>](get-status-for-an-add-on-submission.md)
