---
title: Xbox の UWP への Unity ゲームの移行
description: Xbox での Unity UWP 開発。
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp
ms.assetid: fca3267a-0c0f-4872-8017-90384fb34215
ms.localizationpriority: medium
ms.openlocfilehash: 64a686aea24d23b5e999780eaa0eda661af3637f
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57611687"
---
# <a name="bringing-unity-games-to-uwp-on-xbox"></a><span data-ttu-id="bf469-104">Xbox の UWP への Unity ゲームの移行</span><span class="sxs-lookup"><span data-stu-id="bf469-104">Bringing Unity games to UWP on Xbox</span></span>


<span data-ttu-id="bf469-105">このチュートリアルでは、既に Unity のゲームが存在し、ビルドおよび展開する準備ができていることを前提としています。</span><span class="sxs-lookup"><span data-stu-id="bf469-105">In this step-by-step tutorial, we assume that you already have a game in Unity, ready to be built and deployed.</span></span>

<span data-ttu-id="bf469-106">[このチュートリアルのビデオ バージョン](https://www.youtube.com/watch?v=f0Ptvw7k-CE)もご覧ください。</span><span class="sxs-lookup"><span data-stu-id="bf469-106">See also a [video version of this tutorial](https://www.youtube.com/watch?v=f0Ptvw7k-CE).</span></span>

<span data-ttu-id="bf469-107">Unity UWP プロジェクトのバージョン管理については、</span><span class="sxs-lookup"><span data-stu-id="bf469-107">Looking to version your Unity UWP project?</span></span> <span data-ttu-id="bf469-108">「[UWP プロジェクトのバージョン管理](development-lanes-unity-versioning.md)」をご覧ください</span><span class="sxs-lookup"><span data-stu-id="bf469-108">See [Version control your UWP project](development-lanes-unity-versioning.md).</span></span>

## <a name="step-0-ensure-unity-is-installed-correctly"></a><span data-ttu-id="bf469-109">手順 0:Unity が正しくインストールされていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="bf469-109">Step 0: Ensure Unity is installed correctly</span></span>

<span data-ttu-id="bf469-110">Unity をインストールするときに、以下のコンポーネントを選択する必要があります。</span><span class="sxs-lookup"><span data-stu-id="bf469-110">When installing Unity, these components must be selected:</span></span>

![Unity のインストール コンポーネント](images/unity-install-components.png)

## <a name="step-1-building-the-uwp-solution"></a><span data-ttu-id="bf469-112">手順 1:UWP のソリューションの構築</span><span class="sxs-lookup"><span data-stu-id="bf469-112">Step 1: Building the UWP solution</span></span>

<span data-ttu-id="bf469-113">Unity ゲーム プロジェクトで、**[File] -> [Build Settings]** から **[Build Settings]** ウィンドウを開き、Microsoft Store オプション メニューに移動します。</span><span class="sxs-lookup"><span data-stu-id="bf469-113">In your Unity game project, open the **Build Settings** windows located at **File -> Build Settings**, and go to the Microsoft Store options menu.</span></span>

![[Build Settings] ウィンドウ](images/build-settings.png)

<span data-ttu-id="bf469-115">**[SDK]** 設定が **[Universal 10]** であることを確認し、**[Build]** ボタンを選択します。作成先フォルダーを要求するエクスプローラー ウィンドウが起動します。</span><span class="sxs-lookup"><span data-stu-id="bf469-115">Make sure the **SDK** setting is set to **Universal 10**, and then select the **Build** button, which will launch a File Explorer window asking for a destination folder.</span></span> <span data-ttu-id="bf469-116">プロジェクトの **[Assets]** ディレクトリと並んで **[UWP]** というフォルダーを作成し、ビルドの保存先フォルダーとしてこのフォルダーを選択します。</span><span class="sxs-lookup"><span data-stu-id="bf469-116">Create a folder named **UWP** next to the **Assets** directory of your project, and choose this folder as the destination folder of the build.</span></span>

![ビルドの保存先フォルダー](images/build-destination.png)

<span data-ttu-id="bf469-118">Unity で新しい Visual Studio ソリューションを作成できたので、これを使って UWP ゲームを展開します。</span><span class="sxs-lookup"><span data-stu-id="bf469-118">Unity has now created a new Visual Studio solution that we will use to deploy your UWP game from.</span></span>

![UWP VS ソリューション](images/uwp-vs-solution.png)

## <a name="step-2-deploying-your-game"></a><span data-ttu-id="bf469-120">手順 2:ゲームを展開します。</span><span class="sxs-lookup"><span data-stu-id="bf469-120">Step 2: Deploying your game</span></span>

<span data-ttu-id="bf469-121">**[UWP]** フォルダーに新しく作成されたソリューションを開き、ターゲット プラットフォームを **[x64]** に変更します。</span><span class="sxs-lookup"><span data-stu-id="bf469-121">Open the newly generated solution in the **UWP** folder, and then change the target platform to **x64**.</span></span>

![x64 ビルド プラットフォーム](images/x64-build-platform.png)

<span data-ttu-id="bf469-123">これで、ゲームの UWP Visual Studio ソリューションの準備ができました。[こちらの手順に従うことによって](getting-started.md)、ゲームを製品版の Xbox One に正常に展開できます。</span><span class="sxs-lookup"><span data-stu-id="bf469-123">Now that you have a UWP Visual Studio solution for your game, [following these steps](getting-started.md) will allow you to successfuly deploy your game onto your retail Xbox One!</span></span>

## <a name="step-3-modify-and-rebuild"></a><span data-ttu-id="bf469-124">手順 3:変更および再構築</span><span class="sxs-lookup"><span data-stu-id="bf469-124">Step 3: Modify and rebuild</span></span>

<span data-ttu-id="bf469-125">スクリプトではないものに変更を行った場合、これらの変更がゲームの UWP ビルドに表示されるようにするために、(__手順 1__ の説明に従って) エディター内からプロジェクトをリビルドする必要があります。</span><span class="sxs-lookup"><span data-stu-id="bf469-125">If changes are made to anything that isn't a script, for these changes to be shown in your game's UWP build, the project must be rebuilt from within the Editor (as described in __Step 1__).</span></span>

## <a name="versioning-your-uwp-project"></a><span data-ttu-id="bf469-126">UWP プロジェクトのバージョン管理</span><span class="sxs-lookup"><span data-stu-id="bf469-126">Versioning your UWP project</span></span>

<span data-ttu-id="bf469-127">この新しく生成された UWP ディレクトリの一部をバージョン管理に追加することが必要になる一般的な状況がいくつかあります。</span><span class="sxs-lookup"><span data-stu-id="bf469-127">There are a few common situations where adding parts of this newly generated UWP directory to version control becomes necessary.</span></span> <span data-ttu-id="bf469-128">たとえば、新しい依存関係を UWP プロジェクト (たとえば Xbox Live SDK など) に追加する場合です。</span><span class="sxs-lookup"><span data-stu-id="bf469-128">For example, if you're adding a new dependency to the UWP project (for example, the Xbox Live SDK).</span></span>  <span data-ttu-id="bf469-129">この例の詳細については、[UWP プロジェクトのバージョン管理](development-lanes-unity-versioning.md)で説明します。</span><span class="sxs-lookup"><span data-stu-id="bf469-129">We go over this example in detail at [Version control your UWP project](development-lanes-unity-versioning.md).</span></span>

## <a name="see-also"></a><span data-ttu-id="bf469-130">関連項目</span><span class="sxs-lookup"><span data-stu-id="bf469-130">See also</span></span>
- [<span data-ttu-id="bf469-131">既存のゲームの Xbox への移行</span><span class="sxs-lookup"><span data-stu-id="bf469-131">Bringing existing games to Xbox</span></span>](development-lanes-landing.md)
- [<span data-ttu-id="bf469-132">Xbox One の UWP</span><span class="sxs-lookup"><span data-stu-id="bf469-132">UWP on Xbox One</span></span>](index.md)
