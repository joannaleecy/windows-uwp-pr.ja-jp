---
author: normesta
title: 関心のあるポイント (POI) の地図への表示
description: プッシュピン、画像、図形、XAML UI 要素を使って、関心のあるポイント (POI) を地図に追加します。
ms.assetid: CA00D8EB-6C1B-4536-8921-5EAEB9B04FCA
ms.author: normesta
ms.date: 08/11/2017
ms.topic: article
keywords: Windows 10, UWP, 地図, 位置情報, プッシュピン
ms.localizationpriority: medium
ms.openlocfilehash: 13c0ea463cbab97e03c87c4e558bba0eff92300c
ms.sourcegitcommit: 086001cffaf436e6e4324761d59bcc5e598c15ea
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5711099"
---
# <a name="display-points-of-interest-on-a-map"></a><span data-ttu-id="d711f-104">関心のあるポイントの地図への表示</span><span class="sxs-lookup"><span data-stu-id="d711f-104">Display points of interest on a map</span></span>

<span data-ttu-id="d711f-105">プッシュピン、画像、図形、XAML UI 要素を使って、関心のあるポイント (POI) を地図に追加します。</span><span class="sxs-lookup"><span data-stu-id="d711f-105">Add points of interest (POI) to a map using pushpins, images, shapes, and XAML UI elements.</span></span> <span data-ttu-id="d711f-106">POI は、地図上の特定のポイントであり、関心のあるものを表します。</span><span class="sxs-lookup"><span data-stu-id="d711f-106">A POI is a specific point on the map that represents something of interest.</span></span> <span data-ttu-id="d711f-107">たとえば、企業、市区町村、友人の所在地を示すことができます。</span><span class="sxs-lookup"><span data-stu-id="d711f-107">For example, the location of a business, city, or friend.</span></span>

