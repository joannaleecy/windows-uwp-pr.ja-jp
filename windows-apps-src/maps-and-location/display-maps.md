---
title: '2D、3D、Streetside ビューでの地図の表示'
description: MapControl クラスを使って、アプリにカスタマイズできる地図を表示する方法について説明します。 このトピックでは、航空写真 3D ビューと Streetside ビューについても紹介します。
ms.assetid: 3839E00B-2C1E-4627-A45F-6DDA98D7077F
---

# 2D、3D、Streetside ビューでの地図の表示


\[ Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください \]


[
            **MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004) クラスを使って、アプリにカスタマイズできる地図を表示します。 このトピックでは、航空写真 3D ビューと Streetside ビューについても紹介します。

**ヒント:** アプリで地図を使う方法について詳しくは、GitHub の [Windows-universal-samples リポジトリ](http://go.microsoft.com/fwlink/p/?LinkId=619979)から次のサンプルをダウンロードしてください。

-   [ユニバーサル Windows プラットフォーム (UWP) の地図サンプル](http://go.microsoft.com/fwlink/p/?LinkId=619977)

## マップ コントロールのアプリへの追加


[
            **MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004) を追加することによって、XAML ページに地図を表示します。 **MapControl** を使うには、XAML ページまたはコード内に [**Windows.UI.Xaml.Controls.Maps**](https://msdn.microsoft.com/library/windows/apps/dn610751) 名前空間の宣言が必要です。 ツールボックスからコントロールをドラッグすると、この名前空間宣言が自動的に追加されます。 XAML ページに **MapControl** を手動で追加する場合は、ページの上部に名前空間宣言を手動で追加する必要があります。

次の例では、基本的なマップ コントロールを表示し、タッチ入力を受け付けるだけでなくズーム コントロールとチルト コントロールを表示するように地図を構成しています。 地図の外観をカスタマイズする方法について詳しくは、「[地図の構成](#mapconfig)」をご覧ください。

```xaml
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

コードにマップ コントロールを追加する場合は、コード ファイルの先頭で手動で名前空間を宣言する必要があります。

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

## マップ認証キーの取得と設定


[
            **MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004) やマップ サービスを使用する前に、マップ認証キーを [**MapServiceToken**](https://msdn.microsoft.com/library/windows/apps/dn637036) プロパティの値として指定する必要があります。 前に示した例では、`EnterYourAuthenticationKeyHere` を [Bing Maps Developer Center](https://www.bingmapsportal.com/) から取得したキーで置き換えます。 マップ認証キーを指定するまでは、コントロールの下に **[警告: MapServiceToken が指定されていません]** というテキストが表示されます。 マップ認証キーを取得して設定する方法について詳しくは、「[マップ認証キーの要求](authentication-key.md)」をご覧ください。

## 地図の開始位置の設定


コードで [**MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004) の [**Center**](https://msdn.microsoft.com/library/windows/apps/dn637005) プロパティを指定するか、または XAML マークアップでプロパティをバインドすることにより、地図上の表示位置を設定します。 シアトル市を中心とした地図を表示する例を次に示します。

**ヒント**  文字列は [**Geopoint**](https://msdn.microsoft.com/library/windows/apps/dn263675) に変換できないので、データ バインディングを使わない限り、XAML マークアップで [**Center**](https://msdn.microsoft.com/library/windows/apps/dn637005) プロパティに対する値を指定できません (この制限は、[**MapControl.Location**](https://msdn.microsoft.com/library/windows/apps/dn653264) 添付プロパティにも適用されます)。

 

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

## 地図の現在位置の設定


ユーザーの位置情報にアクセスするには、先にアプリで [**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/dn859152) メソッドを呼び出す必要があります。 このときに、アプリをフォアグラウンドで実行し、**RequestAccessAsync** を UI スレッドから呼び出す必要があります。 位置情報に対するアクセス許可をユーザーがアプリに与えるまで、アプリは位置情報にアクセスできません。

[
            **Geolocator**](https://msdn.microsoft.com/library/windows/apps/br225534) クラスの [**GetGeopositionAsync**](https://msdn.microsoft.com/library/windows/apps/hh973536) メソッドを使って、デバイスの現在の位置情報を取得します (位置情報にアクセスできる場合)。 対応する [**Geopoint**](https://msdn.microsoft.com/library/windows/apps/dn263675) を取得するには、geoposition オブジェクトの geocoordinate の [**Point**](https://msdn.microsoft.com/library/windows/apps/dn263665) プロパティを使います。 詳しくは、「[現在の位置情報の取得](get-location.md)」をご覧ください。

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

地図にデバイスの位置を表示するときは、位置情報の精度に基づいてグラフィックスを表示してズーム レベルを設定することを検討します。 詳しくは、「[位置認識アプリのガイドライン](https://msdn.microsoft.com/library/windows/apps/hh465148)」をご覧ください。

## 地図の位置の変更


2D 地図に表示する位置を変更するには、[**TrySetViewAsync**](https://msdn.microsoft.com/library/windows/apps/dn637060) メソッドのいずれかのオーバーロードを呼び出します。 そのメソッドを使って、[**Center**](https://msdn.microsoft.com/library/windows/apps/dn637005)、[**ZoomLevel**](https://msdn.microsoft.com/library/windows/apps/dn637068)、[**Heading**](https://msdn.microsoft.com/library/windows/apps/dn637019)、[**Pitch**](https://msdn.microsoft.com/library/windows/apps/dn637044) の新しい値を指定します。 また、ビューが変わるときに使うアニメーションをオプションで指定することもできます。そのためには、[**MapAnimationKind**](https://msdn.microsoft.com/library/windows/apps/dn637002) 列挙値の定数を指定します。

3D 地図の場所を変更するには、代わりに [**TrySetSceneAsync**](https://msdn.microsoft.com/library/windows/apps/dn974296) メソッドを使います。 詳しくは、「[3D ビューの表示](#display3d)」をご覧ください。

地図上に [**GeoboundingBox**](https://msdn.microsoft.com/library/windows/apps/dn607949) の内容を表示するには、[**TrySetViewBoundsAsync**](https://msdn.microsoft.com/library/windows/apps/dn637065) メソッドを呼び出します。 たとえばこのメソッドを使うと、地図上にルートやルートの一部を表示することができます。 詳しくは、「[地図へのルートとルート案内の表示](routes-and-directions.md)」をご覧ください。

## 地図の構成


地図とその外観を構成するには、[**MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004) の次のプロパティの値を設定します。

**マップの設定**

-   地図の**中心**を地理的位置に設定するには、[**Center**](https://msdn.microsoft.com/library/windows/apps/dn637005) プロパティを設定します。
-   [
            **ZoomLevel**](https://msdn.microsoft.com/library/windows/apps/dn637068) プロパティに 1 ～ 20 度の値を設定することにより、地図の**ズーム レベル**を設定します。
-   [
            **Heading**](https://msdn.microsoft.com/library/windows/apps/dn637019) プロパティを設定することにより地図の**回転**を設定します。ここでは 0 度または 360 度 = 北、90 度 = 東、180 度 = 南、270 度 = 西です。
-   [
            **DesiredPitch**](https://msdn.microsoft.com/library/windows/apps/dn637012) プロパティに 0 ～ 65 度の値を設定することにより、地図の**傾き**を設定します。

**地図の外観**

-   地図の**種類** (たとえば、道路地図や航空地図など) を指定するには、[**Style**](https://msdn.microsoft.com/library/windows/apps/dn637051) プロパティを [**MapStyle**](https://msdn.microsoft.com/library/windows/apps/dn637127) 定数のいずれかに設定します。
-   地図の**配色**を淡色または濃色に設定するには、[**ColorScheme**](https://msdn.microsoft.com/library/windows/apps/dn637010) プロパティを [**MapColorScheme**](https://msdn.microsoft.com/library/windows/apps/dn637003) 定数のいずれかに設定します。

地図に情報を表示するには、[**MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004) の次のプロパティの値を設定します。

-   地図に**建物やランドマーク**を表示するには、[**LandmarksVisible**](https://msdn.microsoft.com/library/windows/apps/dn637023) プロパティを有効または無効にします。
-   地図に公共階段などの**歩行者用の施設**を表示するには、[**PedestrianFeaturesVisible**](https://msdn.microsoft.com/library/windows/apps/dn637042) プロパティを有効または無効にします。
-   地図に**交通情報**を表示するには、[**TrafficFlowVisible**](https://msdn.microsoft.com/library/windows/apps/dn637055) プロパティを有効または無効にします。
-   地図に**透かし**を表示するかどうかを指定するには、[**WatermarkMode**](https://msdn.microsoft.com/library/windows/apps/dn637066) プロパティを [**MapWatermarkMode**](https://msdn.microsoft.com/library/windows/apps/dn610749) 定数のいずれかに設定します。
-   地図に**自動車ルートや徒歩ルート**を表示するには、マップ コントロールの [**Routes**](https://msdn.microsoft.com/library/windows/apps/dn637047) コレクションに [**MapRouteView**](https://msdn.microsoft.com/library/windows/apps/dn637122) を追加します。 詳しい情報と例については、「[地図へのルートとルート案内の表示](routes-and-directions.md)」をご覧ください。

[
            **MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004) でプッシュピン、図形、XAML コントロールを表示する方法については、「[関心のあるポイント (POI) の地図への表示](display-poi.md)」をご覧ください。

## Streetside ビューの表示


Streetside ビューは、視点がストリート レベルにある場合の場所の見え方を示すもので、マップ コントロールの上に表示されます。

![マップ コントロールの Streetside ビューの例。](images/onlystreetside-730width.png)

Streetside ビューの「内部」での操作は、マップ コントロールにもともと表示されている地図とは独立していることを考慮します。 たとえば、Streetside ビューで場所を変更しても、Streetside ビューの「下」にある地図の場所や外観は変わりません。 コントロールの右上隅にある **[X]** をクリックして Streetside ビューを閉じると、元の地図は Streetside ビューが表示される前のままです。

Streetside ビューを表示するには

1.  [
            **IsStreetsideSupported**](https://msdn.microsoft.com/library/windows/apps/dn974271) を確認して、Streetside ビューがデバイスでサポートされているかどうかを調べます。
2.  Streetside ビューがサポートされている場合は、[**FindNearbyAsync**](https://msdn.microsoft.com/library/windows/apps/dn974361) を呼び出し、指定した位置の近くに [**StreetsidePanorama**](https://msdn.microsoft.com/library/windows/apps/dn974360) を作成します。
3.  [
            **StreetsidePanorama**](https://msdn.microsoft.com/library/windows/apps/dn974360) が null でないかどうかを確認し、近隣のパノラマ写真があるかどうかを調べます。
4.  近隣のパノラマ写真があった場合、[**StreetsideExperience**](https://msdn.microsoft.com/library/windows/apps/dn974356) を作成し、マップ コントロールの [**CustomExperience**](https://msdn.microsoft.com/library/windows/apps/dn974263) プロパティに設定します。

次の例は、前掲の画像に似た Streetside ビューを表示する方法を示しています。

**注**  マップ コントロールのサイズが小さすぎる場合は、概観の地図は表示されません。

 

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

## 航空写真 3D ビューの表示


[
            **MapScene**](https://msdn.microsoft.com/library/windows/apps/dn974329) クラスを使って、地図の 3D 視点を指定します。 マップ シーンは、地図に表示される 3D ビューを表します。 [
            **MapCamera**](https://msdn.microsoft.com/library/windows/apps/dn974244) クラスは、このようなビューが表示されるカメラの位置を表します。

![](images/mapcontrol-techdiagram.png)

建物などの地物を地図表面に 3D 表示するには、マップ コントロールの [**Style**](https://msdn.microsoft.com/library/windows/apps/dn637051) プロパティを [**MapStyle.Aerial3DWithRoads**](https://msdn.microsoft.com/library/windows/apps/dn637127) に設定します。 **Aerial3DWithRoads** スタイルの 3D ビューの例を次に示します。

![3D 地図ビューの例。](images/only3d-730width.png)

3D ビューを表示するには

1.  [
            **Is3DSupported**](https://msdn.microsoft.com/library/windows/apps/dn974265) を確認して、3D ビューがデバイスでサポートされているかどうかを調べます。
2.  3D ビューがサポートされている場合は、マップ コントロールの [**Style**](https://msdn.microsoft.com/library/windows/apps/dn637051) プロパティを [**MapStyle.Aerial3DWithRoads**](https://msdn.microsoft.com/library/windows/apps/dn637127) に設定します。
3.  [
            **CreateFromLocationAndRadius**](https://msdn.microsoft.com/library/windows/apps/dn974336)、[**CreateFromCamera**](https://msdn.microsoft.com/library/windows/apps/dn974334) などの多数の **CreateFrom** メソッドの中から [**MapScene**](https://msdn.microsoft.com/library/windows/apps/dn974329) オブジェクトを作成します。
4.  [
            **TrySetSceneAsync**](https://msdn.microsoft.com/library/windows/apps/dn974296) を呼び出して、3D ビューを表示します。 また、ビューが変わるときに使うアニメーションをオプションで指定することもできます。そのためには、[**MapAnimationKind**](https://msdn.microsoft.com/library/windows/apps/dn637002) 列挙値の定数を指定します。

次の例は、3D ビューを表示する方法を示しています。

```csharp
private async void display3DLocation()
{
   if (MapControl1.Is3DSupported)
   {
      // Set the aerial 3D view.
      MapControl1.Style = MapStyle.Aerial3DWithRoads;

      // Specify the location.
      BasicGeoposition hwGeoposition = new BasicGeoposition() { Latitude = 34.134, Longitude = -118.3216};
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

## 位置や要素に関する情報の取得


地図上の位置に関する情報を取得するには、[**MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004) の次のメソッドを呼び出します。

-   [**GetLocationFromOffset**](https://msdn.microsoft.com/library/windows/apps/dn637016) メソッド - マップ コントロールのビューポート内の指定したポイントに対応する地理的な位置情報を取得します。
-   [**GetOffsetFromLocation**](https://msdn.microsoft.com/library/windows/apps/dn637018) メソッド - 指定した地理的な位置情報に対応するマップ コントロールのビューポート内のポイントを取得します。
-   [**IsLocationInView**](https://msdn.microsoft.com/library/windows/apps/dn637022) メソッド - 指定した地理的な位置がマップ コントロールのビューポート内に現在表示されているかどうかを調べます。
-   [**FindMapElementsAtOffset**](https://msdn.microsoft.com/library/windows/apps/dn637014) メソッド - マップ コントロールのビューポート内の指定したポイントにある地図上の要素を取得します。

## ユーザー操作と変更の処理


地図でのユーザーの入力ジェスチャを処理するには、[**MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004) の次のイベントを処理します。 地図上の地理的な位置、およびジェスチャが行われたビューポート内の実際の位置に関する情報を取得するには、[**MapInputEventArgs**](https://msdn.microsoft.com/library/windows/apps/dn637090) の [**Location**](https://msdn.microsoft.com/library/windows/apps/dn637091) プロパティと [**Position**](https://msdn.microsoft.com/library/windows/apps/dn637093) プロパティの値を確認します。

-   [**MapTapped**](https://msdn.microsoft.com/library/windows/apps/dn637038)
-   [**MapDoubleTapped**](https://msdn.microsoft.com/library/windows/apps/dn637032)
-   [**MapHolding**](https://msdn.microsoft.com/library/windows/apps/dn637035)

地図が読み込まれている最中であるか、完全に読み込まれたかどうかを判断するには、コントロールの [**LoadingStatusChanged**](https://msdn.microsoft.com/library/windows/apps/dn637028) イベントを処理します。

ユーザーやアプリによる地図の設定変更に対応するには、[**MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004) の次のイベントを処理します。 [マップのガイドライン](https://msdn.microsoft.com/library/windows/apps/dn596102)

-   [**CenterChanged**](https://msdn.microsoft.com/library/windows/apps/dn637006)
-   [**HeadingChanged**](https://msdn.microsoft.com/library/windows/apps/dn637020)
-   [**PitchChanged**](https://msdn.microsoft.com/library/windows/apps/dn637045)
-   [**ZoomLevelChanged**](https://msdn.microsoft.com/library/windows/apps/dn637069)

## 関連トピック

* [Bing Maps Developer Center](https://www.bingmapsportal.com/)
* [UWP の地図サンプル](http://go.microsoft.com/fwlink/p/?LinkId=619977)
* [現在の位置情報の取得](get-location.md)
* [位置認識アプリの設計ガイドライン](https://msdn.microsoft.com/library/windows/apps/hh465148)
* [地図の設計ガイドライン](https://msdn.microsoft.com/library/windows/apps/dn596102)
* [Build 2015 のビデオ: Windows アプリでの電話、タブレット、PC で使用できるマップと位置情報の活用](https://channel9.msdn.com/Events/Build/2015/2-757)
* [UWP の交通情報アプリのサンプル](http://go.microsoft.com/fwlink/p/?LinkId=619982)
* [**MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004)




<!--HONumber=Mar16_HO1-->


