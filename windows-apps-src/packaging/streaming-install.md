---
author: laurenhughes
ms.assetid: df4d227c-21f9-4f99-9e95-3305b149d9c5
title: UWP アプリ ストリーミング インストール
description: ユニバーサル Windows プラットフォーム (UWP) アプリ ストリーミング インストールでは、Microsoft Store からアプリのどの部分を最初にダウンロードするかを指定できます。 アプリの基本的なファイルを先にダウンロードすると、残りの部分のダウンロードをバックグラウンドで完了している間に、ユーザーはアプリを起動して操作できます。
ms.author: lahugh
ms.date: 04/05/2017
ms.topic: article
keywords: windows 10, uwp, ストリーミング インストールでは、uwp アプリのストリーミング インストールします。
ms.localizationpriority: medium
ms.openlocfilehash: e4915d2fb4d1133cd190d766d38c79934d9f3956
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/02/2018
ms.locfileid: "5945990"
---
# <a name="uwp-app-streaming-install"></a>UWP アプリ ストリーミング インストール
ユニバーサル Windows プラットフォーム (UWP) アプリ ストリーミング インストールでは、Microsoft Store からアプリのどの部分を最初にダウンロードするかを指定できます。 アプリの基本的なファイルを先にダウンロードすると、残りの部分のダウンロードをバックグラウンドで完了している間に、ユーザーはアプリを起動して操作できます。 

UWP アプリ ストリーミング インストールを使用するには、セクションでは、アプリのファイルに分割する必要があります。 これを行うにはダウンロードの優先順位のセットを注文できるが、アプリをパッケージ化されている XML ファイルで、コンテンツ グループ マップ作成します。 詳細については下のリンクのトピックを参照してください。

UWP アプリに UWP アプリ ストリーミング インストールを追加する完全なガイドについて、この[ブログ シリーズ](https://blogs.msdn.microsoft.com/appinstaller/2017/03/15/uwp-streaming-app-installation/)ご覧ください。

| トピック | 説明 | 
|-------|-------------|
| [ソース コンテンツ グループ マップの作成と変換](create-cgm.md) | ユニバーサル Windows プラットフォーム (UWP) アプリを UWP アプリ ストリーミング インストールに対応させるには、コンテンツ グループ マップを作成する必要があります。 この記事では、コンテンツ グループ マップの作成と変換に関する詳細情報と、それに伴うヒントやコツを示します。 |