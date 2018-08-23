---
author: mcleanbyron
ms.assetid: B071F6BC-49D3-4E74-98EA-0461A1A55EFB
description: アプリとアドオンのカタログがある場合は、Microsoft Store コレクション API および Microsoft Store 購入 API を使って、サービスからこれらの製品の所有権情報にアクセスできます。
title: サービスから製品の権利を管理する
ms.author: mcleans
ms.date: 08/01/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, Microsoft Store コレクション API, Microsoft Store 購入 API, 製品の表示, 製品の付与
ms.localizationpriority: medium
ms.openlocfilehash: 3a0766830bc2110dffcf5baf886e8ccb98ac6446
ms.sourcegitcommit: 9c79fdab9039ff592edf7984732d300a14e81d92
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/23/2018
ms.locfileid: "2819504"
---
# <a name="manage-product-entitlements-from-a-service"></a><span data-ttu-id="a0993-104">サービスから製品の権利を管理する</span><span class="sxs-lookup"><span data-stu-id="a0993-104">Manage product entitlements from a service</span></span>

<span data-ttu-id="a0993-105">アプリとアドオンのカタログがある場合は、*Microsoft Store コレクション API* と *Microsoft Store 購入 API* を使って、サービスからこれらの製品の権利の情報にアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="a0993-105">If you have a catalog of apps and add-ons, you can use the *Microsoft Store collection API* and *Microsoft Store purchase API* to access entitlement information for these products from your services.</span></span> <span data-ttu-id="a0993-106">"権利"** とは、Microsoft Store を通じて公開されたアプリまたはアドオンを顧客が使用する権利を表します。</span><span class="sxs-lookup"><span data-stu-id="a0993-106">An *entitlement* represents a customer's right to use an app or add-on that is published through the Microsoft Store.</span></span>

<span data-ttu-id="a0993-107">これらの API は、クロスプラットフォーム サービスでサポートされるアドオン カタログを持つ開発者向けに設計された REST メソッドで構成されています。</span><span class="sxs-lookup"><span data-stu-id="a0993-107">These APIs consist of REST methods that are designed to be used by developers with add-on catalogs that are supported by cross-platform services.</span></span> <span data-ttu-id="a0993-108">これらの API を使用すると、次の操作を実行できます。</span><span class="sxs-lookup"><span data-stu-id="a0993-108">These APIs enable you to do the following:</span></span>

-   <span data-ttu-id="a0993-109">Microsoft Store コレクション API: [ユーザーが所有するアプリを照会](query-for-products.md)し、[コンシューマブルな製品をフルフィルメント完了として報告](report-consumable-products-as-fulfilled.md)する。</span><span class="sxs-lookup"><span data-stu-id="a0993-109">Microsoft Store collection API: [Query for products owned by a user](query-for-products.md) and [report a consumable product as fulfilled](report-consumable-products-as-fulfilled.md).</span></span>
-   <span data-ttu-id="a0993-110">Microsoft Store 購入 API: [無料のアプリをユーザーに付与する](grant-free-products.md)、[ユーザーのサブスクリプションを取得する](get-subscriptions-for-a-user.md)、[ユーザーのサブスクリプションに関する請求の状態を変更する](change-the-billing-state-of-a-subscription-for-a-user.md)。</span><span class="sxs-lookup"><span data-stu-id="a0993-110">Microsoft Store purchase API: [Grant a free product to a user](grant-free-products.md), [get subscriptions for a user](get-subscriptions-for-a-user.md), and [change the billing state of a subscription for a user](change-the-billing-state-of-a-subscription-for-a-user.md).</span></span>

