---
author: seksenov
title: "ホストされた Web アプリ - Mac を使用した Web アプリケーションから Windows アプリへの変換"
description: "Mac を使用して、Web サイトを、Windows 10 用のユニバーサル Windows プラットフォーム (UWP) アプリに変換します。"
kw: Hosted Web Apps with a Mac, Porting to Windows 10 with a Mac, Convert website to Windows with Mac, Packaging web application with ManfoldJS for Windows Store, Add website to Windows Store with App Studio
translationtype: Human Translation
ms.sourcegitcommit: 0458dcd2aab862ccdecf1ebbc51e883405a929a6
ms.openlocfilehash: 3ba820e2ec8a3556874c0c7c7e328831bab783ca

---

# Mac を使用したホストされた Web アプリの作成

Web サイトの URL のみから開始して、Windows 10 用のユニバーサル Windows プラットフォーム アプリをすばやく作成できます。 

> [!NOTE]
> 以下の手順は、Mac の開発プラットフォームで使用される手順です。 Windows ユーザーの場合は、[Windows 開発プラットフォームを使用する手順](/hwa-create-windows.md)をご覧ください。

## Mac での開発に必要な要素

- Web ブラウザー。
- コマンド プロンプト。

## オプション 1: ManifoldJS

[ManifoldJS](http://manifoldjs.com/) は、NPM から簡単にインストールできる Node.js アプリです。 Web サイトに関するメタデータが抽出され、Android、iOS、Windows でホストされるネイティブ アプリが生成されます。 サイトに [Web アプリ マニフェスト](https://www.w3.org/TR/appmanifest/)がない場合は、自動的に生成されます。

1. NPM (Node Package Manager) を含む [NodeJS](https://nodejs.org/) をインストールします。 <br>

2. コマンド プロンプトを開いて、NPM で ManifoldJS をインストールします。
```
npm install -g manifoldjs
```

3. Web サイトの URL に対して `manifoldjs` コマンドを実行します。
```
manifoldjs http://codepen.io/seksenov/pen/wBbVyb/?editors=101
```

4. 次のビデオの手順に従って、ホストされた Web アプリのパッケージ化を完了し、Windows ストアに公開します。

[![ManifoldJS を使用して Mac で UWP Web アプリを公開する](images/hwa-to-uwp/mac_manifoldjs_video.png)](https://sec.ch9.ms/ch9/0a67/9b06e5c7-d7aa-478d-b30d-f99e145a0a67/ManifoldJS_high.mp4 "ManifoldJS を使用して Mac で UWP Web アプリを公開する")

## オプション 2: App Studio

[App Studio](http://appstudio.windows.com/) は無料のオンライン アプリ作成ツールで、Windows 10 アプリをすばやく構築することができます。

1. Web ブラウザーで [App Studio](http://appstudio.windows.com/) を開きます。

2. **[Start now!]** (今すぐ開始) をクリックします。

3. **[Web app templates]** (Web アプリ テンプレート) の **[Hosted Web App]** (ホストされた Web アプリ) をクリックします。

4. 画面の指示に従って、Windows ストアに公開できるパッケージを生成します。

## 関連トピック

- [ユニバーサル Windows プラットフォーム (UWP) 機能にアクセスして Web アプリを強化する](/hwa-access-features.md)
- [ユニバーサル Windows プラットフォーム (UWP) アプリのガイド](http://go.microsoft.com/fwlink/p/?LinkID=397871)
- [Windows ストア アプリ設計のアセットのダウンロード](https://msdn.microsoft.com/library/windows/apps/xaml/bg125377.aspx)



<!--HONumber=Aug16_HO3-->


