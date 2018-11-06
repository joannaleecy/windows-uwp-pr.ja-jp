---
author: Karl-Bridge-Microsoft
Description: Build UWP apps and custom/templated controls that support platform text scaling.
title: テキストの拡大縮小
label: Text scaling
template: detail.hbs
keywords: UWP, テキスト、スケーリング、アクセシビリティ、「簡単」、表示、「するテキストがより大きく」, ユーザーの操作, 入力
ms.author: kbridge
ms.date: 08/02/2018
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: ce3ec15a45f812162c7aab0cb9683183d7196ae3
ms.sourcegitcommit: e814a13978f33654d8e995584f4b047cb53e0aef
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/06/2018
ms.locfileid: "6051642"
---
# <a name="text-scaling"></a><span data-ttu-id="c6583-103">テキストの拡大縮小</span><span class="sxs-lookup"><span data-stu-id="c6583-103">Text scaling</span></span>

![テキストの 100% に 225% のスケーリングの例](images/coretext/text-scaling-news-hero-small.png)  
*<span data-ttu-id="c6583-105">Windows 10 (100% に 225%) でスケーリング テキストの例</span><span class="sxs-lookup"><span data-stu-id="c6583-105">Example of text scaling in Windows 10 (100% to 225%)</span></span>*

## <a name="overview"></a><span data-ttu-id="c6583-106">概要</span><span class="sxs-lookup"><span data-stu-id="c6583-106">Overview</span></span>

<span data-ttu-id="c6583-107">(モバイル デバイスから Surface Hub の大きな画面にデスクトップのモニターにラップトップ) コンピューターの画面上のテキストの読み取りは、多くの人にとって困難なことができます。</span><span class="sxs-lookup"><span data-stu-id="c6583-107">Reading text on a computer screen (from mobile device to laptop to desktop monitor to the giant screen of a Surface Hub) can be challenging for many people.</span></span> <span data-ttu-id="c6583-108">逆に、一部のユーザーは、アプリや web サイトで必要以上にするために使用するフォント サイズを検索します。</span><span class="sxs-lookup"><span data-stu-id="c6583-108">Conversely, some users find the font sizes used in apps and web sites to be larger than necessary.</span></span>

<span data-ttu-id="c6583-109">テキストはを幅広いユーザーできるだけ読みやすいことを確認するには、Windows には、ユーザーが OS と個々 のアプリケーションの両方の間での相対的なフォント サイズを変更する機能が用意されています。</span><span class="sxs-lookup"><span data-stu-id="c6583-109">To ensure text is as legible as possible for the broadest range of users, Windows provides the ability for users to change relative font size across both the OS and individual applications.</span></span> <span data-ttu-id="c6583-110">拡大鏡アプリ (これ通常だけ、画面の領域内のすべてを拡大し、独自の操作性の問題が導入されています) を使って、ディスプレイの解像度を変更または DPI スケーリングのサイズを変更の表示と一般的な表示に基づくすべての証明書利用者ではなく距離)、ユーザーは、テキストだけで、100% (既定のサイズ) からの範囲のサイズを変更する設定にすばやくアクセスできる最大 225% です。</span><span class="sxs-lookup"><span data-stu-id="c6583-110">Instead of using a magnifier app (which typically just enlarges everything within an area of the screen and introduces its own usability issues), changing display resolution, or relying on DPI scaling (which resizes everything based on display and typical viewing distance), a user can quickly access a setting to resize just text, ranging from 100% (the default size) up to 225%.</span></span>

## <a name="support"></a><span data-ttu-id="c6583-111">サポート</span><span class="sxs-lookup"><span data-stu-id="c6583-111">Support</span></span>

<span data-ttu-id="c6583-112">ユニバーサル Windows アプリケーション (標準および PWA)、既定でスケーリング テキストをサポートします。</span><span class="sxs-lookup"><span data-stu-id="c6583-112">Universal Windows applications (both standard and PWA), support text scaling by default.</span></span>

