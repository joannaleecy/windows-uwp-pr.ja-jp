---
author: msatranjr
ms.assetid: 25B18BA5-E584-4537-9F19-BB2C8C52DFE1
title: アプリ機能の宣言
description: 一部の API またはピクチャ、ミュージック、デバイス (カメラ、マイクなど) などのリソースにアクセスするには、機能をユニバーサル Windows プラットフォーム (UWP) アプリのパッケージ マニフェストで宣言する必要があります。
ms.author: misatran
ms.date: 09/20/2018
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 451a8041e0a81d43d91692e92046c32d458e0982
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/29/2018
ms.locfileid: "5755300"
---
# <a name="app-capability-declarations"></a>アプリ機能の宣言

一部の API またはピクチャ、ミュージック、デバイス (カメラ、マイクなど) などのリソースにアクセスするには、機能をユニバーサル Windows プラットフォーム (UWP) アプリの [パッケージ マニフェスト](https://msdn.microsoft.com/library/windows/apps/BR211474) で宣言する必要があります。

特定のリソースまたは API へのアクセスを要求するには、アプリの [パッケージ マニフェスト](https://msdn.microsoft.com/library/windows/apps/BR211474) で機能を宣言します。 一般的な機能は Microsoft Visual Studio の [マニフェスト デザイナー](packaging-uwp-apps.md#configure-an-app-package) で宣言できるほか、パッケージ マニフェストに手動で追加することもできます。 詳しくは、「[パッケージ マニフェストで機能を指定する方法](https://msdn.microsoft.com/library/windows/apps/BR211477)」をご覧ください。 ユーザーがストアからアプリを入手するときに、アプリで宣言されているすべての機能が通知されることを知っておくのは重要です。 アプリに不要な機能を宣言しないでください。

一部の機能では、アプリが*機密性の高いリソース*にアクセスできます。 ユーザーの個人データにアクセスしたり、ユーザーに課金したりできるため、これらのリソースは機密性の高いリソースと見なされます。 設定アプリで管理されるプライバシー設定で、機密性の高いリソースへのアクセスを動的に制御することができます。 したがって、機密性の高いリソースが常に利用できるとアプリで認識されないことが重要です。 機密性の高いリソースへのアクセスについて詳しくは、「[個人データにアクセスするアプリのガイドライン](https://msdn.microsoft.com/library/windows/apps/Hh768223)」をご覧ください。 *機密性の高いリソース*へのアクセス許可をアプリに与える機能は、機能のシナリオの横にアスタリスク (\*) が付いています。

機能のいくつかの種類があります。

- [一般的な用途の機能](#general-use-capabilities)アプリの最も一般的なシナリオに適用します。
- [デバイスの機能](#device-capabilities)アプリが周辺機器と内部デバイスにアクセスできるようにします。
- [制限付き機能](#restricted-capabilities)、Microsoft Store 申請の承認が必要か、通常はのみ Microsoft および特定のパートナーを利用します。
- [カスタムの機能](#custom-capabilities)です。

## <a name="general-use-capabilities"></a>一般的な用途の機能

一般的な用途の機能は、ストア アプリのほとんどのシナリオに適用される機能です。

| 機能のシナリオ | 機能の使用法 |
|---------------------|------------------|
| **音楽**\* | **musicLibrary** 機能は、ユーザーの音楽ライブラリへのプログラムによるアクセスを提供します。これによって、ユーザーの操作なしで、ライブラリ内のすべてのファイルを列挙してそれらのファイルにアクセスできます。 通常、この機能は、音楽ライブラリ全体を利用するジュークボックス アプリで使われます。<br /><br />[**ファイル ピッカー**](https://msdn.microsoft.com/library/windows/apps/BR207847)は、アプリで使うファイルをユーザーが開くことができる強力な UI メカニズムを提供します。 **musicLibrary** 機能を宣言するのは、アプリのシナリオでプログラムによるアクセスが必要であるため、**ファイル ピッカー**では実現できない場合だけにしてください。<br /><br /> アプリのパッケージ マニフェストで宣言するとき、以下に示すように、**musicLibrary** 機能に **uap** 名前空間を含める必要があります。 <table><thead><tr><th>XML</th></tr></thead><tbody><tr><td><pre><code>&lt;Capabilities&gt;&lt;uap:Capability Name="musicLibrary"/&gt;&lt;/Capabilities&gt;</code></pre></td></tr></tbody></table>
| **画像**\* | **picturesLibrary** 機能は、ユーザーの画像へのプログラムによるアクセスを提供します。これによって、ユーザーの操作なしで、ライブラリ内のすべてのファイルを列挙してそれらのファイルにアクセスできます。 通常、この機能は、画像ライブラリ全体を利用する写真再生アプリで使われます。<br /><br />[**ファイル ピッカー**](https://msdn.microsoft.com/library/windows/apps/BR207847)は、アプリで使うファイルをユーザーが開くことができる強力な UI メカニズムを提供します。 **picturesLibrary** 機能を宣言するのは、アプリのシナリオでプログラムによるアクセスが必要であるため、**ファイル ピッカー**では実現できない場合だけにしてください。<br /><br />アプリのパッケージ マニフェストで宣言するとき、以下に示すように、**picturesLibrary** 機能に **uap** 名前空間を含める必要があります。<table><thead><tr><th>XML</th></tr></thead><tbody><tr><td><pre><code>&lt;Capabilities&gt;&lt;uap:Capability Name="picturesLibrary"/&gt;&lt;/Capabilities&gt;</code></pre></td></tr></tbody></table>
| **ビデオ**\* | **videosLibrary** 機能は、ユーザーのビデオへのプログラムによるアクセスを提供します。これによって、ユーザーの操作なしで、ライブラリ内のすべてのファイルを列挙してそれらのファイルにアクセスできます。 通常、この機能は、ビデオ ライブラリ全体を利用するムービー再生アプリで使われます。<br /><br />[**ファイル ピッカー**](https://msdn.microsoft.com/library/windows/apps/BR207847)は、アプリで使うファイルをユーザーが開くことができる強力な UI メカニズムを提供します。 **videosLibrary** 機能を宣言するのは、アプリのシナリオでプログラムによるアクセスが必要であるため、**ファイル ピッカー**では実現できない場合だけにしてください。<br /><br />アプリのパッケージ マニフェストで宣言するとき、以下に示すように、**videosLibrary** 機能に **uap** 名前空間を含める必要があります。<table><thead><tr><th>XML</th></tr></thead><tbody><tr><td><pre><code>&lt;Capabilities&gt;&lt;uap:Capability Name="videosLibrary"/&gt;&lt;/Capabilities&gt;</code></pre></td></tr></tbody></table>
| **リムーバブル記憶域** | **removableStorage** 機能は、パッケージ マニフェストで宣言されたファイルの種類の関連付けに限定された、USB キーや外部ハード ドライブなどのリムーバブル ストレージ上のファイルへのプログラムによるアクセスを提供します。 たとえば、ドキュメント リーダー アプリで .doc ファイルの種類の関連付けを宣言すると、リムーバブル ストレージ デバイス上の .doc ファイルを開くことはできますが、他の種類のファイルを開くことはできません。 ユーザーのリムーバブル ストレージ デバイスにはさまざまな情報が含まれている可能性があり、リムーバブル ストレージにプログラムでアクセスするときは宣言された種類のファイルすべてについて正当な理由が求められるため、この機能を宣言する場合は注意が必要です。<br /><br />ユーザーは、関連付けが宣言されたファイルはアプリで処理されるものと考えます。 そのため、責任を持って処理できないファイルについては、関連付けを宣言しないでください。 [**ファイル ピッカー**](https://msdn.microsoft.com/library/windows/apps/BR207847)は、アプリで使うファイルをユーザーが開くことができる強力な UI メカニズムを提供します。<br /><br />**removableStorage** 機能を宣言するのは、アプリのシナリオでプログラムによるアクセスが必要であるため、[**ファイル ピッカー**](https://msdn.microsoft.com/library/windows/apps/BR207847)では実現できない場合だけにしてください。<br /><br />アプリのパッケージ マニフェストで宣言するとき、以下に示すように、**removableStorage** 機能に **uap** 名前空間を含める必要があります。<table><thead><tr><th>XML</th></tr></thead><tbody><tr><td><pre><code>&lt;Capabilities&gt;&lt;uap:Capability Name="removableStorage"/&gt;&lt;/Capabilities&gt;</code></pre></td></tr></tbody></table>
| **インターネットとパブリック ネットワーク**\* | インターネットとパブリック ネットワークに対するさまざまなレベルのアクセスを提供する機能は 2 つあります。<br /><br />**internetClient** 機能を使うと、アプリはインターネットから着信データを受信できます。 サーバーとして機能することはできません。 ローカル ネットワーク アクセスはありません。<br />**internetClientServer** 機能を使うと、アプリはインターネットから着信データを受信できます。 サーバーとして機能できます。 ローカル ネットワーク アクセスはありません。<br /><br />Web サービス コンポーネントを持つほとんどのアプリで **internetClient** を使います。 着信ネットワーク接続をリッスンする必要があるピア ツー ピア (P2P) シナリオを実現するアプリは **internetClientServer** を使う必要があります。 **internetClientServer** 機能には **internetClient** 機能で提供されるアクセスが含まれるため、**internetClientServer** を指定した場合は **internetClient** を指定する必要はありません。
| **ホーム ネットワークと社内ネットワーク**\* | **privateNetworkClientServer** 機能は、ファイアウォール経由でのホーム ネットワークおよび社内ネットワークへの入力方向および出力方向のアクセスを提供します。 通常、この機能は、ローカル エリア ネットワーク (LAN) 上で通信するゲーム、およびさまざまなローカル デバイスでデータを共有するアプリで使われます。 アプリで **musicLibrary**、**picturesLibrary**、または **videosLibrary** を指定している場合は、ホーム グループ内の対応するライブラリにアクセスするためにこの機能を使う必要はありません。 Windows の場合、この機能はインターネットへのアクセスを提供しません。
| **予定** | **appointments** 機能は、ユーザーの予定ストアへのアクセスを提供します。 この機能によって、同期されたネットワーク アカウントから取得された予定や、予定ストアへの書き込みを行う他のアプリに対する読み取りアクセスが可能になります。 この機能を使うと、アプリで新しいカレンダーを作り、そのカレンダーに予定を書き込むことができます。<br /><br />アプリのパッケージ マニフェストで宣言するとき、以下に示すように、**appointments** 機能に **uap** 名前空間を含める必要があります。<table><thead><tr><th>XML</th></tr></thead><tbody><tr><td><pre><code>&lt;Capabilities&gt;&lt;uap:Capability Name="appointments"/&gt;&lt;/Capabilities&gt;</code></pre></td></tr></tbody></table>
| **連絡先**\* | **contacts** 機能は、さまざまな連絡先ストアからの連絡先が集約されたビューへのアクセスを提供します。 この機能によって、アプリでは、さまざまなネットワークやローカルの連絡先ストアから同期された連絡先に制限付きでアクセスできます (ネットワーク許可規則が適用されます)。<br /><br />アプリのパッケージ マニフェストで宣言するとき、以下に示すように、**contacts** 機能に **uap** 名前空間を含める必要があります。<table><thead><tr><th>XML</th></tr></thead><tbody><tr><td><pre><code>&lt;Capabilities&gt;&lt;uap:Capability Name="contacts"/&gt;&lt;/Capabilities&gt;</code></pre></td></tr></tbody></table>
| **コード生成** | **codeGeneration** 機能を使うと、アプリは JIT が可能になる次の機能にアクセスできます。<br /><br />[**VirtualProtectFromApp**](https://msdn.microsoft.com/library/windows/desktop/Mt169846)<br />[**CreateFileMappingFromApp**](https://msdn.microsoft.com/library/windows/desktop/Hh994453)<br />[**OpenFileMappingFromApp**](https://msdn.microsoft.com/library/windows/desktop/Mt169844)<br />[**MapViewOfFileFromApp**](https://msdn.microsoft.com/library/windows/desktop/Hh994454)
| **AllJoyn** | **allJoyn** 機能を使うと、ネットワーク上の AllJoyn 対応のアプリやデバイスは、相互に検出を行い、対話することができます。<br /><br />[**Windows.Devices.AllJoyn**](https://msdn.microsoft.com/library/windows/apps/Dn894971) 名前空間の API にアクセスするすべてのアプリは、この機能を使う必要があります。
| **通話** | **phoneCall** 機能を使うと、アプリは、デバイスのすべての電話回線にアクセスし、次の機能を実行できます。<br /><br />ユーザーに確認を求めずに、電話回線での通話を実行してシステムのダイヤラーを表示します。<br />電話回線に関連するメタデータへアクセスします。<br />電話回線に関連するトリガーへアクセスします。<br />ユーザーが選んだスパム フィルター アプリで、禁止一覧と呼び出し元の情報を設定し、確認することができます。<br /><br />アプリのパッケージ マニフェストで宣言するとき、以下に示すように、**phoneCall** 機能に **uap** 名前空間を含める必要があります。<table><thead><tr><th>XML</th></tr></thead><tbody><tr><td><pre><code>&lt;Capabilities&gt;&lt;uap:Capability Name="phoneCall"/&gt;&lt;/Capabilities&gt;</code></pre></td></tr></tbody></table><b>phoneCallHistoryPublic</b> 機能を使うと、アプリはデバイス上の電話と一部の VOIP の通話履歴を読み取ることができます。 また、VOIP の通話履歴のエントリを書き込むこともできます。 この機能は、<a href="https://msdn.microsoft.com/library/windows/apps/Dn705931"><b>PhoneCallHistoryStore</b></a> クラスのすべてのメンバーへのアクセスに必要です。
| **通話が録音されているフォルダー**\* | **recordedCallsFolder** デバイス機能を使うと、アプリは通話が録音されているフォルダーにアクセスできます。<br /><br />アプリのパッケージ マニフェストで宣言するとき、以下に示すように、**recordedCallsFolder** 機能に **mobile** 名前空間を含める必要があります。<table><thead><tr><th>XML</th></tr></thead><tbody><tr><td><pre><code>&lt;Capabilities&gt;&lt;mobile:Capability Name="recordedCallsFolder"/&gt;&lt;/Capabilities&gt;</code></pre></td></tr></tbody></table>
| **ユーザー アカウント情報**\* | **userAccountInformation** 機能を使うと、アプリはユーザーの名前と画像にアクセスできるようになります。<br /><br />[**Windows.System.UserProfile**](https://msdn.microsoft.com/library/windows/apps/Windows.System.UserProfile) 名前空間の一部の API にアクセスする場合は、この機能が必要になります。<br /><br />アプリのパッケージ マニフェストで宣言するとき、以下に示すように、**userAccountInformation** 機能に **uap** 名前空間を含める必要があります。<table><thead><tr><th>XML</th></tr></thead><tbody><tr><td><pre><code>&lt;Capabilities&gt;&lt;uap:Capability Name="userAccountInformation"/&gt;&lt;/Capabilities&gt;</code></pre></td></tr></tbody></table>
| **VOIP 呼び出し** | **voipCall** 機能を使うと、アプリは [**Windows.ApplicationModel.Calls**](https://msdn.microsoft.com/library/windows/apps/Dn297266) 名前空間の VOIP 呼び出し API にアクセスできます。<br /><br />アプリのパッケージ マニフェストで宣言するとき、以下に示すように、**voipCall** 機能に **uap** 名前空間を含める必要があります。<table><thead><tr><th>XML</th></tr></thead><tbody><tr><td><pre><code>&lt;Capabilities&gt;&lt;uap:Capability Name="voipCall"/&gt;&lt;/Capabilities&gt;</code></pre></td></tr></tbody></table>
| **3D オブジェクト** | **objects3D** 機能を使用すると、アプリは 3D オブジェクト ファイルにプログラムでアクセスできます。 通常、この機能は、3D オブジェクト ライブラリ全体にアクセスする必要がある 3D アプリやゲームで使用されます。<br /><br />[**Windows.Storage**](https://msdn.microsoft.com/library/windows/apps/BR227346) 名前空間の API を使って 3D オブジェクトを含むフォルダーにアクセスする場合は、この機能が必要になります。<br /><br />アプリのパッケージ マニフェストで宣言するとき、以下に示すように、**objects3D** 機能に **uap** 名前空間を含める必要があります。<table><thead><tr><th>XML</th></tr></thead><tbody><tr><td><pre><code>&lt;Capabilities&gt;&lt;uap:Capability Name="objects3D"/&gt;&lt;/Capabilities&gt;</code></pre></td></tr></tbody></table>
| **ブロックされているメッセージの読み取り**\* | **blockedChatMessages** 機能を使うと、アプリはスパム フィルター アプリでブロックされた SMS メッセージや MMS メッセージを読み取ることができます。<br /><br />[**Windows.ApplicationModel.Chat**](https://msdn.microsoft.com/library/windows/apps/Dn642321) 名前空間の API を使ってブロックされたメッセージにアクセスする場合は、この機能が必要になります。<br /><br />アプリのパッケージ マニフェストで宣言するとき、以下に示すように、**blockedChatMessages** 機能に **uap** 名前空間を含める必要があります。<table><thead><tr><th>XML</th></tr></thead><tbody><tr><td><pre><code>&lt;Capabilities&gt;&lt;uap:Capability Name="blockedChatMessages"/&gt;&lt;/Capabilities&gt;</code></pre></td></tr></tbody></table>
| **カスタム デバイス** | **LowLevelDevices**機能には、さまざまな追加の要件が満たされているカスタム デバイスにアクセスするアプリができます。 この機能は、GPIO、I2C、SPI、および PWM デバイスにアクセスできるように、**ローレベル**デバイス機能と混同しないでください。<br /><br /> 必要な[デバイス インターフェイス](https://docs.microsoft.com/windows-hardware/drivers/install/device-interface-classes)を公開するカスタム ドライバーを開発する場合、このデバイスへのハンドルを開くし、Ioctl を送信します。<ul><li>アプリケーション マニフェストで**lowLevelDevices**機能を有効にします。 <table><thead><tr><th>XML</th></tr></thead><tbody><tr><td><pre><code>&lt;Capabilities&gt;&lt;iot:Capability Name="lowLevelDevices"/&gt;&lt;/Capabilities&gt;</code></pre></td></tr></tbody></table></li><li>[埋め込みモード](https://docs.microsoft.com/windows/iot-core/develop-your-app/EmbeddedMode)を有効にします。</li><li>[制限付き](https://docs.microsoft.com/windows-hardware/drivers/install/devpkey-deviceinterface-restricted)、 [INF](https://msdn.microsoft.com/library/windows/desktop/hh404264(v=vs.85).aspx)またはドライバーの[WdfDeviceAssignInterfaceProperty()](https://docs.microsoft.com/windows-hardware/drivers/ddi/content/wdfdevice/nf-wdfdevice-wdfdeviceassigninterfaceproperty)を呼び出すことによってとしてデバイス インターフェイスをマークします。</ul>  <br /><br />[**Windows.Devices.Custom.CustomDevice**](https://docs.microsoft.com/uwp/api/Windows.Devices.Custom.CustomDevice)を使用して、デバイスへのハンドルを開くをすることができます。 詳細については、[内部のデバイス用の UWP デバイス アプリ](https://docs.microsoft.com/windows-hardware/drivers/devapps/uwp-device-apps-for-specialized-devices)を参照してください。
| **IoT システム管理** | **systemManagement** 機能を使うと、アプリは基本的なシステム管理者特権 (シャットダウン、再起動、ロケール、タイムゾーンなど) を持つことができます。<br /><br />[**Windows.System**](https://msdn.microsoft.com/library/windows/apps/BR241814) 名前空間の一部の API にアクセスする場合は、この機能が必要になります。<br /><br />アプリのパッケージ マニフェストで宣言するとき、以下に示すように、**systemManagement** 機能に **iot** 名前空間を含める必要があります。<table><thead><tr><th>XML</th></tr></thead><tbody><tr><td><pre><code>&lt;Capabilities&gt;&lt;iot:Capability Name="systemManagement"/&gt;&lt;/Capabilities&gt;</code></pre></td></tr></tbody></table>
| **バックグラウンドでのメディアの再生** | **backgroundMediaPlayback** 機能は、[ **MediaPlayer** ](https://msdn.microsoft.com/library/windows/apps/windows.media.playback.mediaplayer.aspx) クラスや [ **AudioGraph** ](https://msdn.microsoft.com/library/windows/apps/windows.media.audio.audiograph.aspx) クラスなど、メディア固有の API の動作を変更して、アプリがバック グラウンドで実行されている間のメディアの再生を有効にします。 アプリがバックグラウンドに移行しても、アクティブなすべてのオーディオ ストリームはミュートせず、音声を発し続けます。 また再生が行われている間はアプリが有効に保たれるように、アプリの有効期間が自動的に延長されます。
| **リモート システム** | **remoteSystem**機能を使うと、アプリがユーザーの Microsoft アカウントに関連付けられているデバイスの一覧にアクセスできるようになります。 デバイスの一覧へのアクセスは、実行した操作を複数のデバイス間で保持するために不可欠です。 この機能は、次の項目のすべてのメンバーにアクセスするために必要です。<br /><br />Windows.System.RemoteSystems 名前空間<br />Windows.System.RemoteLauncher 名前空間<br />AppServiceConnection.OpenRemoteAsync メソッド |
| **空間認知** | **spatialPerception** 機能は、空間マッピング データにプログラムでアクセスし、ユーザーに近い空間内でアプリケーション指定領域のサーフェスに関する情報を Mixed Reality アプリに提供します。  spatialPerception 機能は、これらのサーフェス メッシュをアプリで明示的に使用する場合にのみ宣言してください。ユーザーの頭部姿勢に基づいて Mixed Reality アプリでホログラフィック レンダリングを実行する場合、この機能は必要ありません。 |


## <a name="device-capabilities"></a>デバイス機能

デバイス機能を使用すると、アプリは周辺機器と内部デバイスにアクセスできます。 デバイスの機能を指定するには、アプリのパッケージ マニフェストの **DeviceCapability** 要素を使います。 この要素は追加の子要素を必要とする場合があり、一部のデバイス機能をパッケージ マニフェストに手動で追加する必要があります。 詳しくは、「[パッケージ マニフェストでデバイス機能を指定する方法](https://msdn.microsoft.com/library/windows/apps/Dn263092)」と「[**DeviceCapability スキーマ リファレンス**](https://msdn.microsoft.com/library/windows/apps/BR211430)」をご覧ください。

| 機能のシナリオ | 機能の使用法 |
|---------------------|------------------|
| **位置情報**\* | **location** 機能は、位置情報機能へのアクセスを提供します。この情報は PC が備えている GPS センサーなどの専用ハードウェアや、利用可能なネットワーク情報から取得されます。 アプリは、ユーザーが **[設定]** チャームで位置情報サービスを無効にした場合に対応する必要があります。 |
| **マイク** | **microphone** 機能は、マイクのオーディオ フィードへのアクセスを提供します。これによって、接続されたマイクからオーディオを録音できます。 アプリは、ユーザーが **[設定]** チャームでマイクを無効にした場合に対応する必要があります。 |
| **近接** | **proximity** 機能を使うと、きわめて近い場所にある複数のデバイスが相互に通信できます。 通常、この機能は、カジュアルなマルチプレーヤー ゲームや情報を交換するアプリで使われます。 デバイスは、Bluetooth、Wi-Fi、インターネットを含む、最適な接続を提供する通信テクノロジを使います。 この機能は、デバイス間の通信を開始するためにのみ使われます。 |
| **Webcam** | **webcam** 機能は、内蔵カメラや外付け Web カメラのビデオ フィードへのアクセスを提供します。これによって、アプリで写真やビデオをキャプチャできます。 Windows の場合、アプリはユーザーが **[設定]** チャームでカメラを無効にした場合に対応する必要があります。<br/>**webcam** 機能では、ビデオ ストリームへのアクセスだけが許可されます。 オーディオ ストリームへのアクセスも許可するには、**microphone** 機能を追加する必要があります。 |
| **USB** | **usb** デバイス機能を使うと、「[USB デバイスのアプリ マニフェスト パッケージの更新](http://go.microsoft.com/fwlink/p/?LinkId=302259)」で API にアクセスできます。 |
| **ヒューマン インターフェイス デバイス (HID)** | **humaninterfacedevice** デバイス機能を使うと、「[HID のデバイス機能を指定する方法](https://msdn.microsoft.com/library/windows/apps/Dn263091)」の API にアクセスできます。 |
| **Point of Service (POS)** | **pointOfService** デバイス機能を使うと、[**Windows.Devices.PointOfService**](https://msdn.microsoft.com/library/windows/apps/Dn298071) 名前空間の API にアクセスできます。 この名前空間により、アプリは、Point of Service (POS) バー コード スキャナーや磁気ストライプ リーダーにアクセスできます。 この名前空間は、さまざまな製造元の POS デバイスに UWP アプリからアクセスするための、ベンダーに依存しないインターフェイスを提供します。 |
| **Bluetooth** | **bluetooth** デバイス機能を使うと、アプリは Generic Attribute (GATT) または Classic Basic Rate (RFCOMM) プロトコル経由で既にペアリングされている Bluetooth デバイスと通信できます。<br/>[**Windows.Devices.Bluetooth**](https://msdn.microsoft.com/library/windows/apps/Dn263413) 名前空間の一部の API を使う場合は、この機能が必要になります。 |
| **Wi-Fi ネットワーク** | **wiFiControl** デバイス機能を使うと、アプリはスキャンを実行して、Wi-Fi ネットワークに接続することができます。<br/>[**Windows.Devices.WiFi**](https://msdn.microsoft.com/library/windows/apps/Dn975224) 名前空間の一部の API を使う場合は、この機能が必要になります。 |
| **無線状態** | **radios** デバイス機能を使うと、アプリは Wi-Fi 通信と Bluetooth 通信を切り替えることができます。<br/>[**Windows.Devices.Radios**](https://msdn.microsoft.com/library/windows/apps/Dn996447) 名前空間の API を使う場合は、この機能が必要になります。  |
| **光学式ディスク** | **optical** デバイス機能を使うと、アプリは、CD、DVD、ブルーレイなどの光ディスク ドライブの機能にアクセスできます。<br/>[**Windows.Devices.Custom**](https://msdn.microsoft.com/library/windows/apps/Dn263667) 名前空間の一部の API を使う場合は、この機能が必要になります。 |
| **モーション アクティビティ** | デバイス機能 **activity** を使うと、アプリはデバイスの現在の動きを検出できるようになります。<br/>[**Windows.Devices.Sensors**](https://msdn.microsoft.com/library/windows/apps/BR206408) 名前空間の一部の API を使う場合は、この機能が必要になります。 |
| **シリアル通信** | **serialcommunication** デバイス機能では Windows.Devices.SerialCommunication 名前空間の API へのアクセスが提供され、Windows アプリはシリアル ポートまたはシリアル ポートのアブストラクションを公開するデバイスと通信できるようになります。 [**Windows.Devices.SerialCommnication**](https://docs.microsoft.com/uwp/api/windows.devices.serialcommunication) 名前空間の API を使う場合は、この機能が必要になります。 |
| **アイ トラッカー** | **gazeInput** 機能を使うと、互換性のある視線追跡デバイスが接続されているときにユーザーがアプリケーション境界内で見ている場所を検出できます。 [**Windows.Devices.Input.Preview**](https://docs.microsoft.com/en-us/uwp/api/windows.devices.input.preview)名前空間の一部の Api を使用するには、この機能が必要です。 |
| **GPIO、I2C、SPI、およびできるようになります** | **ローレベル**デバイスの機能は、GPIO、I2C、SPI、および PWM デバイスへのアクセスを提供します。 この機能は、次の名前空間で Api を使用するために必要です。 [**Windows.Devices.Gpio**](https://docs.microsoft.com/uwp/api/windows.devices.gpio)、 [**Windows.Devices.I2c**](https://docs.microsoft.com/uwp/api/windows.devices.i2c)、 [**Windows.Devices.Spi**](https://docs.microsoft.com/uwp/api/windows.devices.spi)、[**Windows.Devices.Pwm**](https://docs.microsoft.com/uwp/api/windows.devices.pwm)します。 <table><thead><tr><th>XML</th></tr></thead><tbody><tr><td><pre><code>&lt;Capabilities&gt;&lt;DeviceCapability Name="lowLevel"/&gt;&lt;/Capabilities&gt;</code></pre></td></tr></tbody></table>|


<span id="special-and-restricted-capabilities" />

## <a name="restricted-capabilities"></a>制限付き機能

アプリでは、任意の制限付き機能を宣言する場合は、承認を受けるアプリを Microsoft Store に公開するために、[アプリの申請プロセス](../publish/app-submissions.md)中に情報を提供する必要があります。 この情報は、アプリがそれを宣言する各制限付き機能を使用する方法を説明する、申請の[申請オプション](../publish/manage-submission-options.md#restricted-capabilities)] ページで提供します。

> [!IMPORTANT]
> 制限付き機能は、非常に特定のシナリオを意図しています。 これらの機能は、用途が厳格に制限されており、ストアへの登録に際して追加のポリシーやレビューが適用されます。 任意の承認を受けることがなく、制限付き機能を宣言するアプリのサイドローディングことに注意してください。 承認は、これらのアプリを App Store に提出するときのみ必要です。

必ず、アプリで本当に必要ない限りこれら制限付き機能を宣言しないようにします。 これらの機能が必要で適しているものとしては、身元を証明するデジタル証明書をスマート カードに含めるようにユーザーに求める 2 要素認証を使ったバンキング アプリなどがあります。 また、主に企業ユーザー向けに設計されたアプリや、ユーザーのドメイン資格情報がないとアクセスできな企業リソースへのアクセスを必要とするアプリもあります。

制限付き機能を宣言する[アプリ パッケージ マニフェスト](https://msdn.microsoft.com/library/windows/apps/BR211474)ソース ファイルを変更します (`Package.appxmanifest`)。 **Xmlns:rescap** XML 名前空間の宣言を追加し、制限付き機能を宣言するときに、 **rescap**プレフィックスを使用します。 たとえば、**appCaptureSettings** 機能を宣言する方法を次に示します。

```xml
<?xml version="1.0" encoding="utf-8"?>
<Package
    ...
    xmlns:rescap="http://schemas.microsoft.com/appx/manifest/foundation/windows10/restrictedcapabilities"
    IgnorableNamespaces="... rescap">
...
<Capabilities>
    <rescap:Capability Name="appCaptureSettings"/>
</Capabilities>
</Package>
```

### <a name="restricted-capability-approval-process"></a>制限付き機能の承認プロセス

以前は、機能を使う承認を得るためにサポートに問い合わせる必要がありました。 現在では、[申請プロセス](../publish/app-submissions.md)の一部としてデベロッパー センター ダッシュボードでこの情報を提供できるようになりました。

申請のパッケージをアップロードするとき、制限付き機能が宣言されているかどうかが検出されます。 検出された場合、製品で各機能が使用されているかどうかに関する詳しい情報を[申請オプション](../publish/manage-submission-options.md#restricted-capabilities)ページで提供する必要があります。 製品が機能を宣言する必要がある理由を理解できるように、必ずできる限り詳しく入力してください。 これにより、申請が認定プロセスを完了するまでの時間がいくらか長くなる可能性があります。

認定プロセス中、テスターが提供された情報を確認し、その申請で機能の使用を承認するかどうかを判断します。 これにより、申請が認定プロセスを完了するまでの時間がいくらか長くなる可能性があります。 機能の使用が承認された場合、アプリの認定プロセスの残りの部分が続行されます。 一般に、アプリの更新プログラムを申請するときに機能の承認プロセスを繰り返す必要はありません (追加の機能を宣言する場合を除く)。

機能の使用が承認されない、申請は認定に失敗し、認定レポートでフィードバックが提供されます。 その後、新しい申請を作成して機能を宣言しないパッケージをアップロードすることを選択できます。または、該当する場合は、機能の使用に関連する問題を解決し、新しい申請で承認をリクエストします。

> [!NOTE]
> 申請でデベロッパー センターの開発サンドボックスを使う場合 (たとえば、Xbox Live と統合されるゲームがこれに該当します)、**申請オプション** ページで情報を提供するのではなく事前に承認をリクエストする必要があります。 このためには、[Windows 開発者向けサポート ページ](https://developer.microsoft.com/windows/support)にアクセスしてください。 開発者向けサポート トピック**ダッシュ ボードの問題**問題の種類として**アプリの申請**、およびサブカテゴリ**他**を選択します。 その機能を使用している方法と、製品の必要がある理由を説明します。 必要情報がすべて記載されていない場合、要求が拒否されます。 また別途、追加情報の提供を求められることがあります。 このプロセスには通常 5 営業日以上かかるため、十分前もってリクエストを送信してください。
>
> 承認を要求するには、このメソッドを使用することもできます (のではなく、申請時にこの情報を提供します)、かどうかを使用している、開発サンド ボックスを開始する前に、制限付き機能を使う承認されていることを確認する場合は、申請します。

<span id="restricted-and-special-use-capability-list" />

### <a name="restricted-capability-list"></a>制限付き機能の一覧

次の表では、制限付き機能を示します。 上記で説明したプロセスに従うことによって、Microsoft Store に提出するアプリでこれらの機能の承認をリクエストすることができます。

> [!IMPORTANT]
> かなり限定された状況を除き、一部の制限付き機能が Microsoft Store に提出されるアプリで承認されることはほとんどありません。 これらの機能は、次の表で言及されています。 Microsoft Store で配布する予定の場合、アプリでこれらの機能を宣言しないことをお勧めします。

| 機能のシナリオ | 機能の使用法 |
|---------------------|------------------|
| **エンタープライズ** | Windows ドメイン資格情報により、ユーザーはそれぞれの資格情報を使ってリモートのリソースにログインし、ユーザー名とパスワードを指定したかのように動作できます。 **EnterpriseAuthentication**機能は通常、企業内のサーバーに接続する基幹業務アプリで使われます。 <br /><br />インターネット上での汎用通信にはこの機能は不要です。<br /><br />**EnterpriseAuthentication**機能は、一般的な基幹業務アプリをサポートするものです。 企業リソースにアクセスする必要がないアプリでは宣言しないでください。 [**ファイル ピッカー**](https://msdn.microsoft.com/library/windows/apps/BR207847) は、アプリで使うネットワーク共有上のファイルをユーザーが開くことができる強力な UI メカニズムを提供します。 プログラムによるアクセスを必要とするアプリのシナリオと、**ファイル ピッカー**を使って実現できない場合にのみ、 **enterpriseAuthentication**機能を宣言します。<br /><br />アプリのパッケージ マニフェストで宣言するとき、以下に示すように、**enterpriseAuthentication** 機能に **uap** 名前空間を含める必要があります。<br /><br />```<Capabilities><uap:Capability Name="enterpriseAuthentication"/></Capabilities>```<br /><br />**EnterpriseDataPolicy**機能により、アプリに企業データを個別に処理し、アプリが Windows 情報保護ポリシーを使って管理されているときに安全に (例: モバイル デバイス管理およびモバイル アプリケーション管理システム)。  次に示すように、この制限付き機能を宣言します。 <br /><br />```<Capabilities><rescap:Capability Name="enterpriseDataPolicy"/></Capabilities>```<br /><br />この機能は、次のクラスのすべてのメンバーを使うために必要です。<ul><li><a href="https://msdn.microsoft.com/library/windows/apps/Dn705151">FileProtectionManager</a></li><li><a href="https://msdn.microsoft.com/library/windows/apps/Dn706017">DataProtectionManager</a></li><li><a href="https://msdn.microsoft.com/library/windows/apps/Dn705170">ProtectionPolicyManager</a></li></ul> |
| **ユーザー証明書の共有** | **SharedUserCertificates**機能により、アプリを追加し、ソフトウェアにアクセスし、ハードウェア ベースの共有ユーザー ストアに証明書、スマート カードに格納されている証明書などです。 通常、この機能は、認証にスマート カードを必要とする財務アプリまたはエンタープライズ アプリで使われます。<br /><br />アプリのパッケージ マニフェストで宣言するとき、以下に示すように、**sharedUserCertificates** 機能に **uap** 名前空間を含める必要があります。<br /><br />```<Capabilities><uap:Capability Name="sharedUserCertificates"/></Capabilities>``` |
|**ドキュメント**\* | **DocumentsLibrary**機能は、ファイルの種類の関連付けに限定、パッケージ マニフェストで宣言されている OneDrive へのオフライン アクセスをサポートするために、ユーザーのドキュメントへのプログラムによるアクセスを提供します。 たとえば、DOC リーダー アプリで .doc ファイルの種類の関連付けを宣言すると、ドキュメント フォルダー内の .doc ファイルを開くことはできますが、他の種類のファイルを開くことはできません。 <br /><br />**DocumentsLibrary**機能を宣言するアプリは、ホーム グループ コンピューター上のドキュメントにアクセスできません。 [ファイル ピッカー](https://msdn.microsoft.com/library/windows/apps/Hh465174)は、アプリで使うファイルをユーザーが開くことができる強力な UI メカニズムを提供します。 ファイル ピッカーを使えない場合にのみ、 **documentsLibrary**機能を宣言します。<br /><br />**DocumentsLibrary**機能を使用して、アプリが必要です。<ul><li>有効な OneDrive URL またはリソース ID を使った、特定の OneDrive コンテンツへのクロスプラットフォーム オフライン アクセスを容易にする</li><li>オフライン時に、開いているファイルをユーザーの OneDrive に自動的に保存する</li></ul>必要に応じてこれら 2 つの目的上、 **documentsLibrary**機能を使用するアプリは、機能を使用して、別のドキュメント内の埋め込みのコンテンツを開く可能性があります。 **DocumentsLibrary**機能の上記の使用のみが受け入れられます。<ul><li>アプリは、電話の内部ストレージにあるドキュメント ライブラリにはアクセスできません。 ただし、別のアプリによってオプションの SD カード上にドキュメント フォルダーが作られた場合は、アプリでそのフォルダーを表示できます。</li></ul>アプリのパッケージ マニフェストで宣言するとき、以下に示すように、**documentsLibrary** 機能に **uap** 名前空間を含める必要があります。<br /><br />```<Capabilities><uap:Capability Name="documentsLibrary"/></Capabilities>``` |
| **ゲーム DVR 設定** | 制限された機能 **appCaptureSettings** を使うと、アプリはゲーム DVR のユーザー設定を制御できます。<br /><br />[**Windows.Media.Capture**](https://msdn.microsoft.com/library/windows/apps/BR226738) 名前空間の一部の API を使う場合は、この機能が必要になります。 <br /><br />Microsoft Store に提出するアプリでこの機能を宣言することはお勧めしません。 ほとんどの開発者の方は、この機能の使用が承認されません。  |
| **Cellular** | 制限された機能 **cellularDeviceControl** を使うと、アプリは携帯デバイスを制御できます。<br /><br />**cellularDeviceIdentity** 機能を使うと、アプリは携帯デバイスの ID データにアクセスできます。<br /><br />**cellularMessaging** 機能を使うと、アプリは SMS と RCS を利用できます。<br /><br />[**Windows.Devices.Sms**](https://msdn.microsoft.com/library/windows/apps/BR206567) 名前空間の一部の API を使う場合は、これらの機能が必要になります。  |
| **デバイスのロック解除** | 制限付き機能 **deviceUnlock** を使うと、アプリは、開発者サイドローディングのシナリオやエンタープライズ サイドローディングのシナリオ向けにデバイスをロック解除できます。<br /><br /> Microsoft Store に提出するアプリでこの機能を宣言することはお勧めしません。 ほとんどの開発者の方は、この機能の使用が承認されません。 |
| **デュアル SIM タイル** | 制限された機能 **dualSimTiles** を使うと、アプリは、複数の SIM を備えたデバイスでアプリ一覧の追加のエントリを作成できます。<br /><br />[**Windows.UI.StartScreen**](https://msdn.microsoft.com/library/windows/apps/BR242235) 名前空間の一部の API を使う場合は、この機能が必要になります。 |
| **エンタープライズ共有記憶域** | 制限付き機能 **enterpriseDeviceLockdown** を使うと、アプリは、デバイスのロック ダウン API を利用したり、企業で共有している保存フォルダーにアクセスしたりすることができます。 <br /><br />Microsoft Store に提出するアプリでこの機能を宣言することはお勧めしません。 ほとんどの開発者の方は、この機能の使用が承認されません。 |
| **システム入力の挿入** | **InputInjectionBrokered**制限付き機能には、プログラムでさまざまな形式の HID、タッチ、ペン、キーボード、マウス、システムになどの入力を挿入するアプリができます。 通常、この機能はシステムを制御できる共同作業アプリで使われます。<br /><br />PC の場合、この機能を使ったアプリからの入力の挿入は、同じアプリ コンテナー内のプロセスによってのみ許可されます。<br /><br />```<Capabilities><rescap:Capability Name="inputInjectionBrokered" /></Capabilities>``` |
| **入力の監視**\* | 制限された機能 **inputObservation** を使うと、アプリは、さまざまな形式の未加工入力 (HID、タッチ、ペン、キーボード、マウスなど) が、最終的な宛先に関係なく、システムによって許可されるのを監視できます。  |
| **入力の抑制** | 制限された機能 **inputSuppression** を使うと、アプリは、さまざまな形式の未加工入力 (HID、タッチ、ペン、キーボード、マウスなど) が、システムによって許可されるのを抑制できます。
| **VPN アプリ** | 制限された機能 **networkingVpnProvider** を使うと、アプリは VPN 機能 (接続の管理や VPN プラグイン機能の提供など) へのフル アクセスが可能になります。<br /><br />[**Windows.Networking.Vpn**](https://msdn.microsoft.com/library/windows/apps/Dn434040) 名前空間の一部の API を使う場合は、この機能が必要になります。 |
| **他のアプリの管理** | 制限された機能 **packageManagement** を使うと、アプリは他のアプリを直接管理できます。<br /><br />**packageQuery** デバイス機能を使うと、アプリは他のアプリに関する情報を収集できます。<br /><br />[**PackageManager**](https://msdn.microsoft.com/library/windows/apps/BR240960) クラスの一部のメソッドとプロパティにアクセスする場合は、これらの機能が必要になります。 |
| **画面の投影** | 制限された機能 **screenDuplication** を使うと、アプリは画面を別のデバイスに表示できます。<br /><br />DirectX 名前空間の API を使う場合は、この機能が必要になります。 <br /><br />Microsoft Store に提出するアプリでこの機能を宣言することはお勧めしません。 ほとんどの開発者の方は、この機能の使用が承認されません。 |
| **ユーザー プリンシパル名** | 制限された機能 **userPrincipalName** を使うと、アプリは、写真に基づく縮小表示のキャッシュを変更したり、このキャッシュにアクセスしたりすることができます。<br /><br />[**GetUserNameEx**](https://msdn.microsoft.com/library/windows/desktop/ms724435) 関数を呼び出す場合は、この機能が必要になります。 <br /><br />Microsoft Store に提出するアプリでこの機能を宣言することはお勧めしません。 ほとんどの開発者の方は、この機能の使用が承認されません。 |
| **ウォレット** | 制限された機能 **walletSystem** を使うと、アプリは保存されたウォレット カードへのフル アクセスが可能になります。<br /><br />[**Windows.ApplicationModel.Wallet.System**](https://msdn.microsoft.com/library/windows/apps/Mt171610) 名前空間の API を使う場合は、この機能が必要になります。 <br /><br />Microsoft Store に提出するアプリでこの機能を宣言することはお勧めしません。 ほとんどの開発者の方は、この機能の使用が承認されません。 |
| **位置情報の履歴** | 制限された機能 **locationHistory** を使うと、アプリはデバイスの位置情報の履歴にアクセスできます。<br /><br />[**Windows.Devices.Geolocation**](https://msdn.microsoft.com/library/windows/apps/BR225603) 名前空間の API を使う場合は、この機能が必要になります。
| **アプリを閉じる確認** | 制限付き機能 **confirmAppClose** を使うと、アプリはアプリ自体とアプリ独自のウィンドウを閉じたり、アプリを閉じることを遅延させたりすることができます。<br /><br />アプリは、Windows 10 Version 1703 (ビルド 10.0.15063) 以上でこの機能を要求できます。 以前の Windows 10 バージョンでは、この機能はプライベートであり、"このアプリケーションには、要求された機能を許可できません" というエラー メッセージでアプリのインストールが失敗になります。 |
| **通話履歴**\* | 制限付き機能 **phoneCallHistory** を使うと、アプリは通話履歴を読み取ったり、履歴のエントリを削除できます。<br /><br />[**Windows.ApplicationModel.Chat**](https://msdn.microsoft.com/library/windows/apps/Dn642321) 名前空間の API を使う場合は、この機能が必要になります。 <br /><br />Microsoft Store に提出するアプリでこの機能を宣言することはお勧めしません。 ほとんどの開発者の方は、この機能の使用が承認されません。 |
| **システム レベルの予定へのアクセス** | 制限された機能 **appointmentsSystem** を使うと、アプリはユーザーのカレンダーにあるすべての予定を読み取ったり、変更したりすることができます。<br /><br />[**Windows.ApplicationModel.Appointment**](https://msdn.microsoft.com/library/windows/apps/Dn263359) 名前空間の API を使う場合は、この機能が必要になります。 <br /><br />Microsoft Store に提出するアプリでこの機能を宣言することはお勧めしません。 ほとんどの開発者の方は、この機能の使用が承認されません。 |
| **システム レベルのチャット メッセージへのアクセス**\* | 制限付き機能 **chatSystem** を使うと、アプリはすべての SMS メッセージと MMS メッセージの読み取りと書き込みを実行できます。<br />[**Windows.ApplicationModel.Chat**](https://msdn.microsoft.com/library/windows/apps/Dn642321) 名前空間の API を使う場合は、この機能が必要になります。 <br /><br />Microsoft Store に提出するアプリでこの機能を宣言することはお勧めしません。 ほとんどの開発者の方は、この機能の使用が承認されません。 |
| **システム レベルの連絡先へのアクセス** | 制限された機能 **contactsSystem** を使うと、アプリは制限付きの連絡先情報や機密性の高い連絡先情報を読み取ったり、既存の連絡先情報を変更したりすることができます。<br /><br />[**Windows.ApplicationModel.Chat**](https://msdn.microsoft.com/library/windows/apps/Dn642321) 名前空間の API を使う場合は、この機能が必要になります。 <br /><br />Microsoft Store に提出するアプリでこの機能を宣言することはお勧めしません。 ほとんどの開発者の方は、この機能の使用が承認されません。 |
| **メールへのアクセス*** | 制限付き機能 **email** を使うと、アプリはユーザーのメールの読み取り、トリアージ、送信を実行できます。<br /><br />[**Windows.ApplicationModel.Email**](https://msdn.microsoft.com/library/windows/apps/Dn631285) 名前空間の API を使う場合は、この機能が必要になります。 <br /><br />Microsoft Store に提出するアプリでこの機能を宣言することはお勧めしません。 ほとんどの開発者の方は、この機能の使用が承認されません。 |
| **システム レベルのメールへのアクセス**| 制限された機能 **emailSystem** を使うと、アプリは制限つきのユーザーのメールや機密性の高いユーザーのメールの読み取り、トリアージ、送信を実行できます。 <br /><br />[**Windows.ApplicationModel.Email**](https://msdn.microsoft.com/library/windows/apps/Dn631285) 名前空間の API を使う場合は、この機能が必要になります。 <br /><br />Microsoft Store に提出するアプリでこの機能を宣言することはお勧めしません。 ほとんどの開発者の方は、この機能の使用が承認されません。 |
| **システム レベルの通話履歴へのアクセス** | 制限された機能 **phoneCallHistorySystem** を使うと、アプリは通話履歴を完全に変更できます (既存のエントリの変更や新しいエントリの作成など)。<br /><br />[**Windows.ApplicationModel.Calls**](https://msdn.microsoft.com/library/windows/apps/Dn297266) 名前空間の API を使う場合は、この機能が必要になります。 <br /><br />Microsoft Store に提出するアプリでこの機能を宣言することはお勧めしません。 ほとんどの開発者の方は、この機能の使用が承認されません。 |
| **テキスト メッセージの送信**\* | 制限付き機能 **smsSend** を使うと、アプリは SMS メッセージや MMS メッセージを送信できます。<br /><br />[**Windows.ApplicationModel.Chat**](https://msdn.microsoft.com/library/windows/apps/Dn642321) 名前空間の API を使う場合は、この機能が必要になります。 |
| **システム レベルのすべてのユーザー データへのアクセス** | 制限付き機能 **userDataSystem** を使うと、アプリはシステム データ ストアに保存されているユーザー データへのアクセスが可能になります。 <br /><br />Microsoft Store に提出するアプリでこの機能を宣言することはお勧めしません。 ほとんどの開発者の方は、この機能の使用が承認されません。 |
| **Microsoft Store プレビュー機能** | 制限された機能 **previewStore** を使うと、アプリはアプリ内製品の SKU の取得や購入ができます。<br /><br />[**Windows.ApplicationModel.Store.Preview**](https://msdn.microsoft.com/library/windows/apps/Mt185546) 名前空間の特定の API を使う場合は、この機能が必要になります。 |
| **初回サインイン時の設定** | 制限された機能 **firstSignInSettings** を使うと、アプリは、ユーザーが初めてデバイスにサインインしたときに設定されたユーザー設定にアクセスできます。 |
| **Windows チーム エクスペリエンス** | 制限された機能 **teamEditionExperience** を使うと、アプリは、Windows チーム セッションの多くの経験的側面を制御する内部 API にアクセスできます。 Windows チーム セッションは、Microsoft Surface Hub など、チーム デバイスで実行されている可能性があります。 <br /><br />Microsoft Store に提出するアプリでこの機能を宣言することはお勧めしません。 ほとんどの開発者の方は、この機能の使用が承認されません。 |
| **リモート ロック解除** | 制限付き機能 **remotePassportAuthentication** を使うと、アプリは、リモート PC のロック解除に使用される資格情報にアクセスできます。 <br /><br />Microsoft Store に提出するアプリでこの機能を宣言することはお勧めしません。 ほとんどの開発者の方は、この機能の使用が承認されません。 |
| **コンポジションのプレビュー** | 制限された機能 **previewUiComposition** を使うと、アプリはユーザー インターフェイスの [**Windows.UI.Composition**](https://msdn.microsoft.com/library/windows/apps/Dn706878) 名前空間をプレビューすることで、完成前に API に関するフィードバックを提供できます。 詳細については、wincomposition@microsoft.com にお問い合わせください。 |
| **安全な評価のためのロックダウン** | 制限付き機能 **secureAssessment** を使うと、アプリは安全な評価のために単一アプリ モードに Windows をロックダウンできます。 <br /><br />Microsoft Store に提出するアプリでこの機能を宣言することはお勧めしません。 ほとんどの開発者の方は、この機能の使用が承認されません。 |
| **接続マネージャーのプロビジョニング** | 制限された機能 **networkConnectionManagerProvisioning** を使うと、アプリは、デバイスを WWAN および WLAN インターフェイスに接続するポリシーを定義できます。 この機能を使うアプリは、携帯電話会社が作成し、モバイル ネットワークへのデバイス接続を管理します。 |
| **データ通信プランのプロビジョニング** | 制限された機能 **networkDataPlanProvisioning** を使うと、アプリは、デバイスのデータ プランに関する情報を収集し、ネットワーク使用状況を読み取れます。 この機能を使うアプリは、携帯電話会社が作成し、ユーザーの実際のデータ使用量を OS データ使用量の設定に統合します。 |
| **ソフトウェア ライセンス** | 制限付き機能 **slapiQueryLicenseValue** を使うと、アプリは、ソフトウェア ライセンス ポリシーにクエリを実行できます。 <br /><br />Microsoft Store に提出するアプリでこの機能を宣言することはお勧めしません。 ほとんどの開発者の方は、この機能の使用が承認されません。 |
| **延長実行** | 制限付き機能 **extendedBackgroundTaskTime** を使うと、バックグラウンド タスクが実行時間制限によって取り消されたり停止されたりすることがなくなります。 ただし、この場合も、他のメモリ使用制限や電力使用制限は、すべてバックグラウンド タスクに適用されます。 この機能は、バッテリーの使用やプライバシーなどのバックグラウンド アプリ設定を使用して制限できます。 ユーザーと管理者がグループ ポリシー設定を使うとバックグラウンド タスクを制御できる点に注意してください。<br /><br />制限付き機能 **extendedExecutionBackgroundAudio** を使うと、アプリがフォアグラウンドにないとき、アプリはオーディオを再生できます。<br /><br />制限された機能 **extendedExecutionCritical** を使うと、アプリは重要な延長実行セッションを開始できます。<br /><br />制限付き機能 **extendedExecutionUnconstrained** を使うと、アプリは制限のない延長実行セッションを開始できます。 <br /><br />Microsoft Store に提出するアプリでこの機能を宣言することはお勧めしません。 ほとんどの開発者の方は、この機能の使用が承認されません。<br /><br />延長実行を使用してアプリが中断されるタイミングを延期する方法については、「[延長実行を使ってアプリの中断を延期する](https://docs.microsoft.com/windows/uwp/launch-resume/run-minimized-with-extended-execution)」をご覧ください。 |
| **モバイル デバイス管理** | 制限された機能 **deviceManagementDmAccount** を使うと、アプリは、携帯電話会社の Open Mobile Alliance - Device Management (MO OMA-DM) アカウントをプロビジョニング、構成できます。<br /><br />制限された機能 **deviceManagementFoundation** を使うと、アプリは、デバイスのモバイル デバイス管理 (MDM) 構成サービス プロバイダー (CSP) インフラストラクチャへの基本的なアクセスが可能になります。 他の機能は、特定の CSP にアクセスする必要があることに注意してください。<br /><br />制限された機能 **deviceManagementWapSecurityPolicies** を使うと、アプリは、ワイヤレス アプリケーション プロトコル (WAP) ベースのサービス (MM、Service Indication/Service Loading (SI/SL)、Open Mobile Alliance - Client Provisioning (OMA-CP) など) を構成できます。<br /><br />制限された機能 **deviceManagementEmailAccount** を使うと、携帯電話会社が作成したアプリは、ユーザーにプロビジョニングするデバイス上の電子メール アカウントを追加および管理できます。 |
| **パッケージ ポリシー制御** | 制限付き機能 **packagePolicySystem** を使うと、アプリは、デバイスにインストールされたアプリに関連するシステム ポリシーを制御できます。<br /><br />Microsoft Store に提出するアプリでこの機能を宣言することはお勧めしません。 ほとんどの開発者の方は、この機能の使用が承認されません。 |
| **ゲームの一覧** | 制限付き機能 **gameList** を使うと、アプリはシステムにインストールされた既知のゲームの一覧を取得できます。<br /><br />Microsoft Store に提出するアプリでこの機能を宣言することはお勧めしません。 ほとんどの開発者の方は、この機能の使用が承認されません。 |
| **Xbox アクセサリ** | 制限付き機能 **xboxAccessoryManagement** を使うと、アプリは Xbox ハードウェア仕様に準拠した Xbox デバイスを直接管理できます。<br /><br />Microsoft Store に提出するアプリでこの機能を宣言することはお勧めしません。 ほとんどの開発者の方は、この機能の使用が承認されません。 |
| **アクセサリの音声認識** | 制限付き機能 **cortanaSpeechAccessory** を使うと、アプリはコマンドを呼び出して Cortana に渡すことができます。<br /><br />Microsoft Store に提出するアプリでこの機能を宣言することはお勧めしません。 ほとんどの開発者の方は、この機能の使用が承認されません。 |
| **アクセサリ管理** | 制限された機能 **accessoryManager** を使うと、アプリはアクセサリ アプリや特定のアプリ通知のオプトインとしての登録が可能になり、アクセサリに転送したり、ユーザーに表示したりできるようになります。 |
| **ドライバー アクセス** | 制限付き機能 **interopServices** を使うと、アプリはデバイスと直接やり取りできます。 <br /><br />Microsoft Store に提出するアプリでこの機能を宣言することはお勧めしません。 ほとんどの開発者の方は、この機能の使用が承認されません。 |
| **フォアグラウンドの監視** | 制限された機能 **inputForegroundObservation** を使うと、アプリはフォアグラウンドでキーボード入力を傍受でき、アプリ以外へのすべてのキーボード入力の処理を省くことができます。 SAS の組み合わせはこの機能により傍受することはできません。 この機能は、[**KeyboardDeliveryInterceptor**](https://msdn.microsoft.com/library/windows/apps/Mt608395) クラスのメンバーにアクセスするために必要です。
| **OEM および MO のパートナー アプリ** | 制限された機能 **oemDeployment** を使うと、Microsoft パートナー製のアプリは、新しいアプリをインストールし、デバイスに現在インストールされているアプリを照会できます。<br /><br />制限付き機能 **oemPublicDirectory** を使うと、Microsoft パートナー製のアプリは、共有アプリ フォルダーにアクセスできます。 Microsoft Store に提出するアプリでこの機能を宣言することはお勧めしません。 ほとんどの開発者の方は、この機能の使用が承認されません。 |
| **アプリのライセンス** | 制限された機能 **appLicensing** を使うと、ライセンスの必要なくアプリを実行できます。 マニフェストにこの機能を宣言している場合、Microsoft Store にアプリを提出することはできません。 <br /><br />Microsoft Store に提出するアプリでこの機能を宣言することはお勧めしません。 ほとんどの開発者の方は、この機能の使用が承認されません。 |
| **場所システム**| 制限付き機能 **locationSystem** を使うと、アプリは特権のある特定の場所の構成 (デバイスの既定の場所の設定など) を実行できます。 <br /><br />Microsoft Store に提出するアプリでこの機能を宣言することはお勧めしません。 ほとんどの開発者の方は、この機能の使用が承認されません。 |
| **ユーザー データ アカウント プロバイダー**| 制限付き機能 **userDataAccountsProvider** を使うと、アプリはメール、カレンダー、連絡先のアカウントを完全に管理できます。 |
| **ペン ワークスペース** | **previewPenWorkspace** 機能を使うと、アプリは、ペン ワークスペースの内側でアクション記憶ハンドラとしてホストされる Windows.ApplicationModel.Preview.Notes 名前空間にアクセスできます。 |
| **2 要素認証** | **secondaryAuthenticationFactor** 機能を使うと、アプリは近くにあるコンパニオン認証デバイス上のシークレット ストアを渡して、PC のロックを解除できます。 たとえば、コンパニオン フィットネス バンドを使用して、PC のロックを解除できます。 Windows.Security.Authentication.Identity.Provider 名前空間の API にアクセスするには、この機能が必要です。<br /><br />Microsoft Store に提出するアプリでこの機能を宣言することはお勧めしません。 ほとんどの開発者の方は、この機能の使用が承認されません。 |
| **Microsoft Store ライセンスの管理**| **storeLicenseManagement**機能を使うと、Microsoft パートナー ハブ アプリで、デバイス上のストア ライセンスを管理できます。 Windows.ApplicationModel.Store.LicenseManagement 名前空間の API にアクセスするには、この機能が必要です。 |
| **ユーザー システム ID**| **userSystemId** 機能を使うと、アプリは、ユーザー固有のシステム識別子を取得できます。 この識別子は特定のシステムで現在のユーザーを一意に識別し、アプリ間での情報の関連付けに使うことができます。 Windows.System.Profile.SystemIdentification クラスの GetUserSpecificSystemId API にアクセスするには、この機能が必要です。 |
| **対象コンテンツ**| **targetedContent** 機能を使うと、アプリケーションは、[**Windows.Services.TargetedContent**](https://docs.microsoft.com/uwp/api/windows.services.targetedcontent) 名前空間によって提供される対象のサブスクリプション コンテンツを取得して使用できます。<br /><br />**Windows.System.Profile.SystemIdentification** 名前空間の一部の API を使用するには、この機能が必要になります。 |
| **UI オートメーション**| **uiAutomation** 機能を使うと、ナレーターなどの UI オートメーション クライアントを UI オートメーション サーバーまたはプロバイダーに接続できます。<br /><br />**Windows.Xbox.Media.Capture.Broadcaster** 名前空間の一部の API を使う場合は、この機能が必要になります。 |
|**ゲーム バー サービス**| **gameBarServices** の使用は、ストア更新可能なファースト パーティ製 UWA に限定されます。<br /><br />[**Windows.Media.Capture.GameBarsSrvices**](https://docs.microsoft.com/uwp/api/windows.media.capture.gamebarservices) クラスを使う場合は、この機能が必要になります。<br /><br />Microsoft Store に提出するアプリでこの機能を宣言することはお勧めしません。 ほとんどの開発者の方は、この機能の使用が承認されません。 |
|**アプリ キャプチャ サービス**| **appCaptureServices** 機能の使用は、Microsoft との契約関係がある当事者に限定されます。 契約関係は、Xbox サービスおよび bizdev の支援によって成り立っているパートナー契約に基づいて設定されます。<br /><br />[**Windows.Media.Capture.AppCaptureServices**](https://docs.microsoft.com/uwp/api/windows.media.capture.appcaptureservices) クラスを使う場合は、この機能が必要になります。 |
|**アプリ ブロードキャスト サービス**| **appBroadcastServices** 機能の使用は、Microsoft との契約関係がある当事者に限定されます。 契約関係は、Xbox サービスの支援によって成り立っているパートナー契約に基づいて設定されます。<br /> <br /><br />[**Windows.Media.capture.AppBroadcastServices**](https://docs.microsoft.com/uwp/api/windows.media.capture.appbroadcastservices) クラスを使う場合は、この機能が必要になります。<br /><br />Microsoft Store に提出するアプリでこの機能を宣言することはお勧めしません。 ほとんどの開発者の方は、この機能の使用が承認されません。 |
|**オーディオ デバイスの構成**| **audioDeviceConfiguration** 機能を使うと、アプリケーションは、オーディオ ドライバーによって公開されるオーディオ エフェクトを照会、構成、有効化、および無効化できます。 <br /> <br />[**Windows.Media.Devices.AudioDeviceModulesManager**](https://docs.microsoft.com/uwp/api/windows.media.devices.audiodevicemodulesmanager) クラスを使う場合は、この機能が必要になります。<br /><br />Microsoft Store に提出するアプリでこの機能を宣言することはお勧めしません。 ほとんどの開発者の方は、この機能の使用が承認されません。 これは、アプリケーションで **AudioDeviceModulesManager** を使用すると、システム上のすべてのオーディオ エフェクトにアクセスできるためです。 可能性として、オーディオ エフェクトの設定によっては、デバイス上のオーディオ パフォーマンスに悪影響を与えることができます。 |
|**Preview Ink ワークスペース**| **previewInkWorkspace** 機能を使うと、アプリは、Ink ワークスペース内でホストされている Preview Ink 名前空間にアクセスできます。 一般的に、この機能は、デバイス上のホワイト ボード アプリケーションを置き換えるために、OEM によって使用されます。<br /> <br />[**Windows.ApplicationModel.Preview.InkWorkspace**](https://docs.microsoft.com/uwp/api/windows.applicationmodel.preview.inkworkspace) 名前空間の API を使う場合は、この機能が必要になります。 |
|**スタート画面の管理**| **startScreenManagement** 機能を使うと、アプリは、スタート画面にタイルを自動的にピン留めすることができます。 アプリは、バックグラウンドでピン留めすることもできます。 **startScreenManagement** 機能がないといずれかの API がブロックされるということではなく、**startScreenManagement** を使用すると、アプリで Pin API を使用しているときにシェルによって UI が表示されなくなります。 |
|**Cortana のアクセス許可**| **cortanaPermissions** 機能を使うと、アプリは、デバイス上でユーザーが Cortana に付与したアクセス許可を列挙できます。 また、アプリはこの機能によって、デバイス上で Cortana のアクセス許可の付与および取り消しを行うことができます。 **cortanaPermissions** を使うには、アクセス許可を付与する前にデバイスで法的なテキストを表示する必要があります。 アプリには、アクセス許可を変更した場合に生じる法的な影響をユーザーに通知する義務があります。<br /> <br /><br />レジストリ設定 **HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\Search\(*)** に対する読み取りアクセス許可を得るには、この機能が必要になります。<br /><br />Microsoft Store に提出するアプリでこの機能を宣言することはお勧めしません。 ほとんどの開発者の方は、この機能の使用が承認されません。 |
|**すべてのアプリの MOD**| **allAppMods** 機能を使うと、アプリは、すべてのアプリに対して AppMods フォルダーにアクセスできます。 Mod 管理ユーティリティでは **allAppMods** を使用し、MOD を使用するゲームやアプリの外で、その MOD を管理します。 |
|**拡張リソース**| **expandedResources** 機能を使うと、アプリは、ゲーム モードのリソースにアクセスできます。 Xbox と、ゲーム バーに対応する PC で、ゲーム モードのリソースとは、アプリ専用に予約されている、使用可能な CPU コアのサブセットを表します。 Xbox では、アプリは 4 GB 以上のメモリ パーティションも排他的に使用できます。<br /><br />前述のように CPU とメモリのリソースを排他的に使用するには、この機能が必要になります。 |
|**保護されたアプリ**| **protectedApp** 機能を使うと、ストアによって保護されているプロセスにアプリを読み込むことができます。 アプリがストアに取り込まれると、ストアによって実行可能ファイルに blob が追加されます。 ストアでは、Microsoft キーを使って実行可能ファイルへの署名も行われます。 blob には Microsoft の署名が必要であるため、プロセス ローダーは、保護されたプロセスを適用する機能ではなく、この blob をチェックします。<br /><br />Microsoft Store に提出するアプリでこの機能を宣言することはお勧めしません。 ほとんどの開発者の方は、この機能の使用が承認されません。 |
|**ゲーム モニター**| **gameMonitor** 機能を使うと、アプリによるゲーム不正がシステムのアクティブ監視で検出されるようになります。<br /><br />Microsoft Store に提出するアプリでこの機能を宣言することはお勧めしません。 ほとんどの開発者の方は、この機能の使用が承認されません。 |
|**アプリの診断**| **appDiagnostics** 機能を使うと、アプリは、実行中の他の UWP アプリに関する診断情報 (パッケージ情報、メモリ使用量、アカウント名など) を取得できます。 返される情報には、アプリの実行に使用されたドメイン/コンピューター アカウント名が含まれます。呼び出し元のアプリが管理者権限で起動されている場合、そのアプリは、コンピューター上のすべてのアカウントについて、実行中のすべてのアプリのリストを取得できます。 <br /><br />[**Windows.System.AppDiagnosticInfo**](https://docs.microsoft.com/uwp/api/windows.system.appdiagnosticinfo) クラス、**Windows.System.AppDiagnosticInfo.RequestAppDiagnosticInfoAsync** クラス、[**Windows.ApplicationModel.AppInfo**](https://docs.microsoft.com/uwp/api/windows.applicationmodel.appinfo) クラスを使う場合は、この機能が必要になります。 |
| **デバイス ポータルのプロバイダー** | **devicePortalProvider** 機能を使うと、アプリは **Windows.System.Diagnostics.DevicePortal** API を呼び出し、開発者モードでの診断ツール用 [Web サーバーとして](https://docs.microsoft.com/windows/uwp/debug-test-perf/device-portal-plugin) 機能することができます。<br /><br />Microsoft Store に提出するアプリでこの機能を宣言することはお勧めしません。 ほとんどの開発者の方は、この機能の使用が承認されません。 |
| **エンタープライズ クラウド シングル サインオン** | **enterpriseCloudSSO** 機能を使用すると、アプリはホスト型 Web 表示コントロール内で Azure Active Director (AAD) リソースによってシングル サインオンを使用できます。 |
| **VoIP 通話の自動受信** | **backgroundVoIP** 機能を使用すると、通話の明示的な受け入れをユーザーに求めることなく、VoIP の着信通話を自動的に受信し、受け入れることができます。 この機能を利用するアプリは、カメラとマイクのフル制御が許可され、これらのリソースをバックグラウンドで使用することができます。<br /><br />Microsoft Store に提出するアプリでこの機能を宣言することはお勧めしません。 ほとんどの開発者の方は、この機能の使用が承認されません。 |
| **開発モード ネットワーク** | **developmentModeNetwork** 機能を使用すると、C++/CX の UWP アプリまたは C++ の Windows ランタイム コンポーネントで OpenFile Win32 API を呼び出す際に、サインイン済みユーザーの資格情報を使用してネットワーク パスにアクセスできます。 <br /><br />Microsoft Store に提出するアプリでこの機能を宣言することはお勧めしません。 ほとんどの開発者の方は、この機能の使用が承認されません。 |
| **ファイル システムへの幅広いアクセス** | **broadFileSystemAccess** 機能を使用すると、実行時にファイル ピッカー スタイルのプロンプトを追加使用しなくても、アプリはファイル システムに対して、アプリを実行中のユーザーと同じアクセス許可を獲得できます。 ことが重要 FilePicker または FolderPicker を使用して、ユーザーが既に選択したことのファイルにアクセスするこの機能が必要ないことに注意してください。<br/><br/>この機能は、[Windows.Storage](https://docs.microsoft.com/uwp/api/windows.storage) API で動作します。 ただし、この機能をアプリ パッケージ マニフェストに宣言して任意の **Windows.Storage** API を初めて使用すると、ユーザーの同意を求めるプロンプトが表示される点に注意してください。このときユーザーは、アクセスを許可することも拒否することもできます。 また、ユーザーは、[設定] を切り替えることで、このアクセスをいつでも許可または拒否できます。 さらに、この機能では**ドキュメント**、**ピクチャ**、**ビデオ**などの特殊なフォルダー機能を宣言できない点にも注意してください。 |
| **システム ファームウェアおよび BIOS** | **smbios** 機能を使うと、アプリは BIOS データとシステム ファームウェア データにアクセスできます。 |
| **完全な信頼のアクセス許可レベル** | **RunFullTrust**制限された機能は、ユーザーのコンピューターで完全な信頼のアクセス許可レベルで動作するアプリを使うとします。 [FullTrustProcessLauncher](https://docs.microsoft.com/uwp/api/windows.applicationmodel.fulltrustprocesslauncher) API を使用するには、この機能が必要です。<br /><br />この機能は、デスクトップ アプリケーションは、appx や msix パッケージとして提供する必要も ([デスクトップ ブリッジ](https://developer.microsoft.com/windows/bridges/desktop)と同様)、Desktop App Converter (DAC) を使用してこれらのアプリをパッケージ化するとき、マニフェストに表示される自動的に、またはVisual Studio します。 |
| **昇格** | **AllowElevation**制限付き機能には、起動、またはアプリの有効期間中に自動昇格を必要とする既存のデスクトップ機能を維持するには、Microsoft パートナーや企業によって作成されたアプリができます。<br/><br/>Microsoft Store に提出するアプリでこの機能を宣言することはお勧めしません。 ほとんどの開発者の方は、この機能の使用が承認されません。 のみが承認されるため基幹業務アプリの企業がビジネス向け Microsoft ストアでプライベート ストアを展開します。  |
| **Windows チーム デバイスの資格情報** | **TeamEditionDeviceCredentials**制限付き機能には、Windows 10 バージョン 1703 以降を実行する Surface Hub デバイスでデバイス アカウントの資格情報を要求する Api にアクセスするアプリができます。<br/><br/>Microsoft Store に提出するアプリでこの機能を宣言することはお勧めしません。 ほとんどの開発者の方は、この機能の使用が承認されません。 |
| **Windows チーム アプリケーション ビュー** | **TeamEditionView**制限付き機能には、Windows 10 バージョン 1703 以降を実行する Surface Hub デバイスでのアプリケーションのビューをホストするための Api にアクセスするアプリができます。<br/><br/>Microsoft Store に提出するアプリでこの機能を宣言することはお勧めしません。 ほとんどの開発者の方は、この機能の使用が承認されません。 |
| **カメラの処理の拡張機能** | **CameraProcessingExtension**制限付き機能には、直接カメラの制御なし、カメラからキャプチャしたイメージを処理するアプリができます。<br /><br />[Windows.Devices.PointOfService.Provider](/uwp/api/windows.devices.pointofservice.provider)名前空間で Api を呼び出すには、この機能が必要です。<br /><br />この機能は、ストア申請用に誰でもアクセスを要求できます。 |
| **データ使用量の管理*** | **NetworkDataUsageManagement**制限付き機能には、ネットワーク データの使用状況に関する情報を収集するアプリができます。<br /><br />この機能を呼び出す[GetAttributedNetworkUsageAsync](/uwp/api/windows.networking.connectivity.connectionprofile.getattributednetworkusageasync)が必要です。<br /><br />この機能は、ストア申請用に誰でもアクセスを要求できます。 |

## <a name="custom-capabilities"></a>カスタムの機能

上記の[制限付き機能](#restricted-capabilities)には、カスタムの機能を使う承認をリクエストを使って、同じ機能の承認プロセスについて説明します。 [埋め込まれた SIM](/uwp/api/windows.networking.networkoperators.esim) Api は、カスタムの機能を必要とする Api の例を示します。 開発者モードでアプリケーションをローカルで実行する場合は、カスタムの機能を必要はありません。 ただし、Microsoft Store にアプリを公開するか、開発者モード外で実行する必要があります。

ある場合は、Windows のテクニカル アカウント マネージャー (TAM)、TAM へのアクセスを要求すると操作することができます。 詳細については、[連絡先 Microsoft TAM](/windows-hardware/drivers/mobilebroadband/testing-your-desktop-cosa-apn-database-submission#contact-your-microsoft-tam)で入手できます。

カスタムの機能を宣言する[アプリ パッケージ マニフェスト](https://msdn.microsoft.com/library/windows/apps/BR211474)ソース ファイルを変更します (`Package.appxmanifest`)。 **Xmlns:uap4** XML 名前空間の宣言を追加し、カスタムの機能を宣言するときに、 **uap4**プレフィックスを使用します。 次に例を示します。

```xml
<?xml version="1.0" encoding="utf-8"?>
<Package
    ...
    xmlns:uap4="http://schemas.microsoft.com/appx/manifest/uap/windows10/4">
...
<Capabilities>
    <uap4:CustomCapability Name="CompanyName.customCapabilityName_PublisherID"/>
</Capabilities>
</Package>
```

## <a name="related-topics"></a>関連トピック

* [申請オプション](../publish/manage-submission-options.md)
* [パッケージ マニフェストで機能を指定する方法](https://msdn.microsoft.com/library/windows/apps/BR211477)
* [パッケージ マニフェストでデバイス機能を指定する方法](https://msdn.microsoft.com/library/windows/apps/Dn263092)
