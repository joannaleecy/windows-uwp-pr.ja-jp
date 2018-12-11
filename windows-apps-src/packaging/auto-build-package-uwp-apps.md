---
title: UWP アプリの自動ビルドを設定する
description: サイドロード パッケージやストア パッケージを生成する自動ビルドを構成する方法について説明します。
ms.date: 09/30/2018
ms.topic: article
keywords: windows 10, UWP
ms.assetid: f9b0d6bd-af12-4237-bc66-0c218859d2fd
ms.localizationpriority: medium
ms.openlocfilehash: 4208fd56b16d5130f218492428eb459364b8ada9
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8923849"
---
# <a name="set-up-automated-builds-for-your-uwp-app"></a>UWP アプリの自動ビルドを設定する

Visual Studio Team Services (VSTS) を使用して、UWP プロジェクトの自動ビルドを作成できます。
この記事では、そのためのさまざまな方法について取り上げます。  また、AppVeyor などの他のビルド システムと統合できるようにコマンド ラインを使用してこれらのタスクを実行する方法も示します。

## <a name="select-the-right-type-of-build-agent"></a>適切な種類のビルド エージェントを選択する

ビルド プロセスの実行時に VSTS で使用するビルド エージェントの種類を選択します。
ホスト ビルド エージェントは、最も一般的なツールや SDK と共に展開され、ほとんどのシナリオで動作します ([ホスト ビルド サーバー上のソフトウェアに関する記事](https://www.visualstudio.com/docs/build/admin/agents/hosted-pool#software)をご覧ください)。 ただし、ビルド ステップをより細かく制御する必要がある場合は、カスタム ビルド エージェントを作成できます。 次の表は、この意思決定を行うのに役立ちます。

| **シナリオ** | **カスタム エージェント** | **ホスト ビルド エージェント** |
|-------------|----------------|----------------------|
| 基本的な UWP ビルド (.NET Native を含む)| :white_check_mark: | :white_check_mark: |
| サイドロード用パッケージを生成する| :white_check_mark: | :white_check_mark: |
| ストア申請用パッケージを生成する| :white_check_mark: | :white_check_mark: |
| カスタム証明書を使用する| :white_check_mark: | |
| カスタム Windows SDK を対象としてビルドする| :white_check_mark: |  |
| 単体テストを実行する| :white_check_mark: |  |
| 段階的なビルドを使用する| :white_check_mark: |  |

#### <a name="create-a-custom-build-agent-optional"></a>カスタム ビルド エージェントを作成する (省略可能)

カスタム ビルド エージェントを作成する場合は、ユニバーサル Windows プラットフォームのツールが必要です。 これらのツールは、Visual Studio に含まれています。 Visual Studio の Community Edition を使用できます。

詳しくは、[Windows でのエージェントの展開に関するページ](https://www.visualstudio.com/docs/build/admin/agents/v2-windows)をご覧ください。

UWP 単体テストを実行するには、以下の操作を実行する必要があります。

- アプリを展開および起動する
- 対話モードで VSTS エージェントを実行する
- 再起動後に自動ログオンするようにエージェントを構成する

## <a name="set-up-an-automated-build"></a>自動ビルドを設定する

まず、VSTS で利用可能な既定の UWP ビルドの定義について説明し、さらに高度なビルド タスクを実行できるようにその定義を構成する方法を示します。

**ソース コード リポジトリにプロジェクトの証明書を追加する**

VSTS は、TFS および GIT ベースのコード リポジトリと連携します。
Git リポジトリを使用する場合は、ビルド エージェントがアプリ パッケージに署名できるように、リポジトリにプロジェクトの証明書ファイルを追加します。 これを行わない場合、Git リポジトリは証明書ファイルを無視します。
リポジトリに証明書ファイルを追加するには、ソリューション エクスプローラーで証明書ファイルを右クリックし、ショートカット メニューで [無視されたファイルをソース管理に追加] を選択します。

![証明書を含める方法](images/building-screen1.png)

[高度な証明書の管理](#certificates-best-practices)については、このガイドで後述します。

VSTS で最初のビルド定義を作成するには、[ビルド] タブに移動し、[+] ボタンを選択します。

![ビルド定義を作成する](images/building-screen2.png)

ビルド定義テンプレートの一覧で、*[ユニバーサル Windows プラットフォーム]* テンプレートを選択します。

![UWP のビルドを選択する](images/building-screen3.png)

このビルド定義には、次のビルド タスクが含まれています。

- NuGet の復元 **\*.sln
- ソリューションのビルド **\*.sln
- シンボルの発行
- 成果物の公開: drop

#### <a name="configure-the-nuget-restore-build-task"></a>NuGet の復元のビルド タスクを構成する

このタスクでは、プロジェクトで定義されている NuGet パッケージを復元します。 一部のパッケージには、NuGet.exe のカスタム バージョンが必要です。 カスタム バージョンを必要とするパッケージを使っている場合、リポジトリでそのバージョンの NuGet.exe を参照し、詳細プロパティの *[NuGet.exe へのパス]* で指定します。

![既定のビルド定義](images/building-screen4.png)

#### <a name="configure-the-build-solution-build-task"></a>ソリューションのビルドのビルド タスクを構成する

このタスクは、バイナリに作業フォルダー内では出力アプリ パッケージのファイルを生成したすべてのソリューションをコンパイルします。
このタスクでは、MSBuild の引数を使用します。  これらの引数の値を指定する必要があります。 次の表をガイドとして使用してください。

|**MSBuild の引数**|**値**|**説明**|
|--------------------|---------|---------------|
|AppxPackageDir|$(Build.ArtifactStagingDirectory)\AppxPackages|生成された成果物を格納するフォルダーを定義します。|
|AppxBundlePlatforms|$(Build.BuildPlatform)|バンドルに含めるプラットフォームを定義できます。|
|AppxBundle|Always|指定されているプラットフォームの appx ファイルを含む appxbundle を作成します。|
|**UapAppxPackageBuildMode**|StoreUpload|生成するアプリ パッケージの種類を定義します。 (既定では含まれません)。|

コマンド ラインを使って、つまり他のビルド システムを使って、ソリューションをビルドする場合は、次の引数を指定して msbuild を実行します。

```ps
/p:AppxPackageDir="$(Build.ArtifactStagingDirectory)\AppxPackages\\"
/p:UapAppxPackageBuildMode=StoreUpload
/p:AppxBundlePlatforms="$(Build.BuildPlatform)"
/p:AppxBundle=Always
```

$() 構文で定義されたパラメーターは、ビルド定義で定義される変数で、他のビルド システムでは変更されます。

![既定の変数](images/building-screen5.png)

すべての定義済みの変数を表示するには、[ビルド変数の使用に関するページ](https://www.visualstudio.com/docs/build/define/variables)をご覧ください。

#### <a name="configure-the-publish-artifact-build-task"></a>成果物の公開のビルド タスクを構成する

このタスクは、VSTS で生成される成果物を格納します。 成果物は、ビルド結果ページの [成果物] タブで確認できます。
VSTS は、以前に定義した `$(Build.ArtifactStagingDirectory)\AppxPackages` フォルダーを使用します。

![成果物](images/building-screen6.png)

ここでは、`UapAppxPackageBuildMode` プロパティを `StoreUpload` に設定しているため、成果物フォルダーには、ストアへの提出に推奨されるパッケージ (.appxupload) が含まれます。 提出できることも通常のアプリ パッケージ (.appx/.msix) またはアプリ バンドル (.appxbundle/.msixbundle) ストアに注意してください。 この資料の目的上、.appxupload ファイルを使います。

>[!NOTE]
> 既定では、VSTS エージェントによって、生成された最新のアプリ パッケージが維持されます。 現在のビルドの成果物のみを格納する場合は、バイナリ ディレクトリをクリーンアップするようにビルドを構成します。 そのためには、`Build.Clean` という名前の変数を追加し、その変数の値を `all` に設定します。 詳しくは、[リポジトリの指定に関するページ](https://www.visualstudio.com/docs/build/define/repository#how-can-i-clean-the-repository-in-a-different-way)をご覧ください。

#### <a name="the-types-of-automated-builds"></a>自動ビルドの種類

次に、ビルド定義を使って自動ビルドを作成します。 次の表では、作成できる自動ビルドの各種類について説明します。

|**ビルドの種類**|**成果物**|**推奨される頻度**|**説明**|
|-----------------|------------|-------------------------|---------------|
|継続的インテグレーション|ビルド ログ、テスト結果|コミットごと|この種類のビルドは高速で、1 日に数回実行されます。|
|サイドロード用の継続的配置ビルド|配置パッケージ|毎日 |この種類のビルドは、単体テストを含めることができますが、少し長くかかります。 これにより、手動でテストでき、HockeyApp などの他のツールと統合できます。|
|ストアにパッケージを提出する継続的配置ビルド|公開パッケージ|オンデマンド|この種類のビルドでは、ストアに公開できるパッケージを作成します。|

1 つずつを構成する方法を見てみましょう。

## <a name="set-up-a-continuous-integration-ci-build"></a>継続的インテグレーション (CI) ビルドを設定する

この種類のビルドは、すばやくコードに関連する問題を診断するのに役立ちます。 通常、1 つのプラットフォーム用にのみ実行され、.NETネイティブ ツール チェーンで処理する必要はありません。 また、CI ビルドを使って、テスト結果のレポートを生成する単体テストを実行できます。

CI ビルドの一環として UWP 単体テストを実行する場合、ホスト ビルド エージェントではなく、カスタム ビルド エージェントを使用する必要があります。

>[!NOTE]
> 複数のアプリを同じソリューションにバンドルすると、エラーが発生する可能性があります。 このようなエラーを解決する方法については、「[複数のアプリを同じソリューションにバンドルした場合に表示されるエラーを解決する](#bundle-errors)」をご覧ください。

### <a name="configure-a-ci-build-definition"></a>CI ビルド定義を構成する

既定の UWP テンプレートを使用して、ビルド定義を作成します。 次に、チェックインごとに実行するトリガーを構成します。

![CI トリガー](images/building-screen7.png)

CI ビルドはユーザーに対して展開されないため、CD ビルドとの混同を避けるために、異なるバージョン番号によって管理することをお勧めします。 次に、例を示します。
`$(BuildDefinitionName)_0.0.$(DayOfYear)$(Rev:.r)`

#### <a name="configure-a-custom-build-agent-for-unit-testing"></a>単体テスト用のカスタム ビルド エージェントを構成する

1. お使いの PC で開発者モードを有効にします。 詳しくは、「[デバイスを開発用に有効にする](https://docs.microsoft.com/windows/uwp/get-started/enable-your-device-for-development)」をご覧ください。
2. サービスを対話型プロセスとして実行できるように設定します。 詳しくは、[Windows でのエージェントの展開に関するページ](https://docs.microsoft.com/vsts/build-release/actions/agents/v2-windows)をご覧ください。
3. エージェントに署名証明書を展開します。

署名証明書を展開するには、`.cer` ファイルをダブルクリックし、**[ローカル コンピューター]** を選択して、**信頼されたユーザーのストア**を選択します。

<span id="uwp-unit-tests" />

### <a name="configure-the-build-definition-to-run-uwp-unit-tests"></a>UWP 単体テストを実行するようにビルド定義を構成する

単体テストを実行するには、Visual Studio テスト ビルド ステップを使用します。

![単体テストを追加する](images/building-screen8.png)

UWP 単体テストは特定の appxrecipe ファイルのコンテキストで実行されるため、生成されたバンドルを使うことはできません。 また、具体的なプラットフォームの appxrecipe ファイルへのパスを指定する必要があります。 次に、例を示します。

```ps
$(Build.ArtifactStagingDirectory)\AppxPackages\MyUWPApp.UnitTest\x86\MyUWPApp.UnitTest_$(AppxVersion)_x86.appxrecipe
```

テストを実行するには、コンソール パラメーターを vstest.console.exe に追加する必要があります。 このパラメーターは、**[実行オプション] => [Other console options] (その他のコンソール オプション)** から指定できます。 次のパラメーターを追加してください。

```ps
/framework:FrameworkUap10
```

>[!NOTE]
> コマンド ラインからローカルに単体テストを実行するには、次のコマンドを使います。
`"%ProgramFiles(x86)%\Microsoft Visual Studio 14.0\Common7\IDE\CommonExtensions\Microsoft\TestWindow\vstest.console.exe"`

#### <a name="access-test-results"></a>テスト結果にアクセスする

VSTS では、ビルドの概要ページに、単体テストを実行する各ビルドのテスト結果が表示されます。 そこから、**[テスト結果]** ページを開いてテスト結果の詳細を確認できます。

![テスト結果](images/building-screen9.png)

#### <a name="improve-the-speed-of-a-ci-build"></a>CI ビルドの速度を向上させる

チェックインの品質を監視する目的にのみ CI ビルドを使用する場合は、ビルド時間を短縮できます。

#### <a name="to-improve-the-speed-of-a-ci-build"></a>CI ビルドの速度を向上させるには

1. 1 つのプラットフォーム向けにのみビルドします。
2. BuildPlatform 変数を編集して、x86 のみを使用します。 ![CI を構成する](images/building-screen10.png)
3. ビルド ステップで、[MSBuild 引数] プロパティに「/p:AppxBundle=Never」を追加し、[プラットフォーム] プロパティを設定します。 ![プラットフォームを構成する](images/building-screen11.png)
4. 単体テスト プロジェクトで、.NET Native を無効にします。

そのためには、プロジェクト ファイルを開き、プロジェクトのプロパティで、`UseDotNetNativeToolchain` プロパティを `false` に設定します。

.NET Native ツール チェーンはワークフローの重要な部分であるため、リリース ビルドをテストするにはこのツール チェーンを使用する必要があります。

<span id="bundle-errors" />

#### <a name="address-errors-that-appear-when-you-bundle-more-than-one-app-in-the-same-solution"></a>複数のアプリを同じソリューションにバンドルした場合に表示されるエラーを解決する

ソリューションに複数の UWP プロジェクトを追加し、バンドルを作成しようとすると、次のようなエラーが表示される場合があります。

```ps
MakeAppx(0,0): Error : Error info: error 80080204: The package with file name "AppOne.UnitTests_0.1.2595.0_x86.appx" and package full name "8ef641d1-4557-4e33-957f-6895b122f1e6_0.1.2595.0_x86__scrj5wvaadcy6" is not valid in the bundle because it has a different package family name than other packages in the bundle
```

このエラーが表示されるのは、ソリューション レベルで、バンドルに含めるアプリが明確ではないためです。
この問題を解決するには、各プロジェクト ファイルを開き、最初の `<PropertyGroup>` 要素の最後に以下のプロパティを追加します。

|**プロジェクト**|**プロパティ**|
|-------|----------|
|App|`<AppxBundle>Always</AppxBundle>`|
|UnitTests|`<AppxBundle>Never</AppxBundle>`|

その後、ビルド ステップから MSBuild の `AppxBundle` 引数を削除します。

## <a name="set-up-a-continuous-deployment-build-for-sideloading"></a>サイドロード用の継続的配置ビルドの設定

この種類のビルドが完了したら、ユーザーは、ビルド結果ページの [成果物] セクションから、アプリ バンドル ファイルをダウンロードできます。
より完全な配布を作成することでアプリのベータ テストを行う場合は、HockeyApp サービスを使用できます。 このサービスは、ベータ テスト、ユーザー分析、クラッシュ診断用の高度な機能を提供します。

### <a name="applying-version-numbers-to-your-builds"></a>ビルドにバージョン番号を適用する

マニフェスト ファイルには、アプリのバージョン番号が含まれています。  バージョン番号を変更するには、ソース コントロール リポジトリ内のマニフェスト ファイルを更新します。
アプリのバージョン番号を更新するもう 1 つの方法は、VSTS によって生成されるビルド番号を使用し、アプリをコンパイルする直前にアプリ マニフェストを変更する方法です。 ソース コード リポジトリにはこれらの変更をコミットしないでください。

ビルド定義でバージョン管理ビルド番号の形式を定義し、コンパイルする前に、結果のバージョン番号を使用して AppxManifest ファイルと、必要に応じて AssemblyInfo.cs ファイルを更新する必要があります。

ビルド定義の *[全般]* タブで、ビルド番号の形式を定義します。

![ビルドのバージョン](images/building-screen12.png)

たとえば、ビルド番号の形式を次のように設定したとします。

```ps
$(BuildDefinitionName)_1.1.$(DayOfYear)$(Rev:r).0
```

VSTS では次のようなバージョン番号が生成されます。

```ps
CI_MyUWPApp_1.1.2501.0
```

>[!NOTE]
>Microsoft Store では、バージョンの最後の数字は 0 である必要があります。

バージョン番号を抽出し、マニフェストや `AssemblyInfo` ファイルに適用できるようにするには、カスタム PowerShell スクリプト ([ここ](https://go.microsoft.com/fwlink/?prd=12560&pver=14&plcid=0x409&clcid=0x9&ar=DevCenter&sar=docs)で入手可能) を使用します。 このスクリプトは、環境変数 `BUILD_BUILDNUMBER` からバージョン番号を読み取り、AssemblyInfo ファイルと AppxManifest ファイルを変更します。 ソース リポジトリにこのスクリプトを追加したことを確認し、次のように PowerShell のビルド タスクを構成します。

![バージョンの更新](images/building-screen13.png)

`$(AppxVersion)` 変数にバージョン番号が含まれています。 この番号を他のビルド ステップで使用できます。

#### <a name="optional-integrate-with-hockeyapp"></a>省略可能: HockeyApp と統合する

まず、Visual Studio 拡張機能 [HockeyApp](https://marketplace.visualstudio.com/items?itemName=ms.hockeyapp) をインストールします。 VSTS 管理者としてこの拡張機能をインストールする必要があります。

![HockeyApp](images/building-screen14.png)

次に、HockeyApp の接続を構成します。手順については、[Visual Studio Team Services (VSTS) や Team Foundation Server (TFS) で HockeyApp を使用する方法に関するページ](https://support.hockeyapp.net/kb/third-party-bug-trackers-services-and-webhooks/how-to-use-hockeyapp-with-visual-studio-team-services-vsts-or-team-foundation-server-tfs)をご覧ください。
HockeyApp アカウントを設定するには、Microsoft アカウント、ソーシャル メディア アカウント、または電子メール アドレスのみを使用できます。 無料プランには、2 つのアプリ、1 人の所有者が含まれ、データ制限はありません。

次に、手動で、または既存のアプリ パッケージ ファイルをアップロードすることで、HockeyApp アプリを作成できます。 詳しくは、[新しいアプリを作成する方法に関するページ](https://support.hockeyapp.net/kb/app-management-2/how-to-create-a-new-app)をご覧ください。

既存のアプリ パッケージ ファイルを使用するには、ビルド ステップを追加し、ビルド ステップのバイナリ ファイルのパス パラメーターを設定します。

![HockeyApp を構成する](images/building-screen15.png)

このパラメーターを設定するには、次の例のように、アプリ名、AppxVersion 変数、サポートされているプラットフォームを組み合わせて 1 つの文字列にする必要があります。

```ps
$(Build.ArtifactStagingDirectory)\AppxPackages\MyUWPApp_$(AppxVersion)_Test\MyUWPApp_$(AppxVersion)_x86_x64_ARM.appxbundle
```

HockeyApp タスクには、シンボル ファイルへのパスを指定することができますが、お、バンドルと共にシンボルを含めることをお勧めします。

## <a name="set-up-a-continuous-deployment-build-that-submits-a-package-to-the-store"></a>Microsoft Store にパッケージを提出する継続的配置ビルドを設定する

ストア提出パッケージを生成するには、Visual Studio のストア関連付けウィザードを使用してストアにアプリを関連付けます。

![Microsoft Store に関連付ける](images/building-screen16.png)

このウィザードでは、Microsoft Store の関連付けの情報が含まれる Package.StoreAssociation.xml という名前のファイルが生成されます。 GitHub などのパブリック リポジトリでソース コードを保存する場合、このファイルには、そのアカウントのすべてのアプリの予約名が含まれます。 公開する前に、このファイルを除外または削除することができます。

このドキュメントの手順では、アプリを公開するために使用されたパートナー センター アカウントへのアクセスをお持ちでない場合:[サード パーティのアプリを構築するかどうか。ストア アプリをパッケージ化する方法](https://blogs.windows.com/buildingapps/2015/12/15/building-an-app-for-a-3rd-party-how-to-package-their-store-app/#e35YzR5aRG6uaBqK.97)します。

次に、ビルド ステップに次のパラメーターが含まれていることを確認する必要があります。

```ps
/p:UapAppxPackageBuildMode=StoreUpload
```

これにより、ストアに提出できるファイルのアップロードが生成されます。

#### <a name="configure-automatic-store-submission"></a>Microsoft Store への自動提出を構成する

Visual Studio Team Services の Microsoft Store 用の拡張機能を使用して Microsoft Store API と統合し、アプリ パッケージを Microsoft Store に送信します。

Azure Active Directory (AD)、パートナー センターのアカウントを接続し、要求を認証する広告にアプリを作成する必要があります。 これを実行するには、拡張機能のページのガイダンスに従います。

拡張機能を構成した後は、ビルド タスクを追加し、アプリの ID と、アップロード ファイルの場所を使用して構成します。

![パートナー センターを構成します。](images/building-screen17.png)

`Package File` パラメーターの値は次のようになります。

```ps
$(Build.ArtifactStagingDirectory)\
AppxPackages\MyUWPApp__$(AppxVersion)_x86_x64_ARM_bundle.appxupload
```

このビルドは手動でアクティブ化する必要があります。 これを使用して既存のアプリを更新することはできますが、Microsoft Store への最初の提出に使用することはできません。 詳しくは、「[Microsoft Store サービスを使用した申請の作成と管理](https://msdn.microsoft.com/windows/uwp/monetize/create-and-manage-submissions-using-windows-store-services)」をご覧ください。

## <a name="best-practices"></a>ベスト プラクティス

<span id="sideloading-best-practices"/>

### <a name="best-practices-for-sideloading-apps"></a>アプリのサイドロードのベスト プラクティス

ストアに公開せずに、アプリを配布する場合は、直接デバイスにアプリをサイドロードできます。ただし、それらのデバイスは、アプリ パッケージの署名に使用された証明書を信頼している必要があります。

`Add-AppDevPackage.ps1` PowerShell スクリプトを使用してアプリをインストールします。 このスクリプトは、証明書を追加して、ローカル コンピューターの信頼されたルート証明セクションにをインストールするかアプリのパッケージ ファイルを更新します。

#### <a name="sideloading-your-app-with-the-windows-10-anniversary-update"></a>Windows 10 Anniversary Update でのアプリのサイドロード

Windows 10 Anniversary update では、アプリのパッケージ ファイルをダブルクリックし、ダイアログ ボックスで [インストール] ボタンを選択してアプリをインストールできます。

![rs1 でのサイドロード](images/building-screen18.png)

>[!NOTE]
> この方法では、証明書や関連付けられている依存関係はインストールされません。

VSTS や HockeyApp などの web サイトから Windows アプリ パッケージを配布する場合は、そのサイトをブラウザーで信頼済みサイトの一覧に追加する必要があります。 そうしないと、Windows は、ファイルがロックされているものとしてマークします。

<span id="certificates-best-practices"/>

### <a name="best-practices-for-signing-certificates"></a>署名証明書のベスト プラクティス

Visual Studio では、各プロジェクト用の証明書が生成されます。 これにより、有効な証明書の整理された一覧を維持することは困難です。 複数のアプリを作成することを計画している場合は、すべてのアプリに署名するための単一の証明書を作成できます。 その後、その証明書を信頼している各デバイスでは、別の証明書をインストールしなくても、アプリをサイドロードすることができます。 詳しくは、「[パッケージ署名用の証明書を作成する](https://docs.microsoft.com/windows/uwp/packaging/create-certificate-package-signing)」をご覧ください。

#### <a name="create-a-signing-certificate"></a>署名証明書を作成する

証明書を作成するには、[MakeCert.exe](https://msdn.microsoft.com/library/windows/desktop/ff548309.aspx) ツールを使用します。

次の例では、MakeCert.exe ツールを使って証明書を作成します。

```ps
MakeCert /n publisherName /r /h 0 /eku "1.3.6.1.5.5.7.3.3,1.3.6.1.4.1.311.10.3.13" /e expirationDate /sv MyKey.pvk MyKey.cer
```

次に、Pvk2Pfx ツールを使用して、パスワードで保護されている秘密キーを含む PFX ファイルを生成できます。

コンピューターの役割ごとに次の証明書を提供します。

|**コンピューター**|**用途**|**証明書**|**証明書ストア**|
|-----------|---------|---------------|---------------------|
|開発者/ビルド コンピューター|ビルドの署名|MyCert.PFX|現在のユーザー/個人|
|開発者/ビルド コンピューター|実行|MyCert.cer|ローカル コンピューター/信頼されたユーザー|
|ユーザー|実行|MyCert.cer|ローカル コンピューター/信頼されたユーザー|

>注: ユーザーによって信頼済みのエンタープライズ証明書を使用することもできます。

#### <a name="sign-your-uwp-app"></a>UWP アプリに署名する

Visual Studio と MSBuild は、アプリの署名に使う証明書を管理するためのさまざまなオプションを提供します。

そのオプションの 1 つは、ソリューションに証明書と共に秘密キー (通常、.PFX ファイルの形式) を含めて、プロジェクト ファイルで pfx を参照することです。 マニフェスト エディターの [パッケージ] タブを使ってこれを管理できます。

![証明書を作成する](images/building-screen19.png)

もう 1 つのオプションは、ビルド コンピューター (現在のユーザー/個人) に証明書をインストールし、[証明書ストアから選択] オプションを使用することです。 これによって、プロジェクト ファイル内で証明書の拇印が指定されるため、プロジェクトのビルドに使用されるすべてのコンピューターに証明書をインストールする必要があります。

#### <a name="trust-the-signing-certificate-in-the-target-devices"></a>ターゲット デバイスで署名証明書を信頼する

ターゲット デバイスでは、アプリをインストールする前に、証明書を信頼する必要があります。

ローカル コンピューターの証明書ストアの信頼されたユーザーまたは信頼のルートの場所に証明書の公開キーを登録します。

証明書を登録する最もすばやい方法は、.cer ファイルをダブルクリックし、ウィザードの手順に従って、**ローカル コンピューター**の**信頼されたユーザー** ストアに証明書を保存することです。

## <a name="related-topics"></a>関連トピック

- [Windows 用の .NETアプリを構築する](https://www.visualstudio.com/docs/build/get-started/dot-net)
- [UWP アプリのパッケージ化](https://msdn.microsoft.com/windows/uwp/packaging/packaging-uwp-apps)
- [Windows 10 での LOB アプリのサイドローディング](https://technet.microsoft.com/itpro/windows/deploy/sideload-apps-in-windows-10)
- [パッケージ署名用の証明書を作成する](https://docs.microsoft.com/windows/uwp/packaging/create-certificate-package-signing)
