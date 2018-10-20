---
author: Jwmsft
Description: Consider how often we read text in our daily lives - in email, a book, a road sign, the prices on a menu, tire pressure markings, or posters on a street pole.
title: テキスト コントロール
ms.assetid: 43DC68BF-FA86-43D2-8807-70A359453048
label: Text controls
template: detail.hbs
ms.author: jimwalk
ms.date: 10/01/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
pm-contact: miguelrb
design-contact: ksulliv
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 2cd5f7e7022f246fce3d08286fe77c74503ddc5d
ms.sourcegitcommit: 72835733ec429a5deb6a11da4112336746e5e9cf
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/20/2018
ms.locfileid: "5169932"
---
# <a name="text-controls"></a>テキスト コントロール

テキスト コントロールは、テキスト入力ボックス、パスワード ボックス、自動提案ボックス、テキスト ブロックで構成されています。 XAML フレームワークには、テキストのレンダリング、入力、編集用のいくつかのコントロールと、テキストの書式設定用のプロパティのセットが用意されています。

- 読み取り専用テキストを表示するためのコントロールは、[TextBlock](text-block.md) および [RichTextBlock](rich-text-block.md) です。
- テキスト入力と編集用のコントロールは: [TextBox](text-box.md)、 [RichEditBox](rich-edit-box.md)、 [AutoSuggestBox](auto-suggest-box.md)、および[PasswordBox](password-box.md)します。

> **重要な Api**: [TextBlock クラス](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textblock.aspx)、 [RichTextBlock クラス](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richtextblock.aspx)、 [TextBox クラス](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.aspx)、 [RichEditBox クラス](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richeditbox.aspx)、 [AutoSuggestBox クラス](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.aspx)、 [PasswordBox クラス](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.passwordbox.aspx)

## <a name="is-this-the-right-control"></a>適切なコントロールの選択

使うテキスト コントロールは、シナリオによって異なります。 以下の情報を参考にして、アプリに適切なテキスト コントロールを選んでください。

### <a name="render-read-only-text"></a>読み取り専用テキストのレンダリング

**TextBlock** を使用して、アプリ内の読み取り専用テキストの大半を表示します。 これを使用すると、単一行または複数行のテキスト、インライン ハイパーリンク、書式 (太字、斜体、下線付きなど) が設定されたテキストを表示できます。

TextBlock は、一般的に、RichTextBlock より使い方が簡単で、テキスト レンダリングのパフォーマンスが優れているため、ほとんどのアプリで UI テキストに適しています。 [Text](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textblock.text.aspx) プロパティの値を取得することによって、アプリ内で TextBlock のテキストに容易にアクセスして使用することができます。

テキストのレンダリング方法をカスタマイズするための書式設定オプションも、同じものが数多く用意されています。 テキスト内に改行を配置することはできますが、TextBlock は単一の段落を表示するために設計されており、テキストのインデントはサポートされていません。

複数の段落、段組テキスト、インライン UI 要素 (画像など) をサポートする必要がある場合は、**RichTextBlock** を使います。 RichTextBlock には、高度なテキスト レイアウトのための機能がいくつか用意されています。

RichTextBlock のコンテンツ プロパティは [Blocks](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richtextblock.blocks.aspx) プロパティです。このプロパティでは、[Paragraph](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.documents.paragraph.aspx) 要素によって段落に基づくテキストがサポートされています。 アプリ内でコントロールのテキスト コンテンツに簡単にアクセスすることができる **Text** プロパティは含まれていません。  

### <a name="text-input"></a>テキスト入力

ユーザーが書式設定されていないテキストを入力、編集できるようにするには、**TextBox** コントロールを使います。 TextBox 内のテキストの取得と設定には、[Text](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.text.aspx) プロパティを使います。

TextBox を読み取り専用にすることはできますが、これは一時的な条件付きの状態である必要があります。 テキストを編集可能にしない場合は、代わりに TextBlock を使用することを検討してください。

**PasswordBox** コントロールを使用して、パスワードや、社会保障番号などの機密データを収集できます。 パスワード ボックスは、プライバシー保護用に入力文字が非表示になるテキスト入力ボックスです。 パスワード ボックスは、入力されたテキストの代わりに記号が表示される点を除けば、テキスト入力ボックスに似ています。 この記号は、カスタマイズできます。

