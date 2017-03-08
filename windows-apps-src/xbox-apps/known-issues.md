---
author: Mtoepke
title: "Xbox One 開発者プログラムの UWP の既知の問題"
description: 
ms.author: mtoepke
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.assetid: a7b82570-1f99-4bc3-ac78-412f6360e936
translationtype: Human Translation
ms.sourcegitcommit: 5645eee3dc2ef67b5263b08800b0f96eb8a0a7da
ms.openlocfilehash: 4b13b9bbbc75de47ed69112680894d5e3f34d8a1
ms.lasthandoff: 02/08/2017

---

# <a name="known-issues-with-uwp-on-xbox-developer-program"></a>Xbox 開発者プログラムの UWP の既知の問題

このトピックでは、Xbox One 開発者プログラムの UWP の既知の問題について説明します。 このプログラムについて詳しくは、「[Xbox One の UWP](index.md)」をご覧ください。 

\[API リファレンス トピックのリンクからこのページを見つけた、ユニバーサル デバイス ファミリの API の情報を探している方は、「[Xbox でまだサポートされていない UWP 機能](http://go.microsoft.com/fwlink/?LinkID=760755)」をご覧ください。\]

以下では、発生する可能性のある既知の問題を示していますが、すべての問題は網羅されていません。 

**お客様からのフィードバックは重要ですので**、問題が見つかりましたら[ユニバーサル Windows プラットフォーム アプリの開発](https://social.msdn.microsoft.com/forums/windowsapps/home?forum=wpdevelop)フォーラムでご報告ください。 

行き詰まった場合は、このトピックの情報をお読みください。「[よく寄せられる質問](frequently-asked-questions.md)」を利用することも、フォーラムに質問を投稿することもできます。


<!--## Developing games-->

## <a name="issue-when-leaving-dev-mode"></a>開発者モード終了時に発生する問題
DevHome を使用しても [開発者向け設定] からも、開発者モードを終了できない場合があります。
この問題の回避策として、次の 2 つが考えられます。 
1. 開発者モードを終了するときに、**[Delete side loaded games and apps]** (サイドローディングされたゲームとアプリを削除する) チェック ボックスをオフにする
2. [マイ コレクション] に移動し、コンソールにインストールした開発者向けアプリをアンインストールする
 
<!--## Memory limits for background apps are partially enforced
 
The maximum memory footprint for apps running in the background is 128 megabytes. In the current version of UWP on Xbox One, your app will be suspended if it is above this limit when it is moved to the background. This limit is not currently enforced if your app exceeds the limit while it is already running in the background—this means that if your app exceeds 128 MB while running in the background, it will still be able to allocate memory.
 
There is currently no workaround for this issue. Apps should govern their memory usage accordingly and continue to stay under the 128 MB limit while running in the background.-->
 
## <a name="deploying-from-vs-fails-with-parental-controls-turned-on"></a>[保護者による制限] を有効にしたことにより VS からの展開に失敗する

本体で [設定] の [保護者による制限] を有効にした場合、VS からのアプリの起動が失敗します。

この問題を回避するには、[保護者による制限] を一時的に無効にするか、次の操作を行います。
1. [保護者による制限] を無効にして、本体にアプリを展開します。
2. [保護者による制限] 有効にします。
3. 本体からアプリを起動します。
4. アプリを起動できるように、PIN またはパスワードを入力します。
5. アプリが起動します。
6. アプリを閉じます。
7. F5 キーを使用して VS から起動すると、プロンプトを表示せずにアプリが起動します。

この時点では、アプリのアンインストールと再インストールを行っても、ユーザーをサインアウトさせるまで、アクセス許可は_固定_されます。
 
お子様のアカウントのみで利用できる、不適切なコンテンツの除外方法もあります。 お子様のアカウントでは、保護者がサインインしてアクセス許可を付与する必要がありますが、アクセス許可を付与するときに、保護者は、お子様によるアプリの起動を**常に許可**するように選ぶこともできます。 このような除外の情報はクラウドに保存され、お子様がサインアウトして、もう一度サインインした場合でも、維持されます。   

<!--### x86 vs. x64

By the time we release later this year, we will have great support for both x86 and x64, and we do support x86 in this preview. 
However, x64 has had much more testing to date (the Xbox shell and all of the apps running on the console today are x64), and so we recommend using x64 for your projects. 
This is particularly true for games.

If you decide to use x86, please report any issues you see on the forum.

Also see [Switching build flavors can cause deployment failures](known-issues.md#switching-build-flavors-can-cause-deployment-failures) later on this page.-->

<!--### Game engines

We have tested some popular game engines, but not all of them, and our test coverage for this preview has not been comprehensive. 
Your mileage may vary. 

The following game engines have been confirmed to work:
* [Construct 2](https://www.scirra.com/)

There are likely others that are working too. We would love to get your feedback on what you find. 
Please use the forum to report any issues you see.-->

## <a name="directx-12-support"></a>DirectX 12 のサポート

Xbox One の UWP は、DirectX 11 の機能レベル 10 をサポートしています。 現時点では DirectX 12 はサポートされていません。 

Xbox One は、従来のすべてのゲーム コンソールと同じように、その潜在的な機能を最大限に利用するために特定の SDK を必要とする特殊なハードウェアです。 Xbox One のハードウェアの機能を最大限に利用する必要があるゲームを開発している場合、[ID@XBOX](http://www.xbox.com/Developers/id) プログラムに登録することで、DirectX 12 のサポートを含む SDK にアクセスできます。

<!-- ### Xbox One Developer Preview disables game streaming to Windows 10

Activating the Xbox One Developer Preview on your console will prevent you from streaming games from your Xbox One to the Xbox app on Windows 10, even if your console is set to retail mode. 
To restore the game streaming feature, you must leave the developer preview. -->

<!--## System resources for UWP apps and games on Xbox One

UWP apps and games running on Xbox One share resources with the system and other apps, and so the system governs the resources that are available to any one game or app. 
If you are running into memory or performance issues, this may be why. 
For more details, see [System resources for UWP apps and games on Xbox One](system-resource-allocation.md).-->

<!--
## Networking using traditional sockets

In this developer preview, inbound and outbound network access from the console that uses traditional TCP/UDP sockets (WinSock, Windows.Networking.Sockets) is not available. 
Developers can still use HTTP and WebSockets.
--> 

## <a name="blocked-networking-ports-on-xbox-one"></a>Xbox One のネットワーク ポートのブロック

Xbox One デバイスでは、範囲 [57344, 65535] に含まれるポートへのユニバーサル Windows プラットフォーム (UWP) アプリのバインドは制限されています。 実行時にはこの範囲のポートへのバインドは成功しているように見えても、ネットワーク トラフィックはアプリに到達する前にエラーや警告なしで破棄される可能性があります。 できる限りポート 0 にアプリをバインドし、システムによってローカル ポートが選択されるようにしてください。 使用するポートを指定する必要がある場合は、範囲 [1025, 49151] 内のポート番号を使用する必要があります。この場合、IANA レジストリと競合しないように、確認してください。 詳しくは、[サービス名およびトランスポート プロトコル ポート番号のレジストリ](http://www.iana.org/assignments/service-names-port-numbers/service-names-port-numbers.xhtml)についてのページをご覧ください。

## <a name="uwp-api-coverage"></a>UWP API カバレッジ

Xbox では、すべての UWP API がサポートされているわけではありません。 動作しないことが確認されている API の一覧については、「[Xbox でまだサポートされていない UWP 機能](http://go.microsoft.com/fwlink/p/?LinkId=760755)」をご覧ください。 他の API に問題が見つかった場合は、フォーラムでご報告ください。 

<!--## XAML controls do not look like or behave like the controls in the Xbox One shell

In this developer preview, the XAML controls are not in their final form. In particular:
* Gamepad X-Y navigation does not work reliably for all controls.
* Controls do not look like controls in the Xbox shell. This includes the control focus rectangle.
* Navigating between controls does not automatically make “navigation sounds.”

These issues will be addressed in a future developer preview.-->

<!--## Visual Studio and deployment issues

### Switching build flavors can cause deployment failures

Switching between Debug and Release builds, or between x86 and x64, or between Managed and .Net Native builds, can cause deployment failures. 

The simplest way to avoid these issues for this preview is to stick to Debug and one architecture. 

If you do hit this issue, uninstalling your app in the Collections app on your Xbox One will typically resolve it.

> ****&nbsp;&nbsp;Uninstalling your app from Windows Device Portal (WDP) will not resolve the issue.

If your issues persist, uninstall your app or game in the Collections app, leave Developer Mode, restart to Retail Mode and then switch back to Developer Mode.
You may also need to restart Visual Studio and clean your solution.

For more information, see the “Fixing deployment failures” section in [Frequently asked questions](frequently-asked-questions.md).

### Uninstalling an app while you are debugging it in Visual Studio will cause it to fail silently

Attempting to uninstall an app that is running under the debugger via the WDP “Installed Apps” tool will cause it to silently fail. 
The workaround is to stop debugging the app in Visual Studio before attempting to remove it via WDP.

### Visual Studio/Xbox PIN pairing failures

It is possible to get into a state where the PIN pairing between Visual Studio and your Xbox One gets out of sync. 
If PIN pairing fails, use the “Remove all pairings” button in Dev Home, restart Xbox One, restart your development PC, and then try again.--> 


<!--## Windows Device Portal (WDP) preview-->

<!--### Starting WDP from Dev Home crashes Dev Home

When you start WDP in Dev Home, it will cause Dev Home to crash after you have entered your user name and password and selected **Save**. 
The credentials are saved but WDP is not started. 
You can start WDP by restarting Xbox One.--> 

<!--### Disabling WDP in Dev Home does not work

If you disable WDP in Dev Home, it will be turned off. 
However, when you restart your Xbox One, WDP will be started again. 
You can work around this issue by using **Reset and keep my games & apps** to delete any stored state on your Xbox One. 
Go to Settings > System > Console info & updates > Reset console, and then select the **Reset and keep my games & apps** button.

> **Caution**&nbsp;&nbsp;Doing this will delete all saved settings on your Xbox One including wireless settings, user accounts and any game progress that has not been saved to cloud storage.

> **Caution**&nbsp;&nbsp;DO NOT select the **Reset and remove everything** button.
This will delete all of your games, apps, settings and content, deactivate Developer Mode, and remove you console from the Developer Preview group.

### The columns in the “Running Apps” table do not update predictably. 

Sometimes this is resolved by sorting a column on the table.-->

## <a name="navigating-to-wdp-causes-a-certificate-warning"></a>WDP に移動すると証明書の警告が表示される

提供された証明書についての、次のスクリーン ショットのような警告が表示されます。これは、Xbox One 本体によって署名されたセキュリティ証明書が、既知の信頼された発行元とは見なされないためです。 Windows Device Portal にアクセスするには、**[このサイトの閲覧を続行する]** をクリックします。

![Web サイトのセキュリティ証明書の警告](images/security_cert_warning.jpg)

<!--## Dev Home

Occasionally, selecting the “Manage Windows Device Portal” option in Dev Home will cause Dev Home to silently exit to the Home screen. 
This is caused by a failure in the WDP infrastructure on the console and can be resolved by restarting the console.-->

## <a name="knownfoldersmediaserverdevices-caveat-on-xbox"></a>Xbox での KnownFolders.MediaServerDevices の注意事項

デスクトップでは、メディア サーバーが PC と "ペアリング" されており、どのサーバーが現在オンラインかをデバイス関連付けサービスが常に追跡しているため、初期ファイル システム クエリが現在オンラインのペアリング済みサーバーの一覧をすぐに返すことができます。

Xbox では、サーバーを追加または削除する UI がないため、初期ファイル システム クエリは常に空の一覧を返します。 クエリを作成して ContentsChanged イベントにサブスクライブし、通知を受け取るたびにクエリを更新する必要があります。 サーバーは少しずつ明らかになり、ほとんどは 3 秒以内に検出されます。

シンプルなサンプル コード:

```
namespace TestDNLA {

    public sealed partial class MainPage : Page {
        public MainPage() {
            this.InitializeComponent();
        }

        private async void FindFiles_Click(object sender, RoutedEventArgs e) {
            try {
                StorageFolder library = KnownFolders.MediaServerDevices;
                var folderQuery = library.CreateFolderQuery();
                folderQuery.ContentsChanged += FolderQuery_ContentsChanged;
                IReadOnlyList<StorageFolder> rootFolders = await folderQuery.GetFoldersAsync();
                if (rootFolders.Count == 0) {
                    Debug.WriteLine("No Folders found");
                } else {
                    Debug.WriteLine("Folders found");
                }
            } catch (Exception ex) {
                Debug.WriteLine("Error: " + ex.Message);
            } finally {
                Debug.WriteLine("Done");
            }
        }

        private async void FolderQuery_ContentsChanged(Windows.Storage.Search.IStorageQueryResultBase sender, object args) {
            Debug.WriteLine("Folder added " + sender.Folder.Name);
            IReadOnlyList<StorageFolder> topLevelFolders = await sender.Folder.GetFoldersAsync();
            foreach (StorageFolder topLevelFolder in topLevelFolders) {
                Debug.WriteLine(topLevelFolder.Name);
            }
        }
    }
}
```

## <a name="see-also"></a>関連項目
- [よく寄せられる質問](frequently-asked-questions.md)
- [Xbox One の UWP](index.md)

