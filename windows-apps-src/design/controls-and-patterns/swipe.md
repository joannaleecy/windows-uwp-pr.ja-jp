---
pm-contact: kisai
design-contact: ksulliv
dev-contact: Shmazlou
doc-status: Published
Description: Swipe commanding is a touch accelerator for context menus.
title: スワイプ
label: Swipe
template: detail.hbs
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: a75723177e697d3fe4cdae270aba29eabcabf470
ms.sourcegitcommit: b11f305dbf7649c4b68550b666487c77ea30d98f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/27/2018
ms.locfileid: "7842051"
---
# <a name="swipe"></a><span data-ttu-id="33355-103">スワイプ</span><span class="sxs-lookup"><span data-stu-id="33355-103">Swipe</span></span>

<span data-ttu-id="33355-104">スワイプによるコマンド実行は、ユーザーがタッチ操作によってアプリ内の状態を変更することなく、一般的なメニュー アクションに簡単にアクセスできるようにするコンテキスト メニューのアクセラレータです。</span><span class="sxs-lookup"><span data-stu-id="33355-104">Swipe commanding is an accelerator for context menus that lets users easily access common menu actions by touch, without needing to change states within the app.</span></span>

> <span data-ttu-id="33355-105">**重要な API**: [SwipeControl](/uwp/api/windows.ui.xaml.controls.swipecontrol)、[SwipeItem](/uwp/api/windows.ui.xaml.controls.swipeitem)、[ListView class](/uwp/api/Windows.UI.Xaml.Controls.ListView)</span><span class="sxs-lookup"><span data-stu-id="33355-105">**Important APIs**: [SwipeControl](/uwp/api/windows.ui.xaml.controls.swipecontrol), [SwipeItem](/uwp/api/windows.ui.xaml.controls.swipeitem), [ListView class](/uwp/api/Windows.UI.Xaml.Controls.ListView)</span></span>

![実行と表示の淡色テーマ](images/LightThemeSwipe.png)

## <a name="is-this-the-right-control"></a><span data-ttu-id="33355-107">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="33355-107">Is this the right control?</span></span>

<span data-ttu-id="33355-108">スワイプによるコマンド実行によって、領域が節約されます。</span><span class="sxs-lookup"><span data-stu-id="33355-108">Swipe commanding saves space.</span></span> <span data-ttu-id="33355-109">これは、ユーザーが複数の項目に対して同じ操作をすばやく連続して実行できる場合に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="33355-109">It's useful in situations where the user may perform the same operation on multiple items in quick succession.</span></span> <span data-ttu-id="33355-110">ページ内で完全なポップアップや状態の変更を必要としないアイテムに対して「クイック アクション」を提供します。</span><span class="sxs-lookup"><span data-stu-id="33355-110">And it provides "quick actions" on items that don't need a full popup or state change within the page.</span></span>

<span data-ttu-id="33355-111">潜在的に多くの項目のグループで、各項目にユーザーが定期的に実行する必要がある操作が 1 ～ 3 つある場合は、スワイプによるコマンド実行を使用してください。</span><span class="sxs-lookup"><span data-stu-id="33355-111">You should use swipe commanding when you have a potentially large group of items, and each item has 1-3 actions that a user may want to perform regularly.</span></span> <span data-ttu-id="33355-112">これには次のような操作が含まれますが、これに限定されません。</span><span class="sxs-lookup"><span data-stu-id="33355-112">These actions may include, but are not limited to:</span></span>

- <span data-ttu-id="33355-113">削除</span><span class="sxs-lookup"><span data-stu-id="33355-113">Deleting</span></span>
- <span data-ttu-id="33355-114">マークやアーカイブ</span><span class="sxs-lookup"><span data-stu-id="33355-114">Marking or archiving</span></span>
- <span data-ttu-id="33355-115">保存またはダウンロード</span><span class="sxs-lookup"><span data-stu-id="33355-115">Saving or downloading</span></span>
- <span data-ttu-id="33355-116">返信</span><span class="sxs-lookup"><span data-stu-id="33355-116">Replying</span></span>

