---
title: コンポジション シャドウ
description: シャドウの Api を使用して、UI のコンテンツを動的にカスタマイズ可能なシャドウを追加できます。
ms.date: 07/16/2018
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 9541ea1c00d473bc4881a80d8597625592e278f9
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57630837"
---
# <a name="shadows-in-windows-ui"></a>Windows UI のシャドウ

[DropShadow](/uwp/api/Windows.UI.Composition.DropShadow)クラスに適用できる構成可能なシャドウの作成方法を提供する、 [SpriteVisual](/uwp/api/windows.ui.composition.spritevisual)または[LayerVisual](/uwp/api/windows.ui.composition.layervisual) (ビジュアルのサブツリー)。 ビジュアル層でオブジェクトの慣習はでは、CompositionAnimations を使用して、DropShadow のすべてのプロパティをアニメーション化することができます。

## <a name="basic-drop-shadow"></a>基本的なドロップ シャドウ

基本的な影を作成するには、新しい DropShadow を作成し、それをビジュアルに関連付けます。 シャドウは既定では四角形です。 標準的な一連のプロパティをシャドウのルック アンド フィールを調整する利用できます。

```cs
var basicRectVisual = _compositor.CreateSpriteVisual();
basicRectVisual.Brush = _compositor.CreateColorBrush(Colors.Blue);
basicRectVisual.Offset = new Vector3(100, 100, 20);
basicRectVisual.Size = new Vector2(300, 300);

var basicShadow = _compositor.CreateDropShadow();
basicShadow.BlurRadius = 25f;
basicShadow.Offset = new Vector3(20, 20, 20);

basicRectVisual.Shadow = basicShadow;
```

![四角形のビジュアルを基本 DropShadow](images/rectangular-dropshadow.png)

## <a name="shaping-the-shadow"></a>影の整形

これには、DropShadow の形を定義するいくつかの方法があります。

- **既定値を使用して、** - 既定では、DropShadow 図形が CompositionDropShadowSourcePolicy で 'Default' モードで定義されています。 SpriteVisual で、既定値は四角形、マスクを指定しない場合です。 LayerVisual、既定値では、ビジュアルのブラシのアルファを使用してマスクを継承します。
- **マスクを設定**– を設定することがあります、[マスク](/uwp/api/windows.ui.composition.dropshadow.mask)シャドウの不透明度マスクを定義するプロパティ。
- **継承されたマスクを使用するように指定**設定 –、 [SourcePolicy](/uwp/api/windows.ui.composition.dropshadow.sourcepolicy)プロパティを使用する[CompositionDropShadowSourcePolicy](/uwp/api/windows.ui.composition.compositiondropshadowsourcepolicy)します。 InheritFromVisualContent ビジュアルのブラシのアルファから生成されるマスクを使用します。

## <a name="masking-to-match-your-content"></a>コンテンツの一致するようにマスク

ビジュアルのコンテンツの一致するように、シャドウする場合、ビジュアルのブラシを使用して、シャドウ マスク プロパティのかコンテンツからマスクを自動的に継承するように影を設定します。 場合は、LayerVisual を使用して、影は既定では、マスクを継承します。

```cs
var imageSurface = LoadedImageSurface.StartLoadFromUri(new Uri("ms-appx:///Assets/myImage.png"));
var imageBrush = _compositor.CreateSurfaceBrush(imageSurface);

var imageSpriteVisual = _compositor.CreateSpriteVisual();
imageSpriteVisual.Size = new Vector2(400,400);
imageSpriteVisual.Offset = new Vector3(100, 500, 20);
imageSpriteVisual.Brush = imageBrush;

var shadow = _compositor.CreateDropShadow();
shadow.Mask = imageBrush;
// or use shadow.SourcePolicy = CompositionDropShadowSourcePolicy.InheritFromVisualContent;
shadow.BlurRadius = 25f;
shadow.Offset = new Vector3(20, 20, 20);

imageSpriteVisual.Shadow = shadow;
```

![マスクされたドロップ シャドウを伴って接続された web イメージ](images/ms-brand-web-dropshadow.png)

## <a name="using-an-alternative-mask"></a>代替のマスクを使用してください。

