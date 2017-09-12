---
author: normesta
title: "地図へのルートとルート案内の表示"
description: "ルートとルート案内を要求し、アプリで表示します。"
ms.assetid: BBB4C23A-8F10-41D1-81EA-271BE01AED81
ms.author: normesta
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, ルート, マップ, 位置情報, ルート案内"
ms.openlocfilehash: 83985d986f15602923a21db3d308931397a01767
ms.sourcegitcommit: 378382419f1fda4e4df76ffa9c8cea753d271e6a
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 06/08/2017
---
# <a name="display-routes-and-directions-on-a-map"></a><span data-ttu-id="2d995-104">地図へのルートとルート案内の表示</span><span class="sxs-lookup"><span data-stu-id="2d995-104">Display routes and directions on a map</span></span>


<span data-ttu-id="2d995-105">\[Windows 10 の UWP アプリ向けに更新。</span><span class="sxs-lookup"><span data-stu-id="2d995-105">\[ Updated for UWP apps on Windows 10.</span></span> <span data-ttu-id="2d995-106">Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]</span><span class="sxs-lookup"><span data-stu-id="2d995-106">For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]</span></span>


<span data-ttu-id="2d995-107">ルートとルート案内を要求し、アプリで表示します。</span><span class="sxs-lookup"><span data-stu-id="2d995-107">Request routes and directions, and display them in your app.</span></span>

