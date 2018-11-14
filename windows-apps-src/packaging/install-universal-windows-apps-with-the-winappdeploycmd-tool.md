---
author: laurenhughes
ms.assetid: 6AA037C0-35ED-4B9C-80A3-5E144D7EE94B
title: WinAppDeployCmd.exe ツールを使ったアプリのインストール
description: Windows アプリケーションの展開 (WinAppDeployCmd.exe) は、すべての windows 10 デバイスを windows 10 PC からユニバーサル Windows プラットフォーム (UWP) アプリの展開に使用できるコマンド ライン ツールです。
ms.author: lahugh
ms.date: 09/30/2018
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 13468ce3b74992c026d94223b5e67aea99d79991
ms.sourcegitcommit: bdc40b08cbcd46fc379feeda3c63204290e055af
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/08/2018
ms.locfileid: "6152072"
---
# <a name="install-apps-with-the-winappdeploycmdexe-tool"></a><span data-ttu-id="cc564-104">WinAppDeployCmd.exe ツールを使ったアプリのインストール</span><span class="sxs-lookup"><span data-stu-id="cc564-104">Install apps with the WinAppDeployCmd.exe tool</span></span>


<span data-ttu-id="cc564-105">Windows アプリケーションの展開 (WinAppDeployCmd.exe) は、すべての windows 10 デバイスを windows 10 PC からユニバーサル Windows プラットフォーム (UWP) アプリの展開に使用できるコマンド ライン ツールです。</span><span class="sxs-lookup"><span data-stu-id="cc564-105">Windows Application Deployment (WinAppDeployCmd.exe) is a command line tool that can use to deploy a Universal Windows Platform (UWP) app from a Windows10 PC to any Windows10 device.</span></span> <span data-ttu-id="cc564-106">このツールを使用すると、デバイスが、windows 10 USB で接続されているか同じサブネット上に利用可能なそのアプリの Microsoft Visual Studio や、ソリューションがなくても、アプリ パッケージを展開します。</span><span class="sxs-lookup"><span data-stu-id="cc564-106">You can use this tool to deploy an app package when the Windows10 device is connected by USB or available on the same subnet without needing Microsoft Visual Studio or the solution for that app.</span></span> <span data-ttu-id="cc564-107">最初にパッケージ化することなく、リモート PC や Xbox One にアプリを展開することもできます。</span><span class="sxs-lookup"><span data-stu-id="cc564-107">You can also deploy the app without packaging first to a remote PC or Xbox One.</span></span> <span data-ttu-id="cc564-108">この記事では、このツールを使って UWP アプリをインストールする方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="cc564-108">This article describes how to install UWP apps using this tool.</span></span>

<span data-ttu-id="cc564-109">コマンド プロンプトまたはスクリプト ファイルから WinAppDeployCmd ツールを実行するインストールされている windows 10 SDK だけ必要があります。</span><span class="sxs-lookup"><span data-stu-id="cc564-109">You just need the Windows10 SDK installed to run the WinAppDeployCmd tool from a command prompt or a script file.</span></span> <span data-ttu-id="cc564-110">WinAppDeployCmd.exe でアプリをインストールすると.appx/.msix ファイルや AppxManifest (ルーズ ファイル用) を使って windows 10 デバイスにアプリのサイド アンド ロードします。</span><span class="sxs-lookup"><span data-stu-id="cc564-110">When you install an app with WinAppDeployCmd.exe, this uses the .appx/.msix file or AppxManifest(for loose files) to side-load your app onto a Windows10 device.</span></span> <span data-ttu-id="cc564-111">このコマンドによって、アプリに必要な証明書はインストールされません。</span><span class="sxs-lookup"><span data-stu-id="cc564-111">This command does not install the certificate required for your app.</span></span> <span data-ttu-id="cc564-112">アプリを実行するには、windows 10 デバイスは開発者モードまたは既にインストールされている証明書がある必要があります。</span><span class="sxs-lookup"><span data-stu-id="cc564-112">To run the app, the Windows10 device must be in developer mode or already have the certificate installed.</span></span>

