---
title: フラット バンドル アプリ パッケージ
description: フラット バンドルを作成してアプリ パッケージへの参照を持つアプリの .appx パッケージ ファイルをバンドルする方法について説明します。
ms.date: 09/30/2018
ms.topic: article
keywords: windows 10, パッケージ化, パッケージ構成, フラット バンドル
ms.localizationpriority: medium
ms.openlocfilehash: b7066b7f2e5bd72ebee3169e03c7940b6fef4dba
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57638487"
---
# <a name="flat-bundle-app-packages"></a>フラット バンドル アプリ パッケージ 

> [!IMPORTANT]
> Microsoft Store にアプリを提出する予定がある場合、[Windows 開発者向けサポート](https://developer.microsoft.com/windows/support)に連絡してフレット バンドルを使う承認を得る必要があります。

フラットなバンドルは、アプリのパッケージ ファイルをバンドルする方法が改良です。 アプリ バンドルのファイルにバンドルに含まれるアプリのパッケージ ファイルが必要な複数レベルのパッケージの構造を使用して一般的な Windows、フラットなバンドルはのみアプリ バンドルの外部にあるように、アプリ パッケージ ファイルを参照して、このニーズを削除します。 アプリのパッケージ ファイルは、バンドルに含まれることはありません、ために可能性がある並列処理、アップロード時間で高速な発行 (各アプリのパッケージ ファイルは、同時に処理できる) ため、削減と最終的に高速になる開発反復処理します。

![フラット バンドルの図](images/bundle-combined.png)

フラット バンドルの別の利点は、作成する必要があるパッケージが減ることです。 アプリ パッケージ ファイルが参照されるのみであるため、アプリの 2 つのバージョンは、パッケージが 2 つのバージョン間で変更しなかった場合、同じパッケージ ファイルを参照できます。 この結果、次のバージョンのアプリのパッケージをビルドするとき、変更されたアプリ パッケージを作成するだけでよくなります。
既定では、フラットなバンドルは、それ自体と同じフォルダー内のアプリ パッケージ ファイルを参照します。 ただし、この参照は他のパス (相対パス、ネットワーク共有、および http の場所) に変更できます。 これを行うには、フラット バンドルの作成時に **BundleManifest** を直接指定する必要があります。 

## <a name="how-to-create-a-flat-bundle"></a>フラット バンドルを作成する方法

フラット バンドルは、MakeAppx.exe ツールを使うか、パッケージ レイアウトを使ってバンドルの構造を定義することにより作成できます。

### <a name="using-makeappxexe"></a>MakeAppx.exe の使用
MakeAppx.exe を使用してフラット バンドルを作成するには、「MakeAppx.exe バンドル」コマンドを使用して通常どおり、/fb スイッチを使用して (これはのみにアプリ パッケージ ファイルを参照し、実際のペイロードが含まれていないは非常に小さくなりますフラット アプリ バンドル ファイルを生成). 

コマンド構文の例を以下に示します。

```syntax
MakeAppx bundle [options] /d <content directory> /fb /p <output flat bundle name>
```

MakeAppx.exe について詳しくは、「[MakeAppx.exe ツールを使ったアプリ パッケージの作成](https://docs.microsoft.com/windows/uwp/packaging/create-app-package-with-makeappx-tool)」をご覧ください。

### <a name="using-packaging-layout"></a>パッケージ レイアウトの使用
または、パッキング レイアウトを使ってフラット バンドルを作成することができます。 これを行うには、アプリ バンドル マニフェストの **PackageFamily** 要素で **FlatBundle** 属性を **true** に設定します。 パッケージ レイアウトについて詳しくは、「[パッケージ レイアウトを使ったパッケージの作成](packaging-layout.md)」をご覧ください。

## <a name="how-to-deploy-a-flat-bundle"></a>フラット バンドルを展開する方法 
フラット バンドルを展開する前に、(アプリ バンドルに加えて) 各アプリ パッケージに同じ証明書で署名する必要があります。 これは、独立したファイルになったすべてのアプリ パッケージ ファイル (.appx/.msix) 今後、アプリのバンドル (.appxbundle/.msixbundle) ファイルに含まれないためです。 パッケージが署名済み、使用して、 [Add-appxpackage コマンドレット](https://docs.microsoft.com/powershell/module/appx/add-appxpackage?view=win10-ps)アプリ バンドルのファイルをポイントし、(アプリ パッケージは、アプリ バンドルを想定してそれらを想定) アプリをデプロイする powershell。 