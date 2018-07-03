---
author: normesta
description: マップ スタイル シートのエントリとプロパティ
MSHAttr: PreferredLib:/library/windows/apps
Search.Product: eADQiWindows 10XVcnh
title: マップ スタイル シート リファレンス
ms.author: normesta
ms.date: 03/16/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, マップ, マップ スタイル シート
ms.localizationpriority: medium
ms.openlocfilehash: 8fb80bc28900ee695ecf3b9e62b5dafc8f1a8cb3
ms.sourcegitcommit: f91aa1e402f1bc093b48a03fbae583318fc7e05d
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/24/2018
ms.locfileid: "1917775"
---
# <a name="map-style-sheet-reference"></a>マップ スタイル シート リファレンス

JavaScript Object Notation (JSON) を使用して、マップ スタイル シートを作成できます。

たとえば、次の JSON を使用して、水域を赤で、水域のラベルを緑で、陸地領域を青で表示できます。

```json
    {"version":"1.*",
        "settings":{"landColor":"#0000FF"},
        "elements":{"water":{"fillColor":"#FF0000", "labelColor":"#00FF00"}}
    }
```
JSON を使用して地図からすべてのラベルとポイントを削除することもできます。

```json

    {"version":"1.*", "elements":{"mapElement":{"labelVisible":false},"point":{"visible":false}}}
```

最終的な結果を生成するために、プロパティの値が変換される場合があります。  たとえば、表示されるエンティティの種類によって vegetation fillColor の影がやや異なります。  ignoreTransform プロパティを使用することで、この動作はオフにすることができます。それにより、指定の正確な値が使用されます。

```json
    {"version":"1.*",
        "settings":{"shadedReliefVisible":false},
        "elements":{"vegetation":{"fillColor":{"value":"#999999","ignoreTransform":true}}}
    }
```

