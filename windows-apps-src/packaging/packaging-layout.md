---
title: パッケージ レイアウトを使ったパッケージの作成
description: パッケージ レイアウトは、アプリのパッケージ構造を記述する 1 つのドキュメントです。 アプリのバンドル (プライマリおよびオプション)、バンドル内のパッケージ、パッケージ内のファイルを指定します。
ms.date: 04/30/2018
ms.topic: article
keywords: Windows 10, パッケージ化, パッケージ レイアウト, アセット パッケージ
ms.localizationpriority: medium
ms.openlocfilehash: 3e54b74cf3052fdeb5b70cc90f59ab0ea59aef76
ms.sourcegitcommit: b11f305dbf7649c4b68550b666487c77ea30d98f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/27/2018
ms.locfileid: "7835437"
---
# <a name="package-creation-with-the-packaging-layout"></a><span data-ttu-id="5d5af-105">パッケージ レイアウトを使ったパッケージの作成</span><span class="sxs-lookup"><span data-stu-id="5d5af-105">Package creation with the packaging layout</span></span>  

<span data-ttu-id="5d5af-106">アセット パッケージの導入により、開発者はより多くのパッケージの種類だけでなく、より多くのパッケージをビルドするためのツールを利用できるようになりました。</span><span class="sxs-lookup"><span data-stu-id="5d5af-106">With the introduction of asset packages, developers now have the tools to build more packages in addition to more package types.</span></span> <span data-ttu-id="5d5af-107">アプリが大規模で複雑になるにつれて、構成されるパッケージが多くなり、それらのパッケージを管理するのが難しくなるのはよくあることです (特に、Visual Studio 外でビルドする場合やマッピング ファイルを使う場合)。</span><span class="sxs-lookup"><span data-stu-id="5d5af-107">As an app gets larger and more complex, it will often be comprised of more packages, and the difficulty of managing these packages will increase (especially if you are building outside of Visual Studio and using mapping files).</span></span> <span data-ttu-id="5d5af-108">アプリのパッケージ化構造の管理を簡略化するには、MakeAppx.exe でサポートされているパッケージ レイアウトを使うことができます。</span><span class="sxs-lookup"><span data-stu-id="5d5af-108">To simplify the management of an app’s packaging structure, you can use the packaging layout supported by MakeAppx.exe.</span></span> 

<span data-ttu-id="5d5af-109">パッケージ レイアウトは、アプリのパッケージ構造を記述する 1 つの XML ドキュメントです。</span><span class="sxs-lookup"><span data-stu-id="5d5af-109">The packaging layout is a single XML document that describes packaging structure of the app.</span></span> <span data-ttu-id="5d5af-110">アプリのバンドル (プライマリおよびオプション)、バンドル内のパッケージ、パッケージ内のファイルを指定します。</span><span class="sxs-lookup"><span data-stu-id="5d5af-110">It specifies the bundles of an app (primary and optional), the packages in the bundles, and the files in the packages.</span></span> <span data-ttu-id="5d5af-111">ファイルは、さまざまなフォルダー、ドライブ、ネットワークの場所から選択することができます。</span><span class="sxs-lookup"><span data-stu-id="5d5af-111">Files can be selected from different folders, drives, and network locations.</span></span> <span data-ttu-id="5d5af-112">ワイルドカードを使って、ファイルを選択または除外することができます。</span><span class="sxs-lookup"><span data-stu-id="5d5af-112">Wildcards can be used to select or exclude files.</span></span>

<span data-ttu-id="5d5af-113">アプリのパッケージ レイアウトがセットアップされると、1 回のコマンド ライン呼び出しでアプリのパッケージをすべて作成するため MakeAppx.exe と共に使用されます。</span><span class="sxs-lookup"><span data-stu-id="5d5af-113">After the packaging layout for an app has been set up, it's used with MakeAppx.exe to create all of the packages for an app in a single command line call.</span></span> <span data-ttu-id="5d5af-114">展開のニーズに合わせて、パッケージ レイアウトを編集してパッケージ構造を変更できます。</span><span class="sxs-lookup"><span data-stu-id="5d5af-114">The packaging layout can be edited to alter the package structure to fit your deployment needs.</span></span> 


