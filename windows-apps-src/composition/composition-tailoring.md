---
title: コンポジションの調整
description: 合成 Api を使用すると、UI を調整、パフォーマンスを最適化およびユーザー設定とデバイスの特性に対応します。
ms.date: 07/16/2018
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: bcc9a6d89a143d8fd03d73dbd83b832ed9513ee2
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57644417"
---
# <a name="tailoring-effects--experiences-using-windows-ui"></a>効果 & Windows UI を使用してエクスペリエンスを調整すること

Windows UI は、差別化要因の多くの美しい効果、アニメーション、および手段を提供します。 ただし、パフォーマンスとカスタマイズ性のためのユーザーの期待を満たすが成功したアプリケーションを作成するのに必要です。 ユニバーサル Windows プラットフォームには、さまざまな機能と機能が含まれる、デバイスの大規模で多様なファミリがサポートしています。 すべてのユーザーに対して、包括的なエクスペリエンスを提供するためには、デバイス間で、アプリケーションのスケールをことを確認し、ユーザー設定を尊重する必要があります。 UI を調整することと、デバイスの機能を活用し、快適になり、包括的なユーザー エクスペリエンスを実現する効率的な方法を提供できます。

パフォーマンスの高い、美しい UI に関して、次の領域の作業を包括的な広範なカテゴリは、UI を調整すること。

- 尊重し、効果のユーザー設定に合わせて調整
- アニメーションのユーザー設定への対応
- 特定のハードウェア機能の UI を最適化します。

ここでは、効果と、上の領域でビジュアル層でアニメーションを調整する方法について説明しますは、アプリケーションに優れたエンド ユーザー エクスペリエンスを調整するその他の多くの方法があります。 Docs のガイダンスにする方法で使用可能な[、UI を調整](/windows/uwp/design/layout/screen-sizes-and-breakpoints-for-responsive-design)さまざまなデバイス用と[レスポンシブ UI を作成](/windows/uwp/design/layout/responsive-design)です。

## <a name="user-effects-settings"></a>ユーザー設定の効果

ユーザーは、さまざまな理由から、アプリケーションが尊重しに適応する必要があります Windows エクスペリエンスをカスタマイズできます。 エンド ユーザーを制御できる 1 つの領域は、システム全体で使用される表示の副作用の種類を変更します。

### <a name="transparency-effects-settings"></a>透明度の設定の効果

ユーザーがカスタマイズできるこのような効果設定を 1 つは、透明効果オン/オフにすることです。 パーソナル化の下で、設定アプリで確認できます > 色、または [設定] アプリを使用 > コンピューターの簡単操作 > 表示します。

![透明度オプションの設定](images/tailoring-transparency-setting.png)

オンにすると、期待どおりに透明度を使用する影響が表示されます。 これは、アクリル、HostBackdropBrush、または完全に不透明でない任意のカスタム効果グラフに適用されます。

オフのときアクリル素材が自動的にフォールバックを純色ため、XAML の acrylic ブラシが既定でこのイベントをリッスンします。 ここでは、電卓アプリケーションを適切にフォールバックを純色を透明効果が有効になっていないときに表示されます。

![アクリル電卓](images/tailoring-acrylic.png)
![アクリル透明度の設定への応答での計算ツール](images/tailoring-acrylic-fallback.png)

ただし、任意のカスタム エフェクト アプリケーションの必要がありますに応答する、 [UISettings.AdvancedEffectsEnabled](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.uisettings.advancedeffectsenabledchanged)プロパティまたは[AdvancedEffectsEnabledChanged](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.uisettings.advancedeffectsenabledchanged)イベントとスイッチ アウト影響/影響透過性がない効果を使用するグラフ。 この例を次に。

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

同様に、アプリケーションがリッスンして、応答する必要があります、 [UISettings.AnimationsEnabled](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.uisettings.animationsenabled)アニメーションのことを確認するプロパティがオンまたはオフに設定でユーザー設定に基づいて > コンピューターの簡単操作 > 表示します。

![アニメーション設定のオプション](images/tailoring-animations-setting.png)

```cs
public MainPage()
{
   var uisettings = new UISettings();
   bool animationsEnabled = uisettings.AnimationsEnabled;
   // TODO respond to animations settings
}

```

## <a name="leveraging-the-capabilities-api"></a>API の機能を活用します。

