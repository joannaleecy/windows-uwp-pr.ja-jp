---
author: QuinnRadich
ms.assetid: 54973C62-9669-4988-934E-9273FB0425FD
title: デバイスを開発用に有効にする
description: 開発およびデバッグ用に Windows 10 デバイスを構成します。
keywords: 開発者用 Visual Studio での作業の開始, 開発者用ライセンス対応デバイス
ms.author: quradic
ms.date: 05/30/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.localizationpriority: medium
ms.openlocfilehash: ad817bbae2fb8b28b95095880aa1a65c391720f3
ms.sourcegitcommit: e6daa7ff878f2f0c7015aca9787e7f2730abcfbf
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/03/2018
ms.locfileid: "4314015"
---
# <a name="enable-your-device-for-development"></a><span data-ttu-id="e55d7-104">デバイスを開発用に有効にする</span><span class="sxs-lookup"><span data-stu-id="e55d7-104">Enable your device for development</span></span>

## <a name="activate-developer-mode-sideload-apps-and-access-other-developer-features"></a><span data-ttu-id="e55d7-105">開発者モードを有効にし、アプリのサイドローディングを行い、その他の開発者向け機能にアクセスする</span><span class="sxs-lookup"><span data-stu-id="e55d7-105">Activate Developer Mode, sideload apps and access other developer features</span></span>

![デバイスを開発用に有効にする](images/developer-poster.png)

<span data-ttu-id="e55d7-107">コンピューターをゲーム、Web 閲覧、メール、Office アプリなどの日々の通常の用途に使用している場合は、開発者モードを有効にする*必要はなく*、また有効にしないことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="e55d7-107">If you are using your computer for ordinary day-to-day activities such as games, web browsing, email or Office apps, you do *not* need to activate Developer Mode and in fact, you shouldn't activate it.</span></span> <span data-ttu-id="e55d7-108">その場合は、このページの情報の残りの部分は、関連のない情報ですので、</span><span class="sxs-lookup"><span data-stu-id="e55d7-108">The rest of the information on this page won't matter to you, and you can safely get back to whatever it is you were doing.</span></span> <span data-ttu-id="e55d7-109">元の作業にお戻りください。</span><span class="sxs-lookup"><span data-stu-id="e55d7-109">Thanks for stopping by!</span></span>

<span data-ttu-id="e55d7-110">コンピューターで初めて Visual Studio を使用してソフトウェアを作成する場合は、開発用 PC とコードのテスト用デバイスの両方で、開発者モードを有効にする*必要*があります。</span><span class="sxs-lookup"><span data-stu-id="e55d7-110">However, if you are writing software with Visual Studio on a computer for first time, you *will* need to enable Developer Mode on both the development PC, and on any devices you'll use to test your code.</span></span> <span data-ttu-id="e55d7-111">開発者モードが有効になっていない状態で UWP プロジェクトを開くと、**[開発者向け]** 設定ページが開くか、Visual Studio に次のダイアログ ボックスが表示されます。</span><span class="sxs-lookup"><span data-stu-id="e55d7-111">Opening a UWP project when Developer Mode is not enabled will either open the **For developers** settings page, or cause this dialog to appear in Visual Studio:</span></span>

![Visual Studio で表示される、開発者モードを有効にするためのダイアログ](images/latestenabledialog.png)

<span data-ttu-id="e55d7-113">このダイアログが表示された場合は、**[開発者向け設定]** をクリックして \*\*[開発者向け] \*\* 設定ページを開きます。</span><span class="sxs-lookup"><span data-stu-id="e55d7-113">When you see this dialog, click **settings for developers** to open the **For developers** settings page.</span></span>

> [!NOTE]
> <span data-ttu-id="e55d7-114">**[開発者向け]** ページにいつでも移動し、開発者モードの有効/無効を切り替えることができます。その場合には、タスク バーの Cortana 検索ボックスに「開発者向け」と入力するだけです。</span><span class="sxs-lookup"><span data-stu-id="e55d7-114">You can go to the **For developers** page at any time to enable or disable Developer Mode: simply enter "for developers" into the Cortana search box in the taskbar.</span></span>

## <a name="accessing-settings-for-developers"></a><span data-ttu-id="e55d7-115">開発者向け設定にアクセスする</span><span class="sxs-lookup"><span data-stu-id="e55d7-115">Accessing settings for Developers</span></span>

<span data-ttu-id="e55d7-116">開発者モードを有効にするには、またはその他の設定にアクセスするには:</span><span class="sxs-lookup"><span data-stu-id="e55d7-116">To enable Developer mode, or access other settings:</span></span>

1.  <span data-ttu-id="e55d7-117">**[開発者向け]** 設定ダイアログ ボックスで、必要なアクセスのレベルを選択します。</span><span class="sxs-lookup"><span data-stu-id="e55d7-117">From the **For developers** settings dialog, choose the level of access that you need.</span></span>
2.  <span data-ttu-id="e55d7-118">選択した設定の免責事項を読み、**[はい]** をクリックして変更を受け入れます。</span><span class="sxs-lookup"><span data-stu-id="e55d7-118">Read the disclaimer for the setting you chose, then click **Yes** to accept the change.</span></span>

> [!NOTE]
> <span data-ttu-id="e55d7-119">開発者モードを有効にするには、管理者のアクセス権が必要です。</span><span class="sxs-lookup"><span data-stu-id="e55d7-119">Enabling Developer mode requires administrator access.</span></span> <span data-ttu-id="e55d7-120">組織所有のデバイスの場合は、このオプションが無効になっていることもあります。</span><span class="sxs-lookup"><span data-stu-id="e55d7-120">If your device is owned by an organization, this option might be disabled.</span></span>

<span data-ttu-id="e55d7-121">デスクトップ デバイス ファミリの設定ページを以下に示します。</span><span class="sxs-lookup"><span data-stu-id="e55d7-121">Here's the settings page on the desktop device family:</span></span>

![[設定] に移動し、[更新とセキュリティ] を選び、[開発者向け] を選んでオプションを表示する](images/devmode-pc-options.png)

<span data-ttu-id="e55d7-123">モバイル デバイス ファミリの設定ページを以下に示します。</span><span class="sxs-lookup"><span data-stu-id="e55d7-123">Here's the settings page on the mobile device family:</span></span>

![電話の [設定] から [更新とセキュリティ] を選ぶ](images/devmode-mob.png)

## <a name="which-setting-should-i-choose-sideload-apps-or-developer-mode"></a><span data-ttu-id="e55d7-125">選ぶ必要がある設定: アプリのサイドローディングか開発者モードか</span><span class="sxs-lookup"><span data-stu-id="e55d7-125">Which setting should I choose: sideload apps or Developer Mode?</span></span>

 <span data-ttu-id="e55d7-126">デバイスでは、開発者モードを有効にすることも、サイドローディングのみを有効にすることもできます。</span><span class="sxs-lookup"><span data-stu-id="e55d7-126">You can enable a device for development, or just for sideloading.</span></span>

