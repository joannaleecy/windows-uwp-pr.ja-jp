---
ms.assetid: fb6bb856-7a1b-4312-a602-f500646a3119
description: 特定のレビューに返信できるかどうかを判断したり、特定のアプリに関するいずれかのレビューに返信できるかどうかを判断したりするには、Microsoft Store レビュー API の以下のメソッドを使います。
title: レビューへの返信情報の取得
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, Store サービス, Microsoft Store レビュー API, 返信情報
ms.localizationpriority: medium
ms.openlocfilehash: 095afd1eab9b7bd0acdac7c38d9e8e99dd59f38c
ms.sourcegitcommit: fca0132794ec187e90b2ebdad862f22d9f6c0db8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/24/2019
ms.locfileid: "63785760"
---
# <a name="get-response-info-for-reviews"></a><span data-ttu-id="f1847-104">レビューへの返信情報の取得</span><span class="sxs-lookup"><span data-stu-id="f1847-104">Get response info for reviews</span></span>

<span data-ttu-id="f1847-105">アプリのユーザー レビューにプログラムで返信する場合は、Microsoft Store レビュー API の以下のメソッドを使って、まずレビューに返信する権限があるかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="f1847-105">If you want to programmatically respond to a customer review of your app, you can use this method in the Microsoft Store reviews API to first determine whether you have permission to respond to the review.</span></span> <span data-ttu-id="f1847-106">レビューの返信を受け取らないことを選択している顧客が送信したレビューに返信することはできません。</span><span class="sxs-lookup"><span data-stu-id="f1847-106">You cannot respond to reviews submitted by customers who have chosen not to receive review responses.</span></span> <span data-ttu-id="f1847-107">レビューに返信できることを確認した後、[アプリのレビューに返信を送信する](submit-responses-to-app-reviews.md)メソッドを使って、プログラムでレビューに返信します。</span><span class="sxs-lookup"><span data-stu-id="f1847-107">After you confirm that you can respond to the review, you can then use the [submit responses to app reviews](submit-responses-to-app-reviews.md) method to programmatically respond to it.</span></span>


## <a name="prerequisites"></a><span data-ttu-id="f1847-108">前提条件</span><span class="sxs-lookup"><span data-stu-id="f1847-108">Prerequisites</span></span>

