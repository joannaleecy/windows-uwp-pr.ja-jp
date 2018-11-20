---
author: laurenhughes
title: フラット バンドル アプリ パッケージ
description: フラット バンドルを作成してアプリ パッケージへの参照を持つアプリの .appx パッケージ ファイルをバンドルする方法について説明します。
ms.author: lahugh
ms.date: 09/30/2018
ms.topic: article
keywords: windows 10, パッケージ化, パッケージ構成, フラット バンドル
ms.localizationpriority: medium
ms.openlocfilehash: b877996dd5fa32ac764fb587092f501320931527
ms.sourcegitcommit: ed0304b8a214c03b8aab74b8ef12c9f82b8e3c5f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/19/2018
ms.locfileid: "7293902"
---
# <a name="flat-bundle-app-packages"></a>フラット バンドル アプリ パッケージ 

> [!IMPORTANT]
> Microsoft Store にアプリを提出する予定がある場合、[Windows 開発者向けサポート](https://developer.microsoft.com/windows/support)に連絡してフレット バンドルを使う承認を得る必要があります。

フラット バンドルは、アプリのパッケージ ファイルをバンドルする改善された方法です。 アプリ バンドル ファイルで、バンドル内に含めるアプリのパッケージ ファイルが必要な複数レベルのパッケージ構造を使用する一般的な Windows、フラット バンドルはアプリ バンドルの外部にできるように、アプリのパッケージ ファイルを参照するだけで、この必要性を削除します。 アプリのパッケージ ファイルがバンドルには含まれなく、ためにできる並列処理、その結果のアップロード時間、高速な公開 (各アプリのパッケージ ファイルは、同時に処理できることができます) ため、最終的に開発繰り返しできません。

![フラット バンドルの図](images/bundle-combined.png)

フラット バンドルの別の利点は、作成する必要があるパッケージが減ることです。 アプリ パッケージ ファイルが参照されるだけのため、2 つのバージョンのアプリは、パッケージが 2 つのバージョン間で変更されなかった場合、同じパッケージ ファイルを参照できます。 この結果、次のバージョンのアプリのパッケージをビルドするとき、変更されたアプリ パッケージを作成するだけでよくなります。
既定では、フラット バンドルはそれ自体と同じフォルダー内のアプリ パッケージ ファイルを参照します。 ただし、この参照は他のパス (相対パス、ネットワーク共有、および http の場所) に変更できます。 これを行うには、フラット バンドルの作成時に **BundleManifest** を直接指定する必要があります。 

## <a name="how-to-create-a-flat-bundle"></a>フラット バンドルを作成する方法

フラット バンドルは、MakeAppx.exe ツールを使うか、パッケージ レイアウトを使ってバンドルの構造を定義することにより作成できます。

### <a name="using-makeappxexe"></a>MakeAppx.exe の使用
MakeAppx.exe を使ってフラット バンドルを作成するには、コマンドを使って"MakeAppx.exe bundle"通常どおりですが、/fb スイッチ、ファイルを生成、フラット アプリ バンドル (のみにアプリのパッケージ ファイルを参照し、実際のペイロードが含まれていないために、非常に小さくなります). 

コマンド構文の例を以下に示します。

```syntax
MakeAppx bundle [options] /d <content directory> /fb <output flat bundle name>
```

MakeAppx.exe について詳しくは、「[MakeAppx.exe ツールを使ったアプリ パッケージの作成](https://docs.microsoft.com/windows/uwp/packaging/create-app-package-with-makeappx-tool)」をご覧ください。

### <a name="using-packaging-layout"></a>パッケージ レイアウトの使用
または、パッキング レイアウトを使ってフラット バンドルを作成することができます。 これを行うには、アプリ バンドル マニフェストの **PackageFamily** 要素で **FlatBundle** 属性を **true** に設定します。 パッケージ レイアウトについて詳しくは、「[パッケージ レイアウトを使ったパッケージの作成](packaging-layout.md)」をご覧ください。

## <a name="how-to-deploy-a-flat-bundle"></a>フラット バンドルを展開する方法 
フラット バンドルを展開する前に、(アプリ バンドルに加えて) 各アプリ パッケージに同じ証明書で署名する必要があります。 これは、すべてのアプリ パッケージ ファイル (.appx/.msix) が独立したファイルになりできなくなったアプリ バンドル (.appxbundle/.msixbundle) ファイルに含まれないためです。 パッケージが署名されたら、アプリ バンドル ファイルをポイントし、アプリを展開します (アプリ パッケージには、アプリ バンドルを想定してそれらを想定) PowerShell の[Add-appxpackage コマンドレット](https://docs.microsoft.com/powershell/module/appx/add-appxpackage?view=win10-ps)を使用します。 