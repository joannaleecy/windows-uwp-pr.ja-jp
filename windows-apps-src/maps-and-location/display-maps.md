---
author: normesta
title: 2D、3D、Streetside ビューでの地図の表示
description: 地図を表示するには、マップ *プレースカード*と呼ばれる簡易非表示に対応したウィンドウか、フル機能を備えたマップ コントロールを使うことができます。
ms.assetid: 3839E00B-2C1E-4627-A45F-6DDA98D7077F
ms.author: normesta
ms.date: 03/14/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, 地図, 位置情報, マップ コントロール, マップ ビュー
ms.localizationpriority: medium
ms.openlocfilehash: ba03d430031ad2bdad6959e2c59500dc6f2d2666
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/11/2018
ms.locfileid: "3847396"
---
# <a name="display-maps-with-2d-3d-and-streetside-views"></a><span data-ttu-id="15d7e-104">2D、3D、Streetside ビューでの地図の表示</span><span class="sxs-lookup"><span data-stu-id="15d7e-104">Display maps with 2D, 3D, and Streetside views</span></span>

<span data-ttu-id="15d7e-105">地図を表示するには、マップ *プレースカード*と呼ばれる簡易非表示に対応したウィンドウか、フル機能を備えたマップ コントロールを使うことができます。</span><span class="sxs-lookup"><span data-stu-id="15d7e-105">You can show a map in light dismissable window called a map *placecard* or in a full featured map control.</span></span>

