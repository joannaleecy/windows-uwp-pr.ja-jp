---
author: laurenhughes
title: パッケージ レイアウトを使ったパッケージの作成
description: パッケージ レイアウトは、アプリのパッケージ構造を記述する 1 つのドキュメントです。 アプリのバンドル (プライマリおよびオプション)、バンドル内のパッケージ、パッケージ内のファイルを指定します。
ms.author: lahugh
ms.date: 04/30/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, パッケージ化, パッケージ レイアウト, アセット パッケージ
ms.localizationpriority: medium
ms.openlocfilehash: 3f8cbb3989b58b726336b4bd757902bd9ea3f8c0
ms.sourcegitcommit: fbdc9372dea898a01c7686be54bea47125bab6c0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/08/2018
ms.locfileid: "4422116"
---
# <a name="package-creation-with-the-packaging-layout"></a>パッケージ レイアウトを使ったパッケージの作成  

アセット パッケージの導入により、開発者はより多くのパッケージの種類だけでなく、より多くのパッケージをビルドするためのツールを利用できるようになりました。 アプリが大規模で複雑になるにつれて、構成されるパッケージが多くなり、それらのパッケージを管理するのが難しくなるのはよくあることです (特に、Visual Studio 外でビルドする場合やマッピング ファイルを使う場合)。 アプリのパッケージ化構造の管理を簡略化するには、MakeAppx.exe でサポートされているパッケージ レイアウトを使うことができます。 

パッケージ レイアウトは、アプリのパッケージ構造を記述する 1 つの XML ドキュメントです。 アプリのバンドル (プライマリおよびオプション)、バンドル内のパッケージ、パッケージ内のファイルを指定します。 ファイルは、さまざまなフォルダー、ドライブ、ネットワークの場所から選択することができます。 ワイルドカードを使って、ファイルを選択または除外することができます。

アプリのパッケージ レイアウトがセットアップされると、1 回のコマンド ライン呼び出しでアプリのパッケージをすべて作成するため MakeAppx.exe と共に使用されます。 展開のニーズに合わせて、パッケージ レイアウトを編集してパッケージ構造を変更できます。 


## <a name="simple-packaging-layout-example"></a>シンプルなパッケージ レイアウトの例

シンプルなパッケージ レイアウトの例を次に示します。

```xml
<PackagingLayout xmlns="http://schemas.microsoft.com/appx/makeappx/2017">
  <PackageFamily ID="MyGame" FlatBundle="true" ManifestPath="C:\mygame\appxmanifest.xml" ResourceManager="false">
    
    <!-- x64 code package-->
    <Package ID="x64" ProcessorArchitecture="x64">
      <Files>
        <File DestinationPath="*" SourcePath="C:\mygame\*"/>
        <File ExcludePath="*C:\mygame\*.txt"/>
      </Files>
    </Package>
    
    <!-- Media asset package -->
    <AssetPackage ID="Media" AllowExecution="false">
      <Files>
        <File DestinationPath="Media\**" SourcePath="C:\mygame\media\**"/>
      </Files>
    </AssetPackage>

  </PackageFamily>
</PackagingLayout>
```

この例を分割してそのしくみを理解してみましょう。

### <a name="packagefamily"></a>PackageFamily
このパッケージ レイアウトでは 1 つのフラット アプリ バンドル ファイルを作成、x64 アーキテクチャ パッケージと「メディア」アセット パッケージ。 

アプリ バンドルの定義には **PackageFamily** 要素が使用されます。 バンドルの **AppxManifest** を指定するには **ManifestPath** 属性を使う必要があります。**AppxManifest** は、バンドルのアーキテクチャ パッケージの **AppxManifest** に対応している必要があります。 **ID** 属性も指定されている必要があります。 これは、必要な場合はこのパッケージのみを作成できるように、パッケージの作成時に MakeAppx.exe と共に使用されます。また、結果として作成されるパッケージのファイル名になります。 **FlatBundle** 属性は、作成するバンドルの種類を説明するために使用されます。フラット バンドル (詳しくはここで説明します) の場合は **true**、クラシック バンドルの場合は **false** です。 **ResourceManager** 属性は、このバンドル内のリソース パッケージがファイルにアクセスするために MRT を使うかどうかを指定するために使用されます。 これは既定では **true** ですが、Windows 10 バージョン 1803 の時点ではまだ準備できていないため、この属性は **false** に設定する必要があります。


### <a name="package-and-assetpackage"></a>Package と AssetPackage
**PackageFamily** 内では、アプリ バンドルに含まれるかアプリ バンドルが参照するパッケージが定義されます。 ここでは、アーキテクチャ パッケージ (メイン パッケージとも呼ばれます) が **Package** 要素を使って定義され、アセット パッケージが **AssetPackage** 要素を使って定義されます。 アーキテクチャ パッケージは、パッケージの対象アーキテクチャ ("x64"、"x86"、"arm"、"neutral" のいずれか) を指定する必要があります。 **ManifestPath** 属性をもう一度使って、このパッケージ専用に **AppxManifest** を直接指定することもできます (オプション)。 **AppxManifest** が指定されない場合、**PackageFamily** に指定された **AppxManifest** から自動的に生成されます。 

