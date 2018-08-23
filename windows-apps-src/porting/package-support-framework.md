---
author: normesta
Description: Fix issues that prevent your desktop application from running in an MSIX container
Search.Product: eADQiWindows 10XVcnh
title: MSIX コンテナーで実行してから、デスクトップのアプリケーションを妨げる問題を修正します。
ms.author: normesta
ms.date: 07/02/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 46d5705233af9e8254b9ac89a2d6e9891e90701f
ms.sourcegitcommit: 9c79fdab9039ff592edf7984732d300a14e81d92
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/23/2018
ms.locfileid: "2815514"
---
# <a name="apply-runtime-fixes-to-an-msix-package-by-using-the-package-support-framework"></a>MSIX パッケージにパッケージのサポートのフレームワークを使用して、実行時の修正プログラムを適用します。

パッケージのサポート、フレームワークは、修正を適用、既存の win32 アプリケーション、ソース コードへのアクセスがないとき MSIX コンテナーで実行できるようにするために役立つオープン ソースのキットです。 パッケージのサポート、フレームワークは、アプリケーションの最新のランタイム環境のベスト プラクティスに従うことができます。

パッケージ サポート フレームワークを作成するには、[回り道](https://www.microsoft.com/en-us/research/project/detours)テクノロジによって、Microsoft の研究 (MSR) を開発、オープン ソースのフレームワークと API のリダイレクトのフックを活用できます。

このフレームワークは、オープン ソース、軽量、アプリケーションの問題に対処する簡単に使用できます。 、世界のコミュニティに相談して、他の投資の上に構築する機会も提供します。

## <a name="a-quick-look-inside-of-the-package-support-framework"></a>パッケージ サポート フレームワーク内で簡単に説明

パッケージ サポート フレームワークには、実行可能ファイル、実行時マネージャー DLL、および実行時の修正モジュールが含まれています。

![パッケージ サポート フレームワーク](images/desktop-to-uwp/package-support-framework.png)

しくみは次のとおりです。 アプリケーションに適用する fix(s) を指定する構成ファイルを作成します。 その後、シム起動プログラムの実行可能ファイルを指すように、パッケージを変更してみましょう。

ユーザーがアプリケーションを起動するとシム起動プログラムを実行する最初の実行可能ファイルです。 構成ファイルを読み取りし、ランタイム fix(s) とランタイム マネージャー DLL をアプリケーションのプロセスに挿入します。

![パッケージ サポート フレームワークの DLL インジェクション](images/desktop-to-uwp/package-support-framework-2.png)

ランタイム マネージャーでは、MSIX、コンテナーの内部で実行するアプリケーションで必要な場合にこの修正プログラムが適用されます。

このガイドは、アプリケーション互換性の問題を識別するには役立ち、それらに対処する修正を検索して、このオプションを適用すると、ランタイムを拡張します。

<a id="identify" />

## <a name="identify-packaged-application-compatibility-issues"></a>パッケージ化されたアプリケーション互換性問題を特定します。

最初に、アプリケーションのパッケージを作成します。 それをインストール、実行し、その動作を観察します。 互換性の問題の特定に役立つエラー メッセージが表示されます可能性があります。 [プロセス モニター](https://docs.microsoft.com/en-us/sysinternals/downloads/procmon)は、問題を特定するのにも使用できます。  一般的な問題は、作業ディレクトリとプログラムのパスのアクセス許可に関する暫定要素をアプリケーションに関連します。

### <a name="using-process-monitor-to-identify-an-issue"></a>プロセス モニターを使用して問題を識別するには

[プロセス モニター](https://docs.microsoft.com/en-us/sysinternals/downloads/procmon)は、アプリケーションのファイルとレジストリの操作とその結果を観察するための強力なユーティリティです。  アプリケーションの互換性の問題を理解することができます。  プロセス モニターを開くには、フィルターを追加します (フィルター > フィルター...) にアプリケーションの実行可能ファイルからのイベントのみが含まれます。

![ProcMon のアプリケーション フィルター](images/desktop-to-uwp/procmon_app_filter.png)

イベントの一覧が表示されます。 これらのイベントの多くにとって、単語**の成功**が表示されます [**結果**] 列で。

![ProcMon のイベント](images/desktop-to-uwp/procmon_events.png)

オプションでのみエラーだけを表示するイベントをフィルター処理できます。

![ProcMon の除外の成功](images/desktop-to-uwp/procmon_exclude_success.png)

ファイル ・ システム ・ アクセスの障害が疑われる場合は、[System32/SysWOW64] または [パッケージ ファイルのパスが失敗したイベントを検索します。 フィルターにも役立ちます、すぎます。 このリストの下部に起動し、上方向にスクロールします。 このリストの下部に表示されたエラーが最近発生しています。 エラー「アクセスが拒否されると、」などの文字列が含まれていると「のパスと名前が見つかりません」、ほとんどの注意を払うし、不審な外観がないことを無視します。 [PSFSample](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/samples/PSFSample/)では、2 つの問題があります。 次の図に表示される一覧でそれらの問題を確認できます。

![ProcMon Config.txt](images/desktop-to-uwp/procmon_config_txt.png)

このイメージに表示される最初の問題、アプリケーションは、"C:\Windows\SysWOW64"のパスにある"Config.txt"ファイルからの読み取りに失敗しています。 アプリケーションがそのパスを直接参照しようとしている可能性が高いことはできません。 、相対パスを使用してそのファイルを読み書きしようとして、"System32/SysWOW64"は、アプリケーションの作業ディレクトリを既定では、ほとんどの場合、です。 これは、アプリケーションがパッケージのどこかに設定する、現在の作業ディレクトリを待っていることを示しています。 Appx の内部で見ると、実行可能ファイルと同じディレクトリにファイルが存在することを確認できます。

![アプリ Config.txt](images/desktop-to-uwp/psfsampleapp_config_txt.png)

2 番目の問題は、次の図に表示されます。

![ProcMon のログ ファイル](images/desktop-to-uwp/procmon_logfile.png)

この問題では、アプリケーションは、そのパッケージのパスに .log ファイルを書き込むに失敗しています。 ファイルのリダイレクトの shim が役立つ場合がありますこれを推奨します。

<a id="find" />

## <a name="find-a-runtime-fix"></a>実行時の修正プログラムを検索します。

PSF には、ファイルのリダイレクトのシムなど今すぐに使用できるランタイムの修正プログラムが含まれています。

### <a name="file-redirection-shim"></a>ファイルのリダイレクトのシム

書き込みまたは MSIX コンテナーで実行されるアプリケーションからアクセス可能ではないディレクトリ内のデータの読み取りの試行をリダイレクトするのには、[ファイルのリダイレクトの Shim](https://github.com/Microsoft/MSIX-PackageSupportFramework/tree/develop/FileRedirectionShim)を使用できます。

などの場合は、アプリケーション、アプリケーションの実行可能ファイルと同じディレクトリにあるログ ファイルに書き込むと、ローカル アプリケーションのデータ ストアなど、別の場所にログ ファイルを作成する[ファイルのリダイレクトの Shim](https://github.com/Microsoft/MSIX-PackageSupportFramework/tree/develop/FileRedirectionShim)を使用できます。

### <a name="runtime-fixes-from-the-community"></a>コミュニティからの実行時の修正

[GitHub](https://github.com/Microsoft/MSIX-PackageSupportFramework/tree/develop)ページにコミュニティの貢献度を確認してください。 他の開発者が自分のような問題を解決したし、実行時の修正プログラムを共有しています。

## <a name="apply-a-runtime-fix"></a>実行時の修正プログラムを適用します。

Windows sdk、および次の手順では、いくつかの簡単なツールを使用して既存の実行時の修正を適用できます。

> [!div class="checklist"]
> * パッケージ レイアウト フォルダーを作成します。
> * パッケージ サポート フレームワーク ファイルを取得します。
> * パッケージに追加します。
> * パッケージ マニフェストの変更
> * 構成ファイルを作成します。

各タスクから見ていきましょう。

### <a name="create-the-package-layout-folder"></a>パッケージ レイアウト フォルダーを作成します。

.Appx ファイルが既にある場合場合、パッケージのステージング領域として使用するレイアウト フォルダーにその内容をアンパックすることができます。  これを行うことができます、 **x64 VS 2017 のネイティブ ツールのコマンド プロンプト**、または手動で実行可能ファイルの検索パスに、SDK の bin パスです。

```
makeappx unpack /p PSFSamplePackage_1.0.60.0_AnyCPU_Debug.appx /d PackageContents

```

これにより、次のようになります。

![パッケージ レイアウト](images/desktop-to-uwp/package_contents.png)

お持ちでない .appx ファイルで起動する場合は、最初からパッケージのフォルダーとファイルを作成できます。

### <a name="get-the-package-support-framework-files"></a>パッケージ サポート フレームワーク ファイルを取得します。

PSF Nuget のパッケージは、Visual Studio を使用して取得できます。 スタンドアロンの Nuget のコマンド ライン ツールを使用しても取得できます。

#### <a name="get-the-package-by-using-visual-studio"></a>Visual Studio を使用してパッケージを取得します。

Visual Studio では、ソリューションまたはプロジェクト ノードを右クリックし、Nuget パッケージの管理コマンドのいずれかを選択します。  Nuget.org でパッケージを検索するには、 **Microsoft.PackageSupportFramework**または**PSF**を検索します。その後、それをインストールします。

#### <a name="get-the-package-by-using-the-command-line-tool"></a>コマンド ライン ツールを使用してパッケージを取得します。

この場所から、Nuget のコマンド ライン ツールをインストールする: https://www.nuget.org/downloads。 Nuget のコマンド ・ ラインからは、このコマンドを実行します。

```
nuget install Microsoft.PackageSupportFramework
```

### <a name="add-the-package-support-framework-files-to-your-package"></a>パッケージ サポート フレームワーク ファイルをパッケージに追加します。

パッケージ ディレクトリに必要な 32 ビットおよび 64 ビットの PSF Dll や実行可能ファイルを追加します。 次の表をガイドとして使用してください。 する必要がある、実行時の修正が含まれてもします。 この例では、ファイルのリダイレクトの実行時の修正プログラムが必要です。

| アプリケーション実行可能ファイルは、x64 です。 | アプリケーション実行可能ファイルは、x86 です。 |
|-------------------------------|-----------|
| [ShimLauncher64.exe](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/ShimLauncher/readme.md) |  [ShimLauncher32.exe](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/ShimLauncher/readme.md) |
| [ShimRuntime64.dll](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/ShimRuntime/readme.md) | [ShimRuntime32.dll](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/ShimRuntime/readme.md) |
| [ShimRunDll64.exe](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/ShimRunDll/readme.md) | [ShimRunDll32.exe](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/ShimRunDll/readme.md) |

パッケージの内容は次のようになります。

![パッケージのバイナリ](images/desktop-to-uwp/package_binaries.png)

### <a name="modify-the-package-manifest"></a>パッケージ マニフェストの変更

テキスト エディターで、パッケージ マニフェストを開き、設定し、`Executable`の属性、`Application`シム起動プログラムの実行可能ファイルの名前の要素です。  ターゲット アプリケーションのアーキテクチャがわかっている場合は、ShimLauncher32.exe または ShimLauncher64.exe は、適切なバージョンを選択します。  いない場合は、ShimLauncher32.exe は常に動作します。  次に例を示します。

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

ファイル名を作成する``config.json``、パッケージのルート フォルダーにそのファイルを保存するとします。 交換した実行可能ファイルを指すように config.json ファイルの宣言されたアプリケーション ID を変更します。 プロセス モニターを使用してから増加した知識を活用するとすることも作業ディレクトリを設定、および相対パッケージの"PSFSampleApp"ディレクトリの下の .log ファイルに読み取り/書き込みをリダイレクトするのには、ファイルのリダイレクトの shim を使用します。

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
以下は、config.json スキーマのためのガイドです。

| 配列 | key | 値 |
|-------|-----------|-------|
| applications | id |  値を使用して、`Id`の属性、`Application`パッケージ マニフェスト内の要素。 |
| applications | 実行可能 | 起動する実行可能ファイルへのパッケージの相対パス。 ほとんどの場合、それを変更する前に、パッケージ マニフェスト ファイルからこの値を取得できます。 値は、`Executable`の属性、`Application`要素です。 |
| applications | 作業ディレクトリ | (省略可能)起動するアプリケーションの作業ディレクトリとして使用するパッケージの相対パスです。 オペレーティング システムを使用してこの値を設定しない場合、`System32`ディレクトリをアプリケーションの作業ディレクトリです。 |
| プロセス | 実行可能 | ほとんどの場合の名前になります、`executable`を削除するパスとファイルの拡張子を持つ上に構成されています。 |
| shim | dll | ロードする shim .appx パッケージの相対パスです。 |
| shim | 構成 | (省略可能)シム配布リストの動作方法を制御します。 この値の正確な形式は、各シムはこの"blob"を解釈できる必要があるようにシム ・によって・ シムごとに異なります。 |

`applications`、`processes`と`shims`は、キーの配列。 つまり、1 つ以上のアプリケーション、プロセス、および shim DLL を指定する config.json ファイルを使用することができます。


### <a name="package-and-test-the-app"></a>パッケージとアプリケーションのテスト

次に、パッケージを作成します。

```
makeappx pack /d PackageContents /p PSFSamplePackageFixup.appx
```

その後、それに署名します。

```
signtool sign /a /v /fd sha256 /f ExportedSigningCertificate.pfx PSFSamplePackageFixup.appx
```

詳細については、[署名証明書のパッケージを作成する方法](https://docs.microsoft.com/en-us/windows/desktop/appxpkg/how-to-create-a-package-signing-certificate)と、 [signtool を使用してパッケージに署名する方法](https://docs.microsoft.com/en-us/windows/desktop/appxpkg/how-to-sign-a-package-using-signtool)を参照してください。

PowerShell を使用して、パッケージをインストールします。

>[!NOTE]
> 最初にパッケージをアンインストールしてください。

```
powershell Add-AppxPackage .\PSFSamplePackageFixup.appx
```

アプリケーションを実行し、実行時の修正プログラムが適用されると動作を確認します。  診断し、必要に応じてパッケージ化の手順を繰り返します。

### <a name="use-the-trace-shim"></a>トレースの Shim を使用します。

パッケージ化されたアプリケーションの互換性の問題を診断するために別の方法では、トレースの Shim を使用します。 この DLL は、PSF に含まれてであり、プロセスのモニターのようなアプリケーションの動作の詳細な診断ビューを提供します。  アプリケーションの互換性の問題を明らかにするように設計します。  トレース Shim を使用してパッケージに DLL を追加、config.json では、次のフラグメントに追加とパッケージ化し、アプリケーションをインストールします。

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

既定では、トレースのシムの「予測」と考えられる障害が除外されます。  たとえば、アプリケーションは、無条件に既に存在するかどうか、結果を無視するかを確認するためにファイルを削除するのにはしようと可能性があります。 ファイルシステム関数からすべてのエラーを受信するを選択して上記の例では、いくつかの予期しないエラー可能性があります取得除外、残念な結果があります。 その前に Config.txt ファイルからの読み取りに失敗すると、メッセージ「ファイルが見つかりません」とからわかっているのでこれを行います。 これは、エラーが頻繁に発生しは、一般に予測不可能であると仮定します。 実習では、予期しない障害が発生するだけでフィルタ リングし、フォールバックで発生するすべての障害も識別できない問題がある場合は、最初に可能性が高い最高を勧めします。

既定では、トレースのシムからの出力は、アタッチされたデバッガーに送信されます。 この例では、デバッガーをアタッチしようとしていないは代わりにプログラムを使用して[デバッグ表示](https://docs.microsoft.com/en-us/sysinternals/downloads/debugview)SysInternals から出力を表示します。 アプリケーションを実行すると、わかります同じ障害前とに、同じ実行時の修正プログラムの方にごポイントを。

![TraceShim ファイルが見つかりませんでした。](images/desktop-to-uwp/traceshim_filenotfound.png)

![TraceShim のアクセスが拒否されました](images/desktop-to-uwp/traceshim_accessdenied.png)

## <a name="debug-extend-or-create-a-runtime-fix"></a>デバッグ、拡張、または実行時の修正プログラムを作成

Visual Studio を使用するには実行時の修正プログラムのデバッグ、拡張の実行時の修正プログラム、または最初から作成します。 これらが成功するために対処する必要があります。

> [!div class="checklist"]
> * プロジェクトのパッケージング」を追加します。
> * この修正プログラム実行時にプロジェクトを追加します。
> * Shim の起動ツール実行可能ファイルを起動するプロジェクトを追加します。
> * パッケージ プロジェクトを構成します。

設定が完了したら、ソリューションは次のようです。

![完成したソリューション](images/desktop-to-uwp/runtime-fix-project-structure.png)

この例では、各プロジェクトを見てみましょう。

| プロジェクト | 目的 |
|-------|-----------|
| DesktopApplicationPackage | このプロジェクトは、 [Windows アプリケーションのパッケージ化のプロジェクト](desktop-to-uwp-packaging-dot-net.md)に基づいて、出力、MSIX パッケージです。 |
| Runtimefix | これは、C++ の Dynamic-Linked ライブラリを含むプロジェクトを実行時の修正プログラムとして機能する 1 つまたは複数の交換機能です。 |
| ShimLauncher | これは、C++ の空のプロジェクトです。 このプロジェクトは、パッケージのサポート フレームワークのランタイムの配布可能なファイルを収集する場所です。 実行可能ファイルを出力します。 その実行可能ファイルは、最初にソリューションを起動するときに実行されることです。 |
| WinFormsDesktopApplication | このプロジェクトには、デスクトップ アプリケーションのソース コードが含まれています。 |

これらの種類のプロジェクトのすべてを含む完全なサンプルを見ると、 [PSFSample](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/samples/PSFSample/)を参照してください。

作成し、ソリューション内の各プロジェクトを構成する手順を説明しましょう。


### <a name="create-a-package-solution"></a>パッケージ ソリューションを作成します。

デスクトップ アプリケーションのソリューションがない場合は、Visual Studio で新しい**空のソリューション**を作成します。

![空のソリューション](images/desktop-to-uwp/blank-solution.png)

持つ任意のアプリケーション プロジェクトを追加することもできます。

### <a name="add-a-packaging-project"></a>プロジェクトのパッケージング」を追加します。

既に**Windows アプリケーション プロジェクトのパッケージング**をお持ちでない場合は、1 つを作成し、ソリューションに追加します。

![パッケージのプロジェクト テンプレート](images/desktop-to-uwp/package-project-template.png)

Windows アプリケーションのパッケージ化プロジェクトの詳細については、 [Visual Studio を使用してアプリケーションのパッケージ](desktop-to-uwp-packaging-dot-net.md)を参照してください。

**ソリューション エクスプ ローラー**でパッケージ プロジェクトを右クリックし、**編集**を選択し、プロジェクト ファイルの末尾に追加。

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

### <a name="add-project-for-the-runtime-fix"></a>この修正プログラム実行時にプロジェクトを追加します。

**ダイナミック リンク ライブラリ (DLL)** の C++ プロジェクトをソリューションに追加します。

![実行時の修正プログラム ライブラリ](images/desktop-to-uwp/runtime-fix-library.png)

[プロジェクト]、[**プロパティ**を右クリックします。

プロパティ ページ] で、 **C++ 言語の標準**のフィールドを見つけて、そのフィールドの横のドロップダウン リスト、選択、 **ISO c 17 標準 (/std:c では 17)** オプションです。

![ISO 17 オプション](images/desktop-to-uwp/iso-option.png)

そのプロジェクトを右クリックし、コンテキスト メニューで、 **Nuget パッケージの管理**] オプションを選択します。 **Nuget.org**または**すべて**に、[**パッケージ ソース**] オプションが設定されていることを確認します。

次にそのフィールドの設定] アイコンをクリックします。

*PSF*の検索 * Nuget パッケージ、および、それをこのプロジェクトをインストールします。

![nuget パッケージ](images/desktop-to-uwp/psf-package.png)

デバッグまたは既存の実行時の修正プログラムを拡張する場合は、説明されているガイダンスを使用して、このガイドの「[実行時の修正プログラムを検索](#find)して取得したランタイムの修正プログラム ファイルを追加します。

新しい修正プログラムを作成する場合は、追加しない何もこのプロジェクトにまだです。 ことができますこのガイドの後でこのプロジェクトにファイルを追加します。 ここでは、ソリューションのセットアップをいく予定です。

### <a name="add-a-project-that-starts-the-shim-launcher-executable"></a>Shim の起動ツール実行可能ファイルを起動するプロジェクトを追加します。

**空のプロジェクト**の C++ プロジェクトをソリューションに追加します。

![空のプロジェクト](images/desktop-to-uwp/blank-app.png)

前のセクションで説明されている同じガイドを使用して、このプロジェクトに**PSF** Nuget パッケージを追加します。

開く**全般**の設定] ページで、プロジェクトのプロパティ ページ**名のターゲット**プロパティを設定します``ShimLauncher32``または``ShimLauncher64``、アプリケーションのアーキテクチャに依存します。

![シム起動ツールの参照](images/desktop-to-uwp/shim-exe-reference.png)

ソリューションの実行時の修正プログラムのプロジェクトへのプロジェクト参照を追加します。

![実行時の修正プログラムの参照](images/desktop-to-uwp/reference-fix.png)

参照を右クリックし、 **[プロパティ**] ウィンドウでこれらの値を適用します。

| プロパティ | 値 |
|-------|-----------|-------|
| ローカル コピーします。 | True |
| ローカルのサテライト アセンブリをコピーします。 | True |
| 参照アセンブリの出力 | True |
| リンク ライブラリの依存関係 | False |
| リンク ライブラリの依存関係の入力 | False |

### <a name="configure-the-packaging-project"></a>パッケージ プロジェクトを構成します。

パッケージ プロジェクトで、**[アプリケーション]** フォルダーを右クリックして **[参照の追加]** を選びます。

![プロジェクト参照の追加](images/desktop-to-uwp/add-reference-packaging-project.png)

シム起動プログラムのプロジェクトと、デスクトップ アプリケーションのプロジェクトを選択し、 **[OK** ] ボタンをクリックします。

![デスクトップ プロジェクト](images/desktop-to-uwp/package-project-references.png)

>[!NOTE]
> ソース コードをアプリケーションをお持ちでない場合シム起動プログラムのプロジェクトを選択するだけです。 構成ファイルを作成するときに、実行可能ファイルを参照する方法紹介します。

**アプリケーション**] ノードで shim の起動プログラム アプリケーションを右クリックし、**エントリ ポイントとして設定**します。

![エントリ ポイントの設定](images/desktop-to-uwp/set-startup-project.png)

という名前のファイルを追加する``config.json``をパッケージ化プロジェクトにコピーし、次の json 文字列をファイルに貼り付けます。 **コンテンツ**を**パッケージの Action**プロパティを設定します。

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
各キーの値を提供します。 このテーブルをガイドとして使用します。

| 配列 | key | 値 |
|-------|-----------|-------|
| applications | id |  値を使用して、`Id`の属性、`Application`パッケージ マニフェスト内の要素。 |
| applications | 実行可能 | 起動する実行可能ファイルへのパッケージの相対パス。 ほとんどの場合、それを変更する前に、パッケージ マニフェスト ファイルからこの値を取得できます。 値は、`Executable`の属性、`Application`要素です。 |
| applications | 作業ディレクトリ | (省略可能)起動するアプリケーションの作業ディレクトリとして使用するパッケージの相対パスです。 オペレーティング システムを使用してこの値を設定しない場合、`System32`ディレクトリをアプリケーションの作業ディレクトリです。 |
| プロセス | 実行可能 | ほとんどの場合の名前になります、`executable`を削除するパスとファイルの拡張子を持つ上に構成されています。 |
| shim | dll | Shim DLL を読み込むパッケージの相対パスです。 |
| shim | 構成 | (省略可能)シム配布リストの動作方法を制御します。 この値の正確な形式は、各シムはこの"blob"を解釈できる必要があるようにシム ・によって・ シムごとに異なります。 |

、終わったときに、``config.json``ファイルは次のようになります。

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
> `applications`、`processes`と`shims`は、キーの配列。 つまり、1 つ以上のアプリケーション、プロセス、および shim DLL を指定する config.json ファイルを使用することができます。

### <a name="debug-a-runtime-fix"></a>実行時の修正プログラムをデバッグします。

Visual Studio は、デバッガーを起動するのには f5 キーを押します。  最初に起動することは、次に、ターゲット、デスクトップ アプリケーションを起動する shim のランチャー アプリケーションです。  対象のデスクトップ アプリケーションをデバッグするには、**デバッグ**を選択することによって、デスクトップ アプリケーションのプロセスに手動でアタッチする必要があります->**プロセスにアタッチ**し、アプリケーションの処理] をクリックします。 ネイティブ ランタイム修正 DLL を .NET アプリケーションのデバッグを許可するには、マネージ コードとネイティブ コードの種類 (混合モードのデバッグ) を選択します。  

これ設定したら、デスクトップ アプリケーションのコードと実行時の修正プログラムのプロジェクトでのコード行の横にあるブレーク ・ ポイントを設定できます。 ソース コードをアプリケーションをお持ちでない場合、実行時の修正プログラムのプロジェクトでのコード行の横にあるブレーク ・ ポイントを設定することができます。

>[!NOTE]
> Visual Studio を使用する最も簡単な開発エクスペリエンスをデバッグするには、いくつかの制限がある中、このガイドの後でについて説明しますその他のデバッグ手法を適用することができます。

## <a name="create-a-runtime-fix"></a>実行時の修正プログラムを作成します。

ランタイムの修正の問題を解決する場合、交換用の関数を作成し、任意の構成データを含む新しいランタイムの修正プログラムを作成することができますがない場合は合理的です。 各部分を見てみましょう。

### <a name="replacement-functions"></a>置換機能

MSIX コンテナーでアプリケーションを実行するときに、呼び出しが失敗する関数を最初に、特定するには。 代わりにランタイム マネージャーを希望する交換用関数を作成できます。 これは、最新のランタイム環境の規則に準拠した動作と関数の実装を置き換えることを示します。

Visual Studio は、このガイドの前半で作成したランタイムの修正プログラムのプロジェクトを開きます。

宣言、``SHIM_DEFINE_EXPORTS``マクロ用の include ステートメントを追加し、`shim_framework.h`それぞれの上部にあります。CPP ファイルが、実行時の修正プログラムの機能を追加する対象となります。

```c++
#define SHIM_DEFINE_EXPORTS
#include <shim_framework.h>
```
>[!IMPORTANT]
>確認、 `SHIM_DEFINE_EXPORTS` 、include ステートメントの前にマクロが表示されます。

同じ関数のシグネチャを持つ関数を作成したが動作を変更します。 置換する関数の例をここでは、`MessageBoxW`関数です。

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

呼び出し`DECLARE_SHIM`マップ、 `MessageBoxW` 、新しい置換関数への関数です。 アプリケーションが呼び出すしようとしたとき、`MessageBoxW`関数、その関数を呼び出す、交換代わりにします。

#### <a name="protect-against-recursive-calls-to-functions-in-runtime-fixes"></a>修正を実行時に関数の再帰呼び出しを防ぐ

必要に応じて適用することができます、`reentrancy_guard`修正を実行時に関数の再帰呼び出しを保護する、関数をタイプします。

交換用の関数を作成するなど、`CreateFile`関数です。 実装を呼び出すことがあります、`CopyFile`の実装、`CopyFile`関数を呼び出す可能性があります、`CreateFile`関数です。 無限の再帰的なサイクルへの呼び出しのため、`CreateFile`関数です。

詳細については`reentrancy_guard` [authoring.md](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/Authoring.md)を参照してください。

### <a name="configuration-data"></a>構成データ

構成データ、実行時の修正プログラムを追加する場合は、追加することを検討してください、 ``config.json``。 そうすることが使うことができます、`ShimQueryCurrentDllConfig`に簡単にそのデータを解析します。 この例では、その構成ファイルからのブール値、文字列の値を解析します。

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

## <a name="other-debugging-techniques"></a>その他のデバッグ手法

Visual Studio を使用すると、最も簡単な開発およびデバッグの操作性、ときに、いくつかの制限があります。

.Appx パッケージからインストールするのではなく、パッケージ レイアウト フォルダーのパスからの圧縮しないファイルを展開するアプリケーションを最初に、f5 キーを押してデバッグ実行します。  レイアウト フォルダー通常が同じセキュリティ制限パッケージがインストールされているフォルダーとします。 その結果、ある可能性がありますしない実行時の修正プログラムを適用する前にパッケージのパスのアクセス拒否のエラーを再現することです。

この問題に対処するためには、f5 キーを押して圧縮しないファイルの展開ではなく、.appx パッケージの展開を使用します。  .Appx パッケージ ファイルを作成するには、上記で説明した Windows sdk では、 [MakeAppx](https://docs.microsoft.com/en-us/windows/desktop/appxpkg/make-appx-package--makeappx-exe-)ユーティリティを使用します。 またはから Visual Studio は、内アプリケーション プロジェクト ノードを右クリックし、**選択して**、->**アプリケーションのパッケージを作成**します。

Visual Studio の別の問題は、デバッガーによって起動されるすべての子プロセスにアタッチするための組み込みサポートがないことです。   ロジックを関連付ける必要があります手動で Visual Studio を起動した後、ターゲット アプリケーションの起動パスでのデバッグが困難になります。

この問題を解決するには、サポートが子プロセスにアタッチするデバッガーを使用します。  一般に、ジャスト ・ イン ・ タイム (JIT) デバッガーをターゲット アプリケーションにアタッチすることに注意してください。  JIT のほとんどの手法は、ImageFileExecutionOptions のレジストリ キーを使用して、対象とするアプリケーションにデバッガーを起動するためです。  ShimLauncher.exe ShimRuntime.dll を対象とするアプリケーションに挿入するために使用する detouring 機構が損なわれるためです。  WinDbg は、 [Windows 用デバッグ ツール](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/index)では、含まれているし、 [Windows SDK](https://developer.microsoft.com/en-US/windows/downloads/windows-10-sdk)から取得した子プロセスをサポートしていますが接続します。  サポート直接[起動して UWP アプリケーションをデバッグ](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/debugging-a-uwp-app-using-windbg#span-idlaunchinganddebuggingauwpappspanspan-idlaunchinganddebuggingauwpappspanspan-idlaunchinganddebuggingauwpappspanlaunching-and-debugging-a-uwp-app)します。

子プロセスとターゲット アプリケーションの起動をデバッグするには、開始``WinDbg``。

```
windbg.exe -plmPackage PSFSampleWithFixup_1.0.59.0_x86__7s220nvg1hg3m -plmApp PSFSample
```

``WinDbg``メッセージを表示、子のデバッグを有効にして、適切なブレークポイントを設定します。

```
.childdbg 1
g
```
(ターゲット アプリケーションが起動し、デバッガーを中断するまで実行)

```
sxe ld fixup.dll
g
```
(フィックス アップの DLL が読み込まれるまで実行)

```
bp ...
```

>[!NOTE]
> [PLMDebug](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/plmdebug)は起動時では、アプリケーションにデバッガーをアタッチするのにも使用でき、 [Windows 用デバッグ ツール](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/index)にも含まれます。  ただし、WinDbg によって提供されるようになりました、直接サポートを使用するより複雑なです。

## <a name="support-and-feedback"></a>サポートとフィードバック

**質問に対する回答を見つける**

ご質問がある場合は、 Stack Overflow でお問い合わせください。 Microsoft のチームでは、これらの[タグ](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge)をチェックしています。 [こちら](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D)から質問することもできます。
