---
label: アプリ バー/コマンド バー
template: detail.hbs
---

# アプリ バーとコマンド バー

コマンド バー ("アプリ バー" とも呼ばれます) を使うと、ユーザーはアプリの最も一般的なタスクに簡単にアクセスできます。コマンド バーは、ユーザーのコンテキストに固有のコマンドやオプション (写真の選択や描画モードなど) を表示するために使うことができます。 また、アプリのページやセクション間のナビゲーションにも使うことができます。 コマンド バーは、ナビゲーション パターンと一緒に使うことができます。

![アイコンを含むコマンド バーの例](images/controls_appbar_icons.png)

<span class="sidebar_heading" style="font-weight: bold;">重要な API</span>

-   [**CommandBar **](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.commandbar.aspx)
-   [**AppBarButton**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.appbarbutton.aspx)
-   [**AppBarToggleButton**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.appbartogglebutton.aspx)
-   [**AppBarSeparator**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.appbarseparator.aspx)

## 適切なコントロールの選択

CommandBar コントロールは、汎用的で柔軟、軽量なコントロールです。画像、進行状況バー、テキスト ブロックなどの複雑なコンテンツも、[AppBarButton](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.appbarbutton.aspx)、[AppBarToggleButton](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.appbartogglebutton.aspx)、[AppBarSeparator](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.appbarseparator.aspx) コントロールなどの単純なコマンドも表示できます。

XAML では、AppBar コントロールと CommandBar コントロールの両方が提供されます。 AppBar を使うユニバーサル Windows 8 アプリをアップグレードする場合にのみ、AppBar を使ってください。また、変更は最小限に抑える必要があります。 Windows 10 の新しいアプリでは、代わりに CommandBar コントロールを使うことをお勧めします。 このドキュメントでは、CommandBar コントロールを使うことを前提としています。

## 例

![アプリ バーの配置の例 1](images/AppbarGuidelines_Placement1.png)

## 構造

既定では、コマンド バーには、一連のアイコン ボタンと [その他] ボタン (省略記号の \[•••\]) が表示されます。 後で示すコード例を使って作成されたコマンド バーを次に示します。 コマンド バーは既定の、閉じたコンパクトな状態で表示されます。

![閉じたコマンド バー](images/command-bar-compact.png)

