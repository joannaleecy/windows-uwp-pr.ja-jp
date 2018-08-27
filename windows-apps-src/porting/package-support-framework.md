---
author: normesta
Description: Fix issues that prevent your desktop application from running in an MSIX container
Search.Product: eADQiWindows 10XVcnh
title: デスクトップ アプリケーションを MSIX コンテナーで実行できるようにする問題を修正します。
ms.author: normesta
ms.date: 07/02/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 46d5705233af9e8254b9ac89a2d6e9891e90701f
ms.sourcegitcommit: 753dfcd0f9fdfc963579dd0b217b445c4b110a18
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/27/2018
ms.locfileid: "2861259"
---
# <a name="apply-runtime-fixes-to-an-msix-package-by-using-the-package-support-framework"></a><span data-ttu-id="f8218-103">パッケージのサポート フレームワークを使用して MSIX パッケージにランタイムの修正プログラムを適用します。</span><span class="sxs-lookup"><span data-stu-id="f8218-103">Apply runtime fixes to an MSIX package by using the Package Support Framework</span></span>

<span data-ttu-id="f8218-104">パッケージのサポート フレームワークは MSIX コンテナーに実行できるように、ソース コードへのアクセスをしていない場合、既存の win32 アプリケーションに修正を適用することができるファイルを開くキットです。</span><span class="sxs-lookup"><span data-stu-id="f8218-104">The Package Support Framework is an open source kit that helps you apply fixes to your existing win32 application when you don't have access to the source code, so that it can run in an MSIX container.</span></span> <span data-ttu-id="f8218-105">パッケージのサポート フレームワークでは、アプリケーション モダンなランタイム環境のベスト プラクティスに従うことができます。</span><span class="sxs-lookup"><span data-stu-id="f8218-105">The Package Support Framework helps your application follow the best practices of the modern runtime environment.</span></span>

