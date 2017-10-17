---
title: Create and test a new Creators title
author: KevinAsgari
description: Learn how to create a new Xbox Live Creators Program title and publish to the test environment.
ms.assetid: ced4d708-e8c0-4b69-aad0-e953bfdacbbf
ms.author: kevinasg
ms.date: 04-04-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: xbox live, xbox, games, uwp, windows 10, xbox one, creators, test
ms.openlocfilehash: 0ba9b34ed229b9c7f59ef78711126980540059d7
ms.sourcegitcommit: b185729f0bb73569740d03be67dff9f59a4c4968
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/01/2017
---
# <a name="create-a-new-xbox-live-creators-program-title-and-publish-to-the-test-environment"></a><span data-ttu-id="8dd53-104">Create a new Xbox Live Creators Program title and publish to the test environment</span><span class="sxs-lookup"><span data-stu-id="8dd53-104">Create a new Xbox Live Creators Program title and publish to the test environment</span></span>

## <a name="introduction"></a><span data-ttu-id="8dd53-105">Introduction</span><span class="sxs-lookup"><span data-stu-id="8dd53-105">Introduction</span></span>

<span data-ttu-id="8dd53-106">Before writing any code, you must setup a new title on your service configuration portal.</span><span class="sxs-lookup"><span data-stu-id="8dd53-106">Before writing any code, you must setup a new title on your service configuration portal.</span></span>  <span data-ttu-id="8dd53-107">You can learn more about service configuration in [Xbox Live Service Configuration](../xbox-live-service-configuration.md)</span><span class="sxs-lookup"><span data-stu-id="8dd53-107">You can learn more about service configuration in [Xbox Live Service Configuration](../xbox-live-service-configuration.md)</span></span>

<span data-ttu-id="8dd53-108">この記事では、Windows デベロッパー センターでのタイトルの構成、新しいプロジェクトの作成、テストに向けた Xbox Live の準備に必要なすべての手順を説明します。</span><span class="sxs-lookup"><span data-stu-id="8dd53-108">This article will walk through everything required to get a title configured on Windows Dev Center, a new project created, and preparing Xbox Live for testing.</span></span> <span data-ttu-id="8dd53-109">この記事では、以下を前提としています。</span><span class="sxs-lookup"><span data-stu-id="8dd53-109">This article assumes the following:</span></span>

