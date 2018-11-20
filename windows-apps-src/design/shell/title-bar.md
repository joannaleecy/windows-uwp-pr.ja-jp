---
author: jwmsft
description: アプリの個性に合わせてデスクトップ アプリのタイトル バーをカスタマイズします。
title: タイトル バーのカスタマイズ
template: detail.hbs
ms.author: jimwalk
ms.date: 10/10/2017
ms.topic: article
keywords: windows 10, uwp, タイトル バー
doc-status: Draft
ms.localizationpriority: medium
ms.openlocfilehash: 2ebe590f98afef031ab183589fc7dcfc29cd9493
ms.sourcegitcommit: cbe7cf620622a5e4df7414f9e38dfecec1cfca99
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/20/2018
ms.locfileid: "7419078"
---
# <a name="title-bar-customization"></a><span data-ttu-id="e440d-104">タイトル バーのカスタマイズ</span><span class="sxs-lookup"><span data-stu-id="e440d-104">Title bar customization</span></span>



<span data-ttu-id="e440d-105">アプリをデスクトップ ウィンドウで実行する場合は、アプリの個性に合わせてタイトル バーをカスタマイズできます。</span><span class="sxs-lookup"><span data-stu-id="e440d-105">When your app is running in a desktop window, you can customize the title bars to match the personality of your app.</span></span> <span data-ttu-id="e440d-106">タイトル バーのカスタマイズ用 API を使用すると、タイトル バーの要素に色を指定することも、アプリ コンテンツをタイトル バーの領域に拡張して完全に制御することもできます。</span><span class="sxs-lookup"><span data-stu-id="e440d-106">The title bar customization APIs let you specify colors for title bar elements, or extend your app content into the title bar area and take full control of it.</span></span>

