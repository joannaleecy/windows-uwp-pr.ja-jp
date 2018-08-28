---
author: rido-min
Description: This guide explains how to configure your Visual Studio Solution to optimize the application binaries with native images.
Search.Product: eADQiWindows 10XVcnh
title: ネイティブ イメージで .NET デスクトップ アプリを最適化します。
ms.author: normesta
ms.date: 06/11/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10、ネイティブ コンパイラをイメージします。
ms.localizationpriority: medium
ms.openlocfilehash: d98b576fb51a8f9507802796ab359d0d00d21998
ms.sourcegitcommit: 9a17266f208ec415fc718e5254d5b4c08835150c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/28/2018
ms.locfileid: "2885776"
---
# <a name="optimize-your-net-desktop-apps-with-native-images"></a><span data-ttu-id="e9dca-103">ネイティブ イメージで .NET デスクトップ アプリを最適化します。</span><span class="sxs-lookup"><span data-stu-id="e9dca-103">Optimize your .NET Desktop apps with native images</span></span>

> [!NOTE]
> <span data-ttu-id="e9dca-104">一部の情報はリリース前の製品に関する事項であり、正式版がリリースされるまでに大幅に変更される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="e9dca-104">Some information relates to pre-released product which may be substantially modified before it’s commercially released.</span></span> <span data-ttu-id="e9dca-105">ここに記載された情報について、Microsoft は明示または黙示を問わずいかなる保証をするものでもありません。</span><span class="sxs-lookup"><span data-stu-id="e9dca-105">Microsoft makes no warranties, express or implied, with respect to the information provided here.</span></span>

<span data-ttu-id="e9dca-106">バイナリのコンパイル済みで、.NET Framework アプリケーションの起動時を向上させることができます。</span><span class="sxs-lookup"><span data-stu-id="e9dca-106">You can improve the startup time of your .NET Framework application by pre-compiling your binaries.</span></span> <span data-ttu-id="e9dca-107">パッケージ化し、Windows ストアで配布する大規模なアプリケーションでは、このテクノロジを使用できます。</span><span class="sxs-lookup"><span data-stu-id="e9dca-107">You can use this technology on large applications that you package and distribute through the Windows Store.</span></span> <span data-ttu-id="e9dca-108">場合によっては、お見 20% のパフォーマンスが向上します。</span><span class="sxs-lookup"><span data-stu-id="e9dca-108">In some cases, we've observed a 20% performance improvement.</span></span> <span data-ttu-id="e9dca-109">[技術的な概要](https://github.com/dotnet/coreclr/blob/master/Documentation/botr/readytorun-overview.md)には、この技術の詳細を学びます。</span><span class="sxs-lookup"><span data-stu-id="e9dca-109">You can learn more about this technology in the [technical overview](https://github.com/dotnet/coreclr/blob/master/Documentation/botr/readytorun-overview.md).</span></span>

