---
author: jwmsft
title: ユーザー インターフェイスの作成のチュートリアル
description: この記事では、XAML のユーザー インターフェイス作成の基本について説明します。
keywords: XAML, UWP, 概要
ms.author: jimwalk
ms.date: 08/30/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 5d54df07cd5f2ccc32098b17fd7c656900cba978
ms.sourcegitcommit: cbe7cf620622a5e4df7414f9e38dfecec1cfca99
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/20/2018
ms.locfileid: "7427942"
---
# <a name="tutorial-create-a-user-interface"></a><span data-ttu-id="4c8a1-104">チュートリアル: ユーザー インターフェイスの作成</span><span class="sxs-lookup"><span data-stu-id="4c8a1-104">Tutorial: Create a user interface</span></span>

<span data-ttu-id="4c8a1-105">このチュートリアルでは、イメージ編集プログラムの基本的な UI を作成する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-105">In this tutorial, you'll learn how to create a basic UI for an image editing program by:</span></span> 

+ <span data-ttu-id="4c8a1-106">Visual Studio の XAML ツール (XAML デザイナー、ツールボックス、XAML エディター、[プロパティ] パネル、ドキュメント アウトラインなど) を使用してコントロールやコンテンツを UI に追加する</span><span class="sxs-lookup"><span data-stu-id="4c8a1-106">Using the XAML tools in Visual Studio, such as XAML Designer, Toolbox, XAML editor, Properties panel, and Document Outline to add controls and content to your UI</span></span>
+ <span data-ttu-id="4c8a1-107">最も一般的な XAML レイアウト パネル (RelativePanel、Grid、StackPanel など) を利用する</span><span class="sxs-lookup"><span data-stu-id="4c8a1-107">Utilizing some of the most common XAML layout panels, such as RelativePanel, Grid, and StackPanel.</span></span>

<span data-ttu-id="4c8a1-108">イメージ編集プログラムには、次の 2 つのページ/画面があります。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-108">The image editing program has two pages/screens:</span></span>

<span data-ttu-id="4c8a1-109">**メイン ページ:** フォト ギャラリー ビューが各イメージ ファイルに関する情報と共に表示されます。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-109">The **main page**, which displays a photo gallery view, along with some information about each image file.</span></span>

![MainPage](images/xaml-basics/mainpage.png)

<span data-ttu-id="4c8a1-111">**詳細ページ:** 選択された単一の写真が表示されます。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-111">The **details page**, which displays a single photo after it has been selected.</span></span> <span data-ttu-id="4c8a1-112">ポップアップの編集メニューにより、写真の編集、名前変更、保存を行うことができます。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-112">A flyout editing menu allows the photo to be altered, renamed, and saved.</span></span>

![DetailPage](images/xaml-basics/detailpage.png)


## <a name="prerequisites"></a><span data-ttu-id="4c8a1-114">前提条件</span><span class="sxs-lookup"><span data-stu-id="4c8a1-114">Prerequisites</span></span>

