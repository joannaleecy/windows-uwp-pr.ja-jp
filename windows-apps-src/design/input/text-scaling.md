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
ms.custom: RS5
ms.openlocfilehash: 3110615e43ffa4839d9be6ebf5113fc9d8b7c05f
ms.sourcegitcommit: 9f8010fe67bb3372db1840de9f0be36097ed6258
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/16/2018
ms.locfileid: "7105264"
---
# <a name="text-scaling"></a>テキストの拡大縮小

![テキストの 225% に 100% のスケーリングの例](images/coretext/text-scaling-news-hero-small.png)  
*Windows 10 (100% に 225%) でスケーリング テキストの例*

## <a name="overview"></a>概要

(モバイル デバイスから Surface Hub の大きな画面にデスクトップのモニターにラップトップ) コンピューターの画面上のテキストの読み取りは、多くの人にとって困難なことができます。 逆に、一部のユーザーは、アプリや web サイトで必要以上にするために使用するフォント サイズを検索します。

テキストはを幅広いユーザーできるだけ読みやすいことを確認するには、Windows には、ユーザーが OS と個々 のアプリケーションの両方の間での相対的なフォント サイズを変更する機能が用意されています。 拡大鏡アプリ (これ通常だけ、画面の領域内のすべてを拡大し、独自の操作性の問題が導入されています) を使って、ディスプレイの解像度を変更または DPI スケーリングのサイズを変更ディスプレイと一般的な表示に基づくすべての証明書利用者ではなく距離)、ユーザーは、テキストだけで、100% (既定のサイズ) からの範囲のサイズを変更する設定にすばやくアクセスできる最大 225% です。

## <a name="support"></a>サポート

ユニバーサル Windows アプリケーション (両方の標準と PWA)、既定でスケーリング テキストをサポートします。

UWP アプリケーションには、カスタム コントロール、カスタム テキスト サーフェス、ハード コードされたコントロールの高さ、古いフレームワークは、またはサード パーティのフレームワークが含まれている場合可能性を加えることがユーザーに一貫性があり、便利なエクスペリエンスを確認するいくつかの更新。  

DirectWrite、GDI、および XAML SwapChainPanels ネイティブにサポートしませんテキストのスケーリングで Win32 のサポートは、メニューのアイコン、およびツールバーに制限されます。  

<!-- If you want to support text scaling in your application with these frameworks, you’ll need to support the text scaling change event outlined below and provide alternative sizes for your UI and content.   -->

## <a name="user-experience"></a>ユーザーによるインストール

