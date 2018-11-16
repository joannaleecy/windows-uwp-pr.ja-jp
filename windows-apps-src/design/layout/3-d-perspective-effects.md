---
author: Jwmsft
ms.assetid: 90F07341-01F4-4205-8161-92DD2EB49860
title: XAML UI 用の 3-D 遠近効果
description: 視点の変換を使って、3D 効果を Windows ランタイム アプリのコンテンツに適用することができます。 たとえば、次に示すように、オブジェクトが回転してユーザーに近づいたり離れたりするように見せることができます。
ms.author: jimwalk
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: f0b50ca4cb3f74c7c8e8bccb4fceb58e0151bcf2
ms.sourcegitcommit: e2fca6c79f31e521ba76f7ecf343cf8f278e6a15
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/16/2018
ms.locfileid: "6989757"
---
# <a name="3-d-perspective-effects-for-xaml-ui"></a>XAML UI 用の 3-D 遠近効果


視点の変換を使って、3D 効果を Windows ランタイム アプリのコンテンツに適用することができます。 たとえば、次に示すように、オブジェクトが回転してユーザーに近づいたり離れたりするように見せることができます。

![視点の変換を使った画像](images/3dsimple.png)

また、次に示すように、複数のオブジェクトを互いに相対的に配置して 3D 効果を作成することも、視点の変換の一般的な使い方の 1 つです。

![オブジェクトを重ねて 3D 効果を作成](images/3dstacking.png)

静的な 3D 効果の作成だけでなく、視点の変換のプロパティにアニメーションを適用すると、動く 3D 効果を作成できます。

