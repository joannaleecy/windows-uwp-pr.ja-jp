---
author: mcleanbyron
ms.assetid: AD80F9B3-CED0-40BD-A199-AB81CDAE466C
description: "Windows デベロッパー センター アカウントに登録されているアプリのパッケージ フライトを削除するには、Windows ストア申請 API に含まれる以下のメソッドを使用します。"
title: "パッケージ フライトの削除"
ms.author: mcleans
ms.date: 08/03/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, Windows ストア申請 API, フライトの削除"
ms.openlocfilehash: 4a05e69f3dd1c530fee630cc3af13809fc1ac0b6
ms.sourcegitcommit: a8e7dc247196eee79b67aaae2b2a4496c54ce253
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/04/2017
---
# <a name="delete-a-package-flight"></a><span data-ttu-id="7ef40-104">パッケージ フライトの削除</span><span class="sxs-lookup"><span data-stu-id="7ef40-104">Delete a package flight</span></span>




<span data-ttu-id="7ef40-105">Windows デベロッパー センター アカウントに登録されているアプリのパッケージ フライトを削除するには、Windows ストア申請 API に含まれる以下のメソッドを使用します。</span><span class="sxs-lookup"><span data-stu-id="7ef40-105">Use this method in the Windows Store submission API to delete a package flight for an app that is registered to your Windows Dev Center account.</span></span>


## <a name="prerequisites"></a><span data-ttu-id="7ef40-106">前提条件</span><span class="sxs-lookup"><span data-stu-id="7ef40-106">Prerequisites</span></span>

