---
author: normesta
Description: "Desktop Converter App を実行して、Windows デスクトップ アプリケーション (Win32、WPF、Windows フォームなど) をパッケージ化します。"
Search.Product: eADQiWindows 10XVcnh
title: "Desktop App Converter を使用してアプリをパッケージ化する (デスクトップ ブリッジ)"
ms.author: normesta
ms.date: 05/25/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp
ms.assetid: 74c84eb6-4714-4e12-a658-09cb92b576e3
ms.openlocfilehash: 6aa469d0080412f48de511315684d365d4e90c99
ms.sourcegitcommit: 6c6f3c265498d7651fcc4081c04c41fafcbaa5e7
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/09/2017
---
# <a name="package-an-app-using-the-desktop-app-converter-desktop-bridge"></a>Desktop App Converter を使用してアプリをパッケージ化する (デスクトップ ブリッジ)

[Desktop App Converter を入手する](https://aka.ms/converter)

Desktop App Converter (DAC) を使用すると、デスクトップ アプリをユニバーサル Windows プラットフォーム (UWP) に移行することができます。 Win32 アプリや .NET 4.6.1 を使用して作成されたアプリも対象になります。

<div style="float: left; padding: 10px">
    ![DAC アイコン](images/desktop-to-uwp/dac.png)
</div>

このツールの名前には "Converter" という用語が含まれますが、実は、アプリの変換は行いません。 アプリは変更されません。 しかし、DACは、パッケージ ID を持ち多くの WinRT API を呼び出すことができる Windows アプリ パッケージを生成します。

このパッケージは、開発コンピューターで Add-AppxPackage という PowerShell コマンドレットを使ってインストールすることができます。

このコンバーターは、コンバーターのダウンロードに含まれるクリーンな状態の基本イメージを使って、分離された Windows 環境でデスクトップ インストーラーを実行します。 デスクトップ インストーラーが作成するすべてのレジストリとファイル システムの I/O がキャプチャされ、出力の一部としてパッケージ化されます。

> [!NOTE]
> Microsoft Virtual Academy から公開されている、<a href="https://mva.microsoft.com/en-US/training-courses/developers-guide-to-the-desktop-bridge-17373?l=oZG0B1WhD_8406218965/">このシリーズ</a>の短いビデオをご覧ください。 これらのビデオでは、Desktop App Converter を使用する一般的な方法が紹介されています。

## <a name="the-dac-does-more-than-just-generate-a-package-for-you"></a>DAC が行うのはパッケージの生成だけではありません

他にも以下のような処理を実行できます。

**Windows 10 Creators Update**

<div style="float: left; ">
    ![チェックマーク](images/desktop-to-uwp/check.png)
</div>

プレビュー ハンドラー、サムネイル ハンドラー、プロパティ ハンドラー、ファイアウォール規則、URL フラグを自動的に登録する。

<div style="float: left; ">
    ![チェックマーク](images/desktop-to-uwp/check.png)
</div>

ファイルの種類のマッピングを自動的に登録する。これによりユーザーは、エクスプローラーの **[種類]** 列を使ってファイルをグループ化できるようになります。

<div style="float: left; ">
    ![チェックマーク](images/desktop-to-uwp/check.png)
</div>

公開 COM サーバーを登録する。

**Windows 10 Anniversary Update 以降**

<div style="float: left; ">
    ![チェックマーク](images/desktop-to-uwp/check.png)
</div>

アプリをテストできるように、パッケージに自動的に署名する。

<div style="float: left; ">
    ![チェックマーク](images/desktop-to-uwp/check.png)
</div>

デスクトップ ブリッジと Windows ストアの要件に照らしてアプリを検証する。

オプションの完全な一覧については、このガイドの「[パラメーター リファレンス](#command-reference)」セクションをご覧ください。

パッケージを作成する準備ができたら、始めましょう。

## <a name="first-consider-how-youll-distribute-your-app"></a>まず、アプリの配布方法を検討する
アプリを [Windows ストア](https://www.microsoft.com/store/apps)に公開する予定であれば、[このフォーム](https://developer.microsoft.com/windows/projects/campaigns/desktop-bridge)への記入から開始します。 Microsoft から、オンボード プロセスを開始するための連絡があります。 このプロセスでは、ストア内の名前を予約し、アプリをパッケージ化するための情報を取得します。

## <a name="make-sure-that-your-system-can-run-the-converter"></a>システムで DCA を実行できることを確認する

システムが以下の要件を満たしていることを確認します。

* Windows 10 Anniversary Update (10.0.14393.0 以降) Pro または Enterprise エディション
* 64 ビット (x64) プロセッサ
* ハードウェア支援による仮想化
* Second Level Address Translation (SLAT)
* [Windows 10 用 Windows ソフトウェア開発キット (SDK)](https://go.microsoft.com/fwlink/?linkid=821375)


## <a name="start-the-desktop-app-converter"></a>Desktop App Converter を起動する

1. [Desktop App Converter](https://aka.ms/converter)をダウンロードおよびインストールします。

2. 管理者として Desktop App Converter を実行します。

    ![DAC を管理者として実行する](images/desktop-to-uwp/run-converter.png)

   コンソール ウィンドウが開きます。 コマンドを実行するには、このコンソール ウィンドウを使います。

## <a name="set-a-few-things-up-apps-with-installers-only"></a>必要な設定を行う (インストーラーがあるアプリのみ) 

アプリにインストーラーがない場合は、このセクションをスキップできます。

1. オペレーティング システムのバージョン番号を特定します。

   これを行うには、コンピューターで**システム情報アプリ**を開いて、オペレーティング システムのバージョン番号を見つけます。

    ![システム情報アプリに表示されたオペレーティング システムのバージョン](images/desktop-to-uwp/os-version.png)

2. 適切な [Desktop App Converter 基本イメージ](https://aka.ms/converterimages)をダウンロードします。

   ファイル名に含まれるバージョン番号が Windows ビルドのバージョン番号と一致していることを確認してください。

   ![一致するバージョンの基本イメージ](images/desktop-to-uwp/base-image-version.png)

   ダウンロードしたファイルを後で見つけることができるように、コンピューター上の適切な場所に置きます。

3. Desktop App Converter を起動したときに表示されるコンソール ウィンドウで、コマンド ```Set-ExecutionPolicy bypass``` を実行します。
4.  コマンド ```DesktopAppConverter.exe -Setup -BaseImage .\BaseImage-1XXXX.wim -Verbose``` を実行してコンバーターをセットアップします。
5.  画面の指示に従って、コンピューターを再起動します。

    コンバーターによって基本イメージが展開されると、コンソール ウィンドウに状態メッセージが表示されます。 状態メッセージが表示されない場合は、任意のキーを押します。 これにより、コンソール ウィンドウの内容が更新されます。

    ![コンソール ウィンドウに表示された状態メッセージ](images/desktop-to-uwp/bas-image-setup.png)

    基本イメージが完全に展開されたら、次のセクションに進みます。

## <a name="package-an-app"></a>アプリをパッケージ化する

アプリをパッケージ化するには、Desktop App Converter を起動したときに開くコンソール ウィンドウで ``DesktopAppConverter.exe`` コマンドを実行します。  

パラメーターを使用して、アプリのパッケージ名、発行元、バージョン番号を指定します。

> [!NOTE]
> Windows ストアでアプリ名を予約済みの場合は、Windows デベロッパー センターのダッシュ ボードを使用して、パッケージと発行元名を取得できます。 アプリを他のシステムにサイドローディング展開する場合は、独自の名前を指定できます。ただし、選択する発行元名は、アプリへの署名に使用する証明書の名前と一致する必要があります。

### <a name="a-quick-look-at-command-parameters"></a>コマンド パラメーターの確認

必要なパラメーターは次のとおりです。

```CMD
DesktopAppConverter.exe
-Installer <String>
-Destination <String>
-PackageName <String>
-Publisher <String>
-Version <Version>
```
各パラメーターについて詳しくは、[こちら](#command-reference)をご覧ください。

### <a name="examples"></a>例

アプリをパッケージ化する一般的な方法のいくつかを以下に示します。

* [インストーラー (.msi) ファイルのあるアプリをパッケージ化する](#installer-conversion)
* [セットアップの実行可能ファイルのあるアプリをパッケージ化する](#setup-conversion)
* [インストーラーのないアプリをパッケージ化する](#no-installer-conversion)
* [アプリをパッケージ化し、アプリに署名して、ストアへの提出に備える](#optional-parameters)

<span id="installer-conversion" />
#### <a name="package-an-app-that-has-an-installer-msi-file"></a>インストーラー (.msi) ファイルのあるアプリをパッケージ化する

``Installer`` パラメーターでインストーラー ファイルを指定します。

```cmd
DesktopAppConverter.exe -Installer C:\Installer\MyAppSetup.msi -Destination C:\Output\MyApp -PackageName "MyApp" -Publisher "CN=MyPublisher" -Version 0.0.0.1
```

> [!NOTE]
> インストーラーは独立したフォルダーに配置し、そのインストーラーに関連するファイルだけを同じフォルダーに配置してください。 コンバーターは、このフォルダーの内容をすべて、分離された Windows 環境にコピーします。

**ビデオ**

<iframe src="https://mva.microsoft.com/en-US/training-courses-embed/developers-guide-to-the-desktop-bridge-17373/Demo-Convert-an-Application-That-Has-an-MSI-Installer-Kh1UU2WhD_7106218965" width="636" height="480" allowFullScreen frameBorder="0"></iframe>

<span id="setup-conversion" />
#### セットアップの実行可能ファイルのあるアプリをパッケージ化する

``Installer`` パラメーターを使って、セットアップの実行可能ファイルを指定します。

```cmd
DesktopAppConverter.exe -Installer C:\Installer\MyAppSetup.exe -InstallerArguments "/S" -Destination C:\Output\MyApp -PackageName "MyApp" -Publisher "CN=MyPublisher" -Version 0.0.0.1
```

``InstallerArguments`` パラメーターは省略可能なパラメーターです。 ただし、Desktop App Converter では、インストーラーを無人モードで実行する必要があるため、アプリをサイレント モードで実行するためにサイレント フラグを必要とする場合は、このパラメーターの使用が必要になることがあります。 ``/S`` フラグは非常に一般的なサイレント フラグですが、セットアップ ファイルを作成するために使用したインストーラー テクノロジによっては、使用するフラグが異なる場合もあります。

**ビデオ**

<iframe src="https://mva.microsoft.com/en-US/training-courses-embed/developers-guide-to-the-desktop-bridge-17373/Demo-Convert-an-Application-That-Has-a-Setup-exe-Installer-amWit2WhD_5306218965" width="636" height="480" allowFullScreen frameBorder="0"></iframe>

<span id="no-installer-conversion" />
#### インストーラーのないアプリをパッケージ化する

この例では、``Installer`` パラメーターを使用して、アプリ ファイルのルート フォルダーを指定しています。

アプリの実行可能ファイルを指定するには、`AppExecutable` パラメーターを使用します。

```cmd
DesktopAppConverter.exe -Installer C:\Installer\MyApp\ -AppExecutable MyApp.exe -Destination C:\Output\MyApp -PackageName "MyApp" -Publisher "CN=MyPublisher" -Version 0.0.0.1
```

**ビデオ**

<iframe src="https://mva.microsoft.com/en-US/training-courses-embed/developers-guide-to-the-desktop-bridge-17373/Demo-Convert-a-No-Installer-Application-agAXF2WhD_3506218965" width="636" height="480" allowFullScreen frameBorder="0"></iframe>

<span id="optional-parameters" />
#### アプリをパッケージ化し、アプリに署名して、パッケージに対して検証チェックを実行する

この例は最初の例に似ていますが、こちらはローカル テスト用にアプリに署名し、デスクトップ ブリッジと Windows ストアの要件に照らしてアプリを変換する方法を示しています。

```cmd
DesktopAppConverter.exe -Installer C:\Installer\MyAppSetup.exe -InstallerArguments "/S" -Destination C:\Output\MyApp -PackageName "MyApp" -Publisher "CN=MyPublisher" -Version 0.0.0.1 -MakeAppx -Sign -Verbose -Verify
```

``Sign`` パラメーターは、証明書を生成し、その証明書でアプリに署名します。 アプリを実行するには、生成された証明書をインストールする必要があります。 その方法については、このガイドの「[パッケージ アプリを実行する](#run-app)」セクションをご覧ください。

アプリを検証するには、``Verify`` パラメーターを使います。

### <a name="a-quick-look-at-optional-parameters"></a>省略可能なパラメーターの確認

``Sign`` パラメーターと ``Verify`` パラメーターは省略可能です。 他にも多数の省略可能なパラメーターがあります。  よく使用される省略可能なパラメーターを以下に示します。

```CMD
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
これらについて詳しくは、次のセクションをご覧ください。

<span id="command-reference" />
### <a name="parameter-reference"></a>パラメーター リファレンス

ここでは、Desktop App Converter を実行するときに使用できるパラメーターの完全な一覧をカテゴリ別に示します。

* [セットアップ](#setup-params)
* [変換](#conversion-params)
* [パッケージ ID](#identity-params)
* [パッケージ マニフェスト](#manifest-params)
* [クリーンアップ](#cleanup-params)
* [アーキテクチャ](#architecture-params)
* [その他](#other-params)

アプリ コンソール ウィンドウで ``Get-Help`` コマンドを実行して完全な一覧を表示することもできます。   

||||
|-------------|-----------|-------------|
|<span id="setup-params" /> <strong>セットアップ パラメーター</strong>  ||
|-Setup [&lt;SwitchParameter&gt;] |必須 |セットアップ モードで DesktopAppConverter を実行します。 セットアップ モードでは、用意されている基本イメージの展開をサポートします。|
|-BaseImage &lt;String&gt; | 必須 |展開されていない基本イメージの完全パス。 このパラメーターは、-Setup を指定する場合に必要です。|
| -LogFile &lt;String&gt; |省略可能 |ログ ファイルを指定します。 省略した場合は、ログ ファイルの一時的な場所が作成されます。|
|-NatSubnetPrefix &lt;String&gt; |省略可能 |Nat インスタンスで使うプレフィックス値。 通常この値は、ホスト コンピューターがコンバーターの NetNat と同じサブネット範囲に割り当てられている場合にのみ変更します。 現在のコンバーターの NetNat 構成は **Get NetNat** コマンドレットを使って照会できます。 |
|-NoRestart [&lt;SwitchParameter&gt;] |必須 |セットアップの実行中に再起動を要求しません (コンテナー機能を有効にするには再起動が必要です)。 |
|<span id="conversion-params" /> <strong>変換パラメーター</strong>|||
|-AppInstallPath &lt;String&gt;  |省略可能 |インストール済みのファイルに対応する、アプリケーションのルート フォルダーの完全パス (インストールされている場合)。"C:\Program Files (x86)\MyApp" など。|
|-Destination &lt;String&gt; |必須 |コンバーターの appx を出力する場所。この場所がまだ存在しない場合は、DesktopAppConverter によって作成されます。|
|-Installer &lt;String&gt; |必須 |アプリケーションのインストーラーのパス。無人/サイレント モードで実行できるようにする必要があります。 インストーラーを使用しない変換では、アプリ ファイルのルート ディレクトリへのパス。 |
|-InstallerArguments &lt;String&gt; |省略可能 |インストーラーに無人/サイレント モードでの実行を強制する引数の文字列、またはコンマ区切り一覧。 インストーラーが msi の場合は、このパラメーターは省略可能です。 インストーラーからログを取得するには、ここで、インストーラーのログ記録の引数を指定し、パス &lt;log_folder&gt; (コンバーターが適切なパスに置換するトークン) を使います。 <br><br>**注**: 無人/サイレント フラグとログの引数は、インストーラー テクノロジごとに異なります。 <br><br>このパラメーターの使用例: -InstallerArguments "/silent /log &lt;log_folder&gt;\install.log"。ログ ファイルを生成しない別の例: ```-InstallerArguments "/quiet", "/norestart"```。コンバーターでログをキャプチャし、最終的なログ フォルダーに格納する場合は、文字どおりすべてのログにトークン パス &lt;log_folder&gt; を指定する必要があります。|
|-InstallerValidExitCodes &lt;Int32&gt; |省略可能 |インストーラーの正常な実行を示す、コンマで区切った終了コードの一覧 (例: 0, 1234, 5678)。  既定では、非 msi は 0、msi は 0, 1641, 3010 です。|
|<span id="identity-params" /><strong>パッケージ ID パラメーター</strong>||
|-PackageName &lt;String&gt; |必須 |ユニバーサル Windows アプリ パッケージの名前 |
|-Publisher &lt;String&gt; |必須 |ユニバーサル Windows アプリ パッケージの発行元 |
|-Version &lt;Version&gt; |必須 |ユニバーサル Windows アプリ パッケージのバージョン番号 |
|<span id="manifest-params" /><strong>パッケージ マニフェスト パラメーター</strong>||
|-AppExecutable &lt;String&gt; |省略可能 |アプリケーションのメインの実行可能ファイルの名前 (例:"MyApp.exe")。 インストーラーを使用しない変換では、このパラメーターは必須です。 |
|-AppFileTypes &lt;String&gt;|省略可能 |アプリケーションに関連付ける、ファイルの種類のコンマ区切りの一覧。 使用例: -AppFileTypes "'.md', '.markdown'"。|
|-AppId &lt;String&gt; |省略可能 |Windows アプリ パッケージ マニフェストでアプリケーション ID を設定する値を指定します。 指定しなかった場合は、*PackageName* で渡した値が設定されます。|
|-AppDisplayName &lt;String&gt;  |省略可能 |Windows アプリ パッケージ マニフェストでアプリケーションの表示名を設定する値を指定します。 指定しなかった場合は、*PackageName* で渡した値が設定されます。 |
|-AppDescription &lt;String&gt; |省略可能 |Windows アプリ パッケージ マニフェストでアプリケーションの説明を設定する値を指定します。 指定しなかった場合は、*PackageName* で渡した値が設定されます。|
|-PackageDisplayName &lt;String&gt; |省略可能 |Windows アプリ パッケージ マニフェストでパッケージの表示名を設定する値を指定します。 指定しなかった場合は、*PackageName* で渡した値が設定されます。 |
|-PackagePublisherDisplayName &lt;String&gt; |省略可能 |Windows アプリ パッケージ マニフェストでパッケージ発行元の表示名を設定する値を指定します。 指定しなかった場合は、*Publisher* で渡した値が設定されます。 |
|<span id="cleanup-params" /><strong>クリーンアップ パラメーター</strong>|||
|-Cleanup [&lt;Option&gt;] |必須 |DesktopAppConverter の成果物のクリーンアップを実行します。 クリーンアップ モードには 3 つの有効なオプションがあります。 |
|-Cleanup All | |展開済みのすべての基本イメージを削除し、コンバーターのすべての一時ファイルを削除します。コンテナーのネットワークを削除し、Windows のオプション機能、コンテナーを無効にします。 |
|-Cleanup WorkDirectory |必須 |コンバーターのすべての一時ファイルを削除します。 |
|-Cleanup ExpandedImage |必須 |ホスト コンピューターにインストールされているすべての展開済みの基本イメージを削除します。 |
|<span id="architecture-params" /><strong>パッケージ アーキテクチャ パラメーター</strong>|||
|-PackageArch &lt;String&gt; |必須 |指定したアーキテクチャのパッケージを生成します。 有効なオプションは、'x86' または 'x64' です。たとえば、-PackageArch x86 のように指定します。 このパラメーターは省略可能です。 指定されていない場合、DesktopAppConverter はパッケージのアーキテクチャの自動検出を試みます。 自動検出に失敗した場合、既定値は x64 パッケージです。 |
|<span id="other-params" /><strong>その他のパラメーター</strong>|||
|-ExpandedBaseImage &lt;String&gt;  |省略可能 |既に展開済みの基本イメージの完全パス。|
|-MakeAppx [&lt;SwitchParameter&gt;]  |省略可能 |このスクリプトに出力で MakeAppx を呼び出すように指示するスイッチ (存在する場合)。 |
|-LogFile &lt;String&gt;  |省略可能 |ログ ファイルを指定します。 省略した場合は、ログ ファイルの一時的な場所が作成されます。 |
| -Sign [&lt;SwitchParameter&gt;] |省略可能 |出力する Windows アプリ パッケージに、テスト用に生成された証明書を使用して署名するようにこのスクリプトに指示します。 このスイッチは、```-MakeAppx``` スイッチと共に指定する必要があります。 |
|&lt;共通パラメーター&gt; |必須 |このコマンドレットは、共通パラメーター *Verbose*、*Debug*、*ErrorAction*、*ErrorVariable*、*WarningAction*、*WarningVariable*、*OutBuffer*、*PipelineVariable*、*OutVariable* をサポートします。 詳しくは、「[about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216)」をご覧ください。 |
| -Verify [&lt;SwitchParameter&gt;] |省略可能 |指定された場合、デスクトップ ブリッジと Windows ストアの要件に照らして、アプリ パッケージを検証するように DAC に指示するスイッチ。 結果は、検証レポート "VerifyReport.xml" で、ブラウザーでの視覚化に最適です。 このスイッチは、`-MakeAppx` スイッチと共に指定する必要があります。 |
|-PublishComRegistrations| 省略可能| インストーラーによって行われたすべての パブリック COM 登録をスキャンし、有効な登録をマニフェストで公開します。 このフラグは、これらの登録を他のアプリケーションで利用できるようにする場合にのみ使用してください。 これらの登録を対象アプリケーションでのみ使用する場合、このフラグを使用する必要はありません。 <br><br>アプリをパッケージ化した後、正常に動作するように COM 登録を行うには、[こちらの記事](https://blogs.windows.com/buildingapps/2017/04/13/com-server-ole-document-support-desktop-bridge/#lDg5gSFxJ2TDlpC6.97)をご覧ください。

<span id="run-app" />
## <a name="run-the-packaged-app"></a>パッケージ アプリを実行する

アプリを実行するには、2 種類の方法があります。

1 つ目は、PowerShell コマンド プロンプトを開いて、```Add-AppxPackage –Register AppxManifest.xml``` というコマンドを入力する方法です。 アプリに署名する必要がないため、アプリを最も簡単に実行できるのはこちらの方法です。

2 つ目は、証明書を使ってアプリに署名する方法です。 ```sign``` パラメーターを使用すると、Desktop App Converter によって証明書が生成され、その証明書でアプリへの署名が行われます。 その証明書ファイルは **auto-generated.cer** という名前になり、パッケージ アプリのルート フォルダーに配置されます。

生成された証明書をインストールし、アプリを実行するには、次の手順を実行します。

1. **auto-generated.cer** ファイルをダブルクリックして証明書をインストールします。

   ![生成された証明書ファイル](images/desktop-to-uwp/generated-cert-file.png)

   > [!NOTE]
   > パスワードを求められた場合は、既定のパスワード "123456" を使用します。

2. **[証明書]** ダイアログ ボックスで、**[証明書のインストール]** を選択します。
3. **証明書インポート ウィザード**で、証明書を**ローカル コンピューター**にインストールし、証明書を "**信頼されたユーザー**" の証明書ストアに配置します。

   ![信頼されたユーザー ストア](images/desktop-to-uwp/trusted-people-store.png)

5. パッケージ アプリのルート フォルダーで、Windows アプリのパッケージ ファイルをダブルクリックします。

   ![Windows アプリのパッケージ ファイル](images/desktop-to-uwp/windows-app-package.png)

6. **[インストール]** を選択してアプリをインストールします。

   ![[インストール] ボタン](images/desktop-to-uwp/install.png)


## <a name="modify-the-packaged-app"></a>パッケージ アプリを変更する

パッケージ アプリには、バグの修正、ビジュアル資産の追加、モダン エクスペリエンス (ライブ タイルなど) によるアプリの拡張などのために変更が必要になる可能性があります。

変更を加えた後、もう一度コンバーターを実行する必要はありません。 MakeAppx ツールと、DAC によってアプリ用に生成される appxmanifest.xml ファイルを使ってアプリを再パッケージ化することができます。 「[Windows アプリ パッケージを生成する](desktop-to-uwp-manual-conversion.md#make-appx)」をご覧ください。

> [!NOTE]
> インストーラーによるレジストリ設定を変更した場合は、その変更を適用するために、Desktop App Converter をもう一度実行する必要があります。

**ビデオ**

|出力の変更と再パッケージ化 |デモ: 出力の変更と再パッケージ化|
|---|---|
|<iframe src="https://mva.microsoft.com/en-US/training-courses-embed/developers-guide-to-the-desktop-bridge-17373/Video-Modifying-and-Repackaging-Output-from-Desktop-App-Converter-OwpAJ3WhD_6706218965" width="426" height="472" allowFullScreen frameBorder="0"></iframe>|<iframe src="https://mva.microsoft.com/en-US/training-courses-embed/developers-guide-to-the-desktop-bridge-17373/Demo-Modify-Output-from-Desktop-App-Converter-gEnsa3WhD_8606218965" width="426" height="472" allowFullScreen frameBorder="0"></iframe>|

次の 2 つのセクションでは、パッケージ アプリについて検討可能な調整オプションについて説明します。

### <a name="delete-unnecessary-files-and-registry-keys"></a>不要なファイルとレジストリ キーを削除する

Desktop App Converter では、コンテナー内のファイルとシステム ノイズの除去に、非常に保守的なアプローチを取っています。

VFS フォルダーを確認し、インストーラーに必要ないファイルがあれば、削除することもできます。  また、Reg.dat の内容を確認し、アプリによってインストールされないキーや不要なキーがあれば、削除できます。

### <a name="fix-corrupted-pe-headers"></a>破損した PEヘッダーを修正する

DesktopAppConverter は 変換処理中に PEHeaderCertFixTool を自動的に実行し、破損している PEヘッダーを修正します。 ただし、UWP の Windows アプリ パッケージ、ルーズ ファイル、または特定のバイナリで、PEHeaderCertFixTool を実行することも可能です。 次に例を示します。

```CMD
PEHeaderCertFixTool.exe <binary file>|<.appx package>|&lt;folder> [/c] [/v]
 /c   -- check for corrupted certificate but do not fix (optional)
 /v   -- verbose (optional)
example1: PEHeaderCertFixTool app.exe
example2: PEHeaderCertFixTool c:\package.appx /c
example3: PEHeaderCertFixTool c:\myapp /c /v
```

## <a name="known-issues-and-disclosures"></a>既知の問題と開示情報

### <a name="known-issues-and-workarounds"></a>既知の問題と回避方法

ここでは、既知の問題と、試すことのできる解決方法を示します。

#### <a name="ecreatingisolatedenvfailed-an-estartingisolatedenvfailed-errors"></a>E_CREATING_ISOLATED_ENV_FAILED エラーと E_STARTING_ISOLATED_ENV_FAILED エラー    

これらのエラーのうちいずれかが発生した場合は、[ダウンロード センター](https://aka.ms/converterimages)から取得した有効な基本イメージを使用しているか確認してください。
有効な基本イメージを使っている場合は、コマンドに ``-Cleanup All`` を含めてみてください。
それでも問題が解決しない場合は、調査用としてログを converter@microsoft.com にお送りください。

#### <a name="new-containernetwork-the-object-already-exists-error"></a>"New-ContainerNetwork: オブジェクトは既に存在します" エラー

新しい基本イメージをセットアップするときは、このエラーが発生する可能性があります。 Desktop App Converter が先にインストールされた開発用コンピューターに Windows Insider フライトがある場合に、このエラーが発生することがあります。

この問題を解決するには、管理者特権で開いたコマンド プロンプトで `Netsh int ipv4 reset` コマンドを実行して、コンピューターを再起動します。

#### <a name="your-net-app-is-compiled-with-the-anycpu-build-option-and-fails-to-install"></a>.NET アプリが "AnyCPU" ビルド オプションでコンパイルされ、インストールに失敗する

この問題は、メインの実行可能ファイルまたは何らかの依存ファイルが、**Program Files** または **Windows\System32** のフォルダー階層に配置された場合に発生することがあります。

この問題を解決するには、アーキテクチャ固有のデスクトップ インストーラー (32 ビットまたは 64 ビット) を使って Windowsアプリ パッケージを生成してみてください。

#### <a name="publishing-public-side-by-side-fusion-assemblies-wont-work"></a>パブリック side-by-side Fusion アセンブリの公開が機能しない

 アプリケーションは、インストール中にパブリック side-by-side Fusion アセンブリを公開して、他のプロセスからアクセスできるようにします。 これらのアセンブリは、プロセスのアクティブ化コンテキストの作成中に、CSRSS.exe という名前のシステム プロセスによって取得されます。 変換プロセスでこれが行われると、アクティブ化コンテキスト作成とこれらのアセンブリのモジュール読み込みは失敗します。 side-by-side Fusion アセンブリは、次の場所に登録されています。
  + レジストリ: `HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\SideBySide\Winners`
  + ファイル システム: %windir%\\SideBySide

これは、既知の制限であり、今のところ回避策はありません。 ただし、ComCtl などの受信トレイ アセンブリは OS に同梱されているため、これらのアセンブリに依存していても安全です。

#### <a name="error-found-in-xml-the-executable-attribute-is-invalid---the-value-myappexe-is-invalid-according-to-its-datatype"></a>XML にエラーが見つかり、 'Executable' 属性が無効 - 'MyApp.EXE' の値がデータ型に対して無効

この問題は、アプリケーションに含まれる実行可能ファイルの **.EXE** 拡張子が大文字になっている場合に発生することがあります。 この拡張子が大文字であってもアプリの実行には影響しませんが、DAC ではこのエラーが発生する場合があります。

この問題を解決するには、パッケージ化を行うときに **-AppExecutable** フラグを指定し、メインの実行可能ファイルの拡張子として小文字の ".exe" を使用してみてください (例: MYAPP.exe)。    または、アプリに含まれるすべての実行可能ファイルについて、小文字を大文字に変更することもできます (例: .EXE を .exe に変更する)。


### <a name="telemetry-from-desktop-app-converter"></a>Desktop App Converter の利用統計情報

Desktop App Converter は、ソフトウェアの使用者と使用方法に関する情報を収集して、この情報を Microsoft に送信することがあります。 Microsoft のデータ収集と製品ドキュメントでの使用の詳細については、「[マイクロソフトのプライバシーに関する声明](http://go.microsoft.com/fwlink/?LinkId=521839)」をご覧ください。 マイクロソフトのプライバシーに関する声明の該当するすべての条項に準拠することに同意します。

既定では、Desktop App Converter の利用統計情報は有効にされています。 利用統計情報を目的の設定に構成するには、次のレジストリ キーを追加します。  

```cmd
HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\DesktopAppConverter
```
+ DWORD を 1 に設定して、*DisableTelemetry* 値を追加または編集します。
+ 利用統計情報を有効にするには、このキーを削除するかキーの値を 0 に設定します。

### <a name="language-support"></a>言語サポート

Desktop App Converterは、Unicode をサポートしていません。したがって、漢字または非 ASCII 文字をツールで使用することはできません。

## <a name="next-steps"></a>次のステップ

**アプリを実行する/問題を検出して修正する**

[パッケージ デスクトップ アプリの実行、デバッグ、テスト (デスクトップ ブリッジ)](desktop-to-uwp-debug.md) をご覧ください。

**アプリを配布する**

[パッケージ デスクトップ アプリの配布 (デスクトップ ブリッジ)](desktop-to-uwp-distribute.md) をご覧ください。

**特定の質問に対する回答を見つける**

マイクロソフトのチームでは、[StackOverflow タグ](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge)をチェックしています。

**この記事に関するフィードバックを送信する**

下のコメント セクションをご利用ください。
