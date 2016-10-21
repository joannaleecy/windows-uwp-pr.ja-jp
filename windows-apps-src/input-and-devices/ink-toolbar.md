---
author: Karl-Bridge-Microsoft
Description: "既定の InkToolbar をユニバーサル Windows プラットフォーム (UWP) 手書き入力アプリに追加し、カスタム ペン ボタンを InkToolbar に追加して、カスタム ペン ボタンをカスタム ペン定義にバインドします。"
title: "InkToolbar をユニバーサル Windows プラットフォーム (UWP) 手書き入力アプリに追加する"
label: Add an InkToolbar to a Universal Windows Platform (UWP) inking app
template: detail.hbs
keyword: Windows Ink, Windows Inking, DirectInk, InkPresenter, InkCanvas, InkToolbar, Universal Windows Platform, UWP
translationtype: Human Translation
ms.sourcegitcommit: 71b73605bab71dad36977d0506c090c34359a3e2
ms.openlocfilehash: c4a5b0ae2893fda7697457b9e7449a996707de4b

---

# InkToolbar をユニバーサル Windows プラットフォーム (UWP) 手書き入力アプリに追加する

ユニバーサル Windows プラットフォーム (UWP) アプリでの手書き入力を容易にする、[**InkCanvas**](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.inkcanvas.aspx) と [**InkToolbar**](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.inktoolbar.aspx) という 2 つのコントロールがあります。

[**InkCanvas**](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.inkcanvas.aspx) コントロールには、基本的な Windows Ink 機能が用意されています。 このコントロールを使用して、ペン入力をインク ストローク (色と太さの既定の設定を使う) か消去ストロークとしてレンダリングできます。

> InkCanvas の実装について詳しくは、「[UWP アプリのペン操作とスタイラス操作](pen-and-stylus-interactions.md)」をご覧ください。

InkCanvas は、完全に透明なオーバーレイであるため、インク ストロークのプロパティを設定するための UI は組み込まれていません。 既定の手書き入力エクスペリエンスを変更する場合、ユーザーがインク ストロークのプロパティを設定し、その他のカスタムの手書き入力機能を使用できるようにします。これには 2 つの方法があります。

- コード ビハインドで、InkCanvas にバインドされている、基になる [**InkPresenter**](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.input.inking.inkpresenter.aspx) オブジェクトを使用します。

  InkPresenter API では、手書き入力エクスペリエンスのさまざまなカスタマイズをサポートしています。 詳しくは、「[UWP アプリのペン操作とスタイラス操作](pen-and-stylus-interactions.md)」をご覧ください。

- [**InkToolbar**](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.inktoolbar.aspx) を InkCanvas にバインドします。 既定では、InkToolbar には、インク機能をアクティブ化し、ストロークのサイズ、インクの色、ペン先の形状などのインクのプロパティを設定できる基本的な UI が用意されています。

  ここでは、InkToolbar について説明します。

