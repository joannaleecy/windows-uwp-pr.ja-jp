---
author: GrantMeStrength
ms.assetid: DC235C16-8DAF-4078-9365-6612A10F3EC3
title: 作成、Hello World アプリでは、C++/CX (windows 10)
description: Microsoft Visual の Studio2017 を使用できます C + + CX windows 10 を実行するスマート フォンなど、windows 10 で実行されるアプリの開発にします。 これらのアプリでは、Extensible Application Markup Language (XAML) で定義された UI を使います。
ms.author: jken
ms.date: 06/11/2018
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: bc2258557c492956130424069e6e0c4b73f28056
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/02/2018
ms.locfileid: "5943803"
---
# <a name="create-a-hello-world-app-in-ccx"></a><span data-ttu-id="16ccf-105">"Hello world"アプリで作成する C + + CX</span><span class="sxs-lookup"><span data-stu-id="16ccf-105">Create a "Hello world" app in C++/CX</span></span>

> [!IMPORTANT]
> <span data-ttu-id="16ccf-106">このチュートリアルでは、C++/cli CX します。</span><span class="sxs-lookup"><span data-stu-id="16ccf-106">This tutorial uses C++/CX.</span></span> <span data-ttu-id="16ccf-107">Microsoft がリリースされると、C++/WinRT: 完全に標準化された最新の c++ 17 言語プロジェクション Windows ランタイム (WinRT) Api のです。</span><span class="sxs-lookup"><span data-stu-id="16ccf-107">Microsoft has released C++/WinRT: an entirely standard modern C++17 language projection for Windows Runtime (WinRT) APIs.</span></span> <span data-ttu-id="16ccf-108">この言語について詳しくを参照してください[、C++/WinRT](https://docs.microsoft.com/windows/uwp/cpp-and-winrt-apis/)します。</span><span class="sxs-lookup"><span data-stu-id="16ccf-108">For more information on this language, please see [C++/WinRT](https://docs.microsoft.com/windows/uwp/cpp-and-winrt-apis/).</span></span> 

<span data-ttu-id="16ccf-109">Microsoft Visual の Studio2017 を使用できます C + + CX Extensible Application Markup Language (XAML) で定義された UI と windows 10 で実行されるアプリの開発にします。</span><span class="sxs-lookup"><span data-stu-id="16ccf-109">With Microsoft Visual Studio2017, you can use C++/CX to develop an app that runs on Windows10 with a UI that's defined in Extensible Application Markup Language (XAML).</span></span>

> [!NOTE]
> <span data-ttu-id="16ccf-110">このチュートリアルでは、Visual Studio Community 2017 を使用します。</span><span class="sxs-lookup"><span data-stu-id="16ccf-110">This tutorial uses Visual Studio Community 2017.</span></span> <span data-ttu-id="16ccf-111">異なるバージョンの Visual Studio を使っている場合には、見た目が多少異なることがあります。</span><span class="sxs-lookup"><span data-stu-id="16ccf-111">If you are using a different version of Visual Studio, it may look a little different for you.</span></span>

## <a name="before-you-start"></a><span data-ttu-id="16ccf-112">開始前の作業</span><span class="sxs-lookup"><span data-stu-id="16ccf-112">Before you start</span></span>

-   <span data-ttu-id="16ccf-113">このチュートリアルを完了するには、windows 10 を実行しているコンピューターで Visual StudioCommunity 2017 か、Community バージョン以外の Visual Studio2017 のいずれかを使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="16ccf-113">To complete this tutorial, you must use Visual StudioCommunity 2017, or one of the non-Community versions of Visual Studio2017, on a computer that's running Windows10.</span></span> <span data-ttu-id="16ccf-114">ツールをダウンロードするには、[ツールの入手に関するページ](http://go.microsoft.com/fwlink/p/?LinkId=532666)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="16ccf-114">To download, see [Get the tools](http://go.microsoft.com/fwlink/p/?LinkId=532666).</span></span>
-   <span data-ttu-id="16ccf-115">C + の基本的な知識があると仮定すると/CX、XAML では、 [XAML の概要](https://msdn.microsoft.com/library/windows/apps/Mt185595)で説明されている概念です。</span><span class="sxs-lookup"><span data-stu-id="16ccf-115">We assume you have a basic understanding of C++/CX, XAML, and the concepts in the [XAML overview](https://msdn.microsoft.com/library/windows/apps/Mt185595).</span></span>
-   <span data-ttu-id="16ccf-116">Visual Studio の既定のウィンドウ レイアウトを使用することを前提としています。</span><span class="sxs-lookup"><span data-stu-id="16ccf-116">We assume you're using the default window layout in Visual Studio.</span></span> <span data-ttu-id="16ccf-117">既定のレイアウトに戻すには、メニュー バーで **[ウィンドウ]**、**[ウィンドウ レイアウトのリセット]** の順にクリックします。</span><span class="sxs-lookup"><span data-stu-id="16ccf-117">To reset to the default layout, on the menu bar, choose **Window** > **Reset Window Layout**.</span></span>

## <a name="comparing-c-desktop-apps-to-windows-apps"></a><span data-ttu-id="16ccf-118">C++ デスクトップ アプリと Windows アプリの比較</span><span class="sxs-lookup"><span data-stu-id="16ccf-118">Comparing C++ desktop apps to Windows apps</span></span>

<span data-ttu-id="16ccf-119">C++ を使った Windows デスクトップのプログラミングに関する経験がある場合、UWP 用アプリのプログラミングには、通常の C++ プログラミングと同じ部分もありますが、新しい知識が必要になる部分もあります。</span><span class="sxs-lookup"><span data-stu-id="16ccf-119">If you're coming from a background in Windows desktop programming in C++, you'll probably find that some aspects of writing apps for the UWP are familiar, but other aspects require some learning.</span></span>

### <a name="whats-the-same"></a><span data-ttu-id="16ccf-120">同じ部分</span><span class="sxs-lookup"><span data-stu-id="16ccf-120">What's the same?</span></span>

-   <span data-ttu-id="16ccf-121">コードのみが、Windows ランタイム環境からアクセス可能な Windows 関数を呼び出していれば、STL と CRT (一部例外あり)、やその他のあらゆる C++ ライブラリを使用することができます。</span><span class="sxs-lookup"><span data-stu-id="16ccf-121">You can use the STL, the CRT (with some exceptions), and any other C++ library as long as the code only calls Windows functions that are accessible from the Windows Runtime environment.</span></span>

-   <span data-ttu-id="16ccf-122">使い慣れたビジュアル デザイナーがある場合は、Microsoft Visual Studio に組み込まれたデザイナーを引き続き使うことができます。また、より多機能な Blend for Visual Studio を使うこともできます。</span><span class="sxs-lookup"><span data-stu-id="16ccf-122">If you're accustomed to visual designers, you can still use the designer built into Microsoft Visual Studio, or you can use the more full-featured Blend for Visual Studio.</span></span> <span data-ttu-id="16ccf-123">手動で UI のコーディングを行うことに慣れている場合は、XAML を手動で記述できます。</span><span class="sxs-lookup"><span data-stu-id="16ccf-123">If you're accustomed to coding UI by hand, you can hand-code your XAML.</span></span>

-   <span data-ttu-id="16ccf-124">Windows オペレーティング システムの型と独自のカスタム型を使うアプリをこれまでどおり作成します。</span><span class="sxs-lookup"><span data-stu-id="16ccf-124">You're still creating apps that use Windows operating system types and your own custom types.</span></span>

-   <span data-ttu-id="16ccf-125">Visual Studio のデバッガー、プロファイラー、その他開発ツールをこれまでどおり使います。</span><span class="sxs-lookup"><span data-stu-id="16ccf-125">You're still using the Visual Studio debugger, profiler, and other development tools.</span></span>

-   <span data-ttu-id="16ccf-126">Visual C++ コンパイラでネイティブ マシン コードにコンパイルされるアプリを引き続き作成します。</span><span class="sxs-lookup"><span data-stu-id="16ccf-126">You're still creating apps that are compiled to native machine code by the Visual C++ compiler.</span></span> <span data-ttu-id="16ccf-127">UWP アプリでは、C++/cli CX は、マネージ ランタイム環境で実行しないでください。</span><span class="sxs-lookup"><span data-stu-id="16ccf-127">UWP apps in C++/CX don't execute in a managed runtime environment.</span></span>

### <a name="whats-new"></a><span data-ttu-id="16ccf-128">最新情報</span><span class="sxs-lookup"><span data-stu-id="16ccf-128">What's new?</span></span>

-   <span data-ttu-id="16ccf-129">UWP アプリとユニバーサル Windows アプリの設計原則は、デスクトップ アプリの設計原則とは大きく異なります。</span><span class="sxs-lookup"><span data-stu-id="16ccf-129">The design principles for UWP apps and Universal Windows apps are very different from those for desktop apps.</span></span> <span data-ttu-id="16ccf-130">ウィンドウの境界線、ラベル、ダイアログ ボックスなどの強調は解除され、</span><span class="sxs-lookup"><span data-stu-id="16ccf-130">Window borders, labels, dialog boxes, and so on, are de-emphasized.</span></span> <span data-ttu-id="16ccf-131">コンテンツが最も目立つように表示されます。</span><span class="sxs-lookup"><span data-stu-id="16ccf-131">Content is foremost.</span></span> <span data-ttu-id="16ccf-132">優れたユニバーサル Windows アプリには、こうした原則が計画段階の初期から活かされています。</span><span class="sxs-lookup"><span data-stu-id="16ccf-132">Great Universal Windows apps incorporate these principles from the very beginning of the planning stage.</span></span>

-   <span data-ttu-id="16ccf-133">XAML を使って UI 全体を定義します。</span><span class="sxs-lookup"><span data-stu-id="16ccf-133">You're using XAML to define the entire UI.</span></span> <span data-ttu-id="16ccf-134">Windows ユニバーサル アプリでは、MFC アプリや Win32 アプリよりもはるかに明確に UI と基本的なプログラム ロジックが分離されます。</span><span class="sxs-lookup"><span data-stu-id="16ccf-134">The separation between UI and core program logic is much clearer in a Windows Universal app than in an MFC or Win32 app.</span></span> <span data-ttu-id="16ccf-135">XAML を使った UI の見た目の調整と、コード ファイルでの動作のプログラミングを、異なる担当者が並行して行うことができます。</span><span class="sxs-lookup"><span data-stu-id="16ccf-135">Other people can work on the appearance of the UI in the XAML file while you're working on the behavior in the code file.</span></span>

-   <span data-ttu-id="16ccf-136">プログラミングの対象は主に Windows ランタイム (操作しやすい、オブジェクト指向の新しい API) ですが、Windowsデバイス上で一部の機能にこれまでどおり Win32 を使うこともできます。</span><span class="sxs-lookup"><span data-stu-id="16ccf-136">You're primarily programming against a new, easy-to-navigate, object-oriented API, the Windows Runtime, although on Windows devices Win32 is still available for some functionality.</span></span>

-   <span data-ttu-id="16ccf-137">Windows ランタイムのオブジェクトを利用したり作成したりするには C++/CX を使います。</span><span class="sxs-lookup"><span data-stu-id="16ccf-137">You use C++/CX to consume and create Windows Runtime objects.</span></span> <span data-ttu-id="16ccf-138">C++/CX は、C++ の例外処理、デリゲート、イベントのほか、動的に作成されるオブジェクトの自動参照カウントに対応しています。</span><span class="sxs-lookup"><span data-stu-id="16ccf-138">C++/CX enables C++ exception handling, delegates, events, and automatic reference counting of dynamically created objects.</span></span> <span data-ttu-id="16ccf-139">C++/CX を使うとき、ベースの COM と Windows アーキテクチャの詳細は、アプリ コードからは見えません。</span><span class="sxs-lookup"><span data-stu-id="16ccf-139">When you use C++/CX, the details of the underlying COM and Windows architecture are hidden from your app code.</span></span> <span data-ttu-id="16ccf-140">詳しくは、「[C++/CX 言語のリファレンス](https://msdn.microsoft.com/library/windows/apps/hh699871.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="16ccf-140">For more information, see [C++/CX Language Reference](https://msdn.microsoft.com/library/windows/apps/hh699871.aspx).</span></span>

-   <span data-ttu-id="16ccf-141">アプリは、そのアプリ自体に含まれる型、アプリで使うリソース、必要な機能 (ファイル アクセス、インターネット アクセス、カメラ アクセスなど) に関するメタデータも含むパッケージにコンパイルされます。</span><span class="sxs-lookup"><span data-stu-id="16ccf-141">Your app is compiled into a package that also contains metadata about the types that your app contains, the resources that it uses, and the capabilities that it requires (file access, internet access, camera access, and so forth).</span></span>

-   <span data-ttu-id="16ccf-142">Microsoft Store と Windows Phone ストアでは、認定プロセスを通じてアプリの安全性が検証され、何百万ものユーザーに公開されます。</span><span class="sxs-lookup"><span data-stu-id="16ccf-142">In the Microsoft Store and Windows Phone Store your app is verified as safe by a certification process and made discoverable to millions of potential customers.</span></span>

## <a name="hello-world-store-app-in-ccx"></a><span data-ttu-id="16ccf-143">Hello World ストア アプリでは、C++/cli CX</span><span class="sxs-lookup"><span data-stu-id="16ccf-143">Hello World Store app in C++/CX</span></span>

<span data-ttu-id="16ccf-144">初めてのアプリは "Hello World" という名前です。このアプリでは、インタラクティビティ、レイアウト、スタイルに関する基本的な機能の使い方を学びます。</span><span class="sxs-lookup"><span data-stu-id="16ccf-144">Our first app is a "Hello World" that demonstrates some basic features of interactivity, layout, and styles.</span></span> <span data-ttu-id="16ccf-145">アプリは、Windows ユニバーサル アプリ プロジェクト テンプレートを使って作成します。</span><span class="sxs-lookup"><span data-stu-id="16ccf-145">We'll create an app from the Windows Universal app project template.</span></span> <span data-ttu-id="16ccf-146">Windows8.1 や Windows Phone 8.1 用アプリを開発した場合は、3 つのプロジェクトを Visual Studio、Windows アプリの 1 つは、電話アプリと共有コード用に 1 つである必要がある注意してください可能性があります。</span><span class="sxs-lookup"><span data-stu-id="16ccf-146">If you've developed apps for Windows8.1 and Windows Phone 8.1 before, you might remember that you had to have three projects in Visual Studio, one for the Windows app, one for the phone app, and another with shared code.</span></span> <span data-ttu-id="16ccf-147">Windows 10 のユニバーサル Windows プラットフォーム (UWP) などの windows 10、タブレット、携帯電話、VR デバイスなどのデバイスを実行しているコンピューターのデスクトップやノート pc、すべてのデバイスで実行されているプロジェクトが 1 つだけすることもできます。</span><span class="sxs-lookup"><span data-stu-id="16ccf-147">The Windows10 Universal Windows Platform (UWP) makes it possible to have just one project, which runs on all devices, including desktop and laptop computers running Windows10, devices such as tablets, mobile phones, VR devices and so on.</span></span>

<span data-ttu-id="16ccf-148">それでは、次に示す基礎から始めましょう。</span><span class="sxs-lookup"><span data-stu-id="16ccf-148">We'll start with the basics:</span></span>

-   <span data-ttu-id="16ccf-149">Visual Studio2017 でユニバーサル Windows プロジェクトを作成する方法。</span><span class="sxs-lookup"><span data-stu-id="16ccf-149">How to create a Universal Windows project in Visual Studio2017.</span></span>

-   <span data-ttu-id="16ccf-150">作成されるプロジェクトとファイルを把握する方法。</span><span class="sxs-lookup"><span data-stu-id="16ccf-150">How to understand the projects and files that are created.</span></span>

-   <span data-ttu-id="16ccf-151">VisualC ではコンポーネント拡張機能内の拡張機能を把握する方法 (、C++/cli CX)、およびそれらを使用する場合。</span><span class="sxs-lookup"><span data-stu-id="16ccf-151">How to understand the extensions in VisualC++ component extensions (C++/CX), and when to use them.</span></span>

**<span data-ttu-id="16ccf-152">まず Visual Studio でソリューションを作成する</span><span class="sxs-lookup"><span data-stu-id="16ccf-152">First, create a solution in Visual Studio</span></span>**

1.  <span data-ttu-id="16ccf-153">Visual Studio のメニュー バーから **[ファイル]**、**[新規作成]**、**[プロジェクト]** の順にクリックします。</span><span class="sxs-lookup"><span data-stu-id="16ccf-153">In Visual Studio, on the menu bar, choose **File** > **New** > **Project**.</span></span>

2.  <span data-ttu-id="16ccf-154">**[新しいプロジェクト]** ダイアログ ボックスの左側のウィンドウで、**[インストール済み]** > **[Visual C++]** > **[Windows ユニバーサル]** の順に展開します。</span><span class="sxs-lookup"><span data-stu-id="16ccf-154">In the **New Project** dialog box, in the left pane, expand **Installed** > **Visual C++** > **Windows Universal**.</span></span>

> [!NOTE]
> <span data-ttu-id="16ccf-155">C++ での開発用に Windowsユニバーサル ツールをインストールするように求められることもあります。</span><span class="sxs-lookup"><span data-stu-id="16ccf-155">You may be prompted to install the Windows Universal tools for C++ development.</span></span>

3.  <span data-ttu-id="16ccf-156">中央のウィンドウで、**[空のアプリ (Windows ユニバーサル)]** テンプレートを選びます。</span><span class="sxs-lookup"><span data-stu-id="16ccf-156">In the center pane, select **Blank App (Universal Windows)**.</span></span>

   <span data-ttu-id="16ccf-157">これらのオプションが見つからない場合は、ユニバーサル Windows アプリ開発ツールがインストールされていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="16ccf-157">(If you don't see these options, make sure you have the Universal Windows App Development Tools installed.</span></span> <span data-ttu-id="16ccf-158">詳しくは、「[準備](get-set-up.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="16ccf-158">See [Get set up](get-set-up.md) for more info.)</span></span>

4.  <span data-ttu-id="16ccf-159">プロジェクトの名前を入力します。</span><span class="sxs-lookup"><span data-stu-id="16ccf-159">Enter a name for the project.</span></span> <span data-ttu-id="16ccf-160">ここでは、名前を "HelloWorld" とします。</span><span class="sxs-lookup"><span data-stu-id="16ccf-160">We'll name it HelloWorld.</span></span>

 ![<span data-ttu-id="16ccf-161">C++/cli で新しいプロジェクト] ダイアログ ボックスの CX プロジェクト テンプレート</span><span class="sxs-lookup"><span data-stu-id="16ccf-161">C++/CX project templates in the New Project dialog box</span></span> ](images/vs2017-uwp-01.png)

5.  <span data-ttu-id="16ccf-162">**[OK]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="16ccf-162">Choose the **OK** button.</span></span>

> [!NOTE]
> <span data-ttu-id="16ccf-163">Visual Studio を初めて使う場合は、[設定] ダイアログ ボックスが表示され、**開発者モード**を有効にするよう求められることがあります。</span><span class="sxs-lookup"><span data-stu-id="16ccf-163">If this is the first time you have used Visual Studio, you might see a Settings dialog asking you to enable **Developer mode**.</span></span> <span data-ttu-id="16ccf-164">開発者モードは、アプリをストアからだけではなく、直接実行するためのアクセス許可など、特定の機能を有効にする特別な設定です。</span><span class="sxs-lookup"><span data-stu-id="16ccf-164">Developer mode is a special setting that enables certain features, such as permission to run apps directly, rather than only from the Store.</span></span> <span data-ttu-id="16ccf-165">詳しくは、「[デバイスを開発用に有効にする](enable-your-device-for-development.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="16ccf-165">For more information, please read [Enable your device for development](enable-your-device-for-development.md).</span></span> <span data-ttu-id="16ccf-166">先に進むには、**[開発者モード]** を選択し、**[はい]** をクリックしてダイアログ ボックスを閉じます。</span><span class="sxs-lookup"><span data-stu-id="16ccf-166">To continue with this guide, select **Developer mode**, click **Yes**, and close the dialog.</span></span>

   <span data-ttu-id="16ccf-167">プロジェクト ファイルが作られます。</span><span class="sxs-lookup"><span data-stu-id="16ccf-167">Your project files are created.</span></span>

<span data-ttu-id="16ccf-168">先に進む前に、ソリューションの構成内容を調べてみましょう。</span><span class="sxs-lookup"><span data-stu-id="16ccf-168">Before we go on, let’s look at what's in the solution.</span></span>

![ユニバーサル アプリ ソリューション (ノードを折りたたんだところ)](images/vs2017-uwp-02.png)

### <a name="about-the-project-files"></a><span data-ttu-id="16ccf-170">プロジェクト ファイルについて</span><span class="sxs-lookup"><span data-stu-id="16ccf-170">About the project files</span></span>

<span data-ttu-id="16ccf-171">プロジェクト フォルダー内のすべての .xaml ファイルには、対応する .xaml.h ファイルと .xaml.cpp ファイルが同じフォルダーに、.g ファイルと .g.hpp ファイルが [生成されたファイル] フォルダーにそれぞれ存在します。このフォルダーはプロジェクト内ではなく、ディスク上にあります。</span><span class="sxs-lookup"><span data-stu-id="16ccf-171">Every .xaml file in a project folder has a corresponding .xaml.h file and .xaml.cpp file in the same folder and a .g file and a .g.hpp file in the Generated Files folder, which is on disk but not part of the project.</span></span> <span data-ttu-id="16ccf-172">UI 要素を作成してデータ ソースに接続 (DataBinding) するには、XAML ファイルに変更を加えます。</span><span class="sxs-lookup"><span data-stu-id="16ccf-172">You modify the XAML files to create UI elements and connect them to data sources (DataBinding).</span></span> <span data-ttu-id="16ccf-173">イベント ハンドラーにカスタム ロジックを追加するには、.h ファイルと .cpp ファイルに変更を加えます。</span><span class="sxs-lookup"><span data-stu-id="16ccf-173">You modify the .h and .cpp files to add custom logic for event handlers.</span></span> <span data-ttu-id="16ccf-174">自動生成されたファイルには、C++、XAML マークアップの変換を表す/CX します。</span><span class="sxs-lookup"><span data-stu-id="16ccf-174">The auto-generated files represent the transformation of the XAML markup into C++/CX.</span></span> <span data-ttu-id="16ccf-175">これらのファイルは変更しないでください。ただし、ファイルを観察すると、分離コードの働きをより深く理解できます。</span><span class="sxs-lookup"><span data-stu-id="16ccf-175">Don't modify these files, but you can study them to better understand how the code-behind works.</span></span> <span data-ttu-id="16ccf-176">基本的に、生成されたファイルには、XAML ルート要素の部分クラスの定義が記述されています。これは、\*.xaml.h ファイルや .cpp ファイルで変更するクラスと同じです。</span><span class="sxs-lookup"><span data-stu-id="16ccf-176">Basically, the generated file contains a partial class definition for a XAML root element; this class is the same class that you modify in the \*.xaml.h and .cpp files.</span></span> <span data-ttu-id="16ccf-177">生成されたファイルには、XAML UI の子要素がクラスのメンバーとして宣言されており、開発者がコードの中で参照することができます。</span><span class="sxs-lookup"><span data-stu-id="16ccf-177">The generated files declare the XAML UI child elements as class members so that you can reference them in the code you write.</span></span> <span data-ttu-id="16ccf-178">ビルド時には、生成されたコードと自分で記述したコードとがマージされてクラス定義が完成し、コンパイルされます。</span><span class="sxs-lookup"><span data-stu-id="16ccf-178">At build time, the generated code and your code are merged into a complete class definition and then compiled.</span></span>

<span data-ttu-id="16ccf-179">まずプロジェクト ファイルを見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="16ccf-179">Let's look first at the project files.</span></span>

-   <span data-ttu-id="16ccf-180">**App.xaml、App.xaml.h、App.xaml.cpp:** アプリのエントリ ポイントとなる Application オブジェクトを表します。</span><span class="sxs-lookup"><span data-stu-id="16ccf-180">**App.xaml, App.xaml.h, App.xaml.cpp:** Represent the Application object, which is an app's entry point.</span></span> <span data-ttu-id="16ccf-181">App.xaml に、ページ固有の UI マークアップは含まれませんが、UI のスタイルなどの要素を追加して任意のページからアクセスすることができます。</span><span class="sxs-lookup"><span data-stu-id="16ccf-181">App.xaml contains no page-specific UI markup, but you can add UI styles and other elements that you want to be accessible from any page.</span></span> <span data-ttu-id="16ccf-182">分離コード ファイルには、**OnLaunched** イベントと **OnSuspending** イベントのハンドラーが含まれます。</span><span class="sxs-lookup"><span data-stu-id="16ccf-182">The code-behind files contain handlers for the **OnLaunched** and **OnSuspending** events.</span></span> <span data-ttu-id="16ccf-183">通常、ここには、起動時にアプリを初期化したり、中断または終了時にクリーンアップ処理を実行したりするためのカスタム コードを追加します。</span><span class="sxs-lookup"><span data-stu-id="16ccf-183">Typically, you add custom code here to initialize your app when it starts and perform cleanup when it's suspended or terminated.</span></span>
-   <span data-ttu-id="16ccf-184">**MainPage.xaml、MainPage.xaml.h、MainPage.xaml.cpp:** アプリの既定の "スタート" ページに使う XAML マークアップと分離コードが記述されます。</span><span class="sxs-lookup"><span data-stu-id="16ccf-184">**MainPage.xaml, MainPage.xaml.h, MainPage.xaml.cpp:** Contain the XAML markup and code-behind for the default "start" page in an app.</span></span> <span data-ttu-id="16ccf-185">ナビゲーション サポートやビルトイン コントロールはありません。</span><span class="sxs-lookup"><span data-stu-id="16ccf-185">It has no navigation support or built-in controls.</span></span>
-   <span data-ttu-id="16ccf-186">**pch.h、pch.cpp:** プリコンパイル済みヘッダー ファイルと、それをプロジェクトにインクルードするファイルです。</span><span class="sxs-lookup"><span data-stu-id="16ccf-186">**pch.h, pch.cpp:** A precompiled header file and the file that includes it in your project.</span></span> <span data-ttu-id="16ccf-187">pch.h には、変更頻度が低く、ソリューション内の他のファイルにインクルードされるヘッダーを含めることができます。</span><span class="sxs-lookup"><span data-stu-id="16ccf-187">In pch.h, you can include any headers that do not change often and are included in other files in the solution.</span></span>
-   <span data-ttu-id="16ccf-188">**Package.appxmanifest:** アプリが必要とするデバイスの機能や、アプリのバージョン情報などのメタデータを表す XML ファイルです。</span><span class="sxs-lookup"><span data-stu-id="16ccf-188">**Package.appxmanifest:** An XML file that describes the device capabilities that your app requires, and the app version info and other metadata.</span></span> <span data-ttu-id="16ccf-189">このファイルをダブルクリックすると、**マニフェスト デザイナー**で開くことができます。</span><span class="sxs-lookup"><span data-stu-id="16ccf-189">To open this file in the **Manifest Designer**, just double-click it.</span></span>
-   <span data-ttu-id="16ccf-190">**HelloWorld\_TemporaryKey.pfx:** Visual Studio から対象のコンピューター上にアプリを展開するためのキーです。</span><span class="sxs-lookup"><span data-stu-id="16ccf-190">**HelloWorld\_TemporaryKey.pfx:** A key that enables deployment of the app on this machine, from Visual Studio.</span></span>

## <a name="a-first-look-at-the-code"></a><span data-ttu-id="16ccf-191">初めてのコード</span><span class="sxs-lookup"><span data-stu-id="16ccf-191">A first look at the code</span></span>

<span data-ttu-id="16ccf-192">共有プロジェクト内の App.xaml.h と App.xaml.cpp のコードをよく見ると、ほとんどが、見覚えのある ISO C++ コードであることがわかります。</span><span class="sxs-lookup"><span data-stu-id="16ccf-192">If you examine the code in App.xaml.h, App.xaml.cpp in the shared project, you'll notice that it's mostly C++ code that looks familiar.</span></span> <span data-ttu-id="16ccf-193">ただし、Windows ランタイム アプリの開発が初めての場合や、これまで C++/CLI で作業を行ってきた場合は、あまり馴染みのない構文要素も中には存在します。</span><span class="sxs-lookup"><span data-stu-id="16ccf-193">However, some syntax elements might not be as familiar if you are new to Windows Runtime apps, or you've worked with C++/CLI.</span></span> <span data-ttu-id="16ccf-194">C++/CX でよく使われる標準的ではない構文要素を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="16ccf-194">Here are the most common non-standard syntax elements you'll see in C++/CX:</span></span>

**<span data-ttu-id="16ccf-195">ref クラス</span><span class="sxs-lookup"><span data-stu-id="16ccf-195">Ref classes</span></span>**

<span data-ttu-id="16ccf-196">Windows ランタイムのほぼすべてのクラスは、Windows API のすべての型 (XAML コントロール、アプリ内のページ、App クラス自体、すべてのデバイス オブジェクトとネットワーク オブジェクト、すべてのコンテナー型) を含んでおり、**ref クラス** として宣言されます </span><span class="sxs-lookup"><span data-stu-id="16ccf-196">Almost all Windows Runtime classes, which includes all the types in the Windows API--XAML controls, the pages in your app, the App class itself, all device and network objects, all container types--are declared as a **ref class**.</span></span> <span data-ttu-id="16ccf-197">(**value class** または **value struct** の Windows 型もわずかに存在します)。</span><span class="sxs-lookup"><span data-stu-id="16ccf-197">(A few Windows types are **value class** or **value struct**).</span></span> <span data-ttu-id="16ccf-198">ref クラスはすべての言語から利用できます。</span><span class="sxs-lookup"><span data-stu-id="16ccf-198">A ref class is consumable from any language.</span></span> <span data-ttu-id="16ccf-199">C++/cli CX、これらの型の有効期間は自動参照されるため、これらのオブジェクトを明示的に削除する (ガベージ コレクションではなく) をカウントによって制御されます。</span><span class="sxs-lookup"><span data-stu-id="16ccf-199">In C++/CX, the lifetime of these types is governed by automatic reference counting (not garbage collection) so that you never explicitly delete these objects.</span></span> <span data-ttu-id="16ccf-200">ref クラスは独自に作成することもできます。</span><span class="sxs-lookup"><span data-stu-id="16ccf-200">You can create your own ref classes as well.</span></span>

```cpp
namespace HelloWorld
{
   /// <summary>
   /// An empty page that can be used on its own or navigated to within a Frame.
   /// </summary>
   public ref class MainPage sealed
   {
      public:
      MainPage();
   };
}
```    

<span data-ttu-id="16ccf-201">Windows ランタイムのすべての型は名前空間内で宣言する必要があり、ISO C++ の場合は異なり、型そのものがアクセシビリティ修飾子を持ちます。</span><span class="sxs-lookup"><span data-stu-id="16ccf-201">All Windows Runtime types must be declared within a namespace and unlike in ISO C++ the types themselves have an accessibility modifier.</span></span> <span data-ttu-id="16ccf-202">**public** 修飾子を持つクラスは、その名前空間の外の Windows ランタイム コンポーネントから参照することができます。</span><span class="sxs-lookup"><span data-stu-id="16ccf-202">The **public** modifier makes the class visible to Windows Runtime components outside the namespace.</span></span> <span data-ttu-id="16ccf-203">**sealed** キーワードは、基底クラスとして使うことができないことを意味します。</span><span class="sxs-lookup"><span data-stu-id="16ccf-203">The **sealed** keyword means the class cannot serve as a base class.</span></span> <span data-ttu-id="16ccf-204">ほとんどの ref クラスは sealed です。クラスの継承は、JavaScript が認識しないため、あまり広くは使われません。</span><span class="sxs-lookup"><span data-stu-id="16ccf-204">Almost all ref classes are sealed; class inheritance is not broadly used because Javascript does not understand it.</span></span>

<span data-ttu-id="16ccf-205">**ref new** と **^ (ハット)**</span><span class="sxs-lookup"><span data-stu-id="16ccf-205">**ref new** and **^ (hats)**</span></span>

<span data-ttu-id="16ccf-206">ref クラスの変数は ^ (ハット) 演算子を使って宣言します。ref new キーワードでオブジェクトをインスタンス化することができます。</span><span class="sxs-lookup"><span data-stu-id="16ccf-206">You declare a variable of a ref class by using the ^ (hat) operator, and you instantiate the object with the ref new keyword.</span></span> <span data-ttu-id="16ccf-207">それ以降、オブジェクトのインスタンス メソッドにアクセスする際は、C++ のポインターと同様の -> 演算子を使います。</span><span class="sxs-lookup"><span data-stu-id="16ccf-207">Thereafter you access the object's instance methods with the -> operator just like a C++ pointer.</span></span> <span data-ttu-id="16ccf-208">静的メソッドにアクセスする場合は、ISO C++ と同様、:: 演算子を使います。</span><span class="sxs-lookup"><span data-stu-id="16ccf-208">Static methods are accessed with the :: operator just as in ISO C++.</span></span>

<span data-ttu-id="16ccf-209">次のコードは、完全修飾名を使ってオブジェクトをインスタンス化し、-> 演算子を使ってインスタンス メソッドを呼び出しています。</span><span class="sxs-lookup"><span data-stu-id="16ccf-209">In the following code, we use the fully qualified name to instantiate an object, and use the -> operator to call an instance method.</span></span>

```cpp
Windows::UI::Xaml::Media::Imaging::BitmapImage^ bitmapImage =
     ref new Windows::UI::Xaml::Media::Imaging::BitmapImage();
      
bitmapImage->SetSource(fileStream);
```

<span data-ttu-id="16ccf-210">このコードは、.cpp ファイルで、`using namespace  Windows::UI::Xaml::Media::Imaging` ディレクティブと auto キーワードを追加し、次のように記述するのが一般的です。</span><span class="sxs-lookup"><span data-stu-id="16ccf-210">Typically, in a .cpp file we would add a `using namespace  Windows::UI::Xaml::Media::Imaging` directive and the auto keyword, so that the same code would look like this:</span></span>

```cpp
auto bitmapImage = ref new BitmapImage();
bitmapImage->SetSource(fileStream);
```

**<span data-ttu-id="16ccf-211">プロパティ</span><span class="sxs-lookup"><span data-stu-id="16ccf-211">Properties</span></span>**

<span data-ttu-id="16ccf-212">ref クラスにはプロパティを与えることができます。プロパティは、マネージ言語のプロパティと同様、それを利用する側のコードからはフィールドとして見える特殊なメンバー関数です。</span><span class="sxs-lookup"><span data-stu-id="16ccf-212">A ref class can have properties, which, just as in managed languages, are special member functions that appear as fields to consuming code.</span></span>

```cpp
public ref class SaveStateEventArgs sealed
{
   public:
   // Declare the property
   property Windows::Foundation::Collections::IMap<Platform::String^, Platform::Object^>^ PageState
   {
      Windows::Foundation::Collections::IMap<Platform::String^, Platform::Object^>^ get();
   }
   ...
};

   ...
   // consume the property like a public field
   void PhotoPage::SaveState(Object^ sender, Common::SaveStateEventArgs^ e)
   {    
      if (mruToken != nullptr && !mruToken->IsEmpty())
   {
      e->PageState->Insert("mruToken", mruToken);
   }
}
```

**<span data-ttu-id="16ccf-213">デリゲート</span><span class="sxs-lookup"><span data-stu-id="16ccf-213">Delegates</span></span>**

<span data-ttu-id="16ccf-214">マネージ言語と同様、デリゲートは、特定のシグニチャの関数をカプセル化する参照型です。</span><span class="sxs-lookup"><span data-stu-id="16ccf-214">Just as in managed languages, a delegate is a reference type that encapsulates a function with a specific signature.</span></span> <span data-ttu-id="16ccf-215">ほとんどの場合、イベントとそのハンドラーに使われます。</span><span class="sxs-lookup"><span data-stu-id="16ccf-215">They are most often used with events and event handlers</span></span>

```cpp
// Delegate declaration (within namespace scope)
public delegate void LoadStateEventHandler(Platform::Object^ sender, LoadStateEventArgs^ e);

// Event declaration (class scope)
public ref class NavigationHelper sealed
{
   public:
   event LoadStateEventHandler^ LoadState;
};

// Create the event handler in consuming class
MainPage::MainPage()
{
   auto navigationHelper = ref new Common::NavigationHelper(this);
   navigationHelper->LoadState += ref new Common::LoadStateEventHandler(this, &MainPage::LoadState);
}
```

## <a name="adding-content-to-the-app"></a><span data-ttu-id="16ccf-216">アプリへのコンテンツの追加</span><span class="sxs-lookup"><span data-stu-id="16ccf-216">Adding content to the app</span></span>

<span data-ttu-id="16ccf-217">それでは、アプリにコンテンツを追加しましょう。</span><span class="sxs-lookup"><span data-stu-id="16ccf-217">Let's add some content to the app.</span></span>

**<span data-ttu-id="16ccf-218">手順 1: スタート ページの変更</span><span class="sxs-lookup"><span data-stu-id="16ccf-218">Step 1: Modify your start page</span></span>**

1.  <span data-ttu-id="16ccf-219">**ソリューション エクスプローラー**で、MainPage.xaml を開きます。</span><span class="sxs-lookup"><span data-stu-id="16ccf-219">In **Solution Explorer**, open MainPage.xaml.</span></span>
2.  <span data-ttu-id="16ccf-220">ルート [**Grid**](https://msdn.microsoft.com/library/windows/apps/BR242704) の終了タグの直前に次の XAML を追加して、UI に使うコントロールを作成します。</span><span class="sxs-lookup"><span data-stu-id="16ccf-220">Create controls for the UI by adding the following XAML to the root [**Grid**](https://msdn.microsoft.com/library/windows/apps/BR242704), immediately before its closing tag.</span></span> <span data-ttu-id="16ccf-221">この XAML には、ユーザーの名前をたずねる [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/BR209652)、ユーザーの名前を受け取る [**TextBox**](https://msdn.microsoft.com/library/windows/apps/BR209683) 要素、[**Button**](https://msdn.microsoft.com/library/windows/apps/BR209265)、別の **TextBlock** 要素を持つ [**StackPanel**](https://msdn.microsoft.com/library/windows/apps/BR209635) が含まれます。</span><span class="sxs-lookup"><span data-stu-id="16ccf-221">It contains a [**StackPanel**](https://msdn.microsoft.com/library/windows/apps/BR209635) that has a [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/BR209652) that asks the user's name, a [**TextBox**](https://msdn.microsoft.com/library/windows/apps/BR209683) element that accepts the user's name, a [**Button**](https://msdn.microsoft.com/library/windows/apps/BR209265), and another **TextBlock** element.</span></span>

    ```xaml
    <StackPanel x:Name="contentPanel" Margin="120,30,0,0">
        <TextBlock HorizontalAlignment="Left" Text="Hello World" FontSize="36"/>
        <TextBlock Text="What's your name?"/>
        <StackPanel x:Name="inputPanel" Orientation="Horizontal" Margin="0,20,0,20">
            <TextBox x:Name="nameInput" Width="300" HorizontalAlignment="Left"/>
            <Button x:Name="inputButton" Content="Say &quot;Hello&quot;"/>
        </StackPanel>
        <TextBlock x:Name="greetingOutput"/>
    </StackPanel>
    ```

3.  <span data-ttu-id="16ccf-222">ここまでの作業で、ごく基本的なユニバーサル Windows アプリが作成されました。</span><span class="sxs-lookup"><span data-stu-id="16ccf-222">At this point, you have created a very basic Universal Windows app.</span></span> <span data-ttu-id="16ccf-223">UWP アプリの動作や外観を確かめるには、F5 キーを押してデバッグ モードでアプリをビルド、展開、起動します。</span><span class="sxs-lookup"><span data-stu-id="16ccf-223">To see what the UWP app looks like, press F5 to build, deploy, and run the app in debugging mode.</span></span>

<span data-ttu-id="16ccf-224">最初に、既定のスプラッシュ画面が表示されます。</span><span class="sxs-lookup"><span data-stu-id="16ccf-224">The default splash screen appears first.</span></span> <span data-ttu-id="16ccf-225">この画面には、アプリのマニフェスト ファイルに指定された画像 (Assets\\SplashScreen.scale-100.png) と背景色があります。</span><span class="sxs-lookup"><span data-stu-id="16ccf-225">It has an image—Assets\\SplashScreen.scale-100.png—and a background color that are specified in the app's manifest file.</span></span> <span data-ttu-id="16ccf-226">スプラッシュ画面をカスタマイズする方法については、「[スプラッシュ画面の追加](https://msdn.microsoft.com/library/windows/apps/Hh465332)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="16ccf-226">To learn how to customize the splash screen, see [Adding a splash screen](https://msdn.microsoft.com/library/windows/apps/Hh465332).</span></span>

<span data-ttu-id="16ccf-227">スプラッシュ画面が消えると、アプリが表示されます。</span><span class="sxs-lookup"><span data-stu-id="16ccf-227">When the splash screen disappears, your app appears.</span></span> <span data-ttu-id="16ccf-228">アプリのメイン ページが表示されます。</span><span class="sxs-lookup"><span data-stu-id="16ccf-228">It displays the main page of the App.</span></span>

![コントロールがある UWP アプリ画面](images/xaml-hw-app2.png)

<span data-ttu-id="16ccf-230">特別な機能はありませんが、ともかくこれで、初めてのユニバーサル Windows プラットフォーム アプリの作成は完了です。</span><span class="sxs-lookup"><span data-stu-id="16ccf-230">It doesn't do much—yet—but congratulations, you've built your first Universal Windows Platform app!</span></span>

<span data-ttu-id="16ccf-231">アプリのデバッグを停止して閉じるには、Visual Studio に戻り、Shift キーを押しながら F5 キーを押します。</span><span class="sxs-lookup"><span data-stu-id="16ccf-231">To stop debugging and close the app, return to Visual Studio and press Shift+F5.</span></span>

<span data-ttu-id="16ccf-232">詳しくは、「[Visual Studio からのストア アプリの実行](http://go.microsoft.com/fwlink/p/?LinkId=619619)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="16ccf-232">For more information, see [Run a Store app from Visual Studio](http://go.microsoft.com/fwlink/p/?LinkId=619619).</span></span>

<span data-ttu-id="16ccf-233">アプリの [**TextBox**](https://msdn.microsoft.com/library/windows/apps/BR209683) に文字を入力することはできますが、この時点では [**Button**](https://msdn.microsoft.com/library/windows/apps/BR209265) をクリックしても何も起こりません。</span><span class="sxs-lookup"><span data-stu-id="16ccf-233">In the app, you can type in the [**TextBox**](https://msdn.microsoft.com/library/windows/apps/BR209683), but clicking the [**Button**](https://msdn.microsoft.com/library/windows/apps/BR209265) doesn't do anything.</span></span> <span data-ttu-id="16ccf-234">この後の手順で、ユーザーに合わせたあいさつを表示する、ボタンの [**Click**](https://msdn.microsoft.com/library/windows/apps/BR227737) イベント用のイベント ハンドラーを作成します。</span><span class="sxs-lookup"><span data-stu-id="16ccf-234">In later steps, you create an event handler for the button's [**Click**](https://msdn.microsoft.com/library/windows/apps/BR227737) event, which displays a personalized greeting.</span></span>

## <a name="step-2-create-an-event-handler"></a><span data-ttu-id="16ccf-235">手順 2: イベント ハンドラーの作成</span><span class="sxs-lookup"><span data-stu-id="16ccf-235">Step 2: Create an event handler</span></span>

1.  <span data-ttu-id="16ccf-236">MainPage.xaml (XAML ビューまたはデザイン ビュー) で、先に追加した [**StackPanel**](https://msdn.microsoft.com/library/windows/apps/BR209635) の "Say Hello" [**Button**](https://msdn.microsoft.com/library/windows/apps/BR209265) を選びます。</span><span class="sxs-lookup"><span data-stu-id="16ccf-236">In MainPage.xaml, in either XAML or design view, select the "Say Hello" [**Button**](https://msdn.microsoft.com/library/windows/apps/BR209265) in the [**StackPanel**](https://msdn.microsoft.com/library/windows/apps/BR209635) you added earlier.</span></span>
2.  <span data-ttu-id="16ccf-237">F4 キーを押して**プロパティ ウィンドウ**を開き、[イベント] ボタン (![[イベント] ボタン](images/eventsbutton.png)) を選択します。</span><span class="sxs-lookup"><span data-stu-id="16ccf-237">Open the **Properties Window** by pressing F4, and then choose the Events button (![Events button](images/eventsbutton.png)).</span></span>
3.  <span data-ttu-id="16ccf-238">[**Click**](https://msdn.microsoft.com/library/windows/apps/BR227737) イベントを探します。</span><span class="sxs-lookup"><span data-stu-id="16ccf-238">Find the [**Click**](https://msdn.microsoft.com/library/windows/apps/BR227737) event.</span></span> <span data-ttu-id="16ccf-239">このテキスト ボックスに、**Click** イベントを処理する関数の名前を入力します。</span><span class="sxs-lookup"><span data-stu-id="16ccf-239">In its text box, type the name of the function that handles the **Click** event.</span></span> <span data-ttu-id="16ccf-240">この例では、「Button\_Click」と入力します。</span><span class="sxs-lookup"><span data-stu-id="16ccf-240">For this example, type "Button\_Click".</span></span>

    ![プロパティ ウィンドウのイベント ビュー](images/xaml-hw-event.png)

4.  <span data-ttu-id="16ccf-242">Enter キーを押します。</span><span class="sxs-lookup"><span data-stu-id="16ccf-242">Press Enter.</span></span> <span data-ttu-id="16ccf-243">MainPage.xaml.cpp にイベント ハンドラー メソッドが作成され、イベントの発生時に実行されるコードを追加できるように開きます。</span><span class="sxs-lookup"><span data-stu-id="16ccf-243">The event handler method is created in MainPage.xaml.cpp and opened so that you can add the code that's executed when the event occurs.</span></span>

   <span data-ttu-id="16ccf-244">同時に、MainPage.xaml で、[**Button**](https://msdn.microsoft.com/library/windows/apps/BR209265) の XAML が更新されて、次のように [**Click**](https://msdn.microsoft.com/library/windows/apps/BR227737) イベント ハンドラーが宣言されます。</span><span class="sxs-lookup"><span data-stu-id="16ccf-244">At the same time, in MainPage.xaml, the XAML for the [**Button**](https://msdn.microsoft.com/library/windows/apps/BR209265) is updated to declare the [**Click**](https://msdn.microsoft.com/library/windows/apps/BR227737) event handler, like this:</span></span>

    ```xaml
    <Button Content="Say &quot;Hello&quot;" Click="Button_Click"/>
    ```

   <span data-ttu-id="16ccf-245">これを XAML コードに手動で入力することもできます。これは、デザイナーが読み込みに失敗する場合に役立つことがあります。</span><span class="sxs-lookup"><span data-stu-id="16ccf-245">You could also have simply added this to the xaml code manually, which can be helpful if the designer doesn't load.</span></span> <span data-ttu-id="16ccf-246">手動で入力する場合は、「Click」と入力すると、IntelliSense によって新しいイベント ハンドラーを追加するオプションがポップアップされます。</span><span class="sxs-lookup"><span data-stu-id="16ccf-246">If you enter this manually, type "Click" and then let IntelliSense pop up the option to add a new event handler.</span></span> <span data-ttu-id="16ccf-247">このように、Visual Studio によって必要なメソッド宣言とスタブが作成されます。</span><span class="sxs-lookup"><span data-stu-id="16ccf-247">That way, Visual Studio creates the necessary method declaration and stub.</span></span>

   <span data-ttu-id="16ccf-248">デザイナーは、レンダリング中にハンドルされない例外が発生すると、読み込みに失敗します。</span><span class="sxs-lookup"><span data-stu-id="16ccf-248">The designer fails to load if an unhandled exception occurs during rendering.</span></span> <span data-ttu-id="16ccf-249">デザイナーでのレンダリングでは、ページの設計時のバージョンが実行されます。</span><span class="sxs-lookup"><span data-stu-id="16ccf-249">Rendering in the designer involves running a design-time version of the page.</span></span> <span data-ttu-id="16ccf-250">これは、ユーザー コードの実行を無効にする場合に便利です。</span><span class="sxs-lookup"><span data-stu-id="16ccf-250">It can be helpful to disable running user code.</span></span> <span data-ttu-id="16ccf-251">そのためには、**[ツール]、[オプション]** の順にクリックして、開いたダイアログ ボックスで設定を変更します。</span><span class="sxs-lookup"><span data-stu-id="16ccf-251">You can do this by changing the setting in the **Tools, Options** dialog box.</span></span> <span data-ttu-id="16ccf-252">**[XAML デザイナー]** で、**[プロジェクト コードを XAML デザイナーで実行する (サポートされている場合)]** チェック ボックスをオフにします。</span><span class="sxs-lookup"><span data-stu-id="16ccf-252">Under **XAML Designer**, uncheck **Run project code in XAML designer (if supported)**.</span></span>

5.  <span data-ttu-id="16ccf-253">MainPage.xaml.cpp で、作成した **Button\_Click** イベント ハンドラーに次のコードを追加します。</span><span class="sxs-lookup"><span data-stu-id="16ccf-253">In MainPage.xaml.cpp, add the following code to the **Button\_Click** event handler that you just created.</span></span> <span data-ttu-id="16ccf-254">このコードは、`nameInput` [**TextBox**](https://msdn.microsoft.com/library/windows/apps/BR209683) コントロールからユーザー名を取得し、それを使ってあいさつを作ります。</span><span class="sxs-lookup"><span data-stu-id="16ccf-254">This code retrieves the user's name from the `nameInput` [**TextBox**](https://msdn.microsoft.com/library/windows/apps/BR209683) control and uses it to create a greeting.</span></span> <span data-ttu-id="16ccf-255">結果は、`greetingOutput` [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/BR209652) に表示されます。</span><span class="sxs-lookup"><span data-stu-id="16ccf-255">The `greetingOutput` [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/BR209652) displays the result.</span></span>

    ```cpp
    void HelloWorld::MainPage::Button_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
    {
        greetingOutput->Text = "Hello, " + nameInput->Text + "!";
    }
    ```

6.  <span data-ttu-id="16ccf-256">プロジェクトをスタートアップ プロジェクトとして設定し、F5 キーを押してアプリをビルド、実行します。</span><span class="sxs-lookup"><span data-stu-id="16ccf-256">Set the project as the startup, and then press F5 to build and run the app.</span></span> <span data-ttu-id="16ccf-257">テキスト ボックスに名前を入力してボタンをクリックすると、ユーザーに合わせたあいさつが表示されます。</span><span class="sxs-lookup"><span data-stu-id="16ccf-257">When you type a name in the text box and click the button, the app displays a personalized greeting.</span></span>

![メッセージが表示されたアプリ画面](images/xaml-hw-app4.png)

## <a name="step-3-style-the-start-page"></a><span data-ttu-id="16ccf-259">手順 3: スタート ページのスタイルを設定する</span><span class="sxs-lookup"><span data-stu-id="16ccf-259">Step 3: Style the start page</span></span>

### <a name="choosing-a-theme"></a><span data-ttu-id="16ccf-260">テーマを選ぶ</span><span class="sxs-lookup"><span data-stu-id="16ccf-260">Choosing a theme</span></span>

<span data-ttu-id="16ccf-261">アプリの外観は簡単にカスタマイズできます。</span><span class="sxs-lookup"><span data-stu-id="16ccf-261">It's easy to customize the look and feel of your app.</span></span> <span data-ttu-id="16ccf-262">既定では、アプリは淡色スタイルのリソースを使います。</span><span class="sxs-lookup"><span data-stu-id="16ccf-262">By default, your app uses resources that have a light style.</span></span> <span data-ttu-id="16ccf-263">システム リソースには、淡色テーマも含まれています。</span><span class="sxs-lookup"><span data-stu-id="16ccf-263">The system resources also include a light theme.</span></span> <span data-ttu-id="16ccf-264">試しにそれを使って、どのように表示されるか見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="16ccf-264">Let's try it out and see what it looks like.</span></span>

**<span data-ttu-id="16ccf-265">濃色テーマに切り替えるには</span><span class="sxs-lookup"><span data-stu-id="16ccf-265">To switch to the dark theme</span></span>**

1.  <span data-ttu-id="16ccf-266">App.xaml を開きます。</span><span class="sxs-lookup"><span data-stu-id="16ccf-266">Open App.xaml.</span></span>
2.  <span data-ttu-id="16ccf-267">開始 [**Application**](https://msdn.microsoft.com/library/windows/apps/BR242324) タグで、[**RequestedTheme**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.application.requestedtheme) プロパティを編集し、その値を **Dark** に設定します。</span><span class="sxs-lookup"><span data-stu-id="16ccf-267">In the opening [**Application**](https://msdn.microsoft.com/library/windows/apps/BR242324) tag, edit the [**RequestedTheme**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.application.requestedtheme) property and set its value to **Dark**:</span></span>

    ```xaml
    RequestedTheme="Dark"
    ```

    <span data-ttu-id="16ccf-268">濃色テーマを追加した [**Application**](https://msdn.microsoft.com/library/windows/apps/BR242324) タグ全体を次に示します。</span><span class="sxs-lookup"><span data-stu-id="16ccf-268">Here's the full [**Application**](https://msdn.microsoft.com/library/windows/apps/BR242324) tag with the dark theme :</span></span>

    ```xaml 
        <Application
        x:Class="HelloWorld.App"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:local="using:HelloWorld"
        RequestedTheme="Dark">
    ```

3.  <span data-ttu-id="16ccf-269">F5 キーを押して、アプリをビルドし、実行します。</span><span class="sxs-lookup"><span data-stu-id="16ccf-269">Press F5 to build and run it.</span></span> <span data-ttu-id="16ccf-270">濃色テーマが使われていることに注目してください。</span><span class="sxs-lookup"><span data-stu-id="16ccf-270">Notice that it uses the dark theme.</span></span>

![濃色テーマのアプリ画面](images/xaml-hw-app3.png)

<span data-ttu-id="16ccf-272">どちらを使えばいいでしょうか。</span><span class="sxs-lookup"><span data-stu-id="16ccf-272">Which theme should you use?</span></span> <span data-ttu-id="16ccf-273">どちらでも好きなほうを使用できます。</span><span class="sxs-lookup"><span data-stu-id="16ccf-273">Whichever one you want.</span></span> <span data-ttu-id="16ccf-274">お勧めするとすれば、主に画像やビデオを表示するアプリには濃色テーマ、テキストが大量に含まれるアプリには淡色テーマです。</span><span class="sxs-lookup"><span data-stu-id="16ccf-274">Here's our take: for apps that mostly display images or video, we recommend the dark theme; for apps that contain a lot of text, we recommend the light theme.</span></span> <span data-ttu-id="16ccf-275">カスタム配色を使う場合は、アプリの外観に最もよく合ったテーマを使ってください。</span><span class="sxs-lookup"><span data-stu-id="16ccf-275">If you're using a custom color scheme, use the theme that goes best with your app's look and feel.</span></span> <span data-ttu-id="16ccf-276">このチュートリアルの残りの部分では、スクリーンショットで淡色テーマを使います。</span><span class="sxs-lookup"><span data-stu-id="16ccf-276">In the rest of this tutorial, we use the Light theme in screenshots.</span></span>

<span data-ttu-id="16ccf-277">**注:**、アプリの起動時、アプリの実行中は変更できませんにテーマを適用します。</span><span class="sxs-lookup"><span data-stu-id="16ccf-277">**Note**The theme is applied when the app is started and can't be changed while the app is running.</span></span>

### <a name="using-system-styles"></a><span data-ttu-id="16ccf-278">システム スタイルの使用</span><span class="sxs-lookup"><span data-stu-id="16ccf-278">Using system styles</span></span>

<span data-ttu-id="16ccf-279">現時点では、Windows アプリ内のテキストが小さすぎて判読困難です。</span><span class="sxs-lookup"><span data-stu-id="16ccf-279">Right now, in the Windows app the text is very small and difficult to read.</span></span> <span data-ttu-id="16ccf-280">システム スタイルを適用してこの点を修正してみましょう。</span><span class="sxs-lookup"><span data-stu-id="16ccf-280">Let's fix that by applying a system style.</span></span>

**<span data-ttu-id="16ccf-281">要素のスタイルを変更するには</span><span class="sxs-lookup"><span data-stu-id="16ccf-281">To change the style of an element</span></span>**

1.  <span data-ttu-id="16ccf-282">Windows プロジェクトで、MainPage.xaml を開きます。</span><span class="sxs-lookup"><span data-stu-id="16ccf-282">In the Windows project, open MainPage.xaml.</span></span>
2.  <span data-ttu-id="16ccf-283">XAML ビューまたはデザイン ビューで、前に追加した "What's your name?"[**TextBlock**](https://msdn.microsoft.com/library/windows/apps/BR209652) を選びます。</span><span class="sxs-lookup"><span data-stu-id="16ccf-283">In either XAML or design view, select the "What's your name?"[**TextBlock**](https://msdn.microsoft.com/library/windows/apps/BR209652) that you added earlier.</span></span>
3.  <span data-ttu-id="16ccf-284">**[プロパティ]** ウィンドウ (**F4**) の右上にある [プロパティ] ボタン (![Properties button](images/propertiesbutton.png)) をクリックします。</span><span class="sxs-lookup"><span data-stu-id="16ccf-284">In the **Properties** window (**F4**), choose the Properties button (![Properties button](images/propertiesbutton.png)) in the upper right.</span></span>
4.  <span data-ttu-id="16ccf-285">**[Text]** グループを展開し、フォント サイズを 18px に設定します。</span><span class="sxs-lookup"><span data-stu-id="16ccf-285">Expand the **Text** group and set the font size to 18 px.</span></span>
5.  <span data-ttu-id="16ccf-286">**[その他]** グループを展開し、**Style** プロパティを探します。</span><span class="sxs-lookup"><span data-stu-id="16ccf-286">Expand the **Miscellaneous** group and find the **Style** property.</span></span>
6.  <span data-ttu-id="16ccf-287">プロパティ マーカー (**Style** プロパティの右にある緑色のボックス) をクリックし、メニューから **[システム リソース]**、**[BaseTextBlockStyle]** の順にクリックします。</span><span class="sxs-lookup"><span data-stu-id="16ccf-287">Click the property marker (the green box to the right of the **Style** property), and then, on the menu, choose **System Resource** > **BaseTextBlockStyle**.</span></span>

     <span data-ttu-id="16ccf-288">**BaseTextBlockStyle** は、<root>\\Program Files\\Windows Kits\\10\\Include\\winrt\\xaml\\design\\generic.xaml の [**ResourceDictionary** ](https://msdn.microsoft.com/library/windows/apps/BR208794) で定義されているリソースです。</span><span class="sxs-lookup"><span data-stu-id="16ccf-288">**BaseTextBlockStyle** is a resource that's defined in the [**ResourceDictionary**](https://msdn.microsoft.com/library/windows/apps/BR208794) in <root>\\Program Files\\Windows Kits\\10\\Include\\winrt\\xaml\\design\\generic.xaml.</span></span>

    ![プロパティ ウィンドウのプロパティ ビュー](images/xaml-hw-style-cpp.png)

     <span data-ttu-id="16ccf-290">XAML デザイン サーフェイスで、テキストの外観が変化します。</span><span class="sxs-lookup"><span data-stu-id="16ccf-290">On the XAML design surface, the appearance of the text changes.</span></span> <span data-ttu-id="16ccf-291">XAML エディターで、[**TextBlock**](https://msdn.microsoft.com/library/windows/apps/BR209652) の XAML が更新されます。</span><span class="sxs-lookup"><span data-stu-id="16ccf-291">In the XAML editor, the XAML for the [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/BR209652) is updated:</span></span>

    ```xaml
    <TextBlock Text="What's your name?" Style="{ThemeResource BaseTextBlockStyle}"/>
    ```

7.  <span data-ttu-id="16ccf-292">このプロセスを繰り返してフォント サイズを設定し、**BaseTextBlockStyle** を `greetingOutput` [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/BR209652) 要素に割り当てます。</span><span class="sxs-lookup"><span data-stu-id="16ccf-292">Repeat the process to set the font size and assign the **BaseTextBlockStyle** to the `greetingOutput`[**TextBlock**](https://msdn.microsoft.com/library/windows/apps/BR209652) element.</span></span>

    <span data-ttu-id="16ccf-293">**ヒント:** が選択できるように XAML デザイン サーフェイスの上にポインターを移動するときにこの[**TextBlock**](https://msdn.microsoft.com/library/windows/apps/BR209652)でにテキストがありませんが、青色の輪郭を示しています。</span><span class="sxs-lookup"><span data-stu-id="16ccf-293">**Tip**Although there's no text in this [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/BR209652), when you move the pointer over the XAML design surface, a blue outline shows where it is so that you can select it.</span></span>  

    <span data-ttu-id="16ccf-294">XAML は次のようになります。</span><span class="sxs-lookup"><span data-stu-id="16ccf-294">Your XAML now looks like this:</span></span>

    ```xaml
    <StackPanel x:Name="contentPanel" Margin="120,30,0,0">
        <TextBlock Style="{ThemeResource BaseTextBlockStyle}" FontSize="18" Text="What's your name?"/>
        <StackPanel x:Name="inputPanel" Orientation="Horizontal" Margin="0,20,0,20">
            <TextBox x:Name="nameInput" Width="300" HorizontalAlignment="Left"/>
            <Button x:Name="inputButton" Content="Say &quot;Hello&quot;" Click="Button_Click"/>
        </StackPanel>
        <TextBlock Style="{ThemeResource BaseTextBlockStyle}" FontSize="18" x:Name="greetingOutput"/>
    </StackPanel>
    ```

8.  <span data-ttu-id="16ccf-295">F5 キーを押して、アプリをビルドし、実行します。</span><span class="sxs-lookup"><span data-stu-id="16ccf-295">Press F5 to build and run the app.</span></span> <span data-ttu-id="16ccf-296">次のように表示されます。</span><span class="sxs-lookup"><span data-stu-id="16ccf-296">It now looks like this:</span></span>

![アプリ画面のテキストが大きくなった](images/xaml-hw-app5.png)

### <a name="step-4-adapt-the-ui-to-different-window-sizes"></a><span data-ttu-id="16ccf-298">手順 4: 異なるウィンドウ サイズに合わせて UI を調整する</span><span class="sxs-lookup"><span data-stu-id="16ccf-298">Step 4: Adapt the UI to different window sizes</span></span>

<span data-ttu-id="16ccf-299">次に、モバイル デバイスで適切に表示されるように、さまざまな画面サイズに合わせて UI を調整します。</span><span class="sxs-lookup"><span data-stu-id="16ccf-299">Now we'll make the UI adapt to different screen sizes so it looks good on mobile devices.</span></span> <span data-ttu-id="16ccf-300">これを行うには、[**VisualStateManager**](https://msdn.microsoft.com/library/windows/apps/BR209021) を追加して、さまざまな表示状態に適用されるプロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="16ccf-300">To do this, you add a [**VisualStateManager**](https://msdn.microsoft.com/library/windows/apps/BR209021) and set properties that are applied for different visual states.</span></span>

**<span data-ttu-id="16ccf-301">UI レイアウトを調整するには</span><span class="sxs-lookup"><span data-stu-id="16ccf-301">To adjust the UI layout</span></span>**

1.  <span data-ttu-id="16ccf-302">XAML エディターで、ルートの [**Grid**](https://msdn.microsoft.com/library/windows/apps/BR242704) 要素の開始タグの後に、この XAML ブロックを追加します。</span><span class="sxs-lookup"><span data-stu-id="16ccf-302">In the XAML editor, add this block of XAML after the opening tag of the root [**Grid**](https://msdn.microsoft.com/library/windows/apps/BR242704) element.</span></span>

    ```xaml
    <VisualStateManager.VisualStateGroups>
        <VisualStateGroup>
            <VisualState x:Name="wideState">
                <VisualState.StateTriggers>
                    <AdaptiveTrigger MinWindowWidth="641" />
                </VisualState.StateTriggers>
            </VisualState>
            <VisualState x:Name="narrowState">
                <VisualState.StateTriggers>
                    <AdaptiveTrigger MinWindowWidth="0" />
                </VisualState.StateTriggers>
                <VisualState.Setters>
                    <Setter Target="contentPanel.Margin" Value="20,30,0,0"/>
                    <Setter Target="inputPanel.Orientation" Value="Vertical"/>
                    <Setter Target="inputButton.Margin" Value="0,4,0,0"/>
                </VisualState.Setters>
            </VisualState>
        </VisualStateGroup>
    </VisualStateManager.VisualStateGroups>
    ```

2.  <span data-ttu-id="16ccf-303">ローカル コンピューターでアプリをデバッグします。</span><span class="sxs-lookup"><span data-stu-id="16ccf-303">Debug the app on the local machine.</span></span> <span data-ttu-id="16ccf-304">UI は、ウィンドウが 641 DIP (デバイスに依存しないピクセル) より狭くならない限り、前と同じように表示されることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="16ccf-304">Notice that the UI looks the same as before unless the window gets narrower than 641 device-independent pixels (DIPs).</span></span>
3.  <span data-ttu-id="16ccf-305">モバイル デバイス エミュレーターでアプリをデバッグします。</span><span class="sxs-lookup"><span data-stu-id="16ccf-305">Debug the app on the mobile device emulator.</span></span> <span data-ttu-id="16ccf-306">`narrowState` で定義したプロパティが UI に使用され、小さい画面で適切に表示されていることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="16ccf-306">Notice that the UI uses the properties you defined in the `narrowState` and appears correctly on the small screen.</span></span>

![スタイル付きテキストを表示するモバイル アプリ画面](images/hw10-screen2-mob.png)

<span data-ttu-id="16ccf-308">以前のバージョンの XAML で [**VisualStateManager**](https://msdn.microsoft.com/library/windows/apps/BR209021) を使ったことがある場合は、この XAML では簡素化された構文が使用されていることに気付くかもしれません。</span><span class="sxs-lookup"><span data-stu-id="16ccf-308">If you've used a [**VisualStateManager**](https://msdn.microsoft.com/library/windows/apps/BR209021) in previous versions of XAML, you might notice that the XAML here uses a simplified syntax.</span></span>

<span data-ttu-id="16ccf-309">`wideState` という名前の [**VisualState**](https://msdn.microsoft.com/library/windows/apps/BR209007) で、[**AdaptiveTrigger**](https://msdn.microsoft.com/library/windows/apps/Dn890382) の [**MinWindowWidth**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.adaptivetrigger.minwindowwidth) プロパティが 641 に設定されています。</span><span class="sxs-lookup"><span data-stu-id="16ccf-309">The [**VisualState**](https://msdn.microsoft.com/library/windows/apps/BR209007) named `wideState` has an [**AdaptiveTrigger**](https://msdn.microsoft.com/library/windows/apps/Dn890382) with its [**MinWindowWidth**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.adaptivetrigger.minwindowwidth) property set to 641.</span></span> <span data-ttu-id="16ccf-310">これは、ウィンドウの幅が 641 DIP という最小値以上である場合に限って、状態が適用されることを意味します。</span><span class="sxs-lookup"><span data-stu-id="16ccf-310">This means that the state is to be applied only when the window width is not less than the minimum of 641 DIPs.</span></span> <span data-ttu-id="16ccf-311">この状態には [**Setter**](https://msdn.microsoft.com/library/windows/apps/BR208817) オブジェクトを定義していないため、XAML でページのコンテンツに対して定義したレイアウト プロパティが使用されます。</span><span class="sxs-lookup"><span data-stu-id="16ccf-311">You don't define any [**Setter**](https://msdn.microsoft.com/library/windows/apps/BR208817) objects for this state, so it uses the layout properties you defined in the XAML for the page content.</span></span>

<span data-ttu-id="16ccf-312">2 つ目の [**VisualState**](https://msdn.microsoft.com/library/windows/apps/BR209007) である `narrowState` で、[**AdaptiveTrigger**](https://msdn.microsoft.com/library/windows/apps/Dn890382) の [**MinWindowWidth**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.adaptivetrigger.minwindowwidth) プロパティが 0 に設定されています。</span><span class="sxs-lookup"><span data-stu-id="16ccf-312">The second [**VisualState**](https://msdn.microsoft.com/library/windows/apps/BR209007), `narrowState`, has an [**AdaptiveTrigger**](https://msdn.microsoft.com/library/windows/apps/Dn890382) with its [**MinWindowWidth**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.adaptivetrigger.minwindowwidth) property set to 0.</span></span> <span data-ttu-id="16ccf-313">この状態は、ウィンドウの幅が 0 より大きく 641 DIP より小さい場合に適用されます </span><span class="sxs-lookup"><span data-stu-id="16ccf-313">This state is applied when the window width is greater than 0, but less than 641 DIPs.</span></span> <span data-ttu-id="16ccf-314">(641 DIP では、`wideState` が適用されます)。この状態では、いくつかの [**Setter**](https://msdn.microsoft.com/library/windows/apps/BR208817) オブジェクトを設定して、UI のコントロールのレイアウト プロパティを変更します。</span><span class="sxs-lookup"><span data-stu-id="16ccf-314">(At 641 DIPs, the `wideState` is applied.) In this state, you do define some [**Setter**](https://msdn.microsoft.com/library/windows/apps/BR208817) objects to change the layout properties of controls in the UI:</span></span>

-   <span data-ttu-id="16ccf-315">`contentPanel` の左側の余白を 120 から 20 に減らします。</span><span class="sxs-lookup"><span data-stu-id="16ccf-315">You reduce the left margin of the `contentPanel` element from 120 to 20.</span></span>
-   <span data-ttu-id="16ccf-316">`inputPanel` 要素の [**Orientation**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.stackpanel.orientation) を **Horizontal** から **Vertical** に変更します。</span><span class="sxs-lookup"><span data-stu-id="16ccf-316">You change the [**Orientation**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.stackpanel.orientation) of the `inputPanel` element from **Horizontal** to **Vertical**.</span></span>
-   <span data-ttu-id="16ccf-317">4 DIP の上余白を `inputButton` 要素に追加します。</span><span class="sxs-lookup"><span data-stu-id="16ccf-317">You add a top margin of 4 DIPs to the `inputButton` element.</span></span>

### <a name="summary"></a><span data-ttu-id="16ccf-318">まとめ</span><span class="sxs-lookup"><span data-stu-id="16ccf-318">Summary</span></span>

<span data-ttu-id="16ccf-319">これで、最初のチュートリアルは終わりです。</span><span class="sxs-lookup"><span data-stu-id="16ccf-319">Congratulations, you've completed the first tutorial!</span></span> <span data-ttu-id="16ccf-320">このチュートリアルでは、Windows ユニバーサル アプリにコンテンツを追加する方法、そのコンテンツで対話式操作を実現する方法、見た目を変更する方法の 3 点について説明しました。</span><span class="sxs-lookup"><span data-stu-id="16ccf-320">It taught how to add content to Windows Universal apps, how to add interactivity to them, and how to change their appearance.</span></span>

## <a name="next-steps"></a><span data-ttu-id="16ccf-321">次のステップ</span><span class="sxs-lookup"><span data-stu-id="16ccf-321">Next steps</span></span>

<span data-ttu-id="16ccf-322">Windows8.1 や Windows Phone 8.1 を対象とする Windows ユニバーサル アプリ プロジェクトがある場合は、windows 10 へ移植することができます。</span><span class="sxs-lookup"><span data-stu-id="16ccf-322">If you have a Windows Universal app project that targets Windows8.1 and/or Windows Phone 8.1, you can port it to Windows10.</span></span> <span data-ttu-id="16ccf-323">この移植を自動的に行うプロセスはありませんが、手動で実行することができます。</span><span class="sxs-lookup"><span data-stu-id="16ccf-323">There is no automatic process for this, but you can do it manually.</span></span> <span data-ttu-id="16ccf-324">新しい Windows ユニバーサル プロジェクトを使って開発を始めることで、最新のプロジェクト システム構造を入手し、お使いのコード ファイルをプロジェクトのディレクトリ構造にコピーしたり、項目をプロジェクトに追加したりすることができます。また、このトピックのガイダンスに従い、[**VisualStateManager**](https://msdn.microsoft.com/library/windows/apps/BR209021) を使って XAML を書き換えることもできます。</span><span class="sxs-lookup"><span data-stu-id="16ccf-324">Start with a new Windows Universal project to get the latest project system structure and manifest files, copy your code files into the project's directory structure, add the items to your project, and rewrite your XAML using the [**VisualStateManager**](https://msdn.microsoft.com/library/windows/apps/BR209021) according to the guidance in this topic.</span></span> <span data-ttu-id="16ccf-325">詳しくは、「[Windows ランタイム 8 プロジェクトのユニバーサル Windows プラットフォーム (UWP) プロジェクトへの移植](https://msdn.microsoft.com/library/windows/apps/Mt188203)」と「[ユニバーサル Windows プラットフォームへの移植 (C++)](http://go.microsoft.com/fwlink/p/?LinkId=619525)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="16ccf-325">For more information, see [Porting a Windows Runtime 8 project to a Universal Windows Platform (UWP) project](https://msdn.microsoft.com/library/windows/apps/Mt188203) and [Porting to the Universal Windows Platform (C++)](http://go.microsoft.com/fwlink/p/?LinkId=619525).</span></span>

<span data-ttu-id="16ccf-326">UWP アプリと統合する既存の C++ コードがある場合、たとえば、既存のアプリケーションに新しい UWP UI を作成する場合は、「[方法: ユニバーサル Windows プロジェクトで既存の C++ コードを使う](http://go.microsoft.com/fwlink/p/?LinkId=619623)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="16ccf-326">If you have existing C++ code that you want to integrate with a UWP app, such as to create a new UWP UI for an existing application, see [How to: Use existing C++ code in a Universal Windows project](http://go.microsoft.com/fwlink/p/?LinkId=619623).</span></span>

