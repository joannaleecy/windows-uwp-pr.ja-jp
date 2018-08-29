---
author: daneuber
title: コンポジションの調整
description: UI のカスタマイズ、パフォーマンスを最適化およびユーザーの設定とデバイスの特性に対応するために構成 Api を使用します。
ms.author: jimwalk
ms.date: 07/16/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 66384c4df3195ae0fff35ae5dd7e1b1983204068
ms.sourcegitcommit: 3727445c1d6374401b867c78e4ff8b07d92b7adc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/29/2018
ms.locfileid: "2919092"
---
# <a name="tailoring-effects--experiences-using-windows-ui"></a>適合化の効果と Windows UI を使用しての経験

Windows UI は、差別化要因の多くの美しい効果、アニメーション、および手段を提供します。 ただし、パフォーマンスとカスタマイズ機能をユーザーの期待を満たすが成功したアプリケーションを作成するのに必要な部分です。 汎用の Windows プラットフォームでは、大規模で多様な一連のさまざまな機能と機能を持つデバイスをサポートします。 すべてのユーザーに対して、包括的な経験を提供するために複数のデバイス、アプリケーションの規模を確認し、ユーザーの基本設定を尊重する必要があります。 UI の調整と、デバイスの機能を活用し、快適で包括的なユーザー環境を実現する効率的な方法を提供できます。

UI の調整は、パフォーマンス、次の領域を基準に美しい UI の作業時間を含むさまざまなカテゴリです。

- 尊重し、効果の設定をユーザーに対応します。
- アニメーションのユーザー設定への対応
- 特定のハードウェア機能の UI を最適化します。

ここで、効果と、上記の領域にビジュアル層を使用してアニメーションを調整する方法を説明しますは、優れたエンド ユーザー エクスペリエンスを確保するようにアプリケーションを調整する他の多くの方法があります。 [UI のカスタマイズ](/design/layout/screen-sizes-and-breakpoints-for-responsive-design.md)をさまざまなデバイスや[応答性の高い UI を作成](/design/layout/responsive-design.md)する方法のガイダンスのドキュメントを利用できます。

## <a name="user-effects-settings"></a>ユーザー設定の効果

ユーザーは、さまざまな理由から、アプリケーションが尊重しに適応する必要があります Windows のエクスペリエンスをカスタマイズできます。 エンド ・ ユーザーを制御できる 1 つの領域は、システム全体で使用するを参照してください効果の種類を変更しています。

### <a name="transparency-effects-settings"></a>透明効果の設定

ユーザーがカスタマイズできるこのような 1 つのエフェクト設定は、透明効果をオン/オフにすること。 これでパーソナル化設定アプリを参照して > 色、またはアプリケーションの設定 > の簡単 > 表示します。

![設定で透明度のオプション](images/tailoring-transparency-setting.png)

オンにすると透明が使用されている任意の効果は期待どおりに表示されます。 これは、Acrylic、HostBackdropBrush、または完全に不透明ではない任意のカスタム効果グラフに適用されます。

オフに acrylic の材料に自動的に戻さ単色 acrylic ブラシを XAML の既定でこのイベントを調査した結果であるためです。 ここでは、電卓アプリケーションを適切に比較が純色の透明効果が有効になっていない場合参照してください。

![Acrylic と電卓](images/tailoring-acrylic.png)
![Acrylic の透明度の設定への対応と電卓](images/tailoring-acrylic-fallback.png)

ただし、ユーザー設定の効果はすべてのアプリケーションが[UISettings.AdvancedEffectsEnabled](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.uisettings.advancedeffectsenabledchanged)プロパティまたは[AdvancedEffectsEnabledChanged](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.uisettings.advancedeffectsenabledchanged)のイベントに応答し、効果がなく、透明度を使用する効果と効果のグラフを切り替える必要があります。 この例は、以下です。

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

同様に、アプリケーションがリッスンし、アニメーションがオンに設定] でユーザー設定に基づいて、無効するかを確認するのには[UISettings.AnimationsEnabled](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.uisettings.animationsenabled)プロパティに対応する必要があります > アクセスの容易さ > 表示します。

![アニメーション オプションの設定](images/tailoring-animations-setting.png)

```cs
public MainPage()
{
   var uisettings = new UISettings();
   bool animationsEnabled = uisettings.AnimationsEnabled;
   // TODO respond to animations settings
}

```

## <a name="leveraging-the-capabilities-api"></a>API の機能を活用します。

