---
author: normesta
Description: Run the Desktop Converter App to package a Windows desktop application (like Win32, WPF, and Windows Forms).
Search.Product: eADQiWindows 10XVcnh
title: Desktop App Converter を使用してアプリをパッケージ化する (デスクトップ ブリッジ)
ms.author: normesta
ms.date: 08/21/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.assetid: 74c84eb6-4714-4e12-a658-09cb92b576e3
ms.localizationpriority: medium
ms.openlocfilehash: bde2e58934e24df7db2cb77fb793106aa65e3834
ms.sourcegitcommit: 63cef0a7805f1594984da4d4ff2f76894f12d942
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/05/2018
ms.locfileid: "4390462"
---
# <a name="package-a-desktop-application-using-the-desktop-app-converter"></a>Desktop App Converter を使用してデスクトップ アプリケーションをパッケージ化します。

[Desktop App Converter を入手する](https://aka.ms/converter)

Desktop App Converter (DAC) を使用すると、デスクトップ アプリをユニバーサル Windows プラットフォーム (UWP) に移行することができます。 Win32 アプリや .NET 4.6.1 を使用して作成されたアプリも対象になります。

![DAC アイコン](images/desktop-to-uwp/dac.png)

このツールの名前には "Converter" という用語が含まれますが、実は、アプリの変換は行いません。 アプリケーションはそのまま残ります。 しかし、DACは、パッケージ ID を持ち多くの WinRT API を呼び出すことができる Windows アプリ パッケージを生成します。

このパッケージは、開発コンピューターで Add-AppxPackage という PowerShell コマンドレットを使ってインストールすることができます。

このコンバーターは、コンバーターのダウンロードに含まれるクリーンな状態の基本イメージを使って、分離された Windows 環境でデスクトップ インストーラーを実行します。 デスクトップ インストーラーが作成するすべてのレジストリとファイル システムの I/O をキャプチャし、出力の一部としてパッケージ化します。

>[!IMPORTANT]
>デスクトップ アプリケーションの Windows アプリ パッケージを作成する機能 (それ以外の場合、デスクトップ ブリッジとも呼ばれるは Windows 10 バージョン 1607 で導入されましたし、Windows 10 Anniversary Update (10.0; をターゲットとするプロジェクトでのみ使用できますビルド 14393) 以降の Visual Studio でリリースされます。

> [!NOTE]
> Microsoft Virtual Academy から公開されている、<a href="https://mva.microsoft.com/en-US/training-courses/developers-guide-to-the-desktop-bridge-17373?l=oZG0B1WhD_8406218965/">このシリーズ</a>の短いビデオをご覧ください。 これらのビデオでは、Desktop App Converter を使用する一般的な方法が紹介されています。

## <a name="the-dac-does-more-than-just-generate-a-package-for-you"></a>DAC が行うのはパッケージの生成だけではありません

他にも以下のような処理を実行できます。

**Windows 10 Creators Update**

:heavy_check_mark: プレビュー ハンドラー、サムネイル ハンドラー、プロパティ ハンドラー、ファイアウォール規則、URL フラグを自動的に登録する。

:heavy_check_mark: ファイルの種類のマッピングを自動的に登録する。これによりユーザーは、エクスプローラーの **[種類]** 列を使ってファイルをグループ化できるようになります。

:heavy_check_mark: 公開 COM サーバーを登録する。

**Windows 10 Anniversary Update 以降**

:heavy_check_mark: アプリをテストできるように、パッケージに自動的に署名する。

::heavy_check_mark: パッケージ アプリと Microsoft Store 要件に照らしてアプリを検証します。

オプションの完全な一覧については、このガイドの「[パラメーター リファレンス](#command-reference)」セクションをご覧ください。

パッケージを作成する準備ができたら、始めましょう。

## <a name="first-prepare-your-application"></a>まず、アプリケーションを準備します

アプリケーションのパッケージの作成を開始する前に、このガイドを確認:[デスクトップ アプリケーションのパッケージを準備](desktop-to-uwp-prepare.md)します。

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

スキップできます次のセクションにアプリ インストーラーがない場合。

1. オペレーティング システムのバージョン番号を特定します。

   そのためには、**[ファイル名を指定して実行]** ダイアログ ボックスで「**winver**」と入力し、**[OK]** をクリックします。

   ![winver](images/desktop-to-uwp/winver.png)

   **[Windows のバージョン情報]** ダイアログ ボックスに Windows ビルドのバージョンが表示されます。

   ![Windows 10 のバージョン](images/desktop-to-uwp/win-10-version.png)

2. 適切な [Desktop App Converter 基本イメージ](https://aka.ms/converterimages)をダウンロードします。

   ファイル名に含まれるバージョン番号が Windows ビルドのバージョン番号と一致していることを確認してください。

   >[!IMPORTANT]
   > ビルド番号 **15063** を使用しており、そのビルドのマイナー バージョンが **.483** 以上 (例: **15063.540**) である場合は、**BaseImage-15063-UPDATE.wim** ファイルをダウンロードします。 そのビルドのマイナー バージョンが **.483** 未満である場合は、**BaseImage-15063.wim** ファイルをダウンロードします。 このベース ファイルの互換性のないバージョンを既にセットアップしている場合は、修正することができます。 その方法については、この[ブログの投稿](https://blogs.msdn.microsoft.com/appconsult/2017/08/04/desktop-app-converter-fails-on-windows-10-15063-483-and-later-how-to-solve-it/)をご覧ください。

3. ダウンロードしたファイルを後で見つけることができるように、コンピューター上の適切な場所に置きます。

4. Desktop App Converter を起動したときに表示されるコンソール ウィンドウで、コマンド ```Set-ExecutionPolicy bypass``` を実行します。
5. コマンド ```DesktopAppConverter.exe -Setup -BaseImage .\BaseImage-1XXXX.wim -Verbose``` を実行してコンバーターをセットアップします。
6. 画面の指示に従って、コンピューターを再起動します。

   コンバーターによって基本イメージが展開されると、コンソール ウィンドウに状態メッセージが表示されます。 状態メッセージが表示されない場合は、任意のキーを押します。 これにより、コンソール ウィンドウの内容が更新されます。

   ![コンソール ウィンドウに表示された状態メッセージ](images/desktop-to-uwp/bas-image-setup.png)

   基本イメージが完全に展開されたら、次のセクションに進みます。

## <a name="package-an-app"></a>アプリをパッケージ化する

アプリをパッケージ化するには、Desktop App Converter を起動したときに開くコンソール ウィンドウで ``DesktopAppConverter.exe`` コマンドを実行します。  

パラメーターを使用して、アプリケーションのパッケージ名、発行元、バージョン番号を指定します。

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

* [インストーラー (.msi) ファイルを持つアプリケーションをパッケージ化します。](#installer-conversion)
* [セットアップの実行可能ファイルを持つアプリケーションをパッケージ化します。](#setup-conversion)
* [インストーラーがないアプリケーションをパッケージ化します。](#no-installer-conversion)
* [アプリをパッケージ化し、アプリに署名して、ストアへの提出に備える](#optional-parameters)

<a id="installer-conversion" />

#### <a name="package-an-application-that-has-an-installer-msi-file"></a>インストーラー (.msi) ファイルを持つアプリケーションをパッケージ化します。

``Installer`` パラメーターでインストーラー ファイルを指定します。

```cmd
DesktopAppConverter.exe -Installer C:\Installer\MyAppSetup.msi -Destination C:\Output\MyApp -PackageName "MyApp" -Publisher "CN=MyPublisher" -Version 0.0.0.1
```

> [!IMPORTANT]
> ここで留意すべき重要なことが 2 つあります。 まず、インストーラーは独立したフォルダーに配置し、そのインストーラーに関連するファイルだけを同じフォルダーに配置してください。 コンバーターは、このフォルダーの内容をすべて、分離された Windows 環境にコピーします。 <br> 2 つ目に、デベロッパー センターが数値で始まる ID をパッケージに割り当てる場合、必ず <i>-AppId</i> パラメーターも渡し、そのパラメーターの値として文字列サフィックスのみを使ってください (ピリオドの区切り記号の後)。  

**ビデオ**

<iframe src="https://mva.microsoft.com/en-US/training-courses-embed/developers-guide-to-the-desktop-bridge-17373/Demo-Convert-an-Application-That-Has-an-MSI-Installer-Kh1UU2WhD_7106218965" width="636" height="480" allowFullScreen frameBorder="0"></iframe>

インストーラーに、従属ライブラリやフレームワークのインストーラーが含まれている場合、少し異なる方法で整理する必要があります。 [複数のインストーラーとデスクトップ ブリッジの連結に関する記事](https://blogs.msdn.microsoft.com/appconsult/2017/09/11/chaining-multiple-installers-with-the-desktop-app-converter/)をご覧ください。

<a id="setup-conversion" />

#### <a name="package-an-application-that-has-a-setup-executable-file"></a>セットアップの実行可能ファイルを持つアプリケーションをパッケージ化します。

``Installer`` パラメーターを使って、セットアップの実行可能ファイルを指定します。

```cmd
DesktopAppConverter.exe -Installer C:\Installer\MyAppSetup.exe -InstallerArguments "/S" -Destination C:\Output\MyApp -PackageName "MyApp" -Publisher "CN=MyPublisher" -Version 0.0.0.1
```
>[!IMPORTANT]
>デベロッパー センターが数値で始まる ID をパッケージに割り当てる場合、必ず <i>-AppId</i> パラメーターも渡し、そのパラメーターの値として文字列サフィックスのみを使ってください (ピリオドの区切り記号の後)。

``InstallerArguments`` パラメーターは省略可能なパラメーターです。 ただし、Desktop App Converter は、インストーラーを無人モードで実行する必要があるため、アプリケーションはサイレント実行のサイレント フラグを必要とする場合に使用する必要があります。 ``/S`` フラグは非常に一般的なサイレント フラグですが、セットアップ ファイルを作成するために使用したインストーラー テクノロジによっては、使用するフラグが異なる場合もあります。

**ビデオ**

<iframe src="https://mva.microsoft.com/en-US/training-courses-embed/developers-guide-to-the-desktop-bridge-17373/Demo-Convert-an-Application-That-Has-a-Setup-exe-Installer-amWit2WhD_5306218965" width="636" height="480" allowFullScreen frameBorder="0"></iframe>

<a id="no-installer-conversion" />

#### <a name="package-an-application-that-doesnt-have-an-installer"></a>インストーラーがないアプリケーションをパッケージ化します。

この例では、使用して、``Installer``アプリケーションのファイルのルート フォルダーをポイントするパラメーター。

アプリの実行可能ファイルを指定するには、`AppExecutable` パラメーターを使用します。

```cmd
DesktopAppConverter.exe -Installer C:\Installer\MyApp\ -AppExecutable MyApp.exe -Destination C:\Output\MyApp -PackageName "MyApp" -Publisher "CN=MyPublisher" -Version 0.0.0.1
```

>[!IMPORTANT]
>デベロッパー センターが数値で始まる ID をパッケージに割り当てる場合、必ず <i>-AppId</i> パラメーターも渡し、そのパラメーターの値として文字列サフィックスのみを使ってください (ピリオドの区切り記号の後)。

**ビデオ**

<iframe src="https://mva.microsoft.com/en-US/training-courses-embed/developers-guide-to-the-desktop-bridge-17373/Demo-Convert-a-No-Installer-Application-agAXF2WhD_3506218965" width="636" height="480" allowFullScreen frameBorder="0"></iframe>

<a id="optional-parameters" />

#### <a name="package-an-app-sign-the-app-and-run-validation-checks-on-the-package"></a>アプリをパッケージ化し、アプリに署名して、パッケージに対して検証チェックを実行する

この例は、点を除いて、アプリケーション ローカル テスト用に署名し、パッケージ アプリと Microsoft Store 要件に照らしてアプリを検証する方法を示していますに 1 つ目に似ています。

```cmd
DesktopAppConverter.exe -Installer C:\Installer\MyAppSetup.exe -InstallerArguments "/S" -Destination C:\Output\MyApp -PackageName "MyApp" -Publisher "CN=MyPublisher" -Version 0.0.0.1 -MakeAppx -Sign -Verbose -Verify
```
>[!IMPORTANT]
>デベロッパー センターが数値で始まる ID をパッケージに割り当てる場合、必ず <i>-AppId</i> パラメーターも渡し、そのパラメーターの値として文字列サフィックスのみを使ってください (ピリオドの区切り記号の後)。

``Sign``パラメーターが証明書を生成し、それを使用してアプリケーションを署名します。 アプリを実行するには、生成された証明書をインストールする必要があります。 その方法については、このガイドの「[パッケージ アプリを実行する](#run-app)」セクションをご覧ください。

検証するアプリケーションを使用して、``Verify``パラメーター。

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

<a id="command-reference" />

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
|<a id="setup-params" /> <strong>セットアップ パラメーター</strong>  ||
|-Setup [&lt;SwitchParameter&gt;] |必須 |セットアップ モードで DesktopAppConverter を実行します。 セットアップ モードでは、用意されている基本イメージの展開をサポートします。|
|-BaseImage &lt;String&gt; | 必須 |展開されていない基本イメージの完全パス。 このパラメーターは、-Setup を指定する場合に必要です。|
| -LogFile &lt;String&gt; |省略可能 |ログ ファイルを指定します。 省略した場合は、ログ ファイルの一時的な場所が作成されます。|
|-NatSubnetPrefix &lt;String&gt; |省略可能 |Nat インスタンスで使うプレフィックス値。 通常この値は、ホスト コンピューターがコンバーターの NetNat と同じサブネット範囲に割り当てられている場合にのみ変更します。 現在のコンバーターの NetNat 構成は **Get NetNat** コマンドレットを使って照会できます。 |
|-NoRestart [&lt;SwitchParameter&gt;] |必須 |セットアップの実行中に再起動を要求しません (コンテナー機能を有効にするには再起動が必要です)。 |
|<a id="conversion-params" /> <strong>変換パラメーター</strong>|||
|-AppInstallPath &lt;String&gt;  |省略可能 |インストール済みのファイルに対応する、アプリケーションのルート フォルダーの完全パス (インストールされている場合)。"C:\Program Files (x86)\MyApp" など。|
|-Destination &lt;String&gt; |必須 |コンバーターの appx を出力する場所。この場所がまだ存在しない場合は、DesktopAppConverter によって作成されます。|
|-Installer &lt;String&gt; |必須 |アプリケーションのインストーラーのパス。無人/サイレント モードで実行できるようにする必要があります。 インストーラーの変換、これは、アプリケーションのファイルのルート ディレクトリへのパス。 |
|-InstallerArguments &lt;String&gt; |省略可能 |インストーラーに無人/サイレント モードでの実行を強制する引数の文字列、またはコンマ区切り一覧。 インストーラーが msi の場合は、このパラメーターは省略可能です。 インストーラーからログを取得するには、ここで、インストーラーのログ記録の引数を指定し、パス &lt;log_folder&gt; (コンバーターが適切なパスに置換するトークン) を使います。 <br><br>**注**: 無人/サイレント フラグとログの引数は、インストーラー テクノロジごとに異なります。 <br><br>このパラメーターの使用例: -InstallerArguments "/silent /log &lt;log_folder&gt;\install.log"。ログ ファイルを生成しない別の例: ```-InstallerArguments "/quiet", "/norestart"```。コンバーターでログをキャプチャし、最終的なログ フォルダーに格納する場合は、文字どおりすべてのログにトークン パス &lt;log_folder&gt; を指定する必要があります。|
|-InstallerValidExitCodes &lt;Int32&gt; |省略可能 |インストーラーの正常な実行を示す、コンマで区切った終了コードの一覧 (例: 0, 1234, 5678)。  既定では、非 msi は 0、msi は 0, 1641, 3010 です。|
|-MakeAppx [&lt;SwitchParameter&gt;]  |省略可能 |このスクリプトに出力で MakeAppx を呼び出すように指示するスイッチ (存在する場合)。 |
|-MakeMSIX [&lt;SwitchParameter&gt;]  |オプション |存在する場合、出力 MSIX パッケージとしてパッケージ化するには、このスクリプトに指示するスイッチ。 |
|<a id="identity-params" /><strong>パッケージ ID パラメーター</strong>||
|-PackageName &lt;String&gt; |必須 |ユニバーサル Windows アプリ パッケージの名前。 デベロッパー センターが数値で始まる ID をパッケージに割り当てる場合、必ず <i>-AppId</i> パラメーターも渡し、そのパラメーターの値として文字列サフィックスのみを使ってください (ピリオドの区切り記号の後)。 |
|-Publisher &lt;String&gt; |必須 |ユニバーサル Windows アプリ パッケージの発行元 |
|-Version &lt;Version&gt; |必須 |ユニバーサル Windows アプリ パッケージのバージョン番号 |
|<a id="manifest-params" /><strong>パッケージ マニフェスト パラメーター</strong>||
|-AppExecutable &lt;String&gt; |省略可能 |アプリケーションのメインの実行可能ファイルの名前 (例:"MyApp.exe")。 インストーラーを使用しない変換では、このパラメーターは必須です。 |
|-AppFileTypes &lt;String&gt;|省略可能 |アプリケーションに関連付ける、ファイルの種類のコンマ区切りの一覧。 使用例: -AppFileTypes "'.md', '.markdown'"。|
|-AppId &lt;String&gt; |省略可能 |Windows アプリ パッケージ マニフェストでアプリケーション ID を設定する値を指定します。 指定しなかった場合は、*PackageName* で渡した値が設定されます。 多くの場合、*PackageName* を使って問題ありません。 ただし、デベロッパー センターが数値で始まる ID をパッケージに割り当てる場合、必ず <i>-AppId</i> パラメーターも渡し、そのパラメーターの値として文字列サフィックスのみを使ってください (ピリオドの区切り記号の後)。 |
|-AppDisplayName &lt;String&gt;  |省略可能 |Windows アプリ パッケージ マニフェストでアプリケーションの表示名を設定する値を指定します。 指定しなかった場合は、*PackageName* で渡した値が設定されます。 |
|-AppDescription &lt;String&gt; |省略可能 |Windows アプリ パッケージ マニフェストでアプリケーションの説明を設定する値を指定します。 指定しなかった場合は、*PackageName* で渡した値が設定されます。|
|-PackageDisplayName &lt;String&gt; |省略可能 |Windows アプリ パッケージ マニフェストでパッケージの表示名を設定する値を指定します。 指定しなかった場合は、*PackageName* で渡した値が設定されます。 |
|-PackagePublisherDisplayName &lt;String&gt; |省略可能 |Windows アプリ パッケージ マニフェストでパッケージ発行元の表示名を設定する値を指定します。 指定しなかった場合は、*Publisher* で渡した値が設定されます。 |
|<a id="cleanup-params" /><strong>クリーンアップ パラメーター</strong>|||
|-Cleanup [&lt;Option&gt;] |必須 |DesktopAppConverter の成果物のクリーンアップを実行します。 クリーンアップ モードには 3 つの有効なオプションがあります。 |
|-Cleanup All | |展開済みのすべての基本イメージを削除し、コンバーターのすべての一時ファイルを削除します。コンテナーのネットワークを削除し、Windows のオプション機能、コンテナーを無効にします。 |
|-Cleanup WorkDirectory |必須 |コンバーターのすべての一時ファイルを削除します。 |
|-Cleanup ExpandedImage |必須 |ホスト コンピューターにインストールされているすべての展開済みの基本イメージを削除します。 |
|<a id="architecture-params" /><strong>パッケージ アーキテクチャ パラメーター</strong>|||
|-PackageArch &lt;String&gt; |必須 |指定したアーキテクチャのパッケージを生成します。 有効なオプションは、'x86' または 'x64' です。たとえば、-PackageArch x86 のように指定します。 このパラメーターは省略可能です。 指定されていない場合、DesktopAppConverter はパッケージのアーキテクチャの自動検出を試みます。 自動検出に失敗した場合、既定値は x64 パッケージです。 |
|<a id="other-params" /><strong>その他のパラメーター</strong>|||
|-ExpandedBaseImage &lt;String&gt;  |省略可能 |既に展開済みの基本イメージの完全パス。|
|-LogFile &lt;String&gt;  |省略可能 |ログ ファイルを指定します。 省略した場合は、ログ ファイルの一時的な場所が作成されます。 |
| -Sign [&lt;SwitchParameter&gt;] |省略可能 |出力する Windows アプリ パッケージに、テスト用に生成された証明書を使用して署名するようにこのスクリプトに指示します。 このスイッチは、```-MakeAppx``` スイッチと共に指定する必要があります。 |
|&lt;共通パラメーター&gt; |必須 |このコマンドレットは、共通パラメーター *Verbose*、*Debug*、*ErrorAction*、*ErrorVariable*、*WarningAction*、*WarningVariable*、*OutBuffer*、*PipelineVariable*、*OutVariable* をサポートします。 詳しくは、「[about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216)」をご覧ください。 |
| -Verify [&lt;SwitchParameter&gt;] |オプション |指定されている場合、パッケージ アプリと Microsoft Store 要件に照らして、アプリ パッケージを検証する DAC に指示するスイッチ。 結果は、検証レポート "VerifyReport.xml" で、ブラウザーでの視覚化に最適です。 このスイッチは、`-MakeAppx` スイッチと共に指定する必要があります。 |
|-PublishComRegistrations| 省略可能| インストーラーによって行われたすべての パブリック COM 登録をスキャンし、有効な登録をマニフェストで公開します。 このフラグは、これらの登録を他のアプリケーションで利用できるようにする場合にのみ使用してください。 これらの登録を対象アプリケーションでのみ使用する場合、このフラグを使用する必要はありません。 <br><br>アプリをパッケージ化した後、正常に動作するように COM 登録を行うには、[こちらの記事](https://blogs.windows.com/buildingapps/2017/04/13/com-server-ole-document-support-desktop-bridge/#lDg5gSFxJ2TDlpC6.97)をご覧ください。

<a id="run-app" />

## <a name="run-the-packaged-app"></a>パッケージ アプリを実行する

アプリを実行するには、2 種類の方法があります。

1 つ目は、PowerShell コマンド プロンプトを開いて、```Add-AppxPackage –Register AppxManifest.xml``` というコマンドを入力する方法です。 署名する必要がないために、アプリケーションを実行する最も簡単な方法では可能性があります。

証明書を使って、アプリケーションの署名を別の方法です。 使用する場合、```sign```パラメーター、Desktop App Converter は、のいずれかを生成し、それを使用してアプリケーションに署名します。 その証明書ファイルは **auto-generated.cer** という名前になり、パッケージ アプリのルート フォルダーに配置されます。

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

バグを解決、ビジュアルのアセットを追加またはライブ タイルなどの最新のエクスペリエンスを使用してアプリケーションを強化をパッケージ化されたアプリケーションに変更を加えたあります可能性があります。

変更を加えた後、もう一度コンバーターを実行する必要はありません。 ほとんどの場合、することができますだけと再パッケージ化アプリケーション MakeAppx ツールを使用して、アプリの appxmanifest.xml ファイル、DAC が生成されます。 「[Windows アプリ パッケージを生成する](desktop-to-uwp-manual-conversion.md#make-appx)」をご覧ください。

* アプリのビジュアル アセットを変更する場合、新しいパッケージ リソース インデックス ファイルを生成し、MakeAppx ツールを実行して新しいパッケージを生成します。 「[パッケージ リソース インデックス (PRI) ファイルを生成する](desktop-to-uwp-manual-conversion.md#make-pri)」をご覧ください。

* Windows タスク バー、タスク ビュー、スナップ アシスト、Alt + Tab キーを押したときの一覧、およびスタート画面のタイルの右下に表示されるアイコンおよびタイルを追加する場合は、「[(省略可能) ターゲット ベースのプレートなしのアセットを追加する](desktop-to-uwp-manual-conversion.md#target-based-assets)」をご覧ください。

> [!NOTE]
> インストーラーによるレジストリ設定を変更した場合は、その変更を適用するために、Desktop App Converter をもう一度実行する必要があります。

**ビデオ**

|出力の変更と再パッケージ化 |デモ: 出力の変更と再パッケージ化|
|---|---|
|<iframe src="https://mva.microsoft.com/en-US/training-courses-embed/developers-guide-to-the-desktop-bridge-17373/Video-Modifying-and-Repackaging-Output-from-Desktop-App-Converter-OwpAJ3WhD_6706218965" width="426" height="472" allowFullScreen frameBorder="0"></iframe>|<iframe src="https://mva.microsoft.com/en-US/training-courses-embed/developers-guide-to-the-desktop-bridge-17373/Demo-Modify-Output-from-Desktop-App-Converter-gEnsa3WhD_8606218965" width="426" height="472" allowFullScreen frameBorder="0"></iframe>|

次の 2 つのセクションでは、いくつかの省略可能な修正を検討してパッケージのアプリケーションについて説明します。

### <a name="delete-unnecessary-files-and-registry-keys"></a>不要なファイルとレジストリ キーを削除する

Desktop App Converter では、コンテナー内のファイルとシステム ノイズの除去に、非常に保守的なアプローチを取っています。

VFS フォルダーを確認し、インストーラーに必要ないファイルがあれば、削除することもできます。  また、Reg.dat の内容を確認し、アプリによってインストールされないキーや不要なキーがあれば、削除できます。

### <a name="fix-corrupted-pe-headers"></a>破損した PEヘッダーを修正する

DesktopAppConverter は 変換処理中に PEHeaderCertFixTool を自動的に実行し、破損している PEヘッダーを修正します。 ただし、UWP の Windows アプリ パッケージ、ルーズ ファイル、または特定のバイナリで、PEHeaderCertFixTool を実行することも可能です。 次に例を示します。

```CMD
PEHeaderCertFixTool.exe <binary file>|<.appx package>|<folder> [/c] [/v]
 /c   -- check for corrupted certificate but do not fix (optional)
 /v   -- verbose (optional)
example1: PEHeaderCertFixTool app.exe
example2: PEHeaderCertFixTool c:\package.appx /c
example3: PEHeaderCertFixTool c:\myapp /c /v
```

## <a name="telemetry-from-desktop-app-converter"></a>Desktop App Converter の利用統計情報

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

**質問に対する回答を見つける**

ご質問がある場合は、 Stack Overflow でお問い合わせください。 Microsoft のチームでは、これらの[タグ](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge)をチェックしています。 [こちら](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D)から質問することもできます。

[ここ](desktop-to-uwp-known-issues.md#app-converter)で既知の問題の一覧を確認することもできます。

**フィードバックの提供または機能の提案を行う**

[UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial) のページをご覧ください。

**アプリケーションを実行し、検索/問題を修正します。**

[実行、デバッグ、およびデスクトップ アプリケーションをパッケージ化されたテスト](desktop-to-uwp-debug.md)を参照してください。

**アプリを配布する**

[デスクトップ アプリケーションのパッケージの配布](desktop-to-uwp-distribute.md)を参照してください。
