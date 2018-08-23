---
author: mijacobs
Description: A flyout is a lightweight popup that is used to temporarily show UI that is related to what the user is currently doing.
title: メニューとコンテキスト メニュー
label: Menus and context menus
template: detail.hbs
ms.author: mijacobs
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.assetid: 0327d8c1-8329-4be2-84e3-66e1e9a0aa60
pm-contact: yulikl
design-contact: kimsea
dev-contact: llongley
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: e38e9d61e8546d412cc30bad26680243f3a188e4
ms.sourcegitcommit: 9c79fdab9039ff592edf7984732d300a14e81d92
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/23/2018
ms.locfileid: "2813574"
---
# <a name="menus-and-context-menus"></a>メニューとコンテキスト メニュー



メニューとコンテキスト メニューは、ユーザーが要求するときにコマンドやオプションの一覧を表示します。

> **重要な API**: [MenuFlyout クラス](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.MenuFlyout)、[ContextFlyout プロパティ](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.contextflyout.aspx)、[FlyoutBase.AttachedFlyout プロパティ](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.flyoutbase.attachedflyout.aspx)

![一般的なコンテキスト メニューの例](images/contextmenu_rs2_icons.png)


## <a name="is-this-the-right-control"></a>適切なコントロールの選択
メニューとコンテキスト メニューは、コマンドを整理してユーザーに要求されるまで非表示にすることによって、スペースを節約します。 特定のコマンドを頻繁に使っていて、利用可能なスペースがある場合は、メニューを使って移動しなくてもよいように、メニュー内ではなく、独自の要素に直接配置することを検討してください。

メニューとコンテキスト メニューは、コマンドを整理する目的で使います。通知などの任意のコンテンツを表示する場合や、確認を要求する場合は、[ダイアログまたはポップアップ](dialogs.md)を使います。  

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

メニューとコンテキスト メニューは、外観や、何を含めることができるかという点で同一です。 実際、これらは [MenuFlyout](https://msdn.microsoft.com/library/windows/apps/dn299030) という同じコントロールを使って作成します。 唯一の違いは、ユーザーのアクセス方法です。

メニューまたはコンテキスト メニューは、どのような場合に使えばよいでしょうか。
* ホスト要素がボタンである場合や、追加のコマンドを表示することを主な役割とする他のコマンド要素である場合は、メニューを使います。
* ホスト要素が、別の主な役割 (テキストまたは画像を表示するなど) を持つ他の種類の要素である場合は、コンテキスト メニューを使います。

たとえば、ナビゲーション ウィンドウのボタンでメニューを使って、追加のナビゲーション オプションを提供します。 このシナリオでは、ボタン コントロールの主な役割は、メニューへのアクセスを提供することです。

![[メール] メニューの例](images/Mail_Menu.png)

テキスト要素にコマンド (切り取り、コピー、貼り付けなど) を追加する場合は、メニューの代わりにコンテキスト メニューを使います。 このシナリオでは、テキスト要素の主な役割はテキストを表示して編集することであり、追加のコマンド (切り取り、コピー、貼り付けなど) は補助的な役割であるため、コンテキスト メニューに属します。

![フォト ギャラリーでのコンテキスト メニューの例](images/ContextMenu_example.png) 

<div class="side-by-side">
<div class="side-by-side-content">
  <div class="side-by-side-content-left">
   <p><b>メニュー</b></p>
<ul>
<li>常に表示される 1 つのエントリ ポイント (たとえば、画面上部の [ファイル] メニュー) があります。</li>
<li>通常、ボタンまたは親のメニュー項目にアタッチされます。</li>
<li>左クリック (または、指でタップするなどの同等の操作) によって呼び出されます。</li><li><a href="https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.button.flyout.aspx">Flyout</a> プロパティまたは <a href="https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.flyoutbase.attachedflyout.aspx">FlyoutBase.AttachedFlyout</a> プロパティを介して要素に関連付けられます。</li>
</ul>
</div>
  <div class="side-by-side-content-right">
   <p><b>コンテキスト メニュー</b></p>

<ul>
<li>1 つの要素にアタッチされ、セカンダリ コマンドを表示します。</li>
<li>右クリック (または、指で長押しするなどの同等の操作) によって呼び出されます。</li><li><a href="https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.contextflyout.aspx">ContextFlyout</a> プロパティを介して要素に関連付けられます。</li>
</ul>
  </div>
</div>
</div>

## <a name="icons"></a>アイコン

次のようなメニュー項目のアイコンを用意することを検討します。

<ul>
<li> 最もよく使われる項目 </li>
<li> アイコンが一般的またはよく知られているメニュー項目 </li>
<li> アイコンがコマンドの役割を適切に示すメニュー項目 </li>
</ul>

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
> MenuFlyoutItems のアイコンのサイズは 16 x 16 ピクセルです。 SymbolIcon、FontIcon、または PathIcon を使用した場合、忠実さを失うことなく、アイコンが適切なサイズに自動的に拡大縮小されます。 BitmapIcon を使用すると、アセットは必ず 16 x 16 ピクセルになります。  

## <a name="create-a-menu-or-a-context-menu"></a>メニューまたはコンテキスト メニューの作成

メニューまたはコンテキスト メニューを作成するには、[MenuFlyout クラス](https://msdn.microsoft.com/library/windows/apps/dn299030) を使います。 メニューのコンテンツは、[MenuFlyoutItem](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.menuflyoutitem.aspx) オブジェクト、[ToggleMenuFlyoutItem](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.togglemenuflyoutitem.aspx) オブジェクト、[MenuFlyoutSeparator](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.menuflyoutseparator.aspx) オブジェクトを MenuFlyout に追加することで定義します。 これらのオブジェクトの用途を次に説明します。
* [MenuFlyoutItem](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.menuflyoutitem.aspx)—即座にアクションを実行します。
* [ToggleMenuFlyoutItem](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.togglemenuflyoutitem.aspx)—オプションのオンとオフを切り替えます。
* [MenuFlyoutSeparator](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.menuflyoutseparator.aspx)—メニュー項目を視覚的に分割します。


この例では、[MenuFlyout クラス](https://msdn.microsoft.com/library/windows/apps/dn299030)を作成し、ほとんどのコントロールで利用できる [ContextFlyout](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.contextflyout.aspx) プロパティを使って、コンテキスト メニューとして [MenuFlyout クラス](https://msdn.microsoft.com/library/windows/apps/dn299030)を表示します。

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


> 簡易非表示コントロール (メニュー、コンテキスト メニュー、その他のポップアップ) は、閉じられるまで一時的な UI にキーボードのフォーカスやゲームパッドのフォーカスを捕捉します。 この動作に視覚的な合図を提供するために、Xbox の簡易非表示コントロールは、スコープ外の UI を暗く表示するオーバーレイを描画します。 この動作は、[LightDismissOverlayMode](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.flyoutbase.lightdismissoverlaymode.aspx) プロパティを使って変更できます。 既定では、一時的な UI は Xbox で簡易非表示オーバーレイを描画し (**Auto**)、他のデバイス ファミリでは描画しませんが、アプリで強制的にオーバーレイを常にオン (**On**) にするか、常にオフ (**Off**) にするかを選択できます。

> ```xaml
> <MenuFlyout LightDismissOverlayMode="Off" />
> ```

## <a name="get-the-sample-code"></a>サンプル コードを入手する

- [XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - インタラクティブな形ですべての XAML コントロールを参照できます。
- [XAML コンテキスト メニューのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlContextMenu)

## <a name="related-articles"></a>関連記事

- [MenuFlyout クラス](https://msdn.microsoft.com/library/windows/apps/dn299030)
