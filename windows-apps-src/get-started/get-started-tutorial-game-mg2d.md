---
title: MonoGame 2D で UWP ゲームを作成する
description: C# と MonoGame で記述された Microsoft ストアのゲームのシンプルな UWP
author: muhsinking
ms.author: mukin
ms.date: 03/06/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.assetid: 5d5f7af2-41a9-4749-ad16-4503c64bb80c
ms.localizationpriority: medium
ms.openlocfilehash: d38465ce02e0aedf854094ede75fc33701b226a6
ms.sourcegitcommit: 933e71a31989f8063b020746fdd16e9da94a44c4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/11/2018
ms.locfileid: "4541284"
---
# <a name="create-a-uwp-game-in-monogame-2d"></a><span data-ttu-id="7163b-104">MonoGame 2D で UWP ゲームを作成する</span><span class="sxs-lookup"><span data-stu-id="7163b-104">Create a UWP game in MonoGame 2D</span></span>

## <a name="a-simple-2d-uwp-game-for-the-microsoft-store-written-in-c-and-monogame"></a><span data-ttu-id="7163b-105">C# と MonoGame で記述された Microsoft Store 向けのシンプルな 2D UWP ゲーム</span><span class="sxs-lookup"><span data-stu-id="7163b-105">A simple 2D UWP game for the Microsoft Store, written in C# and MonoGame</span></span>


![Walking Dino スプライト シート](images/JS2D_0.png)

## <a name="introduction"></a><span data-ttu-id="7163b-107">はじめに</span><span class="sxs-lookup"><span data-stu-id="7163b-107">Introduction</span></span>

