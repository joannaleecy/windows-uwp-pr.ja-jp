---
author: c-don
title: ルーズ ファイルの登録をアプリを展開します。
description: このガイドでは、ルーズ ファイルのレイアウトの検証し、Windows 10 アプリをパッケージ化することがなく共有を使用する方法を示します。
ms.author: cdon
ms.date: 6/1/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, デバイス ポータル、アプリ マネージャー, 展開, sdk
ms.localizationpriority: medium
ms.openlocfilehash: a6a96a78cf03ce4994ddee1c929997b12a2d028f
ms.sourcegitcommit: 49aab071aa2bd88f1c165438ee7e5c854b3e4f61
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/09/2018
ms.locfileid: "4469625"
---
# <a name="deploy-an-app-through-loose-file-registration"></a>ルーズ ファイルの登録をアプリを展開します。 

このガイドでは、ルーズ ファイルのレイアウトの検証し、Windows 10 アプリをパッケージ化することがなく共有を使用する方法を示します。 ルーズ ファイルのレイアウトを登録すると、簡単にパッケージ化し、アプリをインストールする必要はありませんがアプリを検証する開発者ができます。 

## <a name="what-is-a-loose-file-layout"></a>ルーズ ファイル レイアウトとは何ですか。

ルーズ ファイルのレイアウトは、単にパッケージ化プロセスを通過するのではなく、フォルダー内のアプリの内容を配置します。 パッケージの内容は「疎結合」フォルダーに利用可能なパッケージ化されません。 です。 

> [!WARNING]
> ルーズ ファイルのレイアウトの登録はすぐにアクティブな開発中に、アプリを検証するには、開発者やデザイナーです。 このアプローチは、「ドッグフード」するために使用または、アプリのフライトしないでください。 信頼された証明書で署名されているパッケージ アプリで最終的な検証が実行されることをお勧めします。 

## <a name="advantages-of-loose-file-registration"></a>ルーズ ファイルの登録の利点

- **クイック検証**- ユーザーをルーズ ファイル レイアウトを登録してアプリを起動できますすばやくアプリ ファイルは、既にパッキングされたはであるためです。 通常のアプリと同様、ユーザーは設計されていることと、アプリを使用することになります。 
- **簡単にネットワークで配布**- ルーズ ファイルがローカル ドライブではなく、ネットワーク共有である場合、開発者を送信できるネットワーク共有上の場所、ネットワークへのアクセスを持つその他のユーザーと、ルーズ ファイルのレイアウトを登録し、アプリを実行することができます。 これにより、複数のユーザーを同時に、アプリを検証できます。 
- **共同作業**- ルーズ ファイルの登録は、開発者やデザイナーは、アプリが登録されているときにビジュアル アセットの操作を続行できます。 ユーザーはアプリを起動するときにこれらの変更を表示します。 この方法で静的なアセットをのみ変更できることに注意してください。 コードまたは動的に作成されたコンテンツを変更する必要がある場合は、アプリを再コンパイルする必要があります。

## <a name="how-to-register-a-loose-file-layout"></a>ルーズ ファイルのレイアウトを登録する方法

