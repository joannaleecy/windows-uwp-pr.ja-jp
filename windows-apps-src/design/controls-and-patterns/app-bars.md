---
Description: Command bars give users easy access to your app's most common tasks.
title: コマンド バー
label: App bars/command bars
template: detail.hbs
op-migration-status: ready
ms.date: 05/19/2017
ms.topic: article
keywords: Windows 10, UWP
ms.assetid: 868b4145-319b-4a97-82bd-c98d966144db
pm-contact: yulikl
design-contact: ksulliv
dev-contact: niallm
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 1bf828fab97a5dddc26d669b771bb831b65c140f
ms.sourcegitcommit: 8921a9cc0dd3e5665345ae8eca7ab7aeb83ccc6f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8881295"
---
# <a name="command-bar"></a><span data-ttu-id="340b8-103">コマンド バー</span><span class="sxs-lookup"><span data-stu-id="340b8-103">Command bar</span></span>

<span data-ttu-id="340b8-104">コマンド バーを使うと、ユーザーはアプリの最も一般的なタスクに簡単にアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="340b8-104">Command bars provide users with easy access to your app's most common tasks.</span></span> <span data-ttu-id="340b8-105">コマンド バーを使うと、アプリ レベルまたはページに固有のコマンドにアクセスできます。これは、ナビゲーション パターンと共に使用することもできます。</span><span class="sxs-lookup"><span data-stu-id="340b8-105">Command bars can provide access to app-level or page-specific commands and can be used with any navigation pattern.</span></span>

> <span data-ttu-id="340b8-106">**重要な API**: [CommandBar クラス](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.commandbar.aspx)、[AppBarButton クラス](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.appbarbutton.aspx)、[AppBarToggleButton クラス](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.appbartogglebutton.aspx)、[AppBarSeparator クラス](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.appbarseparator.aspx)</span><span class="sxs-lookup"><span data-stu-id="340b8-106">**Important APIs**: [CommandBar class](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.commandbar.aspx), [AppBarButton class](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.appbarbutton.aspx), [AppBarToggleButton class](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.appbartogglebutton.aspx), [AppBarSeparator class](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.appbarseparator.aspx)</span></span>

![アイコンを含むコマンド バーの例](images/controls_appbar_icons.png)

## <a name="is-this-the-right-control"></a><span data-ttu-id="340b8-108">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="340b8-108">Is this the right control?</span></span>

<span data-ttu-id="340b8-109">CommandBar コントロールは、汎用的で柔軟、軽量なコントロールです。画像やテキスト ブロックなどの複雑なコンテンツも、[AppBarButton](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.appbarbutton.aspx)、[AppBarToggleButton](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.appbartogglebutton.aspx)、[AppBarSeparator](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.appbarseparator.aspx) コントロールなどの単純なコマンドも表示できます。</span><span class="sxs-lookup"><span data-stu-id="340b8-109">The CommandBar control is a general-purpose, flexible, light-weight control that can display both complex content, such as images or text blocks, as well as simple commands such as [AppBarButton](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.appbarbutton.aspx), [AppBarToggleButton](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.appbartogglebutton.aspx), and [AppBarSeparator](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.appbarseparator.aspx) controls.</span></span>

> [!NOTE]
> <span data-ttu-id="340b8-110">XAML では、[AppBar](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.appbar) コントロールと [CommandBar](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.commandbar) コントロールの両方が提供されます。</span><span class="sxs-lookup"><span data-stu-id="340b8-110">XAML provides both the [AppBar](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.appbar) control and the [CommandBar](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.commandbar) control.</span></span> <span data-ttu-id="340b8-111">AppBar を使うユニバーサル Windows 8 アプリをアップグレードする場合にのみ、AppBar を使ってください。また、変更は最小限に抑える必要があります。</span><span class="sxs-lookup"><span data-stu-id="340b8-111">You should use the AppBar only when you are upgrading a Universal Windows 8 app that uses the AppBar, and need to minimize changes.</span></span> <span data-ttu-id="340b8-112">Windows 10 の新しいアプリでは、代わりに CommandBar コントロールを使うことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="340b8-112">For new apps in Windows 10, we recommend using the CommandBar control instead.</span></span> <span data-ttu-id="340b8-113">このドキュメントでは、CommandBar コントロールを使うことを前提としています。</span><span class="sxs-lookup"><span data-stu-id="340b8-113">This document assumes you are using the CommandBar control.</span></span>

## <a name="examples"></a><span data-ttu-id="340b8-114">例</span><span class="sxs-lookup"><span data-stu-id="340b8-114">Examples</span></span>

<table>
<th align="left"><span data-ttu-id="340b8-115">XAML コントロール ギャラリー</span><span class="sxs-lookup"><span data-stu-id="340b8-115">XAML Controls Gallery</span></span><th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><span data-ttu-id="340b8-116"><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックして<a href="xamlcontrolsgallery:/item/CommandBar">アプリを開き、CommandBar の動作を確認</a>してください。</span><span class="sxs-lookup"><span data-stu-id="340b8-116">If you have the <strong style="font-weight: semi-bold">XAML Controls Gallery</strong> app installed, click here to <a href="xamlcontrolsgallery:/item/CommandBar">open the app and see the CommandBar in action</a>.</span></span></p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT"><span data-ttu-id="340b8-117">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</span><span class="sxs-lookup"><span data-stu-id="340b8-117">Get the XAML Controls Gallery app (Microsoft Store)</span></span></a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics"><span data-ttu-id="340b8-118">ソース コード (GitHub) を入手する</span><span class="sxs-lookup"><span data-stu-id="340b8-118">Get the source code (GitHub)</span></span></a></li>
    </ul>
</td>
</tr>
</table>

