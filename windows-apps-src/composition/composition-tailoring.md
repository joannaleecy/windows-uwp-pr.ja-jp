---
author: daneuber
title: コンポジションの調整
description: UI を調整して、パフォーマンスの最適化、ユーザー設定とデバイスの特性を対応するには、コンポジション Api を使用します。
ms.author: jimwalk
ms.date: 07/16/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 66384c4df3195ae0fff35ae5dd7e1b1983204068
ms.sourcegitcommit: f5cf806a595969ecbb018c3f7eea86c7a34940f6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/10/2018
ms.locfileid: "3822646"
---
# <a name="tailoring-effects--experiences-using-windows-ui"></a>効果と Windows UI を使用して、エクスペリエンスを調整します。

Windows UI では、区別の多くの美しい効果、アニメーション、および手段を提供します。 ただし、パフォーマンスとカスタマイズのユーザーの期待を会議が成功したアプリケーションを作成するのに必要な部分です。 ユニバーサル Windows プラットフォームには、大規模なさまざまなデバイス ファミリのさまざまな機能や機能がサポートしています。 すべてのユーザーの包括的なエクスペリエンスを実現するためには、デバイス間で、アプリケーションのスケールを確認し、ユーザーの優先順位を考慮する必要があります。 UI を調整すると、デバイスの機能を活用し、快適な包括的なユーザー エクスペリエンスを確保する効率的な方法が提供できます。

パフォーマンスと、以下の点に関して美しい UI の作業を含むさまざまなカテゴリは、UI を調整します。

- 尊重し、効果のユーザーの設定への対応
- アニメーションのユーザーの設定への対応
- 特定のハードウェア機能の UI の最適化

ここでは、上の領域でビジュアル レイヤーのアニメーション、効果を調整する方法を説明しますが、終了の優れたユーザー エクスペリエンスを保つアプリケーションを調整するその他の多くの方法があります。 さまざまなデバイスと[応答性の高い UI を作成](/design/layout/responsive-design.md)する[UI を調整](/design/layout/screen-sizes-and-breakpoints-for-responsive-design.md)する方法に関するガイダンス ドキュメントを利用できます。

## <a name="user-effects-settings"></a>ユーザーの効果の設定

ユーザーは、さまざまな理由から、アプリケーションが尊重し、対応する必要があります Windows エクスペリエンスをカスタマイズすることができます。 1 つの領域をエンドユーザーが制御できますが、システム全体で使用する表示効果の種類を変更します。

### <a name="transparency-effects-settings"></a>透明効果の設定

