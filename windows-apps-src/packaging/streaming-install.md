---
author: laurenhughes
ms.assetid: df4d227c-21f9-4f99-9e95-3305b149d9c5
title: UWP アプリ ストリーミング インストール
description: ユニバーサル Windows プラットフォーム (UWP) アプリ ストリーミング インストールでは、Microsoft Store からアプリのどの部分を最初にダウンロードするかを指定できます。 アプリの基本的なファイルを先にダウンロードすると、残りの部分のダウンロードをバックグラウンドで完了している間に、ユーザーはアプリを起動して操作できます。
ms.author: lahugh
ms.date: 04/05/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10、uwp、インストール、ストリーミング ストリーミング uwp アプリをインストールします。
ms.localizationpriority: medium
ms.openlocfilehash: 087226cad4bcf7ea0294d8878564c345d6cfb9d0
ms.sourcegitcommit: 897a111e8fc5d38d483800288ad01c523e924ef4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/13/2018
ms.locfileid: "608797"
---
# <a name="uwp-app-streaming-install"></a>UWP アプリ ストリーミング インストール
ユニバーサル Windows プラットフォーム (UWP) アプリ ストリーミング インストールでは、Microsoft Store からアプリのどの部分を最初にダウンロードするかを指定できます。 アプリの基本的なファイルを先にダウンロードすると、残りの部分のダウンロードをバックグラウンドで完了している間に、ユーザーはアプリを起動して操作できます。 

アプリをインストールするストリーミング UWP を使用するには、アプリのファイルをセクションに分割する必要があります。 これを行うには、されますマップを作成するコンテンツ グループ、アプリ パッケージ化されている XML ファイルには、ダウンロードの優先度を設定して順序ができるようにします。 詳細については、下にあるリンクのトピックを参照してください。

アプリをインストールするストリーミング UWP UWP アプリの追加の完了については、この[ブログ シリーズ](https://blogs.msdn.microsoft.com/appinstaller/2017/03/15/uwp-streaming-app-installation/)を確認します。

| トピック | 説明 | 
|-------|-------------|
| [ソース コンテンツ グループ マップの作成と変換](create-cgm.md) | ユニバーサル Windows プラットフォーム (UWP) アプリを UWP アプリ ストリーミング インストールに対応させるには、コンテンツ グループ マップを作成する必要があります。 この記事では、コンテンツ グループ マップの作成と変換に関する詳細情報と、それに伴うヒントやコツを示します。 |