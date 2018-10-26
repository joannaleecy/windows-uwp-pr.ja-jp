---
author: normesta
Description: Run the Desktop Converter App to package a Windows desktop application (like Win32, WPF, and Windows Forms).
Search.Product: eADQiWindows 10XVcnh
title: Desktop App Converter を使用してアプリをパッケージ化する (デスクトップ ブリッジ)
ms.author: normesta
ms.date: 08/21/2018
ms.topic: article
keywords: Windows 10, UWP
ms.assetid: 74c84eb6-4714-4e12-a658-09cb92b576e3
ms.localizationpriority: medium
ms.openlocfilehash: 3c05cbf2ce0b2f6288e6beb9c84df9d2b42bd6f2
ms.sourcegitcommit: 6cc275f2151f78db40c11ace381ee2d35f0155f9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5559519"
---
# <a name="package-a-desktop-application-using-the-desktop-app-converter"></a><span data-ttu-id="04f9a-103">Desktop App Converter を使用してデスクトップ アプリケーションをパッケージ化します。</span><span class="sxs-lookup"><span data-stu-id="04f9a-103">Package a desktop application using the Desktop App Converter</span></span>

[<span data-ttu-id="04f9a-104">Desktop App Converter を入手する</span><span class="sxs-lookup"><span data-stu-id="04f9a-104">Get the Desktop App Converter</span></span>](https://aka.ms/converter)

<span data-ttu-id="04f9a-105">Desktop App Converter (DAC) を使用すると、デスクトップ アプリをユニバーサル Windows プラットフォーム (UWP) に移行することができます。</span><span class="sxs-lookup"><span data-stu-id="04f9a-105">You can use the Desktop App Converter (DAC) to bring your desktop apps to the Universal Windows Platform (UWP).</span></span> <span data-ttu-id="04f9a-106">Win32 アプリや .NET 4.6.1 を使用して作成されたアプリも対象になります。</span><span class="sxs-lookup"><span data-stu-id="04f9a-106">This includes Win32 apps and apps that you've created by using .NET 4.6.1.</span></span>

![DAC アイコン](images/desktop-to-uwp/dac.png)

<span data-ttu-id="04f9a-108">このツールの名前には "Converter" という用語が含まれますが、実は、アプリの変換は行いません。</span><span class="sxs-lookup"><span data-stu-id="04f9a-108">While the term "Converter" appears in the name of this tool, it doesn't actually convert your app.</span></span> <span data-ttu-id="04f9a-109">アプリケーションはそのまま残ります。</span><span class="sxs-lookup"><span data-stu-id="04f9a-109">Your application remains unchanged.</span></span> <span data-ttu-id="04f9a-110">しかし、DACは、パッケージ ID を持ち多くの WinRT API を呼び出すことができる Windows アプリ パッケージを生成します。</span><span class="sxs-lookup"><span data-stu-id="04f9a-110">However, this tool generates a Windows app package with a package identity and the ability to call a vast range of WinRT APIs.</span></span>

<span data-ttu-id="04f9a-111">このパッケージは、開発コンピューターで Add-AppxPackage という PowerShell コマンドレットを使ってインストールすることができます。</span><span class="sxs-lookup"><span data-stu-id="04f9a-111">You can install that package by using the Add-AppxPackage PowerShell cmdlet on your development machine.</span></span>

<span data-ttu-id="04f9a-112">このコンバーターは、コンバーターのダウンロードに含まれるクリーンな状態の基本イメージを使って、分離された Windows 環境でデスクトップ インストーラーを実行します。</span><span class="sxs-lookup"><span data-stu-id="04f9a-112">The converter runs the desktop installer in an isolated Windows environment by using a clean base image provided as part of the converter download.</span></span> <span data-ttu-id="04f9a-113">デスクトップ インストーラーが作成するすべてのレジストリとファイル システムの I/O をキャプチャし、出力の一部としてパッケージ化します。</span><span class="sxs-lookup"><span data-stu-id="04f9a-113">It captures any registry and file system I/O made by the desktop installer and packages it as part of the output.</span></span>

>[!IMPORTANT]
><span data-ttu-id="04f9a-114">デスクトップ アプリケーションの Windows アプリ パッケージを作成する機能 (それ以外の場合、デスクトップ ブリッジとも呼ばれるは Windows 10 バージョン 1607 で導入されましたし、Windows 10 Anniversary Update (10.0 をターゲットとするプロジェクトでのみ使用できますビルド 14393) 以降の Visual Studio でリリースされます。</span><span class="sxs-lookup"><span data-stu-id="04f9a-114">The ability to create a Windows app package for your desktop application (Otherwise known as the Desktop Bridge, was introduced in Windows 10, version 1607, and it can only be used in projects that target Windows 10 Anniversary Update (10.0; Build 14393) or a later release in Visual Studio.</span></span>

> [!NOTE]
> <span data-ttu-id="04f9a-115">Microsoft Virtual Academy から公開されている、<a href="https://mva.microsoft.com/en-US/training-courses/developers-guide-to-the-desktop-bridge-17373?l=oZG0B1WhD_8406218965/">このシリーズ</a>の短いビデオをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="04f9a-115">Checkout <a href="https://mva.microsoft.com/en-US/training-courses/developers-guide-to-the-desktop-bridge-17373?l=oZG0B1WhD_8406218965/">this series</a> of short videos published by the Microsoft Virtual Academy.</span></span> <span data-ttu-id="04f9a-116">これらのビデオでは、Desktop App Converter を使用する一般的な方法が紹介されています。</span><span class="sxs-lookup"><span data-stu-id="04f9a-116">These videos walk you through some common ways to use the Desktop App Converter.</span></span>

## <a name="the-dac-does-more-than-just-generate-a-package-for-you"></a><span data-ttu-id="04f9a-117">DAC が行うのはパッケージの生成だけではありません</span><span class="sxs-lookup"><span data-stu-id="04f9a-117">The DAC does more than just generate a package for you</span></span>

<span data-ttu-id="04f9a-118">他にも以下のような処理を実行できます。</span><span class="sxs-lookup"><span data-stu-id="04f9a-118">Here's a few extra things it can do for you.</span></span>

**<span data-ttu-id="04f9a-119">Windows 10 Creators Update</span><span class="sxs-lookup"><span data-stu-id="04f9a-119">Windows 10 Creators Update</span></span>**

<span data-ttu-id="04f9a-120">:heavy_check_mark: プレビュー ハンドラー、サムネイル ハンドラー、プロパティ ハンドラー、ファイアウォール規則、URL フラグを自動的に登録する。</span><span class="sxs-lookup"><span data-stu-id="04f9a-120">:heavy_check_mark: Automatically register your preview handlers, thumbnail handlers, property handlers, firewall rules, URL flags.</span></span>

<span data-ttu-id="04f9a-121">:heavy_check_mark: ファイルの種類のマッピングを自動的に登録する。これによりユーザーは、エクスプローラーの **[種類]** 列を使ってファイルをグループ化できるようになります。</span><span class="sxs-lookup"><span data-stu-id="04f9a-121">:heavy_check_mark: Automatically register file type mappings that enable users to group files by using the **Kind** column in File Explorer.</span></span>

<span data-ttu-id="04f9a-122">:heavy_check_mark: 公開 COM サーバーを登録する。</span><span class="sxs-lookup"><span data-stu-id="04f9a-122">:heavy_check_mark: Register your public COM servers.</span></span>

**<span data-ttu-id="04f9a-123">Windows 10 Anniversary Update 以降</span><span class="sxs-lookup"><span data-stu-id="04f9a-123">Windows 10 Anniversary Update or later</span></span>**

<span data-ttu-id="04f9a-124">:heavy_check_mark: アプリをテストできるように、パッケージに自動的に署名する。</span><span class="sxs-lookup"><span data-stu-id="04f9a-124">:heavy_check_mark: Automatically sign your package so that you can test your app.</span></span>

<span data-ttu-id="04f9a-125">::heavy_check_mark: パッケージ アプリと Microsoft Store 要件に照らしてアプリを検証します。</span><span class="sxs-lookup"><span data-stu-id="04f9a-125">:heavy_check_mark: Validate your application against packaged app and Microsoft Store requirements.</span></span>

<span data-ttu-id="04f9a-126">オプションの完全な一覧については、このガイドの「[パラメーター リファレンス](#command-reference)」セクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="04f9a-126">To find a complete list of options, see the [Parameters](#command-reference) section of this guide.</span></span>

<span data-ttu-id="04f9a-127">パッケージを作成する準備ができたら、始めましょう。</span><span class="sxs-lookup"><span data-stu-id="04f9a-127">If you're ready to create your package, let's start.</span></span>

## <a name="first-prepare-your-application"></a><span data-ttu-id="04f9a-128">まず、アプリケーションを準備します</span><span class="sxs-lookup"><span data-stu-id="04f9a-128">First, prepare your application</span></span>

<span data-ttu-id="04f9a-129">アプリケーションのパッケージの作成を開始する前に、このガイドを確認します。[デスクトップ アプリケーションのパッケージを準備](desktop-to-uwp-prepare.md)します。</span><span class="sxs-lookup"><span data-stu-id="04f9a-129">Review this guide before you begin creating a package for your application: [Prepare to package a desktop application](desktop-to-uwp-prepare.md).</span></span>

## <a name="make-sure-that-your-system-can-run-the-converter"></a><span data-ttu-id="04f9a-130">システムで DCA を実行できることを確認する</span><span class="sxs-lookup"><span data-stu-id="04f9a-130">Make sure that your system can run the converter</span></span>

<span data-ttu-id="04f9a-131">システムが以下の要件を満たしていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="04f9a-131">Make sure that your system meets the following requirements:</span></span>

* <span data-ttu-id="04f9a-132">Windows 10 Anniversary Update (10.0.14393.0 以降) Pro または Enterprise エディション</span><span class="sxs-lookup"><span data-stu-id="04f9a-132">Windows 10 Anniversary Update (10.0.14393.0 and later) Pro or Enterprise edition.</span></span>
* <span data-ttu-id="04f9a-133">64 ビット (x64) プロセッサ</span><span class="sxs-lookup"><span data-stu-id="04f9a-133">64 bit (x64) processor</span></span>
* <span data-ttu-id="04f9a-134">ハードウェア支援による仮想化</span><span class="sxs-lookup"><span data-stu-id="04f9a-134">Hardware-assisted virtualization</span></span>
* <span data-ttu-id="04f9a-135">Second Level Address Translation (SLAT)</span><span class="sxs-lookup"><span data-stu-id="04f9a-135">Second Level Address Translation (SLAT)</span></span>
* <span data-ttu-id="04f9a-136">[Windows 10 用 Windows ソフトウェア開発キット (SDK)](https://go.microsoft.com/fwlink/?linkid=821375)</span><span class="sxs-lookup"><span data-stu-id="04f9a-136">[Windows Software Development Kit (SDK) for Windows 10](https://go.microsoft.com/fwlink/?linkid=821375).</span></span>

## <a name="start-the-desktop-app-converter"></a><span data-ttu-id="04f9a-137">Desktop App Converter を起動する</span><span class="sxs-lookup"><span data-stu-id="04f9a-137">Start the Desktop App Converter</span></span>

1. <span data-ttu-id="04f9a-138">[Desktop App Converter](https://aka.ms/converter)をダウンロードおよびインストールします。</span><span class="sxs-lookup"><span data-stu-id="04f9a-138">Download and install the [Desktop App Converter](https://aka.ms/converter).</span></span>

2. <span data-ttu-id="04f9a-139">管理者として Desktop App Converter を実行します。</span><span class="sxs-lookup"><span data-stu-id="04f9a-139">Run the Desktop App Converter as an administrator.</span></span>

    ![DAC を管理者として実行する](images/desktop-to-uwp/run-converter.png)

   <span data-ttu-id="04f9a-141">コンソール ウィンドウが開きます。</span><span class="sxs-lookup"><span data-stu-id="04f9a-141">A console window appears.</span></span> <span data-ttu-id="04f9a-142">コマンドを実行するには、このコンソール ウィンドウを使います。</span><span class="sxs-lookup"><span data-stu-id="04f9a-142">You'll use that console window to run commands.</span></span>

## <a name="set-a-few-things-up-apps-with-installers-only"></a><span data-ttu-id="04f9a-143">必要な設定を行う (インストーラーがあるアプリのみ) </span><span class="sxs-lookup"><span data-stu-id="04f9a-143">Set a few things up (apps with installers only)</span></span>

<span data-ttu-id="04f9a-144">スキップできます次のセクションにアプリ インストーラーがない場合。</span><span class="sxs-lookup"><span data-stu-id="04f9a-144">You can skip ahead to the next section if your application doesn't have an installer.</span></span>

1. <span data-ttu-id="04f9a-145">オペレーティング システムのバージョン番号を特定します。</span><span class="sxs-lookup"><span data-stu-id="04f9a-145">Identify the version number of your operating system.</span></span>

   <span data-ttu-id="04f9a-146">そのためには、**[ファイル名を指定して実行]** ダイアログ ボックスで「**winver**」と入力し、**[OK]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="04f9a-146">To do that, type **winver** in the **Run** dialog box, and then choose the **OK** button.</span></span>

   ![winver](images/desktop-to-uwp/winver.png)

   <span data-ttu-id="04f9a-148">**[Windows のバージョン情報]** ダイアログ ボックスに Windows ビルドのバージョンが表示されます。</span><span class="sxs-lookup"><span data-stu-id="04f9a-148">You'll find the version of your Windows build in the **About Windows** dialog box.</span></span>

   ![Windows 10 のバージョン](images/desktop-to-uwp/win-10-version.png)

2. <span data-ttu-id="04f9a-150">適切な [Desktop App Converter 基本イメージ](https://aka.ms/converterimages)をダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="04f9a-150">Download the appropriate [Desktop app Converter base image](https://aka.ms/converterimages).</span></span>

   <span data-ttu-id="04f9a-151">ファイル名に含まれるバージョン番号が Windows ビルドのバージョン番号と一致していることを確認してください。</span><span class="sxs-lookup"><span data-stu-id="04f9a-151">Make sure that the version number that appears in the name of the file matches the version number of your Windows build.</span></span>

   >[!IMPORTANT]
   > <span data-ttu-id="04f9a-152">ビルド番号 **15063** を使用しており、そのビルドのマイナー バージョンが **.483** 以上 (例: **15063.540**) である場合は、**BaseImage-15063-UPDATE.wim** ファイルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="04f9a-152">If you're using build number **15063**, and the minor version of that build is equal to or greater than **.483** (For example: **15063.540**), make sure to download the **BaseImage-15063-UPDATE.wim** file.</span></span> <span data-ttu-id="04f9a-153">そのビルドのマイナー バージョンが **.483** 未満である場合は、**BaseImage-15063.wim** ファイルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="04f9a-153">If the minor version of that build is less than **.483**, download the **BaseImage-15063.wim** file.</span></span> <span data-ttu-id="04f9a-154">このベース ファイルの互換性のないバージョンを既にセットアップしている場合は、修正することができます。</span><span class="sxs-lookup"><span data-stu-id="04f9a-154">If you've already setup an incompatible version of this base file, you can fix it.</span></span> <span data-ttu-id="04f9a-155">その方法については、この[ブログの投稿](https://blogs.msdn.microsoft.com/appconsult/2017/08/04/desktop-app-converter-fails-on-windows-10-15063-483-and-later-how-to-solve-it/)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="04f9a-155">This [blog post](https://blogs.msdn.microsoft.com/appconsult/2017/08/04/desktop-app-converter-fails-on-windows-10-15063-483-and-later-how-to-solve-it/) explains how to do that.</span></span>

3. <span data-ttu-id="04f9a-156">ダウンロードしたファイルを後で見つけることができるように、コンピューター上の適切な場所に置きます。</span><span class="sxs-lookup"><span data-stu-id="04f9a-156">Place the downloaded file anywhere on your computer where you'll be able to find it later.</span></span>

4. <span data-ttu-id="04f9a-157">Desktop App Converter を起動したときに表示されるコンソール ウィンドウで、コマンド ```Set-ExecutionPolicy bypass``` を実行します。</span><span class="sxs-lookup"><span data-stu-id="04f9a-157">In the console window that appeared when you started the Desktop App Converter, run this command: ```Set-ExecutionPolicy bypass```.</span></span>
5. <span data-ttu-id="04f9a-158">コマンド ```DesktopAppConverter.exe -Setup -BaseImage .\BaseImage-1XXXX.wim -Verbose``` を実行してコンバーターをセットアップします。</span><span class="sxs-lookup"><span data-stu-id="04f9a-158">Set up the converter by running  this command: ```DesktopAppConverter.exe -Setup -BaseImage .\BaseImage-1XXXX.wim -Verbose```.</span></span>
6. <span data-ttu-id="04f9a-159">画面の指示に従って、コンピューターを再起動します。</span><span class="sxs-lookup"><span data-stu-id="04f9a-159">Restart your computer if you're prompted to do so.</span></span>

   <span data-ttu-id="04f9a-160">コンバーターによって基本イメージが展開されると、コンソール ウィンドウに状態メッセージが表示されます。</span><span class="sxs-lookup"><span data-stu-id="04f9a-160">Status messages appear in the console window as the converter expands the base image.</span></span> <span data-ttu-id="04f9a-161">状態メッセージが表示されない場合は、任意のキーを押します。</span><span class="sxs-lookup"><span data-stu-id="04f9a-161">If you don't see any status messages, press any key.</span></span> <span data-ttu-id="04f9a-162">これにより、コンソール ウィンドウの内容が更新されます。</span><span class="sxs-lookup"><span data-stu-id="04f9a-162">This can cause the contents of the console window to refresh.</span></span>

   ![コンソール ウィンドウに表示された状態メッセージ](images/desktop-to-uwp/bas-image-setup.png)

   <span data-ttu-id="04f9a-164">基本イメージが完全に展開されたら、次のセクションに進みます。</span><span class="sxs-lookup"><span data-stu-id="04f9a-164">When the base image is fully expanded, move to the next section.</span></span>

## <a name="package-an-app"></a><span data-ttu-id="04f9a-165">アプリをパッケージ化する</span><span class="sxs-lookup"><span data-stu-id="04f9a-165">Package an app</span></span>

<span data-ttu-id="04f9a-166">アプリをパッケージ化するには、Desktop App Converter を起動したときに開くコンソール ウィンドウで ``DesktopAppConverter.exe`` コマンドを実行します。</span><span class="sxs-lookup"><span data-stu-id="04f9a-166">To Package your app, run the ``DesktopAppConverter.exe`` command in the console window that opened when you started the Desktop App Converter.</span></span>  

<span data-ttu-id="04f9a-167">パラメーターを使用して、アプリケーションのパッケージ名、発行元、バージョン番号を指定します。</span><span class="sxs-lookup"><span data-stu-id="04f9a-167">You'll specify the package name, publisher and version number of the application by using parameters.</span></span>

> [!NOTE]
> <span data-ttu-id="04f9a-168">Windows ストアでアプリ名を予約済みの場合は、Windows デベロッパー センターのダッシュ ボードを使用して、パッケージと発行元名を取得できます。</span><span class="sxs-lookup"><span data-stu-id="04f9a-168">If you've reserved your app name in the Windows store, you can obtain the package and publisher names by using the Windows Dev Center dashboard.</span></span> <span data-ttu-id="04f9a-169">アプリを他のシステムにサイドローディング展開する場合は、独自の名前を指定できます。ただし、選択する発行元名は、アプリへの署名に使用する証明書の名前と一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="04f9a-169">If you plan to sideload your app onto other systems, you can provide your own names for these as long as the publisher name that you choose matches the name on the certificate you use to sign your app.</span></span>

### <a name="a-quick-look-at-command-parameters"></a><span data-ttu-id="04f9a-170">コマンド パラメーターの確認</span><span class="sxs-lookup"><span data-stu-id="04f9a-170">A quick look at command parameters</span></span>

<span data-ttu-id="04f9a-171">必要なパラメーターは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="04f9a-171">Here are the required parameters.</span></span>

```CMD
DesktopAppConverter.exe
-Installer <String>
-Destination <String>
-PackageName <String>
-Publisher <String>
-Version <Version>
```
<span data-ttu-id="04f9a-172">各パラメーターについて詳しくは、[こちら](#command-reference)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="04f9a-172">You can read about each one [here](#command-reference).</span></span>

### <a name="examples"></a><span data-ttu-id="04f9a-173">例</span><span class="sxs-lookup"><span data-stu-id="04f9a-173">Examples</span></span>

<span data-ttu-id="04f9a-174">アプリをパッケージ化する一般的な方法のいくつかを以下に示します。</span><span class="sxs-lookup"><span data-stu-id="04f9a-174">Here's a few common ways to package your app.</span></span>

* [<span data-ttu-id="04f9a-175">インストーラー (.msi) ファイルを持つアプリケーションをパッケージ化します。</span><span class="sxs-lookup"><span data-stu-id="04f9a-175">Package an application that has an installer (.msi) file</span></span>](#installer-conversion)
* [<span data-ttu-id="04f9a-176">セットアップの実行可能ファイルを持つアプリケーションをパッケージ化します。</span><span class="sxs-lookup"><span data-stu-id="04f9a-176">Package an application that has a setup executable file</span></span>](#setup-conversion)
* [<span data-ttu-id="04f9a-177">インストーラーがないアプリケーションをパッケージ化します。</span><span class="sxs-lookup"><span data-stu-id="04f9a-177">Package an application that doesn't have an installer</span></span>](#no-installer-conversion)
* [<span data-ttu-id="04f9a-178">アプリをパッケージ化し、アプリに署名して、ストアへの提出に備える</span><span class="sxs-lookup"><span data-stu-id="04f9a-178">Package an app, sign the app, and prepare it for store submission</span></span>](#optional-parameters)

<a id="installer-conversion" />

#### <a name="package-an-application-that-has-an-installer-msi-file"></a><span data-ttu-id="04f9a-179">インストーラー (.msi) ファイルを持つアプリケーションをパッケージ化します。</span><span class="sxs-lookup"><span data-stu-id="04f9a-179">Package an application that has an installer (.msi) file</span></span>

<span data-ttu-id="04f9a-180">``Installer`` パラメーターでインストーラー ファイルを指定します。</span><span class="sxs-lookup"><span data-stu-id="04f9a-180">Point to the installer file by using the ``Installer`` parameter.</span></span>

```cmd
DesktopAppConverter.exe -Installer C:\Installer\MyAppSetup.msi -Destination C:\Output\MyApp -PackageName "MyApp" -Publisher "CN=MyPublisher" -Version 0.0.0.1
```

> [!IMPORTANT]
> <span data-ttu-id="04f9a-181">ここで留意すべき重要なことが 2 つあります。</span><span class="sxs-lookup"><span data-stu-id="04f9a-181">There are two important things to keep in mind here.</span></span> <span data-ttu-id="04f9a-182">まず、インストーラーは独立したフォルダーに配置し、そのインストーラーに関連するファイルだけを同じフォルダーに配置してください。</span><span class="sxs-lookup"><span data-stu-id="04f9a-182">First, make sure that your installer is located in an independent folder and that only files related to that installer are in the same folder.</span></span> <span data-ttu-id="04f9a-183">コンバーターは、このフォルダーの内容をすべて、分離された Windows 環境にコピーします。</span><span class="sxs-lookup"><span data-stu-id="04f9a-183">The converter copies all of the contents of that folder to the isolated Windows environment.</span></span> <br> <span data-ttu-id="04f9a-184">2 つ目に、デベロッパー センターが数値で始まる ID をパッケージに割り当てる場合、必ず <i>-AppId</i> パラメーターも渡し、そのパラメーターの値として文字列サフィックスのみを使ってください (ピリオドの区切り記号の後)。</span><span class="sxs-lookup"><span data-stu-id="04f9a-184">Secondly, if the dev center assigns an identity to your package that begins with a number, make sure that you also pass in the <i>-AppId</i> parameter, and use only the string suffix (after the period separator) as the value of that parameter.</span></span>  

**<span data-ttu-id="04f9a-185">ビデオ</span><span class="sxs-lookup"><span data-stu-id="04f9a-185">Video</span></span>**

<iframe src="https://mva.microsoft.com/en-US/training-courses-embed/developers-guide-to-the-desktop-bridge-17373/Demo-Convert-an-Application-That-Has-an-MSI-Installer-Kh1UU2WhD_7106218965" width="636" height="480" allowFullScreen frameBorder="0"></iframe>

<span data-ttu-id="04f9a-186">インストーラーに、従属ライブラリやフレームワークのインストーラーが含まれている場合、少し異なる方法で整理する必要があります。</span><span class="sxs-lookup"><span data-stu-id="04f9a-186">If your installer includes installers for dependent libraries or frameworks, you might have to organize things a bit a differently.</span></span> <span data-ttu-id="04f9a-187">[複数のインストーラーとデスクトップ ブリッジの連結に関する記事](https://blogs.msdn.microsoft.com/appconsult/2017/09/11/chaining-multiple-installers-with-the-desktop-app-converter/)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="04f9a-187">See [Chaining multiple installers with the Desktop Bridge](https://blogs.msdn.microsoft.com/appconsult/2017/09/11/chaining-multiple-installers-with-the-desktop-app-converter/).</span></span>

<a id="setup-conversion" />

#### <a name="package-an-application-that-has-a-setup-executable-file"></a><span data-ttu-id="04f9a-188">セットアップの実行可能ファイルを持つアプリケーションをパッケージ化します。</span><span class="sxs-lookup"><span data-stu-id="04f9a-188">Package an application that has a setup executable file</span></span>

<span data-ttu-id="04f9a-189">``Installer`` パラメーターを使って、セットアップの実行可能ファイルを指定します。</span><span class="sxs-lookup"><span data-stu-id="04f9a-189">Point to the setup executable by using the ``Installer`` parameter.</span></span>

```cmd
DesktopAppConverter.exe -Installer C:\Installer\MyAppSetup.exe -InstallerArguments "/S" -Destination C:\Output\MyApp -PackageName "MyApp" -Publisher "CN=MyPublisher" -Version 0.0.0.1
```
>[!IMPORTANT]
><span data-ttu-id="04f9a-190">デベロッパー センターが数値で始まる ID をパッケージに割り当てる場合、必ず <i>-AppId</i> パラメーターも渡し、そのパラメーターの値として文字列サフィックスのみを使ってください (ピリオドの区切り記号の後)。</span><span class="sxs-lookup"><span data-stu-id="04f9a-190">If the dev center assigns an identity to your package that begins with a number, make sure that you also pass in the <i>-AppId</i> parameter, and use only the string suffix (after the period separator) as the value of that parameter.</span></span>

<span data-ttu-id="04f9a-191">``InstallerArguments`` パラメーターは省略可能なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="04f9a-191">The ``InstallerArguments`` parameter is an optional parameter.</span></span> <span data-ttu-id="04f9a-192">ただし、Desktop App Converter は、インストーラーを無人モードで実行する必要があるため、アプリケーションがサイレント フラグをサイレント モードで実行する必要がある場合に使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="04f9a-192">However, because the Desktop App Converter needs your installer to run in unattended mode, you might have to use it if your application needs silent flags to run silently.</span></span> <span data-ttu-id="04f9a-193">``/S`` フラグは非常に一般的なサイレント フラグですが、セットアップ ファイルを作成するために使用したインストーラー テクノロジによっては、使用するフラグが異なる場合もあります。</span><span class="sxs-lookup"><span data-stu-id="04f9a-193">The ``/S`` flag is a very common silent flag, but the flag that you use might be different depending on which installer technology you used to create the setup file.</span></span>

**<span data-ttu-id="04f9a-194">ビデオ</span><span class="sxs-lookup"><span data-stu-id="04f9a-194">Video</span></span>**

<iframe src="https://mva.microsoft.com/en-US/training-courses-embed/developers-guide-to-the-desktop-bridge-17373/Demo-Convert-an-Application-That-Has-a-Setup-exe-Installer-amWit2WhD_5306218965" width="636" height="480" allowFullScreen frameBorder="0"></iframe>

<a id="no-installer-conversion" />

#### <a name="package-an-application-that-doesnt-have-an-installer"></a><span data-ttu-id="04f9a-195">インストーラーがないアプリケーションをパッケージ化します。</span><span class="sxs-lookup"><span data-stu-id="04f9a-195">Package an application that doesn't have an installer</span></span>

<span data-ttu-id="04f9a-196">この例で使用して、 ``Installer`` 、アプリケーションのファイルのルート フォルダーをポイントするパラメーター。</span><span class="sxs-lookup"><span data-stu-id="04f9a-196">In this example, use the ``Installer`` parameter to point to the root folder of your application files.</span></span>

<span data-ttu-id="04f9a-197">アプリの実行可能ファイルを指定するには、`AppExecutable` パラメーターを使用します。</span><span class="sxs-lookup"><span data-stu-id="04f9a-197">Use the `AppExecutable` parameter to point to your apps executable file.</span></span>

```cmd
DesktopAppConverter.exe -Installer C:\Installer\MyApp\ -AppExecutable MyApp.exe -Destination C:\Output\MyApp -PackageName "MyApp" -Publisher "CN=MyPublisher" -Version 0.0.0.1
```

>[!IMPORTANT]
><span data-ttu-id="04f9a-198">デベロッパー センターが数値で始まる ID をパッケージに割り当てる場合、必ず <i>-AppId</i> パラメーターも渡し、そのパラメーターの値として文字列サフィックスのみを使ってください (ピリオドの区切り記号の後)。</span><span class="sxs-lookup"><span data-stu-id="04f9a-198">If the dev center assigns an identity to your package that begins with a number, make sure that you also pass in the <i>-AppId</i> parameter, and use only the string suffix (after the period separator) as the value of that parameter.</span></span>

**<span data-ttu-id="04f9a-199">ビデオ</span><span class="sxs-lookup"><span data-stu-id="04f9a-199">Video</span></span>**

<iframe src="https://mva.microsoft.com/en-US/training-courses-embed/developers-guide-to-the-desktop-bridge-17373/Demo-Convert-a-No-Installer-Application-agAXF2WhD_3506218965" width="636" height="480" allowFullScreen frameBorder="0"></iframe>

<a id="optional-parameters" />

#### <a name="package-an-app-sign-the-app-and-run-validation-checks-on-the-package"></a><span data-ttu-id="04f9a-200">アプリをパッケージ化し、アプリに署名して、パッケージに対して検証チェックを実行する</span><span class="sxs-lookup"><span data-stu-id="04f9a-200">Package an app, sign the app, and run validation checks on the package</span></span>

<span data-ttu-id="04f9a-201">この例は、点を除いて、アプリケーション ローカル テスト用に署名し、パッケージ アプリと Microsoft Store 要件に照らしてアプリを検証する方法を示していますに 1 つ目に似ています。</span><span class="sxs-lookup"><span data-stu-id="04f9a-201">This example is similar to first one except it shows how you can sign your application for local testing, and then validate your application against packaged app and Microsoft Store requirements.</span></span>

```cmd
DesktopAppConverter.exe -Installer C:\Installer\MyAppSetup.exe -InstallerArguments "/S" -Destination C:\Output\MyApp -PackageName "MyApp" -Publisher "CN=MyPublisher" -Version 0.0.0.1 -MakeAppx -Sign -Verbose -Verify
```
>[!IMPORTANT]
><span data-ttu-id="04f9a-202">デベロッパー センターが数値で始まる ID をパッケージに割り当てる場合、必ず <i>-AppId</i> パラメーターも渡し、そのパラメーターの値として文字列サフィックスのみを使ってください (ピリオドの区切り記号の後)。</span><span class="sxs-lookup"><span data-stu-id="04f9a-202">If the dev center assigns an identity to your package that begins with a number, make sure that you also pass in the <i>-AppId</i> parameter, and use only the string suffix (after the period separator) as the value of that parameter.</span></span>

<span data-ttu-id="04f9a-203">``Sign``パラメーターは、証明書を生成し、それを使用してアプリケーションを署名します。</span><span class="sxs-lookup"><span data-stu-id="04f9a-203">The ``Sign`` parameter generates a certificate and then signs your application with it.</span></span> <span data-ttu-id="04f9a-204">アプリを実行するには、生成された証明書をインストールする必要があります。</span><span class="sxs-lookup"><span data-stu-id="04f9a-204">To run your app, you'll have to install that generated certificate.</span></span> <span data-ttu-id="04f9a-205">その方法については、このガイドの「[パッケージ アプリを実行する](#run-app)」セクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="04f9a-205">To learn how, see the [Run the packaged app](#run-app) section of this guide.</span></span>

<span data-ttu-id="04f9a-206">検証するアプリケーションを使用して、``Verify``パラメーター。</span><span class="sxs-lookup"><span data-stu-id="04f9a-206">You can validate you application by using the ``Verify`` parameter.</span></span>

### <a name="a-quick-look-at-optional-parameters"></a><span data-ttu-id="04f9a-207">省略可能なパラメーターの確認</span><span class="sxs-lookup"><span data-stu-id="04f9a-207">A quick look at optional parameters</span></span>

<span data-ttu-id="04f9a-208">``Sign`` パラメーターと ``Verify`` パラメーターは省略可能です。</span><span class="sxs-lookup"><span data-stu-id="04f9a-208">The ``Sign`` and ``Verify`` parameters are optional.</span></span> <span data-ttu-id="04f9a-209">他にも多数の省略可能なパラメーターがあります。</span><span class="sxs-lookup"><span data-stu-id="04f9a-209">There are many more optional parameters.</span></span>  <span data-ttu-id="04f9a-210">よく使用される省略可能なパラメーターを以下に示します。</span><span class="sxs-lookup"><span data-stu-id="04f9a-210">Here are some of the more commonly used optional parameters.</span></span>

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
<span data-ttu-id="04f9a-211">これらについて詳しくは、次のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="04f9a-211">You can read about all of them in the next section.</span></span>

<a id="command-reference" />

### <a name="parameter-reference"></a><span data-ttu-id="04f9a-212">パラメーター リファレンス</span><span class="sxs-lookup"><span data-stu-id="04f9a-212">Parameter Reference</span></span>

<span data-ttu-id="04f9a-213">ここでは、Desktop App Converter を実行するときに使用できるパラメーターの完全な一覧をカテゴリ別に示します。</span><span class="sxs-lookup"><span data-stu-id="04f9a-213">Here's the complete list of parameters (organized by category) that you can use when you run the Desktop App Converter.</span></span>

* [<span data-ttu-id="04f9a-214">セットアップ</span><span class="sxs-lookup"><span data-stu-id="04f9a-214">Setup</span></span>](#setup-params)
* [<span data-ttu-id="04f9a-215">変換</span><span class="sxs-lookup"><span data-stu-id="04f9a-215">Conversion</span></span>](#conversion-params)
* [<span data-ttu-id="04f9a-216">パッケージ ID</span><span class="sxs-lookup"><span data-stu-id="04f9a-216">Package identity</span></span>](#identity-params)
* [<span data-ttu-id="04f9a-217">パッケージ マニフェスト</span><span class="sxs-lookup"><span data-stu-id="04f9a-217">Package manifest</span></span>](#manifest-params)
* [<span data-ttu-id="04f9a-218">クリーンアップ</span><span class="sxs-lookup"><span data-stu-id="04f9a-218">Cleanup</span></span>](#cleanup-params)
* [<span data-ttu-id="04f9a-219">アーキテクチャ</span><span class="sxs-lookup"><span data-stu-id="04f9a-219">Architecture</span></span>](#architecture-params)
* [<span data-ttu-id="04f9a-220">その他</span><span class="sxs-lookup"><span data-stu-id="04f9a-220">Miscellaneous</span></span>](#other-params)

<span data-ttu-id="04f9a-221">アプリ コンソール ウィンドウで ``Get-Help`` コマンドを実行して完全な一覧を表示することもできます。</span><span class="sxs-lookup"><span data-stu-id="04f9a-221">You can also view the entire list by running the ``Get-Help`` command in the app console window.</span></span>   

||||
|-------------|-----------|-------------|
|<a id="setup-params" /> <strong><span data-ttu-id="04f9a-222">セットアップ パラメーター</span><span class="sxs-lookup"><span data-stu-id="04f9a-222">Setup parameters</span></span></strong>  ||
|<span data-ttu-id="04f9a-223">-Setup [&lt;SwitchParameter&gt;]</span><span class="sxs-lookup"><span data-stu-id="04f9a-223">-Setup [&lt;SwitchParameter&gt;]</span></span> |<span data-ttu-id="04f9a-224">必須</span><span class="sxs-lookup"><span data-stu-id="04f9a-224">Required</span></span> |<span data-ttu-id="04f9a-225">セットアップ モードで DesktopAppConverter を実行します。</span><span class="sxs-lookup"><span data-stu-id="04f9a-225">Runs DesktopAppConverter in setup mode.</span></span> <span data-ttu-id="04f9a-226">セットアップ モードでは、用意されている基本イメージの展開をサポートします。</span><span class="sxs-lookup"><span data-stu-id="04f9a-226">Setup mode supports expanding a provided base image.</span></span>|
|<span data-ttu-id="04f9a-227">-BaseImage &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="04f9a-227">-BaseImage &lt;String&gt;</span></span> | <span data-ttu-id="04f9a-228">必須</span><span class="sxs-lookup"><span data-stu-id="04f9a-228">Required</span></span> |<span data-ttu-id="04f9a-229">展開されていない基本イメージの完全パス。</span><span class="sxs-lookup"><span data-stu-id="04f9a-229">Full path to an unexpanded base image.</span></span> <span data-ttu-id="04f9a-230">このパラメーターは、-Setup を指定する場合に必要です。</span><span class="sxs-lookup"><span data-stu-id="04f9a-230">This parameter is required if -Setup is specified.</span></span>|
| <span data-ttu-id="04f9a-231">-LogFile &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="04f9a-231">-LogFile &lt;String&gt;</span></span> |<span data-ttu-id="04f9a-232">省略可能</span><span class="sxs-lookup"><span data-stu-id="04f9a-232">Optional</span></span> |<span data-ttu-id="04f9a-233">ログ ファイルを指定します。</span><span class="sxs-lookup"><span data-stu-id="04f9a-233">Specifies a log file.</span></span> <span data-ttu-id="04f9a-234">省略した場合は、ログ ファイルの一時的な場所が作成されます。</span><span class="sxs-lookup"><span data-stu-id="04f9a-234">If omitted, a log file temporary location will be created.</span></span>|
|<span data-ttu-id="04f9a-235">-NatSubnetPrefix &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="04f9a-235">-NatSubnetPrefix &lt;String&gt;</span></span> |<span data-ttu-id="04f9a-236">省略可能</span><span class="sxs-lookup"><span data-stu-id="04f9a-236">Optional</span></span> |<span data-ttu-id="04f9a-237">Nat インスタンスで使うプレフィックス値。</span><span class="sxs-lookup"><span data-stu-id="04f9a-237">Prefix value to be used for the Nat instance.</span></span> <span data-ttu-id="04f9a-238">通常この値は、ホスト コンピューターがコンバーターの NetNat と同じサブネット範囲に割り当てられている場合にのみ変更します。</span><span class="sxs-lookup"><span data-stu-id="04f9a-238">Typically, you would want to change this only if your host machine is attached to the same subnet range as the converter's NetNat.</span></span> <span data-ttu-id="04f9a-239">現在のコンバーターの NetNat 構成は **Get NetNat** コマンドレットを使って照会できます。</span><span class="sxs-lookup"><span data-stu-id="04f9a-239">You can query the current converter NetNat config by using the **Get-NetNat** cmdlet.</span></span> |
|<span data-ttu-id="04f9a-240">-NoRestart [&lt;SwitchParameter&gt;]</span><span class="sxs-lookup"><span data-stu-id="04f9a-240">-NoRestart [&lt;SwitchParameter&gt;]</span></span> |<span data-ttu-id="04f9a-241">必須</span><span class="sxs-lookup"><span data-stu-id="04f9a-241">Required</span></span> |<span data-ttu-id="04f9a-242">セットアップの実行中に再起動を要求しません (コンテナー機能を有効にするには再起動が必要です)。</span><span class="sxs-lookup"><span data-stu-id="04f9a-242">Don't prompt for reboot when running setup (reboot is required to enable the container feature).</span></span> |
|<a id="conversion-params" /> <strong><span data-ttu-id="04f9a-243">変換パラメーター</span><span class="sxs-lookup"><span data-stu-id="04f9a-243">Conversion parameters</span></span></strong>|||
|<span data-ttu-id="04f9a-244">-AppInstallPath &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="04f9a-244">-AppInstallPath &lt;String&gt;</span></span>  |<span data-ttu-id="04f9a-245">省略可能</span><span class="sxs-lookup"><span data-stu-id="04f9a-245">Optional</span></span> |<span data-ttu-id="04f9a-246">インストール済みのファイルに対応する、アプリケーションのルート フォルダーの完全パス (インストールされている場合)。"C:\Program Files (x86)\MyApp" など。</span><span class="sxs-lookup"><span data-stu-id="04f9a-246">The full path to your application's root folder for the installed files if it were installed (e.g., "C:\Program Files (x86)\MyApp").</span></span>|
|<span data-ttu-id="04f9a-247">-Destination &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="04f9a-247">-Destination &lt;String&gt;</span></span> |<span data-ttu-id="04f9a-248">必須</span><span class="sxs-lookup"><span data-stu-id="04f9a-248">Required</span></span> |<span data-ttu-id="04f9a-249">コンバーターの appx を出力する場所。この場所がまだ存在しない場合は、DesktopAppConverter によって作成されます。</span><span class="sxs-lookup"><span data-stu-id="04f9a-249">The desired destination for the converter's appx output - DesktopAppConverter can create this location if it doesn't already exist.</span></span>|
|<span data-ttu-id="04f9a-250">-Installer &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="04f9a-250">-Installer &lt;String&gt;</span></span> |<span data-ttu-id="04f9a-251">必須</span><span class="sxs-lookup"><span data-stu-id="04f9a-251">Required</span></span> |<span data-ttu-id="04f9a-252">アプリケーションのインストーラーのパス。無人/サイレント モードで実行できるようにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="04f9a-252">The path to the installer for your application - must be able to run unattended/silently.</span></span> <span data-ttu-id="04f9a-253">インストーラーの変換、これは、アプリケーションのファイルのルート ディレクトリへのパス。</span><span class="sxs-lookup"><span data-stu-id="04f9a-253">No-installer conversion, this is the path to the root directory of your application files.</span></span> |
|<span data-ttu-id="04f9a-254">-InstallerArguments &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="04f9a-254">-InstallerArguments &lt;String&gt;</span></span> |<span data-ttu-id="04f9a-255">省略可能</span><span class="sxs-lookup"><span data-stu-id="04f9a-255">Optional</span></span> |<span data-ttu-id="04f9a-256">インストーラーに無人/サイレント モードでの実行を強制する引数の文字列、またはコンマ区切り一覧。</span><span class="sxs-lookup"><span data-stu-id="04f9a-256">A comma-separated list or string of arguments to force your installer to run unattended/silently.</span></span> <span data-ttu-id="04f9a-257">インストーラーが msi の場合は、このパラメーターは省略可能です。</span><span class="sxs-lookup"><span data-stu-id="04f9a-257">This parameter is optional if your installer is an msi.</span></span> <span data-ttu-id="04f9a-258">インストーラーからログを取得するには、ここで、インストーラーのログ記録の引数を指定し、パス &lt;log_folder&gt; (コンバーターが適切なパスに置換するトークン) を使います。</span><span class="sxs-lookup"><span data-stu-id="04f9a-258">To get a log from your installer, supply the logging argument for the installer here and use the path &lt;log_folder&gt;, which is a token that the converter replaces with the appropriate path.</span></span> <br><br><span data-ttu-id="04f9a-259">**注**: 無人/サイレント フラグとログの引数は、インストーラー テクノロジごとに異なります。</span><span class="sxs-lookup"><span data-stu-id="04f9a-259">**NOTE**: The unattended/silent flags and log arguments will vary between installer technologies.</span></span> <br><br><span data-ttu-id="04f9a-260">このパラメーターの使用例: -InstallerArguments "/silent /log &lt;log_folder&gt;\install.log"。ログ ファイルを生成しない別の例: ```-InstallerArguments "/quiet", "/norestart"```。コンバーターでログをキャプチャし、最終的なログ フォルダーに格納する場合は、文字どおりすべてのログにトークン パス &lt;log_folder&gt; を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="04f9a-260">An example usage for this parameter: -InstallerArguments "/silent /log &lt;log_folder&gt;\install.log" Another example that doesn't produce a log file may look like: ```-InstallerArguments "/quiet", "/norestart"``` Again, you must literally direct any logs to the token path &lt;log_folder&gt; if you want the converter to capture it and put it in the final log folder.</span></span>|
|<span data-ttu-id="04f9a-261">-InstallerValidExitCodes &lt;Int32&gt;</span><span class="sxs-lookup"><span data-stu-id="04f9a-261">-InstallerValidExitCodes &lt;Int32&gt;</span></span> |<span data-ttu-id="04f9a-262">省略可能</span><span class="sxs-lookup"><span data-stu-id="04f9a-262">Optional</span></span> |<span data-ttu-id="04f9a-263">インストーラーの正常な実行を示す、コンマで区切った終了コードの一覧 (例: 0, 1234, 5678)。</span><span class="sxs-lookup"><span data-stu-id="04f9a-263">A comma-separated list of exit codes that indicate your installer ran successfully (for example: 0, 1234, 5678).</span></span>  <span data-ttu-id="04f9a-264">既定では、非 msi は 0、msi は 0, 1641, 3010 です。</span><span class="sxs-lookup"><span data-stu-id="04f9a-264">By default this is 0 for non-msi, and 0, 1641, 3010 for msi.</span></span>|
|<span data-ttu-id="04f9a-265">-MakeAppx [&lt;SwitchParameter&gt;]</span><span class="sxs-lookup"><span data-stu-id="04f9a-265">-MakeAppx [&lt;SwitchParameter&gt;]</span></span>  |<span data-ttu-id="04f9a-266">省略可能</span><span class="sxs-lookup"><span data-stu-id="04f9a-266">Optional</span></span> |<span data-ttu-id="04f9a-267">このスクリプトに出力で MakeAppx を呼び出すように指示するスイッチ (存在する場合)。</span><span class="sxs-lookup"><span data-stu-id="04f9a-267">A switch that, when present, tells this script to call MakeAppx on the output.</span></span> |
|<span data-ttu-id="04f9a-268">-MakeMSIX [&lt;SwitchParameter&gt;]</span><span class="sxs-lookup"><span data-stu-id="04f9a-268">-MakeMSIX [&lt;SwitchParameter&gt;]</span></span>  |<span data-ttu-id="04f9a-269">オプション</span><span class="sxs-lookup"><span data-stu-id="04f9a-269">Optional</span></span> |<span data-ttu-id="04f9a-270">存在する場合、出力を MSIX パッケージとしてパッケージ化するには、このスクリプトに指示するスイッチ。</span><span class="sxs-lookup"><span data-stu-id="04f9a-270">A switch that, when present, tells this script to package the output as an MSIX Package.</span></span> |
|<a id="identity-params" /><strong><span data-ttu-id="04f9a-271">パッケージ ID パラメーター</span><span class="sxs-lookup"><span data-stu-id="04f9a-271">Package identity parameters</span></span></strong>||
|<span data-ttu-id="04f9a-272">-PackageName &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="04f9a-272">-PackageName &lt;String&gt;</span></span> |<span data-ttu-id="04f9a-273">必須</span><span class="sxs-lookup"><span data-stu-id="04f9a-273">Required</span></span> |<span data-ttu-id="04f9a-274">ユニバーサル Windows アプリ パッケージの名前。</span><span class="sxs-lookup"><span data-stu-id="04f9a-274">The name of your Universal Windows App package.</span></span> <span data-ttu-id="04f9a-275">デベロッパー センターが数値で始まる ID をパッケージに割り当てる場合、必ず <i>-AppId</i> パラメーターも渡し、そのパラメーターの値として文字列サフィックスのみを使ってください (ピリオドの区切り記号の後)。</span><span class="sxs-lookup"><span data-stu-id="04f9a-275">If the dev center assigns an identity to your package that begins with a number, make sure that you also pass in the <i>-AppId</i> parameter, and use only the string suffix (after the period separator) as the value of that parameter.</span></span> |
|<span data-ttu-id="04f9a-276">-Publisher &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="04f9a-276">-Publisher &lt;String&gt;</span></span> |<span data-ttu-id="04f9a-277">必須</span><span class="sxs-lookup"><span data-stu-id="04f9a-277">Required</span></span> |<span data-ttu-id="04f9a-278">ユニバーサル Windows アプリ パッケージの発行元</span><span class="sxs-lookup"><span data-stu-id="04f9a-278">The publisher of your Universal Windows App package</span></span> |
|<span data-ttu-id="04f9a-279">-Version &lt;Version&gt;</span><span class="sxs-lookup"><span data-stu-id="04f9a-279">-Version &lt;Version&gt;</span></span> |<span data-ttu-id="04f9a-280">必須</span><span class="sxs-lookup"><span data-stu-id="04f9a-280">Required</span></span> |<span data-ttu-id="04f9a-281">ユニバーサル Windows アプリ パッケージのバージョン番号</span><span class="sxs-lookup"><span data-stu-id="04f9a-281">The version number for your Universal Windows App package</span></span> |
|<a id="manifest-params" /><strong><span data-ttu-id="04f9a-282">パッケージ マニフェスト パラメーター</span><span class="sxs-lookup"><span data-stu-id="04f9a-282">Package manifest parameters</span></span></strong>||
|<span data-ttu-id="04f9a-283">-AppExecutable &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="04f9a-283">-AppExecutable &lt;String&gt;</span></span> |<span data-ttu-id="04f9a-284">省略可能</span><span class="sxs-lookup"><span data-stu-id="04f9a-284">Optional</span></span> |<span data-ttu-id="04f9a-285">アプリケーションのメインの実行可能ファイルの名前 (例:"MyApp.exe")。</span><span class="sxs-lookup"><span data-stu-id="04f9a-285">The name of your application's main executable (eg "MyApp.exe").</span></span> <span data-ttu-id="04f9a-286">インストーラーを使用しない変換では、このパラメーターは必須です。</span><span class="sxs-lookup"><span data-stu-id="04f9a-286">This parameter is required for a no-installer conversion.</span></span> |
|<span data-ttu-id="04f9a-287">-AppFileTypes &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="04f9a-287">-AppFileTypes &lt;String&gt;</span></span>|<span data-ttu-id="04f9a-288">省略可能</span><span class="sxs-lookup"><span data-stu-id="04f9a-288">Optional</span></span> |<span data-ttu-id="04f9a-289">アプリケーションに関連付ける、ファイルの種類のコンマ区切りの一覧。</span><span class="sxs-lookup"><span data-stu-id="04f9a-289">A comma-separated list of file types which the application will be associated with.</span></span> <span data-ttu-id="04f9a-290">使用例: -AppFileTypes "'.md', '.markdown'"。</span><span class="sxs-lookup"><span data-stu-id="04f9a-290">Example usage: -AppFileTypes "'.md', '.markdown'".</span></span>|
|<span data-ttu-id="04f9a-291">-AppId &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="04f9a-291">-AppId &lt;String&gt;</span></span> |<span data-ttu-id="04f9a-292">省略可能</span><span class="sxs-lookup"><span data-stu-id="04f9a-292">Optional</span></span> |<span data-ttu-id="04f9a-293">Windows アプリ パッケージ マニフェストでアプリケーション ID を設定する値を指定します。</span><span class="sxs-lookup"><span data-stu-id="04f9a-293">Specifies a value to set Application Id to in the Windows app package manifest.</span></span> <span data-ttu-id="04f9a-294">指定しなかった場合は、*PackageName* で渡した値が設定されます。</span><span class="sxs-lookup"><span data-stu-id="04f9a-294">If it is not specified, it will be set to the value passed in for *PackageName*.</span></span> <span data-ttu-id="04f9a-295">多くの場合、*PackageName* を使って問題ありません。</span><span class="sxs-lookup"><span data-stu-id="04f9a-295">In many cases, using the *PackageName* is fine.</span></span> <span data-ttu-id="04f9a-296">ただし、デベロッパー センターが数値で始まる ID をパッケージに割り当てる場合、必ず <i>-AppId</i> パラメーターも渡し、そのパラメーターの値として文字列サフィックスのみを使ってください (ピリオドの区切り記号の後)。</span><span class="sxs-lookup"><span data-stu-id="04f9a-296">However, if the dev center assigns an identity to your package that begins with a number, make sure that you also pass in the <i>-AppId</i> parameter, and use only the string suffix (after the period separator) as the value of that parameter.</span></span> |
|<span data-ttu-id="04f9a-297">-AppDisplayName &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="04f9a-297">-AppDisplayName &lt;String&gt;</span></span>  |<span data-ttu-id="04f9a-298">省略可能</span><span class="sxs-lookup"><span data-stu-id="04f9a-298">Optional</span></span> |<span data-ttu-id="04f9a-299">Windows アプリ パッケージ マニフェストでアプリケーションの表示名を設定する値を指定します。</span><span class="sxs-lookup"><span data-stu-id="04f9a-299">Specifies a value to set Application Display Name to in the Windows app package manifest.</span></span> <span data-ttu-id="04f9a-300">指定しなかった場合は、*PackageName* で渡した値が設定されます。</span><span class="sxs-lookup"><span data-stu-id="04f9a-300">If it is not specified, it will be set to the value passed in for *PackageName*.</span></span> |
|<span data-ttu-id="04f9a-301">-AppDescription &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="04f9a-301">-AppDescription &lt;String&gt;</span></span> |<span data-ttu-id="04f9a-302">省略可能</span><span class="sxs-lookup"><span data-stu-id="04f9a-302">Optional</span></span> |<span data-ttu-id="04f9a-303">Windows アプリ パッケージ マニフェストでアプリケーションの説明を設定する値を指定します。</span><span class="sxs-lookup"><span data-stu-id="04f9a-303">Specifies a value to set Application Description to in the Windows app package manifest.</span></span> <span data-ttu-id="04f9a-304">指定しなかった場合は、*PackageName* で渡した値が設定されます。</span><span class="sxs-lookup"><span data-stu-id="04f9a-304">If it is not specified, it will be set to the value passed in for *PackageName*.</span></span>|
|<span data-ttu-id="04f9a-305">-PackageDisplayName &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="04f9a-305">-PackageDisplayName &lt;String&gt;</span></span> |<span data-ttu-id="04f9a-306">省略可能</span><span class="sxs-lookup"><span data-stu-id="04f9a-306">Optional</span></span> |<span data-ttu-id="04f9a-307">Windows アプリ パッケージ マニフェストでパッケージの表示名を設定する値を指定します。</span><span class="sxs-lookup"><span data-stu-id="04f9a-307">Specifies a value to set Package Display Name to in the Windows app package manifest.</span></span> <span data-ttu-id="04f9a-308">指定しなかった場合は、*PackageName* で渡した値が設定されます。</span><span class="sxs-lookup"><span data-stu-id="04f9a-308">If it is not specified, it will be set to the value passed in for *PackageName*.</span></span> |
|<span data-ttu-id="04f9a-309">-PackagePublisherDisplayName &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="04f9a-309">-PackagePublisherDisplayName &lt;String&gt;</span></span> |<span data-ttu-id="04f9a-310">省略可能</span><span class="sxs-lookup"><span data-stu-id="04f9a-310">Optional</span></span> |<span data-ttu-id="04f9a-311">Windows アプリ パッケージ マニフェストでパッケージ発行元の表示名を設定する値を指定します。</span><span class="sxs-lookup"><span data-stu-id="04f9a-311">Specifies a value to set Package Publisher Display Name to in the Windows app package manifest.</span></span> <span data-ttu-id="04f9a-312">指定しなかった場合は、*Publisher* で渡した値が設定されます。</span><span class="sxs-lookup"><span data-stu-id="04f9a-312">If it is not specified, it will be set to the value passed in for *Publisher*.</span></span> |
|<a id="cleanup-params" /><strong><span data-ttu-id="04f9a-313">クリーンアップ パラメーター</span><span class="sxs-lookup"><span data-stu-id="04f9a-313">Cleanup parameters</span></span></strong>|||
|<span data-ttu-id="04f9a-314">-Cleanup [&lt;Option&gt;]</span><span class="sxs-lookup"><span data-stu-id="04f9a-314">-Cleanup [&lt;Option&gt;]</span></span> |<span data-ttu-id="04f9a-315">必須</span><span class="sxs-lookup"><span data-stu-id="04f9a-315">Required</span></span> |<span data-ttu-id="04f9a-316">DesktopAppConverter の成果物のクリーンアップを実行します。</span><span class="sxs-lookup"><span data-stu-id="04f9a-316">Runs cleanup for the DesktopAppConverter artifacts.</span></span> <span data-ttu-id="04f9a-317">クリーンアップ モードには 3 つの有効なオプションがあります。</span><span class="sxs-lookup"><span data-stu-id="04f9a-317">There are 3 valid options for the Cleanup mode.</span></span> |
|<span data-ttu-id="04f9a-318">-Cleanup All</span><span class="sxs-lookup"><span data-stu-id="04f9a-318">-Cleanup All</span></span> | |<span data-ttu-id="04f9a-319">展開済みのすべての基本イメージを削除し、コンバーターのすべての一時ファイルを削除します。コンテナーのネットワークを削除し、Windows のオプション機能、コンテナーを無効にします。</span><span class="sxs-lookup"><span data-stu-id="04f9a-319">Deletes all expanded base images, removes any temporary converter files, removes the container network, and disables the optional Windows feature, Containers.</span></span> |
|<span data-ttu-id="04f9a-320">-Cleanup WorkDirectory</span><span class="sxs-lookup"><span data-stu-id="04f9a-320">-Cleanup WorkDirectory</span></span> |<span data-ttu-id="04f9a-321">必須</span><span class="sxs-lookup"><span data-stu-id="04f9a-321">Required</span></span> |<span data-ttu-id="04f9a-322">コンバーターのすべての一時ファイルを削除します。</span><span class="sxs-lookup"><span data-stu-id="04f9a-322">Removes all the temporary converter files.</span></span> |
|<span data-ttu-id="04f9a-323">-Cleanup ExpandedImage</span><span class="sxs-lookup"><span data-stu-id="04f9a-323">-Cleanup ExpandedImage</span></span> |<span data-ttu-id="04f9a-324">必須</span><span class="sxs-lookup"><span data-stu-id="04f9a-324">Required</span></span> |<span data-ttu-id="04f9a-325">ホスト コンピューターにインストールされているすべての展開済みの基本イメージを削除します。</span><span class="sxs-lookup"><span data-stu-id="04f9a-325">Deletes all the expanded base images installed on your host machine.</span></span> |
|<a id="architecture-params" /><strong><span data-ttu-id="04f9a-326">パッケージ アーキテクチャ パラメーター</span><span class="sxs-lookup"><span data-stu-id="04f9a-326">Package architecture parameters</span></span></strong>|||
|<span data-ttu-id="04f9a-327">-PackageArch &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="04f9a-327">-PackageArch &lt;String&gt;</span></span> |<span data-ttu-id="04f9a-328">必須</span><span class="sxs-lookup"><span data-stu-id="04f9a-328">Required</span></span> |<span data-ttu-id="04f9a-329">指定したアーキテクチャのパッケージを生成します。</span><span class="sxs-lookup"><span data-stu-id="04f9a-329">Generates a package with the specified architecture.</span></span> <span data-ttu-id="04f9a-330">有効なオプションは、'x86' または 'x64' です。たとえば、-PackageArch x86 のように指定します。</span><span class="sxs-lookup"><span data-stu-id="04f9a-330">Valid options are 'x86' or 'x64'; for example, -PackageArch x86.</span></span> <span data-ttu-id="04f9a-331">このパラメーターは省略可能です。</span><span class="sxs-lookup"><span data-stu-id="04f9a-331">This parameter is optional.</span></span> <span data-ttu-id="04f9a-332">指定されていない場合、DesktopAppConverter はパッケージのアーキテクチャの自動検出を試みます。</span><span class="sxs-lookup"><span data-stu-id="04f9a-332">If unspecified, the DesktopAppConverter will try to auto-detect package architecture.</span></span> <span data-ttu-id="04f9a-333">自動検出に失敗した場合、既定値は x64 パッケージです。</span><span class="sxs-lookup"><span data-stu-id="04f9a-333">If auto-detection fails, it will default to x64 package.</span></span> |
|<a id="other-params" /><strong><span data-ttu-id="04f9a-334">その他のパラメーター</span><span class="sxs-lookup"><span data-stu-id="04f9a-334">Miscellaneous parameters</span></span></strong>|||
|<span data-ttu-id="04f9a-335">-ExpandedBaseImage &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="04f9a-335">-ExpandedBaseImage &lt;String&gt;</span></span>  |<span data-ttu-id="04f9a-336">省略可能</span><span class="sxs-lookup"><span data-stu-id="04f9a-336">Optional</span></span> |<span data-ttu-id="04f9a-337">既に展開済みの基本イメージの完全パス。</span><span class="sxs-lookup"><span data-stu-id="04f9a-337">Full path to an already expanded base image.</span></span>|
|<span data-ttu-id="04f9a-338">-LogFile &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="04f9a-338">-LogFile &lt;String&gt;</span></span>  |<span data-ttu-id="04f9a-339">省略可能</span><span class="sxs-lookup"><span data-stu-id="04f9a-339">Optional</span></span> |<span data-ttu-id="04f9a-340">ログ ファイルを指定します。</span><span class="sxs-lookup"><span data-stu-id="04f9a-340">Specifies a log file.</span></span> <span data-ttu-id="04f9a-341">省略した場合は、ログ ファイルの一時的な場所が作成されます。</span><span class="sxs-lookup"><span data-stu-id="04f9a-341">If omitted, a log file temporary location will be created.</span></span> |
| <span data-ttu-id="04f9a-342">-Sign [&lt;SwitchParameter&gt;]</span><span class="sxs-lookup"><span data-stu-id="04f9a-342">-Sign [&lt;SwitchParameter&gt;]</span></span> |<span data-ttu-id="04f9a-343">省略可能</span><span class="sxs-lookup"><span data-stu-id="04f9a-343">Optional</span></span> |<span data-ttu-id="04f9a-344">出力する Windows アプリ パッケージに、テスト用に生成された証明書を使用して署名するようにこのスクリプトに指示します。</span><span class="sxs-lookup"><span data-stu-id="04f9a-344">Tells this script to sign the output Windows app package by using a generated certificate for testing purposes.</span></span> <span data-ttu-id="04f9a-345">このスイッチは、```-MakeAppx``` スイッチと共に指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="04f9a-345">This switch should be present alongside the switch ```-MakeAppx```.</span></span> |
|<span data-ttu-id="04f9a-346">&lt;共通パラメーター&gt;</span><span class="sxs-lookup"><span data-stu-id="04f9a-346">&lt;Common parameters&gt;</span></span> |<span data-ttu-id="04f9a-347">必須</span><span class="sxs-lookup"><span data-stu-id="04f9a-347">Required</span></span> |<span data-ttu-id="04f9a-348">このコマンドレットは、共通パラメーター *Verbose*、*Debug*、*ErrorAction*、*ErrorVariable*、*WarningAction*、*WarningVariable*、*OutBuffer*、*PipelineVariable*、*OutVariable* をサポートします。</span><span class="sxs-lookup"><span data-stu-id="04f9a-348">This cmdlet supports the common parameters: *Verbose*, *Debug*, *ErrorAction*, *ErrorVariable*, *WarningAction*, *WarningVariable*, *OutBuffer*, *PipelineVariable*, and *OutVariable*.</span></span> <span data-ttu-id="04f9a-349">詳しくは、「[about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="04f9a-349">For more info, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).</span></span> |
| <span data-ttu-id="04f9a-350">-Verify [&lt;SwitchParameter&gt;]</span><span class="sxs-lookup"><span data-stu-id="04f9a-350">-Verify [&lt;SwitchParameter&gt;]</span></span> |<span data-ttu-id="04f9a-351">オプション</span><span class="sxs-lookup"><span data-stu-id="04f9a-351">Optional</span></span> |<span data-ttu-id="04f9a-352">指定されている場合、パッケージ アプリと Microsoft Store 要件に照らして、アプリ パッケージを検証するように DAC に指示するスイッチ。</span><span class="sxs-lookup"><span data-stu-id="04f9a-352">A switch that, when present, tells the DAC to validate the app package against packaged app and Microsoft Store requirements.</span></span> <span data-ttu-id="04f9a-353">結果は、検証レポート "VerifyReport.xml" で、ブラウザーでの視覚化に最適です。</span><span class="sxs-lookup"><span data-stu-id="04f9a-353">The result is a validation report "VerifyReport.xml", which is best visualized in a browser.</span></span> <span data-ttu-id="04f9a-354">このスイッチは、`-MakeAppx` スイッチと共に指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="04f9a-354">This switch should be present alongside the switch `-MakeAppx`.</span></span> |
|<span data-ttu-id="04f9a-355">-PublishComRegistrations</span><span class="sxs-lookup"><span data-stu-id="04f9a-355">-PublishComRegistrations</span></span>| <span data-ttu-id="04f9a-356">省略可能</span><span class="sxs-lookup"><span data-stu-id="04f9a-356">Optional</span></span>| <span data-ttu-id="04f9a-357">インストーラーによって行われたすべての パブリック COM 登録をスキャンし、有効な登録をマニフェストで公開します。</span><span class="sxs-lookup"><span data-stu-id="04f9a-357">Scans all public COM registrations made by your installer and publishes the valid ones in your manifest.</span></span> <span data-ttu-id="04f9a-358">このフラグは、これらの登録を他のアプリケーションで利用できるようにする場合にのみ使用してください。</span><span class="sxs-lookup"><span data-stu-id="04f9a-358">Use this flag only if you want to make these registrations available to other applications.</span></span> <span data-ttu-id="04f9a-359">これらの登録を対象アプリケーションでのみ使用する場合、このフラグを使用する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="04f9a-359">You don't need to use this flag if these registrations will be used only by your application.</span></span> <br><br><span data-ttu-id="04f9a-360">アプリをパッケージ化した後、正常に動作するように COM 登録を行うには、[こちらの記事](https://blogs.windows.com/buildingapps/2017/04/13/com-server-ole-document-support-desktop-bridge/#lDg5gSFxJ2TDlpC6.97)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="04f9a-360">Review [this article](https://blogs.windows.com/buildingapps/2017/04/13/com-server-ole-document-support-desktop-bridge/#lDg5gSFxJ2TDlpC6.97) to make sure that your COM registrations behave as you expect after you package your app.</span></span>

<a id="run-app" />

## <a name="run-the-packaged-app"></a><span data-ttu-id="04f9a-361">パッケージ アプリを実行する</span><span class="sxs-lookup"><span data-stu-id="04f9a-361">Run the packaged app</span></span>

<span data-ttu-id="04f9a-362">アプリを実行するには、2 種類の方法があります。</span><span class="sxs-lookup"><span data-stu-id="04f9a-362">There's two ways to run your app.</span></span>

<span data-ttu-id="04f9a-363">1 つ目は、PowerShell コマンド プロンプトを開いて、```Add-AppxPackage –Register AppxManifest.xml``` というコマンドを入力する方法です。</span><span class="sxs-lookup"><span data-stu-id="04f9a-363">One way is to open a PowerShell command prompt, and then type this command: ```Add-AppxPackage –Register AppxManifest.xml```.</span></span> <span data-ttu-id="04f9a-364">おそらくに署名する必要がないために、アプリケーションを実行する最も簡単な方法です。</span><span class="sxs-lookup"><span data-stu-id="04f9a-364">It's probably the easiest way to run your application because you don't have to sign it.</span></span>

<span data-ttu-id="04f9a-365">証明書を使って、アプリケーションの署名を別の方法です。</span><span class="sxs-lookup"><span data-stu-id="04f9a-365">Another way is to sign your application with a certificate.</span></span> <span data-ttu-id="04f9a-366">使用する場合、```sign```パラメーター、Desktop App Converter は、1 つ生成され、し、それを使用してアプリケーションに署名します。</span><span class="sxs-lookup"><span data-stu-id="04f9a-366">If you use the ```sign``` parameter, the Desktop App Converter will generate one for you, and then sign your application with it.</span></span> <span data-ttu-id="04f9a-367">その証明書ファイルは **auto-generated.cer** という名前になり、パッケージ アプリのルート フォルダーに配置されます。</span><span class="sxs-lookup"><span data-stu-id="04f9a-367">That file is named **auto-generated.cer**, and you can find it in the root folder of your packaged app.</span></span>

<span data-ttu-id="04f9a-368">生成された証明書をインストールし、アプリを実行するには、次の手順を実行します。</span><span class="sxs-lookup"><span data-stu-id="04f9a-368">Follow these steps to install the generated certificate, and then run your app.</span></span>

1. <span data-ttu-id="04f9a-369">**auto-generated.cer** ファイルをダブルクリックして証明書をインストールします。</span><span class="sxs-lookup"><span data-stu-id="04f9a-369">Double-click the **auto-generated.cer** file to install the certificate.</span></span>

   ![生成された証明書ファイル](images/desktop-to-uwp/generated-cert-file.png)

   > [!NOTE]
   > <span data-ttu-id="04f9a-371">パスワードを求められた場合は、既定のパスワード "123456" を使用します。</span><span class="sxs-lookup"><span data-stu-id="04f9a-371">If you're prompted for a password, use the default password "123456".</span></span>

2. <span data-ttu-id="04f9a-372">**[証明書]** ダイアログ ボックスで、**[証明書のインストール]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="04f9a-372">In the **Certificate** dialog box, choose the **Install Certificate** button.</span></span>
3. <span data-ttu-id="04f9a-373">**証明書インポート ウィザード**で、証明書を**ローカル コンピューター**にインストールし、証明書を "**信頼されたユーザー**" の証明書ストアに配置します。</span><span class="sxs-lookup"><span data-stu-id="04f9a-373">In the **Certificate Import Wizard**, install the certificate onto the **Local Machine**, and place the certificate into the **Trusted People** certificate store.</span></span>

   ![信頼されたユーザー ストア](images/desktop-to-uwp/trusted-people-store.png)

5. <span data-ttu-id="04f9a-375">パッケージ アプリのルート フォルダーで、Windows アプリのパッケージ ファイルをダブルクリックします。</span><span class="sxs-lookup"><span data-stu-id="04f9a-375">In root folder of your packaged app, double click the Windows app package file.</span></span>

   ![Windows アプリのパッケージ ファイル](images/desktop-to-uwp/windows-app-package.png)

6. <span data-ttu-id="04f9a-377">**[インストール]** を選択してアプリをインストールします。</span><span class="sxs-lookup"><span data-stu-id="04f9a-377">Install the app, by choosing the **Install** button.</span></span>

   ![[インストール] ボタン](images/desktop-to-uwp/install.png)


## <a name="modify-the-packaged-app"></a><span data-ttu-id="04f9a-379">パッケージ アプリを変更する</span><span class="sxs-lookup"><span data-stu-id="04f9a-379">Modify the packaged app</span></span>

<span data-ttu-id="04f9a-380">バグを解決、ビジュアルの資産の追加またはアプリを強化するライブ タイルなどの最新のエクスペリエンスでパッケージ化されたアプリケーションに変更を加えたあります可能性があります。</span><span class="sxs-lookup"><span data-stu-id="04f9a-380">You'll likely make changes to your packaged application to address bugs, add visual assets, or enhance your application with modern experiences such as live tiles.</span></span>

<span data-ttu-id="04f9a-381">変更を加えた後、もう一度コンバーターを実行する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="04f9a-381">After you make your changes, you don't need to run the converter again.</span></span> <span data-ttu-id="04f9a-382">ほとんどの場合、することができますだけと再パッケージ化アプリケーション MakeAppx ツールを使用して、アプリの appxmanifest.xml ファイル、DAC が生成されます。</span><span class="sxs-lookup"><span data-stu-id="04f9a-382">In most cases, you can just repackage your application by using the MakeAppx tool and the appxmanifest.xml file the DAC generates for your app.</span></span> <span data-ttu-id="04f9a-383">「[Windows アプリ パッケージを生成する](desktop-to-uwp-manual-conversion.md#make-appx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="04f9a-383">See [Generate a Windows app package](desktop-to-uwp-manual-conversion.md#make-appx).</span></span>

* <span data-ttu-id="04f9a-384">アプリのビジュアル アセットを変更する場合、新しいパッケージ リソース インデックス ファイルを生成し、MakeAppx ツールを実行して新しいパッケージを生成します。</span><span class="sxs-lookup"><span data-stu-id="04f9a-384">If you modify any of the visual assets of your app, generate a new Package Resource Index file, and then run the MakeAppx tool to generate a new package.</span></span> <span data-ttu-id="04f9a-385">「[パッケージ リソース インデックス (PRI) ファイルを生成する](desktop-to-uwp-manual-conversion.md#make-pri)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="04f9a-385">See [Generate a Package Resource Index (PRI) file](desktop-to-uwp-manual-conversion.md#make-pri).</span></span>

* <span data-ttu-id="04f9a-386">Windows タスク バー、タスク ビュー、スナップ アシスト、Alt + Tab キーを押したときの一覧、およびスタート画面のタイルの右下に表示されるアイコンおよびタイルを追加する場合は、「[(省略可能) ターゲット ベースのプレートなしのアセットを追加する](desktop-to-uwp-manual-conversion.md#target-based-assets)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="04f9a-386">If you want to add icons or tiles that appear on the Windows taskbar, task view, LT+TAB, snap assist, and the lower right corner of Start tiles, see [(Optional Add Target-based unplated assets](desktop-to-uwp-manual-conversion.md#target-based-assets).</span></span>

> [!NOTE]
> <span data-ttu-id="04f9a-387">インストーラーによるレジストリ設定を変更した場合は、その変更を適用するために、Desktop App Converter をもう一度実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="04f9a-387">If you make changes to registry settings that your installer makes, you will have to run the Desktop App Converter again to pick up those changes.</span></span>

**<span data-ttu-id="04f9a-388">ビデオ</span><span class="sxs-lookup"><span data-stu-id="04f9a-388">Videos</span></span>**

|<span data-ttu-id="04f9a-389">出力の変更と再パッケージ化</span><span class="sxs-lookup"><span data-stu-id="04f9a-389">Modify and repackage output</span></span> |<span data-ttu-id="04f9a-390">デモ: 出力の変更と再パッケージ化</span><span class="sxs-lookup"><span data-stu-id="04f9a-390">Demo: Modify and repackage output</span></span>|
|---|---|
|<iframe src="https://mva.microsoft.com/en-US/training-courses-embed/developers-guide-to-the-desktop-bridge-17373/Video-Modifying-and-Repackaging-Output-from-Desktop-App-Converter-OwpAJ3WhD_6706218965" width="426" height="472" allowFullScreen frameBorder="0"></iframe>|<iframe src="https://mva.microsoft.com/en-US/training-courses-embed/developers-guide-to-the-desktop-bridge-17373/Demo-Modify-Output-from-Desktop-App-Converter-gEnsa3WhD_8606218965" width="426" height="472" allowFullScreen frameBorder="0"></iframe>|

<span data-ttu-id="04f9a-391">次の 2 つのセクションでは、いくつかの省略可能な修正を検討してパッケージ化されたアプリケーションにについて説明します。</span><span class="sxs-lookup"><span data-stu-id="04f9a-391">The following two sections describe a couple of optional fix-ups to the packaged application that you might consider.</span></span>

### <a name="delete-unnecessary-files-and-registry-keys"></a><span data-ttu-id="04f9a-392">不要なファイルとレジストリ キーを削除する</span><span class="sxs-lookup"><span data-stu-id="04f9a-392">Delete unnecessary files and registry keys</span></span>

<span data-ttu-id="04f9a-393">Desktop App Converter では、コンテナー内のファイルとシステム ノイズの除去に、非常に保守的なアプローチを取っています。</span><span class="sxs-lookup"><span data-stu-id="04f9a-393">The desktop App Converter takes a very conservative approach to filtering out files and system noise in the container.</span></span>

<span data-ttu-id="04f9a-394">VFS フォルダーを確認し、インストーラーに必要ないファイルがあれば、削除することもできます。</span><span class="sxs-lookup"><span data-stu-id="04f9a-394">If you want, you can review the VFS folder and delete any files that your installer doesn't need.</span></span>  <span data-ttu-id="04f9a-395">また、Reg.dat の内容を確認し、アプリによってインストールされないキーや不要なキーがあれば、削除できます。</span><span class="sxs-lookup"><span data-stu-id="04f9a-395">You can also review the contents of Reg.dat and delete any keys that are not installed/needed by the app.</span></span>

### <a name="fix-corrupted-pe-headers"></a><span data-ttu-id="04f9a-396">破損した PEヘッダーを修正する</span><span class="sxs-lookup"><span data-stu-id="04f9a-396">Fix corrupted PE headers</span></span>

<span data-ttu-id="04f9a-397">DesktopAppConverter は 変換処理中に PEHeaderCertFixTool を自動的に実行し、破損している PEヘッダーを修正します。</span><span class="sxs-lookup"><span data-stu-id="04f9a-397">During the conversion process, the DesktopAppConverter automatically runs the PEHeaderCertFixTool to fixup any corrupted PE headers.</span></span> <span data-ttu-id="04f9a-398">ただし、UWP の Windows アプリ パッケージ、ルーズ ファイル、または特定のバイナリで、PEHeaderCertFixTool を実行することも可能です。</span><span class="sxs-lookup"><span data-stu-id="04f9a-398">However, you can also run the PEHeaderCertFixTool on a UWP Windows app package, loose files, or a specific binary.</span></span> <span data-ttu-id="04f9a-399">次に例を示します。</span><span class="sxs-lookup"><span data-stu-id="04f9a-399">Here's an example.</span></span>

```CMD
PEHeaderCertFixTool.exe <binary file>|<.appx package>|<folder> [/c] [/v]
 /c   -- check for corrupted certificate but do not fix (optional)
 /v   -- verbose (optional)
example1: PEHeaderCertFixTool app.exe
example2: PEHeaderCertFixTool c:\package.appx /c
example3: PEHeaderCertFixTool c:\myapp /c /v
```

## <a name="telemetry-from-desktop-app-converter"></a><span data-ttu-id="04f9a-400">Desktop App Converter の利用統計情報</span><span class="sxs-lookup"><span data-stu-id="04f9a-400">Telemetry from Desktop App Converter</span></span>

<span data-ttu-id="04f9a-401">Desktop App Converter は、ソフトウェアの使用者と使用方法に関する情報を収集して、この情報を Microsoft に送信することがあります。</span><span class="sxs-lookup"><span data-stu-id="04f9a-401">Desktop App Converter may collect information about you and your use of the software and send this info to Microsoft.</span></span> <span data-ttu-id="04f9a-402">Microsoft のデータ収集と製品ドキュメントでの使用の詳細については、「[マイクロソフトのプライバシーに関する声明](http://go.microsoft.com/fwlink/?LinkId=521839)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="04f9a-402">You can learn more about Microsoft's data collection and use in the product documentation and in the [Microsoft Privacy Statement](http://go.microsoft.com/fwlink/?LinkId=521839).</span></span> <span data-ttu-id="04f9a-403">マイクロソフトのプライバシーに関する声明の該当するすべての条項に準拠することに同意します。</span><span class="sxs-lookup"><span data-stu-id="04f9a-403">You agree to comply with all applicable provisions of the Microsoft Privacy Statement.</span></span>

<span data-ttu-id="04f9a-404">既定では、Desktop App Converter の利用統計情報は有効にされています。</span><span class="sxs-lookup"><span data-stu-id="04f9a-404">By default, telemetry will be enabled for the Desktop App Converter.</span></span> <span data-ttu-id="04f9a-405">利用統計情報を目的の設定に構成するには、次のレジストリ キーを追加します。</span><span class="sxs-lookup"><span data-stu-id="04f9a-405">Add the following registry key to configure telemetry to a desired setting:</span></span>  

```cmd
HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\DesktopAppConverter
```
+ <span data-ttu-id="04f9a-406">DWORD を 1 に設定して、*DisableTelemetry* 値を追加または編集します。</span><span class="sxs-lookup"><span data-stu-id="04f9a-406">Add or edit the *DisableTelemetry* value by using a DWORD set to 1.</span></span>
+ <span data-ttu-id="04f9a-407">利用統計情報を有効にするには、このキーを削除するかキーの値を 0 に設定します。</span><span class="sxs-lookup"><span data-stu-id="04f9a-407">To enable telemetry, remove the key or set the value to 0.</span></span>

### <a name="language-support"></a><span data-ttu-id="04f9a-408">言語サポート</span><span class="sxs-lookup"><span data-stu-id="04f9a-408">Language support</span></span>

<span data-ttu-id="04f9a-409">Desktop App Converterは、Unicode をサポートしていません。したがって、漢字または非 ASCII 文字をツールで使用することはできません。</span><span class="sxs-lookup"><span data-stu-id="04f9a-409">The Desktop App Converter does not support Unicode; thus, no Chinese characters or non-ASCII characters can be used with the tool.</span></span>

## <a name="next-steps"></a><span data-ttu-id="04f9a-410">次のステップ</span><span class="sxs-lookup"><span data-stu-id="04f9a-410">Next steps</span></span>

**<span data-ttu-id="04f9a-411">質問に対する回答を見つける</span><span class="sxs-lookup"><span data-stu-id="04f9a-411">Find answers to your questions</span></span>**

<span data-ttu-id="04f9a-412">ご質問がある場合は、</span><span class="sxs-lookup"><span data-stu-id="04f9a-412">Have questions?</span></span> <span data-ttu-id="04f9a-413">Stack Overflow でお問い合わせください。</span><span class="sxs-lookup"><span data-stu-id="04f9a-413">Ask us on Stack Overflow.</span></span> <span data-ttu-id="04f9a-414">Microsoft のチームでは、これらの[タグ](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge)をチェックしています。</span><span class="sxs-lookup"><span data-stu-id="04f9a-414">Our team monitors these [tags](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge).</span></span> <span data-ttu-id="04f9a-415">[こちら](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D)から質問することもできます。</span><span class="sxs-lookup"><span data-stu-id="04f9a-415">You can also ask us [here](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D).</span></span>

<span data-ttu-id="04f9a-416">[ここ](desktop-to-uwp-known-issues.md#app-converter)で既知の問題の一覧を確認することもできます。</span><span class="sxs-lookup"><span data-stu-id="04f9a-416">You can also refer to [this](desktop-to-uwp-known-issues.md#app-converter) list of known issues.</span></span>

**<span data-ttu-id="04f9a-417">フィードバックの提供または機能の提案を行う</span><span class="sxs-lookup"><span data-stu-id="04f9a-417">Give feedback or make feature suggestions</span></span>**

<span data-ttu-id="04f9a-418">[UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial) のページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="04f9a-418">See [UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial).</span></span>

**<span data-ttu-id="04f9a-419">アプリケーションを実行し、検索/問題を修正します。</span><span class="sxs-lookup"><span data-stu-id="04f9a-419">Run your application / find and fix issues</span></span>**

<span data-ttu-id="04f9a-420">[実行、デバッグ、およびデスクトップ アプリケーションをパッケージ化されたテスト](desktop-to-uwp-debug.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="04f9a-420">See [Run, debug, and test a packaged desktop application](desktop-to-uwp-debug.md)</span></span>

**<span data-ttu-id="04f9a-421">アプリを配布する</span><span class="sxs-lookup"><span data-stu-id="04f9a-421">Distribute your app</span></span>**

<span data-ttu-id="04f9a-422">[デスクトップ アプリケーションのパッケージの配布](desktop-to-uwp-distribute.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="04f9a-422">See [Distribute a packaged desktop application](desktop-to-uwp-distribute.md)</span></span>
