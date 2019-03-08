---
ms.assetid: 8D4AE532-22EF-4743-9555-A828B24B8F16
description: Microsoft Store 送信 API でこれらのメソッドを使用して、パートナー センター アカウントに登録されているアプリのデータを取得します。
title: アプリ データの入手
ms.date: 02/28/2018
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store 申請 API, アプリ データ
ms.localizationpriority: medium
ms.openlocfilehash: 23e392e2064a2a48089d1efadd1461c146e0d343
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57598897"
---
# <a name="get-app-data"></a><span data-ttu-id="dfe26-104">アプリ データの入手</span><span class="sxs-lookup"><span data-stu-id="dfe26-104">Get app data</span></span>

<span data-ttu-id="dfe26-105">Microsoft Store 送信 API で、次のメソッドを使用して、パートナー センター アカウント内の既存のアプリのデータを取得します。</span><span class="sxs-lookup"><span data-stu-id="dfe26-105">Use the following methods in the Microsoft Store submission API to get data for existing apps in your Partner Center account.</span></span> <span data-ttu-id="dfe26-106">Microsoft Store 申請 API の概要については、「[Microsoft Store サービスを使用した申請の作成と管理](create-and-manage-submissions-using-windows-store-services.md)」をご覧ください。この API を使用するための前提条件などの情報があります。</span><span class="sxs-lookup"><span data-stu-id="dfe26-106">For an introduction to the Microsoft Store submission API, including prerequisites for using the API, see [Create and manage submissions using Microsoft Store services](create-and-manage-submissions-using-windows-store-services.md).</span></span>

<span data-ttu-id="dfe26-107">これらのメソッドを使用する前に、アプリは必要があります、パートナー センター アカウントに既に存在します。</span><span class="sxs-lookup"><span data-stu-id="dfe26-107">Before you can use these methods, the app must already exist in your Partner Center account.</span></span> <span data-ttu-id="dfe26-108">アプリの提出を作成または管理する方法については、「[アプリ提出の管理](manage-app-submissions.md)」のメソッドを参照してください。</span><span class="sxs-lookup"><span data-stu-id="dfe26-108">To create or manage submissions for apps, see the methods in [Manage app submissions](manage-app-submissions.md).</span></span>

| <span data-ttu-id="dfe26-109">メソッド</span><span class="sxs-lookup"><span data-stu-id="dfe26-109">Method</span></span> | <span data-ttu-id="dfe26-110">URI</span><span class="sxs-lookup"><span data-stu-id="dfe26-110">URI</span></span>                                                                                             | <span data-ttu-id="dfe26-111">説明</span><span class="sxs-lookup"><span data-stu-id="dfe26-111">Description</span></span>                                                 |
|------- |------------------------------------------------------------------------------------------------ |------------------------------------------------------------ |
| <span data-ttu-id="dfe26-112">GET</span><span class="sxs-lookup"><span data-stu-id="dfe26-112">GET</span></span>    | `https://manage.devcenter.microsoft.com/v1.0/my/applications`                                   | [<span data-ttu-id="dfe26-113">すべてのアプリのデータを取得します。</span><span class="sxs-lookup"><span data-stu-id="dfe26-113">Get data for all your apps</span></span>](get-all-apps.md)               |
| <span data-ttu-id="dfe26-114">GET</span><span class="sxs-lookup"><span data-stu-id="dfe26-114">GET</span></span>    | `https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}`                   | [<span data-ttu-id="dfe26-115">特定のアプリのデータを取得します。</span><span class="sxs-lookup"><span data-stu-id="dfe26-115">Get data for a specific app</span></span>](get-an-app.md)                |
| <span data-ttu-id="dfe26-116">GET</span><span class="sxs-lookup"><span data-stu-id="dfe26-116">GET</span></span>    | `https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/listinappproducts` | [<span data-ttu-id="dfe26-117">アプリのアドオンを入手します。</span><span class="sxs-lookup"><span data-stu-id="dfe26-117">Get add-ons for an app</span></span>](get-add-ons-for-an-app.md)         |
| <span data-ttu-id="dfe26-118">GET</span><span class="sxs-lookup"><span data-stu-id="dfe26-118">GET</span></span>    | `https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/listflights`       | [<span data-ttu-id="dfe26-119">アプリのパッケージのフライトを取得します。</span><span class="sxs-lookup"><span data-stu-id="dfe26-119">Get package flights for an app</span></span>](get-flights-for-an-app.md) |

