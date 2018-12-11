---
title: アダプティブ レイアウトの作成のチュートリアル
description: この記事では、XAML のアダプティブ レイアウトの基本について説明します。
keywords: XAML、UWP、概要
ms.date: 08/30/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 7b444a11ab032034976d2f1b269bd10a89bf339e
ms.sourcegitcommit: 8921a9cc0dd3e5665345ae8eca7ab7aeb83ccc6f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/10/2018
ms.locfileid: "8878057"
---
# <a name="tutorial-create-adaptive-layouts"></a><span data-ttu-id="0737f-104">チュートリアル: アダプティブ レイアウトの作成</span><span class="sxs-lookup"><span data-stu-id="0737f-104">Tutorial: Create adaptive layouts</span></span>

<span data-ttu-id="0737f-105">このチュートリアルでは、XAML のアダプティブなカスタム レイアウト機能の基本的な使い方について説明します。このレイアウト機能を使用すると、どのようなデバイスでもそのデバイス用に最適化されたアプリを作成できます。</span><span class="sxs-lookup"><span data-stu-id="0737f-105">This tutorial covers the basics of using XAML's adaptive and tailored layout features, which let you create apps that look at home on any device.</span></span> <span data-ttu-id="0737f-106">新しい DataTemplate を作成する方法、ウィンドウ スナップ位置を追加する方法、VisualStateManager 要素および AdaptiveTrigger 要素を使用してアプリのレイアウトをカスタマイズする方法を学習します。</span><span class="sxs-lookup"><span data-stu-id="0737f-106">You'll learn how to create a new DataTemplate, add window snap points, and tailor your app's layout using the VisualStateManager and AdaptiveTrigger elements.</span></span> <span data-ttu-id="0737f-107">ここでは、これらのツールを使用して、より小さなデバイス画面向けにイメージ編集プログラムを最適化します。</span><span class="sxs-lookup"><span data-stu-id="0737f-107">We'll use these tools to optimize an image editing program for smaller device screens.</span></span> 

<span data-ttu-id="0737f-108">作業するイメージ編集プログラムには、次の 2 つのページ/画面があります。</span><span class="sxs-lookup"><span data-stu-id="0737f-108">The image editing program you'll be working on has two pages/screens:</span></span>

<span data-ttu-id="0737f-109">**メイン ページ:** フォト ギャラリー ビューが各イメージ ファイルに関する情報と共に表示されます。</span><span class="sxs-lookup"><span data-stu-id="0737f-109">The **main page**, which displays a photo gallery view, along with some information about each image file.</span></span>

![MainPage](../basics/images/xaml-basics/mainpage.png)

<span data-ttu-id="0737f-111">**詳細ページ:** 選択された単一の写真が表示されます。</span><span class="sxs-lookup"><span data-stu-id="0737f-111">The **details page**, which displays a single photo after it has been selected.</span></span> <span data-ttu-id="0737f-112">ポップアップの編集メニューにより、写真の編集、名前変更、保存を行うことができます。</span><span class="sxs-lookup"><span data-stu-id="0737f-112">A flyout editing menu allows the photo to be altered, renamed, and saved.</span></span>

![DetailPage](../basics/images/xaml-basics/detailpage.png)

## <a name="prerequisites"></a><span data-ttu-id="0737f-114">前提条件</span><span class="sxs-lookup"><span data-stu-id="0737f-114">Prerequisites</span></span>