利用して、 [CompositionCapabilities](/uwp/api/windows.ui.composition.compositioncapabilities) Api どの合成で各機能は使用とパフォーマンスの高い特定のハードウェアを検出してエンドユーザーの高性能、美しいエクスペリエンスを取得することを確認するデザインの調整デバイスです。 Api は、正常な効果がさまざまなフォーム ファクターでスケーリングを実装するためにハードウェア システムの機能を確認するための手段を提供します。 これにより、簡単に美しいを作成するアプリケーションとシームレスなエンド ユーザー エクスペリエンスを適切に調整できます。

この API は、メソッドと効果をアプリケーションの UI の決定事項を評価に使用できるイベント リスナーを提供します。 機能は、システムが複雑な構成と、レンダリング操作を処理する方法もを検出し、使いやすいモデルを利用する開発者向けの情報を返します。

### <a name="using-composition-capabilities"></a>コンポジション機能を使用してください。

CompositionCapabilities 機能は既にアクリル素材を場所、マテリアルはフォールバックして、シナリオとハードウェアに応じてより高いパフォーマンス効果などの機能の活用されています。

API は、いくつかの簡単な手順で既存のコードに追加できます。

1. アプリケーションのコンストラクターで機能オブジェクトを取得します。

    ```cs
    _capabilities = CompositionCapabilities.GetForCurrentView();
    ```

1. アプリの機能変更イベント リスナーを登録します。

    ```cs
    _capabilities.Changed += HandleCapabilitiesChanged;
    ```

1. コンテンツは、さまざまな機能レベルを処理するイベントのコールバック メソッドを追加します。 これは、次の手順を次のようなことができない可能性がありますもかまいません。
1. 効果を使用する場合は、まず機能オブジェクトを確認します。 条件付きチェックの使用を検討するか、または効果を調整する方法に応じて、コントロール ステートメントを切り替えます。

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

全体のコード例で確認できます、 [Windows UI の Github リポジトリ](https://github.com/Microsoft/WindowsUIDevLabs/tree/master/SampleGallery/Samples/SDK%2015063/CompCapabilities)します。

## <a name="fast-vs-slow-effects"></a>低速の効果と高速

提供されたフィードバックに基づく[AreEffectsSupported](/uwp/api/windows.ui.composition.compositioncapabilities.areeffectssupported)と[AreEffectsFast](/uwp/api/windows.ui.composition.compositioncapabilities.areeffectsfast) CompositionCapabilities API のメソッドは、アプリケーションは、のコストがかかったり、サポートされていない効果をスワップすることもできますその他の効果の任意のデバイス用に最適化されます。 効果をいくつかが明らかに一貫して他のユーザーよりもリソースを使用し、適度に使用する必要があり、その他の効果をより自由に使用できます。 すべての効果のただし、注意する必要があります使用効果グラフのパフォーマンス特性を変更することがありますチェーンといくつかのシナリオの組み合わせとアニメーション化するときに。 次には、個々 のエフェクトのいくつかの経験則パフォーマンス特性を示します。

- 高パフォーマンスの影響を与えることがわかっている効果、次のように – ガウスぼかしシャドウ マスク、BackDropBrush、HostBackDropBrush、ビジュアル レイヤー。 これらは、ローエンド デバイスの場合は推奨されません[(機能レベル 9.1 9.3)](https://msdn.microsoft.com/library/windows/desktop/ff476876(v=vs.85).aspx)、ハイ エンド デバイスで慎重に使用する必要があります。
- 中程度のパフォーマンスへの影響を効果にカラー行列を特定ブレンド効果 BlendModes (光度、色、鮮やかさ、および Hue) は、スポット ライト、SceneLightingEffect、および (シナリオによって異なる) BorderEffect します。 ローエンドのデバイスで特定のシナリオでこれらの効果が動作しますが、チェーンとアニメーション化するときに、注意を使用する必要があります。 以下に 2 つの使用を制限して、遷移のみをアニメーション化をお勧めします。
- 他のすべての効果は、低パフォーマンスに影響し、アニメーション化すると、チェーンのすべての妥当なシナリオでは機能します。

## <a name="related-articles"></a>関連記事

- [UWP のレスポンシブ デザイン手法](https://docs.microsoft.com/windows/uwp/design/layout/responsive-design)
- [UWP デバイスの調整](https://docs.microsoft.com/windows/uwp/design/layout/screen-sizes-and-breakpoints-for-responsive-design)