<span data-ttu-id="c6583-113">カスタム コントロール、カスタム テキスト サーフェス、ハード コードされたコントロールの高さ、古いフレームワークは、またはサード パーティのフレームワークで、UWP アプリケーションが含まれる場合可能性がありますを加えることがいくつかの更新に一貫性があり、便利なユーザー エクスペリエンスことを確認します。</span><span class="sxs-lookup"><span data-stu-id="c6583-113">If your UWP application includes custom controls, custom text surfaces, hard-coded control heights, older frameworks, or 3rd party frameworks, you likely have to make some updates to ensure a consistent and useful experience for your users.</span></span>  

<span data-ttu-id="c6583-114">DirectWrite、GDI、および XAML SwapChainPanels ネイティブにサポートしていませんテキストのスケーリング、Win32 のサポートは、メニューのアイコン、およびツールバーに制限されますが。</span><span class="sxs-lookup"><span data-stu-id="c6583-114">DirectWrite, GDI, and XAML SwapChainPanels do not natively support text scaling, while Win32 support is limited to menus, icons, and toolbars.</span></span>  

<!-- If you want to support text scaling in your application with these frameworks, you’ll need to support the text scaling change event outlined below and provide alternative sizes for your UI and content.   -->

## <a name="user-experience"></a><span data-ttu-id="c6583-115">ユーザーによるインストール</span><span class="sxs-lookup"><span data-stu-id="c6583-115">User experience</span></span>

