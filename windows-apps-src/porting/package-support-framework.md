---
author: normesta
Description: Fix issues that prevent your desktop application from running in an MSIX container
Search.Product: eADQiWindows 10XVcnh
title: デスクトップ アプリケーション、MSIX コンテナーでの実行を妨げている問題を修正します。
ms.author: normesta
ms.date: 07/02/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 46d5705233af9e8254b9ac89a2d6e9891e90701f
ms.sourcegitcommit: c8f6866100a4b38fdda8394ea185b02d7af66411
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/13/2018
ms.locfileid: "3957502"
---
# <a name="apply-runtime-fixes-to-an-msix-package-by-using-the-package-support-framework"></a><span data-ttu-id="b9dc6-103">パッケージのサポートのフレームワークを使用して、MSIX パッケージにランタイムの修正プログラムを適用します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-103">Apply runtime fixes to an MSIX package by using the Package Support Framework</span></span>

<span data-ttu-id="b9dc6-104">パッケージのサポートのフレームワークでは、修正プログラムの適用、既存の win32 アプリケーションをソース コードにアクセスできない場合、MSIX コンテナーで実行できるようにするために役立つオープン ソースのキットです。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-104">The Package Support Framework is an open source kit that helps you apply fixes to your existing win32 application when you don't have access to the source code, so that it can run in an MSIX container.</span></span> <span data-ttu-id="b9dc6-105">パッケージのサポートのフレームワークには、最新のランタイム環境のベスト プラクティスに従って、アプリケーションが役立ちます。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-105">The Package Support Framework helps your application follow the best practices of the modern runtime environment.</span></span>

