---
author: msatranjr
title: マネージ Windows ランタイム コンポーネントの配布
description: Windows ランタイム コンポーネントは、ファイルをコピーすることで配布できます。
ms.assetid: 80262992-89FC-42FC-8298-5AABF58F8212
ms.author: misatran
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 6461b6889f110bde8929e1f370f9197caa33e5f3
ms.sourcegitcommit: 38f06f1714334273d865935d9afb80efffe97a17
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/09/2018
ms.locfileid: "6183840"
---
# <a name="distributing-a-managed-windows-runtime-component"></a>マネージ Windows ランタイム コンポーネントの配布



Windows ランタイム コンポーネントは、ファイルをコピーすることで配布できます。 ただし、コンポーネントが多数のファイルで構成されている場合、インストールがユーザーの負担になる可能性があります。 また、ファイルの配置の誤りや、参照設定のエラーが原因で問題が発生する可能性もあります。 複雑なコンポーネントは、Visual Studio 拡張 SDK としてパッケージ化すると、簡単にインストールして使用することができます。 ユーザーは、パッケージ全体で参照を 1 つだけ設定する必要があります。 **[拡張機能と更新プログラム]** ダイアログ ボックスを使用すると、コンポーネントを簡単に配置してインストールできます。詳しくは、MSDN ライブラリの「[Visual Studio 拡張機能の検索と使用](https://msdn.microsoft.com/library/vstudio/dd293638.aspx)」をご覧ください。

## <a name="planning-a-distributable-windows-runtime-component"></a>配布可能な Windows ランタイム コンポーネントの計画

.winmd ファイルなどのバイナリ ファイルには、一意の名前を付けます。 次の形式を使用して、名前を一意にすることをお勧めします。

``` syntax
company.product.purpose.extension
For example: Microsoft.Cpp.Build.dll
```

バイナリ ファイルは、アプリ パッケージにインストールされます。場合によっては、他の開発者のバイナリ ファイルも一緒にインストールされます。 MSDN ライブラリの[ソフトウェア開発キットを作成する方法に関するページ](https://msdn.microsoft.com/library/hh768146.aspx)で、拡張 SDK に関する記述をご覧ください。

コンポーネントを配布する方法を決定する際は、複雑さを考慮します。 次の場合、拡張 SDK、または同様のパッケージ マネージャーを使用することをお勧めします。

-   コンポーネントが複数のファイルで構成されている。
-   複数のプラットフォーム (たとえば、x86 と ARM) に対応するため、複数のバージョンのコンポーネントを提供する。
-   デバッグ バージョンと、リリース バージョンの両方のコンポーネントを提供する。
-   コンポーネントに、設計時にのみ使用されるファイルやアセンブリが含まれる。

拡張 SDK は上記の 1 つ以上の条件に当てはまる場合に特に便利です。

> **注:** NuGet パッケージ管理システムは複雑なコンポーネントは、オープン ソースの代わりに拡張 Sdk を提供します。 NuGet を使用すると、拡張 SDK と同様にパッケージを作成できるため、複雑なコンポーネントのインストールが簡単にできます。 NuGet パッケージと Visual Studio 拡張 SDK を比較するには、MSDN ライブラリの[NuGet と拡張 SDK を使用して参照を追加する方法に関するページ](https://msdn.microsoft.com/library/jj161096.aspx)をご覧ください。

## <a name="distribution-by-file-copy"></a>ファイルのコピーによる配布

コンポーネントが 1 つの .winmd ファイル、または 1 つの .winmd ファイルと 1 つのリソース インデックス (.pri) ファイルで構成されている場合は、.winmd ファイルをユーザーがコピーできるように用意するだけです。 ユーザーは、プロジェクトの任意の場所にファイルを置き、**[既存項目の追加]** ダイアログ ボックスを使用して、.winmd ファイルをプロジェクトに追加してから、[参照マネージャー] ダイアログ ボックスを使用して参照を作成することができます。 .pri ファイルまたは .xml ファイルを含める場合は、.winmd ファイルと共に、それらのファイルを配置するようにユーザーに伝えます。

> **注:** Visual Studio 常に、.pri ファイルを生成、Windows ランタイム コンポーネントをビルドするとき、プロジェクトにすべてのリソースが含まれていない場合でもします。 コンポーネントにテスト アプリが含まれる場合、bin\\debug\\AppX フォルダーでアプリ パッケージの内容を調べると、.pri ファイルを使用するかどうかを確認できます。 コンポーネントの .pri ファイルがそこにない場合は、.pri ファイルを配布する必要はありません。 または、[MakePRI.exe](https://msdn.microsoft.com/library/windows/apps/jj552945.aspx) ツールを使用して、Windows ランタイム コンポーネント プロジェクトからリソース ファイルをダンプすることもできます。 たとえば、Visual Studio コマンド プロンプト ウィンドウで次のように入力します。makepri dump /if MyComponent.pri /of MyComponent.pri.xml .pri ファイルについて詳しくは、「[リソース管理システム (Windows)](https://msdn.microsoft.com/library/windows/apps/jj552947.aspx)」をご覧ください。

## <a name="distribution-by-extension-sdk"></a>拡張 SDK による配布

複雑なコンポーネントには通常、Windows のリソースが含まれていますが、空の .pri ファイルを検出する方法については、前のセクションの注をご覧ください。

**拡張 SDK を作成するには**

1.  Visual Studio SDK がインストールされていることを確認します。 Visual Studio SDK は、[Visual Studio ダウンロード](https://www.visualstudio.com/downloads/download-visual-studio-vs) ページからダウンロードできます。
2.  VSIX プロジェクト テンプレートを使用して、新しいプロジェクトを作成します。 [機能拡張] カテゴリの [Visual C#] または [Visual Basic] の下にテンプレートがあります。 このテンプレートは、Visual Studio SDK の一部としてインストールされます。 ([C# または Visual Basic を使用して SDK を作成する方法のチュートリアル](https://msdn.microsoft.com/library/jj127119.aspx)または [C++ を使用して SDK を作成する方法のチュートリアル](https://msdn.microsoft.com/library/jj127117.aspx)で、このテンプレートを非常に単純なシナリオで使用する方法を紹介しています。 )
3.  SDK のフォルダー構造を決定します。 フォルダーの構造は、VSIX プロジェクトのルート レベルの、**References**、**Redist**、および **DesignTime** フォルダーで始まります。

    -   **References** は、ユーザーがプログラミングできるバイナリ ファイルの場所です。 拡張 SDK は、ユーザーの Visual Studio プロジェクトで、これらのファイルへの参照を作成します。
    -   **Redist** は、開発者独自のコンポーネントを使用して作成されたアプリの場合、バイナリ ファイルと共に配布する必要がある他のファイルの場所です。
    -   **DesignTime** は、開発者により、独自のコンポーネントを使用するアプリの作成中のみ使用されるファイルの場所です。

    これらの各フォルダーで、構成フォルダーを作成できます。 使用できる名前は、debug、retail、CommonConfiguration です。 CommonConfiguration フォルダーに格納されるファイルは、製品ビルドでも、デバッグ ビルドでも同じです。 製品ビルドのコンポーネントのみを配布する場合は、CommonConfiguration にすべてのファイルを置いて、他の 2 つのフォルダーを省略できます。

    各構成フォルダーには、プラットフォーム固有のファイルを格納するアーキテクチャ フォルダーを作成できます。 すべてのプラットフォームで同じファイルを使用する場合は、neutral という名前のフォルダーを 1 つ作成します。 他のアーキテクチャ フォルダーの名前など、フォルダー構造について詳しくは、MSDN ライブラリの[ソフトウェア開発キットを作成する方法に関するページ](https://msdn.microsoft.com/library/hh768146.aspx)をご覧ください。 (この記事は、プラットフォーム SDK と拡張 SDK の両方について説明しています。 混乱を避けるため、プラットフォーム SDK に関するセクションを折りたたむとわかりやすくなります。 )

4.  SDK マニフェスト ファイルを作成します。 マニフェストでは、名前とバージョン情報、SDK がサポートしているアーキテクチャ、.NET Framework のバージョン、および Visual Studio が SDK を使用する方法に関する他の情報を指定します。 詳細と例は、[ソフトウェア開発キットを作成する方法に関するページ](https://msdn.microsoft.com/library/hh768146.aspx)をご覧ください。
5.  拡張 SDK をビルドして配布します。 VSIX パッケージのローカライズや、署名などの詳細は、MSDN ライブラリの「VSIX 配置」をご覧ください。

## <a name="related-topics"></a>関連トピック

* [ソフトウェア開発キットを作成する方法](https://msdn.microsoft.com/library/hh768146.aspx)
* [NuGet パッケージ管理システム](https://github.com/NuGet/Home)
* [リソース管理システム (Windows)](https://msdn.microsoft.com/library/windows/apps/jj552947.aspx)
* [Visual Studio 拡張機能の検索と使用](https://msdn.microsoft.com/library/dd293638.aspx)
* [MakePRI.exe のコマンド オプション](https://msdn.microsoft.com/library/windows/apps/jj552945.aspx)
