---
Description: UWP アプリとプラットフォーム テキスト scaling をサポートするカスタム/テンプレートのコントロールをビルドします。
title: テキストの拡大縮小
label: Text scaling
template: detail.hbs
keywords: 「Make テキストがより大きな」、ユーザーの操作、入力、UWP、テキスト、スケーリング、アクセシビリティ、「のアクセスの容易さ」を表示します。
ms.date: 08/02/2018
ms.topic: article
ms.localizationpriority: medium
ms.custom: RS5
ms.openlocfilehash: 22ad7a1ac6160fd8b1cfb70c69f299c5d89192d3
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57600817"
---
# <a name="text-scaling"></a><span data-ttu-id="b94e4-104">テキストの拡大縮小</span><span class="sxs-lookup"><span data-stu-id="b94e4-104">Text scaling</span></span>

<span data-ttu-id="b94e4-105">![100 ~ 225% に拡大縮小テキストの例](images/coretext/text-scaling-news-hero-small.png)</span><span class="sxs-lookup"><span data-stu-id="b94e4-105">![Example of text scaling 100% to 225%](images/coretext/text-scaling-news-hero-small.png)</span></span>  
<span data-ttu-id="b94e4-106">*Windows 10 (225% を 100%) でのスケーリングのテキストの例*</span><span class="sxs-lookup"><span data-stu-id="b94e4-106">*Example of text scaling in Windows 10 (100% to 225%)*</span></span>

## <a name="overview"></a><span data-ttu-id="b94e4-107">概要</span><span class="sxs-lookup"><span data-stu-id="b94e4-107">Overview</span></span>

<span data-ttu-id="b94e4-108">(ラップトップ、Surface Hub の巨大な画面にデスクトップ モニターをモバイル デバイス) からコンピューター画面上のテキストを読み取るは、多くの人にとって難しいことができます。</span><span class="sxs-lookup"><span data-stu-id="b94e4-108">Reading text on a computer screen (from mobile device to laptop to desktop monitor to the giant screen of a Surface Hub) can be challenging for many people.</span></span> <span data-ttu-id="b94e4-109">逆に、一部のユーザーは、必要以上にするアプリや web サイトで使用されるフォント サイズを検索します。</span><span class="sxs-lookup"><span data-stu-id="b94e4-109">Conversely, some users find the font sizes used in apps and web sites to be larger than necessary.</span></span>

<span data-ttu-id="b94e4-110">テキストはを幅広いユーザーできるだけ読みやすいことを確認するには、Windows には、ユーザーが、OS と個々 のアプリケーション間での相対的なフォント サイズを変更する機能が用意されています。</span><span class="sxs-lookup"><span data-stu-id="b94e4-110">To ensure text is as legible as possible for the broadest range of users, Windows provides the ability for users to change relative font size across both the OS and individual applications.</span></span> <span data-ttu-id="b94e4-111">拡大鏡アプリ (を通常だけ、画面の領域内のすべてを拡大し、独自の使いやすさの問題が発生する) を使用して、ディスプレイの解像度を変更または DPI スケール (を表示し、一般的な表示に基づくすべてのサイズ変更に依存する代わりに距離)、ユーザーがテキストだけで、100% (既定のサイズ) の範囲のサイズを変更する設定をすばやくアクセス 225% です。</span><span class="sxs-lookup"><span data-stu-id="b94e4-111">Instead of using a magnifier app (which typically just enlarges everything within an area of the screen and introduces its own usability issues), changing display resolution, or relying on DPI scaling (which resizes everything based on display and typical viewing distance), a user can quickly access a setting to resize just text, ranging from 100% (the default size) up to 225%.</span></span>

## <a name="support"></a><span data-ttu-id="b94e4-112">サポート</span><span class="sxs-lookup"><span data-stu-id="b94e4-112">Support</span></span>

<span data-ttu-id="b94e4-113">ユニバーサル Windows アプリケーション (標準の PWA と)、テキストが既定ではスケーリングをサポートします。</span><span class="sxs-lookup"><span data-stu-id="b94e4-113">Universal Windows applications (both standard and PWA), support text scaling by default.</span></span>

