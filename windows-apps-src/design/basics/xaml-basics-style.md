---
author: mijacobs
title: カスタム スタイルを作成する
description: この記事では、XAML に含まれる UI 要素のスタイルの基本について説明します。
keywords: XAML, UWP, 概要
ms.author: mijacobs
ms.date: 08/31/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 11f279de206a84e61144789ba43a268f2b896fee
ms.sourcegitcommit: 6cc275f2151f78db40c11ace381ee2d35f0155f9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5570190"
---
# <a name="tutorial-create-custom-styles"></a><span data-ttu-id="23052-104">チュートリアル: カスタム スタイルを作成する</span><span class="sxs-lookup"><span data-stu-id="23052-104">Tutorial: Create custom styles</span></span>

<span data-ttu-id="23052-105">このチュートリアルでは、XAML アプリの UI をカスタマイズする方法を示します。</span><span class="sxs-lookup"><span data-stu-id="23052-105">This tutorial shows you how to customize the UI of our XAML app.</span></span> <span data-ttu-id="23052-106">警告: このチュートリアルにユニコーンが登場するかどうかは保証できません。</span><span class="sxs-lookup"><span data-stu-id="23052-106">Warning: this tutorial might or might not involve a unicorn.</span></span> <span data-ttu-id="23052-107">(後で登場します!)</span><span class="sxs-lookup"><span data-stu-id="23052-107">(It does!)</span></span>  

