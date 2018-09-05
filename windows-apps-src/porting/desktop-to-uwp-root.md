---
author: normesta
Description: Create a modern Windows app package for your existing Windows Forms, WPF, or Win32 app or game. Add modern experiences for Windows 10 users and simplify deployment and monitization.
Search.Product: eADQiWindows 10XVcnh
title: デスクトップ ブリッジ
ms.author: normesta
ms.date: 05/14/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp
ms.assetid: 74373c24-f948-43bb-aa85-01e2e8e87162
ms.localizationpriority: medium
ms.openlocfilehash: 0d6565f56f7105872d14b7b1ce768f4240e0b83b
ms.sourcegitcommit: 7aa1933e6970f878faf50d59e1f799b90afd7cc7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/05/2018
ms.locfileid: "3381688"
---
# <a name="desktop-bridge"></a>デスクトップ ブリッジ

既存のデスクトップ アプリを利用して、Windows 10 ユーザー向けの最新のエクスペリエンスを追加します。 Microsoft Store を通じてアプリを配布し、国際市場でのリーチを拡大します。 Store に直接組み込まれている機能を活用することで、より簡単に、アプリの収益化ができます。 もちろん、ストアを使用する必要はありません。 既存のチャンネルを自由に使用してください。

![デスクトップ ブリッジ](images/desktop-to-uwp/desktop-bridge-4.png)

デスクトップ ブリッジは、最新の Windows アプリ パッケージを使用して開発者が Windows フォーム、WPF、または Win32 デスクトップ アプリやゲームを効率的に配布できるようにするため、プラットフォームに組み込まれているインフラストラクチャです。

このパッケージは、アプリに ID を提供します。デスクトップ アプリは、その ID を使用してユニバーサル Windows プラットフォーム (UWP) API にアクセスできます。 これを利用して、ライブ タイルや通知など、現代的で魅力的なエクスペリエンスを実現できます。  アプリが Windows 10 で実行される場合にのみ、単純な条件付きコンパイルとランタイム チェックを使用して、UWP コードを実行します。

Windows 10 エクスペリエンスを実現するために使用するコード以外は、アプリは元のままです。引き続き、そのアプリを既存の Windows 7、Windows Vista、または Windows XP のユーザーに配布できます。 Windows 10 では、このアプリを現在のアプリと同じように、完全な信頼ユーザー モードで引き続き実行できます。

>[!IMPORTANT]
>デスクトップ ブリッジは、Windows 10 Version 1607 で導入されており、Windows 10 Anniversary Update (10.0、ビルド 14393) 以降のリリースをターゲットとする Visual Studio プロジェクトでのみ使用できます。

> [!NOTE]
> Microsoft Virtual Academy から公開されている、<a href="https://mva.microsoft.com/en-US/training-courses/developers-guide-to-the-desktop-bridge-17373?l=oZG0B1WhD_8406218965/">このシリーズ</a>の短いビデオをご覧ください。 これらのビデオでは、デスクトップ アプリをユニバーサル Windows プラットフォーム (UWP) に移行するプロセスをすべて説明しています。

## <a name="benefits"></a>メリット

以下に、デスクトップ アプリケーションの Windows アプリ パッケージを作成する理由を示します。

:heavy_check_mark: **スムーズな展開プロセス**。 ブリッジを使用しているアプリやゲームでは、優れた展開エクスペリエンスが提供されます。 このエクスペリエンスにより、ユーザーが安心してアプリのインストールおよび更新を行うことができます。 ユーザーがアプリをアンインストールすると、跡形なく完全に削除されます。 このため、セットアップ エクスペリエンスの設計や、更新プログラムの配信にかかる時間を削減できます。

:heavy_check_mark: **自動更新とライセンス**。 アプリは、Microsoft Store の組み込みライセンスと自動更新機能に参加できます。 自動更新機能は、ファイルの変更された部分だけがダウンロードされるため、非常に信頼性が高く効率的なメカニズムです。

:heavy_check_mark: **リーチの拡大とシンプルな決済。** Microsoft Store からの配布なら、数百万人の Windows 10 ユーザーにリーチを拡大できます。ユーザーは、アプリとゲームの購入や、アプリ内での購入に各地域の支払い方法を使用できます。

