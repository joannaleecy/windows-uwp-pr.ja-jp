---
author: PatrickFarley
ms.assetid: 5c34c78e-9ff7-477b-87f6-a31367cd3f8b
title: Windows デスクトップ用 Device Portal
description: Windows デスクトップで Windows Device Portal の診断と自動化を利用する方法について説明します。
ms.author: pafarley
ms.date: 03/15/2018
ms.topic: article
keywords: windows 10, uwp, デバイス ポータル
ms.localizationpriority: medium
ms.openlocfilehash: 353afaa511eb382ba2d5772b9b88d3e6b5335ea6
ms.sourcegitcommit: 3257416aebb5a7b1515e107866806f8bd57845a8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/16/2018
ms.locfileid: "7145190"
---
# <a name="device-portal-for-windows-desktop"></a><span data-ttu-id="258ce-104">Windows デスクトップ用 Device Portal</span><span class="sxs-lookup"><span data-stu-id="258ce-104">Device Portal for Windows Desktop</span></span>



<span data-ttu-id="258ce-105">Windows Device Portal では、診断情報を表示し、ブラウザー ウィンドウから HTTP 経由でデスクトップを操作することができます。</span><span class="sxs-lookup"><span data-stu-id="258ce-105">Windows Device Portal lets you view diagnostic information and interact with your desktop over HTTP from a browser window.</span></span> <span data-ttu-id="258ce-106">Device Portal を使用すると、次の操作を実行できます。</span><span class="sxs-lookup"><span data-stu-id="258ce-106">You can use Device Portal to do the following:</span></span>
- <span data-ttu-id="258ce-107">実行されているプロセスの一覧を確認して操作する</span><span class="sxs-lookup"><span data-stu-id="258ce-107">See and manipulate a list of running processes</span></span>
- <span data-ttu-id="258ce-108">アプリをインストール、削除、起動、および終了する</span><span class="sxs-lookup"><span data-stu-id="258ce-108">Install, delete, launch, and terminate apps</span></span>
- <span data-ttu-id="258ce-109">Wi-Fi プロファイルの変更、シグナルの強さの表示、ipconfig の確認を行う</span><span class="sxs-lookup"><span data-stu-id="258ce-109">Change Wi-Fi profiles, view signal strength, and see ipconfig</span></span>
- <span data-ttu-id="258ce-110">CPU、メモリ、I/O、ネットワーク、および GPU の使用率のライブ グラフを表示する</span><span class="sxs-lookup"><span data-stu-id="258ce-110">View live graphs of CPU, memory, I/O, network, and GPU usage</span></span>
- <span data-ttu-id="258ce-111">プロセス ダンプを収集する</span><span class="sxs-lookup"><span data-stu-id="258ce-111">Collect process dumps</span></span>
- <span data-ttu-id="258ce-112">ETW トレースを収集する</span><span class="sxs-lookup"><span data-stu-id="258ce-112">Collect ETW traces</span></span> 
- <span data-ttu-id="258ce-113">サイドローディングされたアプリの分離ストレージを操作する</span><span class="sxs-lookup"><span data-stu-id="258ce-113">Manipulate the isolated storage of sideloaded apps</span></span>

## <a name="set-up-device-portal-on-windows-desktop"></a><span data-ttu-id="258ce-114">Windows デスクトップで Device Portal をセットアップする</span><span class="sxs-lookup"><span data-stu-id="258ce-114">Set up Device Portal on Windows Desktop</span></span>

### <a name="turn-on-developer-mode"></a><span data-ttu-id="258ce-115">開発者モードをオンにする</span><span class="sxs-lookup"><span data-stu-id="258ce-115">Turn on developer mode</span></span>