<span data-ttu-id="c6583-116">ユーザーがテキストの倍率を調整できる]-> [設定の大きなスライダー テキストにすると簡単ビジョン/ディスプレイの画面]-> [します。</span><span class="sxs-lookup"><span data-stu-id="c6583-116">Users can adjust text scale with the Make text bigger slider on the Settings -> Ease of Access -> Vision/Display screen.</span></span>

![テキストの 100% に 225% のスケーリングの例](images/coretext/text-scaling-settings-100-small.png)  
*<span data-ttu-id="c6583-118">設定から設定テキスト スケール簡単]-> [ビジョン/ディスプレイの画面]-> [</span><span class="sxs-lookup"><span data-stu-id="c6583-118">Text scale setting from Settings -> Ease of Access -> Vision/Display screen</span></span>*

## <a name="ux-guidance"></a><span data-ttu-id="c6583-119">UX ガイダンス</span><span class="sxs-lookup"><span data-stu-id="c6583-119">UX guidance</span></span>

<span data-ttu-id="c6583-120">テキストのサイズが変更されたコントロールとコンテナーする必要がありますもサイズを変更して、テキストとその新しいレイアウトに対応するために再配置されます。</span><span class="sxs-lookup"><span data-stu-id="c6583-120">As text is resized, controls and containers must also resize and reflow to accommodate the text and its new layout.</span></span> <span data-ttu-id="c6583-121">アプリ、フレームワーク、およびプラットフォームに応じて以前は、既に説明したようこの作業の大半に行われます。</span><span class="sxs-lookup"><span data-stu-id="c6583-121">As mentioned previously, depending on the app, framework, and platform, much of this work is done for you.</span></span> <span data-ttu-id="c6583-122">次の UX ガイダンスでは、このようなことがない場合について説明します。</span><span class="sxs-lookup"><span data-stu-id="c6583-122">The following UX guidance covers those cases where it's not.</span></span>

### <a name="use-the-platform-controls"></a><span data-ttu-id="c6583-123">プラットフォーム コントロールを使う</span><span class="sxs-lookup"><span data-stu-id="c6583-123">Use the platform controls</span></span>

<span data-ttu-id="c6583-124">言ったこれ既にかどうか。</span><span class="sxs-lookup"><span data-stu-id="c6583-124">Did we say this already?</span></span> <span data-ttu-id="c6583-125">繰り返しますが: 最小限の作業するときに、最も包括的なユーザー エクスペリエンスを実現するためにさまざまな Windows アプリのフレームワークで提供される組み込みのコントロールが常に使用可能な限り、します。</span><span class="sxs-lookup"><span data-stu-id="c6583-125">It's worth repeating: When possible, always use the built-in controls provided with the various Windows app frameworks to get the most comprehensive user experience possible for the least amount of effort.</span></span>

<span data-ttu-id="c6583-126">たとえば、すべての UWP テキスト コントロールは、テンプレート化やカスタマイズを加えなくてもエクスペリエンスをスケーリングする完全なテキストをサポートします。</span><span class="sxs-lookup"><span data-stu-id="c6583-126">For example, all UWP text controls support the full text scaling experience without any customization or templating.</span></span>

<span data-ttu-id="c6583-127">次に、いくつか標準的なテキスト コントロールにはが含まれている基本的な UWP アプリのスニペットを示します。</span><span class="sxs-lookup"><span data-stu-id="c6583-127">Here's a snippet from a basic UWP app that includes a couple of standard text controls:</span></span>

``` xaml
<Grid>
    <Grid.RowDefinitions>
        <RowDefinition Height="Auto"/>
        <RowDefinition Height="Auto" />
        <RowDefinition Height="Auto"/>
    </Grid.RowDefinitions>
    <TextBlock Grid.Row="0" 
                Style="{ThemeResource TitleTextBlockStyle}"
                Text="Text scaling test" 
                HorizontalTextAlignment="Center" />
    <Grid Grid.Row="1">
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="Auto"/>
            <ColumnDefinition Width="*"/>
            <ColumnDefinition Width="Auto"/>
        </Grid.ColumnDefinitions>
        <Image Grid.Column="0" 
                Source="Assets/StoreLogo.png" 
                Width="450" Height="450"/>
        <StackPanel Grid.Column="1" 
                    HorizontalAlignment="Center">
            <TextBlock TextWrapping="WrapWholeWords">
                The quick brown fox jumped over the lazy dog.
            </TextBlock>
            <TextBox PlaceholderText="Type something here" />
        </StackPanel>
        <Image Grid.Column="2" 
                Source="Assets/StoreLogo.png" 
                Width="450" Height="450"/>
    </Grid>
    <TextBlock Grid.Row="2" 
                Style="{ThemeResource TitleTextBlockStyle}"
                Text="Text scaling test footer" 
                HorizontalTextAlignment="Center" />
</Grid>
```

![アニメーション化されたテキストが 100% に 225% のスケーリング](images/coretext/text-scaling.gif)  
*<span data-ttu-id="c6583-129">アニメーション化されたテキストのスケーリング</span><span class="sxs-lookup"><span data-stu-id="c6583-129">Animated text scaling</span></span>*

### <a name="use-auto-sizing"></a><span data-ttu-id="c6583-130">自動サイズ変更を使用します。</span><span class="sxs-lookup"><span data-stu-id="c6583-130">Use auto-sizing</span></span>

<span data-ttu-id="c6583-131">コントロールの絶対サイズを指定しないでください。</span><span class="sxs-lookup"><span data-stu-id="c6583-131">Don't specify absolute sizes for your controls.</span></span> <span data-ttu-id="c6583-132">可能であれば、[プラットフォームのユーザーとデバイスの設定に基づいて自動的に、コントロールのサイズを変更することができます。</span><span class="sxs-lookup"><span data-stu-id="c6583-132">Whenever possible, let the platform resize your controls automatically based on user and device settings.</span></span>  

<span data-ttu-id="c6583-133">前の例からのこのスニペットで使用して、`Auto`と`*`一連のグリッドの列とできるように、プラットフォームの幅の値は、グリッド内に含まれる要素のサイズに基づくアプリのレイアウトを調整します。</span><span class="sxs-lookup"><span data-stu-id="c6583-133">In this snippet from the previous example, we use the `Auto` and `*` width values for a set of grid columns and let the platform adjust the app layout based on the size of the elements contained within the grid.</span></span>

``` xaml
<Grid.ColumnDefinitions>
    <ColumnDefinition Width="Auto"/>
    <ColumnDefinition Width="*"/>
    <ColumnDefinition Width="Auto"/>
</Grid.ColumnDefinitions>
```

### <a name="use-text-wrapping"></a><span data-ttu-id="c6583-134">テキストの折り返し</span><span class="sxs-lookup"><span data-stu-id="c6583-134">Use text wrapping</span></span>

<span data-ttu-id="c6583-135">アプリのレイアウトは柔軟性および適応可能なことを確認するには、(多くのコントロールでサポートされないテキストの折り返し既定ではテキストが含まれているすべてのコントロールでテキストの折り返しを有効にします。</span><span class="sxs-lookup"><span data-stu-id="c6583-135">To ensure the layout of your app is as flexible and adaptable as possible, enable text wrapping in any control that contains text (many controls do not support text wrapping by default).</span></span>

<span data-ttu-id="c6583-136">プラットフォームで他のメソッドを使用して、クリッピングを含む、レイアウトを調整するテキストの折り返しを指定しない場合 (前の例をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="c6583-136">If you don't specify text wrapping, the platform uses other methods to adjust the layout, including clipping (see previous example).</span></span>

<span data-ttu-id="c6583-137">ここでは、使用して、`AcceptsReturn`と`TextWrapping`、レイアウトを確認するテキスト ボックスのプロパティはできる限り柔軟なします。</span><span class="sxs-lookup"><span data-stu-id="c6583-137">Here, we use the `AcceptsReturn` and `TextWrapping` TextBox properties to ensure our layout is as flexible as possible.</span></span>

``` xaml
<TextBox PlaceholderText="Type something here" 
          AcceptsReturn="True" TextWrapping="Wrap" />
```

![テキストとテキストの折り返し 225% に 100% のスケーリングをアニメーション化](images/coretext/text-scaling-textwrap.gif)  
*<span data-ttu-id="c6583-139">テキストの折り返しをスケーリング アニメーション化されたテキスト</span><span class="sxs-lookup"><span data-stu-id="c6583-139">Animated text scaling with text wrapping</span></span>*

### <a name="specify-text-trimming-behavior"></a><span data-ttu-id="c6583-140">テキストのトリミングの動作を指定します。</span><span class="sxs-lookup"><span data-stu-id="c6583-140">Specify text trimming behavior</span></span>

<span data-ttu-id="c6583-141">テキストの折り返しが優先される動作でない場合は、ほとんどのテキスト コントロールには、テキストをクリップまたはテキストのトリミングの動作の省略記号を指定することができます。</span><span class="sxs-lookup"><span data-stu-id="c6583-141">If text wrapping is not the preferred behavior, most text controls let either clip your text or specify ellipses for the text trimming behavior.</span></span> <span data-ttu-id="c6583-142">クリッピングは省略記号領域を占有自体の省略記号を優先します。</span><span class="sxs-lookup"><span data-stu-id="c6583-142">Clipping is preferred to ellipses as ellipses take up space themselves.</span></span>

> [!NOTE]
> <span data-ttu-id="c6583-143">テキストをクリップする必要がある場合は、開始しない、文字列の末尾をクリップできます。</span><span class="sxs-lookup"><span data-stu-id="c6583-143">If you need to clip your text, clip the end of the string, not the beginning.</span></span>

<span data-ttu-id="c6583-144">この例で方法を示します TextBlock のテキストをクリップ[TextTrimming](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.textblock.texttrimming)プロパティを使用します。</span><span class="sxs-lookup"><span data-stu-id="c6583-144">In this example, we show how to clip text in a TextBlock using the [TextTrimming](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.textblock.texttrimming) property.</span></span>

``` xaml
<TextBlock TextTrimming="Clip">
    The quick brown fox jumped over the lazy dog.
</TextBlock>
```

![テキストとテキストがクリッピングされて 225% に 100% のスケーリング](images/coretext/text-scaling-clipping-small.png)  
*<span data-ttu-id="c6583-146">テキストとテキストがクリッピングされてスケーリング</span><span class="sxs-lookup"><span data-stu-id="c6583-146">Text scaling with text clipping</span></span>*

### <a name="use-a-tooltip"></a><span data-ttu-id="c6583-147">Tooltip します。</span><span class="sxs-lookup"><span data-stu-id="c6583-147">Use a tooltip</span></span>

<span data-ttu-id="c6583-148">テキストをクリップする場合は、ユーザーへの完全なテキストを提供するヒントを使用します。</span><span class="sxs-lookup"><span data-stu-id="c6583-148">If you clip text, use a tooltip to provide the full text to your users.</span></span>

<span data-ttu-id="c6583-149">ここでは、ヒントは、テキストの折り返しがサポートされていない TextBlock を追加します。</span><span class="sxs-lookup"><span data-stu-id="c6583-149">Here, we add a tooltip to a TextBlock that doesn't support text wrapping:</span></span>

``` xaml
<TextBlock TextTrimming="Clip">
    <ToolTipService.ToolTip>
        <ToolTip Content="The quick brown fox jumped over the lazy dog."/>
    </ToolTipService.ToolTip>
    The quick brown fox jumped over the lazy dog.
</TextBlock>
```

### <a name="dont-scale-font-based-icons-or-symbols"></a><span data-ttu-id="c6583-150">フォント ベースのアイコンや記号、拡大縮小されません。</span><span class="sxs-lookup"><span data-stu-id="c6583-150">Don’t scale font-based icons or symbols</span></span>

<span data-ttu-id="c6583-151">フォント ベースのアイコンを強調または装飾を使用する場合は、これらの文字でのスケーリングを無効にします。</span><span class="sxs-lookup"><span data-stu-id="c6583-151">When using font-based icons for emphasis or decoration, disable scaling on these characters.</span></span>

<span data-ttu-id="c6583-152">[IsTextScaleFactorEnabled](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.control.istextscalefactorenabled)プロパティを設定する`false`ほとんどの XAML コントロールです。</span><span class="sxs-lookup"><span data-stu-id="c6583-152">Set the [IsTextScaleFactorEnabled](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.control.istextscalefactorenabled) property to `false` for most XAML controls.</span></span>

### <a name="support-text-scaling-natively"></a><span data-ttu-id="c6583-153">スケーリングをネイティブにサポート テキスト</span><span class="sxs-lookup"><span data-stu-id="c6583-153">Support text scaling natively</span></span>

<span data-ttu-id="c6583-154">カスタム フレームワークやコントロールで[TextScaleFactorChanged](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.uisettings.textscalefactorchanged) UISettings システム イベントを処理します。</span><span class="sxs-lookup"><span data-stu-id="c6583-154">Handle the [TextScaleFactorChanged](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.uisettings.textscalefactorchanged) UISettings system event in your custom framework and controls.</span></span> <span data-ttu-id="c6583-155">このイベントは、ユーザーがシステムにテキストの倍率を設定するたびにします。</span><span class="sxs-lookup"><span data-stu-id="c6583-155">This event is raised each time the user sets the text scaling factor on their system.</span></span>

## <a name="summary"></a><span data-ttu-id="c6583-156">まとめ</span><span class="sxs-lookup"><span data-stu-id="c6583-156">Summary</span></span>

<span data-ttu-id="c6583-157">このトピックでは、Windows でのサポートをスケーリングするテキストの概要を説明し、ユーザー エクスペリエンスをカスタマイズする方法についての UX と開発者向けガイダンスが含まれます。</span><span class="sxs-lookup"><span data-stu-id="c6583-157">This topic provides an overview of text scaling support in Windows and includes UX and developer guidance on how to customize the user experience.</span></span>

## <a name="related-articles"></a><span data-ttu-id="c6583-158">関連記事</span><span class="sxs-lookup"><span data-stu-id="c6583-158">Related articles</span></span>

### <a name="api-reference"></a><span data-ttu-id="c6583-159">API リファレンス</span><span class="sxs-lookup"><span data-stu-id="c6583-159">API reference</span></span>

- [<span data-ttu-id="c6583-160">IsTextScaleFactorEnabled</span><span class="sxs-lookup"><span data-stu-id="c6583-160">IsTextScaleFactorEnabled</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.control.istextscalefactorenabled)
- [<span data-ttu-id="c6583-161">TextScaleFactorChanged</span><span class="sxs-lookup"><span data-stu-id="c6583-161">TextScaleFactorChanged</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.uisettings.textscalefactorchanged)
