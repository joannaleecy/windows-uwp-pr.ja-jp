---
author: mijacobs
Description: Menus and context menus display a list of commands or options when the user requests them.
title: メニューとコンテキスト メニュー
label: Menus and context menus
template: detail.hbs
ms.author: mijacobs
ms.date: 10/02/2018
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
ms.openlocfilehash: 20b6f54f39be116ad77cb5a179ff8c3d188eb8c4
ms.sourcegitcommit: e6daa7ff878f2f0c7015aca9787e7f2730abcfbf
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/03/2018
ms.locfileid: "4311986"
---
# <a name="menus-and-context-menus"></a><span data-ttu-id="b4b47-103">メニューとコンテキスト メニュー</span><span class="sxs-lookup"><span data-stu-id="b4b47-103">Menus and context menus</span></span>

<span data-ttu-id="b4b47-104">メニューとコンテキスト メニューは、ユーザーが要求するときにコマンドやオプションの一覧を表示します。</span><span class="sxs-lookup"><span data-stu-id="b4b47-104">Menus and context menus display a list of commands or options when the user requests them.</span></span> <span data-ttu-id="b4b47-105">メニュー ポップアップを使用して、1 つ、インライン メニューを表示します。</span><span class="sxs-lookup"><span data-stu-id="b4b47-105">Use a menu flyout to show a single, inline menu.</span></span> <span data-ttu-id="b4b47-106">通常は、アプリ ウィンドウの上部で水平方向の行で一連のメニューを表示するのにには、メニュー バーを使用します。</span><span class="sxs-lookup"><span data-stu-id="b4b47-106">Use a menu bar to show a set of menus in a horizontal row, typically at the top of an app window.</span></span> <span data-ttu-id="b4b47-107">メニュー項目やサブメニュー各メニューことができます。</span><span class="sxs-lookup"><span data-stu-id="b4b47-107">Each menu can have menu items and sub-menus.</span></span>

![一般的なコンテキスト メニューの例](images/contextmenu_rs2_icons.png)

