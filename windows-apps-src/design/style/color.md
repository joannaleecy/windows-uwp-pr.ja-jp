---
author: QuinnRadich
description: UWP アプリでアクセント カラーとテーマを使用する方法について説明します。
title: UWP アプリでの色使い
ms.author: quradic
ms.date: 4/7/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
design-contact: karenmui
ms.localizationpriority: medium
ms.openlocfilehash: 19f4d9cde6ee2bc9615f044f18bc5e8828ca1985
ms.sourcegitcommit: 9e2c34a5ed3134aeca7eb9490f05b20eb9a3e5df
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/17/2018
ms.locfileid: "3983425"
---
# <a name="color"></a>色

![ヒーロー イメージ](images/header-color.svg)

色は、アプリの中でユーザーに情報を伝える直感的な方法です。操作可能な要素の強調、ユーザー操作に対するフィードバックの提供、インターフェイスの連続感の演出を色によって行うことができます。 

UWP アプリでの色使いは、主にアクセント カラーとテーマによって指定します。 この記事では、アプリで色を使用する方法と、アクセント カラーとテーマ リソースを使用して、任意のテーマに対応して UWP アプリを使用できるように設定する方法について説明します。 

## <a name="color-principles"></a>色使いの原則

:::row:::
    :::column:::
        **なくした色を使用します。**
重要な要素が強調されるように控え目に色を使用すると、柔軟で直感的なユーザー インターフェイスの作成に役立ちます。
    :::column-end:::
    :::column:::
        **色を使用して、対話機能を示します。**
アプリケーションの中で、操作の対象要素を示す色を 1 つ決めておくことをお勧めします。 たとえば、多くの Web ページでは、ハイパーリンクを示すために青色のテキストを使用しています。
    :::column-end:::
:::row-end:::

:::row:::
    :::column:::
        **色は、個人です。**
Windows では、ユーザーがアクセント カラーや淡色/濃色のテーマを選んで、各自のエクスペリエンス全体に適用できます。 開発者は、ユーザーが選んだアクセント カラーとテーマをどのようにアプリケーションに組み込んで、個人に応じたエクスペリエンスを提供するかを選択できます。
    :::column-end:::
    :::column:::
        **色は文化によって異なります。**
アプリで使用する色が、異なる文化圏のユーザーにどのように解釈されるかを考慮してください。 たとえば、文化によっては、青が美徳と保護を表すこともあれば、服喪を連想させることもあります。
    :::column-end:::
:::row-end:::

## <a name="themes"></a>テーマ

UWP アプリでは、淡色または濃色のアプリケーション テーマを使用できます。 テーマは、アプリの背景、テキスト、アイコン、[コモン コントロール](../controls-and-patterns/index.md) に反映されます。

### <a name="light-theme"></a>淡色テーマ

![淡色テーマ](images/color/light-theme.svg)

### <a name="dark-theme"></a>濃色テーマ

![濃色テーマ](images/color/dark-theme.svg)

既定では、UWP アプリのテーマは、ユーザーが Windows の設定で選択したテーマか、デバイスの既定のテーマ (XBox では黒など) に設定されます。 ただし、開発者が UWP アプリのテーマを設定することもできます。 

### <a name="changing-the-theme"></a>テーマの変更

テーマを変更するには、`App.xaml` ファイルで **RequestedTheme** プロパティを変更します。

```XAML
<Application
    x:Class="App9.App"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:local="using:App9"
    RequestedTheme="Dark">
</Application>
```

**RequestedTheme** プロパティを削除すると、アプリケーションでユーザーのシステム設定が使用されるようになります。

ユーザーはまたハイ コントラスト テーマを使用することができます。これはインターフェイスを見やすくするために、コントラストの大きい、少数の色のパレットを使ったテーマです。 ハイ コントラスト テーマを使用した場合、開発者が設定した RequestedTheme はシステムによって上書きされます。

### <a name="testing-themes"></a>テーマのテスト

アプリのテーマを指定しない場合は、必ず淡色テーマと濃色テーマの両方でアプリをテストして、あらゆる条件でアプリが判読できることを確認します。

**注**: Visual Studio では、RequestedTheme の既定値が淡色に設定されているため、両方をテストするには、RequestedTheme を変更する必要があります。

## <a name="theme-brushes"></a>テーマ ブラシ

