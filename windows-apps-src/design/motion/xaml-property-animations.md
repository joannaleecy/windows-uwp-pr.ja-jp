---
author: Jwmsft
title: XAML プロパティのアニメーション
description: コンポジション アニメーションでの XAML 要素をアニメーション化します。
ms.author: jimwalk
ms.date: 09/13/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
pm-contact: stmoy
design-contact: jeffarn
ms.localizationpriority: medium
ms.openlocfilehash: a03ffc8d5ea78ee6cbdf78feaae7ba1cd1448f37
ms.sourcegitcommit: 9354909f9351b9635bee9bb2dc62db60d2d70107
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/16/2018
ms.locfileid: "4679624"
---
# <a name="animating-xaml-elements-with-composition-animations"></a>コンポジション アニメーションでの XAML 要素をアニメーション化

この記事では、コンポジション アニメーションのパフォーマンスと XAML プロパティを設定するの簡単で XAML UIElement をアニメーション化することができる新しいプロパティが導入されています。

Windows 10 version 1809、以前には、UWP アプリでのアニメーションを構築する 2 つの選択肢がありました。

- [Storyboarded アニメーション](storyboarded-animations.md)と同様に、XAML 構造を使用して、または _* themetransition という単語_と _* themeanimation という単語_ [Windows.UI.Xaml.Media.Animation](/uwp/api/windows.ui.xaml.media.animation)名前空間のクラスです。
- [XAML とビジュアル レイヤーの使用](../../composition/using-the-visual-layer-with-xaml.md)」の説明に従って、コンポジションのアニメーションを使用します。

ビジュアル レイヤーの使用は、XAML の使用を構築します。 より優れたパフォーマンスを提供します。 ただし、 [ElementCompositionPreview](/uwp/api/Windows.UI.Xaml.Hosting.ElementCompositionPreview)を使用して、要素の基になる合成、[ビジュアル](/uwp/api/windows.ui.composition.visual)オブジェクトを取得して、コンポジションのアニメーションでは、ビジュアルをアニメーション化し、使用するより複雑です。

Windows 10、バージョン 1809、以降では基になる合成 Visual を取得する必要はありませんコンポジション アニメーションを使用して直接 UIElement のプロパティをアニメーション化できます。

> [!NOTE]
> UIElement でこれらのプロパティを使用するには、UWP プロジェクトのターゲット バージョン 1809 以降である必要があります。 プロジェクトのバージョンの構成について詳しくは、[バージョン アダプティブ アプリ](../../debug-test-perf/version-adaptive-apps.md)を参照してください。

## <a name="new-rendering-properties-replace-old-rendering-properties"></a>レンダリングの新しいプロパティが古いレンダリング プロパティを置き換えます

次の表では、 [CompositionAnimation](/uwp/api/windows.ui.composition.compositionanimation)とアニメーション化もできる、UIElement のレンダリングを変更するに使用できるプロパティを示します。

| プロパティ | 型 | 説明 |
| -- | -- | -- |
| [Opacity](/uwp/api/windows.ui.xaml.uielement.opacity) | Double | オブジェクトの不透明度 |
| [Translation](/uwp/api/windows.ui.xaml.uielement.translation) | Vector3 | 要素の X、Y、/Z 位置を移動します。 |
| [Transformmatrix などがあります。](/uwp/api/windows.ui.xaml.uielement.transformmatrix) | Matrix4x4 | 要素に適用する変換行列 |
| [Scale](/uwp/api/windows.ui.xaml.uielement.scale) | Vector3 | 中心点を中心と、要素をスケーリングします。 |
| [回転](/uwp/api/windows.ui.xaml.uielement.rotation) | Float | RotationAxis と中心点の周囲の要素を回転させる |
| [RotationAxis](/uwp/api/windows.ui.xaml.uielement.rotationaxis) | Vector3 | 回転の軸 |
| [CenterPoint](/uwp/api/windows.ui.xaml.uielement.centerpoint) | Vector3 | スケール、回転の中心点 |

次の順序で拡大縮小、回転、および Translation プロパティを持つ transformmatrix などがありますプロパティの値を組み合わせる: transformmatrix などがあります、スケール、回転、平行移動します。

これらのプロパティは、要素のレイアウトに影響しないと、ためこれらのプロパティを変更すると、新しい[測定](/uwp/api/windows.ui.xaml.uielement.measure)が発生しない/[配置](/uwp/api/windows.ui.xaml.uielement.arrange)パス。

これらのプロパティとしてという名前のようなプロパティは、コンポジション (翻訳 Visual に表示されていない) を除く[Visual](/uwp/api/windows.ui.composition.visual)クラスで、目的と動作が同じであります。

