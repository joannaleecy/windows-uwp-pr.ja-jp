---
Description: メニューとコンテキスト メニューは、ユーザーが要求するときにコマンドやオプションの一覧を表示します。
title: メニューとショートカット メニュー
label: Menus and context menus
template: detail.hbs
ms.date: 01/08/2019
ms.topic: article
keywords: windows 10, uwp
ms.assetid: 0327d8c1-8329-4be2-84e3-66e1e9a0aa60
pm-contact: yulikl
design-contact: kimsea
dev-contact: llongley
doc-status: Published
ms.localizationpriority: medium
ms.custom: RS5
ms.openlocfilehash: d3ea8e2bff2455340a1183dbe5c1840fdb599d46
ms.sourcegitcommit: 7a1d5198345d114c58287d8a047eadc4fe10f012
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/08/2019
ms.locfileid: "59247190"
---
# <a name="menus-and-context-menus"></a>メニューとショートカット メニュー

メニューとコンテキスト メニューは、ユーザーが要求するときにコマンドやオプションの一覧を表示します。 1 つ、インライン メニューを表示するには、メニュー フライアウトを使用します。 メニュー バーを使用して、アプリのウィンドウの上部にある通常の水平方向の行でメニューのセットを示します。 各メニューには、メニュー項目とサブメニューを持つことができます。

![一般的なコンテキスト メニューの例](images/contextmenu_rs2_icons.png)

