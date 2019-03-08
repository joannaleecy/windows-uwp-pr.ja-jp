---
ms.assetid: df4d227c-21f9-4f99-9e95-3305b149d9c5
title: UWP アプリ ストリーミング インストール
description: ユニバーサル Windows プラットフォーム (UWP) アプリ ストリーミング インストールでは、Microsoft Store からアプリのどの部分を最初にダウンロードするかを指定できます。 アプリの基本的なファイルを先にダウンロードすると、残りの部分のダウンロードをバックグラウンドで完了している間に、ユーザーはアプリを起動して操作できます。
ms.date: 04/05/2017
ms.topic: article
keywords: Windows 10, UWP, ストリーミング インストール, UWP アプリ ストリーミング インストール
ms.localizationpriority: medium
ms.openlocfilehash: 3fa33410be31b1732a04c51d14dbbd114e1f5e0c
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57608657"
---
# <a name="uwp-app-streaming-install"></a>UWP アプリ ストリーミング インストール
ユニバーサル Windows プラットフォーム (UWP) アプリ ストリーミング インストールでは、Microsoft Store からアプリのどの部分を最初にダウンロードするかを指定できます。 アプリの基本的なファイルを先にダウンロードすると、残りの部分のダウンロードをバックグラウンドで完了している間に、ユーザーはアプリを起動して操作できます。 

UWP アプリ ストリーミング インストールを使用するには、アプリのファイルをセクション別に分割する必要があります。 これを行うには、コンテンツ グループ マップと呼ばれる、アプリと共にパッケージ化する XML ファイルを作成します。これを使用することにより、ダウンロードの優先度および順序を設定できます。 詳しくは、以下にリンクが示されているトピックをご覧ください。

UWP アプリ ストリーミング インストールを UWP アプリに追加する方法の完全ガイドについては、こちらの[ブログ シリーズ](https://blogs.msdn.microsoft.com/appinstaller/2017/03/15/uwp-streaming-app-installation/)をご覧ください。

| トピック | 説明 | 
|-------|-------------|
| [作成し、ソースのコンテンツ グループ マップの変換](create-cgm.md) | ユニバーサル Windows プラットフォーム (UWP) アプリを UWP アプリ ストリーミング インストールに対応させるには、コンテンツ グループ マップを作成する必要があります。 この記事では、コンテンツ グループ マップの作成と変換に関する詳細情報と、それに伴うヒントやコツを示します。 |