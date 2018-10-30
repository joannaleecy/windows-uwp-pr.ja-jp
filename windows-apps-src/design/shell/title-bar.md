---
author: jwmsft
description: アプリの個性に合わせてデスクトップ アプリのタイトル バーをカスタマイズします。
title: タイトル バーのカスタマイズ
template: detail.hbs
ms.author: jimwalk
ms.date: 10/10/2017
ms.topic: article
keywords: windows 10, uwp, タイトル バー
doc-status: Draft
ms.localizationpriority: medium
ms.openlocfilehash: 2ebe590f98afef031ab183589fc7dcfc29cd9493
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/30/2018
ms.locfileid: "5764304"
---
# <a name="title-bar-customization"></a>タイトル バーのカスタマイズ



アプリをデスクトップ ウィンドウで実行する場合は、アプリの個性に合わせてタイトル バーをカスタマイズできます。 タイトル バーのカスタマイズ用 API を使用すると、タイトル バーの要素に色を指定することも、アプリ コンテンツをタイトル バーの領域に拡張して完全に制御することもできます。

> **重要な API**: [ApplicationView.TitleBar プロパティ](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.applicationview)、[ApplicationViewTitleBar クラス](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.applicationviewtitlebar)、[CoreApplicationViewTitleBar クラス](https://docs.microsoft.com/uwp/api/windows.applicationmodel.core.coreapplicationviewtitlebar)

## <a name="how-much-to-customize-the-title-bar"></a>タイトル バーのカスタマイズ レベル

タイトル バーに適用可能なカスタマイズの度合いとしては、2 つのレベルがあります。

色による単純なカスタマイズの場合は、[ApplicationViewTitleBar](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.applicationviewtitlebar) プロパティを設定して、タイトル バーの要素に使用する色を指定します。 この場合は、タイトル バーの他の部分 (アプリ タイトルの描画やドラッグ可能領域の定義など) は引き続きシステムが制御します。

もう 1 つのオプションは、既定のタイトル バーを非表示にし、独自の XAML コンテンツに置き換えることです。 たとえば、テキスト、ボタン、またはカスタム メニューをタイトル バー領域に配置できます。 [アクリル](../style/acrylic.md) バックグラウンドをタイトル バー領域に拡張する場合にも、このオプションを使用する必要があります。

全面的なカスタマイズを行う場合は、タイトル バー領域に自分でコンテンツを配置する必要があります。また、ドラッグ可能領域を独自に定義することもできます。 システムの [戻る]、[閉じる]、[最小化]、[最大化] ボタンは引き続き利用可能であり、システムによって処理されますが、アプリ タイトルなどの要素は該当しません。 アプリに必要であれば、このような要素を自身で作成する必要があります。

> [!NOTE]
> 単純な色のカスタマイズは、XAML、DirectX、HTML を使う UWP アプリで利用可能です。 全面的なカスタマイズでは、XAML を使う UWP アプリのみで利用可能です。

## <a name="simple-color-customization"></a>単純な色のカスタマイズ

あまり凝ったこと (タイトル バーにタブを設置するなど) は行わず、タイトル バーの色のみをカスタマイズする場合は、アプリ ウィンドウの [ApplicationViewTitleBar](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.applicationviewtitlebar) で色のプロパティを設定します。

この例では、ApplicationViewTitleBar のインスタンスを取得し、色のプロパティを設定する方法を示しています。

```csharp
// using Windows.UI.ViewManagement;

var titleBar = ApplicationView.GetForCurrentView().TitleBar;

// Set active window colors
titleBar.ForegroundColor = Windows.UI.Colors.White;
titleBar.BackgroundColor = Windows.UI.Colors.Green;
titleBar.ButtonForegroundColor = Windows.UI.Colors.White;
titleBar.ButtonBackgroundColor = Windows.UI.Colors.SeaGreen;
titleBar.ButtonHoverForegroundColor = Windows.UI.Colors.White;
titleBar.ButtonHoverBackgroundColor = Windows.UI.Colors.DarkSeaGreen;
titleBar.ButtonPressedForegroundColor = Windows.UI.Colors.Gray;
titleBar.ButtonPressedBackgroundColor = Windows.UI.Colors.LightGreen;

// Set inactive window colors
titleBar.InactiveForegroundColor = Windows.UI.Colors.Gray;
titleBar.InactiveBackgroundColor = Windows.UI.Colors.SeaGreen;
titleBar.ButtonInactiveForegroundColor = Windows.UI.Colors.Gray;
titleBar.ButtonInactiveBackgroundColor = Windows.UI.Colors.SeaGreen;
```

> [!NOTE]
> このコードは、アプリの [OnLaunched](https://docs.microsoft.com/uwp/api/windows.ui.xaml.application.onlaunched) メソッド (_App.xaml.cs_) 内の [Window.Activate](https://docs.microsoft.com/uwp/api/windows.ui.xaml.window.Activate) の呼び出しの後か、アプリの最初のページに配置できます。

> [!TIP]
> Windows コミュニティ ツールキットには、これらの色プロパティを XAML で設定するための拡張機能が用意されています。 詳細については、[Windows コミュニティ ツールキットのドキュメント](https://docs.microsoft.com/windows/uwpcommunitytoolkit/extensions/viewextensions)を参照してください。

タイトル バーの色を設定する際には注意する点がいくつかあります。

- ボタンの背景色は、[閉じる] ボタンのホバー時および押下時の状態に適用されません。 [閉じる] ボタンがこれらの状態の場合は、常にシステム定義の色が使用されます。
- システムの [戻る] ボタンにはボタンの色のプロパティが適用されます (使用時)  (「[ナビゲーション履歴と前に戻る移動](../basics/navigation-history-and-backwards-navigation.md)」をご覧ください)。
- 色のプロパティを **null** に設定すると、既定のシステム色にリセットされます。
- 透明色を設定することはできません。 色のアルファ チャネルは無視されます。

Windows では、ユーザーが選択した[アクセント カラー](https://docs.microsoft.com/windows/uwp/style/color#accent-color)をタイトル バーに適用するかどうかをユーザーが指定できます。 タイトル バーの色を設定した場合は、すべての色を明示的に設定することをお勧めします。 これにより、ユーザー定義の色設定によって意図しない色の組み合わせが発生する心配がなくなります。

## <a name="full-customization"></a>全面的なカスタマイズ

タイトル バーの全面的なカスタマイズを選択すると、アプリのクライアント領域が拡張され、タイトル バーの領域を含めてウィンドウ全体が対象になります。 この場合は、ウィンドウ全体の描画と入力処理を独自に行う必要があります。ただし、アプリのキャンバスの前面にオーバーレイ表示される、タイトル ボタンは例外です。

既定のタイトル バーを非表示にしてコンテンツをタイトル バー領域まで拡張するには、[CoreApplicationViewTitleBar.ExtendViewIntoTitleBar](https://docs.microsoft.com/uwp/api/windows.applicationmodel.core.coreapplicationviewtitlebar) プロパティを **true** に設定します。

この例は、CoreApplicationViewTitleBar を取得して ExtendViewIntoTitleBar プロパティを **true** に設定する方法を示しています。 この処理は、アプリの [OnLaunched](https://docs.microsoft.com/uwp/api/windows.ui.xaml.application.onlaunched)メソッド (_App.xaml.cs_) またはアプリの最初のページで行うことができます。

```csharp
// using Windows.ApplicationModel.Core;

// Hide default title bar.
var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
coreTitleBar.ExtendViewIntoTitleBar = true;
```

> [!TIP]
> アプリを閉じて再起動しても、この設定は保持されます。 Visual Studio で、ExtendViewIntoTitleBar を **true** に設定した場合に既定値に戻すには、この値を明示的に **false** に設定してアプリを実行することで、保持された設定を上書きする必要があります。

### <a name="draggable-regions"></a>ドラッグ可能領域

タイトル バーのドラッグ可能領域は、クリックしてドラッグすることでユーザーが (アプリのキャンバス内でコンテンツをドラッグするのではなく) ウィンドウを移動できる場所を定義します。 ドラッグ可能領域を指定するには、[Window.SetTitleBar](https://docs.microsoft.com/uwp/api/windows.ui.xaml.window.settitlebar) メソッドを呼び出し、ドラッグ可能領域を定義する UIElement を渡します  (UIElement は多くの場合、他の要素も含むパネルです)。

ドラッグ可能なタイトル バー領域としてコンテンツの Grid を設定する方法を以下に示します。 このコードは、アプリの最初のページの XAML と分離コードに使用します。 完全なコードについては、「[全面的なカスタマイズの例](./title-bar.md#full-customization-example)」セクションをご覧ください。

```xaml
<Grid x:Name="AppTitleBar" Background="Transparent">
    <!-- Width of the padding columns is set in LayoutMetricsChanged handler. -->
    <!-- Using padding columns instead of Margin ensures that the background
         paints the area under the caption control buttons (for transparent buttons). -->
    <Grid.ColumnDefinitions>
        <ColumnDefinition x:Name="LeftPaddingColumn" Width="0"/>
        <ColumnDefinition/>
        <ColumnDefinition x:Name="RightPaddingColumn" Width="0"/>
    </Grid.ColumnDefinitions>
    <Image Source="Assets/Square44x44Logo.png" 
           Grid.Column="1" HorizontalAlignment="Left" 
           Width="20" Height="20" Margin="12,0"/>
    <TextBlock Text="Custom Title Bar" 
               Grid.Column="1" 
               Style="{StaticResource CaptionTextBlockStyle}" 
               Margin="44,8,0,0"/>
</Grid>
```

```csharp
public MainPage()
{
    this.InitializeComponent();

    var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
    coreTitleBar.ExtendViewIntoTitleBar = true;

    // Set XAML element as a draggable region.
    AppTitleBar.Height = coreTitleBar.Height;
    Window.Current.SetTitleBar(AppTitleBar);
}
```

UIElement (`AppTitleBar`) は、アプリの XAML の一部です。 変化しないルート ページでタイトル バーを宣言して設定することも、アプリで表示される各ページでタイトル バー領域を宣言して設定することもできます。 各ページで設定した場合は、ユーザーがアプリ内を移動しても違和感を持たないように、ドラッグ可能領域の一貫性を維持する必要があります。

SetTitleBar を呼び出すと、アプリの実行中に新しいタイトル バー要素に切り替えることができます。 パラメーターとして **null** を SetTitleBar に渡し、既定のドラッグ動作に戻すこともできます  (詳しくは、「既定のドラッグ可能領域」をご覧ください)。

> [!IMPORTANT]
> 指定するドラッグ可能領域は、ヒット テストを可能にしておく必要があります。つまり、一部の要素では、透明な背景ブラシを設定する必要があります。 詳しくは、[VisualTreeHelper.FindElementsInHostCoordinates](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.visualtreehelper.findelementsinhostcoordinates) の「解説」をご覧ください。
>
>たとえば、ドラッグ可能領域として Grid を定義する場合は、`Background="Transparent"` を設定してドラッグ可能にします。
>
>この Grid はドラッグ可能ではありません (ただし、内部の表示要素はドラッグ可能です):`<Grid x:Name="AppTitleBar">`。
>
>この Grid は上のものと似ていますが、Grid 全体がドラッグ可能です: `<Grid x:Name="AppTitleBar" Background="Transparent">`。

#### <a name="default-draggable-region"></a>既定のドラッグ可能領域

ドラッグ可能領域を指定しなかった場合は、ウィンドウの幅、タイトル ボタンの高さで、ウィンドウの上端に合わせて配置された四角形が既定のドラッグ可能領域として設定されます。

ドラッグ可能領域を定義した場合、システムによって既定のドラッグ可能地域がタイトル ボタンのサイズの小さな領域に縮小され、タイトル ボタンの左側 (タイトル ボタンがウィンドウの左端にある場合は右側) に配置されます。 これにより、ユーザーがドラッグできる一貫性のある領域を常に確保できます。

### <a name="system-caption-buttons"></a>システム タイトル ボタン

アプリ ウィンドウの左上隅または右上隅は、システム タイトル ボタン ([戻る]、[最小化]、[最大化]、[閉じる]) 用に予約されています。 ウィンドウをドラッグ、最小化、最大化、および閉じるための最低限の機能を確保するために、タイトル コントロール領域の制御は、システムが保持します。 システムは、左から右へと表記される言語では右上、右から左へと表記される言語では左上に [閉じる] ボタンを描画します。

タイトル コントロール領域のサイズと位置は、CoreApplicationViewTitleBar クラスによって伝達されるため、独自のタイトル バー UI のレイアウトでも、これを利用できます。 左右に予約されている領域の幅は、[SystemOverlayLeftInset](https://docs.microsoft.com/uwp/api/windows.applicationmodel.core.coreapplicationviewtitlebar.SystemOverlayLeftInset) プロパティまたは [SystemOverlayRightInset](https://docs.microsoft.com/uwp/api/windows.applicationmodel.core.coreapplicationviewtitlebar.SystemOverlayRightInset) プロパティで指定され、高さは [Height](https://docs.microsoft.com/uwp/api/windows.applicationmodel.core.coreapplicationviewtitlebar.Height) プロパティで指定されます。

これらのプロパティで定義されたタイトル コントロール領域の背面に (たとえば背景として) コンテンツを描画することもできますが、ユーザーが操作するための UI は配置しないでください。 タイトル コントロールに対する入力はシステムによって処理されるため、タイトル コントロール領域で入力を受け取ることはできません。

タイトル ボタンのサイズ変化に応答するには、[LayoutMetricsChanged](https://docs.microsoft.com/uwp/api/windows.applicationmodel.core.coreapplicationviewtitlebar.LayoutMetricsChanged) イベントを処理します。 たとえば、システムの [戻る] ボタンが表示または非表示になったときなどに、このイベントが発生します。 このイベントを処理し、タイトル バーのサイズに基づく UI 要素の位置を確認および更新します。

以下の例では、システムの [戻る] ボタンの表示や非表示などの変化に対応して、タイトル バーのレイアウトを調整する方法を示します。 `AppTitleBar`、`LeftPaddingColumn`、および `RightPaddingColumn` は、前に示した XAML で宣言されています。

```csharp
private void CoreTitleBar_LayoutMetricsChanged(CoreApplicationViewTitleBar sender, object args)
{
    UpdateTitleBarLayout(sender);
}

private void UpdateTitleBarLayout(CoreApplicationViewTitleBar coreTitleBar)
{
    // Get the size of the caption controls area and back button 
    // (returned in logical pixels), and move your content around as necessary.
    LeftPaddingColumn.Width = new GridLength(coreTitleBar.SystemOverlayLeftInset);
    RightPaddingColumn.Width = new GridLength(coreTitleBar.SystemOverlayRightInset);
    TitleBarButton.Margin = new Thickness(0,0,coreTitleBar.SystemOverlayRightInset,0);

    // Update title bar control size as needed to account for system size changes.
    AppTitleBar.Height = coreTitleBar.Height;
}
```

### <a name="interactive-content"></a>対話型コンテンツ

ボタン、メニュー、検索ボックスなどの対話型のコントロールをアプリの上部に配置して、タイトル バーに表示することもできます。 ただし、対話型要素でユーザー入力を受信するには、以下の規則に従う必要があります。
- SetTitleBar を呼び出し、領域をドラッグ可能なタイトル バー領域として定義する必要があります。 この操作を行わなかった場合は、システムによって、ページの上部に既定のドラッグ可能領域が設定されます。 その場合、この領域へのユーザー入力がすべてシステムによって処理されるため、独自のコントロールには入力が届きません。
- 対話型コントロールは、SetTitleBar の呼び出しによって定義されたドラッグ可能領域より上部 (z オーダーでの上位) に配置します。 対話型コントロールは、SetTitleBar に渡される UIElement の子にしないでください。 SetTitleBar に渡した要素は、システムのタイトル バーと同様に扱われ、その要素へのポインター入力がすべてシステムによって処理されます。

以下のコードで、`TitleBarButton` 要素は z オーダーが `AppTitleBar` より上位であるため、ユーザー入力を受け取ります。

```xaml
<Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
    <Grid.RowDefinitions>
        <RowDefinition Height="Auto"/>
        <RowDefinition />
    </Grid.RowDefinitions>

    <Grid x:Name="AppTitleBar" Background="Transparent">
        <!-- Width of the padding columns is set in LayoutMetricsChanged handler. -->
        <!-- Using padding columns instead of Margin ensures that the background
             paints the area under the caption control buttons (for transparent buttons). -->
        <Grid.ColumnDefinitions>
            <ColumnDefinition x:Name="LeftPaddingColumn" Width="0"/>
            <ColumnDefinition/>
            <ColumnDefinition x:Name="RightPaddingColumn" Width="0"/>
        </Grid.ColumnDefinitions>
        <Image Source="Assets/Square44x44Logo.png"
               Grid.Column="1" HorizontalAlignment="Left"
               Width="20" Height="20" Margin="12,0"/>
        <TextBlock Text="Custom Title Bar"
                   Grid.Column="1"
                   Style="{StaticResource CaptionTextBlockStyle}"
                   Margin="44,8,0,0"/>
    </Grid>

    <!-- This Button has a higher z-order than AppTitleBar, 
         so it receives user input. -->
    <Button x:Name="TitleBarButton" Content="Button in the title bar"
        HorizontalAlignment="Right"/>
</Grid>
```

### <a name="transparency-in-caption-buttons"></a>タイトル ボタンの透明度

ExtendViewIntoTitleBar を **true** に設定すると、アプリの背景が透けるように、タイトル ボタンの背景を透明にすることができます。 一般的には、背景を [Colors.Transparent](https://docs.microsoft.com/uwp/api/windows.ui.colors.Transparent) に設定して完全な透明にします。 部分的に透明にするには、プロパティ設定対象の [Color](https://docs.microsoft.com/uwp/api/windows.ui.color) にアルファ チャネルを設定します。

以下の ApplicationViewTitleBar プロパティは透明にすることができます。

- ButtonBackgroundColor
- ButtonHoverBackgroundColor
- ButtonPressedBackgroundColor
- ButtonInactiveBackgroundColor

ボタンの背景色は、[閉じる] ボタンのホバー時および押下時の状態に適用されません。 [閉じる] ボタンがこれらの状態の場合は、常にシステム定義の色が使用されます。

その他のすべての色プロパティでは、引き続きアルファ チャネルが無視されます。 ExtendViewIntoTitleBar が **false** に設定されている場合は、すべての ApplicationViewTitleBar 色プロパティについて、アルファ チャネルが常に無視されます。

### <a name="full-screen-and-tablet-mode"></a>全画面とタブレット モード

アプリが_全画面_または_タブレット モード_で実行されている場合は、タイトル バーとタイトル コントロール ボタンが非表示になります。 ただし、ユーザーがタイトル バーを呼び出し、アプリ UI の上にオーバーレイとして表示することもあります。
タイトル バーが非表示になった場合または呼び出された場合の通知を受け取り、必要に応じてカスタムのタイトル バー コンテンツを表示または非表示にするには、[CoreApplicationViewTitleBar.IsVisibleChanged](https://docs.microsoft.com/uwp/api/windows.applicationmodel.core.coreapplicationviewtitlebar.IsVisibleChanged) イベントを処理します。

この例では、IsVisibleChanged を処理して、前に表示されていた `AppTitleBar` 要素を表示または非表示にする方法を示しています。

```csharp
public MainPage()
{
    this.InitializeComponent();

    var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;

    // Register a handler for when the title bar visibility changes.
    // For example, when the title bar is invoked in full screen mode.
    coreTitleBar.IsVisibleChanged += CoreTitleBar_IsVisibleChanged;
}

private void CoreTitleBar_IsVisibleChanged(CoreApplicationViewTitleBar sender, object args)
{
    if (sender.IsVisible)
    {
        AppTitleBar.Visibility = Visibility.Visible;
    }
    else
    {
        AppTitleBar.Visibility = Visibility.Collapsed;
    }
}
```

>[!NOTE]
>_全画面表示_モードは、アプリでサポートされている場合にのみ使用できます。 詳しくは、[ApplicationView.IsFullScreenMode](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.applicationview.IsFullScreenMode) をご覧ください。 [_タブレット モード_](https://support.microsoft.com/help/17210/windows-10-use-your-pc-like-a-tablet)は、サポートされているハードウェア上のユーザー オプションであり、ユーザーは任意のアプリをタブレット モードで実行できます。

## <a name="full-customization-example"></a>全面的なカスタマイズの例

```xaml
<Page
    x:Class="CustomTitleBar.MainPage"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:local="using:CustomTitleBar"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    mc:Ignorable="d">

    <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/>
            <RowDefinition />
        </Grid.RowDefinitions>

        <Grid x:Name="AppTitleBar" Background="Transparent">
            <!-- Width of the padding columns is set in LayoutMetricsChanged handler. -->
            <!-- Using padding columns instead of Margin ensures that the background
                 paints the area under the caption control buttons (for transparent buttons). -->
            <Grid.ColumnDefinitions>
                <ColumnDefinition x:Name="LeftPaddingColumn" Width="0"/>
                <ColumnDefinition/>
                <ColumnDefinition x:Name="RightPaddingColumn" Width="0"/>
            </Grid.ColumnDefinitions>
            <Image Source="Assets/Square44x44Logo.png" 
                   Grid.Column="1" HorizontalAlignment="Left" 
                   Width="20" Height="20" Margin="12,0"/>
            <TextBlock Text="Custom Title Bar" 
                       Grid.Column="1" 
                       Style="{StaticResource CaptionTextBlockStyle}" 
                       Margin="44,8,0,0"/>
        </Grid>

        <!-- This Button has a higher z-order than MyTitleBar, 
             so it receives user input. -->
        <Button x:Name="TitleBarButton" Content="Button in the title bar"
                HorizontalAlignment="Right"/>
    </Grid>
</Page>
```

```csharp
public MainPage()
{
    this.InitializeComponent();

    // Hide default title bar.
    var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
    coreTitleBar.ExtendViewIntoTitleBar = true;
    UpdateTitleBarLayout(coreTitleBar);

    // Set XAML element as a draggable region.
    Window.Current.SetTitleBar(AppTitleBar);

    // Register a handler for when the size of the overlaid caption control changes.
    // For example, when the app moves to a screen with a different DPI.
    coreTitleBar.LayoutMetricsChanged += CoreTitleBar_LayoutMetricsChanged;

    // Register a handler for when the title bar visibility changes.
    // For example, when the title bar is invoked in full screen mode.
    coreTitleBar.IsVisibleChanged += CoreTitleBar_IsVisibleChanged;
}

private void CoreTitleBar_LayoutMetricsChanged(CoreApplicationViewTitleBar sender, object args)
{
    UpdateTitleBarLayout(sender);
}

private void UpdateTitleBarLayout(CoreApplicationViewTitleBar coreTitleBar)
{
    // Get the size of the caption controls area and back button 
    // (returned in logical pixels), and move your content around as necessary.
    LeftPaddingColumn.Width = new GridLength(coreTitleBar.SystemOverlayLeftInset);
    RightPaddingColumn.Width = new GridLength(coreTitleBar.SystemOverlayRightInset);
    TitleBarButton.Margin = new Thickness(0,0,coreTitleBar.SystemOverlayRightInset,0);

    // Update title bar control size as needed to account for system size changes.
    AppTitleBar.Height = coreTitleBar.Height;
}

private void CoreTitleBar_IsVisibleChanged(CoreApplicationViewTitleBar sender, object args)
{
    if (sender.IsVisible)
    {
        AppTitleBar.Visibility = Visibility.Visible;
    }
    else
    {
        AppTitleBar.Visibility = Visibility.Collapsed;
    }
}
```

## <a name="dos-and-donts"></a>推奨と非推奨

- ウィンドウがアクティブまたは非アクティブであるときには、それをわかりやすく示してください。 少なくとも、タイトル バーのテキスト、アイコン、ボタンの色を変更してください。
- ドラッグ可能領域は、アプリ キャンバスの上端に沿って定義してください。 システム タイトル バーの配置に合わせると、ユーザーから見つけやすくなります。
- ドラッグ可能領域は、アプリ キャンバス上に表示されるタイトル バー (ある場合) に合わせて定義してください。

## <a name="related-articles"></a>関連記事

- [アクリル](../style/acrylic.md)
- [色](../style/color.md)