## <a name="simple-packaging-layout-example"></a><span data-ttu-id="5d5af-115">シンプルなパッケージ レイアウトの例</span><span class="sxs-lookup"><span data-stu-id="5d5af-115">Simple packaging layout example</span></span>

<span data-ttu-id="5d5af-116">シンプルなパッケージ レイアウトの例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="5d5af-116">Here's an example of what a simple packaging layout looks like:</span></span>

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

<span data-ttu-id="5d5af-117">この例を分割してそのしくみを理解してみましょう。</span><span class="sxs-lookup"><span data-stu-id="5d5af-117">Let's break this example down to understand how it works.</span></span>

### <a name="packagefamily"></a><span data-ttu-id="5d5af-118">PackageFamily</span><span class="sxs-lookup"><span data-stu-id="5d5af-118">PackageFamily</span></span>
<span data-ttu-id="5d5af-119">このパッケージ レイアウトでは 1 つのフラット アプリ バンドル ファイルを作成、x64 アーキテクチャ パッケージと「メディア」アセット パッケージ。</span><span class="sxs-lookup"><span data-stu-id="5d5af-119">This packaging layout will create a single flat app bundle file with an x64 architecture package and a “Media” asset package.</span></span> 

<span data-ttu-id="5d5af-120">アプリ バンドルの定義には **PackageFamily** 要素が使用されます。</span><span class="sxs-lookup"><span data-stu-id="5d5af-120">The **PackageFamily** element is used to define an app bundle.</span></span> <span data-ttu-id="5d5af-121">バンドルの **AppxManifest** を指定するには **ManifestPath** 属性を使う必要があります。**AppxManifest** は、バンドルのアーキテクチャ パッケージの **AppxManifest** に対応している必要があります。</span><span class="sxs-lookup"><span data-stu-id="5d5af-121">You must use the **ManifestPath** attribute to provide an **AppxManifest** for the bundle, the **AppxManifest** should correspond to the **AppxManifest** for the architecture package of the bundle.</span></span> <span data-ttu-id="5d5af-122">**ID** 属性も指定されている必要があります。</span><span class="sxs-lookup"><span data-stu-id="5d5af-122">The **ID** attribute must also be provided.</span></span> <span data-ttu-id="5d5af-123">これは、必要な場合はこのパッケージのみを作成できるように、パッケージの作成時に MakeAppx.exe と共に使用されます。また、結果として作成されるパッケージのファイル名になります。</span><span class="sxs-lookup"><span data-stu-id="5d5af-123">This is used with MakeAppx.exe during package creation so that you can create just this package if you want to, and this will be the file name of the resulting package.</span></span> <span data-ttu-id="5d5af-124">**FlatBundle** 属性は、作成するバンドルの種類を説明するために使用されます。フラット バンドル (詳しくはここで説明します) の場合は **true**、クラシック バンドルの場合は **false** です。</span><span class="sxs-lookup"><span data-stu-id="5d5af-124">The **FlatBundle** attribute is used to describe what type of bundle you want to create, **true** for a flat bundle (which you can read more about here), and **false** for a classic bundle.</span></span> <span data-ttu-id="5d5af-125">**ResourceManager** 属性は、このバンドル内のリソース パッケージがファイルにアクセスするために MRT を使うかどうかを指定するために使用されます。</span><span class="sxs-lookup"><span data-stu-id="5d5af-125">The **ResourceManager** attribute is used to specify if the resource packages within this bundle will use MRT in order to access the files.</span></span> <span data-ttu-id="5d5af-126">これは既定では **true** ですが、Windows 10 バージョン 1803 の時点ではまだ準備できていないため、この属性は **false** に設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="5d5af-126">This is by default **true**, but as of Windows 10, version 1803, this is not yet ready, so this attribute must be set to **false**.</span></span>