コモン コントロールでは、[テーマ ブラシ](../controls-and-patterns/xaml-theme-resources.md#the-xaml-color-ramp-and-theme-dependent-brushes)が自動的に作動して、淡色テーマと濃色テーマのコントラストが調整されます。

たとえば、[AutoSuggestBox](../controls-and-patterns/auto-suggest-box.md) でテーマ ブラシが使用される方法を以下に示します。

![テーマ ブラシ コントロールの例](images/color/theme-brushes.svg)

テーマ ブラシは、以下の目的で使用されます。

- **Base** はテキストの設定に使用されます。
- **Alt** は、Base の反転色の設定に使用されます。
- **Chrome**  は、最上位の要素 (ナビゲーション ウィンドウやコマンド バーなど) の設定に使用されます。
- **List** は、リスト コントロールの設定に使用されます。

**Low**/**Medium**/**High** は色密度を指します。

### <a name="using-theme-brushes"></a>テーマ ブラシの使用

:::row:::
    :::column:::
        カスタム コントロールのテンプレートを作成するときは、色の値をハード コードではなく、テーマ ブラシを使用します。 これにより、アプリがあらゆるテーマに容易に適応できるようになります。

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

アプリでテーマ ブラシを使用する方法について詳しくは、[テーマ リソースに関するページ](../controls-and-patterns/xaml-theme-resources.md)をご覧ください。

## <a name="accent-color"></a>アクセント カラー

コモン コントロールでは、アクセント カラーを使用して、状態情報を伝達します。 アクセント カラーは、既定では、ユーザーが設定で選択した `SystemAccentColor` が使用されます。 ただし、組織のブランドを反映するように、アプリのアクセント カラーをカスタマイズすることもできます。

![Windows コントロール](images/color/windows-controls.svg)

:::row:::
    :::column:::
        ![ユーザーが選択したアクセント ヘッダー](images/color/user-accent.svg) ![ユーザーが選択したアクセント カラー](images/color/user-selected-accent.svg)
    :::column-end:::
    :::column:::
        ![カスタムのアクセント ヘッダー](images/color/custom-accent.svg) ![カスタムのブランド アクセント カラー](images/color/brand-color.svg)
    :::column-end:::
:::row-end:::

### <a name="overriding-the-accent-color"></a>アクセント カラーの上書き

アプリのアクセント カラーを変更するには、次のコードを `app.xaml` に追加します。

```xaml
<Application.Resources>
    <ResourceDictionary>
        <Color x:Key="SystemAccentColor">#107C10</Color>
    </ResourceDictionary>
</Application.Resources>
```

### <a name="choosing-an-accent-color"></a>アクセント カラーの選択

アプリに対してカスタムのアクセント カラーを選択した場合は、アクセント カラーを使用したテキストと背景との間に十分なコントラストがあり、テキストを適切に判読できることを確認してください。 コントラストをテストするには、Windows の設定でカラー ピッカー ツールを使用するか、これらの[オンライン コントラスト ツール](https://www.w3.org/TR/WCAG20-TECHS/G18.html#G18-resources)を使用します。

![Windows の設定のアクセント カラー ピッカー](images/color/color-picker.svg)

## <a name="accent-color-palette"></a>アクセント カラー パレット

Windows シェルのアクセント カラーのアルゴリズムによって、アクセント カラーの淡色と濃色の色調が生成されます。

![アクセント カラー パレット](images/color/accent-color-palette.svg)

これらの色調には、以下の[テーマ リソース](../controls-and-patterns/xaml-theme-resources.md)としてアクセスできます。

- `SystemAccentColorLight3`
- `SystemAccentColorLight2`
- `SystemAccentColorLight1`
- `SystemAccentColorDark1`
- `SystemAccentColorDark2`
- `SystemAccentColorDark3`

<!-- check this is true -->
また [**UISettings.GetColorValue**](https://docs.microsoft.com/uwp/api/Windows.UI.ViewManagement.UISettings#Windows_UI_ViewManagement_UISettings_GetColorValue_Windows_UI_ViewManagement_UIColorType_) メソッドと [**UIColorType**](https://docs.microsoft.com/uwp/api/Windows.UI.ViewManagement.UIColorType) 列挙型を使って、プログラムによってアクセント カラー パレットにアクセスすることもできます。

アクセント カラー パレットを使用して、アプリの色のテーマを設定できます。 以下では、ボタンに対してアクセント カラー パレットを使用する方法の例を示します。

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

テキスト色と背景色の両方を設定する場合は、テキストと背景の間に十分なコントラストがあることを確認します。 既定では、ハイパーリンクまたはハイパーテキストにはアクセント カラーが使用されます。 背景にアクセント カラーのバリエーションを適用する場合は、元のアクセント カラーのバリエーションを使用して、背景色とテキスト色のコントラストを最適化します。

以下の表は、さまざまな色調のアクセント カラーと、色付きの表面上での文字色の見え方の例を示します。

![色調の組み合わせ](images/color/color-on-color.svg)

コントロールのスタイルについて詳しくは、「[XAML スタイル](../controls-and-patterns/xaml-styles.md)」をご覧ください。

## <a name="color-api"></a>色の API

アプリケーションに色を追加できる API は複数存在します。 まず、[**Colors**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.colors) クラスを使用すると、多数の色があらかじめ定義された一覧を実装できます。 これらは、XAML プロパティを使用して自動的にアクセスできます。 以下の例では、ボタンを作成して、**Color** クラスのメンバーに背景色プロパティと前景色プロパティを設定しています。

```xaml
<Button Background="MediumSlateBlue" Foreground="White">Button text</Button>
```

XAML で [**Color**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.color) 構造体を使用すると、RGB または 16 進数値によって独自の色を作成できます。

```xaml
<Color x:Key="LightBlue">#FF36C0FF</Color>
```

また **FromArgb** メソッドを使用すると、コード内で同じ色を作成できます。

```csharp
Color LightBlue = Color.FromArgb(255,54,192,255);
```

"Argb" という文字は、色の 4 つの構成要素であるアルファ (Alpha、不透明度)、赤 (Red)、緑 (Green)、青 (Blue) の頭文字です。 各引数の設定可能な範囲は、0 ～ 255 です。 最初の値は省略可能です。その場合、透明度が既定値の 255、つまり 100% 不透明に設定されます。

> [!Note]
> C++ を使用している場合、[**ColorHelper**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.colorhelper) クラスを使って色を作成する必要があります。

**Color** は、UI 要素を単色で塗りつぶす [**SolidColorBrush**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.media.solidcolorbrush) の引数として使用されるのが最も一般的です。 このようなブラシは、通常、[**ResourceDictionary**](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.ResourceDictionary) で定義されているため、複数の要素に再利用できます。

```xaml
<ResourceDictionary>
    <SolidColorBrush x:Key="ButtonBackgroundBrush" Color="#FFFF4F67"/>
    <SolidColorBrush x:Key="ButtonForegroundBrush" Color="White"/>
</ResourceDictionary>
```

ブラシの使用方法について詳しくは、[XAML ブラシに関するページを](brushes.md)ご覧ください。

## <a name="usability"></a>ユーザビリティ

:::row:::
    :::column:::
        ![コントラストの図](images/color/illo-contrast.svg)
    :::column-end:::
    :::column span =「2」:::**コントラスト**

        Make sure that elements and images have sufficient contrast to differentiate between them, regardless of the accent color or theme.

        When considering what colors to use in your application, accessiblity should be a primary concern. Use the guidance below to make sure your application is accessible to as many users as possible.
    :::column-end:::
:::row-end:::

:::row:::
    :::column:::
        ![コントラストの図](images/color/illo-lighting.svg)
    :::column-end:::
    :::column span =「2」:::**照明**

        Be aware that variation in ambient lighting can affect the useability of your app. For example, a page with a black background might unreadable outside due to screen glare, while a page with a white background might be painful to look at in a dark room.
    :::column-end:::
:::row-end:::

:::row:::
    :::column:::
        ![コントラストの図](images/color/illo-colorblindness.svg)
    :::column-end:::
    :::column span =「2」:::**色覚障碍**

        Be aware of how colorblindness could affect the useability of your application. For example, a user with red-green colorblindness will have difficulty distinguishing red and green elements from each other. About **8 percent of men** and **0.5 percent of women** are red-green colorblind, so avoid using these color combinations as the sole differentiator between application elements.
    :::column-end:::
:::row-end:::

## <a name="related-articles"></a>関連記事

- [XAML スタイル](../controls-and-patterns/xaml-styles.md)
- [XAML テーマ リソース](../controls-and-patterns/xaml-theme-resources.md)