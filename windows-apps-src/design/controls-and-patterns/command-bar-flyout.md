---
author: jwmsft
Description: Command bar flyouts give users inline access to your app's most common tasks.
title: コマンド バーのポップアップ
label: Command bar flyout
template: detail.hbs
ms.author: jimwalk
ms.date: 07/19/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
pm-contact: abarlow
design-contact: ksulliv
dev-contact: llongley
doc-status: Draft
ms.localizationpriority: medium
ms.openlocfilehash: ec532749fc2dacfc56e80ee2830da36f71c75b2f
ms.sourcegitcommit: 2a63ee6770413bc35ace09b14f56b60007be7433
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3931695"
---
# <a name="command-bar-flyout"></a><span data-ttu-id="3a96f-103">コマンド バーのポップアップ</span><span class="sxs-lookup"><span data-stu-id="3a96f-103">Command bar flyout</span></span>

> [!IMPORTANT]
> <span data-ttu-id="3a96f-104">この記事では、まだリリースされていない機能について説明しています。この機能は、正式版がリリースされるまでに大幅に変更される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="3a96f-104">This article describes functionality that hasn’t been released yet and may be substantially modified before it's commercially released.</span></span> <span data-ttu-id="3a96f-105">ここに記載された情報について、Microsoft は明示または黙示を問わずいかなる保証をするものでもありません。</span><span class="sxs-lookup"><span data-stu-id="3a96f-105">Microsoft makes no warranties, express or implied, with respect to the information provided here.</span></span> <span data-ttu-id="3a96f-106">プレビュー機能[最新の Windows 10 Insider Preview ビルドと SDK](https://insider.windows.com/for-developers/)または[Windows UI のライブラリ](https://docs.microsoft.com/uwp/toolkits/winui/)が必要です。</span><span class="sxs-lookup"><span data-stu-id="3a96f-106">Preview features require the [latest Windows 10 Insider Preview build and SDK](https://insider.windows.com/for-developers/) or the [Windows UI Library](https://docs.microsoft.com/uwp/toolkits/winui/).</span></span>

<span data-ttu-id="3a96f-107">コマンド バーのポップアップでは、UI のキャンバス上の要素に関連する浮動ツールバーのコマンドを示すことにより一般的なタスクに簡単にアクセスをユーザーに提供できます。</span><span class="sxs-lookup"><span data-stu-id="3a96f-107">The command bar flyout lets you provide users with easy access to common tasks by showing commands in a floating toolbar related to an element on your UI canvas.</span></span>

![展開されたテキスト、コマンド バー ポップアップ](images/command-bar-flyout-text-full.png)