<span data-ttu-id="258ce-116">Windows 10 バージョン 1607 以降では、デスクトップ用の新しい機能の一部は開発者モードが有効なときだけ利用できます。</span><span class="sxs-lookup"><span data-stu-id="258ce-116">Starting in Windows 10, version 1607, some of the newer features for desktop are only available when developer mode is enabled.</span></span> <span data-ttu-id="258ce-117">開発者モードを有効にする方法については、「[デバイスを開発用に有効にする](../get-started/enable-your-device-for-development.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="258ce-117">For information about how to enable developer mode, see [Enable your device for development](../get-started/enable-your-device-for-development.md).</span></span>

> [!IMPORTANT]
> <span data-ttu-id="258ce-118">ネットワークや互換性の問題により、お使いのデバイスに開発者モードが正しくインストールされないことがあります。</span><span class="sxs-lookup"><span data-stu-id="258ce-118">Sometimes, due to network or compatibility issues, developer mode won't install correctly on your device.</span></span> <span data-ttu-id="258ce-119">これらの問題のトラブルシューティングについては、「[デバイスを開発用に有効にする](https://docs.microsoft.com/windows/uwp/get-started/enable-your-device-for-development#failure-to-install-developer-mode-package)」の関連セクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="258ce-119">See the [relevant section of Enable your device for development](https://docs.microsoft.com/windows/uwp/get-started/enable-your-device-for-development#failure-to-install-developer-mode-package) for help troubleshooting these issues.</span></span>

### <a name="turn-on-device-portal"></a><span data-ttu-id="258ce-120">Device Portal をオンにする</span><span class="sxs-lookup"><span data-stu-id="258ce-120">Turn on Device Portal</span></span>

<span data-ttu-id="258ce-121">**[設定]** の **[開発者向け]** セクションで、Device Portal を有効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="258ce-121">You can enable Device Portal in the **For developers** section of **Settings**.</span></span> <span data-ttu-id="258ce-122">Device Portal を有効にするときは、対応するユーザー名とパスワードも作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="258ce-122">When you enable it, you must also create a corresponding username and password.</span></span> <span data-ttu-id="258ce-123">Microsoft アカウントやその他の Windows の資格情報を使わないでください。</span><span class="sxs-lookup"><span data-stu-id="258ce-123">Do not use your Microsoft account or other Windows credentials.</span></span> 

![設定アプリの [Device Portal] セクション](images/device-portal/device-portal-desk-settings.png) 

<span data-ttu-id="258ce-125">Device Portal が有効になると、セクション下部に Web リンクが表示されます。</span><span class="sxs-lookup"><span data-stu-id="258ce-125">Once Device Portal is enabled, you will see web links at the bottom of the section.</span></span> <span data-ttu-id="258ce-126">表示される URL の末尾に付加されたポート番号をメモします。このポート番号は、Device Portal が有効になるとランダムに生成されるものですが、デスクトップを再起動するまで同じ番号を使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="258ce-126">Take note of the port number appended to the end of the listed URLs: this number is randomly generated when Device Portal is enabled but should remain consistent between reboots of the desktop.</span></span> <span data-ttu-id="258ce-127">同じ番号を使い続けるためにポート番号を手動で設定する場合は、「[ポート番号を設定する](device-portal-desktop.md#setting-port-numbers)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="258ce-127">If you'd like to set the port numbers manually so that they remain permanent, see [Setting port numbers](device-portal-desktop.md#setting-port-numbers).</span></span>

<span data-ttu-id="258ce-128">これらのリンクから、ローカル ネットワーク (VPN を含む) 経由、またはローカル ホスト経由のいずれかの方法で Device Portal に接続できます。</span><span class="sxs-lookup"><span data-stu-id="258ce-128">These links offer two ways to connect to Device Portal: over the local network (including VPN) or through the local host.</span></span>

### <a name="connect-to-device-portal"></a><span data-ttu-id="258ce-129">Device Portal に接続する</span><span class="sxs-lookup"><span data-stu-id="258ce-129">Connect to Device Portal</span></span>

<span data-ttu-id="258ce-130">ローカル ホスト経由で接続するには、ブラウザー ウィンドウを開き、使用している接続の種類に関して次に示すアドレスを入力します。</span><span class="sxs-lookup"><span data-stu-id="258ce-130">To connet through local host, open a browser window and enter the address shown here for the connection type you're using.</span></span>

* <span data-ttu-id="258ce-131">ローカルホスト: `http://127.0.0.1:<PORT>` または</span><span class="sxs-lookup"><span data-stu-id="258ce-131">Localhost: `http://127.0.0.1:<PORT>` or</span></span> `http://localhost:<PORT>`
* <span data-ttu-id="258ce-132">ローカル ネットワーク: </span><span class="sxs-lookup"><span data-stu-id="258ce-132">Local Network:</span></span> `https://<IP address of the desktop>:<PORT>`

<span data-ttu-id="258ce-133">認証とセキュリティで保護された通信には HTTPS が必要です。</span><span class="sxs-lookup"><span data-stu-id="258ce-133">HTTPS is required for authentication and secure communication.</span></span>

<span data-ttu-id="258ce-134">テスト ラボなど、保護された環境で Device Portal を使っている場合、ローカル ネットワーク上のすべてのユーザーを信頼していて、デバイス上に個人情報が保存されておらず、固有の要件もない場合は、[認証] オプションを無効にできます。</span><span class="sxs-lookup"><span data-stu-id="258ce-134">If you are using Device Portal in a protected environment, like a test lab, in which you trust everyone on your local network, have no personal information on the device, and have unique requirements, you can disable the Authentication option.</span></span> <span data-ttu-id="258ce-135">これにより、暗号化されていない通信が有効化され、コンピューターの IP アドレスを知っているすべてのユーザーが接続して制御できるようになります。</span><span class="sxs-lookup"><span data-stu-id="258ce-135">This enables unencrypted communication, and allows anyone with the IP address of your computer to connect to and control it.</span></span>

## <a name="device-portal-content-on-windows-desktop"></a><span data-ttu-id="258ce-136">Windows デスクトップ上の Device Portal のコンテンツ</span><span class="sxs-lookup"><span data-stu-id="258ce-136">Device Portal content on Windows Desktop</span></span>

<span data-ttu-id="258ce-137">Windows デスクトップの Device Portal では、標準のページのセットが提供されます。</span><span class="sxs-lookup"><span data-stu-id="258ce-137">Device Portal on Windows Desktop provides the standard set of pages.</span></span> <span data-ttu-id="258ce-138">これらの詳しい説明については、「[Windows Device Portal の概要](device-portal.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="258ce-138">For detailed descriptions of these, see [Windows Device Portal overview](device-portal.md).</span></span>

- <span data-ttu-id="258ce-139">アプリ マネージャー</span><span class="sxs-lookup"><span data-stu-id="258ce-139">Apps manager</span></span>
- <span data-ttu-id="258ce-140">エクスプローラー</span><span class="sxs-lookup"><span data-stu-id="258ce-140">File explorer</span></span>
- <span data-ttu-id="258ce-141">実行中のプロセス</span><span class="sxs-lookup"><span data-stu-id="258ce-141">Running Processes</span></span>
- <span data-ttu-id="258ce-142">パフォーマンス</span><span class="sxs-lookup"><span data-stu-id="258ce-142">Performance</span></span>
- <span data-ttu-id="258ce-143">デバッグ</span><span class="sxs-lookup"><span data-stu-id="258ce-143">Debug</span></span>
- <span data-ttu-id="258ce-144">Windows イベント トレーシング (ETW)</span><span class="sxs-lookup"><span data-stu-id="258ce-144">Event Tracing for Windows (ETW)</span></span>
- <span data-ttu-id="258ce-145">パフォーマンス トレース</span><span class="sxs-lookup"><span data-stu-id="258ce-145">Performance tracing</span></span>
- <span data-ttu-id="258ce-146">デバイス マネージャー</span><span class="sxs-lookup"><span data-stu-id="258ce-146">Device manager</span></span>
- <span data-ttu-id="258ce-147">ネットワーク</span><span class="sxs-lookup"><span data-stu-id="258ce-147">Networking</span></span>
- <span data-ttu-id="258ce-148">クラッシュ データ</span><span class="sxs-lookup"><span data-stu-id="258ce-148">Crash data</span></span>
- <span data-ttu-id="258ce-149">機能</span><span class="sxs-lookup"><span data-stu-id="258ce-149">Features</span></span>
- <span data-ttu-id="258ce-150">Mixed Reality</span><span class="sxs-lookup"><span data-stu-id="258ce-150">Mixed Reality</span></span>
- <span data-ttu-id="258ce-151">ストリーミング インストール デバッガー</span><span class="sxs-lookup"><span data-stu-id="258ce-151">Streaming Install Debugger</span></span>
- <span data-ttu-id="258ce-152">位置情報</span><span class="sxs-lookup"><span data-stu-id="258ce-152">Location</span></span>
- <span data-ttu-id="258ce-153">スクラッチ</span><span class="sxs-lookup"><span data-stu-id="258ce-153">Scratch</span></span>

## <a name="more-device-portal-options"></a><span data-ttu-id="258ce-154">Device Portal のその他のオプション</span><span class="sxs-lookup"><span data-stu-id="258ce-154">More Device Portal options</span></span>
### <a name="registry-based-configuration-for-device-portal"></a><span data-ttu-id="258ce-155">Device Portal のレジストリ ベースの構成</span><span class="sxs-lookup"><span data-stu-id="258ce-155">Registry-based configuration for Device Portal</span></span>

<span data-ttu-id="258ce-156">デバイス ポータルのポート番号 (80、443 など) を選択する場合は、次のレジストリ キーを設定することができます。</span><span class="sxs-lookup"><span data-stu-id="258ce-156">If you would like to select port numbers for Device Portal (such as 80 and 443), you can set the following regkeys:</span></span>

- <span data-ttu-id="258ce-157">以下のパスの下</span><span class="sxs-lookup"><span data-stu-id="258ce-157">Under</span></span> `HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\WebManagement\Service`
    - `UseDynamicPorts`<span data-ttu-id="258ce-158">: 必須の DWORD。</span><span class="sxs-lookup"><span data-stu-id="258ce-158">: A required DWORD.</span></span> <span data-ttu-id="258ce-159">選択したポート番号を保持するには、これを 0 に設定します。</span><span class="sxs-lookup"><span data-stu-id="258ce-159">Set this to 0 in order to retain the port numbers you've chosen.</span></span>
    - `HttpPort`<span data-ttu-id="258ce-160">: 必須の DWORD。</span><span class="sxs-lookup"><span data-stu-id="258ce-160">: A required DWORD.</span></span> <span data-ttu-id="258ce-161">Device Portal が HTTP 接続をリッスンするポート番号を指定します。</span><span class="sxs-lookup"><span data-stu-id="258ce-161">Contains the port number that Device Portal will listen for HTTP connections on.</span></span>    
    - `HttpsPort`<span data-ttu-id="258ce-162">: 必須の DWORD。</span><span class="sxs-lookup"><span data-stu-id="258ce-162">: A required DWORD.</span></span> <span data-ttu-id="258ce-163">Device Portal が HTTPS 接続をリッスンするポート番号を指定します。</span><span class="sxs-lookup"><span data-stu-id="258ce-163">Contains the port number that Device Portal will listen for HTTPS connections on.</span></span>
    
<span data-ttu-id="258ce-164">同じレジストリ キー パスの下で、認証要件をオフにすることもできます。</span><span class="sxs-lookup"><span data-stu-id="258ce-164">Under the same regkey path, you can also turn off the authentication requirement:</span></span>
- `UseDefaultAuthorizer`<span data-ttu-id="258ce-165"> - `0` (無効)、`1` (有効)。</span><span class="sxs-lookup"><span data-stu-id="258ce-165"> - `0` for disabled, `1` for enabled.</span></span>  
    - <span data-ttu-id="258ce-166">これによって、各接続の基本認証要件と HTTP から HTTPS へのリダイレクトの両方が制御されます。</span><span class="sxs-lookup"><span data-stu-id="258ce-166">This controls both the basic auth requirement for each connection and the redirect from HTTP to HTTPS.</span></span>  
    
### <a name="command-line-options-for-device-portal"></a><span data-ttu-id="258ce-167">Device Portal のコマンド ライン オプション</span><span class="sxs-lookup"><span data-stu-id="258ce-167">Command line options for Device Portal</span></span>
<span data-ttu-id="258ce-168">管理コマンド プロンプトから、Device Portal の各部分を有効にして構成することができます。</span><span class="sxs-lookup"><span data-stu-id="258ce-168">From an administrative command prompt, you can enable and configure parts of Device Portal.</span></span> <span data-ttu-id="258ce-169">ビルドでサポートされている最新のコマンド セットを表示するには、このコマンドを実行することができます。</span><span class="sxs-lookup"><span data-stu-id="258ce-169">To see the latest set of commands supported on your build, you can run</span></span> `webmanagement /?`

- `sc start webmanagement` <span data-ttu-id="258ce-170">または</span><span class="sxs-lookup"><span data-stu-id="258ce-170">or</span></span> `sc stop webmanagement` 
    - <span data-ttu-id="258ce-171">サービスをオンまたはオフにします。</span><span class="sxs-lookup"><span data-stu-id="258ce-171">Turn the service on or off.</span></span> <span data-ttu-id="258ce-172">ここでも、開発者モードを有効にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="258ce-172">This still requires developer mode to be enabled.</span></span> 
- `-Credentials <username> <password>` 
    - <span data-ttu-id="258ce-173">Device Portal のユーザー名とパスワードを設定します。</span><span class="sxs-lookup"><span data-stu-id="258ce-173">Set a username and password for Device Portal.</span></span> <span data-ttu-id="258ce-174">ユーザー名は基本認証の標準に準拠している必要があるため、コロン (:) を含めることはできません。また、ブラウザーは標準的な方法ではすべての文字セットを解析しないため、標準の ASCII 文字 (a-z、A-Z、0-9) で構成されている必要があります。</span><span class="sxs-lookup"><span data-stu-id="258ce-174">The username must conform to Basic Auth standards, so cannot contain a colon (:) and should be built out of standard ASCII characters e.g. [a-zA-Z0-9] as browsers do not parse the full character set in a standard way.</span></span>  
- `-DeleteSSL` 
    - <span data-ttu-id="258ce-175">このオプションを指定すると、HTTPS 接続に使用される SSL 証明書のキャッシュがリセットされます。</span><span class="sxs-lookup"><span data-stu-id="258ce-175">This resets the SSL certificate cache used for HTTPS connections.</span></span> <span data-ttu-id="258ce-176">予期される証明書の警告ではなく、バイパスすることができない TLS 接続エラーが発生した場合は、このオプションで問題が解決される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="258ce-176">If you encounter TLS connection errors that cannot be bypassed (as opposed to the expected certificate warning), this option may fix the problem for you.</span></span> 
- `-SetCert <pfxPath> <pfxPassword>`
    - <span data-ttu-id="258ce-177">詳しくは、「[カスタムの SSL 証明書で Device Portal をプロビジョニングする](https://docs.microsoft.com/windows/uwp/debug-test-perf/device-portal-ssl)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="258ce-177">See [Provisioning Device Portal with a custom SSL certificate](https://docs.microsoft.com/windows/uwp/debug-test-perf/device-portal-ssl) for details.</span></span>  
    - <span data-ttu-id="258ce-178">このオプションを指定すると、独自の SSL 証明書をインストールして、通常 Device Portal に表示される SSL 警告ページを修正することができます。</span><span class="sxs-lookup"><span data-stu-id="258ce-178">This allows you to install your own SSL certificate to fix the SSL warning page that is typically seen in Device Portal.</span></span> 
- `-Debug <various options for authentication, port selection, and tracing level>`
    - <span data-ttu-id="258ce-179">特定の構成と視覚的なデバッグ メッセージを使用して、Device Portal のスタンドアロン バージョンを実行します。</span><span class="sxs-lookup"><span data-stu-id="258ce-179">Run a standalone version of Device Portal with a specific configuration and visible debug messages.</span></span> <span data-ttu-id="258ce-180">これは、[パッケージ プラグイン](https://docs.microsoft.com/windows/uwp/debug-test-perf/device-portal-plugin)を構築するときに最も役立ちます。</span><span class="sxs-lookup"><span data-stu-id="258ce-180">This is most useful for building a [packaged plugin](https://docs.microsoft.com/windows/uwp/debug-test-perf/device-portal-plugin).</span></span> 
    - <span data-ttu-id="258ce-181">これをシステムとして実行して、パッケージ プラグインを完全にテストする方法について詳しくは、[MSDN Magazine の記事](https://msdn.microsoft.com/en-us/magazine/mt826332.aspx)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="258ce-181">See the [MSDN Magazine article](https://msdn.microsoft.com/en-us/magazine/mt826332.aspx) for details on how to run this as System to fully test your packaged plugin.</span></span>

## <a name="see-also"></a><span data-ttu-id="258ce-182">関連項目</span><span class="sxs-lookup"><span data-stu-id="258ce-182">See also</span></span>

* [<span data-ttu-id="258ce-183">Windows Device Portal の概要</span><span class="sxs-lookup"><span data-stu-id="258ce-183">Windows Device Portal overview</span></span>](device-portal.md)
* [<span data-ttu-id="258ce-184">デバイス ポータル コア API リファレンス</span><span class="sxs-lookup"><span data-stu-id="258ce-184">Device Portal core API reference</span></span>](https://docs.microsoft.com/windows/uwp/debug-test-perf/device-portal-api-core)
