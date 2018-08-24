---
author: normesta
title: 地図へのタイル画像のオーバーレイ
description: タイル ソースを使って、地図上にサード パーティ製タイルまたはカスタム タイル画像をオーバーレイします。 タイル ソースを使って、気象データ、人口データ、地質データなどの特殊な情報をオーバーレイすることや、既定の地図を完全に置き換えることができます。
ms.assetid: 066BD6E2-C22B-4F5B-AA94-5D6C86A09BDF
ms.author: normesta
ms.date: 07/19/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10、UWP、地図、位置情報、画像、オーバーレイ
ms.localizationpriority: medium
ms.openlocfilehash: ba1f7d52a1b16fbb421202229ce724dab384ffa0
ms.sourcegitcommit: c6d6f8b54253e79354f8db14e5cf3b113a3e5014
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/24/2018
ms.locfileid: "2837351"
---
# <a name="overlay-tiled-images-on-a-map"></a>地図へのタイル画像のオーバーレイ

タイル ソースを使って、地図上にサード パーティ製タイルまたはカスタム タイル画像をオーバーレイします。 タイル ソースを使って、気象データ、人口データ、地質データなどの特殊な情報をオーバーレイすることや、既定の地図を完全に置き換えることができます。

**ヒント** アプリでの地図の使用について詳しくは、Github で[ユニバーサル Windows プラットフォーム (UWP) の地図サンプル](http://go.microsoft.com/fwlink/p/?LinkId=619977)をダウンロードしてください。

<a id="tileintro" />

## <a name="tiled-image-overview"></a>タイル画像の概要

Nokia Maps や Bing Maps などのマップ サービスでは、迅速な取得と表示のために正方形タイルに地図を切り取ります。 こうしたタイルは 256 ピクセル x 256 ピクセル サイズであり、いくつかの詳細レベルで事前にレンダリングされます。 また、多くのサード パーティ サービスがタイルに切り取られた地図ベースのデータを提供しています。 タイル ソースを使ってサード パーティ製タイルを取得するか、独自のカスタム タイルを作成してそれを [**MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004) に表示された地図上にオーバーレイできます。

**重要**  
タイル ソースを使う場合、個々のタイルの要求または配置のためにコードを記述する必要はありません。 [**MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004) が必要時にタイルを要求します。 各要求では、個々のタイルについて X 座標と Y 座標、ズーム レベルを指定します。 タイルを取得するために使う URI またはファイル名の形式を **UriFormatString** プロパティに指定します。 つまり、各タイルの X 座標、Y 座標、ズーム レベルを渡す場所を示すベース URI またはファイル名に、置き換え可能なパラメーターを挿入します。

次に、X 座標、Y 座標、ズーム レベルの置き換え可能なパラメーターを示す [**HttpMapTileDataSource**](https://msdn.microsoft.com/library/windows/apps/dn636986) の [**UriFormatString**](https://msdn.microsoft.com/library/windows/apps/dn636992) プロパティの例を示します。

```syntax
http://www.<web service name>.com/z={zoomlevel}&x={x}&y={y}
```

X 座標と Y 座標は、指定された詳細レベルで世界地図内の個々のタイルの場所を表します。 タイルの番号付けは、地図の左上端の {0, 0} から開始します。 たとえば、{1, 2} のタイルは、タイル グリッドの第 1 行の第 2 列にあります。

マッピング サービスにより使用されるタイル システムについては、[Bing Maps タイル システムに関するページ (英語) ](http://go.microsoft.com/fwlink/p/?LinkId=626692)をご覧ください。

### <a name="overlay-tiles-from-a-tile-source"></a>タイル ソースからのタイルのオーバーレイ

[**MapTileDataSource**](https://msdn.microsoft.com/library/windows/apps/dn637141) を使って、タイル ソースからのタイル画像を地図にオーバーレイします。

1.  [**MapTileDataSource**](https://msdn.microsoft.com/library/windows/apps/dn637141) から継承する 3 つのタイル データ ソース クラスのいずれかをインスタンス化します。

    -   [**HttpMapTileDataSource**](https://msdn.microsoft.com/library/windows/apps/dn636986)
    -   [**LocalMapTileDataSource**](https://msdn.microsoft.com/library/windows/apps/dn636994)
    -   [**CustomMapTileDataSource**](https://msdn.microsoft.com/library/windows/apps/dn636983)

    ベース URI またはファイル名に置き換え可能なパラメーターを挿入することにより、タイルの要求に使う **UriFormatString** を構成します。

    次の例では、[**HttpMapTileDataSource**](https://msdn.microsoft.com/library/windows/apps/dn636986) をインスタンス化します。 次の例では、**HttpMapTileDataSource** のコンストラクターで [**UriFormatString**](https://msdn.microsoft.com/library/windows/apps/dn636992) の値を指定しています。

    ```csharp
        HttpMapTileDataSource dataSource = new HttpMapTileDataSource(
          "http://www.<web service name>.com/z={zoomlevel}&x={x}&y={y}");
    ```

2.  [**MapTileSource**](https://msdn.microsoft.com/library/windows/apps/dn637144) をインスタンス化および構成します。 以前の手順で **MapTileSource** の [**DataSource**](https://msdn.microsoft.com/library/windows/apps/dn637149) として構成した [**MapTileDataSource**](https://msdn.microsoft.com/library/windows/apps/dn637141) を指定します。

    次の例では、[**MapTileSource**](https://msdn.microsoft.com/library/windows/apps/dn637144) のコンストラクターで [**DataSource**](https://msdn.microsoft.com/library/windows/apps/dn637149) を指定しています。

    ```csharp
        MapTileSource tileSource = new MapTileSource(dataSource);
    ```

    [**MapTileSource**](https://msdn.microsoft.com/library/windows/apps/dn637144) のプロパティを使うことにより、タイルが表示される条件を制限できます。

    -   [**Bounds**](https://msdn.microsoft.com/library/windows/apps/dn637147) プロパティの値を指定することにより、特定地域内にのみタイルを表示します。
    -   [**ZoomLevelRange**](https://msdn.microsoft.com/library/windows/apps/dn637171) プロパティの値を指定することにより、特定の詳細レベルでのみタイルを表示します。

    オプションで、[**Layer**](https://msdn.microsoft.com/library/windows/apps/dn637157)、[**AllowOverstretch**](https://msdn.microsoft.com/library/windows/apps/dn637145)、[**IsRetryEnabled**](https://msdn.microsoft.com/library/windows/apps/dn637153)、[**IsTransparencyEnabled**](https://msdn.microsoft.com/library/windows/apps/dn637155) など、タイルの読み込みまたは表示に影響する [**MapTileSource**](https://msdn.microsoft.com/library/windows/apps/dn637144) の他のプロパティを構成します。

3.  [**MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004) の [**TileSources**](https://msdn.microsoft.com/library/windows/apps/dn637053) コレクションに [**MapTileSource**](https://msdn.microsoft.com/library/windows/apps/dn637144) を追加します。

    ```csharp
         MapControl1.TileSources.Add(tileSource);
    ```

## <a name="overlay-tiles-from-a-web-service"></a>Web サービスからのタイルのオーバーレイ


[**HttpMapTileDataSource**](https://msdn.microsoft.com/library/windows/apps/dn636986) を使って、Web サービスから取得したタイル画像をオーバーレイします。

1.  [**HttpMapTileDataSource**](https://msdn.microsoft.com/library/windows/apps/dn636986) をインスタンス化します。
2.  Web サービスで [**UriFormatString**](https://msdn.microsoft.com/library/windows/apps/dn636992) プロパティの値として想定される URI の形式を指定します。 この値を作成するには、ベース URI に置き換え可能なパラメーターを挿入します。 たとえば次のコード サンプルでは、**UriFormatString** の値は次のとおりです。

    ``` syntax
    http://www.<web service name>.com/z={zoomlevel}&x={x}&y={y}
    ```

    この Web サービスでは、置き換え可能なパラメーター {x}、{y}、{zoomlevel} を含む URI をサポートする必要があります。 大半の Web サービス (たとえば Nokia、Bing、Google など) で、この形式の URI がサポートされています。 [**UriFormatString**](https://msdn.microsoft.com/library/windows/apps/dn636992) プロパティで使用できない追加引数が Web サービスで必要な場合は、カスタム URI を作成する必要があります。 [**UriRequested**](https://msdn.microsoft.com/library/windows/apps/dn636993) イベントを処理することにより、カスタム URI を作成して返します。 詳しくは、このトピックで後述する「[カスタム URI の指定](#customuri)」をご覧ください。

3.  次に、「[タイル画像の概要](#tileintro)」で説明した残りの手順に従います。

次の例では、北米のマップに架空の Web サービスからのタイルをオーバーレイしています。 [**HttpMapTileDataSource**](https://msdn.microsoft.com/library/windows/apps/dn636986) のコンストラクターで [**UriFormatString**](https://msdn.microsoft.com/library/windows/apps/dn636992) の値を指定しています。 この例では、省略可能な [**Bounds**](https://msdn.microsoft.com/library/windows/apps/dn637147) プロパティによって指定した地理的境界内にのみタイルが表示されます。

```csharp
private void AddHttpMapTileSource()
{
    // Create the bounding box in which the tiles are displayed.
    // This example represents North America.
    BasicGeoposition northWestCorner =
        new BasicGeoposition() { Latitude = 48.38544, Longitude = -124.667360 };
    BasicGeoposition southEastCorner =
        new BasicGeoposition() { Latitude = 25.26954, Longitude = -80.30182 };
    GeoboundingBox boundingBox = new GeoboundingBox(northWestCorner, southEastCorner);

    // Create an HTTP data source.
    // This example retrieves tiles from a fictitious web service.
    HttpMapTileDataSource dataSource = new HttpMapTileDataSource(
        "http://www.<web service name>.com/z={zoomlevel}&x={x}&y={y}");

    // Optionally, add custom HTTP headers if the web service requires them.
    dataSource.AdditionalRequestHeaders.Add("header name", "header value");

    // Create a tile source and add it to the Map control.
    MapTileSource tileSource = new MapTileSource(dataSource);
    tileSource.Bounds = boundingBox;
    MapControl1.TileSources.Add(tileSource);
}
```

```cppwinrt
...
#include <winrt/Windows.Devices.Geolocation.h>
#include <winrt/Windows.UI.Xaml.Controls.Maps.h>
...
void MainPage::AddHttpMapTileSource()
{
    Windows::Devices::Geolocation::BasicGeoposition northWest{ 48.38544, -124.667360 };
    Windows::Devices::Geolocation::BasicGeoposition southEast{ 25.26954, -80.30182 };
    Windows::Devices::Geolocation::GeoboundingBox boundingBox{ northWest, southEast };

    Windows::UI::Xaml::Controls::Maps::HttpMapTileDataSource dataSource{
        L"http://www.<web service name>.com/z={zoomlevel}&x={x}&y={y}" };

    dataSource.AdditionalRequestHeaders().Insert(L"header name", L"header value");

    Windows::UI::Xaml::Controls::Maps::MapTileSource tileSource{ dataSource };
    tileSource.Bounds(boundingBox);

    MapControl1().TileSources().Append(tileSource);
}
...
```

```cpp
void MainPage::AddHttpMapTileSource()
{
    BasicGeoposition northWest = { 48.38544, -124.667360 };
    BasicGeoposition southEast = { 25.26954, -80.30182 };
    GeoboundingBox^ boundingBox = ref new GeoboundingBox(northWest, southEast);

    auto dataSource = ref new Windows::UI::Xaml::Controls::Maps::HttpMapTileDataSource(
        "http://www.<web service name>.com/z={zoomlevel}&x={x}&y={y}");

    dataSource->AdditionalRequestHeaders->Insert("header name", "header value");

    auto tileSource = ref new Windows::UI::Xaml::Controls::Maps::MapTileSource(dataSource);
    tileSource->Bounds = boundingBox;

    this->MapControl1->TileSources->Append(tileSource);
}
```

## <a name="overlay-tiles-from-local-storage"></a>ローカル記憶域からのタイルのオーバーレイ


[**LocalMapTileDataSource**](https://msdn.microsoft.com/library/windows/apps/dn636994) を使って、ローカル ストレージにファイルとして格納されたタイル画像をオーバーレイします。 通常、こうしたファイルはアプリと共にパッケージ化して配布します。

1.  [**LocalMapTileDataSource**](https://msdn.microsoft.com/library/windows/apps/dn636994) をインスタンス化します。
2.  [**UriFormatString**](https://msdn.microsoft.com/library/windows/apps/dn636998) プロパティの値としてファイル名の形式を指定します。 この値を作成するには、ベース ファイル名に置き換え可能なパラメーターを挿入します。 たとえば次のコード サンプルでは、[**UriFormatString**](https://msdn.microsoft.com/library/windows/apps/dn636992) の値は次のとおりです。

    ``` syntax
        Tile_{zoomlevel}_{x}_{y}.png
    ```

    [**UriFormatString**](https://msdn.microsoft.com/library/windows/apps/dn636998) プロパティで使用できない追加引数がファイル名の形式で必要な場合は、カスタム URI を作成する必要があります。 [**UriRequested**](https://msdn.microsoft.com/library/windows/apps/dn637001) イベントを処理することにより、カスタム URI を作成して返します。 詳しくは、このトピックで後述する「[カスタム URI の指定](#customuri)」をご覧ください。

3.  次に、「[タイル画像の概要](#tileintro)」で説明した残りの手順に従います。

ローカル ストレージからタイルを読み込むために、次のプロトコルと場所を使用できます。

| URI | 詳細 |
|---------------------|----------------------------------------------------------------------------------------------------------------------------------------------|
| ms-appx:/// | アプリのインストール フォルダーのルートを参照します。 |
|  | これは、[Package.InstalledLocation](https://msdn.microsoft.com/library/windows/apps/br224681) プロパティによって参照される場所です。 |
| ms-appdata:///local | アプリのローカル ストレージのルートを参照します。 |
|  | これは、[ApplicationData.LocalFolder](https://msdn.microsoft.com/library/windows/apps/br241621) プロパティによって参照される場所です。 |
| ms-appdata:///temp | アプリの一時フォルダーを参照します。 |
|  | これは、[ApplicationData.TemporaryFolder](https://msdn.microsoft.com/library/windows/apps/br241629) プロパティによって参照される場所です。 |

 

次の例では、`ms-appx:///` プロトコルを使って、アプリのインストール フォルダーにファイルとして格納されたタイルを読み込みます。 [**LocalMapTileDataSource**](https://msdn.microsoft.com/library/windows/apps/dn636994) のコンストラクターで [**UriFormatString**](https://msdn.microsoft.com/library/windows/apps/dn636998) の値を指定しています。 この例では、省略可能な [**ZoomLevelRange**](https://msdn.microsoft.com/library/windows/apps/dn637171) プロパティによって指定された範囲内に地図のズーム レベルがある場合にのみ、タイルが表示されます。

```csharp
        void AddLocalMapTileSource()
        {
            // Specify the range of zoom levels
            // at which the overlaid tiles are displayed.
            MapZoomLevelRange range;
            range.Min = 11;
            range.Max = 20;

            // Create a local data source.
            LocalMapTileDataSource dataSource = new LocalMapTileDataSource(
                "ms-appx:///TileSourceAssets/Tile_{zoomlevel}_{x}_{y}.png");

            // Create a tile source and add it to the Map control.
            MapTileSource tileSource = new MapTileSource(dataSource);
            tileSource.ZoomLevelRange = range;
            MapControl1.TileSources.Add(tileSource);
        }
```

<a id="customuri" />

## <a name="provide-a-custom-uri"></a>カスタム URI の指定

[**HttpMapTileDataSource**](https://msdn.microsoft.com/library/windows/apps/dn636986) の [**UriFormatString**](https://msdn.microsoft.com/library/windows/apps/dn636992) プロパティまたは [**LocalMapTileDataSource**](https://msdn.microsoft.com/library/windows/apps/dn636994) の [**UriFormatString**](https://msdn.microsoft.com/library/windows/apps/dn636998) プロパティにより使用できる置き換え可能なパラメーターがタイルの取得に十分でない場合は、カスタム URI を作成する必要があります。 **UriRequested** イベントのカスタム ハンドラーを指定することによりカスタム URI を作成して返します。 **UriRequested** イベントは、個々のタイルについて発生します。

1.  カスタム URI を作成するために、**UriRequested** イベントのカスタム ハンドラーで、[**MapTileUriRequestedEventArgs**](https://msdn.microsoft.com/library/windows/apps/dn637177) の [**X**](https://msdn.microsoft.com/library/windows/apps/dn610743) プロパティ、[**Y**](https://msdn.microsoft.com/library/windows/apps/dn610744) プロパティ、[**ZoomLevel**](https://msdn.microsoft.com/library/windows/apps/dn610745) プロパティにより必要なカスタム引数を組み合わせます。
2.  [**MapTileUriRequestedEventArgs**](https://msdn.microsoft.com/library/windows/apps/dn637177) の [**Request**](https://msdn.microsoft.com/library/windows/apps/dn637179) プロパティに含まれている [**MapTileUriRequest**](https://msdn.microsoft.com/library/windows/apps/dn637173) の [**Uri**](https://msdn.microsoft.com/library/windows/apps/dn610748) プロパティにカスタム URI を返します。

次の例では、**UriRequested** イベントのカスタム ハンドラーを作成することによりカスタム URI を指定する方法を示しています。 また、カスタム URI を作成するために非同期処理が必要な場合に、保留パターンを実装する方法を示しています。

```csharp
using Windows.UI.Xaml.Controls.Maps;
using System.Threading.Tasks;
...
            var httpTileDataSource = new HttpMapTileDataSource();
            // Attach a handler for the UriRequested event.
            httpTileDataSource.UriRequested += HandleUriRequestAsync;
            MapTileSource httpTileSource = new MapTileSource(httpTileDataSource);
            MapControl1.TileSources.Add(httpTileSource);
...
        // Handle the UriRequested event.
        private async void HandleUriRequestAsync(HttpMapTileDataSource sender,
            MapTileUriRequestedEventArgs args)
        {
            // Get a deferral to do something asynchronously.
            // Omit this line if you don't have to do something asynchronously.
            var deferral = args.Request.GetDeferral();

            // Get the custom Uri.
            var uri = await GetCustomUriAsync(args.X, args.Y, args.ZoomLevel);

            // Specify the Uri in the Uri property of the MapTileUriRequest.
            args.Request.Uri = uri;

            // Notify the app that the custom Uri is ready.
            // Omit this line also if you don't have to do something asynchronously.
            deferral.Complete();
        }

        // Create the custom Uri.
        private async Task<Uri> GetCustomUriAsync(int x, int y, int zoomLevel)
        {
            // Do something asynchronously to create and return the custom Uri.        }
        }
```

## <a name="overlay-tiles-from-a-custom-source"></a>カスタム ソースからのタイルのオーバーレイ

[**CustomMapTileDataSource**](https://msdn.microsoft.com/library/windows/apps/dn636983) を使って、カスタム タイルをオーバーレイします。 プログラムによってメモリ内で随時にタイルを作成するか、または別のソースから既存のタイルを読み込むために独自のコードを記述します。

カスタム タイルを作成するか読み込むには、[**BitmapRequested**](https://msdn.microsoft.com/library/windows/apps/dn636984) イベントのカスタム ハンドラーを指定します。 **BitmapRequested** イベントは、個々のタイルについて発生します。

1.  カスタム タイルを作成または取得するために、[**BitmapRequested**](https://msdn.microsoft.com/library/windows/apps/dn636984) イベントのカスタム ハンドラーで、[**MapTileBitmapRequestedEventArgs**](https://msdn.microsoft.com/library/windows/apps/dn637132) の [**X**](https://msdn.microsoft.com/library/windows/apps/dn637135) プロパティ、[**Y**](https://msdn.microsoft.com/library/windows/apps/dn637136) プロパティ、[**ZoomLevel**](https://msdn.microsoft.com/library/windows/apps/dn637137) プロパティにより必要なカスタム引数を組み合わせます。
2.  [**MapTileBitmapRequestedEventArgs**](https://msdn.microsoft.com/library/windows/apps/dn637132) の [**Request**](https://msdn.microsoft.com/library/windows/apps/dn637134) プロパティに含まれている [**MapTileBitmapRequest**](https://msdn.microsoft.com/library/windows/apps/dn637128) の [**PixelData**](https://msdn.microsoft.com/library/windows/apps/dn637140) プロパティにカスタム タイルを返します。 **PixelData** プロパティの型は [**IRandomAccessStreamReference**](https://msdn.microsoft.com/library/windows/apps/hh701664) です。

次の例では、**BitmapRequested** イベントのカスタム ハンドラーを作成することによりカスタム タイルを指定する方法を示しています。 この例では、一部が不透明な赤の同じタイルを作成します。 この例では、[**MapTileBitmapRequestedEventArgs**](https://msdn.microsoft.com/library/windows/apps/dn637132) の [**X**](https://msdn.microsoft.com/library/windows/apps/dn637135) プロパティ、[**Y**](https://msdn.microsoft.com/library/windows/apps/dn637136) プロパティ、[**ZoomLevel**](https://msdn.microsoft.com/library/windows/apps/dn637137) プロパティを無視します。 これは実際の例ではありませんが、メモリ内で随時にカスタム タイルを作成する方法を示しています。 この例ではまた、カスタム タイルを作成するために非同期処理が必要な場合に、保留パターンを実装する方法を示しています。

```csharp
using Windows.UI.Xaml.Controls.Maps;
using Windows.Storage.Streams;
using System.Threading.Tasks;
...
        CustomMapTileDataSource customDataSource = new CustomMapTileDataSource();
        // Attach a handler for the BitmapRequested event.
        customDataSource.BitmapRequested += customDataSource_BitmapRequestedAsync;
        customTileSource = new MapTileSource(customDataSource);
        MapControl1.TileSources.Add(customTileSource);
...
        // Handle the BitmapRequested event.
        private async void customDataSource_BitmapRequestedAsync(
            CustomMapTileDataSource sender,
            MapTileBitmapRequestedEventArgs args)
        {
            var deferral = args.Request.GetDeferral();
            args.Request.PixelData = await CreateBitmapAsStreamAsync();
            deferral.Complete();
        }

        // Create the custom tiles.
        // This example creates red tiles that are partially opaque.
        private async Task<RandomAccessStreamReference> CreateBitmapAsStreamAsync()
        {
            int pixelHeight = 256;
            int pixelWidth = 256;
            int bpp = 4;

            byte[] bytes = new byte[pixelHeight * pixelWidth * bpp];

            for (int y = 0; y < pixelHeight; y++)
            {
                for (int x = 0; x < pixelWidth; x++)
                {
                    int pixelIndex = y * pixelWidth + x;
                    int byteIndex = pixelIndex * bpp;

                    // Set the current pixel bytes.
                    bytes[byteIndex] = 0xff;        // Red
                    bytes[byteIndex + 1] = 0x00;    // Green
                    bytes[byteIndex + 2] = 0x00;    // Blue
                    bytes[byteIndex + 3] = 0x80;    // Alpha (0xff = fully opaque)
                }
            }

            // Create RandomAccessStream from byte array.
            InMemoryRandomAccessStream randomAccessStream =
                new InMemoryRandomAccessStream();
            IOutputStream outputStream = randomAccessStream.GetOutputStreamAt(0);
            DataWriter writer = new DataWriter(outputStream);
            writer.WriteBytes(bytes);
            await writer.StoreAsync();
            await writer.FlushAsync();
            return RandomAccessStreamReference.CreateFromStream(randomAccessStream);
        }
```

```cppwinrt
...
#include <winrt/Windows.Storage.Streams.h>
...
Windows::Foundation::IAsyncOperation<Windows::Storage::Streams::InMemoryRandomAccessStream> MainPage::CustomRandomAccessStream()
{
    constexpr int pixelHeight{ 256 };
    constexpr int pixelWidth{ 256 };
    constexpr int bpp{ 4 };

    std::array<uint8_t, pixelHeight * pixelWidth * bpp> bytes;

    for (int y = 0; y < pixelHeight; y++)
    {
        for (int x = 0; x < pixelWidth; x++)
        {
            int pixelIndex{ y * pixelWidth + x };
            int byteIndex{ pixelIndex * bpp };

            // Set the current pixel bytes.
            bytes[byteIndex] = (byte)(std::rand() % 256);        // Red
            bytes[byteIndex + 1] = (byte)(std::rand() % 256);    // Green
            bytes[byteIndex + 2] = (byte)(std::rand() % 256);    // Blue
            bytes[byteIndex + 3] = (byte)((std::rand() % 56) + 200);    // Alpha (0xff = fully opaque)
        }
    }

    // Create RandomAccessStream from byte array.
    Windows::Storage::Streams::InMemoryRandomAccessStream randomAccessStream;
    Windows::Storage::Streams::IOutputStream outputStream{ randomAccessStream.GetOutputStreamAt(0) };
    Windows::Storage::Streams::DataWriter writer{ outputStream };
    writer.WriteBytes(bytes);

    co_await writer.StoreAsync();
    co_await writer.FlushAsync();

    co_return randomAccessStream;
}
...
```

```cpp
InMemoryRandomAccessStream^ TileSources::CustomRandomAccessStream::get()
{
    int pixelHeight = 256;
    int pixelWidth = 256;
    int bpp = 4;

    Array<byte>^ bytes = ref new Array<byte>(pixelHeight * pixelWidth * bpp);

    for (int y = 0; y < pixelHeight; y++)
    {
        for (int x = 0; x < pixelWidth; x++)
        {
            int pixelIndex = y * pixelWidth + x;
            int byteIndex = pixelIndex * bpp;

            // Set the current pixel bytes.
            bytes[byteIndex] = (byte)(std::rand() % 256);        // Red
            bytes[byteIndex + 1] = (byte)(std::rand() % 256);    // Green
            bytes[byteIndex + 2] = (byte)(std::rand() % 256);    // Blue
            bytes[byteIndex + 3] = (byte)((std::rand() % 56) + 200);    // Alpha (0xff = fully opaque)
        }
    }

    // Create RandomAccessStream from byte array.
    InMemoryRandomAccessStream^ randomAccessStream = ref new InMemoryRandomAccessStream();
    IOutputStream^ outputStream = randomAccessStream->GetOutputStreamAt(0);
    DataWriter^ writer = ref new DataWriter(outputStream);
    writer->WriteBytes(bytes);

    create_task(writer->StoreAsync()).then([writer](unsigned int)
    {
        create_task(writer->FlushAsync());
    });

    return randomAccessStream;
}
```

## <a name="replace-the-default-map"></a>既定の地図の置き換え

既定の地図をサード パーティ製タイルまたはカスタム タイルに完全に置き換えるには、次の手順に従います。

-   [**MapTileSource**](https://msdn.microsoft.com/library/windows/apps/dn637144) の [**Layer**](https://msdn.microsoft.com/library/windows/apps/dn637157) プロパティ値として [**MapTileLayer**](https://msdn.microsoft.com/library/windows/apps/dn637143).**BackgroundReplacement** を指定します。
-   [**MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004) の [**Style**](https://msdn.microsoft.com/library/windows/apps/dn637051) プロパティ値として [**MapStyle**](https://msdn.microsoft.com/library/windows/apps/dn637127).**None** を指定します。

## <a name="related-topics"></a>関連トピック

* [Bing Maps Developer Center](https://www.bingmapsportal.com/)
* [UWP の地図サンプル](http://go.microsoft.com/fwlink/p/?LinkId=619977)
* [地図の設計ガイドライン](https://msdn.microsoft.com/library/windows/apps/dn596102)
* [Build 2015 のビデオ: Windows アプリでの電話、タブレット、PC で使用できるマップと位置情報の活用](https://channel9.msdn.com/Events/Build/2015/2-757)
* [UWP の交通情報アプリのサンプル](http://go.microsoft.com/fwlink/p/?LinkId=619982)
