---
author: Xansky
description: Xbox One ゲームのエラーに関する CAB ファイルをダウンロードするのに、Microsoft Store 分析 API の以下のメソッドを使用します。
title: Xbox One ゲームのエラーに関する CAB ファイルをダウンロードします。
ms.author: mhopkins
ms.date: 11/06/2018
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store 分析 API, CAB のダウンロード
ms.localizationpriority: medium
ms.openlocfilehash: ad1e3339fe50087c3a3d8cdcf3a99f27c1c868df
ms.sourcegitcommit: ed0304b8a214c03b8aab74b8ef12c9f82b8e3c5f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/19/2018
ms.locfileid: "7302781"
---
# <a name="download-the-cab-file-for-an-error-in-your-xbox-one-game"></a><span data-ttu-id="c9af1-104">Xbox One ゲームのエラーに関する CAB ファイルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="c9af1-104">Download the CAB file for an error in your Xbox One game</span></span>

<span data-ttu-id="c9af1-105">Xbox デベロッパー ポータル (XDP) を通じてが取り込まれる、Xbox One ゲームの特定のエラーに関連付けられていると、XDP 分析のパートナー センター ダッシュ ボードで利用可能な CAB ファイルをダウンロードするのに、Microsoft Store 分析 API の以下のメソッドを使用します。</span><span class="sxs-lookup"><span data-stu-id="c9af1-105">Use this method in the Microsoft Store analytics API to download the CAB file that is associated with a particular error in your Xbox One game that was ingested through the Xbox Developer Portal (XDP) and available in the XDP Analytics Partner Center dashboard.</span></span> <span data-ttu-id="c9af1-106">このメソッドは、過去 30 日以内に発生したエラーの CAB ファイルのみをダウンロードできます。</span><span class="sxs-lookup"><span data-stu-id="c9af1-106">This method can only download the CAB file for an error that occurred in the last 30 days.</span></span>

<span data-ttu-id="c9af1-107">以下のメソッドを使用する前に、まずは、ダウンロードする CAB ファイルの ID を取得するのにことで、 [Xbox One ゲームのエラーに関する詳細を取得する](get-details-for-an-error-in-your-xbox-one-game.md)メソッドを使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c9af1-107">Before you can use this method, you must first use the [get details for an error in your Xbox One game](get-details-for-an-error-in-your-xbox-one-game.md) method to retrieve the ID of the CAB file you want to download.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="c9af1-108">前提条件</span><span class="sxs-lookup"><span data-stu-id="c9af1-108">Prerequisites</span></span>


