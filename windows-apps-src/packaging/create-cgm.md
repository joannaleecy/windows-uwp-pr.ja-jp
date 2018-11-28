---
ms.assetid: ff2523cb-8109-42be-9dfc-cb5d09002574
title: ソース コンテンツ グループ マップの作成と変換
description: ユニバーサル Windows プラットフォーム (UWP) アプリを UWP アプリ ストリーミング インストールに対応させるには、コンテンツ グループ マップを作成する必要があります。 この記事では、コンテンツ グループ マップの作成と変換に関する詳細情報と、それに伴うヒントやコツを示します。
ms.date: 9/30/2018
ms.topic: article
keywords: Windows 10, UWP, コンテンツ グループ マップ, ストリーミング インストール, UWP アプリ ストリーミング インストール, ソース コンテンツ グループ マップ
ms.localizationpriority: medium
ms.openlocfilehash: ea6e83521007572449b28e65bdff56d9d2c11186
ms.sourcegitcommit: b5c9c18e70625ab770946b8243f3465ee1013184
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/28/2018
ms.locfileid: "7967475"
---
# <a name="create-and-convert-a-source-content-group-map"></a>ソース コンテンツ グループ マップの作成と変換

ユニバーサル Windows プラットフォーム (UWP) アプリを UWP アプリ ストリーミング インストールに対応させるには、コンテンツ グループ マップを作成する必要があります。 この記事では、コンテンツ グループ マップの作成と変換に関する詳細情報と、それに伴うヒントやコツを示します。

## <a name="creating-the-source-content-group-map"></a>ソース コンテンツ グループ マップを作成する

`SourceAppxContentGroupMap.xml` ファイルを作成してから、Visual Studio または **MakeAppx.exe** ツールを使用して、このファイルを最終的なバージョンである `AppxContentGroupMap.xml` に変換する必要があります。 `AppxContentGroupMap.xml` を 1 から作成すると、手順を 1 つ省くことができますが、`AppxContentGroupMap.xml` では (非常に便利な) ワイルドカードを使用できないため、`SourceAppxContentGroupMap.xml` を作成してから変換することをお勧めします (通常はこの方法を使う方が簡単です)。 

UWP アプリ ストリーミング インストールが適した簡単なシナリオを見てみましょう。 

たとえば、作成した UWP ゲームの最終的なアプリのサイズが 100 GB を超えているとします。 便利なことができる、Microsoft Store からダウンロードに時間がかかるする予定です。 UWP アプリ ストリーミング インストールを使用する場合は、アプリのファイルがダウンロードされる順序を指定できます。 必須ファイルから先にダウンロードされるようストアに指定しておくことで、ユーザーは必須ではないファイルをバックグラウンドでダウンロードしながらアプリの使用を早く開始できます。

> [!NOTE]
> UWP アプリ ストリーミング インストールの使用には、アプリのファイル構成が大きく影響します。 アプリのファイル分割を容易にするには、UWP アプリ ストリーミング インストールに合わせてアプリのコンテンツ レイアウトをできるだけ早く検討するようお勧めします。

まず、`SourceAppxContentGroupMap.xml` ファイルを作成します。

詳しい説明の前に、まず完全な `SourceAppxContentGroupMap.xml` ファイルを見てみましょう。

```xml
<?xml version="1.0" encoding="utf-8"?>  
<ContentGroupMap xmlns="http://schemas.microsoft.com/appx/2016/sourcecontentgroupmap" 
                 xmlns:s="http://schemas.microsoft.com/appx/2016/sourcecontentgroupmap"> 
    <Required>
        <ContentGroup Name="Required">
            <File Name="StreamingTestApp.exe"/>
        </ContentGroup>
    </Required>
    <Automatic>
        <ContentGroup Name="Level2">
            <File Name="Assets\Level2\*"/>
        </ContentGroup>
        <ContentGroup Name="Level3">
            <File Name="Assets\Level3\*"/>
        </ContentGroup>
    </Automatic>
</ContentGroupMap>
```

コンテンツ グループ マップには、主要なコンポーネントが 2 つあります。1 つは、必須コンテンツ グループを格納する **Required** セクション、もう 1 つは、複数の自動コンテンツ グループを格納できる **Automatic** セクションです。

### <a name="required-content-group"></a>必須コンテンツ グループ

