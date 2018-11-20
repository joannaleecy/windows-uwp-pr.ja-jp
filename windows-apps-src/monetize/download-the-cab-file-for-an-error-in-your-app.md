---
author: Xansky
ms.assetid: ''
description: アプリのエラーの CAB ファイルをダウンロードするには、Microsoft Store 分析 API の以下のメソッドを使います。
title: アプリのエラーの CAB ファイルをダウンロードする
ms.author: mhopkins
ms.date: 06/16/2017
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store 分析 API, CAB のダウンロード
ms.localizationpriority: medium
ms.openlocfilehash: 047340d180e3de9f963dc76c85edaa6abea67327
ms.sourcegitcommit: ed0304b8a214c03b8aab74b8ef12c9f82b8e3c5f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/19/2018
ms.locfileid: "7292470"
---
# <a name="download-the-cab-file-for-an-error-in-your-app"></a><span data-ttu-id="e8b9c-104">アプリのエラーの CAB ファイルをダウンロードする</span><span class="sxs-lookup"><span data-stu-id="e8b9c-104">Download the CAB file for an error in your app</span></span>

<span data-ttu-id="e8b9c-105">パートナー センターに報告されたアプリの特定のエラーに関連付けられている CAB ファイルをダウンロードするのに、Microsoft Store 分析 API の以下のメソッドを使用します。</span><span class="sxs-lookup"><span data-stu-id="e8b9c-105">Use this method in the Microsoft Store analytics API to download the CAB file that is associated with a particular error in your app that has been reported to Partner Center.</span></span> <span data-ttu-id="e8b9c-106">このメソッドでダウンロードできるのは、過去 30 日以内に発生したアプリのエラーに関する CAB ファイルのみです。</span><span class="sxs-lookup"><span data-stu-id="e8b9c-106">This method can only download the CAB file for an app error that occurred in the last 30 days.</span></span> <span data-ttu-id="e8b9c-107">[正常性レポート](../publish/health-report.md)では、パートナー センターの [**エラー** ] セクションでは、CAB ファイルのダウンロードを利用できます。</span><span class="sxs-lookup"><span data-stu-id="e8b9c-107">CAB file downloads are also available in the **Failures** section of the [Health report](../publish/health-report.md) in Partner Center.</span></span>

<span data-ttu-id="e8b9c-108">このメソッドを使うには、事前に 「[アプリのエラーに関する詳細情報の取得](get-details-for-an-error-in-your-app.md)」のメソッドを使用し、ダウンロードする CAB ファイルの ID を取得しておく必要があります。</span><span class="sxs-lookup"><span data-stu-id="e8b9c-108">Before you can use this method, you must first use the [get details for an error in your app](get-details-for-an-error-in-your-app.md) method to retrieve the ID of the CAB file you want to download.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="e8b9c-109">前提条件</span><span class="sxs-lookup"><span data-stu-id="e8b9c-109">Prerequisites</span></span>


