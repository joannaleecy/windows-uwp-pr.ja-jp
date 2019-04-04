---
Description: デスクトップ アプリケーションの MSIX コンテナーで実行を妨げる問題を修正します。
Search.Product: eADQiWindows 10XVcnh
title: デスクトップ アプリケーションの MSIX コンテナーで実行を妨げる問題を修正します。
ms.date: 07/02/2018
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 80f9c8bad9445bd9cfef9b09c00f99929fda37aa
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57590727"
---
# <a name="apply-runtime-fixes-to-an-msix-package-by-using-the-package-support-framework"></a>MSIX パッケージにパッケージのサポートのフレームワークを使用してランタイム修正プログラムを適用します。

パッケージのサポート、フレームワークは、修正プログラムを適用、既存の win32 アプリケーションに、ソース コードへのアクセス権がないときに、MSIX コンテナーで実行できるようにするのに役立つオープン ソース キット。 パッケージのサポート、フレームワークには、最新のランタイム環境のベスト プラクティスに従って、アプリケーションが役立ちます。

詳細についてを参照してください。[パッケージ サポート フレームワーク](https://docs.microsoft.com/windows/msix/package-support-framework-overview)します。

このガイドを利用するアプリケーションの互換性の問題を特定して、検索、適用、およびランタイムを拡張するには、それらに対処するを修正します。

<a id="identify" />

## <a name="identify-packaged-application-compatibility-issues"></a>パッケージ化されたアプリケーションの互換性の問題を特定します。

最初に、アプリケーションのパッケージを作成します。 その後、インストール、実行、およびその動作を確認します。 互換性に関する問題の特定に役立つエラー メッセージを表示可能性があります。 使用することも[プロセス モニター](https://docs.microsoft.com/en-us/sysinternals/downloads/procmon)の問題を特定します。  一般的な問題は、作業ディレクトリとプログラムのパスのアクセス許可に関する前提条件をアプリケーションに関連します。

### <a name="using-process-monitor-to-identify-an-issue"></a>Process Monitor を使用して、問題を識別するには

[プロセス モニター](https://docs.microsoft.com/en-us/sysinternals/downloads/procmon)はアプリのファイルとレジストリの操作とその結果を監視するための強力なユーティリティです。  アプリケーション互換性の問題を理解することができます。  Process Monitor を開いた後、フィルターの追加 (フィルター > フィルター...) アプリケーションの実行可能ファイルからのイベントのみを含めます。

![ProcMon アプリのフィルター](images/desktop-to-uwp/procmon_app_filter.png)

イベントの一覧が表示されます。 これらのイベントでは、単語の多くの**成功**に表示されます、**結果**列。

![ProcMon イベント](images/desktop-to-uwp/procmon_events.png)

必要に応じて、のみエラーのみを表示するイベントをフィルター処理することができます。

![ProcMon 除外成功](images/desktop-to-uwp/procmon_exclude_success.png)

ファイル システム アクセスの失敗を疑いがある場合は、System32/SysWOW64 またはパッケージのファイル パスのいずれかの下にある失敗したイベントを検索します。 フィルターも役立ちますここでは、すぎます。 この一覧の下部にある開始し、上方向にスクロールします。 この一覧の下部に表示されるエラーが発生した最も最近です。 "パス/名前 not found"、「アクセスが拒否されると、」などの文字列が含まれているエラーをほとんど注意し、不審な外観がないことを無視します。 [PSFSample](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/samples/PSFSample/)は 2 つの問題があります。 次の図に表示される一覧でこれらの問題が発生することができます。

![ProcMon Config.txt](images/desktop-to-uwp/procmon_config_txt.png)

このイメージに表示される最初の問題では"C:\Windows\SysWOW64"パスにある"Config.txt"ファイルを読み取るアプリケーションが失敗します。 可能性の高いアプリケーションがそのパスを直接参照しようとしていることはできません。 相対パスを使用してそのファイルから読み取るしようとして、"System32/SysWOW64"は、アプリケーションの作業ディレクトリを既定では、ほとんどの場合。 これは、アプリケーションがパッケージにどこかに設定する現在の作業ディレクトリを期待していたを示しています。 Appx、内部で見ると、実行可能ファイルと同じディレクトリにファイルが存在することを確認できます。

![アプリ Config.txt](images/desktop-to-uwp/psfsampleapp_config_txt.png)

2 つ目の問題は、次の図に表示されます。

![ProcMon ログ ファイル](images/desktop-to-uwp/procmon_logfile.png)

今月号では、そのパッケージのパスを .log ファイルを記述するアプリケーションが失敗します。 これにより、ファイル リダイレクト フィックス アップに役立つことが提案します。

<a id="find" />

## <a name="find-a-runtime-fix"></a>ランタイム修正プログラムを検索します。

PSF には、ファイルのリダイレクトの修正など、現時点で使用できるランタイム修正プログラムが含まれています。

### <a name="file-redirection-fixup"></a>ファイルのリダイレクトの修正

使用することができます、[ファイル リダイレクト Fixup](https://github.com/Microsoft/MSIX-PackageSupportFramework/tree/master/fixups/FileRedirectionFixup)しようとして書き込みまたは読み取り MSIX コンテナーで実行されるアプリケーションからアクセスできないディレクトリ内のデータをリダイレクトします。

などの場合は、アプリケーションの実行可能ファイルと同じディレクトリ内にあるログ ファイルに書き込むと、アプリケーション、しを使用できます、[ファイル リダイレクト Fixup](https://github.com/Microsoft/MSIX-PackageSupportFramework/tree/master/fixups/FileRedirectionFixup)ローカル アプリのデータ ストアなどの別の場所にそのログ ファイルを作成します。

### <a name="runtime-fixes-from-the-community"></a>コミュニティからのランタイムの修正

コミュニティの貢献を検討してください、 [GitHub](https://github.com/Microsoft/MSIX-PackageSupportFramework)ページ。 他の開発者が自分とよく似た問題が解決し、ランタイム修正プログラムを共有していることができます。

## <a name="apply-a-runtime-fix"></a>ランタイム修正プログラムを適用します。

Windows SDK から、次の手順では、いくつかの簡単なツールでの既存のランタイム修正プログラムを適用できます。

> [!div class="checklist"]
> * パッケージ レイアウト フォルダーを作成します。
> * パッケージのサポート フレームワーク ファイルを取得します。
> * パッケージに追加します。
> * パッケージ マニフェストの変更
> * 構成ファイルを作成します。

各タスクを見ていきましょう。

### <a name="create-the-package-layout-folder"></a>パッケージ レイアウト フォルダーを作成します。

.Msix (または .appx) ファイルが既にがある場合は、パッケージのステージング領域として機能するレイアウト フォルダーにその内容をアンパックすることができます。 SDK のインストール パスに基づく MakeAppx ツールを使用してコマンド プロンプトから実行することが、これは、Windows 10 PC で makeappx.exe ツールを表示します x86:。C:\Program Files (x86)\Windows Kits\10\bin\x86\makeappx.exe x64:C:\Program Files (x86)\Windows Kits\10\bin\x64\makeappx.exe

```ps
makeappx unpack /p PSFSamplePackage_1.0.60.0_AnyCPU_Debug.msix /d PackageContents

```

これが表示されます、次のようになります。

![パッケージのレイアウト](images/desktop-to-uwp/package_contents.png)

を持っていない .msix (または .appx) ファイルから始める場合は、最初からパッケージ フォルダーとファイルを作成できます。

### <a name="get-the-package-support-framework-files"></a>パッケージのサポート フレームワーク ファイルを取得します。

PSF Nuget パッケージは、スタンドアロンの Nuget コマンド ライン ツールを使用して、または Visual Studio を使用して取得できます。

#### <a name="get-the-package-by-using-the-command-line-tool"></a>コマンド ライン ツールを使用してパッケージを取得します。

この場所からの Nuget コマンド ライン ツールのインストール:https://www.nuget.org/downloadsします。 次に、Nuget コマンドラインからこのコマンドを実行します。

```ps
nuget install Microsoft.PackageSupportFramework
```

#### <a name="get-the-package-by-using-visual-studio"></a>Visual Studio を使用してパッケージを取得します。

Visual Studio で、ソリューションまたはプロジェクト ノードを右クリックし、Nuget パッケージの管理コマンドのいずれかを選択します。  検索**Microsoft.PackageSupportFramework**または**PSF** Nuget.org でパッケージを検索します。次に、インストールします。

### <a name="add-the-package-support-framework-files-to-your-package"></a>パッケージのサポート フレームワーク ファイルをパッケージに追加します。

パッケージ ディレクトリに必要な 32 ビットおよび 64 ビット PSF Dll と実行可能ファイルを追加します。 次の表をガイドとして使用してください。 含める必要があるランタイム修正する必要もあります。 この例では、ファイル リダイレクト ランタイム修正プログラムが必要です。

| アプリケーション実行可能ファイルは、x64 | アプリケーション実行可能ファイルは、x86 |
|-------------------------------|-----------|
| [PSFLauncher64.exe](https://github.com/Microsoft/MSIX-PackageSupportFramework/tree/master/PsfLauncher/readme.md) |  [PSFLauncher32.exe](https://github.com/Microsoft/MSIX-PackageSupportFramework/tree/master/PsfLauncher/readme.md) |
| [PSFRuntime64.dll](https://github.com/Microsoft/MSIX-PackageSupportFramework/tree/master/PsfRuntime/readme.md) | [PSFRuntime32.dll](https://github.com/Microsoft/MSIX-PackageSupportFramework/tree/master/PsfRuntime/readme.md) |
| [PSFRunDll64.exe](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/PsfRunDll/readme.md) | [PSFRunDll32.exe](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/PsfRunDll/readme.md) |

パッケージの内容は次のようになります。

![パッケージのバイナリ](images/desktop-to-uwp/package_binaries.png)

### <a name="modify-the-package-manifest"></a>パッケージ マニフェストの変更

テキスト エディターで、パッケージ マニフェストを開き、設定し、`Executable`の属性、`Application`要素 PSF 起動ツールの実行可能ファイルの名前にします。  ターゲット アプリケーションのアーキテクチャがわかっている場合は、PSFLauncher32.exe または PSFLauncher64.exe は、適切なバージョンを選択します。  ない場合は、PSFLauncher32.exe は常に動作します。  次に例を示します。

```xml
<Package ...>
  ...
  <Applications>
    <Application Id="PSFSample"
                 Executable="PSFLauncher32.exe"
                 EntryPoint="Windows.FullTrustApplication">
      ...
    </Application>
  </Applications>
</Package>
```

### <a name="create-a-configuration-file"></a>構成ファイルを作成します。

ファイル名を作成``config.json``パッケージのルート フォルダーにそのファイルを保存します。 交換した実行可能ファイルをポイントする config.json ファイルの宣言されたアプリ ID を変更します。 Process Monitor を使用してから、獲得した知識を使用して、することができますも作業ディレクトリの設定だけでなくファイル リダイレクト フィックス アップを使用してパッケージ相対"PSFSampleApp"ディレクトリの下の .log ファイルに読み取り/書き込みをリダイレクトします。

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
            "fixups": [
                {
                    "dll": "FileRedirectionFixup.dll",
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

Config.json スキーマのためのガイドを次に示します。

| 配列 | key | Value |
|-------|-----------|-------|
| applications | id |  値を使用して、`Id`の属性、`Application`パッケージ マニフェスト内の要素。 |
| applications | 実行可能ファイル | 開始する実行可能ファイルへのパッケージの相対パス。 ほとんどの場合、変更する前に、パッケージ マニフェスト ファイルからこの値を取得できます。 値は、`Executable`の属性、`Application`要素。 |
| applications | WorkingDirectory | (省略可能)起動するアプリケーションの作業ディレクトリとして使用するパッケージの相対パス。 オペレーティング システムを使用して、この値を設定しない場合、`System32`ディレクトリをアプリケーションの作業ディレクトリ。 |
| プロセス | 実行可能ファイル | ほとんどの場合、対象になりますの名前、`executable`削除パスとファイル拡張子で上に構成されています。 |
| フィックス アップ | dll | 修正、.msix/.appx を読み込むパッケージの相対パス。 |
| フィックス アップ | 構成 | (省略可能)フィックス アップ dl の動作を制御します。 この値の正確な形式は、各フィックス アップが必要があると"blob"を解釈できるよう、フィックス アップの修正によってごとに異なります。 |

`applications`、 `processes`、および`fixups`キーは配列です。 つまり、1 つ以上のアプリケーション、プロセス、および DLL のフィックス アップを指定する config.json ファイルを使用することができます。

### <a name="package-and-test-the-app"></a>パッケージとアプリをテストします

次に、パッケージを作成します。

```ps
makeappx pack /d PackageContents /p PSFSamplePackageFixup.msix
```

次に、署名します。

```ps
signtool sign /a /v /fd sha256 /f ExportedSigningCertificate.pfx PSFSamplePackageFixup.msix
```

詳細については、次を参照してください[署名証明書パッケージを作成する方法](https://docs.microsoft.com/en-us/windows/desktop/appxpkg/how-to-create-a-package-signing-certificate)と[signtool を使用してパッケージに署名する方法。](https://docs.microsoft.com/en-us/windows/desktop/appxpkg/how-to-sign-a-package-using-signtool)

PowerShell を使用してパッケージをインストールします。

>[!NOTE]
> まず、パッケージをアンインストールしてください。

```ps
powershell Add-AppPackage .\PSFSamplePackageFixup.msix
```

アプリケーションを実行し、ランタイムの修正プログラムが適用されると、動作を確認します。  診断および必要に応じて、パッケージ化の手順を繰り返します。

### <a name="use-the-trace-fixup"></a>トレースのフィックス アップを使用して、

パッケージ化されたアプリケーション互換性の問題を診断するために別の手法では、トレースのフィックス アップを使用します。 この DLL は、PSF に含まれているし、プロセス モニターと類似した、アプリの動作の詳細な診断ビューを提供します。  アプリケーション互換性の問題を表示するように設計します。  トレース フィックス アップ、DLL、パッケージを追加するの config.json に次のフラグメントを追加しパッケージ化をし使用するアプリケーションをインストールします。

```json
{
    "dll": "TraceFixup.dll",
    "config": {
        "traceLevels": {
            "filesystem": "allFailures"
        }
    }
}
```

既定では、トレースのフィックス アップ「が必要です」と見なされてエラーが除外されます。  たとえば、アプリケーションは、無条件でファイルを削除するかどうかは、既に存在する、結果を無視して確認せずにしようと可能性があります。 これは、上記の例では、ことを選択します filesystem 関数からすべてのエラーを受信するためのいくつかの予期しないエラーが取得除外された、残念な結果です。 そうため、その前に、Config.txt ファイルから読み取りを試みるは、メッセージ「ファイルが見つかりません」で失敗からわかるようにします。 これは、障害が頻繁に観察しは、一般に、予期できないと見なされます。 実際には予期しない故障にのみフィルター処理し、フォールバックしてエラーをすべてまだ識別できない問題がある場合を開始する可能性の高い最適になります。

既定では、トレースの修正から出力を取得、アタッチされたデバッガーに送信されます。 この例では、デバッガーをアタッチしようとしています。 おは代わりに使用、 [DebugView](https://docs.microsoft.com/en-us/sysinternals/downloads/debugview) sysinternals 出力を表示するプログラム。 アプリを実行した後には、ことがわかります同じ障害と同様に、同じランタイム修正プログラムにごポイントします。

![TraceShim ファイルが見つかりません](images/desktop-to-uwp/traceshim_filenotfound.png)

![TraceShim アクセスが拒否されました](images/desktop-to-uwp/traceshim_accessdenied.png)

## <a name="debug-extend-or-create-a-runtime-fix"></a>デバッグ、拡張、またはランタイム修正プログラムの作成

Visual Studio を使用して、ランタイム修正プログラムをデバッグ、実行時の修正プログラムを拡張または最初から作成することができます。 成功するこれらの作業を行う必要があります。

> [!div class="checklist"]
> * パッケージのプロジェクトを追加します。
> * プロジェクト ランタイム修正プログラムを追加します。
> * 実行可能ファイルの PSF ランチャーを起動するプロジェクトを追加します。
> * パッケージ プロジェクトを構成します。

完了すると、ソリューションは次のようになります。

![完成したソリューション](images/desktop-to-uwp/runtime-fix-project-structure.png)

この例では、各プロジェクトを見てみましょう。

| Project | 目的 |
|-------|-----------|
| DesktopApplicationPackage | このプロジェクトがに基づいて、 [Windows アプリケーション パッケージ プロジェクト](desktop-to-uwp-packaging-dot-net.md)MSIX パッケージを出力します。 |
| Runtimefix | これは、ランタイム修正プログラムとして機能する 1 つまたは複数の置換関数を含む C++ Dynamic-Linked ライブラリ プロジェクトです。 |
| PSFLauncher | これは、C++ の空のプロジェクトです。 このプロジェクトは、パッケージのサポート、フレームワークのランタイム再頒布可能ファイルを収集する場所です。 実行可能ファイルを出力します。 この実行可能ファイルとは、ソリューションを開始するときに実行される最初のことです。 |
| WinFormsDesktopApplication | このプロジェクトには、デスクトップ アプリケーションのソース コードが含まれています。 |

これらの種類のプロジェクトのすべてを含む完全なサンプルを見るを参照してください。 [PSFSample](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/samples/PSFSample/)します。

作成し、ソリューションでこれらの各プロジェクトを構成する手順を見てみましょう。

### <a name="create-a-package-solution"></a>パッケージ ソリューションを作成します。

デスクトップ アプリケーションのソリューションがいない場合は、新しい作成**空のソリューション**Visual Studio でします。

![空のソリューション](images/desktop-to-uwp/blank-solution.png)

持つ任意のアプリケーション プロジェクトを追加することもできます。

### <a name="add-a-packaging-project"></a>パッケージのプロジェクトを追加します。

まだ持っていない場合、 **Windows アプリケーション パッケージ プロジェクト**、1 つを作成し、ソリューションに追加します。

![パッケージ プロジェクト テンプレート](images/desktop-to-uwp/package-project-template.png)

Windows アプリケーション パッケージ プロジェクトの詳細については、[Visual Studio を使用して、アプリケーションをパッケージ化](desktop-to-uwp-packaging-dot-net.md)を参照してください。

**ソリューション エクスプ ローラー**をパッケージ プロジェクトを右クリックして選択**編集**、し、これをプロジェクト ファイルの末尾に追加します。

```xml
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

### <a name="add-project-for-the-runtime-fix"></a>プロジェクト ランタイム修正プログラムを追加します。

C++ の追加**ダイナミック リンク ライブラリ (DLL)** プロジェクトがソリューションにします。

![修正プログラムのランタイム ライブラリ](images/desktop-to-uwp/runtime-fix-library.png)

クリックして、プロジェクトを右クリックして**プロパティ**します。

プロパティ ページで、 **C 言語標準**フィールド、およびそのフィールドの横にあるドロップダウン リストを選択します、 **ISO c++ 17 標準 (//std:c + + 17)** オプション。

![17 の ISO オプション](images/desktop-to-uwp/iso-option.png)

そのプロジェクトを右クリックし、コンテキスト メニューを選択、 **Nuget パッケージの管理**オプション。 いることを確認、**パッケージ ソース**にオプションが設定されている**すべて**または**nuget.org**します。

次にそのフィールドの設定 アイコンをクリックします。

検索、 *PSF** Nuget をパッケージ化し、このプロジェクトにインストールします。

![nuget パッケージ](images/desktop-to-uwp/psf-package.png)

デバッグまたは既存のランタイム修正プログラムを拡張する場合は、追加で説明されているガイダンスを使用して取得したランタイム修正プログラム ファイル、[ランタイム修正プログラムを見つける](#find)このガイドの「します。

新しい修正プログラムを作成する場合は、何も追加しないこのプロジェクトにまだだけです。 このガイドの後半では、このプロジェクトに適切なファイルを追加する手伝いします。 ここでは、ソリューションの設定がいく予定です。

### <a name="add-a-project-that-starts-the-psf-launcher-executable"></a>実行可能ファイルの PSF ランチャーを起動するプロジェクトを追加します。

C++ の追加**空のプロジェクト**プロジェクトがソリューションにします。

![空のプロジェクト](images/desktop-to-uwp/blank-app.png)

追加、 **PSF**前のセクションで説明されている同じガイダンスを使用してこのプロジェクトに Nuget パッケージ。

で、プロジェクトのプロパティ ページを開く、**全般**設定ページで、設定、**ターゲット名**プロパティを``PSFLauncher32``または``PSFLauncher64``アプリケーションのアーキテクチャに応じて。

![PSF ランチャー参照](images/desktop-to-uwp/shim-exe-reference.png)

ランタイム修正プログラムのプロジェクトへの参照をプロジェクトをソリューションに追加します。

![ランタイム修正プログラムのリファレンス](images/desktop-to-uwp/reference-fix.png)

参照を右クリックし、**プロパティ**ウィンドウで、これらの値を適用します。

| プロパティ | Value |
|-------|-----------|
| ローカルのコピーします。 | True |
| ローカル サテライト アセンブリをコピーします。 | True |
| 参照アセンブリの出力 | True |
| ライブラリ依存関係のリンク | False |
| リンク ライブラリの依存関係の入力 | False |

### <a name="configure-the-packaging-project"></a>パッケージ プロジェクトを構成します。

パッケージ プロジェクトで、**[アプリケーション]** フォルダーを右クリックして **[参照の追加]** を選びます。

![プロジェクト参照の追加](images/desktop-to-uwp/add-reference-packaging-project.png)

PSF ランチャー プロジェクトと、デスクトップ アプリケーション プロジェクトを選択し、選択、 **OK**ボタンをクリックします。

![デスクトップ プロジェクト](images/desktop-to-uwp/package-project-references.png)

>[!NOTE]
> アプリケーション ソース コードを持っていない場合は、PSF ランチャー プロジェクトを選択します。 構成ファイルを作成するときに、実行可能ファイルを参照する方法について説明します。

**アプリケーション**ノード、PSF ランチャー アプリケーションを右クリックし、**エントリ ポイントとして設定**します。

![エントリ ポイントの設定](images/desktop-to-uwp/set-startup-project.png)

という名前のファイルを追加``config.json``をパッケージ化プロジェクトにコピーし、次の json テキストをファイルに貼り付けます。 設定、**パッケージ アクション**プロパティを**コンテンツ**します。

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
            "fixups": [
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

各キーの値を指定します。 このテーブルをガイドとして使用します。

| 配列 | key | Value |
|-------|-----------|-------|
| applications | id |  値を使用して、`Id`の属性、`Application`パッケージ マニフェスト内の要素。 |
| applications | 実行可能ファイル | 開始する実行可能ファイルへのパッケージの相対パス。 ほとんどの場合、変更する前に、パッケージ マニフェスト ファイルからこの値を取得できます。 値は、`Executable`の属性、`Application`要素。 |
| applications | WorkingDirectory | (省略可能)起動するアプリケーションの作業ディレクトリとして使用するパッケージの相対パス。 オペレーティング システムを使用して、この値を設定しない場合、`System32`ディレクトリをアプリケーションの作業ディレクトリ。 |
| プロセス | 実行可能ファイル | ほとんどの場合、対象になりますの名前、`executable`削除パスとファイル拡張子で上に構成されています。 |
| フィックス アップ | dll | フィックス アップを読み込む DLL にパッケージの相対パス。 |
| フィックス アップ | 構成 | (省略可能)フィックス アップ DLL の動作を制御します。 この値の正確な形式は、各フィックス アップが必要があると"blob"を解釈できるよう、フィックス アップの修正によってごとに異なります。 |

完了すると、``config.json``ファイルは次のようになります。

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
      "fixups": [ { "dll": "RuntimeFix.dll" } ]
    }
  ]
}

```

>[!NOTE]
> `applications`、 `processes`、および`fixups`キーは配列です。 つまり、1 つ以上のアプリケーション、プロセス、および DLL のフィックス アップを指定する config.json ファイルを使用することができます。

### <a name="debug-a-runtime-fix"></a>ランタイム修正プログラムをデバッグします。

Visual Studio で f5 キーを押してデバッガーを起動します。  最初に起動するとは、さらに、ターゲット デスクトップ アプリケーションを起動する PSF のランチャー アプリケーションです。  対象のデスクトップ アプリケーションをデバッグするには、手動で選択してデスクトップ アプリケーションのプロセスにアタッチする必要があります**デバッグ**->**プロセスにアタッチ**、アプリケーションを選択プロセスです。 ネイティブ ランタイム修正プログラムを DLL と .NET アプリケーションのデバッグを許可するには、(混在モードのデバッグ) のマネージ コードとネイティブ コードの種類を選択します。  

これを設定したらとは、デスクトップ アプリケーションのコードでランタイム修正プログラムのプロジェクトのコード行の横にあるブレークポイントを設定できます。 アプリケーション ソース コードを持っていない場合、ランタイム修正プログラムのプロジェクトでのコード行の横にあるブレークポイントを設定することができます。

>[!NOTE]
> Visual Studio では、最も簡単な開発エクスペリエンスをデバッグするには、いくつかの制限があると、このガイドの後で取り上げます他のデバッグ手法を適用することができます。

## <a name="create-a-runtime-fix"></a>ランタイム修正プログラムを作成します。

ない場合、ランタイムを解決することは、置換関数を作成し、構成データを含む新しいランタイム修正プログラムを作成することができます、問題の修正は合理的です。 各部分を見てみましょう。

### <a name="replacement-functions"></a>置換関数

まず、MSIX コンテナーで、アプリケーションの実行時に呼び出しが失敗する関数を特定します。 次に、代わりに、ランタイム マネージャーを置換関数を作成できます。 これにより、最新のランタイム環境の規則に準拠した動作で、関数の実装を置き換えることです。

Visual Studio で、このガイドの前半で作成したランタイム修正プロジェクトを開きます。

宣言、``FIXUP_DEFINE_EXPORTS``マクロの include ステートメントを追加し、`fixup_framework.h`それぞれの上部にあります。CPP ファイルは、ランタイム修正プログラムの機能を追加します。

```c++
#define FIXUP_DEFINE_EXPORTS
#include <fixup_framework.h>
```

>[!IMPORTANT]
>必ず、 `FIXUP_DEFINE_EXPORTS` include ステートメントの前にマクロが表示されます。

同じ関数のシグネチャを持つ関数を作成したが動作を変更します。 置換する関数の例を次に示します、`MessageBoxW`関数。

```c++
auto MessageBoxWImpl = &::MessageBoxW;
int WINAPI MessageBoxWFixup(
    _In_opt_ HWND hwnd,
    _In_opt_ LPCWSTR,
    _In_opt_ LPCWSTR caption,
    _In_ UINT type)
{
    return MessageBoxWImpl(hwnd, L"SUCCESS: This worked", caption, type);
}

DECLARE_FIXUP(MessageBoxWImpl, MessageBoxWFixup);
```

呼び出し`DECLARE_FIXUP`マップ、`MessageBoxW`関数を新しい置換する関数。 アプリケーションが呼び出すしようとしたときに、`MessageBoxW`関数を置換する関数を代わりに呼び出すことがされます。

#### <a name="protect-against-recursive-calls-to-functions-in-runtime-fixes"></a>修正をランタイムに関数への再帰呼び出しから保護します。

必要に応じて適用することができます、`reentrancy_guard`修正をランタイムに関数への再帰呼び出しから保護する、関数への型。

たとえば、置換するための関数を生じる可能性があります、`CreateFile`関数。 実装を呼び出すことができます、`CopyFile`関数がの実装、`CopyFile`関数を呼び出すことができます、`CreateFile`関数。 呼び出しの無限の再帰的なサイクルが生じる、`CreateFile`関数。

詳細については`reentrancy_guard`を参照してください[authoring.md](https://github.com/Microsoft/MSIX-PackageSupportFramework/blob/master/Authoring.md)

### <a name="configuration-data"></a>構成データ

構成データ、ランタイム修正プログラムを追加する場合に追加することを検討してください、``config.json``します。 これでが使用できる、`FixupQueryCurrentDllConfig`を簡単にそのデータを解析します。 この例では、その構成ファイルからのブール値、および文字列の値を解析します。

```c++
if (auto configRoot = ::FixupQueryCurrentDllConfig())
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

## <a name="other-debugging-techniques"></a>その他のデバッグ技術

Visual Studio は、最も簡単な開発およびデバッグ エクスペリエンスをでは、中にいくつかの制限があります。

.Msix からインストールするのではなく、パッケージ レイアウト フォルダーのパスから圧縮しないファイルを展開して、アプリケーションを最初に、F5 デバッグ実行/.appx パッケージ。  レイアウト フォルダー通常が同じセキュリティ制限として、インストールされているパッケージのフォルダー。 その結果、ランタイム修正プログラムを適用する前にパッケージのパスへのアクセス拒否エラーを再現できないこと可能性があります。

この問題に対処 .msix を使用して、f5 キーではなく、.appx パッケージの配置は、ファイルの配置を疎/。  .Msix を作成する/.appx パッケージ ファイルを使用して、 [MakeAppx](https://docs.microsoft.com/en-us/windows/desktop/appxpkg/make-appx-package--makeappx-exe-)前述のように、Windows SDK のユーティリティ。 またはから、Visual Studio 内で、アプリケーションのプロジェクト ノードを右クリックし、選択**ストア**->**アプリ パッケージの作成**です。

Visual Studio の別の問題は、デバッガーによって起動されたすべての子プロセスにアタッチするための組み込みサポートがないことです。   デバッグ対象のアプリケーションでは、関連付ける必要があります手動で Visual Studio によって起動した後の起動パス内のロジックを困難になります。

この問題に対処するには、子プロセスのアタッチをサポートする、デバッガーを使用します。  一般に、ターゲット アプリケーションへのジャストイン タイム (JIT) デバッガーをアタッチすることに注意してください。  これは、ほとんどの JIT 手法では、ImageFileExecutionOptions のレジストリ キーを使用して、対象とするアプリケーションの代わりにデバッガーを起動するが含まれるためにです。  これには、PSFLauncher.exe FixupRuntime.dll を対象となるアプリに挿入するための detouring メカニズムが果たせなくなります。  含まれる、WinDbg、[ツールを Windows のデバッグ](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/index)から取得し、 [Windows SDK](https://developer.microsoft.com/en-US/windows/downloads/windows-10-sdk)、サポートする子プロセスのアタッチします。  また、直接サポート[を起動して、UWP アプリのデバッグ](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/debugging-a-uwp-app-using-windbg#span-idlaunchinganddebuggingauwpappspanspan-idlaunchinganddebuggingauwpappspanspan-idlaunchinganddebuggingauwpappspanlaunching-and-debugging-a-uwp-app)します。

子プロセスとしてターゲット アプリケーションの起動をデバッグするには、開始``WinDbg``します。

```ps
windbg.exe -plmPackage PSFSampleWithFixup_1.0.59.0_x86__7s220nvg1hg3m -plmApp PSFSample
```

``WinDbg``と表示されたら、子のデバッグを有効にする、適切なブレークポイントを設定します。

```ps
.childdbg 1
g
```

(対象のアプリケーションが開始され、デバッガーを中断するまで実行)

```ps
sxe ld fixup.dll
g
```

(フィックス アップ DLL が読み込まれるまで実行)

```ps
bp ...
```

>[!NOTE]
> [PLMDebug](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/plmdebug)を起動すると、アプリにデバッガーをアタッチすることも使用できにも含まれますが、[ツールを Windows のデバッグ](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/index)します。  ただし、WinDbg によって提供されるようになりました direct サポートよりも複雑です。

## <a name="support-and-feedback"></a>サポートとフィードバック

**質問の回答を検索**

ご質問がある場合は、 Stack Overflow でお問い合わせください。 Microsoft のチームでは、これらの[タグ](https://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge)をチェックしています。 [こちら](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D)から質問することもできます。