必須コンテンツ グループは、`SourceAppxContentGroupMap.xml` の `<Required>` 要素に含まれる 1 つのコンテンツ グループです。 必須コンテンツ グループには、最小限のユーザー エクスペリエンスでアプリを起動するために必要となる重要なファイルをすべて含める必要があります。 .NET Native のコンパイルに対応するには、すべてのコード (アプリケーションの実行可能ファイル) を必須グループに含めて、その他の資産やファイルは自動グループに含める必要があります。

たとえば、アプリがゲームの場合は、ゲームのメイン メニューやホーム画面に使用するファイルを必須グループに含めます。

さきほど例示した元の `SourceAppxContentGroupMap.xml` ファイルのスニペットを次に示します。 
```xml
<Required>
    <ContentGroup Name="Required">
        <File Name="StreamingTestApp.exe"/>
    </ContentGroup>
</Required>
```

いくつか重要な点があります。

- `<Required>` 要素内の `<ContentGroup>` は、****"Required" という名前にする必要があります。 この名前は、必須コンテンツ グループ用だけに使用するために予約されており、最終的なコンテンツ グループ マップに含まれる他の `<ContentGroup>` には使用できません。
- ここにある `<ContentGroup>` は 1 つだけです。 必須ファイルのグループは 1 つだけにする必要があるため、これは意図どおりです。
- この例では、`.exe` ファイルは 1 つです。 必須コンテンツ グループは、1 つのファイルに限定せず、複数のファイルにすることもできます。 

このファイルの記述を開始する簡単な方法の 1 つは、好みのテキスト エディターで新しいページを開き、ファイルを [名前を付けて保存] でアプリのプロジェクト フォルダーに保存して、新しく作成したファイルに `SourceAppxContentGroupMap.xml` という名前を付けることです。

> [!IMPORTANT]
> C++ の UWP アプリを開発している場合は、`SourceAppxContentGroupMap.xml` のファイル プロパティを調整する必要があります。 `Content` プロパティを **true**、`File Type` プロパティを **XML File** に設定します。 

