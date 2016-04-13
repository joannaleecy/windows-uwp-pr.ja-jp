---
ms.assetid: 25B18BA5-E584-4537-9F19-BB2C8C52DFE1
title: アプリ機能の宣言
description: 一部の API またはピクチャ、ミュージック、デバイス (カメラ、マイクなど) などのリソースにアクセスするには、機能をユニバーサル Windows プラットフォーム (UWP) アプリのパッケージ マニフェストで宣言する必要があります。
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

<table>
        <thead>
            <tr>
                <th>機能のシナリオ</th>
                <th>機能の使用法</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>**音楽***</td>
                <td>
                    The **musicLibrary** capability provides programmatic access to the user's Music, allowing the app to enumerate and access all files in the library without user interaction. This capability is typically used in jukebox apps that make use of the entire Music library.

                    The [**file picker**](https://msdn.microsoft.com/library/windows/apps/BR207847) provides a robust UI mechanism that lets users open files for use with an app. Declare the **musicLibrary** capability only when the scenarios for your app require programmatic access and can't be realized by using the **file picker**.

                    The **musicLibrary** capability must include the **uap** namespace when you declare it in your app's package manifest as shown below.
                    <table>
                        <thead>
                            <tr>
                                <th>XML</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>
                                    <pre><code>&lt;Capabilities&gt;
    &lt;uap:Capability Name="musicLibrary"/&gt;
&lt;/Capabilities&gt;</code></pre>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
            <tr>
                <td>**画像***</td>
                <td>
                    **picturesLibrary** 機能は、ユーザーの画像へのプログラムによるアクセスを提供します。これによって、ユーザーの操作なしで、ライブラリ内のすべてのファイルを列挙してそれらのファイルにアクセスできます。 通常、この機能は、画像ライブラリ全体を利用する写真再生アプリで使われます。

                    The [**file picker**](https://msdn.microsoft.com/library/windows/apps/BR207847) provides a robust UI mechanism that lets users open files for use with an app. Declare the **picturesLibrary** capability only when the scenarios for your app require programmatic access and can't be realized them by using the **file picker**.

                    The **picturesLibrary** capability must include the **uap** namespace when you declare it in your app's package manifest as shown below.
                    <table>
                        <thead>
                            <tr>
                                <th>XML</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>
<pre><code>&lt;Capabilities&gt;
    &lt;uap:Capability Name="picturesLibrary"/&gt;
&lt;/Capabilities&gt;</code></pre>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
            <tr>
                <td>**ビデオ***</td>
                <td>
                    The **videosLibrary** capability provides programmatic access to the user's Videos, allowing the app to enumerate and access all files in the library without user interaction. This capability is typically used in movie-playback apps that make use of the entire Videos library.

                    The [**file picker**](https://msdn.microsoft.com/library/windows/apps/BR207847) provides a robust UI mechanism that lets users open files for use with an app. Declare the **videosLibrary** capability only when the scenarios for your app require programmatic access and can't be realized by using the **file picker**.

                    The **videosLibrary** capability must include the **uap** namespace when you declare it in your app's package manifest as shown below.
                    <table>
                        <thead>
                            <tr>
                                <th>XML</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>
<pre><code>&lt;Capabilities&gt;
    &lt;uap:Capability Name="videosLibrary"/&gt;
&lt;/Capabilities&gt;</code></pre>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
            <tr>
                <td>**リムーバブル記憶域**</td>
                <td>
                    The **removableStorage** capability provides programmatic access to files on removable storage, like USB keys and external hard drives, filtered to the file-type associations declared in the package manifest. For example, if a document-reader app declares a .doc file-type association, it can open .doc files on the removable storage device, but not other types of files. Be careful when you declare this capability, because users may include a variety of info in their removable storage devices, and will expect your app to provide a valid justification for programmatic access to the removable storage for all files of the declared type.

                    Users will expect your app to handle any file associations that you declare. So don't declare file associations that your app cannot handle responsibly. The [**file picker**](https://msdn.microsoft.com/library/windows/apps/BR207847) provides a robust UI mechanism that lets users open files for use with an app.

                    Declare the **removableStorage** capability only when the scenarios for your app require programmatic access and can't be realized by using the [**file picker**](https://msdn.microsoft.com/library/windows/apps/BR207847).

                    The **removableStorage** capability must include the **uap** namespace when you declare it in your app's package manifest as shown below.
                    <table>
                        <thead>
                            <tr>
                                <th>XML</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>
<pre><code>&lt;Capabilities&gt;
    &lt;uap:Capability Name="removableStorage"/&gt;
&lt;/Capabilities&gt;</code></pre>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
            <tr>
                <td>**インターネットとパブリック ネットワーク***</td>
                <td>
                    There are two capabilities that provide different levels of access to the Internet and public networks.

                    The **internetClient** capability indicates that apps can receive incoming data from the Internet. Cannot act as a server. No local network access.

                    The **internetClientServer** capability indicates that apps can receive incoming data from the Internet. Can act as a server. No local network access.

                    Most apps that have a web service component will use **internetClient**. Apps that enable peer-to-peer (P2P) scenarios where the app needs to listen for incoming network connections should use **internetClientServer**. The **internetClientServer** capability includes the access that the **internetClient** capability provides, so you don't need to specify **internetClient** when you specify **internetClientServer**.
                </td>
            </tr>
            <tr>
                <td>**Homes and work networks***</td>
                <td>
                    The **privateNetworkClientServer** capability provides inbound and outbound access to home and work networks through the firewall. This capability is typically used for games that communicate across the local area network (LAN), and for apps that share data across a variety of local devices. If your app specifies **musicLibrary**, **picturesLibrary**, or **videosLibrary**, you don't need to use this capability to access the corresponding library in a Home Group. On Windows, this capability does not provide access to the Internet.
                </td>
            </tr>
            <tr>
                <td>**Appointments**</td>
                <td>
                    The **appointments** capability provides access to the user’s appointment store. This capability allows read access to appointments obtained from the synced network accounts and to other apps that write to the appointment store. With this capability, your app can create new calendars and write appointments to calendars that it creates.

                    The **appointments** capability must include the **uap** namespace when you declare it in your app's package manifest as shown below.
                    <table>
                        <thead>
                            <tr>
                                <th>XML</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>
<pre><code>&lt;Capabilities&gt;
    &lt;uap:Capability Name="appointments"/&gt;
&lt;/Capabilities&gt;</code></pre>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
            <tr>
                <td>**連絡先***</td>
                <td>
                    The **contacts** capability provides access to the aggregated view of the contacts from various contacts stores. This capability gives the app limited access (network permitting rules apply) to contacts that were synced from various networks and the local contact store.

                    The **contacts** capability must include the **uap** namespace when you declare it in your app's package manifest as shown below.
                    <table>
                        <thead>
                            <tr>
                                <th>XML</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>
<pre><code>&lt;Capabilities&gt;
    &lt;uap:Capability Name="contacts"/&gt;
&lt;/Capabilities&gt;</code></pre>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
            <tr>
                <td>**コード生成**</td>
                <td>
                    The **codeGeneration** capability allows apps to access the following functions which provide JIT capabilities to apps.

                    - [**VirtualProtectFromApp**](https://msdn.microsoft.com/library/windows/desktop/Mt169846)
                    - [**CreateFileMappingFromApp**](https://msdn.microsoft.com/library/windows/desktop/Hh994453)
                    - [**OpenFileMappingFromApp**](https://msdn.microsoft.com/library/windows/desktop/Mt169844)
                    - [**MapViewOfFileFromApp**](https://msdn.microsoft.com/library/windows/desktop/Hh994454)
                </td>
            </tr>
            <tr>
                <td>**AllJoyn**</td>
                <td>
                    The **allJoyn** capability allows AllJoyn-enabled apps and devices on a network to discover and interact with each other.

                    All apps that access APIs in the [**Windows.Devices.AllJoyn**](https://msdn.microsoft.com/library/windows/apps/Dn894971) namespace must use this capability.
                </td>
            </tr>
            <tr>
                <td>**Phone calls**</td>
                <td>
                    The **phoneCall** capability allows apps to access all of the phone lines on the device and perform the following functions.

                    - Place a call on the phone line and show the system dialer without prompting the user.
                    - Access line-related metadata.
                    - Access line-related triggers.
                    - Allows the user-selected spam filter app to set and check block list and call origin information.

                    The **phoneCall** capability must include the **uap** namespace when you declare it in your app's package manifest as shown below.
                    <table>
                        <thead>
                            <tr>
                                <th>XML</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>
<pre><code>&lt;Capabilities&gt;
    &lt;uap:Capability Name="phoneCall"/&gt;
&lt;/Capabilities&gt;</code></pre>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    The **phoneCallHistoryPublic** capability allows apps to read cellular and some VOIP call history information on the device. This capability also allows the app to write VOIP call history entries. This capability is required to access all members of the [**PhoneCallHistoryStore**](https://msdn.microsoft.com/library/windows/apps/Dn705931) class.
                </td>
            </tr>
            <tr>
                <td>**通話が録音されているフォルダー***</td>
                <td>
                    <p>**recordedCallsFolder** デバイス機能を使うと、アプリは通話が録音されているフォルダーにアクセスできます。</p>
                    <p>アプリのパッケージ マニフェストで宣言するとき、以下に示すように、**recordedCallsFolder** 機能に **mobile** 名前空間を含める必要があります。</p>
                    <table>
                        <thead>
                            <tr>
                                <th>XML</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>
                                    <pre><code>&lt;Capabilities&gt;
    &lt;mobile:Capability Name="recordedCallsFolder"/&gt;
&lt;/Capabilities&gt;</code></pre>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
            <tr>
                <td>**エンド アカウント情報***</td>
                <td>
                    <p>**userAccountInformation** 機能を使うと、アプリはユーザーの名前と画像にアクセスできるようになります。</p>
                    <p>Windows.System.User 名前空間の一部の API にアクセスする場合は、この機能が必要になります。</p>
                    <p>アプリのパッケージ マニフェストで宣言するとき、以下に示すように、**userAccountInformation** 機能に **uap** 名前空間を含める必要があります。</p>
                    <table>
                        <colgroup>
                            <col width="100%" />
                        </colgroup>
                        <thead>
                            <tr>
                                <th>XML</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>
                                    <pre><code>&lt;Capabilities&gt;
    &lt;uap:Capability Name="userAccountInformation"/&gt;
&lt;/Capabilities&gt;</code></pre>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
            <tr>
                <td>**VOIP 呼び出し**</td>
                <td>
                    <p>**voipCall** 機能を使うと、アプリは [**Windows.ApplicationModel.Calls**](https://msdn.microsoft.com/library/windows/apps/Dn297266) 名前空間の VOIP 呼び出し API にアクセスできます。</p>
                    <p>アプリのパッケージ マニフェストで宣言するとき、以下に示すように、**voipCall** 機能に **uap** 名前空間を含める必要があります。</p>
                    <table>
                        <colgroup>
                            <col width="100%" />
                        </colgroup>
                        <thead>
                            <tr>
                                <th>XML</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>
                                    <pre><code>&lt;Capabilities&gt;
    &lt;uap:Capability Name="voipCall"/&gt;
&lt;/Capabilities&gt;</code></pre>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
            <tr>
                <td>**3D オブジェクト**</td>
                <td>
                    <p>**objects3D** 機能を使用すると、アプリは 3D オブジェクト ファイルにプログラムでアクセスできます。 通常、この機能は、3D オブジェクト ライブラリ全体にアクセスする必要がある 3D アプリやゲームで使用されます。</p>
                    <p>[
            **Windows.Storage**](https://msdn.microsoft.com/library/windows/apps/BR227346) 名前空間の API を使って 3D オブジェクトを含むフォルダーにアクセスする場合は、この機能が必要になります。</p>
                    <p>アプリのパッケージ マニフェストで宣言するとき、以下に示すように、**objects3D** 機能に **uap** 名前空間を含める必要があります。</p>
                    <table>
                        <colgroup>
                            <col width="100%" />
                        </colgroup>
                        <thead>
                            <tr>
                                <th>XML</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>
                                    <pre><code>&lt;Capabilities&gt;
    &lt;uap:Capability Name="objects3d"/&gt;
&lt;/Capabilities&gt;</code></pre>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
            <tr>
                <td>**ブロックされているメッセージの読み取り***</td>
                <td>
                    <p>**blockedChatMessages** 機能を使うと、アプリはスパム フィルター アプリでブロックされた SMS メッセージや MMS メッセージを読み取ることができます。</p>
                    <p>[
            **Windows.ApplicationModel.Chat**](https://msdn.microsoft.com/library/windows/apps/Dn642321) 名前空間の API を使ってブロックされたメッセージにアクセスする場合は、この機能が必要になります。</p>
                    <p>アプリのパッケージ マニフェストで宣言するとき、以下に示すように、**blockedChatMessages** 機能に **uap** 名前空間を含める必要があります。</p>
                    <table>
                        <colgroup>
                            <col width="100%" />
                        </colgroup>
                        <thead>
                            <tr>
                                <th>XML</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>
                                    <pre><code>&lt;Capabilities&gt;
    &lt;uap:Capability Name="blockedChatMessages"/&gt;
&lt;/Capabilities&gt;</code></pre>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
            <tr>
                <td>**チャット メッセージ アクセス**</td>
                <td>
                    <p>**チャット**機能を使うと、アプリはテキスト メッセージの読み取りと削除を実行できます。 また、この機能を使うと、アプリはチャット メッセージをシステム データ ストアに保存できます。</p>
                    <p>[
            **Windows.ApplicationModel.Chat**](https://msdn.microsoft.com/library/windows/apps/Dn642321) 名前空間の一部の API を使う場合は、この機能が必要になります。</p>
                    <p>アプリのパッケージ マニフェストで宣言するとき、以下に示すように、**chat** 機能に **uap** 名前空間を含める必要があります。</p>
                    <table>
                        <colgroup>
                            <col width="100%" />
                        </colgroup>
                        <thead>
                            <tr>
                                <th>XML</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>
                                    <pre><code>&lt;Capabilities&gt;
    &lt;uap:Capability Name="chat"/&gt;
&lt;/Capabilities&gt;</code></pre>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
            <tr>
                <td>**IoT 下位レベルのバス ハードウェア**</td>
                <td>
                    <p>**lowLevelDevices** 機能を使うと、IoT デバイスで動作するアプリは、下位レベルのバス ハードウェア (GPIO、I2C、SPI、ADC、PWM など) にアクセスできるようになります。</p>
                    <p>[
            **Windows.Devices.Spi**](https://msdn.microsoft.com/library/windows/apps/Dn708178) 名前空間の一部の API にアクセスする場合は、この機能が必要になります。</p>
                    <p>アプリのパッケージ マニフェストで宣言するとき、以下に示すように、**lowLevelDevices** 機能に **iot** 名前空間を含める必要があります。</p>
                    <table>
                        <colgroup>
                            <col width="100%" />
                        </colgroup>
                        <thead>
                            <tr>
                                <th>XML</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>
                                    <pre><code>&lt;Capabilities&gt;
    &lt;iot:Capability Name="lowLevelDevices"/&gt;
&lt;/Capabilities&gt;</code></pre>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
            <tr>
                <td>**IoT システム管理**</td>
                <td>
                    <p>**systemManagement** 機能を使うと、アプリは基本的なシステム管理者特権 (シャットダウン、再起動、ロケール、タイムゾーンなど) を持つことができます。</p>
                    <p>[
            **Windows.System**](https://msdn.microsoft.com/library/windows/apps/BR241814) 名前空間の一部の API にアクセスする場合は、この機能が必要になります。</p>
                    <p>アプリのパッケージ マニフェストで宣言するとき、以下に示すように、**systemManagement** 機能に **iot** 名前空間を含める必要があります。</p>
                    <table>
                        <colgroup>
                            <col width="100%" />
                        </colgroup>
                        <thead>
                            <tr>
                                <th>XML</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>
                                    <pre><code>&lt;Capabilities&gt;
    &lt;iot:Capability Name="systemManagement"/&gt;
&lt;/Capabilities&gt;</code></pre>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
        </tbody>
</table>

 
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

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">機能のシナリオ</th>
<th align="left">機能の使用法</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left">**エンタープライズ**</td>
<td align="left"><p>Windows ドメイン資格情報により、ユーザーはそれぞれの資格情報を使ってリモートのリソースにログインし、ユーザー名とパスワードを指定したかのように動作できます。 通常、特殊な機能 **enterpriseAuthentication** は、企業内のサーバーに接続する基幹業務アプリで使われます。</p>
<p>インターネット上での汎用通信にはこの機能は不要です。</p>

<p>特殊な機能 **enterpriseAuthentication** は、一般的な基幹業務アプリをサポートするための機能です。 企業リソースにアクセスする必要がないアプリでは宣言しないでください。 [
            **ファイル ピッカー**](https://msdn.microsoft.com/library/windows/apps/BR207847) は、アプリで使うネットワーク共有上のファイルをユーザーが開くことができる強力な UI メカニズムを提供します。 **enterpriseAuthentication** 機能を宣言するのは、プログラムによるアクセスを必要とするアプリのシナリオを**ファイル ピッカー**では実現できない場合だけにしてください。</p>
<p>アプリのパッケージ マニフェストで宣言するとき、以下に示すように、**enterpriseAuthentication** 機能に **uap** 名前空間を含める必要があります。</p>
<div class="code">
<span codelanguage="XML"></span>
<table>
<colgroup>
<col width="100%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">XML</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><pre><code>&lt;Capabilities&gt;
    &lt;uap:Capability Name="enterpriseAuthentication"/&gt;
&lt;/Capabilities&gt;</code></pre></td>
</tr>
</tbody>
</table>
</div>
<p>**enterpriseDataPolicy** 機能を使うと、アプリはデバイス用に企業固有のポリシーを定義して使えます。 この機能は、次のクラスのすべてのメンバーを使うために必要です。</p>
<ul>
<li>[**FileProtectionManager**](https://msdn.microsoft.com/library/windows/apps/Dn705151)</li>
<li>[**DataProtectionManager**](https://msdn.microsoft.com/library/windows/apps/Dn706017)</li>
<li>[**ProtectionPolicyManager**](https://msdn.microsoft.com/library/windows/apps/Dn705170)</li>
</ul></td>
</tr>
<tr class="even">
<td align="left">**ユーザー証明書の共有**</td>
<td align="left"><p>特殊な機能 **sharedUserCertificates** を使って、アプリは共有ユーザー ストア内のソフトウェアベースおよびハードウェアベースの証明書 (スマート カードに格納されている証明書など) を追加したり、それらの証明書にアクセスしたりできます。 通常、この機能は、認証にスマート カードを必要とする財務アプリまたはエンタープライズ アプリで使われます。</p>
<p>アプリのパッケージ マニフェストで宣言するとき、以下に示すように、**sharedUserCertificates** 機能に **uap** 名前空間を含める必要があります。</p>
<div class="code">
<span codelanguage="XML"></span>
<table>
<colgroup>
<col width="100%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">XML</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><pre><code>&lt;Capabilities&gt;
    &lt;uap:Capability Name="sharedUserCertificates"/&gt;
&lt;/Capabilities&gt;</code></pre></td>
</tr>
</tbody>
</table>
</div></td>
</tr>
<tr class="odd">
<td align="left">**ドキュメント***</td>
<td align="left"><p>特殊な機能 **documentsLibrary** は、パッケージ マニフェストで宣言されたファイルの種類の関連付けに限定された、ユーザーのドキュメントへのプログラムによるアクセスを提供し、OneDrive へのオフライン アクセスをサポートします。 たとえば、DOC リーダー アプリで .doc ファイルの種類の関連付けを宣言すると、ドキュメント フォルダー内の .doc ファイルを開くことはできますが、他の種類のファイルを開くことはできません。</p>
<p>特殊な機能 **documentsLibrary** を宣言するアプリは、ホーム グループ コンピューター上のドキュメント フォルダーにアクセスできません。 [
            file picker](https://msdn.microsoft.com/library/windows/apps/Hh465174) は、アプリで使うファイルをユーザーが開くことができる強力な UI メカニズムを提供します。 特殊な機能 **documentsLibrary** は、ファイル ピッカーを使えない場合のみ宣言します。</p>
<p>特殊な機能 **documentsLibrary** を使うにはアプリが次の条件を満たしている必要があります。</p>
<ul>
<li>有効な OneDrive URL またはリソース ID を使った、特定の OneDrive コンテンツへのクロスプラットフォーム オフライン アクセスを容易にする</li>
<li>オフライン時に、開いているファイルをユーザーの OneDrive に自動的に保存する</li>
</ul>
<p>これらの 2 つの目的で特殊な機能 **documentsLibrary** を使うアプリと、別のドキュメントに埋め込まれているコンテンツを開く機能を使うこともできます。 特殊な機能 **documentsLibrary** の上記の使用方法のみが許可されています。</p>
<ul>
<li><p>アプリは、電話の内部ストレージにあるドキュメント ライブラリにはアクセスできません。 ただし、別のアプリによってオプションの SD カード上にドキュメント フォルダーが作られた場合は、アプリでそのフォルダーを表示できます。</p></li>
</ul>
<p>アプリのパッケージ マニフェストで宣言するとき、以下に示すように、**documentsLibrary** 機能に **uap** 名前空間を含める必要があります。</p>
<div class="code">
<span codelanguage="XML"></span>
<table>
<colgroup>
<col width="100%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">XML</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><pre><code>&lt;Capabilities&gt;
    &lt;uap:Capability Name="documentsLibrary"/&gt;
&lt;/Capabilities&gt;</code></pre></td>
</tr>
</tbody>
</table>
</div></td>
</tr>
<tr class="even">
<td align="left">**ゲーム DVR 設定**</td>
<td align="left"><p>制限された機能 **appCaptureSettings** を使うと、アプリはゲーム DVR のユーザー設定を制御できます。</p>
<p>[
            **Windows.Media.Capture**](https://msdn.microsoft.com/library/windows/apps/BR226738) 名前空間の一部の API を使う場合は、この機能が必要になります。</p></td>
</tr>
<tr class="odd">
<td align="left">**携帯電話**</td>
<td align="left"><p>制限された機能 **cellularDeviceControl** を使うと、アプリは携帯デバイスを制御できます。</p>
<p>**cellularDeviceIdentity** 機能を使うと、アプリは携帯デバイスの ID データにアクセスできます。</p>
<p>**cellularMessaging** 機能を使うと、アプリは SMS と RCS を利用できます。</p>
<p>[
            **Windows.Devices.Sms**](https://msdn.microsoft.com/library/windows/apps/BR206567) 名前空間の一部の API を使う場合は、これらの機能が必要になります。</p>
<p>Windows 10 以降、[**AppIDList**](https://msdn.microsoft.com/library/windows/apps/Dn393996) を呼び出すアプリ。</p></td>
</tr>
<tr class="even">
<td align="left">**デバイスのロック解除**</td>
<td align="left"><p>制限された機能 **deviceUnlock** を使うと、アプリは、開発者サイドローディングのシナリオやエンタープライズ サイドローディングのシナリオ向けにデバイスをロック解除できます。</p></td>
</tr>
<tr class="odd">
<td align="left">**デュアル SIM タイル**</td>
<td align="left"><p>制限された機能 **dualSimTiles** を使うと、アプリは、複数の SIM を備えたデバイスでアプリ一覧の追加のエントリを作成できます。</p>
<p>[
            **Windows.UI.StartScreen**](https://msdn.microsoft.com/library/windows/apps/BR242235) 名前空間の一部の API を使う場合は、この機能が必要になります。</p></td>
</tr>
<tr class="even">
<td align="left">**エンタープライズ共有記憶域**</td>
<td align="left"><p>制限された機能 **enterpriseDeviceLockdown** を使うと、アプリは、デバイスのロック ダウン API を利用したり、企業で共有している保存フォルダーにアクセスしたりすることができます。</p></td>
</tr>
<tr class="odd">
<td align="left">**システム入力の挿入**</td>
<td align="left"><p>制限された機能 **inputInjection** を使うと、アプリは、さまざまな形式の入力 (HID、タッチ、ペン、キーボード、マウスなど) をプログラムでシステムに挿入できます。 通常、この機能はシステムを制御できる共同作業アプリで使われます。</p>
<div class="alert">
**注**  PC の場合、この機能を使ったアプリからの入力の挿入は、同じアプリ コンテナー内のプロセスによってのみ許可されます。
</div>
</td>
</tr>
<tr class="even">
<td align="left">**入力の監視***</td>
<td align="left"><p>制限された機能 **inputObservation** を使うと、アプリは、さまざまな形式の未加工入力 (HID、タッチ、ペン、キーボード、マウスなど) が、最終的な宛先に関係なく、システムによって許可されるのを監視できます。</p></td>
</tr>
<tr class="odd">
<td align="left">**入力の抑制**</td>
<td align="left"><p>制限された機能 **inputSuppression** を使うと、アプリは、さまざまな形式の未加工入力 (HID、タッチ、ペン、キーボード、マウスなど) が、システムによって許可されるのを抑制できます。</p></td>
</tr>
<tr class="even">
<td align="left">**VPN アプリ**</td>
<td align="left"><p>制限された機能 **networkingVpnProvider** を使うと、アプリは VPN 機能 (接続の管理や VPN プラグイン機能の提供など) へのフル アクセスが可能になります。</p>
<p>[
            **Windows.Networking.Vpn**](https://msdn.microsoft.com/library/windows/apps/Dn434040) 名前空間の一部の API を使う場合は、この機能が必要になります。</p></td>
</tr>
<tr class="odd">
<td align="left">**他のアプリの管理**</td>
<td align="left"><p>制限された機能 **packageManagement** を使うと、アプリは他のアプリを直接管理できます。</p>
<p>**packageQuery** デバイス機能を使うと、アプリは他のアプリに関する情報を収集できます。</p>
<p>[
            **PackageManager**](https://msdn.microsoft.com/library/windows/apps/BR240960) クラスの一部のメソッドとプロパティにアクセスする場合は、これらの機能が必要になります。</p></td>
</tr>
<tr class="even">
<td align="left">**画面の投影**</td>
<td align="left"><p>制限された機能 **ScreenDuplication** を使うと、アプリは画面を別のデバイスに表示できます。</p>
<p>DirectX 名前空間の API を使う場合は、この機能が必要になります。</p></td>
</tr>
<tr class="odd">
<td align="left">**ユーザー プリンシパル名**</td>
<td align="left"><p>制限された機能 **userPrincipalName** を使うと、アプリは、写真に基づく縮小表示のキャッシュを変更したり、このキャッシュにアクセスしたりすることができます。</p>
<p>[
            **GetUserNameEx**](https://msdn.microsoft.com/library/windows/desktop/ms724435) 関数を呼び出す場合は、この機能が必要になります。</p></td>
</tr>
<tr class="even">
<td align="left">**ウォレット**</td>
<td align="left"><p>制限された機能 **walletSystem** を使うと、アプリは保存されたウォレット カードへのフル アクセスが可能になります。</p>
<p>[
            **Windows.ApplicationModel.Wallet.System**](https://msdn.microsoft.com/library/windows/apps/Mt171610) 名前空間の API を使う場合は、この機能が必要になります。</p></td>
</tr>
<tr class="odd">
<td align="left">**位置情報の履歴**</td>
<td align="left"><p>制限された機能 **locationHistory** を使うと、アプリはデバイスの位置情報の履歴にアクセスできます。</p>
<p>[
            **Windows.Devices.Geolocation**](https://msdn.microsoft.com/library/windows/apps/BR225603) 名前空間の API を使う場合は、この機能が必要になります。</p></td>
</tr>
<tr class="even">
<td align="left">**アプリを閉じる確認**</td>
<td align="left"><p>制限された機能 **confirmAppClose** を使うと、アプリはアプリ自体とアプリ独自のウィンドウを閉じたり、アプリを閉じることを遅延させたりすることができます。</p>
<p>[
            **Windows.UI.ViewManagement**](https://msdn.microsoft.com/library/windows/apps/BR242295) 名前空間の API を使う場合は、この機能が必要になります。</p></td>
</tr>
<tr class="odd">
<td align="left">**通話履歴***</td>
<td align="left"><p>制限された機能 **phoneCallHistory** を使うと、アプリは通話履歴を読み取ったり、履歴のエントリを削除できます。</p>
<p>[
            **Windows.ApplicationModel.Chat**](https://msdn.microsoft.com/library/windows/apps/Dn642321) 名前空間の API を使う場合は、この機能が必要になります。</p></td>
</tr>
<tr class="even">
<td align="left">**システム レベルの予定へのアクセス**</td>
<td align="left"><p>制限された機能 **appointmentsSystem** を使うと、アプリはユーザーのカレンダーにあるすべての予定を読み取ったり、変更したりすることができます。</p>
<p>[
            **Windows.ApplicationModel.Appointment**](https://msdn.microsoft.com/library/windows/apps/Dn263359) 名前空間の API を使う場合は、この機能が必要になります。</p></td>
</tr>
<tr class="odd">
<td align="left">**システム レベルのチャット メッセージへのアクセス***</td>
<td align="left"><p>制限された機能 **chatSystem** を使うと、アプリはすべての SMS メッセージと MMS メッセージの読み取りと書き込みを実行できます。</p>
<p>[
            **Windows.ApplicationModel.Chat**](https://msdn.microsoft.com/library/windows/apps/Dn642321) 名前空間の API を使う場合は、この機能が必要になります。</p></td>
</tr>
<tr class="even">
<td align="left">**システム レベルの連絡先へのアクセス**</td>
<td align="left"><p>制限された機能 **contactsSystem** を使うと、アプリは制限付きの連絡先情報や機密性の高い連絡先情報を読み取ったり、既存の連絡先情報を変更したりすることができます。</p>
<p>[
            **Windows.ApplicationModel.Chat**](https://msdn.microsoft.com/library/windows/apps/Dn642321) 名前空間の API を使う場合は、この機能が必要になります。</p></td>
</tr>
<tr class="odd">
<td align="left">**メールへのアクセス***</td>
<td align="left"><p>制限された機能 **email** を使うと、アプリはユーザーのメールの読み取り、トリアージ、送信を実行できます。</p>
<p>[
            **Windows.ApplicationModel.Email**](https://msdn.microsoft.com/library/windows/apps/Dn631285) 名前空間の API を使う場合は、この機能が必要になります。</p></td>
</tr>
<tr class="even">
<td align="left">**システム レベルのメールへのアクセス**</td>
<td align="left"><p>制限された機能 **emailSystem** を使うと、アプリは制限つきのユーザーのメールや機密性の高いユーザーのメールの読み取り、トリアージ、送信を実行できます。</p>
<p>[
            **Windows.ApplicationModel.Email**](https://msdn.microsoft.com/library/windows/apps/Dn631285) 名前空間の API を使う場合は、この機能が必要になります。</p></td>
</tr>
<tr class="odd">
<td align="left">**システム レベルの通話履歴へのアクセス**</td>
<td align="left"><p>制限された機能 **phoneCallHistorySystem** を使うと、アプリは通話履歴を完全に変更できます (既存のエントリの変更や新しいエントリの作成など)。</p>
<p>[
            **Windows.ApplicationModel.Calls**](https://msdn.microsoft.com/library/windows/apps/Dn297266) 名前空間の API を使う場合は、この機能が必要になります。</p></td>
</tr>
<tr class="even">
<td align="left">**テキスト メッセージの送信***</td>
<td align="left"><p>制限された機能 **smsSend** を使うと、アプリは SMS メッセージや MMS メッセージを送信できます。</p>
<p>[
            **Windows.ApplicationModel.Chat**](https://msdn.microsoft.com/library/windows/apps/Dn642321) 名前空間の API を使う場合は、この機能が必要になります。</p></td>
</tr>
<tr class="odd">
<td align="left">**システム レベルのすべてのユーザー データへのアクセス**</td>
<td align="left"><p>制限された機能 **userDataSystem** を使うと、アプリはシステム データ ストアに保存されているユーザー データへのアクセスが可能になります。</p></td>
</tr>
<tr class="even">
<td align="left">**ストア プレビュー機能**</td>
<td align="left"><p>制限された機能 **previewStore** を使うと、アプリはアプリ内製品の SKU の取得や購入ができます。</p>
<p>[
            **Windows.ApplicationModel.Store.Preview**](https://msdn.microsoft.com/library/windows/apps/Mt185546) 名前空間の特定の API を使う場合は、この機能が必要になります。</p></td>
</tr>
<tr class="odd">
<td align="left">**初回サインイン時の設定**</td>
<td align="left"><p>制限された機能 **firstSignInSettings** を使うと、アプリは、ユーザーが初めてデバイスにサインインしたときに設定されたユーザー設定にアクセスできます。</p></td>
</tr>
<tr class="even">
<td align="left">**Windows チーム エクスペリエンス**</td>
<td align="left"><p>制限された機能 **teamEditionExperience** を使うと、アプリは、Windows チーム セッションの多くの経験的側面を制御する内部 API にアクセスできます。 Windows チーム セッションは、Microsoft Surface Hub など、チーム デバイスで実行されている可能性があります。</p></td>
</tr>
<tr class="odd">
<td align="left">**リモート ロック解除**</td>
<td align="left"><p>制限された機能 **remotePassportAuthentication** を使うと、アプリは、リモート PC のロック解除に使用される資格情報にアクセスできます。</p></td>
</tr>
<tr class="even">
<td align="left">**コンポジションのプレビュー**</td>
<td align="left"><p>制限された機能 **previewUiComposition** を使うと、アプリはユーザー インターフェイスの [**Windows.UI.Composition**](https://msdn.microsoft.com/library/windows/apps/Dn706878) 名前空間をプレビューすることで、完成前に API に関するフィードバックを提供できます。 詳しくは、wincomposition@microsoft.com にお問い合わせください。</p></td>
</tr>
<tr class="odd">
<td align="left">**安全な評価のためのロックダウン**</td>
<td align="left"><p>制限された機能 **secureAssessment** を使うと、アプリは安全な評価のために単一アプリ モードに Windows をロックダウンできます。</p></td>
</tr>
<tr class="even">
<td align="left">**接続マネージャーのプロビジョニング**</td>
<td align="left"><p>制限された機能 **networkConnectionManagerProvisioning** を使うと、アプリは、デバイスを WWAN および WLAN インターフェイスに接続するポリシーを定義できます。 この機能を使うアプリは、携帯電話会社が作成し、モバイル ネットワークへのデバイス接続を管理します。</p></td>
</tr>
<tr class="odd">
<td align="left">**データ通信プランのプロビジョニング**</td>
<td align="left"><p>制限された機能 **networkDataPlanProvisioning** を使うと、アプリは、デバイスのデータ プランに関する情報を収集し、ネットワーク使用状況を読み取れます。 この機能を使うアプリは、携帯電話会社が作成し、ユーザーの実際のデータ使用量を OS データ使用量の設定に統合します。</p></td>
</tr>
<tr class="even">
<td align="left">**ソフトウェア ライセンス**</td>
<td align="left"><p>制限された機能 **slapiQueryLicenseValue** を使うと、アプリは、ソフトウェア ライセンス ポリシーにクエリを実行できます。</p></td>
</tr>
<tr class="odd">
<td align="left">**延長実行**</td>
<td align="left"><p>制限された機能 **extendedExecutionBackgroundAudio** を使うと、アプリがフォアグラウンドにないとき、アプリはオーディオを再生できます。</p>
<p>制限された機能 **extendedExecutionCritical** を使うと、アプリは重要な延長実行セッションを開始できます。</p>
<p>制限された機能 **extendedExecutionUnconstrained** を使うと、アプリは制限のない延長実行セッションを開始できます。</p></td>
</tr>
<tr class="even">
<td align="left">**モバイル デバイス管理**</td>
<td align="left"><p>制限された機能 **deviceManagementDmAccount** を使うと、アプリは、携帯電話会社の Open Mobile Alliance - Device Management (MO OMA-DM) アカウントをプロビジョニング、構成できます。</p>
<p>制限された機能 **deviceManagementFoundation** を使うと、アプリは、デバイスのモバイル デバイス管理 (MDM) 構成サービス プロバイダー (CSP) インフラストラクチャへの基本的なアクセスが可能になります。 他の機能は、特定の CSP にアクセスする必要があることに注意してください。</p>
<p>制限された機能 **deviceManagementWapSecurityPolicies** を使うと、アプリは、ワイヤレス アプリケーション プロトコル (WAP) ベースのサービス (MM、Service Indication/Service Loading (SI/SL)、Open Mobile Alliance - Client Provisioning (OMA-CP) など) を構成できます。</p>
<p>制限された機能 **deviceManagementEmailAccount** を使うと、携帯電話会社が作成したアプリは、ユーザーにプロビジョニングするデバイス上の電子メール アカウントを追加および管理できます。</p></td>
</tr>
<tr class="odd">
<td align="left">**パッケージ ポリシー制御**</td>
<td align="left"><p>制限された機能 **packagePolicySystem** を使うと、アプリは、デバイスにインストールされたアプリに関連するシステム ポリシーを制御できます。</p></td>
</tr>
<tr class="even">
<td align="left">**ゲームの一覧**</td>
<td align="left"><p>制限された機能 **gameList** を使うと、アプリはシステムにインストールされた既知のゲームの一覧を取得できます。</p></td>
</tr>
<tr class="odd">
<td align="left">**Xbox アクセサリ**</td>
<td align="left"><p>制限された機能 **xboxAccessoryManagement** を使うと、アプリは Xbox ハードウェア仕様に準拠した Xbox デバイスを直接管理できます。</p></td>
</tr>
<tr class="even">
<td align="left">**アクセサリの音声認識**</td>
<td align="left"><p>制限された機能 **cortanaSpeechAccessory** を使うと、アプリはコマンドを呼び出して Cortana に渡すことができます。</p></td>
</tr>
<tr class="odd">
<td align="left">**アクセサリ管理**</td>
<td align="left"><p>制限された機能 **accessoryManager** を使うと、アプリはアクセサリ アプリや特定のアプリ通知のオプトインとしての登録が可能になり、アクセサリに転送したり、ユーザーに表示したりできるようになります。</p></td>
</tr>
<tr class="even">
<td align="left">**ドライバー アクセス**</td>
<td align="left"><p>制限された機能 **interopServices** を使うと、アプリはデバイスと直接やり取りできます。</p></td>
</tr>
<tr class="odd">
<td align="left">**フォアグラウンドの監視**</td>
<td align="left"><p>制限された機能 **inputForegroundObservation** を使うと、アプリはフォアグラウンドでキーボード入力を傍受でき、アプリ以外へのすべてのキーボード入力の処理を省くことができます。 SAS の組み合わせはこの機能により傍受することはできません。 この機能は、[**KeyboardDeliveryInterceptor**](https://msdn.microsoft.com/library/windows/apps/Mt608395) クラスのメンバーにアクセスするために必要です。</p></td>
</tr>
<tr class="even">
<td align="left">**OEM および MO のパートナー アプリ**</td>
<td align="left"><p>制限された機能 **oemDeployment** を使うと、Microsoft パートナー製のアプリは、新しいアプリをインストールし、デバイスに現在インストールされているアプリを照会できます。</p>
<p>制限された機能 **oemPublicDirectory** を使うと、Microsoft パートナー製のアプリは、共有アプリ フォルダーにアクセスできます。</p></td>
</tr>
<tr class="odd">
<td align="left">**アプリのライセンス**</td>
<td align="left"><p>制限された機能 **appLicensing** を使うと、ライセンスの必要なくアプリを実行できます。 マニフェストにこの機能を宣言している場合、ストアにアプリを提出することはできません。 ストアへの提出を目的とするこの機能へのアクセス要求は、常に拒否されます。</p></td>
</tr>
<tr class="even">
<td align="left">**場所システム**</td>
<td align="left"><p>制限された機能 **LocationSystem** を使うと、アプリは特権のある特定の場所の構成 (デバイスの既定の場所の設定など) を実行できます。 マニフェストにこの機能を宣言している場合、ストアにアプリを提出することはできません。 ストアへの提出を目的とするこの機能へのアクセス要求は、常に拒否されます。</p></td>
</tr>
</tbody>
</table>

**注**  
この記事は、UWP アプリを作成する Windows 10 開発者を対象としています。 Windows 8.x 用または Windows Phone 8.x 用の開発を行っている場合は、[アーカイブされているドキュメント](http://go.microsoft.com/fwlink/p/?linkid=619132) をご覧ください。

## 関連トピック

* [マニフェスト デザイナー](https://msdn.microsoft.com/en-us/library/windows/apps/xaml/br230259.aspx)
* [個人データにアクセスするアプリのガイドライン](https://msdn.microsoft.com/library/windows/apps/Hh768223)
* [パッケージ マニフェストで機能を指定する方法](https://msdn.microsoft.com/library/windows/apps/BR211477)
* [パッケージ マニフェストでデバイス機能を指定する方法](https://msdn.microsoft.com/library/windows/apps/Dn263092)
 


<!--HONumber=Mar16_HO5-->


