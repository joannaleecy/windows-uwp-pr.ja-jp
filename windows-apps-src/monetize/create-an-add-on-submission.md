---
ms.assetid: C09F4B7C-6324-4973-980A-A60035792EFC
description: Microsoft Store 送信 API でこのメソッドを使用すると、パートナー センターに登録されているアプリの新しいアドオンの提出パッケージを作成できます。
title: アドオンの申請の作成
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store 申請 API, アドオンの申請の作成, アプリ内製品, IAP
ms.localizationpriority: medium
ms.openlocfilehash: fcc98252efb1157bc539b68656c96f7afec7104a
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57661707"
---
# <a name="create-an-add-on-submission"></a><span data-ttu-id="8c133-104">アドオンの申請の作成</span><span class="sxs-lookup"><span data-stu-id="8c133-104">Create an add-on submission</span></span>


<span data-ttu-id="8c133-105">Microsoft Store 送信 API でこのメソッドを使用すると、パートナー センター アカウントに登録されているアプリの新しいアドオン (とも呼ばれるアプリ内製品または IAP) 提出を作成できます。</span><span class="sxs-lookup"><span data-stu-id="8c133-105">Use this method in the Microsoft Store submission API to create a new add-on (also known as in-app product or IAP) submission for an app that is registered to your Partner Center account.</span></span> <span data-ttu-id="8c133-106">このメソッドを使って新しい申請を正常に作成したら、[申請を更新](update-an-add-on-submission.md)して申請データに必要な変更を加え、取り込んで公開するために[申請をコミット](commit-an-add-on-submission.md)します。</span><span class="sxs-lookup"><span data-stu-id="8c133-106">After you successfully create a new submission by using this method, [update the submission](update-an-add-on-submission.md) to make any necessary changes to the submission data, and then [commit the submission](commit-an-add-on-submission.md) for ingestion and publishing.</span></span>