<span data-ttu-id="b94e4-114">UWP アプリケーションには、カスタム コントロール、カスタム テキスト サーフェス、ハード コードされたコントロールの高さ、古いフレームワーク、またはサード パーティ製のフレームワークが含まれている場合は、ユーザーのエクスペリエンスを一貫した有用なことを確認するには、いくつか更新がある可能性があります。</span><span class="sxs-lookup"><span data-stu-id="b94e4-114">If your UWP application includes custom controls, custom text surfaces, hard-coded control heights, older frameworks, or 3rd party frameworks, you likely have to make some updates to ensure a consistent and useful experience for your users.</span></span>  

<span data-ttu-id="b94e4-115">DirectWrite、GDI、および XAML SwapChainPanels ネイティブでサポートしないテキストのスケーリング、Win32 のサポートは、メニューのアイコン、およびツールバーに制限されます。</span><span class="sxs-lookup"><span data-stu-id="b94e4-115">DirectWrite, GDI, and XAML SwapChainPanels do not natively support text scaling, while Win32 support is limited to menus, icons, and toolbars.</span></span>  

<!-- If you want to support text scaling in your application with these frameworks, you’ll need to support the text scaling change event outlined below and provide alternative sizes for your UI and content.   -->

## <a name="user-experience"></a><span data-ttu-id="b94e4-116">ユーザー エクスペリエンス</span><span class="sxs-lookup"><span data-stu-id="b94e4-116">User experience</span></span>

