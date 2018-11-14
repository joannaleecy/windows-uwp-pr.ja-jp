---
author: Xansky
ms.assetid: c92c0ea8-f742-4fc1-a3d7-e90aac11953e
description: Store のアプリのレビューにプログラムで返信を送るには、Microsoft Store レビュー API を使います。
title: ストアのサービスを使用してレビューに返信する
ms.author: mhopkins
ms.date: 06/04/2018
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store レビュー API, レビューに返信
ms.localizationpriority: medium
ms.openlocfilehash: 063c228a9a2fcfde9350af4872aabba44f9bb8a5
ms.sourcegitcommit: 71e8eae5c077a7740e5606298951bb78fc42b22c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/13/2018
ms.locfileid: "6646129"
---
# <a name="respond-to-reviews-using-store-services"></a><span data-ttu-id="6f97e-104">ストアのサービスを使用してレビューに返信する</span><span class="sxs-lookup"><span data-stu-id="6f97e-104">Respond to reviews using Store services</span></span>

<span data-ttu-id="6f97e-105">Store のアプリのレビューにプログラムで返信するには、*Microsoft Store レビュー API* を使います。</span><span class="sxs-lookup"><span data-stu-id="6f97e-105">Use the *Microsoft Store reviews API* to programmatically respond to reviews of your app in the Store.</span></span> <span data-ttu-id="6f97e-106">この API は、パートナー センターを使用せず、多数のレビューに返信一括する必要がある開発者に特に便利です。</span><span class="sxs-lookup"><span data-stu-id="6f97e-106">This API is especially useful for developers who want to bulk respond to many reviews without using Partner Center.</span></span> <span data-ttu-id="6f97e-107">この API は、Azure Active Directory (Azure AD) を使って、アプリまたはサービスからの呼び出しを認証します。</span><span class="sxs-lookup"><span data-stu-id="6f97e-107">This API uses Azure Active Directory (Azure AD) to authenticate the calls from your app or service.</span></span>

<span data-ttu-id="6f97e-108">次の手順で、このプロセスについて詳しく説明しています。</span><span class="sxs-lookup"><span data-stu-id="6f97e-108">The following steps describe the end-to-end process:</span></span>

