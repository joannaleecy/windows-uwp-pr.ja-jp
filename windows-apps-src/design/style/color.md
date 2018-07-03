---
author: serenaz
description: UWP アプリでアクセント カラーとテーマを使用する方法について説明します。
title: UWP アプリでの色使い
ms.author: sezhen
ms.date: 4/7/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
design-contact: karenmui
ms.localizationpriority: medium
ms.openlocfilehash: fc348dc4f4733feae86a94e0ada1693326a201d8
ms.sourcegitcommit: 517c83baffd344d4c705bc644d7c6d2b1a4c7e1a
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/07/2018
ms.locfileid: "1843192"
---
# <a name="color"></a><span data-ttu-id="0bb0c-104">色</span><span class="sxs-lookup"><span data-stu-id="0bb0c-104">Color</span></span>

![ヒーロー イメージ](images/header-color.svg)

<span data-ttu-id="0bb0c-106">色は、アプリの中でユーザーに情報を伝える直感的な方法です。操作可能な要素の強調、ユーザー操作に対するフィードバックの提供、インターフェイスの連続感の演出を色によって行うことができます。</span><span class="sxs-lookup"><span data-stu-id="0bb0c-106">Color provides an intuitive way of communicating information to users in your app: it can be used to indicate interactivity, give feedback to user actions, and give your interface a sense of visual continuity.</span></span> 

<span data-ttu-id="0bb0c-107">UWP アプリでの色使いは、主にアクセント カラーとテーマによって指定します。</span><span class="sxs-lookup"><span data-stu-id="0bb0c-107">In UWP apps, colors are primarily determined by accent color and theme.</span></span> <span data-ttu-id="0bb0c-108">この記事では、アプリで色を使用する方法と、アクセント カラーとテーマ リソースを使用して、任意のテーマに対応して UWP アプリを使用できるように設定する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="0bb0c-108">In this article, we'll discuss how you can use color in your app, and how to use accent color and theme resources to make your UWP app usable in any theme context.</span></span> 

## <a name="color-principles"></a><span data-ttu-id="0bb0c-109">色使いの原則</span><span class="sxs-lookup"><span data-stu-id="0bb0c-109">Color principles</span></span>

<span data-ttu-id="0bb0c-110">:::row::: :::column::: **色が意味を持つように使用します。**</span><span class="sxs-lookup"><span data-stu-id="0bb0c-110">:::row::: :::column::: **Use color meaningfully.**</span></span>
<span data-ttu-id="0bb0c-111">重要な要素が強調されるように控え目に色を使用すると、柔軟で直感的なユーザー インターフェイスの作成に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="0bb0c-111">When color is used sparingly to highlight important elements, it can help create a user interface that is fluid and intuitive.</span></span>
<span data-ttu-id="0bb0c-112">:::column-end::: :::column::: **操作対象の要素を示すために色を使用します。**</span><span class="sxs-lookup"><span data-stu-id="0bb0c-112">:::column-end::: :::column::: **Use color to indicate interactivity.**</span></span>
<span data-ttu-id="0bb0c-113">アプリケーションの中で、操作の対象要素を示す色を 1 つ決めておくことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="0bb0c-113">It's a good idea to choose one color to indicate elements of your application that are interactive.</span></span> <span data-ttu-id="0bb0c-114">たとえば、多くの Web ページでは、ハイパーリンクを示すために青色のテキストを使用しています。</span><span class="sxs-lookup"><span data-stu-id="0bb0c-114">For example, many web pages use blue text to denote a hyperlink.</span></span>
<span data-ttu-id="0bb0c-115">:::column-end::: :::row-end:::</span><span class="sxs-lookup"><span data-stu-id="0bb0c-115">:::column-end::: :::row-end:::</span></span>

