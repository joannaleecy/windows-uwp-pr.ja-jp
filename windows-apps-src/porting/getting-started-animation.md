---
author: stevewhims
title: アニメーションを始める
ms.assetid: C1C3F5EA-B775-4700-9C45-695E78C16205
description: このプロジェクトでは、四角形を移動し、フェード効果を適用した後でもう一度表示します。
ms.author: stwhi
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 4822a436225bea92fdf1e981ad33378996adefe4
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/01/2018
ms.locfileid: "5920443"
---
# <a name="getting-started-animation"></a><span data-ttu-id="368ba-104">はじめに: アニメーション</span><span class="sxs-lookup"><span data-stu-id="368ba-104">Getting started: Animation</span></span>


## <a name="adding-animations"></a><span data-ttu-id="368ba-105">アニメーションの追加</span><span class="sxs-lookup"><span data-stu-id="368ba-105">Adding animations</span></span>

<span data-ttu-id="368ba-106">iOS では、ほとんどの場合、アニメーション効果はプログラムで実現されます。</span><span class="sxs-lookup"><span data-stu-id="368ba-106">In iOS, you most often create animation effects programmatically.</span></span> <span data-ttu-id="368ba-107">たとえば、このための方法として、ブロック ベースの **UIView** クラスの **animateWithDuration** メソッド、または以前の非ブロック ベースのメソッドによって提供されるアニメーションを使うことができます。</span><span class="sxs-lookup"><span data-stu-id="368ba-107">For example, you might use animations provided by the block-based **UIView** class's **animateWithDuration** methods, or the older non-block based methods.</span></span> <span data-ttu-id="368ba-108">または、**CALayer** クラスを明示的に使ってレイヤーをアニメーション化することもできます。</span><span class="sxs-lookup"><span data-stu-id="368ba-108">Or, you might explicitly use the **CALayer** class to animate layers.</span></span> <span data-ttu-id="368ba-109">Windows アプリでのアニメーションもプログラムで作成できますが、Extensible Application Markup Language (XAML) を使った宣言で定義することもできます。</span><span class="sxs-lookup"><span data-stu-id="368ba-109">Animations in Windows apps can be created programmatically, but they can also be defined declaratively with Extensible Application Markup Language (XAML).</span></span> <span data-ttu-id="368ba-110">Microsoft Visual Studio を使用して XAML コードを直接編集できますが、Visual Studio にはユーザーがデザイナーでアニメーションを扱っているときに XAML コードを自動的に作成する、**Blend** というツールも付属しています。</span><span class="sxs-lookup"><span data-stu-id="368ba-110">You can use Microsoft Visual Studio to edit XAML code directly, but Visual Studio also comes with a tool called **Blend**, which creates XAML code for you as you work with animations in a designer.</span></span> <span data-ttu-id="368ba-111">実際、Blend では、グラフィック表示で、完全な Visual Studio プロジェクトを開いて、設計、ビルド、実行できます。</span><span class="sxs-lookup"><span data-stu-id="368ba-111">In fact, Blend allows you to open, design, build, and run complete Visual Studio projects, graphically.</span></span> <span data-ttu-id="368ba-112">以下のチュートリアルを実行して、実際に試してみてください。</span><span class="sxs-lookup"><span data-stu-id="368ba-112">The following walkthrough lets you try this out.</span></span>

