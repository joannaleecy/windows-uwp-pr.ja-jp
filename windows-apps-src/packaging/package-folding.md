---
title: アセット パッケージとパッケージ圧縮を使った開発
description: アセット パッケージとパッケージ圧縮を使ってアプリケーションを効率的に整理する方法について説明します。
ms.date: 04/30/2018
ms.topic: article
keywords: Windows 10, パッケージ化, パッケージ レイアウト, アセット パッケージ
ms.localizationpriority: medium
ms.openlocfilehash: 9241ffeb6b232c5b5be3098b114f6c7bf00bcf0d
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57659867"
---
# <a name="developing-with-asset-packages-and-package-folding"></a>アセット パッケージとパッケージ圧縮を使った開発 

> [!IMPORTANT]
> Microsoft Store にアプリを提出する予定がある場合、[Windows 開発者向けサポート](https://developer.microsoft.com/windows/support)に連絡してアセット パッケージとパッケージ圧縮を使う承認を得る必要があります。

アセット パッケージによってパッケージ全体のサイズを減らし、アプリが Microsoft Store で公開されるまでの時間を短縮できます。 アセット パッケージと、開発サイクルを早める方法について詳しくは、「[アセット パッケージの概要](asset-packages.md)」をご覧ください。

アプリにアセット パッケージを使うことを検討している場合や、使うことが既にわかっている場合、アセット パッケージによって開発プロセスがどのように変わるかに関心をお持ちかもしれません。 簡単に言えば、アプリの開発は同じままです。これは、アセット パッケージのパッケージ圧縮によって可能になります。

## <a name="file-access-after-splitting-your-app"></a>アプリの分割後のファイル アクセス

パッケージ圧縮が開発プロセスに影響を与えないことを理解するため、まずアプリを複数のパッケージ (アセット パッケージまたはリソース パッケージを使用) に分割するとどうなるかをもう一度確認してみましょう。 

大まかに言うと、アプリの一部のファイルを (アーキテクチャ パッケージではない) 他のパッケージに分割すると、コードが実行される場所から直接それらのファイルにアクセスすることができなくなります。 これは、パッケージがすべて、アーキテクチャ パッケージがインストールされている場所とは別のディレクトリにインストールされているためです。 たとえば、ゲームを作成する、フランス語とドイツ語用にビルドされた x86 と x64 の両方のマシンにゲームがローカライズされた場合は、ゲームのアプリ バンドル内のこれらのアプリ パッケージ ファイルが必要があります。

-   MyGame_1.0_x86.appx
-   MyGame_1.0_x64.appx
-   MyGame_1.0_language-fr.appx
-   MyGame_1.0_language-de.appx

独自のフォルダーを各アプリのパッケージ ファイルがあるゲームがユーザーのコンピューターにインストールされると、 **WindowsApps**ディレクトリ。 したがって、64 ビット Windows を実行するフランス語ユーザーの場合、ゲームは次のようになります。

```example
C:\Program Files\WindowsApps\
|-- MyGame_1.0_x64
|   `-- …
|-- MyGame_1.0_language-fr
|   `-- …
`-- …(other apps)
```

ファイルをユーザーには適用されませんするには、アプリ パッケージに (x86 およびドイツ語版パッケージ) がインストールされていることに注意してください。 

このユーザーの場合、ゲームの主な実行可能ファイルは **MyGame_1.0_x64** フォルダーに置かれ、そこから実行されます。通常、このフォルダー内のファイルにのみアクセスできます。 **MyGame_1.0_language-fr** フォルダーのファイルにアクセスするには、MRT API または PackageManager API を使う必要があります。 MRT Api は、インストールされている言語から最も適切なファイルを自動的に選択できます、次のようにで MRT Api の詳細を確認できる[Windows.ApplicationModel.Resources.Core](https://docs.microsoft.com/uwp/api/windows.applicationmodel.resources.core)します。 または、[PackageManager クラス](https://docs.microsoft.com/uwp/api/Windows.Management.Deployment.PackageManager)を使ってフランス語言語パッケージのインストール場所を見つけることもできます。 アプリのパッケージのインストール場所は変わることがり、ユーザーごとに異なるため、思い込まないでください。 

## <a name="asset-package-folding"></a>アセット パッケージの圧縮

アセット パッケージのファイルにはどのようにアクセスできるでしょうか。 この場合も、アーキテクチャ パッケージ内の他のファイルへのアクセスに使っているファイル アクセス API を使うことができます。 これは、アセット パッケージ ファイルは、インストールされるときにパッケージ圧縮プロセスを通じてアーキテクチャ パッケージに圧縮されるためです。 さらに、アセット パッケージ ファイルはもともとアーキテクチャ パッケージ内のファイルであるため、開発プロセスをルーズ ファイル配置からパッケージ化配置に移行するときに API の使用方法を変更する必要はありません。 

パッケージ圧縮のしくみについて理解を深めるため、例を見てみましょう。 次のファイル構造のゲーム プロジェクトがあるとします。

```example
MyGame
|-- Audios
|   |-- Level1
|   |   `-- ...
|   `-- Level2
|       `-- ...
|-- Videos
|   |-- Level1
|   |   `-- ...
|   `-- Level2
|       `-- ...
|-- Engine
|   `-- ...
|-- XboxLive
|   `-- ...
`-- Game.exe
```

ゲームを 3 つのパッケージ (x64 アーキテクチャ パッケージ、オーディオのアセット パッケージ、ビデオのアセット パッケージ) に分割する場合、ゲームは以下のパッケージに分割されます。

```example
MyGame_1.0_x64.appx
|-- Engine
|   `-- ...
|-- XboxLive
|   `-- ...
`-- Game.exe
MyGame_1.0_Audios.appx
`-- Audios
    |-- Level1
    |   `-- ...
    `-- Level2
        `-- ...
MyGame_1.0_Videos.appx
`-- Videos
    |-- Level1
    |   `-- ...
    `-- Level2
        `-- ...
```

ゲームをインストールすると、x64 パッケージがまず展開されます。 次に、2 つのアセット パッケージも独自のフォルダーに展開されます (前の例と同様に **MyGame_1.0_language-fr**)。 ただし、パッケージ圧縮のため、アセット パッケージ ファイルは **MyGame_1.0_x64** フォルダーにも表れるようにハード リンクされます (したがって、ファイルは 2 か所に現れますが、ディスク領域を 2 倍消費するわけではありません)。 アセット パッケージ ファイルが表示される場所は、パッケージのルートから見てそのファイルが存在する場所とまったく同じです。 ですから、展開されたゲームの最終レイアウトは次のようになります。

```example 
C:\Program Files\WindowsApps\
|-- MyGame_1.0_x64
|   |-- Audios
|   |   |-- Level1
|   |   |   `-- ...
|   |   `-- Level2
|   |       `-- ...
|   |-- Videos
|   |   |-- Level1
|   |   |   `-- ...
|   |   `-- Level2
|   |       `-- ...
|   |-- Engine
|   |   `-- ...
|   |-- XboxLive
|   |   `-- ...
|   `-- Game.exe
|-- MyGame_1.0_Audios
|   `-- Audios
|       |-- Level1
|       |   `-- ...
|       `-- Level2
|           `-- ...
|-- MyGame_1.0_Videos
|   `-- Videos
|       |-- Level1
|       |   `-- ...
|       `-- Level2
|           `-- ...
`-- …(other apps)
```

アセット パッケージにパッケージ圧縮を使っても、同じ方法でアセット パッケージに分割したファイルにアクセスでき (アーキテクチャ フォルダーが元のプロジェクト フォルダーとまったく同じ構造である点に注目してください)、アセット パッケージを追加したり、コードに影響を与えずにアセット パッケージ間でファイルを移動したりすることができます。 

次に、より複雑なパッケージ圧縮の例を考えてみましょう。 ここでは、レベルに基づいてファイルを分割するとします。元のプロジェクト フォルダーと同じ構造を維持する場合、パッケージは次のようになります。

```example
MyGame_1.0_x64.appx
|-- Engine
|   `-- ...
|-- XboxLive
|   `-- ...
`-- Game.exe
MyGame_Level1.appx
|-- Audios
|   `-- Level1
|       `-- ...
`-- Videos
    `-- Level1
        `-- ...

MyGame_Level2.appx
|-- Audios
|   `-- Level2
|       `-- ...
`-- Videos
    `-- Level2
        `-- ...
```
これにより、**MyGame_Level1** パッケージの **Level1** フォルダーおよびファイルと **MyGame_Level2** パッケージの **Level2** フォルダーおよびファイルを、パッケージ圧縮時に **Audios** および **Videos** フォルダーに結合できるようになります。 したがって、一般的なルールとして、MakeAppx.exe のマッピング ファイルまたは[パッケージ レイアウト](packaging-layout.md)でパッケージ化されたファイルに指定される相対パスは、パッケージ圧縮後にそれらのファイルへのアクセスに使うパスとなります。 

最後に、同じ相対パスを持つ異なるアセット パッケージに 2 つのファイルがある場合、これによりパッケージ圧縮中に競合が発生します。 競合が発生した場合、アプリの展開でエラーが発生して失敗します。 さらに、パッケージ圧縮ではハード リンクが利用されるため、アセット パッケージを使う場合、アプリを NTFS 以外のドライブに展開できなくなります。 ユーザーによってアプリがリムーバブル ドライブに移動される可能性が高いことがわかっている場合、アセット パッケージを使わないでください。 


