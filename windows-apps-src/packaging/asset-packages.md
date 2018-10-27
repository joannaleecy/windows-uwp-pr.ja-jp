---
author: laurenhughes
title: アセット パッケージの概要
description: アセット パッケージは、アプリケーションの共通ファイルの一元的な場所として機能するパッケージの種類です。これにより、そのアーキテクチャ パッケージ全体で重複するファイルが事実上不要になります。
ms.author: lahugh
ms.date: 09/30/2018
ms.topic: article
keywords: Windows 10, パッケージ化, パッケージ レイアウト, アセット パッケージ
ms.localizationpriority: medium
ms.openlocfilehash: 98980e67d24eb96aa55af7fefe10b5e4c2cdfa67
ms.sourcegitcommit: 086001cffaf436e6e4324761d59bcc5e598c15ea
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/27/2018
ms.locfileid: "5700583"
---
# <a name="introduction-to-asset-packages"></a><span data-ttu-id="93249-104">アセット パッケージの概要</span><span class="sxs-lookup"><span data-stu-id="93249-104">Introduction to asset packages</span></span>

> [!IMPORTANT]
> <span data-ttu-id="93249-105">Microsoft Store にアプリを提出する予定がある場合、[Windows 開発者向けサポート](https://developer.microsoft.com/windows/support)に連絡してアセット パッケージを使う承認を得る必要があります。</span><span class="sxs-lookup"><span data-stu-id="93249-105">If you intend to submit your app to the Store, you need to contact [Windows developer support](https://developer.microsoft.com/windows/support) and get approval to use asset packages.</span></span>

<span data-ttu-id="93249-106">アセット パッケージは、アプリケーションの共通ファイルの一元的な場所として機能するパッケージの種類です。これにより、そのアーキテクチャ パッケージ全体で重複するファイルが事実上不要になります。</span><span class="sxs-lookup"><span data-stu-id="93249-106">Asset packages are a type of package that act as a centralized location for an application’s common files – effectively eliminating the necessity for duplicated files throughout its architecture packages.</span></span> <span data-ttu-id="93249-107">アセット パッケージは、どちらもアプリの実行に必要な静的コンテンツが含まれるように設計されているという点でリソース パッケージと似ていますが、ユーザーのシステム アーキテクチャ、言語、表示スケールに関係なくすべてのアセット パッケージがダウンロードされるという点で異なります。</span><span class="sxs-lookup"><span data-stu-id="93249-107">Asset packages are similar to resource packages in that they are both designed to contain static content needed for your app to run, but different in that all asset packages are always downloaded, regardless of the user’s system architecture, language, or display scale.</span></span>

![アセット パッケージ バンドルの図](images/primary-bundle.png)

<span data-ttu-id="93249-109">アセット パッケージには、すべてのアーキテクチャ、言語、およびスケールにとらわれないファイルが含まれているため、アセット パッケージを活用することによりパッケージ化されるアプリ サイズ全体が減少します (重複するファイルがなくなるため)。この結果、大きいアプリのローカル開発ディスク領域の使用量を管理しやすく、アプリのパッケージを全体的に管理しやすくなります。</span><span class="sxs-lookup"><span data-stu-id="93249-109">Because asset packages contain all the architecture, language, and scale agnostic files, leveraging asset packages results in a reduced overall packaged app size (since these files are no longer duplicated), helping you manage local development disk space usage for large apps and manage your app’s packages in general.</span></span> 

### <a name="how-do-asset-packages-affect-publishing"></a><span data-ttu-id="93249-110">アセット パッケージが公開に与える影響</span><span class="sxs-lookup"><span data-stu-id="93249-110">How do asset packages affect publishing?</span></span>
<span data-ttu-id="93249-111">アセット パッケージの最も明確な利点は、パッケージ アプリのサイズが小さくなることです。</span><span class="sxs-lookup"><span data-stu-id="93249-111">The most obvious benefit of asset packages is the reduced size of packaged apps.</span></span> <span data-ttu-id="93249-112">アプリ パッケージが小さい方が、App Store が処理するファイルが少なくなるためアプリの公開プロセスにかかる時間が短縮されます。しかし、これはアセット パッケージの最も重要な利点ではありません。</span><span class="sxs-lookup"><span data-stu-id="93249-112">Smaller app packages speed up the app’s publishing process by letting the Store process less files; however this is not the most important benefit of asset packages.</span></span>

<span data-ttu-id="93249-113">アセット パッケージを作成するとき、パッケージの実行を許可するかどうかを指定できます。</span><span class="sxs-lookup"><span data-stu-id="93249-113">When an asset package is created, you can specify whether the package should be allowed to execute.</span></span> <span data-ttu-id="93249-114">アセット パッケージには、アーキテクチャにとらわれないファイルのみを含める必要があります。一般に、.dll ファイルや .exe ファイルは含まれないため、アセット パッケージの実行は通常必要ありません。</span><span class="sxs-lookup"><span data-stu-id="93249-114">Since asset packages should contain only architecture agnostic files, they generally don't contain any .dll or .exe files, so for asset packages typically don't need to execute.</span></span> <span data-ttu-id="93249-115">この違いが重要なのは、公開プロセス中、マルウェアが含まれていないことを確認するためにすべての実行可能パッケージをスキャンする必要があり、大きいパッケージの方がこのスキャン プロセスに時間がかかるからです。</span><span class="sxs-lookup"><span data-stu-id="93249-115">The importance of this distinction is that during the publishing process, all executable packages must be scanned to ensure that they do not contain malware, and this scanning process takes longer for larger packages.</span></span> <span data-ttu-id="93249-116">ただし、パッケージが非実行可能として指定されている場合、アプリのインストールにより、このパッケージに含まれているファイルを実行できないことが確証されます。</span><span class="sxs-lookup"><span data-stu-id="93249-116">However, if a package is designated as non-executable, the installation of the app will ensure that files contained in this package cannot be executed.</span></span> <span data-ttu-id="93249-117">これにより、パッケージ全体のスキャンが確実に不要になり、アプリの公開時 (更新時も同様) のマルウェア スキャンにかかる時間が大幅に短縮されます。したがって、アセット パッケージを使うアプリの公開にかかる時間が大幅に短縮されます。</span><span class="sxs-lookup"><span data-stu-id="93249-117">This guarantee eliminates the need for a complete package scan and will greatly reduce the malware scan time during the publication of the app (and for updates too) - thus making publishing significantly faster for apps that use asset packages.</span></span> <span data-ttu-id="93249-118">その[フラット バンドル アプリ パッケージ](flat-bundles.md)は、ストア各 .appx または .msix パッケージのファイルを並行して処理することがあるために、この公開上の利点を取得するのにも使用する必要がありますに注意してください。</span><span class="sxs-lookup"><span data-stu-id="93249-118">Note that [flat bundle app packages](flat-bundles.md) must also be used to get this publishing benefit since this is what allows the Store to process each .appx or .msix package file in parallel.</span></span> 


### <a name="should-i-use-asset-packages"></a><span data-ttu-id="93249-119">アセット パッケージを使う必要があるかどうか</span><span class="sxs-lookup"><span data-stu-id="93249-119">Should I use asset packages?</span></span>
<span data-ttu-id="93249-120">アプリのファイル構造を更新してアセット パッケージを活用すると、パッケージ サイズの減少と無駄のない開発サイクルという具体的な利点が得られます。</span><span class="sxs-lookup"><span data-stu-id="93249-120">Updating the file structure of your app to leverage the use of asset packages can yield tangible benefits: reduced package size and leaner development iterations.</span></span> <span data-ttu-id="93249-121">アーキテクチャ パッケージすべてに大量の共通ファイルが含まれている場合や、アプリの大部分が非実行可能ファイルで構成されている場合、余分な時間はかかりますがアセット パッケージの使用に移行することを強くお勧めします。</span><span class="sxs-lookup"><span data-stu-id="93249-121">If your architecture packages all contain significant amount of files in common or if the bulk of your app is made up of non-executing files, it is highly recommended that you invest the extra time to convert to using asset packages.</span></span>

<span data-ttu-id="93249-122">ただし、アセット パッケージはアプリ コンテンツの選択性を実現するための手段ではない点に注意してください。</span><span class="sxs-lookup"><span data-stu-id="93249-122">However, it should be cautioned that asset packages are not a means to achieve app content optionality.</span></span> <span data-ttu-id="93249-123">アセット パッケージ ファイルは選択可能ではなく、ターゲット デバイスのアーキテクチャ、言語、スケールに関係なく**常に**ダウンロードされます。アプリでサポートするオプション コンテンツはすべて[オプション パッケージ](optional-packages.md)を使って実装する必要があります。</span><span class="sxs-lookup"><span data-stu-id="93249-123">Asset package files are non-optional and will **always** be downloaded regardless of the target device’s architecture, language, or scale - any optional content that you want your app to support should be implemented using [optional packages](optional-packages.md).</span></span> 


### <a name="how-to-create-an-asset-package"></a><span data-ttu-id="93249-124">アセット パッケージを作成する方法</span><span class="sxs-lookup"><span data-stu-id="93249-124">How to create an asset package</span></span>
<span data-ttu-id="93249-125">アセット パッケージを作成するには、パッケージ レイアウトを使うのが最も簡単です。</span><span class="sxs-lookup"><span data-stu-id="93249-125">The easiest way to create asset packages is using the packaging layout.</span></span> <span data-ttu-id="93249-126">ただし、アセット パッケージは MakeAppx.exe を使って手動で作成することもできます。</span><span class="sxs-lookup"><span data-stu-id="93249-126">However, asset packages can also be created manually using MakeAppx.exe.</span></span> <span data-ttu-id="93249-127">アセット パッケージに含めるファイルを指定するには、"マッピング ファイル" を作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="93249-127">To specify which files to include in the asset package, you will need to create a “mapping file”.</span></span> <span data-ttu-id="93249-128">この例では、アセット パッケージ内のファイルは "Video.mp4" だけですが、アセット パッケージのすべてのファイルがここに一覧表示されます。</span><span class="sxs-lookup"><span data-stu-id="93249-128">In this example, the only file in the asset package is "Video.mp4”, but all the asset package’s files should be listed here.</span></span> <span data-ttu-id="93249-129">アセット パッケージでは、**ResourceMetadata** の **ResourceDimensions** 指定子は省略される点に注意してください (リソース パッケージのマッピング ファイルと比較)。</span><span class="sxs-lookup"><span data-stu-id="93249-129">Note that the **ResourceDimensions** specifier in **ResourceMetadata** is omitted for asset packages (as compared to a mapping file for resource packages).</span></span>

```example 
[ResourceMetadata]
"ResourceId"        "Videos"

[Files]
"Video.mp4"         "Video.mp4"
```

<span data-ttu-id="93249-130">MakeAppx.exe を使ってアセット パッケージを作成するは、以下のコマンドを使用します。</span><span class="sxs-lookup"><span data-stu-id="93249-130">Use this command to create the asset package using MakeAppx.exe:</span></span> 

```syntax 
MakeAppx.exe pack /r /m AppxManifest.xml /f MappingFile.txt /p Videos.appx

...

MakeAppx.exe pack /r /m AppxManifest.xml /f MappingFile.txt /p Videos.msix

```
<span data-ttu-id="93249-131">ここでは、AppxManifest (ロゴ ファイル) で参照されるすべてのファイルをアセット パッケージに移動することはできない点に注意してください。これらのファイルはアーキテクチャ パッケージ間で重複している必要があります。</span><span class="sxs-lookup"><span data-stu-id="93249-131">It should be noted here that all of the files referenced in the AppxManifest (the logo files) cannot be moved into asset packages – these files must be duplicated across architecture packages.</span></span> <span data-ttu-id="93249-132">アセット パッケージに resources.pri を含めることはできません。MRT を使ってアセット パッケージ ファイルにアクセスすることはできません。</span><span class="sxs-lookup"><span data-stu-id="93249-132">Asset packages should also not contain a resources.pri; MRT cannot be used to access asset package files.</span></span> <span data-ttu-id="93249-133">アセット パッケージ ファイルにアクセスする方法とアセット パッケージではアプリを NTFS ドライブにインストールする必要がある理由については、「[アセット パッケージとパッケージ圧縮を使った開発](Package-Folding.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="93249-133">To learn more about how to access asset package files and why asset packages require your app to be installed to an NTFS drive, see [Developing with asset packages and package folding](Package-Folding.md).</span></span>

<span data-ttu-id="93249-134">アセット パッケージの実行を強化するかどうかを制御するには、AppxManifest の **Properties** 要素で **[uap6:AllowExecution](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-uap6-allowexecution)** を使うことができます。トップ レベルの **Package** 要素に **uap6** も追加して、以下のようにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="93249-134">To control whether an asset package is allowed to execute or not, you can use **[uap6:AllowExecution](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-uap6-allowexecution)** in the **Properties** element of the AppxManifest You must also add **uap6** to the top level **Package** element to become the following:</span></span> 

```XML
<Package IgnorableNamespaces="uap uap6" 
xmlns:uap6="http://schemas.microsoft.com/appx/manifest/uap/windows10/6" 
xmlns:uap="http://schemas.microsoft.com/appx/manifest/uap/windows10" 
xmlns="http://schemas.microsoft.com/appx/manifest/foundation/windows10">
```

 <span data-ttu-id="93249-135">指定しない場合、**AllowExecution** の既定値は **true** です。実行可能ファイルのないアセット パッケージでは、公開にかかる時間を短縮するため **false** に設定します。</span><span class="sxs-lookup"><span data-stu-id="93249-135">If not specified, the default value for **AllowExecution** is **true** – set it to **false** for asset packages with no executables to make publishing faster.</span></span>  



