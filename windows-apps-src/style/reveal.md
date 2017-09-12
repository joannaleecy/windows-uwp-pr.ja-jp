---
author: mijacobs
description: "表示は新しい相互作用モデルで、アプリケーションでのフォーカスの効果を高め、魅力的なアプリケーションを作成する際に役立ちます。"
title: "表示"
template: detail.hbs
ms.author: mijacobs
ms.date: 08/9/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
pm-contact: kisai
design-contact: conrwi
dev-contact: jevansa
doc-status: Published
ms.openlocfilehash: d50e3f47faad5fff0ef461a4b5312127a0b9ec9c
ms.sourcegitcommit: 0d5b3daddb3ae74f91178c58e35cbab33854cb7f
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/09/2017
---
# <a name="reveal"></a>表示

> [!IMPORTANT]
> この記事では、まだリリースされていない機能について説明しています。この機能は、正式版がリリースされるまでに大幅に変更される可能性があります。 ここに記載された情報について、Microsoft は明示または黙示を問わずいかなる保証をするものでもありません。

表示は照明効果の 1 つで、アプリの対話型要素に奥行きを与え、焦点を当てるために役立ちます。

> **重要な API**: [RevealBrush クラス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.revealbrush)、[RevealBackgroundBrush クラス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.revealbackgroundbrush)、[RevealBorderBrush クラス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.revealborderbrush)、[RevealBrushHelper クラス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.revealbrushhelper)、[VisualState class](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.VisualState)

表示の動作は、マウスやフォーカス用の四角形が目的の領域の上に置かれたときに、ヒーロー コンテンツ (重要なコンテンツ) の周囲にある要素を明確に表示することによって実現されます。

![表示のビジュアル効果](images/Nav_Reveal_Animation.gif)

オブジェクトの周囲にある非表示の境界線を明示すると、表示の動作によって、ユーザーが操作する領域の認識が容易になり、実行できる操作もわかりやすくなります。 これは、リスト コントロールやバック プレートを持つコントロールでは特に重要です。

## <a name="reveal-and-the-fluent-design-system"></a>表示と Fluent Design System

 Fluent Design System では、ライト、深度、モーション、マテリアル、スケールを取り入れた、モダンで目を引く UI を作成できます。 表示は、アプリにライトを追加する Fluent Design System コンポーネントです。 

## <a name="what-is-reveal"></a>表示とは

表示には 2 つの主要な視覚コンポーネントがあります。それらは、**ホバーによる表示**動作と**境界線による表示**動作です。

![表示レイヤー](images/RevealLayers.png)

ホバーによる表示は、ポインターやフォーカス入力によってポイントされるコンテンツに直接関連付けられており、ポイントされる項目やフォーカスが置かれる項目の周囲に滑らかなハロー型を適用し、その項目が操作可能であることを示します。

境界線による表示は、フォーカスが置かれる項目やその近くにある項目に適用されます。 これにより、オブジェクトの近くにある項目に対して、現在フォーカスが置かれている項目と類似した操作を実行できること示されます。

表示のレシピには以下のものがあります。

- 境界線による表示は、すべてのコンテンツの最上位にありますが、指定されたエッジの上に配置されます
- テキストとコンテンツは、境界線による表示の直下に表示されます
- ホバーによる表示は、コンテンツとテキストの下にあります
- バック プレート (ホバーによる表示をオンにして有効にします)
- 背景 (コントロールの背景です)

