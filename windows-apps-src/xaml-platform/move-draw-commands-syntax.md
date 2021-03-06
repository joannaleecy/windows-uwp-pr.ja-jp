---
description: ここでは、パスの形状を XAML 属性値として指定するために使うことのできる、移動と描画のコマンド (ミニ言語) について説明します。
title: 移動と描画のコマンド構文
ms.assetid: 7772BC3E-A631-46FF-9940-3DD5B9D0E0D9
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 604ad25bb65486b3b388a9a03d7503b0c1ce9c03
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57632527"
---
# <a name="move-and-draw-commands-syntax"></a>移動と描画のコマンド構文


ここでは、パスの形状を XAML 属性値として指定するために使うことのできる、移動と描画のコマンド (ミニ言語) について説明します。 移動と描画のコマンドは、ベクター グラフィックや図形の出力に対応するさまざまなデザイン ツールやグラフィックス ツールで、シリアル化形式や交換形式として使われます。

## <a name="properties-that-use-move-and-draw-command-strings"></a>移動と描画のコマンド文字列を使うプロパティ

移動と描画のコマンド構文は、XAML の内部型コンバーターによってサポートされます。コンバーターはコマンドを解析し、実行時にグラフィックス表現を生成します。 この表現は、基本的には完成したベクター セットであり、そのまま表示することができます。 ただし、ベクター自体では表現の詳細までは定義されないため、他の値を要素に設定する必要もあります。 [  **Path**](/uwp/api/Windows.UI.Xaml.Shapes.Path) オブジェクトについては、[**Fill**](/uwp/api/Windows.UI.Xaml.Shapes.Shape.Fill) や [**Stroke**](https://msdn.microsoft.com/library/windows/apps/br243383) などのプロパティに値を設定してから、その **Path** を何らかの方法でビジュアル ツリーに関連付ける必要もあります。 [  **PathIcon**](https://msdn.microsoft.com/library/windows/apps/dn252722) オブジェクトでは、[**Foreground**](https://msdn.microsoft.com/library/windows/apps/dn251974) プロパティを設定します。

移動を表す文字列を使用して、描画コマンドを Windows ランタイムには、2 つのプロパティがあります。[**Path.Data** ](https://msdn.microsoft.com/library/windows/apps/br243356)と[ **PathIcon.Data**](https://msdn.microsoft.com/library/windows/apps/dn252723)します。 通常、これらのプロパティに移動と描画のコマンドを指定するときは、その要素に必要な他の属性と共に、コマンドを XAML 属性値として設定します。 単純な例としては次のようになります。

```xml
<Path x:Name="Arrow" Fill="White" Height="11" Width="9.67"
  Data="M4.12,0 L9.67,5.47 L4.12,10.94 L0,10.88 L5.56,5.47 L0,0.06" />
```

[**PathGeometry.Figures** ](https://msdn.microsoft.com/library/windows/apps/br210169)も使用して、移動および描画コマンドことができます。 移動と描画のコマンドを使う [**PathGeometry**](https://msdn.microsoft.com/library/windows/apps/br210168) オブジェクトは、[**GeometryGroup**](https://msdn.microsoft.com/library/windows/apps/br210057) オブジェクトに含まれる他の [**Geometry**](/uwp/api/Windows.UI.Xaml.Media.Geometry) 型と結合して、[**Path.Data**](https://msdn.microsoft.com/library/windows/apps/br243356) の値として使うこともできます。 ただし、この使い方は、属性定義のデータで移動と描画のコマンドを使う方法ほど一般的ではありません。

## <a name="using-move-and-draw-commands-versus-using-a-pathgeometry"></a>移動と描画のコマンドの使用と **PathGeometry** の使用

Windows ランタイム XAML では、移動と描画のコマンドにより、単一の [**PathFigure**](https://msdn.microsoft.com/library/windows/apps/br210143) オブジェクトと [**Figures**](https://msdn.microsoft.com/library/windows/apps/br210169) プロパティの値を持つ [**PathGeometry**](https://msdn.microsoft.com/library/windows/apps/br210168) が生成されます。 各描画コマンドは、その単一の **PathFigure** の [**Segments**](https://msdn.microsoft.com/library/windows/apps/br210164) コレクションに [**PathSegment**](https://msdn.microsoft.com/library/windows/apps/br210174) 派生クラスを生成します。移動コマンドは [**StartPoint**](https://msdn.microsoft.com/library/windows/apps/br210166) を変更します。終了コマンドがある場合は、[**IsClosed**](https://msdn.microsoft.com/library/windows/apps/br210159) が **true** に設定されます。 実行時に **Data** の値を調べると、この構造をオブジェクト モデルとしてたどることができます。

## <a name="the-basic-syntax"></a>基本構文

移動と描画のコマンド構文を簡単にまとめると、次のようになります。

1.  まず、オプションの塗りつぶしルールを指定します。 通常、これを指定するのは、既定の **EvenOdd** では望ましくない場合だけです  (**EvenOdd** については後ほど詳しく説明します)。
2.  移動コマンドを 1 つだけ指定します。
3.  1 つ以上の描画コマンドを指定します。
4.  終了コマンドを指定します。 終了コマンドは省略することもできますが、その場合は図が開いたままになります (これは一般的ではありません)。

この構文の一般的な規則は次のとおりです。

-   各コマンドは 1 文字で表されます。
-   コマンドの文字は大文字または小文字で指定できます。 後で説明するように、大文字と小文字は区別されます。
-   通常、終了コマンド以外の各コマンドには 1 つ以上の数値が続きます。
-   1 つのコマンドに複数の数値を指定する場合は、コンマまたはスペースで区切ります。

**\[**_fillRule_ **\]** _moveCommand_ _drawCommand_ **\[** _drawCommand_ **\* \]** **\[** _closeCommand_**\]**

描画コマンドの多くでは点が使われますが、これは _x,y_ 値として指定します。 表示される場合、 \*_ポイント_プレース ホルダーをすることを想定できます 2 つの 10 進値が提供されています、 _x, y_ポイントの値。

空白がなくても結果があいまいにならない場合は、空白を省略できます。 すべての数値 (ポイントとサイズ) の区切り文字をコンマにすると、空白をすべて省略することができます。 たとえば、`F1M0,58L2,56L6,60L13,51L15,53L6,64z` という使い方は正当です。 ただし、読みやすくするために、コマンドの間には空白を含めるのが一般的です。

コンマを 10 進数の小数点として使わないでください。コマンド文字列は XAML によって解釈され、**en-us** ロケール以外で使われるカルチャ固有の数値形式の規則は考慮されません。

## <a name="syntax-specifics"></a>構文仕様

**規則を入力します。**

省略可能な塗りつぶしルールの 2 つの値があります。**F0**または**F1**します。 (、 **F**が常に大文字です)。**F0**既定値は、生成**EvenOdd**通常指定しないので、動作を入力します。 **Nonzero** の塗りつぶし動作を有効にするには、**F1** を使います。 これらの塗りつぶしの値は、[**FillRule**](https://msdn.microsoft.com/library/windows/apps/br210030) 列挙体の値と対応しています。

**移動 コマンド**

新しい図の始点を指定します。

| 構文 |
|--------|
| `M ` _始点_ <br/>- または -<br/>`m` _始点_|

| 用語 | 説明 |
|------|-------------|
| _始点_ | [**ポイント**](https://msdn.microsoft.com/library/windows/apps/br225870) <br/>新しい図の始点。|

大文字の **M** は *startPoint* が絶対座標であることを示し、小文字の **m** は、*startPoint* が前の点からのオフセットか、前の点がない場合は (0,0) からのオフセットであることを示します。

**注**  移動コマンドの後に複数のポイントを指定することはできます。 これらの点の間には、直線コマンドを指定した場合と同様に直線が描画されます。 ただし、これは推奨されるスタイルではありません。代わりに専用の直線コマンドを使ってください。

**描画コマンド**

描画コマンドはいくつかの図形コマンドから構成されます。図形コマンドには、直線、水平線、垂直線、三次ベジエ曲線、二次ベジエ曲線、平滑三次ベジエ曲線、平滑二次ベジエ曲線、楕円円弧があります。

すべての描画コマンドで大文字と小文字が区別されます。 大文字は絶対座標を示し、小文字は前のコマンドからの相対座標を示します。

セグメントの制御点は、前のセグメントの終点からの相対値で表されます。 同じ種類のコマンドを複数回続けて入力するときは、重複するコマンドの入力を省略できます。 たとえば、`L 100,200 300,400` は `L 100,200 L 300,400` と同じです。

**行のコマンド**

現在の点と指定した終点の間に直線を作成します。 たとえば、`l 20 30` や `L 20,30` は有効な直線コマンドです。 [  **LineGeometry**](https://msdn.microsoft.com/library/windows/apps/br210117) オブジェクトと同等の結果が定義されます。

| 構文 |
|--------|
| `L` _エンドポイント_ <br/>- または -<br/>`l` _エンドポイント_ |

| 用語 | 説明 |
|------|-------------|
| endPoint | [**ポイント**](https://msdn.microsoft.com/library/windows/apps/br225870)<br/>直線の終点。|

**水平線コマンド**

現在の点と指定した x 座標の間に水平線を作成します。 たとえば、`H 90` は有効な水平線コマンドです。

| 構文 |
|--------|
| `H ` _X_ <br/> - または - <br/>`h ` _X_ |

| 用語 | 説明 |
|------|-------------|
| ○ | [**Double 型**](https://msdn.microsoft.com/library/windows/apps/system.double.aspx) <br/> 直線の終点の x 座標。 |

**垂直線コマンド**

現在の点と指定した y 座標の間に垂直線を作成します。 たとえば、`v 90` は有効な垂直線コマンドです。

| 構文 |
|--------|
| `V ` _y_ <br/> - または - <br/> `v ` _y_ |

| 用語 | 説明 |
|------|-------------|
| *y* | [**Double 型**](https://msdn.microsoft.com/library/windows/apps/system.double.aspx) <br/> 直線の終点の y 座標。 |

**3 次ベジエ曲線コマンド**

指定した 2 つの制御点 (*controlPoint1* と *controlPoint2*) を使って、現在の点と指定した終点の間に三次ベジエ曲線を作成します。 たとえば、`C 100,200 200,400 300,200` は有効な曲線コマンドです。 [  **BezierSegment**](https://msdn.microsoft.com/library/windows/apps/br228068) オブジェクトを持つ [**PathGeometry**](https://msdn.microsoft.com/library/windows/apps/br210168) オブジェクトと同等の結果が定義されます。

| 構文 |
|--------|
| `C ` *controlPoint1* *controlPoint2* *エンドポイント* <br/> - または - <br/> `c ` *controlPoint1* *controlPoint2* *エンドポイント* |

| 用語 | 説明 |
|------|-------------|
| *controlPoint1* | [**ポイント**](https://msdn.microsoft.com/library/windows/apps/br225870) <br/> 曲線の 1 つ目の制御点。曲線の開始接線を決定します。 |
| *controlPoint2* | [**ポイント**](https://msdn.microsoft.com/library/windows/apps/br225870) <br/> 曲線の 2 つ目の制御点。曲線の終了接線を決定します。 |
| *エンドポイント* | [**ポイント**](https://msdn.microsoft.com/library/windows/apps/br225870) <br/> 描画される曲線の終点。 | 

**2 次ベジエ曲線コマンド**

指定した制御点 (*controlPoint*) を使って、現在の点と指定した終点の間に二次ベジエ曲線を作成します。 たとえば、`q 100,200 300,200` は有効な二次ベジエ曲線コマンドです。 [  **QuadraticBezierSegment**](https://msdn.microsoft.com/library/windows/apps/br210249) を持つ [**PathGeometry**](https://msdn.microsoft.com/library/windows/apps/br210168) と同等の結果が定義されます。

| 構文 |
|--------|
| `Q ` *controlPoint エンドポイント* <br/> - または - <br/> `q ` *controlPoint エンドポイント* |

| 用語 | 説明 |
|------|-------------|
| *controlPoint* | [**ポイント**](https://msdn.microsoft.com/library/windows/apps/br225870) <br/> 曲線の制御点。曲線の開始接線と終了接線を決定します。 |
| *エンドポイント* | [**ポイント**](https://msdn.microsoft.com/library/windows/apps/br225870)<br/> 描画される曲線の終点。 |

**スムーズ 3 次ベジエ曲線コマンド**

現在の点と指定した終点の間に三次ベジエ曲線を作成します。 1 つ目の制御点は、現在の点を基準として、前のコマンドの 2 つ目の制御点に点対称となるものと想定されます。 前のコマンドがない場合や、前のコマンドが三次ベジエ曲線コマンドまたは平滑三次ベジエ曲線コマンドでない場合、1 つ目の制御点は現在の点と一致すると見なされます。 2 つ目の制御点 (曲線の終端の制御点) は、*controlPoint2* によって指定します。 たとえば、 `S 100,200 200,300` は有効な平滑三次ベジエ曲線コマンドです。 このコマンドは、前に曲線セグメントがある場合の、[**BezierSegment**](https://msdn.microsoft.com/library/windows/apps/br228068) を持つ [**PathGeometry**](https://msdn.microsoft.com/library/windows/apps/br210168) と同等の結果を定義します。

| 構文 |
|--------|
| `S` *controlPoint2* *エンドポイント* <br/> - または - <br/>`s` *controlPoint2 エンドポイント* |

| 用語 | 説明 |
|------|-------------|
| *controlPoint2* | [**ポイント**](https://msdn.microsoft.com/library/windows/apps/br225870) <br/> 曲線の制御点。曲線の終了接線を決定します。 |
| *エンドポイント* | [**ポイント**](https://msdn.microsoft.com/library/windows/apps/br225870)<br/> 描画される曲線の終点。 |

**スムーズ 2 次ベジエ曲線コマンド**

現在の点と指定した終点の間に二次ベジエ曲線を作成します。 制御点は、現在の点を基準として、前のコマンドの制御点に点対称となるものと想定されます。 前のコマンドがない場合や、前のコマンドが二次ベジエ曲線コマンドまたは平滑二次ベジエ曲線コマンドでない場合、制御点は現在の点と一致します。 このコマンドは、前に曲線セグメントがある場合の、[**QuadraticBezierSegment**](https://msdn.microsoft.com/library/windows/apps/br210249) を持つ [**PathGeometry**](https://msdn.microsoft.com/library/windows/apps/br210168) と同等の結果を定義します。

| 構文 |
|--------|
| `T` *controlPoint* *エンドポイント* <br/> - または - <br/> `t` *controlPoint* *エンドポイント* |

| 用語 | 説明 |
|------|-------------|
| *controlPoint* | [**ポイント**](https://msdn.microsoft.com/library/windows/apps/br225870)<br/> 曲線の制御点。曲線の開始接線を決定します。 |
| *エンドポイント* | [**ポイント**](https://msdn.microsoft.com/library/windows/apps/br225870)<br/> 描画される曲線の終点。 |

**楕円の円弧コマンド**

現在の点と指定した終点の間に楕円の円弧を作成します。 [  **ArcSegment**](https://msdn.microsoft.com/library/windows/apps/br228054) を持つ [**PathGeometry**](https://msdn.microsoft.com/library/windows/apps/br210168) と同等の結果が定義されます。

| 構文 |
|--------|
| `A ` *サイズ* *rotationAngle* *isLargeArcFlag* *sweepDirectionFlag* *エンドポイント* <br/> - または - <br/>`a ` *sizerotationAngleisLargeArcFlagsweepDirectionFlagendPoint* |

| 用語 | 説明 |
|------|-------------|
| *サイズ* | [**サイズ**](https://msdn.microsoft.com/library/windows/apps/br225995)<br/>円弧の x 半径と y 半径。 |
| *rotationAngle* | [**Double 型**](https://msdn.microsoft.com/library/windows/apps/system.double.aspx) <br/> 楕円の回転角度。 |
| *isLargeArcFlag* | 円弧の角度を 180°以上にする場合は 1、それ以外の場合は 0 に設定します。 |
| *sweepDirectionFlag* | 円弧を正方向の角度に描画する場合は 1、それ以外の場合は 0 に設定します。 |
| *エンドポイント* | [**ポイント**](https://msdn.microsoft.com/library/windows/apps/br225870) <br/> 描画される円弧の終点。|
 
**[閉じる] コマンド**

現在の図を終了し、現在の点と図の始点を結ぶ直線を作成します。 このコマンドは、図の最後のセグメントと最初のセグメントの間に線結合 (角) を作成します。

| 構文 |
|--------|
| `Z` <br/> - または - <br/> `z ` |

**構文をポイントします。**

点の x 座標と y 座標を記述します。 [  **Point**](https://msdn.microsoft.com/library/windows/apps/br225870) もご覧ください。

| 構文 |
|--------|
| *x*,*y*<br/> - または - <br/>*x* *y* |

| 用語 | 説明 |
|------|-------------|
| *x* | [**Double 型**](https://msdn.microsoft.com/library/windows/apps/system.double.aspx) <br/> 点の x 座標。 |
| *y* | [**Double 型**](https://msdn.microsoft.com/library/windows/apps/system.double.aspx) <br/> 点の y 座標。 |

**その他のメモ**

標準的な数値の代わりに、次の特殊な値を使うこともできます。 これらの値では、大文字と小文字が区別されます。

-   **無限大**:表す**PositiveInfinity**します。
-   **\-無限大**:表す**NegativeInfinity**します。
-   **NaN**:表す**NaN**します。

10 進数や整数を使う代わりに、指数表記を使うこともできます。 たとえば、`+1.e17` は有効な値です。

## <a name="design-tools-that-produce-move-and-draw-commands"></a>移動と描画のコマンドを生成するデザイン ツール

使用して、**ペン**ツールと Blend for Microsoft Visual Studio 2015 での他の描画ツールが生成されます、 [**パス**](/uwp/api/Windows.UI.Xaml.Shapes.Path)オブジェクトを移動および描画コマンド。

Windows ランタイムのコントロール用の既定の XAML テンプレートを見ると、定義されているコントロールのパーツの一部に、移動と描画のコマンドのデータが含まれていることに気付くことがあります。 たとえば、一部のコントロールで使われる [**PathIcon**](https://msdn.microsoft.com/library/windows/apps/dn252722) では、データが移動と描画のコマンドとして定義されています。

その他のよく使われるベクター グラフィックス デザイン ツールにも、ベクターを XAML 形式で出力できるエクスポーターやプラグインがあります。 これらは通常、レイアウト コンテナーに [**Path**](/uwp/api/Windows.UI.Xaml.Shapes.Path) オブジェクトを作成し、[**Path.Data**](https://msdn.microsoft.com/library/windows/apps/br243356) に移動と描画のコマンドを設定します。 XAML には、別々のブラシを適用できるように複数の **Path** 要素が含まれている場合があります。 Windows Presentation Foundation (WPF) XAML、Silverlight、用に作成されたこれらのエクスポートまたはプラグインの多くが、XAML パスの構文は Windows ランタイムの XAML のと同じです。 通常、エクスポーターからの XAML の大部分を Windows ランタイムの XAML ページに直接貼り付けることができます  (ただし、変換後の XAML に **RadialGradientBrush** が含まれている場合、このブラシは Windows ランタイム XAML でサポートされないため、使うことはできません)。

## <a name="related-topics"></a>関連トピック

* [図形を描画します。](https://msdn.microsoft.com/library/windows/apps/mt280380)
* [ブラシを使用します。](https://msdn.microsoft.com/library/windows/apps/mt280383)
* [**Path.Data**](https://msdn.microsoft.com/library/windows/apps/br243356)
* [**PathIcon**](https://msdn.microsoft.com/library/windows/apps/dn252722)

