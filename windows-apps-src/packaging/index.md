---
ms.assetid: 1abcbb13-80f0-4bf1-a812-649ee8bd1915
title: アプリのパッケージ化
description: このセクションには、ユニバーサル Windows プラットフォーム (UWP) アプリのパッケージ化に関する記事または記事へのリンクが記載されています。
ms.date: 09/30/2018
ms.topic: article
keywords: Windows 10, UWP, パッケージ化
ms.localizationpriority: medium
ms.openlocfilehash: 04736c9ac4de5adf162d32191ff30f7a981d6a6f
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57583618"
---
# <a name="packaging-apps"></a>アプリのパッケージ化


## <a name="purpose"></a>目的

このセクションには、ユニバーサル Windows プラットフォーム (UWP) アプリのパッケージ化に関する記事または記事へのリンクが記載されています。

| トピック | 説明 |
|-------|-------------|
| [Visual Studio で UWP アプリをパッケージ化する](packaging-uwp-apps.md) | ユニバーサル Windows プラットフォーム (UWP) アプリを配布または販売するには、そのアプリのアプリ パッケージを作成する必要があります。 |
| [手動でのアプリのパッケージ化](manual-packaging-root.md) | アプリ パッケージを作成して署名するときに、Visual Studio を使ってアプリを開発していない場合は、手動でのアプリのパッケージ化ツールを使用する必要があります。 |
| [アプリ パッケージのアーキテクチャ](device-architecture.md) | UWP アプリ パッケージを構築するときにどのプロセッサ アーキテクチャを使用するべきかについて説明します。 |
| [UWP アプリ ストリーミング インストール](streaming-install.md) | ユニバーサル Windows プラットフォーム (UWP) アプリ ストリーミング インストールでは、Microsoft Store からアプリのどの部分を最初にダウンロードするかを指定できます。 アプリの基本的なファイルを先にダウンロードすると、残りの部分のダウンロードをバックグラウンドで完了している間に、ユーザーはアプリを起動して操作できます。 |
| [オプション パッケージと関連セットの作成](optional-packages.md) | オプション パッケージには、メイン パッケージに統合できるコンテンツが格納されます。 オプション パッケージは、ダウンロード可能なコンテンツ (DLC) 用や、サイズ制約に対応して大規模アプリを分割する場合、元のアプリから分離して追加コンテンツを出荷する場合に便利です。 |
| [実行可能コードによるオプション パッケージ](optional-packages-with-executable-code.md) | Visual Studio を使用して、実行可能コードでオプション パッケージを作成する方法について説明します。 |
| [アプリ インストーラーによる UWP アプリのインストール](appinstaller-root.md) | アプリ インストーラーを使用すると、アプリ パッケージをダブルクリックして UWP アプリをインストールできます。 |
| [WinAppDeployCmd.exe ツールを使ったアプリのインストール](install-universal-windows-apps-with-the-winappdeploycmd-tool.md) | Windows アプリケーションの展開ツール (WinAppDeployCmd.exe) は、Windows 10 コンピューターから Windows 10 Mobile デバイスに UWP アプリを展開するために使うことができるコマンド ライン ツールです。 このツールを使うと、Windows 10 Mobile デバイスが USB で接続されているか同じサブネットにあれば、アプリ パッケージを展開できます。Microsoft Visual Studio やそのアプリ用のソリューションは不要です。 この記事では、このツールを使って UWP アプリをインストールする方法について説明します。 |
| [UWP アプリの自動ビルドを設定する](auto-build-package-uwp-apps.md) | このトピックでは、自動ビルド プロセスの一環としてアプリをパッケージ化する場合に、Visual Studio Team Services (VSTS) を使用して実行する方法を説明します。 |
| [アプリ機能の宣言](app-capability-declarations.md) | 特定の API、画像や音楽などのリソース、カメラやマイクなどデバイスにアクセスするには、機能を UWP アプリの[パッケージ マニフェスト](https://msdn.microsoft.com/library/windows/apps/BR211474)で宣言する必要があります。 |
| [パッケージの更新プログラムを Microsoft Store からダウンロードしてインストールする](self-install-package-updates.md) | UWP アプリでは、プログラムによてパッケージの更新を確認して、インストールできます。 また、パートナー センターで必須としてマークされているパッケージを照会し、必須の更新がインストールされるまで機能を無効にすることもできます。  |
