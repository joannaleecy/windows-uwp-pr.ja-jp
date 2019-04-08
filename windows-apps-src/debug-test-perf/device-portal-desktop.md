---
ms.assetid: 5c34c78e-9ff7-477b-87f6-a31367cd3f8b
title: Windows デスクトップ用 Device Portal
description: Windows デスクトップで Windows Device Portal の診断と自動化を利用する方法について説明します。
ms.date: 02/6/2019
ms.topic: article
keywords: windows 10、uwp、デバイス ポータル
ms.localizationpriority: medium
ms.openlocfilehash: 4fe1f2a51199dd12cd1d285c17c5d48c9a25b969
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57654527"
---
# <a name="device-portal-for-windows-desktop"></a><span data-ttu-id="5eaf6-104">Windows デスクトップ用 Device Portal</span><span class="sxs-lookup"><span data-stu-id="5eaf6-104">Device Portal for Windows Desktop</span></span>

<span data-ttu-id="5eaf6-105">Windows Device Portal では、診断情報を表示し、ブラウザー ウィンドウから HTTP 経由でデスクトップを操作することができます。</span><span class="sxs-lookup"><span data-stu-id="5eaf6-105">Windows Device Portal lets you view diagnostic information and interact with your desktop over HTTP from a browser window.</span></span> <span data-ttu-id="5eaf6-106">Device Portal を使用すると、次の操作を実行できます。</span><span class="sxs-lookup"><span data-stu-id="5eaf6-106">You can use Device Portal to do the following:</span></span>
- <span data-ttu-id="5eaf6-107">実行されているプロセスの一覧を確認して操作する</span><span class="sxs-lookup"><span data-stu-id="5eaf6-107">See and manipulate a list of running processes</span></span>
- <span data-ttu-id="5eaf6-108">アプリをインストール、削除、起動、および終了する</span><span class="sxs-lookup"><span data-stu-id="5eaf6-108">Install, delete, launch, and terminate apps</span></span>
- <span data-ttu-id="5eaf6-109">Wi-Fi プロファイルの変更、シグナルの強さの表示、ipconfig の確認を行う</span><span class="sxs-lookup"><span data-stu-id="5eaf6-109">Change Wi-Fi profiles, view signal strength, and see ipconfig</span></span>
- <span data-ttu-id="5eaf6-110">CPU、メモリ、I/O、ネットワーク、および GPU の使用率のライブ グラフを表示する</span><span class="sxs-lookup"><span data-stu-id="5eaf6-110">View live graphs of CPU, memory, I/O, network, and GPU usage</span></span>
- <span data-ttu-id="5eaf6-111">プロセス ダンプを収集する</span><span class="sxs-lookup"><span data-stu-id="5eaf6-111">Collect process dumps</span></span>
- <span data-ttu-id="5eaf6-112">ETW トレースを収集する</span><span class="sxs-lookup"><span data-stu-id="5eaf6-112">Collect ETW traces</span></span> 
- <span data-ttu-id="5eaf6-113">サイドローディングされたアプリの分離ストレージを操作する</span><span class="sxs-lookup"><span data-stu-id="5eaf6-113">Manipulate the isolated storage of sideloaded apps</span></span>

## <a name="set-up-device-portal-on-windows-desktop"></a><span data-ttu-id="5eaf6-114">Windows デスクトップで Device Portal をセットアップする</span><span class="sxs-lookup"><span data-stu-id="5eaf6-114">Set up Device Portal on Windows Desktop</span></span>

### <a name="turn-on-developer-mode"></a><span data-ttu-id="5eaf6-115">開発者モードをオンにする</span><span class="sxs-lookup"><span data-stu-id="5eaf6-115">Turn on developer mode</span></span>