<span data-ttu-id="0bb0c-116">:::row::: :::column::: **色は個々のユーザーが設定できます。**</span><span class="sxs-lookup"><span data-stu-id="0bb0c-116">:::row::: :::column::: **Color is personal.**</span></span>
<span data-ttu-id="0bb0c-117">Windows では、ユーザーがアクセント カラーや淡色/濃色のテーマを選んで、各自のエクスペリエンス全体に適用できます。</span><span class="sxs-lookup"><span data-stu-id="0bb0c-117">In Windows, users can choose an accent color and a light or dark theme, which are reflected throughout their experience.</span></span> <span data-ttu-id="0bb0c-118">開発者は、ユーザーが選んだアクセント カラーとテーマをどのようにアプリケーションに組み込んで、個人に応じたエクスペリエンスを提供するかを選択できます。</span><span class="sxs-lookup"><span data-stu-id="0bb0c-118">You can choose how to incorporate the user's accent color and theme into your application, personalizing their experience.</span></span>
<span data-ttu-id="0bb0c-119">:::column-end::: :::column::: **色の解釈は文化によって異なります。**</span><span class="sxs-lookup"><span data-stu-id="0bb0c-119">:::column-end::: :::column::: **Color is cultural.**</span></span>
<span data-ttu-id="0bb0c-120">アプリで使用する色が、異なる文化圏のユーザーにどのように解釈されるかを考慮してください。</span><span class="sxs-lookup"><span data-stu-id="0bb0c-120">Consider how the colors you use will be interpreted by people from different cultures.</span></span> <span data-ttu-id="0bb0c-121">たとえば、文化によっては、青が美徳と保護を表すこともあれば、服喪を連想させることもあります。</span><span class="sxs-lookup"><span data-stu-id="0bb0c-121">For example, in some cultures the color blue is associated with virtue and protection, while in others it represents mourning.</span></span>
<span data-ttu-id="0bb0c-122">:::column-end::: :::row-end:::</span><span class="sxs-lookup"><span data-stu-id="0bb0c-122">:::column-end::: :::row-end:::</span></span>

## <a name="themes"></a><span data-ttu-id="0bb0c-123">テーマ</span><span class="sxs-lookup"><span data-stu-id="0bb0c-123">Themes</span></span>

<span data-ttu-id="0bb0c-124">UWP アプリでは、淡色または濃色のアプリケーション テーマを使用できます。</span><span class="sxs-lookup"><span data-stu-id="0bb0c-124">UWP apps can use a light or dark application theme.</span></span> <span data-ttu-id="0bb0c-125">テーマは、アプリの背景、テキスト、アイコン、[コモン コントロール](../controls-and-patterns/index.md) に反映されます。</span><span class="sxs-lookup"><span data-stu-id="0bb0c-125">The theme affects the colors of the app's background, text, icons, and [common controls](../controls-and-patterns/index.md).</span></span>

### <a name="light-theme"></a><span data-ttu-id="0bb0c-126">淡色テーマ</span><span class="sxs-lookup"><span data-stu-id="0bb0c-126">Light theme</span></span>

![淡色テーマ](images/color/light-theme.svg)

### <a name="dark-theme"></a><span data-ttu-id="0bb0c-128">濃色テーマ</span><span class="sxs-lookup"><span data-stu-id="0bb0c-128">Dark theme</span></span>

![濃色テーマ](images/color/dark-theme.svg)

<span data-ttu-id="0bb0c-130">既定では、UWP アプリのテーマは、ユーザーが Windows の設定で選択したテーマか、デバイスの既定のテーマ (XBox では黒など) に設定されます。</span><span class="sxs-lookup"><span data-stu-id="0bb0c-130">By default, your UWP app's theme is the user’s theme preference from Windows Settings or the device's default theme (i.e., dark on XBox).</span></span> <span data-ttu-id="0bb0c-131">ただし、開発者が UWP アプリのテーマを設定することもできます。</span><span class="sxs-lookup"><span data-stu-id="0bb0c-131">However, you can set the theme for your UWP app.</span></span> 

### <a name="changing-the-theme"></a><span data-ttu-id="0bb0c-132">テーマの変更</span><span class="sxs-lookup"><span data-stu-id="0bb0c-132">Changing the theme</span></span>

<span data-ttu-id="0bb0c-133">テーマを変更するには、`App.xaml` ファイルで **RequestedTheme** プロパティを変更します。</span><span class="sxs-lookup"><span data-stu-id="0bb0c-133">You can change themes by changing the **RequestedTheme** property in your `App.xaml` file.</span></span>

