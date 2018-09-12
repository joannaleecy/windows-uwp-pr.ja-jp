---
author: rido-min
Description: This guide explains how to configure your Visual Studio Solution to optimize the application binaries with native images.
Search.Product: eADQiWindows 10XVcnh
title: ネイティブ イメージでデスクトップの .NET アプリケーションを最適化します。
ms.author: normesta
ms.date: 06/11/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: 10、ネイティブの windows イメージのコンパイラ
ms.localizationpriority: medium
ms.openlocfilehash: d98b576fb51a8f9507802796ab359d0d00d21998
ms.sourcegitcommit: 2a63ee6770413bc35ace09b14f56b60007be7433
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3931122"
---
# <a name="optimize-your-net-desktop-apps-with-native-images"></a><span data-ttu-id="3f064-103">ネイティブ イメージでデスクトップの .NET アプリケーションを最適化します。</span><span class="sxs-lookup"><span data-stu-id="3f064-103">Optimize your .NET Desktop apps with native images</span></span>

> [!NOTE]
> <span data-ttu-id="3f064-104">一部の情報はリリース前の製品に関する事項であり、正式版がリリースされるまでに大幅に変更される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="3f064-104">Some information relates to pre-released product which may be substantially modified before it’s commercially released.</span></span> <span data-ttu-id="3f064-105">ここに記載された情報について、Microsoft は明示または黙示を問わずいかなる保証をするものでもありません。</span><span class="sxs-lookup"><span data-stu-id="3f064-105">Microsoft makes no warranties, express or implied, with respect to the information provided here.</span></span>

<span data-ttu-id="3f064-106">バイナリをプリコンパイルして、.NET Framework アプリケーションの起動時間を改善できます。</span><span class="sxs-lookup"><span data-stu-id="3f064-106">You can improve the startup time of your .NET Framework application by pre-compiling your binaries.</span></span> <span data-ttu-id="3f064-107">このテクノロジを使用するには、大規模なアプリケーションをパッケージ化し、Windows ストアを使用して配布するのです。</span><span class="sxs-lookup"><span data-stu-id="3f064-107">You can use this technology on large applications that you package and distribute through the Windows Store.</span></span> <span data-ttu-id="3f064-108">場合によっては、20% のパフォーマンスの向上は見します。</span><span class="sxs-lookup"><span data-stu-id="3f064-108">In some cases, we've observed a 20% performance improvement.</span></span> <span data-ttu-id="3f064-109">[技術概要](https://github.com/dotnet/coreclr/blob/master/Documentation/botr/readytorun-overview.md)には、このテクノロジの詳細については。</span><span class="sxs-lookup"><span data-stu-id="3f064-109">You can learn more about this technology in the [technical overview](https://github.com/dotnet/coreclr/blob/master/Documentation/botr/readytorun-overview.md).</span></span>