### <a name="package-and-assetpackage"></a><span data-ttu-id="5d5af-127">Package と AssetPackage</span><span class="sxs-lookup"><span data-stu-id="5d5af-127">Package and AssetPackage</span></span>
<span data-ttu-id="5d5af-128">**PackageFamily** 内では、アプリ バンドルに含まれるかアプリ バンドルが参照するパッケージが定義されます。</span><span class="sxs-lookup"><span data-stu-id="5d5af-128">Within the **PackageFamily**, the packages that the app bundle contains or references are defined.</span></span> <span data-ttu-id="5d5af-129">ここでは、アーキテクチャ パッケージ (メイン パッケージとも呼ばれます) が **Package** 要素を使って定義され、アセット パッケージが **AssetPackage** 要素を使って定義されます。</span><span class="sxs-lookup"><span data-stu-id="5d5af-129">Here, the architecture package (also called the main package) is defined with the **Package** element, and the asset package is defined with the **AssetPackage** element.</span></span> <span data-ttu-id="5d5af-130">アーキテクチャ パッケージは、パッケージの対象アーキテクチャ ("x64"、"x86"、"arm"、"neutral" のいずれか) を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="5d5af-130">The architecture package must specify which architecture the package is for, either “x64”, “x86”, “arm”, or “neutral”.</span></span> <span data-ttu-id="5d5af-131">**ManifestPath** 属性をもう一度使って、このパッケージ専用に **AppxManifest** を直接指定することもできます (オプション)。</span><span class="sxs-lookup"><span data-stu-id="5d5af-131">You can also (optionally) directly provide an **AppxManifest** specifically for this package by using the **ManifestPath** attribute again.</span></span> <span data-ttu-id="5d5af-132">**AppxManifest** が指定されない場合、**PackageFamily** に指定された **AppxManifest** から自動的に生成されます。</span><span class="sxs-lookup"><span data-stu-id="5d5af-132">If an **AppxManifest** is not provided, one will be automatically generated from the **AppxManifest** provided for the **PackageFamily**.</span></span> 

<span data-ttu-id="5d5af-133">既定では、**AppxManifest** はバンドル内のすべてのパッケージに生成されます。</span><span class="sxs-lookup"><span data-stu-id="5d5af-133">By default and **AppxManifest** will be generated for every package within the bundle.</span></span> <span data-ttu-id="5d5af-134">アセット パッケージでは、**AllowExecution** 属性を設定することもできます。</span><span class="sxs-lookup"><span data-stu-id="5d5af-134">For the asset package, you can also set the **AllowExecution** attribute.</span></span> <span data-ttu-id="5d5af-135">これを **false** に設定すると (既定)、実行する必要のないパッケージがウイルス スキャンに公開プロセスをブロックさせることがなくなるため、アプリの公開にかかる時間が短縮されます (これについて詳しくは「[アセット パッケージの概要](asset-packages.md))」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="5d5af-135">Setting this to **false** (the default), will help decrease the publishing time for your app since packages that don’t need to execute won’t have their virus scan block the publishing process (you can learn more about this at [Introduction to asset packages](asset-packages.md)).</span></span> 

