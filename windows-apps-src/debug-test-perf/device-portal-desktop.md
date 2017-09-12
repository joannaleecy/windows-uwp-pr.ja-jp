---
author: PatrickFarley
ms.assetid: 5c34c78e-9ff7-477b-87f6-a31367cd3f8b
title: "デスクトップ用 Device Portal"
description: "Windows デスクトップで Windows Device Portal の診断と自動化を利用する方法について説明します。"
ms.author: pafarley
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 32155bfbb676a5f79dd4b1629f0a88368da36828
ms.sourcegitcommit: 0fa9ae00117e8e6b04ed38956e605bb74c1261c6
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/07/2017
---
# <a name="device-portal-for-desktop"></a><span data-ttu-id="0a6ad-104">デスクトップ用 Device Portal</span><span class="sxs-lookup"><span data-stu-id="0a6ad-104">Device Portal for Desktop</span></span>

<span data-ttu-id="0a6ad-105">Windows 10 Version 1607 以降では、デスクトップで追加の開発者向け機能が利用できるようになりました。</span><span class="sxs-lookup"><span data-stu-id="0a6ad-105">Starting in Windows 10, Version 1607, additional developer features are available for desktop.</span></span> <span data-ttu-id="0a6ad-106">これらの機能は、開発者モードが有効になっている場合にのみ利用可能です。</span><span class="sxs-lookup"><span data-stu-id="0a6ad-106">These features are available only when Developer Mode is enabled.</span></span>

