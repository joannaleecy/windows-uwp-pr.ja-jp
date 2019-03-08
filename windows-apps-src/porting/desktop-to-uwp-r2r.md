---
Description: このガイドでは、ネイティブ イメージ アプリケーション バイナリを最適化するために、Visual Studio ソリューションを構成する方法について説明します。
Search.Product: eADQiWindows 10XVcnh
title: ネイティブ イメージで .NET デスクトップ アプリを最適化します。
ms.date: 06/11/2018
ms.topic: article
keywords: windows 10、ネイティブ イメージ コンパイラ
ms.localizationpriority: medium
ms.openlocfilehash: 3071b843a1605d765ab5b087d5e1bfb96a220218
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57642877"
---
# <a name="optimize-your-net-desktop-apps-with-native-images"></a><span data-ttu-id="5b76a-104">ネイティブ イメージで .NET デスクトップ アプリを最適化します。</span><span class="sxs-lookup"><span data-stu-id="5b76a-104">Optimize your .NET Desktop apps with native images</span></span>

> [!NOTE]
> <span data-ttu-id="5b76a-105">一部の情報はリリース前の製品に関する事項であり、正式版がリリースされるまでに大幅に変更される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="5b76a-105">Some information relates to pre-released product which may be substantially modified before it’s commercially released.</span></span> <span data-ttu-id="5b76a-106">本書に記載された情報について、Microsoft は明示または黙示を問わずいかなる保証をするものでもありません。</span><span class="sxs-lookup"><span data-stu-id="5b76a-106">Microsoft makes no warranties, express or implied, with respect to the information provided here.</span></span>

<span data-ttu-id="5b76a-107">バイナリを事前コンパイルすることで、.NET Framework アプリケーションの起動時間を向上できます。</span><span class="sxs-lookup"><span data-stu-id="5b76a-107">You can improve the startup time of your .NET Framework application by pre-compiling your binaries.</span></span> <span data-ttu-id="5b76a-108">Microsoft Store を介して配布のパッケージ化とする大規模なアプリケーションでは、このテクノロジを使用できます。</span><span class="sxs-lookup"><span data-stu-id="5b76a-108">You can use this technology on large applications that you package and distribute through the Microsoft Store.</span></span> <span data-ttu-id="5b76a-109">場合によっては、20% のパフォーマンスが向上が見しました。</span><span class="sxs-lookup"><span data-stu-id="5b76a-109">In some cases, we've observed a 20% performance improvement.</span></span> <span data-ttu-id="5b76a-110">このテクノロジに関する詳細については、[の技術概要](https://github.com/dotnet/coreclr/blob/master/Documentation/botr/readytorun-overview.md)します。</span><span class="sxs-lookup"><span data-stu-id="5b76a-110">You can learn more about this technology in the [technical overview](https://github.com/dotnet/coreclr/blob/master/Documentation/botr/readytorun-overview.md).</span></span>

