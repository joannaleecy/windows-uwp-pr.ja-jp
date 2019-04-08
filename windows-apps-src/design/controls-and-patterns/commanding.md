---
title: コマンドの実行でユニバーサル Windows プラットフォーム (UWP) アプリ
description: (ICommand インターフェイス) と共に XamlUICommand と StandardUICommand クラスを使用して、共有し、さまざまなデバイスに関係なく、種類のコントロールを使用している入力の種類のコマンドを管理する方法。
author: Karl-Bridge-Microsoft
ms.service: ''
ms.topic: overview
ms.date: 11/01/2018
ms.author: kbridge
ms.openlocfilehash: 32d5005f9965b14d5080344832eb185f0e711689
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57646527"
---
# <a name="commanding-in-universal-windows-platform-uwp-apps-using-standarduicommand-xamluicommand-and-icommand"></a>StandardUICommand、XamlUICommand、ICommand を使用してユニバーサル Windows プラットフォーム (UWP) アプリでコマンド処理

このトピックでは、ユニバーサル Windows プラットフォーム (UWP) アプリケーションでコマンド処理について説明します。 使用する方法について説明します具体的には、 [XamlUICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.xamluicommand)と[StandardUICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.standarduicommand)を共有し、コマンドの管理のさまざまなコントロールの種類に関係なく (ICommand インターフェイス) と共にクラス入力の種類とデバイスの使用されています。

![共有のコマンドの一般的な使用方法を表すダイアグラム: '任意' コマンドを使用して複数の UI が表示されます](images/commanding/generic-commanding.png)

*デバイスと、入力の種類に関係なく、さまざまなコントロール間で共有コマンド*

## <a name="important-apis"></a>重要な API

