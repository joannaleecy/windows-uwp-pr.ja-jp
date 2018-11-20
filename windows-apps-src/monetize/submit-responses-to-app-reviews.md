---
author: Xansky
ms.assetid: 038903d6-efab-4da6-96b5-046c7431e6e7
description: アプリのレビューに返信を送るには、Microsoft Store レビュー API の以下のメソッドを使います。
title: レビューに対する返信の送信
ms.author: mhopkins
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, Store サービス, Microsoft Store レビュー API, アドオンの入手数
ms.localizationpriority: medium
ms.openlocfilehash: 8a8a336d477e7d66222632821f0fa0855faae6f7
ms.sourcegitcommit: cbe7cf620622a5e4df7414f9e38dfecec1cfca99
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/20/2018
ms.locfileid: "7420849"
---
# <a name="submit-responses-to-reviews"></a><span data-ttu-id="b5686-104">レビューに対する返信の送信</span><span class="sxs-lookup"><span data-stu-id="b5686-104">Submit responses to reviews</span></span>


<span data-ttu-id="b5686-105">アプリのレビューにプログラムで返信するには、Microsoft Store レビュー API の以下のメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="b5686-105">Use this method in the Microsoft Store reviews API to programmatically respond to reviews of your app.</span></span> <span data-ttu-id="b5686-106">このメソッドを呼び出すときは、返信するレビューの ID を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b5686-106">When you call this method, you must specify the IDs of the reviews you want to respond to.</span></span> <span data-ttu-id="b5686-107">レビュー ID は、Microsoft Store 分析 API の[アプリのレビューの取得](get-app-reviews.md)メソッドの応答データ、および[レビュー レポート](../publish/reviews-report.md)の[オフライン ダウンロード](../publish/download-analytic-reports.md)で取得できます。</span><span class="sxs-lookup"><span data-stu-id="b5686-107">Review IDs are available in the response data of the [get app reviews](get-app-reviews.md) method in the Microsoft Store analytics API and in the [offline download](../publish/download-analytic-reports.md) of the [Reviews report](../publish/reviews-report.md).</span></span>

<span data-ttu-id="b5686-108">顧客はレビューを送信するときに、レビューへの返信を受け取らないことを選択できます。</span><span class="sxs-lookup"><span data-stu-id="b5686-108">When a customer submits a review, they can choose not to receive responses to their review.</span></span> <span data-ttu-id="b5686-109">顧客が返信を受け取らないように指定しているレビューに返信すると、このメソッドの返信の本文には、返信ができなかったことが示されます。</span><span class="sxs-lookup"><span data-stu-id="b5686-109">If you try to respond to a review for which the customer chose not to receive responses, the response body of this method will indicate that the response attempt was unsuccessful.</span></span> <span data-ttu-id="b5686-110">このメソッドを呼び出す前に、任意で、[アプリのレビューへの返信情報の取得](get-response-info-for-app-reviews.md)メソッドを使用して、特定のレビューへの返信が許可されているかどうかを確認できます。</span><span class="sxs-lookup"><span data-stu-id="b5686-110">Before calling this method, you can optionally determine whether you are allowed to respond to a given review by using the [get response info for app reviews](get-response-info-for-app-reviews.md) method.</span></span>

> [!NOTE]
> <span data-ttu-id="b5686-111">プログラムでレビューに返信するには、このメソッドを使って、返信できます返信することもレビューを[パートナー センターを使用](../publish/respond-to-customer-reviews.md)します。</span><span class="sxs-lookup"><span data-stu-id="b5686-111">In addition to using this method to programmatically respond to reviews, you can alternatively respond to reviews [using Partner Center](../publish/respond-to-customer-reviews.md).</span></span>

## <a name="prerequisites"></a><span data-ttu-id="b5686-112">前提条件</span><span class="sxs-lookup"><span data-stu-id="b5686-112">Prerequisites</span></span>

