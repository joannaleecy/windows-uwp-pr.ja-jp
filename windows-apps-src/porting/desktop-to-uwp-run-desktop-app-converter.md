---
author: normesta
Description: "Desktop Converter App を実行して、Windows デスクトップ アプリケーション (Win32、WPF、Windows フォームなど) をパッケージ化します。"
Search.Product: eADQiWindows 10XVcnh
title: "Desktop App Converter を使用してアプリをパッケージ化する (デスクトップ ブリッジ)"
ms.author: normesta
ms.date: 05/25/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp
ms.assetid: 74c84eb6-4714-4e12-a658-09cb92b576e3
ms.openlocfilehash: 6aa469d0080412f48de511315684d365d4e90c99
ms.sourcegitcommit: 6c6f3c265498d7651fcc4081c04c41fafcbaa5e7
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/09/2017
---
# <a name="package-an-app-using-the-desktop-app-converter-desktop-bridge"></a><span data-ttu-id="5e276-104">Desktop App Converter を使用してアプリをパッケージ化する (デスクトップ ブリッジ)</span><span class="sxs-lookup"><span data-stu-id="5e276-104">Package an app using the Desktop App Converter (Desktop Bridge)</span></span>

[<span data-ttu-id="5e276-105">Desktop App Converter を入手する</span><span class="sxs-lookup"><span data-stu-id="5e276-105">Get the Desktop App Converter</span></span>](https://aka.ms/converter)

<span data-ttu-id="5e276-106">Desktop App Converter (DAC) を使用すると、デスクトップ アプリをユニバーサル Windows プラットフォーム (UWP) に移行することができます。</span><span class="sxs-lookup"><span data-stu-id="5e276-106">You can use the Desktop App Converter (DAC) to bring your desktop apps to the Universal Windows Platform (UWP).</span></span> <span data-ttu-id="5e276-107">Win32 アプリや .NET 4.6.1 を使用して作成されたアプリも対象になります。</span><span class="sxs-lookup"><span data-stu-id="5e276-107">This includes Win32 apps and apps that you've created by using .NET 4.6.1.</span></span>

<div style="float: left; padding: 10px">
    ![DAC アイコン](images/desktop-to-uwp/dac.png)
</div>

<span data-ttu-id="5e276-109">このツールの名前には "Converter" という用語が含まれますが、実は、アプリの変換は行いません。</span><span class="sxs-lookup"><span data-stu-id="5e276-109">While the term "Converter" appears in the name of this tool, it doesn't actually convert your app.</span></span> <span data-ttu-id="5e276-110">アプリは変更されません。</span><span class="sxs-lookup"><span data-stu-id="5e276-110">Your app remains unchanged.</span></span> <span data-ttu-id="5e276-111">しかし、DACは、パッケージ ID を持ち多くの WinRT API を呼び出すことができる Windows アプリ パッケージを生成します。</span><span class="sxs-lookup"><span data-stu-id="5e276-111">However, this tool generates a Windows app package with a package identity and the ability to call a vast range of WinRT APIs.</span></span>

<span data-ttu-id="5e276-112">このパッケージは、開発コンピューターで Add-AppxPackage という PowerShell コマンドレットを使ってインストールすることができます。</span><span class="sxs-lookup"><span data-stu-id="5e276-112">You can install that package by using the Add-AppxPackage PowerShell cmdlet on your development machine.</span></span>

<span data-ttu-id="5e276-113">このコンバーターは、コンバーターのダウンロードに含まれるクリーンな状態の基本イメージを使って、分離された Windows 環境でデスクトップ インストーラーを実行します。</span><span class="sxs-lookup"><span data-stu-id="5e276-113">The converter runs the desktop installer in an isolated Windows environment by using a clean base image provided as part of the converter download.</span></span> <span data-ttu-id="5e276-114">デスクトップ インストーラーが作成するすべてのレジストリとファイル システムの I/O がキャプチャされ、出力の一部としてパッケージ化されます。</span><span class="sxs-lookup"><span data-stu-id="5e276-114">It captures any registry and file system I/O made by the desktop installer and packages it as part of the output.</span></span>

> [!NOTE]
> <span data-ttu-id="5e276-115">Microsoft Virtual Academy から公開されている、<a href="https://mva.microsoft.com/en-US/training-courses/developers-guide-to-the-desktop-bridge-17373?l=oZG0B1WhD_8406218965/">このシリーズ</a>の短いビデオをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5e276-115">Checkout <a href="https://mva.microsoft.com/en-US/training-courses/developers-guide-to-the-desktop-bridge-17373?l=oZG0B1WhD_8406218965/">this series</a> of short videos published by the Microsoft Virtual Academy.</span></span> <span data-ttu-id="5e276-116">これらのビデオでは、Desktop App Converter を使用する一般的な方法が紹介されています。</span><span class="sxs-lookup"><span data-stu-id="5e276-116">These videos walk you through some common ways to use the Desktop App Converter.</span></span>

## <a name="the-dac-does-more-than-just-generate-a-package-for-you"></a><span data-ttu-id="5e276-117">DAC が行うのはパッケージの生成だけではありません</span><span class="sxs-lookup"><span data-stu-id="5e276-117">The DAC does more than just generate a package for you</span></span>

<span data-ttu-id="5e276-118">他にも以下のような処理を実行できます。</span><span class="sxs-lookup"><span data-stu-id="5e276-118">Here's a few extra things it can do for you.</span></span>

**<span data-ttu-id="5e276-119">Windows 10 Creators Update</span><span class="sxs-lookup"><span data-stu-id="5e276-119">Windows 10 Creators Update</span></span>**

<div style="float: left; ">
    ![チェックマーク](images/desktop-to-uwp/check.png)
</div>

<span data-ttu-id="5e276-121">プレビュー ハンドラー、サムネイル ハンドラー、プロパティ ハンドラー、ファイアウォール規則、URL フラグを自動的に登録する。</span><span class="sxs-lookup"><span data-stu-id="5e276-121">Automatically register your preview handlers, thumbnail handlers, property handlers, firewall rules, URL flags.</span></span>

<div style="float: left; ">
    ![チェックマーク](images/desktop-to-uwp/check.png)
</div>

<span data-ttu-id="5e276-123">ファイルの種類のマッピングを自動的に登録する。これによりユーザーは、エクスプローラーの **[種類]** 列を使ってファイルをグループ化できるようになります。</span><span class="sxs-lookup"><span data-stu-id="5e276-123">Automatically register file type mappings that enable users to group files by using the **Kind** column in File Explorer.</span></span>

<div style="float: left; ">
    ![チェックマーク](images/desktop-to-uwp/check.png)
</div>

<span data-ttu-id="5e276-125">公開 COM サーバーを登録する。</span><span class="sxs-lookup"><span data-stu-id="5e276-125">Register your public COM servers.</span></span>

**<span data-ttu-id="5e276-126">Windows 10 Anniversary Update 以降</span><span class="sxs-lookup"><span data-stu-id="5e276-126">Windows 10 Anniversary Update or later</span></span>**

<div style="float: left; ">
    ![チェックマーク](images/desktop-to-uwp/check.png)
</div>

<span data-ttu-id="5e276-128">アプリをテストできるように、パッケージに自動的に署名する。</span><span class="sxs-lookup"><span data-stu-id="5e276-128">Automatically sign your package so that you can test your app.</span></span>

<div style="float: left; ">
    ![チェックマーク](images/desktop-to-uwp/check.png)
</div>

<span data-ttu-id="5e276-130">デスクトップ ブリッジと Windows ストアの要件に照らしてアプリを検証する。</span><span class="sxs-lookup"><span data-stu-id="5e276-130">Validate your app against Desktop Bridge and Windows Store requirements.</span></span>

<span data-ttu-id="5e276-131">オプションの完全な一覧については、このガイドの「[パラメーター リファレンス](#command-reference)」セクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5e276-131">To find a complete list of options, see the [Parameters](#command-reference) section of this guide.</span></span>

<span data-ttu-id="5e276-132">パッケージを作成する準備ができたら、始めましょう。</span><span class="sxs-lookup"><span data-stu-id="5e276-132">If you're ready to create your package, let's start.</span></span>

## <a name="first-consider-how-youll-distribute-your-app"></a><span data-ttu-id="5e276-133">まず、アプリの配布方法を検討する</span><span class="sxs-lookup"><span data-stu-id="5e276-133">First, consider how you'll distribute your app</span></span>
<span data-ttu-id="5e276-134">アプリを [Windows ストア](https://www.microsoft.com/store/apps)に公開する予定であれば、[このフォーム](https://developer.microsoft.com/windows/projects/campaigns/desktop-bridge)への記入から開始します。</span><span class="sxs-lookup"><span data-stu-id="5e276-134">If you plan to publish your app to the [Windows Store](https://www.microsoft.com/store/apps), start by filling out [this form](https://developer.microsoft.com/windows/projects/campaigns/desktop-bridge).</span></span> <span data-ttu-id="5e276-135">Microsoft から、オンボード プロセスを開始するための連絡があります。</span><span class="sxs-lookup"><span data-stu-id="5e276-135">Microsoft will contact you to start the onboarding process.</span></span> <span data-ttu-id="5e276-136">このプロセスでは、ストア内の名前を予約し、アプリをパッケージ化するための情報を取得します。</span><span class="sxs-lookup"><span data-stu-id="5e276-136">As part of this process, you'll reserve a name in the store, and obtain information that you'll need to package your app.</span></span>

## <a name="make-sure-that-your-system-can-run-the-converter"></a><span data-ttu-id="5e276-137">システムで DCA を実行できることを確認する</span><span class="sxs-lookup"><span data-stu-id="5e276-137">Make sure that your system can run the converter</span></span>

<span data-ttu-id="5e276-138">システムが以下の要件を満たしていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="5e276-138">Make sure that your system meets the following requirements:</span></span>

* <span data-ttu-id="5e276-139">Windows 10 Anniversary Update (10.0.14393.0 以降) Pro または Enterprise エディション</span><span class="sxs-lookup"><span data-stu-id="5e276-139">Windows 10 Anniversary Update (10.0.14393.0 and later) Pro or Enterprise edition.</span></span>
* <span data-ttu-id="5e276-140">64 ビット (x64) プロセッサ</span><span class="sxs-lookup"><span data-stu-id="5e276-140">64 bit (x64) processor</span></span>
* <span data-ttu-id="5e276-141">ハードウェア支援による仮想化</span><span class="sxs-lookup"><span data-stu-id="5e276-141">Hardware-assisted virtualization</span></span>
* <span data-ttu-id="5e276-142">Second Level Address Translation (SLAT)</span><span class="sxs-lookup"><span data-stu-id="5e276-142">Second Level Address Translation (SLAT)</span></span>
* <span data-ttu-id="5e276-143">[Windows 10 用 Windows ソフトウェア開発キット (SDK)](https://go.microsoft.com/fwlink/?linkid=821375)</span><span class="sxs-lookup"><span data-stu-id="5e276-143">[Windows Software Development Kit (SDK) for Windows 10](https://go.microsoft.com/fwlink/?linkid=821375).</span></span>


## <a name="start-the-desktop-app-converter"></a><span data-ttu-id="5e276-144">Desktop App Converter を起動する</span><span class="sxs-lookup"><span data-stu-id="5e276-144">Start the Desktop App Converter</span></span>

1. <span data-ttu-id="5e276-145">[Desktop App Converter](https://aka.ms/converter)をダウンロードおよびインストールします。</span><span class="sxs-lookup"><span data-stu-id="5e276-145">Download and install the [Desktop App Converter](https://aka.ms/converter).</span></span>

2. <span data-ttu-id="5e276-146">管理者として Desktop App Converter を実行します。</span><span class="sxs-lookup"><span data-stu-id="5e276-146">Run the Desktop App Converter as an administrator.</span></span>

    ![DAC を管理者として実行する](images/desktop-to-uwp/run-converter.png)

   <span data-ttu-id="5e276-148">コンソール ウィンドウが開きます。</span><span class="sxs-lookup"><span data-stu-id="5e276-148">A console window appears.</span></span> <span data-ttu-id="5e276-149">コマンドを実行するには、このコンソール ウィンドウを使います。</span><span class="sxs-lookup"><span data-stu-id="5e276-149">You'll use that console window to run commands.</span></span>

## <a name="set-a-few-things-up-apps-with-installers-only"></a><span data-ttu-id="5e276-150">必要な設定を行う (インストーラーがあるアプリのみ) </span><span class="sxs-lookup"><span data-stu-id="5e276-150">Set a few things up (apps with installers only)</span></span>

<span data-ttu-id="5e276-151">アプリにインストーラーがない場合は、このセクションをスキップできます。</span><span class="sxs-lookup"><span data-stu-id="5e276-151">You can skip ahead to the next section if your app doesn't have an installer.</span></span>

1. <span data-ttu-id="5e276-152">オペレーティング システムのバージョン番号を特定します。</span><span class="sxs-lookup"><span data-stu-id="5e276-152">Identify the version number of your operating system.</span></span>

   <span data-ttu-id="5e276-153">これを行うには、コンピューターで**システム情報アプリ**を開いて、オペレーティング システムのバージョン番号を見つけます。</span><span class="sxs-lookup"><span data-stu-id="5e276-153">You can do that by opening the **System Information app** on your computer and then finding the version number of your operating system.</span></span>

    ![システム情報アプリに表示されたオペレーティング システムのバージョン](images/desktop-to-uwp/os-version.png)

2. <span data-ttu-id="5e276-155">適切な [Desktop App Converter 基本イメージ](https://aka.ms/converterimages)をダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="5e276-155">Download the appropriate [Desktop app Converter base image](https://aka.ms/converterimages).</span></span>

   <span data-ttu-id="5e276-156">ファイル名に含まれるバージョン番号が Windows ビルドのバージョン番号と一致していることを確認してください。</span><span class="sxs-lookup"><span data-stu-id="5e276-156">Make sure that the version number that appears in the name of the file matches the version number of your Windows build.</span></span>

   ![一致するバージョンの基本イメージ](images/desktop-to-uwp/base-image-version.png)

   <span data-ttu-id="5e276-158">ダウンロードしたファイルを後で見つけることができるように、コンピューター上の適切な場所に置きます。</span><span class="sxs-lookup"><span data-stu-id="5e276-158">Place the downloaded file anywhere on your computer where you'll be able to find it later.</span></span>

3. <span data-ttu-id="5e276-159">Desktop App Converter を起動したときに表示されるコンソール ウィンドウで、コマンド ```Set-ExecutionPolicy bypass``` を実行します。</span><span class="sxs-lookup"><span data-stu-id="5e276-159">In the console window that appeared when you started the Desktop App Converter, run this command: ```Set-ExecutionPolicy bypass```.</span></span>
4.  <span data-ttu-id="5e276-160">コマンド ```DesktopAppConverter.exe -Setup -BaseImage .\BaseImage-1XXXX.wim -Verbose``` を実行してコンバーターをセットアップします。</span><span class="sxs-lookup"><span data-stu-id="5e276-160">Set up the converter by running  this command: ```DesktopAppConverter.exe -Setup -BaseImage .\BaseImage-1XXXX.wim -Verbose```.</span></span>
5.  <span data-ttu-id="5e276-161">画面の指示に従って、コンピューターを再起動します。</span><span class="sxs-lookup"><span data-stu-id="5e276-161">Restart your computer if you're prompted to do so.</span></span>

    <span data-ttu-id="5e276-162">コンバーターによって基本イメージが展開されると、コンソール ウィンドウに状態メッセージが表示されます。</span><span class="sxs-lookup"><span data-stu-id="5e276-162">Status messages appear in the console window as the converter expands the base image.</span></span> <span data-ttu-id="5e276-163">状態メッセージが表示されない場合は、任意のキーを押します。</span><span class="sxs-lookup"><span data-stu-id="5e276-163">If you don't see any status messages, press any key.</span></span> <span data-ttu-id="5e276-164">これにより、コンソール ウィンドウの内容が更新されます。</span><span class="sxs-lookup"><span data-stu-id="5e276-164">This can cause the contents of the console window to refresh.</span></span>

    ![コンソール ウィンドウに表示された状態メッセージ](images/desktop-to-uwp/bas-image-setup.png)

    <span data-ttu-id="5e276-166">基本イメージが完全に展開されたら、次のセクションに進みます。</span><span class="sxs-lookup"><span data-stu-id="5e276-166">When the base image is fully expanded, move to the next section.</span></span>

## <a name="package-an-app"></a><span data-ttu-id="5e276-167">アプリをパッケージ化する</span><span class="sxs-lookup"><span data-stu-id="5e276-167">Package an app</span></span>

<span data-ttu-id="5e276-168">アプリをパッケージ化するには、Desktop App Converter を起動したときに開くコンソール ウィンドウで ``DesktopAppConverter.exe`` コマンドを実行します。</span><span class="sxs-lookup"><span data-stu-id="5e276-168">To Package your app, run the ``DesktopAppConverter.exe`` command in the console window that opened when you started the Desktop App Converter.</span></span>  

<span data-ttu-id="5e276-169">パラメーターを使用して、アプリのパッケージ名、発行元、バージョン番号を指定します。</span><span class="sxs-lookup"><span data-stu-id="5e276-169">You'll specify the package name, publisher and version number of the app by using parameters.</span></span>

> [!NOTE]
> <span data-ttu-id="5e276-170">Windows ストアでアプリ名を予約済みの場合は、Windows デベロッパー センターのダッシュ ボードを使用して、パッケージと発行元名を取得できます。</span><span class="sxs-lookup"><span data-stu-id="5e276-170">If you've reserved your app name in the Windows store, you can obtain the package and publisher names by using the Windows Dev Center dashboard.</span></span> <span data-ttu-id="5e276-171">アプリを他のシステムにサイドローディング展開する場合は、独自の名前を指定できます。ただし、選択する発行元名は、アプリへの署名に使用する証明書の名前と一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="5e276-171">If you plan to sideload your app onto other systems, you can provide your own names for these as long as the publisher name that you choose matches the name on the certificate you use to sign your app.</span></span>

### <a name="a-quick-look-at-command-parameters"></a><span data-ttu-id="5e276-172">コマンド パラメーターの確認</span><span class="sxs-lookup"><span data-stu-id="5e276-172">A quick look at command parameters</span></span>

<span data-ttu-id="5e276-173">必要なパラメーターは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="5e276-173">Here are the required parameters.</span></span>

```CMD
DesktopAppConverter.exe
-Installer <String>
-Destination <String>
-PackageName <String>
-Publisher <String>
-Version <Version>
```
<span data-ttu-id="5e276-174">各パラメーターについて詳しくは、[こちら](#command-reference)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5e276-174">You can read about each one [here](#command-reference).</span></span>

### <a name="examples"></a><span data-ttu-id="5e276-175">例</span><span class="sxs-lookup"><span data-stu-id="5e276-175">Examples</span></span>

<span data-ttu-id="5e276-176">アプリをパッケージ化する一般的な方法のいくつかを以下に示します。</span><span class="sxs-lookup"><span data-stu-id="5e276-176">Here's a few common ways to package your app.</span></span>

* [<span data-ttu-id="5e276-177">インストーラー (.msi) ファイルのあるアプリをパッケージ化する</span><span class="sxs-lookup"><span data-stu-id="5e276-177">Package an app that has an installer (.msi) file</span></span>](#installer-conversion)
* [<span data-ttu-id="5e276-178">セットアップの実行可能ファイルのあるアプリをパッケージ化する</span><span class="sxs-lookup"><span data-stu-id="5e276-178">Package an app that has a setup executable file</span></span>](#setup-conversion)
* [<span data-ttu-id="5e276-179">インストーラーのないアプリをパッケージ化する</span><span class="sxs-lookup"><span data-stu-id="5e276-179">Package an app that doesn't have an installer</span></span>](#no-installer-conversion)
* [<span data-ttu-id="5e276-180">アプリをパッケージ化し、アプリに署名して、ストアへの提出に備える</span><span class="sxs-lookup"><span data-stu-id="5e276-180">Package an app, sign the app, and prepare it for store submission</span></span>](#optional-parameters)

<span id="installer-conversion" />
#### <a name="package-an-app-that-has-an-installer-msi-file"></a><span data-ttu-id="5e276-181">インストーラー (.msi) ファイルのあるアプリをパッケージ化する</span><span class="sxs-lookup"><span data-stu-id="5e276-181">Package an app that has an installer (.msi) file</span></span>

<span data-ttu-id="5e276-182">``Installer`` パラメーターでインストーラー ファイルを指定します。</span><span class="sxs-lookup"><span data-stu-id="5e276-182">Point to the installer file by using the ``Installer`` parameter.</span></span>

```cmd
DesktopAppConverter.exe -Installer C:\Installer\MyAppSetup.msi -Destination C:\Output\MyApp -PackageName "MyApp" -Publisher "CN=MyPublisher" -Version 0.0.0.1
```

> [!NOTE]
> <span data-ttu-id="5e276-183">インストーラーは独立したフォルダーに配置し、そのインストーラーに関連するファイルだけを同じフォルダーに配置してください。</span><span class="sxs-lookup"><span data-stu-id="5e276-183">Make sure that your installer is located in an independent folder and that only files related to that installer are in the same folder.</span></span> <span data-ttu-id="5e276-184">コンバーターは、このフォルダーの内容をすべて、分離された Windows 環境にコピーします。</span><span class="sxs-lookup"><span data-stu-id="5e276-184">The converter copies all of the contents of that folder to the isolated Windows environment.</span></span>

**<span data-ttu-id="5e276-185">ビデオ</span><span class="sxs-lookup"><span data-stu-id="5e276-185">Video</span></span>**

<iframe src="https://mva.microsoft.com/en-US/training-courses-embed/developers-guide-to-the-desktop-bridge-17373/Demo-Convert-an-Application-That-Has-an-MSI-Installer-Kh1UU2WhD_7106218965" width="636" height="480" allowFullScreen frameBorder="0"></iframe>

<span id="setup-conversion" />
#### <span data-ttu-id="5e276-186">セットアップの実行可能ファイルのあるアプリをパッケージ化する</span><span class="sxs-lookup"><span data-stu-id="5e276-186">Package an app that has a setup executable file</span></span>

<span data-ttu-id="5e276-187">``Installer`` パラメーターを使って、セットアップの実行可能ファイルを指定します。</span><span class="sxs-lookup"><span data-stu-id="5e276-187">Point to the setup executable by using the ``Installer`` parameter.</span></span>

```cmd
DesktopAppConverter.exe -Installer C:\Installer\MyAppSetup.exe -InstallerArguments "/S" -Destination C:\Output\MyApp -PackageName "MyApp" -Publisher "CN=MyPublisher" -Version 0.0.0.1
```

<span data-ttu-id="5e276-188">``InstallerArguments`` パラメーターは省略可能なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="5e276-188">The ``InstallerArguments`` parameter is an optional parameter.</span></span> <span data-ttu-id="5e276-189">ただし、Desktop App Converter では、インストーラーを無人モードで実行する必要があるため、アプリをサイレント モードで実行するためにサイレント フラグを必要とする場合は、このパラメーターの使用が必要になることがあります。</span><span class="sxs-lookup"><span data-stu-id="5e276-189">However, because the Desktop App Converter needs your installer to run in unattended mode, you might have to use it if your app needs silent flags to run silently.</span></span> <span data-ttu-id="5e276-190">``/S`` フラグは非常に一般的なサイレント フラグですが、セットアップ ファイルを作成するために使用したインストーラー テクノロジによっては、使用するフラグが異なる場合もあります。</span><span class="sxs-lookup"><span data-stu-id="5e276-190">The ``/S`` flag is a very common silent flag, but the flag that you use might be different depending on which installer technology you used to create the setup file.</span></span>

**<span data-ttu-id="5e276-191">ビデオ</span><span class="sxs-lookup"><span data-stu-id="5e276-191">Video</span></span>**

<iframe src="https://mva.microsoft.com/en-US/training-courses-embed/developers-guide-to-the-desktop-bridge-17373/Demo-Convert-an-Application-That-Has-a-Setup-exe-Installer-amWit2WhD_5306218965" width="636" height="480" allowFullScreen frameBorder="0"></iframe>

<span id="no-installer-conversion" />
#### <span data-ttu-id="5e276-192">インストーラーのないアプリをパッケージ化する</span><span class="sxs-lookup"><span data-stu-id="5e276-192">Package an app that doesn't have an installer</span></span>

<span data-ttu-id="5e276-193">この例では、``Installer`` パラメーターを使用して、アプリ ファイルのルート フォルダーを指定しています。</span><span class="sxs-lookup"><span data-stu-id="5e276-193">In this example, use the ``Installer`` parameter to point to the root folder of your app files.</span></span>

<span data-ttu-id="5e276-194">アプリの実行可能ファイルを指定するには、`AppExecutable` パラメーターを使用します。</span><span class="sxs-lookup"><span data-stu-id="5e276-194">Use the `AppExecutable` parameter to point to your apps executable file.</span></span>

```cmd
DesktopAppConverter.exe -Installer C:\Installer\MyApp\ -AppExecutable MyApp.exe -Destination C:\Output\MyApp -PackageName "MyApp" -Publisher "CN=MyPublisher" -Version 0.0.0.1
```

**<span data-ttu-id="5e276-195">ビデオ</span><span class="sxs-lookup"><span data-stu-id="5e276-195">Video</span></span>**

<iframe src="https://mva.microsoft.com/en-US/training-courses-embed/developers-guide-to-the-desktop-bridge-17373/Demo-Convert-a-No-Installer-Application-agAXF2WhD_3506218965" width="636" height="480" allowFullScreen frameBorder="0"></iframe>

<span id="optional-parameters" />
#### <span data-ttu-id="5e276-196">アプリをパッケージ化し、アプリに署名して、パッケージに対して検証チェックを実行する</span><span class="sxs-lookup"><span data-stu-id="5e276-196">Package an app, sign the app, and run validation checks on the package</span></span>

<span data-ttu-id="5e276-197">この例は最初の例に似ていますが、こちらはローカル テスト用にアプリに署名し、デスクトップ ブリッジと Windows ストアの要件に照らしてアプリを変換する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="5e276-197">This example is similar to first one except it shows how you can sign your app for local testing, and then validate your app against Desktop Bridge and Windows Store requirements.</span></span>

```cmd
DesktopAppConverter.exe -Installer C:\Installer\MyAppSetup.exe -InstallerArguments "/S" -Destination C:\Output\MyApp -PackageName "MyApp" -Publisher "CN=MyPublisher" -Version 0.0.0.1 -MakeAppx -Sign -Verbose -Verify
```

<span data-ttu-id="5e276-198">``Sign`` パラメーターは、証明書を生成し、その証明書でアプリに署名します。</span><span class="sxs-lookup"><span data-stu-id="5e276-198">The ``Sign`` parameter generates a certificate and then signs your app with it.</span></span> <span data-ttu-id="5e276-199">アプリを実行するには、生成された証明書をインストールする必要があります。</span><span class="sxs-lookup"><span data-stu-id="5e276-199">To run your app, you'll have to install that generated certificate.</span></span> <span data-ttu-id="5e276-200">その方法については、このガイドの「[パッケージ アプリを実行する](#run-app)」セクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5e276-200">To learn how, see the [Run the packaged app](#run-app) section of this guide.</span></span>

<span data-ttu-id="5e276-201">アプリを検証するには、``Verify`` パラメーターを使います。</span><span class="sxs-lookup"><span data-stu-id="5e276-201">You can validate you app by using the ``Verify`` parameter.</span></span>

### <a name="a-quick-look-at-optional-parameters"></a><span data-ttu-id="5e276-202">省略可能なパラメーターの確認</span><span class="sxs-lookup"><span data-stu-id="5e276-202">A quick look at optional parameters</span></span>

<span data-ttu-id="5e276-203">``Sign`` パラメーターと ``Verify`` パラメーターは省略可能です。</span><span class="sxs-lookup"><span data-stu-id="5e276-203">The ``Sign`` and ``Verify`` parameters are optional.</span></span> <span data-ttu-id="5e276-204">他にも多数の省略可能なパラメーターがあります。</span><span class="sxs-lookup"><span data-stu-id="5e276-204">There are many more optional parameters.</span></span>  <span data-ttu-id="5e276-205">よく使用される省略可能なパラメーターを以下に示します。</span><span class="sxs-lookup"><span data-stu-id="5e276-205">Here are some of the more commonly used optional parameters.</span></span>

```CMD
[-ExpandedBaseImage <String>]
[-AppExecutable <String>]
[-AppFileTypes <String>]
[-AppId <String>]
[-AppDisplayName <String>]
[-AppDescription <String>]
[-PackageDisplayName <String>]
[-PackagePublisherDisplayName <String>]
[-MakeAppx]
[-LogFile <String>]
[<CommonParameters>]
```
<span data-ttu-id="5e276-206">これらについて詳しくは、次のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5e276-206">You can read about all of them in the next section.</span></span>

<span id="command-reference" />
### <a name="parameter-reference"></a><span data-ttu-id="5e276-207">パラメーター リファレンス</span><span class="sxs-lookup"><span data-stu-id="5e276-207">Parameter Reference</span></span>

<span data-ttu-id="5e276-208">ここでは、Desktop App Converter を実行するときに使用できるパラメーターの完全な一覧をカテゴリ別に示します。</span><span class="sxs-lookup"><span data-stu-id="5e276-208">Here's the complete list of parameters (organized by category) that you can use when you run the Desktop App Converter.</span></span>

* [<span data-ttu-id="5e276-209">セットアップ</span><span class="sxs-lookup"><span data-stu-id="5e276-209">Setup</span></span>](#setup-params)
* [<span data-ttu-id="5e276-210">変換</span><span class="sxs-lookup"><span data-stu-id="5e276-210">Conversion</span></span>](#conversion-params)
* [<span data-ttu-id="5e276-211">パッケージ ID</span><span class="sxs-lookup"><span data-stu-id="5e276-211">Package identity</span></span>](#identity-params)
* [<span data-ttu-id="5e276-212">パッケージ マニフェスト</span><span class="sxs-lookup"><span data-stu-id="5e276-212">Package manifest</span></span>](#manifest-params)
* [<span data-ttu-id="5e276-213">クリーンアップ</span><span class="sxs-lookup"><span data-stu-id="5e276-213">Cleanup</span></span>](#cleanup-params)
* [<span data-ttu-id="5e276-214">アーキテクチャ</span><span class="sxs-lookup"><span data-stu-id="5e276-214">Architecture</span></span>](#architecture-params)
* [<span data-ttu-id="5e276-215">その他</span><span class="sxs-lookup"><span data-stu-id="5e276-215">Miscellaneous</span></span>](#other-params)

<span data-ttu-id="5e276-216">アプリ コンソール ウィンドウで ``Get-Help`` コマンドを実行して完全な一覧を表示することもできます。</span><span class="sxs-lookup"><span data-stu-id="5e276-216">You can also view the entire list by running the ``Get-Help`` command in the app console window.</span></span>   

||||
|-------------|-----------|-------------|
|<span id="setup-params" /> <strong><span data-ttu-id="5e276-217">セットアップ パラメーター</span><span class="sxs-lookup"><span data-stu-id="5e276-217">Setup parameters</span></span></strong>  ||
|<span data-ttu-id="5e276-218">-Setup [&lt;SwitchParameter&gt;]</span><span class="sxs-lookup"><span data-stu-id="5e276-218">-Setup [&lt;SwitchParameter&gt;]</span></span> |<span data-ttu-id="5e276-219">必須</span><span class="sxs-lookup"><span data-stu-id="5e276-219">Required</span></span> |<span data-ttu-id="5e276-220">セットアップ モードで DesktopAppConverter を実行します。</span><span class="sxs-lookup"><span data-stu-id="5e276-220">Runs DesktopAppConverter in setup mode.</span></span> <span data-ttu-id="5e276-221">セットアップ モードでは、用意されている基本イメージの展開をサポートします。</span><span class="sxs-lookup"><span data-stu-id="5e276-221">Setup mode supports expanding a provided base image.</span></span>|
|<span data-ttu-id="5e276-222">-BaseImage &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="5e276-222">-BaseImage &lt;String&gt;</span></span> | <span data-ttu-id="5e276-223">必須</span><span class="sxs-lookup"><span data-stu-id="5e276-223">Required</span></span> |<span data-ttu-id="5e276-224">展開されていない基本イメージの完全パス。</span><span class="sxs-lookup"><span data-stu-id="5e276-224">Full path to an unexpanded base image.</span></span> <span data-ttu-id="5e276-225">このパラメーターは、-Setup を指定する場合に必要です。</span><span class="sxs-lookup"><span data-stu-id="5e276-225">This parameter is required if -Setup is specified.</span></span>|
| <span data-ttu-id="5e276-226">-LogFile &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="5e276-226">-LogFile &lt;String&gt;</span></span> |<span data-ttu-id="5e276-227">省略可能</span><span class="sxs-lookup"><span data-stu-id="5e276-227">Optional</span></span> |<span data-ttu-id="5e276-228">ログ ファイルを指定します。</span><span class="sxs-lookup"><span data-stu-id="5e276-228">Specifies a log file.</span></span> <span data-ttu-id="5e276-229">省略した場合は、ログ ファイルの一時的な場所が作成されます。</span><span class="sxs-lookup"><span data-stu-id="5e276-229">If omitted, a log file temporary location will be created.</span></span>|
|<span data-ttu-id="5e276-230">-NatSubnetPrefix &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="5e276-230">-NatSubnetPrefix &lt;String&gt;</span></span> |<span data-ttu-id="5e276-231">省略可能</span><span class="sxs-lookup"><span data-stu-id="5e276-231">Optional</span></span> |<span data-ttu-id="5e276-232">Nat インスタンスで使うプレフィックス値。</span><span class="sxs-lookup"><span data-stu-id="5e276-232">Prefix value to be used for the Nat instance.</span></span> <span data-ttu-id="5e276-233">通常この値は、ホスト コンピューターがコンバーターの NetNat と同じサブネット範囲に割り当てられている場合にのみ変更します。</span><span class="sxs-lookup"><span data-stu-id="5e276-233">Typically, you would want to change this only if your host machine is attached to the same subnet range as the converter's NetNat.</span></span> <span data-ttu-id="5e276-234">現在のコンバーターの NetNat 構成は **Get NetNat** コマンドレットを使って照会できます。</span><span class="sxs-lookup"><span data-stu-id="5e276-234">You can query the current converter NetNat config by using the **Get-NetNat** cmdlet.</span></span> |
|<span data-ttu-id="5e276-235">-NoRestart [&lt;SwitchParameter&gt;]</span><span class="sxs-lookup"><span data-stu-id="5e276-235">-NoRestart [&lt;SwitchParameter&gt;]</span></span> |<span data-ttu-id="5e276-236">必須</span><span class="sxs-lookup"><span data-stu-id="5e276-236">Required</span></span> |<span data-ttu-id="5e276-237">セットアップの実行中に再起動を要求しません (コンテナー機能を有効にするには再起動が必要です)。</span><span class="sxs-lookup"><span data-stu-id="5e276-237">Don't prompt for reboot when running setup (reboot is required to enable the container feature).</span></span> |
|<span id="conversion-params" /> <strong><span data-ttu-id="5e276-238">変換パラメーター</span><span class="sxs-lookup"><span data-stu-id="5e276-238">Conversion parameters</span></span></strong>|||
|<span data-ttu-id="5e276-239">-AppInstallPath &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="5e276-239">-AppInstallPath &lt;String&gt;</span></span>  |<span data-ttu-id="5e276-240">省略可能</span><span class="sxs-lookup"><span data-stu-id="5e276-240">Optional</span></span> |<span data-ttu-id="5e276-241">インストール済みのファイルに対応する、アプリケーションのルート フォルダーの完全パス (インストールされている場合)。"C:\Program Files (x86)\MyApp" など。</span><span class="sxs-lookup"><span data-stu-id="5e276-241">The full path to your application's root folder for the installed files if it were installed (e.g., "C:\Program Files (x86)\MyApp").</span></span>|
|<span data-ttu-id="5e276-242">-Destination &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="5e276-242">-Destination &lt;String&gt;</span></span> |<span data-ttu-id="5e276-243">必須</span><span class="sxs-lookup"><span data-stu-id="5e276-243">Required</span></span> |<span data-ttu-id="5e276-244">コンバーターの appx を出力する場所。この場所がまだ存在しない場合は、DesktopAppConverter によって作成されます。</span><span class="sxs-lookup"><span data-stu-id="5e276-244">The desired destination for the converter's appx output - DesktopAppConverter can create this location if it doesn't already exist.</span></span>|
|<span data-ttu-id="5e276-245">-Installer &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="5e276-245">-Installer &lt;String&gt;</span></span> |<span data-ttu-id="5e276-246">必須</span><span class="sxs-lookup"><span data-stu-id="5e276-246">Required</span></span> |<span data-ttu-id="5e276-247">アプリケーションのインストーラーのパス。無人/サイレント モードで実行できるようにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="5e276-247">The path to the installer for your application - must be able to run unattended/silently.</span></span> <span data-ttu-id="5e276-248">インストーラーを使用しない変換では、アプリ ファイルのルート ディレクトリへのパス。</span><span class="sxs-lookup"><span data-stu-id="5e276-248">No-installer conversion, this is the path to the root directory of your app files.</span></span> |
|<span data-ttu-id="5e276-249">-InstallerArguments &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="5e276-249">-InstallerArguments &lt;String&gt;</span></span> |<span data-ttu-id="5e276-250">省略可能</span><span class="sxs-lookup"><span data-stu-id="5e276-250">Optional</span></span> |<span data-ttu-id="5e276-251">インストーラーに無人/サイレント モードでの実行を強制する引数の文字列、またはコンマ区切り一覧。</span><span class="sxs-lookup"><span data-stu-id="5e276-251">A comma-separated list or string of arguments to force your installer to run unattended/silently.</span></span> <span data-ttu-id="5e276-252">インストーラーが msi の場合は、このパラメーターは省略可能です。</span><span class="sxs-lookup"><span data-stu-id="5e276-252">This parameter is optional if your installer is an msi.</span></span> <span data-ttu-id="5e276-253">インストーラーからログを取得するには、ここで、インストーラーのログ記録の引数を指定し、パス &lt;log_folder&gt; (コンバーターが適切なパスに置換するトークン) を使います。</span><span class="sxs-lookup"><span data-stu-id="5e276-253">To get a log from your installer, supply the logging argument for the installer here and use the path &lt;log_folder&gt;, which is a token that the converter replaces with the appropriate path.</span></span> <br><br><span data-ttu-id="5e276-254">**注**: 無人/サイレント フラグとログの引数は、インストーラー テクノロジごとに異なります。</span><span class="sxs-lookup"><span data-stu-id="5e276-254">**NOTE**: The unattended/silent flags and log arguments will vary between installer technologies.</span></span> <br><br><span data-ttu-id="5e276-255">このパラメーターの使用例: -InstallerArguments "/silent /log &lt;log_folder&gt;\install.log"。ログ ファイルを生成しない別の例: ```-InstallerArguments "/quiet", "/norestart"```。コンバーターでログをキャプチャし、最終的なログ フォルダーに格納する場合は、文字どおりすべてのログにトークン パス &lt;log_folder&gt; を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="5e276-255">An example usage for this parameter: -InstallerArguments "/silent /log &lt;log_folder&gt;\install.log" Another example that doesn't produce a log file may look like: ```-InstallerArguments "/quiet", "/norestart"``` Again, you must literally direct any logs to the token path &lt;log_folder&gt; if you want the converter to capture it and put it in the final log folder.</span></span>|
|<span data-ttu-id="5e276-256">-InstallerValidExitCodes &lt;Int32&gt;</span><span class="sxs-lookup"><span data-stu-id="5e276-256">-InstallerValidExitCodes &lt;Int32&gt;</span></span> |<span data-ttu-id="5e276-257">省略可能</span><span class="sxs-lookup"><span data-stu-id="5e276-257">Optional</span></span> |<span data-ttu-id="5e276-258">インストーラーの正常な実行を示す、コンマで区切った終了コードの一覧 (例: 0, 1234, 5678)。</span><span class="sxs-lookup"><span data-stu-id="5e276-258">A comma-separated list of exit codes that indicate your installer ran successfully (for example: 0, 1234, 5678).</span></span>  <span data-ttu-id="5e276-259">既定では、非 msi は 0、msi は 0, 1641, 3010 です。</span><span class="sxs-lookup"><span data-stu-id="5e276-259">By default this is 0 for non-msi, and 0, 1641, 3010 for msi.</span></span>|
|<span id="identity-params" /><strong><span data-ttu-id="5e276-260">パッケージ ID パラメーター</span><span class="sxs-lookup"><span data-stu-id="5e276-260">Package identity parameters</span></span></strong>||
|<span data-ttu-id="5e276-261">-PackageName &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="5e276-261">-PackageName &lt;String&gt;</span></span> |<span data-ttu-id="5e276-262">必須</span><span class="sxs-lookup"><span data-stu-id="5e276-262">Required</span></span> |<span data-ttu-id="5e276-263">ユニバーサル Windows アプリ パッケージの名前</span><span class="sxs-lookup"><span data-stu-id="5e276-263">The name of your Universal Windows App package</span></span> |
|<span data-ttu-id="5e276-264">-Publisher &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="5e276-264">-Publisher &lt;String&gt;</span></span> |<span data-ttu-id="5e276-265">必須</span><span class="sxs-lookup"><span data-stu-id="5e276-265">Required</span></span> |<span data-ttu-id="5e276-266">ユニバーサル Windows アプリ パッケージの発行元</span><span class="sxs-lookup"><span data-stu-id="5e276-266">The publisher of your Universal Windows App package</span></span> |
|<span data-ttu-id="5e276-267">-Version &lt;Version&gt;</span><span class="sxs-lookup"><span data-stu-id="5e276-267">-Version &lt;Version&gt;</span></span> |<span data-ttu-id="5e276-268">必須</span><span class="sxs-lookup"><span data-stu-id="5e276-268">Required</span></span> |<span data-ttu-id="5e276-269">ユニバーサル Windows アプリ パッケージのバージョン番号</span><span class="sxs-lookup"><span data-stu-id="5e276-269">The version number for your Universal Windows App package</span></span> |
|<span id="manifest-params" /><strong><span data-ttu-id="5e276-270">パッケージ マニフェスト パラメーター</span><span class="sxs-lookup"><span data-stu-id="5e276-270">Package manifest parameters</span></span></strong>||
|<span data-ttu-id="5e276-271">-AppExecutable &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="5e276-271">-AppExecutable &lt;String&gt;</span></span> |<span data-ttu-id="5e276-272">省略可能</span><span class="sxs-lookup"><span data-stu-id="5e276-272">Optional</span></span> |<span data-ttu-id="5e276-273">アプリケーションのメインの実行可能ファイルの名前 (例:"MyApp.exe")。</span><span class="sxs-lookup"><span data-stu-id="5e276-273">The name of your application's main executable (eg "MyApp.exe").</span></span> <span data-ttu-id="5e276-274">インストーラーを使用しない変換では、このパラメーターは必須です。</span><span class="sxs-lookup"><span data-stu-id="5e276-274">This parameter is required for a no-installer conversion.</span></span> |
|<span data-ttu-id="5e276-275">-AppFileTypes &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="5e276-275">-AppFileTypes &lt;String&gt;</span></span>|<span data-ttu-id="5e276-276">省略可能</span><span class="sxs-lookup"><span data-stu-id="5e276-276">Optional</span></span> |<span data-ttu-id="5e276-277">アプリケーションに関連付ける、ファイルの種類のコンマ区切りの一覧。</span><span class="sxs-lookup"><span data-stu-id="5e276-277">A comma-separated list of file types which the application will be associated with.</span></span> <span data-ttu-id="5e276-278">使用例: -AppFileTypes "'.md', '.markdown'"。</span><span class="sxs-lookup"><span data-stu-id="5e276-278">Example usage: -AppFileTypes "'.md', '.markdown'".</span></span>|
|<span data-ttu-id="5e276-279">-AppId &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="5e276-279">-AppId &lt;String&gt;</span></span> |<span data-ttu-id="5e276-280">省略可能</span><span class="sxs-lookup"><span data-stu-id="5e276-280">Optional</span></span> |<span data-ttu-id="5e276-281">Windows アプリ パッケージ マニフェストでアプリケーション ID を設定する値を指定します。</span><span class="sxs-lookup"><span data-stu-id="5e276-281">Specifies a value to set Application Id to in the Windows app package manifest.</span></span> <span data-ttu-id="5e276-282">指定しなかった場合は、*PackageName* で渡した値が設定されます。</span><span class="sxs-lookup"><span data-stu-id="5e276-282">If it is not specified, it will be set to the value passed in for *PackageName*.</span></span>|
|<span data-ttu-id="5e276-283">-AppDisplayName &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="5e276-283">-AppDisplayName &lt;String&gt;</span></span>  |<span data-ttu-id="5e276-284">省略可能</span><span class="sxs-lookup"><span data-stu-id="5e276-284">Optional</span></span> |<span data-ttu-id="5e276-285">Windows アプリ パッケージ マニフェストでアプリケーションの表示名を設定する値を指定します。</span><span class="sxs-lookup"><span data-stu-id="5e276-285">Specifies a value to set Application Display Name to in the Windows app package manifest.</span></span> <span data-ttu-id="5e276-286">指定しなかった場合は、*PackageName* で渡した値が設定されます。</span><span class="sxs-lookup"><span data-stu-id="5e276-286">If it is not specified, it will be set to the value passed in for *PackageName*.</span></span> |
|<span data-ttu-id="5e276-287">-AppDescription &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="5e276-287">-AppDescription &lt;String&gt;</span></span> |<span data-ttu-id="5e276-288">省略可能</span><span class="sxs-lookup"><span data-stu-id="5e276-288">Optional</span></span> |<span data-ttu-id="5e276-289">Windows アプリ パッケージ マニフェストでアプリケーションの説明を設定する値を指定します。</span><span class="sxs-lookup"><span data-stu-id="5e276-289">Specifies a value to set Application Description to in the Windows app package manifest.</span></span> <span data-ttu-id="5e276-290">指定しなかった場合は、*PackageName* で渡した値が設定されます。</span><span class="sxs-lookup"><span data-stu-id="5e276-290">If it is not specified, it will be set to the value passed in for *PackageName*.</span></span>|
|<span data-ttu-id="5e276-291">-PackageDisplayName &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="5e276-291">-PackageDisplayName &lt;String&gt;</span></span> |<span data-ttu-id="5e276-292">省略可能</span><span class="sxs-lookup"><span data-stu-id="5e276-292">Optional</span></span> |<span data-ttu-id="5e276-293">Windows アプリ パッケージ マニフェストでパッケージの表示名を設定する値を指定します。</span><span class="sxs-lookup"><span data-stu-id="5e276-293">Specifies a value to set Package Display Name to in the Windows app package manifest.</span></span> <span data-ttu-id="5e276-294">指定しなかった場合は、*PackageName* で渡した値が設定されます。</span><span class="sxs-lookup"><span data-stu-id="5e276-294">If it is not specified, it will be set to the value passed in for *PackageName*.</span></span> |
|<span data-ttu-id="5e276-295">-PackagePublisherDisplayName &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="5e276-295">-PackagePublisherDisplayName &lt;String&gt;</span></span> |<span data-ttu-id="5e276-296">省略可能</span><span class="sxs-lookup"><span data-stu-id="5e276-296">Optional</span></span> |<span data-ttu-id="5e276-297">Windows アプリ パッケージ マニフェストでパッケージ発行元の表示名を設定する値を指定します。</span><span class="sxs-lookup"><span data-stu-id="5e276-297">Specifies a value to set Package Publisher Display Name to in the Windows app package manifest.</span></span> <span data-ttu-id="5e276-298">指定しなかった場合は、*Publisher* で渡した値が設定されます。</span><span class="sxs-lookup"><span data-stu-id="5e276-298">If it is not specified, it will be set to the value passed in for *Publisher*.</span></span> |
|<span id="cleanup-params" /><strong><span data-ttu-id="5e276-299">クリーンアップ パラメーター</span><span class="sxs-lookup"><span data-stu-id="5e276-299">Cleanup parameters</span></span></strong>|||
|<span data-ttu-id="5e276-300">-Cleanup [&lt;Option&gt;]</span><span class="sxs-lookup"><span data-stu-id="5e276-300">-Cleanup [&lt;Option&gt;]</span></span> |<span data-ttu-id="5e276-301">必須</span><span class="sxs-lookup"><span data-stu-id="5e276-301">Required</span></span> |<span data-ttu-id="5e276-302">DesktopAppConverter の成果物のクリーンアップを実行します。</span><span class="sxs-lookup"><span data-stu-id="5e276-302">Runs cleanup for the DesktopAppConverter artifacts.</span></span> <span data-ttu-id="5e276-303">クリーンアップ モードには 3 つの有効なオプションがあります。</span><span class="sxs-lookup"><span data-stu-id="5e276-303">There are 3 valid options for the Cleanup mode.</span></span> |
|<span data-ttu-id="5e276-304">-Cleanup All</span><span class="sxs-lookup"><span data-stu-id="5e276-304">-Cleanup All</span></span> | |<span data-ttu-id="5e276-305">展開済みのすべての基本イメージを削除し、コンバーターのすべての一時ファイルを削除します。コンテナーのネットワークを削除し、Windows のオプション機能、コンテナーを無効にします。</span><span class="sxs-lookup"><span data-stu-id="5e276-305">Deletes all expanded base images, removes any temporary converter files, removes the container network, and disables the optional Windows feature, Containers.</span></span> |
|<span data-ttu-id="5e276-306">-Cleanup WorkDirectory</span><span class="sxs-lookup"><span data-stu-id="5e276-306">-Cleanup WorkDirectory</span></span> |<span data-ttu-id="5e276-307">必須</span><span class="sxs-lookup"><span data-stu-id="5e276-307">Required</span></span> |<span data-ttu-id="5e276-308">コンバーターのすべての一時ファイルを削除します。</span><span class="sxs-lookup"><span data-stu-id="5e276-308">Removes all the temporary converter files.</span></span> |
|<span data-ttu-id="5e276-309">-Cleanup ExpandedImage</span><span class="sxs-lookup"><span data-stu-id="5e276-309">-Cleanup ExpandedImage</span></span> |<span data-ttu-id="5e276-310">必須</span><span class="sxs-lookup"><span data-stu-id="5e276-310">Required</span></span> |<span data-ttu-id="5e276-311">ホスト コンピューターにインストールされているすべての展開済みの基本イメージを削除します。</span><span class="sxs-lookup"><span data-stu-id="5e276-311">Deletes all the expanded base images installed on your host machine.</span></span> |
|<span id="architecture-params" /><strong><span data-ttu-id="5e276-312">パッケージ アーキテクチャ パラメーター</span><span class="sxs-lookup"><span data-stu-id="5e276-312">Package architecture parameters</span></span></strong>|||
|<span data-ttu-id="5e276-313">-PackageArch &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="5e276-313">-PackageArch &lt;String&gt;</span></span> |<span data-ttu-id="5e276-314">必須</span><span class="sxs-lookup"><span data-stu-id="5e276-314">Required</span></span> |<span data-ttu-id="5e276-315">指定したアーキテクチャのパッケージを生成します。</span><span class="sxs-lookup"><span data-stu-id="5e276-315">Generates a package with the specified architecture.</span></span> <span data-ttu-id="5e276-316">有効なオプションは、'x86' または 'x64' です。たとえば、-PackageArch x86 のように指定します。</span><span class="sxs-lookup"><span data-stu-id="5e276-316">Valid options are 'x86' or 'x64'; for example, -PackageArch x86.</span></span> <span data-ttu-id="5e276-317">このパラメーターは省略可能です。</span><span class="sxs-lookup"><span data-stu-id="5e276-317">This parameter is optional.</span></span> <span data-ttu-id="5e276-318">指定されていない場合、DesktopAppConverter はパッケージのアーキテクチャの自動検出を試みます。</span><span class="sxs-lookup"><span data-stu-id="5e276-318">If unspecified, the DesktopAppConverter will try to auto-detect package architecture.</span></span> <span data-ttu-id="5e276-319">自動検出に失敗した場合、既定値は x64 パッケージです。</span><span class="sxs-lookup"><span data-stu-id="5e276-319">If auto-detection fails, it will default to x64 package.</span></span> |
|<span id="other-params" /><strong><span data-ttu-id="5e276-320">その他のパラメーター</span><span class="sxs-lookup"><span data-stu-id="5e276-320">Miscellaneous parameters</span></span></strong>|||
|<span data-ttu-id="5e276-321">-ExpandedBaseImage &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="5e276-321">-ExpandedBaseImage &lt;String&gt;</span></span>  |<span data-ttu-id="5e276-322">省略可能</span><span class="sxs-lookup"><span data-stu-id="5e276-322">Optional</span></span> |<span data-ttu-id="5e276-323">既に展開済みの基本イメージの完全パス。</span><span class="sxs-lookup"><span data-stu-id="5e276-323">Full path to an already expanded base image.</span></span>|
|<span data-ttu-id="5e276-324">-MakeAppx [&lt;SwitchParameter&gt;]</span><span class="sxs-lookup"><span data-stu-id="5e276-324">-MakeAppx [&lt;SwitchParameter&gt;]</span></span>  |<span data-ttu-id="5e276-325">省略可能</span><span class="sxs-lookup"><span data-stu-id="5e276-325">Optional</span></span> |<span data-ttu-id="5e276-326">このスクリプトに出力で MakeAppx を呼び出すように指示するスイッチ (存在する場合)。</span><span class="sxs-lookup"><span data-stu-id="5e276-326">A switch that, when present, tells this script to call MakeAppx on the output.</span></span> |
|<span data-ttu-id="5e276-327">-LogFile &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="5e276-327">-LogFile &lt;String&gt;</span></span>  |<span data-ttu-id="5e276-328">省略可能</span><span class="sxs-lookup"><span data-stu-id="5e276-328">Optional</span></span> |<span data-ttu-id="5e276-329">ログ ファイルを指定します。</span><span class="sxs-lookup"><span data-stu-id="5e276-329">Specifies a log file.</span></span> <span data-ttu-id="5e276-330">省略した場合は、ログ ファイルの一時的な場所が作成されます。</span><span class="sxs-lookup"><span data-stu-id="5e276-330">If omitted, a log file temporary location will be created.</span></span> |
| <span data-ttu-id="5e276-331">-Sign [&lt;SwitchParameter&gt;]</span><span class="sxs-lookup"><span data-stu-id="5e276-331">-Sign [&lt;SwitchParameter&gt;]</span></span> |<span data-ttu-id="5e276-332">省略可能</span><span class="sxs-lookup"><span data-stu-id="5e276-332">Optional</span></span> |<span data-ttu-id="5e276-333">出力する Windows アプリ パッケージに、テスト用に生成された証明書を使用して署名するようにこのスクリプトに指示します。</span><span class="sxs-lookup"><span data-stu-id="5e276-333">Tells this script to sign the output Windows app package by using a generated certificate for testing purposes.</span></span> <span data-ttu-id="5e276-334">このスイッチは、```-MakeAppx``` スイッチと共に指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="5e276-334">This switch should be present alongside the switch ```-MakeAppx```.</span></span> |
|<span data-ttu-id="5e276-335">&lt;共通パラメーター&gt;</span><span class="sxs-lookup"><span data-stu-id="5e276-335">&lt;Common parameters&gt;</span></span> |<span data-ttu-id="5e276-336">必須</span><span class="sxs-lookup"><span data-stu-id="5e276-336">Required</span></span> |<span data-ttu-id="5e276-337">このコマンドレットは、共通パラメーター *Verbose*、*Debug*、*ErrorAction*、*ErrorVariable*、*WarningAction*、*WarningVariable*、*OutBuffer*、*PipelineVariable*、*OutVariable* をサポートします。</span><span class="sxs-lookup"><span data-stu-id="5e276-337">This cmdlet supports the common parameters: *Verbose*, *Debug*, *ErrorAction*, *ErrorVariable*, *WarningAction*, *WarningVariable*, *OutBuffer*, *PipelineVariable*, and *OutVariable*.</span></span> <span data-ttu-id="5e276-338">詳しくは、「[about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5e276-338">For more info, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).</span></span> |
| <span data-ttu-id="5e276-339">-Verify [&lt;SwitchParameter&gt;]</span><span class="sxs-lookup"><span data-stu-id="5e276-339">-Verify [&lt;SwitchParameter&gt;]</span></span> |<span data-ttu-id="5e276-340">省略可能</span><span class="sxs-lookup"><span data-stu-id="5e276-340">Optional</span></span> |<span data-ttu-id="5e276-341">指定された場合、デスクトップ ブリッジと Windows ストアの要件に照らして、アプリ パッケージを検証するように DAC に指示するスイッチ。</span><span class="sxs-lookup"><span data-stu-id="5e276-341">A switch that, when present, tells the DAC to validate the app package against Desktop Bridge and Windows Store requirements.</span></span> <span data-ttu-id="5e276-342">結果は、検証レポート "VerifyReport.xml" で、ブラウザーでの視覚化に最適です。</span><span class="sxs-lookup"><span data-stu-id="5e276-342">The result is a validation report "VerifyReport.xml", which is best visualized in a browser.</span></span> <span data-ttu-id="5e276-343">このスイッチは、`-MakeAppx` スイッチと共に指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="5e276-343">This switch should be present alongside the switch `-MakeAppx`.</span></span> |
|<span data-ttu-id="5e276-344">-PublishComRegistrations</span><span class="sxs-lookup"><span data-stu-id="5e276-344">-PublishComRegistrations</span></span>| <span data-ttu-id="5e276-345">省略可能</span><span class="sxs-lookup"><span data-stu-id="5e276-345">Optional</span></span>| <span data-ttu-id="5e276-346">インストーラーによって行われたすべての パブリック COM 登録をスキャンし、有効な登録をマニフェストで公開します。</span><span class="sxs-lookup"><span data-stu-id="5e276-346">Scans all public COM registrations made by your installer and publishes the valid ones in your manifest.</span></span> <span data-ttu-id="5e276-347">このフラグは、これらの登録を他のアプリケーションで利用できるようにする場合にのみ使用してください。</span><span class="sxs-lookup"><span data-stu-id="5e276-347">Use this flag only if you want to make these registrations available to other applications.</span></span> <span data-ttu-id="5e276-348">これらの登録を対象アプリケーションでのみ使用する場合、このフラグを使用する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="5e276-348">You don't need to use this flag if these registrations will be used only by your application.</span></span> <br><br><span data-ttu-id="5e276-349">アプリをパッケージ化した後、正常に動作するように COM 登録を行うには、[こちらの記事](https://blogs.windows.com/buildingapps/2017/04/13/com-server-ole-document-support-desktop-bridge/#lDg5gSFxJ2TDlpC6.97)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5e276-349">Review [this article](https://blogs.windows.com/buildingapps/2017/04/13/com-server-ole-document-support-desktop-bridge/#lDg5gSFxJ2TDlpC6.97) to make sure that your COM registrations behave as you expect after you package your app.</span></span>

<span id="run-app" />
## <a name="run-the-packaged-app"></a><span data-ttu-id="5e276-350">パッケージ アプリを実行する</span><span class="sxs-lookup"><span data-stu-id="5e276-350">Run the packaged app</span></span>

<span data-ttu-id="5e276-351">アプリを実行するには、2 種類の方法があります。</span><span class="sxs-lookup"><span data-stu-id="5e276-351">There's two ways to run your app.</span></span>

<span data-ttu-id="5e276-352">1 つ目は、PowerShell コマンド プロンプトを開いて、```Add-AppxPackage –Register AppxManifest.xml``` というコマンドを入力する方法です。</span><span class="sxs-lookup"><span data-stu-id="5e276-352">One way is to open a PowerShell command prompt, and then type this command: ```Add-AppxPackage –Register AppxManifest.xml```.</span></span> <span data-ttu-id="5e276-353">アプリに署名する必要がないため、アプリを最も簡単に実行できるのはこちらの方法です。</span><span class="sxs-lookup"><span data-stu-id="5e276-353">It's probably the easiest way to run your app because you don't have to sign it.</span></span>

<span data-ttu-id="5e276-354">2 つ目は、証明書を使ってアプリに署名する方法です。</span><span class="sxs-lookup"><span data-stu-id="5e276-354">Another way is to sign your app with a certificate.</span></span> <span data-ttu-id="5e276-355">```sign``` パラメーターを使用すると、Desktop App Converter によって証明書が生成され、その証明書でアプリへの署名が行われます。</span><span class="sxs-lookup"><span data-stu-id="5e276-355">If you use the ```sign``` parameter, the Desktop App Converter will generate one for you, and then sign your app with it.</span></span> <span data-ttu-id="5e276-356">その証明書ファイルは **auto-generated.cer** という名前になり、パッケージ アプリのルート フォルダーに配置されます。</span><span class="sxs-lookup"><span data-stu-id="5e276-356">That file is named **auto-generated.cer**, and you can find it in the root folder of your packaged app.</span></span>

<span data-ttu-id="5e276-357">生成された証明書をインストールし、アプリを実行するには、次の手順を実行します。</span><span class="sxs-lookup"><span data-stu-id="5e276-357">Follow these steps to install the generated certificate, and then run your app.</span></span>

1. <span data-ttu-id="5e276-358">**auto-generated.cer** ファイルをダブルクリックして証明書をインストールします。</span><span class="sxs-lookup"><span data-stu-id="5e276-358">Double-click the **auto-generated.cer** file to install the certificate.</span></span>

   ![生成された証明書ファイル](images/desktop-to-uwp/generated-cert-file.png)

   > [!NOTE]
   > <span data-ttu-id="5e276-360">パスワードを求められた場合は、既定のパスワード "123456" を使用します。</span><span class="sxs-lookup"><span data-stu-id="5e276-360">If you're prompted for a password, use the default password "123456".</span></span>

2. <span data-ttu-id="5e276-361">**[証明書]** ダイアログ ボックスで、**[証明書のインストール]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="5e276-361">In the **Certificate** dialog box, choose the **Install Certificate** button.</span></span>
3. <span data-ttu-id="5e276-362">**証明書インポート ウィザード**で、証明書を**ローカル コンピューター**にインストールし、証明書を "**信頼されたユーザー**" の証明書ストアに配置します。</span><span class="sxs-lookup"><span data-stu-id="5e276-362">In the **Certificate Import Wizard**, install the certificate onto the **Local Machine**, and place the certificate into the **Trusted People** certificate store.</span></span>

   ![信頼されたユーザー ストア](images/desktop-to-uwp/trusted-people-store.png)

5. <span data-ttu-id="5e276-364">パッケージ アプリのルート フォルダーで、Windows アプリのパッケージ ファイルをダブルクリックします。</span><span class="sxs-lookup"><span data-stu-id="5e276-364">In root folder of your packaged app, double click the Windows app package file.</span></span>

   ![Windows アプリのパッケージ ファイル](images/desktop-to-uwp/windows-app-package.png)

6. <span data-ttu-id="5e276-366">**[インストール]** を選択してアプリをインストールします。</span><span class="sxs-lookup"><span data-stu-id="5e276-366">Install the app, by choosing the **Install** button.</span></span>

   ![[インストール] ボタン](images/desktop-to-uwp/install.png)


## <a name="modify-the-packaged-app"></a><span data-ttu-id="5e276-368">パッケージ アプリを変更する</span><span class="sxs-lookup"><span data-stu-id="5e276-368">Modify the packaged app</span></span>

<span data-ttu-id="5e276-369">パッケージ アプリには、バグの修正、ビジュアル資産の追加、モダン エクスペリエンス (ライブ タイルなど) によるアプリの拡張などのために変更が必要になる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="5e276-369">You'll likely make changes to your packaged app to address bugs, add visual assets, or enhance your app with modern experiences such as live tiles.</span></span>

<span data-ttu-id="5e276-370">変更を加えた後、もう一度コンバーターを実行する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="5e276-370">After you make your changes, you don't need to run the converter again.</span></span> <span data-ttu-id="5e276-371">MakeAppx ツールと、DAC によってアプリ用に生成される appxmanifest.xml ファイルを使ってアプリを再パッケージ化することができます。</span><span class="sxs-lookup"><span data-stu-id="5e276-371">You can repackage your app by using the MakeAppx tool and the appxmanifest.xml file the DAC generates for your app.</span></span> <span data-ttu-id="5e276-372">「[Windows アプリ パッケージを生成する](desktop-to-uwp-manual-conversion.md#make-appx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5e276-372">See [Generate a Windows app package](desktop-to-uwp-manual-conversion.md#make-appx).</span></span>

> [!NOTE]
> <span data-ttu-id="5e276-373">インストーラーによるレジストリ設定を変更した場合は、その変更を適用するために、Desktop App Converter をもう一度実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="5e276-373">If you make changes to registry settings that your installer makes, you will have to run the Desktop App Converter again to pick up those changes.</span></span>

**<span data-ttu-id="5e276-374">ビデオ</span><span class="sxs-lookup"><span data-stu-id="5e276-374">Videos</span></span>**

|<span data-ttu-id="5e276-375">出力の変更と再パッケージ化</span><span class="sxs-lookup"><span data-stu-id="5e276-375">Modify and repackage output</span></span> |<span data-ttu-id="5e276-376">デモ: 出力の変更と再パッケージ化</span><span class="sxs-lookup"><span data-stu-id="5e276-376">Demo: Modify and repackage output</span></span>|
|---|---|
|<iframe src="https://mva.microsoft.com/en-US/training-courses-embed/developers-guide-to-the-desktop-bridge-17373/Video-Modifying-and-Repackaging-Output-from-Desktop-App-Converter-OwpAJ3WhD_6706218965" width="426" height="472" allowFullScreen frameBorder="0"></iframe>|<iframe src="https://mva.microsoft.com/en-US/training-courses-embed/developers-guide-to-the-desktop-bridge-17373/Demo-Modify-Output-from-Desktop-App-Converter-gEnsa3WhD_8606218965" width="426" height="472" allowFullScreen frameBorder="0"></iframe>|

<span data-ttu-id="5e276-377">次の 2 つのセクションでは、パッケージ アプリについて検討可能な調整オプションについて説明します。</span><span class="sxs-lookup"><span data-stu-id="5e276-377">The following two sections describe a couple of optional fix-ups to the packaged app that you might consider.</span></span>

### <a name="delete-unnecessary-files-and-registry-keys"></a><span data-ttu-id="5e276-378">不要なファイルとレジストリ キーを削除する</span><span class="sxs-lookup"><span data-stu-id="5e276-378">Delete unnecessary files and registry keys</span></span>

<span data-ttu-id="5e276-379">Desktop App Converter では、コンテナー内のファイルとシステム ノイズの除去に、非常に保守的なアプローチを取っています。</span><span class="sxs-lookup"><span data-stu-id="5e276-379">The desktop App Converter takes a very conservative approach to filtering out files and system noise in the container.</span></span>

<span data-ttu-id="5e276-380">VFS フォルダーを確認し、インストーラーに必要ないファイルがあれば、削除することもできます。</span><span class="sxs-lookup"><span data-stu-id="5e276-380">If you want, you can review the VFS folder and delete any files that your installer doesn't need.</span></span>  <span data-ttu-id="5e276-381">また、Reg.dat の内容を確認し、アプリによってインストールされないキーや不要なキーがあれば、削除できます。</span><span class="sxs-lookup"><span data-stu-id="5e276-381">You can also review the contents of Reg.dat and delete any keys that are not installed/needed by the app.</span></span>

### <a name="fix-corrupted-pe-headers"></a><span data-ttu-id="5e276-382">破損した PEヘッダーを修正する</span><span class="sxs-lookup"><span data-stu-id="5e276-382">Fix corrupted PE headers</span></span>

<span data-ttu-id="5e276-383">DesktopAppConverter は 変換処理中に PEHeaderCertFixTool を自動的に実行し、破損している PEヘッダーを修正します。</span><span class="sxs-lookup"><span data-stu-id="5e276-383">During the conversion process, the DesktopAppConverter automatically runs the PEHeaderCertFixTool to fixup any corrupted PE headers.</span></span> <span data-ttu-id="5e276-384">ただし、UWP の Windows アプリ パッケージ、ルーズ ファイル、または特定のバイナリで、PEHeaderCertFixTool を実行することも可能です。</span><span class="sxs-lookup"><span data-stu-id="5e276-384">However, you can also run the PEHeaderCertFixTool on a UWP Windows app package, loose files, or a specific binary.</span></span> <span data-ttu-id="5e276-385">次に例を示します。</span><span class="sxs-lookup"><span data-stu-id="5e276-385">Here's an example.</span></span>

```CMD
PEHeaderCertFixTool.exe <binary file>|<.appx package>|&lt;folder> [/c] [/v]
 /c   -- check for corrupted certificate but do not fix (optional)
 /v   -- verbose (optional)
example1: PEHeaderCertFixTool app.exe
example2: PEHeaderCertFixTool c:\package.appx /c
example3: PEHeaderCertFixTool c:\myapp /c /v
```

## <a name="known-issues-and-disclosures"></a><span data-ttu-id="5e276-386">既知の問題と開示情報</span><span class="sxs-lookup"><span data-stu-id="5e276-386">Known issues and disclosures</span></span>

### <a name="known-issues-and-workarounds"></a><span data-ttu-id="5e276-387">既知の問題と回避方法</span><span class="sxs-lookup"><span data-stu-id="5e276-387">Known issues and workarounds</span></span>

<span data-ttu-id="5e276-388">ここでは、既知の問題と、試すことのできる解決方法を示します。</span><span class="sxs-lookup"><span data-stu-id="5e276-388">Here's some known issues and some things you can try to resolve them.</span></span>

#### <a name="ecreatingisolatedenvfailed-an-estartingisolatedenvfailed-errors"></a><span data-ttu-id="5e276-389">E_CREATING_ISOLATED_ENV_FAILED エラーと E_STARTING_ISOLATED_ENV_FAILED エラー</span><span class="sxs-lookup"><span data-stu-id="5e276-389">E_CREATING_ISOLATED_ENV_FAILED an E_STARTING_ISOLATED_ENV_FAILED errors</span></span>    

<span data-ttu-id="5e276-390">これらのエラーのうちいずれかが発生した場合は、[ダウンロード センター](https://aka.ms/converterimages)から取得した有効な基本イメージを使用しているか確認してください。</span><span class="sxs-lookup"><span data-stu-id="5e276-390">If you receive either of these errors, make sure that you're using a valid base image from the [download center](https://aka.ms/converterimages).</span></span>
<span data-ttu-id="5e276-391">有効な基本イメージを使っている場合は、コマンドに ``-Cleanup All`` を含めてみてください。</span><span class="sxs-lookup"><span data-stu-id="5e276-391">If you’re using a valid base image, try using ``-Cleanup All`` in your command.</span></span>
<span data-ttu-id="5e276-392">それでも問題が解決しない場合は、調査用としてログを converter@microsoft.com にお送りください。</span><span class="sxs-lookup"><span data-stu-id="5e276-392">If that does not work, please send us your logs at converter@microsoft.com to help us investigate.</span></span>

#### <a name="new-containernetwork-the-object-already-exists-error"></a><span data-ttu-id="5e276-393">"New-ContainerNetwork: オブジェクトは既に存在します" エラー</span><span class="sxs-lookup"><span data-stu-id="5e276-393">New-ContainerNetwork: The object already exists error</span></span>

<span data-ttu-id="5e276-394">新しい基本イメージをセットアップするときは、このエラーが発生する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="5e276-394">You might receive this error when you setup a new base image.</span></span> <span data-ttu-id="5e276-395">Desktop App Converter が先にインストールされた開発用コンピューターに Windows Insider フライトがある場合に、このエラーが発生することがあります。</span><span class="sxs-lookup"><span data-stu-id="5e276-395">This can happen if you have a Windows Insider flight on a developer machine that previously had the Desktop App Converter installed.</span></span>

<span data-ttu-id="5e276-396">この問題を解決するには、管理者特権で開いたコマンド プロンプトで `Netsh int ipv4 reset` コマンドを実行して、コンピューターを再起動します。</span><span class="sxs-lookup"><span data-stu-id="5e276-396">To resolve this issue, try running the command `Netsh int ipv4 reset` from an elevated command prompt, and then reboot your machine.</span></span>

#### <a name="your-net-app-is-compiled-with-the-anycpu-build-option-and-fails-to-install"></a><span data-ttu-id="5e276-397">.NET アプリが "AnyCPU" ビルド オプションでコンパイルされ、インストールに失敗する</span><span class="sxs-lookup"><span data-stu-id="5e276-397">Your .NET app is compiled with the "AnyCPU" build option and fails to install</span></span>

<span data-ttu-id="5e276-398">この問題は、メインの実行可能ファイルまたは何らかの依存ファイルが、**Program Files** または **Windows\System32** のフォルダー階層に配置された場合に発生することがあります。</span><span class="sxs-lookup"><span data-stu-id="5e276-398">This can happen if the main executable or any of the dependencies were placed anywhere in the **Program Files** or **Windows\System32** folder hierarchy.</span></span>

<span data-ttu-id="5e276-399">この問題を解決するには、アーキテクチャ固有のデスクトップ インストーラー (32 ビットまたは 64 ビット) を使って Windowsアプリ パッケージを生成してみてください。</span><span class="sxs-lookup"><span data-stu-id="5e276-399">To resolve this issue, try using your architecture-specific desktop installer (32 bit or 64 bit) to generate a Windows app package.</span></span>

#### <a name="publishing-public-side-by-side-fusion-assemblies-wont-work"></a><span data-ttu-id="5e276-400">パブリック side-by-side Fusion アセンブリの公開が機能しない</span><span class="sxs-lookup"><span data-stu-id="5e276-400">Publishing public side-by-side Fusion assemblies won't work</span></span>

 <span data-ttu-id="5e276-401">アプリケーションは、インストール中にパブリック side-by-side Fusion アセンブリを公開して、他のプロセスからアクセスできるようにします。</span><span class="sxs-lookup"><span data-stu-id="5e276-401">During install, an application can publish public side-by-side Fusion assemblies, accessible to any other process.</span></span> <span data-ttu-id="5e276-402">これらのアセンブリは、プロセスのアクティブ化コンテキストの作成中に、CSRSS.exe という名前のシステム プロセスによって取得されます。</span><span class="sxs-lookup"><span data-stu-id="5e276-402">During process activation context creation, these assemblies are retrieved by a system process named CSRSS.exe.</span></span> <span data-ttu-id="5e276-403">変換プロセスでこれが行われると、アクティブ化コンテキスト作成とこれらのアセンブリのモジュール読み込みは失敗します。</span><span class="sxs-lookup"><span data-stu-id="5e276-403">When this is done for a converted process, activation context creation and module loading of these assemblies will fail.</span></span> <span data-ttu-id="5e276-404">side-by-side Fusion アセンブリは、次の場所に登録されています。</span><span class="sxs-lookup"><span data-stu-id="5e276-404">The side-by-side Fusion assemblies are registered in the following locations:</span></span>
  + <span data-ttu-id="5e276-405">レジストリ:</span><span class="sxs-lookup"><span data-stu-id="5e276-405">Registry:</span></span> `HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\SideBySide\Winners`
  + <span data-ttu-id="5e276-406">ファイル システム: %windir%\\SideBySide</span><span class="sxs-lookup"><span data-stu-id="5e276-406">File System: %windir%\\SideBySide</span></span>

<span data-ttu-id="5e276-407">これは、既知の制限であり、今のところ回避策はありません。</span><span class="sxs-lookup"><span data-stu-id="5e276-407">This is a known limitation and no workaround currently exists.</span></span> <span data-ttu-id="5e276-408">ただし、ComCtl などの受信トレイ アセンブリは OS に同梱されているため、これらのアセンブリに依存していても安全です。</span><span class="sxs-lookup"><span data-stu-id="5e276-408">That said, Inbox assemblies, like ComCtl, are shipped with the OS, so taking a dependency on them is safe.</span></span>

#### <a name="error-found-in-xml-the-executable-attribute-is-invalid---the-value-myappexe-is-invalid-according-to-its-datatype"></a><span data-ttu-id="5e276-409">XML にエラーが見つかり、</span><span class="sxs-lookup"><span data-stu-id="5e276-409">Error found in XML.</span></span> <span data-ttu-id="5e276-410">'Executable' 属性が無効 - 'MyApp.EXE' の値がデータ型に対して無効</span><span class="sxs-lookup"><span data-stu-id="5e276-410">The 'Executable' attribute is invalid - The value 'MyApp.EXE' is invalid according to its datatype</span></span>

<span data-ttu-id="5e276-411">この問題は、アプリケーションに含まれる実行可能ファイルの **.EXE** 拡張子が大文字になっている場合に発生することがあります。</span><span class="sxs-lookup"><span data-stu-id="5e276-411">This can happen if the executables in your application have a capitalized **.EXE** extension.</span></span> <span data-ttu-id="5e276-412">この拡張子が大文字であってもアプリの実行には影響しませんが、DAC ではこのエラーが発生する場合があります。</span><span class="sxs-lookup"><span data-stu-id="5e276-412">Although, the casing of this extension shouldn't affect whether your app runs, this can cause the DAC to generate this error.</span></span>

<span data-ttu-id="5e276-413">この問題を解決するには、パッケージ化を行うときに **-AppExecutable** フラグを指定し、メインの実行可能ファイルの拡張子として小文字の ".exe" を使用してみてください (例: MYAPP.exe)。</span><span class="sxs-lookup"><span data-stu-id="5e276-413">To resolve this issue, try specifying the **-AppExecutable** flag when you package, and use the lower case ".exe" as the extension of your main executable (For example: MYAPP.exe).</span></span>    <span data-ttu-id="5e276-414">または、アプリに含まれるすべての実行可能ファイルについて、小文字を大文字に変更することもできます (例: .EXE を .exe に変更する)。</span><span class="sxs-lookup"><span data-stu-id="5e276-414">Alternately you can change the casing for all executables in your app from lowercase to uppercase (For example: from .EXE to .exe).</span></span>


### <a name="telemetry-from-desktop-app-converter"></a><span data-ttu-id="5e276-415">Desktop App Converter の利用統計情報</span><span class="sxs-lookup"><span data-stu-id="5e276-415">Telemetry from Desktop App Converter</span></span>

<span data-ttu-id="5e276-416">Desktop App Converter は、ソフトウェアの使用者と使用方法に関する情報を収集して、この情報を Microsoft に送信することがあります。</span><span class="sxs-lookup"><span data-stu-id="5e276-416">Desktop App Converter may collect information about you and your use of the software and send this info to Microsoft.</span></span> <span data-ttu-id="5e276-417">Microsoft のデータ収集と製品ドキュメントでの使用の詳細については、「[マイクロソフトのプライバシーに関する声明](http://go.microsoft.com/fwlink/?LinkId=521839)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5e276-417">You can learn more about Microsoft's data collection and use in the product documentation and in the [Microsoft Privacy Statement](http://go.microsoft.com/fwlink/?LinkId=521839).</span></span> <span data-ttu-id="5e276-418">マイクロソフトのプライバシーに関する声明の該当するすべての条項に準拠することに同意します。</span><span class="sxs-lookup"><span data-stu-id="5e276-418">You agree to comply with all applicable provisions of the Microsoft Privacy Statement.</span></span>

<span data-ttu-id="5e276-419">既定では、Desktop App Converter の利用統計情報は有効にされています。</span><span class="sxs-lookup"><span data-stu-id="5e276-419">By default, telemetry will be enabled for the Desktop App Converter.</span></span> <span data-ttu-id="5e276-420">利用統計情報を目的の設定に構成するには、次のレジストリ キーを追加します。</span><span class="sxs-lookup"><span data-stu-id="5e276-420">Add the following registry key to configure telemetry to a desired setting:</span></span>  

```cmd
HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\DesktopAppConverter
```
+ <span data-ttu-id="5e276-421">DWORD を 1 に設定して、*DisableTelemetry* 値を追加または編集します。</span><span class="sxs-lookup"><span data-stu-id="5e276-421">Add or edit the *DisableTelemetry* value by using a DWORD set to 1.</span></span>
+ <span data-ttu-id="5e276-422">利用統計情報を有効にするには、このキーを削除するかキーの値を 0 に設定します。</span><span class="sxs-lookup"><span data-stu-id="5e276-422">To enable telemetry, remove the key or set the value to 0.</span></span>

### <a name="language-support"></a><span data-ttu-id="5e276-423">言語サポート</span><span class="sxs-lookup"><span data-stu-id="5e276-423">Language support</span></span>

<span data-ttu-id="5e276-424">Desktop App Converterは、Unicode をサポートしていません。したがって、漢字または非 ASCII 文字をツールで使用することはできません。</span><span class="sxs-lookup"><span data-stu-id="5e276-424">The Desktop App Converter does not support Unicode; thus, no Chinese characters or non-ASCII characters can be used with the tool.</span></span>

## <a name="next-steps"></a><span data-ttu-id="5e276-425">次のステップ</span><span class="sxs-lookup"><span data-stu-id="5e276-425">Next steps</span></span>

**<span data-ttu-id="5e276-426">アプリを実行する/問題を検出して修正する</span><span class="sxs-lookup"><span data-stu-id="5e276-426">Run your app / find and fix issues</span></span>**

<span data-ttu-id="5e276-427">[パッケージ デスクトップ アプリの実行、デバッグ、テスト (デスクトップ ブリッジ)](desktop-to-uwp-debug.md) をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5e276-427">See [Run, debug, and test a packaged desktop app (Desktop Bridge)](desktop-to-uwp-debug.md)</span></span>

**<span data-ttu-id="5e276-428">アプリを配布する</span><span class="sxs-lookup"><span data-stu-id="5e276-428">Distribute your app</span></span>**

<span data-ttu-id="5e276-429">[パッケージ デスクトップ アプリの配布 (デスクトップ ブリッジ)](desktop-to-uwp-distribute.md) をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5e276-429">See [Distribute a packaged desktop app (Desktop Bridge)](desktop-to-uwp-distribute.md)</span></span>

**<span data-ttu-id="5e276-430">特定の質問に対する回答を見つける</span><span class="sxs-lookup"><span data-stu-id="5e276-430">Find answers to specific questions</span></span>**

<span data-ttu-id="5e276-431">マイクロソフトのチームでは、[StackOverflow タグ](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge)をチェックしています。</span><span class="sxs-lookup"><span data-stu-id="5e276-431">Our team monitors these [StackOverflow tags](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge).</span></span>

**<span data-ttu-id="5e276-432">この記事に関するフィードバックを送信する</span><span class="sxs-lookup"><span data-stu-id="5e276-432">Give feedback about this article</span></span>**

<span data-ttu-id="5e276-433">下のコメント セクションをご利用ください。</span><span class="sxs-lookup"><span data-stu-id="5e276-433">Use the comments section below.</span></span>