[CompositionCapabilities](/uwp/api/windows.ui.composition.compositioncapabilities) Api を活用するには、どの構成機能が利用可能とパフォーマンスの高い特定のハードウェアを検出し、エンド ・ ユーザーの任意のデバイス、パフォーマンスと美しい経験を取得することを確認するのにはデザインを調整できます。 Api では、さまざまなフォーム ファクターで拡大・縮小、正常な効果を実装するためにシステム ・ ハードウェアの機能を確認する手段を提供します。 これにより、簡単に美しいを作成するアプリケーションとのシームレスなエンド ユーザー エクスペリエンスを適切に調整します。

この API は、メソッド、およびアプリケーションの UI の意思決定を拡大/縮小効果を作成するのに使用できるイベントのリスナーを提供します。 機能では、システムが複雑なコンポジションとレンダリング操作を処理する方法もを検出し、消費を簡単にモデルを利用する開発者のための情報を取得します。

### <a name="using-composition-capabilities"></a>コンポジション機能を使用します。

CompositionCapabilities 機能を活用して、Acrylic 材料、位置、材料にフォールバック シナリオおよびハードウェアによって、複数の高性能な効果などの機能が既にされています。

API は、いくつかの簡単な手順で既存のコードを追加できます。

1. アプリケーションのコンス トラクター内の機能のオブジェクトを取得します。

    ```cs
    _capabilities = CompositionCapabilities.GetForCurrentView();
    ```

1. アプリの機能変更イベントのリスナーを登録します。

    ```cs
    _capabilities.Changed += HandleCapabilitiesChanged;
    ```

1. コンテンツをさまざまな機能レベルを処理するイベントのコールバック メソッドに追加します。 これは、次の手順を以下のようなことができない場合があります。
1. 効果を使用している場合は、まず機能オブジェクトを確認します。 条件チェックの使用を検討するか、または効果を調整する方法に応じて、制御ステートメントを切り替えます。

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

[Windows UI Github リポジトリの索引](https://github.com/Microsoft/WindowsUIDevLabs/tree/master/SampleGallery/Samples/SDK%2015063/CompCapabilities)に完全な例のコードをご覧ください。

## <a name="fast-vs-slow-effects"></a>高速低速の効果との比較

CompositionCapabilties API で提供されている[AreEffectsSupported](/uwp/api/windows.ui.composition.compositioncapabilities.areeffectssupported)および[AreEffectsFast](/uwp/api/windows.ui.composition.compositioncapabilities.areeffectsfast)メソッドからのフィードバックに基づき、アプリケーションことができます高価なまたはサポートされていない効果をスワップとして最適化されている任意の他の効果デバイスです。 いくつかの効果として知られて一貫して他のユーザーよりもリ スを使用しにのみ使用する必要があり、その他の効果をより自由に使用することができます。 すべてのエフェクトでは、ただし、注意するようにして効果のグラフのパフォーマンス特性を変更する場合がありますチェーンといくつかのシナリオの組み合わせとアニメーション化するとき。 次には、個々 のエフェクトのいくつかの経験則のパフォーマンス特性を示します。

- 効果の高いパフォーマンスへの影響があることがわかっているとおりです: ブラー (ガウス)、シャドウ マスク、BackDropBrush、HostBackDropBrush、およびレイヤーの視覚的です。 これらは、ローエンドのデバイス[(フィーチャー レベル 9.1 9.3)](https://msdn.microsoft.com/library/windows/desktop/ff476876(v=vs.85).aspx)では、お勧めしません、ハイ ・ エンド ・ デバイスで慎重に使用してください。
- 中程度のパフォーマンスへの影響、効果にカラー マトリックスでは、(明るさ、色、彩度および色相)、特定のブレンド効果 BlendModes は、スポット ライト、SceneLightingEffect、および (場合によって異なる) BorderEffect。 これらの効果は、ローエンドのデバイスでは、特定のシナリオで動作可能性がありますが、チェーンと、アニメーション化するときに、注意を使用する必要があります。 2 つまたはそれ以下の使用を制限して、遷移のみをアニメーション化することをお勧めします。
- その他のすべての効果は低パフォーマンスへの影響があるし、をアニメートすると、チェーンのすべての適切なシナリオでの作業します。

## <a name="related-articles"></a>関連記事

- [UWP の応答性の高い設計手法](https://docs.microsoft.com/windows/uwp/design/layout/responsive-design)
- [UWP デバイスの調整](https://docs.microsoft.com/windows/uwp/design/layout/screen-sizes-and-breakpoints-for-responsive-design)
