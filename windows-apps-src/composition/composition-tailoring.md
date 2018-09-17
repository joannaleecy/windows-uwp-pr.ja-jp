---
author: daneuber
title: コンポジションの調整
description: UI を調整する、パフォーマンスを最適化してユーザーの設定とデバイスの特性を調整するには、コンポジション Api を使用します。
ms.author: jimwalk
ms.date: 07/16/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 66384c4df3195ae0fff35ae5dd7e1b1983204068
ms.sourcegitcommit: 9e2c34a5ed3134aeca7eb9490f05b20eb9a3e5df
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/17/2018
ms.locfileid: "3989499"
---
# <a name="tailoring-effects--experiences-using-windows-ui"></a>効果と Windows UI を使用して、エクスペリエンスを調整します。

Windows UI では、差別化要因の多くの美しい効果、アニメーション、および手段を提供します。 ただし、パフォーマンスとカスタマイズのユーザーの期待を会議が成功したアプリケーションを作成するのに必要な部分です。 ユニバーサル Windows プラットフォームには、大規模なさまざまなデバイス ファミリのさまざまな機能や機能がサポートしています。 すべてのユーザーの包括的なエクスペリエンスを実現するためには、デバイス間で、アプリケーションのスケールを確認し、ユーザーの優先順位を考慮する必要があります。 UI を調整すると、デバイスの機能を活用し、快適で包括的なユーザー エクスペリエンスを確保する効率的な方法が提供できます。

パフォーマンスの高い、美しい UI に関して次の領域の作業を含むさまざまなカテゴリは、UI を調整します。

- 尊重し、効果のユーザーの設定への対応
- アニメーションのユーザーの設定への対応
- 特定のハードウェア機能の UI の最適化

ここでは、効果や、上の領域でビジュアル レイヤーのアニメーションを調整する方法を説明しますが、優れたエンド ユーザー エクスペリエンスを確保するアプリケーションを調整するその他の多くの意味があります。 さまざまなデバイスや[応答性の高い UI を作成](/design/layout/responsive-design.md)する[UI を調整](/design/layout/screen-sizes-and-breakpoints-for-responsive-design.md)する方法に関するガイダンス ドキュメントを利用できます。

## <a name="user-effects-settings"></a>ユーザー設定の効果

ユーザーは、さまざまな理由から、アプリケーションが尊重し、対応する必要があります Windows エクスペリエンスをカスタマイズすることができます。 1 つの領域をエンドユーザーが制御できますが、システム全体で使用される、表示効果の種類を変更します。

### <a name="transparency-effects-settings"></a>透明効果の設定

ユーザーがカスタマイズできるこのような効果設定を 1 つは、透明効果をオン/オフにするとします。 [パーソナル設定] の下の設定アプリでこれを見つけることができます > 色、または設定アプリ経由 > 簡単 > 表示します。

![透明度設定オプション](images/tailoring-transparency-setting.png)

オンにすると、透明度を使用する任意の効果は、期待どおりに表示されます。 これは、アクリル、HostBackdropBrush、または完全に不透明なではない任意のカスタム効果グラフに適用されます。

無効にアクリル素材は自動的にフォールバックを無地の XAML のアクリル ブラシは既定ではこのイベントをリッスンがあるためです。 ここでは、適切にフォールバックする単色透明効果が有効になっていない電卓アプリを表示します。

![アクリルを使用した電卓](images/tailoring-acrylic.png)
![アクリルの透明度の設定への応答を使用した電卓](images/tailoring-acrylic-fallback.png)

ただし、すべてのカスタム効果のアプリケーションが[UISettings.AdvancedEffectsEnabled](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.uisettings.advancedeffectsenabledchanged)プロパティまたは[AdvancedEffectsEnabledChanged](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.uisettings.advancedeffectsenabledchanged)イベントに応答し、透明度を持たない特殊効果を使う効果/効果グラフを切り替える必要があります。 この例では、次にします。

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

同様に、アプリケーションがリッスンし、アニメーションをオンまたはオフの設定でユーザーの設定に基づくことを確認する[UISettings.AnimationsEnabled](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.uisettings.animationsenabled)プロパティに応答する必要があります > 簡単 > 表示します。