:heavy_check_mark: **UWP 機能の追加**。  自分のペースで、XAML ユーザー インターフェイス、ライブ タイルの更新、UWP バックグラウンド タスク、アプリ サービスなどの多くの UWP 機能をアプリのパッケージに追加できます。

:heavy_check_mark: **対応デバイスの拡大**。 ブリッジを使用すると、徐々にコードをユニバーサル Windows プラットフォームに移行して、電話、Xbox One、HoloLens など、すべての Windows 10 デバイスを対象にできます。

利点の完全な一覧については、「[デスクトップ ブリッジ](https://developer.microsoft.com/windows/bridges/desktop)」をご覧ください。

## <a name="prepare"></a>準備

まず、「[アプリのパッケージ化の準備](desktop-to-uwp-prepare.md)」を読み、アプリに該当する点があれば、Windows アプリ パッケージを作成する前に対処することで、アプリケーションを準備します。 パッケージを作成する前に、多くの変更を加える必要はないかもしれません。 ただし、状況によっては、パッケージを作成する前にアプリへの調整が必要になる場合があります。

<a id="convert" />

## <a name="package"></a>パッケージ化

アプリの Windows アプリ パッケージを作成するには、以下のようなツールを使用できます。

### <a name="desktop-app-converter"></a>Desktop App Converter

このツールの名前には "Converter" という用語が含まれますが、実は、アプリの変換は行いません。 アプリは変更されません。 しかし、Windows アプリ パッケージが生成されます。 アプリによって多くのシステム変更が行われる場合や、インストーラーの処理について不明確な点がある場合に便利です。

Desktop App Converter は、インストーラーの操作を、アプリのパッケージ バージョンで使用される仮想ファイルとレジストリ システムに変換します。 また、Desktop App Converter には、変換以外にも役に立つ機能があります。 その一部を次に示します。

:heavy_check_mark: プレビュー ハンドラー、サムネイル ハンドラー、プロパティ ハンドラー、ファイアウォール規則、URL フラグを自動的に登録する。

:heavy_check_mark: ファイルの種類のマッピングを自動的に登録する。これによりユーザーは、エクスプローラーの **[種類]** 列を使ってファイルをグループ化できるようになります。

:heavy_check_mark: 公開 COM サーバーを登録する。

:heavy_check_mark: アプリの実行に使用できる証明書を生成する。

:heavy_check_mark: デスクトップ ブリッジと Microsoft Store の要件に照らしてアプリを検証する。

Desktop App Converter を使用する別の優れた理由は、Visual Studio とは別の開発環境を使ってアプリを管理する場合です。 Desktop App Converter は、アプリにインストーラーがなくても使うことができます。

「[Desktop App Converter を使用してアプリをパッケージ化する (デスクトップ ブリッジ)](desktop-to-uwp-run-desktop-app-converter.md)」をご覧ください。

### <a name="visual-studio"></a>Visual Studio

Visual Studio を使ってアプリケーションを管理しており、アプリケーションにインストーラーがないか、インストーラーが非常に多数の複雑なタスクを実行しない場合、代わりに Visual Studio の使用を検討してください。

Visual Studio を使うと、パッケージをかなり簡単に作成できます。 パッケージ プロジェクトを追加して、デスクトップ プロジェクトを参照し、F5 キーを押してアプリをデバッグします。 手動で調整する必要はありません。 この新しい効率化されたエクスペリエンスは、以前のバージョンの Visual Studio のエクスペリエンスから大幅に向上しています。 他にも以下のような処理を実行できます。

:heavy_check_mark: ビジュアル アセットを自動的に生成する。

:heavy_check_mark: ビジュアル デザイナーを使ってマニフェストに変更を加える。

:heavy_check_mark: ウィザードを使ってパッケージを生成する。

:heavy_check_mark: Windows デベロッパー センター ダッシュボードで既に予約している名前からアプリに ID を割り当てる。

「[Visual Studio を使った .NET アプリのパッケージ化 (デスクトップ ブリッジ)](desktop-to-uwp-packaging-dot-net.md)」をご覧ください。

### <a name="third-party-installer"></a>サードパーティ インストーラー

 いくつかのポピュラーなサード パーティ製品やインストーラーでは、デスクトップ ブリッジがサポートされるようになりました。 これらを使用すると、わずか数クリックで MSI インストーラーやアプリ パッケージを生成することができます。 これらのツールの使用方法について詳しくは、それぞれの製品の Web サイトをご覧ください。

#### <a name="advanced-installer"></a>Advanced Installer

Caphyon は、わずか数回のクリックでアプリケーションの Windows アプリ パッケージを生成できる、GUI ベースのデスクトップ アプリ パッケージ作成ツールを無料で提供しています。 このツールでは、サイレント モードで実行されるものも含めて、どのようなインストーラーでもパッケージ化できます。また、アプリがパッケージ化に適しているかどうかを判断するための妥当性チェックも実行できます。
Desktop App Converter は、Hyper-V および [VMware](http://www.vmware.com/) にも統合できます。 つまり、独自の仮想マシンを使用することができるため、サイズが 3 GB を超える可能性がある [Docker](https://docs.docker.com/) イメージをダウンロードする必要はありません。

<img width="20%" src="images/desktop-to-uwp/Advanced_Installer_Vertical.png">

[Advanced Installer](http://www.advancedinstaller.com/) を使用すると、既存のプロジェクトから MSI と [Windows アプリ パッケージ](http://www.advancedinstaller.com/uwp-app-package.html)を生成できます。 また、Advanced installer では、Microsoft Desktop App Converter を使用して生成した Windows アプリ パッケージをインポートすることもできます。 インポートしたアプリ パッケージは、UWP アプリ用に設計されたビジュアル ツールを使用して管理できます。

Advanced Installer では、Visual Studio 2017 および 2015 用の拡張機能も提供されており、これらは[デスクトップ ブリッジ アプリのビルドとデバッグ](http://www.advancedinstaller.com/debug-desktop-bridge-apps.html)に使用できます。

簡単な紹介については、こちらの[ビデオ](https://www.youtube.com/watch?v=cmLKgn04Vfg&feature=youtu.be)をご覧ください。

> [!TIP]
> 最近リリースされた [Advanced Installer Express Edition](https://www.advancedinstaller.com/express-edition.html) をチェックしてみてください。

#### <a name="cloudhouse-compatibility-containers"></a>Cloudhouse 互換性コンテナー

Windows 10 および Windows 10 S と互換性のない基幹業務アプリケーションを利用している企業ユーザーの場合、Cloudhouse の互換性コンテナーを使用すると、ソース コードを変更することなく Windows XP アプリケーションと Windows 7 アプリケーションを Windows 10 で実行することや、ユニバーサル Windows プラットフォーム (UWP) で実行できるように変換して、ビジネス向け Microsoft Store や Microsoft InTune を通じて配布することができます。 [無料試用版](http://www.cloudhouse.com/free-trial)に登録してください。

<img width="20%" src="images/desktop-to-uwp/cloudhouse-container-logo.png">

Cloudhouse が提供する Auto Packager は、アプリケーションが現在実行されているオペレーティング システム (Windows XP など) で、基幹業務アプリケーションをパッケージ化して[互換性コンテナー](https://docs.cloudhouse.com/37613-overview/266723-compatibility-containers-for-applications)を作成し、UWP に[変換できるようにアプリを準備](https://docs.cloudhouse.com/37613-overview/266725-compatibility-containers-for-desktop-bridge?from_search=17883905)します。 コンテナーはその後、Microsoft の Desktop App Converter ツールと統合して新しい Windows アプリ パッケージ形式に変換されます。

Auto Packager では、インストール/キャプチャおよび実行時分析を使用して、アプリケーションを Windows 10 で実行できるようにするために必要なアプリケーションのファイル、レジストリ、ランタイム、依存関係、および互換性とリダイレクト エンジンを含む、アプリケーションのコンテナーを作成します。 コンテナーは、アプリケーションとそのランタイムの分離を実現し、ユーザーのデバイスで実行されている他のアプリケーションへの影響や競合を回避できます。

ビジネス向け Microsoft Store を通じてビジネス アプリケーションを提供する方法の詳細については、[リリースに関するブログの記事](http://www.cloudhouse.com/resources/release-solution-to-get-any-line-of-business-app-to-uwp)をご覧ください。

#### <a name="firegiant"></a>FireGiant

[FireGiant Appx 拡張機能](https://www.firegiant.com/products/wix-expansion-pack/appx)を使用すると、同一の WiX ソース コードから Windows アプリ パッケージと MSI パッケージを同時に作成できます。 ビルドするたびに、Windows アプリ パッケージで Windows 10 のデスクトップ ブリッジをターゲットに、MSI で以前のバージョンの Windows ターゲットにすることができます。

<img width="20%" src="images/desktop-to-uwp/FG3rdPartyLogo.png">

FireGiant Appx 拡張機能では、WiX プロジェクトの静的分析とインテリジェント エミュレーションを使用して、コンテナーや仮想マシンによるディスク領域や実行時のオーバーヘッドが生じることなく、Windows アプリ パッケージを作成します。

FireGiant Appx 拡張機能は、実行することでインストーラーを変換するわけではありません。そのため、インストーラーを繰り返し Windows アプリ パッケージに変換する必要はなく、WiX インストーラーをそのまま維持できます。 さまざまな Windows バージョンのユーザーはすべて、最新の機能強化を入手できます。MSI と Windows アプリ パッケージが同期していないことを開発者が心配する必要はありません。

こちらの[ビデオ](https://www.youtube.com/watch?v=AFBpdBiAYQE)で、FireGiant CEO の Rob Mensching が数行のコードで人気のオープンソース 7-Zip 圧縮ツールの Appx (Windows アプリ パッケージ) バージョンを作成した方法や、同じ WiX ソース コードに変更を加えて Windows アプリ パッケージと MSI パッケージの両方を強化した方法を確認してください。

#### <a name="installaware"></a>InstallAware

Install**Aware** は、Microsoft の技術革新をすばやくサポートすることで[実績](https://www.installaware.com/press-room.htm)があり、1 つのソースから [Windows アプリ パッケージ (デスクトップ ブリッジ)](https://www.installaware.com/appx-builder.htm)、APP-V (アプリケーションの仮想化)、MSI (Windows インストーラー)、EXE (ネイティブ コード) パッケージを構築します。

<img width="20%" src="images/desktop-to-uwp/installaware.png">

Install**Aware** は、Visual Studio バージョン 2012 ～ 2017 に無料の Install**Aware** 拡張機能を提供しています。 これを使用すると、[Visual Studio ツールバー](https://www.installaware.com/visual-studio-installer-2015.htm)から直接 1 回クリックするだけで、Windows アプリ パッケージを作成できます。

また、そのセットアップのソース コードがない場合でも、Package**Aware** (スナップショットなしのセットアップ キャプチャ) または Database Import Wizard (すべての MSI インストーラーと MSM マージ モジュール用) を使用して、任意のセットアップをインポートできます。 [GUI ツール](https://www.installaware.com/scripting-two-way-integrated-ide.htm)を使用して、視覚的な方法またはスクリプトによって、インポートの保守と強化ができます。

[高度な APPX 作成オプション](https://www.installaware.com/mhtml5/desktop/appx.htm)を利用すると、Microsoft Store 申請のターゲットや、エンドユーザーに配布するサイドロード用の署名付き Windows アプリ パッケージ バイナリの生成が容易になります。 **Nano Server** に展開することを目的とした **WSA** (Windows Server アプリケーション) インストーラー パッケージをすべて 1 つのソースからビルドすることもできます。また、GUI に加えて、[コマンド ライン自動化](https://www.installaware.com/scripting-automation-interface.htm)の完全なサポートが提供されます。

Install**Aware** では、GNU Affero GPL ライセンスの下で **APPX Builder Library** を[オープン ソース](https://www.installaware.com/gnu.asp)にしており、コマンド ライン アプレットの例と一緒に公開しています。 これらは、WiX などのオープン ソース プラットフォームで使用することを目的としています。

#### <a name="installshield"></a>InstallShield

InstallShield は、MSI インストーラーと EXE インストーラーの開発、ユニバーサル Windows プラットフォーム (UWP) パッケージと Windows Server App (WSA) パッケージの作成、およびアプリケーションの仮想化を最小限のスクリプト作成、コーデイング、および作業のやり直しで実現する単一のソリューションを提供します。

<img width="20%" src="images/desktop-to-uwp/InstallShield-logo.jpg">

InstallShield プロジェクトを数秒でスキャンし、アプリケーションと UWP/WSA パッケージの間の潜在的な互換性の問題を自動的に特定することで、調査にかかる時間を短縮できます。

既存の InstallShield プロジェクトから UWP アプリ パッケージをビルドすることで、Microsoft Store に公開する準備をし、Windows 10 におけるソフトウェアのインストール エクスペリエンスを簡略化します。 Windows インストーラーと UWP アプリ パッケージの両方をビルドし、顧客の希望する展開シナリオをすべてサポートします。 既存の InstallShield プロジェクトから WSA パッケージをビルドし、Nano Server と Windows Server 2016 の展開をサポートします。

展開と保守が容易になるように、インストールをモジュール単位で開発します。その後、コンポーネントと依存関係をビルド時にマージして、Microsoft Store 向けの 1 つの UWP アプリ パッケージにします。 ストア外部で直接配布できるようにするには、UWP アプリ パッケージとその他の依存関係を Suite/Advanced UI インストーラーにバンドルします。

詳細はこちらの [eBook](https://na01.safelinks.protection.outlook.com/?url=https%3A%2F%2Fresources.flexerasoftware.com%2Fweb%2Fpdf%2FeBook-IS-Your-Fast-Track-to-Profit.pdf&data=02%7C01%7Cnormesta%40microsoft.com%7C86b9a00bc8e345c2ac6208d4ba464802%7C72f988bf86f141af91ab2d7cd011db47%7C1%7C1%7C636338258409706554&sdata=IAYNp9nFc8B5ayxwrs%2FQTWowUmOda6p%2Fn%2BjdHea257M%3D&reserved=0) をご覧ください。

#### <a name="pace-suite"></a>PACE Suite

[PACE Suite](https://pacesuite.com/) は、デスクトップ アプリをユニバーサル Windows プラットフォームに移行するために使うことができるアプリケーション パッケージ ツールです。

<img width="20%" src="images/desktop-to-uwp/PACE.png">

PACE Suite を使えば、特別なパッケージ環境を準備したり、追加の Windows SDK コンポーネントをインストールしたりする必要がありません。 PACE Suite は、Windows 10 または Windows Server 2016 の標準パッケージ環境で Windows アプリ パッケージを個別に構築できます。 この[図入りの例](https://pacesuite.com/convert-exe-to-appx/)で、PACE Suite が Windows アプリ パッケージへのインストーラーの再パッケージ化を処理する方法について確認してください。

Windows アプリ パッケージの作成とは別に、Windows インストーラー パッケージ (MSI)、更新プログラム (MSP)、変換 (MST)、App-V パッケージを作成するために PACE Suite を使うことができます。 MSI をオーサリングする段階になると、PACE Suite はアップグレード、アクセス許可の設定、カスタム アクション、スクリプトなどの管理に役立ちます。 System Center Configuration Manager に直接アプリケーションを発行することもできます。

すべてのアプリケーション パッケージ機能を確認するには、[PACE Suite の機能に関するページ](https://pacesuite.com/features/)をご覧ください。

#### <a name="rad-studio"></a>RAD Studio

[RAD Studio (提供元: Embarcadero)](https://www.embarcadero.com/products/rad-studio/windows-10-store-desktop-bridge) のページをご覧ください。

#### <a name="raypack-studio"></a>RayPack Studio

Raynet のパッケージ化ソリューション [RayPack Studio](https://raynet.de/Raynet-Products/RayPackStudio) では、効率的で構成しやすい変換および再パッケージ化フレームワークの結果の 1 つとして考えられるデスクトップ ブリッジがサポートされます。

<img width="20%" src="images/desktop-to-uwp/RaynetLogo_v3.png">

既存の仮想環境 (VMware Workstation、Hyper-V) を使って、時間がかかる環境のセットアップを行わなくても自動/一括変換を実行できます。 Studio のコンポーネント ([RayQC Advanced](https://raynet.de/Raynet-Products/RayQCad)) は、事前変換スクリーニングおよび互換性テストを行って、変換の対象となるソフトウェアを確認できます。 さらに、ユーザーは、Anniversary Update や Creators Update などのさまざまな Windows 10 エディションを使って、包括的な競合および互換性チェックを実行できるようになりました。

Windows 10 APPX/UWP 形式のソフトウェア パッケージの作成の次は、RayPack Studio を使って従来の Windows インストーラー パッケージ (MSI)、更新プログラム (MSP)、変換 (MST)、App-V パッケージを作成することもできます。 さらに、このソリューションには、一連のソフトウェア製品とプロフェッショナル向けエンタープライズ ソフトウェア パッケージ用のコンポーネントが付属しています。 ソフトウェアのパッケージ化と仮想化に加えて、RayPack Studio では、ソフトウェア アプリケーションとパッケージの競合および互換性チェック ([RayQC Advanced](https://raynet.de/Raynet-Products/RayQCad))、ソフトウェア評価 ([RayEval](https://raynet.de/Raynet-Products/RayEval))、品質保証 ([RayQC](https://raynet.de/Raynet-Products/RayQC)) というすべてのパッケージ化関連タスクが考慮されます。

Raynet のエンタープライズ ワークフロー システムである [RayFlow](https://raynet.de/Raynet-Products/RayFlow) と組み合わせると、ユーザーは、パッケージの注文から評価、分析、パッケージ化、品質保証、ユーザー受入テスト、展開まで、エンタープライズ アプリケーション ライフサイクル全体を通じてソフトウェアで効率的に作業することができます。 すべてのパッケージと形式は、SCCM や他のソリューションに直接保存して展開できます。 アプリケーション ライフ サイクル プロセス全体が RayFlow によって追跡および管理されます。 さらに、ServiceNow などのどの注文システムでも統合することができます。 Raynet では、自社のサービス プロバイダー向けツールを使って世界中でソフトウェア パッケージ ファクトリを作成しています。

ぜひ、Raynet の RayPack Studio および RayFlow の[無料試用版ライセンス](https://raynet.de/contact?init=license)を入手してください。 詳しくは、[www.raynet.de](https://raynet.de/home) をご覧ください。

**関連リンク**:

* Raynet: [https://raynet.de/home](https://raynet.de/home)
* RayPack Studio: [https://raynet.de/Raynet-Products/RayPackStudio](https://raynet.de/Raynet-Products/RayPackStudio)
* RayFlow: [https://raynet.de/Raynet-Products/RayFlow](https://raynet.de/Raynet-Products/RayFlow)
* RayEval: [https://raynet.de/Raynet-Products/RayEval](https://raynet.de/Raynet-Products/RayEval)
* RayQC: [https://raynet.de/Raynet-Products/RayQC](https://raynet.de/Raynet-Products/RayQC)
* RayQC Advanced: [https://raynet.de/Raynet-Products/RayQCad](https://raynet.de/Raynet-Products/RayQCad)
* 無料試用版ライセンス: [https://raynet.de/contact?init=license](https://raynet.de/contact?init=license)

### <a name="manual-packaging"></a>手動でのパッケージ化

最後のオプションとして、これらのツールを使わずにアプリを変換できます。 変換をきめ細かく制御する場合は、マニフェスト ファイルを作成し、**MakeAppx.exe** ツールを実行して Windows アプリ パッケージを作成します。

「[アプリを手動でパッケージ化する (デスクトップ ブリッジ)](desktop-to-uwp-manual-conversion.md)」をご覧ください。

## <a name="integrate"></a>統合

アプリをシステムと統合する必要がある場合 (ファイアウォール規則を確立する場合など)、アプリのパッケージ マニフェストにそのことを記述すると、システムによって残りの処理が行われます。 これらのタスクのほとんどは、まったくコードを記述する必要がありません。 マニフェストに少し XML を追加するだけで、ユーザーがログオンしたときにプロセスを開始する、アプリをエクスプローラーに統合する、他のアプリに表示される印刷先の一覧に対象アプリを追加する、などの処理を行うことができます。

「[Windows 10 にアプリを統合する (Windows デスクトップ ブリッジ)](desktop-to-uwp-extensions.md)」をご覧ください。

## <a name="enhance"></a>強化

アプリをパッケージ化すると、ライブ タイルやプッシュ通知などの機能を追加できます。 このような機能の中には、ほとんど時間をかけずに追加して、アプリのエンゲージメント レベルを大幅に向上できるものもあります。 もう少しコードの追加が必要になるものもあります。

「[Windows 10 向けのデスクトップ アプリを強化する](desktop-to-uwp-enhance.md)」をご覧ください。

## <a name="extend"></a>拡張

一部の Windows 10 エクスペリエンス (タッチ対応 UI ページなど) は、最新のアプリ コンテナー内で実行する必要があります。 一般的に、UWP API を使用して既存のデスクトップ アプリケーションを[強化](desktop-to-uwp-enhance.md)することでエクスペリエンスを追加できるかどうかを最初に判断する必要があります。 エクスペリエンスを実現するために UWP コンポーネントを使用する必要がある場合、ソリューションに UWP コンポーネントを追加すると、アプリ サービスを使用してデスクトップ アプリと UWP コンポーネントの間で通信を行うことができます。

「[最新の UWP コンポーネントによるデスクトップ アプリケーションの拡張](desktop-to-uwp-extend.md)」をご覧ください。

## <a name="migrate"></a>移行

デスクトップ アプリケーションを UWP アプリに変換できるツールはありませんが、多くの既存コードを再利用できるため、UWP アプリの作成コストを削減できます。 これは、できるだけ多くのビジネス ロジックを .NET Standard 2.0 ライブラリに移行することで行うことができます。

.NET Standard 2.0 では、お気に入りの NuGet パッケージとサード パーティ製ライブラリに対する互換性 shim が追加されているだけでなく、.NET API の数が大幅に増えています。

お持ちのコードを .NET Standard ライブラリに移行し、ユニバーサル Windows プラットフォーム (UWP) アプリを作成すると、すべての Windows 10 デバイスをターゲットにすることができます。

「[デスクトップ アプリと UWP アプリでコードを共有する](desktop-to-uwp-migrate.md)」をご覧ください


## <a name="test"></a>テスト

配布用の準備の一環として現実的な設定でアプリをテストするには、アプリに署名し、インストールすることをお勧めします。 「[アプリのテスト](https://docs.microsoft.com/en-us/windows/uwp/porting/desktop-to-uwp-debug#test-your-app)」をご覧ください。

>[!IMPORTANT]
> Microsoft Store にアプリを公開する場合は、Windows 10 を S モードで実行するデバイスでアプリが正しく動作することを確認してください。 これは、Microsoft Store 要件です。 「[Windows アプリの S モードの Windows 10 をテストする](desktop-to-uwp-test-windows-s.md)」をご覧ください。

## <a name="validate"></a>検証

作成したアプリを Microsoft Store に公開する、または [Windows 認定](http://go.microsoft.com/fwlink/p/?LinkID=309666)を受ける最善の方法は、認定のためアプリを提出する前に、ローカルでアプリの検証とテストを行うことです。

DAC を使ってアプリをパッケージ化する場合は、新しい ``-Verify`` フラグを使用することで、デスクトップ ブリッジとストアの要件に照らしてパッケージを検証できます。 「[アプリをパッケージ化し、アプリに署名して、ストアへの提出に備える](desktop-to-uwp-run-desktop-app-converter.md#optional-parameters)」をご覧ください。

Visual Studio を使用している場合は、**アプリ パッケージの作成**ウィザードでアプリを検証できます。 [アプリ パッケージ アップロード ファイルの作成に関するページ](../packaging/packaging-uwp-apps.md#create-an-app-package-upload-file)をご覧ください。

ツールを手動で実行する方法については、「[Windows アプリ認定キット](../debug-test-perf/windows-app-certification-kit.md)」をご覧ください。

Windows アプリ認定でアプリの検証に使用されるテストの一覧を確認するには、「[Windows デスクトップ ブリッジ アプリのテスト](../debug-test-perf/windows-desktop-bridge-app-tests.md)」をご覧ください。

## <a name="distribute"></a>配布

他のシステムにサイドローディングするか、Microsoft Store に公開することで、アプリを配布することができます。

「[パッケージ デスクトップ アプリの配布 (デスクトップ ブリッジ)](desktop-to-uwp-distribute.md)」をご覧ください。

## <a name="support-and-feedback"></a>サポートとフィードバック

**質問に対する回答を見つける**

ご質問がある場合は、 Stack Overflow でお問い合わせください。 Microsoft のチームでは、これらの[タグ](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge)をチェックしています。 [こちら](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D)から質問することもできます。

**フィードバックの提供または機能の提案を行う**

[UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial) のページをご覧ください。

## <a name="in-this-section"></a>このセクションの内容

| トピック | 説明 |
|-------|-------------|
| [アプリのパッケージ化の準備](desktop-to-uwp-prepare.md) | デスクトップ アプリをパッケージ化する前に確認する項目の一覧を示します。 |
| [Desktop App Converter を使用してアプリをパッケージ化する (デスクトップ ブリッジ)](desktop-to-uwp-run-desktop-app-converter.md) | Desktop App Converter を実行する方法が説明されています。 |
| [アプリを手動でパッケージ化する (デスクトップ ブリッジ)](desktop-to-uwp-manual-conversion.md) | 手動でアプリ パッケージとマニフェストを作成する方法について説明します。 |
| [Visual Studio を使った .NET アプリのパッケージ化 (デスクトップ ブリッジ)](desktop-to-uwp-packaging-dot-net.md)| Visual Studio を使ってデスクトップ アプリをパッケージ化する方法について説明します。 |
| [Windows 10 にアプリを統合する (デスクトップ ブリッジ)](desktop-to-uwp-extensions.md) | パッケージ プロジェクトのパッケージ マニフェスト ファイルにタスクを記述することで、アプリを Windows 10 と統合します。 |
| [Windows 10 向けのデスクトップ アプリを強化する](desktop-to-uwp-enhance.md)| UWP API を使用して、Windows 10 ユーザーの利便性を高める最新のエクスペリエンスを追加します。 |
| [パッケージ デスクトップ アプリで利用可能な UWP API (デスクトップ ブリッジ)](desktop-to-uwp-supported-api.md) | パッケージ化されたデスクトップ アプリで利用可能な UWP API を確認します。 |
| [最新の UWP コンポーネントによるデスクトップ アプリケーションの拡張](desktop-to-uwp-extend.md)| UWP アプリ コンテナー内で実行する必要がある高度なエクスペリエンスを追加します。 アプリ サービスを使用してデスクトップ アプリと UWP プロセスを接続します。|
| [パッケージ デスクトップ アプリの実行、デバッグ、テスト (デスクトップ ブリッジ)](desktop-to-uwp-debug.md) | パッケージ化されたアプリをデバッグするためのオプションについて説明します。 |
| [パッケージ デスクトップ アプリの配布 (デスクトップ ブリッジ)](desktop-to-uwp-distribute.md) | 変換済みのアプリをユーザーに配布する方法を確認します。  |
| [デスクトップ ブリッジの内側 (デスクトップ ブリッジ)](desktop-to-uwp-behind-the-scenes.md) | デスクトップ ブリッジのバックグラウンドでの処理について詳しく説明します。 |
| [既知の問題 (デスクトップ ブリッジ)](desktop-to-uwp-known-issues.md) | デスクトップ ブリッジに関する既知の問題について説明します。 |
| [デスクトップ ブリッジのコード サンプル](https://github.com/Microsoft/DesktopBridgeToUWP-Samples) | 変換されたアプリの機能を示す GitHub のコード サンプルです。 |
