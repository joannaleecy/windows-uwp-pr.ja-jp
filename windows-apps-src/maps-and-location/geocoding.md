---
title: ジオコーディングと逆ジオコーディングの実行
description: このガイドでは、住所を地理的な場所 (ジオコーディング) に変換し、Windows.Services.Maps 名前空間の MapLocationFinder クラスのメソッドを呼び出すことによって (逆ジオコーディング) の住所を地理的な位置を変換する方法を示します。
ms.assetid: B912BE80-3E1D-43BB-918F-7A43327597D2
ms.date: 07/02/2018
ms.topic: article
keywords: Windows 10, UWP, ジオコーディング, 地図, 位置情報
ms.localizationpriority: medium
ms.openlocfilehash: e8b0efe39578974090844a4224055821c29f8ced
ms.sourcegitcommit: b11f305dbf7649c4b68550b666487c77ea30d98f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/28/2018
ms.locfileid: "7842955"
---
# <a name="perform-geocoding-and-reverse-geocoding"></a>ジオコーディングと逆ジオコーディングの実行

このガイドでは、住所を地理的な場所 (ジオコーディング) に変換[**Windows.Services.Maps で[**MapLocationFinder**](https://msdn.microsoft.com/library/windows/apps/dn627550)クラスのメソッドを呼び出すことによって (逆ジオコーディング) の住所を地理的な位置を変換する方法**](https://msdn.microsoft.com/library/windows/apps/dn636979)名前空間です。

> [!TIP]
> アプリでの地図の使用について詳しくには、github の[Windows ユニバーサル サンプルのリポジトリ](hhttps://github.com/Microsoft/Windows-universal-samples)から[MapControl](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/MapControl)サンプルをダウンロードします。

ジオコーディングや逆ジオコーディングに関連するクラスは、次のように整理されます。

-   [**MapLocationFinder**](https://msdn.microsoft.com/library/windows/apps/dn627550)クラスには、ジオコーディング ([**FindLocationsAsync**](https://msdn.microsoft.com/library/windows/apps/dn636925)) の処理し、逆ジオコーディング ([**FindLocationsAtAsync**](https://msdn.microsoft.com/library/windows/apps/dn636928)) するメソッドが含まれています。
-   このメソッドは、 [**MapLocationFinderResult**](https://msdn.microsoft.com/library/windows/apps/dn627551)インスタンスを返します。
-   [**MapLocationFinderResult**](https://msdn.microsoft.com/library/windows/apps/dn627551)の[**場所**](https://msdn.microsoft.com/library/windows/apps/dn627552)のプロパティは、 [**MapLocation**](https://msdn.microsoft.com/library/windows/apps/dn627549)オブジェクトのコレクションを公開します。 
-   [**MapLocation**](https://msdn.microsoft.com/library/windows/apps/dn627549)オブジェクトは、住所の番地を表す[**MapAddress**](https://msdn.microsoft.com/library/windows/apps/dn627533)オブジェクトを公開するには、[**アドレス**](https://msdn.microsoft.com/library/windows/apps/dn636929)プロパティと地理的な位置を表す[**Geopoint**](https://docs.microsoft.com/uwp/api/windows.devices.geolocation.geopoint)オブジェクトは、公開[**ポイント**](https://docs.microsoft.com/uwp/api/windows.services.maps.maplocation.point)のプロパティの両方があります。

> [!IMPORTANT]
> マップ サービスを使用する前に、マップ認証キーを指定する必要があります。 詳しくは、「[マップ認証キーの要求](authentication-key.md)」をご覧ください。

## <a name="get-a-location-geocode"></a>位置情報の取得 (ジオコーディング)

このセクションでは、住所や地名を地理的な位置 (ジオコーディング) に変換する方法を示します。

1.  場所の名前と住所の番地[**MapLocationFinder**](https://msdn.microsoft.com/library/windows/apps/dn627550)クラスの[**FindLocationsAsync**](https://msdn.microsoft.com/library/windows/apps/dn636925)メソッドのオーバー ロードのいずれかを呼び出します。
2.  [**FindLocationsAsync**](https://msdn.microsoft.com/library/windows/apps/dn636925)メソッドは、 [**MapLocationFinderResult**](https://msdn.microsoft.com/library/windows/apps/dn627551)オブジェクトを返します。
3.  [**MapLocation**](https://msdn.microsoft.com/library/windows/apps/dn627549)オブジェクトのコレクションを公開するのにには、 [**MapLocationFinderResult**](https://msdn.microsoft.com/library/windows/apps/dn627551)の[**場所**](https://msdn.microsoft.com/library/windows/apps/dn627552)のプロパティを使用します。 システムは、特定の入力に対応する複数の場所を見つけることがありますので[**MapLocation**](https://msdn.microsoft.com/library/windows/apps/dn627549)の複数のオブジェクトがかかることがあります。

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

このコードでは、`tbOutputText` テキスト ボックスに次の結果が表示されます。

``` syntax
result = (47.6406099647284,-122.129339994863)
```

## <a name="get-an-address-reverse-geocode"></a>住所の取得 (逆ジオコーディング)

このセクションでは、地理的な位置をアドレス (逆ジオコーディング) に変換する方法を示します。

1.  [**MapLocationFinder**](https://msdn.microsoft.com/library/windows/apps/dn627550) クラスの [**FindLocationsAtAsync**](https://msdn.microsoft.com/library/windows/apps/dn636928) メソッドを呼び出します。
2.  [**FindLocationsAtAsync**](https://msdn.microsoft.com/library/windows/apps/dn636928) メソッドは、一致する [**MapLocation**](https://msdn.microsoft.com/library/windows/apps/dn627549) オブジェクトのコレクションを含む [**MapLocationFinderResult**](https://msdn.microsoft.com/library/windows/apps/dn627551) オブジェクトを返します。
3.  [**MapLocation**](https://msdn.microsoft.com/library/windows/apps/dn627549)オブジェクトのコレクションを公開するのにには、 [**MapLocationFinderResult**](https://msdn.microsoft.com/library/windows/apps/dn627551)の[**場所**](https://msdn.microsoft.com/library/windows/apps/dn627552)のプロパティを使用します。 システムは、特定の入力に対応する複数の場所を見つけることがありますので[**MapLocation**](https://msdn.microsoft.com/library/windows/apps/dn627549)の複数のオブジェクトがかかることがあります。
4.  各[**MapLocation**](https://msdn.microsoft.com/library/windows/apps/dn627549)の[**アドレス**](https://msdn.microsoft.com/library/windows/apps/dn636929)プロパティを通じて[**MapAddress**](https://msdn.microsoft.com/library/windows/apps/dn627533)オブジェクトにアクセスします。

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

このコードでは、`tbOutputText` テキスト ボックスに次の結果が表示されます。

``` syntax
town = Redmond
```

## <a name="related-topics"></a>関連トピック

* [UWP の地図サンプル](http://go.microsoft.com/fwlink/p/?LinkId=619977)
* [UWP の交通情報アプリのサンプル](http://go.microsoft.com/fwlink/p/?LinkId=619982)
* [地図の設計ガイドライン](https://msdn.microsoft.com/library/windows/apps/dn596102)
* [ビデオ: 電話、タブレット、PC、Windows アプリでの間でのマップと位置情報の活用](https://channel9.msdn.com/Events/Build/2015/2-757)
* [Bing Maps Developer Center](https://www.bingmapsportal.com/)
* [**MapLocationFinder** クラス](https://msdn.microsoft.com/library/windows/apps/dn627550)
* [**FindLocationsAsync**メソッド](https://msdn.microsoft.com/library/windows/apps/dn636925)
* [**FindLocationsAtAsync**メソッド](https://msdn.microsoft.com/library/windows/apps/dn636928)
