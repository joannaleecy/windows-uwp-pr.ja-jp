---
author: Jwmsft
description: UWP アプリでアクセント カラーとテーマを使用する方法について説明します。
title: UWP アプリでの色使い
ms.author: jimwalk
ms.date: 4/7/2018
ms.topic: article
keywords: Windows 10, UWP
design-contact: karenmui
ms.localizationpriority: medium
ms.openlocfilehash: cbc884fa3079eaa9db348de3430ed6d59d1e8a0d
ms.sourcegitcommit: f2c9a050a9137a473f28b613968d5782866142c6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/10/2018
ms.locfileid: "6265827"
---
# <a name="color"></a><span data-ttu-id="00708-104">色</span><span class="sxs-lookup"><span data-stu-id="00708-104">Color</span></span>

![ヒーロー イメージ](images/header-color.svg)

<span data-ttu-id="00708-106">色は、アプリの中でユーザーに情報を伝える直感的な方法です。操作可能な要素の強調、ユーザー操作に対するフィードバックの提供、インターフェイスの連続感の演出を色によって行うことができます。</span><span class="sxs-lookup"><span data-stu-id="00708-106">Color provides an intuitive way of communicating information to users in your app: it can be used to indicate interactivity, give feedback to user actions, and give your interface a sense of visual continuity.</span></span> 

<span data-ttu-id="00708-107">UWP アプリでの色使いは、主にアクセント カラーとテーマによって指定します。</span><span class="sxs-lookup"><span data-stu-id="00708-107">In UWP apps, colors are primarily determined by accent color and theme.</span></span> <span data-ttu-id="00708-108">この記事では、アプリで色を使用する方法と、アクセント カラーとテーマ リソースを使用して、任意のテーマに対応して UWP アプリを使用できるように設定する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="00708-108">In this article, we'll discuss how you can use color in your app, and how to use accent color and theme resources to make your UWP app usable in any theme context.</span></span> 

## <a name="color-principles"></a><span data-ttu-id="00708-109">色使いの原則</span><span class="sxs-lookup"><span data-stu-id="00708-109">Color principles</span></span>

:::row:::
    :::column:::
        **Use color meaningfully.**
        When color is used sparingly to highlight important elements, it can help create a user interface that is fluid and intuitive.
    :::column-end:::
    :::column:::
        **Use color to indicate interactivity.**
        It's a good idea to choose one color to indicate elements of your application that are interactive. For example, many web pages use blue text to denote a hyperlink.
    :::column-end:::
:::row-end:::

:::row:::
    :::column:::
        **Color is personal.**
        In Windows, users can choose an accent color and a light or dark theme, which are reflected throughout their experience. You can choose how to incorporate the user's accent color and theme into your application, personalizing their experience.
    :::column-end:::
    :::column:::
        **Color is cultural.**
        Consider how the colors you use will be interpreted by people from different cultures. For example, in some cultures the color blue is associated with virtue and protection, while in others it represents mourning.
    :::column-end:::
:::row-end:::

## <a name="themes"></a><span data-ttu-id="00708-110">テーマ</span><span class="sxs-lookup"><span data-stu-id="00708-110">Themes</span></span>

<span data-ttu-id="00708-111">UWP アプリでは、淡色または濃色のアプリケーション テーマを使用できます。</span><span class="sxs-lookup"><span data-stu-id="00708-111">UWP apps can use a light or dark application theme.</span></span> <span data-ttu-id="00708-112">テーマは、アプリの背景、テキスト、アイコン、[コモン コントロール](../controls-and-patterns/index.md) に反映されます。</span><span class="sxs-lookup"><span data-stu-id="00708-112">The theme affects the colors of the app's background, text, icons, and [common controls](../controls-and-patterns/index.md).</span></span>

### <a name="light-theme"></a><span data-ttu-id="00708-113">淡色テーマ</span><span class="sxs-lookup"><span data-stu-id="00708-113">Light theme</span></span>

![淡色テーマ](images/color/light-theme.svg)

### <a name="dark-theme"></a><span data-ttu-id="00708-115">濃色テーマ</span><span class="sxs-lookup"><span data-stu-id="00708-115">Dark theme</span></span>

![濃色テーマ](images/color/dark-theme.svg)

<span data-ttu-id="00708-117">既定では、UWP アプリのテーマは、ユーザーが Windows の設定で選択したテーマか、デバイスの既定のテーマ (XBox では黒など) に設定されます。</span><span class="sxs-lookup"><span data-stu-id="00708-117">By default, your UWP app's theme is the user’s theme preference from Windows Settings or the device's default theme (i.e., dark on XBox).</span></span> <span data-ttu-id="00708-118">ただし、開発者が UWP アプリのテーマを設定することもできます。</span><span class="sxs-lookup"><span data-stu-id="00708-118">However, you can set the theme for your UWP app.</span></span> 

### <a name="changing-the-theme"></a><span data-ttu-id="00708-119">テーマの変更</span><span class="sxs-lookup"><span data-stu-id="00708-119">Changing the theme</span></span>

<span data-ttu-id="00708-120">テーマを変更するには、`App.xaml` ファイルで **RequestedTheme** プロパティを変更します。</span><span class="sxs-lookup"><span data-stu-id="00708-120">You can change themes by changing the **RequestedTheme** property in your `App.xaml` file.</span></span>

