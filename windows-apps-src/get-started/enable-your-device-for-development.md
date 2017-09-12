---
author: GrantMeStrength
ms.assetid: 54973C62-9669-4988-934E-9273FB0425FD
title: "デバイスを開発用に有効にする"
description: "開発およびデバッグ用に Windows 10 デバイスを構成します。"
keywords: "開発者用 Visual Studio での作業の開始, 開発者用ライセンス対応デバイス"
ms.author: jken
ms.date: 03/12/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.openlocfilehash: 8a7b01205acf12d4a0ab6d3d7024311b3944f103
ms.sourcegitcommit: 0fa9ae00117e8e6b04ed38956e605bb74c1261c6
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/07/2017
---
# <a name="enable-your-device-for-development"></a><span data-ttu-id="6f0a9-104">デバイスを開発用に有効にする</span><span class="sxs-lookup"><span data-stu-id="6f0a9-104">Enable your device for development</span></span>

## <a name="activate-developer-mode-sideload-apps-and-access-other-developer-features"></a><span data-ttu-id="6f0a9-105">開発者モードを有効にし、アプリのサイドローディングを行い、その他の開発者向け機能にアクセスする</span><span class="sxs-lookup"><span data-stu-id="6f0a9-105">Activate Developer Mode, sideload apps and access other developer features</span></span>

![デバイスを開発用に有効にする](images/developer-poster.png)

<span data-ttu-id="6f0a9-107">コンピューターをゲーム、Web 閲覧、メール、Office アプリなどの日々の通常の用途に使用している場合は、開発者モードを有効にする*必要はなく*、また有効にしないことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-107">If you are using your computer for ordinary day-to-day activities such as games, web browsing, email or Office apps, you do *not* need to activate Developer Mode and in fact, you shouldn't activate it.</span></span> <span data-ttu-id="6f0a9-108">その場合は、このページの情報の残りの部分は、関連のない情報ですので、</span><span class="sxs-lookup"><span data-stu-id="6f0a9-108">The rest of the information on this page won't matter to you, and you can safely get back to whatever it is you were doing.</span></span> <span data-ttu-id="6f0a9-109">元の作業にお戻りください。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-109">Thanks for stopping by!</span></span>

<span data-ttu-id="6f0a9-110">コンピューターで初めて Visual Studio を使用してソフトウェアを作成する場合は、開発用 PC とコードのテスト用デバイスの両方で、開発者モードを有効にする*必要*があります。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-110">However, if you are writing software with Visual Studio on a computer for first time, you *will* need to enable Developer Mode on both the development PC, and on any devices you'll use to test your code.</span></span> <span data-ttu-id="6f0a9-111">開発者モードが有効になっていない状態で UWP プロジェクトを開くと、**[開発者向け]** 設定ページが開くか、Visual Studio に次のダイアログ ボックスが表示されます。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-111">Opening a UWP project when Developer Mode is not enabled will either open the **For developers** settings page, or cause this dialog to appear in Visual Studio:</span></span>

![Visual Studio で表示される、開発者モードを有効にするためのダイアログ](images/latestenabledialog.png)

<span data-ttu-id="6f0a9-113">このダイアログが表示された場合は、**[開発者向け設定]** をクリックして **[開発者向け] ** 設定ページを開きます。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-113">When you see this dialog, click **settings for developers** to open the **For developers** settings page.</span></span>

> [!NOTE]
> <span data-ttu-id="6f0a9-114">**[開発者向け]** ページにいつでも移動し、開発者モードの有効/無効を切り替えることができます。その場合には、タスク バーの Cortana 検索ボックスに「開発者向け」と入力するだけです。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-114">You can go to the **For developers** page at any time to enable or disable Developer Mode: simply enter "for developers" into the Cortana search box in the taskbar.</span></span>

## <a name="accessing-settings-for-developers"></a><span data-ttu-id="6f0a9-115">開発者向け設定にアクセスする</span><span class="sxs-lookup"><span data-stu-id="6f0a9-115">Accessing settings for Developers</span></span>

<span data-ttu-id="6f0a9-116">開発者モードを有効にするには、またはその他の設定にアクセスするには:</span><span class="sxs-lookup"><span data-stu-id="6f0a9-116">To enable Developer mode, or access other settings:</span></span>

1.  <span data-ttu-id="6f0a9-117">**[開発者向け]** 設定ダイアログ ボックスで、必要なアクセスのレベルを選択します。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-117">From the **For developers** settings dialog, choose the level of access that you need.</span></span>
2.  <span data-ttu-id="6f0a9-118">選択した設定の免責事項を読み、**[はい]** をクリックして変更を受け入れます。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-118">Read the disclaimer for the setting you chose, then click **Yes** to accept the change.</span></span>

> [!NOTE]
> <span data-ttu-id="6f0a9-119">組織所有のデバイスの場合は、組織によっていくつかのオプションが無効になっていることもあります。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-119">If your device is owned by an organization, some options might be disabled by your organization.</span></span>

<span data-ttu-id="6f0a9-120">デスクトップ デバイス ファミリの設定ページを以下に示します。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-120">Here's the settings page on the desktop device family:</span></span>

![[設定] に移動し、[更新とセキュリティ] を選び、[開発者向け] を選んでオプションを表示する](images/devmode-pc-options.png)

<span data-ttu-id="6f0a9-122">モバイル デバイス ファミリの設定ページを以下に示します。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-122">Here's the settings page on the mobile device family:</span></span>

![電話の [設定] から [更新とセキュリティ] を選ぶ](images/devmode-mob.png)

## <a name="which-setting-should-i-choose-sideload-apps-or-developer-mode"></a><span data-ttu-id="6f0a9-124">選ぶ必要がある設定: アプリのサイドローディングか開発者モードか</span><span class="sxs-lookup"><span data-stu-id="6f0a9-124">Which setting should I choose: sideload apps or Developer Mode?</span></span>

 <span data-ttu-id="6f0a9-125">デバイスでは、開発者モードを有効にすることも、サイドローディングのみを有効にすることもできます。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-125">You can enable a device for development, or just for sideloading.</span></span>

