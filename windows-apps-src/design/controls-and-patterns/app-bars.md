---
Description: コマンド バーを使うと、ユーザーはアプリの最も一般的なタスクに簡単にアクセスできます。
title: コマンド バー
label: App bars/command bars
template: detail.hbs
op-migration-status: ready
ms.date: 05/19/2017
ms.topic: article
keywords: windows 10, uwp
ms.assetid: 868b4145-319b-4a97-82bd-c98d966144db
pm-contact: yulikl
design-contact: ksulliv
dev-contact: niallm
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 461d6d135838a5141e6606d4c77ce21972a45fe1
ms.sourcegitcommit: aeebfe35330aa471d22121957d9b510f6ebacbcf
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/03/2019
ms.locfileid: "58901650"
---
# <a name="command-bar"></a>コマンド バー

コマンド バーを使うと、ユーザーはアプリの最も一般的なタスクに簡単にアクセスできます。 コマンド バーを使うと、アプリ レベルまたはページに固有のコマンドにアクセスできます。これは、ナビゲーション パターンと共に使用することもできます。

> **重要な API**:[コマンド バー クラス](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.commandbar.aspx)、 [AppBarButton クラス](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.appbarbutton.aspx)、 [AppBarToggleButton クラス](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.appbartogglebutton.aspx)、 [AppBarSeparator クラス](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.appbarseparator.aspx)

![アイコンを含むコマンド バーの例](images/controls_appbar_icons.png)

## <a name="is-this-the-right-control"></a>適切なコントロールの選択

CommandBar コントロールは、汎用的で柔軟、軽量なコントロールです。画像やテキスト ブロックなどの複雑なコンテンツも、[AppBarButton](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.appbarbutton.aspx)、[AppBarToggleButton](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.appbartogglebutton.aspx)、[AppBarSeparator](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.appbarseparator.aspx) コントロールなどの単純なコマンドも表示できます。

> [!NOTE]
> XAML では、[AppBar](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.appbar) コントロールと [CommandBar](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.commandbar) コントロールの両方が提供されます。 AppBar を使うユニバーサル Windows 8 アプリをアップグレードする場合にのみ、AppBar を使ってください。また、変更は最小限に抑える必要があります。 Windows 10 の新しいアプリでは、代わりに CommandBar コントロールを使うことをお勧めします。 このドキュメントでは、CommandBar コントロールを使うことを前提としています。

## <a name="examples"></a>例

<table>
<th align="left">XAML コントロール ギャラリー<th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックして<a href="xamlcontrolsgallery:/item/CommandBar">アプリを開き、CommandBar の動作を確認</a>してください。</p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</a></li>
    <li><a href="https://github.com/Microsoft/Xaml-Controls-Gallery">ソース コード (GitHub) を入手する</a></li>
    </ul>
</td>
</tr>
</table>

Microsoft フォト アプリの展開されたコマンド バーです。

![Microsoft フォト アプリのコマンドバー](images/control-examples/command-bar-photos.png)

Windows Phone の Outlook カレンダーのコマンド バーです。

![Outlook カレンダー アプリのコマンド バー](images/control-examples/command-bar-calendar-phone.png)

## <a name="anatomy"></a>構造

既定で、コマンド バーにアイコンのボタンと、省略可能な「詳細」ボタンの省略記号によって表される行が表示されます\[•\]します。 後で示すコード例を使って作成されたコマンド バーを次に示します。 コマンド バーは、閉じたコンパクトな状態で表示されます。

![閉じたコマンド バー](images/command-bar-compact.png)

