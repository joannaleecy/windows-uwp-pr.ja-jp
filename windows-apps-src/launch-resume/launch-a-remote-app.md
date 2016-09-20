---
author: TylerMSFT
title: "リモート デバイスでのアプリの起動"
description: "&quot;Rome&quot; プロジェクトを使って、リモート デバイスでアプリを起動する方法について説明します。"
translationtype: Human Translation
ms.sourcegitcommit: ff8e16d0e376d502157ae42b9cdae11875008554
ms.openlocfilehash: d8c3783d68a1b3b216058790d84255a7fb4b612c

---

# リモート デバイスでのアプリの起動

この記事では、ユニバーサル Windows プラットフォーム (UWP) アプリまたは Windows デスクトップ アプリをリモート デバイスで起動する方法について説明します。

Windows 10 バージョン 1607 以降、UWP アプリでは、同様に Windows 10 バージョン 1607 以降を実行している別のデバイスから、UWP アプリまたは Windows デスクトップ アプリケーションをリモートで起動できます。

リモート デバイスでアプリを起動するシナリオの 1 つでは、ユーザーがあるデバイスでタスクを開始し、別のデバイスでタスクを完了できます。 たとえば、自宅に車で帰っている際にスマートフォンで音楽を聴いている場合、自宅に到着したときに、リモート起動によって再生する機器を Xbox に切り替えることができます。 リモート アプリにデータを渡して、リモート アプリがタスクを続行するためのコンテキストを提供できます。

## RemoteSystem 機能を追加する

アプリでリモート デバイスのアプリを起動するには、<uap3:Capability Name="remoteSystem"/> 機能をアプリ パッケージ マニフェストに追加する必要があります。 **[機能]** タブの **[リモート システム]** を選んでパッケージ マニフェスト デザイナーを使用したり、パッケージ マニフェスト デザイナーが行う作業を手動で行って以下のコードを Package.appxmanifest ファイルに追加できます。

``` xml
<Capabilities>
   <uap3:Capability Name="remoteSystem"/>
 </Capabilities>
```
## リモート デバイスを見つける

最初に、接続するデバイスを見つける必要があります。 
              この方法については、「[リモート デバイスの検出](discover-remote-devices.md)」で詳しく説明されています。 ここでは、デバイスまたは接続の種類によるフィルタリングを避けた、シンプルなアプローチを使います。 リモート デバイスを探すリモート システム ウォッチャーを作成し、同じ Microsoft アカウントを使うデバイスが検出または削除されたときに通知を受けるイベント ハンドラーを記述します。 これにより、リモート デバイスのコレクションが提供されます。

この例のコードでは、ファイルに `using Windows.System.RemoteSystems` ステートメントがあることを前提としています。

[!code-cs[メイン](./code/RemoteLaunchScenario/MainPage.xaml.cs#SnippetBuildDeviceList)]

リモート起動を作成する前に、最初に `RemoteSystem.RequestAccessAsync()` を呼び出す必要があります。 戻り値を確認して、お使いのアプリがリモート デバイスにアクセスする許可を持っていることを確認してください。 このチェックが失敗する理由の 1 つは、アプリに `remoteSystem` 機能を追加していないことです。

システム ウォッチャーのイベント ハンドラーは、接続可能なデバイスが検出されたとき、または接続できなくなったときに呼び出されます。 これらのイベント ハンドラーを使用して、接続可能なデバイスの一覧を最新に保ちます。

[!code-cs[メイン](./code/RemoteLaunchScenario/MainPage.xaml.cs#SnippetEventHandlers)]

Dictionary を使って、リモート システム ID によってデバイスを追跡します。 ObservableCollection を使って、列挙可能なデバイスの一覧を保持します。 ObservableCollection ではデバイスの一覧を UI にバインドすることも簡単にできますが、この例では行いません。

[!code-cs[メイン](./code/RemoteLaunchScenario/MainPage.xaml.cs#SnippetMembers)]

リモート アプリの起動を試みる前に、アプリのスタートアップ コードに `BuildDeviceList()` への呼び出しを追加します。

## リモート デバイスでのアプリの起動

接続するデバイスを [RemoteLauncher.LaunchUri](https://msdn.microsoft.com/en-us/library/windows/apps/windows.system.remotelauncher.launchuriasync.aspx) API に渡すことによって、アプリをリモートで起動します。 この関数には 3 つのオーバーロードがあります。 この例で示されている最も単純なオーバーロードでは、リモート デバイス上のアプリをアクティブ化する URI を指定します。 この例では、URI によって、リモート コンピューター上のマップ アプリがスペース ニードルの 3D ビューで開かれます。

その他の **RemoteLauncher.LaunchUriAsync** オーバーロードを使うと、URI を処理可能なアプリがリモート デバイスで起動できないことを確認するための Web サイトの URI などのオプションや、リモート デバイスでの URI の起動に使用できるパッケージ ファミリ名のオプションの一覧を指定できます。 キーと値のペアの形式でデータを提供することもできます。 音楽の再生をデバイスから別のデバイスへと切り替えるとき、リモート デバイスでアクティブ化しているアプリにデータを渡して、再生する曲名や現在の再生位置などのコンテキストをリモート アプリに提供する場合があります。

実際に使用するときには、UI を提供して、使用するデバイスを選ぶ場合があります。 ただし、この例をシンプルにするために、一覧の最初の 1 つだけを使ってリモート呼び出しを作成しています。

[!code-cs[メイン](./code/RemoteLaunchScenario/MainPage.xaml.cs#SnippetRemoteUriLaunch)]

**RemoteLauncher.LaunchUriAsync()** から返される [RemoteLaunchUriStatus](https://msdn.microsoft.com/en-us/library/windows/apps/windows.system.remotelaunchuristatus.aspx) は、リモートの起動が成功したかどうか、さらに、失敗した場合はその理由についての情報を提供します。

## 関連トピック

[リモート システムの API リファレンス](https://msdn.microsoft.com/en-us/library/windows/apps/Windows.System.RemoteSystems)  
[接続されるアプリやデバイス ("Rome" プロジェクト) の概要](connected-apps-and-devices.md)  
[リモート システムのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/dev/Samples/RemoteSystems )では、リモート システムを検出する方法、リモート システムでアプリを起動する方法、アプリ サービスを使って 2 つのシステム上で実行しているアプリ間でメッセージを送信する方法が説明されています。



<!--HONumber=Aug16_HO5-->


