---
title: 地図と位置情報の概要
description: このセクションでは、アプリで地図の表示、マップ サービスの使用、位置情報の検索、ジオフェンスのセットアップを行う方法について説明します。 また、Windows マップ アプリを起動し、特定の地図やルート、ターン バイ ターン方式のルート案内を表示する方法についても説明します。
ms.assetid: F4C1F094-CF46-4B15-9D80-C1A26A314521
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, 地図, 位置情報, マップ サービス
ms.localizationpriority: medium
ms.openlocfilehash: 3482370719a658f303964204661f1fb5d69ae5b4
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57583235"
---
# <a name="maps-and-location-overview"></a>地図と位置情報の概要




このセクションでは、アプリで地図の表示、マップ サービスの使用、位置情報の検索、ジオフェンスのセットアップを行う方法について説明します。 また、Windows マップ アプリを起動し、特定の地図やルート、ターン バイ ターン方式のルート案内を表示する方法についても説明します。

> [!TIP]
> アプリで地図と位置情報を使う方法について詳しくは、GitHub の [Windows-universal-samples リポジトリ](https://go.microsoft.com/fwlink/p/?LinkId=619979)から次のサンプルをダウンロードしてください。
-   [ユニバーサル Windows プラットフォーム (UWP) の地図のサンプル](https://go.microsoft.com/fwlink/p/?LinkId=619977)
-   [UWP の位置情報のサンプル](https://go.microsoft.com/fwlink/p/?linkid=533278)

 

## <a name="display-maps"></a>地図の表示


[  **Windows.UI.Xaml.Controls.Maps**](https://msdn.microsoft.com/library/windows/apps/dn610751) 名前空間の API を使って、アプリで地図を 2D、3D、または Streetside ビューで表示できます。 プッシュピン、画像、図形、XAML UI 要素を使って、関心のあるポイント (POI) を地図に表示できます。 また、タイル画像をオーバーレイしたり、地図の画像を完全に置き換えたりすることもできます。

| トピック | 説明 |
|-------|-------------|
| [マップ認証キーの要求](authentication-key.md) | [  **MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004) や [**Windows.Services.Maps**](https://msdn.microsoft.com/library/windows/apps/dn636979) 名前空間のマップ サービスをアプリで使うには、アプリを認証する必要があります。 アプリを認証するには、マップ認証キーを指定する必要があります。 この記事では、[Bing Maps Developer Center](https://www.bingmapsportal.com/) にマップ認証キーを要求し、アプリに追加する方法について説明します。 |
| [2D、3D、Streetside ビューでの地図の表示](display-maps.md) | [  **MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004) クラスを使って、アプリにカスタマイズできる地図を表示します。 このトピックでは、航空写真 3D ビューと Streetside ビューについても紹介します。 |
| [関心のあるポイント (POI) の地図への表示](display-poi.md) | プッシュピン、画像、図形、XAML UI 要素を使って、関心のあるポイント (POI) を地図に追加します。 |
| [地図へのタイル画像のオーバーレイ](overlay-tiled-images.md) | タイル ソースを使って、地図上にサード パーティ製タイルまたはカスタム タイル画像をオーバーレイします。 タイル ソースを使って、気象データ、人口データ、地質データなどの特殊な情報をオーバーレイすることや、既定の地図を完全に置き換えることができます。 |



## <a name="access-map-services"></a>マップ サービスへのアクセス

[  **Windows.Services.Maps**](https://msdn.microsoft.com/library/windows/apps/dn636979) 名前空間の API を使って、ルート、ルート案内、ジオコーディング機能をアプリに追加します。

| トピック | 説明 |
|-----------------------------------------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| [マップ認証キーの要求](authentication-key.md) | [  **MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004) や [**Windows.Services.Maps**](https://msdn.microsoft.com/library/windows/apps/dn636979) 名前空間のマップ サービスをアプリで使うには、アプリを認証する必要があります。 アプリを認証するには、マップ認証キーを指定する必要があります。 この記事では、[Bing Maps Developer Center](https://www.bingmapsportal.com/) にマップ認証キーを要求し、アプリに追加する方法について説明します。 |
| [関心のあるポイント (POI) の地図への表示](display-poi.md) | プッシュピン、画像、図形、XAML UI 要素を使って、関心のあるポイント (POI) を地図に追加します。 |
| [ルートとルート案内の表示](routes-and-directions.md) | ルートとルート案内を要求し、アプリで表示します。 |
| [ジオコーディングと逆ジオコーディングの実行](geocoding.md) | 住所から地理的な位置への変換 (ジオコーディング) や地理的な位置から住所への変換 (逆ジオコーディング) を行うには、[**Windows.Services.Maps**](https://msdn.microsoft.com/library/windows/apps/dn636979) 名前空間の [**MapLocationFinder**](https://msdn.microsoft.com/library/windows/apps/dn627550) クラスのメソッドを呼び出します。 |
| [オフラインで使用するマップ パッケージを見つけてダウンロードする](https://docs.microsoft.com/uwp/api/windows.services.maps.offlinemaps)| これまでは、オフライン マップをダウンロードするには、アプリでユーザーを設定アプリに誘導する必要があります。 現在は、[Windows.Services.Maps.OfflineMaps](https://docs.microsoft.com/en-us/uwp/api/windows.services.maps.offlinemaps) 名前空間のクラスを使用して、([Geopoint](https://docs.microsoft.com/uwp/api/Windows.Devices.Geolocation.Geopoint)、[GeoboundingBox](https://docs.microsoft.com/en-us/uwp/api/windows.devices.geolocation.geoboundingbox) などに基づいて) 特定の領域でダウンロードされたパッケージを見つけることができます。 <br> マップ パッケージのダウンロードの状態を確認してリッスンすることもでき、また、ユーザーがアプリから離れなくても、ダウンロードを開始することができます。 <br> この方法の例については、リファレンス コンテンツと、[ユニバーサル Windows プラットフォーム (UWP) の地図のサンプル](https://go.microsoft.com/fwlink/p/?LinkId=619977)に関するページの両方で確認できます。

## <a name="get-the-users-location"></a>ユーザーの位置情報の取得

[  **Windows.Devices.Geolocation**](https://msdn.microsoft.com/library/windows/apps/br225603) 名前空間の API を使って、アプリでユーザーの現在の位置情報を取得し、位置情報が変わったときに通知を受けるようにします。 これらの API メンバーは、マップ API のパラメーターでも頻繁に使われます。 [  **Windows.Devices.Geolocation.Geofencing**](https://msdn.microsoft.com/library/windows/apps/dn263744) 名前空間の API を使って、ユーザーがジオフェンス (事前定義された地理的領域) に入ったり、ジオフェンスから出たりしたときにアプリで通知を受けるようにします。

| トピック | 説明 |
|-------------------------------------------------------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| [マップ認証キーの要求](authentication-key.md) | [  **MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004) や [**Windows.Services.Maps**](https://msdn.microsoft.com/library/windows/apps/dn636979) 名前空間のマップ サービスをアプリで使うには、アプリを認証する必要があります。 アプリを認証するには、マップ認証キーを指定する必要があります。 この記事では、[Bing Maps Developer Center](https://www.bingmapsportal.com/) にマップ認証キーを要求し、アプリに追加する方法について説明します。 |
| [位置認識アプリの設計ガイドライン](guidelines-and-checklist-for-detecting-location.md) | ユーザーの位置情報にアクセスする必要があるアプリを構築するためのパフォーマンス ガイドラインです。 |
| [ユーザーの位置情報の取得](get-location.md) | ユーザーの位置情報にアクセスして取得します。 | 
| [ビジット追跡の使用ガイドライン](guidelines-for-visits.md) | 実用的な位置情報追跡に役立つ強力なビジット追跡機能を使用する方法について説明します。 |
| [ジオフェンスの設計ガイダンス](guidelines-for-geofencing.md) | ジオフェンス機能を利用するアプリのパフォーマンス ガイドラインです。 |
| [ジオフェンスのセットアップ](set-up-a-geofence.md) | アプリでジオフェンスをセットアップし、フォアグラウンドとバックグラウンドで通知を処理する方法について説明します。 |

## <a name="launch-the-windows-maps-app"></a>Windows マップ アプリの起動

アプリで、ここで示しているように、Windows マップ アプリを起動し、特定の地図やターン バイ ターン方式のルート案内を表示できます。 独自のアプリでマップ機能を直接提供する代わりに、Windows マップ アプリを使ってその機能を提供することを検討してください。 詳しくは、「[Windows マップ アプリの起動](https://msdn.microsoft.com/library/windows/apps/mt228341)」をご覧ください。

![Windows マップ アプリの例。](images/mapnyc.png)

## <a name="related-topics"></a>関連トピック

* [UWP の地図のサンプル](https://go.microsoft.com/fwlink/p/?LinkId=619977)
* [UWP の位置情報のサンプル](https://go.microsoft.com/fwlink/p/?linkid=533278)
* [Bing Maps Developer Center](https://www.bingmapsportal.com/)
* [現在の位置情報の取得](get-location.md)
* [位置認識アプリの設計ガイドライン](guidelines-and-checklist-for-detecting-location.md)
* [地図の設計ガイドライン](controls-map.md)
* [個人データにアクセスするアプリの設計ガイドライン](https://msdn.microsoft.com/library/windows/apps/hh768223)
* [Build 2015 のビデオ:Windows アプリでの電話、タブレット、PC で使用できるマップと位置情報の活用](https://channel9.msdn.com/Events/Build/2015/2-757)
* [UWP の交通情報アプリのサンプル](https://go.microsoft.com/fwlink/p/?LinkId=619982)
