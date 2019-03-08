---
description: マップ スタイル シートのエントリとプロパティ
MSHAttr: PreferredLib:/library/windows/apps
Search.Product: eADQiWindows 10XVcnh
title: マップ スタイル シート リファレンス
ms.date: 03/19/2017
ms.topic: article
keywords: Windows 10, UWP, マップ, マップ スタイル シート
ms.localizationpriority: medium
ms.openlocfilehash: f199e08f74ace4e6c8b123a701af19469b029aed
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57608417"
---
# <a name="map-style-sheet-reference"></a>マップ スタイル シート リファレンス

Microsoft マッピング テクノロジを使用して、_マップ スタイル シート_マップの外観を定義します。  マップのスタイル シート、JavaScript Object Notation (JSON) を使用して定義し、Windows ストア アプリケーションのさまざまな方法などで使用できる[MapControl](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapcontrol)を通じて、 [MapStyleSheet.ParseFromJson](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapstylesheet.parsefromjson#Windows_UI_Xaml_Controls_Maps_MapStyleSheet_ParseFromJson_System_String_)メソッド。

使用して対話形式でスタイル シートを作成することができます、[マップ スタイル シート エディター](https://www.microsoft.com/p/map-style-sheet-editor/9nbhtcjt72ft)アプリケーション。

次の JSON を赤で表示される領域が水を使用できます、緑、水のラベルの表示および陸地が青色で表示されます。

```json
    {"version":"1.*",
        "settings":{"landColor":"#0000FF"},
        "elements":{"water":{"fillColor":"#FF0000","labelColor":"#00FF00"}}
    }
```

この JSON は、マップからすべてのラベルとポイントを削除する使用できます。

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

このトピックでは、地図の外観をカスタマイズするために使用できる JSON のエントリと[プロパティ](#properties)を示します。  これらのプロパティは、を介してユーザーのマップ要素にも適用できる、 [MapStyleSheetEntry](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapelement.mapstylesheetentry)プロパティ。

<a id="entries" />

## <a name="entries"></a>エントリ
この表では、文字 ">" を使用してエントリ階層内のレベルを表しています。  Windows のバージョンは、各エントリをサポートし、それを無視することも示しています。

| バージョン | Windows のリリース名 |
|---------|----------------------|
|  1703   | Creators Update      |
|  1709   | Fall Creators Update |
|  1803   | April 2018 Update    |
|  1809   | 2018年 10 月 Update  |

| 名前                         | プロパティ グループ            | 1703 | 1709 | 1803 | 1809 | 説明    |
|------------------------------|---------------------------|------|------|------|------|----------------|
| version                      | [バージョン](#version)       |  ✔   |  ✔   |  ✔   |  ✔   | 使用するスタイル シートのバージョン。 |
| settings                     | [設定](#settings)     |  ✔   |  ✔   |  ✔   |  ✔   | スタイル シート全体に適用される設定。 |
| mapElement                   | [MapElement](#mapelement) |  ✔   |  ✔   |  ✔   |  ✔   | 地図のすべてのエントリの親エントリ。 |
| > baseMapElement             | [MapElement](#mapelement) |  ✔   |  ✔   |  ✔   |  ✔   | すべての非ユーザー エントリの親エントリ。 |
| >> area                      | [MapElement](#mapelement) |  ✔   |  ✔   |  ✔   |  ✔   | Land を記述する領域を使用します。  これらは、構造体のエントリの下にある物理建物と混同しないようにする必要があります。 |
| >>> airport                  | [MapElement](#mapelement) |  ✔   |  ✔   |  ✔   |  ✔   | 空港を網羅する領域。 |
| >>> areaOfInterest           | [MapElement](#mapelement) |      |  ✔   |  ✔   |  ✔   | 企業や興味深いポイントが高度に集中しているエリアです。 |
| >>> cemetery                 | [MapElement](#mapelement) |  ✔   |  ✔   |  ✔   |  ✔   | Cemeteries を網羅する領域。 |
| >>> continent                | [MapElement](#mapelement) |  ✔   |  ✔   |  ✔   |  ✔   | 大陸領域のラベル。 |
| >>> education                | [MapElement](#mapelement) |  ✔   |  ✔   |  ✔   |  ✔   | 学校やその他の教育施設を網羅する領域。 |
| >>> indigenousPeoplesReserve | [MapElement](#mapelement) |  ✔   |  ✔   |  ✔   |  ✔   | 先住民 peoples を網羅する領域を予約します。 |
| >>> industrial               | [MapElement](#mapelement) |      |  ✔   |  ✔   |  ✔   | 産業のために使用される領域。 |
| >>> island                   | [MapElement](#mapelement) |  ✔   |  ✔   |  ✔   |  ✔   | 島領域のラベル。 |
| >>> medical                  | [MapElement](#mapelement) |  ✔   |  ✔   |  ✔   |  ✔   | 医療のために使用される領域 (例: 病院キャンパス)。 |
| >>> military                 | [MapElement](#mapelement) |  ✔   |  ✔   |  ✔   |  ✔   | Encompass の軍事ベースまたは軍事機関の用途がありますの領域です。 |
| >>> nautical                 | [MapElement](#mapelement) |  ✔   |  ✔   |  ✔   |  ✔   | 航海の関連するために使用される領域。 |
| >>> neighborhood             | [MapElement](#mapelement) |  ✔   |  ✔   |  ✔   |  ✔   | 隣接領域のラベル。 |
| >>> runway                   | [MapElement](#mapelement) |  ✔   |  ✔   |  ✔   |  ✔   | 飛行機の滑走路として使用される領域です。 |
| >>> sand                     | [MapElement](#mapelement) |  ✔   |  ✔   |  ✔   |  ✔   | 海辺のような砂地の領域。 |
| >>> shoppingCenter           | [MapElement](#mapelement) |  ✔   |  ✔   |  ✔   |  ✔   | モールやその他のショッピング センター用に割り当てられた土地の領域。 |
| >>> stadium                  | [MapElement](#mapelement) |  ✔   |  ✔   |  ✔   |  ✔   | スタジアムを網羅する領域。 |
| >>> underground              | [MapElement](#mapelement) |      |  ✔   |  ✔   |  ✔   | 地下のエリア (例: 地下鉄の駅の専有面積)。 |
| >>> vegetation               | [MapElement](#mapelement) |  ✔   |  ✔   |  ✔   |  ✔   | 森林、草原領域など。 |
| >>>> forest                  | [MapElement](#mapelement) |  ✔   |  ✔   |  ✔   |  ✔   | 森林の領域。 |
| >>>> golfCourse              | [MapElement](#mapelement) |  ✔   |  ✔   |  ✔   |  ✔   | ゴルフ コースを網羅する領域。 |
| >>>> park                    | [MapElement](#mapelement) |  ✔   |  ✔   |  ✔   |  ✔   | 公園を網羅する領域。 |
| >>>> playingField            | [MapElement](#mapelement) |  ✔   |  ✔   |  ✔   |  ✔   | 野球場やテニス コートなどの競技場。 |
| >>>> reserve                 | [MapElement](#mapelement) |  ✔   |  ✔   |  ✔   |  ✔   | 性質を網羅する領域を予約します。 |
| >> point                     | [PointStyle](#pointstyle) |  ✔   |  ✔   |  ✔   |  ✔   | 何らかのアイコンで描画するすべてのポイント機能です。 |
| >>> address                  | [PointStyle](#pointstyle) |      |      |  ✔   |  ✔   | 数値のラベルに対処します。 |
| >>> naturalPoint             | [PointStyle](#pointstyle) |  ✔   |  ✔   |  ✔   |  ✔   | 自然な機能を表すアイコン。 |
| >>>> peak                    | [PointStyle](#pointstyle) |  ✔   |  ✔   |  ✔   |  ✔   | 山頂を表すアイコン。 |
| >>>>> volcanicPeak           | [PointStyle](#pointstyle) |  ✔   |  ✔   |  ✔   |  ✔   | 火山の山頂を表すアイコン。 |
| >>>> waterPoint              | [PointStyle](#pointstyle) |  ✔   |  ✔   |  ✔   |  ✔   | 滝などの水に関連する場所を表すアイコン。 |
| >>> pointOfInterest          | [PointStyle](#pointstyle) |  ✔   |  ✔   |  ✔   |  ✔   | 興味深いの任意の場所を表すアイコン。 |
| >>>> business                | [PointStyle](#pointstyle) |  ✔   |  ✔   |  ✔   |  ✔   | ビジネスの任意の場所を表すアイコン。 |
| >>>>> attractionPoint        | [PointStyle](#pointstyle) |      |  ✔   |  ✔   |  ✔   | 観光アトラクション (美術館、動物園など) を表すアイコン。 |
| >>>>> communityPoint         | [PointStyle](#pointstyle) |      |  ✔   |  ✔   |  ✔   | コミュニティへの一般的な使用の場所を表すアイコン。 |
| >>>>> educationPoint         | [PointStyle](#pointstyle) |      |  ✔   |  ✔   |  ✔   | 学校やその他の教育を表すアイコンに関連する場所。 |
| >>>>> entertainmentPoint     | [PointStyle](#pointstyle) |      |  ✔   |  ✔   |  ✔   | Entertainment 会場 (シアター、上映など) を表すアイコン。 |
| >>>>> essentialServicePoint  | [PointStyle](#pointstyle) |      |  ✔   |  ✔   |  ✔   | 駐車、銀行、ガスなどの重要なサービスを表すアイコン。 |
| >>>>> foodPoint              | [PointStyle](#pointstyle) |  ✔   |  ✔   |  ✔   |  ✔   | レストラン、喫茶店などを表すアイコン。 |
| >>>>> lodgingPoint           | [PointStyle](#pointstyle) |      |  ✔   |  ✔   |  ✔   | ホテルやその他の宿泊施設の企業を表すアイコン。 |
| >>>>> realEstatePoint        | [PointStyle](#pointstyle) |      |  ✔   |  ✔   |  ✔   | 不動産企業を表すアイコン。 |
| >>>>> shoppingPoint          | [PointStyle](#pointstyle) |      |  ✔   |  ✔   |  ✔   | ホテルやその他の宿泊施設の企業を表すアイコン。 |
| >>> populatedPlace           | [PointStyle](#pointstyle) |  ✔   |  ✔   |  ✔   |  ✔   | 住民のいる場所のサイズを表すアイコン (例: 市区町村)。 |
| >>>> capital                 | [PointStyle](#pointstyle) |  ✔   |  ✔   |  ✔   |  ✔   | 住民のいる場所の首都を表すアイコン。 |
| >>>>> adminDistrictCapital   | [PointStyle](#pointstyle) |  ✔   |  ✔   |  ✔   |  ✔   | 州の州都や都道府県の県庁所在地を表すアイコン。 |
| >>>>> countryRegionCapital   | [PointStyle](#pointstyle) |  ✔   |  ✔   |  ✔   |  ✔   | 国や地域の首都を表すアイコン。 |
| >>> roadShield               | [PointStyle](#pointstyle) |  ✔   |  ✔   |  ✔   |  ✔   | 道路の簡略化された名前を表す記号  (例。I-5)。 settings エントリの **ImageFamily** プロパティを *Palette* の値に設定している場合は、パレット値のみを使用します。 |
| >>> roadExit                 | [PointStyle](#pointstyle) |  ✔   |  ✔   |  ✔   |  ✔   | 通常、通行が管理された高速道路の出口を表すアイコン。 |
| >>> transit                  | [PointStyle](#pointstyle) |  ✔   |  ✔   |  ✔   |  ✔   | バスの停留所、鉄道の駅、空港などを表すアイコン。 |
| >> political                 | [BorderedMapElement](#borderedmapelement) |  ✔   |  ✔   |  ✔   |  ✔   | 国、地域、州などの政治的な区域。 |
| >>> countryRegion            | [BorderedMapElement](#borderedmapelement) |  ✔   |  ✔   |  ✔   |  ✔   | 国のリージョンの枠線とラベル。 |
| >>> adminDistrict            | [BorderedMapElement](#borderedmapelement) |  ✔   |  ✔   |  ✔   |  ✔   | Admin1、状態、都道府県など、枠線し、ラベルを付けます。 |
| >>> district                 | [BorderedMapElement](#borderedmapelement) |  ✔   |  ✔   |  ✔   |  ✔   | Admin2、郡など、枠線し、ラベルを付けます。 |
| >> structure                 | [MapElement](#mapelement) |  ✔   |  ✔   |  ✔   |  ✔   | 建物やその他の建物のような構造体。 |
| >>> building                 | [MapElement](#mapelement) |  ✔   |  ✔   |  ✔   |  ✔   | 建物します。 |
| >>>> educationBuilding       | [MapElement](#mapelement) |  ✔   |  ✔   |  ✔   |  ✔   | 建物の教育機関向けを使用します。 |
| >>>> medicalBuilding         | [MapElement](#mapelement) |  ✔   |  ✔   |  ✔   |  ✔   | 建物の病院などの医療の目的で使用します。 |
| >>>> transitBuilding         | [MapElement](#mapelement) |  ✔   |  ✔   |  ✔   |  ✔   | 建物の空港などの転送に使用します。 |
| >> transportation            | [MapElement](#mapelement) |  ✔   |  ✔   |  ✔   |  ✔   | 交通輸送網の一部である線 (例: 道路、鉄道、フェリー航路)。 |
| >>> road                     | [MapElement](#mapelement) |  ✔   |  ✔   |  ✔   |  ✔   | すべての道路を表す線。 |
| >>>> controlledAccessHighway | [MapElement](#mapelement) |  ✔   |  ✔   |  ✔   |  ✔   | 大規模で制御されたアクセスの高速道路を表す線。 |
| >>>>> highSpeedRamp          | [MapElement](#mapelement) |  ✔   |  ✔   |  ✔   |  ✔   | 通常、接続を高速傾斜を表す線は、高速道路を制御します。 |
| >>>> highway                 | [MapElement](#mapelement) |  ✔   |  ✔   |  ✔   |  ✔   | 高速道路を表す線。 |
| >>>> majorRoad               | [MapElement](#mapelement) |  ✔   |  ✔   |  ✔   |  ✔   | 幹線道路を表す線。 |
| >>>> arterialRoad            | [MapElement](#mapelement) |  ✔   |  ✔   |  ✔   |  ✔   | Arterial 道路を表す線。 |
| >>>> street                  | [MapElement](#mapelement) |  ✔   |  ✔   |  ✔   |  ✔   | 通りを表す行です。 |
| >>>>> ramp                   | [MapElement](#mapelement) |  ✔   |  ✔   |  ✔   |  ✔   | 通常幹線道路に接続する傾斜を表す線。 |
| >>>>> unpavedStreet          | [MapElement](#mapelement) |  ✔   |  ✔   |  ✔   |  ✔   | 装備されて通りを表す行です。 |
| >>>> tollRoad                | [MapElement](#mapelement) |  ✔   |  ✔   |  ✔   |  ✔   | 使用するための費用の道路を表す線。 |
| >>> railway                  | [MapElement](#mapelement) |  ✔   |  ✔   |  ✔   |  ✔   | 鉄道の路線。 |
| >>> trail                    | [MapElement](#mapelement) |  ✔   |  ✔   |  ✔   |  ✔   | 公園内の遊歩道やハイキング コース。 |
| >>> walkway                  | [MapElement](#mapelement) |      |  ✔   |  ✔   |  ✔   | 管理者特権で walkway します。 |
| >>> waterRoute               | [MapElement](#mapelement) |  ✔   |  ✔   |  ✔   |  ✔   | フェリー航路の線。 |
| >> water                     | [MapElement](#mapelement) |  ✔   |  ✔   |  ✔   |  ✔   | 水のように見えるものすべて。 これには海や河川が含まれます。 |
| >>> river                    | [MapElement](#mapelement) |  ✔   |  ✔   |  ✔   |  ✔   | 河川、小川、その他の水路。  これは線の場合も、多角形の場合もあり、線があり、河川以外の水域に接続している場合があることに注意してください。 |
| > routeMapElement            | [MapElement](#mapelement) |  ✔   |  ✔   |  ✔   |  ✔   | すべてのルーティング関連エントリ。 |
| >> routeLine                 | [MapElement](#mapelement) |  ✔   |  ✔   |  ✔   |  ✔   | 行のルーティングのエントリに関連します。 |
| >>> drivingRoute             | [MapElement](#mapelement) |  ✔   |  ✔   |  ✔   |  ✔   | 自動車ルートを表す線。 |
| >>> scenicRoute              | [MapElement](#mapelement) |      |  ✔   |  ✔   |  ✔   | Scenic 自動車ルートを表す線。 |
| >>> walkingRoute             | [MapElement](#mapelement) |  ✔   |  ✔   |  ✔   |  ✔   | 徒歩ルートを表す行です。 |
| > userMapElement             | [MapElement](#mapelement) |  ✔   |  ✔   |  ✔   |  ✔   | すべてのユーザーのエントリ。 |
| >> userBillboard             | [MapElement](#mapelement) |      |  ✔   |  ✔   |  ✔   | 既定の [MapBillboard](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapbillboard) インスタンスのスタイル。 |
| >> userLine                  | [MapElement](#mapelement) |  ✔   |  ✔   |  ✔   |  ✔   | 既定の [MapPolyline](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mappolyline) インスタンスのスタイル。 |
| >> userModel3D               | [MapElement3D](#mapelement3d) |      |  ✔   |  ✔   |  ✔   | 既定の [MapModel3D](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapmodel3d) インスタンスのスタイル。  これは、主に renderAsSurface を設定するためのものです。 |
| >> userPoint                 | [PointStyle](#pointstyle) |  ✔   |  ✔   |  ✔   |  ✔   | 既定の [MapIcon](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapicon) インスタンスのスタイル。 |

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

| プロパティ                     | 種類    | 1703 | 1709 | 1803 | 1809 | 説明 |
|------------------------------|---------|------|------|------|------|-------------|
| atmosphereVisible            | Bool    |  ✔   |  ✔   |  ✔   |  ✔   | 大気が 3D コントロールに表示されるかどうかを示すフラグ。 |
| buildingTexturesVisible      | Bool    |      |      |  ✔   |  ✔   | テクスチャのあるシンボル 3D 施設にテクスチャを表示するかどうかを示すフラグ。 |
| fogColor                     | 色   |  ✔   |  ✔   |  ✔   |  ✔   | 3D コントロールに表示されるディスタンス フォグの ARGB カラー値。 |
| glowColor                    | 色   |  ✔   |  ✔   |  ✔   |  ✔   | ラベルのグローやアイコンのグローに適用される可能性がある ARGB カラー値。 |
| imageFamily                  | String  |  ✔   |  ✔   |  ✔   |  ✔   | このスタイルに使用するよう設定されたイメージの名前。 実際の記号に基づいて固定色を使用する記号の場合は、この値を *Default* に設定します。 パレットで構成可能な色を使用する記号の場合は、この値を *Palette* に設定します。 |
| landColor                    | 色   |  ✔   |  ✔   |  ✔   |  ✔   | 陸地に何かを描画する前の陸地の ARGB カラー値。 |
| logosVisible                 | Bool    |  ✔   |  ✔   |  ✔   |  ✔   | **Organization** プロパティを持つ項目に適切なロゴを描画するか、汎用のアイコンを使用するかを示すフラグ。 |
| officialColorVisible         | Bool    |  ✔   |  ✔   |  ✔   |  ✔   | 公式の色のプロパティを持っている項目 (中国での乗り換え線など) をその色を描画する必要があるかどうかを示すフラグ。 たとえば、白黒の地図ではこの値をオフにします。 |
| rasterRegionsVisible         | Bool    |  ✔   |  ✔   |  ✔   |  ✔   | ラスター領域があるため、ベクトル (日本および韓国) よりもより適切な表現を描画するかどうかを示すフラグ。 |
| shadedReliefVisible          | Bool    |  ✔   |  ✔   |  ✔   |  ✔   | 地図上の高度シェーディングを描画するかどうかを示すフラグ。 |
| shadedReliefDarkColor        | 色   |  ✔   |  ✔   |  ✔   |  ✔   | 影付き起伏の暗い側の色。  アルファ チャネルでは、最大のアルファ値を表します。 |
| shadedReliefLightColor       | 色   |  ✔   |  ✔   |  ✔   |  ✔   | 影付き起伏の明るい側の色。  アルファ チャネルでは、最大のアルファ値を表します。 |
| shadowColor                  | 色   |      |      |      |  ✔   | 影を使用するアイコンの後ろに影の色。 |
| spaceColor                   | 色   |  ✔   |  ✔   |  ✔   |  ✔   | 地図の周囲の領域の ARGB カラー値。 |
| useDefaultImageColors        | Bool    |  ✔   |  ✔   |  ✔   |  ✔   | SVG の元の色が画像内の色のパレット エントリを検索するのではなく、使用するかどうかを示すフラグ。 |

<a id="mapelement" />

### <a name="mapelement-properties"></a>MapElement のプロパティ

| プロパティ                     | 種類    | 1703 | 1709 | 1803 | 1809 | 説明 |
|------------------------------|---------|------|------|------|------|-------------|
| backgroundScale              | Float   |  ✔   |  ✔   |  ✔   |  ✔   | アイコンの背景要素を拡大縮小する量。  たとえば、既定の場合は *1* を、2 倍の大きさの場合は *2* を使用します。 |
| fillColor                    | 色   |  ✔   |  ✔   |  ✔   |  ✔   | 多角形の塗りつぶし、ポイント アイコンの背景、分割した場合の線の中心に使用される色。 |
| fontFamily                   | String  |  ✔   |  ✔   |  ✔   |  ✔   |  |
| iconColor                    | 色   |  ✔   |  ✔   |  ✔   |  ✔   | ポイント アイコンの中央に表示されるグリフの色。 |
| iconScale                    | Float   |      |  ✔   |  ✔   |  ✔   | アイコンのグリフを拡大縮小する量。  たとえば、既定の場合は *1* を、2 倍の大きさの場合は *2* を使用します。 |
| labelColor                   | 色   |  ✔   |  ✔   |  ✔   |  ✔   |  |
| labelOutlineColor            | 色   |  ✔   |  ✔   |  ✔   |  ✔   |  |
| labelScale                   | Float   |  ✔   |  ✔   |  ✔   |  ✔   | 既定のラベル サイズが拡大縮小される量。 たとえば、既定の場合は *1* を、2 倍の大きさの場合は *2* を使用します。 |
| labelVisible                 | Bool    |  ✔   |  ✔   |  ✔   |  ✔   |  |
| overwriteColor               | Bool    |  ✔   |  ✔   |  ✔   |  ✔   | **FillColor** のアルファ値で **StrokeColor** をブレンドするのではなく、上書きします。 |
| scale                        | Float   |  ✔   |  ✔   |  ✔   |  ✔   | ポイント全体のサイズを拡大縮小する量。 たとえば、既定の場合は *1* を、2 倍の大きさの場合は *2* を使用します。 |
| strokeColor                  | 色   |  ✔   |  ✔   |  ✔   |  ✔   | 多角形の輪郭、ポイント アイコンの輪郭、線の色に使用する色。 |
| strokeWidthScale             | Float   |  ✔   |  ✔   |  ✔   |  ✔   | 線の太さが拡大縮小される量。 たとえば、既定の場合は *1* を、2 倍の大きさの場合は *2* を使用します。 |
| visible                      | Bool    |  ✔   |  ✔   |  ✔   |  ✔   |  |

<a id="borderedmap" />

### <a name="borderedmapelement"></a>BorderedMapElement

このプロパティ グループは、[MapElement](#mapelement) プロパティ グループを継承します。

| プロパティ                     | 種類    | 1703 | 1709 | 1803 | 1809 | 説明 |
|------------------------------|---------|------|------|------|------|-------------|
| borderOutlineColor           | 色   |  ✔   |  ✔   |  ✔   |  ✔   | 塗りつぶされた多角形の境界線のセカンダリまたはケーシング線の色。 |
| borderStrokeColor            | 色   |  ✔   |  ✔   |  ✔   |  ✔   | 塗りつぶされた多角形の境界線のプライマリ線の色。 |
| borderVisible                | Bool    |  ✔   |  ✔   |  ✔   |  ✔   |  |
| borderWidthScale             | Float   |  ✔   |  ✔   |  ✔   |  ✔   | 枠線のストロークをスケーリングする量。 たとえば、既定の場合は *1* を、2 倍の大きさの場合は *2* を使用します。 |

<a id="pointstyle" />

### <a name="pointstyle-properties"></a>PointStyle のプロパティ

このプロパティ グループは、[MapElement](#mapelement) プロパティ グループを継承します。

| プロパティ                     | 種類    | 1703 | 1709 | 1803 | 1809 | 説明 |
|------------------------------|---------|------|------|------|------|-------------|
| バック グラウンドの図形             | Float   |      |      |      |  ✔   | 存在する任意の図形を置き換える--アイコンの背景として使用する図形です。 |
| stemAnchorRadiusScale        | Float   |      |      |  ✔   |  ✔   | アイコン ステムのアンカー ポイントを拡大縮小する量。  たとえば、既定の場合は *1* を、2 倍の大きさの場合は *2* を使用します。 |
| stemColor                    | 色   |  ✔   |  ✔   |  ✔   |  ✔   | 3D モードでアイコンの下部から出ている幹の色。 |
| stemHeightScale              | Float   |      |      |  ✔   |  ✔   | アイコンのステムの長さを拡大縮小する量。  たとえば、既定の場合は *1* を、2 倍の長さの場合は *2* を使用します。 |
| stemOutlineColor             | 色   |  ✔   |  ✔   |  ✔   |  ✔   | 3D モードでアイコンの下部から出ている幹の周囲の輪郭の色。 |
| stemWidthScale               | Float   |  ✔   |  ✔   |  ✔   |  ✔   | アイコンのステムの幅を拡大縮小する量。  たとえば、既定の場合は *1* を、2 倍の長さの場合は *2* を使用します。 |

<a id="mapelement3d" />

### <a name="mapelement3d"></a>MapElement3D

このプロパティ グループは、[MapElement](#mapelement) プロパティ グループを継承します。

| プロパティ                     | 種類    | 1703 | 1709 | 1803 | 1809 | 説明 |
|------------------------------|---------|------|------|------|------|------------|
| renderAsSurface              | Bool    |      |      |  ✔   |  ✔   | 3D モデルを地面に対して深度フェーディングなしで建物のようにレンダリングする必要があることを示すフラグ。 |