<span data-ttu-id="f8218-106">パッケージのサポート フレームワークを作成するには、Microsoft Research (MSR) が開発したファイルを開くフレームワーク API リダイレクションと接続でき[は](https://www.microsoft.com/en-us/research/project/detours)テクノロジを活用できます。</span><span class="sxs-lookup"><span data-stu-id="f8218-106">To create the Package Support Framework, we leveraged the [Detours](https://www.microsoft.com/en-us/research/project/detours) technology which is an open source framework developed by Microsoft Research (MSR) and helps with API redirection and hooking.</span></span>

<span data-ttu-id="f8218-107">このフレームワークがファイルを開く、軽量、アプリケーションの問題を解決する簡単に使用できます。</span><span class="sxs-lookup"><span data-stu-id="f8218-107">This framework is open source, lightweight, and you can use it to address application issues quickly.</span></span> <span data-ttu-id="f8218-108">他のユーザーの投資の一番上に作成して、世界のコミュニティに相談するには、営業案件も提供します。</span><span class="sxs-lookup"><span data-stu-id="f8218-108">It also gives you the opportunity to consult with the community around the globe, and to build on top of the investments of others.</span></span>

## <a name="a-quick-look-inside-of-the-package-support-framework"></a><span data-ttu-id="f8218-109">概要パッケージのサポート フレームワーク内</span><span class="sxs-lookup"><span data-stu-id="f8218-109">A quick look inside of the Package Support Framework</span></span>

<span data-ttu-id="f8218-110">パッケージのサポート フレームワークには、実行可能ファイル、ランタイム マネージャー DLL、一連の実行時の修正プログラムが含まれています。</span><span class="sxs-lookup"><span data-stu-id="f8218-110">The Package Support Framework contains an executable, a runtime manager  DLL, and a set of runtime fixes.</span></span>

![パッケージのサポート フレームワーク](images/desktop-to-uwp/package-support-framework.png)

<span data-ttu-id="f8218-112">しくみは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="f8218-112">Here's how it works.</span></span> <span data-ttu-id="f8218-113">アプリに適用する fix(s) を指定する構成ファイルを作成します。</span><span class="sxs-lookup"><span data-stu-id="f8218-113">You'll create a configuration file that specifies the fix(s) that you want to apply to your application.</span></span> <span data-ttu-id="f8218-114">次に、shim 起動ツールの実行可能ファイルを指すように、パッケージを変更してみましょう。</span><span class="sxs-lookup"><span data-stu-id="f8218-114">Then, you'll modify your package to point to the shim launcher executable file.</span></span>

<span data-ttu-id="f8218-115">ユーザーは、アプリケーションを起動、shim 起動ツールを実行している最初の実行可能ファイルです。</span><span class="sxs-lookup"><span data-stu-id="f8218-115">When users start your application, the shim launcher is the first executable that runs.</span></span> <span data-ttu-id="f8218-116">構成ファイルを読み取り、アプリケーションのプロセスにランタイム fix(s) とランタイム マネージャー DLL を挿入します。</span><span class="sxs-lookup"><span data-stu-id="f8218-116">It reads your configuration file, and injects the runtime fix(s) and the runtime manager  DLL into the application process.</span></span>

![パッケージのサポート Framework DLL の挿入](images/desktop-to-uwp/package-support-framework-2.png)

<span data-ttu-id="f8218-118">ランタイム マネージャーでは、アプリケーションを実行する MSIX コンテナー内では、必要に応じて、修正プログラムが適用されます。</span><span class="sxs-lookup"><span data-stu-id="f8218-118">The runtime manager applies the fix when it's needed by the application to run inside of an MSIX container.</span></span>

<span data-ttu-id="f8218-119">このガイドには、アプリケーションの互換性の問題を識別するため、検索、適用、および runtime を拡張するには、それらを解決するを修正する.</span><span class="sxs-lookup"><span data-stu-id="f8218-119">This guide will help you to identify application compatibility issues, and to find, apply, and extend runtime fixes that address them.</span></span>

<a id="identify" />

## <a name="identify-packaged-application-compatibility-issues"></a><span data-ttu-id="f8218-120">パッケージ アプリケーションの互換性の問題を特定します。</span><span class="sxs-lookup"><span data-stu-id="f8218-120">Identify packaged application compatibility issues</span></span>

<span data-ttu-id="f8218-121">最初に、アプリケーションのパッケージを作成します。</span><span class="sxs-lookup"><span data-stu-id="f8218-121">First, create a package for your application.</span></span> <span data-ttu-id="f8218-122">次に、インストール、実行し、その動作を確認します。</span><span class="sxs-lookup"><span data-stu-id="f8218-122">Then, install it, run it, and observe its behavior.</span></span> <span data-ttu-id="f8218-123">互換性の問題を特定するのに役立つエラー メッセージがあります。</span><span class="sxs-lookup"><span data-stu-id="f8218-123">You might receive error messages that can help you identify a compatibility issue.</span></span> <span data-ttu-id="f8218-124">問題を識別するのに[プロセス モニター](https://docs.microsoft.com/en-us/sysinternals/downloads/procmon)を使用することもできます。</span><span class="sxs-lookup"><span data-stu-id="f8218-124">You can also use [Process Monitor](https://docs.microsoft.com/en-us/sysinternals/downloads/procmon) to identify issues.</span></span>  <span data-ttu-id="f8218-125">一般的な問題は、作業ディレクトリおよびプログラム パスのアクセス許可に関するアプリケーションの前提条件に関連しています。</span><span class="sxs-lookup"><span data-stu-id="f8218-125">Common issues relate to application assumptions regarding the working directory and program path permissions.</span></span>

### <a name="using-process-monitor-to-identify-an-issue"></a><span data-ttu-id="f8218-126">プロセスのモニターを使用して、問題を識別するには</span><span class="sxs-lookup"><span data-stu-id="f8218-126">Using Process Monitor to identify an issue</span></span>

<span data-ttu-id="f8218-127">[モニターのプロセス](https://docs.microsoft.com/en-us/sysinternals/downloads/procmon)は、アプリのファイルと、レジストリ操作とその結果を調べるの強力なユーティリティです。</span><span class="sxs-lookup"><span data-stu-id="f8218-127">[Process Monitor](https://docs.microsoft.com/en-us/sysinternals/downloads/procmon) is a powerful utility for observing an app's file and registry operations, and their results.</span></span>  <span data-ttu-id="f8218-128">アプリケーションの互換性の問題を理解することができます。</span><span class="sxs-lookup"><span data-stu-id="f8218-128">This can help you to understand application compatibility issues.</span></span>  <span data-ttu-id="f8218-129">プロセス モニターを開いた後、フィルターを追加する (フィルター > フィルター]) から実行可能なアプリケーションのイベントのみを含めます。</span><span class="sxs-lookup"><span data-stu-id="f8218-129">After opening Process Monitor, add a filter (Filter > Filter…) to include only events from the application executable.</span></span>

![ProcMon アプリのフィルター](images/desktop-to-uwp/procmon_app_filter.png)

<span data-ttu-id="f8218-131">イベントの一覧が表示されます。</span><span class="sxs-lookup"><span data-stu-id="f8218-131">A list of events will appear.</span></span> <span data-ttu-id="f8218-132">これらのイベントの多くの単語**成功**を**結果**列に表示してされます。</span><span class="sxs-lookup"><span data-stu-id="f8218-132">For many of these events, the word **SUCCESS** will appear in the **Result** column.</span></span>

![ProcMon イベント](images/desktop-to-uwp/procmon_events.png)

<span data-ttu-id="f8218-134">必要に応じて、のみエラーだけを表示するイベントをフィルター処理できます。</span><span class="sxs-lookup"><span data-stu-id="f8218-134">Optionally, you can filter events to only show only failures.</span></span>

![成功の ProcMon を除外します。](images/desktop-to-uwp/procmon_exclude_success.png)

<span data-ttu-id="f8218-136">ファイル システムのアクセス エラーが疑われる場合は、System32/SysWOW64 またはパッケージ ファイル パスのいずれかの下にある失敗のイベントを検索します。</span><span class="sxs-lookup"><span data-stu-id="f8218-136">If you suspect a filesystem access failure, search for failed events that are under either the System32/SysWOW64 or the package file path.</span></span> <span data-ttu-id="f8218-137">フィルターも役立ちますここでは、すぎます。</span><span class="sxs-lookup"><span data-stu-id="f8218-137">Filters can also help here, too.</span></span> <span data-ttu-id="f8218-138">このリストの一番下にある起動し、上方向にスクロールします。</span><span class="sxs-lookup"><span data-stu-id="f8218-138">Start at the bottom of this list and scroll upwards.</span></span> <span data-ttu-id="f8218-139">このリストの下部に表示されるエラーが発生した最近します。</span><span class="sxs-lookup"><span data-stu-id="f8218-139">Failures that appear at the bottom of this list have occurred most recently.</span></span> <span data-ttu-id="f8218-140">「パスと名前は見つかりませんでした」、「アクセス拒否されると、」などの文字列を含むエラーをほとんど注意し、不審な外観がないことを無視します。</span><span class="sxs-lookup"><span data-stu-id="f8218-140">Pay most attention to errors that contain strings such as "access denied," and "path/name not found", and ignore things that don't look suspicious.</span></span> <span data-ttu-id="f8218-141">[PSFSample](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/samples/PSFSample/)には、次の 2 つの問題があります。</span><span class="sxs-lookup"><span data-stu-id="f8218-141">The [PSFSample](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/samples/PSFSample/) has two issues.</span></span> <span data-ttu-id="f8218-142">次の図に表示される一覧でこれらの問題が発生したことができます。</span><span class="sxs-lookup"><span data-stu-id="f8218-142">You can see those issues in the list that appears in the following image.</span></span>

![ProcMon Config.txt](images/desktop-to-uwp/procmon_config_txt.png)

<span data-ttu-id="f8218-144">このイメージに表示される最初の問題、アプリケーションは"C:\Windows\SysWOW64"パスに配置されている"Config.txt"ファイル内の参照に失敗します。</span><span class="sxs-lookup"><span data-stu-id="f8218-144">In the first issue that appears in this image, the application is failing to read from the "Config.txt" file that is located in the "C:\Windows\SysWOW64" path.</span></span> <span data-ttu-id="f8218-145">アプリケーションがパスを直接参照しようとしている可能性が高いことはできません。</span><span class="sxs-lookup"><span data-stu-id="f8218-145">It's unlikely that the application is trying to reference that path directly.</span></span> <span data-ttu-id="f8218-146">ほとんどの場合、パス、相対参照を使用して、そのファイルから読み取るしようとして"System32/SysWOW64"では既定では、アプリケーションの作業ディレクトリします。</span><span class="sxs-lookup"><span data-stu-id="f8218-146">Most likely, it's trying to read from that file by using a relative path, and by default, "System32/SysWOW64" is the application's working directory.</span></span> <span data-ttu-id="f8218-147">これは、アプリケーションがパッケージのどこかに設定する作業の現在のディレクトリを待っていることを示しています。</span><span class="sxs-lookup"><span data-stu-id="f8218-147">This suggests that the application is expecting its current working directory to be set to somewhere in the package.</span></span> <span data-ttu-id="f8218-148">[Appx 内を検索、ファイルが実行可能ファイルと同じディレクトリ内に存在することを確認できます。</span><span class="sxs-lookup"><span data-stu-id="f8218-148">Looking inside of the appx, we can see that the file exists in the same directory as the executable.</span></span>

![アプリ Config.txt](images/desktop-to-uwp/psfsampleapp_config_txt.png)

<span data-ttu-id="f8218-150">2 番目の問題は、次の図に表示されます。</span><span class="sxs-lookup"><span data-stu-id="f8218-150">The second issue appears in the following image.</span></span>

![ProcMon ログ ファイル](images/desktop-to-uwp/procmon_logfile.png)

<span data-ttu-id="f8218-152">この問題は、[パッケージ パス. log ファイルを作成するアプリケーションが失敗しています。</span><span class="sxs-lookup"><span data-stu-id="f8218-152">In this issue, the application is failing to write a .log file to its package path.</span></span> <span data-ttu-id="f8218-153">これにより、ファイルのリダイレクト shim が役立つ場合がありますがお勧めします。</span><span class="sxs-lookup"><span data-stu-id="f8218-153">This would suggest that a file redirection shim might help.</span></span>

<a id="find" />

## <a name="find-a-runtime-fix"></a><span data-ttu-id="f8218-154">実行時の修正プログラムを検索します。</span><span class="sxs-lookup"><span data-stu-id="f8218-154">Find a runtime fix</span></span>

<span data-ttu-id="f8218-155">[PSF には、ファイルのリダイレクト shim など、使用できるランタイム修正が含まれています。</span><span class="sxs-lookup"><span data-stu-id="f8218-155">The PSF contains runtime fixes that you can use right now, such as the file redirection shim.</span></span>

### <a name="file-redirection-shim"></a><span data-ttu-id="f8218-156">ファイルのリダイレクト Shim</span><span class="sxs-lookup"><span data-stu-id="f8218-156">File Redirection Shim</span></span>

<span data-ttu-id="f8218-157">書き込みまたは MSIX コンテナーで実行しているアプリケーションからアクセスすることのないディレクトリ内のデータを読み取る試みをリダイレクトするのには、[ファイルのリダイレクト Shim](https://github.com/Microsoft/MSIX-PackageSupportFramework/tree/develop/FileRedirectionShim)を使用できます。</span><span class="sxs-lookup"><span data-stu-id="f8218-157">You can use the [File Redirection Shim](https://github.com/Microsoft/MSIX-PackageSupportFramework/tree/develop/FileRedirectionShim) to redirect attempts to write or read data in a directory that isn't accessible from an application that runs in an MSIX container.</span></span>

<span data-ttu-id="f8218-158">たとえば場合は、アプリケーションは、実行可能アプリケーションと同じディレクトリ内にあるログ ファイルに書き込み、ローカルのアプリのデータ ストアなどの別の場所でそのログ ファイルを作成するのには[ファイル リダイレクション Shim](https://github.com/Microsoft/MSIX-PackageSupportFramework/tree/develop/FileRedirectionShim)を使用ことができます。</span><span class="sxs-lookup"><span data-stu-id="f8218-158">For example, if your application writes to a log file that is in the same directory as your applications executable, then you can use the [File Redirection Shim](https://github.com/Microsoft/MSIX-PackageSupportFramework/tree/develop/FileRedirectionShim) to create that log file in another location, such as the local app data store.</span></span>

### <a name="runtime-fixes-from-the-community"></a><span data-ttu-id="f8218-159">コミュニティからの実行時の修正</span><span class="sxs-lookup"><span data-stu-id="f8218-159">Runtime fixes from the community</span></span>

<span data-ttu-id="f8218-160">[GitHub](https://github.com/Microsoft/MSIX-PackageSupportFramework/tree/develop)ページにコミュニティ投稿を参照してください。</span><span class="sxs-lookup"><span data-stu-id="f8218-160">Make sure to review the community contributions to our [GitHub](https://github.com/Microsoft/MSIX-PackageSupportFramework/tree/develop) page.</span></span> <span data-ttu-id="f8218-161">他の開発者がにもかかわらず、自分のような問題が解決し、実行時の修正プログラムを共有している考えられます。</span><span class="sxs-lookup"><span data-stu-id="f8218-161">It's possible that other developers have resolved an issue similar to yours and have shared a runtime fix.</span></span>

## <a name="apply-a-runtime-fix"></a><span data-ttu-id="f8218-162">実行時の修正プログラムを適用します。</span><span class="sxs-lookup"><span data-stu-id="f8218-162">Apply a runtime fix</span></span>

<span data-ttu-id="f8218-163">Windows SDK し、次の手順では、いくつかの簡単なツールを使用して既存の実行時の修正を適用できます。</span><span class="sxs-lookup"><span data-stu-id="f8218-163">You can apply an existing runtime fix with a few simple tools from the Windows SDK, and by following these steps.</span></span>

> [!div class="checklist"]
> * <span data-ttu-id="f8218-164">パッケージのレイアウトのフォルダーを作成します。</span><span class="sxs-lookup"><span data-stu-id="f8218-164">Create a package layout folder</span></span>
> * <span data-ttu-id="f8218-165">パッケージのサポート フレームワーク ファイルを取得します。</span><span class="sxs-lookup"><span data-stu-id="f8218-165">Get the Package Support Framework files</span></span>
> * <span data-ttu-id="f8218-166">パッケージの追加します。</span><span class="sxs-lookup"><span data-stu-id="f8218-166">Add them to your package</span></span>
> * <span data-ttu-id="f8218-167">パッケージ マニフェストの変更</span><span class="sxs-lookup"><span data-stu-id="f8218-167">Modify the package manifest</span></span>
> * <span data-ttu-id="f8218-168">構成ファイルを作成します。</span><span class="sxs-lookup"><span data-stu-id="f8218-168">Create a configuration file</span></span>

<span data-ttu-id="f8218-169">各タスクしてみましょう。</span><span class="sxs-lookup"><span data-stu-id="f8218-169">Let's go through each task.</span></span>

### <a name="create-the-package-layout-folder"></a><span data-ttu-id="f8218-170">パッケージのレイアウトのフォルダーを作成します。</span><span class="sxs-lookup"><span data-stu-id="f8218-170">Create the package layout folder</span></span>

<span data-ttu-id="f8218-171">既に .appx ファイルがある場合、その内容をパッケージ備中として使用するレイアウト フォルダーに展開ことができます。</span><span class="sxs-lookup"><span data-stu-id="f8218-171">If you have a .appx file already, you can unpack its contents into a layout folder that will serve as the staging area for your package.</span></span>  <span data-ttu-id="f8218-172">これから行うことができます、 **x64 VS 2017 のネイティブのツール コマンド プロンプト**、または手動で実行可能ファイルの検索パスに SDK ビン パス。</span><span class="sxs-lookup"><span data-stu-id="f8218-172">You can do this from an **x64 Native Tools Command Prompt for VS 2017**, or manually with the SDK bin path in the executable search path.</span></span>

```
makeappx unpack /p PSFSamplePackage_1.0.60.0_AnyCPU_Debug.appx /d PackageContents

```

<span data-ttu-id="f8218-173">これにより、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="f8218-173">This will give you something that looks like the following.</span></span>

![パッケージのレイアウト](images/desktop-to-uwp/package_contents.png)

<span data-ttu-id="f8218-175">を持っていない .appx ファイルで起動する場合は、最初からパッケージ フォルダーやファイルを作成できます。</span><span class="sxs-lookup"><span data-stu-id="f8218-175">If you don't have a .appx file to start with, you can create the package folder and files from scratch.</span></span>

### <a name="get-the-package-support-framework-files"></a><span data-ttu-id="f8218-176">パッケージのサポート フレームワーク ファイルを取得します。</span><span class="sxs-lookup"><span data-stu-id="f8218-176">Get the Package Support Framework files</span></span>

<span data-ttu-id="f8218-177">Visual Studio を使用して、PSF Nuget パッケージを取得できます。</span><span class="sxs-lookup"><span data-stu-id="f8218-177">You can get the PSF Nuget package by using Visual Studio.</span></span> <span data-ttu-id="f8218-178">スタンドアロン Nuget のコマンド ライン ツールを使用して取得できます。</span><span class="sxs-lookup"><span data-stu-id="f8218-178">You can also get it by using the standalone Nuget command line tool.</span></span>

#### <a name="get-the-package-by-using-visual-studio"></a><span data-ttu-id="f8218-179">Visual Studio を使用して、パッケージを入手します。</span><span class="sxs-lookup"><span data-stu-id="f8218-179">Get the package by using Visual Studio</span></span>

<span data-ttu-id="f8218-180">Visual Studio では、ソリューションまたはプロジェクト ノードを右クリックし、Nuget パッケージの管理のコマンドのいずれかを選びます。</span><span class="sxs-lookup"><span data-stu-id="f8218-180">In Visual Studio, right-click your solution or project node and pick one of the Manage Nuget Packages commands.</span></span>  <span data-ttu-id="f8218-181">検索**Microsoft.PackageSupportFramework**または**PSF** Nuget.org のパッケージを検索します。次に、インストールします。</span><span class="sxs-lookup"><span data-stu-id="f8218-181">Search for **Microsoft.PackageSupportFramework** or **PSF** to find the package on Nuget.org. Then, install it.</span></span>

#### <a name="get-the-package-by-using-the-command-line-tool"></a><span data-ttu-id="f8218-182">コマンド ライン ツールを使用して、パッケージを取得します。</span><span class="sxs-lookup"><span data-stu-id="f8218-182">Get the package by using the command line tool</span></span>

<span data-ttu-id="f8218-183">次の場所から Nuget コマンド ライン ツールのインストール:https://www.nuget.org/downloadsします。</span><span class="sxs-lookup"><span data-stu-id="f8218-183">Install the Nuget command line tool from this location: https://www.nuget.org/downloads.</span></span> <span data-ttu-id="f8218-184">次に、Nuget のコマンドラインでは、このコマンドを実行します。</span><span class="sxs-lookup"><span data-stu-id="f8218-184">Then, from the Nuget command line, run this command:</span></span>

```
nuget install Microsoft.PackageSupportFramework
```

### <a name="add-the-package-support-framework-files-to-your-package"></a><span data-ttu-id="f8218-185">パッケージのサポート フレームワーク ファイルをパッケージに追加します。</span><span class="sxs-lookup"><span data-stu-id="f8218-185">Add the Package Support Framework files to your package</span></span>

<span data-ttu-id="f8218-186">パッケージのディレクトリに必要な 32 ビットと 64 ビット PSF Dll と実行可能ファイルを追加します。</span><span class="sxs-lookup"><span data-stu-id="f8218-186">Add the required 32-bit and 64-bit PSF  DLLs and executable files to the package directory.</span></span> <span data-ttu-id="f8218-187">次の表をガイドとして使用してください。</span><span class="sxs-lookup"><span data-stu-id="f8218-187">Use the following table as a guide.</span></span> <span data-ttu-id="f8218-188">する必要があるどのようなランタイム修正を挿入するされます。</span><span class="sxs-lookup"><span data-stu-id="f8218-188">You'll also want to include any runtime fixes that you need.</span></span> <span data-ttu-id="f8218-189">ここでは、ファイルのリダイレクト ランタイム修正が必要です。</span><span class="sxs-lookup"><span data-stu-id="f8218-189">In our example, we need the file redirection runtime fix.</span></span>

| <span data-ttu-id="f8218-190">アプリケーションの実行可能ファイルが x64</span><span class="sxs-lookup"><span data-stu-id="f8218-190">Application executable is x64</span></span> | <span data-ttu-id="f8218-191">アプリケーションの実行可能ファイルが x86</span><span class="sxs-lookup"><span data-stu-id="f8218-191">Application executable is x86</span></span> |
|-------------------------------|-----------|
| [<span data-ttu-id="f8218-192">ShimLauncher64.exe</span><span class="sxs-lookup"><span data-stu-id="f8218-192">ShimLauncher64.exe</span></span>](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/ShimLauncher/readme.md) |  [<span data-ttu-id="f8218-193">ShimLauncher32.exe</span><span class="sxs-lookup"><span data-stu-id="f8218-193">ShimLauncher32.exe</span></span>](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/ShimLauncher/readme.md) |
| [<span data-ttu-id="f8218-194">ShimRuntime64.dll</span><span class="sxs-lookup"><span data-stu-id="f8218-194">ShimRuntime64.dll</span></span>](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/ShimRuntime/readme.md) | [<span data-ttu-id="f8218-195">ShimRuntime32.dll</span><span class="sxs-lookup"><span data-stu-id="f8218-195">ShimRuntime32.dll</span></span>](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/ShimRuntime/readme.md) |
| [<span data-ttu-id="f8218-196">ShimRunDll64.exe</span><span class="sxs-lookup"><span data-stu-id="f8218-196">ShimRunDll64.exe</span></span>](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/ShimRunDll/readme.md) | [<span data-ttu-id="f8218-197">ShimRunDll32.exe</span><span class="sxs-lookup"><span data-stu-id="f8218-197">ShimRunDll32.exe</span></span>](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/ShimRunDll/readme.md) |

<span data-ttu-id="f8218-198">パッケージ コンテンツは次のようになります。</span><span class="sxs-lookup"><span data-stu-id="f8218-198">Your package content should now look something like this.</span></span>

![パッケージのバイナリ](images/desktop-to-uwp/package_binaries.png)

### <a name="modify-the-package-manifest"></a><span data-ttu-id="f8218-200">パッケージ マニフェストの変更</span><span class="sxs-lookup"><span data-stu-id="f8218-200">Modify the package manifest</span></span>

<span data-ttu-id="f8218-201">テキスト エディターで、パッケージ マニフェストを開き、[設定、`Executable`の属性、 `Application` shim 起動ツールの実行可能ファイルの名前を要素。</span><span class="sxs-lookup"><span data-stu-id="f8218-201">Open your package manifest in a text editor, and then set the `Executable` attribute of the `Application` element to the name of the shim launcher executable file.</span></span>  <span data-ttu-id="f8218-202">ターゲット アプリケーションのアーキテクチャがわかっている場合は、ShimLauncher32.exe または ShimLauncher64.exe、適切なバージョンを選択します。</span><span class="sxs-lookup"><span data-stu-id="f8218-202">If you know the architecture of your target application, select the appropriate version, ShimLauncher32.exe or ShimLauncher64.exe.</span></span>  <span data-ttu-id="f8218-203">有効でない場合は、ShimLauncher32.exe は常に機能します。</span><span class="sxs-lookup"><span data-stu-id="f8218-203">If not, ShimLauncher32.exe will work in all cases.</span></span>  <span data-ttu-id="f8218-204">次に例を示します。</span><span class="sxs-lookup"><span data-stu-id="f8218-204">Here's an example.</span></span>

```xml
<Package ...>
  ...
  <Applications>
    <Application Id="PSFSample"
                 Executable="ShimLauncher32.exe"
                 EntryPoint="Windows.FullTrustApplication">
      ...
    </Application>
  </Applications>
</Package>
```

### <a name="create-a-configuration-file"></a><span data-ttu-id="f8218-205">構成ファイルを作成します。</span><span class="sxs-lookup"><span data-stu-id="f8218-205">Create a configuration file</span></span>

<span data-ttu-id="f8218-206">ファイル名を作成する``config.json``、および、パッケージのルート フォルダーにそのファイルを保存します。</span><span class="sxs-lookup"><span data-stu-id="f8218-206">Create a file name ``config.json``, and save that file to the root folder of your package.</span></span> <span data-ttu-id="f8218-207">交換した実行可能ファイルを指すように、config.json ファイルの宣言されたアプリ ID を変更します。</span><span class="sxs-lookup"><span data-stu-id="f8218-207">Modify the declared app ID of the config.json file to point to the executable that you just replaced.</span></span> <span data-ttu-id="f8218-208">プロセスのモニターを使用してから取得した情報を使用すると、できますも作業ディレクトリの設定などを行うことパッケージの相対"PSFSampleApp"ディレクトリ. log ファイルへの読み取り/書き込みをリダイレクトするのにはファイルのリダイレクト shim を使用します。</span><span class="sxs-lookup"><span data-stu-id="f8218-208">Using the knowledge that you gained from using Process Monitor, you can also set the working directory as well as use the file redirection shim to redirect reads/writes to .log files under the package-relative "PSFSampleApp" directory.</span></span>

```json
{
    "applications": [
        {
            "id": "PSFSample",
            "executable": "PSFSampleApp/PSFSample.exe",
            "workingDirectory": "PSFSampleApp/"
        }
    ],
    "processes": [
        {
            "executable": "PSFSample",
            "shims": [
                {
                    "dll": "FileRedirectionShim.dll",
                    "config": {
                        "redirectedPaths": {
                            "packageRelative": [
                                {
                                    "base": "PSFSampleApp/",
                                    "patterns": [
                                        ".*\\.log"
                                    ]
                                }
                            ]
                        }
                    }
                }
            ]
        }
    ]
}
```
<span data-ttu-id="f8218-209">以下は、config.json スキーマ向けのガイドです。</span><span class="sxs-lookup"><span data-stu-id="f8218-209">Following is a guide for the config.json schema:</span></span>

| <span data-ttu-id="f8218-210">配列</span><span class="sxs-lookup"><span data-stu-id="f8218-210">Array</span></span> | <span data-ttu-id="f8218-211">key</span><span class="sxs-lookup"><span data-stu-id="f8218-211">key</span></span> | <span data-ttu-id="f8218-212">値</span><span class="sxs-lookup"><span data-stu-id="f8218-212">Value</span></span> |
|-------|-----------|-------|
| <span data-ttu-id="f8218-213">applications</span><span class="sxs-lookup"><span data-stu-id="f8218-213">applications</span></span> | <span data-ttu-id="f8218-214">id</span><span class="sxs-lookup"><span data-stu-id="f8218-214">id</span></span> |  <span data-ttu-id="f8218-215">値を使用して、`Id`の属性、`Application`パッケージ マニフェストの要素。</span><span class="sxs-lookup"><span data-stu-id="f8218-215">Use the value of the `Id` attribute of the `Application` element in the package manifest.</span></span> |
| <span data-ttu-id="f8218-216">applications</span><span class="sxs-lookup"><span data-stu-id="f8218-216">applications</span></span> | <span data-ttu-id="f8218-217">実行可能ファイル</span><span class="sxs-lookup"><span data-stu-id="f8218-217">executable</span></span> | <span data-ttu-id="f8218-218">開始する実行可能ファイルへのパッケージの相対パス。</span><span class="sxs-lookup"><span data-stu-id="f8218-218">The package-relative path to the executable that you want to start.</span></span> <span data-ttu-id="f8218-219">ほとんどの場合、それを変更する前にパッケージ マニフェスト ファイルからこの値を得るができます。</span><span class="sxs-lookup"><span data-stu-id="f8218-219">In most cases, you can get this value from your package manifest file before you modify it.</span></span> <span data-ttu-id="f8218-220">値は、`Executable`の属性、`Application`要素。</span><span class="sxs-lookup"><span data-stu-id="f8218-220">It's the value of the `Executable` attribute of the `Application` element.</span></span> |
| <span data-ttu-id="f8218-221">applications</span><span class="sxs-lookup"><span data-stu-id="f8218-221">applications</span></span> | <span data-ttu-id="f8218-222">作業ディレクトリ</span><span class="sxs-lookup"><span data-stu-id="f8218-222">workingDirectory</span></span> | <span data-ttu-id="f8218-223">(オプション)作業を開始するディレクトリとして使用するパッケージの相対パス。</span><span class="sxs-lookup"><span data-stu-id="f8218-223">(Optional) A package-relative path to use as the working directory of the application that starts.</span></span> <span data-ttu-id="f8218-224">オペレーティング システムを使用して、この値を設定しない場合、`System32`ディレクトリをアプリケーションの作業のディレクトリです。</span><span class="sxs-lookup"><span data-stu-id="f8218-224">If you don't set this value, the operating system uses the `System32` directory as the application's working directory.</span></span> |
| <span data-ttu-id="f8218-225">プロセス</span><span class="sxs-lookup"><span data-stu-id="f8218-225">processes</span></span> | <span data-ttu-id="f8218-226">実行可能ファイル</span><span class="sxs-lookup"><span data-stu-id="f8218-226">executable</span></span> | <span data-ttu-id="f8218-227">ほとんどの場合の名前になります、`executable`上にある削除パスとファイル拡張子のように構成されています。</span><span class="sxs-lookup"><span data-stu-id="f8218-227">In most cases, this will be the name of the `executable` configured above with the path and file extension removed.</span></span> |
| <span data-ttu-id="f8218-228">shim</span><span class="sxs-lookup"><span data-stu-id="f8218-228">shims</span></span> | <span data-ttu-id="f8218-229">dll</span><span class="sxs-lookup"><span data-stu-id="f8218-229">dll</span></span> | <span data-ttu-id="f8218-230">読み込む shim .appx パッケージの相対パス。</span><span class="sxs-lookup"><span data-stu-id="f8218-230">Package-relative path to the shim  .appx  to load.</span></span> |
| <span data-ttu-id="f8218-231">shim</span><span class="sxs-lookup"><span data-stu-id="f8218-231">shims</span></span> | <span data-ttu-id="f8218-232">構成</span><span class="sxs-lookup"><span data-stu-id="f8218-232">config</span></span> | <span data-ttu-id="f8218-233">(オプション)Shim dl の動作を制御します。</span><span class="sxs-lookup"><span data-stu-id="f8218-233">(Optional) Controls how the shim dl behaves.</span></span> <span data-ttu-id="f8218-234">この値の正確な形式は、各 shim できる解釈"blob"必要があると shim-によって-shim ごとに異なります。</span><span class="sxs-lookup"><span data-stu-id="f8218-234">The exact format of this value varies on a shim-by-shim basis as each shim can interpret this "blob" as it wants.</span></span> |

<span data-ttu-id="f8218-235">`applications`、 `processes`、および`shims`キーは、配列します。</span><span class="sxs-lookup"><span data-stu-id="f8218-235">The `applications`, `processes`, and `shims` keys are arrays.</span></span> <span data-ttu-id="f8218-236">つまり、1 つ以上のアプリケーション、プロセス、および shim DLL を指定する config.json ファイルを使用することができます。</span><span class="sxs-lookup"><span data-stu-id="f8218-236">That means that you can use the config.json file to specify more than one application, process, and shim DLL.</span></span>


### <a name="package-and-test-the-app"></a><span data-ttu-id="f8218-237">パッケージ化して、アプリのテスト</span><span class="sxs-lookup"><span data-stu-id="f8218-237">Package and Test the App</span></span>

<span data-ttu-id="f8218-238">次に、パッケージを作成します。</span><span class="sxs-lookup"><span data-stu-id="f8218-238">Next, create a package.</span></span>

```
makeappx pack /d PackageContents /p PSFSamplePackageFixup.appx
```

<span data-ttu-id="f8218-239">次に、署名します。</span><span class="sxs-lookup"><span data-stu-id="f8218-239">Then, sign it.</span></span>

```
signtool sign /a /v /fd sha256 /f ExportedSigningCertificate.pfx PSFSamplePackageFixup.appx
```

<span data-ttu-id="f8218-240">詳細については、「 [signtool を使用して、パッケージ署名する方法](https://docs.microsoft.com/en-us/windows/desktop/appxpkg/how-to-sign-a-package-using-signtool)と[署名証明書パッケージを作成する方法](https://docs.microsoft.com/en-us/windows/desktop/appxpkg/how-to-create-a-package-signing-certificate)の使用」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="f8218-240">For more information, see [how to create a package signing certificate](https://docs.microsoft.com/en-us/windows/desktop/appxpkg/how-to-create-a-package-signing-certificate) and [how to sign a package using signtool](https://docs.microsoft.com/en-us/windows/desktop/appxpkg/how-to-sign-a-package-using-signtool)</span></span>

<span data-ttu-id="f8218-241">PowerShell を使用して、パッケージをインストールします。</span><span class="sxs-lookup"><span data-stu-id="f8218-241">Using PowerShell, install the package.</span></span>

>[!NOTE]
> <span data-ttu-id="f8218-242">最初に、パッケージをアンインストールしてください。</span><span class="sxs-lookup"><span data-stu-id="f8218-242">Remember to uninstall the package first.</span></span>

```
powershell Add-AppxPackage .\PSFSamplePackageFixup.appx
```

<span data-ttu-id="f8218-243">アプリケーションを実行し、ランタイムの修正プログラムが適用されると、動作を確認します。</span><span class="sxs-lookup"><span data-stu-id="f8218-243">Run the application and observe the behavior with runtime fix applied.</span></span>  <span data-ttu-id="f8218-244">診断および必要に応じてパッケージの手順を繰り返します。</span><span class="sxs-lookup"><span data-stu-id="f8218-244">Repeat the diagnostic and packaging steps as necessary.</span></span>

### <a name="use-the-trace-shim"></a><span data-ttu-id="f8218-245">トレース Shim を使用します。</span><span class="sxs-lookup"><span data-stu-id="f8218-245">Use the Trace Shim</span></span>

<span data-ttu-id="f8218-246">パッケージ アプリケーションの互換性の問題を診断する以外の方法では、トレース Shim を使用します。</span><span class="sxs-lookup"><span data-stu-id="f8218-246">An alternative technique to diagnosing packaged application compatibility issues is to use the Trace Shim.</span></span> <span data-ttu-id="f8218-247">この DLL であり、PSF に含まれて、プロセスのモニターのようなアプリの動作の詳細な診断ビューを提供します。</span><span class="sxs-lookup"><span data-stu-id="f8218-247">This DLL is included with the PSF and provides a detailed diagnostic view of the app's behavior, similar to Process Monitor.</span></span>  <span data-ttu-id="f8218-248">アプリケーションの互換性の問題を表示するように設計します。</span><span class="sxs-lookup"><span data-stu-id="f8218-248">It is specially designed to reveal application compatibility issues.</span></span>  <span data-ttu-id="f8218-249">トレース Shim DLL パッケージを追加、config.json に次の例を追加し、[パッケージ化するし、アプリケーションをインストールします。</span><span class="sxs-lookup"><span data-stu-id="f8218-249">To use the Trace Shim, add the DLL to the package, add the following fragment to your config.json, and then package and install your application.</span></span>

```json
{
    "dll": "TraceShim.dll",
    "config": {
        "traceLevels": {
            "filesystem": "allFailures"
        }
    }
}
```

<span data-ttu-id="f8218-250">既定では、トレース Shim「予想」と考えられる失敗が除外されます。</span><span class="sxs-lookup"><span data-stu-id="f8218-250">By default, the Trace Shim filters out failures that might be considered "expected".</span></span>  <span data-ttu-id="f8218-251">たとえば、アプリケーション無条件に既に存在するかどうか、結果を無視して確認せずにファイルを削除することがありますしてみてください。</span><span class="sxs-lookup"><span data-stu-id="f8218-251">For example, applications might try to unconditionally delete a file without checking to see if it already exists, ignoring the result.</span></span> <span data-ttu-id="f8218-252">ファイル システム関数からすべてのエラーが表示される選択の上の例で、いくつかの予期しないエラーが取得フィルターで除外した、残念ながら上の結果があります。</span><span class="sxs-lookup"><span data-stu-id="f8218-252">This has the unfortunate consequence that some unexpected failures might get filtered out, so in the above example, we opt to receive all failures from filesystem functions.</span></span> <span data-ttu-id="f8218-253">前に、その Config.txt ファイル内の参照に失敗すると、メッセージ「ファイルは見つかりませんでした」とからわかっているので操作します。</span><span class="sxs-lookup"><span data-stu-id="f8218-253">We do this because we know from before that the attempt to read from the Config.txt file fails with the message "file not found".</span></span> <span data-ttu-id="f8218-254">これは、エラーが頻繁に確認しは、一般に予期しないがあると見なされます。</span><span class="sxs-lookup"><span data-stu-id="f8218-254">This is a failure that is frequently observed and not generally assumed to be unexpected.</span></span> <span data-ttu-id="f8218-255">演習では、のみに予期しないエラーは、フィルター処理して、[比較がすべての失敗も識別できない問題がある場合は、最初に可能性が高いベストはできます。</span><span class="sxs-lookup"><span data-stu-id="f8218-255">In practice it's likely best to start out filtering only to unexpected failures, and then falling back to all failures if there's an issue that still can't be identified.</span></span>

<span data-ttu-id="f8218-256">既定では、トレース Shim からの出力が接続されているデバッガーに送らを取得します。</span><span class="sxs-lookup"><span data-stu-id="f8218-256">By default, the output from the Trace Shim gets sent to the attached debugger.</span></span> <span data-ttu-id="f8218-257">この例では、おデバッガーに接続するには、代わりにプログラムを使用して[デバッグ表示](https://docs.microsoft.com/en-us/sysinternals/downloads/debugview)SysInternals から出力を表示します。</span><span class="sxs-lookup"><span data-stu-id="f8218-257">For this example, we aren't going to attach a debugger, and will instead use the [DebugView](https://docs.microsoft.com/en-us/sysinternals/downloads/debugview) program from SysInternals to view its output.</span></span> <span data-ttu-id="f8218-258">アプリを実行すると、わかります同じ失敗前とに、同じランタイム修正に向かってポイントへのご協力します。</span><span class="sxs-lookup"><span data-stu-id="f8218-258">After running the app, we can see the same failures as before, which would point us towards the same runtime fixes.</span></span>

![TraceShim ファイルが見つからない](images/desktop-to-uwp/traceshim_filenotfound.png)

![TraceShim アクセス拒否](images/desktop-to-uwp/traceshim_accessdenied.png)

## <a name="debug-extend-or-create-a-runtime-fix"></a><span data-ttu-id="f8218-261">デバッグ、拡張または実行時の修正プログラムを作成します。</span><span class="sxs-lookup"><span data-stu-id="f8218-261">Debug, extend, or create a runtime fix</span></span>

<span data-ttu-id="f8218-262">ランタイムの修正プログラムをデバッグする、拡張ランタイム修正、一から作成するのには、Visual Studio を使用できます。</span><span class="sxs-lookup"><span data-stu-id="f8218-262">You can use Visual Studio to debug a runtime fix, extend a runtime fix, or create one from scratch.</span></span> <span data-ttu-id="f8218-263">成功する点を実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f8218-263">You'll need to do these things to be successful.</span></span>

> [!div class="checklist"]
> * <span data-ttu-id="f8218-264">パッケージのプロジェクトを追加します。</span><span class="sxs-lookup"><span data-stu-id="f8218-264">Add a packaging project</span></span>
> * <span data-ttu-id="f8218-265">ランタイム fix のプロジェクトを追加します。</span><span class="sxs-lookup"><span data-stu-id="f8218-265">Add project for the runtime fix</span></span>
> * <span data-ttu-id="f8218-266">実行可能 Shim の起動ツールを起動するプロジェクトを追加します。</span><span class="sxs-lookup"><span data-stu-id="f8218-266">Add a project that starts the Shim Launcher executable</span></span>
> * <span data-ttu-id="f8218-267">パッケージの project を構成します。</span><span class="sxs-lookup"><span data-stu-id="f8218-267">Configure the packaging project</span></span>

<span data-ttu-id="f8218-268">完了したら、次のようなものをソリューションになります。</span><span class="sxs-lookup"><span data-stu-id="f8218-268">When you're done, your solution will look something like this.</span></span>

![完成したソリューション](images/desktop-to-uwp/runtime-fix-project-structure.png)

<span data-ttu-id="f8218-270">この例では、各プロジェクトを見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="f8218-270">Let's look at each project in this example.</span></span>

| <span data-ttu-id="f8218-271">プロジェクト</span><span class="sxs-lookup"><span data-stu-id="f8218-271">Project</span></span> | <span data-ttu-id="f8218-272">目的</span><span class="sxs-lookup"><span data-stu-id="f8218-272">Purpose</span></span> |
|-------|-----------|
| <span data-ttu-id="f8218-273">DesktopApplicationPackage</span><span class="sxs-lookup"><span data-stu-id="f8218-273">DesktopApplicationPackage</span></span> | <span data-ttu-id="f8218-274">このプロジェクトは、 [Windows アプリケーション パッケージのプロジェクト](desktop-to-uwp-packaging-dot-net.md)に基づいており、出力、パッケージ化する MSIX します。</span><span class="sxs-lookup"><span data-stu-id="f8218-274">This project is based on the [Windows Application Packaging project](desktop-to-uwp-packaging-dot-net.md) and it outputs the the MSIX package.</span></span> |
| <span data-ttu-id="f8218-275">Runtimefix</span><span class="sxs-lookup"><span data-stu-id="f8218-275">Runtimefix</span></span> | <span data-ttu-id="f8218-276">ランタイム fix として機能する 1 つまたは複数の置換関数を含む C Dynamic-Linked ライブラリ プロジェクトであります。</span><span class="sxs-lookup"><span data-stu-id="f8218-276">This is a C++ Dynamic-Linked Library project that contains one or more replacement functions that serve as the runtime fix.</span></span> |
| <span data-ttu-id="f8218-277">ShimLauncher</span><span class="sxs-lookup"><span data-stu-id="f8218-277">ShimLauncher</span></span> | <span data-ttu-id="f8218-278">これは、C の空のプロジェクトです。</span><span class="sxs-lookup"><span data-stu-id="f8218-278">This is C++ Empty Project.</span></span> <span data-ttu-id="f8218-279">このプロジェクトには、パッケージ サポート Framework のランタイム配布可能なファイルを収集します。</span><span class="sxs-lookup"><span data-stu-id="f8218-279">This project is a place to collect the runtime distributable files of the Package Support Framework.</span></span> <span data-ttu-id="f8218-280">実行可能ファイルを出力します。</span><span class="sxs-lookup"><span data-stu-id="f8218-280">It outputs an executable file.</span></span> <span data-ttu-id="f8218-281">その実行可能ファイルは、ソリューションを起動するときに実行される最初に注意します。</span><span class="sxs-lookup"><span data-stu-id="f8218-281">That executable is the first thing that runs when you start the solution.</span></span> |
| <span data-ttu-id="f8218-282">WinFormsDesktopApplication</span><span class="sxs-lookup"><span data-stu-id="f8218-282">WinFormsDesktopApplication</span></span> | <span data-ttu-id="f8218-283">このプロジェクトには、デスクトップ アプリケーションのソース コードが含まれています。</span><span class="sxs-lookup"><span data-stu-id="f8218-283">This project contains the source code of a desktop application.</span></span> |

<span data-ttu-id="f8218-284">これらの種類のプロジェクトのすべてを含む完全なサンプルを見ると、 [PSFSample](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/samples/PSFSample/)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="f8218-284">To look at a complete sample that contains all of these types of projects, see [PSFSample](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/samples/PSFSample/).</span></span>

<span data-ttu-id="f8218-285">作成およびソリューションでは、これらのプロジェクトの各を構成する手順を見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="f8218-285">Let's walk through the steps to create and configure each of these projects in your solution.</span></span>


### <a name="create-a-package-solution"></a><span data-ttu-id="f8218-286">ソリューションをパッケージを作成します。</span><span class="sxs-lookup"><span data-stu-id="f8218-286">Create a package solution</span></span>

<span data-ttu-id="f8218-287">デスクトップ アプリケーションのソリューションがいない場合は、Visual Studio で新しい**空のソリューション**を作成します。</span><span class="sxs-lookup"><span data-stu-id="f8218-287">If you don't already have a solution for your desktop application, create a new **Blank Solution** in Visual Studio.</span></span>

![空のソリューション](images/desktop-to-uwp/blank-solution.png)

<span data-ttu-id="f8218-289">あるアプリケーション プロジェクトを追加することもできます。</span><span class="sxs-lookup"><span data-stu-id="f8218-289">You may also want to add any application projects you have.</span></span>

### <a name="add-a-packaging-project"></a><span data-ttu-id="f8218-290">パッケージのプロジェクトを追加します。</span><span class="sxs-lookup"><span data-stu-id="f8218-290">Add a packaging project</span></span>

<span data-ttu-id="f8218-291">**Windows アプリケーション パッケージのプロジェクト**を持っていない場合は、1 つを作成し、ソリューションに追加します。</span><span class="sxs-lookup"><span data-stu-id="f8218-291">If you don't already have a **Windows Application Packaging Project**, create one and add it to your solution.</span></span>

![パッケージのプロジェクトのテンプレート](images/desktop-to-uwp/package-project-template.png)

<span data-ttu-id="f8218-293">Windows アプリケーション パッケージのプロジェクトの詳細については、 [Visual Studio を使用して、アプリ パッケージ](desktop-to-uwp-packaging-dot-net.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="f8218-293">For more information on Windows Application Packaging project, see [Package your application by using Visual Studio](desktop-to-uwp-packaging-dot-net.md).</span></span>

<span data-ttu-id="f8218-294">**ソリューション エクスプ ローラー**でパッケージ プロジェクトを右クリックし、[**編集**] を選択し、これをプロジェクト ファイルの下に追加。</span><span class="sxs-lookup"><span data-stu-id="f8218-294">In **Solution Explorer**, right-click the packaging project, select **Edit**, and then add this to the bottom of the project file:</span></span>

```
<Target Name="PSFRemoveSourceProject" AfterTargets="ExpandProjectReferences" BeforeTargets="_ConvertItems">
<ItemGroup>
  <FilteredNonWapProjProjectOutput Include="@(_FilteredNonWapProjProjectOutput)">
  <SourceProject Condition="'%(_FilteredNonWapProjProjectOutput.SourceProject)'=='<your runtime fix project name goes here>'" />
  </FilteredNonWapProjProjectOutput>
  <_FilteredNonWapProjProjectOutput Remove="@(_FilteredNonWapProjProjectOutput)" />
  <_FilteredNonWapProjProjectOutput Include="@(FilteredNonWapProjProjectOutput)" />
</ItemGroup>
</Target>
```

### <a name="add-project-for-the-runtime-fix"></a><span data-ttu-id="f8218-295">ランタイム fix のプロジェクトを追加します。</span><span class="sxs-lookup"><span data-stu-id="f8218-295">Add project for the runtime fix</span></span>

<span data-ttu-id="f8218-296">ソリューション C++**ダイナミック リンク ライブラリ (DLL)** プロジェクトに追加します。</span><span class="sxs-lookup"><span data-stu-id="f8218-296">Add a C++ **Dynamic-Link Library (DLL)** project to the solution.</span></span>

![ランタイム fix ライブラリ](images/desktop-to-uwp/runtime-fix-library.png)

<span data-ttu-id="f8218-298">[プロジェクト]、[**プロパティ**を右クリックします。</span><span class="sxs-lookup"><span data-stu-id="f8218-298">Right-click the that project, and then choose **Properties**.</span></span>

<span data-ttu-id="f8218-299">プロパティ ページ] で、[ **C++ 言語標準的な**フィールドを検索し、そのフィールドの横にあるドロップダウン リストで次のように選択します。 [ **ISO c 17 標準 (/std:c + + 17)** オプション。</span><span class="sxs-lookup"><span data-stu-id="f8218-299">In the property pages, find the **C++ Language Standard** field, and then in the drop-down list next to that field, select the **ISO C++17 Standard (/std:c++17)** option.</span></span>

![ISO 17 オプション](images/desktop-to-uwp/iso-option.png)

<span data-ttu-id="f8218-301">プロジェクトを右クリックし、[のコンテキスト メニューで、[ **Nuget パッケージの管理**] のオプション] を選びます。</span><span class="sxs-lookup"><span data-stu-id="f8218-301">Right-click that project, and then in the context menu, choose the **Manage Nuget Packages** option.</span></span> <span data-ttu-id="f8218-302">[**パッケージのソース**] オプションが**すべて**または**nuget.org**に設定されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="f8218-302">Ensure that the **Package source** option is set to **All** or **nuget.org**.</span></span>

<span data-ttu-id="f8218-303">次にそのフィールドの設定] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="f8218-303">Click the settings icon next that field.</span></span>

<span data-ttu-id="f8218-304">検索*PSF*\* Nuget パッケージ化し、次のプロジェクトのインストールします。</span><span class="sxs-lookup"><span data-stu-id="f8218-304">Search for the *PSF*\* Nuget package, and then install it for this project.</span></span>

![nuget パッケージ](images/desktop-to-uwp/psf-package.png)

<span data-ttu-id="f8218-306">デバッグまたは既存の実行時の修正プログラムを拡張する場合は、このガイドの[実行時の修正プログラムを検索](#find)] セクションで説明するガイダンスを使用して取得したランタイム修正ファイルを追加します。</span><span class="sxs-lookup"><span data-stu-id="f8218-306">If you want to debug or extend an existing runtime fix, add the runtime fix files that you obtained by using the guidance described in the [Find a runtime fix](#find) section of this guide.</span></span>

<span data-ttu-id="f8218-307">新しい修正を作成する場合は、追加しない何もこのプロジェクトにまだします。</span><span class="sxs-lookup"><span data-stu-id="f8218-307">If you intend to create a brand new fix, don't add anything to this project just yet.</span></span> <span data-ttu-id="f8218-308">このガイドの後に、このプロジェクトにファイルを追加するのに役立ちます。</span><span class="sxs-lookup"><span data-stu-id="f8218-308">We'll help you add the right files to this project later in this guide.</span></span> <span data-ttu-id="f8218-309">ここでは、ソリューションの設定がいくされます。</span><span class="sxs-lookup"><span data-stu-id="f8218-309">For now, we'll continue setting up your solution.</span></span>

### <a name="add-a-project-that-starts-the-shim-launcher-executable"></a><span data-ttu-id="f8218-310">実行可能 Shim の起動ツールを起動するプロジェクトを追加します。</span><span class="sxs-lookup"><span data-stu-id="f8218-310">Add a project that starts the Shim Launcher executable</span></span>

<span data-ttu-id="f8218-311">ソリューション C**空のプロジェクト**のプロジェクトに追加します。</span><span class="sxs-lookup"><span data-stu-id="f8218-311">Add a C++ **Empty Project** project to the solution.</span></span>

![空のプロジェクト](images/desktop-to-uwp/blank-app.png)

<span data-ttu-id="f8218-313">このプロジェクトに**PSF** Nuget パッケージを追加するには、同じ、前のセクションで説明するガイダンスを使用します。</span><span class="sxs-lookup"><span data-stu-id="f8218-313">Add the **PSF** Nuget package to this project by using the same guidance described in the previous section.</span></span>

<span data-ttu-id="f8218-314">開いているプロジェクトの**全般**設定] ページのプロパティ ページ**Target Name**プロパティを設定します``ShimLauncher32``または``ShimLauncher64``によっては、アプリケーションのアーキテクチャは、します。</span><span class="sxs-lookup"><span data-stu-id="f8218-314">Open the property pages for the project, and in the **General** settings page, set the **Target Name** property to ``ShimLauncher32`` or ``ShimLauncher64`` depending on the architecture of your application.</span></span>

![shim 起動ツールの参照](images/desktop-to-uwp/shim-exe-reference.png)

<span data-ttu-id="f8218-316">ソリューションのランタイム fix プロジェクトにプロジェクトの参照を追加します。</span><span class="sxs-lookup"><span data-stu-id="f8218-316">Add a project reference to the runtime fix project in your solution.</span></span>

![ランタイム fix リファレンス](images/desktop-to-uwp/reference-fix.png)

<span data-ttu-id="f8218-318">参照を右クリックし、[**プロパティ**] ウィンドウで以下の値を適用します。</span><span class="sxs-lookup"><span data-stu-id="f8218-318">Right-click the reference, and then in the **Properties** window, apply these values.</span></span>

| <span data-ttu-id="f8218-319">プロパティ</span><span class="sxs-lookup"><span data-stu-id="f8218-319">Property</span></span> | <span data-ttu-id="f8218-320">値</span><span class="sxs-lookup"><span data-stu-id="f8218-320">Value</span></span> |
|-------|-----------|-------|
| <span data-ttu-id="f8218-321">ローカル コピーします。</span><span class="sxs-lookup"><span data-stu-id="f8218-321">Copy local</span></span> | <span data-ttu-id="f8218-322">True</span><span class="sxs-lookup"><span data-stu-id="f8218-322">True</span></span> |
| <span data-ttu-id="f8218-323">ローカルのサテライト アセンブリをコピーします。</span><span class="sxs-lookup"><span data-stu-id="f8218-323">Copy Local Satellite Assemblies</span></span> | <span data-ttu-id="f8218-324">True</span><span class="sxs-lookup"><span data-stu-id="f8218-324">True</span></span> |
| <span data-ttu-id="f8218-325">参照アセンブリの出力</span><span class="sxs-lookup"><span data-stu-id="f8218-325">Reference Assembly Output</span></span> | <span data-ttu-id="f8218-326">True</span><span class="sxs-lookup"><span data-stu-id="f8218-326">True</span></span> |
| <span data-ttu-id="f8218-327">ライブラリの依存関係のリンク</span><span class="sxs-lookup"><span data-stu-id="f8218-327">Link Library Dependencies</span></span> | <span data-ttu-id="f8218-328">False</span><span class="sxs-lookup"><span data-stu-id="f8218-328">False</span></span> |
| <span data-ttu-id="f8218-329">リンク ライブラリの依存関係の入力</span><span class="sxs-lookup"><span data-stu-id="f8218-329">Link Library Dependency Inputs</span></span> | <span data-ttu-id="f8218-330">False</span><span class="sxs-lookup"><span data-stu-id="f8218-330">False</span></span> |

### <a name="configure-the-packaging-project"></a><span data-ttu-id="f8218-331">パッケージの project を構成します。</span><span class="sxs-lookup"><span data-stu-id="f8218-331">Configure the packaging project</span></span>

<span data-ttu-id="f8218-332">パッケージ プロジェクトで、**[アプリケーション]** フォルダーを右クリックして **[参照の追加]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="f8218-332">In the packaging project, right-click the **Applications** folder, and then choose **Add Reference**.</span></span>

![プロジェクト参照の追加](images/desktop-to-uwp/add-reference-packaging-project.png)

<span data-ttu-id="f8218-334">Shim 起動ツールのプロジェクトと、デスクトップ アプリケーションのプロジェクトを選択し、 **[OK** ] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="f8218-334">Choose the shim launcher project and your desktop application project, and then choose the **OK** button.</span></span>

![デスクトップ プロジェクト](images/desktop-to-uwp/package-project-references.png)

>[!NOTE]
> <span data-ttu-id="f8218-336">ソース コード アプリケーションをお持ちでない場合だけ shim 起動ツールのプロジェクトを選択します。</span><span class="sxs-lookup"><span data-stu-id="f8218-336">If you don't have the source code to your application, just choose the shim launcher project.</span></span> <span data-ttu-id="f8218-337">構成ファイルを作成するときに、実行可能ファイルを参照する方法を紹介します。</span><span class="sxs-lookup"><span data-stu-id="f8218-337">We'll show you how to reference your executable when you create a configuration file.</span></span>

<span data-ttu-id="f8218-338">[**アプリケーション**] ノードでは、shim 起動ツール、アプリケーションを右クリックし、[**エントリ ポイントとして設定**] を選びます。</span><span class="sxs-lookup"><span data-stu-id="f8218-338">In the **Applications** node, right-click the shim launcher application, and then choose **Set as Entry Point**.</span></span>

![エントリ ポイントの設定](images/desktop-to-uwp/set-startup-project.png)

<span data-ttu-id="f8218-340">という名前のファイルを追加する``config.json``パッケージ プロジェクトにコピーし、ファイルに次の json テキストを貼り付けます。</span><span class="sxs-lookup"><span data-stu-id="f8218-340">Add a file named ``config.json`` to your packaging project, then, copy and paste the following json text into the file.</span></span> <span data-ttu-id="f8218-341">**コンテンツ**を**パッケージのアクション**のプロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="f8218-341">Set the **Package Action** property to **Content**.</span></span>

```json
{
    "applications": [
        {
            "id": "",
            "executable": "",
            "workingDirectory": ""
        }
    ],
    "processes": [
        {
            "executable": "",
            "shims": [
                {
                    "dll": "",
                    "config": {
                    }
                }
            ]
        }
    ]
}
```
<span data-ttu-id="f8218-342">各キーの値を指定します。</span><span class="sxs-lookup"><span data-stu-id="f8218-342">Provide a value for each key.</span></span> <span data-ttu-id="f8218-343">ガイドとしては、次の表を使用します。</span><span class="sxs-lookup"><span data-stu-id="f8218-343">Use this table as a guide.</span></span>

| <span data-ttu-id="f8218-344">配列</span><span class="sxs-lookup"><span data-stu-id="f8218-344">Array</span></span> | <span data-ttu-id="f8218-345">key</span><span class="sxs-lookup"><span data-stu-id="f8218-345">key</span></span> | <span data-ttu-id="f8218-346">値</span><span class="sxs-lookup"><span data-stu-id="f8218-346">Value</span></span> |
|-------|-----------|-------|
| <span data-ttu-id="f8218-347">applications</span><span class="sxs-lookup"><span data-stu-id="f8218-347">applications</span></span> | <span data-ttu-id="f8218-348">id</span><span class="sxs-lookup"><span data-stu-id="f8218-348">id</span></span> |  <span data-ttu-id="f8218-349">値を使用して、`Id`の属性、`Application`パッケージ マニフェストの要素。</span><span class="sxs-lookup"><span data-stu-id="f8218-349">Use the value of the `Id` attribute of the `Application` element in the package manifest.</span></span> |
| <span data-ttu-id="f8218-350">applications</span><span class="sxs-lookup"><span data-stu-id="f8218-350">applications</span></span> | <span data-ttu-id="f8218-351">実行可能ファイル</span><span class="sxs-lookup"><span data-stu-id="f8218-351">executable</span></span> | <span data-ttu-id="f8218-352">開始する実行可能ファイルへのパッケージの相対パス。</span><span class="sxs-lookup"><span data-stu-id="f8218-352">The package-relative path to the executable that you want to start.</span></span> <span data-ttu-id="f8218-353">ほとんどの場合、それを変更する前にパッケージ マニフェスト ファイルからこの値を得るができます。</span><span class="sxs-lookup"><span data-stu-id="f8218-353">In most cases, you can get this value from your package manifest file before you modify it.</span></span> <span data-ttu-id="f8218-354">値は、`Executable`の属性、`Application`要素。</span><span class="sxs-lookup"><span data-stu-id="f8218-354">It's the value of the `Executable` attribute of the `Application` element.</span></span> |
| <span data-ttu-id="f8218-355">applications</span><span class="sxs-lookup"><span data-stu-id="f8218-355">applications</span></span> | <span data-ttu-id="f8218-356">作業ディレクトリ</span><span class="sxs-lookup"><span data-stu-id="f8218-356">workingDirectory</span></span> | <span data-ttu-id="f8218-357">(オプション)作業を開始するディレクトリとして使用するパッケージの相対パス。</span><span class="sxs-lookup"><span data-stu-id="f8218-357">(Optional) A package-relative path to use as the working directory of the application that starts.</span></span> <span data-ttu-id="f8218-358">オペレーティング システムを使用して、この値を設定しない場合、`System32`ディレクトリをアプリケーションの作業のディレクトリです。</span><span class="sxs-lookup"><span data-stu-id="f8218-358">If you don't set this value, the operating system uses the `System32` directory as the application's working directory.</span></span> |
| <span data-ttu-id="f8218-359">プロセス</span><span class="sxs-lookup"><span data-stu-id="f8218-359">processes</span></span> | <span data-ttu-id="f8218-360">実行可能ファイル</span><span class="sxs-lookup"><span data-stu-id="f8218-360">executable</span></span> | <span data-ttu-id="f8218-361">ほとんどの場合の名前になります、`executable`上にある削除パスとファイル拡張子のように構成されています。</span><span class="sxs-lookup"><span data-stu-id="f8218-361">In most cases, this will be the name of the `executable` configured above with the path and file extension removed.</span></span> |
| <span data-ttu-id="f8218-362">shim</span><span class="sxs-lookup"><span data-stu-id="f8218-362">shims</span></span> | <span data-ttu-id="f8218-363">dll</span><span class="sxs-lookup"><span data-stu-id="f8218-363">dll</span></span> | <span data-ttu-id="f8218-364">Shim 読み込む DLL パッケージの相対パス。</span><span class="sxs-lookup"><span data-stu-id="f8218-364">Package-relative path to the shim DLL to load.</span></span> |
| <span data-ttu-id="f8218-365">shim</span><span class="sxs-lookup"><span data-stu-id="f8218-365">shims</span></span> | <span data-ttu-id="f8218-366">構成</span><span class="sxs-lookup"><span data-stu-id="f8218-366">config</span></span> | <span data-ttu-id="f8218-367">(オプション)Shim dl の動作を制御します。</span><span class="sxs-lookup"><span data-stu-id="f8218-367">(Optional) Controls how the shim dl behaves.</span></span> <span data-ttu-id="f8218-368">この値の正確な形式は、各 shim できる解釈"blob"必要があると shim-によって-shim ごとに異なります。</span><span class="sxs-lookup"><span data-stu-id="f8218-368">The exact format of this value varies on a shim-by-shim basis as each shim can interpret this "blob" as it wants.</span></span> |

<span data-ttu-id="f8218-369">完了したら、ときに、``config.json``ファイルは次のようになります。</span><span class="sxs-lookup"><span data-stu-id="f8218-369">When you're done, your ``config.json`` file will look something like this.</span></span>

```json
{
  "applications": [
    {
      "id": "DesktopApplication",
      "executable": "DesktopApplication/WinFormsDesktopApplication.exe",
      "workingDirectory": "WinFormsDesktopApplication"
    }
  ],
  "processes": [
    {
      "executable": ".*App.*",
      "shims": [ { "dll": "RuntimeFix.dll" } ]
    }
  ]
}

```

>[!NOTE]
> <span data-ttu-id="f8218-370">`applications`、 `processes`、および`shims`キーは、配列します。</span><span class="sxs-lookup"><span data-stu-id="f8218-370">The `applications`, `processes`, and `shims` keys are arrays.</span></span> <span data-ttu-id="f8218-371">つまり、1 つ以上のアプリケーション、プロセス、および shim DLL を指定する config.json ファイルを使用することができます。</span><span class="sxs-lookup"><span data-stu-id="f8218-371">That means that you can use the config.json file to specify more than one application, process, and shim DLL.</span></span>

### <a name="debug-a-runtime-fix"></a><span data-ttu-id="f8218-372">実行時の修正プログラムをデバッグします。</span><span class="sxs-lookup"><span data-stu-id="f8218-372">Debug a runtime fix</span></span>

<span data-ttu-id="f8218-373">Visual Studio では、[デバッガーを開始する F5 キーを押します。</span><span class="sxs-lookup"><span data-stu-id="f8218-373">In Visual Studio, press F5 to start the debugger.</span></span>  <span data-ttu-id="f8218-374">最初を起動するをターゲット デスクトップ アプリケーションを起動でき、shim 起動ツールのアプリケーションします。</span><span class="sxs-lookup"><span data-stu-id="f8218-374">The first thing that starts is the shim launcher application, which in turn, starts your target desktop application.</span></span>  <span data-ttu-id="f8218-375">対象のデスクトップ アプリケーションをデバッグするには、**デバッグ**を選択して、手動でデスクトップ アプリケーションのプロセスにアタッチする必要があります->**プロセスにアタッチ**、およびアプリケーションの処理] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="f8218-375">To debug the target desktop application, you'll have to manually attach to the desktop application process by choosing **Debug**->**Attach to Process**, and then selecting the application process.</span></span> <span data-ttu-id="f8218-376">ネイティブ ランタイム修正 DLL .NET アプリケーションのデバッグ時に、(混在モード デバッグ) の管理とネイティブ コードの種類を選択します。</span><span class="sxs-lookup"><span data-stu-id="f8218-376">To permit the debugging of a .NET application with a native runtime fix DLL, select managed and native code types (mixed mode debugging).</span></span>  

<span data-ttu-id="f8218-377">これ設定したら、デスクトップ アプリケーションのコードとランタイム fix プロジェクトでのコード行の横にある破断点を設定できます。</span><span class="sxs-lookup"><span data-stu-id="f8218-377">Once you've set this up, you can set break points next to lines of code in the desktop application code and the runtime fix project.</span></span> <span data-ttu-id="f8218-378">ソース コード アプリケーションを持っていない場合は、ランタイム fix プロジェクト内のコード行の横にある破断点を設定することができます。</span><span class="sxs-lookup"><span data-stu-id="f8218-378">If you don't have the source code to your application, you'll be able to set break points only next to lines of code in your runtime fix project.</span></span>

>[!NOTE]
> <span data-ttu-id="f8218-379">Visual Studio を使用する最も簡単な開発おりエクスペリエンスをデバッグするには、いくつかの制限がありますが、このガイドの後でについて説明します適用できるその他のデバッグ手法。</span><span class="sxs-lookup"><span data-stu-id="f8218-379">While Visual Studio gives you the simplest development and debugging experience, there are some limitations, so later in this guide, we'll discuss other debugging techniques that you can apply.</span></span>

## <a name="create-a-runtime-fix"></a><span data-ttu-id="f8218-380">実行時の修正プログラムを作成します。</span><span class="sxs-lookup"><span data-stu-id="f8218-380">Create a runtime fix</span></span>

<span data-ttu-id="f8218-381">ランタイム修正問題を解決することは、代わりの機能を作成し、構成データを含む新しいランタイム修正を作成することができますがまだ存在しない場合は合理的です。</span><span class="sxs-lookup"><span data-stu-id="f8218-381">If there isn't yet a runtime fix for the issue that you want to resolve, you can create a new runtime fix by writing replacement functions and including any configuration data that makes sense.</span></span> <span data-ttu-id="f8218-382">各部分を見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="f8218-382">Let's look at each part.</span></span>

### <a name="replacement-functions"></a><span data-ttu-id="f8218-383">代わりの機能</span><span class="sxs-lookup"><span data-stu-id="f8218-383">Replacement functions</span></span>

<span data-ttu-id="f8218-384">最初に、MSIX コンテナーにアプリケーションの実行時に呼び出しが失敗する関数を特定します。</span><span class="sxs-lookup"><span data-stu-id="f8218-384">First, identify which function calls fail when your application runs in an MSIX container.</span></span> <span data-ttu-id="f8218-385">次に、代わりにランタイム マネージャーを置換関数を作成できます。</span><span class="sxs-lookup"><span data-stu-id="f8218-385">Then, you can create replacement functions that you'd like the runtime manager to call instead.</span></span> <span data-ttu-id="f8218-386">これではモダンなランタイム環境のルールに準拠する動作を関数の実装を置き換えることができます。</span><span class="sxs-lookup"><span data-stu-id="f8218-386">This gives you an opportunity to replace the implementation of a function with behavior that conforms to the rules of the modern runtime environment.</span></span>

<span data-ttu-id="f8218-387">Visual Studio では、このガイドの以前のバージョンで作成したランタイム fix プロジェクトを開きます。</span><span class="sxs-lookup"><span data-stu-id="f8218-387">In Visual Studio, open the runtime fix project that you created earlier in this guide.</span></span>

<span data-ttu-id="f8218-388">宣言、``SHIM_DEFINE_EXPORTS``マクロ用に含める文を追加して、`shim_framework.h`それぞれの上部にあります。CPP ファイルが、実行時の修正プログラムの機能を追加します。</span><span class="sxs-lookup"><span data-stu-id="f8218-388">Declare the ``SHIM_DEFINE_EXPORTS`` macro and then add a include statement for the `shim_framework.h` at the top of each .CPP file where you intend to add the functions of your runtime fix.</span></span>

```c++
#define SHIM_DEFINE_EXPORTS
#include <shim_framework.h>
```
>[!IMPORTANT]
><span data-ttu-id="f8218-389">確認、`SHIM_DEFINE_EXPORTS`含めるステートメントの前にマクロが表示されます。</span><span class="sxs-lookup"><span data-stu-id="f8218-389">Make sure that the `SHIM_DEFINE_EXPORTS` macro appears before the include statement.</span></span>

<span data-ttu-id="f8218-390">関数は、関数の同じ署名を作成できるユーザーは動作を変更します。</span><span class="sxs-lookup"><span data-stu-id="f8218-390">Create a function that has the same signature of the function who's behavior you want to modify.</span></span> <span data-ttu-id="f8218-391">ここを置き換える関数の例では、`MessageBoxW`関数。</span><span class="sxs-lookup"><span data-stu-id="f8218-391">Here's an example function that replaces the `MessageBoxW` function.</span></span>

```c++
auto MessageBoxWImpl = &::MessageBoxW;
int WINAPI MessageBoxWShim(
    _In_opt_ HWND hwnd,
    _In_opt_ LPCWSTR,
    _In_opt_ LPCWSTR caption,
    _In_ UINT type)
{
    return MessageBoxWImpl(hwnd, L"SUCCESS: This worked", caption, type);
}

DECLARE_SHIM(MessageBoxWImpl, MessageBoxWShim);
```

<span data-ttu-id="f8218-392">通話を`DECLARE_SHIM`マップ、`MessageBoxW`関数は、新しい置換関数にします。</span><span class="sxs-lookup"><span data-stu-id="f8218-392">The call to `DECLARE_SHIM` maps the `MessageBoxW` function to your new replacement function.</span></span> <span data-ttu-id="f8218-393">アプリケーションが通話しようとしたときに、`MessageBoxW`関数、関数を代わりに発信ことはできます。</span><span class="sxs-lookup"><span data-stu-id="f8218-393">When your application attempts to call the `MessageBoxW` function, it will call the replacement function instead.</span></span>

#### <a name="protect-against-recursive-calls-to-functions-in-runtime-fixes"></a><span data-ttu-id="f8218-394">再帰ランタイム修正における関数呼び出しから保護します。</span><span class="sxs-lookup"><span data-stu-id="f8218-394">Protect against recursive calls to functions in runtime fixes</span></span>

<span data-ttu-id="f8218-395">適用することができます (オプション)、`reentrancy_guard`再帰ランタイム修正における関数呼び出しを保護する関数を入力します。</span><span class="sxs-lookup"><span data-stu-id="f8218-395">You can optionally apply the `reentrancy_guard` type to your functions that protect against recursive calls to functions in runtime fixes.</span></span>

<span data-ttu-id="f8218-396">関数の値を置換を作成するなど、`CreateFile`関数。</span><span class="sxs-lookup"><span data-stu-id="f8218-396">For example, you might produce a replacement function for the `CreateFile` function.</span></span> <span data-ttu-id="f8218-397">実装を呼び出す、`CopyFile`の実装、`CopyFile`関数を呼び出す、`CreateFile`関数します。</span><span class="sxs-lookup"><span data-stu-id="f8218-397">Your implementation might call the `CopyFile` function, but the implementation of the `CopyFile` function might call the `CreateFile` function.</span></span> <span data-ttu-id="f8218-398">呼び出しを無限再帰サイクルに生じる、`CreateFile`関数。</span><span class="sxs-lookup"><span data-stu-id="f8218-398">This may lead to an infinite recursive cycle of calls to the `CreateFile` function.</span></span>

<span data-ttu-id="f8218-399">ついて詳しくは`reentrancy_guard` [authoring.md](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/Authoring.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="f8218-399">For more information on `reentrancy_guard` see [authoring.md](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/Authoring.md)</span></span>

### <a name="configuration-data"></a><span data-ttu-id="f8218-400">データの構成</span><span class="sxs-lookup"><span data-stu-id="f8218-400">Configuration data</span></span>

<span data-ttu-id="f8218-401">ランタイム修正に構成のデータを追加する場合に追加することを検討してください、``config.json``します。</span><span class="sxs-lookup"><span data-stu-id="f8218-401">If you want to add configuration data to your runtime fix, consider adding it to the ``config.json``.</span></span> <span data-ttu-id="f8218-402">使用するようにすると、`ShimQueryCurrentDllConfig`を簡単にそのデータを分析します。</span><span class="sxs-lookup"><span data-stu-id="f8218-402">That way, you can use the `ShimQueryCurrentDllConfig` to easily parse that data.</span></span> <span data-ttu-id="f8218-403">この例では、その構成ファイルからブール値、文字列値を解析します。</span><span class="sxs-lookup"><span data-stu-id="f8218-403">This example parses a boolean and string value from that configuration file.</span></span>

```c++
if (auto configRoot = ::ShimQueryCurrentDllConfig())
{
    auto& config = configRoot->as_object();

    if (auto enabledValue = config.try_get("enabled"))
    {
        g_enabled = enabledValue->as_boolean().get();
    }

    if (auto logPathValue = config.try_get("logPath"))
    {
        g_logPath = logPathValue->as_string().wstring();
    }
}
```

## <a name="other-debugging-techniques"></a><span data-ttu-id="f8218-404">その他の手法をデバッグ</span><span class="sxs-lookup"><span data-stu-id="f8218-404">Other debugging techniques</span></span>

<span data-ttu-id="f8218-405">Visual Studio を使用すると、最も簡単な開発およびデバッグ時のエクスペリエンス、中にいくつかの制限があります。</span><span class="sxs-lookup"><span data-stu-id="f8218-405">While Visual Studio gives you the simplest development and debugging experience, there are some limitations.</span></span>

<span data-ttu-id="f8218-406">最初に、f5 キーを押してデバッグと、.appx パッケージからインストールするのではなく、パッケージ レイアウト フォルダーのパスから柔軟なファイルを展開するアプリケーションを実行します。</span><span class="sxs-lookup"><span data-stu-id="f8218-406">First, F5 debugging runs the application by deploying loose files from the package layout folder path, rather than installing from a .appx package.</span></span>  <span data-ttu-id="f8218-407">[レイアウト] フォルダー通常がない同じセキュリティ制限インストール パッケージのフォルダーとします。</span><span class="sxs-lookup"><span data-stu-id="f8218-407">The layout folder typically does not have the same security restrictions as an installed package folder.</span></span> <span data-ttu-id="f8218-408">その結果、してできないことがありますランタイムの修正プログラムを適用するよりも前のパッケージ パス アクセス拒否エラーを再現します。</span><span class="sxs-lookup"><span data-stu-id="f8218-408">As a result, it may not be possible to reproduce package path access denial errors prior to applying a runtime fix.</span></span>

<span data-ttu-id="f8218-409">この問題に対処するには、f5 キーを押して柔軟なファイルの展開ではなく、.appx パッケージの展開を使用します。</span><span class="sxs-lookup"><span data-stu-id="f8218-409">To address this issue, use .appx package deployment rather than F5 loose file deployment.</span></span>  <span data-ttu-id="f8218-410">.Appx パッケージ ファイルを作成するには、上記のように Windows SDK から[MakeAppx](https://docs.microsoft.com/en-us/windows/desktop/appxpkg/make-appx-package--makeappx-exe-)ユーティリティを使用します。</span><span class="sxs-lookup"><span data-stu-id="f8218-410">To create a .appx package file, use the [MakeAppx](https://docs.microsoft.com/en-us/windows/desktop/appxpkg/make-appx-package--makeappx-exe-) utility from the Windows SDK, as described above.</span></span> <span data-ttu-id="f8218-411">またはから、Visual Studio 内アプリケーション プロジェクト ノードを右クリックして**ストア**を選択して->**アプリ パッケージを作成**します。</span><span class="sxs-lookup"><span data-stu-id="f8218-411">Or, from within Visual Studio, right-click your application project node and select **Store**->**Create App Packages**.</span></span>

<span data-ttu-id="f8218-412">Visual Studio の別の問題は、デバッガーが起動されるすべての子プロセスにアタッチするための組み込みのサポートがないことができます。</span><span class="sxs-lookup"><span data-stu-id="f8218-412">Another issue with Visual Studio is that it does not have built-in support for attaching to any child processes launched by the debugger.</span></span>   <span data-ttu-id="f8218-413">関連付ける必要があります手動で Visual Studio で起動した後、ターゲット アプリケーションの起動パスのロジックをデバッグする困難になります。</span><span class="sxs-lookup"><span data-stu-id="f8218-413">This makes it difficult to debug logic in the startup path of the target application, which must be manually attached by Visual Studio after launch.</span></span>

<span data-ttu-id="f8218-414">この問題を解決するには、使用子プロセスをサポートしているデバッガーを添付します。</span><span class="sxs-lookup"><span data-stu-id="f8218-414">To address this issue, use a debugger that supports child process attach.</span></span>  <span data-ttu-id="f8218-415">一般的に対象のアプリケーションにだけの時間 (JIT) デバッガーを添付することに注意してください。</span><span class="sxs-lookup"><span data-stu-id="f8218-415">Note that it is generally not possible to attach a just-in-time (JIT) debugger to the target application.</span></span>  <span data-ttu-id="f8218-416">これは、ほとんど JIT 技法 ImageFileExecutionOptions のレジストリ キーを使用して、ターゲット アプリケーションの代わりにデバッガーを起動するためです。</span><span class="sxs-lookup"><span data-stu-id="f8218-416">This is because most JIT techniques involve launching the debugger in place of the target app, via the ImageFileExecutionOptions registry key.</span></span>  <span data-ttu-id="f8218-417">ターゲット アプリケーションに ShimRuntime.dll を挿入する ShimLauncher.exe で使用される detouring メカニズムこの無効になります。</span><span class="sxs-lookup"><span data-stu-id="f8218-417">This defeats the detouring mechanism used by ShimLauncher.exe to inject ShimRuntime.dll into the target app.</span></span>  <span data-ttu-id="f8218-418">サポート子プロセスを添付する WinDbg、 [Windows 用デバッグ ツール](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/index)に含まれているし、 [Windows SDK](https://developer.microsoft.com/en-US/windows/downloads/windows-10-sdk)から取得します。</span><span class="sxs-lookup"><span data-stu-id="f8218-418">WinDbg, included in the [Debugging Tools for Windows](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/index), and obtained from the [Windows SDK](https://developer.microsoft.com/en-US/windows/downloads/windows-10-sdk), supports child process attach.</span></span>  <span data-ttu-id="f8218-419">また、サポート直接[を起動して UWP のアプリをデバッグ](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/debugging-a-uwp-app-using-windbg#span-idlaunchinganddebuggingauwpappspanspan-idlaunchinganddebuggingauwpappspanspan-idlaunchinganddebuggingauwpappspanlaunching-and-debugging-a-uwp-app)します。</span><span class="sxs-lookup"><span data-stu-id="f8218-419">It also now supports directly [launching and debugging a UWP app](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/debugging-a-uwp-app-using-windbg#span-idlaunchinganddebuggingauwpappspanspan-idlaunchinganddebuggingauwpappspanspan-idlaunchinganddebuggingauwpappspanlaunching-and-debugging-a-uwp-app).</span></span>

<span data-ttu-id="f8218-420">子プロセスとしてターゲット アプリケーションの起動をデバッグするには、開始``WinDbg``します。</span><span class="sxs-lookup"><span data-stu-id="f8218-420">To debug target application startup as a child process, start ``WinDbg``.</span></span>

```
windbg.exe -plmPackage PSFSampleWithFixup_1.0.59.0_x86__7s220nvg1hg3m -plmApp PSFSample
```

<span data-ttu-id="f8218-421">``WinDbg``メッセージを表示する、子デバッグを有効化および適切なブレークポイントを設定します。</span><span class="sxs-lookup"><span data-stu-id="f8218-421">At the ``WinDbg`` prompt, enable child debugging and set appropriate breakpoints.</span></span>

```
.childdbg 1
g
```
<span data-ttu-id="f8218-422">(実行ターゲット アプリケーションを起動して、改ページになるまで)</span><span class="sxs-lookup"><span data-stu-id="f8218-422">(execute until target application starts and breaks into the debugger)</span></span>

```
sxe ld fixup.dll
g
```
<span data-ttu-id="f8218-423">(実行が読み込ま修正まで)</span><span class="sxs-lookup"><span data-stu-id="f8218-423">(execute until the fixup DLL is loaded)</span></span>

```
bp ...
```

>[!NOTE]
> <span data-ttu-id="f8218-424">[PLMDebug](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/plmdebug)がデバッガー起動時には、アプリにも使用でき、 [Windows 用デバッグ ツール](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/index)にも含まれています。</span><span class="sxs-lookup"><span data-stu-id="f8218-424">[PLMDebug](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/plmdebug) can be also used to attach a debugger to an app upon launch, and is also included in the [Debugging Tools for Windows](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/index).</span></span>  <span data-ttu-id="f8218-425">ただしは、WinDbg によって提供されるようになりました直接サポートよりも複雑です。</span><span class="sxs-lookup"><span data-stu-id="f8218-425">However, it is more complex to use than the direct support now provided by WinDbg.</span></span>

## <a name="support-and-feedback"></a><span data-ttu-id="f8218-426">サポートとフィードバック</span><span class="sxs-lookup"><span data-stu-id="f8218-426">Support and feedback</span></span>

**<span data-ttu-id="f8218-427">質問に対する回答を見つける</span><span class="sxs-lookup"><span data-stu-id="f8218-427">Find answers to your questions</span></span>**

<span data-ttu-id="f8218-428">ご質問がある場合は、</span><span class="sxs-lookup"><span data-stu-id="f8218-428">Have questions?</span></span> <span data-ttu-id="f8218-429">Stack Overflow でお問い合わせください。</span><span class="sxs-lookup"><span data-stu-id="f8218-429">Ask us on Stack Overflow.</span></span> <span data-ttu-id="f8218-430">Microsoft のチームでは、これらの[タグ](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge)をチェックしています。</span><span class="sxs-lookup"><span data-stu-id="f8218-430">Our team monitors these [tags](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge).</span></span> <span data-ttu-id="f8218-431">[こちら](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D)から質問することもできます。</span><span class="sxs-lookup"><span data-stu-id="f8218-431">You can also ask us [here](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D).</span></span>