* <span data-ttu-id="4c8a1-115">Visual Studio 2017: [Visual Studio 2017 Community (無料) のダウンロード](https://www.visualstudio.com/thank-you-downloading-visual-studio/?sku=Community&rel=15&campaign=WinDevCenter&ocid=wdgcx-windevcenter-community-download)</span><span class="sxs-lookup"><span data-stu-id="4c8a1-115">Visual Studio 2017: [Download Visual Studio 2017 Community (free)](https://www.visualstudio.com/thank-you-downloading-visual-studio/?sku=Community&rel=15&campaign=WinDevCenter&ocid=wdgcx-windevcenter-community-download)</span></span> 
* <span data-ttu-id="4c8a1-116">Windows 10 SDK (10.0.15063.468 以降): [最新の Windows SDK (無料) のダウンロード](https://developer.microsoft.com/windows/downloads/windows-10-sdk)</span><span class="sxs-lookup"><span data-stu-id="4c8a1-116">Windows 10 SDK (10.0.15063.468 or later):  [Download the latest Windows SDK (free)](https://developer.microsoft.com/windows/downloads/windows-10-sdk)</span></span>

## <a name="part-0-get-the-starter-code-from-github"></a><span data-ttu-id="4c8a1-117">パート 0: github からスタート コードを入手する</span><span class="sxs-lookup"><span data-stu-id="4c8a1-117">Part 0: Get the starter code from github</span></span>

<span data-ttu-id="4c8a1-118">このチュートリアルでは、PhotoLab サンプルの簡易バージョンから開始します。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-118">For this tutorial, you'll start with a simplified version of the PhotoLab sample.</span></span> 

1. <span data-ttu-id="4c8a1-119">移動[https://github.com/Microsoft/Windows-appsample-photo-lab](https://github.com/Microsoft/Windows-appsample-photo-lab)します。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-119">Go to [https://github.com/Microsoft/Windows-appsample-photo-lab](https://github.com/Microsoft/Windows-appsample-photo-lab).</span></span> <span data-ttu-id="4c8a1-120">これで、サンプルの GitHub ページが表示されます。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-120">This takes you to the GitHub page for the sample.</span></span> 
2. <span data-ttu-id="4c8a1-121">次に、サンプルを複製またはダウンロードする必要があります。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-121">Next, you'll need to clone or download the sample.</span></span> <span data-ttu-id="4c8a1-122">**[Clone or download]** (複製またはダウンロード) ボタンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-122">Click the **Clone or download** button.</span></span> <span data-ttu-id="4c8a1-123">サブメニューが表示されます。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-123">A sub-menu appears.</span></span>
    <figure>
        <img src="images/xaml-basics/clone-repo.png" alt="The Clone or download menu on GitHub">
        <figcaption><span data-ttu-id="4c8a1-124">PhotoLab サンプルの GitHub ページの <b>[Clone or download]</b> (複製またはダウンロード) メニュー。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-124">The <b>Clone or download</b> menu on the Photo lab sample's GitHub page.</span></span></figcaption>
    </figure>

    **<span data-ttu-id="4c8a1-125">GitHub に慣れていない場合:</span><span class="sxs-lookup"><span data-stu-id="4c8a1-125">If you're not familiar with GitHub:</span></span>**
    
    <span data-ttu-id="4c8a1-126">a. </span><span class="sxs-lookup"><span data-stu-id="4c8a1-126">a.</span></span> <span data-ttu-id="4c8a1-127">**[Download ZIP]** (ZIP をダウンロード) をクリックし、ファイルをローカルに保存します。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-127">Click **Download ZIP** and save the file locally.</span></span> <span data-ttu-id="4c8a1-128">これで、必要なすべてのプロジェクト ファイルを含む .zip ファイルがダウンロードされます。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-128">This downloads a .zip file that contains all the project files you need.</span></span>
    <span data-ttu-id="4c8a1-129">b. </span><span class="sxs-lookup"><span data-stu-id="4c8a1-129">b.</span></span> <span data-ttu-id="4c8a1-130">ファイルを展開します。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-130">Extract the file.</span></span> <span data-ttu-id="4c8a1-131">エクスプローラーを使用して、ダウンロードした .zip ファイルに移動し、ファイルを右クリックして **[すべて展開]** を選択します。c.</span><span class="sxs-lookup"><span data-stu-id="4c8a1-131">Use the File Explorer to navigate to the .zip file you just downloaded, right-click it, and select **Extract All...**. c.</span></span> <span data-ttu-id="4c8a1-132">サンプルのローカル コピーに移動し、`Windows-appsample-photo-lab-master\xaml-basics-starting-points\user-interface` ディレクトリに移動します。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-132">Navigate to your local copy of the sample and go the `Windows-appsample-photo-lab-master\xaml-basics-starting-points\user-interface` directory.</span></span>    

    **<span data-ttu-id="4c8a1-133">GitHub に慣れている場合:</span><span class="sxs-lookup"><span data-stu-id="4c8a1-133">If you are familiar with GitHub:</span></span>**

    <span data-ttu-id="4c8a1-134">a. </span><span class="sxs-lookup"><span data-stu-id="4c8a1-134">a.</span></span> <span data-ttu-id="4c8a1-135">リポジトリのマスター ブランチをローカルに複製します。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-135">Clone the master branch of the repo locally.</span></span>
    <span data-ttu-id="4c8a1-136">b. </span><span class="sxs-lookup"><span data-stu-id="4c8a1-136">b.</span></span> <span data-ttu-id="4c8a1-137">`Windows-appsample-photo-lab\xaml-basics-starting-points\user-interface` ディレクトリに移動します。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-137">Navigate to the `Windows-appsample-photo-lab\xaml-basics-starting-points\user-interface` directory.</span></span>

3. <span data-ttu-id="4c8a1-138">`Photolab.sln` をクリックしてプロジェクトを開きます。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-138">Open the project by clicking `Photolab.sln`.</span></span>

## <a name="part-1-add-a-textblock-using-xaml-designer"></a><span data-ttu-id="4c8a1-139">パート 1: XAML デザイナーを使用して TextBlock を追加する</span><span class="sxs-lookup"><span data-stu-id="4c8a1-139">Part 1: Add a TextBlock using XAML Designer</span></span>

<span data-ttu-id="4c8a1-140">Visual Studio には、XAML UI を簡単に作成するためのツールがいくつか用意されています。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-140">Visual Studio provides several tools to make creating your XAML UI easier.</span></span> <span data-ttu-id="4c8a1-141">XAML デザイナーでは、コントロールをデザイン サーフェイスにドラッグして、アプリを実行する前に外観を確認できます。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-141">XAML Designer lets you drag controls onto the design surface and see what they'll look like before you run the app.</span></span> <span data-ttu-id="4c8a1-142">[プロパティ] パネルでは、デザイナーでアクティブになっているコントロールのすべてのプロパティを表示および設定できます。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-142">The Properties panel lets you view and set all the properties of the control that are active in the designer.</span></span> <span data-ttu-id="4c8a1-143">ドキュメント アウトラインには、UI の XAML ビジュアル ツリーの親子構造が表示されます。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-143">Document Outline shows the parent-child structure of the XAML visual tree for your UI.</span></span> <span data-ttu-id="4c8a1-144">XAML エディターでは、XAML マークアップを直接入力および変更できます。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-144">The XAML editor lets you directly enter and modify the XAML markup.</span></span>

<span data-ttu-id="4c8a1-145">次の図は、Visual Studio の UI の名前を示したものです。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-145">Here's the Visual Studio UI with the tools labeled.</span></span>

![Visual Studio のレイアウト](images/xaml-basics/visual-studio-tools.png)

<span data-ttu-id="4c8a1-147">各ツールを使用すると UI の作成が容易になるため、このチュートリアルではこれらをすべて使います。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-147">Each of these tools make creating your UI easier, so we'll use all of them in this tutorial.</span></span> <span data-ttu-id="4c8a1-148">最初に、XAML デザイナーを使用してコントロールを追加しましょう。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-148">You'll start by using XAML Designer to add a control.</span></span> 

**<span data-ttu-id="4c8a1-149">XAML デザイナーを使用してコントロールを追加するには:</span><span class="sxs-lookup"><span data-stu-id="4c8a1-149">Add a control using XAML Designer:</span></span>**

1. <span data-ttu-id="4c8a1-150">ソリューション エクスプローラーで、**MainPage.xaml** をダブルクリックして開きます。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-150">Double-click **MainPage.xaml** in Solution Explorer to open it.</span></span> <span data-ttu-id="4c8a1-151">これにより、UI 要素が追加されていない状態で、アプリのメイン ページが表示されます。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-151">This shows the main page of the app without any UI elements added.</span></span>

2. <span data-ttu-id="4c8a1-152">先へ進む前に、Visual Studio を調整する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-152">Before going further, you need to make some adjustments to Visual Studio.</span></span>

    - <span data-ttu-id="4c8a1-153">ソリューション プラットフォームを必ず x86 または x64 (ARM は不可) に設定します。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-153">Make sure the Solution Platform is set to x86 or x64, not ARM.</span></span>
    - <span data-ttu-id="4c8a1-154">メイン ページの XAML デザイナーで、13.3 インチ デスクトップのプレビューが表示されるように設定します。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-154">Set the main page XAML Designer to show the 13.3" Desktop preview.</span></span>

    <span data-ttu-id="4c8a1-155">次のように、どちらの設定もウィンドウの最上部近辺にあります。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-155">You should see both settings near the top of the window, as shown here.</span></span>

    ![VS の設定](images/xaml-basics/layout-vs-settings.png)

    <span data-ttu-id="4c8a1-157">これで、アプリを実行できますが、ほとんど何も表示されません。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-157">You can run the app now, but you won't see much.</span></span> <span data-ttu-id="4c8a1-158">このままではつまらないので、いくつか UI 要素を追加してみましょう。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-158">Let's add some UI elements to make things more interesting.</span></span>

3. <span data-ttu-id="4c8a1-159">[ツールボックス] で **[コモン XAML コントロール]** を展開し、[TextBlock](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.textblock) コントロールを見つけます。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-159">In Toolbox, expand **Common XAML controls** and find the [TextBlock](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.textblock) control.</span></span> <span data-ttu-id="4c8a1-160">TextBlock をデザイン サーフェイスにドラッグし、ページの左上隅近辺にドロップします。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-160">Drag a TextBlock onto the design surface near the upper left corner of the page.</span></span>

    <span data-ttu-id="4c8a1-161">TextBlock がページに追加され、レイアウトに基づいて最も適していると判断されたいくつかのプロパティが設定されます。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-161">The TextBlock is added to the page, and the designer sets some properties based on its best guess at the layout you want.</span></span> <span data-ttu-id="4c8a1-162">現在アクティブなオブジェクトであることを示すために、TextBlock の周りが青色で強調表示されます。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-162">A blue highlight appears around the TextBlock to indicate that it is now the active object.</span></span> <span data-ttu-id="4c8a1-163">余白やその他の設定がデザイナーによって追加されます。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-163">Notice the margins and other settings added by the designer.</span></span> <span data-ttu-id="4c8a1-164">XAML は次のようになります。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-164">Your XAML will look something like this.</span></span> <span data-ttu-id="4c8a1-165">次のコードとまったく同じでなくても心配はいりません。ここでは、見やすくするために省略したコードを掲載しています。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-165">Don't worry if it's not formatted exactly like this; we abbreviated here to make it easier to read.</span></span>

    ```xaml
    <TextBlock x:Name="textBlock"
               HorizontalAlignment="Left"
               Margin="351,44,0,0"
               TextWrapping="Wrap"
               Text="TextBlock"
               VerticalAlignment="Top"/>
    ```

    <span data-ttu-id="4c8a1-166">次の手順では、これらの値を更新します。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-166">In the next steps, you'll update these values.</span></span>

4. <span data-ttu-id="4c8a1-167">[プロパティ] パネルで、TextBlock の [名前] の値を **textBlock** から **TitleTextBlock** に変更します </span><span class="sxs-lookup"><span data-stu-id="4c8a1-167">In the Properties panel, change the Name value of the TextBlock from **textBlock** to **TitleTextBlock**.</span></span> <span data-ttu-id="4c8a1-168">(まだ TextBlock がアクティブなオブジェクトであることを確認してください)。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-168">(Make sure the TextBlock is still the active object.)</span></span>

5. <span data-ttu-id="4c8a1-169">**[共通]** の下で、Text 値を **Collection** に変更します。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-169">Under **Common**, change the Text value to **Collection**.</span></span>

    ![TextBlock のプロパティ](images/xaml-basics/text-block-properties.png)

    <span data-ttu-id="4c8a1-171">XAML エディターに、次のような XAML が表示されます。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-171">In the XAML editor, your XAML will now look like this.</span></span>

    ```xaml
    <TextBlock x:Name="TitleTextBlock"
               HorizontalAlignment="Left"
               Margin="351,44,0,0"
               TextWrapping="Wrap"
               Text="Collection"
               VerticalAlignment="Top"/>
    ```

6. <span data-ttu-id="4c8a1-172">TextBlock を配置するには、まず Visual Studio によって追加されたプロパティ値を削除する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-172">To position the TextBlock, you should first remove the property values that were added by Visual Studio.</span></span> <span data-ttu-id="4c8a1-173">[ドキュメント アウトライン] で **[TitleTextBlock]** を右クリックして、**[レイアウト] > [すべてリセット]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-173">In Document Outline, right-click **TitleTextBlock**, then select **Layout > Reset All**.</span></span>

![ドキュメント アウトライン](images/xaml-basics/doc-outline-reset.png)

7. <span data-ttu-id="4c8a1-175">[プロパティ] パネルの検索ボックスに「**margin**」と入力します。これにより、**Margin** プロパティを簡単に見つけることができます。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-175">In the Properties panel, enter **margin** into the search box to easily find the **Margin** property.</span></span> <span data-ttu-id="4c8a1-176">左と下の余白を 24 に設定します。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-176">Set the left and bottom margins to 24.</span></span>

    ![TextBlock の余白](images/xaml-basics/margins.png)

    <span data-ttu-id="4c8a1-178">余白は、ページ上の要素の配置に関する最も基本的なプロパティです。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-178">Margins provide the most basic positioning of an element on the page.</span></span> <span data-ttu-id="4c8a1-179">これらはレイアウトを微調整するために便利ですが、Visual Studio によって追加される値のような大きな余白値を使用すると、UI をさまざまな画面サイズに適応させることが難しくなるため、大きな値の使用は避けてください。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-179">They're useful for fine-tuning your layout, but using large margin values like those added by Visual Studio makes it difficult for your UI to adapt to various screen sizes, and should be avoided.</span></span>

    <span data-ttu-id="4c8a1-180">詳しくは、「[配置、余白、パディング](../layout/alignment-margin-padding.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-180">For more info, see [Alignment, margins, and padding](../layout/alignment-margin-padding.md).</span></span>

8. <span data-ttu-id="4c8a1-181">[ドキュメント アウトライン] パネルで **[TitleTextBlock]** を右クリックし、**[スタイルの編集]、[リソースの適用]、[TitleTextBlockStyle]** の順に選択します。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-181">In the Document Outline panel, right-click **TitleTextBlock**, then select **Edit Style > Apply Resource > TitleTextBlockStyle**.</span></span> <span data-ttu-id="4c8a1-182">これにより、システム定義のスタイルがタイトル テキストに適用されます。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-182">This applies a system-defined style to your title text.</span></span>

    ```xaml
    <TextBlock x:Name="TitleTextBlock"
               TextWrapping="Wrap"
               Text="Collection"
               Margin="24,0,0,24"
               Style="{StaticResource TitleTextBlockStyle}"/>
    ```

9. <span data-ttu-id="4c8a1-183">[プロパティ] パネルの検索ボックスに「**textwrapping**」と入力して、**TextWrapping** プロパティを見つけます。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-183">In the Properties panel, enter **textwrapping** into the search box to find the **TextWrapping** property.</span></span> <span data-ttu-id="4c8a1-184">**TextWrapping** プロパティの_プロパティ マーカー_をクリックして、メニューを開きます </span><span class="sxs-lookup"><span data-stu-id="4c8a1-184">Click the _property marker_ for the **TextWrapping** property to open its menu.</span></span> <span data-ttu-id="4c8a1-185">(_プロパティ マーカー_は、各プロパティ値の右側に表示される小さな四角形のシンボルです。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-185">(The _property marker_ is the small box symbol to the right of each property value.</span></span> <span data-ttu-id="4c8a1-186">_プロパティ マーカー_は、プロパティが既定値以外に設定されていることを示す黒色になっています)。**[プロパティ]** メニューの **[リセット]** を選択して TextWrapping プロパティをリセットします。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-186">The _property marker_ is black to indicate that the property is set to a non-default value.) On the **Property** menu, select **Reset** to reset the TextWrapping property.</span></span>

    <span data-ttu-id="4c8a1-187">Visual Studio によってこのプロパティが追加されますが、適用したスタイルに既に設定されているため、ここでは必要ありません。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-187">Visual Studio adds this property, but it's already set in the style you applied, so you don't need it here.</span></span>

<span data-ttu-id="4c8a1-188">これで、UI の最初の部分をアプリに追加できました! </span><span class="sxs-lookup"><span data-stu-id="4c8a1-188">You've added the first part of the UI to your app!</span></span> <span data-ttu-id="4c8a1-189">では、アプリを実行して結果を確認しましょう。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-189">Run the app now to see what it looks like.</span></span>

<span data-ttu-id="4c8a1-190">XAML デザイナーでは黒色の背景に白色のテキストが表示されましたが、アプリを実行すると、白色の背景に黒色のテキストが表示されました。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-190">You might have noticed that in XAML Designer, your app showed white text on a black background, but when you ran it, it showed black text on a white background.</span></span> <span data-ttu-id="4c8a1-191">これは、Windows に [黒] と [白] のテーマがあり、既定のテーマがデバイスによって異なるためです。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-191">That's because Windows has both a Dark and a Light theme, and the default theme varies by device.</span></span> <span data-ttu-id="4c8a1-192">PC では、既定のテーマは [白] です。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-192">On a PC, the default theme is Light.</span></span> <span data-ttu-id="4c8a1-193">XAML デザイナーの上部にある歯車アイコンをクリックして [デバイス プレビューの設定] を開き、テーマを [ライト] に変更すると、アプリが XAML デザイナーで PC と同じように表示されるようになります。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-193">You can click the gear icon at the top of XAML Designer to open Device Preview Settings and change the theme to Light to make the app in XAML Designer look the same as it does on your PC.</span></span>

> [!NOTE]
> <span data-ttu-id="4c8a1-194">チュートリアルのこの部分では、ドラッグ アンド ドロップでコントロールを追加しました。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-194">In this part of the tutorial, you added a control by dragging-and-dropping.</span></span> <span data-ttu-id="4c8a1-195">コントロールは、[ツールボックス] でそのコントロールをダブルクリックして追加することもできます。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-195">You can also add a control by double-clicking it in Toolbox.</span></span> <span data-ttu-id="4c8a1-196">この方法を試し、Visual Studio によって生成される XAML で違いを確認してください。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-196">Give it a try, and see the differences in the XAML that Visual Studio generates.</span></span>

## <a name="part-2-add-a-gridview-control-using-the-xaml-editor"></a><span data-ttu-id="4c8a1-197">パート 2: XAML エディターを使用して GridView コントロールを追加する</span><span class="sxs-lookup"><span data-stu-id="4c8a1-197">Part 2: Add a GridView control using the XAML editor</span></span>

<span data-ttu-id="4c8a1-198">パート 1 では XAML の基本を紹介し、Visual Studio から提供される他のツールをいくつか見ていただきました。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-198">In Part 1, you had a taste of using XAML Designer and some of the other tools provided by Visual Studio.</span></span> <span data-ttu-id="4c8a1-199">ここでは、XAML エディターを使用して、XAML マークアップを直接操作します。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-199">Here, you'll use the XAML editor to work directly with the XAML markup.</span></span> <span data-ttu-id="4c8a1-200">XAML に慣れると、この方法の方が効率的であると感じられるかもしれません。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-200">As you become more familiar with XAML, you might find that this is a more efficient way for you to work.</span></span>

<span data-ttu-id="4c8a1-201">まず、ルート レイアウトである [Grid](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.grid) を [**RelativePanel**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.relativepanel) に置き換えます。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-201">First, you'll replace the root layout [Grid](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.grid) with a [**RelativePanel**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.relativepanel).</span></span> <span data-ttu-id="4c8a1-202">RelativePanel を使うと、パネルや他の UI に対して UI を簡単に再配置できます。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-202">The RelativePanel makes it easier to rearrange chunks of UI relative to the panel or other pieces of UI.</span></span> <span data-ttu-id="4c8a1-203">その便利さは、[XAML アダプティブ レイアウト](xaml-basics-adaptive-layout.md)のチュートリアルで確認できます。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-203">You'll see its usefulness in the [XAML Adaptive Layout](xaml-basics-adaptive-layout.md) tutorial.</span></span> 

<span data-ttu-id="4c8a1-204">次に、データを表示するための [GridView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.gridview) コントロールを追加します。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-204">Then, you'll add a [GridView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.gridview) control to display your data.</span></span>

**<span data-ttu-id="4c8a1-205">XAML エディターを使用してコントロールを追加する</span><span class="sxs-lookup"><span data-stu-id="4c8a1-205">Add a control using the XAML editor</span></span>**

1. <span data-ttu-id="4c8a1-206">XAML エディターで、ルートの **Grid** を **RelativePanel** に変更します。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-206">In the XAML editor, change the root **Grid** to a **RelativePanel**.</span></span>

    **<span data-ttu-id="4c8a1-207">変更前</span><span class="sxs-lookup"><span data-stu-id="4c8a1-207">Before</span></span>**
    ```xaml
    <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
          <TextBlock x:Name="TitleTextBlock"
                     Text="Collection"
                     Margin="24,0,0,24"
                     Style="{StaticResource TitleTextBlockStyle}"/>
    </Grid>
    ```

    **<span data-ttu-id="4c8a1-208">変更後</span><span class="sxs-lookup"><span data-stu-id="4c8a1-208">After</span></span>**
    ```xaml
    <RelativePanel Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
        <TextBlock x:Name="TitleTextBlock"
                   Text="Collection"
                   Margin="24,0,0,24"
                   Style="{StaticResource TitleTextBlockStyle}"/>
    </RelativePanel>
    ```

    <span data-ttu-id="4c8a1-209">**RelativePanel** を使用したレイアウトについて詳しくは、「[レイアウト パネル](https://docs.microsoft.com/windows/uwp/layout/layout-panels#relativepanel)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-209">For more info about layout using a **RelativePanel**, see [Layout panels](https://docs.microsoft.com/windows/uwp/layout/layout-panels#relativepanel).</span></span>

2. <span data-ttu-id="4c8a1-210">**TextBlock** 要素の下に、ImageGridView という名前の **GridView コントロール**を追加します。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-210">Below the **TextBlock** element, add a **GridView control** named 'ImageGridView'.</span></span> <span data-ttu-id="4c8a1-211">**RelativePanel** の添付プロパティ__ を設定して、コントロールをタイトル テキストの下に配置し、画面の横幅一杯に表示します。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-211">Set the **RelativePanel** _attached properties_ to place the control below the title text and make it stretch across the entire width of the screen.</span></span>

    **<span data-ttu-id="4c8a1-212">追加する XAML</span><span class="sxs-lookup"><span data-stu-id="4c8a1-212">Add this XAML</span></span>**

    ```xaml
    <GridView x:Name="ImageGridView"
              Margin="0,0,0,8"
              RelativePanel.AlignLeftWithPanel="True"
              RelativePanel.AlignRightWithPanel="True"
              RelativePanel.Below="TitleTextBlock"/>
    ```

    **<span data-ttu-id="4c8a1-213">追加先: TextBlock の後</span><span class="sxs-lookup"><span data-stu-id="4c8a1-213">After the TextBlock</span></span>**
    ```xaml
    <RelativePanel Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
        <TextBlock x:Name="TitleTextBlock"
                   Text="Collection"
                   Margin="24,0,0,24"
                   Style="{StaticResource TitleTextBlockStyle}"/>
        
        <!-- Add the GridView here. -->

    </RelativePanel>
    ```

    <span data-ttu-id="4c8a1-214">Panel 添付プロパティについて詳しくは、「[レイアウト パネル](https://docs.microsoft.com/windows/uwp/layout/layout-panels)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-214">For more info about Panel attached properties, see [Layout panels](https://docs.microsoft.com/windows/uwp/layout/layout-panels).</span></span>

3. <span data-ttu-id="4c8a1-215">**GridView** に何かを表示するには、表示するデータのコレクションを追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-215">In order for the **GridView** to show anything, you need to give it a collection of data to show.</span></span> <span data-ttu-id="4c8a1-216">MainPage.xaml.cs を開き、**GetItemsAsync** メソッドを見つけます。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-216">Open MainPage.xaml.cs and find the **GetItemsAsync** method.</span></span> <span data-ttu-id="4c8a1-217">このメソッドでは、MainPage に追加したプロパティである、Images と呼ばれるコレクションが設定されます。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-217">This method populates a collection called Images, which is a property that we've added to MainPage.</span></span>

    <span data-ttu-id="4c8a1-218">**GetItemsAsync** の **foreach** ループの後に、次のコードを追加します。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-218">After the **foreach** loop in **GetItemsAsync**, add this line of code.</span></span>

    ```csharp
    ImageGridView.ItemsSource = Images;
    ```

    <span data-ttu-id="4c8a1-219">これにより、GridView の **ItemsSource** プロパティがアプリの **Images** コレクションに設定され、**GridView** に表示できるようになります。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-219">This sets the GridView's **ItemsSource** property to the app's **Images** collection and gives the **GridView** something to show.</span></span>

<span data-ttu-id="4c8a1-220">ここでアプリを実行して、すべてが適切に動作しているかどうかを確認しましょう。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-220">This is a good place to run the app and make sure everything's working.</span></span> <span data-ttu-id="4c8a1-221">結果は次のようになるはずです。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-221">It should look something like this.</span></span>

![アプリの UI チェックポイント 1](images/xaml-basics/layout-0.png)

<span data-ttu-id="4c8a1-223">アプリにはイメージがまだ表示されていません。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-223">You'll notice that the app isn't showing images yet.</span></span> <span data-ttu-id="4c8a1-224">既定では、コレクション内にあるデータ型の ToString 値が表示されます。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-224">By default, it shows the ToString value of the data type that's in the collection.</span></span> <span data-ttu-id="4c8a1-225">次に、データ テンプレートを作成して、データの表示方法を定義します。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-225">Next, you'll create a data template to define how the data is shown.</span></span>

> [!NOTE]
> <span data-ttu-id="4c8a1-226">**RelativePanel** を使用したレイアウトについて詳しくは、「[レイアウト パネル](https://docs.microsoft.com/windows/uwp/layout/layout-panels#relativepanel)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-226">You can find out more about layout using a **RelativePanel** in the [Layout panels](https://docs.microsoft.com/windows/uwp/layout/layout-panels#relativepanel) article.</span></span> <span data-ttu-id="4c8a1-227">その後で、**TextBlock** と **GridView** の RelativePanel 添付プロパティを設定することで、さまざまなレイアウトを試してください。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-227">Take a look, and then experiment with some different layouts by setting RelativePanel attached properties on the **TextBlock** and **GridView**.</span></span>

## <a name="part-3-add-a-datatemplate-to-display-your-data"></a><span data-ttu-id="4c8a1-228">パート 3: データに DataTemplate を追加する</span><span class="sxs-lookup"><span data-stu-id="4c8a1-228">Part 3: Add a DataTemplate to display your data</span></span>

<span data-ttu-id="4c8a1-229">ここでは、データの表示方法を GridView に伝える [DataTemplate](https://docs.microsoft.com/uwp/api/windows.ui.xaml.datatemplate) を作成します。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-229">Now, you'll create a [DataTemplate](https://docs.microsoft.com/uwp/api/windows.ui.xaml.datatemplate) that tells the GridView how to display your data.</span></span> <span data-ttu-id="4c8a1-230">データ テンプレートについて詳しくは、「[項目コンテナーやテンプレート](../controls-and-patterns/item-containers-templates.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-230">For a full explanation of data templates, see [Item containers and templates](../controls-and-patterns/item-containers-templates.md).</span></span>

<span data-ttu-id="4c8a1-231">ここでは、希望のレイアウトを作成するためのプレースホルダーのみを追加します。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-231">For now, you'll only be adding placeholders to help you create the layout you want.</span></span> <span data-ttu-id="4c8a1-232">[XAML データ バインディング](../../data-binding/xaml-basics-data-binding.md)に関するチュートリアルでは、これらのプレースホルダーを **ImageFileInfo** クラスの実際のデータに置き換えます。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-232">In the [XAML Data Binding](../../data-binding/xaml-basics-data-binding.md) tutorial, you'll replace these placeholders with real data from the **ImageFileInfo** class.</span></span> <span data-ttu-id="4c8a1-233">データ オブジェクトがどのようになっているか確認するには、ここで ImageFileInfo.cs ファイルを開くこともできます。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-233">You can open the ImageFileInfo.cs file now if you want to see what the data object looks like.</span></span>

**<span data-ttu-id="4c8a1-234">データ テンプレートをグリッド ビューに追加する</span><span class="sxs-lookup"><span data-stu-id="4c8a1-234">Add a data template to a grid view</span></span>**

1. <span data-ttu-id="4c8a1-235">MainPage.xaml を開きます。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-235">Open MainPage.xaml.</span></span>

2. <span data-ttu-id="4c8a1-236">評価を表示するには、[Telerik UI for UWP](https://github.com/telerik/UI-For-UWP) という NuGet パッケージの **RadRating** コントロールを使用します。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-236">To show the rating, you use the **RadRating** control from the [Telerik UI for UWP](https://github.com/telerik/UI-For-UWP) NuGet package.</span></span> <span data-ttu-id="4c8a1-237">Telerik コントロールの名前空間を指定する XAML 名前空間の参照を追加します。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-237">Add a XAML namespace reference that specifies the namespace for the Telerik controls.</span></span> <span data-ttu-id="4c8a1-238">これを **Page** の開始タグ内 (他の一連の xmlns: エントリの直後) に配置します。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-238">Put this in the opening **Page** tag, right after the other 'xmlns:' entries.</span></span>

    **<span data-ttu-id="4c8a1-239">追加する XAML</span><span class="sxs-lookup"><span data-stu-id="4c8a1-239">Add this XAML</span></span>**

    ```xaml
    xmlns:telerikInput="using:Telerik.UI.Xaml.Controls.Input"
    ```

    **<span data-ttu-id="4c8a1-240">追加先: 最後の xmlns: エントリの後</span><span class="sxs-lookup"><span data-stu-id="4c8a1-240">After the last 'xmlns:' entry</span></span>**

    ```xaml
    <Page x:Name="page"
      x:Class="PhotoLab.MainPage"
      xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
      xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
      xmlns:local="using:PhotoLab"
      xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
      xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
      xmlns:telerikInput="using:Telerik.UI.Xaml.Controls.Input"
      mc:Ignorable="d"
      NavigationCacheMode="Enabled">
    ```

    <span data-ttu-id="4c8a1-241">XAML 名前空間について詳しくは、「[XAML 名前空間と名前空間マッピング](https://docs.microsoft.com/windows/uwp/xaml-platform/xaml-namespaces-and-namespace-mapping)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-241">For more info about XAML namespaces, see [XAML namespaces and namespace mapping](https://docs.microsoft.com/windows/uwp/xaml-platform/xaml-namespaces-and-namespace-mapping).</span></span>

3. <span data-ttu-id="4c8a1-242">ドキュメント アウトラインで、**ImageGridView** を右クリックします。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-242">In Document Outline, right-click **ImageGridView**.</span></span> <span data-ttu-id="4c8a1-243">コンテキスト メニューで、**[追加テンプレートの編集] > [生成されたアイテムの編集 (ItemTemplate)] > [空アイテムの作成]** を選択します。**[リソースの作成]** ダイアログが開きます。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-243">In the context menu, select **Edit Additional Templates > Edit Generated Items (ItemTemplate) > Create Empty...**. The **Create Resource** dialog opens.</span></span>

4. <span data-ttu-id="4c8a1-244">ダイアログで、[名前 (キー)] の値を **ImageGridView_DefaultItemTemplate** に変更し、**[OK]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-244">In the dialog, change the Name (key) value to **ImageGridView_DefaultItemTemplate**, and then click **OK**.</span></span>

    <span data-ttu-id="4c8a1-245">**[OK]** をクリックすると、いくつかの処理が行われます。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-245">Several things happen when you click **OK**.</span></span>

    - <span data-ttu-id="4c8a1-246">MainPage.xaml の Page.Resources セクションに、**DataTemplate** が追加されます。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-246">A **DataTemplate** is added to the Page.Resources section of MainPage.xaml.</span></span>

        ```xaml
        <Page.Resources>
            <DataTemplate x:Key="ImageGridView_DefaultItemTemplate">
                <Grid/>
            </DataTemplate>
        </Page.Resources>
        ```

    - <span data-ttu-id="4c8a1-247">[ドキュメント アウトライン] のスコープが、この **DataTemplate** に設定されます。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-247">The Document Outline scope is set to this **DataTemplate**.</span></span>

        <span data-ttu-id="4c8a1-248">データ テンプレートの作成を終了したら、[ドキュメント アウトライン] の左上隅にある上向き矢印をクリックすると、ページのスコープに戻ることができます。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-248">When you're done creating the data template, you can click the up arrow in the top left corner of Document Outline to return to page scope.</span></span>

    - <span data-ttu-id="4c8a1-249">GridView の **ItemTemplate** プロパティが **DataTemplate** リソースに設定されます。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-249">The GridView's **ItemTemplate** property is set to the **DataTemplate** resource.</span></span>

    ```xaml
        <GridView x:Name="ImageGridView"
                  Margin="0,0,0,8"
                  RelativePanel.AlignLeftWithPanel="True"
                  RelativePanel.AlignRightWithPanel="True"
                  RelativePanel.Below="TitleTextBlock"
                  ItemTemplate="{StaticResource ImageGridView_DefaultItemTemplate}"/>
    ```

5. <span data-ttu-id="4c8a1-250">**ImageGridView_DefaultItemTemplate** リソースで、ルートの **Grid** の Height と Width に **300**、Margin に **8** を割り当てます。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-250">In the **ImageGridView_DefaultItemTemplate** resource, give the root **Grid** a Height and Width of **300**, and Margin of **8**.</span></span> <span data-ttu-id="4c8a1-251">次に、2 つの行を追加し、2 番目の行の Height を **Auto** に設定します。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-251">Then add two rows and set the Height of the second row to **Auto**.</span></span>

    **<span data-ttu-id="4c8a1-252">変更前</span><span class="sxs-lookup"><span data-stu-id="4c8a1-252">Before</span></span>**
    ```xaml
    <Grid/>
    ```

    **<span data-ttu-id="4c8a1-253">変更後</span><span class="sxs-lookup"><span data-stu-id="4c8a1-253">After</span></span>**
    ```xaml
    <Grid Height="300"
          Width="300"
          Margin="8">
        <Grid.RowDefinitions>
            <RowDefinition />
            <RowDefinition Height="Auto" />
        </Grid.RowDefinitions>
    </Grid>
    ```

    <span data-ttu-id="4c8a1-254">Grid レイアウトについて詳しくは、「[レイアウト パネル](https://docs.microsoft.com/windows/uwp/layout/layout-panels#grid)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-254">For more info about Grid layouts, see [Layout panels](https://docs.microsoft.com/windows/uwp/layout/layout-panels#grid).</span></span>

6. <span data-ttu-id="4c8a1-255">Grid にコントロールを追加します。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-255">Add controls to the Grid.</span></span>

    <span data-ttu-id="4c8a1-256">a. </span><span class="sxs-lookup"><span data-stu-id="4c8a1-256">a.</span></span> <span data-ttu-id="4c8a1-257">最初のグリッド行に **Image** コントロールを追加します。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-257">Add an **Image** control in the first grid row.</span></span> <span data-ttu-id="4c8a1-258">これはイメージを表示する場所ですが、この時点では、プレースホルダーとしてアプリのストアのロゴを使用します。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-258">This is where the image will be shown, but for now, you'll use the app's store logo as a placeholder.</span></span>

    <span data-ttu-id="4c8a1-259">b. </span><span class="sxs-lookup"><span data-stu-id="4c8a1-259">b.</span></span> <span data-ttu-id="4c8a1-260">イメージの名前、ファイルの種類、サイズを表示する **TextBlock** コントロールを追加します。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-260">Add **TextBlock** controls to show the image's name, file type, and dimensions.</span></span> <span data-ttu-id="4c8a1-261">これには、テキスト ブロックを配置するための **StackPanel** コントロールを使用します。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-261">For this, you use **StackPanel** controls to arrange the text blocks.</span></span>

    <span data-ttu-id="4c8a1-262">**StackPanel** レイアウトについて詳しくは、「[レイアウト パネル](https://docs.microsoft.com/windows/uwp/layout/layout-panels#stackpanel)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-262">For more info about **StackPanel** layout, see [Layout panels](https://docs.microsoft.com/windows/uwp/layout/layout-panels#stackpanel)</span></span>

    <span data-ttu-id="4c8a1-263">c. </span><span class="sxs-lookup"><span data-stu-id="4c8a1-263">c.</span></span> <span data-ttu-id="4c8a1-264">外側 (垂直方向) の **StackPanel** に **RadRating** コントロールを追加します。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-264">Add the **RadRating** control to the outer (vertical) **StackPanel**.</span></span> <span data-ttu-id="4c8a1-265">これは内側 (水平方向) の **StackPanel** の後に配置します。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-265">Place it after the inner (horizontal) **StackPanel**.</span></span>

    **<span data-ttu-id="4c8a1-266">最終的なテンプレート</span><span class="sxs-lookup"><span data-stu-id="4c8a1-266">The final template</span></span>**

    ```xaml
    <Grid Height="300"
          Width="300"
          Margin="8">
        <Grid.RowDefinitions>
            <RowDefinition />
            <RowDefinition Height="Auto" />
        </Grid.RowDefinitions>

        <Image x:Name="ItemImage"
               Source="Assets/StoreLogo.png"
               Stretch="Uniform" />

        <StackPanel Orientation="Vertical"
                    Grid.Row="1">
            <TextBlock Text="ImageTitle"
                       HorizontalAlignment="Center"
                       Style="{StaticResource SubtitleTextBlockStyle}" />
            <StackPanel Orientation="Horizontal"
                        HorizontalAlignment="Center">
                <TextBlock Text="ImageFileType"
                           HorizontalAlignment="Center"
                           Style="{StaticResource CaptionTextBlockStyle}" />
                <TextBlock Text="ImageDimensions"
                           HorizontalAlignment="Center"
                           Style="{StaticResource CaptionTextBlockStyle}"
                           Margin="8,0,0,0" />
            </StackPanel>

            <telerikInput:RadRating Value="3"
                                    IsReadOnly="True">
                <telerikInput:RadRating.FilledIconContentTemplate>
                    <DataTemplate>
                        <SymbolIcon Symbol="SolidStar"
                                    Foreground="White" />
                    </DataTemplate>
                </telerikInput:RadRating.FilledIconContentTemplate>
                <telerikInput:RadRating.EmptyIconContentTemplate>
                    <DataTemplate>
                        <SymbolIcon Symbol="OutlineStar"
                                    Foreground="White" />
                    </DataTemplate>
                </telerikInput:RadRating.EmptyIconContentTemplate>
            </telerikInput:RadRating>

        </StackPanel>
    </Grid>
    ```

<span data-ttu-id="4c8a1-267">ここでアプリを実行し、作成した項目テンプレートで **GridView** を確認します。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-267">Run the app now to see the **GridView** with the item template you just created.</span></span> <span data-ttu-id="4c8a1-268">評価コントロールは、白の背景と白い星であるため、見えない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-268">You might not see the rating control, though, because it has white stars on a white background.</span></span> <span data-ttu-id="4c8a1-269">次は、背景色を変更します。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-269">You'll change the background color next.</span></span>

![アプリの UI チェックポイント 2](images/xaml-basics/layout-1.png)

## <a name="part-4-modify-the-item-container-style"></a><span data-ttu-id="4c8a1-271">パート 4: 項目コンテナーのスタイルを変更する</span><span class="sxs-lookup"><span data-stu-id="4c8a1-271">Part 4: Modify the item container style</span></span>

<span data-ttu-id="4c8a1-272">項目のコントロール テンプレートには、選択、ホバー、フォーカスなどの状態を表示する視覚効果が含まれています。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-272">An item’s control template contains the visuals that display state, like selection, pointer over, and focus.</span></span> <span data-ttu-id="4c8a1-273">これらの視覚効果は、データ テンプレートの上または下にレンダリングされます。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-273">These visuals are rendered either on top of or below the data template.</span></span> <span data-ttu-id="4c8a1-274">ここでは、コントロール テンプレートの **Background** プロパティおよび **Margin** プロパティを変更して、**GridView** 項目の背景色を灰色にします。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-274">Here, you'll modify the **Background** and **Margin** properties of the control template to give the **GridView** items a gray background.</span></span>

**<span data-ttu-id="4c8a1-275">項目コンテナーを変更する</span><span class="sxs-lookup"><span data-stu-id="4c8a1-275">Modify the item container</span></span>**

1. <span data-ttu-id="4c8a1-276">ドキュメント アウトラインで、**ImageGridView** を右クリックします。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-276">In Document Outline, right-click **ImageGridView**.</span></span> <span data-ttu-id="4c8a1-277">コンテキスト メニューで、**[追加テンプレートの編集] > [生成されたアイテム コンテナーの編集 (ItemContainerStyle)] > [コピーして編集]** を選択します。**[リソースの作成]** ダイアログが開きます。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-277">On the context menu, select **Edit Additional Templates > Edit Generated Item Container (ItemContainerStyle) > Edit a Copy...**. The **Create Resource** dialog opens.</span></span>

2. <span data-ttu-id="4c8a1-278">ダイアログで、[名前 (キー)] の値を **ImageGridView_DefaultItemContainerStyle** に変更し、**[OK]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-278">In the dialog, change the Name (key) value to **ImageGridView_DefaultItemContainerStyle**, then click **OK**.</span></span>

    <span data-ttu-id="4c8a1-279">既定スタイルのコピーが XAML の **Page.Resources** セクションに追加されます。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-279">A copy of the default style is added to the **Page.Resources** section of your XAML.</span></span>

    ```xaml
    <Style x:Key="ImageGridView_DefaultItemContainerStyle" TargetType="GridViewItem">
        <Setter Property="FontFamily" Value="{ThemeResource ContentControlThemeFontFamily}"/>
        <Setter Property="FontSize" Value="{ThemeResource ControlContentThemeFontSize}"/>
        <Setter Property="Background" Value="{ThemeResource GridViewItemBackground}"/>
        <Setter Property="Foreground" Value="{ThemeResource GridViewItemForeground}"/>
        <Setter Property="TabNavigation" Value="Local"/>
        <Setter Property="IsHoldingEnabled" Value="True"/>
        <Setter Property="HorizontalContentAlignment" Value="Center"/>
        <Setter Property="VerticalContentAlignment" Value="Center"/>
        <Setter Property="Margin" Value="0,0,4,4"/>
        <Setter Property="MinWidth" Value="{ThemeResource GridViewItemMinWidth}"/>
        <Setter Property="MinHeight" Value="{ThemeResource GridViewItemMinHeight}"/>
        <Setter Property="AllowDrop" Value="False"/>
        <Setter Property="UseSystemFocusVisuals" Value="True"/>
        <Setter Property="FocusVisualMargin" Value="-2"/>
        <Setter Property="FocusVisualPrimaryBrush" Value="{ThemeResource GridViewItemFocusVisualPrimaryBrush}"/>
        <Setter Property="FocusVisualPrimaryThickness" Value="2"/>
        <Setter Property="FocusVisualSecondaryBrush" Value="{ThemeResource GridViewItemFocusVisualSecondaryBrush}"/>
        <Setter Property="FocusVisualSecondaryThickness" Value="1"/>
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="GridViewItem">
                <!-- XAML removed for clarity
                    <ListViewItemPresenter ... />
                -->   
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
    ```

    <span data-ttu-id="4c8a1-280">**GridViewItem** 既定スタイルでは、多数のプロパティが設定されます。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-280">The **GridViewItem** default style sets a lot of properties.</span></span> <span data-ttu-id="4c8a1-281">常に既定のスタイルのコピーを作成し、必要なプロパティのみ変更することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-281">You should always start with a copy of the default style and modify only the properties necessary.</span></span> <span data-ttu-id="4c8a1-282">そうしないと、一部のプロパティを正しく設定していないことが原因で、視覚効果が期待どおりに表示されない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-282">Otherwise, the visuals might not show up the way you expect because some properties won't be set correctly.</span></span>

    <span data-ttu-id="4c8a1-283">また、前の手順と同様、GridView の **ItemContainerStyle** プロパティが新しい **Style** リソースに設定されます。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-283">And as in the previous step, the GridView's **ItemContainerStyle** property is set to the new **Style** resource.</span></span>

    ```xaml
        <GridView x:Name="ImageGridView"
                  Margin="0,0,0,8"
                  RelativePanel.AlignLeftWithPanel="True"
                  RelativePanel.AlignRightWithPanel="True"
                  RelativePanel.Below="TitleTextBlock"
                  ItemTemplate="{StaticResource ImageGridView_DefaultItemTemplate}"
                  ItemContainerStyle="{StaticResource ImageGridView_DefaultItemContainerStyle}"/>
    ```

3. <span data-ttu-id="4c8a1-284">**Background** プロパティの値を **Gray** に変更します。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-284">Change the value for the **Background** property to **Gray**.</span></span>

    **<span data-ttu-id="4c8a1-285">変更前</span><span class="sxs-lookup"><span data-stu-id="4c8a1-285">Before</span></span>**
    ```xaml
        <Setter Property="Background" Value="{ThemeResource GridViewItemBackground}"/>
    ```

    **<span data-ttu-id="4c8a1-286">変更後</span><span class="sxs-lookup"><span data-stu-id="4c8a1-286">After</span></span>**
    ```xaml
        <Setter Property="Background" Value="Gray"/>
    ```

4. <span data-ttu-id="4c8a1-287">**Margin** プロパティの値を **8** に変更します。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-287">Change the value for the **Margin** property to **8**.</span></span>

    **<span data-ttu-id="4c8a1-288">変更前</span><span class="sxs-lookup"><span data-stu-id="4c8a1-288">Before</span></span>**
    ```xaml
        <Setter Property="Margin" Value="0,0,4,4"/>
    ```

    **<span data-ttu-id="4c8a1-289">変更後</span><span class="sxs-lookup"><span data-stu-id="4c8a1-289">After</span></span>**
    ```xaml
        <Setter Property="Margin" Value="8"/>
    ```

<span data-ttu-id="4c8a1-290">アプリを実行して、この時点での結果を確認します。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-290">Run the app and see how it looks now.</span></span> <span data-ttu-id="4c8a1-291">アプリ ウィンドウのサイズを変更します。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-291">Resize the app window.</span></span> <span data-ttu-id="4c8a1-292">イメージの再配置は **GridView** によって自動的に処理されますが、幅によっては、アプリ ウィンドウの右余白が大きくなりすぎることがあります。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-292">The **GridView** takes care of rearranging the images for you, but at some widths, there's a lot of space on the right side of the app window.</span></span> <span data-ttu-id="4c8a1-293">このような場合は、イメージを中央に配置した方が見栄えが良くなります。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-293">It would look better if the images were centered.</span></span> <span data-ttu-id="4c8a1-294">次は、この点に関する対応を行います。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-294">We'll take care of that next.</span></span>

![アプリの UI チェックポイント 3](images/xaml-basics/layout-2.png)

> [!Note]
> <span data-ttu-id="4c8a1-296">時間に余裕があれば、Background プロパティと Margin プロパティをさまざまな値に設定して、その結果がどうなるか試してみてください。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-296">If you'd like to experiment, try setting the Background and Margin properties to different values and see what effect it has.</span></span>

## <a name="part-5-apply-some-final-adjustments-to-the-layout"></a><span data-ttu-id="4c8a1-297">パート 5: レイアウトに最終調整を適用する</span><span class="sxs-lookup"><span data-stu-id="4c8a1-297">Part 5: Apply some final adjustments to the layout</span></span>

<span data-ttu-id="4c8a1-298">イメージをページの中央に配置するには、ページ内で Grid の配置を調整する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-298">To center the images in the page, you need to adjust the alignment of the Grid in the page.</span></span> <span data-ttu-id="4c8a1-299">それとも、**GridView** 内でイメージの配置を調整した方がよいでしょうか。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-299">Or do you need to adjust the alignment of the Images in the **GridView**?</span></span> <span data-ttu-id="4c8a1-300">どちらでも同じでしょうか? </span><span class="sxs-lookup"><span data-stu-id="4c8a1-300">Does it matter?</span></span> <span data-ttu-id="4c8a1-301">見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-301">Let's see.</span></span>

<span data-ttu-id="4c8a1-302">配置について詳しくは、「[配置、余白、パディング](../layout/alignment-margin-padding.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-302">For more info about alignment, see [Alignment, margins, and padding](../layout/alignment-margin-padding.md).</span></span>

<span data-ttu-id="4c8a1-303">(この手順で、**GridView** の **Background** を好きな色に設定することもできます。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-303">(You might try setting the **Background** of the **GridView** to your favorite color for this step.</span></span> <span data-ttu-id="4c8a1-304">その方が、レイアウトの変化がわかりやすくなります。)</span><span class="sxs-lookup"><span data-stu-id="4c8a1-304">It will let you see more clearly what's happening with the layout.)</span></span>

**<span data-ttu-id="4c8a1-305">イメージの配置を変更する</span><span class="sxs-lookup"><span data-stu-id="4c8a1-305">Modify the alignment of the images</span></span>**

1. <span data-ttu-id="4c8a1-306">**Gridview** で、**HorizontalAlignment** プロパティを **Center** に設定します。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-306">In the **Gridview**, set the **HorizontalAlignment** property to **Center**.</span></span>

    **<span data-ttu-id="4c8a1-307">変更前</span><span class="sxs-lookup"><span data-stu-id="4c8a1-307">Before</span></span>**
    ```xaml
        <GridView x:Name="ImageGridView"
                  Margin="0,0,0,8"
                  RelativePanel.AlignLeftWithPanel="True"
                  RelativePanel.AlignRightWithPanel="True"
                  RelativePanel.Below="TitleTextBlock"
                  ItemTemplate="{StaticResource ImageGridView_DefaultItemTemplate}"
                  ItemContainerStyle="{StaticResource ImageGridView_DefaultItemContainerStyle}"/>
    ```

    **<span data-ttu-id="4c8a1-308">変更後</span><span class="sxs-lookup"><span data-stu-id="4c8a1-308">After</span></span>**
    ```xaml
        <GridView x:Name="ImageGridView"
                  Margin="0,0,0,8"
                  RelativePanel.AlignLeftWithPanel="True"
                  RelativePanel.AlignRightWithPanel="True"
                  RelativePanel.Below="TitleTextBlock"
                  ItemTemplate="{StaticResource ImageGridView_DefaultItemTemplate}"
                  ItemContainerStyle="{StaticResource ImageGridView_DefaultItemContainerStyle}" 
                  HorizontalAlignment="Center"/>
    ```

2. <span data-ttu-id="4c8a1-309">アプリを実行し、ウィンドウのサイズを変更します。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-309">Run the app and resize the window.</span></span> <span data-ttu-id="4c8a1-310">下へスクロールして、さらに多くのイメージを表示します。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-310">Scroll down to see more images.</span></span>

    <span data-ttu-id="4c8a1-311">イメージは中央揃えで表示され、見栄えが良くなっています。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-311">The images are centered, which looks better.</span></span> <span data-ttu-id="4c8a1-312">ただし、スクロール バーがウィンドウの端ではなく **GridView** の端に位置合わせされています。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-312">However, the scrollbar is aligned with the edge of **GridView** instead of with the edge of the window.</span></span> <span data-ttu-id="4c8a1-313">この問題を解決するには、ページ内で **GridView** を中央揃えにするのではなく、**GridView** 内でイメージを中央揃えにします。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-313">To fix this, you'll center the images in the **GridView** rather than centering the **GridView** in the page.</span></span> <span data-ttu-id="4c8a1-314">少し手間がかかりますが、最終的な見栄えは良くなります。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-314">It's a little more work, but it will look better in the end.</span></span>

3. <span data-ttu-id="4c8a1-315">前の手順で使用した **HorizontalAlignment** 設定を削除します。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-315">Remove the **HorizontalAlignment** setting from the previous step.</span></span>

4. <span data-ttu-id="4c8a1-316">ドキュメント アウトラインで、**ImageGridView** を右クリックします。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-316">In Document Outline, right-click **ImageGridView**.</span></span> <span data-ttu-id="4c8a1-317">コンテキスト メニューで、**[追加テンプレートの編集] > [アイテムのレイアウトの編集 (ItemsPanel)] > [コピーして編集]** を選択します。**[リソースの作成]** ダイアログが開きます。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-317">On the context menu, select **Edit Additional Templates > Edit Layout of Items (ItemsPanel) > Edit a Copy...**. The **Create Resource** dialog opens.</span></span>

5. <span data-ttu-id="4c8a1-318">ダイアログで、[名前 (キー)] の値を **ImageGridView_ItemsPanelTemplate** に変更し、**[OK]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-318">In the dialog, change the Name (key) value to **ImageGridView_ItemsPanelTemplate**, and then click **OK**.</span></span>

    <span data-ttu-id="4c8a1-319">既定の **ItemsPanelTemplate** のコピーが XAML の **Page.Resources** セクションに追加されます </span><span class="sxs-lookup"><span data-stu-id="4c8a1-319">A copy of the default **ItemsPanelTemplate** is added to the **Page.Resources** section of your XAML.</span></span> <span data-ttu-id="4c8a1-320">(今回も、このリソースを参照するように **GridView** が更新されます)。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-320">(And as before, the **GridView** is updated to reference this resource.)</span></span>

    ```xaml
    <ItemsPanelTemplate x:Key="ImageGridView_ItemsPanelTemplate">
        <ItemsWrapGrid Orientation="Horizontal" />
    </ItemsPanelTemplate>
    ```

    <span data-ttu-id="4c8a1-321">アプリ内の各種コントロールをレイアウトするためにさまざまなパネルを使用してきましたが、**GridView** にも、項目のレイアウトを管理する内部パネルがあります。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-321">Just as you've used various panels to layout the controls in your app, the **GridView** has an internal panel that manages the layout of its items.</span></span> <span data-ttu-id="4c8a1-322">このパネル (**ItemsWrapGrid**) にアクセスできるようになったため、パネルのプロパティを変更して、**GridView** 内にある項目のレイアウトを変更します。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-322">Now that you have access to this panel (the **ItemsWrapGrid**), you can modify its properties to change the layout of items inside the **GridView**.</span></span>

6. <span data-ttu-id="4c8a1-323">**ItemsWrapGrid** で、**HorizontalAlignment** プロパティを **Center** に設定します。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-323">In the **ItemsWrapGrid**, set the **HorizontalAlignment** property to **Center**.</span></span>

    **<span data-ttu-id="4c8a1-324">変更前</span><span class="sxs-lookup"><span data-stu-id="4c8a1-324">Before</span></span>**
    ```xaml
    <ItemsPanelTemplate x:Key="ImageGridView_ItemsPanelTemplate">
        <ItemsWrapGrid Orientation="Horizontal" />
    </ItemsPanelTemplate>
    ```

    **<span data-ttu-id="4c8a1-325">変更後</span><span class="sxs-lookup"><span data-stu-id="4c8a1-325">After</span></span>**
    ```xaml
    <ItemsPanelTemplate x:Key="ImageGridView_ItemsPanelTemplate">
        <ItemsWrapGrid Orientation="Horizontal"
                       HorizontalAlignment="Center"/>
    </ItemsPanelTemplate>
    ```

7. <span data-ttu-id="4c8a1-326">アプリを実行し、ウィンドウのサイズをもう一度変更します。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-326">Run the app and resize the window again.</span></span> <span data-ttu-id="4c8a1-327">下へスクロールして、さらに多くのイメージを表示します。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-327">Scroll down to see more images.</span></span>

![アプリの UI チェックポイント 4](images/xaml-basics/layout-3.png)

<span data-ttu-id="4c8a1-329">これで、スクロール バーがウィンドウの端に位置合わせされました。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-329">Now, the scrollbar is aligned with the edge of the window.</span></span> <span data-ttu-id="4c8a1-330">おめでとうございます! </span><span class="sxs-lookup"><span data-stu-id="4c8a1-330">Good job!</span></span> <span data-ttu-id="4c8a1-331">アプリの基本的な UI を作成できました。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-331">You've created the basic UI for your app.</span></span>

## <a name="going-further"></a><span data-ttu-id="4c8a1-332">追加情報</span><span class="sxs-lookup"><span data-stu-id="4c8a1-332">Going further</span></span>

<span data-ttu-id="4c8a1-333">これで基本的な UI を作成できたため、やはり PhotoLab サンプルに基づいているその他のチュートリアルも確認してください。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-333">Now that you've created the basic UI, checkout out these other tutorials, also based on the PhotoLab sample:</span></span> 

* <span data-ttu-id="4c8a1-334">「[XAML データ バインディングのチュートリアル](../../data-binding/xaml-basics-data-binding.md)」では、実際のイメージとデータを追加します。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-334">Add real images and data in the [XAML data binding tutorial](../../data-binding/xaml-basics-data-binding.md).</span></span>
* <span data-ttu-id="4c8a1-335">「[XAML アダプティブ レイアウトのチュートリアル](xaml-basics-adaptive-layout.md)」では、さまざまな画面サイズに合わせて UI を調整します。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-335">Make the UI adapt to different screen sizes in the [XAML adaptive layout tutorial](xaml-basics-adaptive-layout.md).</span></span>


## <a name="get-the-final-version-of-the-photolab-sample"></a><span data-ttu-id="4c8a1-336">PhotoLab サンプルの最終バージョンを入手する</span><span class="sxs-lookup"><span data-stu-id="4c8a1-336">Get the final version of the PhotoLab sample</span></span>

<span data-ttu-id="4c8a1-337">このチュートリアルで完全な写真編集アプリは作成されません。必ず[最終バージョン](https://github.com/Microsoft/Windows-appsample-photo-lab)でカスタム アニメーションやスマートフォン サポートなど、他の機能を確認してください。</span><span class="sxs-lookup"><span data-stu-id="4c8a1-337">This tutorial doesn't build up to the complete photo editing app, so be sure to check out the [final version](https://github.com/Microsoft/Windows-appsample-photo-lab) to see other features such as custom animations and phone support.</span></span>

