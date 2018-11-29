---
Description: Learn how accelerator keys can improve the usability and accessibility of UWP apps.
title: キーボード アクセラレータ
label: Keyboard accelerators
template: detail.hbs
keywords: キーボード, アクセラレータ, アクセラレータ キー, キーボード ショートカット, アクセシビリティ, ナビゲーション, フォーカス, テキスト, 入力, ユーザーの操作, ゲームパッド, リモート
ms.date: 10/10/2017
ms.topic: article
pm-contact: chigy
design-contact: miguelrb
doc-status: Draft
ms.localizationpriority: medium
ms.openlocfilehash: 6f764d15c1bf5a52a6a48a45856daf9031bbd346
ms.sourcegitcommit: b5c9c18e70625ab770946b8243f3465ee1013184
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/29/2018
ms.locfileid: "7986979"
---
# <a name="keyboard-accelerators"></a>キーボード アクセラレータ

![Surface キーボード](images/accelerators/accelerators_hero2.png)

アクセラレータ キー (キーボード アクセラレータ) は、アプリの UI 間を移動せずに一般的な操作やコマンドを呼び出すための直感的な方法をユーザーに提供して、Windows アプリケーションの使いやすさとアクセシビリティを向上させるキーボード ショートカットです。

キーボード ショートカットを使って Windows アプリケーションの UI に移動する方法について詳しくは、「[アクセス キー ](access-keys.md)」をご覧ください。

