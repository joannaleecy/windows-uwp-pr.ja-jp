---
Description: コマンド バーを使うと、ユーザーはアプリの最も一般的なタスクに簡単にアクセスできます。
title: コマンド バー
label: App bars/command bars
template: detail.hbs
op-migration-status: ready
ms.date: 05/19/2017
ms.topic: article
keywords: windows 10, uwp
ms.assetid: 868b4145-319b-4a97-82bd-c98d966144db
pm-contact: yulikl
design-contact: ksulliv
dev-contact: niallm
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 461d6d135838a5141e6606d4c77ce21972a45fe1
ms.sourcegitcommit: aeebfe35330aa471d22121957d9b510f6ebacbcf
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/03/2019
ms.locfileid: "58901650"
---
# <a name="command-bar"></a><span data-ttu-id="83b90-104">コマンド バー</span><span class="sxs-lookup"><span data-stu-id="83b90-104">Command bar</span></span>

<span data-ttu-id="83b90-105">コマンド バーを使うと、ユーザーはアプリの最も一般的なタスクに簡単にアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="83b90-105">Command bars provide users with easy access to your app's most common tasks.</span></span> <span data-ttu-id="83b90-106">コマンド バーを使うと、アプリ レベルまたはページに固有のコマンドにアクセスできます。これは、ナビゲーション パターンと共に使用することもできます。</span><span class="sxs-lookup"><span data-stu-id="83b90-106">Command bars can provide access to app-level or page-specific commands and can be used with any navigation pattern.</span></span>

> <span data-ttu-id="83b90-107">**重要な API**:[コマンド バー クラス](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.commandbar.aspx)、 [AppBarButton クラス](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.appbarbutton.aspx)、 [AppBarToggleButton クラス](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.appbartogglebutton.aspx)、 [AppBarSeparator クラス](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.appbarseparator.aspx)</span><span class="sxs-lookup"><span data-stu-id="83b90-107">**Important APIs**: [CommandBar class](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.commandbar.aspx), [AppBarButton class](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.appbarbutton.aspx), [AppBarToggleButton class](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.appbartogglebutton.aspx), [AppBarSeparator class](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.appbarseparator.aspx)</span></span>

![アイコンを含むコマンド バーの例](images/controls_appbar_icons.png)

## <a name="is-this-the-right-control"></a><span data-ttu-id="83b90-109">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="83b90-109">Is this the right control?</span></span>

<span data-ttu-id="83b90-110">CommandBar コントロールは、汎用的で柔軟、軽量なコントロールです。画像やテキスト ブロックなどの複雑なコンテンツも、[AppBarButton](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.appbarbutton.aspx)、[AppBarToggleButton](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.appbartogglebutton.aspx)、[AppBarSeparator](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.appbarseparator.aspx) コントロールなどの単純なコマンドも表示できます。</span><span class="sxs-lookup"><span data-stu-id="83b90-110">The CommandBar control is a general-purpose, flexible, light-weight control that can display both complex content, such as images or text blocks, as well as simple commands such as [AppBarButton](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.appbarbutton.aspx), [AppBarToggleButton](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.appbartogglebutton.aspx), and [AppBarSeparator](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.appbarseparator.aspx) controls.</span></span>

> [!NOTE]
> <span data-ttu-id="83b90-111">XAML では、[AppBar](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.appbar) コントロールと [CommandBar](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.commandbar) コントロールの両方が提供されます。</span><span class="sxs-lookup"><span data-stu-id="83b90-111">XAML provides both the [AppBar](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.appbar) control and the [CommandBar](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.commandbar) control.</span></span> <span data-ttu-id="83b90-112">AppBar を使うユニバーサル Windows 8 アプリをアップグレードする場合にのみ、AppBar を使ってください。また、変更は最小限に抑える必要があります。</span><span class="sxs-lookup"><span data-stu-id="83b90-112">You should use the AppBar only when you are upgrading a Universal Windows 8 app that uses the AppBar, and need to minimize changes.</span></span> <span data-ttu-id="83b90-113">Windows 10 の新しいアプリでは、代わりに CommandBar コントロールを使うことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="83b90-113">For new apps in Windows 10, we recommend using the CommandBar control instead.</span></span> <span data-ttu-id="83b90-114">このドキュメントでは、CommandBar コントロールを使うことを前提としています。</span><span class="sxs-lookup"><span data-stu-id="83b90-114">This document assumes you are using the CommandBar control.</span></span>

## <a name="examples"></a><span data-ttu-id="83b90-115">例</span><span class="sxs-lookup"><span data-stu-id="83b90-115">Examples</span></span>

<table>
<th align="left"><span data-ttu-id="83b90-116">XAML コントロール ギャラリー</span><span class="sxs-lookup"><span data-stu-id="83b90-116">XAML Controls Gallery</span></span><th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><span data-ttu-id="83b90-117"><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックして<a href="xamlcontrolsgallery:/item/CommandBar">アプリを開き、CommandBar の動作を確認</a>してください。</span><span class="sxs-lookup"><span data-stu-id="83b90-117">If you have the <strong style="font-weight: semi-bold">XAML Controls Gallery</strong> app installed, click here to <a href="xamlcontrolsgallery:/item/CommandBar">open the app and see the CommandBar in action</a>.</span></span></p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT"><span data-ttu-id="83b90-118">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</span><span class="sxs-lookup"><span data-stu-id="83b90-118">Get the XAML Controls Gallery app (Microsoft Store)</span></span></a></li>
    <li><a href="https://github.com/Microsoft/Xaml-Controls-Gallery"><span data-ttu-id="83b90-119">ソース コード (GitHub) を入手する</span><span class="sxs-lookup"><span data-stu-id="83b90-119">Get the source code (GitHub)</span></span></a></li>
    </ul>
