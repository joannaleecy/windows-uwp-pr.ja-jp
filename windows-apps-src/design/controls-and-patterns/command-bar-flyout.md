---
author: jwmsft
Description: Command bar flyouts give users inline access to your app's most common tasks.
title: コマンド バーのポップアップ
label: Command bar flyout
template: detail.hbs
ms.author: jimwalk
ms.date: 10/2/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
pm-contact: abarlow
design-contact: ksulliv
dev-contact: llongley
doc-status: Draft
ms.localizationpriority: medium
ms.openlocfilehash: 22d965d14c4f10f904a4d94a18ce83721c49491c
ms.sourcegitcommit: 4b97117d3aff38db89d560502a3c372f12bb6ed5
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/24/2018
ms.locfileid: "5445480"
---
# <a name="command-bar-flyout"></a><span data-ttu-id="7d9f2-103">コマンド バーのポップアップ</span><span class="sxs-lookup"><span data-stu-id="7d9f2-103">Command bar flyout</span></span>

<span data-ttu-id="7d9f2-104">コマンド バーのポップアップでは、一般的なタスクに簡単にアクセスを UI のキャンバス上の要素に関連する浮動ツールバーでのコマンドを表示してユーザーに提供できます。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-104">The command bar flyout lets you provide users with easy access to common tasks by showing commands in a floating toolbar related to an element on your UI canvas.</span></span>

![展開されたテキスト コマンド バーのポップアップ](images/command-bar-flyout-text-full.png)