場合によっては、図形、影のビジュアルのコンテンツと一致しないようにする場合があります。 この効果を実現するには、アルファのブラシを使って、マスク プロパティを明示的に設定する必要があります。

次の例では、2 つのサーフェスのビジュアルのコンテンツのいずれかと、シャドウ マスク用に 1 つを読み込んでいます。

```cs
var imageSurface = LoadedImageSurface.StartLoadFromUri(new Uri("ms-appx:///Assets/myImage.png"));
var imageBrush = _compositor.CreateSurfaceBrush(imageSurface);

var circleSurface = LoadedImageSurface.StartLoadFromUri(new Uri("ms-appx:///Assets/myCircleImage.png"));
var customMask = _compositor.CreateSurfaceBrush(circleSurface);

var imageSpriteVisual = _compositor.CreateSpriteVisual();
imageSpriteVisual.Size = new Vector2(400,400);
imageSpriteVisual.Offset = new Vector3(100, 500, 20);
imageSpriteVisual.Brush = imageBrush;

var shadow = _compositor.CreateDropShadow();
shadow.Mask = customMask;
shadow.BlurRadius = 25f;
shadow.Offset = new Vector3(20, 20, 20);

imageSpriteVisual.Shadow = shadow;
```

![接続された web イメージ枠で囲まれたマスク ドロップ シャドウ](images/ms-brand-web-masked-dropshadow.png)

## <a name="animating"></a>アニメーション化

ビジュアル層で標準では、合成アニメーションを使用して、DropShadow プロパティをアニメーション化することができます。 次の影のぼかしの半径をアニメーション化するのには、上の結び付けたりサンプルからコードを変更します。

```cs
ScalarKeyFrameAnimation blurAnimation = _compositor.CreateScalarKeyFrameAnimation();
blurAnimation.InsertKeyFrame(0.0f, 25.0f);
blurAnimation.InsertKeyFrame(0.7f, 50.0f);
blurAnimation.InsertKeyFrame(1.0f, 25.0f);
blurAnimation.Duration = TimeSpan.FromSeconds(4);
blurAnimation.IterationBehavior = AnimationIterationBehavior.Forever;
shadow.StartAnimation("BlurRadius", blurAnimation);
```

## <a name="shadows-in-xaml"></a>XAML で影

複雑なフレームワーク要素に影を追加する場合は、XAML と合成の影付きの相互運用機能のいくつかの方法があります。

1. 使用して、 [DropShadowPanel](https://github.com/Microsoft/UWPCommunityToolkit/blob/master/Microsoft.Toolkit.Uwp.UI.Controls/DropShadowPanel/DropShadowPanel.Properties.cs) Windows の Community Toolkit で使用できます。 参照してください、 [DropShadowPanel ドキュメント](https://docs.microsoft.com/windows/uwpcommunitytoolkit/controls/DropShadowPanel)それを使用する方法の詳細について。
1. シャドウのホストとして使用して、& XAML 配布資料 Visual に関連付けることにビジュアルを作成します。
1. 使用して、コンポジション サンプル ギャラリーの[SamplesCommon](https://github.com/Microsoft/WindowsUIDevLabs/tree/master/SamplesCommon/SamplesCommon)カスタム CompositionShadow コントロール。 使用状況の次の例を参照してください。

## <a name="performance"></a>パフォーマンス

ビジュアル層は、多くの最適化を効率的かつ使用可能な効果を設定する場所には、影を生成すると、どのようなオプションを設定するによって比較的高価な操作を指定できます。 高レベル '' のコストの影のさまざまな種類を次に示します。 特定の影が高価な場合がありますが、ある可能性があります特定のシナリオで慎重に使用する適切なに注意してください。

シャドウの特性| コスト
------------- | -------------
[四角形の領域切り取り]    | 低
Shadow.Mask      | 高
CompositionDropShadowSourcePolicy.InheritFromVisualContent | 高
静的ぼかしの半径 | 低
ぼかしの半径をアニメーション化 | 高

## <a name="additional-resources"></a>その他のリソース

- [コンポジション DropShadow API](/uwp/api/Windows.UI.Composition.DropShadow)
- [WindowsUIDevLabs GitHub リポジトリ](https://github.com/Microsoft/WindowsUIDevLabs)