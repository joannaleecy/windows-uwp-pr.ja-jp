---
author: JordanEllis6809
title: Unity - UWP プロジェクトのバージョン管理
description: UWP プロジェクトをバージョン管理します。
ms.openlocfilehash: 3b796c31e6b284cea628ba68a34799cf9317ee2e
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.locfileid: "246557"
---
# <a name="unity-version-control-your-uwp-project"></a><span data-ttu-id="a574d-103">Unity: UWP プロジェクトのバージョン管理</span><span class="sxs-lookup"><span data-stu-id="a574d-103">Unity: Version control your UWP project</span></span>

<span data-ttu-id="a574d-104">ユニバーサル Windows プラットフォーム (UWP) を使って Xbox 用の Unity ゲームをまだ構築していない場合には、</span><span class="sxs-lookup"><span data-stu-id="a574d-104">Still haven't built your Unity game for Xbox using the Universal Windows Platform (UWP)?</span></span>  <span data-ttu-id="a574d-105">まず「[Xbox の UWP への Unity ゲームの移行](development-lanes-unity.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a574d-105">First see [Bringing Unity games to UWP on Xbox](development-lanes-unity.md).</span></span>

<span data-ttu-id="a574d-106">生成された UWP ディレクトリの一部をバージョン管理に追加することにはいくつかの理由があり、依存関係 (たとえば、Xbox Live SDK) の追加もその 1 つです。</span><span class="sxs-lookup"><span data-stu-id="a574d-106">There are a few different reasons why you would want to add parts of your generated UWP directory to version control, one of which is adding dependencies (for example,Xbox Live SDK).</span></span>  <span data-ttu-id="a574d-107">このチュートリアルでは、このシナリオを例として使用しますが、プロジェクトの個別のニーズを解決する際にも活用できます。</span><span class="sxs-lookup"><span data-stu-id="a574d-107">We'll use this scenario as an example for this tutorial, and hopefully it will help you solve your project's individual needs.</span></span>

***<span data-ttu-id="a574d-108">免責事項: ここでは、バージョン管理のソリューションとして Git を使用しています。</span><span class="sxs-lookup"><span data-stu-id="a574d-108">Disclaimer: We'll be using Git as our version control solution.</span></span>  <span data-ttu-id="a574d-109">使用するソリューションが異なる場合は、説明されている概念を参考にしてください。</span><span class="sxs-lookup"><span data-stu-id="a574d-109">If yours differs, the concepts should still translate.</span></span>***

<span data-ttu-id="a574d-110">サンプルのゲーム ***ScrapyardPhoenix*** のディレクトリが現在どのようになっているかを、確認のため以下に示します。</span><span class="sxs-lookup"><span data-stu-id="a574d-110">To refresh your memory, this is what the directory for our game, ***ScrapyardPhoenix***, looks like currently:</span></span>

![ビルドの保存先フォルダー](images/build-destination.png)

<span data-ttu-id="a574d-112">また、UWP ディレクトリは次のようになっています。</span><span class="sxs-lookup"><span data-stu-id="a574d-112">And this is what our UWP directory looks like:</span></span>

![UWP VS ソリューション](images/uwp-vs-solution.png)

<span data-ttu-id="a574d-114">このディレクトリで、注目する必要があるのは ***ScrapyardPhoenix*** (お客様のゲームの名前をここに挿入) フォルダーのみです。</span><span class="sxs-lookup"><span data-stu-id="a574d-114">In this directory, we're only concerned about one folder, the ***ScrapyardPhoenix*** (insert your game's name here) folder.</span></span>  <span data-ttu-id="a574d-115">他の要素はバージョン管理ではすべて無視できます。</span><span class="sxs-lookup"><span data-stu-id="a574d-115">Everything else can be ignored in our version control.</span></span>

