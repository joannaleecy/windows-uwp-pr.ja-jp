---
description: Microsoft Store analytics API でこのメソッドを使用して、Xbox One、ゲームでエラー用の CAB ファイルをダウンロードします。
title: Xbox One ゲームのエラーの CAB ファイルをダウンロードする
ms.date: 11/06/2018
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store 分析 API, CAB のダウンロード
ms.localizationpriority: medium
ms.openlocfilehash: 736219533a254e6380c10600e97f707f15e37de6
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57604327"
---
# <a name="download-the-cab-file-for-an-error-in-your-xbox-one-game"></a><span data-ttu-id="833aa-104">Xbox One ゲームのエラーの CAB ファイルをダウンロードする</span><span class="sxs-lookup"><span data-stu-id="833aa-104">Download the CAB file for an error in your Xbox One game</span></span>

<span data-ttu-id="833aa-105">Microsoft Store analytics API でこのメソッドを使用すると、Xbox 開発者ポータル (XDP) を通じてが取り込まれますが、Xbox One のゲームの特定のエラーに関連付け、XDP Analytics パートナー センター ダッシュ ボードで使用可能である CAB ファイルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="833aa-105">Use this method in the Microsoft Store analytics API to download the CAB file that is associated with a particular error in your Xbox One game that was ingested through the Xbox Developer Portal (XDP) and available in the XDP Analytics Partner Center dashboard.</span></span> <span data-ttu-id="833aa-106">このメソッドは、過去 30 日間に発生したエラー用の CAB ファイルのみをダウンロードできます。</span><span class="sxs-lookup"><span data-stu-id="833aa-106">This method can only download the CAB file for an error that occurred in the last 30 days.</span></span>

<span data-ttu-id="833aa-107">最初に使用する必要があるこのメソッドを使用する前に、[ゲーム、Xbox One でエラーの詳細を取得](get-details-for-an-error-in-your-xbox-one-game.md)をダウンロードする CAB ファイルの ID を取得します。</span><span class="sxs-lookup"><span data-stu-id="833aa-107">Before you can use this method, you must first use the [get details for an error in your Xbox One game](get-details-for-an-error-in-your-xbox-one-game.md) method to retrieve the ID of the CAB file you want to download.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="833aa-108">前提条件</span><span class="sxs-lookup"><span data-stu-id="833aa-108">Prerequisites</span></span>