<span data-ttu-id="2d995-108">**ヒント** アプリで地図を使う方法について詳しくは、GitHub の [Windows-universal-samples リポジトリ](http://go.microsoft.com/fwlink/p/?LinkId=619979)から次のサンプルをダウンロードしてください。</span><span class="sxs-lookup"><span data-stu-id="2d995-108">**Tip** To learn more about using maps in your app, download the following sample from the [Windows-universal-samples repo](http://go.microsoft.com/fwlink/p/?LinkId=619979) on GitHub.</span></span>

-   [<span data-ttu-id="2d995-109">ユニバーサル Windows プラットフォーム (UWP) の地図サンプル</span><span class="sxs-lookup"><span data-stu-id="2d995-109">Universal Windows Platform (UWP) map sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkId=619977)

<span data-ttu-id="2d995-110">**ヒント**  地図表示がアプリの主要機能ではない場合は、代わりに Windows マップ アプリを起動することを検討します。</span><span class="sxs-lookup"><span data-stu-id="2d995-110">**Tip**  If mapping isn't a core feature of your app, consider launching the Windows Maps app instead.</span></span> <span data-ttu-id="2d995-111">`bingmaps:`、`ms-drive-to:`、`ms-walk-to:` の各 UI スキームを使って、Windows マップ アプリを起動し、特定の地図やターン バイ ターン方式のルート案内を表示することができます。</span><span class="sxs-lookup"><span data-stu-id="2d995-111">You can use the `bingmaps:`, `ms-drive-to:`, and `ms-walk-to:` URI schemes to launch the Windows Maps app to specific maps and turn-by-turn directions.</span></span> <span data-ttu-id="2d995-112">詳しくは、「[Windows マップ アプリの起動](https://msdn.microsoft.com/library/windows/apps/mt228341)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="2d995-112">For more info, see [Launch the Windows Maps app](https://msdn.microsoft.com/library/windows/apps/mt228341).</span></span>

 

## <a name="an-intro-to-maproutefinder-results"></a><span data-ttu-id="2d995-113">MapRouteFinder 結果の概要</span><span class="sxs-lookup"><span data-stu-id="2d995-113">An intro to MapRouteFinder results</span></span>


<span data-ttu-id="2d995-114">ルートとルート案内のクラスがどのように関連するかを次に示します。</span><span class="sxs-lookup"><span data-stu-id="2d995-114">Here's how the classes for routes and directions are related:</span></span>

-   <span data-ttu-id="2d995-115">[**MapRouteFinder**](https://msdn.microsoft.com/library/windows/apps/dn636938) クラスには、ルートとルート案内を取得するメソッドがあります。</span><span class="sxs-lookup"><span data-stu-id="2d995-115">The [**MapRouteFinder**](https://msdn.microsoft.com/library/windows/apps/dn636938) class has methods that get routes and directions.</span></span>
-   <span data-ttu-id="2d995-116">これらのメソッドは、[**MapRouteFinderResult**](https://msdn.microsoft.com/library/windows/apps/dn636939) を返します。</span><span class="sxs-lookup"><span data-stu-id="2d995-116">These methods return a [**MapRouteFinderResult**](https://msdn.microsoft.com/library/windows/apps/dn636939).</span></span>
-   <span data-ttu-id="2d995-117">[**MapRouteFinderResult**](https://msdn.microsoft.com/library/windows/apps/dn636939) には [**MapRoute**](https://msdn.microsoft.com/library/windows/apps/dn636937) オブジェクトが含まれています。</span><span class="sxs-lookup"><span data-stu-id="2d995-117">The [**MapRouteFinderResult**](https://msdn.microsoft.com/library/windows/apps/dn636939) contains a [**MapRoute**](https://msdn.microsoft.com/library/windows/apps/dn636937) object.</span></span> <span data-ttu-id="2d995-118">**MapRouteFinderResult** の [**Route**](https://msdn.microsoft.com/library/windows/apps/dn636940) プロパティを通じてこのオブジェクトにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="2d995-118">Access this object through the [**Route**](https://msdn.microsoft.com/library/windows/apps/dn636940) property of the **MapRouteFinderResult**.</span></span>
-   <span data-ttu-id="2d995-119">[**MapRoute**](https://msdn.microsoft.com/library/windows/apps/dn636937) には、[**MapRouteLeg**](https://msdn.microsoft.com/library/windows/apps/dn636955) オブジェクトのコレクションが含まれています。</span><span class="sxs-lookup"><span data-stu-id="2d995-119">The [**MapRoute**](https://msdn.microsoft.com/library/windows/apps/dn636937) contains a collection of [**MapRouteLeg**](https://msdn.microsoft.com/library/windows/apps/dn636955) objects.</span></span> <span data-ttu-id="2d995-120">**MapRoute** の [**Legs**](https://msdn.microsoft.com/library/windows/apps/dn636973) プロパティを通じてこのコレクションにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="2d995-120">Access this collection through the [**Legs**](https://msdn.microsoft.com/library/windows/apps/dn636973) property of the **MapRoute**.</span></span>
-   <span data-ttu-id="2d995-121">各 [**MapRouteLeg**](https://msdn.microsoft.com/library/windows/apps/dn636955) には、[**MapRouteManeuver**](https://msdn.microsoft.com/library/windows/apps/dn636961) オブジェクトのコレクションが含まれています。</span><span class="sxs-lookup"><span data-stu-id="2d995-121">Each [**MapRouteLeg**](https://msdn.microsoft.com/library/windows/apps/dn636955) contains a collection of [**MapRouteManeuver**](https://msdn.microsoft.com/library/windows/apps/dn636961) objects.</span></span> <span data-ttu-id="2d995-122">**MapRouteLeg** の [**Maneuvers**](https://msdn.microsoft.com/library/windows/apps/dn636959) プロパティを通じてこのコレクションにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="2d995-122">Access this collection through the [**Maneuvers**](https://msdn.microsoft.com/library/windows/apps/dn636959) property of the **MapRouteLeg**.</span></span>

## <a name="display-directions"></a><span data-ttu-id="2d995-123">ルート案内の表示</span><span class="sxs-lookup"><span data-stu-id="2d995-123">Display directions</span></span>


<span data-ttu-id="2d995-124">自動車ルートや徒歩ルート、ルート案内を取得するには、[**MapRouteFinder**](https://msdn.microsoft.com/library/windows/apps/dn636938) クラスのメソッド ([**GetDrivingRouteAsync**](https://msdn.microsoft.com/library/windows/apps/dn636943)、[**GetWalkingRouteAsync**](https://msdn.microsoft.com/library/windows/apps/dn636953) など) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="2d995-124">Get a driving or walking route and directions by calling the methods of the [**MapRouteFinder**](https://msdn.microsoft.com/library/windows/apps/dn636938) class—for example, [**GetDrivingRouteAsync**](https://msdn.microsoft.com/library/windows/apps/dn636943) or [**GetWalkingRouteAsync**](https://msdn.microsoft.com/library/windows/apps/dn636953).</span></span> <span data-ttu-id="2d995-125">[**MapRouteFinderResult**](https://msdn.microsoft.com/library/windows/apps/dn636939) オブジェクトには [**MapRoute**](https://msdn.microsoft.com/library/windows/apps/dn636937) オブジェクトが含まれており、[**Route**](https://msdn.microsoft.com/library/windows/apps/dn636940) プロパティを使ってアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="2d995-125">The [**MapRouteFinderResult**](https://msdn.microsoft.com/library/windows/apps/dn636939) object contains a [**MapRoute**](https://msdn.microsoft.com/library/windows/apps/dn636937) object that you can access through its [**Route**](https://msdn.microsoft.com/library/windows/apps/dn636940) property.</span></span>

<span data-ttu-id="2d995-126">ルートを要求する場合は、次の指定を行うことができます。</span><span class="sxs-lookup"><span data-stu-id="2d995-126">When you request a route, you can specify the following things:</span></span>

-   <span data-ttu-id="2d995-127">始点と終点のみを指定するか、ルートを計算する一連の中間点を指定できます。</span><span class="sxs-lookup"><span data-stu-id="2d995-127">You can provide a start point and end point only, or you can provide a series of waypoints to compute the route.</span></span>
-   <span data-ttu-id="2d995-128">最適化を指定できます。たとえば、距離を最小にします。</span><span class="sxs-lookup"><span data-stu-id="2d995-128">You can specify optimizations - for example, minimize the distance.</span></span>
-   <span data-ttu-id="2d995-129">制限を指定できます。たとえば、高速道路を回避できます。</span><span class="sxs-lookup"><span data-stu-id="2d995-129">You can specify restrictions - for example, avoid highways.</span></span>

<span data-ttu-id="2d995-130">計算された [**MapRoute**](https://msdn.microsoft.com/library/windows/apps/dn636937) には、ルートの移動にかかる時間、ルートの距離、およびルートの区間を含む [**MapRouteLeg**](https://msdn.microsoft.com/library/windows/apps/dn636955) オブジェクトのコレクションを提供するプロパティがあります。</span><span class="sxs-lookup"><span data-stu-id="2d995-130">The computed [**MapRoute**](https://msdn.microsoft.com/library/windows/apps/dn636937) has properties that provide the time to traverse the route, the length of the route, and the collection of [**MapRouteLeg**](https://msdn.microsoft.com/library/windows/apps/dn636955) objects that contain the legs of the route.</span></span> <span data-ttu-id="2d995-131">各 **MapRouteLeg** オブジェクトには、[**MapRouteManeuver**](https://msdn.microsoft.com/library/windows/apps/dn636961) オブジェクトのコレクションが含まれています。</span><span class="sxs-lookup"><span data-stu-id="2d995-131">Each **MapRouteLeg** object contains a collection of [**MapRouteManeuver**](https://msdn.microsoft.com/library/windows/apps/dn636961) objects.</span></span> <span data-ttu-id="2d995-132">**MapRouteManeuver** オブジェクトにはルート案内が含まれており、[**InstructionText**](https://msdn.microsoft.com/library/windows/apps/dn636964) プロパティを使ってアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="2d995-132">The **MapRouteManeuver** object contains directions that you can access through its [**InstructionText**](https://msdn.microsoft.com/library/windows/apps/dn636964) property.</span></span>

<span data-ttu-id="2d995-133">**重要**  マップ サービスを使用する前に、マップ認証キーを指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="2d995-133">**Important**  You must specify a maps authentication key before you can use map services.</span></span> <span data-ttu-id="2d995-134">詳しくは、「[マップ認証キーの要求](authentication-key.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="2d995-134">For more info, see [Request a maps authentication key](authentication-key.md).</span></span>

 

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

<span data-ttu-id="2d995-135">この例では、`tbOutputText` テキスト ボックスに次の結果が表示されます。</span><span class="sxs-lookup"><span data-stu-id="2d995-135">This example displays the following results to the `tbOutputText` text box.</span></span>

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

## <a name="display-routes"></a><span data-ttu-id="2d995-136">ルートの表示</span><span class="sxs-lookup"><span data-stu-id="2d995-136">Display routes</span></span>


<span data-ttu-id="2d995-137">[**MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004) に [**MapRoute**](https://msdn.microsoft.com/library/windows/apps/dn636937) を表示するには、**MapRoute** を使って [**MapRouteView**](https://msdn.microsoft.com/library/windows/apps/dn637122) を構成します。</span><span class="sxs-lookup"><span data-stu-id="2d995-137">To display a [**MapRoute**](https://msdn.microsoft.com/library/windows/apps/dn636937) on a [**MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004), construct a [**MapRouteView**](https://msdn.microsoft.com/library/windows/apps/dn637122) with the **MapRoute**.</span></span> <span data-ttu-id="2d995-138">次に、**MapControl** の [**Routes**](https://msdn.microsoft.com/library/windows/apps/dn637047) コレクションに **MapRouteView** を追加します。</span><span class="sxs-lookup"><span data-stu-id="2d995-138">Then, add the **MapRouteView** to the [**Routes**](https://msdn.microsoft.com/library/windows/apps/dn637047) collection of the **MapControl**.</span></span>

<span data-ttu-id="2d995-139">**重要**  マップ サービスまたはマップ コントロールを使用する前に、マップ認証キーを指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="2d995-139">**Important**  You must specify a maps authentication key before you can use map services or the map control.</span></span> <span data-ttu-id="2d995-140">詳しくは、「[マップ認証キーの要求](authentication-key.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="2d995-140">For more info, see [Request a maps authentication key](authentication-key.md).</span></span>

 

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

<span data-ttu-id="2d995-141">この例では、**MapWithRoute** という名前の [**MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004) に次のルートが表示されます。</span><span class="sxs-lookup"><span data-stu-id="2d995-141">This example displays the following on a [**MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004) named **MapWithRoute**.</span></span>

![ルートが表示されたマップ コントロール。](images/routeonmap.png)

## <a name="related-topics"></a><span data-ttu-id="2d995-143">関連トピック</span><span class="sxs-lookup"><span data-stu-id="2d995-143">Related topics</span></span>

* [<span data-ttu-id="2d995-144">Bing Maps Developer Center</span><span class="sxs-lookup"><span data-stu-id="2d995-144">Bing Maps Developer Center</span></span>](https://www.bingmapsportal.com/)
* [<span data-ttu-id="2d995-145">UWP の地図サンプル</span><span class="sxs-lookup"><span data-stu-id="2d995-145">UWP map sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkId=619977)
* [<span data-ttu-id="2d995-146">地図の設計ガイドライン</span><span class="sxs-lookup"><span data-stu-id="2d995-146">Design guidelines for maps</span></span>](https://msdn.microsoft.com/library/windows/apps/dn596102)
* [<span data-ttu-id="2d995-147">Build 2015 のビデオ: Windows アプリでの電話、タブレット、PC で使用できるマップと位置情報の活用</span><span class="sxs-lookup"><span data-stu-id="2d995-147">Build 2015 video: Leveraging Maps and Location Across Phone, Tablet, and PC in Your Windows Apps</span></span>](https://channel9.msdn.com/Events/Build/2015/2-757)
* [<span data-ttu-id="2d995-148">UWP の交通情報アプリのサンプル</span><span class="sxs-lookup"><span data-stu-id="2d995-148">UWP traffic app sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkId=619982)