<span data-ttu-id="0a6ad-107">開発者モードを有効にする方法については、「[デバイスを開発用に有効にする](../get-started/enable-your-device-for-development.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0a6ad-107">For information about how to enable Developer Mode, see [Enable your device for development](../get-started/enable-your-device-for-development.md).</span></span>

<span data-ttu-id="0a6ad-108">Device Portal では、診断情報を表示し、使用しているブラウザーから HTTP 経由でデスクトップを操作できます。</span><span class="sxs-lookup"><span data-stu-id="0a6ad-108">Device Portal lets you view diagnostic information and interact with your desktop over HTTP from your browser.</span></span> <span data-ttu-id="0a6ad-109">Device Portal を使用すると、次の操作を実行できます。</span><span class="sxs-lookup"><span data-stu-id="0a6ad-109">You can use Device Portal to do the following:</span></span>
- <span data-ttu-id="0a6ad-110">実行されているプロセスの一覧を確認して操作する</span><span class="sxs-lookup"><span data-stu-id="0a6ad-110">See and manipulate a list of running processes</span></span>
- <span data-ttu-id="0a6ad-111">アプリをインストール、削除、起動、および終了する</span><span class="sxs-lookup"><span data-stu-id="0a6ad-111">Install, delete, launch, and terminate apps</span></span>
- <span data-ttu-id="0a6ad-112">Wi-Fi プロファイルの変更、シグナルの強さの表示、ipconfig の確認を行う</span><span class="sxs-lookup"><span data-stu-id="0a6ad-112">Change Wi-Fi profiles, view signal strength, and see ipconfig</span></span>
- <span data-ttu-id="0a6ad-113">CPU、メモリ、I/O、ネットワーク、および GPU の使用率のライブ グラフを表示する</span><span class="sxs-lookup"><span data-stu-id="0a6ad-113">View live graphs of CPU, memory, I/O, network, and GPU usage</span></span>
- <span data-ttu-id="0a6ad-114">プロセス ダンプを収集する</span><span class="sxs-lookup"><span data-stu-id="0a6ad-114">Collect process dumps</span></span>
- <span data-ttu-id="0a6ad-115">ETW トレースを収集する</span><span class="sxs-lookup"><span data-stu-id="0a6ad-115">Collect ETW traces</span></span> 
- <span data-ttu-id="0a6ad-116">サイドローディングしたアプリの分離ストレージを操作する</span><span class="sxs-lookup"><span data-stu-id="0a6ad-116">Manipulate the isolated storage of sideloaded apps</span></span>

## <a name="set-up-device-portal-on-windows-desktop"></a><span data-ttu-id="0a6ad-117">Windows Desktop で Device Portal をセットアップする</span><span class="sxs-lookup"><span data-stu-id="0a6ad-117">Set up device portal on Windows Desktop</span></span>

### <a name="turn-on-device-portal"></a><span data-ttu-id="0a6ad-118">Device Portal を有効にする</span><span class="sxs-lookup"><span data-stu-id="0a6ad-118">Turn on device portal</span></span>

<span data-ttu-id="0a6ad-119">**[開発者向け設定]** メニューの [開発者モード] を有効にすると、Device Portal を有効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="0a6ad-119">In the **Developer Settings** menu, with Developer Mode enabled, you can enable Device Portal.</span></span>  

<span data-ttu-id="0a6ad-120">Device Portal を有効にするときは、Device Portal のユーザー名とパスワードも作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0a6ad-120">When you enable Device Portal, you must also create a username and password for Device Portal.</span></span> <span data-ttu-id="0a6ad-121">Microsoft アカウントやその他の Windows の資格情報を使わないでください。</span><span class="sxs-lookup"><span data-stu-id="0a6ad-121">Do not use your Microsoft account or other Windows credentials.</span></span>  

<span data-ttu-id="0a6ad-122">Device Portal を有効にしたら、**[設定]** セクション下部にリンクが表示されます。</span><span class="sxs-lookup"><span data-stu-id="0a6ad-122">After Device Portal is enabled, you will see links to it at the bottom of the **Settings** section.</span></span> <span data-ttu-id="0a6ad-123">URL の末尾に適用されるポート番号をメモします。このポート番号は、Device Portal を有効にするとランダムに生成されるものですが、デスクトップを再起動するまで同じ番号を使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="0a6ad-123">Take note of the port number applied to the end of the URL: this port number is randomly generated when Device Portal is enabled, but should remain consistent between reboots of the desktop.</span></span> <span data-ttu-id="0a6ad-124">同じ番号を使い続けるためにポート番号を手動で設定する場合は、「[ポート番号を設定する](device-portal-desktop.md#setting-port-numbers)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0a6ad-124">If you'd like to set the port numbers manually so they remain permanent, see [Setting port numbers](device-portal-desktop.md#setting-port-numbers).</span></span>

<span data-ttu-id="0a6ad-125">Device Portal に接続するには、ローカル ホスト接続と、ローカル ネットワーク (VPN を含む) 経由接続の 2 つの方法のいずれかを使うことができます。</span><span class="sxs-lookup"><span data-stu-id="0a6ad-125">You can choose from two ways to connect to Device Portal: local host and over the local network (including VPN).</span></span>

**<span data-ttu-id="0a6ad-126">Device Portal に接続するには</span><span class="sxs-lookup"><span data-stu-id="0a6ad-126">To connect to Device Portal</span></span>**

1. <span data-ttu-id="0a6ad-127">ブラウザーで、使っている接続の種類に応じて次のアドレスを入力します。</span><span class="sxs-lookup"><span data-stu-id="0a6ad-127">In your browser, enter the address shown here for the connection type you're using.</span></span>

    - <span data-ttu-id="0a6ad-128">Localhost: `http://127.0.0.1:PORT` または</span><span class="sxs-lookup"><span data-stu-id="0a6ad-128">Localhost: `http://127.0.0.1:PORT` or</span></span> `http://localhost:PORT`

    <span data-ttu-id="0a6ad-129">このアドレスを使用すると、Device Portal がローカルに表示されます。</span><span class="sxs-lookup"><span data-stu-id="0a6ad-129">Use this address to view Device Portal locally.</span></span>
    
    - <span data-ttu-id="0a6ad-130">ローカル ネットワーク:</span><span class="sxs-lookup"><span data-stu-id="0a6ad-130">Local Network:</span></span> `https://<The IP address of the desktop>:PORT`

    <span data-ttu-id="0a6ad-131">このアドレスは、ローカル ネットワーク経由で接続するときに使います。</span><span class="sxs-lookup"><span data-stu-id="0a6ad-131">Use this address to connect over a local network.</span></span>

<span data-ttu-id="0a6ad-132">認証とセキュリティで保護された通信には HTTPS が必要です。</span><span class="sxs-lookup"><span data-stu-id="0a6ad-132">HTTPS is required for authentication and secure communication.</span></span>

<span data-ttu-id="0a6ad-133">テスト ラボなど、保護された環境で Device Portal を使っている場合、ローカル ネットワーク上のすべてのユーザーを信頼していて、デバイス上に個人情報が保存されておらず、固有の要件もない場合は、認証を無効にできます。</span><span class="sxs-lookup"><span data-stu-id="0a6ad-133">If you are using Device Portal in a protected environment, like a test lab, where you trust everyone on your local network, have no personal information on the device, and have unique requirements, you can disable authentication.</span></span> <span data-ttu-id="0a6ad-134">これにより、暗号化されていない通信が有効化され、コンピューターの IP アドレスを知っているすべてのユーザーが制御できるようになります。</span><span class="sxs-lookup"><span data-stu-id="0a6ad-134">This enables unencrypted communication, and allows anyone with the IP address of your computer to control it.</span></span>

## <a name="device-portal-pages"></a><span data-ttu-id="0a6ad-135">Device Portal のページ</span><span class="sxs-lookup"><span data-stu-id="0a6ad-135">Device Portal pages</span></span>

<span data-ttu-id="0a6ad-136">デスクトップの Device Portal では、標準のページのセットが提供されます。</span><span class="sxs-lookup"><span data-stu-id="0a6ad-136">Device Portal on desktop provides the standard set of pages.</span></span> <span data-ttu-id="0a6ad-137">詳しい説明については、「[Windows Device Portal の概要](device-portal.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0a6ad-137">For detailed descriptions, see [Windows Device Portal overview](device-portal.md).</span></span>

- <span data-ttu-id="0a6ad-138">アプリ</span><span class="sxs-lookup"><span data-stu-id="0a6ad-138">Apps</span></span>
- <span data-ttu-id="0a6ad-139">プロセス</span><span class="sxs-lookup"><span data-stu-id="0a6ad-139">Processes</span></span>
- <span data-ttu-id="0a6ad-140">パフォーマンス</span><span class="sxs-lookup"><span data-stu-id="0a6ad-140">Performance</span></span>
- <span data-ttu-id="0a6ad-141">デバッグ</span><span class="sxs-lookup"><span data-stu-id="0a6ad-141">Debugging</span></span>
- <span data-ttu-id="0a6ad-142">Windows イベント トレーシング (ETW)</span><span class="sxs-lookup"><span data-stu-id="0a6ad-142">Event Tracing for Windows (ETW)</span></span>
- <span data-ttu-id="0a6ad-143">パフォーマンス トレース</span><span class="sxs-lookup"><span data-stu-id="0a6ad-143">Performance tracing</span></span>
- <span data-ttu-id="0a6ad-144">デバイス</span><span class="sxs-lookup"><span data-stu-id="0a6ad-144">Devices</span></span>
- <span data-ttu-id="0a6ad-145">ネットワーク</span><span class="sxs-lookup"><span data-stu-id="0a6ad-145">Networking</span></span>
- <span data-ttu-id="0a6ad-146">アプリのエクスプローラー</span><span class="sxs-lookup"><span data-stu-id="0a6ad-146">App File Explorer</span></span> 

## <a name="setting-port-numbers"></a><span data-ttu-id="0a6ad-147">ポート番号を設定する</span><span class="sxs-lookup"><span data-stu-id="0a6ad-147">Setting port numbers</span></span>

<span data-ttu-id="0a6ad-148">デバイス ポータルのポート番号 (80、443 など) を選択する場合は、次のレジストリ キーを設定することができます。</span><span class="sxs-lookup"><span data-stu-id="0a6ad-148">If you would like to select port numbers for Device Portal (such as 80 and 443), you can set the following regkeys:</span></span>

- <span data-ttu-id="0a6ad-149">HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\WebManagement\Service の下</span><span class="sxs-lookup"><span data-stu-id="0a6ad-149">Under HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\WebManagement\Service</span></span>
    - <span data-ttu-id="0a6ad-150">UseDynamicPorts: 必要な DWORD。</span><span class="sxs-lookup"><span data-stu-id="0a6ad-150">UseDynamicPorts: A required DWORD.</span></span> <span data-ttu-id="0a6ad-151">選択したポート番号を保持するには、これを 0 に設定します。</span><span class="sxs-lookup"><span data-stu-id="0a6ad-151">Set this to 0 in order to retain the port numbers you've chosen.</span></span>
    - <span data-ttu-id="0a6ad-152">HttpPort: 必要な DWORD。</span><span class="sxs-lookup"><span data-stu-id="0a6ad-152">HttpPort: A required DWORD.</span></span> <span data-ttu-id="0a6ad-153">Device Portal が HTTP 接続をリッスンするポート番号を指定します。</span><span class="sxs-lookup"><span data-stu-id="0a6ad-153">Contains the port number that Device Portal will listen for HTTP connections on.</span></span>  
    - <span data-ttu-id="0a6ad-154">HttpsPort: 必要な DWORD。</span><span class="sxs-lookup"><span data-stu-id="0a6ad-154">HttpsPort: A required DWORD.</span></span> <span data-ttu-id="0a6ad-155">Device Portal が HTTPS 接続をリッスンするポート番号を指定します。</span><span class="sxs-lookup"><span data-stu-id="0a6ad-155">Contains the port number that Device Portal will listen for HTTPS connections on.</span></span>

## <a name="failure-to-install-developer-mode-package"></a><span data-ttu-id="0a6ad-156">開発者モード パッケージのインストール エラー</span><span class="sxs-lookup"><span data-stu-id="0a6ad-156">Failure to install Developer Mode package</span></span>
<span data-ttu-id="0a6ad-157">ネットワークや互換性の問題により、開発者モードが正しくインストールされないことがあります。</span><span class="sxs-lookup"><span data-stu-id="0a6ad-157">Sometimes, due to network or compatibility issues, Developer Mode won't install correctly.</span></span> <span data-ttu-id="0a6ad-158">開発者モード パッケージは、PC への**リモート**展開 (ブラウザーから Device Portal を使うか、デバイスの検出を使って SSH を有効にする場合) に必要ですが、ローカル展開には必要ありません。</span><span class="sxs-lookup"><span data-stu-id="0a6ad-158">The Developer Mode package is required for **remote** deployment to the PC -- using Device Portal from a browser or Device Discovery to enable SSH -- but not for local development.</span></span>  <span data-ttu-id="0a6ad-159">これらの問題が発生した場合でも、Visual Studio を使用してローカルでアプリを展開できます。</span><span class="sxs-lookup"><span data-stu-id="0a6ad-159">Even if you encounter these issues, you can still deploy your app locally using Visual Studio.</span></span> 

<span data-ttu-id="0a6ad-160">これらの問題に対する回避策については、[既知の問題](https://social.msdn.microsoft.com/Forums/en-US/home?forum=Win10SDKToolsIssues&sort=relevancedesc&brandIgnore=True&searchTerm=%22device+portal%22)フォーラムと[開発者モードに関するページ](https://docs.microsoft.com/windows/uwp/get-started/enable-your-device-for-development#failure-to-install-developer-mode-package)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0a6ad-160">See the [Known Issues](https://social.msdn.microsoft.com/Forums/en-US/home?forum=Win10SDKToolsIssues&sort=relevancedesc&brandIgnore=True&searchTerm=%22device+portal%22) forum and the [Developer Mode page](https://docs.microsoft.com/windows/uwp/get-started/enable-your-device-for-development#failure-to-install-developer-mode-package) to find workarounds to these issues and more.</span></span> 