- [Windows.UI.Xaml.Input.ICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.icommand)と[System.Windows.Input.ICommand](https://docs.microsoft.com/dotnet/api/system.windows.input.icommand)
- [XamlUICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.xamluicommand)
- [StandardUICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.standarduicommand)

## <a name="overview"></a>概要

<!-- See https://blogs.msdn.microsoft.com/jebarson/2017/07/26/writing-an-asynchronous-relaycommand-implementing-icommand/ -->

<!-- A command describes an action but not its implementation (in other words, the what, but not the how). For example, the "Paste" command indicates that the user wants to copy something from the clipboard to a target control, but does not specify how. -->

コマンドは、ボタンをクリックしてまたはコンテキスト メニューから項目を選択するような UI 操作を使用して直接呼び出すことができます。 呼び出すことができましていない直接をキーボード アクセラレータ、ジェスチャ、音声認識、または automation/ユーザー補助ツールなどの入力デバイス。 呼び出されると後のコマンドは、しで処理できるコントロール (エディット コントロールでテキスト ナビゲーション) ウィンドウ (ナビゲーション)、またはアプリケーションを (終了)。

コマンド テキストを削除するか、アクションを元に戻すなど、アプリ内で特定のコンテキストを操作できるまたはオーディオのミュートまたは明るさの調整などのコンテキスト フリーになることができます。

次の図は 2 つのコマンド インターフェイス (、 [CommandBar](app-bars.md)浮動コンテキストと[CommandBarFlyout](command-bar-flyout.md)) と同じコマンドの多くを共有します。

![コマンド インターフェイスの例](images/commanding/command-interface-example.png)

## <a name="command-interactions"></a>コマンドの相互作用

により、さまざまなデバイス、入力の種類、およびコマンドの呼び出し方法に影響を与える UI の外観、できるだけ多くのコマンド実行画面から、コマンドを公開することをお勧めします。 これらの組み合わせを含めることができます[スワイプ](swipe.md)、 [MenuBar](menus.md)、 [CommandBar](app-bars.md)、 [CommandBarFlyout](command-bar-flyout.md)、従来と[コンテキスト メニュー](menus.md)します。

**重要なコマンドは、入力に固有のアクセラレータを使用します。** 入力のアクセラレータを使用している入力デバイスに応じてすばやく操作を実行することができます。

いくつかの一般的な入力アクセラレータのさまざまな入力の種類を次に示します。

- **ポインター** -マウス (& p) ボタンをホバー
- **キーボード**-ショートカット (アクセス キーとアクセラレータ キー)
- **タッチ**-スワイプ
- **タッチ**-データを更新するプル

アプリケーションの機能を普遍的にアクセスできるようにする入力タイプとユーザー エクスペリエンスを検討する必要があります。 たとえば、コレクション (特にユーザー編集可能なもの) には通常、さまざまな入力デバイスによって大きく異なる実行される特定のコマンドが含まれます。

次の表は、いくつかの一般的なコレクション コマンドとこれらのコマンドを公開する方法を示します。

| コマンド          | 入力方法を問わない | マウス アクセラレータ | キーボード アクセラレータ | タッチ アクセラレータ |
| ---------------- | -------------- | ----------------- | -------------------- | ----------------- |
| 項目の削除      | ショートカット メニュー   | ホバー ボタン      | DEL キー              | スワイプして削除   |
| フラグの設定        | ショートカット メニュー   | ホバー ボタン      | Ctrl + Shift + G         | スワイプしてフラグを設定     |
| データの更新     | ショートカット メニュー   | なし               | F5 キー               | 引っ張って更新   |
| お気に入りに追加 | ショートカット メニュー   | ホバー ボタン      | F、Ctrl + S            | スワイプしてお気に入りに追加 |

**コンテキスト メニューを常に提供**をお勧めの従来のコンテキスト メニューまたは CommandBarFlyout、関連するすべてのコンテキストに応じたコマンドを含むすべての種類の入力の両方がサポートされています。 たとえば、コマンドが、ポインターのホバー イベント中にのみ公開されている場合、タッチ専用デバイスで使用できません。

## <a name="commands-in-uwp-applications"></a>UWP アプリケーションでのコマンド

共有および UWP アプリケーションでのコマンド実行のエクスペリエンスを管理できるいくつかの方法はあります。 (これはできない、UI の複雑さによっては、非常に効率的な) 分離コードでのクリックなどの標準的なやり取りのイベント ハンドラーを定義することができます。、標準的な対話のイベント リスナーをバインドするには、共有のハンドラーに、またはコントロールのバインドすることができます。コマンド ロジックを記述する ICommand 実装にコマンドのプロパティです。

バインディングでは、このトピックで説明されている機能のコマンドを使用してお勧めを効率的かつ最小限のコードの重複は、コマンドのサーフェイスにわたって機能が豊富で包括的なユーザー エクスペリエンスを提供するに (標準的なイベント処理のため、個々 のイベントのトピックを参照してください)。

コマンドの共有リソースにコントロールをバインドする、自分で ICommand インターフェイスを実装できますまたはいずれかから、コマンドをビルドすることができます、 [XamlUICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.xamluicommand)基底クラスまたはそのいずれかで定義されているプラットフォームのコマンド、 [StandardUICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.standarduicommand)クラスを派生します。

- ICommand インターフェイス ([Windows.UI.Xaml.Input.ICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.icommand)または[System.Windows.Input.ICommand](https://docs.microsoft.com/dotnet/api/system.windows.input.icommand)) を作成する完全にカスタマイズされたアプリ間で再利用可能なコマンドを使用することができます。
- [XamlUICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.xamluicommand)もこの機能を提供しますが、一連のコマンドの動作、キーボード ショートカット (アクセス キーとアクセラレータ キー)、アイコン、ラベル、および説明などの組み込みコマンドのプロパティを公開することで開発を簡略化されます。
- [StandardUICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.standarduicommand)から定義済みのプロパティを持つ標準プラットフォームのコマンドのセットを選択することで、さらを簡略化します。

> [!Important]
> コマンドのいずれかの実装は、UWP アプリケーションで、 [Windows.UI.Xaml.Input.ICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.icommand) (C++) または[System.Windows.Input.ICommand](https://docs.microsoft.com/dotnet/api/system.windows.input.icommand) (C#) に応じて、選択したインターフェイス言語フレームワーク。

## <a name="command-experiences-using-the-standarduicommand-class"></a>StandardUICommand クラスを使用してコマンドのエクスペリエンス

派生した[XamlUiCommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.xamluicommand) (から派生した[Windows.UI.Xaml.Input.ICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.icommand) c++ または[System.Windows.Input.ICommand](https://docs.microsoft.com/dotnet/api/system.windows.input.icommand)のC#)、 [StandardUICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.standarduicommand)クラスは、アイコン、キーボード アクセス キー、および説明などの定義済みのプロパティを持つ標準プラットフォームのコマンドのセットを公開します。

A [StandardUICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.standarduicommand)などの一般的なコマンドを定義する迅速かつ一貫した方法を提供します`Save`または`Delete`します。 Execute と canExecute 関数を指定するだけです。

### <a name="example"></a>例

![StandardUICommand サンプル](images/commanding/StandardUICommandSampleOptimized.gif)

*StandardUICommandSample*

この例では、基本的なを強化する方法を説明します[ListView](listview-and-gridview.md)コマンドを使用して実装を項目の削除、 [StandardUICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.standarduicommand)入力の種類のさまざまなユーザー エクスペリエンスを最適化する際に、クラス使用して、 [MenuBar](menus.md)、[スワイプ](swipe.md)コントロール、ボタンのポイントと[コンテキスト メニュー](menus.md)します。

> [!NOTE]
> このサンプルの一部である Microsoft.UI.Xaml.Controls NuGet パッケージが必要です、 [Microsoft Windows の UI ライブラリ](https://docs.microsoft.com/uwp/toolkits/winui/)します。

**Xaml:**

UI を含むサンプル、 [ListView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.listview) 5 つの項目。 削除[StandardUICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.standarduicommand)にバインドされて、 [MenuBarItem](https://docs.microsoft.com/uwp/api/microsoft.ui.xaml.controls.menubaritem)、 [SwipeItem](https://docs.microsoft.com/uwp/api/microsoft.ui.xaml.controls.swipeitem)、 [AppBarButton](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.appbarbutton)、および[ContextFlyout メニュー](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.contextflyout)します。

``` xaml
<Page
    x:Class="StandardUICommandSample.MainPage"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:local="using:StandardUICommandSample"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    xmlns:muxcontrols="using:Microsoft.UI.Xaml.Controls"
    mc:Ignorable="d"
    Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">

    <Page.Resources>
        <Style x:Key="HorizontalSwipe" 
               TargetType="ListViewItem" 
               BasedOn="{StaticResource ListViewItemRevealStyle}">
            <Setter Property="Height" Value="60"/>
            <Setter Property="Padding" Value="0"/>
            <Setter Property="HorizontalContentAlignment" Value="Stretch"/>
            <Setter Property="VerticalContentAlignment" Value="Stretch"/>
            <Setter Property="BorderThickness" Value="0"/>
        </Style>
    </Page.Resources>

    <Grid Loaded="ControlExample_Loaded">
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto" />
            <RowDefinition Height="Auto" />
            <RowDefinition Height="*"/>
        </Grid.RowDefinitions>

        <StackPanel Grid.Row="0" 
                    Padding="10" 
                    BorderThickness="0,0,0,1" 
                    BorderBrush="LightBlue"
                    Background="AliceBlue">
            <TextBlock Style="{StaticResource HeaderTextBlockStyle}">
                StandardUICommand sample
            </TextBlock>
            <TextBlock Style="{StaticResource SubtitleTextBlockStyle}" Margin="0,0,0,10">
                This sample shows how to use the StandardUICommand class to 
                share a platform command and consistent user experiences 
                across various controls.
            </TextBlock>
            <TextBlock Style="{StaticResource SubtitleTextBlockStyle}" Margin="0,0,0,0">
                Specifically, we define a standard delete command and add it 
                to a variety of command surfaces, all of which share a common 
                icon, label, keyboard accelerator, and description.
            </TextBlock>
        </StackPanel>

        <muxcontrols:MenuBar Grid.Row="1" Padding="10">
            <muxcontrols:MenuBarItem Title="File">
            </muxcontrols:MenuBarItem>
            <muxcontrols:MenuBarItem Title="Edit">
                <MenuFlyoutItem x:Name="DeleteFlyoutItem"/>
            </muxcontrols:MenuBarItem>
            <muxcontrols:MenuBarItem Title="Help">
            </muxcontrols:MenuBarItem>
        </muxcontrols:MenuBar>

        <ListView x:Name="ListViewRight" Grid.Row="2" 
                  Loaded="ListView_Loaded" 
                  IsItemClickEnabled="True" 
                  SelectionMode="Single" 
                  SelectionChanged="ListView_SelectionChanged" 
                  ItemContainerStyle="{StaticResource HorizontalSwipe}">
            <ListView.ItemTemplate>
                <DataTemplate x:DataType="local:ListItemData">
                    <UserControl PointerEntered="ListViewSwipeContainer_PointerEntered" 
                                 PointerExited="ListViewSwipeContainer_PointerExited">
                        <UserControl.ContextFlyout>
                            <MenuFlyout>
                                <MenuFlyoutItem 
                                    Command="{x:Bind Command}" 
                                    CommandParameter="{x:Bind Text}" />
                            </MenuFlyout>
                        </UserControl.ContextFlyout>
                        <Grid AutomationProperties.Name="{x:Bind Text}">
                            <VisualStateManager.VisualStateGroups>
                                <VisualStateGroup x:Name="HoveringStates">
                                    <VisualState x:Name="HoverButtonsHidden" />
                                    <VisualState x:Name="HoverButtonsShown">
                                        <VisualState.Setters>
                                            <Setter Target="HoverButton.Visibility" 
                                                    Value="Visible" />
                                        </VisualState.Setters>
                                    </VisualState>
                                </VisualStateGroup>
                            </VisualStateManager.VisualStateGroups>
                            <SwipeControl x:Name="ListViewSwipeContainer" >
                                <SwipeControl.RightItems>
                                    <SwipeItems Mode="Execute">
                                        <SwipeItem x:Name="DeleteSwipeItem" 
                                                   Background="Red" 
                                                   Command="{x:Bind Command}" 
                                                   CommandParameter="{x:Bind Text}"/>
                                    </SwipeItems>
                                </SwipeControl.RightItems>
                                <Grid VerticalAlignment="Center">
                                    <TextBlock Text="{x:Bind Text}" 
                                               Margin="10" 
                                               FontSize="18" 
                                               HorizontalAlignment="Left" 
                                               VerticalAlignment="Center"/>
                                    <AppBarButton x:Name="HoverButton" 
                                                  IsTabStop="False" 
                                                  HorizontalAlignment="Right" 
                                                  Visibility="Collapsed" 
                                                  Command="{x:Bind Command}" 
                                                  CommandParameter="{x:Bind Text}"/>
                                </Grid>
                            </SwipeControl>
                        </Grid>
                    </UserControl>
                </DataTemplate>
            </ListView.ItemTemplate>
        </ListView>
    </Grid>
</Page>
```

**分離コード**

1. 最初に、定義、`ListItemData`それぞれの ListViewItem、ListView 内のテキスト文字列と ICommand を含むクラスです。

```csharp
public class ListItemData
{
    public String Text { get; set; }
    public ICommand Command { get; set; }
}
```

2. MainPage クラスでのコレクションを定義します。`ListItemData`オブジェクトに対する、 [DataTemplate](https://docs.microsoft.com/uwp/api/windows.ui.xaml.datatemplate)の、 [ListView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.listview) [ItemTemplate](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.itemscontrol.itemtemplate)します。 5 つの項目の初期のコレクションを使用し、設定します (テキストと関連付けられた[StandardUICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.standarduicommand)削除) します。

```csharp
ObservableCollection<ListItemData> collection = new ObservableCollection<ListItemData>();

private void ControlExample_Loaded(object sender, RoutedEventArgs e)
{
    var deleteCommand = new StandardUICommand(StandardUICommandKind.Delete);
    deleteCommand.ExecuteRequested += DeleteCommand_ExecuteRequested;

    DeleteFlyoutItem.Command = deleteCommand;

    for (var i = 0; i < 5; i++)
    {
        collection.Add(new ListItemData { Text = "List item " + i.ToString(), Command = deleteCommand });
    }
}

private void ListView_Loaded(object sender, RoutedEventArgs e)
{
    var listView = (ListView)sender;
    listView.ItemsSource = collection;
}
```

3. 次に、項目の削除コマンドを実装して、ICommand ExecuteRequested ハンドラーを定義します。

``` csharp
private void DeleteCommand_ExecuteRequested(XamlUICommand sender, ExecuteRequestedEventArgs args)
{
    if (args.Parameter != null)
    {
        foreach (var i in collection)
        {
            if (i.Text == (args.Parameter as string))
            {
                collection.Remove(i);
                return;
            }
        }
    }
    if (ListViewRight.SelectedIndex != -1)
    {
        collection.RemoveAt(ListViewRight.SelectedIndex);
    }
}
```

4. 最後に、定義を含む、ListView のさまざまなイベントのハンドラー [PointerEntered](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.pointerentered)、 [PointerExited](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.pointerexited)、および[SelectionChanged](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.primitives.selector.selectionchanged)イベント。 ポインターのイベント ハンドラーは、各項目の削除 ボタンを非表示に使用されます。

```csharp
private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
{
    if (ListViewRight.SelectedIndex != -1)
    {
        var item = collection[ListViewRight.SelectedIndex];
    }
}

private void ListViewSwipeContainer_PointerEntered(object sender, PointerRoutedEventArgs e)
{
    if (e.Pointer.PointerDeviceType == Windows.Devices.Input.PointerDeviceType.Mouse || e.Pointer.PointerDeviceType == Windows.Devices.Input.PointerDeviceType.Pen)
    {
        VisualStateManager.GoToState(sender as Control, "HoverButtonsShown", true);
    }
}

private void ListViewSwipeContainer_PointerExited(object sender, PointerRoutedEventArgs e)
{
    VisualStateManager.GoToState(sender as Control, "HoverButtonsHidden", true);
}
```

## <a name="command-experiences-using-the-xamluicommand-class"></a>XamlUICommand クラスを使用してコマンドのエクスペリエンス

によって定義されていないコマンドを作成する必要があるかどうか、 [StandardUICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.standarduicommand)クラス、または希望コマンドの外観を細かく制御、 [XamlUiCommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.xamluicommand)クラスから派生、 [ICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.icommand)インターフェイス、さまざまな UI (アイコン、ラベル、説明、キーボード ショートカットなど) のプロパティ、メソッド、およびカスタム コマンドの動作と UI を簡単に定義のイベントを追加します。

[XamlUICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.xamluicommand)コントロールのアイコンなど、バインドを通じて UI を指定することができますが、説明、ラベルし、個々 のプロパティを設定せずのキーボード ショートカット (アクセス キーおよびキーボード アクセラレータの両方)、します。

### <a name="example"></a>例

![XamlUICommand サンプル](images/commanding/XamlUICommandSampleOptimized.gif)

*XamlUICommandSample*

この例は、以前の削除機能を共有[StandardUICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.standarduicommand)などが表示されますが、どのように[XamlUICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.xamluicommand)クラスでは、独自のフォントのアイコンとカスタム削除コマンドを定義できますラベル、。キーボード アクセス キー、および説明します。 ように、 [StandardUICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.standarduicommand)例では、基本的なを向上させ[ListView](listview-and-gridview.md)コマンドを使用して実装を項目の削除、 [XamlUICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.xamluicommand)を最適化しつつ、クラス、使用して入力の型のさまざまなユーザー エクスペリエンスを[MenuBar](menus.md)、[スワイプ](swipe.md)コントロール、ボタンのポイントと[コンテキスト メニュー](menus.md)します。

多くのプラットフォーム コントロールでは、実際には、前のセクションでは、この StandardUICommand 例と同様の XamlUICommand プロパティを使用します。 

> [!NOTE]
> このサンプルの一部である Microsoft.UI.Xaml.Controls NuGet パッケージが必要です、 [Microsoft Windows の UI ライブラリ](https://docs.microsoft.com/uwp/toolkits/winui/)します。

**Xaml:**

UI を含むサンプル、 [ListView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.listview) 5 つの項目。 カスタム[XamlUICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.xamluicommand) Delete にバインドされて、 [MenuBarItem](https://docs.microsoft.com/uwp/api/microsoft.ui.xaml.controls.menubaritem)、 [SwipeItem](https://docs.microsoft.com/uwp/api/microsoft.ui.xaml.controls.swipeitem)、 [AppBarButton](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.appbarbutton)、および[ContextFlyout メニュー](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.contextflyout)します。

``` xaml
<Page
    x:Class="XamlUICommand_Sample.MainPage"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:local="using:XamlUICommand_Sample"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    xmlns:muxcontrols="using:Microsoft.UI.Xaml.Controls"
    mc:Ignorable="d"
    Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">

    <Page.Resources>
        <XamlUICommand x:Name="CustomXamlUICommand" ExecuteRequested="DeleteCommand_ExecuteRequested" Description="Custom XamlUICommand" Label="Custom XamlUICommand">
            <XamlUICommand.IconSource>
                <FontIconSource FontFamily="Wingdings" Glyph="&#x4D;"/>
            </XamlUICommand.IconSource>
            <XamlUICommand.KeyboardAccelerators>
                <KeyboardAccelerator Key="D" Modifiers="Control"/>
            </XamlUICommand.KeyboardAccelerators>
        </XamlUICommand>

        <Style x:Key="HorizontalSwipe" 
               TargetType="ListViewItem" 
               BasedOn="{StaticResource ListViewItemRevealStyle}">
            <Setter Property="Height" Value="70"/>
            <Setter Property="Padding" Value="0"/>
            <Setter Property="HorizontalContentAlignment" Value="Stretch"/>
            <Setter Property="VerticalContentAlignment" Value="Stretch"/>
            <Setter Property="BorderThickness" Value="0"/>
        </Style>
        
    </Page.Resources>

    <Grid Loaded="ControlExample_Loaded" Name="MainGrid">
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto" />
            <RowDefinition Height="Auto" />
            <RowDefinition Height="*"/>
        </Grid.RowDefinitions>
        
        <StackPanel Grid.Row="0" 
                    Padding="10" 
                    BorderThickness="0,0,0,1" 
                    BorderBrush="LightBlue"
                    Background="AliceBlue">
            <TextBlock Style="{StaticResource HeaderTextBlockStyle}">
                XamlUICommand sample
            </TextBlock>
            <TextBlock Style="{StaticResource SubtitleTextBlockStyle}" Margin="0,0,0,10">
                This sample shows how to use the XamlUICommand class to 
                share a custom command with consistent user experiences 
                across various controls.
            </TextBlock>
            <TextBlock Style="{StaticResource SubtitleTextBlockStyle}" Margin="0,0,0,0">
                Specifically, we define a custom delete command and add it 
                to a variety of command surfaces, all of which share a common 
                icon, label, keyboard accelerator, and description.
            </TextBlock>
        </StackPanel>

        <muxcontrols:MenuBar Grid.Row="1">
            <muxcontrols:MenuBarItem Title="File">
            </muxcontrols:MenuBarItem>
            <muxcontrols:MenuBarItem Title="Edit">
                <MenuFlyoutItem x:Name="DeleteFlyoutItem" Command="{StaticResource CustomXamlUICommand}"/>
            </muxcontrols:MenuBarItem>
            <muxcontrols:MenuBarItem Title="Help">
            </muxcontrols:MenuBarItem>
        </muxcontrols:MenuBar>

        <ListView x:Name="ListViewRight" Grid.Row="2" 
                  Loaded="ListView_Loaded" 
                  IsItemClickEnabled="True"
                  SelectionMode="Single" 
                  SelectionChanged="ListView_SelectionChanged" 
                  ItemContainerStyle="{StaticResource HorizontalSwipe}">
            <ListView.ItemTemplate>
                <DataTemplate x:DataType="local:ListItemData">
                    <UserControl PointerEntered="ListViewSwipeContainer_PointerEntered"
                                 PointerExited="ListViewSwipeContainer_PointerExited">
                        <UserControl.ContextFlyout>
                            <MenuFlyout>
                                <MenuFlyoutItem 
                                    Command="{x:Bind Command}" 
                                    CommandParameter="{x:Bind Text}" />
                            </MenuFlyout>
                        </UserControl.ContextFlyout>
                        <Grid AutomationProperties.Name="{x:Bind Text}">
                            <VisualStateManager.VisualStateGroups>
                                <VisualStateGroup x:Name="HoveringStates">
                                    <VisualState x:Name="HoverButtonsHidden" />
                                    <VisualState x:Name="HoverButtonsShown">
                                        <VisualState.Setters>
                                            <Setter Target="HoverButton.Visibility" 
                                                    Value="Visible" />
                                        </VisualState.Setters>
                                    </VisualState>
                                </VisualStateGroup>
                            </VisualStateManager.VisualStateGroups>
                            <SwipeControl x:Name="ListViewSwipeContainer">
                                <SwipeControl.RightItems>
                                    <SwipeItems Mode="Execute">
                                        <SwipeItem x:Name="DeleteSwipeItem"
                                                   Background="Red" 
                                                   Command="{x:Bind Command}" 
                                                   CommandParameter="{x:Bind Text}"/>
                                    </SwipeItems>
                                </SwipeControl.RightItems>
                                <Grid VerticalAlignment="Center">
                                    <TextBlock Text="{x:Bind Text}" 
                                               Margin="10" 
                                               FontSize="18" 
                                               HorizontalAlignment="Left"       
                                               VerticalAlignment="Center"/>
                                    <AppBarButton x:Name="HoverButton" 
                                                  IsTabStop="False" 
                                                  HorizontalAlignment="Right" 
                                                  Visibility="Collapsed" 
                                                  Command="{x:Bind Command}" 
                                                  CommandParameter="{x:Bind Text}"/>
                                </Grid>
                            </SwipeControl>
                        </Grid>
                    </UserControl>
                </DataTemplate>
            </ListView.ItemTemplate>
        </ListView>
    </Grid>
</Page>
```

**分離コード**

1. 最初に、定義、`ListItemData`それぞれの ListViewItem、ListView 内のテキスト文字列と ICommand を含むクラスです。

```csharp
public class ListItemData
{
    public String Text { get; set; }
    public ICommand Command { get; set; }
}
```

2. MainPage クラスでのコレクションを定義します。`ListItemData`オブジェクトに対する、 [DataTemplate](https://docs.microsoft.com/uwp/api/windows.ui.xaml.datatemplate)の、 [ListView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.listview) [ItemTemplate](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.itemscontrol.itemtemplate)します。 5 つの項目の初期のコレクションを使用し、設定します (テキストと関連付けられた[XamlUICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.xamluicommand))。

```csharp
ObservableCollection<ListItemData> collection = new ObservableCollection<ListItemData>();

private void ControlExample_Loaded(object sender, RoutedEventArgs e)
{
    for (var i = 0; i < 5; i++)
    {
        collection.Add(new ListItemData { Text = "List item " + i.ToString(), Command = CustomXamlUICommand });
    }
}

private void ListView_Loaded(object sender, RoutedEventArgs e)
{
    var listView = (ListView)sender;
    listView.ItemsSource = collection;
}
```

3. 次に、項目の削除コマンドを実装して、ICommand ExecuteRequested ハンドラーを定義します。

``` csharp
private void DeleteCommand_ExecuteRequested(XamlUICommand sender, ExecuteRequestedEventArgs args)
{
    if (args.Parameter != null)
    {
        foreach (var i in collection)
        {
            if (i.Text == (args.Parameter as string))
            {
                collection.Remove(i);
                return;
            }
        }
    }
    if (ListViewRight.SelectedIndex != -1)
    {
        collection.RemoveAt(ListViewRight.SelectedIndex);
    }
}
```

4. 最後に、定義を含む、ListView のさまざまなイベントのハンドラー [PointerEntered](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.pointerentered)、 [PointerExited](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.pointerexited)、および[SelectionChanged](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.primitives.selector.selectionchanged)イベント。 ポインターのイベント ハンドラーは、各項目の削除 ボタンを非表示に使用されます。

```csharp
private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
{
    if (ListViewRight.SelectedIndex != -1)
    {
        var item = collection[ListViewRight.SelectedIndex];
    }
}

private void ListViewSwipeContainer_PointerEntered(object sender, PointerRoutedEventArgs e)
{
    if (e.Pointer.PointerDeviceType == Windows.Devices.Input.PointerDeviceType.Mouse || e.Pointer.PointerDeviceType == Windows.Devices.Input.PointerDeviceType.Pen)
    {
        VisualStateManager.GoToState(sender as Control, "HoverButtonsShown", true);
    }
}

private void ListViewSwipeContainer_PointerExited(object sender, PointerRoutedEventArgs e)
{
    VisualStateManager.GoToState(sender as Control, "HoverButtonsHidden", true);
}
```

## <a name="command-experiences-using-the-icommand-interface"></a>ICommand インターフェイスを使用してコマンドのエクスペリエンス

標準の UWP コントロール (ボタン、リスト、選択、予定表、予測のテキスト) は、多くの一般的なコマンド エクスペリエンスの基礎を提供します。 コントロールの種類の完全な一覧を参照してください。[コントロールと UWP アプリのパターン](index.md)します。

構造化されたコマンド実行エクスペリエンスをサポートする最も基本的な方法は、ICommand インターフェイスの実装を定義する ([Windows.UI.Xaml.Input.ICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.icommand) c++ または[System.Windows.Input.ICommand](https://docs.microsoft.com/dotnet/api/system.windows.input.icommand)のC#)。  この ICommand インスタンスは、ボタンなどのコントロールにバインドできます。

> [!NOTE]
> 場合によっては、同じメソッドをクリック イベントと IsEnabled プロパティをプロパティにバインドするように効率的場合があります。

#### <a name="example"></a>例

![コマンド インターフェイスの例](images/commanding/icommand.gif)

*ICommand の例*
 
この例では 1 つのコマンドを呼び出すボタンを使用する方法を示します をクリックして、キーボード アクセス キー、およびマウス ホイールを回転します。

使用して 2 つ[Listview](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.listview)左、右から項目を移動するため、5 つの項目とその他の空の場合は、2 つのボタンが、ListView から左側、右側の ListView に項目の移動のいずれかのいずれかに設定されます。 各ボタンは、対応するコマンドにバインドされます (ViewModel.MoveRightCommand と ViewModel.MoveLeftCommand、それぞれ)、およびが有効になっているし、関連する ListView の項目数に基づいて自動的に無効になっています。

**次の XAML コードは、この例の UI を定義します。**

```xaml
<Page
    x:Class="UICommand1.View.MainPage"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:vm="using:UICommand1.ViewModel"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    mc:Ignorable="d"
    Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">

    <Page.Resources>
        <vm:OpacityConverter x:Key="opaque" />
    </Page.Resources>

    <Grid Name="ItemGrid"
          Background="AliceBlue"
          PointerWheelChanged="Page_PointerWheelChanged">
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="*"/>
            <ColumnDefinition Width="2*"/>
            <ColumnDefinition Width="*"/>
        </Grid.ColumnDefinitions>
        <ListView Grid.Column="0" VerticalAlignment="Center"
                  x:Name="CommandListView" 
                  ItemsSource="{x:Bind Path=ViewModel.ListItemLeft}" 
                  SelectionMode="None" IsItemClickEnabled="False" 
                  HorizontalAlignment="Right">
            <ListView.ItemTemplate>
                <DataTemplate x:DataType="vm:ListItemData">
                    <Grid VerticalAlignment="Center">
                        <AppBarButton Label="{x:Bind ListItemText}">
                            <AppBarButton.Icon>
                                <SymbolIcon Symbol="{x:Bind ListItemIcon}"/>
                            </AppBarButton.Icon>
                        </AppBarButton>
                    </Grid>
                </DataTemplate>
            </ListView.ItemTemplate>
        </ListView>
        <Grid Grid.Column="1" Margin="0,0,5,0"
              HorizontalAlignment="Center" 
              VerticalAlignment="Center">
            <Grid.RowDefinitions>
                <RowDefinition Height="*"/>
                <RowDefinition Height="*"/>
                <RowDefinition Height="*"/>
            </Grid.RowDefinitions>
            <StackPanel Grid.Row="1">
                <FontIcon FontFamily="{StaticResource SymbolThemeFontFamily}" 
                          FontSize="40" Glyph="&#xE893;" 
                          Opacity="{x:Bind Path=ViewModel.listItemLeft.Count, Mode=OneWay, Converter={StaticResource opaque}}"/>
                <Button Name="MoveItemRightButton" ToolTipService.ToolTip="Tooltip"
                        Margin="0,10,0,10" Width="120" HorizontalAlignment="Center"
                        Command="{x:Bind Path=ViewModel.MoveRightCommand, Mode=OneWay}">
                    <Button.KeyboardAccelerators>
                        <KeyboardAccelerator 
                            Modifiers="Control" 
                            Key="Add" />
                    </Button.KeyboardAccelerators>
                    <StackPanel>
                        <SymbolIcon Symbol="Next"/>
                        <TextBlock>Move item right</TextBlock>
                    </StackPanel>
                </Button>
                <Button Name="MoveItemLeftButton" 
                            Margin="0,10,0,10" Width="120" HorizontalAlignment="Center"
                            Command="{x:Bind Path=ViewModel.MoveLeftCommand, Mode=OneWay}">
                    <Button.KeyboardAccelerators>
                        <KeyboardAccelerator 
                            Modifiers="Control" 
                            Key="Subtract" />
                    </Button.KeyboardAccelerators>
                    <StackPanel>
                        <SymbolIcon Symbol="Previous"/>
                        <TextBlock>Move item left</TextBlock>
                    </StackPanel>
                </Button>
                <FontIcon FontFamily="{StaticResource SymbolThemeFontFamily}" 
                          FontSize="40" Glyph="&#xE892;"
                          Opacity="{x:Bind Path=ViewModel.listItemRight.Count, Mode=OneWay, Converter={StaticResource opaque}}"/>
            </StackPanel>
        </Grid>
        <ListView Grid.Column="2" 
                  x:Name="CommandListViewRight" 
                  VerticalAlignment="Center" 
                  IsItemClickEnabled="False" 
                  SelectionMode="None"
                  ItemsSource="{x:Bind Path=ViewModel.ListItemRight}" 
                  HorizontalAlignment="Left">
            <ListView.ItemTemplate>
                <DataTemplate x:DataType="vm:ListItemData">
                    <Grid VerticalAlignment="Center">
                        <AppBarButton Label="{x:Bind ListItemText}">
                            <AppBarButton.Icon>
                                <SymbolIcon Symbol="{x:Bind ListItemIcon}"/>
                            </AppBarButton.Icon>
                        </AppBarButton>
                    </Grid>
                </DataTemplate>
            </ListView.ItemTemplate>
        </ListView>
    </Grid>
</Page>
```

**上記の UI の分離コードを次に示します。**

分離コードでは、このコマンド コードを含むビュー モデルに接続します。 さらに、マウスのホイール コマンド コードにも接続からの入力のハンドラーを定義します。

```csharp
using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Controls;
using UICommand1.ViewModel;
using Windows.System;
using Windows.UI.Core;

namespace UICommand1.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        // Reference to our view model.
        public UICommand1ViewModel ViewModel { get; set; }

        // Initialize our view and view model.
        public MainPage()
        {
            this.InitializeComponent();
            ViewModel = new UICommand1ViewModel();
        }

        /// <summary>
        /// Handle mouse wheel input and assign our
        /// commands to appropriate direction of rotation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_PointerWheelChanged(object sender, PointerRoutedEventArgs e)
        {
            var props = e.GetCurrentPoint(sender as UIElement).Properties;

            // Require CTRL key and accept only vertical mouse wheel movement 
            // to eliminate accidental wheel input.
            if ((Window.Current.CoreWindow.GetKeyState(VirtualKey.Control) != 
                CoreVirtualKeyStates.None) && !props.IsHorizontalMouseWheel)
            {
                bool delta = props.MouseWheelDelta < 0 ? true : false;

                switch (delta)
                {
                    case true:
                        ViewModel.MoveRight();
                        break;
                    case false:
                        ViewModel.MoveLeft();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
```

**このビュー モデルからコードに示します。**

このビュー モデルでは、アプリで 2 つのコマンドの実行の詳細を定義、1 つの ListView を設定したり表示または非表示の各 ListView の項目数に基づくいくつか追加の UI の不透明度の値コンバーターを提供します。

```csharp
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace UICommand1.ViewModel
{
    /// <summary>
    /// UI properties for our list items.
    /// </summary>
    public class ListItemData
    {
        /// <summary>
        /// Gets and sets the list item content string.
        /// </summary>
        public string ListItemText { get; set; }
        /// <summary>
        /// Gets and sets the list item icon.
        /// </summary>
        public Symbol ListItemIcon { get; set; }
    }

    /// <summary>
    /// View Model that sets up a command to handle invoking the move item buttons.
    /// </summary>
    public class UICommand1ViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// The command to invoke when the Move item left button is pressed.
        /// </summary>
        public RelayCommand moveLeftCommand;
        public RelayCommand MoveLeftCommand { get => moveLeftCommand; private set { } }

        /// <summary>
        /// The command to invoke when the Move item right button is pressed.
        /// </summary>
        public RelayCommand moveRightCommand;
        public RelayCommand MoveRightCommand { get => moveRightCommand; private set { } }

        // Item collections
        public ObservableCollection<ListItemData> listItemLeft;
        public ObservableCollection<ListItemData> ListItemLeft { get => listItemLeft; private set { } }
        public ObservableCollection<ListItemData> listItemRight;
        public ObservableCollection<ListItemData> ListItemRight { get => listItemRight; private set { } }

        public ListItemData listItem;

        /// <summary>
        /// Sets up a command to handle invoking the move item buttons.
        /// </summary>
        public UICommand1ViewModel()
        {
            moveLeftCommand = new RelayCommand(new Action(MoveLeft), CanExecuteMoveLeftCommand);
            moveRightCommand = new RelayCommand(new Action(MoveRight), CanExecuteMoveRightCommand);

            listItemLeft = new ObservableCollection<ListItemData>();
            listItemRight = new ObservableCollection<ListItemData>();

            LoadItems();
        }

        /// <summary>
        ///  Populate our list of items.
        /// </summary>
        public void LoadItems()
        {
            for (var x = 0; x <= 4; x++)
            {
                listItem = new ListItemData();
                listItemLeft.Add(listItem);
                listItem.ListItemText = "Item " + listItemLeft.Count.ToString();
                listItem.ListItemIcon = Symbol.Emoji;
            }
        }

        /// <summary>
        /// Move left command valid when items present in the list on right.
        /// </summary>
        /// <returns>True, if count is greater than 0.</returns>
        private bool CanExecuteMoveLeftCommand()
        {
            return listItemRight.Count > 0;
        }

        /// <summary>
        /// Move right command valid when items present in the list on left.
        /// </summary>
        /// <returns>True, if count is greater than 0.</returns>
        private bool CanExecuteMoveRightCommand()
        {
            return listItemLeft.Count > 0;
        }

        /// <summary>
        /// The command implementation to execute when the Move item right button is pressed.
        /// </summary>
        public void MoveRight()
        {
            if (listItemLeft.Count > 0)
            {
                listItem = new ListItemData();
                listItemRight.Add(listItem);
                listItem.ListItemText = "Item " + listItemRight.Count.ToString();
                listItem.ListItemIcon = Symbol.Emoji;
                listItemLeft.RemoveAt(listItemLeft.Count - 1);
                moveRightCommand.RaiseCanExecuteChanged();
                moveLeftCommand.RaiseCanExecuteChanged();
            }
        }

        /// <summary>
        /// The command implementation to execute when the Move item left button is pressed.
        /// </summary>
        public void MoveLeft()
        {
            if (listItemRight.Count > 0)
            {
                listItem = new ListItemData();
                listItemLeft.Add(listItem);
                listItem.ListItemText = "Item " + listItemRight.Count.ToString();
                listItem.ListItemIcon = Symbol.Emoji;
                listItemRight.RemoveAt(listItemRight.Count - 1);
                moveRightCommand.RaiseCanExecuteChanged();
                moveLeftCommand.RaiseCanExecuteChanged();
            }
        }
    }

    /// <summary>
    /// Convert a collection count to an opacity value of 0.0 or 1.0.
    /// </summary>
    public class OpacityConverter : IValueConverter
    {
        /// <summary>
        /// Converts a collection count to an opacity value of 0.0 or 1.0.
        /// </summary>
        /// <param name="value">The bool passed in</param>
        /// <param name="targetType">Ignored.</param>
        /// <param name="parameter">Ignored</param>
        /// <param name="language">Ignored</param>
        /// <returns>1.0 if count > 0, otherwise returns 0.0</returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return ((int)value > 0 ? 1.0 : 0.0);
        }

        /// <summary>
        /// Not used, converter is not intended for two-way binding. 
        /// </summary>
        /// <param name="value">Ignored</param>
        /// <param name="targetType">Ignored</param>
        /// <param name="parameter">Ignored</param>
        /// <param name="language">Ignored</param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
```

**最後に、ICommand インターフェイスの実装を示します**

ここでは、実装するコマンドを定義、 [ICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.icommand)インターフェイスし、その他のオブジェクトにその機能を単純に中継します。

```csharp
using System;
using System.Windows.Input;

namespace UICommand1
{
    /// <summary>
    /// A command whose sole purpose is to relay its functionality 
    /// to other objects by invoking delegates. 
    /// The default return value for the CanExecute method is 'true'.
    /// <see cref="RaiseCanExecuteChanged"/> needs to be called whenever
    /// <see cref="CanExecute"/> is expected to return a different value.
    /// </summary>
    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        /// <summary>
        /// Raised when RaiseCanExecuteChanged is called.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Creates a new command that can always execute.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        public RelayCommand(Action execute)
            : this(execute, null)
        {
        }

        /// <summary>
        /// Creates a new command.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        /// <param name="canExecute">The execution status logic.</param>
        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            _execute = execute;
            _canExecute = canExecute;
        }

        /// <summary>
        /// Determines whether this <see cref="RelayCommand"/> can execute in its current state.
        /// </summary>
        /// <param name="parameter">
        /// Data used by the command. If the command does not require data to be passed, this object can be set to null.
        /// </param>
        /// <returns>true if this command can be executed; otherwise, false.</returns>
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute();
        }

        /// <summary>
        /// Executes the <see cref="RelayCommand"/> on the current command target.
        /// </summary>
        /// <param name="parameter">
        /// Data used by the command. If the command does not require data to be passed, this object can be set to null.
        /// </param>
        public void Execute(object parameter)
        {
            _execute();
        }

        /// <summary>
        /// Method used to raise the <see cref="CanExecuteChanged"/> event
        /// to indicate that the return value of the <see cref="CanExecute"/>
        /// method has changed.
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }
}
```

## <a name="summary"></a>概要

ユニバーサル Windows プラットフォームの提供できるようにするための堅牢性と柔軟性ようにコマンド実行システムを共有し、コントロールの種類、デバイス、および入力の型の間でのコマンドを管理するアプリを構築します。

UWP アプリ用のコマンドを構築するときに、次の方法を使用します。

- リッスンし、XAML またはコード ビハインドでイベントを処理
- イベント処理クリックなどのメソッドにバインドします。
- 独自の ICommand 実装を定義します。
- 事前に定義された一連のプロパティの独自の値を持つ XamlUICommand オブジェクトを作成します。
- 定義済みのプラットフォームのプロパティと値のセットで StandardUICommand オブジェクトを作成します。

## <a name="next-steps"></a>次のステップ

完全な例を示す、 [XamlUiCommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.xamluicommand)と[StandardUICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.standarduicommand)実装を参照してください、 [XAML コントロール ギャラリー](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics)サンプル。

## <a name="see-also"></a>関連項目

[コントロールと UWP アプリのパターン](index.md)

<!---Some context for the following links goes here
- [link to next logical step for the customer](global-quickstart-template.md)--->

<!--- Required:
In Overview articles, provide at least one next step and no more than three.
Next steps in overview articles will often link to a quickstart.
Use regular links; do not use a blue box link. What you link to will depend on what is really a next step for the customer.
Do not use a "More info section" or a "Resources section" or a "See also section".
--->