> [!NOTE]
> <span data-ttu-id="a0993-111">Microsoft Store コレクション API と Microsoft Store 購入 API では、Azure Active Directory (Azure AD) 認証を使って顧客の所有権情報にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="a0993-111">The Microsoft Store collection API and purchase API use Azure Active Directory (Azure AD) authentication to access customer ownership information.</span></span> <span data-ttu-id="a0993-112">これらの API を使用するには、ユーザー (またはユーザーの組織) が、Azure AD ディレクトリと、そのディレクトリに対する[全体管理者](http://go.microsoft.com/fwlink/?LinkId=746654)のアクセス許可を持っている必要があります。</span><span class="sxs-lookup"><span data-stu-id="a0993-112">To use these APIs, you (or your organization) must have an Azure AD directory and you must have [Global administrator](http://go.microsoft.com/fwlink/?LinkId=746654) permission for the directory.</span></span> <span data-ttu-id="a0993-113">Office 365 または Microsoft の他のビジネス サービスを既に使っている場合は、既に Azure AD ディレクトリをお持ちです。</span><span class="sxs-lookup"><span data-stu-id="a0993-113">If you already use Office 365 or other business services from Microsoft, you already have Azure AD directory.</span></span>

## <a name="overview"></a><span data-ttu-id="a0993-114">概要</span><span class="sxs-lookup"><span data-stu-id="a0993-114">Overview</span></span>

<span data-ttu-id="a0993-115">次の手順は、Microsoft Store コレクション API および購入 API を使用するプロセス全体を表したものです。</span><span class="sxs-lookup"><span data-stu-id="a0993-115">The following steps describe the end-to-end process for using the Microsoft Store collection API and purchase API:</span></span>

1.  <span data-ttu-id="a0993-116">[Azure AD でアプリケーションを構成](#step-1)します。</span><span class="sxs-lookup"><span data-stu-id="a0993-116">[Configure an application in Azure AD](#step-1).</span></span>
2.  <span data-ttu-id="a0993-117">[Windows デベロッパー センターのダッシュ ボードで、アプリでは、Azure AD アプリケーションの ID に関連付ける](#step-2)に。</span><span class="sxs-lookup"><span data-stu-id="a0993-117">[Associate your Azure AD application ID with your app in the Windows Dev Center dashboard](#step-2).</span></span>
3.  <span data-ttu-id="a0993-118">サービスで、発行元 ID を表す [Azure AD アクセス トークンを作成します](#step-3)。</span><span class="sxs-lookup"><span data-stu-id="a0993-118">In your service, [create Azure AD access tokens](#step-3) that represent your publisher identity.</span></span>
4.  <span data-ttu-id="a0993-119">クライアントの Windows アプリでは、サービスにバックアップ[Microsoft ストア ID キーを作成](#step-4)するキーのパスと現在のユーザーの id を表します。</span><span class="sxs-lookup"><span data-stu-id="a0993-119">In your client Windows app, [create a Microsoft Store ID key](#step-4) that represents the identity of the current user, and pass this key back to your service.</span></span>
5.  <span data-ttu-id="a0993-120">必要な Azure AD のアクセス トークンと Microsoft Store ID キーを取得した後、[サービスから Microsoft Store コレクション API または Microsoft Store 購入 API を呼び出します](#step-5)。</span><span class="sxs-lookup"><span data-stu-id="a0993-120">After you have the required Azure AD access token and Microsoft Store ID key, [call the Microsoft Store collection API or purchase API from your service](#step-5).</span></span>

<span data-ttu-id="a0993-121">この - エンドツー エンド プロセスには、さまざまなタスクを実行する 2 つのソフトウェア コンポーネントが含まれます。</span><span class="sxs-lookup"><span data-stu-id="a0993-121">This end-to-end process involves two software components that perform different tasks:</span></span>

* <span data-ttu-id="a0993-122">**サービス**です。</span><span class="sxs-lookup"><span data-stu-id="a0993-122">**Your service**.</span></span> <span data-ttu-id="a0993-123">これは、ビジネス環境のコンテキストで安全に実行されるアプリケーションであり、実装を選択する、開発プラットフォームを使用することができます。</span><span class="sxs-lookup"><span data-stu-id="a0993-123">This is an application that runs securely in the context of your business environment, and it can be implemented using any development platform you choose.</span></span> <span data-ttu-id="a0993-124">Azure AD アクセス トークンを作成するために必要なシナリオでは、Microsoft ストア コレクションの残りの Uri の発信に API や購入 API のサービスは、状態にします。</span><span class="sxs-lookup"><span data-stu-id="a0993-124">Your service is responsible for creating the Azure AD access tokens needed for the scenario and for calling the REST URIs for the Microsoft Store collection API and purchase API.</span></span>
* <span data-ttu-id="a0993-125">**クライアント Windows アプリ**。</span><span class="sxs-lookup"><span data-stu-id="a0993-125">**Your client Windows app**.</span></span> <span data-ttu-id="a0993-126">これは、アプリにアクセスして、顧客の資格情報 (アプリのアドオンを含む) を管理します。</span><span class="sxs-lookup"><span data-stu-id="a0993-126">This is the app for which you want to access and manage customer entitlement information (including add-ons for the app).</span></span> <span data-ttu-id="a0993-127">このアプリは、Microsoft ストア コレクション API 呼び出しして API のサービスを購入する必要が Microsoft ストア ID キーを作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a0993-127">This app is responsible for creating the Microsoft Store ID keys you need to call the Microsoft Store collection API and purchase API from your service.</span></span>

<span id="step-1"/>

## <a name="step-1-configure-an-application-in-azure-ad"></a><span data-ttu-id="a0993-128">手順 1: Azure AD でアプリケーションを構成します。</span><span class="sxs-lookup"><span data-stu-id="a0993-128">Step 1: Configure an application in Azure AD</span></span>

<span data-ttu-id="a0993-129">Microsoft ストア コレクション API を使用するか、購入 API、前に、Azure AD Web アプリケーションを作成するテナント ID とアプリケーションのアプリケーションの ID を取得、キーを生成してください。</span><span class="sxs-lookup"><span data-stu-id="a0993-129">Before you can use the Microsoft Store collection API or purchase API, you must create an Azure AD Web application, retrieve the tenant ID and application ID for the application, and generate a key.</span></span> <span data-ttu-id="a0993-130">Azure AD Web アプリケーションでは、Microsoft ストア コレクション API 呼び出しまたは API を購入するサービスを表します。</span><span class="sxs-lookup"><span data-stu-id="a0993-130">The Azure AD Web application represents the service from which you want to call the Microsoft Store collection API or purchase API.</span></span> <span data-ttu-id="a0993-131">API を呼び出す必要がある Azure AD アクセス トークンを生成するには、テナント ID、アプリケーション ID およびキー必要があります。</span><span class="sxs-lookup"><span data-stu-id="a0993-131">You need the tenant ID, application ID and key to generate Azure AD access tokens that you need to call the API.</span></span>

> [!NOTE]
> <span data-ttu-id="a0993-132">このセクションの作業は 1 回実行する必要があるだけです。</span><span class="sxs-lookup"><span data-stu-id="a0993-132">You only need to perform the tasks in this section one time.</span></span> <span data-ttu-id="a0993-133">Azure AD アプリケーション マニフェストを更新すると、アプリケーションの ID とクライアント シークレット、テナントの ID がある場合、再利用できるこれらの値を新規作成に必要ないつでも Azure AD アクセス トークンします。</span><span class="sxs-lookup"><span data-stu-id="a0993-133">After you update your Azure AD application manifest and you have your tenant ID, application ID and client secret, you can reuse these values any time you need to create a new Azure AD access token.</span></span>

1.  <span data-ttu-id="a0993-134">まだ、登録していない場合の指示に従って[Azure Active Directory を統合するアプリケーション](https://docs.microsoft.com/azure/active-directory/develop/active-directory-integrating-applications)を登録する**Web app/API** Azure ad アプリケーションします。</span><span class="sxs-lookup"><span data-stu-id="a0993-134">If you haven't done so already, follow the instructions in [Integrating Applications with Azure Active Directory](https://docs.microsoft.com/azure/active-directory/develop/active-directory-integrating-applications) to register a **Web app / API** application with Azure AD.</span></span>
    > [!NOTE]
    > <span data-ttu-id="a0993-135">アプリケーションを登録するときに選ぶ必要があります**Web app/API**アプリケーションの (*クライアント シークレット*とも呼ばれます) キーを取得できるようにする、アプリケーションが入力します。</span><span class="sxs-lookup"><span data-stu-id="a0993-135">When you register your application, you must choose **Web app / API** as the application type so that you can retrieve a key (also called a *client secret*) for your application.</span></span> <span data-ttu-id="a0993-136">Microsoft Store コレクション API または購入 API を呼び出すには、後の手順で Azure AD からアクセス トークンを要求するときにクライアント シークレットを指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a0993-136">In order to call the Microsoft Store collection API or purchase API, you must provide a client secret when you request an access token from Azure AD in a later step.</span></span>

2.  <span data-ttu-id="a0993-137">[Azure 管理ポータル](https://portal.azure.com/)では、[ **Azure Active Directory**に移動します。</span><span class="sxs-lookup"><span data-stu-id="a0993-137">In the [Azure Management Portal](https://portal.azure.com/), navigate to **Azure Active Directory**.</span></span> <span data-ttu-id="a0993-138">ディレクトリを選択して、左側のナビゲーション ウィンドウで、**アプリの登録**] をクリックして、[アプリケーション] を選びます。</span><span class="sxs-lookup"><span data-stu-id="a0993-138">Select your directory, click **App registrations** in the left navigation pane, and then select your application.</span></span>
3.  <span data-ttu-id="a0993-139">アプリケーションのメインの登録] ページが表示されます。</span><span class="sxs-lookup"><span data-stu-id="a0993-139">You are taken to the application's main registration page.</span></span> <span data-ttu-id="a0993-140">このページでは、後で使用する**アプリケーションの ID**の値をコピーします。</span><span class="sxs-lookup"><span data-stu-id="a0993-140">On this page, copy the **Application ID** value for use later.</span></span>
4.  <span data-ttu-id="a0993-141">後で必要なキーを作成する (よっては [すべての*クライアント シークレット*)。</span><span class="sxs-lookup"><span data-stu-id="a0993-141">Create a key that you will need later (this is all called a *client secret*).</span></span> <span data-ttu-id="a0993-142">左側のウィンドウで [**設定]** [**キー**] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="a0993-142">In the left pane, click **Settings** and then **Keys**.</span></span> <span data-ttu-id="a0993-143">このページで、[キーを作成](https://docs.microsoft.com/azure/active-directory/develop/active-directory-integrating-applications#to-add-application-credentials-or-permissions-to-access-web-apis)する手順を実行します。</span><span class="sxs-lookup"><span data-stu-id="a0993-143">On this page, complete the steps to [create a key](https://docs.microsoft.com/azure/active-directory/develop/active-directory-integrating-applications#to-add-application-credentials-or-permissions-to-access-web-apis).</span></span> <span data-ttu-id="a0993-144">後で使用するためには、このキーをコピーします。</span><span class="sxs-lookup"><span data-stu-id="a0993-144">Copy this key for later use.</span></span>
5.  <span data-ttu-id="a0993-145">[アプリケーション マニフェスト](https://docs.microsoft.com/azure/active-directory/develop/active-directory-application-manifest)に、いくつか必要な対象ユーザーの Uri を追加します。</span><span class="sxs-lookup"><span data-stu-id="a0993-145">Add several required audience URIs to your [application manifest](https://docs.microsoft.com/azure/active-directory/develop/active-directory-application-manifest).</span></span> <span data-ttu-id="a0993-146">左側のウィンドウで [**マニフェスト**] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="a0993-146">In the left pane, click **Manifest**.</span></span> <span data-ttu-id="a0993-147">[**編集**] を置き換える、 `"identifierUris"` 、次のテキストを含むセクションし、[**保存**] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="a0993-147">Click **Edit**, replace the `"identifierUris"` section with the following text, and then click **Save**.</span></span>

    ```json
    "identifierUris" : [                                
            "https://onestore.microsoft.com",
            "https://onestore.microsoft.com/b2b/keys/create/collections",
            "https://onestore.microsoft.com/b2b/keys/create/purchase"
        ],
    ```

    <span data-ttu-id="a0993-148">これらの文字列は、アプリケーションでサポートされる対象ユーザーを表します。</span><span class="sxs-lookup"><span data-stu-id="a0993-148">These strings represent the audiences supported by your application.</span></span> <span data-ttu-id="a0993-149">後の手順で、各対象ユーザー値に関連付けられた Azure AD アクセス トークンを作成します。</span><span class="sxs-lookup"><span data-stu-id="a0993-149">In a later step, you will create Azure AD access tokens that are associated with each of these audience values.</span></span>

<span id="step-2"/>

## <a name="step-2-associate-your-azure-ad-application-id-with-your-client-app-in-windows-dev-center"></a><span data-ttu-id="a0993-150">手順 2: Azure AD アプリケーションの ID を Windows デベロッパー センターでクライアント アプリケーションに関連付ける</span><span class="sxs-lookup"><span data-stu-id="a0993-150">Step 2: Associate your Azure AD application ID with your client app in Windows Dev Center</span></span>

<span data-ttu-id="a0993-151">Microsoft ストア コレクション API を使用するか、購入 API のアプリやアドオンの購入、所有権を構成するのには、前に、デベロッパー センターのダッシュ ボード (とアドオンが含まれてアプリ) のアプリの Azure AD アプリケーションの ID を関連付ける必要があります。</span><span class="sxs-lookup"><span data-stu-id="a0993-151">Before you can use the Microsoft Store collection API or purchase API to configure the ownership and purchases for your app or add-on, you must associate your Azure AD application ID with the app (or the app that contains the add-on) in the Dev Center dashboard.</span></span>

> [!NOTE]
> <span data-ttu-id="a0993-152">この作業を行うのは一度だけです。</span><span class="sxs-lookup"><span data-stu-id="a0993-152">You only need to perform this task one time.</span></span>

1.  <span data-ttu-id="a0993-153">[デベロッパー センター ダッシュボード](https://dev.windows.com/overview)にサインインし、アプリを選択します。</span><span class="sxs-lookup"><span data-stu-id="a0993-153">Sign in to the [Dev Center dashboard](https://dev.windows.com/overview) and select your app.</span></span>
2.  <span data-ttu-id="a0993-154">**サービス**に移動&gt;**製品コレクションと購入**] ページを開き、利用可能な**クライアント ID**フィールドのいずれかに Azure AD アプリケーションの ID を入力します。</span><span class="sxs-lookup"><span data-stu-id="a0993-154">Go to the **Services** &gt; **Product collections and purchases** page and enter your Azure AD application ID into one of the available **Client ID** fields.</span></span>

<span id="step-3"/>

## <a name="step-3-create-azure-ad-access-tokens"></a><span data-ttu-id="a0993-155">手順 3: Azure AD アクセス トークンを作成する</span><span class="sxs-lookup"><span data-stu-id="a0993-155">Step 3: Create Azure AD access tokens</span></span>

<span data-ttu-id="a0993-156">Microsoft Store ID キーを取得したり、Microsoft Store コレクション API または Microsoft Store 購入 API を呼び出したりする前に、発行元 ID を表すいくつかの Azure AD アクセス トークンをサービスで作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a0993-156">Before you can retrieve a Microsoft Store ID key or call the Microsoft Store collection API or purchase API, your service must create several different Azure AD access tokens that represent your publisher identity.</span></span> <span data-ttu-id="a0993-157">各トークンは別々の API で使われます。</span><span class="sxs-lookup"><span data-stu-id="a0993-157">Each token will be used with a different API.</span></span> <span data-ttu-id="a0993-158">各トークンの有効期間は 60 分であり、有効期限が切れた場合は更新できます。</span><span class="sxs-lookup"><span data-stu-id="a0993-158">The lifetime of each token is 60 minutes, and you can refresh them after they expire.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="a0993-159">Azure AD アクセス トークンは、アプリ内ではなく、サービスのコンテキスト内でのみ作成してください。</span><span class="sxs-lookup"><span data-stu-id="a0993-159">Create Azure AD access tokens only in the context of your service, not in your app.</span></span> <span data-ttu-id="a0993-160">このアクセス トークンがアプリに送信されると、クライアント シークレットが侵害される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="a0993-160">Your client secret could be compromised if it is sent to your app.</span></span>

<span id="access-tokens" />

### <a name="understanding-the-different-tokens-and-audience-uris"></a><span data-ttu-id="a0993-161">さまざまなトークンとオーディエンス URI を理解する</span><span class="sxs-lookup"><span data-stu-id="a0993-161">Understanding the different tokens and audience URIs</span></span>

<span data-ttu-id="a0993-162">Microsoft Store コレクション API または購入 API で呼び出そうとしているメソッドに応じて、2 つまたは 3 つの異なるトークンを作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a0993-162">Depending on which methods you want to call in the Microsoft Store collection API or purchase API, you must create either two or three different tokens.</span></span> <span data-ttu-id="a0993-163">各アクセス トークンは、別々のオーディエンス URI に関連付けられます (これらは、以前に Azure AD アプリケーション マニフェストの `"identifierUris"` セクションに追加した URI と同じです)。</span><span class="sxs-lookup"><span data-stu-id="a0993-163">Each access token is associated with a different audience URI (these are the same URIs that you previously added to the `"identifierUris"` section of the Azure AD application manifest).</span></span>

  * <span data-ttu-id="a0993-164">いずれの場合も、`https://onestore.microsoft.com` オーディエンス URI のトークンを 1 つ作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a0993-164">In all cases, you must create a token with the `https://onestore.microsoft.com` audience URI.</span></span> <span data-ttu-id="a0993-165">このトークンは、後の手順で Microsoft Store コレクション API または購入 API のメソッドの **Authorization** ヘッダーに渡します。</span><span class="sxs-lookup"><span data-stu-id="a0993-165">In a later step, you will pass this token to the **Authorization** header of methods in the Microsoft Store collection API or purchase API.</span></span>
      > [!IMPORTANT]
      > <span data-ttu-id="a0993-166">`https://onestore.microsoft.com` 対象ユーザーには、サービス内に安全に格納されたアクセス トークンのみを使用してください。</span><span class="sxs-lookup"><span data-stu-id="a0993-166">Use the `https://onestore.microsoft.com` audience only with access tokens that are stored securely within your service.</span></span> <span data-ttu-id="a0993-167">このオーディエンスのアクセス トークンがサービス外に公開されると、サービスがリプレイ攻撃に対して脆弱になる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="a0993-167">Exposing access tokens with this audience outside your service could make your service vulnerable to replay attacks.</span></span>

  * <span data-ttu-id="a0993-168">Microsoft Store コレクション API のメソッドを呼び出して、[特定のユーザーが所有する製品を照会](query-for-products.md)したり、[コンシューマブルな製品をフルフィルメント完了として報告](report-consumable-products-as-fulfilled.md)したりする場合は、`https://onestore.microsoft.com/b2b/keys/create/collections` オーディエンス URI のトークンも作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a0993-168">If you want to call a method in the Microsoft Store collection API to [query for products owned by a user](query-for-products.md) or [report a consumable product as fulfilled](report-consumable-products-as-fulfilled.md), you must also create a token with the `https://onestore.microsoft.com/b2b/keys/create/collections` audience URI.</span></span> <span data-ttu-id="a0993-169">後の手順で、このトークンを Windows SDK のクライアント メソッドに渡し、Microsoft Store コレクション API で使用できる Microsoft Store ID キーを要求します。</span><span class="sxs-lookup"><span data-stu-id="a0993-169">In a later step, you will pass this token to a client method in the Windows SDK to request a Microsoft Store ID key that you can use with the Microsoft Store collection API.</span></span>

  * <span data-ttu-id="a0993-170">Microsoft Store 購入 API でメソッドを呼び出して[無料の製品をユーザーに付与する](grant-free-products.md)、[ユーザーのサブスクリプションを取得する](get-subscriptions-for-a-user.md)、または[ユーザーのサブスクリプションに関する請求の状態を変更する](change-the-billing-state-of-a-subscription-for-a-user.md)場合、`https://onestore.microsoft.com/b2b/keys/create/purchase` 対象ユーザー URI を使ってトークンも作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a0993-170">If you want to call a method in the Microsoft Store purchase API to [grant a free product to a user](grant-free-products.md), [get subscriptions for a user](get-subscriptions-for-a-user.md), or [change the billing state of a subscription for a user](change-the-billing-state-of-a-subscription-for-a-user.md), you must also create a token with the `https://onestore.microsoft.com/b2b/keys/create/purchase` audience URI.</span></span> <span data-ttu-id="a0993-171">後の手順で、このトークンを Windows SDK のクライアント メソッドに渡し、Microsoft Store 購入 API で使用できる Microsoft Store ID キーを要求します。</span><span class="sxs-lookup"><span data-stu-id="a0993-171">In a later step, you will pass this token to a client method in the Windows SDK to request a Microsoft Store ID key that you can use with the Microsoft Store purchase API.</span></span>

<span />

### <a name="create-the-tokens"></a><span data-ttu-id="a0993-172">トークンの作成</span><span class="sxs-lookup"><span data-stu-id="a0993-172">Create the tokens</span></span>

<span data-ttu-id="a0993-173">アクセス トークンを作成するには、「[クライアント資格情報を使用したサービス間の呼び出し](https://azure.microsoft.com/documentation/articles/active-directory-protocols-oauth-service-to-service)」の手順に従って OAuth 2.0 API をサービスで使用し、HTTP POST を ```https://login.microsoftonline.com/<tenant_id>/oauth2/token``` エンドポイントに送信します。</span><span class="sxs-lookup"><span data-stu-id="a0993-173">To create the access tokens, use the OAuth 2.0 API in your service by following the instructions in [Service to Service Calls Using Client Credentials](https://azure.microsoft.com/documentation/articles/active-directory-protocols-oauth-service-to-service) to send an HTTP POST to the ```https://login.microsoftonline.com/<tenant_id>/oauth2/token``` endpoint.</span></span> <span data-ttu-id="a0993-174">要求の例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="a0993-174">Here is a sample request.</span></span>

``` syntax
POST https://login.microsoftonline.com/<tenant_id>/oauth2/token HTTP/1.1
Host: login.microsoftonline.com
Content-Type: application/x-www-form-urlencoded; charset=utf-8

grant_type=client_credentials
&client_id=<your_client_id>
&client_secret=<your_client_secret>
&resource=https://onestore.microsoft.com
```

<span data-ttu-id="a0993-175">各トークンについて、次のパラメーター データを指定します。</span><span class="sxs-lookup"><span data-stu-id="a0993-175">For each token, specify the following parameter data:</span></span>

* <span data-ttu-id="a0993-176">*Client\_id*と*client\_secret*パラメーター アプリケーション ID と[Azure 管理ポータル](http://manage.windowsazure.com)から取得したアプリケーションにクライアント シークレットを指定します。</span><span class="sxs-lookup"><span data-stu-id="a0993-176">For the *client\_id* and *client\_secret* parameters, specify the application ID and the client secret for your application that you retrieved from the [Azure Management Portal](http://manage.windowsazure.com).</span></span> <span data-ttu-id="a0993-177">これらのパラメーターはいずれも、Microsoft Store コレクション API または購入 API で必要とされる認証のレベルに基づいてアクセス トークンを生成するために必要です。</span><span class="sxs-lookup"><span data-stu-id="a0993-177">Both of these parameters are required in order to create an access token with the level of authentication required by the Microsoft Store collection API or purchase API.</span></span>

* <span data-ttu-id="a0993-178">*resource* パラメーターには、作成するアクセス トークンの種類に応じて、[前のセクション](#access-tokens)に記載したいずれかのオーディエンス URI を指定します。</span><span class="sxs-lookup"><span data-stu-id="a0993-178">For the *resource* parameter, specify one of the audience URIs listed in the [previous section](#access-tokens), depending on the type of access token you are creating.</span></span>

<span data-ttu-id="a0993-179">アクセス トークンの有効期限が切れた後は、[こちらのトピック](https://azure.microsoft.com/documentation/articles/active-directory-protocols-oauth-code/#refreshing-the-access-tokens)の手順に従って更新できます。</span><span class="sxs-lookup"><span data-stu-id="a0993-179">After your access token expires, you can refresh it by following the instructions [here](https://azure.microsoft.com/documentation/articles/active-directory-protocols-oauth-code/#refreshing-the-access-tokens).</span></span> <span data-ttu-id="a0993-180">アクセス トークンの構造について詳しくは、「[サポートされているトークンと要求の種類](http://go.microsoft.com/fwlink/?LinkId=722501)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a0993-180">For more details about the structure of an access token, see [Supported Token and Claim Types](http://go.microsoft.com/fwlink/?LinkId=722501).</span></span>

<span id="step-4"/>

## <a name="step-4-create-a-microsoft-store-id-key"></a><span data-ttu-id="a0993-181">手順 4: Microsoft Store ID キーを生成する</span><span class="sxs-lookup"><span data-stu-id="a0993-181">Step 4: Create a Microsoft Store ID key</span></span>

<span data-ttu-id="a0993-182">Microsoft Store コレクション API または Microsoft Store 購入 API のメソッドを呼び出すには、事前にアプリで Microsoft Store ID キーを作成し、サービスに送信する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a0993-182">Before you can call any method in the Microsoft Store collection API or purchase API, your app must create a Microsoft Store ID key and send it to your service.</span></span> <span data-ttu-id="a0993-183">このキーは、アクセス対象の製品所有権情報を保持するユーザーの ID を表す JSON Web トークン (JWT) です。</span><span class="sxs-lookup"><span data-stu-id="a0993-183">This key is a JSON Web Token (JWT) that represents the identity of the user whose product ownership information you want to access.</span></span> <span data-ttu-id="a0993-184">このキーの要求について詳しくは、「[Microsoft Store ID キー内の要求](#claims-in-a-microsoft-store-id-key)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a0993-184">For more information about the claims in this key, see [Claims in a Microsoft Store ID key](#claims-in-a-microsoft-store-id-key).</span></span>

<span data-ttu-id="a0993-185">現時点では、Microsoft Store ID キーを作成する唯一の方法は、アプリ内のコードからユニバーサル Windows プラットフォーム (UWP) API を呼び出すことです。</span><span class="sxs-lookup"><span data-stu-id="a0993-185">Currently, the only way to create a Microsoft Store ID key is by calling a Universal Windows Platform (UWP) API from client code in your app.</span></span> <span data-ttu-id="a0993-186">生成されたキーは、デバイスで現在 Microsoft Store にサインインしているユーザーの ID を表します。</span><span class="sxs-lookup"><span data-stu-id="a0993-186">The generated key represents the identity of the user who is currently signed in to the Microsoft Store on the device.</span></span>

> [!NOTE]
> <span data-ttu-id="a0993-187">各 Microsoft Store ID キーは 90 日間有効です。</span><span class="sxs-lookup"><span data-stu-id="a0993-187">Each Microsoft Store ID key is valid for 90 days.</span></span> <span data-ttu-id="a0993-188">キーの有効期限が切れた場合は、[キーを更新](renew-a-windows-store-id-key.md)できます。</span><span class="sxs-lookup"><span data-stu-id="a0993-188">After a key expires, you can [renew the key](renew-a-windows-store-id-key.md).</span></span> <span data-ttu-id="a0993-189">新しい Microsoft Store ID キーを作成するのではなく、更新することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="a0993-189">We recommend that you renew your Microsoft Store ID keys rather than creating new ones.</span></span>

<span />

### <a name="to-create-a-microsoft-store-id-key-for-the-microsoft-store-collection-api"></a><span data-ttu-id="a0993-190">Microsoft Store コレクション API 用の Microsoft Store ID キーを作成するには</span><span class="sxs-lookup"><span data-stu-id="a0993-190">To create a Microsoft Store ID key for the Microsoft Store collection API</span></span>

<span data-ttu-id="a0993-191">[特定のユーザーが所有する製品を照会](query-for-products.md)したり、[コンシューマブルな製品をフルフィルメント完了として報告](report-consumable-products-as-fulfilled.md)したりするために、Microsoft Store コレクション API で使用できる Microsoft Store ID キーを作成するには、次の手順に従います。</span><span class="sxs-lookup"><span data-stu-id="a0993-191">Follow these steps to create a Microsoft Store ID key that you can use with the Microsoft Store collection API to [query for products owned by a user](query-for-products.md) or [report a consumable product as fulfilled](report-consumable-products-as-fulfilled.md).</span></span>

1.  <span data-ttu-id="a0993-192">オーディエンス URI 値 `https://onestore.microsoft.com/b2b/keys/create/collections` を持つ Azure AD アクセス トークンを、サービスからクライアント アプリに渡します。</span><span class="sxs-lookup"><span data-stu-id="a0993-192">Pass the Azure AD access token that has the audience URI value `https://onestore.microsoft.com/b2b/keys/create/collections` from your service to your client app.</span></span> <span data-ttu-id="a0993-193">これは、[前述の手順 3](#step-3) で作成したトークンのいずれかです。</span><span class="sxs-lookup"><span data-stu-id="a0993-193">This is one of the tokens you created [earlier in step 3](#step-3).</span></span>

2.  <span data-ttu-id="a0993-194">アプリ コードで次のいずれかのメソッドを呼び出して、Microsoft Store ID キーを取得します。</span><span class="sxs-lookup"><span data-stu-id="a0993-194">In your app code, call one of these methods to retrieve a Microsoft Store ID key:</span></span>

  * <span data-ttu-id="a0993-195">アプリで [Windows.Services.Store](https://docs.microsoft.com/uwp/api/windows.services.store) 名前空間の [StoreContext](https://docs.microsoft.com/uwp/api/Windows.Services.Store.StoreContext) クラスを使ってアプリ内購入を管理する場合は、[StoreContext.GetCustomerCollectionsIdAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.getcustomercollectionsidasync) メソッドを使用します。</span><span class="sxs-lookup"><span data-stu-id="a0993-195">If your app uses the [StoreContext](https://docs.microsoft.com/uwp/api/Windows.Services.Store.StoreContext) class in the [Windows.Services.Store](https://docs.microsoft.com/uwp/api/windows.services.store) namespace to manage in-app purchases, use the [StoreContext.GetCustomerCollectionsIdAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.getcustomercollectionsidasync) method.</span></span>

  * <span data-ttu-id="a0993-196">アプリで [Windows.ApplicationModel.Store](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store) 名前空間の  [CurrentApp](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Store.CurrentApp) クラスを使ってアプリ内購入を管理する場合は、[CurrentApp.GetCustomerCollectionsIdAsync](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.currentapp.getcustomercollectionsidasync) メソッドを使用します。</span><span class="sxs-lookup"><span data-stu-id="a0993-196">If your app uses the [CurrentApp](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Store.CurrentApp) class in the [Windows.ApplicationModel.Store](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store) namespace to manage in-app purchases, use the [CurrentApp.GetCustomerCollectionsIdAsync](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.currentapp.getcustomercollectionsidasync) method.</span></span>

    <span data-ttu-id="a0993-197">メソッドの *serviceTicket* パラメーターに、Azure AD アクセス トークンを渡します。</span><span class="sxs-lookup"><span data-stu-id="a0993-197">Pass your Azure AD access token to the *serviceTicket* parameter of the method.</span></span> <span data-ttu-id="a0993-198">現在のユーザーを新しい Microsoft ストア ID キー (ユーザー ID がある全角に関連付ける*publisherUserId*パラメーターにユーザー ID を渡すことも、現在のアプリの発行元として管理サービスのコンテキストで匿名ユーザー Id を管理している場合bedded キー)。</span><span class="sxs-lookup"><span data-stu-id="a0993-198">If you maintain anonymous user IDs in the context of services that you manage as the publisher of the current app, you can also pass a user ID to the *publisherUserId* parameter to associate the current user with the new Microsoft Store ID key (the user ID will be embedded in the key).</span></span> <span data-ttu-id="a0993-199">それ以外の場合、Microsoft ストア ID キーを使って、ユーザー ID に関連付ける必要がない場合は、任意の文字列値を*publisherUserId*パラメーターに渡すことができます。</span><span class="sxs-lookup"><span data-stu-id="a0993-199">Otherwise, if you don't need to associate a user ID with the Microsoft Store ID key, you can pass any string value to the *publisherUserId* parameter.</span></span>

3.  <span data-ttu-id="a0993-200">アプリで正しく Microsoft Store ID キーを作成したら、そのキーをサービスに渡します。</span><span class="sxs-lookup"><span data-stu-id="a0993-200">After your app successfully creates a Microsoft Store ID key, pass the key back to your service.</span></span>

<span />

### <a name="to-create-a-microsoft-store-id-key-for-the-microsoft-store-purchase-api"></a><span data-ttu-id="a0993-201">Microsoft Store 購入 API 用の Microsoft Store ID キーを作成するには</span><span class="sxs-lookup"><span data-stu-id="a0993-201">To create a Microsoft Store ID key for the Microsoft Store purchase API</span></span>

<span data-ttu-id="a0993-202">[無料の製品をユーザーに付与する](grant-free-products.md)、[ユーザーのサブスクリプションを取得する](get-subscriptions-for-a-user.md)、または[ユーザーのサブスクリプションの請求状態を変更する](change-the-billing-state-of-a-subscription-for-a-user.md)ために、Microsoft Store 購入 API と共に使うことができる Microsoft Store ID キーを作成するには、以下の手順に従います。</span><span class="sxs-lookup"><span data-stu-id="a0993-202">Follow these steps to create a Microsoft Store ID key that you can use with the Microsoft Store purchase API to [grant a free product to a user](grant-free-products.md), [get subscriptions for a user](get-subscriptions-for-a-user.md), or [change the billing state of a subscription for a user](change-the-billing-state-of-a-subscription-for-a-user.md).</span></span>

1.  <span data-ttu-id="a0993-203">オーディエンス URI 値 `https://onestore.microsoft.com/b2b/keys/create/purchase` を持つ Azure AD アクセス トークンを、サービスからクライアント アプリに渡します。</span><span class="sxs-lookup"><span data-stu-id="a0993-203">Pass the Azure AD access token that has the audience URI value `https://onestore.microsoft.com/b2b/keys/create/purchase` from your service to your client app.</span></span> <span data-ttu-id="a0993-204">これは、[前述の手順 3](#step-3) で作成したトークンのいずれかです。</span><span class="sxs-lookup"><span data-stu-id="a0993-204">This is one of the tokens you created [earlier in step 3](#step-3).</span></span>

2.  <span data-ttu-id="a0993-205">アプリ コードで次のいずれかのメソッドを呼び出して、Microsoft Store ID キーを取得します。</span><span class="sxs-lookup"><span data-stu-id="a0993-205">In your app code, call one of these methods to retrieve a Microsoft Store ID key:</span></span>

  * <span data-ttu-id="a0993-206">アプリで [Windows.Services.Store](https://docs.microsoft.com/uwp/api/windows.services.store) 名前空間の [StoreContext](https://docs.microsoft.com/uwp/api/Windows.Services.Store.StoreContext) クラスを使ってアプリ内購入を管理する場合は、[StoreContext.GetCustomerPurchaseIdAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.getcustomerpurchaseidasync) メソッドを使用します。</span><span class="sxs-lookup"><span data-stu-id="a0993-206">If your app uses the [StoreContext](https://docs.microsoft.com/uwp/api/Windows.Services.Store.StoreContext) class in the [Windows.Services.Store](https://docs.microsoft.com/uwp/api/windows.services.store) namespace to manage in-app purchases, use the [StoreContext.GetCustomerPurchaseIdAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.getcustomerpurchaseidasync) method.</span></span>

  * <span data-ttu-id="a0993-207">アプリで [Windows.ApplicationModel.Store](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store) 名前空間の [CurrentApp](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Store.CurrentApp) クラスを使ってアプリ内購入を管理する場合は、[CurrentApp.GetCustomerPurchaseIdAsync](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.currentapp.getcustomerpurchaseidasync) メソッドを使用します。</span><span class="sxs-lookup"><span data-stu-id="a0993-207">If your app uses the [CurrentApp](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Store.CurrentApp) class in the [Windows.ApplicationModel.Store](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store) namespace to manage in-app purchases, use the [CurrentApp.GetCustomerPurchaseIdAsync](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.currentapp.getcustomerpurchaseidasync) method.</span></span>

    <span data-ttu-id="a0993-208">メソッドの *serviceTicket* パラメーターに、Azure AD アクセス トークンを渡します。</span><span class="sxs-lookup"><span data-stu-id="a0993-208">Pass your Azure AD access token to the *serviceTicket* parameter of the method.</span></span> <span data-ttu-id="a0993-209">現在のユーザーを新しい Microsoft ストア ID キー (ユーザー ID がある全角に関連付ける*publisherUserId*パラメーターにユーザー ID を渡すことも、現在のアプリの発行元として管理サービスのコンテキストで匿名ユーザー Id を管理している場合bedded キー)。</span><span class="sxs-lookup"><span data-stu-id="a0993-209">If you maintain anonymous user IDs in the context of services that you manage as the publisher of the current app, you can also pass a user ID to the *publisherUserId* parameter to associate the current user with the new Microsoft Store ID key (the user ID will be embedded in the key).</span></span> <span data-ttu-id="a0993-210">それ以外の場合、Microsoft ストア ID キーを使って、ユーザー ID に関連付ける必要がない場合は、任意の文字列値を*publisherUserId*パラメーターに渡すことができます。</span><span class="sxs-lookup"><span data-stu-id="a0993-210">Otherwise, if you don't need to associate a user ID with the Microsoft Store ID key, you can pass any string value to the *publisherUserId* parameter.</span></span>

3.  <span data-ttu-id="a0993-211">アプリで正しく Microsoft Store ID キーを作成したら、そのキーをサービスに渡します。</span><span class="sxs-lookup"><span data-stu-id="a0993-211">After your app successfully creates a Microsoft Store ID key, pass the key back to your service.</span></span>

### <a name="diagram"></a><span data-ttu-id="a0993-212">ダイアグラム</span><span class="sxs-lookup"><span data-stu-id="a0993-212">Diagram</span></span>

<span data-ttu-id="a0993-213">次の図は、Microsoft ストア ID キーを作成するプロセスを示しています。</span><span class="sxs-lookup"><span data-stu-id="a0993-213">The following diagram illustrates the process of creating a Microsoft Store ID key.</span></span>

  ![Windows ストア ID キーを作成します。](images/b2b-1.png)

<span id="step-5"/>

## <a name="step-5-call-the-microsoft-store-collection-api-or-purchase-api-from-your-service"></a><span data-ttu-id="a0993-215">手順 5: サービスから Microsoft Store コレクション API または購入 API を呼び出す</span><span class="sxs-lookup"><span data-stu-id="a0993-215">Step 5: Call the Microsoft Store collection API or purchase API from your service</span></span>

<span data-ttu-id="a0993-216">特定のユーザーの製品所有権情報にアクセスするための Microsoft Store ID キーをサービスで取得したら、次の手順に従って、サービスから Microsoft Store コレクション API または購入 API を呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="a0993-216">After your service has a Microsoft Store ID key that enables it to access a specific user's product ownership information, your service can call the Microsoft Store collection API or purchase API by following these instructions:</span></span>

* [<span data-ttu-id="a0993-217">製品の照会</span><span class="sxs-lookup"><span data-stu-id="a0993-217">Query for products</span></span>](query-for-products.md)
* [<span data-ttu-id="a0993-218">コンシューマブルな製品をフルフィルメント完了として報告する</span><span class="sxs-lookup"><span data-stu-id="a0993-218">Report consumable products as fulfilled</span></span>](report-consumable-products-as-fulfilled.md)
* [<span data-ttu-id="a0993-219">無料の製品の付与</span><span class="sxs-lookup"><span data-stu-id="a0993-219">Grant free products</span></span>](grant-free-products.md)
* [<span data-ttu-id="a0993-220">ユーザーのサブスクリプションを取得する</span><span class="sxs-lookup"><span data-stu-id="a0993-220">Get subscriptions for a user</span></span>](get-subscriptions-for-a-user.md)
* [<span data-ttu-id="a0993-221">ユーザーのサブスクリプションに関する請求の状態を変更する</span><span class="sxs-lookup"><span data-stu-id="a0993-221">Change the billing state of a subscription for a user</span></span>](change-the-billing-state-of-a-subscription-for-a-user.md)

<span data-ttu-id="a0993-222">各シナリオについて、次の情報を API に渡します。</span><span class="sxs-lookup"><span data-stu-id="a0993-222">For each scenario, pass the following information to the API:</span></span>

-   <span data-ttu-id="a0993-223">要求ヘッダーで、対象ユーザー URI 値 `https://onestore.microsoft.com` を持つ Azure AD アクセス トークンを渡します。</span><span class="sxs-lookup"><span data-stu-id="a0993-223">In the request header, pass the Azure AD access token that has the audience URI value `https://onestore.microsoft.com`.</span></span> <span data-ttu-id="a0993-224">これは、[前述の手順 3](#step-3) で作成したトークンのいずれかです。</span><span class="sxs-lookup"><span data-stu-id="a0993-224">This is one of the tokens you created [earlier in step 3](#step-3).</span></span> <span data-ttu-id="a0993-225">このトークンは発行元 ID を表します。</span><span class="sxs-lookup"><span data-stu-id="a0993-225">This token represents your publisher identity.</span></span>
-   <span data-ttu-id="a0993-226">要求本文で、[前述の手順 4](#step-4) でアプリのクライアント側コードから取得した Microsoft Store ID キーを渡します。</span><span class="sxs-lookup"><span data-stu-id="a0993-226">In the request body, pass the Microsoft Store ID key you retrieved [earlier in step 4](#step-4) from client-side code in your app.</span></span> <span data-ttu-id="a0993-227">このキーは、ユーザーの製品所有権情報にアクセスする場合にそのユーザーの ID を表します。</span><span class="sxs-lookup"><span data-stu-id="a0993-227">This key represents the identity of the user whose product ownership information you want to access.</span></span>

### <a name="diagram"></a><span data-ttu-id="a0993-228">ダイアグラム</span><span class="sxs-lookup"><span data-stu-id="a0993-228">Diagram</span></span>

<span data-ttu-id="a0993-229">次の図は、メソッド、Microsoft ストア コレクション API または購入 API でのサービスからのプロセスを説明します。</span><span class="sxs-lookup"><span data-stu-id="a0993-229">The following diagram describes the process of calling a method in the Microsoft Store collection API or purchase API from your service.</span></span>

  ![コレクションまたは購入 API を呼び出す](images/b2b-2.png)

## <a name="claims-in-a-microsoft-store-id-key"></a><span data-ttu-id="a0993-231">Microsoft Store ID キー内の要求</span><span class="sxs-lookup"><span data-stu-id="a0993-231">Claims in a Microsoft Store ID key</span></span>

<span data-ttu-id="a0993-232">Microsoft Store ID キーは、ユーザーの製品所有権情報にアクセスする場合にそのユーザーの ID を表す JSON Web トークン (JWT) です。</span><span class="sxs-lookup"><span data-stu-id="a0993-232">A Microsoft Store ID key is a JSON Web Token (JWT) that represents the identity of the user whose product ownership information you want to access.</span></span> <span data-ttu-id="a0993-233">Base64 を使用してデコードされた Microsoft Store ID キーには、次の要求が含まれています。</span><span class="sxs-lookup"><span data-stu-id="a0993-233">When decoded using Base64, a Microsoft Store ID key contains the following claims.</span></span>

* `iat`<span data-ttu-id="a0993-234">:&nbsp;&nbsp;&nbsp;キーが発行された時刻を識別します。</span><span class="sxs-lookup"><span data-stu-id="a0993-234">:&nbsp;&nbsp;&nbsp;Identifies the time at which the key was issued.</span></span> <span data-ttu-id="a0993-235">この要求は、トークンの経過期間を判別するために使用できます。</span><span class="sxs-lookup"><span data-stu-id="a0993-235">This claim can be used to determine the age of the token.</span></span> <span data-ttu-id="a0993-236">この値はエポック時間で表されます。</span><span class="sxs-lookup"><span data-stu-id="a0993-236">This value is expressed as epoch time.</span></span>
* `iss`<span data-ttu-id="a0993-237">:&nbsp;&nbsp;&nbsp;発行者を識別します。</span><span class="sxs-lookup"><span data-stu-id="a0993-237">:&nbsp;&nbsp;&nbsp;Identifies the issuer.</span></span> <span data-ttu-id="a0993-238">これは `aud` 要求と同じ値を持ちます。</span><span class="sxs-lookup"><span data-stu-id="a0993-238">This has the same value as the `aud` claim.</span></span>
* `aud`<span data-ttu-id="a0993-239">:&nbsp;&nbsp;&nbsp;オーディエンスを識別します。</span><span class="sxs-lookup"><span data-stu-id="a0993-239">:&nbsp;&nbsp;&nbsp;Identifies the audience.</span></span> <span data-ttu-id="a0993-240">`https://collections.mp.microsoft.com/v6.0/keys` または `https://purchase.mp.microsoft.com/v6.0/keys` のいずれかの値である必要があります。</span><span class="sxs-lookup"><span data-stu-id="a0993-240">Must be one of the following values: `https://collections.mp.microsoft.com/v6.0/keys` or `https://purchase.mp.microsoft.com/v6.0/keys`.</span></span>
* `exp`<span data-ttu-id="a0993-241">:&nbsp;&nbsp;&nbsp;キーがキーの更新以外のどの処理も受け入れられなくなる有効期限を識別します。</span><span class="sxs-lookup"><span data-stu-id="a0993-241">:&nbsp;&nbsp;&nbsp;Identifies the expiration time on or after which the key will no longer be accepted for processing anything except for renewing keys.</span></span> <span data-ttu-id="a0993-242">この要求の値はエポック時間で表されます。</span><span class="sxs-lookup"><span data-stu-id="a0993-242">The value of this claim is expressed as epoch time.</span></span>
* `nbf`<span data-ttu-id="a0993-243">:&nbsp;&nbsp;&nbsp;トークンの処理が受け入れられる時刻を識別します。</span><span class="sxs-lookup"><span data-stu-id="a0993-243">:&nbsp;&nbsp;&nbsp;Identifies the time at which the token will be accepted for processing.</span></span> <span data-ttu-id="a0993-244">この要求の値はエポック時間で表されます。</span><span class="sxs-lookup"><span data-stu-id="a0993-244">The value of this claim is expressed as epoch time.</span></span>
* `http://schemas.microsoft.com/marketplace/2015/08/claims/key/clientId`<span data-ttu-id="a0993-245">:&nbsp;&nbsp;&nbsp;開発者を識別するクライアント ID。</span><span class="sxs-lookup"><span data-stu-id="a0993-245">:&nbsp;&nbsp;&nbsp;The client ID that identifies the developer.</span></span>
* `http://schemas.microsoft.com/marketplace/2015/08/claims/key/payload`<span data-ttu-id="a0993-246">:&nbsp;&nbsp;&nbsp;Microsoft Store サービスでのみ使用する情報が含まれている不透明なペイロード (暗号化され、Base64 でエンコード)。</span><span class="sxs-lookup"><span data-stu-id="a0993-246">:&nbsp;&nbsp;&nbsp;An opaque payload (encrypted and Base64 encoded) that contains information that is intended only for use by Microsoft Store services.</span></span>
* `http://schemas.microsoft.com/marketplace/2015/08/claims/key/userId`<span data-ttu-id="a0993-247">:&nbsp;&nbsp;&nbsp;サービスのコンテキストで現在のユーザーを識別するユーザー ID。</span><span class="sxs-lookup"><span data-stu-id="a0993-247">:&nbsp;&nbsp;&nbsp;A user ID that identifies the current user in the context of your services.</span></span> <span data-ttu-id="a0993-248">これは、[キーの作成に使うメソッド](#step-4)の省略可能な *publisherUserId* パラメーターに渡す値と同じです。</span><span class="sxs-lookup"><span data-stu-id="a0993-248">This is the same value you pass into the optional *publisherUserId* parameter of the [method you use to create the key](#step-4).</span></span>
* `http://schemas.microsoft.com/marketplace/2015/08/claims/key/refreshUri`<span data-ttu-id="a0993-249">:&nbsp;&nbsp;&nbsp;キーの更新に使用できる URI。</span><span class="sxs-lookup"><span data-stu-id="a0993-249">:&nbsp;&nbsp;&nbsp;The URI that you can use to renew the key.</span></span>

<span data-ttu-id="a0993-250">デコードされた Microsoft Store ID キー ヘッダーの例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="a0993-250">Here is an example of a decoded Microsoft Store ID key header.</span></span>

```json
{
    "typ":"JWT",
    "alg":"RS256",
    "x5t":"agA_pgJ7Twx_Ex2_rEeQ2o5fZ5g"
}
```

<span data-ttu-id="a0993-251">デコードされた Microsoft Store ID キー要求セットの例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="a0993-251">Here is an example of a decoded Microsoft Store ID key claim set.</span></span>

```json
{
    "http://schemas.microsoft.com/marketplace/2015/08/claims/key/clientId": "1d5773695a3b44928227393bfef1e13d",
    "http://schemas.microsoft.com/marketplace/2015/08/claims/key/payload": "ZdcOq0/N2rjytCRzCHSqnfczv3f0343wfSydx7hghfu0snWzMqyoAGy5DSJ5rMSsKoQFAccs1iNlwlGrX+/eIwh/VlUhLrncyP8c18mNAzAGK+lTAd2oiMQWRRAZxPwGrJrwiq2fTq5NOVDnQS9Za6/GdRjeiQrv6c0x+WNKxSQ7LV/uH1x+IEhYVtDu53GiXIwekltwaV6EkQGphYy7tbNsW2GqxgcoLLMUVOsQjI+FYBA3MdQpalV/aFN4UrJDkMWJBnmz3vrxBNGEApLWTS4Bd3cMswXsV9m+VhOEfnv+6PrL2jq8OZFoF3FUUpY8Fet2DfFr6xjZs3CBS1095J2yyNFWKBZxAXXNjn+zkvqqiVRjjkjNajhuaNKJk4MGHfk2rZiMy/aosyaEpCyncdisHVSx/S4JwIuxTnfnlY24vS0OXy7mFiZjjB8qL03cLsBXM4utCyXSIggb90GAx0+EFlVoJD7+ZKlm1M90xO/QSMDlrzFyuqcXXDBOnt7rPynPTrOZLVF+ODI5HhWEqArkVnc5MYnrZD06YEwClmTDkHQcxCvU+XUEvTbEk69qR2sfnuXV4cJRRWseUTfYoGyuxkQ2eWAAI1BXGxYECIaAnWF0W6ThweL5ZZDdadW9Ug5U3fZd4WxiDlB/EZ3aTy8kYXTW4Uo0adTkCmdLibw=",
    "http://schemas.microsoft.com/marketplace/2015/08/claims/key/userId": "infusQMLaYCrgtC0d/SZWoPB4FqLEwHXgZFuMJ6TuTY=",
    "http://schemas.microsoft.com/marketplace/2015/08/claims/key/refreshUri": "https://collections.mp.microsoft.com/v6.0/b2b/keys/renew",
    "iat": 1442395542,
    "iss": "https://collections.mp.microsoft.com/v6.0/keys",
    "aud": "https://collections.mp.microsoft.com/v6.0/keys",
    "exp": 1450171541,
    "nbf": 1442391941
}
```

## <a name="related-topics"></a><span data-ttu-id="a0993-252">関連トピック</span><span class="sxs-lookup"><span data-stu-id="a0993-252">Related topics</span></span>

* [<span data-ttu-id="a0993-253">製品の照会</span><span class="sxs-lookup"><span data-stu-id="a0993-253">Query for products</span></span>](query-for-products.md)
* [<span data-ttu-id="a0993-254">コンシューマブルな製品をフルフィルメント完了として報告する</span><span class="sxs-lookup"><span data-stu-id="a0993-254">Report consumable products as fulfilled</span></span>](report-consumable-products-as-fulfilled.md)
* [<span data-ttu-id="a0993-255">無料の製品の付与</span><span class="sxs-lookup"><span data-stu-id="a0993-255">Grant free products</span></span>](grant-free-products.md)
* [<span data-ttu-id="a0993-256">ユーザーのサブスクリプションを取得する</span><span class="sxs-lookup"><span data-stu-id="a0993-256">Get subscriptions for a user</span></span>](get-subscriptions-for-a-user.md)
* [<span data-ttu-id="a0993-257">ユーザーのサブスクリプションに関する請求の状態を変更する</span><span class="sxs-lookup"><span data-stu-id="a0993-257">Change the billing state of a subscription for a user</span></span>](change-the-billing-state-of-a-subscription-for-a-user.md)
* [<span data-ttu-id="a0993-258">Microsoft Store ID キーの更新</span><span class="sxs-lookup"><span data-stu-id="a0993-258">Renew a Microsoft Store ID key</span></span>](renew-a-windows-store-id-key.md)
* [<span data-ttu-id="a0993-259">Azure Active Directory とアプリケーションの統合</span><span class="sxs-lookup"><span data-stu-id="a0993-259">Integrating Applications with Azure Active Directory</span></span>](http://go.microsoft.com/fwlink/?LinkId=722502)
* [<span data-ttu-id="a0993-260">Azure Active Directory アプリケーション マニフェストの概要</span><span class="sxs-lookup"><span data-stu-id="a0993-260">Understanding the Azure Active Directory application manifest</span></span>]( http://go.microsoft.com/fwlink/?LinkId=722500)
* [<span data-ttu-id="a0993-261">サポートされているトークンと要求の種類</span><span class="sxs-lookup"><span data-stu-id="a0993-261">Supported Token and Claim Types</span></span>](http://go.microsoft.com/fwlink/?LinkId=722501)
