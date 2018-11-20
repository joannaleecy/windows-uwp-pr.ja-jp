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
ms.sourcegitcommit: ed0304b8a214c03b8aab74b8ef12c9f82b8e3c5f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/19/2018
ms.locfileid: "7296724"
---
# <a name="3-d-perspective-effects-for-xaml-ui"></a><span data-ttu-id="08650-105">XAML UI 用の 3-D 遠近効果</span><span class="sxs-lookup"><span data-stu-id="08650-105">3-D perspective effects for XAML UI</span></span>


<span data-ttu-id="08650-106">視点の変換を使って、3D 効果を Windows ランタイム アプリのコンテンツに適用することができます。</span><span class="sxs-lookup"><span data-stu-id="08650-106">You can apply 3-D effects to content in your Windows Runtime apps using perspective transforms.</span></span> <span data-ttu-id="08650-107">たとえば、次に示すように、オブジェクトが回転してユーザーに近づいたり離れたりするように見せることができます。</span><span class="sxs-lookup"><span data-stu-id="08650-107">For example, you can create the illusion that an object is rotated toward or away from you, as shown here.</span></span>

![視点の変換を使った画像](images/3dsimple.png)

<span data-ttu-id="08650-109">また、次に示すように、複数のオブジェクトを互いに相対的に配置して 3D 効果を作成することも、視点の変換の一般的な使い方の 1 つです。</span><span class="sxs-lookup"><span data-stu-id="08650-109">Another common usage for perspective transforms is to arrange objects in relation to one another to create a 3-D effect, as here.</span></span>

![オブジェクトを重ねて 3D 効果を作成](images/3dstacking.png)

<span data-ttu-id="08650-111">静的な 3D 効果の作成だけでなく、視点の変換のプロパティにアニメーションを適用すると、動く 3D 効果を作成できます。</span><span class="sxs-lookup"><span data-stu-id="08650-111">Besides creating static 3-D effects, you can animate the perspective transform properties to create moving 3-D effects.</span></span>

