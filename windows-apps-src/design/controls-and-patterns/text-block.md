---
ms.assetid: DA562509-D893-425A-AAE6-B2AE9E9F8A19
Description: テキスト ブロックは、アプリで読み取り専用テキストを表示するためのプライマリ コントロールです。
title: テキスト ブロック
label: Text block
template: detail.hbs
ms.date: 05/19/2017
ms.topic: article
keywords: windows 10, uwp
pm-contact: miguelrb
design-contact: ksulliv
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 692b8837f3bd74dfc5f74bee02786213c9a898f2
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57599387"
---
# <a name="text-block"></a>テキスト ブロック

 

 テキスト ブロックは、アプリで読み取り専用テキストを表示するためのプライマリ コントロールです。 これを使用すると、単一行または複数行のテキスト、インライン ハイパーリンク、書式 (太字、斜体、下線付きなど) が設定されたテキストを表示できます。
 
 > **重要な Api**:[TextBlock クラス](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textblock.aspx)、 [Text プロパティ](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textblock.text.aspx)、 [Inlines プロパティ](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textblock.inlines.aspx)

## <a name="is-this-the-right-control"></a>適切なコントロールの選択

テキスト ブロックは、一般的に、リッチ テキスト ブロックより使い方が簡単で、テキスト レンダリングのパフォーマンスが優れているため、ほとんどのアプリで UI テキストに適しています。 [Text](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textblock.text.aspx) プロパティの値を取得することによって、アプリ内でテキスト ブロックのテキストに容易にアクセスして使用することができます。 テキストのレンダリング方法をカスタマイズするための書式設定オプションも、同じものが数多く用意されています。

テキスト内に改行を配置することはできますが、テキスト ブロックは単一の段落を表示するために設計されており、テキストのインデントはサポートされていません。 複数の段落、段組テキスト、インライン UI 要素 (画像など) をサポートする必要がある場合は、**RichTextBlock** を使います。

適切なテキスト コントロールの選択について詳しくは、「[テキスト コントロール](text-controls.md)」をご覧ください。

## <a name="examples"></a>例

<table>
<th align="left">XAML コントロール ギャラリー<th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックして<a href="xamlcontrolsgallery:/item/TextBlock">アプリを開き、TextBlock の動作を確認</a>してください。</p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">XAML コントロール ギャラリー アプリ (Microsoft Store) を入手します。</a></li>
    <li><a href="https://github.com/Microsoft/Xaml-Controls-Gallery">ソース コード (GitHub) を取得します。</a></li>
    </ul>
</td>
</tr>
</table>

## <a name="create-a-text-block"></a>テキスト ブロックの作成

ここでは、単純な TextBlock コントロールを定義し、その Text プロパティを文字列に設定する方法を示します。

```xaml
<TextBlock Text="Hello, world!" />
```

```csharp
TextBlock textBlock1 = new TextBlock();
textBlock1.Text = "Hello, world!";
```

    <TextBlock Text="Hello, world!" />

    TextBlock textBlock1 = new TextBlock();
    textBlock1.Text = "Hello, world!";

### <a name="content-model"></a>コンテンツ モデル

これには TextBlock にコンテンツを追加する際の 2 つのプロパティがあります。[テキスト](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textblock.text.aspx)と[Inlines](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textblock.inlines.aspx)します。

テキストを表示する最も一般的な方法は、前の例で示したように Text プロパティを文字列値に設定することです。

また、次のように、TextBox.Inlines プロパティにインライン フロー コンテンツ要素を配置することで、コンテンツを追加することもできます。
```xaml
<TextBlock>Text can be <Bold>bold</Bold>, <Underline>underlined</Underline>, 
    <Italic>italic</Italic>, or a <Bold><Italic>combination</Italic></Bold>.</TextBlock>
```