<span data-ttu-id="340b8-119">Microsoft フォト アプリの展開されたコマンド バーです。</span><span class="sxs-lookup"><span data-stu-id="340b8-119">An expanded command bar in the Microsoft Photos app.</span></span>

![Microsoft フォト アプリのコマンドバー](images/control-examples/command-bar-photos.png)

<span data-ttu-id="340b8-121">Windows Phone の Outlook カレンダーのコマンド バーです。</span><span class="sxs-lookup"><span data-stu-id="340b8-121">A command bar in the Outlook Calendar on Windows Phone.</span></span>

![Outlook カレンダー アプリのコマンド バー](images/control-examples/command-bar-calendar-phone.png)

## <a name="anatomy"></a><span data-ttu-id="340b8-123">構造</span><span class="sxs-lookup"><span data-stu-id="340b8-123">Anatomy</span></span>

<span data-ttu-id="340b8-124">既定では、コマンド バーには、一連のアイコン ボタンとオプションの [その他] ボタン (省略記号の \[•••\]) が表示されます。</span><span class="sxs-lookup"><span data-stu-id="340b8-124">By default, the command bar shows a row of icon buttons and an optional "see more" button, which is represented by an ellipsis \[•••\].</span></span> <span data-ttu-id="340b8-125">後で示すコード例を使って作成されたコマンド バーを次に示します。</span><span class="sxs-lookup"><span data-stu-id="340b8-125">Here's the command bar created by the example code shown later.</span></span> <span data-ttu-id="340b8-126">コマンド バーは、閉じたコンパクトな状態で表示されます。</span><span class="sxs-lookup"><span data-stu-id="340b8-126">It's shown in its closed compact state.</span></span>

![閉じたコマンド バー](images/command-bar-compact.png)

