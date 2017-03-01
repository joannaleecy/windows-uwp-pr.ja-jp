---
author: laurenhughes
ms.assetid: 1abcbb13-80f0-4bf1-a812-649ee8bd1915
title: "アプリのパッケージ化"
description: "このセクションには、ユニバーサル Windows プラットフォーム (UWP) アプリのパッケージ化に関する記事または記事へのリンクが記載されています。"
ms.author: lahugh
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
translationtype: Human Translation
ms.sourcegitcommit: c6b64cff1bbebc8ba69bc6e03d34b69f85e798fc
ms.openlocfilehash: 0a9689738fac363012fb9af197f52ac8813b47c9
ms.lasthandoff: 02/07/2017

---
# <a name="packaging-apps"></a>アプリのパッケージ化

\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください。\]

## <a name="purpose"></a>目的

このセクションには、ユニバーサル Windows プラットフォーム (UWP) アプリのパッケージ化に関する記事または記事へのリンクが記載されています。

| トピック | 説明 |
|-------|-------------|
| [UWP アプリのパッケージ化](packaging-uwp-apps.md) | UWP アプリを販売、または他のユーザーに配布するには、そのアプリの appxupload パッケージを作成する必要があります。 appxupload を作成すると、別の appx パッケージがテストとサイドローディング用に生成されます。 デバイスに appx パッケージをサイドローディングすることで、アプリを直接配布できます。 この記事では、UWP アプリ パッケージを構成、作成、テストする方法について説明します。 サイドローディングについて詳しくは、「[DISM を使ったアプリのサイドローディング](http://go.microsoft.com/fwlink/?LinkID=231020)」をご覧ください。 |
| [MakeAppx.exe ツールを使ったアプリ パッケージの作成](create-app-package-with-makeappx-tool.md) | MakeAppx.exe は、アプリ パッケージとバンドルからのファイルの作成、暗号化、暗号化解除、抽出を行います。 |
| [パッケージ署名用証明書を作成する](create-certificate-package-signing.md) | PowerShell ツールを使ってアプリ パッケージ署名用を作成し、エクスポートします。 |
| [SignTool を使ってアプリ パッケージに署名する](sign-app-package-using-signtool.md) | SignTool を使って手動でアプリ パッケージに証明書による署名を行います。 |
| [WinAppDeployCmd.exe ツールを使ったアプリのインストール](install-universal-windows-apps-with-the-winappdeploycmd-tool.md) | Windows アプリケーションの展開ツール (WinAppDeployCmd.exe) は、Windows 10 コンピューターから Windows 10 Mobile デバイスに UWP アプリを展開するために使うことができるコマンド ライン ツールです。 このツールを使うと、Windows 10 Mobile デバイスが USB で接続されているか同じサブネットにあれば、.appx パッケージを展開できます。Microsoft Visual Studio やそのアプリ用のソリューションは不要です。 この記事では、このツールを使って UWP アプリをインストールする方法について説明します。 |
| [UWP アプリの自動ビルドを設定する](auto-build-package-uwp-apps.md) | このトピックでは、自動ビルド プロセスの一環としてアプリをパッケージ化する場合に、Visual Studio Team Services (VSTS) を使用して実行する方法を説明します。 |
| [アプリ機能の宣言](app-capability-declarations.md) | 特定の API、画像や音楽などのリソース、カメラやマイクなどデバイスにアクセスするには、機能を UWP アプリの[パッケージ マニフェスト](https://msdn.microsoft.com/library/windows/apps/BR211474)で宣言する必要があります。 |
| [アプリのパッケージの更新をダウンロードしてインストールする](self-install-package-updates.md) | UWP アプリでは、プログラムによてパッケージの更新を確認して、インストールできます。 またｈ、Windows デベロッパー センター ダッシュボードで必須としてマークされているパッケージを照会し、必須の更新がインストールされるまで機能を無効にすることもできます。 この記事では、これらのタスクを実行する方法について説明します。 |
 