<span data-ttu-id="08650-112">ここまでは、視点の変換を画像に適用する例を見ましたが、これらの効果は、コントロールなどすべての [**UIElement**](https://msdn.microsoft.com/library/windows/apps/BR208911) に適用できます。</span><span class="sxs-lookup"><span data-stu-id="08650-112">You just saw perspective transforms applied to images, but you can apply these effects to any [**UIElement**](https://msdn.microsoft.com/library/windows/apps/BR208911), including controls.</span></span> <span data-ttu-id="08650-113">たとえば、次のようなコントロールのコンテナー全体に 3D 効果を適用できます。</span><span class="sxs-lookup"><span data-stu-id="08650-113">For example, you can apply a 3-D effect to an entire container of controls like this:</span></span>

![要素のコンテナーに適用された 3D 効果](images/skewedstackpanel.png)

<span data-ttu-id="08650-115">このサンプルの作成に使った XAML コードを次に示します。</span><span class="sxs-lookup"><span data-stu-id="08650-115">Here is the XAML code used to create this sample:</span></span>

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

<span data-ttu-id="08650-116">ここでは、3D 空間でのオブジェクトの回転と移動に使われる [**PlaneProjection**](https://msdn.microsoft.com/library/windows/apps/BR210192) のプロパティに注目してください。</span><span class="sxs-lookup"><span data-stu-id="08650-116">Here we focus on the properties of [**PlaneProjection**](https://msdn.microsoft.com/library/windows/apps/BR210192) which is used to rotate and move objects in 3-D space.</span></span> <span data-ttu-id="08650-117">次のサンプルでは、これらのプロパティの動作を実際に試し、オブジェクトへの影響を調べることができます。</span><span class="sxs-lookup"><span data-stu-id="08650-117">The next sample allows you to experiment with these properties and see their effect on an object.</span></span>

## <a name="planeprojection-class"></a><span data-ttu-id="08650-118">PlaneProjection クラス</span><span class="sxs-lookup"><span data-stu-id="08650-118">PlaneProjection class</span></span>

<span data-ttu-id="08650-119">[**PlaneProjection**](https://msdn.microsoft.com/library/windows/apps/BR210192) を使って [**UIElement**](https://msdn.microsoft.com/library/windows/apps/BR208911) の [**Projection**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.projection) プロパティを設定することで、UIElement に 3D 効果を適用できます。</span><span class="sxs-lookup"><span data-stu-id="08650-119">You can apply 3D effects can to any [**UIElement**](https://msdn.microsoft.com/library/windows/apps/BR208911), by setting the UIElement's [**Projection**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.projection) property using a [**PlaneProjection**](https://msdn.microsoft.com/library/windows/apps/BR210192).</span></span> <span data-ttu-id="08650-120">**PlaneProjection** は、変換を空間内でどのようにレンダリングするかを定義します。</span><span class="sxs-lookup"><span data-stu-id="08650-120">The **PlaneProjection** defines how the transform is rendered in space.</span></span> <span data-ttu-id="08650-121">単純な場合の例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="08650-121">The next example shows a simple case.</span></span>

```xml
<Image Source="kid.png">
    <Image.Projection>
        <PlaneProjection RotationX="-35"   />
    </Image.Projection>
</Image>
```

<span data-ttu-id="08650-122">次の図は、画像のレンダリング結果を示しています。</span><span class="sxs-lookup"><span data-stu-id="08650-122">This figure shows what the image renders as.</span></span> <span data-ttu-id="08650-123">X 軸、Y 軸、Z 軸が赤い線で示されています。</span><span class="sxs-lookup"><span data-stu-id="08650-123">The x-axis, y-axis, and z-axis are shown as red lines.</span></span> <span data-ttu-id="08650-124">この画像は、[**RotationX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.rotationx) プロパティを使って、X 軸の周りに 35°後方に回転しています。</span><span class="sxs-lookup"><span data-stu-id="08650-124">The image is rotated backward 35 degrees around the x-axis using the [**RotationX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.rotationx) property.</span></span>

![-35°の X 回転](images/3drotatexminus35.png)

<span data-ttu-id="08650-126">[**RotationY**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.rotationy) プロパティは、回転中心の Y 軸の周りに画像を回転させます。</span><span class="sxs-lookup"><span data-stu-id="08650-126">The [**RotationY**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.rotationy) property rotates around the y-axis of the center of rotation.</span></span>

```xml
<Image Source="kid.png">
    <Image.Projection>
        <PlaneProjection RotationY="-35"   />
    </Image.Projection>
</Image>
```

![-35°の Y 回転](images/3drotateyminus35.png)

<span data-ttu-id="08650-128">[**RotationZ**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.rotationz) プロパティは、回転中心の Z 軸 (オブジェクトの平面に垂直な直線) の周りに画像を回転させます。</span><span class="sxs-lookup"><span data-stu-id="08650-128">The [**RotationZ**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.rotationz) property rotates around the z-axis of the center of rotation (a line that is perpendicular to the plane of the object).</span></span>

```xml
<Image Source="kid.png">
    <Image.Projection>
        <PlaneProjection RotationZ="-45"/>
    </Image.Projection>
</Image>
```

![-45°の Z 回転](images/3drotatezminus35.png)

<span data-ttu-id="08650-130">回転プロパティでは、正または負の値を指定することで、どちらの方向にも回転させることができます。</span><span class="sxs-lookup"><span data-stu-id="08650-130">The rotation properties can specify a positive or negative value to rotate in either direction.</span></span> <span data-ttu-id="08650-131">絶対値が 360 を超える値も指定でき、その場合、オブジェクトは 1 回転よりも大きく回転します。</span><span class="sxs-lookup"><span data-stu-id="08650-131">The absolute number can be greater than 360, which rotates the object more than one full rotation.</span></span>

<span data-ttu-id="08650-132">[**CenterOfRotationX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.centerofrotationx)、[**CenterOfRotationY**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.centerofrotationy)、[**CenterOfRotationZ**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.centerofrotationz) の各プロパティを使うと、回転の中心を移動できます。</span><span class="sxs-lookup"><span data-stu-id="08650-132">You can move the center of rotation by using the [**CenterOfRotationX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.centerofrotationx), [**CenterOfRotationY**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.centerofrotationy), and [**CenterOfRotationZ**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.centerofrotationz) properties.</span></span> <span data-ttu-id="08650-133">既定では、各回転軸がオブジェクトの中心を通っているため、オブジェクトは中心の周りを回転します。</span><span class="sxs-lookup"><span data-stu-id="08650-133">By default, the axes of rotation run directly through the center of the object, causing the object to rotate around its center.</span></span> <span data-ttu-id="08650-134">ただし、回転の中心をオブジェクトの外側の端に移動すると、オブジェクトはその端の周りを回転します。</span><span class="sxs-lookup"><span data-stu-id="08650-134">But if you move the center of rotation to the outer edge of the object, it will rotate around that edge.</span></span> <span data-ttu-id="08650-135">**CenterOfRotationX** と **CenterOfRotationY** の既定値は 0.5 であり、**CenterOfRotationZ** の既定値は 0 です。</span><span class="sxs-lookup"><span data-stu-id="08650-135">The default values for **CenterOfRotationX** and **CenterOfRotationY** are 0.5, and the default value for **CenterOfRotationZ** is 0.</span></span> <span data-ttu-id="08650-136">**CenterOfRotationX** と **CenterOfRotationY** では、0 ～ 1 の値を指定すると、回転の中心がオブジェクト内部の点に設定されます。</span><span class="sxs-lookup"><span data-stu-id="08650-136">For **CenterOfRotationX** and **CenterOfRotationY**, values between 0 and 1 set the pivot point at some location within the object.</span></span> <span data-ttu-id="08650-137">値 0 はオブジェクトの一方の端を示し、値 1 はもう一方の端を示します。</span><span class="sxs-lookup"><span data-stu-id="08650-137">A value of 0 denotes one object edge and 1 denotes the opposite edge.</span></span> <span data-ttu-id="08650-138">この範囲外の値も指定でき、回転の中心は対応する位置に移動します。</span><span class="sxs-lookup"><span data-stu-id="08650-138">Values outside of this range are allowed and will move the center of rotation accordingly.</span></span> <span data-ttu-id="08650-139">回転の中心の Z 軸はオブジェクトの平面と交差しているため、負の値を指定すると回転の中心をオブジェクトの後ろに移動でき、正の値を指定するとオブジェクトの手前へ移動できます。</span><span class="sxs-lookup"><span data-stu-id="08650-139">Because the z-axis of the center of rotation is drawn through the plane of the object, you can move the center of rotation behind the object using a negative number and in front of the object (toward you) using a positive number.</span></span>

<span data-ttu-id="08650-140">[**CenterOfRotationX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.centerofrotationx) は回転の中心をオブジェクトと平行に X 軸に沿って移動し、[**CenterOfRotationY**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.centerofrotationy) は回転の中心をオブジェクトの Y 軸に沿って移動します。</span><span class="sxs-lookup"><span data-stu-id="08650-140">[**CenterOfRotationX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.centerofrotationx) moves the center of rotation along the x-axis parallel to the object while [**CenterOfRotationY**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.centerofrotationy) moves the center or rotation along the y-axis of the object.</span></span> <span data-ttu-id="08650-141">**CenterOfRotationY** にさまざまな値を指定した例を以降の図に示します。</span><span class="sxs-lookup"><span data-stu-id="08650-141">The next illustrations demonstrate using different values for **CenterOfRotationY**.</span></span>

```xml
<Image Source="kid.png">
    <Image.Projection>
        <PlaneProjection RotationX="-35" CenterOfRotationY="0.5" />
    </Image.Projection>
</Image>
```

**<span data-ttu-id="08650-142">CenterOfRotationY = "0.5" (既定)</span><span class="sxs-lookup"><span data-stu-id="08650-142">CenterOfRotationY = "0.5" (default)</span></span>**

![CenterOfRotationY が 0.5](images/3drotatexminus35.png)
```xml
<Image Source="kid.png">
    <Image.Projection>
        <PlaneProjection RotationX="-35" CenterOfRotationY="0.1"/>
    </Image.Projection>
</Image>
```

**<span data-ttu-id="08650-144">CenterOfRotationY = "0.1"</span><span class="sxs-lookup"><span data-stu-id="08650-144">CenterOfRotationY = "0.1"</span></span>**

![CenterOfRotationY が 0.1](images/3dcenterofrotationy0point1.png)

<span data-ttu-id="08650-146">[**CenterOfRotationY**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.centerofrotationy) プロパティを既定値の 0.5 に設定すると画像が中心の周りを回転し、0.1 に設定するとほぼ上端の周りを回転することがわかります。</span><span class="sxs-lookup"><span data-stu-id="08650-146">Notice how the image rotates around the center when the [**CenterOfRotationY**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.centerofrotationy) property is set to the default value of 0.5 and rotates near the upper edge when set to 0.1.</span></span> <span data-ttu-id="08650-147">[**CenterOfRotationX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.centerofrotationx) プロパティを変更することで、[**RotationY**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.rotationy) プロパティによってオブジェクトが回転する位置を移動した場合も、同様な結果が得られます。</span><span class="sxs-lookup"><span data-stu-id="08650-147">You see similar behavior when changing the [**CenterOfRotationX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.centerofrotationx) property to move where the [**RotationY**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.rotationy) property rotates the object.</span></span>

```xml
<Image Source="kid.png">
    <Image.Projection>
        <PlaneProjection RotationY="-35" CenterOfRotationX="0.5" />
    </Image.Projection>
</Image>
```

**<span data-ttu-id="08650-148">CenterOfRotationX = "0.5" (既定)</span><span class="sxs-lookup"><span data-stu-id="08650-148">CenterOfRotationX = "0.5" (default)</span></span>**

![CenterOfRotationX が 0.5](images/3drotateyminus35.png)
```xml
<Image Source="kid.png">
    <Image.Projection>
        <PlaneProjection RotationY="-35" CenterOfRotationX="0.5" />
    </Image.Projection>
</Image>
```

**<span data-ttu-id="08650-150">CenterOfRotationX = "0.9" (右端)</span><span class="sxs-lookup"><span data-stu-id="08650-150">CenterOfRotationX = "0.9" (right-hand edge)</span></span>**

![CenterOfRotationX が 0.9](images/3dcenterofrotationx0point9.png)

<span data-ttu-id="08650-152">オブジェクトの平面よりも上側または下側に回転の中心を配置するには、[**CenterOfRotationZ**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.centerofrotationz) を使用します。</span><span class="sxs-lookup"><span data-stu-id="08650-152">Use the [**CenterOfRotationZ**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.centerofrotationz) to place the center of rotation above or below the plane of the object.</span></span> <span data-ttu-id="08650-153">これにより、恒星の周りを周回する惑星のように、その点を中心にオブジェクトを回転させることができます。</span><span class="sxs-lookup"><span data-stu-id="08650-153">This way, you can rotate the object around the point analogous to a planet orbiting around a star.</span></span>

## <a name="positioning-an-object"></a><span data-ttu-id="08650-154">オブジェクトの配置</span><span class="sxs-lookup"><span data-stu-id="08650-154">Positioning an object</span></span>

<span data-ttu-id="08650-155">ここまで、空間内でオブジェクトを回転させる方法について説明しました。</span><span class="sxs-lookup"><span data-stu-id="08650-155">So far, you learned how to rotate an object in space.</span></span> <span data-ttu-id="08650-156">以下のプロパティを使うと、空間内でこれらの回転したオブジェクトを互いに相対的に配置できます。</span><span class="sxs-lookup"><span data-stu-id="08650-156">You can position these rotated objects in space relative to one another by using these properties:</span></span>

-   <span data-ttu-id="08650-157">[**LocalOffsetX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.localoffsetx) は、回転したオブジェクトの平面の X 軸に沿ってオブジェクトを移動します。</span><span class="sxs-lookup"><span data-stu-id="08650-157">[**LocalOffsetX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.localoffsetx) moves an object along the x-axis of the plane of a rotated object.</span></span>
-   <span data-ttu-id="08650-158">[**LocalOffsetY**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.localoffsety) は、回転したオブジェクトの平面の Y 軸に沿ってオブジェクトを移動します。</span><span class="sxs-lookup"><span data-stu-id="08650-158">[**LocalOffsetY**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.localoffsety) moves an object along the y-axis of the plane of a rotated object.</span></span>
-   <span data-ttu-id="08650-159">[**LocalOffsetZ**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.localoffsetz) は、回転したオブジェクトの平面の Z 軸に沿ってオブジェクトを移動します。</span><span class="sxs-lookup"><span data-stu-id="08650-159">[**LocalOffsetZ**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.localoffsetz) moves an object along the z-axis of the plane of a rotated object.</span></span>
-   <span data-ttu-id="08650-160">[**GlobalOffsetX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.globaloffsetx) は、画面の X 軸に沿ってオブジェクトを移動します。</span><span class="sxs-lookup"><span data-stu-id="08650-160">[**GlobalOffsetX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.globaloffsetx) moves an object along the screen-aligned x-axis.</span></span>
-   <span data-ttu-id="08650-161">[**GlobalOffsetY**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.globaloffsety) は、画面の Y 軸に沿ってオブジェクトを移動します。</span><span class="sxs-lookup"><span data-stu-id="08650-161">[**GlobalOffsetY**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.globaloffsety) moves an object along the screen-aligned y-axis.</span></span>
-   <span data-ttu-id="08650-162">[**GlobalOffsetZ**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.globaloffsetz) は、画面の Z 軸に沿ってオブジェクトを移動します。</span><span class="sxs-lookup"><span data-stu-id="08650-162">[**GlobalOffsetZ**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.globaloffsetz) moves an object along the screen-aligned z-axis.</span></span>

**<span data-ttu-id="08650-163">ローカル オフセット</span><span class="sxs-lookup"><span data-stu-id="08650-163">Local offset</span></span>**

<span data-ttu-id="08650-164">[**LocalOffsetX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.localoffsetx)、[**LocalOffsetY**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.localoffsety)、[**LocalOffsetZ**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.localoffsetz) の各プロパティは、オブジェクトを回転させた後で、オブジェクトの平面の該当する軸に沿ってオブジェクトを移動します。</span><span class="sxs-lookup"><span data-stu-id="08650-164">The [**LocalOffsetX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.localoffsetx), [**LocalOffsetY**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.localoffsety), and [**LocalOffsetZ**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.localoffsetz) properties translate an object along the respective axis of the plane of the object after it has been rotated.</span></span> <span data-ttu-id="08650-165">したがって、オブジェクトの回転によって、オブジェクトが移動する方向が決まります。</span><span class="sxs-lookup"><span data-stu-id="08650-165">Therefore, the rotation of the object determines the direction that the object is translated.</span></span> <span data-ttu-id="08650-166">この考え方を示すために、次のサンプルでは、**LocalOffsetX** を 0 から 400 まで、[**RotationY**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.rotationy) を 0 から 65°まで変化させてアニメーションを表示します。</span><span class="sxs-lookup"><span data-stu-id="08650-166">To demonstrate this concept, the next sample animates **LocalOffsetX** from 0 to 400 and [**RotationY**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.rotationy) from 0 to 65 degrees.</span></span>

<span data-ttu-id="08650-167">このサンプルでは、オブジェクトが自身の X 軸に沿って移動していることがわかります。</span><span class="sxs-lookup"><span data-stu-id="08650-167">Notice in the preceding sample that the object is moving along its own x-axis.</span></span> <span data-ttu-id="08650-168">アニメーションの冒頭で [**RotationY**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.rotationy) の値が 0 (画面に平行) に近いときには、オブジェクトは画面に沿って X 方向に移動しますが、オブジェクトが前方に回転するにつれて、オブジェクトは自身の平面の X 軸に沿って前方に移動するようになります。</span><span class="sxs-lookup"><span data-stu-id="08650-168">At the very beginning of the animation, when the [**RotationY**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.rotationy) value is near zero (parallel to the screen), the object moves along the screen in the x direction, but as the object rotates toward you, the object moves along the x-axis of the plane of the object toward you.</span></span> <span data-ttu-id="08650-169">一方、**RotationY** プロパティを -65°に設定した場合は、オブジェクトが後方に離れていきます。</span><span class="sxs-lookup"><span data-stu-id="08650-169">On the other hand, if you animated the **RotationY** property to -65 degrees, the object would curve away from you.</span></span>

<span data-ttu-id="08650-170">[**LocalOffsetY**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.localoffsety) も [**LocalOffsetX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.localoffsetx) と同様に機能しますが、オブジェクトは Y 軸に沿って移動します。[**RotationX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.rotationx) を変更すると、**LocalOffsetY** でオブジェクトが移動する方向が変化します。</span><span class="sxs-lookup"><span data-stu-id="08650-170">[**LocalOffsetY**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.localoffsety) works similarly to [**LocalOffsetX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.localoffsetx), except that it moves along the vertical axis, so changing [**RotationX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.rotationx) affects the direction **LocalOffsetY** moves the object.</span></span> <span data-ttu-id="08650-171">次のサンプルでは、**LocalOffsetY** を 0 から 400 まで、**RotationX** を 0 から 65°まで変化させてアニメーションを表示します。</span><span class="sxs-lookup"><span data-stu-id="08650-171">In the next sample, **LocalOffsetY** is animated from 0 to 400 and **RotationX** from 0 to 65 degrees.</span></span>

<span data-ttu-id="08650-172">[**LocalOffsetZ**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.localoffsetz) は、オブジェクトの平面に垂直な方向にオブジェクトを移動し、これは、オブジェクトの後ろから直接中心を通って手前へ抜けるベクターを描画したような結果となります。</span><span class="sxs-lookup"><span data-stu-id="08650-172">[**LocalOffsetZ**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.localoffsetz) translates the object perpendicular to the plane of the object as though a vector was drawn directly through the center from behind the object out toward you.</span></span> <span data-ttu-id="08650-173">**LocalOffsetZ** の機能を示すために、次のサンプルでは、**LocalOffsetZ** を 0 から 400 まで、[**RotationX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.rotationx) を 0 から 65°まで変化させてアニメーションを表示します。</span><span class="sxs-lookup"><span data-stu-id="08650-173">To demonstrate how **LocalOffsetZ** works, the next sample animates **LocalOffsetZ** from 0 to 400 and [**RotationX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.rotationx) from 0 to 65 degrees.</span></span>

<span data-ttu-id="08650-174">アニメーションの冒頭で [**RotationX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.rotationx) の値が 0 (画面に平行) に近いときには、オブジェクトはまっすぐ手前へ向かって移動しますが、オブジェクトの平面が下側に回転するにつれて、オブジェクトは下に向かって移動するようになります。</span><span class="sxs-lookup"><span data-stu-id="08650-174">At the beginning of the animation, when the [**RotationX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.rotationx) value is near zero (parallel to the screen), the object moves directly out toward you, but as the face of the object rotates down, the object moves down instead.</span></span>

**<span data-ttu-id="08650-175">グローバル オフセット</span><span class="sxs-lookup"><span data-stu-id="08650-175">Global offset</span></span>**

<span data-ttu-id="08650-176">[**GlobalOffsetX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.globaloffsetx)、[**GlobalOffsetY**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.globaloffsety)、[**GlobalOffsetZ**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.globaloffsetz) の各プロパティは、画面を基準とした軸に沿ってオブジェクトを移動します。</span><span class="sxs-lookup"><span data-stu-id="08650-176">The [**GlobalOffsetX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.globaloffsetx), [**GlobalOffsetY**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.globaloffsety), and [**GlobalOffsetZ**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.globaloffsetz) properties translate the object along axes relative to the screen.</span></span> <span data-ttu-id="08650-177">つまり、ローカル オフセット プロパティとは異なり、オブジェクトが移動する軸は、オブジェクトに適用される回転に依存しません。</span><span class="sxs-lookup"><span data-stu-id="08650-177">That is, unlike the local offset properties, the axis the object moves along is independent of any rotation applied to the object.</span></span> <span data-ttu-id="08650-178">これらのプロパティは、オブジェクトに適用される回転に関係なく、単に画面の X 軸、Y 軸、Z 軸に沿ってオブジェクトを移動する場合に便利です。</span><span class="sxs-lookup"><span data-stu-id="08650-178">These properties are useful when you want to simply move the object along the x-, y-, or z-axis of the screen without worrying about the rotation applied to the object.</span></span>

<span data-ttu-id="08650-179">次のサンプルでは、[**GlobalOffsetX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.globaloffsetx) を 0 から 400 まで、[**RotationY**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.rotationy) を 0 から 65°まで変化させてアニメーションを表示します。</span><span class="sxs-lookup"><span data-stu-id="08650-179">The next sample animates [**GlobalOffsetX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.globaloffsetx) from 0 to 400 and [**RotationY**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.rotationy) from 0 to 65 degrees.</span></span>

<span data-ttu-id="08650-180">このサンプルでは、オブジェクトが回転しても移動方向が変わらないことがわかります。</span><span class="sxs-lookup"><span data-stu-id="08650-180">Notice in this sample that the object does not change course as it rotates.</span></span> <span data-ttu-id="08650-181">これは、オブジェクトが回転に関係なく画面の X 軸に沿って移動しているためです。</span><span class="sxs-lookup"><span data-stu-id="08650-181">That is because the object is being moved along the x-axis of the screen without regard to its rotation.</span></span>

## <a name="positioning-an-object"></a><span data-ttu-id="08650-182">オブジェクトの配置</span><span class="sxs-lookup"><span data-stu-id="08650-182">Positioning an object</span></span>

<span data-ttu-id="08650-183">[**PlaneProjection**](https://msdn.microsoft.com/library/windows/apps/BR210192) を使って対応できる場合よりもさらに複雑な疑似 3D のシナリオに対しては、[**Matrix3DProjection**](https://msdn.microsoft.com/library/windows/apps/BR210128) 型および [**Matrix3D**](https://msdn.microsoft.com/library/windows/apps/BR243266) 型を使うことができます。</span><span class="sxs-lookup"><span data-stu-id="08650-183">You can use the [**Matrix3DProjection**](https://msdn.microsoft.com/library/windows/apps/BR210128) and [**Matrix3D**](https://msdn.microsoft.com/library/windows/apps/BR243266) types for more complex semi-3D scenarios than are possible with the [**PlaneProjection**](https://msdn.microsoft.com/library/windows/apps/BR210192).</span></span> <span data-ttu-id="08650-184">**Matrix3DProjection** には、どの [**UIElement**](https://msdn.microsoft.com/library/windows/apps/BR208911) にも適用できる完全な 3D 変換マトリックスが備えられているため、任意のモデル変換マトリックスおよび視点マトリックスを要素に適用できます。</span><span class="sxs-lookup"><span data-stu-id="08650-184">**Matrix3DProjection** provides you with a complete 3D transform matrix to apply to any [**UIElement**](https://msdn.microsoft.com/library/windows/apps/BR208911), so that you can apply arbitrary model transformation matrices and perspective matrices to elements.</span></span> <span data-ttu-id="08650-185">これらの API は最小限のものであるため、使用する場合は、3D 変換マトリックスを正しく作成するコードを記述する必要があります。</span><span class="sxs-lookup"><span data-stu-id="08650-185">Keep in mind that these API are minimal and therefore if you use them, you will need to write the code that correctly creates the 3D transform matrices.</span></span> <span data-ttu-id="08650-186">そのため、単純な 3D シナリオには、**PlaneProjection** を使う方が簡単です。</span><span class="sxs-lookup"><span data-stu-id="08650-186">Because of this, it is easier to use **PlaneProjection** for simple 3D scenarios.</span></span>
