---
Description: ユニバーサル Windows プラットフォーム (UWP) アプリをアクセシビリティ対応にするために役立つチェック リストを示します。
title: アクセシビリティのチェック リスト
ms.assetid: BB8399E2-7013-4F77-AF2C-C1A0E5412856
label: チェック リスト
template: detail.hbs
---

アクセシビリティのチェック リスト
===================================================================================

\[ Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132) をご覧ください \]

ユニバーサル Windows プラットフォーム (UWP) アプリをアクセシビリティ対応にするために役立つチェック リストを示します。

ここでは、アプリをアクセシビリティ対応にするときに使用できるチェック リストを示します。

1.  コンテンツやアプリの対話型の UI 要素にアクセシビリティ対応の名前 (必須) と説明 (省略可能) を設定します。

    アクセシビリティ対応の名前とは、スクリーン リーダーが UI 要素を読み上げるときに使う短い説明の文字列です。 [
            **TextBlock**](https://msdn.microsoft.com/library/windows/apps/BR209652) や [**TextBox**](https://msdn.microsoft.com/library/windows/apps/BR209683) などの一部の UI 要素では、既定のアクセシビリティ対応の名前としてテキスト コンテンツを昇格させるものがあります。「[基本的なアクセシビリティ情報](basic-accessibility-information.md#name_from_inner_text)」をご覧ください。

    暗黙的なアクセシビリティ対応の名前として内部テキスト コンテンツを昇格させない画像などのコントロールに対し、明示的にアクセシビリティ対応の名前を設定する必要があります。 フォーム要素のラベルのテキストは、ラベルと入力を関連付けるために、Microsoft UI オートメーション モデルの [**LabeledBy**](https://msdn.microsoft.com/library/windows/apps/Hh759769) ターゲットとして使うことができるようにする必要があります。 ユーザーに、通常アクセシビリティ対応の名前に含まれているものよりも詳しい UI のガイダンスを提供する場合は、アクセシビリティ対応の説明やヒントを用意すると、UI の内容がわかりやすくなります。

    詳しくは、「[アクセシビリティ対応の名前](basic-accessibility-information.md#accessible_name)」と「[アクセシビリティ対応の説明](basic-accessibility-information.md)」をご覧ください。

2.  キーボード アクセシビリティを実装します。


    -   Test the default tab index order for a UI. Adjust the tab index order if necessary, which may require enabling or disabling certain controls, or changing the default values of [**TabIndex**](https://msdn.microsoft.com/library/windows/apps/BR209461) on some of the UI elements.
    -   Use controls that support arrow-key navigation for composite elements. For default controls, the arrow-key navigation is typically already implemented.
    -   Use controls that support keyboard activation. For default controls, particularly those that support the UI Automation [**Invoke**](https://msdn.microsoft.com/library/windows/apps/BR242582) pattern, keyboard activation is typically available; check the documentation for that control.
    -   Set access keys or implement accelerator keys for specific parts of the UI that support interaction.
    -   For any custom controls that you use in your UI, verify that you have implemented these controls with correct [**AutomationPeer**](https://msdn.microsoft.com/library/windows/apps/BR209185) support for activation, and defined overrides for key handling as needed to support activation, traversal and access or accelerator keys.

    For more info, see [Keyboard interactions](https://msdn.microsoft.com/library/windows/apps/Mt185607).

3.  テキスト コントラストが適切であること、ハイ コントラスト テーマで要素が正しくレンダリングされること、色が正しく使われていることを確認するため、UI を表示して検証します。

    -   ディスプレイの 1 インチあたりのドット数 (dpi) の値を調整するシステム ディスプレイ オプションを使い、DPI の値の変更に合わせてアプリの UI が正常に拡大縮小されることを確認します (一部のユーザーはアクセシビリティ対応オプションとして DPI の値を変更します。これは、**[コンピューターの簡単操作]** から設定できます)。
    -   色分析ツールを使って、視覚的なテキストのコントラスト比が 4.5:1 以上であることを検証します。
    -   ハイ コントラスト テーマに切り替え、アプリの UI が読みやすく使いやすいことを確認します。
    -   UI が情報を伝える唯一の手段として色を使っていないことを確認します。

    詳しくは、「[ハイ コントラスト テーマ](high-contrast-themes.md)」と「[アクセシビリティに対応したテキストの要件](accessible-text-requirements.md)」をご覧ください。

4.  アクセシビリティ ツールを実行し、報告された問題に対処して、画面の読み上げを確認します。

    [
            **Inspect**](https://msdn.microsoft.com/library/windows/desktop/Dd318521) などのツールを使ってプログラムによるアクセスを検証し、[**AccChecker**](https://msdn.microsoft.com/library/windows/desktop/Hh920985) などの診断ツールを実行して一般的なエラーを見つけます。画面の読み上げの確認には、ナレーターを使います。

    詳しくは、「[アクセシビリティ テスト](accessibility-testing.md)」をご覧ください。

5.  アプリ マニフェストの設定がアクセシビリティ ガイドラインに準拠しているかどうかを確認します。

6.  Windows ストアでアプリがアクセシビリティ対応であることを宣言します。

    アクセシビリティ サポートの基準を実装したら、Windows ストアでアプリがアクセシビリティ対応であることを宣言することで、より多くのユーザーにアプリを提供し、さらに良い評価を得ることができます。

    詳しくは、「[ストア内のアクセシビリティ](accessibility-in-the-store.md)」をご覧ください。

関連トピック
-----------------------------------------------

* [アクセシビリティ](accessibility.md)
* [アクセシビリティのための設計](https://msdn.microsoft.com/library/windows/apps/Hh700407)
* [避ける事項](practices-to-avoid.md)
 

 





<!--HONumber=Mar16_HO1-->


