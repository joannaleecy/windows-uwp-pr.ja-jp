---
author: normesta
Description: "Desktop Converter App を実行して、Windows デスクトップ アプリケーション (Win32、WPF、Windows フォームなど) をユニバーサル Windows プラットフォーム (UWP) アプリに変換します。"
Search.Product: eADQiWindows 10XVcnh
title: "Desktop to UWP Bridge の Desktop App Converter"
ms.author: normesta
ms.date: 03/09/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.assetid: 74c84eb6-4714-4e12-a658-09cb92b576e3
ms.openlocfilehash: 4daf45a4637ac846c550430cbc7518238ebd5bd8
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="desktop-to-uwp-bridge-desktop-app-converter"></a>Desktop to UWP Bridge: Desktop App Converter

[Desktop App Converter を入手する](https://aka.ms/converter)

Desktop App Converter (DAC) は、.NET 4.6.1 または Win32 向けに記述された既存のデスクトップ アプリをユニバーサル Windows プラットフォーム (UWP) に変換するためのツールです。 このコンバーターを使って、無人 (サイレント) モードでデスクトップのインストーラーを実行し、開発コンピューターで PowerShell の Add-AppxPackage コマンドレットを使ってインストールすることができる Windows アプリ パッケージを作成できます。

Desktop App Converterは現在、[Windows ストア](https://aka.ms/converter)で入手できます。

このコンバーターは、コンバーターのダウンロードに含まれるクリーンな状態の基本イメージを使って、分離された Windows 環境でデスクトップのインストーラーを実行します。 デスクトップ インストーラーが作成するすべてのレジストリとファイル システムの I/O をキャプチャし、出力の一部としてパッケージ化します。 パッケージ ID を持ち、多くの WinRT API を呼び出すことができる Windows アプリ パッケージを出力します。

## <a name="whats-new"></a>新機能

DAC の最新バージョンは v1.0.9.0 です。 この更新での新しい内容:

* インストーラーを使用しない変換: アプリが Xcopy を使用してインストールされる場合や、アプリのインストーラーがシステムに加える変更について詳しい知識がある場合は、-Installer パラメーターをアプリ ファイルのルート ディレクトリに設定することによって、インストーラーを使用せずに変換を実行できます。
* アプリ パッケージの検証: 新しい `-Verify` フラグを使用して、デスクトップ ブリッジとストアの要件に照らして、変換済みのアプリ パッケージを検証します。


## <a name="system-requirements"></a>システム要件

### <a name="operating-system"></a>オペレーティング システム

+ Windows 10 Anniversary Update (10.0.14393.0 以降) Pro または Enterprise エディション。

### <a name="hardware-configuration"></a>ハードウェア構成

+ 64 ビット (x64) プロセッサ
+ ハードウェア支援による仮想化
+ Second Level Address Translation (SLAT)

### <a name="required-resources"></a>必要なリソース

+ [Windows 10 用 Windows ソフトウェア開発キット (SDK)](https://go.microsoft.com/fwlink/?linkid=821375)

## <a name="set-up-the-desktop-app-converter"></a>Desktop App Converter をセットアップする

*(次の手順はインストーラーを使用しない変換では必要がありません)*

Desktop App Converter は、最新の Windows 10 機能に依存しています。 Windows 10 Anniversary Update (14393.0) 以降のビルドをお使いであることを確認してください。

1.    [DesktopAppConverter を Windows ストアからダウンロード](https://aka.ms/converter)し、[ビルドに対応する基本イメージの .wim ファイル](https://aka.ms/converterimages)をダウンロードします。  
2.    管理者として DesktopAppConverter を実行します。 これには、スタート メニューでタイルを右クリックして *[その他]* から *[管理者として実行]* を選択するか、タスク バーでタイルを右クリックし、表示されるアプリ名を右クリックして *[管理者として実行]* を選択します。
3.    アプリ コンソール ウィンドウから ```Set-ExecutionPolicy bypass``` を実行します。
4.    アプリ コンソール ウィンドウから ```DesktopAppConverter.exe -Setup -BaseImage .\BaseImage-1XXXX.wim -Verbose``` を実行することでコンバーターをセットアップします。
5.    上のコマンドを実行したときに再起動を求めるメッセージが表示されたら、コンピューターを再起動してください。

## <a name="run-the-desktop-app-converter"></a>Desktop App Converter を実行する

+ **ストア ダウンロード**: ```DesktopAppConverter.exe``` を使用してコンバーターを実行します。

### <a name="usage"></a>使用方法

```CMD
DesktopAppConverter.exe
-Installer <String> [-InstallerArguments <String>] [-InstallerValidExitCodes <Int32>]
-Destination <String>
-PackageName <String>
-Publisher <String>
-Version <Version>
[-ExpandedBaseImage <String>]
[-AppExecutable <String>]
[-AppFileTypes <String>]
[-AppId <String>]
[-AppDisplayName <String>]
[-AppDescription <String>]
[-PackageDisplayName <String>]
[-PackagePublisherDisplayName <String>]
[-MakeAppx]
[-LogFile <String>]
[<CommonParameters>]  
```

### <a name="examples"></a>例

次の例では、*MyApp* という名前のデスクトップ アプリを *MyPublisher* で Windows アプリ パッケージに変換する方法を説明します。

#### <a name="no-installer-conversion"></a>インストーラーを使用しない変換

インストーラーを使用しない変換では、`-Installer` パラメーターでアプリ ファイルのルート ディレクトリを指定し、`-AppExecutable` パラメーターが必要です。

```cmd
DesktopAppConverter.exe -Installer C:\Installer\MyApp\ -AppExecutable MyApp.exe -Destination C:\Output\MyApp -PackageName "MyApp" -Publisher "CN=MyPublisher" -Version 0.0.0.1 -MakeAppx -Sign -Verbose
```

#### <a name="installer-based-conversion"></a>インストーラー ベースの変換

インストーラー ベースの変換では、`-Installer` でアプリのセットアップ インストーラーを指定します。

```cmd
DesktopAppConverter.exe -Installer C:\Installer\MyAppSetup.exe -InstallerArguments "/S" -Destination C:\Output\MyApp -PackageName "MyApp" -Publisher "CN=MyPublisher" -Version 0.0.0.1 -MakeAppx -Sign -Verbose
```

## <a name="deploy-your-converted-windows-app-package"></a>変換済みの Windows アプリ パッケージを展開する

PowerShell で [Add-AppxPackage](https://technet.microsoft.com/library/hh856048.aspx) コマンドレットを使って、ユーザー アカウントに対して署名済みのアプリ パッケージ (.appx) を展開します。

Desktop App Converter (v0.1.24) の ```-Sign``` フラグを使って、変換済みアプリの自動署名を行うことができます。 または、「[変換済みのデスクトップ アプリに署名する](desktop-to-uwp-signing.md)」を参照して、AppX パッケージに自己署名する方法を学びます。

また、Add-AppXPackage PowerShell コマンドレットの ```-Register``` パラメーターを使用して、開発プロセス中にパッケージ化を解除したファイルのフォルダーからインストールすることもできます。

変換済みのアプリの展開とデバッグの詳細については、「[変換済みの UWP アプリを展開してデバッグする](desktop-to-uwp-deploy-and-debug.md)」をご覧ください。

## <a name="sign-your-windows-app-package"></a>Windows アプリ パッケージに署名する

Add-AppxPackage コマンドレットを使うには、展開する Windows アプリ パッケージ (.appx) が署名されている必要があります。 コンバーター コマンドラインまたは SignTool.exe の中で ```-Sign``` フラグを使います。これは Microsoft Windows 10 SDK に含まれている、Windows アプリ パッケージに署名を行うためのツールです。

Windows アプリ パッケージに署名を行う方法について詳しくは、「[変換済みのデスクトップ アプリに署名する](desktop-to-uwp-signing.md)」をご覧ください。

注: 自動生成された証明書を使用してパッケージに署名をする場合は、既定のパスワード "123456" を使用する必要があります。

## <a name="modify-vfs-folder-and-registry-hive-optional"></a>VFS フォルダーとレジストリ ハイブを変更する (オプション)

Desktop App Converter は、コンテナー内のファイルとシステム ノイズの除去に、非常に保守的なアプローチを取ります。  lこれは必須ではありませんが、変換後に以下を実行できます。

1. VFS フォルダーを確認し、インストーラーに必要ないファイルを削除します。
2. Reg.dat の内容を確認し、アプリによってインストールされないまたは必要ないキーを削除します。

変換済みのアプリ を変更する場合 (上記を含む)、コンバーターを再実行する必要はありません。MakeAppx ツールと、DAC によってアプリ用に生成された appxmanifest.xml ファイルを使用して、手動でアプリをもう一度パッケージ化します。 詳しくは、「[Desktop Bridge を使って手動でアプリを UWP アプリに変換する](desktop-to-uwp-manual-conversion.md)」をご覧ください。

## <a name="caveats"></a>注意事項

1. ホスト コンピューターの Windows 10 ビルドは、Desktop App Converter ダウンロードに含まれていた基本イメージと一致する必要があります。  
2. コンバーターはディレクトのすべての内容を分離されている Windows 環境にコピーするため、デスクトップ インストーラーが独立したディレクトリにあることを確認します。  
3. 現時点では、Desktop App Converter は 64 ビット オペレーティング システムのみで、変換処理の実行をサポートします。 変換済みの Windows アプリ パッケージは、64 ビット (x64) OS のみに展開できます。  
4. Desktop App Converter では、デスクトップ インストーラーを無人モードで実行する必要があります。 *- InstallerArguments* パラメーターを使って、インストーラーのサイレント フラグをコンバーターに渡してください。
5. パブリック SxS Fusion アセンブリの公開は機能しません。 アプリケーションは、インストール中にパブリック side-by-side Fusion アセンブリを公開して、他のプロセスからアクセスできるようにします。 これらのアセンブリは、プロセスのアクティブ化コンテキストの作成中に、CSRSS.exe という名前のシステム プロセスによって取得されます。 変換プロセスでこれが行われると、アクティブ化コンテキスト作成とこれらのアセンブリのモジュール読み込みは失敗します。 ComCtl などの受信トレイ アセンブリは OS に同梱されているので、これらのアセンブリに依存していても安全です。 SxS Fusion アセンブリは、次の場所に登録されています。
  + レジストリ: `HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\SideBySide\Winners`
  + ファイル システム: %windir%\\SideBySide

## <a name="known-issues"></a>既知の問題

* 一部の OS ビルドで発生する以下のエラーについては、現在調査中です。

    * ```E_CREATTING_ISOLATED_ENV_FAILED```
    * ```E_STARTING_ISOLATED_ENV_FAILED```

    以下のいずれかのエラーが発生した場合は、[ダウンロード センター](https://aka.ms/converterimages)から取得した有効な基本イメージを使用していることを確認してください。 有効な .wim をお使いの場合は、お手数ですがログを converter@microsoft.com にお送りください。調査へのご協力をお願いいたします。

* 以前に Desktop App Converter がインストールされていた開発用コンピューターで Windows Insider フライトを受信すると、新しい基本イメージをセットアップするときにエラー (`New-ContainerNetwork: The object already exists`) が表示される場合があります。 この問題を回避するには、管理者特権のコマンド プロンプトからコマンド `Netsh int ipv4 reset` を実行し、コンピューターを再起動します。

* "AnyCPU" ビルド オプションでコンパイルされた .NET アプリは、メインの実行可能ファイルまたはいずれかの依存関係が "Program Files" または "Windows\System32" に置かれていた場合、インストールに失敗します。 回避策として、アーキテクチャ固有デスクトップ インストーラー (32 ビットまたは 64 ビット) を使用して、Windows アプリ パッケージを正しく生成してください。

## <a name="telemetry-from-desktop-app-converter"></a>Desktop App Converter の利用統計情報

Desktop App Converter は、ソフトウェアの使用者と使用方法に関する情報を収集して、この情報を Microsoft に送信することがあります。 Microsoft のデータ収集と製品ドキュメントでの使用の詳細については、「[マイクロソフトのプライバシーに関する声明](http://go.microsoft.com/fwlink/?LinkId=521839)」をご覧ください。 マイクロソフトのプライバシーに関する声明の該当するすべての条項に準拠することに同意します。

既定では、Desktop App Converter の利用統計情報は有効にされています。 利用統計情報を目的の設定に構成するには、次のレジストリ キーを追加します。  

```cmd
HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\DesktopAppConverter
```
+ DWORD を 1 に設定して、*DisableTelemetry* 値を追加または編集します。
+ 利用統計情報を有効にするには、このキーを削除するかキーの値を 0 に設定します。

## <a name="desktop-app-converter-usage"></a>Desktop App Converter の使用法

Desktop App Converter のパラメーターの一覧を示します。 この一覧は、以下のコマンドを実行して表示することもできます。   

```CMD
Get-Help DesktopAppConverter.exe -detailed
```

### <a name="setup-parameters"></a>セットアップ パラメーター  

|パラメーター|説明|
|---------|-----------|
|```-Setup [<SwitchParameter>]``` | セットアップ モードで DesktopAppConverter を実行します。 セットアップ モードでは、用意されている基本イメージの展開をサポートします。|
|```-BaseImage <String>``` | 展開されていない基本イメージの完全パス。 このパラメーターは、-Setup を指定する場合に必要です。|
|```-LogFile <String>``` (省略可能) | ログ ファイルを指定します。 省略すると、ログ ファイルの一時的な場所が作成されます。|
|```-NatSubnetPrefix <String>``` (省略可能) | Nat インスタンスで使うプレフィックス値。 通常この値は、ホスト コンピューターがコンバーターの NetNat と同じサブネット範囲に割り当てられている場合にのみ変更します。 現在のコンバーターの NetNat 構成は **Get NetNat** コマンドレットを使って照会できます。 |
|```-NoRestart [<SwitchParameter>]``` | セットアップの実行中に再起動を要求しません (コンテナー機能を有効にするには再起動が必要です)。 |

### <a name="conversion-parameters"></a>変換パラメーター  

|パラメーター|説明|
|---------|-----------|
|```-AppInstallPath <String> [optional]``` | インストール済みのファイルに対応する、アプリケーションのルート フォルダーの完全パス (インストールされている場合)。"C:\Program Files (x86)\MyApp" など。|
|```-Destination <String>``` | コンバーターの appx を出力する場所。この場所がまだ存在しない場合は、DesktopAppConverter によって作成されます。|
|```-Installer <String>``` | アプリケーションのインストーラーのパス。無人/サイレント モードで実行できるようにする必要があります。 インストーラーを使用しない変換では、アプリ ファイルのルート ディレクトリへのパス。 |
|```-InstallerArguments <String>``` (省略可能) | インストーラーに無人/サイレント モードでの実行を強制する引数の文字列、またはコンマ区切り一覧。 インストーラーが msi の場合は、このパラメーターは省略可能です。 インストーラーからログを取得するには、ここで、インストーラーのログ記録の引数を指定し、パス ```<log_folder>``` (コンバーターが適切なパスに置換するトークン) を使います。 <br><br>**注: 無人/サイレント フラグとログの引数は、インストーラー テクノロジごとに異なります。** <br><br>このパラメーターの使用例:```-InstallerArguments "/silent /log <log_folder>\install.log"```。ログ ファイルを生成しない別の例: ```-InstallerArguments "/quiet", "/norestart"```。繰り返しになりますが、コンバーターでログをキャプチャし、最終的なログ フォルダーに格納する場合は、文字どおりすべてのログにトークン パス ```<log_folder>``` を指定する必要があります。|
|```-InstallerValidExitCodes <Int32>``` (省略可能) | インストーラーの正常な実行を示す、コンマで区切った終了コードの一覧 (例: 0, 1234, 5678)。  既定では、非 msi は 0、msi は 0, 1641, 3010 です。|

### <a name="windows-app-package-identity-parameters"></a>Windows アプリ パッケージ ID パラメーター  

|パラメーター|説明|
|---------|-----------|
|```-PackageName <String>``` | ユニバーサル Windows アプリ パッケージの名前
|```-Publisher <String>``` | ユニバーサル Windows アプリ パッケージの発行元
|```-Version <Version>``` | ユニバーサル Windows アプリ パッケージのバージョン番号

### <a name="optional-windows-app-package-manifest-parameters"></a>省略可能な Windows アプリ パッケージ マニフェストのパラメーター  

|パラメーター|説明|
|---------|-----------|
|```-AppExecutable <String> [optional]``` (省略可能) | アプリケーションのメインの実行可能ファイルの名前 (例:"MyApp.exe")。 インストーラーを使用しない変換では、このパラメーターは必須です。 |
|```-AppFileTypes <String>``` (省略可能) | アプリケーションに関連付ける、ファイルの種類のコンマ区切りの一覧 (例: ".txt, .doc"。引用符は不要)。|
|```-AppId <String>``` (省略可能) | Windows アプリ パッケージ マニフェストでアプリケーション ID を設定する値を指定します。 指定しないと、*PackageName* で渡した値が設定されます。|
|```-AppDisplayName <String>``` (省略可能) | Windows アプリ パッケージ マニフェストでアプリケーションの表示名を設定する値を指定します。 指定しないと、*PackageName* で渡した値が設定されます。 |
|```-AppDescription <String>``` (省略可能) | Windows アプリ パッケージ マニフェストでアプリケーションの説明を設定する値を指定します。 指定しないと、*PackageName* で渡した値が設定されます。|
|```-PackageDisplayName <String>``` (省略可能) | Windows アプリ パッケージ マニフェストでパッケージの表示名を設定する値を指定します。 指定しないと、*PackageName* で渡した値が設定されます。 |
|```-PackagePublisherDisplayName <String>``` (省略可能) | Windows アプリ パッケージ マニフェストでパッケージ発行元の表示名を設定する値を指定します。 指定しないと、*Publisher* で渡した値が設定されます。 |

### <a name="other-conversion-parameters"></a>その他の変換パラメーター  

|パラメーター|説明|
|---------|-----------|
|```-ExpandedBaseImage <String>``` (省略可能) | 既に展開済みの基本イメージの完全パス。|
|```-MakeAppx [<SwitchParameter>]``` (省略可能) | このスクリプトに出力で MakeAppx を呼び出すように指示するスイッチ (存在する場合)。 |
|```-LogFile <String>``` (省略可能) | ログ ファイルを指定します。 省略すると、ログ ファイルの一時的な場所が作成されます。 |
| ```-Sign [<SwitchParameter>] [optional]``` | 出力する Windows アプリ パッケージに署名するようにこのスクリプトに指示します。 このスイッチは、```-MakeAppx``` スイッチと共に含める必要があります。
|```<Common parameters>``` | このコマンドレットは、次の共通パラメーターをサポートします。*Verbose*、*Debug*、*ErrorAction*、*ErrorVariable*、*WarningAction*、*WarningVariable*、*OutBuffer*、*PipelineVariable*、および *OutVariable*。 詳細については、「[about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216)」をご覧ください。 |
| ```-Verify [<SwitchParameter>] [optional]``` | 指定した場合、デスクトップ ブリッジと Windows ストアの要件に照らして、変換済みのアプリ パッケージを検証するように DAC に指示するスイッチ。 結果は、検証レポート "VerifyReport.xml" で、ブラウザーでの視覚化に最適です。 このスイッチは、`-MakeAppx` スイッチと共に含める必要があります。

### <a name="cleanup-parameters"></a>クリーンアップ パラメーター

|パラメーター|説明|
|---------|-----------|
|```Cleanup [<Option>]``` | DesktopAppConverter の成果物のクリーンアップを実行します。 クリーンアップ モードには 3 つの有効なオプションがあります。 |
|```Cleanup All``` | 展開済みのすべての基本イメージを削除し、コンバーターのすべての一時ファイルを削除します。コンテナーのネットワークを削除し、Windows のオプション機能、コンテナーを無効にします。 |
|```Cleanup WorkDirectory``` | コンバーターのすべての一時ファイルを削除します。 |
|```Cleanup ExpandedImage``` | ホスト コンピューターにインストールされているすべての展開済みの基本イメージを削除します。 |

### <a name="package-architecture"></a>パッケージのアーキテクチャ

Desktop App Converter では、x86 コンピューターと amd64 コンピューターにインストールして実行できる x86 および x64 の両方のアプリ パッケージの作成がサポートされるようになりました。 適切な変換を実行するには、Desktop App Converter を AMD64 コンピューターで実行する必要があることに注意してください。

|パラメーター|説明|
|---------|-----------|
|```-PackageArch <String>``` | 指定したアーキテクチャのパッケージを生成します。 有効なオプションは、'x86' または 'x64' です。たとえば、-PackageArch x86 のように指定します。 このパラメーターは省略可能です。 指定されていない場合、DesktopAppConverter はパッケージのアーキテクチャの自動検出を試みます。 自動検出に失敗した場合、既定値は x64 パッケージです。

### <a name="running-the-peheadercertfixtool"></a>PEHeaderCertFixTool を実行する

DesktopAppConverter は 変換処理中に PEHeaderCertFixTool を自動的に実行し、破損している PEヘッダーを修正します。 ただし、UWP の Windows アプリ パッケージ、ルーズ ファイル、または特定のバイナリで、PEHeaderCertFixTool を実行することも可能です。 使用例:

```CMD
PEHeaderCertFixTool.exe <binary file>|<.appx package>|<folder> [/c] [/v]
 /c   -- check for corrupted certificate but do not fix (optional)
 /v   -- verbose (optional)
example1: PEHeaderCertFixTool app.exe
example2: PEHeaderCertFixTool c:\package.appx /c
example3: PEHeaderCertFixTool c:\myapp /c /v
```

## <a name="language-support"></a>言語サポート

Desktop App Converterは、Unicode をサポートしていません。したがって、漢字または非 ASCII 文字をツールで使用することはできません。

## <a name="see-also"></a>参照

+ [Desktop App Converter を使う UWP へのデスクトップ アプリの移行](https://channel9.msdn.com/events/Build/2016/P504)
+ [Project Centennial: ユニバーサル Windows プラットフォームへの既存のデスクトップ アプリケーションの移行](https://channel9.msdn.com/events/Build/2016/B829)  
