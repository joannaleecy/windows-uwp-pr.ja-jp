---
author: Jwmsft
ms.assetid: 02141F86-355E-4046-86EA-2A89D615B7DB
title: ブラシの使用
description: Brush オブジェクトは、コントロールの領域、テキスト、図形の内側または輪郭を塗りつぶして、その対象領域を UI 上で視覚的に認識できるようにするために使われます。
ms.author: jimwalk
ms.date: 07/13/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 0473ee984461bf46be4ebf866a564f0d51e0cfc5
ms.sourcegitcommit: e4f3e1b2d08a02b9920e78e802234e5b674e7223
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/26/2018
ms.locfileid: "4207514"
---
# <a name="using-brushes-to-paint-backgrounds-foregrounds-and-outlines"></a>ブラシを使用して背景、前景、輪郭を描画する

[**Brush**](/uwp/api/Windows.UI.Xaml.Media.Brush) オブジェクトを使用して、コントロールの一部、XAML 図形、テキストの内側または輪郭を塗りつぶすと、対象オブジェクトが UI 上で見えやすくなります。 ここでは、利用可能なブラシとそれらの使い方について説明します。

> **重要な API**: [Brush クラス](/uwp/api/Windows.UI.Xaml.Media.Brush)

## <a name="introduction-to-brushes"></a>ブラシ入門