### <a name="files"></a><span data-ttu-id="5d5af-136">File</span><span class="sxs-lookup"><span data-stu-id="5d5af-136">Files</span></span>
<span data-ttu-id="5d5af-137">各パッケージ定義内では、**File** 要素を使ってこのパッケージに含めるファイルを選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="5d5af-137">Within each package definition, you can use the **File** element to select files to be included in this package.</span></span> <span data-ttu-id="5d5af-138">**SourcePath** 属性は、ファイルが存在するローカルの場所です。</span><span class="sxs-lookup"><span data-stu-id="5d5af-138">The **SourcePath** attribute is where the files are locally.</span></span> <span data-ttu-id="5d5af-139">ファイルは、さまざまなフォルダー (相対パスを指定)、さまざまなドライブ (絶対パスを指定)、さらにはネットワーク共有 (`\\myshare\myapp\*` のように指定) から選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="5d5af-139">You can select files from different folders (by providing relative paths), different drives (by providing absolute paths), or even network shares (by providing something like `\\myshare\myapp\*`).</span></span> <span data-ttu-id="5d5af-140">**DestinationPath** は、ファイルが最終的に配置されるパッケージ内の場所 (パッケージのルートを基準) です。</span><span class="sxs-lookup"><span data-stu-id="5d5af-140">The **DestinationPath** is where the files will end up within the package, relative to the package root.</span></span> <span data-ttu-id="5d5af-141">**ExcludePath** を使うと (他の 2 つの属性の代わりに)、同じパッケージ内にある他の **File** 要素の **SourcePath** 属性によって選択されたファイルから除外するファイルを選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="5d5af-141">**ExcludePath** can be used (instead of the other two attributes) to select files to be excluded from the ones selected by other **File** elements’ **SourcePath** attributes within the same package.</span></span>

<span data-ttu-id="5d5af-142">各 **File** 要素を使うと、ワイルドカードを使って複数のファイルを選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="5d5af-142">Each **File** element can be used to select multiple files by using wildcards.</span></span> <span data-ttu-id="5d5af-143">通常、単一ワイルドカード (`*`) はパス内の任意の場所で何回でも使うことができます。</span><span class="sxs-lookup"><span data-stu-id="5d5af-143">In general, single wildcard (`*`) can be used anywhere within the path any number of times.</span></span> <span data-ttu-id="5d5af-144">ただし、単一ワイルドカードが一致するのはフォルダー内のファイルのみであり、サブフォルダーには一致しません。</span><span class="sxs-lookup"><span data-stu-id="5d5af-144">However, a single wildcard will only match the files within a folder and not any subfolders.</span></span> <span data-ttu-id="5d5af-145">たとえば、**SourcePath** で `C:\MyGame\*\*` を使って `C:\MyGame\Audios\UI.mp3` ファイルと `C:\MyGame\Videos\intro.mp4` ファイルを選ぶことはできますが、`C:\MyGame\Audios\Level1\warp.mp3` を選ぶことはできません。</span><span class="sxs-lookup"><span data-stu-id="5d5af-145">For example, `C:\MyGame\*\*` can be used in the **SourcePath** to select the files `C:\MyGame\Audios\UI.mp3` and `C:\MyGame\Videos\intro.mp4`, but it cannot select `C:\MyGame\Audios\Level1\warp.mp3`.</span></span> <span data-ttu-id="5d5af-146">二重ワイルドカード (`**`) は、フォルダーまたはファイル名として使って再帰的に一致させることができます (ただし、名前の一部で使うことはできません)。</span><span class="sxs-lookup"><span data-stu-id="5d5af-146">The double wildcard (`**`) can also be used in place of folder or file names to match anything recursively (but it cannot be next to partial names).</span></span> <span data-ttu-id="5d5af-147">たとえば、`C:\MyGame\**\Level1\**` を使うと `C:\MyGame\Audios\Level1\warp.mp3` と `C:\MyGame\Videos\Bonus\Level1\DLC1\intro.mp4` を選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="5d5af-147">For example, `C:\MyGame\**\Level1\**` can select `C:\MyGame\Audios\Level1\warp.mp3` and `C:\MyGame\Videos\Bonus\Level1\DLC1\intro.mp4`.</span></span> <span data-ttu-id="5d5af-148">移動元と移動先の異なる場所でワイルドカードを使う場合、ワイルドカードを使ってパッケージ化プロセスの一部としてファイル名を直接変更することもできます。</span><span class="sxs-lookup"><span data-stu-id="5d5af-148">Wildcards can also be used to directly change file names as part of the packaging process if the wildcards are used in different places between the source and destination.</span></span> <span data-ttu-id="5d5af-149">たとえば、**SourcePath** に `C:\MyGame\Audios\*`、**DestinationPath** に `Sound\copy_*` を使うと、`C:\MyGame\Audios\UI.mp3` を選んでパッケージに `Sound\copy_UI.mp3` として表示することができます。</span><span class="sxs-lookup"><span data-stu-id="5d5af-149">For example, having `C:\MyGame\Audios\*` for **SourcePath** and `Sound\copy_*` for **DestinationPath** can select `C:\MyGame\Audios\UI.mp3` and have it appear in the package as `Sound\copy_UI.mp3`.</span></span> <span data-ttu-id="5d5af-150">通常、単一ワイルドカードおよび二重ワイルドカードの数は単一の **File** 要素の **SourcePath** および **DestinationPath** と同じでなければなりません。</span><span class="sxs-lookup"><span data-stu-id="5d5af-150">In general, the number of single wildcards and double wildcards must be the same for the **SourcePath** and **DestinationPath** of a single **File** element.</span></span>