1.  <span data-ttu-id="6f97e-109">すべての[前提条件](#prerequisites)を完了したことを確認します。</span><span class="sxs-lookup"><span data-stu-id="6f97e-109">Make sure that you have completed all the [prerequisites](#prerequisites).</span></span>
2.  <span data-ttu-id="6f97e-110">Microsoft Store レビュー API のメソッドを呼び出す前に、[Azure AD アクセス トークンを取得](#obtain-an-azure-ad-access-token)する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6f97e-110">Before you call a method in the Microsoft Store reviews API, [obtain an Azure AD access token](#obtain-an-azure-ad-access-token).</span></span> <span data-ttu-id="6f97e-111">トークンを取得した後、Microsoft Store レビュー API の呼び出しでこのトークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="6f97e-111">After you obtain a token, you have 60 minutes to use this token in calls to the Microsoft Store reviews API before the token expires.</span></span> <span data-ttu-id="6f97e-112">トークンの有効期限が切れた後は、新しいトークンを生成できます。</span><span class="sxs-lookup"><span data-stu-id="6f97e-112">After the token expires, you can generate a new token.</span></span>
3.  <span data-ttu-id="6f97e-113">[Microsoft Store レビュー API を呼び出します](#call-the-windows-store-reviews-api)。</span><span class="sxs-lookup"><span data-stu-id="6f97e-113">[Call the Microsoft Store reviews API](#call-the-windows-store-reviews-api).</span></span>

> [!NOTE]
> <span data-ttu-id="6f97e-114">使用してだけでなく、Microsoft Store レビューにプログラムでレビューに返信する、レビューの[パートナー センターの使用](../publish/respond-to-customer-reviews.md)に返信することもできます。 API を使用します。</span><span class="sxs-lookup"><span data-stu-id="6f97e-114">In addition to using the Microsoft Store reviews API to programmatically respond to reviews, you can alternatively respond to reviews [using Partner Center](../publish/respond-to-customer-reviews.md).</span></span>

<span id="prerequisites" />

## <a name="step-1-complete-prerequisites-for-using-the-microsoft-store-reviews-api"></a><span data-ttu-id="6f97e-115">手順 1: Microsoft Store レビュー API を使うための前提条件を満たす</span><span class="sxs-lookup"><span data-stu-id="6f97e-115">Step 1: Complete prerequisites for using the Microsoft Store reviews API</span></span>

<span data-ttu-id="6f97e-116">Microsoft Store レビュー API を呼び出すコードの作成を開始する前に、次の前提条件が満たされていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="6f97e-116">Before you start writing code to call the Microsoft Store reviews API, make sure that you have completed the following prerequisites.</span></span>

* <span data-ttu-id="6f97e-117">ユーザー (またはユーザーの組織) は、Azure AD ディレクトリと、そのディレクトリに対する[全体管理者](http://go.microsoft.com/fwlink/?LinkId=746654)のアクセス許可を持っている必要があります。</span><span class="sxs-lookup"><span data-stu-id="6f97e-117">You (or your organization) must have an Azure AD directory and you must have [Global administrator](http://go.microsoft.com/fwlink/?LinkId=746654) permission for the directory.</span></span> <span data-ttu-id="6f97e-118">Office 365 または Microsoft の他のビジネス サービスを既に使っている場合は、既に Azure AD ディレクトリをお持ちです。</span><span class="sxs-lookup"><span data-stu-id="6f97e-118">If you already use Office 365 or other business services from Microsoft, you already have Azure AD directory.</span></span> <span data-ttu-id="6f97e-119">それ以外の場合、追加料金なしの[パートナー センターで新しい Azure AD を作成](../publish/associate-azure-ad-with-dev-center.md#create-a-brand-new-azure-ad-to-associate-with-your-partner-center-account)できます。</span><span class="sxs-lookup"><span data-stu-id="6f97e-119">Otherwise, you can [create a new Azure AD in Partner Center](../publish/associate-azure-ad-with-dev-center.md#create-a-brand-new-azure-ad-to-associate-with-your-partner-center-account) for no additional charge.</span></span>

* <span data-ttu-id="6f97e-120">Azure AD アプリケーションをパートナー センター アカウントに関連付け、テナント ID とアプリケーションのクライアント ID を取得して、キーを生成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6f97e-120">You must associate an Azure AD application with your Partner Center account, retrieve the tenant ID and client ID for the application and generate a key.</span></span> <span data-ttu-id="6f97e-121">Azure AD アプリケーションは、Microsoft Store レビュー API の呼び出し元のアプリまたはサービスを表します。</span><span class="sxs-lookup"><span data-stu-id="6f97e-121">The Azure AD application represents the app or service from which you want to call the Microsoft Store reviews API.</span></span> <span data-ttu-id="6f97e-122">テナント ID、クライアント ID、およびキーは、API に渡す Azure AD アクセス トークンを取得するために必要です。</span><span class="sxs-lookup"><span data-stu-id="6f97e-122">You need the tenant ID, client ID and key to obtain an Azure AD access token that you pass to the API.</span></span>
    > [!NOTE]
    > <span data-ttu-id="6f97e-123">この作業を行うのは一度だけです。</span><span class="sxs-lookup"><span data-stu-id="6f97e-123">You only need to perform this task one time.</span></span> <span data-ttu-id="6f97e-124">テナント ID、クライアント ID、キーがあれば、新しい Azure AD アクセス トークンの作成が必要になったときに、いつでもそれらを再利用できます。</span><span class="sxs-lookup"><span data-stu-id="6f97e-124">After you have the tenant ID, client ID and key, you can reuse them any time you need to create a new Azure AD access token.</span></span>

<span data-ttu-id="6f97e-125">Azure AD アプリケーションをパートナー センター アカウントに関連付けると、必要な値を取得します。</span><span class="sxs-lookup"><span data-stu-id="6f97e-125">To associate an Azure AD application with your Partner Center account and retrieve the required values:</span></span>

1.  <span data-ttu-id="6f97e-126">パートナー センターで、[組織のパートナー センターのアカウントを組織の Azure AD ディレクトリを関連付けます](../publish/associate-azure-ad-with-dev-center.md)。</span><span class="sxs-lookup"><span data-stu-id="6f97e-126">In Partner Center, [associate your organization's Partner Center account with your organization's Azure AD directory](../publish/associate-azure-ad-with-dev-center.md).</span></span>

2.  <span data-ttu-id="6f97e-127">次に、パートナー センターの**アカウント設定**] セクションの [**ユーザー** ] ページから[Azure AD アプリケーションの追加](../publish/add-users-groups-and-azure-ad-applications.md#add-azure-ad-applications-to-your-partner-center-account)のアプリまたはに応答を使用するサービスを表すを確認します。</span><span class="sxs-lookup"><span data-stu-id="6f97e-127">Next, from the **Users** page in the **Account settings** section of Partner Center, [add the Azure AD application](../publish/add-users-groups-and-azure-ad-applications.md#add-azure-ad-applications-to-your-partner-center-account) that represents the app or service that you will use to respond to reviews.</span></span> <span data-ttu-id="6f97e-128">このアプリケーションに必ず**マネージャー** ロールを割り当てます。</span><span class="sxs-lookup"><span data-stu-id="6f97e-128">Make sure you assign this application the **Manager** role.</span></span> <span data-ttu-id="6f97e-129">アプリケーションが存在しない場合、Azure AD ディレクトリで実行できます[新しいパートナー センターで Azure AD アプリケーション](../publish/add-users-groups-and-azure-ad-applications.md#create-a-new-azure-ad-application-account-in-your-organizations-directory-and-add-it-to-your-partner-center-account)します。</span><span class="sxs-lookup"><span data-stu-id="6f97e-129">If the application doesn't exist yet in your Azure AD directory, you can [create a new Azure AD application in Partner Center](../publish/add-users-groups-and-azure-ad-applications.md#create-a-new-azure-ad-application-account-in-your-organizations-directory-and-add-it-to-your-partner-center-account).</span></span> 

3.  <span data-ttu-id="6f97e-130">**[ユーザー]** ページに戻り、Azure AD アプリケーションの名前をクリックしてアプリケーション設定に移動し、**[テナント ID]** と **[クライアント ID]** の値を書き留めます。</span><span class="sxs-lookup"><span data-stu-id="6f97e-130">Return to the **Users** page, click the name of your Azure AD application to go to the application settings, and copy down the **Tenant ID** and **Client ID** values.</span></span>

4. <span data-ttu-id="6f97e-131">**[新しいキーの追加]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="6f97e-131">Click **Add new key**.</span></span> <span data-ttu-id="6f97e-132">次の画面で、**[キー]** の値を書き留めます。</span><span class="sxs-lookup"><span data-stu-id="6f97e-132">On the following screen, copy down the **Key** value.</span></span> <span data-ttu-id="6f97e-133">このページから離れると、この情報に再度アクセスすることはできません。</span><span class="sxs-lookup"><span data-stu-id="6f97e-133">You won't be able to access this info again after you leave this page.</span></span> <span data-ttu-id="6f97e-134">詳しくは、「[Azure AD アプリケーションのキーを管理する方法](../publish/add-users-groups-and-azure-ad-applications.md#manage-keys)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6f97e-134">For more information, see [Manage keys for an Azure AD application](../publish/add-users-groups-and-azure-ad-applications.md#manage-keys).</span></span>

<span id="obtain-an-azure-ad-access-token" />

## <a name="step-2-obtain-an-azure-ad-access-token"></a><span data-ttu-id="6f97e-135">手順 2: Azure AD のアクセス トークンを取得する</span><span class="sxs-lookup"><span data-stu-id="6f97e-135">Step 2: Obtain an Azure AD access token</span></span>

<span data-ttu-id="6f97e-136">Microsoft Store レビュー API のいずれかのメソッドを呼び出す前に、まず API の各メソッドの **Authorization** ヘッダーに渡す Azure AD アクセス トークンを取得する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6f97e-136">Before you call any of the methods in the Microsoft Store reviews API, you must first obtain an Azure AD access token that you pass to the **Authorization** header of each method in the API.</span></span> <span data-ttu-id="6f97e-137">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="6f97e-137">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="6f97e-138">トークンの有効期限が切れた後は、トークンを更新してそれ以降の API 呼び出しで引き続き使用できます。</span><span class="sxs-lookup"><span data-stu-id="6f97e-138">After the token expires, you can refresh the token so you can continue to use it in further calls to the API.</span></span>

<span data-ttu-id="6f97e-139">アクセス トークンを取得するには、「[クライアント資格情報を使用したサービス間の呼び出し](https://azure.microsoft.com/documentation/articles/active-directory-protocols-oauth-service-to-service/)」の手順に従って、HTTP POST を ```https://login.microsoftonline.com/<tenant_id>/oauth2/token``` エンドポイントに送信します。</span><span class="sxs-lookup"><span data-stu-id="6f97e-139">To obtain the access token, follow the instructions in [Service to Service Calls Using Client Credentials](https://azure.microsoft.com/documentation/articles/active-directory-protocols-oauth-service-to-service/) to send an HTTP POST to the ```https://login.microsoftonline.com/<tenant_id>/oauth2/token``` endpoint.</span></span> <span data-ttu-id="6f97e-140">要求の例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="6f97e-140">Here is a sample request.</span></span>

```syntax
POST https://login.microsoftonline.com/<tenant_id>/oauth2/token HTTP/1.1
Host: login.microsoftonline.com
Content-Type: application/x-www-form-urlencoded; charset=utf-8

grant_type=client_credentials
&client_id=<your_client_id>
&client_secret=<your_client_secret>
&resource=https://manage.devcenter.microsoft.com
```

<span data-ttu-id="6f97e-141">POST URI と*client \_id*と*client \_secret*パラメーターで*tenant\_id*値、テナント ID、クライアント ID および前のセクションで、パートナー センターから取得したアプリケーションのキーを指定します。</span><span class="sxs-lookup"><span data-stu-id="6f97e-141">For the *tenant\_id* value in the POST URI and the *client\_id* and *client\_secret* parameters, specify the tenant ID, client ID and the key for your application that you retrieved from Partner Center in the previous section.</span></span> <span data-ttu-id="6f97e-142">*resource* パラメーターには、```https://manage.devcenter.microsoft.com``` を指定します。</span><span class="sxs-lookup"><span data-stu-id="6f97e-142">For the *resource* parameter, you must specify ```https://manage.devcenter.microsoft.com```.</span></span>

<span data-ttu-id="6f97e-143">アクセス トークンの有効期限が切れた後は、[この](https://azure.microsoft.com/documentation/articles/active-directory-protocols-oauth-code/#refreshing-the-access-tokens)手順に従って更新できます。</span><span class="sxs-lookup"><span data-stu-id="6f97e-143">After your access token expires, you can refresh it by following the instructions [here](https://azure.microsoft.com/documentation/articles/active-directory-protocols-oauth-code/#refreshing-the-access-tokens).</span></span>

<span id="call-the-windows-store-reviews-api" />

## <a name="step-3-call-the-microsoft-store-reviews-api"></a><span data-ttu-id="6f97e-144">手順 3: Microsoft Store レビュー API を呼び出す</span><span class="sxs-lookup"><span data-stu-id="6f97e-144">Step 3: Call the Microsoft Store reviews API</span></span>

<span data-ttu-id="6f97e-145">Azure AD アクセス トークンを取得したら、Microsoft Store レビュー API を呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="6f97e-145">After you have an Azure AD access token, you are ready to call the Microsoft Store reviews API.</span></span> <span data-ttu-id="6f97e-146">各メソッドの **Authorization** ヘッダーにアクセス トークンを渡す必要があります。</span><span class="sxs-lookup"><span data-stu-id="6f97e-146">You must pass the access token to the **Authorization** header of each method.</span></span>

<span data-ttu-id="6f97e-147">Microsoft Store レビュー API には、特定のレビューに返信できるかどうかや、1 つ以上のレビューに返信を提出できるかどうかの判断に使えるメソッドがいくつか含まれています。</span><span class="sxs-lookup"><span data-stu-id="6f97e-147">The Microsoft Store reviews API contains several methods you can use to determine whether you are allowed to respond to a given review and to submit responses to one or more reviews.</span></span> <span data-ttu-id="6f97e-148">この API を使用するには次のプロセスに従います。</span><span class="sxs-lookup"><span data-stu-id="6f97e-148">Follow this process to use this API:</span></span>

1. <span data-ttu-id="6f97e-149">返信するレビューの ID を取得します。</span><span class="sxs-lookup"><span data-stu-id="6f97e-149">Get the IDs of the reviews you want to respond to.</span></span> <span data-ttu-id="6f97e-150">レビュー ID は、Microsoft Store 分析 API の[アプリのレビューの取得](get-app-reviews.md)メソッドの応答データ、および[レビュー レポート](../publish/reviews-report.md)の[オフライン ダウンロード](../publish/download-analytic-reports.md)で取得できます。</span><span class="sxs-lookup"><span data-stu-id="6f97e-150">Review IDs are available in the response data of the [get app reviews](get-app-reviews.md) method in the Microsoft Store analytics API and in the [offline download](../publish/download-analytic-reports.md) of the [Reviews report](../publish/reviews-report.md).</span></span>
2. <span data-ttu-id="6f97e-151">レビューに返信できるかどうかを判断するには、[アプリのレビューへの返信情報の取得](get-response-info-for-app-reviews.md)メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="6f97e-151">Call the [get response info for app reviews](get-response-info-for-app-reviews.md) method to determine whether you are allowed to respond to the reviews.</span></span> <span data-ttu-id="6f97e-152">顧客はレビューを送信するときに、レビューへの返信を受け取らないことを選択できます。</span><span class="sxs-lookup"><span data-stu-id="6f97e-152">When a customer submits a review, they can choose not to receive responses to their review.</span></span> <span data-ttu-id="6f97e-153">レビューの返信を受け取らないことを選択している顧客が送信したレビューに返信することはできません。</span><span class="sxs-lookup"><span data-stu-id="6f97e-153">You cannot respond to reviews submitted by customers who have chosen not to receive review responses.</span></span>
3. <span data-ttu-id="6f97e-154">プラグラムでレビューに返信するには、[アプリ レビューへの返信の提出](submit-responses-to-app-reviews.md)メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="6f97e-154">Call the [submit responses to app reviews](submit-responses-to-app-reviews.md) method to programmatically respond to the reviews.</span></span>


## <a name="related-topics"></a><span data-ttu-id="6f97e-155">関連トピック</span><span class="sxs-lookup"><span data-stu-id="6f97e-155">Related topics</span></span>

* [<span data-ttu-id="6f97e-156">アプリのレビューの取得</span><span class="sxs-lookup"><span data-stu-id="6f97e-156">Get app reviews</span></span>](get-app-reviews.md)
* [<span data-ttu-id="6f97e-157">アプリのレビューへの返信情報の取得</span><span class="sxs-lookup"><span data-stu-id="6f97e-157">Get response info for app reviews</span></span>](get-response-info-for-app-reviews.md)
* [<span data-ttu-id="6f97e-158">アプリのレビューへの返信の提出</span><span class="sxs-lookup"><span data-stu-id="6f97e-158">Submit responses to app reviews</span></span>](submit-responses-to-app-reviews.md)

 
