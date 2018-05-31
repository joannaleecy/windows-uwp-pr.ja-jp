---
author: normesta
Description: Run the Desktop Converter App to package a Windows desktop application (like Win32, WPF, and Windows Forms).
Search.Product: eADQiWindows 10XVcnh
title: Desktop App Converter を使用してアプリをパッケージ化する (デスクトップ ブリッジ)
ms.author: normesta
ms.date: 09/18/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp
ms.assetid: 74c84eb6-4714-4e12-a658-09cb92b576e3
ms.localizationpriority: medium
ms.openlocfilehash: f867861537ddfb7fe346011cd637156854e2f7d8
ms.sourcegitcommit: 91511d2d1dc8ab74b566aaeab3ef2139e7ed4945
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/30/2018
ms.locfileid: "1817187"
---
# <a name="package-an-app-using-the-desktop-app-converter-desktop-bridge"></a><span data-ttu-id="ed420-103">Desktop App Converter を使用してアプリをパッケージ化する (デスクトップ ブリッジ)</span><span class="sxs-lookup"><span data-stu-id="ed420-103">Package an app using the Desktop App Converter (Desktop Bridge)</span></span>

[<span data-ttu-id="ed420-104">Desktop App Converter を入手する</span><span class="sxs-lookup"><span data-stu-id="ed420-104">Get the Desktop App Converter</span></span>](https://aka.ms/converter)

<span data-ttu-id="ed420-105">Desktop App Converter (DAC) を使用すると、デスクトップ アプリをユニバーサル Windows プラットフォーム (UWP) に移行することができます。</span><span class="sxs-lookup"><span data-stu-id="ed420-105">You can use the Desktop App Converter (DAC) to bring your desktop apps to the Universal Windows Platform (UWP).</span></span> <span data-ttu-id="ed420-106">Win32 アプリや .NET 4.6.1 を使用して作成されたアプリも対象になります。</span><span class="sxs-lookup"><span data-stu-id="ed420-106">This includes Win32 apps and apps that you've created by using .NET 4.6.1.</span></span>

![DAC アイコン](images/desktop-to-uwp/dac.png)

<span data-ttu-id="ed420-108">このツールの名前には "Converter" という用語が含まれますが、実は、アプリの変換は行いません。</span><span class="sxs-lookup"><span data-stu-id="ed420-108">While the term "Converter" appears in the name of this tool, it doesn't actually convert your app.</span></span> <span data-ttu-id="ed420-109">アプリは変更されません。</span><span class="sxs-lookup"><span data-stu-id="ed420-109">Your app remains unchanged.</span></span> <span data-ttu-id="ed420-110">しかし、DACは、パッケージ ID を持ち多くの WinRT API を呼び出すことができる Windows アプリ パッケージを生成します。</span><span class="sxs-lookup"><span data-stu-id="ed420-110">However, this tool generates a Windows app package with a package identity and the ability to call a vast range of WinRT APIs.</span></span>

<span data-ttu-id="ed420-111">このパッケージは、開発コンピューターで Add-AppxPackage という PowerShell コマンドレットを使ってインストールすることができます。</span><span class="sxs-lookup"><span data-stu-id="ed420-111">You can install that package by using the Add-AppxPackage PowerShell cmdlet on your development machine.</span></span>

<span data-ttu-id="ed420-112">このコンバーターは、コンバーターのダウンロードに含まれるクリーンな状態の基本イメージを使って、分離された Windows 環境でデスクトップ インストーラーを実行します。</span><span class="sxs-lookup"><span data-stu-id="ed420-112">The converter runs the desktop installer in an isolated Windows environment by using a clean base image provided as part of the converter download.</span></span> <span data-ttu-id="ed420-113">デスクトップ インストーラーが作成するすべてのレジストリとファイル システムの I/O がキャプチャされ、出力の一部としてパッケージ化されます。</span><span class="sxs-lookup"><span data-stu-id="ed420-113">It captures any registry and file system I/O made by the desktop installer and packages it as part of the output.</span></span>

>[!IMPORTANT]
><span data-ttu-id="ed420-114">デスクトップ ブリッジは、Windows 10 Version 1607 で導入されており、Windows 10 Anniversary Update (10.0、ビルド 14393) 以降のリリースをターゲットとする Visual Studio プロジェクトでのみ使用できます。</span><span class="sxs-lookup"><span data-stu-id="ed420-114">The Desktop Bridge was introduced in Windows 10, version 1607, and it can only be used in projects that target Windows 10 Anniversary Update (10.0; Build 14393) or a later release in Visual Studio.</span></span>

> [!NOTE]
> <span data-ttu-id="ed420-115">Microsoft Virtual Academy から公開されている、<a href="https://mva.microsoft.com/en-US/training-courses/developers-guide-to-the-desktop-bridge-17373?l=oZG0B1WhD_8406218965/">このシリーズ</a>の短いビデオをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ed420-115">Checkout <a href="https://mva.microsoft.com/en-US/training-courses/developers-guide-to-the-desktop-bridge-17373?l=oZG0B1WhD_8406218965/">this series</a> of short videos published by the Microsoft Virtual Academy.</span></span> <span data-ttu-id="ed420-116">これらのビデオでは、Desktop App Converter を使用する一般的な方法が紹介されています。</span><span class="sxs-lookup"><span data-stu-id="ed420-116">These videos walk you through some common ways to use the Desktop App Converter.</span></span>

## <a name="the-dac-does-more-than-just-generate-a-package-for-you"></a><span data-ttu-id="ed420-117">DAC が行うのはパッケージの生成だけではありません</span><span class="sxs-lookup"><span data-stu-id="ed420-117">The DAC does more than just generate a package for you</span></span>

<span data-ttu-id="ed420-118">他にも以下のような処理を実行できます。</span><span class="sxs-lookup"><span data-stu-id="ed420-118">Here's a few extra things it can do for you.</span></span>

**<span data-ttu-id="ed420-119">Windows 10 Creators Update</span><span class="sxs-lookup"><span data-stu-id="ed420-119">Windows 10 Creators Update</span></span>**

<span data-ttu-id="ed420-120">:heavy_check_mark: プレビュー ハンドラー、サムネイル ハンドラー、プロパティ ハンドラー、ファイアウォール規則、URL フラグを自動的に登録する。</span><span class="sxs-lookup"><span data-stu-id="ed420-120">:heavy_check_mark: Automatically register your preview handlers, thumbnail handlers, property handlers, firewall rules, URL flags.</span></span>

<span data-ttu-id="ed420-121">:heavy_check_mark: ファイルの種類のマッピングを自動的に登録する。これによりユーザーは、エクスプローラーの **[種類]** 列を使ってファイルをグループ化できるようになります。</span><span class="sxs-lookup"><span data-stu-id="ed420-121">:heavy_check_mark: Automatically register file type mappings that enable users to group files by using the **Kind** column in File Explorer.</span></span>

<span data-ttu-id="ed420-122">:heavy_check_mark: 公開 COM サーバーを登録する。</span><span class="sxs-lookup"><span data-stu-id="ed420-122">:heavy_check_mark: Register your public COM servers.</span></span>

**<span data-ttu-id="ed420-123">Windows 10 Anniversary Update 以降</span><span class="sxs-lookup"><span data-stu-id="ed420-123">Windows 10 Anniversary Update or later</span></span>**

<span data-ttu-id="ed420-124">:heavy_check_mark: アプリをテストできるように、パッケージに自動的に署名する。</span><span class="sxs-lookup"><span data-stu-id="ed420-124">:heavy_check_mark: Automatically sign your package so that you can test your app.</span></span>

<span data-ttu-id="ed420-125">:heavy_check_mark: デスクトップ ブリッジと Microsoft Store の要件に照らしてアプリを検証する。</span><span class="sxs-lookup"><span data-stu-id="ed420-125">:heavy_check_mark: Validate your app against Desktop Bridge and Microsoft Store requirements.</span></span>

<span data-ttu-id="ed420-126">オプションの完全な一覧については、このガイドの「[パラメーター リファレンス](#command-reference)」セクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ed420-126">To find a complete list of options, see the [Parameters](#command-reference) section of this guide.</span></span>

<span data-ttu-id="ed420-127">パッケージを作成する準備ができたら、始めましょう。</span><span class="sxs-lookup"><span data-stu-id="ed420-127">If you're ready to create your package, let's start.</span></span>

## <a name="first-consider-how-youll-distribute-your-app"></a><span data-ttu-id="ed420-128">まず、アプリの配布方法を検討する</span><span class="sxs-lookup"><span data-stu-id="ed420-128">First, consider how you'll distribute your app</span></span>
<span data-ttu-id="ed420-129">アプリを [Microsoft Store](https://www.microsoft.com/store/apps) に公開する予定であれば、[このフォーム](https://developer.microsoft.com/windows/projects/campaigns/desktop-bridge)への記入から開始します。</span><span class="sxs-lookup"><span data-stu-id="ed420-129">If you plan to publish your app to the [Microsoft Store](https://www.microsoft.com/store/apps), start by filling out [this form](https://developer.microsoft.com/windows/projects/campaigns/desktop-bridge).</span></span> <span data-ttu-id="ed420-130">Microsoft から、オンボード プロセスを開始するための連絡があります。</span><span class="sxs-lookup"><span data-stu-id="ed420-130">Microsoft will contact you to start the onboarding process.</span></span> <span data-ttu-id="ed420-131">このプロセスでは、Microsoft Store 内の名前を予約し、アプリをパッケージ化するための情報を取得します。</span><span class="sxs-lookup"><span data-stu-id="ed420-131">As part of this process, you'll reserve a name in the store, and obtain information that you'll need to package your app.</span></span>

<span data-ttu-id="ed420-132">さらに、アプリケーションのパッケージの作成を開始する前に、必ず「[アプリのパッケージ化の準備 (デスクトップ ブリッジ)](desktop-to-uwp-prepare.md)」を確認してください。</span><span class="sxs-lookup"><span data-stu-id="ed420-132">Also, make sure to review this guide before you begin creating a package for your application: [Prepare to package an app (Desktop Bridge)](desktop-to-uwp-prepare.md).</span></span>

## <a name="make-sure-that-your-system-can-run-the-converter"></a><span data-ttu-id="ed420-133">システムで DCA を実行できることを確認する</span><span class="sxs-lookup"><span data-stu-id="ed420-133">Make sure that your system can run the converter</span></span>

<span data-ttu-id="ed420-134">システムが以下の要件を満たしていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="ed420-134">Make sure that your system meets the following requirements:</span></span>

* <span data-ttu-id="ed420-135">Windows 10 Anniversary Update (10.0.14393.0 以降) Pro または Enterprise エディション</span><span class="sxs-lookup"><span data-stu-id="ed420-135">Windows 10 Anniversary Update (10.0.14393.0 and later) Pro or Enterprise edition.</span></span>
* <span data-ttu-id="ed420-136">64 ビット (x64) プロセッサ</span><span class="sxs-lookup"><span data-stu-id="ed420-136">64 bit (x64) processor</span></span>
* <span data-ttu-id="ed420-137">ハードウェア支援による仮想化</span><span class="sxs-lookup"><span data-stu-id="ed420-137">Hardware-assisted virtualization</span></span>
* <span data-ttu-id="ed420-138">Second Level Address Translation (SLAT)</span><span class="sxs-lookup"><span data-stu-id="ed420-138">Second Level Address Translation (SLAT)</span></span>
* <span data-ttu-id="ed420-139">[Windows 10 用 Windows ソフトウェア開発キット (SDK)](https://go.microsoft.com/fwlink/?linkid=821375)</span><span class="sxs-lookup"><span data-stu-id="ed420-139">[Windows Software Development Kit (SDK) for Windows 10](https://go.microsoft.com/fwlink/?linkid=821375).</span></span>


## <a name="start-the-desktop-app-converter"></a><span data-ttu-id="ed420-140">Desktop App Converter を起動する</span><span class="sxs-lookup"><span data-stu-id="ed420-140">Start the Desktop App Converter</span></span>

1. <span data-ttu-id="ed420-141">[Desktop App Converter](https://aka.ms/converter)をダウンロードおよびインストールします。</span><span class="sxs-lookup"><span data-stu-id="ed420-141">Download and install the [Desktop App Converter](https://aka.ms/converter).</span></span>

2. <span data-ttu-id="ed420-142">管理者として Desktop App Converter を実行します。</span><span class="sxs-lookup"><span data-stu-id="ed420-142">Run the Desktop App Converter as an administrator.</span></span>

    ![DAC を管理者として実行する](images/desktop-to-uwp/run-converter.png)

   <span data-ttu-id="ed420-144">コンソール ウィンドウが開きます。</span><span class="sxs-lookup"><span data-stu-id="ed420-144">A console window appears.</span></span> <span data-ttu-id="ed420-145">コマンドを実行するには、このコンソール ウィンドウを使います。</span><span class="sxs-lookup"><span data-stu-id="ed420-145">You'll use that console window to run commands.</span></span>

## <a name="set-a-few-things-up-apps-with-installers-only"></a><span data-ttu-id="ed420-146">必要な設定を行う (インストーラーがあるアプリのみ) </span><span class="sxs-lookup"><span data-stu-id="ed420-146">Set a few things up (apps with installers only)</span></span>

<span data-ttu-id="ed420-147">アプリにインストーラーがない場合は、このセクションをスキップできます。</span><span class="sxs-lookup"><span data-stu-id="ed420-147">You can skip ahead to the next section if your app doesn't have an installer.</span></span>

1. <span data-ttu-id="ed420-148">オペレーティング システムのバージョン番号を特定します。</span><span class="sxs-lookup"><span data-stu-id="ed420-148">Identify the version number of your operating system.</span></span>

   <span data-ttu-id="ed420-149">そのためには、**[ファイル名を指定して実行]** ダイアログ ボックスで「**winver**」と入力し、**[OK]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="ed420-149">To do that, type **winver** in the **Run** dialog box, and then choose the **OK** button.</span></span>

   ![winver](images/desktop-to-uwp/winver.png)

   <span data-ttu-id="ed420-151">**[Windows のバージョン情報]** ダイアログ ボックスに Windows ビルドのバージョンが表示されます。</span><span class="sxs-lookup"><span data-stu-id="ed420-151">You'll find the version of your Windows build in the **About Windows** dialog box.</span></span>

   ![Windows 10 のバージョン](images/desktop-to-uwp/win-10-version.png)

2. <span data-ttu-id="ed420-153">適切な [Desktop App Converter 基本イメージ](https://aka.ms/converterimages)をダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="ed420-153">Download the appropriate [Desktop app Converter base image](https://aka.ms/converterimages).</span></span>

   <span data-ttu-id="ed420-154">ファイル名に含まれるバージョン番号が Windows ビルドのバージョン番号と一致していることを確認してください。</span><span class="sxs-lookup"><span data-stu-id="ed420-154">Make sure that the version number that appears in the name of the file matches the version number of your Windows build.</span></span>

   >[!IMPORTANT]
   > <span data-ttu-id="ed420-155">ビルド番号 **15063** を使用しており、そのビルドのマイナー バージョンが **.483** 以上 (例: **15063.540**) である場合は、**BaseImage-15063-UPDATE.wim** ファイルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="ed420-155">If you're using build number **15063**, and the minor version of that build is equal to or greater than **.483** (For example: **15063.540**), make sure to download the **BaseImage-15063-UPDATE.wim** file.</span></span> <span data-ttu-id="ed420-156">そのビルドのマイナー バージョンが **.483** 未満である場合は、**BaseImage-15063.wim** ファイルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="ed420-156">If the minor version of that build is less than **.483**, download the **BaseImage-15063.wim** file.</span></span> <span data-ttu-id="ed420-157">このベース ファイルの互換性のないバージョンを既にセットアップしている場合は、修正することができます。</span><span class="sxs-lookup"><span data-stu-id="ed420-157">If you've already setup an incompatible version of this base file, you can fix it.</span></span> <span data-ttu-id="ed420-158">その方法については、この[ブログの投稿](https://blogs.msdn.microsoft.com/appconsult/2017/08/04/desktop-app-converter-fails-on-windows-10-15063-483-and-later-how-to-solve-it/)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ed420-158">This [blog post](https://blogs.msdn.microsoft.com/appconsult/2017/08/04/desktop-app-converter-fails-on-windows-10-15063-483-and-later-how-to-solve-it/) explains how to do that.</span></span>

3. <span data-ttu-id="ed420-159">ダウンロードしたファイルを後で見つけることができるように、コンピューター上の適切な場所に置きます。</span><span class="sxs-lookup"><span data-stu-id="ed420-159">Place the downloaded file anywhere on your computer where you'll be able to find it later.</span></span>

4. <span data-ttu-id="ed420-160">Desktop App Converter を起動したときに表示されるコンソール ウィンドウで、コマンド ```Set-ExecutionPolicy bypass``` を実行します。</span><span class="sxs-lookup"><span data-stu-id="ed420-160">In the console window that appeared when you started the Desktop App Converter, run this command: ```Set-ExecutionPolicy bypass```.</span></span>
5. <span data-ttu-id="ed420-161">コマンド ```DesktopAppConverter.exe -Setup -BaseImage .\BaseImage-1XXXX.wim -Verbose``` を実行してコンバーターをセットアップします。</span><span class="sxs-lookup"><span data-stu-id="ed420-161">Set up the converter by running  this command: ```DesktopAppConverter.exe -Setup -BaseImage .\BaseImage-1XXXX.wim -Verbose```.</span></span>
6. <span data-ttu-id="ed420-162">画面の指示に従って、コンピューターを再起動します。</span><span class="sxs-lookup"><span data-stu-id="ed420-162">Restart your computer if you're prompted to do so.</span></span>

   <span data-ttu-id="ed420-163">コンバーターによって基本イメージが展開されると、コンソール ウィンドウに状態メッセージが表示されます。</span><span class="sxs-lookup"><span data-stu-id="ed420-163">Status messages appear in the console window as the converter expands the base image.</span></span> <span data-ttu-id="ed420-164">状態メッセージが表示されない場合は、任意のキーを押します。</span><span class="sxs-lookup"><span data-stu-id="ed420-164">If you don't see any status messages, press any key.</span></span> <span data-ttu-id="ed420-165">これにより、コンソール ウィンドウの内容が更新されます。</span><span class="sxs-lookup"><span data-stu-id="ed420-165">This can cause the contents of the console window to refresh.</span></span>

   ![コンソール ウィンドウに表示された状態メッセージ](images/desktop-to-uwp/bas-image-setup.png)

   <span data-ttu-id="ed420-167">基本イメージが完全に展開されたら、次のセクションに進みます。</span><span class="sxs-lookup"><span data-stu-id="ed420-167">When the base image is fully expanded, move to the next section.</span></span>

## <a name="package-an-app"></a><span data-ttu-id="ed420-168">アプリをパッケージ化する</span><span class="sxs-lookup"><span data-stu-id="ed420-168">Package an app</span></span>

<span data-ttu-id="ed420-169">アプリをパッケージ化するには、Desktop App Converter を起動したときに開くコンソール ウィンドウで ``DesktopAppConverter.exe`` コマンドを実行します。</span><span class="sxs-lookup"><span data-stu-id="ed420-169">To Package your app, run the ``DesktopAppConverter.exe`` command in the console window that opened when you started the Desktop App Converter.</span></span>  

<span data-ttu-id="ed420-170">パラメーターを使用して、アプリのパッケージ名、発行元、バージョン番号を指定します。</span><span class="sxs-lookup"><span data-stu-id="ed420-170">You'll specify the package name, publisher and version number of the app by using parameters.</span></span>

> [!NOTE]
> <span data-ttu-id="ed420-171">Windows ストアでアプリ名を予約済みの場合は、Windows デベロッパー センターのダッシュ ボードを使用して、パッケージと発行元名を取得できます。</span><span class="sxs-lookup"><span data-stu-id="ed420-171">If you've reserved your app name in the Windows store, you can obtain the package and publisher names by using the Windows Dev Center dashboard.</span></span> <span data-ttu-id="ed420-172">アプリを他のシステムにサイドローディング展開する場合は、独自の名前を指定できます。ただし、選択する発行元名は、アプリへの署名に使用する証明書の名前と一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ed420-172">If you plan to sideload your app onto other systems, you can provide your own names for these as long as the publisher name that you choose matches the name on the certificate you use to sign your app.</span></span>

### <a name="a-quick-look-at-command-parameters"></a><span data-ttu-id="ed420-173">コマンド パラメーターの確認</span><span class="sxs-lookup"><span data-stu-id="ed420-173">A quick look at command parameters</span></span>

<span data-ttu-id="ed420-174">必要なパラメーターは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="ed420-174">Here are the required parameters.</span></span>

```CMD
DesktopAppConverter.exe
-Installer <String>
-Destination <String>
-PackageName <String>
-Publisher <String>
-Version <Version>
```
<span data-ttu-id="ed420-175">各パラメーターについて詳しくは、[こちら](#command-reference)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ed420-175">You can read about each one [here](#command-reference).</span></span>

### <a name="examples"></a><span data-ttu-id="ed420-176">例</span><span class="sxs-lookup"><span data-stu-id="ed420-176">Examples</span></span>

<span data-ttu-id="ed420-177">アプリをパッケージ化する一般的な方法のいくつかを以下に示します。</span><span class="sxs-lookup"><span data-stu-id="ed420-177">Here's a few common ways to package your app.</span></span>

* [<span data-ttu-id="ed420-178">インストーラー (.msi) ファイルのあるアプリをパッケージ化する</span><span class="sxs-lookup"><span data-stu-id="ed420-178">Package an app that has an installer (.msi) file</span></span>](#installer-conversion)
* [<span data-ttu-id="ed420-179">セットアップの実行可能ファイルのあるアプリをパッケージ化する</span><span class="sxs-lookup"><span data-stu-id="ed420-179">Package an app that has a setup executable file</span></span>](#setup-conversion)
* [<span data-ttu-id="ed420-180">インストーラーのないアプリをパッケージ化する</span><span class="sxs-lookup"><span data-stu-id="ed420-180">Package an app that doesn't have an installer</span></span>](#no-installer-conversion)
* [<span data-ttu-id="ed420-181">アプリをパッケージ化し、アプリに署名して、ストアへの提出に備える</span><span class="sxs-lookup"><span data-stu-id="ed420-181">Package an app, sign the app, and prepare it for store submission</span></span>](#optional-parameters)

<a id="installer-conversion" />

#### <a name="package-an-app-that-has-an-installer-msi-file"></a><span data-ttu-id="ed420-182">インストーラー (.msi) ファイルのあるアプリをパッケージ化する</span><span class="sxs-lookup"><span data-stu-id="ed420-182">Package an app that has an installer (.msi) file</span></span>

<span data-ttu-id="ed420-183">``Installer`` パラメーターでインストーラー ファイルを指定します。</span><span class="sxs-lookup"><span data-stu-id="ed420-183">Point to the installer file by using the ``Installer`` parameter.</span></span>

```cmd
DesktopAppConverter.exe -Installer C:\Installer\MyAppSetup.msi -Destination C:\Output\MyApp -PackageName "MyApp" -Publisher "CN=MyPublisher" -Version 0.0.0.1
```

> [!IMPORTANT]
> <span data-ttu-id="ed420-184">ここで留意すべき重要なことが 2 つあります。</span><span class="sxs-lookup"><span data-stu-id="ed420-184">There are two important things to keep in mind here.</span></span> <span data-ttu-id="ed420-185">まず、インストーラーは独立したフォルダーに配置し、そのインストーラーに関連するファイルだけを同じフォルダーに配置してください。</span><span class="sxs-lookup"><span data-stu-id="ed420-185">First, make sure that your installer is located in an independent folder and that only files related to that installer are in the same folder.</span></span> <span data-ttu-id="ed420-186">コンバーターは、このフォルダーの内容をすべて、分離された Windows 環境にコピーします。</span><span class="sxs-lookup"><span data-stu-id="ed420-186">The converter copies all of the contents of that folder to the isolated Windows environment.</span></span> <br> <span data-ttu-id="ed420-187">2 つ目に、デベロッパー センターが数値で始まる ID をパッケージに割り当てる場合、必ず <i>-AppId</i> パラメーターも渡し、そのパラメーターの値として文字列サフィックスのみを使ってください (ピリオドの区切り記号の後)。</span><span class="sxs-lookup"><span data-stu-id="ed420-187">Secondly, if the dev center assigns an identity to your package that begins with a number, make sure that you also pass in the <i>-AppId</i> parameter, and use only the string suffix (after the period separator) as the value of that parameter.</span></span>  

**<span data-ttu-id="ed420-188">ビデオ</span><span class="sxs-lookup"><span data-stu-id="ed420-188">Video</span></span>**

<iframe src="https://mva.microsoft.com/en-US/training-courses-embed/developers-guide-to-the-desktop-bridge-17373/Demo-Convert-an-Application-That-Has-an-MSI-Installer-Kh1UU2WhD_7106218965" width="636" height="480" allowFullScreen frameBorder="0"></iframe>

<span data-ttu-id="ed420-189">インストーラーに、従属ライブラリやフレームワークのインストーラーが含まれている場合、少し異なる方法で整理する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ed420-189">If your installer includes installers for dependent libraries or frameworks, you might have to organize things a bit a differently.</span></span> <span data-ttu-id="ed420-190">[複数のインストーラーとデスクトップ ブリッジの連結に関する記事](https://blogs.msdn.microsoft.com/appconsult/2017/09/11/chaining-multiple-installers-with-the-desktop-app-converter/)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ed420-190">See [Chaining multiple installers with the Desktop Bridge](https://blogs.msdn.microsoft.com/appconsult/2017/09/11/chaining-multiple-installers-with-the-desktop-app-converter/).</span></span>

<a id="setup-conversion" />

#### <a name="package-an-app-that-has-a-setup-executable-file"></a><span data-ttu-id="ed420-191">セットアップの実行可能ファイルのあるアプリをパッケージ化する</span><span class="sxs-lookup"><span data-stu-id="ed420-191">Package an app that has a setup executable file</span></span>

<span data-ttu-id="ed420-192">``Installer`` パラメーターを使って、セットアップの実行可能ファイルを指定します。</span><span class="sxs-lookup"><span data-stu-id="ed420-192">Point to the setup executable by using the ``Installer`` parameter.</span></span>

```cmd
DesktopAppConverter.exe -Installer C:\Installer\MyAppSetup.exe -InstallerArguments "/S" -Destination C:\Output\MyApp -PackageName "MyApp" -Publisher "CN=MyPublisher" -Version 0.0.0.1
```
>[!IMPORTANT]
><span data-ttu-id="ed420-193">デベロッパー センターが数値で始まる ID をパッケージに割り当てる場合、必ず <i>-AppId</i> パラメーターも渡し、そのパラメーターの値として文字列サフィックスのみを使ってください (ピリオドの区切り記号の後)。</span><span class="sxs-lookup"><span data-stu-id="ed420-193">If the dev center assigns an identity to your package that begins with a number, make sure that you also pass in the <i>-AppId</i> parameter, and use only the string suffix (after the period separator) as the value of that parameter.</span></span>

<span data-ttu-id="ed420-194">``InstallerArguments`` パラメーターは省略可能なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="ed420-194">The ``InstallerArguments`` parameter is an optional parameter.</span></span> <span data-ttu-id="ed420-195">ただし、Desktop App Converter では、インストーラーを無人モードで実行する必要があるため、アプリをサイレント モードで実行するためにサイレント フラグを必要とする場合は、このパラメーターの使用が必要になることがあります。</span><span class="sxs-lookup"><span data-stu-id="ed420-195">However, because the Desktop App Converter needs your installer to run in unattended mode, you might have to use it if your app needs silent flags to run silently.</span></span> <span data-ttu-id="ed420-196">``/S`` フラグは非常に一般的なサイレント フラグですが、セットアップ ファイルを作成するために使用したインストーラー テクノロジによっては、使用するフラグが異なる場合もあります。</span><span class="sxs-lookup"><span data-stu-id="ed420-196">The ``/S`` flag is a very common silent flag, but the flag that you use might be different depending on which installer technology you used to create the setup file.</span></span>

**<span data-ttu-id="ed420-197">ビデオ</span><span class="sxs-lookup"><span data-stu-id="ed420-197">Video</span></span>**

<iframe src="https://mva.microsoft.com/en-US/training-courses-embed/developers-guide-to-the-desktop-bridge-17373/Demo-Convert-an-Application-That-Has-a-Setup-exe-Installer-amWit2WhD_5306218965" width="636" height="480" allowFullScreen frameBorder="0"></iframe>

<a id="no-installer-conversion" />

#### <a name="package-an-app-that-doesnt-have-an-installer"></a><span data-ttu-id="ed420-198">インストーラーのないアプリをパッケージ化する</span><span class="sxs-lookup"><span data-stu-id="ed420-198">Package an app that doesn't have an installer</span></span>

<span data-ttu-id="ed420-199">この例では、``Installer`` パラメーターを使用して、アプリ ファイルのルート フォルダーを指定しています。</span><span class="sxs-lookup"><span data-stu-id="ed420-199">In this example, use the ``Installer`` parameter to point to the root folder of your app files.</span></span>

<span data-ttu-id="ed420-200">アプリの実行可能ファイルを指定するには、`AppExecutable` パラメーターを使用します。</span><span class="sxs-lookup"><span data-stu-id="ed420-200">Use the `AppExecutable` parameter to point to your apps executable file.</span></span>

```cmd
DesktopAppConverter.exe -Installer C:\Installer\MyApp\ -AppExecutable MyApp.exe -Destination C:\Output\MyApp -PackageName "MyApp" -Publisher "CN=MyPublisher" -Version 0.0.0.1
```

>[!IMPORTANT]
><span data-ttu-id="ed420-201">デベロッパー センターが数値で始まる ID をパッケージに割り当てる場合、必ず <i>-AppId</i> パラメーターも渡し、そのパラメーターの値として文字列サフィックスのみを使ってください (ピリオドの区切り記号の後)。</span><span class="sxs-lookup"><span data-stu-id="ed420-201">If the dev center assigns an identity to your package that begins with a number, make sure that you also pass in the <i>-AppId</i> parameter, and use only the string suffix (after the period separator) as the value of that parameter.</span></span>

**<span data-ttu-id="ed420-202">ビデオ</span><span class="sxs-lookup"><span data-stu-id="ed420-202">Video</span></span>**

<iframe src="https://mva.microsoft.com/en-US/training-courses-embed/developers-guide-to-the-desktop-bridge-17373/Demo-Convert-a-No-Installer-Application-agAXF2WhD_3506218965" width="636" height="480" allowFullScreen frameBorder="0"></iframe>

<a id="optional-parameters" />

#### <a name="package-an-app-sign-the-app-and-run-validation-checks-on-the-package"></a><span data-ttu-id="ed420-203">アプリをパッケージ化し、アプリに署名して、パッケージに対して検証チェックを実行する</span><span class="sxs-lookup"><span data-stu-id="ed420-203">Package an app, sign the app, and run validation checks on the package</span></span>

<span data-ttu-id="ed420-204">この例は最初の例に似ていますが、こちらはローカル テスト用にアプリに署名し、デスクトップ ブリッジと Microsoft Store の要件に照らしてアプリを変換する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="ed420-204">This example is similar to first one except it shows how you can sign your app for local testing, and then validate your app against Desktop Bridge and Microsoft Store requirements.</span></span>

```cmd
DesktopAppConverter.exe -Installer C:\Installer\MyAppSetup.exe -InstallerArguments "/S" -Destination C:\Output\MyApp -PackageName "MyApp" -Publisher "CN=MyPublisher" -Version 0.0.0.1 -MakeAppx -Sign -Verbose -Verify
```
>[!IMPORTANT]
><span data-ttu-id="ed420-205">デベロッパー センターが数値で始まる ID をパッケージに割り当てる場合、必ず <i>-AppId</i> パラメーターも渡し、そのパラメーターの値として文字列サフィックスのみを使ってください (ピリオドの区切り記号の後)。</span><span class="sxs-lookup"><span data-stu-id="ed420-205">If the dev center assigns an identity to your package that begins with a number, make sure that you also pass in the <i>-AppId</i> parameter, and use only the string suffix (after the period separator) as the value of that parameter.</span></span>

<span data-ttu-id="ed420-206">``Sign`` パラメーターは、証明書を生成し、その証明書でアプリに署名します。</span><span class="sxs-lookup"><span data-stu-id="ed420-206">The ``Sign`` parameter generates a certificate and then signs your app with it.</span></span> <span data-ttu-id="ed420-207">アプリを実行するには、生成された証明書をインストールする必要があります。</span><span class="sxs-lookup"><span data-stu-id="ed420-207">To run your app, you'll have to install that generated certificate.</span></span> <span data-ttu-id="ed420-208">その方法については、このガイドの「[パッケージ アプリを実行する](#run-app)」セクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ed420-208">To learn how, see the [Run the packaged app](#run-app) section of this guide.</span></span>

<span data-ttu-id="ed420-209">アプリを検証するには、``Verify`` パラメーターを使います。</span><span class="sxs-lookup"><span data-stu-id="ed420-209">You can validate you app by using the ``Verify`` parameter.</span></span>

### <a name="a-quick-look-at-optional-parameters"></a><span data-ttu-id="ed420-210">省略可能なパラメーターの確認</span><span class="sxs-lookup"><span data-stu-id="ed420-210">A quick look at optional parameters</span></span>

<span data-ttu-id="ed420-211">``Sign`` パラメーターと ``Verify`` パラメーターは省略可能です。</span><span class="sxs-lookup"><span data-stu-id="ed420-211">The ``Sign`` and ``Verify`` parameters are optional.</span></span> <span data-ttu-id="ed420-212">他にも多数の省略可能なパラメーターがあります。</span><span class="sxs-lookup"><span data-stu-id="ed420-212">There are many more optional parameters.</span></span>  <span data-ttu-id="ed420-213">よく使用される省略可能なパラメーターを以下に示します。</span><span class="sxs-lookup"><span data-stu-id="ed420-213">Here are some of the more commonly used optional parameters.</span></span>

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
<span data-ttu-id="ed420-214">これらについて詳しくは、次のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ed420-214">You can read about all of them in the next section.</span></span>

<a id="command-reference" />

### <a name="parameter-reference"></a><span data-ttu-id="ed420-215">パラメーター リファレンス</span><span class="sxs-lookup"><span data-stu-id="ed420-215">Parameter Reference</span></span>

<span data-ttu-id="ed420-216">ここでは、Desktop App Converter を実行するときに使用できるパラメーターの完全な一覧をカテゴリ別に示します。</span><span class="sxs-lookup"><span data-stu-id="ed420-216">Here's the complete list of parameters (organized by category) that you can use when you run the Desktop App Converter.</span></span>

* [<span data-ttu-id="ed420-217">セットアップ</span><span class="sxs-lookup"><span data-stu-id="ed420-217">Setup</span></span>](#setup-params)
* [<span data-ttu-id="ed420-218">変換</span><span class="sxs-lookup"><span data-stu-id="ed420-218">Conversion</span></span>](#conversion-params)
* [<span data-ttu-id="ed420-219">パッケージ ID</span><span class="sxs-lookup"><span data-stu-id="ed420-219">Package identity</span></span>](#identity-params)
* [<span data-ttu-id="ed420-220">パッケージ マニフェスト</span><span class="sxs-lookup"><span data-stu-id="ed420-220">Package manifest</span></span>](#manifest-params)
* [<span data-ttu-id="ed420-221">クリーンアップ</span><span class="sxs-lookup"><span data-stu-id="ed420-221">Cleanup</span></span>](#cleanup-params)
* [<span data-ttu-id="ed420-222">アーキテクチャ</span><span class="sxs-lookup"><span data-stu-id="ed420-222">Architecture</span></span>](#architecture-params)
* [<span data-ttu-id="ed420-223">その他</span><span class="sxs-lookup"><span data-stu-id="ed420-223">Miscellaneous</span></span>](#other-params)

<span data-ttu-id="ed420-224">アプリ コンソール ウィンドウで ``Get-Help`` コマンドを実行して完全な一覧を表示することもできます。</span><span class="sxs-lookup"><span data-stu-id="ed420-224">You can also view the entire list by running the ``Get-Help`` command in the app console window.</span></span>   

||||
|-------------|-----------|-------------|
|<a id="setup-params" /> <strong><span data-ttu-id="ed420-225">セットアップ パラメーター</span><span class="sxs-lookup"><span data-stu-id="ed420-225">Setup parameters</span></span></strong>  ||
|<span data-ttu-id="ed420-226">-Setup [&lt;SwitchParameter&gt;]</span><span class="sxs-lookup"><span data-stu-id="ed420-226">-Setup [&lt;SwitchParameter&gt;]</span></span> |<span data-ttu-id="ed420-227">必須</span><span class="sxs-lookup"><span data-stu-id="ed420-227">Required</span></span> |<span data-ttu-id="ed420-228">セットアップ モードで DesktopAppConverter を実行します。</span><span class="sxs-lookup"><span data-stu-id="ed420-228">Runs DesktopAppConverter in setup mode.</span></span> <span data-ttu-id="ed420-229">セットアップ モードでは、用意されている基本イメージの展開をサポートします。</span><span class="sxs-lookup"><span data-stu-id="ed420-229">Setup mode supports expanding a provided base image.</span></span>|
|<span data-ttu-id="ed420-230">-BaseImage &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="ed420-230">-BaseImage &lt;String&gt;</span></span> | <span data-ttu-id="ed420-231">必須</span><span class="sxs-lookup"><span data-stu-id="ed420-231">Required</span></span> |<span data-ttu-id="ed420-232">展開されていない基本イメージの完全パス。</span><span class="sxs-lookup"><span data-stu-id="ed420-232">Full path to an unexpanded base image.</span></span> <span data-ttu-id="ed420-233">このパラメーターは、-Setup を指定する場合に必要です。</span><span class="sxs-lookup"><span data-stu-id="ed420-233">This parameter is required if -Setup is specified.</span></span>|
| <span data-ttu-id="ed420-234">-LogFile &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="ed420-234">-LogFile &lt;String&gt;</span></span> |<span data-ttu-id="ed420-235">省略可能</span><span class="sxs-lookup"><span data-stu-id="ed420-235">Optional</span></span> |<span data-ttu-id="ed420-236">ログ ファイルを指定します。</span><span class="sxs-lookup"><span data-stu-id="ed420-236">Specifies a log file.</span></span> <span data-ttu-id="ed420-237">省略した場合は、ログ ファイルの一時的な場所が作成されます。</span><span class="sxs-lookup"><span data-stu-id="ed420-237">If omitted, a log file temporary location will be created.</span></span>|
|<span data-ttu-id="ed420-238">-NatSubnetPrefix &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="ed420-238">-NatSubnetPrefix &lt;String&gt;</span></span> |<span data-ttu-id="ed420-239">省略可能</span><span class="sxs-lookup"><span data-stu-id="ed420-239">Optional</span></span> |<span data-ttu-id="ed420-240">Nat インスタンスで使うプレフィックス値。</span><span class="sxs-lookup"><span data-stu-id="ed420-240">Prefix value to be used for the Nat instance.</span></span> <span data-ttu-id="ed420-241">通常この値は、ホスト コンピューターがコンバーターの NetNat と同じサブネット範囲に割り当てられている場合にのみ変更します。</span><span class="sxs-lookup"><span data-stu-id="ed420-241">Typically, you would want to change this only if your host machine is attached to the same subnet range as the converter's NetNat.</span></span> <span data-ttu-id="ed420-242">現在のコンバーターの NetNat 構成は **Get NetNat** コマンドレットを使って照会できます。</span><span class="sxs-lookup"><span data-stu-id="ed420-242">You can query the current converter NetNat config by using the **Get-NetNat** cmdlet.</span></span> |
|<span data-ttu-id="ed420-243">-NoRestart [&lt;SwitchParameter&gt;]</span><span class="sxs-lookup"><span data-stu-id="ed420-243">-NoRestart [&lt;SwitchParameter&gt;]</span></span> |<span data-ttu-id="ed420-244">必須</span><span class="sxs-lookup"><span data-stu-id="ed420-244">Required</span></span> |<span data-ttu-id="ed420-245">セットアップの実行中に再起動を要求しません (コンテナー機能を有効にするには再起動が必要です)。</span><span class="sxs-lookup"><span data-stu-id="ed420-245">Don't prompt for reboot when running setup (reboot is required to enable the container feature).</span></span> |
|<a id="conversion-params" /> <strong><span data-ttu-id="ed420-246">変換パラメーター</span><span class="sxs-lookup"><span data-stu-id="ed420-246">Conversion parameters</span></span></strong>|||
|<span data-ttu-id="ed420-247">-AppInstallPath &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="ed420-247">-AppInstallPath &lt;String&gt;</span></span>  |<span data-ttu-id="ed420-248">省略可能</span><span class="sxs-lookup"><span data-stu-id="ed420-248">Optional</span></span> |<span data-ttu-id="ed420-249">インストール済みのファイルに対応する、アプリケーションのルート フォルダーの完全パス (インストールされている場合)。"C:\Program Files (x86)\MyApp" など。</span><span class="sxs-lookup"><span data-stu-id="ed420-249">The full path to your application's root folder for the installed files if it were installed (e.g., "C:\Program Files (x86)\MyApp").</span></span>|
|<span data-ttu-id="ed420-250">-Destination &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="ed420-250">-Destination &lt;String&gt;</span></span> |<span data-ttu-id="ed420-251">必須</span><span class="sxs-lookup"><span data-stu-id="ed420-251">Required</span></span> |<span data-ttu-id="ed420-252">コンバーターの appx を出力する場所。この場所がまだ存在しない場合は、DesktopAppConverter によって作成されます。</span><span class="sxs-lookup"><span data-stu-id="ed420-252">The desired destination for the converter's appx output - DesktopAppConverter can create this location if it doesn't already exist.</span></span>|
|<span data-ttu-id="ed420-253">-Installer &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="ed420-253">-Installer &lt;String&gt;</span></span> |<span data-ttu-id="ed420-254">必須</span><span class="sxs-lookup"><span data-stu-id="ed420-254">Required</span></span> |<span data-ttu-id="ed420-255">アプリケーションのインストーラーのパス。無人/サイレント モードで実行できるようにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="ed420-255">The path to the installer for your application - must be able to run unattended/silently.</span></span> <span data-ttu-id="ed420-256">インストーラーを使用しない変換では、アプリ ファイルのルート ディレクトリへのパス。</span><span class="sxs-lookup"><span data-stu-id="ed420-256">No-installer conversion, this is the path to the root directory of your app files.</span></span> |
|<span data-ttu-id="ed420-257">-InstallerArguments &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="ed420-257">-InstallerArguments &lt;String&gt;</span></span> |<span data-ttu-id="ed420-258">省略可能</span><span class="sxs-lookup"><span data-stu-id="ed420-258">Optional</span></span> |<span data-ttu-id="ed420-259">インストーラーに無人/サイレント モードでの実行を強制する引数の文字列、またはコンマ区切り一覧。</span><span class="sxs-lookup"><span data-stu-id="ed420-259">A comma-separated list or string of arguments to force your installer to run unattended/silently.</span></span> <span data-ttu-id="ed420-260">インストーラーが msi の場合は、このパラメーターは省略可能です。</span><span class="sxs-lookup"><span data-stu-id="ed420-260">This parameter is optional if your installer is an msi.</span></span> <span data-ttu-id="ed420-261">インストーラーからログを取得するには、ここで、インストーラーのログ記録の引数を指定し、パス &lt;log_folder&gt; (コンバーターが適切なパスに置換するトークン) を使います。</span><span class="sxs-lookup"><span data-stu-id="ed420-261">To get a log from your installer, supply the logging argument for the installer here and use the path &lt;log_folder&gt;, which is a token that the converter replaces with the appropriate path.</span></span> <br><br><span data-ttu-id="ed420-262">**注**: 無人/サイレント フラグとログの引数は、インストーラー テクノロジごとに異なります。</span><span class="sxs-lookup"><span data-stu-id="ed420-262">**NOTE**: The unattended/silent flags and log arguments will vary between installer technologies.</span></span> <br><br><span data-ttu-id="ed420-263">このパラメーターの使用例: -InstallerArguments "/silent /log &lt;log_folder&gt;\install.log"。ログ ファイルを生成しない別の例: ```-InstallerArguments "/quiet", "/norestart"```。コンバーターでログをキャプチャし、最終的なログ フォルダーに格納する場合は、文字どおりすべてのログにトークン パス &lt;log_folder&gt; を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ed420-263">An example usage for this parameter: -InstallerArguments "/silent /log &lt;log_folder&gt;\install.log" Another example that doesn't produce a log file may look like: ```-InstallerArguments "/quiet", "/norestart"``` Again, you must literally direct any logs to the token path &lt;log_folder&gt; if you want the converter to capture it and put it in the final log folder.</span></span>|
|<span data-ttu-id="ed420-264">-InstallerValidExitCodes &lt;Int32&gt;</span><span class="sxs-lookup"><span data-stu-id="ed420-264">-InstallerValidExitCodes &lt;Int32&gt;</span></span> |<span data-ttu-id="ed420-265">省略可能</span><span class="sxs-lookup"><span data-stu-id="ed420-265">Optional</span></span> |<span data-ttu-id="ed420-266">インストーラーの正常な実行を示す、コンマで区切った終了コードの一覧 (例: 0, 1234, 5678)。</span><span class="sxs-lookup"><span data-stu-id="ed420-266">A comma-separated list of exit codes that indicate your installer ran successfully (for example: 0, 1234, 5678).</span></span>  <span data-ttu-id="ed420-267">既定では、非 msi は 0、msi は 0, 1641, 3010 です。</span><span class="sxs-lookup"><span data-stu-id="ed420-267">By default this is 0 for non-msi, and 0, 1641, 3010 for msi.</span></span>|
|<a id="identity-params" /><strong><span data-ttu-id="ed420-268">パッケージ ID パラメーター</span><span class="sxs-lookup"><span data-stu-id="ed420-268">Package identity parameters</span></span></strong>||
|<span data-ttu-id="ed420-269">-PackageName &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="ed420-269">-PackageName &lt;String&gt;</span></span> |<span data-ttu-id="ed420-270">必須</span><span class="sxs-lookup"><span data-stu-id="ed420-270">Required</span></span> |<span data-ttu-id="ed420-271">ユニバーサル Windows アプリ パッケージの名前。</span><span class="sxs-lookup"><span data-stu-id="ed420-271">The name of your Universal Windows App package.</span></span> <span data-ttu-id="ed420-272">デベロッパー センターが数値で始まる ID をパッケージに割り当てる場合、必ず <i>-AppId</i> パラメーターも渡し、そのパラメーターの値として文字列サフィックスのみを使ってください (ピリオドの区切り記号の後)。</span><span class="sxs-lookup"><span data-stu-id="ed420-272">If the dev center assigns an identity to your package that begins with a number, make sure that you also pass in the <i>-AppId</i> parameter, and use only the string suffix (after the period separator) as the value of that parameter.</span></span> |
|<span data-ttu-id="ed420-273">-Publisher &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="ed420-273">-Publisher &lt;String&gt;</span></span> |<span data-ttu-id="ed420-274">必須</span><span class="sxs-lookup"><span data-stu-id="ed420-274">Required</span></span> |<span data-ttu-id="ed420-275">ユニバーサル Windows アプリ パッケージの発行元</span><span class="sxs-lookup"><span data-stu-id="ed420-275">The publisher of your Universal Windows App package</span></span> |
|<span data-ttu-id="ed420-276">-Version &lt;Version&gt;</span><span class="sxs-lookup"><span data-stu-id="ed420-276">-Version &lt;Version&gt;</span></span> |<span data-ttu-id="ed420-277">必須</span><span class="sxs-lookup"><span data-stu-id="ed420-277">Required</span></span> |<span data-ttu-id="ed420-278">ユニバーサル Windows アプリ パッケージのバージョン番号</span><span class="sxs-lookup"><span data-stu-id="ed420-278">The version number for your Universal Windows App package</span></span> |
|<a id="manifest-params" /><strong><span data-ttu-id="ed420-279">パッケージ マニフェスト パラメーター</span><span class="sxs-lookup"><span data-stu-id="ed420-279">Package manifest parameters</span></span></strong>||
|<span data-ttu-id="ed420-280">-AppExecutable &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="ed420-280">-AppExecutable &lt;String&gt;</span></span> |<span data-ttu-id="ed420-281">省略可能</span><span class="sxs-lookup"><span data-stu-id="ed420-281">Optional</span></span> |<span data-ttu-id="ed420-282">アプリケーションのメインの実行可能ファイルの名前 (例:"MyApp.exe")。</span><span class="sxs-lookup"><span data-stu-id="ed420-282">The name of your application's main executable (eg "MyApp.exe").</span></span> <span data-ttu-id="ed420-283">インストーラーを使用しない変換では、このパラメーターは必須です。</span><span class="sxs-lookup"><span data-stu-id="ed420-283">This parameter is required for a no-installer conversion.</span></span> |
|<span data-ttu-id="ed420-284">-AppFileTypes &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="ed420-284">-AppFileTypes &lt;String&gt;</span></span>|<span data-ttu-id="ed420-285">省略可能</span><span class="sxs-lookup"><span data-stu-id="ed420-285">Optional</span></span> |<span data-ttu-id="ed420-286">アプリケーションに関連付ける、ファイルの種類のコンマ区切りの一覧。</span><span class="sxs-lookup"><span data-stu-id="ed420-286">A comma-separated list of file types which the application will be associated with.</span></span> <span data-ttu-id="ed420-287">使用例: -AppFileTypes "'.md', '.markdown'"。</span><span class="sxs-lookup"><span data-stu-id="ed420-287">Example usage: -AppFileTypes "'.md', '.markdown'".</span></span>|
|<span data-ttu-id="ed420-288">-AppId &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="ed420-288">-AppId &lt;String&gt;</span></span> |<span data-ttu-id="ed420-289">省略可能</span><span class="sxs-lookup"><span data-stu-id="ed420-289">Optional</span></span> |<span data-ttu-id="ed420-290">Windows アプリ パッケージ マニフェストでアプリケーション ID を設定する値を指定します。</span><span class="sxs-lookup"><span data-stu-id="ed420-290">Specifies a value to set Application Id to in the Windows app package manifest.</span></span> <span data-ttu-id="ed420-291">指定しなかった場合は、*PackageName* で渡した値が設定されます。</span><span class="sxs-lookup"><span data-stu-id="ed420-291">If it is not specified, it will be set to the value passed in for *PackageName*.</span></span> <span data-ttu-id="ed420-292">多くの場合、*PackageName* を使って問題ありません。</span><span class="sxs-lookup"><span data-stu-id="ed420-292">In many cases, using the *PackageName* is fine.</span></span> <span data-ttu-id="ed420-293">ただし、デベロッパー センターが数値で始まる ID をパッケージに割り当てる場合、必ず <i>-AppId</i> パラメーターも渡し、そのパラメーターの値として文字列サフィックスのみを使ってください (ピリオドの区切り記号の後)。</span><span class="sxs-lookup"><span data-stu-id="ed420-293">However, if the dev center assigns an identity to your package that begins with a number, make sure that you also pass in the <i>-AppId</i> parameter, and use only the string suffix (after the period separator) as the value of that parameter.</span></span> |
|<span data-ttu-id="ed420-294">-AppDisplayName &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="ed420-294">-AppDisplayName &lt;String&gt;</span></span>  |<span data-ttu-id="ed420-295">省略可能</span><span class="sxs-lookup"><span data-stu-id="ed420-295">Optional</span></span> |<span data-ttu-id="ed420-296">Windows アプリ パッケージ マニフェストでアプリケーションの表示名を設定する値を指定します。</span><span class="sxs-lookup"><span data-stu-id="ed420-296">Specifies a value to set Application Display Name to in the Windows app package manifest.</span></span> <span data-ttu-id="ed420-297">指定しなかった場合は、*PackageName* で渡した値が設定されます。</span><span class="sxs-lookup"><span data-stu-id="ed420-297">If it is not specified, it will be set to the value passed in for *PackageName*.</span></span> |
|<span data-ttu-id="ed420-298">-AppDescription &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="ed420-298">-AppDescription &lt;String&gt;</span></span> |<span data-ttu-id="ed420-299">省略可能</span><span class="sxs-lookup"><span data-stu-id="ed420-299">Optional</span></span> |<span data-ttu-id="ed420-300">Windows アプリ パッケージ マニフェストでアプリケーションの説明を設定する値を指定します。</span><span class="sxs-lookup"><span data-stu-id="ed420-300">Specifies a value to set Application Description to in the Windows app package manifest.</span></span> <span data-ttu-id="ed420-301">指定しなかった場合は、*PackageName* で渡した値が設定されます。</span><span class="sxs-lookup"><span data-stu-id="ed420-301">If it is not specified, it will be set to the value passed in for *PackageName*.</span></span>|
|<span data-ttu-id="ed420-302">-PackageDisplayName &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="ed420-302">-PackageDisplayName &lt;String&gt;</span></span> |<span data-ttu-id="ed420-303">省略可能</span><span class="sxs-lookup"><span data-stu-id="ed420-303">Optional</span></span> |<span data-ttu-id="ed420-304">Windows アプリ パッケージ マニフェストでパッケージの表示名を設定する値を指定します。</span><span class="sxs-lookup"><span data-stu-id="ed420-304">Specifies a value to set Package Display Name to in the Windows app package manifest.</span></span> <span data-ttu-id="ed420-305">指定しなかった場合は、*PackageName* で渡した値が設定されます。</span><span class="sxs-lookup"><span data-stu-id="ed420-305">If it is not specified, it will be set to the value passed in for *PackageName*.</span></span> |
|<span data-ttu-id="ed420-306">-PackagePublisherDisplayName &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="ed420-306">-PackagePublisherDisplayName &lt;String&gt;</span></span> |<span data-ttu-id="ed420-307">省略可能</span><span class="sxs-lookup"><span data-stu-id="ed420-307">Optional</span></span> |<span data-ttu-id="ed420-308">Windows アプリ パッケージ マニフェストでパッケージ発行元の表示名を設定する値を指定します。</span><span class="sxs-lookup"><span data-stu-id="ed420-308">Specifies a value to set Package Publisher Display Name to in the Windows app package manifest.</span></span> <span data-ttu-id="ed420-309">指定しなかった場合は、*Publisher* で渡した値が設定されます。</span><span class="sxs-lookup"><span data-stu-id="ed420-309">If it is not specified, it will be set to the value passed in for *Publisher*.</span></span> |
|<a id="cleanup-params" /><strong><span data-ttu-id="ed420-310">クリーンアップ パラメーター</span><span class="sxs-lookup"><span data-stu-id="ed420-310">Cleanup parameters</span></span></strong>|||
|<span data-ttu-id="ed420-311">-Cleanup [&lt;Option&gt;]</span><span class="sxs-lookup"><span data-stu-id="ed420-311">-Cleanup [&lt;Option&gt;]</span></span> |<span data-ttu-id="ed420-312">必須</span><span class="sxs-lookup"><span data-stu-id="ed420-312">Required</span></span> |<span data-ttu-id="ed420-313">DesktopAppConverter の成果物のクリーンアップを実行します。</span><span class="sxs-lookup"><span data-stu-id="ed420-313">Runs cleanup for the DesktopAppConverter artifacts.</span></span> <span data-ttu-id="ed420-314">クリーンアップ モードには 3 つの有効なオプションがあります。</span><span class="sxs-lookup"><span data-stu-id="ed420-314">There are 3 valid options for the Cleanup mode.</span></span> |
|<span data-ttu-id="ed420-315">-Cleanup All</span><span class="sxs-lookup"><span data-stu-id="ed420-315">-Cleanup All</span></span> | |<span data-ttu-id="ed420-316">展開済みのすべての基本イメージを削除し、コンバーターのすべての一時ファイルを削除します。コンテナーのネットワークを削除し、Windows のオプション機能、コンテナーを無効にします。</span><span class="sxs-lookup"><span data-stu-id="ed420-316">Deletes all expanded base images, removes any temporary converter files, removes the container network, and disables the optional Windows feature, Containers.</span></span> |
|<span data-ttu-id="ed420-317">-Cleanup WorkDirectory</span><span class="sxs-lookup"><span data-stu-id="ed420-317">-Cleanup WorkDirectory</span></span> |<span data-ttu-id="ed420-318">必須</span><span class="sxs-lookup"><span data-stu-id="ed420-318">Required</span></span> |<span data-ttu-id="ed420-319">コンバーターのすべての一時ファイルを削除します。</span><span class="sxs-lookup"><span data-stu-id="ed420-319">Removes all the temporary converter files.</span></span> |
|<span data-ttu-id="ed420-320">-Cleanup ExpandedImage</span><span class="sxs-lookup"><span data-stu-id="ed420-320">-Cleanup ExpandedImage</span></span> |<span data-ttu-id="ed420-321">必須</span><span class="sxs-lookup"><span data-stu-id="ed420-321">Required</span></span> |<span data-ttu-id="ed420-322">ホスト コンピューターにインストールされているすべての展開済みの基本イメージを削除します。</span><span class="sxs-lookup"><span data-stu-id="ed420-322">Deletes all the expanded base images installed on your host machine.</span></span> |
|<a id="architecture-params" /><strong><span data-ttu-id="ed420-323">パッケージ アーキテクチャ パラメーター</span><span class="sxs-lookup"><span data-stu-id="ed420-323">Package architecture parameters</span></span></strong>|||
|<span data-ttu-id="ed420-324">-PackageArch &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="ed420-324">-PackageArch &lt;String&gt;</span></span> |<span data-ttu-id="ed420-325">必須</span><span class="sxs-lookup"><span data-stu-id="ed420-325">Required</span></span> |<span data-ttu-id="ed420-326">指定したアーキテクチャのパッケージを生成します。</span><span class="sxs-lookup"><span data-stu-id="ed420-326">Generates a package with the specified architecture.</span></span> <span data-ttu-id="ed420-327">有効なオプションは、'x86' または 'x64' です。たとえば、-PackageArch x86 のように指定します。</span><span class="sxs-lookup"><span data-stu-id="ed420-327">Valid options are 'x86' or 'x64'; for example, -PackageArch x86.</span></span> <span data-ttu-id="ed420-328">このパラメーターは省略可能です。</span><span class="sxs-lookup"><span data-stu-id="ed420-328">This parameter is optional.</span></span> <span data-ttu-id="ed420-329">指定されていない場合、DesktopAppConverter はパッケージのアーキテクチャの自動検出を試みます。</span><span class="sxs-lookup"><span data-stu-id="ed420-329">If unspecified, the DesktopAppConverter will try to auto-detect package architecture.</span></span> <span data-ttu-id="ed420-330">自動検出に失敗した場合、既定値は x64 パッケージです。</span><span class="sxs-lookup"><span data-stu-id="ed420-330">If auto-detection fails, it will default to x64 package.</span></span> |
|<a id="other-params" /><strong><span data-ttu-id="ed420-331">その他のパラメーター</span><span class="sxs-lookup"><span data-stu-id="ed420-331">Miscellaneous parameters</span></span></strong>|||
|<span data-ttu-id="ed420-332">-ExpandedBaseImage &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="ed420-332">-ExpandedBaseImage &lt;String&gt;</span></span>  |<span data-ttu-id="ed420-333">省略可能</span><span class="sxs-lookup"><span data-stu-id="ed420-333">Optional</span></span> |<span data-ttu-id="ed420-334">既に展開済みの基本イメージの完全パス。</span><span class="sxs-lookup"><span data-stu-id="ed420-334">Full path to an already expanded base image.</span></span>|
|<span data-ttu-id="ed420-335">-MakeAppx [&lt;SwitchParameter&gt;]</span><span class="sxs-lookup"><span data-stu-id="ed420-335">-MakeAppx [&lt;SwitchParameter&gt;]</span></span>  |<span data-ttu-id="ed420-336">省略可能</span><span class="sxs-lookup"><span data-stu-id="ed420-336">Optional</span></span> |<span data-ttu-id="ed420-337">このスクリプトに出力で MakeAppx を呼び出すように指示するスイッチ (存在する場合)。</span><span class="sxs-lookup"><span data-stu-id="ed420-337">A switch that, when present, tells this script to call MakeAppx on the output.</span></span> |
|<span data-ttu-id="ed420-338">-LogFile &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="ed420-338">-LogFile &lt;String&gt;</span></span>  |<span data-ttu-id="ed420-339">省略可能</span><span class="sxs-lookup"><span data-stu-id="ed420-339">Optional</span></span> |<span data-ttu-id="ed420-340">ログ ファイルを指定します。</span><span class="sxs-lookup"><span data-stu-id="ed420-340">Specifies a log file.</span></span> <span data-ttu-id="ed420-341">省略した場合は、ログ ファイルの一時的な場所が作成されます。</span><span class="sxs-lookup"><span data-stu-id="ed420-341">If omitted, a log file temporary location will be created.</span></span> |
| <span data-ttu-id="ed420-342">-Sign [&lt;SwitchParameter&gt;]</span><span class="sxs-lookup"><span data-stu-id="ed420-342">-Sign [&lt;SwitchParameter&gt;]</span></span> |<span data-ttu-id="ed420-343">省略可能</span><span class="sxs-lookup"><span data-stu-id="ed420-343">Optional</span></span> |<span data-ttu-id="ed420-344">出力する Windows アプリ パッケージに、テスト用に生成された証明書を使用して署名するようにこのスクリプトに指示します。</span><span class="sxs-lookup"><span data-stu-id="ed420-344">Tells this script to sign the output Windows app package by using a generated certificate for testing purposes.</span></span> <span data-ttu-id="ed420-345">このスイッチは、```-MakeAppx``` スイッチと共に指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ed420-345">This switch should be present alongside the switch ```-MakeAppx```.</span></span> |
|<span data-ttu-id="ed420-346">&lt;共通パラメーター&gt;</span><span class="sxs-lookup"><span data-stu-id="ed420-346">&lt;Common parameters&gt;</span></span> |<span data-ttu-id="ed420-347">必須</span><span class="sxs-lookup"><span data-stu-id="ed420-347">Required</span></span> |<span data-ttu-id="ed420-348">このコマンドレットは、共通パラメーター *Verbose*、*Debug*、*ErrorAction*、*ErrorVariable*、*WarningAction*、*WarningVariable*、*OutBuffer*、*PipelineVariable*、*OutVariable* をサポートします。</span><span class="sxs-lookup"><span data-stu-id="ed420-348">This cmdlet supports the common parameters: *Verbose*, *Debug*, *ErrorAction*, *ErrorVariable*, *WarningAction*, *WarningVariable*, *OutBuffer*, *PipelineVariable*, and *OutVariable*.</span></span> <span data-ttu-id="ed420-349">詳しくは、「[about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ed420-349">For more info, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).</span></span> |
| <span data-ttu-id="ed420-350">-Verify [&lt;SwitchParameter&gt;]</span><span class="sxs-lookup"><span data-stu-id="ed420-350">-Verify [&lt;SwitchParameter&gt;]</span></span> |<span data-ttu-id="ed420-351">省略可能</span><span class="sxs-lookup"><span data-stu-id="ed420-351">Optional</span></span> |<span data-ttu-id="ed420-352">指定された場合、デスクトップ ブリッジと Microsoft Store の要件に照らして、アプリ パッケージを検証するように DAC に指示するスイッチ。</span><span class="sxs-lookup"><span data-stu-id="ed420-352">A switch that, when present, tells the DAC to validate the app package against Desktop Bridge and Microsoft Store requirements.</span></span> <span data-ttu-id="ed420-353">結果は、検証レポート "VerifyReport.xml" で、ブラウザーでの視覚化に最適です。</span><span class="sxs-lookup"><span data-stu-id="ed420-353">The result is a validation report "VerifyReport.xml", which is best visualized in a browser.</span></span> <span data-ttu-id="ed420-354">このスイッチは、`-MakeAppx` スイッチと共に指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ed420-354">This switch should be present alongside the switch `-MakeAppx`.</span></span> |
|<span data-ttu-id="ed420-355">-PublishComRegistrations</span><span class="sxs-lookup"><span data-stu-id="ed420-355">-PublishComRegistrations</span></span>| <span data-ttu-id="ed420-356">省略可能</span><span class="sxs-lookup"><span data-stu-id="ed420-356">Optional</span></span>| <span data-ttu-id="ed420-357">インストーラーによって行われたすべての パブリック COM 登録をスキャンし、有効な登録をマニフェストで公開します。</span><span class="sxs-lookup"><span data-stu-id="ed420-357">Scans all public COM registrations made by your installer and publishes the valid ones in your manifest.</span></span> <span data-ttu-id="ed420-358">このフラグは、これらの登録を他のアプリケーションで利用できるようにする場合にのみ使用してください。</span><span class="sxs-lookup"><span data-stu-id="ed420-358">Use this flag only if you want to make these registrations available to other applications.</span></span> <span data-ttu-id="ed420-359">これらの登録を対象アプリケーションでのみ使用する場合、このフラグを使用する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="ed420-359">You don't need to use this flag if these registrations will be used only by your application.</span></span> <br><br><span data-ttu-id="ed420-360">アプリをパッケージ化した後、正常に動作するように COM 登録を行うには、[こちらの記事](https://blogs.windows.com/buildingapps/2017/04/13/com-server-ole-document-support-desktop-bridge/#lDg5gSFxJ2TDlpC6.97)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ed420-360">Review [this article](https://blogs.windows.com/buildingapps/2017/04/13/com-server-ole-document-support-desktop-bridge/#lDg5gSFxJ2TDlpC6.97) to make sure that your COM registrations behave as you expect after you package your app.</span></span>

<a id="run-app" />

## <a name="run-the-packaged-app"></a><span data-ttu-id="ed420-361">パッケージ アプリを実行する</span><span class="sxs-lookup"><span data-stu-id="ed420-361">Run the packaged app</span></span>

<span data-ttu-id="ed420-362">アプリを実行するには、2 種類の方法があります。</span><span class="sxs-lookup"><span data-stu-id="ed420-362">There's two ways to run your app.</span></span>

<span data-ttu-id="ed420-363">1 つ目は、PowerShell コマンド プロンプトを開いて、```Add-AppxPackage –Register AppxManifest.xml``` というコマンドを入力する方法です。</span><span class="sxs-lookup"><span data-stu-id="ed420-363">One way is to open a PowerShell command prompt, and then type this command: ```Add-AppxPackage –Register AppxManifest.xml```.</span></span> <span data-ttu-id="ed420-364">アプリに署名する必要がないため、アプリを最も簡単に実行できるのはこちらの方法です。</span><span class="sxs-lookup"><span data-stu-id="ed420-364">It's probably the easiest way to run your app because you don't have to sign it.</span></span>

<span data-ttu-id="ed420-365">2 つ目は、証明書を使ってアプリに署名する方法です。</span><span class="sxs-lookup"><span data-stu-id="ed420-365">Another way is to sign your app with a certificate.</span></span> <span data-ttu-id="ed420-366">```sign``` パラメーターを使用すると、Desktop App Converter によって証明書が生成され、その証明書でアプリへの署名が行われます。</span><span class="sxs-lookup"><span data-stu-id="ed420-366">If you use the ```sign``` parameter, the Desktop App Converter will generate one for you, and then sign your app with it.</span></span> <span data-ttu-id="ed420-367">その証明書ファイルは **auto-generated.cer** という名前になり、パッケージ アプリのルート フォルダーに配置されます。</span><span class="sxs-lookup"><span data-stu-id="ed420-367">That file is named **auto-generated.cer**, and you can find it in the root folder of your packaged app.</span></span>

<span data-ttu-id="ed420-368">生成された証明書をインストールし、アプリを実行するには、次の手順を実行します。</span><span class="sxs-lookup"><span data-stu-id="ed420-368">Follow these steps to install the generated certificate, and then run your app.</span></span>

1. <span data-ttu-id="ed420-369">**auto-generated.cer** ファイルをダブルクリックして証明書をインストールします。</span><span class="sxs-lookup"><span data-stu-id="ed420-369">Double-click the **auto-generated.cer** file to install the certificate.</span></span>

   ![生成された証明書ファイル](images/desktop-to-uwp/generated-cert-file.png)

   > [!NOTE]
   > <span data-ttu-id="ed420-371">パスワードを求められた場合は、既定のパスワード "123456" を使用します。</span><span class="sxs-lookup"><span data-stu-id="ed420-371">If you're prompted for a password, use the default password "123456".</span></span>

2. <span data-ttu-id="ed420-372">**[証明書]** ダイアログ ボックスで、**[証明書のインストール]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="ed420-372">In the **Certificate** dialog box, choose the **Install Certificate** button.</span></span>
3. <span data-ttu-id="ed420-373">**証明書インポート ウィザード**で、証明書を**ローカル コンピューター**にインストールし、証明書を "**信頼されたユーザー**" の証明書ストアに配置します。</span><span class="sxs-lookup"><span data-stu-id="ed420-373">In the **Certificate Import Wizard**, install the certificate onto the **Local Machine**, and place the certificate into the **Trusted People** certificate store.</span></span>

   ![信頼されたユーザー ストア](images/desktop-to-uwp/trusted-people-store.png)

5. <span data-ttu-id="ed420-375">パッケージ アプリのルート フォルダーで、Windows アプリのパッケージ ファイルをダブルクリックします。</span><span class="sxs-lookup"><span data-stu-id="ed420-375">In root folder of your packaged app, double click the Windows app package file.</span></span>

   ![Windows アプリのパッケージ ファイル](images/desktop-to-uwp/windows-app-package.png)

6. <span data-ttu-id="ed420-377">**[インストール]** を選択してアプリをインストールします。</span><span class="sxs-lookup"><span data-stu-id="ed420-377">Install the app, by choosing the **Install** button.</span></span>

   ![[インストール] ボタン](images/desktop-to-uwp/install.png)


## <a name="modify-the-packaged-app"></a><span data-ttu-id="ed420-379">パッケージ アプリを変更する</span><span class="sxs-lookup"><span data-stu-id="ed420-379">Modify the packaged app</span></span>

<span data-ttu-id="ed420-380">パッケージ アプリには、バグの修正、ビジュアル資産の追加、モダン エクスペリエンス (ライブ タイルなど) によるアプリの拡張などのために変更が必要になる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="ed420-380">You'll likely make changes to your packaged app to address bugs, add visual assets, or enhance your app with modern experiences such as live tiles.</span></span>

<span data-ttu-id="ed420-381">変更を加えた後、もう一度コンバーターを実行する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="ed420-381">After you make your changes, you don't need to run the converter again.</span></span> <span data-ttu-id="ed420-382">ほとんどの場合、MakeAppx ツールと、DAC によってアプリ用に生成される appxmanifest.xml ファイルを使ってアプリを再パッケージ化することができます。</span><span class="sxs-lookup"><span data-stu-id="ed420-382">In most cases, you can just repackage your app by using the MakeAppx tool and the appxmanifest.xml file the DAC generates for your app.</span></span> <span data-ttu-id="ed420-383">「[Windows アプリ パッケージを生成する](desktop-to-uwp-manual-conversion.md#make-appx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ed420-383">See [Generate a Windows app package](desktop-to-uwp-manual-conversion.md#make-appx).</span></span>

* <span data-ttu-id="ed420-384">アプリのビジュアル アセットを変更する場合、新しいパッケージ リソース インデックス ファイルを生成し、MakeAppx ツールを実行して新しいパッケージを生成します。</span><span class="sxs-lookup"><span data-stu-id="ed420-384">If you modify any of the visual assets of your app, generate a new Package Resource Index file, and then run the MakeAppx tool to generate a new package.</span></span> <span data-ttu-id="ed420-385">「[パッケージ リソース インデックス (PRI) ファイルを生成する](desktop-to-uwp-manual-conversion.md#make-pri)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ed420-385">See [Generate a Package Resource Index (PRI) file](desktop-to-uwp-manual-conversion.md#make-pri).</span></span>

* <span data-ttu-id="ed420-386">Windows タスク バー、タスク ビュー、スナップ アシスト、Alt + Tab キーを押したときの一覧、およびスタート画面のタイルの右下に表示されるアイコンおよびタイルを追加する場合は、「[(省略可能) ターゲット ベースのプレートなしのアセットを追加する](desktop-to-uwp-manual-conversion.md#target-based-assets)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ed420-386">If you want to add icons or tiles that appear on the Windows taskbar, task view, LT+TAB, snap assist, and the lower right corner of Start tiles, see [(Optional Add Target-based unplated assets](desktop-to-uwp-manual-conversion.md#target-based-assets).</span></span>

> [!NOTE]
> <span data-ttu-id="ed420-387">インストーラーによるレジストリ設定を変更した場合は、その変更を適用するために、Desktop App Converter をもう一度実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ed420-387">If you make changes to registry settings that your installer makes, you will have to run the Desktop App Converter again to pick up those changes.</span></span>

**<span data-ttu-id="ed420-388">ビデオ</span><span class="sxs-lookup"><span data-stu-id="ed420-388">Videos</span></span>**

|<span data-ttu-id="ed420-389">出力の変更と再パッケージ化</span><span class="sxs-lookup"><span data-stu-id="ed420-389">Modify and repackage output</span></span> |<span data-ttu-id="ed420-390">デモ: 出力の変更と再パッケージ化</span><span class="sxs-lookup"><span data-stu-id="ed420-390">Demo: Modify and repackage output</span></span>|
|---|---|
|<iframe src="https://mva.microsoft.com/en-US/training-courses-embed/developers-guide-to-the-desktop-bridge-17373/Video-Modifying-and-Repackaging-Output-from-Desktop-App-Converter-OwpAJ3WhD_6706218965" width="426" height="472" allowFullScreen frameBorder="0"></iframe>|<iframe src="https://mva.microsoft.com/en-US/training-courses-embed/developers-guide-to-the-desktop-bridge-17373/Demo-Modify-Output-from-Desktop-App-Converter-gEnsa3WhD_8606218965" width="426" height="472" allowFullScreen frameBorder="0"></iframe>|

<span data-ttu-id="ed420-391">次の 2 つのセクションでは、パッケージ アプリについて検討可能な調整オプションについて説明します。</span><span class="sxs-lookup"><span data-stu-id="ed420-391">The following two sections describe a couple of optional fix-ups to the packaged app that you might consider.</span></span>

### <a name="delete-unnecessary-files-and-registry-keys"></a><span data-ttu-id="ed420-392">不要なファイルとレジストリ キーを削除する</span><span class="sxs-lookup"><span data-stu-id="ed420-392">Delete unnecessary files and registry keys</span></span>

<span data-ttu-id="ed420-393">Desktop App Converter では、コンテナー内のファイルとシステム ノイズの除去に、非常に保守的なアプローチを取っています。</span><span class="sxs-lookup"><span data-stu-id="ed420-393">The desktop App Converter takes a very conservative approach to filtering out files and system noise in the container.</span></span>

<span data-ttu-id="ed420-394">VFS フォルダーを確認し、インストーラーに必要ないファイルがあれば、削除することもできます。</span><span class="sxs-lookup"><span data-stu-id="ed420-394">If you want, you can review the VFS folder and delete any files that your installer doesn't need.</span></span>  <span data-ttu-id="ed420-395">また、Reg.dat の内容を確認し、アプリによってインストールされないキーや不要なキーがあれば、削除できます。</span><span class="sxs-lookup"><span data-stu-id="ed420-395">You can also review the contents of Reg.dat and delete any keys that are not installed/needed by the app.</span></span>

### <a name="fix-corrupted-pe-headers"></a><span data-ttu-id="ed420-396">破損した PEヘッダーを修正する</span><span class="sxs-lookup"><span data-stu-id="ed420-396">Fix corrupted PE headers</span></span>

<span data-ttu-id="ed420-397">DesktopAppConverter は 変換処理中に PEHeaderCertFixTool を自動的に実行し、破損している PEヘッダーを修正します。</span><span class="sxs-lookup"><span data-stu-id="ed420-397">During the conversion process, the DesktopAppConverter automatically runs the PEHeaderCertFixTool to fixup any corrupted PE headers.</span></span> <span data-ttu-id="ed420-398">ただし、UWP の Windows アプリ パッケージ、ルーズ ファイル、または特定のバイナリで、PEHeaderCertFixTool を実行することも可能です。</span><span class="sxs-lookup"><span data-stu-id="ed420-398">However, you can also run the PEHeaderCertFixTool on a UWP Windows app package, loose files, or a specific binary.</span></span> <span data-ttu-id="ed420-399">次に例を示します。</span><span class="sxs-lookup"><span data-stu-id="ed420-399">Here's an example.</span></span>

```CMD
PEHeaderCertFixTool.exe <binary file>|<.appx package>|&lt;folder> [/c] [/v]
 /c   -- check for corrupted certificate but do not fix (optional)
 /v   -- verbose (optional)
example1: PEHeaderCertFixTool app.exe
example2: PEHeaderCertFixTool c:\package.appx /c
example3: PEHeaderCertFixTool c:\myapp /c /v
```

## <a name="telemetry-from-desktop-app-converter"></a><span data-ttu-id="ed420-400">Desktop App Converter の利用統計情報</span><span class="sxs-lookup"><span data-stu-id="ed420-400">Telemetry from Desktop App Converter</span></span>

<span data-ttu-id="ed420-401">Desktop App Converter は、ソフトウェアの使用者と使用方法に関する情報を収集して、この情報を Microsoft に送信することがあります。</span><span class="sxs-lookup"><span data-stu-id="ed420-401">Desktop App Converter may collect information about you and your use of the software and send this info to Microsoft.</span></span> <span data-ttu-id="ed420-402">Microsoft のデータ収集と製品ドキュメントでの使用の詳細については、「[マイクロソフトのプライバシーに関する声明](http://go.microsoft.com/fwlink/?LinkId=521839)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ed420-402">You can learn more about Microsoft's data collection and use in the product documentation and in the [Microsoft Privacy Statement](http://go.microsoft.com/fwlink/?LinkId=521839).</span></span> <span data-ttu-id="ed420-403">マイクロソフトのプライバシーに関する声明の該当するすべての条項に準拠することに同意します。</span><span class="sxs-lookup"><span data-stu-id="ed420-403">You agree to comply with all applicable provisions of the Microsoft Privacy Statement.</span></span>

<span data-ttu-id="ed420-404">既定では、Desktop App Converter の利用統計情報は有効にされています。</span><span class="sxs-lookup"><span data-stu-id="ed420-404">By default, telemetry will be enabled for the Desktop App Converter.</span></span> <span data-ttu-id="ed420-405">利用統計情報を目的の設定に構成するには、次のレジストリ キーを追加します。</span><span class="sxs-lookup"><span data-stu-id="ed420-405">Add the following registry key to configure telemetry to a desired setting:</span></span>  

```cmd
HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\DesktopAppConverter
```
+ <span data-ttu-id="ed420-406">DWORD を 1 に設定して、*DisableTelemetry* 値を追加または編集します。</span><span class="sxs-lookup"><span data-stu-id="ed420-406">Add or edit the *DisableTelemetry* value by using a DWORD set to 1.</span></span>
+ <span data-ttu-id="ed420-407">利用統計情報を有効にするには、このキーを削除するかキーの値を 0 に設定します。</span><span class="sxs-lookup"><span data-stu-id="ed420-407">To enable telemetry, remove the key or set the value to 0.</span></span>

### <a name="language-support"></a><span data-ttu-id="ed420-408">言語サポート</span><span class="sxs-lookup"><span data-stu-id="ed420-408">Language support</span></span>

<span data-ttu-id="ed420-409">Desktop App Converterは、Unicode をサポートしていません。したがって、漢字または非 ASCII 文字をツールで使用することはできません。</span><span class="sxs-lookup"><span data-stu-id="ed420-409">The Desktop App Converter does not support Unicode; thus, no Chinese characters or non-ASCII characters can be used with the tool.</span></span>

## <a name="next-steps"></a><span data-ttu-id="ed420-410">次のステップ</span><span class="sxs-lookup"><span data-stu-id="ed420-410">Next steps</span></span>

**<span data-ttu-id="ed420-411">質問に対する回答を見つける</span><span class="sxs-lookup"><span data-stu-id="ed420-411">Find answers to your questions</span></span>**

<span data-ttu-id="ed420-412">ご質問がある場合は、</span><span class="sxs-lookup"><span data-stu-id="ed420-412">Have questions?</span></span> <span data-ttu-id="ed420-413">Stack Overflow でお問い合わせください。</span><span class="sxs-lookup"><span data-stu-id="ed420-413">Ask us on Stack Overflow.</span></span> <span data-ttu-id="ed420-414">Microsoft のチームでは、これらの[タグ](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge)をチェックしています。</span><span class="sxs-lookup"><span data-stu-id="ed420-414">Our team monitors these [tags](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge).</span></span> <span data-ttu-id="ed420-415">[こちら](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D)から質問することもできます。</span><span class="sxs-lookup"><span data-stu-id="ed420-415">You can also ask us [here](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D).</span></span>

<span data-ttu-id="ed420-416">[ここ](desktop-to-uwp-known-issues.md#app-converter)で既知の問題の一覧を確認することもできます。</span><span class="sxs-lookup"><span data-stu-id="ed420-416">You can also refer to [this](desktop-to-uwp-known-issues.md#app-converter) list of known issues.</span></span>

**<span data-ttu-id="ed420-417">フィードバックの提供または機能の提案を行う</span><span class="sxs-lookup"><span data-stu-id="ed420-417">Give feedback or make feature suggestions</span></span>**

<span data-ttu-id="ed420-418">[UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial) のページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ed420-418">See [UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial).</span></span>

**<span data-ttu-id="ed420-419">アプリを実行する/問題を検出して修正する</span><span class="sxs-lookup"><span data-stu-id="ed420-419">Run your app / find and fix issues</span></span>**

<span data-ttu-id="ed420-420">[パッケージ デスクトップ アプリの実行、デバッグ、テスト (デスクトップ ブリッジ)](desktop-to-uwp-debug.md) をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ed420-420">See [Run, debug, and test a packaged desktop app (Desktop Bridge)](desktop-to-uwp-debug.md)</span></span>

**<span data-ttu-id="ed420-421">アプリを配布する</span><span class="sxs-lookup"><span data-stu-id="ed420-421">Distribute your app</span></span>**

<span data-ttu-id="ed420-422">[パッケージ デスクトップ アプリの配布 (デスクトップ ブリッジ)](desktop-to-uwp-distribute.md) をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ed420-422">See [Distribute a packaged desktop app (Desktop Bridge)](desktop-to-uwp-distribute.md)</span></span>