## 重要な API

  -   [**InkCanvas クラス**](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.inkcanvas.aspx)
  -   [**InkToolbar クラス**](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.inktoolbar.aspx)
  -   [**InkPresenter クラス**](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.input.inking.inkpresenter.aspx)
  -   [**Windows.UI.Input.Inking**](https://msdn.microsoft.com/library/windows/apps/br208524)


## 既定の InkToolbar

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

## 基本的なカスタマイズ

このセクションでは、Windows Ink ツール バーの基本的なカスタマイズに関するシナリオについて説明します。

### 選択されるボタンを指定する  
![初期化時に鉛筆ボタンが選択される](.\images\ink\ink-tools-default-toolbar.png)  
*Windows Ink ツール バーで初期化時に鉛筆ボタンが選択される*

既定では、アプリが起動し、ツール バーが初期化されると、最初 (または左端) のボタンが選択されます。 既定の Windows Ink ツール バーでは、ボールペン ボタンが選択されます。

フレームワークで組み込みのボタンの順序が定義されるため、最初のボタンが既定でアクティブ化したいペンやツールでない場合があります。

この既定の動作を上書きし、ツール バーで選択されるボタンを指定できます。

ここでは、(ボールペンではなく) 鉛筆ボタンが選択され、鉛筆がアクティブになるように、既定のツール バーを初期化します。

1. 前の例から、InkCanvas と InkToolbar の XAML 宣言を使用します。
2. コード ビハインドで、[InkToolbar](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbar.aspx) オブジェクトの [Loaded](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.frameworkelement.loaded.aspx) イベントのハンドラーを設定します。

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

3. [Loaded](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.frameworkelement.loaded.aspx) イベントのハンドラーで次の処理を行います。
  1. 組み込みの [InkToolbarPencilButton](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.inktoolbarpencilbutton.aspx) への参照を取得します。

    [GetToolButton](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.inktoolbar.gettoolbutton.aspx) メソッドで [InkToolbarTool.Pencil](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.inktoolbartool.aspx) オブジェクトを渡すことで、[InkToolbarPencilButton](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbarpencilbutton.aspx) の [InkToolbarToolButton](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.inktoolbartoolbutton.aspx) オブジェクトが返されます。

  2. 前の手順で返されたオブジェクトに [ActiveTool](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.inktoolbar.activetool.aspx) を設定します。

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

### 組み込みのボタンを指定する

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
- [InitialControls](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.inktoolbar.initialcontrols.aspx) 属性を追加し、値を "[None](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.inktoolbarinitialcontrols.aspx)" に設定します。 これで組み込みボタンの既定のコレクションがクリアされます。
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

2. コード ビハインドで、[InkToolbar](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbar.aspx) オブジェクトの [Loading](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.frameworkelement.loading.aspx) イベントのハンドラーを設定します。

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

3. [InitialControls](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.inktoolbar.initialcontrols.aspx) を "[None](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.inktoolbarinitialcontrols.aspx)" に設定します。
4. アプリで必要なボタンのオブジェクト参照を作成します。 ここでは、[InkToolbarBallpointPenButton](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbarballpointpenbutton.aspx)、[InkToolbarPencilButton](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbarpencilbutton.aspx)、および [InkToolbarEraserButton](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbareraserbutton.aspx) のみ追加します。
  > [!NOTE]
  > ボタンは、ここで指定した順序ではなく、フレームワークで定義されている順序でツール バーに追加されます。

5. [Add](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.dependencyobjectcollection.add.aspx) メソッドを使用して、ボタンを InkToolbar に追加します。

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

## カスタム ボタンおよび手書き入力機能

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

### カスタム ペン

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

4. CalligraphicPen クラスが [InkToolbarCustomPen](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.inktoolbarcustompen.aspx) から派生するように指定します。
```csharp
class CalligraphicPen : InkToolbarCustomPen
{
}
```

5. [CreateInkDrawingAttributesCore](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.inktoolbarcustompen.createinkdrawingattributescore.aspx) をオーバーライドし、ブラシとストロークのサイズを独自に指定します。
```csharp
class CalligraphicPen : InkToolbarCustomPen
{
    protected override InkDrawingAttributes
      CreateInkDrawingAttributesCore(Brush brush, double strokeWidth)
    {
    }
}
```

6. [InkDrawingAttributes](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.input.inking.inkdrawingattributes.aspx) オブジェクトを作成し、[ペン先の形状](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.input.inking.inkdrawingattributes.pentip.aspx)、[ペン先の回転](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.input.inking.inkdrawingattributes.pentiptransform.aspx)、[ストロークのサイズ](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.input.inking.inkdrawingattributes.size.aspx)、および[インクの色](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.input.inking.inkdrawingattributes.color.aspx)を設定します。
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

1. CalligraphicPen.cs で定義したカスタム ペン (`CalligraphicPen`) と、カスタム ペンでサポートされる[ブラシ コレクション](https://msdn.microsoft.com/en-us/library/windows/apps/Windows.UI.Xaml.Media.BrushCollection.aspx) (`CalligraphicPenPalette`) への参照を作成するローカル ページのリソース ディクショナリを宣言します。
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

2. 次に、InkToolbar と子要素の [InkToolbarCustomPenButton](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.inktoolbarcustompenbutton.aspx) を追加します。

  カスタム ペン ボタンには、ページ リソースで宣言された `CalligraphicPen` と `CalligraphicPenPalette` の 2 つの静的なリソース参照が含まれます。

  また、ストローク サイズのスライダーの範囲 ([MinStrokeWidth](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.inktoolbarpenbutton.minstrokewidth.aspx)、[MaxStrokeWidth](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.inktoolbarpenbutton.maxstrokewidth.aspx)、および [SelectedStrokeWidth](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.inktoolbarpenbutton.selectedstrokewidthproperty.aspx))、選択されたブラシ ([SelectedBrushIndex](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.inktoolbarpenbutton.selectedbrushindex.aspx))、カスタム ペン ボタンのアイコン ([SymbolIcon](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.symbolicon.aspx)) も指定します。
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

<!--
### Custom toggle

Enable touch inking

>**Note**&nbsp;&nbsp;InkToolbar supports pen and mouse input and can be configured to recognize touch input.
-->


## 関連記事

* [ペン操作とスタイラス操作](pen-and-stylus-interactions.md)

**サンプル**
* [インクのサンプル](http://go.microsoft.com/fwlink/p/?LinkID=620308)
* [単純なインクのサンプル](http://go.microsoft.com/fwlink/p/?LinkID=620312)
* [複雑なインクのサンプル](http://go.microsoft.com/fwlink/p/?LinkID=620314)



<!--HONumber=Sep16_HO2-->


