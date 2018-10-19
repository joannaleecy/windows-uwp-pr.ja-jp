---
author: rido-min
Description: This guide explains how to configure your Visual Studio Solution to optimize the application binaries with native images.
Search.Product: eADQiWindows 10XVcnh
title: ネイティブ イメージを使って、.NET デスクトップ アプリを最適化します。
ms.author: normesta
ms.date: 06/11/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10 では、ネイティブ イメージ コンパイラ
ms.localizationpriority: medium
ms.openlocfilehash: d98b576fb51a8f9507802796ab359d0d00d21998
ms.sourcegitcommit: e16c9845b52d5bd43fc02bbe92296a9682d96926
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/19/2018
ms.locfileid: "4960162"
---
# <a name="optimize-your-net-desktop-apps-with-native-images"></a><span data-ttu-id="db3d3-103">ネイティブ イメージを使って、.NET デスクトップ アプリを最適化します。</span><span class="sxs-lookup"><span data-stu-id="db3d3-103">Optimize your .NET Desktop apps with native images</span></span>

> [!NOTE]
> <span data-ttu-id="db3d3-104">一部の情報はリリース前の製品に関する事項であり、正式版がリリースされるまでに大幅に変更される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="db3d3-104">Some information relates to pre-released product which may be substantially modified before it’s commercially released.</span></span> <span data-ttu-id="db3d3-105">ここに記載された情報について、Microsoft は明示または黙示を問わずいかなる保証をするものでもありません。</span><span class="sxs-lookup"><span data-stu-id="db3d3-105">Microsoft makes no warranties, express or implied, with respect to the information provided here.</span></span>

<span data-ttu-id="db3d3-106">事前、バイナリをコンパイルすることによって、.NET Framework アプリケーションの起動時間を向上できます。</span><span class="sxs-lookup"><span data-stu-id="db3d3-106">You can improve the startup time of your .NET Framework application by pre-compiling your binaries.</span></span> <span data-ttu-id="db3d3-107">大規模なアプリケーションをパッケージ化して、Windows ストアを通じて配布することで、このテクノロジを使用できます。</span><span class="sxs-lookup"><span data-stu-id="db3d3-107">You can use this technology on large applications that you package and distribute through the Windows Store.</span></span> <span data-ttu-id="db3d3-108">場合によっては、お客様には、20% のパフォーマンスの向上を確認しました。</span><span class="sxs-lookup"><span data-stu-id="db3d3-108">In some cases, we've observed a 20% performance improvement.</span></span> <span data-ttu-id="db3d3-109">[技術概要](https://github.com/dotnet/coreclr/blob/master/Documentation/botr/readytorun-overview.md)では、このテクノロジについて詳しく知るすることができます。</span><span class="sxs-lookup"><span data-stu-id="db3d3-109">You can learn more about this technology in the [technical overview](https://github.com/dotnet/coreclr/blob/master/Documentation/botr/readytorun-overview.md).</span></span>

