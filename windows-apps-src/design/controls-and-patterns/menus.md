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
# <a name="menus-and-context-menus"></a><span data-ttu-id="c9c46-104">メニューとショートカット メニュー</span><span class="sxs-lookup"><span data-stu-id="c9c46-104">Menus and context menus</span></span>

<span data-ttu-id="c9c46-105">メニューとコンテキスト メニューは、ユーザーが要求するときにコマンドやオプションの一覧を表示します。</span><span class="sxs-lookup"><span data-stu-id="c9c46-105">Menus and context menus display a list of commands or options when the user requests them.</span></span> <span data-ttu-id="c9c46-106">1 つ、インライン メニューを表示するには、メニュー フライアウトを使用します。</span><span class="sxs-lookup"><span data-stu-id="c9c46-106">Use a menu flyout to show a single, inline menu.</span></span> <span data-ttu-id="c9c46-107">メニュー バーを使用して、アプリのウィンドウの上部にある通常の水平方向の行でメニューのセットを示します。</span><span class="sxs-lookup"><span data-stu-id="c9c46-107">Use a menu bar to show a set of menus in a horizontal row, typically at the top of an app window.</span></span> <span data-ttu-id="c9c46-108">各メニューには、メニュー項目とサブメニューを持つことができます。</span><span class="sxs-lookup"><span data-stu-id="c9c46-108">Each menu can have menu items and sub-menus.</span></span>

![一般的なコンテキスト メニューの例](images/contextmenu_rs2_icons.png)