***<span data-ttu-id="a574d-116">.gitignore ファイルについて詳しくは、</span><span class="sxs-lookup"><span data-stu-id="a574d-116">Unfamiliar with what a .gitignore file is?</span></span>  <span data-ttu-id="a574d-117">「[gitignore](https://git-scm.com/docs/gitignore)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a574d-117">See [gitignore](https://git-scm.com/docs/gitignore).</span></span>***

    ##################################################################
    # The original .gitignore file can be found at
    # https://github.com/github/gitignore/blob/master/Unity.gitignore
    ##################################################################

    # standard ignores for a Unity Project
    ...

    # ignore the whole UWP directory
    /UWP/**

    # except we want to keep... (this line will be modified and removed further down)
    !/UWP/ScrapyardPhoenix/

<span data-ttu-id="a574d-118">ここでは、**UWP/ScrapyardPhoenix** フォルダー内のいくつかのファイルやフォルダーを選択してバージョン管理に追加します。</span><span class="sxs-lookup"><span data-stu-id="a574d-118">We're going to want to select a few different files and folders from within the **UWP/ScrapyardPhoenix** folder to add to our version control.</span></span>  <span data-ttu-id="a574d-119">最初に、フォルダーの内容全体を詳しく見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="a574d-119">First let's look at the full thing in detail:</span></span>

![UWP ビルド ディレクトリ](images/uwp-build-directory.png)  

## <a name="folders"></a><span data-ttu-id="a574d-121">フォルダー</span><span class="sxs-lookup"><span data-stu-id="a574d-121">Folders</span></span>  

`Assets` | <span data-ttu-id="a574d-122">***含める*** | Windows ストアの画像が格納されています</span><span class="sxs-lookup"><span data-stu-id="a574d-122">***Include*** | Contains Windows Store images</span></span>  
`Data`   | <span data-ttu-id="a574d-123">***無視*** | Unity でプロジェクト (シーン、シェーダー、スクリプト、プレハブなど) のコンパイル先となる場所です</span><span class="sxs-lookup"><span data-stu-id="a574d-123">***Ignore*** | Where Unity compiles your project to (Scenes, Shaders, Scripts, Prefabs, etc.)</span></span>  
`Dependencies` | <span data-ttu-id="a574d-124">***含める*** | このフォルダーは、UWP のすべての依存関係 (たとえば、XboxLiveSDK.dll) を格納するために作成したフォルダーです</span><span class="sxs-lookup"><span data-stu-id="a574d-124">***Include*** | This folder is one I created to keep all UWP dependencies in (for example, XboxLiveSDK.dll)</span></span>  
`Properties` | <span data-ttu-id="a574d-125">***含める*** | 開発者が変更できる高度な設定が格納されています</span><span class="sxs-lookup"><span data-stu-id="a574d-125">***Include*** | Contains more advanced settings that can be modified by the developer</span></span>  
`Unprocessed` | <span data-ttu-id="a574d-126">***無視*** | Unity の `.dll` ファイルと `.pdb` ファイルが格納されています</span><span class="sxs-lookup"><span data-stu-id="a574d-126">***Ignore*** | Contains Unity `.dll` and `.pdb` files</span></span>  

## <a name="files"></a><span data-ttu-id="a574d-127">ファイル</span><span class="sxs-lookup"><span data-stu-id="a574d-127">Files</span></span>  

`App.cs` | <span data-ttu-id="a574d-128">***含める*** | UWP アプリケーションのエントリ ポイントであり、他のソース ファイルを使って、変更、拡張することができます</span><span class="sxs-lookup"><span data-stu-id="a574d-128">***Include*** | Entry point for your UWP application; this can be modified and extended with other source files</span></span>  
`Package.appxmanifest` | <span data-ttu-id="a574d-129">***含める*** | AppX のパッケージ マニフェストです</span><span class="sxs-lookup"><span data-stu-id="a574d-129">***Include*** | Package manifest for your AppX</span></span>  
`project.json` | <span data-ttu-id="a574d-130">***含める*** | `*.csproj` が依存する NuGet パッケージを記述します。</span><span class="sxs-lookup"><span data-stu-id="a574d-130">***Include*** | Describes the NuGet packages your `*.csproj` depends on</span></span>  
`ScrapyardPhoenix.csproj` | <span data-ttu-id="a574d-131">***含める*** | UWP ビルド ターゲットを記述します。新しい依存関係を UWP プロジェクトに追加した場合、この `*.csproj` ファイルにその情報が格納されます</span><span class="sxs-lookup"><span data-stu-id="a574d-131">***Include*** | Describes your UWP build target; if you add additional dependencies to your UWP project, this `*.csproj` file will contain that information</span></span>  
`ScrapyardPhoenix.csproj.user` | <span data-ttu-id="a574d-132">***無視*** | このファイルにはローカル ユーザーの情報が格納されます</span><span class="sxs-lookup"><span data-stu-id="a574d-132">***Ignore*** | This file contains local user information</span></span>

## <a name="resulting-gitignore"></a><span data-ttu-id="a574d-133">結果として得られる .gitignore</span><span class="sxs-lookup"><span data-stu-id="a574d-133">Resulting .gitignore</span></span>

    ##################################################################
    # The original .gitignore file can be found at
    # https://github.com/github/gitignore/blob/master/Unity.gitignore
    ##################################################################

    # standard ignores for a Unity Project
    ...

    # ignore the whole UWP directory
    /UWP/**

    # except we want to keep...
    !/UWP/ScrapyardPhoenix/Assets/*
    !/UWP/ScrapyardPhoenix/Dependencies/*
    !/UWP/ScrapyardPhoenix/Properties/*
    !/UWP/ScrapyardPhoenix/App.cs
    !/UWP/ScrapyardPhoenix/Package.appxmanifest
    !/UWP/ScrapyardPhoenix/project.json
    !/UWP/ScrapyardPhoenix/ScrapyardPhoenix.csproj

<span data-ttu-id="a574d-134">これで、開発チームのメンバーは生成された最新の UWP プロジェクトを利用できるようになります。</span><span class="sxs-lookup"><span data-stu-id="a574d-134">And there you go, now your teammates will be in sync with the UWP project you've generated.</span></span> <span data-ttu-id="a574d-135">新しいアセット、ソース、依存関係を、UWP プロジェクトに自由に追加できます。</span><span class="sxs-lookup"><span data-stu-id="a574d-135">Now you can feel free to add additional assets, source, and dependencies to your UWP project.</span></span>

<span data-ttu-id="a574d-136">UWP フォルダーのバージョン管理については、[これらの例](https://bitbucket.org/Unity-Technologies/windowsstoreappssamples/overview)もご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a574d-136">Some more examples of versioning the UWP folder can be found in [these examples](https://bitbucket.org/Unity-Technologies/windowsstoreappssamples/overview).</span></span>

## <a name="adding-dependencies-to-your-uwp-app"></a><span data-ttu-id="a574d-137">UWP アプリへの依存関係の追加</span><span class="sxs-lookup"><span data-stu-id="a574d-137">Adding dependencies to your UWP app</span></span>

<span data-ttu-id="a574d-138">依存関係を **Plugins** フォルダーの下の **Unity Assets** フォルダーに置くことにより、DLL と WINMD に依存関係を追加します。次に Inspector でそれを選択し、ターゲット プラットフォーム設定を適切に設定します。</span><span class="sxs-lookup"><span data-stu-id="a574d-138">Add dependencies to DLLs and WINMDs by putting them in your **Unity Assets** folder under a **Plugins** folder, then select them and set their target platform settings appropriately in the Inspector.</span></span>

![UWP ソリューション](images/uwp-solution.PNG)

<span data-ttu-id="a574d-140">***ScrapyardPhoenix (ユニバーサル Windows)*** が、Xbox Live SDK などへの参照を追加する対象のプロジェクトです。</span><span class="sxs-lookup"><span data-stu-id="a574d-140">***ScrapyardPhoenix (Universal Windows)*** is the project you would add a reference to, for example, the Xbox Live SDK.</span></span>

## <a name="see-also"></a><span data-ttu-id="a574d-141">関連項目</span><span class="sxs-lookup"><span data-stu-id="a574d-141">See also</span></span>
- [<span data-ttu-id="a574d-142">既存のゲームの Xbox への移行</span><span class="sxs-lookup"><span data-stu-id="a574d-142">Bringing existing games to Xbox</span></span>](development-lanes-landing.md)
- [<span data-ttu-id="a574d-143">Xbox One の UWP</span><span class="sxs-lookup"><span data-stu-id="a574d-143">UWP on Xbox One</span></span>](index.md)
