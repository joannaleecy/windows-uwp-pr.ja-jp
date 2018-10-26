---
author: mijacobs
Description: Menus and context menus display a list of commands or options when the user requests them.
title: メニューとコンテキスト メニュー
label: Menus and context menus
template: detail.hbs
ms.author: mijacobs
ms.date: 10/02/2018
ms.topic: article
keywords: Windows 10, UWP
ms.assetid: 0327d8c1-8329-4be2-84e3-66e1e9a0aa60
pm-contact: yulikl
design-contact: kimsea
dev-contact: llongley
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 7a2b58ef505c4b6d045197dee525c5264a7dd518
ms.sourcegitcommit: 6cc275f2151f78db40c11ace381ee2d35f0155f9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5554497"
---
# <a name="menus-and-context-menus"></a>メニューとコンテキスト メニュー

メニューとコンテキスト メニューは、ユーザーが要求するときにコマンドやオプションの一覧を表示します。 1 つ、インライン メニューを表示するには、メニュー ポップアップを使用します。 通常は、アプリ ウィンドウの上部で、水平方向の行で一連のメニューを表示するのにには、メニュー バーを使用します。 各メニューには、メニュー項目とサブ メニューを持つことができます。

![一般的なコンテキスト メニューの例](images/contextmenu_rs2_icons.png)