コマンド バーは、次のように、閉じた最小の状態で表示することもできます。 詳しくは、「[開いた状態と閉じた状態](#open-and-closed-states)」をご覧ください。

![閉じたコマンド バー](images/command-bar-minimal.png)

同じコマンド バーが開いている状態を次に示します。 ラベルは、コントロールのメイン部分を識別します。

![閉じたコマンド バー](images/commandbar_anatomy_open.png)

コマンド バーは、4 つの主な領域に分かれています。
- コンテンツ領域はバーの左側に配置されます。 これは、[Content](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.contentcontrol.content.aspx) プロパティが指定されている場合に表示されます。
- 基本コマンド領域はバーの右側に配置されます。 これは、[PrimaryCommands](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.commandbar.primarycommands.aspx) プロパティが指定されている場合に表示されます。  
- See 以上" \[•\]ボタン バーの右側に表示します。 See 以上"キーを押して\[•\] primary コマンドのラベルし、セカンダリ コマンドがある場合は、オーバーフロー メニューを開き、ボタンが表示されます。 このボタンは、プライマリ コマンド ラベルもセカンダリ ラベルもない場合には表示されません。 既定の動作を変更するには、[OverflowButtonVisibility](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.commandbar.overflowbuttonvisibility.aspx) プロパティを使います。
- オーバーフロー メニューは、コマンド バーが開いていて、[SecondaryCommands](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.commandbar.secondarycommands.aspx) プロパティが指定されている場合にのみ表示されます。 スペースが限られている場合に、プライマリ コマンドは SecondaryCommands 領域に移動されます。 既定の動作を変更するには、[IsDynamicOverflowEnabled](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.commandbar.isdynamicoverflowenabled.aspx) プロパティを使います。

[FlowDirection](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.frameworkelement.flowdirection.aspx) が **RightToLeft** のときは、レイアウトが逆になります。

## <a name="create-a-command-bar"></a>コマンド バーの作成
次の例では、上に示したコマンド バーが作成されます。

```xaml
<CommandBar>
    <AppBarToggleButton Icon="Shuffle" Label="Shuffle" Click="AppBarButton_Click" />
    <AppBarToggleButton Icon="RepeatAll" Label="Repeat" Click="AppBarButton_Click"/>
    <AppBarSeparator/>
    <AppBarButton Icon="Back" Label="Back" Click="AppBarButton_Click"/>
    <AppBarButton Icon="Stop" Label="Stop" Click="AppBarButton_Click"/>
    <AppBarButton Icon="Play" Label="Play" Click="AppBarButton_Click"/>
    <AppBarButton Icon="Forward" Label="Forward" Click="AppBarButton_Click"/>

    <CommandBar.SecondaryCommands>
        <AppBarButton Label="Like" Click="AppBarButton_Click"/>
        <AppBarButton Label="Dislike" Click="AppBarButton_Click"/>
    </CommandBar.SecondaryCommands>

    <CommandBar.Content>
        <TextBlock Text="Now playing..." Margin="12,14"/>
    </CommandBar.Content>
</CommandBar>
```

## <a name="commands-and-content"></a>コマンドとコンテンツ
コマンド バー コントロールには、コマンドとコンテンツを追加する際、3 つのプロパティがあります。[PrimaryCommands](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.commandbar.primarycommands.aspx)、 [SecondaryCommands](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.commandbar.secondarycommands.aspx)、および[コンテンツ](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.contentcontrol.content.aspx)します。


### <a name="commands"></a>コマンド

既定では、コマンド バーの項目は **PrimaryCommands** コレクションに追加されます。 最も重要なコマンドを常に表示できるように、重要度順にコマンドを追加する必要があります。 ユーザーによるアプリ ウィンドウのサイズ変更などでコマンド バーの幅が変化した場合、プライマリ コマンドはブレークポイントを境としてコマンド バーとオーバーフロー メニューの間を動的に移動します。 この既定の動作を変更するには、[IsDynamicOverflowEnabled](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.commandbar.isdynamicoverflowenabled.aspx) プロパティを使います。 

最小画面 (幅 320 epx) には、最大 4 つのプライマリ コマンドを、コマンド バーに配置できます。 

**SecondaryCommands** コレクションにコマンドを追加することもできます。これらは、オーバーフロー メニューに表示されます。

![[その他] 領域とアイコンがあるコマンド バーの例](images/appbar_rs2_overflow_icons.png)

必要に応じて、プログラムを使って PrimaryCommands と SecondaryCommands の間でコマンドを移動できます。

- *複数のページで一貫して表示されるコマンドがある場合は、一貫した場所にそのコマンドを配置することをお勧めします。*
- *また、[Accept] （承諾）、[Yes] （はい）、[OK] （OK） コマンドは、[Reject] （拒否）、[No] （いいえ）、[Cancel] （キャンセル） コマンドの左に配置することをお勧めします。 一貫性があることで、ユーザーは安心してシステム内を移動でき、アプリのナビゲーションに関する知識をさまざまなアプリで利用することができます。*

### <a name="app-bar-buttons"></a>アプリ バーのボタン

PrimaryCommands と SecondaryCommands には、どちらも [AppBarButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbarbutton.aspx)、[AppBarToggleButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbartogglebutton.aspx)、[AppBarSeparator](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbarseparator.aspx) の各コマンド要素のみを入力できます。 

アプリ バーのボタン コントロールは、アイコンとテキスト ラベルによって特徴付けられます。 これらのコントロールは、コマンド バーで使うように最適化されており、コマンド バーとオーバーフロー メニューのどちらで使うかに応じて外観が変化します。

オーバーフロー メニューのアイコンのサイズは 16 x 16 ピクセルで、基本コマンド領域のアイコン (20 x 20 ピクセル) よりも小さくなります。 SymbolIcon、FontIcon、または PathIcon を使うと、コマンドがセカンダリ コマンド領域に表示されるときに、忠実さを失うことなく、適切なサイズに自動的に調整されます。 

### <a name="button-labels"></a>ボタンのラベル
AppBarButton [IsCompact](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.appbarbutton.IsCompact) プロパティはラベルが表示されるかどうかを決定します。 CommandBar コントロールで、コマンド バーの開閉に応じてコマンド バーがボタンの IsCompact プロパティを自動的に上書きします。

アプリ バー ボタンのラベルを配置するには、CommandBar の [DefaultLabelPosition](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.commandbar.defaultlabelposition.aspx) プロパティを使用します。

```xaml
<CommandBar DefaultLabelPosition="Right">
    <AppBarToggleButton Icon="Shuffle" Label="Shuffle"/>
    <AppBarToggleButton Icon="RepeatAll" Label="Repeat"/>
</CommandBar>
```

![ラベルが右に配置されたコマンド バー](images/app-bar-labels-on-right.png)

比較的大きなウィンドウの場合は、ラベルを見やすくするためにアプリ バーのボタン アイコンの右に移動することを検討します。 ラベルを下に配置すると、コマンド バーを開かないとラベルが見えませんが、ラベルを右に配置すると、コマンド バーが閉じていてもラベルが見えます。

オーバーフロー メニューで、ラベルは既定ではアイコンの右側に配置され、**LabelPosition** は無視されます。 スタイルを調整するには、[CommandBarOverflowPresenterStyle](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.CommandBar.CommandBarOverflowPresenterStyle) プロパティを、[CommandBarOverflowPresenter](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.commandbaroverflowpresenter) をターゲットにする Style に設定します。 

ボタンのラベルは、短く、可能であれば 1 つの単語にすることをお勧めします。 アイコンの下の長いラベルは複数の行に折り返されるため、開いたコマンド バーの全体的な高さが増します。 ラベルのテキストにソフト ハイフン文字 (0x00AD) を含めると、テキストの中で単語を分割する位置を示すことができます。 XAML でこの処理を行うには、次のようなエスケープ シーケンスを使います。

```xaml
<AppBarButton Icon="Back" Label="Areally&#x00AD;longlabel"/>
```

指定した場所でラベルが折り返されると、次のようになります。

![ラベルが折り返されたアプリ バーのボタン](images/app-bar-button-label-wrap.png)

### <a name="command-bar-flyouts"></a>コマンド バーのポップアップ

コマンドは論理的にグループ化することを検討します。たとえば、[返信]、[全員に返信]、[転送] を [応答] メニューに配置します。 通常、アプリ バー ボタンは単一のコマンドをアクティブ化しますが、アプリ バー ボタンを使用して、カスタム コンテンツを持つ [MenuFlyout](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.menuflyout.aspx) または [Flyout](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.flyout.aspx) を表示できます。

![コマンド バーでのポップアップの例](images/AppbarGuidelines_Flyouts.png)

### <a name="other-content"></a>その他のコンテンツ

XAML 要素をコンテンツ領域に追加するには、**Content** プロパティを設定します。 複数の要素を追加する場合は、それらの要素をパネル コンテナーに配置し、パネルを Content プロパティの唯一の子にする必要があります。

動的オーバーフローが有効になっている場合は、プライマリ コマンドがオーバーフロー メニューに移動するため、コンテンツはクリップされません。 それ以外の場合は、プライマリ コマンドが優先されるため、コンテンツがクリップされる可能性があります。

[ClosedDisplayMode](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.closeddisplaymode.aspx) が **Compact** の場合、コンパクト サイズのコマンド バーよりも大きいコンテンツはクリップされる可能性があります。 UI の一部がクリップされないようにするには、コンテンツ領域で UI の各部分を表示または非表示にするように [Opening](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.opening.aspx) と [Closed](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.closed.aspx) の各イベントを処理する必要があります。 詳しくは、「[開いた状態と閉じた状態](#open-and-closed-states)」をご覧ください。


## <a name="open-and-closed-states"></a>開いた状態と閉じた状態

コマンド バーは、開いたり閉じたりできます。 開いているときは、テキスト ラベルが付いた primary コマンド ボタンを表示してと (セカンダリ コマンドがある) 場合は、オーバーフロー メニューを開きます。
コマンド バー メニューを開き、オーバーフロー上 (プライマリ コマンド) 上または下 (プライマリ コマンド) 以下。 既定の方向しますが、上方にオーバーフロー メニューを開くには、十分な領域がない場合、コマンド バー開くために下方向。 

ユーザーは、キーを押して、「参照」これらの状態を切り替えることができます\[•\]ボタンをクリックします。 プログラムで切り替えるには、[IsOpen](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.isopen.aspx) プロパティを設定します。 

[Opening](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.opening.aspx)、[Opened](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.opened.aspx)、[Closing](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.closing.aspx)、[Closed](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.closed.aspx) の各イベントを使うと、コマンド バーの開閉に対応できます。  
- Opening イベントと Closing イベントが発生するのは、切り替えアニメーションの開始前です。
- Opened イベントと Closed イベントが発生するのは、切り替えの完了後です。

次の例では、Opening イベントと Closing イベントを使ってコマンド バーの不透明度を変更します。 コマンド バーが閉じているときは、アプリの背景が見えるようにコマンド バーが半透明になります。 コマンド バーが開いているときは、ユーザーがコマンドに集中できるようにコマンド バーが不透明になります。

```xaml
<CommandBar Opening="CommandBar_Opening"
            Closing="CommandBar_Closing">
    <AppBarButton Icon="Accept" Label="Accept"/>
    <AppBarButton Icon="Edit" Label="Edit"/>
    <AppBarButton Icon="Save" Label="Save"/>
    <AppBarButton Icon="Cancel" Label="Cancel"/>
</CommandBar>
```

```csharp
private void CommandBar_Opening(object sender, object e)
{
    CommandBar cb = sender as CommandBar;
    if (cb != null) cb.Background.Opacity = 1.0;
}

private void CommandBar_Closing(object sender, object e)
{
    CommandBar cb = sender as CommandBar;
    if (cb != null) cb.Background.Opacity = 0.5;
}

```

### <a name="issticky"></a>IsSticky

コマンド バーが開いているときにユーザーがアプリの他の部分とやり取りすると、コマンド バーは自動的に閉じます。 これは*簡易非表示*と呼ばれます。 簡易非表示動作を制御するには、[IsSticky](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.issticky.aspx) プロパティを設定します。 ときに`IsSticky="true"`、ユーザーは、「参照」を押すまで、バーが開いたまま\[•\]ボタンまたはオーバーフロー メニューから項目を選択します。 

に対するユーザーの期待に準拠していないため、固定のコマンド バーを回避することをお勧めします。[光を無視し、キーボード フォーカスの動作](https://docs.microsoft.com/windows/uwp/design/controls-and-patterns/menus#light-dismiss)します。

### <a name="display-mode"></a>表示モード

コマンド バーが閉じた状態でどのように表示されるか制御するには、[ClosedDisplayMode](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.closeddisplaymode.aspx) プロパティを設定します。 3 つのクローズド表示モードから選ぶことができます。
- **Compact**:既定のモード。 コンテンツ、primary コマンド アイコン、ラベルがない場合、「参照」が詳細を示しています。 \[•\]ボタンをクリックします。
- **最小**:示していますが、「詳細」としてのみ、細いバーを動作\[•\]ボタンをクリックします。 ユーザーはバーの任意の場所を押してバーを開くことができます。
- **非表示に**:閉じているときは、コマンド バーは表示されません。 このモードは、インライン コマンド バーでコンテキスト依存コマンドを表示するときに便利な場合があります。 この場合は、コマンド バーをプログラムで開く必要があります。この操作を行うには、**IsOpen** プロパティを設定するか、ClosedDisplayMode を **Minimal** または **Compact** に変更します。

以下では、コマンド バーを使って [RichEditBox](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richeditbox.aspx) に単純な書式設定コマンドを保持しています。 編集ボックスにフォーカスがないときには、書式設定コマンドが煩わしくないように非表示にします。 編集ボックスを使っているときは、コマンド バーの ClosedDisplayMode を Compact に変更して書式設定コマンドを表示します。

```xaml
<StackPanel Width="300"
            GotFocus="EditStackPanel_GotFocus"
            LostFocus="EditStackPanel_LostFocus">
    <CommandBar x:Name="FormattingCommandBar" ClosedDisplayMode="Hidden">
        <AppBarButton Icon="Bold" Label="Bold" ToolTipService.ToolTip="Bold"/>
        <AppBarButton Icon="Italic" Label="Italic" ToolTipService.ToolTip="Italic"/>
        <AppBarButton Icon="Underline" Label="Underline" ToolTipService.ToolTip="Underline"/>
    </CommandBar>
    <RichEditBox Height="200"/>
</StackPanel>
```

```csharp
private void EditStackPanel_GotFocus(object sender, RoutedEventArgs e)
{
    FormattingCommandBar.ClosedDisplayMode = AppBarClosedDisplayMode.Compact;
}

private void EditStackPanel_LostFocus(object sender, RoutedEventArgs e)
{
    FormattingCommandBar.ClosedDisplayMode = AppBarClosedDisplayMode.Hidden;
}
```

>**注**&nbsp;&nbsp;この例では編集コマンドの実装については取り上げません。 詳しくは、「[RichEditBox](rich-edit-box.md)」をご覧ください。

Minimal モードと Hidden モードが役に立つ場合もありますが、すべてのアクションを非表示にするとユーザーが混乱する可能性があることに注意してください。

ClosedDisplayMode を変更してユーザーにヒントを表示すると、周囲にある要素のレイアウトが影響を受けます。 これに対し、CommandBar の開閉を切り替えても他の要素のレイアウトには影響しません。

## <a name="placement"></a>配置
コマンド バーは、アプリ ウィンドウの上部、アプリ ウィンドウの下部、またはインラインに配置できます。

![アプリ バーの配置の例 1](images/AppbarGuidelines_Placement1.png)

-   小型の携帯デバイスでは、コマンド バーを画面の下部に配置して、操作しやすくことをお勧めします。
-   大きな画面を持つデバイスでは、では、コマンド バーは、ウィンドウの上端近くに配置して、気付きやすくします。

物理的な画面サイズを調べるには、[DiagonalSizeInInches](https://msdn.microsoft.com/library/windows/apps/windows.graphics.display.displayinformation.diagonalsizeininches.aspx) API を使います。

コマンド バーは、単一ビュー画面 (左側の例) と複数ビュー画面 (右側の例) の次の画面領域に配置できます。 インラインのコマンド バーは、アクション領域の任意の場所に配置できます。

![アプリ バーの配置の例 2](images/AppbarGuidelines_Placement2.png)

>**デバイスのタッチ**:かどうかは、コマンド バーがユーザーに表示する必要がありますままタッチ キーボード、またはソフト入力パネル (SIP) は、コマンド バーを割り当てることが表示されたら、[は BottomAppBar](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.page.bottomappbar.aspx)ページとそのプロパティは、SIP が存在する場合に表示されたままに移動. それ以外の場合は、コマンド バーをインラインおよびアプリのコンテンツに対して相対的に配置します。

## <a name="get-the-sample-code"></a>サンプル コードを入手する

- [XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Xaml-Controls-Gallery) - インタラクティブな形で XAML コントロールのすべてを参照できます。
- [XAML コマンド実行のサンプル](https://go.microsoft.com/fwlink/p/?LinkId=620019)

## <a name="related-articles"></a>関連記事

* [UWP アプリのコマンド設計の基本](../basics/commanding-basics.md)
* [CommandBar クラス](https://msdn.microsoft.com/library/windows/apps/dn279427)
