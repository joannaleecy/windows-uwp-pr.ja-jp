---
author: PatrickFarley
title: ジオコーディングと逆ジオコーディングの実行
description: このガイドでは、住所を地理的な場所 (ジオコーディング) に変換し、Windows.Services.Maps 名前空間の MapLocationFinder クラスのメソッドを呼び出すことによって (逆ジオコーディング) の住所を地理的な位置を変換する方法を示します。
ms.assetid: B912BE80-3E1D-43BB-918F-7A43327597D2
ms.author: pafarley
ms.date: 07/02/2018
ms.topic: article
keywords: Windows 10, UWP, ジオコーディング, 地図, 位置情報
ms.localizationpriority: medium
ms.openlocfilehash: bdd956dece4435ceb8e14121ec2b545095af3a11
ms.sourcegitcommit: 6cc275f2151f78db40c11ace381ee2d35f0155f9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5563237"
---
# <a name="perform-geocoding-and-reverse-geocoding"></a><span data-ttu-id="4f36f-104">ジオコーディングと逆ジオコーディングの実行</span><span class="sxs-lookup"><span data-stu-id="4f36f-104">Perform geocoding and reverse geocoding</span></span>

<span data-ttu-id="4f36f-105">このガイドでは、住所を地理的な場所 (ジオコーディング) に変換[**Windows.Services.Maps で[**MapLocationFinder**](https://msdn.microsoft.com/library/windows/apps/dn627550)クラスのメソッドを呼び出すことによって (逆ジオコーディング) の住所を地理的な位置を変換する方法**](https://msdn.microsoft.com/library/windows/apps/dn636979)名前空間です。</span><span class="sxs-lookup"><span data-stu-id="4f36f-105">This guide shows you how to convert street addresses to geographic locations (geocoding) and convert geographic locations to street addresses (reverse geocoding) by calling the methods of the [**MapLocationFinder**](https://msdn.microsoft.com/library/windows/apps/dn627550) class in the [**Windows.Services.Maps**](https://msdn.microsoft.com/library/windows/apps/dn636979) namespace.</span></span>

> [!TIP]
> <span data-ttu-id="4f36f-106">アプリでの地図の使用について詳しくには、github の[Windows ユニバーサル サンプルのリポジトリ](hhttps://github.com/Microsoft/Windows-universal-samples)から[MapControl](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/MapControl)サンプルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="4f36f-106">To learn more about using maps in your app, download the [MapControl](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/MapControl) sample from the [Windows universal samples repo](hhttps://github.com/Microsoft/Windows-universal-samples) on GitHub.</span></span>

<span data-ttu-id="4f36f-107">ジオコーディングや逆ジオコーディングに関連するクラスは、次のように整理されます。</span><span class="sxs-lookup"><span data-stu-id="4f36f-107">The classes involved in geocoding and reverse geocoding are organized as follows.</span></span>

-   <span data-ttu-id="4f36f-108">[**MapLocationFinder**](https://msdn.microsoft.com/library/windows/apps/dn627550)クラスには、ジオコーディング ([**FindLocationsAsync**](https://msdn.microsoft.com/library/windows/apps/dn636925)) の処理し、逆ジオコーディング ([**FindLocationsAtAsync**](https://msdn.microsoft.com/library/windows/apps/dn636928)) するメソッドが含まれています。</span><span class="sxs-lookup"><span data-stu-id="4f36f-108">The [**MapLocationFinder**](https://msdn.microsoft.com/library/windows/apps/dn627550) class contains methods that handle geocoding ([**FindLocationsAsync**](https://msdn.microsoft.com/library/windows/apps/dn636925)) and reverse geocoding ([**FindLocationsAtAsync**](https://msdn.microsoft.com/library/windows/apps/dn636928)).</span></span>
-   <span data-ttu-id="4f36f-109">このメソッドは、 [**MapLocationFinderResult**](https://msdn.microsoft.com/library/windows/apps/dn627551)インスタンスを返します。</span><span class="sxs-lookup"><span data-stu-id="4f36f-109">These methods both return a [**MapLocationFinderResult**](https://msdn.microsoft.com/library/windows/apps/dn627551) instance.</span></span>
-   <span data-ttu-id="4f36f-110">[**MapLocationFinderResult**](https://msdn.microsoft.com/library/windows/apps/dn627551)の[**場所**](https://msdn.microsoft.com/library/windows/apps/dn627552)のプロパティは、 [**MapLocation**](https://msdn.microsoft.com/library/windows/apps/dn627549)オブジェクトのコレクションを公開します。</span><span class="sxs-lookup"><span data-stu-id="4f36f-110">The [**Locations**](https://msdn.microsoft.com/library/windows/apps/dn627552) property of the [**MapLocationFinderResult**](https://msdn.microsoft.com/library/windows/apps/dn627551) exposes a collection of [**MapLocation**](https://msdn.microsoft.com/library/windows/apps/dn627549) objects.</span></span> 
-   <span data-ttu-id="4f36f-111">[**MapLocation**](https://msdn.microsoft.com/library/windows/apps/dn627549)オブジェクト両方住所の番地を表す[**MapAddress**](https://msdn.microsoft.com/library/windows/apps/dn627533)オブジェクトを公開するには、[**アドレス**](https://msdn.microsoft.com/library/windows/apps/dn636929)プロパティを取得するには、するプロパティがある[**点**](https://docs.microsoft.com/uwp/api/windows.services.maps.maplocation.point)、地理的な位置を表す[**Geopoint**](https://docs.microsoft.com/uwp/api/windows.devices.geolocation.geopoint)オブジェクトを公開します。</span><span class="sxs-lookup"><span data-stu-id="4f36f-111">[**MapLocation**](https://msdn.microsoft.com/library/windows/apps/dn627549) objects have both an [**Address**](https://msdn.microsoft.com/library/windows/apps/dn636929) property, which exposes a [**MapAddress**](https://msdn.microsoft.com/library/windows/apps/dn627533) object representing a street address, and a [**Point**](https://docs.microsoft.com/uwp/api/windows.services.maps.maplocation.point) property, which exposes a [**Geopoint**](https://docs.microsoft.com/uwp/api/windows.devices.geolocation.geopoint) object representing a geographic location.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="4f36f-112">マップ サービスを使用する前に、マップ認証キーを指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4f36f-112">You must specify a maps authentication key before you can use map services.</span></span> <span data-ttu-id="4f36f-113">詳しくは、「[マップ認証キーの要求](authentication-key.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4f36f-113">For more info, see [Request a maps authentication key](authentication-key.md).</span></span>

## <a name="get-a-location-geocode"></a><span data-ttu-id="4f36f-114">位置情報の取得 (ジオコーディング)</span><span class="sxs-lookup"><span data-stu-id="4f36f-114">Get a location (Geocode)</span></span>

<span data-ttu-id="4f36f-115">このセクションでは、住所や地名を地理的な位置 (ジオコーディング) に変換する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="4f36f-115">This section shows how to convert a street address or a place name to a geographic location (geocoding).</span></span>

1.  <span data-ttu-id="4f36f-116">場所の名前と住所の番地[**MapLocationFinder**](https://msdn.microsoft.com/library/windows/apps/dn627550)クラスの[**FindLocationsAsync**](https://msdn.microsoft.com/library/windows/apps/dn636925)メソッドのオーバー ロードのいずれかを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="4f36f-116">Call one of the overloads of the [**FindLocationsAsync**](https://msdn.microsoft.com/library/windows/apps/dn636925) method of the [**MapLocationFinder**](https://msdn.microsoft.com/library/windows/apps/dn627550) class with a place name or street address.</span></span>
2.  <span data-ttu-id="4f36f-117">[**FindLocationsAsync**](https://msdn.microsoft.com/library/windows/apps/dn636925)メソッドは、 [**MapLocationFinderResult**](https://msdn.microsoft.com/library/windows/apps/dn627551)オブジェクトを返します。</span><span class="sxs-lookup"><span data-stu-id="4f36f-117">The [**FindLocationsAsync**](https://msdn.microsoft.com/library/windows/apps/dn636925) method returns a [**MapLocationFinderResult**](https://msdn.microsoft.com/library/windows/apps/dn627551) object.</span></span>
3.  <span data-ttu-id="4f36f-118">コレクションの[**MapLocation**](https://msdn.microsoft.com/library/windows/apps/dn627549)オブジェクトを公開するのにには、 [**MapLocationFinderResult**](https://msdn.microsoft.com/library/windows/apps/dn627551)の[**場所**](https://msdn.microsoft.com/library/windows/apps/dn627552)のプロパティを使用します。</span><span class="sxs-lookup"><span data-stu-id="4f36f-118">Use the [**Locations**](https://msdn.microsoft.com/library/windows/apps/dn627552) property of the [**MapLocationFinderResult**](https://msdn.microsoft.com/library/windows/apps/dn627551) to expose a collection [**MapLocation**](https://msdn.microsoft.com/library/windows/apps/dn627549) objects.</span></span> <span data-ttu-id="4f36f-119">システムは、特定の入力に対応する複数の場所を見つけることがありますので[**MapLocation**](https://msdn.microsoft.com/library/windows/apps/dn627549)の複数のオブジェクトがかかることがあります。</span><span class="sxs-lookup"><span data-stu-id="4f36f-119">There may be multiple [**MapLocation**](https://msdn.microsoft.com/library/windows/apps/dn627549) objects because the system may find multiple locations that correspond to the given input.</span></span>

```csharp
using Windows.Services.Maps;
using Windows.Devices.Geolocation;
...
private async void geocodeButton_Click(object sender, RoutedEventArgs e)
{
   // The address or business to geocode.
   string addressToGeocode = "Microsoft";

   // The nearby location to use as a query hint.
   BasicGeoposition queryHint = new BasicGeoposition();
   queryHint.Latitude = 47.643;
   queryHint.Longitude = -122.131;
   Geopoint hintPoint = new Geopoint(queryHint);

   // Geocode the specified address, using the specified reference point
   // as a query hint. Return no more than 3 results.
   MapLocationFinderResult result =
         await MapLocationFinder.FindLocationsAsync(
                           addressToGeocode,
                           hintPoint,
                           3);

   // If the query returns results, display the coordinates
   // of the first result.
   if (result.Status == MapLocationFinderStatus.Success)
   {
      tbOutputText.Text = "result = (" +
            result.Locations[0].Point.Position.Latitude.ToString() + "," +
            result.Locations[0].Point.Position.Longitude.ToString() + ")";
   }
}
```

<span data-ttu-id="4f36f-120">このコードでは、`tbOutputText` テキスト ボックスに次の結果が表示されます。</span><span class="sxs-lookup"><span data-stu-id="4f36f-120">This code displays the following results to the `tbOutputText` textbox.</span></span>

``` syntax
result = (47.6406099647284,-122.129339994863)
```

## <a name="get-an-address-reverse-geocode"></a><span data-ttu-id="4f36f-121">住所の取得 (逆ジオコーディング)</span><span class="sxs-lookup"><span data-stu-id="4f36f-121">Get an address (reverse geocode)</span></span>

<span data-ttu-id="4f36f-122">このセクションでは、地理的な位置をアドレス (逆ジオコーディング) に変換する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="4f36f-122">This section shows how to convert a geographic location to an address (reverse geocoding).</span></span>

1.  <span data-ttu-id="4f36f-123">[**MapLocationFinder**](https://msdn.microsoft.com/library/windows/apps/dn627550) クラスの [**FindLocationsAtAsync**](https://msdn.microsoft.com/library/windows/apps/dn636928) メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="4f36f-123">Call the [**FindLocationsAtAsync**](https://msdn.microsoft.com/library/windows/apps/dn636928) method of the [**MapLocationFinder**](https://msdn.microsoft.com/library/windows/apps/dn627550) class.</span></span>
2.  <span data-ttu-id="4f36f-124">[**FindLocationsAtAsync**](https://msdn.microsoft.com/library/windows/apps/dn636928) メソッドは、一致する [**MapLocation**](https://msdn.microsoft.com/library/windows/apps/dn627549) オブジェクトのコレクションを含む [**MapLocationFinderResult**](https://msdn.microsoft.com/library/windows/apps/dn627551) オブジェクトを返します。</span><span class="sxs-lookup"><span data-stu-id="4f36f-124">The [**FindLocationsAtAsync**](https://msdn.microsoft.com/library/windows/apps/dn636928) method returns a [**MapLocationFinderResult**](https://msdn.microsoft.com/library/windows/apps/dn627551) object that contains a collection of matching [**MapLocation**](https://msdn.microsoft.com/library/windows/apps/dn627549) objects.</span></span>
3.  <span data-ttu-id="4f36f-125">コレクションの[**MapLocation**](https://msdn.microsoft.com/library/windows/apps/dn627549)オブジェクトを公開するのにには、 [**MapLocationFinderResult**](https://msdn.microsoft.com/library/windows/apps/dn627551)の[**場所**](https://msdn.microsoft.com/library/windows/apps/dn627552)のプロパティを使用します。</span><span class="sxs-lookup"><span data-stu-id="4f36f-125">Use the [**Locations**](https://msdn.microsoft.com/library/windows/apps/dn627552) property of the [**MapLocationFinderResult**](https://msdn.microsoft.com/library/windows/apps/dn627551) to expose a collection [**MapLocation**](https://msdn.microsoft.com/library/windows/apps/dn627549) objects.</span></span> <span data-ttu-id="4f36f-126">システムは、特定の入力に対応する複数の場所を見つけることがありますので[**MapLocation**](https://msdn.microsoft.com/library/windows/apps/dn627549)の複数のオブジェクトがかかることがあります。</span><span class="sxs-lookup"><span data-stu-id="4f36f-126">There may be multiple [**MapLocation**](https://msdn.microsoft.com/library/windows/apps/dn627549) objects because the system may find multiple locations that correspond to the given input.</span></span>
4.  <span data-ttu-id="4f36f-127">各[**MapLocation**](https://msdn.microsoft.com/library/windows/apps/dn627549)の[**アドレス**](https://msdn.microsoft.com/library/windows/apps/dn636929)プロパティを通じて[**MapAddress**](https://msdn.microsoft.com/library/windows/apps/dn627533)オブジェクトにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="4f36f-127">Access [**MapAddress**](https://msdn.microsoft.com/library/windows/apps/dn627533) objects through the [**Address**](https://msdn.microsoft.com/library/windows/apps/dn636929) property of each [**MapLocation**](https://msdn.microsoft.com/library/windows/apps/dn627549).</span></span>

```csharp
using Windows.Services.Maps;
using Windows.Devices.Geolocation;
...
private async void reverseGeocodeButton_Click(object sender, RoutedEventArgs e)
{
   // The location to reverse geocode.
   BasicGeoposition location = new BasicGeoposition();
   location.Latitude = 47.643;
   location.Longitude = -122.131;
   Geopoint pointToReverseGeocode = new Geopoint(location);

   // Reverse geocode the specified geographic location.
   MapLocationFinderResult result =
         await MapLocationFinder.FindLocationsAtAsync(pointToReverseGeocode);

   // If the query returns results, display the name of the town
   // contained in the address of the first result.
   if (result.Status == MapLocationFinderStatus.Success)
   {
      tbOutputText.Text = "town = " +
            result.Locations[0].Address.Town;
   }
}
```

<span data-ttu-id="4f36f-128">このコードでは、`tbOutputText` テキスト ボックスに次の結果が表示されます。</span><span class="sxs-lookup"><span data-stu-id="4f36f-128">This code displays the following results to the `tbOutputText` textbox.</span></span>

``` syntax
town = Redmond
```

## <a name="related-topics"></a><span data-ttu-id="4f36f-129">関連トピック</span><span class="sxs-lookup"><span data-stu-id="4f36f-129">Related topics</span></span>

* [<span data-ttu-id="4f36f-130">UWP の地図サンプル</span><span class="sxs-lookup"><span data-stu-id="4f36f-130">UWP map sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkId=619977)
* [<span data-ttu-id="4f36f-131">UWP の交通情報アプリのサンプル</span><span class="sxs-lookup"><span data-stu-id="4f36f-131">UWP traffic app sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkId=619982)
* [<span data-ttu-id="4f36f-132">地図の設計ガイドライン</span><span class="sxs-lookup"><span data-stu-id="4f36f-132">Design guidelines for maps</span></span>](https://msdn.microsoft.com/library/windows/apps/dn596102)
* [<span data-ttu-id="4f36f-133">ビデオ: 電話、タブレット、PC、Windows アプリでの間でのマップと位置情報の活用</span><span class="sxs-lookup"><span data-stu-id="4f36f-133">Video: Leveraging Maps and Location Across Phone, Tablet, and PC in Your Windows Apps</span></span>](https://channel9.msdn.com/Events/Build/2015/2-757)
* [<span data-ttu-id="4f36f-134">Bing Maps Developer Center</span><span class="sxs-lookup"><span data-stu-id="4f36f-134">Bing Maps Developer Center</span></span>](https://www.bingmapsportal.com/)
* [<span data-ttu-id="4f36f-135">**MapLocationFinder** クラス</span><span class="sxs-lookup"><span data-stu-id="4f36f-135">**MapLocationFinder** class</span></span>](https://msdn.microsoft.com/library/windows/apps/dn627550)
* [<span data-ttu-id="4f36f-136">**FindLocationsAsync**メソッド</span><span class="sxs-lookup"><span data-stu-id="4f36f-136">**FindLocationsAsync** method</span></span>](https://msdn.microsoft.com/library/windows/apps/dn636925)
* [<span data-ttu-id="4f36f-137">**FindLocationsAtAsync**メソッド</span><span class="sxs-lookup"><span data-stu-id="4f36f-137">**FindLocationsAtAsync** method</span></span>](https://msdn.microsoft.com/library/windows/apps/dn636928)
