---
author: awkoren
Description: "Desktop Converter App を実行して、Windows デスクトップ アプリケーション (Win32、WPF、Windows フォームなど) をユニバーサル Windows プラットフォーム (UWP) アプリに変換します。"
Search.Product: eADQiWindows 10XVcnh
title: Desktop App Converter
translationtype: Human Translation
ms.sourcegitcommit: 8429e6e21319a03fc2a0260c68223437b9aed02e
ms.openlocfilehash: fcff283e0d97d76fefe3f42a6cd1076b6cdd2aae

---

# Desktop App Converter

[Desktop App Converter を入手する](https://aka.ms/converter)

Desktop App Converter (DAC) は、.NET 4.6.1 または Win32 向けに記述された既存のデスクトップ アプリをユニバーサル Windows プラットフォーム (UWP) に変換するためのツールです。 このコンバーターを使って、無人 (サイレント) モードでデスクトップのインストーラーを実行し、開発コンピューターで PowerShell の Add-appxpackage コマンドレットを使ってインストールすることができる AppX パッケージを作成できます。

Desktop App Converterは現在、[Windows ストア](https://aka.ms/converter)で入手できます。

このコンバーターは、コンバーターのダウンロードに含まれるクリーンな状態の基本イメージを使って、分離された Windows 環境でデスクトップのインストーラーを実行します。 デスクトップ インストーラーが作成するすべてのレジストリとファイル システムの I/O をキャプチャし、出力の一部としてパッケージ化します。 パッケージ ID を持ち、多くの WinRT API を呼び出すことができる AppX を出力します。

## 新着情報

ここでは、Desktop App Converter のバージョン間での変更について概要を示します。 

### 2016 年 9 月 14 日 (v1.0)

* Desktop App Converter は現在、[Windows ストア](https://aka.ms/converter)からダウンロードできます。 
* DAC と共に使用する、最新の Windows 10 の基本イメージ (.wim) を[ダウンロード センター](https://aka.ms/converterimages)から入手します。
* ストア アプリにより、*DesktopAppConverter.exe <arguments>* の新しいエントリ ポイントを使って、管理者特権のコマンド プロンプトまたは PowerShell ウィンドウの任意の場所からコンバーターを実行できるようになりました。  


### 2016 年 9 月 2 日 (v0.1.25)

* 最新の .NET コンピューター仮想化 NuGet パッケージを統合しました。
* common.dll で新しく導入された依存関係を追加しました。
* いくつかのバグを修正しました。

### 2016 年 8 月 4 日 (v0.1.24)

* DAC によって生成された変換済みのアプリの自動署名のサポート (テスト用) が追加されました。 ```–Sign``` フラグを確認して、試すことができます。 
* 仮想レジストリ ハイブの COM 登録がいずれも AppX パッケージ内でサポートされない場合の警告を追加しました。  
* VC++ ライブラリのアプリの依存関係を自動検出し、それを AppX マニフェストの依存関係に変換する機能のサポートを追加しました。 VC++ ランタイムを使ってアプリのサイドローディングとテストを行うためには、VCLib フレームワーク パッケージをダウンロードする必要があります。これはブログ投稿「[Centennial プロジェクトで Visual C++ ラインタイムを使用する](https://blogs.msdn.microsoft.com/vcblog/2016/07/07/using-visual-c-runtime-in-centennial-project)」で説明されています。 コンピューターの ```Program Files (x86)\Microsoft SDKs\Windows Kits\10\ExtensionSDKs\Microsoft.VCLibs.Desktop``` フォルダーでパッケージを探し、依存するバージョン (11.0、12.0、14.0など) に移動し、適切なアーキテクチャのパッケージ (x64、x86) をダブルクリックしてインストールします。
* Windows 10 Anniversary Update (10.0.14393.0) に合わせてマニフェスト スキーマを更新しました。 
* いくつかのバグ修正を行い、出力レイアウトを向上しました。 

### 2016 年 7 月 7 日 (v0.1.22)

* デスクトップ アプリケーションのシェル拡張機能の自動検出と、UWP パッケージ用の AppXManifest での宣言のサポートが追加されました。 デスクトップの拡張機能について詳しくは、「[**変換されたデスクトップ アプリの拡張機能**](desktop-to-uwp-extensions.md)」をご覧ください。 
* 大規模な一連のアプリでの AppExecutable 検出機能が向上しました。 

### 2016 年 6 月 16 日 (v0.1.20)

* 最新の Windows 10 Insider Preview ビルドで正常な変換がブロックされる問題を修正します。 
* ```–CreateX86Package``` が ```–PackageArch``` に置き換えられ、生成されるパッケージのアーキテクチャを指定できます。 

### 2016 年 6 月 8 日

* コンバーターを実行している AMD64 ホスト コンピューター上で x86 appx パッケージを生成するためのサポートが追加されました。
* 以前に展開された基本イメージを削除することによって、ディスク領域の使用量が削減されました。
* 一時ファイルや不要な基本イメージのクリーンアップのサポートが追加されました。
* ファイルの種類やプロトコルの関連付けを検出する機能のサポートが強化されました。
* 大規模な一連のアプリの AppExecutable プロパティを検出するロジックが強化されました。
* MSI ベースのインストーラー用に追加の -InstallerArguments を指定するためのサポートが追加されました。
* 変換処理中に PathTooLongException エラーが出力されるバグが修正されました。

### 2016 年 5 月 12 日

- Pro エディションの Windows のサポートが復元されました。 
- コンバーターの ```-Setup``` フラグによって、Windows コンテナー機能が有効になり、基本イメージの展開が処理されるようになりました。 1 回限りのセットアップを行うには、管理者特権の PowerShell プロンプトから次のコマンドを実行します。 ```PS C:\> .\DesktopAppConverter.ps1 -Setup -BaseImage BaseImage-12345.wim -Verbose```
- 実行時に不要なファイル システムのリダイレクトを減らすために、アプリのインストール パスの自動検出機能と、VFS の外部にアプリケーション ルートを移動する機能が追加されました。
- 変換プロセスの一部として展開された基本イメージの自動検出機能が追加されました。
- ファイルの種類の関連付けとプロトコルの自動検出機能が追加されました。
- [スタート] メニューのショートカットを検出するロジックが強化されました。
- アプリがインストールした MUI ファイルを保持するために、ファイル システムのフィルタ リングが強化されました。
- マニフェストでサポートされる最小デスクトップ バージョン (10.0.14342.0) が更新されました。

## システム要件

### オペレーティング システム

+ Windows 10 Anniversary Update (10.0.14393.0 以降) Pro または Enterprise エディション。

### ハードウェア構成

+ 64 ビット (x64) プロセッサ
+ ハードウェア支援による仮想化
+ Second Level Address Translation (SLAT)

### 必要なリソース

+ [Windows 10 用 Windows ソフトウェア開発キット (SDK)](https://go.microsoft.com/fwlink/?linkid=821375)

## Desktop App Converter をセットアップする

Desktop App Converter は、最新の Windows 10 機能に依存しています。 Windows 10 Anniversary Update (14393.0) 以降のビルドをお使いであることを確認してください。

### ストアのダウンロード

1.  [DesktopAppConverter を Windows ストアからダウンロード](https://aka.ms/converter)し、[ビルドに対応する基本イメージの .wim ファイル](https://aka.ms/converterimages)をダウンロードします。  
2.  管理者として DesktopAppConverter を実行します。 これには、スタート メニューでタイルを右クリックして *[その他]* から *[管理者として実行]* を選択するか、タスク バーでタイルを右クリックし、表示されるアプリ名を右クリックして *[管理者として実行]* を選択します。
3.  アプリ コンソール ウィンドウから ```CMD PS C:\> Set-ExecutionPolicy bypass``` を実行します。
4.  アプリ コンソール ウィンドウから ```CMD PS C:\> DesktopAppConverter.exe -Setup -BaseImage .\BaseImage-1XXXX.wim -Verbose``` を実行することでコンバーターをセットアップします。
5.  上のコマンドを実行したときに再起動を求めるメッセージが表示されたら、コンピューターを再起動してください。

### zip ファイル 

オフラインでの使用に対応できるように、DAC は zip ファイルとして[ダウンロード センター](https://aka.ms/converterimages)に残されます。 ただし、今後の更新プログラムはすべて、ストア バージョンとしてのみ公開されます。

1.  DAC の zip ファイルと、[ビルドに一致する基本イメージの .wimファイル](https://aka.ms/converterimages)をダウンロードします。  
2. ローカル フォルダーに DesktopAppConverter.zip を抽出します。
3. 管理者 PowerShell ウィンドウから ```CMD PS C:\> Set-ExecutionPolicy bypass``` を実行します。
4. 管理者 PowerShell ウィンドウから ```CMD PS C:\> .\DesktopAppConverter.ps1 -Setup -BaseImage .\BaseImage-1XXXX.wim -Verbose``` を実行してコンバーターをセットアップします。
5. 上のコマンドを実行したときに再起動を求めるメッセージが表示されたら、コンピューターを再起動してください。

## Desktop App Converter を実行する

+ **ストア ダウンロード**: ```DesktopAppConverter.exe``` を使用してコンバーターを実行します。
+ **zipファイル**: ```DesktopAppConverter.ps1``` を使用してコンバーターを実行します。 

### 使用法

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

### 例

次の例では、*MyApp* という名前のデスクトップ アプリを *&lt;publisher_name&gt;* で UWP パッケージ (AppX) に変換する方法を説明します。

```CMD
DesktopAppConverter.exe -Installer C:\Installer\MyApp.exe 
-InstallerArguments "/S" -Destination C:\Output\MyApp -PackageName "MyApp" 
-Publisher "CN=<publisher_name>" -Version 0.0.0.1 -MakeAppx -Verbose
```

## 変換済み AppX を展開する

PowerShell で [Add-appxpackage](https://technet.microsoft.com/library/hh856048.aspx) コマンドレットを使って、ユーザー アカウントに対して署名済みのアプリ パッケージ (.appx) を展開します。 

Desktop App Converter (v0.1.24) の ```-Sign``` フラグを使って、変換済みアプリの自動署名を行うことができます。 または、「[変換済みのデスクトップ アプリに署名する](desktop-to-uwp-signing.md)」を参照して、AppX パッケージに自己署名する方法を学びます。

また、Add-AppXPackage PowerShell コマンドレットの ```-Register``` パラメーターを使用して、開発プロセス中にパッケージ化を解除したファイルのフォルダーからインストールすることもできます。 

変換済みのアプリの展開とデバッグの詳細については、「[変換済みの UWP アプリを展開してデバッグする](desktop-to-uwp-deploy-and-debug.md)」をご覧ください。 

## .Appx パッケージに署名する

Add-AppxPackage コマンドレットを使うには、展開するアプリケーション パッケージ (.appx) が署名されている必要があります。 コンバーター コマンドラインまたは SignTool.exe の中で ```-Sign``` フラグを使います。これは Microsoft Windows 10 SDK に含まれている、.appx パッケージに署名を行うためのツールです。

.appx パッケージに署名を行う方法について詳しくは、「[変換済みのデスクトップ アプリに署名する](desktop-to-uwp-signing.md)」をご覧ください。 

## 注意事項

1. ホスト コンピューターの Windows 10 ビルドは、Desktop App Converter ダウンロードに含まれていた基本イメージと一致する必要があります。  
2. コンバーターはディレクトのすべての内容を分離されている Windows 環境にコピーするため、デスクトップ インストーラーが独立したディレクトリにあることを確認します。  
3. 現時点では、Desktop App Converter は 64 ビット オペレーティング システムのみで、変換処理の実行をサポートします。 変換済みの .appx パッケージは、64 ビット (x64) OS のみに展開できます。  
4. Desktop App Converter では、デスクトップ インストーラーを無人モードで実行する必要があります。 *- InstallerArguments* パラメーターを使って、インストーラーのサイレント フラグをコンバーターに渡してください。
5. パブリック SxS Fusion アセンブリの公開は機能しません。 アプリケーションは、インストール中にパブリック side-by-side Fusion アセンブリを公開して、他のプロセスからアクセスできるようにします。 これらのアセンブリは、プロセスのアクティブ化コンテキストの作成中に、CSRSS.exe という名前のシステム プロセスによって取得されます。 変換プロセスでこれが行われると、アクティブ化コンテキスト作成とこれらのアセンブリのモジュール読み込みは失敗します。 ComCtl などの受信トレイ アセンブリは OS に同梱されているので、これらのアセンブリに依存していても安全です。 SxS Fusion アセンブリは、次の場所に登録されています。
  + レジストリ: `HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\SideBySide\Winners`
  + ファイル システム: %windir%\\SideBySide

## 既知の問題

+ 以前に Desktop App Converter がインストールされていた開発用コンピューターで Windows Insider フライトを受信すると、新しい基本イメージをセットアップするときにエラー (`New-ContainerNetwork: The object already exists`) が表示される場合があります。 この問題を回避するには、管理者特権のコマンド プロンプトからコマンド `Netsh int ipv4 reset` を実行し、コンピューターを再起動します。 
+ "AnyCPU" ビルド オプションでコンパイルされた .NET アプリは、メインの実行可能ファイルまたはいずれかの依存関係が "Program Files" または "Windows\System32" に置かれていた場合、インストールに失敗します。 回避策として、アーキテクチャ固有デスクトップ インストーラー (32 ビットまたは 64 ビット) を使用して、AppX パッケージを正しく生成してください。

## Desktop App Converter の利用統計情報  
Desktop App Converter は、ソフトウェアの使用者と使用方法に関する情報を収集して、この情報を Microsoft に送信することがあります。 Microsoft のデータ収集と製品ドキュメントでの使用の詳細については、「[マイクロソフトのプライバシーに関する声明](http://go.microsoft.com/fwlink/?LinkId=521839)」をご覧ください。 マイクロソフトのプライバシーに関する声明の該当するすべての条項に準拠することに同意します。

既定では、Desktop App Converter の利用統計情報は有効にされています。 利用統計情報を目的の設定に構成するには、次のレジストリ キーを追加します。  
```CMD
HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\DesktopAppConverter
```
+ DWORD を 1 に設定して、*DisableTelemetry* 値を追加または編集します。
+ 利用統計情報を有効にするには、このキーを削除するかキーの値を 0 に設定します。

## Desktop App Converter の使用法

Desktop App Converter のパラメーターの一覧を示します。 この一覧は、以下のコマンドを実行して表示することもできます。   

```CMD
Get-Help DesktopAppConverter.exe -detailed
```

### セットアップ パラメーター  

|パラメーター|説明|
|---------|-----------|
|```-Setup [<SwitchParameter>]``` | セットアップ モードで DesktopAppConverter を実行します。 セットアップ モードでは、用意されている基本イメージの展開をサポートします。|
|```-BaseImage <String>``` | 展開されていない基本イメージの完全パス。 このパラメーターは、-Setup を指定する場合に必要です。|
|```-LogFile <String>``` (省略可能) | ログ ファイルを指定します。 省略すると、ログ ファイルの一時的な場所が作成されます。|
|```-NatSubnetPrefix <String>``` (省略可能) | Nat インスタンスで使うプレフィックス値。 通常この値は、ホスト コンピューターがコンバーターの NetNat と同じサブネット範囲に割り当てられている場合にのみ変更します。 現在のコンバーターの NetNat 構成は **Get NetNat** コマンドレットを使って照会できます。 |
|```-NoRestart [<SwitchParameter>]``` | セットアップの実行中に再起動を要求しません (コンテナー機能を有効にするには再起動が必要です)。 |

### 変換パラメーター  

|パラメーター|説明|
|---------|-----------|
|```-AppInstallPath <String> [optional]``` | インストール済みのファイルに対応する、アプリケーションのルート フォルダーの完全パス (インストールされている場合)。"C:\Program Files (x86)\MyApp" など。| 
|```-Destination <String>``` | コンバーターの appx を出力する場所。この場所がまだ存在しない場合は、DesktopAppConverter によって作成されます。|
|```-Installer <String>``` | アプリケーションのインストーラーのパス。無人/サイレント モードで実行できるようにする必要があります。|
|```-InstallerArguments <String>``` (省略可能) | インストーラーに無人/サイレント モードでの実行を強制する引数の文字列、またはコンマ区切り一覧。 インストーラーが msi の場合は、このパラメーターは省略可能です。 インストーラーからログを取得するには、ここで、インストーラーのログ記録の引数を指定し、パス ```<log_folder>``` (コンバーターが適切なパスに置換するトークン) を使います。 <br><br>**注: 無人/サイレント フラグとログの引数は、インストーラー テクノロジごとに異なります。** <br><br>このパラメーターの使用例:```-InstallerArguments "/silent /log <log_folder>\install.log"```。ログ ファイルを生成しない別の例: ```-InstallerArguments "/quiet", "/norestart"```。繰り返しになりますが、コンバーターでログをキャプチャし、最終的なログ フォルダーに格納する場合は、文字どおりすべてのログにトークン パス ```<log_folder>``` を指定する必要があります。|
|```-InstallerValidExitCodes <Int32>``` (省略可能) | インストーラーの正常な実行を示す、コンマで区切った終了コードの一覧 (例: 0, 1234, 5678)。  既定では、非 msi は 0、msi は 0, 1641, 3010 です。|

### Appx ID パラメーター  

|パラメーター|説明|
|---------|-----------|
|```-PackageName <String>``` | ユニバーサル Windows アプリ パッケージの名前
|```-Publisher <String>``` | ユニバーサル Windows アプリ パッケージの発行元
|```-Version <Version>``` | ユニバーサル Windows アプリ パッケージのバージョン番号

### Appx マニフェストのオプションのパラメーター  

|パラメーター|説明|
|---------|-----------|
|```-AppExecutable <String> [optional]``` (省略可能) | アプリケーションのメインの実行可能ファイル (例:"MyApp.exe") の名前。 |
|```-AppFileTypes <String>``` (省略可能) | アプリケーションに関連付ける、ファイルの種類のコンマ区切りの一覧 (例: ".txt, .doc"。引用符は不要)。|
|```-AppId <String>``` (省略可能) | appx マニフェストでアプリケーション ID を設定する値を指定します。 指定しないと、*PackageName* で渡した値が設定されます。|
|```-AppDisplayName <String>``` (省略可能) | appx マニフェストでアプリケーション表示名を設定する値を指定します。 指定しないと、*PackageName* で渡した値が設定されます。 |
|```-AppDescription <String>``` (省略可能) | appx マニフェストでアプリケーションの説明を設定する値を指定します。 指定しないと、*PackageName* で渡した値が設定されます。|
|```-PackageDisplayName <String>``` (省略可能) | appx マニフェストでパッケージ表示名を設定する値を指定します。 指定しないと、*PackageName* で渡した値が設定されます。 |
|```-PackagePublisherDisplayName <String>``` (省略可能) | appx マニフェストでパッケージの発行元表示名を設定する値を指定します。 指定しないと、*Publisher* で渡した値が設定されます。 |

### その他の変換パラメーター  

|パラメーター|説明|
|---------|-----------|
|```-ExpandedBaseImage <String>``` (省略可能) | 既に展開済みの基本イメージの完全パス。|
|```-MakeAppx [<SwitchParameter>]``` (省略可能) | このスクリプトに出力で MakeAppx を呼び出すように指示するスイッチ (存在する場合)。 |
|```-LogFile <String>``` (省略可能) | ログ ファイルを指定します。 省略すると、ログ ファイルの一時的な場所が作成されます。 |
| ```Sign [<SwitchParameter>] [optional]``` | 出力の appx に署名を行うようにこのスクリプトに指示します。 このスイッチは、```-MakeAppx``` スイッチと共に含める必要があります。 
|```<Common parameters>``` | このコマンドレットは、次の共通パラメーターをサポートします。*Verbose*、*Debug*、*ErrorAction*、*ErrorVariable*、*WarningAction*、*WarningVariable*、*OutBuffer*、*PipelineVariable*、および *OutVariable*。 詳細については、「[about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216)」をご覧ください。 |

### クリーンアップ パラメーター

|パラメーター|説明|
|---------|-----------|
|```Cleanup [<Option>]``` | DesktopAppConverter の成果物のクリーンアップを実行します。 クリーンアップ モードには 3 つの有効なオプションがあります。 |
|```Cleanup All``` | 展開済みのすべての基本イメージを削除し、コンバーターのすべての一時ファイルを削除します。コンテナーのネットワークを削除し、Windows のオプション機能、コンテナーを無効にします。 |
|```Cleanup WorkDirectory``` | コンバーターのすべての一時ファイルを削除します。 |
|```Cleanup ExpandedImage``` | ホスト コンピューターにインストールされているすべての展開済みの基本イメージを削除します。 |

### パッケージのアーキテクチャ

Desktop App Converter では、x86 コンピューターと amd64 コンピューターにインストールして実行できる x86 および x64 の両方のアプリ パッケージの作成がサポートされるようになりました。 適切な変換を実行するには、Desktop App Converter を AMD64 コンピューターで実行する必要があることに注意してください。

|パラメーター|説明|
|---------|-----------|
|```-PackageArch <String>``` | 指定したアーキテクチャのパッケージを生成します。 有効なオプションは、'x86' または 'x64' です。たとえば、-PackageArch x86 のように指定します。 このパラメーターは省略可能です。 指定されていない場合、DesktopAppConverter はパッケージのアーキテクチャの自動検出を試みます。 自動検出に失敗した場合、既定値は x64 パッケージです。 

### PEHeaderCertFixTool を実行する

DesktopAppConverter は 変換処理中に PEHeaderCertFixTool を自動的に実行し、破損している PEヘッダーを修正します。 ただし、UWP の appx、ルーズ ファイル、または特定のバイナリで、PEHeaderCertFixTool を実行することも可能です。 

PEHeaderCertFixTool は、DesktopAppConverter.zip の一部として付属しています。 使用例: 

```CMD
PEHeaderCertFixTool.exe <binary file>|<.appx package>|<folder> [/c] [/v]
 /c   -- check for corrupted certificate but do not fix (optional)
 /v   -- verbose (optional)
example1: PEHeaderCertFixTool app.exe
example2: PEHeaderCertFixTool c:\package.appx /c
example3: PEHeaderCertFixTool c:\myapp /c /v
```

## サポート言語

Desktop App Converterは、Unicode をサポートしていません。したがって、漢字または非 ASCII 文字をツールで使用することはできません。

## 参照

+ [Desktop App Converter を使う UWP へのデスクトップ アプリの移行](https://channel9.msdn.com/events/Build/2016/P504)
+ [Project Centennial: ユニバーサル Windows プラットフォームへの既存のデスクトップ アプリケーションの移行](https://channel9.msdn.com/events/Build/2016/B829)  


<!--HONumber=Nov16_HO1-->