-   <span data-ttu-id="e55d7-127">*Microsoft Store アプリ*は、既定の設定です。</span><span class="sxs-lookup"><span data-stu-id="e55d7-127">*Microsoft Store apps* is the default setting.</span></span> <span data-ttu-id="e55d7-128">アプリの開発中でない場合や、組織から配布された特殊な内部アプリを使っている場合は、この設定を有効にしておきます。</span><span class="sxs-lookup"><span data-stu-id="e55d7-128">If you aren't developing apps, or using special internal apps issued by your company, keep this setting active.</span></span>
-   <span data-ttu-id="e55d7-129">*サイドローディング*では、Microsoft Store の認証を受けていないアプリをインストールし、実行やテストを行うことができます。</span><span class="sxs-lookup"><span data-stu-id="e55d7-129">*Sideloading* is installing and then running or testing an app that has not been certified by the Microsoft Store.</span></span> <span data-ttu-id="e55d7-130">たとえば、社内のみで使うアプリなどがあります。</span><span class="sxs-lookup"><span data-stu-id="e55d7-130">For example, an app that is internal to your company only.</span></span>
-   <span data-ttu-id="e55d7-131">*開発者モード*を使用すると、アプリをサイドロードし、Visual Studio からデバッグ モードでアプリを実行することもできます。</span><span class="sxs-lookup"><span data-stu-id="e55d7-131">*Developer mode* lets you sideload apps, and also run apps from Visual Studio in debug mode.</span></span> 

<span data-ttu-id="e55d7-132">既定では、Microsoft Store からのみユニバーサル Windows プラットフォーム (UWP) アプリをインストールできます。</span><span class="sxs-lookup"><span data-stu-id="e55d7-132">By default, you can only install Universal Windows Platform (UWP) apps from the Microsoft Store.</span></span> <span data-ttu-id="e55d7-133">開発者向け機能を使用するように設定を変更すると、デバイスのセキュリティ レベルが変わる場合があります。</span><span class="sxs-lookup"><span data-stu-id="e55d7-133">Changing these settings to use developer features can change the level of security of your device.</span></span> <span data-ttu-id="e55d7-134">未検証のソースからはアプリをインストールしないでください。</span><span class="sxs-lookup"><span data-stu-id="e55d7-134">You should not install apps from unverified sources.</span></span>

### <a name="sideload-apps"></a><span data-ttu-id="e55d7-135">アプリのサイドローディング</span><span class="sxs-lookup"><span data-stu-id="e55d7-135">Sideload apps</span></span>

<span data-ttu-id="e55d7-136">アプリのサイドローディング設定は、通常、Microsoft Store を使わずにカスタム アプリを管理対象デバイスにインストールする必要がある会社や学校によって使用されます。</span><span class="sxs-lookup"><span data-stu-id="e55d7-136">The Sideload apps setting is typically used by companies or schools that need to install custom apps on managed devices without going through the Microsoft Store.</span></span> <span data-ttu-id="e55d7-137">この場合、設定ページのイメージで以前に示したように、*UWP アプリ*設定を無効にするポリシーを組織が適用していることはよくあります。</span><span class="sxs-lookup"><span data-stu-id="e55d7-137">In this case, it's common for the organization to enforce a policy that disables the *UWP apps* setting, as shown previously in the image of the settings page.</span></span> <span data-ttu-id="e55d7-138">また、組織は、必要な証明書と、アプリをサイドローディングするインストール場所を提供します。</span><span class="sxs-lookup"><span data-stu-id="e55d7-138">The organization also provides the required certificate and install location to sideload apps.</span></span> <span data-ttu-id="e55d7-139">詳しくは、TechNet の記事「[Windows 10 でのアプリのサイド ローディング](https://technet.microsoft.com/library/mt269549.aspx)」と「[Microsoft Intune でのアプリ展開の開始](https://technet.microsoft.com/library/dn646955.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e55d7-139">For more info, see the TechNet articles [Sideload apps in Windows 10](https://technet.microsoft.com/library/mt269549.aspx) and [Get started with app deployment in Microsoft Intune](https://technet.microsoft.com/library/dn646955.aspx).</span></span>

<span data-ttu-id="e55d7-140">デバイス ファミリ固有の情報</span><span class="sxs-lookup"><span data-stu-id="e55d7-140">Device family specific info</span></span>

