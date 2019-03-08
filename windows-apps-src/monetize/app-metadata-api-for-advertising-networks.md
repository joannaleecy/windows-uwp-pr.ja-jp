---
description: アプリのメタデータ REST API を使用して、アプリの特定の種類のメタデータにアクセスする方法について説明します。 この API は、広告ネットワークで使用することにより、Microsoft Store 内のアプリに関する情報を取得し、広告主への広告スペースの販売を向上させることを目的としています。
title: 広告ネットワーク用のアプリのメタデータ API
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10、UWP、広告ネットワーク、アプリのメタデータ
ms.assetid: f0904086-d61f-4adb-82b6-25968cbec7f3
ms.localizationpriority: medium
ms.openlocfilehash: 0122c2fbe1e0e9905a8509694c4a589e04e33247
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57621137"
---
# <a name="app-metadata-api-for-advertising-networks"></a><span data-ttu-id="5322d-105">広告ネットワーク用のアプリのメタデータ API</span><span class="sxs-lookup"><span data-stu-id="5322d-105">App metadata API for advertising networks</span></span>

<span data-ttu-id="5322d-106">広告ネットワークでは、*アプリのメタデータ API* を使用して、プログラムによって Microsoft Store 内のアプリに関するメタデータを取得します。これには、アプリの Store 登録情報の説明やカテゴリ、アプリが 13 歳未満の子供を対象とするかどうかなどの詳細が含まれます。</span><span class="sxs-lookup"><span data-stu-id="5322d-106">Advertising networks can use the *app metadata API* to programmatically retrieve metadata about apps in the Microsoft Store, including details such as the description and category for the Store listing of the app and whether the app is targeted to children under 13.</span></span> <span data-ttu-id="5322d-107">この API へのアクセスは、現在、Microsoft によって API へのアクセス許可が付与されている開発者に制限されています。</span><span class="sxs-lookup"><span data-stu-id="5322d-107">Access to this API is currently restricted to developers who are granted permission to the API by Microsoft.</span></span>

