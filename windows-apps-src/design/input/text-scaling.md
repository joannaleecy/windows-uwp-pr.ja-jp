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
# <a name="text-scaling"></a>テキストの拡大縮小

![100 ~ 225% に拡大縮小テキストの例](images/coretext/text-scaling-news-hero-small.png)  
*Windows 10 (225% を 100%) でのスケーリングのテキストの例*

## <a name="overview"></a>概要

(ラップトップ、Surface Hub の巨大な画面にデスクトップ モニターをモバイル デバイス) からコンピューター画面上のテキストを読み取るは、多くの人にとって難しいことができます。 逆に、一部のユーザーは、必要以上にするアプリや web サイトで使用されるフォント サイズを検索します。

テキストはを幅広いユーザーできるだけ読みやすいことを確認するには、Windows には、ユーザーが、OS と個々 のアプリケーション間での相対的なフォント サイズを変更する機能が用意されています。 拡大鏡アプリ (を通常だけ、画面の領域内のすべてを拡大し、独自の使いやすさの問題が発生する) を使用して、ディスプレイの解像度を変更または DPI スケール (を表示し、一般的な表示に基づくすべてのサイズ変更に依存する代わりに距離)、ユーザーがテキストだけで、100% (既定のサイズ) の範囲のサイズを変更する設定をすばやくアクセス 225% です。

## <a name="support"></a>サポート

ユニバーサル Windows アプリケーション (標準の PWA と)、テキストが既定ではスケーリングをサポートします。

UWP アプリケーションには、カスタム コントロール、カスタム テキスト サーフェス、ハード コードされたコントロールの高さ、古いフレームワーク、またはサード パーティ製のフレームワークが含まれている場合は、ユーザーのエクスペリエンスを一貫した有用なことを確認するには、いくつか更新がある可能性があります。  

DirectWrite、GDI、および XAML SwapChainPanels ネイティブでサポートしないテキストのスケーリング、Win32 のサポートは、メニューのアイコン、およびツールバーに制限されます。  

<!-- If you want to support text scaling in your application with these frameworks, you’ll need to support the text scaling change event outlined below and provide alternative sizes for your UI and content.   -->

## <a name="user-experience"></a>ユーザー エクスペリエンス

