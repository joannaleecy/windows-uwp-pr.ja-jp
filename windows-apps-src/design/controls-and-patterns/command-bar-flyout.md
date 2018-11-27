---
Description: Command bar flyouts give users inline access to your app's most common tasks.
title: コマンド バーのポップアップ
label: Command bar flyout
template: detail.hbs
ms.date: 10/2/2018
ms.topic: article
keywords: Windows 10, UWP
pm-contact: abarlow
design-contact: ksulliv
dev-contact: llongley
doc-status: Draft
ms.localizationpriority: medium
ms.custom: RS5
ms.openlocfilehash: ef472863550b7d17836dc7f47e2fe789c9ca7fbc
ms.sourcegitcommit: 681c70f964210ab49ac5d06357ae96505bb78741
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/26/2018
ms.locfileid: "7709883"
---
# <a name="command-bar-flyout"></a><span data-ttu-id="168ef-103">コマンド バーのポップアップ</span><span class="sxs-lookup"><span data-stu-id="168ef-103">Command bar flyout</span></span>

<span data-ttu-id="168ef-104">コマンド バーのポップアップでは、UI のキャンバス上の要素に関連する浮動ツールバーでのコマンドを表示して一般的なタスクに簡単にアクセスをユーザーに提供できます。</span><span class="sxs-lookup"><span data-stu-id="168ef-104">The command bar flyout lets you provide users with easy access to common tasks by showing commands in a floating toolbar related to an element on your UI canvas.</span></span>

![展開されたテキスト コマンド バーのポップアップ](images/command-bar-flyout-header.png)