<span data-ttu-id="d711f-108">アプリで POI を表示する方法について詳しくは、GitHub の [Windows-universal-samples リポジトリ](http://go.microsoft.com/fwlink/p/?LinkId=619979)から[ユニバーサル Windows プラットフォーム (UWP) の地図サンプル](http://go.microsoft.com/fwlink/p/?LinkId=619977)をダウンロードしてください。</span><span class="sxs-lookup"><span data-stu-id="d711f-108">To learn more about displaying POI on your app, download the following sample from the [Windows-universal-samples repo](http://go.microsoft.com/fwlink/p/?LinkId=619979) on GitHub: [Universal Windows Platform (UWP) map sample](http://go.microsoft.com/fwlink/p/?LinkId=619977).</span></span>

<span data-ttu-id="d711f-109">地図にプッシュピン、画像、図形を表示するには、[**MapIcon**](https://msdn.microsoft.com/library/windows/apps/dn637077)、[**MapBillboard**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapbillboard)、[**MapPolygon**](https://msdn.microsoft.com/library/windows/apps/dn637103)、[**MapPolyline**](https://msdn.microsoft.com/library/windows/apps/dn637114) の各オブジェクトを、[**MapElementsLayer**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapelementslayer) オブジェクトの **MapElements** コレクションに追加します。</span><span class="sxs-lookup"><span data-stu-id="d711f-109">Display pushpins, images, and shapes on the map by adding [**MapIcon**](https://msdn.microsoft.com/library/windows/apps/dn637077), [**MapBillboard**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapbillboard),  [**MapPolygon**](https://msdn.microsoft.com/library/windows/apps/dn637103), and [**MapPolyline**](https://msdn.microsoft.com/library/windows/apps/dn637114) objects to a **MapElements** collection of a [**MapElementsLayer**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapelementslayer) object.</span></span> <span data-ttu-id="d711f-110">次に、そのレイヤー オブジェクトをマップ コントロールの **Layers** コレクションに追加します。</span><span class="sxs-lookup"><span data-stu-id="d711f-110">Then, add that layer object to the **Layers** collection of a map control.</span></span>

>[!NOTE]
> <span data-ttu-id="d711f-111">以前のリリースでは、このガイドで、マップの要素を [**MapElements**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapcontrol.MapElements) コレクションに追加する方法を示していました。</span><span class="sxs-lookup"><span data-stu-id="d711f-111">In previous releases, this guide showed you how to add map elements to the [**MapElements**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapcontrol.MapElements) collection.</span></span> <span data-ttu-id="d711f-112">引き続き同じアプローチを使うこともできますが、その場合は新しいマップ レイヤー モデルの利点が活かされません。</span><span class="sxs-lookup"><span data-stu-id="d711f-112">While you can still use this approach, you'll miss out on some of the advantages of the new map layer model.</span></span> <span data-ttu-id="d711f-113">詳しくは、このガイドの「[レイヤーの使用](#layers)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d711f-113">To learn more, see the [Working with layers](#layers) section of this guide.</span></span>

<span data-ttu-id="d711f-114">[**Button**](https://msdn.microsoft.com/library/windows/apps/br209265)、[**HyperlinkButton**](https://msdn.microsoft.com/library/windows/apps/br242739)、[**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652) などの XAML ユーザー インターフェイス要素を地図に表示することもできます。そのためには、それらの要素を [**MapItemsControl**](https://msdn.microsoft.com/library/windows/apps/dn637094) に追加するか、[**MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004) の [**Children**](https://msdn.microsoft.com/library/windows/apps/dn637008) として追加します。</span><span class="sxs-lookup"><span data-stu-id="d711f-114">You can also display XAML user interface elements such as a [**Button**](https://msdn.microsoft.com/library/windows/apps/br209265), a [**HyperlinkButton**](https://msdn.microsoft.com/library/windows/apps/br242739), or a [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652) on the map by adding them to the [**MapItemsControl**](https://msdn.microsoft.com/library/windows/apps/dn637094) or as [**Children**](https://msdn.microsoft.com/library/windows/apps/dn637008) of the [**MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004).</span></span>

<span data-ttu-id="d711f-115">地図に配置する要素の数が多い場合、[地図にタイル画像をオーバーレイする](overlay-tiled-images.md)ことを検討します。</span><span class="sxs-lookup"><span data-stu-id="d711f-115">If you have a large number of elements to place on the map, consider [overlaying tiled images on the map](overlay-tiled-images.md).</span></span> <span data-ttu-id="d711f-116">地図に道路情報を表示するには、「[ルートとルート案内の表示](routes-and-directions.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d711f-116">To display roads on the map, see [Display routes and directions](routes-and-directions.md)</span></span>

## <a name="add-a-pushpin"></a><span data-ttu-id="d711f-117">プッシュピンの追加</span><span class="sxs-lookup"><span data-stu-id="d711f-117">Add a pushpin</span></span>

<span data-ttu-id="d711f-118">プッシュピンなどの画像をオプションのテキストと共に地図に表示するには、[**MapIcon**](https://msdn.microsoft.com/library/windows/apps/dn637077) クラスを使います。</span><span class="sxs-lookup"><span data-stu-id="d711f-118">Display an image such a pushpin, with optional text, on the map by using the [**MapIcon**](https://msdn.microsoft.com/library/windows/apps/dn637077) class.</span></span> <span data-ttu-id="d711f-119">既定の画像をそのまま使うか、[**Image**](https://msdn.microsoft.com/library/windows/apps/dn637078) プロパティを使ってカスタム画像を指定できます。</span><span class="sxs-lookup"><span data-stu-id="d711f-119">You can accept the default image or provide a custom image by using the [**Image**](https://msdn.microsoft.com/library/windows/apps/dn637078) property.</span></span> <span data-ttu-id="d711f-120">次の画像はそれぞれ、[**Title**](https://msdn.microsoft.com/library/windows/apps/dn637088) プロパティに値を指定しない、短いタイトル、長いタイトル、非常に長いタイトルを指定した場合の **MapIcon** の既定の画像です。</span><span class="sxs-lookup"><span data-stu-id="d711f-120">The following image displays the default image for a **MapIcon** with no value specified for the [**Title**](https://msdn.microsoft.com/library/windows/apps/dn637088) property, with a short title, with a long title, and with a very long title.</span></span>

![さまざまな長さのタイトルを含むサンプルの MapIcon。](images/mapctrl-mapicons.png)

<span data-ttu-id="d711f-122">次の例では、シアトル市の地図を表示して、既定の画像とオプションのタイトルを使って [**MapIcon**](https://msdn.microsoft.com/library/windows/apps/dn637077) を追加し、スペース ニードルの場所を示しています。</span><span class="sxs-lookup"><span data-stu-id="d711f-122">The following example shows a map of the city of Seattle and adds a [**MapIcon**](https://msdn.microsoft.com/library/windows/apps/dn637077) with the default image and an optional title to indicate the location of the Space Needle.</span></span> <span data-ttu-id="d711f-123">また、アイコンを地図の中央に配置し、拡大しています。</span><span class="sxs-lookup"><span data-stu-id="d711f-123">It also centers the map over the icon and zooms in.</span></span> <span data-ttu-id="d711f-124">マップ コントロールを使用する方法に関する一般的な情報については、「[2D、3D、Streetside ビューでの地図の表示](display-maps.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d711f-124">For general info about using the map control, see [Display maps with 2D, 3D, and Streetside views](display-maps.md).</span></span>

```csharp
public void AddSpaceNeedleIcon()
{
    var MyLandmarks = new List<MapElement>();

    BasicGeoposition snPosition = new BasicGeoposition { Latitude = 47.620, Longitude = -122.349 };
    Geopoint snPoint = new Geopoint(snPosition);

    var spaceNeedleIcon = new MapIcon
    {
        Location = snPoint,
        NormalizedAnchorPoint = new Point(0.5, 1.0),
        ZIndex = 0,
        Title = "Space Needle"
    };

    MyLandmarks.Add(spaceNeedleIcon);

    var LandmarksLayer = new MapElementsLayer
    {
        ZIndex = 1,
        MapElements = MyLandmarks
    };

    myMap.Layers.Add(LandmarksLayer);

    myMap.Center = snPoint;
    myMap.ZoomLevel = 14;

}
```

<span data-ttu-id="d711f-125">この例では、次の POI (中央の既定の画像) が地図に表示されます。</span><span class="sxs-lookup"><span data-stu-id="d711f-125">This example displays the following POI on the map (the default image in the center).</span></span>

![MapIcon を使った地図](images/displaypoidefault.png)

<span data-ttu-id="d711f-127">次のコード行では、プロジェクトの Assets フォルダーに保存されているカスタム イメージを使って [**MapIcon**](https://msdn.microsoft.com/library/windows/apps/dn637077) が表示されます。</span><span class="sxs-lookup"><span data-stu-id="d711f-127">The following line of code displays the [**MapIcon**](https://msdn.microsoft.com/library/windows/apps/dn637077) with a custom image saved in the Assets folder of the project.</span></span> <span data-ttu-id="d711f-128">**MapIcon** の [**Image**](https://msdn.microsoft.com/library/windows/apps/dn637078) プロパティでは、[**RandomAccessStreamReference**](https://msdn.microsoft.com/library/windows/apps/hh701813) 型の値が想定されています。</span><span class="sxs-lookup"><span data-stu-id="d711f-128">The [**Image**](https://msdn.microsoft.com/library/windows/apps/dn637078) property of the **MapIcon** expects a value of type [**RandomAccessStreamReference**](https://msdn.microsoft.com/library/windows/apps/hh701813).</span></span> <span data-ttu-id="d711f-129">この型では、[**Windows.Storage.Streams**](https://msdn.microsoft.com/library/windows/apps/br241791) 名前空間用に **using** ステートメントが必要になります。</span><span class="sxs-lookup"><span data-stu-id="d711f-129">This type requires a **using** statement for the [**Windows.Storage.Streams**](https://msdn.microsoft.com/library/windows/apps/br241791) namespace.</span></span>

>[!NOTE]
><span data-ttu-id="d711f-130">複数の地図アイコンに同じ画像を使う場合は、パフォーマンスが最大限に高まるように、ページ レベルまたはアプリ レベルで [**RandomAccessStreamReference**](https://msdn.microsoft.com/library/windows/apps/hh701813) を宣言します。</span><span class="sxs-lookup"><span data-stu-id="d711f-130">If you use the same image for multiple map icons, declare the [**RandomAccessStreamReference**](https://msdn.microsoft.com/library/windows/apps/hh701813) at the page or app level for the best performance.</span></span>

```csharp
    MapIcon1.Image =
        RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/customicon.png"));
```

<span data-ttu-id="d711f-131">[**MapIcon**](https://msdn.microsoft.com/library/windows/apps/dn637077) クラスを使うときは、次の考慮事項を念頭に置いてください。</span><span class="sxs-lookup"><span data-stu-id="d711f-131">Keep these considerations in mind when working with the [**MapIcon**](https://msdn.microsoft.com/library/windows/apps/dn637077) class:</span></span>

-   <span data-ttu-id="d711f-132">[**Image**](https://msdn.microsoft.com/library/windows/apps/dn637078) プロパティがサポートしている最大画像サイズは 2048 × 2048 ピクセルです。</span><span class="sxs-lookup"><span data-stu-id="d711f-132">The [**Image**](https://msdn.microsoft.com/library/windows/apps/dn637078) property supports a maximum image size of 2048×2048 pixels.</span></span>
-   <span data-ttu-id="d711f-133">既定では、地図アイコンの画像は必ず表示されるとは限りません。</span><span class="sxs-lookup"><span data-stu-id="d711f-133">By default, the map icon's image is not guaranteed to be shown.</span></span> <span data-ttu-id="d711f-134">このクラスが地図上の他の要素やラベルを覆い隠す場合には、このクラスは非表示になることがあります。</span><span class="sxs-lookup"><span data-stu-id="d711f-134">It may be hidden when it obscures other elements or labels on the map.</span></span> <span data-ttu-id="d711f-135">地図アイコンを表示したままにするには、このアイコンの [**CollisionBehaviorDesired**](https://msdn.microsoft.com/library/windows/apps/dn974327) プロパティを [**MapElementCollisionBehavior.RemainVisible**](https://msdn.microsoft.com/library/windows/apps/dn974314) に設定します。</span><span class="sxs-lookup"><span data-stu-id="d711f-135">To keep it visible, set the map icon's [**CollisionBehaviorDesired**](https://msdn.microsoft.com/library/windows/apps/dn974327) property to [**MapElementCollisionBehavior.RemainVisible**](https://msdn.microsoft.com/library/windows/apps/dn974314).</span></span>
-   <span data-ttu-id="d711f-136">[**MapIcon**](https://msdn.microsoft.com/library/windows/apps/dn637077) のオプションの [**Title**](https://msdn.microsoft.com/library/windows/apps/dn637088) は、必ず表示されるとは限りません。</span><span class="sxs-lookup"><span data-stu-id="d711f-136">The optional [**Title**](https://msdn.microsoft.com/library/windows/apps/dn637088) of the [**MapIcon**](https://msdn.microsoft.com/library/windows/apps/dn637077) is not guaranteed to be shown.</span></span> <span data-ttu-id="d711f-137">テキストが表示されない場合は、[**MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004) の [**ZoomLevel**](https://msdn.microsoft.com/library/windows/apps/dn637068) プロパティの値を減らして、地図を縮小してください。</span><span class="sxs-lookup"><span data-stu-id="d711f-137">If you don't see the text, zoom out by decreasing the value of the [**ZoomLevel**](https://msdn.microsoft.com/library/windows/apps/dn637068) property of the [**MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004).</span></span>
-   <span data-ttu-id="d711f-138">地図上の特定の場所を指す [**MapIcon**](https://msdn.microsoft.com/library/windows/apps/dn637077) 画像 (たとえば、プッシュピンや矢印など) を表示する場合は、[**NormalizedAnchorPoint**](https://msdn.microsoft.com/library/windows/apps/dn637082) プロパティの値を画像上にあるポインターのおおよその位置に設定することを検討してください。</span><span class="sxs-lookup"><span data-stu-id="d711f-138">When you display a [**MapIcon**](https://msdn.microsoft.com/library/windows/apps/dn637077) image that points to a specific location on the map - for example, a pushpin or an arrow - consider setting the value of the [**NormalizedAnchorPoint**](https://msdn.microsoft.com/library/windows/apps/dn637082) property to the approximate location of the pointer on the image.</span></span> <span data-ttu-id="d711f-139">**NormalizedAnchorPoint** の値を、画像の左上隅を示す既定値 (0, 0) のままにした場合、地図の [**ZoomLevel**](https://msdn.microsoft.com/library/windows/apps/dn637068) を変更すると、画像が別の場所を示した状態になる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="d711f-139">If you leave the value of **NormalizedAnchorPoint** at its default value of (0, 0), which represents the upper left corner of the image, changes in the [**ZoomLevel**](https://msdn.microsoft.com/library/windows/apps/dn637068) of the map may leave the image pointing to a different location.</span></span>
-   <span data-ttu-id="d711f-140">[Altitude](https://docs.microsoft.com/uwp/api/windows.devices.geolocation.basicgeoposition) と [AltitudeReferenceSystem](https://docs.microsoft.com/uwp/api/windows.devices.geolocation.geopoint.AltitudeReferenceSystem) を明示的に設定しない場合、[**MapIcon**](https://msdn.microsoft.com/library/windows/apps/dn637077) はサーフェスに配置されます。</span><span class="sxs-lookup"><span data-stu-id="d711f-140">If you don't explicitly set an [Altitude](https://docs.microsoft.com/uwp/api/windows.devices.geolocation.basicgeoposition) and [AltitudeReferenceSystem](https://docs.microsoft.com/uwp/api/windows.devices.geolocation.geopoint.AltitudeReferenceSystem), the [**MapIcon**](https://msdn.microsoft.com/library/windows/apps/dn637077) will be placed on the surface.</span></span>

## <a name="add-a-3d-pushpin"></a><span data-ttu-id="d711f-141">3D プッシュピンの追加</span><span class="sxs-lookup"><span data-stu-id="d711f-141">Add a 3D pushpin</span></span>

<span data-ttu-id="d711f-142">3 次元オブジェクトをマップに追加できます。</span><span class="sxs-lookup"><span data-stu-id="d711f-142">You can add three-dimensional objects to a map.</span></span> <span data-ttu-id="d711f-143">[MapModel3D](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapmodel3d) クラスを使って、[3D Manufacturing Format (3MF)](http://3mf.io/specification/) ファイルから 3D オブジェクトをインポートします。</span><span class="sxs-lookup"><span data-stu-id="d711f-143">Use the [MapModel3D](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapmodel3d) class to import a 3D object from a [3D Manufacturing Format (3MF)](http://3mf.io/specification/) file.</span></span>

<span data-ttu-id="d711f-144">次の画像では、3D のコーヒー カップを使って、付近の喫茶店の場所を示しています。</span><span class="sxs-lookup"><span data-stu-id="d711f-144">This image uses 3D coffee cups to mark the locations of coffee shops in a neighborhood.</span></span>

![地図上のマグ](images/mugs.png)

<span data-ttu-id="d711f-146">次のコードでは、3MF ファイルのインポートを使って、地図にコーヒー カップを追加します。</span><span class="sxs-lookup"><span data-stu-id="d711f-146">The following code adds a coffee cup to the map by using importing a 3MF file.</span></span> <span data-ttu-id="d711f-147">シンプルにするために、このコードでは地図の中央に画像を追加していますが、実際のコードでは通常、特定の場所に画像を追加することになります。</span><span class="sxs-lookup"><span data-stu-id="d711f-147">To keep things simple, this code adds the image to the center of the map, but your code would likely add the image to a specific location.</span></span>

```csharp
public async void Add3DMapModel()
{
    var mugStreamReference = RandomAccessStreamReference.CreateFromUri
        (new Uri("ms-appx:///Assets/mug.3mf"));

    var myModel = await MapModel3D.CreateFrom3MFAsync(mugStreamReference,
        MapModel3DShadingOption.Smooth);

    myMap.Layers.Add(new MapElementsLayer
    {
       ZIndex = 1,
       MapElements = new List<MapElement>
       {
          new MapElement3D
          {
              Location = myMap.Center,
              Model = myModel,
          },
       },
    });
}
```

## <a name="add-an-image"></a><span data-ttu-id="d711f-148">画像の追加</span><span class="sxs-lookup"><span data-stu-id="d711f-148">Add an image</span></span>

<span data-ttu-id="d711f-149">レストランやランドマークの画像など、地図の場所に関連する大きい画像を表示します。</span><span class="sxs-lookup"><span data-stu-id="d711f-149">Display large images that relate to map locations such as a picture of a restaurant or a landmark.</span></span> <span data-ttu-id="d711f-150">ユーザーが地図を縮小すると、画像のサイズも比例的に縮小され、より広い範囲の地図を表示できるようになります。</span><span class="sxs-lookup"><span data-stu-id="d711f-150">As users zoom out, the image will shrink proportionally in size to enable the user to view more of the map.</span></span> <span data-ttu-id="d711f-151">これは特定の場所をマークする [**MapIcon**](https://msdn.microsoft.com/library/windows/apps/dn637077) とは少し異なります。MapIcon は小さいのが通常で、ユーザーが地図の拡大や縮小を行ってもサイズは変わりません。</span><span class="sxs-lookup"><span data-stu-id="d711f-151">This is a bit different than a [**MapIcon**](https://msdn.microsoft.com/library/windows/apps/dn637077) which marks a specific location, is typically small, and remains the same size as users zoom in and out of a map.</span></span>

![MapBillboard 画像](images/map-billboard.png)

<span data-ttu-id="d711f-153">次のコードは、上記の画像に表示されている [**MapBillboard**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapbillboard) を示しています。</span><span class="sxs-lookup"><span data-stu-id="d711f-153">The following code shows the [**MapBillboard**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapbillboard) presented in the image above.</span></span>

```csharp
public void AddLandmarkPhoto()
{
    // Create MapBillboard.

    RandomAccessStreamReference mapBillboardStreamReference =
        RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/billboard.jpg"));

    var mapBillboard = new MapBillboard(myMap.ActualCamera)
    {
        Location = myMap.Center,
        NormalizedAnchorPoint = new Point(0.5, 1.0),
        Image = mapBillboardStreamReference
    };

    // Add MapBillboard to a layer on the map control.

    var MyLandmarkPhotos = new List<MapElement>();

    MyLandmarkPhotos.Add(mapBillboard);

    var LandmarksPhotoLayer = new MapElementsLayer
    {
        ZIndex = 1,
        MapElements = MyLandmarkPhotos
    };

    myMap.Layers.Add(LandmarksPhotoLayer);
}
```

<span data-ttu-id="d711f-154">このコードには、少し詳しく説明するに値する部分が 3 つあります。画像、リファレンス カメラ、および [**NormalizedAnchorPoint**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapbillboard.NormalizedAnchorPoint) のことです。</span><span class="sxs-lookup"><span data-stu-id="d711f-154">There's three parts of this code worth examining a little closer: The image, the reference camera, and the [**NormalizedAnchorPoint**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapbillboard.NormalizedAnchorPoint) property.</span></span>

### <a name="image"></a><span data-ttu-id="d711f-155">画像</span><span class="sxs-lookup"><span data-stu-id="d711f-155">Image</span></span>

<span data-ttu-id="d711f-156">この例は、プロジェクトの **Assets** フォルダーに保存されたカスタム画像を示しています。</span><span class="sxs-lookup"><span data-stu-id="d711f-156">This example shows a custom image saved in the **Assets** folder of the project.</span></span> <span data-ttu-id="d711f-157">[**MapBillboard**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapbillboard) の [**Image**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapbillboard.Image) プロパティでは、[**RandomAccessStreamReference**](https://msdn.microsoft.com/library/windows/apps/hh701813) 型の値が想定されています。</span><span class="sxs-lookup"><span data-stu-id="d711f-157">The [**Image**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapbillboard.Image) property of the [**MapBillboard**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapbillboard) expects a value of type [**RandomAccessStreamReference**](https://msdn.microsoft.com/library/windows/apps/hh701813).</span></span> <span data-ttu-id="d711f-158">この型では、[**Windows.Storage.Streams**](https://msdn.microsoft.com/library/windows/apps/br241791) 名前空間用に **using** ステートメントが必要になります。</span><span class="sxs-lookup"><span data-stu-id="d711f-158">This type requires a **using** statement for the [**Windows.Storage.Streams**](https://msdn.microsoft.com/library/windows/apps/br241791) namespace.</span></span>

>[!NOTE]
><span data-ttu-id="d711f-159">複数の地図アイコンに同じ画像を使う場合は、パフォーマンスが最大限に高まるように、ページ レベルまたはアプリ レベルで [**RandomAccessStreamReference**](https://msdn.microsoft.com/library/windows/apps/hh701813) を宣言します。</span><span class="sxs-lookup"><span data-stu-id="d711f-159">If you use the same image for multiple map icons, declare the [**RandomAccessStreamReference**](https://msdn.microsoft.com/library/windows/apps/hh701813) at the page or app level for the best performance.</span></span>

### <a name="reference-camera"></a><span data-ttu-id="d711f-160">リファレンス カメラ</span><span class="sxs-lookup"><span data-stu-id="d711f-160">Reference camera</span></span>

 <span data-ttu-id="d711f-161">[**MapBillboard**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapbillboard) 画像は地図の [**ZoomLevel**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapcontrol.ZoomLevel) の変更に合わせて拡大および縮小するため、その [**ZoomLevel**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapcontrol.ZoomLevel) が標準の 1x 倍率のときに画像がどこに表示されるかを定義することが重要になります。</span><span class="sxs-lookup"><span data-stu-id="d711f-161">Because a [**MapBillboard**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapbillboard) image scales in and out as the [**ZoomLevel**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapcontrol.ZoomLevel) of the map changes, it's important to define where in that [**ZoomLevel**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapcontrol.ZoomLevel) the image appears at a normal 1x scale.</span></span> <span data-ttu-id="d711f-162">その位置は [**MapBillboard**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapbillboard) のリファレンス カメラで定義されます。リファレンス カメラを設定するには、[**MapCamera**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapcamera) オブジェクトを [**MapBillboard**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapbillboard) のコンストラクターに渡す必要があります。</span><span class="sxs-lookup"><span data-stu-id="d711f-162">That position is defined in the reference camera of the [**MapBillboard**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapbillboard), and to set it, you'll have to pass a [**MapCamera**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapcamera) object into the constructor of the [**MapBillboard**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapbillboard).</span></span>

 <span data-ttu-id="d711f-163">[**Geopoint**](https://docs.microsoft.com/uwp/api/windows.devices.geolocation.geopoint) で目的の位置を定義し、その [**Geopoint**](https://docs.microsoft.com/uwp/api/windows.devices.geolocation.geopoint) を使用することで、[**MapCamera**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapcamera) オブジェクトを作成できます。</span><span class="sxs-lookup"><span data-stu-id="d711f-163">You can define the position that you want in a [**Geopoint**](https://docs.microsoft.com/uwp/api/windows.devices.geolocation.geopoint), and then use that [**Geopoint**](https://docs.microsoft.com/uwp/api/windows.devices.geolocation.geopoint) to create a [**MapCamera**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapcamera) object.</span></span>  <span data-ttu-id="d711f-164">ただし、この例で使用している [**MapCamera**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapcamera) オブジェクトは、単純にマップ コントロールの [**ActualCamera**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapcontrol.ActualCamera) プロパティから返されたものです。</span><span class="sxs-lookup"><span data-stu-id="d711f-164">However, in this example, we're just using the [**MapCamera**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapcamera) object returned by the [**ActualCamera**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapcontrol.ActualCamera) property of the map control.</span></span> <span data-ttu-id="d711f-165">これは地図の内部カメラです。</span><span class="sxs-lookup"><span data-stu-id="d711f-165">This is the map's internal camera.</span></span> <span data-ttu-id="d711f-166">このカメラの現在の位置がリファレンス カメラの位置となり、1x 倍率ではこの位置に [**MapBillboard**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapbillboard) 画像が表示されます。</span><span class="sxs-lookup"><span data-stu-id="d711f-166">The current position of that camera becomes the reference camera position; the position where the [**MapBillboard**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapbillboard) image appears at 1x scale.</span></span>

 <span data-ttu-id="d711f-167">アプリでユーザーが地図を縮小できるようにしている場合、画像のサイズも縮小されます。これは、1x 倍率の画像はリファレンス カメラの位置で固定されたままになりますが、地図の内部カメラは高度が上がるためです。</span><span class="sxs-lookup"><span data-stu-id="d711f-167">If your app gives users the ability to zoom out on the map, the image decreases in size because the maps internal camera is rising in altitude while the image at 1x scale remains fixed at the reference camera's position.</span></span>

### <a name="normalizedanchorpoint"></a><span data-ttu-id="d711f-168">NormalizedAnchorPoint</span><span class="sxs-lookup"><span data-stu-id="d711f-168">NormalizedAnchorPoint</span></span>

<span data-ttu-id="d711f-169">[**NormalizedAnchorPoint**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapbillboard.NormalizedAnchorPoint) は、[**MapBillboard**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapbillboard) の [**Location**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapbillboard.Location) プロパティに固定される画像のポイントです。</span><span class="sxs-lookup"><span data-stu-id="d711f-169">The [**NormalizedAnchorPoint**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapbillboard.NormalizedAnchorPoint) is the point of the image that is anchored to the [**Location**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapbillboard.Location) property of the [**MapBillboard**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapbillboard).</span></span> <span data-ttu-id="d711f-170">ポイント 0.5,1 は画像の下部中央になります。</span><span class="sxs-lookup"><span data-stu-id="d711f-170">The point 0.5,1 is the bottom center of the image.</span></span> <span data-ttu-id="d711f-171">[**MapBillboard**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapbillboard) の [**Location**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapbillboard.Location) プロパティをマップ コントロールの中央に設定しているので、画像の下部中央がマップ コントロールの中央に固定されることになります。</span><span class="sxs-lookup"><span data-stu-id="d711f-171">Because we've set the [**Location**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapbillboard.Location) property of the [**MapBillboard**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapbillboard) to the center of the map's control, the bottom center of the image will be anchored at the center of the maps control.</span></span> <span data-ttu-id="d711f-172">ポイントが中心になるように画像を表示するには、[**NormalizedAnchorPoint**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapbillboard.NormalizedAnchorPoint) を 0.5,0.5 に設定します。</span><span class="sxs-lookup"><span data-stu-id="d711f-172">If you want your image to appear centered directly over a point, set the [**NormalizedAnchorPoint**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapbillboard.NormalizedAnchorPoint) to 0.5,0.5.</span></span>  

## <a name="add-a-shape"></a><span data-ttu-id="d711f-173">図形の追加</span><span class="sxs-lookup"><span data-stu-id="d711f-173">Add a shape</span></span>

<span data-ttu-id="d711f-174">マルチポイント図形を地図に表示するには、[**MapPolygon**](https://msdn.microsoft.com/library/windows/apps/dn637103) クラスを使います。</span><span class="sxs-lookup"><span data-stu-id="d711f-174">Display a multi-point shape on the map by using the [**MapPolygon**](https://msdn.microsoft.com/library/windows/apps/dn637103) class.</span></span> <span data-ttu-id="d711f-175">次の例は、[UWP の地図サンプル](http://go.microsoft.com/fwlink/p/?LinkId=619977)から抜粋したもので、地図に赤色のボックス (境界線は青色) を表示します。</span><span class="sxs-lookup"><span data-stu-id="d711f-175">The following example, from the [UWP map sample](http://go.microsoft.com/fwlink/p/?LinkId=619977), displays a red box with blue border on the map.</span></span>

```csharp
public void HighlightArea()
{
    // Create MapPolygon.

    double centerLatitude = myMap.Center.Position.Latitude;
    double centerLongitude = myMap.Center.Position.Longitude;

    var mapPolygon = new MapPolygon
    {
        Path = new Geopath(new List<BasicGeoposition> {
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

    // Add MapPolygon to a layer on the map control.
    var MyHighlights = new List<MapElement>();

    MyHighlights.Add(mapPolygon);

    var HighlightsLayer = new MapElementsLayer
    {
        ZIndex = 1,
        MapElements = MyHighlights
    };

    myMap.Layers.Add(HighlightsLayer);
}
```

## <a name="add-a-line"></a><span data-ttu-id="d711f-176">線の追加</span><span class="sxs-lookup"><span data-stu-id="d711f-176">Add a line</span></span>


<span data-ttu-id="d711f-177">線を地図に表示するには、[**MapPolyline**](https://msdn.microsoft.com/library/windows/apps/dn637114) クラスを使います。</span><span class="sxs-lookup"><span data-stu-id="d711f-177">Display a line on the map by using the [**MapPolyline**](https://msdn.microsoft.com/library/windows/apps/dn637114) class.</span></span> <span data-ttu-id="d711f-178">次の例は、[UWP の地図サンプル](http://go.microsoft.com/fwlink/p/?LinkId=619977)から抜粋したもので、地図に破線を表示します。</span><span class="sxs-lookup"><span data-stu-id="d711f-178">The following example, from the [UWP map sample](http://go.microsoft.com/fwlink/p/?LinkId=619977), displays a dashed line on the map.</span></span>

```csharp
public void DrawLineOnMap()
{
    // Create Polyline.

    double centerLatitude = myMap.Center.Position.Latitude;
    double centerLongitude = myMap.Center.Position.Longitude;
    var mapPolyline = new MapPolyline
    {
        Path = new Geopath(new List<BasicGeoposition> {
                    new BasicGeoposition() {Latitude=centerLatitude-0.0005, Longitude=centerLongitude-0.001 },
                    new BasicGeoposition() {Latitude=centerLatitude+0.0005, Longitude=centerLongitude+0.001 },
                }),
        StrokeColor = Colors.Black,
        StrokeThickness = 3,
        StrokeDashed = true,
    };

   // Add Polyline to a layer on the map control.

   var MyLines = new List<MapElement>();

   MyLines.Add(mapPolyline);

   var LinesLayer = new MapElementsLayer
   {
       ZIndex = 1,
       MapElements = MyLines
   };

   myMap.Layers.Add(LinesLayer);

}
```

## <a name="add-xaml"></a><span data-ttu-id="d711f-179">XAML の追加</span><span class="sxs-lookup"><span data-stu-id="d711f-179">Add XAML</span></span>

<span data-ttu-id="d711f-180">XAML を使って、カスタム UI 要素を地図に表示します。</span><span class="sxs-lookup"><span data-stu-id="d711f-180">Display custom UI elements on the map using XAML.</span></span> <span data-ttu-id="d711f-181">XAML を地図に配置するには、XAML の位置と正規化されたアンカー ポイントを指定します。</span><span class="sxs-lookup"><span data-stu-id="d711f-181">Position XAML on the map by specifying the location and normalized anchor point of the XAML.</span></span>

-   <span data-ttu-id="d711f-182">[**SetLocation**](https://msdn.microsoft.com/library/windows/desktop/ms704369) を呼び出して、XAML を地図に配置する位置を設定します。</span><span class="sxs-lookup"><span data-stu-id="d711f-182">Set the location on the map where the XAML is placed by calling [**SetLocation**](https://msdn.microsoft.com/library/windows/desktop/ms704369).</span></span>
-   <span data-ttu-id="d711f-183">[**SetNormalizedAnchorPoint**](https://msdn.microsoft.com/library/windows/apps/dn637050) を呼び出して、指定した位置に対応する XAML 上の相対位置を設定します。</span><span class="sxs-lookup"><span data-stu-id="d711f-183">Set the relative location on the XAML that corresponds to the specified location by calling [**SetNormalizedAnchorPoint**](https://msdn.microsoft.com/library/windows/apps/dn637050).</span></span>

<span data-ttu-id="d711f-184">次の例では、シアトル市の地図を表示して、XAML の [**Border**](https://msdn.microsoft.com/library/windows/apps/br209250) コントロールを追加し、スペース ニードルの場所を示しています。</span><span class="sxs-lookup"><span data-stu-id="d711f-184">The following example shows a map of the city of Seattle and adds a XAML [**Border**](https://msdn.microsoft.com/library/windows/apps/br209250) control to indicate the location of the Space Needle.</span></span> <span data-ttu-id="d711f-185">また、そのエリアを地図の中央に配置し、拡大しています。</span><span class="sxs-lookup"><span data-stu-id="d711f-185">It also centers the map over the area and zooms in.</span></span> <span data-ttu-id="d711f-186">マップ コントロールを使用する方法に関する一般的な情報については、「 [2D、3D、Streetside ビューでの地図の表示](display-maps.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d711f-186">For general info about using the map control, see [Display maps with 2D, 3D, and Streetside views](display-maps.md).</span></span>

```csharp
private void displayXAMLButton_Click(object sender, RoutedEventArgs e)
{
   // Specify a known location.
   BasicGeoposition snPosition = new BasicGeoposition { Latitude = 47.620, Longitude = -122.349 };
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

<span data-ttu-id="d711f-187">この例では、地図に青色の境界線が表示されます。</span><span class="sxs-lookup"><span data-stu-id="d711f-187">This example displays a blue border on the map.</span></span>

![地図上の関心がある場所に表示された xaml のスクリーンショット](images/displaypoixaml.png)

<span data-ttu-id="d711f-189">次の例では、データ バインディングを使って、ページの XAML マークアップで XAML UI 要素を直接追加する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="d711f-189">The next examples show how to add XAML UI elements directly in the XAML markup of the page using data binding.</span></span> <span data-ttu-id="d711f-190">コンテンツを表示する他の XAML 要素と同様に、[**Children**](https://msdn.microsoft.com/library/windows/apps/dn637008) は [**MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004) の既定のコンテンツ プロパティであり、XAML マークアップで明示的に指定する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="d711f-190">As with other XAML elements that display content, [**Children**](https://msdn.microsoft.com/library/windows/apps/dn637008) is the default content property of the [**MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004) and does not have to be specified explicitly in XAML markup.</span></span>

<span data-ttu-id="d711f-191">次の例では、2 つの XAML コントロールを [**MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004) の暗黙的な子として表示する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="d711f-191">This example shows how to display two XAML controls as implicit children of the [**MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004).</span></span> <span data-ttu-id="d711f-192">これらのコントロールは、地図上のデータがバインドされた場所に表示されます。</span><span class="sxs-lookup"><span data-stu-id="d711f-192">These controls appear on the map at the data bound locations.</span></span>

```xml
<maps:MapControl>
    <TextBox Text="Seattle" maps:MapControl.Location="{x:Bind SeattleLocation}"/>
    <TextBox Text="Bellevue" maps:MapControl.Location="{x:Bind BellevueLocation}"/>
</maps:MapControl>
```

<span data-ttu-id="d711f-193">これらの場所を設定するには、分離コード ファイルでプロパティを使います。</span><span class="sxs-lookup"><span data-stu-id="d711f-193">Set these locations by using a properties in your code-behind file.</span></span>

```csharp
public Geopoint SeattleLocation { get; set; }
public Geopoint BellevueLocation { get; set; }
```

<span data-ttu-id="d711f-194">次の例は、[**MapItemsControl**](https://msdn.microsoft.com/library/windows/apps/dn637094) に含まれる 2 つの XAML コントロールを表示する方法を示しています。これらのコントロールは、地図上のデータがバインドされた場所に表示されます。</span><span class="sxs-lookup"><span data-stu-id="d711f-194">This example shows how to display two XAML controls contained within a [**MapItemsControl**](https://msdn.microsoft.com/library/windows/apps/dn637094).These controls appear on the map at the data bound locations.</span></span>

```xml
<maps:MapControl>
  <maps:MapItemsControl>
    <TextBox Text="Seattle" maps:MapControl.Location="{x:Bind SeattleLocation}"/>
    <TextBox Text="Bellevue" maps:MapControl.Location="{x:Bind BellevueLocation}"/>
  </maps:MapItemsControl>
</maps:MapControl>
```

<span data-ttu-id="d711f-195">次の例では、[**MapItemsControl**](https://msdn.microsoft.com/library/windows/apps/dn637094) にバインドされている XAML 要素のコレクションが表示されます。</span><span class="sxs-lookup"><span data-stu-id="d711f-195">This example displays a collection of XAML elements bound to a [**MapItemsControl**](https://msdn.microsoft.com/library/windows/apps/dn637094).</span></span>

```xml
<maps:MapControl x:Name="MapControl" MapTapped="MapTapped" MapDoubleTapped="MapTapped" MapHolding="MapTapped">
  <maps:MapItemsControl ItemsSource="{x:Bind LandmarkOverlays}">
      <maps:MapItemsControl.ItemTemplate>
          <DataTemplate>
              <StackPanel Background="Black" Tapped ="Overlay_Tapped">
                  <TextBlock maps:MapControl.Location="{Binding Location}" Text="{Binding Title}"
                    maps:MapControl.NormalizedAnchorPoint="0.5,0.5" FontSize="20" Margin="5"/>
              </StackPanel>
          </DataTemplate>
      </maps:MapItemsControl.ItemTemplate>
  </maps:MapItemsControl>
</maps:MapControl>
```

<span data-ttu-id="d711f-196">上の例の ``ItemsSource`` プロパティは、分離コード ファイルで [IList](https://docs.microsoft.com/dotnet/api/system.collections.ilist?view=netframework-4.70) 型のプロパティにバインドされます。</span><span class="sxs-lookup"><span data-stu-id="d711f-196">The ``ItemsSource`` property in the example above is bound to a property of type [IList](https://docs.microsoft.com/dotnet/api/system.collections.ilist?view=netframework-4.70) in the code-behind file.</span></span>

```csharp
public sealed partial class Scenario1 : Page
{
    public IList LandmarkOverlays { get; set; }

    public MyClassConstructor()
    {
         SetLandMarkLocations();
         this.InitializeComponent();   
    }

    private void SetLandMarkLocations()
    {
        LandmarkOverlays = new List<MapElement>();

        var pikePlaceIcon = new MapIcon
        {
            Location = new Geopoint(new BasicGeoposition
            { Latitude = 47.610, Longitude = -122.342 }),
            Title = "Pike Place Market"
        };

        LandmarkOverlays.Add(pikePlaceIcon);

        var SeattleSpaceNeedleIcon = new MapIcon
        {
            Location = new Geopoint(new BasicGeoposition
            { Latitude = 47.6205, Longitude = -122.3493 }),
            Title = "Seattle Space Needle"
        };

        LandmarkOverlays.Add(SeattleSpaceNeedleIcon);
    }
}
```

<a id="layers" />

## <a name="working-with-layers"></a><span data-ttu-id="d711f-197">レイヤーの使用</span><span class="sxs-lookup"><span data-stu-id="d711f-197">Working with layers</span></span>

<span data-ttu-id="d711f-198">このガイドの例では、要素を [MapElementLayers](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapelementslayer) コレクションに追加しています。</span><span class="sxs-lookup"><span data-stu-id="d711f-198">The examples in this guide add elements to a [MapElementLayers](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapelementslayer) collection.</span></span> <span data-ttu-id="d711f-199">その後、そのコレクションをマップ コントロールの **Layers** プロパティに追加する方法が示されています。</span><span class="sxs-lookup"><span data-stu-id="d711f-199">Then they show how to add that collection to the **Layers** property of the map control.</span></span> <span data-ttu-id="d711f-200">以前のリリースでは、このガイドで、次のようにマップの要素を [**MapElements**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapcontrol.MapElements) コレクションに追加する方法を示していました。</span><span class="sxs-lookup"><span data-stu-id="d711f-200">In previous releases, this guide showed you how to add map elements to the [**MapElements**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapcontrol.MapElements) collection as follows:</span></span>

```csharp
var pikePlaceIcon = new MapIcon
{
    Location = new Geopoint(new BasicGeoposition
    { Latitude = 47.610, Longitude = -122.342 }),
    NormalizedAnchorPoint = new Point(0.5, 1.0),
    ZIndex = 0,
    Title = "Pike Place Market"
};

myMap.MapElements.Add(pikePlaceIcon);
```

<span data-ttu-id="d711f-201">引き続き同じアプローチを使うこともできますが、その場合は新しいマップ レイヤー モデルの利点が活かされません。</span><span class="sxs-lookup"><span data-stu-id="d711f-201">While you can still use this approach, you'll miss out on some of the advantages of the new map layer model.</span></span> <span data-ttu-id="d711f-202">要素をレイヤーにグループ化すると、各レイヤーを互いに独立して操作できます。</span><span class="sxs-lookup"><span data-stu-id="d711f-202">By grouping your elements into layers, you can manipulate each layer independently from one another.</span></span> <span data-ttu-id="d711f-203">たとえば、各レイヤーには独自のイベント セットがあるため、特定のレイヤーのイベントに応答し、そのイベントに固有の操作を実行することができます。</span><span class="sxs-lookup"><span data-stu-id="d711f-203">For example, each layer has it's own set of events so you can respond to an event on a specific layer and perform an action specific to that event.</span></span>

<span data-ttu-id="d711f-204">また、XAML を直接 [MapLayer](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.maplayer) にバインドすることもできます。</span><span class="sxs-lookup"><span data-stu-id="d711f-204">Also, you can bind XAML directly to a [MapLayer](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.maplayer).</span></span> <span data-ttu-id="d711f-205">これは [MapElements](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapcontrol.MapElements) コレクションを使う場合にはできないことです。</span><span class="sxs-lookup"><span data-stu-id="d711f-205">This is something that you can't do by using the [MapElements](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapcontrol.MapElements)  collection.</span></span>

<span data-ttu-id="d711f-206">これを実現するには、1 つの方法として、ビュー モデル クラス、XAML ページの分離コード、および XAML ページを使います。</span><span class="sxs-lookup"><span data-stu-id="d711f-206">One way you could do this is by using a view model class, code-behind a XAML page, and a XAML page.</span></span>

### <a name="view-model-class"></a><span data-ttu-id="d711f-207">ビュー モデル クラス</span><span class="sxs-lookup"><span data-stu-id="d711f-207">View model class</span></span>

```csharp
public class LandmarksViewModel
{
    public ObservableCollection<MapLayer> LandmarkLayer
        { get; } = new ObservableCollection<MapLayer>();

    public LandmarksViewModel()
    {
        var MyElements = new List<MapElement>();

        var pikePlaceIcon = new MapIcon
        {
            Location = new Geopoint(new BasicGeoposition
            { Latitude = 47.610, Longitude = -122.342 }),
            Title = "Pike Place Market"
        };

        MyElements.Add(pikePlaceIcon);

        var LandmarksLayer = new MapElementsLayer
        {
            ZIndex = 1,
            MapElements = MyElements
        };

        LandmarkLayer.Add(LandmarksLayer);         
    }

```

### <a name="code-behind-a-xaml-page"></a><span data-ttu-id="d711f-208">XAML ページの分離コード</span><span class="sxs-lookup"><span data-stu-id="d711f-208">Code-behind a XAML page</span></span>

<span data-ttu-id="d711f-209">ビュー モデル クラスを分離コード ページに結び付けます。</span><span class="sxs-lookup"><span data-stu-id="d711f-209">Connect the view model class to your code behind page.</span></span>

```csharp
public LandmarksViewModel ViewModel { get; set; }

public myMapPage()
{
    this.InitializeComponent();
    this.ViewModel = new LandmarksViewModel();
}
```

### <a name="xaml-page"></a><span data-ttu-id="d711f-210">XAML ページ</span><span class="sxs-lookup"><span data-stu-id="d711f-210">XAML page</span></span>

<span data-ttu-id="d711f-211">XAML ページで、レイヤーを返すビュー モデル クラスのプロパティにバインドします。</span><span class="sxs-lookup"><span data-stu-id="d711f-211">In your XAML page, bind to the property in your view model class that returns the layer.</span></span>

```XML
<maps:MapControl
    x:Name="myMap" TransitFeaturesVisible="False" Loaded="MyMap_Loaded" Grid.Row="2"
    MapServiceToken="Your token" Layers="{x:Bind ViewModel.LandmarkLayer}"/>
```

## <a name="related-topics"></a><span data-ttu-id="d711f-212">関連トピック</span><span class="sxs-lookup"><span data-stu-id="d711f-212">Related topics</span></span>

* [<span data-ttu-id="d711f-213">Bing Maps Developer Center</span><span class="sxs-lookup"><span data-stu-id="d711f-213">Bing Maps Developer Center</span></span>](https://www.bingmapsportal.com/)
* [<span data-ttu-id="d711f-214">UWP の地図サンプル</span><span class="sxs-lookup"><span data-stu-id="d711f-214">UWP map sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkId=619977)
* [<span data-ttu-id="d711f-215">地図の設計ガイドライン</span><span class="sxs-lookup"><span data-stu-id="d711f-215">Design guidelines for maps</span></span>](https://msdn.microsoft.com/library/windows/apps/dn596102)
* [<span data-ttu-id="d711f-216">Build 2015 のビデオ: Windows アプリでの電話、タブレット、PC で使用できるマップと位置情報の活用</span><span class="sxs-lookup"><span data-stu-id="d711f-216">Build 2015 video: Leveraging Maps and Location Across Phone, Tablet, and PC in Your Windows Apps</span></span>](https://channel9.msdn.com/Events/Build/2015/2-757)
* [<span data-ttu-id="d711f-217">UWP の交通情報アプリのサンプル</span><span class="sxs-lookup"><span data-stu-id="d711f-217">UWP traffic app sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkId=619982)
* [**<span data-ttu-id="d711f-218">MapIcon</span><span class="sxs-lookup"><span data-stu-id="d711f-218">MapIcon</span></span>**](https://msdn.microsoft.com/library/windows/apps/dn637077)
* [**<span data-ttu-id="d711f-219">MapPolygon</span><span class="sxs-lookup"><span data-stu-id="d711f-219">MapPolygon</span></span>**](https://msdn.microsoft.com/library/windows/apps/dn637103)
* [**<span data-ttu-id="d711f-220">MapPolyline</span><span class="sxs-lookup"><span data-stu-id="d711f-220">MapPolyline</span></span>**](https://msdn.microsoft.com/library/windows/apps/dn637114)
