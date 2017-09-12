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
# <a name="display-points-of-interest-poi-on-a-map"></a>関心のあるポイント (POI) の地図への表示


\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください \]


プッシュピン、画像、図形、XAML UI 要素を使って、関心のあるポイント (POI) を地図に追加します。 POI は、地図上の特定のポイントであり、関心のあるものを表します。 たとえば、企業、市区町村、友人の所在地を示すことができます。

**ヒント** アプリで POI を表示する方法について詳しくは、GitHub の [Windows-universal-samples リポジトリ](http://go.microsoft.com/fwlink/p/?LinkId=619979)から次のサンプルをダウンロードしてください。

-   [ユニバーサル Windows プラットフォーム (UWP) の地図サンプル](http://go.microsoft.com/fwlink/p/?LinkId=619977)

地図にプッシュピン、画像、図形を表示するには、[**MapIcon**](https://msdn.microsoft.com/library/windows/apps/dn637077) オブジェクト、[**MapPolygon**](https://msdn.microsoft.com/library/windows/apps/dn637103) オブジェクト、[**MapPolyline**](https://msdn.microsoft.com/library/windows/apps/dn637114) オブジェクトをマップ コントロールの [**MapElements**](https://msdn.microsoft.com/library/windows/apps/dn637033) コレクションに追加します。 プログラムでデータ バインディングを使うか、項目を追加します。XAML マークアップで宣言を使って **MapElements** コレクションにバインドすることはできません。

XAML ユーザー インターフェイス要素 ([**Button**](https://msdn.microsoft.com/library/windows/apps/br209265)、[**HyperlinkButton**](https://msdn.microsoft.com/library/windows/apps/br242739)、[**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652) など) を地図に表示するには、それらの要素を [**MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004) の [**Children**](https://msdn.microsoft.com/library/windows/apps/dn637008) として追加します。 また、それらの要素を [**MapItemsControl**](https://msdn.microsoft.com/library/windows/apps/dn637094) に追加したり、**MapItemsControl** を項目や項目のコレクションにバインドしたりすることもできます。

以上の説明をまとめると次のようになります。

-   
              プッシュピンなどの画像をオプションのテキストと共に表示するには、[MapIcon を地図に追加](#mapicon)
-   
              マルチポイント図形を表示するには、[MapPolygon を地図に追加](#mappolygon)
-   
              地図に線を表示するには、[MapPolyline を地図に追加](#mappolyline)
-   
              カスタム UI 要素を表示するには、[XAML を地図に追加](#mapxaml)

地図に配置する要素の数が多い場合、[地図にタイル画像をオーバーレイする](overlay-tiled-images.md)ことを検討します。 地図に道路情報を表示するには、「[ルートとルート案内の表示](routes-and-directions.md)」をご覧ください。

## <a name="add-a-mapicon"></a>MapIcon の追加


[**MapIcon**](https://msdn.microsoft.com/library/windows/apps/dn637077) クラスを使って、プッシュピンなどの画像をオプションのテキストと共に地図に表示します。 既定の画像をそのまま使うか、[**Image**](https://msdn.microsoft.com/library/windows/apps/dn637078) プロパティを使ってカスタム画像を指定できます。 次の画像はそれぞれ、[**Title**](https://msdn.microsoft.com/library/windows/apps/dn637088) プロパティに値を指定しない、短いタイトル、長いタイトル、非常に長いタイトルを指定した場合の **MapIcon** の既定の画像です。

![さまざまな長さのタイトルを含むサンプルの MapIcon。](images/mapctrl-mapicons.png)

次の例では、シアトル市の地図を表示して、既定の画像とオプションのタイトルを使って [**MapIcon**](https://msdn.microsoft.com/library/windows/apps/dn637077) を追加し、スペース ニードルの場所を示しています。 また、アイコンを地図の中央に配置し、拡大しています。 マップ コントロールを使用する方法に関する一般的な情報については、「[2D、3D、Streetside ビューでの地図の表示](display-maps.md)」をご覧ください。

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

この例では、次の POI (中央の既定の画像) が地図に表示されます。

![MapIcon を使った地図](images/displaypoidefault.png)

次のコード行では、プロジェクトの Assets フォルダーに保存されているカスタム イメージを使って [**MapIcon**](https://msdn.microsoft.com/library/windows/apps/dn637077) が表示されます。 **MapIcon** の [**Image**](https://msdn.microsoft.com/library/windows/apps/dn637078) プロパティでは、[**RandomAccessStreamReference**](https://msdn.microsoft.com/library/windows/apps/hh701813) 型の値が想定されています。 この型では、[**Windows.Storage.Streams**](https://msdn.microsoft.com/library/windows/apps/br241791) 名前空間用に **using** ステートメントが必要になります。

**ヒント** 複数の地図アイコンに同じ画像を使う場合は、パフォーマンスが最大限に高まるように、ページ レベルまたはアプリ レベルで [**RandomAccessStreamReference**](https://msdn.microsoft.com/library/windows/apps/hh701813) を宣言します。

```csharp
    MapIcon1.Image =
        RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/customicon.png"));
```

[**MapIcon**](https://msdn.microsoft.com/library/windows/apps/dn637077) クラスを使うときは、次の考慮事項を念頭に置いてください。

-   [**Image**](https://msdn.microsoft.com/library/windows/apps/dn637078) プロパティがサポートしている最大画像サイズは 2048 × 2048 ピクセルです。
-   既定では、地図アイコンの画像は必ず表示されるとは限りません。 このクラスが地図上の他の要素やラベルを覆い隠す場合には、このクラスは非表示になることがあります。 地図アイコンを表示したままにするには、このアイコンの [**CollisionBehaviorDesired**](https://msdn.microsoft.com/library/windows/apps/dn974327) プロパティを [**MapElementCollisionBehavior.RemainVisible**](https://msdn.microsoft.com/library/windows/apps/dn974314) に設定します。
-   [**MapIcon**](https://msdn.microsoft.com/library/windows/apps/dn637077) のオプションの [**Title**](https://msdn.microsoft.com/library/windows/apps/dn637088) は、必ず表示されるとは限りません。 テキストが表示されない場合は、[**MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004) の [**ZoomLevel**](https://msdn.microsoft.com/library/windows/apps/dn637068) プロパティの値を減らして、地図を縮小してください。
-   地図上の特定の場所を指す [**MapIcon**](https://msdn.microsoft.com/library/windows/apps/dn637077) 画像 (たとえば、プッシュピンや矢印など) を表示する場合は、[**NormalizedAnchorPoint**](https://msdn.microsoft.com/library/windows/apps/dn637082) プロパティの値を画像上にあるポインターのおおよその位置に設定することを検討してください。 **NormalizedAnchorPoint** の値を、画像の左上隅を示す既定値 (0, 0) のままにした場合、地図の [**ZoomLevel**](https://msdn.microsoft.com/library/windows/apps/dn637068) を変更すると、画像が別の場所を示した状態になる可能性があります。

## <a name="add-a-mapbillboard"></a>MapBillboard の追加

レストランやランドマークの画像など、地図の場所に関連する大きな画像を表示します。 ユーザーが地図を縮小すると、画像のサイズも比例的に縮小され、より広い範囲の地図を表示できるようになります。 これは特定の場所をマークする [**MapIcon**](https://msdn.microsoft.com/library/windows/apps/dn637077) とは少し異なります。MapIcon は小さいのが通常で、ユーザーが地図の拡大や縮小を行ってもサイズは変わりません。

![MapBillboard 画像](images/map-billboard.png)

次のコードは、上記の画像に表示されている [**MapBillboard**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapbillboard) を示しています。

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
このコードには、少し詳しく説明するに値する部分が 3 つあります。画像、リファレンス カメラ、および [**NormalizedAnchorPoint**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapbillboard#Windows_UI_Xaml_Controls_Maps_MapBillboard_NormalizedAnchorPoint) のことです。

### <a name="image"></a>画像

この例は、プロジェクトの **Assets** フォルダーに保存されたカスタム画像を示しています。 [**MapBillboard**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapbillboard) の [**Image**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapbillboard#Windows_UI_Xaml_Controls_Maps_MapBillboard_Image) プロパティでは、[**RandomAccessStreamReference**](https://msdn.microsoft.com/library/windows/apps/hh701813) 型の値が想定されています。 この型では、[**Windows.Storage.Streams**](https://msdn.microsoft.com/library/windows/apps/br241791) 名前空間用に **using** ステートメントが必要になります。

>[!NOTE]
>複数の地図アイコンに同じ画像を使う場合は、パフォーマンスが最大限に高まるように、ページ レベルまたはアプリ レベルで [**RandomAccessStreamReference**](https://msdn.microsoft.com/library/windows/apps/hh701813) を宣言します。

### <a name="reference-camera"></a>リファレンス カメラ

 [**MapBillboard**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapbillboard) 画像は地図の [**ZoomLevel**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapcontrol#Windows_UI_Xaml_Controls_Maps_MapControl_ZoomLevel) の変更に合わせて拡大および縮小するため、その [**ZoomLevel**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapcontrol#Windows_UI_Xaml_Controls_Maps_MapControl_ZoomLevel) が標準の 1x 倍率のときに画像がどこに表示されるかを定義することが重要になります。 その位置は [**MapBillboard**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapbillboard) のリファレンス カメラで定義されます。リファレンス カメラを設定するには、[**MapCamera**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapcamera) オブジェクトを [**MapBillboard**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapbillboard) のコンストラクターに渡す必要があります。

 [**Geopoint**](https://docs.microsoft.com/uwp/api/windows.devices.geolocation.geopoint) で目的の位置を定義し、その [**Geopoint**](https://docs.microsoft.com/uwp/api/windows.devices.geolocation.geopoint) を使用することで、[**MapCamera**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapcamera) オブジェクトを作成できます。  ただし、この例で使用している [**MapCamera**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapcamera) オブジェクトは、単純にマップ コントロールの [**ActualCamera**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapcontrol#Windows_UI_Xaml_Controls_Maps_MapControl_ActualCamera) プロパティから返されたものです。 これは地図の内部カメラです。 このカメラの現在の位置がリファレンス カメラの位置となり、1x 倍率ではこの位置に [**MapBillboard**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapbillboard) 画像が表示されます。

 アプリでユーザーが地図を縮小できるようにしている場合、画像のサイズも縮小されます。これは、1x 倍率の画像はリファレンス カメラの位置で固定されたままになりますが、地図の内部カメラは高度が上がるためです。

### <a name="normalizedanchorpoint"></a>NormalizedAnchorPoint

[**NormalizedAnchorPoint**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapbillboard#Windows_UI_Xaml_Controls_Maps_MapBillboard_NormalizedAnchorPoint) は、[**MapBillboard**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapbillboard) の [**Location**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapbillboard#Windows_UI_Xaml_Controls_Maps_MapBillboard_Location) プロパティに固定される画像のポイントです。 ポイント 0.5,1 は画像の下部中央になります。 [**MapBillboard**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapbillboard) の [**Location**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapbillboard#Windows_UI_Xaml_Controls_Maps_MapBillboard_Location) プロパティをマップ コントロールの中央に設定しているので、画像の下部中央がマップ コントロールの中央に固定されることになります。

## <a name="add-a-mappolygon"></a>MapPolygon の追加

[**MapPolygon**](https://msdn.microsoft.com/library/windows/apps/dn637103) クラスを使って、マルチポイント図形を地図に表示します。 次の例は、[UWP の地図サンプル](http://go.microsoft.com/fwlink/p/?LinkId=619977)から抜粋したもので、地図に赤色のボックス (境界線は青色) を表示します。

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

## <a name="add-a-mappolyline"></a>MapPolyline の追加


[**MapPolyline**](https://msdn.microsoft.com/library/windows/apps/dn637114) クラスを使って、線を地図に表示します。 次の例は、[UWP の地図サンプル](http://go.microsoft.com/fwlink/p/?LinkId=619977)から抜粋したもので、地図に破線を表示します。

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

## <a name="add-xaml"></a>XAML の追加

XAML を使って、カスタム UI 要素を地図に表示します。 XAML を地図に配置するには、XAML の位置と正規化されたアンカー ポイントを指定します。

-   [**SetLocation**](https://msdn.microsoft.com/library/windows/desktop/ms704369) を呼び出して、XAML を地図に配置する位置を設定します。
-   [**SetNormalizedAnchorPoint**](https://msdn.microsoft.com/library/windows/apps/dn637050) を呼び出して、指定した位置に対応する XAML 上の相対位置を設定します。

次の例では、シアトル市の地図を表示して、XAML の [**Border**](https://msdn.microsoft.com/library/windows/apps/br209250) コントロールを追加し、スペース ニードルの場所を示しています。 また、そのエリアを地図の中央に配置し、拡大しています。 マップ コントロールを使用する方法に関する一般的な情報については、「 [2D、3D、Streetside ビューでの地図の表示](display-maps.md)」をご覧ください。

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

この例では、地図に青色の境界線が表示されます。

![地図上の関心がある場所に表示された xaml のスクリーンショット](images/displaypoixaml.png)

次の例では、データ バインディングを使って、ページの XAML マークアップで XAML UI 要素を直接追加する方法を示しています。 コンテンツを表示する他の XAML 要素と同様に、[**Children**](https://msdn.microsoft.com/library/windows/apps/dn637008) は [**MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004) の既定のコンテンツ プロパティであり、XAML マークアップで明示的に指定する必要はありません。

次の例では、2 つの XAML コントロールを [**MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004) の暗黙的な子として表示する方法を示しています。

```xml
<maps:MapControl>
    <TextBox Text="Seattle" maps:MapControl.Location="{Binding SeattleLocation}"/>
    <TextBox Text="Bellevue" maps:MapControl.Location="{Binding BellevueLocation}"/>
</maps:MapControl>
```

次の例では、[**MapItemsControl**](https://msdn.microsoft.com/library/windows/apps/dn637094) に含まれている 2 つの XAML コントロールを表示する方法を示しています。

```xml
<maps:MapControl>
  <maps:MapItemsControl>
    <TextBox Text="Seattle" maps:MapControl.Location="{Binding SeattleLocation}"/>
    <TextBox Text="Bellevue" maps:MapControl.Location="{Binding BellevueLocation}"/>
  </maps:MapItemsControl>
</maps:MapControl>
```

次の例では、[**MapItemsControl**](https://msdn.microsoft.com/library/windows/apps/dn637094) にバインドされている XAML 要素のコレクションが表示されます。

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

## <a name="related-topics"></a>関連トピック

* [Bing Maps Developer Center](https://www.bingmapsportal.com/)
* [UWP の地図サンプル](http://go.microsoft.com/fwlink/p/?LinkId=619977)
* [地図の設計ガイドライン](https://msdn.microsoft.com/library/windows/apps/dn596102)
* [Build 2015 のビデオ: Windows アプリでの電話、タブレット、PC で使用できるマップと位置情報の活用](https://channel9.msdn.com/Events/Build/2015/2-757)
* [UWP の交通情報アプリのサンプル](http://go.microsoft.com/fwlink/p/?LinkId=619982)
* [**MapIcon**](https://msdn.microsoft.com/library/windows/apps/dn637077)
* [**MapPolygon**](https://msdn.microsoft.com/library/windows/apps/dn637103)
* [**MapPolyline**](https://msdn.microsoft.com/library/windows/apps/dn637114)
