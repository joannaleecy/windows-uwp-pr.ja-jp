---
author: jwmsft
Description: Command bar flyouts give users inline access to your app's most common tasks.
title: コマンド バーのポップアップ
label: Command bar flyout
template: detail.hbs
ms.author: jimwalk
ms.date: 10/2/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
pm-contact: abarlow
design-contact: ksulliv
dev-contact: llongley
doc-status: Draft
ms.localizationpriority: medium
ms.openlocfilehash: ed17299051ae7da32f238eb57876b81597c8effa
ms.sourcegitcommit: 63cef0a7805f1594984da4d4ff2f76894f12d942
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/05/2018
ms.locfileid: "4390231"
---
# <a name="command-bar-flyout"></a>コマンド バーのポップアップ

コマンド バーのポップアップでは、UI のキャンバス上の要素に関連する浮動ツールバーでコマンドを表示することによって一般的なタスクに簡単にアクセスをユーザーに提供できます。

![展開されたテキスト コマンド バーのポップアップ](images/command-bar-flyout-text-full.png)

> 関連する情報は、[ポップアップ](../controls-and-patterns/dialogs-and-flyouts/flyouts.md)[メニューとコンテキスト メニュー](menus.md)、[コマンド バー](app-bars.md)を参照してください。

[CommandBar](app-bars.md)などは CommandBarFlyout に追加のコマンドを使用できます**PrimaryCommands**と**SecondaryCommands**の特徴があります。 コレクション、またはその両方でコマンドを配置することができます。 プライマリとセカンダリ コマンドが表示されるタイミングと方法は、表示モードによって異なります。

コマンド バーのポップアップが 2 つの表示モード:*折りたたまれている*し、*展開*します。

- 折りたたまれたモードでは、プライマリ コマンドのみが表示されます。 プライマリおよびセカンダリの両方に、コマンド バーのポップアップがある場合のコマンド、省略記号で表される「詳細」ボタン \ [•] が表示されます。 これにより、ユーザーが拡張モードに移行してセカンダリ コマンドへのアクセスを取得します。
- 展開時のモードでは、プライマリおよびセカンダリ コマンドの両方が表示されます。 (コントロールのセカンダリ項目のみが表示されます MenuFlyout コントロールと同様の方法で。)

