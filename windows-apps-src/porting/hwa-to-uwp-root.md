---
author: seksenov
title: "ホストされた Web アプリ - Web アプリケーションからユニバーサル Windows プラットフォーム (UWP) アプリへの変換と Windows 10 のネイティブ機能へのアクセス"
description: "Web アプリを Windows ストア用のユニバーサル Windows プラットフォーム (UWP) アプリに変換するためのリソースを検索します。"
ms.author: wdg-dev-content
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "ホストされた Web アプリ, Web サイトから Windows アプリへの変換, Windows ストアでの Web アプリ, Windows 用 Chrome アプリ"
translationtype: Human Translation
ms.sourcegitcommit: 2e230e95be01f0b14fa6346be9fa836c66a812cf
ms.openlocfilehash: c9239f3a3c14bf9da99e60cfef8154eefb4305b4
ms.lasthandoff: 01/20/2017

---

# <a name="hosted-web-apps---access-windows-10-features-from-your-web-app"></a>ホストされた Web アプリ - Web アプリからの Windows 10 の機能へのアクセス

Web アプリケーションで、ユニバーサル Windows プラットフォーム (UWP) へのフル アクセスが可能です。サーバーでホストされているスクリプトから直接 Windows ランタイム API を呼び出したり、Cortana との統合を活用したり、オンライン認証プロバイダーを使用したりすることができます。 ハイブリッド アプリもサポートされているため、ホストされているスクリプトから呼び出されるローカル コードを使って、リモートとローカルのページ間でのアプリのナビゲーションを管理することができます。

## <a name="get-started"></a>開始

Mac と PC のいずれの環境でも、数分でホストされた Web アプリを作成できます。 特に Windows デバイスを使用している場合は、作業を始める最適な方法は無料で完全な機能を備えた[Visual Studio Community 2015](https://www.visualstudio.com/vs/community/) を使用することです。 Visual Studio にアクセスできない場合でも、いくつかのオプションを選択できます。 コマンド ライン インターフェイス (CLI) ユーティリティを使い慣れている場合は、[ManifoldJS](http://manifoldjs.com/) を試してみてください。 また、無料で、コーディング不要のオンライン作成ツールである [App Studio](http://appstudio.windows.com/) を使って、Windows 10 アプリをすばやく構築することもできます。

- [Windows を使用して、Web アプリケーションをユニバーサル Windows プラットフォーム (UWP) アプリに変換するための詳しい手順](hwa-create-windows.md)

- [Mac を使用して、Web アプリケーションをユニバーサル Windows プラットフォーム (UWP) アプリに変換するための詳しい手順](hwa-create-mac.md)

## <a name="enhance-your-app"></a>アプリの強化

- JavaScript から直接呼び出すことができる[ネイティブの Windows ランタイム機能](hwa-access-features.md)を使って、アプリを強化します。

- Content Security Policy (CSP) モデルのアプリケーション コンテンツ URI 規則 (ACUR) を設定して、アプリのセキュリティを維持します。

- Cortana 音声コマンドの統合により、音声によってアプリを実行できます。

- アプリの機能を宣言することで、ユーザー リソースとデバイスの機能に対するプログラムによるアクセスを許可します。

- OpenID や OAuth でユーザーの身元を確認することによって、シンプルかつスムーズなユーザーのログイン フローを作成します。

- パッケージ Web アプリとホストされる Web アプリのいずれかに決定する必要はありません。 ハイブリッド アプリを作成することで、両方のメリットが得られます。

## <a name="convert-your-existing-chrome-app"></a>既存の Chrome アプリの変換

[既存の Chrome でホストされるアプリを変換](hwa-chrome-conversion.md)して、Windows でホストされる Web アプリを作成することが容易になりました。 [ManifoldJS](http://manifoldjs.com/) で、入力の形式として Chrome マニフェストを受け入れるようになりました。 また、既存の `.zip` または `.crx` ファイルから `.appx` パッケージを生成する [CLI ツール](https://github.com/MicrosoftEdge/hwa-cli)が開発されました。

## <a name="demos"></a>デモ

- [Contoso Travel アプリ](http://contosotravel.azurewebsites.net/)