<span data-ttu-id="368ba-113">新しいユニバーサル Windows プラットフォーム (UWP) アプリを作成し、"SimpleAnimation" のような名前を付けてください。</span><span class="sxs-lookup"><span data-stu-id="368ba-113">Create a new Universal Windows Platform (UWP) app and name it something like "SimpleAnimation".</span></span> <span data-ttu-id="368ba-114">このプロジェクトでは、四角形を移動し、フェード効果を適用した後でもう一度表示します。</span><span class="sxs-lookup"><span data-stu-id="368ba-114">In this project, we're going to move a rectangle, apply a fade effect, and then bring it back into view.</span></span> <span data-ttu-id="368ba-115">XAML のアニメーションは、*ストーリーボード*の概念に基づいています (iOS のストーリーボードではありません)。</span><span class="sxs-lookup"><span data-stu-id="368ba-115">Animations in XAML are based on the concept of *storyboards* (not to be confused with iOS storyboards).</span></span> <span data-ttu-id="368ba-116">ストーリーボードでは、*キーフレーム*を使って、プロパティの変更をアニメーション化します。</span><span class="sxs-lookup"><span data-stu-id="368ba-116">Storyboards use *keyframes* to animate property changes.</span></span>

<span data-ttu-id="368ba-117">次の図に示すように、プロジェクトを開いた状態で、**ソリューション エクスプローラー**で、プロジェクトの名前を右クリックし、**[Blend で開く]** または **[Blend でデザイン]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="368ba-117">With your project open, in **Solution Explorer**, right-click the project's name and then select **Open in Blend** or **Design in Blend**, as shown in the following figure.</span></span> <span data-ttu-id="368ba-118">Visual Studio は、バックグラウンドで実行を続けます。</span><span class="sxs-lookup"><span data-stu-id="368ba-118">Visual Studio continues to run in the background.</span></span>

![[Blend で開く] メニュー コマンド](images/ios-to-uwp/vs-open-in-blend.png)

<span data-ttu-id="368ba-120">Blend が起動されると、次の図のような画面が表示されます。</span><span class="sxs-lookup"><span data-stu-id="368ba-120">After Blend starts, you should see something similar to the following figure.</span></span>

![Blend の開発環境](images/ios-to-uwp/blend-1.png)

<span data-ttu-id="368ba-122">**ソリューション エクスプローラー**で画面左側にある **[MainPage.xaml]** をダブルクリックします。</span><span class="sxs-lookup"><span data-stu-id="368ba-122">Double-click on **MainPage.xaml** in the **Solution Explorer** on the left hand side.</span></span> <span data-ttu-id="368ba-123">次に、中央の**デザイン ビュー**の端にあるツールの垂直方向のストリップから**四角形**ツールを選択し、次の図に示すように、**デザイン ビュー**で四角形を描画します。</span><span class="sxs-lookup"><span data-stu-id="368ba-123">Next, from the vertical strip of tools on the edge of the central **Design View**, select the **Rectangle** tool, and then draw a rectangle in **Design View**, as shown in the following figure.</span></span>

![デザイン ビューへの四角形の追加](images/ios-to-uwp/blend-2.png)

<span data-ttu-id="368ba-125">四角形を緑色で塗るために、**[プロパティ]** ウィンドウの **[ブラシ]** 領域で、**[単色ブラシ]** ボタンをクリックします。次に、**[色スポイト]** アイコンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="368ba-125">To make the rectangle green, look in the **Properties** window, and in the **Brush** area, click on the **Solid color brush** button, and then click the **Color eyedropper** icon.</span></span> <span data-ttu-id="368ba-126">色合いが緑色の任意の部分をクリックします。</span><span class="sxs-lookup"><span data-stu-id="368ba-126">Click somewhere in the green band of hues.</span></span>

<span data-ttu-id="368ba-127">四角形のアニメーション化を開始するために、次の図に示すように、**[オブジェクトとタイムライン]** ウィンドウで、プラス記号 (**[新規作成]**) ボタンをタップし、**[OK]** をタップします。</span><span class="sxs-lookup"><span data-stu-id="368ba-127">To begin animating the rectangle, in the **Objects and Timeline** window, tap the plus symbol (**New**) button as shown in the following figure, and then tap **OK**.</span></span>

![ストーリーボードの追加](images/ios-to-uwp/blend-3.png)

