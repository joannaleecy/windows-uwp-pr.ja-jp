---
author: PatrickFarley
ms.assetid: 60fc48dd-91a9-4dd6-a116-9292a7c1f3be
title: "Windows Device Portal の概要"
description: "Windows Device Portal で、ネットワーク経由でリモートから、または USB 接続によって、デバイスの構成と管理を行うための方法を説明します。"
ms.author: pafarley
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: f22600f2bbd5dc43996550c853c6defd04565ad4
ms.sourcegitcommit: e8cc657d85566768a6efb7cd972ebf64c25e0628
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 06/26/2017
---
# <a name="windows-device-portal-overview"></a><span data-ttu-id="00610-104">Windows Device Portal の概要</span><span class="sxs-lookup"><span data-stu-id="00610-104">Windows Device Portal overview</span></span>

<span data-ttu-id="00610-105">Windows Device Portal では、ネットワーク経由でリモートから、または USB 接続によって、デバイスの構成と管理を行えます。</span><span class="sxs-lookup"><span data-stu-id="00610-105">The Windows Device Portal lets you configure and manage your device remotely over a network or USB connection.</span></span> <span data-ttu-id="00610-106">また、Windows デバイスのトラブルシューティングを行ったり、リアルタイムのパフォーマンスを表示するための高度な診断ツールも用意されています。</span><span class="sxs-lookup"><span data-stu-id="00610-106">It also provides advanced diagnostic tools to help you troubleshoot and view the real time performance of your Windows device.</span></span>

<span data-ttu-id="00610-107">デバイス ポータルは、お使いの PC に Web ブラウザーから接続することができるデバイス上の Web サーバーです。</span><span class="sxs-lookup"><span data-stu-id="00610-107">The Device Portal is a web server on your device that you can connect to from a web browser on your PC.</span></span> <span data-ttu-id="00610-108">デバイスに Web ブラウザーがある場合、デバイスのブラウザーにローカル接続することもできます。</span><span class="sxs-lookup"><span data-stu-id="00610-108">If your device has a web browser, you can also connect locally with the browser on your device.</span></span>

<span data-ttu-id="00610-109">各デバイス ファミリで Windows Device Portal を利用できますが、機能とセットアップはデバイスの要件によって異なります。</span><span class="sxs-lookup"><span data-stu-id="00610-109">Windows Device Portal is available on each device family, but features and setup vary based on the device's requirements.</span></span> <span data-ttu-id="00610-110">ここでは、Device Portal の一般的な説明と、各デバイス ファミリに関するさらに詳細な情報が掲載されている記事へのリンクを示します。</span><span class="sxs-lookup"><span data-stu-id="00610-110">This article provides a general description of Device Portal and links to articles with more specific information for each device family.</span></span>

