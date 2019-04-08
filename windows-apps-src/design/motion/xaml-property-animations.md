---
title: XAML プロパティのアニメーション
description: 合成アニメーションを XAML 要素をアニメーション化します。
ms.date: 09/13/2018
ms.topic: article
keywords: windows 10, uwp
pm-contact: stmoy
design-contact: jeffarn
ms.localizationpriority: medium
ms.custom: RS5
ms.openlocfilehash: 81da1e769ab171e47a4f4046e8ec7e7c84ecf2d1
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57630357"
---
# <a name="animating-xaml-elements-with-composition-animations"></a>合成アニメーションを XAML 要素をアニメーション化

この記事では、合成アニメーションのパフォーマンスと XAML のプロパティの設定の容易さと XAML UIElement をアニメーション化できる新しいプロパティについて説明します。

Windows 10、バージョンは 1809、以前は、UWP アプリでのアニメーションを作成する 2 つの選択肢がありました。

- などの XAML の構成要素を使用して、[アニメーションを再検討](storyboarded-animations.md)、または _* ThemeTransition_と _* ThemeAnimation_クラス、 [Windows.UI.Xaml.Media.Animation](/uwp/api/windows.ui.xaml.media.animation)名前空間。
- 」の説明に従って、合成アニメーションを使用して[XAML のビジュアル層を使用して](../../composition/using-the-visual-layer-with-xaml.md)します。

ビジュアル層を使用して構築します、XAML を使用してより優れたパフォーマンスを提供します。 使用していますが[ElementCompositionPreview](/uwp/api/Windows.UI.Xaml.Hosting.ElementCompositionPreview)要素の取得の基になるコンポジション[Visual](/uwp/api/windows.ui.composition.visual)オブジェクト、および、合成アニメーションでビジュアルをアニメーション化し、使用するより複雑な。

Windows 10、バージョンは 1809、以降のプロパティを基になる合成ビジュアルを取得する必要がなく、合成アニメーションを使用して直接 UIElement をアニメーション化できます。

> [!NOTE]
> UIElement にこれらのプロパティを使用するには、UWP プロジェクトのターゲット バージョンは 1809 以降にする必要があります。 プロジェクトのバージョンを構成する方法の詳細については、次を参照してください。[バージョン アダプティブ アプリ](../../debug-test-perf/version-adaptive-apps.md)します。

## <a name="new-rendering-properties-replace-old-rendering-properties"></a>新しいレンダリング プロパティは、古いレンダリング プロパティを置き換えます

この表でアニメーション化もできる、UIElement のレンダリングを変更に使用できるプロパティを示します、 [CompositionAnimation](/uwp/api/windows.ui.composition.compositionanimation)します。

| プロパティ | 種類 | 説明 |
| -- | -- | -- |
| [不透明度](/uwp/api/windows.ui.xaml.uielement.opacity) | Double | オブジェクトの不透明度 |
| [翻訳](/uwp/api/windows.ui.xaml.uielement.translation) | Vector3 | 要素の X、Y、/Z 位置をシフトします。 |
| [平行移動](/uwp/api/windows.ui.xaml.uielement.transformmatrix) | Matrix4x4 | 要素に適用する変換行列 |
| [スケール](/uwp/api/windows.ui.xaml.uielement.scale) | Vector3 | スケール、要素中心点の中央に配置 |
| [回転](/uwp/api/windows.ui.xaml.uielement.rotation) | Float | RotationAxis および中心点を中心、要素を回転させる |
| [RotationAxis](/uwp/api/windows.ui.xaml.uielement.rotationaxis) | Vector3 | 回転の軸 |
| [中心点](/uwp/api/windows.ui.xaml.uielement.centerpoint) | Vector3 | 拡大縮小や回転の中心点 |

TransformMatrix プロパティの値は、次の順序でスケール、回転、および変換のプロパティと組み合わせます。Scale、Rotation、Translation と平行移動します。

これらのプロパティは、要素のレイアウトに影響はありません、ためこれらのプロパティを変更するは発生しません新しい[メジャー](/uwp/api/windows.ui.xaml.uielement.measure)/[配置](/uwp/api/windows.ui.xaml.uielement.arrange)渡します。

これらのプロパティとしてコンポジションに似た名前の付いたプロパティの目的と動作が同じである[Visual](/uwp/api/windows.ui.composition.visual)クラス (を除く翻訳は、ビジュアルではありません)。