<span data-ttu-id="368ba-129">**[オブジェクトとタイムライン]** ウィンドウにストーリーボードが表示されます (正しく表示するにはビューのサイズの変更が必要である可能性があります)。</span><span class="sxs-lookup"><span data-stu-id="368ba-129">A storyboard appears in the **Objects and Timeline** window (you may need to resize the view to see it properly).</span></span> <span data-ttu-id="368ba-130">**デザイン ビュー**が変化して、**Storyboard1 タイムラインの記録がオンである**ことが示されます。</span><span class="sxs-lookup"><span data-stu-id="368ba-130">The **Design View** display changes to show that **Storyboard1 timeline recording is on**.</span></span> <span data-ttu-id="368ba-131">四角形の現在の状態をキャプチャするために、次の図に示すように、**[オブジェクトとタイムライン]** ウィンドウで、黄色い矢印の上の **[キーフレームの記録]** ボタンをタップします。</span><span class="sxs-lookup"><span data-stu-id="368ba-131">To capture the current state of the rectangle, in the **Objects and Timeline** window, tap the **Record Keyframe** button just above the yellow arrow, as shown in the following figure.</span></span>

![キーフレームの記録](images/ios-to-uwp/blend-4.png)

<span data-ttu-id="368ba-133">次に、四角形を移動させながら徐々に非表示にします。</span><span class="sxs-lookup"><span data-stu-id="368ba-133">Now, let's move the rectangle and fade it away.</span></span> <span data-ttu-id="368ba-134">そのためには、オレンジ色/黄色の矢印を 2 秒の位置にドラッグし、緑色の四角形を右方向へ少し移動します。</span><span class="sxs-lookup"><span data-stu-id="368ba-134">To do this, drag the orange/yellow arrow to the 2-second position, and then move your green rectangle slightly to the right.</span></span> <span data-ttu-id="368ba-135">次に、次の図に示すように、**[プロパティ]** ウィンドウの **[外観]** 領域で、**[Opacity]** (不透明度) プロパティを **0** に変更します。</span><span class="sxs-lookup"><span data-stu-id="368ba-135">Then, in the **Properties** window, in the **Appearance** area, change the **Opacity** property to **0**, as shown in the following figure.</span></span> <span data-ttu-id="368ba-136">アニメーションをプレビューするために、ストーリーボード パネルの **[再生]** ボタンをタップします。</span><span class="sxs-lookup"><span data-stu-id="368ba-136">To preview the animation, tap the **Play** button in the Storyboard panel.</span></span>

![[プロパティ] ウィンドウと [再生] ボタン](images/ios-to-uwp/blend-5.png)

<span data-ttu-id="368ba-138">次に、四角形をもう一度表示します。</span><span class="sxs-lookup"><span data-stu-id="368ba-138">Next, let's bring the rectangle back into view.</span></span> <span data-ttu-id="368ba-139">**[オブジェクトとタイムライン]** ウィンドウで、**[Storyboard1]** をダブルクリックします。</span><span class="sxs-lookup"><span data-stu-id="368ba-139">In the **Objects and Timeline** window, double-click **Storyboard1**.</span></span> <span data-ttu-id="368ba-140">次に、次の図に示すように、**[プロパティ]** ウィンドウの **[共通]** 領域で、**[AutoReverse]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="368ba-140">Then, in the **Properties** window, in the **Common** area, select **AutoReverse**, as shown in the following figure.</span></span>

![ストーリーボードの選択](images/ios-to-uwp/blend-6.png)

<span data-ttu-id="368ba-142">最後に、**[再生]** ボタンをクリックして、動作を確かめます。</span><span class="sxs-lookup"><span data-stu-id="368ba-142">Finally, click on the **Play** button to see what happens.</span></span>