</td>
</tr>
</table>

<span data-ttu-id="83b90-120">Microsoft フォト アプリの展開されたコマンド バーです。</span><span class="sxs-lookup"><span data-stu-id="83b90-120">An expanded command bar in the Microsoft Photos app.</span></span>

![Microsoft フォト アプリのコマンドバー](images/control-examples/command-bar-photos.png)

<span data-ttu-id="83b90-122">Windows Phone の Outlook カレンダーのコマンド バーです。</span><span class="sxs-lookup"><span data-stu-id="83b90-122">A command bar in the Outlook Calendar on Windows Phone.</span></span>

![Outlook カレンダー アプリのコマンド バー](images/control-examples/command-bar-calendar-phone.png)

## <a name="anatomy"></a><span data-ttu-id="83b90-124">構造</span><span class="sxs-lookup"><span data-stu-id="83b90-124">Anatomy</span></span>

<span data-ttu-id="83b90-125">既定で、コマンド バーにアイコンのボタンと、省略可能な「詳細」ボタンの省略記号によって表される行が表示されます\[•\]します。</span><span class="sxs-lookup"><span data-stu-id="83b90-125">By default, the command bar shows a row of icon buttons and an optional "see more" button, which is represented by an ellipsis \[•••\].</span></span> <span data-ttu-id="83b90-126">後で示すコード例を使って作成されたコマンド バーを次に示します。</span><span class="sxs-lookup"><span data-stu-id="83b90-126">Here's the command bar created by the example code shown later.</span></span> <span data-ttu-id="83b90-127">コマンド バーは、閉じたコンパクトな状態で表示されます。</span><span class="sxs-lookup"><span data-stu-id="83b90-127">It's shown in its closed compact state.</span></span>

![閉じたコマンド バー](images/command-bar-compact.png)

