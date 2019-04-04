---
title: ルーズ ファイルの登録によるアプリの展開
description: このガイドでは、圧縮しないファイルのレイアウトを使用して検証し、パッケージ化することがなく、Windows 10 アプリを共有する方法を示します。
ms.date: 6/1/2018
ms.topic: article
keywords: windows 10、uwp、デバイスのポータル、apps manager、デプロイ、sdk
ms.localizationpriority: medium
ms.openlocfilehash: 928c07bd23228f0fefd78be6019a0d116b2e6e4b
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57635427"
---
# <a name="deploy-an-app-through-loose-file-registration"></a>ルーズ ファイルの登録によるアプリの展開 

このガイドでは、圧縮しないファイルのレイアウトを使用して検証し、パッケージ化することがなく、Windows 10 アプリを共有する方法を示します。 圧縮しないファイルのレイアウトを登録すると、開発者をパッケージ化し、アプリをインストールする必要はありませんがアプリをすばやく検証ができます。 

## <a name="what-is-a-loose-file-layout"></a>圧縮しないファイルのレイアウトとは何ですか。

圧縮しないファイルのレイアウトは単に、アプリの内容をパッケージ化プロセスを通過するのではなくフォルダーに配置するのです。 パッケージの内容は、「疎」フォルダーで使用可能なパッケージ化されません。 です。 

> [!WARNING]
> 圧縮しないファイル レイアウトの登録は、アクティブな開発中のアプリをすばやく検証するには、開発者および設計者です。 このアプローチは、「ドッグフード」するために使用またはアプリのフライトしないでください。 信頼された証明書で署名されたパッケージのアプリで最終的な検証を実行することをお勧めします。 

## <a name="advantages-of-loose-file-registration"></a>圧縮しないファイルの登録の利点

- **クイック検証**-ユーザーの圧縮しないファイルのレイアウトを登録し、アプリを起動できますすばやくアプリのファイルが既にアンパックしないため、します。 通常、アプリと同様、ユーザーは設計されたとおりにアプリを使用することになります。 
- **簡単にネットワークで配布**-圧縮しないファイルがローカル ドライブではなくネットワーク共有内にある、開発者は、ネットワークへのアクセスを持つその他のユーザーにネットワーク共有の場所を送信することができます、および圧縮しないファイルのレイアウトを登録して実行できる場合、アプリ。 これにより、複数のユーザーに同時に、アプリを検証します。 
- **コラボレーション**-圧縮しないファイルの登録により、アプリを登録中に、ビジュアル アセットで作業を続行するには、開発者および設計者です。 アプリの起動時には、これらの変更が表示されます。 この方法で静的なアセットをのみ変更できることに注意してください。 任意のコードまたは動的に作成されたコンテンツを変更する必要がある場合は、アプリを再コンパイルする必要があります。

## <a name="how-to-register-a-loose-file-layout"></a>圧縮しないファイルのレイアウトを登録する方法

Windows には、ローカルおよびリモート デバイスで圧縮しないファイルのレイアウトを登録する複数の開発者ツールが用意されています。 選択できます`WinDeployAppCmd`(Windows SDK ツール)、Windows Device Portal、PowerShell、および[Visual Studio](https://docs.microsoft.com/windows/uwp/debug-test-perf/deploying-and-debugging-uwp-apps#register-layout-from-network)します。 以下これらのツールを使用して圧縮しないファイルを登録する方法が変わります。 ただし、最初に、次のセットアップがあることを確認します。

- デバイスは、Windows 10 Creators Update (ビルド 14965) 以降である必要があります。
- 有効にする必要があります[開発者モード](https://msdn.microsoft.com/windows/uwp/get-started/enable-your-device-for-development)と[デバイスの検出](https://docs.microsoft.com/en-us/windows/uwp/get-started/enable-your-device-for-development#device-discovery)すべてのデバイスでします。

> [!IMPORTANT]
> 圧縮しないファイルの登録では、ネットワーク共有 (SMB) プロトコルをサポートするデバイスで使用可能なのみです。デスクトップ、Xbox。 

### <a name="register-with-windeployappcmd"></a>WinDeployAppCmd 登録します。

以降、Windows 10 Creators Update (ビルド 14965) に対応する SDK ツールを使用している場合を使用できます、`WinDeployAppCmd`コマンド プロンプトでコマンド。

```cmd
WinAppDeployCmd.exe registerfiles -remotedeploydir <Network Path> -ip <IP Address> -pin <target machine PIN>
```

**ネットワーク パス**– アプリのルーズ ファイルへのパス。

**IP アドレス**– ターゲット マシンの IP アドレス。

**ターゲット マシン PIN** – PIN、ターゲット デバイスとの接続を確立するために、必要な場合。 再試行する求め、`-pin`認証が必要な場合はオプションです。 参照してください[デバイスの検出](https://docs.microsoft.com/windows/uwp/get-started/enable-your-device-for-development#device-discovery)に PIN を取得する方法について説明します。

### <a name="windows-device-portal"></a>Windows Device Portal

Windows Device Portal では、すべての Windows 10 デバイスで利用し、テストおよび検証作業する開発者によって使用されます。 すべての対象ユーザーとそのブラウザー UX 開発者コミュニティのおよび REST エンドポイントに対応します。 デバイスのポータルの詳細については、、 [Windows Device Portal 概要](device-portal.md)を参照してください。

デバイスのポータルで、圧縮しないファイルのレイアウトを登録するに次の手順に従います。

1. 次の手順に従って、デバイス ポータルへの接続、**セットアップ**のセクション、 [Windows Device Portal 概要](device-portal.md)。
1. Apps Manager タブで、次のように選択します。**ネットワーク共有から登録**します。
1. 圧縮しないファイルのレイアウトには、ネットワーク共有のパスを入力します。 
1. ネットワーク共有へのアクセスがない場合、ホスト デバイスの場合は、必要な資格情報の入力を求めるメッセージがあります。
1. 登録が完了すると、アプリを起動できます。

Apps Manager ページで、デバイス ポータルの登録することも省略可能な圧縮しないファイルのレイアウトをメイン アプリを選択して、**省略可能なパッケージを指定する**チェック ボックスをオンし、ネットワークを指定する省略可能なアプリのパスを共有します. 

### <a name="powershell"></a>PowerShell 

Windows PowerShell を使用して、ローカルのデバイスだけに、ルース ファイル レイアウトを登録することもできます。 リモート デバイスへのレイアウトを登録する必要がある場合は、その他の方法のいずれかを使用する必要があります。 

圧縮しないファイルのレイアウトを登録するには、PowerShell を起動し、次を入力します。

```PowerShell
Add-AppxPackage -Register <path to manifest file>
```

## <a name="troubleshooting"></a>トラブルシューティング

### <a name="mapped-network-drives"></a>マップ済みネットワーク ドライブ
現時点では、マップ済みネットワーク ドライブを圧縮しないファイルの登録のサポートされていません。 ネットワーク共有のパスの完全なマップされたドライブを参照してください。

### <a name="registration-failure"></a>登録に失敗しました
登録が行われて、デバイスは、ファイルのレイアウトにアクセスする必要があります。 ファイル レイアウトは、ネットワーク共有でホストされているが場合、は、デバイスにアクセスがあることを確認します。 

### <a name="modifications-to-visual-assets-arent-being-loaded-in-the-app"></a>ビジュアル資産に対する変更は、アプリで読み込まれているはありません。 
アプリは、起動時にそのビジュアル アセットが読み込まれます。 場合は、アプリを起動した後、ビジュアルの資産に変更が加えられた、最新の変更を表示するアプリを再起動する必要があります。