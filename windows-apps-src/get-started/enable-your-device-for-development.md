---
author: GrantMeStrength
ms.assetid: 54973C62-9669-4988-934E-9273FB0425FD
title: "デバイスを開発用に有効にする"
description: "開発およびデバッグ用に Windows 10 デバイスを構成します。"
keywords: "デバイスを有効にする"
translationtype: Human Translation
ms.sourcegitcommit: ed91f7585b63199ab9d591c712d4260a3b452b85
ms.openlocfilehash: 416dce2f7cbe3bba9285f7e354868a2c00728802

---
# <a name="enable-your-device-for-development"></a>デバイスを開発用に有効にする

アプリを作成する前に、開発用 PC と、コードのテストを実行するデバイスの両方で、開発者モードを有効にする必要があります。

## <a name="use-developer-features"></a>開発者向け機能を使用する

### <a name="develop-your-app-with-microsoft-visual-studio"></a>Microsoft Visual Studio を使ってアプリを開発する

Visual Studio で UWP アプリ プロジェクトを開くには、その前に、使用している PC で開発者モードを有効にする必要があります。 UWP プロジェクトを開くときに開発者モードを有効にしていないと、**[開発者向け]** 設定ページが自動的に開きます。 開発者モードを有効にするには、次のセクションの手順に従ってください。

Windows 10 バージョン 1511 以前の Visual Studio で UWP アプリ プロジェクトを開くと、Visual Studio ではこのダイアログが表示されます。 

![Visual Studio で表示される、開発者モードを有効にするためのダイアログ](images/latestenabledialog.png)

このダイアログが表示される場合、**[開発者向け設定]** をクリックして **[開発者向け] ** 設定ページを開き、開発者モードを有効にします。

> **[開発者向け]** ページにいつでも移動し、開発者モードの有効/無効を切り替えられます。その場合には、タスク バーの Cortana 検索ボックスに「開発者向け設定」と入力するだけです。

### <a name="enable-your-windows-10-devices"></a>Windows 10 デバイスを有効にする

デバイスを開発用に有効にしたり、サイドローディングのみを目的として有効にしたりできます。

