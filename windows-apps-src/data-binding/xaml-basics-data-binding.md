---
title: データ バインディングを作成する
description: この記事では、XAML でのデータ バインディングの基礎について説明します。
keywords: XAML, UWP, 概要
ms.date: 08/30/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 21a053934d7391d12f7cd987026524b9ff4c279d
ms.sourcegitcommit: a3dc929858415b933943bba5aa7487ffa721899f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/07/2018
ms.locfileid: "8790324"
---
# <a name="create-data-bindings"></a><span data-ttu-id="85b07-104">データ バインディングを作成する</span><span class="sxs-lookup"><span data-stu-id="85b07-104">Create data bindings</span></span>

<span data-ttu-id="85b07-105">見栄えの良い UI をデザインして実装するとしましょう。その場合はまず、プレースホルダー イメージやダミーのボイラープレート テキスト、まだ何も動作しないコントロールを配置します。</span><span class="sxs-lookup"><span data-stu-id="85b07-105">Suppose you've designed and implemented a nice looking UI filled with placeholder images, "lorem ipsum" boilerplate text, and controls that don't do anything yet.</span></span> <span data-ttu-id="85b07-106">次に、実際のデータに接続し、設計プロトタイプからライブ アプリに変換します。</span><span class="sxs-lookup"><span data-stu-id="85b07-106">Next, you'll want to connect it to real data and transform it from a design prototype into a living app.</span></span> 

<span data-ttu-id="85b07-107">このチュートリアルでは、ボイラープレートをデータ バインディングに置き換え、UI とデータの間で直接リンクを作成する方法を学習します。</span><span class="sxs-lookup"><span data-stu-id="85b07-107">In this tutorial, you'll learn how to replace your boilerplate with data bindings and create other direct links between your UI and your data.</span></span> <span data-ttu-id="85b07-108">また、データを表示用に書式化または変換し、UI とデータの同期を維持する方法についても学習します。このチュートリアルを完了すると、XAML および C# コードのわかりやすさと構造を改善し、保守や拡張が容易なコードを作成できるようになります。</span><span class="sxs-lookup"><span data-stu-id="85b07-108">You'll also learn how to format or convert your data for display, and keep your UI and data in sync. When you complete this tutorial, you'll be able to improve the simplicity and organization of the XAML and C# code, making it easier to maintain and extend.</span></span>