<span data-ttu-id="15d7e-106">[地図サンプル](http://go.microsoft.com/fwlink/p/?LinkId=619977)をダウンロードして、このガイドで説明されている機能のいくつかを試してみてください。</span><span class="sxs-lookup"><span data-stu-id="15d7e-106">Download the [map sample](http://go.microsoft.com/fwlink/p/?LinkId=619977) to try out some the features described in this guide.</span></span>

<a id="placecard" />

## <a name="display-map-in-a-placecard"></a><span data-ttu-id="15d7e-107">プレースカードへの地図の表示</span><span class="sxs-lookup"><span data-stu-id="15d7e-107">Display map in a placecard</span></span>
<span data-ttu-id="15d7e-108">UI 要素またはユーザーがタッチするアプリの領域の上下左右に軽量なポップアップ ウィンドウを開いて、その内部に地図を表示することができます。</span><span class="sxs-lookup"><span data-stu-id="15d7e-108">You can show users a map inside of a light-weight pop-up window above, below or to the side of a UI element or an area of an app where the user touches.</span></span> <span data-ttu-id="15d7e-109">地図には、アプリ内の情報に関連する都市や住所を表示できます。</span><span class="sxs-lookup"><span data-stu-id="15d7e-109">The map can show a city or address that relates to information in your app.</span></span>  

<span data-ttu-id="15d7e-110">次のプレースカードは、シアトルの街を表示します。</span><span class="sxs-lookup"><span data-stu-id="15d7e-110">This placecard shows the city of Seattle.</span></span>

![シアトルの街を表示するプレースカード](images/placecard-city.png)

<span data-ttu-id="15d7e-112">プレースカードのボタンの下にシアトルを表示するコードを次に示します。</span><span class="sxs-lookup"><span data-stu-id="15d7e-112">Here's the code that makes Seattle appear in a placecard below a button.</span></span>

```csharp
private void Seattle_Click(object sender, RoutedEventArgs e)
{
    Geopoint seattlePoint = new Geopoint
        (new BasicGeoposition { Latitude = 47.6062, Longitude = -122.3321 });

    PlaceInfo spaceNeedlePlace = PlaceInfo.Create(seattlePoint);

    FrameworkElement targetElement = (FrameworkElement)sender;

    GeneralTransform generalTransform =
        targetElement.TransformToVisual((FrameworkElement)targetElement.Parent);

    Rect rectangle = generalTransform.TransformBounds(new Rect(new Point
        (targetElement.Margin.Left, targetElement.Margin.Top), targetElement.RenderSize));

    spaceNeedlePlace.Show(rectangle, Windows.UI.Popups.Placement.Below);
}
```

<span data-ttu-id="15d7e-113">次のプレースカードは、シアトルにある Space Needle の場所を表示します。</span><span class="sxs-lookup"><span data-stu-id="15d7e-113">This placecard shows the location of the Space Needle in Seattle.</span></span>

![Space Needle の場所を表示するプレースカード](images/placecard-needle.png)

<span data-ttu-id="15d7e-115">プレースカードのボタンの下に Space Needle を表示するコードを次に示します。</span><span class="sxs-lookup"><span data-stu-id="15d7e-115">Here's the code that makes the Space Needle appear in a placecard below a button.</span></span>

```csharp
private void SpaceNeedle_Click(object sender, RoutedEventArgs e)
{
    Geopoint spaceNeedlePoint = new Geopoint
        (new BasicGeoposition { Latitude = 47.6205, Longitude = -122.3493 });

    PlaceInfoCreateOptions options = new PlaceInfoCreateOptions();

    options.DisplayAddress = "400 Broad St, Seattle, WA 98109";
    options.DisplayName = "Seattle Space Needle";

    PlaceInfo spaceNeedlePlace =  PlaceInfo.Create(spaceNeedlePoint, options);

    FrameworkElement targetElement = (FrameworkElement)sender;

    GeneralTransform generalTransform =
        targetElement.TransformToVisual((FrameworkElement)targetElement.Parent);

    Rect rectangle = generalTransform.TransformBounds(new Rect(new Point
        (targetElement.Margin.Left, targetElement.Margin.Top), targetElement.RenderSize));

    spaceNeedlePlace.Show(rectangle, Windows.UI.Popups.Placement.Below);
}
```

<a id="map-control" />

## <a name="display-map-in-a-control"></a><span data-ttu-id="15d7e-116">コントロールでの地図の表示</span><span class="sxs-lookup"><span data-stu-id="15d7e-116">Display map in a control</span></span>

<span data-ttu-id="15d7e-117">機能豊富でカスタマイズ可能なマップ データをアプリに表示するには、マップ コントロールを使います。</span><span class="sxs-lookup"><span data-stu-id="15d7e-117">Use a map control to show rich and customizable map data in your app.</span></span> <span data-ttu-id="15d7e-118">マップ コントロールでは、道路地図、航空写真、3D ビュー、ルート案内、検索結果、交通情報を表示できます。</span><span class="sxs-lookup"><span data-stu-id="15d7e-118">A map control can display road maps, aerial, 3D, views, directions, search results, and traffic.</span></span> <span data-ttu-id="15d7e-119">マップ上には、現在地、ルート、関心のあるポイントを表示できます。</span><span class="sxs-lookup"><span data-stu-id="15d7e-119">On a map, you can display the user's location, directions, and points of interest.</span></span> <span data-ttu-id="15d7e-120">また、航空写真 3D ビュー、Streetside ビュー、交通情報、乗り換え情報、周辺情報を表示することもできます。</span><span class="sxs-lookup"><span data-stu-id="15d7e-120">A map can also show aerial 3D views, Streetside views, traffic, transit, and local businesses.</span></span>

<span data-ttu-id="15d7e-121">アプリ固有の地理情報または一般的な地理情報を表示できるアプリ内でマップが必要な場合に、マップ コントロールを使います。</span><span class="sxs-lookup"><span data-stu-id="15d7e-121">Use a map control when you want a map within your app that allows users to view app-specific or general geographic information.</span></span> <span data-ttu-id="15d7e-122">アプリにマップ コントロールを含めておくことで、ユーザーはアプリの外部に移動することなく情報を得ることができます。</span><span class="sxs-lookup"><span data-stu-id="15d7e-122">Having a map control in your app means that users don't have to go outside your app to get that information.</span></span>

> [!NOTE]
><span data-ttu-id="15d7e-123">その情報を得るためにユーザーがアプリの外部に移動してもかまわない場合は、Windows マップ アプリを利用することも検討してください。</span><span class="sxs-lookup"><span data-stu-id="15d7e-123">If you don't mind users going outside your app, consider using the Windows Maps app to provide that information.</span></span> <span data-ttu-id="15d7e-124">アプリから Windows マップ アプリを起動し、特定の地図、ルート案内、検索結果を表示することができます。</span><span class="sxs-lookup"><span data-stu-id="15d7e-124">Your app can launch the Windows Maps app to display specific maps, directions, and search results.</span></span> <span data-ttu-id="15d7e-125">詳しくは、「[Windows マップ アプリの起動](https://msdn.microsoft.com/library/windows/apps/mt228341)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="15d7e-125">For more info, see [Launch the Windows Maps app](https://msdn.microsoft.com/library/windows/apps/mt228341).</span></span>

### <a name="add-a-map-control-to-your-app"></a><span data-ttu-id="15d7e-126">アプリへのマップ コントロールの追加</span><span class="sxs-lookup"><span data-stu-id="15d7e-126">Add a map control to your app</span></span>

<span data-ttu-id="15d7e-127">XAML ページに地図を表示するには、[**MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004) を追加します。</span><span class="sxs-lookup"><span data-stu-id="15d7e-127">Display a map on a XAML page by adding a [**MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004).</span></span> <span data-ttu-id="15d7e-128">**MapControl** を使うには、XAML ページまたはコード内に [**Windows.UI.Xaml.Controls.Maps**](https://msdn.microsoft.com/library/windows/apps/dn610751) 名前空間の宣言が必要です。</span><span class="sxs-lookup"><span data-stu-id="15d7e-128">To use the **MapControl**, you must declare the [**Windows.UI.Xaml.Controls.Maps**](https://msdn.microsoft.com/library/windows/apps/dn610751) namespace in the XAML page or in your code.</span></span> <span data-ttu-id="15d7e-129">ツールボックスからコントロールをドラッグすると、この名前空間宣言が自動的に追加されます。</span><span class="sxs-lookup"><span data-stu-id="15d7e-129">If you drag the control from the Toolbox, this namespace declaration is added automatically.</span></span> <span data-ttu-id="15d7e-130">XAML ページに **MapControl** を手動で追加する場合は、ページの上部に名前空間宣言を手動で追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="15d7e-130">If you add the **MapControl** to the XAML page manually, you must add the namespace declaration manually at the top of the page.</span></span>

<span data-ttu-id="15d7e-131">次の例では、基本的なマップ コントロールを表示し、タッチ入力を受け付けるだけでなくズーム コントロールとチルト コントロールを表示するように地図を構成しています。</span><span class="sxs-lookup"><span data-stu-id="15d7e-131">The following example displays a basic map control and configures the map to display the zoom and tilt controls in addition to accepting touch inputs.</span></span>

```xml
<Page
    x:Class="MapsAndLocation1.DisplayMaps"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:local="using:MapsAndLocation1"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    xmlns:Maps="using:Windows.UI.Xaml.Controls.Maps"
    mc:Ignorable="d">

 <Grid x:Name="pageGrid" Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">

    <Maps:MapControl
       x:Name="MapControl1"            
       ZoomInteractionMode="GestureAndControl"
       TiltInteractionMode="GestureAndControl"   
       MapServiceToken="EnterYourAuthenticationKeyHere"/>

 </Grid>
</Page>
```

<span data-ttu-id="15d7e-132">コードにマップ コントロールを追加する場合は、コード ファイルの先頭で手動で名前空間を宣言する必要があります。</span><span class="sxs-lookup"><span data-stu-id="15d7e-132">If you add the map control in your code, you must declare the namespace manually at the top of the code file.</span></span>

```csharp
using Windows.UI.Xaml.Controls.Maps;
...

// Add the MapControl and the specify maps authentication key.
MapControl MapControl2 = new MapControl();
MapControl2.ZoomInteractionMode = MapInteractionMode.GestureAndControl;
MapControl2.TiltInteractionMode = MapInteractionMode.GestureAndControl;
MapControl2.MapServiceToken = "EnterYourAuthenticationKeyHere";
pageGrid.Children.Add(MapControl2);
```

### <a name="get-and-set-a-maps-authentication-key"></a><span data-ttu-id="15d7e-133">マップ認証キーの取得と設定</span><span class="sxs-lookup"><span data-stu-id="15d7e-133">Get and set a maps authentication key</span></span>

<span data-ttu-id="15d7e-134">[**MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004) やマップ サービスを使用する前に、マップ認証キーを [**MapServiceToken**](https://msdn.microsoft.com/library/windows/apps/dn637036) プロパティの値として指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="15d7e-134">Before you can use [**MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004) and map services, you must specify the maps authentication key as the value of the [**MapServiceToken**](https://msdn.microsoft.com/library/windows/apps/dn637036) property.</span></span> <span data-ttu-id="15d7e-135">前に示した例では、`EnterYourAuthenticationKeyHere` を [Bing Maps Developer Center](https://www.bingmapsportal.com/) から取得したキーで置き換えます。</span><span class="sxs-lookup"><span data-stu-id="15d7e-135">In the previous examples, replace `EnterYourAuthenticationKeyHere` with the key you get from the [Bing Maps Developer Center](https://www.bingmapsportal.com/).</span></span> <span data-ttu-id="15d7e-136">マップ認証キーを指定するまでは、コントロールの下に **[警告: MapServiceToken が指定されていません]** というテキストが表示されます。</span><span class="sxs-lookup"><span data-stu-id="15d7e-136">The text **Warning: MapServiceToken not specified** continues to appear below the control until you specify the maps authentication key.</span></span> <span data-ttu-id="15d7e-137">マップ認証キーを取得して設定する方法について詳しくは、「[マップ認証キーの要求](authentication-key.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="15d7e-137">For more info about getting and setting a maps authentication key, see [Request a maps authentication key](authentication-key.md).</span></span>

## <a name="set-the-location-of-a-map"></a><span data-ttu-id="15d7e-138">地図の場所の設定</span><span class="sxs-lookup"><span data-stu-id="15d7e-138">Set the location of a map</span></span>
<span data-ttu-id="15d7e-139">地図を表示するときは、特定の場所を示すように設定することも、ユーザーの現在の場所を使うこともできます。</span><span class="sxs-lookup"><span data-stu-id="15d7e-139">Point the map to any location that you want or use the user's current location.</span></span>  

### <a name="set-a-starting-location-for-the-map"></a><span data-ttu-id="15d7e-140">地図の開始位置の設定</span><span class="sxs-lookup"><span data-stu-id="15d7e-140">Set a starting location for the map</span></span>

<span data-ttu-id="15d7e-141">コードで [**MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004) の [**Center**](https://msdn.microsoft.com/library/windows/apps/dn637005) プロパティを指定するか、または XAML マークアップでプロパティをバインドすることにより、地図上の表示位置を設定します。</span><span class="sxs-lookup"><span data-stu-id="15d7e-141">Set the location to display on the map by specifying the [**Center**](https://msdn.microsoft.com/library/windows/apps/dn637005) property of the [**MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004) in your code or by binding the property in your XAML markup.</span></span> <span data-ttu-id="15d7e-142">シアトル市を中心とした地図を表示する例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="15d7e-142">The following example displays a map with the city of Seattle as its center.</span></span>

> [!NOTE]
> <span data-ttu-id="15d7e-143">文字列は [**Geopoint**](https://msdn.microsoft.com/library/windows/apps/dn263675) に変換できないため、データ バインディングを使わない限り、XAML マークアップで [**Center**](https://msdn.microsoft.com/library/windows/apps/dn637005) プロパティに対する値を指定できません。</span><span class="sxs-lookup"><span data-stu-id="15d7e-143">Since a string can't be converted to a [**Geopoint**](https://msdn.microsoft.com/library/windows/apps/dn263675), you can't specify a value for the [**Center**](https://msdn.microsoft.com/library/windows/apps/dn637005) property in XAML markup unless you use data binding.</span></span> <span data-ttu-id="15d7e-144">(この制限は、[**MapControl.Location**](https://msdn.microsoft.com/library/windows/apps/dn653264) 添付プロパティにも適用されます)。</span><span class="sxs-lookup"><span data-stu-id="15d7e-144">(This limitation also applies to the [**MapControl.Location**](https://msdn.microsoft.com/library/windows/apps/dn653264) attached property.)</span></span>

 
```csharp
protected override void OnNavigatedTo(NavigationEventArgs e)
{
   // Specify a known location.
   BasicGeoposition cityPosition = new BasicGeoposition() { Latitude = 47.604, Longitude = -122.329 };
   Geopoint cityCenter = new Geopoint(cityPosition);

   // Set the map location.
   MapControl1.Center = cityCenter;
   MapControl1.ZoomLevel = 12;
   MapControl1.LandmarksVisible = true;
}
```

![マップ コントロールの例。](images/displaymapsexample1.png)

### <a name="set-the-current-location-of-the-map"></a><span data-ttu-id="15d7e-146">地図の現在位置の設定</span><span class="sxs-lookup"><span data-stu-id="15d7e-146">Set the current location of the map</span></span>

<span data-ttu-id="15d7e-147">ユーザーの位置情報にアクセスするには、先にアプリで [**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/dn859152) メソッドを呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="15d7e-147">Before your app can access the user’s location, your app must call the [**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/dn859152) method.</span></span> <span data-ttu-id="15d7e-148">このときに、アプリをフォアグラウンドで実行し、**RequestAccessAsync** を UI スレッドから呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="15d7e-148">At that time, your app must be in the foreground and **RequestAccessAsync** must be called from the UI thread.</span></span> <span data-ttu-id="15d7e-149">位置情報に対するアクセス許可をユーザーがアプリに与えるまで、アプリは位置情報にアクセスできません。</span><span class="sxs-lookup"><span data-stu-id="15d7e-149">Until the user grants your app permission to their location, your app can't access location data.</span></span>

<span data-ttu-id="15d7e-150">[**Geolocator**](https://msdn.microsoft.com/library/windows/apps/br225534) クラスの [**GetGeopositionAsync**](https://msdn.microsoft.com/library/windows/apps/hh973536) メソッドを使って、デバイスの現在の位置情報を取得します (位置情報にアクセスできる場合)。</span><span class="sxs-lookup"><span data-stu-id="15d7e-150">Get the current location of the device (if location is available) by using the [**GetGeopositionAsync**](https://msdn.microsoft.com/library/windows/apps/hh973536) method of the [**Geolocator**](https://msdn.microsoft.com/library/windows/apps/br225534) class.</span></span> <span data-ttu-id="15d7e-151">対応する [**Geopoint**](https://msdn.microsoft.com/library/windows/apps/dn263675) を取得するには、geoposition オブジェクトの geocoordinate の [**Point**](https://msdn.microsoft.com/library/windows/apps/dn263665) プロパティを使います。</span><span class="sxs-lookup"><span data-stu-id="15d7e-151">To obtain the corresponding [**Geopoint**](https://msdn.microsoft.com/library/windows/apps/dn263675), use the [**Point**](https://msdn.microsoft.com/library/windows/apps/dn263665) property of the geoposition's geocoordinate.</span></span> <span data-ttu-id="15d7e-152">詳しくは、「[現在の位置情報の取得](get-location.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="15d7e-152">For more info, see [Get current location](get-location.md).</span></span>

```csharp
// Set your current location.
var accessStatus = await Geolocator.RequestAccessAsync();
switch (accessStatus)
{
   case GeolocationAccessStatus.Allowed:

      // Get the current location.
      Geolocator geolocator = new Geolocator();
      Geoposition pos = await geolocator.GetGeopositionAsync();
      Geopoint myLocation = pos.Coordinate.Point;

      // Set the map location.
      MapControl1.Center = myLocation;
      MapControl1.ZoomLevel = 12;
      MapControl1.LandmarksVisible = true;
      break;

   case GeolocationAccessStatus.Denied:
      // Handle the case  if access to location is denied.
      break;

   case GeolocationAccessStatus.Unspecified:
      // Handle the case if  an unspecified error occurs.
      break;
}
```

<span data-ttu-id="15d7e-153">地図にデバイスの位置を表示するときは、位置情報の精度に基づいてグラフィックスを表示してズーム レベルを設定することを検討します。</span><span class="sxs-lookup"><span data-stu-id="15d7e-153">When you display your device's location on a map, consider displaying graphics and setting the zoom level based on the accuracy of the location data.</span></span> <span data-ttu-id="15d7e-154">詳しくは、「[位置認識アプリのガイドライン](https://msdn.microsoft.com/library/windows/apps/hh465148)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="15d7e-154">For more info, see [Guidelines for location-aware apps](https://msdn.microsoft.com/library/windows/apps/hh465148).</span></span>

### <a name="change-the-location-of-the-map"></a><span data-ttu-id="15d7e-155">地図の位置の変更</span><span class="sxs-lookup"><span data-stu-id="15d7e-155">Change the location of the map</span></span>

<span data-ttu-id="15d7e-156">2D 地図に表示する位置を変更するには、[**TrySetViewAsync**](https://msdn.microsoft.com/library/windows/apps/dn637060) メソッドのいずれかのオーバーロードを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="15d7e-156">To change the location that appears in a 2D map, call one of the overloads of the [**TrySetViewAsync**](https://msdn.microsoft.com/library/windows/apps/dn637060) method.</span></span> <span data-ttu-id="15d7e-157">そのメソッドを使って、[**Center**](https://msdn.microsoft.com/library/windows/apps/dn637005)、[**ZoomLevel**](https://msdn.microsoft.com/library/windows/apps/dn637068)、[**Heading**](https://msdn.microsoft.com/library/windows/apps/dn637019)、[**Pitch**](https://msdn.microsoft.com/library/windows/apps/dn637044) の新しい値を指定します。</span><span class="sxs-lookup"><span data-stu-id="15d7e-157">Use that method to specify new values for [**Center**](https://msdn.microsoft.com/library/windows/apps/dn637005), [**ZoomLevel**](https://msdn.microsoft.com/library/windows/apps/dn637068), [**Heading**](https://msdn.microsoft.com/library/windows/apps/dn637019), and [**Pitch**](https://msdn.microsoft.com/library/windows/apps/dn637044).</span></span> <span data-ttu-id="15d7e-158">また、ビューが変わるときに使うアニメーションをオプションで指定することもできます。そのためには、[**MapAnimationKind**](https://msdn.microsoft.com/library/windows/apps/dn637002) 列挙値の定数を指定します。</span><span class="sxs-lookup"><span data-stu-id="15d7e-158">You can also specify an optional animation to use when the view changes by providing a constant from the [**MapAnimationKind**](https://msdn.microsoft.com/library/windows/apps/dn637002) enumeration.</span></span>

<span data-ttu-id="15d7e-159">3D 地図の場所を変更するには、代わりに [**TrySetSceneAsync**](https://msdn.microsoft.com/library/windows/apps/dn974296) メソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="15d7e-159">To change the location of a 3D map, use the [**TrySetSceneAsync**](https://msdn.microsoft.com/library/windows/apps/dn974296) method instead.</span></span> <span data-ttu-id="15d7e-160">詳しくは、「[航空写真 3D ビューの表示](#3Dviews)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="15d7e-160">For more info, see [Display aerial 3D views](#3Dviews).</span></span>

<span data-ttu-id="15d7e-161">地図上に [**GeoboundingBox**](https://msdn.microsoft.com/library/windows/apps/dn607949) の内容を表示するには、[**TrySetViewBoundsAsync**](https://msdn.microsoft.com/library/windows/apps/dn637065) メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="15d7e-161">Call the [**TrySetViewBoundsAsync**](https://msdn.microsoft.com/library/windows/apps/dn637065) method to display the contents of a [**GeoboundingBox**](https://msdn.microsoft.com/library/windows/apps/dn607949) on the map.</span></span> <span data-ttu-id="15d7e-162">たとえばこのメソッドを使うと、地図上にルートやルートの一部を表示することができます。</span><span class="sxs-lookup"><span data-stu-id="15d7e-162">Use this method, for example, to display a route or a portion of a route on the map.</span></span> <span data-ttu-id="15d7e-163">詳しくは、「[地図へのルートとルート案内の表示](routes-and-directions.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="15d7e-163">For more info, see [Display routes and directions on a map](routes-and-directions.md).</span></span>

## <a name="change-the-appearance-of-a-map"></a><span data-ttu-id="15d7e-164">地図の外観の変更</span><span class="sxs-lookup"><span data-stu-id="15d7e-164">Change the appearance of a map</span></span>

<span data-ttu-id="15d7e-165">地図の外観をカスタマイズするには、マップ コントロールの [**StyleSheet**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapcontrol.StyleSheet) プロパティを既存の [**MapStyleSheet**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapstylesheet) オブジェクトに設定します。</span><span class="sxs-lookup"><span data-stu-id="15d7e-165">To customize the look and feel of the map, set the [**StyleSheet**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapcontrol.StyleSheet) property of the map control to any of the existing [**MapStyleSheet**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapstylesheet) objects.</span></span>

```csharp
myMap.StyleSheet = MapStyleSheet.RoadDark();
```

![濃色スタイルの地図](images/style-dark.png)

<span data-ttu-id="15d7e-167">また、JSON を使用してカスタム スタイルを定義し、その JSON を使用して [**MapStyleSheet**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapstylesheet) オブジェクトを作成することもできます。</span><span class="sxs-lookup"><span data-stu-id="15d7e-167">You can also use JSON to define custom styles and then use that JSON to create a [**MapStyleSheet**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapstylesheet) object.</span></span>

<span data-ttu-id="15d7e-168">対話的に[マップ スタイル シート エディター](https://www.microsoft.com/p/map-style-sheet-editor/9nbhtcjt72ft)アプリケーションを使用して、JSON のスタイル シートを作成できます。</span><span class="sxs-lookup"><span data-stu-id="15d7e-168">Style sheet JSON can be created interactively using the [Map Style Sheet Editor](https://www.microsoft.com/p/map-style-sheet-editor/9nbhtcjt72ft) application.</span></span>

```csharp
myMap.StyleSheet = MapStyleSheet.ParseFromJson(@"
    {
        ""version"": ""1.0"",
        ""settings"": {
            ""landColor"": ""#FFFFFF"",
            ""spaceColor"": ""#000000""
        },
        ""elements"": {
            ""mapElement"": {
                ""labelColor"": ""#000000"",
                ""labelOutlineColor"": ""#FFFFFF""
            },
            ""water"": {
                ""fillColor"": ""#DDDDDD""
            },
            ""area"": {
                ""fillColor"": ""#EEEEEE""
            },
            ""political"": {
                ""borderStrokeColor"": ""#CCCCCC"",
                ""borderOutlineColor"": ""#00000000""
            }
        }
    }
");
```

![カスタム スタイルの地図](images/style-custom.png)

<span data-ttu-id="15d7e-170">完全な JSON エントリのリファレンスについては、「[マップ スタイル シート リファレンス](elements-of-map-style-sheet.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="15d7e-170">For the complete JSON entry reference, see [Map style sheet reference](elements-of-map-style-sheet.md).</span></span>

<span data-ttu-id="15d7e-171">最初は既存のシートを使用して、次に JSON を使用して要素を上書きできます。</span><span class="sxs-lookup"><span data-stu-id="15d7e-171">You can start with an existing sheet and then use JSON to override any elements that you want.</span></span> <span data-ttu-id="15d7e-172">この例では、最初は既存のスタイルを使用し、次に JSON を使用して水域の色のみを変更しています。</span><span class="sxs-lookup"><span data-stu-id="15d7e-172">This example, starts with an existing style and uses JSON to change only the color of water areas.</span></span>

```csharp
 MapStyleSheet \customSheet = MapStyleSheet.ParseFromJson(@"
    {
        ""version"": ""1.0"",
        ""elements"": {
            ""water"": {
                ""fillColor"": ""#DDDDDD""
            }
        }
    }
");

MapStyleSheet builtInSheet = MapStyleSheet.RoadDark();

myMap.StyleSheet = MapStyleSheet.Combine(new List<MapStyleSheet> { builtInSheet, customSheet });
```

![複数のスタイルの地図](images/style-combined.png)

>[!NOTE]
><span data-ttu-id="15d7e-174">2 番目のスタイル シートで定義するスタイルは、最初のスタイルを上書きします。</span><span class="sxs-lookup"><span data-stu-id="15d7e-174">Styles that you define in the second style sheet override the styles in the first.</span></span>

## <a name="set-orientation-and-perspective"></a><span data-ttu-id="15d7e-175">向きと視点の設定</span><span class="sxs-lookup"><span data-stu-id="15d7e-175">Set orientation and perspective</span></span>

<span data-ttu-id="15d7e-176">マップ カメラを拡大、縮小、回転、傾けることで、求める効果をもたらす適切な角度に設定できます。</span><span class="sxs-lookup"><span data-stu-id="15d7e-176">Zoom in, zoom out, rotate, and tilt the map's camera to get just the right angle for the effect that you want.</span></span> <span data-ttu-id="15d7e-177">次のプロパティをお試しください。</span><span class="sxs-lookup"><span data-stu-id="15d7e-177">Try these properties.</span></span>

-   <span data-ttu-id="15d7e-178">地図の**中心**を地理的位置に設定するには、[**Center**](https://msdn.microsoft.com/library/windows/apps/dn637005) プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="15d7e-178">Set the **center** of the map to a geographic point by setting the [**Center**](https://msdn.microsoft.com/library/windows/apps/dn637005) property.</span></span>
-   <span data-ttu-id="15d7e-179">[**ZoomLevel**](https://msdn.microsoft.com/library/windows/apps/dn637068) プロパティに 1 ～ 20 度の値を設定することにより、地図の**ズーム レベル**を設定します。</span><span class="sxs-lookup"><span data-stu-id="15d7e-179">Set the **zoom level** of the map by setting the [**ZoomLevel**](https://msdn.microsoft.com/library/windows/apps/dn637068) property to a value between 1 and 20.</span></span>
-   <span data-ttu-id="15d7e-180">[**Heading**](https://msdn.microsoft.com/library/windows/apps/dn637019) プロパティを設定することにより地図の**回転**を設定します。ここでは 0 度または 360 度 = 北、90 度 = 東、180 度 = 南、270 度 = 西です。</span><span class="sxs-lookup"><span data-stu-id="15d7e-180">Set the **rotation** of the map by setting the [**Heading**](https://msdn.microsoft.com/library/windows/apps/dn637019) property, where 0 or 360 degrees = North, 90 = East, 180 = South, and 270 = West.</span></span>
-   <span data-ttu-id="15d7e-181">[**DesiredPitch**](https://msdn.microsoft.com/library/windows/apps/dn637012) プロパティに 0 ～ 65 度の値を設定することにより、地図の**傾き**を設定します。</span><span class="sxs-lookup"><span data-stu-id="15d7e-181">Set the **tilt** of the map by setting the [**DesiredPitch**](https://msdn.microsoft.com/library/windows/apps/dn637012) property to a value between 0 and 65 degrees.</span></span>

## <a name="show-and-hide-map-features"></a><span data-ttu-id="15d7e-182">地図機能を表示または非表示にする</span><span class="sxs-lookup"><span data-stu-id="15d7e-182">Show and hide map features</span></span>

<span data-ttu-id="15d7e-183">道路やランドマークなどの地図機能を表示または非表示にするには、[**MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004) の次のプロパティの値を設定します。</span><span class="sxs-lookup"><span data-stu-id="15d7e-183">Show or hide map features such as roads and landmarks by setting the values of the following properties of the [**MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004).</span></span>

* <span data-ttu-id="15d7e-184">地図に**建物やランドマーク**を表示するには、[**LandmarksVisible**](https://msdn.microsoft.com/library/windows/apps/dn637023) プロパティを有効または無効にします。</span><span class="sxs-lookup"><span data-stu-id="15d7e-184">Display **buildings and landmarks** on the map by enabling or disabling the [**LandmarksVisible**](https://msdn.microsoft.com/library/windows/apps/dn637023) property.</span></span>

  > [!NOTE]
  > <span data-ttu-id="15d7e-185">建物の表示と非表示を切り替えることはできますが、3 次元表示を無効にすることはできません。</span><span class="sxs-lookup"><span data-stu-id="15d7e-185">You can show or hide buildings, but you can't prevent them from appearing 3 dimensions.</span></span>  

* <span data-ttu-id="15d7e-186">地図に公共階段などの**歩行者用の施設**を表示するには、[**PedestrianFeaturesVisible**](https://msdn.microsoft.com/library/windows/apps/dn637042) プロパティを有効または無効にします。</span><span class="sxs-lookup"><span data-stu-id="15d7e-186">Display **pedestrian features** such as public stairs on the map by enabling or disabling the [**PedestrianFeaturesVisible**](https://msdn.microsoft.com/library/windows/apps/dn637042) property.</span></span>
* <span data-ttu-id="15d7e-187">地図に**交通情報**を表示するには、[**TrafficFlowVisible**](https://msdn.microsoft.com/library/windows/apps/dn637055) プロパティを有効または無効にします。</span><span class="sxs-lookup"><span data-stu-id="15d7e-187">Display **traffic** on the map by enabling or disabling the [**TrafficFlowVisible**](https://msdn.microsoft.com/library/windows/apps/dn637055) property.</span></span>
* <span data-ttu-id="15d7e-188">地図に**透かし**を表示するかどうかを指定するには、[**WatermarkMode**](https://msdn.microsoft.com/library/windows/apps/dn637066) プロパティを [**MapWatermarkMode**](https://msdn.microsoft.com/library/windows/apps/dn610749) 定数のいずれかに設定します。</span><span class="sxs-lookup"><span data-stu-id="15d7e-188">Specify whether the **watermark** is displayed on the map by setting the [**WatermarkMode**](https://msdn.microsoft.com/library/windows/apps/dn637066) property to one of the [**MapWatermarkMode**](https://msdn.microsoft.com/library/windows/apps/dn610749) constants.</span></span>
* <span data-ttu-id="15d7e-189">地図に**自動車ルートや徒歩ルート**を表示するには、マップ コントロールの [**Routes**](https://msdn.microsoft.com/library/windows/apps/dn637047) コレクションに [**MapRouteView**](https://msdn.microsoft.com/library/windows/apps/dn637122) を追加します。</span><span class="sxs-lookup"><span data-stu-id="15d7e-189">Display a **driving or walking route** on the map by adding a [**MapRouteView**](https://msdn.microsoft.com/library/windows/apps/dn637122) to the [**Routes**](https://msdn.microsoft.com/library/windows/apps/dn637047) collection of the Map control.</span></span> <span data-ttu-id="15d7e-190">詳しい情報と例については、「[地図へのルートとルート案内の表示](routes-and-directions.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="15d7e-190">For more info and an example, see [Display routes and directions on a map](routes-and-directions.md).</span></span>

<span data-ttu-id="15d7e-191">[**MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004) でプッシュピン、図形、XAML コントロールを表示する方法については、「[関心のあるポイント (POI) の地図への表示](display-poi.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="15d7e-191">For info about how to display pushpins, shapes, and XAML controls in the [**MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004), see [Display points of interest (POI) on a map](display-poi.md).</span></span>

## <a name="display-streetside-views"></a><span data-ttu-id="15d7e-192">Streetside ビューの表示</span><span class="sxs-lookup"><span data-stu-id="15d7e-192">Display Streetside views</span></span>


<span data-ttu-id="15d7e-193">Streetside ビューは、視点がストリート レベルにある場合の場所の見え方を示すもので、マップ コントロールの上に表示されます。</span><span class="sxs-lookup"><span data-stu-id="15d7e-193">A Streetside view is a street-level perspective of a location that appears on top of the map control.</span></span>

![マップ コントロールの Streetside ビューの例。](images/onlystreetside-730width.png)

<span data-ttu-id="15d7e-195">Streetside ビューの「内部」での操作は、マップ コントロールにもともと表示されている地図とは独立していることを考慮します。</span><span class="sxs-lookup"><span data-stu-id="15d7e-195">Consider the experience "inside" the Streetside view separate from the map originally displayed in the map control.</span></span> <span data-ttu-id="15d7e-196">たとえば、Streetside ビューで場所を変更しても、Streetside ビューの「下」にある地図の場所や外観は変わりません。</span><span class="sxs-lookup"><span data-stu-id="15d7e-196">For example, changing the location in the Streetside view does not change the location or appearance of the map "under" the Streetside view.</span></span> <span data-ttu-id="15d7e-197">コントロールの右上隅にある **[X]** をクリックして Streetside ビューを閉じると、元の地図は Streetside ビューが表示される前のままです。</span><span class="sxs-lookup"><span data-stu-id="15d7e-197">After you close the Streetside view (by clicking the **X** in the upper right corner of the control), the original map remains unchanged.</span></span>

<span data-ttu-id="15d7e-198">Streetside ビューを表示するには</span><span class="sxs-lookup"><span data-stu-id="15d7e-198">To display a Streetside view</span></span>

1.  <span data-ttu-id="15d7e-199">[**IsStreetsideSupported**](https://msdn.microsoft.com/library/windows/apps/dn974271) を確認して、Streetside ビューがデバイスでサポートされているかどうかを調べます。</span><span class="sxs-lookup"><span data-stu-id="15d7e-199">Determine if Streetside views are supported on the device by checking [**IsStreetsideSupported**](https://msdn.microsoft.com/library/windows/apps/dn974271).</span></span>
2.  <span data-ttu-id="15d7e-200">Streetside ビューがサポートされている場合は、[**FindNearbyAsync**](https://msdn.microsoft.com/library/windows/apps/dn974361) を呼び出し、指定した位置の近くに [**StreetsidePanorama**](https://msdn.microsoft.com/library/windows/apps/dn974360) を作成します。</span><span class="sxs-lookup"><span data-stu-id="15d7e-200">If Streetside view is supported, create a [**StreetsidePanorama**](https://msdn.microsoft.com/library/windows/apps/dn974360) near the specified location by calling [**FindNearbyAsync**](https://msdn.microsoft.com/library/windows/apps/dn974361).</span></span>
3.  <span data-ttu-id="15d7e-201">[**StreetsidePanorama**](https://msdn.microsoft.com/library/windows/apps/dn974360) が null でないかどうかを確認し、近隣のパノラマ写真があるかどうかを調べます。</span><span class="sxs-lookup"><span data-stu-id="15d7e-201">Determine if a nearby panorama was found by checking if the [**StreetsidePanorama**](https://msdn.microsoft.com/library/windows/apps/dn974360) is not null</span></span>
4.  <span data-ttu-id="15d7e-202">近隣のパノラマ写真があった場合、[**StreetsideExperience**](https://msdn.microsoft.com/library/windows/apps/dn974356) を作成し、マップ コントロールの [**CustomExperience**](https://msdn.microsoft.com/library/windows/apps/dn974263) プロパティに設定します。</span><span class="sxs-lookup"><span data-stu-id="15d7e-202">If a nearby panorama was found, create a [**StreetsideExperience**](https://msdn.microsoft.com/library/windows/apps/dn974356) for the map control's [**CustomExperience**](https://msdn.microsoft.com/library/windows/apps/dn974263) property.</span></span>

<span data-ttu-id="15d7e-203">次の例は、前掲の画像に似た Streetside ビューを表示する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="15d7e-203">This example shows how to display a Streetside view similar to the previous image.</span></span>

<span data-ttu-id="15d7e-204">**注**  マップ コントロールのサイズが小さすぎる場合は、概観の地図は表示されません。</span><span class="sxs-lookup"><span data-stu-id="15d7e-204">**Note**  The overview map will not appear if the map control is sized too small.</span></span>

 

```csharp
private async void showStreetsideView()
{
   // Check if Streetside is supported.
   if (MapControl1.IsStreetsideSupported)
   {
      // Find a panorama near Avenue Gustave Eiffel.
      BasicGeoposition cityPosition = new BasicGeoposition() { Latitude = 48.858, Longitude = 2.295};
      Geopoint cityCenter = new Geopoint(cityPosition);
      StreetsidePanorama panoramaNearCity = await StreetsidePanorama.FindNearbyAsync(cityCenter);

      // Set the Streetside view if a panorama exists.
      if (panoramaNearCity != null)
      {
         // Create the Streetside view.
         StreetsideExperience ssView = new StreetsideExperience(panoramaNearCity);
         ssView.OverviewMapVisible = true;
         MapControl1.CustomExperience = ssView;
      }
   }
   else
   {
      // If Streetside is not supported
      ContentDialog viewNotSupportedDialog = new ContentDialog()
      {
         Title = "Streetside is not supported",
         Content ="\nStreetside views are not supported on this device.",
         PrimaryButtonText = "OK"
      };
      await viewNotSupportedDialog.ShowAsync();            
   }
}
```

<a id="3Dviews" />
## <a name="display-aerial-3d-views"></a><span data-ttu-id="15d7e-205">航空写真 3D ビューの表示</span><span class="sxs-lookup"><span data-stu-id="15d7e-205">Display aerial 3D views</span></span>


<span data-ttu-id="15d7e-206">[**MapScene**](https://msdn.microsoft.com/library/windows/apps/dn974329) クラスを使って、地図の 3D 視点を指定します。</span><span class="sxs-lookup"><span data-stu-id="15d7e-206">Specify a 3D perspective of the map by using the [**MapScene**](https://msdn.microsoft.com/library/windows/apps/dn974329) class.</span></span> <span data-ttu-id="15d7e-207">マップ シーンは、地図に表示される 3D ビューを表します。</span><span class="sxs-lookup"><span data-stu-id="15d7e-207">The map scene represents the 3D view that appears in the map.</span></span> <span data-ttu-id="15d7e-208">[**MapCamera**](https://msdn.microsoft.com/library/windows/apps/dn974244) クラスは、このようなビューが表示されるカメラの位置を表します。</span><span class="sxs-lookup"><span data-stu-id="15d7e-208">The [**MapCamera**](https://msdn.microsoft.com/library/windows/apps/dn974244) class represents the position of the camera that would display such a view.</span></span>

![マップ シーンの場所と MapCamera の場所を示す図](images/mapcontrol-techdiagram.png)

<span data-ttu-id="15d7e-210">建物などの地物を地図表面に 3D 表示するには、マップ コントロールの [**Style**](https://msdn.microsoft.com/library/windows/apps/dn637051) プロパティを [**MapStyle.Aerial3DWithRoads**](https://msdn.microsoft.com/library/windows/apps/dn637127) に設定します。</span><span class="sxs-lookup"><span data-stu-id="15d7e-210">To make buildings and other features on the map surface appear in 3D, set the map control's [**Style**](https://msdn.microsoft.com/library/windows/apps/dn637051) property to [**MapStyle.Aerial3DWithRoads**](https://msdn.microsoft.com/library/windows/apps/dn637127).</span></span> <span data-ttu-id="15d7e-211">**Aerial3DWithRoads** スタイルの 3D ビューの例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="15d7e-211">This is an example of a 3D view with the **Aerial3DWithRoads** style.</span></span>

![3D 地図ビューの例。](images/only3d-730width.png)

<span data-ttu-id="15d7e-213">3D ビューを表示するには</span><span class="sxs-lookup"><span data-stu-id="15d7e-213">To display a 3D view</span></span>

1.  <span data-ttu-id="15d7e-214">[**Is3DSupported**](https://msdn.microsoft.com/library/windows/apps/dn974265) を確認して、3D ビューがデバイスでサポートされているかどうかを調べます。</span><span class="sxs-lookup"><span data-stu-id="15d7e-214">Determine if 3D views are supported on the device by checking [**Is3DSupported**](https://msdn.microsoft.com/library/windows/apps/dn974265).</span></span>
2.  <span data-ttu-id="15d7e-215">3D ビューがサポートされている場合は、マップ コントロールの [**Style**](https://msdn.microsoft.com/library/windows/apps/dn637051) プロパティを [**MapStyle.Aerial3DWithRoads**](https://msdn.microsoft.com/library/windows/apps/dn637127) に設定します。</span><span class="sxs-lookup"><span data-stu-id="15d7e-215">If 3D views is supported, set the map control's [**Style**](https://msdn.microsoft.com/library/windows/apps/dn637051) property to [**MapStyle.Aerial3DWithRoads**](https://msdn.microsoft.com/library/windows/apps/dn637127).</span></span>
3.  <span data-ttu-id="15d7e-216">[**CreateFromLocationAndRadius**](https://msdn.microsoft.com/library/windows/apps/dn974336)、[**CreateFromCamera**](https://msdn.microsoft.com/library/windows/apps/dn974334) などの多数の **CreateFrom** メソッドの中から [**MapScene**](https://msdn.microsoft.com/library/windows/apps/dn974329) オブジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="15d7e-216">Create a [**MapScene**](https://msdn.microsoft.com/library/windows/apps/dn974329) object using one of the many **CreateFrom** methods, such as [**CreateFromLocationAndRadius**](https://msdn.microsoft.com/library/windows/apps/dn974336) and [**CreateFromCamera**](https://msdn.microsoft.com/library/windows/apps/dn974334).</span></span>
4.  <span data-ttu-id="15d7e-217">[**TrySetSceneAsync**](https://msdn.microsoft.com/library/windows/apps/dn974296) を呼び出して、3D ビューを表示します。</span><span class="sxs-lookup"><span data-stu-id="15d7e-217">Call [**TrySetSceneAsync**](https://msdn.microsoft.com/library/windows/apps/dn974296) to display the 3D view.</span></span> <span data-ttu-id="15d7e-218">また、ビューが変わるときに使うアニメーションをオプションで指定することもできます。そのためには、[**MapAnimationKind**](https://msdn.microsoft.com/library/windows/apps/dn637002) 列挙値の定数を指定します。</span><span class="sxs-lookup"><span data-stu-id="15d7e-218">You can also specify an optional animation to use when the view changes by providing a constant from the [**MapAnimationKind**](https://msdn.microsoft.com/library/windows/apps/dn637002) enumeration.</span></span>

<span data-ttu-id="15d7e-219">次の例は、3D ビューを表示する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="15d7e-219">This example shows how to display a 3D view.</span></span>

```csharp
private async void display3DLocation()
{
   if (MapControl1.Is3DSupported)
   {
      // Set the aerial 3D view.
      MapControl1.Style = MapStyle.Aerial3DWithRoads;

      // Specify the location.
      BasicGeoposition hwGeoposition = new BasicGeoposition() { Latitude = 43.773251, Longitude = 11.255474};
      Geopoint hwPoint = new Geopoint(hwGeoposition);

      // Create the map scene.
      MapScene hwScene = MapScene.CreateFromLocationAndRadius(hwPoint,
                                                                           80, /* show this many meters around */
                                                                           0, /* looking at it to the North*/
                                                                           60 /* degrees pitch */);
      // Set the 3D view with animation.
      await MapControl1.TrySetSceneAsync(hwScene,MapAnimationKind.Bow);
   }
   else
   {
      // If 3D views are not supported, display dialog.
      ContentDialog viewNotSupportedDialog = new ContentDialog()
      {
         Title = "3D is not supported",
         Content = "\n3D views are not supported on this device.",
         PrimaryButtonText = "OK"
      };
      await viewNotSupportedDialog.ShowAsync();
   }
}
```

## <a name="get-info-about-locations"></a><span data-ttu-id="15d7e-220">位置に関する情報の取得</span><span class="sxs-lookup"><span data-stu-id="15d7e-220">Get info about locations</span></span>


<span data-ttu-id="15d7e-221">地図上の位置に関する情報を取得するには、[**MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004) の次のメソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="15d7e-221">Get info about locations on the map by calling the following methods of the [**MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004).</span></span>

-   <span data-ttu-id="15d7e-222">[**GetLocationFromOffset**](https://msdn.microsoft.com/library/windows/apps/dn637016) メソッド - マップ コントロールのビューポート内の指定したポイントに対応する地理的な位置情報を取得します。</span><span class="sxs-lookup"><span data-stu-id="15d7e-222">[**GetLocationFromOffset**](https://msdn.microsoft.com/library/windows/apps/dn637016) method - Get the geographic location that corresponds to the specified point in the viewport of the Map control.</span></span>
-   <span data-ttu-id="15d7e-223">[**GetOffsetFromLocation**](https://msdn.microsoft.com/library/windows/apps/dn637018) メソッド - 指定した地理的な位置情報に対応するマップ コントロールのビューポート内のポイントを取得します。</span><span class="sxs-lookup"><span data-stu-id="15d7e-223">[**GetOffsetFromLocation**](https://msdn.microsoft.com/library/windows/apps/dn637018) method - Get the point in the viewport of the Map control that corresponds to the specified geographic location.</span></span>
-   <span data-ttu-id="15d7e-224">[**IsLocationInView**](https://msdn.microsoft.com/library/windows/apps/dn637022) メソッド - 指定した地理的な位置がマップ コントロールのビューポート内に現在表示されているかどうかを調べます。</span><span class="sxs-lookup"><span data-stu-id="15d7e-224">[**IsLocationInView**](https://msdn.microsoft.com/library/windows/apps/dn637022) method - Determine whether the specified geographic location is currently visible in the viewport of the Map control.</span></span>
-   <span data-ttu-id="15d7e-225">[**FindMapElementsAtOffset**](https://msdn.microsoft.com/library/windows/apps/dn637014) メソッド - マップ コントロールのビューポート内の指定したポイントにある地図上の要素を取得します。</span><span class="sxs-lookup"><span data-stu-id="15d7e-225">[**FindMapElementsAtOffset**](https://msdn.microsoft.com/library/windows/apps/dn637014) method - Get the elements on the map located at the specified point in the viewport of the Map control.</span></span>

## <a name="handle-interaction-and-changes"></a><span data-ttu-id="15d7e-226">操作と変更の処理</span><span class="sxs-lookup"><span data-stu-id="15d7e-226">Handle interaction and changes</span></span>


<span data-ttu-id="15d7e-227">地図上でのユーザー入力ジェスチャを処理するには、[**MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004) の次のイベントを処理します。</span><span class="sxs-lookup"><span data-stu-id="15d7e-227">Handle user input gestures on the map by handling the following events of the [**MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004).</span></span> <span data-ttu-id="15d7e-228">地図上の地理的な位置、およびジェスチャが行われたビューポート内の実際の位置に関する情報を取得するには、[**MapInputEventArgs**](https://msdn.microsoft.com/library/windows/apps/dn637090) の [**Location**](https://msdn.microsoft.com/library/windows/apps/dn637091) プロパティと [**Position**](https://msdn.microsoft.com/library/windows/apps/dn637093) プロパティの値を確認します。</span><span class="sxs-lookup"><span data-stu-id="15d7e-228">Get info about the geographic location on the map and the physical position in the viewport where the gesture occurred by checking the values of the [**Location**](https://msdn.microsoft.com/library/windows/apps/dn637091) and [**Position**](https://msdn.microsoft.com/library/windows/apps/dn637093) properties of the [**MapInputEventArgs**](https://msdn.microsoft.com/library/windows/apps/dn637090).</span></span>

-   [**<span data-ttu-id="15d7e-229">MapTapped</span><span class="sxs-lookup"><span data-stu-id="15d7e-229">MapTapped</span></span>**](https://msdn.microsoft.com/library/windows/apps/dn637038)
-   [**<span data-ttu-id="15d7e-230">MapDoubleTapped</span><span class="sxs-lookup"><span data-stu-id="15d7e-230">MapDoubleTapped</span></span>**](https://msdn.microsoft.com/library/windows/apps/dn637032)
-   [**<span data-ttu-id="15d7e-231">MapHolding</span><span class="sxs-lookup"><span data-stu-id="15d7e-231">MapHolding</span></span>**](https://msdn.microsoft.com/library/windows/apps/dn637035)

<span data-ttu-id="15d7e-232">地図が読み込まれている最中であるか、完全に読み込まれたかどうかを判断するには、コントロールの [**LoadingStatusChanged**](https://msdn.microsoft.com/library/windows/apps/dn637028) イベントを処理します。</span><span class="sxs-lookup"><span data-stu-id="15d7e-232">Determine whether the map is loading or completely loaded by handling the control's [**LoadingStatusChanged**](https://msdn.microsoft.com/library/windows/apps/dn637028) event.</span></span>

<span data-ttu-id="15d7e-233">ユーザーやアプリによる地図の設定変更に対応するには、[**MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004) の次のイベントを処理します。</span><span class="sxs-lookup"><span data-stu-id="15d7e-233">Handle changes that happen when the user or the app changes the settings of the map by handling the following events of the [**MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004).</span></span> [<span data-ttu-id="15d7e-234">マップのガイドライン</span><span class="sxs-lookup"><span data-stu-id="15d7e-234">Guidelines for maps</span></span>](https://msdn.microsoft.com/library/windows/apps/dn596102)

-   [**<span data-ttu-id="15d7e-235">CenterChanged</span><span class="sxs-lookup"><span data-stu-id="15d7e-235">CenterChanged</span></span>**](https://msdn.microsoft.com/library/windows/apps/dn637006)
-   [**<span data-ttu-id="15d7e-236">HeadingChanged</span><span class="sxs-lookup"><span data-stu-id="15d7e-236">HeadingChanged</span></span>**](https://msdn.microsoft.com/library/windows/apps/dn637020)
-   [**<span data-ttu-id="15d7e-237">PitchChanged</span><span class="sxs-lookup"><span data-stu-id="15d7e-237">PitchChanged</span></span>**](https://msdn.microsoft.com/library/windows/apps/dn637045)
-   [**<span data-ttu-id="15d7e-238">ZoomLevelChanged</span><span class="sxs-lookup"><span data-stu-id="15d7e-238">ZoomLevelChanged</span></span>**](https://msdn.microsoft.com/library/windows/apps/dn637069)

## <a name="best-practice-recommendations"></a><span data-ttu-id="15d7e-239">推奨される運用方法</span><span class="sxs-lookup"><span data-stu-id="15d7e-239">Best practice recommendations</span></span>

-   <span data-ttu-id="15d7e-240">ユーザーが地理情報を表示するためにパンとズームを過度に使用しなくて済むように、十分な画面領域 (または画面全体) を使用してマップを表示します。</span><span class="sxs-lookup"><span data-stu-id="15d7e-240">Use ample screen space (or the entire screen) to display the map so that users don't have to pan and zoom excessively to view geographical information.</span></span>

-   <span data-ttu-id="15d7e-241">静的な情報ビューの提示をするためにのみマップを使う場合、小さなマップを使う方が適している場合があります。</span><span class="sxs-lookup"><span data-stu-id="15d7e-241">If the map is only used to present a static, informational view, then using a smaller map might be more appropriate.</span></span> <span data-ttu-id="15d7e-242">小さく静的なマップを使う場合は、使いやすさを考えてサイズを決めます。画面上の領域を十分節約できる程度に小さく、判読しにくくならない程度に大きくします。</span><span class="sxs-lookup"><span data-stu-id="15d7e-242">If you go with a smaller, static map, base its dimensions on usability—small enough to conserve enough screen real estate, but large enough to remain legible.</span></span>

-   <span data-ttu-id="15d7e-243">マップ シーンに関心のあるポイントを埋め込むには、[**MapElements**](https://msdn.microsoft.com/library/windows/apps/dn637034) を使います。その他の情報も、マップ シーンのオーバーレイとして表示される一時的な UI に表示できます。</span><span class="sxs-lookup"><span data-stu-id="15d7e-243">Embed the points of interest in the map scene using [**map elements**](https://msdn.microsoft.com/library/windows/apps/dn637034); any additional information can be displayed as transient UI that overlays the map scene.</span></span>

## <a name="related-topics"></a><span data-ttu-id="15d7e-244">関連トピック</span><span class="sxs-lookup"><span data-stu-id="15d7e-244">Related topics</span></span>

* [<span data-ttu-id="15d7e-245">Bing Maps Developer Center</span><span class="sxs-lookup"><span data-stu-id="15d7e-245">Bing Maps Developer Center</span></span>](https://www.bingmapsportal.com/)
* [<span data-ttu-id="15d7e-246">UWP の地図サンプル</span><span class="sxs-lookup"><span data-stu-id="15d7e-246">UWP map sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkId=619977)
* [<span data-ttu-id="15d7e-247">現在の位置情報の取得</span><span class="sxs-lookup"><span data-stu-id="15d7e-247">Get current location</span></span>](get-location.md)
* [<span data-ttu-id="15d7e-248">位置認識アプリの設計ガイドライン</span><span class="sxs-lookup"><span data-stu-id="15d7e-248">Design guidelines for location-aware apps</span></span>](https://msdn.microsoft.com/library/windows/apps/hh465148)
* [<span data-ttu-id="15d7e-249">地図の設計ガイドライン</span><span class="sxs-lookup"><span data-stu-id="15d7e-249">Design guidelines for maps</span></span>](https://msdn.microsoft.com/library/windows/apps/dn596102)
* [<span data-ttu-id="15d7e-250">Build 2015 のビデオ: Windows アプリでの電話、タブレット、PC で使用できるマップと位置情報の活用</span><span class="sxs-lookup"><span data-stu-id="15d7e-250">Build 2015 video: Leveraging Maps and Location Across Phone, Tablet, and PC in Your Windows Apps</span></span>](https://channel9.msdn.com/Events/Build/2015/2-757)
* [<span data-ttu-id="15d7e-251">UWP の交通情報アプリのサンプル</span><span class="sxs-lookup"><span data-stu-id="15d7e-251">UWP traffic app sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkId=619982)
* [**<span data-ttu-id="15d7e-252">MapControl</span><span class="sxs-lookup"><span data-stu-id="15d7e-252">MapControl</span></span>**](https://msdn.microsoft.com/library/windows/apps/dn637004)