| **Windows UI ライブラリを入手する** |
| - |
| このコントロールは、Windows の UI ライブラリを新しいコントロール、および UWP アプリの UI 機能を含む NuGet パッケージの一部として含まれています。 インストール手順を含む詳細については、次を参照してください。、 [Windows UI ライブラリの概要](https://docs.microsoft.com/uwp/toolkits/winui/)します。 |

| **プラットフォームの Api** | **Windows UI ライブラリの Api** |
| - | - |
| [MenuFlyout クラス](/uwp/api/windows.ui.xaml.controls.menuflyout)、[メニュー バー クラス](/uwp/api/windows.ui.xaml.controls.menubar)、 [ContextFlyout プロパティ](/uwp/api/windows.ui.xaml.uielement.contextflyout)、 [FlyoutBase.AttachedFlyout プロパティ](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.flyoutbase.attachedflyout.aspx) | [メニュー バー クラス](/uwp/api/microsoft.ui.xaml.controls.menubar) |

## <a name="is-this-the-right-control"></a>適切なコントロールの選択

メニューとコンテキスト メニューは、コマンドを整理してユーザーに要求されるまで非表示にすることによって、スペースを節約します。 特定のコマンドを頻繁に使っていて、利用可能なスペースがある場合は、メニューを使って移動しなくてもよいように、メニュー内ではなく、独自の要素に直接配置することを検討してください。

メニューとコンテキスト メニューは、コマンドを整理するため、します。通知または確認の要求などの任意のコンテンツを表示するには使用、[ダイアログまたはポップアップ](dialogs.md)します。

### <a name="menubar-vs-menuflyout"></a>メニュー バーとします。MenuFlyout

キャンバス上の UI 要素にアタッチされたフライアウトでメニューを表示するのにには、メニュー項目をホストするのに MenuFlyout コントロールを使用します。 通常のメニューまたはコンテキスト メニューのメニュー フライアウトを呼び出すことができます。 メニュー ポップアップでは、単一の最上位メニュー (およびサブメニューの省略可能) をホストします。

水平方向の行では、一連の複数のトップレベル メニューを表示するには、メニュー バーを使用します。 通常、アプリ ウィンドウの上部にあるメニュー バーを配置します。

### <a name="menubar-vs-commandbar"></a>メニュー バーとします。CommandBar

メニュー バーとコマンド バー両方をユーザーにコマンドを公開するために使用できるサーフェスを表します。 メニュー バーでは、一連のコマンドが、多くの組織や、コマンド バーで許可をグループ化に必要なアプリを公開する簡単な方法を提供します。

コマンド バーを組み合わせて、メニュー バーを使用することもできます。 メニュー バーを使用すると、最も使用されているコマンドを強調表示するのにには、コマンドと、コマンド バーの大部分を提供します。

## <a name="examples"></a>例

<table>
<th align="left">XAML コントロール ギャラリー<th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックして<a href="xamlcontrolsgallery:/item/MenuFlyout">アプリを開き、MenuFlyout の動作を確認</a>してください。</p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</a></li>
    <li><a href="https://github.com/Microsoft/Xaml-Controls-Gallery">ソース コード (GitHub) を入手する</a></li>
    </ul>
</td>
</tr>
</table>

## <a name="menus-vs-context-menus"></a>メニューとコンテキスト メニュー

メニューおよびコンテキスト メニューは、どのように表示されると、含めることができるのと似ています。 実際には、同じコントロールを使用することができます[MenuFlyout](https://msdn.microsoft.com/library/windows/apps/dn299030)、それらを作成します。 違いは、ユーザーがアクセスできるようにする方法です。

メニューまたはコンテキスト メニューは、どのような場合に使えばよいでしょうか。

- ホスト要素が、ボタンなどの主な役割がその他のコマンドを表示するにはいくつかのコマンド要素の場合は、メニューを使用します。
- ホスト要素が、別の主な役割 (テキストまたは画像を表示するなど) を持つ他の種類の要素である場合は、コンテキスト メニューを使います。

たとえば、ボタンに、メニューを使用して、フィルター処理および並べ替えのオプションの一覧。 このシナリオでは、ボタン コントロールの主な役割は、メニューへのアクセスを提供することです。

![[メール] メニューの例](images/Mail_Menu.png)

テキスト要素にコマンド (切り取り、コピー、貼り付けなど) を追加する場合は、メニューの代わりにコンテキスト メニューを使います。 このシナリオでは、テキスト要素の主な役割はテキストを表示して編集することであり、追加のコマンド (切り取り、コピー、貼り付けなど) は補助的な役割であるため、コンテキスト メニューに属します。

![フォト ギャラリーでのコンテキスト メニューの例](images/ContextMenu_example.png)

### <a name="menus"></a>メニュー

- 常に表示される 1 つのエントリ ポイント (たとえば、画面上部の [ファイル] メニュー) があります。
- 通常、ボタンまたは親のメニュー項目にアタッチされます。
- 左クリック (または、指でタップするなどの同等の操作) によって呼び出されます。
- 使用して、要素に関連付けられたその[フライアウト](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.button.flyout.aspx)または[FlyoutBase.AttachedFlyout](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.flyoutbase.attachedflyout.aspx)プロパティ、または、アプリ ウィンドウの上部にあるメニュー バーでグループ化します。

### <a name="context-menus"></a>コンテキスト メニュー

- 1 つの要素にアタッチされ、セカンダリ コマンドを表示します。
- 右クリック (または、指で長押しするなどの同等の操作) によって呼び出されます。
- [ContextFlyout](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.contextflyout.aspx) プロパティを介して要素に関連付けられます。

## <a name="icons"></a>アイコン

次のようなメニュー項目のアイコンを用意することを検討します。

- 最もよく使用される項目。
- メニュー項目がアイコンを含む、標準またはよく知られています。
- メニュー項目がアイコンを含むが、コマンドが何を示しています。

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
> MenuFlyoutItem のアイコンのサイズは、16 x 16 ピクセルです。 SymbolIcon、FontIcon、または PathIcon を使用する場合、アイコンが忠実性の損失なしで適切なサイズに自動的にスケールされます。 BitmapIcon を使用すると、アセットは必ず 16 x 16 ピクセルになります。  

## <a name="create-a-menu-flyout-or-a-context-menu"></a>フライアウト メニューまたはコンテキスト メニューを作成します。

使用するメニュー フライアウトまたはコンテキスト メニューを作成する、 [MenuFlyout クラス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.menuflyout)します。 追加することで、メニューの内容を定義する[MenuFlyoutItem](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.menuflyoutitem)、 [MenuFlyoutSubItem](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.menuflyoutsubitem)、 [ToggleMenuFlyoutItem](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.togglemenuflyoutitem)、 [RadioMenuFlyoutItem](https://docs.microsoft.com/uwp/api/microsoft.ui.xaml.controls.radiomenuflyoutitem)と[MenuFlyoutSeparator](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.menuflyoutseparator) MenuFlyout するオブジェクト。

これらのオブジェクトの用途を次に説明します。

- [MenuFlyoutItem](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.menuflyoutitem)—即座にアクションを実行します。
- [MenuFlyoutSubItem](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.menuflyoutsubitem)— カスケード メニュー項目の一覧を格納しています。
- [ToggleMenuFlyoutItem](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.togglemenuflyoutitem)—オプションのオンとオフを切り替えます。
- [RadioMenuFlyoutItem](https://docs.microsoft.com/uwp/api/microsoft.ui.xaml.controls.radiomenuflyoutitem)相互に排他的なメニュー項目間の切り替え。
- [MenuFlyoutSeparator](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.menuflyoutseparator)—メニュー項目を視覚的に分割します。

この例で作成、 [MenuFlyout](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.menuflyout)を使用して、 [ContextFlyout](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.contextflyout.aspx)プロパティ、コンテキスト メニューとして MenuFlyout を表示する、ほとんどのコントロールに使用可能なプロパティ。

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

次の例はほとんど同じですが、[ContextFlyout](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.contextflyout.aspx) プロパティを使って、コンテキスト メニューとして [MenuFlyout クラス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.menuflyout)を表示する代わりに、[FlyoutBase.ShowAttachedFlyout](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.flyoutbase.showattachedflyout) プロパティを使って、メニューとして MenuFlyout クラスを表示します。

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

### <a name="light-dismiss"></a>ライトを閉じる

ライト メニューのコンテキスト メニューのおよびその他の動的メニューなどのコントロールを閉じる、閉じられるまでの一時的な UI 内でキーボード、ゲームパッドのフォーカスをトラップします。 この動作に視覚的な合図を提供するために、Xbox の簡易非表示コントロールは、スコープ外の UI を暗く表示するオーバーレイを描画します。 この動作は、[LightDismissOverlayMode](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.flyoutbase.lightdismissoverlaymode.aspx) プロパティを使って変更できます。 既定では、一時的な Ui は、Xbox でライト dismiss オーバーレイを描画する (**自動**) が、その他のデバイス ファミリではありません。 常にオーバーレイを強制することもできます**で**または always**オフ**します。

```xaml
<MenuFlyout LightDismissOverlayMode="Off" />
```

## <a name="create-a-menu-bar"></a>メニュー バーを作成します。

> [!IMPORTANT]
> メニュー バーには、Windows 10、バージョンは 1809 が必要です ([SDK 17763](https://developer.microsoft.com/windows/downloads/windows-10-sdk)) またはそれ以降、または[Windows UI ライブラリ](https://docs.microsoft.com/uwp/toolkits/winui/)します。

メニュー ポップアップのように、メニュー バーでメニューを作成するのにには、同じ要素を使用します。 ただしで、MenuFlyout MenuFlyoutItem オブジェクトをグループ化ではなくグループ化するそれら MenuBarItem 要素。 各 MenuBarItem は、トップ レベル メニューとしてのメニュー バーに追加されます。

![メニュー バーの例](images/menu-bar-submenu.png)

> [!NOTE]
> この例では、UI 構造を作成する方法のみを示していますが、コマンドのいずれかの実装は表示されません。

```xaml
<muxc:MenuBar>
    <muxc:MenuBarItem Title="File">
        <MenuFlyoutSubItem Text="New">
            <MenuFlyoutItem Text="Plain Text Document"/>
            <MenuFlyoutItem Text="Rich Text Document"/>
            <MenuFlyoutItem Text="Other Formats..."/>
        </MenuFlyoutSubItem>
        <MenuFlyoutItem Text="Open..."/>
        <MenuFlyoutItem Text="Save"/>
        <MenuFlyoutSeparator />
        <MenuFlyoutItem Text="Exit"/>
    </muxc:MenuBarItem>

    <muxc:MenuBarItem Title="Edit">
        <MenuFlyoutItem Text="Undo"/>
        <MenuFlyoutItem Text="Cut"/>
        <MenuFlyoutItem Text="Copy"/>
        <MenuFlyoutItem Text="Paste"/>
    </muxc:MenuBarItem>

    <muxc:MenuBarItem Title="View">
        <MenuFlyoutItem Text="Output"/>
        <MenuFlyoutSeparator/>
        <muxc:RadioMenuFlyoutItem Text="Landscape" GroupName="OrientationGroup"/>
        <muxc:RadioMenuFlyoutItem Text="Portrait" GroupName="OrientationGroup" IsChecked="True"/>
        <MenuFlyoutSeparator/>
        <muxc:RadioMenuFlyoutItem Text="Small icons" GroupName="SizeGroup"/>
        <muxc:RadioMenuFlyoutItem Text="Medium icons" IsChecked="True" GroupName="SizeGroup"/>
        <muxc:RadioMenuFlyoutItem Text="Large icons" GroupName="SizeGroup"/>
    </muxc:MenuBarItem>

    <muxc:MenuBarItem Title="Help">
        <MenuFlyoutItem Text="About"/>
    </muxc:MenuBarItem>
</muxc:MenuBar>
```

## <a name="get-the-sample-code"></a>サンプル コードを入手する

- [XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Xaml-Controls-Gallery) - インタラクティブな形で XAML コントロールのすべてを参照できます。
- [XAML コンテキスト メニューのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlContextMenu)

## <a name="related-articles"></a>関連記事

- [MenuFlyout クラス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.menuflyout)
- [メニュー バー クラス](https://docs.microsoft.com/uwp/api/microsoft.ui.xaml.controls.menubar)
