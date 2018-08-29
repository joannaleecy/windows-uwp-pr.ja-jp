---
author: mcleanbyron
ms.assetid: 4BF9EF21-E9F0-49DB-81E4-062D6E68C8B1
description: Microsoft Store 分析 API を使うと、自分または自分の組織の Windows デベロッパー センター アカウントに登録されているアプリの分析データをプログラムで取得できます。
title: ストア サービスを使った分析データへのアクセス
ms.author: mcleans
ms.date: 06/04/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, Store サービス, Microsoft Store 分析 API
ms.localizationpriority: medium
ms.openlocfilehash: f36facd8ba89fbaccb7c61ad937c2ce005922aa8
ms.sourcegitcommit: 3727445c1d6374401b867c78e4ff8b07d92b7adc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/29/2018
ms.locfileid: "2910568"
---
# <a name="access-analytics-data-using-store-services"></a><span data-ttu-id="7e2af-104">ストア サービスを使った分析データへのアクセス</span><span class="sxs-lookup"><span data-stu-id="7e2af-104">Access analytics data using Store services</span></span>

<span data-ttu-id="7e2af-105">*Microsoft Store 分析 API* を使うと、自分または自分の組織の Windows デベロッパー センター アカウントに登録されているアプリの分析データをプログラムで取得できます。</span><span class="sxs-lookup"><span data-stu-id="7e2af-105">Use the *Microsoft Store analytics API* to programmatically retrieve analytics data for apps that are registered to your or your organization's Windows Dev Center account.</span></span> <span data-ttu-id="7e2af-106">この API では、アプリおよびアドオン (アプリ内製品または IAP とも呼ばれます) の入手数、エラー、アプリの評価とレビューに関するデータを取得できます。</span><span class="sxs-lookup"><span data-stu-id="7e2af-106">This API enables you to retrieve data for app and add-on (also known as in-app product or IAP) acquisitions, errors, app ratings and reviews.</span></span> <span data-ttu-id="7e2af-107">この API は、Azure Active Directory (Azure AD) を使って、アプリまたはサービスからの呼び出しを認証します。</span><span class="sxs-lookup"><span data-stu-id="7e2af-107">This API uses Azure Active Directory (Azure AD) to authenticate the calls from your app or service.</span></span>

<span data-ttu-id="7e2af-108">次の手順で、このプロセスについて詳しく説明しています。</span><span class="sxs-lookup"><span data-stu-id="7e2af-108">The following steps describe the end-to-end process:</span></span>