<span data-ttu-id="e8b9c-110">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="e8b9c-110">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="e8b9c-111">Microsoft Store 分析 API に関するすべての[前提条件](access-analytics-data-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="e8b9c-111">If you have not done so already, complete all the [prerequisites](access-analytics-data-using-windows-store-services.md#prerequisites) for the Microsoft Store analytics API.</span></span>
* <span data-ttu-id="e8b9c-112">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="e8b9c-112">[Obtain an Azure AD access token](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="e8b9c-113">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="e8b9c-113">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="e8b9c-114">トークンの有効期限が切れたら、新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="e8b9c-114">After the token expires, you can obtain a new one.</span></span>
* <span data-ttu-id="e8b9c-115">ダウンロードする CAB ファイルの ID を取得します。</span><span class="sxs-lookup"><span data-stu-id="e8b9c-115">Get the ID of the CAB file you want to download.</span></span> <span data-ttu-id="e8b9c-116">この ID を取得するには、「[アプリのエラーに関する詳細情報の取得](get-details-for-an-error-in-your-app.md)」のメソッドを使って、アプリの特定のエラーに関する詳細情報を取得し、そのメソッドの応答本文で **cabId** 値を使います。</span><span class="sxs-lookup"><span data-stu-id="e8b9c-116">To get this ID, use the [get details for an error in your app](get-details-for-an-error-in-your-app.md) method to retrieve details for a specific error in your app, and use the **cabId** value in the response body of that method.</span></span>

## <a name="request"></a><span data-ttu-id="e8b9c-117">要求</span><span class="sxs-lookup"><span data-stu-id="e8b9c-117">Request</span></span>


### <a name="request-syntax"></a><span data-ttu-id="e8b9c-118">要求の構文</span><span class="sxs-lookup"><span data-stu-id="e8b9c-118">Request syntax</span></span>

| <span data-ttu-id="e8b9c-119">メソッド</span><span class="sxs-lookup"><span data-stu-id="e8b9c-119">Method</span></span> | <span data-ttu-id="e8b9c-120">要求 URI</span><span class="sxs-lookup"><span data-stu-id="e8b9c-120">Request URI</span></span>                                                          |
|--------|----------------------------------------------------------------------|
| <span data-ttu-id="e8b9c-121">GET</span><span class="sxs-lookup"><span data-stu-id="e8b9c-121">GET</span></span>    | ```https://manage.devcenter.microsoft.com/v1.0/my/analytics/cabdownload``` |


### <a name="request-header"></a><span data-ttu-id="e8b9c-122">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="e8b9c-122">Request header</span></span>

| <span data-ttu-id="e8b9c-123">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="e8b9c-123">Header</span></span>        | <span data-ttu-id="e8b9c-124">型</span><span class="sxs-lookup"><span data-stu-id="e8b9c-124">Type</span></span>   | <span data-ttu-id="e8b9c-125">説明</span><span class="sxs-lookup"><span data-stu-id="e8b9c-125">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="e8b9c-126">Authorization</span><span class="sxs-lookup"><span data-stu-id="e8b9c-126">Authorization</span></span> | <span data-ttu-id="e8b9c-127">string</span><span class="sxs-lookup"><span data-stu-id="e8b9c-127">string</span></span> | <span data-ttu-id="e8b9c-128">必須。</span><span class="sxs-lookup"><span data-stu-id="e8b9c-128">Required.</span></span> <span data-ttu-id="e8b9c-129">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="e8b9c-129">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="e8b9c-130">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="e8b9c-130">Request parameters</span></span>

| <span data-ttu-id="e8b9c-131">パラメーター</span><span class="sxs-lookup"><span data-stu-id="e8b9c-131">Parameter</span></span>        | <span data-ttu-id="e8b9c-132">型</span><span class="sxs-lookup"><span data-stu-id="e8b9c-132">Type</span></span>   |  <span data-ttu-id="e8b9c-133">説明</span><span class="sxs-lookup"><span data-stu-id="e8b9c-133">Description</span></span>      |  <span data-ttu-id="e8b9c-134">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="e8b9c-134">Required</span></span>  |
|---------------|--------|---------------|------|
| <span data-ttu-id="e8b9c-135">applicationId</span><span class="sxs-lookup"><span data-stu-id="e8b9c-135">applicationId</span></span> | <span data-ttu-id="e8b9c-136">string</span><span class="sxs-lookup"><span data-stu-id="e8b9c-136">string</span></span> | <span data-ttu-id="e8b9c-137">CAB ファイルをダウンロードするアプリのストア ID です。</span><span class="sxs-lookup"><span data-stu-id="e8b9c-137">The Store ID of the app for which you want to download a CAB file.</span></span> <span data-ttu-id="e8b9c-138">ストア ID は、パートナー センターの[アプリ id] ページ](../publish/view-app-identity-details.md)で利用できます。</span><span class="sxs-lookup"><span data-stu-id="e8b9c-138">The Store ID is available on the [App identity page](../publish/view-app-identity-details.md) of Partner Center.</span></span> <span data-ttu-id="e8b9c-139">ストア ID は、たとえば 9WZDNCRFJ3Q8 のような文字列です。</span><span class="sxs-lookup"><span data-stu-id="e8b9c-139">An example Store ID is 9WZDNCRFJ3Q8.</span></span> |  <span data-ttu-id="e8b9c-140">必須</span><span class="sxs-lookup"><span data-stu-id="e8b9c-140">Yes</span></span>  |
| <span data-ttu-id="e8b9c-141">cabId</span><span class="sxs-lookup"><span data-stu-id="e8b9c-141">cabId</span></span> | <span data-ttu-id="e8b9c-142">string</span><span class="sxs-lookup"><span data-stu-id="e8b9c-142">string</span></span> | <span data-ttu-id="e8b9c-143">ダウンロードする CAB ファイルの一意の ID です。</span><span class="sxs-lookup"><span data-stu-id="e8b9c-143">The unique ID of the CAB file you want to download.</span></span> <span data-ttu-id="e8b9c-144">この ID を取得するには、「[アプリのエラーに関する詳細情報の取得](get-details-for-an-error-in-your-app.md)」のメソッドを使って、アプリの特定のエラーに関する詳細情報を取得し、そのメソッドの応答本文で **cabId** 値を使います。</span><span class="sxs-lookup"><span data-stu-id="e8b9c-144">To get this ID, use the [get details for an error in your app](get-details-for-an-error-in-your-app.md) method to retrieve details for a specific error in your app, and use the **cabId** value in the response body of that method.</span></span> |  <span data-ttu-id="e8b9c-145">必須</span><span class="sxs-lookup"><span data-stu-id="e8b9c-145">Yes</span></span>  |

 
### <a name="request-example"></a><span data-ttu-id="e8b9c-146">要求の例</span><span class="sxs-lookup"><span data-stu-id="e8b9c-146">Request example</span></span>

<span data-ttu-id="e8b9c-147">次の例は、このメソッドを使って CAB ファイルをダウンロードする方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="e8b9c-147">The following example demonstrates how to download a CAB file using this method.</span></span> <span data-ttu-id="e8b9c-148">*applicationId* および *cabId* パラメーターを、アプリの適切な値に置き換えてください。</span><span class="sxs-lookup"><span data-stu-id="e8b9c-148">Replace the *applicationId* and *cabId* parameters with the appropriate values for your app.</span></span>

```syntax
GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/cabdownload?applicationId=9NBLGGGZ5QDR&cabId=1336373323853 HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="e8b9c-149">応答</span><span class="sxs-lookup"><span data-stu-id="e8b9c-149">Response</span></span>

<span data-ttu-id="e8b9c-150">このメソッドは 302 (リダイレクト) 応答コードを返します。また、応答に含まれる **Location** ヘッダーは、CAB ファイルの Shared Access Signature (SAS) URI に割り当てられます。</span><span class="sxs-lookup"><span data-stu-id="e8b9c-150">This method returns a 302 (redirect) response code, and the **Location** header in the response is assigned to the shared access signature (SAS) URI of the CAB file.</span></span> <span data-ttu-id="e8b9c-151">呼び出し元はこの URI にリダイレクトされ、CAB ファイルが自動的にダウンロードされます。</span><span class="sxs-lookup"><span data-stu-id="e8b9c-151">The caller is redirected to this URI to automatically download the CAB file.</span></span>

## <a name="related-topics"></a><span data-ttu-id="e8b9c-152">関連トピック</span><span class="sxs-lookup"><span data-stu-id="e8b9c-152">Related topics</span></span>

* [<span data-ttu-id="e8b9c-153">[正常性] レポート</span><span class="sxs-lookup"><span data-stu-id="e8b9c-153">Health report</span></span>](../publish/health-report.md)
* [<span data-ttu-id="e8b9c-154">Microsoft Store サービスを使った分析データへのアクセス</span><span class="sxs-lookup"><span data-stu-id="e8b9c-154">Access analytics data using Microsoft Store services</span></span>](access-analytics-data-using-windows-store-services.md)
* [<span data-ttu-id="e8b9c-155">エラー報告データの取得</span><span class="sxs-lookup"><span data-stu-id="e8b9c-155">Get error reporting data</span></span>](get-error-reporting-data.md)
* [<span data-ttu-id="e8b9c-156">アプリのエラーに関する詳細情報の取得</span><span class="sxs-lookup"><span data-stu-id="e8b9c-156">Get details for an error in your app</span></span>](get-details-for-an-error-in-your-app.md)
* [<span data-ttu-id="e8b9c-157">アプリのエラーに関するスタック トレースの取得</span><span class="sxs-lookup"><span data-stu-id="e8b9c-157">Get the stack trace for an error in your app</span></span>](get-the-stack-trace-for-an-error-in-your-app.md)
