---
author: normesta
title: "関心のあるポイント (POI) の地図への表示"
description: "プッシュピン、画像、図形、XAML UI 要素を使って、関心のあるポイント (POI) を地図に追加します。"
ms.assetid: CA00D8EB-6C1B-4536-8921-5EAEB9B04FCA
ms.author: normesta
ms.date: 08/02/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, 地図, 位置情報, プッシュピン"
ms.openlocfilehash: 280a651df949018dc9cf490e14d72d167fee0858
ms.sourcegitcommit: 0ebc8dca2fd9149ea163b7db9daa14520fc41db4
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/08/2017
---
# <a name="display-points-of-interest-poi-on-a-map"></a><span data-ttu-id="cdc15-104">関心のあるポイント (POI) の地図への表示</span><span class="sxs-lookup"><span data-stu-id="cdc15-104">Display points of interest (POI) on a map</span></span>


<span data-ttu-id="cdc15-105">\[Windows 10 の UWP アプリ向けに更新。</span><span class="sxs-lookup"><span data-stu-id="cdc15-105">\[ Updated for UWP apps on Windows 10.</span></span> <span data-ttu-id="cdc15-106">Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください \]</span><span class="sxs-lookup"><span data-stu-id="cdc15-106">For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]</span></span>


<span data-ttu-id="cdc15-107">プッシュピン、画像、図形、XAML UI 要素を使って、関心のあるポイント (POI) を地図に追加します。</span><span class="sxs-lookup"><span data-stu-id="cdc15-107">Add points of interest (POI) to a map using pushpins, images, shapes, and XAML UI elements.</span></span> <span data-ttu-id="cdc15-108">POI は、地図上の特定のポイントであり、関心のあるものを表します。</span><span class="sxs-lookup"><span data-stu-id="cdc15-108">A POI is a specific point on the map that represents something of interest.</span></span> <span data-ttu-id="cdc15-109">たとえば、企業、市区町村、友人の所在地を示すことができます。</span><span class="sxs-lookup"><span data-stu-id="cdc15-109">For example, the location of a business, city, or friend.</span></span>