<span data-ttu-id="cc564-113">モバイル デバイスに展開するには、最初にパッケージを作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="cc564-113">To deploy to mobile devices, you must first create a package.</span></span> <span data-ttu-id="cc564-114">詳しくは、[こちら](https://msdn.microsoft.com/windows/uwp/packaging/packaging-uwp-apps)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="cc564-114">For more information, see [here](https://msdn.microsoft.com/windows/uwp/packaging/packaging-uwp-apps).</span></span>

<span data-ttu-id="cc564-115">**WinAppDeployCmd.exe**ツールは、windows 10 PC: **C:\\Program Files (x86) \\Windows Kits\\10\\bin\\<SDK Version>\\x86\\WinAppDeployCmd.exe** (SDK のインストール パスに基づきます)。</span><span class="sxs-lookup"><span data-stu-id="cc564-115">The **WinAppDeployCmd.exe** tool is located here on your Windows10 PC: **C:\\Program Files (x86)\\Windows Kits\\10\\bin\\<SDK Version>\\x86\\WinAppDeployCmd.exe** (based on your installation path for the SDK).</span></span> 
> [!NOTE]
> <span data-ttu-id="cc564-116">SDK のバージョン 15063 以降では、SDK はバージョン固有のフォルダー内にサイド バイ サイドでインストールされます。</span><span class="sxs-lookup"><span data-stu-id="cc564-116">In version 15063 and later of the SDK, the SDK is installed side by side within version-specific folders.</span></span>  <span data-ttu-id="cc564-117">以前の SDK (14393 以前) は、親フォルダーに直接書き込まれます。</span><span class="sxs-lookup"><span data-stu-id="cc564-117">Previous SDKs (prior to and including 14393) are written directly to the parent folder.</span></span>

<span data-ttu-id="cc564-118">まず、windows 10 デバイスを同じサブネットに接続または USB 接続を使用して、windows 10 コンピューターに直接接続します。</span><span class="sxs-lookup"><span data-stu-id="cc564-118">First, connect your Windows10 device to the same subnet or connect it directly to your Windows10 machine with a USB connection.</span></span> <span data-ttu-id="cc564-119">この記事ではその後、このコマンドの次の構文と例を使って UWP アプリを展開します。</span><span class="sxs-lookup"><span data-stu-id="cc564-119">Then use the following syntax and examples of this command later in this article to deploy your UWP app:</span></span>

## <a name="winappdeploycmd-syntax-and-options"></a><span data-ttu-id="cc564-120">WinAppDeployCmd の構文とオプション</span><span class="sxs-lookup"><span data-stu-id="cc564-120">WinAppDeployCmd syntax and options</span></span>

<span data-ttu-id="cc564-121">**WinAppDeployCmd.exe** で使用される一般的な構文を次に示します。</span><span class="sxs-lookup"><span data-stu-id="cc564-121">This is the general syntax used for **WinAppDeployCmd.exe**:</span></span>
```syntax
WinAppDeployCmd command -option <argument>
```

<span data-ttu-id="cc564-122">さまざまなコマンドを使用する他の構文例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="cc564-122">Here are some additional syntax examples for using various commands:</span></span>
```syntax
WinAppDeployCmd devices
WinAppDeployCmd devices <x>
WinAppDeployCmd install -file <path> -ip <address>
WinAppDeployCmd install -file <path> -guid <address> -pin <p>
WinAppDeployCmd install -file <path> -ip <address> -dependency <a> <b> 
WinAppDeployCmd install -file <path> -guid <address> -dependency <a> <b>
WinAppDeployCmd uninstall -file <path>
WinAppDeployCmd uninstall -package <name>
WinAppDeployCmd update -file <path>
WinAppDeployCmd list -ip <address>
WinAppDeployCmd list -guid <address>
WinAppDeployCmd deployfiles -file <path> -remotedeploydir <remoterelativepath> -ip <address>
WinAppDeployCmd registerfiles -remotedeploydir <remoterelativepath> -ip <address>
WinAppDeployCmd addcreds -credserver <server> -credusername <username> -credpassword <password> -ip <address>
WinAppDeployCmd getcreds -credserver <server> -ip <address>
WinAppDeployCmd deletecreds -credserver <server> -ip <address>
```

<span data-ttu-id="cc564-123">ターゲット デバイスでアプリをインストール/アンインストールしたり、既にインストールされているアプリを更新したりできます。</span><span class="sxs-lookup"><span data-stu-id="cc564-123">You can install or uninstall an app on the target device, or you can update an app that's already installed.</span></span> <span data-ttu-id="cc564-124">既にインストールされているアプリによって保存されたデータや設定を保持するには、**install** オプションの代わりに **update** オプションを使います。</span><span class="sxs-lookup"><span data-stu-id="cc564-124">To keep data or settings saved by an app that's already installed, use the **update** options instead of the **install** options.</span></span>

<span data-ttu-id="cc564-125">次の表では、**WinAppDeployCmd.exe** のコマンドについて説明します。</span><span class="sxs-lookup"><span data-stu-id="cc564-125">The following table describes the commands for **WinAppDeployCmd.exe**.</span></span>


| **<span data-ttu-id="cc564-126">コマンド</span><span class="sxs-lookup"><span data-stu-id="cc564-126">Command</span></span>**  | **<span data-ttu-id="cc564-127">説明</span><span class="sxs-lookup"><span data-stu-id="cc564-127">Description</span></span>**                                                     |
|--------------|---------------------------------------------------------------------|
| <span data-ttu-id="cc564-128">devices</span><span class="sxs-lookup"><span data-stu-id="cc564-128">devices</span></span>      | <span data-ttu-id="cc564-129">利用可能なネットワーク デバイスの一覧を表示します。</span><span class="sxs-lookup"><span data-stu-id="cc564-129">Show the list of available network devices.</span></span>                         |
| <span data-ttu-id="cc564-130">install</span><span class="sxs-lookup"><span data-stu-id="cc564-130">install</span></span>      | <span data-ttu-id="cc564-131">ターゲット デバイスに UWP アプリ パッケージをインストールします。</span><span class="sxs-lookup"><span data-stu-id="cc564-131">Install a UWP app package to the target device.</span></span>                     |
| <span data-ttu-id="cc564-132">update</span><span class="sxs-lookup"><span data-stu-id="cc564-132">update</span></span>       | <span data-ttu-id="cc564-133">ターゲット デバイスに既にインストールされている UWP アプリを更新します。</span><span class="sxs-lookup"><span data-stu-id="cc564-133">Update a UWP app that is already installed on the target device.</span></span>    |
| <span data-ttu-id="cc564-134">list</span><span class="sxs-lookup"><span data-stu-id="cc564-134">list</span></span>         | <span data-ttu-id="cc564-135">ターゲット デバイスに既にインストールされている UWP アプリの一覧を表示します。</span><span class="sxs-lookup"><span data-stu-id="cc564-135">Show the list of UWP apps installed on the specified target device.</span></span> |
| <span data-ttu-id="cc564-136">uninstall</span><span class="sxs-lookup"><span data-stu-id="cc564-136">uninstall</span></span>    | <span data-ttu-id="cc564-137">指定したアプリ パッケージをターゲット デバイスからアンインストールします。</span><span class="sxs-lookup"><span data-stu-id="cc564-137">Uninstall the specified app package from the target device.</span></span>         |
| <span data-ttu-id="cc564-138">deployfiles</span><span class="sxs-lookup"><span data-stu-id="cc564-138">deployfiles</span></span>  | <span data-ttu-id="cc564-139">ターゲット パスにあるルーズ ファイル アプリをデバイスのリモート相対パスにコピーします。</span><span class="sxs-lookup"><span data-stu-id="cc564-139">Copy over loose file app at the target path to the remote relative path on the device.</span></span>|
| <span data-ttu-id="cc564-140">registerfiles</span><span class="sxs-lookup"><span data-stu-id="cc564-140">registerfiles</span></span>| <span data-ttu-id="cc564-141">リモートの展開ディレクトリにルーズ ファイル アプリを登録します。</span><span class="sxs-lookup"><span data-stu-id="cc564-141">Register the loose file app at the remote deploy directory.</span></span>         |
| <span data-ttu-id="cc564-142">addcreds</span><span class="sxs-lookup"><span data-stu-id="cc564-142">addcreds</span></span>     | <span data-ttu-id="cc564-143">Xbox に資格情報を追加して、アプリを登録するためにネットワークの場所にアクセスすることを許可します。</span><span class="sxs-lookup"><span data-stu-id="cc564-143">Add credentials to an Xbox to allow it to access a network location for app registration.</span></span>|
| <span data-ttu-id="cc564-144">getcreds</span><span class="sxs-lookup"><span data-stu-id="cc564-144">getcreds</span></span>     | <span data-ttu-id="cc564-145">ネットワーク共有からアプリケーションを実行するときにターゲットが使用するネットワーク資格情報を取得します。</span><span class="sxs-lookup"><span data-stu-id="cc564-145">Get network credentials for the target uses when running an application from a network share.</span></span>|
| <span data-ttu-id="cc564-146">deletecreds</span><span class="sxs-lookup"><span data-stu-id="cc564-146">deletecreds</span></span>  | <span data-ttu-id="cc564-147">ネットワーク共有からアプリケーションを実行するときにターゲットが使用するネットワーク資格情報を削除します。</span><span class="sxs-lookup"><span data-stu-id="cc564-147">Delete network credentials the target uses when running an application from a network share.</span></span>|


<span data-ttu-id="cc564-148">次の表では、**WinAppDeployCmd.exe** のオプションについて説明します。</span><span class="sxs-lookup"><span data-stu-id="cc564-148">The following table describes the options for **WinAppDeployCmd.exe**.</span></span>


| **<span data-ttu-id="cc564-149">コマンド</span><span class="sxs-lookup"><span data-stu-id="cc564-149">Command</span></span>**  | **<span data-ttu-id="cc564-150">説明</span><span class="sxs-lookup"><span data-stu-id="cc564-150">Description</span></span>**  |
|--------------|------------------|
| <span data-ttu-id="cc564-151">-h (-help)</span><span class="sxs-lookup"><span data-stu-id="cc564-151">-h (-help)</span></span>       | <span data-ttu-id="cc564-152">コマンド、オプション、引数を表示します。</span><span class="sxs-lookup"><span data-stu-id="cc564-152">Show the commands, options and arguments.</span></span> |
| <span data-ttu-id="cc564-153">-ip</span><span class="sxs-lookup"><span data-stu-id="cc564-153">-ip</span></span>              | <span data-ttu-id="cc564-154">ターゲット デバイスの IP アドレス。</span><span class="sxs-lookup"><span data-stu-id="cc564-154">IP address of the target device.</span></span> |
| <span data-ttu-id="cc564-155">-g (-guid)</span><span class="sxs-lookup"><span data-stu-id="cc564-155">-g (-guid)</span></span>       | <span data-ttu-id="cc564-156">ターゲット デバイスの一意の識別子。</span><span class="sxs-lookup"><span data-stu-id="cc564-156">Unique identifier of the target device.</span></span>|
| <span data-ttu-id="cc564-157">-d (-dependency)</span><span class="sxs-lookup"><span data-stu-id="cc564-157">-d (-dependency)</span></span> | <span data-ttu-id="cc564-158">(省略可能) パッケージの依存関係のそれぞれの依存パスを指定します。</span><span class="sxs-lookup"><span data-stu-id="cc564-158">(Optional) Specifies the dependency path for each of the package dependencies.</span></span> <span data-ttu-id="cc564-159">パスを指定しない場合、ツールはアプリ パッケージのルート ディレクトリと SDK のディレクトリで依存関係を探します。</span><span class="sxs-lookup"><span data-stu-id="cc564-159">If no path is specified, the tool searches for dependencies in the root directory for the app package and the SDK directories.</span></span>|
| <span data-ttu-id="cc564-160">-f (-file)</span><span class="sxs-lookup"><span data-stu-id="cc564-160">-f (-file)</span></span>       | <span data-ttu-id="cc564-161">インストール、更新、またはアンインストールするアプリ パッケージのファイル パス。</span><span class="sxs-lookup"><span data-stu-id="cc564-161">File path for the app package to install, update or uninstall.</span></span>|
| <span data-ttu-id="cc564-162">-p (-package)</span><span class="sxs-lookup"><span data-stu-id="cc564-162">-p (-package)</span></span>    | <span data-ttu-id="cc564-163">アンインストールするアプリ パッケージの完全なパッケージ名 </span><span class="sxs-lookup"><span data-stu-id="cc564-163">The full package name for the app package to uninstall.</span></span> <span data-ttu-id="cc564-164">(list コマンドを使って、デバイスに既にインストールされているパッケージの完全な名前を見つけることができます)。</span><span class="sxs-lookup"><span data-stu-id="cc564-164">(You can use the list command to find the full names for packages already installed on the device)</span></span> |
| <span data-ttu-id="cc564-165">-pin</span><span class="sxs-lookup"><span data-stu-id="cc564-165">-pin</span></span>             | <span data-ttu-id="cc564-166">ターゲット デバイスとの接続を確立するために求められた場合に指定する PIN。</span><span class="sxs-lookup"><span data-stu-id="cc564-166">A pin if it is required to establish a connection with the target device.</span></span> <span data-ttu-id="cc564-167">(認証が必要な場合に -pin オプションを指定して再試行するように求められます)</span><span class="sxs-lookup"><span data-stu-id="cc564-167">(You will be prompted to retry with the -pin option if authentication is required)</span></span> |
| <span data-ttu-id="cc564-168">-credserver</span><span class="sxs-lookup"><span data-stu-id="cc564-168">-credserver</span></span>      | <span data-ttu-id="cc564-169">ターゲットが使用するネットワーク資格情報のサーバー名。</span><span class="sxs-lookup"><span data-stu-id="cc564-169">The server name of the network credentials for use by the target.</span></span> |
| <span data-ttu-id="cc564-170">-credusername</span><span class="sxs-lookup"><span data-stu-id="cc564-170">-credusername</span></span>    | <span data-ttu-id="cc564-171">ターゲットが使用するネットワーク資格情報のユーザー名。</span><span class="sxs-lookup"><span data-stu-id="cc564-171">The user name of the network credentials for use by the target.</span></span> |
| <span data-ttu-id="cc564-172">-credpassword</span><span class="sxs-lookup"><span data-stu-id="cc564-172">-credpassword</span></span>    | <span data-ttu-id="cc564-173">ターゲットが使用するネットワーク資格情報のパスワード。</span><span class="sxs-lookup"><span data-stu-id="cc564-173">The password of the network credentials for use by the target.</span></span> |
| <span data-ttu-id="cc564-174">-connecttimeout</span><span class="sxs-lookup"><span data-stu-id="cc564-174">-connecttimeout</span></span>  | <span data-ttu-id="cc564-175">デバイスに接続するときに使用されるタイムアウト (秒)。</span><span class="sxs-lookup"><span data-stu-id="cc564-175">The timeout in seconds used when connecting to the device.</span></span> |
| <span data-ttu-id="cc564-176">-remotedeploydir</span><span class="sxs-lookup"><span data-stu-id="cc564-176">-remotedeploydir</span></span> | <span data-ttu-id="cc564-177">リモート デバイス上のファイルのコピー先の相対ディレクトリ パスと名前。これは既知の自動的に決定されたリモート展開フォルダーになります。</span><span class="sxs-lookup"><span data-stu-id="cc564-177">Relative directory path/name to copy files over to on the remote device; This will be a well-known, automatically determined remote deployment folder.</span></span> |
| <span data-ttu-id="cc564-178">-deleteextrafile</span><span class="sxs-lookup"><span data-stu-id="cc564-178">-deleteextrafile</span></span> | <span data-ttu-id="cc564-179">ソース ディレクトリに一致するようにリモート ディレクトリ内の既存のファイルを消去する必要があるかどうかを指定するスイッチ。</span><span class="sxs-lookup"><span data-stu-id="cc564-179">Switch to indicate whether existing files in the remote directory should be purged to match the source directory.</span></span> |


<span data-ttu-id="cc564-180">次の表では、**WinAppDeployCmd.exe** のオプションについて説明します。</span><span class="sxs-lookup"><span data-stu-id="cc564-180">The following table describes the options for **WinAppDeployCmd.exe**.</span></span>

| **<span data-ttu-id="cc564-181">引数</span><span class="sxs-lookup"><span data-stu-id="cc564-181">Argument</span></span>**           | **<span data-ttu-id="cc564-182">説明</span><span class="sxs-lookup"><span data-stu-id="cc564-182">Description</span></span>**                                                              |
|------------------------|------------------------------------------------------------------------------|
| <span data-ttu-id="cc564-183">&lt;x&gt;</span><span class="sxs-lookup"><span data-stu-id="cc564-183">&lt;x&gt;</span></span>              | <span data-ttu-id="cc564-184">タイムアウト (秒単位) </span><span class="sxs-lookup"><span data-stu-id="cc564-184">Timeout in seconds.</span></span> <span data-ttu-id="cc564-185">(既定値は 10 です)</span><span class="sxs-lookup"><span data-stu-id="cc564-185">(Default is 10)</span></span>                                          |
| <span data-ttu-id="cc564-186">&lt;address&gt;</span><span class="sxs-lookup"><span data-stu-id="cc564-186">&lt;address&gt;</span></span>        | <span data-ttu-id="cc564-187">ターゲット デバイスの IP アドレスと一意の識別子。</span><span class="sxs-lookup"><span data-stu-id="cc564-187">IP address or unique identifier of the target device.</span></span>                        |
| <span data-ttu-id="cc564-188">&lt;a&gt;&lt;b&gt; ...</span><span class="sxs-lookup"><span data-stu-id="cc564-188">&lt;a&gt;&lt;b&gt; ...</span></span> | <span data-ttu-id="cc564-189">アプリ パッケージの依存関係のそれぞれの依存パス。</span><span class="sxs-lookup"><span data-stu-id="cc564-189">Dependency path for each of the app package dependencies.</span></span>                    |
| <span data-ttu-id="cc564-190">&lt;p&gt;</span><span class="sxs-lookup"><span data-stu-id="cc564-190">&lt;p&gt;</span></span>              | <span data-ttu-id="cc564-191">接続を確立するためのデバイス設定に示されている、英数字 PIN。</span><span class="sxs-lookup"><span data-stu-id="cc564-191">An alpha-numeric pin shown in the device settings to establish a connection.</span></span> |
| <span data-ttu-id="cc564-192">&lt;path&gt;</span><span class="sxs-lookup"><span data-stu-id="cc564-192">&lt;path&gt;</span></span>           | <span data-ttu-id="cc564-193">ファイル システム パス。</span><span class="sxs-lookup"><span data-stu-id="cc564-193">File system path.</span></span>                                                            |
| <span data-ttu-id="cc564-194">&lt;name&gt;</span><span class="sxs-lookup"><span data-stu-id="cc564-194">&lt;name&gt;</span></span>           | <span data-ttu-id="cc564-195">アンインストールするアプリ パッケージの完全なパッケージ名。</span><span class="sxs-lookup"><span data-stu-id="cc564-195">Full package name for the app package to uninstall.</span></span>                          |
| <span data-ttu-id="cc564-196">&lt;server&gt;</span><span class="sxs-lookup"><span data-stu-id="cc564-196">&lt;server&gt;</span></span>         | <span data-ttu-id="cc564-197">ファイル ネットワーク上のサーバー。</span><span class="sxs-lookup"><span data-stu-id="cc564-197">Server on the file network.</span></span>                                                  |
| <span data-ttu-id="cc564-198">&lt;username&gt;</span><span class="sxs-lookup"><span data-stu-id="cc564-198">&lt;username&gt;</span></span>       | <span data-ttu-id="cc564-199">ファイル ネットワーク上のサーバーにアクセスできる資格情報のユーザー名。</span><span class="sxs-lookup"><span data-stu-id="cc564-199">User for the credentials with access to the server on the file network.</span></span>      |
| <span data-ttu-id="cc564-200">&lt;password&gt;</span><span class="sxs-lookup"><span data-stu-id="cc564-200">&lt;password&gt;</span></span>       | <span data-ttu-id="cc564-201">ファイル ネットワーク上のサーバーにアクセスできる資格情報のパスワード。</span><span class="sxs-lookup"><span data-stu-id="cc564-201">Password for the credentials with access to the server on the files network.</span></span> |
| <span data-ttu-id="cc564-202">&lt;remotedeploydir&gt;</span><span class="sxs-lookup"><span data-stu-id="cc564-202">&lt;remotedeploydir&gt;</span></span>| <span data-ttu-id="cc564-203">展開先の場所を基準としたデバイス上のディレクトリ。</span><span class="sxs-lookup"><span data-stu-id="cc564-203">Directory on device relative to the deployment location</span></span>                      |

 
## <a name="winappdeploycmdexe-examples"></a><span data-ttu-id="cc564-204">WinAppDeployCmd.exe の例</span><span class="sxs-lookup"><span data-stu-id="cc564-204">WinAppDeployCmd.exe examples</span></span>

<span data-ttu-id="cc564-205">**WinAppDeployCmd.exe** の構文を使ってコマンド ラインから展開する方法の例を、次に示します。</span><span class="sxs-lookup"><span data-stu-id="cc564-205">Here are some examples of how to deploy from the command-line using the sytax for **WinAppDeployCmd.exe**.</span></span>

<span data-ttu-id="cc564-206">展開できるデバイスを表示します。</span><span class="sxs-lookup"><span data-stu-id="cc564-206">Shows the devices that are available for deployment.</span></span> <span data-ttu-id="cc564-207">コマンドは 3 秒でタイムアウトになります。</span><span class="sxs-lookup"><span data-stu-id="cc564-207">The command times out in 3 seconds.</span></span>

``` syntax
WinAppDeployCmd devices 3
```

<span data-ttu-id="cc564-208">IP アドレスが 192.168.0.1、PIN a1b2c3 のデバイスに接続を確立すると、windows 10 デバイスを PC のダウンロード ディレクトリにある MyApp.appx パッケージからアプリをインストールします。</span><span class="sxs-lookup"><span data-stu-id="cc564-208">Installs the app from MyApp.appx package that is in your PC's Downloads directory to a Windows10 device with an IP address of 192.168.0.1 with a PIN of A1B2C3 to establish a connection with the device</span></span>

``` syntax
WinAppDeployCmd install -file "Downloads\MyApp.appx" -ip 192.168.0.1 -pin A1B2C3
```

<span data-ttu-id="cc564-209">指定したパッケージ (その完全な名前に基づく) を、IP アドレスが 192.168.0.1 の Windows 10 デバイスからアンインストールします。</span><span class="sxs-lookup"><span data-stu-id="cc564-209">Uninstalls the specified package (based on its full name) from a Windows 10 device with an IP address of 192.168.0.1.</span></span> <span data-ttu-id="cc564-210">list コマンドを使って、デバイスにインストールされているパッケージの完全な名前を見つけることができます。</span><span class="sxs-lookup"><span data-stu-id="cc564-210">You can use the list command to see the full names of any packages that are installed on a device.</span></span>

``` syntax
WinAppDeployCmd uninstall -package Company.MyApp_1.0.0.1_x64__qwertyuiop -ip 192.168.0.1
```

<span data-ttu-id="cc564-211">指定されたアプリ パッケージを使用して 192.168.0.1 の IP アドレスを使って windows 10 デバイスに既にインストールされているアプリを更新します。</span><span class="sxs-lookup"><span data-stu-id="cc564-211">Updates the app that is already installed on the Windows10 device with an IP address of 192.168.0.1 using the specified app package.</span></span>

``` syntax
WinAppDeployCmd update -file "Downloads\MyApp.appx" -ip 192.168.0.1
```

<span data-ttu-id="cc564-212">IP アドレスが 192.168.0.1 である PC または Xbox の展開パスの下にある app1_F5 ディレクトリに、AppxManifest と同じフォルダーにあるアプリのファイルを展開します。</span><span class="sxs-lookup"><span data-stu-id="cc564-212">Deploys the files of an app to a PC or Xbox with an IP address of 192.168.0.1 in the same folder as the AppxManifest to the app1_F5 directory under the deployment path of the device.</span></span>

``` syntax
WinAppDeployCmd deployfiles -file "C:\apps\App1\AppxManifest.xml" -remotedeploydir app1_F5 -ip 192.168.0.1
```

<span data-ttu-id="cc564-213">IP アドレスが 192.168.0.1 である PC または Xbox の展開パスの app1_F5 ディレクトリにあるアプリを登録します。</span><span class="sxs-lookup"><span data-stu-id="cc564-213">Registers the app at the app1_F5 directory under the deployment path of the PC or Xbox at 192.168.0.1.</span></span>

``` syntax
WinAppDeployCmd registerfiles -file app1_F5 -ip 192.168.0.1
```

## <a name="using-winappdeploycmd-to-set-up-run-from-pc-deployment-on-xbox-one"></a><span data-ttu-id="cc564-214">WinAppDeployCmd を使用した PC からの Xbox One 展開の実行の設定</span><span class="sxs-lookup"><span data-stu-id="cc564-214">Using WinAppDeployCmd to set up Run from PC deployment on Xbox One</span></span>

<span data-ttu-id="cc564-215">PC からの実行を利用すると、バイナリをコピーしなくても Xbox One に UWP アプリケーションを展開できます。バイナリは、Xbox と同じネットワーク上のネットワーク共有でホストされます。</span><span class="sxs-lookup"><span data-stu-id="cc564-215">Run from PC allows you to deploy a UWP application to an Xbox One without copying the binaries over, instead the binaries are hosted on a network share on the same network as the Xbox.</span></span>  <span data-ttu-id="cc564-216">そのためには、開発者によりロック解除された Xbox One と、ルーズ ファイル UWP アプリケーションを Xbox がアクセスできるネットワーク ドライブに用意する必要があります。</span><span class="sxs-lookup"><span data-stu-id="cc564-216">In order to do this, you need a developer unlocked Xbox One, and a loose file UWP application on a network drive that the Xbox can access.</span></span>

<span data-ttu-id="cc564-217">アプリを登録するには、次のコマンドを実行します。</span><span class="sxs-lookup"><span data-stu-id="cc564-217">Run this to register the app:</span></span>
``` syntax
WinAppDeployCmd registerfiles -ip <Xbox One IP> -remotedeploydir <location of app> -username <user for network> -password <password for user>

ex. WinAppDeployCmd register files -ip 192.168.0.1 -remotedeploydir \\driveA\myAppLocation -username admin -password A1B2C3
```
