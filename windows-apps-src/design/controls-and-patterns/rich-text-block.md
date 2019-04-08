---
Description: RichTextBlockOverflow 要素を持つ RichTextBlock を使って、高度なテキスト レイアウトを作成します。
title: RichTextBlock
ms.assetid: E4BE4B1B-418E-4075-88F1-22C09DDF8E45
label: Rich text block
template: detail.hbs
ms.date: 05/19/2017
ms.topic: article
keywords: windows 10, uwp
pm-contact: miguelrb
design-contact: ksulliv
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 0ab83e74dc59b407c15e1a8213540c8954fcd16e
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57610897"
---
# <a name="rich-text-block"></a>リッチ テキスト ブロック

 

リッチ テキスト ブロックは、段落、インライン UI 要素、複雑なテキスト レイアウトなどのサポートが必要な場合に使用できる、高度なテキスト レイアウト用のいくつかの機能を提供します。

> **重要な API**:[RichTextBlock クラス](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richtextblock.aspx)、 [RichTextBlockOverflow クラス](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richtextblockoverflow.aspx)、[クラスを段落](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.documents.paragraph.aspx)、[タイポグラフィ クラス](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.documents.typography.aspx)

## <a name="is-this-the-right-control"></a>適切なコントロールの選択

複数の段落、段組などの複雑なテキスト レイアウト、インライン UI 要素 (画像など) をサポートする必要がある場合は、**RichTextBlock** を使います。

**TextBlock** を使用して、アプリ内の読み取り専用テキストの大半を表示します。 これを使用すると、単一行または複数行のテキスト、インライン ハイパーリンク、書式 (太字、斜体、下線付きなど) が設定されたテキストを表示できます。 TextBlock は、よりシンプルなコンテンツ モデルを提供します。そのため、一般に使い方がより簡単で、テキスト レンダリングのパフォーマンスも RichTextBlock より優れています。 ほとんどのアプリで UI テキストに適しています。 テキスト内に改行を配置することはできますが、TextBlock は単一の段落を表示するために設計されており、テキストのインデントはサポートされていません。

適切なテキスト コントロールの選択について詳しくは、「[テキスト コントロール](text-controls.md)」をご覧ください。

## <a name="examples"></a>例

<table>
<th align="left">XAML コントロール ギャラリー<th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックして<a href="xamlcontrolsgallery:/item/RichTextBlock">アプリを開き、RichTextBlock の動作を確認</a>してください。</p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</a></li>
    <li><a href="https://github.com/Microsoft/Xaml-Controls-Gallery">ソース コード (GitHub) を入手する</a></li>
    </ul>
</td>
</tr>
</table>

## <a name="create-a-rich-text-block"></a>リッチ テキスト ブロックを作成する

RichTextBlock のコンテンツ プロパティは [Blocks](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richtextblock.blocks.aspx) プロパティです。このプロパティでは、[Paragraph](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.documents.paragraph.aspx) 要素によって段落に基づくテキストがサポートされています。 アプリ内でコントロールのテキスト コンテンツに簡単にアクセスすることができる **Text** プロパティは含まれていません。 しかし、RichTextBlock には、TextBlock にはない独自の機能がいくつかあります。 

RichTextBlock では次の機能がサポートされています。
- 複数の段落。 段落のインデントを設定するには [TextIndent](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richtextblock.textindent.aspx) プロパティを設定します。
- インライン UI 要素。 画像などの UI 要素をテキスト内にインラインで表示するには [InlineUIContainer](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.documents.inlineuicontainer.aspx) を使います。
- オーバーフロー コンテナー。 段組テキスト レイアウトを作成するには [RichTextBlockOverflow](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richtextblockoverflow.aspx) 要素を使います。

### <a name="paragraphs"></a>段落

RichTextBlock コントロール内に表示するテキストのブロックを定義するには [Paragraph](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.documents.paragraph.aspx) 要素を使います。 すべての RichTextBlock に少なくとも 1 つの Paragraph を含める必要があります。 

RichTextBlock のすべての段落のインデントを設定するには、[RichTextBlock.TextIndent](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richtextblock.textindent.aspx) プロパティを設定します。 RichTextBlock 内の特定の段落でこの設定を上書きするには、[Paragraph.TextIndent](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.documents.paragraph.textindent.aspx) プロパティを別の値に設定します。

```xaml
<RichTextBlock TextIndent="12">
  <Paragraph TextIndent="24">First paragraph.</Paragraph>
  <Paragraph>Second paragraph.</Paragraph>
  <Paragraph>Third paragraph. <Bold>With an inline.</Bold></Paragraph>
</RichTextBlock>
```

### <a name="inline-ui-elements"></a>インライン UI 要素

[InlineUIContainer](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.documents.inlineuicontainer.aspx) クラスを使うと、任意の UIElement をテキスト内にインラインで埋め込むことができます。 Image をテキスト内にインラインで配置するシナリオが一般的ですが、Button、CheckBox などの対話型の要素を使うこともできます。