<span data-ttu-id="368ba-143">プロジェクトをビルドして実行するには、ウィンドウの上部にある緑色の [実行] ボタンをクリックします (または、単に F5 キーを押します)。</span><span class="sxs-lookup"><span data-stu-id="368ba-143">You can build and run the project by clicking on the green run button at the top of the window (or just press F5).</span></span> <span data-ttu-id="368ba-144">これを行った場合、プロジェクトのビルドと実行が実際に表示されますが、緑色の四角形はそのまま残ります。</span><span class="sxs-lookup"><span data-stu-id="368ba-144">If you do this, you'll see your project will indeed build and run, but the green rectangle will stubbornly sit perfectly still, like a toddler denied candy in a supermarket aisle.</span></span> <span data-ttu-id="368ba-145">アニメーションを開始するには、プロジェクトにコードを追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="368ba-145">To start the animation, you'll need to add a line of code to the project.</span></span> <span data-ttu-id="368ba-146">以下にその方法を示します。</span><span class="sxs-lookup"><span data-stu-id="368ba-146">Here's how.</span></span>

<span data-ttu-id="368ba-147">**[ファイル]** メニューを開き、**[MainPage.xaml の保存]** を選択して、プロジェクトを保存します。</span><span class="sxs-lookup"><span data-stu-id="368ba-147">Save the project, by opening the **File** menu, and selecting **Save MainPage.xaml**.</span></span> <span data-ttu-id="368ba-148">Visual Studio に戻ります。</span><span class="sxs-lookup"><span data-stu-id="368ba-148">Return to Visual Studio.</span></span> <span data-ttu-id="368ba-149">変更されたファイルを読み込み直すかどうかをたずねる Visual Studio のダイアログ ボックスが表示された場合は、**[はい]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="368ba-149">If Visual Studio displays a dialog box asking whether you want to reload the modified file, select **Yes**.</span></span> <span data-ttu-id="368ba-150">**MainPage.xaml** の下に隠れている **MainPage.xaml.cs** ファイルをダブルクリックして開き、次のコードを public MainPage() メソッドのすぐ上に追加します。</span><span class="sxs-lookup"><span data-stu-id="368ba-150">Double-click the **MainPage.xaml.cs** file, which is hidden under **MainPage.xaml**, to open it, and add the following code just above the public MainPage() method:</span></span>

```csharp
protected override void OnNavigatedTo(NavigationEventArgs e)
{
    // Add the following line of code.
    Storyboard1.Begin();
}
```

<span data-ttu-id="368ba-151">もう一度プロジェクトを実行して、四角形がアニメーション化されることを確かめます。</span><span class="sxs-lookup"><span data-stu-id="368ba-151">Run the project again, and watch the rectangle animate.</span></span> <span data-ttu-id="368ba-152">問題ないことを確認しました。</span><span class="sxs-lookup"><span data-stu-id="368ba-152">Hurrah!</span></span>

<span data-ttu-id="368ba-153">MainPage.xaml ファイルを **XAML** ビューで開くと、デザイナーで作業していたときに Blend によって自動的に追加された XAML コードを確認できます。</span><span class="sxs-lookup"><span data-stu-id="368ba-153">If you open the MainPage.xaml file, in **XAML** view, you'll see the XAML code that Blend added for you as you worked in the designer.</span></span> <span data-ttu-id="368ba-154">特に、`<Storyboard>` 要素と `<Rectangle>` 要素のコードに注目してください。</span><span class="sxs-lookup"><span data-stu-id="368ba-154">In particular, look at the code in the `<Storyboard>` and `<Rectangle>` elements.</span></span> <span data-ttu-id="368ba-155">次のコードに例を示します </span><span class="sxs-lookup"><span data-stu-id="368ba-155">The following code shows an example.</span></span> <span data-ttu-id="368ba-156">(省略記号は、わかりやすくするために無関係のコードを省略したことを示します。さらに、見やすくするために、改行が追加されています)。</span><span class="sxs-lookup"><span data-stu-id="368ba-156">Ellipses indicate unrelated code omitted for brevity, and line breaks have been added for code readability.)</span></span>