### <a name="example-setting-the-scale-property"></a>以下に例を示します。スケールのプロパティの設定

この例では、ボタンのスケールのプロパティを設定する方法を示します。

```xaml
<Button Scale="2,2,1" Content="I am a large button" />
```

```csharp
var button = new Button();
button.Content = "I am a large button";
button.Scale = new Vector3(2.0f,2.0f,1.0f);
```

### <a name="mutual-exclusivity-between-new-and-old-properties"></a>新規および既存のプロパティの間で相互に排他的

> [!NOTE]
> **不透明度**プロパティでは、このセクションで説明されている相互に排他的は強制されません。 XAML または合成アニメーションを使用するかどうかは、同じ不透明度プロパティを使用します。

CompositionAnimation をアニメーション化できるプロパティは、いくつかの既存の UIElement プロパティの置き換えです。

- [RenderTransform](/uwp/api/windows.ui.xaml.uielement.rendertransform)
- [RenderTransformOrigin](/uwp/api/windows.ui.xaml.uielement.rendertransformorigin)
- [射影](/uwp/api/windows.ui.xaml.uielement.projection)
- [Transform3D](/uwp/api/windows.ui.xaml.uielement.transform3d)

または設定すると (アニメーション化する)、新しいプロパティのいずれか、古いプロパティを使用することはできません。 逆に、設定 (またはアニメーション化する) 場合、古いプロパティのいずれかは、新しいプロパティを使用することはできません。

使用することもできない新しいプロパティを取得し、これらのメソッドを使用して自分でビジュアルを管理する ElementCompositionPreview を使用する場合。

- [ElementCompositionPreview.GetElementVisual](/uwp/api/windows.ui.xaml.hosting.elementcompositionpreview.getelementvisual)
- [ElementCompositionPreview.SetIsTranslationEnabled](/uwp/api/windows.ui.xaml.hosting.elementcompositionpreview.setistranslationenabled)

> [!IMPORTANT]
> 2 つのプロパティのセットを併用しようとして失敗し、エラー メッセージを生成するには、API 呼び出しになります。

わかりやすくするためにはお勧めしませんが、オフにすると、プロパティの 1 つのセットから切り替えるになります。 プロパティは、DependencyProperty でバックアップされている場合 (たとえば、UIElement.Projection 支え UIElement.ProjectionProperty)、「未使用」の状態に復元する ClearValue を呼び出します。 (たとえば、スケールのプロパティ)、それ以外の場合は、既定値に、プロパティを設定します。

## <a name="animating-uielement-properties-with-compositionanimation"></a>CompositionAnimation の UIElement のプロパティをアニメーション化

CompositionAnimation での表に表示プロパティをアニメーション化することができます。 これらのプロパティを参照することも、 [ExpressionAnimation](/uwp/api/windows.ui.composition.expressionanimation)します。

使用して、 [StartAnimation](/uwp/api/windows.ui.xaml.uielement.startanimation)と[StopAnimation](/uwp/api/windows.ui.xaml.uielement.stopanimation) UIElement UIElement プロパティをアニメーション化するメソッド。

### <a name="example-animating-the-scale-property-with-a-vector3keyframeanimation"></a>以下に例を示します。Vector3KeyFrameAnimation とスケールのプロパティをアニメーション化

この例では、ボタンの小数点以下桁数をアニメーション化する方法を示します。

```csharp
var compositor = Window.Current.Compositor;
var animation = compositor.CreateVector3KeyFrameAnimation();

animation.InsertKeyFrame(1.0f, new Vector3(2.0f,2.0f,1.0f));
animation.Duration = TimeSpan.FromSeconds(1);
animation.Target = "Scale";

button.StartAnimation(animation);
```

### <a name="example-animating-the-scale-property-with-an-expressionanimation"></a>以下に例を示します。ExpressionAnimation とスケールのプロパティをアニメーション化

ページには、2 つのボタンがあります。 2 番目のボタンを 2 倍に (スケール) を使用してアニメーションの最初のボタンとして。

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

- [アニメーションの再検討](storyboarded-animations.md)
- [XAML でビジュアル層の使用](../../composition/using-the-visual-layer-with-xaml.md)
- [変換の概要](../layout/transforms.md)
