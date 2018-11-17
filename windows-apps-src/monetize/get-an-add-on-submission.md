---
author: Xansky
ms.assetid: E3DF5D11-8791-4CFC-8131-4F59B928A228
description: 既存のアドオンの申請に関するデータを取得するには、Microsoft Store 申請 API の以下のメソッドを使います。
title: アドオンの申請の取得
ms.author: mhopkins
ms.date: 04/17/2018
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store 申請 API, アドオンの申請, アプリ内製品, IAP
ms.localizationpriority: medium
ms.openlocfilehash: ad6381562b37b1a759a575e070edd6b1bf63402d
ms.sourcegitcommit: 3257416aebb5a7b1515e107866806f8bd57845a8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/17/2018
ms.locfileid: "7170656"
---
# <a name="get-an-add-on-submission"></a><span data-ttu-id="51987-104">アドオンの申請の取得</span><span class="sxs-lookup"><span data-stu-id="51987-104">Get an add-on submission</span></span>

<span data-ttu-id="51987-105">既存のアドオン (アプリ内製品または IAP とも呼ばれます) の申請に関するデータを取得するには、Microsoft Store 申請 API の以下のメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="51987-105">Use this method in the Microsoft Store submission API to get data for an existing add-on (also known as in-app product or IAP) submission.</span></span> <span data-ttu-id="51987-106">Microsoft Store 申請 API を使ったアドオンの申請の作成プロセスについて詳しくは、「[アドオンの申請の管理](manage-add-on-submissions.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="51987-106">For more information about the process of process of creating an add-on submission by using the Microsoft Store submission API, see [Manage add-on submissions](manage-add-on-submissions.md).</span></span>

## <a name="prerequisites"></a><span data-ttu-id="51987-107">前提条件</span><span class="sxs-lookup"><span data-stu-id="51987-107">Prerequisites</span></span>

<span data-ttu-id="51987-108">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="51987-108">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="51987-109">Microsoft Store 申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="51987-109">If you have not done so already, complete all the [prerequisites](create-and-manage-submissions-using-windows-store-services.md#prerequisites) for the Microsoft Store submission API.</span></span>
* <span data-ttu-id="51987-110">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="51987-110">[Obtain an Azure AD access token](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="51987-111">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="51987-111">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="51987-112">トークンの有効期限が切れたら、新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="51987-112">After the token expires, you can obtain a new one.</span></span>
* <span data-ttu-id="51987-113">アプリのいずれかのアドオンの申請を作成します。</span><span class="sxs-lookup"><span data-stu-id="51987-113">Create an add-on submission for one of your apps.</span></span> <span data-ttu-id="51987-114">[アドオンの申請を作成する](create-an-add-on-submission.md)方法を使用して行うことができますパートナー センターで、これを行うこともできます。</span><span class="sxs-lookup"><span data-stu-id="51987-114">You can do this in Partner Center, or you can do this by using the [Create an add-on submission](create-an-add-on-submission.md) method.</span></span>

## <a name="request"></a><span data-ttu-id="51987-115">要求</span><span class="sxs-lookup"><span data-stu-id="51987-115">Request</span></span>

<span data-ttu-id="51987-116">このメソッドの構文は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="51987-116">This method has the following syntax.</span></span> <span data-ttu-id="51987-117">ヘッダーと要求本文の使用例と説明については、次のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="51987-117">See the following sections for usage examples and descriptions of the header and request body.</span></span>

| <span data-ttu-id="51987-118">メソッド</span><span class="sxs-lookup"><span data-stu-id="51987-118">Method</span></span> | <span data-ttu-id="51987-119">要求 URI</span><span class="sxs-lookup"><span data-stu-id="51987-119">Request URI</span></span>                                                      |
|--------|------------------------------------------------------------------|
| <span data-ttu-id="51987-120">GET</span><span class="sxs-lookup"><span data-stu-id="51987-120">GET</span></span>   | ```https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/{inAppProductId}/submissions/{submissionId} ``` |


### <a name="request-header"></a><span data-ttu-id="51987-121">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="51987-121">Request header</span></span>

| <span data-ttu-id="51987-122">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="51987-122">Header</span></span>        | <span data-ttu-id="51987-123">型</span><span class="sxs-lookup"><span data-stu-id="51987-123">Type</span></span>   | <span data-ttu-id="51987-124">説明</span><span class="sxs-lookup"><span data-stu-id="51987-124">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="51987-125">Authorization</span><span class="sxs-lookup"><span data-stu-id="51987-125">Authorization</span></span> | <span data-ttu-id="51987-126">string</span><span class="sxs-lookup"><span data-stu-id="51987-126">string</span></span> | <span data-ttu-id="51987-127">必須。</span><span class="sxs-lookup"><span data-stu-id="51987-127">Required.</span></span> <span data-ttu-id="51987-128">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="51987-128">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="51987-129">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="51987-129">Request parameters</span></span>

| <span data-ttu-id="51987-130">名前</span><span class="sxs-lookup"><span data-stu-id="51987-130">Name</span></span>        | <span data-ttu-id="51987-131">種類</span><span class="sxs-lookup"><span data-stu-id="51987-131">Type</span></span>   | <span data-ttu-id="51987-132">説明</span><span class="sxs-lookup"><span data-stu-id="51987-132">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="51987-133">inAppProductId</span><span class="sxs-lookup"><span data-stu-id="51987-133">inAppProductId</span></span> | <span data-ttu-id="51987-134">string</span><span class="sxs-lookup"><span data-stu-id="51987-134">string</span></span> | <span data-ttu-id="51987-135">必須。</span><span class="sxs-lookup"><span data-stu-id="51987-135">Required.</span></span> <span data-ttu-id="51987-136">取得する申請が含まれるアドオンのストア ID です。</span><span class="sxs-lookup"><span data-stu-id="51987-136">The Store ID of the add-on that contains the submission you want to get.</span></span> <span data-ttu-id="51987-137">パートナー センターで、ストア ID は利用可能なと[アドオンの作成](create-an-add-on.md)または[アドオンの詳細を取得する](get-all-add-ons.md)要求の応答データに含まれています。</span><span class="sxs-lookup"><span data-stu-id="51987-137">The Store ID is available in Partner Center, and it is included in the response data for requests to [Create an add-on](create-an-add-on.md) or [get add-on details](get-all-add-ons.md).</span></span>  |
| <span data-ttu-id="51987-138">submissionId</span><span class="sxs-lookup"><span data-stu-id="51987-138">submissionId</span></span> | <span data-ttu-id="51987-139">string</span><span class="sxs-lookup"><span data-stu-id="51987-139">string</span></span> | <span data-ttu-id="51987-140">必須。</span><span class="sxs-lookup"><span data-stu-id="51987-140">Required.</span></span> <span data-ttu-id="51987-141">取得する申請の ID です。</span><span class="sxs-lookup"><span data-stu-id="51987-141">The ID of the submission to get.</span></span> <span data-ttu-id="51987-142">この ID は、[アドオンの申請の作成](create-an-add-on-submission.md)要求に対する応答データで確認できます。</span><span class="sxs-lookup"><span data-stu-id="51987-142">This ID is available in the response data for requests to [create an add-on submission](create-an-add-on-submission.md).</span></span> <span data-ttu-id="51987-143">パートナー センターで作成された申請はこの ID はパートナー センターでの申請ページの URL で利用可能なもします。</span><span class="sxs-lookup"><span data-stu-id="51987-143">For a submission that was created in Partner Center, this ID is also available in the URL for the submission page in Partner Center.</span></span>  |


### <a name="request-body"></a><span data-ttu-id="51987-144">要求本文</span><span class="sxs-lookup"><span data-stu-id="51987-144">Request body</span></span>

<span data-ttu-id="51987-145">このメソッドでは要求本文を指定しないでください。</span><span class="sxs-lookup"><span data-stu-id="51987-145">Do not provide a request body for this method.</span></span>

### <a name="request-example"></a><span data-ttu-id="51987-146">要求の例</span><span class="sxs-lookup"><span data-stu-id="51987-146">Request example</span></span>

<span data-ttu-id="51987-147">次の例は、アドオンの申請を取得する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="51987-147">The following example demonstrates how to get an add-on submission.</span></span>

```
GET https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/9NBLGGH4TNMP/submissions/1152921504621243680 HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="51987-148">応答</span><span class="sxs-lookup"><span data-stu-id="51987-148">Response</span></span>

<span data-ttu-id="51987-149">次の例は、このメソッドが正常に呼び出された場合の JSON 応答本文を示しています。</span><span class="sxs-lookup"><span data-stu-id="51987-149">The following example demonstrates the JSON response body for a successful call to this method.</span></span> <span data-ttu-id="51987-150">応答本文には、指定された申請に関する情報が含まれています。</span><span class="sxs-lookup"><span data-stu-id="51987-150">The response body contains information about the specified submission.</span></span> <span data-ttu-id="51987-151">応答本文内の値について詳しくは、[アドオンの申請のリソース](manage-add-on-submissions.md#add-on-submission-object)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="51987-151">For more details about the values in the response body, see [add-on submission resource](manage-add-on-submissions.md#add-on-submission-object).</span></span>

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


## <a name="error-codes"></a><span data-ttu-id="51987-152">エラー コード</span><span class="sxs-lookup"><span data-stu-id="51987-152">Error codes</span></span>

<span data-ttu-id="51987-153">要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。</span><span class="sxs-lookup"><span data-stu-id="51987-153">If the request cannot be successfully completed, the response will contain one of the following HTTP error codes.</span></span>

| <span data-ttu-id="51987-154">エラー コード</span><span class="sxs-lookup"><span data-stu-id="51987-154">Error code</span></span> |  <span data-ttu-id="51987-155">説明</span><span class="sxs-lookup"><span data-stu-id="51987-155">Description</span></span>   |
|--------|------------------|
| <span data-ttu-id="51987-156">404</span><span class="sxs-lookup"><span data-stu-id="51987-156">404</span></span>  | <span data-ttu-id="51987-157">申請は見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="51987-157">The submission could not be found.</span></span> |
| <span data-ttu-id="51987-158">409</span><span class="sxs-lookup"><span data-stu-id="51987-158">409</span></span>  | <span data-ttu-id="51987-159">指定されたアドオンに、申請が属していないか、アドオンは[、Microsoft Store 申請 API で現在サポートされている](create-and-manage-submissions-using-windows-store-services.md#not_supported)はパートナー センター機能を使用します。</span><span class="sxs-lookup"><span data-stu-id="51987-159">The submission does not belong to the specified add-on, or the add-on uses a Partner Center feature that is [currently not supported by the Microsoft Store submission API](create-and-manage-submissions-using-windows-store-services.md#not_supported).</span></span> |   


## <a name="related-topics"></a><span data-ttu-id="51987-160">関連トピック</span><span class="sxs-lookup"><span data-stu-id="51987-160">Related topics</span></span>

* [<span data-ttu-id="51987-161">Microsoft Store サービスを使用した申請の作成と管理</span><span class="sxs-lookup"><span data-stu-id="51987-161">Create and manage submissions using Microsoft Store services</span></span>](create-and-manage-submissions-using-windows-store-services.md)
* [<span data-ttu-id="51987-162">アドオンの申請の作成</span><span class="sxs-lookup"><span data-stu-id="51987-162">Create an add-on submission</span></span>](create-an-add-on-submission.md)
* [<span data-ttu-id="51987-163">アドオンの申請のコミット</span><span class="sxs-lookup"><span data-stu-id="51987-163">Commit an add-on submission</span></span>](commit-an-add-on-submission.md)
* [<span data-ttu-id="51987-164">アドオンの申請の更新</span><span class="sxs-lookup"><span data-stu-id="51987-164">Update an add-on submission</span></span>](update-an-add-on-submission.md)
* [<span data-ttu-id="51987-165">アドオンの申請の削除</span><span class="sxs-lookup"><span data-stu-id="51987-165">Delete an add-on submission</span></span>](delete-an-add-on-submission.md)
* [<span data-ttu-id="51987-166">アドオンの申請の状態の取得</span><span class="sxs-lookup"><span data-stu-id="51987-166">Get the status of an add-on submission</span></span>](get-status-for-an-add-on-submission.md)