* <span data-ttu-id="0737f-115">Visual Studio 2017: [Visual Studio 2017 Community (無料) のダウンロード](https://www.visualstudio.com/thank-you-downloading-visual-studio/?sku=Community&rel=15&campaign=WinDevCenter&ocid=wdgcx-windevcenter-community-download)</span><span class="sxs-lookup"><span data-stu-id="0737f-115">Visual Studio 2017: [Download Visual Studio 2017 Community (free)](https://www.visualstudio.com/thank-you-downloading-visual-studio/?sku=Community&rel=15&campaign=WinDevCenter&ocid=wdgcx-windevcenter-community-download)</span></span> 
* <span data-ttu-id="0737f-116">Windows 10 SDK (10.0.15063.468 以降): [最新の Windows SDK (無料) のダウンロード](https://developer.microsoft.com/windows/downloads/windows-10-sdk)</span><span class="sxs-lookup"><span data-stu-id="0737f-116">Windows 10 SDK (10.0.15063.468 or later):  [Download the latest Windows SDK (free)](https://developer.microsoft.com/windows/downloads/windows-10-sdk)</span></span>
* <span data-ttu-id="0737f-117">Windows Mobile エミュレーター: [Windows 10 Mobile エミュレーター (無料) のダウンロード](https://developer.microsoft.com/en-us/windows/downloads/sdk-archive)</span><span class="sxs-lookup"><span data-stu-id="0737f-117">Windows mobile emulator: [Download the Windows 10 mobile emulator (free)](https://developer.microsoft.com/en-us/windows/downloads/sdk-archive)</span></span>

## <a name="part-0-get-the-starter-code-from-github"></a><span data-ttu-id="0737f-118">パート 0: github からスタート コードを入手する</span><span class="sxs-lookup"><span data-stu-id="0737f-118">Part 0: Get the starter code from github</span></span>

<span data-ttu-id="0737f-119">このチュートリアルでは、PhotoLab サンプルの簡易バージョンから開始します。</span><span class="sxs-lookup"><span data-stu-id="0737f-119">For this tutorial, you'll start with a simplified version of the PhotoLab sample.</span></span> 

1. <span data-ttu-id="0737f-120">移動[https://github.com/Microsoft/Windows-appsample-photo-lab](https://github.com/Microsoft/Windows-appsample-photo-lab)します。</span><span class="sxs-lookup"><span data-stu-id="0737f-120">Go to [https://github.com/Microsoft/Windows-appsample-photo-lab](https://github.com/Microsoft/Windows-appsample-photo-lab).</span></span> <span data-ttu-id="0737f-121">これで、サンプルの GitHub ページが表示されます。</span><span class="sxs-lookup"><span data-stu-id="0737f-121">This takes you to the GitHub page for the sample.</span></span> 
2. <span data-ttu-id="0737f-122">次に、サンプルを複製またはダウンロードする必要があります。</span><span class="sxs-lookup"><span data-stu-id="0737f-122">Next, you'll need to clone or download the sample.</span></span> <span data-ttu-id="0737f-123">**[Clone or download]** (複製またはダウンロード) ボタンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="0737f-123">Click the **Clone or download** button.</span></span> <span data-ttu-id="0737f-124">サブメニューが表示されます。</span><span class="sxs-lookup"><span data-stu-id="0737f-124">A sub-menu appears.</span></span>
    <figure>
        <img src="../basics/images/xaml-basics/clone-repo.png" alt="The Clone or download menu on GitHub">
        <figcaption><span data-ttu-id="0737f-125">PhotoLab サンプルの GitHub ページの <b>[Clone or download]</b> (複製またはダウンロード) メニュー。</span><span class="sxs-lookup"><span data-stu-id="0737f-125">The <b>Clone or download</b> menu on the Photo lab sample's GitHub page.</span></span></figcaption>
    </figure>

    **<span data-ttu-id="0737f-126">GitHub に慣れていない場合:</span><span class="sxs-lookup"><span data-stu-id="0737f-126">If you're not familiar with GitHub:</span></span>**
    
    <span data-ttu-id="0737f-127">a. </span><span class="sxs-lookup"><span data-stu-id="0737f-127">a.</span></span> <span data-ttu-id="0737f-128">**[Download ZIP]** (ZIP をダウンロード) をクリックし、ファイルをローカルに保存します。</span><span class="sxs-lookup"><span data-stu-id="0737f-128">Click **Download ZIP** and save the file locally.</span></span> <span data-ttu-id="0737f-129">これで、必要なすべてのプロジェクト ファイルを含む .zip ファイルがダウンロードされます。</span><span class="sxs-lookup"><span data-stu-id="0737f-129">This downloads a .zip file that contains all the project files you need.</span></span>
    <span data-ttu-id="0737f-130">b. </span><span class="sxs-lookup"><span data-stu-id="0737f-130">b.</span></span> <span data-ttu-id="0737f-131">ファイルを展開します。</span><span class="sxs-lookup"><span data-stu-id="0737f-131">Extract the file.</span></span> <span data-ttu-id="0737f-132">エクスプローラーを使用して、ダウンロードした .zip ファイルに移動し、ファイルを右クリックして **[すべて展開]** を選択します。c.</span><span class="sxs-lookup"><span data-stu-id="0737f-132">Use the File Explorer to navigate to the .zip file you just downloaded, right-click it, and select **Extract All...**. c.</span></span> <span data-ttu-id="0737f-133">サンプルのローカル コピーに移動し、`Windows-appsample-photo-lab-master\xaml-basics-starting-points\adaptive-layout` ディレクトリに移動します。</span><span class="sxs-lookup"><span data-stu-id="0737f-133">Navigate to your local copy of the sample and go the `Windows-appsample-photo-lab-master\xaml-basics-starting-points\adaptive-layout` directory.</span></span>    

    **<span data-ttu-id="0737f-134">GitHub に慣れている場合:</span><span class="sxs-lookup"><span data-stu-id="0737f-134">If you are familiar with GitHub:</span></span>**

    <span data-ttu-id="0737f-135">a. </span><span class="sxs-lookup"><span data-stu-id="0737f-135">a.</span></span> <span data-ttu-id="0737f-136">リポジトリのマスター ブランチをローカルに複製します。</span><span class="sxs-lookup"><span data-stu-id="0737f-136">Clone the master branch of the repo locally.</span></span>
    <span data-ttu-id="0737f-137">b. </span><span class="sxs-lookup"><span data-stu-id="0737f-137">b.</span></span> <span data-ttu-id="0737f-138">`Windows-appsample-photo-lab\xaml-basics-starting-points\adaptive-layout` ディレクトリに移動します。</span><span class="sxs-lookup"><span data-stu-id="0737f-138">Navigate to the `Windows-appsample-photo-lab\xaml-basics-starting-points\adaptive-layout` directory.</span></span>

3. <span data-ttu-id="0737f-139">`Photolab.sln` をクリックしてプロジェクトを開きます。</span><span class="sxs-lookup"><span data-stu-id="0737f-139">Open the project by clicking `Photolab.sln`.</span></span>

## <a name="part-1-run-the-mobile-emulator"></a><span data-ttu-id="0737f-140">手順 1: モバイル エミュレーターを実行する</span><span class="sxs-lookup"><span data-stu-id="0737f-140">Part 1: Run the mobile emulator</span></span>

<span data-ttu-id="0737f-141">Visual Studio ツールバーで、ソリューション プラットフォームを必ず x86 または x64 (ARM は不可) に設定してから、ターゲット デバイスをローカル コンピューターから変更して、インストール済みのいずれかのモバイル エミュレーター (Mobile Emulator 10.0.15063 WVGA 5 inch 1GB など) に設定します。</span><span class="sxs-lookup"><span data-stu-id="0737f-141">In the Visual Studio toolbar, make sure your Solution Platform is set to x86 or x64, not ARM, and then change your target device from Local Machine to one of the mobile emulators that you've installed (for example, Mobile Emulator 10.0.15063 WVGA 5 inch 1GB).</span></span> <span data-ttu-id="0737f-142">**F5** を押して、選択したモバイル エミュレーターで Photo Gallery アプリを実行します。</span><span class="sxs-lookup"><span data-stu-id="0737f-142">Try running the Photo Gallery app in the mobile emulator you've selected by pressing **F5**.</span></span>

<span data-ttu-id="0737f-143">アプリが開始すると、動作しているものの、このように小さなビューポートでは見栄えが良くないことに気付きます。</span><span class="sxs-lookup"><span data-stu-id="0737f-143">As soon as the app starts, you'll probably notice that while the app works, it doesn't look great on such a small viewport.</span></span> <span data-ttu-id="0737f-144">限られた画面領域への対応として、可変の Grid 要素により表示する列の数が減っていますが、レイアウトはこのように小さなビューポートに適合せず、見づらい状態です。</span><span class="sxs-lookup"><span data-stu-id="0737f-144">The fluid Grid element tries to accommodate for the limited screen real estate by reducing the number of columns displayed, but we are left with a layout that looks uninspired and ill-fitted to such a small viewport.</span></span>

![モバイル レイアウト: 変更後](../basics/images/xaml-basics/adaptive-layout-mobile-before.png)

## <a name="part-2-build-a-tailored-mobile-layout"></a><span data-ttu-id="0737f-146">パート 2: カスタムのモバイル レイアウトを作成する</span><span class="sxs-lookup"><span data-stu-id="0737f-146">Part 2: Build a tailored mobile layout</span></span>
<span data-ttu-id="0737f-147">より小さなデバイスでもこのアプリの見栄えを良くするには、モバイル デバイスが検出された場合にのみ使用される、別のスタイルを XAML ページに作成します。</span><span class="sxs-lookup"><span data-stu-id="0737f-147">To make this app look good on smaller devices, we're going to create a separate set of styles in our XAML page that will only be used if a mobile device is detected.</span></span>

### <a name="create-a-new-datatemplate"></a><span data-ttu-id="0737f-148">新しい DataTemplate を作成する</span><span class="sxs-lookup"><span data-stu-id="0737f-148">Create a new DataTemplate</span></span>
<span data-ttu-id="0737f-149">イメージの新しい DataTemplate を作成することで、アプリケーションのギャラリー ビューをカスタマイズしましょう。</span><span class="sxs-lookup"><span data-stu-id="0737f-149">We're going to tailor the gallery view of the application by creating a new DataTemplate for the images.</span></span> <span data-ttu-id="0737f-150">ソリューション エクスプ ローラーから MainPage.xaml を開き、**Page.Resources** タグ内に次のコードを追加します。</span><span class="sxs-lookup"><span data-stu-id="0737f-150">Open MainPage.xaml from the Solution Explorer, and add the following code within the **Page.Resources** tags.</span></span>

```XAML
<DataTemplate x:Key="ImageGridView_MobileItemTemplate"
              x:DataType="local:ImageFileInfo">

    <!-- Create image grid -->
    <Grid Height="{Binding ItemSize, ElementName=page}"
          Width="{Binding ItemSize, ElementName=page}">
        
        <!-- Place image in grid, stretching it to fill the pane-->
        <Image x:Name="ItemImage"
               Source="{x:Bind ImagePreview}"
               Stretch="UniformToFill">
        </Image>

    </Grid>
</DataTemplate>
```

<span data-ttu-id="0737f-151">このギャラリー テンプレートでは、イメージの境界線を排除し、各サムネイルの下にあるイメージのメタデータ (ファイル名、評価など) を非表示にすることによって、画面領域を節約しています。</span><span class="sxs-lookup"><span data-stu-id="0737f-151">This gallery template saves screen real estate by eliminating the border around images, and getting rid of the image metadata (filename, ratings, and so on.) below each thumbnail.</span></span> <span data-ttu-id="0737f-152">代わりに、各サムネイルは単純な正方形で表示します。</span><span class="sxs-lookup"><span data-stu-id="0737f-152">Instead, we show each thumbnail as a simple square.</span></span>

### <a name="add-metadata-to-a-tooltip"></a><span data-ttu-id="0737f-153">メタデータをヒントを追加する</span><span class="sxs-lookup"><span data-stu-id="0737f-153">Add metadata to a tooltip</span></span>
<span data-ttu-id="0737f-154">ユーザーが各イメージのメタデータにアクセスできるように、各イメージ項目にヒントを追加します。</span><span class="sxs-lookup"><span data-stu-id="0737f-154">We still want the user to be able to access the metadata for each image, so we'll add a tooltip to each image item.</span></span> <span data-ttu-id="0737f-155">先ほど作成した DataTemplate の **Image** タグ内に、次のコードを追加します。</span><span class="sxs-lookup"><span data-stu-id="0737f-155">Add the following code within the **Image** tags of the DataTemplate you just created.</span></span>

```XAML
<Image ...>

    <!-- Add a tooltip to the image that displays metadata -->
    <ToolTipService.ToolTip>
        <ToolTip x:Name="tooltip">

            <!-- Arrange tooltip elements vertically -->
            <StackPanel Orientation="Vertical"
                        Grid.Row="1">

                <!-- Image title -->
                <TextBlock Text="{x:Bind ImageTitle, Mode=OneWay}"
                           HorizontalAlignment="Center"
                           Style="{StaticResource SubtitleTextBlockStyle}" />

                <!-- Arrange elements horizontally -->
                <StackPanel Orientation="Horizontal"
                            HorizontalAlignment="Center">

                    <!-- Image file type -->
                    <TextBlock Text="{x:Bind ImageFileType}"
                               HorizontalAlignment="Center"
                               Style="{StaticResource CaptionTextBlockStyle}" />

                    <!-- Image dimensions -->
                    <TextBlock Text="{x:Bind ImageDimensions}"
                               HorizontalAlignment="Center"
                               Style="{StaticResource CaptionTextBlockStyle}"
                               Margin="8,0,0,0" />
                </StackPanel>
            </StackPanel>
        </ToolTip>
    </ToolTipService.ToolTip>
</Image>
```

<span data-ttu-id="0737f-156">これにより、サムネイルにマウスを重ねると (または、タッチ スクリーンを長押しすると)、イメージのタイトル、ファイルの種類、サイズが表示されるようになります。</span><span class="sxs-lookup"><span data-stu-id="0737f-156">This will show the title, file type, and dimensions of an image when you hover the mouse over the thumbnail (or press and hold on a touch screen).</span></span>

### <a name="add-a-visualstatemanager-and-statetrigger"></a><span data-ttu-id="0737f-157">VisualStateManager と StateTrigger を追加する</span><span class="sxs-lookup"><span data-stu-id="0737f-157">Add a VisualStateManager and StateTrigger</span></span>

<span data-ttu-id="0737f-158">これで、新しいデータ レイアウトが作成されましたが、今のところ、どのようなときに既定のスタイルではなくこのレイアウトを使うのか、アプリに知らせる方法がありません。</span><span class="sxs-lookup"><span data-stu-id="0737f-158">We've now created a new layout for our data, but the app currently has no way of knowing when to use this layout over the default styles.</span></span> <span data-ttu-id="0737f-159">これを解決するには、**VisualStateManager** を追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0737f-159">To fix this, we'll need to add a **VisualStateManager**.</span></span> <span data-ttu-id="0737f-160">ページのルート要素である **RelativePanel** に次のコードを追加します。</span><span class="sxs-lookup"><span data-stu-id="0737f-160">Add the following code to the root element of the page, **RelativePanel**.</span></span>

```XAML
<VisualStateManager.VisualStateGroups>
    <VisualStateGroup>

        <!-- Add a new VisualState for mobile devices -->
        <VisualState x:Key="Mobile">

            <!-- Trigger visualstate when a mobile device is detected -->
            <VisualState.StateTriggers>
                <local:MobileScreenTrigger InteractionMode="Touch" />
            </VisualState.StateTriggers>

        </VisualState>
    </VisualStateGroup>
</VisualStateManager.VisualStateGroups>
```

<span data-ttu-id="0737f-161">これにより、新しい **VisualState** および **StateTrigger** が追加されます。これらは、アプリがモバイル デバイス上で実行中であると検出されるとトリガーされます (この動作のロジックは、PhotoLab ディレクトリにある MobileScreenTrigger.cs で確認できます)。</span><span class="sxs-lookup"><span data-stu-id="0737f-161">This adds a new **VisualState** and **StateTrigger**, which will be triggered when the app detects that it is running on a mobile device (the logic for this operation can be found in MobileScreenTrigger.cs, which is provided for you in the PhotoLab directory).</span></span> <span data-ttu-id="0737f-162">**StateTrigger** が起動されると、アプリは、この **VisualState** に割り当てられているレイアウト属性を使用します。</span><span class="sxs-lookup"><span data-stu-id="0737f-162">When the **StateTrigger** starts, the app will use whatever layout attributes are assigned to this **VisualState**.</span></span>

### <a name="add-visualstate-setters"></a><span data-ttu-id="0737f-163">VisualState の setter を追加する</span><span class="sxs-lookup"><span data-stu-id="0737f-163">Add VisualState setters</span></span>
<span data-ttu-id="0737f-164">次に、**VisualState** の setter を使用して、状態がトリガーされたときに適用する属性を **VisualStateManager** に伝えます。</span><span class="sxs-lookup"><span data-stu-id="0737f-164">Next, we'll use **VisualState** setters to tell the **VisualStateManager** what attributes to apply when the state is triggered.</span></span> <span data-ttu-id="0737f-165">各 setter は、特定の XAML 要素の 1 つのプロパティを対象とし、指定された値に設定します。</span><span class="sxs-lookup"><span data-stu-id="0737f-165">Each setter targets one property of a particular XAML element and sets it to the given value.</span></span> <span data-ttu-id="0737f-166">先ほど作成したモバイルの **VisualState** (**VisualState.StateTriggers** 要素の下) にこのコードを追加します。 </span><span class="sxs-lookup"><span data-stu-id="0737f-166">Add this code to the mobile **VisualState** you just created, below the **VisualState.StateTriggers** element.</span></span> 

```XAML
<VisualStateManager.VisualStateGroups>
    <VisualStateGroup>

        <VisualState x:Key="Mobile">
            ...

            <!-- Add setters for mobile visualstate -->
            <VisualState.Setters>

                <!-- Move GridView about the command bar -->
                <Setter Target="ImageGridView.(RelativePanel.Above)"
                        Value="MainCommandBar" />

                <!-- Switch to mobile layout -->
                <Setter Target="ImageGridView.ItemTemplate"
                        Value="{StaticResource ImageGridView_MobileItemTemplate}" />

                <!-- Switch to mobile container styles -->
                <Setter Target="ImageGridView.ItemContainerStyle"
                        Value="{StaticResource ImageGridView_MobileItemContainerStyle}" />

                <!-- Move command bar to bottom of the screen -->
                <Setter Target="MainCommandBar.(RelativePanel.AlignBottomWithPanel)"
                        Value="True" />
                <Setter Target="MainCommandBar.(RelativePanel.AlignLeftWithPanel)"
                        Value="True" />
                <Setter Target="MainCommandBar.(RelativePanel.AlignRightWithPanel)"
                        Value="True" />

                <!-- Adjust the zoom slider to fit mobile screens -->
                <Setter Target="ZoomSlider.Minimum"
                        Value="80" />
                <Setter Target="ZoomSlider.Maximum"
                        Value="180" />
                <Setter Target="ZoomSlider.TickFrequency"
                        Value="20" />
                <Setter Target="ZoomSlider.Value"
                        Value="100" />
            </VisualState.Setters>

        </VisualState>
    </VisualStateGroup>
</VisualStateManager.VisualStateGroups>

```

<span data-ttu-id="0737f-167">これらの setter は、イメージ ギャラリーの **ItemTemplate** を、先ほど作成した新しい **DataTemplate** に設定します。さらに、携帯電話の画面で親指によってアクセスしやすくなるように、コマンド バーとズーム スライダーを画面の下端に揃えます。</span><span class="sxs-lookup"><span data-stu-id="0737f-167">These setters set the **ItemTemplate** of the image gallery to the new **DataTemplate** that we created in the first part, and align the command bar and zoom slider with the bottom of the screen, so they are easier to reach with your thumb on a mobile phone screen.</span></span>

### <a name="run-the-app"></a><span data-ttu-id="0737f-168">アプリを実行する</span><span class="sxs-lookup"><span data-stu-id="0737f-168">Run the app</span></span>
<span data-ttu-id="0737f-169">では、モバイル エミュレーターを使用してアプリを実行してみましょう。</span><span class="sxs-lookup"><span data-stu-id="0737f-169">Now try running the app using a mobile emulator.</span></span> <span data-ttu-id="0737f-170">新しいレイアウトは正しく表示されますか? </span><span class="sxs-lookup"><span data-stu-id="0737f-170">Does the new layout display successfully?</span></span> <span data-ttu-id="0737f-171">次のように、グリッド状に並んだ小さなサムネイルが表示されるはずです。</span><span class="sxs-lookup"><span data-stu-id="0737f-171">You should see a grid of small thumbnails as below.</span></span> <span data-ttu-id="0737f-172">まだ以前のレイアウトが表示される場合は、**VisualStateManager** コードにスペルの間違いがないか確認してください。</span><span class="sxs-lookup"><span data-stu-id="0737f-172">If you still see the old layout, there may be a typo in your **VisualStateManager** code.</span></span>

![モバイル レイアウト: 変更後](../basics/images/xaml-basics/adaptive-layout-mobile-after.png)

## <a name="part-3-adapt-to-multiple-window-sizes-on-a-single-device"></a><span data-ttu-id="0737f-174">パート 3: 単一デバイスのさまざまなウィンドウ サイズに対応する</span><span class="sxs-lookup"><span data-stu-id="0737f-174">Part 3: Adapt to multiple window sizes on a single device</span></span>
<span data-ttu-id="0737f-175">新しいカスタム レイアウトを作成すると、モバイル デバイスのレスポンシブ デザインに関する問題が解決しますが、デスクトップとタブレットの場合はどうでしょうか? </span><span class="sxs-lookup"><span data-stu-id="0737f-175">Creating a new tailored layout solves the challenge of responsive design for mobile devices, but what about desktops and tablets?</span></span> <span data-ttu-id="0737f-176">アプリは、全画面では見栄え良く表示されても、ユーザーがウィンドウ サイズを縮小すると、インターフェイスが使いづらくなることがあります。</span><span class="sxs-lookup"><span data-stu-id="0737f-176">The app may look good at full screen, but if the user shrinks the window, they may end up with an awkward interface.</span></span> <span data-ttu-id="0737f-177">エンド ユーザーが常に適切な外観および操作性を得ることができるように、**VisualStateManager** を使用して、単一デバイスのさまざまなウィンドウサイズに対応することができます。</span><span class="sxs-lookup"><span data-stu-id="0737f-177">We can ensure that the end-user experience always looks and feels right by using the **VisualStateManager** to adapt to multiple window sizes on a single device.</span></span>

![小さなウィンドウ: 変更前](../basics/images/xaml-basics/adaptive-layout-small-before.png)

### <a name="add-window-snap-points"></a><span data-ttu-id="0737f-179">ウィンドウ スナップ位置を追加する</span><span class="sxs-lookup"><span data-stu-id="0737f-179">Add window snap points</span></span>
<span data-ttu-id="0737f-180">最初のステップは、さまざまな **VisualStates** がトリガーされる "スナップ位置" を定義することです。</span><span class="sxs-lookup"><span data-stu-id="0737f-180">The first step is to define the "snap points" at which different **VisualStates** will be triggered.</span></span> <span data-ttu-id="0737f-181">ソリューション エクスプ ローラーから App.xaml を開き、2 つの **Application** タグの間に次のコードを追加します。</span><span class="sxs-lookup"><span data-stu-id="0737f-181">Open App.xaml from the Solution Explorer, and add the following code between the **Application** tags.</span></span>

```XAML
<Application.Resources>
    <!--  window width adaptive snap points  -->
    <x:Double x:Key="MinWindowSnapPoint">0</x:Double>
    <x:Double x:Key="MediumWindowSnapPoint">641</x:Double>
    <x:Double x:Key="LargeWindowSnapPoint">1008</x:Double>
</Application.Resources>
```

<span data-ttu-id="0737f-182">これにより 3 つのスナップ位置が追加され、3 種類のウィンドウ サイズ範囲に対する新しい **VisualStates** を作成できます。</span><span class="sxs-lookup"><span data-stu-id="0737f-182">This gives us three snap points, which allow us to create new **VisualStates** for three ranges of window sizes:</span></span>
+ <span data-ttu-id="0737f-183">小 (0 ～ 640 ピクセル幅)</span><span class="sxs-lookup"><span data-stu-id="0737f-183">Small (0 - 640 pixels wide)</span></span>
+ <span data-ttu-id="0737f-184">中 (641 ～ 1007 ピクセル幅)</span><span class="sxs-lookup"><span data-stu-id="0737f-184">Medium (641 - 1007 pixels wide)</span></span>
+ <span data-ttu-id="0737f-185">大 (1008 ピクセル幅以上)</span><span class="sxs-lookup"><span data-stu-id="0737f-185">Large (> 1007 pixels wide)</span></span>

### <a name="create-new-visualstates-and-statetriggers"></a><span data-ttu-id="0737f-186">新しい VisualStates と StateTriggers を作成する</span><span class="sxs-lookup"><span data-stu-id="0737f-186">Create new VisualStates and StateTriggers</span></span>
<span data-ttu-id="0737f-187">次に、各スナップ位置に対応する **VisualStates** および **StateTriggers** を作成します。</span><span class="sxs-lookup"><span data-stu-id="0737f-187">Next, we create the **VisualStates** and **StateTriggers** that correspond to each snap point.</span></span> <span data-ttu-id="0737f-188">MainPage.xaml.cpp の **VisualStateManager** (パート 2 で作成) に次のコードを追加します。</span><span class="sxs-lookup"><span data-stu-id="0737f-188">In MainPage.xaml, add the following code to the **VisualStateManager** that you created in Part 2.</span></span>

```XAML
<VisualStateManager.VisualStateGroups>
    <VisualStateGroup>
    ...

        <!-- Large window VisualState -->
        <VisualState x:Key="LargeWindow">

            <!-- Large window trigger -->
            <VisualState.StateTriggers>
                <AdaptiveTrigger MinWindowWidth="{StaticResource LargeWindowSnapPoint}"/>
            </VisualState.StateTriggers>
     
        </VisualState>

        <!-- Medium window VisualState -->
        <VisualState x:Key="MediumWindow">

            <!-- Medium window trigger -->
            <VisualState.StateTriggers>
                <AdaptiveTrigger MinWindowWidth="{StaticResource MediumWindowSnapPoint}"/>
            </VisualState.StateTriggers>
        
        </VisualState>

        <!-- Small window VisualState -->
        <VisualState x:Key="SmallWindow">

            <!-- Small window trigger -->
            <VisualState.StateTriggers >
                <AdaptiveTrigger MinWindowWidth="{StaticResource MinWindowSnapPoint}"/>
            </VisualState.StateTriggers>

        </VisualState>

    </VisualStateGroup>
</VisualStateManager.VisualStateGroups>
```

### <a name="add-setters"></a><span data-ttu-id="0737f-189">setter を追加する</span><span class="sxs-lookup"><span data-stu-id="0737f-189">Add setters</span></span>
<span data-ttu-id="0737f-190">最後に、これらの setter を **SmallWindow** の状態に追加します。</span><span class="sxs-lookup"><span data-stu-id="0737f-190">Finally, add these setters to the **SmallWindow** state.</span></span>

```XAML

<VisualState x:Key="SmallWindow">
    ...

    <!-- Small window setters -->
    <VisualState.Setters>

        <!-- Apply mobile itemtemplate and styles -->
        <Setter Target="ImageGridView.ItemTemplate"
                Value="{StaticResource ImageGridView_MobileItemTemplate}" />
        <Setter Target="ImageGridView.ItemContainerStyle"
                Value="{StaticResource ImageGridView_MobileItemContainerStyle}" />

        <!-- Adjust the zoom slider to fit small windows-->
        <Setter Target="ZoomSlider.Minimum"
                Value="80" />
        <Setter Target="ZoomSlider.Maximum"
                Value="180" />
        <Setter Target="ZoomSlider.TickFrequency"
                Value="20" />
        <Setter Target="ZoomSlider.Value"
                Value="100" />
    </VisualState.Setters>

</VisualState>

```

<span data-ttu-id="0737f-191">これらの setter では、ビューポートが 641 ピクセル幅を下回る場合に、モバイルの **DataTemplate** およびスタイルがデスクトップ アプリに適用されます。</span><span class="sxs-lookup"><span data-stu-id="0737f-191">These setters apply the mobile **DataTemplate** and styles to the desktop app, whenever the viewport is less than 641 pixels wide.</span></span> <span data-ttu-id="0737f-192">また、小さい画面に合わせて、ズーム スライダーの調整も行われます。</span><span class="sxs-lookup"><span data-stu-id="0737f-192">They also tweak the zoom slider to better fit the small screen.</span></span>

### <a name="run-the-app"></a><span data-ttu-id="0737f-193">アプリを実行する</span><span class="sxs-lookup"><span data-stu-id="0737f-193">Run the app</span></span>

<span data-ttu-id="0737f-194">Visual Studio ツール バーで、ターゲット デバイスを **Local Machine** に設定し、アプリを実行します。</span><span class="sxs-lookup"><span data-stu-id="0737f-194">In the Visual Studio toolbar set the target device to **Local Machine**, and run the app.</span></span> <span data-ttu-id="0737f-195">アプリが読み込まれたら、ウィンドウのサイズを変更してみてください。</span><span class="sxs-lookup"><span data-stu-id="0737f-195">When the app loads, try changing the size of the window.</span></span> <span data-ttu-id="0737f-196">ウィンドウを小さなサイズに縮小すると、パート 2 で作成したモバイル レイアウトにアプリが切り替わることがわかります。</span><span class="sxs-lookup"><span data-stu-id="0737f-196">When you shrink the window to a small size, you should see the app switch to the mobile layout you created in Part 2.</span></span>

![小さなウィンドウ: 変更後](../basics/images/xaml-basics/adaptive-layout-small-after.png)

## <a name="going-further"></a><span data-ttu-id="0737f-198">追加情報</span><span class="sxs-lookup"><span data-stu-id="0737f-198">Going further</span></span>

<span data-ttu-id="0737f-199">これで、この演習は終わりです。自身でさらに試すために必要な、レイアウトに関する知識を身につけることができました。</span><span class="sxs-lookup"><span data-stu-id="0737f-199">Now that you've completed this lab, you have enough adaptive layout knowledge to experiment further on your own.</span></span> <span data-ttu-id="0737f-200">以前に追加したモバイル専用のヒントに、評価コントロールを追加してみてください。</span><span class="sxs-lookup"><span data-stu-id="0737f-200">Try adding a rating control to the mobile-only tooltip you added earlier.</span></span> <span data-ttu-id="0737f-201">または、さらに大きな課題として、大きな画面サイズ用にレイアウトを最適化してみてください (テレビ画面や Surface Studio を想定)。</span><span class="sxs-lookup"><span data-stu-id="0737f-201">Or, for a bigger challenge, try optimizing the layout for larger screen sizes (think TV screens or a Surface Studio)</span></span>

<span data-ttu-id="0737f-202">行き詰まった場合は、「[XAML を使ったページ レイアウトの定義](../layout/layouts-with-xaml.md)」の以下のセクションで、詳しいガイダンスを参照できます。</span><span class="sxs-lookup"><span data-stu-id="0737f-202">If you get stuck, you can find more guidance in these sections of [Define page layouts with XAML](../layout/layouts-with-xaml.md).</span></span>

+ [<span data-ttu-id="0737f-203">表示状態と状態トリガー</span><span class="sxs-lookup"><span data-stu-id="0737f-203">Visual states and state triggers</span></span>](https://docs.microsoft.com/en-us/windows/uwp/layout/layouts-with-xaml#visual-states-and-state-triggers)
+ [<span data-ttu-id="0737f-204">カスタマイズされたレイアウト</span><span class="sxs-lookup"><span data-stu-id="0737f-204">Tailored layouts</span></span>](https://docs.microsoft.com/en-us/windows/uwp/layout/layouts-with-xaml#tailored-layouts)

<span data-ttu-id="0737f-205">当初の写真編集アプリの作成方法を学習するには、XAML の[ユーザー インターフェイス](../basics/xaml-basics-ui.md)と[データ バインディング](../../data-binding/xaml-basics-data-binding.md)に関するチュートリアルをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0737f-205">Alternatively, if you want to learn more about how the initial photo editing app was built, check out these tutorials on XAML [user interfaces](../basics/xaml-basics-ui.md) and [data binding](../../data-binding/xaml-basics-data-binding.md).</span></span>

## <a name="get-the-final-version-of-the-photolab-sample"></a><span data-ttu-id="0737f-206">PhotoLab サンプルの最終バージョンを入手する</span><span class="sxs-lookup"><span data-stu-id="0737f-206">Get the final version of the PhotoLab sample</span></span>

<span data-ttu-id="0737f-207">このチュートリアルで完全な写真編集アプリは作成されません。必ず[最終バージョン](https://github.com/Microsoft/Windows-appsample-photo-lab)でカスタム アニメーションやスマートフォン サポートなど、他の機能を確認してください。</span><span class="sxs-lookup"><span data-stu-id="0737f-207">This tutorial doesn't build up to the complete photo editing app, so be sure to check out the [final version](https://github.com/Microsoft/Windows-appsample-photo-lab) to see other features such as custom animations and phone support.</span></span>