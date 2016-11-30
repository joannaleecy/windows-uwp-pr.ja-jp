---
author: PatrickFarley
title: "リモート デバイスの検出"
description: Learn how to discover remote devices from your app using Project "Rome".
translationtype: Human Translation
ms.sourcegitcommit: dc5030fea8e149b3926b926b09bfec3eeb5092ee
ms.openlocfilehash: b4b4eb28ea56ab3d84e2fe0bc0c281cb53149d5d

---

# リモート デバイスの検出
アプリは、ワイヤレス ネットワーク、Bluetooth、クラウド接続を使用って、検出側デバイスと同じ Microsoft アカウントでサインインしている Windows デバイスを検出できます。 Surface Hub や Xbox One などの、匿名接続を受け入れる共用デバイスも検出できます。 リモート デバイスを検出するために特別なソフトウェアをインストールする必要はありません。

> [!NOTE]
> このガイドでは、「[リモート アプリの起動](launch-a-remote-app.md)」の手順に従うことで、リモート システム機能へのアクセスが既に許可されていることを前提としています。

## 検出可能な一連のデバイスのフィルター処理
フィルターに [ **RemoteSystemWatcher** ](https://msdn.microsoft.com/library/windows/apps/Windows.System.RemoteSystems.RemoteSystemWatcher) を使うことで、検出可能な一連のデバイスを絞り込むことができます。 フィルターは、検出の種類 (ローカル ネットワークかクラウド接続か)、デバイスの種類 (デスクトップ、モバイル デバイス、Xbox、Hub、ホログラフィック)、利用可能ステータス (デバイスがリモート システム機能を利用可能かどうかのステータス) を検出できます。

**RemoteSystemWatcher** オブジェクトを初期化する前に、フィルター オブジェクトを作成する必要があります。コンストラクターにパラメーターとして渡されるためです。 次のコードでは、利用可能な各種類のフィルターを作成し、一覧に追加します。

> [!NOTE]
> この例のコードでは、ファイルに `using Windows.System.RemoteSystems` ステートメントがあることを前提としています。

[!code-cs[メイン](./code/DiscoverDevices/MainPage.xaml.cs#SnippetMakeFilterList)]

[**IRemoteSystemFilter**](https://msdn.microsoft.com/library/windows/apps/Windows.System.RemoteSystems.IRemoteSystemFilter) オブジェクトの一覧を作成すると、**RemoteSystemWatcher** のコンストラクターに渡すことができます。

[!code-cs[メイン](./code/DiscoverDevices/MainPage.xaml.cs#SnippetCreateWatcher)]

このウォッチャーの [**Start**](https://msdn.microsoft.com/library/windows/apps/Windows.System.RemoteSystems.RemoteSystemWatcher.Start) メソッドが呼び出されると、次の条件を満たすデバイスが検出された場合のみ [**RemoteSystemAdded**](https://msdn.microsoft.com/library/windows/apps/Windows.System.RemoteSystems.RemoteSystemWatcher.RemoteSystemAdded) イベントが発生します。
* 近接接続によって検出可能
* デスクトップまたは携帯電話である
* 利用可能として分類されている

これ以降、イベントの処理、[**RemoteSystem**](https://msdn.microsoft.com/library/windows/apps/Windows.System.RemoteSystems.RemoteSystem) オブジェクトの取得、リモート デバイスへの接続の手順は「[リモート アプリの起動](launch-a-remote-app.md)」とまったく同じ手順です。 つまり、**RemoteSystem** オブジェクトは、各 **RemoteSystemAdded** イベントのパラメーターである [**RemoteSystemAddedEventArgs**](https://msdn.microsoft.com/library/windows/apps/Windows.System.RemoteSystems.RemoteSystemAddedEventArgs) オブジェクトのプロパティとして格納されます。

## アドレス入力によるデバイスの検出
ユーザーに関連付けられていないか、スキャンで検出することができないデバイスでも、検出側のアプリが直接アドレスを使う場合はアクセスできます。 リモート デバイスのアドレスを表すには、[ **HostName** ](https://msdn.microsoft.com/library/windows/apps/windows.networking.hostname.aspx) クラスを使います。 これは多くの場合 IP アドレスの形式で保存されますが、他のいくつかの形式も使うことができます (詳しくは、「[ **HostName コンス トラクター** ](https://msdn.microsoft.com/library/windows/apps/br207118.aspx)」をご覧ください)。

**RemoteSystem** オブジェクトは、有効な **HostName** オブジェクトが指定された場合に取得されます。 アドレス データが無効な場合、`null` オブジェクト参照が返されます。

[!code-cs[メイン](./code/DiscoverDevices/MainPage.xaml.cs#SnippetFindByHostName)]

## 関連トピック
[接続されているアプリとデバイス ("Rome" プロジェクト)](connected-apps-and-devices.md)  
[リモート アプリの起動](launch-a-remote-app.md)  
[リモート システムの API リファレンス](https://msdn.microsoft.com/library/windows/apps/Windows.System.RemoteSystems)  
[リモート システムのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/dev/Samples/RemoteSystems )では、リモート システムを検出する方法、リモート システムでアプリを起動する方法、アプリ サービスを使って 2 つのシステム上で実行しているアプリ間でメッセージを送信する方法が説明されています。



<!--HONumber=Nov16_HO1-->