## <a name="advanced-packaging-layout-example"></a><span data-ttu-id="5d5af-151">高度なパッケージ レイアウトの例</span><span class="sxs-lookup"><span data-stu-id="5d5af-151">Advanced packaging layout example</span></span>

<span data-ttu-id="5d5af-152">より複雑なパッケージ レイアウトの例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="5d5af-152">Here's an example of a more complicated packaging layout:</span></span>

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

<span data-ttu-id="5d5af-153">この例は、**ResourcePackage** 要素と **Optional** 要素が追加されている点がシンプルな例と異なります。</span><span class="sxs-lookup"><span data-stu-id="5d5af-153">This example differs from the simple example with the addition of **ResourcePackage** and **Optional** elements.</span></span>

<span data-ttu-id="5d5af-154">リソース パッケージは、**ResourcePackage** 要素を使って指定することができます。</span><span class="sxs-lookup"><span data-stu-id="5d5af-154">Resource packages can be specified with the **ResourcePackage** element.</span></span> <span data-ttu-id="5d5af-155">**ResourcePackage** 内では、**Resources** 要素を使ってリソース パックのリソース修飾子を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="5d5af-155">Within the **ResourcePackage**, the **Resources** element must be used to specify the resource qualifiers of the resource pack.</span></span> <span data-ttu-id="5d5af-156">リソース修飾子は、リソース パックによってサポートされているリソースです。ここには、2 つのリソース パッケージが定義されており、それぞれ英語とフランス語に固有のファイルが含まれていることがわかります。</span><span class="sxs-lookup"><span data-stu-id="5d5af-156">The resource qualifiers are the resources that are supported by the resource pack, here, we can see that there are two resource packs defined and they each contain the English and French specific files.</span></span> <span data-ttu-id="5d5af-157">リソース パックには、**Resources** 内に別の **Resource** 要素を追加することで複数の修飾子を付けることができます。</span><span class="sxs-lookup"><span data-stu-id="5d5af-157">A resource pack can have more than one qualifier, this can be done by adding another **Resource** element within **Resources**.</span></span> <span data-ttu-id="5d5af-158">ディメンションが存在する場合は (ディメンションは language、scale、dxfl)、リソース ディメンションの既定のリソースも指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="5d5af-158">A default resource for the resource dimension must also be specified if the dimension exists (dimensions being language, scale, dxfl).</span></span> <span data-ttu-id="5d5af-159">ここでは、英語が既定の言語であることがわかります。つまり、システム言語としてフランス語を設定していないユーザーの場合、英語のリソース パックをダウンロードして英語で表示するようにフォールバックすることになります。</span><span class="sxs-lookup"><span data-stu-id="5d5af-159">Here, we can see that English is the default language, meaning that for users that does not have a system language of French set, they will fallback to downloading the English resource pack and display in English.</span></span>