## <a name="examples"></a><span data-ttu-id="33355-117">例</span><span class="sxs-lookup"><span data-stu-id="33355-117">Examples</span></span>

<table>
<th align="left"><span data-ttu-id="33355-118">XAML コントロール ギャラリー</span><span class="sxs-lookup"><span data-stu-id="33355-118">XAML Controls Gallery</span></span><th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><span data-ttu-id="33355-119"><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックして<a href="xamlcontrolsgallery:/item/SwipeControl">アプリを開き、SwipeControl の動作を確認</a>してください。</span><span class="sxs-lookup"><span data-stu-id="33355-119">If you have the <strong style="font-weight: semi-bold">XAML Controls Gallery</strong> app installed, click here to <a href="xamlcontrolsgallery:/item/SwipeControl">open the app and see the SwipeControl in action</a>.</span></span></p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT"><span data-ttu-id="33355-120">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</span><span class="sxs-lookup"><span data-stu-id="33355-120">Get the XAML Controls Gallery app (Microsoft Store)</span></span></a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics"><span data-ttu-id="33355-121">ソース コード (GitHub) を入手する</span><span class="sxs-lookup"><span data-stu-id="33355-121">Get the source code (GitHub)</span></span></a></li>
    </ul>
</td>
</tr>
</table>

## <a name="video-summary"></a><span data-ttu-id="33355-122">概要 (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="33355-122">Video summary</span></span>