<span data-ttu-id="5322d-108">この記事では、[アプリのメタデータ API ポータル](https://admetadata.portal.azure-api.net/)を使用して API へのアクセスを要求する方法、API にアクセスするためのサブスクリプション キーを取得する方法、API を呼び出す方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="5322d-108">This article provides instructions for how to request access to the API using the [app metadata API portal](https://admetadata.portal.azure-api.net/), how to get your subscription key to access the API, and how to call the API.</span></span>

## <a name="request-access"></a><span data-ttu-id="5322d-109">アクセスを要求する</span><span class="sxs-lookup"><span data-stu-id="5322d-109">Request access</span></span>

<span data-ttu-id="5322d-110">広告ネットワークでは、次の手順に従って、アプリのメタデータ API へのアクセスを要求できます。</span><span class="sxs-lookup"><span data-stu-id="5322d-110">Advertising networks can request access to the app metadata API by following these instructions:</span></span>

1. <span data-ttu-id="5322d-111">アプリのメタデータ API ポータルの [https://admetadata.portal.azure-api.net/signup](https://admetadata.portal.azure-api.net/signup) ページに移動します。</span><span class="sxs-lookup"><span data-stu-id="5322d-111">Go to the [https://admetadata.portal.azure-api.net/signup](https://admetadata.portal.azure-api.net/signup) page of the app metadata API portal.</span></span>
2. <span data-ttu-id="5322d-112">必要な情報を入力し、**[サインアップ]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="5322d-112">Enter the required information and click the **Sign up** button.</span></span>
3. <span data-ttu-id="5322d-113">同じサイトで、**[製品]** タブをクリックし、**[広告用のアプリの詳細]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="5322d-113">On the same site, click the **Products** tab and then click **App details for advertising**.</span></span>
4. <span data-ttu-id="5322d-114">次のページで、**[サブスクライブ]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="5322d-114">On the next page, click the **Subscribe** button.</span></span> <span data-ttu-id="5322d-115">これにより、アプリのメタデータ API へのアクセスの要求が Microsoft に送信されます。</span><span class="sxs-lookup"><span data-stu-id="5322d-115">This submits your request to access the app metadata API to Microsoft.</span></span>

<span data-ttu-id="5322d-116">要求が送信されてから、約 24 時間以内に、要求が許可されたか、拒否されたかをメールで通知します。</span><span class="sxs-lookup"><span data-stu-id="5322d-116">After your request is submitted, you will receive an email within approximately 24 hours that notifies you if your request was granted or denied.</span></span>

<span id="get-key" />

## <a name="get-your-subscription-key"></a><span data-ttu-id="5322d-117">サブスクリプション キーを取得する</span><span class="sxs-lookup"><span data-stu-id="5322d-117">Get your subscription key</span></span>

<span data-ttu-id="5322d-118">アプリのメタデータ API へのアクセスが許可されている場合は、次の手順に従ってサブスクリプション キーを取得します。</span><span class="sxs-lookup"><span data-stu-id="5322d-118">If you are granted access to the app metadata API, follow these instructions to get your subscription key.</span></span> <span data-ttu-id="5322d-119">API の呼び出しの要求ヘッダーでこのキーを渡す必要があります。</span><span class="sxs-lookup"><span data-stu-id="5322d-119">You must pass this key in the request header of calls to the API.</span></span>

1. <span data-ttu-id="5322d-120">アプリのメタデータ API ポータルの [https://admetadata.portal.azure-api.net/signin](https://admetadata.portal.azure-api.net/signin) ページに移動し、メール アドレスとパスワードでサインインします。</span><span class="sxs-lookup"><span data-stu-id="5322d-120">Go to the [https://admetadata.portal.azure-api.net/signin](https://admetadata.portal.azure-api.net/signin) page of the app metadata API portal and sign in with your email and password.</span></span>
2. <span data-ttu-id="5322d-121">サイトの右上隅にある自分の名前をクリックし、**[プロファイル]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="5322d-121">Click your name in the top-right corner of the site and then click **Profile**.</span></span>
3. <span data-ttu-id="5322d-122">ページの **[サブスクリプション]** セクションで、**[主キー]** の横にある **[表示]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="5322d-122">In the **Your subscriptions** section of the page, click **Show** next to **Primary key**.</span></span> <span data-ttu-id="5322d-123">これが自分のサブスクリプション キーです。</span><span class="sxs-lookup"><span data-stu-id="5322d-123">This is your subscription key.</span></span> <span data-ttu-id="5322d-124">後で API を呼び出すときに使用できるように、このキーをコピーします。</span><span class="sxs-lookup"><span data-stu-id="5322d-124">Copy the key so you can use it later when you call the API.</span></span>

<span id="call-the-api" />

## <a name="call-the-api"></a><span data-ttu-id="5322d-125">API を呼び出す</span><span class="sxs-lookup"><span data-stu-id="5322d-125">Call the API</span></span>

<span data-ttu-id="5322d-126">サブスクリプション キーを確認したら、任意のプログラミング言語から、HTTP REST 構文を使用して、API を呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="5322d-126">After you have your subscription key, you are ready to call the API using HTTP REST syntax from the programming language of your choice.</span></span> <span data-ttu-id="5322d-127">API の構文については、後の「[API 構文](#syntax)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5322d-127">For information about the syntax of the API, see the [API syntax](#syntax) section below.</span></span> <span data-ttu-id="5322d-128">C#、JavaScript、Python、およびその他のいくつかの言語でコード例を表示するには、アプリのメタデータ API ポータルの **[API]** タブをクリックし、**[アプリの詳細]** をクリックして、ページの下部にある **[コード サンプル]** セクションを参照します。</span><span class="sxs-lookup"><span data-stu-id="5322d-128">To see code examples in C#, JavaScript, Python, and several other languages, click the **APIs** tab of the app metadata API portal, click **App details**, and then see the **Code samples** section on the bottom of the page.</span></span>

<span data-ttu-id="5322d-129">または、アプリのメタデータ API ポータルによって提供される UI を使って、API を呼び出すこともできます。</span><span class="sxs-lookup"><span data-stu-id="5322d-129">Alternatively, you can call the API using the UI provided by the app metadata API portal:</span></span>
  1. <span data-ttu-id="5322d-130">ポータルで、**[API]** タブをクリックして、**[アプリの詳細]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="5322d-130">In the portal, click the **APIs** tab and then click **App details**.</span></span>
  2. <span data-ttu-id="5322d-131">次のページで、メタデータを取得するアプリの [app_id](#request-parameters) を **[app_id]** フィールドに入力し、サブスクリプション キーを **[Ocp_Apim_Subscription-Key]** フィールドに入力します。</span><span class="sxs-lookup"><span data-stu-id="5322d-131">On the following page, enter the [app_id](#request-parameters) of the app for which you want to retrieve metadata in the **app_id** field and enter your subscription key in the **Ocp_Apim_Subscription-Key** field.</span></span>
  3. <span data-ttu-id="5322d-132">**[送信]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="5322d-132">Click **Send**.</span></span> <span data-ttu-id="5322d-133">応答は、ページの下部に表示されます。</span><span class="sxs-lookup"><span data-stu-id="5322d-133">The response appears at the bottom of the page.</span></span>


<span id="syntax" />

## <a name="api-syntax"></a><span data-ttu-id="5322d-134">API 構文</span><span class="sxs-lookup"><span data-stu-id="5322d-134">API syntax</span></span>

<span data-ttu-id="5322d-135">このメソッドの要求の構文は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="5322d-135">This method has the following request syntax.</span></span>

| <span data-ttu-id="5322d-136">メソッド</span><span class="sxs-lookup"><span data-stu-id="5322d-136">Method</span></span> | <span data-ttu-id="5322d-137">要求 URI</span><span class="sxs-lookup"><span data-stu-id="5322d-137">Request URI</span></span>                                                      |
|--------|------------------------------------------------------------------|
| <span data-ttu-id="5322d-138">GET</span><span class="sxs-lookup"><span data-stu-id="5322d-138">GET</span></span>   | ```https://admetadata.azure-api.net/v1/app/{app_id}``` |

<span/>
 

### <a name="request-header"></a><span data-ttu-id="5322d-139">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="5322d-139">Request header</span></span>

| <span data-ttu-id="5322d-140">Header</span><span class="sxs-lookup"><span data-stu-id="5322d-140">Header</span></span>        | <span data-ttu-id="5322d-141">種類</span><span class="sxs-lookup"><span data-stu-id="5322d-141">Type</span></span>   | <span data-ttu-id="5322d-142">説明</span><span class="sxs-lookup"><span data-stu-id="5322d-142">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="5322d-143">Ocp-Apim-Subscription-Key</span><span class="sxs-lookup"><span data-stu-id="5322d-143">Ocp-Apim-Subscription-Key</span></span> | <span data-ttu-id="5322d-144">string</span><span class="sxs-lookup"><span data-stu-id="5322d-144">string</span></span> | <span data-ttu-id="5322d-145">必須。</span><span class="sxs-lookup"><span data-stu-id="5322d-145">Required.</span></span> <span data-ttu-id="5322d-146">[アプリのメタデータ API ポータルから取得した](#get-key)サブスクリプション キー。</span><span class="sxs-lookup"><span data-stu-id="5322d-146">The subscription key that you [retrieved from the app metadata API portal](#get-key).</span></span>  |

<span/>

### <a name="request-parameters"></a><span data-ttu-id="5322d-147">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="5322d-147">Request parameters</span></span>

| <span data-ttu-id="5322d-148">名前</span><span class="sxs-lookup"><span data-stu-id="5322d-148">Name</span></span>        | <span data-ttu-id="5322d-149">種類</span><span class="sxs-lookup"><span data-stu-id="5322d-149">Type</span></span>   | <span data-ttu-id="5322d-150">説明</span><span class="sxs-lookup"><span data-stu-id="5322d-150">Description</span></span>                                                                 |
|---------------|--------|-----------------------|
| <span data-ttu-id="5322d-151">app_id</span><span class="sxs-lookup"><span data-stu-id="5322d-151">app_id</span></span> | <span data-ttu-id="5322d-152">string</span><span class="sxs-lookup"><span data-stu-id="5322d-152">string</span></span> | <span data-ttu-id="5322d-153">必須。</span><span class="sxs-lookup"><span data-stu-id="5322d-153">Required.</span></span> <span data-ttu-id="5322d-154">メタデータを取得する対象となるアプリの ID。</span><span class="sxs-lookup"><span data-stu-id="5322d-154">The ID of the app for which you want retrieve metadata.</span></span> <span data-ttu-id="5322d-155">次のいずれかの値を使用できます。</span><span class="sxs-lookup"><span data-stu-id="5322d-155">This can be one of the following values:</span></span><br/><br/><ul><li><span data-ttu-id="5322d-156">アプリのストア ID。</span><span class="sxs-lookup"><span data-stu-id="5322d-156">The Store ID for the app.</span></span> <span data-ttu-id="5322d-157">ストア ID の例は 9NBLGGH29DM8 です。</span><span class="sxs-lookup"><span data-stu-id="5322d-157">An example Store ID is 9NBLGGH29DM8.</span></span></li><li><span data-ttu-id="5322d-158">当初は Windows 8.x または Windows Phone 8.x 用にビルドされたアプリの製品ID (*アプリID* とも呼ばれる)。</span><span class="sxs-lookup"><span data-stu-id="5322d-158">The Product ID (also sometimes called the *app ID*) for an app that was originally built for Windows 8.x or Windows Phone 8.x.</span></span> <span data-ttu-id="5322d-159">製品 ID は GUID です。</span><span class="sxs-lookup"><span data-stu-id="5322d-159">The Product ID is a GUID.</span></span></li></ul> |

<span/>

### <a name="request-example"></a><span data-ttu-id="5322d-160">要求の例</span><span class="sxs-lookup"><span data-stu-id="5322d-160">Request example</span></span>

<span data-ttu-id="5322d-161">次の例は、ストア ID が 9NBLGGH29DM8 であるアプリのメタデータを取得する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="5322d-161">The following example demonstrates how to retrieve metadata for an app that has the Store ID 9NBLGGH29DM8.</span></span>

```syntax
GET https://admetadata.azure-api.net/v1/app/9NBLGGH29DM8 HTTP/1.1
Ocp-Apim-Subscription-Key: <subscription key>
```

### <a name="response-body"></a><span data-ttu-id="5322d-162">応答本文</span><span class="sxs-lookup"><span data-stu-id="5322d-162">Response body</span></span>

<span data-ttu-id="5322d-163">次の例は、このメソッドが正常に呼び出された場合の JSON 応答本文を示しています。</span><span class="sxs-lookup"><span data-stu-id="5322d-163">The following example demonstrates the JSON response body for a successful call to this method.</span></span>

```json
{
    "storeId":"9NBLGGH29DM8",
    "name":"Contoso Sports App",
    "description":"Catch the latest scores and replays using Contoso Sports App!",
    "phoneStoreGuid":"920217d7-90da-4019-99e8-46e4a6bd2594",
    "windowsStoreGuid":"d7e982e7-fbf3-42b5-9dad-72b65bd4e248",
    "storeCategory":"Sports",
    "iabCategory":"Sports",
    "iabCategoryId":"IAB17",
    "coppa":false,
    "downloadUrl":"https://www.microsoft.com/store/apps/9nblggh29dm8",
    "isLive":true,
    "iconUrls":[
      "//store-images.microsoft.com/image/apps.15753.13510798883747357.b6981489-6fdd-4fec-b655-a822247d5a76.33529096-a723-4204-9da9-a5dd8b328d4e"
    ],
    "type":"App",
    "devices":[
      "PC",
      "Phone"
    ],
    "platformVersions":[
      "Windows.Universal"
    ],
    "screenshotUrls":[
      "//store-images.microsoft.com/image/apps.15901.19810723133740207.c9781069-6fef-5fba-a055-c922051d59b6.40129896-d083-5604-ab79-aba68bfa084f"
    ]
}
```

<span data-ttu-id="5322d-164">応答本文の値について詳しくは、次の表をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5322d-164">For more details about the values in the response body, see the following table.</span></span>

| <span data-ttu-id="5322d-165">Value</span><span class="sxs-lookup"><span data-stu-id="5322d-165">Value</span></span>      | <span data-ttu-id="5322d-166">種類</span><span class="sxs-lookup"><span data-stu-id="5322d-166">Type</span></span>   | <span data-ttu-id="5322d-167">説明</span><span class="sxs-lookup"><span data-stu-id="5322d-167">Description</span></span>    |
|------------|--------|--------------------|
| <span data-ttu-id="5322d-168">storeId</span><span class="sxs-lookup"><span data-stu-id="5322d-168">storeId</span></span>           | <span data-ttu-id="5322d-169">string</span><span class="sxs-lookup"><span data-stu-id="5322d-169">string</span></span>  | <span data-ttu-id="5322d-170">アプリケーションのストア ID です。</span><span class="sxs-lookup"><span data-stu-id="5322d-170">The Store ID of the app.</span></span> <span data-ttu-id="5322d-171">ストア ID の例は 9NBLGGH29DM8 です。</span><span class="sxs-lookup"><span data-stu-id="5322d-171">An example Store ID is 9NBLGGH29DM8.</span></span>     |  
| <span data-ttu-id="5322d-172">name</span><span class="sxs-lookup"><span data-stu-id="5322d-172">name</span></span>           | <span data-ttu-id="5322d-173">string</span><span class="sxs-lookup"><span data-stu-id="5322d-173">string</span></span>  | <span data-ttu-id="5322d-174">アプリの名前。</span><span class="sxs-lookup"><span data-stu-id="5322d-174">The name of the app.</span></span>   |
| <span data-ttu-id="5322d-175">説明</span><span class="sxs-lookup"><span data-stu-id="5322d-175">description</span></span>           | <span data-ttu-id="5322d-176">string</span><span class="sxs-lookup"><span data-stu-id="5322d-176">string</span></span>  | <span data-ttu-id="5322d-177">アプリのストア登録情報にある説明。</span><span class="sxs-lookup"><span data-stu-id="5322d-177">The description from the Store listing for the app.</span></span>  |
| <span data-ttu-id="5322d-178">phoneStoreGuid</span><span class="sxs-lookup"><span data-stu-id="5322d-178">phoneStoreGuid</span></span>           | <span data-ttu-id="5322d-179">string</span><span class="sxs-lookup"><span data-stu-id="5322d-179">string</span></span>  | <span data-ttu-id="5322d-180">アプリの製品 ID (Windows Phone 8.x)。</span><span class="sxs-lookup"><span data-stu-id="5322d-180">The Product ID (Windows Phone 8.x) for the app.</span></span> <span data-ttu-id="5322d-181">これは GUID です。</span><span class="sxs-lookup"><span data-stu-id="5322d-181">This is a GUID.</span></span>  |
| <span data-ttu-id="5322d-182">windowsStoreGuid</span><span class="sxs-lookup"><span data-stu-id="5322d-182">windowsStoreGuid</span></span>           | <span data-ttu-id="5322d-183">string</span><span class="sxs-lookup"><span data-stu-id="5322d-183">string</span></span>  | <span data-ttu-id="5322d-184">アプリの製品 ID (Windows 8.x)。</span><span class="sxs-lookup"><span data-stu-id="5322d-184">The Product ID (Windows 8.x) for the app.</span></span> <span data-ttu-id="5322d-185">これは GUID です。</span><span class="sxs-lookup"><span data-stu-id="5322d-185">This is a GUID.</span></span> |
| <span data-ttu-id="5322d-186">storeCategory</span><span class="sxs-lookup"><span data-stu-id="5322d-186">storeCategory</span></span>           | <span data-ttu-id="5322d-187">string</span><span class="sxs-lookup"><span data-stu-id="5322d-187">string</span></span>  | <span data-ttu-id="5322d-188">ストアでのアプリのカテゴリ。</span><span class="sxs-lookup"><span data-stu-id="5322d-188">The category for the app in the Store.</span></span> <span data-ttu-id="5322d-189">サポートされる値については、ストア内のアプリの[カテゴリとサブカテゴリの一覧](../publish/category-and-subcategory-table.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5322d-189">For the supported values, see the [category and subcategory table](../publish/category-and-subcategory-table.md) for apps in the Store.</span></span>  |
| <span data-ttu-id="5322d-190">iabCategory</span><span class="sxs-lookup"><span data-stu-id="5322d-190">iabCategory</span></span>           | <span data-ttu-id="5322d-191">string</span><span class="sxs-lookup"><span data-stu-id="5322d-191">string</span></span>  | <span data-ttu-id="5322d-192">Interactive Advertising Bureau (IAB) によって定義されているアプリのコンテンツのカテゴリ。</span><span class="sxs-lookup"><span data-stu-id="5322d-192">The content category for the app as defined by the Interactive Advertising Bureau (IAB).</span></span> <span data-ttu-id="5322d-193">たとえば、**News** や **Sports** です。</span><span class="sxs-lookup"><span data-stu-id="5322d-193">For example, **News** or **Sports**.</span></span> <span data-ttu-id="5322d-194">コンテンツのカテゴリの一覧については、IAB の Web サイトで [IAB Tech Lab のコンテンツ分類](https://www.iab.com/guidelines/iab-quality-assurance-guidelines-qag-taxonomy)のページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5322d-194">For a list of content categories, see the [IAB Tech Lab Content Taxonomy](https://www.iab.com/guidelines/iab-quality-assurance-guidelines-qag-taxonomy) page on the IAB web site.</span></span>   |
| <span data-ttu-id="5322d-195">iabCategoryId</span><span class="sxs-lookup"><span data-stu-id="5322d-195">iabCategoryId</span></span>           | <span data-ttu-id="5322d-196">string</span><span class="sxs-lookup"><span data-stu-id="5322d-196">string</span></span>  | <span data-ttu-id="5322d-197">アプリのコンテンツ カテゴリの ID。</span><span class="sxs-lookup"><span data-stu-id="5322d-197">The ID of the content category for the app.</span></span> <span data-ttu-id="5322d-198">たとえば、**IAB12** はニュース カテゴリの ID で、**IAB17** はスポーツ カテゴリの ID です。</span><span class="sxs-lookup"><span data-stu-id="5322d-198">For example, **IAB12** is the ID for the News category, and **IAB17** is the ID for the Sports category.</span></span> <span data-ttu-id="5322d-199">コンテンツ カテゴリ ID の一覧については、[OpenRTB API 仕様](https://www.iab.com/wp-content/uploads/2015/05/OpenRTB_API_Specification_Version_2_3_1.pdf)のセクション 5.1 をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5322d-199">For a list of content category IDs, see section 5.1 in the [OpenRTB API Specification](https://www.iab.com/wp-content/uploads/2015/05/OpenRTB_API_Specification_Version_2_3_1.pdf).</span></span> |
| <span data-ttu-id="5322d-200">coppa</span><span class="sxs-lookup"><span data-stu-id="5322d-200">coppa</span></span>           | <span data-ttu-id="5322d-201">ブール値</span><span class="sxs-lookup"><span data-stu-id="5322d-201">Boolean</span></span>  | <span data-ttu-id="5322d-202">アプリが 13 歳未満の子供を対象しており、児童オンライン プライバシー保護法 (COPPA) の義務がある場合は true。それ以外の場合は false です。</span><span class="sxs-lookup"><span data-stu-id="5322d-202">True if the app is directed at children under the age of 13 and therefore has obligations under the Children's Online Privacy Protection Act (COPPA); otherwise, false.</span></span>  |
| <span data-ttu-id="5322d-203">downloadUrl</span><span class="sxs-lookup"><span data-stu-id="5322d-203">downloadUrl</span></span>           | <span data-ttu-id="5322d-204">string</span><span class="sxs-lookup"><span data-stu-id="5322d-204">string</span></span>  | <span data-ttu-id="5322d-205">ストア内のアプリの登録情報へのリンク。</span><span class="sxs-lookup"><span data-stu-id="5322d-205">The link to the app's listing in the Store.</span></span> <span data-ttu-id="5322d-206">このリンクは、```https://www.microsoft.com/store/apps/<Store ID>``` の形式で示されます。</span><span class="sxs-lookup"><span data-stu-id="5322d-206">This link is in the format ```https://www.microsoft.com/store/apps/<Store ID>```.</span></span>  |
| <span data-ttu-id="5322d-207">isLive</span><span class="sxs-lookup"><span data-stu-id="5322d-207">isLive</span></span>           | <span data-ttu-id="5322d-208">ブール値</span><span class="sxs-lookup"><span data-stu-id="5322d-208">Boolean</span></span>  | <span data-ttu-id="5322d-209">アプリが現在ストアで利用可能な場合は true。それ以外の場合は false。</span><span class="sxs-lookup"><span data-stu-id="5322d-209">True if the app is currently available in the Store; otherwise, false.</span></span>  |
| <span data-ttu-id="5322d-210">iconUrls</span><span class="sxs-lookup"><span data-stu-id="5322d-210">iconUrls</span></span>           | <span data-ttu-id="5322d-211">array</span><span class="sxs-lookup"><span data-stu-id="5322d-211">array</span></span>  |  <span data-ttu-id="5322d-212">アプリに関連付けられたアイコン URL への相対パスを含む 1 つ以上の文字列の配列。</span><span class="sxs-lookup"><span data-stu-id="5322d-212">An array of one or more strings that contain the relative paths to the icon URLs associated with the app.</span></span> <span data-ttu-id="5322d-213">アイコンを取得するには、URL の先頭に *http* または *https* を付けます。</span><span class="sxs-lookup"><span data-stu-id="5322d-213">To retrieve the icons, prepend *http* or *https* to the URLs.</span></span>  |
| <span data-ttu-id="5322d-214">type</span><span class="sxs-lookup"><span data-stu-id="5322d-214">type</span></span>           | <span data-ttu-id="5322d-215">string</span><span class="sxs-lookup"><span data-stu-id="5322d-215">string</span></span>  | <span data-ttu-id="5322d-216">次のいずれかの文字列です。**アプリ**または**ゲーム**します。</span><span class="sxs-lookup"><span data-stu-id="5322d-216">One of the following strings: **App** or **Game**.</span></span>  |
| <span data-ttu-id="5322d-217">デバイス</span><span class="sxs-lookup"><span data-stu-id="5322d-217">devices</span></span>           |  <span data-ttu-id="5322d-218">array</span><span class="sxs-lookup"><span data-stu-id="5322d-218">array</span></span>  | <span data-ttu-id="5322d-219">アプリをサポートするデバイスの種類を指定する次の文字列の 1 つ以上の配列。**PC**、 **Phone**、 **Xbox**、 **IoT**、 **Server**、および**Holographic**します。</span><span class="sxs-lookup"><span data-stu-id="5322d-219">An array of one or more of the following strings that specify the device types that the app supports: **PC**, **Phone**, **Xbox**, **IoT**, **Server**, and **Holographic**.</span></span>  |
| <span data-ttu-id="5322d-220">platformVersions</span><span class="sxs-lookup"><span data-stu-id="5322d-220">platformVersions</span></span>           | <span data-ttu-id="5322d-221">array</span><span class="sxs-lookup"><span data-stu-id="5322d-221">array</span></span>  |  <span data-ttu-id="5322d-222">アプリをサポートするプラットフォームを指定する次の文字列の 1 つ以上の配列。**Windows.Universal**、 **Windows.Windows8x**、および**Windows.WindowsPhone8x**します。</span><span class="sxs-lookup"><span data-stu-id="5322d-222">An array of one or more of the following strings that specify the platforms that the app supports: **Windows.Universal**, **Windows.Windows8x**, and **Windows.WindowsPhone8x**.</span></span>  |
| <span data-ttu-id="5322d-223">screenshotUrls</span><span class="sxs-lookup"><span data-stu-id="5322d-223">screenshotUrls</span></span>           | <span data-ttu-id="5322d-224">array</span><span class="sxs-lookup"><span data-stu-id="5322d-224">array</span></span>  | <span data-ttu-id="5322d-225">このアプリのスクリーンショット URL への相対パスを含む 1 つ以上の文字列の配列。</span><span class="sxs-lookup"><span data-stu-id="5322d-225">An array of one or more strings that contain the relative paths to the screenshot URLs for this app.</span></span> <span data-ttu-id="5322d-226">スクリーンショットを取得するには、URL の先頭に *http* または *https* を付けます。</span><span class="sxs-lookup"><span data-stu-id="5322d-226">To retrieve the screenshots, prepend *http* or *https* to the URLs.</span></span>  |

<span/>



 

 
