---
author: mijacobs
description: "言語の視覚的な表現として、文字体裁の主な役割は明確であることです。 スタイルによってその目的が邪魔されてはなりません。 ただし、文字体裁にはレイアウト コンポーネントとしての重要な役割もあり、そのデザインの密度と複雑さに強い影響を与え、そのデザインのユーザー エクスペリエンスにも影響します。"
title: "文字体裁"
ms.assetid: ca35f78a-e4da-423d-9f5b-75896e0b8f82
template: detail.hbs
ms.author: mijacobs
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: bec416694e347a1432892f9dc591afdfe8548e61
ms.sourcegitcommit: f9a4854b6aecfda472fb3f8b4a2d3b271b327800
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/12/2017
---
# <a name="typography"></a>文字体裁

言語の視覚的な表現として、文字体裁の主な役割は明確であることです。 スタイルによってその目的が邪魔されてはなりません。 ただし、文字体裁にはレイアウト コンポーネントとしての重要な役割もあり、そのデザインの密度と複雑さに強い影響を与え、そのデザインのユーザー エクスペリエンスにも影響します。

## <a name="typeface"></a>書体

すべての Microsoft デジタル デザインで使う書体として Segoe UI が選択されました。 Segoe UI には多くの文字が用意されており、さまざまなサイズとピクセル密度で最適な読みやすさが維持されるように設計されています。 システムのコンテンツを補完する、きれいで明るくオープンな美しさを備えています。

![Segoe UI フォントのサンプル テキスト](images/segoe-sample.png)

## <a name="weights"></a>太さ

Microsoft では、シンプルさと効率性を考慮に入れて文字体裁に取り組んでいます。 1 つの書体、最小限の太さとサイズ、明確な階層構造を使うことを選択しました。 配置と位置合わせは、各言語の既定のスタイルに従います。 英語では、文字が左から右、上から下へと進みます。 テキストと画像の関係は、明確で直接的です。

![サポートされるフォントの太さを示します。 ライト、セミ ライト、レギュラー、セミ ボールド、ボールド](images/weights.png)

## <a name="line-spacing"></a>行間

![行間 125% の例](images/line-spacing.png)

行間はフォント サイズの 125% で計算し、必要に応じて 4 の倍数の近似値に丸めてください。 たとえば 15 ピクセルの Segoe UI の場合、15 ピクセルの 125% は 18.75 ピクセルです。 4 ピクセル グリッドが維持されるように、行の高さを 20 ピクセルに切り上げて設定することをお勧めします。 これにより、読みやすくなり、発音区分符のスペースが十分確保されます。 具体的な例については、以下の「書体見本」をご覧ください。

小さい書体の上に大きい書体を重ねる場合、大きい書体の最後のベースラインから小さい書体の最初のベースラインまでの距離が、大きい書体の行の高さと等しくなるようにしてください。

![小さい書体に対する大きい書体の重なり方を示す図](images/line-height-stacking.png)

XAML では、これは 2 つの [TextBlocks](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.textblock.aspx) を重ね、適切な余白を設定することで実現できます。

```xaml
<StackPanel Width="200">
    <!-- Setting a bottom margin of 3px on the header
         puts the baseline of the body text exactly 24px
         below the baseline of the header. 24px is the
         recommended line height for a 20px font size,
         which is what’s set in SubtitleTextBlockStyle.
         The bottom margin will be different for
         different font size pairings. -->
    <TextBlock
        Style="{StaticResource SubtitleTextBlockStyle}"
        Margin="0,0,0,3"
        Text="Header text" />
    <TextBlock
        Style="{StaticResource BodyTextBlockStyle}"
        TextWrapping="Wrap"
        Text="This line of text should be positioned where the above header would have wrapped." />
</StackPanel>
```


<div class="side-by-side">
<div class="side-by-side-content">
  <div class="side-by-side-content-left">
<h2>カーニングとトラッキング</h2>

Segoe は、ソフトでわかりやすい外観をした人間的な書体であり、手書き文字に基づく自然でオープンな形をしています。 できるだけ読みやすくし、人間的な一貫性を保つため、カーニングとトラッキングの設定を特定の値にする必要があります。