同じ位置に複数の要素をインラインで埋め込むには、パネルを 1 つの InlineUIContainer の子として使って、そのパネルに複数の要素を配置することを検討してください。

次の例は、InlineUIContainer を使って RichTextBlock に画像を挿入する方法を示しています。 

```xaml
<RichTextBlock>
    <Paragraph>
        <Italic>This is an inline image.</Italic>
        <InlineUIContainer>
            <Image Source="Assets/Square44x44Logo.png" Height="30" Width="30"/>
        </InlineUIContainer>
        Mauris auctor tincidunt auctor.
    </Paragraph>
</RichTextBlock>
```

## <a name="overflow-containers"></a>オーバーフロー コンテナー

[RichTextBlockOverflow](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richtextblockoverflow.aspx) 要素を持つ RichTextBlock を使って、段組などの高度なページ レイアウトを作成することができます。 RichTextBlockOverflow 要素のコンテンツは、常に RichTextBlock 要素から取得されます。 RichTextBlockOverflow 要素をリンクするには、その要素を RichTextBlock または別の RichTextBlockOverflow の OverflowContentTarget として設定します。

2 段組みのレイアウトを作成する簡単な例を次に示します。 より複雑な例については、「例」をご覧ください。

```xaml
<Grid>
    <Grid.ColumnDefinitions>
        <ColumnDefinition/>
        <ColumnDefinition/>
    </Grid.ColumnDefinitions>
    <RichTextBlock Grid.Column="0" 
                   OverflowContentTarget="{Binding ElementName=overflowContainer}" >
        <Paragraph>
            Proin ac metus at quam luctus ultricies.
        </Paragraph>
    </RichTextBlock>
    <RichTextBlockOverflow x:Name="overflowContainer" Grid.Column="1"/>
</Grid>
```

## <a name="formatting-text"></a>テキストの書式設定

RichTextBlock に格納されるのはプレーン テキストですが、各種の書式設定オプションを適用して、アプリでテキストをレンダリングする方法をカスタマイズすることができます。 FontFamily、FontSize、FontStyle、Foreground、CharacterSpacing などの標準的なコントロール プロパティを設定して、テキストの外観を変更できます。 インライン テキスト要素と Typography 添付プロパティを使ってテキストを書式設定することもできます。 これらのオプションが影響を与えるのは、RichTextBlock がローカルでテキストを表示する方法だけです。したがって、テキストをコピーしてリッチ テキスト コントロールなどに貼り付けても、書式設定は適用されません。

### <a name="inline-elements"></a>インライン要素

[Windows.UI.Xaml.Documents](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.documents.aspx) 名前空間には、テキストの書式設定に使うことができるさまざまなインライン テキスト要素が用意されています (Bold、Italic、Run、Span、LineBreak など)。 テキストのセクションに書式設定を適用する典型的な方法では、テキストを Run 要素または Span 要素に配置して、その要素のプロパティを設定します。

次の例では、Paragraph の最初の語句が太字、青色、16 ポイントのテキストで表示されます。

```xaml
<Paragraph>
    <Bold><Span Foreground="DarkSlateBlue" FontSize="16">Lorem ipsum dolor sit amet</Span></Bold>
    , consectetur adipiscing elit.
</Paragraph>
```

### <a name="typography"></a>文字体裁

[Typography](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.documents.typography.aspx) クラスの添付プロパティは、Microsoft OpenType の一連の Typography プロパティへのアクセスを提供します。 これらの添付プロパティは、RichTextBlock で設定することも、次の例のように個々のインライン テキスト要素で設定することもできます。

```xaml
<RichTextBlock Typography.StylisticSet4="True">
    <Paragraph>
        <Span Typography.Capitals="SmallCaps">Lorem ipsum dolor sit amet</Span>
        , consectetur adipiscing elit.
    </Paragraph>
</RichTextBlock>
```

## <a name="recommendations"></a>推奨事項

文字体裁およびフォントのガイドラインに関するトピックをご覧ください。

## <a name="get-the-sample-code"></a>サンプル コードを入手する

- [XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Xaml-Controls-Gallery) - インタラクティブな形で XAML コントロールのすべてを参照できます。

## <a name="related-articles"></a>関連記事

[テキスト コントロール](text-controls.md)

**デザイナー向け**
- [スペル チェックするためのガイドライン](text-controls.md)
- [検索の追加](https://msdn.microsoft.com/library/windows/apps/hh465231)
- [テキスト入力するためのガイドライン](text-controls.md)

**開発者向け (XAML)**
- [TextBox クラス](https://msdn.microsoft.com/library/windows/apps/br209683)
- [Windows.UI.Xaml.Controls PasswordBox クラス](https://msdn.microsoft.com/library/windows/apps/br227519)


**(その他) 開発者向け**
- [String.Length プロパティ](https://msdn.microsoft.com/library/system.string.length(v=vs.110).aspx)