| **<span data-ttu-id="b4b47-109">Windows UI のライブラリを入手します。</span><span class="sxs-lookup"><span data-stu-id="b4b47-109">Get the Windows UI Library</span></span>** |
| - |
| <span data-ttu-id="b4b47-110">このコントロールは、Windows UI のライブラリ、新しいコントロールと UWP アプリの UI の機能が含まれている NuGet パッケージの一部として含まれています。</span><span class="sxs-lookup"><span data-stu-id="b4b47-110">This control is included as part of the Windows UI Library, a NuGet package that contains new controls and UI features for UWP apps.</span></span> <span data-ttu-id="b4b47-111">詳しくは、インストールの手順を含む、 [Windows UI のライブラリの概要](https://docs.microsoft.com/uwp/toolkits/winui/)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b4b47-111">For more info, including installation instructions, see the [Windows UI Library overview](https://docs.microsoft.com/uwp/toolkits/winui/).</span></span> |

| **<span data-ttu-id="b4b47-112">プラットフォーム Api</span><span class="sxs-lookup"><span data-stu-id="b4b47-112">Platform APIs</span></span>** | **<span data-ttu-id="b4b47-113">Windows UI ライブラリ Api</span><span class="sxs-lookup"><span data-stu-id="b4b47-113">Windows UI Library APIs</span></span>** |
| - | - |
| <span data-ttu-id="b4b47-114">[MenuFlyout クラス](/uwp/api/windows.ui.xaml.controls.menuflyout)、[メニュー バーのクラス](/uwp/api/windows.ui.xaml.controls.menubar)、 [ContextFlyout プロパティ](/uwp/api/windows.ui.xaml.uielement.contextflyout)、 [FlyoutBase.AttachedFlyout プロパティ](/uwp/api/windows.ui.xaml.controls.primitives.flyoutbase.attachedflyout)</span><span class="sxs-lookup"><span data-stu-id="b4b47-114">[MenuFlyout class](/uwp/api/windows.ui.xaml.controls.menuflyout), [MenuBar class](/uwp/api/windows.ui.xaml.controls.menubar), [ContextFlyout property](/uwp/api/windows.ui.xaml.uielement.contextflyout), [FlyoutBase.AttachedFlyout property](/uwp/api/windows.ui.xaml.controls.primitives.flyoutbase.attachedflyout)</span></span> | [<span data-ttu-id="b4b47-115">メニュー バー クラス</span><span class="sxs-lookup"><span data-stu-id="b4b47-115">MenuBar class</span></span>](/uwp/api/microsoft.ui.xaml.controls.menubar) |

## <a name="is-this-the-right-control"></a><span data-ttu-id="b4b47-116">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="b4b47-116">Is this the right control?</span></span>

<span data-ttu-id="b4b47-117">メニューとコンテキスト メニューは、コマンドを整理してユーザーに要求されるまで非表示にすることによって、スペースを節約します。</span><span class="sxs-lookup"><span data-stu-id="b4b47-117">Menus and context menus save space by organizing commands and hiding them until the user needs them.</span></span> <span data-ttu-id="b4b47-118">特定のコマンドを頻繁に使っていて、利用可能なスペースがある場合は、メニューを使って移動しなくてもよいように、メニュー内ではなく、独自の要素に直接配置することを検討してください。</span><span class="sxs-lookup"><span data-stu-id="b4b47-118">If a particular command will be used frequently and you have the space available, consider placing it directly in its own element, rather than in a menu, so that users don't have to go through a menu to get to it.</span></span>

<span data-ttu-id="b4b47-119">メニューとコンテキスト メニューはコマンドを整理します。確認または通知の要求などの任意のコンテンツを表示する、[ダイアログやポップアップ](dialogs.md)を使用します。</span><span class="sxs-lookup"><span data-stu-id="b4b47-119">Menus and context menus are for organizing commands; to display arbitrary content, such as a notification or confirmation request, use a [dialog or a flyout](dialogs.md).</span></span>

### <a name="menubar-vs-menuflyout"></a><span data-ttu-id="b4b47-120">メニュー バーと MenuFlyout</span><span class="sxs-lookup"><span data-stu-id="b4b47-120">MenuBar vs. MenuFlyout</span></span>

<span data-ttu-id="b4b47-121">キャンバスの UI 要素にアタッチ ポップアップで、メニューを表示するのにには、メニュー項目をホストするのに MenuFlyout コントロールを使用します。</span><span class="sxs-lookup"><span data-stu-id="b4b47-121">To show a menu in a flyout attached to an on-canvas UI element, use the MenuFlyout control to host your menu items.</span></span> <span data-ttu-id="b4b47-122">メニュー ポップアップは、定期的なメニューまたはコンテキスト メニューとして呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="b4b47-122">You can invoke a menu flyout either as a regular menu or as a context menu.</span></span> <span data-ttu-id="b4b47-123">メニュー ポップアップは、1 つの最上位のメニュー (およびオプションのサブ メニュー) をホストします。</span><span class="sxs-lookup"><span data-stu-id="b4b47-123">A menu flyout hosts a single top-level menu (and optional sub-menus).</span></span>

<span data-ttu-id="b4b47-124">複数の最上位のメニューのセットを水平方向の行を表示するには、メニュー バーを使用します。</span><span class="sxs-lookup"><span data-stu-id="b4b47-124">To show a set of multiple top-level menus in a horizontal row, use a menu bar.</span></span> <span data-ttu-id="b4b47-125">通常、アプリ ウィンドウの上部のメニュー バーに配置します。</span><span class="sxs-lookup"><span data-stu-id="b4b47-125">You typically position the menu bar at the top of the app window.</span></span>

### <a name="menubar-vs-commandbar"></a><span data-ttu-id="b4b47-126">メニュー バーとコマンド バー</span><span class="sxs-lookup"><span data-stu-id="b4b47-126">MenuBar vs. CommandBar</span></span>

<span data-ttu-id="b4b47-127">メニュー バーや CommandBar 両方をユーザーにコマンドを公開するために使用できるサーフェスを表します。</span><span class="sxs-lookup"><span data-stu-id="b4b47-127">MenuBar and CommandBar both represent surfaces that you can use to expose commands to your users.</span></span> <span data-ttu-id="b4b47-128">メニュー バーでは、CommandBar よりをグループ化または複数の組織が必要なアプリのコマンドのセットを公開するためのクイックでシンプルな方法を提供します。</span><span class="sxs-lookup"><span data-stu-id="b4b47-128">The MenuBar provides a quick and simple way to expose a set of commands for apps that might need more organization or grouping than a CommandBar allows.</span></span>

<span data-ttu-id="b4b47-129">メニュー バー CommandBar と組み合わせて使用することもできます。</span><span class="sxs-lookup"><span data-stu-id="b4b47-129">You can also use a MenuBar in conjunction with a CommandBar.</span></span> <span data-ttu-id="b4b47-130">メニュー バーを使用して、最も使用されているコマンドを強調表示するには、コマンドと CommandBar の大部分を提供します。</span><span class="sxs-lookup"><span data-stu-id="b4b47-130">Use the MenuBar to provide the bulk of the commands, and the CommandBar to highlight the most used commands.</span></span>

## <a name="examples"></a><span data-ttu-id="b4b47-131">例</span><span class="sxs-lookup"><span data-stu-id="b4b47-131">Examples</span></span>

<table>
<th align="left"><span data-ttu-id="b4b47-132">XAML コントロール ギャラリー</span><span class="sxs-lookup"><span data-stu-id="b4b47-132">XAML Controls Gallery</span></span><th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><span data-ttu-id="b4b47-133"><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックして<a href="xamlcontrolsgallery:/item/MenuFlyout">アプリを開き、MenuFlyout の動作を確認</a>してください。</span><span class="sxs-lookup"><span data-stu-id="b4b47-133">If you have the <strong style="font-weight: semi-bold">XAML Controls Gallery</strong> app installed, click here to <a href="xamlcontrolsgallery:/item/MenuFlyout">open the app and see the MenuFlyout in action</a>.</span></span></p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT"><span data-ttu-id="b4b47-134">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</span><span class="sxs-lookup"><span data-stu-id="b4b47-134">Get the XAML Controls Gallery app (Microsoft Store)</span></span></a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics"><span data-ttu-id="b4b47-135">ソース コード (GitHub) を入手する</span><span class="sxs-lookup"><span data-stu-id="b4b47-135">Get the source code (GitHub)</span></span></a></li>
    </ul>
</td>
</tr>
</table>

## <a name="menus-vs-context-menus"></a><span data-ttu-id="b4b47-136">メニューとコンテキスト メニュー</span><span class="sxs-lookup"><span data-stu-id="b4b47-136">Menus vs. context menus</span></span>

<span data-ttu-id="b4b47-137">メニューとコンテキスト メニューは、どのように表示されると、含めることができます似ています。</span><span class="sxs-lookup"><span data-stu-id="b4b47-137">Menus and context menus are similar in how they look and what they can contain.</span></span> <span data-ttu-id="b4b47-138">実際には、 [MenuFlyout](https://msdn.microsoft.com/library/windows/apps/dn299030)、同じコントロールを使用して、それらを作成することができます。</span><span class="sxs-lookup"><span data-stu-id="b4b47-138">In fact, you can use the same control, [MenuFlyout](https://msdn.microsoft.com/library/windows/apps/dn299030), to create them.</span></span> <span data-ttu-id="b4b47-139">違いは、ユーザーのアクセスができるようにする方法です。</span><span class="sxs-lookup"><span data-stu-id="b4b47-139">The difference is how you let the user access it.</span></span>

<span data-ttu-id="b4b47-140">メニューまたはコンテキスト メニューは、どのような場合に使えばよいでしょうか。</span><span class="sxs-lookup"><span data-stu-id="b4b47-140">When should you use a menu or a context menu?</span></span>

- <span data-ttu-id="b4b47-141">ホスト要素がボタンである場合や、追加のコマンドを表示することを主な役割とする他のコマンド要素である場合は、メニューを使います。</span><span class="sxs-lookup"><span data-stu-id="b4b47-141">If the host element is a button or some other command element who's primary role is to present additional commands, use a menu.</span></span>
- <span data-ttu-id="b4b47-142">ホスト要素が、別の主な役割 (テキストまたは画像を表示するなど) を持つ他の種類の要素である場合は、コンテキスト メニューを使います。</span><span class="sxs-lookup"><span data-stu-id="b4b47-142">If the host element is some other type of element that has another primary purpose (such as presenting text or an image), use a context menu.</span></span>

<span data-ttu-id="b4b47-143">たとえば、フィルター処理と並べ替えの一覧については、オプションを提供するのに、ボタンでメニューを使用します。</span><span class="sxs-lookup"><span data-stu-id="b4b47-143">For example, use a menu on a button to provide filtering and sorting options for a list.</span></span> <span data-ttu-id="b4b47-144">このシナリオでは、ボタン コントロールの主な役割は、メニューへのアクセスを提供することです。</span><span class="sxs-lookup"><span data-stu-id="b4b47-144">In this scenario, the primary purpose of the button control is to provide access to a menu.</span></span>

![[メール] メニューの例](images/Mail_Menu.png)

<span data-ttu-id="b4b47-146">テキスト要素にコマンド (切り取り、コピー、貼り付けなど) を追加する場合は、メニューの代わりにコンテキスト メニューを使います。</span><span class="sxs-lookup"><span data-stu-id="b4b47-146">If you want to add commands (such as cut, copy, and paste) to a text element, use a context menu instead of a menu.</span></span> <span data-ttu-id="b4b47-147">このシナリオでは、テキスト要素の主な役割はテキストを表示して編集することであり、追加のコマンド (切り取り、コピー、貼り付けなど) は補助的な役割であるため、コンテキスト メニューに属します。</span><span class="sxs-lookup"><span data-stu-id="b4b47-147">In this scenario, the primary role of the text element is to present and edit text; additional commands (such as cut, copy, and paste) are secondary and belong in a context menu.</span></span>

![フォト ギャラリーでのコンテキスト メニューの例](images/ContextMenu_example.png)

### <a name="menus"></a><span data-ttu-id="b4b47-149">メニュー</span><span class="sxs-lookup"><span data-stu-id="b4b47-149">Menus</span></span>

- <span data-ttu-id="b4b47-150">常に表示される 1 つのエントリ ポイント (たとえば、画面上部の [ファイル] メニュー) があります。</span><span class="sxs-lookup"><span data-stu-id="b4b47-150">Have a single entry point (a File menu at the top of the screen, for example) that is always displayed.</span></span>
- <span data-ttu-id="b4b47-151">通常、ボタンまたは親のメニュー項目にアタッチされます。</span><span class="sxs-lookup"><span data-stu-id="b4b47-151">Are usually attached to a button or a parent menu item.</span></span>
- <span data-ttu-id="b4b47-152">左クリック (または、指でタップするなどの同等の操作) によって呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="b4b47-152">Are invoked by left-clicking (or an equivalent action, such as tapping with your finger).</span></span>
- <span data-ttu-id="b4b47-153">その[ポップアップ](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.button.flyout.aspx)や[FlyoutBase.AttachedFlyout](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.flyoutbase.attachedflyout.aspx)プロパティを介して要素に関連付けられているか、アプリ ウィンドウの上部のメニュー バーでグループ化します。</span><span class="sxs-lookup"><span data-stu-id="b4b47-153">Are associated with an element via its [Flyout](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.button.flyout.aspx) or [FlyoutBase.AttachedFlyout](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.flyoutbase.attachedflyout.aspx) properties, or grouped in a menu bar at the top of the app window.</span></span>

### <a name="context-menus"></a><span data-ttu-id="b4b47-154">コンテキスト メニュー</span><span class="sxs-lookup"><span data-stu-id="b4b47-154">Context menus</span></span>

- <span data-ttu-id="b4b47-155">1 つの要素にアタッチされ、セカンダリ コマンドを表示します。</span><span class="sxs-lookup"><span data-stu-id="b4b47-155">Are attached to a single element and display secondary commands.</span></span>
- <span data-ttu-id="b4b47-156">右クリック (または、指で長押しするなどの同等の操作) によって呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="b4b47-156">Are invoked by right clicking (or an equivalent action, such as pressing and holding with your finger).</span></span>
- <span data-ttu-id="b4b47-157">[ContextFlyout](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.contextflyout.aspx) プロパティを介して要素に関連付けられます。</span><span class="sxs-lookup"><span data-stu-id="b4b47-157">Are associated with an element via its [ContextFlyout](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.contextflyout.aspx) property.</span></span>

## <a name="icons"></a><span data-ttu-id="b4b47-158">アイコン</span><span class="sxs-lookup"><span data-stu-id="b4b47-158">Icons</span></span>

<span data-ttu-id="b4b47-159">次のようなメニュー項目のアイコンを用意することを検討します。</span><span class="sxs-lookup"><span data-stu-id="b4b47-159">Consider providing menu item icons for:</span></span>

- <span data-ttu-id="b4b47-160">最もよく使われる項目。</span><span class="sxs-lookup"><span data-stu-id="b4b47-160">The most commonly used items.</span></span>
- <span data-ttu-id="b4b47-161">メニュー項目がアイコンが標準またはよく知られています。</span><span class="sxs-lookup"><span data-stu-id="b4b47-161">Menu items whose icon is standard or well known.</span></span>
- <span data-ttu-id="b4b47-162">アイコンが適切に示すコマンドのメニュー項目。</span><span class="sxs-lookup"><span data-stu-id="b4b47-162">Menu items whose icon well illustrates what the command does.</span></span>

<span data-ttu-id="b4b47-163">標準的な視覚表現がないコマンドにアイコンを用意しなければならないと考える必要はありません。</span><span class="sxs-lookup"><span data-stu-id="b4b47-163">Don't feel obligated to provide icons for commands that don't have a standard visualization.</span></span> <span data-ttu-id="b4b47-164">わかりづらいアイコンは役に立たず、視覚的な混乱をもたらし、ユーザーが重要なメニュー項目に集中できなくなります。</span><span class="sxs-lookup"><span data-stu-id="b4b47-164">Cryptic icons aren’t helpful, create visual clutter, and prevent users from focusing on the important menu items.</span></span>

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
> <span data-ttu-id="b4b47-166">MenuFlyoutItem のアイコンのサイズは、16 x 16 ピクセルです。</span><span class="sxs-lookup"><span data-stu-id="b4b47-166">The size of the icon in a MenuFlyoutItem is 16x16px.</span></span> <span data-ttu-id="b4b47-167">SymbolIcon、FontIcon、または PathIcon を使用する場合、アイコンを忠実度を損なうことがなく、適切なサイズに自動的にスケーリングします。</span><span class="sxs-lookup"><span data-stu-id="b4b47-167">If you use SymbolIcon, FontIcon, or PathIcon, the icon automatically scales to the correct size with no loss of fidelity.</span></span> <span data-ttu-id="b4b47-168">BitmapIcon を使用すると、アセットは必ず 16 x 16 ピクセルになります。</span><span class="sxs-lookup"><span data-stu-id="b4b47-168">If you use BitmapIcon, ensure that your asset is 16x16px.</span></span>  

## <a name="create-a-menu-flyout-or-a-context-menu"></a><span data-ttu-id="b4b47-169">メニュー ポップアップやコンテキスト メニューを作成します。</span><span class="sxs-lookup"><span data-stu-id="b4b47-169">Create a menu flyout or a context menu</span></span>

<span data-ttu-id="b4b47-170">メニュー ポップアップやコンテキスト メニューを作成するには、 [MenuFlyout クラス](https://msdn.microsoft.com/library/windows/apps/dn299030)を使用します。</span><span class="sxs-lookup"><span data-stu-id="b4b47-170">To create a menu flyout or a context menu, you use the [MenuFlyout class](https://msdn.microsoft.com/library/windows/apps/dn299030).</span></span> <span data-ttu-id="b4b47-171">メニューのコンテンツは、[MenuFlyoutItem](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.menuflyoutitem.aspx) オブジェクト、[ToggleMenuFlyoutItem](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.togglemenuflyoutitem.aspx) オブジェクト、[MenuFlyoutSeparator](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.menuflyoutseparator.aspx) オブジェクトを MenuFlyout に追加することで定義します。</span><span class="sxs-lookup"><span data-stu-id="b4b47-171">You define the contents of the menu by adding [MenuFlyoutItem](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.menuflyoutitem.aspx), [ToggleMenuFlyoutItem](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.togglemenuflyoutitem.aspx), and [MenuFlyoutSeparator](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.menuflyoutseparator.aspx) objects to the MenuFlyout.</span></span>

<span data-ttu-id="b4b47-172">これらのオブジェクトの用途を次に説明します。</span><span class="sxs-lookup"><span data-stu-id="b4b47-172">These objects are for:</span></span>

- <span data-ttu-id="b4b47-173">[MenuFlyoutItem](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.menuflyoutitem.aspx)—即座にアクションを実行します。</span><span class="sxs-lookup"><span data-stu-id="b4b47-173">[MenuFlyoutItem](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.menuflyoutitem.aspx)—Performing an immediate action.</span></span>
- <span data-ttu-id="b4b47-174">[ToggleMenuFlyoutItem](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.togglemenuflyoutitem.aspx)—オプションのオンとオフを切り替えます。</span><span class="sxs-lookup"><span data-stu-id="b4b47-174">[ToggleMenuFlyoutItem](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.togglemenuflyoutitem.aspx)—Switching an option on or off.</span></span>
- <span data-ttu-id="b4b47-175">[MenuFlyoutSeparator](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.menuflyoutseparator.aspx)—メニュー項目を視覚的に分割します。</span><span class="sxs-lookup"><span data-stu-id="b4b47-175">[MenuFlyoutSeparator](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.menuflyoutseparator.aspx)—Visually separating menu items.</span></span>

<span data-ttu-id="b4b47-176">この例では、 [MenuFlyout](https://msdn.microsoft.com/library/windows/apps/dn299030)を作成し、 [ContextFlyout](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.contextflyout.aspx)プロパティ、ほとんどのコントロールで利用可能なプロパティを使用して、コンテキスト メニューとして MenuFlyout を表示します。</span><span class="sxs-lookup"><span data-stu-id="b4b47-176">This example creates a [MenuFlyout](https://msdn.microsoft.com/library/windows/apps/dn299030) and uses the [ContextFlyout](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.contextflyout.aspx) property, a property available to most controls, to show the MenuFlyout as a context menu.</span></span>

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

<span data-ttu-id="b4b47-177">次の例はほとんど同じですが、[ContextFlyout](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.contextflyout.aspx) プロパティを使って、コンテキスト メニューとして [MenuFlyout クラス](https://msdn.microsoft.com/library/windows/apps/dn299030)を表示する代わりに、[FlyoutBase.ShowAttachedFlyout](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.flyoutbase.showattachedflyout) プロパティを使って、メニューとして MenuFlyout クラスを表示します。</span><span class="sxs-lookup"><span data-stu-id="b4b47-177">The next example is nearly identical, but instead of using the [ContextFlyout](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.contextflyout.aspx) property to show the [MenuFlyout class](https://msdn.microsoft.com/library/windows/apps/dn299030) as a context menu, the example uses the [FlyoutBase.ShowAttachedFlyout](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.flyoutbase.showattachedflyout) property to show it as a menu.</span></span>

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

### <a name="light-dismiss"></a><span data-ttu-id="b4b47-178">簡易非表示</span><span class="sxs-lookup"><span data-stu-id="b4b47-178">Light dismiss</span></span>

<span data-ttu-id="b4b47-179">簡易非表示コントロール (メニュー、コンテキスト メニュー、その他のポップアップ) は、閉じられるまで一時的な UI にキーボードのフォーカスやゲームパッドのフォーカスを捕捉します。</span><span class="sxs-lookup"><span data-stu-id="b4b47-179">Light dismiss controls, such as menus, context menus, and other flyouts, trap keyboard and gamepad focus inside the transient UI until dismissed.</span></span> <span data-ttu-id="b4b47-180">この動作に視覚的な合図を提供するために、Xbox の簡易非表示コントロールは、スコープ外の UI を暗く表示するオーバーレイを描画します。</span><span class="sxs-lookup"><span data-stu-id="b4b47-180">To provide a visual cue for this behavior, light dismiss controls on Xbox will draw an overlay that dims the visibility of out of scope UI.</span></span> <span data-ttu-id="b4b47-181">この動作は、[LightDismissOverlayMode](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.flyoutbase.lightdismissoverlaymode.aspx) プロパティを使って変更できます。</span><span class="sxs-lookup"><span data-stu-id="b4b47-181">This behavior can be modified with the  [LightDismissOverlayMode](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.flyoutbase.lightdismissoverlaymode.aspx) property.</span></span> <span data-ttu-id="b4b47-182">既定では、一時的な UI は Xbox で簡易非表示オーバーレイを描画し (**Auto**)、他のデバイス ファミリでは描画しませんが、アプリで強制的にオーバーレイを常にオン (**On**) にするか、常にオフ (**Off**) にするかを選択できます。</span><span class="sxs-lookup"><span data-stu-id="b4b47-182">By default, transient UIs will draw the light dismiss overlay on Xbox (**Auto**) but not other device families, but apps can choose to force the overlay to be always **On** or always **Off**.</span></span>

```xaml
<MenuFlyout LightDismissOverlayMode="Off" />
```

## <a name="create-a-menu-bar"></a><span data-ttu-id="b4b47-183">メニュー バーを作成します。</span><span class="sxs-lookup"><span data-stu-id="b4b47-183">Create a menu bar</span></span>

> <span data-ttu-id="b4b47-184">**プレビュー**: メニュー バー[最新の Windows 10 Insider Preview ビルドと SDK](https://insider.windows.com/for-developers/)または[Windows UI のライブラリ](https://docs.microsoft.com/uwp/toolkits/winui/)が必要です。</span><span class="sxs-lookup"><span data-stu-id="b4b47-184">**Preview**: MenuBar requires the [latest Windows 10 Insider Preview build and SDK](https://insider.windows.com/for-developers/) or the [Windows UI Library](https://docs.microsoft.com/uwp/toolkits/winui/).</span></span>

<span data-ttu-id="b4b47-185">メニュー ポップアップと同様のメニュー バーでメニューを作成するのにには、同じ要素を使用します。</span><span class="sxs-lookup"><span data-stu-id="b4b47-185">You use the same elements to create menus in a menu bar as in a menu flyout.</span></span> <span data-ttu-id="b4b47-186">ただし、MenuFlyoutItem オブジェクトを MenuFlyout をグループ化ではなくグループする MenuBarItem 要素。</span><span class="sxs-lookup"><span data-stu-id="b4b47-186">However, instead of grouping MenuFlyoutItem objects in a MenuFlyout, you group them in a MenuBarItem element.</span></span> <span data-ttu-id="b4b47-187">各 MenuBarItem は、最上位メニューとして、メニュー バーに追加されます。</span><span class="sxs-lookup"><span data-stu-id="b4b47-187">Each MenuBarItem is added to the MenuBar as a top level menu.</span></span>

![メニュー バーの例](images/menu-bar-submenu.png)

> [!NOTE]
> <span data-ttu-id="b4b47-189">この例では、UI の構造体を作成する方法を示していますが、コマンドのいずれかの実装は表示されません。</span><span class="sxs-lookup"><span data-stu-id="b4b47-189">This example shows only how to create the UI structure, but does not show implementation of any of the commands.</span></span>

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

## <a name="get-the-sample-code"></a><span data-ttu-id="b4b47-190">サンプル コードを入手する</span><span class="sxs-lookup"><span data-stu-id="b4b47-190">Get the sample code</span></span>

- <span data-ttu-id="b4b47-191">[XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - インタラクティブな形ですべての XAML コントロールを参照できます。</span><span class="sxs-lookup"><span data-stu-id="b4b47-191">[XAML Controls Gallery sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - See all the XAML controls in an interactive format.</span></span>
- [<span data-ttu-id="b4b47-192">XAML コンテキスト メニューのサンプル</span><span class="sxs-lookup"><span data-stu-id="b4b47-192">XAML Context menu sample</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlContextMenu)

## <a name="related-articles"></a><span data-ttu-id="b4b47-193">関連記事</span><span class="sxs-lookup"><span data-stu-id="b4b47-193">Related articles</span></span>

- [<span data-ttu-id="b4b47-194">MenuFlyout クラス</span><span class="sxs-lookup"><span data-stu-id="b4b47-194">MenuFlyout class</span></span>](https://msdn.microsoft.com/library/windows/apps/dn299030)
- [<span data-ttu-id="b4b47-195">メニュー バー クラス</span><span class="sxs-lookup"><span data-stu-id="b4b47-195">MenuBar class</span></span>](/uwp/api/Windows.UI.Xaml.Controls.MenuBar)