> <span data-ttu-id="e440d-107">**重要な API**: [ApplicationView.TitleBar プロパティ](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.applicationview)、[ApplicationViewTitleBar クラス](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.applicationviewtitlebar)、[CoreApplicationViewTitleBar クラス](https://docs.microsoft.com/uwp/api/windows.applicationmodel.core.coreapplicationviewtitlebar)</span><span class="sxs-lookup"><span data-stu-id="e440d-107">**Important APIs**: [ApplicationView.TitleBar property](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.applicationview), [ApplicationViewTitleBar class](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.applicationviewtitlebar), [CoreApplicationViewTitleBar class](https://docs.microsoft.com/uwp/api/windows.applicationmodel.core.coreapplicationviewtitlebar)</span></span>

## <a name="how-much-to-customize-the-title-bar"></a><span data-ttu-id="e440d-108">タイトル バーのカスタマイズ レベル</span><span class="sxs-lookup"><span data-stu-id="e440d-108">How much to customize the title bar</span></span>

<span data-ttu-id="e440d-109">タイトル バーに適用可能なカスタマイズの度合いとしては、2 つのレベルがあります。</span><span class="sxs-lookup"><span data-stu-id="e440d-109">There are two levels of customization that you can apply to the title bar.</span></span>

<span data-ttu-id="e440d-110">色による単純なカスタマイズの場合は、[ApplicationViewTitleBar](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.applicationviewtitlebar) プロパティを設定して、タイトル バーの要素に使用する色を指定します。</span><span class="sxs-lookup"><span data-stu-id="e440d-110">For simple color customization, you can set [ApplicationViewTitleBar](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.applicationviewtitlebar) properties to specify the colors you want to use for title bar elements.</span></span> <span data-ttu-id="e440d-111">この場合は、タイトル バーの他の部分 (アプリ タイトルの描画やドラッグ可能領域の定義など) は引き続きシステムが制御します。</span><span class="sxs-lookup"><span data-stu-id="e440d-111">In this case, the system retains responsibility for all other aspects of the title bar, such as drawing the app title and defining draggable areas.</span></span>

<span data-ttu-id="e440d-112">もう 1 つのオプションは、既定のタイトル バーを非表示にし、独自の XAML コンテンツに置き換えることです。</span><span class="sxs-lookup"><span data-stu-id="e440d-112">Your other option is to hide the default title bar and replace it with your own XAML content.</span></span> <span data-ttu-id="e440d-113">たとえば、テキスト、ボタン、またはカスタム メニューをタイトル バー領域に配置できます。</span><span class="sxs-lookup"><span data-stu-id="e440d-113">For example, you can place text, buttons, or custom menus in the title bar area.</span></span> <span data-ttu-id="e440d-114">[アクリル](../style/acrylic.md) バックグラウンドをタイトル バー領域に拡張する場合にも、このオプションを使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e440d-114">You will also need to use this option to extend an [acrylic](../style/acrylic.md) background into the title bar area.</span></span>

<span data-ttu-id="e440d-115">全面的なカスタマイズを行う場合は、タイトル バー領域に自分でコンテンツを配置する必要があります。また、ドラッグ可能領域を独自に定義することもできます。</span><span class="sxs-lookup"><span data-stu-id="e440d-115">When you opt for full customization, you are responsible for putting content in the title bar area, and you can define your own draggable region.</span></span> <span data-ttu-id="e440d-116">システムの [戻る]、[閉じる]、[最小化]、[最大化] ボタンは引き続き利用可能であり、システムによって処理されますが、アプリ タイトルなどの要素は該当しません。</span><span class="sxs-lookup"><span data-stu-id="e440d-116">The system Back, Close, Minimize, and Maximize buttons are still available and handled by the system, but elements like the app title are not.</span></span> <span data-ttu-id="e440d-117">アプリに必要であれば、このような要素を自身で作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e440d-117">You will need to create those elements yourself as needed by your app.</span></span>

> [!NOTE]
> <span data-ttu-id="e440d-118">単純な色のカスタマイズは、XAML、DirectX、HTML を使う UWP アプリで利用可能です。</span><span class="sxs-lookup"><span data-stu-id="e440d-118">Simple color customization is available to UWP apps using XAML, DirectX, and HTML.</span></span> <span data-ttu-id="e440d-119">全面的なカスタマイズでは、XAML を使う UWP アプリのみで利用可能です。</span><span class="sxs-lookup"><span data-stu-id="e440d-119">Full customization is available only to UWP apps using XAML.</span></span>

## <a name="simple-color-customization"></a><span data-ttu-id="e440d-120">単純な色のカスタマイズ</span><span class="sxs-lookup"><span data-stu-id="e440d-120">Simple color customization</span></span>

<span data-ttu-id="e440d-121">あまり凝ったこと (タイトル バーにタブを設置するなど) は行わず、タイトル バーの色のみをカスタマイズする場合は、アプリ ウィンドウの [ApplicationViewTitleBar](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.applicationviewtitlebar) で色のプロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="e440d-121">If you want only to customize the title bar colors and not do anything too fancy (such as putting tabs in your title bar), you can set the color properties on the [ApplicationViewTitleBar](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.applicationviewtitlebar) for your app window.</span></span>

<span data-ttu-id="e440d-122">この例では、ApplicationViewTitleBar のインスタンスを取得し、色のプロパティを設定する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="e440d-122">This example shows how to get an instance of ApplicationViewTitleBar and set its color properties.</span></span>

```csharp
// using Windows.UI.ViewManagement;

var titleBar = ApplicationView.GetForCurrentView().TitleBar;

// Set active window colors
titleBar.ForegroundColor = Windows.UI.Colors.White;
titleBar.BackgroundColor = Windows.UI.Colors.Green;
titleBar.ButtonForegroundColor = Windows.UI.Colors.White;
titleBar.ButtonBackgroundColor = Windows.UI.Colors.SeaGreen;
titleBar.ButtonHoverForegroundColor = Windows.UI.Colors.White;
titleBar.ButtonHoverBackgroundColor = Windows.UI.Colors.DarkSeaGreen;
titleBar.ButtonPressedForegroundColor = Windows.UI.Colors.Gray;
titleBar.ButtonPressedBackgroundColor = Windows.UI.Colors.LightGreen;

// Set inactive window colors
titleBar.InactiveForegroundColor = Windows.UI.Colors.Gray;
titleBar.InactiveBackgroundColor = Windows.UI.Colors.SeaGreen;
titleBar.ButtonInactiveForegroundColor = Windows.UI.Colors.Gray;
titleBar.ButtonInactiveBackgroundColor = Windows.UI.Colors.SeaGreen;
```

> [!NOTE]
> <span data-ttu-id="e440d-123">このコードは、アプリの [OnLaunched](https://docs.microsoft.com/uwp/api/windows.ui.xaml.application.onlaunched) メソッド (_App.xaml.cs_) 内の [Window.Activate](https://docs.microsoft.com/uwp/api/windows.ui.xaml.window.Activate) の呼び出しの後か、アプリの最初のページに配置できます。</span><span class="sxs-lookup"><span data-stu-id="e440d-123">This code can be placed in your app's [OnLaunched](https://docs.microsoft.com/uwp/api/windows.ui.xaml.application.onlaunched) method (_App.xaml.cs_), after the call to [Window.Activate](https://docs.microsoft.com/uwp/api/windows.ui.xaml.window.Activate), or in your app's first page.</span></span>

> [!TIP]
> <span data-ttu-id="e440d-124">Windows コミュニティ ツールキットには、これらの色プロパティを XAML で設定するための拡張機能が用意されています。</span><span class="sxs-lookup"><span data-stu-id="e440d-124">The Windows Community Toolkit provides extensions that let you set these color properties in XAML.</span></span> <span data-ttu-id="e440d-125">詳細については、[Windows コミュニティ ツールキットのドキュメント](https://docs.microsoft.com/windows/uwpcommunitytoolkit/extensions/viewextensions)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="e440d-125">For more info, see the [Windows Community Toolkit documentation](https://docs.microsoft.com/windows/uwpcommunitytoolkit/extensions/viewextensions).</span></span>

<span data-ttu-id="e440d-126">タイトル バーの色を設定する際には注意する点がいくつかあります。</span><span class="sxs-lookup"><span data-stu-id="e440d-126">There are a few things to be aware of when setting title bar colors:</span></span>

- <span data-ttu-id="e440d-127">ボタンの背景色は、[閉じる] ボタンのホバー時および押下時の状態に適用されません。</span><span class="sxs-lookup"><span data-stu-id="e440d-127">The button background color is not applied to the close button hover and pressed states.</span></span> <span data-ttu-id="e440d-128">[閉じる] ボタンがこれらの状態の場合は、常にシステム定義の色が使用されます。</span><span class="sxs-lookup"><span data-stu-id="e440d-128">The close button always uses the system-defined color for those states.</span></span>
- <span data-ttu-id="e440d-129">システムの [戻る] ボタンにはボタンの色のプロパティが適用されます (使用時) </span><span class="sxs-lookup"><span data-stu-id="e440d-129">The button color properties are applied to the system back button when it's used.</span></span> <span data-ttu-id="e440d-130">(「[ナビゲーション履歴と前に戻る移動](../basics/navigation-history-and-backwards-navigation.md)」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="e440d-130">([See Navigation history and backwards navigation](../basics/navigation-history-and-backwards-navigation.md).)</span></span>
- <span data-ttu-id="e440d-131">色のプロパティを **null** に設定すると、既定のシステム色にリセットされます。</span><span class="sxs-lookup"><span data-stu-id="e440d-131">Setting a color property to **null** resets it to the default system color.</span></span>
- <span data-ttu-id="e440d-132">透明色を設定することはできません。</span><span class="sxs-lookup"><span data-stu-id="e440d-132">You can't set transparent colors.</span></span> <span data-ttu-id="e440d-133">色のアルファ チャネルは無視されます。</span><span class="sxs-lookup"><span data-stu-id="e440d-133">The color's alpha channel is ignored.</span></span>

<span data-ttu-id="e440d-134">Windows では、ユーザーが選択した[アクセント カラー](https://docs.microsoft.com/windows/uwp/style/color#accent-color)をタイトル バーに適用するかどうかをユーザーが指定できます。</span><span class="sxs-lookup"><span data-stu-id="e440d-134">Windows gives a user the option to apply their selected [accent color](https://docs.microsoft.com/windows/uwp/style/color#accent-color) to the title bar.</span></span> <span data-ttu-id="e440d-135">タイトル バーの色を設定した場合は、すべての色を明示的に設定することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="e440d-135">If you set any title bar color, we recommend that you explicitly set all the colors.</span></span> <span data-ttu-id="e440d-136">これにより、ユーザー定義の色設定によって意図しない色の組み合わせが発生する心配がなくなります。</span><span class="sxs-lookup"><span data-stu-id="e440d-136">This ensures that there are no unintended color combinations that occur because of user defined color settings.</span></span>

## <a name="full-customization"></a><span data-ttu-id="e440d-137">全面的なカスタマイズ</span><span class="sxs-lookup"><span data-stu-id="e440d-137">Full customization</span></span>

<span data-ttu-id="e440d-138">タイトル バーの全面的なカスタマイズを選択すると、アプリのクライアント領域が拡張され、タイトル バーの領域を含めてウィンドウ全体が対象になります。</span><span class="sxs-lookup"><span data-stu-id="e440d-138">When you opt-in to full title bar customization, your app’s client area is extended to cover the entire window, including the title bar area.</span></span> <span data-ttu-id="e440d-139">この場合は、ウィンドウ全体の描画と入力処理を独自に行う必要があります。ただし、アプリのキャンバスの前面にオーバーレイ表示される、タイトル ボタンは例外です。</span><span class="sxs-lookup"><span data-stu-id="e440d-139">You are responsible for drawing and input-handling for the entire window except the caption buttons, which are overlaid on top of the app’s canvas.</span></span>

<span data-ttu-id="e440d-140">既定のタイトル バーを非表示にしてコンテンツをタイトル バー領域まで拡張するには、[CoreApplicationViewTitleBar.ExtendViewIntoTitleBar](https://docs.microsoft.com/uwp/api/windows.applicationmodel.core.coreapplicationviewtitlebar) プロパティを **true** に設定します。</span><span class="sxs-lookup"><span data-stu-id="e440d-140">To hide the default title bar and extend your content into the title bar area, set the [CoreApplicationViewTitleBar.ExtendViewIntoTitleBar](https://docs.microsoft.com/uwp/api/windows.applicationmodel.core.coreapplicationviewtitlebar) property to **true**.</span></span>

<span data-ttu-id="e440d-141">この例は、CoreApplicationViewTitleBar を取得して ExtendViewIntoTitleBar プロパティを **true** に設定する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="e440d-141">This example shows how to get the CoreApplicationViewTitleBar and set the ExtendViewIntoTitleBar property to **true**.</span></span> <span data-ttu-id="e440d-142">この処理は、アプリの [OnLaunched](https://docs.microsoft.com/uwp/api/windows.ui.xaml.application.onlaunched)メソッド (_App.xaml.cs_) またはアプリの最初のページで行うことができます。</span><span class="sxs-lookup"><span data-stu-id="e440d-142">This can be done in your app's [OnLaunched](https://docs.microsoft.com/uwp/api/windows.ui.xaml.application.onlaunched) method (_App.xaml.cs_), or in your app's first page.</span></span>

```csharp
// using Windows.ApplicationModel.Core;

// Hide default title bar.
var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
coreTitleBar.ExtendViewIntoTitleBar = true;
```

> [!TIP]
> <span data-ttu-id="e440d-143">アプリを閉じて再起動しても、この設定は保持されます。</span><span class="sxs-lookup"><span data-stu-id="e440d-143">This setting persists when your app is closed and restarted.</span></span> <span data-ttu-id="e440d-144">Visual Studio で、ExtendViewIntoTitleBar を **true** に設定した場合に既定値に戻すには、この値を明示的に **false** に設定してアプリを実行することで、保持された設定を上書きする必要があります。</span><span class="sxs-lookup"><span data-stu-id="e440d-144">In Visual Studio, if you set ExtendViewIntoTitleBar to **true**, and then want to revert to the default, you should explicitly set it to **false** and run your app to overwrite the persisted setting.</span></span>

### <a name="draggable-regions"></a><span data-ttu-id="e440d-145">ドラッグ可能領域</span><span class="sxs-lookup"><span data-stu-id="e440d-145">Draggable regions</span></span>

<span data-ttu-id="e440d-146">タイトル バーのドラッグ可能領域は、クリックしてドラッグすることでユーザーが (アプリのキャンバス内でコンテンツをドラッグするのではなく) ウィンドウを移動できる場所を定義します。</span><span class="sxs-lookup"><span data-stu-id="e440d-146">The draggable region of the title bar defines where the user can click and drag to move the window around (as opposed to simply dragging content within the app’s canvas).</span></span> <span data-ttu-id="e440d-147">ドラッグ可能領域を指定するには、[Window.SetTitleBar](https://docs.microsoft.com/uwp/api/windows.ui.xaml.window.settitlebar) メソッドを呼び出し、ドラッグ可能領域を定義する UIElement を渡します </span><span class="sxs-lookup"><span data-stu-id="e440d-147">You specify the draggable region by calling the [Window.SetTitleBar](https://docs.microsoft.com/uwp/api/windows.ui.xaml.window.settitlebar) method and passing in a UIElement that defines the draggable region.</span></span> <span data-ttu-id="e440d-148">(UIElement は多くの場合、他の要素も含むパネルです)。</span><span class="sxs-lookup"><span data-stu-id="e440d-148">(The UIElement is often a panel that contains other elements.)</span></span>

<span data-ttu-id="e440d-149">ドラッグ可能なタイトル バー領域としてコンテンツの Grid を設定する方法を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="e440d-149">Here's how to set a Grid of content as the draggable title bar region.</span></span> <span data-ttu-id="e440d-150">このコードは、アプリの最初のページの XAML と分離コードに使用します。</span><span class="sxs-lookup"><span data-stu-id="e440d-150">This code goes in the XAML and code-behind for your app's first page.</span></span> <span data-ttu-id="e440d-151">完全なコードについては、「[全面的なカスタマイズの例](./title-bar.md#full-customization-example)」セクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e440d-151">See the [Full customization example](./title-bar.md#full-customization-example) section for the full code.</span></span>

```xaml
<Grid x:Name="AppTitleBar" Background="Transparent">
    <!-- Width of the padding columns is set in LayoutMetricsChanged handler. -->
    <!-- Using padding columns instead of Margin ensures that the background
         paints the area under the caption control buttons (for transparent buttons). -->
    <Grid.ColumnDefinitions>
        <ColumnDefinition x:Name="LeftPaddingColumn" Width="0"/>
        <ColumnDefinition/>
        <ColumnDefinition x:Name="RightPaddingColumn" Width="0"/>
    </Grid.ColumnDefinitions>
    <Image Source="Assets/Square44x44Logo.png" 
           Grid.Column="1" HorizontalAlignment="Left" 
           Width="20" Height="20" Margin="12,0"/>
    <TextBlock Text="Custom Title Bar" 
               Grid.Column="1" 
               Style="{StaticResource CaptionTextBlockStyle}" 
               Margin="44,8,0,0"/>
</Grid>
```

```csharp
public MainPage()
{
    this.InitializeComponent();

    var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
    coreTitleBar.ExtendViewIntoTitleBar = true;

    // Set XAML element as a draggable region.
    AppTitleBar.Height = coreTitleBar.Height;
    Window.Current.SetTitleBar(AppTitleBar);
}
```

<span data-ttu-id="e440d-152">UIElement (`AppTitleBar`) は、アプリの XAML の一部です。</span><span class="sxs-lookup"><span data-stu-id="e440d-152">The UIElement (`AppTitleBar`) is part of the XAML for your app.</span></span> <span data-ttu-id="e440d-153">変化しないルート ページでタイトル バーを宣言して設定することも、アプリで表示される各ページでタイトル バー領域を宣言して設定することもできます。</span><span class="sxs-lookup"><span data-stu-id="e440d-153">You can either declare and set the title bar in a root page that doesn’t change, or declare and set a title bar region in each page that your app can navigate to.</span></span> <span data-ttu-id="e440d-154">各ページで設定した場合は、ユーザーがアプリ内を移動しても違和感を持たないように、ドラッグ可能領域の一貫性を維持する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e440d-154">If you set it in each page, you should make sure the draggable region stays consistent as a user navigates around your app.</span></span>

<span data-ttu-id="e440d-155">SetTitleBar を呼び出すと、アプリの実行中に新しいタイトル バー要素に切り替えることができます。</span><span class="sxs-lookup"><span data-stu-id="e440d-155">You can call SetTitleBar to switch to a new title bar element while your app is running.</span></span> <span data-ttu-id="e440d-156">パラメーターとして **null** を SetTitleBar に渡し、既定のドラッグ動作に戻すこともできます </span><span class="sxs-lookup"><span data-stu-id="e440d-156">You can also pass **null** as the parameter to SetTitleBar to revert to the default dragging behavior.</span></span> <span data-ttu-id="e440d-157">(詳しくは、「既定のドラッグ可能領域」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="e440d-157">(See "Default draggable region" for more info.)</span></span>

> [!IMPORTANT]
> <span data-ttu-id="e440d-158">指定するドラッグ可能領域は、ヒット テストを可能にしておく必要があります。つまり、一部の要素では、透明な背景ブラシを設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e440d-158">The draggable region you specify needs to be hit testable, which means, for some elements, you might need to set a transparent background brush.</span></span> <span data-ttu-id="e440d-159">詳しくは、[VisualTreeHelper.FindElementsInHostCoordinates](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.visualtreehelper.findelementsinhostcoordinates) の「解説」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e440d-159">See the remarks on [VisualTreeHelper.FindElementsInHostCoordinates](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.visualtreehelper.findelementsinhostcoordinates) for more info.</span></span>
>
><span data-ttu-id="e440d-160">たとえば、ドラッグ可能領域として Grid を定義する場合は、`Background="Transparent"` を設定してドラッグ可能にします。</span><span class="sxs-lookup"><span data-stu-id="e440d-160">For example, if you define a Grid as your draggable region, set `Background="Transparent"` to make it draggable.</span></span>
>
><span data-ttu-id="e440d-161">この Grid はドラッグ可能ではありません (ただし、内部の表示要素はドラッグ可能です):`<Grid x:Name="AppTitleBar">`。</span><span class="sxs-lookup"><span data-stu-id="e440d-161">This Grid is not draggable (but visible elements within it are): `<Grid x:Name="AppTitleBar">`.</span></span>
>
><span data-ttu-id="e440d-162">この Grid は上のものと似ていますが、Grid 全体がドラッグ可能です: `<Grid x:Name="AppTitleBar" Background="Transparent">`。</span><span class="sxs-lookup"><span data-stu-id="e440d-162">This Grid looks the same, but the whole Grid is draggable: `<Grid x:Name="AppTitleBar" Background="Transparent">`.</span></span>

#### <a name="default-draggable-region"></a><span data-ttu-id="e440d-163">既定のドラッグ可能領域</span><span class="sxs-lookup"><span data-stu-id="e440d-163">Default draggable region</span></span>

<span data-ttu-id="e440d-164">ドラッグ可能領域を指定しなかった場合は、ウィンドウの幅、タイトル ボタンの高さで、ウィンドウの上端に合わせて配置された四角形が既定のドラッグ可能領域として設定されます。</span><span class="sxs-lookup"><span data-stu-id="e440d-164">If you don’t specify a draggable region, a rectangle that is the width of the window, the height of the caption buttons, and positioned along the top edge of the window is set as the default draggable region.</span></span>

<span data-ttu-id="e440d-165">ドラッグ可能領域を定義した場合、システムによって既定のドラッグ可能地域がタイトル ボタンのサイズの小さな領域に縮小され、タイトル ボタンの左側 (タイトル ボタンがウィンドウの左端にある場合は右側) に配置されます。</span><span class="sxs-lookup"><span data-stu-id="e440d-165">If you do define a draggable region, the system shrinks the default draggable region down to a small area the size of a caption button, positioned to the left of the caption buttons (or to the right if the captions buttons are on the left side of the window).</span></span> <span data-ttu-id="e440d-166">これにより、ユーザーがドラッグできる一貫性のある領域を常に確保できます。</span><span class="sxs-lookup"><span data-stu-id="e440d-166">This ensures that there is always a consistent area the user can drag.</span></span>

### <a name="system-caption-buttons"></a><span data-ttu-id="e440d-167">システム タイトル ボタン</span><span class="sxs-lookup"><span data-stu-id="e440d-167">System caption buttons</span></span>

<span data-ttu-id="e440d-168">アプリ ウィンドウの左上隅または右上隅は、システム タイトル ボタン ([戻る]、[最小化]、[最大化]、[閉じる]) 用に予約されています。</span><span class="sxs-lookup"><span data-stu-id="e440d-168">The system reserves the upper-left or upper-right corner of the app window for the system caption buttons (Back, Minimize, Maximize, Close).</span></span> <span data-ttu-id="e440d-169">ウィンドウをドラッグ、最小化、最大化、および閉じるための最低限の機能を確保するために、タイトル コントロール領域の制御は、システムが保持します。</span><span class="sxs-lookup"><span data-stu-id="e440d-169">The system retains control of the caption control area to guarantee that minimum functionality is provided for dragging, minimizing, maximizing, and closing the window.</span></span> <span data-ttu-id="e440d-170">システムは、左から右へと表記される言語では右上、右から左へと表記される言語では左上に [閉じる] ボタンを描画します。</span><span class="sxs-lookup"><span data-stu-id="e440d-170">The system draws the Close button in the upper-right for left-to-right languages and the upper-left for right-to-left languages.</span></span>

<span data-ttu-id="e440d-171">タイトル コントロール領域のサイズと位置は、CoreApplicationViewTitleBar クラスによって伝達されるため、独自のタイトル バー UI のレイアウトでも、これを利用できます。</span><span class="sxs-lookup"><span data-stu-id="e440d-171">The dimensions and position of the caption control area is communicated by the CoreApplicationViewTitleBar class so that you can account for it in the layout of your title bar UI.</span></span> <span data-ttu-id="e440d-172">左右に予約されている領域の幅は、[SystemOverlayLeftInset](https://docs.microsoft.com/uwp/api/windows.applicationmodel.core.coreapplicationviewtitlebar.SystemOverlayLeftInset) プロパティまたは [SystemOverlayRightInset](https://docs.microsoft.com/uwp/api/windows.applicationmodel.core.coreapplicationviewtitlebar.SystemOverlayRightInset) プロパティで指定され、高さは [Height](https://docs.microsoft.com/uwp/api/windows.applicationmodel.core.coreapplicationviewtitlebar.Height) プロパティで指定されます。</span><span class="sxs-lookup"><span data-stu-id="e440d-172">The width of the reserved region on each side is given by the [SystemOverlayLeftInset](https://docs.microsoft.com/uwp/api/windows.applicationmodel.core.coreapplicationviewtitlebar.SystemOverlayLeftInset) or [SystemOverlayRightInset](https://docs.microsoft.com/uwp/api/windows.applicationmodel.core.coreapplicationviewtitlebar.SystemOverlayRightInset) properties, and its height is given by the [Height](https://docs.microsoft.com/uwp/api/windows.applicationmodel.core.coreapplicationviewtitlebar.Height) property.</span></span>

<span data-ttu-id="e440d-173">これらのプロパティで定義されたタイトル コントロール領域の背面に (たとえば背景として) コンテンツを描画することもできますが、ユーザーが操作するための UI は配置しないでください。</span><span class="sxs-lookup"><span data-stu-id="e440d-173">You can draw content underneath the caption control area defined by these properties, such as your app background, but you should not put any UI that you expect the user to be able to interact with.</span></span> <span data-ttu-id="e440d-174">タイトル コントロールに対する入力はシステムによって処理されるため、タイトル コントロール領域で入力を受け取ることはできません。</span><span class="sxs-lookup"><span data-stu-id="e440d-174">It does not receive any input because input for the caption controls is handled by the system.</span></span>

<span data-ttu-id="e440d-175">タイトル ボタンのサイズ変化に応答するには、[LayoutMetricsChanged](https://docs.microsoft.com/uwp/api/windows.applicationmodel.core.coreapplicationviewtitlebar.LayoutMetricsChanged) イベントを処理します。</span><span class="sxs-lookup"><span data-stu-id="e440d-175">You can handle the [LayoutMetricsChanged](https://docs.microsoft.com/uwp/api/windows.applicationmodel.core.coreapplicationviewtitlebar.LayoutMetricsChanged) event to respond to changes in the size of the caption buttons.</span></span> <span data-ttu-id="e440d-176">たとえば、システムの [戻る] ボタンが表示または非表示になったときなどに、このイベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="e440d-176">For example, this can happen when the system back button is shown or hidden.</span></span> <span data-ttu-id="e440d-177">このイベントを処理し、タイトル バーのサイズに基づく UI 要素の位置を確認および更新します。</span><span class="sxs-lookup"><span data-stu-id="e440d-177">Handle this event to verify and update the positioning of UI elements that depend on the title bar's size.</span></span>

<span data-ttu-id="e440d-178">以下の例では、システムの [戻る] ボタンの表示や非表示などの変化に対応して、タイトル バーのレイアウトを調整する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="e440d-178">This example shows how to adjust the layout of your title bar to account for changes like the system back button being shown or hidden.</span></span> `AppTitleBar`<span data-ttu-id="e440d-179">、`LeftPaddingColumn`、および `RightPaddingColumn` は、前に示した XAML で宣言されています。</span><span class="sxs-lookup"><span data-stu-id="e440d-179">, `LeftPaddingColumn`, and `RightPaddingColumn` are declared in the XAML shown previously.</span></span>

```csharp
private void CoreTitleBar_LayoutMetricsChanged(CoreApplicationViewTitleBar sender, object args)
{
    UpdateTitleBarLayout(sender);
}

private void UpdateTitleBarLayout(CoreApplicationViewTitleBar coreTitleBar)
{
    // Get the size of the caption controls area and back button 
    // (returned in logical pixels), and move your content around as necessary.
    LeftPaddingColumn.Width = new GridLength(coreTitleBar.SystemOverlayLeftInset);
    RightPaddingColumn.Width = new GridLength(coreTitleBar.SystemOverlayRightInset);
    TitleBarButton.Margin = new Thickness(0,0,coreTitleBar.SystemOverlayRightInset,0);

    // Update title bar control size as needed to account for system size changes.
    AppTitleBar.Height = coreTitleBar.Height;
}
```

### <a name="interactive-content"></a><span data-ttu-id="e440d-180">対話型コンテンツ</span><span class="sxs-lookup"><span data-stu-id="e440d-180">Interactive content</span></span>

<span data-ttu-id="e440d-181">ボタン、メニュー、検索ボックスなどの対話型のコントロールをアプリの上部に配置して、タイトル バーに表示することもできます。</span><span class="sxs-lookup"><span data-stu-id="e440d-181">You can place interactive controls, like buttons, menus, or a search box, in the top part of the app so they appear to be in the title bar.</span></span> <span data-ttu-id="e440d-182">ただし、対話型要素でユーザー入力を受信するには、以下の規則に従う必要があります。</span><span class="sxs-lookup"><span data-stu-id="e440d-182">However, there are a few rules you must follow to unsure that your interactive elements receive user input.</span></span>
- <span data-ttu-id="e440d-183">SetTitleBar を呼び出し、領域をドラッグ可能なタイトル バー領域として定義する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e440d-183">You must call SetTitleBar to define an area as the draggable title bar region.</span></span> <span data-ttu-id="e440d-184">この操作を行わなかった場合は、システムによって、ページの上部に既定のドラッグ可能領域が設定されます。</span><span class="sxs-lookup"><span data-stu-id="e440d-184">If you don’t, the system sets the default draggable region at the top of the page.</span></span> <span data-ttu-id="e440d-185">その場合、この領域へのユーザー入力がすべてシステムによって処理されるため、独自のコントロールには入力が届きません。</span><span class="sxs-lookup"><span data-stu-id="e440d-185">The system will then handle all user input to this area, and prevent input from reaching your controls.</span></span>
- <span data-ttu-id="e440d-186">対話型コントロールは、SetTitleBar の呼び出しによって定義されたドラッグ可能領域より上部 (z オーダーでの上位) に配置します。</span><span class="sxs-lookup"><span data-stu-id="e440d-186">Place your interactive controls over the top of the draggable region defined by the call to SetTitleBar (with a higher z-order).</span></span> <span data-ttu-id="e440d-187">対話型コントロールは、SetTitleBar に渡される UIElement の子にしないでください。</span><span class="sxs-lookup"><span data-stu-id="e440d-187">Don’t make your interactive controls children of the UIElement passed to SetTitleBar.</span></span> <span data-ttu-id="e440d-188">SetTitleBar に渡した要素は、システムのタイトル バーと同様に扱われ、その要素へのポインター入力がすべてシステムによって処理されます。</span><span class="sxs-lookup"><span data-stu-id="e440d-188">After you pass an element to SetTitleBar, the system treats it like the system title bar and handles all pointer input to that element.</span></span>

<span data-ttu-id="e440d-189">以下のコードで、`TitleBarButton` 要素は z オーダーが `AppTitleBar` より上位であるため、ユーザー入力を受け取ります。</span><span class="sxs-lookup"><span data-stu-id="e440d-189">Here, the `TitleBarButton` element has a higher z-order than `AppTitleBar`, so it receives user input.</span></span>

```xaml
<Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
    <Grid.RowDefinitions>
        <RowDefinition Height="Auto"/>
        <RowDefinition />
    </Grid.RowDefinitions>

    <Grid x:Name="AppTitleBar" Background="Transparent">
        <!-- Width of the padding columns is set in LayoutMetricsChanged handler. -->
        <!-- Using padding columns instead of Margin ensures that the background
             paints the area under the caption control buttons (for transparent buttons). -->
        <Grid.ColumnDefinitions>
            <ColumnDefinition x:Name="LeftPaddingColumn" Width="0"/>
            <ColumnDefinition/>
            <ColumnDefinition x:Name="RightPaddingColumn" Width="0"/>
        </Grid.ColumnDefinitions>
        <Image Source="Assets/Square44x44Logo.png"
               Grid.Column="1" HorizontalAlignment="Left"
               Width="20" Height="20" Margin="12,0"/>
        <TextBlock Text="Custom Title Bar"
                   Grid.Column="1"
                   Style="{StaticResource CaptionTextBlockStyle}"
                   Margin="44,8,0,0"/>
    </Grid>

    <!-- This Button has a higher z-order than AppTitleBar, 
         so it receives user input. -->
    <Button x:Name="TitleBarButton" Content="Button in the title bar"
        HorizontalAlignment="Right"/>
</Grid>
```

### <a name="transparency-in-caption-buttons"></a><span data-ttu-id="e440d-190">タイトル ボタンの透明度</span><span class="sxs-lookup"><span data-stu-id="e440d-190">Transparency in caption buttons</span></span>

<span data-ttu-id="e440d-191">ExtendViewIntoTitleBar を **true** に設定すると、アプリの背景が透けるように、タイトル ボタンの背景を透明にすることができます。</span><span class="sxs-lookup"><span data-stu-id="e440d-191">When you set ExtendViewIntoTitleBar to **true**, you can make the background of the caption buttons transparent to let your app background show through.</span></span> <span data-ttu-id="e440d-192">一般的には、背景を [Colors.Transparent](https://docs.microsoft.com/uwp/api/windows.ui.colors.Transparent) に設定して完全な透明にします。</span><span class="sxs-lookup"><span data-stu-id="e440d-192">You typically set the background to [Colors.Transparent](https://docs.microsoft.com/uwp/api/windows.ui.colors.Transparent) for full transparency.</span></span> <span data-ttu-id="e440d-193">部分的に透明にするには、プロパティ設定対象の [Color](https://docs.microsoft.com/uwp/api/windows.ui.color) にアルファ チャネルを設定します。</span><span class="sxs-lookup"><span data-stu-id="e440d-193">For partial transparency, set the alpha channel for the [Color](https://docs.microsoft.com/uwp/api/windows.ui.color) you set the property to.</span></span>

<span data-ttu-id="e440d-194">以下の ApplicationViewTitleBar プロパティは透明にすることができます。</span><span class="sxs-lookup"><span data-stu-id="e440d-194">These ApplicationViewTitleBar properties can be transparent:</span></span>

- <span data-ttu-id="e440d-195">ButtonBackgroundColor</span><span class="sxs-lookup"><span data-stu-id="e440d-195">ButtonBackgroundColor</span></span>
- <span data-ttu-id="e440d-196">ButtonHoverBackgroundColor</span><span class="sxs-lookup"><span data-stu-id="e440d-196">ButtonHoverBackgroundColor</span></span>
- <span data-ttu-id="e440d-197">ButtonPressedBackgroundColor</span><span class="sxs-lookup"><span data-stu-id="e440d-197">ButtonPressedBackgroundColor</span></span>
- <span data-ttu-id="e440d-198">ButtonInactiveBackgroundColor</span><span class="sxs-lookup"><span data-stu-id="e440d-198">ButtonInactiveBackgroundColor</span></span>

<span data-ttu-id="e440d-199">ボタンの背景色は、[閉じる] ボタンのホバー時および押下時の状態に適用されません。</span><span class="sxs-lookup"><span data-stu-id="e440d-199">The button background color is not applied to the close button hover and pressed states.</span></span> <span data-ttu-id="e440d-200">[閉じる] ボタンがこれらの状態の場合は、常にシステム定義の色が使用されます。</span><span class="sxs-lookup"><span data-stu-id="e440d-200">The close button always uses the system-defined color for those states.</span></span>

<span data-ttu-id="e440d-201">その他のすべての色プロパティでは、引き続きアルファ チャネルが無視されます。</span><span class="sxs-lookup"><span data-stu-id="e440d-201">All other color properties will continue to ignore the alpha channel.</span></span> <span data-ttu-id="e440d-202">ExtendViewIntoTitleBar が **false** に設定されている場合は、すべての ApplicationViewTitleBar 色プロパティについて、アルファ チャネルが常に無視されます。</span><span class="sxs-lookup"><span data-stu-id="e440d-202">If ExtendViewIntoTitleBar is set to **false**, the alpha channel is always ignored for all ApplicationViewTitleBar color properties.</span></span>

### <a name="full-screen-and-tablet-mode"></a><span data-ttu-id="e440d-203">全画面とタブレット モード</span><span class="sxs-lookup"><span data-stu-id="e440d-203">Full screen and tablet mode</span></span>

<span data-ttu-id="e440d-204">アプリが_全画面_または_タブレット モード_で実行されている場合は、タイトル バーとタイトル コントロール ボタンが非表示になります。</span><span class="sxs-lookup"><span data-stu-id="e440d-204">When your app runs in _full screen_ or _tablet mode_, the system hides the title bar and caption control buttons.</span></span> <span data-ttu-id="e440d-205">ただし、ユーザーがタイトル バーを呼び出し、アプリ UI の上にオーバーレイとして表示することもあります。</span><span class="sxs-lookup"><span data-stu-id="e440d-205">However, the user can invoke the title bar to have it shown as an overlay on top of the app’s UI.</span></span>
<span data-ttu-id="e440d-206">タイトル バーが非表示になった場合または呼び出された場合の通知を受け取り、必要に応じてカスタムのタイトル バー コンテンツを表示または非表示にするには、[CoreApplicationViewTitleBar.IsVisibleChanged](https://docs.microsoft.com/uwp/api/windows.applicationmodel.core.coreapplicationviewtitlebar.IsVisibleChanged) イベントを処理します。</span><span class="sxs-lookup"><span data-stu-id="e440d-206">You can handle the [CoreApplicationViewTitleBar.IsVisibleChanged](https://docs.microsoft.com/uwp/api/windows.applicationmodel.core.coreapplicationviewtitlebar.IsVisibleChanged) event to be notified when the title bar is hidden or invoked, and show or hide your custom title bar content as needed.</span></span>

<span data-ttu-id="e440d-207">この例では、IsVisibleChanged を処理して、前に表示されていた `AppTitleBar` 要素を表示または非表示にする方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="e440d-207">This example shows how to handle IsVisibleChanged to show and hide the `AppTitleBar` element shown previously.</span></span>

```csharp
public MainPage()
{
    this.InitializeComponent();

    var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;

    // Register a handler for when the title bar visibility changes.
    // For example, when the title bar is invoked in full screen mode.
    coreTitleBar.IsVisibleChanged += CoreTitleBar_IsVisibleChanged;
}

private void CoreTitleBar_IsVisibleChanged(CoreApplicationViewTitleBar sender, object args)
{
    if (sender.IsVisible)
    {
        AppTitleBar.Visibility = Visibility.Visible;
    }
    else
    {
        AppTitleBar.Visibility = Visibility.Collapsed;
    }
}
```

>[!NOTE]
><span data-ttu-id="e440d-208">_全画面表示_モードは、アプリでサポートされている場合にのみ使用できます。</span><span class="sxs-lookup"><span data-stu-id="e440d-208">_Full screen_ mode can be entered only if supported by your app.</span></span> <span data-ttu-id="e440d-209">詳しくは、[ApplicationView.IsFullScreenMode](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.applicationview.IsFullScreenMode) をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e440d-209">See [ApplicationView.IsFullScreenMode](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.applicationview.IsFullScreenMode) for more info.</span></span> <span data-ttu-id="e440d-210">[_タブレット モード_](https://support.microsoft.com/help/17210/windows-10-use-your-pc-like-a-tablet)は、サポートされているハードウェア上のユーザー オプションであり、ユーザーは任意のアプリをタブレット モードで実行できます。</span><span class="sxs-lookup"><span data-stu-id="e440d-210">[_Tablet mode_](https://support.microsoft.com/help/17210/windows-10-use-your-pc-like-a-tablet) is a user option on supported hardware, so a user can choose to run any app in tablet mode.</span></span>

## <a name="full-customization-example"></a><span data-ttu-id="e440d-211">全面的なカスタマイズの例</span><span class="sxs-lookup"><span data-stu-id="e440d-211">Full customization example</span></span>

```xaml
<Page
    x:Class="CustomTitleBar.MainPage"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:local="using:CustomTitleBar"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    mc:Ignorable="d">

    <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/>
            <RowDefinition />
        </Grid.RowDefinitions>

        <Grid x:Name="AppTitleBar" Background="Transparent">
            <!-- Width of the padding columns is set in LayoutMetricsChanged handler. -->
            <!-- Using padding columns instead of Margin ensures that the background
                 paints the area under the caption control buttons (for transparent buttons). -->
            <Grid.ColumnDefinitions>
                <ColumnDefinition x:Name="LeftPaddingColumn" Width="0"/>
                <ColumnDefinition/>
                <ColumnDefinition x:Name="RightPaddingColumn" Width="0"/>
            </Grid.ColumnDefinitions>
            <Image Source="Assets/Square44x44Logo.png" 
                   Grid.Column="1" HorizontalAlignment="Left" 
                   Width="20" Height="20" Margin="12,0"/>
            <TextBlock Text="Custom Title Bar" 
                       Grid.Column="1" 
                       Style="{StaticResource CaptionTextBlockStyle}" 
                       Margin="44,8,0,0"/>
        </Grid>

        <!-- This Button has a higher z-order than MyTitleBar, 
             so it receives user input. -->
        <Button x:Name="TitleBarButton" Content="Button in the title bar"
                HorizontalAlignment="Right"/>
    </Grid>
</Page>
```

```csharp
public MainPage()
{
    this.InitializeComponent();

    // Hide default title bar.
    var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
    coreTitleBar.ExtendViewIntoTitleBar = true;
    UpdateTitleBarLayout(coreTitleBar);

    // Set XAML element as a draggable region.
    Window.Current.SetTitleBar(AppTitleBar);

    // Register a handler for when the size of the overlaid caption control changes.
    // For example, when the app moves to a screen with a different DPI.
    coreTitleBar.LayoutMetricsChanged += CoreTitleBar_LayoutMetricsChanged;

    // Register a handler for when the title bar visibility changes.
    // For example, when the title bar is invoked in full screen mode.
    coreTitleBar.IsVisibleChanged += CoreTitleBar_IsVisibleChanged;
}

private void CoreTitleBar_LayoutMetricsChanged(CoreApplicationViewTitleBar sender, object args)
{
    UpdateTitleBarLayout(sender);
}

private void UpdateTitleBarLayout(CoreApplicationViewTitleBar coreTitleBar)
{
    // Get the size of the caption controls area and back button 
    // (returned in logical pixels), and move your content around as necessary.
    LeftPaddingColumn.Width = new GridLength(coreTitleBar.SystemOverlayLeftInset);
    RightPaddingColumn.Width = new GridLength(coreTitleBar.SystemOverlayRightInset);
    TitleBarButton.Margin = new Thickness(0,0,coreTitleBar.SystemOverlayRightInset,0);

    // Update title bar control size as needed to account for system size changes.
    AppTitleBar.Height = coreTitleBar.Height;
}

private void CoreTitleBar_IsVisibleChanged(CoreApplicationViewTitleBar sender, object args)
{
    if (sender.IsVisible)
    {
        AppTitleBar.Visibility = Visibility.Visible;
    }
    else
    {
        AppTitleBar.Visibility = Visibility.Collapsed;
    }
}
```

## <a name="dos-and-donts"></a><span data-ttu-id="e440d-212">推奨と非推奨</span><span class="sxs-lookup"><span data-stu-id="e440d-212">Do's and don'ts</span></span>

- <span data-ttu-id="e440d-213">ウィンドウがアクティブまたは非アクティブであるときには、それをわかりやすく示してください。</span><span class="sxs-lookup"><span data-stu-id="e440d-213">Do make is obvious when your window is active or inactive.</span></span> <span data-ttu-id="e440d-214">少なくとも、タイトル バーのテキスト、アイコン、ボタンの色を変更してください。</span><span class="sxs-lookup"><span data-stu-id="e440d-214">At a minimum, change the color of the text, icons, and buttons in your title bar.</span></span>
- <span data-ttu-id="e440d-215">ドラッグ可能領域は、アプリ キャンバスの上端に沿って定義してください。</span><span class="sxs-lookup"><span data-stu-id="e440d-215">Do define a draggable region along the top edge of the app canvas.</span></span> <span data-ttu-id="e440d-216">システム タイトル バーの配置に合わせると、ユーザーから見つけやすくなります。</span><span class="sxs-lookup"><span data-stu-id="e440d-216">Matching the placement of system title bars makes it easier for users to find.</span></span>
- <span data-ttu-id="e440d-217">ドラッグ可能領域は、アプリ キャンバス上に表示されるタイトル バー (ある場合) に合わせて定義してください。</span><span class="sxs-lookup"><span data-stu-id="e440d-217">Do define a draggable region that matches the visual title bar (if any) on the app’s canvas.</span></span>

## <a name="related-articles"></a><span data-ttu-id="e440d-218">関連記事</span><span class="sxs-lookup"><span data-stu-id="e440d-218">Related articles</span></span>

- [<span data-ttu-id="e440d-219">アクリル</span><span class="sxs-lookup"><span data-stu-id="e440d-219">Acrylic</span></span>](../style/acrylic.md)
- [<span data-ttu-id="e440d-220">色</span><span class="sxs-lookup"><span data-stu-id="e440d-220">Color</span></span>](../style/color.md)