<span data-ttu-id="00610-111">Windows Device Portal のすべての機能は [REST API](device-portal-api-core.md) の上に構築されます。REST API を使用してデータにアクセスしたり、プログラムを使ってデバイスを制御することができます。</span><span class="sxs-lookup"><span data-stu-id="00610-111">Everything in the Windows Device Portal is built on top of [REST API's](device-portal-api-core.md) that you can use to access the data and control your device programmatically.</span></span>

## <a name="setup"></a><span data-ttu-id="00610-112">セットアップ</span><span class="sxs-lookup"><span data-stu-id="00610-112">Setup</span></span>

<span data-ttu-id="00610-113">Device Portal への接続の具体的な手順はデバイスによって異なりますが、どのデバイスでも次の一般的な手順が必要です。</span><span class="sxs-lookup"><span data-stu-id="00610-113">Each device has specific instructions for connecting to Device Portal, but each requires these general steps:</span></span>
1. <span data-ttu-id="00610-114">デバイスで開発者モードと Device Portal を有効にします。</span><span class="sxs-lookup"><span data-stu-id="00610-114">Enable Developer Mode and Device Portal on your device.</span></span>
2. <span data-ttu-id="00610-115">デバイスと PC をローカル ネットワークまたは USB 経由で接続します。</span><span class="sxs-lookup"><span data-stu-id="00610-115">Connect your device and PC via local network or USB.</span></span>
3. <span data-ttu-id="00610-116">ブラウザーでデバイス ポータルのページに移動します。</span><span class="sxs-lookup"><span data-stu-id="00610-116">Navigate to the Device Portal page in your browser.</span></span> <span data-ttu-id="00610-117">次の表は、各デバイス ファミリで使用されるポートとプロトコルを示しています。</span><span class="sxs-lookup"><span data-stu-id="00610-117">This table shows the ports and protcols used by each device family.</span></span>

<span data-ttu-id="00610-118">デバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="00610-118">Device family</span></span> | <span data-ttu-id="00610-119">既定でオンになっているか</span><span class="sxs-lookup"><span data-stu-id="00610-119">On by default?</span></span> | <span data-ttu-id="00610-120">HTTP</span><span class="sxs-lookup"><span data-stu-id="00610-120">HTTP</span></span> | <span data-ttu-id="00610-121">HTTPS</span><span class="sxs-lookup"><span data-stu-id="00610-121">HTTPS</span></span> | <span data-ttu-id="00610-122">USB</span><span class="sxs-lookup"><span data-stu-id="00610-122">USB</span></span>
--------------|----------------|------|-------|----
<span data-ttu-id="00610-123">HoloLens</span><span class="sxs-lookup"><span data-stu-id="00610-123">HoloLens</span></span> | <span data-ttu-id="00610-124">開発者モードでオン</span><span class="sxs-lookup"><span data-stu-id="00610-124">Yes, in Dev Mode</span></span> | <span data-ttu-id="00610-125">80 (既定)</span><span class="sxs-lookup"><span data-stu-id="00610-125">80 (default)</span></span> | <span data-ttu-id="00610-126">443 (既定)</span><span class="sxs-lookup"><span data-stu-id="00610-126">443 (default)</span></span> | <span data-ttu-id="00610-127">http://127.0.0.1:10080</span><span class="sxs-lookup"><span data-stu-id="00610-127">http://127.0.0.1:10080</span></span>
<span data-ttu-id="00610-128">IoT</span><span class="sxs-lookup"><span data-stu-id="00610-128">IoT</span></span> | <span data-ttu-id="00610-129">開発者モードでオン</span><span class="sxs-lookup"><span data-stu-id="00610-129">Yes, in Dev Mode</span></span> | <span data-ttu-id="00610-130">8080</span><span class="sxs-lookup"><span data-stu-id="00610-130">8080</span></span> | <span data-ttu-id="00610-131">レジストリ キーで有効化する</span><span class="sxs-lookup"><span data-stu-id="00610-131">Enable via regkey</span></span> | <span data-ttu-id="00610-132">なし</span><span class="sxs-lookup"><span data-stu-id="00610-132">N/A</span></span>
<span data-ttu-id="00610-133">Xbox</span><span class="sxs-lookup"><span data-stu-id="00610-133">Xbox</span></span> | <span data-ttu-id="00610-134">開発者モードで有効化する</span><span class="sxs-lookup"><span data-stu-id="00610-134">Enable inside Dev Mode</span></span> | <span data-ttu-id="00610-135">無効</span><span class="sxs-lookup"><span data-stu-id="00610-135">Disabled</span></span> | <span data-ttu-id="00610-136">11443</span><span class="sxs-lookup"><span data-stu-id="00610-136">11443</span></span> | <span data-ttu-id="00610-137">なし</span><span class="sxs-lookup"><span data-stu-id="00610-137">N/A</span></span>
<span data-ttu-id="00610-138">Desktop</span><span class="sxs-lookup"><span data-stu-id="00610-138">Desktop</span></span>| <span data-ttu-id="00610-139">開発者モードで有効化する</span><span class="sxs-lookup"><span data-stu-id="00610-139">Enable inside Dev Mode</span></span> | <span data-ttu-id="00610-140">50080\*</span><span class="sxs-lookup"><span data-stu-id="00610-140">50080\*</span></span> | <span data-ttu-id="00610-141">50043\*</span><span class="sxs-lookup"><span data-stu-id="00610-141">50043\*</span></span> | <span data-ttu-id="00610-142">なし</span><span class="sxs-lookup"><span data-stu-id="00610-142">N/A</span></span>
<span data-ttu-id="00610-143">Phone</span><span class="sxs-lookup"><span data-stu-id="00610-143">Phone</span></span> | <span data-ttu-id="00610-144">開発者モードで有効化する</span><span class="sxs-lookup"><span data-stu-id="00610-144">Enable inside Dev Mode</span></span> | <span data-ttu-id="00610-145">80</span><span class="sxs-lookup"><span data-stu-id="00610-145">80</span></span>| <span data-ttu-id="00610-146">443</span><span class="sxs-lookup"><span data-stu-id="00610-146">443</span></span> | <span data-ttu-id="00610-147">http://127.0.0.1:10080</span><span class="sxs-lookup"><span data-stu-id="00610-147">http://127.0.0.1:10080</span></span>

<span data-ttu-id="00610-148">\* デスクトップ上の Device Portal が、デバイス上の既存のポート要求との競合を避ける目的で ephemeral ポートの範囲 (>50,000) にあるポートを要求するため、この表が当てはまらない場合があります。</span><span class="sxs-lookup"><span data-stu-id="00610-148">\* This is not always the case, as Device Portal on desktop claims ports in the ephemeral range (>50,000) to prevent collisions with existing port claims on the device.</span></span>  <span data-ttu-id="00610-149">詳しくは、デスクトップに関する「[ポート番号を設定する](device-portal-desktop.md#setting-port-numbers)」のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="00610-149">To learn more, see the [Port Settings](device-portal-desktop.md#setting-port-numbers) section for desktop.</span></span>  

<span data-ttu-id="00610-150">デバイス固有のセットアップ手順については、以下をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="00610-150">For device-specific setup instructions, see:</span></span>
- [<span data-ttu-id="00610-151">HoloLens 用 Device Portal</span><span class="sxs-lookup"><span data-stu-id="00610-151">Device Portal for HoloLens</span></span>](https://docs.microsoft.com/en-us/windows/uwp/debug-test-perf/device-portal-hololens)
- [<span data-ttu-id="00610-152">IoT 用 Device Portal</span><span class="sxs-lookup"><span data-stu-id="00610-152">Device Portal for IoT</span></span>](https://go.microsoft.com/fwlink/?LinkID=616499)
- [<span data-ttu-id="00610-153">モバイル用 Device Portal</span><span class="sxs-lookup"><span data-stu-id="00610-153">Device Portal for Mobile</span></span>](device-portal-mobile.md)
- [<span data-ttu-id="00610-154">Xbox 用 Device Portal</span><span class="sxs-lookup"><span data-stu-id="00610-154">Device Portal for Xbox</span></span>](device-portal-xbox.md)
- [<span data-ttu-id="00610-155">デスクトップ用 Device Portal</span><span class="sxs-lookup"><span data-stu-id="00610-155">Device Portal for Desktop</span></span>](device-portal-desktop.md#set-up-device-portal-on-windows-desktop)

## <a name="features"></a><span data-ttu-id="00610-156">機能</span><span class="sxs-lookup"><span data-stu-id="00610-156">Features</span></span>

### <a name="toolbar-and-navigation"></a><span data-ttu-id="00610-157">ツールバーとナビゲーション</span><span class="sxs-lookup"><span data-stu-id="00610-157">Toolbar and navigation</span></span>

<span data-ttu-id="00610-158">ページの最上部にあるツール バーでは、よく使われる状態や機能にアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="00610-158">The toolbar at the top of the page provides access to commonly used status and features.</span></span>
- <span data-ttu-id="00610-159">**[Shutdown]** (シャットダウン): デバイスをオフにします。</span><span class="sxs-lookup"><span data-stu-id="00610-159">**Shutdown**: Turns off the device.</span></span>
- <span data-ttu-id="00610-160">**[Restart]** (再起動): デバイスの電源を入れ直します。</span><span class="sxs-lookup"><span data-stu-id="00610-160">**Restart**: Cycles power on the device.</span></span>
- <span data-ttu-id="00610-161">**[Help]** (ヘルプ): ヘルプ ページを開きます。</span><span class="sxs-lookup"><span data-stu-id="00610-161">**Help**: Opens the help page.</span></span>

<span data-ttu-id="00610-162">ページの左側にあるナビゲーション ウィンドウのリンクを使用して、デバイスの管理と監視に利用可能なツールに移動します。</span><span class="sxs-lookup"><span data-stu-id="00610-162">Use the links in the navigation pane along the left side of the page to navigate to the available management and monitoring tools for your device.</span></span>

<span data-ttu-id="00610-163">ここでは、すべてのデバイスに共通のツールについて説明します。</span><span class="sxs-lookup"><span data-stu-id="00610-163">Tools that are common across devices are described here.</span></span> <span data-ttu-id="00610-164">デバイスによってはその他のオプションを利用できる場合があります。</span><span class="sxs-lookup"><span data-stu-id="00610-164">Other options might be available depending on the device.</span></span> <span data-ttu-id="00610-165">詳しくは、お使いのデバイス用のページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="00610-165">For more info, see the specific page for your device.</span></span>

### <a name="home"></a><span data-ttu-id="00610-166">ホーム</span><span class="sxs-lookup"><span data-stu-id="00610-166">Home</span></span>

<span data-ttu-id="00610-167">デバイス ポータル セッションはホーム ページで開始します。</span><span class="sxs-lookup"><span data-stu-id="00610-167">Your Device Portal session starts at the home page.</span></span> <span data-ttu-id="00610-168">通常、ホーム ページには、名前や OS のバージョンなどのデバイスに関する情報、およびデバイスについて設定できる項目が表示されます。</span><span class="sxs-lookup"><span data-stu-id="00610-168">The home page typically has information about the device, such as name and OS version, and preferences that you can set for the device.</span></span>

### <a name="apps"></a><span data-ttu-id="00610-169">アプリ</span><span class="sxs-lookup"><span data-stu-id="00610-169">Apps</span></span>

<span data-ttu-id="00610-170">デバイスへの AppX パッケージとバンドルのインストール/アンインストールおよび管理を行う機能を提供します。</span><span class="sxs-lookup"><span data-stu-id="00610-170">Provides install/uninstall and management functionality for AppX packages and bundles on your device.</span></span>

![モバイル用 Device Portal](images/device-portal/mob-device-portal-apps.png)

- <span data-ttu-id="00610-172">**[Installed apps]** (インストール済みのアプリ): アプリを削除および起動します。</span><span class="sxs-lookup"><span data-stu-id="00610-172">**Installed apps**: Remove and start apps.</span></span>
- <span data-ttu-id="00610-173">**[Running apps]** (実行中のアプリ): 現在実行されているアプリを一覧表示し、アプリを閉じるためのオプションを提供します。</span><span class="sxs-lookup"><span data-stu-id="00610-173">**Running apps**: Lists apps that are running currently and provides the option to close them.</span></span>
- <span data-ttu-id="00610-174">**[Install app]** (アプリのインストール): コンピューターまたはネットワーク上のフォルダーからインストールするアプリ パッケージを選択します。</span><span class="sxs-lookup"><span data-stu-id="00610-174">**Install app**: Select app packages for installation from a folder on your computer or network.</span></span>
- <span data-ttu-id="00610-175">**[Dependency]** (依存関係): インストールするアプリの依存関係を追加します。</span><span class="sxs-lookup"><span data-stu-id="00610-175">**Dependency**: Add dependencies for the app you are going to install.</span></span>
- <span data-ttu-id="00610-176">**[Deploy]** (展開): 選択したアプリと依存関係をデバイスに展開します。</span><span class="sxs-lookup"><span data-stu-id="00610-176">**Deploy**: Deploy the selected app and dependencies to your device.</span></span>

**<span data-ttu-id="00610-177">アプリをインストールするには</span><span class="sxs-lookup"><span data-stu-id="00610-177">To install an app</span></span>**

1.  <span data-ttu-id="00610-178">[アプリ パッケージを作成](https://msdn.microsoft.com/library/windows/apps/xaml/hh454036(v=vs.140).aspx)したら、デバイス上にリモートでインストールできます。</span><span class="sxs-lookup"><span data-stu-id="00610-178">When you've [created an app package](https://msdn.microsoft.com/library/windows/apps/xaml/hh454036(v=vs.140).aspx), you can remotely install it onto your device.</span></span> <span data-ttu-id="00610-179">Visual Studio でビルドすると、出力フォルダーが生成されます。</span><span class="sxs-lookup"><span data-stu-id="00610-179">After you build it in Visual Studio, an output folder is generated.</span></span>

    ![アプリのインストール](images/device-portal/iot-installapp0.png)
2.  <span data-ttu-id="00610-181">[参照] をクリックして、アプリ パッケージ (.appx) を検索します。</span><span class="sxs-lookup"><span data-stu-id="00610-181">Click browse and find your app package (.appx).</span></span>
3.  <span data-ttu-id="00610-182">[参照] をクリックして、証明書ファイル (.cer) を検索します。</span><span class="sxs-lookup"><span data-stu-id="00610-182">Click browse and find the certificate file (.cer).</span></span> <span data-ttu-id="00610-183">(デバイスによっては不要です。)</span><span class="sxs-lookup"><span data-stu-id="00610-183">(Not required on all devices.)</span></span>
4.  <span data-ttu-id="00610-184">依存関係を追加します。</span><span class="sxs-lookup"><span data-stu-id="00610-184">Add dependencies.</span></span> <span data-ttu-id="00610-185">1 つ以上ある場合は、それぞれを個別に追加します。</span><span class="sxs-lookup"><span data-stu-id="00610-185">If you have more than one, add each one individually.</span></span>     
5.  <span data-ttu-id="00610-186">**[Deploy]** (展開) の下の **[Go]** (進む) をクリックします。</span><span class="sxs-lookup"><span data-stu-id="00610-186">Under **Deploy**, click **Go**.</span></span> 
6.  <span data-ttu-id="00610-187">別のアプリをインストールするには、**[Reset]** (リセット) ボタンをクリックしてフィールドをクリアします。</span><span class="sxs-lookup"><span data-stu-id="00610-187">To install another app, click the **Reset** button to clear the fields.</span></span>


**<span data-ttu-id="00610-188">アプリをアンインストールするには</span><span class="sxs-lookup"><span data-stu-id="00610-188">To uninstall an app</span></span>**

1.  <span data-ttu-id="00610-189">アプリが実行中でないことを確認します。</span><span class="sxs-lookup"><span data-stu-id="00610-189">Ensure that your app is not running.</span></span> 
2.  <span data-ttu-id="00610-190">実行中の場合、[Running apps] に移動してそのアプリを閉じます。</span><span class="sxs-lookup"><span data-stu-id="00610-190">If it is, go to 'running apps' and close it.</span></span> <span data-ttu-id="00610-191">アプリの実行中にアンインストールすると、そのアプリを再インストールしようとするときに問題が発生することがあります。</span><span class="sxs-lookup"><span data-stu-id="00610-191">If you attempt to uninstall while the app is running, it will cause issues when trying to re-install the app.</span></span> 
3.  <span data-ttu-id="00610-192">準備ができたら、**[Uninstall]** (アンインストール) をクリックします。</span><span class="sxs-lookup"><span data-stu-id="00610-192">Once you're ready, click **Uninstall**.</span></span>

### <a name="processes"></a><span data-ttu-id="00610-193">プロセス</span><span class="sxs-lookup"><span data-stu-id="00610-193">Processes</span></span>

<span data-ttu-id="00610-194">現在実行中のプロセスに関する詳細を表示します。</span><span class="sxs-lookup"><span data-stu-id="00610-194">Shows details about currently running processes.</span></span> <span data-ttu-id="00610-195">これには、アプリとシステムの両方のプロセスが含まれます。</span><span class="sxs-lookup"><span data-stu-id="00610-195">This includes both apps and system processes.</span></span>

<span data-ttu-id="00610-196">このページでは、PC のタスク マネージャーと同様に、現在実行されているプロセスと、そのプロセスのメモリ使用量を確認できます。</span><span class="sxs-lookup"><span data-stu-id="00610-196">Much like the Task Manager on your PC, this page lets you see which processes are currently running as well as their memory usage.</span></span>  <span data-ttu-id="00610-197">一部のプラットフォーム (Desktop、IoT、および HoloLens) では、プロセスを終了することができます。</span><span class="sxs-lookup"><span data-stu-id="00610-197">On some platforms (Desktop, IoT, and HoloLens) you can terminate processes.</span></span>

![モバイル用 Device Portal](images/device-portal/mob-device-portal-processes.png)

### <a name="performance"></a><span data-ttu-id="00610-199">パフォーマンス</span><span class="sxs-lookup"><span data-stu-id="00610-199">Performance</span></span>

<span data-ttu-id="00610-200">電力消費、フレーム レート、CPU 負荷など、システムの診断情報のグラフをリアルタイムで表示します。</span><span class="sxs-lookup"><span data-stu-id="00610-200">Shows real-time graphs of system diagnostic info, like power usage, frame rate, and CPU load.</span></span>

<span data-ttu-id="00610-201">利用可能なメトリックを次に示します。</span><span class="sxs-lookup"><span data-stu-id="00610-201">These are the available metrics:</span></span>
- <span data-ttu-id="00610-202">**[CPU]**: 使用可能量の合計に対するパーセント</span><span class="sxs-lookup"><span data-stu-id="00610-202">**CPU**: Percent of total available</span></span>
- <span data-ttu-id="00610-203">**[Memory]** (メモリ): 合計メモリ、使用中のメモリ、使用可能なコミット メモリ、ページ メモリ、および非ページ メモリ</span><span class="sxs-lookup"><span data-stu-id="00610-203">**Memory**: Total, in use, available committed, paged, and non-paged</span></span>
- <span data-ttu-id="00610-204">**[GPU]**: GPU エンジンの使用率、使用可能量の合計に対するパーセント</span><span class="sxs-lookup"><span data-stu-id="00610-204">**GPU**: GPU engine utilization, percent of total available</span></span>
- <span data-ttu-id="00610-205">**[I/O]**: 読み取りと書き込み</span><span class="sxs-lookup"><span data-stu-id="00610-205">**I/O**: Reads and writes</span></span>
- <span data-ttu-id="00610-206">**[Network]** (ネットワーク): 受信と送信</span><span class="sxs-lookup"><span data-stu-id="00610-206">**Network**: Received and sent</span></span>

![モバイル用 Device Portal](images/device-portal/mob-device-portal-perf.png)

### <a name="event-tracing-for-windows-etw"></a><span data-ttu-id="00610-208">Windows イベント トレーシング (ETW)</span><span class="sxs-lookup"><span data-stu-id="00610-208">Event Tracing for Windows (ETW)</span></span>

<span data-ttu-id="00610-209">デバイス上の Windows イベント トレーシング (ETW) をリアルタイムで管理します。</span><span class="sxs-lookup"><span data-stu-id="00610-209">Manages realtime Event Tracing for Windows (ETW) on the device.</span></span>

![モバイル用 Device Portal](images/device-portal/mob-device-portal-etw.png)

<span data-ttu-id="00610-211">**[Hide Providers]** (プロバイダを非表示にする) チェックボックスをオンにすると、イベントの一覧のみが表示されます。</span><span class="sxs-lookup"><span data-stu-id="00610-211">Check **Hide providers** to show the Events list only.</span></span>
- <span data-ttu-id="00610-212">**[Registered providers]** (登録済みプロバイダー): ETW プロバイダーとトレース レベルを選択します。</span><span class="sxs-lookup"><span data-stu-id="00610-212">**Registered providers**: Select the ETW provider and the tracing level.</span></span> <span data-ttu-id="00610-213">トレース レベルは次のいずれかの値になります。</span><span class="sxs-lookup"><span data-stu-id="00610-213">Tracing level is one of these values:</span></span>
    1. <span data-ttu-id="00610-214">異常終了または終了</span><span class="sxs-lookup"><span data-stu-id="00610-214">Abnormal exit or termination</span></span>
    2. <span data-ttu-id="00610-215">重大なエラー</span><span class="sxs-lookup"><span data-stu-id="00610-215">Severe errors</span></span>
    3. <span data-ttu-id="00610-216">警告</span><span class="sxs-lookup"><span data-stu-id="00610-216">Warnings</span></span>
    4. <span data-ttu-id="00610-217">エラーではない警告</span><span class="sxs-lookup"><span data-stu-id="00610-217">Non-error warnings</span></span>
    5. <span data-ttu-id="00610-218">詳細なトレース (*)</span><span class="sxs-lookup"><span data-stu-id="00610-218">Detailed trace (*)</span></span>

<span data-ttu-id="00610-219">トレースを開始するには、**[Enable]** (有効にする) をクリックまたはタップします。</span><span class="sxs-lookup"><span data-stu-id="00610-219">Click or tap **Enable** to start tracing.</span></span> <span data-ttu-id="00610-220">**[Enabled Providers]** (有効なプロバイダー) ドロップダウン リストにプロバイダーが追加されます。</span><span class="sxs-lookup"><span data-stu-id="00610-220">The provider is added to the **Enabled Providers** dropdown.</span></span>
- <span data-ttu-id="00610-221">**[Custom providers]** (カスタム プロバイダー): カスタム ETW プロバイダーとトレース レベルを選択します。</span><span class="sxs-lookup"><span data-stu-id="00610-221">**Custom providers**: Select a custom ETW provider and the tracing level.</span></span> <span data-ttu-id="00610-222">GUID を使用してプロバイダーを識別します。</span><span class="sxs-lookup"><span data-stu-id="00610-222">Identify the provider by its GUID.</span></span> <span data-ttu-id="00610-223">GUID にはかっこを含めないでください。</span><span class="sxs-lookup"><span data-stu-id="00610-223">Don't include brackets in the GUID.</span></span>
- <span data-ttu-id="00610-224">**[Enabled providers]** (有効なプロバイダー): 有効なプロバイダーを一覧表示します。</span><span class="sxs-lookup"><span data-stu-id="00610-224">**Enabled providers**: Lists the enabled providers.</span></span> <span data-ttu-id="00610-225">ドロップダウンからプロバイダーを選択し、**[Disable]** (無効にする) をクリックまたはタップしてトレースを停止します。</span><span class="sxs-lookup"><span data-stu-id="00610-225">Select a provider from the dropdown and click or tap **Disable** to stop tracing.</span></span> <span data-ttu-id="00610-226">すべてのトレースを中断するには、**[Stop All]** (すべて停止) をクリックまたはタップします。</span><span class="sxs-lookup"><span data-stu-id="00610-226">Click or tap **Stop all** to suspend all tracing.</span></span>
- <span data-ttu-id="00610-227">**[Providers history]** (プロバイダー履歴): 現在のセッション中に有効になった ETW プロバイダーを表示します。</span><span class="sxs-lookup"><span data-stu-id="00610-227">**Providers history**: Shows the ETW providers that were enabled during the current session.</span></span> <span data-ttu-id="00610-228">無効になっているプロバイダーをアクティブ化するには、**[Enable]** (有効にする) をクリックまたはタップします。</span><span class="sxs-lookup"><span data-stu-id="00610-228">Click or tap **Enable** to activate a provider that was disabled.</span></span> <span data-ttu-id="00610-229">履歴をクリアするには、**[Clear]** (クリア) をクリックまたはタップします。</span><span class="sxs-lookup"><span data-stu-id="00610-229">Click or tap **Clear** to clear the history.</span></span>
- <span data-ttu-id="00610-230">**[Events]** (イベント): 選択したプロバイダーの ETW イベントを表形式で一覧表示します。</span><span class="sxs-lookup"><span data-stu-id="00610-230">**Events**: Lists ETW events from the selected providers in table format.</span></span> <span data-ttu-id="00610-231">この表は、リアルタイムで更新されます。</span><span class="sxs-lookup"><span data-stu-id="00610-231">This table is updated in real time.</span></span> <span data-ttu-id="00610-232">すべての ETW イベントを表から削除するには、表の下にある **[Clear]** (クリア) ボタンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="00610-232">Beneath the table, click the **Clear** button to delete all ETW events from the table.</span></span> <span data-ttu-id="00610-233">これによってプロバイダーが無効になることはありません。</span><span class="sxs-lookup"><span data-stu-id="00610-233">This does not disable any providers.</span></span> <span data-ttu-id="00610-234">**[Save to file]** (ファイルに保存) をクリックすると、現在収集されている ETW イベントをローカルの CSV ファイルにエクスポートできます。</span><span class="sxs-lookup"><span data-stu-id="00610-234">You can click **Save to file** to export the currently collected ETW events to a CSV file locally.</span></span>

<span data-ttu-id="00610-235">ETW トレースの使い方について詳しくは、アプリからリアルタイムのログを収集する方法に関する[ブログの記事](https://blogs.windows.com/buildingapps/2016/06/10/using-device-portal-to-view-debug-logs-for-uwp/)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="00610-235">For more details on using ETW tracing, see the [blogpost](https://blogs.windows.com/buildingapps/2016/06/10/using-device-portal-to-view-debug-logs-for-uwp/) about using it to collect real-time logs from your app.</span></span> 

### <a name="performance-tracing"></a><span data-ttu-id="00610-236">パフォーマンス トレース</span><span class="sxs-lookup"><span data-stu-id="00610-236">Performance tracing</span></span>

<span data-ttu-id="00610-237">[Windows Performance Recorder](https://msdn.microsoft.com/library/windows/hardware/hh448205.aspx) (WPR) のトレースをデバイスからキャプチャします。</span><span class="sxs-lookup"><span data-stu-id="00610-237">Capture [Windows Performance Recorder](https://msdn.microsoft.com/library/windows/hardware/hh448205.aspx) (WPR) traces from your device.</span></span>

![モバイル用 Device Portal](images/device-portal/mob-device-portal-perf-tracing.png)

- <span data-ttu-id="00610-239">**[Available profiles]** (利用可能なプロファイル): ドロップダウン リストから WPR プロファイルを選択し、**[Start]** (開始) をクリックまたはタップすると、トレースを開始できます。</span><span class="sxs-lookup"><span data-stu-id="00610-239">**Available profiles**: Select the WPR profile from the dropdown, and click or tap **Start** to start tracing.</span></span>
- <span data-ttu-id="00610-240">**[Custom profiles]** (カスタム プロファイル): **[Browse]** (参照) をクリックまたはタップして、PC から WPR プロファイルを選択します。</span><span class="sxs-lookup"><span data-stu-id="00610-240">**Custom profiles**: Click or tap **Browse** to choose a WPR profile from your PC.</span></span> <span data-ttu-id="00610-241">**[Upload and start]** (アップロードして開始) をクリックまたはタップすると、トレースが開始します。</span><span class="sxs-lookup"><span data-stu-id="00610-241">Click or tap **Upload and start** to start tracing.</span></span>

<span data-ttu-id="00610-242">トレースを停止するには、**[Stop]** (停止) をクリックします。</span><span class="sxs-lookup"><span data-stu-id="00610-242">To stop the trace, click **Stop**.</span></span> <span data-ttu-id="00610-243">トレース ファイル (.ETL) のダウンロードが完了するまで、このページを閉じないでください。</span><span class="sxs-lookup"><span data-stu-id="00610-243">Stay on this page until the trace file (.ETL) has completed downloading.</span></span>

<span data-ttu-id="00610-244">キャプチャした ETL ファイルは、[Windows Performance Analyzer](https://msdn.microsoft.com/library/windows/hardware/hh448170.aspx) で開いて分析に使用できます。</span><span class="sxs-lookup"><span data-stu-id="00610-244">Captured ETL files can be opened for analysis in [Windows Performance Analyzer](https://msdn.microsoft.com/library/windows/hardware/hh448170.aspx).</span></span>

### <a name="devices"></a><span data-ttu-id="00610-245">デバイス</span><span class="sxs-lookup"><span data-stu-id="00610-245">Devices</span></span>

<span data-ttu-id="00610-246">デバイスに接続されているすべての周辺機器を列挙します。</span><span class="sxs-lookup"><span data-stu-id="00610-246">Enumerates all peripherals attached to your device.</span></span>

![モバイル用 Device Portal](images/device-portal/mob-device-portal-devices.png)

### <a name="networking"></a><span data-ttu-id="00610-248">ネットワーク</span><span class="sxs-lookup"><span data-stu-id="00610-248">Networking</span></span>

<span data-ttu-id="00610-249">デバイス上のネットワーク接続を管理します。</span><span class="sxs-lookup"><span data-stu-id="00610-249">Manages network connections on the device.</span></span>  <span data-ttu-id="00610-250">デバイス ポータルに USB 経由で接続している場合を除き、これらの設定を変更するとデバイス ポータルとの接続が切断される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="00610-250">Unless you are connected to Device Portal via USB, changing these settings will likely disconnect you from Device Portal.</span></span>
- <span data-ttu-id="00610-251">**[Profiles]** (プロファイル): 使用する Wi-Fi プロファイルを選択します。</span><span class="sxs-lookup"><span data-stu-id="00610-251">**Profiles**: Select a different WiFi profile to use.</span></span>  
- <span data-ttu-id="00610-252">**[Available networks]** (利用可能なネットワーク): デバイスで利用可能な Wi-Fi ネットワーク。</span><span class="sxs-lookup"><span data-stu-id="00610-252">**Available networks**: The WiFi networks available to the device.</span></span> <span data-ttu-id="00610-253">ネットワークをクリックまたはタップすると、そのネットワークに接続し、必要に応じてパスキーを提供できます。</span><span class="sxs-lookup"><span data-stu-id="00610-253">Clicking or tapping on a network will allow you to connect to it and supply a passkey if needed.</span></span> <span data-ttu-id="00610-254">注: Device Portal では Enterprise Authentication はまだサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="00610-254">Note: Device Portal does not yet support Enterprise Authentication.</span></span> 

![モバイル用 Device Portal](images/device-portal/mob-device-portal-network.png)

### <a name="app-file-explorer"></a><span data-ttu-id="00610-256">アプリのエクスプローラー</span><span class="sxs-lookup"><span data-stu-id="00610-256">App File Explorer</span></span>

<span data-ttu-id="00610-257">サイドロードされたアプリによって保存されたファイルを表示および操作できるようにします。</span><span class="sxs-lookup"><span data-stu-id="00610-257">Allows you to view and manipulate files stored by your sideloaded apps.</span></span>  <span data-ttu-id="00610-258">これは、Windows Phone 8.1 の[分離ストレージ エクスプローラー](https://msdn.microsoft.com/library/windows/apps/hh286408(v=vs.105).aspx)の新しいクロスプラットフォーム バージョンです。アプリのエクスプローラーとその使用方法について詳しくは、[こちらのブログの投稿](https://blogs.windows.com/buildingapps/2016/06/08/using-the-app-file-explorer-to-see-your-app-data/)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="00610-258">This is a new, cross-platform version of the [Isolated Storage Explorer](https://msdn.microsoft.com/library/windows/apps/hh286408(v=vs.105).aspx) from Windows Phone 8.1  See [this blog post](https://blogs.windows.com/buildingapps/2016/06/08/using-the-app-file-explorer-to-see-your-app-data/) to learn more about the App File Explorer and how to use it.</span></span> 

![モバイル用 Device Portal](images/device-portal/mob-device-portal-AppFileExplorer.png)

## <a name="service-features-and-notes"></a><span data-ttu-id="00610-260">サービスの機能と注意事項</span><span class="sxs-lookup"><span data-stu-id="00610-260">Service Features and Notes</span></span>

### <a name="dns-sd"></a><span data-ttu-id="00610-261">DNS-SD</span><span class="sxs-lookup"><span data-stu-id="00610-261">DNS-SD</span></span>

<span data-ttu-id="00610-262">Device Portal は DNS-SD を使用して、ローカル ネットワーク上でその存在をアドバタイズします</span><span class="sxs-lookup"><span data-stu-id="00610-262">Device Portal advertises its presence on the local network using DNS-SD.</span></span>  <span data-ttu-id="00610-263">Device Portal のすべてのインスタンスは、デバイスの種類に関係なく、"WDP._wdp._tcp.local" でアドバタイズします。</span><span class="sxs-lookup"><span data-stu-id="00610-263">All Device Portal instances, regardless of their device type, advertise under "WDP._wdp._tcp.local".</span></span> <span data-ttu-id="00610-264">サービス インスタンスの TXT レコードは、次の情報を提供します。</span><span class="sxs-lookup"><span data-stu-id="00610-264">The TXT records for the service instance provide the following:</span></span>

<span data-ttu-id="00610-265">キー</span><span class="sxs-lookup"><span data-stu-id="00610-265">Key</span></span> | <span data-ttu-id="00610-266">型</span><span class="sxs-lookup"><span data-stu-id="00610-266">Type</span></span> | <span data-ttu-id="00610-267">説明</span><span class="sxs-lookup"><span data-stu-id="00610-267">Description</span></span> 
----|------|-------------
<span data-ttu-id="00610-268">S</span><span class="sxs-lookup"><span data-stu-id="00610-268">S</span></span> | <span data-ttu-id="00610-269">int</span><span class="sxs-lookup"><span data-stu-id="00610-269">int</span></span> | <span data-ttu-id="00610-270">Device Portal 用のセキュリティで保護されたポート。</span><span class="sxs-lookup"><span data-stu-id="00610-270">Secure port for Device Portal.</span></span>  <span data-ttu-id="00610-271">0 (ゼロ) の場合、Device Portal は HTTPS 接続をリッスンしていません。</span><span class="sxs-lookup"><span data-stu-id="00610-271">If 0 (zero), Device Portal is not listening for HTTPS connections.</span></span> 
<span data-ttu-id="00610-272">D</span><span class="sxs-lookup"><span data-stu-id="00610-272">D</span></span> | <span data-ttu-id="00610-273">string</span><span class="sxs-lookup"><span data-stu-id="00610-273">string</span></span> | <span data-ttu-id="00610-274">デバイスの種類。</span><span class="sxs-lookup"><span data-stu-id="00610-274">Type of device.</span></span>  <span data-ttu-id="00610-275">"Windows.*" の形式 (Windows.Xbox、Windows.Desktop など) になります。</span><span class="sxs-lookup"><span data-stu-id="00610-275">This will be in the format "Windows.*", e.g. Windows.Xbox or Windows.Desktop</span></span>
<span data-ttu-id="00610-276">A</span><span class="sxs-lookup"><span data-stu-id="00610-276">A</span></span> | <span data-ttu-id="00610-277">string</span><span class="sxs-lookup"><span data-stu-id="00610-277">string</span></span> | <span data-ttu-id="00610-278">デバイスのアーキテクチャ。</span><span class="sxs-lookup"><span data-stu-id="00610-278">Device architecture.</span></span>  <span data-ttu-id="00610-279">これは、ARM、x86、AMD64 のいずれかです。</span><span class="sxs-lookup"><span data-stu-id="00610-279">This will be ARM, x86, or AMD64.</span></span>  
<span data-ttu-id="00610-280">T</span><span class="sxs-lookup"><span data-stu-id="00610-280">T</span></span> | <span data-ttu-id="00610-281">null 文字で区切られた string のリスト</span><span class="sxs-lookup"><span data-stu-id="00610-281">null-character delineated list of strings</span></span> | <span data-ttu-id="00610-282">ユーザーが適用したデバイスのタグ。</span><span class="sxs-lookup"><span data-stu-id="00610-282">User-applied tags for the device.</span></span> <span data-ttu-id="00610-283">使い方については、タグの REST API に関する説明をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="00610-283">See the Tags REST API for how to use this.</span></span> <span data-ttu-id="00610-284">リストは 2 つの null で終了します。</span><span class="sxs-lookup"><span data-stu-id="00610-284">List is double-null terminated.</span></span>  

<span data-ttu-id="00610-285">DNS-SD レコードでアドバタイズされる HTTP ポートですべてのデバイスがリッスンしているわけではないため、HTTPS ポートでの接続をお勧めします。</span><span class="sxs-lookup"><span data-stu-id="00610-285">Connecting on the HTTPS port is suggested, as not all devices are listening on the HTTP port advertised by the DNS-SD record.</span></span> 

### <a name="csrf-protection-and-scripting"></a><span data-ttu-id="00610-286">CSRF に対する保護とスクリプト</span><span class="sxs-lookup"><span data-stu-id="00610-286">CSRF Protection and Scripting</span></span>

<span data-ttu-id="00610-287">[CSRF 攻撃](https://wikipedia.org/wiki/Cross-site_request_forgery)に対する保護のために、すべての非 GET 要求に一意のトークンが必要です。</span><span class="sxs-lookup"><span data-stu-id="00610-287">In order to protect against [CSRF attacks](https://wikipedia.org/wiki/Cross-site_request_forgery), a unique token is required on all non-GET requests.</span></span> <span data-ttu-id="00610-288">このトークン、X-CSRF-Token 要求ヘッダーは、セッション Cookie、CSRF-Token から派生します。</span><span class="sxs-lookup"><span data-stu-id="00610-288">This token, the X-CSRF-Token request header, is derived from a session cookie, CSRF-Token.</span></span> <span data-ttu-id="00610-289">Device Portal の Web UI では、CSRF-Token Cookie が、各要求の X-CSRF-Token にコピーされます。</span><span class="sxs-lookup"><span data-stu-id="00610-289">In the Device Portal web UI, the CSRF-Token cookie is copied into the X-CSRF-Token header on each request.</span></span>

<span data-ttu-id="00610-290">**重要:** この保護によって、スタンドアロン クライアント (コマンド ライン ユーティリティなど) から REST API を使用できなくなります。</span><span class="sxs-lookup"><span data-stu-id="00610-290">**Important** This protection prevents usages of the REST APIs from a standalone client (e.g. command-line utilities).</span></span> <span data-ttu-id="00610-291">これは 3 つの方法で解決できます。</span><span class="sxs-lookup"><span data-stu-id="00610-291">This can be solved in 3 ways:</span></span> 

1. <span data-ttu-id="00610-292">"auto-" というユーザー名を使用します。</span><span class="sxs-lookup"><span data-stu-id="00610-292">Use of the "auto-" username.</span></span> <span data-ttu-id="00610-293">クライアントはユーザー名の前に "auto-" を追加することによって、CSRF に対する保護を迂回できます。</span><span class="sxs-lookup"><span data-stu-id="00610-293">Clients that prepend "auto-" to their username will bypass CSRF protection.</span></span> <span data-ttu-id="00610-294">このユーザー名は、ブラウザーから Device Portal にログインするために使用しないでください。サービスが CSRF 攻撃を受ける可能性があります。</span><span class="sxs-lookup"><span data-stu-id="00610-294">It is important that this username not be used to log in to Device Portal through the browser, as it will open up the service to CSRF attacks.</span></span> <span data-ttu-id="00610-295">例: Device Portal のユーザー名が "admin" である場合、CSRF に対する保護を迂回するために ```curl -u auto-admin:password <args>``` を使用します。</span><span class="sxs-lookup"><span data-stu-id="00610-295">Example: If Device Portal's username is "admin", ```curl -u auto-admin:password <args>``` should be used to bypass CSRF protection.</span></span> 

2. <span data-ttu-id="00610-296">クライアントで cookie-to-header スキームを実装します。</span><span class="sxs-lookup"><span data-stu-id="00610-296">Implement the cookie-to-header scheme in the client.</span></span> <span data-ttu-id="00610-297">そのためには、GET 要求でセッション Cookie を確立し、それ以降のすべての要求にヘッダーと Cookie の両方を含めます。</span><span class="sxs-lookup"><span data-stu-id="00610-297">This requires a GET request to establish the session cookie, and then the inclusion of both the header and the cookie on all subsequent requests.</span></span> 
 
3. <span data-ttu-id="00610-298">認証を無効にして、HTTP を使用します。</span><span class="sxs-lookup"><span data-stu-id="00610-298">Disable authentication and use HTTP.</span></span> <span data-ttu-id="00610-299">CSRF に対する保護は HTTPS エンドポイントにのみ適用されるため、HTTP エンドポイントに接続する場合、上記のいずれの操作も必要ありません。</span><span class="sxs-lookup"><span data-stu-id="00610-299">CSRF protection only applies to HTTPS endpoints, so connections on HTTP endpoints will not need to do either of the above.</span></span> 

<span data-ttu-id="00610-300">**注**: ユーザー名が "auto-" で始まる場合、ブラウザーを使用して Device Portal にログインできません。</span><span class="sxs-lookup"><span data-stu-id="00610-300">**Note**: a username that begins with "auto-" will not be able to log into Device Portal via the browser.</span></span>  

#### <a name="cross-site-websocket-hijacking-cswsh-protection"></a><span data-ttu-id="00610-301">クロスサイト WebSocket ハイジャック (CSWSH) に対する保護</span><span class="sxs-lookup"><span data-stu-id="00610-301">Cross-Site WebSocket Hijacking (CSWSH) protection</span></span>

<span data-ttu-id="00610-302">[CSWSH 攻撃](https://www.christian-schneider.net/CrossSiteWebSocketHijacking.html)を防御するために、Device Portal に対して WebSocket 接続を開くすべてのクライアントは、Host ヘッダーと一致する Origin ヘッダーも提供する必要があります。</span><span class="sxs-lookup"><span data-stu-id="00610-302">To protect against [CSWSH attacks](https://www.christian-schneider.net/CrossSiteWebSocketHijacking.html), all clients opening a WebSocket connection to Device Portal must also provide an Origin header that matches the Host header.</span></span>  <span data-ttu-id="00610-303">これにより、Device Portal に対して、要求が Device Portal の UI または有効なクライアント アプリケーションからの要求であることを証明します。</span><span class="sxs-lookup"><span data-stu-id="00610-303">This proves to Device Portal that the request comes either from the Device Portal UI or a valid client application.</span></span>  <span data-ttu-id="00610-304">Origin ヘッダーがない場合、要求は拒否されます。</span><span class="sxs-lookup"><span data-stu-id="00610-304">Without the Origin header your request will be rejected.</span></span> 
