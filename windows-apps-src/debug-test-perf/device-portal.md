---
ms.assetid: 60fc48dd-91a9-4dd6-a116-9292a7c1f3be
title: Windows Device Portal の概要
description: Windows Device Portal で、ネットワーク経由でリモートから、または USB 接続によって、デバイスの構成と管理を行うための方法を説明します。
ms.date: 02/19/2019
ms.topic: article
keywords: windows 10、uwp、デバイス ポータル
ms.localizationpriority: medium
ms.openlocfilehash: ba3c0a393cc5eb536de43539df48f43bb98d8ef1
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57611937"
---
# <a name="windows-device-portal-overview"></a><span data-ttu-id="d2411-104">Windows Device Portal の概要</span><span class="sxs-lookup"><span data-stu-id="d2411-104">Windows Device Portal overview</span></span>

<span data-ttu-id="d2411-105">Windows Device Portal では、ネットワーク経由でリモートから、または USB 接続によって、デバイスの構成と管理を行えます。</span><span class="sxs-lookup"><span data-stu-id="d2411-105">The Windows Device Portal lets you configure and manage your device remotely over a network or USB connection.</span></span> <span data-ttu-id="d2411-106">また、トラブルシューティングを行うし、Windows デバイスのリアルタイムのパフォーマンスの表示に役立つ高度な診断ツールも提供します。</span><span class="sxs-lookup"><span data-stu-id="d2411-106">It also provides advanced diagnostic tools to help you troubleshoot and view the real-time performance of your Windows device.</span></span>

<span data-ttu-id="d2411-107">Windows Device Portal は、PC 上の web ブラウザーからに接続できるデバイスで web サーバーです。</span><span class="sxs-lookup"><span data-stu-id="d2411-107">Windows Device Portal is a web server on your device that you can connect to from a web browser on a PC.</span></span> <span data-ttu-id="d2411-108">デバイスでは、web ブラウザーには、するはそのデバイスのブラウザーでローカルに接続もできます。</span><span class="sxs-lookup"><span data-stu-id="d2411-108">If your device has a web browser, you can also connect locally with the browser on that device.</span></span>

<span data-ttu-id="d2411-109">Windows Device Portal は各デバイス ファミリで使用できますが、機能とセットアップは、各デバイスの要件に基づいて変化します。</span><span class="sxs-lookup"><span data-stu-id="d2411-109">Windows Device Portal is available on each device family, but features and setup vary based on each device's requirements.</span></span> <span data-ttu-id="d2411-110">ここでは、Device Portal の一般的な説明と、各デバイス ファミリに関するさらに詳細な情報が掲載されている記事へのリンクを示します。</span><span class="sxs-lookup"><span data-stu-id="d2411-110">This article provides a general description of Device Portal and links to articles with more specific information for each device family.</span></span>

<span data-ttu-id="d2411-111">Windows Device Portal の機能が実装されている[REST Api](device-portal-api-core.md)ことは、データにアクセスし、デバイスの管理をプログラム的に直接使用することができます。</span><span class="sxs-lookup"><span data-stu-id="d2411-111">The functionality of the Windows Device Portal is implemented with [REST APIs](device-portal-api-core.md) that you can use directly to access data and control your device programmatically.</span></span>

## <a name="setup"></a><span data-ttu-id="d2411-112">セットアップ</span><span class="sxs-lookup"><span data-stu-id="d2411-112">Setup</span></span>

<span data-ttu-id="d2411-113">Device Portal への接続の具体的な手順はデバイスによって異なりますが、どのデバイスでも次の一般的な手順が必要です。</span><span class="sxs-lookup"><span data-stu-id="d2411-113">Each device has specific instructions for connecting to Device Portal, but each requires these general steps:</span></span>
1. <span data-ttu-id="d2411-114">(構成、設定アプリで) デバイスで開発者モードとデバイスのポータルを有効にします。</span><span class="sxs-lookup"><span data-stu-id="d2411-114">Enable Developer Mode and Device Portal on your device (configured in the Settings app).</span></span>
2. <span data-ttu-id="d2411-115">ローカル ネットワーク経由または USB デバイスと PC を接続します。</span><span class="sxs-lookup"><span data-stu-id="d2411-115">Connect your device and PC through a local network or with USB.</span></span>
3. <span data-ttu-id="d2411-116">ブラウザーでデバイス ポータルのページに移動します。</span><span class="sxs-lookup"><span data-stu-id="d2411-116">Navigate to the Device Portal page in your browser.</span></span> <span data-ttu-id="d2411-117">次の表は、ポートと各デバイス ファミリで使用されるプロトコルを示します。</span><span class="sxs-lookup"><span data-stu-id="d2411-117">This table shows the ports and protocols used by each device family.</span></span>