<span data-ttu-id="c9af1-109">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="c9af1-109">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="c9af1-110">Microsoft Store 分析 API に関するすべての[前提条件](access-analytics-data-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="c9af1-110">If you have not done so already, complete all the [prerequisites](access-analytics-data-using-windows-store-services.md#prerequisites) for the Microsoft Store analytics API.</span></span>
* <span data-ttu-id="c9af1-111">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="c9af1-111">[Obtain an Azure AD access token](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="c9af1-112">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="c9af1-112">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="c9af1-113">トークンの有効期限が切れたら、新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="c9af1-113">After the token expires, you can obtain a new one.</span></span>
* <span data-ttu-id="c9af1-114">ダウンロードする CAB ファイルの ID を取得します。</span><span class="sxs-lookup"><span data-stu-id="c9af1-114">Get the ID of the CAB file you want to download.</span></span> <span data-ttu-id="c9af1-115">この ID を取得するには、[ゲームの Xbox One でのエラーに関する詳細を取得する](get-details-for-an-error-in-your-xbox-one-game.md)メソッドを使用して、アプリの特定のエラーに関する詳細情報を取得し、そのメソッドの応答本文で**cabId**値を使用します。</span><span class="sxs-lookup"><span data-stu-id="c9af1-115">To get this ID, use the [get details for an error in your Xbox One game](get-details-for-an-error-in-your-xbox-one-game.md) method to retrieve details for a specific error in your app, and use the **cabId** value in the response body of that method.</span></span>

## <a name="request"></a><span data-ttu-id="c9af1-116">要求</span><span class="sxs-lookup"><span data-stu-id="c9af1-116">Request</span></span>


### <a name="request-syntax"></a><span data-ttu-id="c9af1-117">要求の構文</span><span class="sxs-lookup"><span data-stu-id="c9af1-117">Request syntax</span></span>

| <span data-ttu-id="c9af1-118">メソッド</span><span class="sxs-lookup"><span data-stu-id="c9af1-118">Method</span></span> | <span data-ttu-id="c9af1-119">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c9af1-119">Request URI</span></span>                                                          |
|--------|----------------------------------------------------------------------|
| <span data-ttu-id="c9af1-120">GET</span><span class="sxs-lookup"><span data-stu-id="c9af1-120">GET</span></span>    | ```https://manage.devcenter.microsoft.com/v1.0/my/analytics/xbox/cabdownload``` |


### <a name="request-header"></a><span data-ttu-id="c9af1-121">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="c9af1-121">Request header</span></span>

| <span data-ttu-id="c9af1-122">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="c9af1-122">Header</span></span>        | <span data-ttu-id="c9af1-123">型</span><span class="sxs-lookup"><span data-stu-id="c9af1-123">Type</span></span>   | <span data-ttu-id="c9af1-124">説明</span><span class="sxs-lookup"><span data-stu-id="c9af1-124">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="c9af1-125">Authorization</span><span class="sxs-lookup"><span data-stu-id="c9af1-125">Authorization</span></span> | <span data-ttu-id="c9af1-126">string</span><span class="sxs-lookup"><span data-stu-id="c9af1-126">string</span></span> | <span data-ttu-id="c9af1-127">必須。</span><span class="sxs-lookup"><span data-stu-id="c9af1-127">Required.</span></span> <span data-ttu-id="c9af1-128">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="c9af1-128">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="c9af1-129">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="c9af1-129">Request parameters</span></span>

| <span data-ttu-id="c9af1-130">パラメーター</span><span class="sxs-lookup"><span data-stu-id="c9af1-130">Parameter</span></span>        | <span data-ttu-id="c9af1-131">型</span><span class="sxs-lookup"><span data-stu-id="c9af1-131">Type</span></span>   |  <span data-ttu-id="c9af1-132">説明</span><span class="sxs-lookup"><span data-stu-id="c9af1-132">Description</span></span>      |  <span data-ttu-id="c9af1-133">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="c9af1-133">Required</span></span>  |
|---------------|--------|---------------|------|
| <span data-ttu-id="c9af1-134">applicationId</span><span class="sxs-lookup"><span data-stu-id="c9af1-134">applicationId</span></span> | <span data-ttu-id="c9af1-135">string</span><span class="sxs-lookup"><span data-stu-id="c9af1-135">string</span></span> | <span data-ttu-id="c9af1-136">CAB ファイルをダウンロードする Xbox One ゲームの製品 ID です。</span><span class="sxs-lookup"><span data-stu-id="c9af1-136">The product ID of the Xbox One game for which you are downloading the CAB file.</span></span> <span data-ttu-id="c9af1-137">ゲームの製品 ID を取得するには、Xbox デベロッパー ポータル (XDP) で目的のゲームに移動し、URL から製品 ID を取得します。</span><span class="sxs-lookup"><span data-stu-id="c9af1-137">To get the product ID of your game, navigate to your game in the Xbox Developer Portal (XDP) and retrieve the product ID from the URL.</span></span> <span data-ttu-id="c9af1-138">または、Windows パートナー センターの分析レポートから正常性データをダウンロードした場合、製品 ID は .tsv ファイルに含まれています。</span><span class="sxs-lookup"><span data-stu-id="c9af1-138">Alternatively, if you download your health data from the Windows Partner Center analytics report, the product ID is included in the .tsv file.</span></span> |  <span data-ttu-id="c9af1-139">必須</span><span class="sxs-lookup"><span data-stu-id="c9af1-139">Yes</span></span>  |
| <span data-ttu-id="c9af1-140">cabId</span><span class="sxs-lookup"><span data-stu-id="c9af1-140">cabId</span></span> | <span data-ttu-id="c9af1-141">string</span><span class="sxs-lookup"><span data-stu-id="c9af1-141">string</span></span> | <span data-ttu-id="c9af1-142">ダウンロードする CAB ファイルの一意の ID です。</span><span class="sxs-lookup"><span data-stu-id="c9af1-142">The unique ID of the CAB file you want to download.</span></span> <span data-ttu-id="c9af1-143">この ID を取得するには、[ゲームの Xbox One でのエラーに関する詳細を取得する](get-details-for-an-error-in-your-xbox-one-game.md)メソッドを使用して、アプリの特定のエラーに関する詳細情報を取得し、そのメソッドの応答本文で**cabId**値を使用します。</span><span class="sxs-lookup"><span data-stu-id="c9af1-143">To get this ID, use the [get details for an error in your Xbox One game](get-details-for-an-error-in-your-xbox-one-game.md) method to retrieve details for a specific error in your app, and use the **cabId** value in the response body of that method.</span></span> |  <span data-ttu-id="c9af1-144">はい</span><span class="sxs-lookup"><span data-stu-id="c9af1-144">Yes</span></span>  |

 
### <a name="request-example"></a><span data-ttu-id="c9af1-145">要求の例</span><span class="sxs-lookup"><span data-stu-id="c9af1-145">Request example</span></span>

<span data-ttu-id="c9af1-146">次の例は、このメソッドを使って CAB ファイルをダウンロードする方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="c9af1-146">The following example demonstrates how to download a CAB file using this method.</span></span> <span data-ttu-id="c9af1-147">*applicationId* および *cabId* パラメーターを、アプリの適切な値に置き換えてください。</span><span class="sxs-lookup"><span data-stu-id="c9af1-147">Replace the *applicationId* and *cabId* parameters with the appropriate values for your app.</span></span>

```syntax
GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/xbox/cabdownload?applicationId=BRRT4NJ9B3D1&cabId=1336373323853 HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="c9af1-148">応答</span><span class="sxs-lookup"><span data-stu-id="c9af1-148">Response</span></span>

<span data-ttu-id="c9af1-149">このメソッドは 302 (リダイレクト) 応答コードを返します。また、応答に含まれる **Location** ヘッダーは、CAB ファイルの Shared Access Signature (SAS) URI に割り当てられます。</span><span class="sxs-lookup"><span data-stu-id="c9af1-149">This method returns a 302 (redirect) response code, and the **Location** header in the response is assigned to the shared access signature (SAS) URI of the CAB file.</span></span> <span data-ttu-id="c9af1-150">呼び出し元はこの URI にリダイレクトされ、CAB ファイルが自動的にダウンロードされます。</span><span class="sxs-lookup"><span data-stu-id="c9af1-150">The caller is redirected to this URI to automatically download the CAB file.</span></span>

## <a name="related-topics"></a><span data-ttu-id="c9af1-151">関連トピック</span><span class="sxs-lookup"><span data-stu-id="c9af1-151">Related topics</span></span>

* [<span data-ttu-id="c9af1-152">Microsoft Store サービスを使った分析データへのアクセス</span><span class="sxs-lookup"><span data-stu-id="c9af1-152">Access analytics data using Microsoft Store services</span></span>](access-analytics-data-using-windows-store-services.md)
* [<span data-ttu-id="c9af1-153">ゲームの Xbox One に関するエラー報告データを取得します。</span><span class="sxs-lookup"><span data-stu-id="c9af1-153">Get error reporting data for your Xbox One game</span></span>](get-error-reporting-data-for-your-xbox-one-game.md)
* [<span data-ttu-id="c9af1-154">ゲームの Xbox One のエラーに関する詳細を取得します。</span><span class="sxs-lookup"><span data-stu-id="c9af1-154">Get details for an error in your Xbox One game</span></span>](get-details-for-an-error-in-your-xbox-one-game.md)
* [<span data-ttu-id="c9af1-155">ゲームに Xbox One でのエラーに関するスタック トレースを取得します。</span><span class="sxs-lookup"><span data-stu-id="c9af1-155">Get the stack trace for an error in your Xbox One game</span></span>](get-the-stack-trace-for-an-error-in-your-xbox-one-game.md)