ユーザーがテキストの倍率を調整できるより大きくスライダー設定]-> [テキストにすると簡単ビジョン/ディスプレイの画面]-> [します。

![テキストの 225% に 100% のスケーリングの例](images/coretext/text-scaling-settings-100-small.png)  
*設定から設定テキスト スケール簡単]-> [ビジョン/ディスプレイの画面]-> [*

## <a name="ux-guidance"></a>UX ガイダンス

テキストのサイズが変更されたコントロールとコンテナーする必要がありますもサイズを変更して、テキストとその新しいレイアウトに合わせて再配置されます。 前述の以前は、アプリ、フレームワーク、およびプラットフォームによってこの作業の大半はする行われます。 次の UX ガイダンスでは、そのことができない場合もについて説明します。

### <a name="use-the-platform-controls"></a>プラットフォーム コントロールを使う

言ったこれ既にかどうか。 繰り返しますが: 最小限の作業するときに、最も包括的なユーザー エクスペリエンスを実現するためにさまざまな Windows アプリのフレームワークで提供される組み込みのコントロールが常に使用可能な限り、します。

たとえば、すべての UWP テキスト コントロールは、テンプレート化やカスタマイズを加えなくてもエクスペリエンスをスケーリング完全なテキストをサポートします。

次に、いくつか標準的なテキスト コントロールにはが含まれている基本的な UWP アプリのスニペットを示します。

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
*アニメーション化されたテキストのスケーリング*

### <a name="use-auto-sizing"></a>自動サイズ変更を使う

コントロールの絶対サイズを指定しないでください。 可能であれば、[プラットフォームのユーザーとデバイスの設定に基づいて自動的に、コントロールのサイズを変更することができます。  

前の例からのこのスニペットで使用して、`Auto`と`*`一連の列のグリッドとできるように、プラットフォームの幅の値は、グリッド内に含まれる要素のサイズに基づくアプリのレイアウトを調整します。

``` xaml
<Grid.ColumnDefinitions>
    <ColumnDefinition Width="Auto"/>
    <ColumnDefinition Width="*"/>
    <ColumnDefinition Width="Auto"/>
</Grid.ColumnDefinitions>
```

### <a name="use-text-wrapping"></a>テキストの折り返し

アプリのレイアウトは柔軟性および適応可能なことを確認するには、(多くのコントロールでサポートされないテキストの折り返し既定ではテキストが含まれているすべてのコントロールでテキストの折り返しを有効にします。

プラットフォームで他のメソッドを使用して、クリッピングを含む、レイアウトを調整するテキストの折り返しを指定しない場合 (前の例をご覧ください)。

ここでは、使用して、`AcceptsReturn`と`TextWrapping`、レイアウトを確認するテキスト ボックスのプロパティは限りの柔軟性。

``` xaml
<TextBox PlaceholderText="Type something here" 
          AcceptsReturn="True" TextWrapping="Wrap" />
```

![テキストとテキストの折り返し 225% に 100% のスケーリングをアニメーション化](images/coretext/text-scaling-textwrap.gif)  
*テキストの折り返しをスケーリング アニメーション化されたテキスト*

### <a name="specify-text-trimming-behavior"></a>テキストのトリミングの動作を指定します。

テキストの折り返しが優先される動作でない場合は、ほとんどのテキスト コントロールには、テキストをクリップまたはテキスト トリミングの動作の省略記号を指定することができます。 クリッピングは省略記号領域を占有自体の省略記号を優先します。

> [!NOTE]
> テキストをクリップする必要がある場合は、開始しない、文字列の末尾をクリップできます。

この例で方法を示します TextBlock のテキストをクリップ[TextTrimming](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.textblock.texttrimming)プロパティを使用します。

``` xaml
<TextBlock TextTrimming="Clip">
    The quick brown fox jumped over the lazy dog.
</TextBlock>
```

![テキストとテキストがクリッピングされて 225% に 100% のスケーリング](images/coretext/text-scaling-clipping-small.png)  
*テキストとテキストがクリッピングされてスケーリング*

### <a name="use-a-tooltip"></a>ヒントを使う

テキストをクリップする場合は、完全なテキストをユーザーに提供するヒントを使用します。

ここでは、ヒントは、テキストの折り返しがサポートされていない TextBlock を追加します。

``` xaml
<TextBlock TextTrimming="Clip">
    <ToolTipService.ToolTip>
        <ToolTip Content="The quick brown fox jumped over the lazy dog."/>
    </ToolTipService.ToolTip>
    The quick brown fox jumped over the lazy dog.
</TextBlock>
```

### <a name="dont-scale-font-based-icons-or-symbols"></a>フォント ベースのアイコンや記号を拡大縮小されません。

フォント ベースのアイコンを強調または装飾を使用する場合は、これらの文字でのスケーリングを無効にします。

[IsTextScaleFactorEnabled](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.control.istextscalefactorenabled)プロパティを設定する`false`ほとんどの XAML コントロールです。

### <a name="support-text-scaling-natively"></a>スケーリングをネイティブにサポート テキスト

コントロール、カスタムのフレームワークで[TextScaleFactorChanged](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.uisettings.textscalefactorchanged) UISettings システム イベントを処理します。 このイベントは、ユーザーがシステムにテキストの倍率を設定するたびにします。

## <a name="summary"></a>まとめ

このトピックでは、Windows でのサポートをスケーリングするテキストの概要を説明し、ユーザー エクスペリエンスをカスタマイズする方法についての UX と開発者向けガイダンスが含まれます。

## <a name="related-articles"></a>関連記事

### <a name="api-reference"></a>API リファレンス

- [IsTextScaleFactorEnabled](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.control.istextscalefactorenabled)
- [TextScaleFactorChanged](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.uisettings.textscalefactorchanged)