> <span data-ttu-id="168ef-106">CommandBarFlyout には、Windows 10 version 1809 ([SDK 17763](https://developer.microsoft.com/windows/downloads/windows-10-sdk)) が必要ですか、後で、または[Windows UI のライブラリ](https://docs.microsoft.com/uwp/toolkits/winui/)。</span><span class="sxs-lookup"><span data-stu-id="168ef-106">CommandBarFlyout requires Windows 10, version 1809 ([SDK 17763](https://developer.microsoft.com/windows/downloads/windows-10-sdk)) or later, or the [Windows UI Library](https://docs.microsoft.com/uwp/toolkits/winui/).</span></span>

> - <span data-ttu-id="168ef-107">**プラットフォーム Api**: [CommandBarFlyout クラス](/uwp/api/windows.ui.xaml.controls.commandbarflyout)、 [TextCommandBarFlyout クラス](/uwp/api/windows.ui.xaml.controls.textcommandbarflyout)、 [AppBarButton クラス](/uwp/api/windows.ui.xaml.controls.appbarbutton)、 [AppBarToggleButton クラス](/uwp/api/windows.ui.xaml.controls.appbartogglebutton)、 [AppBarSeparator クラス](/uwp/api/windows.ui.xaml.controls.appbarseparator)</span><span class="sxs-lookup"><span data-stu-id="168ef-107">**Platform APIs**: [CommandBarFlyout class](/uwp/api/windows.ui.xaml.controls.commandbarflyout), [TextCommandBarFlyout class](/uwp/api/windows.ui.xaml.controls.textcommandbarflyout), [AppBarButton class](/uwp/api/windows.ui.xaml.controls.appbarbutton), [AppBarToggleButton class](/uwp/api/windows.ui.xaml.controls.appbartogglebutton), [AppBarSeparator class](/uwp/api/windows.ui.xaml.controls.appbarseparator)</span></span>
>- <span data-ttu-id="168ef-108">**Windows UI ライブラリ Api**: [CommandBarFlyout クラス](/uwp/api/microsoft.ui.xaml.controls.commandbarflyout)、 [TextCommandBarFlyout クラス](/uwp/api/microsoft.ui.xaml.controls.textcommandbarflyout)</span><span class="sxs-lookup"><span data-stu-id="168ef-108">**Windows UI Library APIs**: [CommandBarFlyout class](/uwp/api/microsoft.ui.xaml.controls.commandbarflyout), [TextCommandBarFlyout class](/uwp/api/microsoft.ui.xaml.controls.textcommandbarflyout)</span></span>

<span data-ttu-id="168ef-109">[CommandBar](app-bars.md)などは CommandBarFlyout に追加のコマンドを使用できます**PrimaryCommands**と**SecondaryCommands**の特徴があります。</span><span class="sxs-lookup"><span data-stu-id="168ef-109">Like [CommandBar](app-bars.md), CommandBarFlyout has **PrimaryCommands** and **SecondaryCommands** properties you can use to add commands.</span></span> <span data-ttu-id="168ef-110">コレクション、またはその両方でコマンドを配置することができます。</span><span class="sxs-lookup"><span data-stu-id="168ef-110">You can place commands in either collection, or both.</span></span> <span data-ttu-id="168ef-111">プライマリおよびセカンダリ コマンドが表示されるタイミングと方法は、表示モードによって異なります。</span><span class="sxs-lookup"><span data-stu-id="168ef-111">When and how the primary and secondary commands are displayed depends on the display mode.</span></span>

<span data-ttu-id="168ef-112">コマンド バーのポップアップが 2 つの表示モード:*折りたたまれている*し、*展開*します。</span><span class="sxs-lookup"><span data-stu-id="168ef-112">The command bar flyout has two display modes: *collapsed* and *expanded*.</span></span>

- <span data-ttu-id="168ef-113">折りたたまれたモードでは、プライマリ コマンドのみが表示されます。</span><span class="sxs-lookup"><span data-stu-id="168ef-113">In the collapsed mode, only the primary commands are shown.</span></span> <span data-ttu-id="168ef-114">コマンド バーのポップアップがプライマリとセカンダリ コマンド、省略記号で表される「詳細」ボタン \ [•] が表示されます。</span><span class="sxs-lookup"><span data-stu-id="168ef-114">If your command bar flyout has both primary and secondary commands, a "see more" button, which is represented by an ellipsis \[•••\], is displayed.</span></span> <span data-ttu-id="168ef-115">これにより、ユーザーの拡張モードに移行して、セカンダリ コマンドへのアクセスを取得できます。</span><span class="sxs-lookup"><span data-stu-id="168ef-115">This lets the user get access to the secondary commands by transitioning to expanded mode.</span></span>
- <span data-ttu-id="168ef-116">拡張のモードでは、プライマリおよびセカンダリ コマンドの両方が表示されます。</span><span class="sxs-lookup"><span data-stu-id="168ef-116">In the expanded mode, both the primary and secondary commands are shown.</span></span> <span data-ttu-id="168ef-117">(、コントロールにセカンダリ項目のみがある場合は表示 MenuFlyout コントロールと同様の方法で)。</span><span class="sxs-lookup"><span data-stu-id="168ef-117">(If the control has only secondary items, they are shown in a way similar to the MenuFlyout control.)</span></span>

## <a name="is-this-the-right-control"></a><span data-ttu-id="168ef-118">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="168ef-118">Is this the right control?</span></span>

<span data-ttu-id="168ef-119">メニュー項目は、アプリのキャンバス上の要素のコンテキストでボタンなど、ユーザーにコマンドのコレクションを表示するのにには、CommandBarFlyout コントロールを使用します。</span><span class="sxs-lookup"><span data-stu-id="168ef-119">Use the CommandBarFlyout control to show a collection of commands to the user, such as buttons and menu items, in the context of an element on the app canvas.</span></span>

<span data-ttu-id="168ef-120">TextCommandBarFlyout では、TextBox、TextBlock、RichEditBox、RichTextBlock、および PasswordBox のコントロールでテキスト コマンドが表示されます。</span><span class="sxs-lookup"><span data-stu-id="168ef-120">The TextCommandBarFlyout displays text commands in TextBox, TextBlock, RichEditBox, RichTextBlock, and PasswordBox controls.</span></span> <span data-ttu-id="168ef-121">コマンドは現在のテキストの選択に自動的に適切に構成します。</span><span class="sxs-lookup"><span data-stu-id="168ef-121">The commands are automatically configured appropriately to the current text selection.</span></span> <span data-ttu-id="168ef-122">テキスト コントロールの既定のテキストのコマンドを置換するのに、CommandBarFlyout を使用します。</span><span class="sxs-lookup"><span data-stu-id="168ef-122">Use a CommandBarFlyout to replace the default text commands on text controls.</span></span>

<span data-ttu-id="168ef-123">コンテキストを表示するには、リスト項目でのコマンドは[コマンドのコレクションとリストの実行コンテキスト](collection-commanding.md)のガイダンスに従います。</span><span class="sxs-lookup"><span data-stu-id="168ef-123">To show contextual commands on list items follow the guidance in [Contextual commanding for collections and lists](collection-commanding.md).</span></span>

### <a name="commandbarflyout-vs-menuflyout"></a><span data-ttu-id="168ef-124">CommandBarFlyout vs MenuFlyout</span><span class="sxs-lookup"><span data-stu-id="168ef-124">CommandBarFlyout vs MenuFlyout</span></span>

<span data-ttu-id="168ef-125">コンテキスト メニューにコマンドを表示するには、CommandBarFlyout または MenuFlyout を使用できます。</span><span class="sxs-lookup"><span data-stu-id="168ef-125">To show commands in a context menu, you can use CommandBarFlyout or MenuFlyout.</span></span> <span data-ttu-id="168ef-126">MenuFlyout よりも多くの機能を提供するため CommandBarFlyout をお勧めします。</span><span class="sxs-lookup"><span data-stu-id="168ef-126">We recommend CommandBarFlyout because it provides more functionality than MenuFlyout.</span></span> <span data-ttu-id="168ef-127">動作を取得して、MenuFlyout の検索やプライマリおよびセカンダリの両方のコマンドで完全なコマンド バーのポップアップを使用するセカンダリ コマンドのみを使った CommandBarFlyout を使用することができます。</span><span class="sxs-lookup"><span data-stu-id="168ef-127">You can use CommandBarFlyout with only secondary commands to get the behavior and look of a MenuFlyout, or use the full command bar flyout with both primary and secondary commands.</span></span>

> <span data-ttu-id="168ef-128">関連する情報は、[コマンド バーを使う](app-bars.md)[メニューとコンテキスト メニュー](menus.md)は、[ポップアップ](../controls-and-patterns/dialogs-and-flyouts/flyouts.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="168ef-128">For related info, see [Flyouts](../controls-and-patterns/dialogs-and-flyouts/flyouts.md), [Menus and context menus](menus.md), and [Command bars](app-bars.md).</span></span>

## <a name="examples"></a><span data-ttu-id="168ef-129">例</span><span class="sxs-lookup"><span data-stu-id="168ef-129">Examples</span></span>

<table>
<th align="left"><span data-ttu-id="168ef-130">XAML コントロール ギャラリー</span><span class="sxs-lookup"><span data-stu-id="168ef-130">XAML Controls Gallery</span></span><th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><span data-ttu-id="168ef-131"><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong>アプリをインストールした場合ここをクリックして<a href="xamlcontrolsgallery:/item/CommandBarFlyout">アプリを開き、CommandBarFlyout の動作を参照してください</a>。</span><span class="sxs-lookup"><span data-stu-id="168ef-131">If you have the <strong style="font-weight: semi-bold">XAML Controls Gallery</strong> app installed, click here to <a href="xamlcontrolsgallery:/item/CommandBarFlyout">open the app and see the CommandBarFlyout in action</a>.</span></span></p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT"><span data-ttu-id="168ef-132">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</span><span class="sxs-lookup"><span data-stu-id="168ef-132">Get the XAML Controls Gallery app (Microsoft Store)</span></span></a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics"><span data-ttu-id="168ef-133">ソース コード (GitHub) を入手する</span><span class="sxs-lookup"><span data-stu-id="168ef-133">Get the source code (GitHub)</span></span></a></li>
    </ul>
</td>
</tr>
</table>

## <a name="proactive-vs-reactive-invocation"></a><span data-ttu-id="168ef-134">事後対応型の呼び出しプロアクティブ</span><span class="sxs-lookup"><span data-stu-id="168ef-134">Proactive vs. reactive invocation</span></span>

<span data-ttu-id="168ef-135">ポップアップや、UI のキャンバス上の要素に関連付けられているメニューを呼び出すに 2 つの方法は通常:_呼び出しプロアクティブ_および_事後対応型の呼び出しを実行_します。</span><span class="sxs-lookup"><span data-stu-id="168ef-135">There are typically two ways to invoke a flyout or menu that's associated with an element on your UI canvas: _proactive invocation_ and _reactive invocation_.</span></span>

<span data-ttu-id="168ef-136">コマンドは事前対応型の呼び出しでは、ユーザーがコマンドに関連付けられている項目を操作する自動的に表示します。</span><span class="sxs-lookup"><span data-stu-id="168ef-136">In proactive invocation, commands appear automatically when the user interacts with the item that the commands are associated with.</span></span> <span data-ttu-id="168ef-137">たとえば、テキストの書式設定コマンド可能性がありますがポップアップ、ユーザーがテキスト ボックスのテキストを選択します。</span><span class="sxs-lookup"><span data-stu-id="168ef-137">For example, text formatting commands might pop up when the user selects text in a text box.</span></span> <span data-ttu-id="168ef-138">この例では、コマンド バーのポップアップでは、フォーカスは実行されません。</span><span class="sxs-lookup"><span data-stu-id="168ef-138">In this case, the command bar flyout does not take focus.</span></span> <span data-ttu-id="168ef-139">代わりに、適切なコマンドで、ユーザーが操作の項目に近いを表示します。</span><span class="sxs-lookup"><span data-stu-id="168ef-139">Instead, it presents relevant commands close to the item the user is interacting with.</span></span> <span data-ttu-id="168ef-140">場合は、ユーザーは、コマンドを操作しない、それらが閉じられます。</span><span class="sxs-lookup"><span data-stu-id="168ef-140">If the user doesn't interact with the commands, they are dismissed.</span></span>

<span data-ttu-id="168ef-141">事後対応型の呼び出しでコマンドは表示、明示的なユーザー操作への応答で、コマンドを要求するにはたとえば、右クリックします。</span><span class="sxs-lookup"><span data-stu-id="168ef-141">In reactive invocation, commands are shown in response to an explicit user action to request the commands; for example, a right-click.</span></span> <span data-ttu-id="168ef-142">これは、[コンテキスト メニュー](menus.md)の従来の概念に対応します。</span><span class="sxs-lookup"><span data-stu-id="168ef-142">This corresponds to the traditional concept of a [context menu](menus.md).</span></span>

<span data-ttu-id="168ef-143">により、または 2 つの組み合わせでも CommandBarFlyout を使用することができます。</span><span class="sxs-lookup"><span data-stu-id="168ef-143">You can use the CommandBarFlyout in either way, or even a mixture of the two.</span></span>

## <a name="create-a-command-bar-flyout"></a><span data-ttu-id="168ef-144">コマンド バーのポップアップを作成します。</span><span class="sxs-lookup"><span data-stu-id="168ef-144">Create a command bar flyout</span></span>

<span data-ttu-id="168ef-145">この例では、コマンド バーのポップアップを作成し、事前と事後対応的に使用する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="168ef-145">This example shows how to create a command bar flyout and use it both proactively and reactively.</span></span> <span data-ttu-id="168ef-146">イメージをタップすると、ポップアップが折りたたまれているモードで表示されます。</span><span class="sxs-lookup"><span data-stu-id="168ef-146">When the image is tapped, the flyout is shown in its collapsed mode.</span></span> <span data-ttu-id="168ef-147">表示されるとき、コンテキスト メニューとして、その拡張モードで、ポップアップが表示されます。</span><span class="sxs-lookup"><span data-stu-id="168ef-147">When shown as a context menu, the flyout is shown in its expanded mode.</span></span> <span data-ttu-id="168ef-148">どちらの場合、ユーザーに展開またはに開いた後、ポップアップを折りたたむできます。</span><span class="sxs-lookup"><span data-stu-id="168ef-148">In either case, the user can expand or collapse the flyout after it's opened.</span></span>

![折りたたまれたコマンド バーのポップアップの例](images/command-bar-flyout-img-collapsed.png)

> _<span data-ttu-id="168ef-150">折りたたまれたコマンド バーのポップアップ</span><span class="sxs-lookup"><span data-stu-id="168ef-150">A collapsed command bar flyout</span></span>_

![展開されたコマンド バーのポップアップの例](images/command-bar-flyout-img-expanded.png)

> _<span data-ttu-id="168ef-152">展開されたコマンド バーのポップアップ</span><span class="sxs-lookup"><span data-stu-id="168ef-152">An expanded command bar flyout</span></span>_

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

### <a name="show-commands-proactively"></a><span data-ttu-id="168ef-153">事前にコマンドを表示します。</span><span class="sxs-lookup"><span data-stu-id="168ef-153">Show commands proactively</span></span>

<span data-ttu-id="168ef-154">事前にコンテキスト コマンドを表示すると、プライマリ コマンドのみする必要があります (コマンド バーのポップアップを縮小する必要があります) を既定で表示されます。</span><span class="sxs-lookup"><span data-stu-id="168ef-154">When you show contextual commands proactively, only the primary commands should be shown by default (the command bar flyout should be collapsed).</span></span> <span data-ttu-id="168ef-155">プライマリ コマンドのコレクション、およびされる従来のコンテキスト メニューで、セカンダリ コマンドのコレクションに追加のコマンドで最も重要なコマンドを配置します。</span><span class="sxs-lookup"><span data-stu-id="168ef-155">Place the most important commands in the primary commands collection, and additional commands that would traditionally go in a context menu into the secondary commands collection.</span></span>

<span data-ttu-id="168ef-156">コマンドをプロアクティブに表示するには、通常コマンド バーのポップアップを表示する[] をクリックして](/uwp/api/windows.ui.xaml.controls.primitives.buttonbase.click)または[Tapped](/uwp/api/windows.ui.xaml.uielement.tapped)イベントを処理します。</span><span class="sxs-lookup"><span data-stu-id="168ef-156">To proactively show commands, you typically handle the [Click](/uwp/api/windows.ui.xaml.controls.primitives.buttonbase.click) or [Tapped](/uwp/api/windows.ui.xaml.uielement.tapped) event to show the command bar flyout.</span></span> <span data-ttu-id="168ef-157">**一時的な**または**TransientWithDismissOnPointerMoveAway**折りたたまれているモードでフォーカスを移動することがなく、ポップアップを開くには、ポップアップの[ShowMode](/uwp/api/windows.ui.xaml.controls.primitives.flyoutbase.showmode)を設定します。</span><span class="sxs-lookup"><span data-stu-id="168ef-157">Set the flyout's [ShowMode](/uwp/api/windows.ui.xaml.controls.primitives.flyoutbase.showmode) to **Transient** or **TransientWithDismissOnPointerMoveAway** to open the flyout in its collapsed mode without taking focus.</span></span>

<span data-ttu-id="168ef-158">以降、Windows 10 Insider Preview では、テキスト コントロールには、 **SelectionFlyout**プロパティが設定されています。</span><span class="sxs-lookup"><span data-stu-id="168ef-158">Starting in the Windows 10 Insider Preview, text controls have a **SelectionFlyout** property.</span></span> <span data-ttu-id="168ef-159">ポップアップをこのプロパティに割り当てるとテキストが選択されているときに自動的に表示されます。</span><span class="sxs-lookup"><span data-stu-id="168ef-159">When you assign a flyout to this property, it is automatically shown when text is selected.</span></span>

### <a name="show-commands-reactively"></a><span data-ttu-id="168ef-160">事後対応的にコマンドを表示します。</span><span class="sxs-lookup"><span data-stu-id="168ef-160">Show commands reactively</span></span>

<span data-ttu-id="168ef-161">コンテキスト コマンドを事後対応的、コンテキスト メニューとして表示する場合は、既定では (コマンド バーのポップアップを展開する必要があります)、セカンダリ コマンドが表示されます。</span><span class="sxs-lookup"><span data-stu-id="168ef-161">When you show contextual commands reactively, as a context menu, the secondary commands are shown by default (the command bar flyout should be expanded).</span></span> <span data-ttu-id="168ef-162">この例では、コマンド バーのポップアップには、プライマリおよびセカンダリの両方のコマンド、またはセカンダリ コマンドのみがあります。</span><span class="sxs-lookup"><span data-stu-id="168ef-162">In this case, the command bar flyout might have both primary and secondary commands, or secondary commands only.</span></span>

<span data-ttu-id="168ef-163">コンテキスト メニューにコマンドを表示するには、通常に UI 要素の[ContextFlyout](/uwp/api/windows.ui.xaml.uielement.contextflyout)プロパティに、ポップアップを割り当てます。</span><span class="sxs-lookup"><span data-stu-id="168ef-163">To show commands in a context menu, you typically assign the flyout to the [ContextFlyout](/uwp/api/windows.ui.xaml.uielement.contextflyout) property of a UI element.</span></span> <span data-ttu-id="168ef-164">これによりは、要素によって処理されますが、ポップアップを開くと、特に何もする必要はありません。</span><span class="sxs-lookup"><span data-stu-id="168ef-164">This way, opening the flyout is handled by the element, and you don't need to do anything more.</span></span>

<span data-ttu-id="168ef-165">(たとえば、 [RightTapped](/uwp/api/windows.ui.xaml.uielement.righttapped)イベント) を自分で、ポップアップを示すを処理する場合は、**標準**の拡張モードで、ポップアップを開き、フォーカスを設定するポップアップの[ShowMode](/uwp/api/windows.ui.xaml.controls.primitives.flyoutbase.showmode)を設定します。</span><span class="sxs-lookup"><span data-stu-id="168ef-165">If you handle showing the flyout yourself (for example, on a [RightTapped](/uwp/api/windows.ui.xaml.uielement.righttapped) event), set the flyout's [ShowMode](/uwp/api/windows.ui.xaml.controls.primitives.flyoutbase.showmode) to **Standard** to open the flyout in its expanded mode and give it focus.</span></span>

> [!TIP]
> <span data-ttu-id="168ef-166">ポップアップの配置を制御する方法と、ポップアップを表示するときのオプションについて詳しくは、[ポップアップ](../controls-and-patterns/dialogs-and-flyouts/flyouts.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="168ef-166">For more info about options when showing a flyout and how to control placement of the flyout, see [Flyouts](../controls-and-patterns/dialogs-and-flyouts/flyouts.md).</span></span>

## <a name="commands-and-content"></a><span data-ttu-id="168ef-167">コマンドとコンテンツ</span><span class="sxs-lookup"><span data-stu-id="168ef-167">Commands and content</span></span>

<span data-ttu-id="168ef-168">CommandBarFlyout コントロールは、コマンドとコンテンツの追加に使用できる 2 つのプロパティを持つ: [PrimaryCommands](/uwp/api/windows.ui.xaml.controls.commandbarflyout.primarycommands)と[SecondaryCommands](/uwp/api/windows.ui.xaml.controls.commandbarflyout.secondarycommands)にします。</span><span class="sxs-lookup"><span data-stu-id="168ef-168">The CommandBarFlyout control has 2 properties you can use to add commands and content: [PrimaryCommands](/uwp/api/windows.ui.xaml.controls.commandbarflyout.primarycommands) and [SecondaryCommands](/uwp/api/windows.ui.xaml.controls.commandbarflyout.secondarycommands).</span></span>

<span data-ttu-id="168ef-169">既定では、コマンド バーの項目は **PrimaryCommands** コレクションに追加されます。</span><span class="sxs-lookup"><span data-stu-id="168ef-169">By default, command bar items are added to the **PrimaryCommands** collection.</span></span> <span data-ttu-id="168ef-170">これらのコマンドは、コマンド バーは表示され、折りたたまれていると、展開時の両方のモードで表示されます。</span><span class="sxs-lookup"><span data-stu-id="168ef-170">These commands are shown in the command bar and are visible in both the collapsed and expanded modes.</span></span> <span data-ttu-id="168ef-171">CommandBar とは異なり、プライマリ コマンドは自動的にセカンダリ コマンドにオーバーフローではないと切り詰められている可能性があります。</span><span class="sxs-lookup"><span data-stu-id="168ef-171">Unlike CommandBar, primary commands do not automatically overflow to the secondary commands and might be truncated.</span></span>

<span data-ttu-id="168ef-172">コマンドは**SecondaryCommands**コレクションに追加することもできます。</span><span class="sxs-lookup"><span data-stu-id="168ef-172">You can also add commands to the **SecondaryCommands** collection.</span></span> <span data-ttu-id="168ef-173">セカンダリ コマンドは、コントロールのメニューの部分では表示され、展開モードでのみ表示されます。</span><span class="sxs-lookup"><span data-stu-id="168ef-173">Secondary commands are shown in the menu portion of the control and are visible only in the expanded mode.</span></span>

### <a name="app-bar-buttons"></a><span data-ttu-id="168ef-174">アプリ バーのボタン</span><span class="sxs-lookup"><span data-stu-id="168ef-174">App bar buttons</span></span>

<span data-ttu-id="168ef-175">PrimaryCommands と SecondaryCommands には、 [AppBarButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbarbutton.aspx)、 [AppBarToggleButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbartogglebutton.aspx)、および[AppBarSeparator](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbarseparator.aspx)コントロールを直接設定できます。</span><span class="sxs-lookup"><span data-stu-id="168ef-175">You can populate the PrimaryCommands and SecondaryCommands directly with [AppBarButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbarbutton.aspx), [AppBarToggleButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbartogglebutton.aspx), and [AppBarSeparator](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbarseparator.aspx) controls.</span></span>

<span data-ttu-id="168ef-176">アプリ バーのボタン コントロールは、アイコンとテキスト ラベルによって特徴付けられます。</span><span class="sxs-lookup"><span data-stu-id="168ef-176">The app bar button controls are characterized by an icon and text label.</span></span> <span data-ttu-id="168ef-177">これらのコントロールは、コマンド バーで使用するために最適化されていて、コマンド バーやオーバーフロー メニューにコントロールを表示するかどうかに応じて外観が変化します。</span><span class="sxs-lookup"><span data-stu-id="168ef-177">These controls are optimized for use in a command bar, and their appearance changes depending on whether the control is shown in the command bar or the overflow menu.</span></span>

- <span data-ttu-id="168ef-178">プライマリ コマンドとして使われるアプリ バーのボタンは、アイコンのみを含むコマンド バーに表示されます。テキスト ラベルは表示されません。</span><span class="sxs-lookup"><span data-stu-id="168ef-178">App bar buttons used as primary commands are shown in the command bar with only their icon; the text label is not shown.</span></span> <span data-ttu-id="168ef-179">次のように、コマンドの説明のテキストを表示するヒントを使用することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="168ef-179">We recommend that you use a tooltip to show a text description of the command, as shown here.</span></span>
    ```xaml
    <AppBarButton Icon="Copy" ToolTipService.ToolTip="Copy"/>
    ```
- <span data-ttu-id="168ef-180">メニューで、ラベルとアイコンが表示されるには、セカンダリ コマンドとして使われるアプリ バーのボタンが表示されます。</span><span class="sxs-lookup"><span data-stu-id="168ef-180">App bar buttons used as secondary commands are shown in the menu, with both the label and icon visible.</span></span>

### <a name="other-content"></a><span data-ttu-id="168ef-181">その他のコンテンツ</span><span class="sxs-lookup"><span data-stu-id="168ef-181">Other content</span></span>

<span data-ttu-id="168ef-182">コマンド バーのポップアップを他のコントロールを追加するには、AppBarElementContainer でラップします。</span><span class="sxs-lookup"><span data-stu-id="168ef-182">You can add other controls to a command bar flyout by wrapping them in an AppBarElementContainer.</span></span> <span data-ttu-id="168ef-183">これにより[DropDownButton]() [SplitButton]()などのコントロールを追加したりより複雑な UI を作成するために[StackPanel]()などのコンテナーを追加できます。</span><span class="sxs-lookup"><span data-stu-id="168ef-183">This lets you add controls like [DropDownButton]() or [SplitButton](), or add containers like [StackPanel]() to create more complex UI.</span></span>

<span data-ttu-id="168ef-184">コマンド バーのポップアップのプライマリまたはセカンダリ コマンドのコレクションに追加するために、要素は[ICommandBarElement](/uwp/api/windows.ui.xaml.controls.icommandbarelement)インターフェイスを実装する必要があります。</span><span class="sxs-lookup"><span data-stu-id="168ef-184">In order to be added to the primary or secondary command collections of a command bar flyout, an element must implement the [ICommandBarElement](/uwp/api/windows.ui.xaml.controls.icommandbarelement) interface.</span></span> <span data-ttu-id="168ef-185">AppBarElementContainer は、インターフェイス自体を実装していない場合でも、コマンド バーに要素を追加できるように、このインターフェイスを実装するラッパーです。</span><span class="sxs-lookup"><span data-stu-id="168ef-185">AppBarElementContainer is a wrapper that implements this interface so you can add an element to a command bar even if it doesn't implement the interface itself.</span></span>

<span data-ttu-id="168ef-186">ここでは、コマンド バーのポップアップに余分な要素を追加する、AppBarElementContainer が使用されます。</span><span class="sxs-lookup"><span data-stu-id="168ef-186">Here, an AppBarElementContainer is used to add extra elements to a command bar flyout.</span></span> <span data-ttu-id="168ef-187">SplitButton は、色の選択を許可するプライマリ コマンドに追加されます。</span><span class="sxs-lookup"><span data-stu-id="168ef-187">A SplitButton is added to the primary commands to allow selection of colors.</span></span> <span data-ttu-id="168ef-188">StackPanel は、ズーム コントロールのより複雑なレイアウトを許可するセカンダリ コマンドに追加されます。</span><span class="sxs-lookup"><span data-stu-id="168ef-188">A StackPanel is added to the secondary commands to allow a more complex layout for zoom controls.</span></span>

> [!TIP]
> <span data-ttu-id="168ef-189">既定では、アプリのキャンバス向けに設計された要素はないように見えます適切なコマンド バーにします。</span><span class="sxs-lookup"><span data-stu-id="168ef-189">By default, elements designed for the app canvas might not look right in a command bar.</span></span> <span data-ttu-id="168ef-190">AppBarElementContainer を使用して、要素を追加する場合は、他のコマンド バーの要素に一致する要素を行う必要がいくつかの手順があります。</span><span class="sxs-lookup"><span data-stu-id="168ef-190">When you add an element using AppBarElementContainer, there are some steps you should take to make the element match other command bar elements:</span></span>
>
> - <span data-ttu-id="168ef-191">要素の背景と境界線アプリ バーのボタンに一致する[軽量なスタイル設定](/design/controls-and-patterns/xaml-styles#lightweight-styling)の既定のブラシを上書きします。</span><span class="sxs-lookup"><span data-stu-id="168ef-191">Override the default brushes with [lightweight styling](/design/controls-and-patterns/xaml-styles#lightweight-styling) to make the element's background and border match the app bar buttons.</span></span>
> - <span data-ttu-id="168ef-192">要素の位置とサイズを調整します。</span><span class="sxs-lookup"><span data-stu-id="168ef-192">Adjust the size and position of the element.</span></span>
> - <span data-ttu-id="168ef-193">上部 16 ピクセルの高さ、幅の Viewbox でアイコンをラップします。</span><span class="sxs-lookup"><span data-stu-id="168ef-193">Wrap icons in a Viewbox with a Width and Height of 16px.</span></span>

> [!NOTE]
> <span data-ttu-id="168ef-194">この例では、表示されるコマンドのいずれかが実装していないのみ、コマンド バーのポップアップ UI を示しています。</span><span class="sxs-lookup"><span data-stu-id="168ef-194">This example shows only the command bar flyout UI, it does not implement any of the commands that are shown.</span></span> <span data-ttu-id="168ef-195">コマンドの実装について詳しくは、[ボタン](buttons.md)や[コマンド設計の基本](../basics/commanding-basics.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="168ef-195">For more info about implementing the commands, see [Buttons](buttons.md) and [Command design basics](../basics/commanding-basics.md).</span></span>

![分割のボタンを含むコマンド バーのポップアップ](images/command-bar-flyout-split-button.png)

> _<span data-ttu-id="168ef-197">Open の SplitButton と折りたたまれているコマンド バーのポップアップ</span><span class="sxs-lookup"><span data-stu-id="168ef-197">A collapsed command bar flyout with an open SplitButton</span></span>_

![複雑な UI とコマンド バーのポップアップ](images/command-bar-flyout-custom-ui.png)

> _<span data-ttu-id="168ef-199">メニューにカスタム ズーム UI で展開されたコマンド バーのポップアップ</span><span class="sxs-lookup"><span data-stu-id="168ef-199">An expanded command bar flyout with custom zoom UI in the menu</span></span>_


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

## <a name="create-a-context-menu-with-secondary-commands-only"></a><span data-ttu-id="168ef-200">セカンダリ コマンドのみでコンテキスト メニューを作成します。</span><span class="sxs-lookup"><span data-stu-id="168ef-200">Create a context menu with secondary commands only</span></span>

<span data-ttu-id="168ef-201">[コンテキスト メニュー](menus.md)MenuFlyout の代わりとして、セカンダリ コマンドのみを使用して、CommandBarFlyout を使用できます。</span><span class="sxs-lookup"><span data-stu-id="168ef-201">You can use a CommandBarFlyout with only secondary commands as a [context menu](menus.md), in place of a MenuFlyout.</span></span>

![セカンダリ コマンドのみを含むコマンド バーのポップアップ](images/command-bar-flyout-context-menu.png)

> _<span data-ttu-id="168ef-203">コンテキスト メニューとしてコマンド バーのポップアップ</span><span class="sxs-lookup"><span data-stu-id="168ef-203">Command bar flyout as a context menu</span></span>_

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

<span data-ttu-id="168ef-204">標準的なメニューを作成するのに、DropDownButton で、CommandBarFlyout を使用することもできます。</span><span class="sxs-lookup"><span data-stu-id="168ef-204">You can also use a CommandBarFlyout with a DropDownButton to create a standard menu.</span></span>

![ドロップダウン メニューのボタンとしてとコマンド バー ポップアップ](images/command-bar-flyout-dropdown.png)

> _<span data-ttu-id="168ef-206">コマンド バーのポップアップ メニュー ボタン ドロップダウン</span><span class="sxs-lookup"><span data-stu-id="168ef-206">A drop down button menu in a command bar flyout</span></span>_

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

## <a name="command-bar-flyouts-for-text-controls"></a><span data-ttu-id="168ef-207">テキスト コントロールのコマンド バーのポップアップ</span><span class="sxs-lookup"><span data-stu-id="168ef-207">Command bar flyouts for text controls</span></span>

<span data-ttu-id="168ef-208">[TextCommandBarFlyout](/uwp/api/microsoft.ui.xaml.controls.textcommandbarflyout)は、テキスト編集のコマンドを含む特殊なコマンド バーのポップアップです。</span><span class="sxs-lookup"><span data-stu-id="168ef-208">The [TextCommandBarFlyout](/uwp/api/microsoft.ui.xaml.controls.textcommandbarflyout) is a specialized command bar flyout that contains commands for editing text.</span></span> <span data-ttu-id="168ef-209">各テキスト コントロールは、コンテキスト メニュー (右クリック)、またはテキストが選択されているときに自動的に、TextCommandBarFlyout を示します。</span><span class="sxs-lookup"><span data-stu-id="168ef-209">Each text control shows the TextCommandBarFlyout automatically as a context menu (right-click), or when text is selected.</span></span> <span data-ttu-id="168ef-210">テキストのコマンド バーのポップアップは、適切なコマンドのみを表示するテキストの選択に適応します。</span><span class="sxs-lookup"><span data-stu-id="168ef-210">The text command bar flyout adapts to the text selection to only show relevant commands.</span></span>

![折りたたまれているテキスト コマンド バーのポップアップ](images/command-bar-flyout-text-selection.png)

> _<span data-ttu-id="168ef-212">テキストの選択でテキスト コマンド バーのポップアップ</span><span class="sxs-lookup"><span data-stu-id="168ef-212">A text command bar flyout on text selection</span></span>_

![展開されたテキスト コマンド バーのポップアップ](images/command-bar-flyout-text-full.png)

> _<span data-ttu-id="168ef-214">展開されたテキスト コマンド バーのポップアップ</span><span class="sxs-lookup"><span data-stu-id="168ef-214">An expanded text command bar flyout</span></span>_


### <a name="available-commands"></a><span data-ttu-id="168ef-215">利用可能なコマンド</span><span class="sxs-lookup"><span data-stu-id="168ef-215">Available commands</span></span>

<span data-ttu-id="168ef-216">表示されているときと、TextCommandBarFlyout に含まれているコマンドを次の表に示します。</span><span class="sxs-lookup"><span data-stu-id="168ef-216">This table shows the commands that are included in a TextCommandBarFlyout, and when they are shown.</span></span>

| <span data-ttu-id="168ef-217">コマンド</span><span class="sxs-lookup"><span data-stu-id="168ef-217">Command</span></span> | <span data-ttu-id="168ef-218">表示される.</span><span class="sxs-lookup"><span data-stu-id="168ef-218">Shown...</span></span> |
| ------- | -------- |
| <span data-ttu-id="168ef-219">Bold</span><span class="sxs-lookup"><span data-stu-id="168ef-219">Bold</span></span> | <span data-ttu-id="168ef-220">テキスト コントロールは読み取り専用 (RichEditBox のみ) ではありません。</span><span class="sxs-lookup"><span data-stu-id="168ef-220">when the text control is not read-only (RichEditBox only).</span></span> |
| <span data-ttu-id="168ef-221">Italic</span><span class="sxs-lookup"><span data-stu-id="168ef-221">Italic</span></span> | <span data-ttu-id="168ef-222">テキスト コントロールは読み取り専用 (RichEditBox のみ) ではありません。</span><span class="sxs-lookup"><span data-stu-id="168ef-222">when the text control is not read-only (RichEditBox only).</span></span> |
| <span data-ttu-id="168ef-223">Underline</span><span class="sxs-lookup"><span data-stu-id="168ef-223">Underline</span></span> | <span data-ttu-id="168ef-224">テキスト コントロールは読み取り専用 (RichEditBox のみ) ではありません。</span><span class="sxs-lookup"><span data-stu-id="168ef-224">when the text control is not read-only (RichEditBox only).</span></span> |
| <span data-ttu-id="168ef-225">校正</span><span class="sxs-lookup"><span data-stu-id="168ef-225">Proofing</span></span> | <span data-ttu-id="168ef-226">IsSpellCheckEnabled が**true**でのスペルに誤りテキストが選択されます。</span><span class="sxs-lookup"><span data-stu-id="168ef-226">when IsSpellCheckEnabled is **true** and misspelled text is selected.</span></span> |
| <span data-ttu-id="168ef-227">切り取り</span><span class="sxs-lookup"><span data-stu-id="168ef-227">Cut</span></span> | <span data-ttu-id="168ef-228">テキスト コントロールは読み取り専用ではないとテキストが選択されます。</span><span class="sxs-lookup"><span data-stu-id="168ef-228">when the text control is not read-only and text is selected.</span></span> |
| <span data-ttu-id="168ef-229">コピー</span><span class="sxs-lookup"><span data-stu-id="168ef-229">Copy</span></span> | <span data-ttu-id="168ef-230">テキストが選択されている場合。</span><span class="sxs-lookup"><span data-stu-id="168ef-230">when text is selected.</span></span> |
| <span data-ttu-id="168ef-231">貼り付け</span><span class="sxs-lookup"><span data-stu-id="168ef-231">Paste</span></span> | <span data-ttu-id="168ef-232">テキスト コントロールは読み取り専用ではないとクリップボードがコンテンツです。</span><span class="sxs-lookup"><span data-stu-id="168ef-232">when the text control is not read-only and the clipboard has content.</span></span> |
| <span data-ttu-id="168ef-233">元に戻す</span><span class="sxs-lookup"><span data-stu-id="168ef-233">Undo</span></span> | <span data-ttu-id="168ef-234">取り消すことができる操作がある場合。</span><span class="sxs-lookup"><span data-stu-id="168ef-234">when there is an action that can be undone.</span></span> |
| <span data-ttu-id="168ef-235">すべて選択</span><span class="sxs-lookup"><span data-stu-id="168ef-235">Select all</span></span> | <span data-ttu-id="168ef-236">テキストを選択することができます。</span><span class="sxs-lookup"><span data-stu-id="168ef-236">when text can be selected.</span></span> |

### <a name="custom-text-command-bar-flyouts"></a><span data-ttu-id="168ef-237">カスタム テキスト コマンド バーのポップアップ</span><span class="sxs-lookup"><span data-stu-id="168ef-237">Custom text command bar flyouts</span></span>

<span data-ttu-id="168ef-238">TextCommandBarFlyout は、カスタマイズできませんされ、各テキスト コントロールで自動的に管理されます。</span><span class="sxs-lookup"><span data-stu-id="168ef-238">TextCommandBarFlyout can't be customized, and is managed automatically by each text control.</span></span> <span data-ttu-id="168ef-239">ただし、カスタム コマンドを使った TextCommandBarFlyout 既定値を置き換えることができます。</span><span class="sxs-lookup"><span data-stu-id="168ef-239">However, you can replace the default TextCommandBarFlyout with custom commands.</span></span>

- <span data-ttu-id="168ef-240">TextCommandBarFlyout テキストの選択に表示される既定値を交換するには、カスタム CommandBarFlyout (またはその他のポップアップ型) を作成し、 **SelectionFlyout**プロパティに割り当てます。</span><span class="sxs-lookup"><span data-stu-id="168ef-240">To replace the default TextCommandBarFlyout that's shown on text selection, you can create a custom CommandBarFlyout (or other flyout type) and assign it to the **SelectionFlyout** property.</span></span> <span data-ttu-id="168ef-241">SelectionFlyout を**null**に設定すると、選択内容にコマンドは表示されません。</span><span class="sxs-lookup"><span data-stu-id="168ef-241">If you set SelectionFlyout to **null**, no commands are shown on selection.</span></span>
- <span data-ttu-id="168ef-242">既定のコンテキスト メニューとして表示されている TextCommandBarFlyout を置換するには、テキスト コントロールに**ContextFlyout**プロパティにカスタム CommandBarFlyout (またはその他のポップアップ型) を割り当てます。</span><span class="sxs-lookup"><span data-stu-id="168ef-242">To replace the default TextCommandBarFlyout that's shown as the context menu, assign a custom CommandBarFlyout (or other flyout type) to the **ContextFlyout** property on a text control.</span></span> <span data-ttu-id="168ef-243">ContextFlyout を**null**に設定した場合、TextCommandBarFlyout ではなく、テキスト コントロールの以前のバージョンに表示されるメニュー ポップアップが表示されます。</span><span class="sxs-lookup"><span data-stu-id="168ef-243">If you set ContextFlyout to **null**, the menu flyout shown in previous versions of the text control is shown instead of the TextCommandBarFlyout.</span></span>

## <a name="get-the-sample-code"></a><span data-ttu-id="168ef-244">サンプル コードを入手する</span><span class="sxs-lookup"><span data-stu-id="168ef-244">Get the sample code</span></span>

- <span data-ttu-id="168ef-245">[XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - インタラクティブな形ですべての XAML コントロールを参照できます。</span><span class="sxs-lookup"><span data-stu-id="168ef-245">[XAML Controls Gallery sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - See all the XAML controls in an interactive format.</span></span>
- [<span data-ttu-id="168ef-246">XAML コマンド実行のサンプル</span><span class="sxs-lookup"><span data-stu-id="168ef-246">XAML Commanding sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkId=620019)

## <a name="related-articles"></a><span data-ttu-id="168ef-247">関連記事</span><span class="sxs-lookup"><span data-stu-id="168ef-247">Related articles</span></span>

- [<span data-ttu-id="168ef-248">UWP アプリのコマンド設計の基本</span><span class="sxs-lookup"><span data-stu-id="168ef-248">Command design basics for UWP apps</span></span>](../basics/commanding-basics.md)
- [<span data-ttu-id="168ef-249">CommandBar クラス</span><span class="sxs-lookup"><span data-stu-id="168ef-249">CommandBar class</span></span>](https://msdn.microsoft.com/library/windows/apps/dn279427)