<span data-ttu-id="b5686-113">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="b5686-113">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="b5686-114">Microsoft Store レビュー API に関するすべての[前提条件](respond-to-reviews-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="b5686-114">If you have not done so already, complete all the [prerequisites](respond-to-reviews-using-windows-store-services.md#prerequisites) for the Microsoft Store reviews API.</span></span>
* <span data-ttu-id="b5686-115">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](respond-to-reviews-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="b5686-115">[Obtain an Azure AD access token](respond-to-reviews-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="b5686-116">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="b5686-116">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="b5686-117">トークンの有効期限が切れたら、新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="b5686-117">After the token expires, you can obtain a new one.</span></span>
* <span data-ttu-id="b5686-118">返信するレビューの ID を取得します。</span><span class="sxs-lookup"><span data-stu-id="b5686-118">Get the IDs of the reviews you want to respond to.</span></span> <span data-ttu-id="b5686-119">レビュー ID は、Microsoft Store 分析 API の[アプリのレビューの取得](get-app-reviews.md)メソッドの応答データ、および[レビュー レポート](../publish/reviews-report.md)の[オフライン ダウンロード](../publish/download-analytic-reports.md)で取得できます。</span><span class="sxs-lookup"><span data-stu-id="b5686-119">Review IDs are available in the response data of the [get app reviews](get-app-reviews.md) method in the Microsoft Store analytics API and in the [offline download](../publish/download-analytic-reports.md) of the [Reviews report](../publish/reviews-report.md).</span></span>

## <a name="request"></a><span data-ttu-id="b5686-120">要求</span><span class="sxs-lookup"><span data-stu-id="b5686-120">Request</span></span>

### <a name="request-syntax"></a><span data-ttu-id="b5686-121">要求の構文</span><span class="sxs-lookup"><span data-stu-id="b5686-121">Request syntax</span></span>

| <span data-ttu-id="b5686-122">メソッド</span><span class="sxs-lookup"><span data-stu-id="b5686-122">Method</span></span> | <span data-ttu-id="b5686-123">要求 URI</span><span class="sxs-lookup"><span data-stu-id="b5686-123">Request URI</span></span>                                                      |
|--------|------------------------------------------------------------------|
| <span data-ttu-id="b5686-124">POST</span><span class="sxs-lookup"><span data-stu-id="b5686-124">POST</span></span>    | ```https://manage.devcenter.microsoft.com/v1.0/my/reviews/responses``` |


### <a name="request-header"></a><span data-ttu-id="b5686-125">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="b5686-125">Request header</span></span>

| <span data-ttu-id="b5686-126">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="b5686-126">Header</span></span>        | <span data-ttu-id="b5686-127">型</span><span class="sxs-lookup"><span data-stu-id="b5686-127">Type</span></span>   | <span data-ttu-id="b5686-128">説明</span><span class="sxs-lookup"><span data-stu-id="b5686-128">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="b5686-129">Authorization</span><span class="sxs-lookup"><span data-stu-id="b5686-129">Authorization</span></span> | <span data-ttu-id="b5686-130">string</span><span class="sxs-lookup"><span data-stu-id="b5686-130">string</span></span> | <span data-ttu-id="b5686-131">必須。</span><span class="sxs-lookup"><span data-stu-id="b5686-131">Required.</span></span> <span data-ttu-id="b5686-132">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="b5686-132">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="b5686-133">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="b5686-133">Request parameters</span></span>

<span data-ttu-id="b5686-134">このメソッドには要求パラメーターはありません。</span><span class="sxs-lookup"><span data-stu-id="b5686-134">This method has no request parameters.</span></span>


### <a name="request-body"></a><span data-ttu-id="b5686-135">要求本文</span><span class="sxs-lookup"><span data-stu-id="b5686-135">Request body</span></span>

<span data-ttu-id="b5686-136">要求本文には次の値が含まれます。</span><span class="sxs-lookup"><span data-stu-id="b5686-136">The request body has the following values.</span></span>

| <span data-ttu-id="b5686-137">値</span><span class="sxs-lookup"><span data-stu-id="b5686-137">Value</span></span>        | <span data-ttu-id="b5686-138">型</span><span class="sxs-lookup"><span data-stu-id="b5686-138">Type</span></span>   | <span data-ttu-id="b5686-139">説明</span><span class="sxs-lookup"><span data-stu-id="b5686-139">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------|
| <span data-ttu-id="b5686-140">Responses</span><span class="sxs-lookup"><span data-stu-id="b5686-140">Responses</span></span> | <span data-ttu-id="b5686-141">array</span><span class="sxs-lookup"><span data-stu-id="b5686-141">array</span></span> | <span data-ttu-id="b5686-142">提出する返信を含むオブジェクトの配列です。</span><span class="sxs-lookup"><span data-stu-id="b5686-142">An array of objects that contain the response data you want to submit.</span></span> <span data-ttu-id="b5686-143">各オブジェクトのデータの詳細については、以下の表を参照してください。</span><span class="sxs-lookup"><span data-stu-id="b5686-143">For more information about the data in each object, see the following table.</span></span> |


<span data-ttu-id="b5686-144">*Responses* 配列内の各オブジェクトには、次の値が保持されています。</span><span class="sxs-lookup"><span data-stu-id="b5686-144">Each object in the *Responses* array contains the following values.</span></span>

| <span data-ttu-id="b5686-145">値</span><span class="sxs-lookup"><span data-stu-id="b5686-145">Value</span></span>        | <span data-ttu-id="b5686-146">型</span><span class="sxs-lookup"><span data-stu-id="b5686-146">Type</span></span>   | <span data-ttu-id="b5686-147">説明</span><span class="sxs-lookup"><span data-stu-id="b5686-147">Description</span></span>           |  <span data-ttu-id="b5686-148">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="b5686-148">Required</span></span>  |
|---------------|--------|-----------------------------|-----|
| <span data-ttu-id="b5686-149">ApplicationId</span><span class="sxs-lookup"><span data-stu-id="b5686-149">ApplicationId</span></span> | <span data-ttu-id="b5686-150">string</span><span class="sxs-lookup"><span data-stu-id="b5686-150">string</span></span> |  <span data-ttu-id="b5686-151">返信対象のレビューがあるアプリのストア ID です。</span><span class="sxs-lookup"><span data-stu-id="b5686-151">The Store ID of the app with the review you want to respond to.</span></span> <span data-ttu-id="b5686-152">ストア ID は、パートナー センターの[アプリ id] ページ](../publish/view-app-identity-details.md)で利用できます。</span><span class="sxs-lookup"><span data-stu-id="b5686-152">The Store ID is available on the [App identity page](../publish/view-app-identity-details.md) of Partner Center.</span></span> <span data-ttu-id="b5686-153">ストア ID は、たとえば 9WZDNCRFJ3Q8 のような文字列です。</span><span class="sxs-lookup"><span data-stu-id="b5686-153">An example Store ID is 9WZDNCRFJ3Q8.</span></span>   |  <span data-ttu-id="b5686-154">○</span><span class="sxs-lookup"><span data-stu-id="b5686-154">Yes</span></span>  |
| <span data-ttu-id="b5686-155">ReviewId</span><span class="sxs-lookup"><span data-stu-id="b5686-155">ReviewId</span></span> | <span data-ttu-id="b5686-156">string</span><span class="sxs-lookup"><span data-stu-id="b5686-156">string</span></span> |  <span data-ttu-id="b5686-157">返信するレビューの ID です (これは GUID です)。</span><span class="sxs-lookup"><span data-stu-id="b5686-157">The ID of the review you want to respond to (this is a GUID).</span></span> <span data-ttu-id="b5686-158">レビュー ID は、Microsoft Store 分析 API の[アプリのレビューの取得](get-app-reviews.md)メソッドの応答データ、および[レビュー レポート](../publish/reviews-report.md)の[オフライン ダウンロード](../publish/download-analytic-reports.md)で取得できます。</span><span class="sxs-lookup"><span data-stu-id="b5686-158">Review IDs are available in the response data of the [get app reviews](get-app-reviews.md) method in the Microsoft Store analytics API and in the [offline download](../publish/download-analytic-reports.md) of the [Reviews report](../publish/reviews-report.md).</span></span>   |  <span data-ttu-id="b5686-159">○</span><span class="sxs-lookup"><span data-stu-id="b5686-159">Yes</span></span>  |
| <span data-ttu-id="b5686-160">ResponseText</span><span class="sxs-lookup"><span data-stu-id="b5686-160">ResponseText</span></span> | <span data-ttu-id="b5686-161">string</span><span class="sxs-lookup"><span data-stu-id="b5686-161">string</span></span> | <span data-ttu-id="b5686-162">提出する返信です。</span><span class="sxs-lookup"><span data-stu-id="b5686-162">The response you want to submit.</span></span> <span data-ttu-id="b5686-163">返信は、[こちらのガイドライン](../publish/respond-to-customer-reviews.md#guidelines-for-responses)に従う必要があります。</span><span class="sxs-lookup"><span data-stu-id="b5686-163">Your response must follow [these guidelines](../publish/respond-to-customer-reviews.md#guidelines-for-responses).</span></span>   |  <span data-ttu-id="b5686-164">○</span><span class="sxs-lookup"><span data-stu-id="b5686-164">Yes</span></span>  |
| <span data-ttu-id="b5686-165">SupportEmail</span><span class="sxs-lookup"><span data-stu-id="b5686-165">SupportEmail</span></span> | <span data-ttu-id="b5686-166">string</span><span class="sxs-lookup"><span data-stu-id="b5686-166">string</span></span> | <span data-ttu-id="b5686-167">アプリのサポート メール アドレスです。顧客はこのアドレスを使用して、直接連絡できます。</span><span class="sxs-lookup"><span data-stu-id="b5686-167">Your app's support email address, which the customer can use to contact you directly.</span></span> <span data-ttu-id="b5686-168">したがって、有効なメール アドレスである必要があります。</span><span class="sxs-lookup"><span data-stu-id="b5686-168">This must be a valid email address.</span></span>     |  <span data-ttu-id="b5686-169">○</span><span class="sxs-lookup"><span data-stu-id="b5686-169">Yes</span></span>  |
| <span data-ttu-id="b5686-170">IsPublic</span><span class="sxs-lookup"><span data-stu-id="b5686-170">IsPublic</span></span> | <span data-ttu-id="b5686-171">Boolean</span><span class="sxs-lookup"><span data-stu-id="b5686-171">Boolean</span></span> |  <span data-ttu-id="b5686-172">**True**を指定する場合、返信は、アプリのストア登録情報、顧客のレビューのすぐ下に表示され、すべてのユーザーに表示されます。</span><span class="sxs-lookup"><span data-stu-id="b5686-172">If you specify **true**, your response will be displayed in your app's Store listing, directly below the customer's review, and will be visible to all customers.</span></span> <span data-ttu-id="b5686-173">**False**と、ユーザーがメールへの返信オプトアウトしていないを指定する場合、返信はメールで顧客に送信され、アプリのストア登録情報内の他のユーザーに表示されません。</span><span class="sxs-lookup"><span data-stu-id="b5686-173">If you specify **false** and the user hasn't opted out of receiving email responses, your response will be sent to the customer via email, and it will not be visible to other customers in your app's Store listing.</span></span> <span data-ttu-id="b5686-174">メールへの返信**false**と、ユーザーが選択されている、指定した場合は、エラーが返されます。</span><span class="sxs-lookup"><span data-stu-id="b5686-174">If you specify **false** and the user has opted out of receiving email responses, an error will be returned.</span></span>   |  <span data-ttu-id="b5686-175">はい</span><span class="sxs-lookup"><span data-stu-id="b5686-175">Yes</span></span>  |


### <a name="request-example"></a><span data-ttu-id="b5686-176">要求の例</span><span class="sxs-lookup"><span data-stu-id="b5686-176">Request example</span></span>

<span data-ttu-id="b5686-177">次の例は、このメソッドを使用して、いくつかのレビューに返信を提出する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="b5686-177">The following example demonstrates how to use this method to submit responses to several reviews.</span></span>

```json
POST https://manage.devcenter.microsoft.com/v1.0/my/reviews/responses HTTP/1.1
Authorization: Bearer <your access token>
Content-Type: application/json
{
  "Responses": [
    {
      "ApplicationId": "9WZDNCRFJ3Q8",
      "ReviewId": "6be543ff-1c9c-4534-aced-af8b4fbe0316",
      "ResponseText": "Thank you for pointing out this bug. I fixed it and published an update, you should have the fix soon",
      "SupportEmail": "support@contoso.com",
      "IsPublic": "true"
    },
    {
      "ApplicationId": "9NBLGGH1RP08",
      "ReviewId": "80c9671a-96c2-4278-bcbc-be0ce5a32a7c",
      "ResponseText": "Thank you for submitting your review. Can you tell more about what you were doing in the app when it froze? Thanks very much for your help.",
      "SupportEmail": "support@contoso.com",
      "IsPublic": "false"
    }
  ]
}
```

## <a name="response"></a><span data-ttu-id="b5686-178">返信</span><span class="sxs-lookup"><span data-stu-id="b5686-178">Response</span></span>

### <a name="response-body"></a><span data-ttu-id="b5686-179">応答本文</span><span class="sxs-lookup"><span data-stu-id="b5686-179">Response body</span></span>

| <span data-ttu-id="b5686-180">値</span><span class="sxs-lookup"><span data-stu-id="b5686-180">Value</span></span>        | <span data-ttu-id="b5686-181">型</span><span class="sxs-lookup"><span data-stu-id="b5686-181">Type</span></span>   | <span data-ttu-id="b5686-182">説明</span><span class="sxs-lookup"><span data-stu-id="b5686-182">Description</span></span>            |
|---------------|--------|---------------------|
| <span data-ttu-id="b5686-183">Result</span><span class="sxs-lookup"><span data-stu-id="b5686-183">Result</span></span> | <span data-ttu-id="b5686-184">array</span><span class="sxs-lookup"><span data-stu-id="b5686-184">array</span></span> | <span data-ttu-id="b5686-185">提出した各返信についてのデータを保持するオブジェクトの配列です。</span><span class="sxs-lookup"><span data-stu-id="b5686-185">An array of objects that contain data about each response you submitted.</span></span> <span data-ttu-id="b5686-186">各オブジェクトのデータの詳細については、以下の表を参照してください。</span><span class="sxs-lookup"><span data-stu-id="b5686-186">For more information about the data in each object, see the following table.</span></span>  |


<span data-ttu-id="b5686-187">*Result* 配列内の各オブジェクトには、次の値が保持されています。</span><span class="sxs-lookup"><span data-stu-id="b5686-187">Each object in the *Result* array contains the following values.</span></span>

| <span data-ttu-id="b5686-188">値</span><span class="sxs-lookup"><span data-stu-id="b5686-188">Value</span></span>        | <span data-ttu-id="b5686-189">型</span><span class="sxs-lookup"><span data-stu-id="b5686-189">Type</span></span>   | <span data-ttu-id="b5686-190">説明</span><span class="sxs-lookup"><span data-stu-id="b5686-190">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------|
| <span data-ttu-id="b5686-191">ApplicationId</span><span class="sxs-lookup"><span data-stu-id="b5686-191">ApplicationId</span></span> | <span data-ttu-id="b5686-192">string</span><span class="sxs-lookup"><span data-stu-id="b5686-192">string</span></span> |  <span data-ttu-id="b5686-193">返信対象のレビューがあるアプリのストア ID です。</span><span class="sxs-lookup"><span data-stu-id="b5686-193">The Store ID of the app with the review you responded to.</span></span> <span data-ttu-id="b5686-194">ストア ID は、たとえば 9WZDNCRFJ3Q8 のような文字列です。</span><span class="sxs-lookup"><span data-stu-id="b5686-194">An example Store ID is 9WZDNCRFJ3Q8.</span></span>   |
| <span data-ttu-id="b5686-195">ReviewId</span><span class="sxs-lookup"><span data-stu-id="b5686-195">ReviewId</span></span> | <span data-ttu-id="b5686-196">string</span><span class="sxs-lookup"><span data-stu-id="b5686-196">string</span></span> |  <span data-ttu-id="b5686-197">返信するレビューの ID です。</span><span class="sxs-lookup"><span data-stu-id="b5686-197">The ID of the review you responded to.</span></span> <span data-ttu-id="b5686-198">これは GUID です。</span><span class="sxs-lookup"><span data-stu-id="b5686-198">This is a GUID.</span></span>   |
| <span data-ttu-id="b5686-199">Successful</span><span class="sxs-lookup"><span data-stu-id="b5686-199">Successful</span></span> | <span data-ttu-id="b5686-200">string</span><span class="sxs-lookup"><span data-stu-id="b5686-200">string</span></span> | <span data-ttu-id="b5686-201">値が **true** の場合、返信が正常に送信されたことを示します。</span><span class="sxs-lookup"><span data-stu-id="b5686-201">The value **true** indicates that your response was sent successfully.</span></span> <span data-ttu-id="b5686-202">値が **false** の場合、返信は提出できなかったことを示します。</span><span class="sxs-lookup"><span data-stu-id="b5686-202">The value **false** indicates that your response was unsuccessful.</span></span>    |
| <span data-ttu-id="b5686-203">FailureReason</span><span class="sxs-lookup"><span data-stu-id="b5686-203">FailureReason</span></span> | <span data-ttu-id="b5686-204">string</span><span class="sxs-lookup"><span data-stu-id="b5686-204">string</span></span> | <span data-ttu-id="b5686-205">**Successful** が **false** の場合、この値には失敗の理由が含まれます。</span><span class="sxs-lookup"><span data-stu-id="b5686-205">If **Successful** is **false**, this value contains a reason for the failure.</span></span> <span data-ttu-id="b5686-206">**Successful** が **true** の場合、この値は空です。</span><span class="sxs-lookup"><span data-stu-id="b5686-206">If **Successful** is **true**, this value is empty.</span></span>      |


### <a name="response-example"></a><span data-ttu-id="b5686-207">返信の例</span><span class="sxs-lookup"><span data-stu-id="b5686-207">Response example</span></span>

<span data-ttu-id="b5686-208">この要求の JSON 応答の本文の例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="b5686-208">The following example demonstrates an example JSON response body for this request.</span></span>

```json
{
  "Result": [
    {
      "ApplicationId": "9WZDNCRFJ3Q8",
      "ReviewId": "6be543ff-1c9c-4534-aced-af8b4fbe0316",
      "Successful": "true",
      "FailureReason": ""
    },
    {
      "ApplicationId": "9NBLGGH1RP08",
      "ReviewId": "80c9671a-96c2-4278-bcbc-be0ce5a32a7c",
      "Successful": "false",
      "FailureReason": "No Permission"
    }
  ]
}
```

## <a name="related-topics"></a><span data-ttu-id="b5686-209">関連トピック</span><span class="sxs-lookup"><span data-stu-id="b5686-209">Related topics</span></span>

* [<span data-ttu-id="b5686-210">パートナー センターを使用して顧客のレビューに返信するには</span><span class="sxs-lookup"><span data-stu-id="b5686-210">Respond to customer reviews using Partner Center</span></span>](../publish/respond-to-customer-reviews.md)
* [<span data-ttu-id="b5686-211">Microsoft Store サービスを使ってレビューに返信する</span><span class="sxs-lookup"><span data-stu-id="b5686-211">Respond to reviews using Microsoft Store services</span></span>](respond-to-reviews-using-windows-store-services.md)
* [<span data-ttu-id="b5686-212">アプリのレビューへの返信情報の取得</span><span class="sxs-lookup"><span data-stu-id="b5686-212">Get response info for app reviews</span></span>](get-response-info-for-app-reviews.md)
* [<span data-ttu-id="b5686-213">アプリのレビューの取得</span><span class="sxs-lookup"><span data-stu-id="b5686-213">Get app reviews</span></span>](get-app-reviews.md)