<!--
<div class=”microsoft-internal-note”>
To create your own Reveal lighting effect for static comps or prototype purposes, see the full [uni design guidance](http://uni/DesignDepot.FrontEnd/#/ProductNav/3020/1/dv/?t=Resources%7CToolkit%7CReveal&f=Neon) for this effect in illustrator.
</div>
-->

## <a name="how-to-use-it"></a>用途

表示を使用すると、必要に応じてカーソルの周囲にジオメトリが明示され、カーソルが離れるとそのジオメトリがシームレスにフェード アウトします。

表示は、境界やバック プレートが暗示的に示されている、アプリの主要なコンテンツ (ヒーロー コンテンツ) 上で有効にするのが最適な使用方法です。 また、表示をコレクションやリストのようなコントロールで使用することもお勧めします。

## <a name="controls-that-automatically-use-reveal"></a>表示を自動的に使用するコントロール

- [**ListView**](../controls-and-patterns/lists.md)
- [**TreeView**](../controls-and-patterns/tree-view.md)
- [**NavigationView**](../controls-and-patterns/navigationview.md)
- [**AutosuggestBox**](../controls-and-patterns/auto-suggest-box.md)

## <a name="enabling-reveal-on-other-common-controls"></a>他の一般的なコントロールで表示を有効にする

表示の適用が必要なシナリオの場合 (シナリオで使用されるコントロールはメイン コンテンツである場合、またはそれらのコントロールがリストやコレクションに対応するために使用される場合)、オプトインのリソース スタイルが用意されているので、これらのスタイルを使用することで、そのような状況で表示を有効にすることができます。

以下に示すコントロールは、既定では表示の機能を備えていません。これらのコントロールは小さなコントロールであり、通常は、アプリケーションの重要なコンテンツをサポートするヘルパー コントロールですが、アプリによってはその状況は異なります。これらのコントロールをアプリの多くの部分で使用する場合は、その表示をサポートするスタイルがいくつか用意されているのでご利用ください。

| コントロール名   | リソース名 |
|----------|:-------------:|
| Button |  ButtonRevealStyle |
| ToggleButton | ToggleButtonRevealStyle |
| RepeatButton | RepeatButtonRevealStyle |
| AppBarButton | AppBarButtonRevealStyle |
| SemanticZoom | SemanticZoomRevealStyle |
| ComboBoxItem | ComboxBoxItemRevealStyle |

これらのスタイルを適用するには、Style プロパティを次のように更新するだけです。

```XAML
<Button Content="Button Content" Style="{StaticResource ButtonRevealStyle}"/>
```

> [!NOTE]
> SDK バージョン 16190 では、これらのスタイルは自動的には提供されません。 これらを使うには、generic.xaml から手動でアプリにコピーする必要があります。 generic.xaml は通常、C:\Program Files (x86)\Windows Kits\10\DesignTime\CommonConfiguration\Neutral\UAP\10.0.16190.0\Generic に配置されています。 この問題は今後のビルドで修正される予定です。 

## <a name="enabling-reveal-on-custom-controls"></a>カスタム コントロールで表示を有効にする

カスタム コントロールや再テンプレート化されたコントロールで表示を有効にするには、そのコントロールのテンプレートの表示状態 (VisualState) でコントロールのスタイルを調べ、ルート グリッドで表示を指定します。

```xaml
<VisualState x:Name="PointerOver">
  <VisualState.Setters>
    <Setter Target="RootGrid.(RevealBrushHelper.State)" Value="PointerOver" />
    <Setter Target="RootGrid.Background" Value="{ThemeResource ButtonRevealBackgroundPointerOver}"/>
    <Setter Target="ContentPresenter.BorderBrush" Value="{ThemeResource ButtonRevealBorderBrushPointerOver}"/>
    <Setter Target="ContentPresenter.Foreground" Value="{ThemeResource ButtonForegroundPointerOver}"/>
  </VisualState.Setters>
</VisualState>
```

表示のプル効果を実現するには、PressedState に同じ RevealBrushHelper を追加する必要があります。

```xaml
<VisualState x:Name="Pressed">
  <VisualState.Setters>
    <Setter Target="RootGrid.(RevealBrushHelper.State)" Value="Pressed" />
    <Setter Target="RootGrid.Background" Value="{ThemeResource ButtonRevealBackgroundPressed}"/>
    <Setter Target="ContentPresenter.BorderBrush" Value="{ThemeResource ButtonRevealBorderBrushPressed}"/>
    <Setter Target="ContentPresenter.Foreground" Value="{ThemeResource ButtonForegroundPressed}"/>
  </VisualState.Setters>
</VisualState>
```


システム リソースである "表示" を使用することは、すべてのテーマの変更が自動的に処理されることを意味します。

## <a name="dos-and-donts"></a>推奨と非推奨
- 表示は、ユーザーが操作できる要素に対して使用してください - 表示は、静的なコンテンツに対しては使用しないでください
- データのリストやコレクションで表示の効果を利用してください
- 表示は、バック プレートを持ち、明示的に含まれているコンテンツに適用してください
- 操作することができない静的な背景、テキスト、画像では表示の効果を利用しないでください
- 無関係な浮動コンテンツには表示を適用しないでください
- 1 回限りの個別の状況 (コンテンツ ダイアログや通知など) では表示を使用しないでください
- セキュリティ上の決定を行う場合には表示を使用しないでください (ユーザーに提供する必要があるメッセージから注意がそれる可能性があるため)

## <a name="related-articles"></a>関連記事

- [RevealBrush クラス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.revealbrush)
- [**アクリル**](acrylic.md)
- [**コンポジションの効果**](https://msdn.microsoft.com/windows/uwp/graphics/composition-effects)
