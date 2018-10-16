---
author: laurenhughes
ms.assetid: ee51eae3-ed55-419e-ad74-6adf1e1fb8b9
title: 手動でのアプリのパッケージ化
description: このセクションには、ユニバーサル Windows プラットフォーム (UWP) アプリの手動でのパッケージ化に関する記事または記事へのリンクが記載されています。
ms.author: lahugh
ms.date: 04/30/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, パッケージ化
ms.localizationpriority: medium
ms.openlocfilehash: fcd6d937c7261b5cfa8af954eb5d2ec2869d8afd
ms.sourcegitcommit: 9354909f9351b9635bee9bb2dc62db60d2d70107
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/16/2018
ms.locfileid: "4687825"
---
# <a name="manual-app-packaging"></a>手動でのアプリのパッケージ化

アプリ パッケージを作成して署名するときに、Visual Studio を使ってアプリを開発していない場合は、手動でのアプリのパッケージ化ツールを使用する必要があります。

> [!IMPORTANT] 
> Visual Studio を使用してアプリを開発する場合は、Visual Studio のウィザードを使ってアプリ パッケージを作成し、署名することをお勧めします。 詳しくは、「[Visual Studio での UWP アプリのパッケージ化](https://msdn.microsoft.com/windows/uwp/packaging/packaging-uwp-apps)」をご覧ください。

## <a name="purpose"></a>目的

このセクションには、ユニバーサル Windows プラットフォーム (UWP) アプリの手動でのパッケージ化に関する記事または記事へのリンクが記載されています。

| トピック | 説明 |
|-------|-------------|
| [MakeAppx.exe ツールを使ったアプリ パッケージの作成](create-app-package-with-makeappx-tool.md) | MakeAppx.exe は、アプリ パッケージとバンドルからのファイルの作成、暗号化、暗号化解除、抽出を行います。 |
| [パッケージ署名用証明書を作成する](create-certificate-package-signing.md) | PowerShell ツールを使ってアプリ パッケージ署名用を作成し、エクスポートします。 |
| [SignTool を使ってアプリ パッケージに署名する](sign-app-package-using-signtool.md) | SignTool を使って手動でアプリ パッケージに証明書による署名を行います。 |

### <a name="advanced-topics"></a>高度なトピック

このセクションには、より効率的なパッケージ化とインストールのために大規模なアプリや複雑なアプリをコンポーネント化する高度なトピックが含まれています。 

> [!IMPORTANT]
> Microsoft Store にアプリを提出する予定がある場合、[Windows 開発者向けサポート](https://developer.microsoft.com/windows/support)に連絡してこのセクションの高度な機能を使う承認を得る必要があります。


| トピック | 説明 |
|-------|-------------|
| [アセット パッケージの概要](asset-packages.md) | アセット パッケージは、アプリケーションの共通ファイルの一元的な場所として機能するパッケージの種類です。これにより、そのアーキテクチャ パッケージ全体で重複するファイルが事実上不要になります。 |
| [アセット パッケージとパッケージ圧縮を使った開発](package-folding.md) | アセット パッケージとパッケージ圧縮を使ってアプリケーションを効率的に整理する方法について説明します。 |
| [フラット バンドル アプリ パッケージ](flat-bundles.md) | アプリのパッケージ ファイルのフラット バンドルを作成する方法について説明します。 |
| [パッケージ レイアウトを使ったパッケージの作成](packaging-layout.md) | パッケージ レイアウトは、アプリのパッケージ構造を記述する 1 つのドキュメントです。 アプリのバンドル (プライマリおよびオプション)、バンドル内のパッケージ、パッケージ内のファイルを指定します。 |
