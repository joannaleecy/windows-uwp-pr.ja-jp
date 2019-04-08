---
Description: コマンド バーのフライアウトは、アプリの最も一般的なタスクのインラインへのアクセスをユーザーに付与します。
title: コマンド バーのポップアップ
label: Command bar flyout
template: detail.hbs
ms.date: 10/02/2018
ms.topic: article
keywords: windows 10, uwp
pm-contact: abarlow
design-contact: ksulliv
dev-contact: llongley
doc-status: Draft
ms.localizationpriority: medium
ms.custom: RS5
ms.openlocfilehash: cb87bea001492e39a0f60b96f884db70b5bd28ad
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57592527"
---
# <a name="command-bar-flyout"></a><span data-ttu-id="9427d-104">コマンド バーのポップアップ</span><span class="sxs-lookup"><span data-stu-id="9427d-104">Command bar flyout</span></span>

<span data-ttu-id="9427d-105">コマンド バーのフライアウトを使用して、UI キャンバス上の要素に関連するフローティング ツールバーでコマンドを表示することによって簡単にアクセスする一般的なタスクをユーザーに提供できます。</span><span class="sxs-lookup"><span data-stu-id="9427d-105">The command bar flyout lets you provide users with easy access to common tasks by showing commands in a floating toolbar related to an element on your UI canvas.</span></span>

![テキスト コマンド バー フライアウト](images/command-bar-flyout-header.png)

