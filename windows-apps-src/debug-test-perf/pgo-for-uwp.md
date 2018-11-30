---
title: ユニバーサル Windows プラットフォーム (UWP) アプリにおけるガイド付き最適化のプロファイル (PGO) の実行
ms.localizationpriority: medium
ms.openlocfilehash: 1d7321f0ef49c12ac4506fb72fab937fde77f740
ms.sourcegitcommit: 89ff8ff88ef58f4fe6d3b1368fe94f62e59118ad
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/30/2018
ms.locfileid: "8216889"
---
# <a name="running-profile-guided-optimization-on-universal-windows-platform-apps"></a><span data-ttu-id="73ada-102">ユニバーサル Windows プラットフォーム アプリにおけるガイド付き最適化のプロファイルの実行</span><span class="sxs-lookup"><span data-stu-id="73ada-102">Running Profile Guided Optimization on Universal Windows Platform apps</span></span> 
 
<span data-ttu-id="73ada-103">このトピックでは、ユニバーサル Windows プラットフォーム (UWP) アプリに対してガイド付き最適化のプロファイル (PGO) を適用するための手順を説明します。</span><span class="sxs-lookup"><span data-stu-id="73ada-103">This topic provides a step-by-step guide to applying Profile Guided Optimization (PGO) to Universal Windows Platform (UWP) apps.</span></span> <span data-ttu-id="73ada-104">従来の win32 アプリケーションで利用可能な手順の一部は UWP アプリでは利用できません。そのため、UWP 開発者にとって最適化がより簡単かつ利用しやすくなるよう、PGO を組み込むために必要な方法を説明することを目標としています。</span><span class="sxs-lookup"><span data-stu-id="73ada-104">Not all of the steps available to classic win32 applications are available to UWP apps, so our goal is to explain the process necessary to incorporate PGO to make optimizing easier and more accessible to UWP developers.</span></span>

<span data-ttu-id="73ada-105">Visual Studio 2015 Update 3 を使用して既定の DirectX 11 アプリ (UWP) テンプレートに PGO を適用する方法の基本的なチュートリアルを次に示します。</span><span class="sxs-lookup"><span data-stu-id="73ada-105">The following is a basic walkthrough of applying PGO to the default DirectX 11 app (UWP) template by using Visual Studio 2015 Update 3.</span></span>
 