<span data-ttu-id="b94e4-117">ユーザーがテキストのスケールを調整できるコンピューターの簡単操作]-> [設定のスライダーをより大きなテキストにするにはビジョン/ディスプレイの画面]-> [です。</span><span class="sxs-lookup"><span data-stu-id="b94e4-117">Users can adjust text scale with the Make text bigger slider on the Settings -> Ease of Access -> Vision/Display screen.</span></span>

<span data-ttu-id="b94e4-118">![100 ~ 225% に拡大縮小テキストの例](images/coretext/text-scaling-settings-100-small.png)</span><span class="sxs-lookup"><span data-stu-id="b94e4-118">![Example of text scaling 100% to 225%](images/coretext/text-scaling-settings-100-small.png)</span></span>  
<span data-ttu-id="b94e4-119">*テキストのスケール設定の設定からコンピューターの簡単操作]-> [Vision/ディスプレイの画面を ->*</span><span class="sxs-lookup"><span data-stu-id="b94e4-119">*Text scale setting from Settings -> Ease of Access -> Vision/Display screen*</span></span>

## <a name="ux-guidance"></a><span data-ttu-id="b94e4-120">UX ガイダンス</span><span class="sxs-lookup"><span data-stu-id="b94e4-120">UX guidance</span></span>

<span data-ttu-id="b94e4-121">テキストのサイズを調整コントロールとコンテナーする必要がありますものサイズを変更し、テキストと新しいレイアウトに合わせて調整します。</span><span class="sxs-lookup"><span data-stu-id="b94e4-121">As text is resized, controls and containers must also resize and reflow to accommodate the text and its new layout.</span></span> <span data-ttu-id="b94e4-122">アプリ、フレームワーク、プラットフォームによって、以前に説明したように、この作業の多くが行われます。</span><span class="sxs-lookup"><span data-stu-id="b94e4-122">As mentioned previously, depending on the app, framework, and platform, much of this work is done for you.</span></span> <span data-ttu-id="b94e4-123">次の UX ガイドでは、このような場合がについて説明します。</span><span class="sxs-lookup"><span data-stu-id="b94e4-123">The following UX guidance covers those cases where it's not.</span></span>

### <a name="use-the-platform-controls"></a><span data-ttu-id="b94e4-124">プラットフォーム コントロールを使用します。</span><span class="sxs-lookup"><span data-stu-id="b94e4-124">Use the platform controls</span></span>

<span data-ttu-id="b94e4-125">言ったのこの既にでしょうか。</span><span class="sxs-lookup"><span data-stu-id="b94e4-125">Did we say this already?</span></span> <span data-ttu-id="b94e4-126">繰り返す価値があります。可能であれば、常に最小限の作業の最も包括的なユーザー エクスペリエンスを実現するため、さまざまな Windows アプリ フレームワークで提供される組み込みのコントロールを使用します。</span><span class="sxs-lookup"><span data-stu-id="b94e4-126">It's worth repeating: When possible, always use the built-in controls provided with the various Windows app frameworks to get the most comprehensive user experience possible for the least amount of effort.</span></span>

<span data-ttu-id="b94e4-127">たとえば、UWP のすべてのテキスト コントロールは、フルテキスト エクスペリエンスのカスタマイズやテンプレートなしのスケーリングをサポートします。</span><span class="sxs-lookup"><span data-stu-id="b94e4-127">For example, all UWP text controls support the full text scaling experience without any customization or templating.</span></span>

<span data-ttu-id="b94e4-128">標準のテキスト コントロールをいくつかを含む基本的な UWP アプリからのスニペットを次に示します。</span><span class="sxs-lookup"><span data-stu-id="b94e4-128">Here's a snippet from a basic UWP app that includes a couple of standard text controls:</span></span>

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

<span data-ttu-id="b94e4-129">![アニメーション化されたテキストが 100% ~ 225% のスケーリング](images/coretext/text-scaling.gif)</span><span class="sxs-lookup"><span data-stu-id="b94e4-129">![Animated text scaling 100% to 225%](images/coretext/text-scaling.gif)</span></span>  
<span data-ttu-id="b94e4-130">*アニメーション化されたテキストのスケーリング*</span><span class="sxs-lookup"><span data-stu-id="b94e4-130">*Animated text scaling*</span></span>

### <a name="use-auto-sizing"></a><span data-ttu-id="b94e4-131">自動サイズ調整を使用します。</span><span class="sxs-lookup"><span data-stu-id="b94e4-131">Use auto-sizing</span></span>

<span data-ttu-id="b94e4-132">コントロールの絶対サイズを指定しないでください。</span><span class="sxs-lookup"><span data-stu-id="b94e4-132">Don't specify absolute sizes for your controls.</span></span> <span data-ttu-id="b94e4-133">可能であれば、ユーザーとデバイスの設定に基づいて自動的にコントロールのサイズを変更するプラットフォームを使用できます。</span><span class="sxs-lookup"><span data-stu-id="b94e4-133">Whenever possible, let the platform resize your controls automatically based on user and device settings.</span></span>  

<span data-ttu-id="b94e4-134">このスニペットが、前の例では使用して、`Auto`と`*`一連の let プラットフォームとグリッド列の幅の値がグリッド内に含まれる要素のサイズに基づいてアプリのレイアウトを調整します。</span><span class="sxs-lookup"><span data-stu-id="b94e4-134">In this snippet from the previous example, we use the `Auto` and `*` width values for a set of grid columns and let the platform adjust the app layout based on the size of the elements contained within the grid.</span></span>

``` xaml
<Grid.ColumnDefinitions>
    <ColumnDefinition Width="Auto"/>
    <ColumnDefinition Width="*"/>
    <ColumnDefinition Width="Auto"/>
</Grid.ColumnDefinitions>
```

### <a name="use-text-wrapping"></a><span data-ttu-id="b94e4-135">テキストの折り返し</span><span class="sxs-lookup"><span data-stu-id="b94e4-135">Use text wrapping</span></span>

<span data-ttu-id="b94e4-136">アプリのレイアウトはを柔軟で可能な限り適応性のあることを確認するには、(多くのコントロールによってサポートしていないテキストの折り返し既定値) のテキストを含む任意のコントロールのテキストの折り返しを有効にします。</span><span class="sxs-lookup"><span data-stu-id="b94e4-136">To ensure the layout of your app is as flexible and adaptable as possible, enable text wrapping in any control that contains text (many controls do not support text wrapping by default).</span></span>

<span data-ttu-id="b94e4-137">プラットフォームが、クリッピングなど、レイアウトを調整するその他のメソッドを使用してテキストの折り返しを指定しない場合 (前の例を参照してください)。</span><span class="sxs-lookup"><span data-stu-id="b94e4-137">If you don't specify text wrapping, the platform uses other methods to adjust the layout, including clipping (see previous example).</span></span>

<span data-ttu-id="b94e4-138">ここで、使用、`AcceptsReturn`と`TextWrapping`レイアウトを確認するテキスト ボックスのプロパティは、柔軟性を備えています。</span><span class="sxs-lookup"><span data-stu-id="b94e4-138">Here, we use the `AcceptsReturn` and `TextWrapping` TextBox properties to ensure our layout is as flexible as possible.</span></span>

``` xaml
<TextBox PlaceholderText="Type something here" 
          AcceptsReturn="True" TextWrapping="Wrap" />
```

<span data-ttu-id="b94e4-139">![100 ~ 225% 自動スケールでテキストの折り返しテキストをアニメーション化](images/coretext/text-scaling-textwrap.gif)</span><span class="sxs-lookup"><span data-stu-id="b94e4-139">![Animated text scaling 100% to 225% with text wrapping](images/coretext/text-scaling-textwrap.gif)</span></span>  
<span data-ttu-id="b94e4-140">*アニメーション化されたテキストがテキストの折り返しを使用したスケール*</span><span class="sxs-lookup"><span data-stu-id="b94e4-140">*Animated text scaling with text wrapping*</span></span>

### <a name="specify-text-trimming-behavior"></a><span data-ttu-id="b94e4-141">テキストのトリミング動作を指定します。</span><span class="sxs-lookup"><span data-stu-id="b94e4-141">Specify text trimming behavior</span></span>

<span data-ttu-id="b94e4-142">テキストの折り返しが優先動作でない場合は、ほとんどのテキスト コントロールを使用するテキストをクリップするか、テキストのトリミング動作の省略記号を指定できます。</span><span class="sxs-lookup"><span data-stu-id="b94e4-142">If text wrapping is not the preferred behavior, most text controls let you either clip your text or specify ellipses for the text trimming behavior.</span></span> <span data-ttu-id="b94e4-143">省略記号が自身の領域を占有クリッピングは楕円に優先されます。</span><span class="sxs-lookup"><span data-stu-id="b94e4-143">Clipping is preferred to ellipses as ellipses take up space themselves.</span></span>

> [!NOTE]
> <span data-ttu-id="b94e4-144">テキストをクリップする必要がある場合は、先頭ではない、文字列の末尾をクリップします。</span><span class="sxs-lookup"><span data-stu-id="b94e4-144">If you need to clip your text, clip the end of the string, not the beginning.</span></span>

<span data-ttu-id="b94e4-145">この例でを使用して、TextBlock のテキストをクリップする方法を説明します、 [TextTrimming](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.textblock.texttrimming)プロパティ。</span><span class="sxs-lookup"><span data-stu-id="b94e4-145">In this example, we show how to clip text in a TextBlock using the [TextTrimming](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.textblock.texttrimming) property.</span></span>

``` xaml
<TextBlock TextTrimming="Clip">
    The quick brown fox jumped over the lazy dog.
</TextBlock>
```

<span data-ttu-id="b94e4-146">![テキストがテキスト領域で 100 ~ 225% のスケーリング](images/coretext/text-scaling-clipping-small.png)</span><span class="sxs-lookup"><span data-stu-id="b94e4-146">![Text scaling 100% to 225% with text clipping](images/coretext/text-scaling-clipping-small.png)</span></span>  
<span data-ttu-id="b94e4-147">*テキストのテキストのクリッピングを使用したスケール*</span><span class="sxs-lookup"><span data-stu-id="b94e4-147">*Text scaling with text clipping*</span></span>

### <a name="use-a-tooltip"></a><span data-ttu-id="b94e4-148">ツールヒントを使用して、</span><span class="sxs-lookup"><span data-stu-id="b94e4-148">Use a tooltip</span></span>

<span data-ttu-id="b94e4-149">テキストをクリップする場合は、ツールヒントを使用して、ユーザーに完全なテキストを提供します。</span><span class="sxs-lookup"><span data-stu-id="b94e4-149">If you clip text, use a tooltip to provide the full text to your users.</span></span>

<span data-ttu-id="b94e4-150">ここでは、テキストの折り返しをサポートしていない TextBlock にツールヒントを追加します。</span><span class="sxs-lookup"><span data-stu-id="b94e4-150">Here, we add a tooltip to a TextBlock that doesn't support text wrapping:</span></span>

``` xaml
<TextBlock TextTrimming="Clip">
    <ToolTipService.ToolTip>
        <ToolTip Content="The quick brown fox jumped over the lazy dog."/>
    </ToolTipService.ToolTip>
    The quick brown fox jumped over the lazy dog.
</TextBlock>
```

### <a name="dont-scale-font-based-icons-or-symbols"></a><span data-ttu-id="b94e4-151">フォント ベースのアイコンまたはシンボルのスケール変更はありません。</span><span class="sxs-lookup"><span data-stu-id="b94e4-151">Don’t scale font-based icons or symbols</span></span>

<span data-ttu-id="b94e4-152">フォント ベースのアイコンを強調または装飾を使用する場合は、これらの文字のスケーリングを無効にします。</span><span class="sxs-lookup"><span data-stu-id="b94e4-152">When using font-based icons for emphasis or decoration, disable scaling on these characters.</span></span>

<span data-ttu-id="b94e4-153">設定、 [IsTextScaleFactorEnabled](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.control.istextscalefactorenabled)プロパティを`false`XAML のほとんどを制御します。</span><span class="sxs-lookup"><span data-stu-id="b94e4-153">Set the [IsTextScaleFactorEnabled](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.control.istextscalefactorenabled) property to `false` for most XAML controls.</span></span>

### <a name="support-text-scaling-natively"></a><span data-ttu-id="b94e4-154">ネイティブのスケーリング サポート テキスト</span><span class="sxs-lookup"><span data-stu-id="b94e4-154">Support text scaling natively</span></span>

<span data-ttu-id="b94e4-155">処理、 [TextScaleFactorChanged](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.uisettings.textscalefactorchanged)カスタムのフレームワークとコントロールで UISettings システム イベント。</span><span class="sxs-lookup"><span data-stu-id="b94e4-155">Handle the [TextScaleFactorChanged](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.uisettings.textscalefactorchanged) UISettings system event in your custom framework and controls.</span></span> <span data-ttu-id="b94e4-156">このイベントには、ユーザーがシステムにテキストの倍率を設定するたびが発生します。</span><span class="sxs-lookup"><span data-stu-id="b94e4-156">This event is raised each time the user sets the text scaling factor on their system.</span></span>

## <a name="summary"></a><span data-ttu-id="b94e4-157">概要</span><span class="sxs-lookup"><span data-stu-id="b94e4-157">Summary</span></span>

<span data-ttu-id="b94e4-158">このトピックでは、Windows でのサポートを拡大縮小テキストの概要を説明し、ユーザー エクスペリエンスをカスタマイズする方法の UX や開発者向けのガイダンスが含まれます。</span><span class="sxs-lookup"><span data-stu-id="b94e4-158">This topic provides an overview of text scaling support in Windows and includes UX and developer guidance on how to customize the user experience.</span></span>

## <a name="related-articles"></a><span data-ttu-id="b94e4-159">関連記事</span><span class="sxs-lookup"><span data-stu-id="b94e4-159">Related articles</span></span>

### <a name="api-reference"></a><span data-ttu-id="b94e4-160">API リファレンス</span><span class="sxs-lookup"><span data-stu-id="b94e4-160">API reference</span></span>

- [<span data-ttu-id="b94e4-161">IsTextScaleFactorEnabled</span><span class="sxs-lookup"><span data-stu-id="b94e4-161">IsTextScaleFactorEnabled</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.control.istextscalefactorenabled)
- [<span data-ttu-id="b94e4-162">TextScaleFactorChanged</span><span class="sxs-lookup"><span data-stu-id="b94e4-162">TextScaleFactorChanged</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.uisettings.textscalefactorchanged)