```XAML
<Application
    x:Class="App9.App"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:local="using:App9"
    RequestedTheme="Dark">
</Application>
```

<span data-ttu-id="00708-121">**RequestedTheme** プロパティを削除すると、アプリケーションでユーザーのシステム設定が使用されるようになります。</span><span class="sxs-lookup"><span data-stu-id="00708-121">Removing the **RequestedTheme** property means that your application will use the user’s system settings.</span></span>

<span data-ttu-id="00708-122">ユーザーはまたハイ コントラスト テーマを使用することができます。これはインターフェイスを見やすくするために、コントラストの大きい、少数の色のパレットを使ったテーマです。</span><span class="sxs-lookup"><span data-stu-id="00708-122">Users can also select the high contrast theme, which uses a small palette of contrasting colors that makes the interface easier to see.</span></span> <span data-ttu-id="00708-123">ハイ コントラスト テーマを使用した場合、開発者が設定した RequestedTheme はシステムによって上書きされます。</span><span class="sxs-lookup"><span data-stu-id="00708-123">In that case, the system will override your RequestedTheme.</span></span>

### <a name="testing-themes"></a><span data-ttu-id="00708-124">テーマのテスト</span><span class="sxs-lookup"><span data-stu-id="00708-124">Testing themes</span></span>

<span data-ttu-id="00708-125">アプリのテーマを指定しない場合は、必ず淡色テーマと濃色テーマの両方でアプリをテストして、あらゆる条件でアプリが判読できることを確認します。</span><span class="sxs-lookup"><span data-stu-id="00708-125">If you don't request a theme for your app, make sure to test your app in both light and dark themes to ensure that your app will be legible in all conditions.</span></span>

<span data-ttu-id="00708-126">**注**: Visual Studio では、RequestedTheme の既定値が淡色に設定されているため、両方をテストするには、RequestedTheme を変更する必要があります。</span><span class="sxs-lookup"><span data-stu-id="00708-126">**Note**: In Visual Studio, the default RequestedTheme is light, so you'll need to change the RequestedTheme to test both.</span></span>

## <a name="theme-brushes"></a><span data-ttu-id="00708-127">テーマ ブラシ</span><span class="sxs-lookup"><span data-stu-id="00708-127">Theme brushes</span></span>