<span data-ttu-id="340b8-128">コマンド バーは、次のように、閉じた最小の状態で表示することもできます。</span><span class="sxs-lookup"><span data-stu-id="340b8-128">The command bar can also be shown in a closed minimal state that looks like this.</span></span> <span data-ttu-id="340b8-129">詳しくは、「[開いた状態と閉じた状態](#open-and-closed-states)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="340b8-129">See the [Open and closed states](#open-and-closed-states) section for more info.</span></span>

![閉じたコマンド バー](images/command-bar-minimal.png)

<span data-ttu-id="340b8-131">同じコマンド バーが開いている状態を次に示します。</span><span class="sxs-lookup"><span data-stu-id="340b8-131">Here's the same command bar in its open state.</span></span> <span data-ttu-id="340b8-132">ラベルは、コントロールのメイン部分を識別します。</span><span class="sxs-lookup"><span data-stu-id="340b8-132">The labels identify the main parts of the control.</span></span>

![閉じたコマンド バー](images/commandbar_anatomy_open.png)

<span data-ttu-id="340b8-134">コマンド バーは、4 つの主な領域に分かれています。</span><span class="sxs-lookup"><span data-stu-id="340b8-134">The command bar is divided into 4 main areas:</span></span>
- <span data-ttu-id="340b8-135">コンテンツ領域はバーの左側に配置されます。</span><span class="sxs-lookup"><span data-stu-id="340b8-135">The content area is aligned to the left side of the bar.</span></span> <span data-ttu-id="340b8-136">これは、[Content](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.contentcontrol.content.aspx) プロパティが指定されている場合に表示されます。</span><span class="sxs-lookup"><span data-stu-id="340b8-136">It is shown if the [Content](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.contentcontrol.content.aspx) property is populated.</span></span>
- <span data-ttu-id="340b8-137">基本コマンド領域はバーの右側に配置されます。</span><span class="sxs-lookup"><span data-stu-id="340b8-137">The primary command area is aligned to the right side of the bar.</span></span> <span data-ttu-id="340b8-138">これは、[PrimaryCommands](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.commandbar.primarycommands.aspx) プロパティが指定されている場合に表示されます。</span><span class="sxs-lookup"><span data-stu-id="340b8-138">It is shown if the [PrimaryCommands](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.commandbar.primarycommands.aspx) property is populated.</span></span>  
- <span data-ttu-id="340b8-139">[その他] （\[•••\]） ボタンはバーの右側に表示されます。</span><span class="sxs-lookup"><span data-stu-id="340b8-139">The "see more" \[•••\] button is shown on the right of the bar.</span></span> <span data-ttu-id="340b8-140">[その他] （\[•••\]） ボタンを押すと、プライマリ コマンドのラベルが表示され、セカンダリ コマンドが存在する場合はオーバーフロー メニューが開きます。</span><span class="sxs-lookup"><span data-stu-id="340b8-140">Pressing the "see more" \[•••\] button reveals primary command labels and opens the overflow menu if there are secondary commands.</span></span> <span data-ttu-id="340b8-141">このボタンは、プライマリ コマンド ラベルもセカンダリ ラベルもない場合には表示されません。</span><span class="sxs-lookup"><span data-stu-id="340b8-141">The button will not be visible when no primary command labels or secondary labels are present.</span></span> <span data-ttu-id="340b8-142">既定の動作を変更するには、[OverflowButtonVisibility](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.commandbar.overflowbuttonvisibility.aspx) プロパティを使います。</span><span class="sxs-lookup"><span data-stu-id="340b8-142">To change default behavior, use the [OverflowButtonVisibility](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.commandbar.overflowbuttonvisibility.aspx) property.</span></span>
- <span data-ttu-id="340b8-143">オーバーフロー メニューは、コマンド バーが開いていて、[SecondaryCommands](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.commandbar.secondarycommands.aspx) プロパティが指定されている場合にのみ表示されます。</span><span class="sxs-lookup"><span data-stu-id="340b8-143">The overflow menu is shown only when the command bar is open and the [SecondaryCommands](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.commandbar.secondarycommands.aspx) property is populated.</span></span> <span data-ttu-id="340b8-144">スペースが限られている場合に、プライマリ コマンドは SecondaryCommands 領域に移動されます。</span><span class="sxs-lookup"><span data-stu-id="340b8-144">When space is limited, primary commands will move into the SecondaryCommands area.</span></span> <span data-ttu-id="340b8-145">既定の動作を変更するには、[IsDynamicOverflowEnabled](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.commandbar.isdynamicoverflowenabled.aspx) プロパティを使います。</span><span class="sxs-lookup"><span data-stu-id="340b8-145">To change default behavior, use the [IsDynamicOverflowEnabled](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.commandbar.isdynamicoverflowenabled.aspx) property.</span></span>

<span data-ttu-id="340b8-146">[FlowDirection](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.frameworkelement.flowdirection.aspx) が **RightToLeft** のときは、レイアウトが逆になります。</span><span class="sxs-lookup"><span data-stu-id="340b8-146">The layout is reversed when the [FlowDirection](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.frameworkelement.flowdirection.aspx) is **RightToLeft**.</span></span>

## <a name="create-a-command-bar"></a><span data-ttu-id="340b8-147">コマンド バーの作成</span><span class="sxs-lookup"><span data-stu-id="340b8-147">Create a command bar</span></span>
<span data-ttu-id="340b8-148">次の例では、上に示したコマンド バーが作成されます。</span><span class="sxs-lookup"><span data-stu-id="340b8-148">This example creates the command bar shown previously.</span></span>

```xaml
<CommandBar>
    <AppBarToggleButton Icon="Shuffle" Label="Shuffle" Click="AppBarButton_Click" />
    <AppBarToggleButton Icon="RepeatAll" Label="Repeat" Click="AppBarButton_Click"/>
    <AppBarSeparator/>
    <AppBarButton Icon="Back" Label="Back" Click="AppBarButton_Click"/>
    <AppBarButton Icon="Stop" Label="Stop" Click="AppBarButton_Click"/>
    <AppBarButton Icon="Play" Label="Play" Click="AppBarButton_Click"/>
    <AppBarButton Icon="Forward" Label="Forward" Click="AppBarButton_Click"/>

    <CommandBar.SecondaryCommands>
        <AppBarButton Label="Like" Click="AppBarButton_Click"/>
        <AppBarButton Label="Dislike" Click="AppBarButton_Click"/>
    </CommandBar.SecondaryCommands>

    <CommandBar.Content>
        <TextBlock Text="Now playing..." Margin="12,14"/>
    </CommandBar.Content>
</CommandBar>
```

## <a name="commands-and-content"></a><span data-ttu-id="340b8-149">コマンドとコンテンツ</span><span class="sxs-lookup"><span data-stu-id="340b8-149">Commands and content</span></span>
<span data-ttu-id="340b8-150">CommandBar コントロールには [PrimaryCommands](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.commandbar.primarycommands.aspx)、[SecondaryCommands](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.commandbar.secondarycommands.aspx)、[Content](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.contentcontrol.content.aspx) の 3 つのプロパティがあり、コマンドとコンテンツを追加するために使うことができます。</span><span class="sxs-lookup"><span data-stu-id="340b8-150">The CommandBar control has 3 properties you can use to add commands and content: [PrimaryCommands](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.commandbar.primarycommands.aspx), [SecondaryCommands](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.commandbar.secondarycommands.aspx), and [Content](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.contentcontrol.content.aspx).</span></span>


### <a name="commands"></a><span data-ttu-id="340b8-151">コマンド</span><span class="sxs-lookup"><span data-stu-id="340b8-151">Commands</span></span>

<span data-ttu-id="340b8-152">既定では、コマンド バーの項目は **PrimaryCommands** コレクションに追加されます。</span><span class="sxs-lookup"><span data-stu-id="340b8-152">By default, command bar items are added to the **PrimaryCommands** collection.</span></span> <span data-ttu-id="340b8-153">最も重要なコマンドを常に表示できるように、重要度順にコマンドを追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="340b8-153">You should add commands in order of their importance so that the most important commands are always visible.</span></span> <span data-ttu-id="340b8-154">ユーザーによるアプリ ウィンドウのサイズ変更などでコマンド バーの幅が変化した場合、プライマリ コマンドはブレークポイントを境としてコマンド バーとオーバーフロー メニューの間を動的に移動します。</span><span class="sxs-lookup"><span data-stu-id="340b8-154">When the command bar width changes, such as when users resize their app window, primary commands dynamically move between the command bar and the overflow menu at breakpoints.</span></span> <span data-ttu-id="340b8-155">この既定の動作を変更するには、[IsDynamicOverflowEnabled](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.commandbar.isdynamicoverflowenabled.aspx) プロパティを使います。</span><span class="sxs-lookup"><span data-stu-id="340b8-155">To change this default behavior, use the [IsDynamicOverflowEnabled](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.commandbar.isdynamicoverflowenabled.aspx) property.</span></span> 

<span data-ttu-id="340b8-156">最小画面 (幅 320 epx) には、最大 4 つのプライマリ コマンドを、コマンド バーに配置できます。</span><span class="sxs-lookup"><span data-stu-id="340b8-156">On the smallest screens (320 epx width), a maximum of 4 primary commands fit in the command bar.</span></span> 

<span data-ttu-id="340b8-157">**SecondaryCommands** コレクションにコマンドを追加することもできます。これらは、オーバーフロー メニューに表示されます。</span><span class="sxs-lookup"><span data-stu-id="340b8-157">You can also add commands to the **SecondaryCommands** collection, which are shown in the overflow menu.</span></span>

![[その他] 領域とアイコンがあるコマンド バーの例](images/appbar_rs2_overflow_icons.png)

<span data-ttu-id="340b8-159">必要に応じて、プログラムを使って PrimaryCommands と SecondaryCommands の間でコマンドを移動できます。</span><span class="sxs-lookup"><span data-stu-id="340b8-159">You can programmatically move commands between the PrimaryCommands and SecondaryCommands as needed.</span></span>

- *<span data-ttu-id="340b8-160">複数のページで一貫して表示されるコマンドがある場合は、一貫した場所にそのコマンドを配置することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="340b8-160">If there is a command that would appear consistently across pages, it's best to keep that command in a consistent location.</span></span>*
- *<span data-ttu-id="340b8-161">また、[Accept] （承諾）、[Yes] （はい）、[OK] （OK） コマンドは、[Reject] （拒否）、[No] （いいえ）、[Cancel] （キャンセル） コマンドの左に配置することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="340b8-161">We recommended placing Accept, Yes, and OK commands to the left of Reject, No, and Cancel.</span></span> <span data-ttu-id="340b8-162">一貫性があることで、ユーザーは安心してシステム内を移動でき、アプリのナビゲーションに関する知識をさまざまなアプリで利用することができます。</span><span class="sxs-lookup"><span data-stu-id="340b8-162">Consistency gives users the confidence to move around the system and helps them transfer their knowledge of app navigation from app to app.</span></span>*

### <a name="app-bar-buttons"></a><span data-ttu-id="340b8-163">アプリ バーのボタン</span><span class="sxs-lookup"><span data-stu-id="340b8-163">App bar buttons</span></span>

<span data-ttu-id="340b8-164">PrimaryCommands と SecondaryCommands には、どちらも [AppBarButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbarbutton.aspx)、[AppBarToggleButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbartogglebutton.aspx)、[AppBarSeparator](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbarseparator.aspx) の各コマンド要素のみを入力できます。</span><span class="sxs-lookup"><span data-stu-id="340b8-164">Both the PrimaryCommands and SecondaryCommands can be populated only with [AppBarButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbarbutton.aspx), [AppBarToggleButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbartogglebutton.aspx), and [AppBarSeparator](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbarseparator.aspx) command elements.</span></span> 

<span data-ttu-id="340b8-165">アプリ バーのボタン コントロールは、アイコンとテキスト ラベルによって特徴付けられます。</span><span class="sxs-lookup"><span data-stu-id="340b8-165">The app bar button controls are characterized by an icon and text label.</span></span> <span data-ttu-id="340b8-166">これらのコントロールは、コマンド バーで使うように最適化されており、コマンド バーとオーバーフロー メニューのどちらで使うかに応じて外観が変化します。</span><span class="sxs-lookup"><span data-stu-id="340b8-166">These controls are optimized for use in a command bar, and their appearance changes depending on whether the control is used in the command bar or the overflow menu.</span></span>

<span data-ttu-id="340b8-167">オーバーフロー メニューのアイコンのサイズは 16 x 16 ピクセルで、基本コマンド領域のアイコン (20 x 20 ピクセル) よりも小さくなります。</span><span class="sxs-lookup"><span data-stu-id="340b8-167">The size of the icons in the overflow menu is 16x16px, which is smaller than the icons in the primary command area (which are 20x20px).</span></span> <span data-ttu-id="340b8-168">SymbolIcon、FontIcon、または PathIcon を使うと、コマンドがセカンダリ コマンド領域に表示されるときに、忠実さを失うことなく、適切なサイズに自動的に調整されます。</span><span class="sxs-lookup"><span data-stu-id="340b8-168">If you use SymbolIcon, FontIcon, or PathIcon, the icon will automatically scale to the correct size with no loss of fidelity when the command enters the secondary command area.</span></span> 

### <a name="button-labels"></a><span data-ttu-id="340b8-169">ボタンのラベル</span><span class="sxs-lookup"><span data-stu-id="340b8-169">Button labels</span></span>
<span data-ttu-id="340b8-170">AppBarButton [IsCompact](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.appbarbutton.IsCompact) プロパティはラベルが表示されるかどうかを決定します。</span><span class="sxs-lookup"><span data-stu-id="340b8-170">The AppBarButton [IsCompact](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.appbarbutton.IsCompact) property determines whether the label is shown.</span></span> <span data-ttu-id="340b8-171">CommandBar コントロールで、コマンド バーの開閉に応じてコマンド バーがボタンの IsCompact プロパティを自動的に上書きします。</span><span class="sxs-lookup"><span data-stu-id="340b8-171">In a CommandBar control, the command bar overwrites the button's IsCompact property automatically as the command bar is opened and closed.</span></span>

<span data-ttu-id="340b8-172">アプリ バー ボタンのラベルを配置するには、CommandBar の [DefaultLabelPosition](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.commandbar.defaultlabelposition.aspx) プロパティを使用します。</span><span class="sxs-lookup"><span data-stu-id="340b8-172">To position app bar button labels, use CommandBar's [DefaultLabelPosition](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.commandbar.defaultlabelposition.aspx) property.</span></span>

```xaml
<CommandBar DefaultLabelPosition="Right">
    <AppBarToggleButton Icon="Shuffle" Label="Shuffle"/>
    <AppBarToggleButton Icon="RepeatAll" Label="Repeat"/>
</CommandBar>
```

![ラベルが右に配置されたコマンド バー](images/app-bar-labels-on-right.png)

<span data-ttu-id="340b8-174">比較的大きなウィンドウの場合は、ラベルを見やすくするためにアプリ バーのボタン アイコンの右に移動することを検討します。</span><span class="sxs-lookup"><span data-stu-id="340b8-174">On larger windows, consider moving labels to the right of app bar button icons to improve legibility.</span></span> <span data-ttu-id="340b8-175">ラベルを下に配置すると、コマンド バーを開かないとラベルが見えませんが、ラベルを右に配置すると、コマンド バーが閉じていてもラベルが見えます。</span><span class="sxs-lookup"><span data-stu-id="340b8-175">Labels on the bottom require users to open the command bar to reveal labels, while labels on the right are visible even when command bar is closed.</span></span>

<span data-ttu-id="340b8-176">オーバーフロー メニューで、ラベルは既定ではアイコンの右側に配置され、**LabelPosition** は無視されます。</span><span class="sxs-lookup"><span data-stu-id="340b8-176">In overflow menus, labels are positioned to the right of icons by default, and **LabelPosition** is ignored.</span></span> <span data-ttu-id="340b8-177">スタイルを調整するには、[CommandBarOverflowPresenterStyle](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.CommandBar.CommandBarOverflowPresenterStyle) プロパティを、[CommandBarOverflowPresenter](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.commandbaroverflowpresenter) をターゲットにする Style に設定します。</span><span class="sxs-lookup"><span data-stu-id="340b8-177">You can adjust the styling by setting the [CommandBarOverflowPresenterStyle](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.CommandBar.CommandBarOverflowPresenterStyle) property to a Style that targets the [CommandBarOverflowPresenter](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.commandbaroverflowpresenter).</span></span> 

<span data-ttu-id="340b8-178">ボタンのラベルは、短く、可能であれば 1 つの単語にすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="340b8-178">Button labels should be short, preferably a single word.</span></span> <span data-ttu-id="340b8-179">アイコンの下の長いラベルは複数の行に折り返されるため、開いたコマンド バーの全体的な高さが増します。</span><span class="sxs-lookup"><span data-stu-id="340b8-179">Longer labels below an icon will wrap to multiple lines, increasing the overall height of the opened command bar.</span></span> <span data-ttu-id="340b8-180">ラベルのテキストにソフト ハイフン文字 (0x00AD) を含めると、テキストの中で単語を分割する位置を示すことができます。</span><span class="sxs-lookup"><span data-stu-id="340b8-180">You can include a soft-hyphen character (0x00AD) in the text for a label to hint at the character boundary where a word break should occur.</span></span> <span data-ttu-id="340b8-181">XAML でこの処理を行うには、次のようなエスケープ シーケンスを使います。</span><span class="sxs-lookup"><span data-stu-id="340b8-181">In XAML, you express this using an escape sequence, like this:</span></span>

```xaml
<AppBarButton Icon="Back" Label="Areally&#x00AD;longlabel"/>
```

<span data-ttu-id="340b8-182">指定した場所でラベルが折り返されると、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="340b8-182">When the label wraps at the hinted location, it looks like this.</span></span>

![ラベルが折り返されたアプリ バーのボタン](images/app-bar-button-label-wrap.png)

### <a name="command-bar-flyouts"></a><span data-ttu-id="340b8-184">コマンド バーのポップアップ</span><span class="sxs-lookup"><span data-stu-id="340b8-184">Command bar flyouts</span></span>

<span data-ttu-id="340b8-185">コマンドは論理的にグループ化することを検討します。たとえば、[返信]、[全員に返信]、[転送] を [応答] メニューに配置します。</span><span class="sxs-lookup"><span data-stu-id="340b8-185">Consider logical groupings for the commands, such as placing Reply, Reply All, and Forward in a Respond menu.</span></span> <span data-ttu-id="340b8-186">通常、アプリ バー ボタンは単一のコマンドをアクティブ化しますが、アプリ バー ボタンを使用して、カスタム コンテンツを持つ [MenuFlyout](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.menuflyout.aspx) または [Flyout](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.flyout.aspx) を表示できます。</span><span class="sxs-lookup"><span data-stu-id="340b8-186">While typically an app bar button activates a single command, an app bar button can be used to show a [MenuFlyout](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.menuflyout.aspx) or [Flyout](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.flyout.aspx) with custom content.</span></span>

![コマンド バーでのポップアップの例](images/AppbarGuidelines_Flyouts.png)

### <a name="other-content"></a><span data-ttu-id="340b8-188">その他のコンテンツ</span><span class="sxs-lookup"><span data-stu-id="340b8-188">Other content</span></span>

<span data-ttu-id="340b8-189">XAML 要素をコンテンツ領域に追加するには、**Content** プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="340b8-189">You can add any XAML elements to the content area by setting the **Content** property.</span></span> <span data-ttu-id="340b8-190">複数の要素を追加する場合は、それらの要素をパネル コンテナーに配置し、パネルを Content プロパティの唯一の子にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="340b8-190">If you want to add more than one element, you need to place them in a panel container and make the panel the single child of the Content property.</span></span>

<span data-ttu-id="340b8-191">動的オーバーフローが有効になっている場合は、プライマリ コマンドがオーバーフロー メニューに移動するため、コンテンツはクリップされません。</span><span class="sxs-lookup"><span data-stu-id="340b8-191">When dynamic overflow is enabled, content will not clip because primary commands can move into the overflow menu.</span></span> <span data-ttu-id="340b8-192">それ以外の場合は、プライマリ コマンドが優先されるため、コンテンツがクリップされる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="340b8-192">Otherwise, primary commands take precedence and may cause the content to be clipped.</span></span>

<span data-ttu-id="340b8-193">[ClosedDisplayMode](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.closeddisplaymode.aspx) が **Compact** の場合、コンパクト サイズのコマンド バーよりも大きいコンテンツはクリップされる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="340b8-193">When the [ClosedDisplayMode](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.closeddisplaymode.aspx) is **Compact**, the content can be clipped if it is larger than the compact size of the command bar.</span></span> <span data-ttu-id="340b8-194">UI の一部がクリップされないようにするには、コンテンツ領域で UI の各部分を表示または非表示にするように [Opening](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.opening.aspx) と [Closed](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.closed.aspx) の各イベントを処理する必要があります。</span><span class="sxs-lookup"><span data-stu-id="340b8-194">You should handle the [Opening](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.opening.aspx) and [Closed](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.closed.aspx) events to show or hide parts of the UI in the content area so that they aren't clipped.</span></span> <span data-ttu-id="340b8-195">詳しくは、「[開いた状態と閉じた状態](#open-and-closed-states)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="340b8-195">See the [Open and closed states](#open-and-closed-states) section for more info.</span></span>


## <a name="open-and-closed-states"></a><span data-ttu-id="340b8-196">開いた状態と閉じた状態</span><span class="sxs-lookup"><span data-stu-id="340b8-196">Open and closed states</span></span>

<span data-ttu-id="340b8-197">コマンド バーは、開いたり閉じたりできます。</span><span class="sxs-lookup"><span data-stu-id="340b8-197">The command bar can be open or closed.</span></span> <span data-ttu-id="340b8-198">開いた状態の場合、プライマリ コマンド ボタンはテキスト ラベル付きで表示され、セカンダリ コマンドが存在するときはオーバーフロー メニューが開きます。</span><span class="sxs-lookup"><span data-stu-id="340b8-198">When open, the primary command buttons are shown with text labels, and the overflow menu is open if secondary commands are present.</span></span>

<span data-ttu-id="340b8-199">ユーザーは、[その他] （\[•••\]） ボタンを押して状態を切り替えることができます。</span><span class="sxs-lookup"><span data-stu-id="340b8-199">A user can switch between these states by pressing the "see more" \[•••\] button.</span></span> <span data-ttu-id="340b8-200">プログラムで切り替えるには、[IsOpen](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.isopen.aspx) プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="340b8-200">You can switch between them programmatically by setting the [IsOpen](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.isopen.aspx) property.</span></span> 

<span data-ttu-id="340b8-201">[Opening](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.opening.aspx)、[Opened](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.opened.aspx)、[Closing](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.closing.aspx)、[Closed](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.closed.aspx) の各イベントを使うと、コマンド バーの開閉に対応できます。</span><span class="sxs-lookup"><span data-stu-id="340b8-201">You can use the [Opening](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.opening.aspx), [Opened](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.opened.aspx), [Closing](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.closing.aspx), and [Closed](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.closed.aspx) events to respond to the command bar being opened or closed.</span></span>  
- <span data-ttu-id="340b8-202">Opening イベントと Closing イベントが発生するのは、切り替えアニメーションの開始前です。</span><span class="sxs-lookup"><span data-stu-id="340b8-202">The Opening and Closing events occur before the transition animation begins.</span></span>
- <span data-ttu-id="340b8-203">Opened イベントと Closed イベントが発生するのは、切り替えの完了後です。</span><span class="sxs-lookup"><span data-stu-id="340b8-203">The Opened and Closed events occur after the transition completes.</span></span>

<span data-ttu-id="340b8-204">次の例では、Opening イベントと Closing イベントを使ってコマンド バーの不透明度を変更します。</span><span class="sxs-lookup"><span data-stu-id="340b8-204">In this example, the Opening and Closing events are used to change the opacity of the command bar.</span></span> <span data-ttu-id="340b8-205">コマンド バーが閉じているときは、アプリの背景が見えるようにコマンド バーが半透明になります。</span><span class="sxs-lookup"><span data-stu-id="340b8-205">When the command bar is closed, it's semi-transparent so the app background shows through.</span></span> <span data-ttu-id="340b8-206">コマンド バーが開いているときは、ユーザーがコマンドに集中できるようにコマンド バーが不透明になります。</span><span class="sxs-lookup"><span data-stu-id="340b8-206">When the command bar is opened, the command bar is made opaque so the user can focus on the commands.</span></span>

```xaml
<CommandBar Opening="CommandBar_Opening"
            Closing="CommandBar_Closing">
    <AppBarButton Icon="Accept" Label="Accept"/>
    <AppBarButton Icon="Edit" Label="Edit"/>
    <AppBarButton Icon="Save" Label="Save"/>
    <AppBarButton Icon="Cancel" Label="Cancel"/>
</CommandBar>
```

```csharp
private void CommandBar_Opening(object sender, object e)
{
    CommandBar cb = sender as CommandBar;
    if (cb != null) cb.Background.Opacity = 1.0;
}

private void CommandBar_Closing(object sender, object e)
{
    CommandBar cb = sender as CommandBar;
    if (cb != null) cb.Background.Opacity = 0.5;
}

```

### <a name="issticky"></a><span data-ttu-id="340b8-207">IsSticky</span><span class="sxs-lookup"><span data-stu-id="340b8-207">IsSticky</span></span>

<span data-ttu-id="340b8-208">コマンド バーが開いているときにユーザーがアプリの他の部分とやり取りすると、コマンド バーは自動的に閉じます。</span><span class="sxs-lookup"><span data-stu-id="340b8-208">If a user interacts with other parts of an app when a command bar is open, then the command bar will automatically close.</span></span> <span data-ttu-id="340b8-209">これは*簡易非表示*と呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="340b8-209">This is called *light dismiss*.</span></span> <span data-ttu-id="340b8-210">簡易非表示動作を制御するには、[IsSticky](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.issticky.aspx) プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="340b8-210">You can control light dismiss behavior by setting the [IsSticky](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.issticky.aspx) property.</span></span> <span data-ttu-id="340b8-211">`IsSticky="true"` の場合、ユーザーが [その他] （\[•••\]） ボタンを押すか、オーバーフロー メニューから項目を選ぶまで、バーは開いたままになります。</span><span class="sxs-lookup"><span data-stu-id="340b8-211">When `IsSticky="true"`, the bar remains open until the user presses the "see more" \[•••\] button or selects an item from the overflow menu.</span></span> 

<span data-ttu-id="340b8-212">固定のコマンド バーは、簡易非表示に関してユーザーが期待する動作と一致しないため、使わないことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="340b8-212">We recommend avoiding sticky command bars because they don't conform to users' expectations around light dismiss.</span></span>

### <a name="display-mode"></a><span data-ttu-id="340b8-213">表示モード</span><span class="sxs-lookup"><span data-stu-id="340b8-213">Display Mode</span></span>

<span data-ttu-id="340b8-214">コマンド バーが閉じた状態でどのように表示されるか制御するには、[ClosedDisplayMode](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.closeddisplaymode.aspx) プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="340b8-214">You can control how the command bar is shown in its closed state by setting the [ClosedDisplayMode](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.closeddisplaymode.aspx) property.</span></span> <span data-ttu-id="340b8-215">3 つのクローズド表示モードから選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="340b8-215">There are 3 closed display modes to choose from:</span></span>
- <span data-ttu-id="340b8-216">**Compact**: 既定のモードです。</span><span class="sxs-lookup"><span data-stu-id="340b8-216">**Compact**: The default mode.</span></span> <span data-ttu-id="340b8-217">コンテンツ、プライマリ コマンドのアイコン (ラベルなし)、[その他] （\[•••\]） ボタンが表示されます。</span><span class="sxs-lookup"><span data-stu-id="340b8-217">Shows content, primary command icons without labels, and the "see more" \[•••\] button.</span></span>
- <span data-ttu-id="340b8-218">**Minimal**: [その他] （\[•••\]） ボタンとして機能する細いバーのみが表示されます。</span><span class="sxs-lookup"><span data-stu-id="340b8-218">**Minimal**: Shows only a thin bar that acts as the "see more" \[•••\] button.</span></span> <span data-ttu-id="340b8-219">ユーザーはバーの任意の場所を押してバーを開くことができます。</span><span class="sxs-lookup"><span data-stu-id="340b8-219">The user can press anywhere on the bar to open it.</span></span>
- <span data-ttu-id="340b8-220">**Hidden**: コマンド バーを閉じたとき、コマンド バーは表示されません。</span><span class="sxs-lookup"><span data-stu-id="340b8-220">**Hidden**: The command bar is not shown when it's closed.</span></span> <span data-ttu-id="340b8-221">このモードは、インライン コマンド バーでコンテキスト依存コマンドを表示するときに便利な場合があります。</span><span class="sxs-lookup"><span data-stu-id="340b8-221">This can be useful for showing contextual commands with an inline command bar.</span></span> <span data-ttu-id="340b8-222">この場合は、コマンド バーをプログラムで開く必要があります。この操作を行うには、**IsOpen** プロパティを設定するか、ClosedDisplayMode を **Minimal** または **Compact** に変更します。</span><span class="sxs-lookup"><span data-stu-id="340b8-222">In this case, you must open the command bar programmatically by setting the **IsOpen** property or changing the ClosedDisplayMode to **Minimal** or **Compact**.</span></span>

<span data-ttu-id="340b8-223">以下では、コマンド バーを使って [RichEditBox](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richeditbox.aspx) に単純な書式設定コマンドを保持しています。</span><span class="sxs-lookup"><span data-stu-id="340b8-223">Here, a command bar is used to hold simple formatting commands for a [RichEditBox](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richeditbox.aspx).</span></span> <span data-ttu-id="340b8-224">編集ボックスにフォーカスがないときには、書式設定コマンドが煩わしくないように非表示にします。</span><span class="sxs-lookup"><span data-stu-id="340b8-224">When the edit box doesn't have focus, the formatting commands can be distracting, so they're hidden.</span></span> <span data-ttu-id="340b8-225">編集ボックスを使っているときは、コマンド バーの ClosedDisplayMode を Compact に変更して書式設定コマンドを表示します。</span><span class="sxs-lookup"><span data-stu-id="340b8-225">When the edit box is being used, the command bar's ClosedDisplayMode is changed to Compact so the formatting commands are visible.</span></span>

```xaml
<StackPanel Width="300"
            GotFocus="EditStackPanel_GotFocus"
            LostFocus="EditStackPanel_LostFocus">
    <CommandBar x:Name="FormattingCommandBar" ClosedDisplayMode="Hidden">
        <AppBarButton Icon="Bold" Label="Bold" ToolTipService.ToolTip="Bold"/>
        <AppBarButton Icon="Italic" Label="Italic" ToolTipService.ToolTip="Italic"/>
        <AppBarButton Icon="Underline" Label="Underline" ToolTipService.ToolTip="Underline"/>
    </CommandBar>
    <RichEditBox Height="200"/>
</StackPanel>
```

```csharp
private void EditStackPanel_GotFocus(object sender, RoutedEventArgs e)
{
    FormattingCommandBar.ClosedDisplayMode = AppBarClosedDisplayMode.Compact;
}

private void EditStackPanel_LostFocus(object sender, RoutedEventArgs e)
{
    FormattingCommandBar.ClosedDisplayMode = AppBarClosedDisplayMode.Hidden;
}
```

><span data-ttu-id="340b8-226">**注**&nbsp;&nbsp;この例では編集コマンドの実装については取り上げません。</span><span class="sxs-lookup"><span data-stu-id="340b8-226">**Note**&nbsp;&nbsp;The implementation of the editing commands is beyond the scope of this example.</span></span> <span data-ttu-id="340b8-227">詳しくは、「[RichEditBox](rich-edit-box.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="340b8-227">For more info, see the [RichEditBox](rich-edit-box.md) article.</span></span>

<span data-ttu-id="340b8-228">Minimal モードと Hidden モードが役に立つ場合もありますが、すべてのアクションを非表示にするとユーザーが混乱する可能性があることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="340b8-228">Although the Minimal and Hidden modes are useful in some situations, keep in mind that hiding all actions could confuse users.</span></span>

<span data-ttu-id="340b8-229">ClosedDisplayMode を変更してユーザーにヒントを表示すると、周囲にある要素のレイアウトが影響を受けます。</span><span class="sxs-lookup"><span data-stu-id="340b8-229">Changing the ClosedDisplayMode to provide more or less of a hint to the user affects the layout of surrounding elements.</span></span> <span data-ttu-id="340b8-230">これに対し、CommandBar の開閉を切り替えても他の要素のレイアウトには影響しません。</span><span class="sxs-lookup"><span data-stu-id="340b8-230">In contrast, when the CommandBar transitions between closed and open, it does not affect the layout of other elements.</span></span>

## <a name="placement"></a><span data-ttu-id="340b8-231">配置</span><span class="sxs-lookup"><span data-stu-id="340b8-231">Placement</span></span>
<span data-ttu-id="340b8-232">コマンド バーは、アプリ ウィンドウの上部、アプリ ウィンドウの下部、またはインラインに配置できます。</span><span class="sxs-lookup"><span data-stu-id="340b8-232">Command bars can be placed at the top of the app window, at the bottom of the app window, and inline.</span></span>

![アプリ バーの配置の例 1](images/AppbarGuidelines_Placement1.png)

-   <span data-ttu-id="340b8-234">小型の携帯デバイスでは、コマンド バーを画面の下部に配置して、操作しやすくことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="340b8-234">For small handheld devices, we recommend positioning command bars at the bottom of the screen for easy reachability.</span></span>
-   <span data-ttu-id="340b8-235">大きな画面を持つデバイスでは、では、コマンド バーは、ウィンドウの上端近くに配置して、気付きやすくします。</span><span class="sxs-lookup"><span data-stu-id="340b8-235">For devices with larger screens, placing command bars near the top of the window makes them more noticeable and discoverable.</span></span>

<span data-ttu-id="340b8-236">物理的な画面サイズを調べるには、[DiagonalSizeInInches](https://msdn.microsoft.com/library/windows/apps/windows.graphics.display.displayinformation.diagonalsizeininches.aspx) API を使います。</span><span class="sxs-lookup"><span data-stu-id="340b8-236">Use the [DiagonalSizeInInches](https://msdn.microsoft.com/library/windows/apps/windows.graphics.display.displayinformation.diagonalsizeininches.aspx) API to determine physical screen size.</span></span>

<span data-ttu-id="340b8-237">コマンド バーは、単一ビュー画面 (左側の例) と複数ビュー画面 (右側の例) の次の画面領域に配置できます。</span><span class="sxs-lookup"><span data-stu-id="340b8-237">Command bars can be placed in the following screen regions on single-view screens (left example) and on multi-view screens (right example).</span></span> <span data-ttu-id="340b8-238">インラインのコマンド バーは、アクション領域の任意の場所に配置できます。</span><span class="sxs-lookup"><span data-stu-id="340b8-238">Inline command bars can be placed anywhere in the action space.</span></span>

![アプリ バーの配置の例 2](images/AppbarGuidelines_Placement2.png)

><span data-ttu-id="340b8-240">**タッチ デバイス**: タッチ キーボード、つまりソフト入力パネル (SIP) が表示されているときに、コマンド バーをユーザーに対して表示したままにする必要がある場合、コマンド バーをページの [BottomAppBar](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.page.bottomappbar.aspx) プロパティに割り当てると、SIP の表示中はコマンド バーが移動して表示されたままになります。</span><span class="sxs-lookup"><span data-stu-id="340b8-240">**Touch devices**: If the command bar must remain visible to a user when the touch keyboard, or Soft Input Panel (SIP), appears then you can assign the command bar to the [BottomAppBar](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.page.bottomappbar.aspx) property of a Page and it will move to remain visible when the SIP is present.</span></span> <span data-ttu-id="340b8-241">それ以外の場合は、コマンド バーをインラインおよびアプリのコンテンツに対して相対的に配置します。</span><span class="sxs-lookup"><span data-stu-id="340b8-241">Otherwise, you should place the command bar inline and positioned relative to your app content.</span></span>

## <a name="get-the-sample-code"></a><span data-ttu-id="340b8-242">サンプル コードを入手する</span><span class="sxs-lookup"><span data-stu-id="340b8-242">Get the sample code</span></span>

- <span data-ttu-id="340b8-243">[XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - インタラクティブな形ですべての XAML コントロールを参照できます。</span><span class="sxs-lookup"><span data-stu-id="340b8-243">[XAML Controls Gallery sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - See all the XAML controls in an interactive format.</span></span>
- [<span data-ttu-id="340b8-244">XAML コマンド実行のサンプル</span><span class="sxs-lookup"><span data-stu-id="340b8-244">XAML Commanding sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkId=620019)

## <a name="related-articles"></a><span data-ttu-id="340b8-245">関連記事</span><span class="sxs-lookup"><span data-stu-id="340b8-245">Related articles</span></span>

* [<span data-ttu-id="340b8-246">UWP アプリのコマンド設計の基本</span><span class="sxs-lookup"><span data-stu-id="340b8-246">Command design basics for UWP apps</span></span>](../basics/commanding-basics.md)
* [<span data-ttu-id="340b8-247">CommandBar クラス</span><span class="sxs-lookup"><span data-stu-id="340b8-247">CommandBar class</span></span>](https://msdn.microsoft.com/library/windows/apps/dn279427)