<span data-ttu-id="d2411-118">デバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="d2411-118">Device family</span></span> | <span data-ttu-id="d2411-119">既定でオンになっているか</span><span class="sxs-lookup"><span data-stu-id="d2411-119">On by default?</span></span> | <span data-ttu-id="d2411-120">HTTP</span><span class="sxs-lookup"><span data-stu-id="d2411-120">HTTP</span></span> | <span data-ttu-id="d2411-121">HTTPS</span><span class="sxs-lookup"><span data-stu-id="d2411-121">HTTPS</span></span> | <span data-ttu-id="d2411-122">USB</span><span class="sxs-lookup"><span data-stu-id="d2411-122">USB</span></span>
--------------|----------------|------|-------|----
<span data-ttu-id="d2411-123">HoloLens</span><span class="sxs-lookup"><span data-stu-id="d2411-123">HoloLens</span></span> | <span data-ttu-id="d2411-124">開発者モードでオン</span><span class="sxs-lookup"><span data-stu-id="d2411-124">Yes, in Dev Mode</span></span> | <span data-ttu-id="d2411-125">80 (既定)</span><span class="sxs-lookup"><span data-stu-id="d2411-125">80 (default)</span></span> | <span data-ttu-id="d2411-126">443 (既定)</span><span class="sxs-lookup"><span data-stu-id="d2411-126">443 (default)</span></span> | http://127.0.0.1:10080
<span data-ttu-id="d2411-127">IoT</span><span class="sxs-lookup"><span data-stu-id="d2411-127">IoT</span></span> | <span data-ttu-id="d2411-128">開発者モードでオン</span><span class="sxs-lookup"><span data-stu-id="d2411-128">Yes, in Dev Mode</span></span> | <span data-ttu-id="d2411-129">8080</span><span class="sxs-lookup"><span data-stu-id="d2411-129">8080</span></span> | <span data-ttu-id="d2411-130">レジストリ キーで有効化する</span><span class="sxs-lookup"><span data-stu-id="d2411-130">Enable via regkey</span></span> | <span data-ttu-id="d2411-131">なし</span><span class="sxs-lookup"><span data-stu-id="d2411-131">N/A</span></span>
<span data-ttu-id="d2411-132">Xbox</span><span class="sxs-lookup"><span data-stu-id="d2411-132">Xbox</span></span> | <span data-ttu-id="d2411-133">開発者モードで有効化する</span><span class="sxs-lookup"><span data-stu-id="d2411-133">Enable inside Dev Mode</span></span> | <span data-ttu-id="d2411-134">Disabled</span><span class="sxs-lookup"><span data-stu-id="d2411-134">Disabled</span></span> | <span data-ttu-id="d2411-135">11443</span><span class="sxs-lookup"><span data-stu-id="d2411-135">11443</span></span> | <span data-ttu-id="d2411-136">なし</span><span class="sxs-lookup"><span data-stu-id="d2411-136">N/A</span></span>
<span data-ttu-id="d2411-137">Desktop</span><span class="sxs-lookup"><span data-stu-id="d2411-137">Desktop</span></span>| <span data-ttu-id="d2411-138">開発者モードで有効化する</span><span class="sxs-lookup"><span data-stu-id="d2411-138">Enable inside Dev Mode</span></span> | <span data-ttu-id="d2411-139">50080\*</span><span class="sxs-lookup"><span data-stu-id="d2411-139">50080\*</span></span> | <span data-ttu-id="d2411-140">50043\*</span><span class="sxs-lookup"><span data-stu-id="d2411-140">50043\*</span></span> | <span data-ttu-id="d2411-141">なし</span><span class="sxs-lookup"><span data-stu-id="d2411-141">N/A</span></span>
<span data-ttu-id="d2411-142">Phone</span><span class="sxs-lookup"><span data-stu-id="d2411-142">Phone</span></span> | <span data-ttu-id="d2411-143">開発者モードで有効化する</span><span class="sxs-lookup"><span data-stu-id="d2411-143">Enable inside Dev Mode</span></span> | <span data-ttu-id="d2411-144">80</span><span class="sxs-lookup"><span data-stu-id="d2411-144">80</span></span>| <span data-ttu-id="d2411-145">443</span><span class="sxs-lookup"><span data-stu-id="d2411-145">443</span></span> | http://127.0.0.1:10080

