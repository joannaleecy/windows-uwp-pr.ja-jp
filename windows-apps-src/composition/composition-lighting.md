---
title: コンポジション照明
description: 動的な 3D ライティングをアプリケーションに追加する合成照明の Api を使用できます。
ms.date: 07/16/2018
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 733ce75942a05482ade88c1510e788f1cbd515d4
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57602207"
---
# <a name="using-lights-in-windows-ui"></a>Windows の UI でのライトの使用

Windows.UI.Composition Api を使用すると、リアルタイムのアニメーションや効果を作成できます。 コンポジション照明は、2 D のアプリケーションで 3D ライティングを使用できます。 この概要では、コンポジションのライトのセットアップ、各ライトを受信するビジュアルを識別し、効果を使用して、コンテンツの素材を定義する方法の機能を使用して実行します。

> [!NOTE]
> 読み取り方法を[XamlLight](/uwp/api/windows.ui.xaml.media.xamllight)オブジェクトを適用[CompositionLights](/uwp/api/Windows.UI.Composition.CompositionLight) XAML Uielement を明らかに、次を参照してください。 [XAML 照明](xaml-lighting.md)します。

コンポジション照明を使用して、UI を許可することで興味深いを作成できます。

- 音楽の再生のシーンなどの没入型のシナリオを有効にするシーン内の他のオブジェクトのライトに依存しない変換します。
- 一緒に移動できるように、ライトを持つオブジェクトをペアリングする機能 Fluent のようなシナリオを有効にするシーンの残りの部分の独立した[表示](/windows/uwp/design/style/reveal)を強調表示します。
- 素材と深さを作成するグループとして光とシーン全体の変換です。

コンポジション照明は、次の 3 つの主要な概念をサポートしています。**Light**、**ターゲット**、および**SceneLightingEffect**します。

## <a name="light"></a>明るい

[CompositionLight](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionlight)さまざまなライトを作成して、座標空間内に配置することができます。 これらのライトはターゲットがライトによって照らさとして識別するビジュアルです。

### <a name="light-types"></a>ライトの種類

| 種類 | 説明 |
| --- | --- |
| [Ambientlight を組み合わせます](/uwp/api/windows.ui.composition.ambientlight) | シーン内のすべてが表示される方向性のない光を放射光源が反映されます。 |
| [DistantLight](/uwp/api/windows.ui.composition.distantlight) | 無限に大規模な光源を 1 つの方向に光を出力します。 太陽の。 |
| [PointLight](/uwp/api/windows.ui.composition.pointlight) | すべての方向に光が放射される光のポイントのソース。 電球など。 |
| [スポット ライト](/uwp/api/windows.ui.composition.spotlight) | 光の内側と外側の円錐を出力する光源を使用します。 懐中電灯など。 |

## <a name="targets"></a>ターゲット

ライトがビジュアルを対象する場合 (に追加[ターゲット](/uwp/api/windows.ui.composition.compositionlight.targets)一覧)、ビジュアルとそのすべての子孫が認識して、この光源に応答します。 これは、ポイント ライトの方向をアニメーションに対応する以下のすべてのビジュアル ツリーのルートにある PointLight ソース設定と同じくらい単純ことができます。

**ExclusionsFromTargets**ターゲットを追加すると同様の方法でビジュアルの場合、またはビジュアルのサブツリーの照明を削除する機能を提供します。 除外されているビジュアルで root 化されているツリー内の子が結果として、点灯していません。

### <a name="sample-targets"></a>サンプル (ターゲット)

次の例では、XAML の TextBlock を対象に、CompositionPointLight を使用します。

```cs
    _pointLight = _compositor.CreatePointLight();
    _pointLight.Color = Colors.White;
    _pointLight.CoordinateSpace = text; //set up co-ordinate space for offset
    _pointLight.Targets.Add(text); //target XAML TextBlock
```

ポイント ライトのオフセットにアニメーションを追加することで、光る効果を簡単に行います。

```cs
_pointLight.Offset = new Vector3(-(float)TextBlock.ActualWidth, (float)TextBlock.ActualHeight / 2, (float)TextBlock.FontSize);
```

