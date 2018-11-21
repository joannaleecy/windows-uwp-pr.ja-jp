---
author: laurenhughes
title: アセット パッケージとパッケージ圧縮を使った開発
description: アセット パッケージとパッケージ圧縮を使ってアプリケーションを効率的に整理する方法について説明します。
ms.author: lahugh
ms.date: 04/30/2018
ms.topic: article
keywords: Windows 10, パッケージ化, パッケージ レイアウト, アセット パッケージ
ms.localizationpriority: medium
ms.openlocfilehash: efdf560158e2b57ae9e05ecc31d49c7cf981d8c0
ms.sourcegitcommit: cbe7cf620622a5e4df7414f9e38dfecec1cfca99
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/21/2018
ms.locfileid: "7434279"
---
# <a name="developing-with-asset-packages-and-package-folding"></a><span data-ttu-id="e031c-104">アセット パッケージとパッケージ圧縮を使った開発</span><span class="sxs-lookup"><span data-stu-id="e031c-104">Developing with asset packages and package folding</span></span> 

> [!IMPORTANT]
> <span data-ttu-id="e031c-105">Microsoft Store にアプリを提出する予定がある場合、[Windows 開発者向けサポート](https://developer.microsoft.com/windows/support)に連絡してアセット パッケージとパッケージ圧縮を使う承認を得る必要があります。</span><span class="sxs-lookup"><span data-stu-id="e031c-105">If you intend to submit your app to the Store, you need to contact [Windows developer support](https://developer.microsoft.com/windows/support) and get approval to use asset packages and package folding.</span></span>

<span data-ttu-id="e031c-106">アセット パッケージによってパッケージ全体のサイズを減らし、アプリが Microsoft Store で公開されるまでの時間を短縮できます。</span><span class="sxs-lookup"><span data-stu-id="e031c-106">Asset packages can decrease the overall packaging size and publishing time for your apps to the Store.</span></span> <span data-ttu-id="e031c-107">アセット パッケージと、開発サイクルを早める方法について詳しくは、「[アセット パッケージの概要](asset-packages.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e031c-107">You can learn more about asset packages and how it can speed up your development iterations at [Introduction to asset packages](asset-packages.md).</span></span>

<span data-ttu-id="e031c-108">アプリにアセット パッケージを使うことを検討している場合や、使うことが既にわかっている場合、アセット パッケージによって開発プロセスがどのように変わるかに関心をお持ちかもしれません。</span><span class="sxs-lookup"><span data-stu-id="e031c-108">If you are thinking about using asset packages for your app or already know that you want to use it, then you are probably wondering about how asset packages will change your development process.</span></span> <span data-ttu-id="e031c-109">簡単に言えば、アプリの開発は同じままです。これは、アセット パッケージのパッケージ圧縮によって可能になります。</span><span class="sxs-lookup"><span data-stu-id="e031c-109">In short, app development for you stays the same - this is possible because of package folding for asset packages.</span></span>

## <a name="file-access-after-splitting-your-app"></a><span data-ttu-id="e031c-110">アプリの分割後のファイル アクセス</span><span class="sxs-lookup"><span data-stu-id="e031c-110">File access after splitting your app</span></span>

<span data-ttu-id="e031c-111">パッケージ圧縮が開発プロセスに影響を与えないことを理解するため、まずアプリを複数のパッケージ (アセット パッケージまたはリソース パッケージを使用) に分割するとどうなるかをもう一度確認してみましょう。</span><span class="sxs-lookup"><span data-stu-id="e031c-111">To understand how package folding doesn’t impact your development process, let’s step back first to understand what happens when you split your app into multiple packages (with either asset packages or resource packages).</span></span> 

<span data-ttu-id="e031c-112">大まかに言うと、アプリの一部のファイルを (アーキテクチャ パッケージではない) 他のパッケージに分割すると、コードが実行される場所から直接それらのファイルにアクセスすることができなくなります。</span><span class="sxs-lookup"><span data-stu-id="e031c-112">At a high level, when you split some of your app’s files into other packages (that are not architecture packages), you will not be able to access those files directly relative to where your code runs.</span></span> <span data-ttu-id="e031c-113">これは、パッケージがすべて、アーキテクチャ パッケージがインストールされている場所とは別のディレクトリにインストールされているためです。</span><span class="sxs-lookup"><span data-stu-id="e031c-113">This is because these packages are all installed into different directories from where your architecture package is installed.</span></span> <span data-ttu-id="e031c-114">たとえば、ゲームを作成している場合に、ゲームがローカライズされるフランス語とドイツ語用にビルドされた x86 と x64 の両方のコンピューター、し、ゲームのアプリ バンドル内のこれらのアプリ パッケージ ファイルがあります。</span><span class="sxs-lookup"><span data-stu-id="e031c-114">For example, if you’re making a game and your game is localized into French and German and you built for both x86 and x64 machines, then you should have these app package files within the app bundle of your game:</span></span>

-   <span data-ttu-id="e031c-115">MyGame_1.0_x86.appx</span><span class="sxs-lookup"><span data-stu-id="e031c-115">MyGame_1.0_x86.appx</span></span>
-   <span data-ttu-id="e031c-116">MyGame_1.0_x64.appx</span><span class="sxs-lookup"><span data-stu-id="e031c-116">MyGame_1.0_x64.appx</span></span>
-   <span data-ttu-id="e031c-117">MyGame_1.0_language-fr.appx</span><span class="sxs-lookup"><span data-stu-id="e031c-117">MyGame_1.0_language-fr.appx</span></span>
-   <span data-ttu-id="e031c-118">MyGame_1.0_language-de.appx</span><span class="sxs-lookup"><span data-stu-id="e031c-118">MyGame_1.0_language-de.appx</span></span>

<span data-ttu-id="e031c-119">ゲームがユーザーのコンピューターにインストールされると、各アプリのパッケージ ファイルは**WindowsApps**ディレクトリ内のフォルダーがあります。</span><span class="sxs-lookup"><span data-stu-id="e031c-119">When your game is installed to a user’s machine, each app package file will have its own folder in the **WindowsApps** directory.</span></span> <span data-ttu-id="e031c-120">したがって、64 ビット Windows を実行するフランス語ユーザーの場合、ゲームは次のようになります。</span><span class="sxs-lookup"><span data-stu-id="e031c-120">So for a French user running 64-bit Windows, your game will look like this:</span></span>

```example
C:\Program Files\WindowsApps\
|-- MyGame_1.0_x64
|   `-- …
|-- MyGame_1.0_language-fr
|   `-- …
`-- …(other apps)
```

<span data-ttu-id="e031c-121">ファイルには、ユーザーに適用できないするには、アプリ パッケージに (x86 およびドイツ語のパッケージ) がインストールされていることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="e031c-121">Note that the app package files that are not applicable to the user will not be installed (the x86 and German packages).</span></span> 

<span data-ttu-id="e031c-122">このユーザーの場合、ゲームの主な実行可能ファイルは **MyGame_1.0_x64** フォルダーに置かれ、そこから実行されます。通常、このフォルダー内のファイルにのみアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="e031c-122">For this user, your game’s main executable will be within the **MyGame_1.0_x64** folder and will run from there, and normally, it will only have access to the files within this folder.</span></span> <span data-ttu-id="e031c-123">**MyGame_1.0_language-fr** フォルダーのファイルにアクセスするには、MRT API または PackageManager API を使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="e031c-123">In order to access the files in the **MyGame_1.0_language-fr** folder, you would have to use either the MRT APIs or the PackageManager APIs.</span></span> <span data-ttu-id="e031c-124">MRT Api は、インストールされている言語から自動的に最も適切なファイルを選ぶことができます、 [windows.applicationmodel.resources.core](https://docs.microsoft.com/uwp/api/windows.applicationmodel.resources.core)MRT Api について詳しく見つけることができます。</span><span class="sxs-lookup"><span data-stu-id="e031c-124">The MRT APIs can automatically select the most appropriate file from the languages installed, you can find out more about MRT APIs at [Windows.ApplicationModel.Resources.Core](https://docs.microsoft.com/uwp/api/windows.applicationmodel.resources.core).</span></span> <span data-ttu-id="e031c-125">または、[PackageManager クラス](https://docs.microsoft.com/uwp/api/Windows.Management.Deployment.PackageManager)を使ってフランス語言語パッケージのインストール場所を見つけることもできます。</span><span class="sxs-lookup"><span data-stu-id="e031c-125">Alternatively, you can find the installed location of the French language package using the [PackageManager Class](https://docs.microsoft.com/uwp/api/Windows.Management.Deployment.PackageManager).</span></span> <span data-ttu-id="e031c-126">アプリのパッケージのインストール場所は変わることがり、ユーザーごとに異なるため、思い込まないでください。</span><span class="sxs-lookup"><span data-stu-id="e031c-126">You should never assume the installed location of the packages of your app since this can change and can vary between users.</span></span> 

## <a name="asset-package-folding"></a><span data-ttu-id="e031c-127">アセット パッケージの圧縮</span><span class="sxs-lookup"><span data-stu-id="e031c-127">Asset package folding</span></span>

<span data-ttu-id="e031c-128">アセット パッケージのファイルにはどのようにアクセスできるでしょうか。</span><span class="sxs-lookup"><span data-stu-id="e031c-128">So how can you access the files in your asset packages?</span></span> <span data-ttu-id="e031c-129">この場合も、アーキテクチャ パッケージ内の他のファイルへのアクセスに使っているファイル アクセス API を使うことができます。</span><span class="sxs-lookup"><span data-stu-id="e031c-129">Well, you can continue to use the file access APIs you are using to access any other file in your architecture package.</span></span> <span data-ttu-id="e031c-130">これは、アセット パッケージ ファイルは、インストールされるときにパッケージ圧縮プロセスを通じてアーキテクチャ パッケージに圧縮されるためです。</span><span class="sxs-lookup"><span data-stu-id="e031c-130">This is because asset package files will be folded into your architecture package when it is installed through the package folding process.</span></span> <span data-ttu-id="e031c-131">さらに、アセット パッケージ ファイルはもともとアーキテクチャ パッケージ内のファイルであるため、開発プロセスをルーズ ファイル配置からパッケージ化配置に移行するときに API の使用方法を変更する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="e031c-131">Furthermore, since asset package files should originally be files within your architecture packages, this means that you would not have to change API usage when you move from loose files deployment to packaged deployment in your development process.</span></span> 

<span data-ttu-id="e031c-132">パッケージ圧縮のしくみについて理解を深めるため、例を見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="e031c-132">To understand more about how package folding works, let’s start with an example.</span></span> <span data-ttu-id="e031c-133">次のファイル構造のゲーム プロジェクトがあるとします。</span><span class="sxs-lookup"><span data-stu-id="e031c-133">If you have a game project with the following file structure:</span></span>

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

<span data-ttu-id="e031c-134">ゲームを 3 つのパッケージ (x64 アーキテクチャ パッケージ、オーディオのアセット パッケージ、ビデオのアセット パッケージ) に分割する場合、ゲームは以下のパッケージに分割されます。</span><span class="sxs-lookup"><span data-stu-id="e031c-134">If you want to split your game into 3 packages: an x64 architecture package, an asset package for audios, and an asset package for videos, your game will be divided into these packages:</span></span>

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

<span data-ttu-id="e031c-135">ゲームをインストールすると、x64 パッケージがまず展開されます。</span><span class="sxs-lookup"><span data-stu-id="e031c-135">When you install your game, the x64 package will be deployed first.</span></span> <span data-ttu-id="e031c-136">次に、2 つのアセット パッケージも独自のフォルダーに展開されます (前の例と同様に **MyGame_1.0_language-fr**)。</span><span class="sxs-lookup"><span data-stu-id="e031c-136">Then the two asset packages will still be deployed to their own folders, just like **MyGame_1.0_language-fr** from our previous example.</span></span> <span data-ttu-id="e031c-137">ただし、パッケージ圧縮のため、アセット パッケージ ファイルは **MyGame_1.0_x64** フォルダーにも表れるようにハード リンクされます (したがって、ファイルは 2 か所に現れますが、ディスク領域を 2 倍消費するわけではありません)。</span><span class="sxs-lookup"><span data-stu-id="e031c-137">However, because of package folding, the asset package files will also be hard linked to appear in the **MyGame_1.0_x64** folder (so even though the files appear in two locations, they do not take up twice the disk space).</span></span> <span data-ttu-id="e031c-138">アセット パッケージ ファイルが表示される場所は、パッケージのルートから見てそのファイルが存在する場所とまったく同じです。</span><span class="sxs-lookup"><span data-stu-id="e031c-138">The location in which the asset package files will appear in is exactly the location that they are at relative to the root of the package.</span></span> <span data-ttu-id="e031c-139">ですから、展開されたゲームの最終レイアウトは次のようになります。</span><span class="sxs-lookup"><span data-stu-id="e031c-139">So here’s what the final layout of the deployed game will look like:</span></span>

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

<span data-ttu-id="e031c-140">アセット パッケージにパッケージ圧縮を使っても、同じ方法でアセット パッケージに分割したファイルにアクセスでき (アーキテクチャ フォルダーが元のプロジェクト フォルダーとまったく同じ構造である点に注目してください)、アセット パッケージを追加したり、コードに影響を与えずにアセット パッケージ間でファイルを移動したりすることができます。</span><span class="sxs-lookup"><span data-stu-id="e031c-140">When using package folding for asset packages, you can still access the files you’ve split into asset packages the same way (notice that the architecture folder has the exact same structure as the original project folder), and you can add asset packages or move files between asset packages without impacting your code.</span></span> 

<span data-ttu-id="e031c-141">次に、より複雑なパッケージ圧縮の例を考えてみましょう。</span><span class="sxs-lookup"><span data-stu-id="e031c-141">Now for a more complicated package folding example.</span></span> <span data-ttu-id="e031c-142">ここでは、レベルに基づいてファイルを分割するとします。元のプロジェクト フォルダーと同じ構造を維持する場合、パッケージは次のようになります。</span><span class="sxs-lookup"><span data-stu-id="e031c-142">Let’s say that you want to split your files based on level instead, and if you want to keep the same structure as the original project folder, your packages should look like this:</span></span>

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
<span data-ttu-id="e031c-143">これにより、**MyGame_Level1** パッケージの **Level1** フォルダーおよびファイルと **MyGame_Level2** パッケージの **Level2** フォルダーおよびファイルを、パッケージ圧縮時に **Audios** および **Videos** フォルダーに結合できるようになります。</span><span class="sxs-lookup"><span data-stu-id="e031c-143">This will allow the **Level1** folders and files in the **MyGame_Level1** package and **Level2** folders and files in the **MyGame_Level2** package to be merged into the **Audios** and **Videos** folders during package folding.</span></span> <span data-ttu-id="e031c-144">したがって、一般的なルールとして、MakeAppx.exe のマッピング ファイルまたは[パッケージ レイアウト](packaging-layout.md)でパッケージ化されたファイルに指定される相対パスは、パッケージ圧縮後にそれらのファイルへのアクセスに使うパスとなります。</span><span class="sxs-lookup"><span data-stu-id="e031c-144">So as a general rule, the relative path designated for packaged files in the mapping file or [packaging layout](packaging-layout.md) for MakeAppx.exe is the path you should use to access them after package folding.</span></span> 

<span data-ttu-id="e031c-145">最後に、同じ相対パスを持つ異なるアセット パッケージに 2 つのファイルがある場合、これによりパッケージ圧縮中に競合が発生します。</span><span class="sxs-lookup"><span data-stu-id="e031c-145">Lastly, if there are two files in different asset packages that have the same relative paths, this will cause a collision during package folding.</span></span> <span data-ttu-id="e031c-146">競合が発生した場合、アプリの展開でエラーが発生して失敗します。</span><span class="sxs-lookup"><span data-stu-id="e031c-146">If a collision occurs, the deployment of your app will result in an error and fail.</span></span> <span data-ttu-id="e031c-147">さらに、パッケージ圧縮ではハード リンクが利用されるため、アセット パッケージを使う場合、アプリを NTFS 以外のドライブに展開できなくなります。</span><span class="sxs-lookup"><span data-stu-id="e031c-147">Also, because package folding takes advantage of hard links, if you do use asset packages, your app will not be able to be deployed to non-NTFS drives.</span></span> <span data-ttu-id="e031c-148">ユーザーによってアプリがリムーバブル ドライブに移動される可能性が高いことがわかっている場合、アセット パッケージを使わないでください。</span><span class="sxs-lookup"><span data-stu-id="e031c-148">If you know your app will likely be moved to removable drives by your users, then you should not use asset packages.</span></span> 