このトピックでは、地図の外観をカスタマイズするために使用できる JSON のエントリと[プロパティ](#properties)を示します。

<a id="entries" />

## <a name="entries"></a>エントリ
この表では、文字 ">" を使用してエントリ階層内のレベルを表しています。   

| 名前                         | プロパティ グループ            | 説明    |
|------------------------------|---------------------------|----------------|
| version                      | [Version](#version)       | 使用するスタイル シートのバージョン。 |
| settings                     | [Settings](#settings)     | スタイル シート全体に適用される設定。 |
| mapElement                   | [MapElement](#mapelement) | 地図のすべてのエントリの親エントリ。 |
| > baseMapElement             | [MapElement](#mapelement) | すべての非ユーザー エントリの親エントリ。 |
| >> area                      | [MapElement](#mapelement) | 土地利用の領域 (structure エントリと混同しないでください)。 |
| >>> airport                  | [MapElement](#mapelement) | 空港を囲む領域。 |
| >>> areaOfInterest           | [MapElement](#mapelement) | 企業や興味深いポイントが高度に集中しているエリアです。 |
| >>> cemetery                 | [MapElement](#mapelement) | 墓地の領域。 |
| >>> continent                | [MapElement](#mapelement) | 大陸全体の領域。 |
| >>> education                | [MapElement](#mapelement) |  |
| >>> indigenousPeoplesReserve | [MapElement](#mapelement) |  |
| >>> industrial               | [MapElement](#mapelement) | 工業目的に使用される土地の領域。 |
| >>> island                   | [MapElement](#mapelement) | 島領域内のラベル。 |
| >>> medical                  | [MapElement](#mapelement) | 医療用に使用される土地の領域 (例: 病院の構内)。 |
| >>> military                 | [MapElement](#mapelement) | 軍事基地の領域。 |
| >>> nautical                 | [MapElement](#mapelement) | 海事目的に使用される土地の領域。 |
| >>> neighborhood             | [MapElement](#mapelement) | 近隣地域として定義されている領域内のラベル。 |
| >>> runway                   | [MapElement](#mapelement) | 滑走路で覆われている陸地領域。 |
| >>> sand                     | [MapElement](#mapelement) | 海辺のような砂地の領域。 |
| >>> shoppingCenter           | [MapElement](#mapelement) | モールやその他のショッピング センター用に割り当てられた土地の領域。 |
| >>> stadium                  | [MapElement](#mapelement) | スタジアムの領域。 |
| >>> underground              | [MapElement](#mapelement) | 地下のエリア (例: 地下鉄の駅の専有面積)。 |
| >>> vegetation               | [MapElement](#mapelement) | 森林、草原領域など。 |
| >>>> forest                  | [MapElement](#mapelement) | 森林の領域。 |
| >>>> golfCourse              | [MapElement](#mapelement) |  |
| >>>> park                    | [MapElement](#mapelement) | 公園の領域。 |
| >>>> playingField            | [MapElement](#mapelement) | 野球場やテニス コートなどの競技場。 |
| >>>> reserve                 | [MapElement](#mapelement) | 自然保護の領域。 |
| >> point                     | [PointStyle](#pointstyle) | 何かのアイコンで表示されるすべてのポイント機能。 |
| >>> address                  | [PointStyle](#pointstyle) | 住所の番号。 |
| >>> naturalPoint             | [PointStyle](#pointstyle) |  |
| >>>> peak                    | [PointStyle](#pointstyle) | 山頂を表すアイコン。 |
| >>>>> volcanicPeak           | [PointStyle](#pointstyle) | 火山の山頂を表すアイコン。 |
| >>>> waterPoint              | [PointStyle](#pointstyle) | 滝などの水に関連する場所を表すアイコン。 |
| >>> pointOfInterest          | [PointStyle](#pointstyle) | レストラン、病院、学校、マリーナ、スキー場など。 |
| >>>> business                | [PointStyle](#pointstyle) | レストラン、病院、学校など。 |
| >>>>> foodPoint              | [PointStyle](#pointstyle) | レストラン、カフェなど。 |
| >>> populatedPlace           | [PointStyle](#pointstyle) | 住民のいる場所のサイズを表すアイコン (例: 市区町村)。 |
| >>>> capital                 | [PointStyle](#pointstyle) | 住民のいる場所の首都を表すアイコン。 |
| >>>>> adminDistrictCapital   | [PointStyle](#pointstyle) | 州の州都や都道府県の県庁所在地を表すアイコン。 |
| >>>>> countryRegionCapital   | [PointStyle](#pointstyle) | 国や地域の首都を表すアイコン。 |
| >>> roadShield               | [PointStyle](#pointstyle) | 道路の簡略化された名前を表す記号  (例: I-5)。 settings エントリの **ImageFamily** プロパティを *Palette* の値に設定している場合は、パレット値のみを使用します。 |
| >>> roadExit                 | [PointStyle](#pointstyle) | 通常、通行が管理された高速道路の出口を表すアイコン。 |
| >>> transit                  | [PointStyle](#pointstyle) | バスの停留所、鉄道の駅、空港などを表すアイコン。 |
| >> political                 | [BorderedMapElement](#borderedmapelement) | 国、地域、州などの政治的な区域。 |
| >>> countryRegion            | [BorderedMapElement](#borderedmapelement) |  |
| >>> adminDistrict            | [BorderedMapElement](#borderedmapelement) | Admin1、州、都道府県など。 |
| >>> district                 | [BorderedMapElement](#borderedmapelement) | Admin2、郡など。 |
| >> structure                 | [MapElement](#mapelement) | 建物やその他の建物のような構造体。 |
| >>> building                 | [MapElement](#mapelement) |  |
| >>>> educationBuilding       | [MapElement](#mapelement) |  |
| >>>> medicalBuilding         | [MapElement](#mapelement) |  |
| >>>> transitBuilding         | [MapElement](#mapelement) |  |
| >> transportation            | [MapElement](#mapelement) | 交通輸送網の一部である線 (例: 道路、鉄道、フェリー航路)。 |
| >>> road                     | [MapElement](#mapelement) | すべての道路を表す線。 |
| >>>> controlledAccessHighway | [MapElement](#mapelement) |  |
| >>>>> highSpeedRamp          | [MapElement](#mapelement) | ランプを表す線。 これらのランプは、通常、通行が管理された高速道路に沿って表示されます。 |
| >>>> highway                 | [MapElement](#mapelement) |  |
| >>>> majorRoad               | [MapElement](#mapelement) |  |
| >>>> arterialRoad            | [MapElement](#mapelement) |  |
| >>>> street                  | [MapElement](#mapelement) |  |
| >>>>> ramp                   | [MapElement](#mapelement) | 高速道路の入口と出口を表す線。 |
| >>>>> unpavedStreet          | [MapElement](#mapelement) |  |
| >>>> tollRoad                | [MapElement](#mapelement) | 有料道路。 |
| >>> railway                  | [MapElement](#mapelement) | 鉄道の路線。 |
| >>> trail                    | [MapElement](#mapelement) | 公園内の遊歩道やハイキング コース。 |
| >>> waterRoute               | [MapElement](#mapelement) | フェリー航路の線。 |
| >> water                     | [MapElement](#mapelement) | 水のように見えるものすべて。 これには海や河川が含まれます。 |
| >>> river                    | [MapElement](#mapelement) | 河川、小川、その他の水路。  これは線の場合も、多角形の場合もあり、線があり、河川以外の水域に接続している場合があることに注意してください。 |
| > routeMapElement            | [MapElement](#mapelement) | すべての経路エントリは、このエントリの下位にあります。 |
| >> routeLine                 | [MapElement](#mapelement) | すべての経路の線のスタイル。 |
| >>> drivingRoute             | [MapElement](#mapelement) |  |
| >>> scenicRoute              | [MapElement](#mapelement) |  |
| >>> walkingRoute             | [MapElement](#mapelement) |  |
| > userMapElement             | [MapElement](#mapelement) | すべてのユーザー エントリは、このエントリの下位にあります。 |
| >> userBillboard             | [MapElement](#mapelement) | 既定の [MapBillboard](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapbillboard) インスタンスのスタイル。 |
| >> userLine                  | [MapElement](#mapelement) | 既定の [MapPolyline](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mappolyline) インスタンスのスタイル。 |
| >> userModel3D               | [MapElement3D](#mapelement3d) | 既定の [MapModel3D](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapmodel3d) インスタンスのスタイル。  これは、主に renderAsSurface を設定するためのものです。 |
| >> userPoint                 | [PointStyle](#pointstyle) | 既定の [MapIcon](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapicon) インスタンスのスタイル。 |


<a id="properties" />

## <a name="properties"></a>プロパティ

このセクションでは、エントリごとに使用できるプロパティについて説明します。

<a id="version" />

### <a name="version-properties"></a>Version のプロパティ

| プロパティ                     | 種類    | 説明                                                                                                           |
|------------------------------|---------|-----------------------------------------------------------------------------------------------------------------------|
| version                      | String  | 対象のスタイル シートのバージョン。 適用性のために使用します。 既定では "1.0"、追加のマイナー機能更新では "1.*" になります。 |

<a id="settings" />

### <a name="settings-properties"></a>Settings のプロパティ

| プロパティ                     | 種類    | 説明                                                                                                                                                                                                                 |
|------------------------------|---------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| atmosphereVisible            | Bool    | 大気が 3D コントロールに表示されるかどうかを示すフラグ。                                                                                                                                                     |
| buildingTexturesVisible      | Bool    | テクスチャのあるシンボル 3D 施設にテクスチャを表示するかどうかを示すフラグ。                                                                                                                          |
| fogColor                     | Color   | 3D コントロールに表示されるディスタンス フォグの ARGB カラー値。                                                                                                                                                    |
| glowColor                    | Color   | ラベルのグローやアイコンのグローに適用される可能性がある ARGB カラー値。                                                                                                                                                     |
| imageFamily                  | String  | このスタイルに使用するよう設定されたイメージの名前。 実際の記号に基づいて固定色を使用する記号の場合は、この値を *Default* に設定します。 パレットで構成可能な色を使用する記号の場合は、この値を *Palette* に設定します。 |
| landColor                    | Color   | 陸地に何かを描画する前の陸地の ARGB カラー値。                                                                                                                                                     |
| logosVisible                 | Bool    | **Organization** プロパティを持つ項目に適切なロゴを描画するか、汎用のアイコンを使用するかを示すフラグ。                                                                                         |
| officialColorVisible         | Bool    | 公式の色のプロパティを持っている項目 (中国での乗り換え線など) をその色を描画する必要があるかどうかを示すフラグ。 たとえば、白黒の地図ではこの値をオフにします。                               |
| rasterRegionsVisible         | Bool    | ベクターによってレンダリングしないラスター領域を描画するかどうかを示すフラグ (例: 日本、韓国)。                                                                                                |
| shadedReliefVisible          | Bool    | 地図上の高度シェーディングを描画するかどうかを示すフラグ。                                                                                                                                                  |
| shadedReliefDarkColor        | Color   | 影付き起伏の暗い側の色。  アルファ チャネルは最大アルファ 値を表します。                                                                                                                            |
| shadedReliefLightColor       | Color   | 影付き起伏の明るい側の色。  アルファ チャネルは最大アルファ 値を表します。                                                                                                                           |
| spaceColor                   | Color   | 地図の周囲の領域の ARGB カラー値。                                                                                                                                                                               |
| useDefaultImageColors        | Bool    | イメージ内の色のパレット エントリを検索するのではなく、SVG の元の色を使用する必要があるかどうかを示すフラグ。                                                                                |

<a id="mapelement" />

### <a name="mapelement-properties"></a>MapElement のプロパティ

| プロパティ                     | 種類    | 説明                                                                                                                       |
|------------------------------|---------|-----------------------------------------------------------------------------------------------------------------------------------|
| backgroundScale              | Float   | アイコンの背景要素を拡大縮小する量。  たとえば、既定の場合は *1* を、2 倍の大きさの場合は *2* を使用します。 |
| fillColor                    | Color   | 多角形の塗りつぶし、ポイント アイコンの背景、分割した場合の線の中心に使用される色。       |
| fontFamily                   | String  |                                                                                                                                   |
| iconColor                    | Color   | ポイント アイコンの中央に表示されるグリフの色。                                                                       |
| iconScale                    | Float   | アイコンのグリフを拡大縮小する量。  たとえば、既定の場合は *1* を、2 倍の大きさの場合は *2* を使用します。              |
| labelColor                   | Color   |                                                                                                                                   |
| labelOutlineColor            | Color   |                                                                                                                                   |
| labelScale                   | Float   | 既定のラベル サイズが拡大縮小される量。 たとえば、既定の場合は *1* を、2 倍の大きさの場合は *2* を使用します。                  |
| labelVisible                 | Bool    |                                                                                                                                   |
| overwriteColor               | Bool    | **FillColor** のアルファ値で **StrokeColor** をブレンドするのではなく、上書きします。                               |
| scale                        | Float   | ポイント全体のサイズを拡大縮小する量。 たとえば、既定の場合は *1* を、2 倍の大きさの場合は *2* を使用します。                |
| strokeColor                  | Color   | 多角形の輪郭、ポイント アイコンの輪郭、線の色に使用する色。                         |
| strokeWidthScale             | Float   | 線の太さが拡大縮小される量。 たとえば、既定の場合は *1* を、2 倍の大きさの場合は *2* を使用します。                  |
| visible                      | Bool    |                                                                                                                                   |

<a id="borderedmap" />

### <a name="borderedmapelement"></a>BorderedMapElement

このプロパティ グループは、[MapElement](#mapelement) プロパティ グループを継承します。

| プロパティ                     | 種類    | 説明                                                           |
|------------------------------|---------|-----------------------------------------------------------------------|
| borderOutlineColor           | Color   | 塗りつぶされた多角形の境界線のセカンダリまたはケーシング線の色。 |
| borderStrokeColor            | Color   | 塗りつぶされた多角形の境界線のプライマリ線の色。             |
| borderVisible                | Bool    |                                                                       |
| borderWidthScale             | Float   |                                                                       |

<a id="pointstyle" />

### <a name="pointstyle-properties"></a>PointStyle のプロパティ

このプロパティ グループは、[MapElement](#mapelement) プロパティ グループを継承します。

| プロパティ                     | 種類    | 説明                                                                                                                      |
|------------------------------|---------|----------------------------------------------------------------------------------------------------------------------------------|
| stemAnchorRadiusScale        | Float   | アイコン ステムのアンカー ポイントを拡大縮小する量。  たとえば、既定の場合は *1* を、2 倍の大きさの場合は *2* を使用します。 |
| stemColor                    | Color   | 3D モードでアイコンの下部から出ている幹の色。                                                           |
| stemHeightScale              | Float   | アイコンのステムの長さを拡大縮小する量。  たとえば、既定の場合は *1* を、2 倍の長さの場合は *2* を使用します。 |
| stemWidthScale               | Float   | アイコンのステムの幅を拡大縮小する量。  たとえば、既定の場合は *1* を、2 倍の長さの場合は *2* を使用します。  |
| stemOutlineColor             | Color   | 3D モードでアイコンの下部から出ている幹の周囲の輪郭の色。                                        |

<a id="mapelement3d" />

### <a name="mapelement3d"></a>MapElement3D

このプロパティ グループは、[MapElement](#mapelement) プロパティ グループを継承します。

| プロパティ                     | 種類    | 説明                                                                                                                      |
|------------------------------|---------|----------------------------------------------------------------------------------------------------------------------------------|
| renderAsSurface              | Bool    | 3D モデルを地面に対して深度フェーディングなしで建物のようにレンダリングする必要があることを示すフラグ。               |