Inline クラスから派生した要素 (Bold、Italic、Run、Span、LineBreak など) を使用すると、テキスト内の部分によって別々の書式を有効にすることができます。 詳しくは、「[テキストの書式設定](#formatting-text)」をご覧ください。 インラインの Hyperlink 要素を使うと、テキストにハイパーリンクを追加することができます。 ただし、Inlines を使用すると、テキストの高速パス レンダリングが無効になります。これについては、次のセクションで説明します。


## <a name="performance-considerations"></a>パフォーマンスに関する考慮事項

可能であれば、XAML ではより効率的なコード パスを使ってテキストをレイアウトします。 この高速パスを使うと、全体的なメモリ使用量が減少し、テキストのサイズ測定と配置を実行するための CPU 時間が大幅に減少します。 この高速パスは TextBlock にのみ適用されるため、可能な場合 RichTextBlock よりも優先されます。

特定の条件では、TextBlock のテキストのレンダリングはより高機能な CPU 負荷の高いコード パスにフォールバックされます。 常に高速パスでテキスト レンダリングを処理するために、次に示すプロパティを設定するときは、以下のガイドラインに従ってください。
- [テキスト](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textblock.text.aspx):最も重要な条件では、XAML またはコード (前の例で示す) のように、Text プロパティを明示的に設定してテキストを設定する場合にのみ、高速パスを使用します。 TextBlock の Inlines コレクション (`<TextBlock>Inline text</TextBlock>` など) によってテキストを設定すると、複数の形式の潜在的な複雑さのために、高速パスが無効になります。
- [CharacterSpacing](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textblock.characterspacing.aspx):既定値の 0 だけには、高速のパスです。
- [TextTrimming](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textblock.texttrimming.aspx):のみ、 **None**、 **CharacterEllipsis**、および**WordEllipsis**値は、高速なパス。 **Clip** 値は高速パスを無効にします。

> **注**&nbsp;&nbsp;Windows 10 Version 1607 より前のバージョンでは、他のプロパティも高速パスに影響を与えます。 以前のバージョンの Windows でアプリが実行される場合は、以下の条件によってもテキストは低速パスでレンダリングされます。 バージョンについて詳しくは、バージョン アダプティブ コードを参照してください。
- [文字体裁](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.documents.typography.aspx):さまざまな文字体裁プロパティの既定値だけは、高速なパスです。
- [LineStackingStrategy](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textblock.linestackingstrategy.aspx):場合[LineHeight](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textblock.lineheight.aspx)が 0 ではなく、 **BaselineToBaseline**と**MaxHeight**値には、高速パスが無効にします。
- [IsTextSelectionEnabled](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textblock.istextselectionenabled.aspx):のみ**false**は高速なパスです。 このプロパティを **true** に設定すると、高速パスが無効になります。

デバッグ中に [DebugSettings.IsTextPerformanceVisualizationEnabled](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.debugsettings.istextperformancevisualizationenabled.aspx) プロパティを **true** に設定すると、テキストのレンダリングに高速パスが使用されているかどうかを特定できます。 このプロパティを true に設定すると、高速パスにあるテキストは明るい緑色で表示されます。

>**ヒント:**&nbsp;&nbsp;このセッションでは、この機能の詳細に説明からビルド 2015- [XAML のパフォーマンス。XAML でユニバーサル Windows アプリのエクスペリエンスを最大化するための手法がビルドされた](https://channel9.msdn.com/Events/Build/2015/3-698)します。



通常、次のように、App.xaml の分離コード ページの [OnLaunched](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.application.onlaunched.aspx) メソッドのオーバーライドでデバッグの設定を行います。
```csharp
protected override void OnLaunched(LaunchActivatedEventArgs e)
{
#if DEBUG
    if (System.Diagnostics.Debugger.IsAttached)
    {
        this.DebugSettings.IsTextPerformanceVisualizationEnabled = true;
    }
#endif

// ...

}
```

この例では、最初の TextBlock は高速パスを使用してレンダリングされますが、2 番目の TextBlock は高速パスでレンダリングされません。
```xaml
<StackPanel>
    <TextBlock Text="This text is on the fast path."/>
    <TextBlock>This text is NOT on the fast path.</TextBlock>
<StackPanel/>
```

IsTextPerformanceVisualizationEnabled を true に設定してデバッグ モードでこの XAML を実行すると、次のような結果になります。

![デバッグ モードでレンダリングされたテキスト](images/text-block-rendering-performance.png)

>**注意**&nbsp;&nbsp;高速パスにないテキストの色は変更されません。 アプリ内に、明るい緑色として指定された色のテキストがある場合、レンダリング パスが低速であれば、引き続き明るい緑色として表示されます。 テキストが高速パスにあるアプリで緑色に設定されたテキストと、デバッグ設定による緑色を混同しないように注意してください。

## <a name="formatting-text"></a>テキストの書式設定

Text プロパティに格納されるのはプレーンテキストですが、各種の書式設定オプションを TextBlock コントロールに適用して、アプリでテキストをレンダリングする方法をカスタマイズすることができます。 FontFamily、FontSize、FontStyle、Foreground、CharacterSpacing などの標準的なコントロール プロパティを設定して、テキストの外観を変更できます。 インライン テキスト要素と Typography 添付プロパティを使ってテキストを書式設定することもできます。 これらのオプションが影響を与えるのは、TextBlock がローカルでテキストを表示する方法だけです。したがって、テキストをコピーしてリッチ テキスト コントロールなどに貼り付けても、書式設定は適用されません。

>**注**&nbsp;&nbsp;前のセクションで説明したように、インライン テキスト要素と既定以外の文字体裁値は、高速パスでレンダリングされません。


### <a name="inline-elements"></a>インライン要素

[Windows.UI.Xaml.Documents](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.documents.aspx) 名前空間には、テキストの書式設定に使うことができるさまざまなインライン テキスト要素が用意されています (Bold、Italic、Run、Span、LineBreak など)。

それぞれ書式設定の異なる複数の文字列を TextBlock に表示できます。 そのためには、Run 要素を使って各文字列をそれぞれの書式設定で表示し、各 Run 要素を LineBreak 要素で区切ります。

次の例は、LineBreak で区切られた Run オブジェクトを使って、書式設定の異なる複数のテキスト文字列を TextBlock に定義する方法を示しています。
```xaml
<TextBlock FontFamily="Segoe UI" Width="400" Text="Sample text formatting runs">
    <LineBreak/>
    <Run Foreground="Gray" FontFamily="Segoe UI Light" FontSize="24">
        Segoe UI Light 24
    </Run>
    <LineBreak/>
    <Run Foreground="Teal" FontFamily="Georgia" FontSize="18" FontStyle="Italic">
        Georgia Italic 18
    </Run>
    <LineBreak/>
    <Run Foreground="Black" FontFamily="Arial" FontSize="14" FontWeight="Bold">
        Arial Bold 14
    </Run>
</TextBlock>
```

結果は次のようになります。

![Run 要素で書式設定されたテキスト](images/text-block-run-examples.png)

### <a name="typography"></a>文字体裁

[Typography](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.documents.typography.aspx) クラスの添付プロパティは、Microsoft OpenType の一連の Typography プロパティへのアクセスを提供します。 これらの添付プロパティは、TextBlock で設定することも、個々のインライン テキスト要素で設定することもできます。 次の例では、両方を示します。
```xaml
<TextBlock Text="Hello, world!"
           Typography.Capitals="SmallCaps"
           Typography.StylisticSet4="True"/>
```

```csharp
TextBlock textBlock1 = new TextBlock();
textBlock1.Text = "Hello, world!";
Windows.UI.Xaml.Documents.Typography.SetCapitals(textBlock1, FontCapitals.SmallCaps);
Windows.UI.Xaml.Documents.Typography.SetStylisticSet4(textBlock1, true);
```

```xaml
<TextBlock>12 x <Run Typography.Fraction="Slashed">1/3</Run> = 4.</TextBlock>
```

## <a name="get-the-sample-code"></a>サンプル コードを入手する

- [XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Xaml-Controls-Gallery) - インタラクティブな形で XAML コントロールのすべてを参照できます。

## <a name="related-articles"></a>関連記事

- [テキスト コントロール](text-controls.md)
- [スペル チェックするためのガイドライン](text-controls.md)
- [検索の追加](search.md)
- [テキスト入力するためのガイドライン](text-controls.md)
- [TextBox クラス](https://msdn.microsoft.com/library/windows/apps/br209683)
- [Windows.UI.Xaml.Controls PasswordBox クラス](https://msdn.microsoft.com/library/windows/apps/br227519)
- [String.Length プロパティ](https://msdn.microsoft.com/library/system.string.length(v=vs.110).aspx)