<span data-ttu-id="5d5af-160">オプション パッケージには、それぞれ個々のパッケージ ファミリ名があり、**PackageFamily** 要素を使って定義する必要があります。ただし、**Optional** 属性を **true** に指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="5d5af-160">Optional packages each have their own distinct package family names and must be defined with **PackageFamily** elements, while specifying the **Optional** attribute to be **true**.</span></span> <span data-ttu-id="5d5af-161">**RelatedSet** 属性は、オプション パッケージが関連するセット内にあるかどうか、つまりプライマリ パッケージを使ってオプション パッケージを更新する必要があるかどうかを指定するために使用されます (既定では true)。</span><span class="sxs-lookup"><span data-stu-id="5d5af-161">The **RelatedSet** attribute is used to specify whether the optional package is within the related set (by default this is true) – whether the optional package should be updated with the primary package.</span></span>

<span data-ttu-id="5d5af-162">**PrebuiltPackage**要素を使用して、パッケージをビルドするアプリ バンドル ファイルで参照されているまたは含まれているパッケージ レイアウトで定義されていないを追加します。</span><span class="sxs-lookup"><span data-stu-id="5d5af-162">The **PrebuiltPackage** element is used to add packages that are not defined in the packaging layout to be included or referenced in the app bundle file(s) to be built.</span></span> <span data-ttu-id="5d5af-163">この例では、別の DLC オプション パッケージは、プライマリ アプリ バンドル ファイルがそれを参照し、関連するセットの一部とすることができるように、ここで含まれないがします。</span><span class="sxs-lookup"><span data-stu-id="5d5af-163">In this case, another DLC optional package is being included here so that the primary app bundle file can reference it and have it be part of the related set.</span></span>


## <a name="build-app-packages-with-a-packaging-layout-and-makeappxexe"></a><span data-ttu-id="5d5af-164">パッケージ レイアウトと MakeAppx.exe を使ったアプリ パッケージのビルド</span><span class="sxs-lookup"><span data-stu-id="5d5af-164">Build app packages with a packaging layout and MakeAppx.exe</span></span>
<span data-ttu-id="5d5af-165">アプリのパッケージ レイアウトを作成したら、MakeAppx.exe を使ってアプリのパッケージのビルドを開始できます。</span><span class="sxs-lookup"><span data-stu-id="5d5af-165">Once you have the packaging layout for your app, you can start using MakeAppx.exe to build the packages of your app.</span></span> <span data-ttu-id="5d5af-166">パッケージ レイアウトで定義されているパッケージをすべてビルドするには、次のコマンドを使用します。</span><span class="sxs-lookup"><span data-stu-id="5d5af-166">To build all of the packages defined in the packaging layout, use the command:</span></span>

``` example 
MakeAppx.exe build /f PackagingLayout.xml /op OutputPackages\
```

<span data-ttu-id="5d5af-167">ただし、アプリを更新するが、変更されたファイルがまったく含まれていないパッケージがある場合、変更されたパッケージのみをビルドすることができます。</span><span class="sxs-lookup"><span data-stu-id="5d5af-167">But, if you are updating your app and some packages don't contain any changed files, you can build only the packages that have changed.</span></span> <span data-ttu-id="5d5af-168">このページのシンプルなパッケージ レイアウトの例を使って、x64 アーキテクチャ パッケージをビルドすると、次のようなコマンドになります。</span><span class="sxs-lookup"><span data-stu-id="5d5af-168">Using the simple packaging layout example on this page and building the x64 architecture package, this is what our command would look like:</span></span>

``` example 
MakeAppx.exe build /f PackagingLayout.xml /id "x64" /ip PreviousVersion\ /op OutputPackages\ /iv
```