<span data-ttu-id="833aa-109">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="833aa-109">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="833aa-110">Microsoft Store 分析 API に関するすべての[前提条件](access-analytics-data-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="833aa-110">If you have not done so already, complete all the [prerequisites](access-analytics-data-using-windows-store-services.md#prerequisites) for the Microsoft Store analytics API.</span></span>
* <span data-ttu-id="833aa-111">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="833aa-111">[Obtain an Azure AD access token](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="833aa-112">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="833aa-112">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="833aa-113">トークンの有効期限が切れたら新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="833aa-113">After the token expires, you can obtain a new one.</span></span>
* <span data-ttu-id="833aa-114">ダウンロードする CAB ファイルの ID を取得します。</span><span class="sxs-lookup"><span data-stu-id="833aa-114">Get the ID of the CAB file you want to download.</span></span> <span data-ttu-id="833aa-115">この ID を取得するには、使用、[ゲーム、Xbox One でエラーの詳細を取得](get-details-for-an-error-in-your-xbox-one-game.md)アプリでは、特定のエラーの詳細を取得し、使用するメソッド、 **cabId**メソッドの応答本文内の値。</span><span class="sxs-lookup"><span data-stu-id="833aa-115">To get this ID, use the [get details for an error in your Xbox One game](get-details-for-an-error-in-your-xbox-one-game.md) method to retrieve details for a specific error in your app, and use the **cabId** value in the response body of that method.</span></span>

## <a name="request"></a><span data-ttu-id="833aa-116">要求</span><span class="sxs-lookup"><span data-stu-id="833aa-116">Request</span></span>


### <a name="request-syntax"></a><span data-ttu-id="833aa-117">要求の構文</span><span class="sxs-lookup"><span data-stu-id="833aa-117">Request syntax</span></span>

| <span data-ttu-id="833aa-118">メソッド</span><span class="sxs-lookup"><span data-stu-id="833aa-118">Method</span></span> | <span data-ttu-id="833aa-119">要求 URI</span><span class="sxs-lookup"><span data-stu-id="833aa-119">Request URI</span></span>                                                          |
|--------|----------------------------------------------------------------------|
| <span data-ttu-id="833aa-120">GET</span><span class="sxs-lookup"><span data-stu-id="833aa-120">GET</span></span>    | ```https://manage.devcenter.microsoft.com/v1.0/my/analytics/xbox/cabdownload``` |


### <a name="request-header"></a><span data-ttu-id="833aa-121">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="833aa-121">Request header</span></span>

| <span data-ttu-id="833aa-122">Header</span><span class="sxs-lookup"><span data-stu-id="833aa-122">Header</span></span>        | <span data-ttu-id="833aa-123">種類</span><span class="sxs-lookup"><span data-stu-id="833aa-123">Type</span></span>   | <span data-ttu-id="833aa-124">説明</span><span class="sxs-lookup"><span data-stu-id="833aa-124">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="833aa-125">Authorization</span><span class="sxs-lookup"><span data-stu-id="833aa-125">Authorization</span></span> | <span data-ttu-id="833aa-126">string</span><span class="sxs-lookup"><span data-stu-id="833aa-126">string</span></span> | <span data-ttu-id="833aa-127">必須。</span><span class="sxs-lookup"><span data-stu-id="833aa-127">Required.</span></span> <span data-ttu-id="833aa-128">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="833aa-128">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="833aa-129">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="833aa-129">Request parameters</span></span>

| <span data-ttu-id="833aa-130">パラメーター</span><span class="sxs-lookup"><span data-stu-id="833aa-130">Parameter</span></span>        | <span data-ttu-id="833aa-131">種類</span><span class="sxs-lookup"><span data-stu-id="833aa-131">Type</span></span>   |  <span data-ttu-id="833aa-132">説明</span><span class="sxs-lookup"><span data-stu-id="833aa-132">Description</span></span>      |  <span data-ttu-id="833aa-133">必須</span><span class="sxs-lookup"><span data-stu-id="833aa-133">Required</span></span>  |
|---------------|--------|---------------|------|
| <span data-ttu-id="833aa-134">applicationId</span><span class="sxs-lookup"><span data-stu-id="833aa-134">applicationId</span></span> | <span data-ttu-id="833aa-135">string</span><span class="sxs-lookup"><span data-stu-id="833aa-135">string</span></span> | <span data-ttu-id="833aa-136">CAB ファイルをダウンロードする Xbox One のゲームの製品の ID。</span><span class="sxs-lookup"><span data-stu-id="833aa-136">The product ID of the Xbox One game for which you are downloading the CAB file.</span></span> <span data-ttu-id="833aa-137">ゲームの製品 ID を取得するには、Xbox デベロッパー ポータル (XDP) で目的のゲームに移動し、URL から製品 ID を取得します。</span><span class="sxs-lookup"><span data-stu-id="833aa-137">To get the product ID of your game, navigate to your game in the Xbox Developer Portal (XDP) and retrieve the product ID from the URL.</span></span> <span data-ttu-id="833aa-138">または、パートナー センターの Windows analytics レポートから、正常性データをダウンロードする場合は、.tsv ファイルで製品 ID が含まれます。</span><span class="sxs-lookup"><span data-stu-id="833aa-138">Alternatively, if you download your health data from the Windows Partner Center analytics report, the product ID is included in the .tsv file.</span></span> |  <span data-ttu-id="833aa-139">〇</span><span class="sxs-lookup"><span data-stu-id="833aa-139">Yes</span></span>  |
| <span data-ttu-id="833aa-140">cabId</span><span class="sxs-lookup"><span data-stu-id="833aa-140">cabId</span></span> | <span data-ttu-id="833aa-141">string</span><span class="sxs-lookup"><span data-stu-id="833aa-141">string</span></span> | <span data-ttu-id="833aa-142">ダウンロードする CAB ファイルの一意の ID です。</span><span class="sxs-lookup"><span data-stu-id="833aa-142">The unique ID of the CAB file you want to download.</span></span> <span data-ttu-id="833aa-143">この ID を取得するには、使用、[ゲーム、Xbox One でエラーの詳細を取得](get-details-for-an-error-in-your-xbox-one-game.md)アプリでは、特定のエラーの詳細を取得し、使用するメソッド、 **cabId**メソッドの応答本文内の値。</span><span class="sxs-lookup"><span data-stu-id="833aa-143">To get this ID, use the [get details for an error in your Xbox One game](get-details-for-an-error-in-your-xbox-one-game.md) method to retrieve details for a specific error in your app, and use the **cabId** value in the response body of that method.</span></span> |  <span data-ttu-id="833aa-144">〇</span><span class="sxs-lookup"><span data-stu-id="833aa-144">Yes</span></span>  |

 
### <a name="request-example"></a><span data-ttu-id="833aa-145">要求の例</span><span class="sxs-lookup"><span data-stu-id="833aa-145">Request example</span></span>

<span data-ttu-id="833aa-146">次の例は、このメソッドを使って CAB ファイルをダウンロードする方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="833aa-146">The following example demonstrates how to download a CAB file using this method.</span></span> <span data-ttu-id="833aa-147">*applicationId* および *cabId* パラメーターを、アプリの適切な値に置き換えてください。</span><span class="sxs-lookup"><span data-stu-id="833aa-147">Replace the *applicationId* and *cabId* parameters with the appropriate values for your app.</span></span>

```syntax
GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/xbox/cabdownload?applicationId=BRRT4NJ9B3D1&cabId=1336373323853 HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="833aa-148">応答</span><span class="sxs-lookup"><span data-stu-id="833aa-148">Response</span></span>

<span data-ttu-id="833aa-149">このメソッドは 302 (リダイレクト) 応答コードを返します。また、応答に含まれる **Location** ヘッダーは、CAB ファイルの Shared Access Signature (SAS) URI に割り当てられます。</span><span class="sxs-lookup"><span data-stu-id="833aa-149">This method returns a 302 (redirect) response code, and the **Location** header in the response is assigned to the shared access signature (SAS) URI of the CAB file.</span></span> <span data-ttu-id="833aa-150">呼び出し元はこの URI にリダイレクトされ、CAB ファイルが自動的にダウンロードされます。</span><span class="sxs-lookup"><span data-stu-id="833aa-150">The caller is redirected to this URI to automatically download the CAB file.</span></span>

## <a name="related-topics"></a><span data-ttu-id="833aa-151">関連トピック</span><span class="sxs-lookup"><span data-stu-id="833aa-151">Related topics</span></span>

* [<span data-ttu-id="833aa-152">Microsoft Store サービスを使用して分析データにアクセス</span><span class="sxs-lookup"><span data-stu-id="833aa-152">Access analytics data using Microsoft Store services</span></span>](access-analytics-data-using-windows-store-services.md)
* [<span data-ttu-id="833aa-153">レポート データを Xbox One のエラーが発生するゲーム</span><span class="sxs-lookup"><span data-stu-id="833aa-153">Get error reporting data for your Xbox One game</span></span>](get-error-reporting-data-for-your-xbox-one-game.md)
* [<span data-ttu-id="833aa-154">ゲーム、Xbox One でエラーの詳細を取得します。</span><span class="sxs-lookup"><span data-stu-id="833aa-154">Get details for an error in your Xbox One game</span></span>](get-details-for-an-error-in-your-xbox-one-game.md)
* [<span data-ttu-id="833aa-155">ゲーム、Xbox One でエラーのスタック トレースを取得します。</span><span class="sxs-lookup"><span data-stu-id="833aa-155">Get the stack trace for an error in your Xbox One game</span></span>](get-the-stack-trace-for-an-error-in-your-xbox-one-game.md)