参照してください[テキスト シマー](https://github.com/Microsoft/WindowsUIDevLabs/tree/master/SampleGallery/Samples/SDK%2014393/TextShimmer)詳しく WindowUIDevLabs サンプル ギャラリーにあるサンプル。

## <a name="restrictions"></a>制限

CompositionLight で点灯するコンテンツを決定する際に考慮するいくつかの要素があります。

概念 | 詳細
--- | ---
**アンビエント ライト** | シーンに非アンビエント ライトを追加すると、既存のライトがすべてオフになります。  対象非アンビエント ライトでもないアイテムは、黒で表示されます。  自然な方法でライトによって発信周囲のビジュアルを点灯するには、他のライトと組み合わせて、アンビエント ライトを使用します。
**ライトの数** | UI を対象とするのに任意の組み合わせで、2 つの非アンビエント コンポジション ライトを使用できます。 アンビエント ライトではありません。スポット、ポイント、および離れたライトです。
**有効期間** | CompositionLight 有効期間の条件が発生する可能性があります (例: される前に、ガベージ コレクターは軽量のオブジェクトをリサイクル可能性があります)。  アプリケーションの有効期間の管理に役立つメンバーとして、ライトを追加することで、ライトへの参照を維持することをお勧めします。
**変換** | ライトをなどの効果を使用する UI 上のノードに配置する必要があります[パースペクティブ変換](/windows/uwp/design/layout/3-d-perspective-effects)で、視覚的な構造が適切に描画されます。
**ターゲットと座標空間** | CoordinateSpace は、visual の領域のすべてのライトのプロパティを設定する必要があります。 CompositionLight.Targets は CoordinateSpace ツリー内である必要があります。

## <a name="lighting-properties"></a>照明プロパティ

、使用するライトの種類に応じて、光の減衰と領域のプロパティことができます。 すべての種類の光源がすべてのプロパティを使うわけではありません。

プロパティ | 説明
--- | ---
**色** | [色](/uwp/api/windows.ui.color)光の。 光の色の値がによって定義されている[D3D](https://docs.microsoft.com/windows/uwp/graphics-concepts/light-properties)拡散、アンビエント、および反射出力される色を定義します。 照明ライト; RGBA 値が使用されます。色のアルファ コンポーネントは使用されません。
**方向** | 光の方向です。 に対して相対的な光が指している方向が指定されたその[CoordinateSpace](/uwp/api/windows.ui.composition.distantlight.coordinatespace)ビジュアル。
**座標空間** | すべてのビジュアルでは、暗黙の 3D 座標空間は。 X 方向は、左から右です。 Y 方向は、上から下です。 Z 方向は、平面からポイントです。 この座標の元のポイントは、ビジュアルの左上隅にあると、単位はデバイス独立ピクセル (DIP)。 この座標で定義されている光のオフセット。
**内側と外側の円錐** | スポットライトは、明るい内部コーンと外部コーンの 2 つの部分を持つ光のコーンを放射します。 コンポジションは、内側と外側の円錐の角度と色を制御できます。
**オフセット** | 座標空間 Visual 基準とした光の光源のオフセット。

> [!NOTE]
> 複数のライトが同じのビジュアルをヒットしたときに、または 1.0 を超える大きさ光の色の値を取得するたびに、光の色をクランプ ライトの色チャネルのため変更可能性があります。

### <a name="advanced-lighting-properties"></a>高度なライティング プロパティ

プロパティ | 説明
--- | ---
**輝度** | 光源の輝度を制御します。
**減衰** | 減衰は、範囲プロパティによって指定された最大距離にいたるまでに光の強さがどのように弱くなっていくかを制御します。  定数、Quadradic と線形 attenuation プロパティができます。

## <a name="getting-started-with-lighting"></a>照明の概要

ライトを追加する一般的な手順に従います。

- 作成し、ライトを配置します。ライトを作成し、指定された座標空間内に配置します。
- ライトをオブジェクトを識別します。関連するビジュアルのライトを対象します。
- [省略可能]どのように個々 のオブジェクトを定義ライトに対応します。EffectBrush SceneLightingEffect を使用すると、SpriteVisual を表示するためのライトの反射をカスタマイズできます。 リフレクションの既定値は、光源の CoordinateSpace の子の照明をサポートします。  SceneLightingEffect と描画ビジュアルには、そのビジュアルの既定の照明が上書きされます。

## <a name="scenelightingeffect"></a>SceneLightingEffect

[SceneLightingEffect](/uwp/api/Windows.UI.Composition.Effects.SceneLightingEffect)の内容に適用される既定の光源を変更するために使用する[SpriteVisual](/uwp/api/Windows.UI.Composition.SpriteVisual)の対象となる、 [CompositionLight](/uwp/api/windows.ui.composition.compositionlight)します。

[SceneLightingEffect](/uwp/api/Windows.UI.Composition.Effects.SceneLightingEffect)の素材の作成に頻繁に使用します。 SceneLightingEffect は、イメージの反射プロパティの有効化や法線マップで、奥行を提供するようより複雑なものを実現するときに使われる効果です。 SceneLightingEffect スペキュラ、拡散の金額のように照明プロパティを使用して、UI をカスタマイズする機能を提供します。 さらに、blend し、compose のコンテンツとのさまざまな照明反応に個別に使用できる効果のパイプラインの残りの部分と光源の効果をカスタマイズすることができます。

> [!NOTE]
> シーンの照明が shadows; を作成できません。2D レンダリングに重点を置いて効果になります。  影をなど、実際の照明モデルを含む考慮対象として 3D ライティング シナリオにはなりません。


プロパティ | 説明
--- | ---
**法線マップ** | NormalMaps では、テクスチャ、明るい光の方向に通常のポイントになりますであり通常を指しているすぐ調光の効果を作成します。 対象となる visual 使用時に、NormalMap を追加する、 [compositionsurfacebrush クラス](/uwp/api/Windows.UI.Composition.CompositionSurfaceBrush)NormalMap 資産を読み込む LoadedImageSurface を使用します。
**アンビエント** | アンビエント プロパティはほとんどの場合、全体的な色の反射を制御するために使用します。
**反射** | スペキュラ反射は、オブジェクト、光沢のある表示したりすることで、強調表示を作成します。 スペキュラ反射のレベルと光沢のレベルを制御できます。  これらのプロパティでは光沢金属など光沢紙の素材の効果を作成する操作します。
**拡散** | 拡散型のリフレクションでは、すべての方向に光を拡散します。
**反射のモデル** | [反射モデル](/uwp/api/windows.ui.composition.effects.scenelightingeffectreflectancemodel)間を選択することができます[Blinn フォン](https://docs.microsoft.com/visualstudio/designers/how-to-create-a-basic-phong-shader)と Blinn フォンを物理的に基づきます。  反射の光源が狭い場合は、Blinn フォンを物理的にベースを選択します。

### <a name="sample-scenelightingeffect"></a>サンプル (SceneLightingEffect)

以下のサンプルでは、通常のマップを SceneLightingEffect を追加する方法を示します。

```cs
CompositionBrush CreateNormalMapBrush(ICompositionSurface normalMapImage)
{
    var colorSourceEffect = new ColorSourceEffect()
    {
        Color = Colors.White
    };
    var sceneLightingEffect = new SceneLightingEffect()
    {
        NormalMapSource = new CompositionEffectSourceParameter("NormalMap")
    };

    var compositeEffect = new ArithmeticCompositeEffect()
    {
        Source1 = colorSourceEffect,
        Source2 = sceneLightingEffect,
    };

    var factory = _compositor.CreateEffectFactory(sceneLightingEffect);

    var normalMapBrush = _compositor.CreateSurfaceBrush();
    normalMapBrush.Surface = normalMapImage;
    normalMapBrush.Stretch = CompositionStretch.Fill;

    var brush = factory.CreateBrush();
    brush.SetSourceParameter("NormalMap", normalMapBrush);

    return brush;
}
```

## <a name="related-articles"></a>関連記事

- [ビジュアル層で素材と光源を作成します。](https://blogs.windows.com/buildingapps/2017/08/04/creating-materials-lights-visual-layer/)
- [照明の概要](https://docs.microsoft.com/windows/uwp/graphics-concepts/lighting-overview)
- [CompositionCapabilities API](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositioncapabilities)
- [照明の計算](https://docs.microsoft.com/windows/uwp/graphics-concepts/mathematics-of-lighting)
- [SceneLightingEffect](https://docs.microsoft.com/uwp/api/windows.ui.composition.effects.scenelightingeffect)
- [WindowsUIDevLabs GitHub リポジトリ](https://github.com/Microsoft/WindowsUIDevLabs)
