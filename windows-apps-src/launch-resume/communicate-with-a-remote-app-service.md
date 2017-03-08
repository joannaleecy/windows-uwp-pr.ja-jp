---
author: PatrickFarley
title: "リモート アプリ サービスとの通信"
description: "&quot;Rome&quot; プロジェクトを使って、リモート デバイスで実行されているアプリ サービスとメッセージをやり取りします。"
ms.assetid: a0261e7a-5706-4f9a-b79c-46a3c81b136f
ms.author: pafarley
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
translationtype: Human Translation
ms.sourcegitcommit: c6b64cff1bbebc8ba69bc6e03d34b69f85e798fc
ms.openlocfilehash: 0cac219625fbc7b6526c81cf11f010589d2bf000
ms.lasthandoff: 02/07/2017

---

# <a name="communicate-with-a-remote-app-service"></a>リモート アプリ サービスとの通信

URI を使ってリモート デバイスでアプリを起動するのに加えて、リモート デバイスでも*アプリ サービス*を実行して通信できます。 どの Windows ベースのデバイスでも、クライアント デバイス、またはホスト デバイスのいずれかとして使うことができます。 これにより、アプリをフォアグラウンドにしなくても、接続されているデバイスとやり取りする方法がほぼ無限になります。

## <a name="set-up-the-app-service-on-the-host-device"></a>ホスト デバイスでアプリ サービスをセットアップする
リモート デバイスでアプリ サービスを実行するには、アプリ サービスのプロバイダーが既にそのデバイスにインストールされている必要があります。 このガイドでは、[ユニバーサル Windows アプリ サンプルのリポジトリ](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/AppServices)で入手可能な乱数ジェネレーター アプリ サービスを使います。 独自のアプリ サービスを記述する方法については、「[アプリ サービスの作成と利用](how-to-create-and-consume-an-app-service.md)」をご覧ください。

既製のアプリ サービスを使うか独自のアプリ サービスを記述するかにかかわらず、リモート システムとの互換性を確保するにはいくらかの編集を行う必要があります。 Visual Studio で、アプリ サービス プロバイダーのプロジェクトに移動し、その Package.appxmanifest ファイルを選びます。 右クリックして **[コードの表示]** を選び、ファイルの全内容を表示します。 プロジェクトをアプリ サービスとして定義する **Extension** 要素を見つけ、その親プロジェクトに名前を付けます。

``` xml
...
<Extensions>
    <uap:Extension Category="windows.appService" EntryPoint="RandomNumberService.RandomNumberGeneratorTask">
        <uap:AppService Name="com.microsoft.randomnumbergenerator"/>
    </uap:Extension>
</Extensions>
...
```

**AppService** 要素の名前空間を **uap3** に変更し、**SupportsRemoteSystems** 属性に変更します。

``` xml
...
<uap3:AppService Name="com.microsoft.randomnumbergenerator" SupportsRemoteSystems="true"/>
...
```

この新しい名前空間で要素を使うには、マニフェスト ファイルの上部に名前空間定義を追加する必要があります。

``` xml
<?xml version="1.0" encoding="utf-8"?>
<Package
  xmlns="http://schemas.microsoft.com/appx/manifest/foundation/windows10"
  xmlns:mp="http://schemas.microsoft.com/appx/2014/phone/manifest"
  xmlns:uap="http://schemas.microsoft.com/appx/manifest/uap/windows10"
  xmlns:uap3="http://schemas.microsoft.com/appx/manifest/uap/windows10/3">
  ...
</Package>
```

アプリ サービス プロバイダー プロジェクトをビルドし、ホスト デバイスに展開します。

## <a name="target-the-app-service-from-the-client-device"></a>クライアント デバイスからアプリ サービスをターゲットにする
呼び出すリモート アプリ サービスの元となるデバイスには、リモート システム機能を備えたアプリが必要です。 これは、ホスト デバイスでアプリ サービスを提供する同じアプリに追加するか (この場合、両方のデバイスに同じアプリをインストールします)、完全に別のアプリに実装することができます。

このセクションのコードをそのまま実行するには、次の **using** ステートメントが必要です。

[!code-cs[メイン](./code/RemoteAppService/MainPage.xaml.cs#SnippetUsings)]


まず、アプリ サービスをローカルで呼び出すのと同じように [**AppServiceConnection**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.AppService.AppServiceConnection) オブジェクトをインスタンス化する必要があります。 このプロセスについては、「[アプリ サービスの作成と利用](how-to-create-and-consume-an-app-service.md)」で詳しく説明します。 この例では、ターゲットにアプリ サービスは乱数ジェネレーター サービスです。

> [!NOTE]
> 次のメソッドを呼び出すコード内で、何らかの方法で [RemoteSystem](https://msdn.microsoft.com/library/windows/apps/Windows.System.RemoteSystems.RemoteSystem) オブジェクトが既に取得されていることを前提としています。 これをセットアップする方法については、「[リモート アプリの起動](launch-a-remote-app.md)」をご覧ください。

[!code-cs[メイン](./code/RemoteAppService/MainPage.xaml.cs#SnippetAppService)]

次に、目的のリモート デバイスに [**RemoteSystemConnectionRequest**](https://msdn.microsoft.com/library/windows/apps/Windows.System.RemoteSystems.RemoteSystemConnectionRequest) オブジェクトが作成されます。 これは、そのサービスに対して **AppServiceConnection** を開くために使われます。 次の例では、簡単にするためにエラー処理とレポートが大幅に簡略化されている点に注意してください。

[!code-cs[メイン](./code/RemoteAppService/MainPage.xaml.cs#SnippetRemoteConnection)]

現時点では、リモート コンピューター上のアプリ サービスへの接続が開かれている必要があります。

## <a name="exchange-service-specific-messages-over-the-remote-connection"></a>リモート接続経由でサービス固有のメッセージをやり取りする

ここでは、[**ValueSet**](https://msdn.microsoft.com/library/windows/apps/windows.foundation.collections.valueset) オブジェクトの形式を使ってサービスとの間でメッセージを送受信できます (詳しくは「[アプリ サービスの作成と利用](how-to-create-and-consume-an-app-service.md)」をご覧ください)。 乱数ジェネレーター サービスは、キー `"minvalue"` と `"maxvalue"` と共に 2 つの整数を入力として取得し、その範囲内の整数をランダムに選んで、キー `"Result"` と共に呼び出し元プロセスに返します。

[!code-cs[メイン](./code/RemoteAppService/MainPage.xaml.cs#SnippetSendMessage)]

ここでは、ターゲットとなるホスト デバイス上のアプリ サービスに接続して、そのデバイスで操作を実行し、応答でクライアント デバイスへのデータを受信しました。

## <a name="related-topics"></a>関連トピック

[接続されるアプリやデバイス ("Rome" プロジェクト) の概要](connected-apps-and-devices.md)  
[リモート アプリの起動](launch-a-remote-app.md)  
[アプリ サービスの作成と利用](how-to-create-and-consume-an-app-service.md)  
[リモート システムの API リファレンス](https://msdn.microsoft.com/library/windows/apps/Windows.System.RemoteSystems)  
[リモート システムのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/dev/Samples/RemoteSystems)

