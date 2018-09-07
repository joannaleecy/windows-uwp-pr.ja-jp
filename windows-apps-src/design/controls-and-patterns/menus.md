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
ms.sourcegitcommit: 00d27738325d6db5b5e481911ae7fac0711b05eb
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/07/2018
ms.locfileid: "3660073"
---
# <a name="menus-and-context-menus"></a><span data-ttu-id="35082-103">メニューとコンテキスト メニュー</span><span class="sxs-lookup"><span data-stu-id="35082-103">Menus and context menus</span></span>



<span data-ttu-id="35082-104">メニューとコンテキスト メニューは、ユーザーが要求するときにコマンドやオプションの一覧を表示します。</span><span class="sxs-lookup"><span data-stu-id="35082-104">Menus and context menus display a list of commands or options when the user requests them.</span></span>

> <span data-ttu-id="35082-105">**重要な API**: [MenuFlyout クラス](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.MenuFlyout)、[ContextFlyout プロパティ](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.contextflyout.aspx)、[FlyoutBase.AttachedFlyout プロパティ](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.flyoutbase.attachedflyout.aspx)</span><span class="sxs-lookup"><span data-stu-id="35082-105">**Important APIs**: [MenuFlyout class](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.MenuFlyout), [ContextFlyout property](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.contextflyout.aspx), [FlyoutBase.AttachedFlyout property](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.flyoutbase.attachedflyout.aspx)</span></span>

![一般的なコンテキスト メニューの例](images/contextmenu_rs2_icons.png)


## <a name="is-this-the-right-control"></a><span data-ttu-id="35082-107">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="35082-107">Is this the right control?</span></span>
<span data-ttu-id="35082-108">メニューとコンテキスト メニューは、コマンドを整理してユーザーに要求されるまで非表示にすることによって、スペースを節約します。</span><span class="sxs-lookup"><span data-stu-id="35082-108">Menus and context menus save space by organizing commands and hiding them until the user needs them.</span></span> <span data-ttu-id="35082-109">特定のコマンドを頻繁に使っていて、利用可能なスペースがある場合は、メニューを使って移動しなくてもよいように、メニュー内ではなく、独自の要素に直接配置することを検討してください。</span><span class="sxs-lookup"><span data-stu-id="35082-109">If a particular command will be used frequently and you have the space available, consider placing it directly in its own element, rather than in a menu, so that users don't have to go through a menu to get to it.</span></span>

<span data-ttu-id="35082-110">メニューとコンテキスト メニューは、コマンドを整理する目的で使います。通知などの任意のコンテンツを表示する場合や、確認を要求する場合は、[ダイアログまたはポップアップ](dialogs.md)を使います。</span><span class="sxs-lookup"><span data-stu-id="35082-110">Menus and context menus are for organizing commands; to display arbitrary content, such as an notification or to request confirmation, use a [dialog or a flyout](dialogs.md).</span></span>  

## <a name="examples"></a><span data-ttu-id="35082-111">例</span><span class="sxs-lookup"><span data-stu-id="35082-111">Examples</span></span>

<table>
<th align="left"><span data-ttu-id="35082-112">XAML コントロール ギャラリー</span><span class="sxs-lookup"><span data-stu-id="35082-112">XAML Controls Gallery</span></span><th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><span data-ttu-id="35082-113"><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックして<a href="xamlcontrolsgallery:/item/MenuFlyout">アプリを開き、MenuFlyout の動作を確認</a>してください。</span><span class="sxs-lookup"><span data-stu-id="35082-113">If you have the <strong style="font-weight: semi-bold">XAML Controls Gallery</strong> app installed, click here to <a href="xamlcontrolsgallery:/item/MenuFlyout">open the app and see the MenuFlyout in action</a>.</span></span></p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT"><span data-ttu-id="35082-114">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</span><span class="sxs-lookup"><span data-stu-id="35082-114">Get the XAML Controls Gallery app (Microsoft Store)</span></span></a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics"><span data-ttu-id="35082-115">ソース コード (GitHub) を入手する</span><span class="sxs-lookup"><span data-stu-id="35082-115">Get the source code (GitHub)</span></span></a></li>
    </ul>