```xml
...
<Storyboard 
        x:Name="Storyboard1" 
        AutoReverse="True">
    <DoubleAnimationUsingKeyFrames 
            Storyboard.TargetProperty="(UIElement.RenderTransform).(CompositeTransform.TranslateX)"
            Storyboard.TargetName="rectangle">
        <EasingDoubleKeyFrame 
                KeyTime="0" 
                Value="0"/>
        <EasingDoubleKeyFrame 
                KeyTime="0:0:2" 
                Value="185.075"/>
    </DoubleAnimationUsingKeyFrames>
    <DoubleAnimationUsingKeyFrames 
            Storyboard.TargetProperty="(UIElement.RenderTransform).(CompositeTransform.TranslateY)" 
            Storyboard.TargetName="rectangle">
        <EasingDoubleKeyFrame 
                KeyTime="0" 
                Value="0"/>
        <EasingDoubleKeyFrame 
                KeyTime="0:0:2" 
                Value="2.985"/>
    </DoubleAnimationUsingKeyFrames>
    <DoubleAnimationUsingKeyFrames 
            Storyboard.TargetProperty="(UIElement.Opacity)" 
            Storyboard.TargetName="rectangle">
        <EasingDoubleKeyFrame 
                KeyTime="0" 
                Value="1"/>
        <EasingDoubleKeyFrame 
                KeyTime="0:0:2"
                Value="0"/>
    </DoubleAnimationUsingKeyFrames>
</Storyboard>
...
<Rectangle 
        x:Name="rectangle" 
        Fill="#FF00FF63" 
        HorizontalAlignment="Left" 
        Height="122" 
        Margin="151,312,0,0" 
        Stroke="Black" 
        VerticalAlignment="Top" 
        Width="239" 
        RenderTransformOrigin="0.5,0.5">
    <Rectangle.RenderTransform>
        <CompositeTransform/>
    </Rectangle.RenderTransform>
</Rectangle>
...
```

<span data-ttu-id="368ba-157">この XAML を手動で編集するか、または Blend に戻って操作を続行することができます。</span><span class="sxs-lookup"><span data-stu-id="368ba-157">You can edit this XAML manually, or return to Blend to continue working on it there.</span></span> <span data-ttu-id="368ba-158">Blend を使うと興味を引くユーザー インターフェイスを作成することが楽しくなり、グラフィカル ツールを使用してそれらをアニメーション化する機能によって開発時間を大幅に高速化することができます。</span><span class="sxs-lookup"><span data-stu-id="368ba-158">Blend makes it fun to create interesting user interfaces, and the ability to animate them using a graphical tool can dramatically speed up development time.</span></span> <span data-ttu-id="368ba-159">アニメーションについて詳しくは、「[アニメーションの概要](https://msdn.microsoft.com/library/windows/apps/mt187350)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="368ba-159">For more info about animations, see [Animations overview](https://msdn.microsoft.com/library/windows/apps/mt187350).</span></span>

<span data-ttu-id="368ba-160">**注:** <span class="legacy-term">JavaScript と HTML を使った UWP アプリ</span>のアニメーションについて詳しくは、[アニメーション化 UI (HTML)](https://msdn.microsoft.com/library/windows/apps/hh465165)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="368ba-160">**Note**For info about animations for <span class="legacy-term">UWP apps using JavaScript and HTML</span>, see [Animating your UI (HTML)](https://msdn.microsoft.com/library/windows/apps/hh465165).</span></span>

### <a name="next-step"></a><span data-ttu-id="368ba-161">次の手順</span><span class="sxs-lookup"><span data-stu-id="368ba-161">Next step</span></span>

[<span data-ttu-id="368ba-162">はじめに: 次の手順</span><span class="sxs-lookup"><span data-stu-id="368ba-162">Getting started: What next?</span></span>](getting-started-what-next.md)
