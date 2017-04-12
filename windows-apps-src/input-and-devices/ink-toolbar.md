---
author: Karl-Bridge-Microsoft
Description: "既定の InkToolbar をユニバーサル Windows プラットフォーム (UWP) 手書き入力アプリに追加し、カスタム ペン ボタンを InkToolbar に追加して、カスタム ペン ボタンをカスタム ペン定義にバインドします。"
title: "InkToolbar をユニバーサル Windows プラットフォーム (UWP) 手書き入力アプリに追加する"
label: Add an InkToolbar to a Universal Windows Platform (UWP) inking app
template: detail.hbs
keywords: "Windows Ink, Windows の手書き入力, DirectInk, InkPresenter, InkCanvas, InkToolbar, ユニバーサル Windows プラットフォーム, UWP, ユーザー操作, 入力"
ms.author: kbridge
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.assetid: d888f75f-c2a0-4134-81db-907b5e24fcc5
ms.openlocfilehash: dd307bd6d7551c1e95de29360a8601484b37e742
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="add-an-inktoolbar-to-a-universal-windows-platform-uwp-inking-app"></a>InkToolbar をユニバーサル Windows プラットフォーム (UWP) 手書き入力アプリに追加する
<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css">


ユニバーサル Windows プラットフォーム (UWP) アプリでの手書き入力を容易にする、[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inkcanvas.aspx) と [**InkToolbar**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbar.aspx) という 2 つのコントロールがあります。

[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inkcanvas.aspx) コントロールには、基本的な Windows Ink 機能が用意されています。 このコントロールを使用して、ペン入力をインク ストローク (色と太さの既定の設定を使う) か消去ストロークとしてレンダリングできます。

> InkCanvas の実装について詳しくは、「[UWP アプリのペン操作とスタイラス操作](pen-and-stylus-interactions.md)」をご覧ください。

InkCanvas は、完全に透明なオーバーレイであるため、インク ストロークのプロパティを設定するための UI は組み込まれていません。 既定の手書き入力エクスペリエンスを変更する場合、ユーザーがインク ストロークのプロパティを設定し、その他のカスタムの手書き入力機能を使用できるようにします。これには 2 つの方法があります。

- コード ビハインドで、InkCanvas にバインドされている、基になる [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/windows.ui.input.inking.inkpresenter.aspx) オブジェクトを使用します。

  InkPresenter API では、手書き入力エクスペリエンスのさまざまなカスタマイズをサポートしています。 詳しくは、「[UWP アプリのペン操作とスタイラス操作](pen-and-stylus-interactions.md)」をご覧ください。

- [**InkToolbar**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbar.aspx) を InkCanvas にバインドします。 既定では、InkToolbar には、インク機能をアクティブ化し、ストロークのサイズ、インクの色、ペン先の形状などのインクのプロパティを設定できる基本的な UI が用意されています。

  ここでは、InkToolbar について説明します。