-   <span data-ttu-id="6f0a9-126">既定の設定は、*[Windows ストア アプリ]* です。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-126">*Windows Store apps* is the default setting.</span></span> <span data-ttu-id="6f0a9-127">アプリの開発中でない場合や、組織から配布された特殊な内部アプリを使っている場合は、この設定を有効にしておきます。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-127">If you aren't developing apps, or using special internal apps issued by your company, keep this setting active.</span></span>
-   <span data-ttu-id="6f0a9-128">*サイドローディング*では、Windows ストアの認証を受けていないアプリをインストールし、実行やテストを行うことができます。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-128">*Sideloading* is installing and then running or testing an app that has not been certified by the Windows Store.</span></span> <span data-ttu-id="6f0a9-129">たとえば、社内のみで使うアプリなどがあります。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-129">For example, an app that is internal to your company only.</span></span>
-   <span data-ttu-id="6f0a9-130">*開発者モード*を使用すると、アプリをサイドロードし、Visual Studio からデバッグ モードでアプリを実行することもできます。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-130">*Developer mode* lets you sideload apps, and also run apps from Visual Studio in debug mode.</span></span> 

<span data-ttu-id="6f0a9-131">既定では、Windows ストアからのみユニバーサル Windows プラットフォーム (UWP) アプリをインストールできます。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-131">By default, you can only install Universal Windows Platform (UWP) apps from the Windows Store.</span></span> <span data-ttu-id="6f0a9-132">開発者向け機能を使用するように設定を変更すると、デバイスのセキュリティ レベルが変わる場合があります。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-132">Changing these settings to use developer features can change the level of security of your device.</span></span> <span data-ttu-id="6f0a9-133">未検証のソースからはアプリをインストールしないでください。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-133">You should not install apps from unverified sources.</span></span>

### <a name="sideload-apps"></a><span data-ttu-id="6f0a9-134">アプリのサイドローディング</span><span class="sxs-lookup"><span data-stu-id="6f0a9-134">Sideload apps</span></span>

<span data-ttu-id="6f0a9-135">アプリのサイドローディング設定は、通常、Windows ストアを使わずにカスタム アプリを管理対象デバイスにインストールする必要がある会社や学校によって使用されます。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-135">The Sideload apps setting is typically used by companies or schools that need to install custom apps on managed devices without going through the Windows Store.</span></span> <span data-ttu-id="6f0a9-136">この場合、設定ページのイメージで以前に示したように、*Windows ストア アプリ*設定を無効にするポリシーを組織が適用していることはよくあります。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-136">In this case, it's common for the organization to enforce a policy that disables the *Windows Store apps* setting, as shown previously in the image of the settings page.</span></span> <span data-ttu-id="6f0a9-137">また、組織は、必要な証明書と、アプリをサイドローディングするインストール場所を提供します。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-137">The organization also provides the required certificate and install location to sideload apps.</span></span> <span data-ttu-id="6f0a9-138">詳しくは、TechNet の記事「[Windows 10 でのアプリのサイド ローディング](https://technet.microsoft.com/library/mt269549.aspx)」と「[Microsoft Intune でのアプリ展開の開始](https://technet.microsoft.com/library/dn646955.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-138">For more info, see the TechNet articles [Sideload apps in Windows 10](https://technet.microsoft.com/library/mt269549.aspx) and [Get started with app deployment in Microsoft Intune](https://technet.microsoft.com/library/dn646955.aspx).</span></span>

<span data-ttu-id="6f0a9-139">デバイス ファミリ固有の情報</span><span class="sxs-lookup"><span data-stu-id="6f0a9-139">Device family specific info</span></span>

-   <span data-ttu-id="6f0a9-140">デスクトップ デバイス ファミリの場合: パッケージと共に作成される Windows PowerShell スクリプトを実行して、アプリの実行に必要なアプリ パッケージ (.appx) と証明書をインストールできます ("Add-AppDevPackage.ps1")。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-140">On the desktop device family: You can install an app package (.appx) and any certificate that is needed to run the app by running the Windows PowerShell script that is created with the package ("Add-AppDevPackage.ps1").</span></span> <span data-ttu-id="6f0a9-141">詳しくは、「[UWP アプリのパッケージ化](../packaging/packaging-uwp-apps.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-141">For more info, see [Packaging UWP apps](../packaging/packaging-uwp-apps.md).</span></span>

-   <span data-ttu-id="6f0a9-142">モバイル デバイス ファミリの場合: 必要な証明書が既にインストールされている場合は、電子メールまたは SD カードで受け取ったファイルをタップして、.appx をインストールできます。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-142">On the mobile device family: If the required certificate is already installed, you can tap the file to install any .appx sent to you via email or on an SD card.</span></span>

<span data-ttu-id="6f0a9-143">信頼できる証明書がないデバイスにアプリをインストールすることはできないため、**アプリのサイドローディング**は開発者モードよりも安全です。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-143">**Sideload apps** is a more secure option than Developer Mode because you cannot install apps on the device without a trusted certificate.</span></span>

