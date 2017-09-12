---
author: normesta
Description: "既存の Windows フォーム、WPF、または Win32 アプリやゲームに対して、最新の Windows アプリ パッケージを作成します。 Windows 10 ユーザー向けに最新のエクスペリエンスを追加し、展開と収益化を簡略化します。"
Search.Product: eADQiWindows 10XVcnh
title: "デスクトップ ブリッジ"
ms.author: normesta
ms.date: 05/25/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp
ms.assetid: 74373c24-f948-43bb-aa85-01e2e8e87162
ms.openlocfilehash: 1830c1661325afe68e8e7cd32528ec075e098b1d
ms.sourcegitcommit: 77bbd060f9253f2b03f0b9d74954c187bceb4a30
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/11/2017
---
# <a name="desktop-bridge"></a>デスクトップ ブリッジ

既存のデスクトップ アプリを利用して、Windows 10 ユーザー向けの最新のエクスペリエンスを追加します。 Windows ストアを通じてアプリを配布し、国際市場でのリーチを拡大します。 ストアに直接組み込まれている機能を活用することで、より簡単に、アプリの収益化ができます。 もちろん、ストアを使用する必要はありません。 既存のチャンネルを自由に使用してください。
<div style="float: left; padding: 10px">
    ![Desktop to UWP Bridge のイメージ](images/desktop-to-uwp/desktop-bridge-4.png)
</div>
Desktop to UWP Bridge は、最新の Windows アプリ パッケージを使用して開発者が Windows フォーム、WPF、または Win32 アプリやゲームを効率的に配布できるようにするため、プラットフォームに組み込まれているインフラストラクチャです。

このパッケージは、アプリに ID を提供します。デスクトップ アプリは、その ID を使用してユニバーサル Windows プラットフォーム (UWP) API にアクセスできます。 これを利用して、ライブ タイルや通知など、現代的で魅力的なエクスペリエンスを実現できます。  アプリが Windows 10 で実行される場合にのみ、単純な条件付きコンパイルとランタイム チェックを使用して、UWP コードを実行します。

Windows 10 エクスペリエンスを実現するために使用するコード以外は、アプリは元のままです。引き続き、そのアプリを既存の Windows 7、Windows Vista、または Windows XP のユーザーに配布できます。 Windows 10 では、このアプリを現在のアプリと同じように、完全な信頼ユーザー モードで引き続き実行できます。

> [!NOTE]
> Microsoft Virtual Academy から公開されている、<a href="https://mva.microsoft.com/en-US/training-courses/developers-guide-to-the-desktop-bridge-17373?l=oZG0B1WhD_8406218965/">このシリーズ</a>の短いビデオをご覧ください。 これらのビデオでは、デスクトップ アプリをユニバーサル Windows プラットフォーム (UWP) に移行するプロセスをすべて説明しています。

## <a name="benefits"></a>利点

以下に、デスクトップ アプリケーションの Windows アプリ パッケージを作成する理由を示します。

**スムーズな展開プロセス**。 ブリッジを使用しているアプリやゲームでは、優れた展開エクスペリエンスが提供されます。 このエクスペリエンスにより、ユーザーが安心してアプリのインストールおよび更新を行うことができます。 ユーザーがアプリをアンインストールすると、跡形なく完全に削除されます。 このため、セットアップ エクスペリエンスの設計や、更新プログラムの配信にかかる時間を削減できます。

**自動更新とライセンス**。 アプリは、Windows ストアの組み込みライセンスと自動更新機能に参加できます。 自動更新機能は、ファイルの変更された部分だけがダウンロードされるため、非常に信頼性が高く効率的なメカニズムです。

**リーチの拡大とシンプルな決済**。 Windows ストアからの配布なら、数百万人の Windows 10 ユーザーにリーチを拡大できます。ユーザーは、アプリとゲームの購入や、アプリ内での購入に各地域の支払い方法を使用できます。

**UWP 機能の追加**。  自分のペースで、XAML ユーザー インターフェイス、ライブ タイルの更新、UWP バックグラウンド タスク、アプリ サービスなどの多くの UWP 機能をアプリのパッケージに追加できます。

**対応デバイスの拡大**。 ブリッジを使用すると、徐々にコードをユニバーサル Windows プラットフォームに移行して、電話、Xbox One、HoloLens など、すべての Windows 10 デバイスを対象にできます。