**AutoSuggestBox** コントロールを使って、ユーザーが入力時に選べる候補リストを表示します。 自動提案ボックスは、基本的な検索候補の一覧をトリガーするテキスト入力ボックスです。 候補となる用語は、一般的な検索用語とユーザーが入力した履歴の組み合わせから取得できます。

また、検索ボックスを実装する場合も、AutoSuggestBox コントロールを使用する必要があります。

**RichEditBox** を使用して、テキスト ファイルを表示および編集します。 その他の標準的なテキスト入力ボックスを使用するように、RichEditBox を使用してアプリにユーザー入力を行わないでください。 代わりに、アプリとは別のテキスト ファイルを操作するために使用します。 通常、RichEditBox に入力されたテキストを .rtf ファイルに保存します。

**テキスト入力は最適な選択肢か**

アプリでユーザー入力を取得するには、さまざまな方法があります。 標準テキスト ボックスのいずれかまたは別のコントロールのどちらがユーザー入力を取得するのに最適であるかを決定する際には、次の点を考慮します。

-   **有効なすべての値を効率的に列挙することが現実的か。** そうである場合は、いずれかの選択コントロールを使うことを検討します。考えられる選択コントロールは、[チェック ボックス](checkbox.md)、[ドロップダウン リスト](lists.md)、リスト ボックス、[ラジオ ボタン](radio-button.md)、[スライダー](slider.md)、[トグル スイッチ](toggles.md)、[日付の選択コントロール](date-and-time.md)、または時刻の選択コントロールです。
-   **有効な値は比較的少数か。** 少数の場合は、[ドロップダウン リスト](lists.md)またはリスト ボックス (値の文字数が多い場合) をお勧めします。
-   **有効なデータに、何も制約がないか。 または、形式の制約 (長さや文字の種類による制約) だけがあるか。** これに該当する場合は、テキスト入力コントロールを使います。 入力できる文字数を制限したり、アプリ コードで形式を検証したりすることができます。
-   **値は専用のコモン コントロールがあるデータ型か。** そうである場合は、テキスト入力コントロールではなく、適切なコントロールを使います。 たとえば、データ入力を受け付けるには、テキスト入力コントロールの代わりに [DatePicker](https://msdn.microsoft.com/library/windows/apps/br211681) を使います。
-   数値データのみに制限されている場合:
    -   **入力される値は、近似値や同じページの別の数量に対する相対値か。** そうである場合は、[スライダー](slider.md)を使います。
    -   **設定の変更による影響をすぐに確認できることがユーザーにとって便利か。** そうである場合は、 [スライダー](slider.md)を使い、必要であれば付随するコントロールも使います。
    -   **入力した結果の確認後 (たとえば、音量や明るさを設定した後など)、入力された値を調整する可能性が高いか。** そうである場合は、[スライダー](slider.md)を使います。

## <a name="examples"></a>例

<table>
<th align="left">XAML コントロール ギャラリー<th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックして<a href="xamlcontrolsgallery:/category/Text">アプリを開き、テキスト コントロールの動作を確認</a>してください。</p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics">ソース コード (GitHub) を入手する</a></li>
    </ul>
</td>
</tr>
</table>

テキスト ボックス

![テキスト ボックス](images/text-box.png)

自動提案ボックス

![展開された自動提案コントロールの例](images/controls_autosuggest_expanded01.png)

パスワード ボックス

![テキスト入力中でフォーカス状態のパスワード ボックス](images/passwordbox-focus-typing.png)

## <a name="create-a-text-control"></a>テキスト コントロールの作成

各テキスト コントロールの詳細と例については、次の記事を参照してください。

-   [AutoSuggestBox](auto-suggest-box.md)
-   [PasswordBox](password-box.md)
-   [RichEditBox](rich-edit-box.md)
-   [RichTextBlock](rich-text-block.md)
-   [TextBlock](text-block.md)
-   [TextBox](text-box.md)

## <a name="font-and-style-guidelines"></a>フォントとスタイルのガイドライン
フォントのガイドラインについては、次の記事を参照してください。

- [文字体裁のガイドライン](../style/typography.md)
- [Segoe MDL2 アイコンの一覧とガイドライン](../style/segoe-ui-symbol-font.md)

## <a name="pen-input"></a>ペン入力

**適用対象:** TextBox、RichEditBox、AutoSuggestBox

Windows 10 バージョン 1803 以降では、XAML テキスト入力ボックスは、[Windows Ink](../input/pen-and-stylus-interactions.md) を使用したペン入力の埋め込みをサポートしています。 ユーザーが Windows ペンを使用してテキスト入力ボックスでタップすると、テキスト ボックスは変換され、ユーザーは別の入力パネルを開かなくても、ペンを使用して直接書き込むことができます。

![ペンでタップするとテキスト ボックスが展開する](images/handwritingview/handwritingview2.gif)

詳しくは、[手書きのビューでのテキスト入力](text-handwriting-view.md)を参照してください。

## <a name="choose-the-right-keyboard-for-your-text-control"></a>テキスト コントロールに適切なキーボードの選択

**適用対象:** TextBox、PasswordBox、RichEditBox

ユーザーがタッチ キーボード、つまりソフト入力パネル (SIP) でデータを入力できるように、ユーザーが入力すると予想されるデータの種類に合わせてテキスト コントロールの入力スコープを設定できます。

>ヒント この情報は、SIP にのみ適用されます。 ハードウェア キーボードにも、Windows の簡単操作オプションで使用できるスクリーン キーボードにも適用されません。

タッチ キーボードは、アプリがタッチ スクリーン付きのデバイスで実行されているときにテキスト入力に使うことができます。 タッチ キーボードは、TextBox または RichEditBox などの編集可能な入力フィールドをユーザーがタップしたときに呼び出されます。 ユーザーが入力すると予想されるデータの種類と一致するようにテキスト コントロールの入力スコープを設定することで、ユーザーがより速く簡単にアプリにデータを入力できるようになります。 入力値の種類は、システムに対してコントロールが予期しているテキスト入力の種類のヒントとなるため、システムはその入力の種類用の特殊なタッチ キーボード レイアウトを提供できます。

たとえば、テキスト ボックスが 4 桁の PIN の入力専用の場合は、[InputScope](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.inputscope.aspx) プロパティを **Number** に設定します。 これにより、システムに数字キーパッド レイアウトの表示が指示されるため、ユーザーは簡単に PIN を入力できます。

>重要  
>入力スコープの設定によって、入力の検証が実行されるわけではありません。また、ユーザーが、ハードウェア キーボードやその他の入力デバイスから入力できなくなることもありません。 必要に応じて、コードで入力を検証する必要があります。

詳しくは、「[入力値の種類を使ったタッチ キーボードの変更](https://msdn.microsoft.com/library/windows/apps/mt280229)」をご覧ください。

## <a name="color-fonts"></a>カラー フォント

**適用対象:** TextBlock、RichTextBlock、TextBox、RichEditBox

Windows には、フォントに各グリフの複数の色付きレイヤーを含めるための機能があります。 たとえば、Segoe UI Emoji フォントは、顔文字とその他の絵文字のカラー バージョンを定義します。

標準テキスト コントロールとリッチ テキスト コントロールは、カラー フォントの表示をサポートしています。 既定では、**IsColorFontEnabled** プロパティは **true** であり、これらの追加のレイヤーを使用するフォントはカラーでレンダリングされます。 システムに既定のカラー フォントは Segoe UI Emoji フォントで、コントロールはこのフォントにフォールバックしてグリフをカラーで表示します。

```xaml
<TextBlock FontSize="30">Hello ☺⛄☂♨⛅</TextBlock>
```

レンダリングされたテキストは次のようになります。

![カラー フォントを使用したテキスト ブロック](images/text-block-color-fonts.png)

詳しくは、[IsColorFontEnabled](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textblock.iscolorfontenabled.aspx) プロパティに関するトピックをご覧ください。

## <a name="guidelines-for-line-and-paragraph-separators"></a>行と段落の区切り記号のガイドライン

**適用対象:** TextBlock、RichTextBlock、複数行 TextBox、RichEditBox

行の区切り文字 (0x2028) と段落の区切り文字 (0x2029) を使用すると、プレーンテキストを分割できます。 各行区切り文字の後に新しい行が開始されます。 各段落区切り文字の後に新しい段落が開始されます。

ファイルの最初の行や段落をこれらの文字で始める必要はなく、最後の行や段落をこれらの文字で終わる必要はありません。これらの文字を使用した場合、その位置に空の行または段落があることを意味します。

アプリでは、行の区切り記号を使って無条件の行の終わりを示すことができます。 ただし、行の区切り記号は、独立した復帰文字や改行文字またはこれらの文字の組み合わせに対応していません。 行の区切り記号は、復帰文字や改行文字とは別に処理する必要があります。

アプリでは、テキストの段落の間の段落の区切り記号を挿入できます。 この区切り記号を使用すると、さまざまなオペレーティング システムで異なる行の幅で書式設定できるプレーンテキスト ファイルを作成できます。 ターゲット システムでは、行の区切り記号を無視し、段落の区切り記号でのみ段落を分割することができます。

## <a name="guidelines-for-spell-checking"></a>スペル チェックのガイドライン

**適用対象:** TextBox、RichEditBox

テキストの入力と編集を行っているときに、スペル チェックは単語を赤い波線で強調表示してユーザーに単語のスペルの間違いを知らせ、それを修正する方法を提供します。

組み込みスペル チェックの例を次に示します。

![組み込みスペル チェック](images/spellchecking.png)

テキスト入力コントロールでのスペル チェックは、次の 2 つの目的で使います。

-   **スペル ミスを自動修正する**

    スペル チェック エンジンは、単語にスペルの間違いがあり、修正が確実であれば自動的に修正します。 たとえば、エンジンは自動的に "teh" を "the" に変更します。

-   **代わりのスペルを示す**

    修正が確実でないとスペル チェック エンジンが判断した場合、スペル ミスのある単語には赤い下線が引かれ、ユーザーがその単語をタップするか右クリックすると、ショートカット メニューに修正候補が表示されます。

-   スペル チェックは、テキスト入力コントロールに単語や文を入力するときにユーザーを補助するために使います。 スペル チェックは、タッチ、マウス、キーボード入力で機能します。
-   単語が辞書になさそうな場合や、ユーザーがスペル チェックを重視しない場合は、スペル チェックを使わないでください。 たとえば、電話番号または名前をキャプチャするためのテキスト ボックスでは、スペル チェックを有効にしません。
-   現在のスペル チェック エンジンがアプリの言語をサポートしていないという理由だけで、スペル チェックを無効にしないでください。 スペル チェックでその言語がサポートされていない場合は、何も行われないので、有効にしたままで何も問題がありません。 また、一部のユーザーは Input Method Editor (IME) を使ってアプリに他の言語を入力する場合があり、その言語がサポートされている可能性もあります。 たとえば、日本語のアプリを構築している場合には、現在はスペル チェック エンジンが日本語を認識していなくても、スペル チェックを無効にしないでください。 ユーザーが英語 IME に切り替え、アプリに英語を入力する場合があります。スペル チェックが有効になっていれば、英語のスペル チェックが行われます。

TextBox コントロールおよび RichEditBox コントロールでは、スペル チェックが既定で有効になっています。 **IsSpellCheckEnabled** プロパティを **false** に設定することによって無効にできます。

## <a name="related-articles"></a>関連記事

**設計者向け**
- [文字体裁のガイドライン](../style/typography.md)
- [Segoe MDL2 アイコンの一覧とガイドライン](../style/segoe-ui-symbol-font.md)
- [検索の追加](https://msdn.microsoft.com/library/windows/apps/hh465231)

**開発者向け (XAML)**
- [TextBox クラス](https://msdn.microsoft.com/library/windows/apps/br209683)
- [Windows.UI.Xaml.Controls PasswordBox クラス](https://msdn.microsoft.com/library/windows/apps/br227519)
- [String.Length プロパティ](https://msdn.microsoft.com/library/system.string.length.aspx)