<span data-ttu-id="00708-128">コモン コントロールでは、[テーマ ブラシ](../controls-and-patterns/xaml-theme-resources.md#the-xaml-color-ramp-and-theme-dependent-brushes)が自動的に作動して、淡色テーマと濃色テーマのコントラストが調整されます。</span><span class="sxs-lookup"><span data-stu-id="00708-128">Common controls automatically use [theme brushes](../controls-and-patterns/xaml-theme-resources.md#the-xaml-color-ramp-and-theme-dependent-brushes) to adjust contrast for light and dark themes.</span></span>

<span data-ttu-id="00708-129">たとえば、[AutoSuggestBox](../controls-and-patterns/auto-suggest-box.md) でテーマ ブラシが使用される方法を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="00708-129">For example, here's an illustration of how the [AutoSuggestBox](../controls-and-patterns/auto-suggest-box.md) uses theme brushes:</span></span>

![テーマ ブラシ コントロールの例](images/color/theme-brushes.svg)

<span data-ttu-id="00708-131">テーマ ブラシは、以下の目的で使用されます。</span><span class="sxs-lookup"><span data-stu-id="00708-131">The theme brushes are used for the following purposes:</span></span>

- <span data-ttu-id="00708-132">**Base** はテキストの設定に使用されます。</span><span class="sxs-lookup"><span data-stu-id="00708-132">**Base** is for text.</span></span>
- <span data-ttu-id="00708-133">**Alt** は、Base の反転色の設定に使用されます。</span><span class="sxs-lookup"><span data-stu-id="00708-133">**Alt** is the inverse of Base.</span></span>
- <span data-ttu-id="00708-134">**Chrome**  は、最上位の要素 (ナビゲーション ウィンドウやコマンド バーなど) の設定に使用されます。</span><span class="sxs-lookup"><span data-stu-id="00708-134">**Chrome** is for top-level elements, such as navigation panes or command bars.</span></span>
- <span data-ttu-id="00708-135">**List** は、リスト コントロールの設定に使用されます。</span><span class="sxs-lookup"><span data-stu-id="00708-135">**List** is for list controls.</span></span>

<span data-ttu-id="00708-136">**Low**/**Medium**/**High** は色密度を指します。</span><span class="sxs-lookup"><span data-stu-id="00708-136">**Low**/**Medium**/**High** refer to the intensity of the color.</span></span>

### <a name="using-theme-brushes"></a><span data-ttu-id="00708-137">テーマ ブラシの使用</span><span class="sxs-lookup"><span data-stu-id="00708-137">Using theme brushes</span></span>

:::row:::
    :::column:::
        When creating templates for custom controls, use theme brushes rather than hard code color values. This way, your app can easily adapt to any theme.

        For example, these [item templates for ListView](../controls-and-patterns/item-templates-listview.md) demonstrate how to use theme brushes in a custom template.
    :::column-end:::
    :::column:::
         ![double line list item with icon example](images/color/list-view.svg)
    :::column-end:::
:::row-end:::

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

<span data-ttu-id="00708-138">アプリでテーマ ブラシを使用する方法について詳しくは、[テーマ リソースに関するページ](../controls-and-patterns/xaml-theme-resources.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="00708-138">For more information about how to use theme brushes in your app, see [Theme Resources](../controls-and-patterns/xaml-theme-resources.md).</span></span>

## <a name="accent-color"></a><span data-ttu-id="00708-139">アクセント カラー</span><span class="sxs-lookup"><span data-stu-id="00708-139">Accent color</span></span>

<span data-ttu-id="00708-140">コモン コントロールでは、アクセント カラーを使用して、状態情報を伝達します。</span><span class="sxs-lookup"><span data-stu-id="00708-140">Common controls use an accent color to convey state information.</span></span> <span data-ttu-id="00708-141">アクセント カラーは、既定では、ユーザーが設定で選択した `SystemAccentColor` が使用されます。</span><span class="sxs-lookup"><span data-stu-id="00708-141">By default, the accent color is the `SystemAccentColor` that users select in their Settings.</span></span> <span data-ttu-id="00708-142">ただし、組織のブランドを反映するように、アプリのアクセント カラーをカスタマイズすることもできます。</span><span class="sxs-lookup"><span data-stu-id="00708-142">However, you can also customize your app's accent color to reflect your brand.</span></span>

![Windows コントロール](images/color/windows-controls.svg)

:::row:::
    :::column:::
        ![user-selected accent header](images/color/user-accent.svg)
        ![user-selected accent color](images/color/user-selected-accent.svg)
    :::column-end:::
    :::column:::
        ![custom accent header](images/color/custom-accent.svg)
        ![custom brand accent color](images/color/brand-color.svg)
    :::column-end:::
:::row-end:::

### <a name="overriding-the-accent-color"></a><span data-ttu-id="00708-144">アクセント カラーの上書き</span><span class="sxs-lookup"><span data-stu-id="00708-144">Overriding the accent color</span></span>

<span data-ttu-id="00708-145">アプリのアクセント カラーを変更するには、次のコードを `app.xaml` に追加します。</span><span class="sxs-lookup"><span data-stu-id="00708-145">To change your app's accent color, place the following code in `app.xaml`.</span></span>

```xaml
<Application.Resources>
    <ResourceDictionary>
        <Color x:Key="SystemAccentColor">#107C10</Color>
    </ResourceDictionary>
</Application.Resources>
```

### <a name="choosing-an-accent-color"></a><span data-ttu-id="00708-146">アクセント カラーの選択</span><span class="sxs-lookup"><span data-stu-id="00708-146">Choosing an accent color</span></span>

<span data-ttu-id="00708-147">アプリに対してカスタムのアクセント カラーを選択した場合は、アクセント カラーを使用したテキストと背景との間に十分なコントラストがあり、テキストを適切に判読できることを確認してください。</span><span class="sxs-lookup"><span data-stu-id="00708-147">If you select a custom accent color for your app, please make sure that text and backgrounds that use the accent color have sufficient contrast for optimal readability.</span></span> <span data-ttu-id="00708-148">コントラストをテストするには、Windows の設定でカラー ピッカー ツールを使用するか、これらの[オンライン コントラスト ツール](https://www.w3.org/TR/WCAG20-TECHS/G18.html#G18-resources)を使用します。</span><span class="sxs-lookup"><span data-stu-id="00708-148">To test contrast, you can use the color picker tool in Windows Settings, or you can use these [online contrast tools](https://www.w3.org/TR/WCAG20-TECHS/G18.html#G18-resources).</span></span>

![Windows の設定のアクセント カラー ピッカー](images/color/color-picker.svg)

## <a name="accent-color-palette"></a><span data-ttu-id="00708-150">アクセント カラー パレット</span><span class="sxs-lookup"><span data-stu-id="00708-150">Accent color palette</span></span>

<span data-ttu-id="00708-151">Windows シェルのアクセント カラーのアルゴリズムによって、アクセント カラーの淡色と濃色の色調が生成されます。</span><span class="sxs-lookup"><span data-stu-id="00708-151">An accent color algorithm in the Windows shell generates light and dark shades of the accent color.</span></span>

![アクセント カラー パレット](images/color/accent-color-palette.svg)

<span data-ttu-id="00708-153">これらの色調には、以下の[テーマ リソース](../controls-and-patterns/xaml-theme-resources.md)としてアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="00708-153">These shades can be accessed as [theme resources](../controls-and-patterns/xaml-theme-resources.md):</span></span>

- `SystemAccentColorLight3`
- `SystemAccentColorLight2`
- `SystemAccentColorLight1`
- `SystemAccentColorDark1`
- `SystemAccentColorDark2`
- `SystemAccentColorDark3`

<!-- check this is true -->
<span data-ttu-id="00708-154">また [**UISettings.GetColorValue**](https://docs.microsoft.com/uwp/api/Windows.UI.ViewManagement.UISettings#Windows_UI_ViewManagement_UISettings_GetColorValue_Windows_UI_ViewManagement_UIColorType_) メソッドと [**UIColorType**](https://docs.microsoft.com/uwp/api/Windows.UI.ViewManagement.UIColorType) 列挙型を使って、プログラムによってアクセント カラー パレットにアクセスすることもできます。</span><span class="sxs-lookup"><span data-stu-id="00708-154">You can also access the accent color palette programmatically with the [**UISettings.GetColorValue**](https://docs.microsoft.com/uwp/api/Windows.UI.ViewManagement.UISettings#Windows_UI_ViewManagement_UISettings_GetColorValue_Windows_UI_ViewManagement_UIColorType_) method and [**UIColorType**](https://docs.microsoft.com/uwp/api/Windows.UI.ViewManagement.UIColorType) enum.</span></span>

<span data-ttu-id="00708-155">アクセント カラー パレットを使用して、アプリの色のテーマを設定できます。</span><span class="sxs-lookup"><span data-stu-id="00708-155">You can use the accent color palette for color theming in your app.</span></span> <span data-ttu-id="00708-156">以下では、ボタンに対してアクセント カラー パレットを使用する方法の例を示します。</span><span class="sxs-lookup"><span data-stu-id="00708-156">Below is an example of how you can use the accent color palette on a button.</span></span>

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

<span data-ttu-id="00708-158">テキスト色と背景色の両方を設定する場合は、テキストと背景の間に十分なコントラストがあることを確認します。</span><span class="sxs-lookup"><span data-stu-id="00708-158">When using colored text on a colored background, make sure there is enough contrast between text and background.</span></span> <span data-ttu-id="00708-159">既定では、ハイパーリンクまたはハイパーテキストにはアクセント カラーが使用されます。</span><span class="sxs-lookup"><span data-stu-id="00708-159">By default, hyperlink or hypertext will use the accent color.</span></span> <span data-ttu-id="00708-160">背景にアクセント カラーのバリエーションを適用する場合は、元のアクセント カラーのバリエーションを使用して、背景色とテキスト色のコントラストを最適化します。</span><span class="sxs-lookup"><span data-stu-id="00708-160">If you apply variations of the accent color to the background, you should use a variation of the original accent color to optimize the contrast of colored text on a colored background.</span></span>

<span data-ttu-id="00708-161">以下の表は、さまざまな色調のアクセント カラーと、色付きの表面上での文字色の見え方の例を示します。</span><span class="sxs-lookup"><span data-stu-id="00708-161">The chart below illustrates an example of the various light/dark shades of accent color, and how colored type can be applied on a colored surface.</span></span>

![色調の組み合わせ](images/color/color-on-color.svg)

<span data-ttu-id="00708-163">コントロールのスタイルについて詳しくは、「[XAML スタイル](../controls-and-patterns/xaml-styles.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="00708-163">For more information about styling controls, see [XAML styles](../controls-and-patterns/xaml-styles.md).</span></span>

## <a name="color-api"></a><span data-ttu-id="00708-164">色の API</span><span class="sxs-lookup"><span data-stu-id="00708-164">Color API</span></span>

<span data-ttu-id="00708-165">アプリケーションに色を追加できる API は複数存在します。</span><span class="sxs-lookup"><span data-stu-id="00708-165">There are several APIs that can be used to add color to your application.</span></span> <span data-ttu-id="00708-166">まず、[**Colors**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.colors) クラスを使用すると、多数の色があらかじめ定義された一覧を実装できます。</span><span class="sxs-lookup"><span data-stu-id="00708-166">First, the [**Colors**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.colors) class, which implements a large list of predefined colors.</span></span> <span data-ttu-id="00708-167">これらは、XAML プロパティを使用して自動的にアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="00708-167">These can be accessed automatically with XAML properties.</span></span> <span data-ttu-id="00708-168">以下の例では、ボタンを作成して、**Color** クラスのメンバーに背景色プロパティと前景色プロパティを設定しています。</span><span class="sxs-lookup"><span data-stu-id="00708-168">In the example below, we create a button and set the background and foreground color properties to members of the **Colors** class.</span></span>

```xaml
<Button Background="MediumSlateBlue" Foreground="White">Button text</Button>
```

<span data-ttu-id="00708-169">XAML で [**Color**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.color) 構造体を使用すると、RGB または 16 進数値によって独自の色を作成できます。</span><span class="sxs-lookup"><span data-stu-id="00708-169">You can create your own colors from RGB or hex values using the [**Color**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.color) struct in XAML.</span></span>

```xaml
<Color x:Key="LightBlue">#FF36C0FF</Color>
```

<span data-ttu-id="00708-170">また **FromArgb** メソッドを使用すると、コード内で同じ色を作成できます。</span><span class="sxs-lookup"><span data-stu-id="00708-170">You can also create the same color in code by using the **FromArgb** method.</span></span>

```csharp
Color LightBlue = Color.FromArgb(255,54,192,255);
```

<span data-ttu-id="00708-171">"Argb" という文字は、色の 4 つの構成要素であるアルファ (Alpha、不透明度)、赤 (Red)、緑 (Green)、青 (Blue) の頭文字です。</span><span class="sxs-lookup"><span data-stu-id="00708-171">The letters "Argb" stands for Alpha (opacity), Red, Green, and Blue, which are the four components of a color.</span></span> <span data-ttu-id="00708-172">各引数の設定可能な範囲は、0 ～ 255 です。</span><span class="sxs-lookup"><span data-stu-id="00708-172">Each argument can range from 0 to 255.</span></span> <span data-ttu-id="00708-173">最初の値は省略可能です。その場合、透明度が既定値の 255、つまり 100% 不透明に設定されます。</span><span class="sxs-lookup"><span data-stu-id="00708-173">You can choose to omit the first value, which will give you a default opacity of 255, or 100% opaque.</span></span>

> [!Note]
> <span data-ttu-id="00708-174">C++ を使用している場合、[**ColorHelper**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.colorhelper) クラスを使って色を作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="00708-174">If you're using C++, you must create colors by using the [**ColorHelper**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.colorhelper) class.</span></span>

<span data-ttu-id="00708-175">**Color** は、UI 要素を単色で塗りつぶす [**SolidColorBrush**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.media.solidcolorbrush) の引数として使用されるのが最も一般的です。</span><span class="sxs-lookup"><span data-stu-id="00708-175">The most common use for a **Color** is as an argument for a [**SolidColorBrush**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.media.solidcolorbrush), which can be used to paint UI elements a single solid color.</span></span> <span data-ttu-id="00708-176">このようなブラシは、通常、[**ResourceDictionary**](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.ResourceDictionary) で定義されているため、複数の要素に再利用できます。</span><span class="sxs-lookup"><span data-stu-id="00708-176">These brushes are generally defined in a [**ResourceDictionary**](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.ResourceDictionary), so they can be reused for multiple elements.</span></span>

```xaml
<ResourceDictionary>
    <SolidColorBrush x:Key="ButtonBackgroundBrush" Color="#FFFF4F67"/>
    <SolidColorBrush x:Key="ButtonForegroundBrush" Color="White"/>
</ResourceDictionary>
```

<span data-ttu-id="00708-177">ブラシの使用方法について詳しくは、[XAML ブラシに関するページを](brushes.md)ご覧ください。</span><span class="sxs-lookup"><span data-stu-id="00708-177">For more information on how to use brushes, see [XAML brushes](brushes.md).</span></span>

## <a name="scoping-system-colors"></a><span data-ttu-id="00708-178">システム カラーのスコープを設定します。</span><span class="sxs-lookup"><span data-stu-id="00708-178">Scoping system colors</span></span>

<span data-ttu-id="00708-179">だけでなく、アプリでは、独自の色を定義するもスコープを設定できます、systematized の色を目的の地域をアプリ全体で**ColorSchemeResources**タグを使用しています。</span><span class="sxs-lookup"><span data-stu-id="00708-179">In addition to defining your own colors in your app, you can also scope our systematized colors to desired regions throughout your app by using the **ColorSchemeResources** tag.</span></span> <span data-ttu-id="00708-180">この API を使用するだけでなく、色を付けるし、独自のカスタムの色を手動で定義では一度にいくつかのプロパティも提供するその他の多くのシステムのメリットを設定することでコントロールのテーマの大規模なグループを取得通常はありません。</span><span class="sxs-lookup"><span data-stu-id="00708-180">This API allows you to not only colorize and theme large groups of controls at once by setting a few properties, but also gives you many other system benefits that you wouldn't normally get with defining your own custom colors manually:</span></span>

- <span data-ttu-id="00708-181">任意のカラー **ColorSchemeResources**を使用して設定には、ハイ コントラストは変わりません。</span><span class="sxs-lookup"><span data-stu-id="00708-181">Any color set using **ColorSchemeResources** will not effect High Contrast</span></span>
  * <span data-ttu-id="00708-182">つまり、アプリはその他の設計やデベロッパー コストを加えなくても多くのユーザーにアクセスできなくなります</span><span class="sxs-lookup"><span data-stu-id="00708-182">Meaning your app will be accessible to more people without any additional design or dev cost</span></span>
- <span data-ttu-id="00708-183">簡単に設定できます色ライト、濃色テーマまたは広範囲に両方のテーマで API を 1 つのプロパティを設定して</span><span class="sxs-lookup"><span data-stu-id="00708-183">Can easily set colors to Light, Dark or pervasive across both themes by setting one property on the API</span></span>
- <span data-ttu-id="00708-184">**ColorSchemeResources**の設定の色、そのシステム カラーを使用するすべてのようなコントロールに伝播します。</span><span class="sxs-lookup"><span data-stu-id="00708-184">Colors set on **ColorSchemeResources** will cascade down to all similar controls that also use that system color</span></span>
  * <span data-ttu-id="00708-185">これにより、一貫した色ストーリー ブランドの外観を維持しながら、アプリ間でがされます。</span><span class="sxs-lookup"><span data-stu-id="00708-185">This ensures that you will have a consistent color story across your app while maintaining the look of your brand</span></span>
- <span data-ttu-id="00708-186">テンプレートを再適用することがなく、すべての表示状態、アニメーション、不透明度のバリエーションを効果します。</span><span class="sxs-lookup"><span data-stu-id="00708-186">Effects all visual states, animations and opacity variations without needing to re-template</span></span>

### <a name="how-to-use-colorschemeresources"></a><span data-ttu-id="00708-187">ColorSchemeResources を使用する方法</span><span class="sxs-lookup"><span data-stu-id="00708-187">How to use ColorSchemeResources</span></span>

<span data-ttu-id="00708-188">ColorSchemeResources は、どのようなリソースがされているシステムの場所のスコープを指示する API です。</span><span class="sxs-lookup"><span data-stu-id="00708-188">ColorSchemeResources is an API that tells the system what resources are being scoped where.</span></span> <span data-ttu-id="00708-189">ColorSchemeResources、 [X:key](https://docs.microsoft.com/windows/uwp/xaml-platform/x-key-attribute)ことができる 3 つの選択肢のいずれかを実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="00708-189">ColorSchemeResources must take an [x:Key](https://docs.microsoft.com/windows/uwp/xaml-platform/x-key-attribute), that can be one of three choices:</span></span>
- <span data-ttu-id="00708-190">既定値</span><span class="sxs-lookup"><span data-stu-id="00708-190">Default</span></span>
  * <span data-ttu-id="00708-191">[淡色](https://docs.microsoft.com/windows/uwp/design/style/color#light-theme)と[濃色](https://docs.microsoft.com/windows/uwp/design/style/color#dark-theme)テーマの色の変更を表示します。</span><span class="sxs-lookup"><span data-stu-id="00708-191">Will show your color changes in both [Light](https://docs.microsoft.com/windows/uwp/design/style/color#light-theme) and [Dark](https://docs.microsoft.com/windows/uwp/design/style/color#dark-theme) theme</span></span>
- <span data-ttu-id="00708-192">Light</span><span class="sxs-lookup"><span data-stu-id="00708-192">Light</span></span>
  * <span data-ttu-id="00708-193">色の変更が[淡色テーマ](https://docs.microsoft.com/windows/uwp/design/style/color#light-theme)でのみ表示されます。</span><span class="sxs-lookup"><span data-stu-id="00708-193">Will show your color changes only in [Light theme](https://docs.microsoft.com/windows/uwp/design/style/color#light-theme)</span></span> 
- <span data-ttu-id="00708-194">Dark</span><span class="sxs-lookup"><span data-stu-id="00708-194">Dark</span></span>
  * <span data-ttu-id="00708-195">[濃色テーマ](https://docs.microsoft.com/windows/uwp/design/style/color#dark-theme)でのみ、色の変更が表示されます。</span><span class="sxs-lookup"><span data-stu-id="00708-195">Will show your color changes only in [Dark theme](https://docs.microsoft.com/windows/uwp/design/style/color#dark-theme)</span></span>

<span data-ttu-id="00708-196">その X:key の設定によりシステムまたはアプリのテーマに色を適切に変更するテーマのいずれかで異なる独自の外観をする必要があります。</span><span class="sxs-lookup"><span data-stu-id="00708-196">Setting that x:Key will ensure that your colors change appropriately to the system or app theme, should you want a different custom appearance when in either theme.</span></span>

### <a name="how-to-apply-scoped-colors"></a><span data-ttu-id="00708-197">スコープ指定された色を適用する方法</span><span class="sxs-lookup"><span data-stu-id="00708-197">How to apply scoped colors</span></span>

<span data-ttu-id="00708-198">によって、 **ColorSchemeResources** API では、XAML リソースのスコープを設定するには、システム カラーまたは[テーマ リソース](https://docs.microsoft.com/windows/uwp/design/controls-and-patterns/xaml-theme-resources)ライブラリでは、ページまたはコンテナーのスコープ内でそれらを再定義できる、ブラシを実行することができます。</span><span class="sxs-lookup"><span data-stu-id="00708-198">Scoping resources through the **ColorSchemeResources** API in XAML allows you to take any system color or brush that's in our [theme resources](https://docs.microsoft.com/windows/uwp/design/controls-and-patterns/xaml-theme-resources) library and redefine them within the scope of a page or container.</span></span>

<span data-ttu-id="00708-199">たとえば、2 つのシステム カラー - **SystemBaseLowColor**および**SystemBaseMediumLowColor**グリッド内で定義されているし、ページの 2 つのボタンを配置する場合: そのグリッド内の 1 つと 1 つの外側。</span><span class="sxs-lookup"><span data-stu-id="00708-199">For example, if you defined two system colors - **SystemBaseLowColor** and **SystemBaseMediumLowColor** inside a grid, and then placed two buttons on your page: one inside that grid, and one outside:</span></span>

```xaml
<Grid x:Name="Grid_A">
    <Grid.Resources>
        <ColorSchemeResources x:Key="Default" 
        SystemBaseLowColor="LightGreen" 
        SystemBaseMediumLowColor="DarkCyan"/>
    </Grid.Resources>

    <Buton Content="Button_A"/>
</Grid>
<Buton Content="Button_B"/>
```

<span data-ttu-id="00708-200">**Button_A**適用されている新しい色を取得して、システムの既定のボタンのように見えるまま**Button_B** :</span><span class="sxs-lookup"><span data-stu-id="00708-200">You would get **Button_A** with the applied new colors, and **Button_B** would remain looking like our system default button:</span></span>

![スコープ指定されたシステムのボタンの色](images/color/scopedcolors_cyan_button.png)

<span data-ttu-id="00708-202">ただし、ため、すべてのシステム色に伝播他のコントロールも、 **SystemBaseLowColor**と**SystemBaseMediumLowColor**設定は、影響ボタンだけで。</span><span class="sxs-lookup"><span data-stu-id="00708-202">However, since all our system colors cascade down to other controls too, setting **SystemBaseLowColor** and **SystemBaseMediumLowColor** will affect more than just buttons.</span></span> <span data-ttu-id="00708-203">この場合、制御**ToggleButton**、 **RadioButton**と**スライダー**も影響を受けるこれらのシステム色の変更によってようにそれらのコントロールを配置する exampl グリッドのスコープの上します。</span><span class="sxs-lookup"><span data-stu-id="00708-203">In this case, controls like **ToggleButton**, **RadioButton** and **Slider** will also be effected by these system color changes, should those controls be put in above exampl grid's scope.</span></span>
<span data-ttu-id="00708-204">スコープ、システムの色の変更*に 1 つのコントロールだけに*する場合は、そのコントロールのリソース内で**ColorSchemeResources**を定義することによってためを実行できます。</span><span class="sxs-lookup"><span data-stu-id="00708-204">If you wish to scope a system color change *to a single controls only* you can do so by defining **ColorSchemeResources** within that control's resources:</span></span>

```xaml
<Grid x:Name="Grid_A">
    <Button Content="Button_A">
        <Button.Resources>
            <ColorSchemeResources x:Key="Default" 
                SystemBaseLowColor="LightGreen" 
                SystemBaseMediumLowColor="DarkCyan"/>
        </Button.Resources>
    </Button>
</Grid>
<Button Content="Button_B"/>
```
<span data-ttu-id="00708-205">基本的にする前とまったく同じものがある場合も、色の変更をグリッドに追加されたその他の任意のコントロールを選択してができるようになりました。</span><span class="sxs-lookup"><span data-stu-id="00708-205">You essentially have the exact same thing as before, but now any other controls added to the grid will not pick up the color changes.</span></span> <span data-ttu-id="00708-206">これは、ため、これらのシステム色のスコープは**Button_A**のみです。</span><span class="sxs-lookup"><span data-stu-id="00708-206">This is because those system colors are scoped to **Button_A** only.</span></span>

### <a name="nesting-scoped-resources"></a><span data-ttu-id="00708-207">スコープ入れ子リソース</span><span class="sxs-lookup"><span data-stu-id="00708-207">Nesting scoped resources</span></span>

<span data-ttu-id="00708-208">システム カラーを入れ子に可能であればとも**ColorSchemeResources**をアプリのレイアウトのマークアップ内で入れ子になった要素のリソースに配置することで操作が完了です。</span><span class="sxs-lookup"><span data-stu-id="00708-208">Nesting system colors is also possible, and is done so by placing **ColorSchemeResources** in the nested elements' resources within the markup of your app layout:</span></span>

```xaml
<Grid x:Name="Grid_A">
    <Grid.Resources>
        <ColorSchemeResources x:Key="Default"
            SystemBaseLowColor="LightGreen"
            SystemBaseMediumLowColor="DarkCyan"/>
    </Grid.Resources>

    <Button Content="Button_A"/>
    <Grid x:Name="Grid_B">
        <Grid.Resources>
            <ColorSchemeResources x:Key="Default"
                SystemBaseLowColor="Goldenrod"
                SystemBaseMediumLowColor="DarkGoldenrod"/>
        </Grid.Resources>

        <Button Content="Nested Button"/>
    </Grid>
</Grid>
```

<span data-ttu-id="00708-209">この例では**Button_A**が継承する**Grid_A**をリソースに色を定義し、**入れ子になったボタン**が**Grid_B**をリソースからの色を継承します。</span><span class="sxs-lookup"><span data-stu-id="00708-209">In this example, **Button_A** is inheriting colors define in **Grid_A**'s resources, and **Nested Button** is inheriting colors from **Grid_B**'s resources.</span></span> <span data-ttu-id="00708-210">何も表示されない場合、最後に、既定の色を適用することが定義されていると拡張機能によって**Grid_B**内の他の任意のコントロールを配置することを意味が確認するかを確認または**Grid_A**をのリソースを適用する前にまず、 **Grid_B**をリソースを適用しますページまたはアプリ レベルです。</span><span class="sxs-lookup"><span data-stu-id="00708-210">By extension, this means that any other controls placed within **Grid_B** will check or apply **Grid_B**'s resources first, before checking or applying **Grid_A**'s resources, and finally applying our default colors if nothing is defined at the page or app level.</span></span>

<span data-ttu-id="00708-211">これは、さまざまなリソースを含む色の定義がある入れ子になった要素で機能します。</span><span class="sxs-lookup"><span data-stu-id="00708-211">This works for any number of nested elements whose resources have color definitions.</span></span>

### <a name="scoping-with-a-resourcedictionary"></a><span data-ttu-id="00708-212">ResourceDictionary のスコープを設定します。</span><span class="sxs-lookup"><span data-stu-id="00708-212">Scoping with a ResourceDictionary</span></span>

<span data-ttu-id="00708-213">コンテナーや、ページのリソースに制限されませんし、マージすることによって、スコープでディクショナリ マージは通常の方法の ResourceDictionary にこれらのシステム色を定義することもできます。</span><span class="sxs-lookup"><span data-stu-id="00708-213">You are not limited to a container or page’s resources, and can also define these system colors in a ResourceDictionary that can then be merged at any scope the way you normally would merge a dictionary.</span></span>

#### <a name="mycustomthemexaml"></a><span data-ttu-id="00708-214">MyCustomTheme.xaml</span><span class="sxs-lookup"><span data-stu-id="00708-214">MyCustomTheme.xaml</span></span>

<span data-ttu-id="00708-215">まず、ResourceDictionary を作成します。</span><span class="sxs-lookup"><span data-stu-id="00708-215">First, you would create a ResourceDictionary.</span></span> <span data-ttu-id="00708-216">**ColorSchemeResources** ThemeDictionaries 内に配置し、目的のシステム カラーを上書きします。</span><span class="sxs-lookup"><span data-stu-id="00708-216">Then place the **ColorSchemeResources** within the ThemeDictionaries and override the desired system colors:</span></span>

```xaml
<ResourceDictionary
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation" 
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:local="using:TestApp">

    <ResourceDictionary.ThemeDictionaries>

        <ColorSchemeResources x:Key="Default"
            SystemBaseLowColor="LightGreen"
            SystemBaseMediumLowColor="DarkCyan"/>
        
    </ResourceDictionary.ThemeDictionaries>
</ResourceDictionary>
```

#### <a name="mainpagexaml"></a><span data-ttu-id="00708-217">MainPage.xaml</span><span class="sxs-lookup"><span data-stu-id="00708-217">MainPage.xaml</span></span>

<span data-ttu-id="00708-218">レイアウトが含まれているページで、目的のスコープにでは、そのディクショナリをマージだけです。</span><span class="sxs-lookup"><span data-stu-id="00708-218">On the page containing your layout, simply merge that dictionary in at the scope you want:</span></span>

```xaml
<Grid x:Name="Grid_A">
    <Grid.Resources>
            <ResourceDictionary>
                <ResourceDictionary.MergedDictionaries>
                    <ResourceDictionary Source="MyCustomTheme.xaml"/>
                </ResourceDictionary.MergedDictionaries>
            </ResourceDictionary>
    </Grid.Resources>
             
    <Button Content="Button_A"/>
</Grid>
```

<span data-ttu-id="00708-219">これで、すべてのリソース、テーマおよびカスタムの色は 1 つの**MyCustomTheme**リソース ディクショナリに格納される、レイアウトのマークアップで余分ななくすについて心配しなくても必要となるスコープします。</span><span class="sxs-lookup"><span data-stu-id="00708-219">Now, all resources, theming, and custom colors can be placed in a single **MyCustomTheme** resource dictionary and scoped where needed without having to worry about extra clutter in your layout markup.</span></span>

### <a name="other-ways-to-define-color-resources"></a><span data-ttu-id="00708-220">カラー リソースを定義する他の方法</span><span class="sxs-lookup"><span data-stu-id="00708-220">Other ways to define color resources</span></span>

<span data-ttu-id="00708-221">ColorSchemeResources に配置されるシステム カラーと行ではなく、ラッパーとして直接内で定義することもできます。</span><span class="sxs-lookup"><span data-stu-id="00708-221">ColorSchemeResources also allows for system colors to be placed and defining directly within it as a wrapper, rather than in line:</span></span>

``` xaml
<ColorSchemeResources x:Key="Dark">
    <Color x:Key="SystemBaseLowColor">Goldenrod</Color>
</ColorSchemeResources>
```

## <a name="usability"></a><span data-ttu-id="00708-222">ユーザビリティ</span><span class="sxs-lookup"><span data-stu-id="00708-222">Usability</span></span>

:::row:::
    :::column:::
        ![contrast illustration](images/color/illo-contrast.svg)
    :::column-end:::
    :::column span="2":::
        **Contrast**

        Make sure that elements and images have sufficient contrast to differentiate between them, regardless of the accent color or theme.

        When considering what colors to use in your application, accessiblity should be a primary concern. Use the guidance below to make sure your application is accessible to as many users as possible.
    :::column-end:::
:::row-end:::

:::row:::
    :::column:::
        ![contrast illustration](images/color/illo-lighting.svg)
    :::column-end:::
    :::column span="2":::
        **Lighting**

        Be aware that variation in ambient lighting can affect the useability of your app. For example, a page with a black background might unreadable outside due to screen glare, while a page with a white background might be painful to look at in a dark room.
    :::column-end:::
:::row-end:::

:::row:::
    :::column:::
        ![contrast illustration](images/color/illo-colorblindness.svg)
    :::column-end:::
    :::column span="2":::
        **Colorblindness**

        Be aware of how colorblindness could affect the useability of your application. For example, a user with red-green colorblindness will have difficulty distinguishing red and green elements from each other. About **8 percent of men** and **0.5 percent of women** are red-green colorblind, so avoid using these color combinations as the sole differentiator between application elements.
    :::column-end:::
:::row-end:::

## <a name="related-articles"></a><span data-ttu-id="00708-223">関連記事</span><span class="sxs-lookup"><span data-stu-id="00708-223">Related articles</span></span>

- [<span data-ttu-id="00708-224">XAML スタイル</span><span class="sxs-lookup"><span data-stu-id="00708-224">XAML Styles</span></span>](../controls-and-patterns/xaml-styles.md)
- [<span data-ttu-id="00708-225">XAML テーマ リソース</span><span class="sxs-lookup"><span data-stu-id="00708-225">XAML Theme Resources</span></span>](../controls-and-patterns/xaml-theme-resources.md)