| **<span data-ttu-id="c9c46-110">Windows UI ライブラリを入手する</span><span class="sxs-lookup"><span data-stu-id="c9c46-110">Get the Windows UI Library</span></span>** |
| - |
| <span data-ttu-id="c9c46-111">このコントロールは、Windows の UI ライブラリを新しいコントロール、および UWP アプリの UI 機能を含む NuGet パッケージの一部として含まれています。</span><span class="sxs-lookup"><span data-stu-id="c9c46-111">This control is included as part of the Windows UI Library, a NuGet package that contains new controls and UI features for UWP apps.</span></span> <span data-ttu-id="c9c46-112">インストール手順を含む詳細については、次を参照してください。、 [Windows UI ライブラリの概要](https://docs.microsoft.com/uwp/toolkits/winui/)します。</span><span class="sxs-lookup"><span data-stu-id="c9c46-112">For more info, including installation instructions, see the [Windows UI Library overview](https://docs.microsoft.com/uwp/toolkits/winui/).</span></span> |

| **<span data-ttu-id="c9c46-113">プラットフォームの Api</span><span class="sxs-lookup"><span data-stu-id="c9c46-113">Platform APIs</span></span>** | **<span data-ttu-id="c9c46-114">Windows UI ライブラリの Api</span><span class="sxs-lookup"><span data-stu-id="c9c46-114">Windows UI Library APIs</span></span>** |
| - | - |
| <span data-ttu-id="c9c46-115">[MenuFlyout クラス](/uwp/api/windows.ui.xaml.controls.menuflyout)、[メニュー バー クラス](/uwp/api/windows.ui.xaml.controls.menubar)、 [ContextFlyout プロパティ](/uwp/api/windows.ui.xaml.uielement.contextflyout)、 [FlyoutBase.AttachedFlyout プロパティ](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.flyoutbase.attachedflyout.aspx)</span><span class="sxs-lookup"><span data-stu-id="c9c46-115">[MenuFlyout class](/uwp/api/windows.ui.xaml.controls.menuflyout), [MenuBar class](/uwp/api/windows.ui.xaml.controls.menubar), [ContextFlyout property](/uwp/api/windows.ui.xaml.uielement.contextflyout), [FlyoutBase.AttachedFlyout property](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.flyoutbase.attachedflyout.aspx)</span></span> | [<span data-ttu-id="c9c46-116">メニュー バー クラス</span><span class="sxs-lookup"><span data-stu-id="c9c46-116">MenuBar class</span></span>](/uwp/api/microsoft.ui.xaml.controls.menubar) |

## <a name="is-this-the-right-control"></a><span data-ttu-id="c9c46-117">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="c9c46-117">Is this the right control?</span></span>

<span data-ttu-id="c9c46-118">メニューとコンテキスト メニューは、コマンドを整理してユーザーに要求されるまで非表示にすることによって、スペースを節約します。</span><span class="sxs-lookup"><span data-stu-id="c9c46-118">Menus and context menus save space by organizing commands and hiding them until the user needs them.</span></span> <span data-ttu-id="c9c46-119">特定のコマンドを頻繁に使っていて、利用可能なスペースがある場合は、メニューを使って移動しなくてもよいように、メニュー内ではなく、独自の要素に直接配置することを検討してください。</span><span class="sxs-lookup"><span data-stu-id="c9c46-119">If a particular command will be used frequently and you have the space available, consider placing it directly in its own element, rather than in a menu, so that users don't have to go through a menu to get to it.</span></span>

<span data-ttu-id="c9c46-120">メニューとコンテキスト メニューは、コマンドを整理するため、します。通知または確認の要求などの任意のコンテンツを表示するには使用、[ダイアログまたはポップアップ](dialogs.md)します。</span><span class="sxs-lookup"><span data-stu-id="c9c46-120">Menus and context menus are for organizing commands; to display arbitrary content, such as a notification or confirmation request, use a [dialog or a flyout](dialogs.md).</span></span>

### <a name="menubar-vs-menuflyout"></a><span data-ttu-id="c9c46-121">メニュー バーとします。MenuFlyout</span><span class="sxs-lookup"><span data-stu-id="c9c46-121">MenuBar vs. MenuFlyout</span></span>

<span data-ttu-id="c9c46-122">キャンバス上の UI 要素にアタッチされたフライアウトでメニューを表示するのにには、メニュー項目をホストするのに MenuFlyout コントロールを使用します。</span><span class="sxs-lookup"><span data-stu-id="c9c46-122">To show a menu in a flyout attached to an on-canvas UI element, use the MenuFlyout control to host your menu items.</span></span> <span data-ttu-id="c9c46-123">通常のメニューまたはコンテキスト メニューのメニュー フライアウトを呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="c9c46-123">You can invoke a menu flyout either as a regular menu or as a context menu.</span></span> <span data-ttu-id="c9c46-124">メニュー ポップアップでは、単一の最上位メニュー (およびサブメニューの省略可能) をホストします。</span><span class="sxs-lookup"><span data-stu-id="c9c46-124">A menu flyout hosts a single top-level menu (and optional sub-menus).</span></span>

<span data-ttu-id="c9c46-125">水平方向の行では、一連の複数のトップレベル メニューを表示するには、メニュー バーを使用します。</span><span class="sxs-lookup"><span data-stu-id="c9c46-125">To show a set of multiple top-level menus in a horizontal row, use a menu bar.</span></span> <span data-ttu-id="c9c46-126">通常、アプリ ウィンドウの上部にあるメニュー バーを配置します。</span><span class="sxs-lookup"><span data-stu-id="c9c46-126">You typically position the menu bar at the top of the app window.</span></span>

### <a name="menubar-vs-commandbar"></a><span data-ttu-id="c9c46-127">メニュー バーとします。CommandBar</span><span class="sxs-lookup"><span data-stu-id="c9c46-127">MenuBar vs. CommandBar</span></span>

<span data-ttu-id="c9c46-128">メニュー バーとコマンド バー両方をユーザーにコマンドを公開するために使用できるサーフェスを表します。</span><span class="sxs-lookup"><span data-stu-id="c9c46-128">MenuBar and CommandBar both represent surfaces that you can use to expose commands to your users.</span></span> <span data-ttu-id="c9c46-129">メニュー バーでは、一連のコマンドが、多くの組織や、コマンド バーで許可をグループ化に必要なアプリを公開する簡単な方法を提供します。</span><span class="sxs-lookup"><span data-stu-id="c9c46-129">The MenuBar provides a quick and simple way to expose a set of commands for apps that might need more organization or grouping than a CommandBar allows.</span></span>

<span data-ttu-id="c9c46-130">コマンド バーを組み合わせて、メニュー バーを使用することもできます。</span><span class="sxs-lookup"><span data-stu-id="c9c46-130">You can also use a MenuBar in conjunction with a CommandBar.</span></span> <span data-ttu-id="c9c46-131">メニュー バーを使用すると、最も使用されているコマンドを強調表示するのにには、コマンドと、コマンド バーの大部分を提供します。</span><span class="sxs-lookup"><span data-stu-id="c9c46-131">Use the MenuBar to provide the bulk of the commands, and the CommandBar to highlight the most used commands.</span></span>

## <a name="examples"></a><span data-ttu-id="c9c46-132">例</span><span class="sxs-lookup"><span data-stu-id="c9c46-132">Examples</span></span>

<table>
<th align="left"><span data-ttu-id="c9c46-133">XAML コントロール ギャラリー</span><span class="sxs-lookup"><span data-stu-id="c9c46-133">XAML Controls Gallery</span></span><th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><span data-ttu-id="c9c46-134"><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックして<a href="xamlcontrolsgallery:/item/MenuFlyout">アプリを開き、MenuFlyout の動作を確認</a>してください。</span><span class="sxs-lookup"><span data-stu-id="c9c46-134">If you have the <strong style="font-weight: semi-bold">XAML Controls Gallery</strong> app installed, click here to <a href="xamlcontrolsgallery:/item/MenuFlyout">open the app and see the MenuFlyout in action</a>.</span></span></p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT"><span data-ttu-id="c9c46-135">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</span><span class="sxs-lookup"><span data-stu-id="c9c46-135">Get the XAML Controls Gallery app (Microsoft Store)</span></span></a></li>
    <li><a href="https://github.com/Microsoft/Xaml-Controls-Gallery"><span data-ttu-id="c9c46-136">ソース コード (GitHub) を入手する</span><span class="sxs-lookup"><span data-stu-id="c9c46-136">Get the source code (GitHub)</span></span></a></li>
    </ul>
</td>
</tr>
</table>

## <a name="menus-vs-context-menus"></a><span data-ttu-id="c9c46-137">メニューとコンテキスト メニュー</span><span class="sxs-lookup"><span data-stu-id="c9c46-137">Menus vs. context menus</span></span>

<span data-ttu-id="c9c46-138">メニューおよびコンテキスト メニューは、どのように表示されると、含めることができるのと似ています。</span><span class="sxs-lookup"><span data-stu-id="c9c46-138">Menus and context menus are similar in how they look and what they can contain.</span></span> <span data-ttu-id="c9c46-139">実際には、同じコントロールを使用することができます[MenuFlyout](https://msdn.microsoft.com/library/windows/apps/dn299030)、それらを作成します。</span><span class="sxs-lookup"><span data-stu-id="c9c46-139">In fact, you can use the same control, [MenuFlyout](https://msdn.microsoft.com/library/windows/apps/dn299030), to create them.</span></span> <span data-ttu-id="c9c46-140">違いは、ユーザーがアクセスできるようにする方法です。</span><span class="sxs-lookup"><span data-stu-id="c9c46-140">The difference is how you let the user access it.</span></span>

<span data-ttu-id="c9c46-141">メニューまたはコンテキスト メニューは、どのような場合に使えばよいでしょうか。</span><span class="sxs-lookup"><span data-stu-id="c9c46-141">When should you use a menu or a context menu?</span></span>

- <span data-ttu-id="c9c46-142">ホスト要素が、ボタンなどの主な役割がその他のコマンドを表示するにはいくつかのコマンド要素の場合は、メニューを使用します。</span><span class="sxs-lookup"><span data-stu-id="c9c46-142">If the host element is a button or some other command element whose primary role is to present additional commands, use a menu.</span></span>
- <span data-ttu-id="c9c46-143">ホスト要素が、別の主な役割 (テキストまたは画像を表示するなど) を持つ他の種類の要素である場合は、コンテキスト メニューを使います。</span><span class="sxs-lookup"><span data-stu-id="c9c46-143">If the host element is some other type of element that has another primary purpose (such as presenting text or an image), use a context menu.</span></span>

<span data-ttu-id="c9c46-144">たとえば、ボタンに、メニューを使用して、フィルター処理および並べ替えのオプションの一覧。</span><span class="sxs-lookup"><span data-stu-id="c9c46-144">For example, use a menu on a button to provide filtering and sorting options for a list.</span></span> <span data-ttu-id="c9c46-145">このシナリオでは、ボタン コントロールの主な役割は、メニューへのアクセスを提供することです。</span><span class="sxs-lookup"><span data-stu-id="c9c46-145">In this scenario, the primary purpose of the button control is to provide access to a menu.</span></span>

![[メール] メニューの例](images/Mail_Menu.png)

<span data-ttu-id="c9c46-147">テキスト要素にコマンド (切り取り、コピー、貼り付けなど) を追加する場合は、メニューの代わりにコンテキスト メニューを使います。</span><span class="sxs-lookup"><span data-stu-id="c9c46-147">If you want to add commands (such as cut, copy, and paste) to a text element, use a context menu instead of a menu.</span></span> <span data-ttu-id="c9c46-148">このシナリオでは、テキスト要素の主な役割はテキストを表示して編集することであり、追加のコマンド (切り取り、コピー、貼り付けなど) は補助的な役割であるため、コンテキスト メニューに属します。</span><span class="sxs-lookup"><span data-stu-id="c9c46-148">In this scenario, the primary role of the text element is to present and edit text; additional commands (such as cut, copy, and paste) are secondary and belong in a context menu.</span></span>

![フォト ギャラリーでのコンテキスト メニューの例](images/ContextMenu_example.png)

### <a name="menus"></a><span data-ttu-id="c9c46-150">メニュー</span><span class="sxs-lookup"><span data-stu-id="c9c46-150">Menus</span></span>

- <span data-ttu-id="c9c46-151">常に表示される 1 つのエントリ ポイント (たとえば、画面上部の [ファイル] メニュー) があります。</span><span class="sxs-lookup"><span data-stu-id="c9c46-151">Have a single entry point (a File menu at the top of the screen, for example) that is always displayed.</span></span>
- <span data-ttu-id="c9c46-152">通常、ボタンまたは親のメニュー項目にアタッチされます。</span><span class="sxs-lookup"><span data-stu-id="c9c46-152">Are usually attached to a button or a parent menu item.</span></span>
- <span data-ttu-id="c9c46-153">左クリック (または、指でタップするなどの同等の操作) によって呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="c9c46-153">Are invoked by left-clicking (or an equivalent action, such as tapping with your finger).</span></span>
- <span data-ttu-id="c9c46-154">使用して、要素に関連付けられたその[フライアウト](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.button.flyout.aspx)または[FlyoutBase.AttachedFlyout](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.flyoutbase.attachedflyout.aspx)プロパティ、または、アプリ ウィンドウの上部にあるメニュー バーでグループ化します。</span><span class="sxs-lookup"><span data-stu-id="c9c46-154">Are associated with an element via its [Flyout](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.button.flyout.aspx) or [FlyoutBase.AttachedFlyout](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.flyoutbase.attachedflyout.aspx) properties, or grouped in a menu bar at the top of the app window.</span></span>

### <a name="context-menus"></a><span data-ttu-id="c9c46-155">コンテキスト メニュー</span><span class="sxs-lookup"><span data-stu-id="c9c46-155">Context menus</span></span>

- <span data-ttu-id="c9c46-156">1 つの要素にアタッチされ、セカンダリ コマンドを表示します。</span><span class="sxs-lookup"><span data-stu-id="c9c46-156">Are attached to a single element and display secondary commands.</span></span>
- <span data-ttu-id="c9c46-157">右クリック (または、指で長押しするなどの同等の操作) によって呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="c9c46-157">Are invoked by right clicking (or an equivalent action, such as pressing and holding with your finger).</span></span>
- <span data-ttu-id="c9c46-158">[ContextFlyout](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.contextflyout.aspx) プロパティを介して要素に関連付けられます。</span><span class="sxs-lookup"><span data-stu-id="c9c46-158">Are associated with an element via its [ContextFlyout](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.contextflyout.aspx) property.</span></span>

## <a name="icons"></a><span data-ttu-id="c9c46-159">アイコン</span><span class="sxs-lookup"><span data-stu-id="c9c46-159">Icons</span></span>

<span data-ttu-id="c9c46-160">次のようなメニュー項目のアイコンを用意することを検討します。</span><span class="sxs-lookup"><span data-stu-id="c9c46-160">Consider providing menu item icons for:</span></span>

- <span data-ttu-id="c9c46-161">最もよく使用される項目。</span><span class="sxs-lookup"><span data-stu-id="c9c46-161">The most commonly used items.</span></span>
- <span data-ttu-id="c9c46-162">メニュー項目がアイコンを含む、標準またはよく知られています。</span><span class="sxs-lookup"><span data-stu-id="c9c46-162">Menu items whose icon is standard or well known.</span></span>
- <span data-ttu-id="c9c46-163">メニュー項目がアイコンを含むが、コマンドが何を示しています。</span><span class="sxs-lookup"><span data-stu-id="c9c46-163">Menu items whose icon well illustrates what the command does.</span></span>

<span data-ttu-id="c9c46-164">標準的な視覚表現がないコマンドにアイコンを用意しなければならないと考える必要はありません。</span><span class="sxs-lookup"><span data-stu-id="c9c46-164">Don't feel obligated to provide icons for commands that don't have a standard visualization.</span></span> <span data-ttu-id="c9c46-165">わかりづらいアイコンは役に立たず、視覚的な混乱をもたらし、ユーザーが重要なメニュー項目に集中できなくなります。</span><span class="sxs-lookup"><span data-stu-id="c9c46-165">Cryptic icons aren’t helpful, create visual clutter, and prevent users from focusing on the important menu items.</span></span>

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
> <span data-ttu-id="c9c46-167">MenuFlyoutItem のアイコンのサイズは、16 x 16 ピクセルです。</span><span class="sxs-lookup"><span data-stu-id="c9c46-167">The size of the icon in a MenuFlyoutItem is 16x16px.</span></span> <span data-ttu-id="c9c46-168">SymbolIcon、FontIcon、または PathIcon を使用する場合、アイコンが忠実性の損失なしで適切なサイズに自動的にスケールされます。</span><span class="sxs-lookup"><span data-stu-id="c9c46-168">If you use SymbolIcon, FontIcon, or PathIcon, the icon automatically scales to the correct size with no loss of fidelity.</span></span> <span data-ttu-id="c9c46-169">BitmapIcon を使用すると、アセットは必ず 16 x 16 ピクセルになります。</span><span class="sxs-lookup"><span data-stu-id="c9c46-169">If you use BitmapIcon, ensure that your asset is 16x16px.</span></span>  

## <a name="create-a-menu-flyout-or-a-context-menu"></a><span data-ttu-id="c9c46-170">フライアウト メニューまたはコンテキスト メニューを作成します。</span><span class="sxs-lookup"><span data-stu-id="c9c46-170">Create a menu flyout or a context menu</span></span>

<span data-ttu-id="c9c46-171">使用するメニュー フライアウトまたはコンテキスト メニューを作成する、 [MenuFlyout クラス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.menuflyout)します。</span><span class="sxs-lookup"><span data-stu-id="c9c46-171">To create a menu flyout or a context menu, you use the [MenuFlyout class](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.menuflyout).</span></span> <span data-ttu-id="c9c46-172">追加することで、メニューの内容を定義する[MenuFlyoutItem](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.menuflyoutitem)、 [MenuFlyoutSubItem](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.menuflyoutsubitem)、 [ToggleMenuFlyoutItem](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.togglemenuflyoutitem)、 [RadioMenuFlyoutItem](https://docs.microsoft.com/uwp/api/microsoft.ui.xaml.controls.radiomenuflyoutitem)と[MenuFlyoutSeparator](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.menuflyoutseparator) MenuFlyout するオブジェクト。</span><span class="sxs-lookup"><span data-stu-id="c9c46-172">You define the contents of the menu by adding [MenuFlyoutItem](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.menuflyoutitem), [MenuFlyoutSubItem](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.menuflyoutsubitem), [ToggleMenuFlyoutItem](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.togglemenuflyoutitem), [RadioMenuFlyoutItem](https://docs.microsoft.com/uwp/api/microsoft.ui.xaml.controls.radiomenuflyoutitem) and [MenuFlyoutSeparator](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.menuflyoutseparator) objects to the MenuFlyout.</span></span>

<span data-ttu-id="c9c46-173">これらのオブジェクトの用途を次に説明します。</span><span class="sxs-lookup"><span data-stu-id="c9c46-173">These objects are for:</span></span>

- <span data-ttu-id="c9c46-174">[MenuFlyoutItem](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.menuflyoutitem)—即座にアクションを実行します。</span><span class="sxs-lookup"><span data-stu-id="c9c46-174">[MenuFlyoutItem](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.menuflyoutitem)—Performing an immediate action.</span></span>
- <span data-ttu-id="c9c46-175">[MenuFlyoutSubItem](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.menuflyoutsubitem)— カスケード メニュー項目の一覧を格納しています。</span><span class="sxs-lookup"><span data-stu-id="c9c46-175">[MenuFlyoutSubItem](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.menuflyoutsubitem)—Containing a cascading list of menu items.</span></span>
- <span data-ttu-id="c9c46-176">[ToggleMenuFlyoutItem](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.togglemenuflyoutitem)—オプションのオンとオフを切り替えます。</span><span class="sxs-lookup"><span data-stu-id="c9c46-176">[ToggleMenuFlyoutItem](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.togglemenuflyoutitem)—Switching an option on or off.</span></span>
- <span data-ttu-id="c9c46-177">[RadioMenuFlyoutItem](https://docs.microsoft.com/uwp/api/microsoft.ui.xaml.controls.radiomenuflyoutitem)相互に排他的なメニュー項目間の切り替え。</span><span class="sxs-lookup"><span data-stu-id="c9c46-177">[RadioMenuFlyoutItem](https://docs.microsoft.com/uwp/api/microsoft.ui.xaml.controls.radiomenuflyoutitem)—Switching between mutually-exclusive menu items.</span></span>
- <span data-ttu-id="c9c46-178">[MenuFlyoutSeparator](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.menuflyoutseparator)—メニュー項目を視覚的に分割します。</span><span class="sxs-lookup"><span data-stu-id="c9c46-178">[MenuFlyoutSeparator](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.menuflyoutseparator)—Visually separating menu items.</span></span>

<span data-ttu-id="c9c46-179">この例で作成、 [MenuFlyout](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.menuflyout)を使用して、 [ContextFlyout](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.contextflyout.aspx)プロパティ、コンテキスト メニューとして MenuFlyout を表示する、ほとんどのコントロールに使用可能なプロパティ。</span><span class="sxs-lookup"><span data-stu-id="c9c46-179">This example creates a [MenuFlyout](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.menuflyout) and uses the [ContextFlyout](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.contextflyout.aspx) property, a property available to most controls, to show the MenuFlyout as a context menu.</span></span>

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

<span data-ttu-id="c9c46-180">次の例はほとんど同じですが、[ContextFlyout](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.contextflyout.aspx) プロパティを使って、コンテキスト メニューとして [MenuFlyout クラス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.menuflyout)を表示する代わりに、[FlyoutBase.ShowAttachedFlyout](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.flyoutbase.showattachedflyout) プロパティを使って、メニューとして MenuFlyout クラスを表示します。</span><span class="sxs-lookup"><span data-stu-id="c9c46-180">The next example is nearly identical, but instead of using the [ContextFlyout](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.contextflyout.aspx) property to show the [MenuFlyout class](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.menuflyout) as a context menu, the example uses the [FlyoutBase.ShowAttachedFlyout](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.flyoutbase.showattachedflyout) property to show it as a menu.</span></span>

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

### <a name="light-dismiss"></a><span data-ttu-id="c9c46-181">ライトを閉じる</span><span class="sxs-lookup"><span data-stu-id="c9c46-181">Light dismiss</span></span>

<span data-ttu-id="c9c46-182">ライト メニューのコンテキスト メニューのおよびその他の動的メニューなどのコントロールを閉じる、閉じられるまでの一時的な UI 内でキーボード、ゲームパッドのフォーカスをトラップします。</span><span class="sxs-lookup"><span data-stu-id="c9c46-182">Light dismiss controls such as menus, context menus, and other flyouts, trap keyboard and gamepad focus inside the transient UI until dismissed.</span></span> <span data-ttu-id="c9c46-183">この動作に視覚的な合図を提供するために、Xbox の簡易非表示コントロールは、スコープ外の UI を暗く表示するオーバーレイを描画します。</span><span class="sxs-lookup"><span data-stu-id="c9c46-183">To provide a visual cue for this behavior, light dismiss controls on Xbox will draw an overlay that dims the visibility of out of scope UI.</span></span> <span data-ttu-id="c9c46-184">この動作は、[LightDismissOverlayMode](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.flyoutbase.lightdismissoverlaymode.aspx) プロパティを使って変更できます。</span><span class="sxs-lookup"><span data-stu-id="c9c46-184">This behavior can be modified with the  [LightDismissOverlayMode](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.flyoutbase.lightdismissoverlaymode.aspx) property.</span></span> <span data-ttu-id="c9c46-185">既定では、一時的な Ui は、Xbox でライト dismiss オーバーレイを描画する (**自動**) が、その他のデバイス ファミリではありません。</span><span class="sxs-lookup"><span data-stu-id="c9c46-185">By default, transient UIs will draw the light dismiss overlay on Xbox (**Auto**) but not other device families.</span></span> <span data-ttu-id="c9c46-186">常にオーバーレイを強制することもできます**で**または always**オフ**します。</span><span class="sxs-lookup"><span data-stu-id="c9c46-186">You can choose to force the overlay to be always **On** or always **Off**.</span></span>

```xaml
<MenuFlyout LightDismissOverlayMode="Off" />
```

## <a name="create-a-menu-bar"></a><span data-ttu-id="c9c46-187">メニュー バーを作成します。</span><span class="sxs-lookup"><span data-stu-id="c9c46-187">Create a menu bar</span></span>

> [!IMPORTANT]
> <span data-ttu-id="c9c46-188">メニュー バーには、Windows 10、バージョンは 1809 が必要です ([SDK 17763](https://developer.microsoft.com/windows/downloads/windows-10-sdk)) またはそれ以降、または[Windows UI ライブラリ](https://docs.microsoft.com/uwp/toolkits/winui/)します。</span><span class="sxs-lookup"><span data-stu-id="c9c46-188">MenuBar requires Windows 10, version 1809 ([SDK 17763](https://developer.microsoft.com/windows/downloads/windows-10-sdk)) or later, or the [Windows UI Library](https://docs.microsoft.com/uwp/toolkits/winui/).</span></span>

<span data-ttu-id="c9c46-189">メニュー ポップアップのように、メニュー バーでメニューを作成するのにには、同じ要素を使用します。</span><span class="sxs-lookup"><span data-stu-id="c9c46-189">You use the same elements to create menus in a menu bar as in a menu flyout.</span></span> <span data-ttu-id="c9c46-190">ただしで、MenuFlyout MenuFlyoutItem オブジェクトをグループ化ではなくグループ化するそれら MenuBarItem 要素。</span><span class="sxs-lookup"><span data-stu-id="c9c46-190">However, instead of grouping MenuFlyoutItem objects in a MenuFlyout, you group them in a MenuBarItem element.</span></span> <span data-ttu-id="c9c46-191">各 MenuBarItem は、トップ レベル メニューとしてのメニュー バーに追加されます。</span><span class="sxs-lookup"><span data-stu-id="c9c46-191">Each MenuBarItem is added to the MenuBar as a top level menu.</span></span>

![メニュー バーの例](images/menu-bar-submenu.png)

> [!NOTE]
> <span data-ttu-id="c9c46-193">この例では、UI 構造を作成する方法のみを示していますが、コマンドのいずれかの実装は表示されません。</span><span class="sxs-lookup"><span data-stu-id="c9c46-193">This example shows only how to create the UI structure, but does not show implementation of any of the commands.</span></span>

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

## <a name="get-the-sample-code"></a><span data-ttu-id="c9c46-194">サンプル コードを入手する</span><span class="sxs-lookup"><span data-stu-id="c9c46-194">Get the sample code</span></span>

- <span data-ttu-id="c9c46-195">[XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Xaml-Controls-Gallery) - インタラクティブな形で XAML コントロールのすべてを参照できます。</span><span class="sxs-lookup"><span data-stu-id="c9c46-195">[XAML Controls Gallery sample](https://github.com/Microsoft/Xaml-Controls-Gallery) - See all the XAML controls in an interactive format.</span></span>
- [<span data-ttu-id="c9c46-196">XAML コンテキスト メニューのサンプル</span><span class="sxs-lookup"><span data-stu-id="c9c46-196">XAML Context menu sample</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlContextMenu)

## <a name="related-articles"></a><span data-ttu-id="c9c46-197">関連記事</span><span class="sxs-lookup"><span data-stu-id="c9c46-197">Related articles</span></span>

- [<span data-ttu-id="c9c46-198">MenuFlyout クラス</span><span class="sxs-lookup"><span data-stu-id="c9c46-198">MenuFlyout class</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.menuflyout)
- [<span data-ttu-id="c9c46-199">メニュー バー クラス</span><span class="sxs-lookup"><span data-stu-id="c9c46-199">MenuBar class</span></span>](https://docs.microsoft.com/uwp/api/microsoft.ui.xaml.controls.menubar)
