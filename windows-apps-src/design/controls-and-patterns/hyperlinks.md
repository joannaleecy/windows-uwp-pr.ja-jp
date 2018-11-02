---
author: Jwmsft
Description: Hyperlinks navigate the user to another part of the app, to another app, or launch a specific uniform resource identifier (URI) using a separate browser app.
title: ハイパーリンク
ms.assetid: 74302FF0-65FC-4820-B59A-718A765EF7F0
label: Hyperlinks
template: detail.hbs
ms.author: jimwalk
ms.date: 05/19/2017
ms.topic: article
keywords: Windows 10, UWP
pm-contact: kisai
design-contact: kimsea
dev-contact: stpete
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: e6679f789f2530a34a2bf527556c144e7a8e03c3
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/02/2018
ms.locfileid: "5936374"
---
# <a name="hyperlinks"></a>ハイパーリンク

 

ハイパーリンクはユーザーを、アプリの別の部分、別のアプリ、または別のブラウザー アプリを使って呼び出した URI (Uniform Resource Identifier) に誘導します。 XAML アプリにハイパーリンクを追加するには 2 つの方法、**ハイパーリンク** テキスト要素と **HyperlinkButton** コントロールがあります。

> **重要な API**: [ハイパーリンク テキスト要素](https://msdn.microsoft.com/library/windows/apps/dn279356)、[HyperlinkButton コントロール](https://msdn.microsoft.com/library/windows/apps/br242739)

![ハイパーリンク ボタン](images/controls/hyperlink-button.png)


## <a name="is-this-the-right-control"></a>適切なコントロールの選択

ユーザーがテキストを選び、そのテキストに関する詳しい情報が表示される場所に移動するとき、この操作に応答するテキストが必要となる場合に、ハイパーリンクを使います。

必要に応じて適切な種類のハイパーリンクを選んでください。

-   テキスト コントロール内でインライン **ハイパーリンク** テキスト要素を使用します。 ハイパーリンク要素は他のテキスト要素とともに表示され、すべて InlineCollection で使うことができます。 自動テキスト折り返しを必要とするが、大きいサイズのヒット ターゲットを必要としない場合は、テキスト ハイパーリンクを使います。 ハイパーリンク テキストのサイズは小さく、ターゲットとして使うのが難しくなることがあります (特にタッチ操作の場合)。
-   スタンドアロンのハイパーリンクには **HyperlinkButton** を使用します。 HyperlinkButton は、ボタンを使用する任意の場所で使用できる特殊なボタン コントロールです。
-   クリック可能なイメージを作成するには[イメージ](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.image.aspx) と一緒にそのコンテンツとして **HyperlinkButton** を使用します。

## <a name="examples"></a>例

<table>
<th align="left">XAML コントロール ギャラリー<th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックして<a href="xamlcontrolsgallery:/item/HyperlinkButton">アプリを開き、HyperlinkButton の動作を確認</a>してください。</p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics">ソース コード (GitHub) を入手する</a></li>
    </ul>
</td>
</tr>
</table>

## <a name="create-a-hyperlink-text-element"></a>ハイパーリンク テキスト要素を作成する

この例では、[TextBlock](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.textblock.aspx) 内のハイパーリンク テキスト要素の使用方法を示します。

```xml
<StackPanel Width="200">
    <TextBlock Text="Privacy" Style="{StaticResource SubheaderTextBlockStyle}"/>
    <TextBlock TextWrapping="WrapWholeWords">
        <Span xml:space="preserve"><Run>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Read the </Run><Hyperlink NavigateUri="http://www.contoso.com">Contoso Privacy Statement</Hyperlink><Run> in your browser.</Run> Donec pharetra, enim sit amet mattis tincidunt, felis nisi semper lectus, vel porta diam nisi in augue.</Span>
    </TextBlock>
</StackPanel>

```
ハイパーリンクは、インラインで周囲のテキストと表示されます。

![テキスト要素としてのハイパーリンクの例](images/controls_hyperlink-element.png) 

> **ヒント**&nbsp;&nbsp;テキスト コントロールでハイパーリンクを XAML のその他のテキスト要素と一緒に使用する場合、[スパン](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.documents.span.aspx) コンテナーにコンテンツを配置してスパンに `xml:space="preserve"` 属性を適用すると、ハイパーリンクとその他の要素間に空白を保持します。

## <a name="create-a-hyperlinkbutton"></a>HyperlinkButton を作成する

テキストおよび画像の両方で HyperlinkButton を使用する方法を次に示します。

```xml
<StackPanel>
    <TextBlock Text="About" Style="{StaticResource TitleTextBlockStyle}"/>
    <HyperlinkButton NavigateUri="http://www.contoso.com">
        <Image Source="Assets/ContosoLogo.png"/>
    </HyperlinkButton>
    <TextBlock Text="Version: 1.0.0001" Style="{StaticResource CaptionTextBlockStyle}"/>
    <HyperlinkButton Content="Contoso.com" NavigateUri="http://www.contoso.com"/>
    <HyperlinkButton Content="Acknowledgments" NavigateUri="http://www.contoso.com"/>
    <HyperlinkButton Content="Help" NavigateUri="http://www.contoso.com"/>
</StackPanel>

```

テキスト コンテンツの付いたハイパーリンク ボタンは、マークアップ テキストとして表示されます。 Contoso ロゴ画像もクリック可能なハイパーリンクです。

![ボタン コントロールとしてのハイパーリンクの例](images/controls_hyperlink-button-image.png)

次の例は、HyperlinkButton をコードで作成する方法を示しています。

```csharp
var helpLinkButton = new HyperlinkButton();
helpLinkButton.Content = "Help";
helpLinkButton.NavigateUri = new Uri("http://www.contoso.com");
```

## <a name="handle-navigation"></a>ナビゲーションの処理

どちらの種類のハイパーリンクでも同様にナビゲーションを処理します。**NavigateUri** プロパティを設定するか、または**クリック** イベントを処理することができます。

**URI に移動**

ハイパーリンクを使用して URI に移動するには、NavigateUri プロパティを設定します。 ユーザーがハイパーリンクをクリックしてまたはタップすると、指定された URI が既定のブラウザーで開きます。 既定のブラウザーは、アプリと別のプロセスで実行されます。

> [!NOTE]
> URI は [Windows.Foundation.Uri](/uwp/api/windows.foundation.uri) クラスで表されます。 .NET を使用したプログラミングでは、このクラスは表示されないため、[System.Uri](https://docs.microsoft.com/dotnet/api/system.uri)クラスを使用する必要があります。 詳しくは、これらのクラスのリファレンス ページをご覧ください。

**http:** または **https:** スキームを使用する必要はありません。 ブラウザーに読み込むのに適したリソース コンテンツがこれらの場所にある場合は、**ms-appx:**、**ms-appdata:**、または **ms-resources:** などのスキームを使うことができます。 ただし、**file:** スキームは明確に禁止されます。 詳しくは、「[URI スキーム](https://msdn.microsoft.com/library/windows/apps/jj655406.aspx)」 をご覧ください。

ユーザーがハイパーリンクをクリックすると、URI の種類とスキームのシステムのハンドラーに NavigateUri プロパティの値が渡されます。 システムは、NavigateUri の指定された URI のスキームに対して登録されているアプリを起動します。

ハイパーリンクで、コンテンツを既定の Web ブラウザーで読み込む必要がない場合 (ブラウザーを表示しない場合) は、NavigateUri の値を設定しないでください。 代わりに、Click イベントを処理し、目的に合ったコードを記述します。


**Click イベントの処理**

アプリ内のナビゲーションなど、ブラウザーの URI の起動以外の操作に Click イベントを使用します。 たとえば、ブラウザーを開くのではなく、新しいアプリのページを読み込む場合は、クリック イベント ハンドラー内で [Frame.Navigate](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.frame.navigate.aspx) メソッドを呼び出して新しいアプリのページに移動します。 同様にアプリ内にある [WebView](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.webview.aspx) コントロール内で外部の絶対 URI を読み込む場合は、[WebView.Navigate](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.webview.navigate.aspx) を Click ハンドラーのロジックの一部として呼び出します。

通常は、これらはハイパーリンク要素を使用する別の 2 つの方法に相当するので、Click イベントの処理は行わず、NavigateUri 値も指定しません。 既定のブラウザーで URI を開き、NavigateUri の値を指定した場合は、クリック イベントは処理しません。 逆に、クリック イベントを処理する場合は、NavigateUri を指定しないでください。

既定のブラウザーが NavigateUri に指定されている任意の有効なターゲットを読み込むことを防ぐために Click イベント ハンドラー内でできることはありません。ハイパーリンクがアクティブ化されると操作は自動的に (非同期的に) 行われ、Click イベント ハンドラー内で取り消すことはできません。 

## <a name="hyperlink-underlines"></a>ハイパーリンクの下線
既定では、ハイパーリンクに下線が引かれます。 この下線は、アクセシビリティ要件を満たすために役立つので重要です。 色覚に障碍があるユーザーは、ハイパーリンクとその他のテキストを区別するために下線を使用します。 下線を無効にした場合は、ハイパーリンクを他のテキストと区別するために、FontWeight または FontStyle など、他の書式設定の違いを追加することを検討してください。

**ハイパーリンク テキスト要素**

[UnderlineStyle](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.documents.hyperlink.underlinestyle.aspx) プロパティを設定すると下線の表示を無効にすることができます。 これを行う場合は、リンクを表すテキストを区別するために [FontWeight](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.documents.textelement.fontweight.aspx) または [FontStyle](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.documents.textelement.fontstyle.aspx) を使うことを検討します。

**HyperlinkButton** 

既定では、HyperlinkButton は、[Content](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.contentcontrol.content.aspx) プロパティの値として文字列を設定すると、下線付きテキストとして表示されます。

次の場合、テキストは下線付きで表示されません。
- コンテンツのプロパティの値として [TextBlock](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.textblock.aspx) を設定し、TextBlock の [Text](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.textblock.text.aspx) プロパティを設定した場合。
- HyperlinkButton を再テンプレートして [ContentPresenter](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.contentpresenter.aspx) テンプレート パーツの名前を変更した場合。

下線の無いテキストとして表示されるボタンが必要な場合は、標準のボタン コントロールを使い、そのスタイルのプロパティに組み込みの `TextBlockButtonStyle` システム リソースを適用することを検討してください。

## <a name="notes-for-hyperlink-text-element"></a>ハイパーリンク テキスト要素の注意点

このセクションは、ハイパーリンク テキスト要素にのみ該当します。HyperlinkButton コントロールには該当しません。

**入力イベント**

ハイパーリンクは [UIElement](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.aspx) ではないため、Tapped、PointerPressed などの UI 要素の入力イベントのセットはありません。 代わりに、ハイパーリンクには、独自の Click イベントに加えて、NavigateUri として指定されている任意の URI を読み込むシステムの暗黙的な動作があります。 システムは、ハイパーリンクのアクションを呼び出し、応答で Click イベントを発生させる必要があるすべての入力動作を処理します。

**コンテンツ**

ハイパーリンクには、その [Inlines](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.documents.span.inlines.aspx) コレクション内にあるコンテンツの制限があります。 具体的には、ハイパーリンクは、[実行](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.documents.run.aspx)および別のハイパーリンクではないその他の[スパン]() タイプのみ許可します。 [InlineUIContainer](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.documents.inlineuicontainer.aspx) は、ハイパーリンクの Inlines コレクション内にはありません。 制限されたコンテンツを追加しようとすると、無効な引数の例外、または XAML 解析例外がスローされます。

**ハイパーリンクとテーマまたはスタイルの動作**

ハイパーリンクは [コントロール](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.control.aspx) から継承しないため、[Style](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.frameworkelement.style.aspx) プロパティまたは [Template](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.control.template.aspx) がありません。 Foreground または FontFamily など、[TextElement](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.documents.textelement.aspx) から継承されたプロパティを編集してハイパーリンクの外観を変更できますが、一般的なスタイルまたはテンプレートを使用して変更を適用することはできません。 テンプレートを使う代わりに、一貫性を保つためにハイパーリンクのプロパティの値の一般的なリソースの使用を検討してください。 一部のプロパティのハイパーリンクは、システムによって提供される {themeresource} マークアップ拡張機能の値から既定の設定を使用します。 これにより、ハイパーリンクの外観は、実行時にシステム テーマが変更されると、適切な方法で切り替わります。

ハイパーリンクの既定の色は、システムのアクセント カラーです。 [Foreground](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.documents.textelement.foreground.aspx) プロパティを設定するとこれを上書きできます。

## <a name="recommendations"></a>推奨事項

-   ハイパーリンクを使う場合は、移動のみを目的としてください。他の操作のためにハイパーリンクは使わないでください。
-   テキスト ベースのハイパーリンクには、書体見本の本文スタイルを使います。 [フォントと Windows 10 の書体見本](../style/typography.md)に関するページをご覧ください。
-   個々のハイパーリンクの間には十分な間隔を空けます。これにより、それぞれのハイパーリンクを区別することができ、ハイパーリンクを間違えずに選ぶことができます。
-   ユーザーの移動先を示すヒントをハイパーリンクに追加します。 ユーザーが外部サイトに移動する場合は、ヒント内にトップレベルのドメイン名を入れ、補助的なフォント色を使ってそのテキストのスタイルを指定します。

## <a name="get-the-sample-code"></a>サンプル コードを入手する

- [XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - インタラクティブな形で XAML コントロールのすべてを参照できます。

## <a name="related-articles"></a>関連記事

- [テキスト コントロール](text-controls.md)
- [ヒントのガイドライン](tooltips.md)

**開発者向け (XAML)**
- [Windows.UI.Xaml.Documents.Hyperlink クラス](https://msdn.microsoft.com/library/windows/apps/dn279356)
- [Windows.UI.Xaml.Controls.HyperlinkButton クラス](https://msdn.microsoft.com/library/windows/apps/br242739)
