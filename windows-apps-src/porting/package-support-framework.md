---
Description: Fix issues that prevent your desktop application from running in an MSIX container
Search.Product: eADQiWindows 10XVcnh
title: MSIX コンテナー内で実行してから、デスクトップ アプリケーションを防ぐための問題を解決します。
ms.date: 07/02/2018
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 674f5977a69855ff51cbc579ca66085aa133eb5b
ms.sourcegitcommit: b5c9c18e70625ab770946b8243f3465ee1013184
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/29/2018
ms.locfileid: "7987946"
---
# <a name="apply-runtime-fixes-to-an-msix-package-by-using-the-package-support-framework"></a><span data-ttu-id="97ca8-103">MSIX パッケージにパッケージのサポートのフレームワークを使用して、ランタイムの修正プログラムを適用します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-103">Apply runtime fixes to an MSIX package by using the Package Support Framework</span></span>

<span data-ttu-id="97ca8-104">パッケージのサポート フレームワークでは、修正プログラムの適用既存の win32 アプリケーションをソース コードにアクセスできない場合、MSIX コンテナーで実行できるようにするために役立つオープン ソースのキットです。</span><span class="sxs-lookup"><span data-stu-id="97ca8-104">The Package Support Framework is an open source kit that helps you apply fixes to your existing win32 application when you don't have access to the source code, so that it can run in an MSIX container.</span></span> <span data-ttu-id="97ca8-105">パッケージのサポートのフレームワークには、最新のランタイム環境のベスト プラクティスに従って、アプリケーションが役立ちます。</span><span class="sxs-lookup"><span data-stu-id="97ca8-105">The Package Support Framework helps your application follow the best practices of the modern runtime environment.</span></span>