</td>
</tr>
</table>

## <a name="menus-vs-context-menus"></a><span data-ttu-id="35082-116">メニューとコンテキスト メニュー</span><span class="sxs-lookup"><span data-stu-id="35082-116">Menus vs. context menus</span></span>

<span data-ttu-id="35082-117">メニューとコンテキスト メニューは、外観や、何を含めることができるかという点で同一です。</span><span class="sxs-lookup"><span data-stu-id="35082-117">Menus and context menus are identical in how they look and what they can contain.</span></span> <span data-ttu-id="35082-118">実際、これらは [MenuFlyout](https://msdn.microsoft.com/library/windows/apps/dn299030) という同じコントロールを使って作成します。</span><span class="sxs-lookup"><span data-stu-id="35082-118">In fact, you use the same control, [MenuFlyout](https://msdn.microsoft.com/library/windows/apps/dn299030), to create them.</span></span> <span data-ttu-id="35082-119">唯一の違いは、ユーザーのアクセス方法です。</span><span class="sxs-lookup"><span data-stu-id="35082-119">The only difference is how you let the user access it.</span></span>

<span data-ttu-id="35082-120">メニューまたはコンテキスト メニューは、どのような場合に使えばよいでしょうか。</span><span class="sxs-lookup"><span data-stu-id="35082-120">When should you use a menu or a context menu?</span></span>
* <span data-ttu-id="35082-121">ホスト要素がボタンである場合や、追加のコマンドを表示することを主な役割とする他のコマンド要素である場合は、メニューを使います。</span><span class="sxs-lookup"><span data-stu-id="35082-121">If the host element is a button or some other command element who's primary role is to present additional commands, use a menu.</span></span>
* <span data-ttu-id="35082-122">ホスト要素が、別の主な役割 (テキストまたは画像を表示するなど) を持つ他の種類の要素である場合は、コンテキスト メニューを使います。</span><span class="sxs-lookup"><span data-stu-id="35082-122">If the host element is some other type of element that has another primary purpose (such as presenting text or an image), use a context menu.</span></span>

<span data-ttu-id="35082-123">たとえば、ナビゲーション ウィンドウのボタンでメニューを使って、追加のナビゲーション オプションを提供します。</span><span class="sxs-lookup"><span data-stu-id="35082-123">For example, use a menu on a button in a navigation pane to provide additional navigation options.</span></span> <span data-ttu-id="35082-124">このシナリオでは、ボタン コントロールの主な役割は、メニューへのアクセスを提供することです。</span><span class="sxs-lookup"><span data-stu-id="35082-124">In this scenario, the primary purpose of the button control is to provide access to a menu.</span></span>

![[メール] メニューの例](images/Mail_Menu.png)

<span data-ttu-id="35082-126">テキスト要素にコマンド (切り取り、コピー、貼り付けなど) を追加する場合は、メニューの代わりにコンテキスト メニューを使います。</span><span class="sxs-lookup"><span data-stu-id="35082-126">If you want to add commands (such as cut, copy, and paste) to a text element, use a context menu instead of a menu.</span></span> <span data-ttu-id="35082-127">このシナリオでは、テキスト要素の主な役割はテキストを表示して編集することであり、追加のコマンド (切り取り、コピー、貼り付けなど) は補助的な役割であるため、コンテキスト メニューに属します。</span><span class="sxs-lookup"><span data-stu-id="35082-127">In this scenario, the primary role of the text element is to present and edit text; additional commands (such as cut, copy, and paste) are secondary and belong in a context menu.</span></span>

![フォト ギャラリーでのコンテキスト メニューの例](images/ContextMenu_example.png) 

<div class="side-by-side">
<div class="side-by-side-content">
  <div class="side-by-side-content-left">
   <p><b><span data-ttu-id="35082-129">メニュー</span><span class="sxs-lookup"><span data-stu-id="35082-129">Menus</span></span></b></p>
<ul>
<li><span data-ttu-id="35082-130">常に表示される 1 つのエントリ ポイント (たとえば、画面上部の [ファイル] メニュー) があります。</span><span class="sxs-lookup"><span data-stu-id="35082-130">Have a single entry point (a File menu at the top of the screen, for example) that is always displayed.</span></span></li>
<li><span data-ttu-id="35082-131">通常、ボタンまたは親のメニュー項目にアタッチされます。</span><span class="sxs-lookup"><span data-stu-id="35082-131">Are usually attached to a button or a parent menu item.</span></span></li>
<li><span data-ttu-id="35082-132">左クリック (または、指でタップするなどの同等の操作) によって呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="35082-132">Are invoked by left-clicking (or an equivalent action, such as tapping with your finger).</span></span></li><li><span data-ttu-id="35082-133"><a href="https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.button.flyout.aspx">Flyout</a> プロパティまたは <a href="https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.flyoutbase.attachedflyout.aspx">FlyoutBase.AttachedFlyout</a> プロパティを介して要素に関連付けられます。</span><span class="sxs-lookup"><span data-stu-id="35082-133">Are associated with an element via its <a href="https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.button.flyout.aspx">Flyout</a> or <a href="https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.flyoutbase.attachedflyout.aspx">FlyoutBase.AttachedFlyout</a> properties.</span></span></li>
</ul>
</div>
  <div class="side-by-side-content-right">
   <p><b><span data-ttu-id="35082-134">コンテキスト メニュー</span><span class="sxs-lookup"><span data-stu-id="35082-134">Context menus</span></span></b></p>

<ul>
<li><span data-ttu-id="35082-135">1 つの要素にアタッチされ、セカンダリ コマンドを表示します。</span><span class="sxs-lookup"><span data-stu-id="35082-135">Are attached to a single element and display secondary commands.</span></span></li>
<li><span data-ttu-id="35082-136">右クリック (または、指で長押しするなどの同等の操作) によって呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="35082-136">Are invoked by right clicking (or an equivalent action, such as pressing and holding with your finger).</span></span></li><li><span data-ttu-id="35082-137"><a href="https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.contextflyout.aspx">ContextFlyout</a> プロパティを介して要素に関連付けられます。</span><span class="sxs-lookup"><span data-stu-id="35082-137">Are associated with an element via its <a href="https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.contextflyout.aspx">ContextFlyout</a> property.</span></span></li>
</ul>
  </div>
</div>
</div>

## <a name="icons"></a><span data-ttu-id="35082-138">アイコン</span><span class="sxs-lookup"><span data-stu-id="35082-138">Icons</span></span>

<span data-ttu-id="35082-139">次のようなメニュー項目のアイコンを用意することを検討します。</span><span class="sxs-lookup"><span data-stu-id="35082-139">Consider providing menu item icons for:</span></span>

<ul>
<li> <span data-ttu-id="35082-140">最もよく使われる項目</span><span class="sxs-lookup"><span data-stu-id="35082-140">The most commonly used items</span></span> </li>
<li> <span data-ttu-id="35082-141">アイコンが一般的またはよく知られているメニュー項目</span><span class="sxs-lookup"><span data-stu-id="35082-141">Menu items whose icon is standard or well known</span></span> </li>
<li> <span data-ttu-id="35082-142">アイコンがコマンドの役割を適切に示すメニュー項目</span><span class="sxs-lookup"><span data-stu-id="35082-142">Menu items whose icon well illustrates what the command does</span></span> </li>
</ul>

<span data-ttu-id="35082-143">標準的な視覚表現がないコマンドにアイコンを用意しなければならないと考える必要はありません。</span><span class="sxs-lookup"><span data-stu-id="35082-143">Don't feel obligated to provide icons for commands that don't have a standard visualization.</span></span> <span data-ttu-id="35082-144">わかりづらいアイコンは役に立たず、視覚的な混乱をもたらし、ユーザーが重要なメニュー項目に集中できなくなります。</span><span class="sxs-lookup"><span data-stu-id="35082-144">Cryptic icons aren’t helpful, create visual clutter, and prevent users from focusing on the important menu items.</span></span>

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
> <span data-ttu-id="35082-146">MenuFlyoutItems のアイコンのサイズは 16 x 16 ピクセルです。</span><span class="sxs-lookup"><span data-stu-id="35082-146">The size of the icons in MenuFlyoutItems is 16x16px.</span></span> <span data-ttu-id="35082-147">SymbolIcon、FontIcon、または PathIcon を使用した場合、忠実さを失うことなく、アイコンが適切なサイズに自動的に拡大縮小されます。</span><span class="sxs-lookup"><span data-stu-id="35082-147">If you use SymbolIcon, FontIcon, or PathIcon, the icon will automatically scale to the correct size with no loss of fidelity.</span></span> <span data-ttu-id="35082-148">BitmapIcon を使用すると、アセットは必ず 16 x 16 ピクセルになります。</span><span class="sxs-lookup"><span data-stu-id="35082-148">If you use BitmapIcon, ensure that your asset is 16x16px.</span></span>  

## <a name="create-a-menu-or-a-context-menu"></a><span data-ttu-id="35082-149">メニューまたはコンテキスト メニューの作成</span><span class="sxs-lookup"><span data-stu-id="35082-149">Create a menu or a context menu</span></span>

<span data-ttu-id="35082-150">メニューまたはコンテキスト メニューを作成するには、[MenuFlyout クラス](https://msdn.microsoft.com/library/windows/apps/dn299030) を使います。</span><span class="sxs-lookup"><span data-stu-id="35082-150">To create a menu or a context menu, you use the [MenuFlyout class](https://msdn.microsoft.com/library/windows/apps/dn299030).</span></span> <span data-ttu-id="35082-151">メニューのコンテンツは、[MenuFlyoutItem](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.menuflyoutitem.aspx) オブジェクト、[ToggleMenuFlyoutItem](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.togglemenuflyoutitem.aspx) オブジェクト、[MenuFlyoutSeparator](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.menuflyoutseparator.aspx) オブジェクトを MenuFlyout に追加することで定義します。</span><span class="sxs-lookup"><span data-stu-id="35082-151">You define the contents of the menu by adding [MenuFlyoutItem](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.menuflyoutitem.aspx), [ToggleMenuFlyoutItem](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.togglemenuflyoutitem.aspx), and [MenuFlyoutSeparator](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.menuflyoutseparator.aspx) objects to the MenuFlyout.</span></span> <span data-ttu-id="35082-152">これらのオブジェクトの用途を次に説明します。</span><span class="sxs-lookup"><span data-stu-id="35082-152">These objects are for:</span></span>
* <span data-ttu-id="35082-153">[MenuFlyoutItem](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.menuflyoutitem.aspx)—即座にアクションを実行します。</span><span class="sxs-lookup"><span data-stu-id="35082-153">[MenuFlyoutItem](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.menuflyoutitem.aspx)—Performing an immediate action.</span></span>
* <span data-ttu-id="35082-154">[ToggleMenuFlyoutItem](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.togglemenuflyoutitem.aspx)—オプションのオンとオフを切り替えます。</span><span class="sxs-lookup"><span data-stu-id="35082-154">[ToggleMenuFlyoutItem](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.togglemenuflyoutitem.aspx)—Switching an option on or off.</span></span>
* <span data-ttu-id="35082-155">[MenuFlyoutSeparator](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.menuflyoutseparator.aspx)—メニュー項目を視覚的に分割します。</span><span class="sxs-lookup"><span data-stu-id="35082-155">[MenuFlyoutSeparator](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.menuflyoutseparator.aspx)—Visually separating menu items.</span></span>


<span data-ttu-id="35082-156">この例では、[MenuFlyout クラス](https://msdn.microsoft.com/library/windows/apps/dn299030)を作成し、ほとんどのコントロールで利用できる [ContextFlyout](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.contextflyout.aspx) プロパティを使って、コンテキスト メニューとして [MenuFlyout クラス](https://msdn.microsoft.com/library/windows/apps/dn299030)を表示します。</span><span class="sxs-lookup"><span data-stu-id="35082-156">This example creates a [MenuFlyout class](https://msdn.microsoft.com/library/windows/apps/dn299030) and uses the [ContextFlyout](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.contextflyout.aspx) property, a property available to most controls, to show the [MenuFlyout class](https://msdn.microsoft.com/library/windows/apps/dn299030) as a context menu.</span></span>

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

<span data-ttu-id="35082-157">次の例はほとんど同じですが、[ContextFlyout](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.contextflyout.aspx) プロパティを使って、コンテキスト メニューとして [MenuFlyout クラス](https://msdn.microsoft.com/library/windows/apps/dn299030)を表示する代わりに、[FlyoutBase.ShowAttachedFlyout](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.flyoutbase.showattachedflyout) プロパティを使って、メニューとして MenuFlyout クラスを表示します。</span><span class="sxs-lookup"><span data-stu-id="35082-157">The next example is nearly identical, but instead of using the [ContextFlyout](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.contextflyout.aspx) property to show the [MenuFlyout class](https://msdn.microsoft.com/library/windows/apps/dn299030) as a context menu, the example uses the [FlyoutBase.ShowAttachedFlyout](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.flyoutbase.showattachedflyout) property to show it as a menu.</span></span>

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


> <span data-ttu-id="35082-158">簡易非表示コントロール (メニュー、コンテキスト メニュー、その他のポップアップ) は、閉じられるまで一時的な UI にキーボードのフォーカスやゲームパッドのフォーカスを捕捉します。</span><span class="sxs-lookup"><span data-stu-id="35082-158">Light dismiss controls, such as menus, context menus, and other flyouts, trap keyboard and gamepad focus inside the transient UI until dismissed.</span></span> <span data-ttu-id="35082-159">この動作に視覚的な合図を提供するために、Xbox の簡易非表示コントロールは、スコープ外の UI を暗く表示するオーバーレイを描画します。</span><span class="sxs-lookup"><span data-stu-id="35082-159">To provide a visual cue for this behavior, light dismiss controls on Xbox will draw an overlay that dims the visibility of out of scope UI.</span></span> <span data-ttu-id="35082-160">この動作は、[LightDismissOverlayMode](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.flyoutbase.lightdismissoverlaymode.aspx) プロパティを使って変更できます。</span><span class="sxs-lookup"><span data-stu-id="35082-160">This behavior can be modified with the  [LightDismissOverlayMode](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.flyoutbase.lightdismissoverlaymode.aspx) property.</span></span> <span data-ttu-id="35082-161">既定では、一時的な UI は Xbox で簡易非表示オーバーレイを描画し (**Auto**)、他のデバイス ファミリでは描画しませんが、アプリで強制的にオーバーレイを常にオン (**On**) にするか、常にオフ (**Off**) にするかを選択できます。</span><span class="sxs-lookup"><span data-stu-id="35082-161">By default, transient UIs will draw the light dismiss overlay on Xbox (**Auto**) but not other device families, but apps can choose to force the overlay to be always **On** or always **Off**.</span></span>

> ```xaml
> <MenuFlyout LightDismissOverlayMode="Off" />
> ```

## <a name="get-the-sample-code"></a><span data-ttu-id="35082-162">サンプル コードを入手する</span><span class="sxs-lookup"><span data-stu-id="35082-162">Get the sample code</span></span>

- <span data-ttu-id="35082-163">[XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - インタラクティブな形ですべての XAML コントロールを参照できます。</span><span class="sxs-lookup"><span data-stu-id="35082-163">[XAML Controls Gallery sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - See all the XAML controls in an interactive format.</span></span>
- [<span data-ttu-id="35082-164">XAML コンテキスト メニューのサンプル</span><span class="sxs-lookup"><span data-stu-id="35082-164">XAML Context menu sample</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlContextMenu)

## <a name="related-articles"></a><span data-ttu-id="35082-165">関連記事</span><span class="sxs-lookup"><span data-stu-id="35082-165">Related articles</span></span>

- [<span data-ttu-id="35082-166">MenuFlyout クラス</span><span class="sxs-lookup"><span data-stu-id="35082-166">MenuFlyout class</span></span>](https://msdn.microsoft.com/library/windows/apps/dn299030)
