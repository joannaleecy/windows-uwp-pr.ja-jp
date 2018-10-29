---
author: jwmsft
Description: Command bar flyouts give users inline access to your app's most common tasks.
title: コマンド バーのポップアップ
label: Command bar flyout
template: detail.hbs
ms.author: jimwalk
ms.date: 10/2/2018
ms.topic: article
keywords: Windows 10, UWP
pm-contact: abarlow
design-contact: ksulliv
dev-contact: llongley
doc-status: Draft
ms.localizationpriority: medium
ms.openlocfilehash: 95d99c41ff2679e3ef3e0471dd583fe78458922c
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/29/2018
ms.locfileid: "5749276"
---
# <a name="command-bar-flyout"></a>コマンド バーのポップアップ

コマンド バーのポップアップでは、UI のキャンバス上の要素に関連する浮動ツールバーでのコマンドを表示して一般的なタスクに簡単にアクセスをユーザーに提供できます。

![展開されたテキスト コマンド バーのポップアップ](images/command-bar-flyout-header.png)

> CommandBarFlyout には、Windows 10 version 1809 ([SDK 17763](https://developer.microsoft.com/windows/downloads/windows-10-sdk)) が必要ですか、後で、または[Windows UI のライブラリ](https://docs.microsoft.com/uwp/toolkits/winui/)。

> - **プラットフォーム Api**: [CommandBarFlyout クラス](/uwp/api/windows.ui.xaml.controls.commandbarflyout)、 [TextCommandBarFlyout クラス](/uwp/api/windows.ui.xaml.controls.textcommandbarflyout)、 [AppBarButton クラス](/uwp/api/windows.ui.xaml.controls.appbarbutton)、 [AppBarToggleButton クラス](/uwp/api/windows.ui.xaml.controls.appbartogglebutton)、 [AppBarSeparator クラス](/uwp/api/windows.ui.xaml.controls.appbarseparator)
>- **Windows UI ライブラリ Api**: [CommandBarFlyout クラス](/uwp/api/microsoft.ui.xaml.controls.commandbarflyout)、 [TextCommandBarFlyout クラス](/uwp/api/microsoft.ui.xaml.controls.textcommandbarflyout)

[CommandBar](app-bars.md)など CommandBarFlyout にコマンドを追加するのに使用できる**PrimaryCommands**と**SecondaryCommands**のプロパティがあります。 コレクション、またはその両方でコマンドを配置することができます。 プライマリおよびセカンダリ コマンドが表示されるタイミングと方法は、表示モードによって異なります。

コマンド バーのポップアップが 2 つの表示モード:*折りたたまれている*し、*展開*します。

- 折りたたまれたモードでは、プライマリ コマンドのみが表示されます。 コマンド バーのポップアップがプライマリとセカンダリ コマンド、省略記号で表される「詳細」ボタン \ [•] が表示されます。 これにより、ユーザーの拡張モードに移行してセカンダリ コマンドへのアクセスを取得できます。
- 拡張のモードでは、プライマリおよびセカンダリ コマンドの両方が表示されます。 (コントロールのセカンダリ項目のみが表示されます MenuFlyout コントロールと同様の方法で。)

## <a name="is-this-the-right-control"></a>適切なコントロールの選択

メニュー項目は、アプリのキャンバス上の要素のコンテキストでボタンなど、ユーザーにコマンドのコレクションを表示するのにには、CommandBarFlyout コントロールを使用します。

TextCommandBarFlyout では、TextBox、TextBlock、RichEditBox、RichTextBlock、および PasswordBox のコントロールでテキスト コマンドが表示されます。 コマンドは現在のテキストの選択に自動的に適切に構成します。 テキスト コントロールの既定のテキストのコマンドを使用して、CommandBarFlyout します。

リスト項目でのコマンドをコンテキストを表示するには、[コンテキスト コマンドのコレクションとリストの実行](collection-commanding.md)のガイダンスに従っています。

### <a name="commandbarflyout-vs-menuflyout"></a>CommandBarFlyout vs MenuFlyout

コンテキスト メニューにコマンドを表示するには、CommandBarFlyout または MenuFlyout を使用できます。 MenuFlyout よりもさらに機能を提供するため CommandBarFlyout をお勧めします。 セカンダリ コマンドのみを使った CommandBarFlyout を使用して、動作を取得して、MenuFlyout の検索プライマリおよびセカンダリの両方のコマンドで完全なコマンド バーのポップアップを使用することができます。

> 関連する情報は、[ポップアップ](../controls-and-patterns/dialogs-and-flyouts/flyouts.md)[メニューとコンテキスト メニュー](menus.md)、[コマンド バー](app-bars.md)を参照してください。

## <a name="examples"></a>例

<table>
<th align="left">XAML コントロール ギャラリー<th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong>アプリがインストールされた場合は、ここをクリックして<a href="xamlcontrolsgallery:/item/CommandBarFlyout">アプリを開きの動作を確認 CommandBarFlyout を参照してください</a>。</p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics">ソース コード (GitHub) を入手する</a></li>
    </ul>
</td>
</tr>
</table>

## <a name="proactive-vs-reactive-invocation"></a>事後対応型の呼び出しと事前対応型

ポップアップや、UI のキャンバス上の要素に関連付けられているメニューを呼び出すに 2 つの方法は通常:_プロアクティブな呼び出し_および_事後対応型の呼び出しを実行_します。

コマンドは事前対応型の呼び出しでは、ユーザーがコマンドに関連付けられている項目を操作する自動的に表示します。 たとえば、テキストの書式設定コマンド可能性がありますがポップアップ、ユーザーがテキスト ボックスのテキストを選択します。 この例では、コマンド バーのポップアップでは、フォーカスは実行されません。 代わりに、関連するコマンドで、ユーザーが操作の項目に近いを表示します。 場合は、ユーザーは、コマンドを操作しない、それらが閉じられます。

事後対応型の呼び出しでコマンドは表示、明示的なユーザー操作への応答でコマンドを要求するにはたとえば、右クリックします。 これは、[コンテキスト メニュー](menus.md)の従来の概念に対応します。

により、または 2 つの混合でも CommandBarFlyout を使用することができます。

## <a name="create-a-command-bar-flyout"></a>コマンド バーのポップアップを作成します。

この例では、コマンド バーのポップアップを作成し、事前と事後対応的に使用する方法を示します。 イメージをタップすると、ポップアップが折りたたまれているモードで表示されます。 表示されるとき、コンテキスト メニューとして、その拡張モードで、ポップアップが表示されます。 どちらの場合、ユーザーに展開またはに開いた後、ポップアップを折りたたむできます。

![折りたたまれているコマンド バーのポップアップの例](images/command-bar-flyout-img-collapsed.png)

> _折りたたまれているコマンド バーのポップアップ_

![展開されたコマンド バーのポップアップの例](images/command-bar-flyout-img-expanded.png)

> _展開されたコマンド バーのポップアップ_

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

コンテキスト コマンドをプロアクティブに表示すると、プライマリ コマンドのみする必要があります (コマンド バーのポップアップを縮小する必要があります) を既定で表示されます。 プライマリ コマンドのコレクション、およびされる従来のコンテキスト メニューで、セカンダリ コマンドのコレクションに追加のコマンドで最も重要なコマンドを配置します。

コマンドをプロアクティブに表示するには、コマンド バーのポップアップを表示する[] をクリックして](/uwp/api/windows.ui.xaml.controls.primitives.buttonbase.click)または[Tapped](/uwp/api/windows.ui.xaml.uielement.tapped)イベントを処理する通常します。 **一時的な**または**TransientWithDismissOnPointerMoveAway**折りたたまれているモードでフォーカスを移動することがなく、ポップアップを開くには、ポップアップの[ShowMode](/uwp/api/windows.ui.xaml.controls.primitives.flyoutbase.showmode)を設定します。

以降、Windows 10 Insider Preview では、テキスト コントロールには、 **SelectionFlyout**プロパティが設定されています。 ポップアップをこのプロパティに割り当てるとテキストが選択されているときに自動的に表示されます。

### <a name="show-commands-reactively"></a>事後対応的にコマンドを表示します。

コンテキスト コマンドを事後対応的、コンテキスト メニューとして表示する場合は、既定では (コマンド バーのポップアップを展開する必要があります)、セカンダリ コマンドが表示されます。 この例では、コマンド バーのポップアップは、プライマリおよびセカンダリの両方のコマンド、またはセカンダリ コマンドにのみがあります。

コンテキスト メニューにコマンドを表示するには、通常に UI 要素の[ContextFlyout](/uwp/api/windows.ui.xaml.uielement.contextflyout)プロパティに、ポップアップを割り当てます。 これによりは、要素によって処理されますが、ポップアップを開くと、特に何もする必要はありません。

(たとえば、 [RightTapped](/uwp/api/windows.ui.xaml.uielement.righttapped)イベント) を自分で、ポップアップを示すを処理する場合は、**標準**の拡張モードで、ポップアップを開き、フォーカスを設定するポップアップの[ShowMode](/uwp/api/windows.ui.xaml.controls.primitives.flyoutbase.showmode)を設定します。

> [!TIP]
> ポップアップと、ポップアップの配置を制御する方法を表示するときのオプションについて詳しくは、[ポップアップ](../controls-and-patterns/dialogs-and-flyouts/flyouts.md)を参照してください。

## <a name="commands-and-content"></a>コマンドとコンテンツ

CommandBarFlyout コントロールは、コマンドとコンテンツを追加するのに使用できる 2 つのプロパティを持つ: [PrimaryCommands](/uwp/api/windows.ui.xaml.controls.commandbarflyout.primarycommands)と[SecondaryCommands](/uwp/api/windows.ui.xaml.controls.commandbarflyout.secondarycommands)にします。

既定では、コマンド バーの項目は **PrimaryCommands** コレクションに追加されます。 これらのコマンドは、コマンド バーは表示され、折りたたまれていると展開両方のモードで表示されます。 CommandBar とは異なり、プライマリ コマンドは自動的にセカンダリ コマンドにオーバーフローではないと切り詰められている可能性があります。

コマンドは**SecondaryCommands**コレクションに追加することもできます。 セカンダリ コマンドは、コントロールのメニューの部分では表示され、展開モードでのみ表示されます。

### <a name="app-bar-buttons"></a>アプリ バーのボタン

PrimaryCommands と SecondaryCommands には、 [AppBarButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbarbutton.aspx)、 [AppBarToggleButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbartogglebutton.aspx)、および[AppBarSeparator](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbarseparator.aspx)コントロールを直接設定できます。

アプリ バーのボタン コントロールは、アイコンとテキスト ラベルによって特徴付けられます。 これらのコントロールは、コマンド バーで使用するために最適化されていて、コマンド バーやオーバーフロー メニューにコントロールを表示するかどうかに応じて外観が変化します。

- アプリ バーのボタンがプライマリ コマンドとして使われますが、アイコンのみを含むコマンド バーで表示されます。テキスト ラベルは表示されません。 次のように、コマンドの説明のテキストを表示するヒントを使用することをお勧めします。
    ```xaml
    <AppBarButton Icon="Copy" ToolTipService.ToolTip="Copy"/>
    ```
- メニューで、ラベルとアイコンが表示されるには、セカンダリ コマンドとして使われるアプリ バーのボタンが表示されます。

### <a name="other-content"></a>その他のコンテンツ

コマンド バーのポップアップを他のコントロールを追加するには、AppBarElementContainer でラップします。 これにより[DropDownButton]() [SplitButton]()などのコントロールを追加したりより複雑な UI を作成するために[StackPanel]()などのコンテナーを追加できます。

コマンド バーのポップアップのプライマリまたはセカンダリ コマンドのコレクションに追加するために、要素は[ICommandBarElement](/uwp/api/windows.ui.xaml.controls.icommandbarelement)インターフェイスを実装する必要があります。 AppBarElementContainer は、インターフェイス自体を実装していない場合でも、コマンド バーに要素を追加できるように、このインターフェイスを実装するラッパーです。

ここでは、コマンド バーのポップアップに余分な要素を追加する、AppBarElementContainer が使用されます。 SplitButton は、色の選択を許可するプライマリ コマンドに追加されます。 StackPanel より複雑なズーム コントロールのレイアウトを許可するセカンダリ コマンドに追加されます。

> [!TIP]
> 既定では、アプリのキャンバス向けに設計された要素はないように見えます適切なコマンド バーにします。 AppBarElementContainer を使用して、要素を追加する場合は、その他のコマンド バーの要素に一致する要素を行う必要がいくつかの手順があります。
>
> - 要素の背景と境界線アプリ バーのボタンに一致する[軽量なスタイル設定](/design/controls-and-patterns/xaml-styles#lightweight-styling)の既定のブラシを上書きします。
> - 要素の位置とサイズを調整します。
> - 上部 16 ピクセルの高さ、幅の Viewbox では、アイコンをラップします。

> [!NOTE]
> この例では、表示されるコマンドのいずれかが実装していないのみ、コマンド バーのポップアップ UI を示しています。 コマンドの実装について詳しくは、[ボタン](buttons.md)や[コマンド設計の基本](../basics/commanding-basics.md)を参照してください。

![分割のボタンを含むコマンド バーのポップアップ](images/command-bar-flyout-split-button.png)

> _Open の SplitButton と折りたたまれているコマンド バーのポップアップ_

![複雑な UI とコマンド バーのポップアップ](images/command-bar-flyout-custom-ui.png)

> _メニューにカスタムのズーム UI では、展開されたコマンド バーのポップアップ_


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

## <a name="create-a-context-menu-with-secondary-commands-only"></a>セカンダリ コマンドのみでコンテキスト メニューを作成します。

[コンテキスト メニュー](menus.md)MenuFlyout の代わりとして、セカンダリ コマンドのみを使用して、CommandBarFlyout を使用できます。

![セカンダリ コマンドのみを使ったコマンド バーのポップアップ](images/command-bar-flyout-context-menu.png)

> _コンテキスト メニューとしてコマンド バーのポップアップ_

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

標準的なメニューを作成するのに、DropDownButton で、CommandBarFlyout を使用することもできます。

![ドロップダウン メニューのボタンとしてとコマンド バー ポップアップ](images/command-bar-flyout-dropdown.png)

> _ドロップダウン コマンド バーのポップアップ メニュー ボタン_

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

## <a name="command-bar-flyouts-for-text-controls"></a>テキスト コントロールのコマンド バーのポップアップ

[TextCommandBarFlyout](/uwp/api/microsoft.ui.xaml.controls.textcommandbarflyout)は、テキスト編集のコマンドを含む特殊なコマンド バーのポップアップです。 各テキスト コントロールは、テキストが選択されている場合や、コンテキスト メニュー (右クリック) として自動的に、TextCommandBarFlyout を示します。 テキストのコマンド バーのポップアップは、適切なコマンドのみを表示するテキストの選択に適応します。

![折りたたまれているテキスト コマンド バーのポップアップ](images/command-bar-flyout-text-selection.png)

> _テキストの選択でテキスト コマンド バーのポップアップ_

![展開されたテキスト コマンド バーのポップアップ](images/command-bar-flyout-text-full.png)

> _展開されたテキスト コマンド バーのポップアップ_


### <a name="available-commands"></a>利用可能なコマンド

次の表では、表示されているときと、TextCommandBarFlyout に含まれているコマンドを示します。

| コマンド | 表示される. |
| ------- | -------- |
| Bold | テキスト コントロールは読み取り専用 (RichEditBox のみ) ではありません。 |
| Italic | テキスト コントロールは読み取り専用 (RichEditBox のみ) ではありません。 |
| Underline | テキスト コントロールは読み取り専用 (RichEditBox のみ) ではありません。 |
| 校正 | IsSpellCheckEnabled が**true**でのスペルに誤りテキストが選択されます。 |
| 切り取り | テキスト コントロールは読み取り専用ではないとテキストが選択されます。 |
| コピー | テキストが選択されている場合。 |
| 貼り付け | テキスト コントロールは読み取り専用ではないとクリップボードがコンテンツです。 |
| 元に戻す | 実行できる操作がある場合。 |
| すべて選択 | テキストを選択することができます。 |

### <a name="custom-text-command-bar-flyouts"></a>カスタム テキスト コマンド バーのポップアップ

TextCommandBarFlyout では、カスタマイズできませんされ、各テキスト コントロールで自動的に管理されます。 ただし、カスタム コマンドを使った TextCommandBarFlyout 既定値を置き換えることができます。

- TextCommandBarFlyout テキストの選択に表示される既定値を交換するには、カスタム CommandBarFlyout (またはその他のポップアップ型) を作成し、 **SelectionFlyout**プロパティに割り当てます。 SelectionFlyout を**null**に設定した場合、選択内容にコマンドは表示されません。
- 置き換えるには、既定のコンテキスト メニューとして表示されている TextCommandBarFlyout、テキスト コントロールに**ContextFlyout**プロパティにカスタム CommandBarFlyout (またはその他のポップアップ型) を割り当てます。 ContextFlyout を**null**に設定すると、TextCommandBarFlyout ではなく、以前のバージョンのテキスト コントロールに表示されるメニュー ポップアップが表示されます。

## <a name="get-the-sample-code"></a>サンプル コードを入手する

- [XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - インタラクティブな形ですべての XAML コントロールを参照できます。
- [XAML コマンド実行のサンプル](http://go.microsoft.com/fwlink/p/?LinkId=620019)

## <a name="related-articles"></a>関連記事

- [UWP アプリのコマンド設計の基本](../basics/commanding-basics.md)
- [CommandBar クラス](https://msdn.microsoft.com/library/windows/apps/dn279427)