1.  <span data-ttu-id="7e2af-109">すべての[前提条件](#prerequisites)を完了したことを確認します。</span><span class="sxs-lookup"><span data-stu-id="7e2af-109">Make sure that you have completed all the [prerequisites](#prerequisites).</span></span>
2.  <span data-ttu-id="7e2af-110">Microsoft Store 分析 API のメソッドを呼び出す前に、[Azure AD アクセス トークンを取得](#obtain-an-azure-ad-access-token)する必要があります。</span><span class="sxs-lookup"><span data-stu-id="7e2af-110">Before you call a method in the Microsoft Store analytics API, [obtain an Azure AD access token](#obtain-an-azure-ad-access-token).</span></span> <span data-ttu-id="7e2af-111">トークンを取得した後、Microsoft Store 分析 API の呼び出しでこのトークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="7e2af-111">After you obtain a token, you have 60 minutes to use this token in calls to the Microsoft Store analytics API before the token expires.</span></span> <span data-ttu-id="7e2af-112">トークンの有効期限が切れた後は、新しいトークンを生成できます。</span><span class="sxs-lookup"><span data-stu-id="7e2af-112">After the token expires, you can generate a new token.</span></span>
3.  <span data-ttu-id="7e2af-113">[Microsoft Store 分析 API を呼び出します](#call-the-windows-store-analytics-api)。</span><span class="sxs-lookup"><span data-stu-id="7e2af-113">[Call the Microsoft Store analytics API](#call-the-windows-store-analytics-api).</span></span>

<span id="prerequisites" />

## <a name="step-1-complete-prerequisites-for-using-the-microsoft-store-analytics-api"></a><span data-ttu-id="7e2af-114">手順 1: Microsoft Store 分析 API を使うための前提条件を満たす</span><span class="sxs-lookup"><span data-stu-id="7e2af-114">Step 1: Complete prerequisites for using the Microsoft Store analytics API</span></span>

<span data-ttu-id="7e2af-115">Microsoft Store 分析 API を呼び出すコードの作成を開始する前に、次の前提条件が満たされていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="7e2af-115">Before you start writing code to call the Microsoft Store analytics API, make sure that you have completed the following prerequisites.</span></span>

* <span data-ttu-id="7e2af-116">ユーザー (またはユーザーの組織) は、Azure AD ディレクトリと、そのディレクトリに対する[全体管理者](http://go.microsoft.com/fwlink/?LinkId=746654)のアクセス許可を持っている必要があります。</span><span class="sxs-lookup"><span data-stu-id="7e2af-116">You (or your organization) must have an Azure AD directory and you must have [Global administrator](http://go.microsoft.com/fwlink/?LinkId=746654) permission for the directory.</span></span> <span data-ttu-id="7e2af-117">Office 365 または Microsoft の他のビジネス サービスを既に使っている場合は、既に Azure AD ディレクトリをお持ちです。</span><span class="sxs-lookup"><span data-stu-id="7e2af-117">If you already use Office 365 or other business services from Microsoft, you already have Azure AD directory.</span></span> <span data-ttu-id="7e2af-118">それ以外の場合は、追加料金なしで[デベロッパー センター内から新しい Azure AD を作成](../publish/associate-azure-ad-with-dev-center.md#create-a-brand-new-azure-ad-to-associate-with-your-dev-center-account)できます。</span><span class="sxs-lookup"><span data-stu-id="7e2af-118">Otherwise, you can [create a new Azure AD in Dev Center](../publish/associate-azure-ad-with-dev-center.md#create-a-brand-new-azure-ad-to-associate-with-your-dev-center-account) for no additional charge.</span></span>

* <span data-ttu-id="7e2af-119">Azure AD アプリケーションをデベロッパー センター アカウントに関連付け、アプリケーションのテナント ID とクライアント ID を取得してキーを生成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="7e2af-119">You must associate an Azure AD application with your Dev Center account, retrieve the tenant ID and client ID for the application and generate a key.</span></span> <span data-ttu-id="7e2af-120">Azure AD アプリケーションは、Microsoft Store 分析 API の呼び出し元のアプリまたはサービスを表します。</span><span class="sxs-lookup"><span data-stu-id="7e2af-120">The Azure AD application represents the app or service from which you want to call the Microsoft Store analytics API.</span></span> <span data-ttu-id="7e2af-121">テナント ID、クライアント ID、およびキーは、API に渡す Azure AD アクセス トークンを取得するために必要です。</span><span class="sxs-lookup"><span data-stu-id="7e2af-121">You need the tenant ID, client ID and key to obtain an Azure AD access token that you pass to the API.</span></span>
    > [!NOTE]
    > <span data-ttu-id="7e2af-122">この作業を行うのは一度だけです。</span><span class="sxs-lookup"><span data-stu-id="7e2af-122">You only need to perform this task one time.</span></span> <span data-ttu-id="7e2af-123">テナント ID、クライアント ID、キーがあれば、新しい Azure AD アクセス トークンの作成が必要になったときに、いつでもそれらを再利用できます。</span><span class="sxs-lookup"><span data-stu-id="7e2af-123">After you have the tenant ID, client ID and key, you can reuse them any time you need to create a new Azure AD access token.</span></span>

<span data-ttu-id="7e2af-124">Azure AD アプリケーションをデベロッパー センター アカウントに関連付け、必要な値を取得するには:</span><span class="sxs-lookup"><span data-stu-id="7e2af-124">To associate an Azure AD application with your Dev Center account and retrieve the required values:</span></span>

1.  <span data-ttu-id="7e2af-125">デベロッパー センターで、[組織のデベロッパー センター アカウントと組織の Azure AD ディレクトリを関連付けます](../publish/associate-azure-ad-with-dev-center.md)。</span><span class="sxs-lookup"><span data-stu-id="7e2af-125">In Dev Center, [associate your organization's Dev Center account with your organization's Azure AD directory](../publish/associate-azure-ad-with-dev-center.md).</span></span>

2.  <span data-ttu-id="7e2af-126">次に、デベロッパー センターの **[アカウント設定]** セクションの **[ユーザー]** ページで、デベロッパー センター アカウントの分析データへのアクセスに使うアプリやサービスを表す [Azure AD アプリケーションを追加](../publish/add-users-groups-and-azure-ad-applications.md#add-azure-ad-applications-to-your-dev-center-account)します。</span><span class="sxs-lookup"><span data-stu-id="7e2af-126">Next, from the **Users** page in the **Account settings** section of Dev Center, [add the Azure AD application](../publish/add-users-groups-and-azure-ad-applications.md#add-azure-ad-applications-to-your-dev-center-account) that represents the app or service that you will use to access analytics data for your Dev Center account.</span></span> <span data-ttu-id="7e2af-127">このアプリケーションに必ず**マネージャー** ロールを割り当てます。</span><span class="sxs-lookup"><span data-stu-id="7e2af-127">Make sure you assign this application the **Manager** role.</span></span> <span data-ttu-id="7e2af-128">アプリケーションが Azure AD ディレクトリにまだ存在しない場合は、[デベロッパー センターで新しい Azure AD アプリケーションを作成](../publish/add-users-groups-and-azure-ad-applications.md#create-a-new-azure-ad-application-account-in-your-organizations-directory-and-add-it-to-your-dev-center-account)することができます。</span><span class="sxs-lookup"><span data-stu-id="7e2af-128">If the application doesn't exist yet in your Azure AD directory, you can [create a new Azure AD application in Dev Center](../publish/add-users-groups-and-azure-ad-applications.md#create-a-new-azure-ad-application-account-in-your-organizations-directory-and-add-it-to-your-dev-center-account).</span></span>

3.  <span data-ttu-id="7e2af-129">**[ユーザー]** ページに戻り、Azure AD アプリケーションの名前をクリックしてアプリケーション設定に移動し、**[テナント ID]** と **[クライアント ID]** の値を書き留めます。</span><span class="sxs-lookup"><span data-stu-id="7e2af-129">Return to the **Users** page, click the name of your Azure AD application to go to the application settings, and copy down the **Tenant ID** and **Client ID** values.</span></span>

4. <span data-ttu-id="7e2af-130">**[新しいキーの追加]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="7e2af-130">Click **Add new key**.</span></span> <span data-ttu-id="7e2af-131">次の画面で、**[キー]** の値を書き留めます。</span><span class="sxs-lookup"><span data-stu-id="7e2af-131">On the following screen, copy down the **Key** value.</span></span> <span data-ttu-id="7e2af-132">このページから離れると、この情報に再度アクセスすることはできません。</span><span class="sxs-lookup"><span data-stu-id="7e2af-132">You won't be able to access this info again after you leave this page.</span></span> <span data-ttu-id="7e2af-133">詳しくは、「[Azure AD アプリケーションのキーを管理する方法](../publish/add-users-groups-and-azure-ad-applications.md#manage-keys)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7e2af-133">For more information, see [Manage keys for an Azure AD application](../publish/add-users-groups-and-azure-ad-applications.md#manage-keys).</span></span>

<span id="obtain-an-azure-ad-access-token" />

## <a name="step-2-obtain-an-azure-ad-access-token"></a><span data-ttu-id="7e2af-134">手順 2: Azure AD のアクセス トークンを取得する</span><span class="sxs-lookup"><span data-stu-id="7e2af-134">Step 2: Obtain an Azure AD access token</span></span>

<span data-ttu-id="7e2af-135">Microsoft Store 分析 API のいずれかのメソッドを呼び出す前に、まず API の各メソッドの **Authorization** ヘッダーに渡す Azure AD アクセス トークンを取得する必要があります。</span><span class="sxs-lookup"><span data-stu-id="7e2af-135">Before you call any of the methods in the Microsoft Store analytics API, you must first obtain an Azure AD access token that you pass to the **Authorization** header of each method in the API.</span></span> <span data-ttu-id="7e2af-136">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="7e2af-136">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="7e2af-137">トークンの有効期限が切れた後は、トークンを更新してそれ以降の API 呼び出しで引き続き使用できます。</span><span class="sxs-lookup"><span data-stu-id="7e2af-137">After the token expires, you can refresh the token so you can continue to use it in further calls to the API.</span></span>

<span data-ttu-id="7e2af-138">アクセス トークンを取得するには、「[クライアント資格情報を使用したサービス間の呼び出し](https://azure.microsoft.com/documentation/articles/active-directory-protocols-oauth-service-to-service/)」の手順に従って、HTTP POST を ```https://login.microsoftonline.com/<tenant_id>/oauth2/token``` エンドポイントに送信します。</span><span class="sxs-lookup"><span data-stu-id="7e2af-138">To obtain the access token, follow the instructions in [Service to Service Calls Using Client Credentials](https://azure.microsoft.com/documentation/articles/active-directory-protocols-oauth-service-to-service/) to send an HTTP POST to the ```https://login.microsoftonline.com/<tenant_id>/oauth2/token``` endpoint.</span></span> <span data-ttu-id="7e2af-139">要求の例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="7e2af-139">Here is a sample request.</span></span>

```
POST https://login.microsoftonline.com/<tenant_id>/oauth2/token HTTP/1.1
Host: login.microsoftonline.com
Content-Type: application/x-www-form-urlencoded; charset=utf-8

grant_type=client_credentials
&client_id=<your_client_id>
&client_secret=<your_client_secret>
&resource=https://manage.devcenter.microsoft.com
```

<span data-ttu-id="7e2af-140">POST URI の *tenant\_id* の値と *client \_id* および *client \_secret* のパラメーターには、前のセクションでデベロッパー センターから取得したテナント ID、クライアント ID、キーを指定します。</span><span class="sxs-lookup"><span data-stu-id="7e2af-140">For the *tenant\_id* value in the POST URI and the *client\_id* and *client\_secret* parameters, specify the tenant ID, client ID and the key for your application that you retrieved from Dev Center in the previous section.</span></span> <span data-ttu-id="7e2af-141">*resource* パラメーターには、```https://manage.devcenter.microsoft.com``` を指定します。</span><span class="sxs-lookup"><span data-stu-id="7e2af-141">For the *resource* parameter, you must specify ```https://manage.devcenter.microsoft.com```.</span></span>

<span data-ttu-id="7e2af-142">アクセス トークンの有効期限が切れた後は、[この](https://azure.microsoft.com/documentation/articles/active-directory-protocols-oauth-code/#refreshing-the-access-tokens)手順に従って更新できます。</span><span class="sxs-lookup"><span data-stu-id="7e2af-142">After your access token expires, you can refresh it by following the instructions [here](https://azure.microsoft.com/documentation/articles/active-directory-protocols-oauth-code/#refreshing-the-access-tokens).</span></span>

<span id="call-the-windows-store-analytics-api" />

## <a name="step-3-call-the-microsoft-store-analytics-api"></a><span data-ttu-id="7e2af-143">手順 3: Microsoft Store 分析 API を呼び出す</span><span class="sxs-lookup"><span data-stu-id="7e2af-143">Step 3: Call the Microsoft Store analytics API</span></span>

<span data-ttu-id="7e2af-144">Azure AD アクセス トークンを取得したら、Microsoft Store 分析 API を呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="7e2af-144">After you have an Azure AD access token, you are ready to call the Microsoft Store analytics API.</span></span> <span data-ttu-id="7e2af-145">各メソッドの **Authorization** ヘッダーにアクセス トークンを渡す必要があります。</span><span class="sxs-lookup"><span data-stu-id="7e2af-145">You must pass the access token to the **Authorization** header of each method.</span></span>

### <a name="methods-for-uwp-apps"></a><span data-ttu-id="7e2af-146">UWP アプリ向けのメソッド</span><span class="sxs-lookup"><span data-stu-id="7e2af-146">Methods for UWP apps</span></span>

<span data-ttu-id="7e2af-147">次の分析メソッドは、デベロッパー センターの UWP アプリで利用できます。</span><span class="sxs-lookup"><span data-stu-id="7e2af-147">The following analytics methods are available for UWP apps in Dev Center.</span></span>

| <span data-ttu-id="7e2af-148">シナリオ</span><span class="sxs-lookup"><span data-stu-id="7e2af-148">Scenario</span></span>       | <span data-ttu-id="7e2af-149">メソッド</span><span class="sxs-lookup"><span data-stu-id="7e2af-149">Methods</span></span>      |
|---------------|--------------------|
| <span data-ttu-id="7e2af-150">入手、コンバージョン、およびインストール</span><span class="sxs-lookup"><span data-stu-id="7e2af-150">Acquisitions, conversions, and installs</span></span> |  <ul><li>[<span data-ttu-id="7e2af-151">アプリの入手数の取得</span><span class="sxs-lookup"><span data-stu-id="7e2af-151">Get app acquisitions</span></span>](get-app-acquisitions.md)</li><li>[<span data-ttu-id="7e2af-152">アプリの入手に関するファネル データの取得</span><span class="sxs-lookup"><span data-stu-id="7e2af-152">Get app acquisition funnel data</span></span>](get-acquisition-funnel-data.md)</li><li>[<span data-ttu-id="7e2af-153">チャネルごとのアプリのコンバージョンの取得</span><span class="sxs-lookup"><span data-stu-id="7e2af-153">Get app conversions by channel</span></span>](get-app-conversions-by-channel.md)</li><li>[<span data-ttu-id="7e2af-154">アドオンの入手数の取得</span><span class="sxs-lookup"><span data-stu-id="7e2af-154">Get add-on acquisitions</span></span>](get-in-app-acquisitions.md)</li><li>[<span data-ttu-id="7e2af-155">サブスクリプション アドオンの入手数の取得</span><span class="sxs-lookup"><span data-stu-id="7e2af-155">Get subscription add-on acquisitions</span></span>](get-subscription-acquisitions.md)</li><li>[<span data-ttu-id="7e2af-156">チャネルごとのアドオンのコンバージョンの取得</span><span class="sxs-lookup"><span data-stu-id="7e2af-156">Get add-on conversions by channel</span></span>](get-add-on-conversions-by-channel.md)</li><li>[<span data-ttu-id="7e2af-157">アプリのインストール数の取得</span><span class="sxs-lookup"><span data-stu-id="7e2af-157">Get app installs</span></span>](get-app-installs.md)</li></ul> |
| <span data-ttu-id="7e2af-158">アプリのエラー</span><span class="sxs-lookup"><span data-stu-id="7e2af-158">App errors</span></span> | <ul><li>[<span data-ttu-id="7e2af-159">エラー報告データの取得</span><span class="sxs-lookup"><span data-stu-id="7e2af-159">Get error reporting data</span></span>](get-error-reporting-data.md)</li><li>[<span data-ttu-id="7e2af-160">アプリのエラーに関する詳細情報の取得</span><span class="sxs-lookup"><span data-stu-id="7e2af-160">Get details for an error in your app</span></span>](get-details-for-an-error-in-your-app.md)</li><li>[<span data-ttu-id="7e2af-161">アプリのエラーに関するスタック トレースの取得</span><span class="sxs-lookup"><span data-stu-id="7e2af-161">Get the stack trace for an error in your app</span></span>](get-the-stack-trace-for-an-error-in-your-app.md)</li><li>[<span data-ttu-id="7e2af-162">アプリのエラーの CAB ファイルをダウンロードする</span><span class="sxs-lookup"><span data-stu-id="7e2af-162">Download the CAB file for an error in your app</span></span>](download-the-cab-file-for-an-error-in-your-app.md)</li></ul> |
| <span data-ttu-id="7e2af-163">情報</span><span class="sxs-lookup"><span data-stu-id="7e2af-163">Insights</span></span> | <ul><li>[<span data-ttu-id="7e2af-164">アプリのインサイト データの取得</span><span class="sxs-lookup"><span data-stu-id="7e2af-164">Get insights data for your app</span></span>](get-insights-data-for-your-app.md)</li></ul>  |
| <span data-ttu-id="7e2af-165">評価とレビュー</span><span class="sxs-lookup"><span data-stu-id="7e2af-165">Ratings and reviews</span></span> | <ul><li>[<span data-ttu-id="7e2af-166">アプリの評価の取得</span><span class="sxs-lookup"><span data-stu-id="7e2af-166">Get app ratings</span></span>](get-app-ratings.md)</li><li>[<span data-ttu-id="7e2af-167">アプリのレビューの取得</span><span class="sxs-lookup"><span data-stu-id="7e2af-167">Get app reviews</span></span>](get-app-reviews.md)</li></ul> |
| <span data-ttu-id="7e2af-168">アプリ内広告と広告キャンペーン</span><span class="sxs-lookup"><span data-stu-id="7e2af-168">In-app ads and ad campaigns</span></span> | <ul><li>[<span data-ttu-id="7e2af-169">広告のパフォーマンス データの取得</span><span class="sxs-lookup"><span data-stu-id="7e2af-169">Get ad performance data</span></span>](get-ad-performance-data.md)</li><li>[<span data-ttu-id="7e2af-170">広告キャンペーンのパフォーマンス データの取得</span><span class="sxs-lookup"><span data-stu-id="7e2af-170">Get ad campaign performance data</span></span>](get-ad-campaign-performance-data.md)</li></ul> |

### <a name="methods-for-desktop-applications"></a><span data-ttu-id="7e2af-171">デスクトップ アプリケーション向けのメソッド</span><span class="sxs-lookup"><span data-stu-id="7e2af-171">Methods for desktop applications</span></span>

<span data-ttu-id="7e2af-172">次の分析メソッドは、[Windows デスクトップ アプリケーション プログラム](https://msdn.microsoft.com/library/windows/desktop/mt826504)に参加している開発者アカウントで利用できます。</span><span class="sxs-lookup"><span data-stu-id="7e2af-172">The following analytics methods are available for use by developer accounts that belong to the [Windows Desktop Application program](https://msdn.microsoft.com/library/windows/desktop/mt826504).</span></span>

| <span data-ttu-id="7e2af-173">シナリオ</span><span class="sxs-lookup"><span data-stu-id="7e2af-173">Scenario</span></span>       | <span data-ttu-id="7e2af-174">メソッド</span><span class="sxs-lookup"><span data-stu-id="7e2af-174">Methods</span></span>      |
|---------------|--------------------|
| <span data-ttu-id="7e2af-175">インストール</span><span class="sxs-lookup"><span data-stu-id="7e2af-175">Installs</span></span> |  <ul><li>[<span data-ttu-id="7e2af-176">デスクトップ アプリケーションのインストール数の取得</span><span class="sxs-lookup"><span data-stu-id="7e2af-176">Get desktop application installs</span></span>](get-desktop-app-installs.md)</li></ul> |
| <span data-ttu-id="7e2af-177">ブロック</span><span class="sxs-lookup"><span data-stu-id="7e2af-177">Blocks</span></span> |  <ul><li>[<span data-ttu-id="7e2af-178">デスクトップ アプリケーションのアップグレード ブロックの取得</span><span class="sxs-lookup"><span data-stu-id="7e2af-178">Get upgrade blocks for your desktop application</span></span>](get-desktop-block-data.md)</li><li>[<span data-ttu-id="7e2af-179">デスクトップ アプリケーションのアップグレード ブロックの詳細情報の取得</span><span class="sxs-lookup"><span data-stu-id="7e2af-179">Get upgrade block details for your desktop application</span></span>](get-desktop-block-data-details.md)</li></ul> |
| <span data-ttu-id="7e2af-180">アプリケーション エラー</span><span class="sxs-lookup"><span data-stu-id="7e2af-180">Application errors</span></span> |  <ul><li>[<span data-ttu-id="7e2af-181">デスクトップ アプリケーションのエラー報告データの取得</span><span class="sxs-lookup"><span data-stu-id="7e2af-181">Get error reporting data for your desktop application</span></span>](get-desktop-application-error-reporting-data.md)</li><li>[<span data-ttu-id="7e2af-182">デスクトップ アプリケーションのエラーに関する詳細情報の取得</span><span class="sxs-lookup"><span data-stu-id="7e2af-182">Get details for an error in your desktop application</span></span>](get-details-for-an-error-in-your-desktop-application.md)</li><li>[<span data-ttu-id="7e2af-183">デスクトップ アプリケーションのエラーに関するスタック トレースの取得</span><span class="sxs-lookup"><span data-stu-id="7e2af-183">Get the stack trace for an error in your desktop application</span></span>](get-the-stack-trace-for-an-error-in-your-desktop-application.md)</li><li>[<span data-ttu-id="7e2af-184">デスクトップ アプリケーションのエラーの CAB ファイルをダウンロードする</span><span class="sxs-lookup"><span data-stu-id="7e2af-184">Download the CAB file for an error in your desktop application</span></span>](download-the-cab-file-for-an-error-in-your-desktop-application.md)</li></ul> |
| <span data-ttu-id="7e2af-185">情報</span><span class="sxs-lookup"><span data-stu-id="7e2af-185">Insights</span></span> | <ul><li>[<span data-ttu-id="7e2af-186">デスクトップ アプリケーションのインサイト データの取得</span><span class="sxs-lookup"><span data-stu-id="7e2af-186">Get insights data for your desktop application</span></span>](get-insights-data-for-your-desktop-app.md)</li></ul>  |

### <a name="methods-for-xbox-live-services"></a><span data-ttu-id="7e2af-187">Xbox Live サービス向けのメソッド</span><span class="sxs-lookup"><span data-stu-id="7e2af-187">Methods for Xbox Live services</span></span>

<span data-ttu-id="7e2af-188">次の追加のメソッドは、[Xbox Live サービス](../xbox-live/developer-program-overview.md)を使うゲームの開発者アカウントで利用できます。</span><span class="sxs-lookup"><span data-stu-id="7e2af-188">The following additional methods are available for use by developer accounts with games that use [Xbox Live services](../xbox-live/developer-program-overview.md).</span></span>

| <span data-ttu-id="7e2af-189">シナリオ</span><span class="sxs-lookup"><span data-stu-id="7e2af-189">Scenario</span></span>       | <span data-ttu-id="7e2af-190">メソッド</span><span class="sxs-lookup"><span data-stu-id="7e2af-190">Methods</span></span>      |
|---------------|--------------------|
| <span data-ttu-id="7e2af-191">一般的な分析</span><span class="sxs-lookup"><span data-stu-id="7e2af-191">General analytics</span></span> |  <ul><li>[<span data-ttu-id="7e2af-192">Xbox Live の分析データの取得</span><span class="sxs-lookup"><span data-stu-id="7e2af-192">Get Xbox Live analytics data</span></span>](get-xbox-live-analytics.md)</li><li>[<span data-ttu-id="7e2af-193">Xbox Live の実績データの取得</span><span class="sxs-lookup"><span data-stu-id="7e2af-193">Get Xbox Live achievements data</span></span>](get-xbox-live-achievements-data.md)</li><li>[<span data-ttu-id="7e2af-194">Xbox Live の同時使用状況データの取得</span><span class="sxs-lookup"><span data-stu-id="7e2af-194">Get Xbox Live concurrent usage data</span></span>](get-xbox-live-concurrent-usage-data.md)</li></ul> |
| <span data-ttu-id="7e2af-195">正常性分析</span><span class="sxs-lookup"><span data-stu-id="7e2af-195">Health analytics</span></span> |  <ul><li>[<span data-ttu-id="7e2af-196">Xbox Live の正常性データの取得</span><span class="sxs-lookup"><span data-stu-id="7e2af-196">Get Xbox Live health data</span></span>](get-xbox-live-health-data.md)</li></ul> |
| <span data-ttu-id="7e2af-197">コミュニティ分析</span><span class="sxs-lookup"><span data-stu-id="7e2af-197">Community analytics</span></span> |  <ul><li>[<span data-ttu-id="7e2af-198">Xbox Live ゲーム ハブのデータの取得</span><span class="sxs-lookup"><span data-stu-id="7e2af-198">Get Xbox Live Game Hub data</span></span>](get-xbox-live-game-hub-data.md)</li><li>[<span data-ttu-id="7e2af-199">Xbox Live クラブのデータの取得</span><span class="sxs-lookup"><span data-stu-id="7e2af-199">Get Xbox Live club data</span></span>](get-xbox-live-club-data.md)</li><li>[<span data-ttu-id="7e2af-200">Xbox Live のマルチプレイヤー データの取得</span><span class="sxs-lookup"><span data-stu-id="7e2af-200">Get Xbox Live multiplayer data</span></span>](get-xbox-live-multiplayer-data.md)</li></ul>  |

### <a name="methods-for-xbox-one-games"></a><span data-ttu-id="7e2af-201">Xbox One ゲーム向けのメソッド</span><span class="sxs-lookup"><span data-stu-id="7e2af-201">Methods for Xbox One games</span></span>

<span data-ttu-id="7e2af-202">次の追加のメソッドは、Xbox デベロッパー ポータル (XDP) を通じて取り込まれ、デベロッパー センター ダッシュボードの [XDP 分析] で利用できる Xbox One ゲームの開発者アカウントで使うことができます。</span><span class="sxs-lookup"><span data-stu-id="7e2af-202">The following additional methods are available for use by developer accounts with Xbox One games that were ingested through the Xbox Developer Portal (XDP) and available in the XDP Analytics Dev Center dashboard.</span></span>

| <span data-ttu-id="7e2af-203">シナリオ</span><span class="sxs-lookup"><span data-stu-id="7e2af-203">Scenario</span></span>       | <span data-ttu-id="7e2af-204">メソッド</span><span class="sxs-lookup"><span data-stu-id="7e2af-204">Methods</span></span>      |
|---------------|--------------------|
| <span data-ttu-id="7e2af-205">入手</span><span class="sxs-lookup"><span data-stu-id="7e2af-205">Acquisitions</span></span> |  <ul><li>[<span data-ttu-id="7e2af-206">Xbox One ゲームの入手数の取得</span><span class="sxs-lookup"><span data-stu-id="7e2af-206">Get Xbox One game acquisitions</span></span>](get-xbox-one-game-acquisitions.md)</li></ul> |

### <a name="methods-for-hardware-and-drivers"></a><span data-ttu-id="7e2af-207">ハードウェアとドライバー向けのメソッド</span><span class="sxs-lookup"><span data-stu-id="7e2af-207">Methods for hardware and drivers</span></span>

<span data-ttu-id="7e2af-208">[Windows ハードウェア デベロッパー センター プログラム](https://msdn.microsoft.com/windows/hardware/drivers/dashboard/get-started-with-the-hardware-dashboard)に参加している開発者アカウントでは、追加のハードウェアとドライバーの分析データを取得するためのメソッドのセットへのアクセスがあります。</span><span class="sxs-lookup"><span data-stu-id="7e2af-208">Developer accounts that belong to the [Windows Hardware Dev Center program](https://msdn.microsoft.com/windows/hardware/drivers/dashboard/get-started-with-the-hardware-dashboard) have access to an additional set of methods for retrieving analytics data for hardware and drivers.</span></span> <span data-ttu-id="7e2af-209">詳しくは、[ハードウェア ダッシュ ボード API](https://docs.microsoft.com/windows-hardware/drivers/dashboard/dashboard-api)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="7e2af-209">For more information, see [Hardware dashboard API](https://docs.microsoft.com/windows-hardware/drivers/dashboard/dashboard-api).</span></span>

## <a name="code-example"></a><span data-ttu-id="7e2af-210">コードの例</span><span class="sxs-lookup"><span data-stu-id="7e2af-210">Code example</span></span>

<span data-ttu-id="7e2af-211">次のコード例は、Azure AD アクセス トークンを取得し、C# コンソール アプリから Microsoft Store 分析 API を呼び出す方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="7e2af-211">The following code example demonstrates how to obtain an Azure AD access token and call the Microsoft Store analytics API from a C# console app.</span></span> <span data-ttu-id="7e2af-212">このコード例を使う場合は、変数 *tenantId*、*clientId*、*clientSecret*、および *appID* を自分のシナリオに合った適切な値に割り当ててください。</span><span class="sxs-lookup"><span data-stu-id="7e2af-212">To use this code example, assign the *tenantId*, *clientId*, *clientSecret*, and *appID* variables to the appropriate values for your scenario.</span></span> <span data-ttu-id="7e2af-213">この例では、Microsoft Store 分析 API から返される JSON データを逆シリアル化するときに、Newtonsoft の [Json.NET パッケージ](http://www.newtonsoft.com/json)が必要になります。</span><span class="sxs-lookup"><span data-stu-id="7e2af-213">This example requires the [Json.NET package](http://www.newtonsoft.com/json) from Newtonsoft to deserialize the JSON data returned by the Microsoft Store analytics API.</span></span>

> [!div class="tabbedCodeSnippets"]
[!code-cs[AnalyticsApi](./code/StoreServicesExamples_Analytics/cs/Program.cs#AnalyticsApiExample)]

## <a name="error-responses"></a><span data-ttu-id="7e2af-214">エラー応答</span><span class="sxs-lookup"><span data-stu-id="7e2af-214">Error responses</span></span>

<span data-ttu-id="7e2af-215">Microsoft Store 分析 API は、エラー コードとメッセージが含まれた JSON オブジェクトにエラー応答を返します。</span><span class="sxs-lookup"><span data-stu-id="7e2af-215">The Microsoft Store analytics API returns error responses in a JSON object that contains error codes and messages.</span></span> <span data-ttu-id="7e2af-216">次の例は、無効なパラメーターに対するエラー応答を示しています。</span><span class="sxs-lookup"><span data-stu-id="7e2af-216">The following example demonstrates an error response caused by an invalid parameter.</span></span>

```json
{
    "code":"BadRequest",
    "data":[],
    "details":[],
    "innererror":{
        "code":"InvalidQueryParameters",
        "data":[
            "top parameter cannot be more than 10000"
        ],
        "details":[],
        "message":"One or More Query Parameters has invalid values.",
        "source":"AnalyticsAPI"
    },
    "message":"The calling client sent a bad request to the service.",
    "source":"AnalyticsAPI"
}
```