-   *サイドローディング*では、Windows ストアの認証を受けていないアプリをインストールし、実行やテストを行うことができます。 たとえば、社内のみで使うアプリなどがあります。
-   *開発者モード*を使用すると、アプリをサイドロードし、Visual Studio からデバッグ モードでアプリを実行することもできます。 

    開発者モードを有効にすると、次のようなオプション パッケージがインストールされます。
    - Windows Device Portal がインストールされます。 Device Portal が有効になり、ファイアウォール規則が構成されるのは、**[デバイス ポータルを有効にする]** オプションがオンの場合のみです。
    - アプリのリモート インストールを可能にする SSH サービスのファイアウォール規則がインストールされ、有効になり、構成されます。
    - (デスクトップのみ) Linux 用 Windows サブシステムを有効にできます。 詳しくは、「[Bash on Ubuntu on Windows について](https://msdn.microsoft.com/commandline/wsl/about)」をご覧ください。

オプションについて詳しくは、「[選ぶ必要がある設定: アプリのサイドローディングか開発者モードか](https://msdn.microsoft.com/en-us/windows/uwp/get-started/enable-your-device-for-development#which-settings-should-i-choose-sideload-apps-or-developer-mode)」をご覧ください。

**開発者向け機能を使用するには**

1.  有効にするデバイスで、**[設定]** に移動します。 **[更新とセキュリティ]**、**[開発者向け]** の順にクリックします。
2.  必要なアクセス レベルを選択します。UWP アプリを開発する場合は、**[開発者モード]** を選択します。 
3.  選択した設定の免責事項を読み、**[はい]** をクリックして変更を受け入れます。

> [!NOTE]
> 組織所有のデバイスの場合、ここに示されているように、組織によっていくつかのオプションが無効になっている可能性があります。

デスクトップ デバイス ファミリの設定ページを以下に示します。

![[設定] に移動し、[更新とセキュリティ] を選び、[開発者用] を選んでオプションを表示する](images/devmode-pc-options.png)

モバイル デバイス ファミリの設定ページを以下に示します。

![電話の [設定] から [更新とセキュリティ] を選ぶ](images/devmode-mob.png)

## <a name="developer-mode-features"></a>開発者モードの機能

各デバイス ファミリには、開発者向けの追加機能が用意されている場合があります。 これらの機能は、デバイスで開発者モードが有効になっている場合にのみ使用でき、OS バージョンによって異なる可能性があります。

次の画像は、Windows 10 Version 1511 が搭載されたモバイル デバイス ファミリの開発者向け機能を示しています。

![モバイル デバイスの開発者モード オプション](images/devmode-mob-options.png) 

### <a name="span-iddevice-discovery-and-pairingspandevice-portal"></a><span id="device-discovery-and-pairing"></span>Device Portal

デバイスの検出と Device Portal について詳しくは、「[Windows Device Portal の概要](../debug-test-perf/device-portal.md)」をご覧ください。

デバイス固有のセットアップ手順については、以下をご覧ください。
- [デスクトップ用 Device Portal](https://msdn.microsoft.com/windows/uwp/debug-test-perf/device-portal-desktop)
- [HoloLens 用 Device Portal](https://dev.windows.com/holographic/using_the_windows_device_portal)
- [IoT 用 Device Portal](https://developer.microsoft.com/windows/iot/docs/DevicePortal)
- [モバイル用 Device Portal](../debug-test-perf/device-portal-mobile.md)
- [Xbox 用 Device Portal](../debug-test-perf/device-portal-xbox.md)

開発者モードまたは Device Portal を有効にするときに問題が発生する場合、「[既知の問題](https://social.msdn.microsoft.com/Forums/en-US/home?forum=Win10SDKToolsIssues&sort=relevancedesc&brandIgnore=True&searchTerm=%22device+portal%22)」フォーラムを参照してこれらの問題の回避策を見つけてください。 

###<a name="ssh"></a>SSH

デバイスで開発者モードを有効にすると、SSH サービスが有効になります。  デバイスが UWP アプリケーションの展開ターゲットの場合にこれを使用します。   サービスの名前は、「SSH Server Broker」と「SSH Server Proxy」です。

> [!NOTE]
> これは Microsoft の OpenSSH の実装ではありません。それは [GitHub](https://github.com/PowerShell/Win32-OpenSSH) にあります。

SSH サービスを利用するには、デバイスの検出を有効にして PIN のペアリングを許可できます。 別の SSH サービスを実行する予定の場合、別のポートにセットアップするか、開発者モードの SSH サービスを無効にできます。 これらの SSH サービスを無効にするには、開発者モードを無効にするだけです。  

### <a name="device-discovery"></a>デバイスの検出

デバイスの検出を有効にすると、ネットワーク上の他のデバイスから mDNS を介してそのデバイスが表示できるようになります。  またこの機能では、対象デバイスをペアリングするための SSH PIN も取得できます。  

![PIN のペアリング](images/devmode-pc-pinpair.PNG)

デバイスを展開ターゲットにする予定の場合にのみ、デバイスの検出を有効にする必要があります。 たとえば、Device Portal を使用してアプリを電話に展開してテストする場合、その電話でデバイスの検出を有効にする必要がありますが、開発用 PC では不要です。

### <a name="error-reporting-mobile-only"></a>エラー報告 (モバイルのみ)

電話に保存されるクラッシュ ダンプの数を指定するには、この値を設定します。

電話でクラッシュ ダンプを収集することで、クラッシュの発生直後に重要なクラッシュ情報にすばやくアクセスできます。 開発者が署名したアプリに対してのみ、ダンプが収集されます。 ダンプは、電話の記憶域の Documents\\Debug フォルダーにあります。 ダンプ ファイルについて詳しくは、[ダンプ ファイルの使用](https://msdn.microsoft.com/library/d5zhxt22.aspx)に関するページをご覧ください。

### <a name="optimizations-for-windows-explorer-remote-desktop-and-powershell-desktop-only"></a>エクスプローラー、リモート デスクトップ、PowerShell の最適化 (デスクトップのみ)

 デスクトップ デバイス ファミリの場合、**[開発者向け]** 設定ページには、開発タスク用 PC を最適化するために使用できる設定へのショートカットが備わっています。 それぞれの設定で、チェック ボックスを選択して **[適用]** をクリックするか、**[設定の表示]** リンクをクリックして対象オプションの設定ページを開くことができます。 

## <a name="which-settings-should-i-choose-sideload-apps-or-developer-mode"></a>選ぶ必要がある設定: アプリのサイドローディングか開発者モードか

既定では、Windows ストアからのみユニバーサル Windows プラットフォーム (UWP) アプリをインストールできます。 開発者向け機能を使用するように設定を変更すると、デバイスのセキュリティ レベルが変わる場合があります。 未検証のソースからはアプリをインストールしないでください。

### <a name="sideload-apps"></a>アプリのサイドローディング

アプリのサイドローディング設定は、通常、Windows ストアを使わずにカスタム アプリを管理対象デバイスにインストールする必要がある会社や学校によって使用されます。 この場合、設定ページのイメージで以前に示したように、*Windows ストア アプリ*設定を無効にするポリシーを組織が適用していることはよくあります。 また、組織は、必要な証明書と、アプリをサイドローディングするインストール場所を提供します。 詳しくは、TechNet の記事「[Windows 10 でのアプリのサイド ローディング](https://technet.microsoft.com/library/mt269549.aspx)」と「[Microsoft Intune でのアプリ展開の開始](https://technet.microsoft.com/library/dn646955.aspx)」をご覧ください。

デバイス ファミリ固有の情報

-   デスクトップ デバイス ファミリの場合: パッケージと共に作成される Windows PowerShell スクリプトを実行して、アプリの実行に必要なアプリ パッケージ (.appx) と証明書をインストールできます ("Add-AppDevPackage.ps1")。 詳しくは、「[UWP アプリのパッケージ化](../packaging/packaging-uwp-apps.md)」をご覧ください。

-   モバイル デバイス ファミリの場合: 必要な証明書が既にインストールされている場合は、電子メールまたは SD カードで受け取ったファイルをタップして、.appx をインストールできます。

信頼できる証明書がないデバイスにアプリをインストールすることはできないため、**アプリのサイドローディング**は開発者モードよりも安全です。

> [!NOTE]
> アプリをサイドローディングする場合は、信頼できるソースからのみアプリをインストールしてください。 サイドローディングしたアプリ (Windows ストアの認証を受けていないアプリ) をインストールする場合は、そのアプリをサイドローディングする際に必要なすべての権利をお客様が保持していること、およびそのアプリのインストールや実行の結果生じるすべての問題についてお客様が一切の責任を負うことに同意したものと見なされます。 この[プライバシーに関する声明](http://go.microsoft.com/fwlink/?LinkId=521839)の「Windows」&gt;「Windows ストア」セクションをご覧ください。

### <a name="developer-mode"></a>開発者モード

開発者モードは、開発者用ライセンスに対する Windows 8.1 の要件に置き換わるものです。  サイドローディングだけでなく、開発者モードの設定でデバッグおよび追加の展開オプションを有効にできます。 デバイスを展開先にできるようにする SSH サービスの開始も含まれます。 このサービスを停止するためには、開発者モードを無効にしなければなりません。

デバイス ファミリ固有の情報

-   デスクトップ デバイス ファミリの場合:

    開発者モードを有効にして、Visual Studio でアプリを開発およびデバッグします。 既に説明したように、開発者モードが有効になっていない場合は、Visual Studio で有効にするように求められます。

    Linux 用の Windows サブシステムを有効にできます。 詳しくは、「[Bash on Ubuntu on Windows について](https://msdn.microsoft.com/commandline/wsl/about)」をご覧ください。

-   モバイル デバイス ファミリの場合:

    開発者モードを有効にして、Visual Studio からアプリを展開し、デバイスでそのアプリをデバッグします。

    電子メールまたは SD カードで受け取ったファイルをタップして、.appx をインストールできます。 未検証のソースからはアプリをインストールしないでください。

**ヒント**  
Windows 10 PC から Windows 10 モバイル デバイスへのアプリの展開に使用できるツールはいくつかあります。 デバイスは両方ともワイヤード (有線) またはワイヤレスでネットワークの同じサブネットに接続されているか、または 2 台のデバイスが USB で接続されている必要があります。 どちらの方法を使用しても、アプリ パッケージ (.appx) のみがインストールされます。証明書はインストールされません。

-   Windows 10 アプリケーション展開 (WinAppDeployCmd) ツールを使います。 詳しくは、[WinAppDeployCmd ツール](http://msdn.microsoft.com/library/windows/apps/mt203806.aspx)に関するページをご覧ください。
-   Windows 10 バージョン 1511 以降では、[デバイス ポータル](#device_portal)を使用して、ブラウザーから、Windows 10 バージョン 1511 以降を実行しているモバイル デバイスに展開できます。 Device Portal の **[アプリ](../debug-test-perf/device-portal.md#apps)** ページを使用して、アプリ パッケージ (.appx) をアップロードしてデバイスにインストールします。

## <a name="use-group-policies-or-registry-keys-to-enable-a-device"></a>グループ ポリシーまたはレジストリ キーを使用してデバイスを有効にする

ほとんどの開発者のためには、設定アプリを使用して、デバイスでデバッグを有効にします。 自動化テストなど特定のシナリオでは、他の方法を使用して、Windows 10 デスクトップ デバイスで開発を有効にできます。

Windows 10 Home をお持ちでない場合は、gpedit.msc を使って、グループ ポリシーを設定してデバイスを有効にできます。 Windows 10 Home をお持ちの場合は、regedit または PowerShell コマンドを使ってレジストリ キーを直接設定し、デバイスを有効にしてください。

**gpedit を使ってデバイスを有効にする**

1.  **Gpedit.msc** を実行します。
2.  [ローカル コンピューター ポリシー] &gt; [コンピューターの構成] &gt; [管理用テンプレート] &gt; [Windows コンポーネント] &gt; [アプリ パッケージの展開] の順に移動します。
3.  サイドローディングを有効にするには、ポリシーを編集して次を有効にします。

    -   **信頼できるすべてのアプリのインストールを許可する**

    - または -

    開発者モードを有効にするには、ポリシーを編集して次の両方を有効にします。

    -   **信頼できるすべてのアプリのインストールを許可する**
    -   **Windows ストア アプリの開発と統合開発環境 (IDE) からのインストールを許可する**

4.  コンピューターを再起動します。

**regedit を使ってデバイスを有効にする**

1.  **regedit** を実行します。
2.  サイドローディングを有効にするには、この DWORD の値を 1 に設定します。

    -   **HKLM\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\AppModelUnlock\\AllowAllTrustedApps**

    - または -

    開発者モードを有効にするには、この DWORD の値を 1 に設定します。

    -   **HKLM\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\AppModelUnlock\\AllowDevelopmentWithoutDevLicense**

**PowerShell を使ってデバイスを有効にする**

1.  管理者特権で PowerShell を実行します。
2.  サイドローディングを有効にするには、このコマンドを実行します。

    -   **PS C:\\WINDOWS\\system32&gt; reg add "HKEY\_LOCAL\_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\AppModelUnlock" /t REG\_DWORD /f /v "AllowAllTrustedApps" /d "1"**

    - または -

    開発者モードを有効にするには、このコマンドを実行します。

    -   **PS C:\\WINDOWS\\system32&gt; reg add "HKEY\_LOCAL\_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\AppModelUnlock" /t REG\_DWORD /f /v "AllowDevelopmentWithoutDevLicense" /d "1"**

## <a name="upgrade-your-device-from-windows-81-to-windows-10"></a>Windows 8.1 から Windows 10 にデバイスをアップグレードする

Windows 8.1 デバイスでアプリを作成またはサイドローディングするときに、開発者用ライセンスをインストールする必要があります。 Windows 8.1 から Windows 10 にデバイスをアップグレードする場合は、この情報が維持されます。 アップグレードした Windows 10 デバイスからこの情報を削除するには、次のコマンドを実行します。 Windows 8.1 から Windows 10 バージョン 1511 以降に直接アップグレードする場合、この手順は必要ありません。

**開発者用ライセンスを登録解除するには**

1.  管理者特権で PowerShell を実行します。
2.  **unregister-windowsdeveloperlicense** コマンドを実行します。

その後、このトピックで説明されているように、開発用のデバイスを有効にする必要があります。これにより、このデバイスで開発を継続できます。 有効にしない場合、アプリをデバッグしたり、パッケージを作成しようとしたりすると、エラーが発生する可能性があります。 このエラーの例を次に示します。

エラー: DEP0700: アプリケーションの登録に失敗しました。



<!--HONumber=Dec16_HO1-->