> <span data-ttu-id="7d9f2-106">関連する情報は、[コマンド バーを使う](app-bars.md)[メニューとコンテキスト メニュー](menus.md)は、[ポップアップ](../controls-and-patterns/dialogs-and-flyouts/flyouts.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-106">For related info, see [Flyouts](../controls-and-patterns/dialogs-and-flyouts/flyouts.md), [Menus and context menus](menus.md), and [Command bars](app-bars.md).</span></span>

<span data-ttu-id="7d9f2-107">CommandBarFlyout では[CommandBar](app-bars.md)のように、追加のコマンドを使用できます**PrimaryCommands**と**SecondaryCommands**のプロパティがあります。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-107">Like [CommandBar](app-bars.md), CommandBarFlyout has **PrimaryCommands** and **SecondaryCommands** properties you can use to add commands.</span></span> <span data-ttu-id="7d9f2-108">コレクション、またはその両方でコマンドを配置することができます。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-108">You can place commands in either collection, or both.</span></span> <span data-ttu-id="7d9f2-109">プライマリとセカンダリ コマンドが表示されるタイミングと方法は、表示モードによって異なります。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-109">When and how the primary and secondary commands are displayed depends on the display mode.</span></span>

<span data-ttu-id="7d9f2-110">コマンド バーのポップアップが 2 つの表示モード:*折りたたまれている*し、*展開*します。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-110">The command bar flyout has two display modes: *collapsed* and *expanded*.</span></span>

- <span data-ttu-id="7d9f2-111">折りたたまれたモードでは、プライマリ コマンドのみが表示されます。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-111">In the collapsed mode, only the primary commands are shown.</span></span> <span data-ttu-id="7d9f2-112">コマンド バーのポップアップがプライマリとセカンダリ コマンド、省略記号で表される「詳細」ボタン \ [•] が表示されます。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-112">If your command bar flyout has both primary and secondary commands, a "see more" button, which is represented by an ellipsis \[•••\], is displayed.</span></span> <span data-ttu-id="7d9f2-113">これにより、ユーザーの拡張モードに移行して、セカンダリ コマンドへのアクセスを取得できます。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-113">This lets the user get access to the secondary commands by transitioning to expanded mode.</span></span>
- <span data-ttu-id="7d9f2-114">展開時のモードでは、プライマリおよびセカンダリ コマンドの両方が表示されます。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-114">In the expanded mode, both the primary and secondary commands are shown.</span></span> <span data-ttu-id="7d9f2-115">(、コントロールにセカンダリ項目のみがある場合は表示 MenuFlyout コントロールと同様の方法で)。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-115">(If the control has only secondary items, they are shown in a way similar to the MenuFlyout control.)</span></span>

| **<span data-ttu-id="7d9f2-116">Windows UI のライブラリを入手します。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-116">Get the Windows UI Library</span></span>** |
| - |
| <span data-ttu-id="7d9f2-117">このコントロールは、Windows UI のライブラリ、新しいコントロールと UWP アプリの UI の機能が含まれている NuGet パッケージの一部として含まれています。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-117">This control is included as part of the Windows UI Library, a NuGet package that contains new controls and UI features for UWP apps.</span></span> <span data-ttu-id="7d9f2-118">詳しくは、インストールの手順を含む、 [Windows UI のライブラリの概要](https://docs.microsoft.com/uwp/toolkits/winui/)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-118">For more info, including installation instructions, see the [Windows UI Library overview](https://docs.microsoft.com/uwp/toolkits/winui/).</span></span> |

| **<span data-ttu-id="7d9f2-119">プラットフォーム Api</span><span class="sxs-lookup"><span data-stu-id="7d9f2-119">Platform APIs</span></span>** | **<span data-ttu-id="7d9f2-120">Windows UI ライブラリ Api</span><span class="sxs-lookup"><span data-stu-id="7d9f2-120">Windows UI Library APIs</span></span>** |
| - | - |
| <span data-ttu-id="7d9f2-121">[CommandBarFlyout クラス](/uwp/api/windows.ui.xaml.controls.commandbarflyout)、 [TextCommandBarFlyout クラス](/uwp/api/windows.ui.xaml.controls.textcommandbarflyout)、 [AppBarButton クラス](/uwp/api/windows.ui.xaml.controls.appbarbutton)、 [AppBarToggleButton クラス](/uwp/api/windows.ui.xaml.controls.appbartogglebutton)、 [AppBarSeparator クラス](/uwp/api/windows.ui.xaml.controls.appbarseparator)</span><span class="sxs-lookup"><span data-stu-id="7d9f2-121">[CommandBarFlyout class](/uwp/api/windows.ui.xaml.controls.commandbarflyout), [TextCommandBarFlyout class](/uwp/api/windows.ui.xaml.controls.textcommandbarflyout), [AppBarButton class](/uwp/api/windows.ui.xaml.controls.appbarbutton), [AppBarToggleButton class](/uwp/api/windows.ui.xaml.controls.appbartogglebutton), [AppBarSeparator class](/uwp/api/windows.ui.xaml.controls.appbarseparator)</span></span> | <span data-ttu-id="7d9f2-122">[CommandBarFlyout クラス](/uwp/api/microsoft.ui.xaml.controls.commandbarflyout)、 [TextCommandBarFlyout クラス](/uwp/api/microsoft.ui.xaml.controls.textcommandbarflyout)</span><span class="sxs-lookup"><span data-stu-id="7d9f2-122">[CommandBarFlyout class](/uwp/api/microsoft.ui.xaml.controls.commandbarflyout), [TextCommandBarFlyout class](/uwp/api/microsoft.ui.xaml.controls.textcommandbarflyout)</span></span> |

## <a name="is-this-the-right-control"></a><span data-ttu-id="7d9f2-123">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="7d9f2-123">Is this the right control?</span></span>

<span data-ttu-id="7d9f2-124">ボタンとアプリのキャンバス上の要素のコンテキストでのメニュー項目など、ユーザーにコマンドのコレクションを表示するのにには、CommandBarFlyout コントロールを使用します。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-124">Use the CommandBarFlyout control to show a collection of commands to the user, such as buttons and menu items, in the context of an element on the app canvas.</span></span>

<span data-ttu-id="7d9f2-125">TextCommandBarFlyout では、TextBox、TextBlock、RichEditBox、RichTextBlock、および PasswordBox のコントロールでテキスト コマンドが表示されます。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-125">The TextCommandBarFlyout displays text commands in TextBox, TextBlock, RichEditBox, RichTextBlock, and PasswordBox controls.</span></span> <span data-ttu-id="7d9f2-126">コマンドは現在のテキストの選択に自動的に適切に構成します。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-126">The commands are automatically configured appropriately to the current text selection.</span></span> <span data-ttu-id="7d9f2-127">CommandBarFlyout を使用してテキスト コントロールの既定のテキストのコマンドを置き換えます。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-127">Use a CommandBarFlyout to replace the default text commands on text controls.</span></span>

<span data-ttu-id="7d9f2-128">リスト項目でのコマンドをコンテキストを表示するには、[コンテキスト コマンドのコレクションとリストの実行](collection-commanding.md)のガイダンスに従っています。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-128">To show contextual commands on list items follow the guidance in [Contextual commanding for collections and lists](collection-commanding.md).</span></span>

### <a name="commandbarflyout-vs-menuflyout"></a><span data-ttu-id="7d9f2-129">CommandBarFlyout vs MenuFlyout</span><span class="sxs-lookup"><span data-stu-id="7d9f2-129">CommandBarFlyout vs MenuFlyout</span></span>

<span data-ttu-id="7d9f2-130">コンテキスト メニューにコマンドを表示するには、CommandBarFlyout または MenuFlyout を使用できます。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-130">To show commands in a context menu, you can use CommandBarFlyout or MenuFlyout.</span></span> <span data-ttu-id="7d9f2-131">MenuFlyout よりも多くの機能を提供するため CommandBarFlyout をお勧めします。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-131">We recommend CommandBarFlyout because it provides more functionality than MenuFlyout.</span></span> <span data-ttu-id="7d9f2-132">CommandBarFlyout は、動作を取得して、MenuFlyout の検索やプライマリおよびセカンダリの両方のコマンドで完全なコマンド バーのポップアップを使用するセカンダリ コマンドのみで使用できます。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-132">You can use CommandBarFlyout with only secondary commands to get the behavior and look of a MenuFlyout, or use the full command bar flyout with both primary and secondary commands.</span></span>

## <a name="examples"></a><span data-ttu-id="7d9f2-133">例</span><span class="sxs-lookup"><span data-stu-id="7d9f2-133">Examples</span></span>

<table>
<th align="left"><span data-ttu-id="7d9f2-134">XAML コントロール ギャラリー</span><span class="sxs-lookup"><span data-stu-id="7d9f2-134">XAML Controls Gallery</span></span><th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><span data-ttu-id="7d9f2-135"><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong>アプリがインストールされた場合は、ここをクリックして<a href="xamlcontrolsgallery:/item/CommandBarFlyout">アプリを開きの動作を確認 CommandBarFlyout を参照してください</a>。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-135">If you have the <strong style="font-weight: semi-bold">XAML Controls Gallery</strong> app installed, click here to <a href="xamlcontrolsgallery:/item/CommandBarFlyout">open the app and see the CommandBarFlyout in action</a>.</span></span></p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT"><span data-ttu-id="7d9f2-136">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</span><span class="sxs-lookup"><span data-stu-id="7d9f2-136">Get the XAML Controls Gallery app (Microsoft Store)</span></span></a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics"><span data-ttu-id="7d9f2-137">ソース コード (GitHub) を入手する</span><span class="sxs-lookup"><span data-stu-id="7d9f2-137">Get the source code (GitHub)</span></span></a></li>
    </ul>
</td>
</tr>
</table>

## <a name="proactive-vs-reactive-invocation"></a><span data-ttu-id="7d9f2-138">事後対応型の呼び出しと事前対応型</span><span class="sxs-lookup"><span data-stu-id="7d9f2-138">Proactive vs. reactive invocation</span></span>

<span data-ttu-id="7d9f2-139">ポップアップや、UI のキャンバス上の要素に関連付けられているメニューを呼び出すは通常 2 つの方法があります。_事前起動_と_事後対応型の呼び出し_です。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-139">There are typically two ways to invoke a flyout or menu that's associated with an element on your UI canvas: _proactive invocation_ and _reactive invocation_.</span></span>

<span data-ttu-id="7d9f2-140">コマンドは事前対応型の呼び出しでは、ユーザーがコマンドに関連付けられている項目を操作する自動的に表示します。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-140">In proactive invocation, commands appear automatically when the user interacts with the item that the commands are associated with.</span></span> <span data-ttu-id="7d9f2-141">たとえば、テキストの書式設定コマンド可能性がありますがポップアップ、ユーザーがテキスト ボックスのテキストを選択します。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-141">For example, text formatting commands might pop up when the user selects text in a text box.</span></span> <span data-ttu-id="7d9f2-142">この例では、コマンド バーのポップアップでは、フォーカスは実行されません。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-142">In this case, the command bar flyout does not take focus.</span></span> <span data-ttu-id="7d9f2-143">代わりに、適切なコマンドで、ユーザーが操作の項目に近いが表示されます。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-143">Instead, it presents relevant commands close to the item the user is interacting with.</span></span> <span data-ttu-id="7d9f2-144">場合は、ユーザーは、コマンドを操作しない、それらが閉じられます。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-144">If the user doesn't interact with the commands, they are dismissed.</span></span>

<span data-ttu-id="7d9f2-145">事後対応型の呼び出しでコマンドは表示、明示的なユーザー操作への応答で、コマンドを要求するにはたとえば、右クリックします。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-145">In reactive invocation, commands are shown in response to an explicit user action to request the commands; for example, a right-click.</span></span> <span data-ttu-id="7d9f2-146">これは、[コンテキスト メニュー](menus.md)の従来の概念に対応します。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-146">This corresponds to the traditional concept of a [context menu](menus.md).</span></span>

<span data-ttu-id="7d9f2-147">により、または 2 つの組み合わせでも CommandBarFlyout を使用することができます。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-147">You can use the CommandBarFlyout in either way, or even a mixture of the two.</span></span>

## <a name="create-a-command-bar-flyout"></a><span data-ttu-id="7d9f2-148">コマンド バーのポップアップを作成します。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-148">Create a command bar flyout</span></span>

> <span data-ttu-id="7d9f2-149">**プレビュー**: CommandBarFlyout[最新の Windows 10 Insider Preview ビルドと SDK](https://insider.windows.com/for-developers/)または[Windows UI のライブラリ](https://docs.microsoft.com/uwp/toolkits/winui/)が必要です。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-149">**Preview**: CommandBarFlyout requires the [latest Windows 10 Insider Preview build and SDK](https://insider.windows.com/for-developers/) or the [Windows UI Library](https://docs.microsoft.com/uwp/toolkits/winui/).</span></span>

<span data-ttu-id="7d9f2-150">この例では、コマンド バーのポップアップを作成し、事前と事後対応的に使用する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-150">This example shows how to create a command bar flyout and use it both proactively and reactively.</span></span> <span data-ttu-id="7d9f2-151">イメージをタップすると、ポップアップが折りたたまれているモードで表示されます。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-151">When the image is tapped, the flyout is shown in its collapsed mode.</span></span> <span data-ttu-id="7d9f2-152">表示されるとき、コンテキスト メニューとして、その拡張モードで、ポップアップが表示されます。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-152">When shown as a context menu, the flyout is shown in its expanded mode.</span></span> <span data-ttu-id="7d9f2-153">どちらの場合、ユーザー展開したり折りたたんだり、ポップアップを開いた後。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-153">In either case, the user can expand or collapse the flyout after it's opened.</span></span>

:::row:::
    :::column:::
        A collapsed command bar flyout<br/>
        ![Example of a collapsed command bar flyout](images/command-bar-flyout-img-collapsed.png)
    :::column-end:::
    :::column:::
        An expanded command bar flyout<br/>
        ![Example of an expanded command bar flyout](images/command-bar-flyout-img-expanded.png)
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

### <a name="show-commands-proactively"></a><span data-ttu-id="7d9f2-154">事前にコマンドを表示します。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-154">Show commands proactively</span></span>

<span data-ttu-id="7d9f2-155">コンテキスト コマンドをプロアクティブに表示すると、プライマリ コマンドのみする必要があります (コマンド バーのポップアップを縮小する必要があります) を既定で表示されます。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-155">When you show contextual commands proactively, only the primary commands should be shown by default (the command bar flyout should be collapsed).</span></span> <span data-ttu-id="7d9f2-156">プライマリ コマンドのコレクションとされる従来のコンテキスト メニューで、セカンダリ コマンドのコレクションに追加のコマンドで最も重要なコマンドを配置します。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-156">Place the most important commands in the primary commands collection, and additional commands that would traditionally go in a context menu into the secondary commands collection.</span></span>

<span data-ttu-id="7d9f2-157">コマンドをプロアクティブに表示するには、コマンド バーのポップアップを表示する[] をクリックして](/uwp/api/windows.ui.xaml.controls.primitives.buttonbase.click)または[Tapped](/uwp/api/windows.ui.xaml.uielement.tapped)イベントを処理する通常します。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-157">To proactively show commands, you typically handle the [Click](/uwp/api/windows.ui.xaml.controls.primitives.buttonbase.click) or [Tapped](/uwp/api/windows.ui.xaml.uielement.tapped) event to show the command bar flyout.</span></span> <span data-ttu-id="7d9f2-158">**一時的な**または**TransientWithDismissOnPointerMoveAway**折りたたまれたモードでフォーカスを移動することがなく、ポップアップを開くには、ポップアップの[ShowMode](/uwp/api/windows.ui.xaml.controls.primitives.flyoutbase.showmode)を設定します。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-158">Set the flyout's [ShowMode](/uwp/api/windows.ui.xaml.controls.primitives.flyoutbase.showmode) to **Transient** or **TransientWithDismissOnPointerMoveAway** to open the flyout in its collapsed mode without taking focus.</span></span>

<span data-ttu-id="7d9f2-159">以降、Windows 10 Insider Preview では、テキスト コントロールには、 **SelectionFlyout**プロパティが設定されています。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-159">Starting in the Windows 10 Insider Preview, text controls have a **SelectionFlyout** property.</span></span> <span data-ttu-id="7d9f2-160">ポップアップを割り当てるには、このプロパティに、テキストが選択されているときに自動的に表示されます。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-160">When you assign a flyout to this property, it is automatically shown when text is selected.</span></span>

### <a name="show-commands-reactively"></a><span data-ttu-id="7d9f2-161">事後対応的にコマンドを表示します。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-161">Show commands reactively</span></span>

<span data-ttu-id="7d9f2-162">事後対応的、コンテキスト メニューとコンテキスト コマンドを表示する場合は、既定では (コマンド バーのポップアップを展開する必要があります)、セカンダリ コマンドが表示されます。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-162">When you show contextual commands reactively, as a context menu, the secondary commands are shown by default (the command bar flyout should be expanded).</span></span> <span data-ttu-id="7d9f2-163">この例では、コマンド バーのポップアップには、プライマリおよびセカンダリの両方のコマンド、またはセカンダリ コマンドのみがあります。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-163">In this case, the command bar flyout might have both primary and secondary commands, or secondary commands only.</span></span>

<span data-ttu-id="7d9f2-164">コンテキスト メニューにコマンドを表示するには、通常に UI 要素の[ContextFlyout](/uwp/api/windows.ui.xaml.uielement.contextflyout)プロパティに、ポップアップを割り当てます。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-164">To show commands in a context menu, you typically assign the flyout to the [ContextFlyout](/uwp/api/windows.ui.xaml.uielement.contextflyout) property of a UI element.</span></span> <span data-ttu-id="7d9f2-165">これによりは、要素によって処理されますが、ポップアップを開くと、特に何もする必要はありません。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-165">This way, opening the flyout is handled by the element, and you don't need to do anything more.</span></span>

<span data-ttu-id="7d9f2-166">(たとえば、 [RightTapped](/uwp/api/windows.ui.xaml.uielement.righttapped)イベント) を自分で、ポップアップを示すを処理する場合は、**標準**の拡張モードで、ポップアップを開き、フォーカスを設定するポップアップの[ShowMode](/uwp/api/windows.ui.xaml.controls.primitives.flyoutbase.showmode)を設定します。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-166">If you handle showing the flyout yourself (for example, on a [RightTapped](/uwp/api/windows.ui.xaml.uielement.righttapped) event), set the flyout's [ShowMode](/uwp/api/windows.ui.xaml.controls.primitives.flyoutbase.showmode) to **Standard** to open the flyout in its expanded mode and give it focus.</span></span>

> [!TIP]
> <span data-ttu-id="7d9f2-167">ポップアップの配置を制御する方法と、ポップアップを表示するときのオプションについて詳しくは、[ポップアップ](../controls-and-patterns/dialogs-and-flyouts/flyouts.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-167">For more info about options when showing a flyout and how to control placement of the flyout, see [Flyouts](../controls-and-patterns/dialogs-and-flyouts/flyouts.md).</span></span>

## <a name="commands-and-content"></a><span data-ttu-id="7d9f2-168">コマンドとコンテンツ</span><span class="sxs-lookup"><span data-stu-id="7d9f2-168">Commands and content</span></span>

<span data-ttu-id="7d9f2-169">CommandBarFlyout コントロールは、コマンドとコンテンツを追加するに使用できる 2 つのプロパティを持つ: [PrimaryCommands](/uwp/api/windows.ui.xaml.controls.commandbarflyout.primarycommands)と[SecondaryCommands](/uwp/api/windows.ui.xaml.controls.commandbarflyout.secondarycommands)にします。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-169">The CommandBarFlyout control has 2 properties you can use to add commands and content: [PrimaryCommands](/uwp/api/windows.ui.xaml.controls.commandbarflyout.primarycommands) and [SecondaryCommands](/uwp/api/windows.ui.xaml.controls.commandbarflyout.secondarycommands).</span></span>

<span data-ttu-id="7d9f2-170">既定では、コマンド バーの項目は **PrimaryCommands** コレクションに追加されます。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-170">By default, command bar items are added to the **PrimaryCommands** collection.</span></span> <span data-ttu-id="7d9f2-171">これらのコマンドでは、コマンド バーは表示され、折りたたまれていると、展開時の両方のモードで表示されます。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-171">These commands are shown in the command bar and are visible in both the collapsed and expanded modes.</span></span> <span data-ttu-id="7d9f2-172">CommandBar とは異なり、プライマリ コマンドは自動的にセカンダリ コマンドにオーバーフローではないと切り詰められている可能性があります。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-172">Unlike CommandBar, primary commands do not automatically overflow to the secondary commands and might be truncated.</span></span>

<span data-ttu-id="7d9f2-173">コマンドは**SecondaryCommands**コレクションに追加することもできます。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-173">You can also add commands to the **SecondaryCommands** collection.</span></span> <span data-ttu-id="7d9f2-174">セカンダリ コマンドは、コントロールのメニューの部分では表示され、展開モードでのみ表示されます。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-174">Secondary commands are shown in the menu portion of the control and are visible only in the expanded mode.</span></span>

### <a name="app-bar-buttons"></a><span data-ttu-id="7d9f2-175">アプリ バーのボタン</span><span class="sxs-lookup"><span data-stu-id="7d9f2-175">App bar buttons</span></span>

<span data-ttu-id="7d9f2-176">PrimaryCommands と SecondaryCommands には、 [AppBarButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbarbutton.aspx)、 [AppBarToggleButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbartogglebutton.aspx)、および[AppBarSeparator](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbarseparator.aspx)コントロールを直接設定できます。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-176">You can populate the PrimaryCommands and SecondaryCommands directly with [AppBarButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbarbutton.aspx), [AppBarToggleButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbartogglebutton.aspx), and [AppBarSeparator](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbarseparator.aspx) controls.</span></span>

<span data-ttu-id="7d9f2-177">アプリ バーのボタン コントロールは、アイコンとテキスト ラベルによって特徴付けられます。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-177">The app bar button controls are characterized by an icon and text label.</span></span> <span data-ttu-id="7d9f2-178">これらのコントロールは、コマンド バーで使用向けに最適化され、コマンド バーやオーバーフロー メニューにコントロールを表示するかどうかに応じて外観が変化します。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-178">These controls are optimized for use in a command bar, and their appearance changes depending on whether the control is shown in the command bar or the overflow menu.</span></span>

- <span data-ttu-id="7d9f2-179">アプリ バーのボタンがプライマリ コマンドとして使用されます。 が、アイコンのみを含むコマンド バーで表示されます。テキスト ラベルは表示されません。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-179">App bar buttons used as primary commands are shown in the command bar with only their icon; the text label is not shown.</span></span> <span data-ttu-id="7d9f2-180">次のように、コマンドの説明のテキストを表示するヒントを使用することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-180">We recommend that you use a tooltip to show a text description of the command, as shown here.</span></span>
    ```xaml
    <AppBarButton Icon="Copy" ToolTipService.ToolTip="Copy"/>
    ```
- <span data-ttu-id="7d9f2-181">セカンダリ コマンドとして使われるアプリ バーのボタンは、ラベルとアイコンが表示されると、メニューに表示されます。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-181">App bar buttons used as secondary commands are shown in the menu, with both the label and icon visible.</span></span>

### <a name="other-content"></a><span data-ttu-id="7d9f2-182">その他のコンテンツ</span><span class="sxs-lookup"><span data-stu-id="7d9f2-182">Other content</span></span>

<span data-ttu-id="7d9f2-183">コマンド バーのポップアップを他のコントロールを追加するには、AppBarElementContainer でラップします。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-183">You can add other controls to a command bar flyout by wrapping them in an AppBarElementContainer.</span></span> <span data-ttu-id="7d9f2-184">これにより、 [DropDownButton]() [SplitButton]()などのコントロールを追加したりより複雑な UI を作成するために[StackPanel]()などのコンテナーを追加することができます。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-184">This lets you add controls like [DropDownButton]() or [SplitButton](), or add containers like [StackPanel]() to create more complex UI.</span></span>

> [!NOTE]
> <span data-ttu-id="7d9f2-185">コマンド バーのポップアップのプライマリまたはセカンダリ コマンドのコレクションに追加するためには、要素が[ICommandBarElement](/uwp/api/windows.ui.xaml.controls.icommandbarelement)インターフェイスを実装する必要があります。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-185">In order to be added to the primary or secondary command collections of a command bar flyout, an element must implement the [ICommandBarElement](/uwp/api/windows.ui.xaml.controls.icommandbarelement) interface.</span></span> <span data-ttu-id="7d9f2-186">AppBarElementContainer は、自体インターフェイスを実装していない場合でも、コマンド バーに要素を追加できるように、このインターフェイスを実装するラッパーです。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-186">AppBarElementContainer is a wrapper that implements this interface so you can add an element to a command bar even if it doesn't implement the interface itself.</span></span>

<span data-ttu-id="7d9f2-187">ここでは、AppBarElementContainer を使用して、コマンド バーのポップアップに余分な要素を追加します。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-187">Here, an AppBarElementContainer is used to add extra elements to a command bar flyout.</span></span> <span data-ttu-id="7d9f2-188">SplitButton は、色の選択を許可するプライマリ コマンドに追加されます。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-188">A SplitButton is added to the primary commands to allow selection of colors.</span></span> <span data-ttu-id="7d9f2-189">StackPanel は、ズーム コントロールのより複雑なレイアウトを許可するセカンダリ コマンドに追加されます。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-189">A StackPanel is added to the secondary commands to allow a more complex layout for zoom controls.</span></span>

> [!NOTE]
> <span data-ttu-id="7d9f2-190">この例では、表示されるコマンドのいずれかの実装していないのみ、コマンド バーのポップアップ UI を示しています。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-190">This example shows only the command bar flyout UI, it does not implement any of the commands that are shown.</span></span> <span data-ttu-id="7d9f2-191">コマンドの実装について詳しくは、[ボタン](buttons.md)や[コマンド設計の基本](../basics/commanding-basics.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-191">For more info about implementing the commands, see [Buttons](buttons.md) and [Command design basics](../basics/commanding-basics.md).</span></span>

:::row:::
    :::column:::
        A collapsed command bar flyout with an open SplitButton<br/>
        ![A command bar flyout with a split button](images/command-bar-flyout-split-button.png)
    :::column-end:::
    :::column:::
        An expanded command bar flyout with custom zoom UI in the menu<br/>
        ![A command bar flyout with complex UI](images/command-bar-flyout-complex-ui.png)
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

## <a name="create-a-context-menu-with-secondary-commands-only"></a><span data-ttu-id="7d9f2-192">セカンダリ コマンドのみでコンテキスト メニューを作成します。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-192">Create a context menu with secondary commands only</span></span>

<span data-ttu-id="7d9f2-193">[コンテキスト メニュー](menus.md)MenuFlyout の代わりとして、セカンダリ コマンドのみを使用して、CommandBarFlyout を使用できます。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-193">You can use a CommandBarFlyout with only secondary commands as a [context menu](menus.md), in place of a MenuFlyout.</span></span>

![セカンダリ コマンドのみを含むコマンド バーのポップアップ](images/command-bar-flyout-context-menu.png)

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

<span data-ttu-id="7d9f2-195">標準的なメニューを作成するのに、DropDownButton で、CommandBarFlyout を使用することもできます。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-195">You can also use a CommandBarFlyout with a DropDownButton to create a standard menu.</span></span>

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

## <a name="command-bar-flyouts-for-text-controls"></a><span data-ttu-id="7d9f2-197">テキスト コントロールのコマンド バーのポップアップ</span><span class="sxs-lookup"><span data-stu-id="7d9f2-197">Command bar flyouts for text controls</span></span>

<span data-ttu-id="7d9f2-198">[TextCommandBarFlyout](/uwp/api/microsoft.ui.xaml.controls.textcommandbarflyout)は、テキスト編集のコマンドを含む特殊なコマンド バーのポップアップです。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-198">The [TextCommandBarFlyout](/uwp/api/microsoft.ui.xaml.controls.textcommandbarflyout) is a specialized command bar flyout that contains commands for editing text.</span></span> <span data-ttu-id="7d9f2-199">各テキスト コントロールは、コンテキスト メニュー (右クリック)、またはテキストが選択されているときに自動的に、TextCommandBarFlyout を表示します。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-199">Each text control shows the TextCommandBarFlyout automatically as a context menu (right-click), or when text is selected.</span></span> <span data-ttu-id="7d9f2-200">テキストのコマンド バーのポップアップは、適切なコマンドのみを表示するテキストの選択に適応します。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-200">The text command bar flyout adapts to the text selection to only show relevant commands.</span></span>

:::row:::
    :::column:::
        A text command bar flyout on text selection<br/>
        ![A collapsed text command bar flyout](images/command-bar-flyout-text-selection.png)
    :::column-end:::
    :::column:::
        An expanded text command bar flyout<br/>
        ![An expanded text command bar flyout](images/command-bar-flyout-text-full.png)
    :::column-end:::
:::row-end:::

### <a name="available-commands"></a><span data-ttu-id="7d9f2-201">利用可能なコマンド</span><span class="sxs-lookup"><span data-stu-id="7d9f2-201">Available commands</span></span>

<span data-ttu-id="7d9f2-202">次の表では、表示されているときと、TextCommandBarFlyout に含まれているコマンドを示します。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-202">This table shows the commands that are included in a TextCommandBarFlyout, and when they are shown.</span></span>

| <span data-ttu-id="7d9f2-203">コマンド</span><span class="sxs-lookup"><span data-stu-id="7d9f2-203">Command</span></span> | <span data-ttu-id="7d9f2-204">表示されます。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-204">Shown...</span></span> |
| ------- | -------- |
| <span data-ttu-id="7d9f2-205">Bold</span><span class="sxs-lookup"><span data-stu-id="7d9f2-205">Bold</span></span> | <span data-ttu-id="7d9f2-206">テキスト コントロールは読み取り専用 (RichEditBox のみ) ではありません。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-206">when the text control is not read-only (RichEditBox only).</span></span> |
| <span data-ttu-id="7d9f2-207">Italic</span><span class="sxs-lookup"><span data-stu-id="7d9f2-207">Italic</span></span> | <span data-ttu-id="7d9f2-208">テキスト コントロールは読み取り専用 (RichEditBox のみ) ではありません。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-208">when the text control is not read-only (RichEditBox only).</span></span> |
| <span data-ttu-id="7d9f2-209">Underline</span><span class="sxs-lookup"><span data-stu-id="7d9f2-209">Underline</span></span> | <span data-ttu-id="7d9f2-210">テキスト コントロールは読み取り専用 (RichEditBox のみ) ではありません。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-210">when the text control is not read-only (RichEditBox only).</span></span> |
| <span data-ttu-id="7d9f2-211">校正</span><span class="sxs-lookup"><span data-stu-id="7d9f2-211">Proofing</span></span> | <span data-ttu-id="7d9f2-212">IsSpellCheckEnabled が**true**でのスペルに誤りがある場合は、テキストが選択されます。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-212">when IsSpellCheckEnabled is **true** and misspelled text is selected.</span></span> |
| <span data-ttu-id="7d9f2-213">切り取り</span><span class="sxs-lookup"><span data-stu-id="7d9f2-213">Cut</span></span> | <span data-ttu-id="7d9f2-214">テキスト コントロールは読み取り専用ではないとテキストが選択されます。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-214">when the text control is not read-only and text is selected.</span></span> |
| <span data-ttu-id="7d9f2-215">コピー</span><span class="sxs-lookup"><span data-stu-id="7d9f2-215">Copy</span></span> | <span data-ttu-id="7d9f2-216">テキストが選択されている場合。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-216">when text is selected.</span></span> |
| <span data-ttu-id="7d9f2-217">貼り付け</span><span class="sxs-lookup"><span data-stu-id="7d9f2-217">Paste</span></span> | <span data-ttu-id="7d9f2-218">テキスト コントロールは読み取り専用ではないとクリップボードがコンテンツです。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-218">when the text control is not read-only and the clipboard has content.</span></span> |
| <span data-ttu-id="7d9f2-219">元に戻す</span><span class="sxs-lookup"><span data-stu-id="7d9f2-219">Undo</span></span> | <span data-ttu-id="7d9f2-220">実行できるアクションがある場合。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-220">when there is an action that can be undone.</span></span> |
| <span data-ttu-id="7d9f2-221">すべて選択</span><span class="sxs-lookup"><span data-stu-id="7d9f2-221">Select all</span></span> | <span data-ttu-id="7d9f2-222">テキストを選択することができます。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-222">when text can be selected.</span></span> |

### <a name="custom-text-command-bar-flyouts"></a><span data-ttu-id="7d9f2-223">カスタム テキスト コマンド バーのポップアップ</span><span class="sxs-lookup"><span data-stu-id="7d9f2-223">Custom text command bar flyouts</span></span>

<span data-ttu-id="7d9f2-224">TextCommandBarFlyout では、カスタマイズできませんされ、各テキスト コントロールで自動的に管理されます。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-224">TextCommandBarFlyout can't be customized, and is managed automatically by each text control.</span></span> <span data-ttu-id="7d9f2-225">ただし、カスタム コマンドを使った TextCommandBarFlyout 既定値を置き換えることができます。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-225">However, you can replace the default TextCommandBarFlyout with custom commands.</span></span>

- <span data-ttu-id="7d9f2-226">TextCommandBarFlyout テキストの選択に表示される既定値を交換するには、カスタム CommandBarFlyout (またはその他のポップアップ型) を作成し、 **SelectionFlyout**プロパティに割り当てます。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-226">To replace the default TextCommandBarFlyout that's shown on text selection, you can create a custom CommandBarFlyout (or other flyout type) and assign it to the **SelectionFlyout** property.</span></span> <span data-ttu-id="7d9f2-227">SelectionFlyout を**null**に設定する場合は、選択内容にコマンドが表示されません。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-227">If you set SelectionFlyout to **null**, no commands are shown on selection.</span></span>
- <span data-ttu-id="7d9f2-228">既定のコンテキスト メニューとして表示されている TextCommandBarFlyout を置換するには、テキスト コントロールに**ContextFlyout**プロパティにカスタム CommandBarFlyout (またはその他のポップアップ型) を割り当てます。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-228">To replace the default TextCommandBarFlyout that's shown as the context menu, assign a custom CommandBarFlyout (or other flyout type) to the **ContextFlyout** property on a text control.</span></span> <span data-ttu-id="7d9f2-229">ContextFlyout を**null**に設定すると、TextCommandBarFlyout ではなく、テキスト コントロールの以前のバージョンに表示されるメニュー ポップアップが表示されます。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-229">If you set ContextFlyout to **null**, the menu flyout shown in previous versions of the text control is shown instead of the TextCommandBarFlyout.</span></span>

## <a name="get-the-sample-code"></a><span data-ttu-id="7d9f2-230">サンプル コードを入手する</span><span class="sxs-lookup"><span data-stu-id="7d9f2-230">Get the sample code</span></span>

- <span data-ttu-id="7d9f2-231">[XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - インタラクティブな形ですべての XAML コントロールを参照できます。</span><span class="sxs-lookup"><span data-stu-id="7d9f2-231">[XAML Controls Gallery sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - See all the XAML controls in an interactive format.</span></span>
- [<span data-ttu-id="7d9f2-232">XAML コマンド実行のサンプル</span><span class="sxs-lookup"><span data-stu-id="7d9f2-232">XAML Commanding sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkId=620019)

## <a name="related-articles"></a><span data-ttu-id="7d9f2-233">関連記事</span><span class="sxs-lookup"><span data-stu-id="7d9f2-233">Related articles</span></span>

- [<span data-ttu-id="7d9f2-234">UWP アプリのコマンド設計の基本</span><span class="sxs-lookup"><span data-stu-id="7d9f2-234">Command design basics for UWP apps</span></span>](../basics/commanding-basics.md)
- [<span data-ttu-id="7d9f2-235">CommandBar クラス</span><span class="sxs-lookup"><span data-stu-id="7d9f2-235">CommandBar class</span></span>](https://msdn.microsoft.com/library/windows/apps/dn279427)
