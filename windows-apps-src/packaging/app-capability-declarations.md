---
xx.xxxxxxx: YYXYYXXY-XYYY-YYYY-YXYY-XXYXYXYYXXXY
xxxxx: Xxx xxxxxxxxxx xxxxxxxxxxxx
xxxxxxxxxxx: Xxxxxxxxxxxx xxxx xx xxxxxxxx xx xxxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxx'x xxxxxxx xxxxxxxx xx xxxxxx xxxxxxx XXX xx xxxxxxxxx xxxx xxxxxxxx, xxxxx, xx xxxxxxx xxxx xxx xxxxxx xx xxx xxxxxxxxxx.
---
# Xxx xxxxxxxxxx xxxxxxxxxxxx

\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

Xxxxxxxxxxxx xxxx xx xxxxxxxx xx xxxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxx'x [xxxxxxx xxxxxxxx](https://msdn.microsoft.com/library/windows/apps/BR211474) xx xxxxxx xxxxxxx XXX xx xxxxxxxxx xxxx xxxxxxxx, xxxxx, xx xxxxxxx xxxx xxx xxxxxx xx xxx xxxxxxxxxx.

Xxx xxxxxxx xxxxxx xx xxxxxxxx xxxxxxxxx xx XXX xx xxxxxxxxx xxxxxxxxxxxx xx xxxx xxx'x [xxxxxxx xxxxxxxx](https://msdn.microsoft.com/library/windows/apps/BR211474). Xxx xxx xxxxxxx xxxxxxx xxxxxxxxxxxx xx xxxxx xxx [Xxxxxxxx Xxxxxxxx](https://msdn.microsoft.com/en-us/library/windows/apps/xaml/br230259.aspx) xx Xxxxxxxxx Xxxxxx Xxxxxx, xx xxx xxx xxx xxxx xxxxxxxx. Xxx xxxx xxxxxxxxxxx, xxx [Xxx xx xxxxxxx xxxxxxxxxxxx xx x xxxxxxx xxxxxxxx](https://msdn.microsoft.com/library/windows/apps/BR211477). Xx xx xxxxxxxxx xx xxxx xxxx xxxx xxxxxxxxx xxx xxxx xxx xxxx xxx Xxxxx, xxxx'xx xxxxxxxx xx xxx xxx xxxxxxxxxxxx xxxx xxx xxx xxxxxxxx. Xxxxx xxxxxxxxx xxxxxxxxxxxx xxxx xxxx xxx xxxxx'x xxxx.

Xxxx xxxxxxxxxxxx xxxxxxx xxxx xxxx xxxxxx xx x *xxxxxxxxx xxxxxxxx*. Xxxxx xxxxxxxxx xxx xxxxxxxxxx xxxxxxxxx xxxxxxx xxxx xxx xxxxxx xxx xxxx'x xxxxxxxx xxxx xx xxxx xxx xxxx xxxxx. Xxxxxxx xxxxxxxx, xxxxxxx xx xxx Xxxxxxxx xxx, xxx xxx xxxx xxxxxxxxxxx xxxxxxx xxxxxx xx xxxxxxxxx xxxxxxxxx. Xxxx, xx'x xxxxxxxxx xxxx xxxx xxx xxxxx'x xxxxxx x xxxxxxxxx xxxxxxxx xx xxxxxx xxxxxxxxx. Xxx xxxx xxxx xxxxx xxxxxxxxx xxxxxxxxx xxxxxxxxx, xxx [Xxxxxxxxxx xxx xxxxxxx-xxxxx xxxx](https://msdn.microsoft.com/library/windows/apps/Hh768223). Xxxxxxxxxxxx xxxx xxxxxxx xxxx xxxx xxxxxx xx x *xxxxxxxxx xxxxxxxx* xxx xxxxxxxxx xx xx xxxxxxxx (\*) xxxx xx xxx xxxxxxxxxx xxxxxxxx.

Xxxx xxxxxxx xxxxxxx xxxx xxxxxxxxxx xx xxxxxxxxxxxx xxxxxxxxx xxxxx.

-   Xxxxxxx-xxx xxxxxxxxxxxx xxxx xxxxx xx xxxx xxxxxx xxx xxxxxxxxx.

-   Xxxxxx xxxxxxxxxxxx xxxx xxxxx xxxx xxx xx xxxxxx xxxxxxxxxx xxx xxxxxxxx xxxxxxx.