既定では、**AppxManifest** はバンドル内のすべてのパッケージに生成されます。 アセット パッケージでは、**AllowExecution** 属性を設定することもできます。 これを **false** に設定すると (既定)、実行する必要のないパッケージがウイルス スキャンに公開プロセスをブロックさせることがなくなるため、アプリの公開にかかる時間が短縮されます (これについて詳しくは「[アセット パッケージの概要](asset-packages.md))」をご覧ください)。 

### <a name="files"></a>File
各パッケージ定義内では、**File** 要素を使ってこのパッケージに含めるファイルを選ぶことができます。 **SourcePath** 属性は、ファイルが存在するローカルの場所です。 ファイルは、さまざまなフォルダー (相対パスを指定)、さまざまなドライブ (絶対パスを指定)、さらにはネットワーク共有 (`\\myshare\myapp\*` のように指定) から選ぶことができます。 **DestinationPath** は、ファイルが最終的に配置されるパッケージ内の場所 (パッケージのルートを基準) です。 **ExcludePath** を使うと (他の 2 つの属性の代わりに)、同じパッケージ内にある他の **File** 要素の **SourcePath** 属性によって選択されたファイルから除外するファイルを選ぶことができます。

各 **File** 要素を使うと、ワイルドカードを使って複数のファイルを選ぶことができます。 通常、単一ワイルドカード (`*`) はパス内の任意の場所で何回でも使うことができます。 ただし、単一ワイルドカードが一致するのはフォルダー内のファイルのみであり、サブフォルダーには一致しません。 たとえば、**SourcePath** で `C:\MyGame\*\*` を使って `C:\MyGame\Audios\UI.mp3` ファイルと `C:\MyGame\Videos\intro.mp4` ファイルを選ぶことはできますが、`C:\MyGame\Audios\Level1\warp.mp3` を選ぶことはできません。 二重ワイルドカード (`**`) は、フォルダーまたはファイル名として使って再帰的に一致させることができます (ただし、名前の一部で使うことはできません)。 たとえば、`C:\MyGame\**\Level1\**` を使うと `C:\MyGame\Audios\Level1\warp.mp3` と `C:\MyGame\Videos\Bonus\Level1\DLC1\intro.mp4` を選ぶことができます。 移動元と移動先の異なる場所でワイルドカードを使う場合、ワイルドカードを使ってパッケージ化プロセスの一部としてファイル名を直接変更することもできます。 たとえば、**SourcePath** に `C:\MyGame\Audios\*`、**DestinationPath** に `Sound\copy_*` を使うと、`C:\MyGame\Audios\UI.mp3` を選んでパッケージに `Sound\copy_UI.mp3` として表示することができます。 通常、単一ワイルドカードおよび二重ワイルドカードの数は単一の **File** 要素の **SourcePath** および **DestinationPath** と同じでなければなりません。


## <a name="advanced-packaging-layout-example"></a>高度なパッケージ レイアウトの例

より複雑なパッケージ レイアウトの例を次に示します。

```xml
<PackagingLayout xmlns="http://schemas.microsoft.com/appx/makeappx/2017">
  <!-- Main game -->
  <PackageFamily ID="MyGame" FlatBundle="true" ManifestPath="C:\mygame\appxmanifest.xml" ResourceManager="false">
    
    <!-- x64 code package-->
    <Package ID="x64" ProcessorArchitecture="x64">
      <Files>
        <File DestinationPath="*" SourcePath="C:\mygame\*"/>
        <File ExcludePath="*C:\mygame\*.txt"/>
      </Files>
    </Package>

    <!-- Media asset package -->
    <AssetPackage ID="Media" AllowExecution="false">
      <Files>
        <File DestinationPath="Media\**" SourcePath="C:\mygame\media\**"/>
      </Files>
    </AssetPackage>
    
    <!-- English resource package -->
    <ResourcePackage ID="en">
      <Files>
        <File DestinationPath="english\**" SourcePath="C:\mygame\english\**"/>
      </Files>
      <Resources Default="true">
        <Resource Language="en"/>
      </Resources>
    </ResourcePackage>

    <!-- French resource package -->
    <ResourcePackage ID="fr">
      <Files>
        <File DestinationPath="french\**" SourcePath="C:\mygame\french\**"/>
      </Files>
      <Resources>
        <Resource Language="fr"/>
      </Resources>
    </ResourcePackage>
  </PackageFamily>

  <!-- DLC in the related set -->
  <PackageFamily ID="DLC" Optional="true" ManifestPath="C:\DLC\appxmanifest.xml">
    <Package ID="DLC.x86" Architecture="x86">
      <Files>
        <File DestinationPath="**" SourcePath="C:\DLC\**"/>
      </Files>
    </Package>
  </PackageFamily>

  <!-- DLC not part of the related set -->
  <PackageFamily ID="Themes" Optional="true" RelatedSet="false" ManifestPath="C:\themes\appxmanifest.xml">
    <Package ID="Themes.main" Architecture="neutral">
      <Files>
        <File DestinationPath="**" SourcePath="C:\themes\**"/>
      </Files>
    </Package>
  </PackageFamily>

  <!-- Existing packages that need to be included/referenced in the bundle -->
  <PrebuiltPackage Path="C:\prebuilt\DLC2.appxbundle" />

</PackagingLayout>
```