<span data-ttu-id="85b07-109">まず、PhotoLab サンプルの簡易バージョンから開始します。</span><span class="sxs-lookup"><span data-stu-id="85b07-109">You'll start with a simplified version of the PhotoLab sample.</span></span> <span data-ttu-id="85b07-110">このスターター バージョンには、完全なデータ レイヤーと基本的な XAML ページ レイアウトが含まれています。ただしこのバージョンでは、コードを見やすくするために多くの機能が除外されています。</span><span class="sxs-lookup"><span data-stu-id="85b07-110">This starter version includes the complete data layer plus the basic XAML page layouts, and leaves out many features to make the code easier to browse around in.</span></span> <span data-ttu-id="85b07-111">このチュートリアルで完全なアプリは作成されません。必ず最終バージョンでカスタム アニメーションやスマートフォン サポートなどの機能を確認してください。</span><span class="sxs-lookup"><span data-stu-id="85b07-111">This tutorial doesn't build up to the complete app, so be sure to check out the final version to see features such as custom animations and phone support.</span></span> <span data-ttu-id="85b07-112">最終バージョンは、[Windows-appsample-photo-lab](https://github.com/Microsoft/Windows-appsample-photo-lab) リポジトリのルート フォルダーにあります。</span><span class="sxs-lookup"><span data-stu-id="85b07-112">You can find the final version in the root folder of the [Windows-appsample-photo-lab](https://github.com/Microsoft/Windows-appsample-photo-lab) repo.</span></span> 

## <a name="prerequisites"></a><span data-ttu-id="85b07-113">前提条件</span><span class="sxs-lookup"><span data-stu-id="85b07-113">Prerequisites</span></span>

* <span data-ttu-id="85b07-114">[Visual Studio 2017 と Windows 10 SDK の最新バージョン](https://developer.microsoft.com/windows/downloads)。</span><span class="sxs-lookup"><span data-stu-id="85b07-114">[Visual Studio 2017 and the latest version of the Windows 10 SDK](https://developer.microsoft.com/windows/downloads).</span></span>

## <a name="part-0-get-the-code"></a><span data-ttu-id="85b07-115">パート 0: コードを入手する</span><span class="sxs-lookup"><span data-stu-id="85b07-115">Part 0: Get the code</span></span>
<span data-ttu-id="85b07-116">この演習の開始点は、PhotoLab サンプル リポジトリ ([xaml-basics-starting-points/data-binding](https://github.com/Microsoft/Windows-appsample-photo-lab/tree/master/xaml-basics-starting-points/data-binding) フォルダー) です。</span><span class="sxs-lookup"><span data-stu-id="85b07-116">The starting point for this lab is located in the PhotoLab sample repository, in the [xaml-basics-starting-points/data-binding](https://github.com/Microsoft/Windows-appsample-photo-lab/tree/master/xaml-basics-starting-points/data-binding) folder.</span></span> <span data-ttu-id="85b07-117">このリポジトリを複製またはダウンロードした後、Visual Studio 2017 で PhotoLab.sln を開くことによって、プロジェクトを編集できます。</span><span class="sxs-lookup"><span data-stu-id="85b07-117">After you've cloned or downloaded the repo, you can edit the project by opening PhotoLab.sln with Visual Studio 2017.</span></span>

<span data-ttu-id="85b07-118">PhotoLab アプリには、次の 2 つのプライマリ ページがあります。</span><span class="sxs-lookup"><span data-stu-id="85b07-118">The PhotoLab app has two primary pages:</span></span>

<span data-ttu-id="85b07-119">**MainPage.xaml:** フォト ギャラリー ビューが各イメージ ファイルに関する情報と共に表示されます。</span><span class="sxs-lookup"><span data-stu-id="85b07-119">**MainPage.xaml:** displays a photo gallery view, along with some information about each image file.</span></span>
![MainPage](../design/basics/images/xaml-basics/mainpage.png)

<span data-ttu-id="85b07-121">**DetailPage.xaml:** 選択された単一の写真が表示されます。</span><span class="sxs-lookup"><span data-stu-id="85b07-121">**DetailPage.xaml:** displays a single photo after it has been selected.</span></span> <span data-ttu-id="85b07-122">ポップアップの編集メニューにより、写真の編集、名前変更、保存を行うことができます。</span><span class="sxs-lookup"><span data-stu-id="85b07-122">A flyout editing menu allows the photo to be altered, renamed, and saved.</span></span>
![DetailPage](../design/basics/images/xaml-basics/detailpage.png)

## <a name="part-1-replace-the-placeholders"></a><span data-ttu-id="85b07-124">パート 1: プレースホルダーを置き換える</span><span class="sxs-lookup"><span data-stu-id="85b07-124">Part 1: Replace the placeholders</span></span>

<span data-ttu-id="85b07-125">ここでは、データ テンプレートの XAML で 1 回限りのバインディングを作成し、プレースホルダー コンテンツの代わりに実際のイメージとイメージ メタデータを表示します。</span><span class="sxs-lookup"><span data-stu-id="85b07-125">Here you'll create one-time bindings in data-template XAML to display real images and image metadata instead of placeholder content.</span></span> 

<span data-ttu-id="85b07-126">1 回限りのバインディングは読み取り専用の不変データです。したがって、これらは高パフォーマンスで簡単に作成でき、大きなデータ セットも **GridView** コントロールおよび **ListView** コントロールに表示できます。</span><span class="sxs-lookup"><span data-stu-id="85b07-126">One-time bindings are for read-only, unchanging data, which means they are high performance and easy to create, letting you display large data sets in **GridView** and **ListView** controls.</span></span> 

**<span data-ttu-id="85b07-127">プレースホルダーを 1 回限りのバインディングに置き換える</span><span class="sxs-lookup"><span data-stu-id="85b07-127">Replace the placeholders with one-time bindings</span></span>**

1. <span data-ttu-id="85b07-128">xaml-basics-starting-points\data-binding フォルダーを開き、PhotoLab.sln ファイルを起動します。</span><span class="sxs-lookup"><span data-stu-id="85b07-128">Open the xaml-basics-starting-points\data-binding folder and launch the PhotoLab.sln file.</span></span> 

2. <span data-ttu-id="85b07-129">ソリューション プラットフォームを必ず x86 または x64 (ARM は不可) に設定して、アプリを実行します。</span><span class="sxs-lookup"><span data-stu-id="85b07-129">Make sure your Solution Platform is set to x86 or x64, not ARM, and then run the app.</span></span> <span data-ttu-id="85b07-130">これにより、バインドを追加する前の、UI プレースホルダーがある状態のアプリが表示されます。</span><span class="sxs-lookup"><span data-stu-id="85b07-130">This shows the state of the app with UI placeholders, before bindings have been added.</span></span> 

    ![実行中のアプリにプレースホルダー イメージとテキストが表示された状態](../design/basics/images/xaml-basics/gallery-with-placeholder-templates.png)

3. <span data-ttu-id="85b07-132">MainPage.xaml を開き、**ImageGridView_DefaultItemTemplate** という名前の **DataTemplate** を探します。</span><span class="sxs-lookup"><span data-stu-id="85b07-132">Open MainPage.xaml and search for a **DataTemplate** named **ImageGridView_DefaultItemTemplate**.</span></span> <span data-ttu-id="85b07-133">データ バインディングを使用するには、このテンプレートを更新します。</span><span class="sxs-lookup"><span data-stu-id="85b07-133">You'll update this template to use data bindings.</span></span> 

    **<span data-ttu-id="85b07-134">変更前:</span><span class="sxs-lookup"><span data-stu-id="85b07-134">Before:</span></span>**
    ```xaml
    <DataTemplate x:Key="ImageGridView_DefaultItemTemplate">
    ```

    <span data-ttu-id="85b07-135">**x:Key**値は、データ オブジェクトの表示用にこのテンプレートを選択するために **ImageGridView** によって使用されます。</span><span class="sxs-lookup"><span data-stu-id="85b07-135">The **x:Key** value is used by the **ImageGridView** to select this template for displaying data objects.</span></span> 

4. <span data-ttu-id="85b07-136">テンプレートに **x:DataType** 値を追加します。</span><span class="sxs-lookup"><span data-stu-id="85b07-136">Add an **x:DataType** value to the template.</span></span> 

    **<span data-ttu-id="85b07-137">変更後:</span><span class="sxs-lookup"><span data-stu-id="85b07-137">After:</span></span>**
    ```xaml
    <DataTemplate x:Key="ImageGridView_DefaultItemTemplate" 
                  x:DataType="local:ImageFileInfo">
    ```

    <span data-ttu-id="85b07-138">**x:DataType** は、このテンプレートが対応する型を示します。</span><span class="sxs-lookup"><span data-stu-id="85b07-138">**x:DataType** indicates which type this is a template for.</span></span> <span data-ttu-id="85b07-139">この場合、このテンプレートが対応する型は **ImageFileInfo** クラスです ("local:" は local 名前空間を示します。これは、ファイルの先頭近くの xmlns 宣言で定義されています)。</span><span class="sxs-lookup"><span data-stu-id="85b07-139">In this case, it's a template for the **ImageFileInfo** class (where "local:" indicates the local namespace, as defined in an xmlns declaration near the top of the file).</span></span>
    
    <span data-ttu-id="85b07-140">次に示すように、データ テンプレートで **x:Bind** 式を使用する場合には **x:DataType** が必要です。</span><span class="sxs-lookup"><span data-stu-id="85b07-140">**x:DataType** is required when using **x:Bind** expressions in a data template, as described next.</span></span> 

5. <span data-ttu-id="85b07-141">**DataTemplate** で、**ItemImage** という名前の **Image** 要素を探し、**Source** 値を次のように置き換えます。</span><span class="sxs-lookup"><span data-stu-id="85b07-141">In the **DataTemplate**, find the **Image** element named **ItemImage** and replace its **Source** value as shown.</span></span> 

    **<span data-ttu-id="85b07-142">変更前:</span><span class="sxs-lookup"><span data-stu-id="85b07-142">Before:</span></span>**
    ```xaml
    <Image x:Name="ItemImage" 
           Source="/Assets/StoreLogo.png" 
           Stretch="Uniform" />
    ```
    
    **<span data-ttu-id="85b07-143">変更後:</span><span class="sxs-lookup"><span data-stu-id="85b07-143">After:</span></span>**
    ```xaml
    <Image x:Name="ItemImage" 
           Source="{x:Bind ImageSource}" 
           Stretch="Uniform" />
    ```
    
    <span data-ttu-id="85b07-144">**x:Name** は XAML 要素を表し、XAML およびコード ビハインド内の任意の場所から参照できます。</span><span class="sxs-lookup"><span data-stu-id="85b07-144">**x:Name** identifies a XAML element so you can refer to it elsewhere in the XAML and in the code-behind.</span></span> 

    <span data-ttu-id="85b07-145">**x:Bind** 式は、**data-object** プロパティから値を取得して UI プロパティに値を提供します。</span><span class="sxs-lookup"><span data-stu-id="85b07-145">**x:Bind** expressions supply a value to a UI property by getting the value from a **data-object** property.</span></span> <span data-ttu-id="85b07-146">テンプレート内で示されているプロパティは、**x:DataType** が設定されている対象のプロパティです。</span><span class="sxs-lookup"><span data-stu-id="85b07-146">In templates, the property indicated is a property of whatever the **x:DataType** has been set to.</span></span> <span data-ttu-id="85b07-147">この場合は、**ImageFileInfo.ImageSource** プロパティがデータ ソースです。</span><span class="sxs-lookup"><span data-stu-id="85b07-147">So in this case, the data source is the **ImageFileInfo.ImageSource** property.</span></span> 
    
    > [!NOTE] 
    > <span data-ttu-id="85b07-148">**x:Bind** 値によってデータ型がエディターに通知されるため、**x:Bind** 式にプロパティ名を入力する代わりに IntelliSense を使用することもできます。</span><span class="sxs-lookup"><span data-stu-id="85b07-148">The **x:Bind** value also lets the editor know about the data type, so you can use IntelliSense instead of typing in the property name in an **x:Bind** expression.</span></span> <span data-ttu-id="85b07-149">先ほど貼り付けたコードで試すこともでき、**x:Bind** の直後にカーソルを置いて Space キーを押すと、バインド可能なプロパティの一覧が表示されます。</span><span class="sxs-lookup"><span data-stu-id="85b07-149">Try it on the code you just pasted in: place the cursor just after **x:Bind** and press the Spacebar to see a list of properties you can bind to.</span></span>

6. <span data-ttu-id="85b07-150">他の UI コントロールの値も、同じ方法で置き換えます。</span><span class="sxs-lookup"><span data-stu-id="85b07-150">Replace the values of the other UI controls in the same way.</span></span> <span data-ttu-id="85b07-151">コピー/貼り付けではなく、IntelliSense を使ってみてください。</span><span class="sxs-lookup"><span data-stu-id="85b07-151">(Try doing this with IntelliSense instead of copy/pasting!)</span></span>

    **<span data-ttu-id="85b07-152">変更前:</span><span class="sxs-lookup"><span data-stu-id="85b07-152">Before:</span></span>**
    ```xaml
    <TextBlock Text="Placeholder" ... />
    <StackPanel ... >
        <TextBlock Text="PNG file" ... />
        <TextBlock Text="50 x 50" ... />
    </StackPanel>
    <telerikInput:RadRating Value="3" ... />
    ```
    
    **<span data-ttu-id="85b07-153">変更後:</span><span class="sxs-lookup"><span data-stu-id="85b07-153">After:</span></span>**
    ```xaml
    <TextBlock Text="{x:Bind ImageTitle}" ... />
    <StackPanel ... >
        <TextBlock Text="{x:Bind ImageFileType}" ... />
        <TextBlock Text="{x:Bind ImageDimensions}" ... />
    </StackPanel>
    <telerikInput:RadRating Value="{x:Bind ImageRating}" ... />
    ```

<span data-ttu-id="85b07-154">アプリを実行して、ここまでの結果を確認します。</span><span class="sxs-lookup"><span data-stu-id="85b07-154">Run the app to see how it looks so far.</span></span> <span data-ttu-id="85b07-155">空のプレース ホルダーがなくなっています。</span><span class="sxs-lookup"><span data-stu-id="85b07-155">No more placeholders!</span></span> <span data-ttu-id="85b07-156">快調なスタートですね。</span><span class="sxs-lookup"><span data-stu-id="85b07-156">We're off to a good start.</span></span> 

![実行中のアプリで、プレース ホルダーの代わりに実際のイメージとテキストが表示されている](../design/basics/images/xaml-basics/gallery-with-populated-templates.png)

> [!Note]
> <span data-ttu-id="85b07-158">もっと試してみたい場合は、新しい TextBlock をデータ テンプレートに追加し、x:Bind で IntelliSense を使用して、表示するプロパティを見つけてください。</span><span class="sxs-lookup"><span data-stu-id="85b07-158">If you want to experiment further, try adding a new TextBlock to the data template, and use the x:Bind IntelliSense trick to find a property to display.</span></span> 

## <a name="part-2-use-binding-to-connect-the-gallery-ui-to-the-images"></a><span data-ttu-id="85b07-159">パート 2: バインディングを使用してギャラリー UI をイメージに接続する</span><span class="sxs-lookup"><span data-stu-id="85b07-159">Part 2: Use binding to connect the gallery UI to the images</span></span>

<span data-ttu-id="85b07-160">ここでは、ページ XAML に 1 回限りのバインディングを作成してギャラリー ビューをイメージ コレクションに接続し、分離コードでこの操作を行う既存の手続き型コードを置き換えます。</span><span class="sxs-lookup"><span data-stu-id="85b07-160">Here, you'll create one-time bindings in page XAML to connect the gallery view to the image collection, replacing the existing procedural code that does this in code-behind.</span></span> <span data-ttu-id="85b07-161">また、イメージをコレクションから削除した場合にギャラリー ビューがどのように変化するかを見るために、**[Delete]** ボタンを作成します。</span><span class="sxs-lookup"><span data-stu-id="85b07-161">You'll also create a **Delete** button to see how the gallery view changes when images are removed from the collection.</span></span> <span data-ttu-id="85b07-162">同時に、従来のイベント ハンドラーより柔軟性を高めるためにイベントをイベント ハンドラーにバインドする方法についても学習します。</span><span class="sxs-lookup"><span data-stu-id="85b07-162">At the same time, you'll learn how to bind events to event handlers for more flexibility than that provided by traditional event handlers.</span></span> 

<span data-ttu-id="85b07-163">ここまでに説明したすべてのバインディングはデータ テンプレート内にあり、**x:DataType** 値で示されたクラスのプロパティを指しています。</span><span class="sxs-lookup"><span data-stu-id="85b07-163">All the bindings covered so far are inside data templates and refer to properties of the class indicated by the **x:DataType** value.</span></span> <span data-ttu-id="85b07-164">では、ページ内の残りの部分の XAML を見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="85b07-164">What about the rest of the XAML in your page?</span></span> 

<span data-ttu-id="85b07-165">データ テンプレート外の **x:Bind** 式は常にページ自体にバインドされます。</span><span class="sxs-lookup"><span data-stu-id="85b07-165">**x:Bind** expressions outside of data templates are always bound to the page itself.</span></span> <span data-ttu-id="85b07-166">つまり、配置したものは分離コードで参照することも XAML で宣言することもできます。これには、ページ内の他の UI コントロール (**x:Name** 値が必要) のプロパティやカスタム プロパティも含まれます。</span><span class="sxs-lookup"><span data-stu-id="85b07-166">This means you can reference anything you put in code-behind or declare in XAML, including custom properties and properties of other UI controls on the page (as long as they have an **x:Name** value).</span></span> 

<span data-ttu-id="85b07-167">PhotoLab サンプルでは、メインの **GridView** コントロールをイメージのコレクションに直接接続するために、(分離コード内で行う代わりに) このようなバインドが使用されています。</span><span class="sxs-lookup"><span data-stu-id="85b07-167">In the PhotoLab sample, one use for a binding like this is to connect the main **GridView** control directly to the collection of images, instead of doing it in code-behind.</span></span> <span data-ttu-id="85b07-168">後でその他の例も確認します。</span><span class="sxs-lookup"><span data-stu-id="85b07-168">Later, you'll see other examples.</span></span> 

**<span data-ttu-id="85b07-169">メイン GridView コントロールをイメージのコレクションにバインドする</span><span class="sxs-lookup"><span data-stu-id="85b07-169">Bind the main GridView control to the Images collection</span></span>**

1. <span data-ttu-id="85b07-170">MainPage.xaml.cs で、**OnNavigatedTo** メソッドを見つけ、**ItemsSource** を設定するコードを削除します。</span><span class="sxs-lookup"><span data-stu-id="85b07-170">In MainPage.xaml.cs, find the **OnNavigatedTo** method and remove the code that sets **ItemsSource**.</span></span>

    **<span data-ttu-id="85b07-171">変更前:</span><span class="sxs-lookup"><span data-stu-id="85b07-171">Before:</span></span>**
    ```c#
    ImageGridView.ItemsSource = Images;
    ```

    **<span data-ttu-id="85b07-172">変更後:</span><span class="sxs-lookup"><span data-stu-id="85b07-172">After:</span></span>**
    ```c#
    // Replaced with XAML binding:
    // ImageGridView.ItemsSource = Images;
    ```

2. <span data-ttu-id="85b07-173">MainPage.xaml で、**ImageGridView** という名前の **GridView** を探し、**ItemsSource** 属性を追加します。</span><span class="sxs-lookup"><span data-stu-id="85b07-173">In MainPage.xaml, find the **GridView** named **ImageGridView** and add an **ItemsSource** attribute.</span></span> <span data-ttu-id="85b07-174">値には、分離コードに実装されている **Images** プロパティを参照する **x:Bind** 式を使用します。</span><span class="sxs-lookup"><span data-stu-id="85b07-174">For the value, use an **x:Bind** expression that refers to the **Images** property implemented in code-behind.</span></span> 

    **<span data-ttu-id="85b07-175">変更前:</span><span class="sxs-lookup"><span data-stu-id="85b07-175">Before:</span></span>**
    ```xaml
    <GridView x:Name="ImageGridView" 
    ```

    **<span data-ttu-id="85b07-176">変更後:</span><span class="sxs-lookup"><span data-stu-id="85b07-176">After:</span></span>**
    ```xaml
    <GridView x:Name="ImageGridView" 
              ItemsSource="{x:Bind Images}" 
    ```

    <span data-ttu-id="85b07-177">**Images** プロパティの型は **ObservableCollection\<ImageFileInfo\>** であるため、**GridView** に表示される個々の項目の型は **ImageFileInfo** になります。</span><span class="sxs-lookup"><span data-stu-id="85b07-177">The **Images** property is of type **ObservableCollection\<ImageFileInfo\>**, so the individual items displayed in the **GridView** are of type **ImageFileInfo**.</span></span> <span data-ttu-id="85b07-178">これは、パート 1 で説明した **x:DataType** 値に一致します。</span><span class="sxs-lookup"><span data-stu-id="85b07-178">This matches the **x:DataType** value described in Part 1.</span></span> 

<span data-ttu-id="85b07-179">ここまでで説明したすべてのバインディングは、1 回限りの読み取り専用バインディングですが、これは単純な **x:Bind** 式の既定動作です。</span><span class="sxs-lookup"><span data-stu-id="85b07-179">All the bindings we've looked at so far are one-time, read-only bindings, which is the default behavior for plain **x:Bind** expressions.</span></span> <span data-ttu-id="85b07-180">データは初期化の際にのみ読み込まれるため、バインディングのパフォーマンスが高くなります。これは、大きなデータ セットの複雑な複数ビューのサポートに最適です。</span><span class="sxs-lookup"><span data-stu-id="85b07-180">The data is loaded only at initialization, which makes for high-performance bindings - perfect for supporting multiple, complex views of large data sets.</span></span> 

<span data-ttu-id="85b07-181">先ほど追加した **ItemsSource** というバインディングも、不変プロパティ値に対する 1 回限りの読み取り専用バインディングですが、ここには重要な相違点があります。</span><span class="sxs-lookup"><span data-stu-id="85b07-181">Even the **ItemsSource** binding you just added is a one-time, read-only binding to an unchanging property value, but there's an important distinction to make here.</span></span> <span data-ttu-id="85b07-182">**Images** プロパティの不変値は、コレクションの単一な特定インスタンスであり、ここに示されているように初期化されます。</span><span class="sxs-lookup"><span data-stu-id="85b07-182">The unchanging value of the **Images** property is a single, specific instance of a collection, initialized once as shown here.</span></span>

```Csharp
private ObservableCollection<ImageFileInfo> Images { get; }
    = new ObservableCollection<ImageFileInfo>();
```

<span data-ttu-id="85b07-183">**Images** プロパティ値は変化しませんが、プロパティの型は **ObservableCollection\<T\>** であるため、コレクションの*コンテンツ*は変化することがあります。バインディングは自動的に変更を通知し、UI を更新します。</span><span class="sxs-lookup"><span data-stu-id="85b07-183">The **Images** property value never changes, but because the property is of type **ObservableCollection\<T\>**, the *contents* of the collection can change, and the binding will automatically notice the changes and update the UI.</span></span> 

<span data-ttu-id="85b07-184">これをテストするために、現在選択されているイメージを削除するボタンを一時的に追加します。</span><span class="sxs-lookup"><span data-stu-id="85b07-184">To test this, we're going to temporarily add a button that deletes the currently-selected image.</span></span> <span data-ttu-id="85b07-185">イメージを選択すると詳細ページに移動するため、このボタンは最終バージョンではありません。</span><span class="sxs-lookup"><span data-stu-id="85b07-185">This button isn't in the final version because selecting an image will take you to a detail page.</span></span> <span data-ttu-id="85b07-186">ただし、XAML はページ コンストラクター内で (**InitializeComponent** メソッド呼び出しを介して) 初期化されるため、最終的な PhotoLab サンプルの中では、やはり **ObservableCollection\<T\>** の動作が重要になりますが、**Images** コレクションのデータは後で **OnNavigatedTo** メソッド内で設定されます。</span><span class="sxs-lookup"><span data-stu-id="85b07-186">However, the behavior of **ObservableCollection\<T\>** is still important in the final PhotoLab sample because the XAML is initialized in the page constructor (through the **InitializeComponent** method call), but the **Images** collection is populated later in the **OnNavigatedTo** method.</span></span> 

**<span data-ttu-id="85b07-187">削除ボタンを追加する</span><span class="sxs-lookup"><span data-stu-id="85b07-187">Add a delete button</span></span>**

1. <span data-ttu-id="85b07-188">MainPage.xaml で、**MainCommandBar** という名前の **CommandBar** を見つけ、新しいボタンを拡大ボタンより前に追加します。</span><span class="sxs-lookup"><span data-stu-id="85b07-188">In MainPage.xaml, find the **CommandBar** named **MainCommandBar** and add a new button before the zoom button.</span></span> <span data-ttu-id="85b07-189">(拡大コントロールは、まだ機能しません。</span><span class="sxs-lookup"><span data-stu-id="85b07-189">(The zoom controls don't work yet.</span></span> <span data-ttu-id="85b07-190">これらは、チュートリアルの次の部分で組み込みます。)</span><span class="sxs-lookup"><span data-stu-id="85b07-190">You'll hook those up in the next part of the tutorial.)</span></span>

    ```xaml
    <AppBarButton Icon="Delete"
                  Label="Delete selected image"
                  Click="{x:Bind DeleteSelectedImage}" />
    ```

    <span data-ttu-id="85b07-191">既に XAML を使い慣れていれば、**Click** 値が通常とは異なることがわかるはずです。</span><span class="sxs-lookup"><span data-stu-id="85b07-191">If you're already familiar with XAML, this **Click** value might look unusual.</span></span> <span data-ttu-id="85b07-192">以前のバージョンの XAML では、特定イベント ハンドラーのシグネチャ (多くの場合、イベント送信元を示すパラメーターやイベント固有の引数オブジェクトなど) を持つメソッドに設定する必要がありました。</span><span class="sxs-lookup"><span data-stu-id="85b07-192">In previous versions of XAML, you had to set this to a method with a specific event-handler signature, typically including parameters for the event sender and an event-specific arguments object.</span></span> <span data-ttu-id="85b07-193">この手法はイベント引数が必要な場合にも使用できますが、x:Bind では、他のメソッドにも接続できます。</span><span class="sxs-lookup"><span data-stu-id="85b07-193">You can still use this technique when you need the event arguments, but with x:Bind, you can connect to other methods, too.</span></span> <span data-ttu-id="85b07-194">たとえば、イベント データが必要でなければ、この場合のように、パラメーターを持たないメソッドに接続できます。</span><span class="sxs-lookup"><span data-stu-id="85b07-194">For example, if you don't need the event data, you can connect to methods that have no parameters, like we do here.</span></span>

    <!-- TODO add doc links about event binding - and doc links in general? -->

2. <span data-ttu-id="85b07-195">MainPage.xaml.cs に、**DeleteSelectedImage** メソッドを追加します。</span><span class="sxs-lookup"><span data-stu-id="85b07-195">In MainPage.xaml.cs, add the **DeleteSelectedImage** method.</span></span>

    ```c#
    private void DeleteSelectedImage() =>
        Images.Remove(ImageGridView.SelectedItem as ImageFileInfo);
    ```

    <span data-ttu-id="85b07-196">このメソッドは、単純に、**Images** コレクションから選択されたイメージを削除します。</span><span class="sxs-lookup"><span data-stu-id="85b07-196">This method simply deletes the selected image from the **Images** collection.</span></span> 

<span data-ttu-id="85b07-197">それではアプリを実行し、ボタンを使用して、イメージをいくつか削除しましょう。</span><span class="sxs-lookup"><span data-stu-id="85b07-197">Now run the app and use the button to delete a few images.</span></span> <span data-ttu-id="85b07-198">おわかりのように、データ バインディングと **ObservableCollection\<T\>** 型を使用しているため、UI が自動的に更新されます。</span><span class="sxs-lookup"><span data-stu-id="85b07-198">As you can see, the UI is updated automatically, thanks to data binding and the **ObservableCollection\<T\>** type.</span></span> 

> [!Note]
> <span data-ttu-id="85b07-199">チャレンジとして、選択されたイメージを一覧内で上下に移動する 2 つのボタンを追加し、これらのボタンの Click イベントを (DeleteSelectedImage のような) 2 つの新しいメソッドに x:Bind でバインドしてみてください。</span><span class="sxs-lookup"><span data-stu-id="85b07-199">For a challenge, try adding two buttons that move the selected image up or down in the list, then x:Bind their Click events to two new methods similar to DeleteSelectedImage.</span></span>
 
## <a name="part-3-set-up-the-zoom-slider"></a><span data-ttu-id="85b07-200">パート 3: ズーム スライダーをセットアップする</span><span class="sxs-lookup"><span data-stu-id="85b07-200">Part 3: Set up the zoom slider</span></span> 

<span data-ttu-id="85b07-201">このパートでは、データ テンプレート内のコントロールから、テンプレート外にあるズーム スライダーへの一方向のバインディングを作成します。</span><span class="sxs-lookup"><span data-stu-id="85b07-201">In this part, you'll create one-way bindings from a control in the data template to the zoom slider, which is outside the template.</span></span> <span data-ttu-id="85b07-202">データ バインディングを **TextBlock.Text** や **Image.Source** などの明白なもの以外に多数のコントロール プロパティと組み合わせて使用する方法についても学習します。</span><span class="sxs-lookup"><span data-stu-id="85b07-202">You'll also learn that you can use data binding with many control properties, not just the most obvious ones like **TextBlock.Text** and **Image.Source**.</span></span> 

**<span data-ttu-id="85b07-203">イメージ データ テンプレートをズーム スライダーにバインドする</span><span class="sxs-lookup"><span data-stu-id="85b07-203">Bind the image data template to the zoom slider</span></span>**

* <span data-ttu-id="85b07-204">**ImageGridView_DefaultItemTemplate** という名前の **DataTemplate** を見つけ、テンプレートの先頭にある **Grid** コントロールの **Height** 値と **Width** 値を置き換えます。</span><span class="sxs-lookup"><span data-stu-id="85b07-204">Find the **DataTemplate** named **ImageGridView_DefaultItemTemplate** and replace the **Height** and **Width** values of the **Grid** control at the top of the template.</span></span>

    **<span data-ttu-id="85b07-205">変更前</span><span class="sxs-lookup"><span data-stu-id="85b07-205">Before</span></span>**
    ```xaml
    <DataTemplate x:Key="ImageGridView_DefaultItemTemplate" 
                  x:DataType="local:ImageFileInfo">
        <Grid Height="200"
              Width="200"
              Margin="{StaticResource LargeItemMargin}">
    ```
    
    **<span data-ttu-id="85b07-206">変更後</span><span class="sxs-lookup"><span data-stu-id="85b07-206">After</span></span>**
    ```xaml
    <DataTemplate x:Key="ImageGridView_DefaultItemTemplate" 
                  x:DataType="local:ImageFileInfo">
        <Grid Height="{Binding Value, ElementName=ZoomSlider}"
              Width="{Binding Value, ElementName=ZoomSlider}"
              Margin="{StaticResource LargeItemMargin}">
    ```
    
    <!-- TODO talk about dependency properties --> 
    
    <span data-ttu-id="85b07-207">これらは **x:Bind** 式ではなく **Binding** 式であることにお気づきですか? </span><span class="sxs-lookup"><span data-stu-id="85b07-207">Did you notice that these are **Binding** expressions, and not **x:Bind** expressions?</span></span> <span data-ttu-id="85b07-208">これは、データ バインディングの従来の方法であり、現在はほとんど使用されていません。</span><span class="sxs-lookup"><span data-stu-id="85b07-208">This is the old way of doing data bindings, and it's mostly obsolete.</span></span> <span data-ttu-id="85b07-209">**x:Bind** では、**Binding** で行われるほとんどすべての処理と、それ以上のことが行われます。</span><span class="sxs-lookup"><span data-stu-id="85b07-209">**x:Bind** does nearly everything that **Binding** does, and more.</span></span> <span data-ttu-id="85b07-210">ただし、データ テンプレートで **x:Bind** を使用した場合は、**x:DataType** 値で宣言されている型にバインドされます。</span><span class="sxs-lookup"><span data-stu-id="85b07-210">However, when you use **x:Bind** in a data template, it binds to the type declared in the **x:DataType** value.</span></span> <span data-ttu-id="85b07-211">では、テンプレート内の項目をページ XAML 内または分離コード内の項目にバインドするには、どのようにすればよいでしょうか? </span><span class="sxs-lookup"><span data-stu-id="85b07-211">So how do you bind something in the template to something in the page XAML or in code-behind?</span></span> <span data-ttu-id="85b07-212">この場合は、従来のスタイルの **Binding** 式を使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="85b07-212">You must use an old-style **Binding** expression.</span></span> 
    
    <span data-ttu-id="85b07-213">**Binding** 式では **x:DataType** 値が認識されませんが、**Binding** 式には、同様の役割を果たす **ElementName** 値があります。</span><span class="sxs-lookup"><span data-stu-id="85b07-213">**Binding** expressions don't recognize the **x:DataType** value, but these **Binding** expressions have **ElementName** values that work almost the same way.</span></span> <span data-ttu-id="85b07-214">これらの値は、**Binding Value** はページ上にある指定された要素 (つまり、**x:Name** 値を持つ要素) の **Value** プロパティに対するバインディングであることをバインディング エンジンに伝えます。</span><span class="sxs-lookup"><span data-stu-id="85b07-214">These tell the binding engine that **Binding Value** is a binding to the **Value** property of the specified element on the page (that is, the element with that **x:Name** value).</span></span> <span data-ttu-id="85b07-215">分離コード内のプロパティにバインドする場合は、```{Binding MyCodeBehindProperty, ElementName=page}``` のようになります (**page** は、XAML の **Page** 要素で設定されている **x:Name** 値)。</span><span class="sxs-lookup"><span data-stu-id="85b07-215">If you want to bind to a property in code-behind, it would look something like ```{Binding MyCodeBehindProperty, ElementName=page}``` where **page** refers to the **x:Name** value set in the **Page** element in XAML.</span></span> 
    
    > [!NOTE]
    > <span data-ttu-id="85b07-216">既定では、**Binding** 式は*一方向*です。つまり、バインドされたプロパティ値が変化すると、UI が自動的に更新されます。</span><span class="sxs-lookup"><span data-stu-id="85b07-216">By default, **Binding** expressions are one-*way*, meaning that they will automatically update the UI when the bound property value changes.</span></span> 
    > 
    > <span data-ttu-id="85b07-217">これに対し、**x:Bind** は既定で *1 回限り*です。つまり、バインドされたプロパティへの変更は無視されます。</span><span class="sxs-lookup"><span data-stu-id="85b07-217">In contrast, the default for **x:Bind** is one-*time*, meaning that any changes to the bound property are ignored.</span></span> <span data-ttu-id="85b07-218">これは最もパフォーマンスの高いオプションであり、ほとんどのバインディング先は静的な読み取り専用データであるため、既定の動作として設定されています。</span><span class="sxs-lookup"><span data-stu-id="85b07-218">This is the default because it's the most high-performance option, and most bindings are to static, read-only data.</span></span> 
    >
    > <span data-ttu-id="85b07-219">値が変化するプロパティと共に **x:Bind** を使用する場合は、必ず ```Mode=OneWay``` または ```Mode=TwoWay``` を追加してください。</span><span class="sxs-lookup"><span data-stu-id="85b07-219">The lesson here is that if you use **x:Bind** with properties that can change their values, be sure to add ```Mode=OneWay``` or ```Mode=TwoWay```.</span></span> <span data-ttu-id="85b07-220">この例は、次のセクションで確認できます。</span><span class="sxs-lookup"><span data-stu-id="85b07-220">You'll see examples of this in the next section.</span></span>

<span data-ttu-id="85b07-221">アプリを実行し、スライダーを使用してイメージ テンプレートのサイズを変更します。</span><span class="sxs-lookup"><span data-stu-id="85b07-221">Run the app and use the slider to change the image-template dimensions.</span></span> <span data-ttu-id="85b07-222">ご覧のように、それほどコードを必要とせず、強力な効果を得ることができます。</span><span class="sxs-lookup"><span data-stu-id="85b07-222">As you can see, the effect is pretty powerful without needing much code.</span></span> 

![実行中のアプリにズーム スライダーが表示されている](../design/basics/images/xaml-basics/gallery-with-zoom-control.png)

> [!NOTE]
> <span data-ttu-id="85b07-224">チャレンジとして、他の UI プロパティをズーム スライダーの **Value** プロパティか、ズーム スライダーの後に追加する他のスライダーにバインドしてみてください。</span><span class="sxs-lookup"><span data-stu-id="85b07-224">For a challenge, try binding other UI properties to the zoom slider **Value** property, or to other sliders that you add after the zoom slider.</span></span> <span data-ttu-id="85b07-225">たとえば、**TitleTextBlock** の **FontSize** プロパティを新しいスライダーに、既定値の **24** でバインドすることができます。</span><span class="sxs-lookup"><span data-stu-id="85b07-225">For example, you could bind the **FontSize** property of the **TitleTextBlock** to a new slider with a default value of **24**.</span></span> <span data-ttu-id="85b07-226">適切な最小値と最大値を必ず設定してください。</span><span class="sxs-lookup"><span data-stu-id="85b07-226">Be sure to set reasonable minimum and maximum values.</span></span>

## <a name="part-4-improve-the-zoom-experience"></a><span data-ttu-id="85b07-227">手順 4: ズーム エクスペリエンスを改善する</span><span class="sxs-lookup"><span data-stu-id="85b07-227">Part 4: Improve the zoom experience</span></span> 

<span data-ttu-id="85b07-228">このパートでは、カスタムの **ItemSize** プロパティを分離コードに追加し、イメージ テンプレートから新しいプロパティへの一方向のバインディングを作成します。</span><span class="sxs-lookup"><span data-stu-id="85b07-228">In this part, you'll add a custom **ItemSize** property to code-behind and create one-way bindings from the image template to the new property.</span></span> <span data-ttu-id="85b07-229">**ItemSize** 値は、快適なエクスペリエンスのために、ズーム スライダーのほか、**[Fit to screen]** スイッチやウィンドウ サイズなどの要因によって更新されます。</span><span class="sxs-lookup"><span data-stu-id="85b07-229">The **ItemSize** value will be updated by the zoom slider and other factors such as the **Fit to screen** toggle and the window size, making for a more refined experience.</span></span> 

<span data-ttu-id="85b07-230">組み込みコントロールのプロパティとは異なり、カスタム プロパティでは、一方向または双方向のバインディングが設定されていても UI が自動更新されません。</span><span class="sxs-lookup"><span data-stu-id="85b07-230">Unlike built-in control properties, your custom properties do not automatically update the UI, even with one-way and two-way bindings.</span></span> <span data-ttu-id="85b07-231">カスタム プロパティには **1 回限り**のバインディングを設定できますが、プロパティを変更して実際の UI に反映させるには、多少の作業が必要になります。</span><span class="sxs-lookup"><span data-stu-id="85b07-231">They work fine with one-**time** bindings, but if you want your property changes to actually show up in your UI, you need to do some work.</span></span> 

**<span data-ttu-id="85b07-232">UI を更新できるように ItemSize プロパティを作成する</span><span class="sxs-lookup"><span data-stu-id="85b07-232">Create the ItemSize property so that it updates the UI</span></span>**

1. <span data-ttu-id="85b07-233">MainPage.xaml.cs で、**INotifyPropertyChanged** インターフェイスが実装されるように **MainPage** クラスのシグネチャを変更します。</span><span class="sxs-lookup"><span data-stu-id="85b07-233">In MainPage.xaml.cs, change the signature of the **MainPage** class so that it implements the **INotifyPropertyChanged** interface.</span></span>

    **<span data-ttu-id="85b07-234">変更前:</span><span class="sxs-lookup"><span data-stu-id="85b07-234">Before:</span></span>**
    ```c#
    public sealed partial class MainPage : Page
    ```

    **<span data-ttu-id="85b07-235">変更後:</span><span class="sxs-lookup"><span data-stu-id="85b07-235">After:</span></span>**
    ```c#
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    ```

    <span data-ttu-id="85b07-236">これにより、MainPage に PropertyChanged イベント (以下で追加) があり、UI を更新するためにバインディングでリッスンできることがバインディング システムに通知されます。</span><span class="sxs-lookup"><span data-stu-id="85b07-236">This informs the binding system that MainPage has a PropertyChanged event (added next) that bindings can listen for in order to update the UI.</span></span> 

2. <span data-ttu-id="85b07-237">**MainPage** クラスに **PropertyChanged** イベントを追加します。</span><span class="sxs-lookup"><span data-stu-id="85b07-237">Add a **PropertyChanged** event to the **MainPage** class.</span></span>

    ```c#
    public event PropertyChangedEventHandler PropertyChanged;
    ```

    <span data-ttu-id="85b07-238">このイベントは、**INotifyPropertyChanged** インターフェイスに必要な完全な実装を提供します。</span><span class="sxs-lookup"><span data-stu-id="85b07-238">This event provides the complete implementation required by the **INotifyPropertyChanged** interface.</span></span> <span data-ttu-id="85b07-239">ただし効力を持たせるには、カスタム プロパティでこのイベントを明示的に発生させる必要があります。</span><span class="sxs-lookup"><span data-stu-id="85b07-239">However, for it to have any effect, you must explicitly raise the event in your custom properties.</span></span> 

3. <span data-ttu-id="85b07-240">**ItemSize** プロパティを追加し、setter 内で **PropertyChanged** イベントを発生させます。</span><span class="sxs-lookup"><span data-stu-id="85b07-240">Add an **ItemSize** property and raise the **PropertyChanged** event in its setter.</span></span>

    ```c#
    public double ItemSize
    {
        get => _itemSize;
        set
        {
            if (_itemSize != value)
            {
                _itemSize = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ItemSize)));
            }
        }
    }
    private double _itemSize;
    ```

    <span data-ttu-id="85b07-241">**ItemSize** プロパティは、プライベートの **_itemSize** フィールドの値を公開します。</span><span class="sxs-lookup"><span data-stu-id="85b07-241">The **ItemSize** property exposes the value of a private **_itemSize** field.</span></span> <span data-ttu-id="85b07-242">このようなバッキング フィールドを使用すると、不要の可能性がある **PropertyChanged** イベントを発生させる前に、プロパティの新しい値が元の値と同じかどうかを確認することができます。</span><span class="sxs-lookup"><span data-stu-id="85b07-242">Using a backing field like this enables the property to check whether a new value is the same as the old value before it raises a potentially unnecessary **PropertyChanged** event.</span></span>

    <span data-ttu-id="85b07-243">イベント自体は **Invoke** メソッドによって発生します。</span><span class="sxs-lookup"><span data-stu-id="85b07-243">The event itself is raised by the **Invoke** method.</span></span> <span data-ttu-id="85b07-244">疑問符を指定すると、**PropertyChanged** イベントが null かどうか、つまり何らかのイベント ハンドラーが追加済みかどうかの確認が行われます。</span><span class="sxs-lookup"><span data-stu-id="85b07-244">The question mark checks whether the **PropertyChanged** event is null - that is, whether any event handlers have been added yet.</span></span> <span data-ttu-id="85b07-245">一方向または双方向のすべてのバインディングでは、イベント ハンドラーが自動的に追加されますが、リッスンされていなければ、それ以上何も起こりません。</span><span class="sxs-lookup"><span data-stu-id="85b07-245">Every one-way or two-way binding adds an event handler behind the scenes, but if no one is listening, nothing more would happen here.</span></span> <span data-ttu-id="85b07-246">ただし **PropertyChanged** が null でなければ、イベント ソースへの参照 (ページ自体を **this** キーワードで表す) および **event-args** オブジェクト (プロパティの名前を示す) を指定して **Invoke** が呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="85b07-246">If **PropertyChanged** isn't null, however, then **Invoke** is called with a reference to the event source (the page itself, represented by the **this** keyword) and an **event-args** object that indicates the name of the property.</span></span> <span data-ttu-id="85b07-247">変更があれば、バインドされている UI を更新できるように、この情報によって **ItemSize** プロパティに対する一方向または双方向のバインディングに通知されます。</span><span class="sxs-lookup"><span data-stu-id="85b07-247">With this info, any one-way or two-way bindings to the **ItemSize** property will be informed of any changes so they can update the bound UI.</span></span> 

4. <span data-ttu-id="85b07-248">MainPage.xaml で、**ImageGridView_DefaultItemTemplate** という名前の **DataTemplate** を見つけ、テンプレートの先頭にある **Grid** コントロールの **Height** 値と **Width** 値を置き換えます。</span><span class="sxs-lookup"><span data-stu-id="85b07-248">In MainPage.xaml, find the **DataTemplate** named **ImageGridView_DefaultItemTemplate** and replace the **Height** and **Width** values of the **Grid** control at the top of the template.</span></span> <span data-ttu-id="85b07-249">(このチュートリアルの前のパートでコントロール間のバインディングを行った場合は、**Value** を **ItemSize** に、**ZoomSlider** を **page** に置き換えるだけです。</span><span class="sxs-lookup"><span data-stu-id="85b07-249">(If you did the control-to-control binding in the previous part of this tutorial, the only changes are to replace **Value** with **ItemSize** and **ZoomSlider** with **page**.</span></span> <span data-ttu-id="85b07-250">これを Height と Width の両方に行ってください。)</span><span class="sxs-lookup"><span data-stu-id="85b07-250">Be sure to do this for both Height and Width!)</span></span>

    **<span data-ttu-id="85b07-251">変更前</span><span class="sxs-lookup"><span data-stu-id="85b07-251">Before</span></span>**
    ```xaml
    <DataTemplate x:Key="ImageGridView_DefaultItemTemplate" 
                  x:DataType="local:ImageFileInfo">
        <Grid Height="{Binding Value, ElementName=ZoomSlider}"
            Width="{Binding Value, ElementName=ZoomSlider}"
            Margin="{StaticResource LargeItemMargin}">
    ```
    
    **<span data-ttu-id="85b07-252">変更後</span><span class="sxs-lookup"><span data-stu-id="85b07-252">After</span></span>**
    ```xaml
    <DataTemplate x:Key="ImageGridView_DefaultItemTemplate" 
                  x:DataType="local:ImageFileInfo">
        <Grid Height="{Binding ItemSize, ElementName=page}"
              Width="{Binding ItemSize, ElementName=page}"
              Margin="{StaticResource LargeItemMargin}">
    ```

<span data-ttu-id="85b07-253">UI が **ItemSize** の変化に対応できるようになったため、実際に変更を行ってみましょう。</span><span class="sxs-lookup"><span data-stu-id="85b07-253">Now that the UI can respond to **ItemSize** changes, you need to actually make some changes.</span></span> <span data-ttu-id="85b07-254">前に説明したように、**ItemSize** 値はさまざまな UI コントロールの現在の状態から計算しますが、コントロールの状態が変化するたびにこの計算を実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="85b07-254">As mentioned previously, the **ItemSize** value is calculated from the current state of various UI controls, but the calculation must be performed whenever those controls change state.</span></span> <span data-ttu-id="85b07-255">これを行うには、UI の変更によっては **ItemSize** を更新するためのヘルパー メソッドが呼び出されるように、イベント バインディングを使用します。</span><span class="sxs-lookup"><span data-stu-id="85b07-255">To do this, you'll use event binding so that certain UI changes will call a helper method that updates **ItemSize**.</span></span> 

**<span data-ttu-id="85b07-256">ItemSize プロパティ値を更新する</span><span class="sxs-lookup"><span data-stu-id="85b07-256">Update the ItemSize property value</span></span>**

1. <span data-ttu-id="85b07-257">MainPage.xaml.cs に、**DetermineItemSize** メソッドを追加します。</span><span class="sxs-lookup"><span data-stu-id="85b07-257">Add the **DetermineItemSize** method to MainPage.xaml.cs.</span></span>

    ```c#
    private void DetermineItemSize()
    {
        if (FitScreenToggle != null
            && FitScreenToggle.IsOn == true
            && ImageGridView != null
            && ZoomSlider != null)
        {
            // The 'margins' value represents the total of the margins around the
            // image in the grid item. 8 from the ItemTemplate root grid + 8 from
            // the ItemContainerStyle * (Right + Left). If those values change, 
            // this value needs to be updated to match.
            int margins = (int)this.Resources["LargeItemMarginValue"] * 4;
            double gridWidth = ImageGridView.ActualWidth -
                (int)this.Resources["DesktopWindowSidePaddingValue"];
    
            if (AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Mobile" &&
                UIViewSettings.GetForCurrentView().UserInteractionMode ==
                    UserInteractionMode.Touch)
            {
                margins = (int)this.Resources["SmallItemMarginValue"] * 4;
                gridWidth = ImageGridView.ActualWidth -
                    (int)this.Resources["MobileWindowSidePaddingValue"];
            }
    
            double ItemWidth = ZoomSlider.Value + margins;
            // We need at least 1 column.
            int columns = (int)Math.Max(gridWidth / ItemWidth, 1);
    
            // Adjust the available grid width to account for margins around each item.
            double adjustedGridWidth = gridWidth - (columns * margins);
    
            ItemSize = (adjustedGridWidth / columns);
        }
        else
        {
            ItemSize = ZoomSlider.Value;
        }
    }
    ```

2. <span data-ttu-id="85b07-258">MainPage.xaml でファイルの先頭に移動し、**Page** 要素に **SizeChanged** イベント バインディングを追加します。</span><span class="sxs-lookup"><span data-stu-id="85b07-258">In MainPage.xaml, navigate to the top of the file and add a **SizeChanged** event binding to the **Page** element.</span></span>

    **<span data-ttu-id="85b07-259">変更前:</span><span class="sxs-lookup"><span data-stu-id="85b07-259">Before:</span></span>**
    ```xaml
    <Page x:Name="page"  
    ```

    **<span data-ttu-id="85b07-260">変更後:</span><span class="sxs-lookup"><span data-stu-id="85b07-260">After:</span></span>**
    ```xaml
    <Page x:Name="page" 
          SizeChanged="{x:Bind DetermineItemSize}"
    ```

3. <span data-ttu-id="85b07-261">**ZoomSlider** という名前の **Slider** を見つけ、**ValueChanged** イベント バインディングを追加します。</span><span class="sxs-lookup"><span data-stu-id="85b07-261">Find the **Slider** named **ZoomSlider** and add a **ValueChanged** event binding.</span></span>

    **<span data-ttu-id="85b07-262">変更前:</span><span class="sxs-lookup"><span data-stu-id="85b07-262">Before:</span></span>**
    ```xaml
    <Slider x:Name="ZoomSlider"
    ```

    **<span data-ttu-id="85b07-263">変更後:</span><span class="sxs-lookup"><span data-stu-id="85b07-263">After:</span></span>**
    ```xaml
    <Slider x:Name="ZoomSlider"
            ValueChanged="{x:Bind DetermineItemSize}"
    ```

4. <span data-ttu-id="85b07-264">**FitScreenToggle** という名前の **ToggleSwitch** を見つけ、**Toggled** イベント バインディングを追加します。</span><span class="sxs-lookup"><span data-stu-id="85b07-264">Find the **ToggleSwitch** named **FitScreenToggle** and add a **Toggled** event binding.</span></span>

    **<span data-ttu-id="85b07-265">変更前:</span><span class="sxs-lookup"><span data-stu-id="85b07-265">Before:</span></span>**
    ```xaml
    <ToggleSwitch x:Name="FitScreenToggle"
    ```

    **<span data-ttu-id="85b07-266">変更後:</span><span class="sxs-lookup"><span data-stu-id="85b07-266">After:</span></span>**
    ```xaml
    <ToggleSwitch x:Name="FitScreenToggle"
                  Toggled="{x:Bind DetermineItemSize}"
    ```

<span data-ttu-id="85b07-267">アプリを実行し、ズーム スライダーと **[Fit to screen]** スイッチを使用して、イメージ テンプレートのサイズを変更します。</span><span class="sxs-lookup"><span data-stu-id="85b07-267">Run the app and use the zoom slider and **Fit to screen** toggle to change the image-template dimensions.</span></span> <span data-ttu-id="85b07-268">ご覧のように、最新の変更内容では、コードを適切な構造に維持しつつ、ズーム/サイズ変更のエクスペリエンスがさらに調整されています。</span><span class="sxs-lookup"><span data-stu-id="85b07-268">As you can see, the latest changes enable a more refined zoom/resize experience while keeping the code well organized.</span></span> 

![実行中のアプリで画面に合わせるスイッチがオンになっている](../design/basics/images/xaml-basics/gallery-with-fit-to-screen.png)

> [!NOTE]
> <span data-ttu-id="85b07-270">チャレンジとして、**ZoomSlider** の後に **TextBlock** を追加し、**Text** プロパティを **ItemSize** プロパティにバインドしてみてください。</span><span class="sxs-lookup"><span data-stu-id="85b07-270">For a challenge, try adding a **TextBlock** after the **ZoomSlider** and binding the **Text** property to the **ItemSize** property.</span></span> <span data-ttu-id="85b07-271">これはデータ テンプレートではないため、前の **ItemSize** バインディングのように、**Binding** の代わりに **x:Bind** を使用できます。</span><span class="sxs-lookup"><span data-stu-id="85b07-271">Because it's not in a data template, you can use **x:Bind** instead of **Binding** like in the previous **ItemSize** bindings.</span></span>  
<span data-ttu-id="85b07-272">}</span><span class="sxs-lookup"><span data-stu-id="85b07-272">}</span></span>

## <a name="part-5-enable-user-edits"></a><span data-ttu-id="85b07-273">パート 5: ユーザー編集を有効にする</span><span class="sxs-lookup"><span data-stu-id="85b07-273">Part 5: Enable user edits</span></span>

<span data-ttu-id="85b07-274">ここでは、イメージ タイトル、評価、さまざまな視覚効果などの値をユーザーが更新できるように、双方向のバインディングを作成します。</span><span class="sxs-lookup"><span data-stu-id="85b07-274">Here, you'll create two-way bindings to enable users to update values, including the image title, rating, and various visual effects.</span></span> 

<span data-ttu-id="85b07-275">これを実現するには、単一イメージ ビューアー、ズーム コントロール、UI 編集を提供する、既存の **DetailPage** を更新します。</span><span class="sxs-lookup"><span data-stu-id="85b07-275">To achieve this, you'll update the existing **DetailPage**, which provides a single-image viewer, zoom control, and editing UI.</span></span>  

<span data-ttu-id="85b07-276">ただし、まず **DetailPage** (ギャラリー ビューでユーザーによってイメージがクリックされたときにアプリが移動する先) をアタッチする必要があります。</span><span class="sxs-lookup"><span data-stu-id="85b07-276">First, however, you need to attach the **DetailPage** so that the app navigates to it when the user clicks an image in the gallery view.</span></span>

**<span data-ttu-id="85b07-277">DetailPage をアタッチする</span><span class="sxs-lookup"><span data-stu-id="85b07-277">Attach the DetailPage</span></span>**

1. <span data-ttu-id="85b07-278">MainPage.xaml で、**ImageGridView** という名前の **GridView** を探し、**ItemClick** 値を追加します。</span><span class="sxs-lookup"><span data-stu-id="85b07-278">In MainPage.xaml, find the **GridView** named **ImageGridView** and add an **ItemClick** value.</span></span> 

    > [!TIP] 
    > <span data-ttu-id="85b07-279">コピー/貼り付けの代わりに以下の変更を入力すると、IntelliSense ポップアップに "\<New Event Handler\>" と表示されます。</span><span class="sxs-lookup"><span data-stu-id="85b07-279">If you type in the change below instead of copy/pasting, you'll see an IntelliSense pop-up that says "\<New Event Handler\>".</span></span> <span data-ttu-id="85b07-280">Tab キーを押すと、既定のメソッド ハンドラー名を使用して値が指定され、メソッドが自動的にスタブアウトされます (次の手順を参照)。</span><span class="sxs-lookup"><span data-stu-id="85b07-280">If you press the Tab key, it will fill in the value with a default method handler name, and automatically stub out the method shown in the next step.</span></span> <span data-ttu-id="85b07-281">F12 キーを押すと、分離コード内にある、このメソッドに移動できます。</span><span class="sxs-lookup"><span data-stu-id="85b07-281">You can then press F12 to navigate to the method in the code-behind.</span></span> 

    **<span data-ttu-id="85b07-282">変更前:</span><span class="sxs-lookup"><span data-stu-id="85b07-282">Before:</span></span>**
    ```xaml
    <GridView x:Name="ImageGridView"
    ```

    **<span data-ttu-id="85b07-283">変更後:</span><span class="sxs-lookup"><span data-stu-id="85b07-283">After:</span></span>**
    ```xaml
    <GridView x:Name="ImageGridView"
              ItemClick="ImageGridView_ItemClick"
    ```

    > [!NOTE] 
    > <span data-ttu-id="85b07-284">ここでは、x:Bind 式ではなく従来のイベント ハンドラーを使用します。</span><span class="sxs-lookup"><span data-stu-id="85b07-284">We're using a conventional event handler here instead of an x:Bind expression.</span></span> <span data-ttu-id="85b07-285">これは、次に示すようにイベント データを参照する必要があるためです。</span><span class="sxs-lookup"><span data-stu-id="85b07-285">This is because we need to see the event data, as shown next.</span></span> 

2. <span data-ttu-id="85b07-286">MainPage.xaml.cs で、イベント ハンドラーを追加 (前の手順のヒントを使用した場合は、指定) します。</span><span class="sxs-lookup"><span data-stu-id="85b07-286">In MainPage.xaml.cs, add the event handler (or fill it in, if you used the tip in the last step).</span></span>

    ```c#
    private void ImageGridView_ItemClick(object sender, ItemClickEventArgs e)
    {
        this.Frame.Navigate(typeof(DetailPage), e.ClickedItem);
    }
    ```

    <span data-ttu-id="85b07-287">このメソッドは、単純に詳細ページに移動するだけです。このとき、クリックされた項目 (**DetailPage.OnNavigatedTo** でページの初期化に使用された **ImageFileInfo** オブジェクト) が渡されます。</span><span class="sxs-lookup"><span data-stu-id="85b07-287">This method simply navigates to the detail page, passing in the clicked item, which is an **ImageFileInfo** object used by **DetailPage.OnNavigatedTo** for initializing the page.</span></span> <span data-ttu-id="85b07-288">このチュートリアルで、このメソッドを実装する必要はありませんが、コードで動作の内容を確認してください。</span><span class="sxs-lookup"><span data-stu-id="85b07-288">You won't have to implement that method in this tutorial, but you can take a look to see what it does.</span></span> 
    
3. <span data-ttu-id="85b07-289">(オプション) ここまでのプレイ ポイントで追加した、現在選択されているイメージと連携するコントロールを削除またはコメントアウトします。</span><span class="sxs-lookup"><span data-stu-id="85b07-289">(Optional) Delete or comment out any controls you added in previous play-points that work with the currently selected image.</span></span> <span data-ttu-id="85b07-290">これらを残しても問題はありませんが、詳細ページに移動せずにイメージを選択することがずっと困難になっています。</span><span class="sxs-lookup"><span data-stu-id="85b07-290">Keeping them around won't hurt anything, but it's now a lot harder to select an image without navigating to the detail page.</span></span> 

<span data-ttu-id="85b07-291">2 つのページを接続したので、アプリを実行して結果を確認しましょう。</span><span class="sxs-lookup"><span data-stu-id="85b07-291">Now that you've connected the two pages, run the app and take a look around.</span></span> <span data-ttu-id="85b07-292">すべて想定どおりに動作しますが、編集ペインのコントロールだけは、値を変更しようとしても応答しません。</span><span class="sxs-lookup"><span data-stu-id="85b07-292">Everything works except the controls on the editing pane, which don't respond when you try to change the values.</span></span> 

<span data-ttu-id="85b07-293">ご覧のように、タイトル テキスト ボックスではタイトルが表示され、変更を入力できます。</span><span class="sxs-lookup"><span data-stu-id="85b07-293">As you can see, the title text box does display the title and lets you type in changes.</span></span> <span data-ttu-id="85b07-294">変更をコミットするには別のコントロールにフォーカスを移動する必要がありますが、画面の左上にあるタイトルは、まだ更新されません。</span><span class="sxs-lookup"><span data-stu-id="85b07-294">You have to change focus to another control to commit the changes, but the title in the upper-left corner of the screen doesn't update yet.</span></span> 

<span data-ttu-id="85b07-295">コントロールはすべて、パート 1 で説明した単純な **x:Bind** 式を使用して既にバインドされています。</span><span class="sxs-lookup"><span data-stu-id="85b07-295">All the controls are already bound using the plain **x:Bind** expressions we covered in Part 1.</span></span> <span data-ttu-id="85b07-296">つまり、これらはすべて 1 回限りのバインディングであり、値への変更が登録されていないのはそのためです。</span><span class="sxs-lookup"><span data-stu-id="85b07-296">If you recall, this means they are all one-time bindings, which explains why changes to the values aren't registered.</span></span> <span data-ttu-id="85b07-297">これを修正するために必要な操作は、双方向のバインディングに変換することです。</span><span class="sxs-lookup"><span data-stu-id="85b07-297">To fix this, all we have to do is turn them into two-way bindings.</span></span> 

**<span data-ttu-id="85b07-298">編集コントロールを対話型に変換する</span><span class="sxs-lookup"><span data-stu-id="85b07-298">Make the editing controls interactive</span></span>**

1. <span data-ttu-id="85b07-299">DetailPage.xaml で、**TitleTextBlock** という名前の **TextBlock** と、その後の **RadRating** コントロールを見つけ、それぞれの **x:Bind** 式に **Mode=TwoWay** を追加します。</span><span class="sxs-lookup"><span data-stu-id="85b07-299">In DetailPage.xaml, find the **TextBlock** named **TitleTextBlock** and the **RadRating** control after it, and update their **x:Bind** expressions to include **Mode=TwoWay**.</span></span>

    **<span data-ttu-id="85b07-300">変更前:</span><span class="sxs-lookup"><span data-stu-id="85b07-300">Before:</span></span>**
    ```xaml
    <TextBlock x:Name="TitleTextBlock"
               Text="{x:Bind item.ImageTitle}"
               ... >
    <telerikInput:RadRating Value="{x:Bind item.ImageRating}"
                            ... >
    ```

    **<span data-ttu-id="85b07-301">変更後:</span><span class="sxs-lookup"><span data-stu-id="85b07-301">After:</span></span>**
    ```xaml
    <TextBlock x:Name="TitleTextBlock" 
               Text="{x:Bind item.ImageTitle, Mode=TwoWay}" 
               ... >
    <telerikInput:RadRating Value="{x:Bind item.ImageRating, Mode=TwoWay}" 
                            ... >
    ```

2. <span data-ttu-id="85b07-302">評価コントロールの後のすべてのエフェクト スライダーにも、同じ操作を行います。</span><span class="sxs-lookup"><span data-stu-id="85b07-302">Do the same thing for all the effect sliders that come after the rating control.</span></span>

    ```xaml
    <Slider Header="Exposure"    ... Value="{x:Bind item.Exposure, Mode=TwoWay}" ...
    <Slider Header="Temperature" ... Value="{x:Bind item.Temperature, Mode=TwoWay}" ... 
    <Slider Header="Tint"        ... Value="{x:Bind item.Tint, Mode=TwoWay}" ... 
    <Slider Header="Contrast"    ... Value="{x:Bind item.Contrast, Mode=TwoWay}" ... 
    <Slider Header="Saturation"  ... Value="{x:Bind item.Saturation, Mode=TwoWay}" ...
    <Slider Header="Blur"        ... Value="{x:Bind item.Blur, Mode=TwoWay}" ... 
    ```

<span data-ttu-id="85b07-303">双方向モードとは、その名前が示すように、いずれかの側で変更が発生するたびにデータが双方向に移動することを意味します。</span><span class="sxs-lookup"><span data-stu-id="85b07-303">The two-way mode, as you might expect, means that the data moves in both directions whenever there are changes on either side.</span></span> 

<span data-ttu-id="85b07-304">前に説明した一方向のバインディングのように、これらの双方向バインディングでも、**ImageFileInfo** クラスの **INotifyPropertyChanged** 実装により、バインドされたプロパティが変化するたびに UI が更新されるようになります。</span><span class="sxs-lookup"><span data-stu-id="85b07-304">Like the one-way bindings covered earlier, these two-way bindings will now update the UI whenever the bound properties change, thanks to the **INotifyPropertyChanged** implementation in the **ImageFileInfo** class.</span></span> <span data-ttu-id="85b07-305">ただし、双方向バインディングでは、ユーザーがコントロールを操作するたびに、UI からバインド先プロパティにも値が移動します。</span><span class="sxs-lookup"><span data-stu-id="85b07-305">With two-way binding, however, the values will also move from the UI to the bound properties whenever the user interacts with the control.</span></span> <span data-ttu-id="85b07-306">これで、XAML 側への作業は完了しました。</span><span class="sxs-lookup"><span data-stu-id="85b07-306">Nothing more is needed on the XAML side.</span></span> 

<span data-ttu-id="85b07-307">アプリを実行し、編集コントロールを試してください。</span><span class="sxs-lookup"><span data-stu-id="85b07-307">Run the app and try the editing controls.</span></span> <span data-ttu-id="85b07-308">変更を行うと、イメージの値に影響するようになっています。また、メイン ページに戻っても、これらの変更はそのままです。</span><span class="sxs-lookup"><span data-stu-id="85b07-308">As you can see, when you make a change, it now affects the image values, and those changes persist when you navigate back to the main page.</span></span> 

## <a name="part-6-format-values-through-function-binding"></a><span data-ttu-id="85b07-309">パート 6: 関数バインディングを介して値を書式化する</span><span class="sxs-lookup"><span data-stu-id="85b07-309">Part 6: Format values through function binding</span></span>

<span data-ttu-id="85b07-310">最後に問題が 1 つ残っています。</span><span class="sxs-lookup"><span data-stu-id="85b07-310">One last problem remains.</span></span> <span data-ttu-id="85b07-311">エフェクト スライダーを動かしても、横にあるラベルが変化しません。</span><span class="sxs-lookup"><span data-stu-id="85b07-311">When you move the effect sliders, the labels next to them still don't change.</span></span> 

![既定のラベル値が表示されたエフェクト スライダー](../design/basics/images/xaml-basics/effect-sliders-before-label-fix.png)

<span data-ttu-id="85b07-313">このチュートリアルの最後のパートでは、表示用にスライダーの値を書式化するバインディングを追加します。</span><span class="sxs-lookup"><span data-stu-id="85b07-313">The final part in this tutorial is to add bindings that format the slider values for display.</span></span>

**<span data-ttu-id="85b07-314">エフェクト スライダーのラベルをバインドし、表示用に値を書式化する</span><span class="sxs-lookup"><span data-stu-id="85b07-314">Bind the effect-slider labels and format the values for display</span></span>**

1. <span data-ttu-id="85b07-315">**Exposure** スライダーの後の **TextBlock** を見つけ、**Text** 値を下のバインディング式に置き換えます。</span><span class="sxs-lookup"><span data-stu-id="85b07-315">Find the **TextBlock** after the **Exposure** slider and replace the **Text** value with the binding expression shown here.</span></span>

    **<span data-ttu-id="85b07-316">変更前:</span><span class="sxs-lookup"><span data-stu-id="85b07-316">Before:</span></span>**
    ```xaml
    <Slider Header="Exposure" ... />
    <TextBlock ... Text="0.00" />
    ```

    **<span data-ttu-id="85b07-317">変更後:</span><span class="sxs-lookup"><span data-stu-id="85b07-317">After:</span></span>**
    ```xaml
    <Slider Header="Exposure" ... />
    <TextBlock ... Text="{x:Bind item.Exposure.ToString('N', culture), Mode=OneWay}" />
    ```

    <span data-ttu-id="85b07-318">これは、メソッドの戻り値へのバインドであるため、関数バインディングと呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="85b07-318">This is called a function binding because you are binding to the return value of a method.</span></span> <span data-ttu-id="85b07-319">メソッドには、ページの分離コードまたは **x:DataType** 型 (データ テンプレートの使用時) を介してアクセスできるようにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="85b07-319">The method must be accessible through the page's code-behind or the **x:DataType** type if you are in a data template.</span></span> <span data-ttu-id="85b07-320">この場合のメソッドは、.NET でよく使用される **ToString** メソッドです。ページの item プロパティでアクセスし、さらに item の **Exposure** プロパティでアクセスしています。</span><span class="sxs-lookup"><span data-stu-id="85b07-320">In this case, the method is the familiar .NET **ToString** method, which is accessed through the item property of the page, and then through the **Exposure** property of the item.</span></span> <span data-ttu-id="85b07-321">(これは、何重もの接続構造に深く入れ子状態になっているメソッドやプロパティをバインドする方法を示しています。)</span><span class="sxs-lookup"><span data-stu-id="85b07-321">(This illustrates how you can bind to methods and properties that are deeply nested in a chain of connections.)</span></span>

    <span data-ttu-id="85b07-322">関数バインディングは、他のバインディング ソースをメソッドの引数として渡すことができるため、値を表示用に書式化する場合に最も望ましい方法です。バインディング式は、これらの値の変化を一方向モードでリッスンします。</span><span class="sxs-lookup"><span data-stu-id="85b07-322">Function binding is an ideal way to format values for display because you can pass in other binding sources as method arguments, and the binding expression will listen for changes to those values as expected with the one-way mode.</span></span> <span data-ttu-id="85b07-323">この例の **culture** 引数は、分離コードに実装されている不変フィールドへの参照ですが、**PropertyChanged** イベントを発生させるプロパティにすることも簡単にできます。</span><span class="sxs-lookup"><span data-stu-id="85b07-323">In this example, the **culture** argument is a reference to an unchanging field implemented in code-behind, but it could just as easily have been a property that raises **PropertyChanged** events.</span></span> <span data-ttu-id="85b07-324">その場合は、プロパティ値に変化が発生すると、**x:Bind** 式が新しい値を使用して **ToString** を呼び出し、その結果で UI を更新します。</span><span class="sxs-lookup"><span data-stu-id="85b07-324">In that case, any changes to the property value would cause the **x:Bind** expression to call **ToString** with the new value and then update the UI with the result.</span></span> 

2. <span data-ttu-id="85b07-325">他のエフェクト スライダーにラベル付けする **TextBlocks** に対しても、同じ操作を行います。</span><span class="sxs-lookup"><span data-stu-id="85b07-325">Do the same thing for the **TextBlocks** that label the other effect sliders.</span></span>

    ```xaml
    <Slider Header="Temperature" ... />
    <TextBlock ... Text="{x:Bind item.Temperature.ToString('N', culture), Mode=OneWay}" />

    <Slider Header="Tint" ... />
    <TextBlock ... Text="{x:Bind item.Tint.ToString('N', culture), Mode=OneWay}" />

    <Slider Header="Contrast" ... />
    <TextBlock ... Text="{x:Bind item.Contrast.ToString('N', culture), Mode=OneWay}" />

    <Slider Header="Saturation" ... />
    <TextBlock ... Text="{x:Bind item.Saturation.ToString('N', culture), Mode=OneWay}" />

    <Slider Header="Blur" ... />
    <TextBlock ... Text="{x:Bind item.Blur.ToString('N', culture), Mode=OneWay}" />
    ```

<span data-ttu-id="85b07-326">これで、アプリを実行すると、スライダーのラベルを含めてすべてが正常に動作します。</span><span class="sxs-lookup"><span data-stu-id="85b07-326">Now when you run the app, everything works, including the slider labels.</span></span> 

![ラベルが機能するエフェクト スライダー](../design/basics/images/xaml-basics/effect-sliders-after-label-fix.png)

> [!NOTE]
> <span data-ttu-id="85b07-328">前のプレイ ポイントで説明した **TextBlock** に関数バインディングを使用し、**ItemSize** 値が渡されると "000 x 000" 形式の文字列を返す新しいメソッドにバインドしてみてください。</span><span class="sxs-lookup"><span data-stu-id="85b07-328">Try using function binding with the **TextBlock** from the last play-point and bind it to a new method that returns a string in "000 x 000" format when you pass it the **ItemSize** value.</span></span>


## <a name="conclusion"></a><span data-ttu-id="85b07-329">まとめ</span><span class="sxs-lookup"><span data-stu-id="85b07-329">Conclusion</span></span>

<span data-ttu-id="85b07-330">このチュートリアルでは、データ バインディングの基本を紹介し、いくつかの機能を見ていただきました。</span><span class="sxs-lookup"><span data-stu-id="85b07-330">This tutorial has given you a taste of data binding and shown you some of the functionality available.</span></span> <span data-ttu-id="85b07-331">終わる前に、1 つ注意しておきたいのは、すべてがバインド可能ではないということです。また、接続しようとする対象の値に、バインドしようとするプロパティとの互換性がない場合もあります。</span><span class="sxs-lookup"><span data-stu-id="85b07-331">One word of caution before we wrap up: not everything is bindable, and sometimes the values you try to connect to are incompatible with the properties you are trying to bind.</span></span> <span data-ttu-id="85b07-332">バインディングには高い柔軟性がありますが、あらゆる状況に対応できるわけではありません。</span><span class="sxs-lookup"><span data-stu-id="85b07-332">There is a lot of flexibility in binding, but it won't work in every situation.</span></span>

<span data-ttu-id="85b07-333">バインディングで対処できない問題の一例は、詳細ページのズーム機能と同様、コントロールをバインドできる適切なプロパティがない場合です。</span><span class="sxs-lookup"><span data-stu-id="85b07-333">One example of a problem not addressed by binding is when a control has no suitable properties to bind to, as with the detail page zoom feature.</span></span> <span data-ttu-id="85b07-334">このズーム スライダーは、イメージを表示する **ScrollViewer** と連携する必要がありますが、**ScrollViewer** を更新できるのは、自身の **ChangeView** メソッドのみです。</span><span class="sxs-lookup"><span data-stu-id="85b07-334">This zoom slider needs to interact with the **ScrollViewer** that displays the image, but **ScrollViewer** can only be updated through its **ChangeView** method.</span></span> <span data-ttu-id="85b07-335">この場合は、従来のイベント ハンドラーを使用して、**ScrollViewer** とズーム スライダーの同期を維持します。詳しくは、**DetailPage** の **ZoomSlider_ValueChanged** メソッドと **MainImageScroll_ViewChanged** メソッドを参照してください。</span><span class="sxs-lookup"><span data-stu-id="85b07-335">In this case, we use conventional event handlers to keep the **ScrollViewer** and the zoom slider in sync; see the **DetailPage** **ZoomSlider_ValueChanged** and **MainImageScroll_ViewChanged** methods for details.</span></span>

<span data-ttu-id="85b07-336">とはいえ、コードを簡素化してデータ ロジックから UI のロジックを分離するための強力で柔軟な方法として、バインディングは有用です。</span><span class="sxs-lookup"><span data-stu-id="85b07-336">Nonetheless, binding is a powerful and flexible way to simplify your code and keep your UI logic separate from your data logic.</span></span> <span data-ttu-id="85b07-337">このように分離することで、どちらの側に対しても調整が容易になり、相手側にバグが入り込むリスクを軽減できます。</span><span class="sxs-lookup"><span data-stu-id="85b07-337">This will make it much easier for you adjust either side of this divide while reducing the risk of introducing bugs on the other side.</span></span> 

<span data-ttu-id="85b07-338">**ImageFileInfo.ImageTitle** プロパティは、UI とデータを分離のしている例の 1 つです。</span><span class="sxs-lookup"><span data-stu-id="85b07-338">One example of UI and data separation is with the **ImageFileInfo.ImageTitle** property.</span></span> <span data-ttu-id="85b07-339">このプロパティ (および **ImageRating** プロパティ) は、パート 4 で作成した **ItemSize** と少し異なっており、フィールドではなくファイル メタデータ (**ImageProperties** 型によって公開) に値が格納されます。</span><span class="sxs-lookup"><span data-stu-id="85b07-339">This property (and the **ImageRating** property) is slightly different than the **ItemSize** property you created in Part 4 because the value is stored in the file metadata (exposed through the **ImageProperties** type) instead of in a field.</span></span> <span data-ttu-id="85b07-340">また、ファイルのメタデータにタイトルがない場合は、**ImageTitle** によって **ImageName** 値 (ファイル名として設定) が返されます。</span><span class="sxs-lookup"><span data-stu-id="85b07-340">Additionally, **ImageTitle** returns the **ImageName** value (set to the file name) if there is no title in the file metadata.</span></span> 

```c#
public string ImageTitle
{
    get => String.IsNullOrEmpty(ImageProperties.Title) ? ImageName : ImageProperties.Title;
    set
    {
        if (ImageProperties.Title != value)
        {
            ImageProperties.Title = value;
            var ignoreResult = ImageProperties.SavePropertiesAsync();
            OnPropertyChanged();
        }
    }
}
```

<span data-ttu-id="85b07-341">ご覧のように、setter が **ImageProperties.Title** プロパティを更新してから、新しい値をファイルに書き込むために **SavePropertiesAsync** を呼び出しています </span><span class="sxs-lookup"><span data-stu-id="85b07-341">As you can see, the setter updates the **ImageProperties.Title** property and then calls **SavePropertiesAsync** to write the new value to the file.</span></span> <span data-ttu-id="85b07-342">(これは非同期のメソッドですが、プロパティに **await** キーワードを使うことはできません。プロパティの getter と setter を直ちに完了する必要があるため、このキーワードの使用は不適切です。</span><span class="sxs-lookup"><span data-stu-id="85b07-342">(This is an async method, but we can't use the **await** keyword in a property - and you wouldn't want to because property getters and setters should complete immediately.</span></span> <span data-ttu-id="85b07-343">代わりに、メソッドを呼び出して、返される **Task** オブジェクトを無視します)。</span><span class="sxs-lookup"><span data-stu-id="85b07-343">So instead, you would call the method and ingore the **Task** object it returns.)</span></span> 

<!-- TODO more screenshots? -->

## <a name="going-further"></a><span data-ttu-id="85b07-344">追加情報</span><span class="sxs-lookup"><span data-stu-id="85b07-344">Going further</span></span>

<span data-ttu-id="85b07-345">これで、この演習は終わりです。自身で問題に取り組むために必要な、バインディングに関する知識を身につけることができました。</span><span class="sxs-lookup"><span data-stu-id="85b07-345">Now that you've completed this lab, you have enough binding knowledge tackle a problem on your own.</span></span>

<span data-ttu-id="85b07-346">お気付きのように、詳細ページでズーム レベルを変更しても、前に戻って同じイメージをもう一度選択すると、ズーム レベルが自動的にリセットされます。</span><span class="sxs-lookup"><span data-stu-id="85b07-346">As you might have noticed, if you change the zoom level on the details page, it resets automatically when you navigate backward then select the same image again.</span></span> <span data-ttu-id="85b07-347">各イメージのズーム レベルを保存して個別に復元する方法はわかりますか? </span><span class="sxs-lookup"><span data-stu-id="85b07-347">Can you figure out how to preserve and restore the zoom level for each image individually?</span></span> <span data-ttu-id="85b07-348">幸運をお祈りします!</span><span class="sxs-lookup"><span data-stu-id="85b07-348">Good luck!</span></span>
    
<span data-ttu-id="85b07-349">必要な情報はすべてこのチュートリアルにありますが、さらにガイダンスが必要な場合は、データ バインディングに関するドキュメントをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="85b07-349">You should have all the info you need in this tutorial, but if you need more guidance, the data binding docs are only a click away.</span></span> <span data-ttu-id="85b07-350">以下のリンクから参照できます。</span><span class="sxs-lookup"><span data-stu-id="85b07-350">Start here:</span></span>

+ [<span data-ttu-id="85b07-351">{x:Bind} マークアップ拡張</span><span class="sxs-lookup"><span data-stu-id="85b07-351">{x:Bind} markup extension</span></span>](https://docs.microsoft.com/windows/uwp/xaml-platform/x-bind-markup-extension)
+ [<span data-ttu-id="85b07-352">データ バインディングの詳細</span><span class="sxs-lookup"><span data-stu-id="85b07-352">Data binding in depth</span></span>](https://docs.microsoft.com/windows/uwp/data-binding/data-binding-in-depth)