<span data-ttu-id="d2411-146">\* これは常に場合は、デスクトップ上のデバイスのポータルが短期の範囲内のポートを要求として (> 50,000) デバイスで既存のポートのクレームとの競合を回避します。</span><span class="sxs-lookup"><span data-stu-id="d2411-146">\* This is not always the case, as Device Portal on desktop claims ports in the ephemeral range (>50,000) to prevent collisions with existing port claims on the device.</span></span> <span data-ttu-id="d2411-147">詳しくは、デスクトップに関する「[ポート番号を設定する](device-portal-desktop.md#registry-based-configuration-for-device-portal)」のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d2411-147">To learn more, see the [Port Settings](device-portal-desktop.md#registry-based-configuration-for-device-portal) section for desktop.</span></span>  

<span data-ttu-id="d2411-148">デバイス固有のセットアップ手順については、以下をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d2411-148">For device-specific setup instructions, see:</span></span>
- [<span data-ttu-id="d2411-149">HoloLens デバイス ポータル</span><span class="sxs-lookup"><span data-stu-id="d2411-149">Device Portal for HoloLens</span></span>](https://docs.microsoft.com/windows/uwp/debug-test-perf/device-portal-hololens)
- [<span data-ttu-id="d2411-150">IoT のデバイス ポータル</span><span class="sxs-lookup"><span data-stu-id="d2411-150">Device Portal for IoT</span></span>](https://go.microsoft.com/fwlink/?LinkID=616499)
- [<span data-ttu-id="d2411-151">モバイル デバイスのポータル</span><span class="sxs-lookup"><span data-stu-id="d2411-151">Device Portal for Mobile</span></span>](device-portal-mobile.md)
- [<span data-ttu-id="d2411-152">Xbox 用のデバイス ポータル</span><span class="sxs-lookup"><span data-stu-id="d2411-152">Device Portal for Xbox</span></span>](device-portal-xbox.md)
- [<span data-ttu-id="d2411-153">デスクトップ用のデバイス ポータル</span><span class="sxs-lookup"><span data-stu-id="d2411-153">Device Portal for Desktop</span></span>](device-portal-desktop.md#set-up-device-portal-on-windows-desktop)

## <a name="features"></a><span data-ttu-id="d2411-154">機能</span><span class="sxs-lookup"><span data-stu-id="d2411-154">Features</span></span>

### <a name="toolbar-and-navigation"></a><span data-ttu-id="d2411-155">ツールバーとナビゲーション</span><span class="sxs-lookup"><span data-stu-id="d2411-155">Toolbar and navigation</span></span>

<span data-ttu-id="d2411-156">ページの上部にあるツールバーでは、一般的に使用される機能へのアクセスを提供します。</span><span class="sxs-lookup"><span data-stu-id="d2411-156">The toolbar at the top of the page provides access to commonly used features.</span></span>
- <span data-ttu-id="d2411-157">**Power**:電源オプション のアクセス。</span><span class="sxs-lookup"><span data-stu-id="d2411-157">**Power**: Access power options.</span></span>
  - <span data-ttu-id="d2411-158">**シャット ダウン**:デバイスをオフにします。</span><span class="sxs-lookup"><span data-stu-id="d2411-158">**Shutdown**: Turns off the device.</span></span>
  - <span data-ttu-id="d2411-159">**再起動**:デバイスの電源が循環します。</span><span class="sxs-lookup"><span data-stu-id="d2411-159">**Restart**: Cycles power on the device.</span></span>
- <span data-ttu-id="d2411-160">**ヘルプ**:ヘルプ ページが開きます。</span><span class="sxs-lookup"><span data-stu-id="d2411-160">**Help**: Opens the help page.</span></span>

<span data-ttu-id="d2411-161">ページの左側にあるナビゲーション ウィンドウのリンクを使用して、デバイスの管理と監視に利用可能なツールに移動します。</span><span class="sxs-lookup"><span data-stu-id="d2411-161">Use the links in the navigation pane along the left side of the page to navigate to the available management and monitoring tools for your device.</span></span>

<span data-ttu-id="d2411-162">ここでは、デバイス ファミリに共通するツールについて説明します。</span><span class="sxs-lookup"><span data-stu-id="d2411-162">Tools that are common across device families are described here.</span></span> <span data-ttu-id="d2411-163">デバイスによってはその他のオプションを利用できる場合があります。</span><span class="sxs-lookup"><span data-stu-id="d2411-163">Other options might be available depending on the device.</span></span> <span data-ttu-id="d2411-164">詳細については、デバイスの種類の特定のページを参照してください。</span><span class="sxs-lookup"><span data-stu-id="d2411-164">For more info, see the specific page for your device type.</span></span>

### <a name="apps-manager"></a><span data-ttu-id="d2411-165">アプリ マネージャー</span><span class="sxs-lookup"><span data-stu-id="d2411-165">Apps manager</span></span>

<span data-ttu-id="d2411-166">Apps manager には、インストール/アンインストールし、アプリの管理機能をパッケージ化し、ホスト デバイスにバンドルします。</span><span class="sxs-lookup"><span data-stu-id="d2411-166">The Apps manager provides install/uninstall and management functionality for app packages and bundles on the host device.</span></span>

![デバイスのポータル アプリはマネージャー ページ](images/device-portal/WDP_AppsManager2.png)

* <span data-ttu-id="d2411-168">**アプリを展開する**:ローカルからのパッケージ アプリ、ネットワーク、または web ホストを展開し、ネットワーク共有から圧縮しないファイルを登録します。</span><span class="sxs-lookup"><span data-stu-id="d2411-168">**Deploy apps**: Deploy packaged apps from local, network, or web hosts and register loose files from network shares.</span></span>
* <span data-ttu-id="d2411-169">**アプリがインストールされている**:ドロップダウン メニューを使用して、削除するか、デバイスにインストールされているアプリを起動します。</span><span class="sxs-lookup"><span data-stu-id="d2411-169">**Installed apps**: Use the dropdown menu to remove or start apps that are installed on the device.</span></span>
* <span data-ttu-id="d2411-170">**アプリを実行している**:現在実行中、必要に応じてそれらを閉じるアプリに関する情報を取得します。</span><span class="sxs-lookup"><span data-stu-id="d2411-170">**Running apps**: Get information about the apps that are currently running and close them as necessary.</span></span>

#### <a name="install-sideload-an-app"></a><span data-ttu-id="d2411-171">(サイドロード) アプリをインストールします。</span><span class="sxs-lookup"><span data-stu-id="d2411-171">Install (sideload) an app</span></span>

<span data-ttu-id="d2411-172">Windows Device Portal を使用した開発中にアプリをサイドロードすることができます。</span><span class="sxs-lookup"><span data-stu-id="d2411-172">You can sideload apps during development using Windows Device Portal:</span></span>

1.  <span data-ttu-id="d2411-173">アプリ パッケージを作成した場合は、デバイス上にリモートでインストールできます。</span><span class="sxs-lookup"><span data-stu-id="d2411-173">When you've created an app package, you can remotely install it onto your device.</span></span> <span data-ttu-id="d2411-174">Visual Studio でビルドすると、出力フォルダーが生成されます。</span><span class="sxs-lookup"><span data-stu-id="d2411-174">After you build it in Visual Studio, an output folder is generated.</span></span>

  ![アプリのインストール](images/device-portal/iot-installapp0.png)

2. <span data-ttu-id="d2411-176">Windows Device Portal のに移動、 **Apps manager**ページ。</span><span class="sxs-lookup"><span data-stu-id="d2411-176">In Windows Device Portal, navigate to the **Apps manager** page.</span></span>

3. <span data-ttu-id="d2411-177">**アプリを展開する**セクションで、**ローカル ストレージ**します。</span><span class="sxs-lookup"><span data-stu-id="d2411-177">In the **Deploy apps** section, select **Local Storage**.</span></span>

4. <span data-ttu-id="d2411-178">**アプリケーション パッケージを選択して**を選択します**ファイルの選択**サイドロードするアプリ パッケージを参照します。</span><span class="sxs-lookup"><span data-stu-id="d2411-178">Under **Select the application package**, select **Choose File** and browse to the app package that you want to sideload.</span></span>

5. <span data-ttu-id="d2411-179">**アプリ パッケージの署名に使用される証明書の選択ファイル (.cer)** を選択します**Choose File**し、そのアプリのパッケージに関連付けられている証明書を参照します。</span><span class="sxs-lookup"><span data-stu-id="d2411-179">Under **Select certificate file (.cer) used to sign app package**, select **Choose File** and browse to the certificate associated with that app package.</span></span>

6. <span data-ttu-id="d2411-180">省略可能なインストールやアプリのインストールと共にフレームワーク パッケージを選択すると、それぞれのボックスをチェック**次**して選択します。</span><span class="sxs-lookup"><span data-stu-id="d2411-180">Check the respective boxes if you want to install optional or framework packages along with the app installation, and select **Next** to choose them.</span></span>

7. <span data-ttu-id="d2411-181">選択**インストール**のインストールを開始します。</span><span class="sxs-lookup"><span data-stu-id="d2411-181">Select **Install** to initiate the installation.</span></span>

8. <span data-ttu-id="d2411-182">デバイスが S のモードで Windows 10 を実行しているが初めてデバイスの特定の証明書がインストールされている場合、デバイスを再起動します。</span><span class="sxs-lookup"><span data-stu-id="d2411-182">If the device is running Windows 10 in S mode, and it is the first time that the given certificate has been installed on the device, restart the device.</span></span>

#### <a name="install-a-certificate"></a><span data-ttu-id="d2411-183">証明書をインストールします。</span><span class="sxs-lookup"><span data-stu-id="d2411-183">Install a certificate</span></span>

<span data-ttu-id="d2411-184">または、Windows Device Portal を使用して証明書をインストールし、他の手段でアプリをインストールします。</span><span class="sxs-lookup"><span data-stu-id="d2411-184">Alternatively, you can install the certificate via Windows Device Portal, and install the app through other means:</span></span>

1. <span data-ttu-id="d2411-185">Windows Device Portal のに移動、 **Apps manager**ページ。</span><span class="sxs-lookup"><span data-stu-id="d2411-185">In Windows Device Portal, navigate to the **Apps manager** page.</span></span>

2. <span data-ttu-id="d2411-186">**アプリを展開する**セクションで、**証明書のインストール**します。</span><span class="sxs-lookup"><span data-stu-id="d2411-186">In the **Deploy apps** section, select **Install Certificate**.</span></span>

3. <span data-ttu-id="d2411-187">**アプリ パッケージの署名に使用される証明書の選択ファイル (.cer)** を選択します**ファイルの選択**サイドロードするアプリ パッケージに関連付けられている証明書を参照します。</span><span class="sxs-lookup"><span data-stu-id="d2411-187">Under **Select certificate file (.cer) used to sign an app package**, select **Choose File** and browse to the certificate associated with the app package that you want to sideload.</span></span>

4. <span data-ttu-id="d2411-188">選択**インストール**のインストールを開始します。</span><span class="sxs-lookup"><span data-stu-id="d2411-188">Select **Install** to initiate the installation.</span></span>

5. <span data-ttu-id="d2411-189">デバイスが S のモードで Windows 10 を実行しているが初めてデバイスの特定の証明書がインストールされている場合、デバイスを再起動します。</span><span class="sxs-lookup"><span data-stu-id="d2411-189">If the device is running Windows 10 in S mode, and it is the first time that the given certificate has been installed on the device, restart the device.</span></span>

#### <a name="uninstall-an-app"></a><span data-ttu-id="d2411-190">アプリをアンインストールする</span><span class="sxs-lookup"><span data-stu-id="d2411-190">Uninstall an app</span></span>
1.  <span data-ttu-id="d2411-191">アプリが実行中でないことを確認します。</span><span class="sxs-lookup"><span data-stu-id="d2411-191">Ensure that your app is not running.</span></span> 
2.  <span data-ttu-id="d2411-192">場合を参照してください。**アプリを実行している**して閉じます。</span><span class="sxs-lookup"><span data-stu-id="d2411-192">If it is, go to **Running apps** and close it.</span></span> <span data-ttu-id="d2411-193">場合は、アプリの実行中をアンインストールしようとすると、問題が生じるため、アプリを再インストールしようとしたときにします。</span><span class="sxs-lookup"><span data-stu-id="d2411-193">If you attempt to uninstall while the app is running, it will cause issues when you attempt to reinstall the app.</span></span> 
3.  <span data-ttu-id="d2411-194">ドロップダウン リストとクリックからアプリを選択**削除**します。</span><span class="sxs-lookup"><span data-stu-id="d2411-194">Select the app from the dropdown and click **Remove**.</span></span>

### <a name="running-processes"></a><span data-ttu-id="d2411-195">実行中のプロセス</span><span class="sxs-lookup"><span data-stu-id="d2411-195">Running processes</span></span>

<span data-ttu-id="d2411-196">このページには、ホスト デバイスで現在実行されているプロセスに関する詳細情報が表示されます。</span><span class="sxs-lookup"><span data-stu-id="d2411-196">This page shows details about processes currently running on the host device.</span></span> <span data-ttu-id="d2411-197">これには、アプリとシステムの両方のプロセスが含まれます。</span><span class="sxs-lookup"><span data-stu-id="d2411-197">This includes both apps and system processes.</span></span> <span data-ttu-id="d2411-198">(デスクトップや IoT、HoloLens) 一部のプラットフォームでは、プロセスを終了できます。</span><span class="sxs-lookup"><span data-stu-id="d2411-198">On some platforms (Desktop, IoT, and HoloLens), you can terminate processes.</span></span>

![ページを処理するポータルを実行しているデバイス](images/device-portal/mob-device-portal-processes.png)

### <a name="file-explorer"></a><span data-ttu-id="d2411-200">エクスプローラー</span><span class="sxs-lookup"><span data-stu-id="d2411-200">File explorer</span></span>

<span data-ttu-id="d2411-201">このページを表示およびサイドロードしたアプリによって保存されているファイルを操作できます。</span><span class="sxs-lookup"><span data-stu-id="d2411-201">This page allows you to view and manipulate files stored by any sideloaded apps.</span></span> <span data-ttu-id="d2411-202">参照してください、[アプリのファイル エクスプ ローラーを使用して](https://blogs.windows.com/buildingapps/2016/06/08/using-the-app-file-explorer-to-see-your-app-data/)ブログの投稿をファイル エクスプ ローラーとその使用方法の詳細を参照してください。</span><span class="sxs-lookup"><span data-stu-id="d2411-202">See the [Using the App File Explorer](https://blogs.windows.com/buildingapps/2016/06/08/using-the-app-file-explorer-to-see-your-app-data/) blog post to learn more about the File explorer and how to use it.</span></span> 

![デバイスのポータル ファイル エクスプ ローラー ページ](images/device-portal/mob-device-portal-AppFileExplorer.png)

### <a name="performance"></a><span data-ttu-id="d2411-204">パフォーマンス</span><span class="sxs-lookup"><span data-stu-id="d2411-204">Performance</span></span>

<span data-ttu-id="d2411-205">[パフォーマンス] ページには、電力使用状況、フレーム レートのようなシステム診断情報のリアルタイムのグラフが表示されます。 と CPU の負荷。</span><span class="sxs-lookup"><span data-stu-id="d2411-205">The Performance page shows real-time graphs of system diagnostic info like power usage, frame rate, and CPU load.</span></span>

<span data-ttu-id="d2411-206">利用可能なメトリックを次に示します。</span><span class="sxs-lookup"><span data-stu-id="d2411-206">These are the available metrics:</span></span>
- <span data-ttu-id="d2411-207">**CPU**:使用可能な CPU 使用率の合計の割合</span><span class="sxs-lookup"><span data-stu-id="d2411-207">**CPU**: Percent of total available CPU utilization</span></span>
- <span data-ttu-id="d2411-208">**メモリ**:内の合計、使用して、使用可能なコミット、ページング、および非ページ</span><span class="sxs-lookup"><span data-stu-id="d2411-208">**Memory**: Total, in use, available, committed, paged, and non-paged</span></span>
- <span data-ttu-id="d2411-209">**I/O**:読み取りと書き込みのデータ量</span><span class="sxs-lookup"><span data-stu-id="d2411-209">**I/O**: Read and write data quantities</span></span>
- <span data-ttu-id="d2411-210">**ネットワーク**:受信および送信データ</span><span class="sxs-lookup"><span data-stu-id="d2411-210">**Network**: Received and sent data</span></span>
- <span data-ttu-id="d2411-211">**GPU**:使用可能な GPU エンジンの合計使用率の割合</span><span class="sxs-lookup"><span data-stu-id="d2411-211">**GPU**: Percent of total available GPU engine utilization</span></span>


![デバイスのポータルのパフォーマンス ページ](images/device-portal/mob-device-portal-perf.png)

### <a name="event-tracing-for-windows-etw-logging"></a><span data-ttu-id="d2411-213">Event Tracing for Windows (ETW) ログ記録</span><span class="sxs-lookup"><span data-stu-id="d2411-213">Event Tracing for Windows (ETW) logging</span></span>

<span data-ttu-id="d2411-214">ETW のログ記録 ページでは、デバイスのリアルタイムの Event Tracing for Windows (ETW) 情報を管理します。</span><span class="sxs-lookup"><span data-stu-id="d2411-214">The ETW logging page manages real-time Event Tracing for Windows (ETW) information on the device.</span></span>

![デバイスのポータルの ETW のログ記録 ページ](images/device-portal/mob-device-portal-etw.png)

<span data-ttu-id="d2411-216">**[Hide Providers]** (プロバイダを非表示にする) チェックボックスをオンにすると、イベントの一覧のみが表示されます。</span><span class="sxs-lookup"><span data-stu-id="d2411-216">Check **Hide providers** to show the Events list only.</span></span>
- <span data-ttu-id="d2411-217">**登録済みプロバイダー**:イベント プロバイダーは、トレース レベルを選択します。</span><span class="sxs-lookup"><span data-stu-id="d2411-217">**Registered providers**: Select the event provider and the tracing level.</span></span> <span data-ttu-id="d2411-218">トレース レベルでは、これらの値の 1 つです。</span><span class="sxs-lookup"><span data-stu-id="d2411-218">The tracing level is one of these values:</span></span>
  1. <span data-ttu-id="d2411-219">異常終了または終了</span><span class="sxs-lookup"><span data-stu-id="d2411-219">Abnormal exit or termination</span></span>
  2. <span data-ttu-id="d2411-220">重大なエラー</span><span class="sxs-lookup"><span data-stu-id="d2411-220">Severe errors</span></span>
  3. <span data-ttu-id="d2411-221">警告</span><span class="sxs-lookup"><span data-stu-id="d2411-221">Warnings</span></span>
  4. <span data-ttu-id="d2411-222">エラーではない警告</span><span class="sxs-lookup"><span data-stu-id="d2411-222">Non-error warnings</span></span>
  5. <span data-ttu-id="d2411-223">詳細なトレース</span><span class="sxs-lookup"><span data-stu-id="d2411-223">Detailed trace</span></span>

  <span data-ttu-id="d2411-224">トレースを開始するには、**[Enable]** (有効にする) をクリックまたはタップします。</span><span class="sxs-lookup"><span data-stu-id="d2411-224">Click or tap **Enable** to start tracing.</span></span> <span data-ttu-id="d2411-225">**[Enabled Providers]** (有効なプロバイダー) ドロップダウン リストにプロバイダーが追加されます。</span><span class="sxs-lookup"><span data-stu-id="d2411-225">The provider is added to the **Enabled Providers** dropdown.</span></span>
- <span data-ttu-id="d2411-226">**カスタム プロバイダー**:カスタムの ETW プロバイダーと、トレース レベルを選択します。</span><span class="sxs-lookup"><span data-stu-id="d2411-226">**Custom providers**: Select a custom ETW provider and the tracing level.</span></span> <span data-ttu-id="d2411-227">GUID を使用してプロバイダーを識別します。</span><span class="sxs-lookup"><span data-stu-id="d2411-227">Identify the provider by its GUID.</span></span> <span data-ttu-id="d2411-228">GUID に角かっこは含めないでください。</span><span class="sxs-lookup"><span data-stu-id="d2411-228">Do not include brackets in the GUID.</span></span>
- <span data-ttu-id="d2411-229">**プロバイダーを有効になっている**:これには、有効なプロバイダーが一覧表示します。</span><span class="sxs-lookup"><span data-stu-id="d2411-229">**Enabled providers**: This lists the enabled providers.</span></span> <span data-ttu-id="d2411-230">ドロップダウンからプロバイダーを選択し、**[Disable]** (無効にする) をクリックまたはタップしてトレースを停止します。</span><span class="sxs-lookup"><span data-stu-id="d2411-230">Select a provider from the dropdown and click or tap **Disable** to stop tracing.</span></span> <span data-ttu-id="d2411-231">すべてのトレースを中断するには、**[Stop All]** (すべて停止) をクリックまたはタップします。</span><span class="sxs-lookup"><span data-stu-id="d2411-231">Click or tap **Stop all** to suspend all tracing.</span></span>
- <span data-ttu-id="d2411-232">**プロバイダーの履歴**:これは、現在のセッション中に有効にしていた ETW プロバイダーを表示します。</span><span class="sxs-lookup"><span data-stu-id="d2411-232">**Providers history**: This shows the ETW providers that were enabled during the current session.</span></span> <span data-ttu-id="d2411-233">無効になっているプロバイダーをアクティブ化するには、**[Enable]** (有効にする) をクリックまたはタップします。</span><span class="sxs-lookup"><span data-stu-id="d2411-233">Click or tap **Enable** to activate a provider that was disabled.</span></span> <span data-ttu-id="d2411-234">履歴をクリアするには、**[Clear]** (クリア) をクリックまたはタップします。</span><span class="sxs-lookup"><span data-stu-id="d2411-234">Click or tap **Clear** to clear the history.</span></span>
- <span data-ttu-id="d2411-235">**フィルター/イベント**:**イベント**セクションには、テーブル形式で選択したプロバイダーから ETW イベントが一覧表示します。</span><span class="sxs-lookup"><span data-stu-id="d2411-235">**Filters / Events**: The **Events** section lists ETW events from the selected providers in table format.</span></span> <span data-ttu-id="d2411-236">テーブルは、リアルタイムで更新されます。</span><span class="sxs-lookup"><span data-stu-id="d2411-236">The table is updated in real time.</span></span> <span data-ttu-id="d2411-237">使用して、**フィルター**メニューに表示されるイベントをカスタム フィルターを設定します。</span><span class="sxs-lookup"><span data-stu-id="d2411-237">Use the **Filters** menu to set up custom filters for which events will be displayed.</span></span> <span data-ttu-id="d2411-238">をクリックして、**クリア**テーブルからすべての ETW イベントを削除するボタンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="d2411-238">Click the **Clear** button to delete all ETW events from the table.</span></span> <span data-ttu-id="d2411-239">これによってプロバイダーが無効になることはありません。</span><span class="sxs-lookup"><span data-stu-id="d2411-239">This does not disable any providers.</span></span> <span data-ttu-id="d2411-240">クリックすることができます**ファイルに保存する**現在収集された ETW イベントをローカルの CSV ファイルにエクスポートします。</span><span class="sxs-lookup"><span data-stu-id="d2411-240">You can click **Save to file** to export the currently collected ETW events to a local CSV file.</span></span>

<span data-ttu-id="d2411-241">ETW のログ記録の使用に関する詳細については、次を参照してください。、[デバイス ポータルでのデバッグ ログを表示する](https://blogs.windows.com/buildingapps/2016/06/10/using-device-portal-to-view-debug-logs-for-uwp/)ブログの投稿。</span><span class="sxs-lookup"><span data-stu-id="d2411-241">For more details on using ETW logging, see the [Use Device Portal to view debug logs](https://blogs.windows.com/buildingapps/2016/06/10/using-device-portal-to-view-debug-logs-for-uwp/) blog post.</span></span> 

### <a name="performance-tracing"></a><span data-ttu-id="d2411-242">パフォーマンス トレース</span><span class="sxs-lookup"><span data-stu-id="d2411-242">Performance tracing</span></span>

<span data-ttu-id="d2411-243">パフォーマンス トレース ページで表示できます、 [Windows Performance Recorder (WPR)](https://msdn.microsoft.com/library/hh448205.aspx)ホスト デバイスからのトレース。</span><span class="sxs-lookup"><span data-stu-id="d2411-243">The Performance tracing page allows you for view the [Windows Performance Recorder (WPR)](https://msdn.microsoft.com/library/hh448205.aspx) traces from the host device.</span></span>

![デバイスのポータルのパフォーマンス トレースのページ](images/device-portal/mob-device-portal-perf-tracing.png)

- <span data-ttu-id="d2411-245">**使用可能なプロファイル**:ドロップダウン リスト、およびクリックまたはタップしますから WPR プロファイルを選択**開始**トレースを開始します。</span><span class="sxs-lookup"><span data-stu-id="d2411-245">**Available profiles**: Select the WPR profile from the dropdown, and click or tap **Start** to start tracing.</span></span>
- <span data-ttu-id="d2411-246">**カスタム プロファイル**:をクリックしてまたはタップします**参照**を PC から WPR プロファイルを選択します。</span><span class="sxs-lookup"><span data-stu-id="d2411-246">**Custom profiles**: Click or tap **Browse** to choose a WPR profile from your PC.</span></span> <span data-ttu-id="d2411-247">**[Upload and start]** (アップロードして開始) をクリックまたはタップすると、トレースが開始します。</span><span class="sxs-lookup"><span data-stu-id="d2411-247">Click or tap **Upload and start** to start tracing.</span></span>

<span data-ttu-id="d2411-248">トレースを停止するには、**[Stop]** (停止) をクリックします。</span><span class="sxs-lookup"><span data-stu-id="d2411-248">To stop the trace, click **Stop**.</span></span> <span data-ttu-id="d2411-249">トレース ファイルまで、このページに留まります (です。ETL) のダウンロードが完了するとします。</span><span class="sxs-lookup"><span data-stu-id="d2411-249">Stay on this page until the trace file (.ETL) has finished downloading.</span></span>

<span data-ttu-id="d2411-250">キャプチャされます。分析のために ETL ファイルを開くことが、 [Windows Performance Analyzer](https://msdn.microsoft.com/library/windows/desktop/hh448170.aspx)します。</span><span class="sxs-lookup"><span data-stu-id="d2411-250">Captured .ETL files can be opened for analysis in the [Windows Performance Analyzer](https://msdn.microsoft.com/library/windows/desktop/hh448170.aspx).</span></span>

### <a name="device-manager"></a><span data-ttu-id="d2411-251">デバイス マネージャー</span><span class="sxs-lookup"><span data-stu-id="d2411-251">Device manager</span></span>

<span data-ttu-id="d2411-252">デバイス マネージャー ページでは、デバイスに接続されているすべての周辺機器を列挙します。</span><span class="sxs-lookup"><span data-stu-id="d2411-252">The Device manager page enumerates all peripherals attached to your device.</span></span> <span data-ttu-id="d2411-253">それぞれのプロパティを表示する設定アイコンをクリックできます。</span><span class="sxs-lookup"><span data-stu-id="d2411-253">You can click the settings icons to view the properties of each.</span></span>

![デバイスのポータルのデバイス マネージャー ページ](images/device-portal/mob-device-portal-devices.png)

### <a name="networking"></a><span data-ttu-id="d2411-255">ネットワーク</span><span class="sxs-lookup"><span data-stu-id="d2411-255">Networking</span></span>

<span data-ttu-id="d2411-256">ネットワーク ページでは、デバイス上のネットワーク接続を管理します。</span><span class="sxs-lookup"><span data-stu-id="d2411-256">The Networking page manages network connections on the device.</span></span> <span data-ttu-id="d2411-257">USB 経由のデバイスのポータルに接続している場合を除き、これらの設定を変更する可能性がありますから切断されますをデバイスのポータルです。</span><span class="sxs-lookup"><span data-stu-id="d2411-257">Unless you are connected to Device Portal through USB, changing these settings will likely disconnect you from Device Portal.</span></span>
- <span data-ttu-id="d2411-258">**使用可能なネットワーク**:デバイスで使用できる、WiFi ネットワークを示しています。</span><span class="sxs-lookup"><span data-stu-id="d2411-258">**Available networks**: Shows the WiFi networks available to the device.</span></span> <span data-ttu-id="d2411-259">ネットワークをクリックまたはタップすると、そのネットワークに接続し、必要に応じてパスキーを提供できます。</span><span class="sxs-lookup"><span data-stu-id="d2411-259">Clicking or tapping on a network will allow you to connect to it and supply a passkey if needed.</span></span> <span data-ttu-id="d2411-260">デバイスのポータルは、エンタープライズ認証をまだサポートしていません。</span><span class="sxs-lookup"><span data-stu-id="d2411-260">Device Portal does not yet support Enterprise Authentication.</span></span> <span data-ttu-id="d2411-261">使用することも、**プロファイル**ドロップダウンを使用して既知のデバイスに Wi-fi プロファイルのいずれかに接続しようとしています。</span><span class="sxs-lookup"><span data-stu-id="d2411-261">You can also use the **Profiles** dropdown to attempt to connect to any of the WiFi profiles known to the device.</span></span>
- <span data-ttu-id="d2411-262">**IP 構成**:アドレスの各ホスト デバイスのネットワーク ポートに関する情報を表示します。</span><span class="sxs-lookup"><span data-stu-id="d2411-262">**IP configuration**: Shows address information about each of the host device's network ports.</span></span>

![デバイスのポータルのネットワーク ページ](images/device-portal/mob-device-portal-network.png)

## <a name="service-features-and-notes"></a><span data-ttu-id="d2411-264">サービスの機能と注意事項</span><span class="sxs-lookup"><span data-stu-id="d2411-264">Service features and notes</span></span>

### <a name="dns-sd"></a><span data-ttu-id="d2411-265">DNS-SD</span><span class="sxs-lookup"><span data-stu-id="d2411-265">DNS-SD</span></span>

<span data-ttu-id="d2411-266">Device Portal は DNS-SD を使用して、ローカル ネットワーク上でその存在をアドバタイズします</span><span class="sxs-lookup"><span data-stu-id="d2411-266">Device Portal advertises its presence on the local network using DNS-SD.</span></span> <span data-ttu-id="d2411-267">Device Portal のすべてのインスタンスは、デバイスの種類に関係なく、"WDP._wdp._tcp.local" でアドバタイズします。</span><span class="sxs-lookup"><span data-stu-id="d2411-267">All Device Portal instances, regardless of their device type, advertise under "WDP._wdp._tcp.local".</span></span> <span data-ttu-id="d2411-268">サービス インスタンスの TXT レコードは、次の情報を提供します。</span><span class="sxs-lookup"><span data-stu-id="d2411-268">The TXT records for the service instance provide the following:</span></span>

<span data-ttu-id="d2411-269">Key</span><span class="sxs-lookup"><span data-stu-id="d2411-269">Key</span></span> | <span data-ttu-id="d2411-270">種類</span><span class="sxs-lookup"><span data-stu-id="d2411-270">Type</span></span> | <span data-ttu-id="d2411-271">説明</span><span class="sxs-lookup"><span data-stu-id="d2411-271">Description</span></span> 
----|------|-------------
<span data-ttu-id="d2411-272">S</span><span class="sxs-lookup"><span data-stu-id="d2411-272">S</span></span> | <span data-ttu-id="d2411-273">int</span><span class="sxs-lookup"><span data-stu-id="d2411-273">int</span></span> | <span data-ttu-id="d2411-274">Device Portal 用のセキュリティで保護されたポート。</span><span class="sxs-lookup"><span data-stu-id="d2411-274">Secure port for Device Portal.</span></span> <span data-ttu-id="d2411-275">0 (ゼロ) の場合、Device Portal は HTTPS 接続をリッスンしていません。</span><span class="sxs-lookup"><span data-stu-id="d2411-275">If 0 (zero), Device Portal is not listening for HTTPS connections.</span></span> 
<span data-ttu-id="d2411-276">D</span><span class="sxs-lookup"><span data-stu-id="d2411-276">D</span></span> | <span data-ttu-id="d2411-277">string</span><span class="sxs-lookup"><span data-stu-id="d2411-277">string</span></span> | <span data-ttu-id="d2411-278">デバイスの種類。</span><span class="sxs-lookup"><span data-stu-id="d2411-278">Type of device.</span></span> <span data-ttu-id="d2411-279">"Windows.\*" の形式 (Windows.Xbox、Windows.Desktop など) になります。</span><span class="sxs-lookup"><span data-stu-id="d2411-279">This will be in the format "Windows.\*", e.g. Windows.Xbox or Windows.Desktop</span></span>
<span data-ttu-id="d2411-280">A</span><span class="sxs-lookup"><span data-stu-id="d2411-280">A</span></span> | <span data-ttu-id="d2411-281">string</span><span class="sxs-lookup"><span data-stu-id="d2411-281">string</span></span> | <span data-ttu-id="d2411-282">デバイスのアーキテクチャ。</span><span class="sxs-lookup"><span data-stu-id="d2411-282">Device architecture.</span></span> <span data-ttu-id="d2411-283">これは、ARM、x86、AMD64 のいずれかです。</span><span class="sxs-lookup"><span data-stu-id="d2411-283">This will be ARM, x86, or AMD64.</span></span>  
<span data-ttu-id="d2411-284">T</span><span class="sxs-lookup"><span data-stu-id="d2411-284">T</span></span> | <span data-ttu-id="d2411-285">null 文字で区切られた string のリスト</span><span class="sxs-lookup"><span data-stu-id="d2411-285">null-character delineated list of strings</span></span> | <span data-ttu-id="d2411-286">ユーザーが適用したデバイスのタグ。</span><span class="sxs-lookup"><span data-stu-id="d2411-286">User-applied tags for the device.</span></span> <span data-ttu-id="d2411-287">使い方については、タグの REST API に関する説明をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d2411-287">See the Tags REST API for how to use this.</span></span> <span data-ttu-id="d2411-288">リストは 2 つの null で終了します。</span><span class="sxs-lookup"><span data-stu-id="d2411-288">List is double-null terminated.</span></span>  

<span data-ttu-id="d2411-289">DNS-SD レコードでアドバタイズされる HTTP ポートですべてのデバイスがリッスンしているわけではないため、HTTPS ポートでの接続をお勧めします。</span><span class="sxs-lookup"><span data-stu-id="d2411-289">Connecting on the HTTPS port is suggested, as not all devices are listening on the HTTP port advertised by the DNS-SD record.</span></span> 

### <a name="csrf-protection-and-scripting"></a><span data-ttu-id="d2411-290">CSRF に対する保護とスクリプト</span><span class="sxs-lookup"><span data-stu-id="d2411-290">CSRF Protection and Scripting</span></span>

<span data-ttu-id="d2411-291">[CSRF 攻撃](https://wikipedia.org/wiki/Cross-site_request_forgery)に対する保護のために、すべての非 GET 要求に一意のトークンが必要です。</span><span class="sxs-lookup"><span data-stu-id="d2411-291">In order to protect against [CSRF attacks](https://wikipedia.org/wiki/Cross-site_request_forgery), a unique token is required on all non-GET requests.</span></span> <span data-ttu-id="d2411-292">このトークン、X-CSRF-Token 要求ヘッダーは、セッション Cookie、CSRF-Token から派生します。</span><span class="sxs-lookup"><span data-stu-id="d2411-292">This token, the X-CSRF-Token request header, is derived from a session cookie, CSRF-Token.</span></span> <span data-ttu-id="d2411-293">Device Portal の Web UI では、CSRF-Token Cookie が、各要求の X-CSRF-Token にコピーされます。</span><span class="sxs-lookup"><span data-stu-id="d2411-293">In the Device Portal web UI, the CSRF-Token cookie is copied into the X-CSRF-Token header on each request.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="d2411-294">この保護は、(コマンド ライン ユーティリティ) などのスタンドアロン クライアントから REST Api の使用状況をできないようにします。</span><span class="sxs-lookup"><span data-stu-id="d2411-294">This protection prevents usages of the REST APIs from a standalone client (such as command-line utilities).</span></span> <span data-ttu-id="d2411-295">これは 3 つの方法で解決できます。</span><span class="sxs-lookup"><span data-stu-id="d2411-295">This can be solved in 3 ways:</span></span> 
> - <span data-ttu-id="d2411-296">「自動-」ユーザー名を使用します。</span><span class="sxs-lookup"><span data-stu-id="d2411-296">Use an "auto-" username.</span></span> <span data-ttu-id="d2411-297">クライアントはユーザー名の前に "auto-" を追加することによって、CSRF に対する保護を迂回できます。</span><span class="sxs-lookup"><span data-stu-id="d2411-297">Clients that prepend "auto-" to their username will bypass CSRF protection.</span></span> <span data-ttu-id="d2411-298">このユーザー名は、ブラウザーから Device Portal にログインするために使用しないでください。サービスが CSRF 攻撃を受ける可能性があります。</span><span class="sxs-lookup"><span data-stu-id="d2411-298">It is important that this username not be used to log in to Device Portal through the browser, as it will open up the service to CSRF attacks.</span></span> <span data-ttu-id="d2411-299">以下に例を示します。デバイスのポータルのユーザー名が"admin"の場合```curl -u auto-admin:password <args>```CSRF 保護をバイパスするために使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d2411-299">Example: If Device Portal's username is "admin", ```curl -u auto-admin:password <args>``` should be used to bypass CSRF protection.</span></span> 
> - <span data-ttu-id="d2411-300">クライアントで cookie-to-header スキームを実装します。</span><span class="sxs-lookup"><span data-stu-id="d2411-300">Implement the cookie-to-header scheme in the client.</span></span> <span data-ttu-id="d2411-301">そのためには、GET 要求でセッション Cookie を確立し、それ以降のすべての要求にヘッダーと Cookie の両方を含めます。</span><span class="sxs-lookup"><span data-stu-id="d2411-301">This requires a GET request to establish the session cookie, and then the inclusion of both the header and the cookie on all subsequent requests.</span></span> 
> - <span data-ttu-id="d2411-302">認証を無効にして、HTTP を使用します。</span><span class="sxs-lookup"><span data-stu-id="d2411-302">Disable authentication and use HTTP.</span></span> <span data-ttu-id="d2411-303">CSRF に対する保護は HTTPS エンドポイントにのみ適用されるため、HTTP エンドポイントに接続する場合、上記のいずれの操作も必要ありません。</span><span class="sxs-lookup"><span data-stu-id="d2411-303">CSRF protection only applies to HTTPS endpoints, so connections on HTTP endpoints will not need to do either of the above.</span></span> 

#### <a name="cross-site-websocket-hijacking-cswsh-protection"></a><span data-ttu-id="d2411-304">クロスサイト WebSocket ハイジャック (CSWSH) に対する保護</span><span class="sxs-lookup"><span data-stu-id="d2411-304">Cross-Site WebSocket Hijacking (CSWSH) protection</span></span>

<span data-ttu-id="d2411-305">[CSWSH 攻撃](https://www.christian-schneider.net/CrossSiteWebSocketHijacking.html)を防御するために、Device Portal に対して WebSocket 接続を開くすべてのクライアントは、Host ヘッダーと一致する Origin ヘッダーも提供する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d2411-305">To protect against [CSWSH attacks](https://www.christian-schneider.net/CrossSiteWebSocketHijacking.html), all clients opening a WebSocket connection to Device Portal must also provide an Origin header that matches the Host header.</span></span> <span data-ttu-id="d2411-306">これにより、Device Portal に対して、要求が Device Portal の UI または有効なクライアント アプリケーションからの要求であることを証明します。</span><span class="sxs-lookup"><span data-stu-id="d2411-306">This proves to Device Portal that the request comes either from the Device Portal UI or a valid client application.</span></span> <span data-ttu-id="d2411-307">Origin ヘッダーがない場合、要求は拒否されます。</span><span class="sxs-lookup"><span data-stu-id="d2411-307">Without the Origin header your request will be rejected.</span></span> 