![アニメーションのオプションの設定](images/tailoring-animations-setting.png)

```cs
public MainPage()
{
   var uisettings = new UISettings();
   bool animationsEnabled = uisettings.AnimationsEnabled;
   // TODO respond to animations settings
}

```

## <a name="leveraging-the-capabilities-api"></a>API の機能を活用します。

[CompositionCapabilities](/uwp/api/windows.ui.composition.compositioncapabilities) Api を利用して、どのコンポジション機能利用可能なとパフォーマンスの高いで特定のハードウェアを検出し、エンドユーザーが任意のデバイスで、パフォーマンスに優れたと美しいエクスペリエンスを取得することを確認する設計を調整できます。 Api は、さまざまなフォーム ファクターでスケーリング正常な効果を実装するためにハードウェア システム機能を確認する手段を提供します。 これにより、簡単に美しいを作成するアプリケーションとシームレスなエンド ユーザー エクスペリエンスを適切に調整できます。

この API は、メソッドと効果のアプリケーション UI に意思決定をスケーリングするために使うイベント リスナーを提供します。 機能は、システムが複雑なコンポジションとレンダリング操作を処理するどの程度を検出し、開発者を利用するため、消費する簡単なモデルでは、情報を返します。

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
1. 効果を使用する場合は、まず capabilities オブジェクトを確認します。 条件チェックを使うことを検討するか、効果を調整する方法に応じて、コントロールのステートメントを切り替えます。

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

完全な例のコードは、 [Windows UI の Github リポジトリ](https://github.com/Microsoft/WindowsUIDevLabs/tree/master/SampleGallery/Samples/SDK%2015063/CompCapabilities)で確認できます。

## <a name="fast-vs-slow-effects"></a>高速低速な効果との比較

CompositionCapabilties API で提供されている[AreEffectsSupported](/uwp/api/windows.ui.composition.compositioncapabilities.areeffectssupported)と[AreEffectsFast](/uwp/api/windows.ui.composition.compositioncapabilities.areeffectsfast)メソッドからのフィードバックに基づき、最適化された任意の他の効果のコストやサポートされていない効果を交換するアプリケーションを決定できます。デバイス。 一部の効果他と比べてリソース負荷の高いを一貫することがわかって多用する必要があり、その他の効果を自由に使用することができます。 すべてのエフェクトのただし、注意するようにしてチェーンと一部のシナリオやの組み合わせとしてアニメーション化が効果グラフのパフォーマンス特性を変更可能性があります。 個々 のエフェクトのいくつかの経験則パフォーマンス特性を次に示します。

- 高パフォーマンスの影響を与えることがわかっている効果は次のように – ガウスぼかし、シャドウ マスク、BackDropBrush、HostBackDropBrush、ビジュアル レイヤー。 これらは、ローエンドのデバイス[(機能レベル 9.1 9.3)](https://msdn.microsoft.com/library/windows/desktop/ff476876(v=vs.85).aspx)では推奨されませんし、ハイエンド デバイスで慎重に使用する必要があります。
- 普通サイズのパフォーマンスへの影響を効果には、カラー マトリックス (明るさ、色、彩度および色相) 特定のブレンド効果 BlendModes スポット ライト、SceneLightingEffect、および (シナリオによって異なります) BorderEffect します。 これらの効果では、特定のシナリオ、ローエンドのデバイスで動作が、チェーンとアニメーション化するとき、注意を使用する必要があります。 以内に 2 つの使用を制限して、切り替えのみでアニメーション化することをお勧めします。
- その他のすべての効果は、低パフォーマンスの影響を与えるし、アニメーション化すると、チェーンのすべての妥当なシナリオで動作します。

## <a name="related-articles"></a>関連記事

- [UWP のレスポンシブ デザイン テクニック](https://docs.microsoft.com/windows/uwp/design/layout/responsive-design)
- [UWP デバイスの調整](https://docs.microsoft.com/windows/uwp/design/layout/screen-sizes-and-breakpoints-for-responsive-design)