ユーザーがカスタマイズできるこのような効果設定を 1 つは、透明効果をオン/オフにするとします。 これは、「[パーソナル設定、設定アプリ > 色、または設定アプリを使用して > 簡単 > 表示します。

![透明度設定オプション](images/tailoring-transparency-setting.png)

オンにすると、透明度を使用するすべての効果は、期待どおりに表示されます。 これは、アクリル、HostBackdropBrush、または完全に不透明なではない任意のカスタム効果グラフに適用されます。

無効アクリル素材は自動的にフォールバックする単色を XAML のアクリル ブラシは、既定ではこのイベントを進めがあるためです。 ここでは、私たちは適切にフォールバックする単色透明効果が有効になっていない電卓アプリをご覧ください。

![アクリルを使用した電卓](images/tailoring-acrylic.png)
![透明度の設定への対応アクリルを使用した電卓](images/tailoring-acrylic-fallback.png)

ただし、すべてのカスタム効果のアプリケーションが[UISettings.AdvancedEffectsEnabled](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.uisettings.advancedeffectsenabledchanged)プロパティまたは[AdvancedEffectsEnabledChanged](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.uisettings.advancedeffectsenabledchanged)イベントに応答し、透明度がない効果を使用する効果/効果グラフを切り替える必要があります。 この例では、以下です。

```cs
public MainPage()
{
   var uisettings = new UISettings();
   bool advancedEffects = uisettings.AdvancedEffectsEnabled;
   uisettings.AdvancedEffectsEnabledChanged += Uisettings_AdvancedEffectsEnabledChanged;
}

private void Uisettings_AdvancedEffectsEnabledChanged(UISettings sender, object args)
{
    // TODO respond to sender.AdvancedEffectsEnabled
}
```

## <a name="animations-settings"></a>アニメーションの設定

同様に、アプリケーションがリッスンし、アニメーションがオンまたはオフに基づいて設定でユーザーの設定を確認する[UISettings.AnimationsEnabled](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.uisettings.animationsenabled)プロパティに対応する必要があります > 簡単 > 表示します。

![[設定] でアニメーション オプション](images/tailoring-animations-setting.png)

```cs
public MainPage()
{
   var uisettings = new UISettings();
   bool animationsEnabled = uisettings.AnimationsEnabled;
   // TODO respond to animations settings
}

```

## <a name="leveraging-the-capabilities-api"></a>API の機能を活用します。

[CompositionCapabilities](/uwp/api/windows.ui.composition.compositioncapabilities) Api を利用して、どのコンポジションの機能が利用可能なパフォーマンスに優れたで特定のハードウェアを検出し、エンドユーザーが任意のデバイスで、パフォーマンスに優れたと美しいエクスペリエンスを取得することを確認する設計を調整できます。 Api は、さまざまなフォーム ファクターでスケーリング正常な効果を実装するためにハードウェア システム機能を確認する手段を提供します。 これにより、簡単に、優れた美しさを持つ、作成するアプリケーションとシームレスなエンド ユーザー エクスペリエンスを適切に調整できます。

この API は、メソッドと効果のアプリケーション UI に意思決定をスケーリングするために使うことができるイベント リスナーを提供します。 機能は、システムが複雑なコンポジションとレンダリング操作を処理するどの程度を検出しを使用する開発者向けの利用簡単のモデルでは、情報を返します。

### <a name="using-composition-capabilities"></a>コンポジションの機能を使用

CompositionCapabilities 機能を活用して、アクリル素材、場所、素材にフォールバック シナリオとハードウェアによって複数のパフォーマンスに優れた効果などの機能が既にされています。

API は、いくつかの簡単な手順で既存のコードを追加できます。

1. アプリケーションのコンス トラクターで capabilities オブジェクトを取得します。

    ```cs
    _capabilities = CompositionCapabilities.GetForCurrentView();
    ```

1. アプリの機能の変更イベント リスナーを登録します。

    ```cs
    _capabilities.Changed += HandleCapabilitiesChanged;
    ```

1. さまざまな機能レベルを処理するイベントのコールバック メソッドにコンテンツを追加します。 これは、次の手順を次のようなことができない可能性があります。
1. 効果を使う場合は、まず capabilities オブジェクトを確認します。 効果を調整する方法に応じて、コントロールのステートメントを切り替えるか条件チェックを使用してください。

    ```cs
    if (_capabilities.AreEffectsSupported())
    {
        // Add incremental effects updates here

        if (_capabilities.AreEffectsFast())
        {
            // Add more advanced effects here where applicable
        }
    }
    ```

完全な例のコードは、 [Windows UI の Github リポジトリ](https://github.com/Microsoft/WindowsUIDevLabs/tree/master/SampleGallery/Samples/SDK%2015063/CompCapabilities)で見つかんだことができます。

## <a name="fast-vs-slow-effects"></a>高速低速な効果との比較

CompositionCapabilties API で提供されている[AreEffectsSupported](/uwp/api/windows.ui.composition.compositioncapabilities.areeffectssupported)と[AreEffectsFast](/uwp/api/windows.ui.composition.compositioncapabilities.areeffectsfast)メソッドからのフィードバックに基づき、最適化された任意の他の効果のコストやサポートされていない効果を交換するアプリケーションを決定できます。デバイス。 一部の効果は、他のユーザーよりも負荷の高い複数のリソースを一貫することがわかってし、多用する必要があり、他の効果を自由に使用できます。 すべてのエフェクトのただし、注意する必要があります使用チェーンと一部のシナリオやの組み合わせをアニメーション化が効果グラフのパフォーマンス特性を変更可能性があります。 個々 の効果のいくつかの経験則パフォーマンス特性を次に示します。

- 高パフォーマンスの影響を与えることがわかっている効果とおり – ガウスぼかし、シャドウ マスク、BackDropBrush、HostBackDropBrush、ビジュアル レイヤーです。 これらは、ローエンドのデバイス[(機能レベル 9.1 9.3)](https://msdn.microsoft.com/library/windows/desktop/ff476876(v=vs.85).aspx)では推奨されず、ハイエンド デバイスで慎重に使用する必要があります。
- 普通サイズのパフォーマンスへの影響を効果には、カラー マトリックス (明るさ、色、彩度と色相) 特定のブレンド効果 BlendModes スポット ライト、SceneLightingEffect、および (シナリオによって異なります) BorderEffect します。 これらの効果は、ローエンドのデバイスで特定のシナリオで動作場合がありますが、チェーンとアニメーション化するとき、注意を使用する必要があります。 以内に 2 つの使用を制限して、切り替えのみでアニメーション化することをお勧めします。
- その他のすべての効果は、低パフォーマンスの影響し、アニメーション化すると、チェーンのすべての適切なシナリオで動作します。

## <a name="related-articles"></a>関連記事

- [UWP のレスポンシブ デザイン手法](https://docs.microsoft.com/windows/uwp/design/layout/responsive-design)
- [UWP デバイスの調整](https://docs.microsoft.com/windows/uwp/design/layout/screen-sizes-and-breakpoints-for-responsive-design)
