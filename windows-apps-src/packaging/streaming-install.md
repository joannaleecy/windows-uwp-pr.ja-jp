---
ms.assetid: df4d227c-21f9-4f99-9e95-3305b149d9c5
title: UWP アプリ ストリーミング インストール
description: ユニバーサル Windows プラットフォーム (UWP) アプリ ストリーミング インストールでは、Microsoft Store からアプリのどの部分を最初にダウンロードするかを指定できます。 アプリの基本的なファイルを先にダウンロードすると、残りの部分のダウンロードをバックグラウンドで完了している間に、ユーザーはアプリを起動して操作できます。
ms.date: 04/05/2017
ms.topic: article
keywords: windows 10, uwp, ストリーミング インストールをストリーミングする uwp アプリのインストールします。
ms.localizationpriority: medium
ms.openlocfilehash: 3fa33410be31b1732a04c51d14dbbd114e1f5e0c
ms.sourcegitcommit: 231065c899d0de285584d41e6335251e0c2c4048
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/10/2018
ms.locfileid: "8826347"
---
# <a name="uwp-app-streaming-install"></a>UWP アプリ ストリーミング インストール
ユニバーサル Windows プラットフォーム (UWP) アプリ ストリーミング インストールでは、Microsoft Store からアプリのどの部分を最初にダウンロードするかを指定できます。 アプリの基本的なファイルを先にダウンロードすると、残りの部分のダウンロードをバックグラウンドで完了している間に、ユーザーはアプリを起動して操作できます。 

UWP アプリ ストリーミング インストールを使用するには、セクションでは、アプリのファイルに分割する必要があります。 これを行うにはダウンロードの優先順位のセットを注文できるが、アプリをパッケージ化されている XML ファイルで、コンテンツ グループ マップ作成します。 詳細については以下のリンクのトピックを参照してください。

UWP アプリに UWP アプリ ストリーミング インストールを追加する完全なについては、この[ブログ シリーズ](https://blogs.msdn.microsoft.com/appinstaller/2017/03/15/uwp-streaming-app-installation/)ご覧ください。

| トピック | 説明 | 
|-------|-------------|
| [ソース コンテンツ グループ マップの作成と変換](create-cgm.md) | ユニバーサル Windows プラットフォーム (UWP) アプリを UWP アプリ ストリーミング インストールに対応させるには、コンテンツ グループ マップを作成する必要があります。 この記事では、コンテンツ グループ マップの作成と変換に関する詳細情報と、それに伴うヒントやコツを示します。 |