<span data-ttu-id="7163b-108">MonoGame は、軽量のゲーム開発フレームワークです。</span><span class="sxs-lookup"><span data-stu-id="7163b-108">MonoGame is a lightweight game development framework.</span></span> <span data-ttu-id="7163b-109">このチュートリアルでは、コンテンツの読み込み、ストライプの描画、これらのアニメーション、ユーザー入力の処理など、MonoGame でのゲーム開発の基本事項について説明します。</span><span class="sxs-lookup"><span data-stu-id="7163b-109">This tutorial will teach you the basics of game development in MonoGame, including how to load content, draw sprites, animate them, and handle user input.</span></span> <span data-ttu-id="7163b-110">衝突の検出や高 DPI 画面用のスケールアップなど、いくつかの高度な概念についても説明します。</span><span class="sxs-lookup"><span data-stu-id="7163b-110">Some more advanced concepts like collision detection and scaling up for high-DPI screens are also discussed.</span></span> <span data-ttu-id="7163b-111">このチュートリアルの所要時間は 30 ～ 60 分です。</span><span class="sxs-lookup"><span data-stu-id="7163b-111">This tutorial takes 30-60 minutes.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="7163b-112">前提条件</span><span class="sxs-lookup"><span data-stu-id="7163b-112">Prerequisites</span></span>
+   <span data-ttu-id="7163b-113">Windows 10 と Microsoft Visual Studio 2017。</span><span class="sxs-lookup"><span data-stu-id="7163b-113">Windows 10 and Microsoft Visual Studio 2017.</span></span>  <span data-ttu-id="7163b-114">[Visual Studio を備えた環境をセットアップする方法については、ここをクリックしてください](https://docs.microsoft.com/en-us/windows/uwp/get-started/get-set-up)。</span><span class="sxs-lookup"><span data-stu-id="7163b-114">[Click here to learn how to get set up with Visual Studio](https://docs.microsoft.com/en-us/windows/uwp/get-started/get-set-up).</span></span>
+ <span data-ttu-id="7163b-115">.NET デスクトップ開発フレームワークです。</span><span class="sxs-lookup"><span data-stu-id="7163b-115">The .NET desktop development framework.</span></span> <span data-ttu-id="7163b-116">このインストールされていない場合は、Visual Studio インストーラーを再度実行し、Visual Studio 2017 のインストールを変更することによって取得できます。</span><span class="sxs-lookup"><span data-stu-id="7163b-116">If you don't already have this installed, you can get it by re-running the Visual Studio installer and modifying your installation of Visual Studio 2017.</span></span>
+   <span data-ttu-id="7163b-117">C# またはこれに類似するオブジェクト指向プログラミング言語に関する基本的な知識。</span><span class="sxs-lookup"><span data-stu-id="7163b-117">Basic knowledge of C# or a similar object-oriented programming language.</span></span> <span data-ttu-id="7163b-118">[C# によるチュートリアルについては、こちらをご覧ください](https://docs.microsoft.com/en-us/windows/uwp/get-started/create-a-hello-world-app-xaml-universal)。</span><span class="sxs-lookup"><span data-stu-id="7163b-118">[Click here to learn how to get started with C#](https://docs.microsoft.com/en-us/windows/uwp/get-started/create-a-hello-world-app-xaml-universal).</span></span>
+   <span data-ttu-id="7163b-119">オプションとして、クラス、メソッド、変数など、基本的なコンピューター サイエンスの概念に関する知識。</span><span class="sxs-lookup"><span data-stu-id="7163b-119">Familiarity with basic computer science concepts like classes, methods, and variables is a plus.</span></span>

## <a name="why-monogame"></a><span data-ttu-id="7163b-120">MonoGame を使用する理由</span><span class="sxs-lookup"><span data-stu-id="7163b-120">Why MonoGame?</span></span>
<span data-ttu-id="7163b-121">ゲームの開発環境には、今や十分すぎるほどの選択肢が存在します。</span><span class="sxs-lookup"><span data-stu-id="7163b-121">There’s no shortage of options when it comes to game development environments.</span></span> <span data-ttu-id="7163b-122">Unity などフル機能を備えたエンジンから DirectX など包括的で複雑なマルチメディア API まで、どこから始めるべきか迷います。</span><span class="sxs-lookup"><span data-stu-id="7163b-122">From full-featured engines like Unity to comprehensive and complex multimedia APIs like DirectX, it can be hard to know where to start.</span></span> <span data-ttu-id="7163b-123">MonoGame は、複雑さのレベルがゲーム エンジンと DirectX などの基本 API の中間に分類されるツールのセットです。</span><span class="sxs-lookup"><span data-stu-id="7163b-123">MonoGame is a set of tools, with a level of complexity falling somewhere between a game engine and a grittier API like DirectX.</span></span> <span data-ttu-id="7163b-124">MonoGame では、使いやすいコンテンツ パイプラインと、多様なプラットフォームで動作する軽量のゲームを作成するために必要なすべての機能が提供されています。</span><span class="sxs-lookup"><span data-stu-id="7163b-124">It provides an easy-to-use content pipeline, and all the functionality required to create lightweight games that run on a wide variety of platforms.</span></span> <span data-ttu-id="7163b-125">MonoGame のアプリは純粋な c# で記述してに配布できる迅速に、Microsoft Store やその他のような配布プラットフォームを通じて、すべての最適なします。</span><span class="sxs-lookup"><span data-stu-id="7163b-125">Best of all, MonoGame apps are written in pure C#, and you can distribute them quickly via the Microsoft Store or other similar distribution platforms.</span></span>

## <a name="get-the-code"></a><span data-ttu-id="7163b-126">コードを入手する</span><span class="sxs-lookup"><span data-stu-id="7163b-126">Get the code</span></span>
<span data-ttu-id="7163b-127">段階を追ってチュートリアルを進めるのではなく、MonoGame の動作を確認するには、[こちらをクリックして完成したアプリを入手してください](https://github.com/Microsoft/Windows-appsample-get-started-mg2d)。</span><span class="sxs-lookup"><span data-stu-id="7163b-127">If you don’t feel like working through the tutorial step-by-step and just want to see MonoGame in action, [click here to get the finished app](https://github.com/Microsoft/Windows-appsample-get-started-mg2d).</span></span>

<span data-ttu-id="7163b-128">Visual Studio 2017 でプロジェクトを開き、サンプルを実行する、 **F5**キーを押します。</span><span class="sxs-lookup"><span data-stu-id="7163b-128">Open the project in Visual Studio 2017, and press **F5** to run the sample.</span></span> <span data-ttu-id="7163b-129">初めての実行時には、インストールに含まれていない NuGet パッケージを Visual Studio が取得する必要があるため、少し時間がかかることがあります。</span><span class="sxs-lookup"><span data-stu-id="7163b-129">The first time you do this may take a while, as Visual Studio needs to fetch any NuGet packages that are missing from your installation.</span></span>

<span data-ttu-id="7163b-130">これを行った場合は、MonoGame のセットアップに関する次のセクションをスキップして、順を追ったコードのウォークスルーに進むことができます。</span><span class="sxs-lookup"><span data-stu-id="7163b-130">If you’ve done this, skip the next section about setting up MonoGame to see a step-by-step walkthrough of the code.</span></span>

<span data-ttu-id="7163b-131">**注:** このサンプルで作成するゲームは、完全なゲームではなく、おもしろい内容でもありません。</span><span class="sxs-lookup"><span data-stu-id="7163b-131">**Note:** The game created in this sample is not meant to be complete (or any fun at all).</span></span> <span data-ttu-id="7163b-132">その唯一の目的では、MonoGame での 2D 開発のすべての主要な概念を示すです。</span><span class="sxs-lookup"><span data-stu-id="7163b-132">Its only purpose is to demonstrate all the core concepts of 2D development in MonoGame.</span></span> <span data-ttu-id="7163b-133">このコードを基にして、より優れたゲームを作成することも、基礎を習得して 1 から始めることもできます。</span><span class="sxs-lookup"><span data-stu-id="7163b-133">Feel free to use this code and make something much better—or just start from scratch after you’ve mastered the basics!</span></span>

## <a name="set-up-monogame-project"></a><span data-ttu-id="7163b-134">MonoGame プロジェクトのセットアップ</span><span class="sxs-lookup"><span data-stu-id="7163b-134">Set up MonoGame project</span></span>
1. <span data-ttu-id="7163b-135">[MonoGame.net](http://www.monogame.net/) から、**MonoGame 3.6** for Visual Studio をインストールします。</span><span class="sxs-lookup"><span data-stu-id="7163b-135">Install **MonoGame 3.6** for Visual Studio from [MonoGame.net](http://www.monogame.net/)</span></span>

2. <span data-ttu-id="7163b-136">Visual Studio 2017 を起動します。</span><span class="sxs-lookup"><span data-stu-id="7163b-136">Start Visual Studio 2017.</span></span>

3. <span data-ttu-id="7163b-137">**[ファイル] -> [新規] -> [プロジェクト]** を開きます。</span><span class="sxs-lookup"><span data-stu-id="7163b-137">Go to **File -> New -> Project**</span></span>

4. <span data-ttu-id="7163b-138">Visual C# プロジェクト テンプレートで、**[MonoGame]** と **[MonoGame Windows 10 Universal Project]** (MonoGame Windows 10 ユニバーサル プロジェクト) を選択します。</span><span class="sxs-lookup"><span data-stu-id="7163b-138">Under the Visual C# project templates, select **MonoGame** and **MonoGame Windows 10 Universal Project**</span></span>

5. <span data-ttu-id="7163b-139">プロジェクトに「MonoGame2D」という名前を指定し、[OK] を選択します。</span><span class="sxs-lookup"><span data-stu-id="7163b-139">Name your project “MonoGame2D" and select OK.</span></span> <span data-ttu-id="7163b-140">プロジェクトの作成時には多数のエラーがあるように見えますが、初めてプロジェクトを実行すると、不足していた NuGet パッケージがすべてインストールされ、エラーがなくなります。</span><span class="sxs-lookup"><span data-stu-id="7163b-140">With the project created, it will probably look like it is full of errors—these should go away after you run the project for the first time, and any missing NuGet packages are installed.</span></span>

6. <span data-ttu-id="7163b-141">ターゲット プラットフォームとして **[x86]** および **[ローカル コンピューター ]** を設定し、**F5** を押して、空のプロジェクトをビルド/実行します。</span><span class="sxs-lookup"><span data-stu-id="7163b-141">Make sure **x86** and **Local Machine** are set as the target platform, and press **F5** to build and run the empty project.</span></span> <span data-ttu-id="7163b-142">上の手順を実行した場合は、プロジェクトのビルドが終了した後、空の青いウィンドウが表示されます。</span><span class="sxs-lookup"><span data-stu-id="7163b-142">If you followed the steps above, you should see an empty blue window after the project finishes building.</span></span>

## <a name="method-overview"></a><span data-ttu-id="7163b-143">メソッドの概要</span><span class="sxs-lookup"><span data-stu-id="7163b-143">Method overview</span></span>
<span data-ttu-id="7163b-144">プロジェクトを作成したので、**ソリューション エクスプローラー**から **Game1.cs** ファイルを開きます。</span><span class="sxs-lookup"><span data-stu-id="7163b-144">Now you’ve created the project, open the **Game1.cs** file from the **Solution Explorer**.</span></span> <span data-ttu-id="7163b-145">ゲーム ロジックの大部分は、ここに記述します。</span><span class="sxs-lookup"><span data-stu-id="7163b-145">This is where the bulk of the game logic is going to go.</span></span> <span data-ttu-id="7163b-146">新しい MonoGame プロジェクトを作成すると、多数の重要なメソッドがここに自動的に生成されます。</span><span class="sxs-lookup"><span data-stu-id="7163b-146">Many crucial methods are automatically generated here when you create a new MonoGame project.</span></span> <span data-ttu-id="7163b-147">その内容を簡単に確認してみましょう。</span><span class="sxs-lookup"><span data-stu-id="7163b-147">Let’s quickly review them:</span></span>

<span data-ttu-id="7163b-148">**public Game1()** コンストラクター。</span><span class="sxs-lookup"><span data-stu-id="7163b-148">**public Game1()** The constructor.</span></span> <span data-ttu-id="7163b-149">このチュートリアルでは、このメソッドをそのまま使用します。</span><span class="sxs-lookup"><span data-stu-id="7163b-149">We aren’t going to change this method at all for this tutorial.</span></span>

<span data-ttu-id="7163b-150">**protected override void Initialize()** 使用するクラス変数は、ここですべて初期化します。</span><span class="sxs-lookup"><span data-stu-id="7163b-150">**protected override void Initialize()** Here we initialize any class variables that are used.</span></span> <span data-ttu-id="7163b-151">このメソッドは、ゲームの開始時に 1 回だけ呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="7163b-151">This method is called once at the start of the game.</span></span>

<span data-ttu-id="7163b-152">**protected override void LoadContent()** このメソッドでは、ゲームの開始前にコンテンツ (</span><span class="sxs-lookup"><span data-stu-id="7163b-152">**protected override void LoadContent()** This method loads content (eg.</span></span> <span data-ttu-id="7163b-153">テクスチャ、オーディオ、フォントなど) をメモリに読み込みます。</span><span class="sxs-lookup"><span data-stu-id="7163b-153">textures, audio, fonts) into memory before the game starts.</span></span> <span data-ttu-id="7163b-154">Initialize と同様、アプリの起動時に 1 回だけ呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="7163b-154">Like Initialize, it’s called once when the app starts.</span></span>

<span data-ttu-id="7163b-155">**protected override void UnloadContent()** このメソッドは、非コンテンツ マネージャーのコンテンツをアンロードするために使用されます。</span><span class="sxs-lookup"><span data-stu-id="7163b-155">**protected override void UnloadContent()** This method is used to unload non content-manager content.</span></span> <span data-ttu-id="7163b-156">ここでは使用しません。</span><span class="sxs-lookup"><span data-stu-id="7163b-156">We don’t use this one at all.</span></span>

<span data-ttu-id="7163b-157">**protected override void Update(GameTime gameTIme)** このメソッドは、ゲーム ループのすべてのサイクルで 1 回呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="7163b-157">**protected override void Update(GameTime gameTIme)** This method is called once for every cycle of the game loop.</span></span> <span data-ttu-id="7163b-158">ここでは、ゲームで使用するあらゆるオブジェクトや変数の状態を更新します。</span><span class="sxs-lookup"><span data-stu-id="7163b-158">Here we update the states of any object or variable used in the game.</span></span> <span data-ttu-id="7163b-159">これには、オブジェクトの位置、速度、色などが含まれます。</span><span class="sxs-lookup"><span data-stu-id="7163b-159">This includes things like an object’s position, speed, or color.</span></span> <span data-ttu-id="7163b-160">ユーザー入力が処理される場所でもあります。</span><span class="sxs-lookup"><span data-stu-id="7163b-160">This is also where use input is handled.</span></span> <span data-ttu-id="7163b-161">つまりこのメソッドでは、画面へのオブジェクトの描画を除いて、ゲーム ロジックのすべての部分が処理されます。</span><span class="sxs-lookup"><span data-stu-id="7163b-161">In short, this method handles every part of the game logic except drawing objects on screen.</span></span>
<span data-ttu-id="7163b-162">**protected override void Draw(GameTime gameTime)** ここでは、Update メソッドで指定された位置を使用して、オブジェクトが画面に描画されます。</span><span class="sxs-lookup"><span data-stu-id="7163b-162">**protected override void Draw(GameTime gameTime)** This is where objects are drawn on the screen, using the positions given by the Update method.</span></span>

## <a name="draw-a-sprite"></a><span data-ttu-id="7163b-163">スプライトの描画</span><span class="sxs-lookup"><span data-stu-id="7163b-163">Draw a sprite</span></span>
<span data-ttu-id="7163b-164">作成したばかりの MonoGame プロジェクトを実行し、美しい青空を確認しました。次は、地面を追加しましょう。</span><span class="sxs-lookup"><span data-stu-id="7163b-164">So you’ve run your fresh MonoGame project and found a nice blue sky—let’s add some ground.</span></span>
<span data-ttu-id="7163b-165">MonoGame では、2D アートが "スプライト" という形でアプリに追加されます。</span><span class="sxs-lookup"><span data-stu-id="7163b-165">In MonoGame, 2D art is added to the app in the form of “sprites.”</span></span> <span data-ttu-id="7163b-166">スプライトは、単一のエンティティとして処理されるコンピューター グラフィックです。</span><span class="sxs-lookup"><span data-stu-id="7163b-166">A sprite is just a computer graphic that is manipulated as a single entity.</span></span> <span data-ttu-id="7163b-167">スプライトの移動、拡大縮小、成形、アニメーション化、組み合わせなどを行うことで、思い描いたものを 2D 空間に作成することができます。</span><span class="sxs-lookup"><span data-stu-id="7163b-167">Sprites can be moved, scaled, shaped, animated, and combined to create anything you can imagine in the 2D space.</span></span>

### <a name="1-download-a-texture"></a><span data-ttu-id="7163b-168">1. テクスチャをダウンロードする</span><span class="sxs-lookup"><span data-stu-id="7163b-168">1. Download a texture</span></span>
<span data-ttu-id="7163b-169">説明目的ですので、最初のスプライトは非常につまらないものです。</span><span class="sxs-lookup"><span data-stu-id="7163b-169">For our purposes, this first sprite is going to be extremely boring.</span></span> <span data-ttu-id="7163b-170">[こちらをクリックして、特徴のない緑色の四角形をダウンロードしてください](https://github.com/Microsoft/Windows-appsample-get-started-mg2d/blob/master/MonoGame2D/Content/grass.png)。</span><span class="sxs-lookup"><span data-stu-id="7163b-170">[Click here to download this featureless green rectangle](https://github.com/Microsoft/Windows-appsample-get-started-mg2d/blob/master/MonoGame2D/Content/grass.png).</span></span>

### <a name="2-add-the-texture-to-the-content-folder"></a><span data-ttu-id="7163b-171">2. コンテンツ フォルダーにテクスチャを追加する</span><span class="sxs-lookup"><span data-stu-id="7163b-171">2. Add the texture to the Content folder</span></span>
- <span data-ttu-id="7163b-172">**ソリューション エクスプローラー**を開きます。</span><span class="sxs-lookup"><span data-stu-id="7163b-172">Open the **Solution Explorer**</span></span>
- <span data-ttu-id="7163b-173">**[コンテンツ]** フォルダー内の **Content.mgcb** を右クリックし、**[プログラムから開く]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="7163b-173">Right click **Content.mgcb** in the **Content** folder and select **Open With**.</span></span> <span data-ttu-id="7163b-174">ポップアップ メニューから **[Monogame Pipeline]** (MonoGame パイプライン) を選択し、**[OK]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="7163b-174">From the popup menu select **Monogame Pipeline**, and select **OK**.</span></span>
- <span data-ttu-id="7163b-175">新しいウィンドウで **[コンテンツ]** 項目を右クリックし、**[追加] -> [既存の項目]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="7163b-175">In the new window, Right-Click the **Content** item and select **Add -> Existing Item**.</span></span>
- <span data-ttu-id="7163b-176">ファイル ブラウザーで、緑色の四角形を見つけて選択します。</span><span class="sxs-lookup"><span data-stu-id="7163b-176">Locate and select the green rectangle in the file browser</span></span>
- <span data-ttu-id="7163b-177">項目に「grass.png」という名前を指定し、**[追加]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="7163b-177">Name the item “grass.png” and select **Add**.</span></span>

### <a name="3-add-class-variables"></a><span data-ttu-id="7163b-178">3. クラス変数を追加する</span><span class="sxs-lookup"><span data-stu-id="7163b-178">3. Add class variables</span></span>
<span data-ttu-id="7163b-179">この画像をスプライトのテクスチャとして読み込むには、**Game1.cs** を開き、以下のクラス変数を追加します。</span><span class="sxs-lookup"><span data-stu-id="7163b-179">To load this image as a sprite texture, open **Game1.cs** and add the following class variables.</span></span>

```CSharp
const float SKYRATIO = 2f/3f;
float screenWidth;
float screenHeight;
Texture2D grass;
```

<span data-ttu-id="7163b-180">SKYRATIO 変数は、シーン内の草地に対する空の割合 (この場合は 3 分の 2) を示します。</span><span class="sxs-lookup"><span data-stu-id="7163b-180">The SKYRATIO variable tells us how much of the scene we want to be sky versus grass—in this case, two-thirds.</span></span> <span data-ttu-id="7163b-181">**screenWidth** と **screenHeight** では、アプリ ウィンドウのサイズを追跡し、**grass** には、緑色の四角形を格納します。</span><span class="sxs-lookup"><span data-stu-id="7163b-181">**screenWidth** and **screenHeight** will keep track of the app window size, while **grass** is where we’ll store our green rectangle.</span></span>

### <a name="4-initialize-class-variables-and-set-window-size"></a><span data-ttu-id="7163b-182">4. クラス変数を初期化してウィンドウ サイズを設定する</span><span class="sxs-lookup"><span data-stu-id="7163b-182">4. Initialize class variables and set window size</span></span>
<span data-ttu-id="7163b-183">**screenWidth** 変数と **screenHeight** 変数は初期化する必要があるため、このコードを **Initialize** メソッドに追加します。</span><span class="sxs-lookup"><span data-stu-id="7163b-183">The **screenWidth** and **screenHeight** variables still need to be initialized, so add this code to the **Initialize** method:</span></span>

```CSharp
ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.FullScreen;

screenHeight = (float)ApplicationView.GetForCurrentView().VisibleBounds.Height;
screenWidth = (float)ApplicationView.GetForCurrentView().VisibleBounds.Width;

this.IsMouseVisible = false;
```

<span data-ttu-id="7163b-184">画面の高さと幅を取得するほか、アプリのウィンドウ表示モードを **Fullscreen** に設定し、マウスを非表示にします。</span><span class="sxs-lookup"><span data-stu-id="7163b-184">Along with getting the screen’s height and width, we also set the app’s windowing mode to **Fullscreen**, and make the mouse invisible.</span></span>

### <a name="5-load-the-texture"></a><span data-ttu-id="7163b-185">5. テクスチャを読み込む</span><span class="sxs-lookup"><span data-stu-id="7163b-185">5. Load the texture</span></span>
<span data-ttu-id="7163b-186">テクスチャを grass 変数に読み込むには、以下を **LoadContent** メソッドに追加します。</span><span class="sxs-lookup"><span data-stu-id="7163b-186">To load the texture into the grass variable, add the following to the **LoadContent** method:</span></span>

```CSharp
grass = Content.Load<Texture2D>("grass");
```

### <a name="6-draw-the-sprite"></a><span data-ttu-id="7163b-187">6. スプライトを描画する</span><span class="sxs-lookup"><span data-stu-id="7163b-187">6. Draw the sprite</span></span>
<span data-ttu-id="7163b-188">四角形を描画するには、以下の行を追加、**Draw** メソッドに追加します。</span><span class="sxs-lookup"><span data-stu-id="7163b-188">To draw the rectangle, add the following lines to the **Draw** method:</span></span>

```CSharp
GraphicsDevice.Clear(Color.CornflowerBlue);
spriteBatch.Begin();
spriteBatch.Draw(grass, new Rectangle(0, (int)(screenHeight * SKYRATIO),
  (int)screenWidth, (int)screenHeight), Color.White);
spriteBatch.End();
```

<span data-ttu-id="7163b-189">ここでは、**spriteBatch.Draw** メソッドを使用して、指定されたテクスチャを Rectangle オブジェクトの境界内に配置します。</span><span class="sxs-lookup"><span data-stu-id="7163b-189">Here we use the **spriteBatch.Draw** method to place the given texture within the borders of a Rectangle object.</span></span> <span data-ttu-id="7163b-190">**Rectangle** は、左上角および右下角の x 座標と y 座標で定義されます。</span><span class="sxs-lookup"><span data-stu-id="7163b-190">A **Rectangle** is defined by the x and y coordinates of its top left and bottom right corner.</span></span> <span data-ttu-id="7163b-191">先ほど定義した変数 **screenWidth**、**screenHeight**、**SKYRATIO** を使用して、画面の下から 3 分の 1 まで緑色の四角形のテクスチャを描画します。</span><span class="sxs-lookup"><span data-stu-id="7163b-191">Using the **screenWidth**, **screenHeight**, and **SKYRATIO** variables we defined earlier, we draw the green rectangle texture across the bottom one-third of the screen.</span></span> <span data-ttu-id="7163b-192">この時点でプログラムを実行すると、これまでの青い背景が、部分的に緑色の四角形で覆われます。</span><span class="sxs-lookup"><span data-stu-id="7163b-192">If you run the program now you should see the blue background from before, partially covered by the green rectangle.</span></span>

![緑色の四角形](images/monogame-tutorial-1.png)

## <a name="scale-to-high-dpi-screens"></a><span data-ttu-id="7163b-194">高 DPI 画面へのスケーリング</span><span class="sxs-lookup"><span data-stu-id="7163b-194">Scale to high DPI screens</span></span>
<span data-ttu-id="7163b-195">Surface Pro や Surface Studio などで見られる高ピクセル密度モニターで Visual Studioを実行している場合、先ほどの緑色の四角形で、画面の下から 3 分の 1 までがきちんと覆われていないことがあります。</span><span class="sxs-lookup"><span data-stu-id="7163b-195">If you’re running Visual Studio on a high pixel-density monitor, like those found on a Surface Pro or Surface Studio, you may find that the green rectangle from the steps above doesn’t quite cover the bottom third of the screen.</span></span> <span data-ttu-id="7163b-196">その場合は、画面の左下角が隠れない状態になります。</span><span class="sxs-lookup"><span data-stu-id="7163b-196">It’s probably floating above the bottom-left corner of the screen.</span></span> <span data-ttu-id="7163b-197">この問題を解決し、すべてのデバイスでゲームのエクスペリエンスを統一するには、画面のピクセル密度を基準として特定の値をスケーリングするメソッドを作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="7163b-197">To fix this and unify the experience of our game across all devices, we will need to create a method that scales certain values relative to the screen’s pixel density:</span></span>

```CSharp
public float ScaleToHighDPI(float f)
{
  DisplayInformation d = DisplayInformation.GetForCurrentView();
  f *= (float)d.RawPixelsPerViewPixel;
  return f;
}
```

<span data-ttu-id="7163b-198">次に、**Initialize** メソッド内の **screenHeight** および **screenWidth** の初期化を以下のコードに置き換えます。</span><span class="sxs-lookup"><span data-stu-id="7163b-198">Next replace the initializations of **screenHeight** and **screenWidth** in the **Initialize** method with this:</span></span>

```CSharp
screenHeight = ScaleToHighDPI((float)ApplicationView.GetForCurrentView().VisibleBounds.Height);
screenWidth = ScaleToHighDPI((float)ApplicationView.GetForCurrentView().VisibleBounds.Width);
```

<span data-ttu-id="7163b-199">この時点で、高 DPI 画面でアプリを実行すると、意図したとおりに画面の下から 3 分の 1 までが緑色の四角形で覆われます。</span><span class="sxs-lookup"><span data-stu-id="7163b-199">If you’re using a high DPI screen and try to run the app now, you should see the green rectangle covering the bottom third of the screen as intended.</span></span>

## <a name="build-the-spriteclass"></a><span data-ttu-id="7163b-200">SpriteClass のビルド</span><span class="sxs-lookup"><span data-stu-id="7163b-200">Build the SpriteClass</span></span>
<span data-ttu-id="7163b-201">スプライトのアニメーションを開始する前に、SpriteClass という新しいクラスを作成しましょう。このクラスを使用すると、スプライト処理に関する表面上の複雑さを軽減できます。</span><span class="sxs-lookup"><span data-stu-id="7163b-201">Before we start animating sprites, we’re going to make a new class called “SpriteClass,” which will let us reduce the surface-level complexity of sprite manipulation.</span></span>

### <a name="1-create-a-new-class"></a><span data-ttu-id="7163b-202">1. 新しいクラスを作成する</span><span class="sxs-lookup"><span data-stu-id="7163b-202">1. Create a new class</span></span>
<span data-ttu-id="7163b-203">**ソリューション エクスプローラー**で、**[MonoGame2D (Universal Windows)]** (MonoGame2D (ユニバーサル Windows)) を右クリックし、**[追加] -> [クラス]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="7163b-203">In the **Solution Explorer**, right-click **MonoGame2D (Universal Windows)** and select **Add -> Class**.</span></span> <span data-ttu-id="7163b-204">クラスに「SpriteClass.cs」という名前を指定し、**[追加]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="7163b-204">Name the class “SpriteClass.cs” then select **Add**.</span></span>

### <a name="2-add-class-variables"></a><span data-ttu-id="7163b-205">2. クラス変数を追加する</span><span class="sxs-lookup"><span data-stu-id="7163b-205">2. Add class variables</span></span>
<span data-ttu-id="7163b-206">今作成したクラスに、以下のコードを追加します。</span><span class="sxs-lookup"><span data-stu-id="7163b-206">Add this code to the class you just created:</span></span>

```CSharp
public Texture2D texture
{
  get;
}

public float x
{
  get;
  set;
}

public float y
{
  get;
  set;
}

public float angle
{
  get;
  set;
}

public float dX
{
  get;
  set;
}

public float dY
{
  get;
  set;
}

public float dA
{
  get;
  set;
}

public float scale
{
  get;
  set;
}
```

<span data-ttu-id="7163b-207">ここでは、スプライトの描画とアニメーション化に必要なクラス変数をセットアップします。</span><span class="sxs-lookup"><span data-stu-id="7163b-207">Here we set up the class variables we need to draw and animate a sprite.</span></span> <span data-ttu-id="7163b-208">**x** 変数と **y** 変数は、平面上のスプライトの現在の位置を表し、**angle** 変数は、スプライトの現在の角度を度単位で表します (0 の場合は直立、90 の場合は時計回りに 90 度傾斜)。</span><span class="sxs-lookup"><span data-stu-id="7163b-208">The **x** and **y** variables represent the sprite’s current position on the plane, while the **angle** variable is the sprite’s current angle in degrees (0 being upright, 90 being tilted 90 degrees clockwise).</span></span> <span data-ttu-id="7163b-209">このクラスでは **x** と **y** がスプライトの**中央**の座標を表している点に注意します (既定の起点は左上角)。</span><span class="sxs-lookup"><span data-stu-id="7163b-209">It’s important to note that, for this class, **x** and **y** represent the coordinates of the **center** of the sprite, (the default origin is the top-left corner).</span></span> <span data-ttu-id="7163b-210">これにより、指定された起点を中心としてスプライトが回転するため、スプライトの回転が容易になり、回転モーションを統一できます。</span><span class="sxs-lookup"><span data-stu-id="7163b-210">This is makes rotating sprites easier, as they will rotate around whatever origin they are given, and rotating around the center gives us a uniform spinning motion.</span></span>

<span data-ttu-id="7163b-211">その後に、**dX**、**dY**、**dA** があります。これらはそれぞれ、変数 **x**、**y**、**angle** の 1 秒あたりの変化レートです。</span><span class="sxs-lookup"><span data-stu-id="7163b-211">After this, we have **dX**, **dY**, and **dA**, which are the per-second rates of change for the **x**, **y**, and **angle** variables respectively.</span></span>

### <a name="3-create-a-constructor"></a><span data-ttu-id="7163b-212">3. コンストラクターを作成する</span><span class="sxs-lookup"><span data-stu-id="7163b-212">3. Create a constructor</span></span>
<span data-ttu-id="7163b-213">**SpriteClass** のインスタンスを作成する場合は、**Game1.cs** からのグラフィックス デバイス、プロジェクト フォルダーを基準としたテクスチャのパス、元のサイズを基準としたテクスチャの倍率をコンストラクターに渡します。</span><span class="sxs-lookup"><span data-stu-id="7163b-213">When creating an instance of **SpriteClass**, we provide the constructor with the graphics device from **Game1.cs**, the path to the texture relative to the project folder, and the desired scale of the texture relative to its original size.</span></span> <span data-ttu-id="7163b-214">残りのクラス変数は、ゲームを開始した後、Update メソッドで設定します。</span><span class="sxs-lookup"><span data-stu-id="7163b-214">We’ll set the rest of the class variables after we start the game, in the update method.</span></span>

```CSharp
public SpriteClass (GraphicsDevice graphicsDevice, string textureName, float scale)
{
  this.scale = scale;
  if (texture == null)
  {
    using (var stream = TitleContainer.OpenStream(textureName))
    {
      texture = Texture2D.FromStream(graphicsDevice, stream);
    }
  }
}
```

### <a name="4-update-and-draw"></a><span data-ttu-id="7163b-215">4. 更新と描画</span><span class="sxs-lookup"><span data-stu-id="7163b-215">4. Update and Draw</span></span>
<span data-ttu-id="7163b-216">SpriteClass 宣言に追加する必要のあるメソッドが、あと 2 つあります。</span><span class="sxs-lookup"><span data-stu-id="7163b-216">There are still a couple of methods we need to add to the SpriteClass declaration:</span></span>

```CSharp
public void Update (float elapsedTime)
{
  this.x += this.dX * elapsedTime;
  this.y += this.dY * elapsedTime;
  this.angle += this.dA * elapsedTime;
}

public void Draw (SpriteBatch spriteBatch)
{
  Vector2 spritePosition = new Vector2(this.x, this.y);
  spriteBatch.Draw(texture, spritePosition, null, Color.White, this.angle, new Vector2(texture.Width/2, texture.Height/2), new Vector2(scale, scale), SpriteEffects.None, 0f);
}
```

<span data-ttu-id="7163b-217">SpriteClass の **Update** メソッドは、Game1.cs の **Update** メソッドで呼び出され、スプライトの **x**、**y**、および **angle** の値をそれぞれの変化レートに基づいて更新するために使用されます。</span><span class="sxs-lookup"><span data-stu-id="7163b-217">The **Update** SpriteClass method is called in the **Update** method of Game1.cs, and is used to update the sprites **x**, **y**, and **angle** values based on their respective rates of change.</span></span>

<span data-ttu-id="7163b-218">**Draw** メソッドは、Game1.cs の **Draw** メソッドで呼び出され、ゲーム ウィンドウにスプライトを描画するために使用されます。</span><span class="sxs-lookup"><span data-stu-id="7163b-218">The **Draw** method is called in the **Draw** method of Game1.cs, and is used to draw the sprite in the game window.</span></span>

## <a name="user-input-and-animation"></a><span data-ttu-id="7163b-219">ユーザー入力とアニメーション</span><span class="sxs-lookup"><span data-stu-id="7163b-219">User input and animation</span></span>
<span data-ttu-id="7163b-220">これで SpriteClass を構築できたため、これを使用して 2 つの新しいゲーム オブジェクトを作成します。1 つ目は、プレイヤーが方向キーと Space キーで制御できるアバターです。</span><span class="sxs-lookup"><span data-stu-id="7163b-220">Now we have the SpriteClass built, we’ll use it to create two new game objects, The first is an avatar that the player can control with the arrow keys and the space bar.</span></span> <span data-ttu-id="7163b-221">2 つ目は、プレイヤーが回避する必要があるオブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="7163b-221">The second is an object that the player must avoid</span></span>

### <a name="1-get-the-textures"></a><span data-ttu-id="7163b-222">1. テクスチャを入手する</span><span class="sxs-lookup"><span data-stu-id="7163b-222">1. Get the textures</span></span>
<span data-ttu-id="7163b-223">プレイヤーのアバターには、Microsoft 独自のニンジャ キャットを使用します。ニンジャ キャットは、信頼できるティラノサウルスに乗っています。</span><span class="sxs-lookup"><span data-stu-id="7163b-223">For the player’s avatar we’re going to use Microsoft’s very own ninja cat, riding on his trusty t-rex.</span></span> <span data-ttu-id="7163b-224">[画像をダウンロードするには、こちらをクリックしてください](https://github.com/Microsoft/Windows-appsample-get-started-mg2d/blob/master/MonoGame2D/Content/ninja-cat-dino.png)。</span><span class="sxs-lookup"><span data-stu-id="7163b-224">[Click here to download the image](https://github.com/Microsoft/Windows-appsample-get-started-mg2d/blob/master/MonoGame2D/Content/ninja-cat-dino.png).</span></span>

<span data-ttu-id="7163b-225">次は、プレイヤーが避ける必要がある障害物を設定します。</span><span class="sxs-lookup"><span data-stu-id="7163b-225">Now for the obstacle that the player needs to avoid.</span></span> <span data-ttu-id="7163b-226">ニンジャ キャットとティラノサウルスの両方が何より嫌うものは、</span><span class="sxs-lookup"><span data-stu-id="7163b-226">What do ninja-cats and carnivorous dinosaurs both hate more than anything?</span></span> <span data-ttu-id="7163b-227">野菜を食べることです。</span><span class="sxs-lookup"><span data-stu-id="7163b-227">Eating their veggies!</span></span> <span data-ttu-id="7163b-228">[画像をダウンロードするには、こちらをクリックしてください](https://github.com/Microsoft/Windows-appsample-get-started-mg2d/blob/master/MonoGame2D/Content/broccoli.png)。</span><span class="sxs-lookup"><span data-stu-id="7163b-228">[Click here to download the image](https://github.com/Microsoft/Windows-appsample-get-started-mg2d/blob/master/MonoGame2D/Content/broccoli.png).</span></span>

<span data-ttu-id="7163b-229">緑色の四角形のときと同じように、これらの画像を **[MonoGame Pipeline]** (MonoGame パイプライン) 経由で **Content.mgcb** に追加し、それぞれ「ninja-cat-dino.png」および「broccoli.png」という名前を指定します。</span><span class="sxs-lookup"><span data-stu-id="7163b-229">Just as before with the green rectangle, add these images to **Content.mgcb** via the **MonoGame Pipeline**, naming them “ninja-cat-dino.png” and “broccoli.png” respectively.</span></span>

### <a name="2-add-class-variables"></a><span data-ttu-id="7163b-230">2. クラス変数を追加する</span><span class="sxs-lookup"><span data-stu-id="7163b-230">2. Add class variables</span></span>
<span data-ttu-id="7163b-231">**Game1.cs** の一連のクラス変数に、以下のコードを追加します。</span><span class="sxs-lookup"><span data-stu-id="7163b-231">Add the following code to the list of class variables in **Game1.cs**:</span></span>

```CSharp
SpriteClass dino;
SpriteClass broccoli;

bool spaceDown;
bool gameStarted;

float broccoliSpeedMultiplier;
float gravitySpeed;
float dinoSpeedX;
float dinoJumpY;
float score;

Random random;
```

<span data-ttu-id="7163b-232">**dino** と **broccoli** は、SpriteClass 変数です。</span><span class="sxs-lookup"><span data-stu-id="7163b-232">**dino** and **broccoli** are our SpriteClass variables.</span></span> <span data-ttu-id="7163b-233">**dino** はプレイヤーのアバターを保持し、**broccoli** はブロッコリの障害物を保持します。</span><span class="sxs-lookup"><span data-stu-id="7163b-233">**dino** will hold the player avatar, while **broccoli** holds the broccoli obstacle.</span></span>

<span data-ttu-id="7163b-234">**spaceDown** は、Space キーが押したまま (押してすぐ離していない) になっているかどうかを追跡します。</span><span class="sxs-lookup"><span data-stu-id="7163b-234">**spaceDown** keeps track of whether the spacebar is being held down as opposed to pressed and released.</span></span>

<span data-ttu-id="7163b-235">**gameStarted** は、ユーザーがゲームを開始したのが初めてかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="7163b-235">**gameStarted** tells us whether the user has started the game for the first time.</span></span>

<span data-ttu-id="7163b-236">**broccoliSpeedMultiplier** は、障害物であるブロッコリが画面上を移動する速度を示します。</span><span class="sxs-lookup"><span data-stu-id="7163b-236">**broccoliSpeedMultiplier** determines how fast the broccoli obstacle moves across the screen.</span></span>

<span data-ttu-id="7163b-237">**gravitySpeed** は、プレイヤーのアバターがジャンプの後に下向きにどの程度加速するかを示します。</span><span class="sxs-lookup"><span data-stu-id="7163b-237">**gravitySpeed** determines how fast the player avatar accelerates downward after a jump.</span></span>

<span data-ttu-id="7163b-238">**dinoSpeedX** と **dinoJumpY** は、プレイヤーのアバターが移動およびジャンプする速度を示します。</span><span class="sxs-lookup"><span data-stu-id="7163b-238">**dinoSpeedX** and **dinoJumpY** determine how fast the player avatar moves and jumps.</span></span>
<span data-ttu-id="7163b-239">score は、プレイヤーがかわした障害物の数を追跡します。</span><span class="sxs-lookup"><span data-stu-id="7163b-239">score tracks how many obstacles the player has successfully dodged.</span></span>

<span data-ttu-id="7163b-240">最後に、**random** は、障害物であるブロッコリの動作にランダム性を加えるために使用します。</span><span class="sxs-lookup"><span data-stu-id="7163b-240">Finally, **random** will be used to add some randomness to the behavior of the broccoli obstacle.</span></span>

### <a name="3-initialize-variables"></a><span data-ttu-id="7163b-241">3. 変数を初期化する</span><span class="sxs-lookup"><span data-stu-id="7163b-241">3. Initialize variables</span></span>
<span data-ttu-id="7163b-242">次に、これらの変数を初期化する必要があります。</span><span class="sxs-lookup"><span data-stu-id="7163b-242">Next we need to initialize these variables.</span></span> <span data-ttu-id="7163b-243">以下のコードを Initialize メソッドに追加します。</span><span class="sxs-lookup"><span data-stu-id="7163b-243">Add the following code to the Initialize method:</span></span>

```CSharp
broccoliSpeedMultiplier = 0.5f;
spaceDown = false;
gameStarted = false;
score = 0;
random = new Random();
dinoSpeedX = ScaleToHighDPI(1000f);
dinoJumpY = ScaleToHighDPI(-1200f);
gravitySpeed = ScaleToHighDPI(30f);
```

<span data-ttu-id="7163b-244">下から 3 つの変数は、変化レートをピクセルで指定しているため、高 DPI デバイス用にはスケーリングが必要である点に注意してください。</span><span class="sxs-lookup"><span data-stu-id="7163b-244">Note that the last three variables need to be scaled for high DPI devices, because they specify a rate of change in pixels.</span></span>

### <a name="4-construct-spriteclasses"></a><span data-ttu-id="7163b-245">4. SpriteClasses を作成する</span><span class="sxs-lookup"><span data-stu-id="7163b-245">4. Construct SpriteClasses</span></span>
<span data-ttu-id="7163b-246">SpriteClass オブジェクトは、**LoadContent** メソッドで作成します。</span><span class="sxs-lookup"><span data-stu-id="7163b-246">We will construct SpriteClass objects in the **LoadContent** method.</span></span> <span data-ttu-id="7163b-247">既にあるコードに、以下を追加します。</span><span class="sxs-lookup"><span data-stu-id="7163b-247">Add this code to what you already have there:</span></span>

```CSharp
dino = new SpriteClass(GraphicsDevice, "Content/ninja-cat-dino.png", ScaleToHighDPI(1f));
broccoli = new SpriteClass(GraphicsDevice, "Content/broccoli.png", ScaleToHighDPI(0.2f));
```

<span data-ttu-id="7163b-248">ブロッコリの画像は、ゲームへの表示に適したサイズよりかなり大きいため、元のサイズの 0.2 倍に縮小します。</span><span class="sxs-lookup"><span data-stu-id="7163b-248">The broccoli image is quite a lot larger than we want it to appear in the game, so we’ll scale it down to 0.2 times its original size.</span></span>

### <a name="5-program-obstacle-behavior"></a><span data-ttu-id="7163b-249">5. 障害物の動作のプログラム</span><span class="sxs-lookup"><span data-stu-id="7163b-249">5. Program obstacle behavior</span></span>
<span data-ttu-id="7163b-250">ブロッコリは画面の外で生成され、プレイヤーのアバターの方に向かうため、プレイヤーのアバターはブロッコリをかわす必要があります。</span><span class="sxs-lookup"><span data-stu-id="7163b-250">We want the broccoli to spawn somewhere offscreen, and head in the direction of the player’s avatar, so they need to dodge it.</span></span> <span data-ttu-id="7163b-251">そのためには、このメソッドを **Game1.cs** クラスに追加します。</span><span class="sxs-lookup"><span data-stu-id="7163b-251">To accomplish they, add this method to the **Game1.cs** class:</span></span>

```CSharp
public void SpawnBroccoli()
{
  int direction = random.Next(1, 5);
  switch (direction)
  {
    case 1:
      broccoli.x = -100;
      broccoli.y = random.Next(0, (int)screenHeight);
      break;
    case 2:
      broccoli.y = -100;
      broccoli.x = random.Next(0, (int)screenWidth);
      break;
    case 3:
      broccoli.x = screenWidth + 100;
      broccoli.y = random.Next(0, (int)screenHeight);
      break;
    case 4:
      broccoli.y = screenHeight + 100;
      broccoli.x = random.Next(0, (int)screenWidth);
      break;
  }

  if (score % 5 == 0) broccoliSpeedMultiplier += 0.2f;

  broccoli.dX = (dino.x - broccoli.x) * broccoliSpeedMultiplier;
  broccoli.dY = (dino.y - broccoli.y) * broccoliSpeedMultiplier;
  broccoli.dA = 7f;
}
```

<span data-ttu-id="7163b-252">メソッドの最初の部分では、ランダム数を使用して、broccoli オブジェクトが生成される画面外の位置を指定しています。</span><span class="sxs-lookup"><span data-stu-id="7163b-252">The first part of the of the method determines what off screen point the broccoli object will spawn from, using two random numbers.</span></span>

<span data-ttu-id="7163b-253">2 番目の部分では、現在のスコアによってブロッコリの速度を決定しています。</span><span class="sxs-lookup"><span data-stu-id="7163b-253">The second part determines how fast the broccoli will travel, which is determined by the current score.</span></span> <span data-ttu-id="7163b-254">プレイヤーがブロッコリを 5 個かわすごとに、速度が増します。</span><span class="sxs-lookup"><span data-stu-id="7163b-254">It will get faster for every five broccoli the player successfully dodges.</span></span>

<span data-ttu-id="7163b-255">3 番目の部分では、broccoli スプライトによるモーションの方向を設定しています。</span><span class="sxs-lookup"><span data-stu-id="7163b-255">The third part sets the direction of the broccoli sprite’s motion.</span></span> <span data-ttu-id="7163b-256">ブロッコリは、生成されると、プレイヤーのアバター (恐竜) の方に向います。</span><span class="sxs-lookup"><span data-stu-id="7163b-256">It heads in the direction of the player avatar (dino) when the broccoli is spawned.</span></span> <span data-ttu-id="7163b-257">また、**dA** には 7f という値が設定されています。これにより、プレイヤーを追随する際にはブロッコリがスピンしながら空中を進むことになります。</span><span class="sxs-lookup"><span data-stu-id="7163b-257">We also give it a **dA** value of 7f, which will cause the broccoli to spin through the air as it chases the player.</span></span>

### <a name="6-program-game-starting-state"></a><span data-ttu-id="7163b-258">6. ゲームの開始状態のプログラム</span><span class="sxs-lookup"><span data-stu-id="7163b-258">6. Program game starting state</span></span>
<span data-ttu-id="7163b-259">キーボード入力の処理に進む前に、作成した 2 つのオブジェクトの初期ゲーム状態を設定するメソッドが必要です。</span><span class="sxs-lookup"><span data-stu-id="7163b-259">Before we can move on to handling keyboard input, we need a method that sets the initial game state of the two objects we’ve created.</span></span> <span data-ttu-id="7163b-260">また、ゲームはアプリが実行されるとすぐに開始するのではなく、ユーザーが Space キーを押すことにより手動で開始できるようにします。</span><span class="sxs-lookup"><span data-stu-id="7163b-260">Rather than the game starting as soon as the app runs, we want the user to start it manually, by pressing the spacebar.</span></span> <span data-ttu-id="7163b-261">アニメーション化されたオブジェクトの初期状態を設定し、スコアをリセットする以下のコードを追加してください。</span><span class="sxs-lookup"><span data-stu-id="7163b-261">Add the following code, which sets the initial state of the animated objects, and resets the score:</span></span>

```CSharp
public void StartGame()
{
  dino.x = screenWidth / 2;
  dino.y = screenHeight * SKYRATIO;
  broccoliSpeedMultiplier = 0.5f;
  SpawnBroccoli();  
  score = 0;
}
```

### <a name="7-handle-keyboard-input"></a><span data-ttu-id="7163b-262">7. キーボード入力を処理します。</span><span class="sxs-lookup"><span data-stu-id="7163b-262">7. Handle keyboard input</span></span>
<span data-ttu-id="7163b-263">次に、キーボード経由でユーザー入力を処理する新しいメソッドが必要です。</span><span class="sxs-lookup"><span data-stu-id="7163b-263">Next we need a new method to handle user input via the keyboard.</span></span> <span data-ttu-id="7163b-264">このメソッドを **Game1.cs** に追加します。</span><span class="sxs-lookup"><span data-stu-id="7163b-264">Add this this method to **Game1.cs**:</span></span>

```CSharp
void KeyboardHandler()
{
  KeyboardState state = Keyboard.GetState();

  // Quit the game if Escape is pressed.
  if (state.IsKeyDown(Keys.Escape))
  {
    Exit();
  }

  // Start the game if Space is pressed.
  if (!gameStarted)
  {
    if (state.IsKeyDown(Keys.Space))
    {
      StartGame();
      gameStarted = true;
      spaceDown = true;
      gameOver = false;
    }
    return;
  }            
  // Jump if Space is pressed
  if (state.IsKeyDown(Keys.Space) || state.IsKeyDown(Keys.Up))
  {
    // Jump if the Space is pressed but not held and the dino is on the floor
    if (!spaceDown && dino.y >= screenHeight * SKYRATIO - 1) dino.dY = dinoJumpY;

    spaceDown = true;
  }
  else spaceDown = false;

  // Handle left and right
  if (state.IsKeyDown(Keys.Left)) dino.dX = dinoSpeedX * -1;

  else if (state.IsKeyDown(Keys.Right)) dino.dX = dinoSpeedX;
  else dino.dX = 0;
}
```

<span data-ttu-id="7163b-265">上のコードには、4 つの if ステートメントが含まれています。</span><span class="sxs-lookup"><span data-stu-id="7163b-265">Above we have a series of four if-statements:</span></span>

<span data-ttu-id="7163b-266">1 つ目では、**Esc** キーが押されるとゲームを終了します。</span><span class="sxs-lookup"><span data-stu-id="7163b-266">The first quits the game if the **Escape** key is pressed.</span></span>

<span data-ttu-id="7163b-267">2 つ目では、**Space** キーが押され、ゲームがまだ開始されていなければ、ゲームを開始します。</span><span class="sxs-lookup"><span data-stu-id="7163b-267">The second starts the game if the **Space** key is pressed, and the game is not already started.</span></span>

<span data-ttu-id="7163b-268">3 つ目では、**Space** が押されると **dY** プロパティを変更することで恐竜アバターをジャンプさせます。</span><span class="sxs-lookup"><span data-stu-id="7163b-268">The third makes the dino avatar jump if **Space** is pressed, by changing its **dY** property.</span></span> <span data-ttu-id="7163b-269">ただしプレイヤーは、"地上" (dino.y = screenHeight \* SKYRATIO) にいなければジャンプできません。また、Space キーが 1 回押されるのではなく押したままになっている場合もジャンプしません。</span><span class="sxs-lookup"><span data-stu-id="7163b-269">Note that the player cannot jump unless they are on the “ground” (dino.y = screenHeight \* SKYRATIO), and will also not jump if the space key is being help down rather than pressed once.</span></span> <span data-ttu-id="7163b-270">押したままになっている場合は、ゲームを開始する同じキープレスが認識され、ゲームが始まると同時に恐竜がジャンプできなくなります。</span><span class="sxs-lookup"><span data-stu-id="7163b-270">This stops the dino from jumping as soon as the game is started, piggybacking on the same keypress that starts the game.</span></span>

<span data-ttu-id="7163b-271">最後の if/else 句では、左または右の方向キーが押されているかどうかを確認し、押されている場合は、キーに応じて恐竜の **dX** プロパティを変更します。</span><span class="sxs-lookup"><span data-stu-id="7163b-271">Finally, the last if/else clause checks if the left or right directional arrows are being pressed, and if so changes the dino’s **dX** property accordingly.</span></span>

<span data-ttu-id="7163b-272">**課題:** 上のキーボード処理メソッドで、方向キーと同様に、WASD 入力スキームも処理できますか?</span><span class="sxs-lookup"><span data-stu-id="7163b-272">**Challenge:** can you make the keyboard handling method above work with the WASD input scheme as well as the arrow keys?</span></span>

### <a name="8-add-logic-to-the-update-method"></a><span data-ttu-id="7163b-273">8. ロジックに Update メソッドを追加する</span><span class="sxs-lookup"><span data-stu-id="7163b-273">8. Add logic to the Update method</span></span>
<span data-ttu-id="7163b-274">次に、これらすべての部分のロジックを **Game1.cs** の **Update** メソッドに追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="7163b-274">Next we need to add logic for all of these parts to the **Update** method in **Game1.cs**:</span></span>

```CSharp
float elapsedTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
KeyboardHandler(); // Handle keyboard input
// Update animated SpriteClass objects based on their current rates of change
dino.Update(elapsedTime);
broccoli.Update(elapsedTime);

// Accelerate the dino downward each frame to simulate gravity.
dino.dY += gravitySpeed;

// Set game floor so the player does not fall through it
if (dino.y > screenHeight * SKYRATIO)
{
  dino.dY = 0;
  dino.y = screenHeight * SKYRATIO;
}

// Set game edges to prevent the player from moving offscreen
if (dino.x > screenWidth - dino.texture.Width/2)
{
  dino.x = screenWidth - dino.texture.Width/2;
  dino.dX = 0;
}
if (dino.x < 0 + dino.texture.Width/2)
{
  dino.x = 0 + dino.texture.Width/2;
  dino.dX = 0;
}

// If the broccoli goes offscreen, spawn a new one and iterate the score
if (broccoli.y > screenHeight+100 || broccoli.y < -100 || broccoli.x > screenWidth+100 || broccoli.x < -100)
{
  SpawnBroccoli();
  score++;
}
```

### <a name="9-draw-spriteclass-objects"></a><span data-ttu-id="7163b-275">9. SpriteClass オブジェクトを描画する</span><span class="sxs-lookup"><span data-stu-id="7163b-275">9. Draw SpriteClass objects</span></span>
<span data-ttu-id="7163b-276">最後に、**Game1.cs** の **Draw** メソッドに以下のコードを追加します (**spriteBatch.Draw** の最後の呼び出しの直後)。</span><span class="sxs-lookup"><span data-stu-id="7163b-276">Finally, add the following code to the **Draw** method of **Game1.cs**, just after the last call of **spriteBatch.Draw**:</span></span>

```CSharp
broccoli.Draw(spriteBatch);
dino.Draw(spriteBatch);
```

<span data-ttu-id="7163b-277">MonoGame では、**spriteBatch.Draw** を新しく呼び出すと、その時点までの呼び出しを上書きして描画されます。</span><span class="sxs-lookup"><span data-stu-id="7163b-277">In MonoGame, new calls of **spriteBatch.Draw** will draw over any prior calls.</span></span> <span data-ttu-id="7163b-278">つまり、broccoli および dino スプライトはどちらも、既存の grass スプライトの上に描画されるため、どこにあっても grass スプライトに隠れることはありません。</span><span class="sxs-lookup"><span data-stu-id="7163b-278">This means that both the broccoli and the dino sprite will be drawn over the  existing grass sprite, so they can never be hidden behind it regardless of their position.</span></span>

<span data-ttu-id="7163b-279">ここでゲームを実行し、方向キーと Space キーを使用して、恐竜を動かしてみてください。</span><span class="sxs-lookup"><span data-stu-id="7163b-279">Try running the game now, and moving around the dino with the arrow keys and the spacebar.</span></span> <span data-ttu-id="7163b-280">これまでの手順に従っていれば、ゲーム ウィンドウ内でアバターを移動できます。ブロッコリはさらに高速化します。</span><span class="sxs-lookup"><span data-stu-id="7163b-280">If you followed the steps above, you should be able to make your avatar move within the game window, and the broccoli should at an ever-increasing speed.</span></span>

![プレイヤーのアバターと障害物](images/monogame-tutorial-2.png)

## <a name="render-text-with-spritefont"></a><span data-ttu-id="7163b-282">SpriteFont によるテキストのレンダリング</span><span class="sxs-lookup"><span data-stu-id="7163b-282">Render text with SpriteFont</span></span>
<span data-ttu-id="7163b-283">上記のコードでは、プレイヤーのスコアを内部的に追跡できますが、実際にはプレイヤーに伝えていません。</span><span class="sxs-lookup"><span data-stu-id="7163b-283">Using the code above, we keep track of the player’s score behind the scenes, but we don’t actually tell the player what it is.</span></span> <span data-ttu-id="7163b-284">また、アプリの起動時に表示される画面は、あまり直観的ではありません。プレイヤーには青と緑のウィンドウが見えますが、ゲームを開始するためには Space キーを押す必要があると知る方法がありません。</span><span class="sxs-lookup"><span data-stu-id="7163b-284">We also have a fairly unintuitive introduction when the app starts up—the player sees a blue and green window, but has no way of knowing they need to press Space to get things rolling.</span></span>

<span data-ttu-id="7163b-285">これらの問題をどちらも解決するために、**SpriteFonts** という新しい種類の MonoGame オブジェクトを使用します。</span><span class="sxs-lookup"><span data-stu-id="7163b-285">To fix both these problems, we’re going to use a new kind of MonoGame object called **SpriteFonts**.</span></span>

### <a name="1-create-spritefont-description-files"></a><span data-ttu-id="7163b-286">1. SpriteFont 記述ファイルを作成する</span><span class="sxs-lookup"><span data-stu-id="7163b-286">1. Create SpriteFont description files</span></span>
<span data-ttu-id="7163b-287">**ソリューション エクスプローラー**で、**[コンテンツ]** フォルダーを見つけます。</span><span class="sxs-lookup"><span data-stu-id="7163b-287">In the **Solution Explorer** find the **Content** folder.</span></span> <span data-ttu-id="7163b-288">このフォルダー内の **Content.mgcb** ファイルを右クリックし、**[プログラムから開く]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="7163b-288">In this folder, Right-Click the **Content.mgcb** file and select **Open With**.</span></span> <span data-ttu-id="7163b-289">ポップアップ メニューから **[MonoGame Pipeline]** (MonoGame パイプライン) を選択し、**[OK]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="7163b-289">From the popup menu select **MonoGame Pipeline**, then press **OK**.</span></span> <span data-ttu-id="7163b-290">新しいウィンドウで **[コンテンツ]** 項目を右クリックし、**[追加] -> [新しいアイテム]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="7163b-290">In the new window, Right-Click the **Content** item and select **Add -> New Item**.</span></span> <span data-ttu-id="7163b-291">**[SpriteFont Description]** (SpriteFont 記述) を選択し、「Score」という名前を指定して、**[OK]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="7163b-291">Select **SpriteFont Description**, name it “Score” and press **OK**.</span></span> <span data-ttu-id="7163b-292">次に、同じ手順を使って、別の SpriteFont 記述を「GameState」という名前で追加します。</span><span class="sxs-lookup"><span data-stu-id="7163b-292">Then, add another SpriteFont description named “GameState” using the same procedure.</span></span>

### <a name="2-edit-descriptions"></a><span data-ttu-id="7163b-293">2. 記述を編集する</span><span class="sxs-lookup"><span data-stu-id="7163b-293">2. Edit descriptions</span></span>
<span data-ttu-id="7163b-294">**[MonoGame Pipeline]** (MonoGame パイプライン) の **[コンテンツ]** フォルダーを右クリックし、**[ファイルの場所を開く]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="7163b-294">Right click the **Content** folder in the **MonoGame Pipeline** and select **Open File Location**.</span></span> <span data-ttu-id="7163b-295">先ほど作成した SpriteFont 記述ファイルや、これまでに [コンテンツ] フォルダーに追加した画像がすべて含まれたフォルダーが表示されます。</span><span class="sxs-lookup"><span data-stu-id="7163b-295">You should see a folder with the SpriteFont description files that you just created, as well as any images you’ve added to the Content folder so far.</span></span> <span data-ttu-id="7163b-296">MonoGame パイプライン ウィンドウを保存して閉じます。</span><span class="sxs-lookup"><span data-stu-id="7163b-296">You can now close and save the MonoGame Pipeline window.</span></span> <span data-ttu-id="7163b-297">**エクスプローラー**で、両方の記述ファイルをテキスト エディター (Visual Studio、NotePad++、Atom など) で開きます。</span><span class="sxs-lookup"><span data-stu-id="7163b-297">From the **File Explorer** open both description files in a text editor (Visual Studio, NotePad++, Atom, etc).</span></span>

<span data-ttu-id="7163b-298">各記述には、SpriteFont を記述するさまざまな値が含まれています。</span><span class="sxs-lookup"><span data-stu-id="7163b-298">Each description contains a number of values that describe the SpriteFont.</span></span> <span data-ttu-id="7163b-299">いくつか変更を行いましょう。</span><span class="sxs-lookup"><span data-stu-id="7163b-299">We're going to make a few changes:</span></span>

<span data-ttu-id="7163b-300">**Score.spritefont** で、**<Size>** の値を 12 から 36 に変更します。</span><span class="sxs-lookup"><span data-stu-id="7163b-300">In **Score.spritefont**, change the **<Size>** value from 12 to 36.</span></span>

<span data-ttu-id="7163b-301">**GameState.spritefont** で、**<Size>** の値を 12 から 72 に変更し、**<FontName>** の値を Arial から Agency に変更します。</span><span class="sxs-lookup"><span data-stu-id="7163b-301">In **GameState.spritefont**, change the **<Size>** value from 12 to 72, and the **<FontName>** value from Arial to Agency.</span></span> <span data-ttu-id="7163b-302">Agency も、Windows 10 のコンピューターに標準で付属しているフォントです。画面にスタイルを加えるために、これを使用します。</span><span class="sxs-lookup"><span data-stu-id="7163b-302">Agency is another font that comes standard with Windows 10 machines, and will add some flair to our intro screen.</span></span>

### <a name="3-load-spritefonts"></a><span data-ttu-id="7163b-303">3. SpriteFonts を読み込む</span><span class="sxs-lookup"><span data-stu-id="7163b-303">3. Load SpriteFonts</span></span>
<span data-ttu-id="7163b-304">Visual Studio に戻って、まず、導入のスプラッシュ スクリーン用に新しいテクスチャを追加します。</span><span class="sxs-lookup"><span data-stu-id="7163b-304">Back in Visual Studio, we’re first going to add a new texture for the intro splash screen.</span></span> <span data-ttu-id="7163b-305">[画像をダウンロードするには、こちらをクリックしてください](https://github.com/Microsoft/Windows-appsample-get-started-mg2d/blob/master/MonoGame2D/Content/start-splash.png)。</span><span class="sxs-lookup"><span data-stu-id="7163b-305">[Click here to download the image](https://github.com/Microsoft/Windows-appsample-get-started-mg2d/blob/master/MonoGame2D/Content/start-splash.png).</span></span>

<span data-ttu-id="7163b-306">先ほどと同じように、[コンテンツ] を右クリックして **[追加] -> [既存の項目]** を選択することで、テクスチャをプロジェクトに追加します。</span><span class="sxs-lookup"><span data-stu-id="7163b-306">As before, add the texture to the project by right-clicking the Content and selecting **Add -> Existing Item**.</span></span> <span data-ttu-id="7163b-307">新しい項目に「start-splash.png」という名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="7163b-307">Name the new item “start-splash.png”.</span></span>

<span data-ttu-id="7163b-308">次に、以下のクラス変数を **Game1.cs** に追加します。</span><span class="sxs-lookup"><span data-stu-id="7163b-308">Next, add the following class variables to **Game1.cs**:</span></span>

```CSharp
Texture2D startGameSplash;
SpriteFont scoreFont;
SpriteFont stateFont;
```

<span data-ttu-id="7163b-309">次に、以下の行を **LoadContent** メソッドに追加します。</span><span class="sxs-lookup"><span data-stu-id="7163b-309">Then add these lines to the **LoadContent** method:</span></span>

```CSharp
startGameSplash = Content.Load<Texture2D>("start-splash");
scoreFont = Content.Load<SpriteFont>("Score");
stateFont = Content.Load<SpriteFont>("GameState");
```

### <a name="4-draw-the-score"></a><span data-ttu-id="7163b-310">4. スコアを描画する</span><span class="sxs-lookup"><span data-stu-id="7163b-310">4. Draw the score</span></span>
<span data-ttu-id="7163b-311">**Game1.cs** の **Draw** メソッドに移動し、以下のコードを **spriteBatch.End();** の直前に追加します。</span><span class="sxs-lookup"><span data-stu-id="7163b-311">Go to the **Draw** method of **Game1.cs** and add the following code just before **spriteBatch.End();**</span></span>

```CSharp
spriteBatch.DrawString(scoreFont, score.ToString(),
new Vector2(screenWidth - 100, 50), Color.Black);
```

<span data-ttu-id="7163b-312">上のコードでは、先ほど作成したスプライト記述 (Arial Size 36) を使用して、プレイヤーの現在のスコアを画面の右上付近に描画しています。</span><span class="sxs-lookup"><span data-stu-id="7163b-312">The code above uses the sprite description we created (Arial Size 36) to draw the player’s current score near the top right corner of the screen.</span></span>

### <a name="5-draw-horizontally-centered-text"></a><span data-ttu-id="7163b-313">5. テキストを水平方向で中央揃えにして描画する</span><span class="sxs-lookup"><span data-stu-id="7163b-313">5. Draw horizontally centered text</span></span>
<span data-ttu-id="7163b-314">ゲームを作成する場合は、水平方向または垂直方向で中央揃えにしてテキストを描画する機会が多数あります。</span><span class="sxs-lookup"><span data-stu-id="7163b-314">When making a game, you will often want to draw text that is centered, either horizontally or vertically.</span></span> <span data-ttu-id="7163b-315">導入のテキストを水平方向で中央揃えにするには、以下のコードを **Draw**メソッドの **spriteBatch.End();** の直前に追加します。</span><span class="sxs-lookup"><span data-stu-id="7163b-315">To horizontally center the introductory text, add this code to the **Draw** method just before **spriteBatch.End();**</span></span>

```CSharp
if (!gameStarted)
{
  // Fill the screen with black before the game starts
  spriteBatch.Draw(startGameSplash, new Rectangle(0, 0,
  (int)screenWidth, (int)screenHeight), Color.White);

  String title = "VEGGIE JUMP";
  String pressSpace = "Press Space to start";

  // Measure the size of text in the given font
  Vector2 titleSize = stateFont.MeasureString(title);
  Vector2 pressSpaceSize = stateFont.MeasureString(pressSpace);

  // Draw the text horizontally centered
  spriteBatch.DrawString(stateFont, title,
  new Vector2(screenWidth / 2 - titleSize.X / 2, screenHeight / 3),
  Color.ForestGreen);
  spriteBatch.DrawString(stateFont, pressSpace,
  new Vector2(screenWidth / 2 - pressSpaceSize.X / 2,
  screenHeight / 2), Color.White);
  }
```

<span data-ttu-id="7163b-316">まず、描画するテキスト行に対して 1 つずつ、合計 2 つの String を作成します。</span><span class="sxs-lookup"><span data-stu-id="7163b-316">First we create two Strings, one for each line of text we want to draw.</span></span> <span data-ttu-id="7163b-317">次に、**SpriteFont.MeasureString(String)** メソッドを使用して、各行の出力時の幅と高さを計測します。</span><span class="sxs-lookup"><span data-stu-id="7163b-317">Next, we measure the width and height of each line when printed, using the **SpriteFont.MeasureString(String)** method.</span></span> <span data-ttu-id="7163b-318">これにより、サイズを **Vector2** オブジェクトとして取得できます。**X** プロパティには幅、**Y** プロパティには高さが格納されます。</span><span class="sxs-lookup"><span data-stu-id="7163b-318">This gives us the size as a **Vector2** object, with the **X** property containing its width, and **Y** its height.</span></span>

<span data-ttu-id="7163b-319">最後に、1 行ずつ描画しています。</span><span class="sxs-lookup"><span data-stu-id="7163b-319">Finally, we draw each line.</span></span> <span data-ttu-id="7163b-320">テキストを水平方向で中央揃えにするために、位置ベクトルの **X** 値として **screenWidth / 2 - textSize.X / 2** を指定しています。</span><span class="sxs-lookup"><span data-stu-id="7163b-320">To center the text horizontally, we make the **X** value of it’s position vector equal to **screenWidth / 2 - textSize.X / 2**</span></span>

<span data-ttu-id="7163b-321">**課題:** テキストを水平方向だけでなく垂直方向でも中央揃えにするには、上の手順をどのように変更しますか?</span><span class="sxs-lookup"><span data-stu-id="7163b-321">**Challenge:** how would you change the procedure above to center the text vertically as well as horizontally?</span></span>

<span data-ttu-id="7163b-322">ゲームを実行してみましょう。</span><span class="sxs-lookup"><span data-stu-id="7163b-322">Try running the game.</span></span> <span data-ttu-id="7163b-323">導入のスプラッシュ スクリーンは表示されますか? </span><span class="sxs-lookup"><span data-stu-id="7163b-323">Do you see the intro splash screen?</span></span> <span data-ttu-id="7163b-324">ブロッコリが再生成されるたびに、スコア カウントが加算されますか?</span><span class="sxs-lookup"><span data-stu-id="7163b-324">Does the score count up each time the broccoli respawns?</span></span>

![導入のスプラッシュ](images/monogame-tutorial-3.png)

## <a name="collision-detection"></a><span data-ttu-id="7163b-326">衝突の検出</span><span class="sxs-lookup"><span data-stu-id="7163b-326">Collision detection</span></span>
<span data-ttu-id="7163b-327">これで、プレイヤーを追随するブロッコリをセットアップし、新しいブロッコリが生成されるたびに加算されるスコアも用意できました。ただ、このままでは、実際にゲームに負ける方法がありません。</span><span class="sxs-lookup"><span data-stu-id="7163b-327">So we have a broccoli that follows you around, and we have a score that ticks up each time a new one spawns—but as it is there is no way to actually lose this game.</span></span> <span data-ttu-id="7163b-328">dino スプライトと broccoli スプライトが衝突したかどうかを知り、衝突した場合はゲーム オーバーを宣言する手段が必要です。</span><span class="sxs-lookup"><span data-stu-id="7163b-328">We need a way to know if the dino and broccoli sprites collide, and if when they do, to declare the game over.</span></span>

### <a name="1-rectangular-collision"></a><span data-ttu-id="7163b-329">1. 四角形の衝突</span><span class="sxs-lookup"><span data-stu-id="7163b-329">1. Rectangular collision</span></span>
<span data-ttu-id="7163b-330">ゲーム内での衝突を検出するためには、多くの場合、オブジェクトを単純化して数学的な複雑さを軽減します。</span><span class="sxs-lookup"><span data-stu-id="7163b-330">When detecting collisions in a game, objects are often simplified to reduce the complexity of the math involved.</span></span> <span data-ttu-id="7163b-331">ここでは、プレイヤーのアバターとブロッコリの障害物の衝突を検出する目的で、これらをどちらも四角形として扱います。</span><span class="sxs-lookup"><span data-stu-id="7163b-331">We are going to treat both the player avatar and broccoli obstacle as rectangles for the purpose of detecting collision between them.</span></span>

<span data-ttu-id="7163b-332">**SpriteClass.cs** を開き、新しいクラス変数を追加します。</span><span class="sxs-lookup"><span data-stu-id="7163b-332">Open **SpriteClass.cs** and add a new class variable:</span></span>

```CSharp
const float HITBOXSCALE = .5f;
```

<span data-ttu-id="7163b-333">この値は、衝突の検出がプレイヤーにとってどの程度 "寛容" であるかを表します。</span><span class="sxs-lookup"><span data-stu-id="7163b-333">This value will represent how “forgiving” the collision detection is for the player.</span></span> <span data-ttu-id="7163b-334">この値を .5f にした場合、恐竜がブロッコリに衝突する四角形の境界 (多くの場合は "ヒットボックス" と呼ばれます) が、テクスチャのフルサイズの半分になります。</span><span class="sxs-lookup"><span data-stu-id="7163b-334">With a value of .5f, the edges of the rectangle in which the dino can collide with the broccoli—often call the “hitbox”—will be half of the full size of the texture.</span></span> <span data-ttu-id="7163b-335">その結果、画像のどの部分も実際に触れているようには見えないのに 2 つのテクスチャの角が衝突する機会は少なくなります。</span><span class="sxs-lookup"><span data-stu-id="7163b-335">This will result in few instances where the corners of the two textures collide, without any parts of the images actually appearing to touch.</span></span> <span data-ttu-id="7163b-336">この値は、好みに応じて自由に調整してください。</span><span class="sxs-lookup"><span data-stu-id="7163b-336">Feel free to tweak this value to your personal taste.</span></span>

<span data-ttu-id="7163b-337">次に、新しいメソッドを **SpriteClass.cs** に追加します。</span><span class="sxs-lookup"><span data-stu-id="7163b-337">Next, add a new method to **SpriteClass.cs**:</span></span>

```CSharp
public bool RectangleCollision(SpriteClass otherSprite)
{
  if (this.x + this.texture.Width * this.scale * HITBOXSCALE / 2 < otherSprite.x - otherSprite.texture.Width * otherSprite.scale / 2) return false;
  if (this.y + this.texture.Height * this.scale * HITBOXSCALE / 2 < otherSprite.y - otherSprite.texture.Height * otherSprite.scale / 2) return false;
  if (this.x - this.texture.Width * this.scale * HITBOXSCALE / 2 > otherSprite.x + otherSprite.texture.Width * otherSprite.scale / 2) return false;
  if (this.y - this.texture.Height * this.scale * HITBOXSCALE / 2 > otherSprite.y + otherSprite.texture.Height * otherSprite.scale / 2) return false;
  return true;
}
```

<span data-ttu-id="7163b-338">このメソッドでは、2 つの四角形オブジェクトが衝突したかどうかを検出します。</span><span class="sxs-lookup"><span data-stu-id="7163b-338">This method detects if two rectangular objects have collided.</span></span> <span data-ttu-id="7163b-339">このアルゴリズムでは、四角形どうしの辺と辺の間に隙間があるかどうかをテストします。</span><span class="sxs-lookup"><span data-stu-id="7163b-339">The algorithm works by testing to see if there is a gap between any of the side sides of the rectangles.</span></span> <span data-ttu-id="7163b-340">隙間があれば、衝突していません。隙間がなければ、衝突しているということになります。</span><span class="sxs-lookup"><span data-stu-id="7163b-340">If there is any gap, there is no collision—if no gap exists, there must be a collision.</span></span>

### <a name="2-load-new-textures"></a><span data-ttu-id="7163b-341">2. 新しいテクスチャを読み込む</span><span class="sxs-lookup"><span data-stu-id="7163b-341">2. Load new textures</span></span>

<span data-ttu-id="7163b-342">次は、**Game1.cs** を開き、2 つの新しいクラス変数を追加します。1 つはゲーム オーバーのスプライト テクスチャを格納し、もう 1 つはゲームの状態を追跡するためのブール値を格納します。</span><span class="sxs-lookup"><span data-stu-id="7163b-342">Then, open **Game1.cs** and add two new class variables, one to store the game over sprite texture, and a Boolean to track the game’s state:</span></span>

```CSharp
Texture2D gameOverTexture;
bool gameOver;
```

<span data-ttu-id="7163b-343">次に、**Initialize** メソッドで **gameOver** を初期化します。</span><span class="sxs-lookup"><span data-stu-id="7163b-343">Then, initialize **gameOver** in the **Initialize** method:</span></span>

```CSharp
gameOver = false;
```

<span data-ttu-id="7163b-344">最後に、**LoadContent** メソッドの **gameOverTexture** にテクスチャを読み込みます。</span><span class="sxs-lookup"><span data-stu-id="7163b-344">Finally, load the texture into **gameOverTexture** in the **LoadContent** method:</span></span>

```CSharp
gameOverTexture = Content.Load<Texture2D>("game-over");
```

### <a name="3-implement-game-over-logic"></a><span data-ttu-id="7163b-345">3."ゲーム オーバー" のロジックを実装する</span><span class="sxs-lookup"><span data-stu-id="7163b-345">3. Implement “game over” logic</span></span>
<span data-ttu-id="7163b-346">以下のコードを **Update** メソッド (**KeyboardHandler** メソッドの呼び出し直後) に追加します。</span><span class="sxs-lookup"><span data-stu-id="7163b-346">Add this code to the **Update** method, just after the **KeyboardHandler** method is called:</span></span>

```CSharp
if (gameOver)
{
  dino.dX = 0;
  dino.dY = 0;
  broccoli.dX = 0;
  broccoli.dY = 0;
  broccoli.dA = 0;
}
```

<span data-ttu-id="7163b-347">これにより、ゲームが終了したときにすべてのモーションが停止し、恐竜とブロッコリが現在の位置に固定されます。</span><span class="sxs-lookup"><span data-stu-id="7163b-347">This will cause all motion to stop when the game has ended, freezing the dino and broccoli sprites in their current positions.</span></span>

<span data-ttu-id="7163b-348">次に、**Update** メソッドの最後 (**base.Update(gameTime)** の直前) に、以下の行を追加します。</span><span class="sxs-lookup"><span data-stu-id="7163b-348">Next, at the end of the **Update** method, just before **base.Update(gameTime)**, add this line:</span></span>

```CSharp
if (dino.RectangleCollision(broccoli)) gameOver = true;
```

<span data-ttu-id="7163b-349">これにより、**SpriteClass** で作成した **RectangleCollision** メソッドが呼び出され、true が返された場合は、ゲーム オーバーのフラグが設定されます。</span><span class="sxs-lookup"><span data-stu-id="7163b-349">This calls the **RectangleCollision** method we created in **SpriteClass**, and flags the game as over if it returns true.</span></span>

### <a name="4-add-user-input-for-resetting-the-game"></a><span data-ttu-id="7163b-350">4. ゲームをリセットするためのユーザー入力を追加する</span><span class="sxs-lookup"><span data-stu-id="7163b-350">4. Add user input for resetting the game</span></span>
<span data-ttu-id="7163b-351">ユーザーが Enter キーを押してゲームをリセットできるように、以下のコードを **KeyboardHandler** メソッドに追加します。</span><span class="sxs-lookup"><span data-stu-id="7163b-351">Add this code to the **KeyboardHandler** method, to allow the user to reset them game if they press Enter:</span></span>

```CSharp
if (gameOver && state.IsKeyDown(Keys.Enter))
{
  StartGame();
  gameOver = false;
}
```

### <a name="5-draw-game-over-splash-and-text"></a><span data-ttu-id="7163b-352">5. ゲーム オーバーのスプラッシュとテキストを描画する</span><span class="sxs-lookup"><span data-stu-id="7163b-352">5. Draw game over splash and text</span></span>
<span data-ttu-id="7163b-353">最後に、以下のコードを Draw メソッド内の **spriteBatch.Draw** の呼び出し (grass テクスチャを描画する) の直後に追加します。</span><span class="sxs-lookup"><span data-stu-id="7163b-353">Finally, add this code to the Draw method, just after the first call of **spriteBatch.Draw** (this should be the call that draws the grass texture).</span></span>

```CSharp
if (gameOver)
{
  // Draw game over texture
  spriteBatch.Draw(gameOverTexture, new Vector2(screenWidth / 2 - gameOverTexture.Width / 2, screenHeight / 4 - gameOverTexture.Width / 2), Color.White);

  String pressEnter = "Press Enter to restart!";

  // Measure the size of text in the given font
  Vector2 pressEnterSize = stateFont.MeasureString(pressEnter);

  // Draw the text horizontally centered
  spriteBatch.DrawString(stateFont, pressEnter, new Vector2(screenWidth / 2 - pressEnterSize.X / 2, screenHeight - 200), Color.White);
}
```

<span data-ttu-id="7163b-354">前と同じメソッドを使用して (導入のスプラッシュと同じフォントを使用して)、テキストを水平方向で中央揃えにします。また、ウィンドウの上半分で、**gameOverTexture** も中央揃えにします。</span><span class="sxs-lookup"><span data-stu-id="7163b-354">Here we use the same method as before to draw text horizontally centered (reusing the font we used for the intro splash), as well as centering **gameOverTexture** in the top half of the window.</span></span>

<span data-ttu-id="7163b-355">これで、終わりです。</span><span class="sxs-lookup"><span data-stu-id="7163b-355">And we’re done!</span></span> <span data-ttu-id="7163b-356">ゲームをもう一度実行してみてください。</span><span class="sxs-lookup"><span data-stu-id="7163b-356">Try running the game again.</span></span> <span data-ttu-id="7163b-357">これまでの手順に従っていれば、恐竜がブロッコリに衝突するとゲームが終了するようになっています。また、Enter キーを押してゲームを再起動するようにプレイヤーに求めるメッセージも表示されます。</span><span class="sxs-lookup"><span data-stu-id="7163b-357">If you followed the steps above, the game should now end when the dino collides with the broccoli, and the player should be prompted to restart the game by pressing the Enter key.</span></span>

![ゲーム オーバー](images/monogame-tutorial-4.png)

## <a name="publish-to-the-microsoft-store"></a><span data-ttu-id="7163b-359">Microsoft Store への公開します。</span><span class="sxs-lookup"><span data-stu-id="7163b-359">Publish to the Microsoft Store</span></span>
<span data-ttu-id="7163b-360">UWP アプリとしては、このゲームを作成したためは、このプロジェクトを Microsoft Store に公開することもできます。</span><span class="sxs-lookup"><span data-stu-id="7163b-360">Because we built this game as a UWP app, it is possible to publish this project to the Microsoft Store.</span></span> <span data-ttu-id="7163b-361">このプロセスにはいくつかの手順が必要になります。</span><span class="sxs-lookup"><span data-stu-id="7163b-361">There are a few steps to the process.</span></span>

<span data-ttu-id="7163b-362">Windows 開発者として[登録](https://developer.microsoft.com/en-us/store/register)する必要があります。</span><span class="sxs-lookup"><span data-stu-id="7163b-362">You must be [registered](https://developer.microsoft.com/en-us/store/register) as a Windows Developer.</span></span>

<span data-ttu-id="7163b-363">[アプリの申請チェックリスト](https://docs.microsoft.com/en-us/windows/uwp/publish/app-submissions)を使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="7163b-363">You must use the [app submission checklist](https://docs.microsoft.com/en-us/windows/uwp/publish/app-submissions).</span></span>

<span data-ttu-id="7163b-364">[認定](https://docs.microsoft.com/en-us/windows/uwp/publish/the-app-certification-process)を受けるために、アプリを提出する必要があります。</span><span class="sxs-lookup"><span data-stu-id="7163b-364">The app must be submitted for [certification](https://docs.microsoft.com/en-us/windows/uwp/publish/the-app-certification-process).</span></span>

<span data-ttu-id="7163b-365">詳細については、 [UWP アプリの公開](https://developer.microsoft.com/en-us/store/publish-apps)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="7163b-365">For more details, see [Publishing your UWP app](https://developer.microsoft.com/en-us/store/publish-apps).</span></span>