-   Xxxxxxx-xxx xxxxxxxxxxxx xxxx xxxxxxx x xxxxxxx xxxxxxx xxxxxxx xxx xxxxxxxxxx xx xxx Xxxxx xx xxx xxxx. Xxx xxxx xxxx xxxxx xxxxxxx xxxxxxxx, xxx [Xxxxxxx xxxxx, xxxxxxxxx, xxx xxxx](https://msdn.microsoft.com/library/windows/apps/JJ863494).

-   Xxxxxxxxxx xxxxxxxxxxxx xxxx xxx xxxx xxxxxxxxx xx Xxxxxxxxx xxx xxx xxxxxxxx.

## Xxxxxxx-xxx xxxxxxxxxxxx

Xxxxxxx-xxx xxxxxxxxxxxx xxxxx xx xxx xxxx xxxxxx xxx xxxxxxxxx.

<table>
        <thead>
            <tr>
                <th>Xxxxxxxxxx xxxxxxxx</th>
                <th>Xxxxxxxxxx xxxxx</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>**Xxxxx***</td>
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
&xx;/Xxxxxxxxxxxx&xx;</code></pre>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
            <tr>
                <td>**Xxxxxxxx***</td>
                <td>
                    Xxx **xxxxxxxxXxxxxxx** xxxxxxxxxx xxxxxxxx xxxxxxxxxxxx xxxxxx xx xxx xxxx'x Xxxxxxxx, xxxxxxxx xxx xxx xx xxxxxxxxx xxx xxxxxx xxx xxxxx xx xxx xxxxxxx xxxxxxx xxxx xxxxxxxxxxx. Xxxx xxxxxxxxxx xx xxxxxxxxx xxxx xx xxxxx xxxx xxxx xxxx xxx xx xxx xxxxxx Xxxxxxxx xxxxxxx.

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
                <td>**Xxxxxx***</td>
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
                <td>**Xxxxxxxxx Xxxxxxx**</td>
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
                <td>**Xxxxxxxx xxx xxxxxx xxxxxxxx***</td>
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
                <td>**Xxxxxxxx***</td>
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
                <td>**Xxxx xxxxxxxxxx**</td>
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
                <td>**Xxxxxxxx Xxxxx Xxxxxx***</td>
                <td>
                    <p>Xxx **xxxxxxxxXxxxxXxxxxx** xxxxxx xxxxxxxxxx xxxxxx xxxx xx xxxxxx xxx xxxxxxxx xxxxx xxxxxx.</p>
                    <p>Xxx **xxxxxxxxXxxxxXxxxxx** xxxxxxxxxx xxxx xxxxxxx xxx **xxxxxx** xxxxxxxxx xxxx xxx xxxxxxx xx xx xxxx xxx'x xxxxxxx xxxxxxxx xx xxxxx xxxxx.</p>
                    <table>
                        <thead>
                            <tr>
                                <th>XXX</th>
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
                <td>**Xxxx Xxxxxxx Xxxxxxxxxxx***</td>
                <td>
                    <p>Xxx **xxxxXxxxxxxXxxxxxxxxxx** xxxxxxxxxx xxxxx xxxx xxx xxxxxxx xx xxxxxx xxx xxxx'x xxxx xxx xxxxxxx.</p>
                    <p>Xxxx xxxxxxxxxx xx xxxxxxxx xx xxxxxx xxxx XXXx xx xxx Xxxxxxx.Xxxxxx.Xxxx xxxxxxxxx.</p>
                    <p>Xxx **xxxxXxxxxxxXxxxxxxxxxx** xxxxxxxxxx xxxx xxxxxxx xxx **xxx** xxxxxxxxx xxxx xxx xxxxxxx xx xx xxxx xxx'x xxxxxxx xxxxxxxx xx xxxxx xxxxx.</p>
                    <table>
                        <colgroup>
                            <col width="100%" />
                        </colgroup>
                        <thead>
                            <tr>
                                <th>XXX</th>
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
                <td>**XXXX xxxxxxx**</td>
                <td>
                    <p>Xxx **xxxxXxxx** xxxxxxxxxx xxxxxx xxxx xx xxxxxx xxx XXXX xxxxxxx XXXx xx xxx [**Xxxxxxx.XxxxxxxxxxxXxxxx.Xxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn297266) xxxxxxxxx.</p>
                    <p>Xxx **xxxxXxxx** xxxxxxxxxx xxxx xxxxxxx xxx **xxx** xxxxxxxxx xxxx xxx xxxxxxx xx xx xxxx xxx'x xxxxxxx xxxxxxxx xx xxxxx xxxxx.</p>
                    <table>
                        <colgroup>
                            <col width="100%" />
                        </colgroup>
                        <thead>
                            <tr>
                                <th>XXX</th>
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
                <td>**YX Xxxxxxx**</td>
                <td>
                    <p>Xxx **xxxxxxxYX** xxxxxxxxxx xxxxxx xxxx xx xxxx xxxxxxxxxxxx xxxxxx xx xxx YX xxxxxx xxxxx. Xxxx xxxxxxxxxx xx xxxxxxxxx xxxx xx YX xxxx xxx xxxxx xxxx xxxx xxxxxx xx xxx xxxxxx YX xxxxxxx xxxxxxx.</p>
                    <p>Xxxx xxxxxxxxxx xx xxxxxxxx xx xxxxxx xxx xxxxxx xxxx xxxxxxxx xxx YX xxxxxxx xxxxx XXXx xx xxx [**Xxxxxxx.Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR227346) xxxxxxxxx.</p>
                    <p>Xxx **xxxxxxxYX** xxxxxxxxxx xxxx xxxxxxx xxx **xxx** xxxxxxxxx xxxx xxx xxxxxxx xx xx xxxx xxx'x xxxxxxx xxxxxxxx xx xxxxx xxxxx.</p>
                    <table>
                        <colgroup>
                            <col width="100%" />
                        </colgroup>
                        <thead>
                            <tr>
                                <th>XXX</th>
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
                <td>**Xxxx Xxxxxxx Xxxxxxxx***</td>
                <td>
                    <p>Xxx **xxxxxxxXxxxXxxxxxxx** xxxxxxxxxx xxxxxx xxxx xx xxxx XXX xxx XXX xxxxxxxx xxxx xxxx xxxx xxxxxxx xx xxx Xxxx Xxxxxx xxx.</p>
                    <p>Xxxx xxxxxxxxxx xx xxxxxxxx xx xxxxxx xxx xxxxxxx xxxxxxxx xxxxx XXXx xx xxx [**Xxxxxxx.XxxxxxxxxxxXxxxx.Xxxx**](https://msdn.microsoft.com/library/windows/apps/Dn642321) xxxxxxxxx.</p>
                    <p>Xxx **xxxxxxxXxxxXxxxxxxx** xxxxxxxxxx xxxx xxxxxxx xxx **xxx** xxxxxxxxx xxxx xxx xxxxxxx xx xx xxxx xxx'x xxxxxxx xxxxxxxx xx xxxxx xxxxx.</p>
                    <table>
                        <colgroup>
                            <col width="100%" />
                        </colgroup>
                        <thead>
                            <tr>
                                <th>XXX</th>
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
                <td>**Xxxx Xxxxxxx Xxxxxx**</td>
                <td>
                    <p>Xxx **xxxx** xxxxxxxxxx xxxxxx xxxx xx xxxx xxx xxxxxx Xxxx Xxxxxxxx. Xxxx xxxxxxxxxx xxxx xxxxxx xxxx xx xxxxx xxxx xxxxxxxx xx xxx xxxxxx xxxx xxxxx.</p>
                    <p>Xxxx xxxxxxxxxx xx xxxxxxxx xx xxx xxxx XXXx xx xxx [**Xxxxxxx.XxxxxxxxxxxXxxxx.Xxxx**](https://msdn.microsoft.com/library/windows/apps/Dn642321) xxxxxxxxx.</p>
                    <p>Xxx **xxxx** xxxxxxxxxx xxxx xxxxxxx xxx **xxx** xxxxxxxxx xxxx xxx xxxxxxx xx xx xxxx xxx'x xxxxxxx xxxxxxxx xx xxxxx xxxxx.</p>
                    <table>
                        <colgroup>
                            <col width="100%" />
                        </colgroup>
                        <thead>
                            <tr>
                                <th>XXX</th>
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
                <td>**XxX Xxx-xxxxx Xxx Xxxxxxxx**</td>
                <td>
                    <p>Xxx **xxxXxxxxXxxxxxx** xxxxxxxxxx xxxxxx xxxx xxxx xxx xx XxX xxxxxxx xx xxxxxx xxx-xxxxx xxx xxxxxxxx xxxx xx XXXX, XYX, XXX, XXX, xxx XXX.</p>
                    <p>Xxxx xxxxxxxxxx xx xxxxxxxx xx xxxxxx xxxx XXXx xx xxx [**Xxxxxxx.Xxxxxxx.Xxx**](https://msdn.microsoft.com/library/windows/apps/Dn708178) xxxxxxxxxx.</p>
                    <p>Xxx **xxxXxxxxXxxxxxx** xxxxxxxxxx xxxx xxxxxxx xxx **xxx** xxxxxxxxx xxxx xxx xxxxxxx xx xx xxxx xxx'x xxxxxxx xxxxxxxx xx xxxxx xxxxx.</p>
                    <table>
                        <colgroup>
                            <col width="100%" />
                        </colgroup>
                        <thead>
                            <tr>
                                <th>XXX</th>
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
                <td>**XxX Xxxxxx Xxxxxxxxxxxxxx**</td>
                <td>
                    <p>Xxx **xxxxxxXxxxxxxxxx** xxxxxxxxxx xxxxxx xxxx xx xxxx xxxxx xxxxxx xxxxxxxxxxxxxx xxxxxxxxxx xxxx xx xxxxxxxx xxxx xx xxxxxxxxx, xxxxxx, xxx xxxxxxxx.</p>
                    <p>Xxxx xxxxxxxxxx xx xxxxxxxx xx xxxxxx xxxx xx xxx XXXx xx xxx [**Xxxxxxx.Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR241814) xxxxxxxxx.</p>
                    <p>Xxx **xxxxxxXxxxxxxxxx** xxxxxxxxxx xxxx xxxxxxx xxx **xxx** xxxxxxxxx xxxx xxx xxxxxxx xx xx xxxx xxx'x xxxxxxx xxxxxxxx xx xxxxx xxxxx.</p>
                    <table>
                        <colgroup>
                            <col width="100%" />
                        </colgroup>
                        <thead>
                            <tr>
                                <th>XXX</th>
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

 
## Xxxxxx xxxxxxxxxxxx

Xxxxxx xxxxxxxxxxxx xxxxx xxxx xxx xx xxxxxx xxxxxxxxxx xxx xxxxxxxx xxxxxxx. Xxxxxx xxxxxxxxxxxx xxx xxxxxxxxx xx xxxxx xxx **XxxxxxXxxxxxxxxx** xxxxxxx xx xxxx xxx xxxxxxx xxxxxxxx. Xxxx xxxxxxx xxx xxxxxxx xxxxxxxxxx xxxxx xxxxxxxx xxx xxxx xxxxxx xxxxxxxxxxxx xxxx xx xx xxxxx xx xxx xxxxxxx xxxxxxxx xxxxxxxx. Xxx xxxx xxxx, xxx [Xxx xx xxxxxxx xxxxxx xxxxxxxxxxxx xx x xxxxxxx xxxxxxxx](https://msdn.microsoft.com/library/windows/apps/Dn263092) xxx [**XxxxxxXxxxxxxxxx Xxxxxx xxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR211430).

| Xxxxxxxxxx xxxxxxxx | Xxxxxxxxxx xxxxx |
|---------------------|------------------|
| **Xxxxxxxx**\* | Xxx **xxxxxxxx** xxxxxxxxxx xxxxxxxx xxxxxx xx xxxxxxxx xxxxxxxxxxxxx xxxx xx xxxxxxxxx xxxx xxxxxxxxx xxxxxxxx xxxx x XXX xxxxxx xx xxx XX xx xx xxxxxxx xxxx xxxxxxxxx xxxxxxx xxxx. Xxxx xxxx xxxxxx xxx xxxx xx xxxxx xxx xxxx xxx xxxxxxxx xxxxxxxx xxxxxxxx xxxx xxx **Xxxxxxxx** xxxxx. |
| **Xxxxxxxxxx** | Xxx **xxxxxxxxxx** xxxxxxxxxx xxxxxxxx xxxxxx xx xxx xxxxxxxxxx’x xxxxx xxxx, xxxxx xxxxxx xxx xxx xx xxxxxx xxxxx xxxx xxxxxxxxx xxxxxxxxxxx. Xxxx xxxx xxxxxx xxx xxxx xx xxxxx xxx xxxx xxx xxxxxxxx xxx xxxxxxxxxx xxxx xxx **Xxxxxxxx** xxxxx. |
| **Xxxxxxxxx** | Xxx **xxxxxxxxx** xxxxxxxxxx xxxxxxx xxxxxxxx xxxxxxx xx xxxxx xxxxxxxxx xx xxxxxxxxxxx xxxx xxx xxxxxxx. Xxxx xxxxxxxxxx xx xxxxxxxxx xxxx xx xxxxxx xxxxx-xxxxxx xxxxx xxx xx xxxx xxxx xxxxxxxx xxxxxxxxxxx. Xxxxxxx xxxxxxx xx xxx xxx xxxxxxxxxxxxx xxxxxxxxxx xxxx xxxxxxxx xxx xxxx xxxxxxxx xxxxxxxxxx, xxxxxxxxx Xxxxxxxxx, Xx-Xx, xxx xxx Xxxxxxxx. Xxxx xxxxxxxxxx xx xxxx xxxx xx xxxxxxxx xxxxxxxxxxxxx xxxxxxx xxx xxxxxxx. |
| **Xxxxxx** | Xxx **xxxxxx** xxxxxxxxxx xxxxxxxx xxxxxx xx xxx xxxxx xxxx xx x xxxxx-xx xxxxxx xx xxxxxxxx xxxxxx, xxxxx xxxxxx xxx xxx xx xxxxxxx xxxxxx xxx xxxxxx. Xx Xxxxxxx, xxxx xxxx xxxxxx xxx xxxx xx xxxxx xxx xxxx xxx xxxxxxxx xxx xxxxxx xxxx xxx **Xxxxxxxx** xxxxx.<br/>Xxx **xxxxxx** xxxxxxxxxx xxxx xxxxxx xxxxxx xx xxx xxxxx xxxxxx. Xx xxxxx xx xxxxx xxxxxx xx xxx xxxxx xxxxxx xx xxxx, xxx **xxxxxxxxxx** xxxxxxxxxx xxxx xx xxxxx. | 
| **XXX** | Xxx **xxx** xxxxxx xxxxxxxxxx xxxxxxx xxxxxx xx XXXx xx xxx [Xxxxxxxx xxx xxx xxxxxxxx xxxxxxx xxx x XXX xxxxxx](http://go.microsoft.com/fwlink/p/?LinkId=302259). | 
| **Xxxxx xxxxxxxxx xxxxxx (XXX)** | Xxx **xxxxxxxxxxxxxxxxxxxx** xxxxxx xxxxxxxxxx xxxxxxx xxxxxx xx XXXx xx xxx [Xxx xx xxxxxxx xxxxxx xxxxxxxxxxxx xxx XXX](https://msdn.microsoft.com/library/windows/apps/Dn263091). |
| **Xxxxx xx Xxxxxx (XXX)** | Xxx **xxxxxXxXxxxxxx** xxxxxx xxxxxxxxxx xxxxxxx xxxxxx xx XXXx xx xxx [**Xxxxxxx.Xxxxxxx.XxxxxXxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn298071) xxxxxxxxx. Xxxx xxxxxxxxx xxxx xxxx xxx xxxxxx Xxxxx xx Xxxxxxx (XXX) xxxxxxx xxxxxxxx xxx xxxxxxxx xxxxxx xxxxxxx. Xxx xxxxxxxxx xxxxxxxx x xxxxxx-xxxxxxx xxxxxxxxx xxx xxxxxxxxx XXX xxxxxxx xxxx xxxxxxx xxxxxxxxxxxxx xxxx x Xxxxxxx Xxxxx xxx. |
| **Xxxxxxxxx** | Xxx **xxxxxxxxx** xxxxxx xxxxxxxxxx xxxxxx xxxx xx xxxxxxxxxxx xxxx xxxxxxx xxxxxx xxxxxxxxx xxxxxxx xxxx xxxx Xxxxxxx Xxxxxxxxx (XXXX) xx Xxxxxxx Xxxxx Xxxx (XXXXXX) xxxxxxxx.<br/>Xxxx xxxxxxxxxx xx xxxxxxxx xx xxx xxxx XXXx xx xxx [**Xxxxxxx.Xxxxxxx.Xxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn263413) xxxxxxxxx. |
| **Xx-Xx Xxxxxxxxxx** | Xxx **xxXxXxxxxxx** xxxxxx xxxxxxxxxx xxxxxx xxxx xx xxxx xxx xxxxxxx xx Xx-Xx xxxxxxxx.<br/>Xxxx xxxxxxxxxx xx xxxxxxxx xx xxx xxxx XXXx xx xxx [**Xxxxxxx.Xxxxxxx.XxXx**](https://msdn.microsoft.com/library/windows/apps/Dn975224) xxxxxxxxx. |
| **Xxxxx xxxxx** | Xxx **xxxxxx** xxxxxx xxxxxxxxxx xxxxxx xxxx xx xxxxxx xxx Xx-Xx xxx Xxxxxxxxx xxxxxx.<br/>Xxxx xxxxxxxxxx xx xxxxxxxx xx xxx xxx XXXx xx xxx [**Xxxxxxx.Xxxxxxx.Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn996447) xxxxxxxxx.  |
| **Xxxxxxx xxxx** | Xxx **xxxxxxx** xxxxxx xxxxxxxxxx xxxxxx xxxx xx xxxxxx xxxxxxxxx xx xxxxxxx xxxx xxxxxx xxxx xx XX, XXX, xxx Xxx-xxx.<br/>Xxxx xxxxxxxxxx xx xxxxxxxx xx xxx xxxx XXXx xx xxx [**Xxxxxxx.Xxxxxxx.Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn263667) xxxxxxxxx. |
| **Xxxxxx xxxxxxxx** | Xxx **xxxxxxxx** xxxxxx xxxxxxxxxx xxxxxx xxxx xx xxxxxx xxx xxxxxxx xxxxxx xx xxx xxxxxx.<br/>Xxxx xxxxxxxxxx xx xxxxxxxx xx xxx xxxx XXXx xx xxx [**Xxxxxxx.Xxxxxxx.Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR206408) xxxxxxxxx. |

## Xxxxxxx xxx xxxxxxxxxx xxxxxxxxxxxx

**Xxxxxxxxx**  
Xxxxxxx xxx xxxxxxxxxx xxxxxxxxxxxx xxx xxxxxxxx xxx xxxx xxxxxxxx xxxxxxxxx. Xxx xxx xx xxxxx xxxxxxxxxxxx xx xxxxxx xxxxxxxxxx xxx xxxxxxx xx xxxxxxxxxx Xxxxx xxxxxxxxxx xxxxxx xxx xxxxxx.

Xxxxx xxx xxxxx xxxxx xxxx xxxxxxxxxxxx xxx xxxxxxxxx xxx xxxxxxxxxxx, xxxx xx xxxxxxx xxxx xxx-xxxxxx xxxxxxxxxxxxxx, xxxxx xxxxx xxxxxxx x xxxxx xxxx xxxx x xxxxxxx xxxxxxxxxxx xxxx xxxxxxxx xxxxx xxxxxxxx. Xxxxx xxxx xxx xx xxxxxxxx xxxxxxxxx xxx xxxxxxxxxx xxxxxxxxx xxx xxx xxxx xxxxxx xx xxxxxxxxx xxxxxxxxx xxxx xxxxxx xx xxxxxxxx xxxxxxx xxx xxxx’x xxxxxx xxxxxxxxxxx.

Xxxx xxxx xxxxx xxx xxxxxxx-xxx xxxxxxxxxxxx xxxxxxx x xxxxxxx xxxxxxx xx xxxxxx xxxx xx xxx Xxxxx. Xx xxxxxxxx, xxxxxxxxxx xxxxxxxxxxxx xx xxx xxxxxxx x xxxxxxx xxxxxxx xxxxxxx xxx xxx Xxxxx, xxxx xxx xxx xxxxxxxxx xxx xxxxxxxxxx xx xxx. Xxxxxxxxxx xxxxxxxxxxxx xxx xxxxxxxxx xxxx xx xxxx xxxx xxx xxxxxxxxx xx Xxxxxxxxx xxx xxx xxxxxxxx. Xxx xxxx xxxxxxxxxxx xxxxx xxxxxxx xxxxxxxx, xxx [Xxxxxxx xxxxx, xxxxxxxxx, xxx xxxx](https://msdn.microsoft.com/library/windows/apps/JJ863494).

Xxx xxxxxxxxxx xxxxxxxxxxxx xxxx xxxxxxx xxx **xxxxxx** xxxxxxxxx xxxx xxx xxxxxxx xxxx xx xxxx xxx'x xxxxxxx xxxxxxxx xxxxxxxxxxx xxxx xxxxx xxxxxxxxxxxx. Xxx xxxxxxxxx xxxxxxx xxxxx xxx xxx xx xxxxxxx xxx **xxxXxxxxxxXxxxxxxx** xxxxxxxxxx.

```xml
<Capabilities>
    <rescap:Capability Name="appCaptureSettings"/>
</Capabilities>
```

Xxx xxxx xxxx xxx xxx **xxxxx:xxxxxx** xxxxxxxxx xxxxxxxxxxx xx xxx xxx xx xxx Xxxxxxx.xxxxxxxxxxxx xxxx xx xxxxx xxxxx.

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
<th align="left">Xxxxxxxxxx xxxxxxxx</th>
<th align="left">Xxxxxxxxxx xxxxx</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left">**Xxxxxxxxxx**</td>
<td align="left"><p>Xxxxxxx xxxxxx xxxxxxxxxxx xxxxxx x xxxx xx xxx xxxx xxxxxx xxxxxxxxx xxxxx xxxxx xxxxxxxxxxx, xxx xxx xx xx x xxxx xxxxxxxx xxxxx xxxx xxxx xxx xxxxxxxx. Xxx **xxxxxxxxxxXxxxxxxxxxxxxx** xxxxxxx xxxxxxxxxx xx xxxxxxxxx xxxx xx xxxx-xx-xxxxxxxx xxxx xxxx xxxxxxx xx xxxxxxx xxxxxx xx xxxxxxxxxx.</p>
<p>Xxx xxx'x xxxx xxxx xxxxxxxxxx xxx xxxxxxx xxxxxxxxxxxxx xxxxxx xxx Xxxxxxxx.</p>

<p>Xxx **xxxxxxxxxxXxxxxxxxxxxxxx** xxxxxxx xxxxxxxxxx xx xxxxxxxx xx xxxxxxx xxxxxx xxxx-xx-xxxxxxxx xxxx. Xxx'x xxxxxxx xx xx xxxx xxxx xxx'x xxxx xx xxxxxx xxxxxxxxx xxxxxxxxx. Xxx [**xxxx xxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR207847) xxxxxxxx x xxxxxx XX xxxxxxxxx xxxx xxxxxxx xxxxx xx xxxx xxxxx xx x xxxxxxx xxxxx xxx xxx xxxx xx xxx. Xxxxxxx xxx **xxxxxxxxxxXxxxxxxxxxxxxx** xxxxxxx xxxxxxxxxx xxxx xxxx xxx xxxxxxxxx xxx xxxx xxx xxxxxxx xxxxxxxxxxxx xxxxxx, xxx xxx xxxxxx xxxxxxx xxxx xx xxxxx xxx **xxxx xxxxxx**.</p>
<p>Xxx **xxxxxxxxxxXxxxxxxxxxxxxx** xxxxxxxxxx xxxx xxxxxxx xxx **xxx** xxxxxxxxx xxxx xxx xxxxxxx xx xx xxxx xxx'x xxxxxxx xxxxxxxx xx xxxxx xxxxx.</p>
<div class="code">
<span codelanguage="XML"></span>
<table>
<colgroup>
<col width="100%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">XXX</th>
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
<p>Xxx **xxxxxxxxxxXxxxXxxxxx** xxxxxxxxxx xxxxxx xxxx xx xxxxxx xxx xxx xxxxxxxxxx-xxxxxxxx xxxxxxxx xxx xxx xxxxxx. Xxxx xxxxxxxxxx xx xxxxxxxx xx xxx xxx xxxxxxx xx xxx xxxxxxxxx xxxxxxx.</p>
<ul>
<li>[
            **XxxxXxxxxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn705151)</li>
<li>[
            **XxxxXxxxxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn706017)</li>
<li>[
            **XxxxxxxxxxXxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn705170)</li>
</ul></td>
</tr>
<tr class="even">
<td align="left">**Xxxxxx xxxx xxxxxxxxxxxx**</td>
<td align="left"><p>Xxx **xxxxxxXxxxXxxxxxxxxxxx** xxxxxxx xxxxxxxxxx xxxxxxx xx xxx xx xxx xxx xxxxxx xxxxxxxx xxx xxxxxxxx-xxxxx xxxxxxxxxxxx xx xxx Xxxxxx Xxxx xxxxx, xxxx xx xxxxxxxxxxxx xxxxxx xx x xxxxx xxxx. Xxxx xxxxxxxxxx xx xxxxxxxxx xxxx xxx xxxxxxxxx xx xxxxxxxxxx xxxx xxxx xxxxxxx x xxxxx xxxx xxx xxxxxxxxxxxxxx.</p>
<p>Xxx **xxxxxxXxxxXxxxxxxxxxxx** xxxxxxxxxx xxxx xxxxxxx xxx **xxx** xxxxxxxxx xxxx xxx xxxxxxx xx xx xxxx xxx'x xxxxxxx xxxxxxxx xx xxxxx xxxxx.</p>
<div class="code">
<span codelanguage="XML"></span>
<table>
<colgroup>
<col width="100%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">XXX</th>
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
<td align="left">**Xxxxxxxxx***</td>
<td align="left"><p>Xxx **xxxxxxxxxXxxxxxx** xxxxxxx xxxxxxxxxx xxxxxxxx xxxxxxxxxxxx xxxxxx xx xxx xxxx'x Xxxxxxxxx, xxxxxxxx xx xxx xxxx xxxx xxxxxxxxxxxx xxxxxxxx xx xxx xxxxxxx xxxxxxxx, xx xxxxxxx xxxxxxx xxxxxx xx XxxXxxxx. Xxx xxxxxxx, xx x XXX xxxxxx xxx xxxxxxxx x .xxx xxxx xxxx xxxxxxxxxxx, xx xxx xxxx .xxx xxxxx xx Xxxxxxxxx, xxx xxx xxxxx xxxxx xx xxxxx.</p>
<p>Xxxx xxxx xxxxxxx xxx **xxxxxxxxxXxxxxxx** xxxxxxx xxxxxxxxxx xxx'x xxxxxx Xxxxxxxxx xx Xxxx Xxxxx xxxxxxxxx. Xxx [file picker](https://msdn.microsoft.com/library/windows/apps/Hh465174) xxxxxxxx x xxxxxx XX xxxxxxxxx xxxx xxxxxxx xxxxx xx xxxx xxxxx xxx xxx xxxx xx xxx. Xxxxxxx xxx **xxxxxxxxxXxxxxxx** xxxxxxx xxxxxxxxxx xxxx xxxx xxx xxxxxx xxx xxx xxxx xxxxxx.</p>
<p>Xx xxx xxx **xxxxxxxxxXxxxxxx** xxxxxxx xxxxxxxxxx, xx xxx xxxx:</p>
<ul>
<li>Xxxxxxxxxx xxxxx-xxxxxxxx xxxxxxx xxxxxx xx xxxxxxxx XxxXxxxx xxxxxxx xxxxx xxxxx XxxXxxxx XXXx xx Xxxxxxxx XXx</li>
<li>Xxxx xxxx xxxxx xx xxx xxxx’x XxxXxxxx xxxxxxxxxxxxx xxxxx xxxxxxx</li>
</ul>
<p>Xxxx xxxx xxx xxx **xxxxxxxxxXxxxxxx** xxxxxxx xxxxxxxxxx xxx xxxxx xxx xxxxxxxx xxx xxxx xxxxxxxxxx xxx xxx xxxxxxxxxx xx xxxx xxxxxxxx xxxxxxx xxxxxx xxxxxxx xxxxxxxx. Xxxx xxx xxxxx xxxx xx xxx **xxxxxxxxxXxxxxxx** xxxxxxx xxxxxxxxxx xxx xxxxxxxx.</p>
<ul>
<li><p>Xxxx xxx xxx'x xxxxxx xxx Xxxxxxxxx xxxxxxx xx xxx xxxxx'x xxxxxxxx xxxxxxx. Xx xxxxxxx xxx xxxxxxx x Xxxxxxxxx xxxxxx xx xxx xxxxxxxx XX xxxx, xxxxxxx, xxxx xxx xxx xxx xxxx xxxxxx.</p></li>
</ul>
<p>Xxx **xxxxxxxxxXxxxxxx** xxxxxxxxxx xxxx xxxxxxx xxx **xxx** xxxxxxxxx xxxx xxx xxxxxxx xx xx xxxx xxx'x xxxxxxx xxxxxxxx xx xxxxx xxxxx.</p>
<div class="code">
<span codelanguage="XML"></span>
<table>
<colgroup>
<col width="100%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">XXX</th>
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
<td align="left">**Xxxx XXX Xxxxxxxx**</td>
<td align="left"><p>Xxx **xxxXxxxxxxXxxxxxxx** xxxxxxxxxx xxxxxxxxxx xxxxxx xxxx xx xxxxxxx xxx xxxx xxxxxxxx xxx xxx Xxxx XXX.</p>
<p>Xxxx xxxxxxxxxx xx xxxxxxxx xx xxx xxxx XXXx xx xxx [**Xxxxxxx.Xxxxx.Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR226738) xxxxxxxxx.</p></td>
</tr>
<tr class="odd">
<td align="left">**Xxxxxxxx**</td>
<td align="left"><p>Xxx **xxxxxxxxXxxxxxXxxxxxx** xxxxxxxxxx xxxxxxxxxx xxxxxx xxxx xx xxxx xxxxxxx xxxx xxx xxxxxxxx xxxxxx.</p>
<p>Xxx **xxxxxxxxXxxxxxXxxxxxxx** xxxxxxxxxx xxxxxx xxxx xx xxxxxx xxxxxxxx xxxxxxxxxxxxxx xxxx.</p>
<p>Xxx **xxxxxxxxXxxxxxxxx** xxxxxxxxxx xxxxxx xxxx xx xxxx xxx xx XXX xxx XXX.</p>
<p>Xxxxx xxxxxxxxxxxx xxx xxxxxxxx xx xxx xxxx XXXx xx xxx [**Xxxxxxx.Xxxxxxx.Xxx**](https://msdn.microsoft.com/library/windows/apps/BR206567) xxxxxxxxxx.</p>
<p>Xxxxxxxx xx Xxxxxxx YY, xxxx xxxxxxx [**XxxXXXxxx**](https://msdn.microsoft.com/library/windows/apps/Dn393996)).</p></td>
</tr>
<tr class="even">
<td align="left">**Xxxxxx Xxxxxx**</td>
<td align="left"><p>Xxx **xxxxxxXxxxxx** xxxxxxxxxx xxxxxxxxxx xxxxxx xxxx xx xxxxxx x xxxxxx xxx xxxxxxxxx xxx xxxxxxxxxx xxxxxxxxxxx xxxxxxxxx.</p></td>
</tr>
<tr class="odd">
<td align="left">**Xxxx XXX Xxxxx**</td>
<td align="left"><p>Xxx **xxxxXxxXxxxx** xxxxxxxxxx xxxxxxxxxx xxxxxx xxxx xx xxxxxx xx xxxxxxxxxx xxx xxxx xxxxx xx xxxxxxx xxxx xxxx xxxxxxxx XXXx.</p>
<p>Xxxx xxxxxxxxxx xx xxxxxxxx xx xxx xxxx XXXx xx xxx [**Xxxxxxx.XX.XxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR242235) xxxxxxxxx.</p></td>
</tr>
<tr class="even">
<td align="left">**Xxxxxxxxxx Xxxxxx Xxxxxxx**</td>
<td align="left"><p>Xxx **xxxxxxxxxxXxxxxxXxxxxxxx** xxxxxxxxxx xxxxxxxxxx xxxxxx xxxx xx xxx xxx xxxxxx xxxx xxxx XXX xxx xxxxxx xxx xxxxxxxxxx xxxxxx xxxxxxx xxxxxxx.</p></td>
</tr>
<tr class="odd">
<td align="left">**Xxxxxx Xxxxx Xxxxxxxxx**</td>
<td align="left"><p>Xxx **xxxxxXxxxxxxxx** xxxxxxxxxx xxxxxxxxxx xxxxxx xxxx xx xxxxxx xxxxxxx xxxxx xx xxxxx xxxx xx XXX, xxxxx, xxx, xxxxxxxx xx xxxxx xxxx xxx xxxxxx xxxxxxxxxxxxxxxx. Xxxx xxxxxxxxxx xx xxxxxxxxx xxxx xxx xxxxxxxxxxxxx xxxx xxxx xxx xxxx xxxxxxx xx xxx xxxxxx.</p>
<div class="alert">
**Xxxx**  Xxx x XX, xxxxx xxxxxxxxx xxxx xx xxx xxxx xxx xxxx xxxxxxxxxx xxxx xxxx xx xxxxxxxx xx xxxxxxxxx xx xxx xxxx Xxx Xxxxxxxxx.
</div>
</td>
</tr>
<tr class="even">
<td align="left">**Xxxxxxx Xxxxx***</td>
<td align="left"><p>Xxx **xxxxxXxxxxxxxxxx** xxxxxxxxxx xxxxxxxxxx xxxxxx xxxx xx xxxxxxx xxxxxxx xxxxx xx xxx xxxxx xxxx xx XXX, xxxxx, xxx, xxxxxxxx, xx xxxxx xxxxx xxxxxxxx xx xxx xxxxxx xxxxxxxxxx xx xxx xxxxx xxxxxxxxxxx.</p></td>
</tr>
<tr class="odd">
<td align="left">**Xxxxxxxx Xxxxx**</td>
<td align="left"><p>Xxx **xxxxxXxxxxxxxxxx** xxxxxxxxxx xxxxxxxxxx xxxxxx xxxx xx xxxxxxxx xxxxxxx xxxxx xx xxx xxxxx xxxx xx XXX, xxxxx, xxx, xxxxxxxx, xx xxxxx xxxx xxxxx xxxxxxxx xx xxx xxxxxx.</p></td>
</tr>
<tr class="even">
<td align="left">**XXX Xxx**</td>
<td align="left"><p>Xxx **xxxxxxxxxxXxxXxxxxxxx** xxxxxxxxxx xxxxxxxxxx xxxxxx xxxx xx xxxx xxxx xxxxxx xx XXX xxxxxxxx, xxxxxxxxx xxx xxxxxxx xx xxxxxx xxxxxxxxxxx xxx xxxxxxx XXX Xxxxxx xxxxxxxxxxxxx.</p>
<p>Xxxx xxxxxxxxxx xx xxxxxxxx xx xxx xxxx XXXx xx xxx [**Xxxxxxx.Xxxxxxxxxx.Xxx**](https://msdn.microsoft.com/library/windows/apps/Dn434040) xxxxxxxxx.</p></td>
</tr>
<tr class="odd">
<td align="left">**Xxxxx Xxx Xxxxxxxxx**</td>
<td align="left"><p>Xxx **xxxxxxxXxxxxxxxxx** xxxxxxxxxx xxxxxxxxxx xxxxxx xxxx xx xxxxxx xxxxx xxxx xxxxxxxx.</p>
<p>Xxx **xxxxxxxXxxxx** xxxxxx xxxxxxxxxx xxxxxx xxxx xx xxxxxx xxxxxxxxxxx xxxxx xxxxx xxxx.</p>
<p>Xxxxx xxxxxxxxxxxx xxx xxxxxxxx xx xxxxxx xxxx xxxxxxx xxx xxxxxxxxxx xx xxx [**XxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR240960) xxxxx.</p></td>
</tr>
<tr class="even">
<td align="left">**Xxxxxx Xxxxxxxxxx**</td>
<td align="left"><p>Xxx **xxxxxxXxxxxxxxxxx** xxxxxxxxxx xxxxxxxxxx xxxxxx xxxx xx xxxxxxx xxx xxxxxx xx xxxxxxx xxxxxx.</p>
<p>Xxxx xxxxxxxxxx xx xxxxxxxx xx xxx XXXx xx xxx XxxxxxX xxxxxxxxx.</p></td>
</tr>
<tr class="odd">
<td align="left">**Xxxx Xxxxxxxxx Xxxx**</td>
<td align="left"><p>Xxx **xxxxXxxxxxxxxXxxx** xxxxxxxxxx xxxxxxxxxx xxxxxx xxxx xx xxxxxx xxx xxxxxx xxx xxxxxxxxx xxxxx xxxx xxxxxx.</p>
<p>Xxxx xxxxxxxxxx xx xxxxxxxx xx xxxx xxx [**XxxXxxxXxxxXx**](https://msdn.microsoft.com/library/windows/desktop/ms724435) xxxxxxxx.</p></td>
</tr>
<tr class="even">
<td align="left">**Xxxxxx**</td>
<td align="left"><p>Xxx **xxxxxxXxxxxx** xxxxxxxxxx xxxxxxxxxx xxxxxx xxxx xx xxxx xxxx xxxxxx xx xxx xxxxxx xxxxxx xxxxx.</p>
<p>Xxxx xxxxxxxxxx xx xxxxxxxx xx xxx XXXx xx xxx [**Xxxxxxx.XxxxxxxxxxxXxxxx.Xxxxxx.Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/Mt171610) xxxxxxxxx.</p></td>
</tr>
<tr class="odd">
<td align="left">**Xxxxxxxx Xxxxxxx**</td>
<td align="left"><p>Xxx **xxxxxxxxXxxxxxx** xxxxxxxxxx xxxxxxxxxx xxxxxx xxxx xx xxxxxx xxx xxxxxxxx xxxxxxx xx xxx xxxxxx.</p>
<p>Xxxx xxxxxxxxxx xx xxxxxxxx xx xxx XXXx xx xxx [**Xxxxxxx.Xxxxxxx.Xxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR225603) xxxxxxxxx.</p></td>
</tr>
<tr class="even">
<td align="left">**Xxx Xxxxx Xxxxxxxxxxxx**</td>
<td align="left"><p>Xxx **xxxxxxxXxxXxxxx** xxxxxxxxxx xxxxxxxxxx xxxxxx xxxx xx xxxxx xxxxxxxxxx, xxxxx xxx xxxxxxx, xxx xxxxx xxx xxxxxxx xx xxxxx xxx.</p>
<p>Xxxx xxxxxxxxxx xx xxxxxxxx xx xxx XXXx xx xxx [**Xxxxxxx.XX.XxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR242295) xxxxxxxxx.</p></td>
</tr>
<tr class="odd">
<td align="left">**Xxxx Xxxxxxx***</td>
<td align="left"><p>Xxx **xxxxxXxxxXxxxxxx** xxxxxxxxxx xxxxxxxxxx xxxxxx xxxx xx xxxx xxx xxxx xxxxxxx xxx xx xxxxxx xxxxxxx xx xxx xxxxxxx.</p>
<p>Xxxx xxxxxxxxxx xx xxxxxxxx xx xxx XXXx xx xxx [**Xxxxxxx.XxxxxxxxxxxXxxxx.Xxxx**](https://msdn.microsoft.com/library/windows/apps/Dn642321) xxxxxxxxx.</p></td>
</tr>
<tr class="even">
<td align="left">**Xxxxxx Xxxxx Xxxxxxxxxxx Xxxxxx**</td>
<td align="left"><p>Xxx **xxxxxxxxxxxxXxxxxx** xxxxxxxxxx xxxxxxxxxx xxxxxx xxxx xx xxxx xxx xxxxxx xxx xxxxxxxxxxxx xx xxx xxxx'x xxxxxxxx.</p>
<p>Xxxx xxxxxxxxxx xx xxxxxxxx xx xxx XXXx xx xxx [**Xxxxxxx.XxxxxxxxxxxXxxxx.Xxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn263359) xxxxxxxxx.</p></td>
</tr>
<tr class="odd">
<td align="left">**Xxxxxx Xxxxx Xxxx Xxxxxxx Xxxxxx***</td>
<td align="left"><p>Xxx **xxxxXxxxxx** xxxxxxxxxx xxxxxxxxxx xxxxxx xxxx xx xxxx xxx xxxxx xxx XXX xxx XXX xxxxxxxx.</p>
<p>Xxxx xxxxxxxxxx xx xxxxxxxx xx xxx XXXx xx xxx [**Xxxxxxx.XxxxxxxxxxxXxxxx.Xxxx**](https://msdn.microsoft.com/library/windows/apps/Dn642321) xxxxxxxxx.</p></td>
</tr>
<tr class="even">
<td align="left">**Xxxxxx Xxxxx Xxxxxxx Xxxxxx**</td>
<td align="left"><p>Xxx **xxxxxxxxXxxxxx** xxxxxxxxxx xxxxxxxxxx xxxxxx xxxx xx xxxx xxxxxxx xxxxxxxxxxx xxxx xxx xxxx xxxxxxxxxx xx xxxxxxxxxx xx xxxxxxxxx xxx xxxxxx xxxxxxxx xxxxxxx xxxxxxxxxxx.</p>
<p>Xxxx xxxxxxxxxx xx xxxxxxxx xx xxx XXXx xx xxx [**Xxxxxxx.XxxxxxxxxxxXxxxx.Xxxx**](https://msdn.microsoft.com/library/windows/apps/Dn642321) xxxxxxxxx.</p></td>
</tr>
<tr class="odd">
<td align="left">**Xxxxx Xxxxxx***</td>
<td align="left"><p>Xxx **xxxxx** xxxxxxxxxx xxxxxxxxxx xxxxxx xxxx xx xxxx, xxxxxx, xxx xxxx xxxx xxxxxx.</p>
<p>Xxxx xxxxxxxxxx xx xxxxxxxx xx xxx XXXx xx xxx [**Xxxxxxx.XxxxxxxxxxxXxxxx.Xxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn631285) xxxxxxxxx.</p></td>
</tr>
<tr class="even">
<td align="left">**Xxxxxx Xxxxx Xxxxx Xxxxxx**</td>
<td align="left"><p>Xxx **xxxxxXxxxxx** xxxxxxxxxx xxxxxxxxxx xxxxxx xxxx xx xxxx, xxxxxx, xxx xxxx xxxx xxxxxxxxxx xx xxxxxxxxx xxxxxx.</p>
<p>Xxxx xxxxxxxxxx xx xxxxxxxx xx xxx XXXx xx xxx [**Xxxxxxx.XxxxxxxxxxxXxxxx.Xxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn631285) xxxxxxxxx.</p></td>
</tr>
<tr class="odd">
<td align="left">**Xxxxxx Xxxxx Xxxx Xxxxxxx Xxxxxx**</td>
<td align="left"><p>Xxx **xxxxxXxxxXxxxxxxXxxxxx** xxxxxxxxxx xxxxxxxxxx xxxxxx xxxx xx xxxxx xxxxxx xxx xxxx xxxxxxx xx xxxxxxxx xxxxxxxx xxxxxxx xxx xxxxxxx xxx xxxx.</p>
<p>Xxxx xxxxxxxxxx xx xxxxxxxx xx xxx XXXx xx xxx [**Xxxxxxx.XxxxxxxxxxxXxxxx.Xxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn297266) xxxxxxxxx.</p></td>
</tr>
<tr class="even">
<td align="left">**Xxxx Xxxx Xxxxxxxx***</td>
<td align="left"><p>Xxx **xxxXxxx** xxxxxxxxxx xxxxxxxxxx xxxxxx xxxx xx xxxx XXX xxx XXX xxxxxxxx.</p>
<p>Xxxx xxxxxxxxxx xx xxxxxxxx xx xxx XXXx xx xxx [**Xxxxxxx.XxxxxxxxxxxXxxxx.Xxxx**](https://msdn.microsoft.com/library/windows/apps/Dn642321) xxxxxxxxx.</p></td>
</tr>
<tr class="odd">
<td align="left">**Xxxxxx Xxxxx Xxxxxx xx Xxx Xxxx Xxxx**</td>
<td align="left"><p>Xxx **xxxxXxxxXxxxxx** xxxxxxxxxx xxxxxxxxxx xxxxxx xxxx xx xxxxxx xxx xxxx xxxx xxxxxx xxxxxxxxx.</p></td>
</tr>
<tr class="even">
<td align="left">**Xxxxx Xxxxxxx Xxxxxxxx**</td>
<td align="left"><p>Xxx **xxxxxxxXxxxx** xxxxxxxxxx xxxxxxxxxx xxxxxx xxxx xx xxxxxxxx xxx xxxxxxxx XXXx xx xx-xxx xxxxxxxx.</p>
<p>Xxxx xxxxxxxxxx xx xxxxxxxx xx xxx xxxxxxx XXXx xx xxx [**Xxxxxxx.XxxxxxxxxxxXxxxx.Xxxxx.Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Mt185546) xxxxxxxxx.</p></td>
</tr>
<tr class="odd">
<td align="left">**Xxxxx-Xxxx Xxxx-xx Xxxxxxxx**</td>
<td align="left"><p>Xxx **xxxxxXxxxXxXxxxxxxx** xxxxxxxxxx xxxxxxxxxx xxxxxx xxxx xx xxxxxx xxxx xxxxxxxx xxxx xxxx xxx xxxx xxx xxxx xxxxx xxxxxx xx xx xxxxx xxxxxx.</p></td>
</tr>
<tr class="even">
<td align="left">**Xxxxxxx Xxxx Xxxxxxxxxx**</td>
<td align="left"><p>Xxx **xxxxXxxxxxxXxxxxxxxxx** xxxxxxxxxx xxxxxxxxxx xxxxxx xxxx xx xxxxxx xxxxxxxx XXXx xxxx xxxxxxx xxxx xxxxxxxxxxxx xxxxxxx xx x Xxxxxxx Xxxx xxxxxxx. X Xxxxxxx Xxxx xxxxxxx xx xxxxxx xx xx xxxxxxx xx x xxxx xxxxxx xxxx xx x Xxxxxxxxx Xxxxxxx Xxx.</p></td>
</tr>
<tr class="odd">
<td align="left">**Xxxxxx Xxxxxx**</td>
<td align="left"><p>Xxx **xxxxxxXxxxxxxxXxxxxxxxxxxxxx** xxxxxxxxxx xxxxxxxxxx xxxxxx xxxx xx xxxxxx xxxxxxxxxxx xxxx xxx xx xxxx xx xxxxxx x xxxxxx XX.</p></td>
</tr>
<tr class="even">
<td align="left">**Xxxxxxx Xxxxxxxxxxx**</td>
<td align="left"><p>Xxx **xxxxxxxXxXxxxxxxxxxx** xxxxxxxxxx xxxxxxxxxx xxxxxx xxxx xx xxxxxxx xxx [**Xxxxxxx.XX.Xxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn706878) xxxxxxxxx xxx xxxxx xxxx xxxxxxxxx xx xxxx xxx xxxxxxx xxxxxxxx xx xxx XXX xxxxxx xx xx xxxxxxxxx. Xxxxxx xxxxxxx xxxxxxxxxxxxxx@xxxxxxxxx.xxx xxx xxxx xxxxxxxxxxx.</p></td>
</tr>
<tr class="odd">
<td align="left">**Xxxxxx Xxxxxxxxxx Xxxxxxxx**</td>
<td align="left"><p>Xxx **xxxxxxXxxxxxxxxx** xxxxxxxxxx xxxxxxxxxx xxxxxx xxxx xx xxxxxxxx Xxxxxxx xxxx x xxxxxx xxx xxxx xxx xxxxxx xxxxxxxxxxx.</p></td>
</tr>
<tr class="even">
<td align="left">**Xxxxxxxxxx Xxxxxxx Xxxxxxxxxxxx**</td>
<td align="left"><p>Xxx **xxxxxxxXxxxxxxxxxXxxxxxxXxxxxxxxxxxx** xxxxxxxxxx xxxxxxxxxx xxxxxx xxxx xx xxxxxx xxx xxxxxxxx xxxx xxxxxxx xxx xxxxxx xxxx XXXX xxx XXXX xxxxxxxxxx. Xxxx xxxx xxx xxxx xxxxxxxxxx xxx xxxxxxx xx Xxxxxx Xxxxxxxxx xx xxxxxx xxx xxxxxxx xxxx xxxxxxx xx xxxxx xxxxxx xxxxxxx.</p></td>
</tr>
<tr class="odd">
<td align="left">**Xxxx Xxxx Xxxxxxxxxxxx**</td>
<td align="left"><p>Xxx **xxxxxxxXxxxXxxxXxxxxxxxxxxx** xxxxxxxxxx xxxxxxxxxx xxxxxx xxxx xx xxxxxx xxxxxxxxxxx xxxxx xxxx xxxxx xx xxx xxxxxx xxx xxxx xxxxxxx xxxxx. Xxxx xxxx xxx xxxx xxxxxxxxxx xxx xxxxxxx xx Xxxxxx Xxxxxxxxx xx xxxxxxxxx xxxxx xxxxxxxxx’ xxxxxx xxxx xxxxx xxxx xxx XX Xxxx xxxxx xxxxxxx.</p></td>
</tr>
<tr class="even">
<td align="left">**Xxxxxxxx Xxxxxxxxx**</td>
<td align="left"><p>Xxx **xxxxxXxxxxXxxxxxxXxxxx** xxxxxxxxxx xxxxxxxxxx xxxxxx xxxx xx xxxxx xxxxxxxx xxxxxxxxx xxxxxxxx.</p></td>
</tr>
<tr class="odd">
<td align="left">**Xxxxxxxx Xxxxxxxxx**</td>
<td align="left"><p>Xxx **xxxxxxxxXxxxxxxxxXxxxxxxxxxXxxxx** xxxxxxxxxx xxxxxxxxxx xxxxxx xxxx xx xxxx xxxxx xxxx xxx xxx xx xxx xx xxx xxxxxxxxxx.</p>
<p>Xxx **xxxxxxxxXxxxxxxxxXxxxxxxx** xxxxxxxxxx xxxxxxxxxx xxxxxx xxxx xx xxxxx x xxxxxxxx xxxxxxxx xxxxxxxxx xxxxxxx.</p>
<p>Xxx **xxxxxxxxXxxxxxxxxXxxxxxxxxxxxx** xxxxxxxxxx xxxxxxxxxx xxxxxx xxxx xx xxxxx xx xxxxxxxxxxxxx xxxxxxxx xxxxxxxxx xxxxxxx.</p></td>
</tr>
<tr class="even">
<td align="left">**Xxxxxx Xxxxxx Xxxxxxxxxx**</td>
<td align="left"><p>Xxx **xxxxxxXxxxxxxxxxXxXxxxxxx** xxxxxxxxxx xxxxxxxxxx xxxxxx xxxx xx xxxxxxxxx xxx xxxxxxxxx Xxxxxx Xxxxxxxx Xxxx Xxxxxx Xxxxxxxx - Xxxxxx Xxxxxxxxxx (XX XXX-XX) xxxxxxxx.</p>
<p>Xxx **xxxxxxXxxxxxxxxxXxxxxxxxxx** xxxxxxxxxx xxxxxxxxxx xxxxxx xxxx xx xxxx xxxxx xxxxxx xx xxx Xxxxxx Xxxxxx Xxxxxxxxxx (XXX) xxxxxxxxxxxxx xxxxxxx xxxxxxxx (XXX) xxxxxxxxxxxxxx xx xxx xxxxxx. Xxxx xxxx xxxxx xxxxxxxxxxxx xxx xxxxxx xx xxxxxx xxxxxxxx XXXx.</p>
<p>Xxx **xxxxxxXxxxxxxxxxXxxXxxxxxxxXxxxxxxx** xxxxxxxxxx xxxxxxxxxx xxxxxx xxxx xx xxxxxxxxx Xxxxxxxx Xxxxxxxxxxx Xxxxxxxx (XXX)-xxxxx xxxxxxxx xxxx xx XXx, Xxxxxxx Xxxxxxxxxx/Xxxxxxx Xxxxxxx (XX/XX), xxx Xxxx Xxxxxx Xxxxxxxx - Xxxxxx Xxxxxxxxxxxx (XXX-XX).</p>
<p>Xxx **xxxxxxXxxxxxxxxxXxxxxXxxxxxx** xxxxxxxxxx xxxxxxxxxx xxxxxx xxxx xxxxxxx xx Xxxxxx Xxxxxxxxx xx xxx xxx xxxxxx xx xxxxx xxxxxxx xx xxxxxxx xxxx xxxxxxxxx xx xxxxx.</p></td>
</tr>
<tr class="odd">
<td align="left">**Xxxxxxx Xxxxxx Xxxxxxx**</td>
<td align="left"><p>Xxx **xxxxxxxXxxxxxXxxxxx** xxxxxxxxxx xxxxxxxxxx xxxxxx xxxx xx xxxx xxxxxxx xx xxxxxx xxxxxxxx xxxxxxx xx xxxx xxxx xxx xxxxxxxxx xx xxx xxxxxx.</p></td>
</tr>
<tr class="even">
<td align="left">**Xxxxx Xxxx**</td>
<td align="left"><p>Xxx **xxxxXxxx** xxxxxxxxxx xxxxxxxxxx xxxxxx xxxx xx xxx x xxxx xx xxxxx xxxxx xxxxxxxxx xx xxx xxxxxx.</p></td>
</tr>
<tr class="odd">
<td align="left">**Xxxx Xxxxxxxxx**</td>
<td align="left"><p>Xxx **xxxxXxxxxxxxxXxxxxxxxxx** xxxxxxxxxx xxxxxxxxxx xxxxxx xxxx xx xxxxxxxx xxxxxx Xxxx xxxxxxx xxxx xxxxxxx xx xxx Xxxx xxxxxxxx xxxxxxxxxxxxx.</p></td>
</tr>
<tr class="even">
<td align="left">**Xxxxxx Xxxxxxxxxxx xxx Xxxxxxxxxxx**</td>
<td align="left"><p>Xxx **xxxxxxxXxxxxxXxxxxxxxx** xxxxxxxxxx xxxxxxxxxx xxxxxx xxxx xx xxxxxx xxx xxxx xxxxxxxx xx Xxxxxxx.</p></td>
</tr>
<tr class="odd">
<td align="left">**Xxxxxxxxx Xxxxxxxxxx**</td>
<td align="left"><p>Xxx **xxxxxxxxxXxxxxxx** xxxxxxxxxx xxxxxxxxxx xxxxxx xxxx xx xxxxxxxx xx xx xxxxxxxxx xxx xxx xxx-xx xx xxxxxxxx xxx xxxxxxxxxxxxx xx xxxx xxxx xxx xx xxxxxxxxx xx xxxxxxxxxxx xxx xxxxxxx xx xxx xxxx.</p></td>
</tr>
<tr class="even">
<td align="left">**Xxxxxx xxxxxx**</td>
<td align="left"><p>Xxx **xxxxxxxXxxxxxxx** xxxxxxxxxx xxxxxxxxxx xxxxxx xxxx xx xxxxxxxx xxxxxxxx xxxx xxxxxxx.</p></td>
</tr>
<tr class="odd">
<td align="left">**Xxxxxxxxxx xxxxxxxxxxx**</td>
<td align="left"><p>Xxx **xxxxxXxxxxxxxxxXxxxxxxxxxx** xxxxxxxxxx xxxxxxxxxx xxxxxx xxxx xx xxx xxxxxxxxxx xx xxxxxxxxx xxxxxxxx xxxxx xxx xxxxxxx xxx xxx-xxx xxxxxxxx xxxxx xxxxxxxxxx. XXX xxxxxxxxxxxx xxxxxx xx xxxxxxxxxxx xx xxxx xxxxxxxxxx. Xxxx xxxxxxxxxx xx xxxxxxxx xx xxxxxx xxxxxxx xx xxx [**XxxxxxxxXxxxxxxxXxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Mt608395) xxxxx.</p></td>
</tr>
<tr class="even">
<td align="left">**XXX xxx XX Xxxxxxx xxxx**</td>
<td align="left"><p>Xxx **xxxXxxxxxxxxx** xxxxxxxxxx xxxxxxxxxx xxxxxx xxxx xxxx xxx xxxxxxx xx Xxxxxxxxx xxxxxxxx xx xxxxxxx xxx xxxx xxx xxxxx xxxxxxxxx xxxxxxxxx xxxx xx xxx xxxxxx.</p>
<p>Xxx **xxxXxxxxxXxxxxxxxx** xxxxxxxxxx xxxxxxxxxx xxxxxx xxxx xxxx xxx xxxxxxx xx Xxxxxxxxx xxxxxxxx xx xxxx xxxxxx xx xxx xxxxxx xxx xxxxxx.</p></td>
</tr>
</tbody>
</table>

**Xxxx**  
Xxxx xxxxxxx xx xxx Xxxxxxx YY xxxxxxxxxx xxxxxxx XXX xxxx. Xx xxx’xx xxxxxxxxxx xxx Xxxxxxx Y.x xx Xxxxxxx Xxxxx Y.x, xxx xxx [xxxxxxxx xxxxxxxxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132).

## Xxxxxxx xxxxxx

* [Xxxxxxxx Xxxxxxxx](https://msdn.microsoft.com/en-us/library/windows/apps/xaml/br230259.aspx)
* [Xxxxxxxxxx xxx xxxxxxx-xxxxx xxxx](https://msdn.microsoft.com/library/windows/apps/Hh768223)
* [Xxx xx xxxxxxx xxxxxxxxxxxx xx x xxxxxxx xxxxxxxx](https://msdn.microsoft.com/library/windows/apps/BR211477)
* [Xxx xx xxxxxxx xxxxxx xxxxxxxxxxxx xx x xxxxxxx xxxxxxxx](https://msdn.microsoft.com/library/windows/apps/Dn263092)
 

<!--HONumber=Mar16_HO1-->
