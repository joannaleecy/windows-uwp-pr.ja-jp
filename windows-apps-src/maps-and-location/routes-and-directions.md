---
title: 地図へのルートとルート案内の表示
description: ルートとルート案内を要求し、アプリで表示します。
ms.assetid: BBB4C23A-8F10-41D1-81EA-271BE01AED81
ms.date: 09/20/2017
ms.topic: article
keywords: Windows 10, UWP, ルート, マップ, 位置情報, ルート案内
ms.localizationpriority: medium
ms.openlocfilehash: dd93a092ee0db0821e9326d0f9ffa86890850b87
ms.sourcegitcommit: 89ff8ff88ef58f4fe6d3b1368fe94f62e59118ad
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/30/2018
ms.locfileid: "8216076"
---
# <a name="display-routes-and-directions-on-a-map"></a><span data-ttu-id="92acb-104">地図へのルートとルート案内の表示</span><span class="sxs-lookup"><span data-stu-id="92acb-104">Display routes and directions on a map</span></span>



<span data-ttu-id="92acb-105">ルートとルート案内を要求し、アプリで表示します。</span><span class="sxs-lookup"><span data-stu-id="92acb-105">Request routes and directions, and display them in your app.</span></span>

>[!Note]
><span data-ttu-id="92acb-106">アプリでの地図の使用について詳しくは、[ユニバーサル Windows プラットフォーム (UWP) の地図サンプル](http://go.microsoft.com/fwlink/p/?LinkId=619977)をダウンロードしてください。</span><span class="sxs-lookup"><span data-stu-id="92acb-106">To learn more about using maps in your app, download the [Universal Windows Platform (UWP) map sample](http://go.microsoft.com/fwlink/p/?LinkId=619977).</span></span>
><span data-ttu-id="92acb-107">地図表示がアプリの主要機能でない場合は、代わりに Windows マップ アプリを起動することを検討します。</span><span class="sxs-lookup"><span data-stu-id="92acb-107">If mapping isn't a core feature of your app, consider launching the Windows Maps app instead.</span></span> <span data-ttu-id="92acb-108">`bingmaps:`、`ms-drive-to:`、`ms-walk-to:` の各 UI スキームを使って、Windows マップ アプリを起動し、特定の地図やターン バイ ターン方式のルート案内を表示することができます。</span><span class="sxs-lookup"><span data-stu-id="92acb-108">You can use the `bingmaps:`, `ms-drive-to:`, and `ms-walk-to:` URI schemes to launch the Windows Maps app to specific maps and turn-by-turn directions.</span></span> <span data-ttu-id="92acb-109">詳しくは、「[Windows マップ アプリの起動](https://msdn.microsoft.com/library/windows/apps/mt228341)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="92acb-109">For more info, see [Launch the Windows Maps app](https://msdn.microsoft.com/library/windows/apps/mt228341).</span></span>

 
## <a name="an-intro-to-maproutefinder-results"></a><span data-ttu-id="92acb-110">MapRouteFinder 結果の概要</span><span class="sxs-lookup"><span data-stu-id="92acb-110">An intro to MapRouteFinder results</span></span>


<span data-ttu-id="92acb-111">ルートとルート案内のクラスがどのように関連するかを次に示します。</span><span class="sxs-lookup"><span data-stu-id="92acb-111">Here's how the classes for routes and directions are related:</span></span>

* <span data-ttu-id="92acb-112">[**MapRouteFinder**](https://msdn.microsoft.com/library/windows/apps/dn636938) クラスには、ルートとルート案内を取得するメソッドがあります。</span><span class="sxs-lookup"><span data-stu-id="92acb-112">The [**MapRouteFinder**](https://msdn.microsoft.com/library/windows/apps/dn636938) class has methods that get routes and directions.</span></span> <span data-ttu-id="92acb-113">これらのメソッドは、[**MapRouteFinderResult**](https://msdn.microsoft.com/library/windows/apps/dn636939) を返します。</span><span class="sxs-lookup"><span data-stu-id="92acb-113">These methods return a [**MapRouteFinderResult**](https://msdn.microsoft.com/library/windows/apps/dn636939).</span></span>

* <span data-ttu-id="92acb-114">[**MapRouteFinderResult**](https://msdn.microsoft.com/library/windows/apps/dn636939) には [**MapRoute**](https://msdn.microsoft.com/library/windows/apps/dn636937) オブジェクトが含まれています。</span><span class="sxs-lookup"><span data-stu-id="92acb-114">The [**MapRouteFinderResult**](https://msdn.microsoft.com/library/windows/apps/dn636939) contains a [**MapRoute**](https://msdn.microsoft.com/library/windows/apps/dn636937) object.</span></span> <span data-ttu-id="92acb-115">**MapRouteFinderResult** の [**Route**](https://msdn.microsoft.com/library/windows/apps/dn636940) プロパティを通じてこのオブジェクトにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="92acb-115">Access this object through the [**Route**](https://msdn.microsoft.com/library/windows/apps/dn636940) property of the **MapRouteFinderResult**.</span></span>

* <span data-ttu-id="92acb-116">[**MapRoute**](https://msdn.microsoft.com/library/windows/apps/dn636937) には、[**MapRouteLeg**](https://msdn.microsoft.com/library/windows/apps/dn636955) オブジェクトのコレクションが含まれています。</span><span class="sxs-lookup"><span data-stu-id="92acb-116">The [**MapRoute**](https://msdn.microsoft.com/library/windows/apps/dn636937) contains a collection of [**MapRouteLeg**](https://msdn.microsoft.com/library/windows/apps/dn636955) objects.</span></span> <span data-ttu-id="92acb-117">**MapRoute** の [**Legs**](https://msdn.microsoft.com/library/windows/apps/dn636973) プロパティを通じてこのコレクションにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="92acb-117">Access this collection through the [**Legs**](https://msdn.microsoft.com/library/windows/apps/dn636973) property of the **MapRoute**.</span></span>

* <span data-ttu-id="92acb-118">各 [**MapRouteLeg**](https://msdn.microsoft.com/library/windows/apps/dn636955) には、[**MapRouteManeuver**](https://msdn.microsoft.com/library/windows/apps/dn636961) オブジェクトのコレクションが含まれています。</span><span class="sxs-lookup"><span data-stu-id="92acb-118">Each [**MapRouteLeg**](https://msdn.microsoft.com/library/windows/apps/dn636955) contains a collection of [**MapRouteManeuver**](https://msdn.microsoft.com/library/windows/apps/dn636961) objects.</span></span> <span data-ttu-id="92acb-119">**MapRouteLeg** の [**Maneuvers**](https://msdn.microsoft.com/library/windows/apps/dn636959) プロパティを通じてこのコレクションにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="92acb-119">Access this collection through the [**Maneuvers**](https://msdn.microsoft.com/library/windows/apps/dn636959) property of the **MapRouteLeg**.</span></span>

<span data-ttu-id="92acb-120">自動車や徒歩でのルートとルート案内を取得するには、[**MapRouteFinder**](https://msdn.microsoft.com/library/windows/apps/dn636938) クラスのメソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="92acb-120">Get a driving or walking route and directions by calling the methods of the [**MapRouteFinder**](https://msdn.microsoft.com/library/windows/apps/dn636938) class.</span></span> <span data-ttu-id="92acb-121">たとえば、[**GetDrivingRouteAsync**](https://msdn.microsoft.com/library/windows/apps/dn636943) や [**GetWalkingRouteAsync**](https://msdn.microsoft.com/library/windows/apps/dn636953) を使用できます。</span><span class="sxs-lookup"><span data-stu-id="92acb-121">For example, [**GetDrivingRouteAsync**](https://msdn.microsoft.com/library/windows/apps/dn636943) or [**GetWalkingRouteAsync**](https://msdn.microsoft.com/library/windows/apps/dn636953).</span></span>

<span data-ttu-id="92acb-122">ルートを要求する場合は、次の指定を行うことができます。</span><span class="sxs-lookup"><span data-stu-id="92acb-122">When you request a route, you can specify the following things:</span></span>

* <span data-ttu-id="92acb-123">始点と終点のみを指定するか、ルートを計算する一連の中間点を指定できます。</span><span class="sxs-lookup"><span data-stu-id="92acb-123">You can provide a start point and end point only, or you can provide a series of waypoints to compute the route.</span></span>

    <span data-ttu-id="92acb-124">*立寄地*を指定するとルート区間が追加され、各区間に独自の旅程が設定されます。</span><span class="sxs-lookup"><span data-stu-id="92acb-124">*Stop* waypoints adds additional route legs, each with their own Itinerary.</span></span> <span data-ttu-id="92acb-125">*立寄地*を指定するには、[**GetDrivingRouteFromWaypointsAsync**](https://docs.microsoft.com/uwp/api/windows.services.maps.maproutefinder.getwalkingroutefromwaypointsasync) のオーバーロードのいずれかを使います。</span><span class="sxs-lookup"><span data-stu-id="92acb-125">To specify *stop* waypoints, use any of the [**GetDrivingRouteFromWaypointsAsync**](https://docs.microsoft.com/uwp/api/windows.services.maps.maproutefinder.getwalkingroutefromwaypointsasync) overloads.</span></span>

    <span data-ttu-id="92acb-126">*経由地*は、*立寄地*どうしの間の中間点を定義します。</span><span class="sxs-lookup"><span data-stu-id="92acb-126">*Via* waypoint defines intermediate locations between *stop* waypoints.</span></span> <span data-ttu-id="92acb-127">ルート区間は追加されません。</span><span class="sxs-lookup"><span data-stu-id="92acb-127">They do not add route legs.</span></span>  <span data-ttu-id="92acb-128">これらは、通過する必要のあるルート上の中間点を示すだけです。</span><span class="sxs-lookup"><span data-stu-id="92acb-128">They are merely waypoints that a route must pass through.</span></span> <span data-ttu-id="92acb-129">*経由地*を指定するには、[**GetDrivingRouteFromEnhancedWaypointsAsync**](https://docs.microsoft.com/uwp/api/windows.services.maps.maproutefinder.getdrivingroutefromenhancedwaypointsasync) のオーバーロードのいずれかを使います。</span><span class="sxs-lookup"><span data-stu-id="92acb-129">To specify *via* waypoints, use any of the [**GetDrivingRouteFromEnhancedWaypointsAsync**](https://docs.microsoft.com/uwp/api/windows.services.maps.maproutefinder.getdrivingroutefromenhancedwaypointsasync) overloads.</span></span>

* <span data-ttu-id="92acb-130">最適化を指定できます (例: 距離を最短にする)。</span><span class="sxs-lookup"><span data-stu-id="92acb-130">You can specify optimizations (For example: minimize the distance).</span></span>

* <span data-ttu-id="92acb-131">制限を指定できます (例: 高速道路を回避する)。</span><span class="sxs-lookup"><span data-stu-id="92acb-131">You can specify restrictions (For example: avoid highways).</span></span>

## <a name="display-directions"></a><span data-ttu-id="92acb-132">ルート案内の表示</span><span class="sxs-lookup"><span data-stu-id="92acb-132">Display directions</span></span>

<span data-ttu-id="92acb-133">[**MapRouteFinderResult**](https://msdn.microsoft.com/library/windows/apps/dn636939) オブジェクトには [**MapRoute**](https://msdn.microsoft.com/library/windows/apps/dn636937) オブジェクトが含まれており、[**Route**](https://msdn.microsoft.com/library/windows/apps/dn636940) プロパティを使ってアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="92acb-133">The [**MapRouteFinderResult**](https://msdn.microsoft.com/library/windows/apps/dn636939) object contains a [**MapRoute**](https://msdn.microsoft.com/library/windows/apps/dn636937) object that you can access through its [**Route**](https://msdn.microsoft.com/library/windows/apps/dn636940) property.</span></span>

<span data-ttu-id="92acb-134">計算された [**MapRoute**](https://msdn.microsoft.com/library/windows/apps/dn636937) には、ルートの移動にかかる時間、ルートの距離、およびルートの区間を含む [**MapRouteLeg**](https://msdn.microsoft.com/library/windows/apps/dn636955) オブジェクトのコレクションを提供するプロパティがあります。</span><span class="sxs-lookup"><span data-stu-id="92acb-134">The computed [**MapRoute**](https://msdn.microsoft.com/library/windows/apps/dn636937) has properties that provide the time to traverse the route, the length of the route, and the collection of [**MapRouteLeg**](https://msdn.microsoft.com/library/windows/apps/dn636955) objects that contain the legs of the route.</span></span> <span data-ttu-id="92acb-135">各 **MapRouteLeg** オブジェクトには、[**MapRouteManeuver**](https://msdn.microsoft.com/library/windows/apps/dn636961) オブジェクトのコレクションが含まれています。</span><span class="sxs-lookup"><span data-stu-id="92acb-135">Each **MapRouteLeg** object contains a collection of [**MapRouteManeuver**](https://msdn.microsoft.com/library/windows/apps/dn636961) objects.</span></span> <span data-ttu-id="92acb-136">**MapRouteManeuver** オブジェクトにはルート案内が含まれており、[**InstructionText**](https://msdn.microsoft.com/library/windows/apps/dn636964) プロパティを使ってアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="92acb-136">The **MapRouteManeuver** object contains directions that you can access through its [**InstructionText**](https://msdn.microsoft.com/library/windows/apps/dn636964) property.</span></span>

>[!IMPORTANT]
><span data-ttu-id="92acb-137">マップ サービスを使用する前に、マップ認証キーを指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="92acb-137">You must specify a maps authentication key before you can use map services.</span></span> <span data-ttu-id="92acb-138">詳しくは、「[マップ認証キーの要求](authentication-key.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="92acb-138">For more info, see [Request a maps authentication key](authentication-key.md).</span></span>

 

```csharp
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Services.Maps;
using Windows.Devices.Geolocation;
...
private async void button_Click(object sender, RoutedEventArgs e)
{
   // Start at Microsoft in Redmond, Washington.
   BasicGeoposition startLocation = new BasicGeoposition() {Latitude=47.643,Longitude=-122.131};

   // End at the city of Seattle, Washington.
   BasicGeoposition endLocation = new BasicGeoposition() {Latitude = 47.604,Longitude= -122.329};

   // Get the route between the points.
   MapRouteFinderResult routeResult =
         await MapRouteFinder.GetDrivingRouteAsync(
         new Geopoint(startLocation),
         new Geopoint(endLocation),
         MapRouteOptimization.Time,
         MapRouteRestrictions.None);

   if (routeResult.Status == MapRouteFinderStatus.Success)
   {
      System.Text.StringBuilder routeInfo = new System.Text.StringBuilder();

      // Display summary info about the route.
      routeInfo.Append("Total estimated time (minutes) = ");
      routeInfo.Append(routeResult.Route.EstimatedDuration.TotalMinutes.ToString());
      routeInfo.Append("\nTotal length (kilometers) = ");
      routeInfo.Append((routeResult.Route.LengthInMeters / 1000).ToString());

      // Display the directions.
      routeInfo.Append("\n\nDIRECTIONS\n");

      foreach (MapRouteLeg leg in routeResult.Route.Legs)
      {
         foreach (MapRouteManeuver maneuver in leg.Maneuvers)
         {
            routeInfo.AppendLine(maneuver.InstructionText);
         }
      }

      // Load the text box.
      tbOutputText.Text = routeInfo.ToString();
   }
   else
   {
      tbOutputText.Text =
            "A problem occurred: " + routeResult.Status.ToString();
   }
}
```

<span data-ttu-id="92acb-139">この例では、`tbOutputText` テキスト ボックスに次の結果が表示されます。</span><span class="sxs-lookup"><span data-stu-id="92acb-139">This example displays the following results to the `tbOutputText` text box.</span></span>

``` syntax
Total estimated time (minutes) = 18.4833333333333
Total length (kilometers) = 21.847

DIRECTIONS
Head north on 157th Ave NE.
Turn left onto 159th Ave NE.
Turn left onto NE 40th St.
Turn left onto WA-520 W.
Enter the freeway WA-520 from the right.
Keep left onto I-5 S/Portland.
Keep right and leave the freeway at exit 165A towards James St..
Turn right onto James St.
You have reached your destination.
```

## <a name="display-routes"></a><span data-ttu-id="92acb-140">ルートの表示</span><span class="sxs-lookup"><span data-stu-id="92acb-140">Display routes</span></span>


<span data-ttu-id="92acb-141">[**MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004) に [**MapRoute**](https://msdn.microsoft.com/library/windows/apps/dn636937) を表示するには、**MapRoute** を使って [**MapRouteView**](https://msdn.microsoft.com/library/windows/apps/dn637122) を構成します。</span><span class="sxs-lookup"><span data-stu-id="92acb-141">To display a [**MapRoute**](https://msdn.microsoft.com/library/windows/apps/dn636937) on a [**MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004), construct a [**MapRouteView**](https://msdn.microsoft.com/library/windows/apps/dn637122) with the **MapRoute**.</span></span> <span data-ttu-id="92acb-142">次に、**MapControl** の [**Routes**](https://msdn.microsoft.com/library/windows/apps/dn637047) コレクションに **MapRouteView** を追加します。</span><span class="sxs-lookup"><span data-stu-id="92acb-142">Then, add the **MapRouteView** to the [**Routes**](https://msdn.microsoft.com/library/windows/apps/dn637047) collection of the **MapControl**.</span></span>

>[!IMPORTANT]
><span data-ttu-id="92acb-143">マップ サービスまたはマップ コントロールを使用する前に、マップ認証キーを指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="92acb-143">You must specify a maps authentication key before you can use map services or the map control.</span></span> <span data-ttu-id="92acb-144">詳しくは、「[マップ認証キーの要求](authentication-key.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="92acb-144">For more info, see [Request a maps authentication key](authentication-key.md).</span></span>

 

```csharp
using System;
using Windows.Devices.Geolocation;
using Windows.Services.Maps;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
...
private async void ShowRouteOnMap()
{
   // Start at Microsoft in Redmond, Washington.
   BasicGeoposition startLocation = new BasicGeoposition() { Latitude = 47.643, Longitude = -122.131 };

   // End at the city of Seattle, Washington.
   BasicGeoposition endLocation = new BasicGeoposition() { Latitude = 47.604, Longitude = -122.329 };


   // Get the route between the points.
   MapRouteFinderResult routeResult =
         await MapRouteFinder.GetDrivingRouteAsync(
         new Geopoint(startLocation),
         new Geopoint(endLocation),
         MapRouteOptimization.Time,
         MapRouteRestrictions.None);

   if (routeResult.Status == MapRouteFinderStatus.Success)
   {
      // Use the route to initialize a MapRouteView.
      MapRouteView viewOfRoute = new MapRouteView(routeResult.Route);
      viewOfRoute.RouteColor = Colors.Yellow;
      viewOfRoute.OutlineColor = Colors.Black;

      // Add the new MapRouteView to the Routes collection
      // of the MapControl.
      MapWithRoute.Routes.Add(viewOfRoute);

      // Fit the MapControl to the route.
      await MapWithRoute.TrySetViewBoundsAsync(
            routeResult.Route.BoundingBox,
            null,
            Windows.UI.Xaml.Controls.Maps.MapAnimationKind.None);
   }
}
```

<span data-ttu-id="92acb-145">この例では、**MapWithRoute** という名前の [**MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004) に次のルートが表示されます。</span><span class="sxs-lookup"><span data-stu-id="92acb-145">This example displays the following on a [**MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004) named **MapWithRoute**.</span></span>

![ルートが表示されたマップ コントロール。](images/routeonmap.png)

<span data-ttu-id="92acb-147">同じ例を使って、2 つの*立寄地*の間に 1 つの*経由地*を指定するバージョンを次に示します。</span><span class="sxs-lookup"><span data-stu-id="92acb-147">Here's a version of this example that uses a *via* waypoint in between two *stop* waypoints:</span></span>

```csharp
using System;
using Windows.Devices.Geolocation;
using Windows.Services.Maps;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
...
private async void ShowRouteOnMap()
{
  Geolocator locator = new Geolocator();
  locator.DesiredAccuracyInMeters = 1;
  locator.PositionChanged += Locator_PositionChanged;

  BasicGeoposition point1 = new BasicGeoposition() { Latitude = 47.649693, Longitude = -122.144908 };
  BasicGeoposition point2 = new BasicGeoposition() { Latitude = 47.6205, Longitude = -122.3493 };
  BasicGeoposition point3 = new BasicGeoposition() { Latitude = 48.649693, Longitude = -122.144908 };

  // Get Driving Route from point A  to point B thru point C
  var path = new List<EnhancedWaypoint>();

  path.Add(new EnhancedWaypoint(new Geopoint(point1), WaypointKind.Stop));
  path.Add(new EnhancedWaypoint(new Geopoint(point2), WaypointKind.Via));
  path.Add(new EnhancedWaypoint(new Geopoint(point3), WaypointKind.Stop));

  MapRouteFinderResult routeResult =  await MapRouteFinder.GetDrivingRouteFromEnhancedWaypointsAsync(path);

  if (routeResult.Status == MapRouteFinderStatus.Success)
  {
      MapRouteView viewOfRoute = new MapRouteView(routeResult.Route);
      viewOfRoute.RouteColor = Colors.Yellow;
      viewOfRoute.OutlineColor = Colors.Black;

      myMap.Routes.Add(viewOfRoute);

      await myMap.TrySetViewBoundsAsync(
            routeResult.Route.BoundingBox,
            null,
            Windows.UI.Xaml.Controls.Maps.MapAnimationKind.None);
  }
}
```

## <a name="related-topics"></a><span data-ttu-id="92acb-148">関連トピック</span><span class="sxs-lookup"><span data-stu-id="92acb-148">Related topics</span></span>

* [<span data-ttu-id="92acb-149">Bing Maps Developer Center</span><span class="sxs-lookup"><span data-stu-id="92acb-149">Bing Maps Developer Center</span></span>](https://www.bingmapsportal.com/)
* [<span data-ttu-id="92acb-150">UWP の地図サンプル</span><span class="sxs-lookup"><span data-stu-id="92acb-150">UWP map sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkId=619977)
* [<span data-ttu-id="92acb-151">地図の設計ガイドライン</span><span class="sxs-lookup"><span data-stu-id="92acb-151">Design guidelines for maps</span></span>](https://msdn.microsoft.com/library/windows/apps/dn596102)
* [<span data-ttu-id="92acb-152">Build 2015 のビデオ: Windows アプリでの電話、タブレット、PC で使用できるマップと位置情報の活用</span><span class="sxs-lookup"><span data-stu-id="92acb-152">Build 2015 video: Leveraging Maps and Location Across Phone, Tablet, and PC in Your Windows Apps</span></span>](https://channel9.msdn.com/Events/Build/2015/2-757)
* [<span data-ttu-id="92acb-153">UWP の交通情報アプリのサンプル</span><span class="sxs-lookup"><span data-stu-id="92acb-153">UWP traffic app sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkId=619982)