この例は、**ResourcePackage** 要素と **Optional** 要素が追加されている点がシンプルな例と異なります。

リソース パッケージは、**ResourcePackage** 要素を使って指定することができます。 **ResourcePackage** 内では、**Resources** 要素を使ってリソース パックのリソース修飾子を指定する必要があります。 リソース修飾子は、リソース パックによってサポートされているリソースです。ここには、2 つのリソース パッケージが定義されており、それぞれ英語とフランス語に固有のファイルが含まれていることがわかります。 リソース パックには、**Resources** 内に別の **Resource** 要素を追加することで複数の修飾子を付けることができます。 ディメンションが存在する場合は (ディメンションは language、scale、dxfl)、リソース ディメンションの既定のリソースも指定する必要があります。 ここでは、英語が既定の言語であることがわかります。つまり、システム言語としてフランス語を設定していないユーザーの場合、英語のリソース パックをダウンロードして英語で表示するようにフォールバックすることになります。


オプション パッケージには、それぞれ個々のパッケージ ファミリ名があり、**PackageFamily** 要素を使って定義する必要があります。ただし、**Optional** 属性を **true** に指定する必要があります。 **RelatedSet** 属性は、オプション パッケージが関連するセット内にあるかどうか、つまりプライマリ パッケージを使ってオプション パッケージを更新する必要があるかどうかを指定するために使用されます (既定では true)。

**PrebuiltPackage**要素を使用して、パッケージに含まれているか、ビルドするアプリ バンドル ファイルで参照されているパッケージ レイアウトで定義されていないを追加します。 この例では、別の DLC オプション パッケージがされている含まれている次に、プライマリ アプリ バンドル ファイルがそれを参照し、関連するセットの一部とすることができるようにします。


## <a name="build-app-packages-with-a-packaging-layout-and-makeappxexe"></a>パッケージ レイアウトと MakeAppx.exe を使ったアプリ パッケージのビルド
アプリのパッケージ レイアウトを作成したら、MakeAppx.exe を使ってアプリのパッケージのビルドを開始できます。 パッケージ レイアウトで定義されているパッケージをすべてビルドするには、次のコマンドを使用します。

``` example 
MakeAppx.exe build /f PackagingLayout.xml /op OutputPackages\
```

ただし、アプリを更新するが、変更されたファイルがまったく含まれていないパッケージがある場合、変更されたパッケージのみをビルドすることができます。 このページのシンプルなパッケージ レイアウトの例を使って、x64 アーキテクチャ パッケージをビルドすると、次のようなコマンドになります。

``` example 
MakeAppx.exe build /f PackagingLayout.xml /id "x64" /ip PreviousVersion\ /op OutputPackages\ /iv
```

`/id` フラグを使うとパッケージ レイアウトからビルドするパッケージを選ぶことができます。これは、レイアウトの **ID** 属性に対応します。 `/ip` は、この場合はパッケージの以前のバージョンの場所を示すために使用されます。 アプリ バンドル ファイルは引き続き以前のバージョンの**メディア**のパッケージを参照する必要があるために、以前のバージョンを提供する必要があります。 `/iv` フラグは、ビルドするパッケージのバージョンを自動的に増分するために使用されます (**AppxManifest** でバージョンを変更する代わりに)。 または、`/pv` スイッチと `/bv` スイッチを使うと、それぞれパッケージのバージョン (作成するすべてのパッケージについて) とバンドルのバージョン (作成するすべてのバンドルについて) を直接指定することができます。
このページの高度なパッケージ レイアウトの例を使って、**Themes** オプション バンドルとそれが参照する **Themes.main** アプリ パッケージのみビルドする場合、次のコマンドを使う必要があります。

``` example 
MakeAppx.exe build /f PackagingLayout.xml /id "Themes" /op OutputPackages\ /bc /nbp
```

`/bc` フラグは、**Themes** バンドルの子もビルドする必要があることを指定するために使用されます (この場合、**Themes.main** がビルドされます)。 `/nbp` フラグは、**Themes** バンドルの親をビルドしないことを指定するために使用されます。 オプション アプリ バンドルである **Themes** の親は、プライマリ アプリ バンドル **MyGame** です。 通常、関連するセットのオプション パッケージの場合、オプション パッケージをインストール可能にするにはプライマリ アプリ バンドルもビルドする必要があります。オプション パッケージが関連するセットに含まれる場合は、プライマリ アプリ バンドルでオプション パッケージも参照する必要があるためです (プライマリ パッケージとオプション パッケージの間でバージョン管理を保証するため)。 パッケージ間の親子関係を次の図に示します。

![パッケージ レイアウトの図](images/packaging-layout.png)