## <a name="prerequisites"></a><span data-ttu-id="dfe26-120">前提条件</span><span class="sxs-lookup"><span data-stu-id="dfe26-120">Prerequisites</span></span>

<span data-ttu-id="dfe26-121">Microsoft Store 申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)がまだ満たされていない場合は、ここに記載されているメソッドを使用する前に前提条件を整えてください。</span><span class="sxs-lookup"><span data-stu-id="dfe26-121">If you have not done so already, complete all the [prerequisites](create-and-manage-submissions-using-windows-store-services.md#prerequisites) for the Microsoft Store submission API before trying to use any of these methods.</span></span>

## <a name="data-resources"></a><span data-ttu-id="dfe26-122">データ リソース</span><span class="sxs-lookup"><span data-stu-id="dfe26-122">Data resources</span></span>

<span data-ttu-id="dfe26-123">アプリ データを取得するための Microsoft Store 申請 API のメソッドでは、次の JSON データ リソースが使われます。</span><span class="sxs-lookup"><span data-stu-id="dfe26-123">The Microsoft Store submission API methods for getting app data use the following JSON data resources.</span></span>

<span id="application_object" />

### <a name="application-resource"></a><span data-ttu-id="dfe26-124">アプリケーション リソース</span><span class="sxs-lookup"><span data-stu-id="dfe26-124">Application resource</span></span>

<span data-ttu-id="dfe26-125">このリソースは、アカウントに登録されているアプリを表します。</span><span class="sxs-lookup"><span data-stu-id="dfe26-125">This resource represents an app that is registered to your account.</span></span>

```json
{
  "id": "9NBLGGH4R315",
  "primaryName": "ApiTestApp",
  "packageFamilyName": "30481DevCenterAPITester.ApiTestAppForDevbox_ng6try80pwt52",
  "packageIdentityName": "30481DevCenterAPITester.ApiTestAppForDevbox",
  "publisherName": "CN=…",
  "firstPublishedDate": "1601-01-01T00:00:00Z",
  "lastPublishedApplicationSubmission": {
    "id": "1152921504621086517",
    "resourceLocation": "applications/9NBLGGH4R315/submissions/1152921504621086517"
  },
  "pendingApplicationSubmission": {
    "id": "1152921504621243487",
    "resourceLocation": "applications/9NBLGGH4R315/submissions/1152921504621243487"
  },
  "hasAdvancedListingPermission": true
}
```

<span data-ttu-id="dfe26-126">このリソースには、次の値があります。</span><span class="sxs-lookup"><span data-stu-id="dfe26-126">This resource has the following values.</span></span>

| <span data-ttu-id="dfe26-127">Value</span><span class="sxs-lookup"><span data-stu-id="dfe26-127">Value</span></span>           | <span data-ttu-id="dfe26-128">種類</span><span class="sxs-lookup"><span data-stu-id="dfe26-128">Type</span></span>    | <span data-ttu-id="dfe26-129">説明</span><span class="sxs-lookup"><span data-stu-id="dfe26-129">Description</span></span>       |
|-----------------|---------|---------------------|
| <span data-ttu-id="dfe26-130">id</span><span class="sxs-lookup"><span data-stu-id="dfe26-130">id</span></span>            | <span data-ttu-id="dfe26-131">string</span><span class="sxs-lookup"><span data-stu-id="dfe26-131">string</span></span>  | <span data-ttu-id="dfe26-132">アプリケーションのストア ID です。</span><span class="sxs-lookup"><span data-stu-id="dfe26-132">The Store ID of the app.</span></span> <span data-ttu-id="dfe26-133">ストア ID について詳しくは、「[アプリ ID の詳細の表示](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="dfe26-133">For more information about the Store ID, see [View app identity details](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details).</span></span>   |
| <span data-ttu-id="dfe26-134">primaryName</span><span class="sxs-lookup"><span data-stu-id="dfe26-134">primaryName</span></span>   | <span data-ttu-id="dfe26-135">string</span><span class="sxs-lookup"><span data-stu-id="dfe26-135">string</span></span>  | <span data-ttu-id="dfe26-136">アプリのプライマリ名です。</span><span class="sxs-lookup"><span data-stu-id="dfe26-136">The primary name of the app.</span></span>      |
| <span data-ttu-id="dfe26-137">packageFamilyName</span><span class="sxs-lookup"><span data-stu-id="dfe26-137">packageFamilyName</span></span> | <span data-ttu-id="dfe26-138">string</span><span class="sxs-lookup"><span data-stu-id="dfe26-138">string</span></span>  | <span data-ttu-id="dfe26-139">アプリのパッケージ ファミリ名です。</span><span class="sxs-lookup"><span data-stu-id="dfe26-139">The package family name of the app.</span></span>      |
| <span data-ttu-id="dfe26-140">packageIdentityName</span><span class="sxs-lookup"><span data-stu-id="dfe26-140">packageIdentityName</span></span>          | <span data-ttu-id="dfe26-141">string</span><span class="sxs-lookup"><span data-stu-id="dfe26-141">string</span></span>  | <span data-ttu-id="dfe26-142">アプリのパッケージ ID 名です。</span><span class="sxs-lookup"><span data-stu-id="dfe26-142">The package identity name of the app.</span></span>                       |
| <span data-ttu-id="dfe26-143">publisherName</span><span class="sxs-lookup"><span data-stu-id="dfe26-143">publisherName</span></span>       | <span data-ttu-id="dfe26-144">string</span><span class="sxs-lookup"><span data-stu-id="dfe26-144">string</span></span>  | <span data-ttu-id="dfe26-145">アプリに関連付けられている Windows 発行元 ID です。</span><span class="sxs-lookup"><span data-stu-id="dfe26-145">The Windows publisher ID that is associated with the app.</span></span> <span data-ttu-id="dfe26-146">これに対応して、**パッケージ/ユーザー/パブリッシャー**に表示される値、[アプリ id](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details)パートナー センターでアプリのページ。</span><span class="sxs-lookup"><span data-stu-id="dfe26-146">This corresponds to the **Package/Identity/Publisher** value that appears on the [App identity](https://msdn.microsoft.com/windows/uwp/publish/view-app-identity-details) page for the app in Partner Center.</span></span>       |
| <span data-ttu-id="dfe26-147">firstPublishedDate</span><span class="sxs-lookup"><span data-stu-id="dfe26-147">firstPublishedDate</span></span>      | <span data-ttu-id="dfe26-148">string</span><span class="sxs-lookup"><span data-stu-id="dfe26-148">string</span></span>  | <span data-ttu-id="dfe26-149">アプリが最初に発行された日付 (ISO 8601 形式)。</span><span class="sxs-lookup"><span data-stu-id="dfe26-149">The date the app was first published, in ISO 8601 format.</span></span>   |
| <span data-ttu-id="dfe26-150">lastPublishedApplicationSubmission</span><span class="sxs-lookup"><span data-stu-id="dfe26-150">lastPublishedApplicationSubmission</span></span>       | <span data-ttu-id="dfe26-151">オブジェクト</span><span class="sxs-lookup"><span data-stu-id="dfe26-151">object</span></span> | <span data-ttu-id="dfe26-152">アプリの最後に公開された申請に関する情報を提供する[申請のリソース](#submission_object)。</span><span class="sxs-lookup"><span data-stu-id="dfe26-152">A [submission resource](#submission_object) that provides information about the last published submission for the app.</span></span>    |
| <span data-ttu-id="dfe26-153">pendingApplicationSubmission</span><span class="sxs-lookup"><span data-stu-id="dfe26-153">pendingApplicationSubmission</span></span>        | <span data-ttu-id="dfe26-154">オブジェクト</span><span class="sxs-lookup"><span data-stu-id="dfe26-154">object</span></span>  |  <span data-ttu-id="dfe26-155">アプリの現在保留中の申請に関する情報を提供する[申請のリソース](#submission_object)。</span><span class="sxs-lookup"><span data-stu-id="dfe26-155">A [submission resource](#submission_object) that provides information about the current pending submission for the app.</span></span>   |   
| <span data-ttu-id="dfe26-156">hasAdvancedListingPermission</span><span class="sxs-lookup"><span data-stu-id="dfe26-156">hasAdvancedListingPermission</span></span>        | <span data-ttu-id="dfe26-157">boolean</span><span class="sxs-lookup"><span data-stu-id="dfe26-157">boolean</span></span>  |  <span data-ttu-id="dfe26-158">アプリの申請用に [gamingOptions](manage-app-submissions.md#gaming-options-object) または[トレーラー](manage-app-submissions.md#trailer-object)を構成できるかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="dfe26-158">Indicates whether you can configure the [gamingOptions](manage-app-submissions.md#gaming-options-object) or [trailers](manage-app-submissions.md#trailer-object) for submissions for the app.</span></span> <span data-ttu-id="dfe26-159">2017 年 5 月以降に作成された申請では、この値は true になります。</span><span class="sxs-lookup"><span data-stu-id="dfe26-159">This value is true for submissions created after May 2017.</span></span> |  |


<span id="add-on-object" />

### <a name="add-on-resource"></a><span data-ttu-id="dfe26-160">アドオン リソース</span><span class="sxs-lookup"><span data-stu-id="dfe26-160">Add-on resource</span></span>

<span data-ttu-id="dfe26-161">このリソースは、アドオンに関する情報を提供します。</span><span class="sxs-lookup"><span data-stu-id="dfe26-161">This resource provides information about an add-on.</span></span>

```json
{
    "inAppProductId": "9WZDNCRD7DLK"
}
```

<span data-ttu-id="dfe26-162">このリソースには、次の値があります。</span><span class="sxs-lookup"><span data-stu-id="dfe26-162">This resource has the following values.</span></span>

| <span data-ttu-id="dfe26-163">Value</span><span class="sxs-lookup"><span data-stu-id="dfe26-163">Value</span></span>           | <span data-ttu-id="dfe26-164">種類</span><span class="sxs-lookup"><span data-stu-id="dfe26-164">Type</span></span>    | <span data-ttu-id="dfe26-165">説明</span><span class="sxs-lookup"><span data-stu-id="dfe26-165">Description</span></span>         |
|-----------------|---------|----------------------|
| <span data-ttu-id="dfe26-166">inAppProductId</span><span class="sxs-lookup"><span data-stu-id="dfe26-166">inAppProductId</span></span>            | <span data-ttu-id="dfe26-167">string</span><span class="sxs-lookup"><span data-stu-id="dfe26-167">string</span></span>  | <span data-ttu-id="dfe26-168">アドオンのストア ID です。</span><span class="sxs-lookup"><span data-stu-id="dfe26-168">The Store ID of the add-on.</span></span> <span data-ttu-id="dfe26-169">この値は、ストアによって提供されます。</span><span class="sxs-lookup"><span data-stu-id="dfe26-169">This value is supplied by the Store.</span></span> <span data-ttu-id="dfe26-170">ストア ID の例は 9NBLGGH4TNMP です。</span><span class="sxs-lookup"><span data-stu-id="dfe26-170">An example Store ID is 9NBLGGH4TNMP.</span></span>   |


<span id="flight-object" />

### <a name="flight-resource"></a><span data-ttu-id="dfe26-171">フライト リソース</span><span class="sxs-lookup"><span data-stu-id="dfe26-171">Flight resource</span></span>

<span data-ttu-id="dfe26-172">このリソースは、アプリのパッケージ フライトに関する情報を提供します。</span><span class="sxs-lookup"><span data-stu-id="dfe26-172">This resource provides information about a package flight for an app.</span></span>

```json
{
    "flightId": "7bfc11d5-f710-47c5-8a98-e04bb5aad310",
    "friendlyName": "myflight",
    "lastPublishedFlightSubmission": {
        "id": "1152921504621086517",
        "resourceLocation": "flights/7bfc11d5-f710-47c5-8a98-e04bb5aad310/submissions/1152921504621086517"
    },
    "pendingFlightSubmission": {
        "id": "1152921504621215786",
        "resourceLocation": "flights/7bfc11d5-f710-47c5-8a98-e04bb5aad310/submissions/1152921504621215786"
    },
    "groupIds": [
        "1152921504606962205"
    ],
    "rankHigherThan": "Non-flighted submission"
}
```

<span data-ttu-id="dfe26-173">このリソースには、次の値があります。</span><span class="sxs-lookup"><span data-stu-id="dfe26-173">This resource has the following values.</span></span>

| <span data-ttu-id="dfe26-174">Value</span><span class="sxs-lookup"><span data-stu-id="dfe26-174">Value</span></span>           | <span data-ttu-id="dfe26-175">種類</span><span class="sxs-lookup"><span data-stu-id="dfe26-175">Type</span></span>    | <span data-ttu-id="dfe26-176">説明</span><span class="sxs-lookup"><span data-stu-id="dfe26-176">Description</span></span>           |
|-----------------|---------|------------------------|
| <span data-ttu-id="dfe26-177">flightId</span><span class="sxs-lookup"><span data-stu-id="dfe26-177">flightId</span></span>            | <span data-ttu-id="dfe26-178">string</span><span class="sxs-lookup"><span data-stu-id="dfe26-178">string</span></span>  | <span data-ttu-id="dfe26-179">パッケージ フライトの ID。</span><span class="sxs-lookup"><span data-stu-id="dfe26-179">The ID for the package flight.</span></span> <span data-ttu-id="dfe26-180">この値は、パートナー センターによって提供されます。</span><span class="sxs-lookup"><span data-stu-id="dfe26-180">This value is supplied by Partner Center.</span></span>  |
| <span data-ttu-id="dfe26-181">friendlyName</span><span class="sxs-lookup"><span data-stu-id="dfe26-181">friendlyName</span></span>           | <span data-ttu-id="dfe26-182">string</span><span class="sxs-lookup"><span data-stu-id="dfe26-182">string</span></span>  | <span data-ttu-id="dfe26-183">開発者によって指定されているパッケージ フライトの名前。</span><span class="sxs-lookup"><span data-stu-id="dfe26-183">The name of the package flight, as specified by the developer.</span></span>   |
| <span data-ttu-id="dfe26-184">lastPublishedFlightSubmission</span><span class="sxs-lookup"><span data-stu-id="dfe26-184">lastPublishedFlightSubmission</span></span>       | <span data-ttu-id="dfe26-185">オブジェクト</span><span class="sxs-lookup"><span data-stu-id="dfe26-185">object</span></span> | <span data-ttu-id="dfe26-186">パッケージ フライトの最後に公開された申請に関する情報を提供する[申請のリソース](#submission_object)。</span><span class="sxs-lookup"><span data-stu-id="dfe26-186">A [submission resource](#submission_object) that provides information about the last published submission for the package flight.</span></span>   |
| <span data-ttu-id="dfe26-187">pendingFlightSubmission</span><span class="sxs-lookup"><span data-stu-id="dfe26-187">pendingFlightSubmission</span></span>        | <span data-ttu-id="dfe26-188">オブジェクト</span><span class="sxs-lookup"><span data-stu-id="dfe26-188">object</span></span>  |  <span data-ttu-id="dfe26-189">パッケージ フライトの現在保留中の申請に関する情報を提供する[申請のリソース](#submission_object)。</span><span class="sxs-lookup"><span data-stu-id="dfe26-189">A [submission resource](#submission_object) that provides information about the current pending submission for the package flight.</span></span>  |    
| <span data-ttu-id="dfe26-190">groupIds</span><span class="sxs-lookup"><span data-stu-id="dfe26-190">groupIds</span></span>           | <span data-ttu-id="dfe26-191">array</span><span class="sxs-lookup"><span data-stu-id="dfe26-191">array</span></span>  | <span data-ttu-id="dfe26-192">パッケージ フライトに関連付けられているフライト グループの ID を含む文字列の配列。</span><span class="sxs-lookup"><span data-stu-id="dfe26-192">An array of strings that contain the IDs of the flight groups that are associated with the package flight.</span></span> <span data-ttu-id="dfe26-193">フライト グループについて詳しくは、「[パッケージ フライト](https://msdn.microsoft.com/windows/uwp/publish/package-flights)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="dfe26-193">For more information about flight groups, see [Package flights](https://msdn.microsoft.com/windows/uwp/publish/package-flights).</span></span>   |
| <span data-ttu-id="dfe26-194">rankHigherThan</span><span class="sxs-lookup"><span data-stu-id="dfe26-194">rankHigherThan</span></span>           | <span data-ttu-id="dfe26-195">string</span><span class="sxs-lookup"><span data-stu-id="dfe26-195">string</span></span>  | <span data-ttu-id="dfe26-196">現在のパッケージ フライトの次に低位のパッケージ フライトのフレンドリ名。</span><span class="sxs-lookup"><span data-stu-id="dfe26-196">The friendly name of the package flight that is ranked immediately lower than the current package flight.</span></span> <span data-ttu-id="dfe26-197">フライト グループのランク付けについて詳しくは、「[パッケージ フライト](https://msdn.microsoft.com/windows/uwp/publish/package-flights)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="dfe26-197">For more information about ranking flight groups, see [Package flights](https://msdn.microsoft.com/windows/uwp/publish/package-flights).</span></span>  |


<span id="submission_object" />

### <a name="submission-resource"></a><span data-ttu-id="dfe26-198">申請のリソース</span><span class="sxs-lookup"><span data-stu-id="dfe26-198">Submission resource</span></span>

<span data-ttu-id="dfe26-199">このリソースは、申請に関する情報を提供します。</span><span class="sxs-lookup"><span data-stu-id="dfe26-199">This resource provides information about a submission.</span></span> <span data-ttu-id="dfe26-200">次の例は、このリソースの書式設定を示しています。</span><span class="sxs-lookup"><span data-stu-id="dfe26-200">The following example demonstrates the format of this resource.</span></span>

```json
{
  "pendingApplicationSubmission": {
    "id": "1152921504621243487",
    "resourceLocation": "applications/9WZDNCRD9MMD/submissions/1152921504621243487"
  }
}
```

<span data-ttu-id="dfe26-201">このリソースには、次の値があります。</span><span class="sxs-lookup"><span data-stu-id="dfe26-201">This resource has the following values.</span></span>

| <span data-ttu-id="dfe26-202">Value</span><span class="sxs-lookup"><span data-stu-id="dfe26-202">Value</span></span>              | <span data-ttu-id="dfe26-203">種類</span><span class="sxs-lookup"><span data-stu-id="dfe26-203">Type</span></span>   | <span data-ttu-id="dfe26-204">説明</span><span class="sxs-lookup"><span data-stu-id="dfe26-204">Description</span></span>               |
|--------------------|--------|---------------------------|
| <span data-ttu-id="dfe26-205">id</span><span class="sxs-lookup"><span data-stu-id="dfe26-205">id</span></span>                 | <span data-ttu-id="dfe26-206">string</span><span class="sxs-lookup"><span data-stu-id="dfe26-206">string</span></span> | <span data-ttu-id="dfe26-207">申請 ID。</span><span class="sxs-lookup"><span data-stu-id="dfe26-207">The ID of the submission.</span></span> |
| <span data-ttu-id="dfe26-208">resourceLocation</span><span class="sxs-lookup"><span data-stu-id="dfe26-208">resourceLocation</span></span>   | <span data-ttu-id="dfe26-209">string</span><span class="sxs-lookup"><span data-stu-id="dfe26-209">string</span></span> | <span data-ttu-id="dfe26-210">申請の完全なデータを取得するために基本 ```https://manage.devcenter.microsoft.com/v1.0/my/``` 要求 URI に付加できる相対パス。</span><span class="sxs-lookup"><span data-stu-id="dfe26-210">A relative path that you can append to the base ```https://manage.devcenter.microsoft.com/v1.0/my/``` request URI to retrieve the complete data for the submission.</span></span> |

 
## <a name="related-topics"></a><span data-ttu-id="dfe26-211">関連トピック</span><span class="sxs-lookup"><span data-stu-id="dfe26-211">Related topics</span></span>

* [<span data-ttu-id="dfe26-212">作成し、Microsoft Store サービスを使用して送信の管理</span><span class="sxs-lookup"><span data-stu-id="dfe26-212">Create and manage submissions using Microsoft Store services</span></span>](create-and-manage-submissions-using-windows-store-services.md)
* [<span data-ttu-id="dfe26-213">Microsoft Store 送信 API を使用してアプリ送信を管理します。</span><span class="sxs-lookup"><span data-stu-id="dfe26-213">Manage app submissions using the Microsoft Store submission API</span></span>](manage-app-submissions.md)
* [<span data-ttu-id="dfe26-214">すべてのアプリを入手します。</span><span class="sxs-lookup"><span data-stu-id="dfe26-214">Get all apps</span></span>](get-all-apps.md)
* [<span data-ttu-id="dfe26-215">アプリを取得します。</span><span class="sxs-lookup"><span data-stu-id="dfe26-215">Get an app</span></span>](get-an-app.md)
* [<span data-ttu-id="dfe26-216">アプリのアドオンを入手します。</span><span class="sxs-lookup"><span data-stu-id="dfe26-216">Get add-ons for an app</span></span>](get-add-ons-for-an-app.md)
* [<span data-ttu-id="dfe26-217">アプリのパッケージのフライトを取得します。</span><span class="sxs-lookup"><span data-stu-id="dfe26-217">Get package flights for an app</span></span>](get-flights-for-an-app.md)
