---
author: Jwmsft
Description: メール、本、道路標識、メニューに書かれた価格、タイヤの空気圧のマーキング、道路脇のポールに掲示されたポスターなど、日常生活の中で文字を目にする機会はたくさんあります。
title: テキスト コントロール
ms.assetid: 43DC68BF-FA86-43D2-8807-70A359453048
label: Text controls
template: detail.hbs
---
# テキスト コントロール
テキスト コントロールは、テキスト入力ボックス、パスワード ボックス、自動提案ボックス、テキスト ブロックで構成されています。 XAML フレームワークには、テキストのレンダリング、入力、編集用のいくつかのコントロールと、テキストの書式設定用のプロパティのセットが用意されています。

- 読み取り専用テキストを表示するためのコントロールは、[TextBlock](text-block.md) および [RichTextBlock](rich-text-block.md) です。
- テキストの入力と編集用のコントロールは、[TextBox](text-block.md)、[AutoSuggestBox](auto-suggest-box.md)、[PasswordBox](password-box.md)、[RichEditBox](rich-edit-box.md) です。 


<span class="sidebar_heading" style="font-weight: bold;">重要な API</span>

-   [**AutoSuggestBox クラス**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.aspx)
-   [**PasswordBox クラス**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.passwordbox.aspx)
-   [**RichEditBox クラス**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richeditbox.aspx)
-   [**RichTextBlock クラス**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richtextblock.aspx)
-   [**TextBlock クラス**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textblock.aspx)
-   [**TextBox クラス**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.aspx)

## 適切なコントロールの選択

使うテキスト コントロールは、シナリオによって異なります。 以下の情報を参考にして、アプリに適切なテキスト コントロールを選んでください。

### 読み取り専用テキストのレンダリング

**TextBlock** を使用して、アプリ内の読み取り専用テキストの大半を表示します。 これを使用すると、単一行または複数行のテキスト、インライン ハイパーリンク、書式 (太字、斜体、下線付きなど) が設定されたテキストを表示できます。

TextBlock は、一般的に、RichTextBlock より使い方が簡単で、テキスト レンダリングのパフォーマンスが優れているため、ほとんどのアプリで UI テキストに適しています。 [Text](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textblock.text.aspx) プロパティの値を取得することによって、アプリ内で TextBlock のテキストに容易にアクセスして使用することができます。 

テキストのレンダリング方法をカスタマイズするための書式設定オプションも、同じものが数多く用意されています。 テキスト内に改行を配置することはできますが、TextBlock は単一の段落を表示するために設計されており、テキストのインデントはサポートされていません。

複数の段落、段組テキスト、インライン UI 要素 (画像など) をサポートする必要がある場合は、**RichTextBlock** を使います。 RichTextBlock には、高度なテキスト レイアウトのための機能がいくつか用意されています。

RichTextBlock のコンテンツ プロパティは [Blocks](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richtextblock.blocks.aspx) プロパティです。このプロパティでは、[Paragraph](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.documents.paragraph.aspx) 要素によって段落に基づくテキストがサポートされています。 アプリ内でコントロールのテキスト コンテンツに簡単にアクセスすることができる **Text** プロパティは含まれていません。  

