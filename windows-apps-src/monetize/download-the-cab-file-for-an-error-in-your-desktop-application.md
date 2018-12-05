---
description: デスクトップ アプリケーションのエラーの CAB ファイルをダウンロードするには、Microsoft Store 分析 API の以下のメソッドを使います。
title: デスクトップ アプリケーションのエラーの CAB ファイルをダウンロードする
ms.date: 03/06/2018
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store 分析 API, CAB のダウンロード, デスクトップ アプリケーション
ms.localizationpriority: medium
ms.openlocfilehash: 1e3535f18b8127ea18bca234cdcc9b695e89ebfd
ms.sourcegitcommit: c01c29cd97f1cbf050950526e18e15823b6a12a0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/05/2018
ms.locfileid: "8699830"
---
# <a name="download-the-cab-file-for-an-error-in-your-desktop-application"></a><span data-ttu-id="d1e17-104">デスクトップ アプリケーションのエラーの CAB ファイルをダウンロードする</span><span class="sxs-lookup"><span data-stu-id="d1e17-104">Download the CAB file for an error in your desktop application</span></span>

<span data-ttu-id="d1e17-105">[Windows デスクトップ アプリケーション プログラム](https://msdn.microsoft.com/library/windows/desktop/mt826504)に追加したデスクトップ アプリケーションの特定のエラーに関連する CAB ファイルをダウンロードするには、Microsoft Store 分析 API の以下のメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="d1e17-105">Use this method in the Microsoft Store analytics API to download the CAB file that is associated with a particular error for a desktop application that you have added to the [Windows Desktop Application program](https://msdn.microsoft.com/library/windows/desktop/mt826504).</span></span> <span data-ttu-id="d1e17-106">このメソッドでダウンロードできるのは、過去 30 日以内に発生したアプリのエラーに関する CAB ファイルのみです。</span><span class="sxs-lookup"><span data-stu-id="d1e17-106">This method can only download the CAB file for an app error that occurred in the last 30 days.</span></span> <span data-ttu-id="d1e17-107">CAB ファイルのダウンロードでは、パートナー センターでデスクトップ アプリケーションの[正常性レポート](https://msdn.microsoft.com/library/windows/desktop/mt826504)で利用できます。</span><span class="sxs-lookup"><span data-stu-id="d1e17-107">CAB file downloads are also available in the [Health report](https://msdn.microsoft.com/library/windows/desktop/mt826504) for desktop applications in Partner Center.</span></span>

<span data-ttu-id="d1e17-108">このメソッドを使用するには、事前に「[デスクトップ アプリケーションのエラーに関する詳細情報の取得](get-details-for-an-error-in-your-desktop-application.md)」のメソッドを使って、ダウンロードする CAB ファイルの ID ハッシュを取得しておく必要があります。</span><span class="sxs-lookup"><span data-stu-id="d1e17-108">Before you can use this method, you must first use the [get details for an error in your desktop application](get-details-for-an-error-in-your-desktop-application.md) method to retrieve the ID hash of the CAB file you want to download.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="d1e17-109">前提条件</span><span class="sxs-lookup"><span data-stu-id="d1e17-109">Prerequisites</span></span>


<span data-ttu-id="d1e17-110">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="d1e17-110">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="d1e17-111">Microsoft Store 分析 API に関するすべての[前提条件](access-analytics-data-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="d1e17-111">If you have not done so already, complete all the [prerequisites](access-analytics-data-using-windows-store-services.md#prerequisites) for the Microsoft Store analytics API.</span></span>
* <span data-ttu-id="d1e17-112">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="d1e17-112">[Obtain an Azure AD access token](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="d1e17-113">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="d1e17-113">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="d1e17-114">トークンの有効期限が切れたら、新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="d1e17-114">After the token expires, you can obtain a new one.</span></span>
* <span data-ttu-id="d1e17-115">ダウンロードする CAB ファイルの ID ハッシュを取得します。</span><span class="sxs-lookup"><span data-stu-id="d1e17-115">Get the ID hash of the CAB file you want to download.</span></span> <span data-ttu-id="d1e17-116">この値を取得するには、「[デスクトップ アプリケーションのエラーに関する詳細情報の取得](get-details-for-an-error-in-your-desktop-application.md)」のメソッドを使ってアプリの特定のエラーに関する詳細情報を取得し、そのメソッドの応答本文に含まれる **cabIdHash** 値を使用します。</span><span class="sxs-lookup"><span data-stu-id="d1e17-116">To get this value, use the [get details for an error in your desktop application](get-details-for-an-error-in-your-desktop-application.md) method to retrieve details for a specific error in your app, and use the **cabIdHash** value in the response body of that method.</span></span>

## <a name="request"></a><span data-ttu-id="d1e17-117">要求</span><span class="sxs-lookup"><span data-stu-id="d1e17-117">Request</span></span>


### <a name="request-syntax"></a><span data-ttu-id="d1e17-118">要求の構文</span><span class="sxs-lookup"><span data-stu-id="d1e17-118">Request syntax</span></span>

| <span data-ttu-id="d1e17-119">メソッド</span><span class="sxs-lookup"><span data-stu-id="d1e17-119">Method</span></span> | <span data-ttu-id="d1e17-120">要求 URI</span><span class="sxs-lookup"><span data-stu-id="d1e17-120">Request URI</span></span>                                                          |
|--------|----------------------------------------------------------------------|
| <span data-ttu-id="d1e17-121">GET</span><span class="sxs-lookup"><span data-stu-id="d1e17-121">GET</span></span>    | ```https://manage.devcenter.microsoft.com/v1.0/my/analytics/desktop/cabdownload``` |


### <a name="request-header"></a><span data-ttu-id="d1e17-122">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="d1e17-122">Request header</span></span>

| <span data-ttu-id="d1e17-123">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="d1e17-123">Header</span></span>        | <span data-ttu-id="d1e17-124">型</span><span class="sxs-lookup"><span data-stu-id="d1e17-124">Type</span></span>   | <span data-ttu-id="d1e17-125">説明</span><span class="sxs-lookup"><span data-stu-id="d1e17-125">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="d1e17-126">Authorization</span><span class="sxs-lookup"><span data-stu-id="d1e17-126">Authorization</span></span> | <span data-ttu-id="d1e17-127">string</span><span class="sxs-lookup"><span data-stu-id="d1e17-127">string</span></span> | <span data-ttu-id="d1e17-128">必須。</span><span class="sxs-lookup"><span data-stu-id="d1e17-128">Required.</span></span> <span data-ttu-id="d1e17-129">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="d1e17-129">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="d1e17-130">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="d1e17-130">Request parameters</span></span>

| <span data-ttu-id="d1e17-131">パラメーター</span><span class="sxs-lookup"><span data-stu-id="d1e17-131">Parameter</span></span>        | <span data-ttu-id="d1e17-132">型</span><span class="sxs-lookup"><span data-stu-id="d1e17-132">Type</span></span>   |  <span data-ttu-id="d1e17-133">説明</span><span class="sxs-lookup"><span data-stu-id="d1e17-133">Description</span></span>      |  <span data-ttu-id="d1e17-134">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="d1e17-134">Required</span></span>  |
|---------------|--------|---------------|------|
| <span data-ttu-id="d1e17-135">applicationId</span><span class="sxs-lookup"><span data-stu-id="d1e17-135">applicationId</span></span> | <span data-ttu-id="d1e17-136">string</span><span class="sxs-lookup"><span data-stu-id="d1e17-136">string</span></span> | <span data-ttu-id="d1e17-137">CAB ファイルをダウンロードするデスクトップ アプリケーションの製品 ID です。</span><span class="sxs-lookup"><span data-stu-id="d1e17-137">The product ID of the desktop application for which you want to download a CAB file.</span></span> <span data-ttu-id="d1e17-138">デスクトップ アプリケーションの製品 ID を取得するには、[デスクトップ アプリケーションのパートナー センターの分析レポート](https://msdn.microsoft.com/library/windows/desktop/mt826504)(など**の正常性レポート**) を開き、URL から製品 ID を取得します。</span><span class="sxs-lookup"><span data-stu-id="d1e17-138">To get the product ID of a desktop application, open any [Partner Center analytics report for your desktop application](https://msdn.microsoft.com/library/windows/desktop/mt826504) (such as the **Health report**) and retrieve the product ID from the URL.</span></span> |  <span data-ttu-id="d1e17-139">はい</span><span class="sxs-lookup"><span data-stu-id="d1e17-139">Yes</span></span>  |
| <span data-ttu-id="d1e17-140">cabIdHash</span><span class="sxs-lookup"><span data-stu-id="d1e17-140">cabIdHash</span></span> | <span data-ttu-id="d1e17-141">string</span><span class="sxs-lookup"><span data-stu-id="d1e17-141">string</span></span> | <span data-ttu-id="d1e17-142">ダウンロードする CAB ファイルの一意の ID ハッシュです。</span><span class="sxs-lookup"><span data-stu-id="d1e17-142">The unique ID hash of the CAB file you want to download.</span></span> <span data-ttu-id="d1e17-143">この値を取得するには、「[デスクトップ アプリケーションのエラーに関する詳細情報の取得](get-details-for-an-error-in-your-desktop-application.md)」のメソッドを使ってアプリケーションの特定のエラーに関する詳細情報を取得し、そのメソッドの応答本文に含まれる **cabIdHash** 値を使用します。</span><span class="sxs-lookup"><span data-stu-id="d1e17-143">To get this value, use the [get details for an error in your desktop application](get-details-for-an-error-in-your-desktop-application.md) method to retrieve details for a specific error in your application, and use the **cabIdHash** value in the response body of that method.</span></span> |  <span data-ttu-id="d1e17-144">必須</span><span class="sxs-lookup"><span data-stu-id="d1e17-144">Yes</span></span>  |


### <a name="request-example"></a><span data-ttu-id="d1e17-145">要求の例</span><span class="sxs-lookup"><span data-stu-id="d1e17-145">Request example</span></span>

<span data-ttu-id="d1e17-146">次の例は、このメソッドを使って CAB ファイルをダウンロードする方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="d1e17-146">The following example demonstrates how to download a CAB file using this method.</span></span> <span data-ttu-id="d1e17-147">*applicationId* パラメーターと *cabIdHash* パラメーターは、デスクトップ アプリケーションに合わせて適切な値に置き換えてください。</span><span class="sxs-lookup"><span data-stu-id="d1e17-147">Replace the *applicationId* and *cabIdHash* parameters with the appropriate values for your desktop application.</span></span>

```syntax
GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/desktop/cabdownload?applicationId=10238467886765136388&cabIdHash=54ffb83a-e159-41d2-8158-f36f306cc01e HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="d1e17-148">応答</span><span class="sxs-lookup"><span data-stu-id="d1e17-148">Response</span></span>

<span data-ttu-id="d1e17-149">このメソッドは 302 (リダイレクト) 応答コードを返します。また、応答に含まれる **Location** ヘッダーは、CAB ファイルの Shared Access Signature (SAS) URI に割り当てられます。</span><span class="sxs-lookup"><span data-stu-id="d1e17-149">This method returns a 302 (redirect) response code, and the **Location** header in the response is assigned to the shared access signature (SAS) URI of the CAB file.</span></span> <span data-ttu-id="d1e17-150">呼び出し元はこの URI にリダイレクトされ、CAB ファイルが自動的にダウンロードされます。</span><span class="sxs-lookup"><span data-stu-id="d1e17-150">The caller is redirected to this URI to automatically download the CAB file.</span></span>

## <a name="related-topics"></a><span data-ttu-id="d1e17-151">関連トピック</span><span class="sxs-lookup"><span data-stu-id="d1e17-151">Related topics</span></span>

* [<span data-ttu-id="d1e17-152">[正常性] レポート</span><span class="sxs-lookup"><span data-stu-id="d1e17-152">Health report</span></span>](../publish/health-report.md)
* [<span data-ttu-id="d1e17-153">Microsoft Store サービスを使った分析データへのアクセス</span><span class="sxs-lookup"><span data-stu-id="d1e17-153">Access analytics data using Microsoft Store services</span></span>](access-analytics-data-using-windows-store-services.md)
* [<span data-ttu-id="d1e17-154">デスクトップ アプリケーションのエラー報告データの取得</span><span class="sxs-lookup"><span data-stu-id="d1e17-154">Get error reporting data for your desktop application</span></span>](get-desktop-application-error-reporting-data.md)
* [<span data-ttu-id="d1e17-155">デスクトップ アプリケーションのエラーに関する詳細情報の取得</span><span class="sxs-lookup"><span data-stu-id="d1e17-155">Get details for an error in your desktop application</span></span>](get-details-for-an-error-in-your-desktop-application.md)
* [<span data-ttu-id="d1e17-156">デスクトップ アプリケーションのエラーに関するスタック トレースの取得</span><span class="sxs-lookup"><span data-stu-id="d1e17-156">Get the stack trace for an error in your desktop application</span></span>](get-the-stack-trace-for-an-error-in-your-desktop-application.md)
