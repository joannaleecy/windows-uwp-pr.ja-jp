---
author: jwmsft
Description: Command bar flyouts give users inline access to your app's most common tasks.
title: コマンド バーのポップアップ
label: Command bar flyout
template: detail.hbs
ms.author: jimwalk
ms.date: 10/2/2018
ms.topic: article
keywords: Windows 10, UWP
pm-contact: abarlow
design-contact: ksulliv
dev-contact: llongley
doc-status: Draft
ms.localizationpriority: medium
ms.openlocfilehash: 95d99c41ff2679e3ef3e0471dd583fe78458922c
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/01/2018
ms.locfileid: "5919160"
---
# <a name="command-bar-flyout"></a><span data-ttu-id="3b41b-103">コマンド バーのポップアップ</span><span class="sxs-lookup"><span data-stu-id="3b41b-103">Command bar flyout</span></span>

<span data-ttu-id="3b41b-104">コマンド バーのポップアップでは、UI のキャンバス上の要素に関連するフリー ツールバーにコマンドを表示することによって一般的なタスクに簡単にアクセスをユーザーに提供できます。</span><span class="sxs-lookup"><span data-stu-id="3b41b-104">The command bar flyout lets you provide users with easy access to common tasks by showing commands in a floating toolbar related to an element on your UI canvas.</span></span>

![拡張テキスト コマンド バーのポップアップ](images/command-bar-flyout-header.png)

