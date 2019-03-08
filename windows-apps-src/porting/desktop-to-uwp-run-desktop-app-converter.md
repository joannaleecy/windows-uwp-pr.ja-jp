---
Description: Desktop Converter App を実行して、Windows デスクトップ アプリケーション (Win32、WPF、Windows フォームなど) をパッケージ化します。
Search.Product: eADQiWindows 10XVcnh
title: Desktop App Converter を使用してアプリをパッケージ化する (デスクトップ ブリッジ)
ms.date: 08/21/2018
ms.topic: article
keywords: windows 10, uwp
ms.assetid: 74c84eb6-4714-4e12-a658-09cb92b576e3
ms.localizationpriority: medium
ms.openlocfilehash: 392c8c181906e9e403f2204689b5e0406ea0f914
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57652547"
---
# <a name="package-a-desktop-application-using-the-desktop-app-converter"></a><span data-ttu-id="39d14-104">パッケージ、Desktop App Converter を使用してデスクトップ アプリケーション</span><span class="sxs-lookup"><span data-stu-id="39d14-104">Package a desktop application using the Desktop App Converter</span></span>

[<span data-ttu-id="39d14-105">Desktop App Converter を入手する</span><span class="sxs-lookup"><span data-stu-id="39d14-105">Get the Desktop App Converter</span></span>](https://aka.ms/converter)

<span data-ttu-id="39d14-106">Desktop App Converter (DAC) は、分散など、Microsoft Store を使用してサービスの最新の Windows 機能と統合するデスクトップ アプリケーション用のパッケージを作成します。</span><span class="sxs-lookup"><span data-stu-id="39d14-106">The Desktop App Converter (DAC) creates packages for desktop applications to integrate with the latest Windows features, including distribution and servicing via the Microsoft Store.</span></span> <span data-ttu-id="39d14-107">Win32 アプリや .NET 4.6.1 を使用して作成されたアプリも対象になります。</span><span class="sxs-lookup"><span data-stu-id="39d14-107">This includes Win32 apps and apps that you've created by using .NET 4.6.1.</span></span>

![DAC アイコン](images/desktop-to-uwp/dac.png)

<span data-ttu-id="39d14-109">このツールの名前には "Converter" という用語が含まれますが、実は、アプリの変換は行いません。</span><span class="sxs-lookup"><span data-stu-id="39d14-109">While the term "Converter" appears in the name of this tool, it doesn't actually convert your app.</span></span> <span data-ttu-id="39d14-110">アプリケーションは変更されません。</span><span class="sxs-lookup"><span data-stu-id="39d14-110">Your application remains unchanged.</span></span> <span data-ttu-id="39d14-111">しかし、DACは、パッケージ ID を持ち多くの WinRT API を呼び出すことができる Windows アプリ パッケージを生成します。</span><span class="sxs-lookup"><span data-stu-id="39d14-111">However, this tool generates a Windows app package with a package identity and the ability to call a vast range of WinRT APIs.</span></span>

<span data-ttu-id="39d14-112">このパッケージは、開発コンピューターで Add-AppxPackage という PowerShell コマンドレットを使ってインストールすることができます。</span><span class="sxs-lookup"><span data-stu-id="39d14-112">You can install that package by using the Add-AppxPackage PowerShell cmdlet on your development machine.</span></span>

<span data-ttu-id="39d14-113">このコンバーターは、コンバーターのダウンロードに含まれるクリーンな状態の基本イメージを使って、分離された Windows 環境でデスクトップ インストーラーを実行します。</span><span class="sxs-lookup"><span data-stu-id="39d14-113">The converter runs the desktop installer in an isolated Windows environment by using a clean base image provided as part of the converter download.</span></span> <span data-ttu-id="39d14-114">デスクトップ インストーラーが作成するすべてのレジストリとファイル システムの I/O がキャプチャされ、出力の一部としてパッケージ化されます。</span><span class="sxs-lookup"><span data-stu-id="39d14-114">It captures any registry and file system I/O made by the desktop installer and packages it as part of the output.</span></span>

>[!IMPORTANT]
><span data-ttu-id="39d14-115">(それ以外の場合は、デスクトップ ブリッジと呼ばれます) デスクトップ アプリケーションの Windows アプリ パッケージを作成する機能は Windows 10 バージョン 1607 で導入され、Windows 10 Anniversary Update (10.0; を対象とするプロジェクトでのみ使用できます。ビルド 14393) または Visual Studio の今後のリリース。</span><span class="sxs-lookup"><span data-stu-id="39d14-115">The ability to create a Windows app package for your desktop application (otherwise known as the Desktop Bridge) was introduced in Windows 10, version 1607, and it can only be used in projects that target Windows 10 Anniversary Update (10.0; Build 14393) or a later release in Visual Studio.</span></span>

> [!NOTE]
> <span data-ttu-id="39d14-116">Microsoft Virtual Academy から公開されている、<a href="https://mva.microsoft.com/en-US/training-courses/developers-guide-to-the-desktop-bridge-17373?l=oZG0B1WhD_8406218965/">このシリーズ</a>の短いビデオをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="39d14-116">Checkout <a href="https://mva.microsoft.com/en-US/training-courses/developers-guide-to-the-desktop-bridge-17373?l=oZG0B1WhD_8406218965/">this series</a> of short videos published by the Microsoft Virtual Academy.</span></span> <span data-ttu-id="39d14-117">これらのビデオでは、Desktop App Converter を使用する一般的な方法が紹介されています。</span><span class="sxs-lookup"><span data-stu-id="39d14-117">These videos walk you through some common ways to use the Desktop App Converter.</span></span>

## <a name="the-dac-does-more-than-just-generate-a-package-for-you"></a><span data-ttu-id="39d14-118">DAC が行うのはパッケージの生成だけではありません</span><span class="sxs-lookup"><span data-stu-id="39d14-118">The DAC does more than just generate a package for you</span></span>

<span data-ttu-id="39d14-119">他にも以下のような処理を実行できます。</span><span class="sxs-lookup"><span data-stu-id="39d14-119">Here's a few extra things it can do for you.</span></span>

<span data-ttu-id="39d14-120">**Windows 10 Creators Update します。**</span><span class="sxs-lookup"><span data-stu-id="39d14-120">**Windows 10 Creators Update**</span></span>

<span data-ttu-id="39d14-121">:heavy_check_mark:プレビュー ハンドラー、サムネイル ハンドラー、プロパティ ハンドラー、ファイアウォール規則、URL フラグを自動的に登録する。</span><span class="sxs-lookup"><span data-stu-id="39d14-121">:heavy_check_mark: Automatically register your preview handlers, thumbnail handlers, property handlers, firewall rules, URL flags.</span></span>

<span data-ttu-id="39d14-122">:heavy_check_mark:ファイルの種類のマッピングを自動的に登録する。これによりユーザーは、エクスプローラーの **[種類]** 列を使ってファイルをグループ化できるようになります。</span><span class="sxs-lookup"><span data-stu-id="39d14-122">:heavy_check_mark: Automatically register file type mappings that enable users to group files by using the **Kind** column in File Explorer.</span></span>

<span data-ttu-id="39d14-123">:heavy_check_mark:公開 COM サーバーを登録する。</span><span class="sxs-lookup"><span data-stu-id="39d14-123">:heavy_check_mark: Register your public COM servers.</span></span>

<span data-ttu-id="39d14-124">**Windows 10 Anniversary Update 以降**</span><span class="sxs-lookup"><span data-stu-id="39d14-124">**Windows 10 Anniversary Update or later**</span></span>

<span data-ttu-id="39d14-125">:heavy_check_mark:アプリをテストできるように、パッケージに自動的に署名する。</span><span class="sxs-lookup"><span data-stu-id="39d14-125">:heavy_check_mark: Automatically sign your package so that you can test your app.</span></span>

<span data-ttu-id="39d14-126">:heavy_check_mark:パッケージ アプリと Microsoft Store の要件に照らしてアプリケーションを検証します。</span><span class="sxs-lookup"><span data-stu-id="39d14-126">:heavy_check_mark: Validate your application against packaged app and Microsoft Store requirements.</span></span>

<span data-ttu-id="39d14-127">オプションの完全な一覧については、このガイドの「[パラメーター リファレンス](#command-reference)」セクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="39d14-127">To find a complete list of options, see the [Parameters](#command-reference) section of this guide.</span></span>

<span data-ttu-id="39d14-128">パッケージを作成する準備ができたら、始めましょう。</span><span class="sxs-lookup"><span data-stu-id="39d14-128">If you're ready to create your package, let's start.</span></span>

## <a name="first-prepare-your-application"></a><span data-ttu-id="39d14-129">まず、アプリケーションを準備します</span><span class="sxs-lookup"><span data-stu-id="39d14-129">First, prepare your application</span></span>

<span data-ttu-id="39d14-130">アプリケーションのパッケージの作成を開始する前に、このガイドを確認します。[デスクトップ アプリケーションをパッケージ化するための準備](desktop-to-uwp-prepare.md)します。</span><span class="sxs-lookup"><span data-stu-id="39d14-130">Review this guide before you begin creating a package for your application: [Prepare to package a desktop application](desktop-to-uwp-prepare.md).</span></span>

## <a name="make-sure-that-your-system-can-run-the-converter"></a><span data-ttu-id="39d14-131">システムでコンバーターを実行できることを確認する</span><span class="sxs-lookup"><span data-stu-id="39d14-131">Make sure that your system can run the converter</span></span>

<span data-ttu-id="39d14-132">システムが以下の要件を満たしていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="39d14-132">Make sure that your system meets the following requirements:</span></span>

* <span data-ttu-id="39d14-133">Windows 10 Anniversary Update (10.0.14393.0 以降) Pro または Enterprise エディション</span><span class="sxs-lookup"><span data-stu-id="39d14-133">Windows 10 Anniversary Update (10.0.14393.0 and later) Pro or Enterprise edition.</span></span>
* <span data-ttu-id="39d14-134">64 ビット (x64) プロセッサ</span><span class="sxs-lookup"><span data-stu-id="39d14-134">64 bit (x64) processor</span></span>
* <span data-ttu-id="39d14-135">ハードウェア支援による仮想化</span><span class="sxs-lookup"><span data-stu-id="39d14-135">Hardware-assisted virtualization</span></span>
* <span data-ttu-id="39d14-136">Second Level Address Translation (SLAT)</span><span class="sxs-lookup"><span data-stu-id="39d14-136">Second Level Address Translation (SLAT)</span></span>
* <span data-ttu-id="39d14-137">[Windows 10 用 Windows ソフトウェア開発キット (SDK)](https://go.microsoft.com/fwlink/?linkid=821375)</span><span class="sxs-lookup"><span data-stu-id="39d14-137">[Windows Software Development Kit (SDK) for Windows 10](https://go.microsoft.com/fwlink/?linkid=821375).</span></span>

## <a name="start-the-desktop-app-converter"></a><span data-ttu-id="39d14-138">Desktop App Converter を起動する</span><span class="sxs-lookup"><span data-stu-id="39d14-138">Start the Desktop App Converter</span></span>

1. <span data-ttu-id="39d14-139">[Desktop App Converter](https://aka.ms/converter)をダウンロードおよびインストールします。</span><span class="sxs-lookup"><span data-stu-id="39d14-139">Download and install the [Desktop App Converter](https://aka.ms/converter).</span></span>

2. <span data-ttu-id="39d14-140">管理者として Desktop App Converter を実行します。</span><span class="sxs-lookup"><span data-stu-id="39d14-140">Run the Desktop App Converter as an administrator.</span></span>

    ![DAC を管理者として実行する](images/desktop-to-uwp/run-converter.png)

   <span data-ttu-id="39d14-142">コンソール ウィンドウが開きます。</span><span class="sxs-lookup"><span data-stu-id="39d14-142">A console window appears.</span></span> <span data-ttu-id="39d14-143">コマンドを実行するには、このコンソール ウィンドウを使います。</span><span class="sxs-lookup"><span data-stu-id="39d14-143">You'll use that console window to run commands.</span></span>

## <a name="set-a-few-things-up-apps-with-installers-only"></a><span data-ttu-id="39d14-144">必要な設定を行う (インストーラーがあるアプリのみ) </span><span class="sxs-lookup"><span data-stu-id="39d14-144">Set a few things up (apps with installers only)</span></span>

<span data-ttu-id="39d14-145">進んで、次のセクションに、アプリケーションは、インストーラーを持っていない場合。</span><span class="sxs-lookup"><span data-stu-id="39d14-145">You can skip ahead to the next section if your application doesn't have an installer.</span></span>

1. <span data-ttu-id="39d14-146">オペレーティング システムのバージョン番号を特定します。</span><span class="sxs-lookup"><span data-stu-id="39d14-146">Identify the version number of your operating system.</span></span>

   <span data-ttu-id="39d14-147">そのためには、**[ファイル名を指定して実行]** ダイアログ ボックスで「**winver**」と入力し、**[OK]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="39d14-147">To do that, type **winver** in the **Run** dialog box, and then choose the **OK** button.</span></span>

   ![winver](images/desktop-to-uwp/winver.png)

   <span data-ttu-id="39d14-149">**[Windows のバージョン情報]** ダイアログ ボックスに Windows ビルドのバージョンが表示されます。</span><span class="sxs-lookup"><span data-stu-id="39d14-149">You'll find the version of your Windows build in the **About Windows** dialog box.</span></span>

   ![Windows 10 のバージョン](images/desktop-to-uwp/win-10-version.png)

2. <span data-ttu-id="39d14-151">適切な [Desktop App Converter 基本イメージ](https://aka.ms/converterimages)をダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="39d14-151">Download the appropriate [Desktop app Converter base image](https://aka.ms/converterimages).</span></span>

   <span data-ttu-id="39d14-152">ファイル名に含まれるバージョン番号が Windows ビルドのバージョン番号と一致していることを確認してください。</span><span class="sxs-lookup"><span data-stu-id="39d14-152">Make sure that the version number that appears in the name of the file matches the version number of your Windows build.</span></span>

   >[!IMPORTANT]
   > <span data-ttu-id="39d14-153">ビルド番号を使用している場合**15063**、そのビルドのマイナー バージョン以上になるは **.483** (例。**15063.540**) をダウンロードすることを確認、 **UPDATE.wim-BaseImage-15063**ファイル。</span><span class="sxs-lookup"><span data-stu-id="39d14-153">If you're using build number **15063**, and the minor version of that build is equal to or greater than **.483** (For example: **15063.540**), make sure to download the **BaseImage-15063-UPDATE.wim** file.</span></span> <span data-ttu-id="39d14-154">そのビルドのマイナー バージョンが **.483** 未満である場合は、**BaseImage-15063.wim** ファイルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="39d14-154">If the minor version of that build is less than **.483**, download the **BaseImage-15063.wim** file.</span></span> <span data-ttu-id="39d14-155">このベース ファイルの互換性のないバージョンを既にセットアップしている場合は、修正することができます。</span><span class="sxs-lookup"><span data-stu-id="39d14-155">If you've already setup an incompatible version of this base file, you can fix it.</span></span> <span data-ttu-id="39d14-156">その方法については、この[ブログの投稿](https://blogs.msdn.microsoft.com/appconsult/2017/08/04/desktop-app-converter-fails-on-windows-10-15063-483-and-later-how-to-solve-it/)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="39d14-156">This [blog post](https://blogs.msdn.microsoft.com/appconsult/2017/08/04/desktop-app-converter-fails-on-windows-10-15063-483-and-later-how-to-solve-it/) explains how to do that.</span></span>

3. <span data-ttu-id="39d14-157">ダウンロードしたファイルを後で見つけることができるように、コンピューター上の適切な場所に置きます。</span><span class="sxs-lookup"><span data-stu-id="39d14-157">Place the downloaded file anywhere on your computer where you'll be able to find it later.</span></span>

4. <span data-ttu-id="39d14-158">Desktop App Converter を起動したときに表示されるコンソール ウィンドウで、コマンド ```Set-ExecutionPolicy bypass``` を実行します。</span><span class="sxs-lookup"><span data-stu-id="39d14-158">In the console window that appeared when you started the Desktop App Converter, run this command: ```Set-ExecutionPolicy bypass```.</span></span>
5. <span data-ttu-id="39d14-159">コマンド ```DesktopAppConverter.exe -Setup -BaseImage .\BaseImage-1XXXX.wim -Verbose``` を実行してコンバーターをセットアップします。</span><span class="sxs-lookup"><span data-stu-id="39d14-159">Set up the converter by running  this command: ```DesktopAppConverter.exe -Setup -BaseImage .\BaseImage-1XXXX.wim -Verbose```.</span></span>
6. <span data-ttu-id="39d14-160">画面の指示に従って、コンピューターを再起動します。</span><span class="sxs-lookup"><span data-stu-id="39d14-160">Restart your computer if you're prompted to do so.</span></span>

   <span data-ttu-id="39d14-161">コンバーターによって基本イメージが展開されると、コンソール ウィンドウに状態メッセージが表示されます。</span><span class="sxs-lookup"><span data-stu-id="39d14-161">Status messages appear in the console window as the converter expands the base image.</span></span> <span data-ttu-id="39d14-162">状態メッセージが表示されない場合は、任意のキーを押します。</span><span class="sxs-lookup"><span data-stu-id="39d14-162">If you don't see any status messages, press any key.</span></span> <span data-ttu-id="39d14-163">これにより、コンソール ウィンドウの内容が更新されます。</span><span class="sxs-lookup"><span data-stu-id="39d14-163">This can cause the contents of the console window to refresh.</span></span>

   ![コンソール ウィンドウに表示された状態メッセージ](images/desktop-to-uwp/bas-image-setup.png)

   <span data-ttu-id="39d14-165">基本イメージが完全に展開されたら、次のセクションに進みます。</span><span class="sxs-lookup"><span data-stu-id="39d14-165">When the base image is fully expanded, move to the next section.</span></span>

## <a name="package-an-app"></a><span data-ttu-id="39d14-166">アプリをパッケージ化する</span><span class="sxs-lookup"><span data-stu-id="39d14-166">Package an app</span></span>

<span data-ttu-id="39d14-167">アプリをパッケージ化するには、Desktop App Converter を起動したときに開くコンソール ウィンドウで ``DesktopAppConverter.exe`` コマンドを実行します。</span><span class="sxs-lookup"><span data-stu-id="39d14-167">To Package your app, run the ``DesktopAppConverter.exe`` command in the console window that opened when you started the Desktop App Converter.</span></span>  

<span data-ttu-id="39d14-168">パラメーターを使用して、アプリケーションのパッケージの名前、発行者、およびバージョン番号を指定します。</span><span class="sxs-lookup"><span data-stu-id="39d14-168">You'll specify the package name, publisher and version number of the application by using parameters.</span></span>

> [!NOTE]
> <span data-ttu-id="39d14-169">使用して、パッケージとパブリッシャーの名前を取得するには、Microsoft Store でアプリ名に予約した場合[パートナー センター](https://partner.microsoft.com/dashboard)します。</span><span class="sxs-lookup"><span data-stu-id="39d14-169">If you've reserved your app name in the Microsoft Store, you can obtain the package and publisher names by using [Partner Center](https://partner.microsoft.com/dashboard).</span></span> <span data-ttu-id="39d14-170">アプリを他のシステムにサイドローディング展開する場合は、独自の名前を指定できます。ただし、選択する発行元名は、アプリへの署名に使用する証明書の名前と一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="39d14-170">If you plan to sideload your app onto other systems, you can provide your own names for these as long as the publisher name that you choose matches the name on the certificate you use to sign your app.</span></span>

### <a name="a-quick-look-at-command-parameters"></a><span data-ttu-id="39d14-171">コマンド パラメーターの確認</span><span class="sxs-lookup"><span data-stu-id="39d14-171">A quick look at command parameters</span></span>

<span data-ttu-id="39d14-172">必要なパラメーターは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="39d14-172">Here are the required parameters.</span></span>

```CMD
DesktopAppConverter.exe
-Installer <String>
-Destination <String>
-PackageName <String>
-Publisher <String>
-Version <Version>
```
<span data-ttu-id="39d14-173">各パラメーターについて詳しくは、[こちら](#command-reference)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="39d14-173">You can read about each one [here](#command-reference).</span></span>

### <a name="examples"></a><span data-ttu-id="39d14-174">例</span><span class="sxs-lookup"><span data-stu-id="39d14-174">Examples</span></span>

<span data-ttu-id="39d14-175">アプリをパッケージ化する一般的な方法のいくつかを以下に示します。</span><span class="sxs-lookup"><span data-stu-id="39d14-175">Here's a few common ways to package your app.</span></span>

* [<span data-ttu-id="39d14-176">パッケージ インストーラー (.msi) ファイルがあるアプリケーション</span><span class="sxs-lookup"><span data-stu-id="39d14-176">Package an application that has an installer (.msi) file</span></span>](#installer-conversion)
* [<span data-ttu-id="39d14-177">セットアップの実行可能ファイルがあるアプリケーションをパッケージ化します。</span><span class="sxs-lookup"><span data-stu-id="39d14-177">Package an application that has a setup executable file</span></span>](#setup-conversion)
* [<span data-ttu-id="39d14-178">インストーラーがないアプリケーションをパッケージ化します。</span><span class="sxs-lookup"><span data-stu-id="39d14-178">Package an application that doesn't have an installer</span></span>](#no-installer-conversion)
* [<span data-ttu-id="39d14-179">アプリをパッケージ化、アプリ、署名およびストアに提出できるように準備</span><span class="sxs-lookup"><span data-stu-id="39d14-179">Package an app, sign the app, and prepare it for Store submission</span></span>](#optional-parameters)

<a id="installer-conversion" />

#### <a name="package-an-application-that-has-an-installer-msi-file"></a><span data-ttu-id="39d14-180">パッケージ インストーラー (.msi) ファイルがあるアプリケーション</span><span class="sxs-lookup"><span data-stu-id="39d14-180">Package an application that has an installer (.msi) file</span></span>

<span data-ttu-id="39d14-181">``Installer`` パラメーターでインストーラー ファイルを指定します。</span><span class="sxs-lookup"><span data-stu-id="39d14-181">Point to the installer file by using the ``Installer`` parameter.</span></span>

```cmd
DesktopAppConverter.exe -Installer C:\Installer\MyAppSetup.msi -Destination C:\Output\MyApp -PackageName "MyApp" -Publisher "CN=MyPublisher" -Version 0.0.0.1
```

> [!IMPORTANT]
> <span data-ttu-id="39d14-182">ここで留意すべき重要なことが 2 つあります。</span><span class="sxs-lookup"><span data-stu-id="39d14-182">There are two important things to keep in mind here.</span></span> <span data-ttu-id="39d14-183">まず、インストーラーは独立したフォルダーに配置し、そのインストーラーに関連するファイルだけを同じフォルダーに配置してください。</span><span class="sxs-lookup"><span data-stu-id="39d14-183">First, make sure that your installer is located in an independent folder and that only files related to that installer are in the same folder.</span></span> <span data-ttu-id="39d14-184">コンバーターは、このフォルダーの内容をすべて、分離された Windows 環境にコピーします。</span><span class="sxs-lookup"><span data-stu-id="39d14-184">The converter copies all of the contents of that folder to the isolated Windows environment.</span></span> <br> <span data-ttu-id="39d14-185">次に、パートナー センターでは、id を数字で始まる場合、パッケージに割り当てられる場合、確認で渡すことも、 <i>- AppId</i>パラメーター、およびそのパラメーターの値としては、(後にピリオドを区切り文字) 文字列サフィックスのみを使用します。</span><span class="sxs-lookup"><span data-stu-id="39d14-185">Secondly, if Partner Center assigns an identity to your package that begins with a number, make sure that you also pass in the <i>-AppId</i> parameter, and use only the string suffix (after the period separator) as the value of that parameter.</span></span>  

<span data-ttu-id="39d14-186">**ビデオ**</span><span class="sxs-lookup"><span data-stu-id="39d14-186">**Video**</span></span>

<iframe src="https://mva.microsoft.com/en-US/training-courses-embed/developers-guide-to-the-desktop-bridge-17373/Demo-Convert-an-Application-That-Has-an-MSI-Installer-Kh1UU2WhD_7106218965" width="636" height="480" allowFullScreen frameBorder="0"></iframe>

<span data-ttu-id="39d14-187">インストーラーに、従属ライブラリやフレームワークのインストーラーが含まれている場合、少し異なる方法で整理する必要があります。</span><span class="sxs-lookup"><span data-stu-id="39d14-187">If your installer includes installers for dependent libraries or frameworks, you might have to organize things a bit a differently.</span></span> <span data-ttu-id="39d14-188">[複数のインストーラーとデスクトップ ブリッジの連結に関する記事](https://blogs.msdn.microsoft.com/appconsult/2017/09/11/chaining-multiple-installers-with-the-desktop-app-converter/)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="39d14-188">See [Chaining multiple installers with the Desktop Bridge](https://blogs.msdn.microsoft.com/appconsult/2017/09/11/chaining-multiple-installers-with-the-desktop-app-converter/).</span></span>

<a id="setup-conversion" />

#### <a name="package-an-application-that-has-a-setup-executable-file"></a><span data-ttu-id="39d14-189">セットアップの実行可能ファイルがあるアプリケーションをパッケージ化します。</span><span class="sxs-lookup"><span data-stu-id="39d14-189">Package an application that has a setup executable file</span></span>

<span data-ttu-id="39d14-190">``Installer`` パラメーターを使って、セットアップの実行可能ファイルを指定します。</span><span class="sxs-lookup"><span data-stu-id="39d14-190">Point to the setup executable by using the ``Installer`` parameter.</span></span>

```cmd
DesktopAppConverter.exe -Installer C:\Installer\MyAppSetup.exe -InstallerArguments "/S" -Destination C:\Output\MyApp -PackageName "MyApp" -Publisher "CN=MyPublisher" -Version 0.0.0.1
```
>[!IMPORTANT]
><span data-ttu-id="39d14-191">パートナー センターによって id が数字で始まる場合、パッケージに割り当てられる場合に渡すことも確認、 <i>- AppId</i>パラメーター、およびそのパラメーターの値としては、(後にピリオドを区切り文字) 文字列サフィックスのみを使用します。</span><span class="sxs-lookup"><span data-stu-id="39d14-191">If Partner Center assigns an identity to your package that begins with a number, make sure that you also pass in the <i>-AppId</i> parameter, and use only the string suffix (after the period separator) as the value of that parameter.</span></span>

<span data-ttu-id="39d14-192">``InstallerArguments`` パラメーターは省略可能なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="39d14-192">The ``InstallerArguments`` parameter is an optional parameter.</span></span> <span data-ttu-id="39d14-193">ただし、Desktop App Converter のには、インストーラーを無人モードで実行する必要があります、ためには、アプリケーションがサイレント フラグをサイレント実行する必要がある場合に使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="39d14-193">However, because the Desktop App Converter needs your installer to run in unattended mode, you might have to use it if your application needs silent flags to run silently.</span></span> <span data-ttu-id="39d14-194">``/S`` フラグは非常に一般的なサイレント フラグですが、セットアップ ファイルを作成するために使用したインストーラー テクノロジによっては、使用するフラグが異なる場合もあります。</span><span class="sxs-lookup"><span data-stu-id="39d14-194">The ``/S`` flag is a very common silent flag, but the flag that you use might be different depending on which installer technology you used to create the setup file.</span></span>

<span data-ttu-id="39d14-195">**ビデオ**</span><span class="sxs-lookup"><span data-stu-id="39d14-195">**Video**</span></span>

<iframe src="https://mva.microsoft.com/en-US/training-courses-embed/developers-guide-to-the-desktop-bridge-17373/Demo-Convert-an-Application-That-Has-a-Setup-exe-Installer-amWit2WhD_5306218965" width="636" height="480" allowFullScreen frameBorder="0"></iframe>

<a id="no-installer-conversion" />

#### <a name="package-an-application-that-doesnt-have-an-installer"></a><span data-ttu-id="39d14-196">インストーラーがないアプリケーションをパッケージ化します。</span><span class="sxs-lookup"><span data-stu-id="39d14-196">Package an application that doesn't have an installer</span></span>

<span data-ttu-id="39d14-197">この例では、使用、``Installer``アプリケーション ファイルのルート フォルダーを指定するパラメーター。</span><span class="sxs-lookup"><span data-stu-id="39d14-197">In this example, use the ``Installer`` parameter to point to the root folder of your application files.</span></span>

<span data-ttu-id="39d14-198">アプリの実行可能ファイルを指定するには、`AppExecutable` パラメーターを使用します。</span><span class="sxs-lookup"><span data-stu-id="39d14-198">Use the `AppExecutable` parameter to point to your apps executable file.</span></span>

```cmd
DesktopAppConverter.exe -Installer C:\Installer\MyApp\ -AppExecutable MyApp.exe -Destination C:\Output\MyApp -PackageName "MyApp" -Publisher "CN=MyPublisher" -Version 0.0.0.1
```

>[!IMPORTANT]
><span data-ttu-id="39d14-199">パートナー センターによって id が数字で始まる場合、パッケージに割り当てられる場合に渡すことも確認、 <i>- AppId</i>パラメーター、およびそのパラメーターの値としては、(後にピリオドを区切り文字) 文字列サフィックスのみを使用します。</span><span class="sxs-lookup"><span data-stu-id="39d14-199">If Partner Center assigns an identity to your package that begins with a number, make sure that you also pass in the <i>-AppId</i> parameter, and use only the string suffix (after the period separator) as the value of that parameter.</span></span>

<span data-ttu-id="39d14-200">**ビデオ**</span><span class="sxs-lookup"><span data-stu-id="39d14-200">**Video**</span></span>

<iframe src="https://mva.microsoft.com/en-US/training-courses-embed/developers-guide-to-the-desktop-bridge-17373/Demo-Convert-a-No-Installer-Application-agAXF2WhD_3506218965" width="636" height="480" allowFullScreen frameBorder="0"></iframe>

<a id="optional-parameters" />

#### <a name="package-an-app-sign-the-app-and-run-validation-checks-on-the-package"></a><span data-ttu-id="39d14-201">アプリをパッケージ化し、アプリに署名して、パッケージに対して検証チェックを実行する</span><span class="sxs-lookup"><span data-stu-id="39d14-201">Package an app, sign the app, and run validation checks on the package</span></span>

<span data-ttu-id="39d14-202">この例は、ローカル テストでアプリケーションへの署名およびパッケージ アプリと Microsoft Store の要件に照らしてアプリケーションを検証する方法を示しています点を除いて最初の 1 つに似ています。</span><span class="sxs-lookup"><span data-stu-id="39d14-202">This example is similar to first one except it shows how you can sign your application for local testing, and then validate your application against packaged app and Microsoft Store requirements.</span></span>

```cmd
DesktopAppConverter.exe -Installer C:\Installer\MyAppSetup.exe -InstallerArguments "/S" -Destination C:\Output\MyApp -PackageName "MyApp" -Publisher "CN=MyPublisher" -Version 0.0.0.1 -MakeAppx -Sign -Verbose -Verify
```
>[!IMPORTANT]
><span data-ttu-id="39d14-203">パートナー センターによって id が数字で始まる場合、パッケージに割り当てられる場合に渡すことも確認、 <i>- AppId</i>パラメーター、およびそのパラメーターの値としては、(後にピリオドを区切り文字) 文字列サフィックスのみを使用します。</span><span class="sxs-lookup"><span data-stu-id="39d14-203">If Partner Center assigns an identity to your package that begins with a number, make sure that you also pass in the <i>-AppId</i> parameter, and use only the string suffix (after the period separator) as the value of that parameter.</span></span>

<span data-ttu-id="39d14-204">``Sign``パラメーター証明書を生成し、それを使用してアプリケーションに署名します。</span><span class="sxs-lookup"><span data-stu-id="39d14-204">The ``Sign`` parameter generates a certificate and then signs your application with it.</span></span> <span data-ttu-id="39d14-205">アプリを実行するには、生成された証明書をインストールする必要があります。</span><span class="sxs-lookup"><span data-stu-id="39d14-205">To run your app, you'll have to install that generated certificate.</span></span> <span data-ttu-id="39d14-206">その方法については、このガイドの「[パッケージ アプリを実行する](#run-app)」セクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="39d14-206">To learn how, see the [Run the packaged app](#run-app) section of this guide.</span></span>

<span data-ttu-id="39d14-207">検証でくアプリケーションを使用して、``Verify``パラメーター。</span><span class="sxs-lookup"><span data-stu-id="39d14-207">You can validate you application by using the ``Verify`` parameter.</span></span>

### <a name="a-quick-look-at-optional-parameters"></a><span data-ttu-id="39d14-208">省略可能なパラメーターの確認</span><span class="sxs-lookup"><span data-stu-id="39d14-208">A quick look at optional parameters</span></span>

<span data-ttu-id="39d14-209">``Sign`` パラメーターと ``Verify`` パラメーターは省略可能です。</span><span class="sxs-lookup"><span data-stu-id="39d14-209">The ``Sign`` and ``Verify`` parameters are optional.</span></span> <span data-ttu-id="39d14-210">他にも多数の省略可能なパラメーターがあります。</span><span class="sxs-lookup"><span data-stu-id="39d14-210">There are many more optional parameters.</span></span>  <span data-ttu-id="39d14-211">よく使用される省略可能なパラメーターを以下に示します。</span><span class="sxs-lookup"><span data-stu-id="39d14-211">Here are some of the more commonly used optional parameters.</span></span>

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
<span data-ttu-id="39d14-212">これらについて詳しくは、次のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="39d14-212">You can read about all of them in the next section.</span></span>

<a id="command-reference" />

### <a name="parameter-reference"></a><span data-ttu-id="39d14-213">パラメーター リファレンス</span><span class="sxs-lookup"><span data-stu-id="39d14-213">Parameter Reference</span></span>

<span data-ttu-id="39d14-214">ここでは、Desktop App Converter を実行するときに使用できるパラメーターの完全な一覧をカテゴリ別に示します。</span><span class="sxs-lookup"><span data-stu-id="39d14-214">Here's the complete list of parameters (organized by category) that you can use when you run the Desktop App Converter.</span></span>

* [<span data-ttu-id="39d14-215">セットアップ</span><span class="sxs-lookup"><span data-stu-id="39d14-215">Setup</span></span>](#setup-params)
* [<span data-ttu-id="39d14-216">変換</span><span class="sxs-lookup"><span data-stu-id="39d14-216">Conversion</span></span>](#conversion-params)
* [<span data-ttu-id="39d14-217">パッケージ id</span><span class="sxs-lookup"><span data-stu-id="39d14-217">Package identity</span></span>](#identity-params)
* [<span data-ttu-id="39d14-218">パッケージ マニフェスト</span><span class="sxs-lookup"><span data-stu-id="39d14-218">Package manifest</span></span>](#manifest-params)
* [<span data-ttu-id="39d14-219">クリーンアップ</span><span class="sxs-lookup"><span data-stu-id="39d14-219">Cleanup</span></span>](#cleanup-params)
* [<span data-ttu-id="39d14-220">アーキテクチャ</span><span class="sxs-lookup"><span data-stu-id="39d14-220">Architecture</span></span>](#architecture-params)
* [<span data-ttu-id="39d14-221">その他</span><span class="sxs-lookup"><span data-stu-id="39d14-221">Miscellaneous</span></span>](#other-params)

<span data-ttu-id="39d14-222">アプリ コンソール ウィンドウで ``Get-Help`` コマンドを実行して完全な一覧を表示することもできます。</span><span class="sxs-lookup"><span data-stu-id="39d14-222">You can also view the entire list by running the ``Get-Help`` command in the app console window.</span></span>   

||||
|-------------|-----------|-------------|
|<span data-ttu-id="39d14-223"><a id="setup-params" /> <strong>セットアップ パラメーター</strong></span><span class="sxs-lookup"><span data-stu-id="39d14-223"><a id="setup-params" /> <strong>Setup parameters</strong></span></span>  ||
|<span data-ttu-id="39d14-224">-Setup [&lt;SwitchParameter&gt;]</span><span class="sxs-lookup"><span data-stu-id="39d14-224">-Setup [&lt;SwitchParameter&gt;]</span></span> |<span data-ttu-id="39d14-225">必須</span><span class="sxs-lookup"><span data-stu-id="39d14-225">Required</span></span> |<span data-ttu-id="39d14-226">セットアップ モードで DesktopAppConverter を実行します。</span><span class="sxs-lookup"><span data-stu-id="39d14-226">Runs DesktopAppConverter in setup mode.</span></span> <span data-ttu-id="39d14-227">セットアップ モードでは、用意されている基本イメージの展開をサポートします。</span><span class="sxs-lookup"><span data-stu-id="39d14-227">Setup mode supports expanding a provided base image.</span></span>|
|<span data-ttu-id="39d14-228">-BaseImage &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="39d14-228">-BaseImage &lt;String&gt;</span></span> | <span data-ttu-id="39d14-229">必須</span><span class="sxs-lookup"><span data-stu-id="39d14-229">Required</span></span> |<span data-ttu-id="39d14-230">展開されていない基本イメージの完全パス。</span><span class="sxs-lookup"><span data-stu-id="39d14-230">Full path to an unexpanded base image.</span></span> <span data-ttu-id="39d14-231">このパラメーターは、-Setup を指定する場合に必要です。</span><span class="sxs-lookup"><span data-stu-id="39d14-231">This parameter is required if -Setup is specified.</span></span>|
| <span data-ttu-id="39d14-232">-LogFile &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="39d14-232">-LogFile &lt;String&gt;</span></span> |<span data-ttu-id="39d14-233">省略可能</span><span class="sxs-lookup"><span data-stu-id="39d14-233">Optional</span></span> |<span data-ttu-id="39d14-234">ログ ファイルを指定します。</span><span class="sxs-lookup"><span data-stu-id="39d14-234">Specifies a log file.</span></span> <span data-ttu-id="39d14-235">省略した場合は、ログ ファイルの一時的な場所が作成されます。</span><span class="sxs-lookup"><span data-stu-id="39d14-235">If omitted, a log file temporary location will be created.</span></span>|
|<span data-ttu-id="39d14-236">-NatSubnetPrefix &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="39d14-236">-NatSubnetPrefix &lt;String&gt;</span></span> |<span data-ttu-id="39d14-237">省略可能</span><span class="sxs-lookup"><span data-stu-id="39d14-237">Optional</span></span> |<span data-ttu-id="39d14-238">Nat インスタンスで使うプレフィックス値。</span><span class="sxs-lookup"><span data-stu-id="39d14-238">Prefix value to be used for the Nat instance.</span></span> <span data-ttu-id="39d14-239">通常この値は、ホスト コンピューターがコンバーターの NetNat と同じサブネット範囲に割り当てられている場合にのみ変更します。</span><span class="sxs-lookup"><span data-stu-id="39d14-239">Typically, you would want to change this only if your host machine is attached to the same subnet range as the converter's NetNat.</span></span> <span data-ttu-id="39d14-240">現在のコンバーターの NetNat 構成は **Get NetNat** コマンドレットを使って照会できます。</span><span class="sxs-lookup"><span data-stu-id="39d14-240">You can query the current converter NetNat config by using the **Get-NetNat** cmdlet.</span></span> |
|<span data-ttu-id="39d14-241">-NoRestart [&lt;SwitchParameter&gt;]</span><span class="sxs-lookup"><span data-stu-id="39d14-241">-NoRestart [&lt;SwitchParameter&gt;]</span></span> |<span data-ttu-id="39d14-242">必須</span><span class="sxs-lookup"><span data-stu-id="39d14-242">Required</span></span> |<span data-ttu-id="39d14-243">セットアップの実行中に再起動を要求しません (コンテナー機能を有効にするには再起動が必要です)。</span><span class="sxs-lookup"><span data-stu-id="39d14-243">Don't prompt for reboot when running setup (reboot is required to enable the container feature).</span></span> |
|<span data-ttu-id="39d14-244"><a id="conversion-params" /> <strong>変換パラメーター</strong></span><span class="sxs-lookup"><span data-stu-id="39d14-244"><a id="conversion-params" /> <strong>Conversion parameters</strong></span></span>|||
|<span data-ttu-id="39d14-245">-AppInstallPath &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="39d14-245">-AppInstallPath &lt;String&gt;</span></span>  |<span data-ttu-id="39d14-246">省略可能</span><span class="sxs-lookup"><span data-stu-id="39d14-246">Optional</span></span> |<span data-ttu-id="39d14-247">インストール済みのファイルに対応する、アプリケーションのルート フォルダーの完全パス (インストールされている場合)。"C:\Program Files (x86)\MyApp" など。</span><span class="sxs-lookup"><span data-stu-id="39d14-247">The full path to your application's root folder for the installed files if it were installed (e.g., "C:\Program Files (x86)\MyApp").</span></span>|
|<span data-ttu-id="39d14-248">-Destination &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="39d14-248">-Destination &lt;String&gt;</span></span> |<span data-ttu-id="39d14-249">必須</span><span class="sxs-lookup"><span data-stu-id="39d14-249">Required</span></span> |<span data-ttu-id="39d14-250">コンバーターの appx を出力する場所。この場所がまだ存在しない場合は、DesktopAppConverter によって作成されます。</span><span class="sxs-lookup"><span data-stu-id="39d14-250">The desired destination for the converter's appx output - DesktopAppConverter can create this location if it doesn't already exist.</span></span>|
|<span data-ttu-id="39d14-251">-Installer &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="39d14-251">-Installer &lt;String&gt;</span></span> |<span data-ttu-id="39d14-252">必須</span><span class="sxs-lookup"><span data-stu-id="39d14-252">Required</span></span> |<span data-ttu-id="39d14-253">アプリケーションのインストーラーのパス。無人/サイレント モードで実行できるようにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="39d14-253">The path to the installer for your application - must be able to run unattended/silently.</span></span> <span data-ttu-id="39d14-254">No インストーラー変換では、これは、アプリケーション ファイルのルート ディレクトリのパスです。</span><span class="sxs-lookup"><span data-stu-id="39d14-254">No-installer conversion, this is the path to the root directory of your application files.</span></span> |
|<span data-ttu-id="39d14-255">-InstallerArguments &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="39d14-255">-InstallerArguments &lt;String&gt;</span></span> |<span data-ttu-id="39d14-256">省略可能</span><span class="sxs-lookup"><span data-stu-id="39d14-256">Optional</span></span> |<span data-ttu-id="39d14-257">インストーラーに無人/サイレント モードでの実行を強制する引数の文字列、またはコンマ区切り一覧。</span><span class="sxs-lookup"><span data-stu-id="39d14-257">A comma-separated list or string of arguments to force your installer to run unattended/silently.</span></span> <span data-ttu-id="39d14-258">インストーラーが msi の場合は、このパラメーターは省略可能です。</span><span class="sxs-lookup"><span data-stu-id="39d14-258">This parameter is optional if your installer is an msi.</span></span> <span data-ttu-id="39d14-259">インストーラーからログを取得するには、ここで、インストーラーのログ記録の引数を指定し、パス &lt;log_folder&gt; (コンバーターが適切なパスに置換するトークン) を使います。</span><span class="sxs-lookup"><span data-stu-id="39d14-259">To get a log from your installer, supply the logging argument for the installer here and use the path &lt;log_folder&gt;, which is a token that the converter replaces with the appropriate path.</span></span> <br><br><span data-ttu-id="39d14-260">**注**:サイレント/無人のフラグとログ引数インストーラー テクノロジによって異なります。</span><span class="sxs-lookup"><span data-stu-id="39d14-260">**NOTE**: The unattended/silent flags and log arguments will vary between installer technologies.</span></span> <br><br><span data-ttu-id="39d14-261">このパラメーターの使用例: - InstallerArguments"/silent/log &lt;log_folder&gt;\install.log"ログ ファイルを生成しない別の例のようになります。```-InstallerArguments "/quiet", "/norestart"``` ここでも、する指示する必要が文字どおりトークンのパスにログがあれば&lt;log_folder&gt;する場合はそれをキャプチャし、最後のログ フォルダーに配置するコンバーター。</span><span class="sxs-lookup"><span data-stu-id="39d14-261">An example usage for this parameter: -InstallerArguments "/silent /log &lt;log_folder&gt;\install.log" Another example that doesn't produce a log file may look like: ```-InstallerArguments "/quiet", "/norestart"``` Again, you must literally direct any logs to the token path &lt;log_folder&gt; if you want the converter to capture it and put it in the final log folder.</span></span>|
|<span data-ttu-id="39d14-262">-InstallerValidExitCodes &lt;Int32&gt;</span><span class="sxs-lookup"><span data-stu-id="39d14-262">-InstallerValidExitCodes &lt;Int32&gt;</span></span> |<span data-ttu-id="39d14-263">省略可能</span><span class="sxs-lookup"><span data-stu-id="39d14-263">Optional</span></span> |<span data-ttu-id="39d14-264">インストーラーを示す終了コードのコンマ区切りの一覧が正常に実行 (例。0, 1234, 5678).</span><span class="sxs-lookup"><span data-stu-id="39d14-264">A comma-separated list of exit codes that indicate your installer ran successfully (for example: 0, 1234, 5678).</span></span>  <span data-ttu-id="39d14-265">既定では、非 msi は 0、msi は 0, 1641, 3010 です。</span><span class="sxs-lookup"><span data-stu-id="39d14-265">By default this is 0 for non-msi, and 0, 1641, 3010 for msi.</span></span>|
|<span data-ttu-id="39d14-266">-MakeAppx [&lt;SwitchParameter&gt;]</span><span class="sxs-lookup"><span data-stu-id="39d14-266">-MakeAppx [&lt;SwitchParameter&gt;]</span></span>  |<span data-ttu-id="39d14-267">省略可能</span><span class="sxs-lookup"><span data-stu-id="39d14-267">Optional</span></span> |<span data-ttu-id="39d14-268">このスクリプトに出力で MakeAppx を呼び出すように指示するスイッチ (存在する場合)。</span><span class="sxs-lookup"><span data-stu-id="39d14-268">A switch that, when present, tells this script to call MakeAppx on the output.</span></span> |
|<span data-ttu-id="39d14-269">-MakeMSIX [&lt;SwitchParameter&gt;]</span><span class="sxs-lookup"><span data-stu-id="39d14-269">-MakeMSIX [&lt;SwitchParameter&gt;]</span></span>  |<span data-ttu-id="39d14-270">省略可能</span><span class="sxs-lookup"><span data-stu-id="39d14-270">Optional</span></span> |<span data-ttu-id="39d14-271">存在する場合、MSIX パッケージとして出力をパッケージ化するには、このスクリプトに指示するスイッチ。</span><span class="sxs-lookup"><span data-stu-id="39d14-271">A switch that, when present, tells this script to package the output as an MSIX Package.</span></span> |
|<span data-ttu-id="39d14-272"><a id="identity-params" /><strong>パッケージの id パラメーター</strong></span><span class="sxs-lookup"><span data-stu-id="39d14-272"><a id="identity-params" /><strong>Package identity parameters</strong></span></span>||
|<span data-ttu-id="39d14-273">-PackageName &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="39d14-273">-PackageName &lt;String&gt;</span></span> |<span data-ttu-id="39d14-274">必須</span><span class="sxs-lookup"><span data-stu-id="39d14-274">Required</span></span> |<span data-ttu-id="39d14-275">ユニバーサル Windows アプリ パッケージの名前。</span><span class="sxs-lookup"><span data-stu-id="39d14-275">The name of your Universal Windows App package.</span></span> <span data-ttu-id="39d14-276">パートナー センターによって id が数字で始まる場合、パッケージに割り当てられる場合に渡すことも確認、 <i>- AppId</i>パラメーター、およびそのパラメーターの値としては、(後にピリオドを区切り文字) 文字列サフィックスのみを使用します。</span><span class="sxs-lookup"><span data-stu-id="39d14-276">If Partner Center assigns an identity to your package that begins with a number, make sure that you also pass in the <i>-AppId</i> parameter, and use only the string suffix (after the period separator) as the value of that parameter.</span></span> |
|<span data-ttu-id="39d14-277">-Publisher &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="39d14-277">-Publisher &lt;String&gt;</span></span> |<span data-ttu-id="39d14-278">必須</span><span class="sxs-lookup"><span data-stu-id="39d14-278">Required</span></span> |<span data-ttu-id="39d14-279">ユニバーサル Windows アプリ パッケージの発行元</span><span class="sxs-lookup"><span data-stu-id="39d14-279">The publisher of your Universal Windows App package</span></span> |
|<span data-ttu-id="39d14-280">-Version &lt;Version&gt;</span><span class="sxs-lookup"><span data-stu-id="39d14-280">-Version &lt;Version&gt;</span></span> |<span data-ttu-id="39d14-281">必須</span><span class="sxs-lookup"><span data-stu-id="39d14-281">Required</span></span> |<span data-ttu-id="39d14-282">ユニバーサル Windows アプリ パッケージのバージョン番号</span><span class="sxs-lookup"><span data-stu-id="39d14-282">The version number for your Universal Windows App package</span></span> |
|<span data-ttu-id="39d14-283"><a id="manifest-params" /><strong>パッケージ マニフェストのパラメーター</strong></span><span class="sxs-lookup"><span data-stu-id="39d14-283"><a id="manifest-params" /><strong>Package manifest parameters</strong></span></span>||
|<span data-ttu-id="39d14-284">-AppExecutable &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="39d14-284">-AppExecutable &lt;String&gt;</span></span> |<span data-ttu-id="39d14-285">省略可能</span><span class="sxs-lookup"><span data-stu-id="39d14-285">Optional</span></span> |<span data-ttu-id="39d14-286">アプリケーションのメインの実行可能ファイルの名前 (例:"MyApp.exe")。</span><span class="sxs-lookup"><span data-stu-id="39d14-286">The name of your application's main executable (eg "MyApp.exe").</span></span> <span data-ttu-id="39d14-287">インストーラーを使用しない変換では、このパラメーターは必須です。</span><span class="sxs-lookup"><span data-stu-id="39d14-287">This parameter is required for a no-installer conversion.</span></span> |
|<span data-ttu-id="39d14-288">-AppFileTypes &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="39d14-288">-AppFileTypes &lt;String&gt;</span></span>|<span data-ttu-id="39d14-289">省略可能</span><span class="sxs-lookup"><span data-stu-id="39d14-289">Optional</span></span> |<span data-ttu-id="39d14-290">アプリケーションに関連付ける、ファイルの種類のコンマ区切りの一覧。</span><span class="sxs-lookup"><span data-stu-id="39d14-290">A comma-separated list of file types which the application will be associated with.</span></span> <span data-ttu-id="39d14-291">使用例: -AppFileTypes "'.md', '.markdown'"。</span><span class="sxs-lookup"><span data-stu-id="39d14-291">Example usage: -AppFileTypes "'.md', '.markdown'".</span></span>|
|<span data-ttu-id="39d14-292">-AppId &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="39d14-292">-AppId &lt;String&gt;</span></span> |<span data-ttu-id="39d14-293">省略可能</span><span class="sxs-lookup"><span data-stu-id="39d14-293">Optional</span></span> |<span data-ttu-id="39d14-294">Windows アプリ パッケージ マニフェストでアプリケーション ID を設定する値を指定します。</span><span class="sxs-lookup"><span data-stu-id="39d14-294">Specifies a value to set Application Id to in the Windows app package manifest.</span></span> <span data-ttu-id="39d14-295">指定しなかった場合は、*PackageName* で渡した値が設定されます。</span><span class="sxs-lookup"><span data-stu-id="39d14-295">If it is not specified, it will be set to the value passed in for *PackageName*.</span></span> <span data-ttu-id="39d14-296">多くの場合、*PackageName* を使って問題ありません。</span><span class="sxs-lookup"><span data-stu-id="39d14-296">In many cases, using the *PackageName* is fine.</span></span> <span data-ttu-id="39d14-297">ただし、パートナー センターでは、id を数字で始まる場合、パッケージに割り当てられる場合、確認で渡すことも、 <i>- AppId</i>パラメーター、およびそのパラメーターの値としては、(後にピリオドを区切り文字) 文字列サフィックスのみを使用します。</span><span class="sxs-lookup"><span data-stu-id="39d14-297">However, if Partner Center assigns an identity to your package that begins with a number, make sure that you also pass in the <i>-AppId</i> parameter, and use only the string suffix (after the period separator) as the value of that parameter.</span></span> |
|<span data-ttu-id="39d14-298">-AppDisplayName &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="39d14-298">-AppDisplayName &lt;String&gt;</span></span>  |<span data-ttu-id="39d14-299">省略可能</span><span class="sxs-lookup"><span data-stu-id="39d14-299">Optional</span></span> |<span data-ttu-id="39d14-300">Windows アプリ パッケージ マニフェストでアプリケーションの表示名を設定する値を指定します。</span><span class="sxs-lookup"><span data-stu-id="39d14-300">Specifies a value to set Application Display Name to in the Windows app package manifest.</span></span> <span data-ttu-id="39d14-301">指定しなかった場合は、*PackageName* で渡した値が設定されます。</span><span class="sxs-lookup"><span data-stu-id="39d14-301">If it is not specified, it will be set to the value passed in for *PackageName*.</span></span> |
|<span data-ttu-id="39d14-302">-AppDescription &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="39d14-302">-AppDescription &lt;String&gt;</span></span> |<span data-ttu-id="39d14-303">省略可能</span><span class="sxs-lookup"><span data-stu-id="39d14-303">Optional</span></span> |<span data-ttu-id="39d14-304">Windows アプリ パッケージ マニフェストでアプリケーションの説明を設定する値を指定します。</span><span class="sxs-lookup"><span data-stu-id="39d14-304">Specifies a value to set Application Description to in the Windows app package manifest.</span></span> <span data-ttu-id="39d14-305">指定しなかった場合は、*PackageName* で渡した値が設定されます。</span><span class="sxs-lookup"><span data-stu-id="39d14-305">If it is not specified, it will be set to the value passed in for *PackageName*.</span></span>|
|<span data-ttu-id="39d14-306">-PackageDisplayName &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="39d14-306">-PackageDisplayName &lt;String&gt;</span></span> |<span data-ttu-id="39d14-307">省略可能</span><span class="sxs-lookup"><span data-stu-id="39d14-307">Optional</span></span> |<span data-ttu-id="39d14-308">Windows アプリ パッケージ マニフェストでパッケージの表示名を設定する値を指定します。</span><span class="sxs-lookup"><span data-stu-id="39d14-308">Specifies a value to set Package Display Name to in the Windows app package manifest.</span></span> <span data-ttu-id="39d14-309">指定しなかった場合は、*PackageName* で渡した値が設定されます。</span><span class="sxs-lookup"><span data-stu-id="39d14-309">If it is not specified, it will be set to the value passed in for *PackageName*.</span></span> |
|<span data-ttu-id="39d14-310">-PackagePublisherDisplayName &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="39d14-310">-PackagePublisherDisplayName &lt;String&gt;</span></span> |<span data-ttu-id="39d14-311">省略可能</span><span class="sxs-lookup"><span data-stu-id="39d14-311">Optional</span></span> |<span data-ttu-id="39d14-312">Windows アプリ パッケージ マニフェストでパッケージ発行元の表示名を設定する値を指定します。</span><span class="sxs-lookup"><span data-stu-id="39d14-312">Specifies a value to set Package Publisher Display Name to in the Windows app package manifest.</span></span> <span data-ttu-id="39d14-313">指定しないと、*Publisher* で渡した値が設定されます。</span><span class="sxs-lookup"><span data-stu-id="39d14-313">If it is not specified, it will be set to the value passed in for *Publisher*.</span></span> |
|<span data-ttu-id="39d14-314"><a id="cleanup-params" /><strong>クリーンアップ パラメーター</strong></span><span class="sxs-lookup"><span data-stu-id="39d14-314"><a id="cleanup-params" /><strong>Cleanup parameters</strong></span></span>|||
|<span data-ttu-id="39d14-315">-Cleanup [&lt;Option&gt;]</span><span class="sxs-lookup"><span data-stu-id="39d14-315">-Cleanup [&lt;Option&gt;]</span></span> |<span data-ttu-id="39d14-316">必須</span><span class="sxs-lookup"><span data-stu-id="39d14-316">Required</span></span> |<span data-ttu-id="39d14-317">DesktopAppConverter の成果物のクリーンアップを実行します。</span><span class="sxs-lookup"><span data-stu-id="39d14-317">Runs cleanup for the DesktopAppConverter artifacts.</span></span> <span data-ttu-id="39d14-318">クリーンアップ モードには 3 つの有効なオプションがあります。</span><span class="sxs-lookup"><span data-stu-id="39d14-318">There are 3 valid options for the Cleanup mode.</span></span> |
|<span data-ttu-id="39d14-319">-Cleanup All</span><span class="sxs-lookup"><span data-stu-id="39d14-319">-Cleanup All</span></span> | |<span data-ttu-id="39d14-320">展開済みのすべての基本イメージを削除し、コンバーターのすべての一時ファイルを削除します。コンテナーのネットワークを削除し、Windows のオプション機能、コンテナーを無効にします。</span><span class="sxs-lookup"><span data-stu-id="39d14-320">Deletes all expanded base images, removes any temporary converter files, removes the container network, and disables the optional Windows feature, Containers.</span></span> |
|<span data-ttu-id="39d14-321">-Cleanup WorkDirectory</span><span class="sxs-lookup"><span data-stu-id="39d14-321">-Cleanup WorkDirectory</span></span> |<span data-ttu-id="39d14-322">必須</span><span class="sxs-lookup"><span data-stu-id="39d14-322">Required</span></span> |<span data-ttu-id="39d14-323">コンバーターのすべての一時ファイルを削除します。</span><span class="sxs-lookup"><span data-stu-id="39d14-323">Removes all the temporary converter files.</span></span> |
|<span data-ttu-id="39d14-324">-Cleanup ExpandedImage</span><span class="sxs-lookup"><span data-stu-id="39d14-324">-Cleanup ExpandedImage</span></span> |<span data-ttu-id="39d14-325">必須</span><span class="sxs-lookup"><span data-stu-id="39d14-325">Required</span></span> |<span data-ttu-id="39d14-326">ホスト コンピューターにインストールされているすべての展開済みの基本イメージを削除します。</span><span class="sxs-lookup"><span data-stu-id="39d14-326">Deletes all the expanded base images installed on your host machine.</span></span> |
|<span data-ttu-id="39d14-327"><a id="architecture-params" /><strong>パッケージ アーキテクチャ パラメーター</strong></span><span class="sxs-lookup"><span data-stu-id="39d14-327"><a id="architecture-params" /><strong>Package architecture parameters</strong></span></span>|||
|<span data-ttu-id="39d14-328">-PackageArch &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="39d14-328">-PackageArch &lt;String&gt;</span></span> |<span data-ttu-id="39d14-329">必須</span><span class="sxs-lookup"><span data-stu-id="39d14-329">Required</span></span> |<span data-ttu-id="39d14-330">指定したアーキテクチャのパッケージを生成します。</span><span class="sxs-lookup"><span data-stu-id="39d14-330">Generates a package with the specified architecture.</span></span> <span data-ttu-id="39d14-331">有効なオプションは、'x86' または 'x64' です。たとえば、-PackageArch x86 のように指定します。</span><span class="sxs-lookup"><span data-stu-id="39d14-331">Valid options are 'x86' or 'x64'; for example, -PackageArch x86.</span></span> <span data-ttu-id="39d14-332">このパラメーターは省略可能です。</span><span class="sxs-lookup"><span data-stu-id="39d14-332">This parameter is optional.</span></span> <span data-ttu-id="39d14-333">指定されていない場合、DesktopAppConverter はパッケージのアーキテクチャの自動検出を試みます。</span><span class="sxs-lookup"><span data-stu-id="39d14-333">If unspecified, the DesktopAppConverter will try to auto-detect package architecture.</span></span> <span data-ttu-id="39d14-334">自動検出に失敗した場合、既定値は x64 パッケージです。</span><span class="sxs-lookup"><span data-stu-id="39d14-334">If auto-detection fails, it will default to x64 package.</span></span> |
|<span data-ttu-id="39d14-335"><a id="other-params" /><strong>その他のパラメーター</strong></span><span class="sxs-lookup"><span data-stu-id="39d14-335"><a id="other-params" /><strong>Miscellaneous parameters</strong></span></span>|||
|<span data-ttu-id="39d14-336">-ExpandedBaseImage &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="39d14-336">-ExpandedBaseImage &lt;String&gt;</span></span>  |<span data-ttu-id="39d14-337">省略可能</span><span class="sxs-lookup"><span data-stu-id="39d14-337">Optional</span></span> |<span data-ttu-id="39d14-338">既に展開済みの基本イメージの完全パス。</span><span class="sxs-lookup"><span data-stu-id="39d14-338">Full path to an already expanded base image.</span></span>|
|<span data-ttu-id="39d14-339">-LogFile &lt;String&gt;</span><span class="sxs-lookup"><span data-stu-id="39d14-339">-LogFile &lt;String&gt;</span></span>  |<span data-ttu-id="39d14-340">省略可能</span><span class="sxs-lookup"><span data-stu-id="39d14-340">Optional</span></span> |<span data-ttu-id="39d14-341">ログ ファイルを指定します。</span><span class="sxs-lookup"><span data-stu-id="39d14-341">Specifies a log file.</span></span> <span data-ttu-id="39d14-342">省略した場合は、ログ ファイルの一時的な場所が作成されます。</span><span class="sxs-lookup"><span data-stu-id="39d14-342">If omitted, a log file temporary location will be created.</span></span> |
| <span data-ttu-id="39d14-343">-Sign [&lt;SwitchParameter&gt;]</span><span class="sxs-lookup"><span data-stu-id="39d14-343">-Sign [&lt;SwitchParameter&gt;]</span></span> |<span data-ttu-id="39d14-344">省略可能</span><span class="sxs-lookup"><span data-stu-id="39d14-344">Optional</span></span> |<span data-ttu-id="39d14-345">出力する Windows アプリ パッケージに、テスト用に生成された証明書を使用して署名するようにこのスクリプトに指示します。</span><span class="sxs-lookup"><span data-stu-id="39d14-345">Tells this script to sign the output Windows app package by using a generated certificate for testing purposes.</span></span> <span data-ttu-id="39d14-346">このスイッチは、```-MakeAppx``` スイッチと共に含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="39d14-346">This switch should be present alongside the switch ```-MakeAppx```.</span></span> |
|<span data-ttu-id="39d14-347">&lt;共通パラメーター&gt;</span><span class="sxs-lookup"><span data-stu-id="39d14-347">&lt;Common parameters&gt;</span></span> |<span data-ttu-id="39d14-348">必須</span><span class="sxs-lookup"><span data-stu-id="39d14-348">Required</span></span> |<span data-ttu-id="39d14-349">このコマンドレットでは、*詳細な*、*デバッグ*、 *ErrorAction*、 *ErrorVariable*、 *WarningAction*、 *WarningVariable*、 *OutBuffer*、 *PipelineVariable*、および*OutVariable*します。</span><span class="sxs-lookup"><span data-stu-id="39d14-349">This cmdlet supports the common parameters: *Verbose*, *Debug*, *ErrorAction*, *ErrorVariable*, *WarningAction*, *WarningVariable*, *OutBuffer*, *PipelineVariable*, and *OutVariable*.</span></span> <span data-ttu-id="39d14-350">詳細については、「[about_CommonParameters](https://go.microsoft.com/fwlink/?LinkID=113216)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="39d14-350">For more info, see [about_CommonParameters](https://go.microsoft.com/fwlink/?LinkID=113216).</span></span> |
| <span data-ttu-id="39d14-351">-Verify [&lt;SwitchParameter&gt;]</span><span class="sxs-lookup"><span data-stu-id="39d14-351">-Verify [&lt;SwitchParameter&gt;]</span></span> |<span data-ttu-id="39d14-352">省略可能</span><span class="sxs-lookup"><span data-stu-id="39d14-352">Optional</span></span> |<span data-ttu-id="39d14-353">存在する場合は、パッケージ アプリと Microsoft Store の要件に対してアプリ パッケージを検証する DAC を通知するスイッチ。</span><span class="sxs-lookup"><span data-stu-id="39d14-353">A switch that, when present, tells the DAC to validate the app package against packaged app and Microsoft Store requirements.</span></span> <span data-ttu-id="39d14-354">結果は、検証レポート "VerifyReport.xml" で、ブラウザーでの視覚化に最適です。</span><span class="sxs-lookup"><span data-stu-id="39d14-354">The result is a validation report "VerifyReport.xml", which is best visualized in a browser.</span></span> <span data-ttu-id="39d14-355">このスイッチは、`-MakeAppx` スイッチと共に含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="39d14-355">This switch should be present alongside the switch `-MakeAppx`.</span></span> |
|<span data-ttu-id="39d14-356">-PublishComRegistrations</span><span class="sxs-lookup"><span data-stu-id="39d14-356">-PublishComRegistrations</span></span>| <span data-ttu-id="39d14-357">省略可能</span><span class="sxs-lookup"><span data-stu-id="39d14-357">Optional</span></span>| <span data-ttu-id="39d14-358">インストーラーによって行われたすべての パブリック COM 登録をスキャンし、有効な登録をマニフェストで公開します。</span><span class="sxs-lookup"><span data-stu-id="39d14-358">Scans all public COM registrations made by your installer and publishes the valid ones in your manifest.</span></span> <span data-ttu-id="39d14-359">このフラグは、これらの登録を他のアプリケーションで利用できるようにする場合にのみ使用してください。</span><span class="sxs-lookup"><span data-stu-id="39d14-359">Use this flag only if you want to make these registrations available to other applications.</span></span> <span data-ttu-id="39d14-360">これらの登録を対象アプリケーションでのみ使用する場合、このフラグを使用する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="39d14-360">You don't need to use this flag if these registrations will be used only by your application.</span></span> <br><br><span data-ttu-id="39d14-361">アプリをパッケージ化した後、正常に動作するように COM 登録を行うには、[こちらの記事](https://blogs.windows.com/buildingapps/2017/04/13/com-server-ole-document-support-desktop-bridge/#lDg5gSFxJ2TDlpC6.97)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="39d14-361">Review [this article](https://blogs.windows.com/buildingapps/2017/04/13/com-server-ole-document-support-desktop-bridge/#lDg5gSFxJ2TDlpC6.97) to make sure that your COM registrations behave as you expect after you package your app.</span></span>

<a id="run-app" />

## <a name="run-the-packaged-app"></a><span data-ttu-id="39d14-362">パッケージ アプリを実行する</span><span class="sxs-lookup"><span data-stu-id="39d14-362">Run the packaged app</span></span>

<span data-ttu-id="39d14-363">アプリを実行するには、2 種類の方法があります。</span><span class="sxs-lookup"><span data-stu-id="39d14-363">There's two ways to run your app.</span></span>

<span data-ttu-id="39d14-364">1 つ目は、PowerShell コマンド プロンプトを開いて、```Add-AppxPackage –Register AppxManifest.xml``` というコマンドを入力する方法です。</span><span class="sxs-lookup"><span data-stu-id="39d14-364">One way is to open a PowerShell command prompt, and then type this command: ```Add-AppxPackage –Register AppxManifest.xml```.</span></span> <span data-ttu-id="39d14-365">署名する必要がないために、アプリケーションを実行する最も簡単な方法です。</span><span class="sxs-lookup"><span data-stu-id="39d14-365">It's probably the easiest way to run your application because you don't have to sign it.</span></span>

<span data-ttu-id="39d14-366">別の方法では、証明書を使用してアプリケーションに署名します。</span><span class="sxs-lookup"><span data-stu-id="39d14-366">Another way is to sign your application with a certificate.</span></span> <span data-ttu-id="39d14-367">使用する場合、 ```sign``` Desktop App Converter のパラメーターは、1 つを生成し、それを使用してアプリケーションにサインインします。</span><span class="sxs-lookup"><span data-stu-id="39d14-367">If you use the ```sign``` parameter, the Desktop App Converter will generate one for you, and then sign your application with it.</span></span> <span data-ttu-id="39d14-368">その証明書ファイルは **auto-generated.cer** という名前になり、パッケージ アプリのルート フォルダーに配置されます。</span><span class="sxs-lookup"><span data-stu-id="39d14-368">That file is named **auto-generated.cer**, and you can find it in the root folder of your packaged app.</span></span>

<span data-ttu-id="39d14-369">生成された証明書をインストールし、アプリを実行するには、次の手順を実行します。</span><span class="sxs-lookup"><span data-stu-id="39d14-369">Follow these steps to install the generated certificate, and then run your app.</span></span>

1. <span data-ttu-id="39d14-370">**auto-generated.cer** ファイルをダブルクリックして証明書をインストールします。</span><span class="sxs-lookup"><span data-stu-id="39d14-370">Double-click the **auto-generated.cer** file to install the certificate.</span></span>

   ![生成された証明書ファイル](images/desktop-to-uwp/generated-cert-file.png)

   > [!NOTE]
   > <span data-ttu-id="39d14-372">パスワードを求められた場合は、既定のパスワード "123456" を使用します。</span><span class="sxs-lookup"><span data-stu-id="39d14-372">If you're prompted for a password, use the default password "123456".</span></span>

2. <span data-ttu-id="39d14-373">**[証明書]** ダイアログ ボックスで、**[証明書のインストール]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="39d14-373">In the **Certificate** dialog box, choose the **Install Certificate** button.</span></span>
3. <span data-ttu-id="39d14-374">**証明書インポート ウィザード**で、証明書を**ローカル コンピューター**にインストールし、証明書を "**信頼されたユーザー**" の証明書ストアに配置します。</span><span class="sxs-lookup"><span data-stu-id="39d14-374">In the **Certificate Import Wizard**, install the certificate onto the **Local Machine**, and place the certificate into the **Trusted People** certificate store.</span></span>

   ![信頼されたユーザー ストア](images/desktop-to-uwp/trusted-people-store.png)

5. <span data-ttu-id="39d14-376">パッケージ アプリのルート フォルダーで、Windows アプリのパッケージ ファイルをダブルクリックします。</span><span class="sxs-lookup"><span data-stu-id="39d14-376">In root folder of your packaged app, double click the Windows app package file.</span></span>

   ![Windows アプリのパッケージ ファイル](images/desktop-to-uwp/windows-app-package.png)

6. <span data-ttu-id="39d14-378">**[インストール]** を選択してアプリをインストールします。</span><span class="sxs-lookup"><span data-stu-id="39d14-378">Install the app, by choosing the **Install** button.</span></span>

   ![[インストール] ボタン](images/desktop-to-uwp/install.png)


## <a name="modify-the-packaged-app"></a><span data-ttu-id="39d14-380">パッケージ アプリを変更する</span><span class="sxs-lookup"><span data-stu-id="39d14-380">Modify the packaged app</span></span>

<span data-ttu-id="39d14-381">バグに対処、ビジュアルの資産を追加またはライブ タイルなどの最新のエクスペリエンスを使用してアプリケーションを強化をパッケージ化されたアプリケーションに変更を行います可能性があります。</span><span class="sxs-lookup"><span data-stu-id="39d14-381">You'll likely make changes to your packaged application to address bugs, add visual assets, or enhance your application with modern experiences such as live tiles.</span></span>

<span data-ttu-id="39d14-382">変更を加えた後、もう一度コンバーターを実行する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="39d14-382">After you make your changes, you don't need to run the converter again.</span></span> <span data-ttu-id="39d14-383">ほとんどの場合、MakeAppx ツールを使用してアプリケーションを再パッケージすることができますのみと、アプリの DAC appxmanifest.xml ファイルが生成されます。</span><span class="sxs-lookup"><span data-stu-id="39d14-383">In most cases, you can just repackage your application by using the MakeAppx tool and the appxmanifest.xml file the DAC generates for your app.</span></span> <span data-ttu-id="39d14-384">「[Windows アプリ パッケージを生成する](desktop-to-uwp-manual-conversion.md#make-appx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="39d14-384">See [Generate a Windows app package](desktop-to-uwp-manual-conversion.md#make-appx).</span></span>

* <span data-ttu-id="39d14-385">アプリのビジュアル アセットを変更する場合、新しいパッケージ リソース インデックス ファイルを生成し、MakeAppx ツールを実行して新しいパッケージを生成します。</span><span class="sxs-lookup"><span data-stu-id="39d14-385">If you modify any of the visual assets of your app, generate a new Package Resource Index file, and then run the MakeAppx tool to generate a new package.</span></span> <span data-ttu-id="39d14-386">「[パッケージ リソース インデックス (PRI) ファイルを生成する](desktop-to-uwp-manual-conversion.md#make-pri)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="39d14-386">See [Generate a Package Resource Index (PRI) file](desktop-to-uwp-manual-conversion.md#make-pri).</span></span>

* <span data-ttu-id="39d14-387">Windows タスク バー、タスク ビュー、スナップ アシスト、Alt + Tab キーを押したときの一覧、およびスタート画面のタイルの右下に表示されるアイコンおよびタイルを追加する場合は、「[(省略可能) ターゲット ベースのプレートなしのアセットを追加する](desktop-to-uwp-manual-conversion.md#target-based-assets)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="39d14-387">If you want to add icons or tiles that appear on the Windows taskbar, task view, LT+TAB, snap assist, and the lower right corner of Start tiles, see [(Optional Add Target-based unplated assets](desktop-to-uwp-manual-conversion.md#target-based-assets).</span></span>

> [!NOTE]
> <span data-ttu-id="39d14-388">インストーラーによるレジストリ設定を変更した場合は、その変更を適用するために、Desktop App Converter をもう一度実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="39d14-388">If you make changes to registry settings that your installer makes, you will have to run the Desktop App Converter again to pick up those changes.</span></span>

<span data-ttu-id="39d14-389">**動画**</span><span class="sxs-lookup"><span data-stu-id="39d14-389">**Videos**</span></span>

|<span data-ttu-id="39d14-390">出力の変更と再パッケージ化</span><span class="sxs-lookup"><span data-stu-id="39d14-390">Modify and repackage output</span></span> |<span data-ttu-id="39d14-391">デモ:出力の変更と再パッケージ化</span><span class="sxs-lookup"><span data-stu-id="39d14-391">Demo: Modify and repackage output</span></span>|
|---|---|
|<iframe src="https://mva.microsoft.com/en-US/training-courses-embed/developers-guide-to-the-desktop-bridge-17373/Video-Modifying-and-Repackaging-Output-from-Desktop-App-Converter-OwpAJ3WhD_6706218965" width="426" height="472" allowFullScreen frameBorder="0"></iframe>|<iframe src="https://mva.microsoft.com/en-US/training-courses-embed/developers-guide-to-the-desktop-bridge-17373/Demo-Modify-Output-from-Desktop-App-Converter-gEnsa3WhD_8606218965" width="426" height="472" allowFullScreen frameBorder="0"></iframe>|

<span data-ttu-id="39d14-392">次の 2 つのセクションでは、いくつかの可能性があるパッケージ化されたアプリケーションに省略可能なによる修正について説明します。</span><span class="sxs-lookup"><span data-stu-id="39d14-392">The following two sections describe a couple of optional fix-ups to the packaged application that you might consider.</span></span>

### <a name="delete-unnecessary-files-and-registry-keys"></a><span data-ttu-id="39d14-393">不要なファイルとレジストリ キーを削除する</span><span class="sxs-lookup"><span data-stu-id="39d14-393">Delete unnecessary files and registry keys</span></span>

<span data-ttu-id="39d14-394">Desktop App Converter は、コンテナー内のファイルとシステム ノイズの除去に、非常に保守的なアプローチを取ります。</span><span class="sxs-lookup"><span data-stu-id="39d14-394">The desktop App Converter takes a very conservative approach to filtering out files and system noise in the container.</span></span>

<span data-ttu-id="39d14-395">VFS フォルダーを確認し、インストーラーに必要ないファイルがあれば、削除することもできます。</span><span class="sxs-lookup"><span data-stu-id="39d14-395">If you want, you can review the VFS folder and delete any files that your installer doesn't need.</span></span>  <span data-ttu-id="39d14-396">また、Reg.dat の内容を確認し、アプリによってインストールされないキーや不要なキーがあれば、削除できます。</span><span class="sxs-lookup"><span data-stu-id="39d14-396">You can also review the contents of Reg.dat and delete any keys that are not installed/needed by the app.</span></span>

### <a name="fix-corrupted-pe-headers"></a><span data-ttu-id="39d14-397">破損した PEヘッダーを修正する</span><span class="sxs-lookup"><span data-stu-id="39d14-397">Fix corrupted PE headers</span></span>

<span data-ttu-id="39d14-398">DesktopAppConverter は 変換処理中に PEHeaderCertFixTool を自動的に実行し、破損している PEヘッダーを修正します。</span><span class="sxs-lookup"><span data-stu-id="39d14-398">During the conversion process, the DesktopAppConverter automatically runs the PEHeaderCertFixTool to fixup any corrupted PE headers.</span></span> <span data-ttu-id="39d14-399">ただし、UWP の Windows アプリ パッケージ、ルーズ ファイル、または特定のバイナリで、PEHeaderCertFixTool を実行することも可能です。</span><span class="sxs-lookup"><span data-stu-id="39d14-399">However, you can also run the PEHeaderCertFixTool on a UWP Windows app package, loose files, or a specific binary.</span></span> <span data-ttu-id="39d14-400">次に例を示します。</span><span class="sxs-lookup"><span data-stu-id="39d14-400">Here's an example.</span></span>

```CMD
PEHeaderCertFixTool.exe <binary file>|<.appx package>|<folder> [/c] [/v]
 /c   -- check for corrupted certificate but do not fix (optional)
 /v   -- verbose (optional)
example1: PEHeaderCertFixTool app.exe
example2: PEHeaderCertFixTool c:\package.appx /c
example3: PEHeaderCertFixTool c:\myapp /c /v
```

## <a name="telemetry-from-desktop-app-converter"></a><span data-ttu-id="39d14-401">Desktop App Converter の利用統計情報</span><span class="sxs-lookup"><span data-stu-id="39d14-401">Telemetry from Desktop App Converter</span></span>

<span data-ttu-id="39d14-402">Desktop App Converter は、ソフトウェアの使用者と使用方法に関する情報を収集して、この情報を Microsoft に送信することがあります。</span><span class="sxs-lookup"><span data-stu-id="39d14-402">Desktop App Converter may collect information about you and your use of the software and send this info to Microsoft.</span></span> <span data-ttu-id="39d14-403">Microsoft のデータ収集と製品ドキュメントでの使用の詳細については、「[マイクロソフトのプライバシーに関する声明](https://go.microsoft.com/fwlink/?LinkId=521839)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="39d14-403">You can learn more about Microsoft's data collection and use in the product documentation and in the [Microsoft Privacy Statement](https://go.microsoft.com/fwlink/?LinkId=521839).</span></span> <span data-ttu-id="39d14-404">お客様は、本ソフトウェアを使用することにより、マイクロソフトのプライバシーに関する声明のすべての適用規定を遵守することに同意したものと見なされます。</span><span class="sxs-lookup"><span data-stu-id="39d14-404">You agree to comply with all applicable provisions of the Microsoft Privacy Statement.</span></span>

<span data-ttu-id="39d14-405">既定では、Desktop App Converter の利用統計情報は有効にされています。</span><span class="sxs-lookup"><span data-stu-id="39d14-405">By default, telemetry will be enabled for the Desktop App Converter.</span></span> <span data-ttu-id="39d14-406">利用統計情報を目的の設定に構成するには、次のレジストリ キーを追加します。</span><span class="sxs-lookup"><span data-stu-id="39d14-406">Add the following registry key to configure telemetry to a desired setting:</span></span>  

```cmd
HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\DesktopAppConverter
```
+ <span data-ttu-id="39d14-407">DWORD を 1 に設定して、*DisableTelemetry* 値を追加または編集します。</span><span class="sxs-lookup"><span data-stu-id="39d14-407">Add or edit the *DisableTelemetry* value by using a DWORD set to 1.</span></span>
+ <span data-ttu-id="39d14-408">利用統計情報を有効にするには、このキーを削除するかキーの値を 0 に設定します。</span><span class="sxs-lookup"><span data-stu-id="39d14-408">To enable telemetry, remove the key or set the value to 0.</span></span>

### <a name="language-support"></a><span data-ttu-id="39d14-409">サポート言語</span><span class="sxs-lookup"><span data-stu-id="39d14-409">Language support</span></span>

<span data-ttu-id="39d14-410">Desktop App Converterは、Unicode をサポートしていません。したがって、漢字または非 ASCII 文字をツールで使用することはできません。</span><span class="sxs-lookup"><span data-stu-id="39d14-410">The Desktop App Converter does not support Unicode; thus, no Chinese characters or non-ASCII characters can be used with the tool.</span></span>

## <a name="next-steps"></a><span data-ttu-id="39d14-411">次のステップ</span><span class="sxs-lookup"><span data-stu-id="39d14-411">Next steps</span></span>

<span data-ttu-id="39d14-412">**質問の回答を検索**</span><span class="sxs-lookup"><span data-stu-id="39d14-412">**Find answers to your questions**</span></span>

<span data-ttu-id="39d14-413">ご質問がある場合は、</span><span class="sxs-lookup"><span data-stu-id="39d14-413">Have questions?</span></span> <span data-ttu-id="39d14-414">Stack Overflow でお問い合わせください。</span><span class="sxs-lookup"><span data-stu-id="39d14-414">Ask us on Stack Overflow.</span></span> <span data-ttu-id="39d14-415">Microsoft のチームでは、これらの[タグ](https://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge)をチェックしています。</span><span class="sxs-lookup"><span data-stu-id="39d14-415">Our team monitors these [tags](https://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge).</span></span> <span data-ttu-id="39d14-416">[こちら](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D)から質問することもできます。</span><span class="sxs-lookup"><span data-stu-id="39d14-416">You can also ask us [here](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D).</span></span>

<span data-ttu-id="39d14-417">[ここ](desktop-to-uwp-known-issues.md#app-converter)で既知の問題の一覧を確認することもできます。</span><span class="sxs-lookup"><span data-stu-id="39d14-417">You can also refer to [this](desktop-to-uwp-known-issues.md#app-converter) list of known issues.</span></span>

<span data-ttu-id="39d14-418">**ご意見や機能を提案します。**</span><span class="sxs-lookup"><span data-stu-id="39d14-418">**Give feedback or make feature suggestions**</span></span>

<span data-ttu-id="39d14-419">[UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial) のページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="39d14-419">See [UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial).</span></span>

<span data-ttu-id="39d14-420">**アプリケーションを実行/を検索し、問題を修正**</span><span class="sxs-lookup"><span data-stu-id="39d14-420">**Run your application / find and fix issues**</span></span>

<span data-ttu-id="39d14-421">参照してください[実行、デバッグ、およびデスクトップ アプリケーションをパッケージ化されたテスト](desktop-to-uwp-debug.md)</span><span class="sxs-lookup"><span data-stu-id="39d14-421">See [Run, debug, and test a packaged desktop application](desktop-to-uwp-debug.md)</span></span>

<span data-ttu-id="39d14-422">**アプリを配布します。**</span><span class="sxs-lookup"><span data-stu-id="39d14-422">**Distribute your app**</span></span>

<span data-ttu-id="39d14-423">参照してください[パッケージ化されたデスクトップ アプリケーションの配布](desktop-to-uwp-distribute.md)</span><span class="sxs-lookup"><span data-stu-id="39d14-423">See [Distribute a packaged desktop application](desktop-to-uwp-distribute.md)</span></span>