コマンド バーは次のように、閉じた最小の状態で表示することもできます。 詳しくは、「[開いた状態と閉じた状態](#open-and-closed-states)」をご覧ください。 

![閉じたコマンド バー](images/command-bar-minimal.png)

同じコマンド バーが開いている状態を次に示します。 ラベルは、コントロールのメイン部分を識別します。

![閉じたコマンド バー](images/commandbar_anatomy_open.png)

コマンド バーは、4 つの主な領域に分かれています。
- [その他] (\[•••\] ) ボタンはバーの右側に表示されます。常に表示された状態です。 [その他] (\[•••\] ) ボタンを押すと 2 つの効果があり、プライマリ コマンド ボタンのラベルが表示され、セカンダリ コマンドが存在する場合はオーバーフロー メニューが開きます。
- コンテンツ領域はバーの左側に配置されます。 Content プロパティが入力されている場合に表示されます。
- 基本コマンド領域はバーの右側の [その他] (\[•••\] ) ボタンの横に配置されます。 PrimaryCommands プロパティが入力されている場合に表示されます。  
- オーバーフロー メニューは、コマンド バーが開き、SecondaryCommands プロパティが入力されている場合にのみ表示されます。

[FlowDirection]() が **RightToLeft** のときは、レイアウトが逆になります。

## コマンド バーの作成
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
        <AppBarButton Icon="Like" Label="Like" Click="AppBarButton_Click"/>
        <AppBarButton Icon="Dislike" Label="Dislike" Click="AppBarButton_Click"/>
    </CommandBar.SecondaryCommands>

    <CommandBar.Content>
        <TextBlock Text="Now playing..." Margin="12,14"/>
    </CommandBar.Content>
</CommandBar>
```

## コマンドとコンテンツ
CommandBar コントロールには [**PrimaryCommands**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.commandbar.primarycommands.aspx)、[**SecondaryCommands**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.commandbar.secondarycommands.aspx)、[**Content**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.contentcontrol.content.aspx) の 3 つのプロパティがあり、コマンドとコンテンツを追加するために使うことができます。 

コマンド バーに配置するアクションは、優先順位に基づいて見やすくします。

### プライマリ操作とオーバーフロー

既定では、コマンド バーに追加した項目は **PrimaryCommands** コレクションに追加されます。 これらのコマンドは [その他] (\[•••\]) ボタンの左側の、アクション領域と呼ばれる場所に表示されます。 バーに常に表示する最も重要なコマンドは、アクション領域に配置します。 最小画面 (幅 320 epx) では、他の画面 UI に応じて 2 ～ 4 項目がコマンド バーのアクション領域に収まります。

**SecondaryCommands** コレクションにコマンドを追加できます。これらの項目は、オーバーフロー領域に表示されます。 重要度の低いコマンドは、オーバーフロー領域に配置します。

既定のオーバーフロー領域には、バーとは別に表示されるスタイルが適用されます。 スタイルを調整するには、[**CommandBarOverflowPresenterStyle**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.commandbar.commandbaroverflowpresenterstyle.aspx) プロパティを、[**CommandBarOverflowPresenter**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.commandbaroverflowpresenter.aspx) をターゲットにする [Style](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.style.aspx) に設定します。

必要に応じて、プログラムを使って PrimaryCommands と SecondaryCommands の間でコマンドを移動できます。 ただし、コマンド バーの幅の変更に合わせてコマンドがオーバーフロー領域の内外に自動的に移動することはありません。

### アプリ バーのボタン

PrimaryCommands と SecondaryCommands はどちらも、[**AppBarButton**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbarbutton.aspx)、[**AppBarToggleButton**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbartogglebutton.aspx)、[**AppBarSeparator**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbarseparator.aspx) の各コマンド要素のみを入力できます。 これらのコントロールは、コマンド バーで使うように最適化されており、アクション領域とオーバーフロー領域のどちらで使うかに応じて外観が変化します。

アプリ バーのボタン コントロールは、アイコンとアイコンに関連付けられたラベルによって特徴付けられます。 標準とコンパクトの 2 つのサイズがあります。 既定では、テキスト ラベルが表示されます。 [
            **IsCompact**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbarbutton.iscompact.aspx) プロパティを **true** に設定すると、テキスト ラベルが非表示になります。 CommandBar コントロールで使う場合、コマンド バーの開閉に応じてコマンド バーがボタンの IsCompact プロパティを自動的に設定します。

アプリ バーのボタンをオーバーフロー メニュー (SecondaryCommands) に配置すると、テキストとしてのみ表示されます。 以下に、同じアプリ バーのトグル ボタンがプライマリ コマンドとしてアクション領域に表示された状態 (上) と、セカンダリ コマンドとしてオーバーフロー領域に表示された状態 (下) を示します。

![プライマリ コマンドとセカンダリ コマンドとしてのアプリ バーのボタン](images/app-bar-toggle-button-two-modes.png)

- *複数のページで一貫して表示されるコマンドがある場合は、一貫した場所にそのコマンドを配置することをお勧めします。* 
- *また、[Accept] (承諾)、[Yes] (はい)、[OK] (OK) コマンドは、[Reject] (拒否)、[No] (いいえ)、[Cancel] (キャンセル) コマンドの左に配置することをお勧めします。 一貫性があることで、ユーザーは安心してシステム内を移動でき、アプリのナビゲーションに関する知識をさまざまなアプリで利用することができます。*

### その他のコンテンツ

XAML 要素をコンテンツ領域に追加するには、**Content** プロパティを設定します。 複数の要素を追加する場合は、それらの要素をパネル コンテナーに配置し、パネルを Content プロパティの唯一の子にする必要があります。

プライマリ コマンドとコンテンツの両方がある場合は、プライマリ コマンドが優先され、コンテンツがクリップされる可能性があります。

[
            **ClosedDisplayMode**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.closeddisplaymode.aspx) が **Compact** の場合、コンテンツがコンパクトなサイズのコマンド バーよりも大きいと、コンテンツがクリップされる可能性があります。 UI の一部がクリップされないようにするには、コンテンツ領域で UI の各部分を表示または非表示にするように [**Opening**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.opening.aspx) と [**Closed**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.closed.aspx) の各イベントを処理する必要があります。 詳しくは、「[開いた状態と閉じた状態](#open-and-closed-states)」をご覧ください。

### ラベルとヒント

アプリ バーのボタンのテキスト ラベルが長すぎて 1 行に収まらない場合は、テキスト ラベルが次の行に折り返され、バーを開いたときのバー全体の高さが増加します。 ラベルのテキストにソフト ハイフン文字 (0x00AD) を含めると、テキストの中で単語を分割する位置を示すことができます。 XAML でこの処理を行うには、次のようなエスケープ シーケンスを使います。

```xaml
<AppBarButton Icon="Back" Label="Areally&#x00AD;longlabel"/>
```

指定した場所でラベルが折り返されると、次のようになります。

![ラベルが折り返されたアプリ バーのボタン](images/app-bar-button-label-wrap.png)

[その他] (\[•••\]) を押さない限り、テキスト ラベルはコマンド バーの操作に対して非表示になるため、アクション アイコンのヒントを使用することを検討します。 これにより、マウスのユーザーが操作の目的を理解しやすくなります。

## 開いた状態と閉じた状態

コマンド バーは、開いたり閉じたりできます。 ユーザーは、[その他] (\[•••\]) ボタンを押して状態を切り替えることができます。 プログラムで切り替えるには、[**IsOpen**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.isopen.aspx) プロパティを設定します。 開いた状態の場合、プライマリ コマンド ボタンはテキスト ラベル付きで表示され、上に示したように、セカンダリ コマンドが存在するときはオーバーフロー メニューが開きます。

[
            **Opening**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.opening.aspx)、[**Opened**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.opened.aspx)、[**Closing**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.closing.aspx)、[**Closed**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.closed.aspx) の各イベントを使うと、コマンド バーの開閉に対応できます。  
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

### ClosedDisplayMode

コマンド バーが閉じた状態でどのように表示されるか制御するには、[**ClosedDisplayMode**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.closeddisplaymode.aspx) プロパティを設定します。 3 つのクローズド表示モードから選ぶことができます。
- **Compact**: 既定のモードです。 コンテンツ、プライマリ コマンドのアイコン (ラベルなし)、[その他] (\[•••\]) ボタンが表示されます。
- **Minimal**: [その他] (\[•••\]) ボタンとして機能する細いバーのみが表示されます。 ユーザーはバーの任意の場所を押してバーを開くことができます。
- **Hidden**: コマンド バーを閉じたとき、コマンド バーは表示されません。 このモードは、インライン コマンド バーでコンテキスト依存コマンドを表示するときに便利な場合があります。 この場合は、コマンド バーをプログラムで開く必要があります。この操作を行うには、**IsOpen** プロパティを設定するか、ClosedDisplayMode を **Minimal** または **Compact** に変更します。 

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

### IsSticky

ユーザーがコマンド バーを開いた後、コントロールの外側の任意の場所でアプリを操作すると、既定では、オーバーフロー メニューが閉じ、ラベルが非表示になります。 この方法で閉じることを*簡易非表示*と呼びます。 バーが閉じる方法を制御するには、[**IsSticky**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.issticky.aspx) プロパティを設定します。 バーが固定の場合 (`IsSticky="true"`)、簡易非表示ジェスチャでは閉じません。 ユーザーが [その他] (\[•••\]) ボタンを押すか、(存在する場合は) オーバーフロー メニューから項目を選ぶまで、バーは開いたままになります。

## 推奨事項

### 配置

コマンド バーはアプリ ウィンドウの上部、アプリ ウィンドウの下部、またはインラインに配置できます。

![アプリ バーの配置の例 1](images/AppbarGuidelines_Placement1.png)

-   モバイル デバイスでは、コマンド バーをアプリに 1 つだけ配置する場合、手に届きやすいように画面の下部に配置します。 アプリの下部にタブがある場合、UI が下部に集中しすぎないように上部にコマンド バーを配置することを検討してください。
-   大きな画面では、コマンド バーを 1 つだけ配置する場合、画面の上部に配置することをお勧めします。
-   ユーザーがコンテキスト依存アクションに使用できるように、コマンド バーをインラインで配置することもできます。

コマンド バーは、単一ビュー画面 (左側の例) と複数ビュー画面 (右側の例) の次の画面領域に配置できます。 インラインのコマンド バーは、アクション領域の任意の場所に配置できます。

![アプリ バーの配置の例 2](images/AppbarGuidelines_Placement2.png)

>**モバイル デバイス ファミリ**: タッチ キーボード、つまりソフト入力パネル (SIP) が表示されているときに、コマンド バーをユーザーに対して表示したままにする必要がある場合、コマンド バーをページの BottomAppBar プロパティに割り当てると、SIP が表示されているときにはコマンド バーが移動して表示されたままになります。 それ以外の場合は、コマンド バーをインラインおよびアプリのコンテンツに対して相対的に配置します。 コマンド バーを配置する場所は、コマンド バーを固定するかどうかや閉じたときに最小モードを使うかどうかなどに影響を与えます。

### 操作

コマンド バーに配置するアクションには、見やすさに基づいて優先順位を付けます。

-   バーに常に表示する最も重要なコマンドは、アクション領域の最初の数スロットに配置します。 最小画面 (幅 320 epx) では、他の画面 UI に応じて 2 ～ 4 項目がコマンド バーのアクション領域に収まります。
-   重要度の低いコマンドは、バーのアクション領域の後方に配置するか、オーバーフロー領域の最初の数スロット内に配置します。 これらのコマンドは、バーに十分な画面領域がある場合は表示されますが、十分な領域がない場合はオーバーフロー領域のドロップダウン メニューに収まります。
-   最も重要度の低いコマンドは、オーバーフロー領域内に配置します。 これらのコマンドは、常にドロップダウン メニューに表示されます。

アクション領域の項目は、アイコンまたはボタンのいずれかを使って視覚化できます。 アイコンのみを使う場合は、テキスト ラベルを含めます。 テキスト ラベルは、[その他] (\[•••\]) ボタンが押されたときにアイコンの下に表示されます。

複数のページで一貫して表示されるコマンドがある場合は、一貫した場所にそのコマンドを配置することをお勧めします。 また、[Accept] (承諾)、[Yes] (はい)、[OK] (OK) コマンドは、[Reject] (拒否)、[No] (いいえ)、[Cancel] (キャンセル) コマンドの左に配置することをお勧めします。 一貫性があることで、ユーザーは安心してシステム内を移動でき、アプリのナビゲーションに関する知識をさまざまなアプリで利用することができます。

すべてのアクションをオーバーフロー領域内に配置して、コマンド バーに [その他] (\[•••\]) ボタンだけが表示されるようにすることができます。ただし、すべてのアクションを非表示にすると、ユーザーが混乱する可能性があることに注意してください。

### コマンド バーのポップアップとヒント

コマンドは論理的にグループ化することを検討します。たとえば、[返信]、[全員に返信]、[転送] を [応答] メニューに配置します。

![コマンド バーでのポップアップの例](images/AppbarGuidelines_Flyouts.png)

\[•••\] を選択しない限り、テキスト ラベルはコマンド バーの操作に対して非表示になるため、アクション アイコンのヒントを使用することを検討します。

### オーバーフロー メニュー

![[その他] 領域があるコマンド バーの例](images/AppbarGuidelines_Illustration.png)

-   オーバーフロー メニューは [その他] (\[•••\]) ボタンで表され、メニューの可視エントリ ポイントです。 ツール バー右端のプライマリ操作の隣に配置されます。
-   プライマリ操作領域の各操作は、アイコンで表されます。 オーバーフロー メニューを選ぶと、プライマリ操作領域の各操作のテキスト ラベルが表示されます。
-   オーバーフロー領域は、使用頻度が少ない操作に割り当てられます。
-   操作は、ブレークポイントを境としてプライマリ操作領域とオーバーフロー メニューの間で移動させることができます。 画面またはアプリのウィンドウ サイズに関係なく、常にアクションをプライマリ操作領域内に維持するように指定することもできます。
-   使用頻度の低いアクションは、より大きな画面でアプリ バーを展開したときに、オーバーフロー メニュー内に残しておくことができます。

## 応答性のガイダンス

-   アプリ バー内のアクションと同じ数のアクションが、縦向きと横向きの両方の向きで表示される必要があります。これにより、ユーザーが認識する負荷が軽減されます。 利用可能なアクションの数は、縦向きでのデバイスの幅によって決まります。
-   ブレークポイントをターゲットにすると、メニューのサイズやアプリ ウィンドウのサイズの変化に応じてアクションをメニューの内外に移動できます。

\[この記事には、ユニバーサル Windows プラットフォーム (UWP) アプリと Windows 10 に固有の情報が含まれています。 Windows 8.1 のガイダンスについては、[Windows 8.1 ガイドラインの PDF](https://go.microsoft.com/fwlink/p/?linkid=258743) ファイルをダウンロードしてください。\]

## 関連記事

**デザイナー向け**
[UWP アプリのコマンド設計の基本](https://msdn.microsoft.com/library/windows/apps/dn958433)

**開発者向け (XAML)**
[**CommandBar**](https://msdn.microsoft.com/library/windows/apps/dn279427)



<!--HONumber=Mar16_HO1-->


