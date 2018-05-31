---
author: mcleanbyron
ms.assetid: 48D891CD-706C-4759-AB33-B0663774A829
description: Windows 7 や Windows 8.x のドライバー エラーに関する CAB ファイルをダウンロードするには、Microsoft Store 分析 API の以下のメソッドを使います。 このメソッドは、IHV のみを対象としています。
title: Windows 7 や Windows 8.x のドライバー エラーに関する CAB ファイルをダウンロードする
ms.author: mcleans
ms.date: 03/17/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, Microsoft Store 分析 API, CAB のダウンロード
ms.localizationpriority: medium
ms.openlocfilehash: 8640506ca954658ad41c5cf70015af52995f7b38
ms.sourcegitcommit: 1773bec0f46906d7b4d71451ba03f47017a87fec
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/17/2018
ms.locfileid: "1662332"
---
# <a name="download-the-cab-file-for-a-windows-7-or-windows-8x-driver-error"></a><span data-ttu-id="7f797-105">Windows 7 や Windows 8.x のドライバー エラーに関する CAB ファイルをダウンロードする</span><span class="sxs-lookup"><span data-stu-id="7f797-105">Download the CAB file for a Windows 7 or Windows 8.x driver error</span></span>

<span data-ttu-id="7f797-106">Windows 7 や Windows 8.x の特定のドライバー エラーに関連付けられている CAB ファイルをダウンロードするには、Microsoft Store 分析 API の以下のメソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="7f797-106">Use this method in the Microsoft Store analytics API to download the CAB file that is associated with a particular Windows 7/Windows 8.x driver error.</span></span> <span data-ttu-id="7f797-107">このメソッドを使うには、事前に [Windows 7 や Windows 8.x のドライバー エラーに関する詳細を取得する](get-details-for-a-windows-7-or-windows-8.x-driver-error.md)メソッドを使用し、ダウンロードする CAB ファイルの ID を取得しておく必要があります。</span><span class="sxs-lookup"><span data-stu-id="7f797-107">Before you can use this method, you must first use the [get details for a Windows 7 or Windows 8.x driver error](get-details-for-a-windows-7-or-windows-8.x-driver-error.md) method to retrieve the ID of the CAB file you want to download.</span></span>

<span data-ttu-id="7f797-108">Microsoft Store 分析 API に含まれる、[Windows 7 や Windows 8.x のドライバーに関するエラー報告データを取得する](get-error-reporting-data-for-windows-7-and-windows-8.x-drivers.md)メソッドおよび [Windows 7 や Windows 8.x のドライバー エラーに関する詳細を取得する](get-details-for-a-windows-7-or-windows-8.x-driver-error.md)メソッドを使うと、Windows 7 や Windows 8.x のドライバー エラーに関する他の情報を取得できます。</span><span class="sxs-lookup"><span data-stu-id="7f797-108">You can get other info about Windows 7/Windows 8.x driver errors by using the [get error reporting data for Windows 7 and Windows 8.x drivers](get-error-reporting-data-for-windows-7-and-windows-8.x-drivers.md) and [get details for a Windows 7 or Windows 8.x driver error](get-details-for-a-windows-7-or-windows-8.x-driver-error.md) methods in the Microsoft Store analytics API.</span></span>