<span data-ttu-id="5d5af-169">`/id` フラグを使うとパッケージ レイアウトからビルドするパッケージを選ぶことができます。これは、レイアウトの **ID** 属性に対応します。</span><span class="sxs-lookup"><span data-stu-id="5d5af-169">The `/id` flag can be used to select the packages to be built from the packaging layout, corresponding to the **ID** attribute in the layout.</span></span> <span data-ttu-id="5d5af-170">`/ip` は、この場合はパッケージの以前のバージョンの場所を示すために使用されます。</span><span class="sxs-lookup"><span data-stu-id="5d5af-170">The `/ip` is used to indicate where the previous version of the packages are in this case.</span></span> <span data-ttu-id="5d5af-171">アプリ バンドル ファイルは引き続き以前のバージョンの**メディア**のパッケージを参照する必要があるために、以前のバージョンを提供する必要があります。</span><span class="sxs-lookup"><span data-stu-id="5d5af-171">The previous version must be provided because the app bundle file still needs to reference the previous version of the **Media** package.</span></span> <span data-ttu-id="5d5af-172">`/iv` フラグは、ビルドするパッケージのバージョンを自動的に増分するために使用されます (**AppxManifest** でバージョンを変更する代わりに)。</span><span class="sxs-lookup"><span data-stu-id="5d5af-172">The `/iv` flag is used to automatically increment the version of the packages being built (instead of changing the version in the **AppxManifest**).</span></span> <span data-ttu-id="5d5af-173">または、`/pv` スイッチと `/bv` スイッチを使うと、それぞれパッケージのバージョン (作成するすべてのパッケージについて) とバンドルのバージョン (作成するすべてのバンドルについて) を直接指定することができます。</span><span class="sxs-lookup"><span data-stu-id="5d5af-173">Alternatively, the switches `/pv` and `/bv` can be used to directly provide a package version (for all packages to be created) and a bundle version (for all bundles to be created), respectively.</span></span>
<span data-ttu-id="5d5af-174">このページの高度なパッケージ レイアウトの例を使って、**Themes** オプション バンドルとそれが参照する **Themes.main** アプリ パッケージのみビルドする場合、次のコマンドを使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="5d5af-174">Using the advanced packaging layout example on this page, if you want to only build the **Themes** optional bundle and the **Themes.main** app package that it references, you would use this command:</span></span>

``` example 
MakeAppx.exe build /f PackagingLayout.xml /id "Themes" /op OutputPackages\ /bc /nbp
```

<span data-ttu-id="5d5af-175">`/bc` フラグは、**Themes** バンドルの子もビルドする必要があることを指定するために使用されます (この場合、**Themes.main** がビルドされます)。</span><span class="sxs-lookup"><span data-stu-id="5d5af-175">The `/bc` flag is used to denote that the children of the **Themes** bundle should also be built (in this case **Themes.main** will be built).</span></span> <span data-ttu-id="5d5af-176">`/nbp` フラグは、**Themes** バンドルの親をビルドしないことを指定するために使用されます。</span><span class="sxs-lookup"><span data-stu-id="5d5af-176">The `/nbp` flag is used to denote that the parent of the **Themes** bundle should not be built.</span></span> <span data-ttu-id="5d5af-177">オプション アプリ バンドルである **Themes** の親は、プライマリ アプリ バンドル **MyGame** です。</span><span class="sxs-lookup"><span data-stu-id="5d5af-177">The parent of **Themes**, which is an optional app bundle, is the primary app bundle: **MyGame**.</span></span> <span data-ttu-id="5d5af-178">通常、関連するセットのオプション パッケージの場合、オプション パッケージをインストール可能にするにはプライマリ アプリ バンドルもビルドする必要があります。オプション パッケージが関連するセットに含まれる場合は、プライマリ アプリ バンドルでオプション パッケージも参照する必要があるためです (プライマリ パッケージとオプション パッケージの間でバージョン管理を保証するため)。</span><span class="sxs-lookup"><span data-stu-id="5d5af-178">Usually for an optional package in a related set, the primary app bundle must also be built for the optional package to be installable, since the optional package is also referenced in the primary app bundle when it is in a related set (to guarantee versioning between the primary and the optional packages).</span></span> <span data-ttu-id="5d5af-179">パッケージ間の親子関係を次の図に示します。</span><span class="sxs-lookup"><span data-stu-id="5d5af-179">The parent child relationship between packages is illustrated in the following diagram:</span></span>

![パッケージ レイアウトの図](images/packaging-layout.png)
