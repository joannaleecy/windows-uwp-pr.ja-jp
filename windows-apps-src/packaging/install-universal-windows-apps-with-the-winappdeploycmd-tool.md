---
author: msatranjr
ms.assetid: 6AA037C0-35ED-4B9C-80A3-5E144D7EE94B
title: WinAppDeployCmd.exe ツールを使ったアプリのインストール
description: Windows のアプリケーションの展開ツール (WinAppDeployCmd.exe) は、Windows 10 コンピューターから Windows 10 Mobile デバイスにユニバーサル Windows プラットフォーム (UWP) アプリを展開するために利用できるコマンド ライン ツールです。
---
# WinAppDeployCmd.exe ツールを使ったアプリのインストール

\[ Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください \]

Windows のアプリケーションの展開ツール (WinAppDeployCmd.exe) は、Windows 10 コンピューターから Windows 10 Mobile デバイスにユニバーサル Windows プラットフォーム (UWP) アプリを展開するために利用できるコマンド ライン ツールです。 このツールを使うと、Windows 10 Mobile デバイスが USB で接続されているか同じサブネットにあれば、.appx パッケージを展開できます。Microsoft Visual Studio やそのアプリ用のソリューションは不要です。 この記事では、このツールを使って UWP アプリをインストールする方法について説明します。

Windows 10 SDK がインストールされていれば、WinAppDeployCmd ツールをコマンド プロンプトまたはスクリプト ファイルから実行できます。 WinAppDeployCmd.exe でアプリをインストールすると、.appx ファイルを使って Windows 10 Mobile デバイスにアプリがサイドローディングされます。 このコマンドによって、アプリに必要な証明書はインストールされません。 アプリを実行するには、Windows 10 Mobile デバイスが開発者モードになっているか、証明書が既にインストールされている必要があります。

Windows 10 Mobile デバイスにアプリを展開するには、先にパッケージを作成する必要があります。 詳しくは、\[parent link here\] をご覧ください。

**WinAppDeployCmd.exe** ツールは、Windows 10 コンピューターの **C:\\Program Files (x86)\\Windows Kits\\10\\bin\\x86\\WinAppDeployCmd.exe** にあります (SDK のインストール パスに基づきます)。 まず、Windows 10 Mobile デバイスを同じサブネットに接続するか、USB 接続で Windows 10 コンピューターに直接接続します。 この記事ではその後、このコマンドの次の構文と例を使って .appx パッケージを展開します。

## WinAppDeployCmd の構文とオプション

**WinAppDeployCmd.exe** で使うことができる構文を次に示します。

``` syntax
WinAppDeployCmd command -option <argument> ...
    WinAppDeployCmd devices
    WinAppDeployCmd devices <x>
    WinAppDeployCmd install -file <path> -ip <address>
    WinAppDeployCmd install -file <path> -guid <address> -pin <p>
    WinAppDeployCmd install -file <path> -ip <address> -dependency <a> <b> ...
    WinAppDeployCmd install -file <path> -guid <address> -dependency <a> <b> ...
    WinAppDeployCmd uninstall -file <path>
    WinAppDeployCmd uninstall -package <name>
    WinAppDeployCmd update -file <path>
    WinAppDeployCmd list -ip <address>
    WinAppDeployCmd list -guid <address>
```

ターゲット デバイスでアプリをインストール/アンインストールしたり、既にインストールされているアプリを更新したりできます。 既にインストールされているアプリによって保存されたデータや設定を保持するには、**install** オプションの代わりに **update** オプションを使います。

次の表では、**WinAppDeployCmd.exe** のコマンドについて説明します。

|             |                                                                     |
|-------------|---------------------------------------------------------------------|
| **コマンド** | **説明**                                                     |
| devices     | 利用可能なネットワーク デバイスの一覧を表示します。                         |
| install     | ターゲット デバイスに UWP アプリ パッケージをインストールします。                     |
| update      | ターゲット デバイスに既にインストールされている UWP アプリを更新します。    |
| list        | ターゲット デバイスに既にインストールされている UWP アプリの一覧を表示します。 |
| uninstall   | 指定したアプリ パッケージをターゲット デバイスからアンインストールします。         |

 

次の表では、**WinAppDeployCmd.exe** のオプションについて説明します。

|                  |                                                                                                                                                                                                               |
|------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| **コマンド**      | **説明**                                                                                                                                                                                               |
| -h (-help)       | コマンド、オプション、引数を表示します。                                                                                                                                                                     |
| -ip              | ターゲット デバイスの IP アドレス。                                                                                                                                                                              |
| -g (-guid)       | ターゲット デバイスの一意の識別子。                                                                                                                                                                       |
| -d (-dependency) | (省略可能) パッケージの依存関係のそれぞれの依存パスを指定します。 パスを指定しない場合、ツールはアプリ パッケージのルート ディレクトリと SDK のディレクトリで依存関係を探します。 |
| -f (-file)       | インストール、更新、またはアンインストールするアプリ パッケージのファイル パス。                                                                                                                                                |
| -p (-package)    | アンインストールするアプリ パッケージの完全なパッケージ名 (list コマンドを使って、デバイスに既にインストールされているパッケージの完全な名前を見つけることができます)。                                                   |
| -pin             | ターゲット デバイスとの接続を確立するために求められた場合に指定する PIN。 (認証が必要な場合に -pin オプションを指定して再試行するように求められます)                                                 |

 

次の表では、**WinAppDeployCmd.exe** のオプションについて説明します。

|                        |                                                                              |
|------------------------|------------------------------------------------------------------------------|
| **引数**           | **説明**                                                              |
| &lt;x&gt;              | タイムアウト (秒単位) (既定値は 10 です)                                          |
| &lt;address&gt;        | ターゲット デバイスの IP アドレスと一意の識別子。                        |
| &lt;a&gt;&lt;b&gt; ... | アプリ パッケージの依存関係のそれぞれの依存パス。                    |
| &lt;p&gt;              | 接続を確立するためのデバイス設定に示されている、英数字 PIN。 |
| &lt;path&gt;           | ファイル システム パス。                                                            |
| &lt;name&gt;           | アンインストールするアプリ パッケージの完全なパッケージ名。                          |

 
## WinAppDeployCmd.exe の例

**WinAppDeployCmd.exe** の構文を使ってコマンド ラインから展開する方法の例を、次に示します。

展開できるデバイスを表示します。 コマンドは 3 秒でタイムアウトになります。

``` syntax
WinAppDeployCmd devices 3
```

PC のダウンロード ディレクトリにある MyApp.appx パッケージからアプリを、IP アドレス 192.168.0.1、PIN A1B2C3 の Windows 10 Mobile デバイスにインストールして、デバイスとの接続を確立します。

``` syntax
WinAppDeployCmd install -file "Downloads\MyApp.appx" -ip 192.168.0.1 -pin A1B2C3
```

指定したパッケージ (その完全な名前に基づく) を、IP アドレスが 192.168.0.1 の Windows 10 Mobile デバイスからアンインストールします。 list コマンドを使って、デバイスにインストールされているパッケージの完全な名前を見つけることができます。

``` syntax
WinAppDeployCmd uninstall -package Company.MyApp_1.0.0.1_x64__qwertyuiop -ip 192.168.0.1
```

指定した .appx パッケージを使って、IP アドレスが 192.168.0.1 の Windows 10 Mobile デバイスに既にインストールされているアプリを更新します。

``` syntax
WinAppDeployCmd update -file "Downloads\MyApp.appx" -ip 192.168.0.1
```



<!--HONumber=May16_HO2-->


