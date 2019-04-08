---
Description: デスクトップ アプリケーションの MSIX コンテナーで実行を妨げる問題を修正します。
Search.Product: eADQiWindows 10XVcnh
title: デスクトップ アプリケーションの MSIX コンテナーで実行を妨げる問題を修正します。
ms.date: 07/02/2018
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 80f9c8bad9445bd9cfef9b09c00f99929fda37aa
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57590727"
---
# <a name="apply-runtime-fixes-to-an-msix-package-by-using-the-package-support-framework"></a><span data-ttu-id="ef727-104">MSIX パッケージにパッケージのサポートのフレームワークを使用してランタイム修正プログラムを適用します。</span><span class="sxs-lookup"><span data-stu-id="ef727-104">Apply runtime fixes to an MSIX package by using the Package Support Framework</span></span>

<span data-ttu-id="ef727-105">パッケージのサポート、フレームワークは、修正プログラムを適用、既存の win32 アプリケーションに、ソース コードへのアクセス権がないときに、MSIX コンテナーで実行できるようにするのに役立つオープン ソース キット。</span><span class="sxs-lookup"><span data-stu-id="ef727-105">The Package Support Framework is an open source kit that helps you apply fixes to your existing win32 application when you don't have access to the source code, so that it can run in an MSIX container.</span></span> <span data-ttu-id="ef727-106">パッケージのサポート、フレームワークには、最新のランタイム環境のベスト プラクティスに従って、アプリケーションが役立ちます。</span><span class="sxs-lookup"><span data-stu-id="ef727-106">The Package Support Framework helps your application follow the best practices of the modern runtime environment.</span></span>