## <a name="prerequisites"></a><span data-ttu-id="23052-108">前提条件</span><span class="sxs-lookup"><span data-stu-id="23052-108">Prerequisites</span></span>
* [<span data-ttu-id="23052-109">Visual Studio 2017、Windows 10 SDK (10.0.15063.468 以降)</span><span class="sxs-lookup"><span data-stu-id="23052-109">Visual Studio 2017 and the Windows 10 SDK (10.0.15063.468 or later)</span></span>](https://developer.microsoft.com/windows/downloads)

## <a name="part-0-get-the-code"></a><span data-ttu-id="23052-110">パート 0: コードを入手する</span><span class="sxs-lookup"><span data-stu-id="23052-110">Part 0: Get the code</span></span>
<span data-ttu-id="23052-111">この演習の開始点は、PhotoLab サンプル リポジトリ ([xaml-basics-starting-points/style/ フォルダー](https://github.com/Microsoft/Windows-appsample-photo-lab/tree/master/xaml-basics-starting-points/style)) です。</span><span class="sxs-lookup"><span data-stu-id="23052-111">The starting point for this lab is located in the PhotoLab sample repository, in the [xaml-basics-starting-points/style/ folder](https://github.com/Microsoft/Windows-appsample-photo-lab/tree/master/xaml-basics-starting-points/style).</span></span> <span data-ttu-id="23052-112">このリポジトリを複製してダウンロードした後、Visual Studio 2017 で PhotoLab.sln を開くことによって、プロジェクトを編集できます。</span><span class="sxs-lookup"><span data-stu-id="23052-112">After you've cloned/downloaded the repo, you can edit the project by opening PhotoLab.sln with Visual Studio 2017.</span></span>

<span data-ttu-id="23052-113">PhotoLab アプリには、次の 2 つのプライマリ ページがあります。</span><span class="sxs-lookup"><span data-stu-id="23052-113">The PhotoLab app has two primary pages:</span></span>

<span data-ttu-id="23052-114">**MainPage.xaml:** フォト ギャラリー ビューが各イメージ ファイルに関する情報と共に表示されます。</span><span class="sxs-lookup"><span data-stu-id="23052-114">**MainPage.xaml:** displays a photo gallery view, along with some information about each image file.</span></span>
![MainPage](../basics/images/xaml-basics/mainpage.png)

<span data-ttu-id="23052-116">**DetailPage.xaml:** 選択された単一の写真が表示されます。</span><span class="sxs-lookup"><span data-stu-id="23052-116">**DetailPage.xaml:** displays a single photo after it has been selected.</span></span> <span data-ttu-id="23052-117">ポップアップの編集メニューにより、写真の編集、名前変更、保存を行うことができます。</span><span class="sxs-lookup"><span data-stu-id="23052-117">A flyout editing menu allows the photo to be altered, renamed, and saved.</span></span>
![DetailPage](../basics/images/xaml-basics/detailpage.png)

## <a name="part-1-create-a-fancy-slider-control"></a><span data-ttu-id="23052-119">パート 1: 装飾的なスライダー コントロールを作成する</span><span class="sxs-lookup"><span data-stu-id="23052-119">Part 1: Create a fancy slider control</span></span>  

<span data-ttu-id="23052-120">ユニバーサル Windows プラットフォーム (UWP) には、アプリの外観をカスタマイズするためのさまざまな方法が用意されています。</span><span class="sxs-lookup"><span data-stu-id="23052-120">Universal Windows Platform (UWP) provides a number of ways to customize the look of your app.</span></span> <span data-ttu-id="23052-121">フォントや文字体裁設定から、色やグラデーション、ぼかし効果まで、多数のオプションがあります。</span><span class="sxs-lookup"><span data-stu-id="23052-121">From fonts and typography settings to colors and gradients to blur effects, you have a lot of options.</span></span> 

<span data-ttu-id="23052-122">チュートリアルの最初のパートでは、写真編集コントロールを装飾してみましょう。</span><span class="sxs-lookup"><span data-stu-id="23052-122">For the first part of the tutorial, let's jazz up some of our photo editing controls.</span></span> 

<figure>
    <img src="../basics/images/xaml-basics/slider-start.png" />
    <figure>*<span data-ttu-id="23052-123">既定のスタイルによるシンプルなスライダー。</span><span class="sxs-lookup"><span data-stu-id="23052-123">A humble slider with default styling.</span></span>*</figure>
</figure>

<span data-ttu-id="23052-124">これらのスライダーに問題はなく、スライダーに必要な機能をすべて備えています。ただ、今ひとつ装飾性に欠けます。</span><span class="sxs-lookup"><span data-stu-id="23052-124">These sliders are nice--they do all the things a slider should do--but they aren't very fancy.</span></span> <span data-ttu-id="23052-125">これを解決してみましょう。</span><span class="sxs-lookup"><span data-stu-id="23052-125">Let's fix that.</span></span> 

<span data-ttu-id="23052-126">露出スライダーは、イメージの露出を調整します。左へスライドすると、イメージが暗くなり、右へスライドするとイメージが明るくなります。</span><span class="sxs-lookup"><span data-stu-id="23052-126">The exposure slider adjusts the exposure of the image: slide it to the left and the image gets darker; slider it to the right and it gets lighter.</span></span> <span data-ttu-id="23052-127">黒から白へのグラデーションを背景として設定し、スライダーの見栄えを改善してみましょう。</span><span class="sxs-lookup"><span data-stu-id="23052-127">Let's make our slider cooler by giving it a background that goes from black to white.</span></span> <span data-ttu-id="23052-128">スライダーの外観が良くなるだけではなく、スライダーによって提供される機能に関する視覚的な手がかりにもなります。</span><span class="sxs-lookup"><span data-stu-id="23052-128">It'll make the slider look better, which is great, but it will also provide a visual clue about the functionality that the slider provides.</span></span>

### <a name="customize-a-slider-control"></a><span data-ttu-id="23052-129">スライダー コントロールをカスタマイズする</span><span class="sxs-lookup"><span data-stu-id="23052-129">Customize a slider control</span></span>

<!-- TODO: Update folder -->
1. <span data-ttu-id="23052-130">リポジトリをダウンロードした後、xaml-basics-starting-points/style/ フォルダーの **PhotoLab.sln** を開き、ソリューション プラットフォームを x86 または x64 (ARM は不可) に設定します。</span><span class="sxs-lookup"><span data-stu-id="23052-130">After downloading the repository, open **PhotoLab.sln** in the xaml-basics-starting-points/style/ folder, and set your Solution Platform to x86 or x64 (not ARM).</span></span> 

    <span data-ttu-id="23052-131">F5 キーを押して、アプリをコンパイルし、実行します。</span><span class="sxs-lookup"><span data-stu-id="23052-131">Press F5 to compile and run the app.</span></span> <span data-ttu-id="23052-132">最初の画面には、イメージ ギャラリーが表示されます。</span><span class="sxs-lookup"><span data-stu-id="23052-132">The first screen shows a gallery of images.</span></span> <span data-ttu-id="23052-133">いずれかのイメージをクリックして、イメージの詳細ページに移動します。</span><span class="sxs-lookup"><span data-stu-id="23052-133">Click an image to go to the image details page.</span></span> <span data-ttu-id="23052-134">移動したら [Edit] ボタンをクリックして、これから作業対象となる編集コントロールを確認します。</span><span class="sxs-lookup"><span data-stu-id="23052-134">Once you're there, click the edit button to see the editing controls we'll be working on.</span></span> <span data-ttu-id="23052-135">アプリケーションを終了し、Visual Studio に戻ります。</span><span class="sxs-lookup"><span data-stu-id="23052-135">Exit the app and return to Visual Studio.</span></span>  

2. <span data-ttu-id="23052-136">[ソリューション エクスプローラー] パネルで、**DetailPage.xaml** をダブルクリックして開きます。</span><span class="sxs-lookup"><span data-stu-id="23052-136">In the Solution Explorer panel, double-click **DetailPage.xaml** to open it.</span></span> 

    ![Visual Studio 2017 のソリューション エクスプ ローラーに表示された DetailPage.xaml ファイル。](../basics/images/xaml-basics/style-detail-page-explorer.png)

3. <span data-ttu-id="23052-138">Polygon 要素を使用して、Exposure スライダーの背景用図形を作成します。</span><span class="sxs-lookup"><span data-stu-id="23052-138">Use a Polygon element to create a background shape for the exposure slider.</span></span>

    <span data-ttu-id="23052-139">[Windows.XAML.Ui.Shapes 名前空間](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.Shapes)には、7 つの図形が用意されており、ここから選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="23052-139">The [Windows.XAML.Ui.Shapes namespace](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.Shapes) provides seven shapes to choose from.</span></span> <span data-ttu-id="23052-140">楕円形、四角形のほか、パスと呼ばれるものを使うと、どのような図形でも (ユニコーンでも!) 作成できます。</span><span class="sxs-lookup"><span data-stu-id="23052-140">There's an ellipse, a rectangle, and a thing called a Path, which can make any sort of shape--yes, even a unicorn!</span></span> 
    
    <span data-ttu-id="23052-141"><!-- TODO reduce size --> ![ユニコーン](../basics/images/xaml-basics/unicorn.png)</span><span class="sxs-lookup"><span data-stu-id="23052-141"><!-- TODO reduce size --> ![A unicorn](../basics/images/xaml-basics/unicorn.png)</span></span>
    
    > <span data-ttu-id="23052-142">**参考情報:** 「[図形の描画](https://docs.microsoft.com/en-us/windows/uwp/graphics/drawing-shapes)」という記事には、XAML の図形について知っておく必要があるすべての情報が含まれています。</span><span class="sxs-lookup"><span data-stu-id="23052-142">**Read about it:** The [Draw shapes](https://docs.microsoft.com/en-us/windows/uwp/graphics/drawing-shapes) article tells you everything you need to know about XAML shapes.</span></span> 
    
    <span data-ttu-id="23052-143">ここでは、ステレオのボリューム コントロールのような形をした、三角形のウィジェットを作成します。</span><span class="sxs-lookup"><span data-stu-id="23052-143">We want to create a triangle-looking widget--something like the shape you'd see on a stereo's volume control.</span></span>
    
    ![ボリューム スライダー](../basics/images/xaml-basics/style-volume-slider.png)
    
    <span data-ttu-id="23052-145">どうやら多角形を扱う作業のようですね! </span><span class="sxs-lookup"><span data-stu-id="23052-145">Sounds like a job for the Polygon shape!</span></span> <span data-ttu-id="23052-146">多角形を定義するには、点のセットを指定し、塗りつぶしを行います。</span><span class="sxs-lookup"><span data-stu-id="23052-146">To define a polygon, you specify a set of points and give it a fill.</span></span> <span data-ttu-id="23052-147">では、幅 200 ピクセル、高さ 20 ピクセルの多角形を作成し、グラデーションで塗りつぶしてみましょう。</span><span class="sxs-lookup"><span data-stu-id="23052-147">Let's create a polygon that's about 200 pixels wide and 20 pixels tall, with a gradient fill.</span></span>
    
    <span data-ttu-id="23052-148">DetailPage.xaml で、露出 (Exposure) スライダーのコードを見つけ、直前に Polygon 要素を作成します。</span><span class="sxs-lookup"><span data-stu-id="23052-148">In DetailPage.xaml, find the code for the exposure slider, then create a Polygon element just before it:</span></span> 

    * <span data-ttu-id="23052-149">露出スライダーと同じ行に多角形を配置するために、**Grid.Row** を "2" に設定します。</span><span class="sxs-lookup"><span data-stu-id="23052-149">Set **Grid.Row** to "2" to put the polygon in the same row as the exposure slider.</span></span> 
    * <span data-ttu-id="23052-150">三角形の図形を定義するために、**Points** プロパティを "0,20 200,20 200,0" に設定します。</span><span class="sxs-lookup"><span data-stu-id="23052-150">Set the **Points** property to "0,20 200,20 200,0" to define the triangle shape.</span></span>
    * <span data-ttu-id="23052-151">**Stretch** プロパティを "Fill" に、**HorizontalAlignment** プロパティを "Stretch" に設定します。</span><span class="sxs-lookup"><span data-stu-id="23052-151">Set the **Stretch** property to "Fill" and the **HorizontalAlignment** property to "Stretch".</span></span>
    * <span data-ttu-id="23052-152">**Height** を "20"、**VerticalAlignment** を "Center" に設定します。</span><span class="sxs-lookup"><span data-stu-id="23052-152">Set the **Height** to "20" and the **VerticalAlignment** to "Center".</span></span> 
    * <span data-ttu-id="23052-153">**Polygon** に、線状グラデーションによる塗りつぶしを適用します。</span><span class="sxs-lookup"><span data-stu-id="23052-153">Give the **Polygon** a linear gradient fill.</span></span>     
    * <span data-ttu-id="23052-154">露出スライダーでは、多角形が見えるように、**Foreground** プロパティを "Transparent" に設定します。</span><span class="sxs-lookup"><span data-stu-id="23052-154">On the exposure slider, set the **Foreground** property to "Transparent" so you can see the polygon.</span></span> 

    **<span data-ttu-id="23052-155">変更前</span><span class="sxs-lookup"><span data-stu-id="23052-155">Before</span></span>**
    ```xaml
    <Slider Header="Exposure"
        Grid.Row="2"
        Value="{x:Bind item.Exposure, Mode=TwoWay}"
        Minimum="-2"
        Maximum="2" />
    ```
    **<span data-ttu-id="23052-156">変更後</span><span class="sxs-lookup"><span data-stu-id="23052-156">After</span></span>**
    ```xaml
    <Polygon Grid.Row="2" Stretch="Fill"
                Points="0,20 200,20 200,0" HorizontalAlignment="Stretch"  
                VerticalAlignment="Center" Height="20">
        <Polygon.Fill>
            <LinearGradientBrush StartPoint="0,0.5" EndPoint="1,0.5">
                <LinearGradientBrush.GradientStops>
                    <GradientStop Offset="0" Color="Black" />
                    <GradientStop Offset="1" Color="White" />
                </LinearGradientBrush.GradientStops>
            </LinearGradientBrush>
        </Polygon.Fill>
    </Polygon>
    <Slider Header="Exposure" 
        Grid.Row="2" 
        Foreground="Transparent"
        Value="{x:Bind item.Exposure, Mode=TwoWay}"
        Minimum="-2"
        Maximum="2" />
    ```

    <span data-ttu-id="23052-157">注:</span><span class="sxs-lookup"><span data-stu-id="23052-157">Notes:</span></span>
    * <span data-ttu-id="23052-158">周囲の XAML を見ると、これらの要素が Grid に含まれていることがわかります。</span><span class="sxs-lookup"><span data-stu-id="23052-158">If you look at the surrounding XAML, you'll see that these elements are in a Grid.</span></span> <span data-ttu-id="23052-159">露出スライダーと同じ行 (Grid.Row="2") に多角形を配置しました。これは、両者を同じ位置に表示するためです。</span><span class="sxs-lookup"><span data-stu-id="23052-159">We put the polygon in the same row as the exposure slider (Grid.Row="2") so they appear in the same spot.</span></span> <span data-ttu-id="23052-160">図形の最上部にスライダーを表示できるように、スライダーの前に多角形を配置しました。</span><span class="sxs-lookup"><span data-stu-id="23052-160">We put the polygon before the slider so that the slider renders of top of the shape.</span></span>
    * <span data-ttu-id="23052-161">この三角形が空き領域に合わせた大きさになるように、Polygon で Stretch="Fill" および HorizontalAlignment="Stretch" を設定しました。</span><span class="sxs-lookup"><span data-stu-id="23052-161">We set Stretch="Fill" and HorizontalAlignment="Stretch" on the polygon so that the triangle will adjust to fill the available space.</span></span> <span data-ttu-id="23052-162">スライダーの幅が縮小または拡大されると、これに合わせて多角形も縮小または拡大されます。</span><span class="sxs-lookup"><span data-stu-id="23052-162">If the slider shrinks or grows in width, the polygon will shrink or grow to match.</span></span> 

4. <span data-ttu-id="23052-163">アプリをコンパイルして実行します。</span><span class="sxs-lookup"><span data-stu-id="23052-163">Compile and run the app.</span></span> <span data-ttu-id="23052-164">これでスライダーはすばらしい外観になります。</span><span class="sxs-lookup"><span data-stu-id="23052-164">Your slider should now look awesome:</span></span>

    ![装飾的な露出スライダー](../basics/images/xaml-basics/style-exposure-slider-done.png)

5. <span data-ttu-id="23052-166">次に、色温度 (Temperature) スライダーをアップグレードしましょう。</span><span class="sxs-lookup"><span data-stu-id="23052-166">Let's give the next slider, the temperature slider, an upgrade.</span></span> <span data-ttu-id="23052-167">色温度スライダーでは、イメージの色温度が変化します。左へスライドするとイメージが青っぽくなり、右へスライドすると黄色っぽくなります。</span><span class="sxs-lookup"><span data-stu-id="23052-167">The temperature slider changes the color temperature of the image; sliding to the left makes the image bluer and sliding to the right makes the image more yellow.</span></span>

    <span data-ttu-id="23052-168">この背景図形用に、先ほどのものと同じ寸法の多角形をもう 1 つ使用します。ただし今回は、白黒ではなく青と黄色のグラデーションで塗りつぶします。</span><span class="sxs-lookup"><span data-stu-id="23052-168">We'll use another polygon for this background shape with the same dimensions as the previous one, but this time we'll make the fill a blue-yellow gradient instead of black and white.</span></span> 

    **<span data-ttu-id="23052-169">変更前</span><span class="sxs-lookup"><span data-stu-id="23052-169">Before</span></span>**
    ```xaml
    <TextBlock Grid.Row="2"
                Grid.Column="1"
                 Margin="10,8,0,0" VerticalAlignment="Center" Padding="0"
                Text="{x:Bind item.Exposure.ToString('N', culture), Mode=OneWay}" />
                
    <Slider Header="Temperature"
            Grid.Row="3" Background="Transparent" Foreground="Transparent"
            Value="{x:Bind item.Temperature, Mode=TwoWay}"
            Minimum="-1"
            Maximum="1" />
    ```
    **<span data-ttu-id="23052-170">変更後</span><span class="sxs-lookup"><span data-stu-id="23052-170">After</span></span>**
    ```xaml
    <TextBlock Grid.Row="2"
                Grid.Column="1"
                Margin="10,8,0,0" VerticalAlignment="Center" Padding="0"
                Text="{x:Bind item.Exposure.ToString('N', culture), Mode=OneWay}" />         
                
    <Polygon Grid.Row="3" Stretch="Fill"
                Points="0,20 200,20 200,0" HorizontalAlignment="Stretch"  
                VerticalAlignment="Center" Height="20">
        <Polygon.Fill>
            <LinearGradientBrush StartPoint="0,0.5" EndPoint="1,0.5">
                <LinearGradientBrush.GradientStops>
                    <GradientStop Offset="0" Color="Blue" />
                    <GradientStop Offset="1" Color="Yellow" />
                </LinearGradientBrush.GradientStops>
            </LinearGradientBrush>
        </Polygon.Fill>
    </Polygon>
    <Slider Header="Temperature"
            Grid.Row="3" Background="Transparent" Foreground="Transparent"
            Value="{x:Bind item.Temperature, Mode=TwoWay}"
            Minimum="-1"
            Maximum="1" />
    ```

6. <span data-ttu-id="23052-171">アプリをコンパイルして実行します。</span><span class="sxs-lookup"><span data-stu-id="23052-171">Compile and run the app.</span></span> <span data-ttu-id="23052-172">これで、2 つの装飾的なスライダーが作成されました。</span><span class="sxs-lookup"><span data-stu-id="23052-172">You should now have two fancy sliders.</span></span>

    ![2 つの装飾的なスライダー](../basics/images/xaml-basics/style-2sliders-done.png)

7. **<span data-ttu-id="23052-174">追加クレジット</span><span class="sxs-lookup"><span data-stu-id="23052-174">Extra credit</span></span>**

    <span data-ttu-id="23052-175">グラデーションで緑から赤に変化するティント (Tint) スライダーに、背景の図形を追加します。</span><span class="sxs-lookup"><span data-stu-id="23052-175">Add a background shape for the tint slider that has a gradient from green to red.</span></span> 

    ![3 つの装飾的なスライダー](../basics/images/xaml-basics/style-3sliders-done.png)


<span data-ttu-id="23052-177">これで、パート 1 は終わりです。</span><span class="sxs-lookup"><span data-stu-id="23052-177">Congratulations, you've completed part 1!</span></span> <span data-ttu-id="23052-178">行き詰った場合や最終的なソリューションを確認したい場合は、完成したコードが **UWP Academy\XAML\Styling\Part1\Finish** にあります。</span><span class="sxs-lookup"><span data-stu-id="23052-178">If you got stuck or want to see the final solution, you can find the completed code at **UWP Academy\XAML\Styling\Part1\Finish**.</span></span>

 
    
## <a name="part-2-create-basic-styles"></a><span data-ttu-id="23052-179">パート 2: 基本スタイルを作成する</span><span class="sxs-lookup"><span data-stu-id="23052-179">Part 2: Create basic styles</span></span>

<span data-ttu-id="23052-180">XAML スタイルの利点の 1 つは、記述するコードの量を劇的に削減し、アプリの外観を更新する作業がずっと簡単になることです。</span><span class="sxs-lookup"><span data-stu-id="23052-180">One of the advantages of XAML styles is that it can dramatically cut down the amount of code you have to write, and it can make it much, much easier to update the look of your app.</span></span>

<span data-ttu-id="23052-181">スタイルを定義するには、スタイルの適用対象となるコントロールが含まれる要素の [Resources](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.frameworkelement.Resources) プロパティに [Style](https://msdn.microsoft.com/library/windows/apps/br208849) 要素を追加します。</span><span class="sxs-lookup"><span data-stu-id="23052-181">To define a style, you add a [Style](https://msdn.microsoft.com/library/windows/apps/br208849) element to the [Resources](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.frameworkelement.Resources) property of an element that contains the control you want to style.</span></span>  <span data-ttu-id="23052-182">スタイルを **Page.Resources**プロパティに追加すると、ページ全体で、そのスタイルにアクセスできるようになります。</span><span class="sxs-lookup"><span data-stu-id="23052-182">If you add your style to the **Page.Resources** property, your styles will be accessible to the entire page.</span></span> <span data-ttu-id="23052-183">App.xaml ファイル内で **Application.Resources** プロパティにスタイルを追加すると、ページ全体で、そのスタイルにアクセスできるようになります。</span><span class="sxs-lookup"><span data-stu-id="23052-183">If you add your style to the **Application.Resources** property in your App.xaml file, the style will be accessible to the entire app.</span></span>

<span data-ttu-id="23052-184">名前付きスタイルと一般スタイルを作成することができます。</span><span class="sxs-lookup"><span data-stu-id="23052-184">You can create named styles and general styles.</span></span> <span data-ttu-id="23052-185">名前付きスタイルは、特定のコントロールに明示的に適用する必要があります。一般スタイルは、指定された **TargetType** に一致するすべてのコントロールに適用されます。</span><span class="sxs-lookup"><span data-stu-id="23052-185">A named style must be explicitly applied to specific controls; a general style is applied to any control that matches the specified **TargetType**.</span></span> 

<span data-ttu-id="23052-186">この例では、最初のスタイルには **x:Key** 属性が含まれており、ターゲットとなる型は **Button** です。</span><span class="sxs-lookup"><span data-stu-id="23052-186">In this example, the first style has an **x:Key** attribute and its target type is **Button**.</span></span> <span data-ttu-id="23052-187">最初のボタンの **Style** プロパティはこのキーに設定されているため、このスタイルは名前付きスタイルであり、明示的に適用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="23052-187">The first button's **Style** property is set to this key, so this style is a named style and must be applied explicitly.</span></span> <span data-ttu-id="23052-188">2 番目のスタイルは、ターゲットとなる型が **Button** で、スタイルに **x:Key** 属性が含まれないため、2 番目のボタンに自動的に適用されます。</span><span class="sxs-lookup"><span data-stu-id="23052-188">The second style is applied automatically to the second button because its target type is **Button** and the style doesn't have an **x:Key** attribute.</span></span>


```XAML
<Page.Resources>
    <Style x:Key="PurpleStyle" TargetType="Button">
        <Setter Property="FontFamily" Value="Lucida Sans Unicode"/>
        <Setter Property="FontStyle" Value="Italic"/>
        <Setter Property="FontSize" Value="14"/>
        <Setter Property="Foreground" Value="MediumOrchid"/>
    </Style>

    <Style TargetType="Button">
        <Setter Property="Foreground" Value="Orange"/>
    </Style>
</Page.Resources>

<Grid x:Name="LayoutRoot">
    <Button Content="Button" Style="{StaticResource PurpleStyle}"/>
    <Button Content="Button" />
</Grid>
```

<span data-ttu-id="23052-189">では、アプリにスタイルを追加しましょう。</span><span class="sxs-lookup"><span data-stu-id="23052-189">Let's add a style to our app.</span></span> <span data-ttu-id="23052-190">DetailsPage.xaml で、露出、色温度、およびティントの各スライダーに隣接するテキスト ブロックを見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="23052-190">In DetailsPage.xaml, take a look at the text blocks that sit next to our exposure, temperature, and tint sliders.</span></span> <span data-ttu-id="23052-191">これらの各テキスト ブロックでは、スライダーの値を表示します。</span><span class="sxs-lookup"><span data-stu-id="23052-191">Each of these text blocks displays the value of a slider.</span></span> <span data-ttu-id="23052-192">露出スライダーのテキスト ブロックは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="23052-192">Here's the text block for the exposure slider.</span></span> <span data-ttu-id="23052-193">**Margin**、**VerticalAlignment**、および **Padding** の各プロパティが設定されています。</span><span class="sxs-lookup"><span data-stu-id="23052-193">Notice that the **Margin**, **VerticalAlignment**, and **Padding** properties are set.</span></span>

```XAML
<TextBlock Grid.Row="2"
            Grid.Column="1"
            Margin="10,8,0,0" VerticalAlignment="Center" Padding="0"
            Text="{x:Bind item.Exposure.ToString('N', culture), Mode=OneWay}" />
```
<span data-ttu-id="23052-194">他のテキスト ブロックでも、同じプロパティが同じ値に設定されています。</span><span class="sxs-lookup"><span data-stu-id="23052-194">Look at the other text blocks--notice that those same properties are set to the same values.</span></span> <span data-ttu-id="23052-195">これらをスタイルに使うと良さそうです。</span><span class="sxs-lookup"><span data-stu-id="23052-195">Sounds like a good candidate for a style...</span></span>

### <a name="create-a-value-text-block-style"></a><span data-ttu-id="23052-196">有用なテキスト ブロック スタイルを作成する</span><span class="sxs-lookup"><span data-stu-id="23052-196">Create a value text block style</span></span>

<!-- TODO: add second starting point -->
1. <span data-ttu-id="23052-197">DetailsPage.xaml を開きます。</span><span class="sxs-lookup"><span data-stu-id="23052-197">Open DetailsPage.xaml.</span></span>

2. <span data-ttu-id="23052-198">**EditControlsGrid** という名前の **Grid** コントロールを見つけます。</span><span class="sxs-lookup"><span data-stu-id="23052-198">Find the **Grid** control named **EditControlsGrid**.</span></span> <span data-ttu-id="23052-199">これには、スライダーとテキスト ボックスが含まれています。</span><span class="sxs-lookup"><span data-stu-id="23052-199">It contains our sliders and text boxes.</span></span> <span data-ttu-id="23052-200">グリッドにより、スライダーのスタイルが既に定義されています。</span><span class="sxs-lookup"><span data-stu-id="23052-200">Notice that the grid already defines a style for our sliders.</span></span> 

    ```XAML
    <Grid x:Name="EditControlsGrid"
            HorizontalAlignment="Stretch"
            Margin="24,48,24,24">
        <Grid.Resources>
            <Style TargetType="Slider">
                <Setter Property="Margin"
                        Value="0,0,0,0" />
                <Setter Property="Padding"
                        Value="0" />
                <Setter Property="MinWidth"
                        Value="100" />
                <Setter Property="StepFrequency"
                        Value="0.1" />
                <Setter Property="TickFrequency"
                        Value="0.1" />
            </Style>
        </Grid.Resources>    
    ```
3. <span data-ttu-id="23052-201">**TextBlock** の **Margin** を "10,8,0,0"、**VerticalAlignment** を "Center"、**Padding** を "0" に設定するスタイルを作成します。</span><span class="sxs-lookup"><span data-stu-id="23052-201">Create a style for a **TextBlock** that sets its **Margin** to "10,8,0,0", its **VerticalAlignment** to "Center", and its **Padding** to "0".</span></span>

    **<span data-ttu-id="23052-202">変更前</span><span class="sxs-lookup"><span data-stu-id="23052-202">Before</span></span>**
    ```XAML
        <Grid.Resources>
            <Style TargetType="Slider">
                <Setter Property="Margin"
                        Value="0,0,0,0" />
                <Setter Property="Padding"
                        Value="0" />
                <Setter Property="MinWidth"
                        Value="100" />
                <Setter Property="StepFrequency"
                        Value="0.1" />
                <Setter Property="TickFrequency"
                        Value="0.1" />
            </Style>                           
        </Grid.Resources>
    ```

    **<span data-ttu-id="23052-203">変更後</span><span class="sxs-lookup"><span data-stu-id="23052-203">After</span></span>**
    ```XAML
        <Grid.Resources>
            <Style TargetType="Slider">
                <Setter Property="Margin"
                        Value="0,0,0,0" />
                <Setter Property="Padding"
                        Value="0" />
                <Setter Property="MinWidth"
                        Value="100" />
                <Setter Property="StepFrequency"
                        Value="0.1" />
                <Setter Property="TickFrequency"
                        Value="0.1" />
            </Style>
            <Style TargetType="TextBlock">
                <Setter Property="Margin"
                        Value="10,8,0,0" />
                <Setter Property="VerticalAlignment"
                        Value="Center" />
                <Setter Property="Padding"
                        Value="0" />
            </Style>                            
        </Grid.Resources>
    ```    

4. <span data-ttu-id="23052-204">どの **TextBlock** コントロールに適用するかを指定できるように、これを名前付きスタイルにしましょう。</span><span class="sxs-lookup"><span data-stu-id="23052-204">Let's make this a named style so we can specify which **TextBlock** controls it applies to.</span></span> <span data-ttu-id="23052-205">スタイルの **x:Key** プロパティを "ValueTextBox" に設定します。</span><span class="sxs-lookup"><span data-stu-id="23052-205">Set the style's **x:Key** property to "ValueTextBox".</span></span> 

    **<span data-ttu-id="23052-206">変更前</span><span class="sxs-lookup"><span data-stu-id="23052-206">Before</span></span>**
    ```XAML
            <Style TargetType="TextBlock">
                <Setter Property="Margin"
                        Value="10,8,0,0" />
                <Setter Property="VerticalAlignment"
                        Value="Center" />
                <Setter Property="Padding"
                        Value="0" />
            </Style>                            
    ```    

    **<span data-ttu-id="23052-207">変更後</span><span class="sxs-lookup"><span data-stu-id="23052-207">After</span></span>**
    ```XAML
            <Style TargetType="TextBlock"
                   x:Key="ValueTextBox">
                <Setter Property="Margin"
                        Value="10,8,0,0" />
                <Setter Property="VerticalAlignment"
                        Value="Center" />
                <Setter Property="Padding"
                        Value="0" />
            </Style>                            
    ```    

5. <span data-ttu-id="23052-208">各 **TextBlock** について、**Margin**、**VerticalAlignment**、および **Padding** プロパティを削除し、**Style** プロパティを "{StaticResource ValueTextBox}" に設定します。</span><span class="sxs-lookup"><span data-stu-id="23052-208">For each **TextBlock**, remove its **Margin**, **VerticalAlignment**, and **Padding** properties, and set its **Style** property to "{StaticResource ValueTextBox}".</span></span>

    **<span data-ttu-id="23052-209">変更前</span><span class="sxs-lookup"><span data-stu-id="23052-209">Before</span></span>**
    ```XAML
     <TextBlock Grid.Row="2"
                Grid.Column="1"
                Margin="10,8,0,0" VerticalAlignment="Center" Padding="0"
                Text="{x:Bind item.Exposure.ToString('N', culture), Mode=OneWay}" />   
    ```

    **<span data-ttu-id="23052-210">変更後</span><span class="sxs-lookup"><span data-stu-id="23052-210">After</span></span>**
    ```XAML
     <TextBlock Grid.Row="2"
                Grid.Column="1"
                Style="{StaticResource ValueTextBox}"
                Text="{x:Bind item.Exposure.ToString('N', culture), Mode=OneWay}" />   
    ```    

    <span data-ttu-id="23052-211">スライダーに関連付けられている 6 つの TextBlock コントロールすべてに対して、この変更を行います。</span><span class="sxs-lookup"><span data-stu-id="23052-211">Make this change to all 6 TextBlock controls associated with the sliders.</span></span>

6. <span data-ttu-id="23052-212">アプリをコンパイルして実行します。</span><span class="sxs-lookup"><span data-stu-id="23052-212">Compile and run the app.</span></span> <span data-ttu-id="23052-213">外観に変わりはないのですが、</span><span class="sxs-lookup"><span data-stu-id="23052-213">It should look... the same.</span></span> <span data-ttu-id="23052-214">効率的で保守性に優れたコードを記述したことによる、すばらしい満足感と達成感をかみしめてください。</span><span class="sxs-lookup"><span data-stu-id="23052-214">But you should feel that wonderful sense of satisfaction and accomplishment that comes from writing efficient, maintainable code.</span></span>

<!-- TODO add new start/end points -->
<span data-ttu-id="23052-215">これで、パート 2 は終わりです。</span><span class="sxs-lookup"><span data-stu-id="23052-215">Congratulations, you've completed Part 2!</span></span>


## <a name="part-3-use-a-control-template-to-make-a-fancy-slider"></a><span data-ttu-id="23052-216">パート 3: コントロール テンプレートを使用して装飾的なスライダーを作成する</span><span class="sxs-lookup"><span data-stu-id="23052-216">Part 3: Use a control template to make a fancy slider</span></span>

<span data-ttu-id="23052-217">パート 1 では、見栄えを良くするために、スライダーの背後に図形を追加しました。</span><span class="sxs-lookup"><span data-stu-id="23052-217">Remember, how in Part 1 we added a shape behind the slider to make it look cool?</span></span>

<span data-ttu-id="23052-218">それで目的は達成しましたが、この効果を得るためのもっと良い方法は、コントロール テンプレートを作成することです。</span><span class="sxs-lookup"><span data-stu-id="23052-218">Well, we got the job done, but there's a better way to achieve the same effect: create a control template.</span></span> 

<!-- TODO add new starting points -->
1. <span data-ttu-id="23052-219">[ソリューション エクスプローラー] パネルで、**DetailPage.xaml** をダブルクリックします。</span><span class="sxs-lookup"><span data-stu-id="23052-219">In the Solution Explorer panel, double-click **DetailPage.xaml**.</span></span>

2. <span data-ttu-id="23052-220">次に、開始点として、スライダー用に既定のコントロール テンプレートを使用します。</span><span class="sxs-lookup"><span data-stu-id="23052-220">Next, we'll use the default control template for slider as our starting point.</span></span> <span data-ttu-id="23052-221">この XAML を **Page.Resources** 要素に追加します </span><span class="sxs-lookup"><span data-stu-id="23052-221">Add this XAML to the **Page.Resources** element.</span></span> <span data-ttu-id="23052-222">(**Page.Resources** 要素は、ページ先頭の近くにあります)。</span><span class="sxs-lookup"><span data-stu-id="23052-222">(The **Page.Resources** element is toward the beginning of the page.)</span></span>

    ```XAML
    <ControlTemplate x:Key="FancySliderControlTemplate" TargetType="Slider">
        <Grid Margin="{TemplateBinding Padding}">
            <Grid.Resources>
                <Style TargetType="Thumb" x:Key="SliderThumbStyle">
                    <Setter Property="BorderThickness" Value="0" />
                    <Setter Property="Background" Value="{ThemeResource SliderThumbBackground}" />
                    <Setter Property="Template">
                        <Setter.Value>
                            <ControlTemplate TargetType="Thumb">
                                <Border Background="{TemplateBinding Background}"
                                            BorderBrush="{TemplateBinding BorderBrush}"
                                            BorderThickness="{TemplateBinding BorderThickness}"
                                            CornerRadius="4" />
                            </ControlTemplate>
                        </Setter.Value>
                    </Setter>
                </Style>
            </Grid.Resources>
            <Grid.RowDefinitions>
                <RowDefinition Height="Auto" />
                <RowDefinition Height="*" />
            </Grid.RowDefinitions>
            <VisualStateManager.VisualStateGroups>
                <VisualStateGroup x:Name="CommonStates">
                    <VisualState x:Name="Normal" />
                    <VisualState x:Name="Pressed">
                        <Storyboard>
                            <ObjectAnimationUsingKeyFrames Storyboard.TargetName="HorizontalTrackRect" Storyboard.TargetProperty="Fill">
                                <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource SliderTrackFillPressed}" />
                            </ObjectAnimationUsingKeyFrames>
                            <ObjectAnimationUsingKeyFrames Storyboard.TargetName="VerticalTrackRect" Storyboard.TargetProperty="Fill">
                                <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource SliderTrackFillPressed}" />
                            </ObjectAnimationUsingKeyFrames>
                            <ObjectAnimationUsingKeyFrames Storyboard.TargetName="HorizontalThumb" Storyboard.TargetProperty="Background">
                                <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource SliderThumbBackgroundPressed}" />
                            </ObjectAnimationUsingKeyFrames>
                            <ObjectAnimationUsingKeyFrames Storyboard.TargetName="VerticalThumb" Storyboard.TargetProperty="Background">
                                <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource SliderThumbBackgroundPressed}" />
                            </ObjectAnimationUsingKeyFrames>
                            <ObjectAnimationUsingKeyFrames Storyboard.TargetName="SliderContainer" Storyboard.TargetProperty="Background">
                                <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource SliderContainerBackgroundPressed}" />
                            </ObjectAnimationUsingKeyFrames>
                            <ObjectAnimationUsingKeyFrames Storyboard.TargetName="HorizontalDecreaseRect" Storyboard.TargetProperty="Fill">
                                <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource SliderTrackValueFillPressed}" />
                            </ObjectAnimationUsingKeyFrames>
                            <ObjectAnimationUsingKeyFrames Storyboard.TargetName="VerticalDecreaseRect" Storyboard.TargetProperty="Fill">
                                <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource SliderTrackValueFillPressed}" />
                            </ObjectAnimationUsingKeyFrames>
                        </Storyboard>
                    </VisualState>
                    <VisualState x:Name="Disabled">
                        <Storyboard>
                            <ObjectAnimationUsingKeyFrames Storyboard.TargetName="HeaderContentPresenter" Storyboard.TargetProperty="Foreground">
                                <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource SliderHeaderForegroundDisabled}" />
                            </ObjectAnimationUsingKeyFrames>
                            <ObjectAnimationUsingKeyFrames Storyboard.TargetName="HorizontalDecreaseRect" Storyboard.TargetProperty="Fill">
                                <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource SliderTrackValueFillDisabled}" />
                            </ObjectAnimationUsingKeyFrames>
                            <ObjectAnimationUsingKeyFrames Storyboard.TargetName="HorizontalTrackRect" Storyboard.TargetProperty="Fill">
                                <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource SliderTrackFillDisabled}" />
                            </ObjectAnimationUsingKeyFrames>
                            <ObjectAnimationUsingKeyFrames Storyboard.TargetName="VerticalDecreaseRect" Storyboard.TargetProperty="Fill">
                                <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource SliderTrackValueFillDisabled}" />
                            </ObjectAnimationUsingKeyFrames>
                            <ObjectAnimationUsingKeyFrames Storyboard.TargetName="VerticalTrackRect" Storyboard.TargetProperty="Fill">
                                <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource SliderTrackFillDisabled}" />
                            </ObjectAnimationUsingKeyFrames>
                            <ObjectAnimationUsingKeyFrames Storyboard.TargetName="HorizontalThumb" Storyboard.TargetProperty="Background">
                                <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource SliderThumbBackgroundDisabled}" />
                            </ObjectAnimationUsingKeyFrames>
                            <ObjectAnimationUsingKeyFrames Storyboard.TargetName="VerticalThumb" Storyboard.TargetProperty="Background">
                                <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource SliderThumbBackgroundDisabled}" />
                            </ObjectAnimationUsingKeyFrames>
                            <ObjectAnimationUsingKeyFrames Storyboard.TargetName="TopTickBar" Storyboard.TargetProperty="Fill">
                                <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource SliderTickBarFillDisabled}" />
                            </ObjectAnimationUsingKeyFrames>
                            <ObjectAnimationUsingKeyFrames Storyboard.TargetName="BottomTickBar" Storyboard.TargetProperty="Fill">
                                <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource SliderTickBarFillDisabled}" />
                            </ObjectAnimationUsingKeyFrames>
                            <ObjectAnimationUsingKeyFrames Storyboard.TargetName="LeftTickBar" Storyboard.TargetProperty="Fill">
                                <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource SliderTickBarFillDisabled}" />
                            </ObjectAnimationUsingKeyFrames>
                            <ObjectAnimationUsingKeyFrames Storyboard.TargetName="RightTickBar" Storyboard.TargetProperty="Fill">
                                <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource SliderTickBarFillDisabled}" />
                            </ObjectAnimationUsingKeyFrames>
                            <ObjectAnimationUsingKeyFrames Storyboard.TargetName="SliderContainer" Storyboard.TargetProperty="Background">
                                <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource SliderContainerBackgroundDisabled}" />
                            </ObjectAnimationUsingKeyFrames>
                        </Storyboard>
                    </VisualState>
                    <VisualState x:Name="PointerOver">
                        <Storyboard>
                            <ObjectAnimationUsingKeyFrames Storyboard.TargetName="HorizontalTrackRect" Storyboard.TargetProperty="Fill">
                                <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource SliderTrackFillPointerOver}" />
                            </ObjectAnimationUsingKeyFrames>
                            <ObjectAnimationUsingKeyFrames Storyboard.TargetName="VerticalTrackRect" Storyboard.TargetProperty="Fill">
                                <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource SliderTrackFillPointerOver}" />
                            </ObjectAnimationUsingKeyFrames>
                            <ObjectAnimationUsingKeyFrames Storyboard.TargetName="HorizontalThumb" Storyboard.TargetProperty="Background">
                                <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource SliderThumbBackgroundPointerOver}" />
                            </ObjectAnimationUsingKeyFrames>
                            <ObjectAnimationUsingKeyFrames Storyboard.TargetName="VerticalThumb" Storyboard.TargetProperty="Background">
                                <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource SliderThumbBackgroundPointerOver}" />
                            </ObjectAnimationUsingKeyFrames>
                            <ObjectAnimationUsingKeyFrames Storyboard.TargetName="SliderContainer" Storyboard.TargetProperty="Background">
                                <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource SliderContainerBackgroundPointerOver}" />
                            </ObjectAnimationUsingKeyFrames>
                            <ObjectAnimationUsingKeyFrames Storyboard.TargetName="HorizontalDecreaseRect" Storyboard.TargetProperty="Fill">
                                <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource SliderTrackValueFillPointerOver}" />
                            </ObjectAnimationUsingKeyFrames>
                            <ObjectAnimationUsingKeyFrames Storyboard.TargetName="VerticalDecreaseRect" Storyboard.TargetProperty="Fill">
                                <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource SliderTrackValueFillPointerOver}" />
                            </ObjectAnimationUsingKeyFrames>
                        </Storyboard>
                    </VisualState>
                </VisualStateGroup>
                <VisualStateGroup x:Name="FocusEngagementStates">
                    <VisualState x:Name="FocusDisengaged" />
                    <VisualState x:Name="FocusEngagedHorizontal">
                        <Storyboard>
                            <ObjectAnimationUsingKeyFrames Storyboard.TargetName="SliderContainer" Storyboard.TargetProperty="(Control.IsTemplateFocusTarget)">
                                <DiscreteObjectKeyFrame KeyTime="0" Value="False" />
                            </ObjectAnimationUsingKeyFrames>
                            <ObjectAnimationUsingKeyFrames Storyboard.TargetName="HorizontalThumb" Storyboard.TargetProperty="(Control.IsTemplateFocusTarget)">
                                <DiscreteObjectKeyFrame KeyTime="0" Value="True" />
                            </ObjectAnimationUsingKeyFrames>
                        </Storyboard>
                    </VisualState>
                    <VisualState x:Name="FocusEngagedVertical">
                        <Storyboard>
                            <ObjectAnimationUsingKeyFrames Storyboard.TargetName="SliderContainer" Storyboard.TargetProperty="(Control.IsTemplateFocusTarget)">
                                <DiscreteObjectKeyFrame KeyTime="0" Value="False" />
                            </ObjectAnimationUsingKeyFrames>
                            <ObjectAnimationUsingKeyFrames Storyboard.TargetName="VerticalThumb" Storyboard.TargetProperty="(Control.IsTemplateFocusTarget)">
                                <DiscreteObjectKeyFrame KeyTime="0" Value="True" />
                            </ObjectAnimationUsingKeyFrames>
                        </Storyboard>
                    </VisualState>
                </VisualStateGroup>
            </VisualStateManager.VisualStateGroups>
            <ContentPresenter x:Name="HeaderContentPresenter"
                        x:DeferLoadStrategy="Lazy"
                        Visibility="Collapsed"
                        Foreground="{ThemeResource SliderHeaderForeground}"
                        Margin="{ThemeResource SliderHeaderThemeMargin}"
                        Content="{TemplateBinding Header}"
                        ContentTemplate="{TemplateBinding HeaderTemplate}"
                        FontWeight="{ThemeResource SliderHeaderThemeFontWeight}"
                        TextWrapping="Wrap" />
            <Grid x:Name="SliderContainer"
                        Background="{ThemeResource SliderContainerBackground}"
                        Grid.Row="1"
                        Control.IsTemplateFocusTarget="True">
                <Grid x:Name="HorizontalTemplate" MinHeight="44">
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="Auto" />
                        <ColumnDefinition Width="Auto" />
                        <ColumnDefinition Width="*" />
                    </Grid.ColumnDefinitions>
                    <Grid.RowDefinitions>
                        <RowDefinition Height="18" />
                        <RowDefinition Height="Auto" />
                        <RowDefinition Height="18" />
                    </Grid.RowDefinitions>
                    <Rectangle x:Name="HorizontalTrackRect"
                                Fill="{TemplateBinding Background}"
                                Height="{ThemeResource SliderTrackThemeHeight}"
                                Grid.Row="1"
                                Grid.ColumnSpan="3" />
                    <Rectangle x:Name="HorizontalDecreaseRect" Fill="{TemplateBinding Foreground}" Grid.Row="1" />
                    <TickBar x:Name="TopTickBar"
                                Visibility="Collapsed"
                                Fill="{ThemeResource SliderTickBarFill}"
                                Height="{ThemeResource SliderOutsideTickBarThemeHeight}"
                                VerticalAlignment="Bottom"
                                Margin="0,0,0,4"
                                Grid.ColumnSpan="3" />
                    <TickBar x:Name="HorizontalInlineTickBar"
                                Visibility="Collapsed"
                                Fill="{ThemeResource SliderInlineTickBarFill}"
                                Height="{ThemeResource SliderTrackThemeHeight}"
                                Grid.Row="1"
                                Grid.ColumnSpan="3" />
                    <TickBar x:Name="BottomTickBar"
                                Visibility="Collapsed"
                                Fill="{ThemeResource SliderTickBarFill}"
                                Height="{ThemeResource SliderOutsideTickBarThemeHeight}"
                                VerticalAlignment="Top"
                                Margin="0,4,0,0"
                                Grid.Row="2"
                                Grid.ColumnSpan="3" />
                    <Thumb x:Name="HorizontalThumb"
                                Style="{StaticResource SliderThumbStyle}"
                                DataContext="{TemplateBinding Value}"
                                Height="24"
                                Width="8"
                                Grid.Row="0"
                                Grid.RowSpan="3"
                                Grid.Column="1"
                                FocusVisualMargin="-14,-6,-14,-6"
                                AutomationProperties.AccessibilityView="Raw" />
                </Grid>
                <Grid x:Name="VerticalTemplate" MinWidth="44" Visibility="Collapsed">
                    <Grid.RowDefinitions>
                        <RowDefinition Height="*" />
                        <RowDefinition Height="Auto" />
                        <RowDefinition Height="Auto" />
                    </Grid.RowDefinitions>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="18" />
                        <ColumnDefinition Width="Auto" />
                        <ColumnDefinition Width="18" />
                    </Grid.ColumnDefinitions>
                    <Rectangle x:Name="VerticalTrackRect"
                                Fill="{TemplateBinding Background}"
                                Width="{ThemeResource SliderTrackThemeHeight}"
                                Grid.Column="1"
                                Grid.RowSpan="3" />
                    <Rectangle x:Name="VerticalDecreaseRect"
                                Fill="{TemplateBinding Foreground}"
                                Grid.Column="1"
                                Grid.Row="2" />
                    <TickBar x:Name="LeftTickBar"
                                Visibility="Collapsed"
                                Fill="{ThemeResource SliderTickBarFill}"
                                Width="{ThemeResource SliderOutsideTickBarThemeHeight}"
                                HorizontalAlignment="Right"
                                Margin="0,0,4,0"
                                Grid.RowSpan="3" />
                    <TickBar x:Name="VerticalInlineTickBar"
                                Visibility="Collapsed"
                                Fill="{ThemeResource SliderInlineTickBarFill}"
                                Width="{ThemeResource SliderTrackThemeHeight}"
                                Grid.Column="1"
                                Grid.RowSpan="3" />
                    <TickBar x:Name="RightTickBar"
                                Visibility="Collapsed"
                                Fill="{ThemeResource SliderTickBarFill}"
                                Width="{ThemeResource SliderOutsideTickBarThemeHeight}"
                                HorizontalAlignment="Left"
                                Margin="4,0,0,0"
                                Grid.Column="2"
                                Grid.RowSpan="3" />
                    <Thumb x:Name="VerticalThumb"
                                Style="{StaticResource SliderThumbStyle}"
                                DataContext="{TemplateBinding Value}"
                                Width="24"
                                Height="8"
                                Grid.Row="1"
                                Grid.Column="0"
                                Grid.ColumnSpan="3"
                                FocusVisualMargin="-6,-14,-6,-14"
                                AutomationProperties.AccessibilityView="Raw" />
                </Grid>
            </Grid>
        </Grid>
    </ControlTemplate>
    ```

    <span data-ttu-id="23052-223">長い XAML ですね。</span><span class="sxs-lookup"><span data-stu-id="23052-223">Wow, that's a lot of XAML!</span></span> <span data-ttu-id="23052-224">コントロール テンプレートは強力な機能ですが、かなり複雑であるため、通常は、既定のテンプレートから開始することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="23052-224">Control templates are a powerful feature, but they can be quite complex, which is why it's usually a good idea to start from the default template.</span></span> 
    
3. <span data-ttu-id="23052-225">追加した **ControlTemplate** 内で、**HorizontalTemplate** という名前のグリッド コントロールを見つけます。</span><span class="sxs-lookup"><span data-stu-id="23052-225">Within the **ControlTemplate** you just added, find the grid control named **HorizontalTemplate**.</span></span> <span data-ttu-id="23052-226">このグリッドは、変更するテンプレートの部分を定義します。</span><span class="sxs-lookup"><span data-stu-id="23052-226">This grid defines the portion of the template that we want to change.</span></span>

    ```XAML
    <Grid x:Name="HorizontalTemplate" MinHeight="44">
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="Auto" />
            <ColumnDefinition Width="Auto" />
            <ColumnDefinition Width="*" />
        </Grid.ColumnDefinitions>
        <Grid.RowDefinitions>
            <RowDefinition Height="18" />
            <RowDefinition Height="Auto" />
            <RowDefinition Height="18" />
        </Grid.RowDefinitions>
    ```

5.  <span data-ttu-id="23052-227">パート 1 で露出スライダー用に作成した多角形と同様の多角形を作成します。</span><span class="sxs-lookup"><span data-stu-id="23052-227">Create a polygon that's just like the polygon you created for the exposure slider in Part 1.</span></span> <span data-ttu-id="23052-228">**Grid.RowDefinitions** の終了タグの後に、多角形を追加します。</span><span class="sxs-lookup"><span data-stu-id="23052-228">Add the polygon after the closing **Grid.RowDefinitions** tag.</span></span> <span data-ttu-id="23052-229">**Grid.Row** を "0"、**Grid.RowSpan** を "3"、**Grid.ColumnSpan** を "3" に設定します。</span><span class="sxs-lookup"><span data-stu-id="23052-229">Set **Grid.Row** to "0", **Grid.RowSpan** to "3", and **Grid.ColumnSpan** to "3".</span></span> 

    **<span data-ttu-id="23052-230">変更前</span><span class="sxs-lookup"><span data-stu-id="23052-230">Before</span></span>**
    ```XAML
    <Grid x:Name="HorizontalTemplate" MinHeight="44">
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="Auto" />
            <ColumnDefinition Width="Auto" />
            <ColumnDefinition Width="*" />
        </Grid.ColumnDefinitions>
        <Grid.RowDefinitions>
            <RowDefinition Height="18" />
            <RowDefinition Height="Auto" />
            <RowDefinition Height="18" />
        </Grid.RowDefinitions>        
    ```

    **<span data-ttu-id="23052-231">変更後</span><span class="sxs-lookup"><span data-stu-id="23052-231">After</span></span>**
    ```XAML
    <Grid x:Name="HorizontalTemplate" MinHeight="44">
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="Auto" />
            <ColumnDefinition Width="Auto" />
            <ColumnDefinition Width="*" />
        </Grid.ColumnDefinitions>
        <Grid.RowDefinitions>
            <RowDefinition Height="18" />
            <RowDefinition Height="Auto" />
            <RowDefinition Height="18" />
        </Grid.RowDefinitions>
        <Polygon Grid.Row="0" Grid.RowSpan="3"  Grid.ColumnSpan="3" Stretch="Fill"
                    Points="0,20 200,20 200,0" HorizontalAlignment="Stretch"  
                    VerticalAlignment="Center" Height="20" >
            <Polygon.Fill>
                <LinearGradientBrush StartPoint="0,0.5" EndPoint="1,0.5">
                    <LinearGradientBrush.GradientStops>
                        <GradientStop Offset="0" Color="Black" />
                        <GradientStop Offset="1" Color="White" />
                    </LinearGradientBrush.GradientStops>
                </LinearGradientBrush>
            </Polygon.Fill>
        </Polygon>           
    ```

6. <span data-ttu-id="23052-232">**Polygon.Fill** 設定を削除します。</span><span class="sxs-lookup"><span data-stu-id="23052-232">Remove the **Polygon.Fill** setting.</span></span> <span data-ttu-id="23052-233">**Fill** を "{TemplateBinding Background}" に設定します。</span><span class="sxs-lookup"><span data-stu-id="23052-233">Set **Fill** to "{TemplateBinding Background}".</span></span> <span data-ttu-id="23052-234">これにより、スライダーの **Background** プロパティを設定すると、多角形の **Fill** プロパティが設定されるようになります。</span><span class="sxs-lookup"><span data-stu-id="23052-234">This makes it so that setting the **Background** property of the slider sets the **Fill** property of the polygon.</span></span> 

    **<span data-ttu-id="23052-235">変更前</span><span class="sxs-lookup"><span data-stu-id="23052-235">Before</span></span>**
    ```XAML
        <Polygon Grid.Row="0" Grid.RowSpan="3"  Grid.ColumnSpan="3" Stretch="Fill"
                    Points="0,20 200,20 200,0" HorizontalAlignment="Stretch"  
                    VerticalAlignment="Center" Height="20" >
            <Polygon.Fill>
                <LinearGradientBrush StartPoint="0,0.5" EndPoint="1,0.5">
                    <LinearGradientBrush.GradientStops>
                        <GradientStop Offset="0" Color="Black" />
                        <GradientStop Offset="1" Color="White" />
                    </LinearGradientBrush.GradientStops>
                </LinearGradientBrush>
            </Polygon.Fill>
        </Polygon>           
    ```
    
    **<span data-ttu-id="23052-236">変更後</span><span class="sxs-lookup"><span data-stu-id="23052-236">After</span></span>**
    ```XAML
        <Polygon Grid.Row="0" Grid.RowSpan="3"  Grid.ColumnSpan="3" Stretch="Fill"
                    Points="0,20 200,20 200,0" HorizontalAlignment="Stretch"  
                    VerticalAlignment="Center" Height="20" 
                    Fill="{TemplateBinding Background}">
        </Polygon>           
    ```    

7. <span data-ttu-id="23052-237">作成した多角形の直後に、**HorizontalTrackRect** という名前の四角形があります。</span><span class="sxs-lookup"><span data-stu-id="23052-237">Just after the polygon you added, there's a rectangle named **HorizontalTrackRect**.</span></span> <span data-ttu-id="23052-238">四角形が表示されて多角形図形を遮ることのないように、Rectangle の **Fill** 設定を削除します </span><span class="sxs-lookup"><span data-stu-id="23052-238">Remove the Rectangle's **Fill** setting so that the rectangle won't be visible and won't block our polygon shape.</span></span> <span data-ttu-id="23052-239">(四角形は、コントロール テンプレートでホバーなどの対話操作用ビジュアル項目としても使用されるため、完全には削除しません)。</span><span class="sxs-lookup"><span data-stu-id="23052-239">(We don't want to completely remove the rectangle because the control template also uses it for interaction visuals, such as hover.)</span></span>

    **<span data-ttu-id="23052-240">変更前</span><span class="sxs-lookup"><span data-stu-id="23052-240">Before</span></span>**
    ```XAML
        <Rectangle x:Name="HorizontalTrackRect"
                    Fill="{TemplateBinding Background}"
                    Height="{ThemeResource SliderTrackThemeHeight}"
                    Grid.Row="1"
                    Grid.ColumnSpan="3" />          
    ```
    
    **<span data-ttu-id="23052-241">変更後</span><span class="sxs-lookup"><span data-stu-id="23052-241">After</span></span>**
    ```XAML
        <Rectangle x:Name="HorizontalTrackRect"
                    Height="{ThemeResource SliderTrackThemeHeight}"
                    Grid.Row="1"
                    Grid.ColumnSpan="3" />
    ```

    <span data-ttu-id="23052-242">これで、テンプレートに対する作業が完了しました。</span><span class="sxs-lookup"><span data-stu-id="23052-242">You're done with the template!</span></span> <span data-ttu-id="23052-243">次は、これをスライダーに適用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="23052-243">Now we need to apply it to our sliders.</span></span> 
    
8. <span data-ttu-id="23052-244">露出スライダーを更新しましょう。</span><span class="sxs-lookup"><span data-stu-id="23052-244">Let's update our exposure slider.</span></span>

    * <span data-ttu-id="23052-245">スライダーの **Template** プロパティを "{StaticResource FancySliderControlTemplate}" に設定します。</span><span class="sxs-lookup"><span data-stu-id="23052-245">Set the slider's **Template** property to "{StaticResource FancySliderControlTemplate}".</span></span>
    * <span data-ttu-id="23052-246">スライダーの Background="Transparent" 設定を削除します。</span><span class="sxs-lookup"><span data-stu-id="23052-246">Remove the slider's Background="Transparent" setting.</span></span> 
    * <span data-ttu-id="23052-247">スライダーの Background を、黒から白への線形グラデーションに設定します。</span><span class="sxs-lookup"><span data-stu-id="23052-247">Set the slider's Background to a linear gradient that transitions from black to white.</span></span>
    * <span data-ttu-id="23052-248">パート 1 で作成した背景の多角形を削除します。</span><span class="sxs-lookup"><span data-stu-id="23052-248">Remove the background polygon we created in Part 1.</span></span>
        
    **<span data-ttu-id="23052-249">変更前</span><span class="sxs-lookup"><span data-stu-id="23052-249">Before</span></span>**
    ```XAML
    <Polygon Grid.Row="2" Stretch="Fill"
                Points="0,20 200,20 200,0" HorizontalAlignment="Stretch"  
                VerticalAlignment="Center" Height="20">
        <Polygon.Fill>
            <LinearGradientBrush StartPoint="0,0.5" EndPoint="1,0.5">
                <LinearGradientBrush.GradientStops>
                    <GradientStop Offset="0" Color="Black" />
                    <GradientStop Offset="1" Color="White" />
                </LinearGradientBrush.GradientStops>
            </LinearGradientBrush>
        </Polygon.Fill>
    </Polygon>
    <Slider Header="Exposure" 
            Grid.Row="2" Background="Transparent" Foreground="Transparent"
            Value="{x:Bind item.Exposure, Mode=TwoWay}"
            Minimum="-2"
            Maximum="2"
            Template="{StaticResource FancySliderControlTemplate}"/>    
    ```
    
    **<span data-ttu-id="23052-250">変更後</span><span class="sxs-lookup"><span data-stu-id="23052-250">After</span></span>**
    ```XAML
    <Slider Header="Exposure" 
            Grid.Row="2"  Foreground="Transparent"
            Value="{x:Bind item.Exposure, Mode=TwoWay}"
            Minimum="-2"
            Maximum="2"
            Template="{StaticResource FancySliderControlTemplate}">
        <Slider.Background>
            <LinearGradientBrush StartPoint="0,0.5" EndPoint="1,0.5">
                <LinearGradientBrush.GradientStops>
                    <GradientStop Offset="0" Color="Black" />
                    <GradientStop Offset="1" Color="White" />
                </LinearGradientBrush.GradientStops>
            </LinearGradientBrush>
        </Slider.Background>
    </Slider>
    ```        
9. <span data-ttu-id="23052-251">色温度スライダーにも、同じ更新を行います。</span><span class="sxs-lookup"><span data-stu-id="23052-251">Make the same updates to the temperature slider.</span></span>

    **<span data-ttu-id="23052-252">変更前</span><span class="sxs-lookup"><span data-stu-id="23052-252">Before</span></span>**
    ```XAML
    <Polygon Grid.Row="3" Stretch="Fill"
                Points="0,20 200,20 200,0" HorizontalAlignment="Stretch"  
                VerticalAlignment="Center" Height="20">
        <Polygon.Fill>
            <LinearGradientBrush StartPoint="0,0.5" EndPoint="1,0.5">
                <LinearGradientBrush.GradientStops>
                    <GradientStop Offset="0" Color="Blue" />
                    <GradientStop Offset="1" Color="Yellow" />
                </LinearGradientBrush.GradientStops>
            </LinearGradientBrush>
        </Polygon.Fill>
    </Polygon>
    <Slider Header="Temperature"
            Grid.Row="3" Background="Transparent" Foreground="Transparent"
            Value="{x:Bind item.Temperature, Mode=TwoWay}"
            Minimum="-1"
            Maximum="1" />
    ```
    
    **<span data-ttu-id="23052-253">変更後</span><span class="sxs-lookup"><span data-stu-id="23052-253">After</span></span>**
    ```XAML
    <Slider Header="Temperature"
            Grid.Row="3" Foreground="Transparent"
            Value="{x:Bind item.Temperature, Mode=TwoWay}"
            Minimum="-1"
            Maximum="1"
            Template="{StaticResource FancySliderControlTemplate}">
        <Slider.Background>
            <LinearGradientBrush StartPoint="0,0.5" EndPoint="1,0.5">
                <LinearGradientBrush.GradientStops>
                    <GradientStop Offset="0" Color="Blue" />
                    <GradientStop Offset="1" Color="Yellow" />
                </LinearGradientBrush.GradientStops>
            </LinearGradientBrush>
        </Slider.Background>
    </Slider>
    ```    

10. <span data-ttu-id="23052-254">ティント スライダーにも、同じ更新を行います。</span><span class="sxs-lookup"><span data-stu-id="23052-254">Make the same updates to the tint slider.</span></span>

    **<span data-ttu-id="23052-255">変更前</span><span class="sxs-lookup"><span data-stu-id="23052-255">Before</span></span>**
    ```XAML
    <Polygon Grid.Row="4" Stretch="Fill"
                Points="0,20 200,20 200,0" HorizontalAlignment="Stretch"  
                VerticalAlignment="Center" Height="20">
        <Polygon.Fill>
            <LinearGradientBrush StartPoint="0,0.5" EndPoint="1,0.5">
                <LinearGradientBrush.GradientStops>
                    <GradientStop Offset="0" Color="Red" />
                    <GradientStop Offset="1" Color="Green" />
                </LinearGradientBrush.GradientStops>
            </LinearGradientBrush>
        </Polygon.Fill>
    </Polygon>
    <Slider Header="Tint"
            Grid.Row="4" Background="Transparent" Foreground="Transparent"
            Value="{x:Bind item.Tint, Mode=TwoWay}"
            Minimum="-1"
            Maximum="1" />
    ```
    
    **<span data-ttu-id="23052-256">変更後</span><span class="sxs-lookup"><span data-stu-id="23052-256">After</span></span>**
    ```XAML
    <Slider Header="Tint"
            Grid.Row="4" Foreground="Transparent"
            Value="{x:Bind item.Tint, Mode=TwoWay}"
            Minimum="-1"
            Maximum="1"
            Template="{StaticResource FancySliderControlTemplate}">
        <Slider.Background>
            <LinearGradientBrush StartPoint="0,0.5" EndPoint="1,0.5">
                <LinearGradientBrush.GradientStops>
                    <GradientStop Offset="0" Color="Red" />
                    <GradientStop Offset="1" Color="Green" />
                </LinearGradientBrush.GradientStops>
            </LinearGradientBrush>
        </Slider.Background>
    </Slider>
    ```        

11. <span data-ttu-id="23052-257">アプリをコンパイルして実行します。</span><span class="sxs-lookup"><span data-stu-id="23052-257">Compile and run the app.</span></span> 

    ![世界一のスライダー](../basics/images/xaml-basics/style-sliders-templates.png)
    
    <span data-ttu-id="23052-259">ここで行った更新により、多角形の配置が改善されました。多角形の下端がスライダーのつまみの下端と揃っています。</span><span class="sxs-lookup"><span data-stu-id="23052-259">As you can see, our updates improved the positioning of the polygon; now the bottom of the polygon is aligned to the bottom of the slider thumb.</span></span>
    
<!-- TODO correct folder -->
<span data-ttu-id="23052-260">これで、チュートリアルは終わりです。</span><span class="sxs-lookup"><span data-stu-id="23052-260">Congratulations, you've finished the tutorial!</span></span> <span data-ttu-id="23052-261">行き詰った場合や最終的なソリューションを確認したい場合は、完成したサンプル コードが [UWP アプリ サンプル リポジトリ](https://github.com/Microsoft/Windows-universal-samples)にあります。</span><span class="sxs-lookup"><span data-stu-id="23052-261">If you got stuck and want to see the final solution, you can find the complete sample in the [UWP app sample repository](https://github.com/Microsoft/Windows-universal-samples).</span></span>