<span data-ttu-id="83b90-129">コマンド バーは、次のように、閉じた最小の状態で表示することもできます。</span><span class="sxs-lookup"><span data-stu-id="83b90-129">The command bar can also be shown in a closed minimal state that looks like this.</span></span> <span data-ttu-id="83b90-130">詳しくは、「[開いた状態と閉じた状態](#open-and-closed-states)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="83b90-130">See the [Open and closed states](#open-and-closed-states) section for more info.</span></span>

![閉じたコマンド バー](images/command-bar-minimal.png)

<span data-ttu-id="83b90-132">同じコマンド バーが開いている状態を次に示します。</span><span class="sxs-lookup"><span data-stu-id="83b90-132">Here's the same command bar in its open state.</span></span> <span data-ttu-id="83b90-133">ラベルは、コントロールのメイン部分を識別します。</span><span class="sxs-lookup"><span data-stu-id="83b90-133">The labels identify the main parts of the control.</span></span>

![閉じたコマンド バー](images/commandbar_anatomy_open.png)

<span data-ttu-id="83b90-135">コマンド バーは、4 つの主な領域に分かれています。</span><span class="sxs-lookup"><span data-stu-id="83b90-135">The command bar is divided into 4 main areas:</span></span>
- <span data-ttu-id="83b90-136">コンテンツ領域はバーの左側に配置されます。</span><span class="sxs-lookup"><span data-stu-id="83b90-136">The content area is aligned to the left side of the bar.</span></span> <span data-ttu-id="83b90-137">これは、[Content](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.contentcontrol.content.aspx) プロパティが指定されている場合に表示されます。</span><span class="sxs-lookup"><span data-stu-id="83b90-137">It is shown if the [Content](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.contentcontrol.content.aspx) property is populated.</span></span>
- <span data-ttu-id="83b90-138">基本コマンド領域はバーの右側に配置されます。</span><span class="sxs-lookup"><span data-stu-id="83b90-138">The primary command area is aligned to the right side of the bar.</span></span> <span data-ttu-id="83b90-139">これは、[PrimaryCommands](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.commandbar.primarycommands.aspx) プロパティが指定されている場合に表示されます。</span><span class="sxs-lookup"><span data-stu-id="83b90-139">It is shown if the [PrimaryCommands](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.commandbar.primarycommands.aspx) property is populated.</span></span>  
- <span data-ttu-id="83b90-140">See 以上" \[•\]ボタン バーの右側に表示します。</span><span class="sxs-lookup"><span data-stu-id="83b90-140">The "see more" \[•••\] button is shown on the right of the bar.</span></span> <span data-ttu-id="83b90-141">See 以上"キーを押して\[•\] primary コマンドのラベルし、セカンダリ コマンドがある場合は、オーバーフロー メニューを開き、ボタンが表示されます。</span><span class="sxs-lookup"><span data-stu-id="83b90-141">Pressing the "see more" \[•••\] button reveals primary command labels and opens the overflow menu if there are secondary commands.</span></span> <span data-ttu-id="83b90-142">このボタンは、プライマリ コマンド ラベルもセカンダリ ラベルもない場合には表示されません。</span><span class="sxs-lookup"><span data-stu-id="83b90-142">The button will not be visible when no primary command labels or secondary labels are present.</span></span> <span data-ttu-id="83b90-143">既定の動作を変更するには、[OverflowButtonVisibility](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.commandbar.overflowbuttonvisibility.aspx) プロパティを使います。</span><span class="sxs-lookup"><span data-stu-id="83b90-143">To change default behavior, use the [OverflowButtonVisibility](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.commandbar.overflowbuttonvisibility.aspx) property.</span></span>
- <span data-ttu-id="83b90-144">オーバーフロー メニューは、コマンド バーが開いていて、[SecondaryCommands](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.commandbar.secondarycommands.aspx) プロパティが指定されている場合にのみ表示されます。</span><span class="sxs-lookup"><span data-stu-id="83b90-144">The overflow menu is shown only when the command bar is open and the [SecondaryCommands](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.commandbar.secondarycommands.aspx) property is populated.</span></span> <span data-ttu-id="83b90-145">スペースが限られている場合に、プライマリ コマンドは SecondaryCommands 領域に移動されます。</span><span class="sxs-lookup"><span data-stu-id="83b90-145">When space is limited, primary commands will move into the SecondaryCommands area.</span></span> <span data-ttu-id="83b90-146">既定の動作を変更するには、[IsDynamicOverflowEnabled](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.commandbar.isdynamicoverflowenabled.aspx) プロパティを使います。</span><span class="sxs-lookup"><span data-stu-id="83b90-146">To change default behavior, use the [IsDynamicOverflowEnabled](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.commandbar.isdynamicoverflowenabled.aspx) property.</span></span>

<span data-ttu-id="83b90-147">[FlowDirection](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.frameworkelement.flowdirection.aspx) が **RightToLeft** のときは、レイアウトが逆になります。</span><span class="sxs-lookup"><span data-stu-id="83b90-147">The layout is reversed when the [FlowDirection](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.frameworkelement.flowdirection.aspx) is **RightToLeft**.</span></span>

## <a name="create-a-command-bar"></a><span data-ttu-id="83b90-148">コマンド バーの作成</span><span class="sxs-lookup"><span data-stu-id="83b90-148">Create a command bar</span></span>
<span data-ttu-id="83b90-149">次の例では、上に示したコマンド バーが作成されます。</span><span class="sxs-lookup"><span data-stu-id="83b90-149">This example creates the command bar shown previously.</span></span>

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

## <a name="commands-and-content"></a><span data-ttu-id="83b90-150">コマンドとコンテンツ</span><span class="sxs-lookup"><span data-stu-id="83b90-150">Commands and content</span></span>
<span data-ttu-id="83b90-151">コマンド バー コントロールには、コマンドとコンテンツを追加する際、3 つのプロパティがあります。[PrimaryCommands](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.commandbar.primarycommands.aspx)、 [SecondaryCommands](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.commandbar.secondarycommands.aspx)、および[コンテンツ](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.contentcontrol.content.aspx)します。</span><span class="sxs-lookup"><span data-stu-id="83b90-151">The CommandBar control has 3 properties you can use to add commands and content: [PrimaryCommands](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.commandbar.primarycommands.aspx), [SecondaryCommands](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.commandbar.secondarycommands.aspx), and [Content](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.contentcontrol.content.aspx).</span></span>


### <a name="commands"></a><span data-ttu-id="83b90-152">コマンド</span><span class="sxs-lookup"><span data-stu-id="83b90-152">Commands</span></span>

<span data-ttu-id="83b90-153">既定では、コマンド バーの項目は **PrimaryCommands** コレクションに追加されます。</span><span class="sxs-lookup"><span data-stu-id="83b90-153">By default, command bar items are added to the **PrimaryCommands** collection.</span></span> <span data-ttu-id="83b90-154">最も重要なコマンドを常に表示できるように、重要度順にコマンドを追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="83b90-154">You should add commands in order of their importance so that the most important commands are always visible.</span></span> <span data-ttu-id="83b90-155">ユーザーによるアプリ ウィンドウのサイズ変更などでコマンド バーの幅が変化した場合、プライマリ コマンドはブレークポイントを境としてコマンド バーとオーバーフロー メニューの間を動的に移動します。</span><span class="sxs-lookup"><span data-stu-id="83b90-155">When the command bar width changes, such as when users resize their app window, primary commands dynamically move between the command bar and the overflow menu at breakpoints.</span></span> <span data-ttu-id="83b90-156">この既定の動作を変更するには、[IsDynamicOverflowEnabled](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.commandbar.isdynamicoverflowenabled.aspx) プロパティを使います。</span><span class="sxs-lookup"><span data-stu-id="83b90-156">To change this default behavior, use the [IsDynamicOverflowEnabled](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.commandbar.isdynamicoverflowenabled.aspx) property.</span></span> 

<span data-ttu-id="83b90-157">最小画面 (幅 320 epx) には、最大 4 つのプライマリ コマンドを、コマンド バーに配置できます。</span><span class="sxs-lookup"><span data-stu-id="83b90-157">On the smallest screens (320 epx width), a maximum of 4 primary commands fit in the command bar.</span></span> 

<span data-ttu-id="83b90-158">**SecondaryCommands** コレクションにコマンドを追加することもできます。これらは、オーバーフロー メニューに表示されます。</span><span class="sxs-lookup"><span data-stu-id="83b90-158">You can also add commands to the **SecondaryCommands** collection, which are shown in the overflow menu.</span></span>

![[その他] 領域とアイコンがあるコマンド バーの例](images/appbar_rs2_overflow_icons.png)

<span data-ttu-id="83b90-160">必要に応じて、プログラムを使って PrimaryCommands と SecondaryCommands の間でコマンドを移動できます。</span><span class="sxs-lookup"><span data-stu-id="83b90-160">You can programmatically move commands between the PrimaryCommands and SecondaryCommands as needed.</span></span>

- *<span data-ttu-id="83b90-161">複数のページで一貫して表示されるコマンドがある場合は、一貫した場所にそのコマンドを配置することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="83b90-161">If there is a command that would appear consistently across pages, it's best to keep that command in a consistent location.</span></span>*
- *<span data-ttu-id="83b90-162">また、[Accept] （承諾）、[Yes] （はい）、[OK] （OK） コマンドは、[Reject] （拒否）、[No] （いいえ）、[Cancel] （キャンセル） コマンドの左に配置することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="83b90-162">We recommended placing Accept, Yes, and OK commands to the left of Reject, No, and Cancel.</span></span> <span data-ttu-id="83b90-163">一貫性があることで、ユーザーは安心してシステム内を移動でき、アプリのナビゲーションに関する知識をさまざまなアプリで利用することができます。</span><span class="sxs-lookup"><span data-stu-id="83b90-163">Consistency gives users the confidence to move around the system and helps them transfer their knowledge of app navigation from app to app.</span></span>*

### <a name="app-bar-buttons"></a><span data-ttu-id="83b90-164">アプリ バーのボタン</span><span class="sxs-lookup"><span data-stu-id="83b90-164">App bar buttons</span></span>

<span data-ttu-id="83b90-165">PrimaryCommands と SecondaryCommands には、どちらも [AppBarButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbarbutton.aspx)、[AppBarToggleButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbartogglebutton.aspx)、[AppBarSeparator](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbarseparator.aspx) の各コマンド要素のみを入力できます。</span><span class="sxs-lookup"><span data-stu-id="83b90-165">Both the PrimaryCommands and SecondaryCommands can be populated only with [AppBarButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbarbutton.aspx), [AppBarToggleButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbartogglebutton.aspx), and [AppBarSeparator](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbarseparator.aspx) command elements.</span></span> 

<span data-ttu-id="83b90-166">アプリ バーのボタン コントロールは、アイコンとテキスト ラベルによって特徴付けられます。</span><span class="sxs-lookup"><span data-stu-id="83b90-166">The app bar button controls are characterized by an icon and text label.</span></span> <span data-ttu-id="83b90-167">これらのコントロールは、コマンド バーで使うように最適化されており、コマンド バーとオーバーフロー メニューのどちらで使うかに応じて外観が変化します。</span><span class="sxs-lookup"><span data-stu-id="83b90-167">These controls are optimized for use in a command bar, and their appearance changes depending on whether the control is used in the command bar or the overflow menu.</span></span>

<span data-ttu-id="83b90-168">オーバーフロー メニューのアイコンのサイズは 16 x 16 ピクセルで、基本コマンド領域のアイコン (20 x 20 ピクセル) よりも小さくなります。</span><span class="sxs-lookup"><span data-stu-id="83b90-168">The size of the icons in the overflow menu is 16x16px, which is smaller than the icons in the primary command area (which are 20x20px).</span></span> <span data-ttu-id="83b90-169">SymbolIcon、FontIcon、または PathIcon を使うと、コマンドがセカンダリ コマンド領域に表示されるときに、忠実さを失うことなく、適切なサイズに自動的に調整されます。</span><span class="sxs-lookup"><span data-stu-id="83b90-169">If you use SymbolIcon, FontIcon, or PathIcon, the icon will automatically scale to the correct size with no loss of fidelity when the command enters the secondary command area.</span></span> 

### <a name="button-labels"></a><span data-ttu-id="83b90-170">ボタンのラベル</span><span class="sxs-lookup"><span data-stu-id="83b90-170">Button labels</span></span>
<span data-ttu-id="83b90-171">AppBarButton [IsCompact](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.appbarbutton.IsCompact) プロパティはラベルが表示されるかどうかを決定します。</span><span class="sxs-lookup"><span data-stu-id="83b90-171">The AppBarButton [IsCompact](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.appbarbutton.IsCompact) property determines whether the label is shown.</span></span> <span data-ttu-id="83b90-172">CommandBar コントロールで、コマンド バーの開閉に応じてコマンド バーがボタンの IsCompact プロパティを自動的に上書きします。</span><span class="sxs-lookup"><span data-stu-id="83b90-172">In a CommandBar control, the command bar overwrites the button's IsCompact property automatically as the command bar is opened and closed.</span></span>

<span data-ttu-id="83b90-173">アプリ バー ボタンのラベルを配置するには、CommandBar の [DefaultLabelPosition](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.commandbar.defaultlabelposition.aspx) プロパティを使用します。</span><span class="sxs-lookup"><span data-stu-id="83b90-173">To position app bar button labels, use CommandBar's [DefaultLabelPosition](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.commandbar.defaultlabelposition.aspx) property.</span></span>

```xaml
<CommandBar DefaultLabelPosition="Right">
    <AppBarToggleButton Icon="Shuffle" Label="Shuffle"/>
    <AppBarToggleButton Icon="RepeatAll" Label="Repeat"/>
</CommandBar>
```

![ラベルが右に配置されたコマンド バー](images/app-bar-labels-on-right.png)

<span data-ttu-id="83b90-175">比較的大きなウィンドウの場合は、ラベルを見やすくするためにアプリ バーのボタン アイコンの右に移動することを検討します。</span><span class="sxs-lookup"><span data-stu-id="83b90-175">On larger windows, consider moving labels to the right of app bar button icons to improve legibility.</span></span> <span data-ttu-id="83b90-176">ラベルを下に配置すると、コマンド バーを開かないとラベルが見えませんが、ラベルを右に配置すると、コマンド バーが閉じていてもラベルが見えます。</span><span class="sxs-lookup"><span data-stu-id="83b90-176">Labels on the bottom require users to open the command bar to reveal labels, while labels on the right are visible even when command bar is closed.</span></span>

<span data-ttu-id="83b90-177">オーバーフロー メニューで、ラベルは既定ではアイコンの右側に配置され、**LabelPosition** は無視されます。</span><span class="sxs-lookup"><span data-stu-id="83b90-177">In overflow menus, labels are positioned to the right of icons by default, and **LabelPosition** is ignored.</span></span> <span data-ttu-id="83b90-178">スタイルを調整するには、[CommandBarOverflowPresenterStyle](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.CommandBar.CommandBarOverflowPresenterStyle) プロパティを、[CommandBarOverflowPresenter](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.commandbaroverflowpresenter) をターゲットにする Style に設定します。</span><span class="sxs-lookup"><span data-stu-id="83b90-178">You can adjust the styling by setting the [CommandBarOverflowPresenterStyle](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.CommandBar.CommandBarOverflowPresenterStyle) property to a Style that targets the [CommandBarOverflowPresenter](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.commandbaroverflowpresenter).</span></span> 

<span data-ttu-id="83b90-179">ボタンのラベルは、短く、可能であれば 1 つの単語にすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="83b90-179">Button labels should be short, preferably a single word.</span></span> <span data-ttu-id="83b90-180">アイコンの下の長いラベルは複数の行に折り返されるため、開いたコマンド バーの全体的な高さが増します。</span><span class="sxs-lookup"><span data-stu-id="83b90-180">Longer labels below an icon will wrap to multiple lines, increasing the overall height of the opened command bar.</span></span> <span data-ttu-id="83b90-181">ラベルのテキストにソフト ハイフン文字 (0x00AD) を含めると、テキストの中で単語を分割する位置を示すことができます。</span><span class="sxs-lookup"><span data-stu-id="83b90-181">You can include a soft-hyphen character (0x00AD) in the text for a label to hint at the character boundary where a word break should occur.</span></span> <span data-ttu-id="83b90-182">XAML でこの処理を行うには、次のようなエスケープ シーケンスを使います。</span><span class="sxs-lookup"><span data-stu-id="83b90-182">In XAML, you express this using an escape sequence, like this:</span></span>

```xaml
<AppBarButton Icon="Back" Label="Areally&#x00AD;longlabel"/>
```

<span data-ttu-id="83b90-183">指定した場所でラベルが折り返されると、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="83b90-183">When the label wraps at the hinted location, it looks like this.</span></span>

![ラベルが折り返されたアプリ バーのボタン](images/app-bar-button-label-wrap.png)

### <a name="command-bar-flyouts"></a><span data-ttu-id="83b90-185">コマンド バーのポップアップ</span><span class="sxs-lookup"><span data-stu-id="83b90-185">Command bar flyouts</span></span>

<span data-ttu-id="83b90-186">コマンドは論理的にグループ化することを検討します。たとえば、[返信]、[全員に返信]、[転送] を [応答] メニューに配置します。</span><span class="sxs-lookup"><span data-stu-id="83b90-186">Consider logical groupings for the commands, such as placing Reply, Reply All, and Forward in a Respond menu.</span></span> <span data-ttu-id="83b90-187">通常、アプリ バー ボタンは単一のコマンドをアクティブ化しますが、アプリ バー ボタンを使用して、カスタム コンテンツを持つ [MenuFlyout](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.menuflyout.aspx) または [Flyout](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.flyout.aspx) を表示できます。</span><span class="sxs-lookup"><span data-stu-id="83b90-187">While typically an app bar button activates a single command, an app bar button can be used to show a [MenuFlyout](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.menuflyout.aspx) or [Flyout](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.flyout.aspx) with custom content.</span></span>

![コマンド バーでのポップアップの例](images/AppbarGuidelines_Flyouts.png)

### <a name="other-content"></a><span data-ttu-id="83b90-189">その他のコンテンツ</span><span class="sxs-lookup"><span data-stu-id="83b90-189">Other content</span></span>

<span data-ttu-id="83b90-190">XAML 要素をコンテンツ領域に追加するには、**Content** プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="83b90-190">You can add any XAML elements to the content area by setting the **Content** property.</span></span> <span data-ttu-id="83b90-191">複数の要素を追加する場合は、それらの要素をパネル コンテナーに配置し、パネルを Content プロパティの唯一の子にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="83b90-191">If you want to add more than one element, you need to place them in a panel container and make the panel the single child of the Content property.</span></span>

<span data-ttu-id="83b90-192">動的オーバーフローが有効になっている場合は、プライマリ コマンドがオーバーフロー メニューに移動するため、コンテンツはクリップされません。</span><span class="sxs-lookup"><span data-stu-id="83b90-192">When dynamic overflow is enabled, content will not clip because primary commands can move into the overflow menu.</span></span> <span data-ttu-id="83b90-193">それ以外の場合は、プライマリ コマンドが優先されるため、コンテンツがクリップされる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="83b90-193">Otherwise, primary commands take precedence and may cause the content to be clipped.</span></span>

<span data-ttu-id="83b90-194">[ClosedDisplayMode](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.closeddisplaymode.aspx) が **Compact** の場合、コンパクト サイズのコマンド バーよりも大きいコンテンツはクリップされる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="83b90-194">When the [ClosedDisplayMode](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.closeddisplaymode.aspx) is **Compact**, the content can be clipped if it is larger than the compact size of the command bar.</span></span> <span data-ttu-id="83b90-195">UI の一部がクリップされないようにするには、コンテンツ領域で UI の各部分を表示または非表示にするように [Opening](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.opening.aspx) と [Closed](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.closed.aspx) の各イベントを処理する必要があります。</span><span class="sxs-lookup"><span data-stu-id="83b90-195">You should handle the [Opening](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.opening.aspx) and [Closed](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.closed.aspx) events to show or hide parts of the UI in the content area so that they aren't clipped.</span></span> <span data-ttu-id="83b90-196">詳しくは、「[開いた状態と閉じた状態](#open-and-closed-states)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="83b90-196">See the [Open and closed states](#open-and-closed-states) section for more info.</span></span>


## <a name="open-and-closed-states"></a><span data-ttu-id="83b90-197">開いた状態と閉じた状態</span><span class="sxs-lookup"><span data-stu-id="83b90-197">Open and closed states</span></span>

<span data-ttu-id="83b90-198">コマンド バーは、開いたり閉じたりできます。</span><span class="sxs-lookup"><span data-stu-id="83b90-198">The command bar can be open or closed.</span></span> <span data-ttu-id="83b90-199">開いているときは、テキスト ラベルが付いた primary コマンド ボタンを表示してと (セカンダリ コマンドがある) 場合は、オーバーフロー メニューを開きます。</span><span class="sxs-lookup"><span data-stu-id="83b90-199">When it's open, it shows primary command buttons with text labels and it opens the overflow menu  (if there are secondary commands).</span></span>
<span data-ttu-id="83b90-200">コマンド バー メニューを開き、オーバーフロー上 (プライマリ コマンド) 上または下 (プライマリ コマンド) 以下。</span><span class="sxs-lookup"><span data-stu-id="83b90-200">The command bar opens the overflow menu upwards (above the primary commands) or downwards (below the primary commands).</span></span> <span data-ttu-id="83b90-201">既定の方向しますが、上方にオーバーフロー メニューを開くには、十分な領域がない場合、コマンド バー開くために下方向。</span><span class="sxs-lookup"><span data-stu-id="83b90-201">The default direction is up, but if there's not enough space to open the overflow menu upwards, the command bar opens it downwards.</span></span> 

<span data-ttu-id="83b90-202">ユーザーは、キーを押して、「参照」これらの状態を切り替えることができます\[•\]ボタンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="83b90-202">A user can switch between these states by pressing the "see more" \[•••\] button.</span></span> <span data-ttu-id="83b90-203">プログラムで切り替えるには、[IsOpen](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.isopen.aspx) プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="83b90-203">You can switch between them programmatically by setting the [IsOpen](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.isopen.aspx) property.</span></span> 

<span data-ttu-id="83b90-204">[Opening](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.opening.aspx)、[Opened](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.opened.aspx)、[Closing](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.closing.aspx)、[Closed](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.closed.aspx) の各イベントを使うと、コマンド バーの開閉に対応できます。</span><span class="sxs-lookup"><span data-stu-id="83b90-204">You can use the [Opening](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.opening.aspx), [Opened](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.opened.aspx), [Closing](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.closing.aspx), and [Closed](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.closed.aspx) events to respond to the command bar being opened or closed.</span></span>  
- <span data-ttu-id="83b90-205">Opening イベントと Closing イベントが発生するのは、切り替えアニメーションの開始前です。</span><span class="sxs-lookup"><span data-stu-id="83b90-205">The Opening and Closing events occur before the transition animation begins.</span></span>
- <span data-ttu-id="83b90-206">Opened イベントと Closed イベントが発生するのは、切り替えの完了後です。</span><span class="sxs-lookup"><span data-stu-id="83b90-206">The Opened and Closed events occur after the transition completes.</span></span>

<span data-ttu-id="83b90-207">次の例では、Opening イベントと Closing イベントを使ってコマンド バーの不透明度を変更します。</span><span class="sxs-lookup"><span data-stu-id="83b90-207">In this example, the Opening and Closing events are used to change the opacity of the command bar.</span></span> <span data-ttu-id="83b90-208">コマンド バーが閉じているときは、アプリの背景が見えるようにコマンド バーが半透明になります。</span><span class="sxs-lookup"><span data-stu-id="83b90-208">When the command bar is closed, it's semi-transparent so the app background shows through.</span></span> <span data-ttu-id="83b90-209">コマンド バーが開いているときは、ユーザーがコマンドに集中できるようにコマンド バーが不透明になります。</span><span class="sxs-lookup"><span data-stu-id="83b90-209">When the command bar is opened, the command bar is made opaque so the user can focus on the commands.</span></span>

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

### <a name="issticky"></a><span data-ttu-id="83b90-210">IsSticky</span><span class="sxs-lookup"><span data-stu-id="83b90-210">IsSticky</span></span>

<span data-ttu-id="83b90-211">コマンド バーが開いているときにユーザーがアプリの他の部分とやり取りすると、コマンド バーは自動的に閉じます。</span><span class="sxs-lookup"><span data-stu-id="83b90-211">If a user interacts with other parts of an app when a command bar is open, then the command bar will automatically close.</span></span> <span data-ttu-id="83b90-212">これは*簡易非表示*と呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="83b90-212">This is called *light dismiss*.</span></span> <span data-ttu-id="83b90-213">簡易非表示動作を制御するには、[IsSticky](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.issticky.aspx) プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="83b90-213">You can control light dismiss behavior by setting the [IsSticky](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.issticky.aspx) property.</span></span> <span data-ttu-id="83b90-214">ときに`IsSticky="true"`、ユーザーは、「参照」を押すまで、バーが開いたまま\[•\]ボタンまたはオーバーフロー メニューから項目を選択します。</span><span class="sxs-lookup"><span data-stu-id="83b90-214">When `IsSticky="true"`, the bar remains open until the user presses the "see more" \[•••\] button or selects an item from the overflow menu.</span></span> 

<span data-ttu-id="83b90-215">に対するユーザーの期待に準拠していないため、固定のコマンド バーを回避することをお勧めします。[光を無視し、キーボード フォーカスの動作](https://docs.microsoft.com/windows/uwp/design/controls-and-patterns/menus#light-dismiss)します。</span><span class="sxs-lookup"><span data-stu-id="83b90-215">We recommend avoiding sticky command bars because they don't conform to users' expectations for [light dismiss and keyboard focus behavior](https://docs.microsoft.com/windows/uwp/design/controls-and-patterns/menus#light-dismiss).</span></span>

### <a name="display-mode"></a><span data-ttu-id="83b90-216">表示モード</span><span class="sxs-lookup"><span data-stu-id="83b90-216">Display Mode</span></span>

<span data-ttu-id="83b90-217">コマンド バーが閉じた状態でどのように表示されるか制御するには、[ClosedDisplayMode](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.closeddisplaymode.aspx) プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="83b90-217">You can control how the command bar is shown in its closed state by setting the [ClosedDisplayMode](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.closeddisplaymode.aspx) property.</span></span> <span data-ttu-id="83b90-218">3 つのクローズド表示モードから選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="83b90-218">There are 3 closed display modes to choose from:</span></span>
- <span data-ttu-id="83b90-219">**Compact**:既定のモード。</span><span class="sxs-lookup"><span data-stu-id="83b90-219">**Compact**: The default mode.</span></span> <span data-ttu-id="83b90-220">コンテンツ、primary コマンド アイコン、ラベルがない場合、「参照」が詳細を示しています。 \[•\]ボタンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="83b90-220">Shows content, primary command icons without labels, and the "see more" \[•••\] button.</span></span>
- <span data-ttu-id="83b90-221">**最小**:示していますが、「詳細」としてのみ、細いバーを動作\[•\]ボタンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="83b90-221">**Minimal**: Shows only a thin bar that acts as the "see more" \[•••\] button.</span></span> <span data-ttu-id="83b90-222">ユーザーはバーの任意の場所を押してバーを開くことができます。</span><span class="sxs-lookup"><span data-stu-id="83b90-222">The user can press anywhere on the bar to open it.</span></span>
- <span data-ttu-id="83b90-223">**非表示に**:閉じているときは、コマンド バーは表示されません。</span><span class="sxs-lookup"><span data-stu-id="83b90-223">**Hidden**: The command bar is not shown when it's closed.</span></span> <span data-ttu-id="83b90-224">このモードは、インライン コマンド バーでコンテキスト依存コマンドを表示するときに便利な場合があります。</span><span class="sxs-lookup"><span data-stu-id="83b90-224">This can be useful for showing contextual commands with an inline command bar.</span></span> <span data-ttu-id="83b90-225">この場合は、コマンド バーをプログラムで開く必要があります。この操作を行うには、**IsOpen** プロパティを設定するか、ClosedDisplayMode を **Minimal** または **Compact** に変更します。</span><span class="sxs-lookup"><span data-stu-id="83b90-225">In this case, you must open the command bar programmatically by setting the **IsOpen** property or changing the ClosedDisplayMode to **Minimal** or **Compact**.</span></span>

<span data-ttu-id="83b90-226">以下では、コマンド バーを使って [RichEditBox](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richeditbox.aspx) に単純な書式設定コマンドを保持しています。</span><span class="sxs-lookup"><span data-stu-id="83b90-226">Here, a command bar is used to hold simple formatting commands for a [RichEditBox](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richeditbox.aspx).</span></span> <span data-ttu-id="83b90-227">編集ボックスにフォーカスがないときには、書式設定コマンドが煩わしくないように非表示にします。</span><span class="sxs-lookup"><span data-stu-id="83b90-227">When the edit box doesn't have focus, the formatting commands can be distracting, so they're hidden.</span></span> <span data-ttu-id="83b90-228">編集ボックスを使っているときは、コマンド バーの ClosedDisplayMode を Compact に変更して書式設定コマンドを表示します。</span><span class="sxs-lookup"><span data-stu-id="83b90-228">When the edit box is being used, the command bar's ClosedDisplayMode is changed to Compact so the formatting commands are visible.</span></span>

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

><span data-ttu-id="83b90-229">**注**&nbsp;&nbsp;この例では編集コマンドの実装については取り上げません。</span><span class="sxs-lookup"><span data-stu-id="83b90-229">**Note**&nbsp;&nbsp;The implementation of the editing commands is beyond the scope of this example.</span></span> <span data-ttu-id="83b90-230">詳しくは、「[RichEditBox](rich-edit-box.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="83b90-230">For more info, see the [RichEditBox](rich-edit-box.md) article.</span></span>

<span data-ttu-id="83b90-231">Minimal モードと Hidden モードが役に立つ場合もありますが、すべてのアクションを非表示にするとユーザーが混乱する可能性があることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="83b90-231">Although the Minimal and Hidden modes are useful in some situations, keep in mind that hiding all actions could confuse users.</span></span>

<span data-ttu-id="83b90-232">ClosedDisplayMode を変更してユーザーにヒントを表示すると、周囲にある要素のレイアウトが影響を受けます。</span><span class="sxs-lookup"><span data-stu-id="83b90-232">Changing the ClosedDisplayMode to provide more or less of a hint to the user affects the layout of surrounding elements.</span></span> <span data-ttu-id="83b90-233">これに対し、CommandBar の開閉を切り替えても他の要素のレイアウトには影響しません。</span><span class="sxs-lookup"><span data-stu-id="83b90-233">In contrast, when the CommandBar transitions between closed and open, it does not affect the layout of other elements.</span></span>

## <a name="placement"></a><span data-ttu-id="83b90-234">配置</span><span class="sxs-lookup"><span data-stu-id="83b90-234">Placement</span></span>
<span data-ttu-id="83b90-235">コマンド バーは、アプリ ウィンドウの上部、アプリ ウィンドウの下部、またはインラインに配置できます。</span><span class="sxs-lookup"><span data-stu-id="83b90-235">Command bars can be placed at the top of the app window, at the bottom of the app window, and inline.</span></span>

![アプリ バーの配置の例 1](images/AppbarGuidelines_Placement1.png)

-   <span data-ttu-id="83b90-237">小型の携帯デバイスでは、コマンド バーを画面の下部に配置して、操作しやすくことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="83b90-237">For small handheld devices, we recommend positioning command bars at the bottom of the screen for easy reachability.</span></span>
-   <span data-ttu-id="83b90-238">大きな画面を持つデバイスでは、では、コマンド バーは、ウィンドウの上端近くに配置して、気付きやすくします。</span><span class="sxs-lookup"><span data-stu-id="83b90-238">For devices with larger screens, placing command bars near the top of the window makes them more noticeable and discoverable.</span></span>

<span data-ttu-id="83b90-239">物理的な画面サイズを調べるには、[DiagonalSizeInInches](https://msdn.microsoft.com/library/windows/apps/windows.graphics.display.displayinformation.diagonalsizeininches.aspx) API を使います。</span><span class="sxs-lookup"><span data-stu-id="83b90-239">Use the [DiagonalSizeInInches](https://msdn.microsoft.com/library/windows/apps/windows.graphics.display.displayinformation.diagonalsizeininches.aspx) API to determine physical screen size.</span></span>

<span data-ttu-id="83b90-240">コマンド バーは、単一ビュー画面 (左側の例) と複数ビュー画面 (右側の例) の次の画面領域に配置できます。</span><span class="sxs-lookup"><span data-stu-id="83b90-240">Command bars can be placed in the following screen regions on single-view screens (left example) and on multi-view screens (right example).</span></span> <span data-ttu-id="83b90-241">インラインのコマンド バーは、アクション領域の任意の場所に配置できます。</span><span class="sxs-lookup"><span data-stu-id="83b90-241">Inline command bars can be placed anywhere in the action space.</span></span>

![アプリ バーの配置の例 2](images/AppbarGuidelines_Placement2.png)

><span data-ttu-id="83b90-243">**デバイスのタッチ**:かどうかは、コマンド バーがユーザーに表示する必要がありますままタッチ キーボード、またはソフト入力パネル (SIP) は、コマンド バーを割り当てることが表示されたら、[は BottomAppBar](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.page.bottomappbar.aspx)ページとそのプロパティは、SIP が存在する場合に表示されたままに移動.</span><span class="sxs-lookup"><span data-stu-id="83b90-243">**Touch devices**: If the command bar must remain visible to a user when the touch keyboard, or Soft Input Panel (SIP), appears then you can assign the command bar to the [BottomAppBar](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.page.bottomappbar.aspx) property of a Page and it will move to remain visible when the SIP is present.</span></span> <span data-ttu-id="83b90-244">それ以外の場合は、コマンド バーをインラインおよびアプリのコンテンツに対して相対的に配置します。</span><span class="sxs-lookup"><span data-stu-id="83b90-244">Otherwise, you should place the command bar inline and positioned relative to your app content.</span></span>

## <a name="get-the-sample-code"></a><span data-ttu-id="83b90-245">サンプル コードを入手する</span><span class="sxs-lookup"><span data-stu-id="83b90-245">Get the sample code</span></span>

- <span data-ttu-id="83b90-246">[XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Xaml-Controls-Gallery) - インタラクティブな形で XAML コントロールのすべてを参照できます。</span><span class="sxs-lookup"><span data-stu-id="83b90-246">[XAML Controls Gallery sample](https://github.com/Microsoft/Xaml-Controls-Gallery) - See all the XAML controls in an interactive format.</span></span>
- [<span data-ttu-id="83b90-247">XAML コマンド実行のサンプル</span><span class="sxs-lookup"><span data-stu-id="83b90-247">XAML Commanding sample</span></span>](https://go.microsoft.com/fwlink/p/?LinkId=620019)

## <a name="related-articles"></a><span data-ttu-id="83b90-248">関連記事</span><span class="sxs-lookup"><span data-stu-id="83b90-248">Related articles</span></span>

* [<span data-ttu-id="83b90-249">UWP アプリのコマンド設計の基本</span><span class="sxs-lookup"><span data-stu-id="83b90-249">Command design basics for UWP apps</span></span>](../basics/commanding-basics.md)
* [<span data-ttu-id="83b90-250">CommandBar クラス</span><span class="sxs-lookup"><span data-stu-id="83b90-250">CommandBar class</span></span>](https://msdn.microsoft.com/library/windows/apps/dn279427)
