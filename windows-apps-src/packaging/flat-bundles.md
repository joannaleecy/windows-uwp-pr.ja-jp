---
author: laurenhughes
title: フラット バンドル アプリ パッケージ
description: フラット バンドルを作成してアプリ パッケージへの参照を持つアプリの .appx パッケージ ファイルをバンドルする方法について説明します。
ms.author: lahugh
ms.date: 04/30/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, パッケージ化, パッケージ構成, フラット バンドル
ms.localizationpriority: medium
ms.openlocfilehash: 757f95a5f46bad6dbe650b4b552f3de486d84e1b
ms.sourcegitcommit: 91511d2d1dc8ab74b566aaeab3ef2139e7ed4945
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/30/2018
ms.locfileid: "1818435"
---
# <a name="flat-bundle-app-packages"></a>フラット バンドル アプリ パッケージ 

> [!IMPORTANT]
> Microsoft Store にアプリを提出する予定がある場合、[Windows 開発者向けサポート](https://developer.microsoft.com/windows/support)に連絡してフレット バンドルを使う承認を得る必要があります。

フラット バンドルは、アプリの .appx パッケージ ファイルをバンドルする改善された方法です。 一般的な .appxbundle ファイルでは複数レベルのパッケージ構造が使用されるため、.appx パッケージ ファイルをバンドル内に含める必要がありますが、フラット バンドルではアプリ バンドルの外部に配置できるため、.appx パッケージ ファイルを参照するだけでこの必要がなくなります。 .appx パッケージ ファイルがバンドルに含まれなくなるため、並列処理できます。その結果、アップロード時間と公開にかかる時間が短縮され (各 .appx パッケージ ファイルを同時に処理できるため)、最終的に開発サイクルを早めることができます。

![フラット バンドルの図](images/bundle-combined.png)

フラット バンドルの別の利点は、作成する必要があるパッケージが減ることです。 .appx パッケージ ファイルは参照されるだけのため、2 つのバージョン間でパッケージが変更されなかった場合、2 つのバージョンのアプリが同じパッケージ ファイルを参照できます。 この結果、次のバージョンのアプリのパッケージをビルドするとき、変更されたアプリ パッケージを作成するだけでよくなります。
既定では、フラット バンドルはそれ自体と同じフォルダー内の .appx パッケージ ファイルを参照します。 ただし、この参照は他のパス (相対パス、ネットワーク共有、および http の場所) に変更できます。 これを行うには、フラット バンドルの作成時に **BundleManifest** を直接指定する必要があります。 

## <a name="how-to-create-a-flat-bundle"></a>フラット バンドルを作成する方法

フラット バンドルは、MakeAppx.exe ツールを使うか、パッケージ レイアウトを使ってバンドルの構造を定義することにより作成できます。

### <a name="using-makeappxexe"></a>MakeAppx.exe の使用
MakeAppx.exe を使ってフラット バンドルを作成するには、通常どおり "MakeAppx.exe bundle" コマンドを使いますが、/fb スイッチを指定してフラットな .appxbundle ファイルを生成します (.appx パッケージのみを参照し、実際のペイロードは含まれないため、非常に小さくなります)。 

コマンド構文の例を以下に示します。

```syntax
MakeAppx bundle [options] /d <content directory> /fb <output flat bundle name>
```

MakeAppx.exe について詳しくは、「[MakeAppx.exe ツールを使ったアプリ パッケージの作成](https://docs.microsoft.com/windows/uwp/packaging/create-app-package-with-makeappx-tool)」をご覧ください。

### <a name="using-packaging-layout"></a>パッケージ レイアウトの使用
または、パッキング レイアウトを使ってフラット バンドルを作成することができます。 これを行うには、アプリ バンドル マニフェストの **PackageFamily** 要素で **FlatBundle** 属性を **true** に設定します。 パッケージ レイアウトについて詳しくは、「[パッケージ レイアウトを使ったパッケージの作成](packaging-layout.md)」をご覧ください。

## <a name="how-to-deploy-a-flat-bundle"></a>フラット バンドルを展開する方法 
フラット バンドルを展開する前に、(アプリ バンドルに加えて) 各アプリ パッケージに同じ証明書で署名する必要があります。 これは、アプリ パッケージ ファイル (.appx) がすべて独立したファイルになり、アプリ バンドル (.appxbundle) ファイルに含まれなくなったためです。 パッケージが署名されたら、PowerShell で [Add-AppxPackage コマンドレット](https://docs.microsoft.com/powershell/module/appx/add-appxpackage?view=win10-ps)を使って .appxbundle ファイルをポイントし、アプリを展開します (アプリ バンドルが期待する場所にアプリ パッケージがあることを想定しています)。 