<span data-ttu-id="3f064-110">[NuGet パッケージ](https://www.nuget.org/packages/Microsoft.DotNet.Framework.NativeImageCompiler)として、イメージのネイティブ コンパイラのプレビュー バージョンをリリースしましたしました。</span><span class="sxs-lookup"><span data-stu-id="3f064-110">We've released a preview version of the native image compiler as a [NuGet package](https://www.nuget.org/packages/Microsoft.DotNet.Framework.NativeImageCompiler).</span></span> <span data-ttu-id="3f064-111">4.6.2 のバージョンの.NET Framework を対象とする任意の.NET Framework アプリケーションにこのパッケージを適用することができますまたはそれ以降です。</span><span class="sxs-lookup"><span data-stu-id="3f064-111">You can apply this package to any .NET Framework application that targets the .NET Framework version 4.6.2 or later.</span></span> <span data-ttu-id="3f064-112">このパッケージでは、ネイティブ アプリケーションで使用されるすべてのバイナリ ペイロードを含む投稿のビルド ステップを追加します。</span><span class="sxs-lookup"><span data-stu-id="3f064-112">This package adds a post build step that includes a native payload to all the binaries used by your application.</span></span> <span data-ttu-id="3f064-113">この最適化されたペイロードは、アプリケーションが実行される .net 4.7.2 と以前のバージョンの MSIL コードがまだ読み込み中に読み込まれます。</span><span class="sxs-lookup"><span data-stu-id="3f064-113">This optimized payload will be loaded when the application runs in .NET 4.7.2 and above while previous versions will still load the MSIL code.</span></span>

<span data-ttu-id="3f064-114">[10 年 2018年 4 月の Windows を更新](https://blogs.windows.com/windowsexperience/2018/04/30/how-to-get-the-windows-10-april-2018-update/)するには、 [.NET framework 4.7.2](https://blogs.msdn.microsoft.com/dotnet/2018/04/30/announcing-the-net-framework-4-7-2/)が含まれます。</span><span class="sxs-lookup"><span data-stu-id="3f064-114">The [.NET framework 4.7.2](https://blogs.msdn.microsoft.com/dotnet/2018/04/30/announcing-the-net-framework-4-7-2/) is included in the [Windows 10 April 2018 update](https://blogs.windows.com/windowsexperience/2018/04/30/how-to-get-the-windows-10-april-2018-update/).</span></span> <span data-ttu-id="3f064-115">PC 上の Windows 7 + と Windows Server 2008 R2 を実行している.NET Framework のこのバージョンをインストールすることもできます。</span><span class="sxs-lookup"><span data-stu-id="3f064-115">You can also install this version of the .NET Framework on PC's that run Windows 7+ and Windows Server 2008 R2+.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="3f064-116">Windows アプリケーションのパッケージ化プロジェクトによってパッケージ化され、アプリケーションのネイティブ イメージを生成する場合は、記念日の Windows 更新プログラムをプロジェクトのターゲット プラットフォームの最小バージョンを設定することを確認してください。</span><span class="sxs-lookup"><span data-stu-id="3f064-116">If you want to produce native images for your application packaged by  the Windows Application Packaging project, make sure to set the Target Platform Minimum version of the project to the Windows Anniversary Update.</span></span>

## <a name="how-to-produce-native-images"></a><span data-ttu-id="3f064-117">ネイティブ イメージを生成する方法</span><span class="sxs-lookup"><span data-stu-id="3f064-117">How to produce native images</span></span>

<span data-ttu-id="3f064-118">プロジェクトを構成するのには、次の手順に従います。</span><span class="sxs-lookup"><span data-stu-id="3f064-118">Follow these instructions to configure your projects.</span></span>

1. <span data-ttu-id="3f064-119">4.6.2 として以上のターゲット フレームワークを構成します。</span><span class="sxs-lookup"><span data-stu-id="3f064-119">Configure the target framework as 4.6.2 or above</span></span>

2. <span data-ttu-id="3f064-120">X86 または x64 としてターゲット ・ プラットフォームを構成します。</span><span class="sxs-lookup"><span data-stu-id="3f064-120">Configure the target platform as x86 or x64</span></span> 

3. <span data-ttu-id="3f064-121">NuGet パッケージを追加します。</span><span class="sxs-lookup"><span data-stu-id="3f064-121">Add the NuGet packages.</span></span>

4. <span data-ttu-id="3f064-122">リリース ビルドを作成します。</span><span class="sxs-lookup"><span data-stu-id="3f064-122">Create a Release Build.</span></span>

## <a name="configure-the-target-framework-as-462-or-above"></a><span data-ttu-id="3f064-123">4.6.2 として以上のターゲット フレームワークを構成します。</span><span class="sxs-lookup"><span data-stu-id="3f064-123">Configure the target framework as 4.6.2 or above</span></span>

<span data-ttu-id="3f064-124">4.6.2 の.NET Framework を対象とするプロジェクトを構成するのには.NET Framework 4.6.2 開発ツールが必要、またはそれ以降です。</span><span class="sxs-lookup"><span data-stu-id="3f064-124">To configure your project to target .NET Framework 4.6.2 you will need the .NET Framework 4.6.2 development tools or newer.</span></span> <span data-ttu-id="3f064-125">これらのツールは、.NET デスクトップ開発の作業負荷の下のオプションのコンポーネントとして Visual Studio インストーラーを使用します。</span><span class="sxs-lookup"><span data-stu-id="3f064-125">These tools are available through the Visual Studio installer as optional components under the .NET desktop development workload:</span></span>

![.NET 4.6.2 をインストールする開発ツール](images/desktop-to-uwp/install-4.6.2-devpack.png)

<span data-ttu-id="3f064-127">またはから .NET 開発者のパックを入手できます。[https://www.microsoft.com/net/download/visual-studio-sdks](https://www.microsoft.com/net/download/visual-studio-sdks)</span><span class="sxs-lookup"><span data-stu-id="3f064-127">Alternatively, you can get the .NET developer packs from: [https://www.microsoft.com/net/download/visual-studio-sdks](https://www.microsoft.com/net/download/visual-studio-sdks)</span></span>

## <a name="configure-the-target-platform-as-x86-or-x64"></a><span data-ttu-id="3f064-128">X86 または x64 としてターゲット ・ プラットフォームを構成します。</span><span class="sxs-lookup"><span data-stu-id="3f064-128">Configure the target platform as x86 or x64</span></span>

<span data-ttu-id="3f064-129">イメージのネイティブ コンパイラでは、特定のプラットフォーム用のコードを最適化します。</span><span class="sxs-lookup"><span data-stu-id="3f064-129">The native image compiler optimizes the code for a given platform.</span></span> <span data-ttu-id="3f064-130">使用するには、x86 または x64 など特定の 1 つのプラットフォームを対象としたアプリケーションを構成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3f064-130">To use it, you need to configure your application to target one specific platform such as x86 or x64.</span></span>

<span data-ttu-id="3f064-131">ソリューション内の複数のプロジェクトにある場合は、エントリ ポイントのプロジェクトのみ (ほとんどの場合、実行可能ファイルを生成するプロジェクト) は x86 または x64 としてコンパイルするのには。</span><span class="sxs-lookup"><span data-stu-id="3f064-131">If you have multiple projects in your solution, only the entry point project (most likely the project that produces an executable file) has to be compiled as x86 or x64.</span></span> <span data-ttu-id="3f064-132">AnyCPU としてコンパイルする場合でも、メインのプロジェクトでは、指定されたアーキテクチャを持つメイン プロジェクトから参照されているその他のバイナリが処理されます。</span><span class="sxs-lookup"><span data-stu-id="3f064-132">Additional binaries referenced from the main project will be processed with the architecture specified in the main project, even if they are compiled as AnyCPU.</span></span>

<span data-ttu-id="3f064-133">プロジェクトを構成します。</span><span class="sxs-lookup"><span data-stu-id="3f064-133">To configure your project:</span></span>

1. <span data-ttu-id="3f064-134">ソリューションを右クリックし、[**構成マネージャー**。</span><span class="sxs-lookup"><span data-stu-id="3f064-134">Right-click your solution, and then select **Configuration Manager**.</span></span>

2. <span data-ttu-id="3f064-135">**を選択して < 新規.>** 、実行可能ファイルを作成するプロジェクトの名前の横にある**プラットフォーム**のドロップダウン ・ メニューです。</span><span class="sxs-lookup"><span data-stu-id="3f064-135">Select **<New ..>** in the **Platform** dropdown menu beside the name of the project that produces your executable file.</span></span>

3. <span data-ttu-id="3f064-136">**新しいプロジェクト プラットフォーム**] ダイアログ ボックスで**設定のコピー元**のドロップ ダウン リストが **[Any CPU**] に設定されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="3f064-136">In the **New Project Platform** dialog box, make sure that the **Copy Settings from** dropdown list is set to **Any CPU**.</span></span>

![X86 を構成します。](images/desktop-to-uwp/configure-x86.png)

<span data-ttu-id="3f064-138">この手順を繰り返して`Release/x64`x64 を生成する場合のバイナリです。</span><span class="sxs-lookup"><span data-stu-id="3f064-138">Repeat this step for `Release/x64` if you want produce x64 binaries.</span></span>

>[!IMPORTANT]
> <span data-ttu-id="3f064-139">AnyCPU 構成は、ネイティブ イメージのコンパイラではサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="3f064-139">AnyCPU configuration is not supported by the native image compiler.</span></span>

## <a name="add-the-nuget-packages"></a><span data-ttu-id="3f064-140">NuGet パッケージを追加します。</span><span class="sxs-lookup"><span data-stu-id="3f064-140">Add the NuGet packages</span></span>

<span data-ttu-id="3f064-141">ネイティブ イメージのコンパイラは、実行可能ファイルを生成する Visual Studio プロジェクトに追加する必要がある NuGet パッケージとして提供されます。</span><span class="sxs-lookup"><span data-stu-id="3f064-141">The native image compiler is provided as a NuGet package that you need to add to the Visual Studio project that produces the executable file.</span></span> <span data-ttu-id="3f064-142">これは通常、Windows フォームまたは WPF プロジェクトです。</span><span class="sxs-lookup"><span data-stu-id="3f064-142">This is typically your Windows Forms or WPF project.</span></span> <span data-ttu-id="3f064-143">そのためには、次の PowerShell コマンドを使用します。</span><span class="sxs-lookup"><span data-stu-id="3f064-143">Use this PowerShell command to do that.</span></span>

```PS
PM> Install-Package Microsoft.DotNet.Framework.NativeImageCompiler -Version 0.0.1-prerelease-00002  -PRE
```

> [!NOTE]
> <span data-ttu-id="3f064-144">プレビュー パッケージは、一覧にないとして、NuGet.org で発行されます。</span><span class="sxs-lookup"><span data-stu-id="3f064-144">The preview packages are published in NuGet.org as unlisted.</span></span> <span data-ttu-id="3f064-145">NuGet.org を参照して、または Visual Studio のパッケージ マネージャーの UI を使用しては検出されません。</span><span class="sxs-lookup"><span data-stu-id="3f064-145">You won’t find them by browsing NuGet.org or by using the Package Manager UI in Visual Studio.</span></span> <span data-ttu-id="3f064-146">パッケージ マネージャー コンソールからインストールするとすると別のコンピューターから復元します。</span><span class="sxs-lookup"><span data-stu-id="3f064-146">However, you can install them from the Package Manager Console, and when you restoring from a different machine.</span></span> <span data-ttu-id="3f064-147">しましょうパッケージ完全にアクセス可能な最初のプレビューでないバージョンを公開するとします。</span><span class="sxs-lookup"><span data-stu-id="3f064-147">We'll make the packages fully accessible when we publish the first non-preview version.</span></span>

## <a name="create-a-release-build"></a><span data-ttu-id="3f064-148">リリース ビルドを作成します。</span><span class="sxs-lookup"><span data-stu-id="3f064-148">Create a Release Build</span></span>

<span data-ttu-id="3f064-149">NuGet のパッケージは、リリース ビルドの他のツールを実行するプロジェクトを構成します。</span><span class="sxs-lookup"><span data-stu-id="3f064-149">The NuGet package configures the project to run an additional tool for release builds.</span></span> <span data-ttu-id="3f064-150">このツールは、同じバイナリのネイティブ コードを追加します。</span><span class="sxs-lookup"><span data-stu-id="3f064-150">This tool adds the native code to the same binaries.</span></span>
<span data-ttu-id="3f064-151">ツールでバイナリを処理したことを確認するのには、ビルドのいずれかのこのようなメッセージが含まれて かどうかを確認するのには出力を確認できます。</span><span class="sxs-lookup"><span data-stu-id="3f064-151">To verify that the tool has processed the binaries you can review the build output to make sure it includes a message such as this one:</span></span>

```
Native image obj\x86\Release\\R2R\DesktopApp1.exe generated successfully.
```

## <a name="faq"></a><span data-ttu-id="3f064-152">FAQ</span><span class="sxs-lookup"><span data-stu-id="3f064-152">FAQ</span></span>

**<span data-ttu-id="3f064-153">Q。</span><span class="sxs-lookup"><span data-stu-id="3f064-153">Q.</span></span> <span data-ttu-id="3f064-154">新しいバイナリに.NET Framework 4.7.2 にも動作しますか。</span><span class="sxs-lookup"><span data-stu-id="3f064-154">Do the new binaries work on machines without .NET Framework 4.7.2?</span></span>**

<span data-ttu-id="3f064-155">A.</span><span class="sxs-lookup"><span data-stu-id="3f064-155">A.</span></span> <span data-ttu-id="3f064-156">最適化されたバイナリが恩恵を受ける機能強化 4.7.2 の.NET Framework で実行している場合。</span><span class="sxs-lookup"><span data-stu-id="3f064-156">Optimized binaries will benefit from the improvements when running with .NET Framework 4.7.2.</span></span> <span data-ttu-id="3f064-157">以前のバージョンの .NET framework を実行しているクライアントは、最適化されていない MSIL コードをバイナリから読み込まれます。</span><span class="sxs-lookup"><span data-stu-id="3f064-157">Clients that run previous .NET framework versions will load the non-optimized MSIL code from the binary.</span></span>

**<span data-ttu-id="3f064-158">Q。</span><span class="sxs-lookup"><span data-stu-id="3f064-158">Q.</span></span> <span data-ttu-id="3f064-159">フィードバックまたは問題の報告方法は?</span><span class="sxs-lookup"><span data-stu-id="3f064-159">How can I provide feedback or report issues?</span></span>**

<span data-ttu-id="3f064-160">A.</span><span class="sxs-lookup"><span data-stu-id="3f064-160">A.</span></span> <span data-ttu-id="3f064-161">Visual Studio 2017 にフィードバック ツールを使用して問題を報告します。</span><span class="sxs-lookup"><span data-stu-id="3f064-161">Report an issue by using the Feedback tool in Visual Studio 2017.</span></span> <span data-ttu-id="3f064-162">[詳細について](https://docs.microsoft.com/visualstudio/ide/how-to-report-a-problem-with-visual-studio-2017)は。</span><span class="sxs-lookup"><span data-stu-id="3f064-162">[More information](https://docs.microsoft.com/visualstudio/ide/how-to-report-a-problem-with-visual-studio-2017).</span></span>

**<span data-ttu-id="3f064-163">Q。</span><span class="sxs-lookup"><span data-stu-id="3f064-163">Q.</span></span> <span data-ttu-id="3f064-164">ネイティブ イメージを追加する既存のバイナリ ファイルへの影響とは何ですか。</span><span class="sxs-lookup"><span data-stu-id="3f064-164">What’s the impact of adding the native image to existing binaries?</span></span>**

<span data-ttu-id="3f064-165">A.</span><span class="sxs-lookup"><span data-stu-id="3f064-165">A.</span></span> <span data-ttu-id="3f064-166">最適化されたバイナリには、最終的なファイルを大きくする、マネージ コードとネイティブ コードが含まれています。</span><span class="sxs-lookup"><span data-stu-id="3f064-166">The optimized binaries contain the managed and native code, making the final files greater.</span></span>

**<span data-ttu-id="3f064-167">Q。</span><span class="sxs-lookup"><span data-stu-id="3f064-167">Q.</span></span> <span data-ttu-id="3f064-168">このテクノロジーを使用してバイナリをリリースすることができますでしょうか。</span><span class="sxs-lookup"><span data-stu-id="3f064-168">Can I release binaries using this technology?</span></span>**

<span data-ttu-id="3f064-169">A.</span><span class="sxs-lookup"><span data-stu-id="3f064-169">A.</span></span> <span data-ttu-id="3f064-170">このバージョンには、現在使用できる、本番運用のライセンスが含まれています。</span><span class="sxs-lookup"><span data-stu-id="3f064-170">This version includes a Go Live license that you can use today.</span></span>
