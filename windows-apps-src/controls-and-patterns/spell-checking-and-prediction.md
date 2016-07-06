---
author: Jwmsft
Description: "テキストの入力と編集を行っているときに、スペル チェックは単語を赤い波線で強調表示してユーザーに単語のスペルの間違いを知らせ、それを修正する方法を提供します。"
title: "スペル チェックと予測入力"
ms.assetid: B867C956-5AB2-4207-A8DE-179CE7871180
label: Spell checking and text prediction
template: detail.hbs
redirect_url: text-controls
ms.sourcegitcommit: 08f982f5c54d596a7624fe63528f91375e7761ca
ms.openlocfilehash: 8954b14a84241686a7c784c3d250f197bed7c8b6

---

# スペル チェックのガイドライン

テキストの入力と編集を行っているときに、スペル チェックは単語を赤い波線で強調表示してユーザーに単語のスペルの間違いを知らせ、それを修正する方法を提供します。

**重要な API**

-   [**IsSpellCheckEnabled プロパティ (XAML)**](https://msdn.microsoft.com/library/windows/apps/br209688)


## <span id="checklist_section"></span><span id="CHECKLIST_SECTION"></span>推奨事項


-   スペル チェックは、テキスト入力コントロールに単語や文を入力するときにユーザーを補助するために使います。 スペル チェックは、タッチ、マウス、キーボード入力で機能します。
-   単語が辞書になさそうな場合や、ユーザーがスペル チェックを重視しない場合は、スペル チェックを使わないでください。 たとえば、パスワード、電話番号、名前などの入力ボックスでは、スペル チェックを有効にしません。 これらのコントロールでは、スペル チェックが既定で無効になっています。
-   現在のスペル チェック エンジンがアプリの言語をサポートしていないという理由だけで、スペル チェックを無効にしないでください。 スペル チェックでその言語がサポートされていない場合は、何も行われないので、有効にしたままで何も問題がありません。 また、一部のユーザーは Input Method Editor (IME) を使ってアプリに他の言語を入力する場合があり、その言語がサポートされている可能性もあります。 たとえば、日本語のアプリを構築している場合には、現在はスペル チェック エンジンが日本語を認識していなくても、スペル チェックを無効にしないでください。 ユーザーが英語 IME に切り替え、アプリに英語を入力する場合があります。スペル チェックが有効になっていれば、英語のスペル チェックが行われます。

## <span id="Additional_usage_guidance"></span><span id="additional_usage_guidance"></span><span id="ADDITIONAL_USAGE_GUIDANCE"></span>その他の使い方のガイダンス


Windows ストア アプリでは、複数行と単一行のテキスト入力ボックスや、**contentEditable** プロパティが **true** に設定されている要素のために組み込みのスペル チェックが用意されています。 組み込みスペル チェックの例を次に示します。

![組み込みスペル チェック](images/spellchecking.png)

詳細については、「[**TextBox クラス**](https://msdn.microsoft.com/library/windows/apps/br209683)」を参照してください。

テキスト入力コントロールでのスペル チェックは、次の 2 つの目的で使います。

-   **スペル ミスを自動修正する**

    スペル チェック エンジンは、単語にスペルの間違いがあり、修正が確実であれば自動的に修正します。 たとえば、エンジンは自動的に "teh" を "the" に変更します。

-   **代わりのスペルを示す**

    修正が確実でないとスペル チェック エンジンが判断した場合、スペル ミスのある単語には赤い下線が引かれ、ユーザーがその単語をタップするか右クリックすると、ショートカット メニューに修正候補が表示されます。

JavaScript コントロールの場合、複数行テキスト入力コントロールでは、既定でスペル チェックが有効になっており、単一行コントロールでは無効になっています。 単一行コントロールでスペル チェックを手動で有効にするには、コントロールの **spellcheck** プロパティを **true** に設定します。 コントロールのスペル チェックを無効にするには、**spellcheck** プロパティを **false** に設定します。

XAML TextBox コントロールの場合、スペル チェックが既定で無効になっています。 **IsSpellCheckEnabled** プロパティを **true** に設定することによって有効にできます。



## <span id="related_topics"></span>関連記事

* [テキストとテキスト コントロール](text-controls.md)
* [テキスト入力のガイドライン](https://msdn.microsoft.com/library/windows/apps/hh750315)
* [テキストとタイポグラフィのガイドライン](https://msdn.microsoft.com/library/windows/apps/hh700394)
            
          
            **開発者向け (XAML)**
* [**TextBox.IsSpellCheckEnabled プロパティ**](https://msdn.microsoft.com/library/windows/apps/br209688)
* [**TextBox クラス**](https://msdn.microsoft.com/library/windows/apps/br209683)

 







<!--HONumber=Jun16_HO5-->