```XAML
<Application
    x:Class="App9.App"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:local="using:App9"
    RequestedTheme="Dark">
</Application>
```

<span data-ttu-id="0bb0c-134">**RequestedTheme** プロパティを削除すると、アプリケーションでユーザーのシステム設定が使用されるようになります。</span><span class="sxs-lookup"><span data-stu-id="0bb0c-134">Removing the **RequestedTheme** property means that your application will use the user’s system settings.</span></span>

<span data-ttu-id="0bb0c-135">ユーザーはまたハイ コントラスト テーマを使用することができます。これはインターフェイスを見やすくするために、コントラストの大きい、少数の色のパレットを使ったテーマです。</span><span class="sxs-lookup"><span data-stu-id="0bb0c-135">Users can also select the high contrast theme, which uses a small palette of contrasting colors that makes the interface easier to see.</span></span> <span data-ttu-id="0bb0c-136">ハイ コントラスト テーマを使用した場合、開発者が設定した RequestedTheme はシステムによって上書きされます。</span><span class="sxs-lookup"><span data-stu-id="0bb0c-136">In that case, the system will override your RequestedTheme.</span></span>

### <a name="testing-themes"></a><span data-ttu-id="0bb0c-137">テーマのテスト</span><span class="sxs-lookup"><span data-stu-id="0bb0c-137">Testing themes</span></span>

<span data-ttu-id="0bb0c-138">アプリのテーマを指定しない場合は、必ず淡色テーマと濃色テーマの両方でアプリをテストして、あらゆる条件でアプリが判読できることを確認します。</span><span class="sxs-lookup"><span data-stu-id="0bb0c-138">If you don't request a theme for your app, make sure to test your app in both light and dark themes to ensure that your app will be legible in all conditions.</span></span>

<span data-ttu-id="0bb0c-139">**注**: Visual Studio では、RequestedTheme の既定値が淡色に設定されているため、両方をテストするには、RequestedTheme を変更する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0bb0c-139">**Note**: In Visual Studio, the default RequestedTheme is light, so you'll need to change the RequestedTheme to test both.</span></span>

## <a name="theme-brushes"></a><span data-ttu-id="0bb0c-140">テーマ ブラシ</span><span class="sxs-lookup"><span data-stu-id="0bb0c-140">Theme brushes</span></span>