> [!NOTE]
> キーボードは、特定の障碍を持つユーザーにとっては不可欠であり ([キーボードのアクセシビリティ](https://docs.microsoft.com/windows/uwp/accessibility/keyboard-accessibility)をご覧ください)、アプリをより効率的に操作することを望むユーザーにとって重要なツールでもあります。

## <a name="overview"></a>概要

通常、アクセラレータには F1 から F12 までのファンクション キーや、標準キーと 1 つ以上の修飾キー (Ctrl、Shift など) の組み合わせが含まれます。

> [!NOTE]
> UWP プラットフォームのコントロールには、組み込みのキーボード アクセラレータが用意されています。 たとえば、ListView では Ctrl + A (一覧のすべての項目を選択する) がサポートされ、RichEditBox では Ctrl + Tab (テキスト ボックスにタブを挿入する) がサポートされています。 これらの組み込みキーボード アクセラレータは、**コントロール アクセラレータ**と呼ばれ、要素またはその子にフォーカスがある場合にのみ実行されます。 ここで説明するキーボード アクセラレータ API を使用して定義するアクセラレータは、**アプリ アクセラレータ**と呼ばれます。

キーボード アクセラレータは、すべてのアクションに用意されるのではなく、多くの場合はメニューで公開されているコマンドに関連付けられています (メニュー項目コンテンツにも示されています)。アクセラレータは、対応するメニュー項目がない操作に関連付けることもできます。 ただし、ユーザーはアプリケーションのメニューを使用して、利用可能なコマンド セットを見つけ、その機能を理解するため、アクセラレータができるだけ簡単に検出されるようにする必要があります (ラベルの使用や、決まったパターンの使用が役立ちます)。

![メニュー項目ラベルに示されているキーボード アクセラレータ](images/accelerators/accelerators_menuitemlabel.png)  
*メニュー項目ラベルに示されているキーボード アクセラレータ*

## <a name="when-to-use-keyboard-accelerators"></a>キーボード アクセラレータの使用に適したケース

UI に適切な場合は必ずキーボード アクセラレータを指定し、すべてのカスタム コントロールでアクセラレータをサポートすることをお勧めします。

- キーボード アクセラレータによりアプリのさらに、一度に 1 つだけのキーを押してしたりが難しい押せる * を使用しているユーザーを含む、運動障碍を持つ accessiblefor ユーザー

  適切に設計されたキーボード UI はソフトウェアのアクセシビリティの重要な要素であり、 視覚に障碍のあるユーザーや特定の運動障碍のあるユーザーによるアプリ内の移動や、その機能の操作を実現します。 このようなユーザーはマウスを操作できない場合があるため、代わりにさまざまな支援技術 (キーボード強化ツール、スクリーン キーボード、スクリーン拡大機能、スクリーン リーダー、音声入力ユーティリティなど) が不可欠になる可能性があります。 このようなユーザーにとっては、コマンドを包括的にカバーすることが重要です。

- キーボード アクセラレータは、複数 usablefor 好むパワー ユーザーにとって、キーボードを使った操作をアプリを行います。

  多くの経験豊富なユーザーには、キーボードの使用の方がはるかに好まれます。キーボード ベースのコマンドであれば、すばやく入力することができ、キーボードから手を離す必要がないためです。 このようなユーザーにとっては、効率性と一貫性が重要です。包括性が重要になるのは、特に頻繁に使用するコマンドに対してのみです。

## <a name="specify-a-keyboard-accelerator"></a>キーボード アクセラレータを指定する

UWP アプリのキーボード アクセラレータを作成するには、[KeyboardAccelerator](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.input.keyboardaccelerator.-ctor) API を使用します。 これらの API を使用すると、複数の KeyDown イベントを処理してキーの組み合わせの押下を検出する必要がなくなり、アプリのリソース内でアクセラレータをローカライズすることもできます。

アプリ内で特に一般的な操作に対してキーボード アクセラレータを設定し、メニュー項目のラベルまたはツール ヒントを使用してわかりやすく示すことをお勧めします。 この例では、名前の変更コマンドとコピー コマンドに対してのみキーボード アクセラレータを宣言しています。

``` xaml
<CommandBar Margin="0,200" AccessKey="M">
  <AppBarButton 
    Icon="Share" 
    Label="Share" 
    Click="OnShare" 
    AccessKey="S" />
  <AppBarButton 
    Icon="Copy" 
    Label="Copy" 
    ToolTipService.ToolTip="Copy (Ctrl+C)" 
    Click="OnCopy" 
    AccessKey="C">
    <AppBarButton.KeyboardAccelerators>
      <KeyboardAccelerator 
        Modifiers="Control" 
        Key="C" />
    </AppBarButton.KeyboardAccelerators>
  </AppBarButton>

  <AppBarButton 
    Icon="Delete" 
    Label="Delete" 
    Click="OnDelete" 
    AccessKey="D" />
  <AppBarSeparator/>
  <AppBarButton 
    Icon="Rename" 
    Label="Rename" 
    ToolTipService.ToolTip="Rename (F2)" 
    Click="OnRename" 
    AccessKey="R">
    <AppBarButton.KeyboardAccelerators>
      <KeyboardAccelerator 
        Modifiers="None" Key="F2" />
    </AppBarButton.KeyboardAccelerators>
  </AppBarButton>

  <AppBarButton 
    Icon="SelectAll" 
    Label="Select" 
    Click="OnSelect" 
    AccessKey="A" />
  
  <CommandBar.SecondaryCommands>
    <AppBarButton 
      Icon="OpenWith" 
      Label="Sources" 
      AccessKey="S">
      <AppBarButton.Flyout>
        <MenuFlyout>
          <ToggleMenuFlyoutItem Text="OneDrive" />
          <ToggleMenuFlyoutItem Text="Contacts" />
          <ToggleMenuFlyoutItem Text="Photos"/>
          <ToggleMenuFlyoutItem Text="Videos"/>
        </MenuFlyout>
      </AppBarButton.Flyout>
    </AppBarButton>
    <AppBarToggleButton 
      Icon="Save" 
      Label="Auto Save" 
      IsChecked="True" 
      AccessKey="A"/>
  </CommandBar.SecondaryCommands>

</CommandBar>
```

![ツール ヒントに示されたアクセス キーの説明](images/accelerators/accelerators_tooltip.png)  
***ツール ヒントに示されたアクセス キーの説明***

[UIElement](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement) オブジェクトには、[KeyboardAccelerator](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.keyboardaccelerator) コレクションおよび [KeyboardAccelerators](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.KeyboardAccelerators) があり、カスタムの KeyboardAccelerator オブジェクトを指定して、キーボード アクセラレータのキー入力を定義できます。

-   **[Key](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.keyboardaccelerator.Key)** - キーボード アクセラレータに使用される [VirtualKey](https://docs.microsoft.com/uwp/api/windows.system.virtualkey)。

-   **[Modifiers](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.keyboardaccelerator.Modifiers)** – キーボード アクセラレータに使用される [VirtualKeyModifiers](https://docs.microsoft.com/uwp/api/windows.system.virtualkeymodifiers)。 Modifiers が設定されていない場合、既定値は None です。

> [!NOTE]
> 単一キーのアクセラレータ (A、Del、F2、Space キー、Esc キー、マルチメディア キー) と複数キーのアクセラレータ (Ctrl + Shift + M) がサポートされます。 ただし、ゲームパッドの仮想キーはサポートされていません。

## <a name="scoped-accelerators"></a>アクセラレータのスコープ

アクセラレータには、アプリ全体で動作するものと、特定のスコープのみで動作するものがあります。

たとえば、Microsoft Outlook には、次のアクセラレータが含まれています。
-   Ctrl + B、Ctrl + I、Esc キーは、メール送信フォームのスコープのみで動作します。
-   Ctrl + 1 と Ctrl + 2 は、アプリ全体で動作します。

### <a name="context-menus"></a>コンテキスト メニュー

コンテキスト メニューのアクションは、テキスト エディター内で選択された文字やプレイリスト内の曲など、特定の領域または要素のみに影響します。 このため、コンテキスト メニュー項目のキーボード アクセラレータのスコープは、コンテキスト メニューの親に設定することをお勧めします。

キーボード アクセラレータのスコープを指定するには、[ScopeOwner](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.keyboardaccelerator.ScopeOwner)プロパティを使用します。 このコードでは、スコープ指定されたキーボード アクセラレータと共に、コンテキスト メニューを ListView に実装する方法を示します。

``` xaml
<ListView x:Name="MyList">
  <ListView.ContextFlyout>
    <MenuFlyout>
      <MenuFlyoutItem Text="Share" Icon="Share"/>
      <MenuFlyoutItem Text="Copy" Icon="Copy">
        <MenuFlyoutItem.KeyboardAccelerators>
          <KeyboardAccelerator 
            Modifiers="Control" 
            Key="C" 
            ScopeOwner="{x:Bind MyList }" />
        </MenuFlyoutItem.KeyboardAccelerators>
      </MenuFlyoutItem>
      
      <MenuFlyoutItem Text="Delete" Icon="Delete" />
      <MenuFlyoutSeparator />
      
      <MenuFlyoutItem Text="Rename">
        <MenuFlyoutItem.KeyboardAccelerators>
          <KeyboardAccelerator 
            Modifiers="None" 
            Key="F2" 
            ScopeOwner="{x:Bind MyList}" />
        </MenuFlyoutItem.KeyboardAccelerators>
      </MenuFlyoutItem>
      
      <MenuFlyoutItem Text="Select" />
    </MenuFlyout>
    
  </ListView.ContextFlyout>
    
  <ListViewItem>Track 1</ListViewItem>
  <ListViewItem>Alternative Track 1</ListViewItem>

</ListView>
```

MenuFlyoutItem.KeyboardAccelerators 要素の ScopeOwner 属性は、アクセラレータがグローバルではなくスコープ指定されていることを示します (既定値はグローバルを示す null)。 詳しくは、このトピックの「**アクセラレータの解決**」をご覧ください。

## <a name="invoke-a-keyboard-accelerator"></a>キーボード アクセラレータを呼び出す 

[KeyboardAccelerator](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.keyboardaccelerator) オブジェクトは、[UI オートメーション (UIA) コントロール パターン](https://msdn.microsoft.com/library/windows/desktop/ee671194(v=vs.85).aspx)を使用して、アクセラレータが呼び出されたときにアクションを実行します。

UIA [コントロール パターン] では、一般的なコントロール機能が公開されます。 たとえば Button コントロールには、Click イベントをサポートするために [Invoke](https://msdn.microsoft.com/library/windows/desktop/ee671279(v=vs.85).aspx) コントロール パターンが実装されています (一般的に、コントロールはクリックまたはダブルクリックの操作のほか、Enter キー、定義済みのショートカット キー、または別の組み合わせのキー入力よって呼び出されます)。 キーボード アクセラレータでコントロールが呼び出されると、XAML フレームワークは、コントロールに Invoke コントロール パターンが実装されているかどうかを調べ、その場合は、コントロールをアクティブ化します (KeyboardAcceleratorInvoked イベントをリッスンする必要はありません)。

次の例では、ボタンに Invoke パターンが実装されているため、Ctrl + S によって Click イベントがトリガーされます。

``` xaml 
<Button Content="Save" Click="OnSave">
  <Button.KeyboardAccelerators>
    <KeyboardAccelerator Key="S" Modifiers="Control" />
  </Button.KeyboardAccelerators>
</Button>
```

要素に複数のコントロール パターンが実装されている場合、アクセラレータでアクティブ化できるのは 1 つだけです。 コントロール パターンの優先順位は次のとおりです。
1.  Invoke (Button)
2.  Toggle (Checkbox)
3.  Selection (ListView)
4.  Expand/Collapse (ComboBox) 

一致するコントロール パターンが見つからない場合は、アクセラレータが無効となり、デバッグ メッセージが発行されます ("このコンポーネントのオートメーション パターンが見つかりません。 Invoked イベントに目的の動作をすべて実装してください。 イベント ハンドラーで Handled を true に設定すると、このメッセージは表示されません")。

## <a name="custom-keyboard-accelerator-behavior"></a>カスタムのキーボード アクセラレータの動作

[KeyboardAccelerator](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.keyboardaccelerator) オブジェクトの Invoked イベントは、アクセラレータが実行されたときに発生します。 [KeyboardAcceleratorInvokedEventArgs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.keyboardacceleratorinvokedeventargs) イベント オブジェクトには、次のプロパティが含まれています。
- **Handled** (Boolean): これを true に設定すると、イベントによるコントロール パターンのトリガーが回避され、アクセラレータ イベントのバブルが停止されます。 既定値は false です。
- **Element** (DependencyObject): アクセラレータを含むオブジェクトです。

次のコードは、キーボード アクセラレータのコレクションを定義する方法と、Invoked イベントを処理する方法を示しています。

``` xaml
<ListView x:Name="MyListView">
  <ListView.KeyboardAccelerators>
    <KeyboardAccelerator Key="A" Modifiers="Control,Shift" Invoked="SelectAllInvoked" />
    <KeyboardAccelerator Key="F5" Invoked="RefreshInvoked"  />
  </ListView.KeyboardAccelerators>
</ListView>   
```

``` csharp
void SelectAllInvoked (KeyboardAccelerator sender, KeyboardAcceleratorInvokedEventArgs args)
{
  CustomSelectAll(MyListView);
  args.Handled = true;
}

void RefreshInvoked(KeyboardAccelerator sender, KeyboardAcceleratorInvokedEventArgs args)
{
  Refresh(MyListView);
  args.Handled = true;
}
```

## <a name="override-default-keyboard-behavior"></a>既定のキーボード動作を上書き

場合によっては、Backspace キーや Enter キーなどの特定のキーの既定の動作をオーバーライドする必要があります。 例: 

## <a name="disable-a-keyboard-accelerator"></a>キーボード アクセラレータを無効にする 

コントロールが無効になると、関連付けられたアクセラレータも無効になります。 次の例では、ListView の IsEnabled プロパティが false に設定されているため、関連付けられている Control+A アクセラレータを呼び出すことができません。

``` xaml
<ListView >
  <ListView.KeyboardAccelerators>
    <KeyboardAccelerator Key="A" 
      Modifiers="Control"
      Invoked="CustomListViewSelecAllInvoked" />
  </ListView.KeyboardAccelerators>
  
  <TextBox>
    <TextBox.KeyboardAccelerators>
      <KeyboardAccelerator 
        Key="A" 
        Modifiers="Control" 
        Invoked="CustomTextSelecAllInvoked" 
        IsEnabled="False" />
    </TextBox.KeyboardAccelerators>
  </TextBox>

<ListView>
```

親と子のコントロールは、同じアクセラレータを共有できます。 この場合は、子にフォーカスがあってアクセス キーが無効になっている場合でも、親のコントロールを呼び出すことができます。

## <a name="screen-readers-and-keyboard-accelerators"></a>スクリーン リーダーとキーボード アクセラレータ 

ナレーターなどのスクリーン リーダーでは、キーボード アクセラレータを構成するキーの組み合わせをユーザーに読み上げることができます。 既定では、各修飾キー (VirtualModifiers 列挙の順) の後にキーが ("+" 記号で区切って) 組み合わされています。 これは、AutomationProperties の [AcceleratorKey](https://docs.microsoft.com/uwp/api/windows.ui.xaml.automation.automationproperties.AcceleratorKeyProperty) 添付プロパティを通じてカスタマイズできます。 複数のアクセラレータが指定されている場合は、最初のものだけが通知されます。

この例では、AutomationProperty.AcceleratorKey は "Control+Shift+A" という文字列を返します。

``` xaml
<ListView x:Name="MyListView">
  <ListView.KeyboardAccelerators>

    <KeyboardAccelerator 
      Key="A" 
      Modifiers="Control,Shift" 
      Invoked="CustomSelectAllInvoked" />
      
    <KeyboardAccelerator 
      Key="F5" 
      Modifiers="None" 
      Invoked="RefreshInvoked" />

  </ListView.KeyboardAccelerators>

</ListView>   
```

> [!NOTE] 
> AutomationProperties.AcceleratorKey を設定しても、キーボード機能が有効になるのではなく、使用するキーが UIA フレームワークに通知されるだけです。

## <a name="common-keyboard-accelerators"></a>一般的なキーボード アクセラレータ

キーボード アクセラレータは、どの UWP アプリケーションでも統一することをお勧めします。 ユーザーは、キーボード アクセラレータを記憶する必要があり、同じ (または同様の) 結果を期待します。

このことは、アプリによる機能の相違のため実現できないこともあります。

| **編集** | **一般的なキーボード アクセラレータ** |
| ------------- | ----------------------------------- |
| 編集モードを開始する | Ctrl + E |
| フォーカスのあるコントロール内またはウィンドウ内のすべての項目を選択する | Ctrl + A |
| 検索して置換 | Ctrl + H |
| 元に戻す | Ctrl + Z |
| やり直す | Ctrl + Y |
| 選択範囲を削除してクリップボードにコピーする | Ctrl + X |
| 選択範囲をクリップボードにコピーする | Ctrl + C、Ctrl + Ins |
| クリップボードの内容を貼り付ける | Ctrl + V、Shift + Ins |
| クリップボードの内容を貼り付ける (オプションあり) | Ctrl + Alt + V |
| 項目の名前を変更する | F2 |
| 新しい項目を追加する | Ctrl + N |
| 新しいセカンダリ項目を追加する | Ctrl + Shift + N |
| 選択した項目を削除する (元に戻すオプションあり) | Del、Ctrl+D |
| 選択した項目を削除する (元に戻すオプションなし) | Shift + Del |
| 太字 | Ctrl + B |
| 下線 | Ctrl + U |
| 斜体 | Ctrl + I |

| **ナビゲーション** | |
| ------------- | ----------------------------------- |
| フォーカスのあるコントロールまたはウィンドウでコンテンツを見つける | Ctrl + F |
| 次の検索結果に移動する | F3 |

| **その他の操作** | |
| ------------- | ----------------------------------- |
| お気に入りに追加する | Ctrl + D | 
| 最新の情報に更新する | F5 または Ctrl + R | 
| 拡大 | Ctrl + + | 
| 縮小 | Ctrl + - | 
| 既定の表示倍率に拡大縮小 | Ctrl + 0 | 
| 上書き保存 | Ctrl + S | 
| 閉じる | Ctrl + W | 
| 印刷 | Ctrl + P | 

ローカライズされたバージョンの Windows では使用できない組み合わせもあります。 たとえば、スペイン語バージョンの Windows では、太字の指定には Ctrl + B ではなく Ctrl + N が使用されます。 アプリがローカライズされている場合は、ローカライズされたキーボード アクセラレータを用意することをお勧めします。

## <a name="usability-affordances-for-keyboard-accelerators"></a>キーボード アクセラレータのユーザビリティ アフォーダンス

### <a name="tooltips"></a>ヒント

通常、キーボード アクセラレータは UWP アプリケーションの UI で直接説明されるものではありません。ユーザーがフォーカスをコントロールに移動したり、コントロールを長押ししたり、マウス ポインターをコントロール上にホバーしたりするときに自動的に表示される、[ヒント](../controls-and-patterns/tooltips.md)を使用すると、キーボード アクセラレータが見つけやすくなります。 ヒントによって、コントロールにキーボード アクセラレータが関連付けられているかどうかを識別でき、関連付けられている場合は、アクセラレータ キーの組み合わせを識別することができます。

**Windows 10、バージョン 1803 (April 2018 Update) 以降**

既定では、キーボード アクセラレータが宣言されている場合、( [MenuFlyoutItem](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.MenuFlyoutItem)と[ToggleMenuFlyoutItem](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.togglemenuflyoutitem)) を除くすべてのコントロールを表示、対応するキーの組み合わせヒントに表示します。

> [!NOTE] 
> コントロールには、複数のアクセラレータが定義されている場合、最初のものだけが表示されます。

![アクセラレータ キーのヒント](images/accelerators/accelerators_tooltip_savebutton_small.png)

*ヒントでのアクセラレータ キーの組み合わせ*

[ボタン](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.button)、 [AppBarButton](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.appbarbutton)と[AppBarToggleButton](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.appbartogglebutton)オブジェクトは、キーボード アクセラレータは、コントロールの既定のヒントに追加されます。 [MenuFlyoutItem](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.appbarbutton)と[ToggleMenuFlyoutItem](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.togglemenuflyoutitem)) オブジェクト、キーボード アクセラレータがポップアップ テキストで表示されます。

> [!NOTE]
> ヒントを指定する (次の例で Button1 を参照) は、この動作を上書きします。

```xaml
<StackPanel x:Name="Container" Grid.Row="0" Background="AliceBlue">
    <Button Content="Button1" Margin="20"
            Click="OnSave" 
            KeyboardAcceleratorPlacementMode="Auto" 
            ToolTipService.ToolTip="Tooltip">
        <Button.KeyboardAccelerators>
            <KeyboardAccelerator  Key="A" Modifiers="Windows"/>
        </Button.KeyboardAccelerators>
    </Button>
    <Button Content="Button2"  Margin="20"
            Click="OnSave" 
            KeyboardAcceleratorPlacementMode="Auto">
        <Button.KeyboardAccelerators>
            <KeyboardAccelerator  Key="B" Modifiers="Windows"/>
        </Button.KeyboardAccelerators>
    </Button>
    <Button Content="Button3"  Margin="20"
            Click="OnSave" 
            KeyboardAcceleratorPlacementMode="Auto">
        <Button.KeyboardAccelerators>
            <KeyboardAccelerator  Key="C" Modifiers="Windows"/>
        </Button.KeyboardAccelerators>
    </Button>
</StackPanel>
```

![アクセラレータ キーのヒント](images/accelerators/accelerators-button-small.png)

*ボタンの既定のヒントに追加されたアクセラレータ キーの組み合わせ*

```xaml
<AppBarButton Icon="Save" Label="Save">
    <AppBarButton.KeyboardAccelerators>
        <KeyboardAccelerator Key="S" Modifiers="Control"/>
    </AppBarButton.KeyboardAccelerators>
</AppBarButton>
```

![アクセラレータ キーのヒント](images/accelerators/accelerators-appbarbutton-small.png)

*AppBarButton の既定のヒントに追加されたアクセラレータ キーの組み合わせ*

```xaml
<AppBarButton AccessKey="R" Icon="Refresh" Label="Refresh" IsAccessKeyScope="True">
    <AppBarButton.Flyout>
        <MenuFlyout>
            <MenuFlyoutItem AccessKey="A" Icon="Refresh" Text="Refresh A">
                <MenuFlyoutItem.KeyboardAccelerators>
                    <KeyboardAccelerator Key="R" Modifiers="Control"/>
                </MenuFlyoutItem.KeyboardAccelerators>
            </MenuFlyoutItem>
            <MenuFlyoutItem AccessKey="B" Icon="Globe" Text="Refresh B" />
            <MenuFlyoutItem AccessKey="C" Icon="Globe" Text="Refresh C" />
            <MenuFlyoutItem AccessKey="D" Icon="Globe" Text="Refresh D" />
            <ToggleMenuFlyoutItem AccessKey="E" Icon="Globe" Text="ToggleMe">
                <MenuFlyoutItem.KeyboardAccelerators>
                    <KeyboardAccelerator Key="Q" Modifiers="Control"/>
                </MenuFlyoutItem.KeyboardAccelerators>
            </ToggleMenuFlyoutItem>
        </MenuFlyout>
    </AppBarButton.Flyout>
</AppBarButton>
```

![アクセラレータ キーのヒント](images/accelerators/accelerators-appbar-menuflyoutitem-small.png)

*MenuFlyoutItem のテキストに追加されたアクセラレータ キーの組み合わせ*

表示の動作を制御するには、[KeyboardAcceleratorPlacementMode](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.KeyboardAcceleratorPlacementMode) プロパティを使用します。このプロパティは 2 つの値、[Auto](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.keyboardacceleratorplacementmode) または [Hidden](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.keyboardacceleratorplacementmode) を受け入れます。    

```xaml
<Button Content="Save" Click="OnSave" KeyboardAcceleratorPlacementMode="Auto">
    <Button.KeyboardAccelerators>
        <KeyboardAccelerator Key="S" Modifiers="Control" />
    </Button.KeyboardAccelerators>
</Button>
```

場合によっては、他の要素 (通常はコンテナー オブジェクト) に関連するヒントを表示する必要があります。 たとえば、ピボット ヘッダー共に PivotItem のヒントを表示するピボット コントロールがあります。 

ここでは、KeyboardAcceleratorPlacementTarget プロパティを使用して、[保存] ボタンのキーボード アクセラレータを構成するキーの組み合わを表示する方法について説明します。この例では、ボタンではなく Grid コンテナーを使用します。

```xaml
<Grid x:Name="Container" Padding="30">
  <Button Content="Save"
    Click="OnSave"
    KeyboardAcceleratorPlacementMode="Auto"
    KeyboardAcceleratorPlacementTarget="{x:Bind Container}">
    <Button.KeyboardAccelerators>
      <KeyboardAccelerator  Key="S" Modifiers="Control" />
    </Button.KeyboardAccelerators>
  </Button>
</Grid>
```

### <a name="labels"></a>ラベル

場合によっては、コントロールのラベルを使用して、コントロールにキーボード アクセラレータが関連付けられているかどうかを識別し、関連付けられている場合は、アクセラレータ キーの組み合わせを識別することをお勧めします。 

一部のプラットフォームのコントロールでは、既定でこの識別が行われます。具体的には、[MenuFlyoutItem](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.MenuFlyoutItem) オブジェクトと [ToggleMenuFlyoutItem](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.togglemenuflyoutitem) オブジェクトで実行されます。これに対して、[AppBarButton](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.appbarbutton) と [AppBarToggleButton](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.appbartogglebutton) は、[CommandBar](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.commandbar) のオーバーフロー メニューにこれらが表示されたときに、この識別が行われます。

![メニュー項目ラベルに示されているキーボード アクセラレータ](images/accelerators/accelerators_menuitemlabel.png)  
*メニュー項目ラベルに示されているキーボード アクセラレータ*

[MenuFlyoutItem](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.MenuFlyoutItem)、[ToggleMenuFlyoutItem](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.togglemenuflyoutitem)、[AppBarButton](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.appbarbutton)、[AppBarToggleButton](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.appbartogglebutton) の各コントロールの [KeyboardAcceleratorTextOverride](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.appbarbutton.KeyboardAcceleratorTextOverride) プロパティを使用して、ラベルの既定のアクセラレータ テキストを上書きすることができます。 

> [!NOTE] 
> 上書きしたテキストは、取り付けられているキーボードをシステムが検出できない場合は表示されません (取り付けられているキーボードの検出は、[KeyboardPresent](https://docs.microsoft.com/uwp/api/windows.devices.input.keyboardcapabilities.KeyboardPresent) プロパティを使用して、ご自分で確認することができます)。

## <a name="advanced-concepts"></a>高度な概念

ここでは、キーボード アクセラレータの基本的な特徴をいくつか確認します。

### <a name="when-an-accelerator-is-invoked"></a>アクセラレータの呼び出し

アクセラレータは、2 種類のキー (修飾キーと非修飾キー) で構成されます。 修飾キーには、Shift キー、メニュー キー、Ctrl キー、Windows キーがあり、[VirtualKeyModifiers](http://msdn.microsoft.com/library/windows/apps/xaml/Windows.System.VirtualKeyModifiers) で公開されます。 非修飾子キーは、Del キー、F3 キー、Space キー、Esc キーなどのすべての仮想キーと、すべての英数字キー、記号キーです。 キーボード アクセラレータは、ユーザーが 1 つまたは複数の修飾キーを押しながら非修飾キーを押したときに呼び出されます。 たとえば、ユーザーが Ctrl + Shift + M を押す場合、M キーが押されたときに、フレームワークは修飾キー (Ctrl キーと Shift キー) を確認し、存在する場合はアクセラレータを起動します。

> [!NOTE]
> 仕様では、アクセラレータは自動的に反復されます (たとえば、ユーザーが Ctrl + Shift を押しながら M キーを押した場合は、M キーが解放されるまで、アクセラレータが繰り返し呼び出されます)。 この動作は変更できません。

### <a name="input-event-priority"></a>入力イベントの優先順位
入力イベントは特定の順序で発生します。これをインターセプトし、アプリの要件に基づいて処理することができます。 

#### <a name="the-keydownkeyup-bubbling-event"></a>KeyDown/KeyUp バブル イベント 

XAML では、入力バブル パイプラインが 1 つだけであるかのようにキー入力が処理されます。 この入力パイプラインは KeyDown/KeyUp イベントや文字入力によって使用されます。 たとえば、要素にフォーカスがある場合にユーザーがキーを押すと、その要素で KeyDown イベントが発生します。これに続き、要素の親、さらにその親と、args.Handled プロパティが true になるまでツリー上層方向にイベントの発生が続きます。

KeyDown イベントは、一部のコントロールで組み込みのコントロール アクセラレータを実装するためにも使用されます。 コントロールにキーボード アクセラレータが設定されている場合は、KeyDown イベントが処理されます。つまり、KeyDown イベント バブルは発生しません。 たとえば、RichEditBox は、Ctrl + C によるコピー操作をサポートします。 Ctrl が押されると KeyDown イベントおよびバブルが発生しますが、ユーザーが同時に C キーを押した場合、KeyDown イベントが Handled となり発生しません ([UIElement.AddHandler](http://msdn.microsoft.com/library/windows/apps/xaml/Windows.UI.Xaml.UIElement.AddHandler) の handledEventsToo パラメーターが true に設定されている場合は例外)。

#### <a name="the-characterreceived-event"></a>CharacterReceived イベント

TextBox などのテキスト コントロールに対する [KeyDown](https://docs.microsoft.com/uwp/api/windows.ui.core.corewindow.KeyDown) イベントの後で [CharacterReceived](https://docs.microsoft.com/uwp/api/windows.ui.core.corewindow.CharacterReceived) イベントが発生した場合は、KeyDown イベント ハンドラーで文字入力を取り消すことができます。

#### <a name="the-previewkeydown-and-previewkeyup-events"></a>PreviewKeyDown イベントと PreviewKeyUp イベント

プレビュー入力イベントは、他のイベントの前に発生します。 これらのイベントを処理しない場合は、フォーカスのある要素のアクセラレータが呼び出され、これに続いて KeyDown イベントが発生します。 処理されるまで、両方のイベントのバブルが発生します。


![キー イベントのシーケンス](images/accelerators/accelerators_keyevents.png)
***キー イベントのシーケンス***

イベントの順序:

PreviewKeyDown イベント …
アプリ アクセラレータ、OnKeyDown メソッド、KeyDown イベント、親に対するアプリ アクセラレータ、親に対する OnKeyDown メソッド、親に対する KeyDown イベント (ルートまでバブル) …
CharacterReceived イベント、PreviewKeyUp イベント、KeyUp イベント

アクセラレータ イベントが処理されると、KeyDown イベントも処理済みとしてマークされます。 KeyUp イベントは、未処理のままとなります。

### <a name="resolving-accelerators"></a>アクセラレータの解決

フォーカスのある要素からルートまで、キーボード アクセラレータ イベントのバブルが発生します。 イベントが処理されない場合、XAML フレームワークはバブル パスの外で、スコープ外の他のアプリ アクセラレータを探します。

2 つのキーボード アクセラレータが同じキーの組み合わせで定義されている場合は、ビジュアル ツリーで最初に見つかったキーボード アクセラレータが呼び出されます。

スコープ指定されたキーボード アクセラレータは、フォーカスが特定のスコープ内にある場合にのみ呼び出されます。 たとえば、多数のコントロールが含まれる Grid では、Grid (スコープ所有者) 内にフォーカスがある場合にのみ、コントロールに対してキーボード アクセラレータを呼び出すことができます。

### <a name="scoping-accelerators-programmatically"></a>アクセラレータのスコープをプログラムで指定する

[UIElement.TryInvokeKeyboardAccelerator](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.uielement.tryinvokekeyboardaccelerator) メソッドは、要素のサブツリー内で一致するアクセラレータを呼び出します。

[UIElement.OnProcessKeyboardAccelerators](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.uielement.onprocesskeyboardaccelerators) メソッドは、キーボード アクセラレータの前に実行されます。 このメソッドは、キー、修飾子、およびブール値 (キーボード アクセラレータが処理済みかどうかを示す) が含まれた [ProcessKeyboardAcceleratorArgs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.processkeyboardacceleratoreventargs) オブジェクトを渡します。 処理済みとしてマークされると、キーボード アクセラレータでバブルが発生します (外部のキーボード アクセラレータが呼び出されることはありません)。

> [!NOTE]
> 処理済みかどうかに関係なく、OnProcessKeyboardAccelerators は常に発生します (OnKeyDown イベントに似ています)。 イベントが処理済みとしてマークされたかどうかを確認する必要があります。

この例では、OnProcessKeyboardAccelerators と TryInvokeKeyboardAccelerator を使用して、キーボード アクセラレータのスコープを Page オブジェクトに設定します。

``` csharp
protected override void OnProcessKeyboardAccelerators(
  ProcessKeyboardAcceleratorArgs args)
{
  if(args.Handled != true)
  {
    this.TryInvokeKeyboardAccelerator(args);
    args.Handled = true;
  }
}
```

### <a name="localize-the-accelerators"></a>アクセラレータのローカライズ

キーボード アクセラレータは、すべてローカライズすることをお勧めします。 これを行うには、標準的な UWP リソース (.resw) ファイルと XAML 宣言の x:Uid 属性を使用します。 この例では、Windows ランタイムによってリソースが自動的に読み込まれます。

![UWP リソース ファイルの使用によるキーボード アクセラレータのローカライズ](images/accelerators/accelerators_localization.png)
***UWP リソース ファイルの使用によるキーボード アクセラレータのローカライズ***

``` xaml
<Button x:Uid="myButton" Click="OnSave">
  <Button.KeyboardAccelerators>
    <KeyboardAccelerator x:Uid="myKeyAccelerator" Modifiers="Control"/>
  </Button.KeyboardAccelerators>
</Button>
```

### <a name="setup-an-accelerator-programmatically"></a>アクセラレータをプログラムでセットアップする

アクセラレータをプログラムで定義する例を次に示します。

``` csharp
void AddAccelerator(
  VirtualKeyModifiers keyModifiers, 
  VirtualKey key, 
  TypedEventHandler<KeyboardAccelerator, KeyboardAcceleratorInvokedEventArgs> handler )
  {
    var accelerator = 
      new KeyboardAccelerator() 
      { 
        Modifiers = keyModifiers, Key = key
      };
    accelerator.Invoked = handler;
    this.KeyAccelerators.Add(accelerator);
  }
```

> [!NOTE]
> KeyboardAccelerator は共有できません。同じ KeyboardAccelerator を複数の要素に追加することはできません。

### <a name="override-keyboard-accelerator-behavior"></a>キーボード アクセラレータの動作を上書きする

[KeyboardAccelerator.Invoked](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.keyboardaccelerator.Invoked) イベントを処理して、KeyboardAccelerator の既定の動作を上書きできます。

次の例は、カスタムの ListView コントロールで "すべて選択" コマンド (キーボード アクセラレータは Ctrl + A) を上書きする方法を示しています。 また、Handled プロパティを true に設定して、以降のイベント バブルを停止します。

```csharp
public class MyListView : ListView
{
  …
  protected override void OnKeyboardAcceleratorInvoked(KeyboardAcceleratorInvokedEventArgs args) 
  {
    if(args.Accelerator.Key == VirtualKey.A 
      && args.Accelerator.Modifiers == KeyboardModifiers.Control)
    {
      CustomSelectAll(TypeOfSelection.OnlyNumbers); 
      args.Handled = true;
    }
  }
  …
}
```

## <a name="related-articles"></a>関連記事

* [キーボード操作](keyboard-interactions.md)
* [アクセス キー](access-keys.md)

**サンプル**
* [XAML コントロール ギャラリー (別名 XamlUiBasics)](https://github.com/Microsoft/Windows-universal-samples/tree/c2aeaa588d9b134466bbd2cc387c8ff4018f151e/Samples/XamlUIBasics)


 

