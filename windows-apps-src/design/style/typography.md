---
description: コンテンツをユーザーに理解しやすくするための、アプリにおける文字体裁の使用方法について説明します。
title: UWP アプリの文字体裁
ms.date: 04/06/2018
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.custom: RS5
ms.openlocfilehash: 0943273dab239669be75b30070222d698246aa41
ms.sourcegitcommit: b11f305dbf7649c4b68550b666487c77ea30d98f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/27/2018
ms.locfileid: "7829362"
---
# <a name="typography"></a>文字体裁

![ヒーロー イメージ](images/header-typography.svg)

言語の視覚的表現である文字体裁において、何よりも重要な役割は情報を伝達することです。 スタイルは、その目的を阻害するものであってはなりません。 この記事では、ユーザーが簡単かつ効率的にコンテンツを理解できるように、UWP アプリで文字体裁のスタイルを決定する方法について説明します。

## <a name="font"></a>フォント

アプリ全体で同じフォントを使用してください。UWP アプリの既定のフォントである **Segoe UI** に統一することをお勧めします。 このフォントは、常に最適な読みやすさが維持されるサイズとピクセル密度を備え、システムのコンテンツを清潔で軽快、かつオープンに美しく表示します。

![Segoe UI フォントのサンプル テキスト](images/type/segoe-sample.svg)