<span data-ttu-id="5eaf6-116">Windows 10 バージョン 1607 以降では、デスクトップ用の新しい機能の一部は開発者モードが有効なときだけ利用できます。</span><span class="sxs-lookup"><span data-stu-id="5eaf6-116">Starting in Windows 10, version 1607, some of the newer features for desktop are only available when developer mode is enabled.</span></span> <span data-ttu-id="5eaf6-117">開発者モードを有効にする方法については、「[デバイスを開発用に有効にする](../get-started/enable-your-device-for-development.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5eaf6-117">For information about how to enable developer mode, see [Enable your device for development](../get-started/enable-your-device-for-development.md).</span></span>

> [!IMPORTANT]
> <span data-ttu-id="5eaf6-118">ネットワークや互換性の問題により、お使いのデバイスに開発者モードが正しくインストールされないことがあります。</span><span class="sxs-lookup"><span data-stu-id="5eaf6-118">Sometimes, due to network or compatibility issues, developer mode won't install correctly on your device.</span></span> <span data-ttu-id="5eaf6-119">これらの問題のトラブルシューティングについては、「[デバイスを開発用に有効にする](https://docs.microsoft.com/windows/uwp/get-started/enable-your-device-for-development#failure-to-install-developer-mode-package)」の関連セクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5eaf6-119">See the [relevant section of Enable your device for development](https://docs.microsoft.com/windows/uwp/get-started/enable-your-device-for-development#failure-to-install-developer-mode-package) for help troubleshooting these issues.</span></span>

### <a name="turn-on-device-portal"></a><span data-ttu-id="5eaf6-120">Device Portal をオンにする</span><span class="sxs-lookup"><span data-stu-id="5eaf6-120">Turn on Device Portal</span></span>

<span data-ttu-id="5eaf6-121">**[設定]** の **[開発者向け]** セクションで、Device Portal を有効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="5eaf6-121">You can enable Device Portal in the **For developers** section of **Settings**.</span></span> <span data-ttu-id="5eaf6-122">Device Portal を有効にするときは、対応するユーザー名とパスワードも作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="5eaf6-122">When you enable it, you must also create a corresponding username and password.</span></span> <span data-ttu-id="5eaf6-123">Microsoft アカウントやその他の Windows の資格情報を使わないでください。</span><span class="sxs-lookup"><span data-stu-id="5eaf6-123">Do not use your Microsoft account or other Windows credentials.</span></span> 

![設定アプリの [Device Portal] セクション](images/device-portal/device-portal-desk-settings.png) 

<span data-ttu-id="5eaf6-125">Device Portal が有効になると、セクション下部に Web リンクが表示されます。</span><span class="sxs-lookup"><span data-stu-id="5eaf6-125">Once Device Portal is enabled, you will see web links at the bottom of the section.</span></span> <span data-ttu-id="5eaf6-126">表示される URL の末尾に付加されたポート番号をメモします。このポート番号は、Device Portal が有効になるとランダムに生成されるものですが、デスクトップを再起動するまで同じ番号を使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="5eaf6-126">Take note of the port number appended to the end of the listed URLs: this number is randomly generated when Device Portal is enabled but should remain consistent between reboots of the desktop.</span></span> 

<span data-ttu-id="5eaf6-127">これらのリンクから、ローカル ネットワーク (VPN を含む) 経由、またはローカル ホスト経由のいずれかの方法で Device Portal に接続できます。</span><span class="sxs-lookup"><span data-stu-id="5eaf6-127">These links offer two ways to connect to Device Portal: over the local network (including VPN) or through the local host.</span></span>

### <a name="connect-to-device-portal"></a><span data-ttu-id="5eaf6-128">Device Portal に接続する</span><span class="sxs-lookup"><span data-stu-id="5eaf6-128">Connect to Device Portal</span></span>

<span data-ttu-id="5eaf6-129">ローカル ホスト経由で接続するには、ブラウザー ウィンドウを開き、使用している接続の種類に関して次に示すアドレスを入力します。</span><span class="sxs-lookup"><span data-stu-id="5eaf6-129">To connet through local host, open a browser window and enter the address shown here for the connection type you're using.</span></span>

* <span data-ttu-id="5eaf6-130">Localhost:`http://127.0.0.1:<PORT>`または `http://localhost:<PORT>`</span><span class="sxs-lookup"><span data-stu-id="5eaf6-130">Localhost: `http://127.0.0.1:<PORT>` or `http://localhost:<PORT>`</span></span>
* <span data-ttu-id="5eaf6-131">Local Network: `https://<IP address of the desktop>:<PORT>`</span><span class="sxs-lookup"><span data-stu-id="5eaf6-131">Local Network: `https://<IP address of the desktop>:<PORT>`</span></span>

<span data-ttu-id="5eaf6-132">認証とセキュリティで保護された通信には HTTPS が必要です。</span><span class="sxs-lookup"><span data-stu-id="5eaf6-132">HTTPS is required for authentication and secure communication.</span></span>

<span data-ttu-id="5eaf6-133">テスト ラボなど、保護された環境で Device Portal を使っている場合、ローカル ネットワーク上のすべてのユーザーを信頼していて、デバイス上に個人情報が保存されておらず、固有の要件もない場合は、[認証] オプションを無効にできます。</span><span class="sxs-lookup"><span data-stu-id="5eaf6-133">If you are using Device Portal in a protected environment, like a test lab, in which you trust everyone on your local network, have no personal information on the device, and have unique requirements, you can disable the Authentication option.</span></span> <span data-ttu-id="5eaf6-134">これにより、暗号化されていない通信が有効化され、コンピューターの IP アドレスを知っているすべてのユーザーが接続して制御できるようになります。</span><span class="sxs-lookup"><span data-stu-id="5eaf6-134">This enables unencrypted communication, and allows anyone with the IP address of your computer to connect to and control it.</span></span>

## <a name="device-portal-content-on-windows-desktop"></a><span data-ttu-id="5eaf6-135">Windows デスクトップ上の Device Portal のコンテンツ</span><span class="sxs-lookup"><span data-stu-id="5eaf6-135">Device Portal content on Windows Desktop</span></span>

<span data-ttu-id="5eaf6-136">Windows デスクトップの Device Portal では、標準のページのセットが提供されます。</span><span class="sxs-lookup"><span data-stu-id="5eaf6-136">Device Portal on Windows Desktop provides the standard set of pages.</span></span> <span data-ttu-id="5eaf6-137">これらの詳しい説明については、「[Windows Device Portal の概要](device-portal.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5eaf6-137">For detailed descriptions of these, see [Windows Device Portal overview](device-portal.md).</span></span>

- <span data-ttu-id="5eaf6-138">アプリ マネージャー</span><span class="sxs-lookup"><span data-stu-id="5eaf6-138">Apps manager</span></span>
- <span data-ttu-id="5eaf6-139">エクスプローラー</span><span class="sxs-lookup"><span data-stu-id="5eaf6-139">File explorer</span></span>
- <span data-ttu-id="5eaf6-140">実行中のプロセス</span><span class="sxs-lookup"><span data-stu-id="5eaf6-140">Running Processes</span></span>
- <span data-ttu-id="5eaf6-141">パフォーマンス</span><span class="sxs-lookup"><span data-stu-id="5eaf6-141">Performance</span></span>
- <span data-ttu-id="5eaf6-142">デバッグ</span><span class="sxs-lookup"><span data-stu-id="5eaf6-142">Debug</span></span>
- <span data-ttu-id="5eaf6-143">Windows イベント トレーシング (ETW)</span><span class="sxs-lookup"><span data-stu-id="5eaf6-143">Event Tracing for Windows (ETW)</span></span>
- <span data-ttu-id="5eaf6-144">パフォーマンス トレース</span><span class="sxs-lookup"><span data-stu-id="5eaf6-144">Performance tracing</span></span>
- <span data-ttu-id="5eaf6-145">デバイス マネージャー</span><span class="sxs-lookup"><span data-stu-id="5eaf6-145">Device manager</span></span>
- <span data-ttu-id="5eaf6-146">ネットワーク</span><span class="sxs-lookup"><span data-stu-id="5eaf6-146">Networking</span></span>
- <span data-ttu-id="5eaf6-147">クラッシュ データ</span><span class="sxs-lookup"><span data-stu-id="5eaf6-147">Crash data</span></span>
- <span data-ttu-id="5eaf6-148">機能</span><span class="sxs-lookup"><span data-stu-id="5eaf6-148">Features</span></span>
- <span data-ttu-id="5eaf6-149">Mixed Reality</span><span class="sxs-lookup"><span data-stu-id="5eaf6-149">Mixed Reality</span></span>
- <span data-ttu-id="5eaf6-150">ストリーミング インストール デバッガー</span><span class="sxs-lookup"><span data-stu-id="5eaf6-150">Streaming Install Debugger</span></span>
- <span data-ttu-id="5eaf6-151">Location</span><span class="sxs-lookup"><span data-stu-id="5eaf6-151">Location</span></span>
- <span data-ttu-id="5eaf6-152">スクラッチ</span><span class="sxs-lookup"><span data-stu-id="5eaf6-152">Scratch</span></span>

## <a name="more-device-portal-options"></a><span data-ttu-id="5eaf6-153">Device Portal のその他のオプション</span><span class="sxs-lookup"><span data-stu-id="5eaf6-153">More Device Portal options</span></span>

### <a name="registry-based-configuration-for-device-portal"></a><span data-ttu-id="5eaf6-154">Device Portal のレジストリ ベースの構成</span><span class="sxs-lookup"><span data-stu-id="5eaf6-154">Registry-based configuration for Device Portal</span></span>

<span data-ttu-id="5eaf6-155">デバイス ポータルのポート番号 (80、443 など) を選択する場合は、次のレジストリ キーを設定することができます。</span><span class="sxs-lookup"><span data-stu-id="5eaf6-155">If you would like to select port numbers for Device Portal (such as 80 and 443), you can set the following regkeys:</span></span>

- <span data-ttu-id="5eaf6-156"> `HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\WebManagement\Service`</span><span class="sxs-lookup"><span data-stu-id="5eaf6-156">Under `HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\WebManagement\Service`</span></span>
    - <span data-ttu-id="5eaf6-157">`UseDynamicPorts` :必要な DWORD です。</span><span class="sxs-lookup"><span data-stu-id="5eaf6-157">`UseDynamicPorts`: A required DWORD.</span></span> <span data-ttu-id="5eaf6-158">選択したポート番号を保持するには、これを 0 に設定します。</span><span class="sxs-lookup"><span data-stu-id="5eaf6-158">Set this to 0 in order to retain the port numbers you've chosen.</span></span>
    - <span data-ttu-id="5eaf6-159">`HttpPort` :必要な DWORD です。</span><span class="sxs-lookup"><span data-stu-id="5eaf6-159">`HttpPort`: A required DWORD.</span></span> <span data-ttu-id="5eaf6-160">Device Portal が HTTP 接続をリッスンするポート番号を指定します。</span><span class="sxs-lookup"><span data-stu-id="5eaf6-160">Contains the port number that Device Portal will listen for HTTP connections on.</span></span>    
    - <span data-ttu-id="5eaf6-161">`HttpsPort` :必要な DWORD です。</span><span class="sxs-lookup"><span data-stu-id="5eaf6-161">`HttpsPort`: A required DWORD.</span></span> <span data-ttu-id="5eaf6-162">Device Portal が HTTPS 接続をリッスンするポート番号を指定します。</span><span class="sxs-lookup"><span data-stu-id="5eaf6-162">Contains the port number that Device Portal will listen for HTTPS connections on.</span></span>
    
<span data-ttu-id="5eaf6-163">同じレジストリ キー パスの下で、認証要件をオフにすることもできます。</span><span class="sxs-lookup"><span data-stu-id="5eaf6-163">Under the same regkey path, you can also turn off the authentication requirement:</span></span>
- <span data-ttu-id="5eaf6-164">`UseDefaultAuthorizer` - `0` 無効の場合、`1`有効になっています。</span><span class="sxs-lookup"><span data-stu-id="5eaf6-164">`UseDefaultAuthorizer` - `0` for disabled, `1` for enabled.</span></span>  
    - <span data-ttu-id="5eaf6-165">これによって、各接続の基本認証要件と HTTP から HTTPS へのリダイレクトの両方が制御されます。</span><span class="sxs-lookup"><span data-stu-id="5eaf6-165">This controls both the basic auth requirement for each connection and the redirect from HTTP to HTTPS.</span></span>  
    
### <a name="command-line-options-for-device-portal"></a><span data-ttu-id="5eaf6-166">Device Portal のコマンド ライン オプション</span><span class="sxs-lookup"><span data-stu-id="5eaf6-166">Command line options for Device Portal</span></span>
<span data-ttu-id="5eaf6-167">管理コマンド プロンプトから、Device Portal の各部分を有効にして構成することができます。</span><span class="sxs-lookup"><span data-stu-id="5eaf6-167">From an administrative command prompt, you can enable and configure parts of Device Portal.</span></span> <span data-ttu-id="5eaf6-168">実行することができます、最新のビルドでサポートされているコマンドのセットを表示するには `webmanagement /?`</span><span class="sxs-lookup"><span data-stu-id="5eaf6-168">To see the latest set of commands supported on your build, you can run `webmanagement /?`</span></span>

- <span data-ttu-id="5eaf6-169">`sc start webmanagement` または `sc stop webmanagement`</span><span class="sxs-lookup"><span data-stu-id="5eaf6-169">`sc start webmanagement` or `sc stop webmanagement`</span></span> 
    - <span data-ttu-id="5eaf6-170">サービスをオンまたはオフにします。</span><span class="sxs-lookup"><span data-stu-id="5eaf6-170">Turn the service on or off.</span></span> <span data-ttu-id="5eaf6-171">ここでも、開発者モードを有効にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="5eaf6-171">This still requires developer mode to be enabled.</span></span> 
- `-Credentials <username> <password>` 
    - <span data-ttu-id="5eaf6-172">Device Portal のユーザー名とパスワードを設定します。</span><span class="sxs-lookup"><span data-stu-id="5eaf6-172">Set a username and password for Device Portal.</span></span> <span data-ttu-id="5eaf6-173">ユーザー名は基本認証の標準に準拠している必要があるため、コロン (:) を含めることはできません。また、ブラウザーは標準的な方法ではすべての文字セットを解析しないため、標準の ASCII 文字 (a-z、A-Z、0-9) で構成されている必要があります。</span><span class="sxs-lookup"><span data-stu-id="5eaf6-173">The username must conform to Basic Auth standards, so cannot contain a colon (:) and should be built out of standard ASCII characters e.g. [a-zA-Z0-9] as browsers do not parse the full character set in a standard way.</span></span>  
- `-DeleteSSL` 
    - <span data-ttu-id="5eaf6-174">このオプションを指定すると、HTTPS 接続に使用される SSL 証明書のキャッシュがリセットされます。</span><span class="sxs-lookup"><span data-stu-id="5eaf6-174">This resets the SSL certificate cache used for HTTPS connections.</span></span> <span data-ttu-id="5eaf6-175">予期される証明書の警告ではなく、バイパスすることができない TLS 接続エラーが発生した場合は、このオプションで問題が解決される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="5eaf6-175">If you encounter TLS connection errors that cannot be bypassed (as opposed to the expected certificate warning), this option may fix the problem for you.</span></span> 
- `-SetCert <pfxPath> <pfxPassword>`
    - <span data-ttu-id="5eaf6-176">詳しくは、「[カスタムの SSL 証明書で Device Portal をプロビジョニングする](https://docs.microsoft.com/windows/uwp/debug-test-perf/device-portal-ssl)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5eaf6-176">See [Provisioning Device Portal with a custom SSL certificate](https://docs.microsoft.com/windows/uwp/debug-test-perf/device-portal-ssl) for details.</span></span>  
    - <span data-ttu-id="5eaf6-177">このオプションを指定すると、独自の SSL 証明書をインストールして、通常 Device Portal に表示される SSL 警告ページを修正することができます。</span><span class="sxs-lookup"><span data-stu-id="5eaf6-177">This allows you to install your own SSL certificate to fix the SSL warning page that is typically seen in Device Portal.</span></span> 
- `-Debug <various options for authentication, port selection, and tracing level>`
    - <span data-ttu-id="5eaf6-178">特定の構成と視覚的なデバッグ メッセージを使用して、Device Portal のスタンドアロン バージョンを実行します。</span><span class="sxs-lookup"><span data-stu-id="5eaf6-178">Run a standalone version of Device Portal with a specific configuration and visible debug messages.</span></span> <span data-ttu-id="5eaf6-179">これは、[パッケージ プラグイン](https://docs.microsoft.com/windows/uwp/debug-test-perf/device-portal-plugin)を構築するときに最も役立ちます。</span><span class="sxs-lookup"><span data-stu-id="5eaf6-179">This is most useful for building a [packaged plugin](https://docs.microsoft.com/windows/uwp/debug-test-perf/device-portal-plugin).</span></span> 
    - <span data-ttu-id="5eaf6-180">これをシステムとして実行して、パッケージ プラグインを完全にテストする方法について詳しくは、[MSDN Magazine の記事](https://msdn.microsoft.com/en-us/magazine/mt826332.aspx)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5eaf6-180">See the [MSDN Magazine article](https://msdn.microsoft.com/en-us/magazine/mt826332.aspx) for details on how to run this as System to fully test your packaged plugin.</span></span>

## <a name="common-errors-and-issues"></a><span data-ttu-id="5eaf6-181">一般的なエラーと問題</span><span class="sxs-lookup"><span data-stu-id="5eaf6-181">Common errors and issues</span></span>

<span data-ttu-id="5eaf6-182">デバイスのポータルを設定するときに発生する一般的なエラーを次に示します。</span><span class="sxs-lookup"><span data-stu-id="5eaf6-182">Below are some common errors that you may encounter when setting up Device Portal.</span></span>

### <a name="windowsupdatesearch-returns-invalid-number-of-updates-0x800f0950-cbseinvalidwindowsupdatecount"></a><span data-ttu-id="5eaf6-183">WindowsUpdateSearch が更新プログラムの無効な数を返します (0x800f0950 CBS_E_INVALID_WINDOWS_UPDATE_COUNT)</span><span class="sxs-lookup"><span data-stu-id="5eaf6-183">WindowsUpdateSearch returns invalid number of updates (0x800f0950 CBS_E_INVALID_WINDOWS_UPDATE_COUNT)</span></span>

<span data-ttu-id="5eaf6-184">Windows 10 のプレリリース版のビルドに開発者パッケージをインストールしようとするとき、このエラーが発生します。</span><span class="sxs-lookup"><span data-stu-id="5eaf6-184">You may get this error when trying to install the developer packages on a pre-release build of Windows 10.</span></span> <span data-ttu-id="5eaf6-185">これらのオンデマンドで機能 (FoD) パッケージは Windows 更新プログラムでホストされ、プレリリース ビルドをダウンロードするには、フライトを選択することが必要です。</span><span class="sxs-lookup"><span data-stu-id="5eaf6-185">These Feature-on-Demand (FoD) packages are hosted on Windows Update, and downloading them on pre-release builds requires that you opt into flighting.</span></span> <span data-ttu-id="5eaf6-186">フライティング適切なビルドおよびリング組み合わせのために、インストールが選択していない場合、ペイロードはダウンロードされません。</span><span class="sxs-lookup"><span data-stu-id="5eaf6-186">If your installation is not opted into flighting for the right build and ring combination, the payload will not be downloadable.</span></span> <span data-ttu-id="5eaf6-187">次のことを再確認してください。</span><span class="sxs-lookup"><span data-stu-id="5eaf6-187">Double-check the following:</span></span>

1. <span data-ttu-id="5eaf6-188">移動します**設定 > 更新とセキュリティ > Windows Insider Program**いることを確認し、 **Windows Insider アカウント**セクションには、正しいアカウント情報。</span><span class="sxs-lookup"><span data-stu-id="5eaf6-188">Navigate to **Settings > Update & Security > Windows Insider Program** and confirm that the **Windows Insider account** section has your correct account info.</span></span> <span data-ttu-id="5eaf6-189">そのセクションが表示されない場合は、選択**Windows Insider アカウント リンク**、電子メール アカウントを追加し、現れることを確認、 **Windows Insider アカウント**見出し (を選択する必要があります**Windows Insider アカウント リンク**実際にリンクする、新しく追加されたアカウント時間を秒)。</span><span class="sxs-lookup"><span data-stu-id="5eaf6-189">If you don't see that section, select **Link a Windows Insider account**, add your email account, and confirm that it shows up under the **Windows Insider account** heading (you may need to select **Link a Windows Insider account** a second time to actually link a newly added account).</span></span>
 
2. <span data-ttu-id="5eaf6-190">**受信にどのような種類のコンテンツを指定しては?**、ことを確認します**Windows のアクティブな開発**が選択されています。</span><span class="sxs-lookup"><span data-stu-id="5eaf6-190">Under **What kind of content would you like to receive?**, make sure **Active development of Windows** is selected.</span></span>
 
3. <span data-ttu-id="5eaf6-191">**新しいビルドを取得する速度ですか?**、ことを確認します**Windows Insider Fast**が選択されています。</span><span class="sxs-lookup"><span data-stu-id="5eaf6-191">Under **What pace do you want to get new builds?**, make sure **Windows Insider Fast** is selected.</span></span>
 
4. <span data-ttu-id="5eaf6-192">今すぐできる、FoDs をインストールします。</span><span class="sxs-lookup"><span data-stu-id="5eaf6-192">You should now be able to install the FoDs.</span></span> <span data-ttu-id="5eaf6-193">Windows Insider Fast にいるとまだことはできません、FoDs をインストール、くださいフィードバックを提供を下に、ログ ファイルのアタッチを確認したら場合**C:\Windows\Logs\CBS**します。</span><span class="sxs-lookup"><span data-stu-id="5eaf6-193">If you've confirmed that you're on Windows Insider Fast and still cannot install the FoDs, please provide feedback and attach the log files under **C:\Windows\Logs\CBS**.</span></span>

### <a name="sc-startservice-openservice-failed-1060-the-specified-service-does-not-exist-as-an-installed-service"></a><span data-ttu-id="5eaf6-194">[SC]StartService:OpenService FAILED 1060:指定されたサービスがインストールされているサービスとして存在しません</span><span class="sxs-lookup"><span data-stu-id="5eaf6-194">[SC] StartService: OpenService FAILED 1060: The specified service does not exist as an installed service</span></span>

<span data-ttu-id="5eaf6-195">開発者のパッケージがインストールされていない場合、このエラーが発生します。</span><span class="sxs-lookup"><span data-stu-id="5eaf6-195">You may get this error if the developer packages aren't installed.</span></span> <span data-ttu-id="5eaf6-196">せず、開発者のパッケージは、web 管理サービスはありません。</span><span class="sxs-lookup"><span data-stu-id="5eaf6-196">Without the developer packages, there is no web management service.</span></span> <span data-ttu-id="5eaf6-197">開発者のパッケージをもう一度インストールしてください。</span><span class="sxs-lookup"><span data-stu-id="5eaf6-197">Try installing the developer packages again.</span></span>

### <a name="cbs-cannot-start-download-because-the-system-is-on-metered-network-cbsemeterednetwork"></a><span data-ttu-id="5eaf6-198">システムが従量制課金接続 (CBS_E_METERED_NETWORK) 上にあるために、CBS はダウンロードを開始できません。</span><span class="sxs-lookup"><span data-stu-id="5eaf6-198">CBS cannot start download because the system is on metered network (CBS_E_METERED_NETWORK)</span></span>

<span data-ttu-id="5eaf6-199">従量制インターネット接続の場合、このエラーが発生します。</span><span class="sxs-lookup"><span data-stu-id="5eaf6-199">You may get this error if you're on a metered internet connection.</span></span> <span data-ttu-id="5eaf6-200">従量制課金接続で開発者パッケージをダウンロードすることはできません。</span><span class="sxs-lookup"><span data-stu-id="5eaf6-200">You won't be able to download the developer packages on a metered connection.</span></span>

## <a name="see-also"></a><span data-ttu-id="5eaf6-201">関連項目</span><span class="sxs-lookup"><span data-stu-id="5eaf6-201">See also</span></span>

* [<span data-ttu-id="5eaf6-202">Windows Device Portal の概要</span><span class="sxs-lookup"><span data-stu-id="5eaf6-202">Windows Device Portal overview</span></span>](device-portal.md)
* [<span data-ttu-id="5eaf6-203">デバイス ポータル core API リファレンス</span><span class="sxs-lookup"><span data-stu-id="5eaf6-203">Device Portal core API reference</span></span>](https://docs.microsoft.com/windows/uwp/debug-test-perf/device-portal-api-core)
