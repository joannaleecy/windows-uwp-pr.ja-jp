---
author: normesta
Description: Fix issues that prevent your desktop application from running in an MSIX container
Search.Product: eADQiWindows 10XVcnh
title: MSIX コンテナーで実行してから、デスクトップのアプリケーションを妨げる問題を修正します。
ms.author: normesta
ms.date: 07/02/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 46d5705233af9e8254b9ac89a2d6e9891e90701f
ms.sourcegitcommit: 9c79fdab9039ff592edf7984732d300a14e81d92
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/23/2018
ms.locfileid: "2815514"
---
# <a name="apply-runtime-fixes-to-an-msix-package-by-using-the-package-support-framework"></a><span data-ttu-id="f8956-103">MSIX パッケージにパッケージのサポートのフレームワークを使用して、実行時の修正プログラムを適用します。</span><span class="sxs-lookup"><span data-stu-id="f8956-103">Apply runtime fixes to an MSIX package by using the Package Support Framework</span></span>

<span data-ttu-id="f8956-104">パッケージのサポート、フレームワークは、修正を適用、既存の win32 アプリケーション、ソース コードへのアクセスがないとき MSIX コンテナーで実行できるようにするために役立つオープン ソースのキットです。</span><span class="sxs-lookup"><span data-stu-id="f8956-104">The Package Support Framework is an open source kit that helps you apply fixes to your existing win32 application when you don't have access to the source code, so that it can run in an MSIX container.</span></span> <span data-ttu-id="f8956-105">パッケージのサポート、フレームワークは、アプリケーションの最新のランタイム環境のベスト プラクティスに従うことができます。</span><span class="sxs-lookup"><span data-stu-id="f8956-105">The Package Support Framework helps your application follow the best practices of the modern runtime environment.</span></span>

