---
Description: ユニバーサル Windows プラットフォーム (UWP) アプリをアクセシビリティ対応にするために役立つチェック リストを示します。
ms.assetid: BB8399E2-7013-4F77-AF2C-C1A0E5412856
title: アクセシビリティのチェック リスト
label: Accessibility checklist
template: detail.hbs
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: c9ff9760b3ae9b852fe1ae1b86d1cc48e49c5dd4
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57602447"
---
# <a name="accessibility-checklist"></a>アクセシビリティのチェック リスト

ユニバーサル Windows プラットフォーム (UWP) アプリをアクセシビリティ対応にするために役立つチェック リストを示します。

ここでは、アプリをアクセシビリティ対応にするときに使用できるチェック リストを示します。

1. コンテンツやアプリの対話型の UI 要素にアクセシビリティ対応の名前 (必須) と説明 (省略可能) を設定します。

    アクセシビリティ対応の名前とは、スクリーン リーダーが UI 要素を読み上げるときに使う短い説明の文字列です。 [  **TextBlock**](https://msdn.microsoft.com/library/windows/apps/BR209652) や [**TextBox**](https://msdn.microsoft.com/library/windows/apps/BR209683) などの一部の UI 要素では、既定のアクセシビリティ対応の名前としてテキスト コンテンツを昇格させるものがあります。「[基本的なアクセシビリティ情報](basic-accessibility-information.md#name_from_inner_text)」をご覧ください。

    暗黙的なアクセシビリティ対応の名前として内部テキスト コンテンツを昇格させない画像などのコントロールに対し、明示的にアクセシビリティ対応の名前を設定する必要があります。 フォーム要素のラベルのテキストは、ラベルと入力を関連付けるために、Microsoft UI オートメーション モデルの [**LabeledBy**](https://msdn.microsoft.com/library/windows/apps/Hh759769) ターゲットとして使うことができるようにする必要があります。 ユーザーに、通常アクセシビリティ対応の名前に含まれているものよりも詳しい UI のガイダンスを提供する場合は、アクセシビリティ対応の説明やヒントを用意すると、UI の内容がわかりやすくなります。

    詳しくは、「[アクセシビリティ対応の名前](basic-accessibility-information.md#accessible_name)」と「[アクセシビリティ対応の説明](basic-accessibility-information.md)」をご覧ください。

2. キーボード アクセシビリティを実装します。

    * UI 用の既定のタブ インデックスの順序をテストします。 必要に応じてタブ インデックスの順序を調整します。このとき、特定のコントロールの有効化または無効化、一部の UI 要素の [**TabIndex**](https://msdn.microsoft.com/library/windows/apps/BR209461) の既定値の変更が必要になる場合があります。
    * コンポジット要素に方向キーのナビゲーションをサポートするコントロールを使います。 既定のコントロールの場合、通常、方向キーのナビゲーションは既に実装されています。
    * キーボードのアクティブ化をサポートするコントロールを使います。 既定のコントロール、特に UI オートメーションの [**Invoke**](https://msdn.microsoft.com/library/windows/apps/BR242582) パターンをサポートするものの場合は、基本的にキーボードのアクティブ化が利用できます。該当するコントロールの説明書をご覧ください。
    * 対話式操作をサポートする UI の一部に対するアクセス キーを設定するか、ショートカット キーを実装します。
    * UI で使うカスタム コントロールで、アクティブ化用に適切な [**AutomationPeer**](https://msdn.microsoft.com/library/windows/apps/BR209185) サポートを設定した状態でコントロールが実装され、アクティブ化キー、トラバーサル キー、アクセス キーまたはショートカット キーのサポートに必要なキー処理の上書きが定義されていることを確認します。

    詳しくは、「[キーボード操作](https://msdn.microsoft.com/library/windows/apps/Mt185607)」をご覧ください。

3. テキストが読み取り可能なサイズであることを確認します。

    * Windows には、さまざまなアクセシビリティ ツールとユーザーが活用し、独自のニーズとテキストを読み取るための基本設定を調整する設定が含まれています。 次のようなクラスがあります。
        * 拡大鏡ツール、UI の選択範囲を拡大します。 アプリ内のテキストのレイアウトが困難に拡大鏡を使用して、読み取り用に行う必要があります。
        * スケールと解像度の設定をグローバル**設定]、[システムの表示]-> [-> スケールとレイアウト**します。 正確にサイズ変更オプションが使用可能なディスプレイ デバイスの機能に依存とは異なります。
        * テキスト サイズ設定**設定、アクセスの容易さの表示-> **します。 調整、**テキストを大きく**すべてのアプリケーションと画面 (すべての UWP テキスト コントロールは、テキストをカスタマイズまたはテンプレートなしのエクスペリエンスをスケーリングをサポート) 間でのサポート コントロールでテキストのサイズだけを指定する設定。
        > [!NOTE]
        > **すべての大きな**設定により、ユーザーのプライマリ画面のみに一般にテキストとアプリの推奨サイズを指定します。

4. テキスト コントラストが適切であること、ハイ コントラスト テーマで要素が正しくレンダリングされること、色が正しく使われていることを確認するため、UI を表示して検証します。

    * 色分析ツールを使って、視覚的なテキストのコントラスト比が 4.5:1 以上であることを検証します。
    * ハイ コントラスト テーマに切り替え、アプリの UI が読みやすく使いやすいことを確認します。
    * UI が情報を伝える唯一の手段として色を使っていないことを確認します。

    詳しくは、「[ハイ コントラスト テーマ](high-contrast-themes.md)」と「[アクセシビリティに対応したテキストの要件](accessible-text-requirements.md)」をご覧ください。

5. アクセシビリティ ツールを実行し、報告された問題に対処して、画面の読み上げを確認します。

    [  **Inspect**](https://msdn.microsoft.com/library/windows/desktop/Dd318521) などのツールを使ってプログラムによるアクセスを検証し、[**AccChecker**](https://msdn.microsoft.com/library/windows/desktop/Hh920985) などの診断ツールを実行して一般的なエラーを見つけます。画面の読み上げの確認には、ナレーターを使います。

    詳しくは、「[アクセシビリティ テスト](accessibility-testing.md)」をご覧ください。

6. アプリ マニフェストの設定がアクセシビリティ ガイドラインに準拠しているかどうかを確認します。

7. Microsoft Store でアプリがアクセシビリティ対応であることを宣言します。

    アクセシビリティ サポートの基準を実装したら、Microsoft Store でアプリがアクセシビリティ対応であることを宣言することで、より多くのユーザーにアプリを提供し、さらに良い評価を得ることができます。

    詳しくは、「[ストア内のアクセシビリティ](accessibility-in-the-store.md)」をご覧ください。

## <a name="related-topics"></a>関連トピック  

* [アクセシビリティに対応したテキストの要件](accessible-text-requirements.md)
* [テキストのスケーリング](../input/text-scaling.md)
* [アクセシビリティ](accessibility.md)
* [ユーザー補助のための設計](https://msdn.microsoft.com/library/windows/apps/Hh700407)
* [避ける事項](practices-to-avoid.md)
