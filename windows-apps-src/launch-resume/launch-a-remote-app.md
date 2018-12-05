---
title: リモート デバイスでのアプリの起動
description: "\"Rome\" プロジェクトを使って、リモート デバイスでアプリを起動する方法について説明します。"
ms.date: 02/12/2018
ms.topic: article
keywords: windows 10, uwp, 接続されているデバイス、リモート システム、"rome"、"rome"プロジェクト
ms.assetid: 54f6a33d-a3b5-4169-8664-653dbab09175
ms.localizationpriority: medium
ms.openlocfilehash: 26a67816195105572d9f690599b9a880ece90c98
ms.sourcegitcommit: c01c29cd97f1cbf050950526e18e15823b6a12a0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/05/2018
ms.locfileid: "8696510"
---
# <a name="launch-an-app-on-a-remote-device"></a>リモート デバイスでのアプリの起動

この記事では、Windows アプリをリモート デバイスで起動する方法について説明します。

Windows 10 Version 1607 以降で実行される UWP アプリは、同じく Windows Version 1607 を実行し、同じ Microsoft アカウント (MSA) にサインオンしている別のデバイスの UWP アプリまたは Windows デスクトップ アプリケーションをリモートで起動できます。 これは Project Rome の最も簡単な使用例です。

このリモート起動機能を使うと、ユーザーが 1 台のデバイスでタスクを開始し、別のデバイスでそのタスクを完了するといった、タスク指向のユーザー エクスペリエンスが実現します。 たとえば、車を運転しながらスマートフォンで音楽を聴き、自宅に着いた後は、機器を Xbox One に切り替えて同じ音楽を引き続き再生することができます。 リモート起動では、中断した箇所からタスクを続行できるように、起動するリモート アプリにコンテキスト データを渡します。

## <a name="preliminary-setup"></a>準備段階のセットアップ

### <a name="add-the-remotesystem-capability"></a>remoteSystem 機能を追加する

アプリでリモート デバイスのアプリを起動するには、`remoteSystem` 機能をアプリ パッケージ マニフェストに追加する必要があります。 これには、マニフェスト デザイナーで  **[機能]** タブの **[リモート システム]** を選んで追加するか、プロジェクトの _Package.appxmanifest_ ファイルに以下のコードを手動で追加します。

``` xml
<Capabilities>
   <uap3:Capability Name="remoteSystem"/>
</Capabilities>
```

### <a name="enable-cross-device-sharing"></a>クロスデバイス共有を実現

さらに、クライアントデバイスは、デバイス間の共有を許可するように設定する必要があります。 この設定には **[設定]** : **[システム]** > **[共有エクスペリエンス]** > **[デバイス間で共有します]** でアクセスできます。既定で有効になっています。 

![[共有エクスペリエンス] 設定ページ](images/shared-experiences-settings.png)

## <a name="find-a-remote-device"></a>リモート デバイスを見つける

最初に、接続するデバイスを見つける必要があります。 この方法については、「[リモート デバイスの検出](discover-remote-devices.md)」で詳しく説明されています。 ここでは、デバイスまたは接続の種類によるフィルタリングを避けた、シンプルなアプローチを使います。 つまり、リモート デバイスを探すリモート システム ウォッチャーを作成し、デバイスが検出または削除されたときに発生するイベントのハンドラーを記述します。 これにより、リモート デバイスのコレクションが提供されます。

この例のコードでは、クラス ファイルに `using Windows.System.RemoteSystems` ステートメントがあることを利用としています。

[!code-cs[Main](./code/RemoteLaunchScenario/MainPage.xaml.cs#SnippetBuildDeviceList)]

リモート起動を作成する前に、最初に `RemoteSystem.RequestAccessAsync()` を呼び出す必要があります。 戻り値を確認して、お使いのアプリがリモート デバイスにアクセスする許可を持っていることを確認してください。 このチェックが失敗する理由の 1 つは、アプリに `remoteSystem` 機能を追加していないことです。

システム ウォッチャーのイベント ハンドラーは、接続可能なデバイスが検出されたとき、または接続できなくなったときに呼び出されます。 これらのイベント ハンドラーを使用して、接続可能なデバイスの一覧を最新に保ちます。

[!code-cs[Main](./code/RemoteLaunchScenario/MainPage.xaml.cs#SnippetEventHandlers)]


**Dictionary** を使って、リモート システム ID によってデバイスを追跡します。 **ObservableCollection** を使って、列挙可能なデバイスの一覧を保持します。 **ObservableCollection** ではデバイスの一覧を UI にバインドすることも簡単にできますが、この例では行いません。

[!code-cs[Main](./code/RemoteLaunchScenario/MainPage.xaml.cs#SnippetMembers)]

リモート アプリの起動を試みる前に、アプリのスタートアップ コードに `BuildDeviceList()` への呼び出しを追加します。

## <a name="launch-an-app-on-a-remote-device"></a>リモート デバイスでのアプリの起動

接続するデバイスを [**RemoteLauncher.LaunchUriAsync**](https://msdn.microsoft.com/library/windows/apps/windows.system.remotelauncher.launchuriasync.aspx) API に渡すことによって、アプリをリモートで起動します。 このメソッドには 3 つのオーバーロードがあります。 この例で示されている最も単純なオーバーロードでは、リモート デバイス上のアプリをアクティブ化する URI を指定します。 この例では、URI によって、リモート コンピューター上のマップ アプリがスペース ニードルの 3D ビューで開かれます。

その他の **RemoteLauncher.LaunchUriAsync** のオーバーロードでは、適切なアプリがリモート デバイスで起動できない場合に参照する Web サイトの URI などのオプションや、リモート デバイスでの URI の起動に使用できるパッケージ ファミリ名のオプションの一覧を指定できます。 キーと値のペアの形式でデータを提供することもできます。 音楽の再生をデバイスから別のデバイスへと切り替えるとき、アクティブ化しているアプリにデータを渡して、再生する曲名や現在の再生位置などのコンテキストをリモート アプリに提供する場合があります。

実際には、使用するデバイスを選ぶための UI を表示するのが普通です。 しかしこの例では単純にするために、一覧の最初のリモート デバイスのみを使います。

[!code-cs[Main](./code/RemoteLaunchScenario/MainPage.xaml.cs#SnippetRemoteUriLaunch)]

**RemoteLauncher.LaunchUriAsync()** から返される [**RemoteLaunchUriStatus**](https://msdn.microsoft.com/library/windows/apps/windows.system.remotelaunchuristatus.aspx) オブジェクトは、リモートの起動が成功したかどうか、さらに、失敗した場合はその理由についての情報を提供します。

## <a name="related-topics"></a>関連トピック

[リモート システムの API リファレンス](https://msdn.microsoft.com/library/windows/apps/Windows.System.RemoteSystems)  
[接続されるアプリやデバイス ("Rome" プロジェクト) の概要](connected-apps-and-devices.md)  
[リモート デバイスの検出](discover-remote-devices.md)  
[リモート システムのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/dev/Samples/RemoteSystems)では、リモート システムを検出する方法、リモート システムでアプリを起動する方法、アプリ サービスを使って 2 つのシステム上で実行しているアプリ間でメッセージを送信する方法が説明されています。
