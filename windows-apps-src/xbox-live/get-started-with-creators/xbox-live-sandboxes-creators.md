---
title: Xbox Live のサンドボックス
author: PhillipLucas
description: Xbox Live のサンドボックスの概要
ms.assetid: e7daf845-e6cb-4561-9dfa-7cfba882f494
ms.author: kevinasg
ms.date: 10/30/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: bb11578fcc641c34b4337d90ee37d4084b16da55
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/02/2018
ms.locfileid: "5929536"
---
# <a name="xbox-live-sandboxes-introduction"></a><span data-ttu-id="95d57-104">Xbox Live のサンドボックスの概要</span><span class="sxs-lookup"><span data-stu-id="95d57-104">Xbox Live sandboxes introduction</span></span>

<span data-ttu-id="95d57-105">「[Xbox Live サービス構成](xbox-live-service-configuration-creators.md)」では、タイトルに関する情報は [Windows デベロッパー センター](http://dev.windows.com)で構成する必要があることを説明しました。</span><span class="sxs-lookup"><span data-stu-id="95d57-105">In the [Xbox Live service configuration](xbox-live-service-configuration-creators.md) article, it was explained that you must configure information about your title in [Windows Dev Center](http://dev.windows.com).</span></span> <span data-ttu-id="95d57-106">この情報には、統計、ランキング、ローカライズなどが含まれます。</span><span class="sxs-lookup"><span data-stu-id="95d57-106">This information includes things like the stats, leaderboards, localization, and more.</span></span> <span data-ttu-id="95d57-107">Xbox Live サービス構成への変更を Xbox Live の他の部分が取得し、タイトルからアクセスするには、その変更をデベロッパー センターから開発サンドボックスに公開する必要があります。</span><span class="sxs-lookup"><span data-stu-id="95d57-107">Changes to your Xbox Live service configuration need to be published from Dev Center into your development sandbox before the changes are picked up by the rest of Xbox Live and can be accessed in your title.</span></span>

<span data-ttu-id="95d57-108">開発サンドボックスでは、分離された環境でタイトルへの変更に取り組むことができます。</span><span class="sxs-lookup"><span data-stu-id="95d57-108">A development sandbox allows you to work on changes to your title in an isolated environment.</span></span> <span data-ttu-id="95d57-109">サンドボックスには、いくつかの利点があります。</span><span class="sxs-lookup"><span data-stu-id="95d57-109">Sandboxes offer several benefits:</span></span>

1. <span data-ttu-id="95d57-110">現在公開されているバージョンに影響を与えずに、タイトルの更新への変更を反復処理できます。</span><span class="sxs-lookup"><span data-stu-id="95d57-110">You can iterate on changes to an update for your title without affecting the version that is live in production.</span></span>
2. <span data-ttu-id="95d57-111">セキュリティ上の理由から、一部のツールは開発サンドボックス内でのみ動作します。</span><span class="sxs-lookup"><span data-stu-id="95d57-111">For security reasons, some tools only work in a development sandbox.</span></span>
3. <span data-ttu-id="95d57-112">他の公開元は、サンドボックスへのアクセス権が付与されない限り、その内部での作業内容を閲覧できません。</span><span class="sxs-lookup"><span data-stu-id="95d57-112">Other publishers cannot see what you are working on without being granted access to your sandbox.</span></span>

<span data-ttu-id="95d57-113">既定では、Xbox One 本体と Windows 10 PC は RETAIL サンドボックスになっています。</span><span class="sxs-lookup"><span data-stu-id="95d57-113">By default, Xbox One consoles and Windows 10 PCs are in the RETAIL sandbox.</span></span> <span data-ttu-id="95d57-114">Xbox Live サービス構成のバージョンにアクセスするには、PC や Xbox One を開発サンドボックスに切り替える必要があります。</span><span class="sxs-lookup"><span data-stu-id="95d57-114">You will need to switch your PC and/or Xbox One to the development sandbox to access that version of the Xbox Live service configuration.</span></span> <span data-ttu-id="95d57-115">RETAIL で何かをテストする必要がある場合や、休憩を取ってお気に入りの Xbox Live ゲームをプレイする場合は、デバイスを元の RETAIL サンドボックスに戻す必要がある点に注意してください。</span><span class="sxs-lookup"><span data-stu-id="95d57-115">It's important to remember to change the device back to the RETAIL sandbox if you need to test something in RETAIL or want to take a break to play your favorite Xbox Live game.</span></span>

## <a name="finding-out-about-your-sandbox"></a><span data-ttu-id="95d57-116">サンドボックスを調べる</span><span class="sxs-lookup"><span data-stu-id="95d57-116">Finding out about your sandbox</span></span>

<span data-ttu-id="95d57-117">サンドボックスは、タイトルの作成時に作られます。</span><span class="sxs-lookup"><span data-stu-id="95d57-117">A sandbox is created for you when you create a title.</span></span> <span data-ttu-id="95d57-118">サンド ボックス ID を検索するには、**Windows デベロッパー センター**で製品を開き、**[サービス]** > **[Xbox Live]** の順に選びます。</span><span class="sxs-lookup"><span data-stu-id="95d57-118">You can find your Sandbox ID by opening your product in **Windows Dev Center** and navigating to **Services** > **Xbox Live**.</span></span> <span data-ttu-id="95d57-119">ページの上部に**サンドボックス ID** が表示されます。</span><span class="sxs-lookup"><span data-stu-id="95d57-119">The **Sandbox ID** will be listed at the top of the page.</span></span>

![](../images/getting_started/devcenter_sandbox_id.png)

## <a name="switch-your-pcs-development-sandbox"></a><span data-ttu-id="95d57-120">PC の開発サンドボックスを切り替える</span><span class="sxs-lookup"><span data-stu-id="95d57-120">Switch your PC's development sandbox</span></span>
<span data-ttu-id="95d57-121">Unity、Windows デバイス ポータル (WPD)、またはコマンド ラインを使って、PC を開発サンドボックスに切り替えることができます。</span><span class="sxs-lookup"><span data-stu-id="95d57-121">You can switch your PC into the development sandbox by using Unity, Windows Device Portal (WPD) or via command-line.</span></span>

### <a name="unity"></a><span data-ttu-id="95d57-122">Unity</span><span class="sxs-lookup"><span data-stu-id="95d57-122">Unity</span></span>

#### <a name="prerequisites"></a><span data-ttu-id="95d57-123">前提条件</span><span class="sxs-lookup"><span data-stu-id="95d57-123">Prerequisites</span></span>
<span data-ttu-id="95d57-124">Unity で開発サンドボックスとの切り替えを行うには、以下の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="95d57-124">The following needs to be done before you can switch in and out of the development sandbox in Unity:</span></span>

1. [<span data-ttu-id="95d57-125">Unity で Xbox Live を構成する</span><span class="sxs-lookup"><span data-stu-id="95d57-125">Configure Xbox Live in Unity</span></span>](configure-xbox-live-in-unity.md)

#### <a name="switch-sandboxes"></a><span data-ttu-id="95d57-126">サンドボックスを切り替える</span><span class="sxs-lookup"><span data-stu-id="95d57-126">Switch Sandboxes</span></span>
<span data-ttu-id="95d57-127">組み込みの Xbox Live の構成ウィンドウを使うと、開発サンドボックスと RETAIL サンドボックスを簡単に切り替えることができます。</span><span class="sxs-lookup"><span data-stu-id="95d57-127">The built in Xbox Live Configuration window lets you toggle between your development and RETAIL sandboxes easily.</span></span> <span data-ttu-id="95d57-128">開始するには、メニューで **[Xbox Live]** > **[構成]** の順に移動します。</span><span class="sxs-lookup"><span data-stu-id="95d57-128">To start, go to **Xbox Live** > **Configuration** in the menu.</span></span> <span data-ttu-id="95d57-129">**[Developer Mode Configuration]** セクションに現在のサンドボックスが表示されます。</span><span class="sxs-lookup"><span data-stu-id="95d57-129">You can see the current sandbox in the **Developer Mode Configuration** section.</span></span>

1. <span data-ttu-id="95d57-130">**[Developer Mode]** に **[enabled]** と表示された場合、現在ゲームに関連付けられた開発サンドボックスになっています。</span><span class="sxs-lookup"><span data-stu-id="95d57-130">If **Developer Mode** says **enabled**, then you are currently in the development sandbox associated with your game.</span></span> <span data-ttu-id="95d57-131">**[Switch back to Retail Mode]** ボタンをクリックすると切り替えることができます。</span><span class="sxs-lookup"><span data-stu-id="95d57-131">You can click the **Switch back to Retail Mode** button to switch out.</span></span>
2. <span data-ttu-id="95d57-132">**[Developer Mode]** が **[disabled]** の場合、現在 RETAIL サンドボックスになっています。</span><span class="sxs-lookup"><span data-stu-id="95d57-132">If **Developer Mode** says **disabled**, then you are currently in the RETAIL sandbox.</span></span> <span data-ttu-id="95d57-133">**[Switch to Developer Mode]** ボタンをクリックすると再度切り替えることができます。</span><span class="sxs-lookup"><span data-stu-id="95d57-133">You can click the **Switch to Developer Mode** button to switch in.</span></span>

![XBL 有効](../images/unity/unity-xbl-dev-mode.PNG)

### <a name="windows-device-portal"></a><span data-ttu-id="95d57-135">Windows デバイス ポータル</span><span class="sxs-lookup"><span data-stu-id="95d57-135">Windows Device Portal</span></span>

#### <a name="prerequisites"></a><span data-ttu-id="95d57-136">前提条件</span><span class="sxs-lookup"><span data-stu-id="95d57-136">Prerequisites</span></span>
<span data-ttu-id="95d57-137">Windows デバイス ポータル (WPD) でサンドボックスに切り替える前に、次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="95d57-137">The following needs to be done before you switch your sandbox in Windows Device Portal (WPD):</span></span>

1. [<span data-ttu-id="95d57-138">Windows デスクトップでデバイス ポータルをセットアップする</span><span class="sxs-lookup"><span data-stu-id="95d57-138">Setup Device Portal on Windows Desktop</span></span>](https://msdn.microsoft.com/en-us/windows/uwp/debug-test-perf/device-portal-desktop)

#### <a name="switch-sandboxes"></a><span data-ttu-id="95d57-139">サンドボックスを切り替える</span><span class="sxs-lookup"><span data-stu-id="95d57-139">Switch Sandboxes</span></span>

1. <span data-ttu-id="95d57-140">「[Windows デスクトップでデバイス ポータルをセットアップする](https://msdn.microsoft.com/en-us/windows/uwp/debug-test-perf/device-portal-desktop)」で説明したように Web ブラウザーで **Windows デバイス ポータル**に接続してこのポータルを開きます。</span><span class="sxs-lookup"><span data-stu-id="95d57-140">Open **Windows Dev Portal** by connecting to it in your web browser, as described in the [Setup Device Portal on Windows Desktop](https://msdn.microsoft.com/en-us/windows/uwp/debug-test-perf/device-portal-desktop) article.</span></span>
2. <span data-ttu-id="95d57-141">**[Xbox Live]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="95d57-141">Click on **Xbox Live**.</span></span>
3. <span data-ttu-id="95d57-142">テキスト フィールドに開発サンドボックスを入力し、**[change]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="95d57-142">Enter your development sandbox in the text field and click **change**.</span></span>

![](../images/getting_started/wdp_switch_sandbox.png)

<span data-ttu-id="95d57-143">RETAIL に戻るには、ここで「RETAIL」と入力します。</span><span class="sxs-lookup"><span data-stu-id="95d57-143">To switch back to RETAIL, you can enter RETAIL here.</span></span>

### <a name="command-line"></a><span data-ttu-id="95d57-144">コマンド ライン</span><span class="sxs-lookup"><span data-stu-id="95d57-144">Command-line</span></span>

#### <a name="prerequisites"></a><span data-ttu-id="95d57-145">前提条件</span><span class="sxs-lookup"><span data-stu-id="95d57-145">Prerequisites</span></span>
<span data-ttu-id="95d57-146">コマンド ラインを使って開発サンドボックスとの切り替えを行うには、以下の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="95d57-146">The following needs to be done before you can switch in and out of the development sandbox via command-line:</span></span>

1. <span data-ttu-id="95d57-147">[https://aka.ms/xboxliveuwptools](https://aka.ms/xboxliveuwptools) で Xbox Live ツール パッケージをダウンロードし、解凍します。</span><span class="sxs-lookup"><span data-stu-id="95d57-147">Download the Xbox Live Tools Package at [https://aka.ms/xboxliveuwptools](https://aka.ms/xboxliveuwptools) and unzip.</span></span>

#### <a name="switch-sandboxes"></a><span data-ttu-id="95d57-148">サンドボックスを切り替える</span><span class="sxs-lookup"><span data-stu-id="95d57-148">Switch Sandboxes</span></span>
1. <span data-ttu-id="95d57-149">**管理者モード**で SwitchSandbox.cmd バッチ ファイルを実行します。</span><span class="sxs-lookup"><span data-stu-id="95d57-149">Run SwitchSandbox.cmd batch file in **administrator mode**.</span></span>

<span data-ttu-id="95d57-150">サンドボックスを切り替えるには、管理者モードでこのバッチ ファイルを実行します。</span><span class="sxs-lookup"><span data-stu-id="95d57-150">Run this in Administrator mode to switch your sandbox.</span></span> <span data-ttu-id="95d57-151">最初の引数がサンドボックスです。</span><span class="sxs-lookup"><span data-stu-id="95d57-151">The first argument is the sandbox.</span></span> <span data-ttu-id="95d57-152">たとえば、MJJSQH.58 サンドボックスに切り替える場合は、このコマンドを実行します。</span><span class="sxs-lookup"><span data-stu-id="95d57-152">For example, if you are trying to switch to the MJJSQH.58 sandbox, you would use this command:</span></span>

```cmd
SwitchSandbox.cmd MJJSQH.58
```

<span data-ttu-id="95d57-153">RETAIL に戻るには、2 番目の引数として RETAIL を指定するだけです。</span><span class="sxs-lookup"><span data-stu-id="95d57-153">To switch back to RETAIL, you simply provide that as the second argument.</span></span>

```cmd
SwitchSandbox.cmd RETAIL
```

## <a name="switch-your-xbox-one-console-development-sandbox"></a><span data-ttu-id="95d57-154">Xbox One 本体の開発サンドボックスを切り替える</span><span class="sxs-lookup"><span data-stu-id="95d57-154">Switch your Xbox One console development sandbox</span></span>

### <a name="using-xbox-dev-portal"></a><span data-ttu-id="95d57-155">Xbox デベロッパー ポータルの使用</span><span class="sxs-lookup"><span data-stu-id="95d57-155">Using Xbox Dev Portal</span></span>

<span data-ttu-id="95d57-156">Xbox デベロッパー ポータルを使用して、本体でサンドボックスを変更できます。</span><span class="sxs-lookup"><span data-stu-id="95d57-156">You can use the Xbox Dev Portal to change the sandbox on your console.</span></span> <span data-ttu-id="95d57-157">これを行うには、使用している本体で [[Dev Home]](https://docs.microsoft.com/windows/uwp/xbox-apps/dev-home) に移動して[デバイス ポータルを有効](https://docs.microsoft.com/windows/uwp/debug-test-perf/device-portal-xbox)にします。</span><span class="sxs-lookup"><span data-stu-id="95d57-157">To do this, go to [Dev Home](https://docs.microsoft.com/windows/uwp/xbox-apps/dev-home) on your console and [enable the Device Portal](https://docs.microsoft.com/windows/uwp/debug-test-perf/device-portal-xbox).</span></span> <span data-ttu-id="95d57-158">Xbox デベロッパー ポータルを開いたら、次のようにします。</span><span class="sxs-lookup"><span data-stu-id="95d57-158">Once you have the Xbox Dev Portal open:</span></span>

2. <span data-ttu-id="95d57-159">**[Xbox Live]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="95d57-159">Click on **Xbox Live**.</span></span>
3. <span data-ttu-id="95d57-160">テキスト フィールドに開発サンドボックスを入力し、**[change]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="95d57-160">Enter your development sandbox in the text field and chick **change**.</span></span>

![](../images/getting_started/xdp_switch_sandbox.png)

### <a name="using-xbox-one-console-ui"></a><span data-ttu-id="95d57-161">Xbox One 本体の UI の使用</span><span class="sxs-lookup"><span data-stu-id="95d57-161">Using Xbox One console UI</span></span>

<span data-ttu-id="95d57-162">[Dev Home](https://docs.microsoft.com/windows/uwp/xbox-apps/dev-home) を使用して、本体で直接サンドボックスを変更できます。</span><span class="sxs-lookup"><span data-stu-id="95d57-162">You can use [Dev Home](https://docs.microsoft.com/windows/uwp/xbox-apps/dev-home) to change the sandbox on your console directly:</span></span>

1. <span data-ttu-id="95d57-163">**[クイックアクション]** にある **[サンドボックスの変更]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="95d57-163">Click **Change Sandbox**, located under **Quick Actions**.</span></span>
2. <span data-ttu-id="95d57-164">サンドボックス ID を入力し、**[保存すて再起動]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="95d57-164">Enter the sandbox ID and then click **Save and restart**.</span></span>

### <a name="sign-in-with-the-xbox-app"></a><span data-ttu-id="95d57-165">Xbox アプリでのサインイン</span><span class="sxs-lookup"><span data-stu-id="95d57-165">Sign-In with the Xbox App</span></span>

<span data-ttu-id="95d57-166">開発用に、サインインしている Xbox Live に、テスト対象アカウントを使用することを確認することが、タイトルの適切なサンド ボックスを使用して PC を切り替えることです。</span><span class="sxs-lookup"><span data-stu-id="95d57-166">Once you've switched your development PC to use the proper sandbox for your title you'll want to verify that you're signed in to Xbox Live with an eligible test account.</span></span> <span data-ttu-id="95d57-167">これは、 [Xbox Live のアプリ](https://www.xbox.com/en-US/xbox-app)に署名することで実行できます。</span><span class="sxs-lookup"><span data-stu-id="95d57-167">This can be done by signing into the [Xbox Live App](https://www.xbox.com/en-US/xbox-app).</span></span> <span data-ttu-id="95d57-168">開発環境が起動すると、目的のサンド ボックスの Xbox アプリを使用するが、その他の Xbox Live として同じ制約を使用してサインイン ユーザー サービスのサンド ボックス内で実行されています。</span><span class="sxs-lookup"><span data-stu-id="95d57-168">Once your development environment starts using the desired sandbox the Xbox App will sign-in users using the same constraints as any other Xbox Live service running on the sandbox.</span></span> <span data-ttu-id="95d57-169">これにより、サンド ボックスの有効なアカウントを使用していることを確認すると便利です。</span><span class="sxs-lookup"><span data-stu-id="95d57-169">This makes it useful to verify that you are using a valid account for the sandbox.</span></span>