Windows では、ローカルとリモート デバイスでルーズ ファイルのレイアウトを登録する複数の開発者ツールを提供します。 選択できる`WinDeployAppCmd`(Windows SDK ツール)、Windows Device Portal、PowerShell、および[Visual Studio](https://docs.microsoft.com/windows/uwp/debug-test-perf/deploying-and-debugging-uwp-apps#register-layout-from-network)。 以下はこれらのツールを使用して、ルーズ ファイルを登録する方法を経由します。 ただし、まず、次の設定があることを確認します。

- デバイスは、Windows 10 Creators Update (ビルド 14965) 以降である必要があります。
- [開発者モード](https://msdn.microsoft.com/windows/uwp/get-started/enable-your-device-for-development)とすべてのデバイスで[デバイスの検出](https://docs.microsoft.com/en-us/windows/uwp/get-started/enable-your-device-for-development#device-discovery)を有効にする必要があります。

> [!IMPORTANT]
> ルーズ ファイルの登録は、ネットワーク共有 (SMB) プロトコルをサポートするデバイスで利用可能なのみ: デスクトップ、Xbox します。 

### <a name="register-with-windeployappcmd"></a>WinDeployAppCmd 登録します。

使用することができますまたは後で、Windows 10 Creators Update (ビルド 14965) に対応する SDK ツールを使用している場合、`WinDeployAppCmd`コマンド プロンプトでコマンド。

```cmd
WinAppDeployCmd.exe registerfiles -remotedeploydir <Network Path> -ip <IP Address> -pin <target machine PIN>
```

**ネットワーク パス**– アプリの緩やかなファイルへのパス。

**IP アドレス**– ターゲット コンピューターの IP アドレス。

**ターゲット コンピューター暗証番号 (pin)** – A 暗証番号 (pin)、ターゲット デバイスとの接続を確立するために必要な場合です。 指定して再試行を求め、`-pin`認証が必要な場合はオプションです。 [デバイスの検出](https://docs.microsoft.com/windows/uwp/get-started/enable-your-device-for-development#device-discovery)暗証番号 (pin) を取得する方法について参照してください。

### <a name="windows-device-portal"></a>Windows Device Portal

Windows Device Portal は、すべての Windows 10 デバイスで利用可能なをテストし、仕事用の検証に開発者が使用します。 すべての REST エンドポイントとそのブラウザーの UX と開発者コミュニティの対象ユーザーに要求を満たします。 Device Portal について詳しくは、 [Windows Device Portal の概要](device-portal.md)をご覧ください。

Device Portal で、ルーズ ファイルのレイアウトを登録するには、次の手順に従います。

1. [Windows Device Portal の概要](device-portal.md)の**セットアップ**」の手順に従って、Device Portal に接続します。
1. アプリ マネージャー] タブでは、**ネットワーク共有から登録**を選択します。
1. ルーズ ファイルのレイアウトをネットワーク共有のパスを入力します。 
1. ホスト デバイスには、ネットワーク共有へのアクセスが割り当てられていない、必要な資格情報を入力するプロンプトがあります。
1. 登録が完了したら後のアプリを起動することができます。

Device Portal のアプリ マネージャー] ページで、**オプション パッケージを指定する]** チェック ボックスを選択し、省略可能なアプリのネットワーク共有パスを指定オプション ルーズ ファイルのレイアウト、メイン アプリの登録することもできます。 

### <a name="powershell"></a>PowerShell 

Windows PowerShell を使用して、ローカル デバイスにのみ、ルーズ ファイルのレイアウトを登録することもできます。 リモート デバイスにレイアウトを登録する必要がある場合は、他のメソッドのいずれかを使用する必要があります。 

ルーズ ファイルのレイアウトを登録するには、PowerShell を起動し、次を入力します。

```PowerShell
Add-AppxPackage -Register <path to manifest file>
```

## <a name="troubleshooting"></a>トラブルシューティング

### <a name="mapped-network-drives"></a>マップされたネットワーク ドライブ
現時点では、ルーズ ファイルの登録のマップされたネットワーク ドライブがサポートされていません。 ネットワーク共有のパスを完全にマッピングされたドライブをご覧ください。

### <a name="registration-failure"></a>登録に失敗しました
デバイスを登録が行われるは、ファイルのレイアウトにアクセスする必要があります。 ファイルのレイアウトは、ネットワーク共有でホストされているが場合、は、デバイスでアクセスできることを確認します。 

### <a name="modifications-to-visual-assets-arent-being-loaded-in-the-app"></a>ビジュアル資産への変更は、アプリに読み込まれているいません。 
アプリの起動時にそのビジュアル アセットが読み込まれます。 アプリを起動した後はビジュアル資産に変更を行った場合再を最新の変更を表示するアプリを起動する必要があります。