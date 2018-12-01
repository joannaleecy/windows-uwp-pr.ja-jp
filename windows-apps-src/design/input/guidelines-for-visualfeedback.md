---
Description: Use visual feedback to show users when their interactions with a UWP app are detected, interpreted, and handled.
title: 視覚的なフィードバック
ms.assetid: bf2f3672-95f0-4c8c-9a72-0934f2d3b767
label: Visual feedback
template: detail.hbs
keywords: 視覚的なフィードバック, フォーカス フィードバック, タッチ フィードバック, 接触の視覚エフェクト, 入力, 操作
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: b043ec71eb7d5883a1b22c4f0d8f43824034d454
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/30/2018
ms.locfileid: "8340621"
---
# <a name="guidelines-for-visual-feedback"></a>視覚的なフィードバックのガイドライン

視覚的なフィードバックは、対話式操作が検出、解釈、処理されていることをユーザーに示すために使います。 視覚的なフィードバックは、対話式操作を促進することによってユーザーを支援します。 対話式操作の成功を示すことによって、ユーザーのコントロール感を向上させます。 また、システム状態の中継やエラーの削減も可能になります。

> **重要な API**: [**Windows.Devices.Input**](https://msdn.microsoft.com/library/windows/apps/br225648)、[**Windows.UI.Input**](https://msdn.microsoft.com/library/windows/apps/br242084)、[**Windows.UI.Core**](https://msdn.microsoft.com/library/windows/apps/br208383)

## <a name="recommendations"></a>推奨事項

- 広範囲な変更はコントロールとアプリケーションの両方のパフォーマンスとアクセシビリティに影響を与える可能性があるため、コントロール テンプレートの変更を、設計意図に直接関連するものに制限するようにしてください。 
    - 表示状態のプロパティなど、コントロールのプロパティのカスタマイズの詳細については、「[XAML スタイル](https://docs.microsoft.com/windows/uwp/design/controls-and-patterns/xaml-styles)」を参照してください。
    - コントロール テンプレートに対する変更の詳細については、「[UserControl クラス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.usercontrol)」を参照してください。
    - コントロール テンプレートに大幅な変更を加える必要がある場合は、独自にテンプレート化したカスタム コントロールを作成することを検討してください。 テンプレート化したカスタム コントロールの例については、「[カスタム編集コントロールのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/CustomEditControl)」を参照してください。
- タッチの視覚エフェクトがアプリの使用を妨げる可能性がある場合は、使わないでください。 詳しくは、「[**ShowGestureFeedback**](https://msdn.microsoft.com/library/windows/apps/br241969)」をご覧ください。
- どうしても必要な場合以外は、フィードバックを表示しないでください。 その場所でしか意味がない場合を除き、視覚的なフィードバックを表示せずに、UI の簡潔さを維持してください。
- Windows の組み込みジェスチャの視覚的なフィードバックの動作は大幅にカスタマイズしないでください。この動作をカスタマイズすると、ユーザー エクスペリエンスに一貫性がなくなり、混乱する可能性があります。

## <a name="additional-usage-guidance"></a>その他の使い方のガイダンス

正確性が求められるタッチ操作では、接触の視覚エフェクトが特に重要です。 たとえば、アプリでタップの位置を正確に示し、対象から外れていたかどうか、どの程度外れていたか、合わせるにはどうすればよいかをユーザーが把握できるようする必要があります。

利用可能な既定の XAML プラットフォーム コントロールを使うと、すべてのデバイスおよびすべての入力状況でアプリが正しく動作します。 カスタマイズされたフィードバックが必要なカスタム操作をアプリに実装する場合は、そのフィードバックが適切であり、各入力デバイスでそのフィードバックが示されることを確認してください。また、フィードバックがユーザーの作業を妨げないようにする必要もあります。 このことは、視覚的なフィードバックが重要な UI と競合したり、重要な UI を隠したりする可能性があるゲームや描画アプリでは特に重要です。

> [!Important]
> 組み込みジェスチャの操作の動作を変更することはお勧めしません。

**複数のデバイスにおけるフィードバック**

視覚的なフィードバックは、一般に入力デバイス (タッチ、タッチバッド、マウス、ペン/スタイラス、キーボードなど) に依存します。 たとえば、マウスの組み込みフィードバックには、通常はカーソルの移動と変化が伴います。一方、タッチとペンの場合は接触の視覚エフェクトが必要です。キーボードによる入力とナビゲーションの場合は、フォーカス用の四角形と強調表示を使います。

プラットフォーム ジェスチャのフィードバック動作を設定するには、[**ShowGestureFeedback**](https://msdn.microsoft.com/library/windows/apps/br241969) を使います。

フィードバック UI をカスタマイズする場合は、すべての入力モードをサポートした適切なフィードバックを提供してください。

Windows には、次のような接触の視覚エフェクトが組み込まれています。

| ![タッチ フィードバック](images/TouchFeedback.png) | ![マウス フィードバック](images/MouseFeedback.png) | ![ペン フィードバック](images/PenFeedback.png) | ![キーボード フィードバック](images/KeyboardFeedback.png) |
| --- | --- | --- | --- |
| タッチの視覚エフェクト | マウス/タッチパッドの視覚エフェクト | ペンの視覚エフェクト | キーボードの視覚エフェクト |

## <a name="high-visibility-focus-visuals"></a>視認性の高いフォーカスの視覚効果

すべての Windows アプリでは、定義済みのさまざまなフォーカスの視覚効果が、アプリケーション内にある対話可能なコントロールの周囲に示されます。 新しいフォーカスの視覚効果は、すべてカスタマイズ可能であり、必要に応じて無効にすることができます。

Xbox とテレビの使用で一般的な **10 フィート エクスペリエンス**では、Windows は**表示フォーカス**をサポートします。これは、ボタンなどのフォーカス可能な要素がゲームパッドやキーボードの入力でフォーカスを取得したときに、その境界線をアニメーション化する照明効果です。 詳細については、「[Xbox およびテレビ向け設計](https://docs.microsoft.com/windows/uwp/design/devices/designing-for-tv#reveal-focus)」を参照してください。

## <a name="color-branding--customizing"></a>色のブランド化とカスタマイズ

**境界線のプロパティ**

視認性の高いフォーカスの視覚効果は、プライマリ境界線とセカンダリ境界線という 2 つの部分で構成されます。 プライマリ境界線は、**2 px** の幅があり、セカンダリ境界線の*外側*に描画されます。 セカンダリ境界線は、**1 px** の幅があり、プライマリ境界線の*内側*に描画されます。
![視認性の高いフォーカスの視覚効果 (赤線で示されています)](images/FocusRectRedlines.png)

それぞれの境界線 (プライマリおよびセカンダリ) の太さを変更するには、**FocusVisualPrimaryThickness** をプライマリ境界線に対して使用し、 **FocusVisualSecondaryThickness** をセカンダリ境界線に対して使用します。
```XAML
<Slider Width="200" FocusVisualPrimaryThickness="5" FocusVisualSecondaryThickness="2"/>
```
![視認性の高いフォーカスの視覚効果における余白部分の太さ](images/FocusMargin.png)

余白は [**Thickness**](https://msdn.microsoft.com/library/system.windows.thickness) という種類のプロパティで指定されます。このため、コントロールの特定の側にのみ表示されるように、余白をカスタマイズすることができます。 次をご覧ください。![視認性の高いフォーカスの視覚効果 (余白部分を下端にのみ表示)](images/FocusThicknessSide.png)

余白は、コントロールの視覚的な境界線と、フォーカスの視覚効果で示される*セカンダリ境界線*の開始点との間にあるスペースです。 既定の余白は、コントロールの境界線から **1 px** の幅で描画されます。 この余白はコントロールごとに変更できます。それには、**FocusVisualMargin** プロパティを変更します。
```XAML
<Slider Width="200" FocusVisualMargin="-5"/>
```
![視認性の高いフォーカスの視覚効果における余白の違い](images/FocusPlusMinusMargin.png)

*負の値で示される余白は、コントロールの中央から遠ざけるようにして境界線を描画し、正の値で示される余白は、コントロールの中央に近づけるようにして境界線を描画します。*

コントロールでフォーカスの視覚効果を完全に無効にするには、**UseSystemFocusVisuals** を無効にするだけです。
```XAML
<Slider Width="200" UseSystemFocusVisuals="False"/>
```

太さ、余白、またはアプリ開発者がフォーカスの視覚効果を必要とするかどうかは、コントロールごとに決める必要があります。

**色のプロパティ**

フォーカスの視覚効果に関する色のプロパティには、プライマリ境界線の色とセカンダリ境界線の色という 2 つのプロパティがあります。 これらのフォーカスの視覚効果における境界線の色は、ページ レベルでコントロールごとに変更したり、アプリ全体を対象としてグローバルに変更したりすることができます。

アプリ全体を対象としてフォーカスの視覚効果をブランド化するには、システム ブラシを上書きします。
```XAML
<SolidColorBrush x:Key="SystemControlFocusVisualPrimaryBrush" Color="DarkRed"/>
<SolidColorBrush x:Key="SystemControlFocusVisualSecondaryBrush" Color="Pink"/>
```
![視認性の高いフォーカスの視覚効果における色の変更](images/FocusRectColorChanges.png)

コントロールごとに色を変更するには、目的のコントロールが持つフォーカスの視覚効果のプロパティを編集するだけです。
```XAML
<Slider Width="200" FocusVisualPrimaryBrush="DarkRed" FocusVisualSecondaryBrush="Pink"/>
```

## <a name="related-articles"></a>関連記事

**デザイナー向け**
* [パンのガイドライン](guidelines-for-panning.md)

**開発者向け**
* [カスタム ユーザー操作](https://msdn.microsoft.com/library/windows/apps/mt185599)

**サンプル**
* [基本的な入力のサンプル](https://go.microsoft.com/fwlink/p/?LinkID=620302)
* [待機時間が短い入力のサンプル](https://go.microsoft.com/fwlink/p/?LinkID=620304)
* [ユーザー操作モードのサンプル](https://go.microsoft.com/fwlink/p/?LinkID=619894)
* [フォーカスの視覚効果のサンプル](https://go.microsoft.com/fwlink/p/?LinkID=619895)

**サンプルのアーカイブ**
* [入力: XAML ユーザー入力イベントのサンプル](https://go.microsoft.com/fwlink/p/?linkid=226855)
* [入力: デバイス機能のサンプル](https://go.microsoft.com/fwlink/p/?linkid=231530)
* [入力: タッチのヒット テストのサンプル](https://go.microsoft.com/fwlink/p/?linkid=231590)
* [XAML のスクロール、パン、ズームのサンプルに関するページ](https://go.microsoft.com/fwlink/p/?linkid=251717)
* [入力: 簡略化されたインクのサンプル](https://go.microsoft.com/fwlink/p/?linkid=246570)
* [入力: Windows 8 のジェスチャのサンプルに関するページ](https://go.microsoft.com/fwlink/p/?LinkId=264995)
* [入力: 操作とジェスチャ (C++) のサンプルに関するページ](https://go.microsoft.com/fwlink/p/?linkid=231605)
* [DirectX タッチ入力のサンプル](https://go.microsoft.com/fwlink/p/?LinkID=231627)
 

 