<span data-ttu-id="97ca8-106">詳細についてはを[パッケージのサポートのフレームワーク](https://docs.microsoft.com/windows/msix/package-support-framework-overview)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="97ca8-106">To learn more, see [Package Support Framework](https://docs.microsoft.com/windows/msix/package-support-framework-overview).</span></span>

<span data-ttu-id="97ca8-107">このガイドには、アプリケーションの互換性の問題を識別するため、およびそれらに対処する修正プログラムを検索し、適用され、ランタイムを拡張します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-107">This guide will help you to identify application compatibility issues, and to find, apply, and extend runtime fixes that address them.</span></span>

<a id="identify" />

## <a name="identify-packaged-application-compatibility-issues"></a><span data-ttu-id="97ca8-108">パッケージ化されたアプリケーションの互換性の問題を特定します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-108">Identify packaged application compatibility issues</span></span>

<span data-ttu-id="97ca8-109">最初に、アプリケーションのパッケージを作成します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-109">First, create a package for your application.</span></span> <span data-ttu-id="97ca8-110">次に、インストール、実行し、その動作を確認します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-110">Then, install it, run it, and observe its behavior.</span></span> <span data-ttu-id="97ca8-111">互換性の問題を識別するのに役立ちますエラー メッセージを表示される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="97ca8-111">You might receive error messages that can help you identify a compatibility issue.</span></span> <span data-ttu-id="97ca8-112">問題を特定するのに[プロセスのモニター](https://docs.microsoft.com/en-us/sysinternals/downloads/procmon)を使用することもできます。</span><span class="sxs-lookup"><span data-stu-id="97ca8-112">You can also use [Process Monitor](https://docs.microsoft.com/en-us/sysinternals/downloads/procmon) to identify issues.</span></span>  <span data-ttu-id="97ca8-113">一般的な問題は、作業ディレクトリとプログラムのパスのアクセス許可に関する前提条件をアプリケーションに関連します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-113">Common issues relate to application assumptions regarding the working directory and program path permissions.</span></span>

### <a name="using-process-monitor-to-identify-an-issue"></a><span data-ttu-id="97ca8-114">プロセスのモニターを使用して、問題を特定するには</span><span class="sxs-lookup"><span data-stu-id="97ca8-114">Using Process Monitor to identify an issue</span></span>

<span data-ttu-id="97ca8-115">[プロセス モニター](https://docs.microsoft.com/en-us/sysinternals/downloads/procmon)は、アプリのファイルとレジストリ操作、およびその結果を観察するための強力なユーティリティです。</span><span class="sxs-lookup"><span data-stu-id="97ca8-115">[Process Monitor](https://docs.microsoft.com/en-us/sysinternals/downloads/procmon) is a powerful utility for observing an app's file and registry operations, and their results.</span></span>  <span data-ttu-id="97ca8-116">アプリケーションの互換性の問題について理解することができます。</span><span class="sxs-lookup"><span data-stu-id="97ca8-116">This can help you to understand application compatibility issues.</span></span>  <span data-ttu-id="97ca8-117">プロセスのモニターを開いたら、フィルターを追加します (フィルター > フィルター.)、アプリケーションの実行可能ファイルからのイベントのみを含めます。</span><span class="sxs-lookup"><span data-stu-id="97ca8-117">After opening Process Monitor, add a filter (Filter > Filter…) to include only events from the application executable.</span></span>

![ProcMon アプリ フィルター](images/desktop-to-uwp/procmon_app_filter.png)

<span data-ttu-id="97ca8-119">イベントの一覧が表示されます。</span><span class="sxs-lookup"><span data-stu-id="97ca8-119">A list of events will appear.</span></span> <span data-ttu-id="97ca8-120">これらのイベントの多くに、単語**成功**を**結果**の列に表示してされます。</span><span class="sxs-lookup"><span data-stu-id="97ca8-120">For many of these events, the word **SUCCESS** will appear in the **Result** column.</span></span>

![ProcMon イベント](images/desktop-to-uwp/procmon_events.png)

<span data-ttu-id="97ca8-122">必要に応じて、のみエラーのみを表示するイベントをフィルター処理することができます。</span><span class="sxs-lookup"><span data-stu-id="97ca8-122">Optionally, you can filter events to only show only failures.</span></span>

![ProcMon 除外の成功](images/desktop-to-uwp/procmon_exclude_success.png)

<span data-ttu-id="97ca8-124">ファイル システムへのアクセスの失敗が疑われる場合は、System32/SysWOW64 またはパッケージのファイル パスのいずれかの下にある障害が発生したイベントを検索します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-124">If you suspect a filesystem access failure, search for failed events that are under either the System32/SysWOW64 or the package file path.</span></span> <span data-ttu-id="97ca8-125">フィルターを使っても役立ちますここでは、すぎます。</span><span class="sxs-lookup"><span data-stu-id="97ca8-125">Filters can also help here, too.</span></span> <span data-ttu-id="97ca8-126">この一覧の下部に開始し、上方向にスクロールします。</span><span class="sxs-lookup"><span data-stu-id="97ca8-126">Start at the bottom of this list and scroll upwards.</span></span> <span data-ttu-id="97ca8-127">この一覧の下部に表示されるエラーが発生した最も新しくします。</span><span class="sxs-lookup"><span data-stu-id="97ca8-127">Failures that appear at the bottom of this list have occurred most recently.</span></span> <span data-ttu-id="97ca8-128">「アクセス拒否」などの文字列が含まれるエラーや"パス/名前が見つかりません"、ほとんどの注意を払うし、疑わしい外観がないことを無視します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-128">Pay most attention to errors that contain strings such as "access denied," and "path/name not found", and ignore things that don't look suspicious.</span></span> <span data-ttu-id="97ca8-129">[PSFSample](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/samples/PSFSample/)には、2 つの問題があります。</span><span class="sxs-lookup"><span data-stu-id="97ca8-129">The [PSFSample](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/samples/PSFSample/) has two issues.</span></span> <span data-ttu-id="97ca8-130">次の図に表示される一覧でそれらの問題を確認できます。</span><span class="sxs-lookup"><span data-stu-id="97ca8-130">You can see those issues in the list that appears in the following image.</span></span>

![ProcMon Config.txt](images/desktop-to-uwp/procmon_config_txt.png)

<span data-ttu-id="97ca8-132">この画像に表示される最初の問題、アプリケーションは、"C:\Windows\SysWOW64"パスにある"Config.txt"ファイルから読み取る失敗しています。</span><span class="sxs-lookup"><span data-stu-id="97ca8-132">In the first issue that appears in this image, the application is failing to read from the "Config.txt" file that is located in the "C:\Windows\SysWOW64" path.</span></span> <span data-ttu-id="97ca8-133">アプリケーションがそのパスを直接参照しようとしている可能性が高いことはできません。</span><span class="sxs-lookup"><span data-stu-id="97ca8-133">It's unlikely that the application is trying to reference that path directly.</span></span> <span data-ttu-id="97ca8-134">ほとんどの場合、相対パスを使用して、そのファイルから読み取るしようと、既定では、"System32/SysWOW64"には、アプリケーションの作業ディレクトリ。</span><span class="sxs-lookup"><span data-stu-id="97ca8-134">Most likely, it's trying to read from that file by using a relative path, and by default, "System32/SysWOW64" is the application's working directory.</span></span> <span data-ttu-id="97ca8-135">これは、アプリケーションでは、パッケージのどこかに設定する現在の作業ディレクトリを想定を示しています。</span><span class="sxs-lookup"><span data-stu-id="97ca8-135">This suggests that the application is expecting its current working directory to be set to somewhere in the package.</span></span> <span data-ttu-id="97ca8-136">Appx 内で見ると、実行可能ファイルと同じディレクトリにファイルが存在することを確認できます。</span><span class="sxs-lookup"><span data-stu-id="97ca8-136">Looking inside of the appx, we can see that the file exists in the same directory as the executable.</span></span>

![アプリの Config.txt](images/desktop-to-uwp/psfsampleapp_config_txt.png)

<span data-ttu-id="97ca8-138">2 番目の問題は、次の図が表示されます。</span><span class="sxs-lookup"><span data-stu-id="97ca8-138">The second issue appears in the following image.</span></span>

![ProcMon ログ ファイル](images/desktop-to-uwp/procmon_logfile.png)

<span data-ttu-id="97ca8-140">この問題は、アプリケーションは、そのパッケージのパスに .log ファイルを書き込むに失敗しています。</span><span class="sxs-lookup"><span data-stu-id="97ca8-140">In this issue, the application is failing to write a .log file to its package path.</span></span> <span data-ttu-id="97ca8-141">これにより、ファイルのリダイレクトの修正が役立つ場合がありますがお勧めします。</span><span class="sxs-lookup"><span data-stu-id="97ca8-141">This would suggest that a file redirection fixup might help.</span></span>

<a id="find" />

## <a name="find-a-runtime-fix"></a><span data-ttu-id="97ca8-142">ランタイムの修正プログラムを見つける</span><span class="sxs-lookup"><span data-stu-id="97ca8-142">Find a runtime fix</span></span>

<span data-ttu-id="97ca8-143">PSF には、ファイルのリダイレクト修正など、今すぐに使用できるランタイムの修正プログラムが含まれています。</span><span class="sxs-lookup"><span data-stu-id="97ca8-143">The PSF contains runtime fixes that you can use right now, such as the file redirection fixup.</span></span>

### <a name="file-redirection-fixup"></a><span data-ttu-id="97ca8-144">ファイルのリダイレクトの修正</span><span class="sxs-lookup"><span data-stu-id="97ca8-144">File Redirection Fixup</span></span>

<span data-ttu-id="97ca8-145">書き込みまたは MSIX コンテナー内で実行されるアプリケーションからアクセス可能ではないディレクトリ内のデータを読み取るしようとするたびにリダイレクトするのに[ファイルのリダイレクトの修正](https://github.com/Microsoft/MSIX-PackageSupportFramework/tree/master/fixups/FileRedirectionFixup)を使用できます。</span><span class="sxs-lookup"><span data-stu-id="97ca8-145">You can use the [File Redirection Fixup](https://github.com/Microsoft/MSIX-PackageSupportFramework/tree/master/fixups/FileRedirectionFixup) to redirect attempts to write or read data in a directory that isn't accessible from an application that runs in an MSIX container.</span></span>

<span data-ttu-id="97ca8-146">たとえば、アプリケーションが、アプリケーションの実行可能ファイルと同じディレクトリで公開されているログ ファイルに書き込む場合、は、ローカル アプリ データ ストアなどの別の場所にそのログ ファイルを作成する[ファイルのリダイレクトの修正](https://github.com/Microsoft/MSIX-PackageSupportFramework/tree/master/fixups/FileRedirectionFixup)を使用できます。</span><span class="sxs-lookup"><span data-stu-id="97ca8-146">For example, if your application writes to a log file that is in the same directory as your applications executable, then you can use the [File Redirection Fixup](https://github.com/Microsoft/MSIX-PackageSupportFramework/tree/master/fixups/FileRedirectionFixup) to create that log file in another location, such as the local app data store.</span></span>

### <a name="runtime-fixes-from-the-community"></a><span data-ttu-id="97ca8-147">コミュニティからランタイムの修正プログラム</span><span class="sxs-lookup"><span data-stu-id="97ca8-147">Runtime fixes from the community</span></span>

<span data-ttu-id="97ca8-148">当社の[GitHub](https://github.com/Microsoft/MSIX-PackageSupportFramework)ページをコミュニティの投稿を確認してください。</span><span class="sxs-lookup"><span data-stu-id="97ca8-148">Make sure to review the community contributions to our [GitHub](https://github.com/Microsoft/MSIX-PackageSupportFramework) page.</span></span> <span data-ttu-id="97ca8-149">他の開発者が自分のような問題を解決してされ、実行時の修正プログラムと共有できます。</span><span class="sxs-lookup"><span data-stu-id="97ca8-149">It's possible that other developers have resolved an issue similar to yours and have shared a runtime fix.</span></span>

## <a name="apply-a-runtime-fix"></a><span data-ttu-id="97ca8-150">ランタイムの修正プログラムを適用します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-150">Apply a runtime fix</span></span>

<span data-ttu-id="97ca8-151">Windows SDK と次の手順では、いくつかの簡単なツールを使用して既存のランタイムの修正を適用できます。</span><span class="sxs-lookup"><span data-stu-id="97ca8-151">You can apply an existing runtime fix with a few simple tools from the Windows SDK, and by following these steps.</span></span>

> [!div class="checklist"]
> * <span data-ttu-id="97ca8-152">パッケージ レイアウト フォルダーを作成します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-152">Create a package layout folder</span></span>
> * <span data-ttu-id="97ca8-153">パッケージのサポート フレームワーク ファイルを取得します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-153">Get the Package Support Framework files</span></span>
> * <span data-ttu-id="97ca8-154">パッケージに追加します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-154">Add them to your package</span></span>
> * <span data-ttu-id="97ca8-155">パッケージ マニフェストの変更</span><span class="sxs-lookup"><span data-stu-id="97ca8-155">Modify the package manifest</span></span>
> * <span data-ttu-id="97ca8-156">構成ファイルを作成します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-156">Create a configuration file</span></span>

<span data-ttu-id="97ca8-157">各タスクを見ていきましょう。</span><span class="sxs-lookup"><span data-stu-id="97ca8-157">Let's go through each task.</span></span>

### <a name="create-the-package-layout-folder"></a><span data-ttu-id="97ca8-158">パッケージ レイアウト フォルダーを作成します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-158">Create the package layout folder</span></span>

<span data-ttu-id="97ca8-159">.Msix (.appx) ファイルが既にある場合は、その内容をパッケージのステージング領域として使用されるレイアウト フォルダーに展開できます。</span><span class="sxs-lookup"><span data-stu-id="97ca8-159">If you have a .msix (or .appx) file already, you can unpack its contents into a layout folder that will serve as the staging area for your package.</span></span> <span data-ttu-id="97ca8-160">SDK のインストール パスに基づき、makemsix ツールを使用してコマンド プロンプトから実行することが、これは、Windows 10 PC 上の makemsix.exe ツールの検索場所: x86: C:\Program Files (x86) \Windows Kits\10\bin\x86\makemsix.exe x64: C:\Program Files (x86) \Windows Kits\10\bin\x64\makemsix.exe</span><span class="sxs-lookup"><span data-stu-id="97ca8-160">You can do this from a command prompt using makemsix tool, based on your installation path of the SDK, this is where you will find the makemsix.exe tool on your Windows 10 PC: x86: C:\Program Files (x86)\Windows Kits\10\bin\x86\makemsix.exe x64: C:\Program Files (x86)\Windows Kits\10\bin\x64\makemsix.exe</span></span>

```ps
makemsix unpack /p PSFSamplePackage_1.0.60.0_AnyCPU_Debug.msix /d PackageContents

```

<span data-ttu-id="97ca8-161">これにより、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="97ca8-161">This will give you something that looks like the following.</span></span>

![パッケージのレイアウト](images/desktop-to-uwp/package_contents.png)

<span data-ttu-id="97ca8-163">まず .msix (.appx) ファイルがあるない、ゼロから、パッケージのフォルダーとファイルを作成できます。</span><span class="sxs-lookup"><span data-stu-id="97ca8-163">If you don't have a .msix (or .appx) file to start with, you can create the package folder and files from scratch.</span></span>

### <a name="get-the-package-support-framework-files"></a><span data-ttu-id="97ca8-164">パッケージのサポート フレームワーク ファイルを取得します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-164">Get the Package Support Framework files</span></span>

<span data-ttu-id="97ca8-165">スタンドアロン Nuget コマンド ライン ツールを使用して、または Visual Studio によって、PSF Nuget パッケージを取得できます。</span><span class="sxs-lookup"><span data-stu-id="97ca8-165">You can get the PSF Nuget package by using the standalone Nuget command line tool or via Visual Studio.</span></span>

#### <a name="get-the-package-by-using-the-command-line-tool"></a><span data-ttu-id="97ca8-166">コマンド ライン ツールを使用して、パッケージを取得します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-166">Get the package by using the command line tool</span></span>

<span data-ttu-id="97ca8-167">この場所から Nuget コマンド ライン ツールをインストール:https://www.nuget.org/downloadsします。</span><span class="sxs-lookup"><span data-stu-id="97ca8-167">Install the Nuget command line tool from this location: https://www.nuget.org/downloads.</span></span> <span data-ttu-id="97ca8-168">次に、Nuget コマンドラインからこのコマンドを実行します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-168">Then, from the Nuget command line, run this command:</span></span>

```ps
nuget install Microsoft.PackageSupportFramework
```

#### <a name="get-the-package-by-using-visual-studio"></a><span data-ttu-id="97ca8-169">Visual Studio を使ってパッケージを取得します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-169">Get the package by using Visual Studio</span></span>

<span data-ttu-id="97ca8-170">Visual Studio で、ソリューションまたはプロジェクト ノードを右クリックし、Nuget パッケージの管理コマンドのいずれかを選択します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-170">In Visual Studio, right-click your solution or project node and pick one of the Manage Nuget Packages commands.</span></span>  <span data-ttu-id="97ca8-171">検索**Microsoft.PackageSupportFramework** **PSF**上 Nuget.org パッケージを検索します。次に、インストールします。</span><span class="sxs-lookup"><span data-stu-id="97ca8-171">Search for **Microsoft.PackageSupportFramework** or **PSF** to find the package on Nuget.org. Then, install it.</span></span>

### <a name="add-the-package-support-framework-files-to-your-package"></a><span data-ttu-id="97ca8-172">サポート フレームワークのパッケージ ファイルをパッケージに追加します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-172">Add the Package Support Framework files to your package</span></span>

<span data-ttu-id="97ca8-173">パッケージのディレクトリに必要な 32 ビットと 64 ビット PSF Dll と実行可能ファイルを追加します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-173">Add the required 32-bit and 64-bit PSF  DLLs and executable files to the package directory.</span></span> <span data-ttu-id="97ca8-174">次の表をガイドとして使用してください。</span><span class="sxs-lookup"><span data-stu-id="97ca8-174">Use the following table as a guide.</span></span> <span data-ttu-id="97ca8-175">含める必要があるランタイムのすべての修正プログラムもします。</span><span class="sxs-lookup"><span data-stu-id="97ca8-175">You'll also want to include any runtime fixes that you need.</span></span> <span data-ttu-id="97ca8-176">ここでは、ファイルのリダイレクトのランタイムの修正プログラムが必要です。</span><span class="sxs-lookup"><span data-stu-id="97ca8-176">In our example, we need the file redirection runtime fix.</span></span>

| <span data-ttu-id="97ca8-177">アプリケーションの実行可能ファイルは、x64</span><span class="sxs-lookup"><span data-stu-id="97ca8-177">Application executable is x64</span></span> | <span data-ttu-id="97ca8-178">アプリケーションの実行可能ファイルは、x86</span><span class="sxs-lookup"><span data-stu-id="97ca8-178">Application executable is x86</span></span> |
|-------------------------------|-----------|
| [<span data-ttu-id="97ca8-179">PSFLauncher64.exe</span><span class="sxs-lookup"><span data-stu-id="97ca8-179">PSFLauncher64.exe</span></span>](https://github.com/Microsoft/MSIX-PackageSupportFramework/tree/master/PsfLauncher/readme.md) |  [<span data-ttu-id="97ca8-180">PSFLauncher32.exe</span><span class="sxs-lookup"><span data-stu-id="97ca8-180">PSFLauncher32.exe</span></span>](https://github.com/Microsoft/MSIX-PackageSupportFramework/tree/master/PsfLauncher/readme.md) |
| [<span data-ttu-id="97ca8-181">PSFRuntime64.dll</span><span class="sxs-lookup"><span data-stu-id="97ca8-181">PSFRuntime64.dll</span></span>](https://github.com/Microsoft/MSIX-PackageSupportFramework/tree/master/PsfRuntime/readme.md) | [<span data-ttu-id="97ca8-182">PSFRuntime32.dll</span><span class="sxs-lookup"><span data-stu-id="97ca8-182">PSFRuntime32.dll</span></span>](https://github.com/Microsoft/MSIX-PackageSupportFramework/tree/master/PsfRuntime/readme.md) |
| [<span data-ttu-id="97ca8-183">PSFRunDll64.exe</span><span class="sxs-lookup"><span data-stu-id="97ca8-183">PSFRunDll64.exe</span></span>](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/PsfRunDll/readme.md) | [<span data-ttu-id="97ca8-184">PSFRunDll32.exe</span><span class="sxs-lookup"><span data-stu-id="97ca8-184">PSFRunDll32.exe</span></span>](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/PsfRunDll/readme.md) |

<span data-ttu-id="97ca8-185">パッケージの内容は次のようになります。</span><span class="sxs-lookup"><span data-stu-id="97ca8-185">Your package content should now look something like this.</span></span>

![パッケージのバイナリ](images/desktop-to-uwp/package_binaries.png)

### <a name="modify-the-package-manifest"></a><span data-ttu-id="97ca8-187">パッケージ マニフェストの変更</span><span class="sxs-lookup"><span data-stu-id="97ca8-187">Modify the package manifest</span></span>

<span data-ttu-id="97ca8-188">テキスト エディターで、パッケージ マニフェストを開き、設定、`Executable`の属性、`Application`要素 PSF ランチャーの実行可能ファイルの名前にします。</span><span class="sxs-lookup"><span data-stu-id="97ca8-188">Open your package manifest in a text editor, and then set the `Executable` attribute of the `Application` element to the name of the PSF launcher executable file.</span></span>  <span data-ttu-id="97ca8-189">ターゲット アプリケーションのアーキテクチャがわかっている場合は、PSFLauncher32.exe または PSFLauncher64.exe は、適切なバージョンを選択します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-189">If you know the architecture of your target application, select the appropriate version, PSFLauncher32.exe or PSFLauncher64.exe.</span></span>  <span data-ttu-id="97ca8-190">ない場合は、PSFLauncher32.exe は、すべての場合で動作します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-190">If not, PSFLauncher32.exe will work in all cases.</span></span>  <span data-ttu-id="97ca8-191">次に例を示します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-191">Here's an example.</span></span>

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

### <a name="create-a-configuration-file"></a><span data-ttu-id="97ca8-192">構成ファイルを作成します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-192">Create a configuration file</span></span>

<span data-ttu-id="97ca8-193">ファイル名を作成``config.json``、そのファイルをパッケージのルート フォルダーに保存します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-193">Create a file name ``config.json``, and save that file to the root folder of your package.</span></span> <span data-ttu-id="97ca8-194">交換した実行可能ファイルをポイントする config.json ファイルの宣言されているアプリの ID を変更します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-194">Modify the declared app ID of the config.json file to point to the executable that you just replaced.</span></span> <span data-ttu-id="97ca8-195">モニターのプロセスを使用してから得られる情報を使用して、したりすることできますも作業ディレクトリを設定しファイルのリダイレクトの修正を使用して、読み取り/書き込みを"PSFSampleApp"ディレクトリにパッケージ相対 .log ファイルにリダイレクトします。</span><span class="sxs-lookup"><span data-stu-id="97ca8-195">Using the knowledge that you gained from using Process Monitor, you can also set the working directory as well as use the file redirection fixup to redirect reads/writes to .log files under the package-relative "PSFSampleApp" directory.</span></span>

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

<span data-ttu-id="97ca8-196">次に示します。 config.json スキーマのためのガイド</span><span class="sxs-lookup"><span data-stu-id="97ca8-196">Following is a guide for the config.json schema:</span></span>

| <span data-ttu-id="97ca8-197">配列</span><span class="sxs-lookup"><span data-stu-id="97ca8-197">Array</span></span> | <span data-ttu-id="97ca8-198">key</span><span class="sxs-lookup"><span data-stu-id="97ca8-198">key</span></span> | <span data-ttu-id="97ca8-199">値</span><span class="sxs-lookup"><span data-stu-id="97ca8-199">Value</span></span> |
|-------|-----------|-------|
| <span data-ttu-id="97ca8-200">applications</span><span class="sxs-lookup"><span data-stu-id="97ca8-200">applications</span></span> | <span data-ttu-id="97ca8-201">id</span><span class="sxs-lookup"><span data-stu-id="97ca8-201">id</span></span> |  <span data-ttu-id="97ca8-202">値を使用して、`Id`の属性、`Application`パッケージ マニフェスト内の要素です。</span><span class="sxs-lookup"><span data-stu-id="97ca8-202">Use the value of the `Id` attribute of the `Application` element in the package manifest.</span></span> |
| <span data-ttu-id="97ca8-203">applications</span><span class="sxs-lookup"><span data-stu-id="97ca8-203">applications</span></span> | <span data-ttu-id="97ca8-204">実行可能</span><span class="sxs-lookup"><span data-stu-id="97ca8-204">executable</span></span> | <span data-ttu-id="97ca8-205">起動する実行可能ファイルへのパッケージ相対パス。</span><span class="sxs-lookup"><span data-stu-id="97ca8-205">The package-relative path to the executable that you want to start.</span></span> <span data-ttu-id="97ca8-206">ほとんどの場合、変更する前に、パッケージ マニフェスト ファイルからこの値を取得できます。</span><span class="sxs-lookup"><span data-stu-id="97ca8-206">In most cases, you can get this value from your package manifest file before you modify it.</span></span> <span data-ttu-id="97ca8-207">値では、`Executable`の属性、`Application`要素です。</span><span class="sxs-lookup"><span data-stu-id="97ca8-207">It's the value of the `Executable` attribute of the `Application` element.</span></span> |
| <span data-ttu-id="97ca8-208">applications</span><span class="sxs-lookup"><span data-stu-id="97ca8-208">applications</span></span> | <span data-ttu-id="97ca8-209">workingDirectory</span><span class="sxs-lookup"><span data-stu-id="97ca8-209">workingDirectory</span></span> | <span data-ttu-id="97ca8-210">(省略可能)起動するアプリケーションの作業ディレクトリとして使用するパッケージの相対パス。</span><span class="sxs-lookup"><span data-stu-id="97ca8-210">(Optional) A package-relative path to use as the working directory of the application that starts.</span></span> <span data-ttu-id="97ca8-211">この値を設定しない場合、オペレーティング システムを使用して、`System32`アプリケーションの作業ディレクトリとしてディレクトリ。</span><span class="sxs-lookup"><span data-stu-id="97ca8-211">If you don't set this value, the operating system uses the `System32` directory as the application's working directory.</span></span> |
| <span data-ttu-id="97ca8-212">プロセス</span><span class="sxs-lookup"><span data-stu-id="97ca8-212">processes</span></span> | <span data-ttu-id="97ca8-213">実行可能</span><span class="sxs-lookup"><span data-stu-id="97ca8-213">executable</span></span> | <span data-ttu-id="97ca8-214">ほとんどの場合の名前になります、`executable`削除パスとファイルの拡張子を持つ上に構成されています。</span><span class="sxs-lookup"><span data-stu-id="97ca8-214">In most cases, this will be the name of the `executable` configured above with the path and file extension removed.</span></span> |
| <span data-ttu-id="97ca8-215">fixup</span><span class="sxs-lookup"><span data-stu-id="97ca8-215">fixups</span></span> | <span data-ttu-id="97ca8-216">dll</span><span class="sxs-lookup"><span data-stu-id="97ca8-216">dll</span></span> | <span data-ttu-id="97ca8-217">パッケージの相対パスを読み込む.msix/.appx、修正します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-217">Package-relative path to the fixup, .msix/.appx  to load.</span></span> |
| <span data-ttu-id="97ca8-218">fixup</span><span class="sxs-lookup"><span data-stu-id="97ca8-218">fixups</span></span> | <span data-ttu-id="97ca8-219">config</span><span class="sxs-lookup"><span data-stu-id="97ca8-219">config</span></span> | <span data-ttu-id="97ca8-220">(省略可能)修正配布リストの動作を制御します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-220">(Optional) Controls how the fixup dl behaves.</span></span> <span data-ttu-id="97ca8-221">この値の正確な形式は、各修正が解釈できるようにこの"blob"必要があるように修正の修正によってごとに異なります。</span><span class="sxs-lookup"><span data-stu-id="97ca8-221">The exact format of this value varies on a fixup-by-fixup basis as each fixup can interpret this "blob" as it wants.</span></span> |

<span data-ttu-id="97ca8-222">`applications`、 `processes`、および`fixups`キーは、配列です。</span><span class="sxs-lookup"><span data-stu-id="97ca8-222">The `applications`, `processes`, and `fixups` keys are arrays.</span></span> <span data-ttu-id="97ca8-223">つまり、1 つ以上のアプリケーション、プロセス、および修正 DLL を指定する config.json ファイルを使用することができます。</span><span class="sxs-lookup"><span data-stu-id="97ca8-223">That means that you can use the config.json file to specify more than one application, process, and fixup DLL.</span></span>

### <a name="package-and-test-the-app"></a><span data-ttu-id="97ca8-224">パッケージと、アプリのテスト</span><span class="sxs-lookup"><span data-stu-id="97ca8-224">Package and Test the App</span></span>

<span data-ttu-id="97ca8-225">次に、パッケージを作成します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-225">Next, create a package.</span></span>

```ps
makeappx pack /d PackageContents /p PSFSamplePackageFixup.msix
```

<span data-ttu-id="97ca8-226">次に、それを署名します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-226">Then, sign it.</span></span>

```ps
signtool sign /a /v /fd sha256 /f ExportedSigningCertificate.pfx PSFSamplePackageFixup.msix
```

<span data-ttu-id="97ca8-227">詳細については、 [signtool を使ってパッケージに署名する方法](https://docs.microsoft.com/en-us/windows/desktop/appxpkg/how-to-sign-a-package-using-signtool)と[、パッケージの署名証明書を作成する方法](https://docs.microsoft.com/en-us/windows/desktop/appxpkg/how-to-create-a-package-signing-certificate)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="97ca8-227">For more information, see [how to create a package signing certificate](https://docs.microsoft.com/en-us/windows/desktop/appxpkg/how-to-create-a-package-signing-certificate) and [how to sign a package using signtool](https://docs.microsoft.com/en-us/windows/desktop/appxpkg/how-to-sign-a-package-using-signtool)</span></span>

<span data-ttu-id="97ca8-228">PowerShell を使用して、パッケージをインストールします。</span><span class="sxs-lookup"><span data-stu-id="97ca8-228">Using PowerShell, install the package.</span></span>

>[!NOTE]
> <span data-ttu-id="97ca8-229">最初にパッケージをアンインストールしてください。</span><span class="sxs-lookup"><span data-stu-id="97ca8-229">Remember to uninstall the package first.</span></span>

```ps
powershell Add-MSIXPackage .\PSFSamplePackageFixup.msix
```

<span data-ttu-id="97ca8-230">アプリケーションを実行し、ランタイムの修正プログラムが適用されると、動作を確認します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-230">Run the application and observe the behavior with runtime fix applied.</span></span>  <span data-ttu-id="97ca8-231">診断と必要に応じて、パッケージ化の手順を繰り返します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-231">Repeat the diagnostic and packaging steps as necessary.</span></span>

### <a name="use-the-trace-fixup"></a><span data-ttu-id="97ca8-232">トレース修正を使用します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-232">Use the Trace Fixup</span></span>

<span data-ttu-id="97ca8-233">パッケージ化されたアプリケーションの互換性の問題を診断するために別の手法では、トレース修正を使用します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-233">An alternative technique to diagnosing packaged application compatibility issues is to use the Trace Fixup.</span></span> <span data-ttu-id="97ca8-234">この DLL は、PSF に付属であり、プロセスの監視と同様、アプリの動作の詳細な診断ビューを提供します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-234">This DLL is included with the PSF and provides a detailed diagnostic view of the app's behavior, similar to Process Monitor.</span></span>  <span data-ttu-id="97ca8-235">アプリケーションの互換性の問題を表示するように設計します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-235">It is specially designed to reveal application compatibility issues.</span></span>  <span data-ttu-id="97ca8-236">トレース修正 DLL、パッケージを追加、config.json に次のフラグメントを追加とをパッケージ化し、アプリケーションをインストールします。</span><span class="sxs-lookup"><span data-stu-id="97ca8-236">To use the Trace Fixup, add the DLL to the package, add the following fragment to your config.json, and then package and install your application.</span></span>

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

<span data-ttu-id="97ca8-237">既定では、トレース修正「期待」と考えられるエラーが除外されます。</span><span class="sxs-lookup"><span data-stu-id="97ca8-237">By default, the Trace Fixup filters out failures that might be considered "expected".</span></span>  <span data-ttu-id="97ca8-238">たとえば、アプリケーションは無条件に既に存在するかどうか、結果を無視して確認することがなく、ファイルを削除しよう可能性があります。</span><span class="sxs-lookup"><span data-stu-id="97ca8-238">For example, applications might try to unconditionally delete a file without checking to see if it already exists, ignoring the result.</span></span> <span data-ttu-id="97ca8-239">これがありますので、ファイルシステム関数からすべてのエラーを受信するオプトイン上記の例では残念ながら結果として、いくつかの予期しないエラーをフィルター処理を取得する可能性。</span><span class="sxs-lookup"><span data-stu-id="97ca8-239">This has the unfortunate consequence that some unexpected failures might get filtered out, so in the above example, we opt to receive all failures from filesystem functions.</span></span> <span data-ttu-id="97ca8-240">これは前に、そのに Config.txt ファイルから読み取る失敗すると、メッセージ「ファイルが見つかりません」からわかっているためです。</span><span class="sxs-lookup"><span data-stu-id="97ca8-240">We do this because we know from before that the attempt to read from the Config.txt file fails with the message "file not found".</span></span> <span data-ttu-id="97ca8-241">これは、頻繁に確認されたでは、一般に予想するものと想定したエラーです。</span><span class="sxs-lookup"><span data-stu-id="97ca8-241">This is a failure that is frequently observed and not generally assumed to be unexpected.</span></span> <span data-ttu-id="97ca8-242">実際には、のみに予期しないエラーは、フィルタ リングとその後にフォールバックするすべてのエラーも識別できない問題がある場合は、最初に可能性の最適なを勧めします。</span><span class="sxs-lookup"><span data-stu-id="97ca8-242">In practice it's likely best to start out filtering only to unexpected failures, and then falling back to all failures if there's an issue that still can't be identified.</span></span>

<span data-ttu-id="97ca8-243">既定では、トレース修正からの出力を取得、アタッチされたデバッガーに送信されます。</span><span class="sxs-lookup"><span data-stu-id="97ca8-243">By default, the output from the Trace Fixup gets sent to the attached debugger.</span></span> <span data-ttu-id="97ca8-244">この例では、します、デバッガーをアタッチすることは、代わりにプログラムを使用して[デバッグ表示](https://docs.microsoft.com/en-us/sysinternals/downloads/debugview)sysinternals 出力を表示します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-244">For this example, we aren't going to attach a debugger, and will instead use the [DebugView](https://docs.microsoft.com/en-us/sysinternals/downloads/debugview) program from SysInternals to view its output.</span></span> <span data-ttu-id="97ca8-245">アプリを実行すると、わかります同じエラー前とに、同じランタイムの修正プログラムから、マイクロソフトをポイントするとします。</span><span class="sxs-lookup"><span data-stu-id="97ca8-245">After running the app, we can see the same failures as before, which would point us towards the same runtime fixes.</span></span>

![TraceShim ファイルが見つかりません](images/desktop-to-uwp/traceshim_filenotfound.png)

![TraceShim アクセスが拒否されました](images/desktop-to-uwp/traceshim_accessdenied.png)

## <a name="debug-extend-or-create-a-runtime-fix"></a><span data-ttu-id="97ca8-248">デバッグ、延長、または実行時の修正プログラムの作成</span><span class="sxs-lookup"><span data-stu-id="97ca8-248">Debug, extend, or create a runtime fix</span></span>

<span data-ttu-id="97ca8-249">ランタイムの修正プログラムのデバッグ、拡張ランタイムの修正プログラムを最初から作成に Visual Studio を使用することができます。</span><span class="sxs-lookup"><span data-stu-id="97ca8-249">You can use Visual Studio to debug a runtime fix, extend a runtime fix, or create one from scratch.</span></span> <span data-ttu-id="97ca8-250">これらの操作を成功させる必要があります。</span><span class="sxs-lookup"><span data-stu-id="97ca8-250">You'll need to do these things to be successful.</span></span>

> [!div class="checklist"]
> * <span data-ttu-id="97ca8-251">パッケージ プロジェクトを追加します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-251">Add a packaging project</span></span>
> * <span data-ttu-id="97ca8-252">ランタイムの修正プログラムのプロジェクトに追加します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-252">Add project for the runtime fix</span></span>
> * <span data-ttu-id="97ca8-253">プロジェクトを追加する実行可能ファイルの PSF ランチャーを起動します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-253">Add a project that starts the PSF Launcher executable</span></span>
> * <span data-ttu-id="97ca8-254">パッケージ プロジェクトを構成します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-254">Configure the packaging project</span></span>

<span data-ttu-id="97ca8-255">完了したら、ソリューションにはこのようになります。</span><span class="sxs-lookup"><span data-stu-id="97ca8-255">When you're done, your solution will look something like this.</span></span>

![完成したソリューション](images/desktop-to-uwp/runtime-fix-project-structure.png)

<span data-ttu-id="97ca8-257">この例では、各プロジェクトを見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="97ca8-257">Let's look at each project in this example.</span></span>

| <span data-ttu-id="97ca8-258">プロジェクト</span><span class="sxs-lookup"><span data-stu-id="97ca8-258">Project</span></span> | <span data-ttu-id="97ca8-259">目的</span><span class="sxs-lookup"><span data-stu-id="97ca8-259">Purpose</span></span> |
|-------|-----------|
| <span data-ttu-id="97ca8-260">DesktopApplicationPackage</span><span class="sxs-lookup"><span data-stu-id="97ca8-260">DesktopApplicationPackage</span></span> | <span data-ttu-id="97ca8-261">このプロジェクトは、 [Windows アプリケーション パッケージ プロジェクト](desktop-to-uwp-packaging-dot-net.md)に基づき、MSIX パッケージを出力します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-261">This project is based on the [Windows Application Packaging project](desktop-to-uwp-packaging-dot-net.md) and it outputs the MSIX package.</span></span> |
| <span data-ttu-id="97ca8-262">Runtimefix</span><span class="sxs-lookup"><span data-stu-id="97ca8-262">Runtimefix</span></span> | <span data-ttu-id="97ca8-263">これは、実行時の修正プログラムとして機能する 1 つまたは複数の代替関数が含まれている C++ Dynamic-Linked ライブラリ プロジェクトです。</span><span class="sxs-lookup"><span data-stu-id="97ca8-263">This is a C++ Dynamic-Linked Library project that contains one or more replacement functions that serve as the runtime fix.</span></span> |
| <span data-ttu-id="97ca8-264">PSFLauncher</span><span class="sxs-lookup"><span data-stu-id="97ca8-264">PSFLauncher</span></span> | <span data-ttu-id="97ca8-265">これは、C++ 空のプロジェクトです。</span><span class="sxs-lookup"><span data-stu-id="97ca8-265">This is C++ Empty Project.</span></span> <span data-ttu-id="97ca8-266">このプロジェクトは、パッケージのサポート フレームワークのランタイム配布可能なファイルを収集する場所です。</span><span class="sxs-lookup"><span data-stu-id="97ca8-266">This project is a place to collect the runtime distributable files of the Package Support Framework.</span></span> <span data-ttu-id="97ca8-267">実行可能ファイルを出力します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-267">It outputs an executable file.</span></span> <span data-ttu-id="97ca8-268">その実行可能ファイルは、ソリューションを起動するときに実行する最初のものです。</span><span class="sxs-lookup"><span data-stu-id="97ca8-268">That executable is the first thing that runs when you start the solution.</span></span> |
| <span data-ttu-id="97ca8-269">WinFormsDesktopApplication</span><span class="sxs-lookup"><span data-stu-id="97ca8-269">WinFormsDesktopApplication</span></span> | <span data-ttu-id="97ca8-270">このプロジェクトには、デスクトップ アプリケーションのソース コードが含まれています。</span><span class="sxs-lookup"><span data-stu-id="97ca8-270">This project contains the source code of a desktop application.</span></span> |

<span data-ttu-id="97ca8-271">これらの種類のプロジェクトのすべてを含む完全なサンプルを見ると、 [PSFSample](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/samples/PSFSample/)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="97ca8-271">To look at a complete sample that contains all of these types of projects, see [PSFSample](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/samples/PSFSample/).</span></span>

<span data-ttu-id="97ca8-272">作成して、ソリューション内の各プロジェクトを構成する手順について説明しましょう。</span><span class="sxs-lookup"><span data-stu-id="97ca8-272">Let's walk through the steps to create and configure each of these projects in your solution.</span></span>

### <a name="create-a-package-solution"></a><span data-ttu-id="97ca8-273">パッケージのソリューションを作成します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-273">Create a package solution</span></span>

<span data-ttu-id="97ca8-274">デスクトップ アプリケーションのソリューションがない場合は、Visual Studio で新しい**空のソリューション**を作成します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-274">If you don't already have a solution for your desktop application, create a new **Blank Solution** in Visual Studio.</span></span>

![空のソリューション](images/desktop-to-uwp/blank-solution.png)

<span data-ttu-id="97ca8-276">あるすべてのアプリケーション プロジェクトに追加することもできます。</span><span class="sxs-lookup"><span data-stu-id="97ca8-276">You may also want to add any application projects you have.</span></span>

### <a name="add-a-packaging-project"></a><span data-ttu-id="97ca8-277">パッケージ プロジェクトを追加します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-277">Add a packaging project</span></span>

<span data-ttu-id="97ca8-278">**Windows アプリケーション パッケージ プロジェクト**がまだしていない場合は、いずれかを作成し、ソリューションに追加します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-278">If you don't already have a **Windows Application Packaging Project**, create one and add it to your solution.</span></span>

![パッケージ プロジェクト テンプレート](images/desktop-to-uwp/package-project-template.png)

<span data-ttu-id="97ca8-280">Windows アプリケーション パッケージ プロジェクトの詳細については、 [Visual Studio を使って、アプリケーションのパッケージ](desktop-to-uwp-packaging-dot-net.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="97ca8-280">For more information on Windows Application Packaging project, see [Package your application by using Visual Studio](desktop-to-uwp-packaging-dot-net.md).</span></span>

<span data-ttu-id="97ca8-281">**ソリューション エクスプ ローラー**、パッケージ プロジェクトを右クリックして、選択**を編集**、およびこれをプロジェクト ファイルの下部に追加。</span><span class="sxs-lookup"><span data-stu-id="97ca8-281">In **Solution Explorer**, right-click the packaging project, select **Edit**, and then add this to the bottom of the project file:</span></span>

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

### <a name="add-project-for-the-runtime-fix"></a><span data-ttu-id="97ca8-282">ランタイムの修正プログラムのプロジェクトに追加します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-282">Add project for the runtime fix</span></span>

<span data-ttu-id="97ca8-283">**ダイナミック リンク ライブラリ (DLL)** の C++ プロジェクトをソリューションに追加します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-283">Add a C++ **Dynamic-Link Library (DLL)** project to the solution.</span></span>

![ランタイム ライブラリの修正プログラム](images/desktop-to-uwp/runtime-fix-library.png)

<span data-ttu-id="97ca8-285">[プロジェクト]、[**プロパティ**を右クリックします。</span><span class="sxs-lookup"><span data-stu-id="97ca8-285">Right-click the that project, and then choose **Properties**.</span></span>

<span data-ttu-id="97ca8-286">プロパティ ページで、**標準的な C++ 言語**のフィールドを検索し、そのフィールドの横にあるドロップダウン リストを選択して、 **ISO C 17 標準 (//std:c では 17)** オプションです。</span><span class="sxs-lookup"><span data-stu-id="97ca8-286">In the property pages, find the **C++ Language Standard** field, and then in the drop-down list next to that field, select the **ISO C++17 Standard (/std:c++17)** option.</span></span>

![ISO 17 オプション](images/desktop-to-uwp/iso-option.png)

<span data-ttu-id="97ca8-288">そのプロジェクトを右クリックし、コンテキスト メニューで、 **Nuget パッケージの管理**オプションを選択します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-288">Right-click that project, and then in the context menu, choose the **Manage Nuget Packages** option.</span></span> <span data-ttu-id="97ca8-289">**すべて**のまたは**nuget.org\*\*\*\*パッケージ ソース**オプションが設定されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-289">Ensure that the **Package source** option is set to **All** or **nuget.org**.</span></span>

<span data-ttu-id="97ca8-290">次にそのフィールドの設定アイコンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="97ca8-290">Click the settings icon next that field.</span></span>

<span data-ttu-id="97ca8-291">*PSF*の検索を \* Nuget パッケージをし、このプロジェクトにインストールします。</span><span class="sxs-lookup"><span data-stu-id="97ca8-291">Search for the *PSF*\* Nuget package, and then install it for this project.</span></span>

![nuget パッケージ](images/desktop-to-uwp/psf-package.png)

<span data-ttu-id="97ca8-293">デバッグや、既存のランタイム修正プログラムを拡張する場合は、このガイドの[ランタイムの修正プログラムの検索](#find)のセクションで説明したガイダンスを使用して、取得したランタイム修正プログラムのファイルを追加します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-293">If you want to debug or extend an existing runtime fix, add the runtime fix files that you obtained by using the guidance described in the [Find a runtime fix](#find) section of this guide.</span></span>

<span data-ttu-id="97ca8-294">新しい修正プログラムを作成する場合は、追加しないでください何もこのプロジェクトにまだだけです。</span><span class="sxs-lookup"><span data-stu-id="97ca8-294">If you intend to create a brand new fix, don't add anything to this project just yet.</span></span> <span data-ttu-id="97ca8-295">このガイドの後半では、このプロジェクトに適切なファイルを追加するをお手伝いします。</span><span class="sxs-lookup"><span data-stu-id="97ca8-295">We'll help you add the right files to this project later in this guide.</span></span> <span data-ttu-id="97ca8-296">ここでは、ソリューションの設定が引き続きされます。</span><span class="sxs-lookup"><span data-stu-id="97ca8-296">For now, we'll continue setting up your solution.</span></span>

### <a name="add-a-project-that-starts-the-psf-launcher-executable"></a><span data-ttu-id="97ca8-297">プロジェクトを追加する実行可能ファイルの PSF ランチャーを起動します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-297">Add a project that starts the PSF Launcher executable</span></span>

<span data-ttu-id="97ca8-298">C**空のプロジェクト**のプロジェクトをソリューションに追加します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-298">Add a C++ **Empty Project** project to the solution.</span></span>

![空のプロジェクト](images/desktop-to-uwp/blank-app.png)

<span data-ttu-id="97ca8-300">このプロジェクトを前のセクションで説明されている同じガイダンスを使用して、 **PSF** Nuget パッケージを追加します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-300">Add the **PSF** Nuget package to this project by using the same guidance described in the previous section.</span></span>

<span data-ttu-id="97ca8-301">開いているプロパティ ページと**全般**設定] ページで、プロジェクトの**ターゲット名**プロパティを設定します``PSFLauncher32``または``PSFLauncher64``によっては、アプリケーションのアーキテクチャ。</span><span class="sxs-lookup"><span data-stu-id="97ca8-301">Open the property pages for the project, and in the **General** settings page, set the **Target Name** property to ``PSFLauncher32`` or ``PSFLauncher64`` depending on the architecture of your application.</span></span>

![PSF ランチャー リファレンス](images/desktop-to-uwp/shim-exe-reference.png)

<span data-ttu-id="97ca8-303">ランタイム修正プロジェクトへの参照をプロジェクトをソリューションに追加します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-303">Add a project reference to the runtime fix project in your solution.</span></span>

![ランタイムの修正プログラムのリファレンス](images/desktop-to-uwp/reference-fix.png)

<span data-ttu-id="97ca8-305">参照を右クリックし、[**プロパティ**] ウィンドウで、これらの値を適用します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-305">Right-click the reference, and then in the **Properties** window, apply these values.</span></span>

| <span data-ttu-id="97ca8-306">プロパティ</span><span class="sxs-lookup"><span data-stu-id="97ca8-306">Property</span></span> | <span data-ttu-id="97ca8-307">値</span><span class="sxs-lookup"><span data-stu-id="97ca8-307">Value</span></span> |
|-------|-----------|
| <span data-ttu-id="97ca8-308">ローカル コピーします。</span><span class="sxs-lookup"><span data-stu-id="97ca8-308">Copy local</span></span> | <span data-ttu-id="97ca8-309">True</span><span class="sxs-lookup"><span data-stu-id="97ca8-309">True</span></span> |
| <span data-ttu-id="97ca8-310">ローカル サテライト アセンブリをコピーします。</span><span class="sxs-lookup"><span data-stu-id="97ca8-310">Copy Local Satellite Assemblies</span></span> | <span data-ttu-id="97ca8-311">True</span><span class="sxs-lookup"><span data-stu-id="97ca8-311">True</span></span> |
| <span data-ttu-id="97ca8-312">参照アセンブリの出力</span><span class="sxs-lookup"><span data-stu-id="97ca8-312">Reference Assembly Output</span></span> | <span data-ttu-id="97ca8-313">True</span><span class="sxs-lookup"><span data-stu-id="97ca8-313">True</span></span> |
| <span data-ttu-id="97ca8-314">リンク ライブラリの依存関係</span><span class="sxs-lookup"><span data-stu-id="97ca8-314">Link Library Dependencies</span></span> | <span data-ttu-id="97ca8-315">False</span><span class="sxs-lookup"><span data-stu-id="97ca8-315">False</span></span> |
| <span data-ttu-id="97ca8-316">リンク ライブラリの依存関係の入力</span><span class="sxs-lookup"><span data-stu-id="97ca8-316">Link Library Dependency Inputs</span></span> | <span data-ttu-id="97ca8-317">False</span><span class="sxs-lookup"><span data-stu-id="97ca8-317">False</span></span> |

### <a name="configure-the-packaging-project"></a><span data-ttu-id="97ca8-318">パッケージ プロジェクトを構成します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-318">Configure the packaging project</span></span>

<span data-ttu-id="97ca8-319">パッケージ プロジェクトで、**[アプリケーション]** フォルダーを右クリックして **[参照の追加]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="97ca8-319">In the packaging project, right-click the **Applications** folder, and then choose **Add Reference**.</span></span>

![プロジェクト参照の追加](images/desktop-to-uwp/add-reference-packaging-project.png)

<span data-ttu-id="97ca8-321">PSF ランチャー プロジェクトとデスクトップ アプリケーション プロジェクトを選択し、 **[ok]** ボタンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="97ca8-321">Choose the PSF launcher project and your desktop application project, and then choose the **OK** button.</span></span>

![デスクトップ プロジェクト](images/desktop-to-uwp/package-project-references.png)

>[!NOTE]
> <span data-ttu-id="97ca8-323">アプリケーションに、ソース コードがあるない場合は、PSF ランチャー プロジェクトを選ぶだけです。</span><span class="sxs-lookup"><span data-stu-id="97ca8-323">If you don't have the source code to your application, just choose the PSF launcher project.</span></span> <span data-ttu-id="97ca8-324">構成ファイルを作成するときに、実行可能ファイルを参照する方法紹介します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-324">We'll show you how to reference your executable when you create a configuration file.</span></span>

<span data-ttu-id="97ca8-325">**アプリケーション**ノードで、PSF ランチャー アプリケーションを右クリックし、**エントリ ポイントとして設定**します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-325">In the **Applications** node, right-click the PSF launcher application, and then choose **Set as Entry Point**.</span></span>

![エントリ ポイントの設定](images/desktop-to-uwp/set-startup-project.png)

<span data-ttu-id="97ca8-327">という名前のファイルを追加``config.json``、パッケージ プロジェクトにコピーし、ファイルに次の json テキストを貼り付けます。</span><span class="sxs-lookup"><span data-stu-id="97ca8-327">Add a file named ``config.json`` to your packaging project, then, copy and paste the following json text into the file.</span></span> <span data-ttu-id="97ca8-328">**コンテンツ**を**パッケージ アクション**プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-328">Set the **Package Action** property to **Content**.</span></span>

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

<span data-ttu-id="97ca8-329">各キーの値を提供します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-329">Provide a value for each key.</span></span> <span data-ttu-id="97ca8-330">次の表をガイドとして使用します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-330">Use this table as a guide.</span></span>

| <span data-ttu-id="97ca8-331">配列</span><span class="sxs-lookup"><span data-stu-id="97ca8-331">Array</span></span> | <span data-ttu-id="97ca8-332">key</span><span class="sxs-lookup"><span data-stu-id="97ca8-332">key</span></span> | <span data-ttu-id="97ca8-333">値</span><span class="sxs-lookup"><span data-stu-id="97ca8-333">Value</span></span> |
|-------|-----------|-------|
| <span data-ttu-id="97ca8-334">applications</span><span class="sxs-lookup"><span data-stu-id="97ca8-334">applications</span></span> | <span data-ttu-id="97ca8-335">id</span><span class="sxs-lookup"><span data-stu-id="97ca8-335">id</span></span> |  <span data-ttu-id="97ca8-336">値を使用して、`Id`の属性、`Application`パッケージ マニフェスト内の要素です。</span><span class="sxs-lookup"><span data-stu-id="97ca8-336">Use the value of the `Id` attribute of the `Application` element in the package manifest.</span></span> |
| <span data-ttu-id="97ca8-337">applications</span><span class="sxs-lookup"><span data-stu-id="97ca8-337">applications</span></span> | <span data-ttu-id="97ca8-338">実行可能</span><span class="sxs-lookup"><span data-stu-id="97ca8-338">executable</span></span> | <span data-ttu-id="97ca8-339">起動する実行可能ファイルへのパッケージ相対パス。</span><span class="sxs-lookup"><span data-stu-id="97ca8-339">The package-relative path to the executable that you want to start.</span></span> <span data-ttu-id="97ca8-340">ほとんどの場合、変更する前に、パッケージ マニフェスト ファイルからこの値を取得できます。</span><span class="sxs-lookup"><span data-stu-id="97ca8-340">In most cases, you can get this value from your package manifest file before you modify it.</span></span> <span data-ttu-id="97ca8-341">値では、`Executable`の属性、`Application`要素です。</span><span class="sxs-lookup"><span data-stu-id="97ca8-341">It's the value of the `Executable` attribute of the `Application` element.</span></span> |
| <span data-ttu-id="97ca8-342">applications</span><span class="sxs-lookup"><span data-stu-id="97ca8-342">applications</span></span> | <span data-ttu-id="97ca8-343">workingDirectory</span><span class="sxs-lookup"><span data-stu-id="97ca8-343">workingDirectory</span></span> | <span data-ttu-id="97ca8-344">(省略可能)起動するアプリケーションの作業ディレクトリとして使用するパッケージの相対パス。</span><span class="sxs-lookup"><span data-stu-id="97ca8-344">(Optional) A package-relative path to use as the working directory of the application that starts.</span></span> <span data-ttu-id="97ca8-345">この値を設定しない場合、オペレーティング システムを使用して、`System32`アプリケーションの作業ディレクトリとしてディレクトリ。</span><span class="sxs-lookup"><span data-stu-id="97ca8-345">If you don't set this value, the operating system uses the `System32` directory as the application's working directory.</span></span> |
| <span data-ttu-id="97ca8-346">プロセス</span><span class="sxs-lookup"><span data-stu-id="97ca8-346">processes</span></span> | <span data-ttu-id="97ca8-347">実行可能</span><span class="sxs-lookup"><span data-stu-id="97ca8-347">executable</span></span> | <span data-ttu-id="97ca8-348">ほとんどの場合の名前になります、`executable`削除パスとファイルの拡張子を持つ上に構成されています。</span><span class="sxs-lookup"><span data-stu-id="97ca8-348">In most cases, this will be the name of the `executable` configured above with the path and file extension removed.</span></span> |
| <span data-ttu-id="97ca8-349">fixup</span><span class="sxs-lookup"><span data-stu-id="97ca8-349">fixups</span></span> | <span data-ttu-id="97ca8-350">dll</span><span class="sxs-lookup"><span data-stu-id="97ca8-350">dll</span></span> | <span data-ttu-id="97ca8-351">パッケージの相対パスを読み込む DLL の修正します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-351">Package-relative path to the fixup DLL to load.</span></span> |
| <span data-ttu-id="97ca8-352">fixup</span><span class="sxs-lookup"><span data-stu-id="97ca8-352">fixups</span></span> | <span data-ttu-id="97ca8-353">config</span><span class="sxs-lookup"><span data-stu-id="97ca8-353">config</span></span> | <span data-ttu-id="97ca8-354">(省略可能)修正 DLL の動作を制御します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-354">(Optional) Controls how the fixup DLL behaves.</span></span> <span data-ttu-id="97ca8-355">この値の正確な形式は、各修正が解釈できるようにこの"blob"必要があるように修正の修正によってごとに異なります。</span><span class="sxs-lookup"><span data-stu-id="97ca8-355">The exact format of this value varies on a fixup-by-fixup basis as each fixup can interpret this "blob" as it wants.</span></span> |

<span data-ttu-id="97ca8-356">完了したら、``config.json``ファイルは次のようになります。</span><span class="sxs-lookup"><span data-stu-id="97ca8-356">When you're done, your ``config.json`` file will look something like this.</span></span>

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
> <span data-ttu-id="97ca8-357">`applications`、 `processes`、および`fixups`キーは、配列です。</span><span class="sxs-lookup"><span data-stu-id="97ca8-357">The `applications`, `processes`, and `fixups` keys are arrays.</span></span> <span data-ttu-id="97ca8-358">つまり、1 つ以上のアプリケーション、プロセス、および修正 DLL を指定する config.json ファイルを使用することができます。</span><span class="sxs-lookup"><span data-stu-id="97ca8-358">That means that you can use the config.json file to specify more than one application, process, and fixup DLL.</span></span>

### <a name="debug-a-runtime-fix"></a><span data-ttu-id="97ca8-359">ランタイムの修正プログラムをデバッグします。</span><span class="sxs-lookup"><span data-stu-id="97ca8-359">Debug a runtime fix</span></span>

<span data-ttu-id="97ca8-360">Visual Studio で f5 キーを押してデバッガーを起動します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-360">In Visual Studio, press F5 to start the debugger.</span></span>  <span data-ttu-id="97ca8-361">最初に起動することは、次に、ターゲット デスクトップ アプリケーションを起動する PSF ランチャー アプリケーションです。</span><span class="sxs-lookup"><span data-stu-id="97ca8-361">The first thing that starts is the PSF launcher application, which in turn, starts your target desktop application.</span></span>  <span data-ttu-id="97ca8-362">ターゲットのデスクトップ アプリケーションをデバッグするには、手動で**デバッグ**を選択してデスクトップ アプリケーションのプロセスにアタッチする必要があります->**プロセスにアタッチ**し、アプリケーションのプロセスを選択します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-362">To debug the target desktop application, you'll have to manually attach to the desktop application process by choosing **Debug**->**Attach to Process**, and then selecting the application process.</span></span> <span data-ttu-id="97ca8-363">ネイティブ ランタイム修正 DLL を持つ .NET アプリケーションのデバッグを許可するには、マネージとネイティブ コードの種類 (混在モードのデバッグ) を選択します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-363">To permit the debugging of a .NET application with a native runtime fix DLL, select managed and native code types (mixed mode debugging).</span></span>  

<span data-ttu-id="97ca8-364">これ設定したら、デスクトップ アプリケーション コードとランタイムの修正プログラム プロジェクトで数行のコードの横にブレークポイントを設定できます。</span><span class="sxs-lookup"><span data-stu-id="97ca8-364">Once you've set this up, you can set break points next to lines of code in the desktop application code and the runtime fix project.</span></span> <span data-ttu-id="97ca8-365">アプリケーションに、ソース コードがあるない場合、ランタイムの修正プログラムのプロジェクトで数行のコードの横にあるブレークポイントを設定することができます。</span><span class="sxs-lookup"><span data-stu-id="97ca8-365">If you don't have the source code to your application, you'll be able to set break points only next to lines of code in your runtime fix project.</span></span>

>[!NOTE]
> <span data-ttu-id="97ca8-366">Visual Studio を使用する最も簡単な開発、エクスペリエンスをデバッグするには、いくつかの制限がある、このガイドでは、後でについて説明します他のデバッグ手法を適用することができます。</span><span class="sxs-lookup"><span data-stu-id="97ca8-366">While Visual Studio gives you the simplest development and debugging experience, there are some limitations, so later in this guide, we'll discuss other debugging techniques that you can apply.</span></span>

## <a name="create-a-runtime-fix"></a><span data-ttu-id="97ca8-367">ランタイムの修正プログラムを作成します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-367">Create a runtime fix</span></span>

<span data-ttu-id="97ca8-368">ない場合、ランタイムを解決する場合、代替関数を作成し、構成データを含む新しいランタイムの修正プログラムを作成すること、問題の修正意味のあります。</span><span class="sxs-lookup"><span data-stu-id="97ca8-368">If there isn't yet a runtime fix for the issue that you want to resolve, you can create a new runtime fix by writing replacement functions and including any configuration data that makes sense.</span></span> <span data-ttu-id="97ca8-369">各部分を見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="97ca8-369">Let's look at each part.</span></span>

### <a name="replacement-functions"></a><span data-ttu-id="97ca8-370">代替機能</span><span class="sxs-lookup"><span data-stu-id="97ca8-370">Replacement functions</span></span>

<span data-ttu-id="97ca8-371">最初に、どの関数の呼び出しは失敗 MSIX コンテナー内で、アプリケーションが実行されている場合を特定します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-371">First, identify which function calls fail when your application runs in an MSIX container.</span></span> <span data-ttu-id="97ca8-372">次に、代替関数を呼び出す代わりに、ランタイム マネージャーたいを作成できます。</span><span class="sxs-lookup"><span data-stu-id="97ca8-372">Then, you can create replacement functions that you'd like the runtime manager to call instead.</span></span> <span data-ttu-id="97ca8-373">これにより、関数の実装を最新のランタイム環境の規則に準拠している動作に置き換えることです。</span><span class="sxs-lookup"><span data-stu-id="97ca8-373">This gives you an opportunity to replace the implementation of a function with behavior that conforms to the rules of the modern runtime environment.</span></span>

<span data-ttu-id="97ca8-374">Visual Studio では、このガイドで既に作成したランタイム修正プロジェクトを開きます。</span><span class="sxs-lookup"><span data-stu-id="97ca8-374">In Visual Studio, open the runtime fix project that you created earlier in this guide.</span></span>

<span data-ttu-id="97ca8-375">宣言、``FIXUP_DEFINE_EXPORTS``マクロし、追加のインクルード ステートメント、`fixup_framework.h`それぞれの上部にします。CPP ファイルは、実行時の修正プログラムの関数を追加します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-375">Declare the ``FIXUP_DEFINE_EXPORTS`` macro and then add a include statement for the `fixup_framework.h` at the top of each .CPP file where you intend to add the functions of your runtime fix.</span></span>

```c++
#define FIXUP_DEFINE_EXPORTS
#include <fixup_framework.h>
```

>[!IMPORTANT]
><span data-ttu-id="97ca8-376">確認、`FIXUP_DEFINE_EXPORTS`マクロがインクルード ステートメントの前に表示されます。</span><span class="sxs-lookup"><span data-stu-id="97ca8-376">Make sure that the `FIXUP_DEFINE_EXPORTS` macro appears before the include statement.</span></span>

<span data-ttu-id="97ca8-377">同じ関数のシグネチャを持つ関数を作成しているが動作を変更します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-377">Create a function that has the same signature of the function who's behavior you want to modify.</span></span> <span data-ttu-id="97ca8-378">置換する関数の例を次に示します、`MessageBoxW`関数です。</span><span class="sxs-lookup"><span data-stu-id="97ca8-378">Here's an example function that replaces the `MessageBoxW` function.</span></span>

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

<span data-ttu-id="97ca8-379">呼び出し`DECLARE_FIXUP`マップ、`MessageBoxW`新しい代替関数に機能します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-379">The call to `DECLARE_FIXUP` maps the `MessageBoxW` function to your new replacement function.</span></span> <span data-ttu-id="97ca8-380">アプリケーションが呼び出すしようとしたとき、`MessageBoxW`関数を呼び出して関数代わりにします。</span><span class="sxs-lookup"><span data-stu-id="97ca8-380">When your application attempts to call the `MessageBoxW` function, it will call the replacement function instead.</span></span>

#### <a name="protect-against-recursive-calls-to-functions-in-runtime-fixes"></a><span data-ttu-id="97ca8-381">ランタイムの修正プログラムの関数を再帰呼び出しからの保護します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-381">Protect against recursive calls to functions in runtime fixes</span></span>

<span data-ttu-id="97ca8-382">適用することが必要に応じて、`reentrancy_guard`を再帰的なランタイムの修正プログラムでの関数の呼び出しを保護する関数の種類。</span><span class="sxs-lookup"><span data-stu-id="97ca8-382">You can optionally apply the `reentrancy_guard` type to your functions that protect against recursive calls to functions in runtime fixes.</span></span>

<span data-ttu-id="97ca8-383">代替の関数を作成するなど、`CreateFile`関数です。</span><span class="sxs-lookup"><span data-stu-id="97ca8-383">For example, you might produce a replacement function for the `CreateFile` function.</span></span> <span data-ttu-id="97ca8-384">実装を呼び出すことがあります、`CopyFile`が、実装、`CopyFile`関数を呼び出すことがあります、`CreateFile`関数です。</span><span class="sxs-lookup"><span data-stu-id="97ca8-384">Your implementation might call the `CopyFile` function, but the implementation of the `CopyFile` function might call the `CreateFile` function.</span></span> <span data-ttu-id="97ca8-385">これは、無限再帰サイクルへの呼び出しのする可能性があります、`CreateFile`関数です。</span><span class="sxs-lookup"><span data-stu-id="97ca8-385">This may lead to an infinite recursive cycle of calls to the `CreateFile` function.</span></span>

<span data-ttu-id="97ca8-386">ついて詳しくは`reentrancy_guard` [authoring.md](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/Authoring.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="97ca8-386">For more information on `reentrancy_guard` see [authoring.md](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/Authoring.md)</span></span>

### <a name="configuration-data"></a><span data-ttu-id="97ca8-387">構成データ</span><span class="sxs-lookup"><span data-stu-id="97ca8-387">Configuration data</span></span>

<span data-ttu-id="97ca8-388">構成データ、ランタイムの修正プログラムを追加する場合は、追加することを検討してください、``config.json``します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-388">If you want to add configuration data to your runtime fix, consider adding it to the ``config.json``.</span></span> <span data-ttu-id="97ca8-389">そうすることが使うことが、`FixupQueryCurrentDllConfig`にそのデータを簡単に解析します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-389">That way, you can use the `FixupQueryCurrentDllConfig` to easily parse that data.</span></span> <span data-ttu-id="97ca8-390">この例では、その構成ファイルからのブール値と文字列の値を解析します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-390">This example parses a boolean and string value from that configuration file.</span></span>

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

## <a name="other-debugging-techniques"></a><span data-ttu-id="97ca8-391">その他のデバッグ手法</span><span class="sxs-lookup"><span data-stu-id="97ca8-391">Other debugging techniques</span></span>

<span data-ttu-id="97ca8-392">Visual Studio を使用すると、最も簡単な開発およびデバッグ エクスペリエンスは制限があります。</span><span class="sxs-lookup"><span data-stu-id="97ca8-392">While Visual Studio gives you the simplest development and debugging experience, there are some limitations.</span></span>

<span data-ttu-id="97ca8-393">.Msix からインストールするのではなく、パッケージのレイアウト フォルダー パスからルーズ ファイルを展開することによって、アプリケーションを最初に、F5 デバッグ実行/.appx パッケージ。</span><span class="sxs-lookup"><span data-stu-id="97ca8-393">First, F5 debugging runs the application by deploying loose files from the package layout folder path, rather than installing from a .msix / .appx package.</span></span>  <span data-ttu-id="97ca8-394">レイアウト フォルダー通常ありませんセキュリティの制限を同じパッケージのインストール フォルダーとして。</span><span class="sxs-lookup"><span data-stu-id="97ca8-394">The layout folder typically does not have the same security restrictions as an installed package folder.</span></span> <span data-ttu-id="97ca8-395">その結果、にくいかもしれませんランタイムの修正プログラムを適用する前にパッケージのパスへのアクセス拒否エラーを再現することもできます。</span><span class="sxs-lookup"><span data-stu-id="97ca8-395">As a result, it may not be possible to reproduce package path access denial errors prior to applying a runtime fix.</span></span>

<span data-ttu-id="97ca8-396">この問題に対処する使用 .msix f5 キーではなく、.appx パッケージの展開が失われるファイルの展開/します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-396">To address this issue, use .msix / .appx package deployment rather than F5 loose file deployment.</span></span>  <span data-ttu-id="97ca8-397">.Msix を作成する .appx パッケージ ファイルは、前述のように、Windows SDK から[MakeMSIX](https://docs.microsoft.com/en-us/windows/desktop/appxpkg/make-appx-package--makeappx-exe-)ユーティリティを使用します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-397">To create a .msix / .appx package file, use the [MakeMSIX](https://docs.microsoft.com/en-us/windows/desktop/appxpkg/make-appx-package--makeappx-exe-) utility from the Windows SDK, as described above.</span></span> <span data-ttu-id="97ca8-398">またはから、Visual Studio 内アプリケーション プロジェクト ノードを右クリックし、**ストア**を選択->**アプリ パッケージの作成**します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-398">Or, from within Visual Studio, right-click your application project node and select **Store**->**Create App Packages**.</span></span>

<span data-ttu-id="97ca8-399">Visual Studio の別の問題は、デバッガーを起動したすべての子プロセスにアタッチするための組み込みサポートがないことです。</span><span class="sxs-lookup"><span data-stu-id="97ca8-399">Another issue with Visual Studio is that it does not have built-in support for attaching to any child processes launched by the debugger.</span></span>   <span data-ttu-id="97ca8-400">Visual Studio での起動後が手動で接続され、ターゲット アプリケーションのスタートアップ パス内のロジックをデバッグが困難になります。</span><span class="sxs-lookup"><span data-stu-id="97ca8-400">This makes it difficult to debug logic in the startup path of the target application, which must be manually attached by Visual Studio after launch.</span></span>

<span data-ttu-id="97ca8-401">この問題に対処するには、使用子プロセスをサポートしているデバッガーをアタッチします。</span><span class="sxs-lookup"><span data-stu-id="97ca8-401">To address this issue, use a debugger that supports child process attach.</span></span>  <span data-ttu-id="97ca8-402">一般に、ターゲット アプリケーションにジャスト イン タイム (JIT) デバッガーをアタッチすることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="97ca8-402">Note that it is generally not possible to attach a just-in-time (JIT) debugger to the target application.</span></span>  <span data-ttu-id="97ca8-403">これは、ほとんど JIT 技法 ImageFileExecutionOptions レジストリ キーを使用して、対象のアプリの代わりにデバッガーを起動するためです。</span><span class="sxs-lookup"><span data-stu-id="97ca8-403">This is because most JIT techniques involve launching the debugger in place of the target app, via the ImageFileExecutionOptions registry key.</span></span>  <span data-ttu-id="97ca8-404">ターゲット アプリに FixupRuntime.dll を挿入するために使用 PSFLauncher.exe detouring メカニズムが損なわれるためです。</span><span class="sxs-lookup"><span data-stu-id="97ca8-404">This defeats the detouring mechanism used by PSFLauncher.exe to inject FixupRuntime.dll into the target app.</span></span>  <span data-ttu-id="97ca8-405">WinDbg、 [Debugging Tools for Windows](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/index)に含まれているし、 [Windows SDK](https://developer.microsoft.com/en-US/windows/downloads/windows-10-sdk)から取得したサポート子プロセスをアタッチします。</span><span class="sxs-lookup"><span data-stu-id="97ca8-405">WinDbg, included in the [Debugging Tools for Windows](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/index), and obtained from the [Windows SDK](https://developer.microsoft.com/en-US/windows/downloads/windows-10-sdk), supports child process attach.</span></span>  <span data-ttu-id="97ca8-406">サポート直接[起動して UWP アプリをデバッグ](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/debugging-a-uwp-app-using-windbg#span-idlaunchinganddebuggingauwpappspanspan-idlaunchinganddebuggingauwpappspanspan-idlaunchinganddebuggingauwpappspanlaunching-and-debugging-a-uwp-app)します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-406">It also now supports directly [launching and debugging a UWP app](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/debugging-a-uwp-app-using-windbg#span-idlaunchinganddebuggingauwpappspanspan-idlaunchinganddebuggingauwpappspanspan-idlaunchinganddebuggingauwpappspanlaunching-and-debugging-a-uwp-app).</span></span>

<span data-ttu-id="97ca8-407">子プロセスとしてターゲット アプリケーションの起動をデバッグするには、開始``WinDbg``します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-407">To debug target application startup as a child process, start ``WinDbg``.</span></span>

```ps
windbg.exe -plmPackage PSFSampleWithFixup_1.0.59.0_x86__7s220nvg1hg3m -plmApp PSFSample
```

<span data-ttu-id="97ca8-408">``WinDbg``プロンプト、子のデバッグを有効にして適切なブレークポイントを設定します。</span><span class="sxs-lookup"><span data-stu-id="97ca8-408">At the ``WinDbg`` prompt, enable child debugging and set appropriate breakpoints.</span></span>

```ps
.childdbg 1
g
```

<span data-ttu-id="97ca8-409">(ターゲット アプリケーションが開始され、デバッガーにするまで実行)</span><span class="sxs-lookup"><span data-stu-id="97ca8-409">(execute until target application starts and breaks into the debugger)</span></span>

```ps
sxe ld fixup.dll
g
```

<span data-ttu-id="97ca8-410">(修正の DLL が読み込まれるまで実行されません)</span><span class="sxs-lookup"><span data-stu-id="97ca8-410">(execute until the fixup DLL is loaded)</span></span>

```ps
bp ...
```

>[!NOTE]
> <span data-ttu-id="97ca8-411">[PLMDebug](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/plmdebug)では、アプリの起動時にデバッガーをアタッチするも使用できますされ、 [Debugging Tools for Windows](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/index)にも含まれています。</span><span class="sxs-lookup"><span data-stu-id="97ca8-411">[PLMDebug](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/plmdebug) can be also used to attach a debugger to an app upon launch, and is also included in the [Debugging Tools for Windows](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/index).</span></span>  <span data-ttu-id="97ca8-412">ただし、WinDbg によって提供されるようになりました直接サポートよりも複雑です。</span><span class="sxs-lookup"><span data-stu-id="97ca8-412">However, it is more complex to use than the direct support now provided by WinDbg.</span></span>

## <a name="support-and-feedback"></a><span data-ttu-id="97ca8-413">サポートとフィードバック</span><span class="sxs-lookup"><span data-stu-id="97ca8-413">Support and feedback</span></span>

**<span data-ttu-id="97ca8-414">質問に対する回答を見つける</span><span class="sxs-lookup"><span data-stu-id="97ca8-414">Find answers to your questions</span></span>**

<span data-ttu-id="97ca8-415">ご質問がある場合は、</span><span class="sxs-lookup"><span data-stu-id="97ca8-415">Have questions?</span></span> <span data-ttu-id="97ca8-416">Stack Overflow でお問い合わせください。</span><span class="sxs-lookup"><span data-stu-id="97ca8-416">Ask us on Stack Overflow.</span></span> <span data-ttu-id="97ca8-417">Microsoft のチームでは、これらの[タグ](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge)をチェックしています。</span><span class="sxs-lookup"><span data-stu-id="97ca8-417">Our team monitors these [tags](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge).</span></span> <span data-ttu-id="97ca8-418">[こちら](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D)から質問することもできます。</span><span class="sxs-lookup"><span data-stu-id="97ca8-418">You can also ask us [here](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D).</span></span>