### テキスト入力

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
-   **値は専用のコモン コントロールがあるデータ型か。** そうである場合は、テキスト入力コントロールではなく、適切なコントロールを使います。 たとえば、日付の入力を受け付けるには、テキスト入力コントロールの代わりに [**DatePicker**](https://msdn.microsoft.com/library/windows/apps/br211681) を使います。
-   数値データのみに制限されている場合:
    -   **入力される値は、近似値や同じページの別の数量に対する相対値か。** そうである場合は、[スライダー](slider.md)を使います。
    -   **設定の変更による影響をすぐに確認できることがユーザーにとって便利か。** そうである場合は、 [スライダー](slider.md)を使い、必要であれば付随するコントロールも使います。
    -   **入力した結果の確認後 (たとえば、音量や明るさを設定した後など)、入力された値を調整する可能性が高いか。** そうである場合は、[スライダー](slider.md)を使います。
    
## 例

テキスト ボックス

![テキスト ボックス](images/text-box.png)

自動提案ボックス

![展開された自動提案コントロールの例](images/controls_autosuggest_expanded01.png)

パスワード ボックス

![テキスト入力中でフォーカス状態のパスワード ボックス](images/passwordbox-focus-typing.png)

## テキスト コントロールの作成

各テキスト コントロールの詳細と例については、次の記事を参照してください。

-   [**AutoSuggestBox**](auto-suggest-box.md)
-   [**PasswordBox**](password-box.md)
-   [**RichEditBox**](rich-edit-box.md)
-   [**RichTextBlock**](rich-text-block.md)
-   [**TextBlock**](text-block.md)
-   [**TextBox**](text-box.md)

## フォントとスタイルのガイドライン
フォントのガイドラインについては、次の記事を参照してください。

- [**フォントのガイドライン**](fonts.md)
- [**Segoe MDL2 アイコンの一覧とガイドライン**](segoe-ui-symbol-font.md)


## テキスト コントロールに適切なキーボードの選択

**適用対象:** TextBox、PasswordBox、RichEditBox

ユーザーがタッチ キーボード、つまりソフト入力パネル (SIP) でデータを入力できるように、ユーザーが入力すると予想されるデータの種類に合わせてテキスト コントロールの入力スコープを設定できます。

>ヒント この情報は、SIP にのみ適用されます。 ハードウェア キーボードにも、Windows の簡単操作オプションで使用できるスクリーン キーボードにも適用されません。

タッチ キーボードは、アプリがタッチ スクリーン付きのデバイスで実行されているときにテキスト入力に使うことができます。 タッチ キーボードは、TextBox または RichEditBox などの編集可能な入力フィールドをユーザーがタップしたときに呼び出されます。 ユーザーが入力すると予想されるデータの種類と一致するようにテキスト コントロールの入力スコープを設定することで、ユーザーがより速く簡単にアプリにデータを入力できるようになります。 入力値の種類は、システムに対してコントロールが予期しているテキスト入力の種類のヒントとなるため、システムはその入力の種類用の特殊なタッチ キーボード レイアウトを提供できます。

たとえば、テキスト ボックスが 4 桁の PIN の入力専用の場合は、[InputScope](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.inputscope.aspx) プロパティを **Number** に設定します。 これにより、システムに数字キーパッド レイアウトの表示が指示されるため、ユーザーは簡単に PIN を入力できます。

>重要  
>入力スコープの設定によって、入力の検証が実行されるわけではありません。また、ユーザーが、ハードウェア キーボードやその他の入力デバイスから入力できなくなることもありません。 必要に応じて、コードで入力を検証する必要があります。

詳しくは、「[入力値の種類を使ったタッチ キーボードの変更]()」をご覧ください。

## カラー フォント

**適用対象:** TextBlock、RichTextBlock、TextBox、RichEditBox

Windows には、フォントに各グリフの複数の色付きレイヤーを含めるための機能があります。 たとえば、Segoe UI Emoji フォントは、顔文字とその他の絵文字のカラー バージョンを定義します。 

標準テキスト コントロールとリッチ テキスト コントロールは、カラー フォントの表示をサポートしています。 既定では、**IsColorFontEnabled** プロパティは **true** であり、これらの追加のレイヤーを使用するフォントはカラーでレンダリングされます。 システムに既定のカラー フォントは Segoe UI Emoji フォントで、コントロールはこのフォントにフォールバックしてグリフをカラーで表示します。 

```xaml
<TextBlock FontSize="30">Hello ☺⛄☂♨⛅</TextBlock>
```

レンダリングされたテキストは次のようになります。

![カラー フォントを使用したテキスト ブロック](images/text-block-color-fonts.png)

詳しくは、[**IsColorFontEnabled**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textblock.iscolorfontenabled.aspx) プロパティに関するトピックをご覧ください。

## 行と段落の区切り記号のガイドライン

**適用対象:** TextBlock、RichTextBlock、複数行 TextBox、RichEditBox

行の区切り文字 (0x2028) と段落の区切り文字 (0x2029) を使用すると、プレーンテキストを分割できます。 各行区切り文字の後に新しい行が開始されます。 各段落区切り文字の後に新しい段落が開始されます。

ファイルの最初の行や段落をこれらの文字で始める必要はなく、最後の行や段落をこれらの文字で終わる必要はありません。これらの文字を使用した場合、その位置に空の行または段落があることを意味します。

アプリでは、行の区切り記号を使って無条件の行の終わりを示すことができます。 ただし、行の区切り記号は、独立した復帰文字や改行文字またはこれらの文字の組み合わせに対応していません。 行の区切り記号は、復帰文字や改行文字とは別に処理する必要があります。

アプリでは、テキストの段落の間の段落の区切り記号を挿入できます。 この区切り記号を使用すると、さまざまなオペレーティング システムで異なる行の幅で書式設定できるプレーンテキスト ファイルを作成できます。 ターゲット システムでは、行の区切り記号を無視し、段落の区切り記号でのみ段落を分割することができます。



## 関連記事

**デザイナー向け**
- [**フォントのガイドライン**](fonts.md)
- [**Segoe MDL2 アイコンの一覧とガイドライン**](segoe-ui-symbol-font.md)
- [スペル チェックのガイドライン](spell-checking-and-prediction.md)
- [検索の追加](https://msdn.microsoft.com/library/windows/apps/hh465231)

**開発者向け (XAML)**
- [**TextBox クラス**](https://msdn.microsoft.com/library/windows/apps/br209683)
- [**Windows.UI.Xaml.Controls PasswordBox クラス**](https://msdn.microsoft.com/library/windows/apps/br227519)
- [String.Length プロパティ](https://msdn.microsoft.com/library/system.string.length.aspx)


<!--HONumber=May16_HO2-->