<span data-ttu-id="b9dc6-106">パッケージのサポートのフレームワークを作成するには、Microsoft Research (MSR) によって開発されたオープン ソース フレームワークとにより API のリダイレクトを見つけてフック[は](https://www.microsoft.com/en-us/research/project/detours)テクノロジを活用します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-106">To create the Package Support Framework, we leveraged the [Detours](https://www.microsoft.com/en-us/research/project/detours) technology which is an open source framework developed by Microsoft Research (MSR) and helps with API redirection and hooking.</span></span>

<span data-ttu-id="b9dc6-107">このフレームワークは、オープン ソース、軽量で、アプリケーションの問題を解決する迅速に使用できます。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-107">This framework is open source, lightweight, and you can use it to address application issues quickly.</span></span> <span data-ttu-id="b9dc6-108">、世界コミュニティに相談して、他のユーザーへの投資の最上位に構築することもできます。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-108">It also gives you the opportunity to consult with the community around the globe, and to build on top of the investments of others.</span></span>

## <a name="a-quick-look-inside-of-the-package-support-framework"></a><span data-ttu-id="b9dc6-109">パッケージのサポート フレームワーク内での確認</span><span class="sxs-lookup"><span data-stu-id="b9dc6-109">A quick look inside of the Package Support Framework</span></span>

<span data-ttu-id="b9dc6-110">パッケージのサポートのフレームワークには、実行可能ファイル、ランタイム マネージャー、DLL とランタイムの修正プログラムのセットが含まれています。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-110">The Package Support Framework contains an executable, a runtime manager  DLL, and a set of runtime fixes.</span></span>

![パッケージのサポート フレームワーク](images/desktop-to-uwp/package-support-framework.png)

<span data-ttu-id="b9dc6-112">しくみは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-112">Here's how it works.</span></span> <span data-ttu-id="b9dc6-113">アプリケーションに適用する fix(s) を指定する構成ファイルを作成します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-113">You'll create a configuration file that specifies the fix(s) that you want to apply to your application.</span></span> <span data-ttu-id="b9dc6-114">次に、shim ランチャーの実行可能ファイルをポイントするパッケージを変更します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-114">Then, you'll modify your package to point to the shim launcher executable file.</span></span>

<span data-ttu-id="b9dc6-115">ユーザーがアプリケーションを起動するときに実行される最初の実行可能ファイルは shim ランチャーです。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-115">When users start your application, the shim launcher is the first executable that runs.</span></span> <span data-ttu-id="b9dc6-116">構成ファイルを読み込んで、ランタイム fix(s) とランタイム manager DLL をアプリケーションのプロセスに挿入します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-116">It reads your configuration file, and injects the runtime fix(s) and the runtime manager  DLL into the application process.</span></span>

![パッケージのサポート フレームワーク DLL インジェクション](images/desktop-to-uwp/package-support-framework-2.png)

<span data-ttu-id="b9dc6-118">ランタイム マネージャーでは、MSIX コンテナー内で実行するアプリケーションでは、必要に応じて、修正プログラムが適用されます。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-118">The runtime manager applies the fix when it's needed by the application to run inside of an MSIX container.</span></span>

<span data-ttu-id="b9dc6-119">このガイドには、アプリケーションの互換性の問題を識別するため、およびそれらに対処する修正プログラムを検索し、適用され、ランタイムを拡張します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-119">This guide will help you to identify application compatibility issues, and to find, apply, and extend runtime fixes that address them.</span></span>

<a id="identify" />

## <a name="identify-packaged-application-compatibility-issues"></a><span data-ttu-id="b9dc6-120">パッケージ化されたアプリケーションの互換性の問題を特定します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-120">Identify packaged application compatibility issues</span></span>

<span data-ttu-id="b9dc6-121">最初に、アプリケーションのパッケージを作成します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-121">First, create a package for your application.</span></span> <span data-ttu-id="b9dc6-122">次に、インストール、実行し、その動作を確認します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-122">Then, install it, run it, and observe its behavior.</span></span> <span data-ttu-id="b9dc6-123">互換性の問題を識別するのに役立ちますエラー メッセージを表示される場合があります。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-123">You might receive error messages that can help you identify a compatibility issue.</span></span> <span data-ttu-id="b9dc6-124">問題を特定するのに[プロセスのモニター](https://docs.microsoft.com/en-us/sysinternals/downloads/procmon)を使用することもできます。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-124">You can also use [Process Monitor](https://docs.microsoft.com/en-us/sysinternals/downloads/procmon) to identify issues.</span></span>  <span data-ttu-id="b9dc6-125">一般的な問題は、作業ディレクトリとプログラムのパスのアクセス許可に関する前提条件をアプリケーションに関連します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-125">Common issues relate to application assumptions regarding the working directory and program path permissions.</span></span>

### <a name="using-process-monitor-to-identify-an-issue"></a><span data-ttu-id="b9dc6-126">プロセスのモニターを使用して、問題を特定するには</span><span class="sxs-lookup"><span data-stu-id="b9dc6-126">Using Process Monitor to identify an issue</span></span>

<span data-ttu-id="b9dc6-127">[プロセスのモニター](https://docs.microsoft.com/en-us/sysinternals/downloads/procmon)は、アプリのファイルとレジストリの操作、およびその結果を監視するための強力なユーティリティです。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-127">[Process Monitor](https://docs.microsoft.com/en-us/sysinternals/downloads/procmon) is a powerful utility for observing an app's file and registry operations, and their results.</span></span>  <span data-ttu-id="b9dc6-128">アプリケーションの互換性の問題について理解することができます。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-128">This can help you to understand application compatibility issues.</span></span>  <span data-ttu-id="b9dc6-129">プロセスのモニターを開いたら、フィルターを追加します (フィルター > フィルター.)、アプリケーションの実行可能ファイルからのイベントのみを含めます。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-129">After opening Process Monitor, add a filter (Filter > Filter…) to include only events from the application executable.</span></span>

![ProcMon アプリ フィルター](images/desktop-to-uwp/procmon_app_filter.png)

<span data-ttu-id="b9dc6-131">イベントの一覧が表示されます。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-131">A list of events will appear.</span></span> <span data-ttu-id="b9dc6-132">これらのイベントの多くに、単語**成功**を**結果**の列に表示してされます。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-132">For many of these events, the word **SUCCESS** will appear in the **Result** column.</span></span>

![ProcMon イベント](images/desktop-to-uwp/procmon_events.png)

<span data-ttu-id="b9dc6-134">必要に応じて、のみエラーのみを表示するイベントをフィルター処理することができます。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-134">Optionally, you can filter events to only show only failures.</span></span>

![ProcMon 除外の成功](images/desktop-to-uwp/procmon_exclude_success.png)

<span data-ttu-id="b9dc6-136">ファイルシステムへアクセスの失敗が疑われる場合は、[System32/SysWOW64 またはパッケージのファイル パスの下である障害が発生したイベントを検索します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-136">If you suspect a filesystem access failure, search for failed events that are under either the System32/SysWOW64 or the package file path.</span></span> <span data-ttu-id="b9dc6-137">フィルターを使っても役立ちますここでは、すぎます。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-137">Filters can also help here, too.</span></span> <span data-ttu-id="b9dc6-138">この一覧の下部に開始し、上方向にスクロールします。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-138">Start at the bottom of this list and scroll upwards.</span></span> <span data-ttu-id="b9dc6-139">この一覧の下部に表示されるエラーが発生した最も新しくします。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-139">Failures that appear at the bottom of this list have occurred most recently.</span></span> <span data-ttu-id="b9dc6-140">「アクセス拒否」などの文字列が含まれているエラーや"パス/名前が見つかりません"、ほとんどの注意を払うし、疑わしい外観がないことを無視します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-140">Pay most attention to errors that contain strings such as "access denied," and "path/name not found", and ignore things that don't look suspicious.</span></span> <span data-ttu-id="b9dc6-141">[PSFSample](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/samples/PSFSample/)では、2 つの問題があります。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-141">The [PSFSample](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/samples/PSFSample/) has two issues.</span></span> <span data-ttu-id="b9dc6-142">次の図に表示される一覧でそれらの問題を確認できます。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-142">You can see those issues in the list that appears in the following image.</span></span>

![ProcMon Config.txt](images/desktop-to-uwp/procmon_config_txt.png)

<span data-ttu-id="b9dc6-144">この画像に表示される最初の問題、アプリケーションは、"C:\Windows\SysWOW64"パスにある"Config.txt"ファイルから読み取る失敗しています。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-144">In the first issue that appears in this image, the application is failing to read from the "Config.txt" file that is located in the "C:\Windows\SysWOW64" path.</span></span> <span data-ttu-id="b9dc6-145">アプリケーションがそのパスを直接参照しようとしている可能性が高いことはできません。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-145">It's unlikely that the application is trying to reference that path directly.</span></span> <span data-ttu-id="b9dc6-146">ほとんどの場合、相対パスを使用して、そのファイルから読み取るしようと、既定では、"System32/SysWOW64"には、アプリケーションの作業ディレクトリ。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-146">Most likely, it's trying to read from that file by using a relative path, and by default, "System32/SysWOW64" is the application's working directory.</span></span> <span data-ttu-id="b9dc6-147">これは、アプリケーションでは、パッケージのどこかに設定する現在の作業ディレクトリを想定を示しています。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-147">This suggests that the application is expecting its current working directory to be set to somewhere in the package.</span></span> <span data-ttu-id="b9dc6-148">Appx 内で見ると、実行可能ファイルと同じディレクトリにファイルが存在することを確認できます。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-148">Looking inside of the appx, we can see that the file exists in the same directory as the executable.</span></span>

![アプリの Config.txt](images/desktop-to-uwp/psfsampleapp_config_txt.png)

<span data-ttu-id="b9dc6-150">2 番目の問題は、次の図が表示されます。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-150">The second issue appears in the following image.</span></span>

![ProcMon ログ ファイル](images/desktop-to-uwp/procmon_logfile.png)

<span data-ttu-id="b9dc6-152">この問題は、アプリケーションは、そのパッケージのパスに .log ファイルを書き込むに失敗しています。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-152">In this issue, the application is failing to write a .log file to its package path.</span></span> <span data-ttu-id="b9dc6-153">これにより、ファイルのリダイレクト shim が役立つ場合がありますがお勧めします。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-153">This would suggest that a file redirection shim might help.</span></span>

<a id="find" />

## <a name="find-a-runtime-fix"></a><span data-ttu-id="b9dc6-154">ランタイムの修正プログラムを見つける</span><span class="sxs-lookup"><span data-stu-id="b9dc6-154">Find a runtime fix</span></span>

<span data-ttu-id="b9dc6-155">PSF には、ファイルのリダイレクト shim など、今すぐに使用できるランタイムの修正プログラムが含まれています。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-155">The PSF contains runtime fixes that you can use right now, such as the file redirection shim.</span></span>

### <a name="file-redirection-shim"></a><span data-ttu-id="b9dc6-156">ファイルのリダイレクト Shim</span><span class="sxs-lookup"><span data-stu-id="b9dc6-156">File Redirection Shim</span></span>

<span data-ttu-id="b9dc6-157">書き込みまたは MSIX コンテナー内で実行されるアプリケーションからアクセス可能ではないディレクトリ内のデータを読み取るしようとするたびにリダイレクトするのに[ファイルのリダイレクト Shim](https://github.com/Microsoft/MSIX-PackageSupportFramework/tree/develop/FileRedirectionShim)を使用することができます。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-157">You can use the [File Redirection Shim](https://github.com/Microsoft/MSIX-PackageSupportFramework/tree/develop/FileRedirectionShim) to redirect attempts to write or read data in a directory that isn't accessible from an application that runs in an MSIX container.</span></span>

<span data-ttu-id="b9dc6-158">たとえば、アプリケーションが、アプリケーションの実行可能ファイルと同じディレクトリで公開されているログ ファイルに書き込む場合、は、ローカル アプリ データ ストアなどの別の場所にそのログ ファイルを作成する[ファイルのリダイレクト Shim](https://github.com/Microsoft/MSIX-PackageSupportFramework/tree/develop/FileRedirectionShim)を使用できます。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-158">For example, if your application writes to a log file that is in the same directory as your applications executable, then you can use the [File Redirection Shim](https://github.com/Microsoft/MSIX-PackageSupportFramework/tree/develop/FileRedirectionShim) to create that log file in another location, such as the local app data store.</span></span>

### <a name="runtime-fixes-from-the-community"></a><span data-ttu-id="b9dc6-159">コミュニティからランタイムの修正プログラム</span><span class="sxs-lookup"><span data-stu-id="b9dc6-159">Runtime fixes from the community</span></span>

<span data-ttu-id="b9dc6-160">当社の[GitHub](https://github.com/Microsoft/MSIX-PackageSupportFramework/tree/develop)ページをコミュニティの投稿を確認してください。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-160">Make sure to review the community contributions to our [GitHub](https://github.com/Microsoft/MSIX-PackageSupportFramework/tree/develop) page.</span></span> <span data-ttu-id="b9dc6-161">他の開発者が自分のような問題を解決してされ、実行時の修正プログラムと共有できます。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-161">It's possible that other developers have resolved an issue similar to yours and have shared a runtime fix.</span></span>

## <a name="apply-a-runtime-fix"></a><span data-ttu-id="b9dc6-162">ランタイムの修正プログラムを適用します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-162">Apply a runtime fix</span></span>

<span data-ttu-id="b9dc6-163">Windows SDK と次の手順では、いくつかの簡単なツールを使用して既存のランタイムの修正を適用できます。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-163">You can apply an existing runtime fix with a few simple tools from the Windows SDK, and by following these steps.</span></span>

> [!div class="checklist"]
> * <span data-ttu-id="b9dc6-164">パッケージ レイアウト フォルダーを作成します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-164">Create a package layout folder</span></span>
> * <span data-ttu-id="b9dc6-165">パッケージのサポート フレームワーク ファイルを取得します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-165">Get the Package Support Framework files</span></span>
> * <span data-ttu-id="b9dc6-166">パッケージに追加します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-166">Add them to your package</span></span>
> * <span data-ttu-id="b9dc6-167">パッケージ マニフェストの変更</span><span class="sxs-lookup"><span data-stu-id="b9dc6-167">Modify the package manifest</span></span>
> * <span data-ttu-id="b9dc6-168">構成ファイルを作成します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-168">Create a configuration file</span></span>

<span data-ttu-id="b9dc6-169">各タスクを見ていきましょう。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-169">Let's go through each task.</span></span>

### <a name="create-the-package-layout-folder"></a><span data-ttu-id="b9dc6-170">パッケージ レイアウトのフォルダーを作成します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-170">Create the package layout folder</span></span>

<span data-ttu-id="b9dc6-171">.Appx ファイルが既にある場合の内容をパッケージのステージング領域として使用されるレイアウト フォルダーに展開できます。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-171">If you have a .appx file already, you can unpack its contents into a layout folder that will serve as the staging area for your package.</span></span>  <span data-ttu-id="b9dc6-172">これを行う、 **x64 ネイティブのツールのコマンド プロンプト for VS 2017**、または手動で実行可能ファイルの検索パスで SDK bin パス。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-172">You can do this from an **x64 Native Tools Command Prompt for VS 2017**, or manually with the SDK bin path in the executable search path.</span></span>

```
makeappx unpack /p PSFSamplePackage_1.0.60.0_AnyCPU_Debug.appx /d PackageContents

```

<span data-ttu-id="b9dc6-173">これにより、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-173">This will give you something that looks like the following.</span></span>

![パッケージのレイアウト](images/desktop-to-uwp/package_contents.png)

<span data-ttu-id="b9dc6-175">.Appx ファイルをできない場合は、ゼロから、パッケージのフォルダーとファイルを作成できます。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-175">If you don't have a .appx file to start with, you can create the package folder and files from scratch.</span></span>

### <a name="get-the-package-support-framework-files"></a><span data-ttu-id="b9dc6-176">パッケージのサポート フレームワーク ファイルを取得します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-176">Get the Package Support Framework files</span></span>

<span data-ttu-id="b9dc6-177">Visual Studio を使って、PSF Nuget パッケージを取得できます。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-177">You can get the PSF Nuget package by using Visual Studio.</span></span> <span data-ttu-id="b9dc6-178">スタンドアロン Nuget コマンド ライン ツールを使用して取得できます。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-178">You can also get it by using the standalone Nuget command line tool.</span></span>

#### <a name="get-the-package-by-using-visual-studio"></a><span data-ttu-id="b9dc6-179">Visual Studio を使ってパッケージを取得します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-179">Get the package by using Visual Studio</span></span>

<span data-ttu-id="b9dc6-180">Visual Studio で、ソリューションまたはプロジェクト ノードを右クリックし、Nuget パッケージの管理コマンドのいずれかを選択します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-180">In Visual Studio, right-click your solution or project node and pick one of the Manage Nuget Packages commands.</span></span>  <span data-ttu-id="b9dc6-181">検索**Microsoft.PackageSupportFramework** **PSF**上 Nuget.org パッケージを検索します。次に、インストールします。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-181">Search for **Microsoft.PackageSupportFramework** or **PSF** to find the package on Nuget.org. Then, install it.</span></span>

#### <a name="get-the-package-by-using-the-command-line-tool"></a><span data-ttu-id="b9dc6-182">コマンド ライン ツールを使用して、パッケージを取得します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-182">Get the package by using the command line tool</span></span>

<span data-ttu-id="b9dc6-183">この場所から Nuget コマンド ライン ツールのインストール:https://www.nuget.org/downloadsします。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-183">Install the Nuget command line tool from this location: https://www.nuget.org/downloads.</span></span> <span data-ttu-id="b9dc6-184">次に、Nuget コマンドラインからこのコマンドを実行します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-184">Then, from the Nuget command line, run this command:</span></span>

```
nuget install Microsoft.PackageSupportFramework
```

### <a name="add-the-package-support-framework-files-to-your-package"></a><span data-ttu-id="b9dc6-185">サポート フレームワークのパッケージ ファイルをパッケージに追加します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-185">Add the Package Support Framework files to your package</span></span>

<span data-ttu-id="b9dc6-186">パッケージのディレクトリに必要な 32 ビットと 64 ビット PSF Dll と実行可能ファイルを追加します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-186">Add the required 32-bit and 64-bit PSF  DLLs and executable files to the package directory.</span></span> <span data-ttu-id="b9dc6-187">次の表をガイドとして使用してください。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-187">Use the following table as a guide.</span></span> <span data-ttu-id="b9dc6-188">また、必要な任意のランタイム修正が含まれています。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-188">You'll also want to include any runtime fixes that you need.</span></span> <span data-ttu-id="b9dc6-189">ここでは、ファイルのリダイレクトのランタイムの修正プログラムが必要です。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-189">In our example, we need the file redirection runtime fix.</span></span>

| <span data-ttu-id="b9dc6-190">アプリケーションの実行可能ファイルは、x64</span><span class="sxs-lookup"><span data-stu-id="b9dc6-190">Application executable is x64</span></span> | <span data-ttu-id="b9dc6-191">アプリケーションの実行可能ファイルは、x86</span><span class="sxs-lookup"><span data-stu-id="b9dc6-191">Application executable is x86</span></span> |
|-------------------------------|-----------|
| [<span data-ttu-id="b9dc6-192">ShimLauncher64.exe</span><span class="sxs-lookup"><span data-stu-id="b9dc6-192">ShimLauncher64.exe</span></span>](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/ShimLauncher/readme.md) |  [<span data-ttu-id="b9dc6-193">ShimLauncher32.exe</span><span class="sxs-lookup"><span data-stu-id="b9dc6-193">ShimLauncher32.exe</span></span>](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/ShimLauncher/readme.md) |
| [<span data-ttu-id="b9dc6-194">ShimRuntime64.dll</span><span class="sxs-lookup"><span data-stu-id="b9dc6-194">ShimRuntime64.dll</span></span>](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/ShimRuntime/readme.md) | [<span data-ttu-id="b9dc6-195">ShimRuntime32.dll</span><span class="sxs-lookup"><span data-stu-id="b9dc6-195">ShimRuntime32.dll</span></span>](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/ShimRuntime/readme.md) |
| [<span data-ttu-id="b9dc6-196">ShimRunDll64.exe</span><span class="sxs-lookup"><span data-stu-id="b9dc6-196">ShimRunDll64.exe</span></span>](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/ShimRunDll/readme.md) | [<span data-ttu-id="b9dc6-197">ShimRunDll32.exe</span><span class="sxs-lookup"><span data-stu-id="b9dc6-197">ShimRunDll32.exe</span></span>](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/ShimRunDll/readme.md) |

<span data-ttu-id="b9dc6-198">パッケージの内容は次のようになります。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-198">Your package content should now look something like this.</span></span>

![パッケージのバイナリ](images/desktop-to-uwp/package_binaries.png)

### <a name="modify-the-package-manifest"></a><span data-ttu-id="b9dc6-200">パッケージ マニフェストの変更</span><span class="sxs-lookup"><span data-stu-id="b9dc6-200">Modify the package manifest</span></span>

<span data-ttu-id="b9dc6-201">テキスト エディターで、パッケージ マニフェストを開き、設定、`Executable`の属性、`Application`要素 shim ランチャーの実行可能ファイルの名前にします。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-201">Open your package manifest in a text editor, and then set the `Executable` attribute of the `Application` element to the name of the shim launcher executable file.</span></span>  <span data-ttu-id="b9dc6-202">ターゲット アプリケーションのアーキテクチャがわかっている場合は、ShimLauncher32.exe または ShimLauncher64.exe は、適切なバージョンを選択します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-202">If you know the architecture of your target application, select the appropriate version, ShimLauncher32.exe or ShimLauncher64.exe.</span></span>  <span data-ttu-id="b9dc6-203">ない場合は、ShimLauncher32.exe は、どのようなケースで動作します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-203">If not, ShimLauncher32.exe will work in all cases.</span></span>  <span data-ttu-id="b9dc6-204">次に例を示します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-204">Here's an example.</span></span>

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

### <a name="create-a-configuration-file"></a><span data-ttu-id="b9dc6-205">構成ファイルを作成します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-205">Create a configuration file</span></span>

<span data-ttu-id="b9dc6-206">ファイル名を作成``config.json``、そのファイルをパッケージのルート フォルダーに保存します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-206">Create a file name ``config.json``, and save that file to the root folder of your package.</span></span> <span data-ttu-id="b9dc6-207">交換した実行可能ファイルをポイントする config.json ファイルの宣言されているアプリの ID を変更します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-207">Modify the declared app ID of the config.json file to point to the executable that you just replaced.</span></span> <span data-ttu-id="b9dc6-208">プロセスのモニターを使用してから得られる情報を使用して、したりすることことができますも作業ディレクトリの設定しファイルのリダイレクト shim を使用して、読み取り/書き込みを"PSFSampleApp"ディレクトリにパッケージ相対 .log ファイルにリダイレクトします。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-208">Using the knowledge that you gained from using Process Monitor, you can also set the working directory as well as use the file redirection shim to redirect reads/writes to .log files under the package-relative "PSFSampleApp" directory.</span></span>

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
<span data-ttu-id="b9dc6-209">次に示します。 config.json スキーマのためのガイド</span><span class="sxs-lookup"><span data-stu-id="b9dc6-209">Following is a guide for the config.json schema:</span></span>

| <span data-ttu-id="b9dc6-210">配列</span><span class="sxs-lookup"><span data-stu-id="b9dc6-210">Array</span></span> | <span data-ttu-id="b9dc6-211">key</span><span class="sxs-lookup"><span data-stu-id="b9dc6-211">key</span></span> | <span data-ttu-id="b9dc6-212">値</span><span class="sxs-lookup"><span data-stu-id="b9dc6-212">Value</span></span> |
|-------|-----------|-------|
| <span data-ttu-id="b9dc6-213">applications</span><span class="sxs-lookup"><span data-stu-id="b9dc6-213">applications</span></span> | <span data-ttu-id="b9dc6-214">id</span><span class="sxs-lookup"><span data-stu-id="b9dc6-214">id</span></span> |  <span data-ttu-id="b9dc6-215">値を使用して、`Id`の属性、`Application`パッケージ マニフェスト内の要素です。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-215">Use the value of the `Id` attribute of the `Application` element in the package manifest.</span></span> |
| <span data-ttu-id="b9dc6-216">applications</span><span class="sxs-lookup"><span data-stu-id="b9dc6-216">applications</span></span> | <span data-ttu-id="b9dc6-217">実行可能</span><span class="sxs-lookup"><span data-stu-id="b9dc6-217">executable</span></span> | <span data-ttu-id="b9dc6-218">起動する実行可能ファイルへのパッケージ相対パス。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-218">The package-relative path to the executable that you want to start.</span></span> <span data-ttu-id="b9dc6-219">ほとんどの場合、変更する前に、パッケージ マニフェスト ファイルからこの値を取得できます。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-219">In most cases, you can get this value from your package manifest file before you modify it.</span></span> <span data-ttu-id="b9dc6-220">値であること、`Executable`の属性、`Application`要素です。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-220">It's the value of the `Executable` attribute of the `Application` element.</span></span> |
| <span data-ttu-id="b9dc6-221">applications</span><span class="sxs-lookup"><span data-stu-id="b9dc6-221">applications</span></span> | <span data-ttu-id="b9dc6-222">作業ディレクトリ</span><span class="sxs-lookup"><span data-stu-id="b9dc6-222">workingDirectory</span></span> | <span data-ttu-id="b9dc6-223">(省略可能)起動するアプリケーションの作業ディレクトリとして使用するパッケージの相対パス。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-223">(Optional) A package-relative path to use as the working directory of the application that starts.</span></span> <span data-ttu-id="b9dc6-224">この値を設定しない場合、オペレーティング システムを使用して、`System32`アプリケーションの作業ディレクトリとしてディレクトリ。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-224">If you don't set this value, the operating system uses the `System32` directory as the application's working directory.</span></span> |
| <span data-ttu-id="b9dc6-225">プロセス</span><span class="sxs-lookup"><span data-stu-id="b9dc6-225">processes</span></span> | <span data-ttu-id="b9dc6-226">実行可能</span><span class="sxs-lookup"><span data-stu-id="b9dc6-226">executable</span></span> | <span data-ttu-id="b9dc6-227">ほとんどの場合の名前になります、`executable`削除パスとファイルの拡張子を持つ上に構成されています。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-227">In most cases, this will be the name of the `executable` configured above with the path and file extension removed.</span></span> |
| <span data-ttu-id="b9dc6-228">shim</span><span class="sxs-lookup"><span data-stu-id="b9dc6-228">shims</span></span> | <span data-ttu-id="b9dc6-229">dll</span><span class="sxs-lookup"><span data-stu-id="b9dc6-229">dll</span></span> | <span data-ttu-id="b9dc6-230">読み込む shim .appx パッケージ相対パス。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-230">Package-relative path to the shim  .appx  to load.</span></span> |
| <span data-ttu-id="b9dc6-231">shim</span><span class="sxs-lookup"><span data-stu-id="b9dc6-231">shims</span></span> | <span data-ttu-id="b9dc6-232">config</span><span class="sxs-lookup"><span data-stu-id="b9dc6-232">config</span></span> | <span data-ttu-id="b9dc6-233">(省略可能)Shim 配布リストがどのように動作するかを制御します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-233">(Optional) Controls how the shim dl behaves.</span></span> <span data-ttu-id="b9dc6-234">この値の正確な形式は、各 shim が解釈できるようにこの"blob"必要があるように、shim-shim によってごとに異なります。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-234">The exact format of this value varies on a shim-by-shim basis as each shim can interpret this "blob" as it wants.</span></span> |

<span data-ttu-id="b9dc6-235">`applications`、 `processes`、および`shims`キーは、配列です。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-235">The `applications`, `processes`, and `shims` keys are arrays.</span></span> <span data-ttu-id="b9dc6-236">つまり、1 つ以上のアプリケーション、プロセス、および shim DLL を指定する config.json ファイルを使用することができます。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-236">That means that you can use the config.json file to specify more than one application, process, and shim DLL.</span></span>


### <a name="package-and-test-the-app"></a><span data-ttu-id="b9dc6-237">パッケージと、アプリのテスト</span><span class="sxs-lookup"><span data-stu-id="b9dc6-237">Package and Test the App</span></span>

<span data-ttu-id="b9dc6-238">次に、パッケージを作成します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-238">Next, create a package.</span></span>

```
makeappx pack /d PackageContents /p PSFSamplePackageFixup.appx
```

<span data-ttu-id="b9dc6-239">次に、それを署名します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-239">Then, sign it.</span></span>

```
signtool sign /a /v /fd sha256 /f ExportedSigningCertificate.pfx PSFSamplePackageFixup.appx
```

<span data-ttu-id="b9dc6-240">詳細については、[パッケージが署名証明書を作成する方法について説明](https://docs.microsoft.com/en-us/windows/desktop/appxpkg/how-to-create-a-package-signing-certificate)し、 [signtool を使ってパッケージに署名する方法](https://docs.microsoft.com/en-us/windows/desktop/appxpkg/how-to-sign-a-package-using-signtool)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-240">For more information, see [how to create a package signing certificate](https://docs.microsoft.com/en-us/windows/desktop/appxpkg/how-to-create-a-package-signing-certificate) and [how to sign a package using signtool](https://docs.microsoft.com/en-us/windows/desktop/appxpkg/how-to-sign-a-package-using-signtool)</span></span>

<span data-ttu-id="b9dc6-241">PowerShell を使用して、パッケージをインストールします。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-241">Using PowerShell, install the package.</span></span>

>[!NOTE]
> <span data-ttu-id="b9dc6-242">最初にパッケージをアンインストールしてください。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-242">Remember to uninstall the package first.</span></span>

```
powershell Add-AppxPackage .\PSFSamplePackageFixup.appx
```

<span data-ttu-id="b9dc6-243">アプリケーションを実行し、ランタイムの修正プログラムが適用されると、動作を確認します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-243">Run the application and observe the behavior with runtime fix applied.</span></span>  <span data-ttu-id="b9dc6-244">診断と必要に応じて、パッケージ化の手順を繰り返します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-244">Repeat the diagnostic and packaging steps as necessary.</span></span>

### <a name="use-the-trace-shim"></a><span data-ttu-id="b9dc6-245">トレース Shim を使用します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-245">Use the Trace Shim</span></span>

<span data-ttu-id="b9dc6-246">パッケージ化されたアプリケーションの互換性の問題を診断するために別の手法では、トレース Shim を使用します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-246">An alternative technique to diagnosing packaged application compatibility issues is to use the Trace Shim.</span></span> <span data-ttu-id="b9dc6-247">この DLL は、PSF に付属であり、プロセスの監視と同様、アプリの動作の詳細な診断ビューを提供します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-247">This DLL is included with the PSF and provides a detailed diagnostic view of the app's behavior, similar to Process Monitor.</span></span>  <span data-ttu-id="b9dc6-248">アプリケーションの互換性の問題を表示するように設計します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-248">It is specially designed to reveal application compatibility issues.</span></span>  <span data-ttu-id="b9dc6-249">トレース Shim DLL、パッケージを追加、config.json に次のフラグメントを追加し、パッケージ化し、し、アプリケーションをインストールします。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-249">To use the Trace Shim, add the DLL to the package, add the following fragment to your config.json, and then package and install your application.</span></span>

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

<span data-ttu-id="b9dc6-250">既定では、トレース Shim「期待」と考えられるエラーが除外されます。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-250">By default, the Trace Shim filters out failures that might be considered "expected".</span></span>  <span data-ttu-id="b9dc6-251">たとえば、アプリケーションは無条件に既に存在するかどうか、結果を無視して確認することがなく、ファイルを削除しよう可能性があります。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-251">For example, applications might try to unconditionally delete a file without checking to see if it already exists, ignoring the result.</span></span> <span data-ttu-id="b9dc6-252">サインアウトして、いくつかの予期しないエラーをフィルター処理を取得する可能性があります残念ながら上の結果は、ファイルシステム関数からすべてのエラーを受信するオプトイン上記の例では、これがあります。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-252">This has the unfortunate consequence that some unexpected failures might get filtered out, so in the above example, we opt to receive all failures from filesystem functions.</span></span> <span data-ttu-id="b9dc6-253">これはそれより前に Config.txt ファイルから読み取る失敗のメッセージ「ファイルが見つかりません」とからわかっているためです。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-253">We do this because we know from before that the attempt to read from the Config.txt file fails with the message "file not found".</span></span> <span data-ttu-id="b9dc6-254">これは、頻繁に確認されたでは、一般に予想するものと想定したエラーです。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-254">This is a failure that is frequently observed and not generally assumed to be unexpected.</span></span> <span data-ttu-id="b9dc6-255">実際には、のみに予期しないエラーをフィルタ リングとその後にフォールバックするすべてのエラーも識別できない問題がある場合は、最初に可能性の最適なを勧めします。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-255">In practice it's likely best to start out filtering only to unexpected failures, and then falling back to all failures if there's an issue that still can't be identified.</span></span>

<span data-ttu-id="b9dc6-256">既定では、トレース Shim からの出力を取得、アタッチされたデバッガーに送信されます。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-256">By default, the output from the Trace Shim gets sent to the attached debugger.</span></span> <span data-ttu-id="b9dc6-257">この例では、します、デバッガーをアタッチすることは、代わりにプログラムを使用して[デバッグ表示](https://docs.microsoft.com/en-us/sysinternals/downloads/debugview)sysinternals 出力を表示します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-257">For this example, we aren't going to attach a debugger, and will instead use the [DebugView](https://docs.microsoft.com/en-us/sysinternals/downloads/debugview) program from SysInternals to view its output.</span></span> <span data-ttu-id="b9dc6-258">アプリを実行すると、わかります同じエラー前とに、同じランタイムの修正プログラムから、マイクロソフトをポイントするとします。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-258">After running the app, we can see the same failures as before, which would point us towards the same runtime fixes.</span></span>

![TraceShim ファイルが見つかりません](images/desktop-to-uwp/traceshim_filenotfound.png)

![TraceShim アクセスが拒否されました](images/desktop-to-uwp/traceshim_accessdenied.png)

## <a name="debug-extend-or-create-a-runtime-fix"></a><span data-ttu-id="b9dc6-261">デバッグ、延長、または実行時の修正プログラムの作成</span><span class="sxs-lookup"><span data-stu-id="b9dc6-261">Debug, extend, or create a runtime fix</span></span>

<span data-ttu-id="b9dc6-262">デバッグ ランタイムの修正プログラム、拡張ランタイムの修正プログラムを最初から作成に Visual Studio を使用することができます。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-262">You can use Visual Studio to debug a runtime fix, extend a runtime fix, or create one from scratch.</span></span> <span data-ttu-id="b9dc6-263">これらの操作を成功させる必要があります。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-263">You'll need to do these things to be successful.</span></span>

> [!div class="checklist"]
> * <span data-ttu-id="b9dc6-264">パッケージ プロジェクトを追加します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-264">Add a packaging project</span></span>
> * <span data-ttu-id="b9dc6-265">ランタイムの修正プログラムのプロジェクトに追加します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-265">Add project for the runtime fix</span></span>
> * <span data-ttu-id="b9dc6-266">プロジェクトを追加する実行可能ファイルの Shim ランチャーを起動します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-266">Add a project that starts the Shim Launcher executable</span></span>
> * <span data-ttu-id="b9dc6-267">パッケージ プロジェクトを構成します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-267">Configure the packaging project</span></span>

<span data-ttu-id="b9dc6-268">完了したら、ソリューションにはこのようになります。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-268">When you're done, your solution will look something like this.</span></span>

![完成したソリューション](images/desktop-to-uwp/runtime-fix-project-structure.png)

<span data-ttu-id="b9dc6-270">この例では、各プロジェクトを見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-270">Let's look at each project in this example.</span></span>

| <span data-ttu-id="b9dc6-271">プロジェクト</span><span class="sxs-lookup"><span data-stu-id="b9dc6-271">Project</span></span> | <span data-ttu-id="b9dc6-272">目的</span><span class="sxs-lookup"><span data-stu-id="b9dc6-272">Purpose</span></span> |
|-------|-----------|
| <span data-ttu-id="b9dc6-273">DesktopApplicationPackage</span><span class="sxs-lookup"><span data-stu-id="b9dc6-273">DesktopApplicationPackage</span></span> | <span data-ttu-id="b9dc6-274">このプロジェクトは、 [Windows アプリケーション パッケージ プロジェクト](desktop-to-uwp-packaging-dot-net.md)に基づいており、出力、MSIX パッケージ。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-274">This project is based on the [Windows Application Packaging project](desktop-to-uwp-packaging-dot-net.md) and it outputs the the MSIX package.</span></span> |
| <span data-ttu-id="b9dc6-275">Runtimefix</span><span class="sxs-lookup"><span data-stu-id="b9dc6-275">Runtimefix</span></span> | <span data-ttu-id="b9dc6-276">これは、実行時の修正プログラムとして機能する 1 つまたは複数の代替関数が含まれている C++ Dynamic-Linked ライブラリ プロジェクトです。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-276">This is a C++ Dynamic-Linked Library project that contains one or more replacement functions that serve as the runtime fix.</span></span> |
| <span data-ttu-id="b9dc6-277">ShimLauncher</span><span class="sxs-lookup"><span data-stu-id="b9dc6-277">ShimLauncher</span></span> | <span data-ttu-id="b9dc6-278">これは、C++ 空のプロジェクトです。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-278">This is C++ Empty Project.</span></span> <span data-ttu-id="b9dc6-279">このプロジェクトは、パッケージのサポート フレームワークのランタイム配布可能なファイルを収集する場所です。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-279">This project is a place to collect the runtime distributable files of the Package Support Framework.</span></span> <span data-ttu-id="b9dc6-280">実行可能ファイルを出力します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-280">It outputs an executable file.</span></span> <span data-ttu-id="b9dc6-281">その実行可能ファイルは、ソリューションを起動するときに実行する最初のものです。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-281">That executable is the first thing that runs when you start the solution.</span></span> |
| <span data-ttu-id="b9dc6-282">WinFormsDesktopApplication</span><span class="sxs-lookup"><span data-stu-id="b9dc6-282">WinFormsDesktopApplication</span></span> | <span data-ttu-id="b9dc6-283">このプロジェクトには、デスクトップ アプリケーションのソース コードが含まれています。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-283">This project contains the source code of a desktop application.</span></span> |

<span data-ttu-id="b9dc6-284">これらの種類のプロジェクトのすべてを含む完全なサンプルを見ると、 [PSFSample](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/samples/PSFSample/)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-284">To look at a complete sample that contains all of these types of projects, see [PSFSample](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/samples/PSFSample/).</span></span>

<span data-ttu-id="b9dc6-285">作成して、ソリューション内の各プロジェクトを構成する手順について説明しましょう。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-285">Let's walk through the steps to create and configure each of these projects in your solution.</span></span>


### <a name="create-a-package-solution"></a><span data-ttu-id="b9dc6-286">パッケージのソリューションを作成します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-286">Create a package solution</span></span>

<span data-ttu-id="b9dc6-287">デスクトップ アプリケーションのソリューションがない場合は、Visual Studio で新しい**空のソリューション**を作成します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-287">If you don't already have a solution for your desktop application, create a new **Blank Solution** in Visual Studio.</span></span>

![空のソリューション](images/desktop-to-uwp/blank-solution.png)

<span data-ttu-id="b9dc6-289">あるすべてのアプリケーション プロジェクトに追加することもできます。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-289">You may also want to add any application projects you have.</span></span>

### <a name="add-a-packaging-project"></a><span data-ttu-id="b9dc6-290">パッケージ プロジェクトを追加します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-290">Add a packaging project</span></span>

<span data-ttu-id="b9dc6-291">**Windows アプリケーション パッケージ プロジェクト**がまだしていない場合は、1 つを作成し、ソリューションに追加します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-291">If you don't already have a **Windows Application Packaging Project**, create one and add it to your solution.</span></span>

![パッケージ プロジェクト テンプレート](images/desktop-to-uwp/package-project-template.png)

<span data-ttu-id="b9dc6-293">Windows アプリケーション パッケージ プロジェクトの詳細については、 [Visual Studio を使って、アプリケーションのパッケージ](desktop-to-uwp-packaging-dot-net.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-293">For more information on Windows Application Packaging project, see [Package your application by using Visual Studio](desktop-to-uwp-packaging-dot-net.md).</span></span>

<span data-ttu-id="b9dc6-294">**ソリューション エクスプ ローラー**では、パッケージ プロジェクトを右クリックして、選択**を編集**、およびし、プロジェクト ファイルの末尾に追加。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-294">In **Solution Explorer**, right-click the packaging project, select **Edit**, and then add this to the bottom of the project file:</span></span>

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

### <a name="add-project-for-the-runtime-fix"></a><span data-ttu-id="b9dc6-295">ランタイムの修正プログラムのプロジェクトに追加します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-295">Add project for the runtime fix</span></span>

<span data-ttu-id="b9dc6-296">**ダイナミック リンク ライブラリ (DLL)** の C++ プロジェクトをソリューションに追加します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-296">Add a C++ **Dynamic-Link Library (DLL)** project to the solution.</span></span>

![ランタイム ライブラリの修正](images/desktop-to-uwp/runtime-fix-library.png)

<span data-ttu-id="b9dc6-298">[プロジェクト]、[**プロパティ**を右クリックします。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-298">Right-click the that project, and then choose **Properties**.</span></span>

<span data-ttu-id="b9dc6-299">プロパティ ページで、**標準的な C++ 言語**のフィールドを検索し、そのフィールドの横にあるドロップダウン リストを選択して、 **ISO C 17 標準 (//std:c では 17)** オプションです。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-299">In the property pages, find the **C++ Language Standard** field, and then in the drop-down list next to that field, select the **ISO C++17 Standard (/std:c++17)** option.</span></span>

![ISO 17 オプション](images/desktop-to-uwp/iso-option.png)

<span data-ttu-id="b9dc6-301">そのプロジェクトを右クリックし、コンテキスト メニューで、 **Nuget パッケージの管理**オプションを選択します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-301">Right-click that project, and then in the context menu, choose the **Manage Nuget Packages** option.</span></span> <span data-ttu-id="b9dc6-302">**すべて**のまたは**nuget.org\*\*\*\*パッケージ ソース**オプションが設定されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-302">Ensure that the **Package source** option is set to **All** or **nuget.org**.</span></span>

<span data-ttu-id="b9dc6-303">次にそのフィールドの設定アイコンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-303">Click the settings icon next that field.</span></span>

<span data-ttu-id="b9dc6-304">*PSF*の検索を \* Nuget パッケージをし、このプロジェクトにインストールします。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-304">Search for the *PSF*\* Nuget package, and then install it for this project.</span></span>

![nuget パッケージ](images/desktop-to-uwp/psf-package.png)

<span data-ttu-id="b9dc6-306">既存のランタイム修正プログラムを拡張またはデバッグする場合は、このガイドの[ランタイムの修正プログラムを検索](#find)のセクションで説明したガイダンスを使用して、取得したランタイムの修正プログラム ファイルを追加します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-306">If you want to debug or extend an existing runtime fix, add the runtime fix files that you obtained by using the guidance described in the [Find a runtime fix](#find) section of this guide.</span></span>

<span data-ttu-id="b9dc6-307">新しい修正プログラムを作成する場合は、追加しないでください何もこのプロジェクトにまだだけです。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-307">If you intend to create a brand new fix, don't add anything to this project just yet.</span></span> <span data-ttu-id="b9dc6-308">お手伝いしますこのガイドの後半では、このプロジェクトに適切なファイルを追加します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-308">We'll help you add the right files to this project later in this guide.</span></span> <span data-ttu-id="b9dc6-309">ここでは、ソリューションの設定が引き続きされます。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-309">For now, we'll continue setting up your solution.</span></span>

### <a name="add-a-project-that-starts-the-shim-launcher-executable"></a><span data-ttu-id="b9dc6-310">プロジェクトを追加する実行可能ファイルの Shim ランチャーを起動します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-310">Add a project that starts the Shim Launcher executable</span></span>

<span data-ttu-id="b9dc6-311">C**空のプロジェクト**のプロジェクトをソリューションに追加します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-311">Add a C++ **Empty Project** project to the solution.</span></span>

![空のプロジェクト](images/desktop-to-uwp/blank-app.png)

<span data-ttu-id="b9dc6-313">このプロジェクトを前のセクションで説明されている同じガイダンスを使用して、 **PSF** Nuget パッケージを追加します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-313">Add the **PSF** Nuget package to this project by using the same guidance described in the previous section.</span></span>

<span data-ttu-id="b9dc6-314">開くと、**全般**設定] ページで、プロジェクトのプロパティ ページ**ターゲット名**プロパティに設定``ShimLauncher32``または``ShimLauncher64``によっては、アプリケーションのアーキテクチャ。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-314">Open the property pages for the project, and in the **General** settings page, set the **Target Name** property to ``ShimLauncher32`` or ``ShimLauncher64`` depending on the architecture of your application.</span></span>

![shim ランチャー リファレンス](images/desktop-to-uwp/shim-exe-reference.png)

<span data-ttu-id="b9dc6-316">ランタイムの修正プログラム プロジェクトへの参照をプロジェクトをソリューションに追加します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-316">Add a project reference to the runtime fix project in your solution.</span></span>

![ランタイムの修正プログラムのリファレンス](images/desktop-to-uwp/reference-fix.png)

<span data-ttu-id="b9dc6-318">参照を右クリックし、[**プロパティ**] ウィンドウで、これらの値を適用します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-318">Right-click the reference, and then in the **Properties** window, apply these values.</span></span>

| <span data-ttu-id="b9dc6-319">プロパティ</span><span class="sxs-lookup"><span data-stu-id="b9dc6-319">Property</span></span> | <span data-ttu-id="b9dc6-320">値</span><span class="sxs-lookup"><span data-stu-id="b9dc6-320">Value</span></span> |
|-------|-----------|-------|
| <span data-ttu-id="b9dc6-321">ローカル コピーします。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-321">Copy local</span></span> | <span data-ttu-id="b9dc6-322">True</span><span class="sxs-lookup"><span data-stu-id="b9dc6-322">True</span></span> |
| <span data-ttu-id="b9dc6-323">ローカル サテライト アセンブリをコピーします。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-323">Copy Local Satellite Assemblies</span></span> | <span data-ttu-id="b9dc6-324">True</span><span class="sxs-lookup"><span data-stu-id="b9dc6-324">True</span></span> |
| <span data-ttu-id="b9dc6-325">参照アセンブリの出力</span><span class="sxs-lookup"><span data-stu-id="b9dc6-325">Reference Assembly Output</span></span> | <span data-ttu-id="b9dc6-326">True</span><span class="sxs-lookup"><span data-stu-id="b9dc6-326">True</span></span> |
| <span data-ttu-id="b9dc6-327">リンク ライブラリの依存関係</span><span class="sxs-lookup"><span data-stu-id="b9dc6-327">Link Library Dependencies</span></span> | <span data-ttu-id="b9dc6-328">False</span><span class="sxs-lookup"><span data-stu-id="b9dc6-328">False</span></span> |
| <span data-ttu-id="b9dc6-329">リンク ライブラリの依存関係の入力</span><span class="sxs-lookup"><span data-stu-id="b9dc6-329">Link Library Dependency Inputs</span></span> | <span data-ttu-id="b9dc6-330">False</span><span class="sxs-lookup"><span data-stu-id="b9dc6-330">False</span></span> |

### <a name="configure-the-packaging-project"></a><span data-ttu-id="b9dc6-331">パッケージ プロジェクトを構成します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-331">Configure the packaging project</span></span>

<span data-ttu-id="b9dc6-332">パッケージ プロジェクトで、**[アプリケーション]** フォルダーを右クリックして **[参照の追加]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-332">In the packaging project, right-click the **Applications** folder, and then choose **Add Reference**.</span></span>

![プロジェクト参照の追加](images/desktop-to-uwp/add-reference-packaging-project.png)

<span data-ttu-id="b9dc6-334">Shim ランチャー プロジェクトとデスクトップ アプリケーション プロジェクトを選択し、 **[ok]** ボタンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-334">Choose the shim launcher project and your desktop application project, and then choose the **OK** button.</span></span>

![デスクトップ プロジェクト](images/desktop-to-uwp/package-project-references.png)

>[!NOTE]
> <span data-ttu-id="b9dc6-336">アプリケーションに、ソース コードがあるない場合は、shim ランチャー プロジェクトを選ぶだけです。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-336">If you don't have the source code to your application, just choose the shim launcher project.</span></span> <span data-ttu-id="b9dc6-337">構成ファイルを作成するときに、実行可能ファイルを参照する方法紹介します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-337">We'll show you how to reference your executable when you create a configuration file.</span></span>

<span data-ttu-id="b9dc6-338">**アプリケーション**] ノードで、shim ランチャー アプリケーションを右クリックし、**エントリ ポイントとして設定**を選択します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-338">In the **Applications** node, right-click the shim launcher application, and then choose **Set as Entry Point**.</span></span>

![エントリ ポイントの設定](images/desktop-to-uwp/set-startup-project.png)

<span data-ttu-id="b9dc6-340">という名前のファイルを追加``config.json``、パッケージ プロジェクトにコピーし、ファイルに次の json テキストを貼り付けます。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-340">Add a file named ``config.json`` to your packaging project, then, copy and paste the following json text into the file.</span></span> <span data-ttu-id="b9dc6-341">**コンテンツ**を**パッケージ アクション**プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-341">Set the **Package Action** property to **Content**.</span></span>

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
<span data-ttu-id="b9dc6-342">各キーの値を提供します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-342">Provide a value for each key.</span></span> <span data-ttu-id="b9dc6-343">次の表をガイドとして使用します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-343">Use this table as a guide.</span></span>

| <span data-ttu-id="b9dc6-344">配列</span><span class="sxs-lookup"><span data-stu-id="b9dc6-344">Array</span></span> | <span data-ttu-id="b9dc6-345">key</span><span class="sxs-lookup"><span data-stu-id="b9dc6-345">key</span></span> | <span data-ttu-id="b9dc6-346">値</span><span class="sxs-lookup"><span data-stu-id="b9dc6-346">Value</span></span> |
|-------|-----------|-------|
| <span data-ttu-id="b9dc6-347">applications</span><span class="sxs-lookup"><span data-stu-id="b9dc6-347">applications</span></span> | <span data-ttu-id="b9dc6-348">id</span><span class="sxs-lookup"><span data-stu-id="b9dc6-348">id</span></span> |  <span data-ttu-id="b9dc6-349">値を使用して、`Id`の属性、`Application`パッケージ マニフェスト内の要素です。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-349">Use the value of the `Id` attribute of the `Application` element in the package manifest.</span></span> |
| <span data-ttu-id="b9dc6-350">applications</span><span class="sxs-lookup"><span data-stu-id="b9dc6-350">applications</span></span> | <span data-ttu-id="b9dc6-351">実行可能</span><span class="sxs-lookup"><span data-stu-id="b9dc6-351">executable</span></span> | <span data-ttu-id="b9dc6-352">起動する実行可能ファイルへのパッケージ相対パス。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-352">The package-relative path to the executable that you want to start.</span></span> <span data-ttu-id="b9dc6-353">ほとんどの場合、変更する前に、パッケージ マニフェスト ファイルからこの値を取得できます。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-353">In most cases, you can get this value from your package manifest file before you modify it.</span></span> <span data-ttu-id="b9dc6-354">値であること、`Executable`の属性、`Application`要素です。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-354">It's the value of the `Executable` attribute of the `Application` element.</span></span> |
| <span data-ttu-id="b9dc6-355">applications</span><span class="sxs-lookup"><span data-stu-id="b9dc6-355">applications</span></span> | <span data-ttu-id="b9dc6-356">作業ディレクトリ</span><span class="sxs-lookup"><span data-stu-id="b9dc6-356">workingDirectory</span></span> | <span data-ttu-id="b9dc6-357">(省略可能)起動するアプリケーションの作業ディレクトリとして使用するパッケージの相対パス。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-357">(Optional) A package-relative path to use as the working directory of the application that starts.</span></span> <span data-ttu-id="b9dc6-358">この値を設定しない場合、オペレーティング システムを使用して、`System32`アプリケーションの作業ディレクトリとしてディレクトリ。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-358">If you don't set this value, the operating system uses the `System32` directory as the application's working directory.</span></span> |
| <span data-ttu-id="b9dc6-359">プロセス</span><span class="sxs-lookup"><span data-stu-id="b9dc6-359">processes</span></span> | <span data-ttu-id="b9dc6-360">実行可能</span><span class="sxs-lookup"><span data-stu-id="b9dc6-360">executable</span></span> | <span data-ttu-id="b9dc6-361">ほとんどの場合の名前になります、`executable`削除パスとファイルの拡張子を持つ上に構成されています。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-361">In most cases, this will be the name of the `executable` configured above with the path and file extension removed.</span></span> |
| <span data-ttu-id="b9dc6-362">shim</span><span class="sxs-lookup"><span data-stu-id="b9dc6-362">shims</span></span> | <span data-ttu-id="b9dc6-363">dll</span><span class="sxs-lookup"><span data-stu-id="b9dc6-363">dll</span></span> | <span data-ttu-id="b9dc6-364">Shim を読み込む DLL のパッケージ相対パス。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-364">Package-relative path to the shim DLL to load.</span></span> |
| <span data-ttu-id="b9dc6-365">shim</span><span class="sxs-lookup"><span data-stu-id="b9dc6-365">shims</span></span> | <span data-ttu-id="b9dc6-366">config</span><span class="sxs-lookup"><span data-stu-id="b9dc6-366">config</span></span> | <span data-ttu-id="b9dc6-367">(省略可能)Shim 配布リストがどのように動作するかを制御します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-367">(Optional) Controls how the shim dl behaves.</span></span> <span data-ttu-id="b9dc6-368">この値の正確な形式は、各 shim が解釈できるようにこの"blob"必要があるように、shim-shim によってごとに異なります。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-368">The exact format of this value varies on a shim-by-shim basis as each shim can interpret this "blob" as it wants.</span></span> |

<span data-ttu-id="b9dc6-369">完了したら、``config.json``ファイルは次のようになります。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-369">When you're done, your ``config.json`` file will look something like this.</span></span>

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
> <span data-ttu-id="b9dc6-370">`applications`、 `processes`、および`shims`キーは、配列です。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-370">The `applications`, `processes`, and `shims` keys are arrays.</span></span> <span data-ttu-id="b9dc6-371">つまり、1 つ以上のアプリケーション、プロセス、および shim DLL を指定する config.json ファイルを使用することができます。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-371">That means that you can use the config.json file to specify more than one application, process, and shim DLL.</span></span>

### <a name="debug-a-runtime-fix"></a><span data-ttu-id="b9dc6-372">ランタイムの修正プログラムをデバッグします。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-372">Debug a runtime fix</span></span>

<span data-ttu-id="b9dc6-373">Visual Studio で f5 キーを押してデバッガーを起動します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-373">In Visual Studio, press F5 to start the debugger.</span></span>  <span data-ttu-id="b9dc6-374">最初に起動することは、次に、ターゲット デスクトップ アプリケーションを起動する shim ランチャー アプリケーションです。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-374">The first thing that starts is the shim launcher application, which in turn, starts your target desktop application.</span></span>  <span data-ttu-id="b9dc6-375">ターゲットのデスクトップ アプリケーションをデバッグするには、手動で**デバッグ**を選択してデスクトップ アプリケーションのプロセスにアタッチする必要があります->**プロセスにアタッチ**し、アプリケーションのプロセスを選択します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-375">To debug the target desktop application, you'll have to manually attach to the desktop application process by choosing **Debug**->**Attach to Process**, and then selecting the application process.</span></span> <span data-ttu-id="b9dc6-376">ネイティブ ランタイム修正 DLL を持つ .NET アプリケーションのデバッグを許可するには、マネージとネイティブ コードの種類 (混在モードのデバッグ) を選択します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-376">To permit the debugging of a .NET application with a native runtime fix DLL, select managed and native code types (mixed mode debugging).</span></span>  

<span data-ttu-id="b9dc6-377">これ設定したら、デスクトップ アプリケーション コードとランタイムの修正プログラムのプロジェクトで数行のコードの横にブレークポイントを設定できます。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-377">Once you've set this up, you can set break points next to lines of code in the desktop application code and the runtime fix project.</span></span> <span data-ttu-id="b9dc6-378">アプリケーションに、ソース コードがあるない場合、ランタイムの修正プログラムのプロジェクトで数行のコードの横にあるブレークポイントを設定することができます。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-378">If you don't have the source code to your application, you'll be able to set break points only next to lines of code in your runtime fix project.</span></span>

>[!NOTE]
> <span data-ttu-id="b9dc6-379">Visual Studio を使用する最も簡単な開発、エクスペリエンスをデバッグするには、いくつかの制限がある、このガイドでは、後でについて説明します他のデバッグ手法を適用することができます。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-379">While Visual Studio gives you the simplest development and debugging experience, there are some limitations, so later in this guide, we'll discuss other debugging techniques that you can apply.</span></span>

## <a name="create-a-runtime-fix"></a><span data-ttu-id="b9dc6-380">ランタイムの修正プログラムを作成します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-380">Create a runtime fix</span></span>

<span data-ttu-id="b9dc6-381">問題を解決する場合、代替関数を作成し、構成データを含む新しいランタイムの修正プログラムを作成することを解決する、ランタイムがない場合意味のあります。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-381">If there isn't yet a runtime fix for the issue that you want to resolve, you can create a new runtime fix by writing replacement functions and including any configuration data that makes sense.</span></span> <span data-ttu-id="b9dc6-382">各部分を見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-382">Let's look at each part.</span></span>

### <a name="replacement-functions"></a><span data-ttu-id="b9dc6-383">代替機能</span><span class="sxs-lookup"><span data-stu-id="b9dc6-383">Replacement functions</span></span>

<span data-ttu-id="b9dc6-384">最初に、どの関数の呼び出しは失敗 MSIX コンテナー内で、アプリケーションが実行されている場合を特定します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-384">First, identify which function calls fail when your application runs in an MSIX container.</span></span> <span data-ttu-id="b9dc6-385">次に、代替関数を呼び出す代わりに、ランタイム マネージャーたいを作成できます。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-385">Then, you can create replacement functions that you'd like the runtime manager to call instead.</span></span> <span data-ttu-id="b9dc6-386">これにより、関数の実装を最新のランタイム環境の規則に準拠している動作に置き換えることです。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-386">This gives you an opportunity to replace the implementation of a function with behavior that conforms to the rules of the modern runtime environment.</span></span>

<span data-ttu-id="b9dc6-387">Visual Studio では、このガイドで既に作成したランタイム修正プロジェクトを開きます。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-387">In Visual Studio, open the runtime fix project that you created earlier in this guide.</span></span>

<span data-ttu-id="b9dc6-388">宣言、``SHIM_DEFINE_EXPORTS``マクロ用の include ステートメントを追加し、`shim_framework.h`それぞれの上部にします。CPP ファイルは、実行時の修正プログラムの関数を追加します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-388">Declare the ``SHIM_DEFINE_EXPORTS`` macro and then add a include statement for the `shim_framework.h` at the top of each .CPP file where you intend to add the functions of your runtime fix.</span></span>

```c++
#define SHIM_DEFINE_EXPORTS
#include <shim_framework.h>
```
>[!IMPORTANT]
><span data-ttu-id="b9dc6-389">確認、`SHIM_DEFINE_EXPORTS`マクロがインクルード ステートメントの前に表示されます。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-389">Make sure that the `SHIM_DEFINE_EXPORTS` macro appears before the include statement.</span></span>

<span data-ttu-id="b9dc6-390">同じ関数のシグネチャを持つ関数を作成しているが動作を変更します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-390">Create a function that has the same signature of the function who's behavior you want to modify.</span></span> <span data-ttu-id="b9dc6-391">置換する関数の例を以下に示します、`MessageBoxW`関数です。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-391">Here's an example function that replaces the `MessageBoxW` function.</span></span>

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

<span data-ttu-id="b9dc6-392">呼び出し`DECLARE_SHIM`マップ、`MessageBoxW`新しい代替関数に機能します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-392">The call to `DECLARE_SHIM` maps the `MessageBoxW` function to your new replacement function.</span></span> <span data-ttu-id="b9dc6-393">アプリケーションが呼び出すしようとしたとき、`MessageBoxW`関数が呼び出さ関数代わりにします。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-393">When your application attempts to call the `MessageBoxW` function, it will call the replacement function instead.</span></span>

#### <a name="protect-against-recursive-calls-to-functions-in-runtime-fixes"></a><span data-ttu-id="b9dc6-394">ランタイムの修正プログラムの関数に再帰呼び出しからの保護します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-394">Protect against recursive calls to functions in runtime fixes</span></span>

<span data-ttu-id="b9dc6-395">適用することが必要に応じて、`reentrancy_guard`を再帰的なランタイムの修正プログラムでの関数の呼び出しを保護する関数の種類。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-395">You can optionally apply the `reentrancy_guard` type to your functions that protect against recursive calls to functions in runtime fixes.</span></span>

<span data-ttu-id="b9dc6-396">代替の関数を作成するなど、`CreateFile`関数です。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-396">For example, you might produce a replacement function for the `CreateFile` function.</span></span> <span data-ttu-id="b9dc6-397">実装を呼び出すことがあります、`CopyFile`が、実装、`CopyFile`関数を呼び出すことがあります、`CreateFile`関数です。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-397">Your implementation might call the `CopyFile` function, but the implementation of the `CopyFile` function might call the `CreateFile` function.</span></span> <span data-ttu-id="b9dc6-398">これは、無限再帰サイクルへの呼び出しのする可能性があります、`CreateFile`関数です。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-398">This may lead to an infinite recursive cycle of calls to the `CreateFile` function.</span></span>

<span data-ttu-id="b9dc6-399">ついて詳しくは`reentrancy_guard` [authoring.md](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/Authoring.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-399">For more information on `reentrancy_guard` see [authoring.md](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/Authoring.md)</span></span>

### <a name="configuration-data"></a><span data-ttu-id="b9dc6-400">構成データ</span><span class="sxs-lookup"><span data-stu-id="b9dc6-400">Configuration data</span></span>

<span data-ttu-id="b9dc6-401">構成データ、ランタイムの修正プログラムを追加する場合は、追加することを検討してください、``config.json``します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-401">If you want to add configuration data to your runtime fix, consider adding it to the ``config.json``.</span></span> <span data-ttu-id="b9dc6-402">使用することにより、`ShimQueryCurrentDllConfig`にそのデータを簡単に解析します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-402">That way, you can use the `ShimQueryCurrentDllConfig` to easily parse that data.</span></span> <span data-ttu-id="b9dc6-403">この例では、その構成ファイルからのブール値と文字列の値を解析します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-403">This example parses a boolean and string value from that configuration file.</span></span>

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

## <a name="other-debugging-techniques"></a><span data-ttu-id="b9dc6-404">その他のデバッグ手法</span><span class="sxs-lookup"><span data-stu-id="b9dc6-404">Other debugging techniques</span></span>

<span data-ttu-id="b9dc6-405">Visual Studio を使用すると、最も簡単な開発およびデバッグ エクスペリエンスは制限があります。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-405">While Visual Studio gives you the simplest development and debugging experience, there are some limitations.</span></span>

<span data-ttu-id="b9dc6-406">まず、F5 デバッグと、.appx パッケージからインストールするのではなく、パッケージ レイアウト フォルダー パスからルーズ ファイルを展開することによって、アプリケーションが実行されます。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-406">First, F5 debugging runs the application by deploying loose files from the package layout folder path, rather than installing from a .appx package.</span></span>  <span data-ttu-id="b9dc6-407">レイアウト フォルダー通常はありませんと同じセキュリティの制限はインストールされているパッケージのフォルダーとして。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-407">The layout folder typically does not have the same security restrictions as an installed package folder.</span></span> <span data-ttu-id="b9dc6-408">その結果、にくいかもしれませんランタイムの修正プログラムを適用する前にパッケージのパスへのアクセス拒否エラーを再現することもできます。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-408">As a result, it may not be possible to reproduce package path access denial errors prior to applying a runtime fix.</span></span>

<span data-ttu-id="b9dc6-409">この問題に対処するには、f5 キーを押してルーズ ファイルの展開ではなく、.appx パッケージの展開を使用します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-409">To address this issue, use .appx package deployment rather than F5 loose file deployment.</span></span>  <span data-ttu-id="b9dc6-410">.Appx パッケージ ファイルを作成するには、既に説明した、Windows SDK から[MakeAppx](https://docs.microsoft.com/en-us/windows/desktop/appxpkg/make-appx-package--makeappx-exe-)ユーティリティを使用します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-410">To create a .appx package file, use the [MakeAppx](https://docs.microsoft.com/en-us/windows/desktop/appxpkg/make-appx-package--makeappx-exe-) utility from the Windows SDK, as described above.</span></span> <span data-ttu-id="b9dc6-411">またはから、Visual Studio 内アプリケーション プロジェクト ノードを右クリックし、**ストア**を選択して->**アプリ パッケージの作成**します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-411">Or, from within Visual Studio, right-click your application project node and select **Store**->**Create App Packages**.</span></span>

<span data-ttu-id="b9dc6-412">Visual Studio の別の問題は、デバッガーが起動されたすべての子プロセスにアタッチするための組み込みサポートがないことです。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-412">Another issue with Visual Studio is that it does not have built-in support for attaching to any child processes launched by the debugger.</span></span>   <span data-ttu-id="b9dc6-413">Visual Studio によって起動後が手動で接続され、ターゲット アプリケーションのスタートアップ パス内のロジックをデバッグが困難になります。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-413">This makes it difficult to debug logic in the startup path of the target application, which must be manually attached by Visual Studio after launch.</span></span>

<span data-ttu-id="b9dc6-414">この問題に対処するには、使用子プロセスをサポートしているデバッガーをアタッチします。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-414">To address this issue, use a debugger that supports child process attach.</span></span>  <span data-ttu-id="b9dc6-415">一般に、ターゲット アプリケーションにジャスト イン タイム (JIT) デバッガーをアタッチすることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-415">Note that it is generally not possible to attach a just-in-time (JIT) debugger to the target application.</span></span>  <span data-ttu-id="b9dc6-416">これは、ほとんど JIT 技法 ImageFileExecutionOptions のレジストリ キーを使用して、対象のアプリの代わりにデバッガーを起動するためです。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-416">This is because most JIT techniques involve launching the debugger in place of the target app, via the ImageFileExecutionOptions registry key.</span></span>  <span data-ttu-id="b9dc6-417">ターゲット アプリに ShimRuntime.dll を挿入するために使用 ShimLauncher.exe detouring メカニズムが損なわれるためです。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-417">This defeats the detouring mechanism used by ShimLauncher.exe to inject ShimRuntime.dll into the target app.</span></span>  <span data-ttu-id="b9dc6-418">WinDbg、 [Debugging Tools for Windows](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/index)に含まれているし、 [Windows SDK](https://developer.microsoft.com/en-US/windows/downloads/windows-10-sdk)から取得したサポート子プロセスをアタッチします。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-418">WinDbg, included in the [Debugging Tools for Windows](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/index), and obtained from the [Windows SDK](https://developer.microsoft.com/en-US/windows/downloads/windows-10-sdk), supports child process attach.</span></span>  <span data-ttu-id="b9dc6-419">サポート直接[起動して UWP アプリをデバッグ](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/debugging-a-uwp-app-using-windbg#span-idlaunchinganddebuggingauwpappspanspan-idlaunchinganddebuggingauwpappspanspan-idlaunchinganddebuggingauwpappspanlaunching-and-debugging-a-uwp-app)します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-419">It also now supports directly [launching and debugging a UWP app](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/debugging-a-uwp-app-using-windbg#span-idlaunchinganddebuggingauwpappspanspan-idlaunchinganddebuggingauwpappspanspan-idlaunchinganddebuggingauwpappspanlaunching-and-debugging-a-uwp-app).</span></span>

<span data-ttu-id="b9dc6-420">子プロセスとしてターゲット アプリケーションの起動をデバッグするには、開始``WinDbg``します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-420">To debug target application startup as a child process, start ``WinDbg``.</span></span>

```
windbg.exe -plmPackage PSFSampleWithFixup_1.0.59.0_x86__7s220nvg1hg3m -plmApp PSFSample
```

<span data-ttu-id="b9dc6-421">``WinDbg``プロンプト、子のデバッグを有効にして適切なブレークポイントを設定します。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-421">At the ``WinDbg`` prompt, enable child debugging and set appropriate breakpoints.</span></span>

```
.childdbg 1
g
```
<span data-ttu-id="b9dc6-422">(ターゲット アプリケーションが開始され、デバッガーにするまで実行)</span><span class="sxs-lookup"><span data-stu-id="b9dc6-422">(execute until target application starts and breaks into the debugger)</span></span>

```
sxe ld fixup.dll
g
```
<span data-ttu-id="b9dc6-423">(修正の DLL が読み込まれるまで実行されません)</span><span class="sxs-lookup"><span data-stu-id="b9dc6-423">(execute until the fixup DLL is loaded)</span></span>

```
bp ...
```

>[!NOTE]
> <span data-ttu-id="b9dc6-424">[PLMDebug](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/plmdebug)では、起動時には、アプリにデバッガーをアタッチするも使用できるされ、 [Debugging Tools for Windows](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/index)にも含まれています。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-424">[PLMDebug](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/plmdebug) can be also used to attach a debugger to an app upon launch, and is also included in the [Debugging Tools for Windows](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/index).</span></span>  <span data-ttu-id="b9dc6-425">ただし、WinDbg によって提供されるようになりました直接サポートよりも複雑です。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-425">However, it is more complex to use than the direct support now provided by WinDbg.</span></span>

## <a name="support-and-feedback"></a><span data-ttu-id="b9dc6-426">サポートとフィードバック</span><span class="sxs-lookup"><span data-stu-id="b9dc6-426">Support and feedback</span></span>

**<span data-ttu-id="b9dc6-427">質問に対する回答を見つける</span><span class="sxs-lookup"><span data-stu-id="b9dc6-427">Find answers to your questions</span></span>**

<span data-ttu-id="b9dc6-428">ご質問がある場合は、</span><span class="sxs-lookup"><span data-stu-id="b9dc6-428">Have questions?</span></span> <span data-ttu-id="b9dc6-429">Stack Overflow でお問い合わせください。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-429">Ask us on Stack Overflow.</span></span> <span data-ttu-id="b9dc6-430">Microsoft のチームでは、これらの[タグ](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge)をチェックしています。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-430">Our team monitors these [tags](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge).</span></span> <span data-ttu-id="b9dc6-431">[こちら](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D)から質問することもできます。</span><span class="sxs-lookup"><span data-stu-id="b9dc6-431">You can also ask us [here](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D).</span></span>
