---
author: QuinnRadich
title: "Windows 10 バージョン 1607 Preview の新着情報"
description: "Windows 10 バージョン 1607 Preview と新しい開発者ツールを使うと、新しいユニバーサル Windows プラットフォームによって強化されたツール、機能、そしてエクスペリエンスが利用できます。"
keywords: "新着情報, 新しい情報, 更新, 更新情報, 機能, 新規, Windows 10, 1607 preview"
ms.author: quradic
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.assetid: 835d5393-427f-4155-a737-d509ea1de99f
translationtype: Human Translation
ms.sourcegitcommit: 5645eee3dc2ef67b5263b08800b0f96eb8a0a7da
ms.openlocfilehash: 51076aed4ae55956164efaf3a3c01461e4b7338b
ms.lasthandoff: 02/08/2017

---

# <a name="whats-new-in-windows"></a>Windows の新着情報

Windows 10 バージョン 1607 Preview と Windows 開発者ツールの更新プログラムでは、引き続きユニバーサル Windows プラットフォームによって強化されたツール、機能、エクスペリエンスを提供しています。 Windows 10 の[ツールと SDK をインストール](http://go.microsoft.com/fwlink/?LinkId=821431)すると、[新しいユニバーサル Windows アプリを作成](https://msdn.microsoft.com/library/windows/apps/bg124288)したり、[Windows の既存のアプリ コード](https://msdn.microsoft.com/library/windows/apps/mt238321)がどのように使えるかを試したりすることができます。

## <a name="windows-10-version-1607-preview"></a>Windows 10 バージョン 1607 Preview

機能 | 説明
 :---- | :----
ネットワーク | サーバー SSL/TLS 証明書に対して独自のカスタム検証を実行できるようになりました。これを行うには、[HttpBaseProtocolFilter.ServerCustomValidationRequest](https://msdn.microsoft.com/library/windows/apps/windows.web.http.filters.httpbaseprotocolfilter.aspx#_blank) イベントを受信登録します。 HTTP 要求で [HttpCacheReadBehavior.NoCache](https://msdn.microsoft.com/library/windows/apps/windows.web.http.filters.httpcachereadbehavior.aspx#_blank) 列挙値を指定することで、キャッシュからの HTTP 応答の読み取りを完全に無効にすることもできます。 [HttpBaseProtocolFilter.ClearAuthenticationCache](https://msdn.microsoft.com/library/windows/apps/windows.web.http.filters.httpbaseprotocolfilter.aspx#_blank) メソッドを呼び出すことで、認証資格情報を消去して "ログアウト" シナリオを実現できるようになりました。
拡張機能 | Microsoft Edge の新機能は、拡張機能を使えるようになったことです。 拡張機能を使用すると、ユーザーは Microsoft Edge の機能を拡張できるようになり、ターゲットのユーザーが重要視するニッチな機能を提供することが可能です。 詳しくは、[拡張機能に関するドキュメント](https://developer.microsoft.com/microsoft-edge/platform/documentation/extensions/#_blank)をご覧ください。
Bluetooth API | アプリでリモートの Bluetooth 周辺機器の RFCOMM サービスにアクセスできるようになりました。これには、[Windows.Devices.Bluetooth and Windows.Devices.Bluetooth.Rfcomm](https://msdn.microsoft.com/library/windows/apps/windows.devices.bluetooth.aspx#_blank) を使用し、あらかじめ周辺機器とペアリングしておく必要はありません。 新しいメソッドを使用すると、ペアリングされていないデバイス上の RFCOMM サービスをアプリで検索し、そのサービスにアクセスできます。
チャット API | 新しい [ChatSyncManager](https://msdn.microsoft.com/library/windows/apps/mt414181.aspx#_blank) クラスを使用すると、クラウドとの間で送受信するテキスト メッセージを同期できます。
[Android と iOS 開発者向けの Windows アプリ概念マッピング](https://msdn.microsoft.com/windows/uwp/porting/android-ios-uwp-map#_blank) | このリソースには、Android や iOS のスキルとコードを持つ開発者が Windows 10 とユニバーサル Windows プラットフォーム (UWP) に移行する場合に、それら 3 つのプラットフォーム間でプラットフォームの機能と知識を関連付けるために必要なすべての情報が含まれています。
[エンタープライズ データ保護 (EDP)](https://msdn.microsoft.com/windows/uwp/enterprise/wip-hub) | EDP は、モバイル デバイス管理 (MDM) 用にデスクトップ、ノート PC、タブレット、および電話に搭載された機能のセットです。 EDP を使用すると、企業は、自社で管理するデバイス上でのデータ (企業のファイルやデータ BLOB) の処理方法をより詳しく制御できるようになります。
[Windows.ApplicationModel.AppExtensions](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.appextensions.aspx#_blank) | 新しい AppExtensions 名前空間を使用すると、他の Windows ストア アプリから提供されるコンテンツを、Windows ストア アプリでホストできます。 それらのアプリの読み取り専用コンテンツを検出、列挙、およびアクセスすることが可能です。
Windows IoT | Windows 10 IoT Core を使うと、使い慣れた Windows で IoT アプリケーションを作成できます。現在、Windows 10 IoT Core は最新の Raspberry Pi ボードである Raspberry Pi 3 で使用できます。
Media API | Windows.Media.Playback 名前空間の新しい MediaBreak API では、MediaSource と MediaPlaybackItem を使ってメディアを再生する場合にメディアの中断を簡単にスケジュールして管理できます。 Windows.Media.Audio 名前空間の新しい AudioGraph API により、3D 配置されたエミッターとリスナーをオーディオ グラフ ノードに割り当てることのできる、空間的なオーディオ処理が追加されています。
マップ API | [MapControl](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.maps.mapcontrol.aspx#_blank) を改良し、開発者はカメラ周辺の表示領域を取得して、深い傾斜があるビューで遠く離れた地平線近くの領域は除外できるようになりました。 拡張した [MapLocationFinder](https://msdn.microsoft.com/library/windows/apps/windows.services.maps.maplocationfinder.aspx#_blank) クラスにより、必要な精度を指定することで、逆ジオコーディングを実行する場合にネットワーク トラフィックを最適化できます。 また、[LaunchUriAsync](https://msdn.microsoft.com/library/windows/apps/hh701480.aspx#_blank) メソッドを使用して緯度と経度を指定し、オフライン マップのダウンロードを利用できるようになりました。 詳しくは、「[Windows マップ アプリの起動](https://msdn.microsoft.com/windows/uwp/launch-resume/launch-maps-app#_blank)」をご覧ください。