<span data-ttu-id="db3d3-110">[NuGet パッケージ](https://www.nuget.org/packages/Microsoft.DotNet.Framework.NativeImageCompiler)としてネイティブ イメージ コンパイラのプレビュー バージョンをリリースしましたしました。</span><span class="sxs-lookup"><span data-stu-id="db3d3-110">We've released a preview version of the native image compiler as a [NuGet package](https://www.nuget.org/packages/Microsoft.DotNet.Framework.NativeImageCompiler).</span></span> <span data-ttu-id="db3d3-111">このパッケージを適用するには、.NET Framework バージョン 4.6.2 をターゲットとする .NET Framework アプリケーションにまたはそれ以降。</span><span class="sxs-lookup"><span data-stu-id="db3d3-111">You can apply this package to any .NET Framework application that targets the .NET Framework version 4.6.2 or later.</span></span> <span data-ttu-id="db3d3-112">このパッケージは、アプリケーションで使用されるすべてのバイナリにネイティブのペイロードが含まれている post ビルド ステップを追加します。</span><span class="sxs-lookup"><span data-stu-id="db3d3-112">This package adds a post build step that includes a native payload to all the binaries used by your application.</span></span> <span data-ttu-id="db3d3-113">この最適化されたペイロードは、アプリケーションが実行される .NET 4.7.2 で以降の以前のバージョンの MSIL コードがまだ読み込み中に読み込まれます。</span><span class="sxs-lookup"><span data-stu-id="db3d3-113">This optimized payload will be loaded when the application runs in .NET 4.7.2 and above while previous versions will still load the MSIL code.</span></span>

<span data-ttu-id="db3d3-114">[Windows 10 April 2018 update](https://blogs.windows.com/windowsexperience/2018/04/30/how-to-get-the-windows-10-april-2018-update/)では、 [.NET framework 4.7.2](https://blogs.msdn.microsoft.com/dotnet/2018/04/30/announcing-the-net-framework-4-7-2/)が含まれます。</span><span class="sxs-lookup"><span data-stu-id="db3d3-114">The [.NET framework 4.7.2](https://blogs.msdn.microsoft.com/dotnet/2018/04/30/announcing-the-net-framework-4-7-2/) is included in the [Windows 10 April 2018 update](https://blogs.windows.com/windowsexperience/2018/04/30/how-to-get-the-windows-10-april-2018-update/).</span></span> <span data-ttu-id="db3d3-115">Windows 7 + および Windows Server 2008 R2 + を実行している PC で、このバージョンの .NET Framework をインストールすることもできます。</span><span class="sxs-lookup"><span data-stu-id="db3d3-115">You can also install this version of the .NET Framework on PC's that run Windows 7+ and Windows Server 2008 R2+.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="db3d3-116">Windows アプリケーション パッケージ プロジェクトをパッケージ化アプリケーションのネイティブ イメージを作成する場合は、プロジェクトのターゲット プラットフォームの最小バージョンを Windows Anniversary Update に設定することを確認してください。</span><span class="sxs-lookup"><span data-stu-id="db3d3-116">If you want to produce native images for your application packaged by  the Windows Application Packaging project, make sure to set the Target Platform Minimum version of the project to the Windows Anniversary Update.</span></span>

## <a name="how-to-produce-native-images"></a><span data-ttu-id="db3d3-117">ネイティブ イメージを作成する方法</span><span class="sxs-lookup"><span data-stu-id="db3d3-117">How to produce native images</span></span>

<span data-ttu-id="db3d3-118">プロジェクトを構成する手順に従います。</span><span class="sxs-lookup"><span data-stu-id="db3d3-118">Follow these instructions to configure your projects.</span></span>

1. <span data-ttu-id="db3d3-119">4.6.2 としてまたは上にターゲット フレームワークを構成します。</span><span class="sxs-lookup"><span data-stu-id="db3d3-119">Configure the target framework as 4.6.2 or above</span></span>

2. <span data-ttu-id="db3d3-120">ターゲット プラットフォームを x86 または x64 として構成します。</span><span class="sxs-lookup"><span data-stu-id="db3d3-120">Configure the target platform as x86 or x64</span></span> 

3. <span data-ttu-id="db3d3-121">NuGet パッケージを追加します。</span><span class="sxs-lookup"><span data-stu-id="db3d3-121">Add the NuGet packages.</span></span>

4. <span data-ttu-id="db3d3-122">リリース ビルドを作成します。</span><span class="sxs-lookup"><span data-stu-id="db3d3-122">Create a Release Build.</span></span>

## <a name="configure-the-target-framework-as-462-or-above"></a><span data-ttu-id="db3d3-123">4.6.2 としてまたは上にターゲット フレームワークを構成します。</span><span class="sxs-lookup"><span data-stu-id="db3d3-123">Configure the target framework as 4.6.2 or above</span></span>

<span data-ttu-id="db3d3-124">.NET Framework 4.6.2 をターゲットにプロジェクトを構成する必要があります、.NET Framework 4.6.2 開発ツールまたはそれ以降。</span><span class="sxs-lookup"><span data-stu-id="db3d3-124">To configure your project to target .NET Framework 4.6.2 you will need the .NET Framework 4.6.2 development tools or newer.</span></span> <span data-ttu-id="db3d3-125">これらのツールは、.NET デスクトップ開発ワークロードでオプション コンポーネントとして Visual Studio インストーラーを利用します。</span><span class="sxs-lookup"><span data-stu-id="db3d3-125">These tools are available through the Visual Studio installer as optional components under the .NET desktop development workload:</span></span>

![.NET 4.6.2 インストール開発ツール](images/desktop-to-uwp/install-4.6.2-devpack.png)

<span data-ttu-id="db3d3-127">またはから .NET 開発者パックを取得できます。[https://www.microsoft.com/net/download/visual-studio-sdks](https://www.microsoft.com/net/download/visual-studio-sdks)</span><span class="sxs-lookup"><span data-stu-id="db3d3-127">Alternatively, you can get the .NET developer packs from: [https://www.microsoft.com/net/download/visual-studio-sdks](https://www.microsoft.com/net/download/visual-studio-sdks)</span></span>

## <a name="configure-the-target-platform-as-x86-or-x64"></a><span data-ttu-id="db3d3-128">ターゲット プラットフォームを x86 または x64 として構成します。</span><span class="sxs-lookup"><span data-stu-id="db3d3-128">Configure the target platform as x86 or x64</span></span>

<span data-ttu-id="db3d3-129">ネイティブ イメージ コンパイラは、特定のプラットフォーム用のコードを最適化します。</span><span class="sxs-lookup"><span data-stu-id="db3d3-129">The native image compiler optimizes the code for a given platform.</span></span> <span data-ttu-id="db3d3-130">これを使用するには、x86 または x64 など特定の 1 つのプラットフォームを対象としたアプリケーションを構成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="db3d3-130">To use it, you need to configure your application to target one specific platform such as x86 or x64.</span></span>

<span data-ttu-id="db3d3-131">複数のプロジェクトをソリューションがある場合のみ、エントリ ポイント プロジェクト (ほとんどの場合、実行可能ファイルを生成する) を x86 または x64 としてコンパイルがあります。</span><span class="sxs-lookup"><span data-stu-id="db3d3-131">If you have multiple projects in your solution, only the entry point project (most likely the project that produces an executable file) has to be compiled as x86 or x64.</span></span> <span data-ttu-id="db3d3-132">メイン プロジェクトから参照されるその他のバイナリが AnyCPU としてコンパイルされている場合でも、メイン プロジェクトで指定されたアーキテクチャで処理されます。</span><span class="sxs-lookup"><span data-stu-id="db3d3-132">Additional binaries referenced from the main project will be processed with the architecture specified in the main project, even if they are compiled as AnyCPU.</span></span>

<span data-ttu-id="db3d3-133">プロジェクトを構成するには。</span><span class="sxs-lookup"><span data-stu-id="db3d3-133">To configure your project:</span></span>

1. <span data-ttu-id="db3d3-134">ソリューションを右クリックし、 **Configuration Manager**を選択します。</span><span class="sxs-lookup"><span data-stu-id="db3d3-134">Right-click your solution, and then select **Configuration Manager**.</span></span>

2. <span data-ttu-id="db3d3-135">選択 **< 新規.>** **プラットフォーム**ドロップダウン メニューで、実行可能ファイルを生成するプロジェクトの名前の横にあります。</span><span class="sxs-lookup"><span data-stu-id="db3d3-135">Select **<New ..>** in the **Platform** dropdown menu beside the name of the project that produces your executable file.</span></span>

3. <span data-ttu-id="db3d3-136">**新しいプロジェクトのプラットフォーム**] ダイアログ ボックスで、**設定のコピー元**のドロップダウン リストを**任意の CPU**に設定されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="db3d3-136">In the **New Project Platform** dialog box, make sure that the **Copy Settings from** dropdown list is set to **Any CPU**.</span></span>

![X86 を構成します。](images/desktop-to-uwp/configure-x86.png)

<span data-ttu-id="db3d3-138">この手順を繰り返します`Release/x64`x64 を生成する場合のバイナリ。</span><span class="sxs-lookup"><span data-stu-id="db3d3-138">Repeat this step for `Release/x64` if you want produce x64 binaries.</span></span>

>[!IMPORTANT]
> <span data-ttu-id="db3d3-139">ネイティブ イメージ コンパイラでは、AnyCPU 構成はサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="db3d3-139">AnyCPU configuration is not supported by the native image compiler.</span></span>

## <a name="add-the-nuget-packages"></a><span data-ttu-id="db3d3-140">NuGet パッケージを追加します。</span><span class="sxs-lookup"><span data-stu-id="db3d3-140">Add the NuGet packages</span></span>

<span data-ttu-id="db3d3-141">ネイティブ イメージ コンパイラは、実行可能ファイルを生成する Visual Studio プロジェクトを追加する必要がある NuGet パッケージとして提供されます。</span><span class="sxs-lookup"><span data-stu-id="db3d3-141">The native image compiler is provided as a NuGet package that you need to add to the Visual Studio project that produces the executable file.</span></span> <span data-ttu-id="db3d3-142">これは、通常、Windows フォームや WPF プロジェクトです。</span><span class="sxs-lookup"><span data-stu-id="db3d3-142">This is typically your Windows Forms or WPF project.</span></span> <span data-ttu-id="db3d3-143">そのためには、次の PowerShell コマンドを使用します。</span><span class="sxs-lookup"><span data-stu-id="db3d3-143">Use this PowerShell command to do that.</span></span>

```PS
PM> Install-Package Microsoft.DotNet.Framework.NativeImageCompiler -Version 0.0.1-prerelease-00002  -PRE
```

> [!NOTE]
> <span data-ttu-id="db3d3-144">プレビュー パッケージは、一覧にないとして NuGet.org で公開されます。</span><span class="sxs-lookup"><span data-stu-id="db3d3-144">The preview packages are published in NuGet.org as unlisted.</span></span> <span data-ttu-id="db3d3-145">閲覧 NuGet.org または Visual Studio でパッケージ マネージャーの UI を使用して、それらを検出されません。</span><span class="sxs-lookup"><span data-stu-id="db3d3-145">You won’t find them by browsing NuGet.org or by using the Package Manager UI in Visual Studio.</span></span> <span data-ttu-id="db3d3-146">パッケージ マネージャー コンソールから、インストールするただし、いつ別のコンピューターから復元します。</span><span class="sxs-lookup"><span data-stu-id="db3d3-146">However, you can install them from the Package Manager Console, and when you restoring from a different machine.</span></span> <span data-ttu-id="db3d3-147">加えますパッケージ完全にアクセスするとき、最初のプレビューでないバージョンを公開しています。</span><span class="sxs-lookup"><span data-stu-id="db3d3-147">We'll make the packages fully accessible when we publish the first non-preview version.</span></span>

## <a name="create-a-release-build"></a><span data-ttu-id="db3d3-148">リリース ビルドを作成します。</span><span class="sxs-lookup"><span data-stu-id="db3d3-148">Create a Release Build</span></span>

<span data-ttu-id="db3d3-149">NuGet パッケージは、リリース ビルドするための追加のツールを実行するプロジェクトを構成します。</span><span class="sxs-lookup"><span data-stu-id="db3d3-149">The NuGet package configures the project to run an additional tool for release builds.</span></span> <span data-ttu-id="db3d3-150">このツールは、同じバイナリにネイティブ コードを追加します。</span><span class="sxs-lookup"><span data-stu-id="db3d3-150">This tool adds the native code to the same binaries.</span></span>
<span data-ttu-id="db3d3-151">ツールのバイナリが処理されることを確認するには、ビルドなど、このいずれかのメッセージが含まれているかどうかを確認する出力を確認できます。</span><span class="sxs-lookup"><span data-stu-id="db3d3-151">To verify that the tool has processed the binaries you can review the build output to make sure it includes a message such as this one:</span></span>

```
Native image obj\x86\Release\\R2R\DesktopApp1.exe generated successfully.
```

## <a name="faq"></a><span data-ttu-id="db3d3-152">FAQ</span><span class="sxs-lookup"><span data-stu-id="db3d3-152">FAQ</span></span>

**<span data-ttu-id="db3d3-153">Q します。</span><span class="sxs-lookup"><span data-stu-id="db3d3-153">Q.</span></span> <span data-ttu-id="db3d3-154">.NET Framework 4.7.2 なしのマシンでは、新しいバイナリが使用かどうか。</span><span class="sxs-lookup"><span data-stu-id="db3d3-154">Do the new binaries work on machines without .NET Framework 4.7.2?</span></span>**

<span data-ttu-id="db3d3-155">A.</span><span class="sxs-lookup"><span data-stu-id="db3d3-155">A.</span></span> <span data-ttu-id="db3d3-156">最適化されたバイナリのメリットは、機能強化 .NET Framework 4.7.2 で実行されている場合。</span><span class="sxs-lookup"><span data-stu-id="db3d3-156">Optimized binaries will benefit from the improvements when running with .NET Framework 4.7.2.</span></span> <span data-ttu-id="db3d3-157">以前のバージョンの .NET フレームワークを実行しているクライアントは、MSIL の最適化されていないコードをバイナリから読み込まれます。</span><span class="sxs-lookup"><span data-stu-id="db3d3-157">Clients that run previous .NET framework versions will load the non-optimized MSIL code from the binary.</span></span>

**<span data-ttu-id="db3d3-158">Q します。</span><span class="sxs-lookup"><span data-stu-id="db3d3-158">Q.</span></span> <span data-ttu-id="db3d3-159">フィードバックや問題を報告する方法はかどうか。</span><span class="sxs-lookup"><span data-stu-id="db3d3-159">How can I provide feedback or report issues?</span></span>**

<span data-ttu-id="db3d3-160">A.</span><span class="sxs-lookup"><span data-stu-id="db3d3-160">A.</span></span> <span data-ttu-id="db3d3-161">Visual Studio 2017 でフィードバック ツールを使用して、問題を報告します。</span><span class="sxs-lookup"><span data-stu-id="db3d3-161">Report an issue by using the Feedback tool in Visual Studio 2017.</span></span> <span data-ttu-id="db3d3-162">[詳細について](https://docs.microsoft.com/visualstudio/ide/how-to-report-a-problem-with-visual-studio-2017)はです。</span><span class="sxs-lookup"><span data-stu-id="db3d3-162">[More information](https://docs.microsoft.com/visualstudio/ide/how-to-report-a-problem-with-visual-studio-2017).</span></span>

**<span data-ttu-id="db3d3-163">Q します。</span><span class="sxs-lookup"><span data-stu-id="db3d3-163">Q.</span></span> <span data-ttu-id="db3d3-164">ネイティブ イメージを既存のバイナリに追加の影響は何ですか。</span><span class="sxs-lookup"><span data-stu-id="db3d3-164">What’s the impact of adding the native image to existing binaries?</span></span>**

<span data-ttu-id="db3d3-165">A.</span><span class="sxs-lookup"><span data-stu-id="db3d3-165">A.</span></span> <span data-ttu-id="db3d3-166">最適化されたバイナリには、最終的なファイルを大きくするマネージとネイティブ コードが含まれています。</span><span class="sxs-lookup"><span data-stu-id="db3d3-166">The optimized binaries contain the managed and native code, making the final files greater.</span></span>

**<span data-ttu-id="db3d3-167">Q します。</span><span class="sxs-lookup"><span data-stu-id="db3d3-167">Q.</span></span> <span data-ttu-id="db3d3-168">このテクノロジを使用してバイナリをリリースすることができますか。</span><span class="sxs-lookup"><span data-stu-id="db3d3-168">Can I release binaries using this technology?</span></span>**

<span data-ttu-id="db3d3-169">A.</span><span class="sxs-lookup"><span data-stu-id="db3d3-169">A.</span></span> <span data-ttu-id="db3d3-170">このバージョンには、今すぐに使用できる Live 移動のライセンスが含まれています。</span><span class="sxs-lookup"><span data-stu-id="db3d3-170">This version includes a Go Live license that you can use today.</span></span>