<span data-ttu-id="f8956-106">パッケージ サポート フレームワークを作成するには、[回り道](https://www.microsoft.com/en-us/research/project/detours)テクノロジによって、Microsoft の研究 (MSR) を開発、オープン ソースのフレームワークと API のリダイレクトのフックを活用できます。</span><span class="sxs-lookup"><span data-stu-id="f8956-106">To create the Package Support Framework, we leveraged the [Detours](https://www.microsoft.com/en-us/research/project/detours) technology which is an open source framework developed by Microsoft Research (MSR) and helps with API redirection and hooking.</span></span>

<span data-ttu-id="f8956-107">このフレームワークは、オープン ソース、軽量、アプリケーションの問題に対処する簡単に使用できます。</span><span class="sxs-lookup"><span data-stu-id="f8956-107">This framework is open source, lightweight, and you can use it to address application issues quickly.</span></span> <span data-ttu-id="f8956-108">、世界のコミュニティに相談して、他の投資の上に構築する機会も提供します。</span><span class="sxs-lookup"><span data-stu-id="f8956-108">It also gives you the opportunity to consult with the community around the globe, and to build on top of the investments of others.</span></span>

## <a name="a-quick-look-inside-of-the-package-support-framework"></a><span data-ttu-id="f8956-109">パッケージ サポート フレームワーク内で簡単に説明</span><span class="sxs-lookup"><span data-stu-id="f8956-109">A quick look inside of the Package Support Framework</span></span>

<span data-ttu-id="f8956-110">パッケージ サポート フレームワークには、実行可能ファイル、実行時マネージャー DLL、および実行時の修正モジュールが含まれています。</span><span class="sxs-lookup"><span data-stu-id="f8956-110">The Package Support Framework contains an executable, a runtime manager  DLL, and a set of runtime fixes.</span></span>

![パッケージ サポート フレームワーク](images/desktop-to-uwp/package-support-framework.png)

<span data-ttu-id="f8956-112">しくみは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="f8956-112">Here's how it works.</span></span> <span data-ttu-id="f8956-113">アプリケーションに適用する fix(s) を指定する構成ファイルを作成します。</span><span class="sxs-lookup"><span data-stu-id="f8956-113">You'll create a configuration file that specifies the fix(s) that you want to apply to your application.</span></span> <span data-ttu-id="f8956-114">その後、シム起動プログラムの実行可能ファイルを指すように、パッケージを変更してみましょう。</span><span class="sxs-lookup"><span data-stu-id="f8956-114">Then, you'll modify your package to point to the shim launcher executable file.</span></span>

<span data-ttu-id="f8956-115">ユーザーがアプリケーションを起動するとシム起動プログラムを実行する最初の実行可能ファイルです。</span><span class="sxs-lookup"><span data-stu-id="f8956-115">When users start your application, the shim launcher is the first executable that runs.</span></span> <span data-ttu-id="f8956-116">構成ファイルを読み取りし、ランタイム fix(s) とランタイム マネージャー DLL をアプリケーションのプロセスに挿入します。</span><span class="sxs-lookup"><span data-stu-id="f8956-116">It reads your configuration file, and injects the runtime fix(s) and the runtime manager  DLL into the application process.</span></span>

![パッケージ サポート フレームワークの DLL インジェクション](images/desktop-to-uwp/package-support-framework-2.png)

<span data-ttu-id="f8956-118">ランタイム マネージャーでは、MSIX、コンテナーの内部で実行するアプリケーションで必要な場合にこの修正プログラムが適用されます。</span><span class="sxs-lookup"><span data-stu-id="f8956-118">The runtime manager applies the fix when it's needed by the application to run inside of an MSIX container.</span></span>

<span data-ttu-id="f8956-119">このガイドは、アプリケーション互換性の問題を識別するには役立ち、それらに対処する修正を検索して、このオプションを適用すると、ランタイムを拡張します。</span><span class="sxs-lookup"><span data-stu-id="f8956-119">This guide will help you to identify application compatibility issues, and to find, apply, and extend runtime fixes that address them.</span></span>

<a id="identify" />

## <a name="identify-packaged-application-compatibility-issues"></a><span data-ttu-id="f8956-120">パッケージ化されたアプリケーション互換性問題を特定します。</span><span class="sxs-lookup"><span data-stu-id="f8956-120">Identify packaged application compatibility issues</span></span>

<span data-ttu-id="f8956-121">最初に、アプリケーションのパッケージを作成します。</span><span class="sxs-lookup"><span data-stu-id="f8956-121">First, create a package for your application.</span></span> <span data-ttu-id="f8956-122">それをインストール、実行し、その動作を観察します。</span><span class="sxs-lookup"><span data-stu-id="f8956-122">Then, install it, run it, and observe its behavior.</span></span> <span data-ttu-id="f8956-123">互換性の問題の特定に役立つエラー メッセージが表示されます可能性があります。</span><span class="sxs-lookup"><span data-stu-id="f8956-123">You might receive error messages that can help you identify a compatibility issue.</span></span> <span data-ttu-id="f8956-124">[プロセス モニター](https://docs.microsoft.com/en-us/sysinternals/downloads/procmon)は、問題を特定するのにも使用できます。</span><span class="sxs-lookup"><span data-stu-id="f8956-124">You can also use [Process Monitor](https://docs.microsoft.com/en-us/sysinternals/downloads/procmon) to identify issues.</span></span>  <span data-ttu-id="f8956-125">一般的な問題は、作業ディレクトリとプログラムのパスのアクセス許可に関する暫定要素をアプリケーションに関連します。</span><span class="sxs-lookup"><span data-stu-id="f8956-125">Common issues relate to application assumptions regarding the working directory and program path permissions.</span></span>

### <a name="using-process-monitor-to-identify-an-issue"></a><span data-ttu-id="f8956-126">プロセス モニターを使用して問題を識別するには</span><span class="sxs-lookup"><span data-stu-id="f8956-126">Using Process Monitor to identify an issue</span></span>

<span data-ttu-id="f8956-127">[プロセス モニター](https://docs.microsoft.com/en-us/sysinternals/downloads/procmon)は、アプリケーションのファイルとレジストリの操作とその結果を観察するための強力なユーティリティです。</span><span class="sxs-lookup"><span data-stu-id="f8956-127">[Process Monitor](https://docs.microsoft.com/en-us/sysinternals/downloads/procmon) is a powerful utility for observing an app's file and registry operations, and their results.</span></span>  <span data-ttu-id="f8956-128">アプリケーションの互換性の問題を理解することができます。</span><span class="sxs-lookup"><span data-stu-id="f8956-128">This can help you to understand application compatibility issues.</span></span>  <span data-ttu-id="f8956-129">プロセス モニターを開くには、フィルターを追加します (フィルター > フィルター...) にアプリケーションの実行可能ファイルからのイベントのみが含まれます。</span><span class="sxs-lookup"><span data-stu-id="f8956-129">After opening Process Monitor, add a filter (Filter > Filter…) to include only events from the application executable.</span></span>

![ProcMon のアプリケーション フィルター](images/desktop-to-uwp/procmon_app_filter.png)

<span data-ttu-id="f8956-131">イベントの一覧が表示されます。</span><span class="sxs-lookup"><span data-stu-id="f8956-131">A list of events will appear.</span></span> <span data-ttu-id="f8956-132">これらのイベントの多くにとって、単語**の成功**が表示されます [**結果**] 列で。</span><span class="sxs-lookup"><span data-stu-id="f8956-132">For many of these events, the word **SUCCESS** will appear in the **Result** column.</span></span>

![ProcMon のイベント](images/desktop-to-uwp/procmon_events.png)

<span data-ttu-id="f8956-134">オプションでのみエラーだけを表示するイベントをフィルター処理できます。</span><span class="sxs-lookup"><span data-stu-id="f8956-134">Optionally, you can filter events to only show only failures.</span></span>

![ProcMon の除外の成功](images/desktop-to-uwp/procmon_exclude_success.png)

<span data-ttu-id="f8956-136">ファイル ・ システム ・ アクセスの障害が疑われる場合は、[System32/SysWOW64] または [パッケージ ファイルのパスが失敗したイベントを検索します。</span><span class="sxs-lookup"><span data-stu-id="f8956-136">If you suspect a filesystem access failure, search for failed events that are under either the System32/SysWOW64 or the package file path.</span></span> <span data-ttu-id="f8956-137">フィルターにも役立ちます、すぎます。</span><span class="sxs-lookup"><span data-stu-id="f8956-137">Filters can also help here, too.</span></span> <span data-ttu-id="f8956-138">このリストの下部に起動し、上方向にスクロールします。</span><span class="sxs-lookup"><span data-stu-id="f8956-138">Start at the bottom of this list and scroll upwards.</span></span> <span data-ttu-id="f8956-139">このリストの下部に表示されたエラーが最近発生しています。</span><span class="sxs-lookup"><span data-stu-id="f8956-139">Failures that appear at the bottom of this list have occurred most recently.</span></span> <span data-ttu-id="f8956-140">エラー「アクセスが拒否されると、」などの文字列が含まれていると「のパスと名前が見つかりません」、ほとんどの注意を払うし、不審な外観がないことを無視します。</span><span class="sxs-lookup"><span data-stu-id="f8956-140">Pay most attention to errors that contain strings such as "access denied," and "path/name not found", and ignore things that don't look suspicious.</span></span> <span data-ttu-id="f8956-141">[PSFSample](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/samples/PSFSample/)では、2 つの問題があります。</span><span class="sxs-lookup"><span data-stu-id="f8956-141">The [PSFSample](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/samples/PSFSample/) has two issues.</span></span> <span data-ttu-id="f8956-142">次の図に表示される一覧でそれらの問題を確認できます。</span><span class="sxs-lookup"><span data-stu-id="f8956-142">You can see those issues in the list that appears in the following image.</span></span>

![ProcMon Config.txt](images/desktop-to-uwp/procmon_config_txt.png)

<span data-ttu-id="f8956-144">このイメージに表示される最初の問題、アプリケーションは、"C:\Windows\SysWOW64"のパスにある"Config.txt"ファイルからの読み取りに失敗しています。</span><span class="sxs-lookup"><span data-stu-id="f8956-144">In the first issue that appears in this image, the application is failing to read from the "Config.txt" file that is located in the "C:\Windows\SysWOW64" path.</span></span> <span data-ttu-id="f8956-145">アプリケーションがそのパスを直接参照しようとしている可能性が高いことはできません。</span><span class="sxs-lookup"><span data-stu-id="f8956-145">It's unlikely that the application is trying to reference that path directly.</span></span> <span data-ttu-id="f8956-146">、相対パスを使用してそのファイルを読み書きしようとして、"System32/SysWOW64"は、アプリケーションの作業ディレクトリを既定では、ほとんどの場合、です。</span><span class="sxs-lookup"><span data-stu-id="f8956-146">Most likely, it's trying to read from that file by using a relative path, and by default, "System32/SysWOW64" is the application's working directory.</span></span> <span data-ttu-id="f8956-147">これは、アプリケーションがパッケージのどこかに設定する、現在の作業ディレクトリを待っていることを示しています。</span><span class="sxs-lookup"><span data-stu-id="f8956-147">This suggests that the application is expecting its current working directory to be set to somewhere in the package.</span></span> <span data-ttu-id="f8956-148">Appx の内部で見ると、実行可能ファイルと同じディレクトリにファイルが存在することを確認できます。</span><span class="sxs-lookup"><span data-stu-id="f8956-148">Looking inside of the appx, we can see that the file exists in the same directory as the executable.</span></span>

![アプリ Config.txt](images/desktop-to-uwp/psfsampleapp_config_txt.png)

<span data-ttu-id="f8956-150">2 番目の問題は、次の図に表示されます。</span><span class="sxs-lookup"><span data-stu-id="f8956-150">The second issue appears in the following image.</span></span>

![ProcMon のログ ファイル](images/desktop-to-uwp/procmon_logfile.png)

<span data-ttu-id="f8956-152">この問題では、アプリケーションは、そのパッケージのパスに .log ファイルを書き込むに失敗しています。</span><span class="sxs-lookup"><span data-stu-id="f8956-152">In this issue, the application is failing to write a .log file to its package path.</span></span> <span data-ttu-id="f8956-153">ファイルのリダイレクトの shim が役立つ場合がありますこれを推奨します。</span><span class="sxs-lookup"><span data-stu-id="f8956-153">This would suggest that a file redirection shim might help.</span></span>

<a id="find" />

## <a name="find-a-runtime-fix"></a><span data-ttu-id="f8956-154">実行時の修正プログラムを検索します。</span><span class="sxs-lookup"><span data-stu-id="f8956-154">Find a runtime fix</span></span>

<span data-ttu-id="f8956-155">PSF には、ファイルのリダイレクトのシムなど今すぐに使用できるランタイムの修正プログラムが含まれています。</span><span class="sxs-lookup"><span data-stu-id="f8956-155">The PSF contains runtime fixes that you can use right now, such as the file redirection shim.</span></span>

### <a name="file-redirection-shim"></a><span data-ttu-id="f8956-156">ファイルのリダイレクトのシム</span><span class="sxs-lookup"><span data-stu-id="f8956-156">File Redirection Shim</span></span>

<span data-ttu-id="f8956-157">書き込みまたは MSIX コンテナーで実行されるアプリケーションからアクセス可能ではないディレクトリ内のデータの読み取りの試行をリダイレクトするのには、[ファイルのリダイレクトの Shim](https://github.com/Microsoft/MSIX-PackageSupportFramework/tree/develop/FileRedirectionShim)を使用できます。</span><span class="sxs-lookup"><span data-stu-id="f8956-157">You can use the [File Redirection Shim](https://github.com/Microsoft/MSIX-PackageSupportFramework/tree/develop/FileRedirectionShim) to redirect attempts to write or read data in a directory that isn't accessible from an application that runs in an MSIX container.</span></span>

<span data-ttu-id="f8956-158">などの場合は、アプリケーション、アプリケーションの実行可能ファイルと同じディレクトリにあるログ ファイルに書き込むと、ローカル アプリケーションのデータ ストアなど、別の場所にログ ファイルを作成する[ファイルのリダイレクトの Shim](https://github.com/Microsoft/MSIX-PackageSupportFramework/tree/develop/FileRedirectionShim)を使用できます。</span><span class="sxs-lookup"><span data-stu-id="f8956-158">For example, if your application writes to a log file that is in the same directory as your applications executable, then you can use the [File Redirection Shim](https://github.com/Microsoft/MSIX-PackageSupportFramework/tree/develop/FileRedirectionShim) to create that log file in another location, such as the local app data store.</span></span>

### <a name="runtime-fixes-from-the-community"></a><span data-ttu-id="f8956-159">コミュニティからの実行時の修正</span><span class="sxs-lookup"><span data-stu-id="f8956-159">Runtime fixes from the community</span></span>

<span data-ttu-id="f8956-160">[GitHub](https://github.com/Microsoft/MSIX-PackageSupportFramework/tree/develop)ページにコミュニティの貢献度を確認してください。</span><span class="sxs-lookup"><span data-stu-id="f8956-160">Make sure to review the community contributions to our [GitHub](https://github.com/Microsoft/MSIX-PackageSupportFramework/tree/develop) page.</span></span> <span data-ttu-id="f8956-161">他の開発者が自分のような問題を解決したし、実行時の修正プログラムを共有しています。</span><span class="sxs-lookup"><span data-stu-id="f8956-161">It's possible that other developers have resolved an issue similar to yours and have shared a runtime fix.</span></span>

## <a name="apply-a-runtime-fix"></a><span data-ttu-id="f8956-162">実行時の修正プログラムを適用します。</span><span class="sxs-lookup"><span data-stu-id="f8956-162">Apply a runtime fix</span></span>

<span data-ttu-id="f8956-163">Windows sdk、および次の手順では、いくつかの簡単なツールを使用して既存の実行時の修正を適用できます。</span><span class="sxs-lookup"><span data-stu-id="f8956-163">You can apply an existing runtime fix with a few simple tools from the Windows SDK, and by following these steps.</span></span>

> [!div class="checklist"]
> * <span data-ttu-id="f8956-164">パッケージ レイアウト フォルダーを作成します。</span><span class="sxs-lookup"><span data-stu-id="f8956-164">Create a package layout folder</span></span>
> * <span data-ttu-id="f8956-165">パッケージ サポート フレームワーク ファイルを取得します。</span><span class="sxs-lookup"><span data-stu-id="f8956-165">Get the Package Support Framework files</span></span>
> * <span data-ttu-id="f8956-166">パッケージに追加します。</span><span class="sxs-lookup"><span data-stu-id="f8956-166">Add them to your package</span></span>
> * <span data-ttu-id="f8956-167">パッケージ マニフェストの変更</span><span class="sxs-lookup"><span data-stu-id="f8956-167">Modify the package manifest</span></span>
> * <span data-ttu-id="f8956-168">構成ファイルを作成します。</span><span class="sxs-lookup"><span data-stu-id="f8956-168">Create a configuration file</span></span>

<span data-ttu-id="f8956-169">各タスクから見ていきましょう。</span><span class="sxs-lookup"><span data-stu-id="f8956-169">Let's go through each task.</span></span>

### <a name="create-the-package-layout-folder"></a><span data-ttu-id="f8956-170">パッケージ レイアウト フォルダーを作成します。</span><span class="sxs-lookup"><span data-stu-id="f8956-170">Create the package layout folder</span></span>

<span data-ttu-id="f8956-171">.Appx ファイルが既にある場合場合、パッケージのステージング領域として使用するレイアウト フォルダーにその内容をアンパックすることができます。</span><span class="sxs-lookup"><span data-stu-id="f8956-171">If you have a .appx file already, you can unpack its contents into a layout folder that will serve as the staging area for your package.</span></span>  <span data-ttu-id="f8956-172">これを行うことができます、 **x64 VS 2017 のネイティブ ツールのコマンド プロンプト**、または手動で実行可能ファイルの検索パスに、SDK の bin パスです。</span><span class="sxs-lookup"><span data-stu-id="f8956-172">You can do this from an **x64 Native Tools Command Prompt for VS 2017**, or manually with the SDK bin path in the executable search path.</span></span>

```
makeappx unpack /p PSFSamplePackage_1.0.60.0_AnyCPU_Debug.appx /d PackageContents

```

<span data-ttu-id="f8956-173">これにより、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="f8956-173">This will give you something that looks like the following.</span></span>

![パッケージ レイアウト](images/desktop-to-uwp/package_contents.png)

<span data-ttu-id="f8956-175">お持ちでない .appx ファイルで起動する場合は、最初からパッケージのフォルダーとファイルを作成できます。</span><span class="sxs-lookup"><span data-stu-id="f8956-175">If you don't have a .appx file to start with, you can create the package folder and files from scratch.</span></span>

### <a name="get-the-package-support-framework-files"></a><span data-ttu-id="f8956-176">パッケージ サポート フレームワーク ファイルを取得します。</span><span class="sxs-lookup"><span data-stu-id="f8956-176">Get the Package Support Framework files</span></span>

<span data-ttu-id="f8956-177">PSF Nuget のパッケージは、Visual Studio を使用して取得できます。</span><span class="sxs-lookup"><span data-stu-id="f8956-177">You can get the PSF Nuget package by using Visual Studio.</span></span> <span data-ttu-id="f8956-178">スタンドアロンの Nuget のコマンド ライン ツールを使用しても取得できます。</span><span class="sxs-lookup"><span data-stu-id="f8956-178">You can also get it by using the standalone Nuget command line tool.</span></span>

#### <a name="get-the-package-by-using-visual-studio"></a><span data-ttu-id="f8956-179">Visual Studio を使用してパッケージを取得します。</span><span class="sxs-lookup"><span data-stu-id="f8956-179">Get the package by using Visual Studio</span></span>

<span data-ttu-id="f8956-180">Visual Studio では、ソリューションまたはプロジェクト ノードを右クリックし、Nuget パッケージの管理コマンドのいずれかを選択します。</span><span class="sxs-lookup"><span data-stu-id="f8956-180">In Visual Studio, right-click your solution or project node and pick one of the Manage Nuget Packages commands.</span></span>  <span data-ttu-id="f8956-181">Nuget.org でパッケージを検索するには、 **Microsoft.PackageSupportFramework**または**PSF**を検索します。その後、それをインストールします。</span><span class="sxs-lookup"><span data-stu-id="f8956-181">Search for **Microsoft.PackageSupportFramework** or **PSF** to find the package on Nuget.org. Then, install it.</span></span>

#### <a name="get-the-package-by-using-the-command-line-tool"></a><span data-ttu-id="f8956-182">コマンド ライン ツールを使用してパッケージを取得します。</span><span class="sxs-lookup"><span data-stu-id="f8956-182">Get the package by using the command line tool</span></span>

<span data-ttu-id="f8956-183">この場所から、Nuget のコマンド ライン ツールをインストールする: https://www.nuget.org/downloads。</span><span class="sxs-lookup"><span data-stu-id="f8956-183">Install the Nuget command line tool from this location: https://www.nuget.org/downloads.</span></span> <span data-ttu-id="f8956-184">Nuget のコマンド ・ ラインからは、このコマンドを実行します。</span><span class="sxs-lookup"><span data-stu-id="f8956-184">Then, from the Nuget command line, run this command:</span></span>

```
nuget install Microsoft.PackageSupportFramework
```

### <a name="add-the-package-support-framework-files-to-your-package"></a><span data-ttu-id="f8956-185">パッケージ サポート フレームワーク ファイルをパッケージに追加します。</span><span class="sxs-lookup"><span data-stu-id="f8956-185">Add the Package Support Framework files to your package</span></span>

<span data-ttu-id="f8956-186">パッケージ ディレクトリに必要な 32 ビットおよび 64 ビットの PSF Dll や実行可能ファイルを追加します。</span><span class="sxs-lookup"><span data-stu-id="f8956-186">Add the required 32-bit and 64-bit PSF  DLLs and executable files to the package directory.</span></span> <span data-ttu-id="f8956-187">次の表をガイドとして使用してください。</span><span class="sxs-lookup"><span data-stu-id="f8956-187">Use the following table as a guide.</span></span> <span data-ttu-id="f8956-188">する必要がある、実行時の修正が含まれてもします。</span><span class="sxs-lookup"><span data-stu-id="f8956-188">You'll also want to include any runtime fixes that you need.</span></span> <span data-ttu-id="f8956-189">この例では、ファイルのリダイレクトの実行時の修正プログラムが必要です。</span><span class="sxs-lookup"><span data-stu-id="f8956-189">In our example, we need the file redirection runtime fix.</span></span>

| <span data-ttu-id="f8956-190">アプリケーション実行可能ファイルは、x64 です。</span><span class="sxs-lookup"><span data-stu-id="f8956-190">Application executable is x64</span></span> | <span data-ttu-id="f8956-191">アプリケーション実行可能ファイルは、x86 です。</span><span class="sxs-lookup"><span data-stu-id="f8956-191">Application executable is x86</span></span> |
|-------------------------------|-----------|
| [<span data-ttu-id="f8956-192">ShimLauncher64.exe</span><span class="sxs-lookup"><span data-stu-id="f8956-192">ShimLauncher64.exe</span></span>](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/ShimLauncher/readme.md) |  [<span data-ttu-id="f8956-193">ShimLauncher32.exe</span><span class="sxs-lookup"><span data-stu-id="f8956-193">ShimLauncher32.exe</span></span>](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/ShimLauncher/readme.md) |
| [<span data-ttu-id="f8956-194">ShimRuntime64.dll</span><span class="sxs-lookup"><span data-stu-id="f8956-194">ShimRuntime64.dll</span></span>](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/ShimRuntime/readme.md) | [<span data-ttu-id="f8956-195">ShimRuntime32.dll</span><span class="sxs-lookup"><span data-stu-id="f8956-195">ShimRuntime32.dll</span></span>](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/ShimRuntime/readme.md) |
| [<span data-ttu-id="f8956-196">ShimRunDll64.exe</span><span class="sxs-lookup"><span data-stu-id="f8956-196">ShimRunDll64.exe</span></span>](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/ShimRunDll/readme.md) | [<span data-ttu-id="f8956-197">ShimRunDll32.exe</span><span class="sxs-lookup"><span data-stu-id="f8956-197">ShimRunDll32.exe</span></span>](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/ShimRunDll/readme.md) |

<span data-ttu-id="f8956-198">パッケージの内容は次のようになります。</span><span class="sxs-lookup"><span data-stu-id="f8956-198">Your package content should now look something like this.</span></span>

![パッケージのバイナリ](images/desktop-to-uwp/package_binaries.png)

### <a name="modify-the-package-manifest"></a><span data-ttu-id="f8956-200">パッケージ マニフェストの変更</span><span class="sxs-lookup"><span data-stu-id="f8956-200">Modify the package manifest</span></span>

<span data-ttu-id="f8956-201">テキスト エディターで、パッケージ マニフェストを開き、設定し、`Executable`の属性、`Application`シム起動プログラムの実行可能ファイルの名前の要素です。</span><span class="sxs-lookup"><span data-stu-id="f8956-201">Open your package manifest in a text editor, and then set the `Executable` attribute of the `Application` element to the name of the shim launcher executable file.</span></span>  <span data-ttu-id="f8956-202">ターゲット アプリケーションのアーキテクチャがわかっている場合は、ShimLauncher32.exe または ShimLauncher64.exe は、適切なバージョンを選択します。</span><span class="sxs-lookup"><span data-stu-id="f8956-202">If you know the architecture of your target application, select the appropriate version, ShimLauncher32.exe or ShimLauncher64.exe.</span></span>  <span data-ttu-id="f8956-203">いない場合は、ShimLauncher32.exe は常に動作します。</span><span class="sxs-lookup"><span data-stu-id="f8956-203">If not, ShimLauncher32.exe will work in all cases.</span></span>  <span data-ttu-id="f8956-204">次に例を示します。</span><span class="sxs-lookup"><span data-stu-id="f8956-204">Here's an example.</span></span>

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

### <a name="create-a-configuration-file"></a><span data-ttu-id="f8956-205">構成ファイルを作成します。</span><span class="sxs-lookup"><span data-stu-id="f8956-205">Create a configuration file</span></span>

<span data-ttu-id="f8956-206">ファイル名を作成する``config.json``、パッケージのルート フォルダーにそのファイルを保存するとします。</span><span class="sxs-lookup"><span data-stu-id="f8956-206">Create a file name ``config.json``, and save that file to the root folder of your package.</span></span> <span data-ttu-id="f8956-207">交換した実行可能ファイルを指すように config.json ファイルの宣言されたアプリケーション ID を変更します。</span><span class="sxs-lookup"><span data-stu-id="f8956-207">Modify the declared app ID of the config.json file to point to the executable that you just replaced.</span></span> <span data-ttu-id="f8956-208">プロセス モニターを使用してから増加した知識を活用するとすることも作業ディレクトリを設定、および相対パッケージの"PSFSampleApp"ディレクトリの下の .log ファイルに読み取り/書き込みをリダイレクトするのには、ファイルのリダイレクトの shim を使用します。</span><span class="sxs-lookup"><span data-stu-id="f8956-208">Using the knowledge that you gained from using Process Monitor, you can also set the working directory as well as use the file redirection shim to redirect reads/writes to .log files under the package-relative "PSFSampleApp" directory.</span></span>

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
<span data-ttu-id="f8956-209">以下は、config.json スキーマのためのガイドです。</span><span class="sxs-lookup"><span data-stu-id="f8956-209">Following is a guide for the config.json schema:</span></span>

| <span data-ttu-id="f8956-210">配列</span><span class="sxs-lookup"><span data-stu-id="f8956-210">Array</span></span> | <span data-ttu-id="f8956-211">key</span><span class="sxs-lookup"><span data-stu-id="f8956-211">key</span></span> | <span data-ttu-id="f8956-212">値</span><span class="sxs-lookup"><span data-stu-id="f8956-212">Value</span></span> |
|-------|-----------|-------|
| <span data-ttu-id="f8956-213">applications</span><span class="sxs-lookup"><span data-stu-id="f8956-213">applications</span></span> | <span data-ttu-id="f8956-214">id</span><span class="sxs-lookup"><span data-stu-id="f8956-214">id</span></span> |  <span data-ttu-id="f8956-215">値を使用して、`Id`の属性、`Application`パッケージ マニフェスト内の要素。</span><span class="sxs-lookup"><span data-stu-id="f8956-215">Use the value of the `Id` attribute of the `Application` element in the package manifest.</span></span> |
| <span data-ttu-id="f8956-216">applications</span><span class="sxs-lookup"><span data-stu-id="f8956-216">applications</span></span> | <span data-ttu-id="f8956-217">実行可能</span><span class="sxs-lookup"><span data-stu-id="f8956-217">executable</span></span> | <span data-ttu-id="f8956-218">起動する実行可能ファイルへのパッケージの相対パス。</span><span class="sxs-lookup"><span data-stu-id="f8956-218">The package-relative path to the executable that you want to start.</span></span> <span data-ttu-id="f8956-219">ほとんどの場合、それを変更する前に、パッケージ マニフェスト ファイルからこの値を取得できます。</span><span class="sxs-lookup"><span data-stu-id="f8956-219">In most cases, you can get this value from your package manifest file before you modify it.</span></span> <span data-ttu-id="f8956-220">値は、`Executable`の属性、`Application`要素です。</span><span class="sxs-lookup"><span data-stu-id="f8956-220">It's the value of the `Executable` attribute of the `Application` element.</span></span> |
| <span data-ttu-id="f8956-221">applications</span><span class="sxs-lookup"><span data-stu-id="f8956-221">applications</span></span> | <span data-ttu-id="f8956-222">作業ディレクトリ</span><span class="sxs-lookup"><span data-stu-id="f8956-222">workingDirectory</span></span> | <span data-ttu-id="f8956-223">(省略可能)起動するアプリケーションの作業ディレクトリとして使用するパッケージの相対パスです。</span><span class="sxs-lookup"><span data-stu-id="f8956-223">(Optional) A package-relative path to use as the working directory of the application that starts.</span></span> <span data-ttu-id="f8956-224">オペレーティング システムを使用してこの値を設定しない場合、`System32`ディレクトリをアプリケーションの作業ディレクトリです。</span><span class="sxs-lookup"><span data-stu-id="f8956-224">If you don't set this value, the operating system uses the `System32` directory as the application's working directory.</span></span> |
| <span data-ttu-id="f8956-225">プロセス</span><span class="sxs-lookup"><span data-stu-id="f8956-225">processes</span></span> | <span data-ttu-id="f8956-226">実行可能</span><span class="sxs-lookup"><span data-stu-id="f8956-226">executable</span></span> | <span data-ttu-id="f8956-227">ほとんどの場合の名前になります、`executable`を削除するパスとファイルの拡張子を持つ上に構成されています。</span><span class="sxs-lookup"><span data-stu-id="f8956-227">In most cases, this will be the name of the `executable` configured above with the path and file extension removed.</span></span> |
| <span data-ttu-id="f8956-228">shim</span><span class="sxs-lookup"><span data-stu-id="f8956-228">shims</span></span> | <span data-ttu-id="f8956-229">dll</span><span class="sxs-lookup"><span data-stu-id="f8956-229">dll</span></span> | <span data-ttu-id="f8956-230">ロードする shim .appx パッケージの相対パスです。</span><span class="sxs-lookup"><span data-stu-id="f8956-230">Package-relative path to the shim  .appx  to load.</span></span> |
| <span data-ttu-id="f8956-231">shim</span><span class="sxs-lookup"><span data-stu-id="f8956-231">shims</span></span> | <span data-ttu-id="f8956-232">構成</span><span class="sxs-lookup"><span data-stu-id="f8956-232">config</span></span> | <span data-ttu-id="f8956-233">(省略可能)シム配布リストの動作方法を制御します。</span><span class="sxs-lookup"><span data-stu-id="f8956-233">(Optional) Controls how the shim dl behaves.</span></span> <span data-ttu-id="f8956-234">この値の正確な形式は、各シムはこの"blob"を解釈できる必要があるようにシム ・によって・ シムごとに異なります。</span><span class="sxs-lookup"><span data-stu-id="f8956-234">The exact format of this value varies on a shim-by-shim basis as each shim can interpret this "blob" as it wants.</span></span> |

<span data-ttu-id="f8956-235">`applications`、`processes`と`shims`は、キーの配列。</span><span class="sxs-lookup"><span data-stu-id="f8956-235">The `applications`, `processes`, and `shims` keys are arrays.</span></span> <span data-ttu-id="f8956-236">つまり、1 つ以上のアプリケーション、プロセス、および shim DLL を指定する config.json ファイルを使用することができます。</span><span class="sxs-lookup"><span data-stu-id="f8956-236">That means that you can use the config.json file to specify more than one application, process, and shim DLL.</span></span>


### <a name="package-and-test-the-app"></a><span data-ttu-id="f8956-237">パッケージとアプリケーションのテスト</span><span class="sxs-lookup"><span data-stu-id="f8956-237">Package and Test the App</span></span>

<span data-ttu-id="f8956-238">次に、パッケージを作成します。</span><span class="sxs-lookup"><span data-stu-id="f8956-238">Next, create a package.</span></span>

```
makeappx pack /d PackageContents /p PSFSamplePackageFixup.appx
```

<span data-ttu-id="f8956-239">その後、それに署名します。</span><span class="sxs-lookup"><span data-stu-id="f8956-239">Then, sign it.</span></span>

```
signtool sign /a /v /fd sha256 /f ExportedSigningCertificate.pfx PSFSamplePackageFixup.appx
```

<span data-ttu-id="f8956-240">詳細については、[署名証明書のパッケージを作成する方法](https://docs.microsoft.com/en-us/windows/desktop/appxpkg/how-to-create-a-package-signing-certificate)と、 [signtool を使用してパッケージに署名する方法](https://docs.microsoft.com/en-us/windows/desktop/appxpkg/how-to-sign-a-package-using-signtool)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="f8956-240">For more information, see [how to create a package signing certificate](https://docs.microsoft.com/en-us/windows/desktop/appxpkg/how-to-create-a-package-signing-certificate) and [how to sign a package using signtool](https://docs.microsoft.com/en-us/windows/desktop/appxpkg/how-to-sign-a-package-using-signtool)</span></span>

<span data-ttu-id="f8956-241">PowerShell を使用して、パッケージをインストールします。</span><span class="sxs-lookup"><span data-stu-id="f8956-241">Using PowerShell, install the package.</span></span>

>[!NOTE]
> <span data-ttu-id="f8956-242">最初にパッケージをアンインストールしてください。</span><span class="sxs-lookup"><span data-stu-id="f8956-242">Remember to uninstall the package first.</span></span>

```
powershell Add-AppxPackage .\PSFSamplePackageFixup.appx
```

<span data-ttu-id="f8956-243">アプリケーションを実行し、実行時の修正プログラムが適用されると動作を確認します。</span><span class="sxs-lookup"><span data-stu-id="f8956-243">Run the application and observe the behavior with runtime fix applied.</span></span>  <span data-ttu-id="f8956-244">診断し、必要に応じてパッケージ化の手順を繰り返します。</span><span class="sxs-lookup"><span data-stu-id="f8956-244">Repeat the diagnostic and packaging steps as necessary.</span></span>

### <a name="use-the-trace-shim"></a><span data-ttu-id="f8956-245">トレースの Shim を使用します。</span><span class="sxs-lookup"><span data-stu-id="f8956-245">Use the Trace Shim</span></span>

<span data-ttu-id="f8956-246">パッケージ化されたアプリケーションの互換性の問題を診断するために別の方法では、トレースの Shim を使用します。</span><span class="sxs-lookup"><span data-stu-id="f8956-246">An alternative technique to diagnosing packaged application compatibility issues is to use the Trace Shim.</span></span> <span data-ttu-id="f8956-247">この DLL は、PSF に含まれてであり、プロセスのモニターのようなアプリケーションの動作の詳細な診断ビューを提供します。</span><span class="sxs-lookup"><span data-stu-id="f8956-247">This DLL is included with the PSF and provides a detailed diagnostic view of the app's behavior, similar to Process Monitor.</span></span>  <span data-ttu-id="f8956-248">アプリケーションの互換性の問題を明らかにするように設計します。</span><span class="sxs-lookup"><span data-stu-id="f8956-248">It is specially designed to reveal application compatibility issues.</span></span>  <span data-ttu-id="f8956-249">トレース Shim を使用してパッケージに DLL を追加、config.json では、次のフラグメントに追加とパッケージ化し、アプリケーションをインストールします。</span><span class="sxs-lookup"><span data-stu-id="f8956-249">To use the Trace Shim, add the DLL to the package, add the following fragment to your config.json, and then package and install your application.</span></span>

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

<span data-ttu-id="f8956-250">既定では、トレースのシムの「予測」と考えられる障害が除外されます。</span><span class="sxs-lookup"><span data-stu-id="f8956-250">By default, the Trace Shim filters out failures that might be considered "expected".</span></span>  <span data-ttu-id="f8956-251">たとえば、アプリケーションは、無条件に既に存在するかどうか、結果を無視するかを確認するためにファイルを削除するのにはしようと可能性があります。</span><span class="sxs-lookup"><span data-stu-id="f8956-251">For example, applications might try to unconditionally delete a file without checking to see if it already exists, ignoring the result.</span></span> <span data-ttu-id="f8956-252">ファイルシステム関数からすべてのエラーを受信するを選択して上記の例では、いくつかの予期しないエラー可能性があります取得除外、残念な結果があります。</span><span class="sxs-lookup"><span data-stu-id="f8956-252">This has the unfortunate consequence that some unexpected failures might get filtered out, so in the above example, we opt to receive all failures from filesystem functions.</span></span> <span data-ttu-id="f8956-253">その前に Config.txt ファイルからの読み取りに失敗すると、メッセージ「ファイルが見つかりません」とからわかっているのでこれを行います。</span><span class="sxs-lookup"><span data-stu-id="f8956-253">We do this because we know from before that the attempt to read from the Config.txt file fails with the message "file not found".</span></span> <span data-ttu-id="f8956-254">これは、エラーが頻繁に発生しは、一般に予測不可能であると仮定します。</span><span class="sxs-lookup"><span data-stu-id="f8956-254">This is a failure that is frequently observed and not generally assumed to be unexpected.</span></span> <span data-ttu-id="f8956-255">実習では、予期しない障害が発生するだけでフィルタ リングし、フォールバックで発生するすべての障害も識別できない問題がある場合は、最初に可能性が高い最高を勧めします。</span><span class="sxs-lookup"><span data-stu-id="f8956-255">In practice it's likely best to start out filtering only to unexpected failures, and then falling back to all failures if there's an issue that still can't be identified.</span></span>

<span data-ttu-id="f8956-256">既定では、トレースのシムからの出力は、アタッチされたデバッガーに送信されます。</span><span class="sxs-lookup"><span data-stu-id="f8956-256">By default, the output from the Trace Shim gets sent to the attached debugger.</span></span> <span data-ttu-id="f8956-257">この例では、デバッガーをアタッチしようとしていないは代わりにプログラムを使用して[デバッグ表示](https://docs.microsoft.com/en-us/sysinternals/downloads/debugview)SysInternals から出力を表示します。</span><span class="sxs-lookup"><span data-stu-id="f8956-257">For this example, we aren't going to attach a debugger, and will instead use the [DebugView](https://docs.microsoft.com/en-us/sysinternals/downloads/debugview) program from SysInternals to view its output.</span></span> <span data-ttu-id="f8956-258">アプリケーションを実行すると、わかります同じ障害前とに、同じ実行時の修正プログラムの方にごポイントを。</span><span class="sxs-lookup"><span data-stu-id="f8956-258">After running the app, we can see the same failures as before, which would point us towards the same runtime fixes.</span></span>

![TraceShim ファイルが見つかりませんでした。](images/desktop-to-uwp/traceshim_filenotfound.png)

![TraceShim のアクセスが拒否されました](images/desktop-to-uwp/traceshim_accessdenied.png)

## <a name="debug-extend-or-create-a-runtime-fix"></a><span data-ttu-id="f8956-261">デバッグ、拡張、または実行時の修正プログラムを作成</span><span class="sxs-lookup"><span data-stu-id="f8956-261">Debug, extend, or create a runtime fix</span></span>

<span data-ttu-id="f8956-262">Visual Studio を使用するには実行時の修正プログラムのデバッグ、拡張の実行時の修正プログラム、または最初から作成します。</span><span class="sxs-lookup"><span data-stu-id="f8956-262">You can use Visual Studio to debug a runtime fix, extend a runtime fix, or create one from scratch.</span></span> <span data-ttu-id="f8956-263">これらが成功するために対処する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f8956-263">You'll need to do these things to be successful.</span></span>

> [!div class="checklist"]
> * <span data-ttu-id="f8956-264">プロジェクトのパッケージング」を追加します。</span><span class="sxs-lookup"><span data-stu-id="f8956-264">Add a packaging project</span></span>
> * <span data-ttu-id="f8956-265">この修正プログラム実行時にプロジェクトを追加します。</span><span class="sxs-lookup"><span data-stu-id="f8956-265">Add project for the runtime fix</span></span>
> * <span data-ttu-id="f8956-266">Shim の起動ツール実行可能ファイルを起動するプロジェクトを追加します。</span><span class="sxs-lookup"><span data-stu-id="f8956-266">Add a project that starts the Shim Launcher executable</span></span>
> * <span data-ttu-id="f8956-267">パッケージ プロジェクトを構成します。</span><span class="sxs-lookup"><span data-stu-id="f8956-267">Configure the packaging project</span></span>

<span data-ttu-id="f8956-268">設定が完了したら、ソリューションは次のようです。</span><span class="sxs-lookup"><span data-stu-id="f8956-268">When you're done, your solution will look something like this.</span></span>

![完成したソリューション](images/desktop-to-uwp/runtime-fix-project-structure.png)

<span data-ttu-id="f8956-270">この例では、各プロジェクトを見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="f8956-270">Let's look at each project in this example.</span></span>

| <span data-ttu-id="f8956-271">プロジェクト</span><span class="sxs-lookup"><span data-stu-id="f8956-271">Project</span></span> | <span data-ttu-id="f8956-272">目的</span><span class="sxs-lookup"><span data-stu-id="f8956-272">Purpose</span></span> |
|-------|-----------|
| <span data-ttu-id="f8956-273">DesktopApplicationPackage</span><span class="sxs-lookup"><span data-stu-id="f8956-273">DesktopApplicationPackage</span></span> | <span data-ttu-id="f8956-274">このプロジェクトは、 [Windows アプリケーションのパッケージ化のプロジェクト](desktop-to-uwp-packaging-dot-net.md)に基づいて、出力、MSIX パッケージです。</span><span class="sxs-lookup"><span data-stu-id="f8956-274">This project is based on the [Windows Application Packaging project](desktop-to-uwp-packaging-dot-net.md) and it outputs the the MSIX package.</span></span> |
| <span data-ttu-id="f8956-275">Runtimefix</span><span class="sxs-lookup"><span data-stu-id="f8956-275">Runtimefix</span></span> | <span data-ttu-id="f8956-276">これは、C++ の Dynamic-Linked ライブラリを含むプロジェクトを実行時の修正プログラムとして機能する 1 つまたは複数の交換機能です。</span><span class="sxs-lookup"><span data-stu-id="f8956-276">This is a C++ Dynamic-Linked Library project that contains one or more replacement functions that serve as the runtime fix.</span></span> |
| <span data-ttu-id="f8956-277">ShimLauncher</span><span class="sxs-lookup"><span data-stu-id="f8956-277">ShimLauncher</span></span> | <span data-ttu-id="f8956-278">これは、C++ の空のプロジェクトです。</span><span class="sxs-lookup"><span data-stu-id="f8956-278">This is C++ Empty Project.</span></span> <span data-ttu-id="f8956-279">このプロジェクトは、パッケージのサポート フレームワークのランタイムの配布可能なファイルを収集する場所です。</span><span class="sxs-lookup"><span data-stu-id="f8956-279">This project is a place to collect the runtime distributable files of the Package Support Framework.</span></span> <span data-ttu-id="f8956-280">実行可能ファイルを出力します。</span><span class="sxs-lookup"><span data-stu-id="f8956-280">It outputs an executable file.</span></span> <span data-ttu-id="f8956-281">その実行可能ファイルは、最初にソリューションを起動するときに実行されることです。</span><span class="sxs-lookup"><span data-stu-id="f8956-281">That executable is the first thing that runs when you start the solution.</span></span> |
| <span data-ttu-id="f8956-282">WinFormsDesktopApplication</span><span class="sxs-lookup"><span data-stu-id="f8956-282">WinFormsDesktopApplication</span></span> | <span data-ttu-id="f8956-283">このプロジェクトには、デスクトップ アプリケーションのソース コードが含まれています。</span><span class="sxs-lookup"><span data-stu-id="f8956-283">This project contains the source code of a desktop application.</span></span> |

<span data-ttu-id="f8956-284">これらの種類のプロジェクトのすべてを含む完全なサンプルを見ると、 [PSFSample](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/samples/PSFSample/)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="f8956-284">To look at a complete sample that contains all of these types of projects, see [PSFSample](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/samples/PSFSample/).</span></span>

<span data-ttu-id="f8956-285">作成し、ソリューション内の各プロジェクトを構成する手順を説明しましょう。</span><span class="sxs-lookup"><span data-stu-id="f8956-285">Let's walk through the steps to create and configure each of these projects in your solution.</span></span>


### <a name="create-a-package-solution"></a><span data-ttu-id="f8956-286">パッケージ ソリューションを作成します。</span><span class="sxs-lookup"><span data-stu-id="f8956-286">Create a package solution</span></span>

<span data-ttu-id="f8956-287">デスクトップ アプリケーションのソリューションがない場合は、Visual Studio で新しい**空のソリューション**を作成します。</span><span class="sxs-lookup"><span data-stu-id="f8956-287">If you don't already have a solution for your desktop application, create a new **Blank Solution** in Visual Studio.</span></span>

![空のソリューション](images/desktop-to-uwp/blank-solution.png)

<span data-ttu-id="f8956-289">持つ任意のアプリケーション プロジェクトを追加することもできます。</span><span class="sxs-lookup"><span data-stu-id="f8956-289">You may also want to add any application projects you have.</span></span>

### <a name="add-a-packaging-project"></a><span data-ttu-id="f8956-290">プロジェクトのパッケージング」を追加します。</span><span class="sxs-lookup"><span data-stu-id="f8956-290">Add a packaging project</span></span>

<span data-ttu-id="f8956-291">既に**Windows アプリケーション プロジェクトのパッケージング**をお持ちでない場合は、1 つを作成し、ソリューションに追加します。</span><span class="sxs-lookup"><span data-stu-id="f8956-291">If you don't already have a **Windows Application Packaging Project**, create one and add it to your solution.</span></span>

![パッケージのプロジェクト テンプレート](images/desktop-to-uwp/package-project-template.png)

<span data-ttu-id="f8956-293">Windows アプリケーションのパッケージ化プロジェクトの詳細については、 [Visual Studio を使用してアプリケーションのパッケージ](desktop-to-uwp-packaging-dot-net.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="f8956-293">For more information on Windows Application Packaging project, see [Package your application by using Visual Studio](desktop-to-uwp-packaging-dot-net.md).</span></span>

<span data-ttu-id="f8956-294">**ソリューション エクスプ ローラー**でパッケージ プロジェクトを右クリックし、**編集**を選択し、プロジェクト ファイルの末尾に追加。</span><span class="sxs-lookup"><span data-stu-id="f8956-294">In **Solution Explorer**, right-click the packaging project, select **Edit**, and then add this to the bottom of the project file:</span></span>

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

### <a name="add-project-for-the-runtime-fix"></a><span data-ttu-id="f8956-295">この修正プログラム実行時にプロジェクトを追加します。</span><span class="sxs-lookup"><span data-stu-id="f8956-295">Add project for the runtime fix</span></span>

<span data-ttu-id="f8956-296">**ダイナミック リンク ライブラリ (DLL)** の C++ プロジェクトをソリューションに追加します。</span><span class="sxs-lookup"><span data-stu-id="f8956-296">Add a C++ **Dynamic-Link Library (DLL)** project to the solution.</span></span>

![実行時の修正プログラム ライブラリ](images/desktop-to-uwp/runtime-fix-library.png)

<span data-ttu-id="f8956-298">[プロジェクト]、[**プロパティ**を右クリックします。</span><span class="sxs-lookup"><span data-stu-id="f8956-298">Right-click the that project, and then choose **Properties**.</span></span>

<span data-ttu-id="f8956-299">プロパティ ページ] で、 **C++ 言語の標準**のフィールドを見つけて、そのフィールドの横のドロップダウン リスト、選択、 **ISO c 17 標準 (/std:c では 17)** オプションです。</span><span class="sxs-lookup"><span data-stu-id="f8956-299">In the property pages, find the **C++ Language Standard** field, and then in the drop-down list next to that field, select the **ISO C++17 Standard (/std:c++17)** option.</span></span>

![ISO 17 オプション](images/desktop-to-uwp/iso-option.png)

<span data-ttu-id="f8956-301">そのプロジェクトを右クリックし、コンテキスト メニューで、 **Nuget パッケージの管理**] オプションを選択します。</span><span class="sxs-lookup"><span data-stu-id="f8956-301">Right-click that project, and then in the context menu, choose the **Manage Nuget Packages** option.</span></span> <span data-ttu-id="f8956-302">**Nuget.org**または**すべて**に、[**パッケージ ソース**] オプションが設定されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="f8956-302">Ensure that the **Package source** option is set to **All** or **nuget.org**.</span></span>

<span data-ttu-id="f8956-303">次にそのフィールドの設定] アイコンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="f8956-303">Click the settings icon next that field.</span></span>

<span data-ttu-id="f8956-304">*PSF*の検索 \* Nuget パッケージ、および、それをこのプロジェクトをインストールします。</span><span class="sxs-lookup"><span data-stu-id="f8956-304">Search for the *PSF*\* Nuget package, and then install it for this project.</span></span>

![nuget パッケージ](images/desktop-to-uwp/psf-package.png)

<span data-ttu-id="f8956-306">デバッグまたは既存の実行時の修正プログラムを拡張する場合は、説明されているガイダンスを使用して、このガイドの「[実行時の修正プログラムを検索](#find)して取得したランタイムの修正プログラム ファイルを追加します。</span><span class="sxs-lookup"><span data-stu-id="f8956-306">If you want to debug or extend an existing runtime fix, add the runtime fix files that you obtained by using the guidance described in the [Find a runtime fix](#find) section of this guide.</span></span>

<span data-ttu-id="f8956-307">新しい修正プログラムを作成する場合は、追加しない何もこのプロジェクトにまだです。</span><span class="sxs-lookup"><span data-stu-id="f8956-307">If you intend to create a brand new fix, don't add anything to this project just yet.</span></span> <span data-ttu-id="f8956-308">ことができますこのガイドの後でこのプロジェクトにファイルを追加します。</span><span class="sxs-lookup"><span data-stu-id="f8956-308">We'll help you add the right files to this project later in this guide.</span></span> <span data-ttu-id="f8956-309">ここでは、ソリューションのセットアップをいく予定です。</span><span class="sxs-lookup"><span data-stu-id="f8956-309">For now, we'll continue setting up your solution.</span></span>

### <a name="add-a-project-that-starts-the-shim-launcher-executable"></a><span data-ttu-id="f8956-310">Shim の起動ツール実行可能ファイルを起動するプロジェクトを追加します。</span><span class="sxs-lookup"><span data-stu-id="f8956-310">Add a project that starts the Shim Launcher executable</span></span>

<span data-ttu-id="f8956-311">**空のプロジェクト**の C++ プロジェクトをソリューションに追加します。</span><span class="sxs-lookup"><span data-stu-id="f8956-311">Add a C++ **Empty Project** project to the solution.</span></span>

![空のプロジェクト](images/desktop-to-uwp/blank-app.png)

<span data-ttu-id="f8956-313">前のセクションで説明されている同じガイドを使用して、このプロジェクトに**PSF** Nuget パッケージを追加します。</span><span class="sxs-lookup"><span data-stu-id="f8956-313">Add the **PSF** Nuget package to this project by using the same guidance described in the previous section.</span></span>

<span data-ttu-id="f8956-314">開く**全般**の設定] ページで、プロジェクトのプロパティ ページ**名のターゲット**プロパティを設定します``ShimLauncher32``または``ShimLauncher64``、アプリケーションのアーキテクチャに依存します。</span><span class="sxs-lookup"><span data-stu-id="f8956-314">Open the property pages for the project, and in the **General** settings page, set the **Target Name** property to ``ShimLauncher32`` or ``ShimLauncher64`` depending on the architecture of your application.</span></span>

![シム起動ツールの参照](images/desktop-to-uwp/shim-exe-reference.png)

<span data-ttu-id="f8956-316">ソリューションの実行時の修正プログラムのプロジェクトへのプロジェクト参照を追加します。</span><span class="sxs-lookup"><span data-stu-id="f8956-316">Add a project reference to the runtime fix project in your solution.</span></span>

![実行時の修正プログラムの参照](images/desktop-to-uwp/reference-fix.png)

<span data-ttu-id="f8956-318">参照を右クリックし、 **[プロパティ**] ウィンドウでこれらの値を適用します。</span><span class="sxs-lookup"><span data-stu-id="f8956-318">Right-click the reference, and then in the **Properties** window, apply these values.</span></span>

| <span data-ttu-id="f8956-319">プロパティ</span><span class="sxs-lookup"><span data-stu-id="f8956-319">Property</span></span> | <span data-ttu-id="f8956-320">値</span><span class="sxs-lookup"><span data-stu-id="f8956-320">Value</span></span> |
|-------|-----------|-------|
| <span data-ttu-id="f8956-321">ローカル コピーします。</span><span class="sxs-lookup"><span data-stu-id="f8956-321">Copy local</span></span> | <span data-ttu-id="f8956-322">True</span><span class="sxs-lookup"><span data-stu-id="f8956-322">True</span></span> |
| <span data-ttu-id="f8956-323">ローカルのサテライト アセンブリをコピーします。</span><span class="sxs-lookup"><span data-stu-id="f8956-323">Copy Local Satellite Assemblies</span></span> | <span data-ttu-id="f8956-324">True</span><span class="sxs-lookup"><span data-stu-id="f8956-324">True</span></span> |
| <span data-ttu-id="f8956-325">参照アセンブリの出力</span><span class="sxs-lookup"><span data-stu-id="f8956-325">Reference Assembly Output</span></span> | <span data-ttu-id="f8956-326">True</span><span class="sxs-lookup"><span data-stu-id="f8956-326">True</span></span> |
| <span data-ttu-id="f8956-327">リンク ライブラリの依存関係</span><span class="sxs-lookup"><span data-stu-id="f8956-327">Link Library Dependencies</span></span> | <span data-ttu-id="f8956-328">False</span><span class="sxs-lookup"><span data-stu-id="f8956-328">False</span></span> |
| <span data-ttu-id="f8956-329">リンク ライブラリの依存関係の入力</span><span class="sxs-lookup"><span data-stu-id="f8956-329">Link Library Dependency Inputs</span></span> | <span data-ttu-id="f8956-330">False</span><span class="sxs-lookup"><span data-stu-id="f8956-330">False</span></span> |

### <a name="configure-the-packaging-project"></a><span data-ttu-id="f8956-331">パッケージ プロジェクトを構成します。</span><span class="sxs-lookup"><span data-stu-id="f8956-331">Configure the packaging project</span></span>

<span data-ttu-id="f8956-332">パッケージ プロジェクトで、**[アプリケーション]** フォルダーを右クリックして **[参照の追加]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="f8956-332">In the packaging project, right-click the **Applications** folder, and then choose **Add Reference**.</span></span>

![プロジェクト参照の追加](images/desktop-to-uwp/add-reference-packaging-project.png)

<span data-ttu-id="f8956-334">シム起動プログラムのプロジェクトと、デスクトップ アプリケーションのプロジェクトを選択し、 **[OK** ] ボタンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="f8956-334">Choose the shim launcher project and your desktop application project, and then choose the **OK** button.</span></span>

![デスクトップ プロジェクト](images/desktop-to-uwp/package-project-references.png)

>[!NOTE]
> <span data-ttu-id="f8956-336">ソース コードをアプリケーションをお持ちでない場合シム起動プログラムのプロジェクトを選択するだけです。</span><span class="sxs-lookup"><span data-stu-id="f8956-336">If you don't have the source code to your application, just choose the shim launcher project.</span></span> <span data-ttu-id="f8956-337">構成ファイルを作成するときに、実行可能ファイルを参照する方法紹介します。</span><span class="sxs-lookup"><span data-stu-id="f8956-337">We'll show you how to reference your executable when you create a configuration file.</span></span>

<span data-ttu-id="f8956-338">**アプリケーション**] ノードで shim の起動プログラム アプリケーションを右クリックし、**エントリ ポイントとして設定**します。</span><span class="sxs-lookup"><span data-stu-id="f8956-338">In the **Applications** node, right-click the shim launcher application, and then choose **Set as Entry Point**.</span></span>

![エントリ ポイントの設定](images/desktop-to-uwp/set-startup-project.png)

<span data-ttu-id="f8956-340">という名前のファイルを追加する``config.json``をパッケージ化プロジェクトにコピーし、次の json 文字列をファイルに貼り付けます。</span><span class="sxs-lookup"><span data-stu-id="f8956-340">Add a file named ``config.json`` to your packaging project, then, copy and paste the following json text into the file.</span></span> <span data-ttu-id="f8956-341">**コンテンツ**を**パッケージの Action**プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="f8956-341">Set the **Package Action** property to **Content**.</span></span>

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
<span data-ttu-id="f8956-342">各キーの値を提供します。</span><span class="sxs-lookup"><span data-stu-id="f8956-342">Provide a value for each key.</span></span> <span data-ttu-id="f8956-343">このテーブルをガイドとして使用します。</span><span class="sxs-lookup"><span data-stu-id="f8956-343">Use this table as a guide.</span></span>

| <span data-ttu-id="f8956-344">配列</span><span class="sxs-lookup"><span data-stu-id="f8956-344">Array</span></span> | <span data-ttu-id="f8956-345">key</span><span class="sxs-lookup"><span data-stu-id="f8956-345">key</span></span> | <span data-ttu-id="f8956-346">値</span><span class="sxs-lookup"><span data-stu-id="f8956-346">Value</span></span> |
|-------|-----------|-------|
| <span data-ttu-id="f8956-347">applications</span><span class="sxs-lookup"><span data-stu-id="f8956-347">applications</span></span> | <span data-ttu-id="f8956-348">id</span><span class="sxs-lookup"><span data-stu-id="f8956-348">id</span></span> |  <span data-ttu-id="f8956-349">値を使用して、`Id`の属性、`Application`パッケージ マニフェスト内の要素。</span><span class="sxs-lookup"><span data-stu-id="f8956-349">Use the value of the `Id` attribute of the `Application` element in the package manifest.</span></span> |
| <span data-ttu-id="f8956-350">applications</span><span class="sxs-lookup"><span data-stu-id="f8956-350">applications</span></span> | <span data-ttu-id="f8956-351">実行可能</span><span class="sxs-lookup"><span data-stu-id="f8956-351">executable</span></span> | <span data-ttu-id="f8956-352">起動する実行可能ファイルへのパッケージの相対パス。</span><span class="sxs-lookup"><span data-stu-id="f8956-352">The package-relative path to the executable that you want to start.</span></span> <span data-ttu-id="f8956-353">ほとんどの場合、それを変更する前に、パッケージ マニフェスト ファイルからこの値を取得できます。</span><span class="sxs-lookup"><span data-stu-id="f8956-353">In most cases, you can get this value from your package manifest file before you modify it.</span></span> <span data-ttu-id="f8956-354">値は、`Executable`の属性、`Application`要素です。</span><span class="sxs-lookup"><span data-stu-id="f8956-354">It's the value of the `Executable` attribute of the `Application` element.</span></span> |
| <span data-ttu-id="f8956-355">applications</span><span class="sxs-lookup"><span data-stu-id="f8956-355">applications</span></span> | <span data-ttu-id="f8956-356">作業ディレクトリ</span><span class="sxs-lookup"><span data-stu-id="f8956-356">workingDirectory</span></span> | <span data-ttu-id="f8956-357">(省略可能)起動するアプリケーションの作業ディレクトリとして使用するパッケージの相対パスです。</span><span class="sxs-lookup"><span data-stu-id="f8956-357">(Optional) A package-relative path to use as the working directory of the application that starts.</span></span> <span data-ttu-id="f8956-358">オペレーティング システムを使用してこの値を設定しない場合、`System32`ディレクトリをアプリケーションの作業ディレクトリです。</span><span class="sxs-lookup"><span data-stu-id="f8956-358">If you don't set this value, the operating system uses the `System32` directory as the application's working directory.</span></span> |
| <span data-ttu-id="f8956-359">プロセス</span><span class="sxs-lookup"><span data-stu-id="f8956-359">processes</span></span> | <span data-ttu-id="f8956-360">実行可能</span><span class="sxs-lookup"><span data-stu-id="f8956-360">executable</span></span> | <span data-ttu-id="f8956-361">ほとんどの場合の名前になります、`executable`を削除するパスとファイルの拡張子を持つ上に構成されています。</span><span class="sxs-lookup"><span data-stu-id="f8956-361">In most cases, this will be the name of the `executable` configured above with the path and file extension removed.</span></span> |
| <span data-ttu-id="f8956-362">shim</span><span class="sxs-lookup"><span data-stu-id="f8956-362">shims</span></span> | <span data-ttu-id="f8956-363">dll</span><span class="sxs-lookup"><span data-stu-id="f8956-363">dll</span></span> | <span data-ttu-id="f8956-364">Shim DLL を読み込むパッケージの相対パスです。</span><span class="sxs-lookup"><span data-stu-id="f8956-364">Package-relative path to the shim DLL to load.</span></span> |
| <span data-ttu-id="f8956-365">shim</span><span class="sxs-lookup"><span data-stu-id="f8956-365">shims</span></span> | <span data-ttu-id="f8956-366">構成</span><span class="sxs-lookup"><span data-stu-id="f8956-366">config</span></span> | <span data-ttu-id="f8956-367">(省略可能)シム配布リストの動作方法を制御します。</span><span class="sxs-lookup"><span data-stu-id="f8956-367">(Optional) Controls how the shim dl behaves.</span></span> <span data-ttu-id="f8956-368">この値の正確な形式は、各シムはこの"blob"を解釈できる必要があるようにシム ・によって・ シムごとに異なります。</span><span class="sxs-lookup"><span data-stu-id="f8956-368">The exact format of this value varies on a shim-by-shim basis as each shim can interpret this "blob" as it wants.</span></span> |

<span data-ttu-id="f8956-369">、終わったときに、``config.json``ファイルは次のようになります。</span><span class="sxs-lookup"><span data-stu-id="f8956-369">When you're done, your ``config.json`` file will look something like this.</span></span>

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
> <span data-ttu-id="f8956-370">`applications`、`processes`と`shims`は、キーの配列。</span><span class="sxs-lookup"><span data-stu-id="f8956-370">The `applications`, `processes`, and `shims` keys are arrays.</span></span> <span data-ttu-id="f8956-371">つまり、1 つ以上のアプリケーション、プロセス、および shim DLL を指定する config.json ファイルを使用することができます。</span><span class="sxs-lookup"><span data-stu-id="f8956-371">That means that you can use the config.json file to specify more than one application, process, and shim DLL.</span></span>

### <a name="debug-a-runtime-fix"></a><span data-ttu-id="f8956-372">実行時の修正プログラムをデバッグします。</span><span class="sxs-lookup"><span data-stu-id="f8956-372">Debug a runtime fix</span></span>

<span data-ttu-id="f8956-373">Visual Studio は、デバッガーを起動するのには f5 キーを押します。</span><span class="sxs-lookup"><span data-stu-id="f8956-373">In Visual Studio, press F5 to start the debugger.</span></span>  <span data-ttu-id="f8956-374">最初に起動することは、次に、ターゲット、デスクトップ アプリケーションを起動する shim のランチャー アプリケーションです。</span><span class="sxs-lookup"><span data-stu-id="f8956-374">The first thing that starts is the shim launcher application, which in turn, starts your target desktop application.</span></span>  <span data-ttu-id="f8956-375">対象のデスクトップ アプリケーションをデバッグするには、**デバッグ**を選択することによって、デスクトップ アプリケーションのプロセスに手動でアタッチする必要があります->**プロセスにアタッチ**し、アプリケーションの処理] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="f8956-375">To debug the target desktop application, you'll have to manually attach to the desktop application process by choosing **Debug**->**Attach to Process**, and then selecting the application process.</span></span> <span data-ttu-id="f8956-376">ネイティブ ランタイム修正 DLL を .NET アプリケーションのデバッグを許可するには、マネージ コードとネイティブ コードの種類 (混合モードのデバッグ) を選択します。</span><span class="sxs-lookup"><span data-stu-id="f8956-376">To permit the debugging of a .NET application with a native runtime fix DLL, select managed and native code types (mixed mode debugging).</span></span>  

<span data-ttu-id="f8956-377">これ設定したら、デスクトップ アプリケーションのコードと実行時の修正プログラムのプロジェクトでのコード行の横にあるブレーク ・ ポイントを設定できます。</span><span class="sxs-lookup"><span data-stu-id="f8956-377">Once you've set this up, you can set break points next to lines of code in the desktop application code and the runtime fix project.</span></span> <span data-ttu-id="f8956-378">ソース コードをアプリケーションをお持ちでない場合、実行時の修正プログラムのプロジェクトでのコード行の横にあるブレーク ・ ポイントを設定することができます。</span><span class="sxs-lookup"><span data-stu-id="f8956-378">If you don't have the source code to your application, you'll be able to set break points only next to lines of code in your runtime fix project.</span></span>

>[!NOTE]
> <span data-ttu-id="f8956-379">Visual Studio を使用する最も簡単な開発エクスペリエンスをデバッグするには、いくつかの制限がある中、このガイドの後でについて説明しますその他のデバッグ手法を適用することができます。</span><span class="sxs-lookup"><span data-stu-id="f8956-379">While Visual Studio gives you the simplest development and debugging experience, there are some limitations, so later in this guide, we'll discuss other debugging techniques that you can apply.</span></span>

## <a name="create-a-runtime-fix"></a><span data-ttu-id="f8956-380">実行時の修正プログラムを作成します。</span><span class="sxs-lookup"><span data-stu-id="f8956-380">Create a runtime fix</span></span>

<span data-ttu-id="f8956-381">ランタイムの修正の問題を解決する場合、交換用の関数を作成し、任意の構成データを含む新しいランタイムの修正プログラムを作成することができますがない場合は合理的です。</span><span class="sxs-lookup"><span data-stu-id="f8956-381">If there isn't yet a runtime fix for the issue that you want to resolve, you can create a new runtime fix by writing replacement functions and including any configuration data that makes sense.</span></span> <span data-ttu-id="f8956-382">各部分を見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="f8956-382">Let's look at each part.</span></span>

### <a name="replacement-functions"></a><span data-ttu-id="f8956-383">置換機能</span><span class="sxs-lookup"><span data-stu-id="f8956-383">Replacement functions</span></span>

<span data-ttu-id="f8956-384">MSIX コンテナーでアプリケーションを実行するときに、呼び出しが失敗する関数を最初に、特定するには。</span><span class="sxs-lookup"><span data-stu-id="f8956-384">First, identify which function calls fail when your application runs in an MSIX container.</span></span> <span data-ttu-id="f8956-385">代わりにランタイム マネージャーを希望する交換用関数を作成できます。</span><span class="sxs-lookup"><span data-stu-id="f8956-385">Then, you can create replacement functions that you'd like the runtime manager to call instead.</span></span> <span data-ttu-id="f8956-386">これは、最新のランタイム環境の規則に準拠した動作と関数の実装を置き換えることを示します。</span><span class="sxs-lookup"><span data-stu-id="f8956-386">This gives you an opportunity to replace the implementation of a function with behavior that conforms to the rules of the modern runtime environment.</span></span>

<span data-ttu-id="f8956-387">Visual Studio は、このガイドの前半で作成したランタイムの修正プログラムのプロジェクトを開きます。</span><span class="sxs-lookup"><span data-stu-id="f8956-387">In Visual Studio, open the runtime fix project that you created earlier in this guide.</span></span>

<span data-ttu-id="f8956-388">宣言、``SHIM_DEFINE_EXPORTS``マクロ用の include ステートメントを追加し、`shim_framework.h`それぞれの上部にあります。CPP ファイルが、実行時の修正プログラムの機能を追加する対象となります。</span><span class="sxs-lookup"><span data-stu-id="f8956-388">Declare the ``SHIM_DEFINE_EXPORTS`` macro and then add a include statement for the `shim_framework.h` at the top of each .CPP file where you intend to add the functions of your runtime fix.</span></span>

```c++
#define SHIM_DEFINE_EXPORTS
#include <shim_framework.h>
```
>[!IMPORTANT]
><span data-ttu-id="f8956-389">確認、 `SHIM_DEFINE_EXPORTS` 、include ステートメントの前にマクロが表示されます。</span><span class="sxs-lookup"><span data-stu-id="f8956-389">Make sure that the `SHIM_DEFINE_EXPORTS` macro appears before the include statement.</span></span>

<span data-ttu-id="f8956-390">同じ関数のシグネチャを持つ関数を作成したが動作を変更します。</span><span class="sxs-lookup"><span data-stu-id="f8956-390">Create a function that has the same signature of the function who's behavior you want to modify.</span></span> <span data-ttu-id="f8956-391">置換する関数の例をここでは、`MessageBoxW`関数です。</span><span class="sxs-lookup"><span data-stu-id="f8956-391">Here's an example function that replaces the `MessageBoxW` function.</span></span>

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

<span data-ttu-id="f8956-392">呼び出し`DECLARE_SHIM`マップ、 `MessageBoxW` 、新しい置換関数への関数です。</span><span class="sxs-lookup"><span data-stu-id="f8956-392">The call to `DECLARE_SHIM` maps the `MessageBoxW` function to your new replacement function.</span></span> <span data-ttu-id="f8956-393">アプリケーションが呼び出すしようとしたとき、`MessageBoxW`関数、その関数を呼び出す、交換代わりにします。</span><span class="sxs-lookup"><span data-stu-id="f8956-393">When your application attempts to call the `MessageBoxW` function, it will call the replacement function instead.</span></span>

#### <a name="protect-against-recursive-calls-to-functions-in-runtime-fixes"></a><span data-ttu-id="f8956-394">修正を実行時に関数の再帰呼び出しを防ぐ</span><span class="sxs-lookup"><span data-stu-id="f8956-394">Protect against recursive calls to functions in runtime fixes</span></span>

<span data-ttu-id="f8956-395">必要に応じて適用することができます、`reentrancy_guard`修正を実行時に関数の再帰呼び出しを保護する、関数をタイプします。</span><span class="sxs-lookup"><span data-stu-id="f8956-395">You can optionally apply the `reentrancy_guard` type to your functions that protect against recursive calls to functions in runtime fixes.</span></span>

<span data-ttu-id="f8956-396">交換用の関数を作成するなど、`CreateFile`関数です。</span><span class="sxs-lookup"><span data-stu-id="f8956-396">For example, you might produce a replacement function for the `CreateFile` function.</span></span> <span data-ttu-id="f8956-397">実装を呼び出すことがあります、`CopyFile`の実装、`CopyFile`関数を呼び出す可能性があります、`CreateFile`関数です。</span><span class="sxs-lookup"><span data-stu-id="f8956-397">Your implementation might call the `CopyFile` function, but the implementation of the `CopyFile` function might call the `CreateFile` function.</span></span> <span data-ttu-id="f8956-398">無限の再帰的なサイクルへの呼び出しのため、`CreateFile`関数です。</span><span class="sxs-lookup"><span data-stu-id="f8956-398">This may lead to an infinite recursive cycle of calls to the `CreateFile` function.</span></span>

<span data-ttu-id="f8956-399">詳細については`reentrancy_guard` [authoring.md](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/Authoring.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="f8956-399">For more information on `reentrancy_guard` see [authoring.md](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/Authoring.md)</span></span>

### <a name="configuration-data"></a><span data-ttu-id="f8956-400">構成データ</span><span class="sxs-lookup"><span data-stu-id="f8956-400">Configuration data</span></span>

<span data-ttu-id="f8956-401">構成データ、実行時の修正プログラムを追加する場合は、追加することを検討してください、 ``config.json``。</span><span class="sxs-lookup"><span data-stu-id="f8956-401">If you want to add configuration data to your runtime fix, consider adding it to the ``config.json``.</span></span> <span data-ttu-id="f8956-402">そうすることが使うことができます、`ShimQueryCurrentDllConfig`に簡単にそのデータを解析します。</span><span class="sxs-lookup"><span data-stu-id="f8956-402">That way, you can use the `ShimQueryCurrentDllConfig` to easily parse that data.</span></span> <span data-ttu-id="f8956-403">この例では、その構成ファイルからのブール値、文字列の値を解析します。</span><span class="sxs-lookup"><span data-stu-id="f8956-403">This example parses a boolean and string value from that configuration file.</span></span>

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

## <a name="other-debugging-techniques"></a><span data-ttu-id="f8956-404">その他のデバッグ手法</span><span class="sxs-lookup"><span data-stu-id="f8956-404">Other debugging techniques</span></span>

<span data-ttu-id="f8956-405">Visual Studio を使用すると、最も簡単な開発およびデバッグの操作性、ときに、いくつかの制限があります。</span><span class="sxs-lookup"><span data-stu-id="f8956-405">While Visual Studio gives you the simplest development and debugging experience, there are some limitations.</span></span>

<span data-ttu-id="f8956-406">.Appx パッケージからインストールするのではなく、パッケージ レイアウト フォルダーのパスからの圧縮しないファイルを展開するアプリケーションを最初に、f5 キーを押してデバッグ実行します。</span><span class="sxs-lookup"><span data-stu-id="f8956-406">First, F5 debugging runs the application by deploying loose files from the package layout folder path, rather than installing from a .appx package.</span></span>  <span data-ttu-id="f8956-407">レイアウト フォルダー通常が同じセキュリティ制限パッケージがインストールされているフォルダーとします。</span><span class="sxs-lookup"><span data-stu-id="f8956-407">The layout folder typically does not have the same security restrictions as an installed package folder.</span></span> <span data-ttu-id="f8956-408">その結果、ある可能性がありますしない実行時の修正プログラムを適用する前にパッケージのパスのアクセス拒否のエラーを再現することです。</span><span class="sxs-lookup"><span data-stu-id="f8956-408">As a result, it may not be possible to reproduce package path access denial errors prior to applying a runtime fix.</span></span>

<span data-ttu-id="f8956-409">この問題に対処するためには、f5 キーを押して圧縮しないファイルの展開ではなく、.appx パッケージの展開を使用します。</span><span class="sxs-lookup"><span data-stu-id="f8956-409">To address this issue, use .appx package deployment rather than F5 loose file deployment.</span></span>  <span data-ttu-id="f8956-410">.Appx パッケージ ファイルを作成するには、上記で説明した Windows sdk では、 [MakeAppx](https://docs.microsoft.com/en-us/windows/desktop/appxpkg/make-appx-package--makeappx-exe-)ユーティリティを使用します。</span><span class="sxs-lookup"><span data-stu-id="f8956-410">To create a .appx package file, use the [MakeAppx](https://docs.microsoft.com/en-us/windows/desktop/appxpkg/make-appx-package--makeappx-exe-) utility from the Windows SDK, as described above.</span></span> <span data-ttu-id="f8956-411">またはから Visual Studio は、内アプリケーション プロジェクト ノードを右クリックし、**選択して**、->**アプリケーションのパッケージを作成**します。</span><span class="sxs-lookup"><span data-stu-id="f8956-411">Or, from within Visual Studio, right-click your application project node and select **Store**->**Create App Packages**.</span></span>

<span data-ttu-id="f8956-412">Visual Studio の別の問題は、デバッガーによって起動されるすべての子プロセスにアタッチするための組み込みサポートがないことです。</span><span class="sxs-lookup"><span data-stu-id="f8956-412">Another issue with Visual Studio is that it does not have built-in support for attaching to any child processes launched by the debugger.</span></span>   <span data-ttu-id="f8956-413">ロジックを関連付ける必要があります手動で Visual Studio を起動した後、ターゲット アプリケーションの起動パスでのデバッグが困難になります。</span><span class="sxs-lookup"><span data-stu-id="f8956-413">This makes it difficult to debug logic in the startup path of the target application, which must be manually attached by Visual Studio after launch.</span></span>

<span data-ttu-id="f8956-414">この問題を解決するには、サポートが子プロセスにアタッチするデバッガーを使用します。</span><span class="sxs-lookup"><span data-stu-id="f8956-414">To address this issue, use a debugger that supports child process attach.</span></span>  <span data-ttu-id="f8956-415">一般に、ジャスト ・ イン ・ タイム (JIT) デバッガーをターゲット アプリケーションにアタッチすることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="f8956-415">Note that it is generally not possible to attach a just-in-time (JIT) debugger to the target application.</span></span>  <span data-ttu-id="f8956-416">JIT のほとんどの手法は、ImageFileExecutionOptions のレジストリ キーを使用して、対象とするアプリケーションにデバッガーを起動するためです。</span><span class="sxs-lookup"><span data-stu-id="f8956-416">This is because most JIT techniques involve launching the debugger in place of the target app, via the ImageFileExecutionOptions registry key.</span></span>  <span data-ttu-id="f8956-417">ShimLauncher.exe ShimRuntime.dll を対象とするアプリケーションに挿入するために使用する detouring 機構が損なわれるためです。</span><span class="sxs-lookup"><span data-stu-id="f8956-417">This defeats the detouring mechanism used by ShimLauncher.exe to inject ShimRuntime.dll into the target app.</span></span>  <span data-ttu-id="f8956-418">WinDbg は、 [Windows 用デバッグ ツール](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/index)では、含まれているし、 [Windows SDK](https://developer.microsoft.com/en-US/windows/downloads/windows-10-sdk)から取得した子プロセスをサポートしていますが接続します。</span><span class="sxs-lookup"><span data-stu-id="f8956-418">WinDbg, included in the [Debugging Tools for Windows](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/index), and obtained from the [Windows SDK](https://developer.microsoft.com/en-US/windows/downloads/windows-10-sdk), supports child process attach.</span></span>  <span data-ttu-id="f8956-419">サポート直接[起動して UWP アプリケーションをデバッグ](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/debugging-a-uwp-app-using-windbg#span-idlaunchinganddebuggingauwpappspanspan-idlaunchinganddebuggingauwpappspanspan-idlaunchinganddebuggingauwpappspanlaunching-and-debugging-a-uwp-app)します。</span><span class="sxs-lookup"><span data-stu-id="f8956-419">It also now supports directly [launching and debugging a UWP app](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/debugging-a-uwp-app-using-windbg#span-idlaunchinganddebuggingauwpappspanspan-idlaunchinganddebuggingauwpappspanspan-idlaunchinganddebuggingauwpappspanlaunching-and-debugging-a-uwp-app).</span></span>

<span data-ttu-id="f8956-420">子プロセスとターゲット アプリケーションの起動をデバッグするには、開始``WinDbg``。</span><span class="sxs-lookup"><span data-stu-id="f8956-420">To debug target application startup as a child process, start ``WinDbg``.</span></span>

```
windbg.exe -plmPackage PSFSampleWithFixup_1.0.59.0_x86__7s220nvg1hg3m -plmApp PSFSample
```

<span data-ttu-id="f8956-421">``WinDbg``メッセージを表示、子のデバッグを有効にして、適切なブレークポイントを設定します。</span><span class="sxs-lookup"><span data-stu-id="f8956-421">At the ``WinDbg`` prompt, enable child debugging and set appropriate breakpoints.</span></span>

```
.childdbg 1
g
```
<span data-ttu-id="f8956-422">(ターゲット アプリケーションが起動し、デバッガーを中断するまで実行)</span><span class="sxs-lookup"><span data-stu-id="f8956-422">(execute until target application starts and breaks into the debugger)</span></span>

```
sxe ld fixup.dll
g
```
<span data-ttu-id="f8956-423">(フィックス アップの DLL が読み込まれるまで実行)</span><span class="sxs-lookup"><span data-stu-id="f8956-423">(execute until the fixup DLL is loaded)</span></span>

```
bp ...
```

>[!NOTE]
> <span data-ttu-id="f8956-424">[PLMDebug](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/plmdebug)は起動時では、アプリケーションにデバッガーをアタッチするのにも使用でき、 [Windows 用デバッグ ツール](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/index)にも含まれます。</span><span class="sxs-lookup"><span data-stu-id="f8956-424">[PLMDebug](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/plmdebug) can be also used to attach a debugger to an app upon launch, and is also included in the [Debugging Tools for Windows](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/index).</span></span>  <span data-ttu-id="f8956-425">ただし、WinDbg によって提供されるようになりました、直接サポートを使用するより複雑なです。</span><span class="sxs-lookup"><span data-stu-id="f8956-425">However, it is more complex to use than the direct support now provided by WinDbg.</span></span>

## <a name="support-and-feedback"></a><span data-ttu-id="f8956-426">サポートとフィードバック</span><span class="sxs-lookup"><span data-stu-id="f8956-426">Support and feedback</span></span>

**<span data-ttu-id="f8956-427">質問に対する回答を見つける</span><span class="sxs-lookup"><span data-stu-id="f8956-427">Find answers to your questions</span></span>**

<span data-ttu-id="f8956-428">ご質問がある場合は、</span><span class="sxs-lookup"><span data-stu-id="f8956-428">Have questions?</span></span> <span data-ttu-id="f8956-429">Stack Overflow でお問い合わせください。</span><span class="sxs-lookup"><span data-stu-id="f8956-429">Ask us on Stack Overflow.</span></span> <span data-ttu-id="f8956-430">Microsoft のチームでは、これらの[タグ](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge)をチェックしています。</span><span class="sxs-lookup"><span data-stu-id="f8956-430">Our team monitors these [tags](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge).</span></span> <span data-ttu-id="f8956-431">[こちら](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D)から質問することもできます。</span><span class="sxs-lookup"><span data-stu-id="f8956-431">You can also ask us [here](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D).</span></span>
