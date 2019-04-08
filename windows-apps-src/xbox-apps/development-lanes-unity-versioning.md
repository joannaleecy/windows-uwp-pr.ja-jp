---
title: Unity - UWP プロジェクトのバージョン管理
description: UWP プロジェクトをバージョン管理します。
ms.localizationpriority: medium
ms.topic: article
ms.date: 02/08/2017
ms.openlocfilehash: 064eaf42fe7d664be273cd7e2222fa5d90be1a11
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57608867"
---
# <a name="unity-version-control-your-uwp-project"></a><span data-ttu-id="e8f9d-103">Unity:バージョン コントロール、UWP プロジェクト</span><span class="sxs-lookup"><span data-stu-id="e8f9d-103">Unity: Version control your UWP project</span></span>

<span data-ttu-id="e8f9d-104">ユニバーサル Windows プラットフォーム (UWP) を使って Xbox 用の Unity ゲームをまだ構築していない場合には、</span><span class="sxs-lookup"><span data-stu-id="e8f9d-104">Still haven't built your Unity game for Xbox using the Universal Windows Platform (UWP)?</span></span>  <span data-ttu-id="e8f9d-105">まず「[Xbox の UWP への Unity ゲームの移行](development-lanes-unity.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e8f9d-105">First see [Bringing Unity games to UWP on Xbox](development-lanes-unity.md).</span></span>

<span data-ttu-id="e8f9d-106">生成された UWP ディレクトリの一部をバージョン管理に追加することにはいくつかの理由があり、依存関係 (たとえば、Xbox Live SDK) の追加もその 1 つです。</span><span class="sxs-lookup"><span data-stu-id="e8f9d-106">There are a few different reasons why you would want to add parts of your generated UWP directory to version control, one of which is adding dependencies (for example,Xbox Live SDK).</span></span>  <span data-ttu-id="e8f9d-107">このチュートリアルでは、このシナリオを例として使用しますが、プロジェクトの個別のニーズを解決する際の参考になれば幸いです。</span><span class="sxs-lookup"><span data-stu-id="e8f9d-107">We'll use this scenario as an example for this tutorial, and hopefully it will help you solve your project's individual needs.</span></span>

<span data-ttu-id="e8f9d-108">***免責事項:使用する Git バージョン コントロール ソリューションとして。自分が異なる場合は、概念も変換。***</span><span class="sxs-lookup"><span data-stu-id="e8f9d-108">***Disclaimer: We'll be using Git as our version control solution.  If yours differs, the concepts should still translate.***</span></span>

<span data-ttu-id="e8f9d-109">サンプルのゲーム ***ScrapyardPhoenix*** のディレクトリが現在どのようになっているかを、確認のため以下に示します。</span><span class="sxs-lookup"><span data-stu-id="e8f9d-109">To refresh your memory, this is what the directory for our game, ***ScrapyardPhoenix***, looks like currently:</span></span>

![ビルドの保存先フォルダー](images/build-destination.png)

<span data-ttu-id="e8f9d-111">また、UWP ディレクトリは次のようになっています。</span><span class="sxs-lookup"><span data-stu-id="e8f9d-111">And this is what our UWP directory looks like:</span></span>

![UWP VS ソリューション](images/uwp-vs-solution.png)

<span data-ttu-id="e8f9d-113">このディレクトリで、注目する必要があるのは ***ScrapyardPhoenix*** (お客様のゲームの名前をここに挿入) フォルダーのみです。</span><span class="sxs-lookup"><span data-stu-id="e8f9d-113">In this directory, we're only concerned about one folder, the ***ScrapyardPhoenix*** (insert your game's name here) folder.</span></span>  <span data-ttu-id="e8f9d-114">他の要素はバージョン管理ではすべて無視できます。</span><span class="sxs-lookup"><span data-stu-id="e8f9d-114">Everything else can be ignored in our version control.</span></span>