> <span data-ttu-id="9427d-107">CommandBarFlyout には、Windows 10、バージョンは 1809 が必要です ([SDK 17763](https://developer.microsoft.com/windows/downloads/windows-10-sdk)) またはそれ以降、または[Windows UI ライブラリ](https://docs.microsoft.com/uwp/toolkits/winui/)します。</span><span class="sxs-lookup"><span data-stu-id="9427d-107">CommandBarFlyout requires Windows 10, version 1809 ([SDK 17763](https://developer.microsoft.com/windows/downloads/windows-10-sdk)) or later, or the [Windows UI Library](https://docs.microsoft.com/uwp/toolkits/winui/).</span></span>

> - <span data-ttu-id="9427d-108">**プラットフォーム Api**:[CommandBarFlyout クラス](/uwp/api/windows.ui.xaml.controls.commandbarflyout)、 [TextCommandBarFlyout クラス](/uwp/api/windows.ui.xaml.controls.textcommandbarflyout)、 [AppBarButton クラス](/uwp/api/windows.ui.xaml.controls.appbarbutton)、 [AppBarToggleButton クラス](/uwp/api/windows.ui.xaml.controls.appbartogglebutton)、 [AppBarSeparator クラス](/uwp/api/windows.ui.xaml.controls.appbarseparator)</span><span class="sxs-lookup"><span data-stu-id="9427d-108">**Platform APIs**: [CommandBarFlyout class](/uwp/api/windows.ui.xaml.controls.commandbarflyout), [TextCommandBarFlyout class](/uwp/api/windows.ui.xaml.controls.textcommandbarflyout), [AppBarButton class](/uwp/api/windows.ui.xaml.controls.appbarbutton), [AppBarToggleButton class](/uwp/api/windows.ui.xaml.controls.appbartogglebutton), [AppBarSeparator class](/uwp/api/windows.ui.xaml.controls.appbarseparator)</span></span>
>- <span data-ttu-id="9427d-109">**Windows UI ライブラリ Api**:[CommandBarFlyout クラス](/uwp/api/microsoft.ui.xaml.controls.commandbarflyout)、 [TextCommandBarFlyout クラス](/uwp/api/microsoft.ui.xaml.controls.textcommandbarflyout)</span><span class="sxs-lookup"><span data-stu-id="9427d-109">**Windows UI Library APIs**: [CommandBarFlyout class](/uwp/api/microsoft.ui.xaml.controls.commandbarflyout), [TextCommandBarFlyout class](/uwp/api/microsoft.ui.xaml.controls.textcommandbarflyout)</span></span>

<span data-ttu-id="9427d-110">ような[CommandBar](app-bars.md)、CommandBarFlyout が**PrimaryCommands**と**SecondaryCommands**プロパティを使用してコマンドを追加できます。</span><span class="sxs-lookup"><span data-stu-id="9427d-110">Like [CommandBar](app-bars.md), CommandBarFlyout has **PrimaryCommands** and **SecondaryCommands** properties you can use to add commands.</span></span> <span data-ttu-id="9427d-111">コマンドは、コレクション、またはその両方に配置できます。</span><span class="sxs-lookup"><span data-stu-id="9427d-111">You can place commands in either collection, or both.</span></span> <span data-ttu-id="9427d-112">プライマリとセカンダリのコマンドを表示するタイミングと方法は、表示モードによって異なります。</span><span class="sxs-lookup"><span data-stu-id="9427d-112">When and how the primary and secondary commands are displayed depends on the display mode.</span></span>

<span data-ttu-id="9427d-113">コマンド バーのフライアウトが 2 つの表示モード:*折りたたまれている*と*展開*します。</span><span class="sxs-lookup"><span data-stu-id="9427d-113">The command bar flyout has two display modes: *collapsed* and *expanded*.</span></span>

- <span data-ttu-id="9427d-114">折りたたみのモードでは、プライマリ コマンドのみが表示されます。</span><span class="sxs-lookup"><span data-stu-id="9427d-114">In the collapsed mode, only the primary commands are shown.</span></span> <span data-ttu-id="9427d-115">場合のコマンド バーのフライアウトがあるプライマリとセカンダリの両方のコマンド、省略記号によって表される、「詳細」ボタン\[•\]が表示されます。</span><span class="sxs-lookup"><span data-stu-id="9427d-115">If your command bar flyout has both primary and secondary commands, a "see more" button, which is represented by an ellipsis \[•••\], is displayed.</span></span> <span data-ttu-id="9427d-116">これにより、ユーザーの拡張モードに遷移するセカンダリ コマンドへのアクセスを取得します。</span><span class="sxs-lookup"><span data-stu-id="9427d-116">This lets the user get access to the secondary commands by transitioning to expanded mode.</span></span>
- <span data-ttu-id="9427d-117">展開のモードでは、プライマリとセカンダリの両方のコマンドが表示されます。</span><span class="sxs-lookup"><span data-stu-id="9427d-117">In the expanded mode, both the primary and secondary commands are shown.</span></span> <span data-ttu-id="9427d-118">(コントロールにセカンダリ項目のみがある場合に表示 MenuFlyout コントロールと同様の方法です。)</span><span class="sxs-lookup"><span data-stu-id="9427d-118">(If the control has only secondary items, they are shown in a way similar to the MenuFlyout control.)</span></span>

## <a name="is-this-the-right-control"></a><span data-ttu-id="9427d-119">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="9427d-119">Is this the right control?</span></span>

<span data-ttu-id="9427d-120">コマンドのコレクションをボタンやメニュー項目は、アプリのキャンバス上の要素のコンテキストでユーザーに表示するのにには、CommandBarFlyout コントロールを使用します。</span><span class="sxs-lookup"><span data-stu-id="9427d-120">Use the CommandBarFlyout control to show a collection of commands to the user, such as buttons and menu items, in the context of an element on the app canvas.</span></span>

<span data-ttu-id="9427d-121">TextCommandBarFlyout では、TextBox、TextBlock、RichEditBox、RichTextBlock、および PasswordBox コントロールのテキスト コマンドが表示されます。</span><span class="sxs-lookup"><span data-stu-id="9427d-121">The TextCommandBarFlyout displays text commands in TextBox, TextBlock, RichEditBox, RichTextBlock, and PasswordBox controls.</span></span> <span data-ttu-id="9427d-122">コマンドは、現在のテキストの選択を適切に構成に自動的には。</span><span class="sxs-lookup"><span data-stu-id="9427d-122">The commands are automatically configured appropriately to the current text selection.</span></span> <span data-ttu-id="9427d-123">CommandBarFlyout を使用して、テキスト コントロールの既定のテキスト コマンドを置き換えます。</span><span class="sxs-lookup"><span data-stu-id="9427d-123">Use a CommandBarFlyout to replace the default text commands on text controls.</span></span>

<span data-ttu-id="9427d-124">コンテキストを表示するリスト項目に対してコマンドがのガイダンスに従って[コレクションとリストのコンテキストのコマンドを実行](collection-commanding.md)します。</span><span class="sxs-lookup"><span data-stu-id="9427d-124">To show contextual commands on list items follow the guidance in [Contextual commanding for collections and lists](collection-commanding.md).</span></span>

### <a name="commandbarflyout-vs-menuflyout"></a><span data-ttu-id="9427d-125">CommandBarFlyout vs MenuFlyout</span><span class="sxs-lookup"><span data-stu-id="9427d-125">CommandBarFlyout vs MenuFlyout</span></span>

<span data-ttu-id="9427d-126">コンテキスト メニューのコマンドを表示するには、CommandBarFlyout または MenuFlyout を使用できます。</span><span class="sxs-lookup"><span data-stu-id="9427d-126">To show commands in a context menu, you can use CommandBarFlyout or MenuFlyout.</span></span> <span data-ttu-id="9427d-127">MenuFlyout より多くの機能を提供するため CommandBarFlyout をお勧めします。</span><span class="sxs-lookup"><span data-stu-id="9427d-127">We recommend CommandBarFlyout because it provides more functionality than MenuFlyout.</span></span> <span data-ttu-id="9427d-128">セカンダリ コマンドのみで CommandBarFlyout を使ってを動作を取得し、MenuFlyout の探すか、完全なコマンド バーのフライアウトを使用して、プライマリとセカンダリの両方のコマンドを使用できます。</span><span class="sxs-lookup"><span data-stu-id="9427d-128">You can use CommandBarFlyout with only secondary commands to get the behavior and look of a MenuFlyout, or use the full command bar flyout with both primary and secondary commands.</span></span>

> <span data-ttu-id="9427d-129">関連する情報は、次を参照してください。[フライアウト](../controls-and-patterns/dialogs-and-flyouts/flyouts.md)、[メニューおよびコンテキスト メニュー](menus.md)、および[コマンド バー](app-bars.md)します。</span><span class="sxs-lookup"><span data-stu-id="9427d-129">For related info, see [Flyouts](../controls-and-patterns/dialogs-and-flyouts/flyouts.md), [Menus and context menus](menus.md), and [Command bars](app-bars.md).</span></span>

## <a name="examples"></a><span data-ttu-id="9427d-130">例</span><span class="sxs-lookup"><span data-stu-id="9427d-130">Examples</span></span>

<table>
<th align="left"><span data-ttu-id="9427d-131">XAML コントロール ギャラリー</span><span class="sxs-lookup"><span data-stu-id="9427d-131">XAML Controls Gallery</span></span><th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><span data-ttu-id="9427d-132">ある場合、 <strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong>アプリをインストールするには、ここをクリックして<a href="xamlcontrolsgallery:/item/CommandBarFlyout">アプリを開き、アクションで CommandBarFlyout を参照してください。</a>します。</span><span class="sxs-lookup"><span data-stu-id="9427d-132">If you have the <strong style="font-weight: semi-bold">XAML Controls Gallery</strong> app installed, click here to <a href="xamlcontrolsgallery:/item/CommandBarFlyout">open the app and see the CommandBarFlyout in action</a>.</span></span></p>
    <ul>
    <li><span data-ttu-id="9427d-133"><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</a></span><span class="sxs-lookup"><span data-stu-id="9427d-133"><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">Get the XAML Controls Gallery app (Microsoft Store)</a></span></span></li>
    <li><span data-ttu-id="9427d-134"><a href="https://github.com/Microsoft/Xaml-Controls-Gallery">ソース コード (GitHub) を入手する</a></span><span class="sxs-lookup"><span data-stu-id="9427d-134"><a href="https://github.com/Microsoft/Xaml-Controls-Gallery">Get the source code (GitHub)</a></span></span></li>
    </ul>
</td>
</tr>
</table>

## <a name="proactive-vs-reactive-invocation"></a><span data-ttu-id="9427d-135">事前と事後対応型の呼び出し</span><span class="sxs-lookup"><span data-stu-id="9427d-135">Proactive vs. reactive invocation</span></span>

<span data-ttu-id="9427d-136">フライアウトや UI キャンバス上の要素に関連付けられているメニューを呼び出す 2 つの方法は通常:_プロアクティブ呼び出し_と_事後対応型の呼び出し_します。</span><span class="sxs-lookup"><span data-stu-id="9427d-136">There are typically two ways to invoke a flyout or menu that's associated with an element on your UI canvas: _proactive invocation_ and _reactive invocation_.</span></span>

<span data-ttu-id="9427d-137">コマンドは事前対応型の呼び出しでは、ユーザーがコマンドに関連付けられている項目と対話するときに自動的に表示します。</span><span class="sxs-lookup"><span data-stu-id="9427d-137">In proactive invocation, commands appear automatically when the user interacts with the item that the commands are associated with.</span></span> <span data-ttu-id="9427d-138">たとえば、テキストの書式設定コマンドをポップアップ表示、ユーザーがテキスト ボックスでテキストを選択。</span><span class="sxs-lookup"><span data-stu-id="9427d-138">For example, text formatting commands might pop up when the user selects text in a text box.</span></span> <span data-ttu-id="9427d-139">この場合、コマンド バーのフライアウトは、フォーカスは考慮されません。</span><span class="sxs-lookup"><span data-stu-id="9427d-139">In this case, the command bar flyout does not take focus.</span></span> <span data-ttu-id="9427d-140">代わりに、ユーザーが対話する項目の近くに関連するコマンドを表示します。</span><span class="sxs-lookup"><span data-stu-id="9427d-140">Instead, it presents relevant commands close to the item the user is interacting with.</span></span> <span data-ttu-id="9427d-141">ユーザーは、コマンドを使用する操作とは、それらが閉じられます。</span><span class="sxs-lookup"><span data-stu-id="9427d-141">If the user doesn't interact with the commands, they are dismissed.</span></span>

<span data-ttu-id="9427d-142">事後対応型の呼び出しでは、コマンドに表示されます、明示的なユーザー アクションに対する応答のコマンドを要求するにはたとえば、右クリックします。</span><span class="sxs-lookup"><span data-stu-id="9427d-142">In reactive invocation, commands are shown in response to an explicit user action to request the commands; for example, a right-click.</span></span> <span data-ttu-id="9427d-143">これは、従来の概念に対応する[コンテキスト メニュー](menus.md)します。</span><span class="sxs-lookup"><span data-stu-id="9427d-143">This corresponds to the traditional concept of a [context menu](menus.md).</span></span>

<span data-ttu-id="9427d-144">方法、または 2 つの組み合わせでも CommandBarFlyout を使用することができます。</span><span class="sxs-lookup"><span data-stu-id="9427d-144">You can use the CommandBarFlyout in either way, or even a mixture of the two.</span></span>

## <a name="create-a-command-bar-flyout"></a><span data-ttu-id="9427d-145">コマンド バーのフライアウトを作成します。</span><span class="sxs-lookup"><span data-stu-id="9427d-145">Create a command bar flyout</span></span>

<span data-ttu-id="9427d-146">この例では、コマンド バーのフライアウトを作成し、事前および事後対応的に使用する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="9427d-146">This example shows how to create a command bar flyout and use it both proactively and reactively.</span></span> <span data-ttu-id="9427d-147">イメージがタップされたときに、折りたたまれたモードで、フライアウトが表示されます。</span><span class="sxs-lookup"><span data-stu-id="9427d-147">When the image is tapped, the flyout is shown in its collapsed mode.</span></span> <span data-ttu-id="9427d-148">、コンテキスト メニューとして表示されると、その展開されたモードで、フライアウトが表示されます。</span><span class="sxs-lookup"><span data-stu-id="9427d-148">When shown as a context menu, the flyout is shown in its expanded mode.</span></span> <span data-ttu-id="9427d-149">どちらの場合、ユーザーは、展開または開かれた後で、フライアウトを折りたたみます。</span><span class="sxs-lookup"><span data-stu-id="9427d-149">In either case, the user can expand or collapse the flyout after it's opened.</span></span>

![折りたたまれたコマンド バーのフライアウトの例](images/command-bar-flyout-img-collapsed.png)

> <span data-ttu-id="9427d-151">_折りたたまれたコマンド バーのフライアウト_</span><span class="sxs-lookup"><span data-stu-id="9427d-151">_A collapsed command bar flyout_</span></span>

![展開されたコマンドのバー フライアウトの例](images/command-bar-flyout-img-expanded.png)

> <span data-ttu-id="9427d-153">_展開されたコマンドのバー フライアウト_</span><span class="sxs-lookup"><span data-stu-id="9427d-153">_An expanded command bar flyout_</span></span>

```xaml
<Grid>
    <Grid.Resources>
        <CommandBarFlyout x:Name="ImageCommandsFlyout">
            <AppBarButton Icon="OutlineStar" ToolTipService.ToolTip="Favorite"/>
            <AppBarButton Icon="Copy" ToolTipService.ToolTip="Copy"/>
            <AppBarButton Icon="Share" ToolTipService.ToolTip="Share"/>
            <CommandBarFlyout.SecondaryCommands>
                <AppBarButton Label="Select all"/>
                <AppBarButton Label="Delete" Icon="Delete"/>
            </CommandBarFlyout.SecondaryCommands>
        </CommandBarFlyout>
    </Grid.Resources>

    <Image Source="Assets/image1.png" Width="300"
           Tapped="Image_Tapped" FlyoutBase.AttachedFlyout="{x:Bind ImageCommandsFlyout}"
           ContextFlyout="{x:Bind ImageCommandsFlyout}"/>
</Grid>
```

```csharp
private void Image_Tapped(object sender, TappedRoutedEventArgs e)
{
    var flyout = FlyoutBase.GetAttachedFlyout((FrameworkElement)sender);
    var options = new FlyoutShowOptions()
    {
        // Position shows the flyout next to the pointer.
        // "Transient" ShowMode makes the flyout open in its collapsed state.
        Position = e.GetPosition((FrameworkElement)sender),
        ShowMode = FlyoutShowMode.Transient
    };
    flyout?.ShowAt((FrameworkElement)sender, options);
}
```

### <a name="show-commands-proactively"></a><span data-ttu-id="9427d-154">事前にコマンドを表示します。</span><span class="sxs-lookup"><span data-stu-id="9427d-154">Show commands proactively</span></span>

<span data-ttu-id="9427d-155">事前にコンテキストに応じたコマンドを表示する場合は、(コマンド バーのフライアウトを縮小する必要があります) 既定でプライマリ コマンドのみを表示する必要があります。</span><span class="sxs-lookup"><span data-stu-id="9427d-155">When you show contextual commands proactively, only the primary commands should be shown by default (the command bar flyout should be collapsed).</span></span> <span data-ttu-id="9427d-156">主要なコマンドのコレクションとコレクション内のセカンダリ コマンドに従来のコンテキスト メニューで行われるその他のコマンドでは、最も重要なコマンドを配置します。</span><span class="sxs-lookup"><span data-stu-id="9427d-156">Place the most important commands in the primary commands collection, and additional commands that would traditionally go in a context menu into the secondary commands collection.</span></span>

<span data-ttu-id="9427d-157">処理する通常のコマンドを事前に表示する、[クリックして](/uwp/api/windows.ui.xaml.controls.primitives.buttonbase.click)または[Tapped](/uwp/api/windows.ui.xaml.uielement.tapped)コマンド バーのフライアウトを表示するイベント。</span><span class="sxs-lookup"><span data-stu-id="9427d-157">To proactively show commands, you typically handle the [Click](/uwp/api/windows.ui.xaml.controls.primitives.buttonbase.click) or [Tapped](/uwp/api/windows.ui.xaml.uielement.tapped) event to show the command bar flyout.</span></span> <span data-ttu-id="9427d-158">設定フライアウトの[ShowMode](/uwp/api/windows.ui.xaml.controls.primitives.flyoutbase.showmode)に**一時的な**または**TransientWithDismissOnPointerMoveAway**フォーカスすることがなく、折りたたみモードで、フライアウトを開きます。</span><span class="sxs-lookup"><span data-stu-id="9427d-158">Set the flyout's [ShowMode](/uwp/api/windows.ui.xaml.controls.primitives.flyoutbase.showmode) to **Transient** or **TransientWithDismissOnPointerMoveAway** to open the flyout in its collapsed mode without taking focus.</span></span>

<span data-ttu-id="9427d-159">以降、Windows 10 Insider Preview では、テキスト コントロールが、 **SelectionFlyout**プロパティ。</span><span class="sxs-lookup"><span data-stu-id="9427d-159">Starting in the Windows 10 Insider Preview, text controls have a **SelectionFlyout** property.</span></span> <span data-ttu-id="9427d-160">このプロパティにフライアウトを割り当てるときにテキストが選択されているときに自動的に表示されます。</span><span class="sxs-lookup"><span data-stu-id="9427d-160">When you assign a flyout to this property, it is automatically shown when text is selected.</span></span>

### <a name="show-commands-reactively"></a><span data-ttu-id="9427d-161">事後対応的にコマンドを表示します。</span><span class="sxs-lookup"><span data-stu-id="9427d-161">Show commands reactively</span></span>

<span data-ttu-id="9427d-162">コンテキストに応じたコマンドをリアクティブ、コンテキスト メニューを表示すると、セカンダリ コマンド (コマンド バーのフライアウトを展開する必要があります) 既定で表示されます。</span><span class="sxs-lookup"><span data-stu-id="9427d-162">When you show contextual commands reactively, as a context menu, the secondary commands are shown by default (the command bar flyout should be expanded).</span></span> <span data-ttu-id="9427d-163">この場合、コマンド バーのフライアウトでは、プライマリとセカンダリの両方のコマンド、またはセカンダリ コマンドのみがあります。</span><span class="sxs-lookup"><span data-stu-id="9427d-163">In this case, the command bar flyout might have both primary and secondary commands, or secondary commands only.</span></span>

<span data-ttu-id="9427d-164">に対するフライアウトの割り当てる通常コマンドのコンテキスト メニューを表示する、 [ContextFlyout](/uwp/api/windows.ui.xaml.uielement.contextflyout) UI 要素のプロパティ。</span><span class="sxs-lookup"><span data-stu-id="9427d-164">To show commands in a context menu, you typically assign the flyout to the [ContextFlyout](/uwp/api/windows.ui.xaml.uielement.contextflyout) property of a UI element.</span></span> <span data-ttu-id="9427d-165">これによりは、要素によって処理されます、フライアウトを開くと何もする必要はありません。</span><span class="sxs-lookup"><span data-stu-id="9427d-165">This way, opening the flyout is handled by the element, and you don't need to do anything more.</span></span>

<span data-ttu-id="9427d-166">フライアウトを自分で表示を処理する場合 (などで、 [RightTapped](/uwp/api/windows.ui.xaml.uielement.righttapped)イベント)、設定フライアウトの[ShowMode](/uwp/api/windows.ui.xaml.controls.primitives.flyoutbase.showmode)に**標準**拡張モードで、フライアウトを開くとフォーカスを設定します。</span><span class="sxs-lookup"><span data-stu-id="9427d-166">If you handle showing the flyout yourself (for example, on a [RightTapped](/uwp/api/windows.ui.xaml.uielement.righttapped) event), set the flyout's [ShowMode](/uwp/api/windows.ui.xaml.controls.primitives.flyoutbase.showmode) to **Standard** to open the flyout in its expanded mode and give it focus.</span></span>

> [!TIP]
> <span data-ttu-id="9427d-167">フライアウトとフライアウトの位置を制御する方法を表示するときのオプションの詳細については、次を参照してください。[フライアウト](../controls-and-patterns/dialogs-and-flyouts/flyouts.md)します。</span><span class="sxs-lookup"><span data-stu-id="9427d-167">For more info about options when showing a flyout and how to control placement of the flyout, see [Flyouts](../controls-and-patterns/dialogs-and-flyouts/flyouts.md).</span></span>

## <a name="commands-and-content"></a><span data-ttu-id="9427d-168">コマンドとコンテンツ</span><span class="sxs-lookup"><span data-stu-id="9427d-168">Commands and content</span></span>

<span data-ttu-id="9427d-169">CommandBarFlyout コントロールには、コマンドとコンテンツを追加するに使用できる 2 つのプロパティがあります。[PrimaryCommands](/uwp/api/windows.ui.xaml.controls.commandbarflyout.primarycommands)と[SecondaryCommands](/uwp/api/windows.ui.xaml.controls.commandbarflyout.secondarycommands)します。</span><span class="sxs-lookup"><span data-stu-id="9427d-169">The CommandBarFlyout control has 2 properties you can use to add commands and content: [PrimaryCommands](/uwp/api/windows.ui.xaml.controls.commandbarflyout.primarycommands) and [SecondaryCommands](/uwp/api/windows.ui.xaml.controls.commandbarflyout.secondarycommands).</span></span>

<span data-ttu-id="9427d-170">既定では、コマンド バーの項目は **PrimaryCommands** コレクションに追加されます。</span><span class="sxs-lookup"><span data-stu-id="9427d-170">By default, command bar items are added to the **PrimaryCommands** collection.</span></span> <span data-ttu-id="9427d-171">これらのコマンドは、コマンド バーに表示されますが折りたたまれ、展開の両方のモードで表示されます。</span><span class="sxs-lookup"><span data-stu-id="9427d-171">These commands are shown in the command bar and are visible in both the collapsed and expanded modes.</span></span> <span data-ttu-id="9427d-172">CommandBar とは異なりは、プライマリ コマンドは、自動的にセカンダリ コマンドにオーバーフローではないと、切り捨てられる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="9427d-172">Unlike CommandBar, primary commands do not automatically overflow to the secondary commands and might be truncated.</span></span>

<span data-ttu-id="9427d-173">コマンドを追加することも、 **SecondaryCommands**コレクション。</span><span class="sxs-lookup"><span data-stu-id="9427d-173">You can also add commands to the **SecondaryCommands** collection.</span></span> <span data-ttu-id="9427d-174">セカンダリ コマンドでは、コントロールのメニューの部分では表示され、展開モードでのみ表示されます。</span><span class="sxs-lookup"><span data-stu-id="9427d-174">Secondary commands are shown in the menu portion of the control and are visible only in the expanded mode.</span></span>

### <a name="app-bar-buttons"></a><span data-ttu-id="9427d-175">アプリ バーのボタン</span><span class="sxs-lookup"><span data-stu-id="9427d-175">App bar buttons</span></span>

<span data-ttu-id="9427d-176">PrimaryCommands と SecondaryCommands を直接読み込める[AppBarButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbarbutton.aspx)、 [AppBarToggleButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbartogglebutton.aspx)、および[AppBarSeparator](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbarseparator.aspx)コントロール。</span><span class="sxs-lookup"><span data-stu-id="9427d-176">You can populate the PrimaryCommands and SecondaryCommands directly with [AppBarButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbarbutton.aspx), [AppBarToggleButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbartogglebutton.aspx), and [AppBarSeparator](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbarseparator.aspx) controls.</span></span>

<span data-ttu-id="9427d-177">アプリ バーのボタン コントロールは、アイコンとテキスト ラベルによって特徴付けられます。</span><span class="sxs-lookup"><span data-stu-id="9427d-177">The app bar button controls are characterized by an icon and text label.</span></span> <span data-ttu-id="9427d-178">これらのコントロールがコマンド バーで使用するために最適化されたし、外観のコントロールがコマンド バーまたはオーバーフロー メニューに表示するかどうかに応じて変化します。</span><span class="sxs-lookup"><span data-stu-id="9427d-178">These controls are optimized for use in a command bar, and their appearance changes depending on whether the control is shown in the command bar or the overflow menu.</span></span>

- <span data-ttu-id="9427d-179">そのアイコンのみで、コマンド バーの主要なコマンドとして使用されるアプリ バーのボタンが表示されます。テキスト ラベルは表示されません。</span><span class="sxs-lookup"><span data-stu-id="9427d-179">App bar buttons used as primary commands are shown in the command bar with only their icon; the text label is not shown.</span></span> <span data-ttu-id="9427d-180">次に示すように、コマンドのテキスト説明を表示するツールヒントを使用することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="9427d-180">We recommend that you use a tooltip to show a text description of the command, as shown here.</span></span>
    ```xaml
    <AppBarButton Icon="Copy" ToolTipService.ToolTip="Copy"/>
    ```
- <span data-ttu-id="9427d-181">セカンダリ コマンドとして使用されるアプリ バー ボタン、ラベルとアイコンが表示されると、メニューに表示されます。</span><span class="sxs-lookup"><span data-stu-id="9427d-181">App bar buttons used as secondary commands are shown in the menu, with both the label and icon visible.</span></span>

### <a name="other-content"></a><span data-ttu-id="9427d-182">その他のコンテンツ</span><span class="sxs-lookup"><span data-stu-id="9427d-182">Other content</span></span>

<span data-ttu-id="9427d-183">AppBarElementContainer で囲むことによって、コマンド バーのフライアウトを他のコントロールを追加できます。</span><span class="sxs-lookup"><span data-stu-id="9427d-183">You can add other controls to a command bar flyout by wrapping them in an AppBarElementContainer.</span></span> <span data-ttu-id="9427d-184">などのコントロールを追加できます[DropDownButton](buttons.md)または[SplitButton](buttons.md)などのコンテナーを追加または[StackPanel](buttons.md)より複雑な UI を作成します。</span><span class="sxs-lookup"><span data-stu-id="9427d-184">This lets you add controls like [DropDownButton](buttons.md) or [SplitButton](buttons.md), or add containers like [StackPanel](buttons.md) to create more complex UI.</span></span>

<span data-ttu-id="9427d-185">コマンド バーのフライアウトのプライマリまたはセカンダリのコマンドのコレクションに追加するには、要素を実装する必要があります、 [ICommandBarElement](/uwp/api/windows.ui.xaml.controls.icommandbarelement)インターフェイス。</span><span class="sxs-lookup"><span data-stu-id="9427d-185">In order to be added to the primary or secondary command collections of a command bar flyout, an element must implement the [ICommandBarElement](/uwp/api/windows.ui.xaml.controls.icommandbarelement) interface.</span></span> <span data-ttu-id="9427d-186">AppBarElementContainer は、インターフェイス自体を実装していない場合でも、コマンド バーに要素を追加できるように、このインターフェイスを実装するラッパーです。</span><span class="sxs-lookup"><span data-stu-id="9427d-186">AppBarElementContainer is a wrapper that implements this interface so you can add an element to a command bar even if it doesn't implement the interface itself.</span></span>

<span data-ttu-id="9427d-187">ここでは、AppBarElementContainer を使用して、コマンド バーのフライアウトに余分な要素を追加できます。</span><span class="sxs-lookup"><span data-stu-id="9427d-187">Here, an AppBarElementContainer is used to add extra elements to a command bar flyout.</span></span> <span data-ttu-id="9427d-188">Splitbutton でしょうが、色の選択できるようにする主要なコマンドに追加されます。</span><span class="sxs-lookup"><span data-stu-id="9427d-188">A SplitButton is added to the primary commands to allow selection of colors.</span></span> <span data-ttu-id="9427d-189">StackPanel は、ズーム コントロールのより複雑なレイアウトを許可するセカンダリ コマンドに追加されます。</span><span class="sxs-lookup"><span data-stu-id="9427d-189">A StackPanel is added to the secondary commands to allow a more complex layout for zoom controls.</span></span>

> [!TIP]
> <span data-ttu-id="9427d-190">既定では、アプリのキャンバス用に設計された要素はないように見えます適切なコマンド バーにします。</span><span class="sxs-lookup"><span data-stu-id="9427d-190">By default, elements designed for the app canvas might not look right in a command bar.</span></span> <span data-ttu-id="9427d-191">AppBarElementContainer を使用して要素を追加する場合は、要素が他のコマンド バーの要素との一致を行う必要があります、いくつかの手順があります。</span><span class="sxs-lookup"><span data-stu-id="9427d-191">When you add an element using AppBarElementContainer, there are some steps you should take to make the element match other command bar elements:</span></span>
>
> - <span data-ttu-id="9427d-192">オーバーライドと既定のブラシ[簡易スタイル](/windows/uwp/design/controls-and-patterns/xaml-styles#lightweight-styling)要素の背景や罫線アプリ バーのボタンを一致させる。</span><span class="sxs-lookup"><span data-stu-id="9427d-192">Override the default brushes with [lightweight styling](/windows/uwp/design/controls-and-patterns/xaml-styles#lightweight-styling) to make the element's background and border match the app bar buttons.</span></span>
> - <span data-ttu-id="9427d-193">要素の位置とサイズを調整します。</span><span class="sxs-lookup"><span data-stu-id="9427d-193">Adjust the size and position of the element.</span></span>
> - <span data-ttu-id="9427d-194">16 px の高さ、幅、Viewbox にアイコンをラップします。</span><span class="sxs-lookup"><span data-stu-id="9427d-194">Wrap icons in a Viewbox with a Width and Height of 16px.</span></span>

> [!NOTE]
> <span data-ttu-id="9427d-195">この例では、示されているコマンドのいずれかが実装していないのみ、コマンド バーのフライアウト、UI を示します。</span><span class="sxs-lookup"><span data-stu-id="9427d-195">This example shows only the command bar flyout UI, it does not implement any of the commands that are shown.</span></span> <span data-ttu-id="9427d-196">コマンドの実装の詳細については、次を参照してください。[ボタン](buttons.md)と[コマンド デザインの基礎](../basics/commanding-basics.md)します。</span><span class="sxs-lookup"><span data-stu-id="9427d-196">For more info about implementing the commands, see [Buttons](buttons.md) and [Command design basics](../basics/commanding-basics.md).</span></span>

![分割ボタンのコマンド バーのフライアウト](images/command-bar-flyout-split-button.png)

> <span data-ttu-id="9427d-198">_オープンの SplitButton で折りたたまれているコマンド バーのフライアウト_</span><span class="sxs-lookup"><span data-stu-id="9427d-198">_A collapsed command bar flyout with an open SplitButton_</span></span>

![複雑な UI を使用したコマンド バーのフライアウト](images/command-bar-flyout-custom-ui.png)

> <span data-ttu-id="9427d-200">_メニューにカスタムのズーム UI と、展開コマンド バーのフライアウト_</span><span class="sxs-lookup"><span data-stu-id="9427d-200">_An expanded command bar flyout with custom zoom UI in the menu_</span></span>


```xaml
<CommandBarFlyout>
    <AppBarButton Icon="Cut" ToolTipService.ToolTip="Cut"/>
    <AppBarButton Icon="Copy" ToolTipService.ToolTip="Copy"/>
    <AppBarButton Icon="Paste" ToolTipService.ToolTip="Paste"/>
    <!-- Alignment controls -->
    <AppBarElementContainer>
        <SplitButton ToolTipService.ToolTip="Alignment">
            <SplitButton.Resources>
                <!-- Override default brushes to make the SplitButton 
                     match other command bar elements. -->
                <Style TargetType="SplitButton">
                    <Setter Property="Height" Value="38"/>
                </Style>
                <SolidColorBrush x:Key="SplitButtonBackground"
                                 Color="Transparent"/>
                <SolidColorBrush x:Key="SplitButtonBackgroundPressed"
                                 Color="{ThemeResource SystemListMediumColor}"/>
                <SolidColorBrush x:Key="SplitButtonBackgroundPointerOver"
                                 Color="{ThemeResource SystemListLowColor}"/>
                <SolidColorBrush x:Key="SplitButtonBorderBrush" Color="Transparent"/>
                <SolidColorBrush x:Key="SplitButtonBorderBrushPointerOver"
                                 Color="Transparent"/>
                <SolidColorBrush x:Key="SplitButtonBorderBrushChecked"
                                 Color="Transparent"/>
            </SplitButton.Resources>
            <SplitButton.Content>
                <Viewbox Width="16" Height="16" Margin="0,2,0,0">
                    <SymbolIcon Symbol="AlignLeft"/>
                </Viewbox>
            </SplitButton.Content>
            <SplitButton.Flyout>
                <MenuFlyout>
                    <MenuFlyoutItem Icon="AlignLeft" Text="Align left"/>
                    <MenuFlyoutItem Icon="AlignCenter" Text="Center"/>
                    <MenuFlyoutItem Icon="AlignRight" Text="Align right"/>
                </MenuFlyout>
            </SplitButton.Flyout>
        </SplitButton>
    </AppBarElementContainer>
    <!-- end Alignment controls -->
    <CommandBarFlyout.SecondaryCommands>
        <!-- Zoom controls -->
        <AppBarElementContainer>
            <AppBarElementContainer.Resources>
                <!-- Override default brushes to make the Buttons 
                     match other command bar elements. -->
                <SolidColorBrush x:Key="ButtonBackground"
                                 Color="Transparent"/>
                <SolidColorBrush x:Key="ButtonBackgroundPressed"
                                 Color="{ThemeResource SystemListMediumColor}"/>
                <SolidColorBrush x:Key="ButtonBackgroundPointerOver"
                                 Color="{ThemeResource SystemListLowColor}"/>
                <SolidColorBrush x:Key="ButtonBorderBrush"
                                 Color="Transparent"/>
                <SolidColorBrush x:Key="ButtonBorderBrushPointerOver"
                                 Color="Transparent"/>
                <SolidColorBrush x:Key="ButtonBorderBrushChecked"
                                 Color="Transparent"/>
                <Style TargetType="TextBlock">
                    <Setter Property="VerticalAlignment" Value="Center"/>
                </Style>
                <Style TargetType="Button">
                    <Setter Property="Height" Value="40"/>
                    <Setter Property="Width" Value="40"/>
                </Style>
            </AppBarElementContainer.Resources>
            <Grid Margin="12,-4">
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width="Auto"/>
                    <ColumnDefinition Width="76"/>
                    <ColumnDefinition Width="Auto"/>
                </Grid.ColumnDefinitions>
                <Viewbox Width="16" Height="16" Margin="0,2,0,0">
                    <SymbolIcon Symbol="Zoom"/>
                </Viewbox>
                <TextBlock Text="Zoom" Margin="10,0,0,0" Grid.Column="1"/>
                <StackPanel Orientation="Horizontal" Grid.Column="2">
                    <Button ToolTipService.ToolTip="Zoom out">
                        <Viewbox Width="16" Height="16">
                            <SymbolIcon Symbol="ZoomOut"/>
                        </Viewbox>
                    </Button>
                    <TextBlock Text="50%" Width="40"
                               HorizontalTextAlignment="Center"/>
                    <Button ToolTipService.ToolTip="Zoom in">
                        <Viewbox Width="16" Height="16">
                            <SymbolIcon Symbol="ZoomIn"/>
                        </Viewbox>
                    </Button>
                </StackPanel>
            </Grid>
        </AppBarElementContainer>
        <!-- end Zoom controls -->
        <AppBarSeparator/>
        <AppBarButton Label="Undo" Icon="Undo"/>
        <AppBarButton Label="Redo" Icon="Redo"/>
        <AppBarButton Label="Select all" Icon="SelectAll"/>
    </CommandBarFlyout.SecondaryCommands>
</CommandBarFlyout>
```

## <a name="create-a-context-menu-with-secondary-commands-only"></a><span data-ttu-id="9427d-201">セカンダリ コマンドのみを使用してコンテキスト メニューを作成します。</span><span class="sxs-lookup"><span data-stu-id="9427d-201">Create a context menu with secondary commands only</span></span>

<span data-ttu-id="9427d-202">セカンダリ コマンドとしてのみで、CommandBarFlyout を使用できる、[コンテキスト メニュー](menus.md)、MenuFlyout の代わりにします。</span><span class="sxs-lookup"><span data-stu-id="9427d-202">You can use a CommandBarFlyout with only secondary commands as a [context menu](menus.md), in place of a MenuFlyout.</span></span>

![セカンダリ コマンドのみを使用してコマンド バーのフライアウト](images/command-bar-flyout-context-menu.png)

> <span data-ttu-id="9427d-204">_コンテキスト メニューとコマンド バーのフライアウト_</span><span class="sxs-lookup"><span data-stu-id="9427d-204">_Command bar flyout as a context menu_</span></span>

```xaml
<Grid>
    <Grid.Resources>
        <!-- A command bar flyout with only secondary commands. -->
        <CommandBarFlyout x:Name="ContextMenu">
            <CommandBarFlyout.SecondaryCommands>
                <AppBarButton Label="Copy" Icon="Copy"/>
                <AppBarButton Label="Save" Icon="Save"/>
                <AppBarButton Label="Print" Icon="Print"/>
                <AppBarSeparator />
                <AppBarButton Label="Properties"/>
            </CommandBarFlyout.SecondaryCommands>
        </CommandBarFlyout>
    </Grid.Resources>

    <Image Source="Assets/image1.png" Width="300"
           ContextFlyout="{x:Bind ContextMenu}"/>
</Grid>
```

<span data-ttu-id="9427d-205">標準メニューを作成するのにと、DropDownButton、CommandBarFlyout を使用することもできます。</span><span class="sxs-lookup"><span data-stu-id="9427d-205">You can also use a CommandBarFlyout with a DropDownButton to create a standard menu.</span></span>

![ドロップダウン ボタンのメニューとコマンド バー フライアウト](images/command-bar-flyout-dropdown.png)

> <span data-ttu-id="9427d-207">_ドロップダウン ボタンのメニュー コマンド バーのフライアウトで_</span><span class="sxs-lookup"><span data-stu-id="9427d-207">_A drop down button menu in a command bar flyout_</span></span>

```xaml
<CommandBarFlyout>
    <AppBarButton Icon="Placeholder"/>
    <AppBarElementContainer>
        <DropDownButton Content="Mail">
            <DropDownButton.Resources>
                <!-- Override default brushes to make the DropDownButton 
                     match other command bar elements. -->
                <Style TargetType="DropDownButton">
                    <Setter Property="Height" Value="38"/>
                </Style>
                <SolidColorBrush x:Key="ButtonBackground"
                                 Color="Transparent"/>
                <SolidColorBrush x:Key="ButtonBackgroundPressed"
                                 Color="{ThemeResource SystemListMediumColor}"/>
                <SolidColorBrush x:Key="ButtonBackgroundPointerOver"
                                 Color="{ThemeResource SystemListLowColor}"/>

                <SolidColorBrush x:Key="ButtonBorderBrush"
                                 Color="Transparent"/>
                <SolidColorBrush x:Key="ButtonBorderBrushPointerOver"
                                 Color="Transparent"/>
                <SolidColorBrush x:Key="ButtonBorderBrushChecked"
                                 Color="Transparent"/>
            </DropDownButton.Resources>
            <DropDownButton.Flyout>
                <CommandBarFlyout Placement="BottomEdgeAlignedLeft">
                    <CommandBarFlyout.SecondaryCommands>
                        <AppBarButton Icon="MailReply" Label="Reply"/>
                        <AppBarButton Icon="MailReplyAll" Label="Reply all"/>
                        <AppBarButton Icon="MailForward" Label="Forward"/>
                    </CommandBarFlyout.SecondaryCommands>
                </CommandBarFlyout>
            </DropDownButton.Flyout>
        </DropDownButton>
    </AppBarElementContainer>
    <AppBarButton Icon="Placeholder"/>
    <AppBarButton Icon="Placeholder"/>
</CommandBarFlyout>
```

## <a name="command-bar-flyouts-for-text-controls"></a><span data-ttu-id="9427d-208">テキスト コントロールのコマンド バーのフライアウト</span><span class="sxs-lookup"><span data-stu-id="9427d-208">Command bar flyouts for text controls</span></span>

<span data-ttu-id="9427d-209">[TextCommandBarFlyout](/uwp/api/microsoft.ui.xaml.controls.textcommandbarflyout)テキストを編集するためのコマンドを含む特殊なコマンド バーのフライアウトが。</span><span class="sxs-lookup"><span data-stu-id="9427d-209">The [TextCommandBarFlyout](/uwp/api/microsoft.ui.xaml.controls.textcommandbarflyout) is a specialized command bar flyout that contains commands for editing text.</span></span> <span data-ttu-id="9427d-210">各テキスト コントロールでは、コンテキスト メニュー (右クリック)、またはテキストが選択されているときに自動的に、TextCommandBarFlyout が表示されます。</span><span class="sxs-lookup"><span data-stu-id="9427d-210">Each text control shows the TextCommandBarFlyout automatically as a context menu (right-click), or when text is selected.</span></span> <span data-ttu-id="9427d-211">テキスト コマンド バーのフライアウトは、関連するコマンドのみを表示するテキストの選択範囲に適応します。</span><span class="sxs-lookup"><span data-stu-id="9427d-211">The text command bar flyout adapts to the text selection to only show relevant commands.</span></span>

![縮小テキストのコマンド バーのフライアウト](images/command-bar-flyout-text-selection.png)

> <span data-ttu-id="9427d-213">_テキストの選択項目のテキスト コマンド バー フライアウト_</span><span class="sxs-lookup"><span data-stu-id="9427d-213">_A text command bar flyout on text selection_</span></span>

![テキスト コマンド バー フライアウト](images/command-bar-flyout-text-full.png)

> <span data-ttu-id="9427d-215">_テキスト コマンド バー フライアウト_</span><span class="sxs-lookup"><span data-stu-id="9427d-215">_An expanded text command bar flyout_</span></span>


### <a name="available-commands"></a><span data-ttu-id="9427d-216">使用可能なコマンド</span><span class="sxs-lookup"><span data-stu-id="9427d-216">Available commands</span></span>

<span data-ttu-id="9427d-217">表示されるときに、TextCommandBarFlyout に含まれているコマンドを次の表に示します。</span><span class="sxs-lookup"><span data-stu-id="9427d-217">This table shows the commands that are included in a TextCommandBarFlyout, and when they are shown.</span></span>

| <span data-ttu-id="9427d-218">コマンド</span><span class="sxs-lookup"><span data-stu-id="9427d-218">Command</span></span> | <span data-ttu-id="9427d-219">表示しています.</span><span class="sxs-lookup"><span data-stu-id="9427d-219">Shown...</span></span> |
| ------- | -------- |
| <span data-ttu-id="9427d-220">Bold</span><span class="sxs-lookup"><span data-stu-id="9427d-220">Bold</span></span> | <span data-ttu-id="9427d-221">ときに、テキスト コントロールは、読み取り専用 (RichEditBox のみ) ではありません。</span><span class="sxs-lookup"><span data-stu-id="9427d-221">when the text control is not read-only (RichEditBox only).</span></span> |
| <span data-ttu-id="9427d-222">Italic</span><span class="sxs-lookup"><span data-stu-id="9427d-222">Italic</span></span> | <span data-ttu-id="9427d-223">ときに、テキスト コントロールは、読み取り専用 (RichEditBox のみ) ではありません。</span><span class="sxs-lookup"><span data-stu-id="9427d-223">when the text control is not read-only (RichEditBox only).</span></span> |
| <span data-ttu-id="9427d-224">Underline</span><span class="sxs-lookup"><span data-stu-id="9427d-224">Underline</span></span> | <span data-ttu-id="9427d-225">ときに、テキスト コントロールは、読み取り専用 (RichEditBox のみ) ではありません。</span><span class="sxs-lookup"><span data-stu-id="9427d-225">when the text control is not read-only (RichEditBox only).</span></span> |
| <span data-ttu-id="9427d-226">校正</span><span class="sxs-lookup"><span data-stu-id="9427d-226">Proofing</span></span> | <span data-ttu-id="9427d-227">IsSpellCheckEnabled が場合**true**スペル ミスのテキストが選択されているとします。</span><span class="sxs-lookup"><span data-stu-id="9427d-227">when IsSpellCheckEnabled is **true** and misspelled text is selected.</span></span> |
| <span data-ttu-id="9427d-228">切り取り</span><span class="sxs-lookup"><span data-stu-id="9427d-228">Cut</span></span> | <span data-ttu-id="9427d-229">テキスト コントロールがないと、読み取り専用とテキストが選択されます。</span><span class="sxs-lookup"><span data-stu-id="9427d-229">when the text control is not read-only and text is selected.</span></span> |
| <span data-ttu-id="9427d-230">コピー</span><span class="sxs-lookup"><span data-stu-id="9427d-230">Copy</span></span> | <span data-ttu-id="9427d-231">テキストを選択するとします。</span><span class="sxs-lookup"><span data-stu-id="9427d-231">when text is selected.</span></span> |
| <span data-ttu-id="9427d-232">Paste</span><span class="sxs-lookup"><span data-stu-id="9427d-232">Paste</span></span> | <span data-ttu-id="9427d-233">テキスト コントロールは読み取り専用ではないと、クリップボードがコンテンツ。</span><span class="sxs-lookup"><span data-stu-id="9427d-233">when the text control is not read-only and the clipboard has content.</span></span> |
| <span data-ttu-id="9427d-234">元に戻す</span><span class="sxs-lookup"><span data-stu-id="9427d-234">Undo</span></span> | <span data-ttu-id="9427d-235">元に戻すことができるアクションがある場合。</span><span class="sxs-lookup"><span data-stu-id="9427d-235">when there is an action that can be undone.</span></span> |
| <span data-ttu-id="9427d-236">すべて選択</span><span class="sxs-lookup"><span data-stu-id="9427d-236">Select all</span></span> | <span data-ttu-id="9427d-237">ときにテキストを選択することができます。</span><span class="sxs-lookup"><span data-stu-id="9427d-237">when text can be selected.</span></span> |

### <a name="custom-text-command-bar-flyouts"></a><span data-ttu-id="9427d-238">カスタム テキスト コマンド バーのフライアウト</span><span class="sxs-lookup"><span data-stu-id="9427d-238">Custom text command bar flyouts</span></span>

<span data-ttu-id="9427d-239">TextCommandBarFlyout はカスタマイズすることはできませんし、各テキスト コントロールによって自動的に管理されています。</span><span class="sxs-lookup"><span data-stu-id="9427d-239">TextCommandBarFlyout can't be customized, and is managed automatically by each text control.</span></span> <span data-ttu-id="9427d-240">ただし、カスタム コマンドを使用して既定 TextCommandBarFlyout を置き換えることができます。</span><span class="sxs-lookup"><span data-stu-id="9427d-240">However, you can replace the default TextCommandBarFlyout with custom commands.</span></span>

- <span data-ttu-id="9427d-241">既定のテキストの選択時に表示される TextCommandBarFlyout を置換するカスタム CommandBarFlyout (またはその他のフライアウト型) を作成およびに割り当てる、 **SelectionFlyout**プロパティ。</span><span class="sxs-lookup"><span data-stu-id="9427d-241">To replace the default TextCommandBarFlyout that's shown on text selection, you can create a custom CommandBarFlyout (or other flyout type) and assign it to the **SelectionFlyout** property.</span></span> <span data-ttu-id="9427d-242">SelectionFlyout に設定する場合**null**、選択項目のコマンドは表示されません。</span><span class="sxs-lookup"><span data-stu-id="9427d-242">If you set SelectionFlyout to **null**, no commands are shown on selection.</span></span>
- <span data-ttu-id="9427d-243">既定のコンテキスト メニューとして表示される TextCommandBarFlyout を置換するにカスタム CommandBarFlyout (またはその他のフライアウト型) を割り当てる、 **ContextFlyout**テキスト コントロールのプロパティ。</span><span class="sxs-lookup"><span data-stu-id="9427d-243">To replace the default TextCommandBarFlyout that's shown as the context menu, assign a custom CommandBarFlyout (or other flyout type) to the **ContextFlyout** property on a text control.</span></span> <span data-ttu-id="9427d-244">ContextFlyout に設定する場合**null**、表示されるメニュー フライアウト、TextCommandBarFlyout ではなく、テキストの以前のバージョン コントロールが示すようにします。</span><span class="sxs-lookup"><span data-stu-id="9427d-244">If you set ContextFlyout to **null**, the menu flyout shown in previous versions of the text control is shown instead of the TextCommandBarFlyout.</span></span>

## <a name="get-the-sample-code"></a><span data-ttu-id="9427d-245">サンプル コードを入手する</span><span class="sxs-lookup"><span data-stu-id="9427d-245">Get the sample code</span></span>

- <span data-ttu-id="9427d-246">[XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Xaml-Controls-Gallery) - インタラクティブな形で XAML コントロールのすべてを参照できます。</span><span class="sxs-lookup"><span data-stu-id="9427d-246">[XAML Controls Gallery sample](https://github.com/Microsoft/Xaml-Controls-Gallery) - See all the XAML controls in an interactive format.</span></span>
- [<span data-ttu-id="9427d-247">コマンド実行の XAML サンプル</span><span class="sxs-lookup"><span data-stu-id="9427d-247">XAML Commanding sample</span></span>](https://go.microsoft.com/fwlink/p/?LinkId=620019)

## <a name="related-articles"></a><span data-ttu-id="9427d-248">関連記事</span><span class="sxs-lookup"><span data-stu-id="9427d-248">Related articles</span></span>

- [<span data-ttu-id="9427d-249">UWP アプリのコマンド設計の基本</span><span class="sxs-lookup"><span data-stu-id="9427d-249">Command design basics for UWP apps</span></span>](../basics/commanding-basics.md)
- [<span data-ttu-id="9427d-250">コマンド バー クラス</span><span class="sxs-lookup"><span data-stu-id="9427d-250">CommandBar class</span></span>](https://msdn.microsoft.com/library/windows/apps/dn279427)