> [!NOTE]
> <span data-ttu-id="7f797-109">このメソッドは、[Windows ハードウェア デベロッパー センター プログラム](https://msdn.microsoft.com/windows/hardware/drivers/dashboard/get-started-with-the-hardware-dashboard)に参加している開発者アカウントでのみ使用できます。</span><span class="sxs-lookup"><span data-stu-id="7f797-109">This method can only be used by developer accounts that belong to the [Windows Hardware Dev Center program](https://msdn.microsoft.com/windows/hardware/drivers/dashboard/get-started-with-the-hardware-dashboard).</span></span>

## <a name="prerequisites"></a><span data-ttu-id="7f797-110">前提条件</span><span class="sxs-lookup"><span data-stu-id="7f797-110">Prerequisites</span></span>

<span data-ttu-id="7f797-111">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="7f797-111">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="7f797-112">Microsoft Store 分析 API に関するすべての[前提条件](access-analytics-data-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="7f797-112">If you have not done so already, complete all the [prerequisites](access-analytics-data-using-windows-store-services.md#prerequisites) for the Microsoft Store analytics API.</span></span>
* <span data-ttu-id="7f797-113">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="7f797-113">[Obtain an Azure AD access token](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="7f797-114">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="7f797-114">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="7f797-115">トークンの有効期限が切れたら、新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="7f797-115">After the token expires, you can obtain a new one.</span></span>
* <span data-ttu-id="7f797-116">ダウンロードする CAB ファイルの ID を取得します。</span><span class="sxs-lookup"><span data-stu-id="7f797-116">Get the ID of the CAB file you want to download.</span></span> <span data-ttu-id="7f797-117">この ID を取得するには、[Windows 7 や Windows 8.x のドライバー エラーに関する詳細を取得する](get-details-for-a-windows-7-or-windows-8.x-driver-error.md)メソッドを使用して、特定のドライバー エラーに関する詳細情報を取得し、そのメソッドの応答本文にある **cabIdHash** の値を使います。</span><span class="sxs-lookup"><span data-stu-id="7f797-117">To get this ID, use the [get details for a Windows 7 or Windows 8.x driver error](get-details-for-a-windows-7-or-windows-8.x-driver-error.md) method to retrieve details for a specific driver error, and use the **cabIdHash** value in the response body of that method.</span></span>

## <a name="request"></a><span data-ttu-id="7f797-118">要求</span><span class="sxs-lookup"><span data-stu-id="7f797-118">Request</span></span>


### <a name="request-syntax"></a><span data-ttu-id="7f797-119">要求の構文</span><span class="sxs-lookup"><span data-stu-id="7f797-119">Request syntax</span></span>

| <span data-ttu-id="7f797-120">メソッド</span><span class="sxs-lookup"><span data-stu-id="7f797-120">Method</span></span> | <span data-ttu-id="7f797-121">要求 URI</span><span class="sxs-lookup"><span data-stu-id="7f797-121">Request URI</span></span>                                                          |
|--------|----------------------------------------------------------------------|
| <span data-ttu-id="7f797-122">GET</span><span class="sxs-lookup"><span data-stu-id="7f797-122">GET</span></span>    | ```https://manage.devcenter.microsoft.com/v1.0/my/analytics/ihvdriver/cabdownload``` |


### <a name="request-header"></a><span data-ttu-id="7f797-123">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="7f797-123">Request header</span></span>

| <span data-ttu-id="7f797-124">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="7f797-124">Header</span></span>        | <span data-ttu-id="7f797-125">型</span><span class="sxs-lookup"><span data-stu-id="7f797-125">Type</span></span>   | <span data-ttu-id="7f797-126">説明</span><span class="sxs-lookup"><span data-stu-id="7f797-126">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="7f797-127">Authorization</span><span class="sxs-lookup"><span data-stu-id="7f797-127">Authorization</span></span> | <span data-ttu-id="7f797-128">文字列</span><span class="sxs-lookup"><span data-stu-id="7f797-128">string</span></span> | <span data-ttu-id="7f797-129">必須。</span><span class="sxs-lookup"><span data-stu-id="7f797-129">Required.</span></span> <span data-ttu-id="7f797-130">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="7f797-130">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |
 

### <a name="request-parameters"></a><span data-ttu-id="7f797-131">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="7f797-131">Request parameters</span></span>

| <span data-ttu-id="7f797-132">パラメーター</span><span class="sxs-lookup"><span data-stu-id="7f797-132">Parameter</span></span>        | <span data-ttu-id="7f797-133">型</span><span class="sxs-lookup"><span data-stu-id="7f797-133">Type</span></span>   |  <span data-ttu-id="7f797-134">説明</span><span class="sxs-lookup"><span data-stu-id="7f797-134">Description</span></span>      |  <span data-ttu-id="7f797-135">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="7f797-135">Required</span></span>  |
|---------------|--------|---------------|------|
| <span data-ttu-id="7f797-136">cabIdHash</span><span class="sxs-lookup"><span data-stu-id="7f797-136">cabIdHash</span></span> | <span data-ttu-id="7f797-137">string</span><span class="sxs-lookup"><span data-stu-id="7f797-137">string</span></span> | <span data-ttu-id="7f797-138">ダウンロードする CAB ファイルの一意の ID です。</span><span class="sxs-lookup"><span data-stu-id="7f797-138">The unique ID of the CAB file you want to download.</span></span> <span data-ttu-id="7f797-139">この ID を取得するには、[Windows 7 や Windows 8.x のドライバー エラーに関する詳細を取得する](get-details-for-a-windows-7-or-windows-8.x-driver-error.md)メソッドを使用して、アプリの特定のエラーに関する詳細情報を取得し、そのメソッドの応答本文にある **cabIdHash** の値を使います。</span><span class="sxs-lookup"><span data-stu-id="7f797-139">To get this ID, use the [get details for a Windows 7 or Windows 8.x driver error](get-details-for-a-windows-7-or-windows-8.x-driver-error.md) method to retrieve details for a specific error in your app, and use the **cabIdHash** value in the response body of that method.</span></span> |  <span data-ttu-id="7f797-140">必須</span><span class="sxs-lookup"><span data-stu-id="7f797-140">Yes</span></span>  |

 
### <a name="request-example"></a><span data-ttu-id="7f797-141">要求の例</span><span class="sxs-lookup"><span data-stu-id="7f797-141">Request example</span></span>

<span data-ttu-id="7f797-142">次の例は、このメソッドを使って CAB ファイルをダウンロードする方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="7f797-142">The following example demonstrates how to download a CAB file using this method.</span></span>

```syntax
GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/ihvdriver/cabdownload?cabIdHash=c1a51104-d682-4230-be14-7278b18e3555 HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="7f797-143">応答</span><span class="sxs-lookup"><span data-stu-id="7f797-143">Response</span></span>

<span data-ttu-id="7f797-144">このメソッドは 302 (リダイレクト) 応答コードを返します。また、応答に含まれる **Location** ヘッダーは、CAB ファイルの Shared Access Signature (SAS) URI に割り当てられます。</span><span class="sxs-lookup"><span data-stu-id="7f797-144">This method returns a 302 (redirect) response code, and the **Location** header in the response is assigned to the shared access signature (SAS) URI of the CAB file.</span></span> <span data-ttu-id="7f797-145">呼び出し元はこの URI にリダイレクトされ、CAB ファイルが自動的にダウンロードされます。</span><span class="sxs-lookup"><span data-stu-id="7f797-145">The caller is redirected to this URI to automatically download the CAB file.</span></span>

## <a name="related-topics"></a><span data-ttu-id="7f797-146">関連トピック</span><span class="sxs-lookup"><span data-stu-id="7f797-146">Related topics</span></span>

* [<span data-ttu-id="7f797-147">Windows 7 や Windows 8.x のドライバーに関するエラー報告データを取得する</span><span class="sxs-lookup"><span data-stu-id="7f797-147">Get error reporting data for Windows 7 and Windows 8.x drivers</span></span>](get-error-reporting-data-for-windows-7-and-windows-8.x-drivers.md)
* [<span data-ttu-id="7f797-148">Windows 7 や Windows 8.x のドライバー エラーに関する詳細を取得する</span><span class="sxs-lookup"><span data-stu-id="7f797-148">Get details for a Windows 7 or Windows 8.x driver error</span></span>](get-details-for-a-windows-7-or-windows-8.x-driver-error.md)