<span data-ttu-id="e8f9d-115">***.Gitignore ファイルがどのような経験がないでしょうか。参照してください[gitignore](https://git-scm.com/docs/gitignore)します。***</span><span class="sxs-lookup"><span data-stu-id="e8f9d-115">***Unfamiliar with what a .gitignore file is?  See [gitignore](https://git-scm.com/docs/gitignore).***</span></span>

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

<span data-ttu-id="e8f9d-116">ここでは、**UWP/ScrapyardPhoenix** フォルダー内のいくつかのファイルやフォルダーを選択してバージョン管理に追加します。</span><span class="sxs-lookup"><span data-stu-id="e8f9d-116">We're going to want to select a few different files and folders from within the **UWP/ScrapyardPhoenix** folder to add to our version control.</span></span>  <span data-ttu-id="e8f9d-117">最初に、フォルダーの内容全体を詳しく見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="e8f9d-117">First let's look at the full thing in detail:</span></span>

![UWP ビルド ディレクトリ](images/uwp-build-directory.png)  

## <a name="folders"></a><span data-ttu-id="e8f9d-119">フォルダー</span><span class="sxs-lookup"><span data-stu-id="e8f9d-119">Folders</span></span>  

<span data-ttu-id="e8f9d-120">`Assets` | ***含める***|Microsoft Store のイメージが含まれています</span><span class="sxs-lookup"><span data-stu-id="e8f9d-120">`Assets` | ***Include*** | Contains Microsoft Store images</span></span>  
<span data-ttu-id="e8f9d-121">`Data`   | ***無視***|Unity が (シーンやシェーダー、スクリプト、プレハブなど) にプロジェクトをコンパイル</span><span class="sxs-lookup"><span data-stu-id="e8f9d-121">`Data`   | ***Ignore*** | Where Unity compiles your project to (Scenes, Shaders, Scripts, Prefabs, etc.)</span></span>  
<span data-ttu-id="e8f9d-122">`Dependencies` | ***含める***|このフォルダーは、UWP のすべての依存関係 (たとえば、XboxLiveSDK.dll) を作成しました</span><span class="sxs-lookup"><span data-stu-id="e8f9d-122">`Dependencies` | ***Include*** | This folder is one I created to keep all UWP dependencies in (for example, XboxLiveSDK.dll)</span></span>  
<span data-ttu-id="e8f9d-123">`Properties` | ***含める***|開発者によって変更可能なより高度な設定が含まれます</span><span class="sxs-lookup"><span data-stu-id="e8f9d-123">`Properties` | ***Include*** | Contains more advanced settings that can be modified by the developer</span></span>  
<span data-ttu-id="e8f9d-124">`Unprocessed` | ***無視***|Unity を含む`.dll`と`.pdb`ファイル</span><span class="sxs-lookup"><span data-stu-id="e8f9d-124">`Unprocessed` | ***Ignore*** | Contains Unity `.dll` and `.pdb` files</span></span>  

## <a name="files"></a><span data-ttu-id="e8f9d-125">ファイル</span><span class="sxs-lookup"><span data-stu-id="e8f9d-125">Files</span></span>  

<span data-ttu-id="e8f9d-126">`App.cs` | ***含める***|UWP アプリケーションのエントリ ポイント変更およびその他のソース ファイルを拡張するには、この</span><span class="sxs-lookup"><span data-stu-id="e8f9d-126">`App.cs` | ***Include*** | Entry point for your UWP application; this can be modified and extended with other source files</span></span>  
<span data-ttu-id="e8f9d-127">`Package.appxmanifest` | ***含める***|Appx アプリのパッケージ マニフェストのソース ファイル</span><span class="sxs-lookup"><span data-stu-id="e8f9d-127">`Package.appxmanifest` | ***Include*** | App package manifest source file for your AppX</span></span>  
<span data-ttu-id="e8f9d-128">`project.json` | ***含める***|NuGet パッケージについて説明します、`*.csproj`に依存</span><span class="sxs-lookup"><span data-stu-id="e8f9d-128">`project.json` | ***Include*** | Describes the NuGet packages your `*.csproj` depends on</span></span>  
<span data-ttu-id="e8f9d-129">`ScrapyardPhoenix.csproj` | ***含める***|UWP のビルド ターゲットについて説明します場合は、UWP に追加の依存関係を追加するプロジェクトをこの`*.csproj`ファイルは、その情報が格納されます</span><span class="sxs-lookup"><span data-stu-id="e8f9d-129">`ScrapyardPhoenix.csproj` | ***Include*** | Describes your UWP build target; if you add additional dependencies to your UWP project, this `*.csproj` file will contain that information</span></span>  
<span data-ttu-id="e8f9d-130">`ScrapyardPhoenix.csproj.user` | ***無視***|このファイルには、ローカル ユーザーの情報が含まれています。</span><span class="sxs-lookup"><span data-stu-id="e8f9d-130">`ScrapyardPhoenix.csproj.user` | ***Ignore*** | This file contains local user information</span></span>

## <a name="resulting-gitignore"></a><span data-ttu-id="e8f9d-131">結果として得られる .gitignore</span><span class="sxs-lookup"><span data-stu-id="e8f9d-131">Resulting .gitignore</span></span>

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

<span data-ttu-id="e8f9d-132">これで、開発チームのメンバーは生成された最新の UWP プロジェクトを利用できるようになります。</span><span class="sxs-lookup"><span data-stu-id="e8f9d-132">And there you go, now your teammates will be in sync with the UWP project you've generated.</span></span> <span data-ttu-id="e8f9d-133">新しいアセット、ソース、依存関係を、UWP プロジェクトに自由に追加できます。</span><span class="sxs-lookup"><span data-stu-id="e8f9d-133">Now you can feel free to add additional assets, source, and dependencies to your UWP project.</span></span>

<span data-ttu-id="e8f9d-134">UWP フォルダーのバージョン管理については、[これらの例](https://bitbucket.org/Unity-Technologies/windowsstoreappssamples/overview)もご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e8f9d-134">Some more examples of versioning the UWP folder can be found in [these examples](https://bitbucket.org/Unity-Technologies/windowsstoreappssamples/overview).</span></span>

## <a name="adding-dependencies-to-your-uwp-app"></a><span data-ttu-id="e8f9d-135">UWP アプリへの依存関係の追加</span><span class="sxs-lookup"><span data-stu-id="e8f9d-135">Adding dependencies to your UWP app</span></span>

<span data-ttu-id="e8f9d-136">依存関係を **Plugins** フォルダーの下の **Unity Assets** フォルダーに置くことにより、DLL と WINMD に依存関係を追加します。次に Inspector でそれを選択し、ターゲット プラットフォーム設定を適切に設定します。</span><span class="sxs-lookup"><span data-stu-id="e8f9d-136">Add dependencies to DLLs and WINMDs by putting them in your **Unity Assets** folder under a **Plugins** folder, then select them and set their target platform settings appropriately in the Inspector.</span></span>

![UWP ソリューション](images/uwp-solution.PNG)

<span data-ttu-id="e8f9d-138">***ScrapyardPhoenix (ユニバーサル Windows)*** が、Xbox Live SDK などへの参照を追加する対象のプロジェクトです。</span><span class="sxs-lookup"><span data-stu-id="e8f9d-138">***ScrapyardPhoenix (Universal Windows)*** is the project you would add a reference to, for example, the Xbox Live SDK.</span></span>

## <a name="see-also"></a><span data-ttu-id="e8f9d-139">関連項目</span><span class="sxs-lookup"><span data-stu-id="e8f9d-139">See also</span></span>
- [<span data-ttu-id="e8f9d-140">既存のゲームの Xbox への移行</span><span class="sxs-lookup"><span data-stu-id="e8f9d-140">Bringing existing games to Xbox</span></span>](development-lanes-landing.md)
- [<span data-ttu-id="e8f9d-141">Xbox One の UWP</span><span class="sxs-lookup"><span data-stu-id="e8f9d-141">UWP on Xbox One</span></span>](index.md)
