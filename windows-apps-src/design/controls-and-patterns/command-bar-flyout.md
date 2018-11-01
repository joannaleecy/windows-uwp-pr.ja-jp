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
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/01/2018
ms.locfileid: "5919160"
---
# <a name="command-bar-flyout"></a>コマンド バーのポップアップ

コマンド バーのポップアップでは、UI のキャンバス上の要素に関連するフリー ツールバーにコマンドを表示することによって一般的なタスクに簡単にアクセスをユーザーに提供できます。

![拡張テキスト コマンド バーのポップアップ](images/command-bar-flyout-header.png)

> Windows 10、1809 ([SDK 17763](https://developer.microsoft.com/windows/downloads/windows-10-sdk)) のバージョンが必要です CommandBarFlyout またはそれ以降、または[Windows の UI ライブラリ](https://docs.microsoft.com/uwp/toolkits/winui/)。

> - **プラットフォーム Api**: [CommandBarFlyout クラス](/uwp/api/windows.ui.xaml.controls.commandbarflyout)、 [TextCommandBarFlyout クラス](/uwp/api/windows.ui.xaml.controls.textcommandbarflyout)、 [AppBarButton クラス](/uwp/api/windows.ui.xaml.controls.appbarbutton)、 [AppBarToggleButton クラス](/uwp/api/windows.ui.xaml.controls.appbartogglebutton)、 [AppBarSeparator クラス](/uwp/api/windows.ui.xaml.controls.appbarseparator)
>- **Windows UI ライブラリ Api**: [CommandBarFlyout クラス](/uwp/api/microsoft.ui.xaml.controls.commandbarflyout)、 [TextCommandBarFlyout クラス](/uwp/api/microsoft.ui.xaml.controls.textcommandbarflyout)

[コマンド バー](app-bars.md)のような CommandBarFlyout には**PrimaryCommands**と**SecondaryCommands**のプロパティのコマンドを追加するのにを使用することができます。 コマンドは、コレクション、またはその両方に配置できます。 プライマリおよびセカンダリのコマンドが表示されるタイミングと方法は、表示モードによって異なります。

コマンド バーのポップアップには、2 つの表示モード:*が折りたたまれている*し、*展開*します。

- モードでは、折りたたまれている、主要なコマンドのみが表示されます。 場合は、コマンド バーのポップアップには、プライマリとセカンダリの両方のコマンド、」の詳細を参照してください」のボタン、省略記号で表される \ [•••\] が表示されます。 これにより、拡張モードへの移行によって第 2 のコマンドへのアクセスを取得します。
- 拡張モードでは、プライマリおよびセカンダリの両方のコマンドが表示されます。 (コントロールに 2 次のアイテムのみがある場合に表示されます MenuFlyout コントロールと同様の方法で。

## <a name="is-this-the-right-control"></a>適切なコントロールの選択

ボタンやアプリのキャンバス上の要素のコンテキストでは、メニュー項目など、ユーザーにコマンドのコレクションを表示するのにには、CommandBarFlyout コントロールを使用します。

TextCommandBarFlyout では、TextBox、TextBlock、RichEditBox、RichTextBlock、および PasswordBox コントロールでテキストのコマンドが表示されます。 コマンドは、現在選択されているテキストを自動的に適切に構成します。 テキスト コントロールの既定のコマンドのテキストを置換するのには、CommandBarFlyout を使用します。

コンテキストを表示するには、] ボックスの一覧の項目のコマンドの[コレクションおよびリストのコマンドを実行するコンテキスト](collection-commanding.md)で指示に従います。

### <a name="commandbarflyout-vs-menuflyout"></a>CommandBarFlyout vs MenuFlyout

コンテキスト メニューにコマンドを表示するには、CommandBarFlyout または MenuFlyout を使用できます。 CommandBarFlyout は、MenuFlyout よりもより多くの機能が用意されていますのでお勧めします。 セカンダリ コマンドのみを使用して CommandBarFlyout を使用するには動作を取得し、MenuFlyout の検索またはプライマリとセカンダリの両方のコマンドを使用して完全なコマンド バーのポップアップを使用します。

> 関連情報は、[動的メニュー](../controls-and-patterns/dialogs-and-flyouts/flyouts.md)の[メニューおよびコンテキスト メニュー](menus.md)、[コマンド バー](app-bars.md)を参照してください。

## <a name="examples"></a>例

<table>
<th align="left">XAML コントロール ギャラリー<th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong>アプリケーションがインストールされている場合は、ここをクリックして<a href="xamlcontrolsgallery:/item/CommandBarFlyout">アプリケーションを開き実行中の CommandBarFlyout を参照してください</a>。</p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics">ソース コード (GitHub) を入手する</a></li>
    </ul>
</td>
</tr>
</table>

## <a name="proactive-vs-reactive-invocation"></a>事前と事後対応型の呼び出し

フライアウトまたは、UI のキャンバス上の要素に関連付けられているメニューを呼び出すには通常 2 つ方法があります:_予防的な呼び出し_および_事後対応型の呼び出しを実行_します。

事前対応型の呼び出しでコマンドが自動的に表示、ユーザーがコマンドに関連付けられている項目を操作したとき。 たとえば、テキストの書式設定コマンドをポップアップ表示、ユーザーがテキスト ボックス内のテキストを選択するとします。 この例では、コマンド バーのポップアップはフォーカスを取得できません。 代わりに、ユーザーと対話して、項目に関連するコマンドが表示されます。 ユーザーは、コマンドを使用して通信できない場合に、閉じられます。

事後対応型の呼び出しでは、コマンドで表示されます明示的なユーザー アクションへの応答を要求するコマンドです。たとえば、右クリックします。 これは、[コンテキスト メニュー](menus.md)の従来の概念に対応しています。

方法、または 2 つの混合気も CommandBarFlyout を使用することができます。

## <a name="create-a-command-bar-flyout"></a>コマンド バーのポップアップを作成します。

この例では、コマンド バーのポップアップを作成し、リアクティブとプロアクティブに使用する方法を示します。 イメージをタップすると、フライアウトは、折りたたまれた状態で表示されます。 コンテキスト メニューとして表示される、拡張モードで、フライアウトが表示されます。 どちらの場合も、ユーザー展開したり折りたたんだり、ポップアップが開かれた後です。

![折りたたまれたコマンド バーのポップアップの例](images/command-bar-flyout-img-collapsed.png)

> _折りたたまれたコマンド バーのポップアップ_

![拡張されたコマンド バー ポップアップの例](images/command-bar-flyout-img-expanded.png)

> _拡張されたコマンド バーのポップアップ_

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

コンテキストのコマンドを事前に表示する場合は、既定の (コマンド バーのポップアップを解除する必要があります) で主要なコマンドのみを表示するか。 主要なコマンドのコレクション、およびコレクション内の補助的なコマンドのコンテキスト メニューで従来から行われるその他のコマンドでは、最も重要なコマンドを配置します。

コマンドを事前に表示するには、通常、コマンド バーのポップアップを表示する[] をクリックして](/uwp/api/windows.ui.xaml.controls.primitives.buttonbase.click)または[Tapped](/uwp/api/windows.ui.xaml.uielement.tapped)イベントを処理します。 **一時的な**または**TransientWithDismissOnPointerMoveAway**にフォーカスすることがなく、折りたたまれた状態で、ポップアップを開くには、フライアウトの[ShowMode](/uwp/api/windows.ui.xaml.controls.primitives.flyoutbase.showmode)を設定します。

以降 Windows 10 の内部からのプレビューでは、テキスト コントロールは、 **SelectionFlyout**プロパティを持ちます。 フライアウトをこのプロパティに代入するときにテキストを選択すると自動的に表示されます。

### <a name="show-commands-reactively"></a>リアクティブにコマンドを表示します。

リアクティブ、コンテキスト メニュー コマンドのコンテキストを表示すると、既定では (コマンド バーのポップアップを展開する必要があります)、補助的なコマンドが表示されます。 この例では、コマンド バーのポップアップには、プライマリとセカンダリの両方のコマンド、または補助的なコマンドのみがあります。

コンテキスト メニューにコマンドを表示するに割り当てることを通常、フライアウト UI 要素の[ContextFlyout](/uwp/api/windows.ui.xaml.uielement.contextflyout)プロパティにします。 この方法では、要素によって処理されます、ポップアップを開くと、特に何もする必要はありません。

(たとえば、 [RightTapped](/uwp/api/windows.ui.xaml.uielement.righttapped)イベントの場合) を自分で、フライアウトを表示を処理する場合は、**標準**の拡張モードで、フライアウトを開き、フォーカスを設定するフライアウトの[ShowMode](/uwp/api/windows.ui.xaml.controls.primitives.flyoutbase.showmode)を設定します。

> [!TIP]
> フライアウトとフライアウトの位置を制御する方法を表示するときのオプションに関する詳細情報は、[動的メニュー](../controls-and-patterns/dialogs-and-flyouts/flyouts.md)を参照してください。

## <a name="commands-and-content"></a>コマンドとコンテンツ

CommandBarFlyout コントロールには 2 つのプロパティ コマンドとコンテンツを追加するのにを使用することができます: [PrimaryCommands](/uwp/api/windows.ui.xaml.controls.commandbarflyout.primarycommands)と[SecondaryCommands](/uwp/api/windows.ui.xaml.controls.commandbarflyout.secondarycommands)。

既定では、コマンド バーの項目は **PrimaryCommands** コレクションに追加されます。 これらのコマンドは、コマンド バーに表示し、折りたたんだ状態と展開の両方のモードで表示されます。 コマンド バーとは異なり主要なコマンドは自動的にセカンダリ コマンドをオーバーフローではないと、切り捨てられる可能性があります。

**SecondaryCommands**コレクションにコマンドを追加することもできます。 補助的なコマンドはコントロールのメニューの部分に表示され、拡張モードでのみ表示されます。

### <a name="app-bar-buttons"></a>アプリ バーのボタン

PrimaryCommands と SecondaryCommands [AppBarButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbarbutton.aspx)、 [AppBarToggleButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbartogglebutton.aspx)、および[AppBarSeparator](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbarseparator.aspx)のコントロールを直接設定できます。

アプリ バーのボタン コントロールは、アイコンとテキスト ラベルによって特徴付けられます。 これらのコントロールは、コマンド バーで使用するために最適化されたし、外観のコントロールがコマンド バーまたはオーバーフロー メニューに表示されているかどうかによって変化します。

- アプリケーション バー ボタンの主要なコマンドとして使用は、アイコンのみを持つコマンド バーに表示されます。テキスト ラベルは表示されません。 次のように、コマンドの説明のテキストを表示するツールヒントを使用することをお勧めします。
    ```xaml
    <AppBarButton Icon="Copy" ToolTipService.ToolTip="Copy"/>
    ```
- メニューで、ラベルとアイコンが表示されると、セカンダリ コマンドとして使用するアプリケーション バーのボタンが表示されます。

### <a name="other-content"></a>その他のコンテンツ

AppBarElementContainer でそれらをラップすることによって、コマンド バーのポップアップに他のコントロールを追加できます。 これは、 [DropDownButton]()や[SplitButton]()のようなコントロールを追加またはより複雑な UI を作成するのには、 [StackPanel]()などのコンテナーを追加することができます。

要素はコマンド バーのポップアップのプライマリまたはセカンダリのコマンドのコレクションに追加するのには、 [ICommandBarElement](/uwp/api/windows.ui.xaml.controls.icommandbarelement)インターフェイスを実装する必要があります。 AppBarElementContainer は、インターフェイス自体を実装していない場合でも、コマンド バーに要素を追加することができますので、このインターフェイスを実装するためのラッパーです。

ここでは、余分な要素をコマンド バーのポップアップに追加するのには、AppBarElementContainer が使用されます。 SplitButton は、色の選択を許可するのには主要なコマンドに追加されます。 StackPanel は、ズーム コントロールのより複雑なレイアウトを許可するセカンダリ コマンドに追加されます。

> [!TIP]
> 既定では、アプリケーションのキャンバスのように設計された要素がありますが正しく印刷されないコマンド バーにします。 AppBarElementContainer を使用して要素を追加するときは、いくつか手順を実行する必要がある要素が他のコマンド バーの要素に一致するがあります。
>
> - オーバーライドが要素の背景と枠線を作成するのには[軽量のスタイル](/design/controls-and-patterns/xaml-styles#lightweight-styling)を持つ既定のブラシでは、アプリケーション バーのボタンと一致します。
> - 要素の位置とサイズを調整します。
> - 16px の高さ、幅、これでアイコンをラップします。

> [!NOTE]
> この例では、表示されているコマンドのいずれかが実装していないのみ、コマンド バー ポップアップ UI を示します。 コマンドを実装する方法の詳細については、[ボタン](buttons.md)や[コマンドの設計の基本」](../basics/commanding-basics.md)を参照してください。

![分割ボタンを使用してコマンド バーのポップアップ](images/command-bar-flyout-split-button.png)

> _オープン、SplitButton で折りたたまれているコマンド バーのフライアウト_

![複雑な UI を持つコマンド バーのポップアップ](images/command-bar-flyout-custom-ui.png)

> _メニューから「カスタム ズーム UI での拡張されたコマンド バー ポップアップ_


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

として[コンテキスト メニュー](menus.md)で、MenuFlyout の代わりに、セカンダリ コマンドのみを使用して、CommandBarFlyout を使用できます。

![セカンダリ コマンドのみを使用してコマンド バーのポップアップ](images/command-bar-flyout-context-menu.png)

> _コンテキスト メニューとコマンド バーのポップアップ_

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

標準メニューを作成するのには、DropDownButton に、CommandBarFlyout を使用することもできます。

![ドロップダウン ボタンのメニューとコマンド バー フライアウト](images/command-bar-flyout-dropdown.png)

> _ドロップ ダウン ボタン] メニューのコマンド バーのポップアップで_

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

[TextCommandBarFlyout](/uwp/api/microsoft.ui.xaml.controls.textcommandbarflyout)は、テキスト編集のためのコマンドを含む特殊なコマンド バー ポップアップです。 各テキスト コントロールは、コンテキスト メニュー (右クリック)、またはテキストを選択すると自動的に、TextCommandBarFlyout を示します。 テキスト コマンド バーのポップアップは、テキストの選択範囲のみに関連するコマンドを表示するに適応します。

![折りたたまれたテキストのコマンド バー ポップアップ](images/command-bar-flyout-text-selection.png)

> _テキストの選択範囲のテキストのコマンド バー ポップアップ_

![拡張テキスト コマンド バーのポップアップ](images/command-bar-flyout-text-full.png)

> _拡張テキスト コマンド バーのポップアップ_


### <a name="available-commands"></a>使用可能なコマンド

表示されている場合、TextCommandBarFlyout に含まれているコマンドを次の表に示します。

| コマンド | 表示しています. |
| ------- | -------- |
| Bold | テキスト コントロールは読み取り専用 (RichEditBox のみ) ではありません。 |
| Italic | テキスト コントロールは読み取り専用 (RichEditBox のみ) ではありません。 |
| Underline | テキスト コントロールは読み取り専用 (RichEditBox のみ) ではありません。 |
| 校正 | IsSpellCheckEnabled が**true**であり、スペルが間違っている場合は、テキストが選択されます。 |
| 切り取り | テキスト コントロールは読み取り専用ではないとテキストが選択されます。 |
| コピー | テキストが選択されている場合。 |
| 貼り付け | テキスト コントロールは読み取り専用ではなく、内容がクリップボードに含まれています。 |
| 元に戻す | 元に戻すことができるアクションがある場合。 |
| すべて選択 | テキストを選択することができます。 |

### <a name="custom-text-command-bar-flyouts"></a>テキストのカスタム コマンド バーのフライアウト

TextCommandBarFlyout はカスタマイズすることはできませんし、テキストの各コントロールによって自動的に管理します。 ただし、デフォルトの TextCommandBarFlyout をユーザー設定のコマンドに置き換えることができます。

- TextCommandBarFlyout テキストの選択時に表示される既定値を置換するには、カスタムの CommandBarFlyout (またはその他のフライアウト型) を作成し、 **SelectionFlyout**プロパティに割り当てることです。 SelectionFlyout を**null**に設定する場合は、選択時にコマンドが表示されません。
- TextCommandBarFlyout は、コンテキスト メニューとして表示する既定値を置き換えるには、テキスト コントロールの**ContextFlyout**プロパティにカスタムの CommandBarFlyout (またはその他のフライアウト型) を割り当てます。 ContextFlyout を**null**に設定すると、TextCommandBarFlyout の代わりにテキスト コントロールの以前のバージョンで表示] メニューのポップアップが表示されます。

## <a name="get-the-sample-code"></a>サンプル コードを入手する

- [XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - インタラクティブな形ですべての XAML コントロールを参照できます。
- [XAML コマンド実行のサンプル](http://go.microsoft.com/fwlink/p/?LinkId=620019)

## <a name="related-articles"></a>関連記事

- [UWP アプリのコマンド設計の基本](../basics/commanding-basics.md)
- [CommandBar クラス](https://msdn.microsoft.com/library/windows/apps/dn279427)
