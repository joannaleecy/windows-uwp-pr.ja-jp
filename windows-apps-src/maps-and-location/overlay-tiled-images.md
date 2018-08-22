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
ms.sourcegitcommit: f2f4820dd2026f1b47a2b1bf2bc89d7220a79c1a
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/22/2018
ms.locfileid: "2788637"
---
# <a name="overlay-tiled-images-on-a-map"></a><span data-ttu-id="26790-105">地図へのタイル画像のオーバーレイ</span><span class="sxs-lookup"><span data-stu-id="26790-105">Overlay tiled images on a map</span></span>

<span data-ttu-id="26790-106">タイル ソースを使って、地図上にサード パーティ製タイルまたはカスタム タイル画像をオーバーレイします。</span><span class="sxs-lookup"><span data-stu-id="26790-106">Overlay third-party or custom tiled images on a map by using tile sources.</span></span> <span data-ttu-id="26790-107">タイル ソースを使って、気象データ、人口データ、地質データなどの特殊な情報をオーバーレイすることや、既定の地図を完全に置き換えることができます。</span><span class="sxs-lookup"><span data-stu-id="26790-107">Use tile sources to overlay specialized information such as weather data, population data, or seismic data; or use tile sources to replace the default map entirely.</span></span>

<span data-ttu-id="26790-108">**ヒント** アプリでの地図の使用について詳しくは、Github で[ユニバーサル Windows プラットフォーム (UWP) の地図サンプル](http://go.microsoft.com/fwlink/p/?LinkId=619977)をダウンロードしてください。</span><span class="sxs-lookup"><span data-stu-id="26790-108">**Tip** To learn more about using maps in your app, download the [Universal Windows Platform (UWP) map sample](http://go.microsoft.com/fwlink/p/?LinkId=619977) on Github.</span></span>

<a id="tileintro" />

## <a name="tiled-image-overview"></a><span data-ttu-id="26790-109">タイル画像の概要</span><span class="sxs-lookup"><span data-stu-id="26790-109">Tiled image overview</span></span>

<span data-ttu-id="26790-110">Nokia Maps や Bing Maps などのマップ サービスでは、迅速な取得と表示のために正方形タイルに地図を切り取ります。</span><span class="sxs-lookup"><span data-stu-id="26790-110">Map services such as Nokia Maps and Bing Maps cut maps into square tiles for quick retrieval and display.</span></span> <span data-ttu-id="26790-111">こうしたタイルは 256 ピクセル x 256 ピクセル サイズであり、いくつかの詳細レベルで事前にレンダリングされます。</span><span class="sxs-lookup"><span data-stu-id="26790-111">These tiles are 256 pixels by 256 pixels in size, and are pre-rendered at multiple levels of detail.</span></span> <span data-ttu-id="26790-112">また、多くのサード パーティ サービスがタイルに切り取られた地図ベースのデータを提供しています。</span><span class="sxs-lookup"><span data-stu-id="26790-112">Many third-party services also provide map-based data that's cut into tiles.</span></span> <span data-ttu-id="26790-113">タイル ソースを使ってサード パーティ製タイルを取得するか、独自のカスタム タイルを作成してそれを [**MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004) に表示された地図上にオーバーレイできます。</span><span class="sxs-lookup"><span data-stu-id="26790-113">Use tile sources to retrieve third-party tiles, or to create your own custom tiles, and overlay them on the map displayed in the [**MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004).</span></span>

**<span data-ttu-id="26790-114">重要</span><span class="sxs-lookup"><span data-stu-id="26790-114">Important</span></span>**  
<span data-ttu-id="26790-115">タイル ソースを使う場合、個々のタイルの要求または配置のためにコードを記述する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="26790-115">When you use tile sources, you don't have to write code to request or to position individual tiles.</span></span> <span data-ttu-id="26790-116">[**MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004) が必要時にタイルを要求します。</span><span class="sxs-lookup"><span data-stu-id="26790-116">The [**MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004) requests tiles as it needs them.</span></span> <span data-ttu-id="26790-117">各要求では、個々のタイルについて X 座標と Y 座標、ズーム レベルを指定します。</span><span class="sxs-lookup"><span data-stu-id="26790-117">Each request specifies the X and Y coordinates and the zoom level for the individual tile.</span></span> <span data-ttu-id="26790-118">タイルを取得するために使う URI またはファイル名の形式を **UriFormatString** プロパティに指定します。</span><span class="sxs-lookup"><span data-stu-id="26790-118">You simply specify the format of the Uri or filename to use to retrieve the tiles in the **UriFormatString** property.</span></span> <span data-ttu-id="26790-119">つまり、各タイルの X 座標、Y 座標、ズーム レベルを渡す場所を示すベース URI またはファイル名に、置き換え可能なパラメーターを挿入します。</span><span class="sxs-lookup"><span data-stu-id="26790-119">That is, you insert replaceable parameters in the base Uri or filename to indicate where to pass the X and Y coordinates and the zoom level for each tile.</span></span>

<span data-ttu-id="26790-120">次に、X 座標、Y 座標、ズーム レベルの置き換え可能なパラメーターを示す [**HttpMapTileDataSource**](https://msdn.microsoft.com/library/windows/apps/dn636986) の [**UriFormatString**](https://msdn.microsoft.com/library/windows/apps/dn636992) プロパティの例を示します。</span><span class="sxs-lookup"><span data-stu-id="26790-120">Here's an example of the [**UriFormatString**](https://msdn.microsoft.com/library/windows/apps/dn636992) property for an [**HttpMapTileDataSource**](https://msdn.microsoft.com/library/windows/apps/dn636986) that shows the replaceable parameters for the X and Y coordinates and the zoom level.</span></span>

```syntax
http://www.<web service name>.com/z={zoomlevel}&x={x}&y={y}
```

<span data-ttu-id="26790-121">X 座標と Y 座標は、指定された詳細レベルで世界地図内の個々のタイルの場所を表します。</span><span class="sxs-lookup"><span data-stu-id="26790-121">(The X and Y coordinates represent the location of the individual tile within the map of the world at the specified level of detail.</span></span> <span data-ttu-id="26790-122">タイルの番号付けは、地図の左上端の {0, 0} から開始します。</span><span class="sxs-lookup"><span data-stu-id="26790-122">The tile numbering system starts from {0, 0} in the upper left corner of the map.</span></span> <span data-ttu-id="26790-123">たとえば、{1, 2} のタイルは、タイル グリッドの第 1 行の第 2 列にあります。</span><span class="sxs-lookup"><span data-stu-id="26790-123">For example, the tile at {1, 2} is in the second column of the third row of the grid of tiles.)</span></span>

<span data-ttu-id="26790-124">マッピング サービスにより使用されるタイル システムについては、[Bing Maps タイル システムに関するページ (英語) ](http://go.microsoft.com/fwlink/p/?LinkId=626692)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="26790-124">For more info about the tile system used by mapping services, see [Bing Maps Tile System](http://go.microsoft.com/fwlink/p/?LinkId=626692).</span></span>

### <a name="overlay-tiles-from-a-tile-source"></a><span data-ttu-id="26790-125">タイル ソースからのタイルのオーバーレイ</span><span class="sxs-lookup"><span data-stu-id="26790-125">Overlay tiles from a tile source</span></span>

<span data-ttu-id="26790-126">[**MapTileDataSource**](https://msdn.microsoft.com/library/windows/apps/dn637141) を使って、タイル ソースからのタイル画像を地図にオーバーレイします。</span><span class="sxs-lookup"><span data-stu-id="26790-126">Overlay tiled images from a tile source on a map by using the [**MapTileDataSource**](https://msdn.microsoft.com/library/windows/apps/dn637141).</span></span>

1.  <span data-ttu-id="26790-127">[**MapTileDataSource**](https://msdn.microsoft.com/library/windows/apps/dn637141) から継承する 3 つのタイル データ ソース クラスのいずれかをインスタンス化します。</span><span class="sxs-lookup"><span data-stu-id="26790-127">Instantiate one of the three tile data source classes that inherit from [**MapTileDataSource**](https://msdn.microsoft.com/library/windows/apps/dn637141).</span></span>

    -   [**<span data-ttu-id="26790-128">HttpMapTileDataSource</span><span class="sxs-lookup"><span data-stu-id="26790-128">HttpMapTileDataSource</span></span>**](https://msdn.microsoft.com/library/windows/apps/dn636986)
    -   [**<span data-ttu-id="26790-129">LocalMapTileDataSource</span><span class="sxs-lookup"><span data-stu-id="26790-129">LocalMapTileDataSource</span></span>**](https://msdn.microsoft.com/library/windows/apps/dn636994)
    -   [**<span data-ttu-id="26790-130">CustomMapTileDataSource</span><span class="sxs-lookup"><span data-stu-id="26790-130">CustomMapTileDataSource</span></span>**](https://msdn.microsoft.com/library/windows/apps/dn636983)

    <span data-ttu-id="26790-131">ベース URI またはファイル名に置き換え可能なパラメーターを挿入することにより、タイルの要求に使う **UriFormatString** を構成します。</span><span class="sxs-lookup"><span data-stu-id="26790-131">Configure the **UriFormatString** to use to request the tiles by inserting replaceable parameters in the base Uri or filename.</span></span>

    <span data-ttu-id="26790-132">次の例では、[**HttpMapTileDataSource**](https://msdn.microsoft.com/library/windows/apps/dn636986) をインスタンス化します。</span><span class="sxs-lookup"><span data-stu-id="26790-132">The following example instantiates an [**HttpMapTileDataSource**](https://msdn.microsoft.com/library/windows/apps/dn636986).</span></span> <span data-ttu-id="26790-133">次の例では、**HttpMapTileDataSource** のコンストラクターで [**UriFormatString**](https://msdn.microsoft.com/library/windows/apps/dn636992) の値を指定しています。</span><span class="sxs-lookup"><span data-stu-id="26790-133">This example specifies the value of the [**UriFormatString**](https://msdn.microsoft.com/library/windows/apps/dn636992) in the constructor of the **HttpMapTileDataSource**.</span></span>

    ```csharp
        HttpMapTileDataSource dataSource = new HttpMapTileDataSource(
          "http://www.<web service name>.com/z={zoomlevel}&x={x}&y={y}");
    ```

2.  <span data-ttu-id="26790-134">[**MapTileSource**](https://msdn.microsoft.com/library/windows/apps/dn637144) をインスタンス化および構成します。</span><span class="sxs-lookup"><span data-stu-id="26790-134">Instantiate and configure a [**MapTileSource**](https://msdn.microsoft.com/library/windows/apps/dn637144).</span></span> <span data-ttu-id="26790-135">以前の手順で **MapTileSource** の [**DataSource**](https://msdn.microsoft.com/library/windows/apps/dn637149) として構成した [**MapTileDataSource**](https://msdn.microsoft.com/library/windows/apps/dn637141) を指定します。</span><span class="sxs-lookup"><span data-stu-id="26790-135">Specify the [**MapTileDataSource**](https://msdn.microsoft.com/library/windows/apps/dn637141) that you configured in the previous step as the [**DataSource**](https://msdn.microsoft.com/library/windows/apps/dn637149) of the **MapTileSource**.</span></span>

    <span data-ttu-id="26790-136">次の例では、[**MapTileSource**](https://msdn.microsoft.com/library/windows/apps/dn637144) のコンストラクターで [**DataSource**](https://msdn.microsoft.com/library/windows/apps/dn637149) を指定しています。</span><span class="sxs-lookup"><span data-stu-id="26790-136">The following example specifies the [**DataSource**](https://msdn.microsoft.com/library/windows/apps/dn637149) in the constructor of the [**MapTileSource**](https://msdn.microsoft.com/library/windows/apps/dn637144).</span></span>

    ```csharp
        MapTileSource tileSource = new MapTileSource(dataSource);
    ```

    <span data-ttu-id="26790-137">[**MapTileSource**](https://msdn.microsoft.com/library/windows/apps/dn637144) のプロパティを使うことにより、タイルが表示される条件を制限できます。</span><span class="sxs-lookup"><span data-stu-id="26790-137">You can restrict the conditions in which the tiles are displayed by using properties of the [**MapTileSource**](https://msdn.microsoft.com/library/windows/apps/dn637144).</span></span>

    -   <span data-ttu-id="26790-138">[**Bounds**](https://msdn.microsoft.com/library/windows/apps/dn637147) プロパティの値を指定することにより、特定地域内にのみタイルを表示します。</span><span class="sxs-lookup"><span data-stu-id="26790-138">Display tiles only within a specific geographic area by providing a value for the [**Bounds**](https://msdn.microsoft.com/library/windows/apps/dn637147) property.</span></span>
    -   <span data-ttu-id="26790-139">[**ZoomLevelRange**](https://msdn.microsoft.com/library/windows/apps/dn637171) プロパティの値を指定することにより、特定の詳細レベルでのみタイルを表示します。</span><span class="sxs-lookup"><span data-stu-id="26790-139">Display tiles only at certain levels of detail by providing a value for the [**ZoomLevelRange**](https://msdn.microsoft.com/library/windows/apps/dn637171) property.</span></span>

    <span data-ttu-id="26790-140">オプションで、[**Layer**](https://msdn.microsoft.com/library/windows/apps/dn637157)、[**AllowOverstretch**](https://msdn.microsoft.com/library/windows/apps/dn637145)、[**IsRetryEnabled**](https://msdn.microsoft.com/library/windows/apps/dn637153)、[**IsTransparencyEnabled**](https://msdn.microsoft.com/library/windows/apps/dn637155) など、タイルの読み込みまたは表示に影響する [**MapTileSource**](https://msdn.microsoft.com/library/windows/apps/dn637144) の他のプロパティを構成します。</span><span class="sxs-lookup"><span data-stu-id="26790-140">Optionally, configure other properties of the [**MapTileSource**](https://msdn.microsoft.com/library/windows/apps/dn637144) that affect the loading or the display of the tiles, such as [**Layer**](https://msdn.microsoft.com/library/windows/apps/dn637157), [**AllowOverstretch**](https://msdn.microsoft.com/library/windows/apps/dn637145), [**IsRetryEnabled**](https://msdn.microsoft.com/library/windows/apps/dn637153), and [**IsTransparencyEnabled**](https://msdn.microsoft.com/library/windows/apps/dn637155).</span></span>

3.  <span data-ttu-id="26790-141">[**MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004) の [**TileSources**](https://msdn.microsoft.com/library/windows/apps/dn637053) コレクションに [**MapTileSource**](https://msdn.microsoft.com/library/windows/apps/dn637144) を追加します。</span><span class="sxs-lookup"><span data-stu-id="26790-141">Add the [**MapTileSource**](https://msdn.microsoft.com/library/windows/apps/dn637144) to the [**TileSources**](https://msdn.microsoft.com/library/windows/apps/dn637053) collection of the [**MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004).</span></span>

    ```csharp
         MapControl1.TileSources.Add(tileSource);
    ```

## <a name="overlay-tiles-from-a-web-service"></a><span data-ttu-id="26790-142">Web サービスからのタイルのオーバーレイ</span><span class="sxs-lookup"><span data-stu-id="26790-142">Overlay tiles from a web service</span></span>


<span data-ttu-id="26790-143">[**HttpMapTileDataSource**](https://msdn.microsoft.com/library/windows/apps/dn636986) を使って、Web サービスから取得したタイル画像をオーバーレイします。</span><span class="sxs-lookup"><span data-stu-id="26790-143">Overlay tiled images retrieved from a web service by using the [**HttpMapTileDataSource**](https://msdn.microsoft.com/library/windows/apps/dn636986).</span></span>

1.  <span data-ttu-id="26790-144">[**HttpMapTileDataSource**](https://msdn.microsoft.com/library/windows/apps/dn636986) をインスタンス化します。</span><span class="sxs-lookup"><span data-stu-id="26790-144">Instantiate an [**HttpMapTileDataSource**](https://msdn.microsoft.com/library/windows/apps/dn636986).</span></span>
2.  <span data-ttu-id="26790-145">Web サービスで [**UriFormatString**](https://msdn.microsoft.com/library/windows/apps/dn636992) プロパティの値として想定される URI の形式を指定します。</span><span class="sxs-lookup"><span data-stu-id="26790-145">Specify the format of the Uri that the web service expects as the value of the [**UriFormatString**](https://msdn.microsoft.com/library/windows/apps/dn636992) property.</span></span> <span data-ttu-id="26790-146">この値を作成するには、ベース URI に置き換え可能なパラメーターを挿入します。</span><span class="sxs-lookup"><span data-stu-id="26790-146">To create this value, insert replaceable parameters in the base Uri.</span></span> <span data-ttu-id="26790-147">たとえば次のコード サンプルでは、**UriFormatString** の値は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="26790-147">For example, in the following code sample, the value of the **UriFormatString** is:</span></span>

    ``` syntax
    http://www.<web service name>.com/z={zoomlevel}&x={x}&y={y}
    ```

    <span data-ttu-id="26790-148">この Web サービスでは、置き換え可能なパラメーター {x}、{y}、{zoomlevel} を含む URI をサポートする必要があります。</span><span class="sxs-lookup"><span data-stu-id="26790-148">The web service has to support a Uri that contains the replaceable parameters {x}, {y}, and {zoomlevel}.</span></span> <span data-ttu-id="26790-149">大半の Web サービス (たとえば Nokia、Bing、Google など) で、この形式の URI がサポートされています。</span><span class="sxs-lookup"><span data-stu-id="26790-149">Most web services (for example, Nokia, Bing, and Google) support Uris in this format.</span></span> <span data-ttu-id="26790-150">[**UriFormatString**](https://msdn.microsoft.com/library/windows/apps/dn636992) プロパティで使用できない追加引数が Web サービスで必要な場合は、カスタム URI を作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="26790-150">If the web service requires additional arguments that aren't available with the [**UriFormatString**](https://msdn.microsoft.com/library/windows/apps/dn636992) property, then you have to create a custom Uri.</span></span> <span data-ttu-id="26790-151">[**UriRequested**](https://msdn.microsoft.com/library/windows/apps/dn636993) イベントを処理することにより、カスタム URI を作成して返します。</span><span class="sxs-lookup"><span data-stu-id="26790-151">Create and return a custom Uri by handling the [**UriRequested**](https://msdn.microsoft.com/library/windows/apps/dn636993) event.</span></span> <span data-ttu-id="26790-152">詳しくは、このトピックで後述する「[カスタム URI の指定](#customuri)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="26790-152">For more info, see the [Provide a custom URI](#customuri) section later in this topic.</span></span>

3.  <span data-ttu-id="26790-153">次に、「[タイル画像の概要](#tileintro)」で説明した残りの手順に従います。</span><span class="sxs-lookup"><span data-stu-id="26790-153">Then, follow the remaining steps described previously in the [Tiled image overview](#tileintro).</span></span>

<span data-ttu-id="26790-154">次の例では、北米のマップに架空の Web サービスからのタイルをオーバーレイしています。</span><span class="sxs-lookup"><span data-stu-id="26790-154">The following example overlays tiles from a fictitious web service on a map of North America.</span></span> <span data-ttu-id="26790-155">[**HttpMapTileDataSource**](https://msdn.microsoft.com/library/windows/apps/dn636986) のコンストラクターで [**UriFormatString**](https://msdn.microsoft.com/library/windows/apps/dn636992) の値を指定しています。</span><span class="sxs-lookup"><span data-stu-id="26790-155">The value of the [**UriFormatString**](https://msdn.microsoft.com/library/windows/apps/dn636992) is specified in the constructor of the [**HttpMapTileDataSource**](https://msdn.microsoft.com/library/windows/apps/dn636986).</span></span> <span data-ttu-id="26790-156">この例では、省略可能な [**Bounds**](https://msdn.microsoft.com/library/windows/apps/dn637147) プロパティによって指定した地理的境界内にのみタイルが表示されます。</span><span class="sxs-lookup"><span data-stu-id="26790-156">In this example, tiles are only displayed within the geographic boundaries specified by the optional [**Bounds**](https://msdn.microsoft.com/library/windows/apps/dn637147) property.</span></span>

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

## <a name="overlay-tiles-from-local-storage"></a><span data-ttu-id="26790-157">ローカル記憶域からのタイルのオーバーレイ</span><span class="sxs-lookup"><span data-stu-id="26790-157">Overlay tiles from local storage</span></span>


<span data-ttu-id="26790-158">[**LocalMapTileDataSource**](https://msdn.microsoft.com/library/windows/apps/dn636994) を使って、ローカル ストレージにファイルとして格納されたタイル画像をオーバーレイします。</span><span class="sxs-lookup"><span data-stu-id="26790-158">Overlay tiled images stored as files in local storage by using the [**LocalMapTileDataSource**](https://msdn.microsoft.com/library/windows/apps/dn636994).</span></span> <span data-ttu-id="26790-159">通常、こうしたファイルはアプリと共にパッケージ化して配布します。</span><span class="sxs-lookup"><span data-stu-id="26790-159">Typically, you package and distribute these files with your app.</span></span>

1.  <span data-ttu-id="26790-160">[**LocalMapTileDataSource**](https://msdn.microsoft.com/library/windows/apps/dn636994) をインスタンス化します。</span><span class="sxs-lookup"><span data-stu-id="26790-160">Instantiate a [**LocalMapTileDataSource**](https://msdn.microsoft.com/library/windows/apps/dn636994).</span></span>
2.  <span data-ttu-id="26790-161">[**UriFormatString**](https://msdn.microsoft.com/library/windows/apps/dn636998) プロパティの値としてファイル名の形式を指定します。</span><span class="sxs-lookup"><span data-stu-id="26790-161">Specify the format of the file names as the value of the [**UriFormatString**](https://msdn.microsoft.com/library/windows/apps/dn636998) property.</span></span> <span data-ttu-id="26790-162">この値を作成するには、ベース ファイル名に置き換え可能なパラメーターを挿入します。</span><span class="sxs-lookup"><span data-stu-id="26790-162">To create this value, insert replaceable parameters in the base filename.</span></span> <span data-ttu-id="26790-163">たとえば次のコード サンプルでは、[**UriFormatString**](https://msdn.microsoft.com/library/windows/apps/dn636992) の値は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="26790-163">For example, in the following code sample, the value of the [**UriFormatString**](https://msdn.microsoft.com/library/windows/apps/dn636992) is:</span></span>

    ``` syntax
        Tile_{zoomlevel}_{x}_{y}.png
    ```

    <span data-ttu-id="26790-164">[**UriFormatString**](https://msdn.microsoft.com/library/windows/apps/dn636998) プロパティで使用できない追加引数がファイル名の形式で必要な場合は、カスタム URI を作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="26790-164">If the format of the file names requires additional arguments that aren't available with the [**UriFormatString**](https://msdn.microsoft.com/library/windows/apps/dn636998) property, then you have to create a custom Uri.</span></span> <span data-ttu-id="26790-165">[**UriRequested**](https://msdn.microsoft.com/library/windows/apps/dn637001) イベントを処理することにより、カスタム URI を作成して返します。</span><span class="sxs-lookup"><span data-stu-id="26790-165">Create and return a custom Uri by handling the [**UriRequested**](https://msdn.microsoft.com/library/windows/apps/dn637001) event.</span></span> <span data-ttu-id="26790-166">詳しくは、このトピックで後述する「[カスタム URI の指定](#customuri)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="26790-166">For more info, see the [Provide a custom URI](#customuri) section later in this topic.</span></span>

3.  <span data-ttu-id="26790-167">次に、「[タイル画像の概要](#tileintro)」で説明した残りの手順に従います。</span><span class="sxs-lookup"><span data-stu-id="26790-167">Then, follow the remaining steps described previously in the [Tiled image overview](#tileintro).</span></span>

<span data-ttu-id="26790-168">ローカル ストレージからタイルを読み込むために、次のプロトコルと場所を使用できます。</span><span class="sxs-lookup"><span data-stu-id="26790-168">You can use the following protocols and locations to load tiles from local storage:</span></span>

| <span data-ttu-id="26790-169">URI</span><span class="sxs-lookup"><span data-stu-id="26790-169">Uri</span></span> | <span data-ttu-id="26790-170">詳細</span><span class="sxs-lookup"><span data-stu-id="26790-170">More info</span></span> |
|---------------------|----------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="26790-171">ms-appx:///</span><span class="sxs-lookup"><span data-stu-id="26790-171">ms-appx:///</span></span> | <span data-ttu-id="26790-172">アプリのインストール フォルダーのルートを参照します。</span><span class="sxs-lookup"><span data-stu-id="26790-172">Points to the root of the app's installation folder.</span></span> |
|  | <span data-ttu-id="26790-173">これは、[Package.InstalledLocation](https://msdn.microsoft.com/library/windows/apps/br224681) プロパティによって参照される場所です。</span><span class="sxs-lookup"><span data-stu-id="26790-173">This is the location referenced by the [Package.InstalledLocation](https://msdn.microsoft.com/library/windows/apps/br224681) property.</span></span> |
| <span data-ttu-id="26790-174">ms-appdata:///local</span><span class="sxs-lookup"><span data-stu-id="26790-174">ms-appdata:///local</span></span> | <span data-ttu-id="26790-175">アプリのローカル ストレージのルートを参照します。</span><span class="sxs-lookup"><span data-stu-id="26790-175">Points to the root of the app's local storage.</span></span> |
|  | <span data-ttu-id="26790-176">これは、[ApplicationData.LocalFolder](https://msdn.microsoft.com/library/windows/apps/br241621) プロパティによって参照される場所です。</span><span class="sxs-lookup"><span data-stu-id="26790-176">This is the location referenced by the [ApplicationData.LocalFolder](https://msdn.microsoft.com/library/windows/apps/br241621) property.</span></span> |
| <span data-ttu-id="26790-177">ms-appdata:///temp</span><span class="sxs-lookup"><span data-stu-id="26790-177">ms-appdata:///temp</span></span> | <span data-ttu-id="26790-178">アプリの一時フォルダーを参照します。</span><span class="sxs-lookup"><span data-stu-id="26790-178">Points to the app's temp folder.</span></span> |
|  | <span data-ttu-id="26790-179">これは、[ApplicationData.TemporaryFolder](https://msdn.microsoft.com/library/windows/apps/br241629) プロパティによって参照される場所です。</span><span class="sxs-lookup"><span data-stu-id="26790-179">This is the location referenced by the [ApplicationData.TemporaryFolder](https://msdn.microsoft.com/library/windows/apps/br241629) property.</span></span> |

 

<span data-ttu-id="26790-180">次の例では、`ms-appx:///` プロトコルを使って、アプリのインストール フォルダーにファイルとして格納されたタイルを読み込みます。</span><span class="sxs-lookup"><span data-stu-id="26790-180">The following example loads tiles that are stored as files in the app's installation folder by using the `ms-appx:///` protocol.</span></span> <span data-ttu-id="26790-181">[**LocalMapTileDataSource**](https://msdn.microsoft.com/library/windows/apps/dn636994) のコンストラクターで [**UriFormatString**](https://msdn.microsoft.com/library/windows/apps/dn636998) の値を指定しています。</span><span class="sxs-lookup"><span data-stu-id="26790-181">The value for the [**UriFormatString**](https://msdn.microsoft.com/library/windows/apps/dn636998) is specified in the constructor of the [**LocalMapTileDataSource**](https://msdn.microsoft.com/library/windows/apps/dn636994).</span></span> <span data-ttu-id="26790-182">この例では、省略可能な [**ZoomLevelRange**](https://msdn.microsoft.com/library/windows/apps/dn637171) プロパティによって指定された範囲内に地図のズーム レベルがある場合にのみ、タイルが表示されます。</span><span class="sxs-lookup"><span data-stu-id="26790-182">In this example, tiles are only displayed when the zoom level of the map is within the range specified by the optional [**ZoomLevelRange**](https://msdn.microsoft.com/library/windows/apps/dn637171) property.</span></span>

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

## <a name="provide-a-custom-uri"></a><span data-ttu-id="26790-183">カスタム URI の指定</span><span class="sxs-lookup"><span data-stu-id="26790-183">Provide a custom URI</span></span>

<span data-ttu-id="26790-184">[**HttpMapTileDataSource**](https://msdn.microsoft.com/library/windows/apps/dn636986) の [**UriFormatString**](https://msdn.microsoft.com/library/windows/apps/dn636992) プロパティまたは [**LocalMapTileDataSource**](https://msdn.microsoft.com/library/windows/apps/dn636994) の [**UriFormatString**](https://msdn.microsoft.com/library/windows/apps/dn636998) プロパティにより使用できる置き換え可能なパラメーターがタイルの取得に十分でない場合は、カスタム URI を作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="26790-184">If the replaceable parameters available with the [**UriFormatString**](https://msdn.microsoft.com/library/windows/apps/dn636992) property of the [**HttpMapTileDataSource**](https://msdn.microsoft.com/library/windows/apps/dn636986) or the [**UriFormatString**](https://msdn.microsoft.com/library/windows/apps/dn636998) property of the [**LocalMapTileDataSource**](https://msdn.microsoft.com/library/windows/apps/dn636994) aren't sufficient to retrieve your tiles, then you have to create a custom Uri.</span></span> <span data-ttu-id="26790-185">**UriRequested** イベントのカスタム ハンドラーを指定することによりカスタム URI を作成して返します。</span><span class="sxs-lookup"><span data-stu-id="26790-185">Create and return a custom Uri by providing a custom handler for the **UriRequested** event.</span></span> <span data-ttu-id="26790-186">**UriRequested** イベントは、個々のタイルについて発生します。</span><span class="sxs-lookup"><span data-stu-id="26790-186">The **UriRequested** event is raised for each individual tile.</span></span>

1.  <span data-ttu-id="26790-187">カスタム URI を作成するために、**UriRequested** イベントのカスタム ハンドラーで、[**MapTileUriRequestedEventArgs**](https://msdn.microsoft.com/library/windows/apps/dn637177) の [**X**](https://msdn.microsoft.com/library/windows/apps/dn610743) プロパティ、[**Y**](https://msdn.microsoft.com/library/windows/apps/dn610744) プロパティ、[**ZoomLevel**](https://msdn.microsoft.com/library/windows/apps/dn610745) プロパティにより必要なカスタム引数を組み合わせます。</span><span class="sxs-lookup"><span data-stu-id="26790-187">In your custom handler for the **UriRequested** event, combine the required custom arguments with the [**X**](https://msdn.microsoft.com/library/windows/apps/dn610743), [**Y**](https://msdn.microsoft.com/library/windows/apps/dn610744), and [**ZoomLevel**](https://msdn.microsoft.com/library/windows/apps/dn610745) properties of the [**MapTileUriRequestedEventArgs**](https://msdn.microsoft.com/library/windows/apps/dn637177) to create the custom Uri.</span></span>
2.  <span data-ttu-id="26790-188">[**MapTileUriRequestedEventArgs**](https://msdn.microsoft.com/library/windows/apps/dn637177) の [**Request**](https://msdn.microsoft.com/library/windows/apps/dn637179) プロパティに含まれている [**MapTileUriRequest**](https://msdn.microsoft.com/library/windows/apps/dn637173) の [**Uri**](https://msdn.microsoft.com/library/windows/apps/dn610748) プロパティにカスタム URI を返します。</span><span class="sxs-lookup"><span data-stu-id="26790-188">Return the custom Uri in the [**Uri**](https://msdn.microsoft.com/library/windows/apps/dn610748) property of the [**MapTileUriRequest**](https://msdn.microsoft.com/library/windows/apps/dn637173), which is contained in the [**Request**](https://msdn.microsoft.com/library/windows/apps/dn637179) property of the [**MapTileUriRequestedEventArgs**](https://msdn.microsoft.com/library/windows/apps/dn637177).</span></span>

<span data-ttu-id="26790-189">次の例では、**UriRequested** イベントのカスタム ハンドラーを作成することによりカスタム URI を指定する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="26790-189">The following example shows how to provide a custom Uri by creating a custom handler for the **UriRequested** event.</span></span> <span data-ttu-id="26790-190">また、カスタム URI を作成するために非同期処理が必要な場合に、保留パターンを実装する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="26790-190">It also shows how to implement the deferral pattern if you have to do something asynchronously to create the custom Uri.</span></span>

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

## <a name="overlay-tiles-from-a-custom-source"></a><span data-ttu-id="26790-191">カスタム ソースからのタイルのオーバーレイ</span><span class="sxs-lookup"><span data-stu-id="26790-191">Overlay tiles from a custom source</span></span>

<span data-ttu-id="26790-192">[**CustomMapTileDataSource**](https://msdn.microsoft.com/library/windows/apps/dn636983) を使って、カスタム タイルをオーバーレイします。</span><span class="sxs-lookup"><span data-stu-id="26790-192">Overlay custom tiles by using the [**CustomMapTileDataSource**](https://msdn.microsoft.com/library/windows/apps/dn636983).</span></span> <span data-ttu-id="26790-193">プログラムによってメモリ内で随時にタイルを作成するか、または別のソースから既存のタイルを読み込むために独自のコードを記述します。</span><span class="sxs-lookup"><span data-stu-id="26790-193">Create tiles programmatically in memory on the fly, or write your own code to load existing tiles from another source.</span></span>

<span data-ttu-id="26790-194">カスタム タイルを作成するか読み込むには、[**BitmapRequested**](https://msdn.microsoft.com/library/windows/apps/dn636984) イベントのカスタム ハンドラーを指定します。</span><span class="sxs-lookup"><span data-stu-id="26790-194">To create or load custom tiles, provide a custom handler for the [**BitmapRequested**](https://msdn.microsoft.com/library/windows/apps/dn636984) event.</span></span> <span data-ttu-id="26790-195">**BitmapRequested** イベントは、個々のタイルについて発生します。</span><span class="sxs-lookup"><span data-stu-id="26790-195">The **BitmapRequested** event is raised for each individual tile.</span></span>

1.  <span data-ttu-id="26790-196">カスタム タイルを作成または取得するために、[**BitmapRequested**](https://msdn.microsoft.com/library/windows/apps/dn636984) イベントのカスタム ハンドラーで、[**MapTileBitmapRequestedEventArgs**](https://msdn.microsoft.com/library/windows/apps/dn637132) の [**X**](https://msdn.microsoft.com/library/windows/apps/dn637135) プロパティ、[**Y**](https://msdn.microsoft.com/library/windows/apps/dn637136) プロパティ、[**ZoomLevel**](https://msdn.microsoft.com/library/windows/apps/dn637137) プロパティにより必要なカスタム引数を組み合わせます。</span><span class="sxs-lookup"><span data-stu-id="26790-196">In your custom handler for the [**BitmapRequested**](https://msdn.microsoft.com/library/windows/apps/dn636984) event, combine the required custom arguments with the [**X**](https://msdn.microsoft.com/library/windows/apps/dn637135), [**Y**](https://msdn.microsoft.com/library/windows/apps/dn637136), and [**ZoomLevel**](https://msdn.microsoft.com/library/windows/apps/dn637137) properties of the [**MapTileBitmapRequestedEventArgs**](https://msdn.microsoft.com/library/windows/apps/dn637132) to create or retrieve a custom tile.</span></span>
2.  <span data-ttu-id="26790-197">[**MapTileBitmapRequestedEventArgs**](https://msdn.microsoft.com/library/windows/apps/dn637132) の [**Request**](https://msdn.microsoft.com/library/windows/apps/dn637134) プロパティに含まれている [**MapTileBitmapRequest**](https://msdn.microsoft.com/library/windows/apps/dn637128) の [**PixelData**](https://msdn.microsoft.com/library/windows/apps/dn637140) プロパティにカスタム タイルを返します。</span><span class="sxs-lookup"><span data-stu-id="26790-197">Return the custom tile in the [**PixelData**](https://msdn.microsoft.com/library/windows/apps/dn637140) property of the [**MapTileBitmapRequest**](https://msdn.microsoft.com/library/windows/apps/dn637128), which is contained in the [**Request**](https://msdn.microsoft.com/library/windows/apps/dn637134) property of the [**MapTileBitmapRequestedEventArgs**](https://msdn.microsoft.com/library/windows/apps/dn637132).</span></span> <span data-ttu-id="26790-198">**PixelData** プロパティの型は [**IRandomAccessStreamReference**](https://msdn.microsoft.com/library/windows/apps/hh701664) です。</span><span class="sxs-lookup"><span data-stu-id="26790-198">The **PixelData** property is of type [**IRandomAccessStreamReference**](https://msdn.microsoft.com/library/windows/apps/hh701664).</span></span>

<span data-ttu-id="26790-199">次の例では、**BitmapRequested** イベントのカスタム ハンドラーを作成することによりカスタム タイルを指定する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="26790-199">The following example shows how to provide custom tiles by creating a custom handler for the **BitmapRequested** event.</span></span> <span data-ttu-id="26790-200">この例では、一部が不透明な赤の同じタイルを作成します。</span><span class="sxs-lookup"><span data-stu-id="26790-200">This example creates identical red tiles that are partially opaque.</span></span> <span data-ttu-id="26790-201">この例では、[**MapTileBitmapRequestedEventArgs**](https://msdn.microsoft.com/library/windows/apps/dn637132) の [**X**](https://msdn.microsoft.com/library/windows/apps/dn637135) プロパティ、[**Y**](https://msdn.microsoft.com/library/windows/apps/dn637136) プロパティ、[**ZoomLevel**](https://msdn.microsoft.com/library/windows/apps/dn637137) プロパティを無視します。</span><span class="sxs-lookup"><span data-stu-id="26790-201">The example ignores the [**X**](https://msdn.microsoft.com/library/windows/apps/dn637135), [**Y**](https://msdn.microsoft.com/library/windows/apps/dn637136), and [**ZoomLevel**](https://msdn.microsoft.com/library/windows/apps/dn637137) properties of the [**MapTileBitmapRequestedEventArgs**](https://msdn.microsoft.com/library/windows/apps/dn637132).</span></span> <span data-ttu-id="26790-202">これは実際の例ではありませんが、メモリ内で随時にカスタム タイルを作成する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="26790-202">Although this is not a real world example, the example demonstrates how you can create in-memory custom tiles on the fly.</span></span> <span data-ttu-id="26790-203">この例ではまた、カスタム タイルを作成するために非同期処理が必要な場合に、保留パターンを実装する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="26790-203">The example also shows how to implement the deferral pattern if you have to do something asynchronously to create the custom tiles.</span></span>

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

## <a name="replace-the-default-map"></a><span data-ttu-id="26790-204">既定の地図の置き換え</span><span class="sxs-lookup"><span data-stu-id="26790-204">Replace the default map</span></span>

<span data-ttu-id="26790-205">既定の地図をサード パーティ製タイルまたはカスタム タイルに完全に置き換えるには、次の手順に従います。</span><span class="sxs-lookup"><span data-stu-id="26790-205">To replace the default map entirely with third-party or custom tiles:</span></span>

-   <span data-ttu-id="26790-206">[**MapTileSource**](https://msdn.microsoft.com/library/windows/apps/dn637144) の [**Layer**](https://msdn.microsoft.com/library/windows/apps/dn637157) プロパティ値として [**MapTileLayer**](https://msdn.microsoft.com/library/windows/apps/dn637143).**BackgroundReplacement** を指定します。</span><span class="sxs-lookup"><span data-stu-id="26790-206">Specify [**MapTileLayer**](https://msdn.microsoft.com/library/windows/apps/dn637143).**BackgroundReplacement** as the value of the [**Layer**](https://msdn.microsoft.com/library/windows/apps/dn637157) property of the [**MapTileSource**](https://msdn.microsoft.com/library/windows/apps/dn637144).</span></span>
-   <span data-ttu-id="26790-207">[**MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004) の [**Style**](https://msdn.microsoft.com/library/windows/apps/dn637051) プロパティ値として [**MapStyle**](https://msdn.microsoft.com/library/windows/apps/dn637127).**None** を指定します。</span><span class="sxs-lookup"><span data-stu-id="26790-207">Specify [**MapStyle**](https://msdn.microsoft.com/library/windows/apps/dn637127).**None** as the value of the [**Style**](https://msdn.microsoft.com/library/windows/apps/dn637051) property of the [**MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004).</span></span>

## <a name="related-topics"></a><span data-ttu-id="26790-208">関連トピック</span><span class="sxs-lookup"><span data-stu-id="26790-208">Related topics</span></span>

* [<span data-ttu-id="26790-209">Bing Maps Developer Center</span><span class="sxs-lookup"><span data-stu-id="26790-209">Bing Maps Developer Center</span></span>](https://www.bingmapsportal.com/)
* [<span data-ttu-id="26790-210">UWP の地図サンプル</span><span class="sxs-lookup"><span data-stu-id="26790-210">UWP map sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkId=619977)
* [<span data-ttu-id="26790-211">地図の設計ガイドライン</span><span class="sxs-lookup"><span data-stu-id="26790-211">Design guidelines for maps</span></span>](https://msdn.microsoft.com/library/windows/apps/dn596102)
* [<span data-ttu-id="26790-212">Build 2015 のビデオ: Windows アプリでの電話、タブレット、PC で使用できるマップと位置情報の活用</span><span class="sxs-lookup"><span data-stu-id="26790-212">Build 2015 video: Leveraging Maps and Location Across Phone, Tablet, and PC in Your Windows Apps</span></span>](https://channel9.msdn.com/Events/Build/2015/2-757)
* [<span data-ttu-id="26790-213">UWP の交通情報アプリのサンプル</span><span class="sxs-lookup"><span data-stu-id="26790-213">UWP traffic app sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkId=619982)
