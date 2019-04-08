---
Description: コマンド バーのフライアウトは、アプリの最も一般的なタスクのインラインへのアクセスをユーザーに付与します。
title: コマンド バーのポップアップ
label: Command bar flyout
template: detail.hbs
ms.date: 10/02/2018
ms.topic: article
keywords: windows 10, uwp
pm-contact: abarlow
design-contact: ksulliv
dev-contact: llongley
doc-status: Draft
ms.localizationpriority: medium
ms.custom: RS5
ms.openlocfilehash: cb87bea001492e39a0f60b96f884db70b5bd28ad
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57592527"
---
# <a name="command-bar-flyout"></a>コマンド バーのポップアップ

コマンド バーのフライアウトを使用して、UI キャンバス上の要素に関連するフローティング ツールバーでコマンドを表示することによって簡単にアクセスする一般的なタスクをユーザーに提供できます。

![テキスト コマンド バー フライアウト](images/command-bar-flyout-header.png)

> CommandBarFlyout には、Windows 10、バージョンは 1809 が必要です ([SDK 17763](https://developer.microsoft.com/windows/downloads/windows-10-sdk)) またはそれ以降、または[Windows UI ライブラリ](https://docs.microsoft.com/uwp/toolkits/winui/)します。

> - **プラットフォーム Api**:[CommandBarFlyout クラス](/uwp/api/windows.ui.xaml.controls.commandbarflyout)、 [TextCommandBarFlyout クラス](/uwp/api/windows.ui.xaml.controls.textcommandbarflyout)、 [AppBarButton クラス](/uwp/api/windows.ui.xaml.controls.appbarbutton)、 [AppBarToggleButton クラス](/uwp/api/windows.ui.xaml.controls.appbartogglebutton)、 [AppBarSeparator クラス](/uwp/api/windows.ui.xaml.controls.appbarseparator)
>- **Windows UI ライブラリ Api**:[CommandBarFlyout クラス](/uwp/api/microsoft.ui.xaml.controls.commandbarflyout)、 [TextCommandBarFlyout クラス](/uwp/api/microsoft.ui.xaml.controls.textcommandbarflyout)

ような[CommandBar](app-bars.md)、CommandBarFlyout が**PrimaryCommands**と**SecondaryCommands**プロパティを使用してコマンドを追加できます。 コマンドは、コレクション、またはその両方に配置できます。 プライマリとセカンダリのコマンドを表示するタイミングと方法は、表示モードによって異なります。

コマンド バーのフライアウトが 2 つの表示モード:*折りたたまれている*と*展開*します。

- 折りたたみのモードでは、プライマリ コマンドのみが表示されます。 場合のコマンド バーのフライアウトがあるプライマリとセカンダリの両方のコマンド、省略記号によって表される、「詳細」ボタン\[•\]が表示されます。 これにより、ユーザーの拡張モードに遷移するセカンダリ コマンドへのアクセスを取得します。
- 展開のモードでは、プライマリとセカンダリの両方のコマンドが表示されます。 (コントロールにセカンダリ項目のみがある場合に表示 MenuFlyout コントロールと同様の方法です。)

## <a name="is-this-the-right-control"></a>適切なコントロールの選択

コマンドのコレクションをボタンやメニュー項目は、アプリのキャンバス上の要素のコンテキストでユーザーに表示するのにには、CommandBarFlyout コントロールを使用します。

TextCommandBarFlyout では、TextBox、TextBlock、RichEditBox、RichTextBlock、および PasswordBox コントロールのテキスト コマンドが表示されます。 コマンドは、現在のテキストの選択を適切に構成に自動的には。 CommandBarFlyout を使用して、テキスト コントロールの既定のテキスト コマンドを置き換えます。

コンテキストを表示するリスト項目に対してコマンドがのガイダンスに従って[コレクションとリストのコンテキストのコマンドを実行](collection-commanding.md)します。

### <a name="commandbarflyout-vs-menuflyout"></a>CommandBarFlyout vs MenuFlyout

コンテキスト メニューのコマンドを表示するには、CommandBarFlyout または MenuFlyout を使用できます。 MenuFlyout より多くの機能を提供するため CommandBarFlyout をお勧めします。 セカンダリ コマンドのみで CommandBarFlyout を使ってを動作を取得し、MenuFlyout の探すか、完全なコマンド バーのフライアウトを使用して、プライマリとセカンダリの両方のコマンドを使用できます。

> 関連する情報は、次を参照してください。[フライアウト](../controls-and-patterns/dialogs-and-flyouts/flyouts.md)、[メニューおよびコンテキスト メニュー](menus.md)、および[コマンド バー](app-bars.md)します。

## <a name="examples"></a>例

<table>
<th align="left">XAML コントロール ギャラリー<th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p>ある場合、 <strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong>アプリをインストールするには、ここをクリックして<a href="xamlcontrolsgallery:/item/CommandBarFlyout">アプリを開き、アクションで CommandBarFlyout を参照してください。</a>します。</p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</a></li>
    <li><a href="https://github.com/Microsoft/Xaml-Controls-Gallery">ソース コード (GitHub) を入手する</a></li>
    </ul>
</td>
</tr>
</table>

## <a name="proactive-vs-reactive-invocation"></a>事前と事後対応型の呼び出し

フライアウトや UI キャンバス上の要素に関連付けられているメニューを呼び出す 2 つの方法は通常:_プロアクティブ呼び出し_と_事後対応型の呼び出し_します。

コマンドは事前対応型の呼び出しでは、ユーザーがコマンドに関連付けられている項目と対話するときに自動的に表示します。 たとえば、テキストの書式設定コマンドをポップアップ表示、ユーザーがテキスト ボックスでテキストを選択。 この場合、コマンド バーのフライアウトは、フォーカスは考慮されません。 代わりに、ユーザーが対話する項目の近くに関連するコマンドを表示します。 ユーザーは、コマンドを使用する操作とは、それらが閉じられます。

事後対応型の呼び出しでは、コマンドに表示されます、明示的なユーザー アクションに対する応答のコマンドを要求するにはたとえば、右クリックします。 これは、従来の概念に対応する[コンテキスト メニュー](menus.md)します。

方法、または 2 つの組み合わせでも CommandBarFlyout を使用することができます。

## <a name="create-a-command-bar-flyout"></a>コマンド バーのフライアウトを作成します。

この例では、コマンド バーのフライアウトを作成し、事前および事後対応的に使用する方法を示します。 イメージがタップされたときに、折りたたまれたモードで、フライアウトが表示されます。 、コンテキスト メニューとして表示されると、その展開されたモードで、フライアウトが表示されます。 どちらの場合、ユーザーは、展開または開かれた後で、フライアウトを折りたたみます。

![折りたたまれたコマンド バーのフライアウトの例](images/command-bar-flyout-img-collapsed.png)

> _折りたたまれたコマンド バーのフライアウト_

![展開されたコマンドのバー フライアウトの例](images/command-bar-flyout-img-expanded.png)

> _展開されたコマンドのバー フライアウト_

```xaml
<Grid>
    <Grid.Resources>
        <CommandBarFlyout x:Name="ImageCommandsFlyout">
            <AppBarButton Icon="OutlineStar" ToolTipService.ToolTip="Favorite"/>
            <AppBarButton Icon="Copy" ToolTipService.ToolTip="Copy"/>
            <AppBarButton Icon="Share" ToolTipService.ToolTip="Share"/>
            <CommandBarFlyout.SecondaryCommands>
                <AppBarButton Label="Select all"/>
                <AppBarButton Label="Delete" Icon="Delete"/>
            </CommandBarFlyout.SecondaryCommands>
        </CommandBarFlyout>
    </Grid.Resources>

    <Image Source="Assets/image1.png" Width="300"
           Tapped="Image_Tapped" FlyoutBase.AttachedFlyout="{x:Bind ImageCommandsFlyout}"
           ContextFlyout="{x:Bind ImageCommandsFlyout}"/>
</Grid>
```

```csharp
private void Image_Tapped(object sender, TappedRoutedEventArgs e)
{
    var flyout = FlyoutBase.GetAttachedFlyout((FrameworkElement)sender);
    var options = new FlyoutShowOptions()
    {
        // Position shows the flyout next to the pointer.
        // "Transient" ShowMode makes the flyout open in its collapsed state.
        Position = e.GetPosition((FrameworkElement)sender),
        ShowMode = FlyoutShowMode.Transient
    };
    flyout?.ShowAt((FrameworkElement)sender, options);
}
```

### <a name="show-commands-proactively"></a>事前にコマンドを表示します。

事前にコンテキストに応じたコマンドを表示する場合は、(コマンド バーのフライアウトを縮小する必要があります) 既定でプライマリ コマンドのみを表示する必要があります。 主要なコマンドのコレクションとコレクション内のセカンダリ コマンドに従来のコンテキスト メニューで行われるその他のコマンドでは、最も重要なコマンドを配置します。

処理する通常のコマンドを事前に表示する、[クリックして](/uwp/api/windows.ui.xaml.controls.primitives.buttonbase.click)または[Tapped](/uwp/api/windows.ui.xaml.uielement.tapped)コマンド バーのフライアウトを表示するイベント。 設定フライアウトの[ShowMode](/uwp/api/windows.ui.xaml.controls.primitives.flyoutbase.showmode)に**一時的な**または**TransientWithDismissOnPointerMoveAway**フォーカスすることがなく、折りたたみモードで、フライアウトを開きます。

以降、Windows 10 Insider Preview では、テキスト コントロールが、 **SelectionFlyout**プロパティ。 このプロパティにフライアウトを割り当てるときにテキストが選択されているときに自動的に表示されます。

### <a name="show-commands-reactively"></a>事後対応的にコマンドを表示します。

コンテキストに応じたコマンドをリアクティブ、コンテキスト メニューを表示すると、セカンダリ コマンド (コマンド バーのフライアウトを展開する必要があります) 既定で表示されます。 この場合、コマンド バーのフライアウトでは、プライマリとセカンダリの両方のコマンド、またはセカンダリ コマンドのみがあります。

に対するフライアウトの割り当てる通常コマンドのコンテキスト メニューを表示する、 [ContextFlyout](/uwp/api/windows.ui.xaml.uielement.contextflyout) UI 要素のプロパティ。 これによりは、要素によって処理されます、フライアウトを開くと何もする必要はありません。

フライアウトを自分で表示を処理する場合 (などで、 [RightTapped](/uwp/api/windows.ui.xaml.uielement.righttapped)イベント)、設定フライアウトの[ShowMode](/uwp/api/windows.ui.xaml.controls.primitives.flyoutbase.showmode)に**標準**拡張モードで、フライアウトを開くとフォーカスを設定します。

> [!TIP]
> フライアウトとフライアウトの位置を制御する方法を表示するときのオプションの詳細については、次を参照してください。[フライアウト](../controls-and-patterns/dialogs-and-flyouts/flyouts.md)します。

## <a name="commands-and-content"></a>コマンドとコンテンツ

CommandBarFlyout コントロールには、コマンドとコンテンツを追加するに使用できる 2 つのプロパティがあります。[PrimaryCommands](/uwp/api/windows.ui.xaml.controls.commandbarflyout.primarycommands)と[SecondaryCommands](/uwp/api/windows.ui.xaml.controls.commandbarflyout.secondarycommands)します。

既定では、コマンド バーの項目は **PrimaryCommands** コレクションに追加されます。 これらのコマンドは、コマンド バーに表示されますが折りたたまれ、展開の両方のモードで表示されます。 CommandBar とは異なりは、プライマリ コマンドは、自動的にセカンダリ コマンドにオーバーフローではないと、切り捨てられる可能性があります。

コマンドを追加することも、 **SecondaryCommands**コレクション。 セカンダリ コマンドでは、コントロールのメニューの部分では表示され、展開モードでのみ表示されます。

### <a name="app-bar-buttons"></a>アプリ バーのボタン

PrimaryCommands と SecondaryCommands を直接読み込める[AppBarButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbarbutton.aspx)、 [AppBarToggleButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbartogglebutton.aspx)、および[AppBarSeparator](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbarseparator.aspx)コントロール。

アプリ バーのボタン コントロールは、アイコンとテキスト ラベルによって特徴付けられます。 これらのコントロールがコマンド バーで使用するために最適化されたし、外観のコントロールがコマンド バーまたはオーバーフロー メニューに表示するかどうかに応じて変化します。

- そのアイコンのみで、コマンド バーの主要なコマンドとして使用されるアプリ バーのボタンが表示されます。テキスト ラベルは表示されません。 次に示すように、コマンドのテキスト説明を表示するツールヒントを使用することをお勧めします。
    ```xaml
    <AppBarButton Icon="Copy" ToolTipService.ToolTip="Copy"/>
    ```
- セカンダリ コマンドとして使用されるアプリ バー ボタン、ラベルとアイコンが表示されると、メニューに表示されます。

### <a name="other-content"></a>その他のコンテンツ

AppBarElementContainer で囲むことによって、コマンド バーのフライアウトを他のコントロールを追加できます。 などのコントロールを追加できます[DropDownButton](buttons.md)または[SplitButton](buttons.md)などのコンテナーを追加または[StackPanel](buttons.md)より複雑な UI を作成します。

コマンド バーのフライアウトのプライマリまたはセカンダリのコマンドのコレクションに追加するには、要素を実装する必要があります、 [ICommandBarElement](/uwp/api/windows.ui.xaml.controls.icommandbarelement)インターフェイス。 AppBarElementContainer は、インターフェイス自体を実装していない場合でも、コマンド バーに要素を追加できるように、このインターフェイスを実装するラッパーです。

ここでは、AppBarElementContainer を使用して、コマンド バーのフライアウトに余分な要素を追加できます。 Splitbutton でしょうが、色の選択できるようにする主要なコマンドに追加されます。 StackPanel は、ズーム コントロールのより複雑なレイアウトを許可するセカンダリ コマンドに追加されます。

> [!TIP]
> 既定では、アプリのキャンバス用に設計された要素はないように見えます適切なコマンド バーにします。 AppBarElementContainer を使用して要素を追加する場合は、要素が他のコマンド バーの要素との一致を行う必要があります、いくつかの手順があります。
>
> - オーバーライドと既定のブラシ[簡易スタイル](/windows/uwp/design/controls-and-patterns/xaml-styles#lightweight-styling)要素の背景や罫線アプリ バーのボタンを一致させる。
> - 要素の位置とサイズを調整します。
> - 16 px の高さ、幅、Viewbox にアイコンをラップします。

> [!NOTE]
> この例では、示されているコマンドのいずれかが実装していないのみ、コマンド バーのフライアウト、UI を示します。 コマンドの実装の詳細については、次を参照してください。[ボタン](buttons.md)と[コマンド デザインの基礎](../basics/commanding-basics.md)します。

![分割ボタンのコマンド バーのフライアウト](images/command-bar-flyout-split-button.png)

> _オープンの SplitButton で折りたたまれているコマンド バーのフライアウト_

![複雑な UI を使用したコマンド バーのフライアウト](images/command-bar-flyout-custom-ui.png)

> _メニューにカスタムのズーム UI と、展開コマンド バーのフライアウト_


```xaml
<CommandBarFlyout>
    <AppBarButton Icon="Cut" ToolTipService.ToolTip="Cut"/>
    <AppBarButton Icon="Copy" ToolTipService.ToolTip="Copy"/>
    <AppBarButton Icon="Paste" ToolTipService.ToolTip="Paste"/>
    <!-- Alignment controls -->
    <AppBarElementContainer>
        <SplitButton ToolTipService.ToolTip="Alignment">
            <SplitButton.Resources>
                <!-- Override default brushes to make the SplitButton 
                     match other command bar elements. -->
                <Style TargetType="SplitButton">
                    <Setter Property="Height" Value="38"/>
                </Style>
                <SolidColorBrush x:Key="SplitButtonBackground"
                                 Color="Transparent"/>
                <SolidColorBrush x:Key="SplitButtonBackgroundPressed"
                                 Color="{ThemeResource SystemListMediumColor}"/>
                <SolidColorBrush x:Key="SplitButtonBackgroundPointerOver"
                                 Color="{ThemeResource SystemListLowColor}"/>
                <SolidColorBrush x:Key="SplitButtonBorderBrush" Color="Transparent"/>
                <SolidColorBrush x:Key="SplitButtonBorderBrushPointerOver"
                                 Color="Transparent"/>
                <SolidColorBrush x:Key="SplitButtonBorderBrushChecked"
                                 Color="Transparent"/>
            </SplitButton.Resources>
            <SplitButton.Content>
                <Viewbox Width="16" Height="16" Margin="0,2,0,0">
                    <SymbolIcon Symbol="AlignLeft"/>
                </Viewbox>
            </SplitButton.Content>
            <SplitButton.Flyout>
                <MenuFlyout>
                    <MenuFlyoutItem Icon="AlignLeft" Text="Align left"/>
                    <MenuFlyoutItem Icon="AlignCenter" Text="Center"/>
                    <MenuFlyoutItem Icon="AlignRight" Text="Align right"/>
                </MenuFlyout>
            </SplitButton.Flyout>
        </SplitButton>
    </AppBarElementContainer>
    <!-- end Alignment controls -->
    <CommandBarFlyout.SecondaryCommands>
        <!-- Zoom controls -->
        <AppBarElementContainer>
            <AppBarElementContainer.Resources>
                <!-- Override default brushes to make the Buttons 
                     match other command bar elements. -->
                <SolidColorBrush x:Key="ButtonBackground"
                                 Color="Transparent"/>
                <SolidColorBrush x:Key="ButtonBackgroundPressed"
                                 Color="{ThemeResource SystemListMediumColor}"/>
                <SolidColorBrush x:Key="ButtonBackgroundPointerOver"
                                 Color="{ThemeResource SystemListLowColor}"/>
                <SolidColorBrush x:Key="ButtonBorderBrush"
                                 Color="Transparent"/>
                <SolidColorBrush x:Key="ButtonBorderBrushPointerOver"
                                 Color="Transparent"/>
                <SolidColorBrush x:Key="ButtonBorderBrushChecked"
                                 Color="Transparent"/>
                <Style TargetType="TextBlock">
                    <Setter Property="VerticalAlignment" Value="Center"/>
                </Style>
                <Style TargetType="Button">
                    <Setter Property="Height" Value="40"/>
                    <Setter Property="Width" Value="40"/>
                </Style>
            </AppBarElementContainer.Resources>
            <Grid Margin="12,-4">
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width="Auto"/>
                    <ColumnDefinition Width="76"/>
                    <ColumnDefinition Width="Auto"/>
                </Grid.ColumnDefinitions>
                <Viewbox Width="16" Height="16" Margin="0,2,0,0">
                    <SymbolIcon Symbol="Zoom"/>
                </Viewbox>
                <TextBlock Text="Zoom" Margin="10,0,0,0" Grid.Column="1"/>
                <StackPanel Orientation="Horizontal" Grid.Column="2">
                    <Button ToolTipService.ToolTip="Zoom out">
                        <Viewbox Width="16" Height="16">
                            <SymbolIcon Symbol="ZoomOut"/>
                        </Viewbox>
                    </Button>
                    <TextBlock Text="50%" Width="40"
                               HorizontalTextAlignment="Center"/>
                    <Button ToolTipService.ToolTip="Zoom in">
                        <Viewbox Width="16" Height="16">
                            <SymbolIcon Symbol="ZoomIn"/>
                        </Viewbox>
                    </Button>
                </StackPanel>
            </Grid>
        </AppBarElementContainer>
        <!-- end Zoom controls -->
        <AppBarSeparator/>
        <AppBarButton Label="Undo" Icon="Undo"/>
        <AppBarButton Label="Redo" Icon="Redo"/>
        <AppBarButton Label="Select all" Icon="SelectAll"/>
    </CommandBarFlyout.SecondaryCommands>
</CommandBarFlyout>
```

## <a name="create-a-context-menu-with-secondary-commands-only"></a>セカンダリ コマンドのみを使用してコンテキスト メニューを作成します。

セカンダリ コマンドとしてのみで、CommandBarFlyout を使用できる、[コンテキスト メニュー](menus.md)、MenuFlyout の代わりにします。

![セカンダリ コマンドのみを使用してコマンド バーのフライアウト](images/command-bar-flyout-context-menu.png)

> _コンテキスト メニューとコマンド バーのフライアウト_

```xaml
<Grid>
    <Grid.Resources>
        <!-- A command bar flyout with only secondary commands. -->
        <CommandBarFlyout x:Name="ContextMenu">
            <CommandBarFlyout.SecondaryCommands>
                <AppBarButton Label="Copy" Icon="Copy"/>
                <AppBarButton Label="Save" Icon="Save"/>
                <AppBarButton Label="Print" Icon="Print"/>
                <AppBarSeparator />
                <AppBarButton Label="Properties"/>
            </CommandBarFlyout.SecondaryCommands>
        </CommandBarFlyout>
    </Grid.Resources>

    <Image Source="Assets/image1.png" Width="300"
           ContextFlyout="{x:Bind ContextMenu}"/>
</Grid>
```

標準メニューを作成するのにと、DropDownButton、CommandBarFlyout を使用することもできます。

![ドロップダウン ボタンのメニューとコマンド バー フライアウト](images/command-bar-flyout-dropdown.png)

> _ドロップダウン ボタンのメニュー コマンド バーのフライアウトで_

```xaml
<CommandBarFlyout>
    <AppBarButton Icon="Placeholder"/>
    <AppBarElementContainer>
        <DropDownButton Content="Mail">
            <DropDownButton.Resources>
                <!-- Override default brushes to make the DropDownButton 
                     match other command bar elements. -->
                <Style TargetType="DropDownButton">
                    <Setter Property="Height" Value="38"/>
                </Style>
                <SolidColorBrush x:Key="ButtonBackground"
                                 Color="Transparent"/>
                <SolidColorBrush x:Key="ButtonBackgroundPressed"
                                 Color="{ThemeResource SystemListMediumColor}"/>
                <SolidColorBrush x:Key="ButtonBackgroundPointerOver"
                                 Color="{ThemeResource SystemListLowColor}"/>

                <SolidColorBrush x:Key="ButtonBorderBrush"
                                 Color="Transparent"/>
                <SolidColorBrush x:Key="ButtonBorderBrushPointerOver"
                                 Color="Transparent"/>
                <SolidColorBrush x:Key="ButtonBorderBrushChecked"
                                 Color="Transparent"/>
            </DropDownButton.Resources>
            <DropDownButton.Flyout>
                <CommandBarFlyout Placement="BottomEdgeAlignedLeft">
                    <CommandBarFlyout.SecondaryCommands>
                        <AppBarButton Icon="MailReply" Label="Reply"/>
                        <AppBarButton Icon="MailReplyAll" Label="Reply all"/>
                        <AppBarButton Icon="MailForward" Label="Forward"/>
                    </CommandBarFlyout.SecondaryCommands>
                </CommandBarFlyout>
            </DropDownButton.Flyout>
        </DropDownButton>
    </AppBarElementContainer>
    <AppBarButton Icon="Placeholder"/>
    <AppBarButton Icon="Placeholder"/>
</CommandBarFlyout>
```

## <a name="command-bar-flyouts-for-text-controls"></a>テキスト コントロールのコマンド バーのフライアウト

[TextCommandBarFlyout](/uwp/api/microsoft.ui.xaml.controls.textcommandbarflyout)テキストを編集するためのコマンドを含む特殊なコマンド バーのフライアウトが。 各テキスト コントロールでは、コンテキスト メニュー (右クリック)、またはテキストが選択されているときに自動的に、TextCommandBarFlyout が表示されます。 テキスト コマンド バーのフライアウトは、関連するコマンドのみを表示するテキストの選択範囲に適応します。

![縮小テキストのコマンド バーのフライアウト](images/command-bar-flyout-text-selection.png)

> _テキストの選択項目のテキスト コマンド バー フライアウト_

![テキスト コマンド バー フライアウト](images/command-bar-flyout-text-full.png)

> _テキスト コマンド バー フライアウト_


### <a name="available-commands"></a>使用可能なコマンド

表示されるときに、TextCommandBarFlyout に含まれているコマンドを次の表に示します。

| コマンド | 表示しています. |
| ------- | -------- |
| Bold | ときに、テキスト コントロールは、読み取り専用 (RichEditBox のみ) ではありません。 |
| Italic | ときに、テキスト コントロールは、読み取り専用 (RichEditBox のみ) ではありません。 |
| Underline | ときに、テキスト コントロールは、読み取り専用 (RichEditBox のみ) ではありません。 |
| 校正 | IsSpellCheckEnabled が場合**true**スペル ミスのテキストが選択されているとします。 |
| 切り取り | テキスト コントロールがないと、読み取り専用とテキストが選択されます。 |
| コピー | テキストを選択するとします。 |
| Paste | テキスト コントロールは読み取り専用ではないと、クリップボードがコンテンツ。 |
| 元に戻す | 元に戻すことができるアクションがある場合。 |
| すべて選択 | ときにテキストを選択することができます。 |

### <a name="custom-text-command-bar-flyouts"></a>カスタム テキスト コマンド バーのフライアウト

TextCommandBarFlyout はカスタマイズすることはできませんし、各テキスト コントロールによって自動的に管理されています。 ただし、カスタム コマンドを使用して既定 TextCommandBarFlyout を置き換えることができます。

- 既定のテキストの選択時に表示される TextCommandBarFlyout を置換するカスタム CommandBarFlyout (またはその他のフライアウト型) を作成およびに割り当てる、 **SelectionFlyout**プロパティ。 SelectionFlyout に設定する場合**null**、選択項目のコマンドは表示されません。
- 既定のコンテキスト メニューとして表示される TextCommandBarFlyout を置換するにカスタム CommandBarFlyout (またはその他のフライアウト型) を割り当てる、 **ContextFlyout**テキスト コントロールのプロパティ。 ContextFlyout に設定する場合**null**、表示されるメニュー フライアウト、TextCommandBarFlyout ではなく、テキストの以前のバージョン コントロールが示すようにします。

## <a name="get-the-sample-code"></a>サンプル コードを入手する

- [XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Xaml-Controls-Gallery) - インタラクティブな形で XAML コントロールのすべてを参照できます。
- [コマンド実行の XAML サンプル](https://go.microsoft.com/fwlink/p/?LinkId=620019)

## <a name="related-articles"></a>関連記事

- [UWP アプリのコマンド設計の基本](../basics/commanding-basics.md)
- [コマンド バー クラス](https://msdn.microsoft.com/library/windows/apps/dn279427)