<span data-ttu-id="8c133-107">このメソッドが Microsoft Store 申請 API を使ったアドオンの申請の作成プロセスにどのように適合するかについては、「[アドオンの申請の管理](manage-add-on-submissions.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8c133-107">For more information about how this method fits into the process of creating an add-on submission by using the Microsoft Store submission API, see [Manage add-on submissions](manage-add-on-submissions.md).</span></span>

> [!NOTE]
> <span data-ttu-id="8c133-108">このメソッドは、既存のアドオンの申請を作成します。</span><span class="sxs-lookup"><span data-stu-id="8c133-108">This method creates a submission for an existing add-on.</span></span> <span data-ttu-id="8c133-109">アドオンを作成するには、[アドオンの作成](create-an-add-on.md)メソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="8c133-109">To create an add-on, use the [Create an add-on](create-an-add-on.md) method.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="8c133-110">前提条件</span><span class="sxs-lookup"><span data-stu-id="8c133-110">Prerequisites</span></span>

<span data-ttu-id="8c133-111">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="8c133-111">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="8c133-112">Microsoft Store 申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="8c133-112">If you have not done so already, complete all the [prerequisites](create-and-manage-submissions-using-windows-store-services.md#prerequisites) for the Microsoft Store submission API.</span></span>
* <span data-ttu-id="8c133-113">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="8c133-113">[Obtain an Azure AD access token](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="8c133-114">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="8c133-114">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="8c133-115">トークンの有効期限が切れたら新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="8c133-115">After the token expires, you can obtain a new one.</span></span>
* <span data-ttu-id="8c133-116">アプリのいずれかのアドオンを作成します。</span><span class="sxs-lookup"><span data-stu-id="8c133-116">Create an add-on for one of your apps.</span></span> <span data-ttu-id="8c133-117">パートナー センターでこれを行うかを使用してこれを行う、[アドオンを作成](create-an-add-on.md)メソッド。</span><span class="sxs-lookup"><span data-stu-id="8c133-117">You can do this in Partner Center, or you can do this by using the [Create an add-on](create-an-add-on.md) method.</span></span>

## <a name="request"></a><span data-ttu-id="8c133-118">要求</span><span class="sxs-lookup"><span data-stu-id="8c133-118">Request</span></span>

<span data-ttu-id="8c133-119">このメソッドの構文は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="8c133-119">This method has the following syntax.</span></span> <span data-ttu-id="8c133-120">ヘッダーと要求本文の使用例と説明については、次のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8c133-120">See the following sections for usage examples and descriptions of the header and request body.</span></span>

| <span data-ttu-id="8c133-121">メソッド</span><span class="sxs-lookup"><span data-stu-id="8c133-121">Method</span></span> | <span data-ttu-id="8c133-122">要求 URI</span><span class="sxs-lookup"><span data-stu-id="8c133-122">Request URI</span></span>                                                      |
|--------|------------------------------------------------------------------|
| <span data-ttu-id="8c133-123">POST</span><span class="sxs-lookup"><span data-stu-id="8c133-123">POST</span></span>    | ```https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/{inAppProductId}/submissions``` |


### <a name="request-header"></a><span data-ttu-id="8c133-124">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="8c133-124">Request header</span></span>

| <span data-ttu-id="8c133-125">Header</span><span class="sxs-lookup"><span data-stu-id="8c133-125">Header</span></span>        | <span data-ttu-id="8c133-126">種類</span><span class="sxs-lookup"><span data-stu-id="8c133-126">Type</span></span>   | <span data-ttu-id="8c133-127">説明</span><span class="sxs-lookup"><span data-stu-id="8c133-127">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="8c133-128">Authorization</span><span class="sxs-lookup"><span data-stu-id="8c133-128">Authorization</span></span> | <span data-ttu-id="8c133-129">string</span><span class="sxs-lookup"><span data-stu-id="8c133-129">string</span></span> | <span data-ttu-id="8c133-130">必須。</span><span class="sxs-lookup"><span data-stu-id="8c133-130">Required.</span></span> <span data-ttu-id="8c133-131">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="8c133-131">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="8c133-132">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="8c133-132">Request parameters</span></span>

| <span data-ttu-id="8c133-133">名前</span><span class="sxs-lookup"><span data-stu-id="8c133-133">Name</span></span>        | <span data-ttu-id="8c133-134">種類</span><span class="sxs-lookup"><span data-stu-id="8c133-134">Type</span></span>   | <span data-ttu-id="8c133-135">説明</span><span class="sxs-lookup"><span data-stu-id="8c133-135">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="8c133-136">inAppProductId</span><span class="sxs-lookup"><span data-stu-id="8c133-136">inAppProductId</span></span> | <span data-ttu-id="8c133-137">string</span><span class="sxs-lookup"><span data-stu-id="8c133-137">string</span></span> | <span data-ttu-id="8c133-138">必須。</span><span class="sxs-lookup"><span data-stu-id="8c133-138">Required.</span></span> <span data-ttu-id="8c133-139">申請を作成するアドオンのストア ID です。</span><span class="sxs-lookup"><span data-stu-id="8c133-139">The Store ID of the add-on for which you want to create a submission.</span></span> <span data-ttu-id="8c133-140">Store ID は、パートナー センターで利用できるとするための要求応答のデータに含まれる[アドオンを作成](create-an-add-on.md)または[アドオンの詳細の取得](get-all-add-ons.md)します。</span><span class="sxs-lookup"><span data-stu-id="8c133-140">The Store ID is available in Partner Center, and it is included in the response data for requests to [Create an add-on](create-an-add-on.md) or [get add-on details](get-all-add-ons.md).</span></span>  |


### <a name="request-body"></a><span data-ttu-id="8c133-141">要求本文</span><span class="sxs-lookup"><span data-stu-id="8c133-141">Request body</span></span>

<span data-ttu-id="8c133-142">このメソッドでは要求本文を指定しないでください。</span><span class="sxs-lookup"><span data-stu-id="8c133-142">Do not provide a request body for this method.</span></span>

### <a name="request-example"></a><span data-ttu-id="8c133-143">要求の例</span><span class="sxs-lookup"><span data-stu-id="8c133-143">Request example</span></span>

<span data-ttu-id="8c133-144">次の例は、アドオンの新しい申請を作成する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="8c133-144">The following example demonstrates how to create a new submission for an add-on.</span></span>

```
POST https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/9NBLGGH4TNMP/submissions HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="8c133-145">応答</span><span class="sxs-lookup"><span data-stu-id="8c133-145">Response</span></span>

<span data-ttu-id="8c133-146">次の例は、このメソッドが正常に呼び出された場合の JSON 応答本文を示しています。</span><span class="sxs-lookup"><span data-stu-id="8c133-146">The following example demonstrates the JSON response body for a successful call to this method.</span></span> <span data-ttu-id="8c133-147">応答本文には、新しい申請に関する情報が含まれています。</span><span class="sxs-lookup"><span data-stu-id="8c133-147">The response body contains information about the new submission.</span></span> <span data-ttu-id="8c133-148">応答本文内の値について詳しくは、[アドオンの申請のリソース](manage-add-on-submissions.md#add-on-submission-object)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8c133-148">For more details about the values in the response body, see [add-on submission resource](manage-add-on-submissions.md#add-on-submission-object).</span></span>

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
    "sales": [
      {
         "name": "Sale1",
         "basePriceId": "Free",
         "startDate": "2016-05-21T18:40:11.7369008Z",
         "endDate": "2016-05-22T18:40:11.7369008Z",
         "marketSpecificPricings": {
            "RU": "NotAvailable"
         }
      }
    ],
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

## <a name="error-codes"></a><span data-ttu-id="8c133-149">エラー コード</span><span class="sxs-lookup"><span data-stu-id="8c133-149">Error codes</span></span>

<span data-ttu-id="8c133-150">要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。</span><span class="sxs-lookup"><span data-stu-id="8c133-150">If the request cannot be successfully completed, the response will contain one of the following HTTP error codes.</span></span>

| <span data-ttu-id="8c133-151">エラー コード</span><span class="sxs-lookup"><span data-stu-id="8c133-151">Error code</span></span> |  <span data-ttu-id="8c133-152">説明</span><span class="sxs-lookup"><span data-stu-id="8c133-152">Description</span></span>   |
|--------|------------------|
| <span data-ttu-id="8c133-153">400</span><span class="sxs-lookup"><span data-stu-id="8c133-153">400</span></span>  | <span data-ttu-id="8c133-154">要求が無効なため、申請を作成できませんでした。</span><span class="sxs-lookup"><span data-stu-id="8c133-154">The submission could not be created because the request is invalid.</span></span> |
| <span data-ttu-id="8c133-155">409</span><span class="sxs-lookup"><span data-stu-id="8c133-155">409</span></span>  | <span data-ttu-id="8c133-156">アプリの現在の状態であるため、送信を作成できませんでしたまたはアプリであるパートナー センター機能を使用する[現在サポートされていません、Microsoft Store 送信 API](create-and-manage-submissions-using-windows-store-services.md#not_supported)。</span><span class="sxs-lookup"><span data-stu-id="8c133-156">The submission could not be created because of the current state of the app, or the app uses a Partner Center feature that is [currently not supported by the Microsoft Store submission API](create-and-manage-submissions-using-windows-store-services.md#not_supported).</span></span> |   


## <a name="related-topics"></a><span data-ttu-id="8c133-157">関連トピック</span><span class="sxs-lookup"><span data-stu-id="8c133-157">Related topics</span></span>

* [<span data-ttu-id="8c133-158">作成し、Microsoft Store サービスを使用して送信の管理</span><span class="sxs-lookup"><span data-stu-id="8c133-158">Create and manage submissions using Microsoft Store services</span></span>](create-and-manage-submissions-using-windows-store-services.md)
* [<span data-ttu-id="8c133-159">アドオンの送信を管理します。</span><span class="sxs-lookup"><span data-stu-id="8c133-159">Manage add-on submissions</span></span>](manage-add-on-submissions.md)
* [<span data-ttu-id="8c133-160">取得するアドオンの送信</span><span class="sxs-lookup"><span data-stu-id="8c133-160">Get an add-on submission</span></span>](get-an-add-on-submission.md)
* [<span data-ttu-id="8c133-161">コミット、アドオンの送信</span><span class="sxs-lookup"><span data-stu-id="8c133-161">Commit an add-on submission</span></span>](commit-an-add-on-submission.md)
* [<span data-ttu-id="8c133-162">アドオンを申請を更新します。</span><span class="sxs-lookup"><span data-stu-id="8c133-162">Update an add-on submission</span></span>](update-an-add-on-submission.md)
* [<span data-ttu-id="8c133-163">削除するアドオンの送信</span><span class="sxs-lookup"><span data-stu-id="8c133-163">Delete an add-on submission</span></span>](delete-an-add-on-submission.md)
* [<span data-ttu-id="8c133-164">アドオンの提出パッケージのステータスを取得します。</span><span class="sxs-lookup"><span data-stu-id="8c133-164">Get the status of an add-on submission</span></span>](get-status-for-an-add-on-submission.md)
