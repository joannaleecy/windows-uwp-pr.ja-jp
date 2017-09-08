---
title: "新しいクリエーターズ タイトルを作成し、テストする"
author: KevinAsgari
description: "新しい Xbox Live クリエーターズ プログラム向けのタイトルを作成し、テスト環境に公開する方法について説明します。"
ms.assetid: ced4d708-e8c0-4b69-aad0-e953bfdacbbf
ms.author: kevinasg
ms.date: 04-04-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, クリエーター, テスト"
ms.openlocfilehash: 4b8fbba80d2151fef62c91d91c2e6cdb60d06710
ms.sourcegitcommit: 90fbdc0e25e0dff40c571d6687143dd7e16ab8a8
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/06/2017
---
# <a name="create-a-new-xbox-live-creators-program-title-and-publish-to-the-test-environment"></a><span data-ttu-id="f4bc1-104">新しい Xbox Live クリエーターズ プログラム向けのタイトルを作成し、テスト環境に公開する</span><span class="sxs-lookup"><span data-stu-id="f4bc1-104">Create a new Xbox Live Creators Program title and publish to the test environment</span></span>

## <a name="introduction"></a><span data-ttu-id="f4bc1-105">はじめに</span><span class="sxs-lookup"><span data-stu-id="f4bc1-105">Introduction</span></span>