> [!VIDEO https://channel9.msdn.com/Events/Windows/Windows-Developer-Day-Fall-Creators-Update/WinDev015/player]

## <a name="how-does-swipe-work"></a><span data-ttu-id="33355-123">スワイプの動作の仕組み</span><span class="sxs-lookup"><span data-stu-id="33355-123">How does Swipe work?</span></span>

<span data-ttu-id="33355-124">UWP のスワイプによるコマンド実行には、[表示](/uwp/api/windows.ui.xaml.controls.swipemode) と[実行](/uwp/api/windows.ui.xaml.controls.swipemode) の 2 つのモードがあります。</span><span class="sxs-lookup"><span data-stu-id="33355-124">UWP swipe commanding has two modes: [Reveal](/uwp/api/windows.ui.xaml.controls.swipemode) and [Execute](/uwp/api/windows.ui.xaml.controls.swipemode).</span></span> <span data-ttu-id="33355-125">さらに、上、下、左、右の 4 つのスワイプの方向もサポートされています。</span><span class="sxs-lookup"><span data-stu-id="33355-125">It also supports four different swipe directions: up, down, left, and right.</span></span>

### <a name="reveal-mode"></a><span data-ttu-id="33355-126">表示モード</span><span class="sxs-lookup"><span data-stu-id="33355-126">Reveal mode</span></span>

<span data-ttu-id="33355-127">表示モードでは、ユーザーが項目をスワイプすると、1 つまたは複数のコマンドのメニューが開きます。ユーザーがコマンドを実行するには、コマンドを明示的にタップする必要があります。</span><span class="sxs-lookup"><span data-stu-id="33355-127">In Reveal mode, the user swipes an item to open a menu of one or more commands and must explicitly tap a command to execute it.</span></span> <span data-ttu-id="33355-128">ユーザーが項目をスワイプして、指を離すと、コマンドを選択するか、メニューを再び閉じるまで、メニューを開いたままになります。メニューが閉じられるのは、端へスワイプしたとき、別の場所をタップしたとき、または開いたスワイプ項目が画面に表示されなくなるまでスクロールしたときです。</span><span class="sxs-lookup"><span data-stu-id="33355-128">When the user swipes and releases an item, the menu remains open until either a command is selected, or the menu is closed again through swiping back, tapping off, or scrolling the opened swipe item off the screen.</span></span>

![スワイプによる表示](images/SwipeCommand-Reveal_v2.gif)

<span data-ttu-id="33355-130">表示モードは、より安全で、より多用途なスワイプ モードであり、ほとんどの種類のメニュー操作に使用できます。ただし、削除など、潜在的に破壊的な操作もあります。</span><span class="sxs-lookup"><span data-stu-id="33355-130">Reveal mode is a safer, more versatile swipe mode, and can be used for most types of menu actions, even potentially destructive actions, such as deletion.</span></span>

<span data-ttu-id="33355-131">ユーザーが表示モードの開いた安静状態で表示されているメニュー オプションの 1 つを選択すると、その項目のコマンドが呼び出され、スワイプ コントロールが閉じられます。</span><span class="sxs-lookup"><span data-stu-id="33355-131">When the user selects one of the menu options shown in the reveal's open and resting state, the command for that item is invoked and the swipe control is closed.</span></span>

### <a name="execute-mode"></a><span data-ttu-id="33355-132">実行モード</span><span class="sxs-lookup"><span data-stu-id="33355-132">Execute mode</span></span>

<span data-ttu-id="33355-133">実行モードでは、ユーザーは項目をスワイプして開き、その 1 回のスワイプで 1 つのコマンドを表示して実行します。</span><span class="sxs-lookup"><span data-stu-id="33355-133">In Execute mode, the user swipes an item open to reveal and execute a single command with that one swipe.</span></span> <span data-ttu-id="33355-134">ユーザーがしきい値を超えるまでスワイプする前に、スワイプしている項目から指を離した場合、メニューは閉じ、コマンドは実行されません。</span><span class="sxs-lookup"><span data-stu-id="33355-134">If the user releases the item being swiped before they swipe past a threshold, the menu closes and the command is not executed.</span></span> <span data-ttu-id="33355-135">しきい値を超えてスワイプした後、項目から指を離すと、コマンドがすぐに実行されます。</span><span class="sxs-lookup"><span data-stu-id="33355-135">If the user swipes past the threshold and then releases the item, the command is executed immediately.</span></span>

![スワイプして実行](images/SwipeCommand_Delete_v2.gif)

<span data-ttu-id="33355-137">しきい値に達した後もユーザーが指を離さなかった場合や、スワイプ項目をプルして再び閉じた場合は、コマンドは実行されず、その項目に対して操作は実行されません。</span><span class="sxs-lookup"><span data-stu-id="33355-137">If the user does not release their finger after the threshold is reached, and pulls the swipe item closed again, the command is not executed  and no action is performed on the item.</span></span>

<span data-ttu-id="33355-138">実行モードでは、項目をスワイプする際に、色やラベルの向きによって、より多くの視覚的フィードバックを提供します。</span><span class="sxs-lookup"><span data-stu-id="33355-138">Execute mode provides more visual feedback through color and label orientation while an item is being swiped.</span></span>

<span data-ttu-id="33355-139">実行モードは、ユーザーが実行する操作が最も一般的なときに使用するのに最適です。</span><span class="sxs-lookup"><span data-stu-id="33355-139">Execute is best used when the action the user is performing is most common.</span></span>

<span data-ttu-id="33355-140">これは、項目を削除するなどのより破壊的な操作についても使用できます。</span><span class="sxs-lookup"><span data-stu-id="33355-140">It may also be used for more destructive actions like deleting an item.</span></span> <span data-ttu-id="33355-141">ただし、実行にはある方向にスワイプする操作だけですむ点に留意してください。表示する場合は、明示的にボタンをクリックする必要があるのとは対照的です。</span><span class="sxs-lookup"><span data-stu-id="33355-141">However, keep in mind that Execute requires only one action of swiping in a direction, as opposed to Reveal, which requires the user to explicitly click on a button.</span></span>

### <a name="swipe-directions"></a><span data-ttu-id="33355-142">スワイプの方向</span><span class="sxs-lookup"><span data-stu-id="33355-142">Swipe directions</span></span>

<span data-ttu-id="33355-143">スワイプはすべての基本的な方向 (上、下、左、右) で機能します。</span><span class="sxs-lookup"><span data-stu-id="33355-143">Swipe works in all cardinal directions: up, down, left, and right.</span></span> <span data-ttu-id="33355-144">各スワイプ方向には、独自のスワイプ項目またはコンテンツを保持できますが、1 つのスワイプ可能な要素について設定できる方向のインスタンスは一度に 1 つだけです。</span><span class="sxs-lookup"><span data-stu-id="33355-144">Each swipe direction can hold its own swipe items or content, but only one instance of a direction can be set at a time on a single swipe-able element.</span></span>

<span data-ttu-id="33355-145">たとえば、同じ SwipeControl で 2 つの [LeftItems](/uwp/api/windows.ui.xaml.controls.swipecontrol.LeftItems) を定義することはできません。</span><span class="sxs-lookup"><span data-stu-id="33355-145">For example, you cannot have two [LeftItems](/uwp/api/windows.ui.xaml.controls.swipecontrol.LeftItems) definitions on the same SwipeControl.</span></span>

## <a name="how-to-create-a-swipe-command"></a><span data-ttu-id="33355-146">スワイプ コマンドを作成する方法</span><span class="sxs-lookup"><span data-stu-id="33355-146">How to create a Swipe command</span></span>

<span data-ttu-id="33355-147">スワイプ コマンドでは、2 つのコンポーネントを定義する必要があります。</span><span class="sxs-lookup"><span data-stu-id="33355-147">Swipe commands have two components that you need to define:</span></span>

- <span data-ttu-id="33355-148">コンテンツを取り囲む [SwipeControl](/uwp/api/windows.ui.xaml.controls.swipecontrol)。</span><span class="sxs-lookup"><span data-stu-id="33355-148">The [SwipeControl](/uwp/api/windows.ui.xaml.controls.swipecontrol), which wraps around your content.</span></span> <span data-ttu-id="33355-149">ListView などコレクションに含まれる場合は、DataTemplate 内にあります。</span><span class="sxs-lookup"><span data-stu-id="33355-149">In a collection, such as a ListView, this sits within your DataTemplate.</span></span>
- <span data-ttu-id="33355-150">スワイプ コントロールの方向コンテナー内に配置された 1 つまたは複数の [SwipeItem](/uwp/api/windows.ui.xaml.controls.swipeitem) オブジェクトであるスワイプ メニュー項目: [LeftItems](/uwp/api/windows.ui.xaml.controls.swipecontrol.LeftItems)、[RightItems](/uwp/api/windows.ui.xaml.controls.swipecontrol.RightItems)、[TopItems](/uwp/api/windows.ui.xaml.controls.swipecontrol.TopItems)、または [BottomItems](/uwp/api/windows.ui.xaml.controls.swipecontrol.BottomItems)</span><span class="sxs-lookup"><span data-stu-id="33355-150">The swipe menu items, which is one or more [SwipeItem](/uwp/api/windows.ui.xaml.controls.swipeitem) objects placed in the swipe control's directional containers: [LeftItems](/uwp/api/windows.ui.xaml.controls.swipecontrol.LeftItems), [RightItems](/uwp/api/windows.ui.xaml.controls.swipecontrol.RightItems), [TopItems](/uwp/api/windows.ui.xaml.controls.swipecontrol.TopItems), or [BottomItems](/uwp/api/windows.ui.xaml.controls.swipecontrol.BottomItems)</span></span>

<span data-ttu-id="33355-151">スワイプ コンテンツは、インラインで配置するか、ページまたはアプリの [リソース] セクションで定義することができます。</span><span class="sxs-lookup"><span data-stu-id="33355-151">Swipe content can be placed inline, or defined in the Resources section of your page or app.</span></span>

<span data-ttu-id="33355-152">いくつかのテキストを囲む SwipeControl の単純な例を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="33355-152">Here's a simple example of a SwipeControl wrapped around some text.</span></span> <span data-ttu-id="33355-153">スワイプ コマンドを作成するために必要な XAML 要素の階層構造が表示されます。</span><span class="sxs-lookup"><span data-stu-id="33355-153">It shows the hierarchy of XAML elements required to create a swipe command.</span></span>

```xaml
<SwipeControl HorizontalAlignment="Center" VerticalAlignment="Center">
    <SwipeControl.LeftItems>
        <SwipeItems>
            <SwipeItem Text="Pin">
                <SwipeItem.IconSource>
                    <SymbolIconSource Symbol="Pin"/>
                </SwipeItem.IconSource>
            </SwipeItem>
        </SwipeItems>
    </SwipeControl.LeftItems>

     <!-- Swipeable content -->
    <Border Width="180" Height="44" BorderBrush="Black" BorderThickness="2">
        <TextBlock Text="Swipe to Pin" Margin="4,8,0,0"/>
    </Border>
</SwipeControl>
```

<span data-ttu-id="33355-154">ここでは、通常、スワイプ コマンドをリスト内で使用する方法のより具体的な例について説明します。</span><span class="sxs-lookup"><span data-stu-id="33355-154">Now we'll take a look at a more complete example of how you would typically use swipe commands in a list.</span></span> <span data-ttu-id="33355-155">この例では、実行モードを使用する削除コマンド、および表示モードを使用するその他のコマンドのメニューを設定します。</span><span class="sxs-lookup"><span data-stu-id="33355-155">In this example, you'll set up a delete command that uses Execute mode, and a menu of other commands that uses Reveal mode.</span></span> <span data-ttu-id="33355-156">どちらのコマンドのセットも、ページの [リソース] セクションで定義されます。</span><span class="sxs-lookup"><span data-stu-id="33355-156">Both sets of commands are defined in the Resources section of the page.</span></span> <span data-ttu-id="33355-157">スワイプ コマンドを ListView の項目に適用します。</span><span class="sxs-lookup"><span data-stu-id="33355-157">You'll apply the swipe commands to the items in a ListView.</span></span>

<span data-ttu-id="33355-158">最初に、コマンドを表すスワイプの項目をページ レベルのリソースとして作成します。</span><span class="sxs-lookup"><span data-stu-id="33355-158">First, create the swipe items, which represent the commands, as page level resources.</span></span> <span data-ttu-id="33355-159">SwipeItem では [IconSource](/uwp/api/windows.ui.xaml.controls.iconsource) がそのアイコンとして使用されます。</span><span class="sxs-lookup"><span data-stu-id="33355-159">SwipeItem uses an [IconSource](/uwp/api/windows.ui.xaml.controls.iconsource) as its icon.</span></span> <span data-ttu-id="33355-160">リソースとしてのアイコンも作成します。</span><span class="sxs-lookup"><span data-stu-id="33355-160">Create the icons as resources, too.</span></span>

```xaml
<Page.Resources>
    <SymbolIconSource x:Key="ReplyIcon" Symbol="MailReply"/>
    <SymbolIconSource x:Key="DeleteIcon" Symbol="Delete"/>
    <SymbolIconSource x:Key="PinIcon" Symbol="Pin"/>

    <SwipeItems x:Key="RevealOptions" Mode="Reveal">
        <SwipeItem Text="Reply" IconSource="{StaticResource ReplyIcon}"/>
        <SwipeItem Text="Pin" IconSource="{StaticResource PinIcon}"/>
    </SwipeItems>

    <SwipeItems x:Key="ExecuteDelete" Mode="Execute">
        <SwipeItem Text="Delete" IconSource="{StaticResource DeleteIcon}"
                   Background="Red"/>
    </SwipeItems>
</Page.Resources>
```

<span data-ttu-id="33355-161">スワイプ コンテンツ内のメニュー項目は、短く、簡潔なテキスト ラベルにしてください。</span><span class="sxs-lookup"><span data-stu-id="33355-161">Remember to keep the menu items in your swipe content to short, concise text labels.</span></span> <span data-ttu-id="33355-162">これらの操作は、ユーザーが短時間で複数回実行するようなプライマリ操作である必要があります。</span><span class="sxs-lookup"><span data-stu-id="33355-162">These actions should be the primary ones that a user may want to perform multiple times over a short period.</span></span>

<span data-ttu-id="33355-163">コレクションや ListView で動作するようにスワイプ コマンドを設定する方法は、1 つのスワイプ コマンド (上の例) を定義する場合とまったく同じですが、DataTemplate で SwipeControl を定義する点が異なります。このため、これはコレクションの各項目に適用されます。</span><span class="sxs-lookup"><span data-stu-id="33355-163">Setting up a swipe command to work in a collection or ListView is exactly the same as defining a single swipe command (shown previously), except you define your SwipeControl in a DataTemplate so it's applied to each item in the collection.</span></span>

<span data-ttu-id="33355-164">SwipeControl がその項目の DataTemplate で適用されている ListView を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="33355-164">Here's a ListView with the SwipeControl applied in its item DataTemplate.</span></span> <span data-ttu-id="33355-165">LeftItems プロパティと RightItems プロパティは、リソースとして作成したスワイプ項目を参照します。</span><span class="sxs-lookup"><span data-stu-id="33355-165">The LeftItems and RightItems properties reference the swipe items that you created as resources.</span></span>

```xaml
<ListView x:Name="sampleList" Width="300">
    <ListView.ItemContainerStyle>
        <Style TargetType="ListViewItem">
            <Setter Property="HorizontalContentAlignment" Value="Stretch"/>
            <Setter Property="VerticalContentAlignment" Value="Stretch"/>
        </Style>
    </ListView.ItemContainerStyle>
    <ListView.ItemTemplate>
        <DataTemplate x:DataType="x:String">
            <SwipeControl x:Name="ListViewSwipeContainer"
                          LeftItems="{StaticResource RevealOptions}"
                          RightItems="{StaticResource ExecuteDelete}"
                          Height="60">
                <StackPanel Orientation="Vertical">
                    <TextBlock Text="{x:Bind}" FontSize="18"/>
                    <StackPanel Orientation="Horizontal">
                        <TextBlock Text="Lorem ipsum dolor sit amet, consectetur adipiscing elit..." FontSize="12"/>
                    </StackPanel>
                </StackPanel>
            </SwipeControl>
        </DataTemplate>
    </ListView.ItemTemplate>
    <x:String>Item 1</x:String>
    <x:String>Item 2</x:String>
    <x:String>Item 3</x:String>
    <x:String>Item 4</x:String>
    <x:String>Item 5</x:String>
</ListView>
```

## <a name="handle-an-invoked-swipe-command"></a><span data-ttu-id="33355-166">呼び出されたスワイプ コマンドの処理</span><span class="sxs-lookup"><span data-stu-id="33355-166">Handle an invoked swipe command</span></span>

<span data-ttu-id="33355-167">スワイプ コマンドを処理するには、その [Invoked](/uwp/api/windows.ui.xaml.controls.swipeitem.Invoked) イベントを処理します。</span><span class="sxs-lookup"><span data-stu-id="33355-167">To act on a swipe command, you handle its [Invoked](/uwp/api/windows.ui.xaml.controls.swipeitem.Invoked) event.</span></span> <span data-ttu-id="33355-168">(ユーザーがコマンドを呼び出す方法の詳細については、この記事の前半にある「_スワイプの動作の仕組み_」セクションをご覧ください。) 通常、スワイプ コマンドは、ListView または一覧のようなシナリオで使用されます。</span><span class="sxs-lookup"><span data-stu-id="33355-168">(For more info about a how a user can invoke a command, review the _How does swipe work?_ section earlier in this article.) Typically, a swipe command is in a ListView or list-like scenario.</span></span> <span data-ttu-id="33355-169">その場合は、コマンドが呼び出されるた場合、そのスワイプされた項目で操作を実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="33355-169">In that case, when a command is invoked, you want to perform an action on that swiped item.</span></span>

<span data-ttu-id="33355-170">以前に作成した_削除_スワイプ項目で Invoked イベントを処理する方法を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="33355-170">Here's how to handle the Invoked event on the _delete_ swipe item you created previously.</span></span>

```xaml
<SwipeItems x:Key="ExecuteDelete" Mode="Execute">
    <SwipeItem Text="Delete" IconSource="{StaticResource DeleteIcon}"
               Background="Red" Invoked="Delete_Invoked"/>
</SwipeItems>
```

<span data-ttu-id="33355-171">データ項目は、SwipeControl の DataContext です。</span><span class="sxs-lookup"><span data-stu-id="33355-171">The data item is the DataContext of the SwipeControl.</span></span> <span data-ttu-id="33355-172">コードで、スワイプされた項目にアクセスするには、以下に示すようにイベント引数から SwipeControl.DataContext プロパティを取得します。</span><span class="sxs-lookup"><span data-stu-id="33355-172">In your code, you can access the item that was swiped by getting the SwipeControl.DataContext property from the event args, as shown here.</span></span>

```csharp
 private void Delete_Invoked(SwipeItem sender, SwipeItemInvokedEventArgs args)
 {
     sampleList.Items.Remove(args.SwipeControl.DataContext);
 }
```

> [!NOTE]
> <span data-ttu-id="33355-173">ここでは、わかりやすくするために項目は ListView.Items コレクションに直接追加されており、同じ方法で削除も実行されます。</span><span class="sxs-lookup"><span data-stu-id="33355-173">Here, the items were added directly to the ListView.Items collection for simplicity, so the item is also deleted the same way.</span></span> <span data-ttu-id="33355-174">代わりに、より一般的な方法として ListView.ItemsSource をコレクションに設定した場合は、ソース コレクションから項目を削除する必要があります。</span><span class="sxs-lookup"><span data-stu-id="33355-174">If you instead set the ListView.ItemsSource to a collection, which is more typical, you need to delete the item from the source collection.</span></span>

<span data-ttu-id="33355-175">この特定のインスタンスで、リストから項目が削除されてりうため、最終的な表示状態は重要ではありません。</span><span class="sxs-lookup"><span data-stu-id="33355-175">In this particular instance, you removed the item from the list, so the final visual state of the swiped item isn't important.</span></span> <span data-ttu-id="33355-176">ただし、操作を実行し、スワイプを再び折りたたむことのみが必要である場合は、[BehaviorOnInvoked](/uwp/api/windows.ui.xaml.controls.swipeitem.BehaviorOnInvoked) プロパティを [SwipeBehaviorOnInvoked](/uwp/api/windows.ui.xaml.controls.swipebehavioroninvoked) 列挙値のいずれかに設定できます。</span><span class="sxs-lookup"><span data-stu-id="33355-176">However, in situations where you simply want to perform an action and then have the swipe collapse again, you can set the [BehaviorOnInvoked](/uwp/api/windows.ui.xaml.controls.swipeitem.BehaviorOnInvoked) property one of the [SwipeBehaviorOnInvoked](/uwp/api/windows.ui.xaml.controls.swipebehavioroninvoked) enum values.</span></span>

- **<span data-ttu-id="33355-177">Auto</span><span class="sxs-lookup"><span data-stu-id="33355-177">Auto</span></span>**
  - <span data-ttu-id="33355-178">実行モードでは、開いたスワイプ項目は呼び出されても開いたままになります。</span><span class="sxs-lookup"><span data-stu-id="33355-178">In Execute mode, the opened swipe item will remain open when invoked.</span></span>
  - <span data-ttu-id="33355-179">表示モードでは、開いたスワイプ項目は呼び出されると折りたたまれます。</span><span class="sxs-lookup"><span data-stu-id="33355-179">In Reveal mode, the opened swipe item will collapse when invoked.</span></span>
- **<span data-ttu-id="33355-180">Close</span><span class="sxs-lookup"><span data-stu-id="33355-180">Close</span></span>**
  - <span data-ttu-id="33355-181">項目が呼び出されると、スワイプ コントロールは常に折りたたまれ、モードに関係なく通常に戻ります。</span><span class="sxs-lookup"><span data-stu-id="33355-181">When the item is invoked, the swipe control will always collapse and return to normal, regardless of the mode.</span></span>
- **<span data-ttu-id="33355-182">RemainOpen</span><span class="sxs-lookup"><span data-stu-id="33355-182">RemainOpen</span></span>**
  - <span data-ttu-id="33355-183">項目が呼び出されると、スワイプ コントロールはモードに関係なく常に開いたままになります。</span><span class="sxs-lookup"><span data-stu-id="33355-183">When the item is invoked, the swipe control will always stay open, regardless of the mode.</span></span>

<span data-ttu-id="33355-184">ここでは、_返信_スワイプ項目は呼び出された後に閉じるように設定されます。</span><span class="sxs-lookup"><span data-stu-id="33355-184">Here, a _reply_ swipe item is set to close after its invoked.</span></span>

```xaml
<SwipeItem Text="Reply" IconSource="{StaticResource ReplyIcon}"
           Invoked="Reply_Invoked"
           BehaviorOnInvoked = "Close"/>
```

## <a name="dos-and-donts"></a><span data-ttu-id="33355-185">推奨と非推奨</span><span class="sxs-lookup"><span data-stu-id="33355-185">Dos and don'ts</span></span>

- <span data-ttu-id="33355-186">FlipView、ハブ、ピボットではスワイプを使用しないでください。</span><span class="sxs-lookup"><span data-stu-id="33355-186">Don't use swipe in FlipViews, Hubs or Pivots.</span></span> <span data-ttu-id="33355-187">組み合わせによっては、スワイプの方向が競合するために、ユーザーの混乱を招く可能性があります。</span><span class="sxs-lookup"><span data-stu-id="33355-187">The combination may be confusing for the user because of conflicting swipe directions.</span></span>
- <span data-ttu-id="33355-188">水平方向ナビゲーションと水平方向のスワイプ、または垂直方向ナビゲーションと垂直方向のスワイプを組み合わせないでください。</span><span class="sxs-lookup"><span data-stu-id="33355-188">Don't combine horizontal swipe with horizontal navigation, or vertical swipe with vertical navigation.</span></span>
- <span data-ttu-id="33355-189">ユーザーがスワイプしている対象が同じアクションであり、スワイプできるすべての関連する項目で一貫していることを確認します。</span><span class="sxs-lookup"><span data-stu-id="33355-189">Do make sure what the user is swiping is the same action, and is consistent across all related items that can be swiped.</span></span>
- <span data-ttu-id="33355-190">ユーザーが実行する主なアクションではスワイプを使用します。</span><span class="sxs-lookup"><span data-stu-id="33355-190">Do use swipe for the main actions a user will want to perform.</span></span>
- <span data-ttu-id="33355-191">同じアクションが何度も繰り返される項目ではスワイプを使用します。</span><span class="sxs-lookup"><span data-stu-id="33355-191">Do use swipe on items where the same action is repeated many times.</span></span>
- <span data-ttu-id="33355-192">幅の広い項目では水平方向のスワイプを使用し、高さのある項目では垂直方向のスワイプを使用します。</span><span class="sxs-lookup"><span data-stu-id="33355-192">Do use horizontal swiping on wider items, and vertical swiping on taller items.</span></span>
- <span data-ttu-id="33355-193">短く、簡潔なテキスト ラベルを使用します。</span><span class="sxs-lookup"><span data-stu-id="33355-193">Do use short, concise text labels.</span></span>

## <a name="get-the-sample-code"></a><span data-ttu-id="33355-194">サンプル コードを入手する</span><span class="sxs-lookup"><span data-stu-id="33355-194">Get the sample code</span></span>

- <span data-ttu-id="33355-195">[XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - インタラクティブな形で XAML コントロールのすべてを参照できます。</span><span class="sxs-lookup"><span data-stu-id="33355-195">[XAML Controls Gallery sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - See all the XAML controls in an interactive format.</span></span>

## <a name="related-articles"></a><span data-ttu-id="33355-196">関連記事</span><span class="sxs-lookup"><span data-stu-id="33355-196">Related articles</span></span>

- [<span data-ttu-id="33355-197">リスト ビューとグリッド ビュー</span><span class="sxs-lookup"><span data-stu-id="33355-197">List view and Grid view</span></span>](listview-and-gridview.md)
- [<span data-ttu-id="33355-198">項目コンテナーやテンプレート</span><span class="sxs-lookup"><span data-stu-id="33355-198">Item containers and templates</span></span>](item-containers-templates.md)
- [<span data-ttu-id="33355-199">引っ張って更新</span><span class="sxs-lookup"><span data-stu-id="33355-199">Pull to refresh</span></span>](pull-to-refresh.md)
