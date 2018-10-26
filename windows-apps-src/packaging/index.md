---
author: laurenhughes
ms.assetid: 1abcbb13-80f0-4bf1-a812-649ee8bd1915
title: アプリのパッケージ化
description: このセクションには、ユニバーサル Windows プラットフォーム (UWP) アプリのパッケージ化に関する記事または記事へのリンクが記載されています。
ms.author: lahugh
ms.date: 09/30/2018
ms.topic: article
keywords: Windows 10, UWP, パッケージ化
ms.localizationpriority: medium
ms.openlocfilehash: d8728094292f1de81eb90752ee496090df4cb6e0
ms.sourcegitcommit: 6cc275f2151f78db40c11ace381ee2d35f0155f9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5559056"
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
| [実行可能コードを使用したオプション パッケージ](optional-packages-with-executable-code.md) | Visual Studio を使用して、実行可能コードでオプション パッケージを作成する方法について説明します。 |
| [アプリ インストーラーで UWP アプリをインストールする](appinstaller-root.md) | アプリ インストーラーを使用すると、アプリ パッケージをダブルクリックして UWP アプリをインストールできます。 |
| [WinAppDeployCmd.exe ツールを使ったアプリのインストール](install-universal-windows-apps-with-the-winappdeploycmd-tool.md) | Windows アプリケーションの展開 (WinAppDeployCmd.exe) は、すべての windows 10 Mobile デバイスを windows 10 コンピューターからの UWP アプリを展開に使用できるコマンド ライン ツールです。 このツールを使用するには、アプリ パッケージを展開するとき、windows 10 Mobile デバイスは USB で接続されているか同じサブネット上に利用可能なしないと、そのアプリ用の Microsoft Visual Studio やソリューションは不要です。 この記事では、このツールを使って UWP アプリをインストールする方法について説明します。 |
| [UWP アプリの自動ビルドを設定する](auto-build-package-uwp-apps.md) | このトピックでは、自動ビルド プロセスの一環としてアプリをパッケージ化する場合に、Visual Studio Team Services (VSTS) を使用して実行する方法を説明します。 |
| [アプリ機能の宣言](app-capability-declarations.md) | 特定の API、画像や音楽などのリソース、カメラやマイクなどデバイスにアクセスするには、機能を UWP アプリの[パッケージ マニフェスト](https://msdn.microsoft.com/library/windows/apps/BR211474)で宣言する必要があります。 |
| [パッケージの更新プログラムを Microsoft Store からダウンロードしてインストールする](self-install-package-updates.md) | UWP アプリでは、プログラムによてパッケージの更新を確認して、インストールできます。 またｈ、Windows デベロッパー センター ダッシュボードで必須としてマークされているパッケージを照会し、必須の更新がインストールされるまで機能を無効にすることもできます。  |