<span data-ttu-id="7ef40-107">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="7ef40-107">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="7ef40-108">Windows ストア申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="7ef40-108">If you have not done so already, complete all the [prerequisites](create-and-manage-submissions-using-windows-store-services.md#prerequisites) for the Windows Store submission API.</span></span>
* <span data-ttu-id="7ef40-109">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="7ef40-109">[Obtain an Azure AD access token](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="7ef40-110">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="7ef40-110">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="7ef40-111">トークンの有効期限が切れたら、新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="7ef40-111">After the token expires, you can obtain a new one.</span></span>

## <a name="request"></a><span data-ttu-id="7ef40-112">要求</span><span class="sxs-lookup"><span data-stu-id="7ef40-112">Request</span></span>

<span data-ttu-id="7ef40-113">このメソッドの構文は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="7ef40-113">This method has the following syntax.</span></span> <span data-ttu-id="7ef40-114">ヘッダーと要求本文の使用例と説明については、次のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7ef40-114">See the following sections for usage examples and descriptions of the header and request body.</span></span>

| <span data-ttu-id="7ef40-115">メソッド</span><span class="sxs-lookup"><span data-stu-id="7ef40-115">Method</span></span> | <span data-ttu-id="7ef40-116">要求 URI</span><span class="sxs-lookup"><span data-stu-id="7ef40-116">Request URI</span></span>                                                      |
|--------|------------------------------------------------------------------|
| <span data-ttu-id="7ef40-117">DELETE</span><span class="sxs-lookup"><span data-stu-id="7ef40-117">DELETE</span></span>    | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}``` |

<span/>
 

### <a name="request-header"></a><span data-ttu-id="7ef40-118">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="7ef40-118">Request header</span></span>

| <span data-ttu-id="7ef40-119">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="7ef40-119">Header</span></span>        | <span data-ttu-id="7ef40-120">型</span><span class="sxs-lookup"><span data-stu-id="7ef40-120">Type</span></span>   | <span data-ttu-id="7ef40-121">説明</span><span class="sxs-lookup"><span data-stu-id="7ef40-121">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="7ef40-122">Authorization</span><span class="sxs-lookup"><span data-stu-id="7ef40-122">Authorization</span></span> | <span data-ttu-id="7ef40-123">string</span><span class="sxs-lookup"><span data-stu-id="7ef40-123">string</span></span> | <span data-ttu-id="7ef40-124">必須。</span><span class="sxs-lookup"><span data-stu-id="7ef40-124">Required.</span></span> <span data-ttu-id="7ef40-125">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="7ef40-125">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |

<span/>

### <a name="request-parameters"></a><span data-ttu-id="7ef40-126">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="7ef40-126">Request parameters</span></span>

| <span data-ttu-id="7ef40-127">名前</span><span class="sxs-lookup"><span data-stu-id="7ef40-127">Name</span></span>        | <span data-ttu-id="7ef40-128">種類</span><span class="sxs-lookup"><span data-stu-id="7ef40-128">Type</span></span>   | <span data-ttu-id="7ef40-129">説明</span><span class="sxs-lookup"><span data-stu-id="7ef40-129">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="7ef40-130">applicationId</span><span class="sxs-lookup"><span data-stu-id="7ef40-130">applicationId</span></span> | <span data-ttu-id="7ef40-131">string</span><span class="sxs-lookup"><span data-stu-id="7ef40-131">string</span></span> | <span data-ttu-id="7ef40-132">必須。</span><span class="sxs-lookup"><span data-stu-id="7ef40-132">Required.</span></span> <span data-ttu-id="7ef40-133">削除するパッケージ フライトが含まれるアプリのストア ID。</span><span class="sxs-lookup"><span data-stu-id="7ef40-133">The Store ID of the app that contains the package flight you want to delete.</span></span> <span data-ttu-id="7ef40-134">アプリのストア ID は、デベロッパー センター ダッシュボードで確認できます。</span><span class="sxs-lookup"><span data-stu-id="7ef40-134">The Store ID for the app is available on the Dev Center dashboard.</span></span>  |
| <span data-ttu-id="7ef40-135">flightId</span><span class="sxs-lookup"><span data-stu-id="7ef40-135">flightId</span></span> | <span data-ttu-id="7ef40-136">string</span><span class="sxs-lookup"><span data-stu-id="7ef40-136">string</span></span> | <span data-ttu-id="7ef40-137">必須。</span><span class="sxs-lookup"><span data-stu-id="7ef40-137">Required.</span></span> <span data-ttu-id="7ef40-138">削除するパッケージ フライトの ID。</span><span class="sxs-lookup"><span data-stu-id="7ef40-138">The ID of the package flight to delete.</span></span> <span data-ttu-id="7ef40-139">この ID は、[パッケージ フライトの作成](create-a-flight.md)要求と[アプリのパッケージ フライトの取得](get-flights-for-an-app.md)要求の応答データで確認できます。</span><span class="sxs-lookup"><span data-stu-id="7ef40-139">This ID is available in the response data for requests to [create a package flight](create-a-flight.md) and [get package flights for an app](get-flights-for-an-app.md).</span></span>  |

<span/>

### <a name="request-body"></a><span data-ttu-id="7ef40-140">要求本文</span><span class="sxs-lookup"><span data-stu-id="7ef40-140">Request body</span></span>

<span data-ttu-id="7ef40-141">このメソッドでは要求本文を指定しないでください。</span><span class="sxs-lookup"><span data-stu-id="7ef40-141">Do not provide a request body for this method.</span></span>

<span/>

### <a name="request-example"></a><span data-ttu-id="7ef40-142">要求の例</span><span class="sxs-lookup"><span data-stu-id="7ef40-142">Request example</span></span>

<span data-ttu-id="7ef40-143">次の例は、新しいパッケージ フライトを削除する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="7ef40-143">The following example demonstrates how to delete a package flight.</span></span>

```
DELETE https://manage.devcenter.microsoft.com/v1.0/my/applications/9NBLGGH4R315/flights/43e448df-97c9-4a43-a0bc-2a445e736bcd HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="7ef40-144">応答</span><span class="sxs-lookup"><span data-stu-id="7ef40-144">Response</span></span>

<span data-ttu-id="7ef40-145">成功した場合、このメソッドは空の応答の本文を返します。</span><span class="sxs-lookup"><span data-stu-id="7ef40-145">If successful, this method returns an empty response body.</span></span>

## <a name="error-codes"></a><span data-ttu-id="7ef40-146">エラー コード</span><span class="sxs-lookup"><span data-stu-id="7ef40-146">Error codes</span></span>

<span data-ttu-id="7ef40-147">要求を正常に完了できない場合、次の HTTP エラー コードのいずれかが応答に含まれます。</span><span class="sxs-lookup"><span data-stu-id="7ef40-147">If the request cannot be successfully completed, the response will contain one of the following HTTP error codes.</span></span>

| <span data-ttu-id="7ef40-148">エラー コード</span><span class="sxs-lookup"><span data-stu-id="7ef40-148">Error code</span></span> |  <span data-ttu-id="7ef40-149">説明</span><span class="sxs-lookup"><span data-stu-id="7ef40-149">Description</span></span>                                                                                                                                                                           |
|--------|------------------|
| <span data-ttu-id="7ef40-150">400</span><span class="sxs-lookup"><span data-stu-id="7ef40-150">400</span></span>  | <span data-ttu-id="7ef40-151">要求パラメーターが有効ではありません。</span><span class="sxs-lookup"><span data-stu-id="7ef40-151">The request parameters are invalid.</span></span> |
| <span data-ttu-id="7ef40-152">404</span><span class="sxs-lookup"><span data-stu-id="7ef40-152">404</span></span>  | <span data-ttu-id="7ef40-153">指定されたパッケージ フライトは見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="7ef40-153">The specified package flight could not be found.</span></span>  |
| <span data-ttu-id="7ef40-154">409</span><span class="sxs-lookup"><span data-stu-id="7ef40-154">409</span></span>  | <span data-ttu-id="7ef40-155">指定したパッケージ フライトは見つかりましたが、現在の状態で削除できなかったか、[Windows ストア申請 API で現在サポートされていない](create-and-manage-submissions-using-windows-store-services.md#not_supported)デベロッパー センター ダッシュボード機能がアプリで使用されています。</span><span class="sxs-lookup"><span data-stu-id="7ef40-155">The specified package flight was found but it could not be deleted in its current state, or the app uses a Dev Center dashboard feature that is [currently not supported by the Windows Store submission API](create-and-manage-submissions-using-windows-store-services.md#not_supported).</span></span> |   

<span/>

## <a name="related-topics"></a><span data-ttu-id="7ef40-156">関連トピック</span><span class="sxs-lookup"><span data-stu-id="7ef40-156">Related topics</span></span>

* [<span data-ttu-id="7ef40-157">Windows ストア サービスを使用した申請の作成と管理</span><span class="sxs-lookup"><span data-stu-id="7ef40-157">Create and manage submissions using Windows Store services</span></span>](create-and-manage-submissions-using-windows-store-services.md)
* [<span data-ttu-id="7ef40-158">パッケージ フライトの作成</span><span class="sxs-lookup"><span data-stu-id="7ef40-158">Create a package flight</span></span>](create-a-flight.md)
* [<span data-ttu-id="7ef40-159">パッケージ フライトの取得</span><span class="sxs-lookup"><span data-stu-id="7ef40-159">Get a package flight</span></span>](get-a-flight.md)