ユーザーがテキストのスケールを調整できるコンピューターの簡単操作]-> [設定のスライダーをより大きなテキストにするにはビジョン/ディスプレイの画面]-> [です。

![100 ~ 225% に拡大縮小テキストの例](images/coretext/text-scaling-settings-100-small.png)  
*テキストのスケール設定の設定からコンピューターの簡単操作]-> [Vision/ディスプレイの画面を ->*

## <a name="ux-guidance"></a>UX ガイダンス

テキストのサイズを調整コントロールとコンテナーする必要がありますものサイズを変更し、テキストと新しいレイアウトに合わせて調整します。 アプリ、フレームワーク、プラットフォームによって、以前に説明したように、この作業の多くが行われます。 次の UX ガイドでは、このような場合がについて説明します。

### <a name="use-the-platform-controls"></a>プラットフォーム コントロールを使用します。

言ったのこの既にでしょうか。 繰り返す価値があります。可能であれば、常に最小限の作業の最も包括的なユーザー エクスペリエンスを実現するため、さまざまな Windows アプリ フレームワークで提供される組み込みのコントロールを使用します。

たとえば、UWP のすべてのテキスト コントロールは、フルテキスト エクスペリエンスのカスタマイズやテンプレートなしのスケーリングをサポートします。

標準のテキスト コントロールをいくつかを含む基本的な UWP アプリからのスニペットを次に示します。

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

![アニメーション化されたテキストが 100% ~ 225% のスケーリング](images/coretext/text-scaling.gif)  
*アニメーション化されたテキストのスケーリング*

### <a name="use-auto-sizing"></a>自動サイズ調整を使用します。

コントロールの絶対サイズを指定しないでください。 可能であれば、ユーザーとデバイスの設定に基づいて自動的にコントロールのサイズを変更するプラットフォームを使用できます。  

このスニペットが、前の例では使用して、`Auto`と`*`一連の let プラットフォームとグリッド列の幅の値がグリッド内に含まれる要素のサイズに基づいてアプリのレイアウトを調整します。

``` xaml
<Grid.ColumnDefinitions>
    <ColumnDefinition Width="Auto"/>
    <ColumnDefinition Width="*"/>
    <ColumnDefinition Width="Auto"/>
</Grid.ColumnDefinitions>
```

### <a name="use-text-wrapping"></a>テキストの折り返し

アプリのレイアウトはを柔軟で可能な限り適応性のあることを確認するには、(多くのコントロールによってサポートしていないテキストの折り返し既定値) のテキストを含む任意のコントロールのテキストの折り返しを有効にします。

プラットフォームが、クリッピングなど、レイアウトを調整するその他のメソッドを使用してテキストの折り返しを指定しない場合 (前の例を参照してください)。

ここで、使用、`AcceptsReturn`と`TextWrapping`レイアウトを確認するテキスト ボックスのプロパティは、柔軟性を備えています。

``` xaml
<TextBox PlaceholderText="Type something here" 
          AcceptsReturn="True" TextWrapping="Wrap" />
```

![100 ~ 225% 自動スケールでテキストの折り返しテキストをアニメーション化](images/coretext/text-scaling-textwrap.gif)  
*アニメーション化されたテキストがテキストの折り返しを使用したスケール*

### <a name="specify-text-trimming-behavior"></a>テキストのトリミング動作を指定します。

テキストの折り返しが優先動作でない場合は、ほとんどのテキスト コントロールを使用するテキストをクリップするか、テキストのトリミング動作の省略記号を指定できます。 省略記号が自身の領域を占有クリッピングは楕円に優先されます。

> [!NOTE]
> テキストをクリップする必要がある場合は、先頭ではない、文字列の末尾をクリップします。

この例でを使用して、TextBlock のテキストをクリップする方法を説明します、 [TextTrimming](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.textblock.texttrimming)プロパティ。

``` xaml
<TextBlock TextTrimming="Clip">
    The quick brown fox jumped over the lazy dog.
</TextBlock>
```

![テキストがテキスト領域で 100 ~ 225% のスケーリング](images/coretext/text-scaling-clipping-small.png)  
*テキストのテキストのクリッピングを使用したスケール*

### <a name="use-a-tooltip"></a>ツールヒントを使用して、

テキストをクリップする場合は、ツールヒントを使用して、ユーザーに完全なテキストを提供します。

ここでは、テキストの折り返しをサポートしていない TextBlock にツールヒントを追加します。

``` xaml
<TextBlock TextTrimming="Clip">
    <ToolTipService.ToolTip>
        <ToolTip Content="The quick brown fox jumped over the lazy dog."/>
    </ToolTipService.ToolTip>
    The quick brown fox jumped over the lazy dog.
</TextBlock>
```

### <a name="dont-scale-font-based-icons-or-symbols"></a>フォント ベースのアイコンまたはシンボルのスケール変更はありません。

フォント ベースのアイコンを強調または装飾を使用する場合は、これらの文字のスケーリングを無効にします。

設定、 [IsTextScaleFactorEnabled](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.control.istextscalefactorenabled)プロパティを`false`XAML のほとんどを制御します。

### <a name="support-text-scaling-natively"></a>ネイティブのスケーリング サポート テキスト

処理、 [TextScaleFactorChanged](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.uisettings.textscalefactorchanged)カスタムのフレームワークとコントロールで UISettings システム イベント。 このイベントには、ユーザーがシステムにテキストの倍率を設定するたびが発生します。

## <a name="summary"></a>概要

このトピックでは、Windows でのサポートを拡大縮小テキストの概要を説明し、ユーザー エクスペリエンスをカスタマイズする方法の UX や開発者向けのガイダンスが含まれます。

## <a name="related-articles"></a>関連記事

### <a name="api-reference"></a>API リファレンス

- [IsTextScaleFactorEnabled](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.control.istextscalefactorenabled)
- [TextScaleFactorChanged](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.uisettings.textscalefactorchanged)
