---
author: normesta
Description: Fix issues that prevent your desktop application from running in an MSIX container
Search.Product: eADQiWindows 10XVcnh
title: デスクトップ アプリケーション、MSIX コンテナーでの実行を妨げている問題を修正します。
ms.author: normesta
ms.date: 07/02/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 46d5705233af9e8254b9ac89a2d6e9891e90701f
ms.sourcegitcommit: 53ba430930ecec8ea10c95b390fe6e654fe363e1
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/06/2018
ms.locfileid: "3420460"
---
# <a name="apply-runtime-fixes-to-an-msix-package-by-using-the-package-support-framework"></a>パッケージのサポートのフレームワークを使用して MSIX パッケージにランタイムの修正プログラムを適用します。

パッケージのサポートのフレームワークでは、修正プログラムの適用、既存の win32 アプリケーションをソース コードにアクセスできない場合、MSIX コンテナーで実行できるようにするために役立つ、オープン ソースのキットです。 パッケージのサポートのフレームワークには、最新のランタイム環境のベスト プラクティスに従って、アプリケーションが役立ちます。

パッケージのサポートのフレームワークを作成するには、Microsoft Research (MSR) によって開発された、オープン ソースのフレームワークは、API のリダイレクトおよびフックを際に役立つテクノロジ[は](https://www.microsoft.com/en-us/research/project/detours)可能です。

このフレームワークは、オープン ソース、軽量で、アプリケーションの問題を解決する迅速に使用できます。 世界では、コミュニティに相談して、他のユーザーへの投資の最上位に構築する機会もできます。

## <a name="a-quick-look-inside-of-the-package-support-framework"></a>パッケージのサポート フレームワーク内での確認

パッケージのサポートのフレームワークには、実行可能ファイル、ランタイム マネージャー、DLL とランタイムの修正プログラムのセットが含まれています。

![パッケージのサポート フレームワーク](images/desktop-to-uwp/package-support-framework.png)

しくみは次のとおりです。 アプリケーションに適用する fix(s) を指定するための構成ファイルを作成します。 次に、shim ランチャーの実行可能ファイルをポイントするパッケージを変更します。

ユーザーは、アプリケーションを起動、shim ランチャーが実行される最初の実行可能ファイルです。 これは、構成ファイルの読み取りし、ランタイム fix(s) とランタイム manager DLL をアプリケーションのプロセスに挿入します。

![パッケージのサポート フレームワーク DLL インジェクション](images/desktop-to-uwp/package-support-framework-2.png)

ランタイム マネージャーでは、MSIX コンテナー内で実行するアプリケーションでは、必要に応じて、修正プログラムが適用されます。

このガイドには、アプリケーションの互換性の問題を識別するため、それらに対処する修正プログラムを検索して、適用すると、ランタイムを拡張します。

<a id="identify" />

## <a name="identify-packaged-application-compatibility-issues"></a>パッケージ化されたアプリケーションの互換性の問題を特定します。

まず、アプリケーションのパッケージを作成します。 次に、インストールを実行し、その動作を確認します。 互換性の問題を特定する際に役立つエラー メッセージを受け取る可能性があります。 問題を特定するのに[プロセスのモニター](https://docs.microsoft.com/en-us/sysinternals/downloads/procmon)を使用することもできます。  一般的な問題に関連する作業ディレクトリとプログラムのパスのアクセス許可に関するアプリケーションの前提条件です。

### <a name="using-process-monitor-to-identify-an-issue"></a>プロセスのモニターを使用して、問題を特定するには

[プロセスのモニター](https://docs.microsoft.com/en-us/sysinternals/downloads/procmon)は、アプリのファイルとレジストリの操作、およびその結果を監視するための強力なユーティリティです。  アプリケーションの互換性の問題について理解することができます。  プロセスのモニターを開いたら、フィルターを追加します (フィルター > フィルター] をクリックします) をアプリケーションの実行可能ファイルからのイベントのみが含まれます。

![ProcMon アプリ フィルター](images/desktop-to-uwp/procmon_app_filter.png)

イベントの一覧が表示されます。 これらのイベントの多くに、単語**成功**を**結果**の列に表示してされます。

![ProcMon イベント](images/desktop-to-uwp/procmon_events.png)

必要に応じて、のみエラーのみを表示するイベントをフィルター処理することができます。

![ProcMon 除外の成功](images/desktop-to-uwp/procmon_exclude_success.png)

ファイルシステムへアクセスの失敗が疑われる場合は、[System32/SysWOW64 またはパッケージのファイル パスの下である障害が発生したイベントを検索します。 フィルターを使っても役立つここでは、すぎます。 この一覧の下部に開始し、上方向にスクロールします。 この一覧の下部に表示されるエラーは、最近発生しています。 「アクセス拒否」などの文字列が含まれるエラーと「パスと名前見つからない」にほとんどの注意を払うし、疑わしい外観がないことを無視します。 [PSFSample](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/samples/PSFSample/)では、2 つの問題があります。 次の図で表示された一覧でそれらの問題を確認できます。

![ProcMon Config.txt](images/desktop-to-uwp/procmon_config_txt.png)

この画像に表示される最初の問題、アプリケーションは、"C:\Windows\SysWOW64"パスにある"Config.txt"ファイルから読み取るに失敗しています。 アプリケーションがそのパスを直接参照しようとしている可能性が高いことはできません。 相対パスを使用して、そのファイルから読み取るしようとして、"System32/SysWOW64"は、アプリケーションの作業ディレクトリを既定では、ほとんどの場合、します。 これは、アプリケーションでは、パッケージにどこか設定されている現在の作業ディレクトリを想定を示しています。 Appx 内で見ると、実行可能ファイルと同じディレクトリで、ファイルが存在することを確認できます。

![アプリの Config.txt](images/desktop-to-uwp/psfsampleapp_config_txt.png)

2 番目の問題は、次の図が表示されます。

![ProcMon ログ ファイル](images/desktop-to-uwp/procmon_logfile.png)

この問題は、アプリケーションは、そのパッケージのパスに .log ファイルを書き込むに失敗しています。 これにより、ファイルのリダイレクト shim が役立つ場合がありますがお勧めします。

<a id="find" />

## <a name="find-a-runtime-fix"></a>ランタイムの修正プログラムを見つける

PSF には、ファイルのリダイレクト shim など、今すぐに使用できるランタイムの修正プログラムが含まれています。

### <a name="file-redirection-shim"></a>ファイルのリダイレクト Shim

[ファイル リダイレクト Shim](https://github.com/Microsoft/MSIX-PackageSupportFramework/tree/develop/FileRedirectionShim)を使用して、リダイレクト書き込みまたはディレクトリにない、MSIX コンテナーで実行されるアプリケーションからアクセス可能なデータを読み取るしようとすることができます。

たとえば、アプリケーションが、アプリケーションの実行可能ファイルと同じディレクトリにあるログ ファイルに書き込む場合、は、ローカル アプリ データ ストアなどの別の場所にそのログ ファイルを作成する[ファイルのリダイレクト Shim](https://github.com/Microsoft/MSIX-PackageSupportFramework/tree/develop/FileRedirectionShim)を使用できます。

### <a name="runtime-fixes-from-the-community"></a>コミュニティからランタイムの修正プログラム

当社の[GitHub](https://github.com/Microsoft/MSIX-PackageSupportFramework/tree/develop)ページをコミュニティの投稿を確認します。 他の開発者が自分のような問題が解決され、ランタイムの修正プログラムと共有できます。

## <a name="apply-a-runtime-fix"></a>ランタイムの修正プログラムを適用します。

Windows SDK にし、次の手順では、いくつかの簡単なツールを使用して既存のランタイムの修正を適用できます。

> [!div class="checklist"]
> * パッケージ レイアウト フォルダーを作成します。
> * サポート フレームワークのパッケージ ファイルを取得します。
> * パッケージに追加します。
> * パッケージ マニフェストの変更
> * 構成ファイルを作成します。

各タスクを見ていきましょう。

### <a name="create-the-package-layout-folder"></a>パッケージ レイアウトのフォルダーを作成します。

.Appx ファイルが既にがある場合の内容をパッケージのステージング領域として使用されるレイアウト フォルダーに展開できます。  これを行う、 **x64 ツールのネイティブのコマンド プロンプト for VS 2017**、または手動で検索が実行可能ファイルのパスで SDK bin パス。

```
makeappx unpack /p PSFSamplePackage_1.0.60.0_AnyCPU_Debug.appx /d PackageContents

```

これにより、次のようになります。

![パッケージのレイアウト](images/desktop-to-uwp/package_contents.png)

.Appx ファイルは、開始時があるない、ゼロから、パッケージのフォルダーとファイルを作成できます。

### <a name="get-the-package-support-framework-files"></a>サポート フレームワークのパッケージ ファイルを取得します。

Visual Studio を使って、PSF Nuget パッケージを取得できます。 スタンドアロン Nuget コマンド ライン ツールを使って取得できます。

#### <a name="get-the-package-by-using-visual-studio"></a>Visual Studio を使って、パッケージを取得します。

Visual Studio のソリューションやプロジェクト ノードを右クリックし、Nuget パッケージの管理コマンドのいずれかを選択します。  検索**Microsoft.PackageSupportFramework** **PSF** Nuget.org 上、パッケージを検索します。次に、インストールします。

#### <a name="get-the-package-by-using-the-command-line-tool"></a>コマンド ライン ツールを使用して、パッケージを取得します。

この場所から Nuget コマンド ライン ツールのインストール:https://www.nuget.org/downloadsします。 次に、Nuget コマンドラインからは、次のコマンドを実行します。

```
nuget install Microsoft.PackageSupportFramework
```

### <a name="add-the-package-support-framework-files-to-your-package"></a>サポート フレームワークのパッケージ ファイルをパッケージに追加します。

パッケージのディレクトリに、必要な 32 ビットと 64 ビット PSF Dll と実行可能ファイルを追加します。 次の表をガイドとして使用してください。 必要な任意のランタイム修正が含まれてすることもあります。 この例でファイルのリダイレクトのランタイムの修正が必要です。

| アプリケーションの実行可能ファイルは x64 | アプリケーションの実行可能ファイルは x86 |
|-------------------------------|-----------|
| [ShimLauncher64.exe](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/ShimLauncher/readme.md) |  [ShimLauncher32.exe](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/ShimLauncher/readme.md) |
| [ShimRuntime64.dll](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/ShimRuntime/readme.md) | [ShimRuntime32.dll](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/ShimRuntime/readme.md) |
| [ShimRunDll64.exe](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/ShimRunDll/readme.md) | [ShimRunDll32.exe](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/ShimRunDll/readme.md) |

パッケージの内容は次のようになります。

![パッケージのバイナリ](images/desktop-to-uwp/package_binaries.png)

### <a name="modify-the-package-manifest"></a>パッケージ マニフェストの変更

テキスト エディターで、パッケージ マニフェストを開き、設定、`Executable`の属性、`Application`要素 shim ランチャーの実行可能ファイルの名前にします。  ターゲット アプリケーションのアーキテクチャがわかっている場合は、ShimLauncher32.exe または ShimLauncher64.exe は、適切なバージョンを選択します。  ない場合は、ShimLauncher32.exe はどのようなケースで動作します。  次に例を示します。

```xml
<Package ...>
  ...
  <Applications>
    <Application Id="PSFSample"
                 Executable="ShimLauncher32.exe"
                 EntryPoint="Windows.FullTrustApplication">
      ...
    </Application>
  </Applications>
</Package>
```

### <a name="create-a-configuration-file"></a>構成ファイルを作成します。

ファイル名を作成``config.json``、パッケージのルート フォルダーにそのファイルを保存します。 交換した実行可能ファイルをポイントする config.json ファイルの宣言されているアプリの ID を変更します。 プロセス モニターの使用権を取得するサポート技術情報を使用して、したりすることできますも作業ディレクトリを設定しファイル リダイレクト shim を使用して、パッケージと相対的な"PSFSampleApp"ディレクトリ .log ファイルの読み取り/書き込みをリダイレクトします。

```json
{
    "applications": [
        {
            "id": "PSFSample",
            "executable": "PSFSampleApp/PSFSample.exe",
            "workingDirectory": "PSFSampleApp/"
        }
    ],
    "processes": [
        {
            "executable": "PSFSample",
            "shims": [
                {
                    "dll": "FileRedirectionShim.dll",
                    "config": {
                        "redirectedPaths": {
                            "packageRelative": [
                                {
                                    "base": "PSFSampleApp/",
                                    "patterns": [
                                        ".*\\.log"
                                    ]
                                }
                            ]
                        }
                    }
                }
            ]
        }
    ]
}
```
次に示します。 config.json スキーマのためのガイド

| 配列 | key | 値 |
|-------|-----------|-------|
| applications | id |  値を使用して、`Id`の属性、 `Application` 、パッケージ マニフェスト内の要素です。 |
| applications | 実行可能 | 起動する実行可能ファイルのパッケージ相対パス。 ほとんどの場合、変更する前に、パッケージ マニフェスト ファイルからこの値を取得できます。 値であること、`Executable`の属性、`Application`要素です。 |
| applications | 作業ディレクトリ | (省略可能)起動するアプリケーションの作業ディレクトリとして使用するパッケージの相対パス。 この値を設定しない場合、オペレーティング システムを使用して、 `System32` 、アプリケーションの作業ディレクトリとしてディレクトリ。 |
| プロセス | 実行可能 | ほとんどの場合の名前になります、`executable`削除パスとファイルの拡張子を持つ上に構成されています。 |
| shim | dll | 読み込む shim .appx パッケージ相対パス。 |
| shim | 構成 | (省略可能)Shim 配布リストがどのように動作するかを制御します。 この値の正確な形式は、各 shim はこの"blob"を解釈できる必要があるように shim-shim によってごとに異なります。 |

`applications`、 `processes`、および`shims`キーは、配列です。 つまり、1 つ以上のアプリケーション、プロセス、および shim DLL を指定する config.json ファイルを使用することができます。


### <a name="package-and-test-the-app"></a>パッケージと、アプリのテスト

次に、パッケージを作成します。

```
makeappx pack /d PackageContents /p PSFSamplePackageFixup.appx
```

次に、署名します。

```
signtool sign /a /v /fd sha256 /f ExportedSigningCertificate.pfx PSFSamplePackageFixup.appx
```

詳しくは、 [signtool を使ってパッケージに署名する方法](https://docs.microsoft.com/en-us/windows/desktop/appxpkg/how-to-sign-a-package-using-signtool)と[、パッケージの署名証明書を作成する方法](https://docs.microsoft.com/en-us/windows/desktop/appxpkg/how-to-create-a-package-signing-certificate)をご覧ください。

PowerShell を使用して、パッケージをインストールします。

>[!NOTE]
> 最初に、パッケージをアンインストールするには、この注意してください。

```
powershell Add-AppxPackage .\PSFSamplePackageFixup.appx
```

アプリケーションを実行し、ランタイムの修正プログラムが適用されると、動作を確認します。  診断と必要に応じて、パッケージの手順を繰り返します。

### <a name="use-the-trace-shim"></a>トレース Shim を使用します。

パッケージ化されたアプリケーションの互換性の問題を診断するために別の手法では、トレース Shim を使用します。 この DLL は、PSF 付属であり、プロセスの監視と同様、アプリの動作の詳細な診断ビューを提供します。  アプリケーションの互換性の問題を表示するように設計します。  トレース Shim を使用して、DLL、パッケージを追加、config.json に次のフラグメントを追加し、パッケージ化し、およびインストールするアプリケーション。

```json
{
    "dll": "TraceShim.dll",
    "config": {
        "traceLevels": {
            "filesystem": "allFailures"
        }
    }
}
```

既定では、トレース Shim「期待」と考えられるエラーが除外されます。  たとえば、アプリケーションは無条件に既に存在するかどうか、結果を無視を確認することがなく、ファイルを削除しよう可能性があります。 ようにおファイルシステム関数からすべてのエラーを受信することを選択では、上記の例では、サインアウトして、いくつかの予期しないエラーをフィルター処理を取得する可能性があります残念ながら上の結果があります。 これは Config.txt ファイルから読み取る試行失敗のメッセージ「ファイルが見つかりません」前に、そのからわかっているためです。 これは、頻繁に確認されたでは、一般に予想するものと想定したエラーです。 実際には、のみに予期しないエラーをフィルタ リングとそのにフォールバックするすべてのエラーも識別できない問題がある場合を開始する可能性の最適なを勧めします。

既定では、トレース Shim からの出力を取得、アタッチされたデバッガーに送信されます。 この例では、お、デバッガーをアタッチすることはないが代わりにプログラムを使用して[デバッグ表示](https://docs.microsoft.com/en-us/sysinternals/downloads/debugview)SysInternals から出力を表示します。 アプリを実行すると、することができますエラーが表示される、同じ前とに、同じランタイムの修正プログラムの方向にポイントがマイクロソフトはします。

![TraceShim ファイルが見つかりません](images/desktop-to-uwp/traceshim_filenotfound.png)

![TraceShim アクセスが拒否されました](images/desktop-to-uwp/traceshim_accessdenied.png)

## <a name="debug-extend-or-create-a-runtime-fix"></a>デバッグ、延長、またはランタイムの修正プログラムの作成

ランタイムの修正プログラムのデバッグ、拡張ランタイムの修正プログラムを最初から作成に Visual Studio を使用することができます。 成功するには以下の操作を行う必要があります。

> [!div class="checklist"]
> * パッケージ プロジェクトを追加します。
> * ランタイムの修正プログラムのプロジェクトを追加します。
> * Shim ランチャーの実行可能ファイルを起動するプロジェクトを追加します。
> * パッケージ プロジェクトを構成します。

完了したら、ソリューションにはこれのようになります。

![完成したソリューション](images/desktop-to-uwp/runtime-fix-project-structure.png)

この例では、各プロジェクトを見てみましょう。

| プロジェクト | 目的 |
|-------|-----------|
| DesktopApplicationPackage | このプロジェクトは、 [Windows アプリケーション パッケージ プロジェクト](desktop-to-uwp-packaging-dot-net.md)に基づいており、出力、MSIX パッケージ。 |
| Runtimefix | これは、ランタイムの修正プログラムとして機能する 1 つまたは複数の代替機能が含まれている C++ Dynamic-Linked ライブラリ プロジェクトです。 |
| ShimLauncher | これは、C 空のプロジェクトです。 このプロジェクトは、パッケージのサポート フレームワークのランタイム配布可能なファイルを収集する場所です。 実行可能ファイルを出力します。 その実行可能ファイルは、ソリューションを起動するときに実行される最初のものです。 |
| WinFormsDesktopApplication | このプロジェクトには、デスクトップ アプリケーションのソース コードが含まれています。 |

これらの種類のプロジェクトのすべてを含む完全なサンプルを見ると、 [PSFSample](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/samples/PSFSample/)を参照してください。

作成して、ソリューション内の各プロジェクトを構成する手順を見てみましょう。


### <a name="create-a-package-solution"></a>パッケージのソリューションを作成します。

デスクトップ アプリケーションのソリューションがない場合は、Visual Studio で新しい**空のソリューション**を作成します。

![空のソリューション](images/desktop-to-uwp/blank-solution.png)

あるすべてのアプリケーション プロジェクトに追加することもできます。

### <a name="add-a-packaging-project"></a>パッケージ プロジェクトを追加します。

**Windows アプリケーション パッケージ プロジェクト**がまだしていない場合は、いずれかを作成し、ソリューションに追加します。

![パッケージ プロジェクト テンプレート](images/desktop-to-uwp/package-project-template.png)

Windows アプリケーション パッケージ プロジェクトについて詳しくは、 [Visual Studio を使って、アプリケーションのパッケージ](desktop-to-uwp-packaging-dot-net.md)を参照してください。

**ソリューション エクスプ**ローラーで、パッケージ プロジェクトを右クリックして、**編集**、選びし、プロジェクト ファイルの末尾に追加します。

```
<Target Name="PSFRemoveSourceProject" AfterTargets="ExpandProjectReferences" BeforeTargets="_ConvertItems">
<ItemGroup>
  <FilteredNonWapProjProjectOutput Include="@(_FilteredNonWapProjProjectOutput)">
  <SourceProject Condition="'%(_FilteredNonWapProjProjectOutput.SourceProject)'=='<your runtime fix project name goes here>'" />
  </FilteredNonWapProjProjectOutput>
  <_FilteredNonWapProjProjectOutput Remove="@(_FilteredNonWapProjProjectOutput)" />
  <_FilteredNonWapProjProjectOutput Include="@(FilteredNonWapProjProjectOutput)" />
</ItemGroup>
</Target>
```

### <a name="add-project-for-the-runtime-fix"></a>ランタイムの修正プログラムのプロジェクトを追加します。

**ダイナミック リンク ライブラリ (DLL)** の C++ プロジェクトをソリューションに追加します。

![ランタイム ライブラリの修正](images/desktop-to-uwp/runtime-fix-library.png)

[プロジェクト]、[**プロパティ**を右クリックします。

プロパティ ページで、**標準的な C++ 言語**のフィールドを見つけるし、そのフィールドの横にあるドロップダウン リストで、[、 **ISO C 17 標準 (//std:c では 17)** オプション。

![ISO 17 オプション](images/desktop-to-uwp/iso-option.png)

そのプロジェクトを右クリックし、コンテキスト メニューで、 **Nuget パッケージの管理**オプションを選択しています。 **すべて**のまたは**nuget.org****パッケージ ソース**オプションが設定されていることを確認します。

次にそのフィールドの設定アイコンをクリックします。

*PSF*の検索 * Nuget パッケージ化し、このプロジェクトにインストールします。

![nuget パッケージ](images/desktop-to-uwp/psf-package.png)

デバッグや、既存のランタイム修正プログラムを拡張する場合は、このガイドの[ランタイムの修正プログラムを検索](#find)のセクションで説明したガイダンスを使用して、取得したランタイムの修正プログラム ファイルを追加します。

新しい修正プログラムを作成する場合は、追加しないでください何もこのプロジェクトにまだだけです。 お手伝いしますこのガイドの後半では、このプロジェクトに適切なファイルを追加します。 ここでは、ソリューションの設定は引き続きされます。

### <a name="add-a-project-that-starts-the-shim-launcher-executable"></a>Shim ランチャーの実行可能ファイルを起動するプロジェクトを追加します。

C**空のプロジェクト**のプロジェクトをソリューションに追加します。

![空のプロジェクト](images/desktop-to-uwp/blank-app.png)

このプロジェクトを前のセクションで説明されている同じガイダンスを使用して、 **PSF** Nuget パッケージを追加します。

開くと、**全般**設定] ページで、プロジェクトのプロパティ ページ、**ターゲット名**プロパティを設定``ShimLauncher32``または``ShimLauncher64``によっては、アプリケーションのアーキテクチャ。

![shim ランチャー リファレンス](images/desktop-to-uwp/shim-exe-reference.png)

ランタイムの修正プロジェクトへの参照をプロジェクトをソリューションに追加します。

![ランタイムの修正プログラムのリファレンス](images/desktop-to-uwp/reference-fix.png)

参照を右クリックし、[**プロパティ**] ウィンドウでこれらの値を適用します。

| プロパティ | 値 |
|-------|-----------|-------|
| ローカル コピーします。 | True |
| ローカル サテライト アセンブリをコピーします。 | True |
| 参照アセンブリの出力 | True |
| リンク ライブラリの依存関係 | False |
| リンク ライブラリの依存関係の入力 | False |

### <a name="configure-the-packaging-project"></a>パッケージ プロジェクトを構成します。

パッケージ プロジェクトで、**[アプリケーション]** フォルダーを右クリックして **[参照の追加]** を選びます。

![プロジェクト参照の追加](images/desktop-to-uwp/add-reference-packaging-project.png)

Shim ランチャー プロジェクトと、デスクトップ アプリケーション プロジェクトを選択し、 **[ok]** ボタンをクリックします。

![デスクトップ プロジェクト](images/desktop-to-uwp/package-project-references.png)

>[!NOTE]
> アプリケーションに、ソース コードしない場合は、shim ランチャー プロジェクトを選ぶだけです。 構成ファイルを作成するときに、実行可能ファイルを参照する方法について説明します。

**Applications** ] ノードでは、shim ランチャー アプリケーションを右クリックし、**エントリ ポイントとして設定**を選択し。

![エントリ ポイントの設定](images/desktop-to-uwp/set-startup-project.png)

という名前のファイルを追加``config.json``、パッケージ プロジェクトにコピーし、ファイルに次の json テキストを貼り付けます。 **コンテンツ**には、**パッケージ**のプロパティを設定します。

```json
{
    "applications": [
        {
            "id": "",
            "executable": "",
            "workingDirectory": ""
        }
    ],
    "processes": [
        {
            "executable": "",
            "shims": [
                {
                    "dll": "",
                    "config": {
                    }
                }
            ]
        }
    ]
}
```
各キーの値を提供します。 次の表をガイドとして使用します。

| 配列 | key | 値 |
|-------|-----------|-------|
| applications | id |  値を使用して、`Id`の属性、 `Application` 、パッケージ マニフェスト内の要素です。 |
| applications | 実行可能 | 起動する実行可能ファイルのパッケージ相対パス。 ほとんどの場合、変更する前に、パッケージ マニフェスト ファイルからこの値を取得できます。 値であること、`Executable`の属性、`Application`要素です。 |
| applications | 作業ディレクトリ | (省略可能)起動するアプリケーションの作業ディレクトリとして使用するパッケージの相対パス。 この値を設定しない場合、オペレーティング システムを使用して、 `System32` 、アプリケーションの作業ディレクトリとしてディレクトリ。 |
| プロセス | 実行可能 | ほとんどの場合の名前になります、`executable`削除パスとファイルの拡張子を持つ上に構成されています。 |
| shim | dll | Shim を読み込む DLL のパッケージ相対パス。 |
| shim | 構成 | (省略可能)Shim 配布リストがどのように動作するかを制御します。 この値の正確な形式は、各 shim はこの"blob"を解釈できる必要があるように shim-shim によってごとに異なります。 |

完了したら、``config.json``ファイルは次のようになります。

```json
{
  "applications": [
    {
      "id": "DesktopApplication",
      "executable": "DesktopApplication/WinFormsDesktopApplication.exe",
      "workingDirectory": "WinFormsDesktopApplication"
    }
  ],
  "processes": [
    {
      "executable": ".*App.*",
      "shims": [ { "dll": "RuntimeFix.dll" } ]
    }
  ]
}

```

>[!NOTE]
> `applications`、 `processes`、および`shims`キーは、配列です。 つまり、1 つ以上のアプリケーション、プロセス、および shim DLL を指定する config.json ファイルを使用することができます。

### <a name="debug-a-runtime-fix"></a>ランタイムの修正プログラムをデバッグします。

Visual Studio で f5 キーを押してデバッガーを起動します。  最初に起動することは、次に、ターゲット デスクトップ アプリケーションを開始する shim ランチャー アプリケーションです。  ターゲットのデスクトップ アプリケーションをデバッグするには、手動で**デバッグ**を選択してデスクトップ アプリケーションのプロセスにアタッチする必要があります->**プロセスにアタッチ**し、アプリケーションのプロセスを選択します。 ネイティブのランタイム修正 DLL を持つ .NET アプリケーションのデバッグを許可するには、マネージ コードとネイティブ コードの種類 (混在モード デバッグ) を選択します。  

これ設定して、デスクトップ アプリケーション コードとランタイムの修正プロジェクトで数行のコードの横にあるブレークポイントを設定できます。 アプリケーションに、ソース コードしない場合は、ランタイム修正プロジェクトで、数行のコードの横にあるのみにブレークポイントを設定することができます。

>[!NOTE]
> Visual Studio を使用する最も簡単な開発エクスペリエンスをデバッグするには、いくつかの制限があるときは、後でこのガイドでは、について説明します他のデバッグの手法を適用することができます。

## <a name="create-a-runtime-fix"></a>ランタイムの修正プログラムを作成します。

ない場合、ランタイムを解決する場合、代替関数を作成し、構成データを含む新しいランタイムの修正プログラムを作成すること、問題の修正を意味します。 各部分を見てみましょう。

### <a name="replacement-functions"></a>代替機能

最初に、どの関数の呼び出しは失敗 MSIX コンテナー内で、アプリケーションが実行されている場合を特定します。 次に、代替関数を呼び出す代わりに、ランタイム マネージャーを作成できます。 これにより、関数の実装を最新のランタイム環境の規則に準拠している動作に置き換えることです。

Visual Studio では、このガイドで既に作成したランタイム修正プロジェクトを開きます。

宣言、``SHIM_DEFINE_EXPORTS``マクロの include ステートメントを追加し、`shim_framework.h`それぞれの上部にあります。CPP ファイルは、ランタイムの修正プログラムの機能を追加します。

```c++
#define SHIM_DEFINE_EXPORTS
#include <shim_framework.h>
```
>[!IMPORTANT]
>確認して、`SHIM_DEFINE_EXPORTS`マクロが含めるステートメントの前に表示されます。

同じ関数のシグネチャを持つ関数を作成しているが動作を変更します。 置換する関数の例を以下に示します、`MessageBoxW`関数。

```c++
auto MessageBoxWImpl = &::MessageBoxW;
int WINAPI MessageBoxWShim(
    _In_opt_ HWND hwnd,
    _In_opt_ LPCWSTR,
    _In_opt_ LPCWSTR caption,
    _In_ UINT type)
{
    return MessageBoxWImpl(hwnd, L"SUCCESS: This worked", caption, type);
}

DECLARE_SHIM(MessageBoxWImpl, MessageBoxWShim);
```

呼び出し`DECLARE_SHIM`マップ、`MessageBoxW`関数は、新しい代替関数にします。 アプリが呼び出すしようとしたとき、`MessageBoxW`関数を置き換え関数を代わりに呼び出すことができます。

#### <a name="protect-against-recursive-calls-to-functions-in-runtime-fixes"></a>再帰的なランタイムの修正プログラムの関数の呼び出しからの保護します。

適用することが必要に応じて、`reentrancy_guard`を再帰的なランタイムの修正プログラムの関数の呼び出しを保護する関数の種類。

代替の関数を作成するなど、`CreateFile`関数。 実装を呼び出すことがあります、`CopyFile`関数がの実装、`CopyFile`関数を呼び出すことがあります、`CreateFile`関数。 これは、無限再帰サイクルへの呼び出しのする可能性があります、`CreateFile`関数。

ついて詳しくは`reentrancy_guard` [authoring.md](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/Authoring.md)を参照してください。

### <a name="configuration-data"></a>データの構成

ランタイムの修正プログラムへの構成データを追加する場合は、追加することを検討してください、``config.json``します。 これにより、使える、`ShimQueryCurrentDllConfig`を簡単にそのデータを解析します。 この例では、その構成ファイルから、ブール値と文字列の値を解析します。

```c++
if (auto configRoot = ::ShimQueryCurrentDllConfig())
{
    auto& config = configRoot->as_object();

    if (auto enabledValue = config.try_get("enabled"))
    {
        g_enabled = enabledValue->as_boolean().get();
    }

    if (auto logPathValue = config.try_get("logPath"))
    {
        g_logPath = logPathValue->as_string().wstring();
    }
}
```

## <a name="other-debugging-techniques"></a>その他のデバッグの手法

Visual Studio を使用すると、最も簡単な開発およびデバッグ エクスペリエンスは制限があります。

まず、F5 デバッグと、.appx パッケージからインストールするのではなく、パッケージ レイアウト フォルダー パスからルーズ ファイルを展開することによって、アプリケーションが実行されます。  レイアウト フォルダー通常はありません同じセキュリティの制限はインストールされているパッケージのフォルダーとして。 その結果、にくいかもしれませんランタイムの修正プログラムを適用する前にパッケージのパス アクセス拒否エラーを再現することもできます。

この問題に対処するためには、f5 キーを押してルーズ ファイルの展開ではなく、.appx パッケージの展開を使用します。  .Appx パッケージ ファイルを作成するには、上記で説明したように、Windows SDK から[MakeAppx](https://docs.microsoft.com/en-us/windows/desktop/appxpkg/make-appx-package--makeappx-exe-)ユーティリティを使用します。 またはから、Visual Studio 内、アプリケーションのプロジェクト ノードを右クリックし、**ストア**を選択->**アプリ パッケージの作成します**。

Visual Studio の別の問題は、デバッガーを起動するすべての子プロセスにアタッチするための組み込みサポートがないことができます。   Visual Studio での起動後が手動で接続され、ターゲット アプリケーションのスタートアップ パス内のロジックをデバッグが困難になります。

この問題に対処するため、使用子プロセスをサポートしているデバッガーがアタッチします。  注は通常、ターゲット アプリケーションをジャスト イン タイム (JIT) デバッガーをアタッチすることもできます。  これは、ほとんど JIT 技法 ImageFileExecutionOptions のレジストリ キーを使用して、対象のアプリの代わりにデバッガーを起動するためです。  ターゲット アプリに ShimRuntime.dll を挿入するために使用 ShimLauncher.exe detouring メカニズムが損なわれるためです。  WinDbg、 [Debugging Tools for Windows](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/index)に含まれているし、 [Windows SDK](https://developer.microsoft.com/en-US/windows/downloads/windows-10-sdk)から取得したサポート子プロセスのアタッチします。  サポート直接[起動して UWP アプリをデバッグ](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/debugging-a-uwp-app-using-windbg#span-idlaunchinganddebuggingauwpappspanspan-idlaunchinganddebuggingauwpappspanspan-idlaunchinganddebuggingauwpappspanlaunching-and-debugging-a-uwp-app)します。

子プロセスとしてターゲット アプリケーションの起動をデバッグするには、開始``WinDbg``します。

```
windbg.exe -plmPackage PSFSampleWithFixup_1.0.59.0_x86__7s220nvg1hg3m -plmApp PSFSample
```

``WinDbg``プロンプト、子のデバッグを有効にして適切なブレークポイントを設定します。

```
.childdbg 1
g
```
(ターゲット アプリケーションが開始され、デバッガーを中断するまで実行)

```
sxe ld fixup.dll
g
```
(修正の DLL が読み込まれるまで実行されません)

```
bp ...
```

>[!NOTE]
> [PLMDebug](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/plmdebug)は起動時には、アプリにデバッガーをアタッチにも使用でき、 [Debugging Tools for Windows](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/index)にも含まれています。  ただし、WinDbg によって提供されるようになりました直接サポートよりも複雑です。

## <a name="support-and-feedback"></a>サポートとフィードバック

**質問に対する回答を見つける**

ご質問がある場合は、 Stack Overflow でお問い合わせください。 Microsoft のチームでは、これらの[タグ](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge)をチェックしています。 [こちら](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D)から質問することもできます。
