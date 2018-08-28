---
author: normesta
Description: Fix issues that prevent your desktop application from running in an MSIX container
Search.Product: eADQiWindows 10XVcnh
title: デスクトップ アプリケーションを MSIX コンテナーで実行できるようにする問題を修正します。
ms.author: normesta
ms.date: 07/02/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 46d5705233af9e8254b9ac89a2d6e9891e90701f
ms.sourcegitcommit: 9a17266f208ec415fc718e5254d5b4c08835150c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/28/2018
ms.locfileid: "2888221"
---
# <a name="apply-runtime-fixes-to-an-msix-package-by-using-the-package-support-framework"></a>パッケージのサポート フレームワークを使用して MSIX パッケージにランタイムの修正プログラムを適用します。

パッケージのサポート フレームワークは MSIX コンテナーに実行できるように、ソース コードへのアクセスをしていない場合、既存の win32 アプリケーションに修正を適用することができるファイルを開くキットです。 パッケージのサポート フレームワークでは、アプリケーション モダンなランタイム環境のベスト プラクティスに従うことができます。

パッケージのサポート フレームワークを作成するには、Microsoft Research (MSR) が開発したファイルを開くフレームワーク API リダイレクションと接続でき[は](https://www.microsoft.com/en-us/research/project/detours)テクノロジを活用できます。

このフレームワークがファイルを開く、軽量、アプリケーションの問題を解決する簡単に使用できます。 他のユーザーの投資の一番上に作成して、世界のコミュニティに相談するには、営業案件も提供します。

## <a name="a-quick-look-inside-of-the-package-support-framework"></a>概要パッケージのサポート フレームワーク内

パッケージのサポート フレームワークには、実行可能ファイル、ランタイム マネージャー DLL、一連の実行時の修正プログラムが含まれています。

![パッケージのサポート フレームワーク](images/desktop-to-uwp/package-support-framework.png)

しくみは次のとおりです。 アプリに適用する fix(s) を指定する構成ファイルを作成します。 次に、shim 起動ツールの実行可能ファイルを指すように、パッケージを変更してみましょう。

ユーザーは、アプリケーションを起動、shim 起動ツールを実行している最初の実行可能ファイルです。 構成ファイルを読み取り、アプリケーションのプロセスにランタイム fix(s) とランタイム マネージャー DLL を挿入します。

![パッケージのサポート Framework DLL の挿入](images/desktop-to-uwp/package-support-framework-2.png)

ランタイム マネージャーでは、アプリケーションを実行する MSIX コンテナー内では、必要に応じて、修正プログラムが適用されます。

このガイドには、アプリケーションの互換性の問題を識別するため、検索、適用、および runtime を拡張するには、それらを解決するを修正する.

<a id="identify" />

## <a name="identify-packaged-application-compatibility-issues"></a>パッケージ アプリケーションの互換性の問題を特定します。

最初に、アプリケーションのパッケージを作成します。 次に、インストール、実行し、その動作を確認します。 互換性の問題を特定するのに役立つエラー メッセージがあります。 問題を識別するのに[プロセス モニター](https://docs.microsoft.com/en-us/sysinternals/downloads/procmon)を使用することもできます。  一般的な問題は、作業ディレクトリおよびプログラム パスのアクセス許可に関するアプリケーションの前提条件に関連しています。

### <a name="using-process-monitor-to-identify-an-issue"></a>プロセスのモニターを使用して、問題を識別するには

[モニターのプロセス](https://docs.microsoft.com/en-us/sysinternals/downloads/procmon)は、アプリのファイルと、レジストリ操作とその結果を調べるの強力なユーティリティです。  アプリケーションの互換性の問題を理解することができます。  プロセス モニターを開いた後、フィルターを追加する (フィルター > フィルター]) から実行可能なアプリケーションのイベントのみを含めます。

![ProcMon アプリのフィルター](images/desktop-to-uwp/procmon_app_filter.png)

イベントの一覧が表示されます。 これらのイベントの多くの単語**成功**を**結果**列に表示してされます。

![ProcMon イベント](images/desktop-to-uwp/procmon_events.png)

必要に応じて、のみエラーだけを表示するイベントをフィルター処理できます。

![成功の ProcMon を除外します。](images/desktop-to-uwp/procmon_exclude_success.png)

ファイル システムのアクセス エラーが疑われる場合は、System32/SysWOW64 またはパッケージ ファイル パスのいずれかの下にある失敗のイベントを検索します。 フィルターも役立ちますここでは、すぎます。 このリストの一番下にある起動し、上方向にスクロールします。 このリストの下部に表示されるエラーが発生した最近します。 「パスと名前は見つかりませんでした」、「アクセス拒否されると、」などの文字列を含むエラーをほとんど注意し、不審な外観がないことを無視します。 [PSFSample](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/samples/PSFSample/)には、次の 2 つの問題があります。 次の図に表示される一覧でこれらの問題が発生したことができます。

![ProcMon Config.txt](images/desktop-to-uwp/procmon_config_txt.png)

このイメージに表示される最初の問題、アプリケーションは"C:\Windows\SysWOW64"パスに配置されている"Config.txt"ファイル内の参照に失敗します。 アプリケーションがパスを直接参照しようとしている可能性が高いことはできません。 ほとんどの場合、パス、相対参照を使用して、そのファイルから読み取るしようとして"System32/SysWOW64"では既定では、アプリケーションの作業ディレクトリします。 これは、アプリケーションがパッケージのどこかに設定する作業の現在のディレクトリを待っていることを示しています。 [Appx 内を検索、ファイルが実行可能ファイルと同じディレクトリ内に存在することを確認できます。

![アプリ Config.txt](images/desktop-to-uwp/psfsampleapp_config_txt.png)

2 番目の問題は、次の図に表示されます。

![ProcMon ログ ファイル](images/desktop-to-uwp/procmon_logfile.png)

この問題は、[パッケージ パス. log ファイルを作成するアプリケーションが失敗しています。 これにより、ファイルのリダイレクト shim が役立つ場合がありますがお勧めします。

<a id="find" />

## <a name="find-a-runtime-fix"></a>実行時の修正プログラムを検索します。

[PSF には、ファイルのリダイレクト shim など、使用できるランタイム修正が含まれています。

### <a name="file-redirection-shim"></a>ファイルのリダイレクト Shim

書き込みまたは MSIX コンテナーで実行しているアプリケーションからアクセスすることのないディレクトリ内のデータを読み取る試みをリダイレクトするのには、[ファイルのリダイレクト Shim](https://github.com/Microsoft/MSIX-PackageSupportFramework/tree/develop/FileRedirectionShim)を使用できます。

たとえば場合は、アプリケーションは、実行可能アプリケーションと同じディレクトリ内にあるログ ファイルに書き込み、ローカルのアプリのデータ ストアなどの別の場所でそのログ ファイルを作成するのには[ファイル リダイレクション Shim](https://github.com/Microsoft/MSIX-PackageSupportFramework/tree/develop/FileRedirectionShim)を使用ことができます。

### <a name="runtime-fixes-from-the-community"></a>コミュニティからの実行時の修正

[GitHub](https://github.com/Microsoft/MSIX-PackageSupportFramework/tree/develop)ページにコミュニティ投稿を参照してください。 他の開発者がにもかかわらず、自分のような問題が解決し、実行時の修正プログラムを共有している考えられます。

## <a name="apply-a-runtime-fix"></a>実行時の修正プログラムを適用します。

Windows SDK し、次の手順では、いくつかの簡単なツールを使用して既存の実行時の修正を適用できます。

> [!div class="checklist"]
> * パッケージのレイアウトのフォルダーを作成します。
> * パッケージのサポート フレームワーク ファイルを取得します。
> * パッケージの追加します。
> * パッケージ マニフェストの変更
> * 構成ファイルを作成します。

各タスクしてみましょう。

### <a name="create-the-package-layout-folder"></a>パッケージのレイアウトのフォルダーを作成します。

既に .appx ファイルがある場合、その内容をパッケージ備中として使用するレイアウト フォルダーに展開ことができます。  これから行うことができます、 **x64 VS 2017 のネイティブのツール コマンド プロンプト**、または手動で実行可能ファイルの検索パスに SDK ビン パス。

```
makeappx unpack /p PSFSamplePackage_1.0.60.0_AnyCPU_Debug.appx /d PackageContents

```

これにより、次のようになります。

![パッケージのレイアウト](images/desktop-to-uwp/package_contents.png)

を持っていない .appx ファイルで起動する場合は、最初からパッケージ フォルダーやファイルを作成できます。

### <a name="get-the-package-support-framework-files"></a>パッケージのサポート フレームワーク ファイルを取得します。

Visual Studio を使用して、PSF Nuget パッケージを取得できます。 スタンドアロン Nuget のコマンド ライン ツールを使用して取得できます。

#### <a name="get-the-package-by-using-visual-studio"></a>Visual Studio を使用して、パッケージを入手します。

Visual Studio では、ソリューションまたはプロジェクト ノードを右クリックし、Nuget パッケージの管理のコマンドのいずれかを選びます。  検索**Microsoft.PackageSupportFramework**または**PSF** Nuget.org のパッケージを検索します。次に、インストールします。

#### <a name="get-the-package-by-using-the-command-line-tool"></a>コマンド ライン ツールを使用して、パッケージを取得します。

次の場所から Nuget コマンド ライン ツールのインストール:https://www.nuget.org/downloadsします。 次に、Nuget のコマンドラインでは、このコマンドを実行します。

```
nuget install Microsoft.PackageSupportFramework
```

### <a name="add-the-package-support-framework-files-to-your-package"></a>パッケージのサポート フレームワーク ファイルをパッケージに追加します。

パッケージのディレクトリに必要な 32 ビットと 64 ビット PSF Dll と実行可能ファイルを追加します。 次の表をガイドとして使用してください。 する必要があるどのようなランタイム修正を挿入するされます。 ここでは、ファイルのリダイレクト ランタイム修正が必要です。

| アプリケーションの実行可能ファイルが x64 | アプリケーションの実行可能ファイルが x86 |
|-------------------------------|-----------|
| [ShimLauncher64.exe](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/ShimLauncher/readme.md) |  [ShimLauncher32.exe](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/ShimLauncher/readme.md) |
| [ShimRuntime64.dll](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/ShimRuntime/readme.md) | [ShimRuntime32.dll](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/ShimRuntime/readme.md) |
| [ShimRunDll64.exe](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/ShimRunDll/readme.md) | [ShimRunDll32.exe](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/ShimRunDll/readme.md) |

パッケージ コンテンツは次のようになります。

![パッケージのバイナリ](images/desktop-to-uwp/package_binaries.png)

### <a name="modify-the-package-manifest"></a>パッケージ マニフェストの変更

テキスト エディターで、パッケージ マニフェストを開き、[設定、`Executable`の属性、 `Application` shim 起動ツールの実行可能ファイルの名前を要素。  ターゲット アプリケーションのアーキテクチャがわかっている場合は、ShimLauncher32.exe または ShimLauncher64.exe、適切なバージョンを選択します。  有効でない場合は、ShimLauncher32.exe は常に機能します。  次に例を示します。

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

ファイル名を作成する``config.json``、および、パッケージのルート フォルダーにそのファイルを保存します。 交換した実行可能ファイルを指すように、config.json ファイルの宣言されたアプリ ID を変更します。 プロセスのモニターを使用してから取得した情報を使用すると、できますも作業ディレクトリの設定などを行うことパッケージの相対"PSFSampleApp"ディレクトリ. log ファイルへの読み取り/書き込みをリダイレクトするのにはファイルのリダイレクト shim を使用します。

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
以下は、config.json スキーマ向けのガイドです。

| 配列 | key | 値 |
|-------|-----------|-------|
| applications | id |  値を使用して、`Id`の属性、`Application`パッケージ マニフェストの要素。 |
| applications | 実行可能ファイル | 開始する実行可能ファイルへのパッケージの相対パス。 ほとんどの場合、それを変更する前にパッケージ マニフェスト ファイルからこの値を得るができます。 値は、`Executable`の属性、`Application`要素。 |
| applications | 作業ディレクトリ | (オプション)作業を開始するディレクトリとして使用するパッケージの相対パス。 オペレーティング システムを使用して、この値を設定しない場合、`System32`ディレクトリをアプリケーションの作業のディレクトリです。 |
| プロセス | 実行可能ファイル | ほとんどの場合の名前になります、`executable`上にある削除パスとファイル拡張子のように構成されています。 |
| shim | dll | 読み込む shim .appx パッケージの相対パス。 |
| shim | 構成 | (オプション)Shim dl の動作を制御します。 この値の正確な形式は、各 shim できる解釈"blob"必要があると shim-によって-shim ごとに異なります。 |

`applications`、 `processes`、および`shims`キーは、配列します。 つまり、1 つ以上のアプリケーション、プロセス、および shim DLL を指定する config.json ファイルを使用することができます。


### <a name="package-and-test-the-app"></a>パッケージ化して、アプリのテスト

次に、パッケージを作成します。

```
makeappx pack /d PackageContents /p PSFSamplePackageFixup.appx
```

次に、署名します。

```
signtool sign /a /v /fd sha256 /f ExportedSigningCertificate.pfx PSFSamplePackageFixup.appx
```

詳細については、「 [signtool を使用して、パッケージ署名する方法](https://docs.microsoft.com/en-us/windows/desktop/appxpkg/how-to-sign-a-package-using-signtool)と[署名証明書パッケージを作成する方法](https://docs.microsoft.com/en-us/windows/desktop/appxpkg/how-to-create-a-package-signing-certificate)の使用」を参照してください。

PowerShell を使用して、パッケージをインストールします。

>[!NOTE]
> 最初に、パッケージをアンインストールしてください。

```
powershell Add-AppxPackage .\PSFSamplePackageFixup.appx
```

アプリケーションを実行し、ランタイムの修正プログラムが適用されると、動作を確認します。  診断および必要に応じてパッケージの手順を繰り返します。

### <a name="use-the-trace-shim"></a>トレース Shim を使用します。

パッケージ アプリケーションの互換性の問題を診断する以外の方法では、トレース Shim を使用します。 この DLL であり、PSF に含まれて、プロセスのモニターのようなアプリの動作の詳細な診断ビューを提供します。  アプリケーションの互換性の問題を表示するように設計します。  トレース Shim DLL パッケージを追加、config.json に次の例を追加し、[パッケージ化するし、アプリケーションをインストールします。

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

既定では、トレース Shim「予想」と考えられる失敗が除外されます。  たとえば、アプリケーション無条件に既に存在するかどうか、結果を無視して確認せずにファイルを削除することがありますしてみてください。 ファイル システム関数からすべてのエラーが表示される選択の上の例で、いくつかの予期しないエラーが取得フィルターで除外した、残念ながら上の結果があります。 前に、その Config.txt ファイル内の参照に失敗すると、メッセージ「ファイルは見つかりませんでした」とからわかっているので操作します。 これは、エラーが頻繁に確認しは、一般に予期しないがあると見なされます。 演習では、のみに予期しないエラーは、フィルター処理して、[比較がすべての失敗も識別できない問題がある場合は、最初に可能性が高いベストはできます。

既定では、トレース Shim からの出力が接続されているデバッガーに送らを取得します。 この例では、おデバッガーに接続するには、代わりにプログラムを使用して[デバッグ表示](https://docs.microsoft.com/en-us/sysinternals/downloads/debugview)SysInternals から出力を表示します。 アプリを実行すると、わかります同じ失敗前とに、同じランタイム修正に向かってポイントへのご協力します。

![TraceShim ファイルが見つからない](images/desktop-to-uwp/traceshim_filenotfound.png)

![TraceShim アクセス拒否](images/desktop-to-uwp/traceshim_accessdenied.png)

## <a name="debug-extend-or-create-a-runtime-fix"></a>デバッグ、拡張または実行時の修正プログラムを作成します。

ランタイムの修正プログラムをデバッグする、拡張ランタイム修正、一から作成するのには、Visual Studio を使用できます。 成功する点を実行する必要があります。

> [!div class="checklist"]
> * パッケージのプロジェクトを追加します。
> * ランタイム fix のプロジェクトを追加します。
> * 実行可能 Shim の起動ツールを起動するプロジェクトを追加します。
> * パッケージの project を構成します。

完了したら、次のようなものをソリューションになります。

![完成したソリューション](images/desktop-to-uwp/runtime-fix-project-structure.png)

この例では、各プロジェクトを見てみましょう。

| プロジェクト | 目的 |
|-------|-----------|
| DesktopApplicationPackage | このプロジェクトは、 [Windows アプリケーション パッケージのプロジェクト](desktop-to-uwp-packaging-dot-net.md)に基づいており、出力、パッケージ化する MSIX します。 |
| Runtimefix | ランタイム fix として機能する 1 つまたは複数の置換関数を含む C Dynamic-Linked ライブラリ プロジェクトであります。 |
| ShimLauncher | これは、C の空のプロジェクトです。 このプロジェクトには、パッケージ サポート Framework のランタイム配布可能なファイルを収集します。 実行可能ファイルを出力します。 その実行可能ファイルは、ソリューションを起動するときに実行される最初に注意します。 |
| WinFormsDesktopApplication | このプロジェクトには、デスクトップ アプリケーションのソース コードが含まれています。 |

これらの種類のプロジェクトのすべてを含む完全なサンプルを見ると、 [PSFSample](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/samples/PSFSample/)を参照してください。

作成およびソリューションでは、これらのプロジェクトの各を構成する手順を見てみましょう。


### <a name="create-a-package-solution"></a>ソリューションをパッケージを作成します。

デスクトップ アプリケーションのソリューションがいない場合は、Visual Studio で新しい**空のソリューション**を作成します。

![空のソリューション](images/desktop-to-uwp/blank-solution.png)

あるアプリケーション プロジェクトを追加することもできます。

### <a name="add-a-packaging-project"></a>パッケージのプロジェクトを追加します。

**Windows アプリケーション パッケージのプロジェクト**を持っていない場合は、1 つを作成し、ソリューションに追加します。

![パッケージのプロジェクトのテンプレート](images/desktop-to-uwp/package-project-template.png)

Windows アプリケーション パッケージのプロジェクトの詳細については、 [Visual Studio を使用して、アプリ パッケージ](desktop-to-uwp-packaging-dot-net.md)を参照してください。

**ソリューション エクスプ ローラー**でパッケージ プロジェクトを右クリックし、[**編集**] を選択し、これをプロジェクト ファイルの下に追加。

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

### <a name="add-project-for-the-runtime-fix"></a>ランタイム fix のプロジェクトを追加します。

ソリューション C++**ダイナミック リンク ライブラリ (DLL)** プロジェクトに追加します。

![ランタイム fix ライブラリ](images/desktop-to-uwp/runtime-fix-library.png)

[プロジェクト]、[**プロパティ**を右クリックします。

プロパティ ページ] で、[ **C++ 言語標準的な**フィールドを検索し、そのフィールドの横にあるドロップダウン リストで次のように選択します。 [ **ISO c 17 標準 (/std:c + + 17)** オプション。

![ISO 17 オプション](images/desktop-to-uwp/iso-option.png)

プロジェクトを右クリックし、[のコンテキスト メニューで、[ **Nuget パッケージの管理**] のオプション] を選びます。 [**パッケージのソース**] オプションが**すべて**または**nuget.org**に設定されていることを確認します。

次にそのフィールドの設定] をクリックします。

検索*PSF** Nuget パッケージ化し、次のプロジェクトのインストールします。

![nuget パッケージ](images/desktop-to-uwp/psf-package.png)

デバッグまたは既存の実行時の修正プログラムを拡張する場合は、このガイドの[実行時の修正プログラムを検索](#find)] セクションで説明するガイダンスを使用して取得したランタイム修正ファイルを追加します。

新しい修正を作成する場合は、追加しない何もこのプロジェクトにまだします。 このガイドの後に、このプロジェクトにファイルを追加するのに役立ちます。 ここでは、ソリューションの設定がいくされます。

### <a name="add-a-project-that-starts-the-shim-launcher-executable"></a>実行可能 Shim の起動ツールを起動するプロジェクトを追加します。

ソリューション C**空のプロジェクト**のプロジェクトに追加します。

![空のプロジェクト](images/desktop-to-uwp/blank-app.png)

このプロジェクトに**PSF** Nuget パッケージを追加するには、同じ、前のセクションで説明するガイダンスを使用します。

開いているプロジェクトの**全般**設定] ページのプロパティ ページ**Target Name**プロパティを設定します``ShimLauncher32``または``ShimLauncher64``によっては、アプリケーションのアーキテクチャは、します。

![shim 起動ツールの参照](images/desktop-to-uwp/shim-exe-reference.png)

ソリューションのランタイム fix プロジェクトにプロジェクトの参照を追加します。

![ランタイム fix リファレンス](images/desktop-to-uwp/reference-fix.png)

参照を右クリックし、[**プロパティ**] ウィンドウで以下の値を適用します。

| プロパティ | 値 |
|-------|-----------|-------|
| ローカル コピーします。 | True |
| ローカルのサテライト アセンブリをコピーします。 | True |
| 参照アセンブリの出力 | True |
| ライブラリの依存関係のリンク | False |
| リンク ライブラリの依存関係の入力 | False |

### <a name="configure-the-packaging-project"></a>パッケージの project を構成します。

パッケージ プロジェクトで、**[アプリケーション]** フォルダーを右クリックして **[参照の追加]** を選びます。

![プロジェクト参照の追加](images/desktop-to-uwp/add-reference-packaging-project.png)

Shim 起動ツールのプロジェクトと、デスクトップ アプリケーションのプロジェクトを選択し、 **[OK** ] をクリックします。

![デスクトップ プロジェクト](images/desktop-to-uwp/package-project-references.png)

>[!NOTE]
> ソース コード アプリケーションをお持ちでない場合だけ shim 起動ツールのプロジェクトを選択します。 構成ファイルを作成するときに、実行可能ファイルを参照する方法を紹介します。

[**アプリケーション**] ノードでは、shim 起動ツール、アプリケーションを右クリックし、[**エントリ ポイントとして設定**] を選びます。

![エントリ ポイントの設定](images/desktop-to-uwp/set-startup-project.png)

という名前のファイルを追加する``config.json``パッケージ プロジェクトにコピーし、ファイルに次の json テキストを貼り付けます。 **コンテンツ**を**パッケージのアクション**のプロパティを設定します。

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
各キーの値を指定します。 ガイドとしては、次の表を使用します。

| 配列 | key | 値 |
|-------|-----------|-------|
| applications | id |  値を使用して、`Id`の属性、`Application`パッケージ マニフェストの要素。 |
| applications | 実行可能ファイル | 開始する実行可能ファイルへのパッケージの相対パス。 ほとんどの場合、それを変更する前にパッケージ マニフェスト ファイルからこの値を得るができます。 値は、`Executable`の属性、`Application`要素。 |
| applications | 作業ディレクトリ | (オプション)作業を開始するディレクトリとして使用するパッケージの相対パス。 オペレーティング システムを使用して、この値を設定しない場合、`System32`ディレクトリをアプリケーションの作業のディレクトリです。 |
| プロセス | 実行可能ファイル | ほとんどの場合の名前になります、`executable`上にある削除パスとファイル拡張子のように構成されています。 |
| shim | dll | Shim 読み込む DLL パッケージの相対パス。 |
| shim | 構成 | (オプション)Shim dl の動作を制御します。 この値の正確な形式は、各 shim できる解釈"blob"必要があると shim-によって-shim ごとに異なります。 |

完了したら、ときに、``config.json``ファイルは次のようになります。

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
> `applications`、 `processes`、および`shims`キーは、配列します。 つまり、1 つ以上のアプリケーション、プロセス、および shim DLL を指定する config.json ファイルを使用することができます。

### <a name="debug-a-runtime-fix"></a>実行時の修正プログラムをデバッグします。

Visual Studio では、[デバッガーを開始する F5 キーを押します。  最初を起動するをターゲット デスクトップ アプリケーションを起動でき、shim 起動ツールのアプリケーションします。  対象のデスクトップ アプリケーションをデバッグするには、**デバッグ**を選択して、手動でデスクトップ アプリケーションのプロセスにアタッチする必要があります->**プロセスにアタッチ**、およびアプリケーションの処理] をクリックします。 ネイティブ ランタイム修正 DLL .NET アプリケーションのデバッグ時に、(混在モード デバッグ) の管理とネイティブ コードの種類を選択します。  

これ設定したら、デスクトップ アプリケーションのコードとランタイム fix プロジェクトでのコード行の横にある破断点を設定できます。 ソース コード アプリケーションを持っていない場合は、ランタイム fix プロジェクト内のコード行の横にある破断点を設定することができます。

>[!NOTE]
> Visual Studio を使用する最も簡単な開発おりエクスペリエンスをデバッグするには、いくつかの制限がありますが、このガイドの後でについて説明します適用できるその他のデバッグ手法。

## <a name="create-a-runtime-fix"></a>実行時の修正プログラムを作成します。

ランタイム修正問題を解決することは、代わりの機能を作成し、構成データを含む新しいランタイム修正を作成することができますがまだ存在しない場合は合理的です。 各部分を見てみましょう。

### <a name="replacement-functions"></a>代わりの機能

最初に、MSIX コンテナーにアプリケーションの実行時に呼び出しが失敗する関数を特定します。 次に、代わりにランタイム マネージャーを置換関数を作成できます。 これではモダンなランタイム環境のルールに準拠する動作を関数の実装を置き換えることができます。

Visual Studio では、このガイドの以前のバージョンで作成したランタイム fix プロジェクトを開きます。

宣言、``SHIM_DEFINE_EXPORTS``マクロ用に含める文を追加して、`shim_framework.h`それぞれの上部にあります。CPP ファイルが、実行時の修正プログラムの機能を追加します。

```c++
#define SHIM_DEFINE_EXPORTS
#include <shim_framework.h>
```
>[!IMPORTANT]
>確認、`SHIM_DEFINE_EXPORTS`含めるステートメントの前にマクロが表示されます。

関数は、関数の同じ署名を作成できるユーザーは動作を変更します。 ここを置き換える関数の例では、`MessageBoxW`関数。

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

通話を`DECLARE_SHIM`マップ、`MessageBoxW`関数は、新しい置換関数にします。 アプリケーションが通話しようとしたときに、`MessageBoxW`関数、関数を代わりに発信ことはできます。

#### <a name="protect-against-recursive-calls-to-functions-in-runtime-fixes"></a>再帰ランタイム修正における関数呼び出しから保護します。

適用することができます (オプション)、`reentrancy_guard`再帰ランタイム修正における関数呼び出しを保護する関数を入力します。

関数の値を置換を作成するなど、`CreateFile`関数。 実装を呼び出す、`CopyFile`の実装、`CopyFile`関数を呼び出す、`CreateFile`関数します。 呼び出しを無限再帰サイクルに生じる、`CreateFile`関数。

ついて詳しくは`reentrancy_guard` [authoring.md](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/Authoring.md)を参照してください。

### <a name="configuration-data"></a>データの構成

ランタイム修正に構成のデータを追加する場合に追加することを検討してください、``config.json``します。 使用するようにすると、`ShimQueryCurrentDllConfig`を簡単にそのデータを分析します。 この例では、その構成ファイルからブール値、文字列値を解析します。

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

## <a name="other-debugging-techniques"></a>その他の手法をデバッグ

Visual Studio を使用すると、最も簡単な開発およびデバッグ時のエクスペリエンス、中にいくつかの制限があります。

最初に、f5 キーを押してデバッグと、.appx パッケージからインストールするのではなく、パッケージ レイアウト フォルダーのパスから柔軟なファイルを展開するアプリケーションを実行します。  [レイアウト] フォルダー通常がない同じセキュリティ制限インストール パッケージのフォルダーとします。 その結果、してできないことがありますランタイムの修正プログラムを適用するよりも前のパッケージ パス アクセス拒否エラーを再現します。

この問題に対処するには、f5 キーを押して柔軟なファイルの展開ではなく、.appx パッケージの展開を使用します。  .Appx パッケージ ファイルを作成するには、上記のように Windows SDK から[MakeAppx](https://docs.microsoft.com/en-us/windows/desktop/appxpkg/make-appx-package--makeappx-exe-)ユーティリティを使用します。 またはから、Visual Studio 内アプリケーション プロジェクト ノードを右クリックして**ストア**を選択して->**アプリ パッケージを作成**します。

Visual Studio の別の問題は、デバッガーが起動されるすべての子プロセスにアタッチするための組み込みのサポートがないことができます。   関連付ける必要があります手動で Visual Studio で起動した後、ターゲット アプリケーションの起動パスのロジックをデバッグする困難になります。

この問題を解決するには、使用子プロセスをサポートしているデバッガーを添付します。  一般的に対象のアプリケーションにだけの時間 (JIT) デバッガーを添付することに注意してください。  これは、ほとんど JIT 技法 ImageFileExecutionOptions のレジストリ キーを使用して、ターゲット アプリケーションの代わりにデバッガーを起動するためです。  ターゲット アプリケーションに ShimRuntime.dll を挿入する ShimLauncher.exe で使用される detouring メカニズムこの無効になります。  サポート子プロセスを添付する WinDbg、 [Windows 用デバッグ ツール](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/index)に含まれているし、 [Windows SDK](https://developer.microsoft.com/en-US/windows/downloads/windows-10-sdk)から取得します。  また、サポート直接[を起動して UWP のアプリをデバッグ](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/debugging-a-uwp-app-using-windbg#span-idlaunchinganddebuggingauwpappspanspan-idlaunchinganddebuggingauwpappspanspan-idlaunchinganddebuggingauwpappspanlaunching-and-debugging-a-uwp-app)します。

子プロセスとしてターゲット アプリケーションの起動をデバッグするには、開始``WinDbg``します。

```
windbg.exe -plmPackage PSFSampleWithFixup_1.0.59.0_x86__7s220nvg1hg3m -plmApp PSFSample
```

``WinDbg``メッセージを表示する、子デバッグを有効化および適切なブレークポイントを設定します。

```
.childdbg 1
g
```
(実行ターゲット アプリケーションを起動して、改ページになるまで)

```
sxe ld fixup.dll
g
```
(実行が読み込ま修正まで)

```
bp ...
```

>[!NOTE]
> [PLMDebug](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/plmdebug)がデバッガー起動時には、アプリにも使用でき、 [Windows 用デバッグ ツール](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/index)にも含まれています。  ただしは、WinDbg によって提供されるようになりました直接サポートよりも複雑です。

## <a name="support-and-feedback"></a>サポートとフィードバック

**質問に対する回答を見つける**

ご質問がある場合は、 Stack Overflow でお問い合わせください。 Microsoft のチームでは、これらの[タグ](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge)をチェックしています。 [こちら](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D)から質問することもできます。