1. <span data-ttu-id="8dd53-110">Xbox Live クリエーターズ プログラムを使用している。</span><span class="sxs-lookup"><span data-stu-id="8dd53-110">You are using the Xbox Live Creators Program.</span></span>
2. <span data-ttu-id="8dd53-111">You are developing a Universal Windows Platform (UWP) title.</span><span class="sxs-lookup"><span data-stu-id="8dd53-111">You are developing a Universal Windows Platform (UWP) title.</span></span>  <span data-ttu-id="8dd53-112">UWP titles can run on Xbox One, Windows 10 desktop PCs, and mobile</span><span class="sxs-lookup"><span data-stu-id="8dd53-112">UWP titles can run on Xbox One, Windows 10 desktop PCs, and mobile</span></span>
3. <span data-ttu-id="8dd53-113">You are configuring your title on Windows Dev Center at [http://dev.windows.com/](http://dev.windows.com).</span><span class="sxs-lookup"><span data-stu-id="8dd53-113">You are configuring your title on Windows Dev Center at [http://dev.windows.com/](http://dev.windows.com).</span></span>  <span data-ttu-id="8dd53-114">If in doubt, you should use Windows Dev Center.</span><span class="sxs-lookup"><span data-stu-id="8dd53-114">If in doubt, you should use Windows Dev Center.</span></span>
4. <span data-ttu-id="8dd53-115">開発用コンピュータが Windows 10 を実行している。</span><span class="sxs-lookup"><span data-stu-id="8dd53-115">Your development machine is running Windows 10.</span></span>

> [!NOTE]
> <span data-ttu-id="8dd53-116">Xbox Live クリエーターズ プログラムに参加している場合は、上記の前提条件が適用されますので、この記事に従ってください。</span><span class="sxs-lookup"><span data-stu-id="8dd53-116">If you are part of the Xbox Live Creators Program, the above assumptions apply to you and you should follow along with this article</span></span>

## <a name="dev-center-setup"></a><span data-ttu-id="8dd53-117">Dev Center setup</span><span class="sxs-lookup"><span data-stu-id="8dd53-117">Dev Center setup</span></span>

<span data-ttu-id="8dd53-118">You need an Xbox Live enabled title created on [Windows Dev Center](http://dev.windows.com) as a pre-requisite to any Xbox Live functionality working.</span><span class="sxs-lookup"><span data-stu-id="8dd53-118">You need an Xbox Live enabled title created on [Windows Dev Center](http://dev.windows.com) as a pre-requisite to any Xbox Live functionality working.</span></span>

### <a name="create-a-microsoft-account"></a><span data-ttu-id="8dd53-119">Create a Microsoft account</span><span class="sxs-lookup"><span data-stu-id="8dd53-119">Create a Microsoft account</span></span>
<span data-ttu-id="8dd53-120">Microsoft アカウント (MSA とも呼ばれます) をお持ちでない場合は、最初に [Microsoft アカウントのサインイン ページ](https://go.microsoft.com/fwlink/p/?LinkID=254486)でアカウントを作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8dd53-120">If you don't have a Microsoft Account (also known as an MSA), you will need to first create one at [Microsoft Account - Sign In](https://go.microsoft.com/fwlink/p/?LinkID=254486).</span></span> <span data-ttu-id="8dd53-121">If you have an Office 365 account, use Outlook.com, or have an Xbox Live account - you probably already have an MSA.</span><span class="sxs-lookup"><span data-stu-id="8dd53-121">If you have an Office 365 account, use Outlook.com, or have an Xbox Live account - you probably already have an MSA.</span></span>

### <a name="register-as-an-app-developer"></a><span data-ttu-id="8dd53-122">Register as an App Developer</span><span class="sxs-lookup"><span data-stu-id="8dd53-122">Register as an App Developer</span></span>
<span data-ttu-id="8dd53-123">デベロッパー センターで新しいタイトルを作成できるようにするには、アプリ開発者として登録する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8dd53-123">You will need to register as an App Developer before you can create a new title on Dev Center.</span></span>

<span data-ttu-id="8dd53-124">登録するには、[アプリ開発者として登録](https://developer.microsoft.com/store/register)し、サインアップ プロセスに従ってください。</span><span class="sxs-lookup"><span data-stu-id="8dd53-124">To register, go to [Register as an app developer](https://developer.microsoft.com/store/register) and follow the sign-up process.</span></span>

### <a name="create-a-new-uwp-title"></a><span data-ttu-id="8dd53-125">Create a new UWP title</span><span class="sxs-lookup"><span data-stu-id="8dd53-125">Create a new UWP title</span></span>
<span data-ttu-id="8dd53-126">デベロッパー センターで UWP タイトルを定義する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8dd53-126">You will need a UWP title defined on Dev Center.</span></span> <span data-ttu-id="8dd53-127">これを実行するには、まず [Windows デベロッパー センター ダッシュボード](https://developer.microsoft.com/dashboard/)に移動します。</span><span class="sxs-lookup"><span data-stu-id="8dd53-127">You do that by first going to the [Windows Dev Center Dashboard](https://developer.microsoft.com/dashboard/).</span></span>

<span data-ttu-id="8dd53-128">次に、新しいタイトルを作成します。</span><span class="sxs-lookup"><span data-stu-id="8dd53-128">Next, create a new title.</span></span> <span data-ttu-id="8dd53-129">You'll need to reserve a name.</span><span class="sxs-lookup"><span data-stu-id="8dd53-129">You'll need to reserve a name.</span></span>

![](../images/getting_started/first_xbltitle_newapp.png)

<span data-ttu-id="8dd53-130">次のスクリーンショットは、Xbox Live を構成するための主要なページを開く **[サービス]** >  **[Xbox Live]** メニューを示しています。</span><span class="sxs-lookup"><span data-stu-id="8dd53-130">The screenshot shows the primary page where you'll be configuring Xbox Live, located under the **Services** > **Xbox Live** menu.</span></span>

![](../images/creators_udc/creators_udc_xboxlive_page.png)

## <a name="enable-xbox-live-services"></a><span data-ttu-id="8dd53-131">Xbox Live サービスを有効にする</span><span class="sxs-lookup"><span data-stu-id="8dd53-131">Enable Xbox Live services</span></span>
<span data-ttu-id="8dd53-132">製品に対して **[サービス]** の下にある **[Xbox Live]** リンクを初めてクリックすると、[Enable Xbox Live Creators Program] (Xbox Live クリエーターズ プログラムの有効化) ページが表示されます。</span><span class="sxs-lookup"><span data-stu-id="8dd53-132">When you click the **Xbox Live** link under **Services** for the first time for a product, you will be taken to the Enable Xbox Live Creators Program page.</span></span>  <span data-ttu-id="8dd53-133">次に、**[有効化]** ボタンをクリックして、Xbox Live のセットアップ ダイアログを表示します。</span><span class="sxs-lookup"><span data-stu-id="8dd53-133">Next, click the **Enable** button to bring up the Xbox Live setup dialog.</span></span>

![](../images/creators_udc/creators_udc_xboxlive_enable.png)

<span data-ttu-id="8dd53-134">セットアップ ダイアログで、Xbox Live サービスを有効にするプラットフォームを選択します (既定では Xbox One と Windows 10 PC の両方が選択されています)。</span><span class="sxs-lookup"><span data-stu-id="8dd53-134">On the setup dialog, select the platforms that you would like to enable the Xbox Live Services for (both Xbox One and Windows 10 PC are selected by default).</span></span>  <span data-ttu-id="8dd53-135">**[確認]** ボタンをクリックして、ゲーム用に Xbox Live クリエーターズ プログラムを有効にします。</span><span class="sxs-lookup"><span data-stu-id="8dd53-135">Click the **Confirm** button to enable Xbox Live Creators Program for your game.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="8dd53-136">Xbox Live は、ゲームに対してのみサポートされます。</span><span class="sxs-lookup"><span data-stu-id="8dd53-136">Xbox Live is only supported for games.</span></span> <span data-ttu-id="8dd53-137">ゲームを Xbox Live で正常に公開するためには、申請のプロパティ セクションで、製品の種類を "ゲーム" に設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8dd53-137">In order to successfully publish your game with Xbox Live, you must set your product type to "Game" in the properties section of the submission.</span></span>

![](../images/creators_udc/creators_udc_xboxlive_enable_dialog.png)

## <a name="test-xbox-live-service-configuration-in-your-game"></a><span data-ttu-id="8dd53-138">ゲームで Xbox Live サービス構成をテストする</span><span class="sxs-lookup"><span data-stu-id="8dd53-138">Test Xbox Live service configuration in your game</span></span>
<span data-ttu-id="8dd53-139">When you make changes to the Xbox Live configuration for your game, you need to publish the changes to a specific environment before they are picked up by the rest of Xbox Live and can be seen by your game.</span><span class="sxs-lookup"><span data-stu-id="8dd53-139">When you make changes to the Xbox Live configuration for your game, you need to publish the changes to a specific environment before they are picked up by the rest of Xbox Live and can be seen by your game.</span></span>

<span data-ttu-id="8dd53-140">When you are still working on your game, you publish to your own development sandbox.</span><span class="sxs-lookup"><span data-stu-id="8dd53-140">When you are still working on your game, you publish to your own development sandbox.</span></span>  <span data-ttu-id="8dd53-141">開発サンドボックスでは、分離された環境でゲームへの変更に取り組むことができます。</span><span class="sxs-lookup"><span data-stu-id="8dd53-141">The development sandbox allows you to work on changes to your game in an isolated environment.</span></span>

<span data-ttu-id="8dd53-142">ゲームを一般向けにリリースすると、Xbox Live 構成は自動的に RETAIL サンドボックスに公開されます。</span><span class="sxs-lookup"><span data-stu-id="8dd53-142">When your game is released to the public, the Xbox Live configuration will automatically be published to the RETAIL sandbox.</span></span>

<span data-ttu-id="8dd53-143">既定では、Xbox One 本体と Windows 10 PC は RETAIL サンドボックスになっています。</span><span class="sxs-lookup"><span data-stu-id="8dd53-143">By default, Xbox One Consoles and Windows 10 PCs are in the RETAIL sandbox.</span></span>

### <a name="authorize-devices-and-users-for-the-development-sandbox"></a><span data-ttu-id="8dd53-144">Authorize devices and users for the development sandbox</span><span class="sxs-lookup"><span data-stu-id="8dd53-144">Authorize devices and users for the development sandbox</span></span>

<span data-ttu-id="8dd53-145">Only authorized devices and users can access the Xbox Live configuration for the game in your development sandbox.</span><span class="sxs-lookup"><span data-stu-id="8dd53-145">Only authorized devices and users can access the Xbox Live configuration for the game in your development sandbox.</span></span>

<span data-ttu-id="8dd53-146">既定では、デベロッパー センター アカウントに追加したすべての Xbox One 開発機本体が開発サンドボックスにアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="8dd53-146">By default, all the Xbox One development consoles you have added to your Dev Center account have access to your development sandbox.</span></span>  <span data-ttu-id="8dd53-147">Xbox One 本体を追加するには、[Xbox One 本体の管理のページ](https://developer.microsoft.com/XboxDevices)に移動します。</span><span class="sxs-lookup"><span data-stu-id="8dd53-147">To add an Xbox One console, go to [Manage Xbox One consoles](https://developer.microsoft.com/XboxDevices).</span></span> <span data-ttu-id="8dd53-148">既にデベロッパー センター アカウントにサインインしている場合は、**[アカウント設定]** > **[アカウント設定]** > **[Dev devices] (開発デバイス)** > **[Xbox One development consoles] (Xbox One 開発機本体)** の順に移動できます。</span><span class="sxs-lookup"><span data-stu-id="8dd53-148">If you’re already in your Dev Center account, you can go to **Account Settings** > **Account Settings** > **Dev devices** > **Xbox One development consoles**.</span></span>

<span data-ttu-id="8dd53-149">通常の Xbox Live アカウントに開発サンドボックスへのアクセスを承認することもできます。</span><span class="sxs-lookup"><span data-stu-id="8dd53-149">You can also authorize normal Xbox Live accounts to have access to your development sandbox.</span></span>  <span data-ttu-id="8dd53-150">Xbox Live アカウントに開発サンドボックスへのアクセスを承認するには、[アカウントの管理のページ](https://developer.microsoft.com/xboxtestaccounts/configurecreators)に移動します。</span><span class="sxs-lookup"><span data-stu-id="8dd53-150">To authorize Xbox Live accounts access to your development sandbox, go to [Manage Accounts](https://developer.microsoft.com/xboxtestaccounts/configurecreators).</span></span>

### <a name="publish-xbox-live-configuration-to-the-test-environment"></a><span data-ttu-id="8dd53-151">Xbox Live 構成をテスト環境に公開する</span><span class="sxs-lookup"><span data-stu-id="8dd53-151">Publish Xbox Live Configuration to the test environment</span></span>

<span data-ttu-id="8dd53-152">Whenever you enable Xbox Live services and make changes to Xbox Live service configuration, to make the changes effective, you need to publish these changes to your development sandbox.</span><span class="sxs-lookup"><span data-stu-id="8dd53-152">Whenever you enable Xbox Live services and make changes to Xbox Live service configuration, to make the changes effective, you need to publish these changes to your development sandbox.</span></span>

<span data-ttu-id="8dd53-153">現在の Xbox Live 構成を開発サンドボックスに公開するには、Xbox Live 構成ページで **[テスト]** ボタンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="8dd53-153">On the Xbox Live configuration page, click the **Test** button to publish the current Xbox Live configuration to your development sandbox.</span></span>

![](../images/creators_udc/creators_udc_xboxlive_config_test.png)

## <a name="next-steps"></a><span data-ttu-id="8dd53-154">次の手順</span><span class="sxs-lookup"><span data-stu-id="8dd53-154">Next steps</span></span>
<span data-ttu-id="8dd53-155">Now that you have a new title created, you can now setup an Xbox Live enabled title in your Game Engine, Visual Studio or build environment of choice.</span><span class="sxs-lookup"><span data-stu-id="8dd53-155">Now that you have a new title created, you can now setup an Xbox Live enabled title in your Game Engine, Visual Studio or build environment of choice.</span></span>

<span data-ttu-id="8dd53-156">See [Step by step guide to integrate Xbox Live](creators-step-by-step-guide.md)</span><span class="sxs-lookup"><span data-stu-id="8dd53-156">See [Step by step guide to integrate Xbox Live](creators-step-by-step-guide.md)</span></span>