> <span data-ttu-id="3b41b-106">Windows 10、1809 ([SDK 17763](https://developer.microsoft.com/windows/downloads/windows-10-sdk)) のバージョンが必要です CommandBarFlyout またはそれ以降、または[Windows の UI ライブラリ](https://docs.microsoft.com/uwp/toolkits/winui/)。</span><span class="sxs-lookup"><span data-stu-id="3b41b-106">CommandBarFlyout requires Windows 10, version 1809 ([SDK 17763](https://developer.microsoft.com/windows/downloads/windows-10-sdk)) or later, or the [Windows UI Library](https://docs.microsoft.com/uwp/toolkits/winui/).</span></span>

> - <span data-ttu-id="3b41b-107">**プラットフォーム Api**: [CommandBarFlyout クラス](/uwp/api/windows.ui.xaml.controls.commandbarflyout)、 [TextCommandBarFlyout クラス](/uwp/api/windows.ui.xaml.controls.textcommandbarflyout)、 [AppBarButton クラス](/uwp/api/windows.ui.xaml.controls.appbarbutton)、 [AppBarToggleButton クラス](/uwp/api/windows.ui.xaml.controls.appbartogglebutton)、 [AppBarSeparator クラス](/uwp/api/windows.ui.xaml.controls.appbarseparator)</span><span class="sxs-lookup"><span data-stu-id="3b41b-107">**Platform APIs**: [CommandBarFlyout class](/uwp/api/windows.ui.xaml.controls.commandbarflyout), [TextCommandBarFlyout class](/uwp/api/windows.ui.xaml.controls.textcommandbarflyout), [AppBarButton class](/uwp/api/windows.ui.xaml.controls.appbarbutton), [AppBarToggleButton class](/uwp/api/windows.ui.xaml.controls.appbartogglebutton), [AppBarSeparator class](/uwp/api/windows.ui.xaml.controls.appbarseparator)</span></span>
>- <span data-ttu-id="3b41b-108">**Windows UI ライブラリ Api**: [CommandBarFlyout クラス](/uwp/api/microsoft.ui.xaml.controls.commandbarflyout)、 [TextCommandBarFlyout クラス](/uwp/api/microsoft.ui.xaml.controls.textcommandbarflyout)</span><span class="sxs-lookup"><span data-stu-id="3b41b-108">**Windows UI Library APIs**: [CommandBarFlyout class](/uwp/api/microsoft.ui.xaml.controls.commandbarflyout), [TextCommandBarFlyout class](/uwp/api/microsoft.ui.xaml.controls.textcommandbarflyout)</span></span>

<span data-ttu-id="3b41b-109">[コマンド バー](app-bars.md)のような CommandBarFlyout には**PrimaryCommands**と**SecondaryCommands**のプロパティのコマンドを追加するのにを使用することができます。</span><span class="sxs-lookup"><span data-stu-id="3b41b-109">Like [CommandBar](app-bars.md), CommandBarFlyout has **PrimaryCommands** and **SecondaryCommands** properties you can use to add commands.</span></span> <span data-ttu-id="3b41b-110">コマンドは、コレクション、またはその両方に配置できます。</span><span class="sxs-lookup"><span data-stu-id="3b41b-110">You can place commands in either collection, or both.</span></span> <span data-ttu-id="3b41b-111">プライマリおよびセカンダリのコマンドが表示されるタイミングと方法は、表示モードによって異なります。</span><span class="sxs-lookup"><span data-stu-id="3b41b-111">When and how the primary and secondary commands are displayed depends on the display mode.</span></span>

<span data-ttu-id="3b41b-112">コマンド バーのポップアップには、2 つの表示モード:*が折りたたまれている*し、*展開*します。</span><span class="sxs-lookup"><span data-stu-id="3b41b-112">The command bar flyout has two display modes: *collapsed* and *expanded*.</span></span>

- <span data-ttu-id="3b41b-113">モードでは、折りたたまれている、主要なコマンドのみが表示されます。</span><span class="sxs-lookup"><span data-stu-id="3b41b-113">In the collapsed mode, only the primary commands are shown.</span></span> <span data-ttu-id="3b41b-114">場合は、コマンド バーのポップアップには、プライマリとセカンダリの両方のコマンド、」の詳細を参照してください」のボタン、省略記号で表される \ [•••\] が表示されます。</span><span class="sxs-lookup"><span data-stu-id="3b41b-114">If your command bar flyout has both primary and secondary commands, a "see more" button, which is represented by an ellipsis \[•••\], is displayed.</span></span> <span data-ttu-id="3b41b-115">これにより、拡張モードへの移行によって第 2 のコマンドへのアクセスを取得します。</span><span class="sxs-lookup"><span data-stu-id="3b41b-115">This lets the user get access to the secondary commands by transitioning to expanded mode.</span></span>
- <span data-ttu-id="3b41b-116">拡張モードでは、プライマリおよびセカンダリの両方のコマンドが表示されます。</span><span class="sxs-lookup"><span data-stu-id="3b41b-116">In the expanded mode, both the primary and secondary commands are shown.</span></span> <span data-ttu-id="3b41b-117">(コントロールに 2 次のアイテムのみがある場合に表示されます MenuFlyout コントロールと同様の方法で。</span><span class="sxs-lookup"><span data-stu-id="3b41b-117">(If the control has only secondary items, they are shown in a way similar to the MenuFlyout control.)</span></span>

## <a name="is-this-the-right-control"></a><span data-ttu-id="3b41b-118">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="3b41b-118">Is this the right control?</span></span>

<span data-ttu-id="3b41b-119">ボタンやアプリのキャンバス上の要素のコンテキストでは、メニュー項目など、ユーザーにコマンドのコレクションを表示するのにには、CommandBarFlyout コントロールを使用します。</span><span class="sxs-lookup"><span data-stu-id="3b41b-119">Use the CommandBarFlyout control to show a collection of commands to the user, such as buttons and menu items, in the context of an element on the app canvas.</span></span>

<span data-ttu-id="3b41b-120">TextCommandBarFlyout では、TextBox、TextBlock、RichEditBox、RichTextBlock、および PasswordBox コントロールでテキストのコマンドが表示されます。</span><span class="sxs-lookup"><span data-stu-id="3b41b-120">The TextCommandBarFlyout displays text commands in TextBox, TextBlock, RichEditBox, RichTextBlock, and PasswordBox controls.</span></span> <span data-ttu-id="3b41b-121">コマンドは、現在選択されているテキストを自動的に適切に構成します。</span><span class="sxs-lookup"><span data-stu-id="3b41b-121">The commands are automatically configured appropriately to the current text selection.</span></span> <span data-ttu-id="3b41b-122">テキスト コントロールの既定のコマンドのテキストを置換するのには、CommandBarFlyout を使用します。</span><span class="sxs-lookup"><span data-stu-id="3b41b-122">Use a CommandBarFlyout to replace the default text commands on text controls.</span></span>

<span data-ttu-id="3b41b-123">コンテキストを表示するには、] ボックスの一覧の項目のコマンドの[コレクションおよびリストのコマンドを実行するコンテキスト](collection-commanding.md)で指示に従います。</span><span class="sxs-lookup"><span data-stu-id="3b41b-123">To show contextual commands on list items follow the guidance in [Contextual commanding for collections and lists](collection-commanding.md).</span></span>

### <a name="commandbarflyout-vs-menuflyout"></a><span data-ttu-id="3b41b-124">CommandBarFlyout vs MenuFlyout</span><span class="sxs-lookup"><span data-stu-id="3b41b-124">CommandBarFlyout vs MenuFlyout</span></span>

<span data-ttu-id="3b41b-125">コンテキスト メニューにコマンドを表示するには、CommandBarFlyout または MenuFlyout を使用できます。</span><span class="sxs-lookup"><span data-stu-id="3b41b-125">To show commands in a context menu, you can use CommandBarFlyout or MenuFlyout.</span></span> <span data-ttu-id="3b41b-126">CommandBarFlyout は、MenuFlyout よりもより多くの機能が用意されていますのでお勧めします。</span><span class="sxs-lookup"><span data-stu-id="3b41b-126">We recommend CommandBarFlyout because it provides more functionality than MenuFlyout.</span></span> <span data-ttu-id="3b41b-127">セカンダリ コマンドのみを使用して CommandBarFlyout を使用するには動作を取得し、MenuFlyout の検索またはプライマリとセカンダリの両方のコマンドを使用して完全なコマンド バーのポップアップを使用します。</span><span class="sxs-lookup"><span data-stu-id="3b41b-127">You can use CommandBarFlyout with only secondary commands to get the behavior and look of a MenuFlyout, or use the full command bar flyout with both primary and secondary commands.</span></span>

> <span data-ttu-id="3b41b-128">関連情報は、[動的メニュー](../controls-and-patterns/dialogs-and-flyouts/flyouts.md)の[メニューおよびコンテキスト メニュー](menus.md)、[コマンド バー](app-bars.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="3b41b-128">For related info, see [Flyouts](../controls-and-patterns/dialogs-and-flyouts/flyouts.md), [Menus and context menus](menus.md), and [Command bars](app-bars.md).</span></span>

## <a name="examples"></a><span data-ttu-id="3b41b-129">例</span><span class="sxs-lookup"><span data-stu-id="3b41b-129">Examples</span></span>

<table>
<th align="left"><span data-ttu-id="3b41b-130">XAML コントロール ギャラリー</span><span class="sxs-lookup"><span data-stu-id="3b41b-130">XAML Controls Gallery</span></span><th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><span data-ttu-id="3b41b-131"><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong>アプリケーションがインストールされている場合は、ここをクリックして<a href="xamlcontrolsgallery:/item/CommandBarFlyout">アプリケーションを開き実行中の CommandBarFlyout を参照してください</a>。</span><span class="sxs-lookup"><span data-stu-id="3b41b-131">If you have the <strong style="font-weight: semi-bold">XAML Controls Gallery</strong> app installed, click here to <a href="xamlcontrolsgallery:/item/CommandBarFlyout">open the app and see the CommandBarFlyout in action</a>.</span></span></p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT"><span data-ttu-id="3b41b-132">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</span><span class="sxs-lookup"><span data-stu-id="3b41b-132">Get the XAML Controls Gallery app (Microsoft Store)</span></span></a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics"><span data-ttu-id="3b41b-133">ソース コード (GitHub) を入手する</span><span class="sxs-lookup"><span data-stu-id="3b41b-133">Get the source code (GitHub)</span></span></a></li>
    </ul>
</td>
</tr>
</table>

## <a name="proactive-vs-reactive-invocation"></a><span data-ttu-id="3b41b-134">事前と事後対応型の呼び出し</span><span class="sxs-lookup"><span data-stu-id="3b41b-134">Proactive vs. reactive invocation</span></span>

<span data-ttu-id="3b41b-135">フライアウトまたは、UI のキャンバス上の要素に関連付けられているメニューを呼び出すには通常 2 つ方法があります:_予防的な呼び出し_および_事後対応型の呼び出しを実行_します。</span><span class="sxs-lookup"><span data-stu-id="3b41b-135">There are typically two ways to invoke a flyout or menu that's associated with an element on your UI canvas: _proactive invocation_ and _reactive invocation_.</span></span>

<span data-ttu-id="3b41b-136">事前対応型の呼び出しでコマンドが自動的に表示、ユーザーがコマンドに関連付けられている項目を操作したとき。</span><span class="sxs-lookup"><span data-stu-id="3b41b-136">In proactive invocation, commands appear automatically when the user interacts with the item that the commands are associated with.</span></span> <span data-ttu-id="3b41b-137">たとえば、テキストの書式設定コマンドをポップアップ表示、ユーザーがテキスト ボックス内のテキストを選択するとします。</span><span class="sxs-lookup"><span data-stu-id="3b41b-137">For example, text formatting commands might pop up when the user selects text in a text box.</span></span> <span data-ttu-id="3b41b-138">この例では、コマンド バーのポップアップはフォーカスを取得できません。</span><span class="sxs-lookup"><span data-stu-id="3b41b-138">In this case, the command bar flyout does not take focus.</span></span> <span data-ttu-id="3b41b-139">代わりに、ユーザーと対話して、項目に関連するコマンドが表示されます。</span><span class="sxs-lookup"><span data-stu-id="3b41b-139">Instead, it presents relevant commands close to the item the user is interacting with.</span></span> <span data-ttu-id="3b41b-140">ユーザーは、コマンドを使用して通信できない場合に、閉じられます。</span><span class="sxs-lookup"><span data-stu-id="3b41b-140">If the user doesn't interact with the commands, they are dismissed.</span></span>

<span data-ttu-id="3b41b-141">事後対応型の呼び出しでは、コマンドで表示されます明示的なユーザー アクションへの応答を要求するコマンドです。たとえば、右クリックします。</span><span class="sxs-lookup"><span data-stu-id="3b41b-141">In reactive invocation, commands are shown in response to an explicit user action to request the commands; for example, a right-click.</span></span> <span data-ttu-id="3b41b-142">これは、[コンテキスト メニュー](menus.md)の従来の概念に対応しています。</span><span class="sxs-lookup"><span data-stu-id="3b41b-142">This corresponds to the traditional concept of a [context menu](menus.md).</span></span>

<span data-ttu-id="3b41b-143">方法、または 2 つの混合気も CommandBarFlyout を使用することができます。</span><span class="sxs-lookup"><span data-stu-id="3b41b-143">You can use the CommandBarFlyout in either way, or even a mixture of the two.</span></span>

## <a name="create-a-command-bar-flyout"></a><span data-ttu-id="3b41b-144">コマンド バーのポップアップを作成します。</span><span class="sxs-lookup"><span data-stu-id="3b41b-144">Create a command bar flyout</span></span>

<span data-ttu-id="3b41b-145">この例では、コマンド バーのポップアップを作成し、リアクティブとプロアクティブに使用する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="3b41b-145">This example shows how to create a command bar flyout and use it both proactively and reactively.</span></span> <span data-ttu-id="3b41b-146">イメージをタップすると、フライアウトは、折りたたまれた状態で表示されます。</span><span class="sxs-lookup"><span data-stu-id="3b41b-146">When the image is tapped, the flyout is shown in its collapsed mode.</span></span> <span data-ttu-id="3b41b-147">コンテキスト メニューとして表示される、拡張モードで、フライアウトが表示されます。</span><span class="sxs-lookup"><span data-stu-id="3b41b-147">When shown as a context menu, the flyout is shown in its expanded mode.</span></span> <span data-ttu-id="3b41b-148">どちらの場合も、ユーザー展開したり折りたたんだり、ポップアップが開かれた後です。</span><span class="sxs-lookup"><span data-stu-id="3b41b-148">In either case, the user can expand or collapse the flyout after it's opened.</span></span>

![折りたたまれたコマンド バーのポップアップの例](images/command-bar-flyout-img-collapsed.png)

> _<span data-ttu-id="3b41b-150">折りたたまれたコマンド バーのポップアップ</span><span class="sxs-lookup"><span data-stu-id="3b41b-150">A collapsed command bar flyout</span></span>_

![拡張されたコマンド バー ポップアップの例](images/command-bar-flyout-img-expanded.png)

> _<span data-ttu-id="3b41b-152">拡張されたコマンド バーのポップアップ</span><span class="sxs-lookup"><span data-stu-id="3b41b-152">An expanded command bar flyout</span></span>_

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

### <a name="show-commands-proactively"></a><span data-ttu-id="3b41b-153">事前にコマンドを表示します。</span><span class="sxs-lookup"><span data-stu-id="3b41b-153">Show commands proactively</span></span>

<span data-ttu-id="3b41b-154">コンテキストのコマンドを事前に表示する場合は、既定の (コマンド バーのポップアップを解除する必要があります) で主要なコマンドのみを表示するか。</span><span class="sxs-lookup"><span data-stu-id="3b41b-154">When you show contextual commands proactively, only the primary commands should be shown by default (the command bar flyout should be collapsed).</span></span> <span data-ttu-id="3b41b-155">主要なコマンドのコレクション、およびコレクション内の補助的なコマンドのコンテキスト メニューで従来から行われるその他のコマンドでは、最も重要なコマンドを配置します。</span><span class="sxs-lookup"><span data-stu-id="3b41b-155">Place the most important commands in the primary commands collection, and additional commands that would traditionally go in a context menu into the secondary commands collection.</span></span>

<span data-ttu-id="3b41b-156">コマンドを事前に表示するには、通常、コマンド バーのポップアップを表示する[] をクリックして](/uwp/api/windows.ui.xaml.controls.primitives.buttonbase.click)または[Tapped](/uwp/api/windows.ui.xaml.uielement.tapped)イベントを処理します。</span><span class="sxs-lookup"><span data-stu-id="3b41b-156">To proactively show commands, you typically handle the [Click](/uwp/api/windows.ui.xaml.controls.primitives.buttonbase.click) or [Tapped](/uwp/api/windows.ui.xaml.uielement.tapped) event to show the command bar flyout.</span></span> <span data-ttu-id="3b41b-157">**一時的な**または**TransientWithDismissOnPointerMoveAway**にフォーカスすることがなく、折りたたまれた状態で、ポップアップを開くには、フライアウトの[ShowMode](/uwp/api/windows.ui.xaml.controls.primitives.flyoutbase.showmode)を設定します。</span><span class="sxs-lookup"><span data-stu-id="3b41b-157">Set the flyout's [ShowMode](/uwp/api/windows.ui.xaml.controls.primitives.flyoutbase.showmode) to **Transient** or **TransientWithDismissOnPointerMoveAway** to open the flyout in its collapsed mode without taking focus.</span></span>

<span data-ttu-id="3b41b-158">以降 Windows 10 の内部からのプレビューでは、テキスト コントロールは、 **SelectionFlyout**プロパティを持ちます。</span><span class="sxs-lookup"><span data-stu-id="3b41b-158">Starting in the Windows 10 Insider Preview, text controls have a **SelectionFlyout** property.</span></span> <span data-ttu-id="3b41b-159">フライアウトをこのプロパティに代入するときにテキストを選択すると自動的に表示されます。</span><span class="sxs-lookup"><span data-stu-id="3b41b-159">When you assign a flyout to this property, it is automatically shown when text is selected.</span></span>

### <a name="show-commands-reactively"></a><span data-ttu-id="3b41b-160">リアクティブにコマンドを表示します。</span><span class="sxs-lookup"><span data-stu-id="3b41b-160">Show commands reactively</span></span>

<span data-ttu-id="3b41b-161">リアクティブ、コンテキスト メニュー コマンドのコンテキストを表示すると、既定では (コマンド バーのポップアップを展開する必要があります)、補助的なコマンドが表示されます。</span><span class="sxs-lookup"><span data-stu-id="3b41b-161">When you show contextual commands reactively, as a context menu, the secondary commands are shown by default (the command bar flyout should be expanded).</span></span> <span data-ttu-id="3b41b-162">この例では、コマンド バーのポップアップには、プライマリとセカンダリの両方のコマンド、または補助的なコマンドのみがあります。</span><span class="sxs-lookup"><span data-stu-id="3b41b-162">In this case, the command bar flyout might have both primary and secondary commands, or secondary commands only.</span></span>

<span data-ttu-id="3b41b-163">コンテキスト メニューにコマンドを表示するに割り当てることを通常、フライアウト UI 要素の[ContextFlyout](/uwp/api/windows.ui.xaml.uielement.contextflyout)プロパティにします。</span><span class="sxs-lookup"><span data-stu-id="3b41b-163">To show commands in a context menu, you typically assign the flyout to the [ContextFlyout](/uwp/api/windows.ui.xaml.uielement.contextflyout) property of a UI element.</span></span> <span data-ttu-id="3b41b-164">この方法では、要素によって処理されます、ポップアップを開くと、特に何もする必要はありません。</span><span class="sxs-lookup"><span data-stu-id="3b41b-164">This way, opening the flyout is handled by the element, and you don't need to do anything more.</span></span>

<span data-ttu-id="3b41b-165">(たとえば、 [RightTapped](/uwp/api/windows.ui.xaml.uielement.righttapped)イベントの場合) を自分で、フライアウトを表示を処理する場合は、**標準**の拡張モードで、フライアウトを開き、フォーカスを設定するフライアウトの[ShowMode](/uwp/api/windows.ui.xaml.controls.primitives.flyoutbase.showmode)を設定します。</span><span class="sxs-lookup"><span data-stu-id="3b41b-165">If you handle showing the flyout yourself (for example, on a [RightTapped](/uwp/api/windows.ui.xaml.uielement.righttapped) event), set the flyout's [ShowMode](/uwp/api/windows.ui.xaml.controls.primitives.flyoutbase.showmode) to **Standard** to open the flyout in its expanded mode and give it focus.</span></span>

> [!TIP]
> <span data-ttu-id="3b41b-166">フライアウトとフライアウトの位置を制御する方法を表示するときのオプションに関する詳細情報は、[動的メニュー](../controls-and-patterns/dialogs-and-flyouts/flyouts.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="3b41b-166">For more info about options when showing a flyout and how to control placement of the flyout, see [Flyouts](../controls-and-patterns/dialogs-and-flyouts/flyouts.md).</span></span>

## <a name="commands-and-content"></a><span data-ttu-id="3b41b-167">コマンドとコンテンツ</span><span class="sxs-lookup"><span data-stu-id="3b41b-167">Commands and content</span></span>

<span data-ttu-id="3b41b-168">CommandBarFlyout コントロールには 2 つのプロパティ コマンドとコンテンツを追加するのにを使用することができます: [PrimaryCommands](/uwp/api/windows.ui.xaml.controls.commandbarflyout.primarycommands)と[SecondaryCommands](/uwp/api/windows.ui.xaml.controls.commandbarflyout.secondarycommands)。</span><span class="sxs-lookup"><span data-stu-id="3b41b-168">The CommandBarFlyout control has 2 properties you can use to add commands and content: [PrimaryCommands](/uwp/api/windows.ui.xaml.controls.commandbarflyout.primarycommands) and [SecondaryCommands](/uwp/api/windows.ui.xaml.controls.commandbarflyout.secondarycommands).</span></span>

<span data-ttu-id="3b41b-169">既定では、コマンド バーの項目は **PrimaryCommands** コレクションに追加されます。</span><span class="sxs-lookup"><span data-stu-id="3b41b-169">By default, command bar items are added to the **PrimaryCommands** collection.</span></span> <span data-ttu-id="3b41b-170">これらのコマンドは、コマンド バーに表示し、折りたたんだ状態と展開の両方のモードで表示されます。</span><span class="sxs-lookup"><span data-stu-id="3b41b-170">These commands are shown in the command bar and are visible in both the collapsed and expanded modes.</span></span> <span data-ttu-id="3b41b-171">コマンド バーとは異なり主要なコマンドは自動的にセカンダリ コマンドをオーバーフローではないと、切り捨てられる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="3b41b-171">Unlike CommandBar, primary commands do not automatically overflow to the secondary commands and might be truncated.</span></span>

<span data-ttu-id="3b41b-172">**SecondaryCommands**コレクションにコマンドを追加することもできます。</span><span class="sxs-lookup"><span data-stu-id="3b41b-172">You can also add commands to the **SecondaryCommands** collection.</span></span> <span data-ttu-id="3b41b-173">補助的なコマンドはコントロールのメニューの部分に表示され、拡張モードでのみ表示されます。</span><span class="sxs-lookup"><span data-stu-id="3b41b-173">Secondary commands are shown in the menu portion of the control and are visible only in the expanded mode.</span></span>

### <a name="app-bar-buttons"></a><span data-ttu-id="3b41b-174">アプリ バーのボタン</span><span class="sxs-lookup"><span data-stu-id="3b41b-174">App bar buttons</span></span>

<span data-ttu-id="3b41b-175">PrimaryCommands と SecondaryCommands [AppBarButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbarbutton.aspx)、 [AppBarToggleButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbartogglebutton.aspx)、および[AppBarSeparator](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbarseparator.aspx)のコントロールを直接設定できます。</span><span class="sxs-lookup"><span data-stu-id="3b41b-175">You can populate the PrimaryCommands and SecondaryCommands directly with [AppBarButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbarbutton.aspx), [AppBarToggleButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbartogglebutton.aspx), and [AppBarSeparator](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbarseparator.aspx) controls.</span></span>

<span data-ttu-id="3b41b-176">アプリ バーのボタン コントロールは、アイコンとテキスト ラベルによって特徴付けられます。</span><span class="sxs-lookup"><span data-stu-id="3b41b-176">The app bar button controls are characterized by an icon and text label.</span></span> <span data-ttu-id="3b41b-177">これらのコントロールは、コマンド バーで使用するために最適化されたし、外観のコントロールがコマンド バーまたはオーバーフロー メニューに表示されているかどうかによって変化します。</span><span class="sxs-lookup"><span data-stu-id="3b41b-177">These controls are optimized for use in a command bar, and their appearance changes depending on whether the control is shown in the command bar or the overflow menu.</span></span>

- <span data-ttu-id="3b41b-178">アプリケーション バー ボタンの主要なコマンドとして使用は、アイコンのみを持つコマンド バーに表示されます。テキスト ラベルは表示されません。</span><span class="sxs-lookup"><span data-stu-id="3b41b-178">App bar buttons used as primary commands are shown in the command bar with only their icon; the text label is not shown.</span></span> <span data-ttu-id="3b41b-179">次のように、コマンドの説明のテキストを表示するツールヒントを使用することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="3b41b-179">We recommend that you use a tooltip to show a text description of the command, as shown here.</span></span>
    ```xaml
    <AppBarButton Icon="Copy" ToolTipService.ToolTip="Copy"/>
    ```
- <span data-ttu-id="3b41b-180">メニューで、ラベルとアイコンが表示されると、セカンダリ コマンドとして使用するアプリケーション バーのボタンが表示されます。</span><span class="sxs-lookup"><span data-stu-id="3b41b-180">App bar buttons used as secondary commands are shown in the menu, with both the label and icon visible.</span></span>

### <a name="other-content"></a><span data-ttu-id="3b41b-181">その他のコンテンツ</span><span class="sxs-lookup"><span data-stu-id="3b41b-181">Other content</span></span>

<span data-ttu-id="3b41b-182">AppBarElementContainer でそれらをラップすることによって、コマンド バーのポップアップに他のコントロールを追加できます。</span><span class="sxs-lookup"><span data-stu-id="3b41b-182">You can add other controls to a command bar flyout by wrapping them in an AppBarElementContainer.</span></span> <span data-ttu-id="3b41b-183">これは、 [DropDownButton]()や[SplitButton]()のようなコントロールを追加またはより複雑な UI を作成するのには、 [StackPanel]()などのコンテナーを追加することができます。</span><span class="sxs-lookup"><span data-stu-id="3b41b-183">This lets you add controls like [DropDownButton]() or [SplitButton](), or add containers like [StackPanel]() to create more complex UI.</span></span>

<span data-ttu-id="3b41b-184">要素はコマンド バーのポップアップのプライマリまたはセカンダリのコマンドのコレクションに追加するのには、 [ICommandBarElement](/uwp/api/windows.ui.xaml.controls.icommandbarelement)インターフェイスを実装する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3b41b-184">In order to be added to the primary or secondary command collections of a command bar flyout, an element must implement the [ICommandBarElement](/uwp/api/windows.ui.xaml.controls.icommandbarelement) interface.</span></span> <span data-ttu-id="3b41b-185">AppBarElementContainer は、インターフェイス自体を実装していない場合でも、コマンド バーに要素を追加することができますので、このインターフェイスを実装するためのラッパーです。</span><span class="sxs-lookup"><span data-stu-id="3b41b-185">AppBarElementContainer is a wrapper that implements this interface so you can add an element to a command bar even if it doesn't implement the interface itself.</span></span>

<span data-ttu-id="3b41b-186">ここでは、余分な要素をコマンド バーのポップアップに追加するのには、AppBarElementContainer が使用されます。</span><span class="sxs-lookup"><span data-stu-id="3b41b-186">Here, an AppBarElementContainer is used to add extra elements to a command bar flyout.</span></span> <span data-ttu-id="3b41b-187">SplitButton は、色の選択を許可するのには主要なコマンドに追加されます。</span><span class="sxs-lookup"><span data-stu-id="3b41b-187">A SplitButton is added to the primary commands to allow selection of colors.</span></span> <span data-ttu-id="3b41b-188">StackPanel は、ズーム コントロールのより複雑なレイアウトを許可するセカンダリ コマンドに追加されます。</span><span class="sxs-lookup"><span data-stu-id="3b41b-188">A StackPanel is added to the secondary commands to allow a more complex layout for zoom controls.</span></span>

> [!TIP]
> <span data-ttu-id="3b41b-189">既定では、アプリケーションのキャンバスのように設計された要素がありますが正しく印刷されないコマンド バーにします。</span><span class="sxs-lookup"><span data-stu-id="3b41b-189">By default, elements designed for the app canvas might not look right in a command bar.</span></span> <span data-ttu-id="3b41b-190">AppBarElementContainer を使用して要素を追加するときは、いくつか手順を実行する必要がある要素が他のコマンド バーの要素に一致するがあります。</span><span class="sxs-lookup"><span data-stu-id="3b41b-190">When you add an element using AppBarElementContainer, there are some steps you should take to make the element match other command bar elements:</span></span>
>
> - <span data-ttu-id="3b41b-191">オーバーライドが要素の背景と枠線を作成するのには[軽量のスタイル](/design/controls-and-patterns/xaml-styles#lightweight-styling)を持つ既定のブラシでは、アプリケーション バーのボタンと一致します。</span><span class="sxs-lookup"><span data-stu-id="3b41b-191">Override the default brushes with [lightweight styling](/design/controls-and-patterns/xaml-styles#lightweight-styling) to make the element's background and border match the app bar buttons.</span></span>
> - <span data-ttu-id="3b41b-192">要素の位置とサイズを調整します。</span><span class="sxs-lookup"><span data-stu-id="3b41b-192">Adjust the size and position of the element.</span></span>
> - <span data-ttu-id="3b41b-193">16px の高さ、幅、これでアイコンをラップします。</span><span class="sxs-lookup"><span data-stu-id="3b41b-193">Wrap icons in a Viewbox with a Width and Height of 16px.</span></span>

> [!NOTE]
> <span data-ttu-id="3b41b-194">この例では、表示されているコマンドのいずれかが実装していないのみ、コマンド バー ポップアップ UI を示します。</span><span class="sxs-lookup"><span data-stu-id="3b41b-194">This example shows only the command bar flyout UI, it does not implement any of the commands that are shown.</span></span> <span data-ttu-id="3b41b-195">コマンドを実装する方法の詳細については、[ボタン](buttons.md)や[コマンドの設計の基本」](../basics/commanding-basics.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="3b41b-195">For more info about implementing the commands, see [Buttons](buttons.md) and [Command design basics](../basics/commanding-basics.md).</span></span>

![分割ボタンを使用してコマンド バーのポップアップ](images/command-bar-flyout-split-button.png)

> _<span data-ttu-id="3b41b-197">オープン、SplitButton で折りたたまれているコマンド バーのフライアウト</span><span class="sxs-lookup"><span data-stu-id="3b41b-197">A collapsed command bar flyout with an open SplitButton</span></span>_

![複雑な UI を持つコマンド バーのポップアップ](images/command-bar-flyout-custom-ui.png)

> _<span data-ttu-id="3b41b-199">メニューから「カスタム ズーム UI での拡張されたコマンド バー ポップアップ</span><span class="sxs-lookup"><span data-stu-id="3b41b-199">An expanded command bar flyout with custom zoom UI in the menu</span></span>_


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

## <a name="create-a-context-menu-with-secondary-commands-only"></a><span data-ttu-id="3b41b-200">セカンダリ コマンドのみを使用してコンテキスト メニューを作成します。</span><span class="sxs-lookup"><span data-stu-id="3b41b-200">Create a context menu with secondary commands only</span></span>

<span data-ttu-id="3b41b-201">として[コンテキスト メニュー](menus.md)で、MenuFlyout の代わりに、セカンダリ コマンドのみを使用して、CommandBarFlyout を使用できます。</span><span class="sxs-lookup"><span data-stu-id="3b41b-201">You can use a CommandBarFlyout with only secondary commands as a [context menu](menus.md), in place of a MenuFlyout.</span></span>

![セカンダリ コマンドのみを使用してコマンド バーのポップアップ](images/command-bar-flyout-context-menu.png)

> _<span data-ttu-id="3b41b-203">コンテキスト メニューとコマンド バーのポップアップ</span><span class="sxs-lookup"><span data-stu-id="3b41b-203">Command bar flyout as a context menu</span></span>_

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

<span data-ttu-id="3b41b-204">標準メニューを作成するのには、DropDownButton に、CommandBarFlyout を使用することもできます。</span><span class="sxs-lookup"><span data-stu-id="3b41b-204">You can also use a CommandBarFlyout with a DropDownButton to create a standard menu.</span></span>

![ドロップダウン ボタンのメニューとコマンド バー フライアウト](images/command-bar-flyout-dropdown.png)

> _<span data-ttu-id="3b41b-206">ドロップ ダウン ボタン] メニューのコマンド バーのポップアップで</span><span class="sxs-lookup"><span data-stu-id="3b41b-206">A drop down button menu in a command bar flyout</span></span>_

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

## <a name="command-bar-flyouts-for-text-controls"></a><span data-ttu-id="3b41b-207">テキスト コントロールのコマンド バーのフライアウト</span><span class="sxs-lookup"><span data-stu-id="3b41b-207">Command bar flyouts for text controls</span></span>

<span data-ttu-id="3b41b-208">[TextCommandBarFlyout](/uwp/api/microsoft.ui.xaml.controls.textcommandbarflyout)は、テキスト編集のためのコマンドを含む特殊なコマンド バー ポップアップです。</span><span class="sxs-lookup"><span data-stu-id="3b41b-208">The [TextCommandBarFlyout](/uwp/api/microsoft.ui.xaml.controls.textcommandbarflyout) is a specialized command bar flyout that contains commands for editing text.</span></span> <span data-ttu-id="3b41b-209">各テキスト コントロールは、コンテキスト メニュー (右クリック)、またはテキストを選択すると自動的に、TextCommandBarFlyout を示します。</span><span class="sxs-lookup"><span data-stu-id="3b41b-209">Each text control shows the TextCommandBarFlyout automatically as a context menu (right-click), or when text is selected.</span></span> <span data-ttu-id="3b41b-210">テキスト コマンド バーのポップアップは、テキストの選択範囲のみに関連するコマンドを表示するに適応します。</span><span class="sxs-lookup"><span data-stu-id="3b41b-210">The text command bar flyout adapts to the text selection to only show relevant commands.</span></span>

![折りたたまれたテキストのコマンド バー ポップアップ](images/command-bar-flyout-text-selection.png)

> _<span data-ttu-id="3b41b-212">テキストの選択範囲のテキストのコマンド バー ポップアップ</span><span class="sxs-lookup"><span data-stu-id="3b41b-212">A text command bar flyout on text selection</span></span>_

![拡張テキスト コマンド バーのポップアップ](images/command-bar-flyout-text-full.png)

> _<span data-ttu-id="3b41b-214">拡張テキスト コマンド バーのポップアップ</span><span class="sxs-lookup"><span data-stu-id="3b41b-214">An expanded text command bar flyout</span></span>_


### <a name="available-commands"></a><span data-ttu-id="3b41b-215">使用可能なコマンド</span><span class="sxs-lookup"><span data-stu-id="3b41b-215">Available commands</span></span>

<span data-ttu-id="3b41b-216">表示されている場合、TextCommandBarFlyout に含まれているコマンドを次の表に示します。</span><span class="sxs-lookup"><span data-stu-id="3b41b-216">This table shows the commands that are included in a TextCommandBarFlyout, and when they are shown.</span></span>

| <span data-ttu-id="3b41b-217">コマンド</span><span class="sxs-lookup"><span data-stu-id="3b41b-217">Command</span></span> | <span data-ttu-id="3b41b-218">表示しています.</span><span class="sxs-lookup"><span data-stu-id="3b41b-218">Shown...</span></span> |
| ------- | -------- |
| <span data-ttu-id="3b41b-219">Bold</span><span class="sxs-lookup"><span data-stu-id="3b41b-219">Bold</span></span> | <span data-ttu-id="3b41b-220">テキスト コントロールは読み取り専用 (RichEditBox のみ) ではありません。</span><span class="sxs-lookup"><span data-stu-id="3b41b-220">when the text control is not read-only (RichEditBox only).</span></span> |
| <span data-ttu-id="3b41b-221">Italic</span><span class="sxs-lookup"><span data-stu-id="3b41b-221">Italic</span></span> | <span data-ttu-id="3b41b-222">テキスト コントロールは読み取り専用 (RichEditBox のみ) ではありません。</span><span class="sxs-lookup"><span data-stu-id="3b41b-222">when the text control is not read-only (RichEditBox only).</span></span> |
| <span data-ttu-id="3b41b-223">Underline</span><span class="sxs-lookup"><span data-stu-id="3b41b-223">Underline</span></span> | <span data-ttu-id="3b41b-224">テキスト コントロールは読み取り専用 (RichEditBox のみ) ではありません。</span><span class="sxs-lookup"><span data-stu-id="3b41b-224">when the text control is not read-only (RichEditBox only).</span></span> |
| <span data-ttu-id="3b41b-225">校正</span><span class="sxs-lookup"><span data-stu-id="3b41b-225">Proofing</span></span> | <span data-ttu-id="3b41b-226">IsSpellCheckEnabled が**true**であり、スペルが間違っている場合は、テキストが選択されます。</span><span class="sxs-lookup"><span data-stu-id="3b41b-226">when IsSpellCheckEnabled is **true** and misspelled text is selected.</span></span> |
| <span data-ttu-id="3b41b-227">切り取り</span><span class="sxs-lookup"><span data-stu-id="3b41b-227">Cut</span></span> | <span data-ttu-id="3b41b-228">テキスト コントロールは読み取り専用ではないとテキストが選択されます。</span><span class="sxs-lookup"><span data-stu-id="3b41b-228">when the text control is not read-only and text is selected.</span></span> |
| <span data-ttu-id="3b41b-229">コピー</span><span class="sxs-lookup"><span data-stu-id="3b41b-229">Copy</span></span> | <span data-ttu-id="3b41b-230">テキストが選択されている場合。</span><span class="sxs-lookup"><span data-stu-id="3b41b-230">when text is selected.</span></span> |
| <span data-ttu-id="3b41b-231">貼り付け</span><span class="sxs-lookup"><span data-stu-id="3b41b-231">Paste</span></span> | <span data-ttu-id="3b41b-232">テキスト コントロールは読み取り専用ではなく、内容がクリップボードに含まれています。</span><span class="sxs-lookup"><span data-stu-id="3b41b-232">when the text control is not read-only and the clipboard has content.</span></span> |
| <span data-ttu-id="3b41b-233">元に戻す</span><span class="sxs-lookup"><span data-stu-id="3b41b-233">Undo</span></span> | <span data-ttu-id="3b41b-234">元に戻すことができるアクションがある場合。</span><span class="sxs-lookup"><span data-stu-id="3b41b-234">when there is an action that can be undone.</span></span> |
| <span data-ttu-id="3b41b-235">すべて選択</span><span class="sxs-lookup"><span data-stu-id="3b41b-235">Select all</span></span> | <span data-ttu-id="3b41b-236">テキストを選択することができます。</span><span class="sxs-lookup"><span data-stu-id="3b41b-236">when text can be selected.</span></span> |

### <a name="custom-text-command-bar-flyouts"></a><span data-ttu-id="3b41b-237">テキストのカスタム コマンド バーのフライアウト</span><span class="sxs-lookup"><span data-stu-id="3b41b-237">Custom text command bar flyouts</span></span>

<span data-ttu-id="3b41b-238">TextCommandBarFlyout はカスタマイズすることはできませんし、テキストの各コントロールによって自動的に管理します。</span><span class="sxs-lookup"><span data-stu-id="3b41b-238">TextCommandBarFlyout can't be customized, and is managed automatically by each text control.</span></span> <span data-ttu-id="3b41b-239">ただし、デフォルトの TextCommandBarFlyout をユーザー設定のコマンドに置き換えることができます。</span><span class="sxs-lookup"><span data-stu-id="3b41b-239">However, you can replace the default TextCommandBarFlyout with custom commands.</span></span>

- <span data-ttu-id="3b41b-240">TextCommandBarFlyout テキストの選択時に表示される既定値を置換するには、カスタムの CommandBarFlyout (またはその他のフライアウト型) を作成し、 **SelectionFlyout**プロパティに割り当てることです。</span><span class="sxs-lookup"><span data-stu-id="3b41b-240">To replace the default TextCommandBarFlyout that's shown on text selection, you can create a custom CommandBarFlyout (or other flyout type) and assign it to the **SelectionFlyout** property.</span></span> <span data-ttu-id="3b41b-241">SelectionFlyout を**null**に設定する場合は、選択時にコマンドが表示されません。</span><span class="sxs-lookup"><span data-stu-id="3b41b-241">If you set SelectionFlyout to **null**, no commands are shown on selection.</span></span>
- <span data-ttu-id="3b41b-242">TextCommandBarFlyout は、コンテキスト メニューとして表示する既定値を置き換えるには、テキスト コントロールの**ContextFlyout**プロパティにカスタムの CommandBarFlyout (またはその他のフライアウト型) を割り当てます。</span><span class="sxs-lookup"><span data-stu-id="3b41b-242">To replace the default TextCommandBarFlyout that's shown as the context menu, assign a custom CommandBarFlyout (or other flyout type) to the **ContextFlyout** property on a text control.</span></span> <span data-ttu-id="3b41b-243">ContextFlyout を**null**に設定すると、TextCommandBarFlyout の代わりにテキスト コントロールの以前のバージョンで表示] メニューのポップアップが表示されます。</span><span class="sxs-lookup"><span data-stu-id="3b41b-243">If you set ContextFlyout to **null**, the menu flyout shown in previous versions of the text control is shown instead of the TextCommandBarFlyout.</span></span>

## <a name="get-the-sample-code"></a><span data-ttu-id="3b41b-244">サンプル コードを入手する</span><span class="sxs-lookup"><span data-stu-id="3b41b-244">Get the sample code</span></span>

- <span data-ttu-id="3b41b-245">[XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - インタラクティブな形ですべての XAML コントロールを参照できます。</span><span class="sxs-lookup"><span data-stu-id="3b41b-245">[XAML Controls Gallery sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - See all the XAML controls in an interactive format.</span></span>
- [<span data-ttu-id="3b41b-246">XAML コマンド実行のサンプル</span><span class="sxs-lookup"><span data-stu-id="3b41b-246">XAML Commanding sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkId=620019)

## <a name="related-articles"></a><span data-ttu-id="3b41b-247">関連記事</span><span class="sxs-lookup"><span data-stu-id="3b41b-247">Related articles</span></span>

- [<span data-ttu-id="3b41b-248">UWP アプリのコマンド設計の基本</span><span class="sxs-lookup"><span data-stu-id="3b41b-248">Command design basics for UWP apps</span></span>](../basics/commanding-basics.md)
- [<span data-ttu-id="3b41b-249">CommandBar クラス</span><span class="sxs-lookup"><span data-stu-id="3b41b-249">CommandBar class</span></span>](https://msdn.microsoft.com/library/windows/apps/dn279427)