<span data-ttu-id="ef727-107">詳細についてを参照してください。[パッケージ サポート フレームワーク](https://docs.microsoft.com/windows/msix/package-support-framework-overview)します。</span><span class="sxs-lookup"><span data-stu-id="ef727-107">To learn more, see [Package Support Framework](https://docs.microsoft.com/windows/msix/package-support-framework-overview).</span></span>

<span data-ttu-id="ef727-108">このガイドを利用するアプリケーションの互換性の問題を特定して、検索、適用、およびランタイムを拡張するには、それらに対処するを修正します。</span><span class="sxs-lookup"><span data-stu-id="ef727-108">This guide will help you to identify application compatibility issues, and to find, apply, and extend runtime fixes that address them.</span></span>

<a id="identify" />

## <a name="identify-packaged-application-compatibility-issues"></a><span data-ttu-id="ef727-109">パッケージ化されたアプリケーションの互換性の問題を特定します。</span><span class="sxs-lookup"><span data-stu-id="ef727-109">Identify packaged application compatibility issues</span></span>

<span data-ttu-id="ef727-110">最初に、アプリケーションのパッケージを作成します。</span><span class="sxs-lookup"><span data-stu-id="ef727-110">First, create a package for your application.</span></span> <span data-ttu-id="ef727-111">その後、インストール、実行、およびその動作を確認します。</span><span class="sxs-lookup"><span data-stu-id="ef727-111">Then, install it, run it, and observe its behavior.</span></span> <span data-ttu-id="ef727-112">互換性に関する問題の特定に役立つエラー メッセージを表示可能性があります。</span><span class="sxs-lookup"><span data-stu-id="ef727-112">You might receive error messages that can help you identify a compatibility issue.</span></span> <span data-ttu-id="ef727-113">使用することも[プロセス モニター](https://docs.microsoft.com/en-us/sysinternals/downloads/procmon)の問題を特定します。</span><span class="sxs-lookup"><span data-stu-id="ef727-113">You can also use [Process Monitor](https://docs.microsoft.com/en-us/sysinternals/downloads/procmon) to identify issues.</span></span>  <span data-ttu-id="ef727-114">一般的な問題は、作業ディレクトリとプログラムのパスのアクセス許可に関する前提条件をアプリケーションに関連します。</span><span class="sxs-lookup"><span data-stu-id="ef727-114">Common issues relate to application assumptions regarding the working directory and program path permissions.</span></span>

### <a name="using-process-monitor-to-identify-an-issue"></a><span data-ttu-id="ef727-115">Process Monitor を使用して、問題を識別するには</span><span class="sxs-lookup"><span data-stu-id="ef727-115">Using Process Monitor to identify an issue</span></span>

<span data-ttu-id="ef727-116">[プロセス モニター](https://docs.microsoft.com/en-us/sysinternals/downloads/procmon)はアプリのファイルとレジストリの操作とその結果を監視するための強力なユーティリティです。</span><span class="sxs-lookup"><span data-stu-id="ef727-116">[Process Monitor](https://docs.microsoft.com/en-us/sysinternals/downloads/procmon) is a powerful utility for observing an app's file and registry operations, and their results.</span></span>  <span data-ttu-id="ef727-117">アプリケーション互換性の問題を理解することができます。</span><span class="sxs-lookup"><span data-stu-id="ef727-117">This can help you to understand application compatibility issues.</span></span>  <span data-ttu-id="ef727-118">Process Monitor を開いた後、フィルターの追加 (フィルター > フィルター...) アプリケーションの実行可能ファイルからのイベントのみを含めます。</span><span class="sxs-lookup"><span data-stu-id="ef727-118">After opening Process Monitor, add a filter (Filter > Filter…) to include only events from the application executable.</span></span>

![ProcMon アプリのフィルター](images/desktop-to-uwp/procmon_app_filter.png)

<span data-ttu-id="ef727-120">イベントの一覧が表示されます。</span><span class="sxs-lookup"><span data-stu-id="ef727-120">A list of events will appear.</span></span> <span data-ttu-id="ef727-121">これらのイベントでは、単語の多くの**成功**に表示されます、**結果**列。</span><span class="sxs-lookup"><span data-stu-id="ef727-121">For many of these events, the word **SUCCESS** will appear in the **Result** column.</span></span>

![ProcMon イベント](images/desktop-to-uwp/procmon_events.png)

<span data-ttu-id="ef727-123">必要に応じて、のみエラーのみを表示するイベントをフィルター処理することができます。</span><span class="sxs-lookup"><span data-stu-id="ef727-123">Optionally, you can filter events to only show only failures.</span></span>

![ProcMon 除外成功](images/desktop-to-uwp/procmon_exclude_success.png)

<span data-ttu-id="ef727-125">ファイル システム アクセスの失敗を疑いがある場合は、System32/SysWOW64 またはパッケージのファイル パスのいずれかの下にある失敗したイベントを検索します。</span><span class="sxs-lookup"><span data-stu-id="ef727-125">If you suspect a filesystem access failure, search for failed events that are under either the System32/SysWOW64 or the package file path.</span></span> <span data-ttu-id="ef727-126">フィルターも役立ちますここでは、すぎます。</span><span class="sxs-lookup"><span data-stu-id="ef727-126">Filters can also help here, too.</span></span> <span data-ttu-id="ef727-127">この一覧の下部にある開始し、上方向にスクロールします。</span><span class="sxs-lookup"><span data-stu-id="ef727-127">Start at the bottom of this list and scroll upwards.</span></span> <span data-ttu-id="ef727-128">この一覧の下部に表示されるエラーが発生した最も最近です。</span><span class="sxs-lookup"><span data-stu-id="ef727-128">Failures that appear at the bottom of this list have occurred most recently.</span></span> <span data-ttu-id="ef727-129">"パス/名前 not found"、「アクセスが拒否されると、」などの文字列が含まれているエラーをほとんど注意し、不審な外観がないことを無視します。</span><span class="sxs-lookup"><span data-stu-id="ef727-129">Pay most attention to errors that contain strings such as "access denied," and "path/name not found", and ignore things that don't look suspicious.</span></span> <span data-ttu-id="ef727-130">[PSFSample](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/samples/PSFSample/)は 2 つの問題があります。</span><span class="sxs-lookup"><span data-stu-id="ef727-130">The [PSFSample](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/samples/PSFSample/) has two issues.</span></span> <span data-ttu-id="ef727-131">次の図に表示される一覧でこれらの問題が発生することができます。</span><span class="sxs-lookup"><span data-stu-id="ef727-131">You can see those issues in the list that appears in the following image.</span></span>

![ProcMon Config.txt](images/desktop-to-uwp/procmon_config_txt.png)

<span data-ttu-id="ef727-133">このイメージに表示される最初の問題では"C:\Windows\SysWOW64"パスにある"Config.txt"ファイルを読み取るアプリケーションが失敗します。</span><span class="sxs-lookup"><span data-stu-id="ef727-133">In the first issue that appears in this image, the application is failing to read from the "Config.txt" file that is located in the "C:\Windows\SysWOW64" path.</span></span> <span data-ttu-id="ef727-134">可能性の高いアプリケーションがそのパスを直接参照しようとしていることはできません。</span><span class="sxs-lookup"><span data-stu-id="ef727-134">It's unlikely that the application is trying to reference that path directly.</span></span> <span data-ttu-id="ef727-135">相対パスを使用してそのファイルから読み取るしようとして、"System32/SysWOW64"は、アプリケーションの作業ディレクトリを既定では、ほとんどの場合。</span><span class="sxs-lookup"><span data-stu-id="ef727-135">Most likely, it's trying to read from that file by using a relative path, and by default, "System32/SysWOW64" is the application's working directory.</span></span> <span data-ttu-id="ef727-136">これは、アプリケーションがパッケージにどこかに設定する現在の作業ディレクトリを期待していたを示しています。</span><span class="sxs-lookup"><span data-stu-id="ef727-136">This suggests that the application is expecting its current working directory to be set to somewhere in the package.</span></span> <span data-ttu-id="ef727-137">Appx、内部で見ると、実行可能ファイルと同じディレクトリにファイルが存在することを確認できます。</span><span class="sxs-lookup"><span data-stu-id="ef727-137">Looking inside of the appx, we can see that the file exists in the same directory as the executable.</span></span>

![アプリ Config.txt](images/desktop-to-uwp/psfsampleapp_config_txt.png)

<span data-ttu-id="ef727-139">2 つ目の問題は、次の図に表示されます。</span><span class="sxs-lookup"><span data-stu-id="ef727-139">The second issue appears in the following image.</span></span>

![ProcMon ログ ファイル](images/desktop-to-uwp/procmon_logfile.png)

<span data-ttu-id="ef727-141">今月号では、そのパッケージのパスを .log ファイルを記述するアプリケーションが失敗します。</span><span class="sxs-lookup"><span data-stu-id="ef727-141">In this issue, the application is failing to write a .log file to its package path.</span></span> <span data-ttu-id="ef727-142">これにより、ファイル リダイレクト フィックス アップに役立つことが提案します。</span><span class="sxs-lookup"><span data-stu-id="ef727-142">This would suggest that a file redirection fixup might help.</span></span>

<a id="find" />

## <a name="find-a-runtime-fix"></a><span data-ttu-id="ef727-143">ランタイム修正プログラムを検索します。</span><span class="sxs-lookup"><span data-stu-id="ef727-143">Find a runtime fix</span></span>

<span data-ttu-id="ef727-144">PSF には、ファイルのリダイレクトの修正など、現時点で使用できるランタイム修正プログラムが含まれています。</span><span class="sxs-lookup"><span data-stu-id="ef727-144">The PSF contains runtime fixes that you can use right now, such as the file redirection fixup.</span></span>

### <a name="file-redirection-fixup"></a><span data-ttu-id="ef727-145">ファイルのリダイレクトの修正</span><span class="sxs-lookup"><span data-stu-id="ef727-145">File Redirection Fixup</span></span>

<span data-ttu-id="ef727-146">使用することができます、[ファイル リダイレクト Fixup](https://github.com/Microsoft/MSIX-PackageSupportFramework/tree/master/fixups/FileRedirectionFixup)しようとして書き込みまたは読み取り MSIX コンテナーで実行されるアプリケーションからアクセスできないディレクトリ内のデータをリダイレクトします。</span><span class="sxs-lookup"><span data-stu-id="ef727-146">You can use the [File Redirection Fixup](https://github.com/Microsoft/MSIX-PackageSupportFramework/tree/master/fixups/FileRedirectionFixup) to redirect attempts to write or read data in a directory that isn't accessible from an application that runs in an MSIX container.</span></span>

<span data-ttu-id="ef727-147">などの場合は、アプリケーションの実行可能ファイルと同じディレクトリ内にあるログ ファイルに書き込むと、アプリケーション、しを使用できます、[ファイル リダイレクト Fixup](https://github.com/Microsoft/MSIX-PackageSupportFramework/tree/master/fixups/FileRedirectionFixup)ローカル アプリのデータ ストアなどの別の場所にそのログ ファイルを作成します。</span><span class="sxs-lookup"><span data-stu-id="ef727-147">For example, if your application writes to a log file that is in the same directory as your applications executable, then you can use the [File Redirection Fixup](https://github.com/Microsoft/MSIX-PackageSupportFramework/tree/master/fixups/FileRedirectionFixup) to create that log file in another location, such as the local app data store.</span></span>

### <a name="runtime-fixes-from-the-community"></a><span data-ttu-id="ef727-148">コミュニティからのランタイムの修正</span><span class="sxs-lookup"><span data-stu-id="ef727-148">Runtime fixes from the community</span></span>

<span data-ttu-id="ef727-149">コミュニティの貢献を検討してください、 [GitHub](https://github.com/Microsoft/MSIX-PackageSupportFramework)ページ。</span><span class="sxs-lookup"><span data-stu-id="ef727-149">Make sure to review the community contributions to our [GitHub](https://github.com/Microsoft/MSIX-PackageSupportFramework) page.</span></span> <span data-ttu-id="ef727-150">他の開発者が自分とよく似た問題が解決し、ランタイム修正プログラムを共有していることができます。</span><span class="sxs-lookup"><span data-stu-id="ef727-150">It's possible that other developers have resolved an issue similar to yours and have shared a runtime fix.</span></span>

## <a name="apply-a-runtime-fix"></a><span data-ttu-id="ef727-151">ランタイム修正プログラムを適用します。</span><span class="sxs-lookup"><span data-stu-id="ef727-151">Apply a runtime fix</span></span>

<span data-ttu-id="ef727-152">Windows SDK から、次の手順では、いくつかの簡単なツールでの既存のランタイム修正プログラムを適用できます。</span><span class="sxs-lookup"><span data-stu-id="ef727-152">You can apply an existing runtime fix with a few simple tools from the Windows SDK, and by following these steps.</span></span>

> [!div class="checklist"]
> * <span data-ttu-id="ef727-153">パッケージ レイアウト フォルダーを作成します。</span><span class="sxs-lookup"><span data-stu-id="ef727-153">Create a package layout folder</span></span>
> * <span data-ttu-id="ef727-154">パッケージのサポート フレームワーク ファイルを取得します。</span><span class="sxs-lookup"><span data-stu-id="ef727-154">Get the Package Support Framework files</span></span>
> * <span data-ttu-id="ef727-155">パッケージに追加します。</span><span class="sxs-lookup"><span data-stu-id="ef727-155">Add them to your package</span></span>
> * <span data-ttu-id="ef727-156">パッケージ マニフェストの変更</span><span class="sxs-lookup"><span data-stu-id="ef727-156">Modify the package manifest</span></span>
> * <span data-ttu-id="ef727-157">構成ファイルを作成します。</span><span class="sxs-lookup"><span data-stu-id="ef727-157">Create a configuration file</span></span>

<span data-ttu-id="ef727-158">各タスクを見ていきましょう。</span><span class="sxs-lookup"><span data-stu-id="ef727-158">Let's go through each task.</span></span>

### <a name="create-the-package-layout-folder"></a><span data-ttu-id="ef727-159">パッケージ レイアウト フォルダーを作成します。</span><span class="sxs-lookup"><span data-stu-id="ef727-159">Create the package layout folder</span></span>

<span data-ttu-id="ef727-160">.Msix (または .appx) ファイルが既にがある場合は、パッケージのステージング領域として機能するレイアウト フォルダーにその内容をアンパックすることができます。</span><span class="sxs-lookup"><span data-stu-id="ef727-160">If you have a .msix (or .appx) file already, you can unpack its contents into a layout folder that will serve as the staging area for your package.</span></span> <span data-ttu-id="ef727-161">SDK のインストール パスに基づく MakeAppx ツールを使用してコマンド プロンプトから実行することが、これは、Windows 10 PC で makeappx.exe ツールを表示します x86:。C:\Program Files (x86) \Windows Kits\10\bin\x86\makeappx.exe x64:C:\Program Files (x86) \Windows Kits\10\bin\x64\makeappx.exe</span><span class="sxs-lookup"><span data-stu-id="ef727-161">You can do this from a command prompt using MakeAppx tool, based on your installation path of the SDK, this is where you will find the makeappx.exe tool on your Windows 10 PC: x86: C:\Program Files (x86)\Windows Kits\10\bin\x86\makeappx.exe x64: C:\Program Files (x86)\Windows Kits\10\bin\x64\makeappx.exe</span></span>

```ps
makeappx unpack /p PSFSamplePackage_1.0.60.0_AnyCPU_Debug.msix /d PackageContents

```

<span data-ttu-id="ef727-162">これが表示されます、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="ef727-162">This will give you something that looks like the following.</span></span>

![パッケージのレイアウト](images/desktop-to-uwp/package_contents.png)

<span data-ttu-id="ef727-164">を持っていない .msix (または .appx) ファイルから始める場合は、最初からパッケージ フォルダーとファイルを作成できます。</span><span class="sxs-lookup"><span data-stu-id="ef727-164">If you don't have a .msix (or .appx) file to start with, you can create the package folder and files from scratch.</span></span>

### <a name="get-the-package-support-framework-files"></a><span data-ttu-id="ef727-165">パッケージのサポート フレームワーク ファイルを取得します。</span><span class="sxs-lookup"><span data-stu-id="ef727-165">Get the Package Support Framework files</span></span>

<span data-ttu-id="ef727-166">PSF Nuget パッケージは、スタンドアロンの Nuget コマンド ライン ツールを使用して、または Visual Studio を使用して取得できます。</span><span class="sxs-lookup"><span data-stu-id="ef727-166">You can get the PSF Nuget package by using the standalone Nuget command line tool or via Visual Studio.</span></span>

#### <a name="get-the-package-by-using-the-command-line-tool"></a><span data-ttu-id="ef727-167">コマンド ライン ツールを使用してパッケージを取得します。</span><span class="sxs-lookup"><span data-stu-id="ef727-167">Get the package by using the command line tool</span></span>

<span data-ttu-id="ef727-168">この場所からの Nuget コマンド ライン ツールのインストール:https://www.nuget.org/downloadsします。</span><span class="sxs-lookup"><span data-stu-id="ef727-168">Install the Nuget command line tool from this location: https://www.nuget.org/downloads.</span></span> <span data-ttu-id="ef727-169">次に、Nuget コマンドラインからこのコマンドを実行します。</span><span class="sxs-lookup"><span data-stu-id="ef727-169">Then, from the Nuget command line, run this command:</span></span>

```ps
nuget install Microsoft.PackageSupportFramework
```

#### <a name="get-the-package-by-using-visual-studio"></a><span data-ttu-id="ef727-170">Visual Studio を使用してパッケージを取得します。</span><span class="sxs-lookup"><span data-stu-id="ef727-170">Get the package by using Visual Studio</span></span>

<span data-ttu-id="ef727-171">Visual Studio で、ソリューションまたはプロジェクト ノードを右クリックし、Nuget パッケージの管理コマンドのいずれかを選択します。</span><span class="sxs-lookup"><span data-stu-id="ef727-171">In Visual Studio, right-click your solution or project node and pick one of the Manage Nuget Packages commands.</span></span>  <span data-ttu-id="ef727-172">検索**Microsoft.PackageSupportFramework**または**PSF** Nuget.org でパッケージを検索します。次に、インストールします。</span><span class="sxs-lookup"><span data-stu-id="ef727-172">Search for **Microsoft.PackageSupportFramework** or **PSF** to find the package on Nuget.org. Then, install it.</span></span>

### <a name="add-the-package-support-framework-files-to-your-package"></a><span data-ttu-id="ef727-173">パッケージのサポート フレームワーク ファイルをパッケージに追加します。</span><span class="sxs-lookup"><span data-stu-id="ef727-173">Add the Package Support Framework files to your package</span></span>

<span data-ttu-id="ef727-174">パッケージ ディレクトリに必要な 32 ビットおよび 64 ビット PSF Dll と実行可能ファイルを追加します。</span><span class="sxs-lookup"><span data-stu-id="ef727-174">Add the required 32-bit and 64-bit PSF  DLLs and executable files to the package directory.</span></span> <span data-ttu-id="ef727-175">次の表をガイドとして使用してください。</span><span class="sxs-lookup"><span data-stu-id="ef727-175">Use the following table as a guide.</span></span> <span data-ttu-id="ef727-176">含める必要があるランタイム修正する必要もあります。</span><span class="sxs-lookup"><span data-stu-id="ef727-176">You'll also want to include any runtime fixes that you need.</span></span> <span data-ttu-id="ef727-177">この例では、ファイル リダイレクト ランタイム修正プログラムが必要です。</span><span class="sxs-lookup"><span data-stu-id="ef727-177">In our example, we need the file redirection runtime fix.</span></span>

| <span data-ttu-id="ef727-178">アプリケーション実行可能ファイルは、x64</span><span class="sxs-lookup"><span data-stu-id="ef727-178">Application executable is x64</span></span> | <span data-ttu-id="ef727-179">アプリケーション実行可能ファイルは、x86</span><span class="sxs-lookup"><span data-stu-id="ef727-179">Application executable is x86</span></span> |
|-------------------------------|-----------|
| [<span data-ttu-id="ef727-180">PSFLauncher64.exe</span><span class="sxs-lookup"><span data-stu-id="ef727-180">PSFLauncher64.exe</span></span>](https://github.com/Microsoft/MSIX-PackageSupportFramework/tree/master/PsfLauncher/readme.md) |  [<span data-ttu-id="ef727-181">PSFLauncher32.exe</span><span class="sxs-lookup"><span data-stu-id="ef727-181">PSFLauncher32.exe</span></span>](https://github.com/Microsoft/MSIX-PackageSupportFramework/tree/master/PsfLauncher/readme.md) |
| [<span data-ttu-id="ef727-182">PSFRuntime64.dll</span><span class="sxs-lookup"><span data-stu-id="ef727-182">PSFRuntime64.dll</span></span>](https://github.com/Microsoft/MSIX-PackageSupportFramework/tree/master/PsfRuntime/readme.md) | [<span data-ttu-id="ef727-183">PSFRuntime32.dll</span><span class="sxs-lookup"><span data-stu-id="ef727-183">PSFRuntime32.dll</span></span>](https://github.com/Microsoft/MSIX-PackageSupportFramework/tree/master/PsfRuntime/readme.md) |
| [<span data-ttu-id="ef727-184">PSFRunDll64.exe</span><span class="sxs-lookup"><span data-stu-id="ef727-184">PSFRunDll64.exe</span></span>](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/PsfRunDll/readme.md) | [<span data-ttu-id="ef727-185">PSFRunDll32.exe</span><span class="sxs-lookup"><span data-stu-id="ef727-185">PSFRunDll32.exe</span></span>](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/PsfRunDll/readme.md) |

<span data-ttu-id="ef727-186">パッケージの内容は次のようになります。</span><span class="sxs-lookup"><span data-stu-id="ef727-186">Your package content should now look something like this.</span></span>

![パッケージのバイナリ](images/desktop-to-uwp/package_binaries.png)

### <a name="modify-the-package-manifest"></a><span data-ttu-id="ef727-188">パッケージ マニフェストの変更</span><span class="sxs-lookup"><span data-stu-id="ef727-188">Modify the package manifest</span></span>

<span data-ttu-id="ef727-189">テキスト エディターで、パッケージ マニフェストを開き、設定し、`Executable`の属性、`Application`要素 PSF 起動ツールの実行可能ファイルの名前にします。</span><span class="sxs-lookup"><span data-stu-id="ef727-189">Open your package manifest in a text editor, and then set the `Executable` attribute of the `Application` element to the name of the PSF launcher executable file.</span></span>  <span data-ttu-id="ef727-190">ターゲット アプリケーションのアーキテクチャがわかっている場合は、PSFLauncher32.exe または PSFLauncher64.exe は、適切なバージョンを選択します。</span><span class="sxs-lookup"><span data-stu-id="ef727-190">If you know the architecture of your target application, select the appropriate version, PSFLauncher32.exe or PSFLauncher64.exe.</span></span>  <span data-ttu-id="ef727-191">ない場合は、PSFLauncher32.exe は常に動作します。</span><span class="sxs-lookup"><span data-stu-id="ef727-191">If not, PSFLauncher32.exe will work in all cases.</span></span>  <span data-ttu-id="ef727-192">次に例を示します。</span><span class="sxs-lookup"><span data-stu-id="ef727-192">Here's an example.</span></span>

```xml
<Package ...>
  ...
  <Applications>
    <Application Id="PSFSample"
                 Executable="PSFLauncher32.exe"
                 EntryPoint="Windows.FullTrustApplication">
      ...
    </Application>
  </Applications>
</Package>
```

### <a name="create-a-configuration-file"></a><span data-ttu-id="ef727-193">構成ファイルを作成します。</span><span class="sxs-lookup"><span data-stu-id="ef727-193">Create a configuration file</span></span>

<span data-ttu-id="ef727-194">ファイル名を作成``config.json``パッケージのルート フォルダーにそのファイルを保存します。</span><span class="sxs-lookup"><span data-stu-id="ef727-194">Create a file name ``config.json``, and save that file to the root folder of your package.</span></span> <span data-ttu-id="ef727-195">交換した実行可能ファイルをポイントする config.json ファイルの宣言されたアプリ ID を変更します。</span><span class="sxs-lookup"><span data-stu-id="ef727-195">Modify the declared app ID of the config.json file to point to the executable that you just replaced.</span></span> <span data-ttu-id="ef727-196">Process Monitor を使用してから、獲得した知識を使用して、することができますも作業ディレクトリの設定だけでなくファイル リダイレクト フィックス アップを使用してパッケージ相対"PSFSampleApp"ディレクトリの下の .log ファイルに読み取り/書き込みをリダイレクトします。</span><span class="sxs-lookup"><span data-stu-id="ef727-196">Using the knowledge that you gained from using Process Monitor, you can also set the working directory as well as use the file redirection fixup to redirect reads/writes to .log files under the package-relative "PSFSampleApp" directory.</span></span>

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
            "fixups": [
                {
                    "dll": "FileRedirectionFixup.dll",
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

<span data-ttu-id="ef727-197">Config.json スキーマのためのガイドを次に示します。</span><span class="sxs-lookup"><span data-stu-id="ef727-197">Following is a guide for the config.json schema:</span></span>

| <span data-ttu-id="ef727-198">配列</span><span class="sxs-lookup"><span data-stu-id="ef727-198">Array</span></span> | <span data-ttu-id="ef727-199">key</span><span class="sxs-lookup"><span data-stu-id="ef727-199">key</span></span> | <span data-ttu-id="ef727-200">Value</span><span class="sxs-lookup"><span data-stu-id="ef727-200">Value</span></span> |
|-------|-----------|-------|
| <span data-ttu-id="ef727-201">applications</span><span class="sxs-lookup"><span data-stu-id="ef727-201">applications</span></span> | <span data-ttu-id="ef727-202">id</span><span class="sxs-lookup"><span data-stu-id="ef727-202">id</span></span> |  <span data-ttu-id="ef727-203">値を使用して、`Id`の属性、`Application`パッケージ マニフェスト内の要素。</span><span class="sxs-lookup"><span data-stu-id="ef727-203">Use the value of the `Id` attribute of the `Application` element in the package manifest.</span></span> |
| <span data-ttu-id="ef727-204">applications</span><span class="sxs-lookup"><span data-stu-id="ef727-204">applications</span></span> | <span data-ttu-id="ef727-205">実行可能ファイル</span><span class="sxs-lookup"><span data-stu-id="ef727-205">executable</span></span> | <span data-ttu-id="ef727-206">開始する実行可能ファイルへのパッケージの相対パス。</span><span class="sxs-lookup"><span data-stu-id="ef727-206">The package-relative path to the executable that you want to start.</span></span> <span data-ttu-id="ef727-207">ほとんどの場合、変更する前に、パッケージ マニフェスト ファイルからこの値を取得できます。</span><span class="sxs-lookup"><span data-stu-id="ef727-207">In most cases, you can get this value from your package manifest file before you modify it.</span></span> <span data-ttu-id="ef727-208">値は、`Executable`の属性、`Application`要素。</span><span class="sxs-lookup"><span data-stu-id="ef727-208">It's the value of the `Executable` attribute of the `Application` element.</span></span> |
| <span data-ttu-id="ef727-209">applications</span><span class="sxs-lookup"><span data-stu-id="ef727-209">applications</span></span> | <span data-ttu-id="ef727-210">WorkingDirectory</span><span class="sxs-lookup"><span data-stu-id="ef727-210">workingDirectory</span></span> | <span data-ttu-id="ef727-211">(省略可能)起動するアプリケーションの作業ディレクトリとして使用するパッケージの相対パス。</span><span class="sxs-lookup"><span data-stu-id="ef727-211">(Optional) A package-relative path to use as the working directory of the application that starts.</span></span> <span data-ttu-id="ef727-212">オペレーティング システムを使用して、この値を設定しない場合、`System32`ディレクトリをアプリケーションの作業ディレクトリ。</span><span class="sxs-lookup"><span data-stu-id="ef727-212">If you don't set this value, the operating system uses the `System32` directory as the application's working directory.</span></span> |
| <span data-ttu-id="ef727-213">プロセス</span><span class="sxs-lookup"><span data-stu-id="ef727-213">processes</span></span> | <span data-ttu-id="ef727-214">実行可能ファイル</span><span class="sxs-lookup"><span data-stu-id="ef727-214">executable</span></span> | <span data-ttu-id="ef727-215">ほとんどの場合、対象になりますの名前、`executable`削除パスとファイル拡張子で上に構成されています。</span><span class="sxs-lookup"><span data-stu-id="ef727-215">In most cases, this will be the name of the `executable` configured above with the path and file extension removed.</span></span> |
| <span data-ttu-id="ef727-216">フィックス アップ</span><span class="sxs-lookup"><span data-stu-id="ef727-216">fixups</span></span> | <span data-ttu-id="ef727-217">dll</span><span class="sxs-lookup"><span data-stu-id="ef727-217">dll</span></span> | <span data-ttu-id="ef727-218">修正、.msix/.appx を読み込むパッケージの相対パス。</span><span class="sxs-lookup"><span data-stu-id="ef727-218">Package-relative path to the fixup, .msix/.appx  to load.</span></span> |
| <span data-ttu-id="ef727-219">フィックス アップ</span><span class="sxs-lookup"><span data-stu-id="ef727-219">fixups</span></span> | <span data-ttu-id="ef727-220">構成</span><span class="sxs-lookup"><span data-stu-id="ef727-220">config</span></span> | <span data-ttu-id="ef727-221">(省略可能)フィックス アップ dl の動作を制御します。</span><span class="sxs-lookup"><span data-stu-id="ef727-221">(Optional) Controls how the fixup dl behaves.</span></span> <span data-ttu-id="ef727-222">この値の正確な形式は、各フィックス アップが必要があると"blob"を解釈できるよう、フィックス アップの修正によってごとに異なります。</span><span class="sxs-lookup"><span data-stu-id="ef727-222">The exact format of this value varies on a fixup-by-fixup basis as each fixup can interpret this "blob" as it wants.</span></span> |

<span data-ttu-id="ef727-223">`applications`、 `processes`、および`fixups`キーは配列です。</span><span class="sxs-lookup"><span data-stu-id="ef727-223">The `applications`, `processes`, and `fixups` keys are arrays.</span></span> <span data-ttu-id="ef727-224">つまり、1 つ以上のアプリケーション、プロセス、および DLL のフィックス アップを指定する config.json ファイルを使用することができます。</span><span class="sxs-lookup"><span data-stu-id="ef727-224">That means that you can use the config.json file to specify more than one application, process, and fixup DLL.</span></span>

### <a name="package-and-test-the-app"></a><span data-ttu-id="ef727-225">パッケージとアプリをテストします</span><span class="sxs-lookup"><span data-stu-id="ef727-225">Package and Test the App</span></span>

<span data-ttu-id="ef727-226">次に、パッケージを作成します。</span><span class="sxs-lookup"><span data-stu-id="ef727-226">Next, create a package.</span></span>

```ps
makeappx pack /d PackageContents /p PSFSamplePackageFixup.msix
```

<span data-ttu-id="ef727-227">次に、署名します。</span><span class="sxs-lookup"><span data-stu-id="ef727-227">Then, sign it.</span></span>

```ps
signtool sign /a /v /fd sha256 /f ExportedSigningCertificate.pfx PSFSamplePackageFixup.msix
```

<span data-ttu-id="ef727-228">詳細については、次を参照してください[署名証明書パッケージを作成する方法](https://docs.microsoft.com/en-us/windows/desktop/appxpkg/how-to-create-a-package-signing-certificate)と[signtool を使用してパッケージに署名する方法。](https://docs.microsoft.com/en-us/windows/desktop/appxpkg/how-to-sign-a-package-using-signtool)</span><span class="sxs-lookup"><span data-stu-id="ef727-228">For more information, see [how to create a package signing certificate](https://docs.microsoft.com/en-us/windows/desktop/appxpkg/how-to-create-a-package-signing-certificate) and [how to sign a package using signtool](https://docs.microsoft.com/en-us/windows/desktop/appxpkg/how-to-sign-a-package-using-signtool)</span></span>

<span data-ttu-id="ef727-229">PowerShell を使用してパッケージをインストールします。</span><span class="sxs-lookup"><span data-stu-id="ef727-229">Using PowerShell, install the package.</span></span>

>[!NOTE]
> <span data-ttu-id="ef727-230">まず、パッケージをアンインストールしてください。</span><span class="sxs-lookup"><span data-stu-id="ef727-230">Remember to uninstall the package first.</span></span>

```ps
powershell Add-AppPackage .\PSFSamplePackageFixup.msix
```

<span data-ttu-id="ef727-231">アプリケーションを実行し、ランタイムの修正プログラムが適用されると、動作を確認します。</span><span class="sxs-lookup"><span data-stu-id="ef727-231">Run the application and observe the behavior with runtime fix applied.</span></span>  <span data-ttu-id="ef727-232">診断および必要に応じて、パッケージ化の手順を繰り返します。</span><span class="sxs-lookup"><span data-stu-id="ef727-232">Repeat the diagnostic and packaging steps as necessary.</span></span>

### <a name="use-the-trace-fixup"></a><span data-ttu-id="ef727-233">トレースのフィックス アップを使用して、</span><span class="sxs-lookup"><span data-stu-id="ef727-233">Use the Trace Fixup</span></span>

<span data-ttu-id="ef727-234">パッケージ化されたアプリケーション互換性の問題を診断するために別の手法では、トレースのフィックス アップを使用します。</span><span class="sxs-lookup"><span data-stu-id="ef727-234">An alternative technique to diagnosing packaged application compatibility issues is to use the Trace Fixup.</span></span> <span data-ttu-id="ef727-235">この DLL は、PSF に含まれているし、プロセス モニターと類似した、アプリの動作の詳細な診断ビューを提供します。</span><span class="sxs-lookup"><span data-stu-id="ef727-235">This DLL is included with the PSF and provides a detailed diagnostic view of the app's behavior, similar to Process Monitor.</span></span>  <span data-ttu-id="ef727-236">アプリケーション互換性の問題を表示するように設計します。</span><span class="sxs-lookup"><span data-stu-id="ef727-236">It is specially designed to reveal application compatibility issues.</span></span>  <span data-ttu-id="ef727-237">トレース フィックス アップ、DLL、パッケージを追加するの config.json に次のフラグメントを追加しパッケージ化をし使用するアプリケーションをインストールします。</span><span class="sxs-lookup"><span data-stu-id="ef727-237">To use the Trace Fixup, add the DLL to the package, add the following fragment to your config.json, and then package and install your application.</span></span>

```json
{
    "dll": "TraceFixup.dll",
    "config": {
        "traceLevels": {
            "filesystem": "allFailures"
        }
    }
}
```

<span data-ttu-id="ef727-238">既定では、トレースのフィックス アップ「が必要です」と見なされてエラーが除外されます。</span><span class="sxs-lookup"><span data-stu-id="ef727-238">By default, the Trace Fixup filters out failures that might be considered "expected".</span></span>  <span data-ttu-id="ef727-239">たとえば、アプリケーションは、無条件でファイルを削除するかどうかは、既に存在する、結果を無視して確認せずにしようと可能性があります。</span><span class="sxs-lookup"><span data-stu-id="ef727-239">For example, applications might try to unconditionally delete a file without checking to see if it already exists, ignoring the result.</span></span> <span data-ttu-id="ef727-240">これは、上記の例では、ことを選択します filesystem 関数からすべてのエラーを受信するためのいくつかの予期しないエラーが取得除外された、残念な結果です。</span><span class="sxs-lookup"><span data-stu-id="ef727-240">This has the unfortunate consequence that some unexpected failures might get filtered out, so in the above example, we opt to receive all failures from filesystem functions.</span></span> <span data-ttu-id="ef727-241">そうため、その前に、Config.txt ファイルから読み取りを試みるは、メッセージ「ファイルが見つかりません」で失敗からわかるようにします。</span><span class="sxs-lookup"><span data-stu-id="ef727-241">We do this because we know from before that the attempt to read from the Config.txt file fails with the message "file not found".</span></span> <span data-ttu-id="ef727-242">これは、障害が頻繁に観察しは、一般に、予期できないと見なされます。</span><span class="sxs-lookup"><span data-stu-id="ef727-242">This is a failure that is frequently observed and not generally assumed to be unexpected.</span></span> <span data-ttu-id="ef727-243">実際には予期しない故障にのみフィルター処理し、フォールバックしてエラーをすべてまだ識別できない問題がある場合を開始する可能性の高い最適になります。</span><span class="sxs-lookup"><span data-stu-id="ef727-243">In practice it's likely best to start out filtering only to unexpected failures, and then falling back to all failures if there's an issue that still can't be identified.</span></span>

<span data-ttu-id="ef727-244">既定では、トレースの修正から出力を取得、アタッチされたデバッガーに送信されます。</span><span class="sxs-lookup"><span data-stu-id="ef727-244">By default, the output from the Trace Fixup gets sent to the attached debugger.</span></span> <span data-ttu-id="ef727-245">この例では、デバッガーをアタッチしようとしています。 おは代わりに使用、 [DebugView](https://docs.microsoft.com/en-us/sysinternals/downloads/debugview) sysinternals 出力を表示するプログラム。</span><span class="sxs-lookup"><span data-stu-id="ef727-245">For this example, we aren't going to attach a debugger, and will instead use the [DebugView](https://docs.microsoft.com/en-us/sysinternals/downloads/debugview) program from SysInternals to view its output.</span></span> <span data-ttu-id="ef727-246">アプリを実行した後には、ことがわかります同じ障害と同様に、同じランタイム修正プログラムにごポイントします。</span><span class="sxs-lookup"><span data-stu-id="ef727-246">After running the app, we can see the same failures as before, which would point us towards the same runtime fixes.</span></span>

![TraceShim ファイルが見つかりません](images/desktop-to-uwp/traceshim_filenotfound.png)

![TraceShim アクセスが拒否されました](images/desktop-to-uwp/traceshim_accessdenied.png)

## <a name="debug-extend-or-create-a-runtime-fix"></a><span data-ttu-id="ef727-249">デバッグ、拡張、またはランタイム修正プログラムの作成</span><span class="sxs-lookup"><span data-stu-id="ef727-249">Debug, extend, or create a runtime fix</span></span>

<span data-ttu-id="ef727-250">Visual Studio を使用して、ランタイム修正プログラムをデバッグ、実行時の修正プログラムを拡張または最初から作成することができます。</span><span class="sxs-lookup"><span data-stu-id="ef727-250">You can use Visual Studio to debug a runtime fix, extend a runtime fix, or create one from scratch.</span></span> <span data-ttu-id="ef727-251">成功するこれらの作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="ef727-251">You'll need to do these things to be successful.</span></span>

> [!div class="checklist"]
> * <span data-ttu-id="ef727-252">パッケージのプロジェクトを追加します。</span><span class="sxs-lookup"><span data-stu-id="ef727-252">Add a packaging project</span></span>
> * <span data-ttu-id="ef727-253">プロジェクト ランタイム修正プログラムを追加します。</span><span class="sxs-lookup"><span data-stu-id="ef727-253">Add project for the runtime fix</span></span>
> * <span data-ttu-id="ef727-254">実行可能ファイルの PSF ランチャーを起動するプロジェクトを追加します。</span><span class="sxs-lookup"><span data-stu-id="ef727-254">Add a project that starts the PSF Launcher executable</span></span>
> * <span data-ttu-id="ef727-255">パッケージ プロジェクトを構成します。</span><span class="sxs-lookup"><span data-stu-id="ef727-255">Configure the packaging project</span></span>

<span data-ttu-id="ef727-256">完了すると、ソリューションは次のようになります。</span><span class="sxs-lookup"><span data-stu-id="ef727-256">When you're done, your solution will look something like this.</span></span>

![完成したソリューション](images/desktop-to-uwp/runtime-fix-project-structure.png)

<span data-ttu-id="ef727-258">この例では、各プロジェクトを見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="ef727-258">Let's look at each project in this example.</span></span>

| <span data-ttu-id="ef727-259">Project</span><span class="sxs-lookup"><span data-stu-id="ef727-259">Project</span></span> | <span data-ttu-id="ef727-260">目的</span><span class="sxs-lookup"><span data-stu-id="ef727-260">Purpose</span></span> |
|-------|-----------|
| <span data-ttu-id="ef727-261">DesktopApplicationPackage</span><span class="sxs-lookup"><span data-stu-id="ef727-261">DesktopApplicationPackage</span></span> | <span data-ttu-id="ef727-262">このプロジェクトがに基づいて、 [Windows アプリケーション パッケージ プロジェクト](desktop-to-uwp-packaging-dot-net.md)MSIX パッケージを出力します。</span><span class="sxs-lookup"><span data-stu-id="ef727-262">This project is based on the [Windows Application Packaging project](desktop-to-uwp-packaging-dot-net.md) and it outputs the MSIX package.</span></span> |
| <span data-ttu-id="ef727-263">Runtimefix</span><span class="sxs-lookup"><span data-stu-id="ef727-263">Runtimefix</span></span> | <span data-ttu-id="ef727-264">これは、ランタイム修正プログラムとして機能する 1 つまたは複数の置換関数を含む C++ Dynamic-Linked ライブラリ プロジェクトです。</span><span class="sxs-lookup"><span data-stu-id="ef727-264">This is a C++ Dynamic-Linked Library project that contains one or more replacement functions that serve as the runtime fix.</span></span> |
| <span data-ttu-id="ef727-265">PSFLauncher</span><span class="sxs-lookup"><span data-stu-id="ef727-265">PSFLauncher</span></span> | <span data-ttu-id="ef727-266">これは、C++ の空のプロジェクトです。</span><span class="sxs-lookup"><span data-stu-id="ef727-266">This is C++ Empty Project.</span></span> <span data-ttu-id="ef727-267">このプロジェクトは、パッケージのサポート、フレームワークのランタイム再頒布可能ファイルを収集する場所です。</span><span class="sxs-lookup"><span data-stu-id="ef727-267">This project is a place to collect the runtime distributable files of the Package Support Framework.</span></span> <span data-ttu-id="ef727-268">実行可能ファイルを出力します。</span><span class="sxs-lookup"><span data-stu-id="ef727-268">It outputs an executable file.</span></span> <span data-ttu-id="ef727-269">この実行可能ファイルとは、ソリューションを開始するときに実行される最初のことです。</span><span class="sxs-lookup"><span data-stu-id="ef727-269">That executable is the first thing that runs when you start the solution.</span></span> |
| <span data-ttu-id="ef727-270">WinFormsDesktopApplication</span><span class="sxs-lookup"><span data-stu-id="ef727-270">WinFormsDesktopApplication</span></span> | <span data-ttu-id="ef727-271">このプロジェクトには、デスクトップ アプリケーションのソース コードが含まれています。</span><span class="sxs-lookup"><span data-stu-id="ef727-271">This project contains the source code of a desktop application.</span></span> |

<span data-ttu-id="ef727-272">これらの種類のプロジェクトのすべてを含む完全なサンプルを見るを参照してください。 [PSFSample](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/samples/PSFSample/)します。</span><span class="sxs-lookup"><span data-stu-id="ef727-272">To look at a complete sample that contains all of these types of projects, see [PSFSample](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/samples/PSFSample/).</span></span>

<span data-ttu-id="ef727-273">作成し、ソリューションでこれらの各プロジェクトを構成する手順を見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="ef727-273">Let's walk through the steps to create and configure each of these projects in your solution.</span></span>

### <a name="create-a-package-solution"></a><span data-ttu-id="ef727-274">パッケージ ソリューションを作成します。</span><span class="sxs-lookup"><span data-stu-id="ef727-274">Create a package solution</span></span>

<span data-ttu-id="ef727-275">デスクトップ アプリケーションのソリューションがいない場合は、新しい作成**空のソリューション**Visual Studio でします。</span><span class="sxs-lookup"><span data-stu-id="ef727-275">If you don't already have a solution for your desktop application, create a new **Blank Solution** in Visual Studio.</span></span>

![空のソリューション](images/desktop-to-uwp/blank-solution.png)

<span data-ttu-id="ef727-277">持つ任意のアプリケーション プロジェクトを追加することもできます。</span><span class="sxs-lookup"><span data-stu-id="ef727-277">You may also want to add any application projects you have.</span></span>

### <a name="add-a-packaging-project"></a><span data-ttu-id="ef727-278">パッケージのプロジェクトを追加します。</span><span class="sxs-lookup"><span data-stu-id="ef727-278">Add a packaging project</span></span>

<span data-ttu-id="ef727-279">まだ持っていない場合、 **Windows アプリケーション パッケージ プロジェクト**、1 つを作成し、ソリューションに追加します。</span><span class="sxs-lookup"><span data-stu-id="ef727-279">If you don't already have a **Windows Application Packaging Project**, create one and add it to your solution.</span></span>

![パッケージ プロジェクト テンプレート](images/desktop-to-uwp/package-project-template.png)

<span data-ttu-id="ef727-281">Windows アプリケーション パッケージ プロジェクトの詳細については、次を参照してください。 [Visual Studio を使用して、アプリケーションをパッケージ化](desktop-to-uwp-packaging-dot-net.md)します。</span><span class="sxs-lookup"><span data-stu-id="ef727-281">For more information on Windows Application Packaging project, see [Package your application by using Visual Studio](desktop-to-uwp-packaging-dot-net.md).</span></span>

<span data-ttu-id="ef727-282">**ソリューション エクスプ ローラー**をパッケージ プロジェクトを右クリックして選択**編集**、し、これをプロジェクト ファイルの末尾に追加します。</span><span class="sxs-lookup"><span data-stu-id="ef727-282">In **Solution Explorer**, right-click the packaging project, select **Edit**, and then add this to the bottom of the project file:</span></span>

```xml
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

### <a name="add-project-for-the-runtime-fix"></a><span data-ttu-id="ef727-283">プロジェクト ランタイム修正プログラムを追加します。</span><span class="sxs-lookup"><span data-stu-id="ef727-283">Add project for the runtime fix</span></span>

<span data-ttu-id="ef727-284">C++ の追加**ダイナミック リンク ライブラリ (DLL)** プロジェクトがソリューションにします。</span><span class="sxs-lookup"><span data-stu-id="ef727-284">Add a C++ **Dynamic-Link Library (DLL)** project to the solution.</span></span>

![修正プログラムのランタイム ライブラリ](images/desktop-to-uwp/runtime-fix-library.png)

<span data-ttu-id="ef727-286">クリックして、プロジェクトを右クリックして**プロパティ**します。</span><span class="sxs-lookup"><span data-stu-id="ef727-286">Right-click the that project, and then choose **Properties**.</span></span>

<span data-ttu-id="ef727-287">プロパティ ページで、 **C 言語標準**フィールド、およびそのフィールドの横にあるドロップダウン リストを選択します、 **ISO c++ 17 標準 (//std:c + + 17)** オプション。</span><span class="sxs-lookup"><span data-stu-id="ef727-287">In the property pages, find the **C++ Language Standard** field, and then in the drop-down list next to that field, select the **ISO C++17 Standard (/std:c++17)** option.</span></span>

![17 の ISO オプション](images/desktop-to-uwp/iso-option.png)

<span data-ttu-id="ef727-289">そのプロジェクトを右クリックし、コンテキスト メニューを選択、 **Nuget パッケージの管理**オプション。</span><span class="sxs-lookup"><span data-stu-id="ef727-289">Right-click that project, and then in the context menu, choose the **Manage Nuget Packages** option.</span></span> <span data-ttu-id="ef727-290">いることを確認、**パッケージ ソース**にオプションが設定されている**すべて**または**nuget.org**します。</span><span class="sxs-lookup"><span data-stu-id="ef727-290">Ensure that the **Package source** option is set to **All** or **nuget.org**.</span></span>

<span data-ttu-id="ef727-291">次にそのフィールドの設定 アイコンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="ef727-291">Click the settings icon next that field.</span></span>

<span data-ttu-id="ef727-292">検索、 *PSF*\* Nuget をパッケージ化し、このプロジェクトにインストールします。</span><span class="sxs-lookup"><span data-stu-id="ef727-292">Search for the *PSF*\* Nuget package, and then install it for this project.</span></span>

![nuget パッケージ](images/desktop-to-uwp/psf-package.png)

<span data-ttu-id="ef727-294">デバッグまたは既存のランタイム修正プログラムを拡張する場合は、追加で説明されているガイダンスを使用して取得したランタイム修正プログラム ファイル、[ランタイム修正プログラムを見つける](#find)このガイドの「します。</span><span class="sxs-lookup"><span data-stu-id="ef727-294">If you want to debug or extend an existing runtime fix, add the runtime fix files that you obtained by using the guidance described in the [Find a runtime fix](#find) section of this guide.</span></span>

<span data-ttu-id="ef727-295">新しい修正プログラムを作成する場合は、何も追加しないこのプロジェクトにまだだけです。</span><span class="sxs-lookup"><span data-stu-id="ef727-295">If you intend to create a brand new fix, don't add anything to this project just yet.</span></span> <span data-ttu-id="ef727-296">このガイドの後半では、このプロジェクトに適切なファイルを追加する手伝いします。</span><span class="sxs-lookup"><span data-stu-id="ef727-296">We'll help you add the right files to this project later in this guide.</span></span> <span data-ttu-id="ef727-297">ここでは、ソリューションの設定がいく予定です。</span><span class="sxs-lookup"><span data-stu-id="ef727-297">For now, we'll continue setting up your solution.</span></span>

### <a name="add-a-project-that-starts-the-psf-launcher-executable"></a><span data-ttu-id="ef727-298">実行可能ファイルの PSF ランチャーを起動するプロジェクトを追加します。</span><span class="sxs-lookup"><span data-stu-id="ef727-298">Add a project that starts the PSF Launcher executable</span></span>

<span data-ttu-id="ef727-299">C++ の追加**空のプロジェクト**プロジェクトがソリューションにします。</span><span class="sxs-lookup"><span data-stu-id="ef727-299">Add a C++ **Empty Project** project to the solution.</span></span>

![空のプロジェクト](images/desktop-to-uwp/blank-app.png)

<span data-ttu-id="ef727-301">追加、 **PSF**前のセクションで説明されている同じガイダンスを使用してこのプロジェクトに Nuget パッケージ。</span><span class="sxs-lookup"><span data-stu-id="ef727-301">Add the **PSF** Nuget package to this project by using the same guidance described in the previous section.</span></span>

<span data-ttu-id="ef727-302">で、プロジェクトのプロパティ ページを開く、**全般**設定ページで、設定、**ターゲット名**プロパティを``PSFLauncher32``または``PSFLauncher64``アプリケーションのアーキテクチャに応じて。</span><span class="sxs-lookup"><span data-stu-id="ef727-302">Open the property pages for the project, and in the **General** settings page, set the **Target Name** property to ``PSFLauncher32`` or ``PSFLauncher64`` depending on the architecture of your application.</span></span>

![PSF ランチャー参照](images/desktop-to-uwp/shim-exe-reference.png)

<span data-ttu-id="ef727-304">ランタイム修正プログラムのプロジェクトへの参照をプロジェクトをソリューションに追加します。</span><span class="sxs-lookup"><span data-stu-id="ef727-304">Add a project reference to the runtime fix project in your solution.</span></span>

![ランタイム修正プログラムのリファレンス](images/desktop-to-uwp/reference-fix.png)

<span data-ttu-id="ef727-306">参照を右クリックし、**プロパティ**ウィンドウで、これらの値を適用します。</span><span class="sxs-lookup"><span data-stu-id="ef727-306">Right-click the reference, and then in the **Properties** window, apply these values.</span></span>

| <span data-ttu-id="ef727-307">プロパティ</span><span class="sxs-lookup"><span data-stu-id="ef727-307">Property</span></span> | <span data-ttu-id="ef727-308">Value</span><span class="sxs-lookup"><span data-stu-id="ef727-308">Value</span></span> |
|-------|-----------|
| <span data-ttu-id="ef727-309">ローカルのコピーします。</span><span class="sxs-lookup"><span data-stu-id="ef727-309">Copy local</span></span> | <span data-ttu-id="ef727-310">True</span><span class="sxs-lookup"><span data-stu-id="ef727-310">True</span></span> |
| <span data-ttu-id="ef727-311">ローカル サテライト アセンブリをコピーします。</span><span class="sxs-lookup"><span data-stu-id="ef727-311">Copy Local Satellite Assemblies</span></span> | <span data-ttu-id="ef727-312">True</span><span class="sxs-lookup"><span data-stu-id="ef727-312">True</span></span> |
| <span data-ttu-id="ef727-313">参照アセンブリの出力</span><span class="sxs-lookup"><span data-stu-id="ef727-313">Reference Assembly Output</span></span> | <span data-ttu-id="ef727-314">True</span><span class="sxs-lookup"><span data-stu-id="ef727-314">True</span></span> |
| <span data-ttu-id="ef727-315">ライブラリ依存関係のリンク</span><span class="sxs-lookup"><span data-stu-id="ef727-315">Link Library Dependencies</span></span> | <span data-ttu-id="ef727-316">False</span><span class="sxs-lookup"><span data-stu-id="ef727-316">False</span></span> |
| <span data-ttu-id="ef727-317">リンク ライブラリの依存関係の入力</span><span class="sxs-lookup"><span data-stu-id="ef727-317">Link Library Dependency Inputs</span></span> | <span data-ttu-id="ef727-318">False</span><span class="sxs-lookup"><span data-stu-id="ef727-318">False</span></span> |

### <a name="configure-the-packaging-project"></a><span data-ttu-id="ef727-319">パッケージ プロジェクトを構成します。</span><span class="sxs-lookup"><span data-stu-id="ef727-319">Configure the packaging project</span></span>

<span data-ttu-id="ef727-320">パッケージ プロジェクトで、**[アプリケーション]** フォルダーを右クリックして **[参照の追加]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="ef727-320">In the packaging project, right-click the **Applications** folder, and then choose **Add Reference**.</span></span>

![プロジェクト参照の追加](images/desktop-to-uwp/add-reference-packaging-project.png)

<span data-ttu-id="ef727-322">PSF ランチャー プロジェクトと、デスクトップ アプリケーション プロジェクトを選択し、選択、 **OK**ボタンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="ef727-322">Choose the PSF launcher project and your desktop application project, and then choose the **OK** button.</span></span>

![デスクトップ プロジェクト](images/desktop-to-uwp/package-project-references.png)

>[!NOTE]
> <span data-ttu-id="ef727-324">アプリケーション ソース コードを持っていない場合は、PSF ランチャー プロジェクトを選択します。</span><span class="sxs-lookup"><span data-stu-id="ef727-324">If you don't have the source code to your application, just choose the PSF launcher project.</span></span> <span data-ttu-id="ef727-325">構成ファイルを作成するときに、実行可能ファイルを参照する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="ef727-325">We'll show you how to reference your executable when you create a configuration file.</span></span>

<span data-ttu-id="ef727-326">**アプリケーション**ノード、PSF ランチャー アプリケーションを右クリックし、**エントリ ポイントとして設定**します。</span><span class="sxs-lookup"><span data-stu-id="ef727-326">In the **Applications** node, right-click the PSF launcher application, and then choose **Set as Entry Point**.</span></span>

![エントリ ポイントの設定](images/desktop-to-uwp/set-startup-project.png)

<span data-ttu-id="ef727-328">という名前のファイルを追加``config.json``をパッケージ化プロジェクトにコピーし、次の json テキストをファイルに貼り付けます。</span><span class="sxs-lookup"><span data-stu-id="ef727-328">Add a file named ``config.json`` to your packaging project, then, copy and paste the following json text into the file.</span></span> <span data-ttu-id="ef727-329">設定、**パッケージ アクション**プロパティを**コンテンツ**します。</span><span class="sxs-lookup"><span data-stu-id="ef727-329">Set the **Package Action** property to **Content**.</span></span>

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
            "fixups": [
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

<span data-ttu-id="ef727-330">各キーの値を指定します。</span><span class="sxs-lookup"><span data-stu-id="ef727-330">Provide a value for each key.</span></span> <span data-ttu-id="ef727-331">このテーブルをガイドとして使用します。</span><span class="sxs-lookup"><span data-stu-id="ef727-331">Use this table as a guide.</span></span>

| <span data-ttu-id="ef727-332">配列</span><span class="sxs-lookup"><span data-stu-id="ef727-332">Array</span></span> | <span data-ttu-id="ef727-333">key</span><span class="sxs-lookup"><span data-stu-id="ef727-333">key</span></span> | <span data-ttu-id="ef727-334">Value</span><span class="sxs-lookup"><span data-stu-id="ef727-334">Value</span></span> |
|-------|-----------|-------|
| <span data-ttu-id="ef727-335">applications</span><span class="sxs-lookup"><span data-stu-id="ef727-335">applications</span></span> | <span data-ttu-id="ef727-336">id</span><span class="sxs-lookup"><span data-stu-id="ef727-336">id</span></span> |  <span data-ttu-id="ef727-337">値を使用して、`Id`の属性、`Application`パッケージ マニフェスト内の要素。</span><span class="sxs-lookup"><span data-stu-id="ef727-337">Use the value of the `Id` attribute of the `Application` element in the package manifest.</span></span> |
| <span data-ttu-id="ef727-338">applications</span><span class="sxs-lookup"><span data-stu-id="ef727-338">applications</span></span> | <span data-ttu-id="ef727-339">実行可能ファイル</span><span class="sxs-lookup"><span data-stu-id="ef727-339">executable</span></span> | <span data-ttu-id="ef727-340">開始する実行可能ファイルへのパッケージの相対パス。</span><span class="sxs-lookup"><span data-stu-id="ef727-340">The package-relative path to the executable that you want to start.</span></span> <span data-ttu-id="ef727-341">ほとんどの場合、変更する前に、パッケージ マニフェスト ファイルからこの値を取得できます。</span><span class="sxs-lookup"><span data-stu-id="ef727-341">In most cases, you can get this value from your package manifest file before you modify it.</span></span> <span data-ttu-id="ef727-342">値は、`Executable`の属性、`Application`要素。</span><span class="sxs-lookup"><span data-stu-id="ef727-342">It's the value of the `Executable` attribute of the `Application` element.</span></span> |
| <span data-ttu-id="ef727-343">applications</span><span class="sxs-lookup"><span data-stu-id="ef727-343">applications</span></span> | <span data-ttu-id="ef727-344">WorkingDirectory</span><span class="sxs-lookup"><span data-stu-id="ef727-344">workingDirectory</span></span> | <span data-ttu-id="ef727-345">(省略可能)起動するアプリケーションの作業ディレクトリとして使用するパッケージの相対パス。</span><span class="sxs-lookup"><span data-stu-id="ef727-345">(Optional) A package-relative path to use as the working directory of the application that starts.</span></span> <span data-ttu-id="ef727-346">オペレーティング システムを使用して、この値を設定しない場合、`System32`ディレクトリをアプリケーションの作業ディレクトリ。</span><span class="sxs-lookup"><span data-stu-id="ef727-346">If you don't set this value, the operating system uses the `System32` directory as the application's working directory.</span></span> |
| <span data-ttu-id="ef727-347">プロセス</span><span class="sxs-lookup"><span data-stu-id="ef727-347">processes</span></span> | <span data-ttu-id="ef727-348">実行可能ファイル</span><span class="sxs-lookup"><span data-stu-id="ef727-348">executable</span></span> | <span data-ttu-id="ef727-349">ほとんどの場合、対象になりますの名前、`executable`削除パスとファイル拡張子で上に構成されています。</span><span class="sxs-lookup"><span data-stu-id="ef727-349">In most cases, this will be the name of the `executable` configured above with the path and file extension removed.</span></span> |
| <span data-ttu-id="ef727-350">フィックス アップ</span><span class="sxs-lookup"><span data-stu-id="ef727-350">fixups</span></span> | <span data-ttu-id="ef727-351">dll</span><span class="sxs-lookup"><span data-stu-id="ef727-351">dll</span></span> | <span data-ttu-id="ef727-352">フィックス アップを読み込む DLL にパッケージの相対パス。</span><span class="sxs-lookup"><span data-stu-id="ef727-352">Package-relative path to the fixup DLL to load.</span></span> |
| <span data-ttu-id="ef727-353">フィックス アップ</span><span class="sxs-lookup"><span data-stu-id="ef727-353">fixups</span></span> | <span data-ttu-id="ef727-354">構成</span><span class="sxs-lookup"><span data-stu-id="ef727-354">config</span></span> | <span data-ttu-id="ef727-355">(省略可能)フィックス アップ DLL の動作を制御します。</span><span class="sxs-lookup"><span data-stu-id="ef727-355">(Optional) Controls how the fixup DLL behaves.</span></span> <span data-ttu-id="ef727-356">この値の正確な形式は、各フィックス アップが必要があると"blob"を解釈できるよう、フィックス アップの修正によってごとに異なります。</span><span class="sxs-lookup"><span data-stu-id="ef727-356">The exact format of this value varies on a fixup-by-fixup basis as each fixup can interpret this "blob" as it wants.</span></span> |

<span data-ttu-id="ef727-357">完了すると、``config.json``ファイルは次のようになります。</span><span class="sxs-lookup"><span data-stu-id="ef727-357">When you're done, your ``config.json`` file will look something like this.</span></span>

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
      "fixups": [ { "dll": "RuntimeFix.dll" } ]
    }
  ]
}

```

>[!NOTE]
> <span data-ttu-id="ef727-358">`applications`、 `processes`、および`fixups`キーは配列です。</span><span class="sxs-lookup"><span data-stu-id="ef727-358">The `applications`, `processes`, and `fixups` keys are arrays.</span></span> <span data-ttu-id="ef727-359">つまり、1 つ以上のアプリケーション、プロセス、および DLL のフィックス アップを指定する config.json ファイルを使用することができます。</span><span class="sxs-lookup"><span data-stu-id="ef727-359">That means that you can use the config.json file to specify more than one application, process, and fixup DLL.</span></span>

### <a name="debug-a-runtime-fix"></a><span data-ttu-id="ef727-360">ランタイム修正プログラムをデバッグします。</span><span class="sxs-lookup"><span data-stu-id="ef727-360">Debug a runtime fix</span></span>

<span data-ttu-id="ef727-361">Visual Studio で f5 キーを押してデバッガーを起動します。</span><span class="sxs-lookup"><span data-stu-id="ef727-361">In Visual Studio, press F5 to start the debugger.</span></span>  <span data-ttu-id="ef727-362">最初に起動するとは、さらに、ターゲット デスクトップ アプリケーションを起動する PSF のランチャー アプリケーションです。</span><span class="sxs-lookup"><span data-stu-id="ef727-362">The first thing that starts is the PSF launcher application, which in turn, starts your target desktop application.</span></span>  <span data-ttu-id="ef727-363">対象のデスクトップ アプリケーションをデバッグするには、手動で選択してデスクトップ アプリケーションのプロセスにアタッチする必要があります**デバッグ**->**プロセスにアタッチ**、アプリケーションを選択プロセスです。</span><span class="sxs-lookup"><span data-stu-id="ef727-363">To debug the target desktop application, you'll have to manually attach to the desktop application process by choosing **Debug**->**Attach to Process**, and then selecting the application process.</span></span> <span data-ttu-id="ef727-364">ネイティブ ランタイム修正プログラムを DLL と .NET アプリケーションのデバッグを許可するには、(混在モードのデバッグ) のマネージ コードとネイティブ コードの種類を選択します。</span><span class="sxs-lookup"><span data-stu-id="ef727-364">To permit the debugging of a .NET application with a native runtime fix DLL, select managed and native code types (mixed mode debugging).</span></span>  

<span data-ttu-id="ef727-365">これを設定したらとは、デスクトップ アプリケーションのコードでランタイム修正プログラムのプロジェクトのコード行の横にあるブレークポイントを設定できます。</span><span class="sxs-lookup"><span data-stu-id="ef727-365">Once you've set this up, you can set break points next to lines of code in the desktop application code and the runtime fix project.</span></span> <span data-ttu-id="ef727-366">アプリケーション ソース コードを持っていない場合、ランタイム修正プログラムのプロジェクトでのコード行の横にあるブレークポイントを設定することができます。</span><span class="sxs-lookup"><span data-stu-id="ef727-366">If you don't have the source code to your application, you'll be able to set break points only next to lines of code in your runtime fix project.</span></span>

>[!NOTE]
> <span data-ttu-id="ef727-367">Visual Studio では、最も簡単な開発エクスペリエンスをデバッグするには、いくつかの制限があると、このガイドの後で取り上げます他のデバッグ手法を適用することができます。</span><span class="sxs-lookup"><span data-stu-id="ef727-367">While Visual Studio gives you the simplest development and debugging experience, there are some limitations, so later in this guide, we'll discuss other debugging techniques that you can apply.</span></span>

## <a name="create-a-runtime-fix"></a><span data-ttu-id="ef727-368">ランタイム修正プログラムを作成します。</span><span class="sxs-lookup"><span data-stu-id="ef727-368">Create a runtime fix</span></span>

<span data-ttu-id="ef727-369">ない場合、ランタイムを解決することは、置換関数を作成し、構成データを含む新しいランタイム修正プログラムを作成することができます、問題の修正は合理的です。</span><span class="sxs-lookup"><span data-stu-id="ef727-369">If there isn't yet a runtime fix for the issue that you want to resolve, you can create a new runtime fix by writing replacement functions and including any configuration data that makes sense.</span></span> <span data-ttu-id="ef727-370">各部分を見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="ef727-370">Let's look at each part.</span></span>

### <a name="replacement-functions"></a><span data-ttu-id="ef727-371">置換関数</span><span class="sxs-lookup"><span data-stu-id="ef727-371">Replacement functions</span></span>

<span data-ttu-id="ef727-372">まず、MSIX コンテナーで、アプリケーションの実行時に呼び出しが失敗する関数を特定します。</span><span class="sxs-lookup"><span data-stu-id="ef727-372">First, identify which function calls fail when your application runs in an MSIX container.</span></span> <span data-ttu-id="ef727-373">次に、代わりに、ランタイム マネージャーを置換関数を作成できます。</span><span class="sxs-lookup"><span data-stu-id="ef727-373">Then, you can create replacement functions that you'd like the runtime manager to call instead.</span></span> <span data-ttu-id="ef727-374">これにより、最新のランタイム環境の規則に準拠した動作で、関数の実装を置き換えることです。</span><span class="sxs-lookup"><span data-stu-id="ef727-374">This gives you an opportunity to replace the implementation of a function with behavior that conforms to the rules of the modern runtime environment.</span></span>

<span data-ttu-id="ef727-375">Visual Studio で、このガイドの前半で作成したランタイム修正プロジェクトを開きます。</span><span class="sxs-lookup"><span data-stu-id="ef727-375">In Visual Studio, open the runtime fix project that you created earlier in this guide.</span></span>

<span data-ttu-id="ef727-376">宣言、``FIXUP_DEFINE_EXPORTS``マクロの include ステートメントを追加し、`fixup_framework.h`それぞれの上部にあります。CPP ファイルは、ランタイム修正プログラムの機能を追加します。</span><span class="sxs-lookup"><span data-stu-id="ef727-376">Declare the ``FIXUP_DEFINE_EXPORTS`` macro and then add a include statement for the `fixup_framework.h` at the top of each .CPP file where you intend to add the functions of your runtime fix.</span></span>

```c++
#define FIXUP_DEFINE_EXPORTS
#include <fixup_framework.h>
```

>[!IMPORTANT]
><span data-ttu-id="ef727-377">必ず、 `FIXUP_DEFINE_EXPORTS` include ステートメントの前にマクロが表示されます。</span><span class="sxs-lookup"><span data-stu-id="ef727-377">Make sure that the `FIXUP_DEFINE_EXPORTS` macro appears before the include statement.</span></span>

<span data-ttu-id="ef727-378">同じ関数のシグネチャを持つ関数を作成したが動作を変更します。</span><span class="sxs-lookup"><span data-stu-id="ef727-378">Create a function that has the same signature of the function who's behavior you want to modify.</span></span> <span data-ttu-id="ef727-379">置換する関数の例を次に示します、`MessageBoxW`関数。</span><span class="sxs-lookup"><span data-stu-id="ef727-379">Here's an example function that replaces the `MessageBoxW` function.</span></span>

```c++
auto MessageBoxWImpl = &::MessageBoxW;
int WINAPI MessageBoxWFixup(
    _In_opt_ HWND hwnd,
    _In_opt_ LPCWSTR,
    _In_opt_ LPCWSTR caption,
    _In_ UINT type)
{
    return MessageBoxWImpl(hwnd, L"SUCCESS: This worked", caption, type);
}

DECLARE_FIXUP(MessageBoxWImpl, MessageBoxWFixup);
```

<span data-ttu-id="ef727-380">呼び出し`DECLARE_FIXUP`マップ、`MessageBoxW`関数を新しい置換する関数。</span><span class="sxs-lookup"><span data-stu-id="ef727-380">The call to `DECLARE_FIXUP` maps the `MessageBoxW` function to your new replacement function.</span></span> <span data-ttu-id="ef727-381">アプリケーションが呼び出すしようとしたときに、`MessageBoxW`関数を置換する関数を代わりに呼び出すことがされます。</span><span class="sxs-lookup"><span data-stu-id="ef727-381">When your application attempts to call the `MessageBoxW` function, it will call the replacement function instead.</span></span>

#### <a name="protect-against-recursive-calls-to-functions-in-runtime-fixes"></a><span data-ttu-id="ef727-382">修正をランタイムに関数への再帰呼び出しから保護します。</span><span class="sxs-lookup"><span data-stu-id="ef727-382">Protect against recursive calls to functions in runtime fixes</span></span>

<span data-ttu-id="ef727-383">必要に応じて適用することができます、`reentrancy_guard`修正をランタイムに関数への再帰呼び出しから保護する、関数への型。</span><span class="sxs-lookup"><span data-stu-id="ef727-383">You can optionally apply the `reentrancy_guard` type to your functions that protect against recursive calls to functions in runtime fixes.</span></span>

<span data-ttu-id="ef727-384">たとえば、置換するための関数を生じる可能性があります、`CreateFile`関数。</span><span class="sxs-lookup"><span data-stu-id="ef727-384">For example, you might produce a replacement function for the `CreateFile` function.</span></span> <span data-ttu-id="ef727-385">実装を呼び出すことができます、`CopyFile`関数がの実装、`CopyFile`関数を呼び出すことができます、`CreateFile`関数。</span><span class="sxs-lookup"><span data-stu-id="ef727-385">Your implementation might call the `CopyFile` function, but the implementation of the `CopyFile` function might call the `CreateFile` function.</span></span> <span data-ttu-id="ef727-386">呼び出しの無限の再帰的なサイクルが生じる、`CreateFile`関数。</span><span class="sxs-lookup"><span data-stu-id="ef727-386">This may lead to an infinite recursive cycle of calls to the `CreateFile` function.</span></span>

<span data-ttu-id="ef727-387">詳細については`reentrancy_guard`を参照してください[authoring.md](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/Authoring.md)</span><span class="sxs-lookup"><span data-stu-id="ef727-387">For more information on `reentrancy_guard` see [authoring.md](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/Authoring.md)</span></span>

### <a name="configuration-data"></a><span data-ttu-id="ef727-388">構成データ</span><span class="sxs-lookup"><span data-stu-id="ef727-388">Configuration data</span></span>

<span data-ttu-id="ef727-389">構成データ、ランタイム修正プログラムを追加する場合に追加することを検討してください、``config.json``します。</span><span class="sxs-lookup"><span data-stu-id="ef727-389">If you want to add configuration data to your runtime fix, consider adding it to the ``config.json``.</span></span> <span data-ttu-id="ef727-390">これでが使用できる、`FixupQueryCurrentDllConfig`を簡単にそのデータを解析します。</span><span class="sxs-lookup"><span data-stu-id="ef727-390">That way, you can use the `FixupQueryCurrentDllConfig` to easily parse that data.</span></span> <span data-ttu-id="ef727-391">この例では、その構成ファイルからのブール値、および文字列の値を解析します。</span><span class="sxs-lookup"><span data-stu-id="ef727-391">This example parses a boolean and string value from that configuration file.</span></span>

```c++
if (auto configRoot = ::FixupQueryCurrentDllConfig())
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

## <a name="other-debugging-techniques"></a><span data-ttu-id="ef727-392">その他のデバッグ技術</span><span class="sxs-lookup"><span data-stu-id="ef727-392">Other debugging techniques</span></span>

<span data-ttu-id="ef727-393">Visual Studio は、最も簡単な開発およびデバッグ エクスペリエンスをでは、中にいくつかの制限があります。</span><span class="sxs-lookup"><span data-stu-id="ef727-393">While Visual Studio gives you the simplest development and debugging experience, there are some limitations.</span></span>

<span data-ttu-id="ef727-394">.Msix からインストールするのではなく、パッケージ レイアウト フォルダーのパスから圧縮しないファイルを展開して、アプリケーションを最初に、F5 デバッグ実行/.appx パッケージ。</span><span class="sxs-lookup"><span data-stu-id="ef727-394">First, F5 debugging runs the application by deploying loose files from the package layout folder path, rather than installing from a .msix / .appx package.</span></span>  <span data-ttu-id="ef727-395">レイアウト フォルダー通常が同じセキュリティ制限として、インストールされているパッケージのフォルダー。</span><span class="sxs-lookup"><span data-stu-id="ef727-395">The layout folder typically does not have the same security restrictions as an installed package folder.</span></span> <span data-ttu-id="ef727-396">その結果、ランタイム修正プログラムを適用する前にパッケージのパスへのアクセス拒否エラーを再現できないこと可能性があります。</span><span class="sxs-lookup"><span data-stu-id="ef727-396">As a result, it may not be possible to reproduce package path access denial errors prior to applying a runtime fix.</span></span>

<span data-ttu-id="ef727-397">この問題に対処 .msix を使用して、f5 キーではなく、.appx パッケージの配置は、ファイルの配置を疎/。</span><span class="sxs-lookup"><span data-stu-id="ef727-397">To address this issue, use .msix / .appx package deployment rather than F5 loose file deployment.</span></span>  <span data-ttu-id="ef727-398">.Msix を作成する/.appx パッケージ ファイルを使用して、 [MakeAppx](https://docs.microsoft.com/en-us/windows/desktop/appxpkg/make-appx-package--makeappx-exe-)前述のように、Windows SDK のユーティリティ。</span><span class="sxs-lookup"><span data-stu-id="ef727-398">To create a .msix / .appx package file, use the [MakeAppx](https://docs.microsoft.com/en-us/windows/desktop/appxpkg/make-appx-package--makeappx-exe-) utility from the Windows SDK, as described above.</span></span> <span data-ttu-id="ef727-399">またはから、Visual Studio 内で、アプリケーションのプロジェクト ノードを右クリックし、選択**ストア**->**アプリ パッケージの作成**です。</span><span class="sxs-lookup"><span data-stu-id="ef727-399">Or, from within Visual Studio, right-click your application project node and select **Store**->**Create App Packages**.</span></span>

<span data-ttu-id="ef727-400">Visual Studio の別の問題は、デバッガーによって起動されたすべての子プロセスにアタッチするための組み込みサポートがないことです。</span><span class="sxs-lookup"><span data-stu-id="ef727-400">Another issue with Visual Studio is that it does not have built-in support for attaching to any child processes launched by the debugger.</span></span>   <span data-ttu-id="ef727-401">デバッグ対象のアプリケーションでは、関連付ける必要があります手動で Visual Studio によって起動した後の起動パス内のロジックを困難になります。</span><span class="sxs-lookup"><span data-stu-id="ef727-401">This makes it difficult to debug logic in the startup path of the target application, which must be manually attached by Visual Studio after launch.</span></span>

<span data-ttu-id="ef727-402">この問題に対処するには、子プロセスのアタッチをサポートする、デバッガーを使用します。</span><span class="sxs-lookup"><span data-stu-id="ef727-402">To address this issue, use a debugger that supports child process attach.</span></span>  <span data-ttu-id="ef727-403">一般に、ターゲット アプリケーションへのジャストイン タイム (JIT) デバッガーをアタッチすることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="ef727-403">Note that it is generally not possible to attach a just-in-time (JIT) debugger to the target application.</span></span>  <span data-ttu-id="ef727-404">これは、ほとんどの JIT 手法では、ImageFileExecutionOptions のレジストリ キーを使用して、対象とするアプリケーションの代わりにデバッガーを起動するが含まれるためにです。</span><span class="sxs-lookup"><span data-stu-id="ef727-404">This is because most JIT techniques involve launching the debugger in place of the target app, via the ImageFileExecutionOptions registry key.</span></span>  <span data-ttu-id="ef727-405">これには、PSFLauncher.exe FixupRuntime.dll を対象となるアプリに挿入するための detouring メカニズムが果たせなくなります。</span><span class="sxs-lookup"><span data-stu-id="ef727-405">This defeats the detouring mechanism used by PSFLauncher.exe to inject FixupRuntime.dll into the target app.</span></span>  <span data-ttu-id="ef727-406">含まれる、WinDbg、[ツールを Windows のデバッグ](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/index)から取得し、 [Windows SDK](https://developer.microsoft.com/en-US/windows/downloads/windows-10-sdk)、サポートする子プロセスのアタッチします。</span><span class="sxs-lookup"><span data-stu-id="ef727-406">WinDbg, included in the [Debugging Tools for Windows](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/index), and obtained from the [Windows SDK](https://developer.microsoft.com/en-US/windows/downloads/windows-10-sdk), supports child process attach.</span></span>  <span data-ttu-id="ef727-407">また、直接サポート[を起動して、UWP アプリのデバッグ](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/debugging-a-uwp-app-using-windbg#span-idlaunchinganddebuggingauwpappspanspan-idlaunchinganddebuggingauwpappspanspan-idlaunchinganddebuggingauwpappspanlaunching-and-debugging-a-uwp-app)します。</span><span class="sxs-lookup"><span data-stu-id="ef727-407">It also now supports directly [launching and debugging a UWP app](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/debugging-a-uwp-app-using-windbg#span-idlaunchinganddebuggingauwpappspanspan-idlaunchinganddebuggingauwpappspanspan-idlaunchinganddebuggingauwpappspanlaunching-and-debugging-a-uwp-app).</span></span>

<span data-ttu-id="ef727-408">子プロセスとしてターゲット アプリケーションの起動をデバッグするには、開始``WinDbg``します。</span><span class="sxs-lookup"><span data-stu-id="ef727-408">To debug target application startup as a child process, start ``WinDbg``.</span></span>

```ps
windbg.exe -plmPackage PSFSampleWithFixup_1.0.59.0_x86__7s220nvg1hg3m -plmApp PSFSample
```

<span data-ttu-id="ef727-409">``WinDbg``と表示されたら、子のデバッグを有効にする、適切なブレークポイントを設定します。</span><span class="sxs-lookup"><span data-stu-id="ef727-409">At the ``WinDbg`` prompt, enable child debugging and set appropriate breakpoints.</span></span>

```ps
.childdbg 1
g
```

<span data-ttu-id="ef727-410">(対象のアプリケーションが開始され、デバッガーを中断するまで実行)</span><span class="sxs-lookup"><span data-stu-id="ef727-410">(execute until target application starts and breaks into the debugger)</span></span>

```ps
sxe ld fixup.dll
g
```

<span data-ttu-id="ef727-411">(フィックス アップ DLL が読み込まれるまで実行)</span><span class="sxs-lookup"><span data-stu-id="ef727-411">(execute until the fixup DLL is loaded)</span></span>

```ps
bp ...
```

>[!NOTE]
> <span data-ttu-id="ef727-412">[PLMDebug](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/plmdebug)を起動すると、アプリにデバッガーをアタッチすることも使用できにも含まれますが、[ツールを Windows のデバッグ](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/index)します。</span><span class="sxs-lookup"><span data-stu-id="ef727-412">[PLMDebug](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/plmdebug) can be also used to attach a debugger to an app upon launch, and is also included in the [Debugging Tools for Windows](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/index).</span></span>  <span data-ttu-id="ef727-413">ただし、WinDbg によって提供されるようになりました direct サポートよりも複雑です。</span><span class="sxs-lookup"><span data-stu-id="ef727-413">However, it is more complex to use than the direct support now provided by WinDbg.</span></span>

## <a name="support-and-feedback"></a><span data-ttu-id="ef727-414">サポートとフィードバック</span><span class="sxs-lookup"><span data-stu-id="ef727-414">Support and feedback</span></span>

<span data-ttu-id="ef727-415">**質問の回答を検索**</span><span class="sxs-lookup"><span data-stu-id="ef727-415">**Find answers to your questions**</span></span>

<span data-ttu-id="ef727-416">ご質問がある場合は、</span><span class="sxs-lookup"><span data-stu-id="ef727-416">Have questions?</span></span> <span data-ttu-id="ef727-417">Stack Overflow でお問い合わせください。</span><span class="sxs-lookup"><span data-stu-id="ef727-417">Ask us on Stack Overflow.</span></span> <span data-ttu-id="ef727-418">Microsoft のチームでは、これらの[タグ](https://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge)をチェックしています。</span><span class="sxs-lookup"><span data-stu-id="ef727-418">Our team monitors these [tags](https://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge).</span></span> <span data-ttu-id="ef727-419">[こちら](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D)から質問することもできます。</span><span class="sxs-lookup"><span data-stu-id="ef727-419">You can also ask us [here](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D).</span></span>
