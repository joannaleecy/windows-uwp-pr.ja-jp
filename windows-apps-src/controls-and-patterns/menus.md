---
author: mijacobs
Description: "ポップアップ (flyout) は、ユーザーが現在操作している内容に関係する UI を一時的に表示するために使われる軽量なポップアップです。"
title: "メニューとコンテキスト メニュー"
label: Menus and context menus
template: detail.hbs
ms.author: mijacobs
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.assetid: 0327d8c1-8329-4be2-84e3-66e1e9a0aa60
translationtype: Human Translation
ms.sourcegitcommit: 5645eee3dc2ef67b5263b08800b0f96eb8a0a7da
ms.openlocfilehash: 515c63d5612358cf90684427f8f747e19384c6ff
ms.lasthandoff: 02/08/2017

---
# <a name="menus-and-context-menus"></a>メニューとコンテキスト メニュー

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css"> 

メニューとコンテキスト メニューは、ユーザーが要求するときにコマンドやオプションの一覧を表示します。

![一般的なコンテキスト メニューの例](images/controls_contextmenu_singlepane.png)

<div class="important-apis" >
<b>重要な API</b><br/>
<ul>
<li>[MenuFlyout クラス](https://msdn.microsoft.com/library/windows/apps/dn299030)</li>
<li>[ContextFlyout プロパティ](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.contextflyout.aspx)</li>
<li>[FlyoutBase.AttachedFlyout プロパティ](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.primitives.flyoutbase.attachedflyout.aspx)</li>
</ul>
</div>


## <a name="is-this-the-right-control"></a>適切なコントロールの選択
メニューとコンテキスト メニューは、コマンドを整理してユーザーに要求されるまで非表示にすることによって、スペースを節約します。 特定のコマンドを頻繁に使っていて、利用可能なスペースがある場合は、メニューを使って移動しなくてもよいように、メニュー内ではなく、独自の要素に直接配置することを検討してください。 

メニューとコンテキスト メニューは、コマンドを整理する目的で使います。通知などの任意のコンテンツを表示する場合や、確認を要求する場合は、[ダイアログまたはポップアップ](dialogs.md)を使います。  


## <a name="menus-vs-context-menus"></a>メニューとコンテキスト メニュー

メニューとコンテキスト メニューは、外観や、何を含めることができるかという点で同一です。 実際、これらは [MenuFlyout](https://msdn.microsoft.com/library/windows/apps/dn299030) という同じコントロールを使って作成します。 唯一の違いは、ユーザーのアクセス方法です。 

メニューまたはコンテキスト メニューは、どのような場合に使えばよいでしょうか。
* ホスト要素がボタンである場合や、追加のコマンドを表示することを主な役割とする他のコマンド要素である場合は、メニューを使います。
* ホスト要素が、別の主な役割 (テキストまたは画像を表示するなど) を持つ他の種類の要素である場合は、コンテキスト メニューを使います。 

たとえば、ナビゲーション ウィンドウのボタンでメニューを使って、追加のナビゲーション オプションを提供します。 このシナリオでは、ボタン コントロールの主な役割は、メニューへのアクセスを提供することです。 

テキスト要素にコマンド (切り取り、コピー、貼り付けなど) を追加する場合は、メニューの代わりにコンテキスト メニューを使います。 このシナリオでは、テキスト要素の主な役割はテキストを表示して編集することであり、追加のコマンド (切り取り、コピー、貼り付けなど) は補助的な役割であるため、コンテキスト メニューに属します。 

<div class="side-by-side">
<div class="side-by-side-content">
  <div class="side-by-side-content-left">
   <p><b>メニュー</b></p>
<p>
<ul>
<li>常に表示される 1 つのエントリ ポイント (たとえば、画面上部の [ファイル] メニュー) があります。</li>
<li>通常、ボタンまたは親のメニュー項目にアタッチされます。</li>
<li>左クリック (または、指でタップするなどの同等の操作) によって呼び出されます。</li>  
<li>[Flyout](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.button.flyout.aspx) プロパティまたは [FlyoutBase.AttachedFlyout](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.primitives.flyoutbase.attachedflyout.aspx) プロパティを介して要素に関連付けられます。</li> 
</ul>
</p><br/>

  </div>
  <div class="side-by-side-content-right">
   <p><b>コンテキスト メニュー</b></p>
   
<ul>
<li>1 つの要素にアタッチされますが、コンテキストが意味をなす場合にのみアクセスできます。</li>
<li>右クリック (または、指で長押しするなどの同等の操作) によって呼び出されます。</li>
<li>[ContextFlyout](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.contextflyout.aspx) プロパティを介して要素に関連付けられます。  
</ul><br/>

  </div>
</div>
</div>

## <a name="create-a-menu-or-a-context-menu"></a>メニューまたはコンテキスト メニューの作成

メニューまたはコンテキスト メニューを作成するには、[MenuFlyout クラス](https://msdn.microsoft.com/library/windows/apps/dn299030) を使います。 メニューのコンテンツは、[MenuFlyoutItem](https://msdn.microsoft.com/en-us/library/windows/apps/xaml/windows.ui.xaml.controls.menuflyoutitem.aspx) オブジェクト、[ToggleMenuFlyoutItem](https://msdn.microsoft.com/en-us/library/windows/apps/xaml/windows.ui.xaml.controls.togglemenuflyoutitem.aspx) オブジェクト、[MenuFlyoutSeparator](https://msdn.microsoft.com/en-us/library/windows/apps/xaml/windows.ui.xaml.controls.menuflyoutseparator.aspx) オブジェクトを MenuFlyout に追加することで定義します。 これらのオブジェクトの用途を次に説明します。
* [MenuFlyoutItem](https://msdn.microsoft.com/en-us/library/windows/apps/xaml/windows.ui.xaml.controls.menuflyoutitem.aspx)—即座にアクションを実行します。
* [ToggleMenuFlyoutItem](https://msdn.microsoft.com/en-us/library/windows/apps/xaml/windows.ui.xaml.controls.togglemenuflyoutitem.aspx)—オプションのオンとオフを切り替えます。
* [MenuFlyoutSeparator](https://msdn.microsoft.com/en-us/library/windows/apps/xaml/windows.ui.xaml.controls.menuflyoutseparator.aspx)—メニュー項目を視覚的に分割します。


この例では、[MenuFlyout クラス](https://msdn.microsoft.com/library/windows/apps/dn299030)を作成し、ほとんどのコントロールで利用できる [ContextFlyout](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.contextflyout.aspx) プロパティを使って、コンテキスト メニューとして [MenuFlyout クラス](https://msdn.microsoft.com/library/windows/apps/dn299030)を表示します。

````xaml
<Rectangle 
  Height="100" Width="100" 
  Tapped="Rectangle_Tapped">
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

次の例はほとんど同じですが、[ContextFlyout](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.uielement.contextflyout.aspx) プロパティを使って、コンテキスト メニューとして [MenuFlyout クラス](https://msdn.microsoft.com/library/windows/apps/dn299030)を表示する代わりに、[FlyoutBase.ShowAttachedFlyout](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.primitives.flyoutbase.showattachedflyout) プロパティを使って、メニューとして MenuFlyout クラスを表示します。 

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


> 簡易非表示コントロール (メニュー、コンテキスト メニュー、その他のポップアップ) は、閉じられるまで一時的な UI にキーボードのフォーカスやゲームパッドのフォーカスを捕捉します。 この動作に視覚的な合図を提供するために、Xbox の簡易非表示コントロールは、スコープ外の UI を暗く表示するオーバーレイを描画します。 この動作は、新しい [LightDismissOverlayMode](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.primitives.flyoutbase.lightdismissoverlaymode.aspx) プロパティを使って変更できます。 既定では、一時的な UI は Xbox で簡易非表示オーバーレイを描画し、他のデバイス ファミリでは描画しませんが、アプリで強制的にオーバーレイを常に**オン**にするか、常に**オフ**にするかを選択できます。

> ```xaml
> <MenuFlyout LightDismissOverlayMode=\"Off\">
> ```

## <a name="get-the-sample-code"></a>サンプル コードを入手する
*   [XAML UI の基本のサンプル](https://github.com/Microsoft/Windows-universal-samples/blob/master/Samples/XamlUIBasics)<br/>
    インタラクティブな形で XAML コントロールのすべてを参照できます。

## <a name="related-articles"></a>関連記事

- [**MenuFlyout クラス**](https://msdn.microsoft.com/library/windows/apps/dn299030)