[**Shape**](/uwp/api/Windows.UI.Xaml.Shapes.Shape) や [**Control**](https://msdn.microsoft.com/library/windows/apps/BR209390) の領域など、アプリ キャンバスに表示されるオブジェクトを塗りつぶすには、[**Brush**](/uwp/api/Windows.UI.Xaml.Media.Brush) を使います。 たとえば、**Shape** や [**Background**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.control.background.aspx) の [**Fill**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.shapes.shape.fill.aspx) プロパティ、または **Control** の [**Foreground**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.control.foreground.aspx) プロパティを **Brush** 値に設定すると、対象となる UI 要素をどのように塗りつぶすか、またその要素を UI でどのようにレンダリングするかが、**Brush** によって決定されます。 

ブラシには、次のような種類があります。 
-   [**AcrylicBrush**](/uwp/api/windows.ui.xaml.media.acrylicbrush)
-   [**SolidColorBrush**](https://msdn.microsoft.com/library/windows/apps/BR242962)
-   [**LinearGradientBrush**](https://msdn.microsoft.com/library/windows/apps/BR210108) 
-   [**ImageBrush**](https://msdn.microsoft.com/library/windows/apps/BR210101)
-   [**WebViewBrush**](https://msdn.microsoft.com/library/windows/apps/BR227703)
-   [**XamlCompositionBrushBase**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.media.xamlcompositionbrushbase)

## <a name="solid-color-brushes"></a>単色ブラシ

[**SolidColorBrush**](https://msdn.microsoft.com/library/windows/apps/BR242962) は、赤や青などの 1 つの [**Color**](https://msdn.microsoft.com/library/windows/apps/Hh673723) で領域を塗りつぶします。 これは、最も基本的なブラシです。 XAML で **SolidColorBrush** とその色 (単色) を定義するには、定義済みの色の名前、16 進数の色値、およびプロパティ要素構文という 3 つの方法があります。

### <a name="predefined-color-names"></a>定義済みの色の名前

[**Yellow**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.colors.yellow.aspx)、[**Magenta**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.colors.magenta.aspx) など、定義済みの色の名前を使うことができます。 名前付きの色は 256 個存在します。 XAML パーサーは、色の名前を、正しいカラー チャネルを持つ [**Color**](https://msdn.microsoft.com/library/windows/apps/Hh673723) 構造体に変換します。 256 個の名前付きの色は、カスケード スタイル シート レベル 3 (CSS3) 仕様の *X11* の色名が基になっているため、過去に Web 開発や Web デザインの経験があれば、この一連の色について既にご存じの方も多いと思います。

[**Rectangle**](/uwp/api/Windows.UI.Xaml.Shapes.Rectangle) の [**Fill**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.shapes.shape.fill.aspx) プロパティを定義済みの色 [**Red**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.colors.red.aspx) に設定する例を次に示します。

```xml
<Rectangle Width="100" Height="100" Fill="Red" />
```

次の画像は、[**Rectangle**](/uwp/api/Windows.UI.Xaml.Shapes.Rectangle) に適用されている [**SolidColorBrush**](https://msdn.microsoft.com/library/windows/apps/BR242962) を示しています。

![レンダリングされた SolidColorBrush。](images/brushes-solidcolorbrush.jpg)

XAML ではなくコードを使って [**SolidColorBrush**](https://msdn.microsoft.com/library/windows/apps/BR242962) を定義する場合、名前付きの色はそれぞれ、[**Colors**](https://msdn.microsoft.com/library/windows/apps/windows.ui.colors) クラスの静的プロパティの値として利用できます。 たとえば、名前付きの色 "Orchid" を表す、**SolidColorBrush** の [**Color**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.media.solidcolorbrush.color.aspx) 値を宣言するには、**Color** 値を静的な [**Colors.Orchid**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.colors.orchid.aspx) 値に設定します。

### <a name="hexadecimal-color-values"></a>16 進数の色値

16 進数形式の文字列を使い、[**SolidColorBrush**](https://msdn.microsoft.com/library/windows/apps/BR242962) に対して、8 ビットのアルファ チャネルを備えた厳密な 24 ビットの色値を宣言できます。 16 進数文字列は成分ごとに、0 ～ F の範囲の 2 文字で定義され、各成分の値がアルファ チャネル (不透明度)、赤色チャネル、緑色チャネル、青色チャネルの順に並びます (**ARGB**)。 たとえば、16 進数値 "\#FFFF0000" は、完全に不透明な赤色 (アルファ = "FF"、赤 = "FF"、緑 = "00"、青 = "00") を定義します。

以下の XAML では、名前付きの色 [**Colors.Red**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.colors.red.aspx) とまったく同じ結果となるように、[**Rectangle**](/uwp/api/Windows.UI.Xaml.Shapes.Rectangle) の [**Fill**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.shapes.shape.fill.aspx) プロパティを 16 進数値 "\#FFFF0000" に設定しています。

```xml
<StackPanel>
  <Rectangle Width="100" Height="100" Fill="#FFFF0000" />
</StackPanel>
```

### <a name="span-idpropertyelementsyntaxspanspan-idpropertyelementsyntaxspanspan-idpropertyelementsyntaxspanproperty-element-syntax"></a><span id="Property_element_syntax__"></span><span id="property_element_syntax__"></span><span id="PROPERTY_ELEMENT_SYNTAX__"></span>プロパティ要素構文

プロパティ要素構文を使って [**SolidColorBrush**](https://msdn.microsoft.com/library/windows/apps/BR242962) を定義できます。 この構文は、前の方法よりもやや複雑ですが、[**Opacity**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.media.brush.opacity.aspx) などのプロパティ値を要素に対して追加で指定できます。 プロパティ要素構文を含む XAML 構文について詳しくは、「[XAML の概要](https://msdn.microsoft.com/library/windows/apps/Mt185595)」と「[XAML 構文のガイド](https://msdn.microsoft.com/library/windows/apps/Mt185596)」をご覧ください。

これまでの例では、構文に "SolidColorBrush" という文字列が一切出現していません。 XAML 言語は、一般的なケースについては UI を簡潔に定義できるよう、意識的に省略表現が採用されており、その一環として、ブラシも暗黙的かつ自動的に作成されます。 次の例では、[**Rectangle**](/uwp/api/Windows.UI.Xaml.Shapes.Rectangle) を作成し、[**Rectangle.Fill**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.shapes.shape.fill.aspx) プロパティの要素値として [**SolidColorBrush**](https://msdn.microsoft.com/library/windows/apps/BR242962) を明示的に作成します。 **SolidColorBrush** の [**Color**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.media.solidcolorbrush.color.aspx) は [**Blue**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.colors.blue.aspx) に設定され、[**Opacity**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.media.brush.opacity.aspx) は 0.5 に設定されます。

```xml
<Rectangle Width="200" Height="150">
    <Rectangle.Fill>
        <SolidColorBrush Color="Blue" Opacity="0.5" />
    </Rectangle.Fill>
</Rectangle>
```

## <a name="span-idlineargradientbrushesspanspan-idlineargradientbrushesspanspan-idlineargradientbrushesspanlinear-gradient-brushes"></a><span id="Linear_gradient_brushes_"></span><span id="linear_gradient_brushes_"></span><span id="LINEAR_GRADIENT_BRUSHES_"></span>線状グラデーション ブラシ

[**LinearGradientBrush**](https://msdn.microsoft.com/library/windows/apps/BR210108) は、直線に沿って定義されたグラデーションを使って、領域を塗りつぶします。 この直線は*グラデーション軸*と呼ばれます。 [**GradientStop**](https://msdn.microsoft.com/library/windows/apps/BR210078) オブジェクトを使って、グラデーションの色とグラデーション軸に沿った位置を指定します。 既定では、ブラシで塗りつぶす領域の左上隅から右下隅に向かってグラデーション軸がとられているため、明暗は斜め方向に適用されます。

[**GradientStop**](https://msdn.microsoft.com/library/windows/apps/BR210078) は、グラデーション ブラシの基本的な構成要素です。 グラデーション境界は、塗りつぶす領域に適用されたブラシの、グラデーション軸上の [**Offset**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.media.gradientstop.offset.aspx) 位置における [**Color**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.media.gradientstop.color.aspx) を指定します。

グラデーション境界の [**Color**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.media.gradientstop.color.aspx) プロパティは、グラデーション境界の色を指定します。 定義済みの色の名前を使うか、または 16 進数の **ARGB** 値を指定して、色を設定できます。

[**GradientStop**](https://msdn.microsoft.com/library/windows/apps/BR210078) の [**Offset**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.media.gradientstop.offset.aspx) プロパティは、グラデーション軸に沿った各 **GradientStop** の位置を指定します。 **Offset** は、0 から 1 までの範囲の**倍精度浮動小数点数**です。 **Offset** が 0 のとき、**GradientStop** は、グラデーション軸の開始位置、つまり、[**StartPoint**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.media.lineargradientbrush.startpoint.aspx) 付近に配置されます。 **Offset** が 1 のとき、**GradientStop** は [**EndPoint**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.media.lineargradientbrush.endpoint.aspx) に配置されます。 実用上、[**LinearGradientBrush**](https://msdn.microsoft.com/library/windows/apps/BR210108) には少なくとも 2 つの **GradientStop** 値が必要であり、2 つの **GradientStop** は、それぞれ異なる [**Color**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.media.gradientstop.color.aspx) と、0 ～ 1 の範囲内の異なる **Offset** 値を持つ必要があります。

次の例では、4 色の線状グラデーションを作成し、それを使って [**Rectangle**](/uwp/api/Windows.UI.Xaml.Shapes.Rectangle) を塗りつぶします。

```xml
<!-- This rectangle is painted with a diagonal linear gradient. -->
<Rectangle Width="200" Height="100">
    <Rectangle.Fill>
        <LinearGradientBrush StartPoint="0,0" EndPoint="1,1">
            <GradientStop Color="Yellow" Offset="0.0" x:Name="GradientStop1"/>
            <GradientStop Color="Red" Offset="0.25" x:Name="GradientStop2"/>
            <GradientStop Color="Blue" Offset="0.75" x:Name="GradientStop3"/>
            <GradientStop Color="LimeGreen" Offset="1.0" x:Name="GradientStop4"/>
        </LinearGradientBrush>
    </Rectangle.Fill>
</Rectangle>
```

グラデーション境界間の各点の色は、境界となる 2 つのグラデーション境界によって指定された色の組み合わせとして、直線的に補間されます。 この例の各グラデーション境界を次の図に示しています。 グラデーション境界の位置が円で示され、グラデーション軸が破線で示されています。

![グラデーション境界](images/linear-gradients-stops.png) グラデーション境界が配置される直線は、[**StartPoint**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.media.lineargradientbrush.startpoint.aspx) プロパティと [**EndPoint**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.media.lineargradientbrush.endpoint.aspx) プロパティを、既定値である `(0,0)` と `(1,1)` 以外の値に設定することで変更できます。 **StartPoint** と **EndPoint** の座標値を変更すると、水平方向や垂直方向のグラデーションを作成したり、グラデーション方向を反転したりできるほか、塗りつぶす領域全体よりも小さくなるようにグラデーションの適用範囲を狭めることができます。 グラデーションの領域を狭めるには、**StartPoint** または **EndPoint** (あるいはその両方) の値を 0 ～ 1 の範囲で変更します。 たとえば、フェード効果がブラシの左半分で完結し、右半分は、直近の [**GradientStop**](https://msdn.microsoft.com/library/windows/apps/BR210078) に基づく単色であるような水平方向のグラデーションが必要な場合、**StartPoint** を `(0,0)` に、**EndPoint** を `(0.5,0)` に設定します。

### <a name="span-idusetoolstomakegradientsspanspan-idusetoolstomakegradientsspanspan-idusetoolstomakegradientsspanuse-tools-to-make-gradients"></a><span id="Use_tools_to_make_gradients"></span><span id="use_tools_to_make_gradients"></span><span id="USE_TOOLS_TO_MAKE_GRADIENTS"></span>ツールによるグラデーションの作成

ここまで、線状グラデーションのしくみについて説明しました。次に、Visual Studio または Blend を使うと、これらのグラデーションの作成が簡単になります。 グラデーションを作成するには、デザイン サーフェイスまたは XAML ビューで、グラデーションを適用するオブジェクトを選択します。 **[ブラシ]** を展開し、**[線状グラデーション]** タブをクリックします (次のスクリーンショットをご覧ください)。

![Visual Studio による線状グラデーションの作成。](images/tool-gradient-brush-1.png)

ここで、グラデーション境界の色を変更したり、下のバーを使って位置をずらしたりできます。 また、バーをクリックして新しいグラデーション境界を追加したり、グラデーション境界をバーの外側にドラッグして削除したりもできます (次のスクリーンショットをご覧ください)。

![プロパティ ウィンドウの下にあるバーでグラデーション境界を制御。](images/tool-gradient-brush-2.png)

## <a name="span-idimagebrushesspanspan-idimagebrushesspanspan-idimagebrushesspanimage-brushes"></a><span id="Image_brushes"></span><span id="image_brushes"></span><span id="IMAGE_BRUSHES"></span>イメージ ブラシ

[**ImageBrush**](https://msdn.microsoft.com/library/windows/apps/BR210101) は、イメージ ファイル ソースから取得した画像で領域を塗りつぶします。 [**ImageSource**](https://msdn.microsoft.com/library/windows/apps/BR210107) プロパティに、読み込む画像のパスを設定します。 通常、イメージ ソースは、アプリのリソースに含まれる **Content** 項目から取得します。

[**ImageBrush**](https://msdn.microsoft.com/library/windows/apps/BR210101) では、既定で、描画する領域が完全に埋まるように画像が拡大されます。描画する領域と画像の縦横比が異なる場合は、画像がゆがむ可能性があります。 この動作を変更するには、[**Stretch**](https://msdn.microsoft.com/library/windows/apps/BR242975) プロパティを既定値の **Fill** から **None**、**Uniform**、または **UniformToFill** に変更します。

次の例では、[**ImageBrush**](https://msdn.microsoft.com/library/windows/apps/BR210101) を作成し、[**ImageSource**](https://msdn.microsoft.com/library/windows/apps/BR210107) を licorice.jpg という画像に設定します。この画像は、アプリのリソースとして取り込んでおく必要があります。 この **ImageBrush** を使って、[**Ellipse**](/uwp/api/Windows.UI.Xaml.Shapes.Ellipse) で定義される領域を塗りつぶします。

```xml
<Ellipse Height="200" Width="300">
   <Ellipse.Fill>
     <ImageBrush ImageSource="licorice.jpg" />
   </Ellipse.Fill>
</Ellipse>
```

この [**ImageBrush**](https://msdn.microsoft.com/library/windows/apps/BR210101) をレンダリングすると、次のようになります。

![レンダリングされた ImageBrush。](images/brushes-imagebrush.jpg)

[**ImageBrush**](https://msdn.microsoft.com/library/windows/apps/BR210101) と [**Image**](https://msdn.microsoft.com/library/windows/apps/BR242752) は、どちらも Uniform Resource Identifier (URI) でイメージ ソース ファイルを参照します。また、イメージ ソース ファイルに使うことができる画像形式には、さまざまなものがあります。 これらのイメージ ソース ファイルは、URI として指定されます。 イメージ ソースの指定、使用できる画像形式、アプリへのパッケージ化について詳しくは、「[Image と ImageBrush](https://msdn.microsoft.com/library/windows/apps/Mt280382)」をご覧ください。

## <a name="brushes-and-text"></a>ブラシとテキスト

ブラシを使って、テキスト要素にレンダリング特性を適用することもできます。 たとえば、[**TextBlock**](https://msdn.microsoft.com/library/windows/apps/BR209652) の [**Foreground**](https://msdn.microsoft.com/library/windows/apps/BR209665) プロパティに対して、[**Brush**](/uwp/api/Windows.UI.Xaml.Media.Brush) を指定できます。 テキストには、ここで説明したすべてのブラシを適用できます。 ただし、テキストにブラシを適用するときは注意が必要です。背景に溶け込むようなブラシやテキスト文字の輪郭に合っていないブラシを使うと、テキストが読みにくくなる場合があります。 テキスト要素の装飾性を高めることが重要でなければ、ほとんどの場合は [**SolidColorBrush**](https://msdn.microsoft.com/library/windows/apps/BR242962) を使うと読みやすくなります。

単色を使う場合でも、テキストには、そのレイアウト コンテナーの背景色に対して十分なコントラストを持つ色を選ぶ必要があります。 テキストの前景とテキスト コンテナーの背景とのコントラスト レベルは、アクセシビリティにかかわる考慮事項です。

## <a name="webviewbrush"></a>WebViewBrush

[**WebViewBrush**](https://msdn.microsoft.com/library/windows/apps/BR227703) は、[**WebView**](https://msdn.microsoft.com/library/windows/apps/BR227702) コントロールに通常表示されるコンテンツにアクセスできる特殊なブラシです。 四角形の **WebView** コントロール領域にコンテンツをレンダリングする代わりに、**WebViewBrush** は、レンダリング サーフェスに [**Brush**](/uwp/api/Windows.UI.Xaml.Media.Brush) タイプのプロパティを持つ別の要素にコンテンツを描画します。 **WebViewBrush** は、必ずしもすべての用途に適したブラシではありませんが、**WebView** の切り替えで効果的に使うことができます。 詳しくは、「[**WebViewBrush**](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.Controls.WebViewBrush)」をご覧ください。

## <a name="xamlcompositionbrushbase"></a>XamlCompositionBrushBase

[**XamlCompositionBrushBase**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.media.xamlcompositionbrushbase) は、[**CompositionBrush**](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Composition.CompositionBrush) を使って XAML UI 要素を描画する、カスタム ブラシを作成するために使用する基底クラスです。

これにより、Windows.UI.Xaml と Windows.UI.Composition レイヤー間の「ドロップ ダウン」相互運用を行えます。詳しくは、「[**ビジュアル レイヤーの概要**](/windows/uwp/composition/visual-layer)」をご覧ください。 

カスタム ブラシを作成するには、XamlCompositionBrushBase から継承する新しいクラスを作成し、必要なメソッドを実装します。

これにより、[**CompositionEffectBrush**](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Composition.CompositionEffectBrush) を使って、[**効果**](/windows/uwp/composition/composition-effects)を XAML UIElements に適用することができます。たとえば、[**XamlLight**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.media.xamllight) に照射される XAML UIElement の反射プロパティを制御する**GaussianBlurEffect** や [**SceneLightingEffect**](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Composition.Effects.SceneLightingEffect) などの効果を適用できます。

コードの例については、[**XamlCompositionBrushBase**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.media.xamlcompositionbrushbase) のリファレンス ページをご覧ください。

## <a name="brushes-as-xaml-resources"></a>XAML リソースとしてのブラシ

すべてのブラシは、XAML リソース ディクショナリに、キーを持つ XAML リソースとして宣言できます。 これにより、UI 内の複数の要素に適用する同じブラシの値を簡単に複製することができます。 このブラシの値を共有し、XAML の [{StaticResource}](https://msdn.microsoft.com/library/windows/apps/Mt185588) でブラシ リソースを参照するときに適用することができます。 たとえば、共有されたブラシを参照する XAML コントロール テンプレートがあるとき、そのコントロール テンプレート自体を、キーを持つ XAML リソースとして利用することができます。

## <a name="brushes-in-code"></a>コードを使ったブラシ

コードを使ってブラシを定義するよりも、XAML を使ってブラシを指定する方が一般的です。 これは、ブラシが通常は XAML リソースとして定義されるためであり、ブラシの値がデザイン ツールの出力結果である場合や、XAML UI 定義の一部としての出力結果である場合が多いためです。 ただし、コードを使ってブラシを定義する必要がある場合は、すべての種類の [**Brush**](/uwp/api/Windows.UI.Xaml.Media.Brush) をコードのインスタンス化に使うことができます。

コードを使って [**SolidColorBrush**](https://msdn.microsoft.com/library/windows/apps/BR242962) を作成するには、[**Color**](https://msdn.microsoft.com/library/windows/apps/Hh673723) パラメーターを受け取るコンストラクターを使います。 次のように、[**Colors**](https://msdn.microsoft.com/library/windows/apps/windows.ui.colors) クラスの静的プロパティである値を渡します。

```cs
SolidColorBrush blueBrush = new SolidColorBrush(Windows.UI.Colors.Blue);
```

```vb
Dim blueBrush as SolidColorBrush = New SolidColorBrush(Windows.UI.Colors.Blue)
```

```cppwinrt
Windows::UI::Xaml::Media::SolidColorBrush blueBrush{ Windows::UI::Colors::Blue() };
```

```cpp
blueBrush = ref new SolidColorBrush(Windows::UI::Colors::Blue);
```

[**WebViewBrush**](https://msdn.microsoft.com/library/windows/apps/BR227703) と [**ImageBrush**](https://msdn.microsoft.com/library/windows/apps/BR210101) を UI プロパティに使う場合、その前に既定のコンストラクターを使って他の API を呼び出してください。

-   コードを使って [
              **ImageBrush**](https://msdn.microsoft.com/library/windows/apps/BR210101) を定義する場合、[**ImageSource**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.imagebrush.imagesourceproperty.aspx) では [**BitmapImage**](https://msdn.microsoft.com/library/windows/apps/BR243235) (URI ではない) が必要です。 ソースがストリームである場合は、[**SetSourceAsync**](https://msdn.microsoft.com/library/windows/apps/JJ191522) メソッドを使って値を初期化します。 ソースが、**ms-appx**  スキームまたは **ms-resource** スキームを使うアプリ内のコンテンツを含む URI である場合は、URI を受け取る [**BitmapImage**](https://msdn.microsoft.com/library/windows/apps/br243238.aspx) コンストラクターを使います。 イメージ ソースが使えるようになるまで代替コンテンツを表示することが必要となる場合など、イメージ ソースの取得やデコードについてタイミングの問題がある場合は、[**ImageOpened**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.media.imagebrush.imageopened.aspx) イベントを処理することも検討してください。
-   [**WebViewBrush**](https://msdn.microsoft.com/library/windows/apps/BR227703) については、[**SourceName**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webviewbrush.sourcename.aspx) プロパティを最近リセットした場合、または [**WebView**](https://msdn.microsoft.com/library/windows/apps/BR227702) のコンテンツをコードを使って変更した場合に、[**Redraw**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webviewbrush.redraw.aspx) を呼び出す必要があります。

コードの例については、[**WebViewBrush**](https://msdn.microsoft.com/library/windows/apps/BR227703)、[**ImageBrush**](https://msdn.microsoft.com/library/windows/apps/BR210101)、[**XamlCompositionBrushBase**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.media.xamlcompositionbrushbase) のリファレンス ページをご覧ください。
 

 