利点の完全な一覧については、「[デスクトップ ブリッジ](https://developer.microsoft.com/windows/bridges/desktop)」をご覧ください。

## <a name="prepare"></a>準備

アプリを [Windows アプリ ストア](https://www.microsoft.com/store/apps)に公開する予定はありますか?  その場合は、まず[このフォーム](https://developer.microsoft.com/windows/projects/campaigns/desktop-bridge)に必要事項を入力してください。 Microsoft から、オンボード プロセスを開始するための連絡があります。 このプロセスでは、ストア内の名前を予約し、Windows アプリ パッケージを作成するための情報を取得します。

次に、「[アプリのパッケージ化の準備](desktop-to-uwp-prepare.md)」を読み、アプリに該当する点があれば、Windows アプリ パッケージを作成する前に対処してください。 パッケージを作成する前に、多くの変更を加える必要はないかもしれません。 ただし、状況によっては、パッケージを作成する前にアプリへの調整が必要になる場合があります。

<span id="convert" />
## <a name="package"></a>パッケージ化

アプリの Windows アプリ パッケージを作成するには、以下のようなツールを使用できます。

### <a name="desktop-app-converter"></a>Desktop App Converter

このツールの名前には "Converter" という用語が含まれますが、実は、アプリの変換は行いません。 アプリは変更されません。 しかし、Windows アプリ パッケージが生成されます。 アプリによって多くのシステム変更が行われる場合や、インストーラーの処理について不明確な点がある場合に便利です。

また、Desktop App Converter には、変換以外にも役に立つ機能があります。 その一部を次に示します。

* プレビュー ハンドラー、サムネイル ハンドラー、プロパティ ハンドラー、ファイアウォール規則、URL フラグを自動的に登録する。

* ファイルの種類のマッピングを自動的に登録する。これによりユーザーは、エクスプローラーの **[種類]** 列を使ってファイルをグループ化できるようになります。

* 公開 COM サーバーを登録する。

* アプリの実行に使用できる証明書を生成する。

* デスクトップ ブリッジと Windows ストアの要件に照らしてアプリを検証する。

「[Desktop App Converter を使用してアプリをパッケージ化する (Desktop to UWP Bridge)](desktop-to-uwp-run-desktop-app-converter.md)」をご覧ください。

### <a name="manual-packaging"></a>手動でのパッケージ化

変換をきめ細かく制御する場合は、マニフェスト ファイルを作成し、**MakeAppx.exe** ツールを実行して Windows アプリ パッケージを作成します。

この方法は、インストーラーによるシステムへの変更点が明確である場合や、インストーラーがなく、フォルダー場所へのファイルの物理コピーや **xcopy** などのコマンドの使用をアプリのインストール方法としている場合に適している可能性があります。 ただし、インストーラーがないことを理由にアプリを手動でパッケージ化することは、適切であるとは限りません。 Desktop App Converter を使用すると、インストーラーがなくてもアプリをパッケージ化できます。

「[アプリを手動でパッケージ化する (Desktop to UWP Bridge)](desktop-to-uwp-manual-conversion.md)」をご覧ください。

### <a name="visual-studio"></a>Visual Studio

このオプションは上に示した手動変換に似ていますが、Visual Studio では、アプリ パッケージやアプリのビジュアル資産を生成するなどの処理も自動的に行われます。 Visual Studio は、アプリを手動でパッケージ化するために使用できる、便利な機能付きのツールであると考えることができます。

「[Visual Studio を使った .NET アプリのパッケージ化 (Desktop to UWP Bridge)](desktop-to-uwp-packaging-dot-net.md)」をご覧ください。

### <a name="third-party-installer"></a>サードパーティ インストーラー

 いくつかのポピュラーなサード パーティ製品やインストーラーでは、Desktop to UWP Bridge がサポートされるようになりました。 これらを使用すると、わずか数クリックで MSI インストーラーやアプリ パッケージを生成することができます。 これらのツールの使用方法について詳しくは、それぞれの製品の Web サイトをご覧ください。

 いくつかのオプションを次に示します。

#### <a name="advanced-installer"></a>Advanced Installer

Caphyon は、わずか数回のクリックでアプリケーションの Windows アプリ パッケージを生成できる、GUI ベースのデスクトップ アプリ パッケージ作成ツールを無料で提供しています。 このツールでは、サイレント モードで実行されるものも含めて、どのようなインストーラーでもパッケージ化できます。また、アプリがパッケージ化に適しているかどうかを判断するための妥当性チェックも実行できます。
<div style="float: left; padding: 10px; width: 20%">
     ![Advanced Installer ロゴ](images/desktop-to-uwp/Advanced_Installer_Vertical.png)
</div>
Desktop App Converter は、Hyper-V および [VMware](http://www.vmware.com/) にも統合できます。 つまり、独自の仮想マシンを使用することができるため、サイズが 3 GB を超える可能性がある [Docker](https://docs.docker.com/) イメージをダウンロードする必要はありません。

[Advanced Installer](http://www.advancedinstaller.com/) を使用すると、既存のプロジェクトから MSI と [Windows アプリ パッケージ](http://www.advancedinstaller.com/uwp-app-package.html)を生成できます。 また、Advanced installer では、Microsoft Desktop App Converter を使用して生成した Windows アプリ パッケージをインポートすることもできます。 インポートしたアプリ パッケージは、UWP アプリ用に設計されたビジュアル ツールを使用して管理できます。

Advanced Installer では、Visual Studio 2017 および 2015 用の拡張機能も提供されており、これらは[デスクトップ ブリッジ アプリのビルドとデバッグ](http://www.advancedinstaller.com/debug-desktop-bridge-apps.html)に使用できます。

簡単な紹介については、こちらの[ビデオ](https://www.youtube.com/watch?v=cmLKgn04Vfg&feature=youtu.be)をご覧ください。

#### <a name="cloudhouse-compatibility-containers"></a>Cloudhouse 互換性コンテナー

Windows 10 および Windows 10 S と互換性のない基幹業務アプリケーションを利用している企業ユーザーの場合、Cloudhouse の互換性コンテナーを使用すると、ソース コードを変更することなく Windows XP アプリケーションと Windows 7 アプリケーションを UWP に変換して、ビジネス向け Windows ストアや Microsoft Intune を通じて配布できます。
<div style="float: left; padding: 10px; width: 20%">
     ![Cloudhouse 互換性コンテナー](images/desktop-to-uwp/container.png)
</div>
Cloudhouse は、Auto Packager を提供しています。このツールは、任意のアプリケーションを受け取り、現在実行しているプラットフォーム (Windows XP など) でアプリをパッケージ化して、互換性コンテナーを作成します。 コンテナーはその後、Desktop Bridge Converter ツールと統合して Windows アプリ パッケージを作成することで、新しい UWP 形式に変換できます。

Auto Packager では、インストール/キャプチャおよび実行時分析を使用して、アプリケーション ファイルとレジストリおよび互換性とリダイレクト エンジンを含むアプリケーションのコンテナーを作成して、アプリケーションを Windows 10 で実行できるようにします。 さらに、インストール済みの他のアプリケーションやランタイムへの影響や競合が発生しないように、アプリケーションの実行に必要な任意のランタイムや前提条件を含めたり、分離したりできます。


ユニバーサル Windows アプリとビジネス向け Windows ストアのサポートについて発表した同社の[ブログ](http://www.cloudhouse.com/resources/release-solution-to-get-any-line-of-business-app-to-uwp)をご覧ください。

#### <a name="firegiant"></a>FireGiant

[FireGiant Appx 拡張機能](https://www.firegiant.com/products/wix-expansion-pack/appx)を使用すると、同一の WiX ソース コードから Windows アプリ パッケージと MSI パッケージを同時に作成できます。 ビルドするたびに、Windows アプリ パッケージで Windows 10 のデスクトップ ブリッジをターゲットに、MSI で以前のバージョンの Windows ターゲットにすることができます。
<div style="float: left; padding: 10px; width: 20%">
     ![Advanced Installer ロゴ](images/desktop-to-uwp/FG3rdPartyLogo.png)
</div>
FireGiant Appx 拡張機能では、WiX プロジェクトの静的分析とインテリジェント エミュレーションを使用して、コンテナーや仮想マシンによるディスク領域や実行時のオーバーヘッドが生じることなく、Windows アプリ パッケージを作成します。

FireGiant Appx 拡張機能は、実行することでインストーラーを変換するわけではありません。そのため、インストーラーを繰り返し Windows アプリ パッケージに変換する必要はなく、WiX インストーラーをそのまま維持できます。 さまざまな Windows バージョンのユーザーはすべて、最新の機能強化を入手できます。MSI と Windows アプリ パッケージが同期していないことを開発者が心配する必要はありません。

こちらの[ビデオ](https://www.youtube.com/watch?v=AFBpdBiAYQE)で、FireGiant CEO の Rob Mensching が数行のコードで人気のオープンソース 7-Zip 圧縮ツールの Appx (Windows アプリ パッケージ) バージョンを作成した方法や、同じ WiX ソース コードに変更を加えて Windows アプリ パッケージと MSI パッケージの両方を強化した方法を確認してください。

#### <a name="installaware"></a>InstallAware

Install**Aware** は、Visual Studio バージョン 2012 ～ 2017 に無料の Install**Aware** 拡張機能を提供しています。 これを使用すると、[Visual Studio ツールバー](https://www.installaware.com/visual-studio-installer-2015.htm)から直接 1 回クリックするだけで、Windows アプリ パッケージを作成できます。
<div style="float: left; padding: 10px; width: 20%">
    ![FireGiant ロゴ](images/desktop-to-uwp/installaware.png)
</div>
また、そのセットアップのソース コードがない場合でも、Package**Aware** (スナップショットなしのセットアップ キャプチャ) または Database Import Wizard (すべての MSI インストーラーと MSM マージ モジュール用) を使用して、任意のセットアップをインポートできます。 [GUI ツール](https://www.installaware.com/scripting-two-way-integrated-ide.htm)を使用して、視覚的な方法またはスクリプトによって、インポートの保守と強化ができます。

[高度な APPX 作成オプション](https://www.installaware.com/mhtml5/desktop/appx.htm)を利用すると、Windows ストア申請のターゲットや、エンドユーザーに配布するサイドロード用の署名付き Windows アプリ パッケージ バイナリの生成が容易になります。 **Nano Server** に展開することを目的とした **WSA** (Windows Server アプリケーション) インストーラー パッケージをすべて 1 つのソースからビルドすることもできます。また、GUI に加えて、[コマンド ライン自動化](https://www.installaware.com/scripting-automation-interface.htm)の完全なサポートが提供されます。

Install**Aware** では、GNU Affero GPL ライセンスの下で **APPX Builder Library** を[オープン ソース](https://www.installaware.com/gnu.asp)にしており、コマンド ライン アプレットの例と一緒に公開しています。 これらは、WiX などのオープン ソース プラットフォームで使用することを目的としています。

#### <a name="installshield"></a>InstallShield

InstallShield は、MSI インストーラーと EXE インストーラーの開発、ユニバーサル Windows プラットフォーム (UWP) パッケージと Windows Server App (WSA) パッケージの作成、およびアプリケーションの仮想化を最小限のスクリプト作成、コーデイング、および作業のやり直しで実現する単一のソリューションを提供します。
<div style="float: left; padding: 10px; width: 20%">
    ![InstallShield ロゴ](images/desktop-to-uwp/InstallShield-logo.jpg)
</div>
InstallShield プロジェクトを数秒でスキャンし、アプリケーションと UWP/WSA パッケージの間の潜在的な互換性の問題を自動的に特定することで、調査にかかる時間を短縮できます。

既存の InstallShield プロジェクトから UWP アプリ パッケージをビルドすることで、Windows ストアに公開する準備をし、Windows 10 におけるソフトウェアのインストール エクスペリエンスを簡略化します。 Windows インストーラーと UWP アプリ パッケージの両方をビルドし、顧客の希望する展開シナリオをすべてサポートします。 既存の InstallShield プロジェクトから WSA パッケージをビルドし、Nano Server と Windows Server 2016 の展開をサポートします。

展開と保守が容易になるように、インストールをモジュール単位で開発します。その後、コンポーネントと依存関係をビルド時にマージして、Windows ストア向けの 1 つの UWP アプリ パッケージにします。 ストア外部で直接配布できるようにするには、UWP アプリ パッケージとその他の依存関係を Suite/Advanced UI インストーラーにバンドルします。

詳細はこちらの [eBook](https://na01.safelinks.protection.outlook.com/?url=https%3A%2F%2Fresources.flexerasoftware.com%2Fweb%2Fpdf%2FeBook-IS-Your-Fast-Track-to-Profit.pdf&data=02%7C01%7Cnormesta%40microsoft.com%7C86b9a00bc8e345c2ac6208d4ba464802%7C72f988bf86f141af91ab2d7cd011db47%7C1%7C1%7C636338258409706554&sdata=IAYNp9nFc8B5ayxwrs%2FQTWowUmOda6p%2Fn%2BjdHea257M%3D&reserved=0) をご覧ください。


#### <a name="rad-studio"></a>RAD Studio

[RAD Studio (提供元: Embarcadero)](https://www.embarcadero.com/products/rad-studio/windows-10-store-desktop-bridge) のページをご覧ください。

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

Windows デスクトップでアプリを実行および公開する機能を維持しつつ、コードを徐々に UWP に移行できます。 UWP に完全に移行 (アプリに WPF/Win32 コンポーネントが含まれていない状態に) すると、スマートフォン、Xbox One、HoloLens などすべての Windows デバイスでの使用が可能になります。

## <a name="test"></a>テスト

配布用の準備の一環として現実的な設定でアプリをテストするには、アプリに署名し、インストールすることをお勧めします。 「[アプリのテスト](https://docs.microsoft.com/en-us/windows/uwp/porting/desktop-to-uwp-debug#test-your-app)」をご覧ください。

>[!IMPORTANT]
> Windows ストアにアプリを公開する場合は、Windows 10 S を実行するデバイスでアプリが正しく動作することを確認してください。これは、ストア要件です。 「[Windows アプリの Windows 10 S 対応をテストする](desktop-to-uwp-test-windows-s.md)」をご覧ください。

## <a name="validate"></a>検証

作成したアプリを Windows ストアに公開する、または、[Windows 認定](http://go.microsoft.com/fwlink/p/?LinkID=309666)を受ける一番の方法は、認定のためアプリを提出する前に、ローカルでアプリの検証とテストを行うことです。

DAC を使ってアプリをパッケージ化する場合は、新しい ``-Verify`` フラグを使用することで、デスクトップ ブリッジとストアの要件に照らしてパッケージを検証できます。 「[アプリをパッケージ化し、アプリに署名して、ストアへの提出に備える](desktop-to-uwp-run-desktop-app-converter.md#optional-parameters)」をご覧ください。

Visual Studio を使用している場合は、**アプリ パッケージの作成**ウィザードでアプリを検証できます。 「[アプリ パッケージを作成する](../packaging/packaging-uwp-apps.md#create-an-app-package)」をご覧ください。

ツールを手動で実行する方法については、「[Windows アプリ認定キット](../debug-test-perf/windows-app-certification-kit.md)」をご覧ください。

Windows アプリ認定でアプリの検証に使用されるテストの一覧を確認するには、「[Windows デスクトップ ブリッジ アプリのテスト](../debug-test-perf/windows-desktop-bridge-app-tests.md)」をご覧ください。

## <a name="distribute"></a>配布

他のシステムにサイドローディングするか、Windows ストアに公開することで、アプリを配布することができます。

「[パッケージ デスクトップ アプリの配布 (デスクトップ ブリッジ)](desktop-to-uwp-distribute.md)」をご覧ください。

## <a name="support-and-feedback"></a>サポートとフィードバック

**特定の質問に対する回答を見つける**

マイクロソフトのチームでは、[StackOverflow タグ](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge)をチェックしています。

**フィードバックの提供または機能の提案を行う**

[UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial) のページをご覧ください。

**この記事に関するフィードバックを送信する**

下のコメント セクションをご利用ください。

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
| [デスクトップ ブリッジの内側 (デスクトップ ブリッジ)](desktop-to-uwp-behind-the-scenes.md) | Desktop to UWP Bridge の内部的な処理について詳しく説明します。 |
| [既知の問題 (デスクトップ ブリッジ)](desktop-to-uwp-known-issues.md) | Desktop to UWP Bridge に関する既知の問題について説明します。 |
| [デスクトップ ブリッジのコード サンプル](https://github.com/Microsoft/DesktopBridgeToUWP-Samples) | 変換されたアプリの機能を示す GitHub のコード サンプルです。 |