| **Windows UI のライブラリを入手します。** |
| - |
| このコントロールは、Windows UI のライブラリ、新しいコントロールと UWP アプリの UI の機能が含まれている NuGet パッケージの一部として含まれています。 詳しくは、インストール手順を含む、 [Windows UI のライブラリの概要](https://docs.microsoft.com/uwp/toolkits/winui/)をご覧ください。 |

| **プラットフォーム Api** | **Windows UI ライブラリ Api** |
| - | - |
| [MenuFlyout クラス](/uwp/api/windows.ui.xaml.controls.menuflyout)、[メニュー バーのクラス](/uwp/api/windows.ui.xaml.controls.menubar)、 [ContextFlyout プロパティ](/uwp/api/windows.ui.xaml.uielement.contextflyout)で[FlyoutBase.AttachedFlyout プロパティ](/uwp/api/windows.ui.xaml.controls.primitives.flyoutbase.attachedflyout) | [メニュー バー クラス](/uwp/api/microsoft.ui.xaml.controls.menubar) |

## <a name="is-this-the-right-control"></a>適切なコントロールの選択

メニューとコンテキスト メニューは、コマンドを整理してユーザーに要求されるまで非表示にすることによって、スペースを節約します。 特定のコマンドを頻繁に使っていて、利用可能なスペースがある場合は、メニューを使って移動しなくてもよいように、メニュー内ではなく、独自の要素に直接配置することを検討してください。

メニューとコンテキスト メニューはコマンドを整理します。通知または確認要求などの任意のコンテンツを表示する、[ダイアログやポップアップ](dialogs.md)を使用します。

### <a name="menubar-vs-menuflyout"></a>メニュー バーと MenuFlyout

キャンバス上の UI 要素に接続されている、ポップアップで、メニューを表示するのにには、メニュー項目をホストするのに MenuFlyout コントロールを使用します。 標準のメニューまたはコンテキスト メニューとしてメニュー ポップアップを呼び出すことができます。 メニュー ポップアップは、1 つの最上位のメニュー (およびオプションのサブ メニュー) をホストします。

水平方向の行で複数の最上位のメニューのセットを表示するには、メニュー バーを使用します。 通常、アプリ ウィンドウの上部のメニュー バーに配置します。

### <a name="menubar-vs-commandbar"></a>メニュー バーとコマンド バー

メニュー バーや CommandBar 両方をユーザーにコマンドを公開するために使用できるサーフェスを表します。 メニュー バーでは、一連のコマンドについて詳しく組織や、コマンド バーよりもグループ化が必要のあるアプリを公開するためのクイックでシンプルな方法を提供します。

CommandBar と連携して、メニュー バーを使用することもできます。 メニュー バーを使用して、最も使用されているコマンドを強調表示するには、コマンド、および、CommandBar の大部分を提供します。

## <a name="examples"></a>例

<table>
<th align="left">XAML コントロール ギャラリー<th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックして<a href="xamlcontrolsgallery:/item/MenuFlyout">アプリを開き、MenuFlyout の動作を確認</a>してください。</p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics">ソース コード (GitHub) を入手する</a></li>
    </ul>
</td>
</tr>
</table>

## <a name="menus-vs-context-menus"></a>メニューとコンテキスト メニュー

メニューとコンテキスト メニューは、どのように表示されると、含めることができます似ています。 実際には、それらを作成するのに[MenuFlyout](https://msdn.microsoft.com/library/windows/apps/dn299030)、同じコントロールを使用することができます。 違いは、ユーザーのアクセスができるようにする方法です。

メニューまたはコンテキスト メニューは、どのような場合に使えばよいでしょうか。

- ホスト要素がボタンである場合や、追加のコマンドを表示することを主な役割とする他のコマンド要素である場合は、メニューを使います。
- ホスト要素が、別の主な役割 (テキストまたは画像を表示するなど) を持つ他の種類の要素である場合は、コンテキスト メニューを使います。

たとえば、フィルター処理と並べ替えの一覧については、オプションを提供するのに、ボタンでメニューを使用します。 このシナリオでは、ボタン コントロールの主な役割は、メニューへのアクセスを提供することです。

![[メール] メニューの例](images/Mail_Menu.png)

テキスト要素にコマンド (切り取り、コピー、貼り付けなど) を追加する場合は、メニューの代わりにコンテキスト メニューを使います。 このシナリオでは、テキスト要素の主な役割はテキストを表示して編集することであり、追加のコマンド (切り取り、コピー、貼り付けなど) は補助的な役割であるため、コンテキスト メニューに属します。

![フォト ギャラリーでのコンテキスト メニューの例](images/ContextMenu_example.png)

### <a name="menus"></a>メニュー

- 常に表示される 1 つのエントリ ポイント (たとえば、画面上部の [ファイル] メニュー) があります。
- 通常、ボタンまたは親のメニュー項目にアタッチされます。
- 左クリック (または、指でタップするなどの同等の操作) によって呼び出されます。
- その[ポップアップ](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.button.flyout.aspx)や[FlyoutBase.AttachedFlyout](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.flyoutbase.attachedflyout.aspx)プロパティを介して要素に関連付けられているか、アプリ ウィンドウの上部のメニュー バーでグループ化します。

### <a name="context-menus"></a>コンテキスト メニュー

- 1 つの要素にアタッチされ、セカンダリ コマンドを表示します。
- 右クリック (または、指で長押しするなどの同等の操作) によって呼び出されます。
- [ContextFlyout](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.contextflyout.aspx) プロパティを介して要素に関連付けられます。

## <a name="icons"></a>アイコン

次のようなメニュー項目のアイコンを用意することを検討します。

- 最もよく使われる項目。
- メニュー項目がアイコンが一般的またはよく知られています。
- アイコンが適切に示すコマンドのメニュー項目。

標準的な視覚表現がないコマンドにアイコンを用意しなければならないと考える必要はありません。 わかりづらいアイコンは役に立たず、視覚的な混乱をもたらし、ユーザーが重要なメニュー項目に集中できなくなります。

![アイコンのあるコンテキスト メニューの例](images/contextmenu_rs2_icons.png)

````xaml
<MenuFlyout>
  <MenuFlyoutItem Text="Share" >
    <MenuFlyoutItem.Icon>
      <FontIcon Glyph="&#xE72D;" />
    </MenuFlyoutItem.Icon>
  </MenuFlyoutItem>
  <MenuFlyoutItem Text="Copy" Icon="Copy" />
  <MenuFlyoutItem Text="Delete" Icon="Delete" />
  <MenuFlyoutSeparator />
  <MenuFlyoutItem Text="Rename" />
  <MenuFlyoutItem Text="Select" />
</MenuFlyout>
````

> [!TIP]
> MenuFlyoutItem のアイコンのサイズは、16 x 16 ピクセルです。 SymbolIcon、FontIcon、または PathIcon を使用する場合、アイコンを忠実度を損なうことがなく、適切なサイズに自動的にスケーリングします。 BitmapIcon を使用すると、アセットは必ず 16 x 16 ピクセルになります。  

## <a name="create-a-menu-flyout-or-a-context-menu"></a>メニュー ポップアップやコンテキスト メニューを作成します。

メニュー ポップアップやコンテキスト メニューを作成するには、 [MenuFlyout クラス](https://msdn.microsoft.com/library/windows/apps/dn299030)を使用します。 メニューのコンテンツは、[MenuFlyoutItem](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.menuflyoutitem.aspx) オブジェクト、[ToggleMenuFlyoutItem](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.togglemenuflyoutitem.aspx) オブジェクト、[MenuFlyoutSeparator](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.menuflyoutseparator.aspx) オブジェクトを MenuFlyout に追加することで定義します。

これらのオブジェクトの用途を次に説明します。

- [MenuFlyoutItem](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.menuflyoutitem.aspx)—即座にアクションを実行します。
- [ToggleMenuFlyoutItem](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.togglemenuflyoutitem.aspx)—オプションのオンとオフを切り替えます。
- [MenuFlyoutSeparator](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.menuflyoutseparator.aspx)—メニュー項目を視覚的に分割します。

この例では、 [MenuFlyout](https://msdn.microsoft.com/library/windows/apps/dn299030)を作成し、 [ContextFlyout](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.contextflyout.aspx)プロパティ、ほとんどのコントロールで利用可能なプロパティを使用して、コンテキスト メニューとして MenuFlyout を表示します。

````xaml
<Rectangle
  Height="100" Width="100">
  <Rectangle.ContextFlyout>
    <MenuFlyout>
      <MenuFlyoutItem Text="Change color" Click="ChangeColorItem_Click" />
    </MenuFlyout>
  </Rectangle.ContextFlyout>
  <Rectangle.Fill>
    <SolidColorBrush x:Name="rectangleFill" Color="Red" />
  </Rectangle.Fill>
</Rectangle>
````

````csharp
private void ChangeColorItem_Click(object sender, RoutedEventArgs e)
{
    // Change the color from red to blue or blue to red.
    if (rectangleFill.Color == Windows.UI.Colors.Red)
    {
        rectangleFill.Color = Windows.UI.Colors.Blue;
    }
    else
    {
        rectangleFill.Color = Windows.UI.Colors.Red;
    }
}
````

次の例はほとんど同じですが、[ContextFlyout](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.contextflyout.aspx) プロパティを使って、コンテキスト メニューとして [MenuFlyout クラス](https://msdn.microsoft.com/library/windows/apps/dn299030)を表示する代わりに、[FlyoutBase.ShowAttachedFlyout](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.flyoutbase.showattachedflyout) プロパティを使って、メニューとして MenuFlyout クラスを表示します。

````xaml
<Rectangle
  Height="100" Width="100"
  Tapped="Rectangle_Tapped">
  <FlyoutBase.AttachedFlyout>
    <MenuFlyout>
      <MenuFlyoutItem Text="Change color" Click="ChangeColorItem_Click" />
    </MenuFlyout>
  </FlyoutBase.AttachedFlyout>
  <Rectangle.Fill>
    <SolidColorBrush x:Name="rectangleFill" Color="Red" />
  </Rectangle.Fill>
</Rectangle>
````

````csharp
private void Rectangle_Tapped(object sender, TappedRoutedEventArgs e)
{
    FlyoutBase.ShowAttachedFlyout((FrameworkElement)sender);
}

private void ChangeColorItem_Click(object sender, RoutedEventArgs e)
{
    // Change the color from red to blue or blue to red.
    if (rectangleFill.Color == Windows.UI.Colors.Red)
    {
        rectangleFill.Color = Windows.UI.Colors.Blue;
    }
    else
    {
        rectangleFill.Color = Windows.UI.Colors.Red;
    }
}
````

### <a name="light-dismiss"></a>簡易非表示

簡易非表示コントロール (メニュー、コンテキスト メニュー、その他のポップアップ) は、閉じられるまで一時的な UI にキーボードのフォーカスやゲームパッドのフォーカスを捕捉します。 この動作に視覚的な合図を提供するために、Xbox の簡易非表示コントロールは、スコープ外の UI を暗く表示するオーバーレイを描画します。 この動作は、[LightDismissOverlayMode](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.flyoutbase.lightdismissoverlaymode.aspx) プロパティを使って変更できます。 既定では、一時的な UI は Xbox で簡易非表示オーバーレイを描画し (**Auto**)、他のデバイス ファミリでは描画しませんが、アプリで強制的にオーバーレイを常にオン (**On**) にするか、常にオフ (**Off**) にするかを選択できます。

```xaml
<MenuFlyout LightDismissOverlayMode="Off" />
```

## <a name="create-a-menu-bar"></a>メニュー バーを作成します。

> **プレビュー**: メニュー バー[最新の Windows 10 Insider Preview ビルドと SDK](https://insider.windows.com/for-developers/)または[Windows UI のライブラリ](https://docs.microsoft.com/uwp/toolkits/winui/)が必要です。

メニュー ポップアップと同様のメニュー バーでメニューを作成するのにには、同じ要素を使用します。 ただし、MenuFlyoutItem オブジェクトを MenuFlyout に、グループ化ではなくグループする MenuBarItem 要素。 各 MenuBarItem は、最上位メニューとして、メニュー バーに追加されます。

![メニュー バーの例](images/menu-bar-submenu.png)

> [!NOTE]
> この例は、UI の構造体を作成する方法を示していますが、コマンドのいずれかの実装は表示されません。

```xaml
<MenuBar>
    <MenuBarItem Title="File">
        <MenuFlyoutSubItem Text="New">
            <MenuFlyoutItem Text="Plain Text Document"/>
            <MenuFlyoutItem Text="Rich Text Document"/>
            <MenuFlyoutItem Text="Other Formats..."/>
        </MenuFlyoutSubItem>
        <MenuFlyoutItem Text="Open..."/>
        <MenuFlyoutItem Text="Save">
        <MenuFlyoutSeparator />
        <MenuFlyoutItem Text="Exit"/>
    </MenuBarItem>

    <MenuBarItem Title="Edit">
        <MenuFlyoutItem Text="Undo"/>
        <MenuFlyoutItem Text="Cut"/>
        <MenuFlyoutItem Text="Copy"/>
        <MenuFlyoutItem Text="Paste"/>
    </MenuBarItem>

    <MenuBarItem Title="Help">
        <MenuFlyoutItem Text="About"/>
    </MenuBarItem>
</MenuBar>
```

## <a name="get-the-sample-code"></a>サンプル コードを入手する

- [XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - インタラクティブな形ですべての XAML コントロールを参照できます。
- [XAML コンテキスト メニューのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlContextMenu)

## <a name="related-articles"></a>関連記事

- [MenuFlyout クラス](https://msdn.microsoft.com/library/windows/apps/dn299030)
- [メニュー バー クラス](/uwp/api/Windows.UI.Xaml.Controls.MenuBar)
