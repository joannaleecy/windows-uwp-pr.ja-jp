---
author: PatrickFarley
title: "ジオコーディングと逆ジオコーディングの実行"
description: "住所から地理的な位置への変換 (ジオコーディング) や地理的な位置から住所への変換 (逆ジオコーディング) を行うには、Windows.Services.Maps 名前空間の MapLocationFinder クラスのメソッドを呼び出します。"
ms.assetid: B912BE80-3E1D-43BB-918F-7A43327597D2
translationtype: Human Translation
ms.sourcegitcommit: 6530fa257ea3735453a97eb5d916524e750e62fc
ms.openlocfilehash: caf3ad6fecd6ed90c65f85477643fb42ab4787d3

---

# ジオコーディングと逆ジオコーディングの実行


\[ Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください \]


住所から地理的な位置への変換 (ジオコーディング) や地理的な位置から住所への変換 (逆ジオコーディング) を行うには、[**Windows.Services.Maps**](https://msdn.microsoft.com/library/windows/apps/dn636979) 名前空間の [**MapLocationFinder**](https://msdn.microsoft.com/library/windows/apps/dn627550) クラスのメソッドを呼び出します。

**ヒント** アプリで地図を使う方法について詳しくは、GitHub の [Windows-universal-samples リポジトリ](http://go.microsoft.com/fwlink/p/?LinkId=619979)から次のサンプルをダウンロードしてください。

-   [ユニバーサル Windows プラットフォーム (UWP) の地図サンプル](http://go.microsoft.com/fwlink/p/?LinkId=619977)

ジオコーディングや逆ジオコーディング用のクラスがどのように関連するかを次に示します。

-   [
            **MapLocationFinder**](https://msdn.microsoft.com/library/windows/apps/dn627550) クラスには、ジオコーディング ([**FindLocationsAsync**](https://msdn.microsoft.com/library/windows/apps/dn636925)) と逆ジオコーディング ([**FindLocationsAtAsync**](https://msdn.microsoft.com/library/windows/apps/dn636928)) を実行するメソッドがあります。
-   これらのメソッドは、[**MapLocationFinderResult**](https://msdn.microsoft.com/library/windows/apps/dn627551) を返します。
-   [
            **MapLocationFinderResult**](https://msdn.microsoft.com/library/windows/apps/dn627551) には、[**MapLocation**](https://msdn.microsoft.com/library/windows/apps/dn627549) オブジェクトのコレクションが含まれています。 [
            **MapLocationFinderResult** の **Locations**](https://msdn.microsoft.com/library/windows/apps/dn627552) プロパティを通じてこのコレクションにアクセスします。
-   各 [**MapLocation**](https://msdn.microsoft.com/library/windows/apps/dn627549) オブジェクトには [**MapAddress**](https://msdn.microsoft.com/library/windows/apps/dn627533) オブジェクトが含まれています。 各 [**MapLocation** の **Address**](https://msdn.microsoft.com/library/windows/apps/dn636929) プロパティを通じてこのオブジェクトにアクセスします。

**重要**  マップ サービスを使用する前に、マップ認証キーを指定する必要があります。 詳しくは、「[マップ認証キーの要求](authentication-key.md)」をご覧ください。

 

## 位置情報の取得 (ジオコーディング)


住所や地名を地理的な位置に変換する (ジオコーディング) には、次に示している手順を実行します。

1.  [
            **MapLocationFinder**](https://msdn.microsoft.com/library/windows/apps/dn627550) クラスの [**FindLocationsAsync**](https://msdn.microsoft.com/library/windows/apps/dn636925) メソッドのいずれかのオーバーロードを呼び出します。
2.  [
            **FindLocationsAsync**](https://msdn.microsoft.com/library/windows/apps/dn636925) メソッドは、一致する [**MapLocation**](https://msdn.microsoft.com/library/windows/apps/dn627549) オブジェクトのコレクションを含む [**MapLocationFinderResult**](https://msdn.microsoft.com/library/windows/apps/dn627551) オブジェクトを返します。
3.  [
            **MapLocationFinderResult**](https://msdn.microsoft.com/library/windows/apps/dn627551) の [**Locations**](https://msdn.microsoft.com/library/windows/apps/dn627552) プロパティを通じてこのコレクションにアクセスします。

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

## 住所の取得 (逆ジオコーディング)


地理的な位置を住所に変換する (逆ジオコーディング) には、次に示している手順を実行します。

1.  [
            **MapLocationFinder**](https://msdn.microsoft.com/library/windows/apps/dn627550) クラスの [**FindLocationsAtAsync**](https://msdn.microsoft.com/library/windows/apps/dn636928) メソッドを呼び出します。
2.  [
            **FindLocationsAtAsync**](https://msdn.microsoft.com/library/windows/apps/dn636928) メソッドは、一致する [**MapLocation**](https://msdn.microsoft.com/library/windows/apps/dn627549) オブジェクトのコレクションを含む [**MapLocationFinderResult**](https://msdn.microsoft.com/library/windows/apps/dn627551) オブジェクトを返します。
3.  [
            **MapLocationFinderResult**](https://msdn.microsoft.com/library/windows/apps/dn627551) の [**Locations**](https://msdn.microsoft.com/library/windows/apps/dn627552) プロパティを通じてこのコレクションにアクセスします。
4.  各 [**MapLocation**](https://msdn.microsoft.com/library/windows/apps/dn627549) の [**Address**](https://msdn.microsoft.com/library/windows/apps/dn636929) プロパティを通じて [**MapAddress**](https://msdn.microsoft.com/library/windows/apps/dn627533) オブジェクトにアクセスします。

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

## 関連トピック

* [Bing Maps Developer Center](https://www.bingmapsportal.com/)
* [UWP の地図サンプル](http://go.microsoft.com/fwlink/p/?LinkId=619977)
* [地図の設計ガイドライン](https://msdn.microsoft.com/library/windows/apps/dn596102)
* [Build 2015 のビデオ: Windows アプリでの電話、タブレット、PC で使用できるマップと位置情報の活用](https://channel9.msdn.com/Events/Build/2015/2-757)
* [UWP の交通情報アプリのサンプル](http://go.microsoft.com/fwlink/p/?LinkId=619982)
* [**MapLocationFinder**](https://msdn.microsoft.com/library/windows/apps/dn627550)
* [**FindLocationsAsync**](https://msdn.microsoft.com/library/windows/apps/dn636925)
* [**FindLocationsAtAsync**](https://msdn.microsoft.com/library/windows/apps/dn636928)





<!--HONumber=Jun16_HO4-->