カーニングを "メトリック" に設定し、トラッキングを "0" に設定してください。
  </div>
  <div class="side-by-side-content-right">
<h2>単語や文字の間隔</h2>

カーニングやトラッキングと同様、できるだけ読みやすくし、人間的な一貫性を保つため、単語の間隔と文字間隔でも特定の設定を使います。

既定では、単語の間隔は常に 100% であり、文字間隔は "0" に設定する必要があります。
  </div>
</div>
</div>
<div class="side-by-side">
<div class="side-by-side-content">
  <div class="side-by-side-content-left">
![カーニングとトラッキングの差](images/kerning-tracking.png)  
  </div>
  <div class="side-by-side-content-right">
![単語の間隔と文字の間隔の差](images/word-letter.png) 
  </div>
</div>
</div>


>[!NOTE]
>XAML テキスト コントロールでは、[Typogrphy.Kerning](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.documents.typography.kerning.aspx) を使ってカーニングを制御し、[FontStretch](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Control#Windows_UI_Xaml_Controls_Control_FontStretch) を使ってトラッキングを制御します。 既定では、Typography.Kerning は "true" に設定され、FontStretch は推奨値である" Normal" に設定されます。

<div class="side-by-side">
<div class="side-by-side-content">
  <div class="side-by-side-content-left">
<h2>配置</h2>

通常は、視覚要素と書体の列を左揃えにすることをお勧めします。 ほとんどの場合、このような左揃えおよび右不揃いのアプローチによって、コンテンツが一貫したアンカー設定となり、均一なレイアウトになります。 
  </div>
  <div class="side-by-side-content-right">
<h2>行の末尾</h2>

文字体裁が左揃えおよび右不揃いで配置されていない場合、行の末尾が均等になるようにし、ハイフンを使わないでください。
  </div>
</div>
</div>

<div class="side-by-side">
<div class="side-by-side-content">
  <div class="side-by-side-content-left">
![左揃えテキストを示します。](images/alignment.png)  
  </div>
  <div class="side-by-side-content-right">
![均等な行の末尾を示します。](images/line-endings.png) 
  </div>
</div>
</div>


## <a name="paragraphs"></a>段落

列の端を揃えるため、インデントなしの行をスキップすることで段落を示してください。

![段落間のスペースの行全体を示します。](images/paragraphs.png)

## <a name="character-count"></a>文字カウント

行が短すぎると、目を左から右へと頻繁に動かさなければならなくなり、読者のリズムが崩れます。 可能であれば、1 行あたり 50 ~ 60 文字にすると最も読みやすくなります。

Segoe UI には多くの文字が用意されており、サイズが小さくても大きくても、またはピクセル密度が低くても高くても最適な読みやすさが維持されるように設計されています。 テキスト列の行の文字数を最適にすると、アプリケーションでの読みやすさが確保されます。

行が長すぎると目に負担がかかり、ユーザーが混乱する可能性があります。 行が短すぎると読者が目を頻繁に動かさなければならず、疲れる可能性があります。

![行の長さが異なる 3 つの段落を示します。](images/character-count.png)

## <a name="hanging-text-alignment"></a>ぶら下げテキストの配置

横方向に配置されたテキスト付きアイコンは、アイコンのサイズとテキストの量に応じてさまざまな方法で処理することができます。 1 行であっても複数行であってもテキストがアイコンの高さに収まる場合、テキストを上下に中央揃えにしてください。

テキストの高さがアイコンの高さより高い場合、テキストの先頭行を縦方向に揃え、残りのテキストが自然に下に流れるようにしてください。 大文字、アセンダー、ディセンダーの高さが通常よりも大きい文字を使うときは、同じ配置ガイダンスが守られるように注意してください。

![アイコンとテキストの組み合わせの例](images/hanging-text-alignment.png)

>[!NOTE]
>XAML の [TextBlock.TextLineBounds](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.textblock.textlinebounds.aspx) プロパティを使うと、大文字の高さやベースライン フォント メトリックにアクセスできます。 このプロパティは、書体を視覚的に上下中央に配置したり、上揃えに配置する場合に利用できます。

## <a name="clipping-and-ellipses"></a>クリッピングと省略記号

既定でクリップ - 赤線により指定されている場合除き、テキストが折り返されることを前提とします。 折り返しのないテキストを使う場合、省略記号ではなくクリッピングをお勧めします。 クリッピングは、コンテナーの端、デバイスの端、スクロール バーの端などで行われます。

例外: 明確に定義されていないコンテナーの場合 (はっきりした背景色がないなど)、折り返しのないテキストに赤線を付けて省略記号 "..." を使うことができます。

![いくつかのテキスト クリッピングがあるデバイス フレームを示します。](images/clipping.png)

## <a name="type-ramp"></a>書体見本
書体見本 (type ramp) は、ヘッドラインからの本文までの重要なデザインの関係を確立し、異なるレベル間の明快でわかりやすい階層を保証します。 この階層により、ユーザーが書面によるコミュニケーションを通じて簡単にナビゲートできる構造が作成されます。

<div class="uwpd-image-with-caption">
    <img src="images/type-ramp.png" alt="Shows the type ramp" />
    <div>すべてのサイズは有効ピクセル単位です。 詳しくは、「[UWP アプリ設計の概要](../basics/design-and-ui-intro.md)」をご覧ください。</div>
</div>

>[!NOTE]
>書体見本のほとんどのレベルは、XAML の[静的リソース](https://msdn.microsoft.com/en-us/library/windows/apps/Mt187274.aspx#the_xaml_type_ramp)として利用できます。これらのリソースは、`*TextBlockStyle` 名前付け規則に従っています (例: `HeaderTextBlockStyle`)。


<!--
<div class="microsoft-internal-note">
SubtitleAlt, BaseAlt, and CaptionAlt are not currently included. You can create the styles in your own app following the code snippets in the above link. Also note that XAML does not currently match the line height exactly.
</div>
-->


## <a name="primary-and-secondary-text"></a>プライマリ テキストとセカンダリ テキスト

書体見本を超えて追加の階層を作成するには、セカンダリ テキストの不透明度を 60% に設定します。 [テーマ カラー パレット](color.md#themes) で、BaseMedium を使います。 プライマリ テキストは、常に不透明度を 100% にするか、BaseHigh にしてください。

<!-- Need new images
![Two phone apps using SubtitleAlt](images/type-ramp-example-2.png)
Recommended use of SubtitleAlt. Also note the primary and secondary text usage in list items.

![Two phone apps using CaptionAlt](images/type-ramp-example-1.png)
Recommended use of CaptionAlt.
-->

## <a name="all-caps-titles"></a>すべて大文字のタイトル

特定のページ タイトルでは、階層に新たな次元を加えるため、すべて大文字にしてください。 これらのタイトルでは、BaseAlt を使い、文字間隔を em の 1,000 分の 75 にしてください。 この処理は、アプリのナビゲーションに使っても役立つことがあります。

ただし、言語によっては固有名詞を大文字にすると意味が変わるため、名前やユーザー入力に基づくページ タイトルはすべて大文字に変換*しない*でください。


<!-- Need new images
![Shows several apps where they should and should not use all caps](images/all-caps.png)
Green shows where all caps should be used. Red shows where it should not.
-->

## <a name="dos-and-donts"></a>推奨と非推奨
* ほとんどのテキストには Body を使う
* スペースに制約がある場合はタイトルに Base を使う
* SubtitleAlt を組み込んで、最上位のコンテンツを強調することでコントラストと階層を作る
* 長い文字列やプライマリ操作には Caption を使わない
* テキストを折り返す必要がある場合は Header や Subheader を使わない
* 同じページで Subtitle と SubtitleAlt を組み合わせない


## <a name="related-articles"></a>関連記事

* [テキスト コントロール](../controls-and-patterns/text-controls.md)
* [フォント](../style/fonts.md)
* [Segoe MDL2 アイコン](segoe-ui-symbol-font.md)