`SourceAppxContentGroupMap.xml` を作成する場合、ワイルドカードをファイル名に使用できることを利用すると便利です。詳しくは、「[ワイルドカードの使用のヒントとコツ](#wildcards)」セクションをご覧ください。

Visual Studio でアプリを開発した場合は、必須コンテンツ グループに以下を含めることをお勧めします。

```xml
<File Name="*"/>
<File Name="WinMetadata\*"/>
<File Name="Properties\*"/>
<File Name="Assets\*Logo*"/>
<File Name="Assets\*SplashScreen*"/>
```

単一ワイルドカードのファイル名を追加すると、アプリの実行可能ファイルや DLL など、Visual Studio からプロジェクト ディレクトリに追加されたファイルが含められます。 WinMetadata フォルダーと Properties フォルダーには、Visual Studio によって生成された他のフォルダーが含められます。 Assets のワイルドカードでは、アプリをインストールするために必要なロゴとスプラッシュ画面の画像が選択されます。

ダブル ワイルドカード "**" をファイル構造のルートに使用して、プロジェクト内のすべてのファイルを含めることはできません。`SourceAppxContentGroupMap.xml` を最終的な `AppxContentGroupMap.xml` に変換する際にエラーとなります。

また、フットプリント ファイル (AppxManifest.xml、AppxSignature.p7x、resources.pri など) をコンテンツ グループ マップに含めることができない点にも注意する必要があります。 指定したファイルドカード ファイル名のいずれかにフットプリント ファイルが含まれている場合、これらは無視されます。

### <a name="automatic-content-groups"></a>自動コンテンツ グループ

自動コンテンツ グループは、ユーザーがダウンロード済みのコンテンツ グループを操作している間に、バックグラウンドでダウンロードされる資産です。 自動コンテンツ グループには、アプリの起動に不可欠ではない追加のファイルが含まれます。 たとえば、自動コンテンツ グループを複数のレベルに分割し、各レベルを個別のコンテンツ グループとして定義することができます。 必須コンテンツ グループのセクションでも説明したように、.NET Native のコンパイルに対応するには、すべてのコード (アプリケーションの実行可能ファイル) を必須グループに含めて、その他の資産やファイルは自動グループに含める必要があります。

`SourceAppxContentGroupMap.xml` の例で自動コンテンツ グループをもう少し詳しく見てみましょう。
```xml
<Automatic>
    <ContentGroup Name="Level2">
        <File Name="Assets\Level2\*"/>
    </ContentGroup>
    <ContentGroup Name="Level3">
        <File Name="Assets\Level3\*"/>
    </ContentGroup>
</Automatic>
```

自動グループのレイアウトは必須グループによく似ていますが、いくつか例外もあります。

- 複数のコンテンツ グループがあります。
- 自動コンテンツ グループには一意の名前を指定できますが、必須コンテンツ グループ用に予約されている "Required" という名前は例外です。
- 自動コンテンツ グループに、必須コンテンツ グループのファイルを含めることはできません****。 
- 自動コンテンツ グループには、他の自動コンテンツ グループにも含まれているファイルを含めることができます。 そのファイルは 1 回だけ、そのファイルを含む最初の自動コンテンツ グループと共にダウンロードされます。

#### ワイルドカードの使用のヒントとコツ<a name="wildcards"></a>

コンテンツ グループ マップのファイル レイアウトでは、常にプロジェクトのルート フォルダーが基準になります。

ここで使用している例では、"Assets\Level2" または "Assets\Level3" のうちいずれかのファイル レベル内のファイルをすべて取得するために、両方の `<ContentGroup>` 要素内でワイルドカードが使用されています。 これより深いフォルダー構造を使っている場合は、次のようにダブル ワイルドカードを使用することができます。

```xml
<ContentGroup Name="Level2">
    <File Name="Assets\Level2\**"/>
</ContentGroup>
```

ファイル名としてワイルドカードと共に文字列を使うこともできます。 たとえば、"Assets" 内でファイル名に "Level2" という文字列が含まれるすべてのファイルを含める場合は、次のようにします。

```xml
<ContentGroup Name="Level2">
    <File Name="Assets\*Level2*"/>
</ContentGroup>
```

## <a name="convert-sourceappxcontentgroupmapxml-to-appxcontentgroupmapxml"></a>SourceAppxContentGroupMap.xml を AppxContentGroupMap.xml に変換する

`SourceAppxContentGroupMap.xml` を最終的なバージョンである `AppxContentGroupMap.xml` に変換するには、Visual Studio 2017 または **MakeAppx.exe** コマンド ライン ツールを使うことができます。

Visual Studio を使ってコンテンツ グループのマップを変換するには:
1. `SourceAppxContentGroupMap.xml` をプロジェクト フォルダーに追加します。
2. [プロパティ] ウィンドウで、`SourceAppxContentGroupMap.xml` のビルド アクションを "AppxSourceContentGroupMap" に変更します。
2. ソリューション エクスプローラーで、プロジェクトを右クリックします。
3. [ストア] ->[コンテンツ グループ マップ ファイルの変換] の順に移動します。

アプリの開発に Visual Studio を使用していない場合や、コマンドラインの使用が望ましい場合は、**MakeAppx.exe** ツールを使って `SourceAppxContentGroupMap.xml` を変換します。 

単純な **MakeAppx.exe** コマンドは次のようになります。
```syntax
MakeAppx convertCGM /s MyApp\SourceAppxContentGroupMap.xml /f MyApp\AppxContentGroupMap.xml /d MyApp\
```

/s オプションでは `SourceAppxContentGroupMap.xml` のパス、/f では `AppxContentGroupMap.xml` のパスを指定します。 最後の /d オプションは、ファイル名ワイルドカードの展開時に使用するディレクトリ (この場合はアプリのプロジェクト ディレクトリ) を指定します。

**MakeAppx.exe** で使用できるオプションについて詳しくは、コマンド プロンプトを開き、**MakeAppx.exe** に移動して、次のように入力します。

```syntax
MakeAppx convertCGM /?
```

これで、アプリ用に最終的な `AppxContentGroupMap.xml` を準備できました。 アプリが、Microsoft Store 用に完全に準備する前に行うには引き続き詳細があります。 UWP アプリ ストリーミング インストールをアプリに追加する完全なプロセスについては、[こちらのブログ記事](https://blogs.msdn.microsoft.com/appinstaller/2017/03/15/uwp-streaming-app-installation/)をご覧ください。
