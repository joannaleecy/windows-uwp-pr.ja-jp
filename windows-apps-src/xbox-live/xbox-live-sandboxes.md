---
title: Xbox Live のサンドボックス
author: KevinAsgari
description: Xbox Live 開発のためのサンドボックスについて説明します。
ms.assetid: a5acb5bf-dc11-4dff-aa94-6d1f01472d2a
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 63447a9423ab65f79f034877a1c74c1eea75c78c
ms.sourcegitcommit: 82c3fc0b06ad490c3456ad18180a6b23ecd9c1a7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/24/2018
ms.locfileid: "5468166"
---
# <a name="xbox-live-sandboxes-intro"></a>Xbox Live のサンドボックスの概要

「[Xbox Live サービス構成](xbox-live-service-configuration.md)」では、タイトルに関する情報をオンライン、通常は [Windows デベロッパー センター](http://dev.windows.com)で構成する必要があることを説明しました。  この情報には、タイトルで表示するランキングなどの項目、プレイヤーが解除できる実績、マッチメイキング構成などが含まれます。

サービス構成に変更を加える場合、それらの変更が Xbox Live の残りの部分によって取得されてタイトルで表示されるようにするには、デベロッパー センターから変更を公開する必要があります。

この公開先は、開発サンドボックスと呼ばれています。  これらにより、分離された環境でタイトルに対して変更作業を行うことができます。  これには、以下のセクションで説明するようにいくつかの利点があります。

既定では、Xbox One 本体と Windows 10 PC は RETAIL サンドボックスに格納されます。

## <a name="benefits"></a>利点

開発サンドボックスには、いくつかの利点があります。


1. 現在利用可能なバージョンに影響を与えずに、タイトルの更新への変更を反復処理できます。
2. 一部のツールは、セキュリティ上の理由から開発サンドボックス内でのみ動作します。
3. チーム内の一部の開発者は、開発中の主要なサービス構成に影響を与えずに、サービス構成の変更を「分岐」させてテストできます。
4. 他の公開元は、サンドボックスへのアクセス権が付与されない限り、その内部での作業内容を閲覧できません。

**必要に応じて**テスト アカウントを作成することもできます。  タイトルのテストに通常の Xbox Live アカウントを使用したくない場合や、ソーシャルな交流 (例: 友人の統計情報の表示) やマルチプレイヤーなどのシナリオをテストするために複数のアカウントが必要である場合に、テスト アカウントを使用できます。

テスト アカウントは開発サンドボックスにのみログインできます。以下のセクションで詳細を説明します。

## <a name="finding-out-about-your-sandbox"></a>サンドボックスを調べる

開発者の大部分は、サンドボックスを 1 つだけ必要とします。  幸いなことに、タイトルを作成するときにサンドボックスが作成されます。

1. サンドボックスについて調べるには、ここにあるデベロッパー センター ダッシュボードに移動します。
![](images/getting_started/first_xbltitle_dashboard.png)

1. 次に、タイトルをクリックします。
![](images/getting_started/first_xbltitle_dashboard_overview.png)

1. 最後に、左側のメニューで [サービス] -> [Xbox Live] をクリックします。
![](images/getting_started/first_xbltitle_leftnav.png)

1. これにより、次に示すようにサンドボックスが表示されます。
![](images/getting_started/devcenter_sandbox_id.png)

## <a name="how-your-sandbox-impacts-your-workflow"></a>サンドボックスがワークフローに与える影響

通常、サンドボックスは次の方法で操作します。

1. (1 回限り) PC または Xbox One を開発サンドボックスに切り替えます。
2. (複数回) サービス構成に変更を加えるときに、変更を開発サンドボックスに公開します。  サービス構成の変更には、実績の定義、ランキングの追加、マルチプレイヤー セッション テンプレートの変更などがあります。
3. (2、3 回) 他のチーム メンバーと作業する場合は、それらのメンバーにサンドボックスへのアクセス権を付与します。
4. (1 回限り) RETAIL で何かをテストする必要がある場合や、休憩を取ってお気に入りの Xbox ゲームをプレイする場合は、サンドボックスを元の RETAIL に切り替える必要があります。

これらのシナリオについて、以下で詳しく説明します。  PC と本体で処理が一部異なるため、それぞれ個別のセクションで説明します。

## <a name="switch-your-pcs-development-sandbox"></a>PC の開発サンドボックスを切り替える

PC の開発サンドボックスを切り替える場合、推奨される方法は Windows Device Portal (WDP) を使用する方法です。  この操作をコマンド ラインで実行することもできます。  両方の方法について説明します。

### <a name="windows-device-portal"></a>Windows Device Portal

お使いの PC で WDP を有効にしていない場合は、次の手順に従ってください。 [Windows デスクトップで Device Portal をセットアップする](https://msdn.microsoft.com/en-us/windows/uwp/debug-test-perf/device-portal-desktop)

この作業が終わったら、上記の記事で説明したように Web ブラウザーで Windows デベロッパー ポータルに接続してポータルを開きます。

続いて、次に示すように [Xbox Live] をクリックして該当するセクションに移動します。

![](images/getting_started/wdp_switch_sandbox.png)

さらに、*「サンドボックスを調べる」* の手順で表示されたサンドボックスを入力し、[変更] をクリックします。

RETAIL に戻るには、ここで「RETAIL」と入力します。

### <a name="powershell-module"></a>PowerShell モジュール

[Xbox Live PowerShell モジュール](https://github.com/Microsoft/xbox-live-powershell-module/blob/master/docs/XboxLivePsModule.md)XboxlivePSModule には、PC または本体でサンドボックスを変更する機能など、Xbox Live の開発のためのさまざまなユーティリティが含まれています。

* [PowerShell ギャラリー](https://www.powershellgallery.com/packages/XboxlivePSModule)からこのモジュールを使うには、PowerShell ウィンドウを開きます。
    1. 次のコマンドを実行して、モジュールをダウンロードしてインストールします。 `Install-Module XboxlivePSModule -Scope CurrentUser`
    2. 次のコマンドを実行して使用を開始します。 `Import-Module XboxlivePSModule`
    3. コマンドレット Set-XblSandbox XDKS.1 または Get-XblSandbox を実行します。

* ある zip ファイルから使用する[https://aka.ms/xboxliveuwptools](https://aka.ms/xboxliveuwptools)、PowerShell ウィンドウを開きます
    1. 実行 `Import-Module <path to unzipped folder>\XboxLivePsModule\XboxLivePsModule.psd1`
    2. コマンドレット Set-XblSandbox XDKS.1 または Get-XblSandbox を実行します。

### <a name="command-prompt-script"></a>コマンド プロンプト スクリプト

[https://aka.ms/xboxliveuwptools](https://aka.ms/xboxliveuwptools) で Xbox Live ツール パッケージをダウンロードし、解凍します。  中には SwitchSandbox.cmd バッチ ファイルがあります。

サンドボックスを切り替えるには、管理者モードでこのバッチ ファイルを実行します。  最初の引数がサンドボックスです。  たとえば、XDKS.1 サンドボックスに切り替える場合は、次のコマンドを実行します。

```
SwitchSandbox.cmd XDKS.1
```

RETAIL に戻るには、2 番目の引数として RETAIL を指定するだけです。

```
SwitchSandbox.cmd RETAIL
```

## <a name="switch-your-xbox-one-console-development-sandbox"></a>Xbox One 本体の開発サンドボックスを切り替える

### <a name="using-windows-dev-portal"></a>Windows デベロッパー ポータルを使用する

Windows デベロッパー ポータルを使用して、本体でサンドボックスを変更できます。  これを行うには、お使いの本体で [Dev Home] (開発者ホーム) に移動して本体を有効にします。

その後、PC の Web ブラウザーに IP アドレスを入力して、本体に接続できます。  続いて [Xbox Live] をクリックし、そこにあるテキスト ボックスにサンドボックスを入力します。

### <a name="using-xbox-one-manager"></a>Xbox One Manager を使用する

Xbox One Manager を使用して、本体の特定の側面を PC から管理できます。  これには、再起動、インストールされているアプリの管理、サンドボックスの変更が含まれます。

サンドボックスを変更する本体を右クリックし、[設定…] に移動します。

そこでサンドボックスを入力できます。

### <a name="using-xbox-one-console-ui"></a>Xbox One 本体の UI を使用する

本体から直接、開発サンドボックスを変更する場合は、[Settings] に移動します。  続いて [Developer Settings] に移動すると、サンドボックスを変更するオプションが表示されます。

## <a name="sandbox-uses"></a>サンドボックスの使用

### <a name="data-that-is-sandboxed"></a>サンドボックス化されるデータ
サンドボックス機能を使用すると、開発プロセス中にチーム内の開発者の間でアクセスを管理できます。  たとえば、開発チームとテスターの間でデータを分離できます。

サンドボックス化されるデータは次のとおりです。
- ユーザーの実績、ランキング、統計情報。  あるサンドボックス内で 1 人のユーザーに対して蓄積された実績は、別のサンドボックスには変換されません。
- マルチプレイヤー、マッチメイキング。  異なるサンドボックスに属するユーザーと一緒にマルチプレーヤー ゲームをプレイすることはできません。
- サービス構成。  あるサンドボックス内で新しい実績をタイトルに追加しても、異なるサンドボックス内では表示されません。  これは、すべてのサービス構成データに適用されます。

サンドボックス化されないデータは、主にソーシャル情報です。  たとえば、ユーザーが別のユーザーをフォローする場合、その関係はサンドボックスに依存しません。

### <a name="examples"></a>例
以下に、複数のサンドボックスを使用する利点を理解するのに役立つ例をいくつか示します。

> **注**: Xbox クリエーターズ プログラムに参加している場合は、1 つのサンドボックスのみを使用できます。  複数のサンドボックスを作成する必要がある場合は、ID@Xbox プログラムにご登録ください。

#### <a name="service-config-isolation"></a>サービス構成の分離
前述したように、サービス構成はサンドボックスに固有です。  そのため、たとえば *Development* サンドボックスと *Testing* サンドボックスを併用できます。  タイトルのビルドをテスターに提供する場合は、[サービス構成](xbox-live-service-configuration.md)を *Testing* サンドボックスに公開します。

その一方で、テスターに対して表示されているサービス構成に影響を与えずに、実績や異なるマルチプレイヤー セッションの種類を *Development* サンドボックスに追加できます。

#### <a name="multiplayer"></a>マルチ プレーヤー
上記の例のように、*Development* と *Testing* のサンドボックスを使用しているとします。  サービス構成はどちらのサンドボックスも同じかもしれませんが、開発者はマルチプレイヤー機能を作成しており、相互にマッチメイキングをテストしたいと考えています。  テスターもマルチプレイヤーをテストしています。

このような場合、テスターは個別に問題をデバッグしているため、開発者は Xbox Live マッチメイキング サービスでテスターをマッチング対象にしたくないと考えている可能性があります。  これを防止する効果的な方法として、開発者向けに *Development* サンドボックスを、テスター向けに別個の *Testing* サンドボックスを使用できます。  これにより、両方のグループを分離します。

## <a name="advanced"></a>高度な設定

開発プロセスを簡潔にするには、既定のサンドボックスで開始し、新しいサンドボックスを慎重に追加します。

アクセス制御とデータ分離のニーズが高まっていることに気付いたら、「[高度な Xbox Live のサンドボックス](advanced-xbox-live-sandboxes.md)」の記事を参照してください。  