<div class="important-apis" >
<b>重要な API</b><br/>
<ul>
<li>[**InkCanvas クラス**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inkcanvas.aspx)</li>
<li>[**InkToolbar クラス**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbar.aspx)</li>
<li>[**InkPresenter クラス**](https://msdn.microsoft.com/library/windows/apps/windows.ui.input.inking.inkpresenter.aspx)</li>
<li>[**Windows.UI.Input.Inking**](https://msdn.microsoft.com/library/windows/apps/br208524)</li>
</ul>
</div>

## <a name="default-inktoolbar"></a>既定の InkToolbar

既定では、InkToolbar には、描画、消去、強調表示、ルーラー表示のボタンが含まれています。 機能に応じて、インクの色、ストロークの太さ、すべてのインクの消去など、他の設定やコマンドがポップアップに表示されます。

![InkToolbar](.\images\ink\ink-tools-invoked-toolbar-small.png)  
*既定の Windows Ink ツール バー*

基本的な既定の InkToolbar を追加する方法は次のとおりです。
1. MainPage.xaml で、手書き入力面のコンテナー オブジェクト (ここでは Grid コントロールを使用します) を宣言します。
2. コンテナーの子として InkCanvas オブジェクトを宣言します  (InkCanvas サイズはコンテナーから継承されます)。
3. InkToolbar を宣言し、TargetInkCanvas 属性を使用して InkCanvas にバインドします。
  InkToolbar が InkCanvas の後で宣言されるようにします。 そうでなければ、InkCanvas オーバーレイで InkToolbar にアクセスできなくなります。

```xaml
<Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
    <Grid.RowDefinitions>
        <RowDefinition Height="Auto"/>
        <RowDefinition Height="*"/>
    </Grid.RowDefinitions>
    <StackPanel x:Name="HeaderPanel" Orientation="Horizontal" Grid.Row="0">
        <TextBlock x:Name="Header"
                   Text="Basic ink sample"
                   Style="{ThemeResource HeaderTextBlockStyle}"
                   Margin="10,0,0,0" />
    </StackPanel>
    <Grid Grid.Row="1">
        <Image Source="Assets\StoreLogo.png" />
        <InkCanvas x:Name="inkCanvas" />
        <InkToolbar x:Name="inkToolbar"
          VerticalAlignment="Top"
          TargetInkCanvas="{x:Bind inkCanvas}" />
    </Grid>
</Grid>
```

## <a name="basic-customization"></a>基本的なカスタマイズ

このセクションでは、Windows Ink ツール バーの基本的なカスタマイズに関するシナリオについて説明します。

### <a name="specify-the-selected-button"></a>選択されるボタンを指定する  
![初期化時に鉛筆ボタンが選択される](.\images\ink\ink-tools-default-toolbar.png)  
*Windows Ink ツール バーで初期化時に鉛筆ボタンが選択される*

既定では、アプリが起動し、ツール バーが初期化されると、最初 (または左端) のボタンが選択されます。 既定の Windows Ink ツール バーでは、ボールペン ボタンが選択されます。

フレームワークで組み込みのボタンの順序が定義されるため、最初のボタンが既定でアクティブ化したいペンやツールでない場合があります。

この既定の動作を上書きし、ツール バーで選択されるボタンを指定できます。

ここでは、(ボールペンではなく) 鉛筆ボタンが選択され、鉛筆がアクティブになるように、既定のツール バーを初期化します。

1. 前の例から、InkCanvas と InkToolbar の XAML 宣言を使用します。
2. コード ビハインドで、[InkToolbar](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbar.aspx) オブジェクトの [Loaded](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.frameworkelement.loaded.aspx) イベントのハンドラーを設定します。

  ```csharp
  /// <summary>
  /// An empty page that can be used on its own or navigated to within a Frame.
  /// Here, we set up InkToolbar event listeners.
  /// </summary>
  public MainPage_CodeBehind()
  {
      this.InitializeComponent();
      // Add handlers for InkToolbar events.
      inkToolbar.Loaded += inkToolbar_Loaded;
  }
  ```

3. [Loaded](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.frameworkelement.loaded.aspx) イベントのハンドラーで次の処理を行います。
  1. 組み込みの [InkToolbarPencilButton](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbarpencilbutton.aspx) への参照を取得します。

    [GetToolButton](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbar.gettoolbutton.aspx) メソッドで [InkToolbarTool.Pencil](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbartool.aspx) オブジェクトを渡すことで、[InkToolbarPencilButton](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbarpencilbutton.aspx) の [InkToolbarToolButton](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbartoolbutton.aspx) オブジェクトが返されます。

  2. 前の手順で返されたオブジェクトに [ActiveTool](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbar.activetool.aspx) を設定します。

```CSharp
/// <summary>
/// Handle the Loaded event of the InkToolbar.
/// By default, the active tool is set to the first tool on the toolbar.
/// Here, we set the active tool to the pencil button.
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
private void inkToolbar_Loaded(object sender, RoutedEventArgs e)
{
    InkToolbarToolButton pencilButton = inkToolbar.GetToolButton(InkToolbarTool.Pencil);
    inkToolbar.ActiveTool = pencilButton;
}
```

### <a name="specify-the-built-in-buttons"></a>組み込みのボタンを指定する

![初期化時に特定のボタンが含まれる](.\images\ink\ink-tools-specific.png)  
*初期化時に特定のボタンが含まれる*

既に説明したように、Windows Ink ツール バーには既定の組み込みボタンのコレクションが含まれます。 これらのボタンは次の順序で (左から右に) 表示されます。

- [InkToolbarBallpointPenButton](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbarballpointpenbutton.aspx)
- [InkToolbarPencilButton](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbarpencilbutton.aspx)
- [InkToolbarHighlighterButton](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbarhighlighterbutton.aspx)
- [InkToolbarEraserButton](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbareraserbutton.aspx)
- [InkToolbarRulerButton](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbarrulerbutton.aspx)

ここでは、組み込みのボールペン、鉛筆、および消しゴムのボタンのみ表示されるようにツール バーを初期化します。

これは、XAML またはコード ビハインドを使用して実行できます。

**XAML**

最初の例から、InkCanvas と InkToolbar の XAML 宣言を変更します。
- [InitialControls](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbar.initialcontrols.aspx) 属性を追加し、値を "[None](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbarinitialcontrols.aspx)" に設定します。 これで組み込みボタンの既定のコレクションがクリアされます。
- アプリで必要な特定の InkToolbar ボタンを追加します。 ここでは、[InkToolbarBallpointPenButton](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbarballpointpenbutton.aspx)、[InkToolbarPencilButton](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbarpencilbutton.aspx)、および [InkToolbarEraserButton](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbareraserbutton.aspx) のみ追加します。
> [!NOTE]
> ボタンは、ここで指定した順序ではなく、フレームワークで定義されている順序でツール バーに追加されます。

```xaml
<Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
    <Grid.RowDefinitions>
        <RowDefinition Height="Auto"/>
        <RowDefinition Height="*"/>
    </Grid.RowDefinitions>
    <StackPanel x:Name="HeaderPanel" Orientation="Horizontal" Grid.Row="0">
        <TextBlock x:Name="Header"
                   Text="Basic ink sample"
                   Style="{ThemeResource HeaderTextBlockStyle}"
                   Margin="10,0,0,0" />
    </StackPanel>
    <Grid Grid.Row="1">
        <Image Source="Assets\StoreLogo.png" />
        <!-- Clear the default InkToolbar buttons by setting InitialControls to None. -->
        <!-- Set the active tool to the pencil button. -->
        <InkCanvas x:Name="inkCanvas" />
        <InkToolbar x:Name="inkToolbar"
                    VerticalAlignment="Top"
                    TargetInkCanvas="{x:Bind inkCanvas}"
                    InitialControls="None">
            <!--
             Add only the ballpoint pen, pencil, and eraser.
             Note that the buttons are added to the toolbar in the order
             defined by the framework, not the order we specify here.
            -->
            <InkToolbarEraserButton />
            <InkToolbarBallpointPenButton />
            <InkToolbarPencilButton/>
        </InkToolbar>
    </Grid>
</Grid>
```

**コード ビハインド**
1. 最初の例から、InkCanvas と InkToolbar の XAML 宣言を使用します。

  ```xaml
  <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
      <Grid.RowDefinitions>
          <RowDefinition Height="Auto"/>
          <RowDefinition Height="*"/>
      </Grid.RowDefinitions>
      <StackPanel x:Name="HeaderPanel" Orientation="Horizontal" Grid.Row="0">
          <TextBlock x:Name="Header"
                     Text="Basic ink sample"
                     Style="{ThemeResource HeaderTextBlockStyle}"
                     Margin="10,0,0,0" />
      </StackPanel>
      <Grid Grid.Row="1">
          <Image Source="Assets\StoreLogo.png" />
          <InkCanvas x:Name="inkCanvas" />
          <InkToolbar x:Name="inkToolbar"
          VerticalAlignment="Top"
          TargetInkCanvas="{x:Bind inkCanvas}" />
      </Grid>
  </Grid>
  ```

2. コード ビハインドで、[InkToolbar](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbar.aspx) オブジェクトの [Loading](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.frameworkelement.loading.aspx) イベントのハンドラーを設定します。

  ```csharp
  /// <summary>
  /// An empty page that can be used on its own or navigated to within a Frame.
  /// Here, we set up InkToolbar event listeners.
  /// </summary>
  public MainPage_CodeBehind()
  {
      this.InitializeComponent();
      // Add handlers for InkToolbar events.
      inkToolbar.Loading += inkToolbar_Loading;
  }
  ```

3. [InitialControls](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbar.initialcontrols.aspx) を "[None](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbarinitialcontrols.aspx)" に設定します。
4. アプリで必要なボタンのオブジェクト参照を作成します。 ここでは、[InkToolbarBallpointPenButton](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbarballpointpenbutton.aspx)、[InkToolbarPencilButton](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbarpencilbutton.aspx)、および [InkToolbarEraserButton](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbareraserbutton.aspx) のみ追加します。
  > [!NOTE]
  > ボタンは、ここで指定した順序ではなく、フレームワークで定義されている順序でツール バーに追加されます。

5. [Add](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.dependencyobjectcollection.add.aspx) メソッドを使用して、ボタンを InkToolbar に追加します。

  ```csharp
  /// <summary>
  /// Handles the Loading event of the InkToolbar.
  /// Here, we identify the buttons to include on the InkToolbar.
  /// </summary>
  /// <param name="sender">The InkToolbar</param>
  /// <param name="args">The InkToolbar event data.
  /// If there is no event data, this parameter is null</param>
  private void inkToolbar_Loading(FrameworkElement sender, object args)
  {
      // Clear all built-in buttons from the InkToolbar.
      inkToolbar.InitialControls = InkToolbarInitialControls.None;

      // Add only the ballpoint pen, pencil, and eraser.
      // Note that the buttons are added to the toolbar in the order
      // defined by the framework, not the order we specify here.
      InkToolbarBallpointPenButton ballpoint = new InkToolbarBallpointPenButton();
      InkToolbarPencilButton pencil = new InkToolbarPencilButton();
      InkToolbarEraserButton eraser = new InkToolbarEraserButton();
      inkToolbar.Children.Add(eraser);
      inkToolbar.Children.Add(ballpoint);
      inkToolbar.Children.Add(pencil);
  }
  ```

<!--
### Support touch input
By default, the InkToolbar supports both pen and mouse input, you have to enable support for touch input.
-->

## <a name="custom-buttons-and-inking-features"></a>カスタム ボタンおよび手書き入力機能

InkToolbar を通じて提供されるボタン (および関連する手書き入力機能) のコレクションをカスタマイズして拡張できます。

InkToolbar は、次のような 2 つの異なるボタンの種類のグループで構成されます。

1. "ツール" ボタンのグループ。組み込みの描画ボタン、消去ボタン、強調表示ボタンが含まれます。 カスタム ペンとカスタム ツールはここに追加されます。
> **注**&nbsp;&nbsp;機能の選択は相互に排他的です。

2. "トグル" ボタンのグループ。組み込みのルーラー ボタンが含まれます。 カスタム トグルはここに追加されます。
> **注**&nbsp;&nbsp;機能は相互に排他的ではないので、他のアクティブなツールと同時に使うことができます。

お使いのアプリケーションと必要なインク機能によって異なりますが、InkToolbar には次のボタン (カスタムの手書き入力機能にバインドされます) を追加できます。

- カスタム ペン – インクのカラー パレットやペン先のプロパティ (形状、回転、サイズなど) がホスト アプリで定義されるペン。
- カスタム ツール – ホスト アプリで定義されるペン不使用ツール。
- カスタム トグル – アプリで定義された機能の状態をオンまたはオフに設定します。 オンにすると、機能はアクティブなツールと連携して動作します。

> **注**&nbsp;&nbsp;組み込みのボタンの表示順序を変更することはできません。 既定の表示順序は、ボールペン、鉛筆、蛍光ペン、消しゴム、ルーラーです。 カスタム ペンは最後の既定のペンに追加され、カスタム ツール ボタンは最後のペン ボタンと消しゴム ボタンの間に追加され、カスタム トグル ボタンはルーラー ボタンの後に追加されます  (カスタム ボタンは、指定されている順序で追加されます)。

### <a name="custom-pen"></a>カスタム ペン

形状、回転、サイズなどのインク カラー パレットと、ペン先のプロパティを定義するカスタムペン (カスタム ペン ボタンを使用してアクティブ化されます) を作成できます。

![筆記体のカスタム ペン ボタン](.\images\ink\ink-tools-custompen.png)  
*筆記体のカスタム ペン ボタン*

ここでは、幅広のペン先で、基本的な筆記体のインク ストロークを可能にするカスタム ペンを定義します。 また、ボタン ポップアップに表示されるパレットのブラシのコレクションもカスタマイズします。

**コード ビハインド**

まず、コード ビハインドでカスタム ペンを定義し、描画の属性を指定します。 このカスタム ペンを後で XAML から参照します。

1. ソリューション エクスプローラーでプロジェクトを右クリックし、[追加]、[新しい項目] の順に選びます。
2. [Visual C#] の [コード] で、新しいクラス ファイルを追加し、CalligraphicPen.cs という名前を付けます。
3. Calligraphic.cs で、既定の using ブロックを次のように置き換えます。
```csharp
using System.Numerics;
using Windows.UI;
using Windows.UI.Input.Inking;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
```

4. CalligraphicPen クラスが [InkToolbarCustomPen](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbarcustompen.aspx) から派生するように指定します。
```csharp
class CalligraphicPen : InkToolbarCustomPen
{
}
```

5. [CreateInkDrawingAttributesCore](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbarcustompen.createinkdrawingattributescore.aspx) をオーバーライドし、ブラシとストロークのサイズを独自に指定します。
```csharp
class CalligraphicPen : InkToolbarCustomPen
{
    protected override InkDrawingAttributes
      CreateInkDrawingAttributesCore(Brush brush, double strokeWidth)
    {
    }
}
```

6. [InkDrawingAttributes](https://msdn.microsoft.com/library/windows/apps/windows.ui.input.inking.inkdrawingattributes.aspx) オブジェクトを作成し、[ペン先の形状](https://msdn.microsoft.com/library/windows/apps/windows.ui.input.inking.inkdrawingattributes.pentip.aspx)、[ペン先の回転](https://msdn.microsoft.com/library/windows/apps/windows.ui.input.inking.inkdrawingattributes.pentiptransform.aspx)、[ストロークのサイズ](https://msdn.microsoft.com/library/windows/apps/windows.ui.input.inking.inkdrawingattributes.size.aspx)、および[インクの色](https://msdn.microsoft.com/library/windows/apps/windows.ui.input.inking.inkdrawingattributes.color.aspx)を設定します。
```csharp
class CalligraphicPen : InkToolbarCustomPen
{
    protected override InkDrawingAttributes
      CreateInkDrawingAttributesCore(Brush brush, double strokeWidth)
    {
        InkDrawingAttributes inkDrawingAttributes =
          new InkDrawingAttributes();
        inkDrawingAttributes.PenTip = PenTipShape.Circle;
        inkDrawingAttributes.Size =
          new Windows.Foundation.Size(strokeWidth, strokeWidth * 20);
        SolidColorBrush solidColorBrush = brush as SolidColorBrush;
        if (solidColorBrush != null)
        {
            inkDrawingAttributes.Color = solidColorBrush.Color;
        }
        else
        {
            inkDrawingAttributes.Color = Colors.Black;
        }

        Matrix3x2 matrix = Matrix3x2.CreateRotation(45);
        inkDrawingAttributes.PenTipTransform = matrix;

        return inkDrawingAttributes;
    }
}
```

**XAML**

次に、MainPage.xaml で、カスタム ペンへの必要な参照を追加します。

1. CalligraphicPen.cs で定義したカスタム ペン (`CalligraphicPen`) と、カスタム ペンでサポートされる[ブラシ コレクション](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Media.BrushCollection.aspx) (`CalligraphicPenPalette`) への参照を作成するローカル ページのリソース ディクショナリを宣言します。
```xaml
<Page.Resources>
    <!-- Add the custom CalligraphicPen to the page resources. -->
    <local:CalligraphicPen x:Key="CalligraphicPen" />
    <!-- Specify the colors for the palette of the custom pen. -->
    <BrushCollection x:Key="CalligraphicPenPalette">
        <SolidColorBrush Color="Blue" />
        <SolidColorBrush Color="Red" />
    </BrushCollection>
</Page.Resources>
```

2. 次に、InkToolbar と子要素の [InkToolbarCustomPenButton](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbarcustompenbutton.aspx) を追加します。

  カスタム ペン ボタンには、ページ リソースで宣言された `CalligraphicPen` と `CalligraphicPenPalette` の 2 つの静的なリソース参照が含まれます。

  また、ストローク サイズのスライダーの範囲 ([MinStrokeWidth](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbarpenbutton.minstrokewidth.aspx)、[MaxStrokeWidth](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbarpenbutton.maxstrokewidth.aspx)、および [SelectedStrokeWidth](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbarpenbutton.selectedstrokewidthproperty.aspx))、選択されたブラシ ([SelectedBrushIndex](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbarpenbutton.selectedbrushindex.aspx))、カスタム ペン ボタンのアイコン ([SymbolIcon](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.symbolicon.aspx)) も指定します。
```xaml
<Grid Grid.Row="1">
    <InkCanvas x:Name="inkCanvas" />
    <InkToolbar x:Name="inkToolbar"
                VerticalAlignment="Top"
                TargetInkCanvas="{x:Bind inkCanvas}">
        <InkToolbarCustomPenButton
            CustomPen="{StaticResource CalligraphicPen}"
            Palette="{StaticResource CalligraphicPenPalette}"
            MinStrokeWidth="1" MaxStrokeWidth="3" SelectedStrokeWidth="2"
            SelectedBrushIndex ="1">
            <SymbolIcon Symbol="Favorite" />
            <InkToolbarCustomPenButton.ConfigurationContent>
                <InkToolbarPenConfigurationControl />
            </InkToolbarCustomPenButton.ConfigurationContent>
        </InkToolbarCustomPenButton>
    </InkToolbar>
</Grid>
```

### <a name="custom-toggle"></a>カスタム トグル

カスタム トグル (カスタム トグル ボタンを使用してアクティブ化されます) を作成して、アプリ定義の機能の状態をオンまたはオフに設定できます。 オンにすると、機能はアクティブなツールと連携して動作します。

この例では、タッチ入力による手書き入力を可能にするカスタム トグル ボタンを定義しています (既定では、タッチの手書き入力は有効化されていません)。

> [!NOTE]  
> タッチを使った手書き入力をサポートする必要がある場合は、この例で指定されたアイコンとツールチップを使い、CustomToggleButton を使用して手書き入力を有効化することをお勧めします。

通常タッチ入力は、オブジェクトまたはアプリの UI を直接操作するために使用されます。 タッチによる手書き入力を有効化したときの動作の違いを示すために、InkCanvas を ScrollViewer コンテナ内に配置し、ScrollViewer のサイズを InkCanvas よりも小さく設定します。 

アプリが起動すると、ペンによる手書き入力のみがサポートされ、タッチは手書き入力の入力面をパンまたはズームするために使用されます。 タッチによる手書き入力が有効化されていると、手書き入力の入力面をタッチ入力でパンまたはズームすることはできません。

> [!NOTE]
> [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.InkCanvas) および [**InkToolbar**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.InkToolbar) の UX ガイドラインは、「[インク コントロール](..\controls-and-patterns\inking-controls.md)」をご覧ください。 次の推奨事項は、この例に関連したものです。
> - [**InkToolbar**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.InkToolbar) と手書き入力全般は、アクティブなペンを通じて最適なエクスペリエンスを実現します。 ただし、アプリで必要な場合は、マウスやタッチによる手書き入力をサポートできます。 
> - タッチ入力による手書き入力をサポートする場合、トグル ボタンに "Segoe MLD2 アセット" フォントの "ED5F" アイコンを使うと共に、"タッチによる手書き" というヒントを表示することをお勧めします。 

**XAML**

1. まず、イベント ハンドラー (Toggle_Custom) を指定する Click イベント リスナーを持つ [**InkToolbarCustomToggleButton**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.InkToolbarCustomToggleButton) 要素 (toggleButton) を宣言します。

```xaml 
<Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
    <Grid.RowDefinitions>
        <RowDefinition Height="Auto"/>
        <RowDefinition Height="*"/>
    </Grid.RowDefinitions>

    <StackPanel Grid.Row="0" 
                x:Name="HeaderPanel" 
                Orientation="Horizontal">
        <TextBlock x:Name="Header" 
                   Text="Basic ink sample" 
                   Style="{ThemeResource HeaderTextBlockStyle}" 
                   Margin="10" />
    </StackPanel>

    <ScrollViewer Grid.Row="1" 
                  HorizontalScrollBarVisibility="Auto" 
                  VerticalScrollBarVisibility="Auto">
        
        <Grid HorizontalAlignment="Left" VerticalAlignment="Top">
            <Grid.RowDefinitions>
                <RowDefinition Height="Auto"/>
                <RowDefinition Height="*"/>
            </Grid.RowDefinitions>
            
            <InkToolbar Grid.Row="0" 
                        Margin="10"
                        x:Name="inkToolbar" 
                        VerticalAlignment="Top"
                        TargetInkCanvas="{x:Bind inkCanvas}">
                <InkToolbarCustomToggleButton 
                x:Name="toggleButton" 
                Click="CustomToggle_Click" 
                ToolTipService.ToolTip="Touch Writing">
                    <SymbolIcon Symbol="{x:Bind TouchWritingIcon}"/>
                </InkToolbarCustomToggleButton>
            </InkToolbar>
            
            <ScrollViewer Grid.Row="1" 
                          Height="500"
                          Width="500"
                          x:Name="scrollViewer" 
                          ZoomMode="Enabled" 
                          MinZoomFactor=".1" 
                          VerticalScrollMode="Enabled" 
                          VerticalScrollBarVisibility="Auto" 
                          HorizontalScrollMode="Enabled" 
                          HorizontalScrollBarVisibility="Auto">
                
                <Grid x:Name="outputGrid" 
                      Height="1000"
                      Width="1000"
                      Background="{ThemeResource SystemControlBackgroundChromeWhiteBrush}">
                    <InkCanvas x:Name="inkCanvas"/>
                </Grid>
                
            </ScrollViewer>
        </Grid>
    </ScrollViewer>
</Grid>
```

**コード ビハインド**

2. 前のスニペットでは、タッチによる手書き入力 (toggleButton) のカスタム トグル ボタンの Click イベント リスナーとハンドラー (Toggle_Custom) を宣言しました。 このハンドラーは、InkPresenter の InputDeviceTypes プロパティを使って、CoreInputDeviceTypes.Touch のサポートを単にトグルします。

   また、SymbolIcon 要素と、コードビハインド ファイル (TouchWritingIcon) で定義されたフィールドにバインドする {x：Bind} マークアップ拡張を使用して、ボタンのアイコンを指定しました。

   次のスニペットには、Click イベント ハンドラーと TouchWritingIcon の定義の両方が含まれています。

```csharp 
namespace Ink_Basic_InkToolbar
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage_AddCustomToggle : Page
    {
        Symbol TouchWritingIcon = (Symbol)0xED5F;

        public MainPage_AddCustomToggle()
        {
            this.InitializeComponent();
        }

        // Handler for the custom toggle button that enables touch inking.
        private void CustomToggle_Click(object sender, RoutedEventArgs e)
        {
            if (toggleButton.IsChecked == true)
            {
                inkCanvas.InkPresenter.InputDeviceTypes |= CoreInputDeviceTypes.Touch;
            }
            else
            {
                inkCanvas.InkPresenter.InputDeviceTypes &= ~CoreInputDeviceTypes.Touch;
            }
        }
    }
}
```

### <a name="custom-tool"></a>カスタム ツール

カスタム ツール ボタンを作成して、アプリで定義されたペン以外のツールを呼び出すことができます。

既定では、[**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.Inking.InkPresenter) はすべての入力をインク ストロークか消去ストロークとして処理します。 これには、セカンダリ ハードウェア アフォーダンス (ペン バレル ボタン、マウスの右ボタンなど) によって変更された入力も含まれます。 ただし、[**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.Inking.InkPresenter) は、特定の入力を未処理のままにするように設定でき、それをカスタム処理のためにアプリに渡すことができます。

この例では、カスタム ツール ボタンを定義しており、これを選択すると、後続のストロークはインクではなく、なげなわ選択 (破線) として処理されてレンダリングされます。 選択領域の範囲内のすべてのインク ストロークが [**Selected**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.Inking.InkStroke.Selected) に設定されます。

> [!NOTE]
> InkCanvas および InkToolbar の UX ガイドラインは、「インク コントロール」をご覧ください。 次の推奨事項は、この例に関連したものです。
> - ストローク選択を提供する場合は、「選択ツール」ツールチップを使用して、ツール ボタンの "Segoe MLD2 アセット" フォントの "EF20" アイコンを使用することをお勧めします。 
 
**XAML**

1. まず、ストローク選択が構成されているイベント ハンドラー (customToolButton_Click) を指定する Click イベント リスナーを持つ [**InkToolbarCustomToolButton**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.InkToolbarCustomToolButton) 要素 (customToolButton) を宣言します。 (ストローク選択のコピー、切り取り、貼り付けのための一連のボタンも追加しました。)

2. 選択ストロークを描画するための Canvas 要素も追加します。 別のレイヤーを使って選択ストロークを描画すると、[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.InkCanvas) とそのコンテンツは影響を受けることがありません。 

```xaml
<Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
    <Grid.RowDefinitions>
        <RowDefinition Height="Auto"/>
        <RowDefinition Height="Auto"/>
        <RowDefinition Height="*"/>
    </Grid.RowDefinitions>
    <StackPanel x:Name="HeaderPanel" Orientation="Horizontal" Grid.Row="0">
        <TextBlock x:Name="Header" 
                   Text="Basic ink sample" 
                   Style="{ThemeResource HeaderTextBlockStyle}" 
                   Margin="10,0,0,0" />
    </StackPanel>
    <StackPanel x:Name="ToolPanel" Orientation="Horizontal" Grid.Row="1">
        <InkToolbar x:Name="inkToolbar" 
                    VerticalAlignment="Top" 
                    TargetInkCanvas="{x:Bind inkCanvas}">
            <InkToolbarCustomToolButton 
                x:Name="customToolButton" 
                Click="customToolButton_Click" 
                ToolTipService.ToolTip="Selection tool">
                <SymbolIcon Symbol="{x:Bind SelectIcon}"/>
            </InkToolbarCustomToolButton>
        </InkToolbar>
        <Button x:Name="cutButton" 
                Content="Cut" 
                Click="cutButton_Click"
                Width="100"
                Margin="5,0,0,0"/>
        <Button x:Name="copyButton" 
                Content="Copy"  
                Click="copyButton_Click"
                Width="100"
                Margin="5,0,0,0"/>
        <Button x:Name="pasteButton" 
                Content="Paste"  
                Click="pasteButton_Click"
                Width="100"
                Margin="5,0,0,0"/>
    </StackPanel>
    <Grid Grid.Row="2" x:Name="outputGrid" 
              Background="{ThemeResource SystemControlBackgroundChromeWhiteBrush}" 
              Height="Auto">
        <!-- Canvas for displaying selection UI. -->
        <Canvas x:Name="selectionCanvas"/>
        <!-- Canvas for displaying ink. -->
        <InkCanvas x:Name="inkCanvas" />
    </Grid>
</Grid>
```

**コード ビハインド**

2. 次に、MainPage.xaml.cs コードビハインド ファイルの [**InkToolbarCustomToolButton**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.InkToolbarCustomToolButton) の Click イベントを処理します。

   このハンドラは、未処理の入力をアプリに渡すように [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.Inking.InkPresenter) を設定します。 

   このコードの詳細な手順については、「[UWP アプリでのペン操作と Windows Ink](pen-and-stylus-interactions.md)」の「高度な処理のための入力のパススルー」のセクションをご覧ください。

   また、SymbolIcon 要素と、コードビハインド ファイル (SelectIcon) で定義されたフィールドにバインドする {x：Bind} マークアップ拡張を使用して、ボタンのアイコンを指定しました。

   次のスニペットには、Click イベント ハンドラーと SelectIcon の定義の両方が含まれています。

```csharp
namespace Ink_Basic_InkToolbar
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage_AddCustomTool : Page
    {
        // Icon for custom selection tool button.
        Symbol SelectIcon = (Symbol)0xEF20;

        // Stroke selection tool.
        private Polyline lasso;
        // Stroke selection area.
        private Rect boundingRect;

        public MainPage_AddCustomTool()
        {
            this.InitializeComponent();

            // Listen for new ink or erase strokes to clean up selection UI.
            inkCanvas.InkPresenter.StrokeInput.StrokeStarted +=
                StrokeInput_StrokeStarted;
            inkCanvas.InkPresenter.StrokesErased +=
                InkPresenter_StrokesErased;
        }

        private void customToolButton_Click(object sender, RoutedEventArgs e)
        {
            // By default, the InkPresenter processes input modified by 
            // a secondary affordance (pen barrel button, right mouse 
            // button, or similar) as ink.
            // To pass through modified input to the app for custom processing 
            // on the app UI thread instead of the background ink thread, set 
            // InputProcessingConfiguration.RightDragAction to LeaveUnprocessed.
            inkCanvas.InkPresenter.InputProcessingConfiguration.RightDragAction =
                InkInputRightDragAction.LeaveUnprocessed;

            // Listen for unprocessed pointer events from modified input.
            // The input is used to provide selection functionality.
            inkCanvas.InkPresenter.UnprocessedInput.PointerPressed +=
                UnprocessedInput_PointerPressed;
            inkCanvas.InkPresenter.UnprocessedInput.PointerMoved +=
                UnprocessedInput_PointerMoved;
            inkCanvas.InkPresenter.UnprocessedInput.PointerReleased +=
                UnprocessedInput_PointerReleased;
        }

        // Handle new ink or erase strokes to clean up selection UI.
        private void StrokeInput_StrokeStarted(
            InkStrokeInput sender, Windows.UI.Core.PointerEventArgs args)
        {
            ClearSelection();
        }

        private void InkPresenter_StrokesErased(
            InkPresenter sender, InkStrokesErasedEventArgs args)
        {
            ClearSelection();
        }

        private void cutButton_Click(object sender, RoutedEventArgs e)
        {
            inkCanvas.InkPresenter.StrokeContainer.CopySelectedToClipboard();
            inkCanvas.InkPresenter.StrokeContainer.DeleteSelected();
            ClearSelection();
        }

        private void copyButton_Click(object sender, RoutedEventArgs e)
        {
            inkCanvas.InkPresenter.StrokeContainer.CopySelectedToClipboard();
        }

        private void pasteButton_Click(object sender, RoutedEventArgs e)
        {
            if (inkCanvas.InkPresenter.StrokeContainer.CanPasteFromClipboard())
            {
                inkCanvas.InkPresenter.StrokeContainer.PasteFromClipboard(
                    new Point(0, 0));
            }
            else
            {
                // Cannot paste from clipboard.
            }
        }

        // Clean up selection UI.
        private void ClearSelection()
        {
            var strokes = inkCanvas.InkPresenter.StrokeContainer.GetStrokes();
            foreach (var stroke in strokes)
            {
                stroke.Selected = false;
            }
            ClearBoundingRect();
        }

        private void ClearBoundingRect()
        {
            if (selectionCanvas.Children.Any())
            {
                selectionCanvas.Children.Clear();
                boundingRect = Rect.Empty;
            }
        }

        // Handle unprocessed pointer events from modifed input.
        // The input is used to provide selection functionality.
        // Selection UI is drawn on a canvas under the InkCanvas.
        private void UnprocessedInput_PointerPressed(
            InkUnprocessedInput sender, PointerEventArgs args)
        {
            // Initialize a selection lasso.
            lasso = new Polyline()
            {
                Stroke = new SolidColorBrush(Windows.UI.Colors.Blue),
                StrokeThickness = 1,
                StrokeDashArray = new DoubleCollection() { 5, 2 },
            };

            lasso.Points.Add(args.CurrentPoint.RawPosition);

            selectionCanvas.Children.Add(lasso);
        }

        private void UnprocessedInput_PointerMoved(
            InkUnprocessedInput sender, PointerEventArgs args)
        {
            // Add a point to the lasso Polyline object.
            lasso.Points.Add(args.CurrentPoint.RawPosition);
        }

        private void UnprocessedInput_PointerReleased(
            InkUnprocessedInput sender, PointerEventArgs args)
        {
            // Add the final point to the Polyline object and 
            // select strokes within the lasso area.
            // Draw a bounding box on the selection canvas 
            // around the selected ink strokes.
            lasso.Points.Add(args.CurrentPoint.RawPosition);

            boundingRect =
                inkCanvas.InkPresenter.StrokeContainer.SelectWithPolyLine(
                    lasso.Points);

            DrawBoundingRect();
        }

        // Draw a bounding rectangle, on the selection canvas, encompassing 
        // all ink strokes within the lasso area.
        private void DrawBoundingRect()
        {
            // Clear all existing content from the selection canvas.
            selectionCanvas.Children.Clear();

            // Draw a bounding rectangle only if there are ink strokes 
            // within the lasso area.
            if (!((boundingRect.Width == 0) ||
                (boundingRect.Height == 0) ||
                boundingRect.IsEmpty))
            {
                var rectangle = new Rectangle()
                {
                    Stroke = new SolidColorBrush(Windows.UI.Colors.Blue),
                    StrokeThickness = 1,
                    StrokeDashArray = new DoubleCollection() { 5, 2 },
                    Width = boundingRect.Width,
                    Height = boundingRect.Height
                };

                Canvas.SetLeft(rectangle, boundingRect.X);
                Canvas.SetTop(rectangle, boundingRect.Y);

                selectionCanvas.Children.Add(rectangle);
            }
        }
    }
}
```



### <a name="custom-ink-rendering"></a>カスタム インク レンダリング

既定では、手書き入力は低待機時間のバックグラウンド スレッドで処理され、描画と同時に "ウェット" レンダリングが行われます。 ストロークが完了すると (ペンまたは指が画面を離れるか、マウスのボタンが離されると)、UI スレッドでストロークが処理されて、[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) レイヤーへの "ドライ" レンダリングが行われます (アプリケーション コンテンツの上にレンダリングされてウェット インクが置き換えられます)。

インク プラットフォームでは、この動作を上書きして、手書き入力のカスタム ドライ レンダリングによって手書き入力エクスペリエンスを全面的にカスタマイズすることができます。

カスタム ドライ レンダリングについて詳しくは、「[UWP アプリでのペン操作と Windows Ink](https://msdn.microsoft.com/windows/uwp/input-and-devices/pen-and-stylus-interactions#custom-ink-rendering)」をご覧ください。

> [!NOTE]
> カスタム ドライ レンダリングと [**InkToolbar**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbar.aspx)  
> カスタム ドライの実装によって、アプリが [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn922011) の既定のインク レンダリング動作を上書きすると、レンダリングされたインク ストロークが InkToolbar で利用できなくなり、InkToolbar の組み込みの消去コマンドが正常に機能しなくなります。 消去機能を提供するには、すべてのポインター イベントを処理し、ストロークごとにヒット テストを実行すると共に、組み込みの [すべてのインクのデータを消去] コマンドをオーバーライドする必要があります。

## <a name="related-articles"></a>関連記事

* [ペン操作とスタイラス操作](pen-and-stylus-interactions.md)

**サンプル**
* [インクのサンプル](http://go.microsoft.com/fwlink/p/?LinkID=620308)
* [単純なインクのサンプル](http://go.microsoft.com/fwlink/p/?LinkID=620312)
* [複雑なインクのサンプル](http://go.microsoft.com/fwlink/p/?LinkID=620314)