> [!NOTE]
> <span data-ttu-id="6f0a9-144">アプリをサイドローディングする場合は、信頼できるソースからのみアプリをインストールしてください。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-144">If you sideload apps, you should still only install apps from trusted sources.</span></span> <span data-ttu-id="6f0a9-145">サイドローディングしたアプリ (Windows ストアの認証を受けていないアプリ) をインストールする場合は、そのアプリをサイドローディングする際に必要なすべての権利をお客様が保持していること、およびそのアプリのインストールや実行の結果生じるすべての問題についてお客様が一切の責任を負うことに同意したものと見なされます。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-145">When you install a sideloaded app that has not been certified by the Windows Store, you are agreeing that you have obtained all rights necessary to sideload the app and that you are solely responsible for any harm that results from installing and running the app.</span></span> <span data-ttu-id="6f0a9-146">この[プライバシーに関する声明](http://go.microsoft.com/fwlink/?LinkId=521839)の「Windows」&gt;「Windows ストア」セクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-146">See the Windows &gt; Windows Store section of this [privacy statement](http://go.microsoft.com/fwlink/?LinkId=521839).</span></span>

### <a name="developer-mode"></a><span data-ttu-id="6f0a9-147">開発者モード</span><span class="sxs-lookup"><span data-stu-id="6f0a9-147">Developer Mode</span></span>

<span data-ttu-id="6f0a9-148">開発者モードは、開発者用ライセンスに対する Windows 8.1 の要件に置き換わるものです。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-148">Developer Mode replaces the Windows 8.1 requirements for a developer license.</span></span>  <span data-ttu-id="6f0a9-149">サイドローディングだけでなく、開発者モードの設定でデバッグおよび追加の展開オプションを有効にできます。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-149">In addition to sideloading, the Developer Mode setting enables debugging and additional deployment options.</span></span> <span data-ttu-id="6f0a9-150">デバイスを展開先にできるようにする SSH サービスの開始も含まれます。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-150">This includes starting an SSH service to allow this device to be deployed to.</span></span> <span data-ttu-id="6f0a9-151">このサービスを停止するためには、開発者モードを無効にしなければなりません。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-151">In order to stop this service, you have to disable Developer Mode.</span></span>

<span data-ttu-id="6f0a9-152">デバイス ファミリ固有の情報</span><span class="sxs-lookup"><span data-stu-id="6f0a9-152">Device family specific info</span></span>

-   <span data-ttu-id="6f0a9-153">デスクトップ デバイス ファミリの場合:</span><span class="sxs-lookup"><span data-stu-id="6f0a9-153">On the desktop device family:</span></span>

    <span data-ttu-id="6f0a9-154">開発者モードを有効にして、Visual Studio でアプリを開発およびデバッグします。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-154">Enable Developer Mode to develop and debug apps in Visual Studio.</span></span> <span data-ttu-id="6f0a9-155">既に説明したように、開発者モードが有効になっていない場合は、Visual Studio で有効にするように求められます。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-155">As stated previously, you will be prompted in Visual Studio if Developer Mode is not enabled.</span></span>

    <span data-ttu-id="6f0a9-156">Fall Creators Update より前の PC では、これにより Linux 用 Windows サブシステムを有効にできます。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-156">On pre-Fall-Creators-Update PCs, this allows enabling of the Windows subsystem for Linux.</span></span> <span data-ttu-id="6f0a9-157">詳しくは、「[Bash on Ubuntu on Windows について](https://msdn.microsoft.com/commandline/wsl/about)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-157">For more info, see [About Bash on Ubuntu on Windows](https://msdn.microsoft.com/commandline/wsl/about).</span></span>  <span data-ttu-id="6f0a9-158">Fall Creators Update 以降は、Linux 用 Windows サブシステムに開発者モードの必要はありません。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-158">Developer Mode is no longer required for WSL, as of the Fall Creators Update.</span></span>  

-   <span data-ttu-id="6f0a9-159">モバイル デバイス ファミリの場合:</span><span class="sxs-lookup"><span data-stu-id="6f0a9-159">On the mobile device family:</span></span>

    <span data-ttu-id="6f0a9-160">開発者モードを有効にして、Visual Studio からアプリを展開し、デバイスでそのアプリをデバッグします。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-160">Enable developer mode to deploy apps from Visual Studio and debug them on the device.</span></span>

    <span data-ttu-id="6f0a9-161">電子メールまたは SD カードで受け取ったファイルをタップして、.appx をインストールできます。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-161">You can tap the file to install any .appx sent to you via email or on an SD card.</span></span> <span data-ttu-id="6f0a9-162">未検証のソースからはアプリをインストールしないでください。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-162">Do not install apps from unverified sources.</span></span>

## <a name="additional-developer-mode-features"></a><span data-ttu-id="6f0a9-163">追加の開発者モード機能</span><span class="sxs-lookup"><span data-stu-id="6f0a9-163">Additional Developer Mode features</span></span>

<span data-ttu-id="6f0a9-164">各デバイス ファミリには、開発者向けの追加機能が用意されている場合があります。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-164">For each device family, additional developer features might be available.</span></span> <span data-ttu-id="6f0a9-165">これらの機能は、デバイスで開発者モードが有効になっている場合にのみ使用でき、OS バージョンによって異なる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-165">These features are available only when Developer Mode is enabled on the device, and might vary depending on your OS version.</span></span>

<span data-ttu-id="6f0a9-166">開発者モードを有効にすると、次のようなオプション パッケージがインストールされます。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-166">When you enable Developer Mode, a package of options is installed that includes:</span></span>
- <span data-ttu-id="6f0a9-167">Windows Device Portal。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-167">Windows Device Portal.</span></span> <span data-ttu-id="6f0a9-168">Device Portal が有効になり、ファイアウォール規則が構成されるのは、**[デバイス ポータルを有効にする]** オプションがオンの場合のみです。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-168">Device Portal is enabled and firewall rules are configured for it only when the **Enable Device Portal** option is turned on.</span></span>
- <span data-ttu-id="6f0a9-169">アプリのリモート インストールを可能にする SSH サービスのファイアウォール規則がインストールされ、有効になり、構成されます。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-169">Installs, enables, and configures firewall rules for SSH services that allow remote installation of apps.</span></span>


<span data-ttu-id="6f0a9-170">次の画像は、Windows 10 が搭載されたモバイル デバイス ファミリの開発者向け機能を示しています。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-170">This image shows developer features for the mobile device family on Windows 10:</span></span>

![モバイル デバイスの開発者モード オプション](images/devmode-mob-options.png) 

### <a name="span-iddevice-discovery-and-pairingspandevice-portal"></a><span data-ttu-id="6f0a9-172"><span id="device-discovery-and-pairing"></span>Device Portal</span><span class="sxs-lookup"><span data-stu-id="6f0a9-172"><span id="device-discovery-and-pairing"></span>Device Portal</span></span>

<span data-ttu-id="6f0a9-173">Device Portal について詳しくは、「[Windows Device Portal の概要](../debug-test-perf/device-portal.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-173">To learn more about Device Portal, see [Windows Device Portal overview](../debug-test-perf/device-portal.md).</span></span>

<span data-ttu-id="6f0a9-174">デバイス固有のセットアップ手順については、以下をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-174">For device specific setup instructions, see:</span></span>
- [<span data-ttu-id="6f0a9-175">デスクトップ用 Device Portal</span><span class="sxs-lookup"><span data-stu-id="6f0a9-175">Device Portal for Desktop</span></span>](https://msdn.microsoft.com/windows/uwp/debug-test-perf/device-portal-desktop)
- [<span data-ttu-id="6f0a9-176">HoloLens 用 Device Portal</span><span class="sxs-lookup"><span data-stu-id="6f0a9-176">Device Portal for HoloLens</span></span>](https://developer.microsoft.com/windows/holographic/using_the_windows_device_portal)
- [<span data-ttu-id="6f0a9-177">IoT 用 Device Portal</span><span class="sxs-lookup"><span data-stu-id="6f0a9-177">Device Portal for IoT</span></span>](https://developer.microsoft.com/windows/iot/docs/DevicePortal)
- [<span data-ttu-id="6f0a9-178">モバイル用 Device Portal</span><span class="sxs-lookup"><span data-stu-id="6f0a9-178">Device Portal for Mobile</span></span>](../debug-test-perf/device-portal-mobile.md)
- [<span data-ttu-id="6f0a9-179">Xbox 用 Device Portal</span><span class="sxs-lookup"><span data-stu-id="6f0a9-179">Device Portal for Xbox</span></span>](../debug-test-perf/device-portal-xbox.md)

<span data-ttu-id="6f0a9-180">開発者モードの有効化または Device Portal について問題が発生した場合には、「[既知の問題](https://social.msdn.microsoft.com/Forums/en-US/home?forum=Win10SDKToolsIssues&sort=relevancedesc&brandIgnore=True&searchTerm=%22device+portal%22)」フォーラムで問題の回避策を見つけるか、または「[開発者モード パッケージのインストール エラー](#failure-to-install-developer-mode-package)」で、開発者モード パッケージをブロック解除するための WSUS サポート技術情報の追加の情報をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-180">If you encounter problems enabling Developer Mode or Device Portal, see the [Known Issues](https://social.msdn.microsoft.com/Forums/en-US/home?forum=Win10SDKToolsIssues&sort=relevancedesc&brandIgnore=True&searchTerm=%22device+portal%22) forum to find workarounds for these issues, or visit [Failure to install the Developer Mode package](#failure-to-install-developer-mode-package) for additional details and which WSUS KBs to allow in order to unblock the Developer Mode package.</span></span> 

###<a name="ssh"></a><span data-ttu-id="6f0a9-181">SSH</span><span class="sxs-lookup"><span data-stu-id="6f0a9-181">SSH</span></span>

<span data-ttu-id="6f0a9-182">デバイスで開発者モードを有効にすると、SSH サービスが有効になります。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-182">SSH services are enabled when you enable Developer Mode on your device.</span></span>  <span data-ttu-id="6f0a9-183">デバイスが UWP アプリケーションの展開ターゲットの場合にこれを使用します。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-183">This is used when your device is a deployment target for UWP applications.</span></span>   <span data-ttu-id="6f0a9-184">サービスの名前は、「SSH Server Broker」と「SSH Server Proxy」です。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-184">The names of the services are 'SSH Server Broker' and 'SSH Server Proxy'.</span></span>

> [!NOTE]
> <span data-ttu-id="6f0a9-185">これは Microsoft の OpenSSH の実装ではありません。それは [GitHub](https://github.com/PowerShell/Win32-OpenSSH) にあります。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-185">This is not Microsoft's OpenSSH implementation, which you can find on [GitHub](https://github.com/PowerShell/Win32-OpenSSH).</span></span>

<span data-ttu-id="6f0a9-186">SSH サービスを利用するには、デバイスの検出を有効にして PIN のペアリングを許可できます。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-186">In order to take advantage of the SSH services, you can enable device discovery to allow pin pairing.</span></span> <span data-ttu-id="6f0a9-187">別の SSH サービスを実行する予定の場合、別のポートにセットアップするか、開発者モードの SSH サービスを無効にできます。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-187">If you intend to run another SSH service, you can set this up on a different port or turn off the Developer Mode SSH services.</span></span> <span data-ttu-id="6f0a9-188">これらの SSH サービスを無効にするには、開発者モードを無効にするだけです。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-188">To turn off the SSH services, simply disable Developer Mode.</span></span>  

### <a name="device-discovery"></a><span data-ttu-id="6f0a9-189">デバイスの検出</span><span class="sxs-lookup"><span data-stu-id="6f0a9-189">Device Discovery</span></span>

<span data-ttu-id="6f0a9-190">デバイスの検出を有効にすると、ネットワーク上の他のデバイスから mDNS を介してそのデバイスが表示できるようになります。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-190">When you enable device discovery, you are allowing your device to be visible to other devices on the network through mDNS.</span></span>  <span data-ttu-id="6f0a9-191">またこの機能では、対象デバイスをペアリングするための SSH PIN も取得できます。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-191">This feature also allows you to get the SSH PIN for pairing to this device.</span></span>  

![PIN のペアリング](images/devmode-pc-pinpair.PNG)

<span data-ttu-id="6f0a9-193">デバイスを展開ターゲットにする予定の場合にのみ、デバイスの検出を有効にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-193">You should enable device discovery only if you intend to make the device a deployment target.</span></span> <span data-ttu-id="6f0a9-194">たとえば、Device Portal を使用してアプリを電話に展開してテストする場合、その電話でデバイスの検出を有効にする必要がありますが、開発用 PC では不要です。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-194">For example, if you use Device Portal to deploy an app to a phone for testing, you need to enable device discovery on the phone, but not on your development PC.</span></span>

### <a name="error-reporting-mobile-only"></a><span data-ttu-id="6f0a9-195">エラー報告 (モバイルのみ)</span><span class="sxs-lookup"><span data-stu-id="6f0a9-195">Error reporting (Mobile only)</span></span>

<span data-ttu-id="6f0a9-196">電話に保存されるクラッシュ ダンプの数を指定するには、この値を設定します。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-196">Set this value to specify how many crash dumps are saved on your phone.</span></span>

<span data-ttu-id="6f0a9-197">電話でクラッシュ ダンプを収集することで、クラッシュの発生直後に重要なクラッシュ情報にすばやくアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-197">Collecting crash dumps on your phone gives you instant access to important crash information directly after the crash occurs.</span></span> <span data-ttu-id="6f0a9-198">開発者が署名したアプリに対してのみ、ダンプが収集されます。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-198">Dumps are collected for developer-signed apps only.</span></span> <span data-ttu-id="6f0a9-199">ダンプは、電話の記憶域の Documents\\Debug フォルダーにあります。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-199">You can find the dumps in your phone's storage in the Documents\\Debug folder.</span></span> <span data-ttu-id="6f0a9-200">ダンプ ファイルについて詳しくは、[ダンプ ファイルの使用](https://msdn.microsoft.com/library/d5zhxt22.aspx)に関するページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-200">For more info about dump files, see [Using dump files](https://msdn.microsoft.com/library/d5zhxt22.aspx).</span></span>

### <a name="optimizations-for-windows-explorer-remote-desktop-and-powershell-desktop-only"></a><span data-ttu-id="6f0a9-201">エクスプローラー、リモート デスクトップ、PowerShell の最適化 (デスクトップのみ)</span><span class="sxs-lookup"><span data-stu-id="6f0a9-201">Optimizations for Windows Explorer, Remote Desktop, and PowerShell (Desktop only)</span></span>

 <span data-ttu-id="6f0a9-202">デスクトップ デバイス ファミリの場合、**[開発者向け]** 設定ページには、開発タスク用 PC を最適化するために使用できる設定へのショートカットが備わっています。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-202">On the desktop device family, the **For developers** settings page has shortcuts to settings that you can use to optimize your PC for development tasks.</span></span> <span data-ttu-id="6f0a9-203">それぞれの設定で、チェック ボックスを選択して **[適用]** をクリックするか、**[設定の表示]** リンクをクリックして対象オプションの設定ページを開くことができます。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-203">For each setting, you can select the checkbox and click **Apply**, or click the **Show settings** link to open the settings page for that option.</span></span> 



**<span data-ttu-id="6f0a9-204">ヒント</span><span class="sxs-lookup"><span data-stu-id="6f0a9-204">Tip</span></span>**  
<span data-ttu-id="6f0a9-205">Windows 10 PC から Windows 10 モバイル デバイスへのアプリの展開に使用できるツールはいくつかあります。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-205">There are several tools you can use to deploy an app from a Windows 10 PC to a Windows 10 mobile device.</span></span> <span data-ttu-id="6f0a9-206">デバイスは両方ともワイヤード (有線) またはワイヤレスでネットワークの同じサブネットに接続されているか、または 2 台のデバイスが USB で接続されている必要があります。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-206">Both devices must be connected to the same subnet of the network by a wired or wireless connection, or they must be connected by USB.</span></span> <span data-ttu-id="6f0a9-207">どちらの方法を使用しても、アプリ パッケージ (.appx) のみがインストールされます。証明書はインストールされません。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-207">Either of the ways listed installs only the app package (.appx); they do not install certificates.</span></span>

-   <span data-ttu-id="6f0a9-208">Windows 10 アプリケーション展開 (WinAppDeployCmd) ツールを使います。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-208">Use the Windows 10 Application Deployment (WinAppDeployCmd) tool.</span></span> <span data-ttu-id="6f0a9-209">詳しくは、[WinAppDeployCmd ツール](http://msdn.microsoft.com/library/windows/apps/mt203806.aspx)に関するページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-209">Learn more about [the WinAppDeployCmd tool](http://msdn.microsoft.com/library/windows/apps/mt203806.aspx).</span></span>
-   <span data-ttu-id="6f0a9-210">Windows 10 バージョン 1511 以降では、[デバイス ポータル](../debug-test-perf/device-portal-desktop.md)を使用して、ブラウザーから、Windows 10 バージョン 1511 以降を実行しているモバイル デバイスに展開できます。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-210">Starting in Windows 10, Version 1511, you can use [Device Portal](../debug-test-perf/device-portal-desktop.md) to deploy from your browser to a mobile device running Windows 10, Version 1511 or later.</span></span> <span data-ttu-id="6f0a9-211">Device Portal の **[アプリ](../debug-test-perf/device-portal.md#apps)** ページを使用して、アプリ パッケージ (.appx) をアップロードしてデバイスにインストールします。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-211">Use the **[Apps](../debug-test-perf/device-portal.md#apps)** page in Device Portal to upload an app package (.appx) and install it on the device.</span></span>

## <a name="failure-to-install-developer-mode-package"></a><span data-ttu-id="6f0a9-212">開発者モード パッケージのインストール エラー</span><span class="sxs-lookup"><span data-stu-id="6f0a9-212">Failure to install Developer Mode package</span></span>
<span data-ttu-id="6f0a9-213">ネットワークや管理上の問題により、開発者モードが正しくインストールされないことがあります。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-213">Sometimes, due to network or administrative issues, Developer Mode won't install correctly.</span></span> <span data-ttu-id="6f0a9-214">開発者モード パッケージは、この PC への**リモート**展開に必要 (ブラウザーから Device Portal を使うか、またはデバイスの検出を使って SSH を有効化する) ですが、ローカル展開には必要ではありません。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-214">The Developer Mode package is required for **remote** deployment to this PC -- using Device Portal from a browser or Device Discovery to enable SSH -- but not for local development.</span></span>  <span data-ttu-id="6f0a9-215">これらの問題が発生した場合でも、Visual Studio を使用してローカルでアプリを展開できます。また、このデバイスから他のデバイスへ展開できます。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-215">Even if you encounter these issues, you can still deploy your app locally using Visual Studio, or from this device to another device.</span></span> 

<span data-ttu-id="6f0a9-216">これらの問題に対する回避策を検索するには、[既知の問題](https://social.msdn.microsoft.com/Forums/en-US/home?forum=Win10SDKToolsIssues&sort=relevancedesc&brandIgnore=True&searchTerm=%22device+portal%22)フォーラムをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-216">See the [Known Issues](https://social.msdn.microsoft.com/Forums/en-US/home?forum=Win10SDKToolsIssues&sort=relevancedesc&brandIgnore=True&searchTerm=%22device+portal%22) forum to find workarounds to these issues and more.</span></span> 

### <a name="failed-to-locate-the-package"></a><span data-ttu-id="6f0a9-217">パッケージ検索エラー</span><span class="sxs-lookup"><span data-stu-id="6f0a9-217">Failed to locate the package</span></span>

<span data-ttu-id="6f0a9-218">"Developer Mode package couldn’t be located in Windows Update.</span><span class="sxs-lookup"><span data-stu-id="6f0a9-218">"Developer Mode package couldn’t be located in Windows Update.</span></span> <span data-ttu-id="6f0a9-219">Error Code 0x80004005 Learn more"</span><span class="sxs-lookup"><span data-stu-id="6f0a9-219">Error Code 0x80004005 Learn more"</span></span>   

<span data-ttu-id="6f0a9-220">このエラーは、ネットワーク接続に問題がある場合、エンタープライズ設定になっている場合、またはパッケージが見つからない場合に発生することがあります。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-220">This error may occur due to a network connectivity problem, Enterprise settings, or the package may be missing.</span></span> 

<span data-ttu-id="6f0a9-221">この問題を解決するには:</span><span class="sxs-lookup"><span data-stu-id="6f0a9-221">To fix this issue:</span></span>

1. <span data-ttu-id="6f0a9-222">お使いのコンピューターがインターネットに接続されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-222">Ensure your computer is connected to the Internet.</span></span> 
2. <span data-ttu-id="6f0a9-223">ドメインに参加しているコンピューターの場合は、ネットワーク管理者に問い合わせます。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-223">If you are on a domain-joined computer, speak to your network administrator.</span></span> <span data-ttu-id="6f0a9-224">開発者モード パッケージは、すべてのオンデマンド機能と同様に、既定では WSUS でブロックされています。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-224">The Developer Mode package, like all Features on Demand,  is blocked by default in WSUS.</span></span> <span data-ttu-id="6f0a9-225">2.1.</span><span class="sxs-lookup"><span data-stu-id="6f0a9-225">2.1.</span></span> <span data-ttu-id="6f0a9-226">現在または以前のリリースで開発者モード パッケージのブロックを解除するためには、WSUS で次のサポート技術情報を許可する必要があります: 4016509, 3180030, 3197985。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-226">In order to unblock the Developer Mode package in the current and previous releases, the following KBs should be allowed in WSUS: 4016509, 3180030, 3197985</span></span>  
3. <span data-ttu-id="6f0a9-227">[設定] > [更新とセキュリティ] > [Windows Update] で Windows の更新プログラムをチェックします。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-227">Check for Windows updates in the Settings > Updates and Security > Windows Updates.</span></span>
4. <span data-ttu-id="6f0a9-228">[設定] > [システム] > [アプリと機能] > [オプション機能を管理する] に、Windows 開発者モード パッケージが存在することを確認します。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-228">Verify that the Windows Developer Mode package is present in Settings > System > Apps & Features > Manage optional features > Add a feature.</span></span> <span data-ttu-id="6f0a9-229">ない場合は、Windows はコンピューターの適切なパッケージを検出できません。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-229">If it is missing, Windows cannot find the correct package for your computer.</span></span> 

<span data-ttu-id="6f0a9-230">上記の手順のいずれかを実行後、修正を確認するために、開発者モードを無効にし、もう一度有効にします。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-230">After doing any of the above steps, disable and then re-enable Developer Mode to verify the fix.</span></span> 


### <a name="failed-to-install-the-package"></a><span data-ttu-id="6f0a9-231">パッケージ インストール エラー</span><span class="sxs-lookup"><span data-stu-id="6f0a9-231">Failed to install the package</span></span>

<span data-ttu-id="6f0a9-232">"Developer Mode package failed to install.</span><span class="sxs-lookup"><span data-stu-id="6f0a9-232">"Developer Mode package failed to install.</span></span> <span data-ttu-id="6f0a9-233">Error code 0x80004005  Learn more"</span><span class="sxs-lookup"><span data-stu-id="6f0a9-233">Error code 0x80004005  Learn more"</span></span>

<span data-ttu-id="6f0a9-234">このエラーは、Windows のビルドと開発者モード パッケージの間に互換性の問題がある場合に発生します。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-234">This error may occur due to incompatibilities between your build of Windows and the Developer Mode package.</span></span> 

<span data-ttu-id="6f0a9-235">この問題を解決するには:</span><span class="sxs-lookup"><span data-stu-id="6f0a9-235">To fix this issue:</span></span>

1. <span data-ttu-id="6f0a9-236">[設定] > [更新とセキュリティ] > [Windows Update] で Windows の更新プログラムをチェックします。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-236">Check for Windows updates in the Settings > Updates and Security > Windows Updates.</span></span>
2. <span data-ttu-id="6f0a9-237">すべての更新プログラムを確実に適用するために、コンピューターを再起動します。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-237">Reboot your computer to ensure all updates are applied.</span></span>


## <a name="use-group-policies-or-registry-keys-to-enable-a-device"></a><span data-ttu-id="6f0a9-238">グループ ポリシーまたはレジストリ キーを使用してデバイスを有効にする</span><span class="sxs-lookup"><span data-stu-id="6f0a9-238">Use group policies or registry keys to enable a device</span></span>

<span data-ttu-id="6f0a9-239">ほとんどの開発者のためには、設定アプリを使用して、デバイスでデバッグを有効にします。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-239">For most developers, you want to use the settings app to enable your device for debugging.</span></span> <span data-ttu-id="6f0a9-240">自動化テストなど特定のシナリオでは、他の方法を使用して、Windows 10 デスクトップ デバイスで開発を有効にできます。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-240">In certain scenarios, such as automated tests, you can use other ways to enable your Windows 10 desktop device for development.</span></span>

<span data-ttu-id="6f0a9-241">Windows 10 Home をお持ちでない場合は、gpedit.msc を使って、グループ ポリシーを設定してデバイスを有効にできます。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-241">You can use gpedit.msc to set the group policies to enable your device, unless you have Windows 10 Home.</span></span> <span data-ttu-id="6f0a9-242">Windows 10 Home をお持ちの場合は、regedit または PowerShell コマンドを使ってレジストリ キーを直接設定し、デバイスを有効にしてください。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-242">If you do have Windows 10 Home, you need to use regedit or PowerShell commands to set the registry keys directly to enable your device.</span></span>

**<span data-ttu-id="6f0a9-243">gpedit を使ってデバイスを有効にする</span><span class="sxs-lookup"><span data-stu-id="6f0a9-243">Use gpedit to enable your device</span></span>**

1.  <span data-ttu-id="6f0a9-244">**Gpedit.msc** を実行します。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-244">Run **Gpedit.msc**.</span></span>
2.  <span data-ttu-id="6f0a9-245">[ローカル コンピューター ポリシー] &gt; [コンピューターの構成] &gt; [管理用テンプレート] &gt; [Windows コンポーネント] &gt; [アプリ パッケージの展開] の順に移動します。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-245">Go to Local Computer Policy &gt; Computer Configuration &gt; Administrative Templates &gt; Windows Components &gt; App Package Deployment</span></span>
3.  <span data-ttu-id="6f0a9-246">サイドローディングを有効にするには、ポリシーを編集して次を有効にします。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-246">To enable sideloading, edit the policies to enable:</span></span>

    -   **<span data-ttu-id="6f0a9-247">信頼できるすべてのアプリのインストールを許可する</span><span class="sxs-lookup"><span data-stu-id="6f0a9-247">Allow all trusted apps to install</span></span>**

    - <span data-ttu-id="6f0a9-248">または -</span><span class="sxs-lookup"><span data-stu-id="6f0a9-248">OR -</span></span>

    <span data-ttu-id="6f0a9-249">開発者モードを有効にするには、ポリシーを編集して次の両方を有効にします。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-249">To enable developer mode, edit the policies to enable both:</span></span>

    -   **<span data-ttu-id="6f0a9-250">信頼できるすべてのアプリのインストールを許可する</span><span class="sxs-lookup"><span data-stu-id="6f0a9-250">Allow all trusted apps to install</span></span>**
    -   **<span data-ttu-id="6f0a9-251">Windows ストア アプリの開発と統合開発環境 (IDE) からのインストールを許可する</span><span class="sxs-lookup"><span data-stu-id="6f0a9-251">Allows development of Windows Store apps and installing them from an integrated development environment (IDE)</span></span>**

4.  <span data-ttu-id="6f0a9-252">コンピューターを再起動します。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-252">Reboot your machine.</span></span>

**<span data-ttu-id="6f0a9-253">regedit を使ってデバイスを有効にする</span><span class="sxs-lookup"><span data-stu-id="6f0a9-253">Use regedit to enable your device</span></span>**

1.  <span data-ttu-id="6f0a9-254">**regedit** を実行します。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-254">Run **regedit**.</span></span>
2.  <span data-ttu-id="6f0a9-255">サイドローディングを有効にするには、この DWORD の値を 1 に設定します。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-255">To enable sideloading, set the value of this DWORD to 1:</span></span>

    -   **<span data-ttu-id="6f0a9-256">HKLM\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\AppModelUnlock\\AllowAllTrustedApps</span><span class="sxs-lookup"><span data-stu-id="6f0a9-256">HKLM\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\AppModelUnlock\\AllowAllTrustedApps</span></span>**

    - <span data-ttu-id="6f0a9-257">または -</span><span class="sxs-lookup"><span data-stu-id="6f0a9-257">OR -</span></span>

    <span data-ttu-id="6f0a9-258">開発者モードを有効にするには、この DWORD の値を 1 に設定します。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-258">To enable developer mode, set the values of this DWORD to 1:</span></span>

    -   **<span data-ttu-id="6f0a9-259">HKLM\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\AppModelUnlock\\AllowDevelopmentWithoutDevLicense</span><span class="sxs-lookup"><span data-stu-id="6f0a9-259">HKLM\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\AppModelUnlock\\AllowDevelopmentWithoutDevLicense</span></span>**

**<span data-ttu-id="6f0a9-260">PowerShell を使ってデバイスを有効にする</span><span class="sxs-lookup"><span data-stu-id="6f0a9-260">Use PowerShell to enable your device</span></span>**

1.  <span data-ttu-id="6f0a9-261">管理者特権で PowerShell を実行します。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-261">Run PowerShell with administrator privileges.</span></span>
2.  <span data-ttu-id="6f0a9-262">サイドローディングを有効にするには、このコマンドを実行します。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-262">To enable sideloading, run this command:</span></span>

    -   **<span data-ttu-id="6f0a9-263">PS C:\\WINDOWS\\system32&gt; reg add "HKEY\_LOCAL\_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\AppModelUnlock" /t REG\_DWORD /f /v "AllowAllTrustedApps" /d "1"</span><span class="sxs-lookup"><span data-stu-id="6f0a9-263">PS C:\\WINDOWS\\system32&gt; reg add "HKEY\_LOCAL\_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\AppModelUnlock" /t REG\_DWORD /f /v "AllowAllTrustedApps" /d "1"</span></span>**

    - <span data-ttu-id="6f0a9-264">または -</span><span class="sxs-lookup"><span data-stu-id="6f0a9-264">OR -</span></span>

    <span data-ttu-id="6f0a9-265">開発者モードを有効にするには、このコマンドを実行します。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-265">To enable developer mode, run this command:</span></span>

    -   **<span data-ttu-id="6f0a9-266">PS C:\\WINDOWS\\system32&gt; reg add "HKEY\_LOCAL\_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\AppModelUnlock" /t REG\_DWORD /f /v "AllowDevelopmentWithoutDevLicense" /d "1"</span><span class="sxs-lookup"><span data-stu-id="6f0a9-266">PS C:\\WINDOWS\\system32&gt; reg add "HKEY\_LOCAL\_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\AppModelUnlock" /t REG\_DWORD /f /v "AllowDevelopmentWithoutDevLicense" /d "1"</span></span>**

## <a name="upgrade-your-device-from-windows-81-to-windows-10"></a><span data-ttu-id="6f0a9-267">Windows 8.1 から Windows 10 にデバイスをアップグレードする</span><span class="sxs-lookup"><span data-stu-id="6f0a9-267">Upgrade your device from Windows 8.1 to Windows 10</span></span>

<span data-ttu-id="6f0a9-268">Windows 8.1 デバイスでアプリを作成またはサイドローディングするときに、開発者用ライセンスをインストールする必要があります。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-268">When you create or sideload apps on your Windows 8.1 device, you have to install a developer license.</span></span> <span data-ttu-id="6f0a9-269">Windows 8.1 から Windows 10 にデバイスをアップグレードする場合は、この情報が維持されます。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-269">If you upgrade your device from Windows 8.1 to Windows 10, this information remains.</span></span> <span data-ttu-id="6f0a9-270">アップグレードした Windows 10 デバイスからこの情報を削除するには、次のコマンドを実行します。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-270">Run the following command to remove this information from your upgraded Windows 10 device.</span></span> <span data-ttu-id="6f0a9-271">Windows 8.1 から Windows 10 バージョン 1511 以降に直接アップグレードする場合、この手順は必要ありません。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-271">This step is not required if you upgrade directly from Windows 8.1 to Windows 10, Version 1511 or later.</span></span>

**<span data-ttu-id="6f0a9-272">開発者用ライセンスを登録解除するには</span><span class="sxs-lookup"><span data-stu-id="6f0a9-272">To unregister a developer license</span></span>**

1.  <span data-ttu-id="6f0a9-273">管理者特権で PowerShell を実行します。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-273">Run PowerShell with administrator privileges.</span></span>
2.  <span data-ttu-id="6f0a9-274">**unregister-windowsdeveloperlicense** コマンドを実行します。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-274">Run this command: **unregister-windowsdeveloperlicense**.</span></span>

<span data-ttu-id="6f0a9-275">その後、このトピックで説明されているように、開発用のデバイスを有効にする必要があります。これにより、このデバイスで開発を継続できます。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-275">After this you need to enable your device for development as described in this topic so that you can continue to develop on this device.</span></span> <span data-ttu-id="6f0a9-276">有効にしない場合、アプリをデバッグしたり、パッケージを作成しようとしたりすると、エラーが発生する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-276">If you don't do that, you might get an error when you debug your app, or you try to create a package for it.</span></span> <span data-ttu-id="6f0a9-277">このエラーの例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-277">Here is an example of this error:</span></span>

<span data-ttu-id="6f0a9-278">エラー: DEP0700: アプリケーションの登録に失敗しました。</span><span class="sxs-lookup"><span data-stu-id="6f0a9-278">Error : DEP0700 : Registration of the app failed.</span></span>

## <a name="see-also"></a><span data-ttu-id="6f0a9-279">関連項目</span><span class="sxs-lookup"><span data-stu-id="6f0a9-279">See Also</span></span>

* [<span data-ttu-id="6f0a9-280">初めてのアプリ</span><span class="sxs-lookup"><span data-stu-id="6f0a9-280">Your first app</span></span>](your-first-app.md)
* <span data-ttu-id="6f0a9-281">[Windows ストア アプリの公開](https://developer.microsoft.com/store/publish-apps)</span><span class="sxs-lookup"><span data-stu-id="6f0a9-281">[Publishing your Windows Store app](https://developer.microsoft.com/store/publish-apps).</span></span>
* [<span data-ttu-id="6f0a9-282">UWP アプリの開発に関するハウツー記事</span><span class="sxs-lookup"><span data-stu-id="6f0a9-282">How-to articles on developing UWP apps</span></span>](https://developer.microsoft.com/windows/apps/develop)
* [<span data-ttu-id="6f0a9-283">UWP 開発者向けコード サンプル</span><span class="sxs-lookup"><span data-stu-id="6f0a9-283">Code Samples for UWP developers</span></span>](https://developer.microsoft.com/windows/samples)
* [<span data-ttu-id="6f0a9-284">ユニバーサル Windows アプリとは?</span><span class="sxs-lookup"><span data-stu-id="6f0a9-284">What's a Universal Windows app?</span></span>](whats-a-uwp.md)
* [<span data-ttu-id="6f0a9-285">Windows アカウントのサインアップ</span><span class="sxs-lookup"><span data-stu-id="6f0a9-285">Sign up for Windows account</span></span>](sign-up.md)