### <a name="example-setting-the-scale-property"></a>例: Scale プロパティを設定します。

この例では、ボタンに Scale プロパティを設定する方法を示します。

```xaml
<Button Scale="2,2,1" Content="I am a large button" />
```

```csharp
var button = new Button();
button.Content = "I am a large button";
button.Scale = new Vector3(2.0f,2.0f,1.0f);
```

### <a name="mutual-exclusivity-between-new-and-old-properties"></a>新規および既存のプロパティの間の相互の排他状態

> [!NOTE]
> **不透明度**のプロパティでは、このセクションで説明されている相互排他状態は適用されません。 XAML またはコンポジション アニメーションを使用するかどうかは、同じの Opacity プロパティを使用します。

Compositionanimation と関連付けてでアニメーション化できるプロパティには、いくつかの既存の UIElement プロパティ用の代替機能があります。

- [RenderTransform](/uwp/api/windows.ui.xaml.uielement.rendertransform)
- [RenderTransformOrigin](/uwp/api/windows.ui.xaml.uielement.rendertransformorigin)
- [Projection](/uwp/api/windows.ui.xaml.uielement.projection)
- [Transform3D](/uwp/api/windows.ui.xaml.uielement.transform3d)

設定 (アニメーション化) のすべての新しいプロパティか、または以前のプロパティを使うことはできません。 逆に、ユーザー設定 (またはアニメーション化) の以前のプロパティ場合、は、新しいプロパティを使用できません。

使うことはできません、新しいプロパティを取得して、これらのメソッドを使用して自分でビジュアルを管理する ElementCompositionPreview を使用する場合。

- [ElementCompositionPreview.GetElementVisual](/uwp/api/windows.ui.xaml.hosting.elementcompositionpreview.getelementvisual)
- [ElementCompositionPreview.SetIsTranslationEnabled](/uwp/api/windows.ui.xaml.hosting.elementcompositionpreview.setistranslationenabled)

> [!IMPORTANT]
> しようとすると、2 つのプロパティの使用を混在させると、API の呼び出しが失敗して、エラー メッセージを生成します。

わかりやすくするためにはお勧めしませんが、それらをオフにしてから 1 つの一連のプロパティの切り替えを行うことができます。 DependencyProperty によって、プロパティがサポートされる場合 (たとえば、UIElement.Projection は、対応 UIElement.ProjectionProperty)、「未使用」の状態に復元する ClearValue を呼び出します。 (たとえば、Scale プロパティ)、それ以外の場合は、既定値にプロパティを設定します。

## <a name="animating-uielement-properties-with-compositionanimation"></a>CompositionAnimation を持つ UIElement プロパティをアニメーション化

Compositionanimation と関連付けての表に示すレンダリング プロパティをアニメーション化することができます。 [Expressionanimation を使用](/uwp/api/windows.ui.composition.expressionanimation)して、これらのプロパティを参照することもできます。

UIElement で[StartAnimation](/uwp/api/windows.ui.xaml.uielement.startanimation)と[StopAnimation](/uwp/api/windows.ui.xaml.uielement.stopanimation)メソッドを使用すると、UIElement のプロパティをアニメーション化します。

### <a name="example-animating-the-scale-property-with-a-vector3keyframeanimation"></a>例: Vector3KeyFrameAnimation を Scale プロパティをアニメーション化

この例では、ボタンのスケールをアニメーション化する方法を示します。

```csharp
var compositor = Window.Current.Compositor;
var animation = compositor.CreateVector3KeyFrameAnimation();

animation.InsertKeyFrame(1.0f, new Vector3(2.0f,2.0f,1.0f));
animation.Duration = TimeSpan.FromSeconds(1);
animation.Target = "Scale";

button.StartAnimation(animation);
```

### <a name="example-animating-the-scale-property-with-an-expressionanimation"></a>例: expressionanimation を使用して Scale プロパティをアニメーション化

ページには、2 つのボタンがあります。 (スケール) 経由で大規模な回する 2 番目のボタンがアニメーション化の最初のボタンとしてします。

```xaml
<Button x:Name="sourceButton" Content="Source"/>
<Button x:Name="destinationButton" Content="Destination"/>
```

```csharp
var compositor = Window.Current.Compositor;
var animation = compositor.CreateExpressionAnimation("sourceButton.Scale*2");
animation.SetExpressionReferenceParameter("sourceButton", sourceButton);
animation.Target = "Scale";
destinationButton.StartAnimation(animation);
```

## <a name="related-topics"></a>関連トピック

- [ストーリーボードに設定されたアニメーション](storyboarded-animations.md)
- [XAML でのビジュアル レイヤーの使用](../../composition/using-the-visual-layer-with-xaml.md)
- [変換の概要](../layout/transforms.md)