---
title: アニメーションを始める
ms.assetid: C1C3F5EA-B775-4700-9C45-695E78C16205
description: このプロジェクトでは、四角形を移動し、フェード効果を適用した後でもう一度表示します。
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: dc5e107fd343798698f5957c26d87a0d3ffe6625
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57608627"
---
# <a name="getting-started-animation"></a>はじめに。アニメーション


## <a name="adding-animations"></a>アニメーションの追加

iOS では、ほとんどの場合、アニメーション効果はプログラムで実現されます。 たとえば、このための方法として、ブロック ベースの **UIView** クラスの **animateWithDuration** メソッド、または以前の非ブロック ベースのメソッドによって提供されるアニメーションを使うことができます。 または、**CALayer** クラスを明示的に使ってレイヤーをアニメーション化することもできます。 Windows アプリでのアニメーションもプログラムで作成できますが、Extensible Application Markup Language (XAML) を使った宣言で定義することもできます。 Microsoft Visual Studio を使用して XAML コードを直接編集できますが、Visual Studio にはユーザーがデザイナーでアニメーションを扱っているときに XAML コードを自動的に作成する、**Blend** というツールも付属しています。 実際、Blend では、グラフィック表示で、完全な Visual Studio プロジェクトを開いて、設計、ビルド、実行できます。 以下のチュートリアルを実行して、実際に試してみてください。

新しいユニバーサル Windows プラットフォーム (UWP) アプリを作成し、"SimpleAnimation" のような名前を付けてください。 このプロジェクトでは、四角形を移動し、フェード効果を適用した後でもう一度表示します。 XAML のアニメーションは、*ストーリーボード*の概念に基づいています (iOS のストーリーボードではありません)。 ストーリーボードでは、*キーフレーム*を使って、プロパティの変更をアニメーション化します。

次の図に示すように、プロジェクトを開いた状態で、**ソリューション エクスプローラー**で、プロジェクトの名前を右クリックし、**[Blend で開く]** または **[Blend でデザイン]** を選択します。 Visual Studio は、バックグラウンドで実行を続けます。

![[Blend で開く] メニュー コマンド](images/ios-to-uwp/vs-open-in-blend.png)

Blend が起動されると、次の図のような画面が表示されます。

![Blend の開発環境](images/ios-to-uwp/blend-1.png)

**ソリューション エクスプローラー**で画面左側にある **[MainPage.xaml]** をダブルクリックします。 次に、中央の**デザイン ビュー**の端にあるツールの垂直方向のストリップから**四角形**ツールを選択し、次の図に示すように、**デザイン ビュー**で四角形を描画します。

![デザイン ビューへの四角形の追加](images/ios-to-uwp/blend-2.png)

四角形を緑色で塗るために、**[プロパティ]** ウィンドウの **[ブラシ]** 領域で、**[単色ブラシ]** ボタンをクリックします。次に、**[色スポイト]** アイコンをクリックします。 色合いが緑色の任意の部分をクリックします。

四角形のアニメーション化を開始するために、次の図に示すように、**[オブジェクトとタイムライン]** ウィンドウで、プラス記号 (**[新規作成]**) ボタンをタップし、**[OK]** をタップします。

![ストーリーボードの追加](images/ios-to-uwp/blend-3.png)

**[オブジェクトとタイムライン]** ウィンドウにストーリーボードが表示されます (正しく表示するにはビューのサイズの変更が必要である可能性があります)。 **デザイン ビュー**が変化して、**Storyboard1 タイムラインの記録がオンである**ことが示されます。 四角形の現在の状態をキャプチャするために、次の図に示すように、**[オブジェクトとタイムライン]** ウィンドウで、黄色い矢印の上の **[キーフレームの記録]** ボタンをタップします。

![キーフレームの記録](images/ios-to-uwp/blend-4.png)

次に、四角形を移動させながら徐々に非表示にします。 そのためには、オレンジ色/黄色の矢印を 2 秒の位置にドラッグし、緑色の四角形を右方向へ少し移動します。 次に、次の図に示すように、**[プロパティ]** ウィンドウの **[外観]** 領域で、**[Opacity]** (不透明度) プロパティを **0** に変更します。 アニメーションをプレビューするために、ストーリーボード パネルの **[再生]** ボタンをタップします。

![[プロパティ] ウィンドウと [再生] ボタン](images/ios-to-uwp/blend-5.png)

次に、四角形をもう一度表示します。 **[オブジェクトとタイムライン]** ウィンドウで、**[Storyboard1]** をダブルクリックします。 次に、次の図に示すように、**[プロパティ]** ウィンドウの **[共通]** 領域で、**[AutoReverse]** を選択します。

![ストーリーボードの選択](images/ios-to-uwp/blend-6.png)

最後に、**[再生]** ボタンをクリックして、動作を確かめます。

プロジェクトをビルドして実行するには、ウィンドウの上部にある緑色の [実行] ボタンをクリックします (または、単に F5 キーを押します)。 これを行った場合、プロジェクトのビルドと実行が実際に表示されますが、緑色の四角形はそのまま残ります。 アニメーションを開始するには、プロジェクトにコードを追加する必要があります。 以下にその方法を示します。

**[ファイル]** メニューを開き、**[MainPage.xaml の保存]** を選択して、プロジェクトを保存します。 Visual Studio に戻ります。 変更されたファイルを読み込み直すかどうかをたずねる Visual Studio のダイアログ ボックスが表示された場合は、**[はい]** を選択します。 **MainPage.xaml** の下に隠れている **MainPage.xaml.cs** ファイルをダブルクリックして開き、次のコードを public MainPage() メソッドのすぐ上に追加します。

```csharp
protected override void OnNavigatedTo(NavigationEventArgs e)
{
    // Add the following line of code.
    Storyboard1.Begin();
}
```

もう一度プロジェクトを実行して、四角形がアニメーション化されることを確かめます。 問題ないことを確認しました。

MainPage.xaml ファイルを **XAML** ビューで開くと、デザイナーで作業していたときに Blend によって自動的に追加された XAML コードを確認できます。 特に、`<Storyboard>` 要素と `<Rectangle>` 要素のコードに注目してください。 次のコードに例を示します  (省略記号は、わかりやすくするために無関係のコードを省略したことを示します。さらに、見やすくするために、改行が追加されています)。

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

この XAML を手動で編集するか、または Blend に戻って操作を続行することができます。 Blend を使うと興味を引くユーザー インターフェイスを作成することが楽しくなり、グラフィカル ツールを使用してそれらをアニメーション化する機能によって開発時間を大幅に高速化することができます。 アニメーションについて詳しくは、「[アニメーションの概要](https://msdn.microsoft.com/library/windows/apps/mt187350)」をご覧ください。

**注**  のアニメーションについて<span class="legacy-term">JavaScript と HTML を使った UWP アプリ</span>を参照してください[UI (HTML) をアニメーション化](https://msdn.microsoft.com/library/windows/apps/hh465165)します。

### <a name="next-step"></a>次の手順

[はじめに。次のステップ](getting-started-what-next.md)
