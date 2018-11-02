---
author: daneuber
title: コンポジションのシャドウ
description: シャドウ Api では、UI コンテンツを動的カスタマイズ可能なシャドウを追加することができます。
ms.author: jimwalk
ms.date: 07/16/2018
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 2c2f42235e6a74747059723841d3082037b558c7
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/02/2018
ms.locfileid: "5938583"
---
# <a name="shadows-in-windows-ui"></a>Windows UI でのシャドウ

[DropShadow](/uwp/api/Windows.UI.Composition.DropShadow)クラスは、 [SpriteVisual](/uwp/api/windows.ui.composition.spritevisual)または[LayerVisual](/uwp/api/windows.ui.composition.layervisual) (ビジュアルのサブツリー) に適用可能な構成可能なシャドウを作成する手段を提供します。 ビジュアル レイヤー内のオブジェクトの慣例では、Compositionanimation を使用して、DropShadow のすべてのプロパティをアニメーション化することができます。

## <a name="basic-drop-shadow"></a>基本的なドロップ シャドウ

基本的なシャドウを作成するには、新しい DropShadow を作成し、ビジュアルに関連付けることだけです。 影が既定では四角形です。 シャドウの見た目や操作感を調整する標準的な一連のプロパティを利用できます。

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

![四角形のビジュアルで基本的な DropShadow](images/rectangular-dropshadow.png)

## <a name="shaping-the-shadow"></a>シャドウを整える

これには、DropShadow の形状を定義するいくつかの方法があります。

- DropShadow 図形を既定では **、既定の使用**- は CompositionDropShadowSourcePolicy の '既定' モードによって定義されます。 SpriteVisual が既定の四角形マスクが提供されている場合を除き、します。 LayerVisual、既定ではビジュアル オブジェクトのブラシのアルファ マスクを継承します。
- **マスクを設定**、シャドウの不透明度マスクを定義する[マスク](/uwp/api/windows.ui.composition.dropshadow.mask)プロパティを設定することがあります。
- **継承マスクを使うことを指定する**– では、 [CompositionDropShadowSourcePolicy](/uwp/api/windows.ui.composition.compositiondropshadowsourcepolicy)を使用する[SourcePolicy](/uwp/api/windows.ui.composition.dropshadow.sourcepolicy)プロパティを設定します。 ビジュアル オブジェクトのブラシのアルファから生成されたマスクを使用する InheritFromVisualContent します。

## <a name="masking-to-match-your-content"></a>コンテンツに合わせてマスク

ビジュアル オブジェクトのコンテンツ、シャドウ マスク プロパティのビジュアル オブジェクトのブラシを使用するか、自動的にコンテンツをマスクを継承するシャドウを設定に一致するように、シャドウを実行する場合にします。 LayerVisual を使っている場合、シャドウは既定では、マスクを継承します。

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

![マスク影付き接続されている web 画像](images/ms-brand-web-dropshadow.png)

## <a name="using-an-alternative-mask"></a>代替のマスクを使用します。

場合によっては、図形、シャドウのビジュアル オブジェクトのコンテンツをそれと一致しないようにすることがあります。 この効果を実現するには、ブラシを使用して、アルファ マスク プロパティを明示的に設定する必要があります。

次の例では、2 つのサーフェスに視覚的なコンテンツ用とシャドウ マスク用に 1 つを読み込みます。

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

![接続されている web 画像の円をマスク ドロップ シャドウ](images/ms-brand-web-masked-dropshadow.png)

## <a name="animating"></a>アニメーション化

標準のビジュアル レイヤーは、コンポジション アニメーションを使用して、DropShadow プロパティをアニメーション化することができます。 以下には、上記の影のぼかし半径をアニメーション化する散点サンプルからコードを変更します。

```cs
ScalarKeyFrameAnimation blurAnimation = _compositor.CreateScalarKeyFrameAnimation();
blurAnimation.InsertKeyFrame(0.0f, 25.0f);
blurAnimation.InsertKeyFrame(0.7f, 50.0f);
blurAnimation.InsertKeyFrame(1.0f, 25.0f);
blurAnimation.Duration = TimeSpan.FromSeconds(4);
blurAnimation.IterationBehavior = AnimationIterationBehavior.Forever;
shadow.StartAnimation("BlurRadius", blurAnimation);
```

## <a name="shadows-in-xaml"></a>XAML でのシャドウ

複雑なフレームワーク要素にシャドウを追加する場合は、XAML とコンポジションのシャドウとの相互運用に、いくつかの方法があります。

1. Windows コミュニティ ツールキットで利用可能な[DropShadowPanel](https://github.com/Microsoft/UWPCommunityToolkit/blob/master/Microsoft.Toolkit.Uwp.UI.Controls/DropShadowPanel/DropShadowPanel.Properties.cs)を使用します。 その使用方法の詳細については、 [DropShadowPanel ドキュメント](https://docs.microsoft.com/windows/uwpcommunitytoolkit/controls/DropShadowPanel)を参照してください。
1. シャドウのホストとして使用すると、XAML ハンドアウト Visual に関連付けることにビジュアルを作成します。
1. コンポジションのサンプル ギャラリーの[SamplesCommon](https://github.com/Microsoft/WindowsUIDevLabs/tree/master/SamplesCommon/SamplesCommon)カスタム CompositionShadow コントロールを使います。 ここでの使用例を参照してください。

## <a name="performance"></a>パフォーマンス

ビジュアル レイヤーは、多くの最適化を効率的で使用可能な効果を作成するには、シャドウを生成するいるとする比較的安価処理にによっては、どのようなオプションを設定することができます。 高レベル '' のコストさまざまな種類のシャドウを以下に示します。 ある特定のシャドウのコストがかかる場合がありますが、可能性があります特定のシナリオで慎重に使用する適切な注意してください。

シャドウ特性| 費用
------------- | -------------
[四角形の領域切り取り]    | 低
Shadow.Mask      | 高
CompositionDropShadowSourcePolicy.InheritFromVisualContent | 高
静的なぼかし Radius | 低
Radius のぼかしをアニメーション化 | 高

## <a name="additional-resources"></a>その他のリソース

- [コンポジション DropShadow API](/uwp/api/Windows.UI.Composition.DropShadow)
- [WindowsUIDevLabs GitHub リポジトリにあります。](https://github.com/Microsoft/WindowsUIDevLabs)