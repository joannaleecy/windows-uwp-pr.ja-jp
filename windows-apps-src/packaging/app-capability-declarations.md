---
author: msatranjr
ms.assetid: 25B18BA5-E584-4537-9F19-BB2C8C52DFE1
title: "アプリ機能の宣言"
description: "一部の API またはピクチャ、ミュージック、デバイス (カメラ、マイクなど) などのリソースにアクセスするには、機能をユニバーサル Windows プラットフォーム (UWP) アプリのパッケージ マニフェストで宣言する必要があります。"
ms.sourcegitcommit: 747cdcecfa04005ee4512007bef95059bd81fb56
ms.openlocfilehash: c3c70afbeab95fa967d5e7bb4b6dc9a9a66b6a39

---
# アプリ機能の宣言

\[ Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132) をご覧ください \]

一部の API またはピクチャ、ミュージック、デバイス (カメラ、マイクなど) などのリソースにアクセスするには、機能をユニバーサル Windows プラットフォーム (UWP) アプリの [パッケージ マニフェスト](https://msdn.microsoft.com/library/windows/apps/BR211474) で宣言する必要があります。

特定のリソースまたは API へのアクセスを要求するには、アプリの [パッケージ マニフェスト](https://msdn.microsoft.com/library/windows/apps/BR211474) で機能を宣言します。 一般的な機能は Microsoft Visual Studio の [マニフェスト デザイナー](https://msdn.microsoft.com/en-us/library/windows/apps/xaml/br230259.aspx) で宣言できるほか、パッケージ マニフェストに手動で追加することもできます。 詳しくは、「[パッケージ マニフェストで機能を指定する方法](https://msdn.microsoft.com/library/windows/apps/BR211477)」をご覧ください。 ユーザーがストアからアプリを入手するときに、アプリで宣言されているすべての機能が通知されることを知っておくのは重要です。 アプリに不要な機能を宣言しないでください。

一部の機能では、アプリが*機密性の高いリソース*にアクセスできます。 ユーザーの個人データにアクセスしたり、ユーザーに課金したりできるため、これらのリソースは機密性の高いリソースと見なされます。 設定アプリで管理されるプライバシー設定で、機密性の高いリソースへのアクセスを動的に制御することができます。 したがって、機密性の高いリソースが常に利用できるとアプリで認識されないことが重要です。 機密性の高いリソースへのアクセスについて詳しくは、「[個人データにアクセスするアプリのガイドライン](https://msdn.microsoft.com/library/windows/apps/Hh768223)」をご覧ください。 *機密性の高いリソース*へのアクセス許可をアプリに与える機能は、機能のシナリオの横にアスタリスク (\*) が付いています。

この記事では、機能を次の 4 つのカテゴリに分けて説明します。

-   ストア アプリのほとんどのシナリオに適用される一般的な用途の機能。

-   アプリが周辺機器と内部デバイスにアクセスできるようにするデバイス機能。

-   ストアに提出して使用可能のするために特別な会社のアカウントが必要になる特殊な用途の機能。 会社のアカウントについて詳しくは、「[アカウントの種類、場所、料金](https://msdn.microsoft.com/library/windows/apps/JJ863494)」をご覧ください。

-   Microsoft とそのパートナーだけが使用可能な制限された機能。

## 一般的な用途の機能

一般的な用途の機能は、ストア アプリのほとんどのシナリオに適用される機能です。

| 機能のシナリオ | 機能の使用法 |
|---------------------|------------------|
| **音楽**\* | **musicLibrary** 機能は、ユーザーの音楽ライブラリへのプログラムによるアクセスを提供します。これによって、ユーザーの操作なしで、ライブラリ内のすべてのファイルを列挙してそれらのファイルにアクセスできます。 通常、この機能は、音楽ライブラリ全体を利用するジュークボックス アプリで使われます。<br /><br />[
            **ファイル ピッカー**](https://msdn.microsoft.com/library/windows/apps/BR207847)は、アプリで使うファイルをユーザーが開くことができる強力な UI メカニズムを提供します。 **musicLibrary** 機能を宣言するのは、アプリのシナリオでプログラムによるアクセスが必要であるため、**ファイル ピッカー**では実現できない場合だけにしてください。<br /><br /> アプリのパッケージ マニフェストで宣言するとき、以下に示すように、**musicLibrary** 機能に **uap** 名前空間を含める必要があります。 <table><thead><tr><th>XML</th></tr></thead><tbody><tr><td><pre><code>&lt;Capabilities&gt;&lt;uap:Capability Name="musicLibrary"/&gt;&lt;/Capabilities&gt;</code></pre></td></tr></tbody></table>
| **画像**\* | **picturesLibrary** 機能は、ユーザーの画像へのプログラムによるアクセスを提供します。これによって、ユーザーの操作なしで、ライブラリ内のすべてのファイルを列挙してそれらのファイルにアクセスできます。 通常、この機能は、画像ライブラリ全体を利用する写真再生アプリで使われます。<br /><br />[
            **ファイル ピッカー**](https://msdn.microsoft.com/library/windows/apps/BR207847)は、アプリで使うファイルをユーザーが開くことができる強力な UI メカニズムを提供します。 **picturesLibrary** 機能を宣言するのは、アプリのシナリオでプログラムによるアクセスが必要であるため、**ファイル ピッカー**では実現できない場合だけにしてください。<br /><br />アプリのパッケージ マニフェストで宣言するとき、以下に示すように、**picturesLibrary** 機能に **uap** 名前空間を含める必要があります。<table><thead><tr><th>XML</th></tr></thead><tbody><tr><td><pre><code>&lt;Capabilities&gt;&lt;uap:Capability Name="picturesLibrary"/&gt;&lt;/Capabilities&gt;</code></pre></td></tr></tbody></table>
| **ビデオ**\* | **videosLibrary** 機能は、ユーザーのビデオへのプログラムによるアクセスを提供します。これによって、ユーザーの操作なしで、ライブラリ内のすべてのファイルを列挙してそれらのファイルにアクセスできます。 通常、この機能は、ビデオ ライブラリ全体を利用するムービー再生アプリで使われます。<br /><br />[
            **ファイル ピッカー**](https://msdn.microsoft.com/library/windows/apps/BR207847)は、アプリで使うファイルをユーザーが開くことができる強力な UI メカニズムを提供します。 **videosLibrary** 機能を宣言するのは、アプリのシナリオでプログラムによるアクセスが必要であるため、**ファイル ピッカー**では実現できない場合だけにしてください。<br /><br />アプリのパッケージ マニフェストで宣言するとき、以下に示すように、**videosLibrary** 機能に **uap** 名前空間を含める必要があります。<table><thead><tr><th>XML</th></tr></thead><tbody><tr><td><pre><code>&lt;Capabilities&gt;&lt;uap:Capability Name="videosLibrary"/&gt;&lt;/Capabilities&gt;</code></pre></td></tr></tbody></table>
| **リムーバブル記憶域** | **removableStorage** 機能は、パッケージ マニフェストで宣言されたファイルの種類の関連付けに限定された、USB キーや外部ハード ドライブなどのリムーバブル ストレージ上のファイルへのプログラムによるアクセスを提供します。 たとえば、ドキュメント リーダー アプリで .doc ファイルの種類の関連付けを宣言すると、リムーバブル ストレージ デバイス上の .doc ファイルを開くことはできますが、他の種類のファイルを開くことはできません。 ユーザーのリムーバブル ストレージ デバイスにはさまざまな情報が含まれている可能性があり、リムーバブル ストレージにプログラムでアクセスするときは宣言された種類のファイルすべてについて正当な理由が求められるため、この機能を宣言する場合は注意が必要です。<br /><br />ユーザーは、関連付けが宣言されたファイルはアプリで処理されるものと考えます。 そのため、責任を持って処理できないファイルについては、関連付けを宣言しないでください。 [
            **ファイル ピッカー**](https://msdn.microsoft.com/library/windows/apps/BR207847)は、アプリで使うファイルをユーザーが開くことができる強力な UI メカニズムを提供します。<br /><br />**removableStorage** 機能を宣言するのは、アプリのシナリオでプログラムによるアクセスが必要であるため、[**ファイル ピッカー**](https://msdn.microsoft.com/library/windows/apps/BR207847)では実現できない場合だけにしてください。<br /><br />アプリのパッケージ マニフェストで宣言するとき、以下に示すように、**removableStorage** 機能に **uap** 名前空間を含める必要があります。<table><thead><tr><th>XML</th></tr></thead><tbody><tr><td><pre><code>&lt;Capabilities&gt;&lt;uap:Capability Name="removableStorage"/&gt;&lt;/Capabilities&gt;</code></pre></td></tr></tbody></table>
| **インターネットとパブリック ネットワーク**\* | インターネットとパブリック ネットワークに対するさまざまなレベルのアクセスを提供する機能は 2 つあります。<br /><br />**internetClient** 機能を使うと、アプリはインターネットから着信データを受信できます。 サーバーとして機能することはできません。 ローカル ネットワーク アクセスはありません。<br />**internetClientServer** 機能を使うと、アプリはインターネットから着信データを受信できます。 サーバーとして機能できます。 ローカル ネットワーク アクセスはありません。<br /><br />Web サービス コンポーネントを持つほとんどのアプリで **internetClient** を使います。 着信ネットワーク接続をリッスンする必要があるピア ツー ピア (P2P) シナリオを実現するアプリは **internetClientServer** を使う必要があります。 **internetClientServer** 機能には **internetClient** 機能で提供されるアクセスが含まれるため、**internetClientServer** を指定した場合は **internetClient** を指定する必要はありません。
| **ホーム ネットワークと社内ネットワーク**\* | **privateNetworkClientServer** 機能は、ファイアウォール経由でのホーム ネットワークおよび社内ネットワークへの入力方向および出力方向のアクセスを提供します。 通常、この機能は、ローカル エリア ネットワーク (LAN) 上で通信するゲーム、およびさまざまなローカル デバイスでデータを共有するアプリで使われます。 アプリで **musicLibrary**、**picturesLibrary**、または **videosLibrary** を指定している場合は、ホーム グループ内の対応するライブラリにアクセスするためにこの機能を使う必要はありません。 Windows の場合、この機能はインターネットへのアクセスを提供しません。
| **予定** | **appointments** 機能は、ユーザーの予定ストアへのアクセスを提供します。 この機能によって、同期されたネットワーク アカウントから取得された予定や、予定ストアへの書き込みを行う他のアプリに対する読み取りアクセスが可能になります。 この機能を使うと、アプリで新しいカレンダーを作り、そのカレンダーに予定を書き込むことができます。<br /><br />アプリのパッケージ マニフェストで宣言するとき、以下に示すように、**appointments** 機能に **uap** 名前空間を含める必要があります。<table><thead><tr><th>XML</th></tr></thead><tbody><tr><td><pre><code>&lt;Capabilities&gt;&lt;uap:Capability Name="appointments"/&gt;&lt;/Capabilities&gt;</code></pre></td></tr></tbody></table>
| **連絡先**\* | **contacts** 機能は、さまざまな連絡先ストアからの連絡先が集約されたビューへのアクセスを提供します。 この機能によって、アプリでは、さまざまなネットワークやローカルの連絡先ストアから同期された連絡先に制限付きでアクセスできます (ネットワーク許可規則が適用されます)。<br /><br />アプリのパッケージ マニフェストで宣言するとき、以下に示すように、**contacts** 機能に **uap** 名前空間を含める必要があります。<table><thead><tr><th>XML</th></tr></thead><tbody><tr><td><pre><code>&lt;Capabilities&gt;&lt;uap:Capability Name="contacts"/&gt;&lt;/Capabilities&gt;</code></pre></td></tr></tbody></table>
| **コード生成** | **codeGeneration** 機能を使うと、アプリは JIT が可能になる次の機能にアクセスできます。<br /><br />[**VirtualProtectFromApp**](https://msdn.microsoft.com/library/windows/desktop/Mt169846)<br />[**CreateFileMappingFromApp**](https://msdn.microsoft.com/library/windows/desktop/Hh994453)<br />[**OpenFileMappingFromApp**](https://msdn.microsoft.com/library/windows/desktop/Mt169844)<br />[**MapViewOfFileFromApp**](https://msdn.microsoft.com/library/windows/desktop/Hh994454)
| **AllJoyn** | **allJoyn** 機能を使うと、ネットワーク上の AllJoyn 対応のアプリやデバイスは、相互に検出を行い、対話することができます。<br /><br />[
            **Windows.Devices.AllJoyn**](https://msdn.microsoft.com/library/windows/apps/Dn894971) 名前空間の API にアクセスするすべてのアプリは、この機能を使う必要があります。
| **通話** | **phoneCall** 機能を使うと、アプリは、デバイスのすべての電話回線にアクセスし、次の機能を実行できます。<br /><br />ユーザーに確認を求めずに、電話回線での通話を実行してシステムのダイヤラーを表示します。<br />電話回線に関連するメタデータへアクセスします。<br />電話回線に関連するトリガーへアクセスします。<br />ユーザーが選んだスパム フィルター アプリで、禁止一覧と呼び出し元の情報を設定し、確認することができます。<br /><br />アプリのパッケージ マニフェストで宣言するとき、以下に示すように、**phoneCall** 機能に **uap** 名前空間を含める必要があります。<table><thead><tr><th>XML</th></tr></thead><tbody><tr><td><pre><code>&lt;Capabilities&gt;&lt;uap:Capability Name="phoneCall"/&gt;&lt;/Capabilities&gt;</code></pre></td></tr></tbody></table>**phoneCallHistoryPublic** 機能を使うと、アプリはデバイス上の電話と一部の VOIP の通話履歴を読み取ることができます。 また、VOIP の通話履歴のエントリを書き込むこともできます。 この機能は、[**PhoneCallHistoryStore**](https://msdn.microsoft.com/library/windows/apps/Dn705931) クラスのすべてのメンバーへのアクセスに必要です。
| **通話が録音されているフォルダー**\* | **recordedCallsFolder** デバイス機能を使うと、アプリは通話が録音されているフォルダーにアクセスできます。<br /><br />アプリのパッケージ マニフェストで宣言するとき、以下に示すように、**recordedCallsFolder** 機能に **mobile** 名前空間を含める必要があります。<table><thead><tr><th>XML</th></tr></thead><tbody><tr><td><pre><code>&lt;Capabilities&gt;&lt;mobile:Capability Name="recordedCallsFolder"/&gt;&lt;/Capabilities&gt;</code></pre></td></tr></tbody></table>
| **ユーザー アカウント情報**\* | **userAccountInformation** 機能を使うと、アプリはユーザーの名前と画像にアクセスできるようになります。<br /><br />[
            **Windows.System.UserProfile**](https://msdn.microsoft.com/library/windows/apps/Windows.System.UserProfile) 名前空間の一部の API にアクセスする場合は、この機能が必要になります。<br /><br />アプリのパッケージ マニフェストで宣言するとき、以下に示すように、**userAccountInformation** 機能に **uap** 名前空間を含める必要があります。<table><thead><tr><th>XML</th></tr></thead><tbody><tr><td><pre><code>&lt;Capabilities&gt;&lt;uap:Capability Name="userAccountInformation"/&gt;&lt;/Capabilities&gt;</code></pre></td></tr></tbody></table>
| **VOIP 呼び出し** | **voipCall** 機能を使うと、アプリは [**Windows.ApplicationModel.Calls**](https://msdn.microsoft.com/library/windows/apps/Dn297266) 名前空間の VOIP 呼び出し API にアクセスできます。<br /><br />アプリのパッケージ マニフェストで宣言するとき、以下に示すように、**voipCall** 機能に **uap** 名前空間を含める必要があります。<table><thead><tr><th>XML</th></tr></thead><tbody><tr><td><pre><code>&lt;Capabilities&gt;&lt;uap:Capability Name="voipCall"/&gt;&lt;/Capabilities&gt;</code></pre></td></tr></tbody></table>
| **3D オブジェクト** | **objects3D** 機能を使用すると、アプリは 3D オブジェクト ファイルにプログラムでアクセスできます。 通常、この機能は、3D オブジェクト ライブラリ全体にアクセスする必要がある 3D アプリやゲームで使用されます。<br /><br />[
            **Windows.Storage**](https://msdn.microsoft.com/library/windows/apps/BR227346) 名前空間の API を使って 3D オブジェクトを含むフォルダーにアクセスする場合は、この機能が必要になります。<br /><br />アプリのパッケージ マニフェストで宣言するとき、以下に示すように、**objects3D** 機能に **uap** 名前空間を含める必要があります。<table><thead><tr><th>XML</th></tr></thead><tbody><tr><td><pre><code>&lt;Capabilities&gt;&lt;uap:Capability Name="objects3d"/&gt;&lt;/Capabilities&gt;</code></pre></td></tr></tbody></table>
| **ブロックされているメッセージの読み取り**\* | **blockedChatMessages** 機能を使うと、アプリはスパム フィルター アプリでブロックされた SMS メッセージや MMS メッセージを読み取ることができます。<br /><br />[
            **Windows.ApplicationModel.Chat**](https://msdn.microsoft.com/library/windows/apps/Dn642321) 名前空間の API を使ってブロックされたメッセージにアクセスする場合は、この機能が必要になります。<br /><br />アプリのパッケージ マニフェストで宣言するとき、以下に示すように、**blockedChatMessages** 機能に **uap** 名前空間を含める必要があります。<table><thead><tr><th>XML</th></tr></thead><tbody><tr><td><pre><code>&lt;Capabilities&gt;&lt;uap:Capability Name="chat"/&gt;&lt;/Capabilities&gt;</code></pre></td></tr></tbody></table>
| **IoT 下位レベルのバス ハードウェア** | **lowLevelDevices** 機能を使うと、IoT デバイスで動作するアプリは、下位レベルのバス ハードウェア (GPIO、I2C、SPI、ADC、PWM など) にアクセスできるようになります。<br /><br />[
            **Windows.Devices.Spi**](https://msdn.microsoft.com/library/windows/apps/Dn708178) 名前空間の一部の API にアクセスする場合は、この機能が必要になります。<br /><br />アプリのパッケージ マニフェストで宣言するとき、以下に示すように、**lowLevelDevices** 機能に **iot** 名前空間を含める必要があります。<table><thead><tr><th>XML</th></tr></thead><tbody><tr><td><pre><code>&lt;Capabilities&gt;&lt;iot:Capability Name="lowLevelDevices"/&gt;&lt;/Capabilities&gt;</code></pre></td></tr></tbody></table>
| **IoT システム管理** | **systemManagement** 機能を使うと、アプリは基本的なシステム管理者特権 (シャットダウン、再起動、ロケール、タイムゾーンなど) を持つことができます。<br /><br />[
            **Windows.System**](https://msdn.microsoft.com/library/windows/apps/BR241814) 名前空間の一部の API にアクセスする場合は、この機能が必要になります。<br /><br />アプリのパッケージ マニフェストで宣言するとき、以下に示すように、**systemManagement** 機能に **iot** 名前空間を含める必要があります。<table><thead><tr><th>XML</th></tr></thead><tbody><tr><td><pre><code>&lt;Capabilities&gt;&lt;iot:Capability Name="systemManagement"/&gt;&lt;/Capabilities&gt;</code></pre></td></tr></tbody></table>


## デバイスの機能

デバイス機能を使用すると、アプリは周辺機器と内部デバイスにアクセスできます。 デバイスの機能を指定するには、アプリのパッケージ マニフェストの **DeviceCapability** 要素を使います。 この要素は追加の子要素を必要とする場合があり、一部のデバイス機能をパッケージ マニフェストに手動で追加する必要があります。 詳しくは、「[パッケージ マニフェストでデバイス機能を指定する方法](https://msdn.microsoft.com/library/windows/apps/Dn263092)」と「[**DeviceCapability スキーマ リファレンス**](https://msdn.microsoft.com/library/windows/apps/BR211430)」をご覧ください。

| 機能のシナリオ | 機能の使用法 |
|---------------------|------------------|
| **位置情報**\* | **location** 機能は、位置情報機能へのアクセスを提供します。この情報は PC が備えている GPS センサーなどの専用ハードウェアや、利用可能なネットワーク情報から取得されます。 アプリは、ユーザーが **[設定]** チャームで位置情報サービスを無効にした場合に対応する必要があります。 |
| **マイク** | **microphone** 機能は、マイクのオーディオ フィードへのアクセスを提供します。これによって、接続されたマイクからオーディオを録音できます。 アプリは、ユーザーが **[設定]** チャームでマイクを無効にした場合に対応する必要があります。 |
| **近接** | **proximity** 機能を使うと、きわめて近い場所にある複数のデバイスが相互に通信できます。 通常、この機能は、カジュアルなマルチプレーヤー ゲームや情報を交換するアプリで使われます。 デバイスは、Bluetooth、Wi-Fi、インターネットを含む、最適な接続を提供する通信テクノロジを使います。 この機能は、デバイス間の通信を開始するためにのみ使われます。 |
| **Webcam** | **webcam** 機能は、内蔵カメラや外付け Web カメラのビデオ フィードへのアクセスを提供します。これによって、アプリで写真やビデオをキャプチャできます。 Windows の場合、アプリはユーザーが **[設定]** チャームでカメラを無効にした場合に対応する必要があります。<br/>**webcam** 機能では、ビデオ ストリームへのアクセスだけが許可されます。 オーディオ ストリームへのアクセスも許可するには、**microphone** 機能を追加する必要があります。 |
| **USB** | **usb** デバイス機能を使うと、「[USB デバイスのアプリ マニフェスト パッケージの更新](http://go.microsoft.com/fwlink/p/?LinkId=302259)」で API にアクセスできます。 |
| **ヒューマン インターフェイス デバイス (HID)** | **humaninterfacedevice** デバイス機能を使うと、「[HID のデバイス機能を指定する方法](https://msdn.microsoft.com/library/windows/apps/Dn263091)」で API にアクセスできます。 |
| **Point of Service (POS)** | **pointOfService** デバイス機能を使うと、[**Windows.Devices.PointOfService**](https://msdn.microsoft.com/library/windows/apps/Dn298071) 名前空間の API にアクセスできます。 この名前空間により、アプリは、Point of Service (POS) バー コード スキャナーや磁気ストライプ リーダーにアクセスできます。 この名前空間は、さまざまな製造元の POS デバイスに Windows ストア アプリからアクセスするための、ベンダーに依存しないインターフェイスを提供します。 |
| **Bluetooth** | **bluetooth** デバイス機能を使うと、アプリは Generic Attribute (GATT) または Classic Basic Rate (RFCOMM) プロトコル経由で既にペアリングされている Bluetooth デバイスと通信できます。<br/>[
            **Windows.Devices.Bluetooth**](https://msdn.microsoft.com/library/windows/apps/Dn263413) 名前空間の一部の API を使う場合は、この機能が必要になります。 |
| **Wi-Fi ネットワーク** | **wiFiControl** デバイス機能を使うと、アプリはスキャンを実行して、Wi-Fi ネットワークに接続することができます。<br/>[
            **Windows.Devices.WiFi**](https://msdn.microsoft.com/library/windows/apps/Dn975224) 名前空間の一部の API を使う場合は、この機能が必要になります。 |
| **無線状態** | **radios** デバイス機能を使うと、アプリは Wi-Fi 通信と Bluetooth 通信を切り替えることができます。<br/>[
            **Windows.Devices.Radios**](https://msdn.microsoft.com/library/windows/apps/Dn996447) 名前空間の API を使う場合は、この機能が必要になります。  |
| **光学式ディスク** | **optical** デバイス機能を使うと、アプリは、CD、DVD、ブルーレイなどの光ディスク ドライブの機能にアクセスできます。<br/>[
            **Windows.Devices.Custom**](https://msdn.microsoft.com/library/windows/apps/Dn263667) 名前空間の一部の API を使う場合は、この機能が必要になります。 |
| **モーション アクティビティ** | デバイス機能 **activity** を使うと、アプリはデバイスの現在の動きを検出できるようになります。<br/>[
            **Windows.Devices.Sensors**](https://msdn.microsoft.com/library/windows/apps/BR206408) 名前空間の一部の API を使う場合は、この機能が必要になります。 |

## 特殊な用途および制限された用途に関する機能

**重要**  
特殊な用途および制限された用途に関する機能は、特殊なシナリオ向けの機能です。 これらの機能は、用途が厳格に制限されており、ストアへの登録に際して追加のポリシーやレビューが適用されます。

これらの機能が必要で適しているものとしては、身元を証明するデジタル証明書をスマート カードに含めるようにユーザーに求める 2 要素認証を使ったバンキング アプリなどがあります。 また、主に企業ユーザー向けに設計されたアプリや、ユーザーのドメイン資格情報がないとアクセスできな企業リソースへのアクセスを必要とするアプリもあります。

特殊な用途の機能に該当するアプリについては、ストアに提出する際に会社のアカウントが必要になります。 これに対し、制限された機能は開発者が使うことができないため、ストア用の特別な会社のアカウントは必要ありません。 制限された機能は、Microsoft とそのパートナーにより開発されたアプリだけが使用可能です。 会社のアカウントについて詳しくは、「[アカウントの種類、場所、料金](https://msdn.microsoft.com/library/windows/apps/JJ863494)」をご覧ください。

アプリのパッケージ マニフェストで宣言するとき、すべての制限された機能には **rescap** 名前空間を含める必要があります (これは、他の機能とは異なります)。 次の例は、**appCaptureSettings** 機能を宣言する方法を示しています。

```xml
<Capabilities>
    <rescap:Capability Name="appCaptureSettings"/>
</Capabilities>
```

次に示すように、Package.appxmanifest ファイルの先頭に **xmlns:rescap** 名前空間の宣言も追加する必要があります。

```xml
<Package
    xmlns="http://schemas.microsoft.com/appx/manifest/foundation/windows10"
    xmlns:mp="http://schemas.microsoft.com/appx/2014/phone/manifest"
    xmlns:uap="http://schemas.microsoft.com/appx/manifest/uap/windows10"
    xmlns:rescap="http://schemas.microsoft.com/appx/manifest/foundation/windows10/restrictedcapabilities"
    IgnorableNamespaces="uap mp wincap rescap">
```

| 機能のシナリオ | 機能の使用法 |
|---------------------|------------------|
| **エンタープライズ** | Windows ドメイン資格情報により、ユーザーはそれぞれの資格情報を使ってリモートのリソースにログインし、ユーザー名とパスワードを指定したかのように動作できます。 通常、特殊な機能 **enterpriseAuthentication** は、企業内のサーバーに接続する基幹業務アプリで使われます。<br /><br />インターネット上での汎用通信にはこの機能は不要です。<br /><br />特殊な機能 **enterpriseAuthentication** は、一般的な基幹業務アプリをサポートするための機能です。 企業リソースにアクセスする必要がないアプリでは宣言しないでください。 [
            **ファイル ピッカー**](https://msdn.microsoft.com/library/windows/apps/BR207847) は、アプリで使うネットワーク共有上のファイルをユーザーが開くことができる強力な UI メカニズムを提供します。 **enterpriseAuthentication** 機能を宣言するのは、プログラムによるアクセスを必要とするアプリのシナリオを**ファイル ピッカー**では実現できない場合だけにしてください。<br /><br />アプリのパッケージ マニフェストで宣言するとき、以下に示すように、**enterpriseAuthentication** 機能に **uap** 名前空間を含める必要があります。<br /><br /><div class="code"><span codelanguage="XML"></span><table><colgroup><col width="100%" /></colgroup><thead><tr class="header"><th align="left">XML</th></tr></thead><tbody><tr class="odd"><td align="left"><pre><code>&lt;Capabilities&gt;&lt;uap:Capability Name="enterpriseAuthentication"/&gt;&lt;/Capabilities&gt;</code></pre></td></tr></tbody></table></div>**enterpriseDataPolicy** 機能を使うと、アプリはデバイス用に企業固有のポリシーを定義して使えます。 この機能は、次のクラスのすべてのメンバーを使うために必要です。<ul><li>[**FileProtectionManager**](https://msdn.microsoft.com/library/windows/apps/Dn705151)</li><li>[**DataProtectionManager**](https://msdn.microsoft.com/library/windows/apps/Dn706017)</li><li>[**ProtectionPolicyManager**](https://msdn.microsoft.com/library/windows/apps/Dn705170)</li></ul></td></tr>
| **ユーザー証明書の共有** | 特殊な機能 **sharedUserCertificates** を使って、アプリは共有ユーザー ストア内のソフトウェアベースおよびハードウェアベースの証明書 (スマート カードに格納されている証明書など) を追加したり、それらの証明書にアクセスしたりできます。 通常、この機能は、認証にスマート カードを必要とする財務アプリまたはエンタープライズ アプリで使われます。<br /><br />アプリのパッケージ マニフェストで宣言するとき、以下に示すように、**sharedUserCertificates** 機能に **uap** 名前空間を含める必要があります。<br /><br /><div class="code"><span codelanguage="XML"></span><table><colgroup><col width="100%" /></colgroup><thead><tr class="header"><th align="left">XML</th></tr></thead><tbody><tr class="odd"><td align="left"><pre><code>&lt;Capabilities&gt;&lt;uap:Capability Name="sharedUserCertificates"/&gt;&lt;/Capabilities&gt;</code></pre></td></tr></tbody></table></div>
|**ドキュメント**\* | 特殊な機能 **documentsLibrary** は、パッケージ マニフェストで宣言されたファイルの種類の関連付けに限定された、ユーザーのドキュメントへのプログラムによるアクセスを提供し、OneDrive へのオフライン アクセスをサポートします。 たとえば、DOC リーダー アプリで .doc ファイルの種類の関連付けを宣言すると、ドキュメント フォルダー内の .doc ファイルを開くことはできますが、他の種類のファイルを開くことはできません。<br /><br />特殊な機能 **documentsLibrary** を宣言するアプリは、ホーム グループ コンピューター上のドキュメント フォルダーにアクセスできません。 [ファイル ピッカー](https://msdn.microsoft.com/library/windows/apps/Hh465174)は、アプリで使うファイルをユーザーが開くことができる強力な UI メカニズムを提供します。 特殊な機能 **documentsLibrary** は、ファイル ピッカーを使えない場合のみ宣言します。<br /><br />特殊な機能 **documentsLibrary** を使うにはアプリが次の条件を満たしている必要があります。<ul><li>有効な OneDrive URL またはリソース ID を使った、特定の OneDrive コンテンツへのクロスプラットフォーム オフライン アクセスを容易にする</li><li>オフライン時に、開いているファイルをユーザーの OneDrive に自動的に保存する</li></ul>これらの 2 つの目的で特殊な機能 **documentsLibrary** を使うアプリと、別のドキュメントに埋め込まれているコンテンツを開く機能を使うこともできます。 特殊な機能 **documentsLibrary** の上記の使用方法のみが許可されています。<ul><li>アプリは、電話の内部ストレージにあるドキュメント ライブラリにはアクセスできません。 ただし、別のアプリによってオプションの SD カード上にドキュメント フォルダーが作られた場合は、アプリでそのフォルダーを表示できます。</li></ul>アプリのパッケージ マニフェストで宣言するとき、以下に示すように、**documentsLibrary** 機能に **uap** 名前空間を含める必要があります。<div class="code"><span codelanguage="XML"></span><table><colgroup><col width="100%" /></colgroup><thead><tr class="header"><th align="left">XML</th></tr></thead><tbody><tr class="odd"><td align="left"><pre><code>&lt;Capabilities&gt;&lt;uap:Capability Name="documentsLibrary"/&gt;&lt;/Capabilities&gt;</code></pre></td></tr></tbody></table></div>
| **ゲーム DVR 設定** | 制限された機能 **appCaptureSettings** を使うと、アプリはゲーム DVR のユーザー設定を制御できます。<br /><br />[
            **Windows.Media.Capture**](https://msdn.microsoft.com/library/windows/apps/BR226738) 名前空間の一部の API を使う場合は、この機能が必要になります。
| **携帯電話** | 制限された機能 **cellularDeviceControl** を使うと、アプリは携帯デバイスを制御できます。<br /><br />**cellularDeviceIdentity** 機能を使うと、アプリは携帯デバイスの ID データにアクセスできます。<br /><br />**cellularMessaging** 機能を使うと、アプリは SMS と RCS を利用できます。<br /><br />[
            **Windows.Devices.Sms**](https://msdn.microsoft.com/library/windows/apps/BR206567) 名前空間の一部の API を使う場合は、これらの機能が必要になります。<br /><br />Windows 10 以降、[**AppIDList**](https://msdn.microsoft.com/library/windows/apps/Dn393996) を呼び出すアプリ。
| **デバイスのロック解除** | 制限された機能 **deviceUnlock** を使うと、アプリは、開発者サイドローディングのシナリオやエンタープライズ サイドローディングのシナリオ向けにデバイスをロック解除できます。
| **デュアル SIM タイル** | 制限された機能 **dualSimTiles** を使うと、アプリは、複数の SIM を備えたデバイスでアプリ一覧の追加のエントリを作成できます。<br /><br />[
            **Windows.UI.StartScreen**](https://msdn.microsoft.com/library/windows/apps/BR242235) 名前空間の一部の API を使う場合は、この機能が必要になります。
| **エンタープライズ共有記憶域** | 制限された機能 **enterpriseDeviceLockdown** を使うと、アプリは、デバイスのロック ダウン API を利用したり、企業で共有している保存フォルダーにアクセスしたりすることができます。
| **システム入力の挿入** | 制限された機能 **inputInjection** を使うと、アプリは、さまざまな形式の入力 (HID、タッチ、ペン、キーボード、マウスなど) をプログラムでシステムに挿入できます。 通常、この機能はシステムを制御できる共同作業アプリで使われます。<br /><br /><div class="alert">**注**  PC の場合、この機能を使ったアプリからの入力の挿入は、同じアプリ コンテナー内のプロセスによってのみ許可されます。</div>
| **入力の監視**\* | 制限された機能 **inputObservation** を使うと、アプリは、さまざまな形式の未加工入力 (HID、タッチ、ペン、キーボード、マウスなど) が、最終的な宛先に関係なく、システムによって許可されるのを監視できます。
| **入力の抑制** | 制限された機能 **inputSuppression** を使うと、アプリは、さまざまな形式の未加工入力 (HID、タッチ、ペン、キーボード、マウスなど) が、システムによって許可されるのを抑制できます。
| **VPN アプリ** | 制限された機能 **networkingVpnProvider** を使うと、アプリは VPN 機能 (接続の管理や VPN プラグイン機能の提供など) へのフル アクセスが可能になります。<br /><br />[
            **Windows.Networking.Vpn**](https://msdn.microsoft.com/library/windows/apps/Dn434040) 名前空間の一部の API を使う場合は、この機能が必要になります。
| **他のアプリの管理** | 制限された機能 **packageManagement** を使うと、アプリは他のアプリを直接管理できます。<br /><br />**packageQuery** デバイス機能を使うと、アプリは他のアプリに関する情報を収集できます。<br /><br />[
            **PackageManager**](https://msdn.microsoft.com/library/windows/apps/BR240960) クラスの一部のメソッドとプロパティにアクセスする場合は、これらの機能が必要になります。
| **画面の投影** | 制限された機能 **ScreenDuplication** を使うと、アプリは画面を別のデバイスに表示できます。<br /><br />DirectX 名前空間の API を使う場合は、この機能が必要になります。
| **ユーザー プリンシパル名** | 制限された機能 **userPrincipalName** を使うと、アプリは、写真に基づく縮小表示のキャッシュを変更したり、このキャッシュにアクセスしたりすることができます。<br /><br />[
            **GetUserNameEx**](https://msdn.microsoft.com/library/windows/desktop/ms724435) 関数を呼び出す場合は、この機能が必要になります。
| **ウォレット** | 制限された機能 **walletSystem** を使うと、アプリは保存されたウォレット カードへのフル アクセスが可能になります。<br /><br />[
            **Windows.ApplicationModel.Wallet.System**](https://msdn.microsoft.com/library/windows/apps/Mt171610) 名前空間の API を使う場合は、この機能が必要になります。
| **位置情報の履歴** | 制限された機能 **locationHistory** を使うと、アプリはデバイスの位置情報の履歴にアクセスできます。<br /><br />[
            **Windows.Devices.Geolocation**](https://msdn.microsoft.com/library/windows/apps/BR225603) 名前空間の API を使う場合は、この機能が必要になります。
| **アプリを閉じる確認** | 制限された機能 **confirmAppClose** を使うと、アプリはアプリ自体とアプリ独自のウィンドウを閉じたり、アプリを閉じることを遅延させたりすることができます。<br /><br />[
            **Windows.UI.ViewManagement**](https://msdn.microsoft.com/library/windows/apps/BR242295) 名前空間の API を使う場合は、この機能が必要になります。
| **通話履歴**\* | 制限された機能 **phoneCallHistory** を使うと、アプリは通話履歴を読み取ったり、履歴のエントリを削除できます。<br /><br />[
            **Windows.ApplicationModel.Chat**](https://msdn.microsoft.com/library/windows/apps/Dn642321) 名前空間の API を使う場合は、この機能が必要になります。
| **システム レベルの予定へのアクセス** | 制限された機能 **appointmentsSystem** を使うと、アプリはユーザーのカレンダーにあるすべての予定を読み取ったり、変更したりすることができます。<br /><br />[
            **Windows.ApplicationModel.Appointment**](https://msdn.microsoft.com/library/windows/apps/Dn263359) 名前空間の API を使う場合は、この機能が必要になります。
| **システム レベルのチャット メッセージへのアクセス**\* | 制限された機能 **chatSystem** を使うと、アプリはすべての SMS メッセージと MMS メッセージの読み取りと書き込みを実行できます。<br />[
            **Windows.ApplicationModel.Chat**](https://msdn.microsoft.com/library/windows/apps/Dn642321) 名前空間の API を使う場合は、この機能が必要になります。
| **システム レベルの連絡先へのアクセス** | 制限された機能 **contactsSystem** を使うと、アプリは制限付きの連絡先情報や機密性の高い連絡先情報を読み取ったり、既存の連絡先情報を変更したりすることができます。<br /><br />[
            **Windows.ApplicationModel.Chat**](https://msdn.microsoft.com/library/windows/apps/Dn642321) 名前空間の API を使う場合は、この機能が必要になります。
| **メールへのアクセス*** | 制限された機能 **email** を使うと、アプリはユーザーのメールの読み取り、トリアージ、送信を実行できます。<br /><br />[
            **Windows.ApplicationModel.Email**](https://msdn.microsoft.com/library/windows/apps/Dn631285) 名前空間の API を使う場合は、この機能が必要になります。
| **システム レベルのメールへのアクセス**| 制限された機能 **emailSystem** を使うと、アプリは制限つきのユーザーのメールや機密性の高いユーザーのメールの読み取り、トリアージ、送信を実行できます。<br /><br />[
            **Windows.ApplicationModel.Email**](https://msdn.microsoft.com/library/windows/apps/Dn631285) 名前空間の API を使う場合は、この機能が必要になります。
| **システム レベルの通話履歴へのアクセス** | 制限された機能 **phoneCallHistorySystem** を使うと、アプリは通話履歴を完全に変更できます (既存のエントリの変更や新しいエントリの作成など)。<br /><br />[
            **Windows.ApplicationModel.Calls**](https://msdn.microsoft.com/library/windows/apps/Dn297266) 名前空間の API を使う場合は、この機能が必要になります。
| **テキスト メッセージの送信**\* | 制限された機能 **smsSend** を使うと、アプリは SMS メッセージや MMS メッセージを送信できます。<br /><br />[
            **Windows.ApplicationModel.Chat**](https://msdn.microsoft.com/library/windows/apps/Dn642321) 名前空間の API を使う場合は、この機能が必要になります。
| **システム レベルのすべてのユーザー データへのアクセス** | 制限された機能 **userDataSystem** を使うと、アプリはシステム データ ストアに保存されているユーザー データへのアクセスが可能になります。
| **ストア プレビュー機能** | 制限された機能 **previewStore** を使うと、アプリはアプリ内製品の SKU の取得や購入ができます。<br /><br />[
            **Windows.ApplicationModel.Store.Preview**](https://msdn.microsoft.com/library/windows/apps/Mt185546) 名前空間の特定の API を使う場合は、この機能が必要になります。
| **初回サインイン時の設定** | 制限された機能 **firstSignInSettings** を使うと、アプリは、ユーザーが初めてデバイスにサインインしたときに設定されたユーザー設定にアクセスできます。
| **Windows チーム エクスペリエンス** | 制限された機能 **teamEditionExperience** を使うと、アプリは、Windows チーム セッションの多くの経験的側面を制御する内部 API にアクセスできます。 Windows チーム セッションは、Microsoft Surface Hub など、チーム デバイスで実行されている可能性があります。
| **リモート ロック解除** | 制限された機能 **remotePassportAuthentication** を使うと、アプリは、リモート PC のロック解除に使用される資格情報にアクセスできます。
| **コンポジションのプレビュー** | 制限された機能 **previewUiComposition** を使うと、アプリはユーザー インターフェイスの [**Windows.UI.Composition**](https://msdn.microsoft.com/library/windows/apps/Dn706878) 名前空間をプレビューすることで、完成前に API に関するフィードバックを提供できます。 詳しくは、wincomposition@microsoft.com にお問い合わせください。
| **安全な評価のためのロックダウン** | 制限された機能 **secureAssessment** を使うと、アプリは安全な評価のために単一アプリ モードに Windows をロックダウンできます。
| **接続マネージャーのプロビジョニング** | 制限された機能 **networkConnectionManagerProvisioning** を使うと、アプリは、デバイスを WWAN および WLAN インターフェイスに接続するポリシーを定義できます。 この機能を使うアプリは、携帯電話会社が作成し、モバイル ネットワークへのデバイス接続を管理します。
| **データ通信プランのプロビジョニング** | 制限された機能 **networkDataPlanProvisioning** を使うと、アプリは、デバイスのデータ プランに関する情報を収集し、ネットワーク使用状況を読み取れます。 この機能を使うアプリは、携帯電話会社が作成し、ユーザーの実際のデータ使用量を OS データ使用量の設定に統合します。
| **ソフトウェア ライセンス** | 制限された機能 **slapiQueryLicenseValue** を使うと、アプリは、ソフトウェア ライセンス ポリシーにクエリを実行できます。
| **延長実行** | 制限された機能 **extendedExecutionBackgroundAudio** を使うと、アプリがフォアグラウンドにないとき、アプリはオーディオを再生できます。<br /><br />制限された機能 **extendedExecutionCritical** を使うと、アプリは重要な延長実行セッションを開始できます。<br /><br />制限された機能 **extendedExecutionUnconstrained** を使うと、アプリは制限のない延長実行セッションを開始できます。
| **モバイル デバイス管理** | 制限された機能 **deviceManagementDmAccount** を使うと、アプリは、携帯電話会社の Open Mobile Alliance - Device Management (MO OMA-DM) アカウントをプロビジョニング、構成できます。<br /><br />制限された機能 **deviceManagementFoundation** を使うと、アプリは、デバイスのモバイル デバイス管理 (MDM) 構成サービス プロバイダー (CSP) インフラストラクチャへの基本的なアクセスが可能になります。 他の機能は、特定の CSP にアクセスする必要があることに注意してください。<br /><br />制限された機能 **deviceManagementWapSecurityPolicies** を使うと、アプリは、ワイヤレス アプリケーション プロトコル (WAP) ベースのサービス (MM、Service Indication/Service Loading (SI/SL)、Open Mobile Alliance - Client Provisioning (OMA-CP) など) を構成できます。<br /><br />制限された機能 **deviceManagementEmailAccount** を使うと、携帯電話会社が作成したアプリは、ユーザーにプロビジョニングするデバイス上の電子メール アカウントを追加および管理できます。
| **パッケージ ポリシー制御** | 制限された機能 **packagePolicySystem** を使うと、アプリは、デバイスにインストールされたアプリに関連するシステム ポリシーを制御できます。
| **ゲームの一覧** | 制限された機能 **gameList** を使うと、アプリはシステムにインストールされた既知のゲームの一覧を取得できます。
| **Xbox アクセサリ** | 制限された機能 **xboxAccessoryManagement** を使うと、アプリは Xbox ハードウェア仕様に準拠した Xbox デバイスを直接管理できます。
| **アクセサリの音声認識** | 制限された機能 **cortanaSpeechAccessory** を使うと、アプリはコマンドを呼び出して Cortana に渡すことができます。
| **アクセサリ管理** | 制限された機能 **accessoryManager** を使うと、アプリはアクセサリ アプリや特定のアプリ通知のオプトインとしての登録が可能になり、アクセサリに転送したり、ユーザーに表示したりできるようになります。
| **ドライバー アクセス** | 制限された機能 **interopServices** を使うと、アプリはデバイスと直接やり取りできます。
| **フォアグラウンドの監視** | 制限された機能 **inputForegroundObservation** を使うと、アプリはフォアグラウンドでキーボード入力を傍受でき、アプリ以外へのすべてのキーボード入力の処理を省くことができます。 SAS の組み合わせはこの機能により傍受することはできません。 この機能は、[**KeyboardDeliveryInterceptor**](https://msdn.microsoft.com/library/windows/apps/Mt608395) クラスのメンバーにアクセスするために必要です。
| **OEM および MO のパートナー アプリ** | 制限された機能 **oemDeployment** を使うと、Microsoft パートナー製のアプリは、新しいアプリをインストールし、デバイスに現在インストールされているアプリを照会できます。<br /><br />制限された機能 **oemPublicDirectory** を使うと、Microsoft パートナー製のアプリは、共有アプリ フォルダーにアクセスできます。
| **ユーザー データ アカウント プロバイダー** | 制限された機能 **userDataAccountsProvider** を使うと、アプリはメール、カレンダー、連絡先のアカウントを完全に管理できます。
| **アプリのライセンス** | 制限された機能 **appLicensing** を使うと、ライセンスの必要なくアプリを実行できます。 マニフェストにこの機能を宣言している場合、ストアにアプリを提出することはできません。 ストアへの提出を目的とするこの機能へのアクセス要求は、常に拒否されます。
| **場所システム**| 制限された機能 **LocationSystem** を使うと、アプリは特権のある特定の場所の構成 (デバイスの既定の場所の設定など) を実行できます。 マニフェストにこの機能を宣言している場合、ストアにアプリを提出することはできません。 ストアへの提出を目的とするこの機能へのアクセス要求は、常に拒否されます。
| **ユーザー データ アカウント プロバイダー**| 制限された機能 **userDataAccountsProvider** を使うと、アプリはメール、カレンダー、連絡先のアカウントを完全に管理できます。



**注**  
この記事は、UWP アプリを作成する Windows 10 開発者を対象としています。 Windows 8.x 用または Windows Phone 8.x 用の開発を行っている場合は、[アーカイブされているドキュメント](http://go.microsoft.com/fwlink/p/?linkid=619132) をご覧ください。

## 関連トピック

* [マニフェスト デザイナー](https://msdn.microsoft.com/en-us/library/windows/apps/xaml/br230259.aspx)
* [個人データにアクセスするアプリのガイドライン](https://msdn.microsoft.com/library/windows/apps/Hh768223)
* [パッケージ マニフェストで機能を指定する方法](https://msdn.microsoft.com/library/windows/apps/BR211477)
* [パッケージ マニフェストでデバイス機能を指定する方法](https://msdn.microsoft.com/library/windows/apps/Dn263092)
 



<!--HONumber=Jun16_HO5-->