<span data-ttu-id="5b76a-111">としてネイティブ イメージのコンパイラのプレビュー バージョンをリリースしました、 [NuGet パッケージ](https://www.nuget.org/packages/Microsoft.DotNet.Framework.NativeImageCompiler)します。</span><span class="sxs-lookup"><span data-stu-id="5b76a-111">We've released a preview version of the native image compiler as a [NuGet package](https://www.nuget.org/packages/Microsoft.DotNet.Framework.NativeImageCompiler).</span></span> <span data-ttu-id="5b76a-112">このパッケージを適用するには、.NET Framework バージョン 4.6.2 を対象とする任意の .NET Framework アプリケーションまたはそれ以降。</span><span class="sxs-lookup"><span data-stu-id="5b76a-112">You can apply this package to any .NET Framework application that targets the .NET Framework version 4.6.2 or later.</span></span> <span data-ttu-id="5b76a-113">このパッケージは、アプリケーションで使用されるすべてのバイナリをネイティブ ペイロードを含む投稿ビルド ステップを追加します。</span><span class="sxs-lookup"><span data-stu-id="5b76a-113">This package adds a post build step that includes a native payload to all the binaries used by your application.</span></span> <span data-ttu-id="5b76a-114">この最適化されたペイロードは、以前のバージョンの MSIL コードはまだ読み込み中に .NET 4.7.2 以降をアプリケーションが実行時に読み込まれます。</span><span class="sxs-lookup"><span data-stu-id="5b76a-114">This optimized payload will be loaded when the application runs in .NET 4.7.2 and above while previous versions will still load the MSIL code.</span></span>

<span data-ttu-id="5b76a-115">[.NET framework 4.7.2](https://blogs.msdn.microsoft.com/dotnet/2018/04/30/announcing-the-net-framework-4-7-2/)に含まれている、 [Windows 10 April 2018 update](https://blogs.windows.com/windowsexperience/2018/04/30/how-to-get-the-windows-10-april-2018-update/)します。</span><span class="sxs-lookup"><span data-stu-id="5b76a-115">The [.NET framework 4.7.2](https://blogs.msdn.microsoft.com/dotnet/2018/04/30/announcing-the-net-framework-4-7-2/) is included in the [Windows 10 April 2018 update](https://blogs.windows.com/windowsexperience/2018/04/30/how-to-get-the-windows-10-april-2018-update/).</span></span> <span data-ttu-id="5b76a-116">Windows 7 以降および Windows Server 2008 R2 以降を実行する PC で、このバージョンの .NET Framework をインストールすることもできます。</span><span class="sxs-lookup"><span data-stu-id="5b76a-116">You can also install this version of the .NET Framework on PC's that run Windows 7+ and Windows Server 2008 R2+.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="5b76a-117">Windows アプリケーション パッケージ プロジェクトでパッケージ化、アプリケーションのネイティブ イメージを生成する場合は、Windows Anniversary Update に、プロジェクトのターゲット プラットフォームの最小バージョンを設定することを確認してください。</span><span class="sxs-lookup"><span data-stu-id="5b76a-117">If you want to produce native images for your application packaged by  the Windows Application Packaging project, make sure to set the Target Platform Minimum version of the project to the Windows Anniversary Update.</span></span>

## <a name="how-to-produce-native-images"></a><span data-ttu-id="5b76a-118">ネイティブ イメージを生成する方法</span><span class="sxs-lookup"><span data-stu-id="5b76a-118">How to produce native images</span></span>

<span data-ttu-id="5b76a-119">プロジェクトを構成する次の手順に従います。</span><span class="sxs-lookup"><span data-stu-id="5b76a-119">Follow these instructions to configure your projects.</span></span>

1. <span data-ttu-id="5b76a-120">4.6.2 またはの上に、ターゲット フレームワークを構成します。</span><span class="sxs-lookup"><span data-stu-id="5b76a-120">Configure the target framework as 4.6.2 or above</span></span>

2. <span data-ttu-id="5b76a-121">ターゲット プラットフォームを x86 または x64 として構成します。</span><span class="sxs-lookup"><span data-stu-id="5b76a-121">Configure the target platform as x86 or x64</span></span> 

3. <span data-ttu-id="5b76a-122">NuGet パッケージを追加します。</span><span class="sxs-lookup"><span data-stu-id="5b76a-122">Add the NuGet packages.</span></span>

4. <span data-ttu-id="5b76a-123">リリース ビルドを作成します。</span><span class="sxs-lookup"><span data-stu-id="5b76a-123">Create a Release Build.</span></span>

## <a name="configure-the-target-framework-as-462-or-above"></a><span data-ttu-id="5b76a-124">4.6.2 またはの上に、ターゲット フレームワークを構成します。</span><span class="sxs-lookup"><span data-stu-id="5b76a-124">Configure the target framework as 4.6.2 or above</span></span>

<span data-ttu-id="5b76a-125">ターゲット .NET Framework 4.6.2 にプロジェクトを構成する必要があります、.NET Framework 4.6.2 開発ツールまたはそれ以降。</span><span class="sxs-lookup"><span data-stu-id="5b76a-125">To configure your project to target .NET Framework 4.6.2 you will need the .NET Framework 4.6.2 development tools or newer.</span></span> <span data-ttu-id="5b76a-126">これらのツールは、.NET デスクトップ開発ワークロードの下のオプション コンポーネントとして、Visual Studio インストーラーで使用できます。</span><span class="sxs-lookup"><span data-stu-id="5b76a-126">These tools are available through the Visual Studio installer as optional components under the .NET desktop development workload:</span></span>

![.NET 4.6.2 をインストールする開発ツール](images/desktop-to-uwp/install-4.6.2-devpack.png)

<span data-ttu-id="5b76a-128">またはから .NET の開発者パックを取得できます。 [https://www.microsoft.com/net/download/visual-studio-sdks](https://www.microsoft.com/net/download/visual-studio-sdks)</span><span class="sxs-lookup"><span data-stu-id="5b76a-128">Alternatively, you can get the .NET developer packs from: [https://www.microsoft.com/net/download/visual-studio-sdks](https://www.microsoft.com/net/download/visual-studio-sdks)</span></span>

## <a name="configure-the-target-platform-as-x86-or-x64"></a><span data-ttu-id="5b76a-129">ターゲット プラットフォームを x86 または x64 として構成します。</span><span class="sxs-lookup"><span data-stu-id="5b76a-129">Configure the target platform as x86 or x64</span></span>

<span data-ttu-id="5b76a-130">ネイティブ イメージのコンパイラでは、特定のプラットフォーム コードを最適化します。</span><span class="sxs-lookup"><span data-stu-id="5b76a-130">The native image compiler optimizes the code for a given platform.</span></span> <span data-ttu-id="5b76a-131">これを使用するには、x86 または x64 など特定の 1 つのプラットフォームを対象とするアプリケーションを構成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="5b76a-131">To use it, you need to configure your application to target one specific platform such as x86 or x64.</span></span>

<span data-ttu-id="5b76a-132">ソリューション内に複数のプロジェクトがある場合のみエントリ ポイント プロジェクトは、(ほとんどの場合、実行可能ファイルを生成するプロジェクト) が x86 または x64 としてコンパイルします。</span><span class="sxs-lookup"><span data-stu-id="5b76a-132">If you have multiple projects in your solution, only the entry point project (most likely the project that produces an executable file) has to be compiled as x86 or x64.</span></span> <span data-ttu-id="5b76a-133">メイン プロジェクトから参照されているその他のバイナリは、AnyCPU としてコンパイルする場合でも、メインのプロジェクトで指定されたアーキテクチャと処理されます。</span><span class="sxs-lookup"><span data-stu-id="5b76a-133">Additional binaries referenced from the main project will be processed with the architecture specified in the main project, even if they are compiled as AnyCPU.</span></span>

<span data-ttu-id="5b76a-134">プロジェクトを構成するには。</span><span class="sxs-lookup"><span data-stu-id="5b76a-134">To configure your project:</span></span>

1. <span data-ttu-id="5b76a-135">ソリューションを右クリックし、 **Configuration Manager**します。</span><span class="sxs-lookup"><span data-stu-id="5b76a-135">Right-click your solution, and then select **Configuration Manager**.</span></span>

2. <span data-ttu-id="5b76a-136">選択 **< 新規作成.>** で、**プラットフォーム**実行可能ファイルを生成するプロジェクトの名前の横にあるドロップダウン メニュー。</span><span class="sxs-lookup"><span data-stu-id="5b76a-136">Select **<New ..>** in the **Platform** dropdown menu beside the name of the project that produces your executable file.</span></span>

3. <span data-ttu-id="5b76a-137">**新しいプロジェクト プラットフォーム** ダイアログ ボックスに、必ず、**設定のコピー元**にドロップダウン リストが設定されている**Any CPU**。</span><span class="sxs-lookup"><span data-stu-id="5b76a-137">In the **New Project Platform** dialog box, make sure that the **Copy Settings from** dropdown list is set to **Any CPU**.</span></span>

![X86 を構成します。](images/desktop-to-uwp/configure-x86.png)

<span data-ttu-id="5b76a-139">この手順を繰り返します`Release/x64`x64 を生成する場合のバイナリです。</span><span class="sxs-lookup"><span data-stu-id="5b76a-139">Repeat this step for `Release/x64` if you want produce x64 binaries.</span></span>

>[!IMPORTANT]
> <span data-ttu-id="5b76a-140">ネイティブ イメージのコンパイラでは、AnyCPU 構成はサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="5b76a-140">AnyCPU configuration is not supported by the native image compiler.</span></span>

## <a name="add-the-nuget-packages"></a><span data-ttu-id="5b76a-141">NuGet パッケージを追加します。</span><span class="sxs-lookup"><span data-stu-id="5b76a-141">Add the NuGet packages</span></span>

<span data-ttu-id="5b76a-142">ネイティブ イメージのコンパイラは、実行可能ファイルを生成する Visual Studio プロジェクトに追加する必要がある NuGet パッケージとして提供されます。</span><span class="sxs-lookup"><span data-stu-id="5b76a-142">The native image compiler is provided as a NuGet package that you need to add to the Visual Studio project that produces the executable file.</span></span> <span data-ttu-id="5b76a-143">これは、通常、Windows フォームまたは WPF プロジェクトです。</span><span class="sxs-lookup"><span data-stu-id="5b76a-143">This is typically your Windows Forms or WPF project.</span></span> <span data-ttu-id="5b76a-144">そのためには、次の PowerShell コマンドを使用します。</span><span class="sxs-lookup"><span data-stu-id="5b76a-144">Use this PowerShell command to do that.</span></span>

```PS
PM> Install-Package Microsoft.DotNet.Framework.NativeImageCompiler -Version 0.0.1-prerelease-00002  -PRE
```

> [!NOTE]
> <span data-ttu-id="5b76a-145">プレビュー パッケージは、一覧にないと、NuGet.org に発行されます。</span><span class="sxs-lookup"><span data-stu-id="5b76a-145">The preview packages are published in NuGet.org as unlisted.</span></span> <span data-ttu-id="5b76a-146">NuGet.org を参照して、または Visual Studio でパッケージ マネージャー UI を使用して、検出されません。</span><span class="sxs-lookup"><span data-stu-id="5b76a-146">You won’t find them by browsing NuGet.org or by using the Package Manager UI in Visual Studio.</span></span> <span data-ttu-id="5b76a-147">パッケージ マネージャー コンソールからインストールするただし、いつ別のコンピューターから復元します。</span><span class="sxs-lookup"><span data-stu-id="5b76a-147">However, you can install them from the Package Manager Console, and when you restoring from a different machine.</span></span> <span data-ttu-id="5b76a-148">しましょうパッケージは、完全にアクセスできるときに、最初の非プレビュー バージョンを公開します。</span><span class="sxs-lookup"><span data-stu-id="5b76a-148">We'll make the packages fully accessible when we publish the first non-preview version.</span></span>

## <a name="create-a-release-build"></a><span data-ttu-id="5b76a-149">リリース ビルドを作成します。</span><span class="sxs-lookup"><span data-stu-id="5b76a-149">Create a Release Build</span></span>

<span data-ttu-id="5b76a-150">NuGet パッケージは、リリース ビルドの場合、追加のツールを実行するプロジェクトを構成します。</span><span class="sxs-lookup"><span data-stu-id="5b76a-150">The NuGet package configures the project to run an additional tool for release builds.</span></span> <span data-ttu-id="5b76a-151">このツールは、同じバイナリにネイティブ コードを追加します。</span><span class="sxs-lookup"><span data-stu-id="5b76a-151">This tool adds the native code to the same binaries.</span></span>
<span data-ttu-id="5b76a-152">ツールのバイナリが処理されていることを確認するには、ビルドの出力など、この 1 つのメッセージを含めたを確認できます。</span><span class="sxs-lookup"><span data-stu-id="5b76a-152">To verify that the tool has processed the binaries you can review the build output to make sure it includes a message such as this one:</span></span>

```
Native image obj\x86\Release\\R2R\DesktopApp1.exe generated successfully.
```

## <a name="faq"></a><span data-ttu-id="5b76a-153">FAQ</span><span class="sxs-lookup"><span data-stu-id="5b76a-153">FAQ</span></span>

<span data-ttu-id="5b76a-154">**Q。新しいバイナリは .NET Framework 4.7.2 なしのマシンでは機能しますか。**</span><span class="sxs-lookup"><span data-stu-id="5b76a-154">**Q. Do the new binaries work on machines without .NET Framework 4.7.2?**</span></span>

<span data-ttu-id="5b76a-155">A.</span><span class="sxs-lookup"><span data-stu-id="5b76a-155">A.</span></span> <span data-ttu-id="5b76a-156">.NET Framework 4.7.2 以降を実行しているときに、機能強化による最適化されたバイナリが得られます。</span><span class="sxs-lookup"><span data-stu-id="5b76a-156">Optimized binaries will benefit from the improvements when running with .NET Framework 4.7.2.</span></span> <span data-ttu-id="5b76a-157">.NET framework の以前のバージョンを実行しているクライアントでは、最適化されていない MSIL コードをバイナリから読み込みます。</span><span class="sxs-lookup"><span data-stu-id="5b76a-157">Clients that run previous .NET framework versions will load the non-optimized MSIL code from the binary.</span></span>

<span data-ttu-id="5b76a-158">**Q。フィードバックを提供または問題を報告する方法は?**</span><span class="sxs-lookup"><span data-stu-id="5b76a-158">**Q. How can I provide feedback or report issues?**</span></span>

<span data-ttu-id="5b76a-159">A.</span><span class="sxs-lookup"><span data-stu-id="5b76a-159">A.</span></span> <span data-ttu-id="5b76a-160">Visual Studio 2017 で、フィードバック ツールを使用して、問題を報告します。</span><span class="sxs-lookup"><span data-stu-id="5b76a-160">Report an issue by using the Feedback tool in Visual Studio 2017.</span></span> <span data-ttu-id="5b76a-161">[詳細については](https://docs.microsoft.com/visualstudio/ide/how-to-report-a-problem-with-visual-studio-2017)します。</span><span class="sxs-lookup"><span data-stu-id="5b76a-161">[More information](https://docs.microsoft.com/visualstudio/ide/how-to-report-a-problem-with-visual-studio-2017).</span></span>

<span data-ttu-id="5b76a-162">**Q。既存のバイナリへのネイティブ イメージの追加の影響とは何ですか。**</span><span class="sxs-lookup"><span data-stu-id="5b76a-162">**Q. What’s the impact of adding the native image to existing binaries?**</span></span>

<span data-ttu-id="5b76a-163">A.</span><span class="sxs-lookup"><span data-stu-id="5b76a-163">A.</span></span> <span data-ttu-id="5b76a-164">最適化されたバイナリには、最終的なファイルが大きいため、マネージ コードとネイティブ コードが含まれます。</span><span class="sxs-lookup"><span data-stu-id="5b76a-164">The optimized binaries contain the managed and native code, making the final files greater.</span></span>

<span data-ttu-id="5b76a-165">**Q。このテクノロジを使用してバイナリをリリースすることができますか。**</span><span class="sxs-lookup"><span data-stu-id="5b76a-165">**Q. Can I release binaries using this technology?**</span></span>

<span data-ttu-id="5b76a-166">A.</span><span class="sxs-lookup"><span data-stu-id="5b76a-166">A.</span></span> <span data-ttu-id="5b76a-167">このバージョンには、現在使用できる、Go Live のライセンスが含まれています。</span><span class="sxs-lookup"><span data-stu-id="5b76a-167">This version includes a Go Live license that you can use today.</span></span>