<span data-ttu-id="f1847-109">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="f1847-109">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="f1847-110">Microsoft Store 分析 API に関するすべての[前提条件](respond-to-reviews-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="f1847-110">If you have not done so already, complete all the [prerequisites](respond-to-reviews-using-windows-store-services.md#prerequisites) for the Microsoft Store analytics API.</span></span>
* <span data-ttu-id="f1847-111">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](respond-to-reviews-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="f1847-111">[Obtain an Azure AD access token](respond-to-reviews-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="f1847-112">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="f1847-112">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="f1847-113">トークンの有効期限が切れたら新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="f1847-113">After the token expires, you can obtain a new one.</span></span>
* <span data-ttu-id="f1847-114">返信できるかどうかを確認するために、対象となるレビューの ID を取得します。</span><span class="sxs-lookup"><span data-stu-id="f1847-114">Get the ID of the review you want to check to determine whether you can respond to it.</span></span> <span data-ttu-id="f1847-115">レビュー ID は、Microsoft Store 分析 API の[アプリのレビューの取得](get-app-reviews.md)メソッドの応答データ、および[レビュー レポート](../publish/reviews-report.md)の[オフライン ダウンロード](../publish/download-analytic-reports.md)で取得できます。</span><span class="sxs-lookup"><span data-stu-id="f1847-115">Review IDs are available in the response data of the [get app reviews](get-app-reviews.md) method in the Microsoft Store analytics API and in the [offline download](../publish/download-analytic-reports.md) of the [Reviews report](../publish/reviews-report.md).</span></span>

## <a name="request"></a><span data-ttu-id="f1847-116">要求</span><span class="sxs-lookup"><span data-stu-id="f1847-116">Request</span></span>


### <a name="request-syntax"></a><span data-ttu-id="f1847-117">要求の構文</span><span class="sxs-lookup"><span data-stu-id="f1847-117">Request syntax</span></span>

| <span data-ttu-id="f1847-118">メソッド</span><span class="sxs-lookup"><span data-stu-id="f1847-118">Method</span></span> | <span data-ttu-id="f1847-119">要求 URI</span><span class="sxs-lookup"><span data-stu-id="f1847-119">Request URI</span></span>                                                      |
|--------|------------------------------------------------------------------|
| <span data-ttu-id="f1847-120">GET</span><span class="sxs-lookup"><span data-stu-id="f1847-120">GET</span></span>    | ```https://manage.devcenter.microsoft.com/v1.0/my/reviews/{reviewId}/apps/{applicationId}/responses/info``` |


### <a name="request-header"></a><span data-ttu-id="f1847-121">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="f1847-121">Request header</span></span>

| <span data-ttu-id="f1847-122">Header</span><span class="sxs-lookup"><span data-stu-id="f1847-122">Header</span></span>        | <span data-ttu-id="f1847-123">種類</span><span class="sxs-lookup"><span data-stu-id="f1847-123">Type</span></span>   | <span data-ttu-id="f1847-124">説明</span><span class="sxs-lookup"><span data-stu-id="f1847-124">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="f1847-125">Authorization</span><span class="sxs-lookup"><span data-stu-id="f1847-125">Authorization</span></span> | <span data-ttu-id="f1847-126">string</span><span class="sxs-lookup"><span data-stu-id="f1847-126">string</span></span> | <span data-ttu-id="f1847-127">必須。</span><span class="sxs-lookup"><span data-stu-id="f1847-127">Required.</span></span> <span data-ttu-id="f1847-128">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="f1847-128">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="f1847-129">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="f1847-129">Request parameters</span></span>

| <span data-ttu-id="f1847-130">パラメーター</span><span class="sxs-lookup"><span data-stu-id="f1847-130">Parameter</span></span>        | <span data-ttu-id="f1847-131">種類</span><span class="sxs-lookup"><span data-stu-id="f1847-131">Type</span></span>   | <span data-ttu-id="f1847-132">説明</span><span class="sxs-lookup"><span data-stu-id="f1847-132">Description</span></span>                                     |  <span data-ttu-id="f1847-133">必須</span><span class="sxs-lookup"><span data-stu-id="f1847-133">Required</span></span>  |
|---------------|--------|--------------------------------------------------|--------------|
| <span data-ttu-id="f1847-134">applicationId</span><span class="sxs-lookup"><span data-stu-id="f1847-134">applicationId</span></span> | <span data-ttu-id="f1847-135">string</span><span class="sxs-lookup"><span data-stu-id="f1847-135">string</span></span> | <span data-ttu-id="f1847-136">返信できるかどうかを確認するレビューを含むアプリのストア ID です。</span><span class="sxs-lookup"><span data-stu-id="f1847-136">The Store ID of the app that contains the review for which you want to determine whether you can respond to.</span></span> <span data-ttu-id="f1847-137">Store ID は、[アプリ id のページ](../publish/view-app-identity-details.md)パートナー センターでします。</span><span class="sxs-lookup"><span data-stu-id="f1847-137">The Store ID is available on the [App identity page](../publish/view-app-identity-details.md) in Partner Center.</span></span> <span data-ttu-id="f1847-138">ストア ID は、たとえば 9WZDNCRFJ3Q8 のような文字列です。</span><span class="sxs-lookup"><span data-stu-id="f1847-138">An example Store ID is 9WZDNCRFJ3Q8.</span></span> |  <span data-ttu-id="f1847-139">〇</span><span class="sxs-lookup"><span data-stu-id="f1847-139">Yes</span></span>  |
| <span data-ttu-id="f1847-140">reviewId</span><span class="sxs-lookup"><span data-stu-id="f1847-140">reviewId</span></span> | <span data-ttu-id="f1847-141">string</span><span class="sxs-lookup"><span data-stu-id="f1847-141">string</span></span> | <span data-ttu-id="f1847-142">返信するレビューの ID です (これは GUID です)。</span><span class="sxs-lookup"><span data-stu-id="f1847-142">The ID of the review you want to respond to (this is a GUID).</span></span> <span data-ttu-id="f1847-143">レビュー ID は、Microsoft Store 分析 API の[アプリのレビューの取得](get-app-reviews.md)メソッドの応答データ、および[レビュー レポート](../publish/reviews-report.md)の[オフライン ダウンロード](../publish/download-analytic-reports.md)で取得できます。</span><span class="sxs-lookup"><span data-stu-id="f1847-143">Review IDs are available in the response data of the [get app reviews](get-app-reviews.md) method in the Microsoft Store analytics API and in the [offline download](../publish/download-analytic-reports.md) of the [Reviews report](../publish/reviews-report.md).</span></span> <br/><span data-ttu-id="f1847-144">このパラメーターを省略すると、このメソッドの応答の本文は、指定されたアプリの任意のレビューに返信する権限があるかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="f1847-144">If you omit this parameter, the response body for this method will indicate whether you have permissions to respond to any reviews for the specified app.</span></span> |  <span data-ttu-id="f1847-145">X</span><span class="sxs-lookup"><span data-stu-id="f1847-145">No</span></span>  |


### <a name="request-example"></a><span data-ttu-id="f1847-146">要求の例</span><span class="sxs-lookup"><span data-stu-id="f1847-146">Request example</span></span>

<span data-ttu-id="f1847-147">次の例では、このメソッドを使って、特定のレビューに返信できるかどうかを判断する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="f1847-147">The following examples how to use this method to determine whether you can respond to a given review.</span></span>

```syntax
GET https://manage.devcenter.microsoft.com/v1.0/my/reviews/6be543ff-1c9c-4534-aced-af8b4fbe0316/apps/9WZDNCRFJ3Q8/responses/info HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="f1847-148">応答</span><span class="sxs-lookup"><span data-stu-id="f1847-148">Response</span></span>


### <a name="response-body"></a><span data-ttu-id="f1847-149">応答本文</span><span class="sxs-lookup"><span data-stu-id="f1847-149">Response body</span></span>

| <span data-ttu-id="f1847-150">Value</span><span class="sxs-lookup"><span data-stu-id="f1847-150">Value</span></span>      | <span data-ttu-id="f1847-151">種類</span><span class="sxs-lookup"><span data-stu-id="f1847-151">Type</span></span>   | <span data-ttu-id="f1847-152">説明</span><span class="sxs-lookup"><span data-stu-id="f1847-152">Description</span></span>    |  
|------------|--------|-----------------------|
| <span data-ttu-id="f1847-153">CanRespond</span><span class="sxs-lookup"><span data-stu-id="f1847-153">CanRespond</span></span>      | <span data-ttu-id="f1847-154">ブール値</span><span class="sxs-lookup"><span data-stu-id="f1847-154">Boolean</span></span>  | <span data-ttu-id="f1847-155">値が **true** の場合は、指定されたレビューに返信できること、または指定されたアプリのすべてのレビューに返信する権限があることを示します。</span><span class="sxs-lookup"><span data-stu-id="f1847-155">The value **true** indicates that you can respond to the specified review, or that you have permissions to respond to any review for the specified app.</span></span> <span data-ttu-id="f1847-156">それ以外の場合、この値は **false** です。</span><span class="sxs-lookup"><span data-stu-id="f1847-156">Otherwise, this value is **false**.</span></span>       |
| <span data-ttu-id="f1847-157">DefaultSupportEmail</span><span class="sxs-lookup"><span data-stu-id="f1847-157">DefaultSupportEmail</span></span>  | <span data-ttu-id="f1847-158">string</span><span class="sxs-lookup"><span data-stu-id="f1847-158">string</span></span> |  <span data-ttu-id="f1847-159">アプリのストア登録情報で指定されているアプリの[サポート メール アドレス](../publish/enter-app-properties.md#support-contact-info)です。</span><span class="sxs-lookup"><span data-stu-id="f1847-159">Your app's [support email address](../publish/enter-app-properties.md#support-contact-info) as specified in your app's Store listing.</span></span> <span data-ttu-id="f1847-160">サポート メール アドレスを指定しなかった場合、このフィールドは空です。</span><span class="sxs-lookup"><span data-stu-id="f1847-160">If you did not specify a support email address, this field is empty.</span></span>    |

 
### <a name="response-example"></a><span data-ttu-id="f1847-161">応答の例</span><span class="sxs-lookup"><span data-stu-id="f1847-161">Response example</span></span>

<span data-ttu-id="f1847-162">この要求の JSON 返信の本文の例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="f1847-162">The following example demonstrates an example JSON response body for this request.</span></span>

```json
{
  "CanRespond": true,
  "DefaultSupportEmail": "support@contoso.com"
}
```

## <a name="related-topics"></a><span data-ttu-id="f1847-163">関連トピック</span><span class="sxs-lookup"><span data-stu-id="f1847-163">Related topics</span></span>

* [<span data-ttu-id="f1847-164">Microsoft Store analytics API を使用してレビューへの応答を送信します。</span><span class="sxs-lookup"><span data-stu-id="f1847-164">Submit responses to reviews using the Microsoft Store analytics API</span></span>](submit-responses-to-app-reviews.md)
* [<span data-ttu-id="f1847-165">パートナー センターを使用して顧客レビューに応答します。</span><span class="sxs-lookup"><span data-stu-id="f1847-165">Respond to customer reviews using Partner Center</span></span>](../publish/respond-to-customer-reviews.md)
* [<span data-ttu-id="f1847-166">Microsoft Store サービスを使用してレビューに応答します。</span><span class="sxs-lookup"><span data-stu-id="f1847-166">Respond to reviews using Microsoft Store services</span></span>](respond-to-reviews-using-windows-store-services.md)
* [<span data-ttu-id="f1847-167">アプリのレビューを取得します。</span><span class="sxs-lookup"><span data-stu-id="f1847-167">Get app reviews</span></span>](get-app-reviews.md)
