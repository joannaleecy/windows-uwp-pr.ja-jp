---
author: TylerMSFT
title: Windows マップ アプリの起動
description: アプリから Windows マップ アプリを起動する方法について説明します。
ms.assetid: E363490A-C886-4D92-9A64-52E3C24F1D98
ms.author: twhitney
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 6fd7377294e0d460720f6a16e71981ab0924ac9a
ms.sourcegitcommit: 6cc275f2151f78db40c11ace381ee2d35f0155f9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/25/2018
ms.locfileid: "5549282"
---
# <a name="launch-the-windows-maps-app"></a>Windows マップ アプリの起動




アプリから Windows マップ アプリを起動する方法について説明します。 このトピックでは、**bingmaps:、*ms-drive-to:、ms-walk-to:**、**ms-settings:** の各 URI (Uniform Resource Identifier) スキームについて説明します。 これらの URI スキームを使って、Windows マップ アプリを起動し、特定の地図、ルート案内、検索結果を表示したり、設定アプリから Windows マップ オフライン マップをダウンロードしたりします。

**ヒント** アプリから Windows マップ アプリを起動する方法について詳しくは、GitHub の [Windows-universal-samples リポジトリ](http://go.microsoft.com/fwlink/p/?LinkId=619979)から[ユニバーサル Windows プラットフォーム (UWP) の地図サンプル](http://go.microsoft.com/fwlink/p/?LinkId=619977)をダウンロードしてください。

## <a name="introducing-uris"></a>URI の概要

URI スキームを使うと、ハイパーリンクのクリックによって (またはアプリでプログラム的に) アプリを開くことができます。 **mailto:** を使って新しいメールの作成を開始したり、**http:** を使って既定の Web ブラウザーを開いたりできるのと同様に、**bingmaps:**、**ms-drive-to:**、**ms-walk-to:** を使って Windows マップ アプリを開くことができます。

-   **bingmaps:** URI は、位置情報、検索結果、ルート案内、交通情報用の地図を提供します。
-   **ms-drive-to:** URI は、現在の場所からのターン バイ ターン方式の自動車ルート案内を提供します。
-   **ms-walk-to:** URI は、現在の場所からのターン バイ ターン方式の徒歩ルート案内を提供します。

たとえば、次の URI は、Windows マップ アプリを開き、ニューヨークを中心とした地図を表示します。

```xml
<bingmaps:?cp=40.726966~-74.006076>
```

![ニューヨークを中心とした地図。](images/mapnyc.png)

URI スキームについて次に説明します。

**bingmaps:?query**

この URI スキームでは、*query* は、次のようなパラメーター名と値の一連のペアを示します。

**&param1=value1&param2=value2 …**

使用可能なパラメーターの一覧については、[bingmaps:](#bingmaps-param-reference)、[ms-drive-to:](#ms-drive-to-param-reference)、[ms-walk-to:](#ms-walk-to-param-reference) のパラメーター リファレンスをご覧ください。 このトピックでも後で例を示します。

## <a name="launch-a-uri-from-your-app"></a>アプリからの URI の起動


アプリから Windows マップ アプリを起動するには、**bingmaps:**、**ms-drive-to:**、または **ms-walk-to:** URI を指定して [**LaunchUriAsync**](https://msdn.microsoft.com/library/windows/apps/hh701476) メソッドを呼び出します。 次の例では、前の例と同じ URI を起動します。 URI によるアプリの起動について詳しくは、「[URI に応じた既定のアプリの起動](launch-default-app.md)」をご覧ください。

```cs
// Center on New York City
var uriNewYork = new Uri(@"bingmaps:?cp=40.726966~-74.006076");

// Launch the Windows Maps app
var launcherOptions = new Windows.System.LauncherOptions();
launcherOptions.TargetApplicationPackageFamilyName = "Microsoft.WindowsMaps_8wekyb3d8bbwe";
var success = await Windows.System.Launcher.LaunchUriAsync(uriNewYork, launcherOptions);
```

この例では、Windows マップ アプリを確実に起動するために [**LauncherOptions**](https://msdn.microsoft.com/library/windows/apps/hh701435) クラスを使っています。

## <a name="display-known-locations"></a>既知の場所の表示

地図の表示する部分を制御するための多くのオプションがあります。 *cp* (中心点) パラメーターと *rad* (半径) パラメーターまたは *lvl* (ズーム レベル) パラメーターを使って、場所を表示し、ズーム インの程度を選択できます。 *cp* パラメーターを使う場合、*hdg* (向き) と *pit* (ピッチ) を指定して、表示する方向を制御できます。 もう 1 つの方法は、*bb* (境界ボックス) パラメーターを使って、表示する領域の東西南北の最大の座標を指定することです。

ビューの種類を制御するには、*sty* (スタイル) パラメーターと *ss* (Streetside) パラメーターを使います。 *sty* パラメーターは、道路図と航空写真表示を切り替えます。 *ss* パラメーターは、Streetside ビューに地図を配置します。 これらのパラメーターやその他のパラメーターについて詳しくは、[bingmaps: のパラメーター リファレンス](#bingmaps-param-reference)をご覧ください。


| サンプル URI                                                                 | 結果                                                                                                                                                                                        |
|----------------------------------------------------------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| bingmaps:?                                                                 | マップ アプリを開きます。                                                                                                                                                                            |
| bingmaps:?cp=40.726966~-74.006076                                          | ニューヨークを中心とした地図を表示します。                                                                                                                                                    |
| bingmaps:?cp=40.726966~-74.006076&lvl=10                                   | ズーム レベル 10 でニューヨークを中心とした地図を表示します。                                                                                                                            |
| bingmaps:?bb=39.719\_-74.52~41.71\_-73.5                                   | **bb** 引数で指定された領域に基づいてニューヨーク市の地図を表示します。                                                                                                           |
| bingmaps:?bb=39.719\_-74.52~41.71\_-73.5&cp=47~-122                        | 境界ボックスの引数で指定された領域に基づいてニューヨークの地図を表示します。 *bb* が指定されているため、**cp** 引数で指定されたシアトルの中心点は無視されます。 |
| bingmaps:?collection=point.36.116584\_-115.176753\_Caesars%20Palace&lvl=16 | シーザーズ パレス (ラスベガス) という名前のポイントを使って地図を表示します。ズーム レベルは 16 に設定されます。                                                                                                 |
| bingmaps:?collection=point.40.726966\_-74.006076\_Some%255FBusiness        | Some\_Business (ラスベガス) という名前のポイントを使って地図を表示します。                                                                                                                               |
| bingmaps:?cp=40.726966~-74.006076&trfc=1&sty=a                             | 航空写真の地図形式を使い、交通情報を有効にして、ニューヨーク市の地図を表示します。                                                                                                                          |
| bingmaps:?cp=47.6204~-122.3491&sty=3d                                      | スペース ニードルの 3D ビューを表示します。                                                                                                                                                        |
| bingmaps:?cp=47.6204~-122.3491&sty=3d&rad=200&pit=75&hdg=165               | 半径 200 m、ピッチ 75 度、方位 165 度で、スペース ニードルの 3D ビューを表示します。                                                                             |
| bingmaps:?cp=47.6204~-122.3491&ss=1                                        | スペース ニードルの Streetside ビューを表示します。                                                                                                                                                |


## <a name="display-search-results"></a>検索結果の表示

*q* パラメーターを使って場所を検索する場合には、検索語句をできるだけ具体的に示すこと、また *cp*、*bb*、または *where* の各パラメーターを使って、検索場所を指定することをお勧めします。 検索場所が指定されず、ユーザーの現在の場所が利用できない場合は、検索が意味のある結果を返さない場合があります。 検索結果は、最も適切な地図のビューに表示されます。 これらのパラメーターやその他のパラメーターについて詳しくは、[bingmaps: のパラメーター リファレンス](#bingmaps-param-reference)をご覧ください。


| サンプル URI                                                    | 結果                                                                            |
|---------------------------------------------------------------|------------------------------------------------------------------------------------|
| bingmaps:?q=1600%20Pennsylvania%20Ave,%20Washington,%20DC     | 地図を表示し、ワシントンD.C. のホワイト ハウスの住所を検索します。 |
| bingmaps:?q=coffee&where=Seattle                              | シアトルでコーヒーを検索します。                                                    |
| bingmaps:?cp=40.726966~-74.006076&where=New%20York            | 指定した中心点の近くのニューヨークを検索します。                             |
| bingmaps:?bb=39.719\_-74.52~41.71\_-73.5&q=pizza              | 指定した境界ボックス (ニューヨーク市) の中でピザを検索します。      |

 
## <a name="display-multiple-points"></a>複数のポイントの表示


地図上のポイントのカスタム セットを表示するには、*collection* パラメーターを使います。 ポイントが複数ある場合は、ポイントの一覧が表示されます。 コレクションには 25 個までポイントを含めることができます。これらのポイントは指定された順序で表示されます。 コレクションは、検索要求やルート案内の要求よりも優先されます。 このパラメーターやその他のパラメーターについて詳しくは、[bingmaps: のパラメーター リファレンス](#bingmaps-param-reference)をご覧ください。

| サンプル URI | 結果                                                                                                                   |
|--------------------------------------------------------------------------------------------------------------------------------------------------------------------|---------------------------------------------------------------------------------------------------------------------------|
| bingmaps:?collection=point.36.116584\_-115.176753\_Caesars%20Palace                                                                                                | ラスベガスのシーザーズ パレスを検索し、その結果を地図に表示します (最適な地図のビューで表示されます)。                         |
| bingmaps:?collection=point.36.116584\_-115.176753\_Caesars%20Palace&lvl=16                                                                                         | ラスベガスにあるシーザーズ パレスという名前のプッシュピンを表示し、ズーム レベルを 16 に設定します。                                               |
| bingmaps:?collection=point.36.116584\_-115.176753\_Caesars%20Palace~point.36.113126\_-115.175188\_The%20Bellagio&lvl=16&cp=36.114902~-115.176669                   | ラスベガスにあるシーザーズ パレスおよびベラジオという名前のプッシュピンを表示し、ズーム レベルを 16 に設定します。              |
| bingmaps:?collection=point.40.726966\_-74.006076\_Fake%255FBusiness%255Fwith%255FUnderscore                                                                        | Fake\_Business\_with\_Underscore という名前のプッシュピンと共にニューヨークを表示します。                                                  |
| bingmaps:?collection=name.Hotel%20List~point.36.116584\_-115.176753\_Caesars%20Palace~point.36.113126\_-115.175188\_The%20Bellagio&lvl=16&cp=36.114902~-115.176669 | Hotel List という名前の一覧、およびラスベガスにあるシーザーズ パレスとベラジオの 2 つのプッシュピンを表示し、ズーム レベルを 16 に設定します。 |

 

## <a name="display-directions-and-traffic"></a>ルート案内と交通情報の表示


*rtp* パラメーターを使って、2 つのポイント間のルート案内を表示できます。これらのポイントは、住所または緯度と経度の座標で指定できます。 交通情報を表示するには、*trfc* パラメーターを使います。 ルート案内の種類 (自動車、徒歩、乗り換え案内) を指定するには、*mode* パラメーターを使います。 *mode* が指定されていない場合、ルート案内は、ユーザーの交通手段の設定のモードを使って提供されます。 これらのパラメーターやその他のパラメーターについて詳しくは、[bingmaps: のパラメーター リファレンス](#bingmaps-param-reference)をご覧ください。

![ルート案内の例](images/windowsmapgcdirections.png)

| サンプル URI                                                                                                              | 結果                                                                                                                                                         |
|-------------------------------------------------------------------------------------------------------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------|
| bingmaps:?rtp=pos.44.9160\_-110.4158~pos.45.0475\_-109.4187                                                             | ポイント ツー ポイントのルート案内と共に地図を表示します。 *mode* が指定されていないため、ルート案内は、ユーザーの交通手段の設定のモードを使って提供されます。 |
| bingmaps:?cp=43.0332~-87.9167&trfc=1                                                                                    | ウィスコンシン州のミルウォーキーを中心とした地図と交通情報を表示します。                                                                                                        |
| bingmaps:?rtp=adr.One Microsoft Way, Redmond, WA 98052~pos.39.0731\_-108.7238                                           | 指定した住所から指定した場所までのルート案内と共に地図を表示します。                                                                            |
| bingmaps:?rtp=adr.1%20Microsoft%20Way,%20Redmond,%20WA,%2098052~pos.36.1223\_-111.9495\_Grand%20Canyon%20northern%20rim | 1 Microsoft Way, Redmond, WA、98052 からグランドキャニオンの北端までのルート案内を表示します。                                                                |
| bingmaps:?rtp=adr.Davenport, CA~adr.Yosemite Village                                                                    | 指定した場所から指定したランドマークまでの自動車ルート案内と共に地図を表示します。                                                                   |
| bingmaps:?rtp=adr.Mountain%20View,%20CA~adr.San%20Francisco%20International%20Airport,%20CA&mode=d                      | カリフォルニア州のマウンテンビューからカリフォルニア州のサンフランシスコ国際空港までの自動車ルート案内を表示します。                                                                  |
| bingmaps:?rtp=adr.Mountain%20View,%20CA~adr.San%20Francisco%20International%20Airport,%20CA&mode=w                      | カリフォルニア州のマウンテンビューからカリフォルニア州のサンフランシスコ国際空港までの徒歩ルート案内を表示します。                                                                  |
| bingmaps:?rtp=adr.Mountain%20View,%20CA~adr.San%20Francisco%20International%20Airport,%20CA&mode=t                      | カリフォルニア州のマウンテンビューからカリフォルニア州のサンフランシスコ国際空港までの乗り換え案内を表示します。                                                                  |

## <a name="display-turn-by-turn-directions"></a>ターン バイ ターン方式のルート案内の表示


**ms-drive-to:** と **ms-walk-to:** の各 URI スキームでは、直接ターン バイ ターン方式のルート案内を起動できます。 これらの URI スキームでは、ユーザーの現在の場所からのルート案内のみを提供できます。 ユーザーの現在の場所を含まないポイント間のルート案内を提供する必要がある場合は、前のセクションで説明した **bingmaps:** URI スキームを使います。 これらの URI スキームについて詳しくは、[ms-drive-to:](#ms-drive-to-param-reference) と [ms-walk-to:](#ms-walk-to-param-reference) のパラメーター リファレンスをご覧ください。

> **重要**  **ms-drive-to:** または **ms-walk-to:** の URI スキームが呼び出されると、マップ アプリは、デバイスで GPS 位置情報の修正が行われたことがあるかどうかを確認します。 行われたことがある場合は、ターン バイ ターン方式のルート案内に進みます。 行われたことがない場合は、「[ルート案内と交通情報の表示](#display-directions-and-traffic)」で説明したルートの概要を表示します。

![ターン バイ ターン方式のルート案内の例](images/windowsmapsappdirections.png)

| サンプル URI                                                                                                | 結果                                                                                       |
|-----------------------------------------------------------------------------------------------------------|-----------------------------------------------------------------------------------------------|
| ms-drive-to:?destination.latitude=47.680504&destination.longitude=-122.328262&destination.name=Green Lake | 現在の場所からグリーン湖までのターン バイ ターン方式の自動車ルート案内と共に地図を表示します。 |
| ms-walk-to:?destination.latitude=47.680504&destination.longitude=-122.328262&destination.name=Green Lake  | 現在の場所からグリーン湖までのターン バイ ターン方式の徒歩ルート案内と共に地図を表示します。 |


## <a name="download-offline-maps"></a>オフライン マップのダウンロード

**ms-settings:** URI スキームでは、設定アプリで特定のページを直接起動することができます。 **ms-settings:** URI スキームでは、マップ アプリが起動されませんが、設定アプリでオフライン マップ ページを直接起動し、マップ アプリが使用するオフライン マップをダウンロードするための確認ダイアログ ボックスを表示することができます。 URI スキームは、緯度と経度で指定されたポイントを受け取り、そのポイントが含まれる地域のオフライン マップが利用できるかどうかを自動的に判定します。  渡された緯度と経度が複数のダウンロード地域内にある場合、ユーザーは、確認ダイアログ ボックスでダウンロードする地域を選択できます。 そのポイントが含まれる地域のオフライン マップが利用できない場合、設定アプリのオフライン マップ ページがエラー ダイアログと共に表示されます。

| サンプル URI  | 結果 |
|-------------|---------|
| ms-settings:maps-downloadmaps?latlong=47.6,-122.3 | 設定アプリで、確認ダイアログ ボックスが表示されたオフライン マップ ページを開き、緯度と経度で指定されたポイントが含まれた地域のマップをダウンロードします。 |

<span id="bingmaps-param-reference"/>

## <a name="bingmaps-parameter-reference"></a>bingmaps: のパラメーター リファレンス

次に示す各パラメーターの構文は、拡張バッカスナウア記法 (ABNF) を使って表されています。

<table>
<colgroup>
<col width="25%" />
<col width="25%" />
<col width="25%" />
<col width="25%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">パラメーター</th>
<th align="left">定義</th>
<th align="left">ABNF での定義と例</th>
<th align="left">詳細</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><b>cp</b></p></td>
<td align="left"><p>中心点</p></td>
<td align="left"><p>cp = "cp=" cpval</p>
<p>cpval = degreeslat "~" degreeslon</p>
<p>degreeslat = ["-"] 1*3DIGIT ["." 1*7DIGIT]</p>
<p>degreeslon = ["-"] 1*2DIGIT ["." 1*7DIGIT]</p>
<p>例:</p>
<p>cp=40.726966~-74.006076</p></td>
<td align="left"><p>どちらの値も、10 進角で表し、チルダ (<b>~</b>) で区切る必要があります。</p>
<p>有効な経度の値の範囲は -180 ～ +180 です (両端の値を含む)。</p>
<p>有効な緯度の値の範囲は -90 ～ +90 です (両端の値を含む)。</p></td>
</tr>
<tr class="even">
<td align="left"><p><b>bb</b></p></td>
<td align="left"><p>境界ボックス</p></td>
<td align="left"><p>bb = "bb=" southlatitude "_" westlongitude "~" northlatitude "_" eastlongitude</p>
<p>southlatitude = degreeslat</p>
<p>northlatitude = degreeslat</p>
<p>westlongitude = degreeslon</p>
<p>eastlongitude = degreeslon</p>
<p>degreeslat = ["-"] 13DIGIT ["." 17DIGIT]</p>
<p>degreeslon = ["-"] 12DIGIT ["." 17DIGIT]</p>
<p>例:</p>
<p>bb=39.719_-74.52~41.71_-73.5</p></td>
<td align="left"><p>境界ボックスを指定する四角形の領域。10 進角で表し、左下隅と右上隅を区別するためにチルダ (<b>~</b>) を使います。 それぞれの緯度と経度は、アンダー スコア (<b>_</b>) で区切られます。</p>
<p>有効な経度の値の範囲は -180 ～ +180 です (両端の値を含む)。</p>
<p>有効な緯度の値の範囲は -90 ～ +90 です (両端の値を含む)。</p><p>境界ボックスが提供されている場合、cp パラメーターと lvl パラメーターは無視されます。</p></td>
</tr>
<tr class="odd">
<td align="left"><p><b>where</b></p></td>
<td align="left"><p>位置情報</p></td>
<td align="left"><p>where = "where=" whereval</p>
<p>whereval = 1 *( ALPHA / DIGIT / "-" / "." / "_" / pct-encoded / "!" / "$" / "'" / "(" / ")" / "*" / "+" / "," / ";" / ":" / "@" / "/" / "?")</p>
<p>以下に例を示します。</p>
<p>where=1600%20Pennsylvania%20Ave,%20Washington,%20DC</p></td>
<td align="left"><p>特定の所在地、ランドマーク、または場所を検索するための語句。</p></td>
</tr>
<tr class="even">
<td align="left"><p><b>q</b></p></td>
<td align="left"><p>クエリ語句</p></td>
<td align="left"><p>q = "q="</p>
<p>whereval</p>
<p>例:</p>
<p>q=mexican%20restaurants</p></td>
<td align="left"><p>各地のビジネスや業種を検索するための語句。</p></td>
</tr>
<tr class="odd">
<td align="left"><p><b>lvl</b></p></td>
<td align="left"><p>ズーム レベル</p></td>
<td align="left"><p>lvl = "lvl=" 1<i>2DIGIT ["." 1</i>2DIGIT]</p>
<p>例:</p>
<p>lvl=10.50</p></td>
<td align="left"><p>地図ビューのズーム レベルを定義します。 有効な値は 1 ～ 20 です。1 は、最も縮小された状態で表示します。</p></td>
</tr>
<tr class="even">
<td align="left"><p><b>sty</b></p></td>
<td align="left"><p>形式</p></td>
<td align="left"><p>sty = "sty=" ("a" / "r"/"3d")</p>
<p>例:</p>
<p>sty=a</p></td>
<td align="left"><p>地図の形式を定義します。 このパラメーターの有効な値は次のとおりです。</p>
<ul>
<li>**a**: 地図の航空写真を表示します。</li>
<li>**r**: 地図の道路図を表示します。</li>
<li>**3d**: 地図を 3D で表示します。 **cp** パラメーターと組み合わせて使います。必要に応じて、**rad** パラメーターと共に使うこともできます。</li>
</ul>
<p>Windows 10 では、航空写真表示と 3D ビューのスタイルは同じです。</p>
<div class="alert">
**注:** **sty**パラメーターを省略することも同じ結果として sty = r します。
</div>
<div>
 
</div></td>
</tr>
<tr class="odd">
<td align="left"><p><b>rad</b></p></td>
<td align="left"><p>半径</p></td>
<td align="left"><p>rad = "rad=" 1*8DIGIT</p>
<p>例:</p>
<p>rad=1000</p></td>
<td align="left"><p>目的の地図ビューを表す円形領域です。 半径の値はメートル単位で指定します。</p></td>
</tr>
<tr class="even">
<td align="left"><p><b>pit</b></p></td>
<td align="left"><p>ピッチ</p></td>
<td align="left"><p>pit = "pit=" pitch</p>
<p>例:</p>
<p>pit=60</p></td>
<td align="left"><p>地図を表示する角度を指定します。90 は水平方向を見ること (最大) を表し、0 は真下を見下ろすこと (最小) を表します。</p><p>有効なピッチの値の範囲は 0 ～ 90 です (両端の値を含む)。</td>
</tr>
<tr class="odd">
<td align="left"><p><b>hdg</b></p></td>
<td align="left"><p>方位</p></td>
<td align="left"><p>hdg = "hdg=" heading</p>
<p>例:</p>
<p>hdg=180</p></td>
<td align="left"><p>地図の向いている方位を角度で指定します。0 または 360 は北、90 は東、180 は南、270 は西を表します。</p></td>
</tr>
<tr class="even">
<td align="left"><p><b>ss</b></p></td>
<td align="left"><p>Streetside</p></td>
<td align="left"><p>ss = "ss=" BIT</p>
<p>例: </p>
<p>ss=1</p></td>
<td align="left"><p><code>ss=1</code> の場合は、ストリート レベルの画像が表示されることを示します。 <b>ss</b> パラメーターを省略すると、<code>ss=0</code> と同じ結果が表示されます。 <b>cp</b> パラメーターと組み合わせて使うと、ストリート レベル ビューの場所を指定できます。</p>
<div class="alert">
**注:** ストリート レベルの画像は、すべての地域では利用可能なではありません。
</div>
<div>
 
</div></td>
</tr>
<tr class="odd">
<td align="left"><p><b>trfc</b></p></td>
<td align="left"><p>交通情報</p></td>
<td align="left"><p>trfc = "trfc=" BIT</p>
<p>例:</p>
<p>trfc=1</p></td>
<td align="left"><p>交通情報を地図に含めるかどうかを指定します。 trfc パラメーターを省略すると、<code>trfc=0</code> と同じ結果が表示されます。</p>
<div class="alert">
**注:** すべての地域でトラフィックのデータは使用できません。
</div>
<div>
 
</div></td>
</tr>
<tr class="even">
<td align="left"><p><b>rtp</b></p></td>
<td align="left"><p>ルート</p></td>
<td align="left"><p>rtp = "rtp=" (waypoint "~" [waypoint]) / ("~" waypoint)</p>
<p>waypoint = ("pos." point ) / ("adr." whereval)</p>
<p>point = "point." pointval ["_" title]</p>
<p>pointval = degreeslat "" degreeslon</p>
<p>degreeslat = ["-"] 13DIGIT ["." 17DIGIT]</p>
<p>degreeslon = ["-"] 12DIGIT ["." 17DIGIT]</p>
<p>title = whereval</p>
<p>whereval = 1( ALPHA / DIGIT / "-" / "." / "_" / pct-encoded / "!" / "$" / "'" / "(" / ")" / "" / "+" / "," / ";" / ":" / "@" / "/" / "?")</p>


<p>例:</p>
<p>rtp=adr.Mountain%20View,%20CA~adr.SFO</p>
<p>rtp=adr.One%20Microsoft%20Way,%20Redmond,%20WA~pos.45.23423_-122.1232 _My%20Picnic%20Spot</p></td>
<td align="left"><p>地図上に表示するルートの開始地点と終了地点を、チルダ (<b>~</b>) で区切って定義します。 各中間点は、緯度、経度、オプションのタイトルを使った位置、または住所の識別情報を使って定義します。</p>
<p>完全なルートとは、中間点が 2 つだけ含まれるルートです。 たとえば、2 つの中間点を持つルートは、<code>rtp="A"~"B"</code> のように定義されます。</p>
<p>不完全なルートを指定することもできます。 たとえば、ルートの開始地点だけを定義する場合は、<code>rtp="A"~</code> のように指定できます。 この場合、ルート案内の入力が表示されると、**[出発地]** フィールドには指定された中間点が表示され、**[目的地]** フィールドにフォーカスが設定されます。</p>
<p><code>rtp=~"B"</code> のようにルートの終了地点のみを指定した場合は、ルート案内のパネルが表示されると、**[目的地]** フィールドには指定された中間点が表示されます。 現在の正確な位置情報にアクセスできる場合、**[出発地]** フィールドに現在の場所があらかじめ入力され、フォーカスが設定されます。</p>
<p>不完全なルートが指定されている場合は、ルートの線は表示されません。</p>
<p>**mode** パラメーターと組み合わせて使うと、交通手段のモード (自動車、公共交通機関、徒歩) を指定できます。 **mode** が指定されていない場合、ルート案内は、ユーザーの交通手段の設定のモードを使って提供されます。</p>
<div class="alert">
**注:** **pos**パラメーターの値によって場所が指定されている場合は、場所に対してタイトルを使うことができます。 緯度と経度が表示される代わりに、タイトルが表示されます。
</div>
<div>
 
</div></td>
</tr>
<tr class="odd">
<td align="left"><p><b>mode</b></p></td>
<td align="left"><p>交通手段モード</p></td>
<td align="left"><p>mode = "mode=" ("d" / "t" / "w")</p>
<p>例:</p>
<p>mode=d</p></td>
<td align="left"><p>交通手段モードを定義します。 このパラメーターの有効な値は次のとおりです。</p>
<ul>
<li>**d**: 自動車ルート案内のルートの概要を表示します。</li>
<li>**t**: 乗り換え案内のルートの概要を表示します。</li>
<li>**w**: 徒歩ルート案内のルートの概要を表示します。</li>
</ul>
<p>交通手段案内の **rtp** パラメーターと組み合わせて使います。 **mode** が指定されていない場合、ルート案内は、ユーザーの交通手段の設定のモードを使って提供されます。 現在の位置情報からこのモード用のルート案内に入力するルート パラメーターなしに、**mode** を提供することができます。</p></td>
</tr>

<tr class="even">
<td align="left"><p><b>collection</b></p></td>
<td align="left"><p>コレクション</p></td>
<td align="left"><p>collection = "collection="(name"~"/)point["~"point]</p>
<p>name = "name." whereval </p>
<p>whereval = 1( ALPHA / DIGIT / "-" / "." / "_" / pct-encoded / "!" / "$" / "'" / "(" / ")" / "" / "+" / "," / ";" / ":" / "@" / "/" / "?") </p>
<p>point = "point." pointval ["_" title] </p>
<p>pointval = degreeslat "" degreeslon </p>
<p>degreeslat = ["-"] 13DIGIT ["." 17DIGIT] </p>
<p>degreeslon = ["-"] 12DIGIT ["." 17DIGIT] </p>
<p>title = whereval</p>


<p>例:</p>
<p>collection=name.My%20Trip%20Stops~point.36.116584_-115.176753_Las%20Vegas~point.37.8268_-122.4798_Golden%20Gate%20Bridge</p></td>
<td align="left"><p>地図と一覧に追加されるポイントのコレクションです。 name パラメーターを使用して、ポイントのコレクションに名前を付けることができます。 ポイントは、緯度、経度、およびオプションのタイトルを使用して指定されます。</p>
<p>名前と複数のポイントをチルダ (**~**) で区切ります。</p>
<p>指定した項目にチルダが含まれている場合は、そのチルダを <code>%7E</code> としてエンコードしてください。 中心点のパラメーターやズーム レベルのパラメーターと共に使わない場合、コレクションによって、最適な地図ビューが表示されます。</p>

<p>**重要** 指定した項目にアンダースコアが含まれている場合は、そのアンダースコアを %255F としてダブル エンコードしてください。</p></td>
</tr>
</tbody>
</table>

  
<span id="ms-drive-to-param-reference"/>

## <a name="ms-drive-to-parameter-reference"></a>ms-drive-to: のパラメーター リファレンス


ターン バイ ターン方式の自動車ルート案内の要求を起動する URI は、エンコードする必要がありません。その形式は、次のようになります。

> **注**  この URI スキームでは出発地を指定しません。 常に、現在の場所が出発地であると見なされます。 現在の場所以外の出発地を指定する必要がある場合は、「[ルート案内と交通情報の表示](#display-directions-and-traffic)」をご覧ください。

 

| パラメーター | 定義 | 例 | 詳細 |
|------------|-----------|---------|---------|
| **destination.latitude** | 目的地の緯度 | 例: destination.latitude=47.6451413797194 | 目的地の緯度です。 有効な緯度の値の範囲は -90 ～ +90 です (両端の値を含む)。 |
| **destination.longitude** | 目的地の経度 | 例: destination.longitude=-122.141964733601 | 目的地の経度です。 有効な経度の値の範囲は -180 ～ +180 です (両端の値を含む)。 |
| **destination.name** | 目的地の名前 | 例: destination.name=Redmond, WA | 目的地の名前です。 **destination.name** 値をエンコードする必要はありません。 |

 
<span id="ms-walk-to-param-reference"/>

## <a name="ms-walk-to-parameter-reference"></a>ms-walk-to: のパラメーター リファレンス


ターン バイ ターン方式の徒歩ルート案内の要求を起動する URI は、エンコードする必要がありません。その形式は、次のようになります。

> **注**  この URI スキームでは出発地を指定しません。 常に、現在の場所が出発地であると見なされます。 現在の場所以外の出発地を指定する必要がある場合は、「[ルート案内と交通情報の表示](#display-directions-and-traffic)」をご覧ください。
 

| パラメーター | 定義 | 例 | 詳細 |
|-----------|------------|---------|----------|
| **destination.latitude** | 目的地の緯度 | 例: destination.latitude=47.6451413797194 | 目的地の緯度です。 有効な緯度の値の範囲は -90 ～ +90 です (両端の値を含む)。 |
| **destination.longitude** | 目的地の経度 | 例: destination.longitude=-122.141964733601 | 目的地の経度です。 有効な経度の値の範囲は -180 ～ +180 です (両端の値を含む)。 |
| **destination.name** | 目的地の名前 | 例: destination.name=Redmond, WA | 目的地の名前です。 **destination.name** 値をエンコードする必要はありません。 |

## <a name="ms-settings-parameter-reference"></a>ms-settings: のパラメーター リファレンス

**ms-settings:** URI スキームのマップ アプリ固有のパラメーターの構文は、次のように定義されます。 **maps-downloadmaps** は、**ms-settings:** URI と共に **ms-settings:maps-downloadmaps?** の形式で指定され、オフライン マップの設定ページを示します。 

| パラメーター | 定義 | 例 | 詳細 |
|-----------|------------|---------|----------|
| **latlong** | オフライン マップの地域を定義するポイント。 | 例: latlong=47.6,-122.3 | GeoPoint は、コンマ区切りの緯度と経度で指定されます。 有効な緯度の値の範囲は -90 ～ +90 です (両端の値を含む)。 有効な経度の値の範囲は -180 ～ +180 です (両端の値を含む)。 |