> <span data-ttu-id="3a96f-109">関連する情報は、[コマンド バーを使う](app-bars.md)[メニューとコンテキスト メニュー](menus.md)は、[ポップアップ](../controls-and-patterns/dialogs-and-flyouts/flyouts.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3a96f-109">For related info, see [Flyouts](../controls-and-patterns/dialogs-and-flyouts/flyouts.md), [Menus and context menus](menus.md), and [Command bars](app-bars.md).</span></span>

<span data-ttu-id="3a96f-110">CommandBarFlyout では[CommandBar](app-bars.md)など、追加のコマンドを使って**PrimaryCommands**と**SecondaryCommands**のプロパティがあります。</span><span class="sxs-lookup"><span data-stu-id="3a96f-110">Like [CommandBar](app-bars.md), CommandBarFlyout has **PrimaryCommands** and **SecondaryCommands** properties you can use to add commands.</span></span> <span data-ttu-id="3a96f-111">コレクション、またはその両方でコマンドを配置することができます。</span><span class="sxs-lookup"><span data-stu-id="3a96f-111">You can place commands in either collection, or both.</span></span> <span data-ttu-id="3a96f-112">プライマリとセカンダリ コマンドが表示されるタイミングと方法は、表示モードによって異なります。</span><span class="sxs-lookup"><span data-stu-id="3a96f-112">When and how the primary and secondary commands are displayed depends on the display mode.</span></span>

<span data-ttu-id="3a96f-113">コマンド バーのポップアップが 2 つの表示モード:*折りたたまれている*し、*展開*します。</span><span class="sxs-lookup"><span data-stu-id="3a96f-113">The command bar flyout has two display modes: *collapsed* and *expanded*.</span></span>

- <span data-ttu-id="3a96f-114">折りたたまれたモードでは、プライマリ コマンドのみが表示されます。</span><span class="sxs-lookup"><span data-stu-id="3a96f-114">In the collapsed mode, only the primary commands are shown.</span></span> <span data-ttu-id="3a96f-115">場合は、コマンド バーのポップアップにプライマリとセカンダリ コマンド、省略記号で表される「詳細」ボタン \ [•] が表示されます。</span><span class="sxs-lookup"><span data-stu-id="3a96f-115">If your command bar flyout has both primary and secondary commands, a "see more" button, which is represented by an ellipsis \[•••\], is displayed.</span></span> <span data-ttu-id="3a96f-116">これにより、ユーザーの拡張モードに移行して、セカンダリ コマンドへのアクセスを取得します。</span><span class="sxs-lookup"><span data-stu-id="3a96f-116">This lets the user get access to the secondary commands by transitioning to expanded mode.</span></span>
- <span data-ttu-id="3a96f-117">展開時のモードでは、プライマリとセカンダリ コマンドの両方が表示されます。</span><span class="sxs-lookup"><span data-stu-id="3a96f-117">In the expanded mode, both the primary and secondary commands are shown.</span></span> <span data-ttu-id="3a96f-118">(コントロールは、セカンダリ項目のみが、表示されます MenuFlyout コントロールと同様の方法で。)</span><span class="sxs-lookup"><span data-stu-id="3a96f-118">(If the control has only secondary items, they are shown in a way similar to the MenuFlyout control.)</span></span>

| **<span data-ttu-id="3a96f-119">Windows UI のライブラリを入手します。</span><span class="sxs-lookup"><span data-stu-id="3a96f-119">Get the Windows UI Library</span></span>** |
| - |
| <span data-ttu-id="3a96f-120">このコントロールは、Windows UI のライブラリ、新しいコントロールと UWP アプリの UI の機能が含まれている NuGet パッケージの一部として含まれています。</span><span class="sxs-lookup"><span data-stu-id="3a96f-120">This control is included as part of the Windows UI Library, a NuGet package that contains new controls and UI features for UWP apps.</span></span> <span data-ttu-id="3a96f-121">詳しくなどのインストール手順については、 [Windows UI のライブラリの概要](https://docs.microsoft.com/uwp/toolkits/winui/)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3a96f-121">For more info, including installation instructions, see the [Windows UI Library overview](https://docs.microsoft.com/uwp/toolkits/winui/).</span></span> |

| **<span data-ttu-id="3a96f-122">プラットフォーム Api</span><span class="sxs-lookup"><span data-stu-id="3a96f-122">Platform APIs</span></span>** | **<span data-ttu-id="3a96f-123">Windows UI ライブラリ Api</span><span class="sxs-lookup"><span data-stu-id="3a96f-123">Windows UI Library APIs</span></span>** |
| - | - |
| <span data-ttu-id="3a96f-124">[CommandBarFlyout クラス](/uwp/api/windows.ui.xaml.controls.commandbarflyout)、 [TextCommandBarFlyout クラス](/uwp/api/windows.ui.xaml.controls.textcommandbarflyout)、 [AppBarButton クラス](/uwp/api/windows.ui.xaml.controls.appbarbutton)、 [AppBarToggleButton クラス](/uwp/api/windows.ui.xaml.controls.appbartogglebutton)、 [AppBarSeparator クラス](/uwp/api/windows.ui.xaml.controls.appbarseparator)</span><span class="sxs-lookup"><span data-stu-id="3a96f-124">[CommandBarFlyout class](/uwp/api/windows.ui.xaml.controls.commandbarflyout), [TextCommandBarFlyout class](/uwp/api/windows.ui.xaml.controls.textcommandbarflyout), [AppBarButton class](/uwp/api/windows.ui.xaml.controls.appbarbutton), [AppBarToggleButton class](/uwp/api/windows.ui.xaml.controls.appbartogglebutton), [AppBarSeparator class](/uwp/api/windows.ui.xaml.controls.appbarseparator)</span></span> | <span data-ttu-id="3a96f-125">[CommandBarFlyout クラス](/uwp/api/microsoft.ui.xaml.controls.commandbarflyout)、 [TextCommandBarFlyout クラス](/uwp/api/microsoft.ui.xaml.controls.textcommandbarflyout)</span><span class="sxs-lookup"><span data-stu-id="3a96f-125">[CommandBarFlyout class](/uwp/api/microsoft.ui.xaml.controls.commandbarflyout), [TextCommandBarFlyout class](/uwp/api/microsoft.ui.xaml.controls.textcommandbarflyout)</span></span> |

## <a name="is-this-the-right-control"></a><span data-ttu-id="3a96f-126">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="3a96f-126">Is this the right control?</span></span>

<span data-ttu-id="3a96f-127">メニュー項目は、アプリのキャンバス上の要素のコンテキストでボタンなど、ユーザーにコマンドのコレクションを表示するには、CommandBarFlyout コントロールを使います。</span><span class="sxs-lookup"><span data-stu-id="3a96f-127">Use the CommandBarFlyout control to show a collection of commands to the user, such as buttons and menu items, in the context of an element on the app canvas.</span></span>

<span data-ttu-id="3a96f-128">TextCommandBarFlyout では、TextBox、TextBlock、RichEditBox、RichTextBlock、および PasswordBox のコントロールでテキスト コマンドが表示されます。</span><span class="sxs-lookup"><span data-stu-id="3a96f-128">The TextCommandBarFlyout displays text commands in TextBox, TextBlock, RichEditBox, RichTextBlock, and PasswordBox controls.</span></span> <span data-ttu-id="3a96f-129">コマンドは現在のテキストの選択に自動的に適切に構成します。</span><span class="sxs-lookup"><span data-stu-id="3a96f-129">The commands are automatically configured appropriately to the current text selection.</span></span> <span data-ttu-id="3a96f-130">テキスト コントロールの既定のテキストのコマンドを置換するのに、CommandBarFlyout を使用します。</span><span class="sxs-lookup"><span data-stu-id="3a96f-130">Use a CommandBarFlyout to replace the default text commands on text controls.</span></span>

<span data-ttu-id="3a96f-131">コンテキストを表示するには、リスト項目でのコマンドは[コマンドのコレクションとリストの実行コンテキスト](collection-commanding.md)のガイダンスに従います。</span><span class="sxs-lookup"><span data-stu-id="3a96f-131">To show contextual commands on list items follow the guidance in [Contextual commanding for collections and lists](collection-commanding.md).</span></span>

### <a name="commandbarflyout-vs-menuflyout"></a><span data-ttu-id="3a96f-132">CommandBarFlyout vs MenuFlyout</span><span class="sxs-lookup"><span data-stu-id="3a96f-132">CommandBarFlyout vs MenuFlyout</span></span>

<span data-ttu-id="3a96f-133">コンテキスト メニューにコマンドを表示するには、CommandBarFlyout または MenuFlyout を使用できます。</span><span class="sxs-lookup"><span data-stu-id="3a96f-133">To show commands in a context menu, you can use CommandBarFlyout or MenuFlyout.</span></span> <span data-ttu-id="3a96f-134">MenuFlyout よりもさらに機能を提供するため CommandBarFlyout をお勧めします。</span><span class="sxs-lookup"><span data-stu-id="3a96f-134">We recommend CommandBarFlyout because it provides more functionality than MenuFlyout.</span></span> <span data-ttu-id="3a96f-135">セカンダリ コマンドのみを使った CommandBarFlyout を使用するには、動作を取得して、MenuFlyout の検索、またはプライマリおよびセカンダリの両方のコマンドで完全なコマンド バーのポップアップを使用します。</span><span class="sxs-lookup"><span data-stu-id="3a96f-135">You can use CommandBarFlyout with only secondary commands to get the behavior and look of a MenuFlyout, or use the full command bar flyout with both primary and secondary commands.</span></span>

## <a name="examples"></a><span data-ttu-id="3a96f-136">例</span><span class="sxs-lookup"><span data-stu-id="3a96f-136">Examples</span></span>

<table>
<th align="left"><span data-ttu-id="3a96f-137">XAML コントロール ギャラリー</span><span class="sxs-lookup"><span data-stu-id="3a96f-137">XAML Controls Gallery</span></span><th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><span data-ttu-id="3a96f-138"><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong>アプリがインストールされている場合、こちらをクリックして<a href="xamlcontrolsgallery:/item/CommandBarFlyout">、アプリを開き CommandBarFlyout の動作をご覧ください</a>。</span><span class="sxs-lookup"><span data-stu-id="3a96f-138">If you have the <strong style="font-weight: semi-bold">XAML Controls Gallery</strong> app installed, click here to <a href="xamlcontrolsgallery:/item/CommandBarFlyout">open the app and see the CommandBarFlyout in action</a>.</span></span></p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT"><span data-ttu-id="3a96f-139">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</span><span class="sxs-lookup"><span data-stu-id="3a96f-139">Get the XAML Controls Gallery app (Microsoft Store)</span></span></a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics"><span data-ttu-id="3a96f-140">ソース コード (GitHub) を入手する</span><span class="sxs-lookup"><span data-stu-id="3a96f-140">Get the source code (GitHub)</span></span></a></li>
    </ul>
</td>
</tr>
</table>

## <a name="proactive-vs-reactive-invocation"></a><span data-ttu-id="3a96f-141">事後対応型の呼び出しと事前対応型</span><span class="sxs-lookup"><span data-stu-id="3a96f-141">Proactive vs. reactive invocation</span></span>

<span data-ttu-id="3a96f-142">ポップアップや、UI のキャンバス上の要素に関連付けられているメニューを呼び出すために 2 つの方法は通常:_事前の呼び出し_と_事後対応型の呼び出し_です。</span><span class="sxs-lookup"><span data-stu-id="3a96f-142">There are typically two ways to invoke a flyout or menu that's associated with an element on your UI canvas: _proactive invocation_ and _reactive invocation_.</span></span>

<span data-ttu-id="3a96f-143">コマンドは事前対応型の呼び出しでは、ユーザーがコマンドに関連付けられている項目を操作する自動的に表示します。</span><span class="sxs-lookup"><span data-stu-id="3a96f-143">In proactive invocation, commands appear automatically when the user interacts with the item that the commands are associated with.</span></span> <span data-ttu-id="3a96f-144">たとえば、テキストの書式設定コマンド可能性がありますがポップアップ、ユーザーがテキスト ボックスのテキストを選択します。</span><span class="sxs-lookup"><span data-stu-id="3a96f-144">For example, text formatting commands might pop up when the user selects text in a text box.</span></span> <span data-ttu-id="3a96f-145">この例では、コマンド バーのポップアップでは、フォーカスは実行されません。</span><span class="sxs-lookup"><span data-stu-id="3a96f-145">In this case, the command bar flyout does not take focus.</span></span> <span data-ttu-id="3a96f-146">代わりに、ユーザーが操作の項目に近い関連するコマンドを表示します。</span><span class="sxs-lookup"><span data-stu-id="3a96f-146">Instead, it presents relevant commands close to the item the user is interacting with.</span></span> <span data-ttu-id="3a96f-147">場合は、ユーザーは、コマンドを操作しない、それらが閉じられます。</span><span class="sxs-lookup"><span data-stu-id="3a96f-147">If the user doesn't interact with the commands, they are dismissed.</span></span>

<span data-ttu-id="3a96f-148">事後対応型の呼び出しでコマンドは表示、明示的なユーザー操作への応答でコマンドを要求するにはたとえば、右クリックします。</span><span class="sxs-lookup"><span data-stu-id="3a96f-148">In reactive invocation, commands are shown in response to an explicit user action to request the commands; for example, a right-click.</span></span> <span data-ttu-id="3a96f-149">これは、[コンテキスト メニュー](menus.md)の従来の概念に対応します。</span><span class="sxs-lookup"><span data-stu-id="3a96f-149">This corresponds to the traditional concept of a [context menu](menus.md).</span></span>

<span data-ttu-id="3a96f-150">により、または、2 つを組み合わせてのいずれかで CommandBarFlyout を使用することができます。</span><span class="sxs-lookup"><span data-stu-id="3a96f-150">You can use the CommandBarFlyout in either way, or even a mixture of the two.</span></span>

## <a name="create-a-command-bar-flyout"></a><span data-ttu-id="3a96f-151">コマンド バーのポップアップを作成します。</span><span class="sxs-lookup"><span data-stu-id="3a96f-151">Create a command bar flyout</span></span>

> <span data-ttu-id="3a96f-152">**プレビュー**: CommandBarFlyout[最新の Windows 10 Insider Preview ビルドと SDK](https://insider.windows.com/for-developers/)または[Windows UI のライブラリ](https://docs.microsoft.com/uwp/toolkits/winui/)が必要です。</span><span class="sxs-lookup"><span data-stu-id="3a96f-152">**Preview**: CommandBarFlyout requires the [latest Windows 10 Insider Preview build and SDK](https://insider.windows.com/for-developers/) or the [Windows UI Library](https://docs.microsoft.com/uwp/toolkits/winui/).</span></span>

<span data-ttu-id="3a96f-153">この例では、コマンド バーのポップアップを作成し、事前と事後対応的に使用する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="3a96f-153">This example shows how to create a command bar flyout and use it both proactively and reactively.</span></span> <span data-ttu-id="3a96f-154">画像をタップすると、ポップアップは折りたたまれているモードで表示されます。</span><span class="sxs-lookup"><span data-stu-id="3a96f-154">When the image is tapped, the flyout is shown in its collapsed mode.</span></span> <span data-ttu-id="3a96f-155">表示されるとき、コンテキスト メニューとして、その拡張モードで、ポップアップが表示されます。</span><span class="sxs-lookup"><span data-stu-id="3a96f-155">When shown as a context menu, the flyout is shown in its expanded mode.</span></span> <span data-ttu-id="3a96f-156">どちらの場合、ユーザーに展開またはに開いた後、ポップアップを縮小できます。</span><span class="sxs-lookup"><span data-stu-id="3a96f-156">In either case, the user can expand or collapse the flyout after it's opened.</span></span>

:::row:::
    :::column:::
        <span data-ttu-id="3a96f-157">折りたたまれているコマンド バーのポップアップ</span><span class="sxs-lookup"><span data-stu-id="3a96f-157">A collapsed command bar flyout</span></span><br/>
        ![折りたたまれているコマンド バーのポップアップの例](images/command-bar-flyout-img-collapsed.png)
    :::column-end:::
    :::column:::
        <span data-ttu-id="3a96f-159">展開されたコマンド バーのポップアップ</span><span class="sxs-lookup"><span data-stu-id="3a96f-159">An expanded command bar flyout</span></span><br/>
        ![展開されたコマンド バーのポップアップの例](images/command-bar-flyout-img-expanded.png)
    :::column-end:::
:::row-end:::

```xaml
<Grid>
    <Grid.Resources>
        <CommandBarFlyout x:Name="ImageCommandsFlyout">
            <AppBarButton Icon="OutlineStar" ToolTipService.ToolTip="Favorite"/>
            <AppBarButton Icon="Copy" ToolTipService.ToolTip="Copy"/>
            <AppBarButton Icon="Share" ToolTipService.ToolTip="Share"/>
            <CommandBarFlyout.SecondaryCommands>
                <AppBarButton Label="Rotate" Icon="Rotate"/>
                <AppBarButton Label="Delete" Icon="Delete"/>
            </CommandBarFlyout.SecondaryCommands>
        </CommandBarFlyout>
    </Grid.Resources>

    <Image Source="Assets/licorice.png" Width="300"
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

### <a name="show-commands-proactively"></a><span data-ttu-id="3a96f-161">事前にコマンドを表示します。</span><span class="sxs-lookup"><span data-stu-id="3a96f-161">Show commands proactively</span></span>

<span data-ttu-id="3a96f-162">事前にコンテキスト コマンドを表示すると、プライマリ コマンドのみする必要があります (コマンド バーのポップアップを解除する必要があります) を既定で表示されます。</span><span class="sxs-lookup"><span data-stu-id="3a96f-162">When you show contextual commands proactively, only the primary commands should be shown by default (the command bar flyout should be collapsed).</span></span> <span data-ttu-id="3a96f-163">プライマリ コマンドのコレクション、およびされる従来のコンテキスト メニューで、セカンダリ コマンドのコレクションに追加のコマンドで最も重要なコマンドを配置します。</span><span class="sxs-lookup"><span data-stu-id="3a96f-163">Place the most important commands in the primary commands collection, and additional commands that would traditionally go in a context menu into the secondary commands collection.</span></span>

<span data-ttu-id="3a96f-164">コマンドを事前に表示するには、コマンド バーのポップアップを表示する] を[クリックして](/uwp/api/windows.ui.xaml.controls.primitives.buttonbase.click)または[Tapped](/uwp/api/windows.ui.xaml.uielement.tapped)イベントを処理する通常します。</span><span class="sxs-lookup"><span data-stu-id="3a96f-164">To proactively show commands, you typically handle the [Click](/uwp/api/windows.ui.xaml.controls.primitives.buttonbase.click) or [Tapped](/uwp/api/windows.ui.xaml.uielement.tapped) event to show the command bar flyout.</span></span> <span data-ttu-id="3a96f-165">**一時的な**または**TransientWithDismissOnPointerMoveAway**折りたたまれているモードでフォーカスを移動することがなく、ポップアップを開くには、ポップアップの[ShowMode](/uwp/api/windows.ui.xaml.controls.primitives.flyoutbase.showmode)を設定します。</span><span class="sxs-lookup"><span data-stu-id="3a96f-165">Set the flyout's [ShowMode](/uwp/api/windows.ui.xaml.controls.primitives.flyoutbase.showmode) to **Transient** or **TransientWithDismissOnPointerMoveAway** to open the flyout in its collapsed mode without taking focus.</span></span>

<span data-ttu-id="3a96f-166">Windows 10 Insider preview 以降は、テキスト コントロールを使うと、 **SelectionFlyout**プロパティがあります。</span><span class="sxs-lookup"><span data-stu-id="3a96f-166">Starting in the Windows 10 Insider Preview, text controls have a **SelectionFlyout** property.</span></span> <span data-ttu-id="3a96f-167">ポップアップをこのプロパティに割り当てるとテキストが選択されると自動的に表示されます。</span><span class="sxs-lookup"><span data-stu-id="3a96f-167">When you assign a flyout to this property, it is automatically shown when text is selected.</span></span>

### <a name="show-commands-reactively"></a><span data-ttu-id="3a96f-168">事後対応的にコマンドを表示します。</span><span class="sxs-lookup"><span data-stu-id="3a96f-168">Show commands reactively</span></span>

<span data-ttu-id="3a96f-169">事後対応的、コンテキスト メニューとコンテキスト コマンドを表示すると、既定では (コマンド バーのポップアップを展開する必要があります)、セカンダリ コマンドが表示されます。</span><span class="sxs-lookup"><span data-stu-id="3a96f-169">When you show contextual commands reactively, as a context menu, the secondary commands are shown by default (the command bar flyout should be expanded).</span></span> <span data-ttu-id="3a96f-170">この例では、コマンド バーのポップアップには、プライマリおよびセカンダリの両方のコマンド、またはセカンダリ コマンドのみがあります。</span><span class="sxs-lookup"><span data-stu-id="3a96f-170">In this case, the command bar flyout might have both primary and secondary commands, or secondary commands only.</span></span>

<span data-ttu-id="3a96f-171">コンテキスト メニューにコマンドを表示するには、通常に UI 要素の[ContextFlyout](/uwp/api/windows.ui.xaml.uielement.contextflyout)プロパティに、ポップアップを割り当てます。</span><span class="sxs-lookup"><span data-stu-id="3a96f-171">To show commands in a context menu, you typically assign the flyout to the [ContextFlyout](/uwp/api/windows.ui.xaml.uielement.contextflyout) property of a UI element.</span></span> <span data-ttu-id="3a96f-172">これによりは、要素によって処理されますが、ポップアップを開くと、特に何もする必要はありません。</span><span class="sxs-lookup"><span data-stu-id="3a96f-172">This way, opening the flyout is handled by the element, and you don't need to do anything more.</span></span>

<span data-ttu-id="3a96f-173">(たとえば、 [RightTapped](/uwp/api/windows.ui.xaml.uielement.righttapped)イベント) で、ポップアップを自分で表示を処理する場合は、設定、**標準的な**展開モードで、ポップアップを開き、フォーカスを設定するには、ポップアップの[ShowMode](/uwp/api/windows.ui.xaml.controls.primitives.flyoutbase.showmode)します。</span><span class="sxs-lookup"><span data-stu-id="3a96f-173">If you handle showing the flyout yourself (for example, on a [RightTapped](/uwp/api/windows.ui.xaml.uielement.righttapped) event), set the the flyout's [ShowMode](/uwp/api/windows.ui.xaml.controls.primitives.flyoutbase.showmode) to **Standard** to open the flyout in its expanded mode and give it focus.</span></span>

> [!TIP]
> <span data-ttu-id="3a96f-174">ポップアップの配置を制御する方法と、ポップアップを表示するときのオプションについて詳しくは、[ポップアップ](../controls-and-patterns/dialogs-and-flyouts/flyouts.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="3a96f-174">For more info about options when showing a flyout and how to control placement of the flyout, see [Flyouts](../controls-and-patterns/dialogs-and-flyouts/flyouts.md).</span></span>

## <a name="commands-and-content"></a><span data-ttu-id="3a96f-175">コマンドとコンテンツ</span><span class="sxs-lookup"><span data-stu-id="3a96f-175">Commands and content</span></span>

<span data-ttu-id="3a96f-176">CommandBarFlyout コントロールは、コマンドとコンテンツを追加するのに使用できる 2 つのプロパティを持つ: [PrimaryCommands](/uwp/api/windows.ui.xaml.controls.commandbarflyout.primarycommands)と[SecondaryCommands](/uwp/api/windows.ui.xaml.controls.commandbarflyout.secondarycommands)にします。</span><span class="sxs-lookup"><span data-stu-id="3a96f-176">The CommandBarFlyout control has 2 properties you can use to add commands and content: [PrimaryCommands](/uwp/api/windows.ui.xaml.controls.commandbarflyout.primarycommands) and [SecondaryCommands](/uwp/api/windows.ui.xaml.controls.commandbarflyout.secondarycommands).</span></span>

<span data-ttu-id="3a96f-177">既定では、コマンド バーの項目は **PrimaryCommands** コレクションに追加されます。</span><span class="sxs-lookup"><span data-stu-id="3a96f-177">By default, command bar items are added to the **PrimaryCommands** collection.</span></span> <span data-ttu-id="3a96f-178">これらのコマンドでは、コマンド バーは表示され、折りたたまれていると、展開モードの両方に表示されます。</span><span class="sxs-lookup"><span data-stu-id="3a96f-178">These commands are shown in the command bar and are visible in both the collapsed and expanded modes.</span></span> <span data-ttu-id="3a96f-179">CommandBar とは異なり、プライマリ コマンドは自動的にセカンダリ コマンドをオーバーフローではないと切り詰められている可能性があります。</span><span class="sxs-lookup"><span data-stu-id="3a96f-179">Unlike CommandBar, primary commands do not automatically overflow to the secondary commands and might be truncated.</span></span>

<span data-ttu-id="3a96f-180">コマンドは**SecondaryCommands**コレクションに追加することもできます。</span><span class="sxs-lookup"><span data-stu-id="3a96f-180">You can also add commands to the **SecondaryCommands** collection.</span></span> <span data-ttu-id="3a96f-181">セカンダリ コマンドは、コントロールのメニューの部分では表示され、展開モードでのみ表示されます。</span><span class="sxs-lookup"><span data-stu-id="3a96f-181">Secondary commands are shown in the menu portion of the control and are visible only in the expanded mode.</span></span>

### <a name="app-bar-buttons"></a><span data-ttu-id="3a96f-182">アプリ バーのボタン</span><span class="sxs-lookup"><span data-stu-id="3a96f-182">App bar buttons</span></span>

<span data-ttu-id="3a96f-183">[AppBarButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbarbutton.aspx)、 [AppBarToggleButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbartogglebutton.aspx)、 [AppBarSeparator](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbarseparator.aspx)コントロールを直接 PrimaryCommands と SecondaryCommands を設定することができます。</span><span class="sxs-lookup"><span data-stu-id="3a96f-183">You can populate the PrimaryCommands and SecondaryCommands directly with [AppBarButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbarbutton.aspx), [AppBarToggleButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbartogglebutton.aspx), and [AppBarSeparator](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbarseparator.aspx) controls.</span></span>

<span data-ttu-id="3a96f-184">アプリ バーのボタン コントロールは、アイコンとテキスト ラベルによって特徴付けられます。</span><span class="sxs-lookup"><span data-stu-id="3a96f-184">The app bar button controls are characterized by an icon and text label.</span></span> <span data-ttu-id="3a96f-185">これらのコントロールは、コマンド バーで使用向けに最適化され、コマンド バーやオーバーフロー メニューで、コントロールを表示するかどうかに応じて外観が変化します。</span><span class="sxs-lookup"><span data-stu-id="3a96f-185">These controls are optimized for use in a command bar, and their appearance changes depending on whether the control is shown in the command bar or the overflow menu.</span></span>

- <span data-ttu-id="3a96f-186">プライマリ コマンドとして使われるアプリ バーのボタンは、アイコンのみを含むコマンド バーに表示されます。テキスト ラベルは表示されません。</span><span class="sxs-lookup"><span data-stu-id="3a96f-186">App bar buttons used as primary commands are shown in the command bar with only their icon; the text label is not shown.</span></span> <span data-ttu-id="3a96f-187">次に示すようにコマンドの説明のテキストを表示するヒントを使用することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="3a96f-187">We recommend that you use a tooltip to show a text description of the command, as shown here.</span></span>
    ```xaml
    <AppBarButton Icon="Copy" ToolTipService.ToolTip="Copy"/>
    ```
- <span data-ttu-id="3a96f-188">アプリ バーのボタンとしてセカンダリ コマンド使用は、ラベルとアイコンが表示されると、メニューに表示されます。</span><span class="sxs-lookup"><span data-stu-id="3a96f-188">App bar buttons used as secondary commands are shown in the menu, with both the label and icon visible.</span></span>

### <a name="other-content"></a><span data-ttu-id="3a96f-189">その他のコンテンツ</span><span class="sxs-lookup"><span data-stu-id="3a96f-189">Other content</span></span>

<span data-ttu-id="3a96f-190">コマンド バーのポップアップを他のコントロールを追加するには、AppBarElementContainer でラップします。</span><span class="sxs-lookup"><span data-stu-id="3a96f-190">You can add other controls to a command bar flyout by wrapping them in an AppBarElementContainer.</span></span> <span data-ttu-id="3a96f-191">これにより[DropDownButton]() [SplitButton]()などのコントロールを追加したりより複雑な UI を作成するために[StackPanel]()などのコンテナーを追加できます。</span><span class="sxs-lookup"><span data-stu-id="3a96f-191">This lets you add controls like [DropDownButton]() or [SplitButton](), or add containers like [StackPanel]() to create more complex UI.</span></span>

> [!NOTE]
> <span data-ttu-id="3a96f-192">コマンド バーのポップアップのプライマリまたはセカンダリ コマンドのコレクションに追加するためには、要素は、 [ICommandBarElement](/uwp/api/windows.ui.xaml.controls.icommandbarelement)インターフェイスを実装する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3a96f-192">In order to be added to the primary or secondary command collections of a command bar flyout, an element must implement the [ICommandBarElement](/uwp/api/windows.ui.xaml.controls.icommandbarelement) interface.</span></span> <span data-ttu-id="3a96f-193">AppBarElementContainer は、ラッパー自体インターフェイスを実装していない場合でも、コマンド バーに要素を追加できるように、このインターフェイスを実装します。</span><span class="sxs-lookup"><span data-stu-id="3a96f-193">AppBarElementContainer is a wrapper that implements this interface so you can add an element to a command bar even if it doesn't implement the interface itself.</span></span>

<span data-ttu-id="3a96f-194">ここでは、AppBarElementContainer を使用して、コマンド バーのポップアップに余分な要素を追加できます。</span><span class="sxs-lookup"><span data-stu-id="3a96f-194">Here, an AppBarElementContainer is used to add extra elements to a command bar flyout.</span></span> <span data-ttu-id="3a96f-195">SplitButton は、色の選択を許可するプライマリ コマンドに追加されます。</span><span class="sxs-lookup"><span data-stu-id="3a96f-195">A SplitButton is added to the primary commands to allow selection of colors.</span></span> <span data-ttu-id="3a96f-196">StackPanel より複雑なズーム コントロールのレイアウトを許可するセカンダリ コマンドに追加されます。</span><span class="sxs-lookup"><span data-stu-id="3a96f-196">A StackPanel is added to the secondary commands to allow a more complex layout for zoom controls.</span></span>

> [!NOTE]
> <span data-ttu-id="3a96f-197">この例では、表示されるコマンドのいずれかが実装していないのみ、コマンド バーのポップアップ UI を示します。</span><span class="sxs-lookup"><span data-stu-id="3a96f-197">This example shows only the command bar flyout UI, it does not implement any of the commands that are shown.</span></span> <span data-ttu-id="3a96f-198">コマンドの実装について詳しくは、[ボタン](buttons.md)や[コマンド設計の基本](../basics/commanding-basics.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3a96f-198">For more info about implementing the commands, see [Buttons](buttons.md) and [Command design basics](../basics/commanding-basics.md).</span></span>

:::row:::
    :::column:::
        <span data-ttu-id="3a96f-199">Open の SplitButton と折りたたまれているコマンド バーのポップアップ</span><span class="sxs-lookup"><span data-stu-id="3a96f-199">A collapsed command bar flyout with an open SplitButton</span></span><br/>
        ![分割ボタンと共に、コマンド バーのポップアップ](images/command-bar-flyout-split-button.png)
    :::column-end:::
    :::column:::
        <span data-ttu-id="3a96f-201">カスタム ズーム UI、メニューで、展開されたコマンド バーのポップアップ</span><span class="sxs-lookup"><span data-stu-id="3a96f-201">An expanded command bar flyout with custom zoom UI in the menu</span></span><br/>
        ![複雑な UI とコマンド バーのポップアップ](images/command-bar-flyout-complex-ui.png)
    :::column-end:::
:::row-end:::

```xaml
<CommandBarFlyout>
    <AppBarButton Icon="Cut" ToolTipService.ToolTip="Cut"/>
    <AppBarButton Icon="Copy" ToolTipService.ToolTip="Copy"/>
    <AppBarButton Icon="Paste" ToolTipService.ToolTip="Paste"/>
    <!-- Color controls -->
    <AppBarElementContainer>
        <SplitButton Height="Auto" Margin="0,4,0,0"
                     ToolTipService.ToolTip="Colors"
                     Background="{ThemeResource AppBarItemBackgroundThemeBrush}">
            <SplitButton.Content>
                <Rectangle Width="20" Height="20">
                    <Rectangle.Fill>
                        <SolidColorBrush Color="Red"/>
                    </Rectangle.Fill>
                </Rectangle>
            </SplitButton.Content>
            <SplitButton.Flyout>
                <MenuFlyout>
                    <MenuFlyoutItem Text="Red"/>
                    <MenuFlyoutItem Text="Yellow"/>
                    <MenuFlyoutItem Text="Green"/>
                    <MenuFlyoutItem Text="Blue"/>
                </MenuFlyout>
            </SplitButton.Flyout>
        </SplitButton>
    </AppBarElementContainer>
    <!-- end Color controls -->
    <CommandBarFlyout.SecondaryCommands>
        <!-- Zoom controls -->
        <AppBarElementContainer>
            <AppBarElementContainer.Resources>
                <Style TargetType="Button">
                    <Setter Property="Background"
                            Value="{ThemeResource AppBarItemBackgroundThemeBrush}"/>
                </Style>
                <Style TargetType="TextBlock">
                    <Setter Property="VerticalAlignment" Value="Center"/>
                </Style>
            </AppBarElementContainer.Resources>
            <Grid Margin="12,0">
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width="86"/>
                    <ColumnDefinition Width="Auto"/>
                </Grid.ColumnDefinitions>
                <TextBlock Text="Zoom"/>
                <StackPanel Orientation="Horizontal" Grid.Column="1">
                    <Button>
                        <SymbolIcon Symbol="Remove"/>
                    </Button>
                    <TextBlock Text="50%" Width="40"
                               HorizontalTextAlignment="Center"/>
                    <Button>
                        <SymbolIcon Symbol="Add"/>
                    </Button>
                </StackPanel>
            </Grid>
        </AppBarElementContainer>
        <!-- end Zoom controls -->
        <AppBarSeparator/>
        <AppBarButton Label="Undo" Icon="Undo"/>
        <AppBarButton Label="Redo" Icon="Redo"/>
        <AppBarButton Label="Select all"/>
    </CommandBarFlyout.SecondaryCommands>
</CommandBarFlyout>
```

## <a name="create-a-context-menu-with-secondary-commands-only"></a><span data-ttu-id="3a96f-203">セカンダリ コマンドのみを使って、コンテキスト メニューを作成します。</span><span class="sxs-lookup"><span data-stu-id="3a96f-203">Create a context menu with secondary commands only</span></span>

<span data-ttu-id="3a96f-204">[コンテキスト メニュー](menus.md)MenuFlyout の代わりとして、セカンダリ コマンドのみを使って、CommandBarFlyout を使用できます。</span><span class="sxs-lookup"><span data-stu-id="3a96f-204">You can use a CommandBarFlyout with only secondary commands as a [context menu](menus.md), in place of a MenuFlyout.</span></span>

![セカンダリ コマンドのみを使って、コマンド バーのポップアップ](images/command-bar-flyout-context-menu.png)

```xaml
<Grid>
    <Grid.Resources>
        <!-- A command bar flyout with only secondary commands. -->
        <CommandBarFlyout x:Name="ContextMenu">
            <CommandBarFlyout.SecondaryCommands>
                <AppBarButton Label="Pin" Icon="Pin"/>
                <AppBarButton Label="Unpin" Icon="UnPin"/>
                <AppBarButton Label="Copy" Icon="Copy"/>
                <AppBarSeparator />
                <AppBarButton Label="Properties"/>
            </CommandBarFlyout.SecondaryCommands>
        </CommandBarFlyout>
    </Grid.Resources>

    <Image Source="Assets/licorice.png" Width="300"
           ContextFlyout="{x:Bind ContextMenu}"/>
</Grid>
```

<span data-ttu-id="3a96f-206">標準的なメニューを作成するのに、DropDownButton で、CommandBarFlyout を使用することもできます。</span><span class="sxs-lookup"><span data-stu-id="3a96f-206">You can also use a CommandBarFlyout with a DropDownButton to create a standard menu.</span></span>

![ドロップダウン メニューのボタンとしてとコマンド バー ポップアップ](images/command-bar-flyout-button-menu.png)

```xaml
<DropDownButton Content="Mail">
    <DropDownButton.Flyout>
        <CommandBarFlyout Placement="BottomEdgeAlignedLeft">
            <CommandBarFlyout.SecondaryCommands>
                <AppBarButton Icon="MailForward" Label="Forward"/>
                <AppBarButton Icon="MailReply" Label="Reply"/>
                <AppBarButton Icon="MailReplyAll" Label="Reply all"/>
            </CommandBarFlyout.SecondaryCommands>
        </CommandBarFlyout>
    </DropDownButton.Flyout>
</DropDownButton>
```

## <a name="command-bar-flyouts-for-text-controls"></a><span data-ttu-id="3a96f-208">テキスト コントロールのコマンド バーのポップアップ</span><span class="sxs-lookup"><span data-stu-id="3a96f-208">Command bar flyouts for text controls</span></span>

<span data-ttu-id="3a96f-209">[TextCommandBarFlyout](/uwp/api/microsoft.ui.xaml.controls.textcommandbarflyout)は、テキスト編集のためのコマンドが含まれている特殊なコマンド バーのポップアップです。</span><span class="sxs-lookup"><span data-stu-id="3a96f-209">The [TextCommandBarFlyout](/uwp/api/microsoft.ui.xaml.controls.textcommandbarflyout) is a specialized command bar flyout that contains commands for editing text.</span></span> <span data-ttu-id="3a96f-210">各テキスト コントロールは、コンテキスト メニュー (右クリック)、またはテキストが選択されると自動的に、TextCommandBarFlyout を示します。</span><span class="sxs-lookup"><span data-stu-id="3a96f-210">Each text control shows the TextCommandBarFlyout automatically as a context menu (right-click), or when text is selected.</span></span> <span data-ttu-id="3a96f-211">テキストのコマンド バーのポップアップにのみ関連するコマンドを表示テキストの選択に合わせて変化します。</span><span class="sxs-lookup"><span data-stu-id="3a96f-211">The text command bar flyout adapts to the text selection to only show relevant commands.</span></span>

:::row:::
    :::column:::
        <span data-ttu-id="3a96f-212">テキストの選択では、テキスト コマンド バー ポップアップ</span><span class="sxs-lookup"><span data-stu-id="3a96f-212">A text command bar flyout on text selection</span></span><br/>
        ![折りたたまれているテキスト コマンド バーのポップアップ](images/command-bar-flyout-text-selection.png)
    :::column-end:::
    :::column:::
        <span data-ttu-id="3a96f-214">展開されたテキスト、コマンド バー ポップアップ</span><span class="sxs-lookup"><span data-stu-id="3a96f-214">An expanded text command bar flyout</span></span><br/>
        ![展開されたテキスト、コマンド バー ポップアップ](images/command-bar-flyout-text-full.png)
    :::column-end:::
:::row-end:::

### <a name="available-commands"></a><span data-ttu-id="3a96f-216">利用可能なコマンド</span><span class="sxs-lookup"><span data-stu-id="3a96f-216">Available commands</span></span>

<span data-ttu-id="3a96f-217">次の表は、TextCommandBarFlyout と表示されるときに含まれているコマンドを示します。</span><span class="sxs-lookup"><span data-stu-id="3a96f-217">This table shows the commands that are included in a TextCommandBarFlyout, and when they are shown.</span></span>

| <span data-ttu-id="3a96f-218">コマンド</span><span class="sxs-lookup"><span data-stu-id="3a96f-218">Command</span></span> | <span data-ttu-id="3a96f-219">表示されます。</span><span class="sxs-lookup"><span data-stu-id="3a96f-219">Shown...</span></span> |
| ------- | -------- |
| <span data-ttu-id="3a96f-220">Bold</span><span class="sxs-lookup"><span data-stu-id="3a96f-220">Bold</span></span> | <span data-ttu-id="3a96f-221">テキスト コントロールは読み取り専用 (RichEditBox のみ) ではありません。</span><span class="sxs-lookup"><span data-stu-id="3a96f-221">when the text control is not read-only (RichEditBox only).</span></span> |
| <span data-ttu-id="3a96f-222">Italic</span><span class="sxs-lookup"><span data-stu-id="3a96f-222">Italic</span></span> | <span data-ttu-id="3a96f-223">テキスト コントロールは読み取り専用 (RichEditBox のみ) ではありません。</span><span class="sxs-lookup"><span data-stu-id="3a96f-223">when the text control is not read-only (RichEditBox only).</span></span> |
| <span data-ttu-id="3a96f-224">Underline</span><span class="sxs-lookup"><span data-stu-id="3a96f-224">Underline</span></span> | <span data-ttu-id="3a96f-225">テキスト コントロールは読み取り専用 (RichEditBox のみ) ではありません。</span><span class="sxs-lookup"><span data-stu-id="3a96f-225">when the text control is not read-only (RichEditBox only).</span></span> |
| <span data-ttu-id="3a96f-226">証明</span><span class="sxs-lookup"><span data-stu-id="3a96f-226">Proofing</span></span> | <span data-ttu-id="3a96f-227">IsSpellCheckEnabled が**true**で、スペルに誤りがある場合は、テキストが選択されます。</span><span class="sxs-lookup"><span data-stu-id="3a96f-227">when IsSpellCheckEnabled is **true** and misspelled text is selected.</span></span> |
| <span data-ttu-id="3a96f-228">切り取り</span><span class="sxs-lookup"><span data-stu-id="3a96f-228">Cut</span></span> | <span data-ttu-id="3a96f-229">テキスト コントロールは読み取り専用ではないとテキストが選択されます。</span><span class="sxs-lookup"><span data-stu-id="3a96f-229">when the text control is not read-only and text is selected.</span></span> |
| <span data-ttu-id="3a96f-230">コピー</span><span class="sxs-lookup"><span data-stu-id="3a96f-230">Copy</span></span> | <span data-ttu-id="3a96f-231">テキストが選択されている場合。</span><span class="sxs-lookup"><span data-stu-id="3a96f-231">when text is selected.</span></span> |
| <span data-ttu-id="3a96f-232">貼り付け</span><span class="sxs-lookup"><span data-stu-id="3a96f-232">Paste</span></span> | <span data-ttu-id="3a96f-233">テキスト コントロールは読み取り専用ではないとクリップボードがコンテンツです。</span><span class="sxs-lookup"><span data-stu-id="3a96f-233">when the text control is not read-only and the clipboard has content.</span></span> |
| <span data-ttu-id="3a96f-234">元に戻す</span><span class="sxs-lookup"><span data-stu-id="3a96f-234">Undo</span></span> | <span data-ttu-id="3a96f-235">実行できる操作がある場合。</span><span class="sxs-lookup"><span data-stu-id="3a96f-235">when there is an action that can be undone.</span></span> |
| <span data-ttu-id="3a96f-236">すべて選択</span><span class="sxs-lookup"><span data-stu-id="3a96f-236">Select all</span></span> | <span data-ttu-id="3a96f-237">テキストを選択することができます。</span><span class="sxs-lookup"><span data-stu-id="3a96f-237">when text can be selected.</span></span> |

### <a name="custom-text-command-bar-flyouts"></a><span data-ttu-id="3a96f-238">カスタム テキスト コマンド バーのポップアップ</span><span class="sxs-lookup"><span data-stu-id="3a96f-238">Custom text command bar flyouts</span></span>

<span data-ttu-id="3a96f-239">TextCommandBarFlyout はカスタマイズできませんされ、各テキスト コントロールで自動的に管理されます。</span><span class="sxs-lookup"><span data-stu-id="3a96f-239">TextCommandBarFlyout can't be customized, and is managed automatically by each text control.</span></span> <span data-ttu-id="3a96f-240">ただし、カスタム コマンドを使った TextCommandBarFlyout 既定値を置き換えることができます。</span><span class="sxs-lookup"><span data-stu-id="3a96f-240">However, you can replace the default TextCommandBarFlyout with custom commands.</span></span>

- <span data-ttu-id="3a96f-241">TextCommandBarFlyout テキストの選択に表示される既定値を交換するには、カスタム CommandBarFlyout (またはその他のポップアップ型) を作成し、 **SelectionFlyout**プロパティに割り当てます。</span><span class="sxs-lookup"><span data-stu-id="3a96f-241">To replace the default TextCommandBarFlyout that's shown on text selection, you can create a custom CommandBarFlyout (or other flyout type) and assign it to the **SelectionFlyout** property.</span></span> <span data-ttu-id="3a96f-242">SelectionFlyout を**null**に設定すると、選択内容にコマンドは表示されません。</span><span class="sxs-lookup"><span data-stu-id="3a96f-242">If you set SelectionFlyout to **null**, no commands are shown on selection.</span></span>
- <span data-ttu-id="3a96f-243">TextCommandBarFlyout として、コンテキスト メニューに表示される既定値を交換するには、テキスト コントロールに**ContextFlyout**プロパティにカスタム CommandBarFlyout (またはその他のポップアップ型) を割り当てます。</span><span class="sxs-lookup"><span data-stu-id="3a96f-243">To replace the default TextCommandBarFlyout that's shown as the context menu, assign a custom CommandBarFlyout (or other flyout type) to the **ContextFlyout** property on a text control.</span></span> <span data-ttu-id="3a96f-244">ContextFlyout を**null**に設定した場合、TextCommandBarFlyout ではなく、テキスト コントロールの以前のバージョンに表示されるメニュー ポップアップが表示されます。</span><span class="sxs-lookup"><span data-stu-id="3a96f-244">If you set ContextFlyout to **null**, the menu flyout shown in previous versions of the text control is shown instead of the TextCommandBarFlyout.</span></span>

## <a name="get-the-sample-code"></a><span data-ttu-id="3a96f-245">サンプル コードを入手する</span><span class="sxs-lookup"><span data-stu-id="3a96f-245">Get the sample code</span></span>

- <span data-ttu-id="3a96f-246">[XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - インタラクティブな形ですべての XAML コントロールを参照できます。</span><span class="sxs-lookup"><span data-stu-id="3a96f-246">[XAML Controls Gallery sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - See all the XAML controls in an interactive format.</span></span>
- [<span data-ttu-id="3a96f-247">XAML コマンド実行のサンプル</span><span class="sxs-lookup"><span data-stu-id="3a96f-247">XAML Commanding sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkId=620019)

## <a name="related-articles"></a><span data-ttu-id="3a96f-248">関連記事</span><span class="sxs-lookup"><span data-stu-id="3a96f-248">Related articles</span></span>

- [<span data-ttu-id="3a96f-249">UWP アプリのコマンド設計の基本</span><span class="sxs-lookup"><span data-stu-id="3a96f-249">Command design basics for UWP apps</span></span>](../basics/commanding-basics.md)
- [<span data-ttu-id="3a96f-250">CommandBar クラス</span><span class="sxs-lookup"><span data-stu-id="3a96f-250">CommandBar class</span></span>](https://msdn.microsoft.com/library/windows/apps/dn279427)
