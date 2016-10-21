---
title: "ホストされた Web アプリ - Web アプリケーションからユニバーサル Windows プラットフォーム (UWP) アプリへの変換と Windows 10 のネイティブ機能へのアクセス"
description: "Web サイトの URL からユニバーサル Windows プラットフォーム (UWP) アプリを作成します。 Web アプリ内のコードから Windows 10 のネイティブ デバイス機能にアクセスします。 ホストされた Web アプリ用 Microsoft Windows ブリッジ (旧 Project Westminster) によって、素早く簡単に Web アプリを Windows ストアで公開できます。"
author: seksenov
translationtype: Human Translation
ms.sourcegitcommit: 7fe6e240e4ef221b49f9b103cf30192449ce4502
ms.openlocfilehash: 95d50aa37f349f494f260ea3af97211a085623a9

---

# ホストされた Web アプリ - Web アプリからの Windows 10 の機能へのアクセス

Web アプリケーションで、ユニバーサル Windows プラットフォーム (UWP) へのフル アクセスが可能です。サーバーでホストされているスクリプトから直接 Windows ランタイム API を呼び出したり、Cortana との統合を活用したり、オンライン認証プロバイダーを使用したりすることができます。 ハイブリッド アプリもサポートされているため、ホストされているスクリプトから呼び出されるローカル コードを使って、リモートとローカルのページ間でのアプリのナビゲーションを管理することができます。

## はじめに

Mac と PC のいずれの環境でも、数分で独自のホストされた Web アプリを作成できます。 特に Windows デバイスを使用している場合は、作業を始める最適な方法は無料で完全な機能を備えた[Visual Studio Community 2015](https://www.visualstudio.com/) を使用することです。 Visual Studio にアクセスできない場合でも、いくつかのオプションを選択できます。 コマンド ライン インターフェイス (CLI) ユーティリティを使い慣れている場合は、[ManifoldJS](http://manifoldjs.com/) を試してみてください。 また、無料で、コーディング不要のオンライン作成ツールである [App Studio](http://appstudio.windows.com/) を使って、Windows 10 アプリをすばやく構築することもできます。

- [Windows を使用して、Web アプリケーションをユニバーサル Windows プラットフォーム (UWP) アプリを変換するための詳しい手順](hwa-create-windows.md)

- [Mac を使用して、Web アプリケーションをユニバーサル Windows プラットフォーム (UWP) アプリを変換するための詳しい手順](hwa-create-mac.md)

## アプリの強化

- Windows ランタイムから JavaScript で [Windows のネイティブ機能にアクセスする](hwa-access-features.md)ことによりアプリを強化します。

- Content Security Policy (CSP) モデルのアプリケーション コンテンツ URI 規則 (ACUR) を設定して、アプリのセキュリティを維持します。
- Cortana 音声コマンドとの統合により、音声によってアプリを実行できます。

- アプリの機能を宣言することで、ユーザー リソースとデバイスの機能に対するプログラムによるアクセスを許可します。

- OpenID や OAuth でユーザーの身元を確認することによって、シンプルかつスムーズなユーザーのログイン フローを作成します。

- パッケージ Web アプリとホストされる Web アプリのいずれかに決定する必要はありません。 ハイブリッド アプリを作成することで、両方のメリットが得られます。

## 既存の Chrome アプリの変換

[既存の Chrome でホストされるアプリを変換](hwa-chrome-conversion.md)して、Windows でホストされる Web アプリを作成することが容易になりました。 [ManifoldJS](http://manifoldjs.com/) で、入力の形式として Chrome マニフェストを受け入れるようになりました。 また、既存の `.zip` または `.crx` ファイルから `.appx` パッケージを生成する [CLI ツール](https://github.com/MicrosoftEdge/hwa-cli)が開発されました。

## デモ

- [Contoso Travel アプリ](http://contosotravel.azurewebsites.net/)

- [Windows ランタイム API: JavaScript コード サンプル](http://rjs.azurewebsites.net/)



<!--HONumber=Aug16_HO3-->