-   <span data-ttu-id="e55d7-141">デスクトップ デバイス ファミリの場合: パッケージと共に作成される Windows PowerShell スクリプトを実行して、アプリの実行に必要なアプリ パッケージ (.appx) と証明書をインストールできます ("Add-AppDevPackage.ps1")。</span><span class="sxs-lookup"><span data-stu-id="e55d7-141">On the desktop device family: You can install an app package (.appx) and any certificate that is needed to run the app by running the Windows PowerShell script that is created with the package ("Add-AppDevPackage.ps1").</span></span> <span data-ttu-id="e55d7-142">詳しくは、「[UWP アプリのパッケージ化](../packaging/packaging-uwp-apps.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e55d7-142">For more info, see [Packaging UWP apps](../packaging/packaging-uwp-apps.md).</span></span>

-   <span data-ttu-id="e55d7-143">モバイル デバイス ファミリの場合: 必要な証明書が既にインストールされている場合は、電子メールまたは SD カードで受け取ったファイルをタップして、.appx をインストールできます。</span><span class="sxs-lookup"><span data-stu-id="e55d7-143">On the mobile device family: If the required certificate is already installed, you can tap the file to install any .appx sent to you via email or on an SD card.</span></span>


<span data-ttu-id="e55d7-144">信頼できる証明書がないデバイスにアプリをインストールすることはできないため、**アプリのサイドローディング**は開発者モードよりも安全です。</span><span class="sxs-lookup"><span data-stu-id="e55d7-144">**Sideload apps** is a more secure option than Developer Mode because you cannot install apps on the device without a trusted certificate.</span></span>

> [!NOTE]
> <span data-ttu-id="e55d7-145">アプリをサイドローディングする場合は、信頼できるソースからのみアプリをインストールしてください。</span><span class="sxs-lookup"><span data-stu-id="e55d7-145">If you sideload apps, you should still only install apps from trusted sources.</span></span> <span data-ttu-id="e55d7-146">サイドローディングしたアプリ (Microsoft Store の認証を受けていないアプリ) をインストールする場合は、そのアプリをサイドローディングする際に必要なすべての権利をお客様が保持していること、およびそのアプリのインストールや実行の結果生じるすべての問題についてお客様が一切の責任を負うことに同意したものと見なされます。</span><span class="sxs-lookup"><span data-stu-id="e55d7-146">When you install a sideloaded app that has not been certified by the Microsoft Store, you are agreeing that you have obtained all rights necessary to sideload the app and that you are solely responsible for any harm that results from installing and running the app.</span></span> <span data-ttu-id="e55d7-147">この[プライバシーに関する声明](http://go.microsoft.com/fwlink/?LinkId=521839)の「Windows」&gt;「Microsoft Store」セクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e55d7-147">See the Windows &gt; Microsoft Store section of this [privacy statement](http://go.microsoft.com/fwlink/?LinkId=521839).</span></span>


### <a name="developer-mode"></a><span data-ttu-id="e55d7-148">開発者モード</span><span class="sxs-lookup"><span data-stu-id="e55d7-148">Developer Mode</span></span>

<span data-ttu-id="e55d7-149">開発者モードは、開発者用ライセンスに対する Windows 8.1 の要件に置き換わるものです。</span><span class="sxs-lookup"><span data-stu-id="e55d7-149">Developer Mode replaces the Windows 8.1 requirements for a developer license.</span></span>  <span data-ttu-id="e55d7-150">サイドローディングだけでなく、開発者モードの設定でデバッグおよび追加の展開オプションを有効にできます。</span><span class="sxs-lookup"><span data-stu-id="e55d7-150">In addition to sideloading, the Developer Mode setting enables debugging and additional deployment options.</span></span> <span data-ttu-id="e55d7-151">デバイスを展開先にできるようにする SSH サービスの開始も含まれます。</span><span class="sxs-lookup"><span data-stu-id="e55d7-151">This includes starting an SSH service to allow this device to be deployed to.</span></span> <span data-ttu-id="e55d7-152">このサービスを停止するためには、開発者モードを無効にしなければなりません。</span><span class="sxs-lookup"><span data-stu-id="e55d7-152">In order to stop this service, you have to disable Developer Mode.</span></span>

<span data-ttu-id="e55d7-153">デスクトップで開発者モードを有効にすると、次のような機能のパッケージがインストールされます。</span><span class="sxs-lookup"><span data-stu-id="e55d7-153">When you enable Developer Mode on desktop, a package of features is installed that includes:</span></span>
- <span data-ttu-id="e55d7-154">Windows デバイス ポータル。</span><span class="sxs-lookup"><span data-stu-id="e55d7-154">Windows Device Portal.</span></span> <span data-ttu-id="e55d7-155">デバイス ポータルが有効になり、ファイアウォール規則が構成されるのは、**[デバイス ポータルを有効にする]** オプションがオンの場合のみです。</span><span class="sxs-lookup"><span data-stu-id="e55d7-155">Device Portal is enabled and firewall rules are configured for it only when the **Enable Device Portal** option is turned on.</span></span>
- <span data-ttu-id="e55d7-156">アプリのリモート インストールを可能にする SSH サービスのファイアウォール規則がインストールされ、構成されます。</span><span class="sxs-lookup"><span data-stu-id="e55d7-156">Installs, and configures firewall rules for SSH services that allow remote installation of apps.</span></span> <span data-ttu-id="e55d7-157">**[デバイスの検出]** を有効にすると、SSH サーバーが有効になります。</span><span class="sxs-lookup"><span data-stu-id="e55d7-157">Enabling **Device Discovery** will turn on the SSH server.</span></span>


## <a name="additional-developer-mode-features"></a><span data-ttu-id="e55d7-158">追加の開発者モード機能</span><span class="sxs-lookup"><span data-stu-id="e55d7-158">Additional Developer Mode features</span></span>

<span data-ttu-id="e55d7-159">各デバイス ファミリには、開発者向けの追加機能が用意されている場合があります。</span><span class="sxs-lookup"><span data-stu-id="e55d7-159">For each device family, additional developer features might be available.</span></span> <span data-ttu-id="e55d7-160">これらの機能は、デバイスで開発者モードが有効になっている場合にのみ使用でき、OS バージョンによって異なる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="e55d7-160">These features are available only when Developer Mode is enabled on the device, and might vary depending on your OS version.</span></span>

<span data-ttu-id="e55d7-161">この画像は、Windows 10 の開発者向け機能を示しています。</span><span class="sxs-lookup"><span data-stu-id="e55d7-161">This image shows developer features for Windows 10:</span></span>

![開発者モードのオプション](images/devmode-mob-options.png) 

### <a name="span-iddevice-discovery-and-pairingspandevice-portal"></a><span data-ttu-id="e55d7-163"><span id="device-discovery-and-pairing"></span>デバイス ポータル</span><span class="sxs-lookup"><span data-stu-id="e55d7-163"><span id="device-discovery-and-pairing"></span>Device Portal</span></span>

<span data-ttu-id="e55d7-164">Device Portal について詳しくは、「[Windows Device Portal の概要](../debug-test-perf/device-portal.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e55d7-164">To learn more about Device Portal, see [Windows Device Portal overview](../debug-test-perf/device-portal.md).</span></span>

<span data-ttu-id="e55d7-165">デバイス固有のセットアップ手順については、以下をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e55d7-165">For device specific setup instructions, see:</span></span>
- [<span data-ttu-id="e55d7-166">デスクトップ用 Device Portal</span><span class="sxs-lookup"><span data-stu-id="e55d7-166">Device Portal for Desktop</span></span>](https://msdn.microsoft.com/windows/uwp/debug-test-perf/device-portal-desktop)
- [<span data-ttu-id="e55d7-167">HoloLens 用 Device Portal</span><span class="sxs-lookup"><span data-stu-id="e55d7-167">Device Portal for HoloLens</span></span>](https://developer.microsoft.com/windows/holographic/using_the_windows_device_portal)
- [<span data-ttu-id="e55d7-168">IoT 用 Device Portal</span><span class="sxs-lookup"><span data-stu-id="e55d7-168">Device Portal for IoT</span></span>](https://developer.microsoft.com/windows/iot/docs/DevicePortal)
- [<span data-ttu-id="e55d7-169">モバイル用 Device Portal</span><span class="sxs-lookup"><span data-stu-id="e55d7-169">Device Portal for Mobile</span></span>](../debug-test-perf/device-portal-mobile.md)
- [<span data-ttu-id="e55d7-170">Xbox 用 Device Portal</span><span class="sxs-lookup"><span data-stu-id="e55d7-170">Device Portal for Xbox</span></span>](../debug-test-perf/device-portal-xbox.md)

<span data-ttu-id="e55d7-171">開発者モードの有効化または Device Portal について問題が発生した場合には、「[既知の問題](https://social.msdn.microsoft.com/Forums/en-US/home?forum=Win10SDKToolsIssues&sort=relevancedesc&brandIgnore=True&searchTerm=%22device+portal%22)」フォーラムで問題の回避策を見つけるか、または「[開発者モード パッケージのインストール エラー](#failure-to-install-developer-mode-package)」で、開発者モード パッケージをブロック解除するための WSUS サポート技術情報の追加の情報をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e55d7-171">If you encounter problems enabling Developer Mode or Device Portal, see the [Known Issues](https://social.msdn.microsoft.com/Forums/en-US/home?forum=Win10SDKToolsIssues&sort=relevancedesc&brandIgnore=True&searchTerm=%22device+portal%22) forum to find workarounds for these issues, or visit [Failure to install the Developer Mode package](#failure-to-install-developer-mode-package) for additional details and which WSUS KBs to allow in order to unblock the Developer Mode package.</span></span> 

### <a name="ssh"></a><span data-ttu-id="e55d7-172">SSH</span><span class="sxs-lookup"><span data-stu-id="e55d7-172">SSH</span></span>

<span data-ttu-id="e55d7-173">デバイスでデバイスの検出を有効にすると、SSH サービスが有効になります。</span><span class="sxs-lookup"><span data-stu-id="e55d7-173">SSH services are enabled when you enable Device Discovery on your device.</span></span>  <span data-ttu-id="e55d7-174">デバイスが UWP アプリケーションのリモート展開ターゲットの場合にこれを使用します。</span><span class="sxs-lookup"><span data-stu-id="e55d7-174">This is used when your device is a remote deployment target for UWP applications.</span></span>   <span data-ttu-id="e55d7-175">サービスの名前は、「SSH Server Broker」と「SSH Server Proxy」です。</span><span class="sxs-lookup"><span data-stu-id="e55d7-175">The names of the services are 'SSH Server Broker' and 'SSH Server Proxy'.</span></span>

> [!NOTE]
> <span data-ttu-id="e55d7-176">これは Microsoft の OpenSSH の実装ではありません。それは [GitHub](https://github.com/PowerShell/Win32-OpenSSH) にあります。</span><span class="sxs-lookup"><span data-stu-id="e55d7-176">This is not Microsoft's OpenSSH implementation, which you can find on [GitHub](https://github.com/PowerShell/Win32-OpenSSH).</span></span>  

<span data-ttu-id="e55d7-177">SSH サービスを利用するには、デバイスの検出を有効にして PIN のペアリングを許可できます。</span><span class="sxs-lookup"><span data-stu-id="e55d7-177">In order to take advantage of the SSH services, you can enable device discovery to allow pin pairing.</span></span> <span data-ttu-id="e55d7-178">別の SSH サービスを実行する予定の場合、別のポートにセットアップするか、開発者モードの SSH サービスを無効にできます。</span><span class="sxs-lookup"><span data-stu-id="e55d7-178">If you intend to run another SSH service, you can set this up on a different port or turn off the Developer Mode SSH services.</span></span> <span data-ttu-id="e55d7-179">SSH サービスを無効にするには、デバイスの検出を無効にします。</span><span class="sxs-lookup"><span data-stu-id="e55d7-179">To turn off the SSH services, turn off Device Discovery.</span></span>  

<span data-ttu-id="e55d7-180">SSH ログインは、認証用のパスワードを受け入れる "DevToolsUser" アカウントを通じて行われます。</span><span class="sxs-lookup"><span data-stu-id="e55d7-180">SSH login is done via the "DevToolsUser" account, which accepts a password for authentication.</span></span>  <span data-ttu-id="e55d7-181">このパスワードは、デバイスの検出の [ペアリング] ボタンを押した後にデバイスに表示される PIN であり、PIN が表示されている間のみ有効です。</span><span class="sxs-lookup"><span data-stu-id="e55d7-181">This password is the PIN displayed on the device after pressing the device discovery "Pair" button, and is only valid while the PIN is displayed.</span></span>  <span data-ttu-id="e55d7-182">Visual Studio からルーズ ファイル配置がインストールされる DevelopmentFiles フォルダーを手動で管理するために、SFTP サブシステムも有効になります。</span><span class="sxs-lookup"><span data-stu-id="e55d7-182">An SFTP subsystem is also enabled, for manual management of the DevelopmentFiles folder where loose file deployments are installed from Visual Studio.</span></span> 

#### <a name="caveats-for-ssh-usage"></a><span data-ttu-id="e55d7-183">SSH の使用に関する注意事項</span><span class="sxs-lookup"><span data-stu-id="e55d7-183">Caveats for SSH usage</span></span>
<span data-ttu-id="e55d7-184">Windows で使用される既存の SSH サーバーはまだプロトコルに準拠していないため、SFTP または SSH クライアントを使うには特殊な構成が必要になることがあります。</span><span class="sxs-lookup"><span data-stu-id="e55d7-184">The existing SSH server used in Windows is not yet protocol compliant, so using an SFTP or SSH client may require special configuration.</span></span>  <span data-ttu-id="e55d7-185">具体的には、SFTP サブシステムはバージョン 3 以下で実行されるため、中継するクライアントが古いサーバーを使うように構成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e55d7-185">In particular, the SFTP subsystem runs at version 3 or less, so any connecting client should be configured to expect an old server.</span></span>  <span data-ttu-id="e55d7-186">古いデバイスの SSH サーバーは、公開キー認証として `ssh-dss` が使用されます。これは、OpenSSH によって非推奨となりました。</span><span class="sxs-lookup"><span data-stu-id="e55d7-186">The SSH server on older devices uses `ssh-dss` for public key authentication, which OpenSSH has deprecated.</span></span>  <span data-ttu-id="e55d7-187">このようなデバイスに接続するには、`ssh-dss` を受け入れるように SSH クライアントを手動で構成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e55d7-187">To connect to such devices the SSH client must be manually configured to accept `ssh-dss`.</span></span>  

### <a name="device-discovery"></a><span data-ttu-id="e55d7-188">デバイスの検出</span><span class="sxs-lookup"><span data-stu-id="e55d7-188">Device Discovery</span></span>

<span data-ttu-id="e55d7-189">デバイスの検出を有効にすると、ネットワーク上の他のデバイスから mDNS を介してそのデバイスが表示できるようになります。</span><span class="sxs-lookup"><span data-stu-id="e55d7-189">When you enable device discovery, you are allowing your device to be visible to other devices on the network through mDNS.</span></span>  <span data-ttu-id="e55d7-190">この機能では、デバイスの検出が有効になると一度だけ表示される [ペアリング] ボタンを押すことで、このデバイスをペアリングするための SSH PIN を取得することもできます。</span><span class="sxs-lookup"><span data-stu-id="e55d7-190">This feature also allows you to get the SSH PIN for pairing to this device by pressing the "Pair" button exposed once device discovery is enabled.</span></span>  <span data-ttu-id="e55d7-191">この PIN プロンプトは、そのデバイスをターゲットとする最初の Visual Studio 展開を完了するために画面に表示する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e55d7-191">This PIN prompt must be displayed on the screen in order to complete your first Visual Studio deployment targeting the device.</span></span>  

![PIN のペアリング](images/devmode-pc-pinpair.PNG)

<span data-ttu-id="e55d7-193">デバイスを展開ターゲットにする予定の場合にのみ、デバイスの検出を有効にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="e55d7-193">You should enable device discovery only if you intend to make the device a deployment target.</span></span> <span data-ttu-id="e55d7-194">たとえば、Device Portal を使用してアプリを電話に展開してテストする場合、その電話でデバイスの検出を有効にする必要がありますが、開発用 PC では不要です。</span><span class="sxs-lookup"><span data-stu-id="e55d7-194">For example, if you use Device Portal to deploy an app to a phone for testing, you need to enable device discovery on the phone, but not on your development PC.</span></span>

### <a name="optimizations-for-windows-explorer-remote-desktop-and-powershell-desktop-only"></a><span data-ttu-id="e55d7-195">エクスプローラー、リモート デスクトップ、PowerShell の最適化 (デスクトップのみ)</span><span class="sxs-lookup"><span data-stu-id="e55d7-195">Optimizations for Windows Explorer, Remote Desktop, and PowerShell (Desktop only)</span></span>

 <span data-ttu-id="e55d7-196">デスクトップ デバイス ファミリの場合、**[開発者向け]** 設定ページには、開発タスク用 PC を最適化するために使用できる設定へのショートカットが備わっています。</span><span class="sxs-lookup"><span data-stu-id="e55d7-196">On the desktop device family, the **For developers** settings page has shortcuts to settings that you can use to optimize your PC for development tasks.</span></span> <span data-ttu-id="e55d7-197">それぞれの設定で、チェック ボックスを選択して **[適用]** をクリックするか、**[設定の表示]** リンクをクリックして対象オプションの設定ページを開くことができます。</span><span class="sxs-lookup"><span data-stu-id="e55d7-197">For each setting, you can select the checkbox and click **Apply**, or click the **Show settings** link to open the settings page for that option.</span></span> 


## <a name="notes"></a><span data-ttu-id="e55d7-198">注意</span><span class="sxs-lookup"><span data-stu-id="e55d7-198">Notes</span></span>
<span data-ttu-id="e55d7-199">以前のバージョンの Windows 10 Mobile では、クラッシュ ダンプ オプションが [開発者向け設定] メニューに存在していました。</span><span class="sxs-lookup"><span data-stu-id="e55d7-199">In early versions of Windows 10 Mobile, a Crash Dumps option was present in the Developer Settings menu.</span></span>  <span data-ttu-id="e55d7-200">これは、USB 経由だけではなくリモートでも使うことができるように[デバイス ポータル](../debug-test-perf/device-portal.md)に移動しました。</span><span class="sxs-lookup"><span data-stu-id="e55d7-200">This has been moved to [Device Portal](../debug-test-perf/device-portal.md) so that it can be used remotely rather than just over USB.</span></span>  

<span data-ttu-id="e55d7-201">Windows 10 PC から Windows 10 デバイスへのアプリの展開に使用できるツールはいくつかあります。</span><span class="sxs-lookup"><span data-stu-id="e55d7-201">There are several tools you can use to deploy an app from a Windows 10 PC to a Windows 10 device.</span></span> <span data-ttu-id="e55d7-202">デバイスは両方ともワイヤード (有線) またはワイヤレスでネットワークの同じサブネットに接続されているか、または 2 台のデバイスが USB で接続されている必要があります。</span><span class="sxs-lookup"><span data-stu-id="e55d7-202">Both devices must be connected to the same subnet of the network by a wired or wireless connection, or they must be connected by USB.</span></span> <span data-ttu-id="e55d7-203">どちらの方法を使用しても、アプリ パッケージ (.appx/.appxbundle) のみがインストールされます。証明書はインストールされません。</span><span class="sxs-lookup"><span data-stu-id="e55d7-203">Both of the ways listed install only the app package (.appx/.appxbundle); they do not install certificates.</span></span>

-   <span data-ttu-id="e55d7-204">Windows 10 アプリケーション展開 (WinAppDeployCmd) ツールを使います。</span><span class="sxs-lookup"><span data-stu-id="e55d7-204">Use the Windows 10 Application Deployment (WinAppDeployCmd) tool.</span></span> <span data-ttu-id="e55d7-205">詳しくは、[WinAppDeployCmd ツール](http://msdn.microsoft.com/library/windows/apps/mt203806.aspx)に関するページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e55d7-205">Learn more about [the WinAppDeployCmd tool](http://msdn.microsoft.com/library/windows/apps/mt203806.aspx).</span></span>
-   <span data-ttu-id="e55d7-206">[デバイス ポータル](../debug-test-perf/device-portal.md)を使用して、ブラウザーから、Windows 10 バージョン 1511 以降を実行しているモバイル デバイスに展開できます。</span><span class="sxs-lookup"><span data-stu-id="e55d7-206">You can use [Device Portal](../debug-test-perf/device-portal.md) to deploy from your browser to a mobile device running Windows 10, Version 1511 or later.</span></span> <span data-ttu-id="e55d7-207">Device Portal の **[アプリ](../debug-test-perf/device-portal.md#apps-manager)** ページを使用して、アプリ パッケージ (.appx) をアップロードしてデバイスにインストールします。</span><span class="sxs-lookup"><span data-stu-id="e55d7-207">Use the **[Apps](../debug-test-perf/device-portal.md#apps-manager)** page in Device Portal to upload an app package (.appx) and install it on the device.</span></span>

## <a name="failure-to-install-developer-mode-package"></a><span data-ttu-id="e55d7-208">開発者モード パッケージのインストール エラー</span><span class="sxs-lookup"><span data-stu-id="e55d7-208">Failure to install Developer Mode package</span></span>
<span data-ttu-id="e55d7-209">ネットワークや管理上の問題により、開発者モードが正しくインストールされないことがあります。</span><span class="sxs-lookup"><span data-stu-id="e55d7-209">Sometimes, due to network or administrative issues, Developer Mode won't install correctly.</span></span> <span data-ttu-id="e55d7-210">開発者モード パッケージは、この PC への**リモート**展開に必要 (ブラウザーから Device Portal を使うか、またはデバイスの検出を使って SSH を有効化する) ですが、ローカル展開には必要ではありません。</span><span class="sxs-lookup"><span data-stu-id="e55d7-210">The Developer Mode package is required for **remote** deployment to this PC -- using Device Portal from a browser or Device Discovery to enable SSH -- but not for local development.</span></span>  <span data-ttu-id="e55d7-211">これらの問題が発生した場合でも、Visual Studio を使用してローカルでアプリを展開できます。また、このデバイスから他のデバイスへ展開できます。</span><span class="sxs-lookup"><span data-stu-id="e55d7-211">Even if you encounter these issues, you can still deploy your app locally using Visual Studio, or from this device to another device.</span></span> 

<span data-ttu-id="e55d7-212">これらの問題に対する回避策を検索するには、[既知の問題](https://social.msdn.microsoft.com/Forums/en-US/home?forum=Win10SDKToolsIssues&sort=relevancedesc&brandIgnore=True&searchTerm=%22device+portal%22)フォーラムをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e55d7-212">See the [Known Issues](https://social.msdn.microsoft.com/Forums/en-US/home?forum=Win10SDKToolsIssues&sort=relevancedesc&brandIgnore=True&searchTerm=%22device+portal%22) forum to find workarounds to these issues and more.</span></span> 

> [!NOTE]
> <span data-ttu-id="e55d7-213">開発者モードが正しくインストールしない場合、要求をフィードバックをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="e55d7-213">If Developer Mode doesn't install correctly, we encourage you to file a feedback request.</span></span> <span data-ttu-id="e55d7-214">**フィードバック Hub**アプリでは、**新しいフィードバックの追加**を選択し、**開発者向けプラットフォーム**カテゴリとサブカテゴリ**開発者モード**を選択します。</span><span class="sxs-lookup"><span data-stu-id="e55d7-214">In the **Feedback Hub** app, select **Add new feedback**, and choose the **Developer Platform** category and the **Developer Mode** subcategory.</span></span> <span data-ttu-id="e55d7-215">フィードバックの送信は、Microsoft が発生した問題を解決するに役立ちます。</span><span class="sxs-lookup"><span data-stu-id="e55d7-215">Submitting feedback will help Microsoft resolve the issue you encountered.</span></span>

### <a name="failed-to-locate-the-package"></a><span data-ttu-id="e55d7-216">パッケージ検索エラー</span><span class="sxs-lookup"><span data-stu-id="e55d7-216">Failed to locate the package</span></span>

<span data-ttu-id="e55d7-217">"Developer Mode package couldn’t be located in Windows Update.</span><span class="sxs-lookup"><span data-stu-id="e55d7-217">"Developer Mode package couldn’t be located in Windows Update.</span></span> <span data-ttu-id="e55d7-218">Error Code 0x80004005 Learn more"</span><span class="sxs-lookup"><span data-stu-id="e55d7-218">Error Code 0x80004005 Learn more"</span></span>   

<span data-ttu-id="e55d7-219">このエラーは、ネットワーク接続に問題がある場合、エンタープライズ設定になっている場合、またはパッケージが見つからない場合に発生することがあります。</span><span class="sxs-lookup"><span data-stu-id="e55d7-219">This error may occur due to a network connectivity problem, Enterprise settings, or the package may be missing.</span></span> 

<span data-ttu-id="e55d7-220">この問題を解決するには:</span><span class="sxs-lookup"><span data-stu-id="e55d7-220">To fix this issue:</span></span>

1. <span data-ttu-id="e55d7-221">お使いのコンピューターがインターネットに接続されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="e55d7-221">Ensure your computer is connected to the Internet.</span></span> 
2. <span data-ttu-id="e55d7-222">ドメインに参加しているコンピューターの場合は、ネットワーク管理者に問い合わせます。</span><span class="sxs-lookup"><span data-stu-id="e55d7-222">If you are on a domain-joined computer, speak to your network administrator.</span></span> <span data-ttu-id="e55d7-223">開発者モード パッケージは、すべてのオンデマンド機能と同様に、既定では WSUS でブロックされています。</span><span class="sxs-lookup"><span data-stu-id="e55d7-223">The Developer Mode package, like all Features on Demand,  is blocked by default in WSUS.</span></span> <span data-ttu-id="e55d7-224">2.1.</span><span class="sxs-lookup"><span data-stu-id="e55d7-224">2.1.</span></span> <span data-ttu-id="e55d7-225">現在または以前のリリースで開発者モード パッケージのブロックを解除するためには、WSUS で次のサポート技術情報を許可する必要があります: 4016509, 3180030, 3197985。</span><span class="sxs-lookup"><span data-stu-id="e55d7-225">In order to unblock the Developer Mode package in the current and previous releases, the following KBs should be allowed in WSUS: 4016509, 3180030, 3197985</span></span>  
3. <span data-ttu-id="e55d7-226">[設定] > [更新とセキュリティ] > [Windows Update] で Windows の更新プログラムをチェックします。</span><span class="sxs-lookup"><span data-stu-id="e55d7-226">Check for Windows updates in the Settings > Updates and Security > Windows Updates.</span></span>
4. <span data-ttu-id="e55d7-227">[設定] > [システム] > [アプリと機能] > [オプション機能を管理する] に、Windows 開発者モード パッケージが存在することを確認します。</span><span class="sxs-lookup"><span data-stu-id="e55d7-227">Verify that the Windows Developer Mode package is present in Settings > System > Apps & Features > Manage optional features > Add a feature.</span></span> <span data-ttu-id="e55d7-228">ない場合は、Windows はコンピューターの適切なパッケージを検出できません。</span><span class="sxs-lookup"><span data-stu-id="e55d7-228">If it is missing, Windows cannot find the correct package for your computer.</span></span> 

<span data-ttu-id="e55d7-229">上記の手順のいずれかを実行後、修正を確認するために、開発者モードを無効にし、もう一度有効にします。</span><span class="sxs-lookup"><span data-stu-id="e55d7-229">After doing any of the above steps, disable and then re-enable Developer Mode to verify the fix.</span></span> 


### <a name="failed-to-install-the-package"></a><span data-ttu-id="e55d7-230">パッケージ インストール エラー</span><span class="sxs-lookup"><span data-stu-id="e55d7-230">Failed to install the package</span></span>

<span data-ttu-id="e55d7-231">"Developer Mode package failed to install.</span><span class="sxs-lookup"><span data-stu-id="e55d7-231">"Developer Mode package failed to install.</span></span> <span data-ttu-id="e55d7-232">Error code 0x80004005  Learn more"</span><span class="sxs-lookup"><span data-stu-id="e55d7-232">Error code 0x80004005  Learn more"</span></span>

<span data-ttu-id="e55d7-233">このエラーは、Windows のビルドと開発者モード パッケージの間に互換性の問題がある場合に発生します。</span><span class="sxs-lookup"><span data-stu-id="e55d7-233">This error may occur due to incompatibilities between your build of Windows and the Developer Mode package.</span></span> 

<span data-ttu-id="e55d7-234">この問題を解決するには:</span><span class="sxs-lookup"><span data-stu-id="e55d7-234">To fix this issue:</span></span>

1. <span data-ttu-id="e55d7-235">[設定] > [更新プログラムとセキュリティ] > [Windows の更新プログラム] で Windows の更新プログラムをチェックします。</span><span class="sxs-lookup"><span data-stu-id="e55d7-235">Check for Windows updates in the Settings > Updates and Security > Windows Updates.</span></span>
2. <span data-ttu-id="e55d7-236">すべての更新プログラムを確実に適用するために、コンピューターを再起動します。</span><span class="sxs-lookup"><span data-stu-id="e55d7-236">Reboot your computer to ensure all updates are applied.</span></span>


## <a name="use-group-policies-or-registry-keys-to-enable-a-device"></a><span data-ttu-id="e55d7-237">グループ ポリシーまたはレジストリ キーを使用してデバイスを有効にする</span><span class="sxs-lookup"><span data-stu-id="e55d7-237">Use group policies or registry keys to enable a device</span></span>

<span data-ttu-id="e55d7-238">ほとんどの開発者のためには、設定アプリを使用して、デバイスでデバッグを有効にします。</span><span class="sxs-lookup"><span data-stu-id="e55d7-238">For most developers, you want to use the settings app to enable your device for debugging.</span></span> <span data-ttu-id="e55d7-239">自動化テストなど特定のシナリオでは、他の方法を使用して、Windows 10 デスクトップ デバイスで開発を有効にできます。</span><span class="sxs-lookup"><span data-stu-id="e55d7-239">In certain scenarios, such as automated tests, you can use other ways to enable your Windows 10 desktop device for development.</span></span>  <span data-ttu-id="e55d7-240">これらの手順では SSH サーバーが有効になったり、リモート展開およびデバッグ用のデバイスを対象にできるようになったりはしない点に注意してください。</span><span class="sxs-lookup"><span data-stu-id="e55d7-240">Note that these steps will not enable the SSH server or allow the device to be targeted for remote deployment and debugging.</span></span> 

<span data-ttu-id="e55d7-241">Windows 10 Home をお持ちでない場合は、gpedit.msc を使って、グループ ポリシーを設定してデバイスを有効にできます。</span><span class="sxs-lookup"><span data-stu-id="e55d7-241">You can use gpedit.msc to set the group policies to enable your device, unless you have Windows 10 Home.</span></span> <span data-ttu-id="e55d7-242">Windows 10 Home をお持ちの場合は、regedit または PowerShell コマンドを使ってレジストリ キーを直接設定し、デバイスを有効にしてください。</span><span class="sxs-lookup"><span data-stu-id="e55d7-242">If you do have Windows 10 Home, you need to use regedit or PowerShell commands to set the registry keys directly to enable your device.</span></span>

**<span data-ttu-id="e55d7-243">gpedit を使ってデバイスを有効にする</span><span class="sxs-lookup"><span data-stu-id="e55d7-243">Use gpedit to enable your device</span></span>**

1.  <span data-ttu-id="e55d7-244">**Gpedit.msc** を実行します。</span><span class="sxs-lookup"><span data-stu-id="e55d7-244">Run **Gpedit.msc**.</span></span>
2.  <span data-ttu-id="e55d7-245">[ローカル コンピューター ポリシー] &gt; [コンピューターの構成] &gt; [管理用テンプレート] &gt; [Windows コンポーネント] &gt; [アプリ パッケージの展開] の順に移動します。</span><span class="sxs-lookup"><span data-stu-id="e55d7-245">Go to Local Computer Policy &gt; Computer Configuration &gt; Administrative Templates &gt; Windows Components &gt; App Package Deployment</span></span>
3.  <span data-ttu-id="e55d7-246">サイドローディングを有効にするには、ポリシーを編集して次を有効にします。</span><span class="sxs-lookup"><span data-stu-id="e55d7-246">To enable sideloading, edit the policies to enable:</span></span>

    -   **<span data-ttu-id="e55d7-247">信頼できるすべてのアプリのインストールを許可する</span><span class="sxs-lookup"><span data-stu-id="e55d7-247">Allow all trusted apps to install</span></span>**

    - <span data-ttu-id="e55d7-248">または -</span><span class="sxs-lookup"><span data-stu-id="e55d7-248">OR -</span></span>

    <span data-ttu-id="e55d7-249">開発者モードを有効にするには、ポリシーを編集して次の両方を有効にします。</span><span class="sxs-lookup"><span data-stu-id="e55d7-249">To enable developer mode, edit the policies to enable both:</span></span>

    -   **<span data-ttu-id="e55d7-250">信頼できるすべてのアプリのインストールを許可する</span><span class="sxs-lookup"><span data-stu-id="e55d7-250">Allow all trusted apps to install</span></span>**
    -   **<span data-ttu-id="e55d7-251">UWP アプリの開発と統合開発環境 (IDE) からのインストールを許可する</span><span class="sxs-lookup"><span data-stu-id="e55d7-251">Allows development of UWP apps and installing them from an integrated development environment (IDE)</span></span>**

4.  <span data-ttu-id="e55d7-252">コンピューターを再起動します。</span><span class="sxs-lookup"><span data-stu-id="e55d7-252">Reboot your machine.</span></span>

**<span data-ttu-id="e55d7-253">regedit を使ってデバイスを有効にする</span><span class="sxs-lookup"><span data-stu-id="e55d7-253">Use regedit to enable your device</span></span>**

1.  <span data-ttu-id="e55d7-254">**regedit** を実行します。</span><span class="sxs-lookup"><span data-stu-id="e55d7-254">Run **regedit**.</span></span>
2.  <span data-ttu-id="e55d7-255">サイドローディングを有効にするには、この DWORD の値を 1 に設定します。</span><span class="sxs-lookup"><span data-stu-id="e55d7-255">To enable sideloading, set the value of this DWORD to 1:</span></span>

    -   **<span data-ttu-id="e55d7-256">HKLM\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\AppModelUnlock\\AllowAllTrustedApps</span><span class="sxs-lookup"><span data-stu-id="e55d7-256">HKLM\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\AppModelUnlock\\AllowAllTrustedApps</span></span>**

    - <span data-ttu-id="e55d7-257">または -</span><span class="sxs-lookup"><span data-stu-id="e55d7-257">OR -</span></span>

    <span data-ttu-id="e55d7-258">開発者モードを有効にするには、この DWORD の値を 1 に設定します。</span><span class="sxs-lookup"><span data-stu-id="e55d7-258">To enable developer mode, set the values of this DWORD to 1:</span></span>

    -   **<span data-ttu-id="e55d7-259">HKLM\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\AppModelUnlock\\AllowDevelopmentWithoutDevLicense</span><span class="sxs-lookup"><span data-stu-id="e55d7-259">HKLM\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\AppModelUnlock\\AllowDevelopmentWithoutDevLicense</span></span>**

**<span data-ttu-id="e55d7-260">PowerShell を使ってデバイスを有効にする</span><span class="sxs-lookup"><span data-stu-id="e55d7-260">Use PowerShell to enable your device</span></span>**

1.  <span data-ttu-id="e55d7-261">管理者特権で PowerShell を実行します。</span><span class="sxs-lookup"><span data-stu-id="e55d7-261">Run PowerShell with administrator privileges.</span></span>
2.  <span data-ttu-id="e55d7-262">サイドローディングを有効にするには、このコマンドを実行します。</span><span class="sxs-lookup"><span data-stu-id="e55d7-262">To enable sideloading, run this command:</span></span>

    -   **<span data-ttu-id="e55d7-263">PS C:\\WINDOWS\\system32&gt; reg add "HKEY\_LOCAL\_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\AppModelUnlock" /t REG\_DWORD /f /v "AllowAllTrustedApps" /d "1"</span><span class="sxs-lookup"><span data-stu-id="e55d7-263">PS C:\\WINDOWS\\system32&gt; reg add "HKEY\_LOCAL\_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\AppModelUnlock" /t REG\_DWORD /f /v "AllowAllTrustedApps" /d "1"</span></span>**

    - <span data-ttu-id="e55d7-264">または -</span><span class="sxs-lookup"><span data-stu-id="e55d7-264">OR -</span></span>

    <span data-ttu-id="e55d7-265">開発者モードを有効にするには、このコマンドを実行します。</span><span class="sxs-lookup"><span data-stu-id="e55d7-265">To enable developer mode, run this command:</span></span>

    -   **<span data-ttu-id="e55d7-266">PS C:\\WINDOWS\\system32&gt; reg add "HKEY\_LOCAL\_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\AppModelUnlock" /t REG\_DWORD /f /v "AllowDevelopmentWithoutDevLicense" /d "1"</span><span class="sxs-lookup"><span data-stu-id="e55d7-266">PS C:\\WINDOWS\\system32&gt; reg add "HKEY\_LOCAL\_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\AppModelUnlock" /t REG\_DWORD /f /v "AllowDevelopmentWithoutDevLicense" /d "1"</span></span>**

## <a name="upgrade-your-device-from-windows-81-to-windows-10"></a><span data-ttu-id="e55d7-267">Windows 8.1 から Windows 10 にデバイスをアップグレードする</span><span class="sxs-lookup"><span data-stu-id="e55d7-267">Upgrade your device from Windows 8.1 to Windows 10</span></span>

<span data-ttu-id="e55d7-268">Windows 8.1 デバイスでアプリを作成またはサイドローディングするときに、開発者用ライセンスをインストールする必要があります。</span><span class="sxs-lookup"><span data-stu-id="e55d7-268">When you create or sideload apps on your Windows 8.1 device, you have to install a developer license.</span></span> <span data-ttu-id="e55d7-269">Windows 8.1 から Windows 10 にデバイスをアップグレードする場合は、この情報が維持されます。</span><span class="sxs-lookup"><span data-stu-id="e55d7-269">If you upgrade your device from Windows 8.1 to Windows 10, this information remains.</span></span> <span data-ttu-id="e55d7-270">アップグレードした Windows 10 デバイスからこの情報を削除するには、次のコマンドを実行します。</span><span class="sxs-lookup"><span data-stu-id="e55d7-270">Run the following command to remove this information from your upgraded Windows 10 device.</span></span> <span data-ttu-id="e55d7-271">Windows 8.1 から Windows 10 バージョン 1511 以降に直接アップグレードする場合、この手順は必要ありません。</span><span class="sxs-lookup"><span data-stu-id="e55d7-271">This step is not required if you upgrade directly from Windows 8.1 to Windows 10, Version 1511 or later.</span></span>

**<span data-ttu-id="e55d7-272">開発者用ライセンスを登録解除するには</span><span class="sxs-lookup"><span data-stu-id="e55d7-272">To unregister a developer license</span></span>**

1.  <span data-ttu-id="e55d7-273">管理者特権で PowerShell を実行します。</span><span class="sxs-lookup"><span data-stu-id="e55d7-273">Run PowerShell with administrator privileges.</span></span>
2.  <span data-ttu-id="e55d7-274">**unregister-windowsdeveloperlicense** コマンドを実行します。</span><span class="sxs-lookup"><span data-stu-id="e55d7-274">Run this command: **unregister-windowsdeveloperlicense**.</span></span>

<span data-ttu-id="e55d7-275">その後、このトピックで説明されているように、開発用のデバイスを有効にする必要があります。これにより、このデバイスで開発を継続できます。</span><span class="sxs-lookup"><span data-stu-id="e55d7-275">After this you need to enable your device for development as described in this topic so that you can continue to develop on this device.</span></span> <span data-ttu-id="e55d7-276">有効にしない場合、アプリをデバッグしたり、パッケージを作成しようとしたりすると、エラーが発生する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="e55d7-276">If you don't do that, you might get an error when you debug your app, or you try to create a package for it.</span></span> <span data-ttu-id="e55d7-277">このエラーの例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="e55d7-277">Here is an example of this error:</span></span>

<span data-ttu-id="e55d7-278">エラー: DEP0700: アプリケーションの登録に失敗しました。</span><span class="sxs-lookup"><span data-stu-id="e55d7-278">Error : DEP0700 : Registration of the app failed.</span></span>

## <a name="see-also"></a><span data-ttu-id="e55d7-279">関連項目</span><span class="sxs-lookup"><span data-stu-id="e55d7-279">See Also</span></span>

* [<span data-ttu-id="e55d7-280">初めてのアプリ</span><span class="sxs-lookup"><span data-stu-id="e55d7-280">Your first app</span></span>](your-first-app.md)
* <span data-ttu-id="e55d7-281">[UWP アプリを公開する](https://developer.microsoft.com/store/publish-apps)</span><span class="sxs-lookup"><span data-stu-id="e55d7-281">[Publishing your UWP app](https://developer.microsoft.com/store/publish-apps).</span></span>
* [<span data-ttu-id="e55d7-282">UWP アプリの開発に関するハウツー記事</span><span class="sxs-lookup"><span data-stu-id="e55d7-282">How-to articles on developing UWP apps</span></span>](https://developer.microsoft.com/windows/apps/develop)
* [<span data-ttu-id="e55d7-283">UWP 開発者向けコード サンプル</span><span class="sxs-lookup"><span data-stu-id="e55d7-283">Code Samples for UWP developers</span></span>](https://developer.microsoft.com/windows/samples)
* [<span data-ttu-id="e55d7-284">UWP アプリとは</span><span class="sxs-lookup"><span data-stu-id="e55d7-284">What's a UWP app?</span></span>](universal-application-platform-guide.md)
* [<span data-ttu-id="e55d7-285">Windows アカウントのサインアップ</span><span class="sxs-lookup"><span data-stu-id="e55d7-285">Sign up for Windows account</span></span>](sign-up.md)