<span data-ttu-id="f4bc1-106">コードを記述する前に、サービス構成ポータルで、新しいタイトルをセットアップする必要があります。</span><span class="sxs-lookup"><span data-stu-id="f4bc1-106">Before writing any code, you must setup a new title on your service configuration portal.</span></span>  <span data-ttu-id="f4bc1-107">サービス構成について詳しくは、「[Xbox Live サービス構成](../xbox-live-service-configuration.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f4bc1-107">You can learn more about service configuration in [Xbox Live Service Configuration](../xbox-live-service-configuration.md)</span></span>

<span data-ttu-id="f4bc1-108">この記事では、新しいタイトルをセットアップする手順について説明します。前提条件は以下のとおりです。</span><span class="sxs-lookup"><span data-stu-id="f4bc1-108">This article will walk you through this process with the following assumptions</span></span>

1. <span data-ttu-id="f4bc1-109">Xbox Live クリエーターズ プログラムを使用している。</span><span class="sxs-lookup"><span data-stu-id="f4bc1-109">You are using the Xbox Live Creators Program.</span></span>
2. <span data-ttu-id="f4bc1-110">ユニバーサル Windows プラットフォーム (UWP) のタイトルを開発している。</span><span class="sxs-lookup"><span data-stu-id="f4bc1-110">You are developing a Universal Windows Platform (UWP) title.</span></span>  <span data-ttu-id="f4bc1-111">UWPのタイトルは、Xbox One、Windows 10 デスクトップ PC、およびモバイルで実行できるタイトルです。</span><span class="sxs-lookup"><span data-stu-id="f4bc1-111">UWP titles can run on Xbox One, Windows 10 desktop PCs, and mobile</span></span>
3. <span data-ttu-id="f4bc1-112">タイトルを、[http://dev.windows.com/](http://dev.windows.com) の Windows デベロッパー センターで構成している。</span><span class="sxs-lookup"><span data-stu-id="f4bc1-112">You are configuring your title on Windows Dev Center at [http://dev.windows.com/](http://dev.windows.com).</span></span>  <span data-ttu-id="f4bc1-113">判断がつかない場合は、Windows デベロッパー センターをご利用ください。</span><span class="sxs-lookup"><span data-stu-id="f4bc1-113">If in doubt, you should use Windows Dev Center.</span></span>
4. <span data-ttu-id="f4bc1-114">開発用コンピュータは Windows 10 を実行している。</span><span class="sxs-lookup"><span data-stu-id="f4bc1-114">Your development machine is running Windows 10.</span></span>

<span data-ttu-id="f4bc1-115">上記の前提条件を満たしていることを想定し、この記事の残りの部分で、Windows デベロッパー センターでのタイトルの構成、新しいプロジェクトの作成、Xbox Live サインイン コードの記述とテストに必要なすべての手順を説明します。</span><span class="sxs-lookup"><span data-stu-id="f4bc1-115">Provided that the above are true, the remainder of this article will walk through everything required to get a title configured on Windows Dev Center, a new project created, and Xbox Live sign-in code written and tested.</span></span>

> <span data-ttu-id="f4bc1-116">**注**: Xbox Live クリエーターズ プログラムに参加している場合は、上記の前提条件が適用されますので、この記事に従ってください。</span><span class="sxs-lookup"><span data-stu-id="f4bc1-116">**Note**: If you are part of the Xbox Live Creators Program, the above assumptions apply to you and you should follow along with this article</span></span>

## <a name="dev-center-setup"></a><span data-ttu-id="f4bc1-117">デベロッパー センターのセットアップ</span><span class="sxs-lookup"><span data-stu-id="f4bc1-117">Dev Center setup</span></span>

<span data-ttu-id="f4bc1-118">Xbox Live の機能が動作するための前提条件として、[Windows デベロッパー センター](http://dev.windows.com)で作成した Xbox Live 対応のタイトルが必要です。</span><span class="sxs-lookup"><span data-stu-id="f4bc1-118">You need an Xbox Live enabled title created on [Windows Dev Center](http://dev.windows.com) as a pre-requisite to any Xbox Live functionality working.</span></span>

### <a name="create-a-microsoft-account"></a><span data-ttu-id="f4bc1-119">Microsoft アカウントを作成する</span><span class="sxs-lookup"><span data-stu-id="f4bc1-119">Create a Microsoft account</span></span>
<span data-ttu-id="f4bc1-120">Microsoft アカウント (MSA とも呼ばれます) をお持ちでない場合は、最初に [https://go.microsoft.com/fwlink/p/?LinkID=254486](https://go.microsoft.com/fwlink/p/?LinkID=254486) でアカウントを作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f4bc1-120">If you don't have a Microsoft Account (also known as an MSA), you will need to first create one at [https://go.microsoft.com/fwlink/p/?LinkID=254486](https://go.microsoft.com/fwlink/p/?LinkID=254486).</span></span>  <span data-ttu-id="f4bc1-121">Office 365 アカウントをお持ちの場合は、Outlook.com を使用してください。または Xbox Live アカウントをお持ちの場合は、既に MSA を持っている可能性があります。</span><span class="sxs-lookup"><span data-stu-id="f4bc1-121">If you have an Office 365 account, use Outlook.com, or have an Xbox Live account - you probably already have an MSA.</span></span>

### <a name="register-as-an-app-developer"></a><span data-ttu-id="f4bc1-122">アプリ開発者として登録する</span><span class="sxs-lookup"><span data-stu-id="f4bc1-122">Register as an App Developer</span></span>
<span data-ttu-id="f4bc1-123">デベロッパー センターで新しいタイトルを作成できるようにするには、アプリ開発者として登録する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f4bc1-123">You will need to register as an App Developer before you are allowed to create a new title on Dev Center.</span></span>

<span data-ttu-id="f4bc1-124">登録するには、[https://developer.microsoft.com/ja-jp/store/register](https://developer.microsoft.com/en-us/store/register) にアクセスし、サインアップ プロセスに従ってください。</span><span class="sxs-lookup"><span data-stu-id="f4bc1-124">To register go to [https://developer.microsoft.com/en-us/store/register](https://developer.microsoft.com/en-us/store/register) and follow the sign-up process.</span></span>

### <a name="create-a-new-uwp-title"></a><span data-ttu-id="f4bc1-125">新しい UWP タイトルを作成する</span><span class="sxs-lookup"><span data-stu-id="f4bc1-125">Create a new UWP title</span></span>
<span data-ttu-id="f4bc1-126">次に、デベロッパー センターで定義されている UWP タイトルが必要です。</span><span class="sxs-lookup"><span data-stu-id="f4bc1-126">Next, you need a UWP title defined on Dev Center.</span></span>  <span data-ttu-id="f4bc1-127">これを実行するには、まずダッシュ ボードに移動します</span><span class="sxs-lookup"><span data-stu-id="f4bc1-127">You do that by first going to the Dashboard</span></span>

![](../images/getting_started/first_xbltitle_dashboard.png)

<p>
</p>
<br>
<p>
</p>

<span data-ttu-id="f4bc1-128">ダッシュ ボードをクリックしてから、新しいタイトルを作成します。</span><span class="sxs-lookup"><span data-stu-id="f4bc1-128">After clicking on the dashboard, create a new title.</span></span>  <span data-ttu-id="f4bc1-129">名前を予約する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f4bc1-129">You'll need to reserve a name.</span></span>

![](../images/getting_started/first_xbltitle_newapp.png)

<span data-ttu-id="f4bc1-130">次に、アプリに関する *[アプリの概要]* ページが表示されます。</span><span class="sxs-lookup"><span data-stu-id="f4bc1-130">You'll then be taken to the *App Overview* page for your app.</span></span>  <span data-ttu-id="f4bc1-131">Xbox Live を構成するための主要なページは、以下に示すように [サービス] -> [Xbox Live] メニューにあります。</span><span class="sxs-lookup"><span data-stu-id="f4bc1-131">The primary page where you'll be configuring Xbox Live is under the Services -> Xbox Live menu shown below.</span></span>

![](../images/getting_started/first_xbltitle_leftnav.png)

## <a name="enable-xbox-live-services"></a><span data-ttu-id="f4bc1-132">Xbox Live サービスを有効にする</span><span class="sxs-lookup"><span data-stu-id="f4bc1-132">Enable Xbox Live services</span></span>
<span data-ttu-id="f4bc1-133">アプリの [サービス] の下にある [Xbox Live] リンクを初めてクリックすると、[Enable Xbox Live Creators Program] (Xbox Live クリエーターズ プログラムの有効化) ページが表示されます。</span><span class="sxs-lookup"><span data-stu-id="f4bc1-133">When you click the "Xbox Live" link under "Services" first time for an app, you will be taken to the "Enable Xbox Live Creators Program" page.</span></span>  <span data-ttu-id="f4bc1-134">[有効化] ボタンをクリックすると、[有効化] ダイアログが表示されます。</span><span class="sxs-lookup"><span data-stu-id="f4bc1-134">Click the "Enable" button to bring up the "Enable" dialog.</span></span>

![](../images/creators_udc/creators_udc_xboxlive_enable_page.png)

<span data-ttu-id="f4bc1-135">[有効化] ダイアログで、Xbox Live サービスを有効にするプラットフォームを選択します (Xbox One と Windows 10 PC の両方が既定で選択されています)。</span><span class="sxs-lookup"><span data-stu-id="f4bc1-135">On the "Enable" dialog, select the platforms of which you would like to enable Xbox Live Services (both Xbox One and Windows 10 PC are selected by default).</span></span>  <span data-ttu-id="f4bc1-136">[確認] ボタンをクリックして、ゲーム用に Xbox Live クリエーターズ プログラムを有効にします。</span><span class="sxs-lookup"><span data-stu-id="f4bc1-136">Click the "Confirm" button to enable Xbox Live Creators Program for your game.</span></span>

![](../images/creators_udc/creators_udc_xboxlive_enable_dialog.png)

## <a name="test-xbox-live-service-configuration-in-your-game"></a><span data-ttu-id="f4bc1-137">ゲームで Xbox Live サービス構成をテストする</span><span class="sxs-lookup"><span data-stu-id="f4bc1-137">Test Xbox Live service configuration in your game</span></span>
<span data-ttu-id="f4bc1-138">ゲーム用の Xbox Live 構成に変更を加える場合、それらの変更が Xbox Live の残りの部分によって取得されてゲームで表示されるようにするには、変更を特定の環境に公開する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f4bc1-138">When you make changes to the Xbox Live configuration for your game, you need to publish the changes to a specific environment before they are picked up by the rest of Xbox Live and can be seen by your game.</span></span>

<span data-ttu-id="f4bc1-139">ゲームに対する作業を継続している間は、独自の開発サンドボックスに公開します。</span><span class="sxs-lookup"><span data-stu-id="f4bc1-139">When you are still working on your game, you publish to your own development sandbox.</span></span>  <span data-ttu-id="f4bc1-140">開発サンドボックスでは、分離された環境でゲームへの変更に取り組むことができます。</span><span class="sxs-lookup"><span data-stu-id="f4bc1-140">The development sandbox allows you to work on changes to your game in an isolated environment.</span></span>

<span data-ttu-id="f4bc1-141">ゲームを一般向けにリリースする場合は、Xbox Live 構成を RETAIL サンドボックスに公開します。</span><span class="sxs-lookup"><span data-stu-id="f4bc1-141">When your game is released to the public, the Xbox Live configuration will be published to the RETAIL sandbox.</span></span>

<span data-ttu-id="f4bc1-142">既定では、Xbox One 本体と Windows 10 PC は RETAIL サンドボックスに格納されます。</span><span class="sxs-lookup"><span data-stu-id="f4bc1-142">By default, Xbox One Consoles and Windows 10 PCs are in the RETAIL sandbox.</span></span>

### <a name="authorize-devices-and-users-for-the-development-sandbox"></a><span data-ttu-id="f4bc1-143">開発サンドボックス用にデバイスとユーザーを承認する</span><span class="sxs-lookup"><span data-stu-id="f4bc1-143">Authorize devices and users for the development sandbox</span></span>

<span data-ttu-id="f4bc1-144">開発サンドボックス内のゲームの Xbox Live 構成には、承認済みのデバイスとユーザーのみがアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="f4bc1-144">Only authorized devices and users can access the Xbox Live configuration for the game in your development sandbox.</span></span>

<span data-ttu-id="f4bc1-145">既定では、デベロッパー センター アカウントに追加したすべての Xbox One 開発機本体が開発サンドボックスにアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="f4bc1-145">By default, all the Xbox One development consoles you have added to your Dev Center account have access to your development sandbox.</span></span>  <span data-ttu-id="f4bc1-146">Xbox One 本体を追加するには、[https://developer.microsoft.com/ja-jp/XboxDevices](https://developer.microsoft.com/en-us/XboxDevices) にアクセスしてください。</span><span class="sxs-lookup"><span data-stu-id="f4bc1-146">To add an Xbox One console, please go to: [https://developer.microsoft.com/en-us/XboxDevices](https://developer.microsoft.com/en-us/XboxDevices)</span></span>

<span data-ttu-id="f4bc1-147">通常の Xbox Live アカウントに開発サンドボックスへのアクセスを承認することもできます。</span><span class="sxs-lookup"><span data-stu-id="f4bc1-147">You can also authorize normal Xbox Live accounts access to your development sandbox.</span></span>  <span data-ttu-id="f4bc1-148">Xbox Live アカウントに開発サンドボックスへのアクセスを承認するには、[https://developer.microsoft.com/ja-jp/xboxtestaccounts/configurecreators](https://developer.microsoft.com/en-us/xboxtestaccounts/configurecreators) にアクセスしてください。</span><span class="sxs-lookup"><span data-stu-id="f4bc1-148">To authorize Xbox Live accounts access to your development sandbox, please go to: [https://developer.microsoft.com/en-us/xboxtestaccounts/configurecreators](https://developer.microsoft.com/en-us/xboxtestaccounts/configurecreators)</span></span>

![](../images/creators_udc/creators_udc_testing_with_retail_accounts.png)

### <a name="publish-xbox-live-configuration-to-the-test-environment"></a><span data-ttu-id="f4bc1-149">Xbox Live 構成をテスト環境に公開する</span><span class="sxs-lookup"><span data-stu-id="f4bc1-149">Publish Xbox Live Configuration to the test environment</span></span>

<span data-ttu-id="f4bc1-150">Xbox Live サービスを有効にした後で Xbox Live サービス構成に変更を加えた場合は必ず、変更を有効にするために、これらの変更を開発サンドボックスに公開する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f4bc1-150">Whenever you enable Xbox Live services and make changes to Xbox Live service configuration, to make the changes effective, you need to publish these changes to your development sandbox.</span></span>

<span data-ttu-id="f4bc1-151">Xbox Live 構成ページで、[テスト] ボタンをクリックして、現在の Xbox Live 構成を開発サンドボックスに公開します。</span><span class="sxs-lookup"><span data-stu-id="f4bc1-151">On the Xbox Live configuration page, click the "Test" button to publish the current Xbox Live configuration to your development sandbox.</span></span>

![](../images/creators_udc/creators_udc_xboxlive_config_test.png)

## <a name="next-steps"></a><span data-ttu-id="f4bc1-152">次の手順</span><span class="sxs-lookup"><span data-stu-id="f4bc1-152">Next steps</span></span>
<span data-ttu-id="f4bc1-153">これで新しいタイトルが作成されたので、次はゲーム エンジン、Visual Studio、任意のビルド環境で Xbox Live 対応のタイトルをセットアップできます。</span><span class="sxs-lookup"><span data-stu-id="f4bc1-153">Now that you have a new title created, you can now setup an Xbox Live enabled title in your Game Engine, Visual Studio or build environment of choice.</span></span>

<span data-ttu-id="f4bc1-154">「[Xbox Live を統合するためのステップ バイ ステップ ガイド](creators-step-by-step-guide.md)」をご覧ください</span><span class="sxs-lookup"><span data-stu-id="f4bc1-154">See [Step by step guide to integrate Xbox Live](creators-step-by-step-guide.md)</span></span>