<span data-ttu-id="e9dca-110">ネイティブ イメージ コンパイラの preview 版をリリース[NuGet パッケージ](https://www.nuget.org/packages/Microsoft.DotNet.Framework.NativeImageCompiler)としてしましたしました。</span><span class="sxs-lookup"><span data-stu-id="e9dca-110">We've released a preview version of the native image compiler as a [NuGet package](https://www.nuget.org/packages/Microsoft.DotNet.Framework.NativeImageCompiler).</span></span> <span data-ttu-id="e9dca-111">このパッケージを適用するには、.NET Framework バージョン 4.6.2 を対象とするすべての .NET Framework アプリケーションまたはそれ以降。</span><span class="sxs-lookup"><span data-stu-id="e9dca-111">You can apply this package to any .NET Framework application that targets the .NET Framework version 4.6.2 or later.</span></span> <span data-ttu-id="e9dca-112">このパッケージでは、ネイティブ アプリケーションで使用されているすべてのバイナリ ペイロードを含む投稿ビルド ステップを追加します。</span><span class="sxs-lookup"><span data-stu-id="e9dca-112">This package adds a post build step that includes a native payload to all the binaries used by your application.</span></span> <span data-ttu-id="e9dca-113">アプリケーションが実行される .NET 4.7.2 で上にある以前のバージョンの MSIL コードはまだ読み込み中に最適化されたこのペイロードが読み込まれます。</span><span class="sxs-lookup"><span data-stu-id="e9dca-113">This optimized payload will be loaded when the application runs in .NET 4.7.2 and above while previous versions will still load the MSIL code.</span></span>

<span data-ttu-id="e9dca-114">[Windows 10 年 2018年 4 月を更新](https://blogs.windows.com/windowsexperience/2018/04/30/how-to-get-the-windows-10-april-2018-update/)するには、 [.NET framework 4.7.2](https://blogs.msdn.microsoft.com/dotnet/2018/04/30/announcing-the-net-framework-4-7-2/)は含まれています。</span><span class="sxs-lookup"><span data-stu-id="e9dca-114">The [.NET framework 4.7.2](https://blogs.msdn.microsoft.com/dotnet/2018/04/30/announcing-the-net-framework-4-7-2/) is included in the [Windows 10 April 2018 update](https://blogs.windows.com/windowsexperience/2018/04/30/how-to-get-the-windows-10-april-2018-update/).</span></span> <span data-ttu-id="e9dca-115">Windows 7 + および Windows Server 2008 R2 + を実行しているコンピューター上の .NET Framework には、このバージョンをインストールすることもできます。</span><span class="sxs-lookup"><span data-stu-id="e9dca-115">You can also install this version of the .NET Framework on PC's that run Windows 7+ and Windows Server 2008 R2+.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="e9dca-116">Windows アプリケーション パッケージのプロジェクトでパッケージ化、アプリケーションのネイティブ イメージを作成する場合は、Windows 記念日の更新プログラムにプロジェクトのターゲット プラットフォームの最小バージョンを設定するのに確認します。</span><span class="sxs-lookup"><span data-stu-id="e9dca-116">If you want to produce native images for your application packaged by  the Windows Application Packaging project, make sure to set the Target Platform Minimum version of the project to the Windows Anniversary Update.</span></span>

## <a name="how-to-produce-native-images"></a><span data-ttu-id="e9dca-117">ネイティブ イメージを作成する方法</span><span class="sxs-lookup"><span data-stu-id="e9dca-117">How to produce native images</span></span>

<span data-ttu-id="e9dca-118">プロジェクトを構成するのには、次の手順に従います。</span><span class="sxs-lookup"><span data-stu-id="e9dca-118">Follow these instructions to configure your projects.</span></span>

1. <span data-ttu-id="e9dca-119">4.6.2 または上にあるターゲット フレームワークを構成します。</span><span class="sxs-lookup"><span data-stu-id="e9dca-119">Configure the target framework as 4.6.2 or above</span></span>

2. <span data-ttu-id="e9dca-120">X86 または x64 としてターゲット プラットフォームを構成します。</span><span class="sxs-lookup"><span data-stu-id="e9dca-120">Configure the target platform as x86 or x64</span></span> 

3. <span data-ttu-id="e9dca-121">NuGet パッケージを追加します。</span><span class="sxs-lookup"><span data-stu-id="e9dca-121">Add the NuGet packages.</span></span>

4. <span data-ttu-id="e9dca-122">リリース ビルドを作成します。</span><span class="sxs-lookup"><span data-stu-id="e9dca-122">Create a Release Build.</span></span>

## <a name="configure-the-target-framework-as-462-or-above"></a><span data-ttu-id="e9dca-123">4.6.2 または上にあるターゲット フレームワークを構成します。</span><span class="sxs-lookup"><span data-stu-id="e9dca-123">Configure the target framework as 4.6.2 or above</span></span>

<span data-ttu-id="e9dca-124">.NET Framework 4.6.2 対象プロジェクトを構成するのには、.NET Framework 4.6.2 開発ツール必要があります以降。</span><span class="sxs-lookup"><span data-stu-id="e9dca-124">To configure your project to target .NET Framework 4.6.2 you will need the .NET Framework 4.6.2 development tools or newer.</span></span> <span data-ttu-id="e9dca-125">これらのツールは、.NET デスクトップ開発作業負荷の下にある省略可能なコンポーネントとして Visual Studio インストーラーで提供されます。</span><span class="sxs-lookup"><span data-stu-id="e9dca-125">These tools are available through the Visual Studio installer as optional components under the .NET desktop development workload:</span></span>

![.NET 4.6.2 をインストールする開発ツール](images/desktop-to-uwp/install-4.6.2-devpack.png)

<span data-ttu-id="e9dca-127">またはから .NET 開発パックを入手することができます。[https://www.microsoft.com/net/download/visual-studio-sdks](https://www.microsoft.com/net/download/visual-studio-sdks)</span><span class="sxs-lookup"><span data-stu-id="e9dca-127">Alternatively, you can get the .NET developer packs from: [https://www.microsoft.com/net/download/visual-studio-sdks](https://www.microsoft.com/net/download/visual-studio-sdks)</span></span>

## <a name="configure-the-target-platform-as-x86-or-x64"></a><span data-ttu-id="e9dca-128">X86 または x64 としてターゲット プラットフォームを構成します。</span><span class="sxs-lookup"><span data-stu-id="e9dca-128">Configure the target platform as x86 or x64</span></span>

<span data-ttu-id="e9dca-129">ネイティブ イメージ コンパイラでは、特定のプラットフォームのコードを最適化します。</span><span class="sxs-lookup"><span data-stu-id="e9dca-129">The native image compiler optimizes the code for a given platform.</span></span> <span data-ttu-id="e9dca-130">これを使用するには、x86 または x64 など特定の 1 つのプラットフォームの対象としたアプリケーションを構成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e9dca-130">To use it, you need to configure your application to target one specific platform such as x86 or x64.</span></span>

<span data-ttu-id="e9dca-131">複数のプロジェクト ソリューションである場合は、x86 または x64 としてコンパイル エントリ ポイント プロジェクトのみ (いる可能性が高い実行可能ファイルを作成するプロジェクト) があります。</span><span class="sxs-lookup"><span data-stu-id="e9dca-131">If you have multiple projects in your solution, only the entry point project (most likely the project that produces an executable file) has to be compiled as x86 or x64.</span></span> <span data-ttu-id="e9dca-132">メインのプロジェクトから参照されているその他のバイナリが AnyCPU としてコンパイルした場合でも、メインのプロジェクトで指定されたアーキテクチャで処理されます。</span><span class="sxs-lookup"><span data-stu-id="e9dca-132">Additional binaries referenced from the main project will be processed with the architecture specified in the main project, even if they are compiled as AnyCPU.</span></span>

<span data-ttu-id="e9dca-133">プロジェクトを構成するには。</span><span class="sxs-lookup"><span data-stu-id="e9dca-133">To configure your project:</span></span>

1. <span data-ttu-id="e9dca-134">ソリューションを右クリックし、[**構成マネージャー**] を選びます。</span><span class="sxs-lookup"><span data-stu-id="e9dca-134">Right-click your solution, and then select **Configuration Manager**.</span></span>

2. <span data-ttu-id="e9dca-135">選択 **< 新しい.>** 、実行可能ファイルを作成するプロジェクトの名前の横にある**プラットフォーム**] ドロップダウン メニューでします。</span><span class="sxs-lookup"><span data-stu-id="e9dca-135">Select **<New ..>** in the **Platform** dropdown menu beside the name of the project that produces your executable file.</span></span>

3. <span data-ttu-id="e9dca-136">**新しいプロジェクト プラットフォーム**] ダイアログ ボックスで、**設定のコピー元**のドロップダウン リストを**任意の CPU**に設定されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="e9dca-136">In the **New Project Platform** dialog box, make sure that the **Copy Settings from** dropdown list is set to **Any CPU**.</span></span>

![X86 を構成します。](images/desktop-to-uwp/configure-x86.png)

<span data-ttu-id="e9dca-138">この手順を繰り返します`Release/x64`x64 を作成する場合のバイナリします。</span><span class="sxs-lookup"><span data-stu-id="e9dca-138">Repeat this step for `Release/x64` if you want produce x64 binaries.</span></span>

>[!IMPORTANT]
> <span data-ttu-id="e9dca-139">AnyCPU 構成は、ネイティブ イメージ コンパイラでサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="e9dca-139">AnyCPU configuration is not supported by the native image compiler.</span></span>

## <a name="add-the-nuget-packages"></a><span data-ttu-id="e9dca-140">NuGet パッケージを追加します。</span><span class="sxs-lookup"><span data-stu-id="e9dca-140">Add the NuGet packages</span></span>

<span data-ttu-id="e9dca-141">ネイティブ イメージ コンパイラ実行可能ファイルを作成する Visual Studio プロジェクトに追加する必要がある NuGet パッケージが表示されます。</span><span class="sxs-lookup"><span data-stu-id="e9dca-141">The native image compiler is provided as a NuGet package that you need to add to the Visual Studio project that produces the executable file.</span></span> <span data-ttu-id="e9dca-142">これは、通常は、Windows フォームまたは WPF プロジェクトです。</span><span class="sxs-lookup"><span data-stu-id="e9dca-142">This is typically your Windows Forms or WPF project.</span></span> <span data-ttu-id="e9dca-143">そのためには、次の PowerShell コマンドを使用します。</span><span class="sxs-lookup"><span data-stu-id="e9dca-143">Use this PowerShell command to do that.</span></span>

```PS
PM> Install-Package Microsoft.DotNet.Framework.NativeImageCompiler -Version 0.0.1-prerelease-00002  -PRE
```

> [!NOTE]
> <span data-ttu-id="e9dca-144">プレビュー パッケージは、一覧にないとして NuGet.org で発行されます。</span><span class="sxs-lookup"><span data-stu-id="e9dca-144">The preview packages are published in NuGet.org as unlisted.</span></span> <span data-ttu-id="e9dca-145">参照 NuGet.org または Visual Studio でパッケージ マネージャーのユーザー インターフェイスを使用して、表示されません。</span><span class="sxs-lookup"><span data-stu-id="e9dca-145">You won’t find them by browsing NuGet.org or by using the Package Manager UI in Visual Studio.</span></span> <span data-ttu-id="e9dca-146">パッケージ マネージャーからインストールするただしと別のコンピューターから復元します。</span><span class="sxs-lookup"><span data-stu-id="e9dca-146">However, you can install them from the Package Manager Console, and when you restoring from a different machine.</span></span> <span data-ttu-id="e9dca-147">しましょうパッケージ完全にアクセスできるときに、最初のプレビューでないバージョンを公開します。</span><span class="sxs-lookup"><span data-stu-id="e9dca-147">We'll make the packages fully accessible when we publish the first non-preview version.</span></span>

## <a name="create-a-release-build"></a><span data-ttu-id="e9dca-148">リリース ビルドを作成します。</span><span class="sxs-lookup"><span data-stu-id="e9dca-148">Create a Release Build</span></span>

<span data-ttu-id="e9dca-149">NuGet パッケージ リリース ビルドの他のツールを実行するプロジェクトを設定します。</span><span class="sxs-lookup"><span data-stu-id="e9dca-149">The NuGet package configures the project to run an additional tool for release builds.</span></span> <span data-ttu-id="e9dca-150">このツールは、同じバイナリにネイティブ コードを追加します。</span><span class="sxs-lookup"><span data-stu-id="e9dca-150">This tool adds the native code to the same binaries.</span></span>
<span data-ttu-id="e9dca-151">ツールがバイナリを処理されることを確認するのには、ビルドなど、このメッセージが含まれて かどうかを確認する出力を確認できます。</span><span class="sxs-lookup"><span data-stu-id="e9dca-151">To verify that the tool has processed the binaries you can review the build output to make sure it includes a message such as this one:</span></span>

```
Native image obj\x86\Release\\R2R\DesktopApp1.exe generated successfully.
```

## <a name="faq"></a><span data-ttu-id="e9dca-152">FAQ</span><span class="sxs-lookup"><span data-stu-id="e9dca-152">FAQ</span></span>

**<span data-ttu-id="e9dca-153">Q します。</span><span class="sxs-lookup"><span data-stu-id="e9dca-153">Q.</span></span> <span data-ttu-id="e9dca-154">.NET Framework 4.7.2 に操作する新しいバイナリすればよいですか。</span><span class="sxs-lookup"><span data-stu-id="e9dca-154">Do the new binaries work on machines without .NET Framework 4.7.2?</span></span>**

<span data-ttu-id="e9dca-155">A.</span><span class="sxs-lookup"><span data-stu-id="e9dca-155">A.</span></span> <span data-ttu-id="e9dca-156">最適化されたバイナリがのメリットを享受改善点は、.NET Framework 4.7.2 で実行されているときにします。</span><span class="sxs-lookup"><span data-stu-id="e9dca-156">Optimized binaries will benefit from the improvements when running with .NET Framework 4.7.2.</span></span> <span data-ttu-id="e9dca-157">.NET framework の以前のバージョンを実行しているクライアントはバイナリから最適化されていない MSIL コードを読み込みます。</span><span class="sxs-lookup"><span data-stu-id="e9dca-157">Clients that run previous .NET framework versions will load the non-optimized MSIL code from the binary.</span></span>

**<span data-ttu-id="e9dca-158">Q します。</span><span class="sxs-lookup"><span data-stu-id="e9dca-158">Q.</span></span> <span data-ttu-id="e9dca-159">フィードバックを送信するまたは問題を報告する方法は?</span><span class="sxs-lookup"><span data-stu-id="e9dca-159">How can I provide feedback or report issues?</span></span>**

<span data-ttu-id="e9dca-160">A.</span><span class="sxs-lookup"><span data-stu-id="e9dca-160">A.</span></span> <span data-ttu-id="e9dca-161">Visual Studio 2017 でフィードバック ツールを使用して、問題の報告します。</span><span class="sxs-lookup"><span data-stu-id="e9dca-161">Report an issue by using the Feedback tool in Visual Studio 2017.</span></span> <span data-ttu-id="e9dca-162">[その他の情報](https://docs.microsoft.com/visualstudio/ide/how-to-report-a-problem-with-visual-studio-2017)です。</span><span class="sxs-lookup"><span data-stu-id="e9dca-162">[More information](https://docs.microsoft.com/visualstudio/ide/how-to-report-a-problem-with-visual-studio-2017).</span></span>

**<span data-ttu-id="e9dca-163">Q します。</span><span class="sxs-lookup"><span data-stu-id="e9dca-163">Q.</span></span> <span data-ttu-id="e9dca-164">既存のバイナリにネイティブ イメージを追加する場合の影響は何ですか。</span><span class="sxs-lookup"><span data-stu-id="e9dca-164">What’s the impact of adding the native image to existing binaries?</span></span>**

<span data-ttu-id="e9dca-165">A.</span><span class="sxs-lookup"><span data-stu-id="e9dca-165">A.</span></span> <span data-ttu-id="e9dca-166">最適化されたバイナリより大きい最終的なファイルを作成、管理し、ネイティブ コードが含まれています。</span><span class="sxs-lookup"><span data-stu-id="e9dca-166">The optimized binaries contain the managed and native code, making the final files greater.</span></span>

**<span data-ttu-id="e9dca-167">Q します。</span><span class="sxs-lookup"><span data-stu-id="e9dca-167">Q.</span></span> <span data-ttu-id="e9dca-168">このテクノロジを使用してバイナリを解放することができますか。</span><span class="sxs-lookup"><span data-stu-id="e9dca-168">Can I release binaries using this technology?</span></span>**

<span data-ttu-id="e9dca-169">A.</span><span class="sxs-lookup"><span data-stu-id="e9dca-169">A.</span></span> <span data-ttu-id="e9dca-170">このバージョンには、現在使用できる Live 移動ライセンスが含まれています。</span><span class="sxs-lookup"><span data-stu-id="e9dca-170">This version includes a Go Live license that you can use today.</span></span>
