---
title: 新しいクリエーターズ タイトルを作成し、テストする
author: KevinAsgari
description: 新しい Xbox Live クリエーターズ プログラム向けのタイトルを作成し、テスト環境に公開する方法について説明します。
ms.assetid: ced4d708-e8c0-4b69-aad0-e953bfdacbbf
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, クリエーター, テスト
ms.localizationpriority: medium
ms.openlocfilehash: 822ce0a3c4e0e0475b4dd01e405ccc9b90799654
ms.sourcegitcommit: 93c0a60cf531c7d9fe7b00e7cf78df86906f9d6e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/23/2018
ms.locfileid: "7568269"
---
# <a name="create-a-new-xbox-live-creators-program-title-and-publish-to-the-test-environment"></a><span data-ttu-id="58740-104">新しい Xbox Live クリエーターズ プログラム向けのタイトルを作成し、テスト環境に公開する</span><span class="sxs-lookup"><span data-stu-id="58740-104">Create a new Xbox Live Creators Program title and publish to the test environment</span></span>

## <a name="introduction"></a><span data-ttu-id="58740-105">はじめに</span><span class="sxs-lookup"><span data-stu-id="58740-105">Introduction</span></span>

<span data-ttu-id="58740-106">Xbox Live コードを記述する前に、サービス構成ポータルで、新しいタイトルをセットアップする必要があります。</span><span class="sxs-lookup"><span data-stu-id="58740-106">Before writing any Xbox Live code, you must setup a new title on your service configuration portal.</span></span>  <span data-ttu-id="58740-107">サービス構成について詳しくは、「[Xbox Live サービス構成](../xbox-live-service-configuration.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="58740-107">You can learn more about service configuration in [Xbox Live Service Configuration](../xbox-live-service-configuration.md).</span></span>

<span data-ttu-id="58740-108">この記事では、[パートナー センター](https://partner.microsoft.com/dashboard)で構成されているタイトル、新しいプロジェクトの作成、および Xbox Live テストの準備に必要なすべての手順について説明します。</span><span class="sxs-lookup"><span data-stu-id="58740-108">This article will walk through everything required to get a title configured in [Partner Center](https://partner.microsoft.com/dashboard), a new project created, and preparing Xbox Live for testing.</span></span> <span data-ttu-id="58740-109">この記事では、以下を前提としています。</span><span class="sxs-lookup"><span data-stu-id="58740-109">This article assumes the following:</span></span>

1. <span data-ttu-id="58740-110">Xbox Live クリエーターズ プログラムを使用している。</span><span class="sxs-lookup"><span data-stu-id="58740-110">You are using the Xbox Live Creators Program.</span></span>
2. <span data-ttu-id="58740-111">ユニバーサル Windows プラットフォーム (UWP) のタイトルを開発している。</span><span class="sxs-lookup"><span data-stu-id="58740-111">You are developing a Universal Windows Platform (UWP) title.</span></span>  <span data-ttu-id="58740-112">UWPのタイトルは、Xbox One、Windows 10 デスクトップ PC、およびモバイルで実行できるタイトルです。</span><span class="sxs-lookup"><span data-stu-id="58740-112">UWP titles can run on Xbox One, Windows 10 desktop PCs, and mobile</span></span>
3. <span data-ttu-id="58740-113">[パートナー センター](https://partner.microsoft.com/dashboard)でタイトルを構成します。</span><span class="sxs-lookup"><span data-stu-id="58740-113">You are configuring your title in [Partner Center](https://partner.microsoft.com/dashboard).</span></span>
4. <span data-ttu-id="58740-114">開発用コンピュータが Windows 10 を実行している。</span><span class="sxs-lookup"><span data-stu-id="58740-114">Your development machine is running Windows 10.</span></span>

> [!NOTE]
> <span data-ttu-id="58740-115">Xbox Live クリエーターズ プログラムに参加している場合は、上記の前提条件が適用されますので、この記事に従ってください。</span><span class="sxs-lookup"><span data-stu-id="58740-115">If you are part of the Xbox Live Creators Program, the above assumptions apply to you and you should follow along with this article</span></span>

## <a name="partner-center-setup"></a><span data-ttu-id="58740-116">パートナー センターのセットアップ</span><span class="sxs-lookup"><span data-stu-id="58740-116">Partner Center setup</span></span>

<span data-ttu-id="58740-117">Xbox Live 対応のタイトルの Xbox Live の機能を使うための前提として、[パートナー センター](https://partner.microsoft.com/dashboard)で作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="58740-117">You need an Xbox Live enabled title created in [Partner Center](https://partner.microsoft.com/dashboard) as a pre-requisite to using any Xbox Live functionality.</span></span>

### <a name="create-a-microsoft-account"></a><span data-ttu-id="58740-118">Microsoft アカウントを作成する</span><span class="sxs-lookup"><span data-stu-id="58740-118">Create a Microsoft account</span></span>
<span data-ttu-id="58740-119">Microsoft アカウント (MSA とも呼ばれます) をお持ちでない場合は、最初に [Microsoft アカウントのサインイン ページ](https://go.microsoft.com/fwlink/p/?LinkID=254486)でアカウントを作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="58740-119">If you don't have a Microsoft Account (also known as an MSA), you will need to first create one at [Microsoft Account - Sign In](https://go.microsoft.com/fwlink/p/?LinkID=254486).</span></span> <span data-ttu-id="58740-120">Office 365 アカウントをお持ちの場合は、Outlook.com を使用してください。または Xbox Live アカウントをお持ちの場合は、既に MSA を持っている可能性があります。</span><span class="sxs-lookup"><span data-stu-id="58740-120">If you have an Office 365 account, use Outlook.com, or have an Xbox Live account - you probably already have an MSA.</span></span>

### <a name="register-as-an-app-developer"></a><span data-ttu-id="58740-121">アプリ開発者として登録する</span><span class="sxs-lookup"><span data-stu-id="58740-121">Register as an App Developer</span></span>
<span data-ttu-id="58740-122">パートナー センターで新しいタイトルを作成する前に、アプリ開発者として登録する必要があります。</span><span class="sxs-lookup"><span data-stu-id="58740-122">You will need to register as an App Developer before you can create a new title in Partner Center.</span></span>

<span data-ttu-id="58740-123">登録するには、[アプリ開発者として登録](https://developer.microsoft.com/store/register)し、サインアップ プロセスに従ってください。</span><span class="sxs-lookup"><span data-stu-id="58740-123">To register, go to [Register as an app developer](https://developer.microsoft.com/store/register) and follow the sign-up process.</span></span>

### <a name="create-a-new-uwp-title"></a><span data-ttu-id="58740-124">新しい UWP タイトルを作成する</span><span class="sxs-lookup"><span data-stu-id="58740-124">Create a new UWP title</span></span>
<span data-ttu-id="58740-125">UWP タイトルがパートナー センターで定義されている必要があります。</span><span class="sxs-lookup"><span data-stu-id="58740-125">You will need a UWP title defined in Partner Center.</span></span> <span data-ttu-id="58740-126">によって行います経由[のパートナー センター](https://partner.microsoft.com/dashboard)にします。</span><span class="sxs-lookup"><span data-stu-id="58740-126">You do that by first going to [Partner Center](https://partner.microsoft.com/dashboard).</span></span>

<span data-ttu-id="58740-127">次に、新しいタイトルを作成します。</span><span class="sxs-lookup"><span data-stu-id="58740-127">Next, create a new title.</span></span> <span data-ttu-id="58740-128">名前を予約する必要があります。</span><span class="sxs-lookup"><span data-stu-id="58740-128">You'll need to reserve a name.</span></span>

![](../images/getting_started/first_xbltitle_newapp.png)

<span data-ttu-id="58740-129">次のスクリーンショットは、Xbox Live を構成するための主要なページを開く **[サービス]** >  **[Xbox Live]** メニューを示しています。</span><span class="sxs-lookup"><span data-stu-id="58740-129">The screenshot shows the primary page where you'll be configuring Xbox Live, located under the **Services** > **Xbox Live** menu.</span></span>

![](../images/creators_udc/creators_udc_xboxlive_page.png)

## <a name="enable-xbox-live-services"></a><span data-ttu-id="58740-130">Xbox Live サービスを有効にする</span><span class="sxs-lookup"><span data-stu-id="58740-130">Enable Xbox Live services</span></span>
<span data-ttu-id="58740-131">製品に対して **[サービス]** の下にある **[Xbox Live]** リンクを初めてクリックすると、[Enable Xbox Live Creators Program] (Xbox Live クリエーターズ プログラムの有効化) ページが表示されます。</span><span class="sxs-lookup"><span data-stu-id="58740-131">When you click the **Xbox Live** link under **Services** for the first time for a product, you will be taken to the Enable Xbox Live Creators Program page.</span></span>  <span data-ttu-id="58740-132">次に、**[有効化]** ボタンをクリックして、Xbox Live のセットアップ ダイアログを表示します。</span><span class="sxs-lookup"><span data-stu-id="58740-132">Next, click the **Enable** button to bring up the Xbox Live setup dialog.</span></span>

![](../images/creators_udc/creators_udc_xboxlive_enable.png)

<span data-ttu-id="58740-133">セットアップ ダイアログで、Xbox Live サービスを有効にするプラットフォームを選択します (既定では Xbox One と Windows 10 PC の両方が選択されています)。</span><span class="sxs-lookup"><span data-stu-id="58740-133">On the setup dialog, select the platforms that you would like to enable the Xbox Live Services for (both Xbox One and Windows 10 PC are selected by default).</span></span>  <span data-ttu-id="58740-134">**[確認]** ボタンをクリックして、ゲーム用に Xbox Live クリエーターズ プログラムを有効にします。</span><span class="sxs-lookup"><span data-stu-id="58740-134">Click the **Confirm** button to enable Xbox Live Creators Program for your game.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="58740-135">Xbox Live は、ゲームに対してのみサポートされます。</span><span class="sxs-lookup"><span data-stu-id="58740-135">Xbox Live is only supported for games.</span></span> <span data-ttu-id="58740-136">ゲームを Xbox Live で正常に公開するためには、申請のプロパティ セクションで、製品の種類を "ゲーム" に設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="58740-136">In order to successfully publish your game with Xbox Live, you must set your product type to "Game" in the properties section of the submission.</span></span>

![](../images/creators_udc/creators_udc_xboxlive_enable_dialog.png)

## <a name="test-xbox-live-service-configuration-in-your-game"></a><span data-ttu-id="58740-137">ゲームで Xbox Live サービス構成をテストする</span><span class="sxs-lookup"><span data-stu-id="58740-137">Test Xbox Live service configuration in your game</span></span>
<span data-ttu-id="58740-138">ゲーム用の Xbox Live 構成に変更を加える場合、それらの変更が Xbox Live の残りの部分によって取得されてゲームで表示されるようにするには、変更を特定の環境に公開する必要があります。</span><span class="sxs-lookup"><span data-stu-id="58740-138">When you make changes to the Xbox Live configuration for your game, you need to publish the changes to a specific environment before they are picked up by the rest of Xbox Live and can be seen by your game.</span></span>

<span data-ttu-id="58740-139">ゲームに対する作業を継続している間は、独自の開発サンドボックスに公開します。</span><span class="sxs-lookup"><span data-stu-id="58740-139">When you are still working on your game, you publish to your own development sandbox.</span></span>  <span data-ttu-id="58740-140">開発サンドボックスでは、分離された環境でゲームへの変更に取り組むことができます。</span><span class="sxs-lookup"><span data-stu-id="58740-140">The development sandbox allows you to work on changes to your game in an isolated environment.</span></span>

<span data-ttu-id="58740-141">ゲームを一般向けにリリースすると、Xbox Live 構成は自動的に RETAIL サンドボックスに公開されます。</span><span class="sxs-lookup"><span data-stu-id="58740-141">When your game is released to the public, the Xbox Live configuration will automatically be published to the RETAIL sandbox.</span></span>

<span data-ttu-id="58740-142">既定では、Xbox One 本体と Windows 10 PC は RETAIL サンドボックスになっています。</span><span class="sxs-lookup"><span data-stu-id="58740-142">By default, Xbox One Consoles and Windows 10 PCs are in the RETAIL sandbox.</span></span>

### <a name="publish-xbox-live-configuration-to-the-test-environment"></a><span data-ttu-id="58740-143">Xbox Live 構成をテスト環境に公開する</span><span class="sxs-lookup"><span data-stu-id="58740-143">Publish Xbox Live Configuration to the test environment</span></span>

<span data-ttu-id="58740-144">Xbox Live サービスを有効にした後で Xbox Live サービス構成に変更を加えた場合は必ず、変更を有効にするために、これらの変更を開発サンドボックスに公開する必要があります。</span><span class="sxs-lookup"><span data-stu-id="58740-144">Whenever you enable Xbox Live services and make changes to Xbox Live service configuration, to make the changes effective, you need to publish these changes to your development sandbox.</span></span>

<span data-ttu-id="58740-145">現在の Xbox Live 構成を開発サンドボックスに公開するには、Xbox Live 構成ページで **[テスト]** ボタンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="58740-145">On the Xbox Live configuration page, click the **Test** button to publish the current Xbox Live configuration to your development sandbox.</span></span>

![](../images/creators_udc/creators_udc_xboxlive_config_test.png)

### <a name="authorize-devices-and-users-for-the-development-sandbox"></a><span data-ttu-id="58740-146">開発サンドボックス用にデバイスとユーザーを承認する</span><span class="sxs-lookup"><span data-stu-id="58740-146">Authorize devices and users for the development sandbox</span></span>

<span data-ttu-id="58740-147">開発サンドボックス内のゲームの Xbox Live 構成には、承認済みのデバイスとユーザーのみがアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="58740-147">Only authorized devices and users can access the Xbox Live configuration for the game in your development sandbox.</span></span>

<span data-ttu-id="58740-148">既定では、パートナー センター アカウントに追加したすべての Xbox One 開発コンソールは開発サンド ボックスへのアクセスがあります。</span><span class="sxs-lookup"><span data-stu-id="58740-148">By default, all the Xbox One development consoles you have added to your Partner Center account have access to your development sandbox.</span></span>  <span data-ttu-id="58740-149">Xbox One 本体を追加するには、[Xbox One 本体の管理のページ](https://partner.microsoft.com/XboxDevices)に移動します。</span><span class="sxs-lookup"><span data-stu-id="58740-149">To add an Xbox One console, go to [Manage Xbox One consoles](https://partner.microsoft.com/XboxDevices).</span></span> <span data-ttu-id="58740-150">既にパートナー センター アカウントになっている場合は、**アカウントの設定**に移動できます > **アカウント設定** > **デベロッパー デバイス** > **Xbox One 開発機本体**です。</span><span class="sxs-lookup"><span data-stu-id="58740-150">If you’re already in your Partner Center account, you can go to **Account Settings** > **Account Settings** > **Dev devices** > **Xbox One development consoles**.</span></span>

<span data-ttu-id="58740-151">通常の Xbox Live アカウントに開発サンドボックスへのアクセスを承認することもできます。</span><span class="sxs-lookup"><span data-stu-id="58740-151">You can also authorize normal Xbox Live accounts to have access to your development sandbox.</span></span>  <span data-ttu-id="58740-152">Xbox Live アカウントに開発サンドボックスへのアクセスを承認するには、[アカウントの管理のページ](https://developer.microsoft.com/xboxtestaccounts/configurecreators)に移動します。</span><span class="sxs-lookup"><span data-stu-id="58740-152">To authorize Xbox Live accounts access to your development sandbox, go to [Manage Accounts](https://developer.microsoft.com/xboxtestaccounts/configurecreators).</span></span>

## <a name="next-steps"></a><span data-ttu-id="58740-153">次の手順</span><span class="sxs-lookup"><span data-stu-id="58740-153">Next steps</span></span>
<span data-ttu-id="58740-154">これで新しいタイトルが作成されたので、次はゲーム エンジン、Visual Studio、任意のビルド環境で Xbox Live 対応のタイトルをセットアップできます。</span><span class="sxs-lookup"><span data-stu-id="58740-154">Now that you have a new title created, you can now setup an Xbox Live enabled title in your Game Engine, Visual Studio or build environment of choice.</span></span>

<span data-ttu-id="58740-155">「[Xbox Live を統合するためのステップ バイ ステップ ガイド](creators-step-by-step-guide.md)」をご覧ください</span><span class="sxs-lookup"><span data-stu-id="58740-155">See [Step by step guide to integrate Xbox Live](creators-step-by-step-guide.md)</span></span>
