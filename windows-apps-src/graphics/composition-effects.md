---
author: scottmill
ms.assetid: 6e9b9ff2-234b-6f63-0975-1afb2d86ba1a
title: "コンポジション効果"
description: "効果 API を使用すると、開発者は UI のレンダリング方法をカスタマイズできます。"
ms.sourcegitcommit: b3d198af0c46ec7a2041a7417bccd56c05af760e
ms.openlocfilehash: 10c3b6d0f56d0e8670cc202ac8d8a3f7538eb5a7

---
# コンポジションの効果

\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132) をご覧ください\]

[**Windows.UI.Composition**](https://msdn.microsoft.com/library/windows/apps/Dn706878) WinRT API により、アニメーション化可能な効果プロパティを持つ画像と UI にリアルタイムの効果を適用できます。 この概要では、コンポジションのビジュアルに効果を適用するために使用できる機能に目を通します。

アプリケーションの効果を記述する開発者に対して [ユニバーサル Windows プラットフォーム (UWP)](https://msdn.microsoft.com/library/windows/apps/dn726767.aspx) との整合性をサポートするには、コンポジション効果で Win2D の IGraphicsEffect インターフェイスを活用し、[Microsoft.Graphics.Canvas.Effects](http://microsoft.github.io/Win2D/html/N_Microsoft_Graphics_Canvas_Effects.md) 名前空間を介して効果記述子を使用します。

ブラシ効果は、一連の既存画像に効果を適用することでアプリケーションの領域をペイントするために使用されます。 Windows 10 のコンポジション効果 API ではスプライト ビジュアルが重視されます。 SpriteVisual を使うと、色、画像、効果の作成で柔軟性と関係性を得られます。 SpriteVisual は、2D の四角形をブラシで埋めることができるコンポジション ビジュアル タイプです。 ビジュアルは四角形の境界を定義し、ブラシは四角形のペイントに使用されるピクセルを定義します。

効果ブラシは、コンテンツが効果グラフの出力に基づくコンポジション ツリー ビジュアルで使用されます。 効果は既存のサーフェスとテクスチャを参照できますが、他のコンポジション ツリーの出力は参照できません。

## 効果機能

-   [効果ライブラリ](./composition-effects.md#effect-library)
-   [チェーン効果](./composition-effects.md#chaining-effects)
-   [アニメーションのサポート](./composition-effects.md#animation-support)
-   [効果プロパティ - 固定とアニメーション化](./composition-effects.md#effect-properties-constant-vs-animated)
-   [独立したプロパティを持つ複数の効果インスタンス](./composition-effects.md#multiple-effect-instances-with-independent-properties)

### 効果ライブラリ

現在、コンポジションでは次の効果がサポートされています。

| 効果               | 説明                                                                                                                                                                                                                |
|----------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 2D アフィン変換  | 画像に 2D アフィン変換マトリックスを適用します。 効果の [サンプル](http://go.microsoft.com/fwlink/?LinkId=785341) では、アルファ マスクのアニメーション化にこの効果が使われています。       |
| 算術コンポジット | 柔軟な方程式を使って 2 つの画像を組み合わせます。 [サンプル](http://go.microsoft.com/fwlink/?LinkId=785341) では、クロスフェード効果の作成に算術コンポジットが使われています。 |
| ブレンド効果         | 2 つの画像を組み合わせるブレンド効果を作成します。 コンポジションでは、Win2D でサポートされている 26 個の [ブレンド モード](http://microsoft.github.io/Win2D/html/T_Microsoft_Graphics_Canvas_Effects_BlendEffectMode.md) のうち 21 個が用意されています。        |
| カラー ソース         | 単色が含まれている画像を生成します。                                                                                                                                                                               |
| コンポジット            | 2 つの画像を組み合わせます。 コンポジションでは、Win2D でサポートされている 13 個の [コンポジット モード](http://microsoft.github.io/Win2D/html/T_Microsoft_Graphics_Canvas_CanvasComposite.md) がすべて用意されています。                                              |
| コントラスト             | 画像のコントラストを増減します。                                                                                                                                                                           |
| 露出             | 画像の露出を増減します。                                                                                                                                                                           |
| グレースケール            | 画像を灰色のモノクロ画像に変換します。                                                                                                                                                                                   |
| ガンマ伝達       | チャネルあたりのガンマ伝達関数を適用することで、画像の色を変更します。                                                                                                                                           |
| 色相回転           | 色相値を回転することで、画像の色を変更します。                                                                                                                                                                   |
| 反転               | 画像の色を反転します。                                                                                                                                                                                            |
| 彩度             | 画像の彩度を変更します。                                                                                                                                                                                         |
| セピア                | 画像をセピア調に変換します。                                                                                                                                                                                          |
| 色温度と濃淡 | 画像の色温度および濃淡を調整します。                                                                                                                                                                           |

 

詳しくは、Win2D の [Microsoft.Graphics.Canvas.Effects](http://microsoft.github.io/Win2D/html/N_Microsoft_Graphics_Canvas_Effects.md) 名前空間を参照してください。 コンポジションでサポートされていない効果は \[NoComposition\] として示されています。

### チェーン効果

効果をチェーンして、アプリケーションの画像で複数の効果を同時に使用できます。 効果グラフは、相互に参照できる複数の効果をサポートできます。 効果を記述するときは、効果に対する入力として効果を追加します。

```cs
IGraphicsEffect graphicsEffect =
new Microsoft.Graphics.Canvas.Effects.ArithmeticCompositeEffect
{
  Source1 = new CompositionEffectSourceParameter("source1"),
  Source2 = new SaturationEffect
  {
    Saturation = 0,
    Source = new CompositionEffectSourceParameter("source2")
  },
  MultiplyAmount = 0,
  Source1Amount = 0.5f,
  Source2Amount = 0.5f,
  Offset = 0    
}
  
```

先ほどの例では、2 つの入力を受け取る算術コンポジット効果について説明しています。 2 番目の入力の彩度効果では、彩度プロパティを 0.5 に設定しています。

### アニメーションのサポート

効果プロパティはアニメーション化をサポートしています。効果のコンパイル時に、効果プロパティをアニメーション化するか、定数として固定するかを指定できます。 アニメーション化可能なプロパティは、「効果名.プロパティ名」という形式の文字列で指定されます。 これらのプロパティは、効果の複数のインスタンスで個別にアニメーション化できます。

### 効果プロパティ - 固定とアニメーション化

効果のコンパイル時に、効果プロパティを動的に設定されるようにするか、定数として固定されるようにするかを指定できます。 動的プロパティは「<effect name>.<property name>」という形式の文字列で指定します。 動的プロパティを特定の値に設定するか、コンポジションのアニメーション システムを使ってアニメーション化できます。

先ほどの効果のコンパイル時、彩度を 0.5 に固定するか、動的に設定される (アニメーション化される) ようにするか、柔軟に選べます。

固定の彩度で効果をコンパイル:

```cs
var effectFactory = _compositor.CreateEffectFactory(graphicsEffect);              
```

動的な彩度で効果をコンパイル:

```cs
var effectFactory = _compositor.CreateEffectFactory(graphicsEffect, new[]{SaturationEffect.Saturation});
_catEffect = effectFactory.CreateBrush();
_catEffect.SetSourceParameter("mySource", surfaceBrush);
_catEffect.Properties.InsertScalar("saturationEffect.Saturation", 0f);
```

その後、先ほどの効果の彩度プロパティを静的な値に設定するか、式または ScalarKeyFrame アニメーションのいずれかを使ってアニメーション化できます。

次のように、効果の彩度プロパティのアニメーション化に使われる ScalarKeyFrame を作成できます。

```cs
ScalarKeyFrameAnimation effectAnimation = _compositor.CreateScalarKeyFrameAnimation();
            effectAnimation.InsertKeyFrame(0f, 0f);
            effectAnimation.InsertKeyFrame(0.50f, 1f);
            effectAnimation.InsertKeyFrame(1.0f, 0f);
            effectAnimation.Duration = TimeSpan.FromMilliseconds(2500);
            effectAnimation.IterationBehavior = AnimationIterationBehavior.Forever;
```

次のように、効果の彩度プロパティのアニメーション化を始めます。

```cs
catEffect.Properties.StartAnimation("saturationEffect.Saturation", effectAnimation);
```

キー フレームを使った効果プロパティのアニメーション化については、[彩度を下げるアニメーション サンプル](http://go.microsoft.com/fwlink/?LinkId=785342) を、効果や式の使用については、[AlphaMask サンプル](http://go.microsoft.com/fwlink/?LinkId=785343) をご覧ください。

### 独立したプロパティを持つ複数の効果インスタンス

効果のコンパイル時にパラメーターが動的であることを指定することにより、パラメーターを効果インスタンスごとに変更できます。 これにより、2 つのビジュアルに同じ効果を使用しても、異なる効果プロパティを使って表示できます。 詳しくは、ColorSource と Blend の [サンプル](http://go.microsoft.com/fwlink/?LinkId=785344) をご覧ください。

## コンポジション効果の概要

このクイック スタート チュートリアルでは、効果のいくつかの基本機能の使用方法を示します。

-   [Visual Studio のインストール](./composition-effects.md#installing-visual-studio)
-   [新しいプロジェクトの作成](./composition-effects.md#creating-a-new-project)
-   [Win2D のインストール](./composition-effects.md#installing-win2d)
-   [コンポジション設定の基本](./composition-effects.md#setting-your-composition-basics)
-   [CompositionSurface ブラシの作成](./composition-effects.md#creating-a-compositionsurface-brush)
-   [効果の作成、コンパイル、および適用](./composition-effects.md#creating,-compiling-and-applying-effects)

### Visual Studio のインストール

-   サポートされている Visual Studio バージョンがインストールされていない場合は、「[Visual Studio ダウンロード](https://www.visualstudio.com/downloads/download-visual-studio-vs.aspx)」ページをご覧ください。

### 新しいプロジェクトの作成

-   [ファイル]、[新規]、[プロジェクト] の順にクリックします。
-   [Visual C#] を選択します。
-   「空のアプリ (Windows ユニバーサル)」を作成します (Visual Studio 2015)。
-   選択したプロジェクト名を入力します。
-   [OK] をクリックします。

### Win2D のインストール

Win2D は Nuget.org パッケージとしてリリースされており、効果を使用する前にインストールする必要があります。

Windows 10 用と Windows 8.1 用の 2 つのパッケージ バージョンがあります。 コンポジション効果の場合、Windows 10 バージョンを使います。

-   [ツール]、[NuGet パッケージ マネージャー]、[ソリューションの NuGet パッケージの管理] の順にクリックして、NuGet パッケージ マネージャーを起動します。
-   「Win2D」を検索し、Windows のターゲット バージョンに適したパッケージを選択します。 Windows.UI.Composition は Windows 10 (8.1 ではない) をサポートするため、Win2D.uwp を選択します。
-   使用許諾契約書に同意します。
-   [閉じる] をクリックします。

次のいくつかの手順では、コンポジション API を使って、すべての彩度を除去する彩度効果をこの猫の画像に適用します。 このモデルでは効果が作成され、画像に適用されます。

![ソース画像](images/composition-cat-source.png)
### コンポジション設定の基本

Windows.UI.Composition コンポジターとルート ContainerVisual の設定方法、およびコア ウィンドウとの関連付け方法の例については、GitHub で [コンポジション ビジュアル ツリーのサンプル](http://go.microsoft.com/fwlink/?LinkId=785345) をご覧ください。

```cs
_compositor = new Compositor();
_root = _compositor.CreateContainerVisual();
_target = _compositor.CreateTargetForCurrentView();
_target.Root = _root;
_imageFactory = new CompositionImageFactory(_compositor)
Desaturate();
```

### CompositionSurface ブラシの作成

```cs
CompositionSurfaceBrush surfaceBrush = _compositor.CreateSurfaceBrush();
LoadImage(surfaceBrush); 
```

### 効果の作成、コンパイル、および適用

1.) グラフィックス効果を作成する
```cs
var graphicsEffect = new SaturationEffect
{
  Saturation = 0.0f,
  Source = new CompositionEffectSourceParameter("mySource")
};
```

2.) 効果をコンパイルし、効果ブラシを作成する
```cs
var effectFactory = _compositor.CreateEffectFactory(graphicsEffect);

var catEffect = effectFactory.CreateBrush();
catEffect.SetSourceParameter("mySource", surfaceBrush);
```

3.) コンポジション ツリーに SpriteVIsual を作成し、効果を適用する
```cs
var catVisual = _compositor.CreateSpriteVisual();
  catVisual.Brush = catEffect;
  catVisual.Size = new Vector2(219, 300);
  _root.Children.InsertAtBottom(catVisual);
}
```

4.) 読み込む画像ソースを作成する。
```cs
CompositionImage imageSource = _imageFactory.CreateImageFromUri(new Uri("ms-appx:///Assets/cat.png"));
CompositionImageLoadResult result = await imageSource.CompleteLoadAsync();
if (result.Status == CompositionImageLoadStatus.Success)
```

5.) SpriteVisual のサーフェスのサイズとブラシ
```cs
brush.Surface = imageSource.Surface;
```

6.) アプリを実行する - 結果は彩度を下げた猫になるはずです。

![彩度を下げた画像](images/composition-cat-desaturated.png)
## 詳細情報

-   [Microsoft - コンポジション GitHub](https://github.com/Microsoft/composition)
-   [**Windows.UI.Composition**](https://msdn.microsoft.com/library/windows/apps/Dn706878)
-   [Twitter の Windows Composition チーム](https://twitter.com/wincomposition)
-   [コンポジションの概要](https://blogs.windows.com/buildingapps/2015/12/08/awaken-your-creativity-with-the-new-windows-ui-composition/)
-   [ビジュアル ツリーの基本](composition-visual-tree.md)
-   [コンポジションのブラシ](composition-brushes.md)
-   [アニメーションの概要](composition-animation.md)
-   [BeginDraw と EndDraw によるコンポジションでの DirectX と Direct2D のネイティブ相互運用](composition-native-interop.md)

 

 







<!--HONumber=Jun16_HO4-->