<span data-ttu-id="cdc15-110">**ヒント** アプリで POI を表示する方法について詳しくは、GitHub の [Windows-universal-samples リポジトリ](http://go.microsoft.com/fwlink/p/?LinkId=619979)から次のサンプルをダウンロードしてください。</span><span class="sxs-lookup"><span data-stu-id="cdc15-110">**Tip** To learn more about displaying POI on your app, download the following sample from the [Windows-universal-samples repo](http://go.microsoft.com/fwlink/p/?LinkId=619979) on GitHub.</span></span>

-   [<span data-ttu-id="cdc15-111">ユニバーサル Windows プラットフォーム (UWP) の地図サンプル</span><span class="sxs-lookup"><span data-stu-id="cdc15-111">Universal Windows Platform (UWP) map sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkId=619977)

<span data-ttu-id="cdc15-112">地図にプッシュピン、画像、図形を表示するには、[**MapIcon**](https://msdn.microsoft.com/library/windows/apps/dn637077) オブジェクト、[**MapPolygon**](https://msdn.microsoft.com/library/windows/apps/dn637103) オブジェクト、[**MapPolyline**](https://msdn.microsoft.com/library/windows/apps/dn637114) オブジェクトをマップ コントロールの [**MapElements**](https://msdn.microsoft.com/library/windows/apps/dn637033) コレクションに追加します。</span><span class="sxs-lookup"><span data-stu-id="cdc15-112">Display pushpins, images, and shapes on the map by adding [**MapIcon**](https://msdn.microsoft.com/library/windows/apps/dn637077), [**MapPolygon**](https://msdn.microsoft.com/library/windows/apps/dn637103), and [**MapPolyline**](https://msdn.microsoft.com/library/windows/apps/dn637114) objects to the [**MapElements**](https://msdn.microsoft.com/library/windows/apps/dn637033) collection of the map control.</span></span> <span data-ttu-id="cdc15-113">プログラムでデータ バインディングを使うか、項目を追加します。XAML マークアップで宣言を使って **MapElements** コレクションにバインドすることはできません。</span><span class="sxs-lookup"><span data-stu-id="cdc15-113">Use data binding or add items programmatically; you can't bind to the **MapElements** collection declaratively in your XAML markup.</span></span>

<span data-ttu-id="cdc15-114">XAML ユーザー インターフェイス要素 ([**Button**](https://msdn.microsoft.com/library/windows/apps/br209265)、[**HyperlinkButton**](https://msdn.microsoft.com/library/windows/apps/br242739)、[**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652) など) を地図に表示するには、それらの要素を [**MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004) の [**Children**](https://msdn.microsoft.com/library/windows/apps/dn637008) として追加します。</span><span class="sxs-lookup"><span data-stu-id="cdc15-114">Display XAML user interface elements such as a [**Button**](https://msdn.microsoft.com/library/windows/apps/br209265), a [**HyperlinkButton**](https://msdn.microsoft.com/library/windows/apps/br242739), or a [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652) on the map by adding them as [**Children**](https://msdn.microsoft.com/library/windows/apps/dn637008) of the [**MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004).</span></span> <span data-ttu-id="cdc15-115">また、それらの要素を [**MapItemsControl**](https://msdn.microsoft.com/library/windows/apps/dn637094) に追加したり、**MapItemsControl** を項目や項目のコレクションにバインドしたりすることもできます。</span><span class="sxs-lookup"><span data-stu-id="cdc15-115">You can also add them to the [**MapItemsControl**](https://msdn.microsoft.com/library/windows/apps/dn637094), or bind the **MapItemsControl** to a collection of items.</span></span>

<span data-ttu-id="cdc15-116">以上の説明をまとめると次のようになります。</span><span class="sxs-lookup"><span data-stu-id="cdc15-116">In summary:</span></span>

-   <span data-ttu-id="cdc15-117">
              プッシュピンなどの画像をオプションのテキストと共に表示するには、[MapIcon を地図に追加](#mapicon)</span><span class="sxs-lookup"><span data-stu-id="cdc15-117">[Add a MapIcon to the map](#mapicon) to display an image such as a pushpin with optional text.</span></span>
-   <span data-ttu-id="cdc15-118">
              マルチポイント図形を表示するには、[MapPolygon を地図に追加](#mappolygon)</span><span class="sxs-lookup"><span data-stu-id="cdc15-118">[Add a MapPolygon to the map](#mappolygon) to display a multi-point shape.</span></span>
-   <span data-ttu-id="cdc15-119">
              地図に線を表示するには、[MapPolyline を地図に追加](#mappolyline)</span><span class="sxs-lookup"><span data-stu-id="cdc15-119">[Add a MapPolyline to the map](#mappolyline) to display lines on the map.</span></span>
-   <span data-ttu-id="cdc15-120">
              カスタム UI 要素を表示するには、[XAML を地図に追加](#mapxaml)</span><span class="sxs-lookup"><span data-stu-id="cdc15-120">[Add XAML to the map](#mapxaml) to display custom UI elements.</span></span>

<span data-ttu-id="cdc15-121">地図に配置する要素の数が多い場合、[地図にタイル画像をオーバーレイする](overlay-tiled-images.md)ことを検討します。</span><span class="sxs-lookup"><span data-stu-id="cdc15-121">If you have a large number of elements to place on the map, consider [overlaying tiled images on the map](overlay-tiled-images.md).</span></span> <span data-ttu-id="cdc15-122">地図に道路情報を表示するには、「[ルートとルート案内の表示](routes-and-directions.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="cdc15-122">To display roads on the map, see [Display routes and directions](routes-and-directions.md).</span></span>

## <a name="add-a-mapicon"></a><span data-ttu-id="cdc15-123">MapIcon の追加</span><span class="sxs-lookup"><span data-stu-id="cdc15-123">Add a MapIcon</span></span>


<span data-ttu-id="cdc15-124">[**MapIcon**](https://msdn.microsoft.com/library/windows/apps/dn637077) クラスを使って、プッシュピンなどの画像をオプションのテキストと共に地図に表示します。</span><span class="sxs-lookup"><span data-stu-id="cdc15-124">Display an image such a pushpin, with optional text, on the map by using the [**MapIcon**](https://msdn.microsoft.com/library/windows/apps/dn637077) class.</span></span> <span data-ttu-id="cdc15-125">既定の画像をそのまま使うか、[**Image**](https://msdn.microsoft.com/library/windows/apps/dn637078) プロパティを使ってカスタム画像を指定できます。</span><span class="sxs-lookup"><span data-stu-id="cdc15-125">You can accept the default image or provide a custom image by using the [**Image**](https://msdn.microsoft.com/library/windows/apps/dn637078) property.</span></span> <span data-ttu-id="cdc15-126">次の画像はそれぞれ、[**Title**](https://msdn.microsoft.com/library/windows/apps/dn637088) プロパティに値を指定しない、短いタイトル、長いタイトル、非常に長いタイトルを指定した場合の **MapIcon** の既定の画像です。</span><span class="sxs-lookup"><span data-stu-id="cdc15-126">The following image displays the default image for a **MapIcon** with no value specified for the [**Title**](https://msdn.microsoft.com/library/windows/apps/dn637088) property, with a short title, with a long title, and with a very long title.</span></span>

![さまざまな長さのタイトルを含むサンプルの MapIcon。](images/mapctrl-mapicons.png)

<span data-ttu-id="cdc15-128">次の例では、シアトル市の地図を表示して、既定の画像とオプションのタイトルを使って [**MapIcon**](https://msdn.microsoft.com/library/windows/apps/dn637077) を追加し、スペース ニードルの場所を示しています。</span><span class="sxs-lookup"><span data-stu-id="cdc15-128">The following example shows a map of the city of Seattle and adds a [**MapIcon**](https://msdn.microsoft.com/library/windows/apps/dn637077) with the default image and an optional title to indicate the location of the Space Needle.</span></span> <span data-ttu-id="cdc15-129">また、アイコンを地図の中央に配置し、拡大しています。</span><span class="sxs-lookup"><span data-stu-id="cdc15-129">It also centers the map over the icon and zooms in.</span></span> <span data-ttu-id="cdc15-130">マップ コントロールを使用する方法に関する一般的な情報については、「[2D、3D、Streetside ビューでの地図の表示](display-maps.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="cdc15-130">For general info about using the map control, see [Display maps with 2D, 3D, and Streetside views](display-maps.md).</span></span>

```csharp
      private void displayPOIButton_Click(object sender, RoutedEventArgs e)
      {
         // Specify a known location.
         BasicGeoposition snPosition = new BasicGeoposition() { Latitude = 47.620, Longitude = -122.349 };
         Geopoint snPoint = new Geopoint(snPosition);

         // Create a MapIcon.
         var mapIcon1 = new MapIcon
         {
             Location = snPoint,
             NormalizedAnchorPoint = new Point(0.5, 1.0),
             Title = "Space Needle",
             ZIndex = 0,
         };

         // Add the MapIcon to the map.
         myMap.MapElements.Add(mapIcon1);

         // Center the map over the POI.
         myMap.Center = snPoint;
         myMap.ZoomLevel = 14;
      }
```

<span data-ttu-id="cdc15-131">この例では、次の POI (中央の既定の画像) が地図に表示されます。</span><span class="sxs-lookup"><span data-stu-id="cdc15-131">This example displays the following POI on the map (the default image in the center).</span></span>

![MapIcon を使った地図](images/displaypoidefault.png)

<span data-ttu-id="cdc15-133">次のコード行では、プロジェクトの Assets フォルダーに保存されているカスタム イメージを使って [**MapIcon**](https://msdn.microsoft.com/library/windows/apps/dn637077) が表示されます。</span><span class="sxs-lookup"><span data-stu-id="cdc15-133">The following line of code displays the [**MapIcon**](https://msdn.microsoft.com/library/windows/apps/dn637077) with a custom image saved in the Assets folder of the project.</span></span> <span data-ttu-id="cdc15-134">**MapIcon** の [**Image**](https://msdn.microsoft.com/library/windows/apps/dn637078) プロパティでは、[**RandomAccessStreamReference**](https://msdn.microsoft.com/library/windows/apps/hh701813) 型の値が想定されています。</span><span class="sxs-lookup"><span data-stu-id="cdc15-134">The [**Image**](https://msdn.microsoft.com/library/windows/apps/dn637078) property of the **MapIcon** expects a value of type [**RandomAccessStreamReference**](https://msdn.microsoft.com/library/windows/apps/hh701813).</span></span> <span data-ttu-id="cdc15-135">この型では、[**Windows.Storage.Streams**](https://msdn.microsoft.com/library/windows/apps/br241791) 名前空間用に **using** ステートメントが必要になります。</span><span class="sxs-lookup"><span data-stu-id="cdc15-135">This type requires a **using** statement for the [**Windows.Storage.Streams**](https://msdn.microsoft.com/library/windows/apps/br241791) namespace.</span></span>

<span data-ttu-id="cdc15-136">**ヒント** 複数の地図アイコンに同じ画像を使う場合は、パフォーマンスが最大限に高まるように、ページ レベルまたはアプリ レベルで [**RandomAccessStreamReference**](https://msdn.microsoft.com/library/windows/apps/hh701813) を宣言します。</span><span class="sxs-lookup"><span data-stu-id="cdc15-136">**Tip** If you use the same image for multiple map icons, declare the [**RandomAccessStreamReference**](https://msdn.microsoft.com/library/windows/apps/hh701813) at the page or app level for the best performance.</span></span>

```csharp
    MapIcon1.Image =
        RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/customicon.png"));
```

<span data-ttu-id="cdc15-137">[**MapIcon**](https://msdn.microsoft.com/library/windows/apps/dn637077) クラスを使うときは、次の考慮事項を念頭に置いてください。</span><span class="sxs-lookup"><span data-stu-id="cdc15-137">Keep these considerations in mind when working with the [**MapIcon**](https://msdn.microsoft.com/library/windows/apps/dn637077) class:</span></span>

-   <span data-ttu-id="cdc15-138">[**Image**](https://msdn.microsoft.com/library/windows/apps/dn637078) プロパティがサポートしている最大画像サイズは 2048 × 2048 ピクセルです。</span><span class="sxs-lookup"><span data-stu-id="cdc15-138">The [**Image**](https://msdn.microsoft.com/library/windows/apps/dn637078) property supports a maximum image size of 2048×2048 pixels.</span></span>
-   <span data-ttu-id="cdc15-139">既定では、地図アイコンの画像は必ず表示されるとは限りません。</span><span class="sxs-lookup"><span data-stu-id="cdc15-139">By default, the map icon's image is not guaranteed to be shown.</span></span> <span data-ttu-id="cdc15-140">このクラスが地図上の他の要素やラベルを覆い隠す場合には、このクラスは非表示になることがあります。</span><span class="sxs-lookup"><span data-stu-id="cdc15-140">It may be hidden when it obscures other elements or labels on the map.</span></span> <span data-ttu-id="cdc15-141">地図アイコンを表示したままにするには、このアイコンの [**CollisionBehaviorDesired**](https://msdn.microsoft.com/library/windows/apps/dn974327) プロパティを [**MapElementCollisionBehavior.RemainVisible**](https://msdn.microsoft.com/library/windows/apps/dn974314) に設定します。</span><span class="sxs-lookup"><span data-stu-id="cdc15-141">To keep it visible, set the map icon's [**CollisionBehaviorDesired**](https://msdn.microsoft.com/library/windows/apps/dn974327) property to [**MapElementCollisionBehavior.RemainVisible**](https://msdn.microsoft.com/library/windows/apps/dn974314).</span></span>
-   <span data-ttu-id="cdc15-142">[**MapIcon**](https://msdn.microsoft.com/library/windows/apps/dn637077) のオプションの [**Title**](https://msdn.microsoft.com/library/windows/apps/dn637088) は、必ず表示されるとは限りません。</span><span class="sxs-lookup"><span data-stu-id="cdc15-142">The optional [**Title**](https://msdn.microsoft.com/library/windows/apps/dn637088) of the [**MapIcon**](https://msdn.microsoft.com/library/windows/apps/dn637077) is not guaranteed to be shown.</span></span> <span data-ttu-id="cdc15-143">テキストが表示されない場合は、[**MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004) の [**ZoomLevel**](https://msdn.microsoft.com/library/windows/apps/dn637068) プロパティの値を減らして、地図を縮小してください。</span><span class="sxs-lookup"><span data-stu-id="cdc15-143">If you don't see the text, zoom out by decreasing the value of the [**ZoomLevel**](https://msdn.microsoft.com/library/windows/apps/dn637068) property of the [**MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004).</span></span>
-   <span data-ttu-id="cdc15-144">地図上の特定の場所を指す [**MapIcon**](https://msdn.microsoft.com/library/windows/apps/dn637077) 画像 (たとえば、プッシュピンや矢印など) を表示する場合は、[**NormalizedAnchorPoint**](https://msdn.microsoft.com/library/windows/apps/dn637082) プロパティの値を画像上にあるポインターのおおよその位置に設定することを検討してください。</span><span class="sxs-lookup"><span data-stu-id="cdc15-144">When you display a [**MapIcon**](https://msdn.microsoft.com/library/windows/apps/dn637077) image that points to a specific location on the map - for example, a pushpin or an arrow - consider setting the value of the [**NormalizedAnchorPoint**](https://msdn.microsoft.com/library/windows/apps/dn637082) property to the approximate location of the pointer on the image.</span></span> <span data-ttu-id="cdc15-145">**NormalizedAnchorPoint** の値を、画像の左上隅を示す既定値 (0, 0) のままにした場合、地図の [**ZoomLevel**](https://msdn.microsoft.com/library/windows/apps/dn637068) を変更すると、画像が別の場所を示した状態になる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="cdc15-145">If you leave the value of **NormalizedAnchorPoint** at its default value of (0, 0), which represents the upper left corner of the image, changes in the [**ZoomLevel**](https://msdn.microsoft.com/library/windows/apps/dn637068) of the map may leave the image pointing to a different location.</span></span>

## <a name="add-a-mapbillboard"></a><span data-ttu-id="cdc15-146">MapBillboard の追加</span><span class="sxs-lookup"><span data-stu-id="cdc15-146">Add a MapBillboard</span></span>

<span data-ttu-id="cdc15-147">レストランやランドマークの画像など、地図の場所に関連する大きな画像を表示します。</span><span class="sxs-lookup"><span data-stu-id="cdc15-147">Display large images that relate to map locations such as a picture of a restaurant or a landmark.</span></span> <span data-ttu-id="cdc15-148">ユーザーが地図を縮小すると、画像のサイズも比例的に縮小され、より広い範囲の地図を表示できるようになります。</span><span class="sxs-lookup"><span data-stu-id="cdc15-148">As users zoom out, the image will shrink proportionally in size to enable the user to view more of the map.</span></span> <span data-ttu-id="cdc15-149">これは特定の場所をマークする [**MapIcon**](https://msdn.microsoft.com/library/windows/apps/dn637077) とは少し異なります。MapIcon は小さいのが通常で、ユーザーが地図の拡大や縮小を行ってもサイズは変わりません。</span><span class="sxs-lookup"><span data-stu-id="cdc15-149">This is a bit different than a [**MapIcon**](https://msdn.microsoft.com/library/windows/apps/dn637077) which marks a specific location, is typically small, and remains the same size as users zoom in and out of a map.</span></span>

![MapBillboard 画像](images/map-billboard.png)

<span data-ttu-id="cdc15-151">次のコードは、上記の画像に表示されている [**MapBillboard**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapbillboard) を示しています。</span><span class="sxs-lookup"><span data-stu-id="cdc15-151">The following code shows the [**MapBillboard**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapbillboard) presented in the image above.</span></span>

```csharp
private void mapBillboardAddButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
{
    RandomAccessStreamReference mapBillboardStreamReference =
        RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/billboard.jpg"));

        var mapBillboard = new MapBillboard(myMap.ActualCamera)
        {
            Location = myMap.Center,
            NormalizedAnchorPoint = new Point(0.5, 1.0),
            Image = mapBillboardStreamReference
        };

        myMap.MapElements.Add(mapBillboard);
}
```
<span data-ttu-id="cdc15-152">このコードには、少し詳しく説明するに値する部分が 3 つあります。画像、リファレンス カメラ、および [**NormalizedAnchorPoint**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapbillboard#Windows_UI_Xaml_Controls_Maps_MapBillboard_NormalizedAnchorPoint) のことです。</span><span class="sxs-lookup"><span data-stu-id="cdc15-152">There's three parts of this code worth examining a little closer: The image, the reference camera, and the [**NormalizedAnchorPoint**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapbillboard#Windows_UI_Xaml_Controls_Maps_MapBillboard_NormalizedAnchorPoint) property.</span></span>

### <a name="image"></a><span data-ttu-id="cdc15-153">画像</span><span class="sxs-lookup"><span data-stu-id="cdc15-153">Image</span></span>

<span data-ttu-id="cdc15-154">この例は、プロジェクトの **Assets** フォルダーに保存されたカスタム画像を示しています。</span><span class="sxs-lookup"><span data-stu-id="cdc15-154">This example shows a custom image saved in the **Assets** folder of the project.</span></span> <span data-ttu-id="cdc15-155">[**MapBillboard**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapbillboard) の [**Image**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapbillboard#Windows_UI_Xaml_Controls_Maps_MapBillboard_Image) プロパティでは、[**RandomAccessStreamReference**](https://msdn.microsoft.com/library/windows/apps/hh701813) 型の値が想定されています。</span><span class="sxs-lookup"><span data-stu-id="cdc15-155">The [**Image**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapbillboard#Windows_UI_Xaml_Controls_Maps_MapBillboard_Image) property of the [**MapBillboard**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapbillboard) expects a value of type [**RandomAccessStreamReference**](https://msdn.microsoft.com/library/windows/apps/hh701813).</span></span> <span data-ttu-id="cdc15-156">この型では、[**Windows.Storage.Streams**](https://msdn.microsoft.com/library/windows/apps/br241791) 名前空間用に **using** ステートメントが必要になります。</span><span class="sxs-lookup"><span data-stu-id="cdc15-156">This type requires a **using** statement for the [**Windows.Storage.Streams**](https://msdn.microsoft.com/library/windows/apps/br241791) namespace.</span></span>

>[!NOTE]
><span data-ttu-id="cdc15-157">複数の地図アイコンに同じ画像を使う場合は、パフォーマンスが最大限に高まるように、ページ レベルまたはアプリ レベルで [**RandomAccessStreamReference**](https://msdn.microsoft.com/library/windows/apps/hh701813) を宣言します。</span><span class="sxs-lookup"><span data-stu-id="cdc15-157">If you use the same image for multiple map icons, declare the [**RandomAccessStreamReference**](https://msdn.microsoft.com/library/windows/apps/hh701813) at the page or app level for the best performance.</span></span>

### <a name="reference-camera"></a><span data-ttu-id="cdc15-158">リファレンス カメラ</span><span class="sxs-lookup"><span data-stu-id="cdc15-158">Reference camera</span></span>

 <span data-ttu-id="cdc15-159">[**MapBillboard**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapbillboard) 画像は地図の [**ZoomLevel**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapcontrol#Windows_UI_Xaml_Controls_Maps_MapControl_ZoomLevel) の変更に合わせて拡大および縮小するため、その [**ZoomLevel**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapcontrol#Windows_UI_Xaml_Controls_Maps_MapControl_ZoomLevel) が標準の 1x 倍率のときに画像がどこに表示されるかを定義することが重要になります。</span><span class="sxs-lookup"><span data-stu-id="cdc15-159">Because a [**MapBillboard**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapbillboard) image scales in and out as the [**ZoomLevel**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapcontrol#Windows_UI_Xaml_Controls_Maps_MapControl_ZoomLevel) of the map changes, it's important to define where in that [**ZoomLevel**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapcontrol#Windows_UI_Xaml_Controls_Maps_MapControl_ZoomLevel) the image appears at a normal 1x scale.</span></span> <span data-ttu-id="cdc15-160">その位置は [**MapBillboard**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapbillboard) のリファレンス カメラで定義されます。リファレンス カメラを設定するには、[**MapCamera**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapcamera) オブジェクトを [**MapBillboard**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapbillboard) のコンストラクターに渡す必要があります。</span><span class="sxs-lookup"><span data-stu-id="cdc15-160">That position is defined in the reference camera of the [**MapBillboard**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapbillboard), and to set it, you'll have to pass a [**MapCamera**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapcamera) object into the constructor of the [**MapBillboard**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapbillboard).</span></span>

 <span data-ttu-id="cdc15-161">[**Geopoint**](https://docs.microsoft.com/uwp/api/windows.devices.geolocation.geopoint) で目的の位置を定義し、その [**Geopoint**](https://docs.microsoft.com/uwp/api/windows.devices.geolocation.geopoint) を使用することで、[**MapCamera**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapcamera) オブジェクトを作成できます。</span><span class="sxs-lookup"><span data-stu-id="cdc15-161">You can define the position that you want in a [**Geopoint**](https://docs.microsoft.com/uwp/api/windows.devices.geolocation.geopoint), and then use that [**Geopoint**](https://docs.microsoft.com/uwp/api/windows.devices.geolocation.geopoint) to create a [**MapCamera**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapcamera) object.</span></span>  <span data-ttu-id="cdc15-162">ただし、この例で使用している [**MapCamera**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapcamera) オブジェクトは、単純にマップ コントロールの [**ActualCamera**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapcontrol#Windows_UI_Xaml_Controls_Maps_MapControl_ActualCamera) プロパティから返されたものです。</span><span class="sxs-lookup"><span data-stu-id="cdc15-162">However, in this example, we're just using the [**MapCamera**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapcamera) object returned by the [**ActualCamera**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapcontrol#Windows_UI_Xaml_Controls_Maps_MapControl_ActualCamera) property of the map control.</span></span> <span data-ttu-id="cdc15-163">これは地図の内部カメラです。</span><span class="sxs-lookup"><span data-stu-id="cdc15-163">This is the map's internal camera.</span></span> <span data-ttu-id="cdc15-164">このカメラの現在の位置がリファレンス カメラの位置となり、1x 倍率ではこの位置に [**MapBillboard**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapbillboard) 画像が表示されます。</span><span class="sxs-lookup"><span data-stu-id="cdc15-164">The current position of that camera becomes the reference camera position; the position where the [**MapBillboard**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapbillboard) image appears at 1x scale.</span></span>

 <span data-ttu-id="cdc15-165">アプリでユーザーが地図を縮小できるようにしている場合、画像のサイズも縮小されます。これは、1x 倍率の画像はリファレンス カメラの位置で固定されたままになりますが、地図の内部カメラは高度が上がるためです。</span><span class="sxs-lookup"><span data-stu-id="cdc15-165">If your app gives users the ability to zoom out on the map, the image decreases in size because the maps internal camera is rising in altitude while the image at 1x scale remains fixed at the reference camera's position.</span></span>

### <a name="normalizedanchorpoint"></a><span data-ttu-id="cdc15-166">NormalizedAnchorPoint</span><span class="sxs-lookup"><span data-stu-id="cdc15-166">NormalizedAnchorPoint</span></span>

<span data-ttu-id="cdc15-167">[**NormalizedAnchorPoint**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapbillboard#Windows_UI_Xaml_Controls_Maps_MapBillboard_NormalizedAnchorPoint) は、[**MapBillboard**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapbillboard) の [**Location**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapbillboard#Windows_UI_Xaml_Controls_Maps_MapBillboard_Location) プロパティに固定される画像のポイントです。</span><span class="sxs-lookup"><span data-stu-id="cdc15-167">The [**NormalizedAnchorPoint**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapbillboard#Windows_UI_Xaml_Controls_Maps_MapBillboard_NormalizedAnchorPoint) is the point of the image that is anchored to the [**Location**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapbillboard#Windows_UI_Xaml_Controls_Maps_MapBillboard_Location) property of the [**MapBillboard**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapbillboard).</span></span> <span data-ttu-id="cdc15-168">ポイント 0.5,1 は画像の下部中央になります。</span><span class="sxs-lookup"><span data-stu-id="cdc15-168">The point 0.5,1 is the bottom center of the image.</span></span> <span data-ttu-id="cdc15-169">[**MapBillboard**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapbillboard) の [**Location**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapbillboard#Windows_UI_Xaml_Controls_Maps_MapBillboard_Location) プロパティをマップ コントロールの中央に設定しているので、画像の下部中央がマップ コントロールの中央に固定されることになります。</span><span class="sxs-lookup"><span data-stu-id="cdc15-169">Because we've set the [**Location**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapbillboard#Windows_UI_Xaml_Controls_Maps_MapBillboard_Location) property of the [**MapBillboard**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapbillboard) to the center of the map's control, the bottom center of the image will be anchored at the center of the maps control.</span></span>

## <a name="add-a-mappolygon"></a><span data-ttu-id="cdc15-170">MapPolygon の追加</span><span class="sxs-lookup"><span data-stu-id="cdc15-170">Add a MapPolygon</span></span>

<span data-ttu-id="cdc15-171">[**MapPolygon**](https://msdn.microsoft.com/library/windows/apps/dn637103) クラスを使って、マルチポイント図形を地図に表示します。</span><span class="sxs-lookup"><span data-stu-id="cdc15-171">Display a multi-point shape on the map by using the [**MapPolygon**](https://msdn.microsoft.com/library/windows/apps/dn637103) class.</span></span> <span data-ttu-id="cdc15-172">次の例は、[UWP の地図サンプル](http://go.microsoft.com/fwlink/p/?LinkId=619977)から抜粋したもので、地図に赤色のボックス (境界線は青色) を表示します。</span><span class="sxs-lookup"><span data-stu-id="cdc15-172">The following example, from the [UWP map sample](http://go.microsoft.com/fwlink/p/?LinkId=619977), displays a red box with blue border on the map.</span></span>

```csharp
private void mapPolygonAddButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
{
    double centerLatitude = myMap.Center.Position.Latitude;
    double centerLongitude = myMap.Center.Position.Longitude;

    var mapPolygon = new MapPolygon()
    {
        Path = new Geopath(new List<BasicGeoposition>() {
        new BasicGeoposition() {Latitude=centerLatitude+0.0005, Longitude=centerLongitude-0.001 },
        new BasicGeoposition() {Latitude=centerLatitude-0.0005, Longitude=centerLongitude-0.001 },
        new BasicGeoposition() {Latitude=centerLatitude-0.0005, Longitude=centerLongitude+0.001 },
        new BasicGeoposition() {Latitude=centerLatitude+0.0005, Longitude=centerLongitude+0.001 },
        }),
        ZIndex = 1,
        FillColor = Colors.Red,
        StrokeColor = Colors.Blue,
        StrokeThickness = 3,
        StrokeDashed = false,
    };

    myMap.MapElements.Add(mapPolygon);
}
```

## <a name="add-a-mappolyline"></a><span data-ttu-id="cdc15-173">MapPolyline の追加</span><span class="sxs-lookup"><span data-stu-id="cdc15-173">Add a MapPolyline</span></span>


<span data-ttu-id="cdc15-174">[**MapPolyline**](https://msdn.microsoft.com/library/windows/apps/dn637114) クラスを使って、線を地図に表示します。</span><span class="sxs-lookup"><span data-stu-id="cdc15-174">Display a line on the map by using the [**MapPolyline**](https://msdn.microsoft.com/library/windows/apps/dn637114) class.</span></span> <span data-ttu-id="cdc15-175">次の例は、[UWP の地図サンプル](http://go.microsoft.com/fwlink/p/?LinkId=619977)から抜粋したもので、地図に破線を表示します。</span><span class="sxs-lookup"><span data-stu-id="cdc15-175">The following example, from the [UWP map sample](http://go.microsoft.com/fwlink/p/?LinkId=619977), displays a dashed line on the map.</span></span>

```csharp
private void mapPolylineAddButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
{
    double centerLatitude = myMap.Center.Position.Latitude;
    double centerLongitude = myMap.Center.Position.Longitude;
    var mapPolyline = new MapPolyline
    {
        Path = new Geopath(new List<BasicGeoposition>() {
            new BasicGeoposition() {Latitude=centerLatitude-0.0005, Longitude=centerLongitude-0.001 },
            new BasicGeoposition() {Latitude=centerLatitude+0.0005, Longitude=centerLongitude+0.001 },
        }),
        StrokeColor = Colors.Black,
        StrokeThickness = 3,
        StrokeDashed = true,
    };

    myMap.MapElements.Add(mapPolyline);
}
```

## <a name="add-xaml"></a><span data-ttu-id="cdc15-176">XAML の追加</span><span class="sxs-lookup"><span data-stu-id="cdc15-176">Add XAML</span></span>

<span data-ttu-id="cdc15-177">XAML を使って、カスタム UI 要素を地図に表示します。</span><span class="sxs-lookup"><span data-stu-id="cdc15-177">Display custom UI elements on the map using XAML.</span></span> <span data-ttu-id="cdc15-178">XAML を地図に配置するには、XAML の位置と正規化されたアンカー ポイントを指定します。</span><span class="sxs-lookup"><span data-stu-id="cdc15-178">Position XAML on the map by specifying the location and normalized anchor point of the XAML.</span></span>

-   <span data-ttu-id="cdc15-179">[**SetLocation**](https://msdn.microsoft.com/library/windows/desktop/ms704369) を呼び出して、XAML を地図に配置する位置を設定します。</span><span class="sxs-lookup"><span data-stu-id="cdc15-179">Set the location on the map where the XAML is placed by calling [**SetLocation**](https://msdn.microsoft.com/library/windows/desktop/ms704369).</span></span>
-   <span data-ttu-id="cdc15-180">[**SetNormalizedAnchorPoint**](https://msdn.microsoft.com/library/windows/apps/dn637050) を呼び出して、指定した位置に対応する XAML 上の相対位置を設定します。</span><span class="sxs-lookup"><span data-stu-id="cdc15-180">Set the relative location on the XAML that corresponds to the specified location by calling [**SetNormalizedAnchorPoint**](https://msdn.microsoft.com/library/windows/apps/dn637050).</span></span>

<span data-ttu-id="cdc15-181">次の例では、シアトル市の地図を表示して、XAML の [**Border**](https://msdn.microsoft.com/library/windows/apps/br209250) コントロールを追加し、スペース ニードルの場所を示しています。</span><span class="sxs-lookup"><span data-stu-id="cdc15-181">The following example shows a map of the city of Seattle and adds a XAML [**Border**](https://msdn.microsoft.com/library/windows/apps/br209250) control to indicate the location of the Space Needle.</span></span> <span data-ttu-id="cdc15-182">また、そのエリアを地図の中央に配置し、拡大しています。</span><span class="sxs-lookup"><span data-stu-id="cdc15-182">It also centers the map over the area and zooms in.</span></span> <span data-ttu-id="cdc15-183">マップ コントロールを使用する方法に関する一般的な情報については、「 [2D、3D、Streetside ビューでの地図の表示](display-maps.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="cdc15-183">For general info about using the map control, see [Display maps with 2D, 3D, and Streetside views](display-maps.md).</span></span>

```csharp
private void displayXAMLButton_Click(object sender, RoutedEventArgs e)
{
   // Specify a known location.
   BasicGeoposition snPosition = new BasicGeoposition() { Latitude = 47.620, Longitude = -122.349 };
   Geopoint snPoint = new Geopoint(snPosition);

   // Create a XAML border.
   Border border = new Border
   {
      Height = 100,
      Width = 100,
      BorderBrush = new SolidColorBrush(Windows.UI.Colors.Blue),
      BorderThickness = new Thickness(5),
   };

   // Center the map over the POI.
   MapControl1.Center = snPoint;
   MapControl1.ZoomLevel = 14;

   // Add XAML to the map.
   MapControl1.Children.Add(border);
   MapControl.SetLocation(border, snPoint);
   MapControl.SetNormalizedAnchorPoint(border, new Point(0.5, 0.5));
}
```

<span data-ttu-id="cdc15-184">この例では、地図に青色の境界線が表示されます。</span><span class="sxs-lookup"><span data-stu-id="cdc15-184">This example displays a blue border on the map.</span></span>

![地図上の関心がある場所に表示された xaml のスクリーンショット](images/displaypoixaml.png)

<span data-ttu-id="cdc15-186">次の例では、データ バインディングを使って、ページの XAML マークアップで XAML UI 要素を直接追加する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="cdc15-186">The next examples show how to add XAML UI elements directly in the XAML markup of the page using data binding.</span></span> <span data-ttu-id="cdc15-187">コンテンツを表示する他の XAML 要素と同様に、[**Children**](https://msdn.microsoft.com/library/windows/apps/dn637008) は [**MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004) の既定のコンテンツ プロパティであり、XAML マークアップで明示的に指定する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="cdc15-187">As with other XAML elements that display content, [**Children**](https://msdn.microsoft.com/library/windows/apps/dn637008) is the default content property of the [**MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004) and does not have to be specified explicitly in XAML markup.</span></span>

<span data-ttu-id="cdc15-188">次の例では、2 つの XAML コントロールを [**MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004) の暗黙的な子として表示する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="cdc15-188">This example shows how to display two XAML controls as implicit children of the [**MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004).</span></span>

```xml
<maps:MapControl>
    <TextBox Text="Seattle" maps:MapControl.Location="{Binding SeattleLocation}"/>
    <TextBox Text="Bellevue" maps:MapControl.Location="{Binding BellevueLocation}"/>
</maps:MapControl>
```

<span data-ttu-id="cdc15-189">次の例では、[**MapItemsControl**](https://msdn.microsoft.com/library/windows/apps/dn637094) に含まれている 2 つの XAML コントロールを表示する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="cdc15-189">This example shows how to display two XAML controls contained within a [**MapItemsControl**](https://msdn.microsoft.com/library/windows/apps/dn637094).</span></span>

```xml
<maps:MapControl>
  <maps:MapItemsControl>
    <TextBox Text="Seattle" maps:MapControl.Location="{Binding SeattleLocation}"/>
    <TextBox Text="Bellevue" maps:MapControl.Location="{Binding BellevueLocation}"/>
  </maps:MapItemsControl>
</maps:MapControl>
```

<span data-ttu-id="cdc15-190">次の例では、[**MapItemsControl**](https://msdn.microsoft.com/library/windows/apps/dn637094) にバインドされている XAML 要素のコレクションが表示されます。</span><span class="sxs-lookup"><span data-stu-id="cdc15-190">This example displays a collection of XAML elements bound to a [**MapItemsControl**](https://msdn.microsoft.com/library/windows/apps/dn637094).</span></span>

```xml
<maps:MapControl x:Name="MapControl" MapTapped="MapTapped" MapDoubleTapped="MapTapped" MapHolding="MapTapped">
  <maps:MapItemsControl ItemsSource="{Binding StateOverlays}">
    <maps:MapItemsControl.ItemTemplate>
      <DataTemplate>
        <StackPanel Background="Black" Tapped="Overlay_Tapped">
          <TextBlock maps:MapControl.Location="{Binding Location}" Text="{Binding Name}" maps:MapControl.NormalizedAnchorPoint="0.5,0.5" FontSize="20" Margin="5"/>
        </StackPanel>
      </DataTemplate>
    </maps:MapItemsControl.ItemTemplate>
  </maps:MapItemsControl>
</maps:MapControl>
```

## <a name="related-topics"></a><span data-ttu-id="cdc15-191">関連トピック</span><span class="sxs-lookup"><span data-stu-id="cdc15-191">Related topics</span></span>

* [<span data-ttu-id="cdc15-192">Bing Maps Developer Center</span><span class="sxs-lookup"><span data-stu-id="cdc15-192">Bing Maps Developer Center</span></span>](https://www.bingmapsportal.com/)
* [<span data-ttu-id="cdc15-193">UWP の地図サンプル</span><span class="sxs-lookup"><span data-stu-id="cdc15-193">UWP map sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkId=619977)
* [<span data-ttu-id="cdc15-194">地図の設計ガイドライン</span><span class="sxs-lookup"><span data-stu-id="cdc15-194">Design guidelines for maps</span></span>](https://msdn.microsoft.com/library/windows/apps/dn596102)
* [<span data-ttu-id="cdc15-195">Build 2015 のビデオ: Windows アプリでの電話、タブレット、PC で使用できるマップと位置情報の活用</span><span class="sxs-lookup"><span data-stu-id="cdc15-195">Build 2015 video: Leveraging Maps and Location Across Phone, Tablet, and PC in Your Windows Apps</span></span>](https://channel9.msdn.com/Events/Build/2015/2-757)
* [<span data-ttu-id="cdc15-196">UWP の交通情報アプリのサンプル</span><span class="sxs-lookup"><span data-stu-id="cdc15-196">UWP traffic app sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkId=619982)
* [**<span data-ttu-id="cdc15-197">MapIcon</span><span class="sxs-lookup"><span data-stu-id="cdc15-197">MapIcon</span></span>**](https://msdn.microsoft.com/library/windows/apps/dn637077)
* [**<span data-ttu-id="cdc15-198">MapPolygon</span><span class="sxs-lookup"><span data-stu-id="cdc15-198">MapPolygon</span></span>**](https://msdn.microsoft.com/library/windows/apps/dn637103)
* [**<span data-ttu-id="cdc15-199">MapPolyline</span><span class="sxs-lookup"><span data-stu-id="cdc15-199">MapPolyline</span></span>**](https://msdn.microsoft.com/library/windows/apps/dn637114)