ここまでは、視点の変換を画像に適用する例を見ましたが、これらの効果は、コントロールなどすべての [**UIElement**](https://msdn.microsoft.com/library/windows/apps/BR208911) に適用できます。 たとえば、次のようなコントロールのコンテナー全体に 3D 効果を適用できます。

![要素のコンテナーに適用された 3D 効果](images/skewedstackpanel.png)

このサンプルの作成に使った XAML コードを次に示します。

```xml
<StackPanel Margin="35" Background="Gray">    
    <StackPanel.Projection>        
        <PlaneProjection RotationX="-35" RotationY="-35" RotationZ="15"  />    
    </StackPanel.Projection>    
    <TextBlock Margin="10">Type Something Below</TextBlock>    
    <TextBox Margin="10"></TextBox>    
    <Button Margin="10" Content="Click" Width="100" />
</StackPanel>
```

ここでは、3D 空間でのオブジェクトの回転と移動に使われる [**PlaneProjection**](https://msdn.microsoft.com/library/windows/apps/BR210192) のプロパティに注目してください。 次のサンプルでは、これらのプロパティの動作を実際に試し、オブジェクトへの影響を調べることができます。

## <a name="planeprojection-class"></a>PlaneProjection クラス

[**PlaneProjection**](https://msdn.microsoft.com/library/windows/apps/BR210192) を使って [**UIElement**](https://msdn.microsoft.com/library/windows/apps/BR208911) の [**Projection**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.projection) プロパティを設定することで、UIElement に 3D 効果を適用できます。 **PlaneProjection** は、変換を空間内でどのようにレンダリングするかを定義します。 単純な場合の例を次に示します。

```xml
<Image Source="kid.png">
    <Image.Projection>
        <PlaneProjection RotationX="-35"   />
    </Image.Projection>
</Image>
```

次の図は、画像のレンダリング結果を示しています。 X 軸、Y 軸、Z 軸が赤い線で示されています。 この画像は、[**RotationX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.rotationx) プロパティを使って、X 軸の周りに 35°後方に回転しています。

![-35°の X 回転](images/3drotatexminus35.png)

[**RotationY**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.rotationy) プロパティは、回転中心の Y 軸の周りに画像を回転させます。

```xml
<Image Source="kid.png">
    <Image.Projection>
        <PlaneProjection RotationY="-35"   />
    </Image.Projection>
</Image>
```

![-35°の Y 回転](images/3drotateyminus35.png)

[**RotationZ**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.rotationz) プロパティは、回転中心の Z 軸 (オブジェクトの平面に垂直な直線) の周りに画像を回転させます。

```xml
<Image Source="kid.png">
    <Image.Projection>
        <PlaneProjection RotationZ="-45"/>
    </Image.Projection>
</Image>
```

![-45°の Z 回転](images/3drotatezminus35.png)

回転プロパティでは、正または負の値を指定することで、どちらの方向にも回転させることができます。 絶対値が 360 を超える値も指定でき、その場合、オブジェクトは 1 回転よりも大きく回転します。

[**CenterOfRotationX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.centerofrotationx)、[**CenterOfRotationY**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.centerofrotationy)、[**CenterOfRotationZ**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.centerofrotationz) の各プロパティを使うと、回転の中心を移動できます。 既定では、各回転軸がオブジェクトの中心を通っているため、オブジェクトは中心の周りを回転します。 ただし、回転の中心をオブジェクトの外側の端に移動すると、オブジェクトはその端の周りを回転します。 **CenterOfRotationX** と **CenterOfRotationY** の既定値は 0.5 であり、**CenterOfRotationZ** の既定値は 0 です。 **CenterOfRotationX** と **CenterOfRotationY** では、0 ～ 1 の値を指定すると、回転の中心がオブジェクト内部の点に設定されます。 値 0 はオブジェクトの一方の端を示し、値 1 はもう一方の端を示します。 この範囲外の値も指定でき、回転の中心は対応する位置に移動します。 回転の中心の Z 軸はオブジェクトの平面と交差しているため、負の値を指定すると回転の中心をオブジェクトの後ろに移動でき、正の値を指定するとオブジェクトの手前へ移動できます。

[**CenterOfRotationX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.centerofrotationx) は回転の中心をオブジェクトと平行に X 軸に沿って移動し、[**CenterOfRotationY**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.centerofrotationy) は回転の中心をオブジェクトの Y 軸に沿って移動します。 **CenterOfRotationY** にさまざまな値を指定した例を以降の図に示します。

```xml
<Image Source="kid.png">
    <Image.Projection>
        <PlaneProjection RotationX="-35" CenterOfRotationY="0.5" />
    </Image.Projection>
</Image>
```

**CenterOfRotationY = "0.5" (既定)**

![CenterOfRotationY が 0.5](images/3drotatexminus35.png)
```xml
<Image Source="kid.png">
    <Image.Projection>
        <PlaneProjection RotationX="-35" CenterOfRotationY="0.1"/>
    </Image.Projection>
</Image>
```

**CenterOfRotationY = "0.1"**

![CenterOfRotationY が 0.1](images/3dcenterofrotationy0point1.png)

[**CenterOfRotationY**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.centerofrotationy) プロパティを既定値の 0.5 に設定すると画像が中心の周りを回転し、0.1 に設定するとほぼ上端の周りを回転することがわかります。 [**CenterOfRotationX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.centerofrotationx) プロパティを変更することで、[**RotationY**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.rotationy) プロパティによってオブジェクトが回転する位置を移動した場合も、同様な結果が得られます。

```xml
<Image Source="kid.png">
    <Image.Projection>
        <PlaneProjection RotationY="-35" CenterOfRotationX="0.5" />
    </Image.Projection>
</Image>
```

**CenterOfRotationX = "0.5" (既定)**

![CenterOfRotationX が 0.5](images/3drotateyminus35.png)
```xml
<Image Source="kid.png">
    <Image.Projection>
        <PlaneProjection RotationY="-35" CenterOfRotationX="0.5" />
    </Image.Projection>
</Image>
```

**CenterOfRotationX = "0.9" (右端)**

![CenterOfRotationX が 0.9](images/3dcenterofrotationx0point9.png)

オブジェクトの平面よりも上側または下側に回転の中心を配置するには、[**CenterOfRotationZ**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.centerofrotationz) を使用します。 これにより、恒星の周りを周回する惑星のように、その点を中心にオブジェクトを回転させることができます。

## <a name="positioning-an-object"></a>オブジェクトの配置

ここまで、空間内でオブジェクトを回転させる方法について説明しました。 以下のプロパティを使うと、空間内でこれらの回転したオブジェクトを互いに相対的に配置できます。

-   [**LocalOffsetX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.localoffsetx) は、回転したオブジェクトの平面の X 軸に沿ってオブジェクトを移動します。
-   [**LocalOffsetY**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.localoffsety) は、回転したオブジェクトの平面の Y 軸に沿ってオブジェクトを移動します。
-   [**LocalOffsetZ**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.localoffsetz) は、回転したオブジェクトの平面の Z 軸に沿ってオブジェクトを移動します。
-   [**GlobalOffsetX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.globaloffsetx) は、画面の X 軸に沿ってオブジェクトを移動します。
-   [**GlobalOffsetY**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.globaloffsety) は、画面の Y 軸に沿ってオブジェクトを移動します。
-   [**GlobalOffsetZ**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.globaloffsetz) は、画面の Z 軸に沿ってオブジェクトを移動します。

**ローカル オフセット**

[**LocalOffsetX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.localoffsetx)、[**LocalOffsetY**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.localoffsety)、[**LocalOffsetZ**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.localoffsetz) の各プロパティは、オブジェクトを回転させた後で、オブジェクトの平面の該当する軸に沿ってオブジェクトを移動します。 したがって、オブジェクトの回転によって、オブジェクトが移動する方向が決まります。 この考え方を示すために、次のサンプルでは、**LocalOffsetX** を 0 から 400 まで、[**RotationY**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.rotationy) を 0 から 65°まで変化させてアニメーションを表示します。

このサンプルでは、オブジェクトが自身の X 軸に沿って移動していることがわかります。 アニメーションの冒頭で [**RotationY**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.rotationy) の値が 0 (画面に平行) に近いときには、オブジェクトは画面に沿って X 方向に移動しますが、オブジェクトが前方に回転するにつれて、オブジェクトは自身の平面の X 軸に沿って前方に移動するようになります。 一方、**RotationY** プロパティを -65°に設定した場合は、オブジェクトが後方に離れていきます。

[**LocalOffsetY**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.localoffsety) も [**LocalOffsetX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.localoffsetx) と同様に機能しますが、オブジェクトは Y 軸に沿って移動します。[**RotationX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.rotationx) を変更すると、**LocalOffsetY** でオブジェクトが移動する方向が変化します。 次のサンプルでは、**LocalOffsetY** を 0 から 400 まで、**RotationX** を 0 から 65°まで変化させてアニメーションを表示します。

[**LocalOffsetZ**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.localoffsetz) は、オブジェクトの平面に垂直な方向にオブジェクトを移動し、これは、オブジェクトの後ろから直接中心を通って手前へ抜けるベクターを描画したような結果となります。 **LocalOffsetZ** の機能を示すために、次のサンプルでは、**LocalOffsetZ** を 0 から 400 まで、[**RotationX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.rotationx) を 0 から 65°まで変化させてアニメーションを表示します。

アニメーションの冒頭で [**RotationX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.rotationx) の値が 0 (画面に平行) に近いときには、オブジェクトはまっすぐ手前へ向かって移動しますが、オブジェクトの平面が下側に回転するにつれて、オブジェクトは下に向かって移動するようになります。

**グローバル オフセット**

[**GlobalOffsetX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.globaloffsetx)、[**GlobalOffsetY**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.globaloffsety)、[**GlobalOffsetZ**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.globaloffsetz) の各プロパティは、画面を基準とした軸に沿ってオブジェクトを移動します。 つまり、ローカル オフセット プロパティとは異なり、オブジェクトが移動する軸は、オブジェクトに適用される回転に依存しません。 これらのプロパティは、オブジェクトに適用される回転に関係なく、単に画面の X 軸、Y 軸、Z 軸に沿ってオブジェクトを移動する場合に便利です。

次のサンプルでは、[**GlobalOffsetX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.globaloffsetx) を 0 から 400 まで、[**RotationY**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.rotationy) を 0 から 65°まで変化させてアニメーションを表示します。

このサンプルでは、オブジェクトが回転しても移動方向が変わらないことがわかります。 これは、オブジェクトが回転に関係なく画面の X 軸に沿って移動しているためです。

## <a name="positioning-an-object"></a>オブジェクトの配置

[**PlaneProjection**](https://msdn.microsoft.com/library/windows/apps/BR210192) を使って対応できる場合よりもさらに複雑な疑似 3D のシナリオに対しては、[**Matrix3DProjection**](https://msdn.microsoft.com/library/windows/apps/BR210128) 型および [**Matrix3D**](https://msdn.microsoft.com/library/windows/apps/BR243266) 型を使うことができます。 **Matrix3DProjection** には、どの [**UIElement**](https://msdn.microsoft.com/library/windows/apps/BR208911) にも適用できる完全な 3D 変換マトリックスが備えられているため、任意のモデル変換マトリックスおよび視点マトリックスを要素に適用できます。 これらの API は最小限のものであるため、使用する場合は、3D 変換マトリックスを正しく作成するコードを記述する必要があります。 そのため、単純な 3D シナリオには、**PlaneProjection** を使う方が簡単です。