<span data-ttu-id="73ada-106">このガイド全体にわたって、スクリーンショットは次の新しいプロジェクトに基づきます。![[新しいプロジェクト] ダイアログ ボックス</span><span class="sxs-lookup"><span data-stu-id="73ada-106">The screenshots throughout this guide are based on the following new project: ![New Project dialog</span></span>](images/pgo-001.png)

<span data-ttu-id="73ada-107">PGO を DirectX 11 アプリ テンプレートに適用するには、次の手順に従います。</span><span class="sxs-lookup"><span data-stu-id="73ada-107">To apply PGO to the DirectX 11 app template:</span></span>

1. <span data-ttu-id="73ada-108">ソリューションの構成を **[Release]** に設定するか、リリース目的の最適化されたコードを生成するソリューションの構成を選択します。</span><span class="sxs-lookup"><span data-stu-id="73ada-108">Set your solution configuration to **Release** or choose a solution configuration where you are generating optimized code intended for release.</span></span> <span data-ttu-id="73ada-109">論理的には、デバッグ ビルドに対して PGO を実行することもできますが、他の最適化されないビルドを最適化するために PGO を使用するのは有効ではありません。</span><span class="sxs-lookup"><span data-stu-id="73ada-109">While you could theoretically run PGO on a debug build, it would be ineffective to use PGO to optimize an otherwise unoptimized build.</span></span> 
 
 ![[App1] ウィンドウ](images/pgo-002.png)
 
2. <span data-ttu-id="73ada-111">プロジェクトのプロパティ (**[プロパティ]** > **[C/C++]** > **[最適化]**) で、**[プログラム全体の最適化]** に /GL フラグを設定してビルドしていることを確認します (これは構成によって既に設定されている可能性があります)。</span><span class="sxs-lookup"><span data-stu-id="73ada-111">Verify in your project’s properties (**Properties** > **C/C++** > **Optimization**) that you are building with the /GL flag for **Whole Program Optimization** (this may already be set by your configuration).</span></span>

 ![プログラム全体の最適化](images/pgo-003.png)

3. <span data-ttu-id="73ada-113">リンカーのプロパティ (**[プロパティ]** > **[リンカー]** > **[最適化]**) に移動し、**[リンク時のコード生成]** を **[ガイド付き最適化のプロファイル - インストルメント (LTCG:PGInstrument)]** に設定します。</span><span class="sxs-lookup"><span data-stu-id="73ada-113">Go into your linker properties (**Properties** > **Linker** > **Optimization**) and set **Link Time Code Generation** to **Profile Guided Optimization - Instrument (LTCG:PGInstrument)**.</span></span>
 
 ![リンク時のコード生成](images/pgo-004.png)

4. <span data-ttu-id="73ada-115">**[ソリューションのビルド]** をクリックした後、**[ソリューションの配置]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="73ada-115">Select **Build Solution**, and then select **Deploy Solution**.</span></span> 

 ![[新しいプロジェクト] ダイアログ ボックス](images/pgo-005.png)
 
 <span data-ttu-id="73ada-117">ビルドの出力場所を見て、.pgd ファイルが生成されていることを確認することで、すべてが適切に動作していることを再確認できます。</span><span class="sxs-lookup"><span data-stu-id="73ada-117">You can double check that everything has worked properly by looking at the build output location and verifying that a .pgd file has been generated.</span></span> <span data-ttu-id="73ada-118">この例の場合、ビルドの出力と一緒に次のファイルが生成されていることを意味しました。</span><span class="sxs-lookup"><span data-stu-id="73ada-118">In this example case, this meant that the following file was generated alongside the build output:</span></span>
 
 `C:\Users\<USER>\Documents\Visual Studio 2015\Projects\App1\Release\App1\App1.pgd`

 <span data-ttu-id="73ada-119">既定では、.pgd ファイルは実行可能ファイルと同じ名前です。</span><span class="sxs-lookup"><span data-stu-id="73ada-119">By default, the .pgd file will have the same name as your executable.</span></span> <span data-ttu-id="73ada-120">**[ガイド付きデータベースのプロファイル]** リンカー オプションを変更することで、生成される .pgd ファイルの名前を変更することもできます。</span><span class="sxs-lookup"><span data-stu-id="73ada-120">You can also change the name of the .pgd file that is generated by changing the **Profile Guided Database** linker option.</span></span> 
 
5. <span data-ttu-id="73ada-121">Visual Studio VC バイナリ ディレクトリに移動します (既定では `C:\Program Files (x86)\Microsoft Visual Studio 14.0\VC\bin` のようになります)。</span><span class="sxs-lookup"><span data-stu-id="73ada-121">Navigate to your Visual Studio VC binaries directory (by default this looks like `C:\Program Files (x86)\Microsoft Visual Studio 14.0\VC\bin`).</span></span> <span data-ttu-id="73ada-122">x86 実行可能ファイルの場合、`pgort140.dll` をコピーします。x64 実行可能ファイルの場合、`amd64\pgort140.dll` から x64 バージョンをコピーします。</span><span class="sxs-lookup"><span data-stu-id="73ada-122">For x86 executables, copy `pgort140.dll`; for x64 executables, copy the x64 version from `amd64\pgort140.dll`.</span></span> <span data-ttu-id="73ada-123">`pgort140.dll` の適切なバージョンを、配置したパッケージのルートに貼りつけます。</span><span class="sxs-lookup"><span data-stu-id="73ada-123">Paste the appropriate version of `pgort140.dll` into the root of your deployed package.</span></span> <span data-ttu-id="73ada-124">このサンプルのパスは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="73ada-124">For this sample the path is:</span></span>

 `C:\Users\<USER>\Documents\Visual Studio 2015\Projects\App1\Release\App1\AppX\`

 <span data-ttu-id="73ada-125">UWP アプリでは、パッケージ内に存在するライブラリしか読み込むことができないため、この手順は必須です。</span><span class="sxs-lookup"><span data-stu-id="73ada-125">This step is necessary because UWP apps can only load libraries that exist within their package.</span></span>

 ![[新しいプロジェクト] ダイアログ ボックス](images/pgo-006.png)
 
6. <span data-ttu-id="73ada-127">[スタート] メニューから、または Visual Studio の **[デバッグ]** メニューから **[デバッグなしで開始]** オプションを使用してアプリを実行します。</span><span class="sxs-lookup"><span data-stu-id="73ada-127">Run the app either from the Start menu or from the Visual Studio **Debug** menu with the **Start Without Debugging** option.</span></span> 

 ![[新しいプロジェクト] ダイアログ ボックス](images/pgo-007.png)
 
7. <span data-ttu-id="73ada-129">現在実行しているビルドがインストルメント化され、PGO データが生成されます。</span><span class="sxs-lookup"><span data-stu-id="73ada-129">The build that is now running is instrumented and generating PGO data.</span></span> <span data-ttu-id="73ada-130">この時点で、最適化する予定の最も一般的なシナリオを通じてアプリケーションを実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="73ada-130">At this point, you should run the application through some of the most common scenarios that you intend to optimize.</span></span> <span data-ttu-id="73ada-131">目的のシナリオすべてでプログラムの実行を終えたら、pgosweep.exe ツールを探します。これは、適切なバージョンの `pgort140.dll` と同じフォルダーに含まれます。</span><span class="sxs-lookup"><span data-stu-id="73ada-131">After the program has run through the intended scenarios, find the pgosweep.exe tool located in the same folder where you found the appropriate version of `pgort140.dll`.</span></span> <span data-ttu-id="73ada-132">または、Visual Studio (x86/x64) Native Tools コマンド プロンプトに、既にそのパスの適切なバージョンが設定されています。</span><span class="sxs-lookup"><span data-stu-id="73ada-132">Alternately, a Visual Studio (x86/x64) Native Tools command prompt will already have the appropriate version in its path.</span></span> <span data-ttu-id="73ada-133">PGOデータを収集するには、アプリケーションの実行中に次のコマンドを実行し、プロファイリング データを含む .pgc ファイルを生成します。</span><span class="sxs-lookup"><span data-stu-id="73ada-133">To gather the PGO data, run the following command while the application is still running to generate a .pgc file that will contain the profiling data:</span></span>
 
  `pgosweep.exe <executable name> <output file>` 
 
  <span data-ttu-id="73ada-134">PGO データの収集方法を制御する他のオプションの引数を確認するために、pgosweep.exe のヘルプ (`pgosweep.exe /help`) を表示することもできます。</span><span class="sxs-lookup"><span data-stu-id="73ada-134">You can also look at the pgosweep.exe help (`pgosweep.exe /help`) to view other optional arguments for controlling the way you gather PGO data.</span></span>
 
  <span data-ttu-id="73ada-135">.pgd が含まれるビルド場所に .pgc ファイルを出力し、ファイルに `<PGDName>!<RunIdentifier>.pgc` という名前を付けることもお勧めします。</span><span class="sxs-lookup"><span data-stu-id="73ada-135">It is a good idea to output the .pgc files into the build location where the .pgd is located, and also to name the files `<PGDName>!<RunIdentifier>.pgc`.</span></span> <span data-ttu-id="73ada-136">この例では、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="73ada-136">For this example, this meant:</span></span>
 
  ```
  pgosweep.exe App1.exe “C:\Users\<USER>\Documents\Visual Studio 2015\Projects\App1\Release\App1\App1!1.pgc”
  ```
 
  <span data-ttu-id="73ada-137">さらに収集する場合は、`App1!CoreScenario.pgc`、`App1!UseCase5.pgc` などのようにもできます。.pgc の名前をこのように付け、ビルドの出力場所が .pgd の隣である場合、手順 9 でリンクするときに自動的にマージされます。</span><span class="sxs-lookup"><span data-stu-id="73ada-137">Further gathering could also be `App1!CoreScenario.pgc`, `App1!UseCase5.pgc`, etc. If the .pgc files are named in this way and in the build output location alongside the .pgd, they will be automatically merged when linking in step 9.</span></span>
 
8. <span data-ttu-id="73ada-138">省略可能: 既定では、手順 7 で指定したように名前を付け、.pgd の隣に配置した .pgc ファイルはすべて、リンクするときにマージされ、平等に重み付けされますが、特定の実行に重みを付ける方法をより詳細に制御することもできます。</span><span class="sxs-lookup"><span data-stu-id="73ada-138">OPTIONAL: By default, all .pgc files named as specified in step 7 and placed next to the .pgd will be merged when linking and weighted equally, but you can also have greater control over how particular runs are weighted.</span></span> <span data-ttu-id="73ada-139">これを行うには、**pgomgr.exe** ツールを使用します。このツールも、最初に `pgort140.dll` のコピーを見つけたフォルダーと同じフォルダーにあります。</span><span class="sxs-lookup"><span data-stu-id="73ada-139">To do this, you will use the **pgomgr.exe** tool also located in the same folder where you first found the copy of `pgort140.dll`.</span></span> <span data-ttu-id="73ada-140">たとえば、`CoreScenario` の実行を他の実行の優先度の 3 倍でマージするには、次のコマンドを使用します。</span><span class="sxs-lookup"><span data-stu-id="73ada-140">For example, to merge the `CoreScenario` run with 3 times the priority of other runs, I can use the following command:</span></span>
 
 ```
 pgomgr.exe -merge:3 “C:\Users\<USER>\Documents\Visual Studio 2015\Projects\App1\Release\App1\App1!CoreScenario.pgc” “C:\Users\<USER>\Documents\Visual Studio 2015\Projects\App1\Release\App1\App1.pgd”
 ```
 
9. <span data-ttu-id="73ada-141">1 つ以上の .pgc ファイルを生成し、それを .pgd の隣に配置するか手動でマージ (手順 8) したら、リンカーを使用して最終的な最適化されたビルドを作成できます。</span><span class="sxs-lookup"><span data-stu-id="73ada-141">After you have generated one or more .pgc files and either placed them alongside your .pgd or manually merged them (step 8), we can now use the linker to create the final optimized build.</span></span> <span data-ttu-id="73ada-142">リンカーのプロパティ (**[プロパティ]** > **[リンカー]** > **[最適化]**) に戻り、**[リンク時のコード生成]** を **[ガイド付き最適化のプロファイル - 最適化 (LTCG:PGOptimize)]** に設定したら、**[ガイド付きデータベースのプロファイル]** が使用予定の .pgd をポイントしていることを確認します (これを変更していない場合、すべてを順序どおりにする必要があります)。</span><span class="sxs-lookup"><span data-stu-id="73ada-142">Go back into your linker properties (**Properties** > **Linker** > **Optimization**) and set **Link Time Code Generation** to **Profile Guided Optimization - Optimization (LTCG:PGOptimize)** and verify that **Profile Guided Database** is pointing at the .pgd that you intend to use (if you have not changed this, everything should be in order).</span></span>

 ![[新しいプロジェクト] ダイアログ ボックス](images/pgo-009.png)
 
10. <span data-ttu-id="73ada-144">プロジェクトがビルドされたら、リンカーによって pgomgr.exe が呼び出され、すべての `<PGDName>!*.pgc` ファイルが既定の重み 1 が設定された .pgd にマージされます。作成されるアプリケーションは、プロファイリング データに基づいて最適化されます。</span><span class="sxs-lookup"><span data-stu-id="73ada-144">Now when the project is built, the linker will call pgomgr.exe to merge any `<PGDName>!*.pgc` files into the .pgd with the default weight of 1, and the resulting application will be optimized based on the profiling data.</span></span>

## <a name="see-also"></a><span data-ttu-id="73ada-145">参照</span><span class="sxs-lookup"><span data-stu-id="73ada-145">See also</span></span>
- [<span data-ttu-id="73ada-146">パフォーマンス</span><span class="sxs-lookup"><span data-stu-id="73ada-146">Performance</span></span>](performance-and-xaml-ui.md)

 