アプリで英語以外の言語を表示する場合、または異なるフォントを選択する場合は、「[言語](#Languages)」と「[フォント](#Fonts)」のセクションで、弊社が UWP アプリ向けに推奨するフォントを確認してください。

:::row:::
    :::column:::
        ![do](images/do.svg)
        Pick one font for your UI.
    :::column-end:::
    :::column:::
        ![don't](images/dont.svg)
        Don't mix multiple fonts.
    :::column-end:::
:::row-end:::

## <a name="size-and-scaling"></a>サイズとスケーリング

UWP アプリのフォント サイズは、すべてのデバイスで自動的に拡大縮小します。 スケーリング アルゴリズムによって、10 フィート離れた Surface Hub 上の 24 ピクセル フォントが、目の前にある 5 インチ サイズの電話の画面に表示された 24 ピクセル フォントと同じ読みやすさで表示されます。

![さまざまなデバイスの視聴距離](images/type/scaling-chart.svg)

スケーリング システムのしくみを踏まえ、実際の物理ピクセルではなく、有効ピクセルに基づいてデザインしてください。異なる画面サイズや解像度に応じてフォント サイズを変更する必要はありません。

:::row:::
    :::column:::
        ![do](images/do.svg)
        Follow the UWP [type ramp](#type-ramp) sizing.
    :::column-end:::
    :::column:::
        ![don't](images/dont.svg)
        Use a font size smaller than 12 px.
    :::column-end:::
:::row-end:::

## <a name="hierarchy"></a>階層

:::row:::
    :::column:::
        Users rely on visual hierarchy when scanning a page: headers summarize content, and body text provides more detail. To create a clear visual hierarchy in your app, follow the UWP type ramp.
    :::column-end:::
    :::column:::
        ![text block styles](images/type/type-hierarchy.svg)
    :::column-end:::
:::row-end:::

### <a name="type-ramp"></a>書体見本

UWP 書体見本は、ユーザーがコンテンツを読みやすいように、ページ上の各書体スタイル間の重要な関係を定めたものです。 すべてのサイズは有効ピクセル単位で示され、UWP アプリが動作するデバイスを問わず、常に最適に表示されるように調整されています。

![書体見本](images/type/type-ramp.svg)

### <a name="using-the-type-ramp"></a>書体見本の使用

:::row:::
    :::column:::
        You can access levels of the type ramp as XAML [static resources](../controls-and-patterns/xaml-theme-resources.md#the-xaml-type-ramp). The styles follow the `*TextBlockStyle` naming convention.
    :::column-end:::
    :::column:::
        ![text block styles](images/type/text-block-type-ramp.svg)
    :::column-end:::
:::row-end:::

```XAML
<TextBlock Text="Header" Style="{StaticResource HeaderTextBlockStyle}"/>
<TextBlock Text="SubHeader" Style="{StaticResource SubheaderTextBlockStyle}"/>
<TextBlock Text="Title" Style="{StaticResource TitleTextBlockStyle}"/>
<TextBlock Text="SubTitle" Style="{StaticResource SubtitleTextBlockStyle}"/>
<TextBlock Text="Base" Style="{StaticResource BaseTextBlockStyle}"/>
<TextBlock Text="Body" Style="{StaticResource BodyTextBlockStyle}"/>
<TextBlock Text="Caption" Style="{StaticResource CaptionTextBlockStyle}"/>
```

:::row:::
    :::column:::
        ![do](images/do.svg)
        Use "Body" for most text.

        Use "Base" for titles when space is constrained.
    :::column-end:::
    :::column:::
        ![don't](images/dont.svg)
        Use "Caption" for primary action or any long strings.

        Use "Header" or "Subheader" if text needs to wrap.
    :::column-end:::
:::row-end:::

## <a name="alignment"></a>配置

既定の [TextAlignment](https://docs.microsoft.com/uwp/api/windows.ui.xaml.textalignment) (行揃え) は Left (左揃え) です。ほとんどの場合、左揃え、右不揃いの形式でコンテンツを一貫してアンカー設定することで、均一なレイアウトが実現します。 RTL 言語については、[グローバリゼーションをサポートするためのレイアウトとフォントの調整に関するページ](../globalizing/adjust-layout-and-fonts--and-support-rtl.md)をご覧ください。

![左揃えテキストを示します。](images/type/alignment.svg)

```xaml
<TextBlock TextAlignment="Left">
```

## <a name="character-count"></a>文字カウント

:::row:::
    :::column:::
        ![do](images/do.svg)
        Keep to 50–60 letters per line for ease of reading.
    :::column-end:::
    :::column:::
        ![don't](images/dont.svg)
        Less than 20 characters or more than 60 characters per line is difficult to read.
    :::column-end:::
:::row-end:::

## <a name="clipping-and-ellipses"></a>クリッピングと省略記号

テキストの量が利用可能なスペースを超えている場合は、テキストをクリッピングすることが推奨されます。クリッピングは、ほとんどの [UWP テキスト コントロール](../controls-and-patterns/text-controls.md) で既定の処理です。

![いくつかのテキスト クリッピングがあるデバイス フレームを示します。](images/type/clipping.svg)

```xaml
<TextBlock TextWrapping="WrapWholeWords" TextTrimming="Clip"/>
```

:::row:::
    :::column:::
        ![do](images/do.svg)
        Clip text, and wrap if multiple lines are enabled.
    :::column-end:::
    :::column:::
        ![don't](images/dont.svg)
        Use ellipses to avoid visual clutter.
    :::column-end:::
:::row-end:::

**注**: 表示領域が不明確な場合 (領域が異なる背景色によって明確に表示されていない場合など)、または詳細テキストへのリンクがある場合は、省略記号を使用します。

## <a name="languages"></a>言語 

Segoe UI は、英語、ヨーロッパの各言語、ギリシャ語、ヘブライ語、アルメニア語、ジョージア語、アラビア語に対応した弊社のフォントです。 他の言語については、以下の推奨事項を参照してください。

### <a name="globalizinglocalizing-fonts"></a>フォントのグローバリゼーション/ローカライズ

特定言語の推奨フォント ファミリー、サイズ、太さ、スタイルにプログラムを使ってアクセスする場合は、[LanguageFont フォント マッピング API](https://docs.microsoft.com/uwp/api/Windows.Globalization.Fonts.LanguageFont) を使ってください。 LanguageFont オブジェクトを使うと、コンテンツのさまざまなカテゴリ (UI ヘッダー、通知、本文のテキスト、ユーザー自身で編集できるドキュメント本文のフォントなど) の正しいフォント情報にアクセスできます。 詳しくは、[グローバリゼーションをサポートするためのレイアウトとフォントの調整に関するページ](../globalizing/adjust-layout-and-fonts--and-support-rtl.md)をご覧ください。

### <a name="fonts-for-non-latin-languages"></a>ラテン語以外の言語用のフォント

<table>
<thead>
<tr class="header">
<th align="left">フォント ファミリー</th>
<th align="left">スタイル</th>
<th align="left">コメント</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td style="font-family: Embrima;">Ebrima</td>
<td align="left">標準、太字</td>
<td align="left">アフリカのスクリプト (エチオピア文字、ンコ文字、オスマニア文字、ティフィナグ文字、ヴァイ文字) 用のユーザー インターフェイス フォント。</td>
</tr>
<tr class="even">
<td style="font-family: Gadugi;">Gadugi</td>
<td align="left">標準、太字</td>
<td align="left">北アメリカ スクリプト (カナダ音節文字、チェロキー文字) 用のユーザー インターフェイス フォント。</td>
</tr>
<tr class="odd">
<td align="left" style="font-family: Leelawadee UI;">Leelawadee UI</td>
<td align="left">通常、Semilight、太字</td>
<td align="left">東南アジアのスクリプト (ブギス文字、ラオス文字、クメール文字、タイ文字) 用のユーザー インターフェイス フォント。</td>
</tr>
<tr class="odd">
<td align="left" style="font-family: Malgun Gothic;">Malgun Gothic</td>
<td align="left">標準</td>
<td align="left">韓国語用のユーザー インターフェイス フォント。</td>
</tr>
<tr class="even">
<td align="left" style="font-family: Microsoft JhengHei UI;">Microsoft JhengHei UI</td>
<td align="left">標準、太字、細字</td>
<td align="left">繁体字中国語用のユーザー インターフェイス フォント。</td>
</tr>
<tr class="odd">
<td align="left" style="font-family: Microsoft YaHei UI;">Microsoft YaHei UI</td>
<td align="left">標準、太字、細字</td>
<td align="left">簡体字中国語用のユーザー インターフェイス フォント。</td>
</tr>
<tr class="odd">
<td align="left" style="font-family: Myanmar Text;">Myanmar Text</td>
<td align="left">標準</td>
<td align="left">ミャンマー文字のスクリプト用のフォールバック フォント。</td>
</tr>
<tr class="even">
<td align="left" style="font-family: Nirmala UI;">Nirmala UI</td>
<td align="left">標準、中細、太字</td>
<td align="left">南アジア言語のスクリプト (バングラ文字、デーバナーガリー文字、グジャラート文字、グルムキー文字、カンナダ文字、マラヤーラム文字、オディア文字、オル チキ文字、シンハラ文字、ソラング ソンペング文字、タミール文字、テルグ文字) 用のユーザー インターフェイス フォント</td>
</tr>
<tr class="odd">
<td align="left" style="font-family: SimSun;">SimSun</td>
<td align="left">標準</td>
<td align="left">中国語繁体字の UI フォント。 </td>
</tr>
<tr class="even">
<td align="left" style="font-family: Yu Gothic UI;">Yu Gothic UI</td>
<td align="left">細字、中細、標準、中太、太字</td>
<td align="left">日本語用のユーザー インターフェイス フォント。</td>
</tr>
</tbody>
</table>

## <a name="fonts"></a>フォント

### <a name="sans-serif-fonts"></a>サンセリフ フォント

サンセリフ フォントは、ヘッダーと UI 要素に適しています。 

<table>
<colgroup>
<col width="33%" />
<col width="33%" />
<col width="33%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">フォント ファミリー</th>
<th align="left">スタイル</th>
<th align="left">コメント</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left" style="font-family: Arial;">Arial</td>
<td align="left">標準、斜体、太字、太字斜体、黒</td>
<td align="left">ヨーロッパおよび中東のスクリプト (ラテン文字、ギリシャ文字、キリル文字、アラビア文字、アルメニア文字、ヘブライ文字) をサポートしています。極太の太さがサポートされているのはヨーロッパのスクリプトだけです。</td>
</tr>
<tr class="even">
<td align="left" style="font-family: Calibri;">Calibri</td>
<td align="left">標準、斜体、太字、太字斜体、細字、細字斜体</td>
<td align="left">ヨーロッパおよび中東のスクリプト (ラテン文字、ギリシャ文字、キリル文字、アラビア語、ヘブライ語) をサポートしています。 アラビア語は縦書きでのみ利用できます。</td>
</tr>
<td style="font-family: Consolas;">Consolas</td>
<td>標準、斜体、太字、太字斜体</td>
<td>ヨーロッパのスクリプト (ラテン文字、ギリシャ文字、キリル文字) をサポートする等幅フォント。</td>
</tr>

<tr>
<td style="font-family: Segoe UI;">Segoe UI</td>
<td>標準、斜体、細字斜体、極太斜体、太字、太字斜体、細字、中細、中太、極太</td>
<td>ヨーロッパおよび中東のスクリプト (アラビア文字、アルメニア文字、キリル文字、ジョージア文字、ギリシャ文字、ヘブライ文字、ラテン文字) およびリス文字のスクリプト用のユーザー インターフェイス フォント。</td>
</tr>

<tr class="even">
<td style="font-family: Selawik;">Selawik</td>
<td align="left">標準、中細、細字、太字、中太</td>
<td align="left">他のプラットフォーム上で動作する Segoe UI をバンドルしないアプリ向けの、Segoe UI と測定上の互換性があるオープン ソース フォント。 <a href="https://github.com/Microsoft/Selawik">Selawik は、GitHub で入手できます。</a></td>
</tr>

</tbody>
</table>

### <a name="serif-fonts"></a>セリフ フォント

セリフ フォントは、大量のテキストを表示するのに適しています。 

<table>
<thead>
<tr class="header">
<th align="left">フォント ファミリー</th>
<th align="left">スタイル</th>
<th align="left">コメント</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td style="font-family: Cambria;">Cambria</td>
<td align="left">標準</td>
<td align="left">ヨーロッパのスクリプト (ラテン文字、ギリシャ文字、キリル文字) をサポートするセリフ フォント。</td>
</tr>
<tr class="even">
<td style="font-family: Courier New;">Courier New</td>
<td align="left">標準、斜体、太字、太字斜体</td>
<td align="left">セリフ等幅フォントは、ヨーロッパおよび中東のスクリプト (ラテン文字、ギリシャ文字、キリル文字、アラビア文字、アルメニア文字、ヘブライ文字) をサポートしています。</td>
</tr>
<tr class="odd">
<td style="font-family: Georgia;">Georgia</td>
<td align="left">標準、斜体、太字、太字斜体</td>
<td align="left">ヨーロッパのスクリプト (ラテン文字、ギリシャ文字、キリル文字) をサポートしています。</td>
</tr>

<tr class="even">
<td style="font-family: Times New Roman;">Times New Roman</td>
<td align="left">標準、斜体、太字、太字斜体</td>
<td align="left">ヨーロッパのスクリプト (ラテン文字、ギリシャ文字、キリル文字、アラビア文字、アルメニア文字、ヘブライ文字) をサポートしている従来のフォント。</td>
</tr>

</tbody>
</table>

### <a name="symbols-and-icons"></a>シンボルとアイコン

<table>
<thead>
<tr class="header">
<th align="left">フォント ファミリー</th>
<th align="left">スタイル</th>
<th align="left">コメント</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left">Segoe MDL2 アセット</td>
<td align="left">標準</td>
<td align="left">アプリ アイコン用のユーザー インターフェイス フォント。 詳しくは、<a href="segoe-ui-symbol-font.md">Segoe MDL2 アセットの記事</a>をご覧ください。</td>
</tr>
<tr class="even">
<td align="left">Segoe UI Emoji</td>
<td align="left">標準</td>
<td align="left"></td>
</tr>
<tr class="even">
<td align="left">Segoe UI Symbol</td>
<td align="left">標準</td>
<td align="left">記号用のフォールバック フォント</td>
</tr>
</tbody>
</table>

## <a name="related-articles"></a>関連記事

* [テキスト コントロール](../controls-and-patterns/text-controls.md)
* [XAML テーマ リソース](../controls-and-patterns/xaml-theme-resources.md#the-xaml-type-ramp)
* [XAML スタイル](../controls-and-patterns/xaml-styles.md)
* [Microsoft の文字体裁](https://docs.microsoft.com/typography/)
