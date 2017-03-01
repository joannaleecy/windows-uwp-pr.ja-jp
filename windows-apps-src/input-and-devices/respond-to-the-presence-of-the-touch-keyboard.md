---
author: Karl-Bridge-Microsoft
Description: "タッチ キーボードを表示または非表示にするときにアプリの UI を調整する方法について説明します。"
title: "タッチ キーボードの表示への応答"
ms.assetid: 70C6130E-23A2-4F9D-88E7-7060062DA988
label: Respond to the presence of the touch keyboard
template: detail.hbs
keywords: "キーボード, アクセシビリティ, ナビゲーション, フォーカス, テキスト, 入力, ユーザーの操作"
ms.author: kbridge
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
translationtype: Human Translation
ms.sourcegitcommit: c6b64cff1bbebc8ba69bc6e03d34b69f85e798fc
ms.openlocfilehash: c08e33b95241ce95c7670e197e67496b774897cb
ms.lasthandoff: 02/07/2017

---

# <a name="respond-to-the-presence-of-the-touch-keyboard"></a>タッチ キーボードの表示への応答
<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css">

タッチ キーボードを表示または非表示にするときにアプリの UI を調整する方法について説明します。

<div class="important-apis" >
<b>重要な API</b><br/>
<ul>
<li>[**AutomationPeer**](https://msdn.microsoft.com/library/windows/apps/br209185)</li>
<li>[**InputPane**](https://msdn.microsoft.com/library/windows/apps/br242255)</li>
</ul>
</div> 



![既定のレイアウト モードのタッチ キーボード](images/touchkeyboard-standard.png)

<sup>既定\\の\\レイアウト\\ モード\\の\\タッチ\\ キーボード</sup>

タッチ キーボードによって、タッチをサポートするデバイスのテキスト入力が有効になります。 ユニバーサル Windows プラットフォーム (UWP) のテキスト入力コントロールでは、ユーザーが編集可能な入力フィールドをタップしたときに、既定でタッチ キーボードが表示されます。 タッチ キーボードは、通常、ユーザーがフォーム内のコントロール間を移動している間は表示されますが、この動作はフォーム内の他のコントロールの種類に基づいて異なります。

標準のテキスト入力コントロールから派生していないカスタム テキスト入力コントロールで対応するタッチ キーボードの動作をサポートするには、[**AutomationPeer**](https://msdn.microsoft.com/library/windows/apps/br209185) クラスを使ってコントロールを Microsoft UI オートメーションに公開し、適切な UI オートメーション コントロール パターンを実装する必要があります。 「[キーボードのアクセシビリティ](https://msdn.microsoft.com/library/windows/apps/mt244347)」と「[カスタム オートメーション ピア](https://msdn.microsoft.com/library/windows/apps/mt297667)」をご覧ください。

このサポートがカスタム コントロールに追加されると、タッチ キーボードの表示に適切に応答できます。

**前提条件:  **

このトピックは、「[キーボード操作](keyboard-interactions.md)」に基づいています。

標準のキーボード操作、キーボード入力とイベントの処理、UI オートメーションの基本を理解している必要があります。

ユニバーサル Windows プラットフォーム (UWP) アプリを開発するのが初めての場合は、以下のトピックに目を通して、ここで説明されているテクノロジをよく理解できるようにしてください。

-   [初めてのアプリ作成](https://msdn.microsoft.com/library/windows/apps/bg124288)
-   「[イベントとルーティング イベントの概要](https://msdn.microsoft.com/library/windows/apps/mt185584)」に記載されているイベントの説明

**ユーザー エクスペリエンス ガイドライン:  **

キーボード入力に最適化された便利で魅力的なアプリの設計に役立つヒントについては、「[キーボードの設計ガイドライン](https://msdn.microsoft.com/library/windows/apps/hh972345)」をご覧ください。

## <a name="touch-keyboard-and-a-custom-ui"></a>タッチ キーボードとカスタム UI


ここでは、カスタム テキスト入力コントロールについてのいくつかの基本的な推奨事項を示します。

-   フォームに対する操作が行われている間はタッチ キーボードを表示します。

-   テキスト入力のコンテキストでフォーカスがテキスト入力フィールドから移動したときにキーボードの表示を持続させるには、カスタム コントロールに適切な UI オートメーションの [**AutomationControlType**](https://msdn.microsoft.com/library/windows/apps/br209182) を使います。 たとえば、テキスト入力シナリオの半ばでメニューを開くときに、キーボードを表示したままにするには、このメニューに Menu の **AutomationControlType** が必要です。

-   UI オートメーション プロパティを操作してタッチ キーボードを制御しないでください。 UI オートメーション プロパティの正確さに依存する他のアクセシビリティ ツールがあります。

-   操作している入力フィールドをユーザーが常に見られるようにします。

    タッチ キーボードによって画面の大部分が見えなくなるため、UWP では、ユーザーがフォームのコントロール間を移動するときに、フォーカスのある入力フィールドをスクロールしてビューに表示します。これには、現在ビューに表示されていないコントロールも含まれます。

    UI をカスタマイズする場合は、[**InputPane**](https://msdn.microsoft.com/library/windows/apps/br242255) オブジェクトで公開される [**Showing**](https://msdn.microsoft.com/library/windows/apps/br242262) イベントと [**Hiding**](https://msdn.microsoft.com/library/windows/apps/br242260) イベントを処理して、タッチ キーボードの表示について同様の動作を提供します。

    ![タッチ キーボードが表示または非表示になっているフォーム](images/touch-keyboard-pan1.png)

    場合によっては、画面にずっと表示されたままであることが必要な UI 要素もあります。 フォーム コントロールがパン領域に含まれ、重要な UI 要素が静的であるように UI を設計します。 例:

    ![常に表示されている必要がある領域を含むフォーム](images/touch-keyboard-pan2.png)

## <a name="handling-the-showing-and-hiding-events"></a>Showing イベントと Hiding イベントの処理


タッチ キーボードの [**showing**](https://msdn.microsoft.com/library/windows/apps/br242262) イベントと [**hiding**](https://msdn.microsoft.com/library/windows/apps/br242260) イベントのイベント ハンドラーをアタッチする例を次に示します。

```CSharp
public class MyApplication
{
    public MyApplication()
    {
        // Grab the input pane for the main application window and attach
        // touch keyboard event handlers.
        Windows.Foundation.Application.InputPane.GetForCurrentView().Showing  
            += new EventHandler(_OnInputPaneShowing);
        Windows.Foundation.Application.InputPane.GetForCurrentView().Hiding 
            += new EventHandler(_OnInputPaneHiding);
    }

    private void _OnInputPaneShowing(object sender, IInputPaneVisibilityEventArgs eventArgs)
    {
        // If the size of this window is going to be too small, the app uses 
        // the Showing event to begin some element removal animations.
        if (eventArgs.OccludedRect.Top < 400)
        {
            _StartElementRemovalAnimations();

            // Don&#39;t use framework scroll- or visibility-related 
            // animations that might conflict with the app&#39;s logic.
            eventArgs.EnsuredFocusedElementInView = true; 
        }
    }

    private void _OnInputPaneHiding(object sender, IInputPaneVisibilityEventArgs eventArgs)
    {
        if (_ResetToDefaultElements())
        {
            eventArgs.EnsuredFocusedElementInView = true; 
        }
    }

    private void _StartElementRemovalAnimations()
    {
        // This function starts the process of removing elements 
        // and starting the animation.
    }

    private void _ResetToDefaultElements()
    {
        // This function resets the window&#39;s elements to their default state.
    }
}
```

## <a name="related-articles"></a>関連記事

* [キーボード操作](keyboard-interactions.md)
* [キーボードのアクセシビリティ](https://msdn.microsoft.com/library/windows/apps/mt244347)
* [カスタム オートメーション ピア](https://msdn.microsoft.com/library/windows/apps/mt297667)


**サンプルのアーカイブ**
* [入力: タッチ キーボードのサンプルに関するページ](http://go.microsoft.com/fwlink/p/?linkid=246019)
* [スクリーン キーボードを表示したときの対応のサンプルのページ](http://go.microsoft.com/fwlink/p/?linkid=231633)
* [XAML テキスト編集のサンプルに関するページ](http://go.microsoft.com/fwlink/p/?LinkID=251417)
* [XAML アクセシビリティ サンプル](http://go.microsoft.com/fwlink/p/?linkid=238570)
 

 