<span data-ttu-id="0bb0c-141">コモン コントロールでは、[テーマ ブラシ](../controls-and-patterns/xaml-theme-resources.md#the-xaml-color-ramp-and-theme-dependent-brushes)が自動的に作動して、淡色テーマと濃色テーマのコントラストが調整されます。</span><span class="sxs-lookup"><span data-stu-id="0bb0c-141">Common controls automatically use [theme brushes](../controls-and-patterns/xaml-theme-resources.md#the-xaml-color-ramp-and-theme-dependent-brushes) to adjust contrast for light and dark themes.</span></span>

<span data-ttu-id="0bb0c-142">たとえば、[AutoSuggestBox](../controls-and-patterns/auto-suggest-box.md) でテーマ ブラシが使用される方法を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="0bb0c-142">For example, here's an illustration of how the [AutoSuggestBox](../controls-and-patterns/auto-suggest-box.md) uses theme brushes:</span></span>

![テーマ ブラシ コントロールの例](images/color/theme-brushes.svg)

<span data-ttu-id="0bb0c-144">テーマ ブラシは、以下の目的で使用されます。</span><span class="sxs-lookup"><span data-stu-id="0bb0c-144">The theme brushes are used for the following purposes:</span></span>

- <span data-ttu-id="0bb0c-145">**Base** はテキストの設定に使用されます。</span><span class="sxs-lookup"><span data-stu-id="0bb0c-145">**Base** is for text.</span></span>
- <span data-ttu-id="0bb0c-146">**Alt** は、Base の反転色の設定に使用されます。</span><span class="sxs-lookup"><span data-stu-id="0bb0c-146">**Alt** is the inverse of Base.</span></span>
- <span data-ttu-id="0bb0c-147">**Chrome**  は、最上位の要素 (ナビゲーション ウィンドウやコマンド バーなど) の設定に使用されます。</span><span class="sxs-lookup"><span data-stu-id="0bb0c-147">**Chrome** is for top-level elements, such as navigation panes or command bars.</span></span>
- <span data-ttu-id="0bb0c-148">**List** は、リスト コントロールの設定に使用されます。</span><span class="sxs-lookup"><span data-stu-id="0bb0c-148">**List** is for list controls.</span></span>

<span data-ttu-id="0bb0c-149">**Low**/**Medium**/**High** は色密度を指します。</span><span class="sxs-lookup"><span data-stu-id="0bb0c-149">**Low**/**Medium**/**High** refer to the intensity of the color.</span></span>

### <a name="using-theme-brushes"></a><span data-ttu-id="0bb0c-150">テーマ ブラシの使用</span><span class="sxs-lookup"><span data-stu-id="0bb0c-150">Using theme brushes</span></span>

<span data-ttu-id="0bb0c-151">:::row::: :::column::: カスタム コントロールのテンプレートを作成する際は、ハード コードで色の値を設定するのではなく、テーマ ブラシを使用することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="0bb0c-151">:::row::: :::column::: When creating templates for custom controls, use theme brushes rather than hard code color values.</span></span> <span data-ttu-id="0bb0c-152">これにより、アプリがあらゆるテーマに容易に適応できるようになります。</span><span class="sxs-lookup"><span data-stu-id="0bb0c-152">This way, your app can easily adapt to any theme.</span></span>

        For example, these [item templates for ListView](../controls-and-patterns/item-templates-listview.md) demonstrate how to use theme brushes in a custom template.
    :::column-end:::
    :::column:::
         ![double line list item with icon example](images/color/list-view.svg)
    :::column-end:::
<span data-ttu-id="0bb0c-153">:::row-end:::</span><span class="sxs-lookup"><span data-stu-id="0bb0c-153">:::row-end:::</span></span>

```xaml
<ListView ItemsSource="{x:Bind ViewModel.Recordings}">
    <ListView.ItemTemplate>
        <DataTemplate x:Name="DoubleLineDataTemplate" x:DataType="local:Recording">
            <StackPanel Orientation="Horizontal" Height="64" AutomationProperties.Name="{x:Bind CompositionName}">
                <Ellipse Height="48" Width="48" VerticalAlignment="Center">
                    <Ellipse.Fill>
                        <ImageBrush ImageSource="Placeholder.png"/>
                    </Ellipse.Fill>
                </Ellipse>
                <StackPanel Orientation="Vertical" VerticalAlignment="Center" Margin="12,0,0,0">
                    <TextBlock Text="{x:Bind CompositionName}"  Style="{ThemeResource BaseTextBlockStyle}" Foreground="{ThemeResource SystemControlPageTextBaseHighBrush}" />
                    <TextBlock Text="{x:Bind ArtistName}" Style="{ThemeResource BodyTextBlockStyle}" Foreground="{ThemeResource SystemControlPageTextBaseMediumBrush}"/>
                </StackPanel>
            </StackPanel>
        </DataTemplate>
    </ListView.ItemTemplate>
</ListView>
```

<span data-ttu-id="0bb0c-154">アプリでテーマ ブラシを使用する方法について詳しくは、[テーマ リソースに関するページ](../controls-and-patterns/xaml-theme-resources.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0bb0c-154">For more information about how to use theme brushes in your app, see [Theme Resources](../controls-and-patterns/xaml-theme-resources.md).</span></span>

## <a name="accent-color"></a><span data-ttu-id="0bb0c-155">アクセント カラー</span><span class="sxs-lookup"><span data-stu-id="0bb0c-155">Accent color</span></span>

<span data-ttu-id="0bb0c-156">コモン コントロールでは、アクセント カラーを使用して、状態情報を伝達します。</span><span class="sxs-lookup"><span data-stu-id="0bb0c-156">Common controls use an accent color to convey state information.</span></span> <span data-ttu-id="0bb0c-157">アクセント カラーは、既定では、ユーザーが設定で選択した `SystemAccentColor` が使用されます。</span><span class="sxs-lookup"><span data-stu-id="0bb0c-157">By default, the accent color is the `SystemAccentColor` that users select in their Settings.</span></span> <span data-ttu-id="0bb0c-158">ただし、組織のブランドを反映するように、アプリのアクセント カラーをカスタマイズすることもできます。</span><span class="sxs-lookup"><span data-stu-id="0bb0c-158">However, you can also customize your app's accent color to reflect your brand.</span></span>

![Windows コントロール](images/color/windows-controls.svg)

<span data-ttu-id="0bb0c-160">:::row::: :::column::: ![ユーザーが選択したアクセント ヘッダー](images/color/user-accent.svg) ![ユーザーが選択したアクセント カラー](images/color/user-selected-accent.svg) :::column-end::: :::column::: ![カスタムのアクセント ヘッダー](images/color/custom-accent.svg) ![カスタムのブランド アクセント カラー](images/color/brand-color.svg) :::column-end::: :::row-end:::</span><span class="sxs-lookup"><span data-stu-id="0bb0c-160">:::row::: :::column::: ![user-selected accent header](images/color/user-accent.svg) ![user-selected accent color](images/color/user-selected-accent.svg) :::column-end::: :::column::: ![custom accent header](images/color/custom-accent.svg) ![custom brand accent color](images/color/brand-color.svg) :::column-end::: :::row-end:::</span></span>

### <a name="overriding-the-accent-color"></a><span data-ttu-id="0bb0c-161">アクセント カラーの上書き</span><span class="sxs-lookup"><span data-stu-id="0bb0c-161">Overriding the accent color</span></span>

<span data-ttu-id="0bb0c-162">アプリのアクセント カラーを変更するには、次のコードを `app.xaml` に追加します。</span><span class="sxs-lookup"><span data-stu-id="0bb0c-162">To change your app's accent color, place the following code in `app.xaml`.</span></span>

```xaml
<Application.Resources>
    <ResourceDictionary>
        <Color x:Key="SystemAccentColor">#107C10</Color>
    </ResourceDictionary>
</Application.Resources>
```

### <a name="choosing-an-accent-color"></a><span data-ttu-id="0bb0c-163">アクセント カラーの選択</span><span class="sxs-lookup"><span data-stu-id="0bb0c-163">Choosing an accent color</span></span>

<span data-ttu-id="0bb0c-164">アプリに対してカスタムのアクセント カラーを選択した場合は、アクセント カラーを使用したテキストと背景との間に十分なコントラストがあり、テキストを適切に判読できることを確認してください。</span><span class="sxs-lookup"><span data-stu-id="0bb0c-164">If you select a custom accent color for your app, please make sure that text and backgrounds that use the accent color have sufficient contrast for optimal readability.</span></span> <span data-ttu-id="0bb0c-165">コントラストをテストするには、Windows の設定でカラー ピッカー ツールを使用するか、これらの[オンライン コントラスト ツール](https://www.w3.org/TR/WCAG20-TECHS/G18.html#G18-resources)を使用します。</span><span class="sxs-lookup"><span data-stu-id="0bb0c-165">To test contrast, you can use the color picker tool in Windows Settings, or you can use these [online contrast tools](https://www.w3.org/TR/WCAG20-TECHS/G18.html#G18-resources).</span></span>

![Windows の設定のアクセント カラー ピッカー](images/color/color-picker.svg)

## <a name="accent-color-palette"></a><span data-ttu-id="0bb0c-167">アクセント カラー パレット</span><span class="sxs-lookup"><span data-stu-id="0bb0c-167">Accent color palette</span></span>

<span data-ttu-id="0bb0c-168">Windows シェルのアクセント カラーのアルゴリズムによって、アクセント カラーの淡色と濃色の色調が生成されます。</span><span class="sxs-lookup"><span data-stu-id="0bb0c-168">An accent color algorithm in the Windows shell generates light and dark shades of the accent color.</span></span>

![アクセント カラー パレット](images/color/accent-color-palette.svg)

<span data-ttu-id="0bb0c-170">これらの色調には、以下の[テーマ リソース](../controls-and-patterns/xaml-theme-resources.md)としてアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="0bb0c-170">These shades can be accessed as [theme resources](../controls-and-patterns/xaml-theme-resources.md):</span></span>

- `SystemAccentColorLight3`
- `SystemAccentColorLight2`
- `SystemAccentColorLight1`
- `SystemAccentColorDark1`
- `SystemAccentColorDark2`
- `SystemAccentColorDark3`

<!-- check this is true -->
<span data-ttu-id="0bb0c-171">また [**UISettings.GetColorValue**](https://docs.microsoft.com/uwp/api/Windows.UI.ViewManagement.UISettings#Windows_UI_ViewManagement_UISettings_GetColorValue_Windows_UI_ViewManagement_UIColorType_) メソッドと [**UIColorType**](https://docs.microsoft.com/uwp/api/Windows.UI.ViewManagement.UIColorType) 列挙型を使って、プログラムによってアクセント カラー パレットにアクセスすることもできます。</span><span class="sxs-lookup"><span data-stu-id="0bb0c-171">You can also access the accent color palette programmatically with the [**UISettings.GetColorValue**](https://docs.microsoft.com/uwp/api/Windows.UI.ViewManagement.UISettings#Windows_UI_ViewManagement_UISettings_GetColorValue_Windows_UI_ViewManagement_UIColorType_) method and [**UIColorType**](https://docs.microsoft.com/uwp/api/Windows.UI.ViewManagement.UIColorType) enum.</span></span>

<span data-ttu-id="0bb0c-172">アクセント カラー パレットを使用して、アプリの色のテーマを設定できます。</span><span class="sxs-lookup"><span data-stu-id="0bb0c-172">You can use the accent color palette for color theming in your app.</span></span> <span data-ttu-id="0bb0c-173">以下では、ボタンに対してアクセント カラー パレットを使用する方法の例を示します。</span><span class="sxs-lookup"><span data-stu-id="0bb0c-173">Below is an example of how you can use the accent color palette on a button.</span></span>

![アクセント カラー パレットのボタンへの適用](images/color/color-theme-button.svg)

```xaml
<Page.Resources>
    <ResourceDictionary>
        <ResourceDictionary.ThemeDictionaries>
            <ResourceDictionary x:Key="Light">
                <SolidColorBrush x:Key="ButtonBackground" Color="{ThemeResource SystemAccentColor}"/>
                <SolidColorBrush x:Key="ButtonBackgroundPointerOver" Color="{ThemeResource SystemAccentColorLight1}"/>
                <SolidColorBrush x:Key="ButtonBackgroundPressed" Color="{ThemeResource SystemAccentColorDark1}"/>
            </ResourceDictionary>
        </ResourceDictionary.ThemeDictionaries>
    </ResourceDictionary>
</Page.Resources>

<Button Content="Button"></Button>
```

<span data-ttu-id="0bb0c-175">テキスト色と背景色の両方を設定する場合は、テキストと背景の間に十分なコントラストがあることを確認します。</span><span class="sxs-lookup"><span data-stu-id="0bb0c-175">When using colored text on a colored background, make sure there is enough contrast between text and background.</span></span> <span data-ttu-id="0bb0c-176">既定では、ハイパーリンクまたはハイパーテキストにはアクセント カラーが使用されます。</span><span class="sxs-lookup"><span data-stu-id="0bb0c-176">By default, hyperlink or hypertext will use the accent color.</span></span> <span data-ttu-id="0bb0c-177">背景にアクセント カラーのバリエーションを適用する場合は、元のアクセント カラーのバリエーションを使用して、背景色とテキスト色のコントラストを最適化します。</span><span class="sxs-lookup"><span data-stu-id="0bb0c-177">If you apply variations of the accent color to the background, you should use a variation of the original accent color to optimize the contrast of colored text on a colored background.</span></span>

<span data-ttu-id="0bb0c-178">以下の表は、さまざまな色調のアクセント カラーと、色付きの表面上での文字色の見え方の例を示します。</span><span class="sxs-lookup"><span data-stu-id="0bb0c-178">The chart below illustrates an example of the various light/dark shades of accent color, and how colored type can be applied on a colored surface.</span></span>

![色調の組み合わせ](images/color/color-on-color.svg)

<span data-ttu-id="0bb0c-180">コントロールのスタイルについて詳しくは、「[XAML スタイル](../controls-and-patterns/xaml-styles.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0bb0c-180">For more information about styling controls, see [XAML styles](../controls-and-patterns/xaml-styles.md).</span></span>

## <a name="color-api"></a><span data-ttu-id="0bb0c-181">色の API</span><span class="sxs-lookup"><span data-stu-id="0bb0c-181">Color API</span></span>

<span data-ttu-id="0bb0c-182">アプリケーションに色を追加できる API は複数存在します。</span><span class="sxs-lookup"><span data-stu-id="0bb0c-182">There are several APIs that can be used to add color to your application.</span></span> <span data-ttu-id="0bb0c-183">まず、[**Colors**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.colors) クラスを使用すると、多数の色があらかじめ定義された一覧を実装できます。</span><span class="sxs-lookup"><span data-stu-id="0bb0c-183">First, the [**Colors**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.colors) class, which implements a large list of predefined colors.</span></span> <span data-ttu-id="0bb0c-184">これらは、XAML プロパティを使用して自動的にアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="0bb0c-184">These can be accessed automatically with XAML properties.</span></span> <span data-ttu-id="0bb0c-185">以下の例では、ボタンを作成して、**Color** クラスのメンバーに背景色プロパティと前景色プロパティを設定しています。</span><span class="sxs-lookup"><span data-stu-id="0bb0c-185">In the example below, we create a button and set the background and foreground color properties to members of the **Colors** class.</span></span>

```xaml
<Button Background="MediumSlateBlue" Foreground="White">Button text</Button>
```

<span data-ttu-id="0bb0c-186">XAML で [**Color**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.color) 構造体を使用すると、RGB または 16 進数値によって独自の色を作成できます。</span><span class="sxs-lookup"><span data-stu-id="0bb0c-186">You can create your own colors from RGB or hex values using the [**Color**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.color) struct in XAML.</span></span>

```xaml
<Color x:Key="LightBlue">#FF36C0FF</Color>
```

<span data-ttu-id="0bb0c-187">また **FromArgb** メソッドを使用すると、コード内で同じ色を作成できます。</span><span class="sxs-lookup"><span data-stu-id="0bb0c-187">You can also create the same color in code by using the **FromArgb** method.</span></span>

```csharp
Color LightBlue = Color.FromArgb(255,54,192,255);
```

<span data-ttu-id="0bb0c-188">"Argb" という文字は、色の 4 つの構成要素であるアルファ (Alpha、不透明度)、赤 (Red)、緑 (Green)、青 (Blue) の頭文字です。</span><span class="sxs-lookup"><span data-stu-id="0bb0c-188">The letters "Argb" stands for Alpha (opacity), Red, Green, and Blue, which are the four components of a color.</span></span> <span data-ttu-id="0bb0c-189">各引数の設定可能な範囲は、0 ～ 255 です。</span><span class="sxs-lookup"><span data-stu-id="0bb0c-189">Each argument can range from 0 to 255.</span></span> <span data-ttu-id="0bb0c-190">最初の値は省略可能です。その場合、透明度が既定値の 255、つまり 100% 不透明に設定されます。</span><span class="sxs-lookup"><span data-stu-id="0bb0c-190">You can choose to omit the first value, which will give you a default opacity of 255, or 100% opaque.</span></span>

> [!Note]
> <span data-ttu-id="0bb0c-191">C++ を使用している場合、[**ColorHelper**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.colorhelper) クラスを使って色を作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0bb0c-191">If you're using C++, you must create colors by using the [**ColorHelper**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.colorhelper) class.</span></span>

<span data-ttu-id="0bb0c-192">**Color** は、UI 要素を単色で塗りつぶす [**SolidColorBrush**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.media.solidcolorbrush) の引数として使用されるのが最も一般的です。</span><span class="sxs-lookup"><span data-stu-id="0bb0c-192">The most common use for a **Color** is as an argument for a [**SolidColorBrush**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.media.solidcolorbrush), which can be used to paint UI elements a single solid color.</span></span> <span data-ttu-id="0bb0c-193">このようなブラシは、通常、[**ResourceDictionary**](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.ResourceDictionary) で定義されているため、複数の要素に再利用できます。</span><span class="sxs-lookup"><span data-stu-id="0bb0c-193">These brushes are generally defined in a [**ResourceDictionary**](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.ResourceDictionary), so they can be reused for multiple elements.</span></span>

```xaml
<ResourceDictionary>
    <SolidColorBrush x:Key="ButtonBackgroundBrush" Color="#FFFF4F67"/>
    <SolidColorBrush x:Key="ButtonForegroundBrush" Color="White"/>
</ResourceDictionary>
```

<span data-ttu-id="0bb0c-194">ブラシの使用方法について詳しくは、[XAML ブラシに関するページを](brushes.md)ご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0bb0c-194">For more information on how to use brushes, see [XAML brushes](brushes.md).</span></span>

## <a name="usability"></a><span data-ttu-id="0bb0c-195">ユーザビリティ</span><span class="sxs-lookup"><span data-stu-id="0bb0c-195">Usability</span></span>

<span data-ttu-id="0bb0c-196">:::row::: :::column::: ![コントラストの図](images/color/illo-contrast.svg) :::column-end::: :::column span="2"::: **コントラスト**</span><span class="sxs-lookup"><span data-stu-id="0bb0c-196">:::row::: :::column::: ![contrast illustration](images/color/illo-contrast.svg) :::column-end::: :::column span="2"::: **Contrast**</span></span>

        Make sure that elements and images have sufficient contrast to differentiate between them, regardless of the accent color or theme.

        When considering what colors to use in your application, accessiblity should be a primary concern. Use the guidance below to make sure your application is accessible to as many users as possible.
    :::column-end:::
<span data-ttu-id="0bb0c-197">:::row-end:::</span><span class="sxs-lookup"><span data-stu-id="0bb0c-197">:::row-end:::</span></span>

<span data-ttu-id="0bb0c-198">:::row::: :::column::: ![コントラストの図](images/color/illo-lighting.svg) :::column-end::: :::column span="2"::: **照明**</span><span class="sxs-lookup"><span data-stu-id="0bb0c-198">:::row::: :::column::: ![contrast illustration](images/color/illo-lighting.svg) :::column-end::: :::column span="2"::: **Lighting**</span></span>

        Be aware that variation in ambient lighting can affect the useability of your app. For example, a page with a black background might unreadable outside due to screen glare, while a page with a white background might be painful to look at in a dark room.
    :::column-end:::
<span data-ttu-id="0bb0c-199">:::row-end:::</span><span class="sxs-lookup"><span data-stu-id="0bb0c-199">:::row-end:::</span></span>

<span data-ttu-id="0bb0c-200">:::row::: :::column::: ![コントラストの図](images/color/illo-colorblindness.svg) :::column-end::: :::column span="2"::: **色覚障碍**</span><span class="sxs-lookup"><span data-stu-id="0bb0c-200">:::row::: :::column::: ![contrast illustration](images/color/illo-colorblindness.svg) :::column-end::: :::column span="2"::: **Colorblindness**</span></span>

        Be aware of how colorblindness could affect the useability of your application. For example, a user with red-green colorblindness will have difficulty distinguishing red and green elements from each other. About **8 percent of men** and **0.5 percent of women** are red-green colorblind, so avoid using these color combinations as the sole differentiator between application elements.
    :::column-end:::
<span data-ttu-id="0bb0c-201">:::row-end:::</span><span class="sxs-lookup"><span data-stu-id="0bb0c-201">:::row-end:::</span></span>

## <a name="related-articles"></a><span data-ttu-id="0bb0c-202">関連記事</span><span class="sxs-lookup"><span data-stu-id="0bb0c-202">Related articles</span></span>

- [<span data-ttu-id="0bb0c-203">XAML スタイル</span><span class="sxs-lookup"><span data-stu-id="0bb0c-203">XAML Styles</span></span>](../controls-and-patterns/xaml-styles.md)
- [<span data-ttu-id="0bb0c-204">XAML テーマ リソース</span><span class="sxs-lookup"><span data-stu-id="0bb0c-204">XAML Theme Resources</span></span>](../controls-and-patterns/xaml-theme-resources.md)