| **Windows UI のライブラリを入手します。** |
| - |
| このコントロールは、Windows UI のライブラリ、新しいコントロールと UWP アプリの UI の機能が含まれている NuGet パッケージの一部として含まれています。 詳しくは、インストールの手順を含む、 [Windows UI のライブラリの概要](https://docs.microsoft.com/uwp/toolkits/winui/)をご覧ください。 |

| **プラットフォーム Api** | **Windows UI ライブラリ Api** |
| - | - |
| [CommandBarFlyout クラス](/uwp/api/windows.ui.xaml.controls.commandbarflyout)、 [TextCommandBarFlyout クラス](/uwp/api/windows.ui.xaml.controls.textcommandbarflyout)、 [AppBarButton クラス](/uwp/api/windows.ui.xaml.controls.appbarbutton)、 [AppBarToggleButton クラス](/uwp/api/windows.ui.xaml.controls.appbartogglebutton)、 [AppBarSeparator クラス](/uwp/api/windows.ui.xaml.controls.appbarseparator) | [CommandBarFlyout クラス](/uwp/api/microsoft.ui.xaml.controls.commandbarflyout)、 [TextCommandBarFlyout クラス](/uwp/api/microsoft.ui.xaml.controls.textcommandbarflyout) |

## <a name="is-this-the-right-control"></a>適切なコントロールの選択

ボタンとアプリのキャンバス上の要素のコンテキストでのメニュー項目など、ユーザーにコマンドのコレクションを表示するのにには、CommandBarFlyout コントロールを使用します。

TextCommandBarFlyout では、TextBox、TextBlock、RichEditBox、RichTextBlock、および PasswordBox のコントロールでテキスト コマンドが表示されます。 コマンドは現在のテキストの選択に自動的に適切に構成します。 CommandBarFlyout を使用してテキスト コントロールの既定のテキストのコマンドを置き換えます。

リスト項目でのコマンドをコンテキストを表示するには、[コンテキスト コマンドのコレクションとリストの実行](collection-commanding.md)のガイダンスに従っています。

### <a name="commandbarflyout-vs-menuflyout"></a>CommandBarFlyout vs MenuFlyout

コマンドをコンテキスト メニューを表示するには、CommandBarFlyout または MenuFlyout を使用できます。 MenuFlyout よりも多くの機能を提供するため CommandBarFlyout をお勧めします。 セカンダリ コマンドのみを使った CommandBarFlyout を使用して、動作を取得して、MenuFlyout の検索プライマリおよびセカンダリの両方のコマンドで完全なコマンド バーのポップアップを使用することができます。

## <a name="examples"></a>例

<table>
<th align="left">XAML コントロール ギャラリー<th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong>アプリがインストールされている場合は、ここをクリックして<a href="xamlcontrolsgallery:/item/CommandBarFlyout">アプリを開き、操作で CommandBarFlyout を参照してください</a>。</p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics">ソース コード (GitHub) を入手する</a></li>
    </ul>
</td>
</tr>
</table>

## <a name="proactive-vs-reactive-invocation"></a>事後対応型の呼び出しと事前対応型

ポップアップや、UI のキャンバス上の要素に関連付けられているメニューを呼び出すに 2 つの方法は通常:_プロアクティブな呼び出し_および_事後対応型の呼び出しを実行_します。

コマンドは事前対応型の呼び出しでは、ユーザーがコマンドに関連付けられている項目を操作する自動的に表示します。 たとえば、テキストの書式設定コマンド可能性がありますがポップアップ テキスト ボックスで、ユーザーがテキストを選択します。 この例では、コマンド バーのポップアップでは、フォーカスは実行されません。 代わりに、ユーザーと対話して、項目に近い関連するコマンドを表示します。 場合は、ユーザーは、コマンドを操作しない、それらが閉じられます。

事後対応型の呼び出しでコマンドは表示明示的なユーザー操作への応答でコマンドを要求するにはたとえば、右クリックします。 これは、[コンテキスト メニュー](menus.md)の従来の概念に対応します。

により、または 2 つの混合でも CommandBarFlyout を使用することができます。

## <a name="create-a-command-bar-flyout"></a>コマンド バーのポップアップを作成します。

> **プレビュー**: CommandBarFlyout[最新の Windows 10 Insider Preview ビルドと SDK](https://insider.windows.com/for-developers/)または[Windows UI のライブラリ](https://docs.microsoft.com/uwp/toolkits/winui/)が必要です。

この例では、コマンド バーのポップアップを作成し、事前と事後対応的に使用する方法を示します。 イメージをタップすると、ポップアップが折りたたまれているモードで表示されます。 表示されるとき、コンテキスト メニューとして、その拡張モードで、ポップアップが表示されます。 どちらの場合、ユーザーに展開またはに開いた後、ポップアップを折りたたむできます。

:::row:::
    :::column:::
        A collapsed command bar flyout<br/>
        ![Example of a collapsed command bar flyout](images/command-bar-flyout-img-collapsed.png)
    :::column-end:::
    :::column:::
        An expanded command bar flyout<br/>
        ![Example of an expanded command bar flyout](images/command-bar-flyout-img-expanded.png)
    :::column-end:::
:::row-end:::

```xaml
<Grid>
    <Grid.Resources>
        <CommandBarFlyout x:Name="ImageCommandsFlyout">
            <AppBarButton Icon="OutlineStar" ToolTipService.ToolTip="Favorite"/>
            <AppBarButton Icon="Copy" ToolTipService.ToolTip="Copy"/>
            <AppBarButton Icon="Share" ToolTipService.ToolTip="Share"/>
            <CommandBarFlyout.SecondaryCommands>
                <AppBarButton Label="Rotate" Icon="Rotate"/>
                <AppBarButton Label="Delete" Icon="Delete"/>
            </CommandBarFlyout.SecondaryCommands>
        </CommandBarFlyout>
    </Grid.Resources>

    <Image Source="Assets/licorice.png" Width="300"
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

事前にコンテキスト コマンドを表示すると、プライマリ コマンドのみする必要があります (コマンド バーのポップアップを縮小する必要があります) を既定で表示されます。 プライマリ コマンドのコレクションとセカンダリ コマンドのコレクションには、コンテキスト メニューに移動しますが従来の追加のコマンドで最も重要なコマンドを配置します。

コマンドをプロアクティブに表示するには、コマンド バーのポップアップを表示する[] をクリックして](/uwp/api/windows.ui.xaml.controls.primitives.buttonbase.click)または[Tapped](/uwp/api/windows.ui.xaml.uielement.tapped)イベントを処理する通常します。 **一時的な**または**TransientWithDismissOnPointerMoveAway**折りたたまれているモードでフォーカスを移動することがなく、ポップアップを開くには、ポップアップの[ShowMode](/uwp/api/windows.ui.xaml.controls.primitives.flyoutbase.showmode)を設定します。

以降、Windows 10 Insider Preview では、テキスト コントロールには、 **SelectionFlyout**プロパティが設定されています。 ポップアップをこのプロパティに割り当てるとテキストが選択されているときに自動的に表示されます。

### <a name="show-commands-reactively"></a>事後対応的にコマンドを表示します。

コンテキスト コマンドを事後対応的、コンテキスト メニューとして表示する場合は、既定では (コマンド バーのポップアップを展開する必要があります)、セカンダリ コマンドが表示されます。 この例では、コマンド バーのポップアップには、プライマリおよびセカンダリの両方のコマンド、またはセカンダリ コマンドのみがあります。

コマンドをコンテキスト メニューを表示するには、通常に UI 要素の[ContextFlyout](/uwp/api/windows.ui.xaml.uielement.contextflyout)プロパティに、ポップアップを割り当てます。 これによりは、要素によって処理されますが、ポップアップを開くより何もする必要はありません。

(たとえば、 [RightTapped](/uwp/api/windows.ui.xaml.uielement.righttapped)イベント) を自分で、ポップアップを示すを処理する場合は、設定、**標準的な**展開モードで、ポップアップを開き、フォーカスを設定するには、ポップアップの[ShowMode](/uwp/api/windows.ui.xaml.controls.primitives.flyoutbase.showmode)します。

> [!TIP]
> ポップアップと、ポップアップの配置を制御する方法を表示するときのオプションについて詳しくは、[ポップアップ](../controls-and-patterns/dialogs-and-flyouts/flyouts.md)を参照してください。

## <a name="commands-and-content"></a>コマンドとコンテンツ

CommandBarFlyout コントロールは、コマンドとコンテンツを追加する場合に使用できる 2 つのプロパティを持つ: [PrimaryCommands](/uwp/api/windows.ui.xaml.controls.commandbarflyout.primarycommands)と[SecondaryCommands](/uwp/api/windows.ui.xaml.controls.commandbarflyout.secondarycommands)にします。

既定では、コマンド バーの項目は **PrimaryCommands** コレクションに追加されます。 これらのコマンドは、コマンド バーは表示され、折りたたまれていると、拡張モードの両方に表示されます。 CommandBar とは異なり、プライマリ コマンドは自動的にセカンダリ コマンドにオーバーフローではないと切り詰められている可能性があります。

コマンドは**SecondaryCommands**コレクションに追加することもできます。 セカンダリ コマンドは、コントロールのメニューの部分では表示され、展開モードでのみ表示されます。

### <a name="app-bar-buttons"></a>アプリ バーのボタン

PrimaryCommands と SecondaryCommands には、 [AppBarButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbarbutton.aspx)、 [AppBarToggleButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbartogglebutton.aspx)、および[AppBarSeparator](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbarseparator.aspx)コントロールを直接設定できます。

アプリ バーのボタン コントロールは、アイコンとテキスト ラベルによって特徴付けられます。 これらのコントロールは、コマンド バーで使用するために最適化されていて、コマンド バーやオーバーフロー メニューで、コントロールを表示するかどうかに応じて外観が変化します。

- アプリ バーのボタンがプライマリ コマンドとして使われますが、アイコンのみを含むコマンド バーで表示されます。テキスト ラベルは表示されません。 次のように、コマンドの説明のテキストを表示するヒントを使用することをお勧めします。
    ```xaml
    <AppBarButton Icon="Copy" ToolTipService.ToolTip="Copy"/>
    ```
- アプリ バーのボタンとしてセカンダリ コマンド使用は、ラベルとアイコンが表示されると、メニューに表示されます。

### <a name="other-content"></a>その他のコンテンツ

コマンド バーのポップアップに他のコントロールを追加するには、AppBarElementContainer でラップします。 これにより[DropDownButton]() [SplitButton]()などのコントロールを追加したりより複雑な UI を作成するために[StackPanel]()などのコンテナーを追加できます。

> [!NOTE]
> コマンド バーのポップアップのプライマリまたはセカンダリ コマンドのコレクションに追加するために、要素は[ICommandBarElement](/uwp/api/windows.ui.xaml.controls.icommandbarelement)インターフェイスを実装する必要があります。 AppBarElementContainer は、インターフェイス自体を実装していない場合でも、コマンド バーに要素を追加できるように、このインターフェイスを実装するラッパーです。

ここでは、AppBarElementContainer を使用して、コマンド バーのポップアップに余分な要素を追加します。 SplitButton は、色の選択を許可するプライマリ コマンドに追加されます。 StackPanel は、ズーム コントロールのより複雑なレイアウトを許可するセカンダリ コマンドに追加されます。

> [!NOTE]
> この例では、表示されるコマンドのいずれかが実装していないのみ、コマンド バーのポップアップ UI を示しています。 コマンドの実装について詳しくは、[ボタン](buttons.md)や[コマンド設計の基本](../basics/commanding-basics.md)を参照してください。

:::row:::
    :::column:::
        A collapsed command bar flyout with an open SplitButton<br/>
        ![A command bar flyout with a split button](images/command-bar-flyout-split-button.png)
    :::column-end:::
    :::column:::
        An expanded command bar flyout with custom zoom UI in the menu<br/>
        ![A command bar flyout with complex UI](images/command-bar-flyout-complex-ui.png)
    :::column-end:::
:::row-end:::

```xaml
<CommandBarFlyout>
    <AppBarButton Icon="Cut" ToolTipService.ToolTip="Cut"/>
    <AppBarButton Icon="Copy" ToolTipService.ToolTip="Copy"/>
    <AppBarButton Icon="Paste" ToolTipService.ToolTip="Paste"/>
    <!-- Color controls -->
    <AppBarElementContainer>
        <SplitButton Height="Auto" Margin="0,4,0,0"
                     ToolTipService.ToolTip="Colors"
                     Background="{ThemeResource AppBarItemBackgroundThemeBrush}">
            <SplitButton.Content>
                <Rectangle Width="20" Height="20">
                    <Rectangle.Fill>
                        <SolidColorBrush Color="Red"/>
                    </Rectangle.Fill>
                </Rectangle>
            </SplitButton.Content>
            <SplitButton.Flyout>
                <MenuFlyout>
                    <MenuFlyoutItem Text="Red"/>
                    <MenuFlyoutItem Text="Yellow"/>
                    <MenuFlyoutItem Text="Green"/>
                    <MenuFlyoutItem Text="Blue"/>
                </MenuFlyout>
            </SplitButton.Flyout>
        </SplitButton>
    </AppBarElementContainer>
    <!-- end Color controls -->
    <CommandBarFlyout.SecondaryCommands>
        <!-- Zoom controls -->
        <AppBarElementContainer>
            <AppBarElementContainer.Resources>
                <Style TargetType="Button">
                    <Setter Property="Background"
                            Value="{ThemeResource AppBarItemBackgroundThemeBrush}"/>
                </Style>
                <Style TargetType="TextBlock">
                    <Setter Property="VerticalAlignment" Value="Center"/>
                </Style>
            </AppBarElementContainer.Resources>
            <Grid Margin="12,0">
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width="86"/>
                    <ColumnDefinition Width="Auto"/>
                </Grid.ColumnDefinitions>
                <TextBlock Text="Zoom"/>
                <StackPanel Orientation="Horizontal" Grid.Column="1">
                    <Button>
                        <SymbolIcon Symbol="Remove"/>
                    </Button>
                    <TextBlock Text="50%" Width="40"
                               HorizontalTextAlignment="Center"/>
                    <Button>
                        <SymbolIcon Symbol="Add"/>
                    </Button>
                </StackPanel>
            </Grid>
        </AppBarElementContainer>
        <!-- end Zoom controls -->
        <AppBarSeparator/>
        <AppBarButton Label="Undo" Icon="Undo"/>
        <AppBarButton Label="Redo" Icon="Redo"/>
        <AppBarButton Label="Select all"/>
    </CommandBarFlyout.SecondaryCommands>
</CommandBarFlyout>
```

## <a name="create-a-context-menu-with-secondary-commands-only"></a>セカンダリ コマンドのみでコンテキスト メニューを作成します。

[コンテキスト メニュー](menus.md)MenuFlyout の代わりとして、セカンダリ コマンドのみを使用して、CommandBarFlyout を使用できます。

![セカンダリ コマンドのみを使ったコマンド バーのポップアップ](images/command-bar-flyout-context-menu.png)

```xaml
<Grid>
    <Grid.Resources>
        <!-- A command bar flyout with only secondary commands. -->
        <CommandBarFlyout x:Name="ContextMenu">
            <CommandBarFlyout.SecondaryCommands>
                <AppBarButton Label="Pin" Icon="Pin"/>
                <AppBarButton Label="Unpin" Icon="UnPin"/>
                <AppBarButton Label="Copy" Icon="Copy"/>
                <AppBarSeparator />
                <AppBarButton Label="Properties"/>
            </CommandBarFlyout.SecondaryCommands>
        </CommandBarFlyout>
    </Grid.Resources>

    <Image Source="Assets/licorice.png" Width="300"
           ContextFlyout="{x:Bind ContextMenu}"/>
</Grid>
```

標準的なメニューを作成するのに、DropDownButton で、CommandBarFlyout を使用することもできます。

![ドロップダウン メニューのボタンとしてとコマンド バー ポップアップ](images/command-bar-flyout-button-menu.png)

```xaml
<DropDownButton Content="Mail">
    <DropDownButton.Flyout>
        <CommandBarFlyout Placement="BottomEdgeAlignedLeft">
            <CommandBarFlyout.SecondaryCommands>
                <AppBarButton Icon="MailForward" Label="Forward"/>
                <AppBarButton Icon="MailReply" Label="Reply"/>
                <AppBarButton Icon="MailReplyAll" Label="Reply all"/>
            </CommandBarFlyout.SecondaryCommands>
        </CommandBarFlyout>
    </DropDownButton.Flyout>
</DropDownButton>
```

## <a name="command-bar-flyouts-for-text-controls"></a>テキスト コントロールのコマンド バーのポップアップ

[TextCommandBarFlyout](/uwp/api/microsoft.ui.xaml.controls.textcommandbarflyout)は、テキスト編集のコマンドを含む特殊なコマンド バーのポップアップです。 各テキスト コントロールは、テキストが選択されている場合や、コンテキスト メニュー (右クリック) として自動的に、TextCommandBarFlyout を示します。 テキストのコマンド バーのポップアップがのみ関連するコマンドを表示するテキストの選択に対応します。

:::row:::
    :::column:::
        A text command bar flyout on text selection<br/>
        ![A collapsed text command bar flyout](images/command-bar-flyout-text-selection.png)
    :::column-end:::
    :::column:::
        An expanded text command bar flyout<br/>
        ![An expanded text command bar flyout](images/command-bar-flyout-text-full.png)
    :::column-end:::
:::row-end:::

### <a name="available-commands"></a>利用可能なコマンド

次の表は、TextCommandBarFlyout と表示されるときに含まれているコマンドを示します。

| コマンド | 表示される. |
| ------- | -------- |
| Bold | テキスト コントロールは読み取り専用 (RichEditBox のみ) ではありません。 |
| Italic | テキスト コントロールは読み取り専用 (RichEditBox のみ) ではありません。 |
| Underline | テキスト コントロールは読み取り専用 (RichEditBox のみ) ではありません。 |
| 証明 | IsSpellCheckEnabled が**true**でのスペルに誤りテキストが選択されます。 |
| 切り取り | テキスト コントロールは読み取り専用ではないとテキストが選択されます。 |
| コピー | テキストが選択されている場合。 |
| 貼り付け | テキスト コントロールは読み取り専用ではないとクリップボードがコンテンツです。 |
| 元に戻す | 取り消すことができる操作がある場合。 |
| すべて選択 | テキストを選択することができます。 |

### <a name="custom-text-command-bar-flyouts"></a>カスタム テキスト コマンド バーのポップアップ

TextCommandBarFlyout では、カスタマイズできませんされ、各テキスト コントロールで自動的に管理されます。 ただし、カスタム コマンドを使った TextCommandBarFlyout 既定値を置き換えることができます。

- 既定のテキストの選択に表示される TextCommandBarFlyout を交換するには、カスタム CommandBarFlyout (またはその他のポップアップ型) を作成し、 **SelectionFlyout**プロパティに割り当てます。 SelectionFlyout を**null**に設定すると、選択内容にコマンドは表示されません。
- 既定のコンテキスト メニューとして表示されている TextCommandBarFlyout を置換するには、テキスト コントロールに**ContextFlyout**プロパティにカスタム CommandBarFlyout (またはその他のポップアップ型) を割り当てます。 ContextFlyout を**null**に設定すると、TextCommandBarFlyout ではなく、テキスト コントロールの以前のバージョンに表示されるメニュー ポップアップが表示されます。

## <a name="get-the-sample-code"></a>サンプル コードを入手する

- [XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - インタラクティブな形ですべての XAML コントロールを参照できます。
- [XAML コマンド実行のサンプル](http://go.microsoft.com/fwlink/p/?LinkId=620019)

## <a name="related-articles"></a>関連記事

- [UWP アプリのコマンド設計の基本](../basics/commanding-basics.md)
- [CommandBar クラス](https://msdn.microsoft.com/library/windows/apps/dn279427)
