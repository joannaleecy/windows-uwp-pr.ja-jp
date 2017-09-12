---
title: "入門チュートリアル - UWP ゲーム (JavaScript)"
description: "JavaScript と CreateJS で記述された Windows ストア向けのシンプルな UWP ゲーム"
author: jken
ms.author: jken
ms.date: 02/09/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.assetid: 01af8254-b073-445e-af4c-e474528f8aa3
ms.openlocfilehash: 3325883b85c87753625a39d5b5634a864bd9c49a
ms.sourcegitcommit: 3e083fe2e253365e506d3e215fca8c35e5e92243
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/18/2017
---
# <a name="get-started-tutorial-a-uwp-game-in-javascript"></a><span data-ttu-id="c0aac-104">入門チュートリアル: UWP ゲーム (JavaScript)</span><span class="sxs-lookup"><span data-stu-id="c0aac-104">Get Started Tutorial: A UWP game in JavaScript</span></span>

## <a name="a-simple-2d-uwp-game-for-the-windows-store-written-in-javascript-and-createjs"></a><span data-ttu-id="c0aac-105">JavaScript と CreateJS で記述された Windows ストア向けのシンプルな 2D UWP ゲーム</span><span class="sxs-lookup"><span data-stu-id="c0aac-105">A simple 2D UWP game for the Windows Store, written in JavaScript and CreateJS</span></span>


![Walking Dino スプライト シート](images/JS2D_1.png)


## <a name="introduction"></a><span data-ttu-id="c0aac-107">はじめに</span><span class="sxs-lookup"><span data-stu-id="c0aac-107">Introduction</span></span>


<span data-ttu-id="c0aac-108">Windows ストアにアプリを公開すると、さまざまな種類のデバイスを使う膨大な数の人々に、そのアプリを提供 (または販売!) することができます。</span><span class="sxs-lookup"><span data-stu-id="c0aac-108">Publishing an app to the Windows Store means you can share it (or sell it!) with millions of people, on many different devices.</span></span>  

<span data-ttu-id="c0aac-109">Windows ストアにアプリを公開するには、そのアプリを UWP (ユニバーサル Windows プラットフォーム) アプリとして作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c0aac-109">In order to publish your app to the Windows Store it must be written as a UWP (Universal Windows Platform) app.</span></span> <span data-ttu-id="c0aac-110">ただし、UWP はきわめて柔軟であり、多様な言語およびフレームワークをサポートしています。</span><span class="sxs-lookup"><span data-stu-id="c0aac-110">However the UWP is extremely flexible, and supports a wide variety of languages and frameworks.</span></span> <span data-ttu-id="c0aac-111">これを証明するために、いくつかの CreateJS ライブラリを活用して JavaScript で記述されたシンプルなゲームをサンプルとして紹介します。このサンプルでは、スプライトの記述、ゲーム ループの作成、キーボードとマウスのサポート、さまざまな画面サイズへの調整の方法を示します。</span><span class="sxs-lookup"><span data-stu-id="c0aac-111">To prove the point, this sample is a simple game written in JavaScript, making use of several CreateJS libraries, and demonstrates how to draw sprites, create a game loop, support the keyboard and mouse, and adapt to different screen sizes.</span></span>

<span data-ttu-id="c0aac-112">このプロジェクトは、Visual Studio を使って JavaScript で構築します。</span><span class="sxs-lookup"><span data-stu-id="c0aac-112">This project is built with JavaScript using Visual Studio.</span></span> <span data-ttu-id="c0aac-113">少し変更を加えると、Web サイトでホスティングすることも、他のプラットフォームに合わせることもできます。</span><span class="sxs-lookup"><span data-stu-id="c0aac-113">With some minor changes, it can also hosted on a website or adapted to other platforms.</span></span> 

<span data-ttu-id="c0aac-114">**注:** これはアプリを Windows ストアに公開できる状態にするために、JavaScript やサード パーティのライブラリの使用方法を示すことを目的としたものであり、完全なゲームではありません (おもしろいゲームでもありません)。</span><span class="sxs-lookup"><span data-stu-id="c0aac-114">**Note:** This is a not a complete (or good!) game; it is designed to demonstrate using JavaScript and a third party library to make an app ready to publish to the Windows Store.</span></span>


## <a name="requirements"></a><span data-ttu-id="c0aac-115">要件</span><span class="sxs-lookup"><span data-stu-id="c0aac-115">Requirements</span></span>

<span data-ttu-id="c0aac-116">このプロジェクトを操作するには、以下が必要になります。</span><span class="sxs-lookup"><span data-stu-id="c0aac-116">To play with this project, you'll need the following:</span></span>

* <span data-ttu-id="c0aac-117">現在のバージョンの Windows 10 を実行する Windows コンピューター (または仮想マシン)。</span><span class="sxs-lookup"><span data-stu-id="c0aac-117">A Windows computer (or a virtual machine) running the current version of Windows 10.</span></span>
* <span data-ttu-id="c0aac-118">Visual Studio。</span><span class="sxs-lookup"><span data-stu-id="c0aac-118">A copy of Visual Studio.</span></span> <span data-ttu-id="c0aac-119">無料の Visual Studio Community Edition は、[Visual Studio ホームページ](http://visualstudio.com)からダウンロードできます。</span><span class="sxs-lookup"><span data-stu-id="c0aac-119">The free Visual Studio Community Edition can be downloaded from the [Visual Studio homepage](http://visualstudio.com).</span></span>

<span data-ttu-id="c0aac-120">このプロジェクトでは、CreateJS という JavaScript フレームワークを使用します。</span><span class="sxs-lookup"><span data-stu-id="c0aac-120">This project makes use of the CreateJS JavaScript framework.</span></span> <span data-ttu-id="c0aac-121">CreateJS は、MIT ライセンスの下にリリースされる無料のツールであり、スプライト ベースのゲームを簡単に作成できるように設計されています。</span><span class="sxs-lookup"><span data-stu-id="c0aac-121">CreateJS is a free set of tools, released under a MIT license, designed to make it easy to create sprite-based games.</span></span> <span data-ttu-id="c0aac-122">CreateJS ライブラリは、既にプロジェクトに含まれています (ソリューション エクスプローラー ビューで *js/easeljs-0.8.2.min.js* および *js/preloadjs-0.6.2.min.js* を探してください)。</span><span class="sxs-lookup"><span data-stu-id="c0aac-122">The CreateJS libraries are already present in the project (look for *js/easeljs-0.8.2.min.js*, and *js/preloadjs-0.6.2.min.js* in the Solution Explorer view).</span></span> <span data-ttu-id="c0aac-123">CreateJS について詳しくは、[CreateJS ホーム ページ](http://www.createjs.com)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c0aac-123">More information about CreateJS can be found at the [CreateJS home page](http://www.createjs.com).</span></span>


## <a name="getting-started"></a><span data-ttu-id="c0aac-124">はじめに</span><span class="sxs-lookup"><span data-stu-id="c0aac-124">Getting started</span></span>

<span data-ttu-id="c0aac-125">アプリの完全なソース コードは、[GitHub](https://github.com/Microsoft/Windows-appsample-get-started-js2d) にあります。</span><span class="sxs-lookup"><span data-stu-id="c0aac-125">The complete source code for the app is stored on [GitHub](https://github.com/Microsoft/Windows-appsample-get-started-js2d).</span></span>

<span data-ttu-id="c0aac-126">最も簡単に始める方法は、GitHub のページで、緑色の **[Clone or download]** (複製またはダウンロード) ボタンをクリックし、**[Open in Visual Studio]** (Visual Studio で開く) を選択することです。</span><span class="sxs-lookup"><span data-stu-id="c0aac-126">The simplest way to get started it to visit GitHub, click on the green **Clone or download** button, and select **Open in Visual Studio**.</span></span> 

![リポジトリを複製する](images/JS2D_2.png)

<span data-ttu-id="c0aac-128">[GitHub プロジェクト](https://msdn.microsoft.com/en-us/windows/uwp/get-started/get-uwp-app-samples)は、zip ファイルとしてダウンロードすることも、その他の標準的な方法で操作することもできます。</span><span class="sxs-lookup"><span data-stu-id="c0aac-128">You can also download the project as a zip file, or use any other standard ways to work with [GitHub projects](https://msdn.microsoft.com/en-us/windows/uwp/get-started/get-uwp-app-samples).</span></span>

<span data-ttu-id="c0aac-129">ソリューションを Visual Studio に読み込むと、次のようなファイルが表示されます。</span><span class="sxs-lookup"><span data-stu-id="c0aac-129">Once the solution has been loaded into Visual Studio, you'll see several files, including:</span></span>

* <span data-ttu-id="c0aac-130">Images/ - UWP アプリに必要なさまざまなアイコン、ゲームの SpriteSheet、その他のビットマップが含まれるフォルダー。</span><span class="sxs-lookup"><span data-stu-id="c0aac-130">Images/ - a folder containing the various icons required by UWP apps, as well as the game's SpriteSheet and some other bitmaps.</span></span>
* <span data-ttu-id="c0aac-131">js/ - JavaScript ファイルが含まれるフォルダー。</span><span class="sxs-lookup"><span data-stu-id="c0aac-131">js/ - a folder containing the JavaScript files.</span></span> <span data-ttu-id="c0aac-132">main.js ファイルはゲームで、その他のファイルは EaselJS と PreloadJS です。</span><span class="sxs-lookup"><span data-stu-id="c0aac-132">The main.js file is our game, the other files are EaselJS and PreloadJS.</span></span>
* <span data-ttu-id="c0aac-133">index.html - ゲームのグラフィックをホストする canvas オブジェクトが含まれる Web ページ。</span><span class="sxs-lookup"><span data-stu-id="c0aac-133">index.html - the webpage which contains the canvas object which hosts the game's graphics.</span></span>

<span data-ttu-id="c0aac-134">これでゲームを実行できます。</span><span class="sxs-lookup"><span data-stu-id="c0aac-134">Now you can run the game!</span></span>

<span data-ttu-id="c0aac-135">**F5** キーを押して、アプリの実行を開始します。</span><span class="sxs-lookup"><span data-stu-id="c0aac-135">Press **F5** to start the app running.</span></span> <span data-ttu-id="c0aac-136">ウィンドウが開き、牧歌的風景の中に、ありふれた恐竜が表示されます。</span><span class="sxs-lookup"><span data-stu-id="c0aac-136">You should see a window open, and our familar dinosaur standing in an idyllic (if sparse) landscape.</span></span> <span data-ttu-id="c0aac-137">それでは、アプリを調べていきましょう。重要な部分について説明し、他の機能についても、その都度明らかにします。</span><span class="sxs-lookup"><span data-stu-id="c0aac-137">We will now examine the app, explain some important parts, and unlock the rest of the features as we go.</span></span>

![ありふれた恐竜の背中に、ニンジャ キャットが乗っている](images/JS2D_3.png)

<span data-ttu-id="c0aac-139">**注:** うまくいかない場合は、</span><span class="sxs-lookup"><span data-stu-id="c0aac-139">**Note:** Something go wrong?</span></span> <span data-ttu-id="c0aac-140">Web サポートを含めて Visual Studio がインストールされていることを確認してください。</span><span class="sxs-lookup"><span data-stu-id="c0aac-140">Be sure you have installed Visual Studio with web support.</span></span> <span data-ttu-id="c0aac-141">これは、新しいプロジェクトを作成することで確認できます。JavaScript のサポートが含まれていない場合は、*[Microsoft Web Developer Tools]* ボックスをオンにして Visual Studio を再インストールする必要があります。</span><span class="sxs-lookup"><span data-stu-id="c0aac-141">You can check by creating a new project - if there is no support for JavaScript, you will need to re-install Visual Studio and check the *Microsoft Web Developer Tools* box.</span></span>

## <a name="walkthough"></a><span data-ttu-id="c0aac-142">チュートリアル</span><span class="sxs-lookup"><span data-stu-id="c0aac-142">Walkthough</span></span>

<span data-ttu-id="c0aac-143">F5 キーでゲームを開始した場合は、内部的に何が起こっているのか疑問に思うかもしれません。</span><span class="sxs-lookup"><span data-stu-id="c0aac-143">If you started the game with F5, you're probably wondering what is going on.</span></span> <span data-ttu-id="c0aac-144">その答えは、"ほとんど何も起こっていない" です。現時点では、コードの大部分がコメントアウトされています。</span><span class="sxs-lookup"><span data-stu-id="c0aac-144">And the answer is "not a lot", as a lot of the code is currently commented-out.</span></span> <span data-ttu-id="c0aac-145">今のところ、表示されるのは恐竜だけであり、Space キーを押しても何も起こりません。</span><span class="sxs-lookup"><span data-stu-id="c0aac-145">So far, all you'll see is the dinosaur, and a ineffectual plea to press Space.</span></span> 

### <a name="1-setting-the-stage"></a><span data-ttu-id="c0aac-146">1. ステージを設定する</span><span class="sxs-lookup"><span data-stu-id="c0aac-146">1. Setting the Stage</span></span>

<span data-ttu-id="c0aac-147">**index.html** を開いて内容を見ると、ほとんど空であることがわかります。</span><span class="sxs-lookup"><span data-stu-id="c0aac-147">If you open and examine **index.html**, you'll see it's almost empty.</span></span> <span data-ttu-id="c0aac-148">このファイルはアプリを含む既定の Web ページであり、重要な役割は次の 2 つだけです。</span><span class="sxs-lookup"><span data-stu-id="c0aac-148">This file is the default web page that contains our app, and it does only two important things.</span></span> <span data-ttu-id="c0aac-149">1 つ目は、CreateJS の **EaselJS** ライブラリおよび **PreloadJS**  ライブラリと **main.js** (このチュートリアルのソース コード ファイル) の JavaScript ソース コードが含まれていることです。</span><span class="sxs-lookup"><span data-stu-id="c0aac-149">First, it includes the JavaScript source code for the **EaselJS** and **PreloadJS** CreateJS libraries, and also **main.js** (our own source code file).</span></span>
<span data-ttu-id="c0aac-150">2 つ目は、すべてのグラフィックスを表示する場所として、&lt;canvas&gt; タグが定義されていることです。</span><span class="sxs-lookup"><span data-stu-id="c0aac-150">Second, it defines a &lt;canvas&gt; tag, which is where all our graphics are going to appear.</span></span> <span data-ttu-id="c0aac-151">&lt;canvas&gt; は、HTML5 ドキュメントの標準コンポーネントです。</span><span class="sxs-lookup"><span data-stu-id="c0aac-151">A &lt;canvas&gt; is a standard HTML5 document component.</span></span> <span data-ttu-id="c0aac-152">これには、**main.js** のコードから参照できるように gameCanvas という名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="c0aac-152">We give it a name (gameCanvas) so our code in **main.js** can reference it.</span></span> <span data-ttu-id="c0aac-153">JavaScript で独自のゲームを 1 から記述する場合は、**EaselJS** ファイルと **PreloadJS** ファイルをソリューションにコピーして、canvas オブジェクトを作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c0aac-153">By the way, if you are going to write your own JavaScript game from scratch, you too will need to copy the **EaselJS** and **PreloadJS** files into your solution, and then create a canvas object.</span></span>

<span data-ttu-id="c0aac-154">EaselJS では、*stage* と呼ばれる新しいオブジェクトが提供されます。</span><span class="sxs-lookup"><span data-stu-id="c0aac-154">EaselJS provides us with a new object called a *stage*.</span></span> <span data-ttu-id="c0aac-155">stage は canvas にリンクされ、画像とテキストを表示するために使用されます。</span><span class="sxs-lookup"><span data-stu-id="c0aac-155">The stage is linked to the canvas, and is used for displaying images and text.</span></span> <span data-ttu-id="c0aac-156">stage に表示するオブジェクトはすべて、まず stage の子として以下のように追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c0aac-156">Any object we want to be displayed on the stage must first be added as a child of the stage, like this:</span></span>

```
    stage.addChild(myObject);
```

<span data-ttu-id="c0aac-157">このコード行は、**main.js** に数回出てきます。</span><span class="sxs-lookup"><span data-stu-id="c0aac-157">You will see that line of code appear several times in **main.js**</span></span>

<span data-ttu-id="c0aac-158">それでは、**main.js** を開いてみましょう。</span><span class="sxs-lookup"><span data-stu-id="c0aac-158">Speaking of which, now is a good time to open **main.js**.</span></span>

### <a name="2-loading-the-bitmaps"></a><span data-ttu-id="c0aac-159">2. ビットマップを読み込む</span><span class="sxs-lookup"><span data-stu-id="c0aac-159">2. Loading the bitmaps</span></span>

<span data-ttu-id="c0aac-160">EaselJS では、数種類のグラフィック オブジェクトが提供されます。</span><span class="sxs-lookup"><span data-stu-id="c0aac-160">EaselJS provides us with several different types of graphical objects.</span></span> <span data-ttu-id="c0aac-161">単純な図形 (空に使用する青色の長方形など)、ビットマップ (後で追加する雲など)、テキスト オブジェクト、ストライプを作成できます。</span><span class="sxs-lookup"><span data-stu-id="c0aac-161">We can create simple shapes (such as the blue rectangle used for the sky), or bitmaps (such as the clouds we're about to add), text objects, and sprites.</span></span> <span data-ttu-id="c0aac-162">スプライトには、SpriteSheet (http://createjs.com/docs/easeljs/classes/SpriteSheet.html) を使用します。SpriteSheet は、複数の画像を含む単一ビットマップです。</span><span class="sxs-lookup"><span data-stu-id="c0aac-162">Sprites use a (SpriteSheet)[http://createjs.com/docs/easeljs/classes/SpriteSheet.html]: a single bitmap containing multiple images.</span></span> <span data-ttu-id="c0aac-163">たとえば、この SpriteSheet を使用して、共有アニメーションの複数フレームを格納することができます。</span><span class="sxs-lookup"><span data-stu-id="c0aac-163">For example, we use this SpriteSheet to store the different frame of dinosaur animation:</span></span>

![Walking Dino スプライト シート](images/JS2D_4.png)

<span data-ttu-id="c0aac-165">恐竜を歩かせるには、複数のフレームを定義し、アニメーション化する際の速度をこのコードで指定します。</span><span class="sxs-lookup"><span data-stu-id="c0aac-165">We make the dinosaur walk, by defining the different frames and how fast they should be animated in this code:</span></span>

```
    // Define the animated dino walk using a spritesheet of images,
    // and also a standing-still state, and a knocked-over state.
    var data = {
        images: [loader.getResult("dino")],
        frames: { width: 373, height: 256 },
        animations: {
            stand: 0,
            lying: { 
                frames: [0, 1],
                speed: 0.1
            },
            walk: {
                frames: [0, 1, 2, 3, 2, 1],
                speed: 0.4
            }
        }
    }

    var spriteSheet = new createjs.SpriteSheet(data);
    dino_walk = new createjs.Sprite(spriteSheet, "walk");
    dino_stand = new createjs.Sprite(spriteSheet, "stand");
    dino_lying = new createjs.Sprite(spriteSheet, "lying");

```

<span data-ttu-id="c0aac-166">ここで、小さくてふわふわした雲をいくつか、stage に追加します。</span><span class="sxs-lookup"><span data-stu-id="c0aac-166">Right now, we're going to add some little fluffy clouds to the stage.</span></span> <span data-ttu-id="c0aac-167">ゲームが実行されると、画面上に雲が漂います。</span><span class="sxs-lookup"><span data-stu-id="c0aac-167">Once the game is running, they'll drift across the screen.</span></span> <span data-ttu-id="c0aac-168">雲の画像は、既にソリューションの *images* フォルダーに含まれています。</span><span class="sxs-lookup"><span data-stu-id="c0aac-168">The image for the cloud is already in the solution, in the *images* folder.</span></span>

<span data-ttu-id="c0aac-169">**main.js** 内で、**init()** 関数を見つけます。</span><span class="sxs-lookup"><span data-stu-id="c0aac-169">Look through **main.js** until you find the **init()** function.</span></span> <span data-ttu-id="c0aac-170">この関数は、ゲームが開始されると呼び出されます。すべてのグラフィック オブジェクトのセットアップは、ここから開始します。</span><span class="sxs-lookup"><span data-stu-id="c0aac-170">This is called when the game starts, and it's where we begin to set up all our graphic objects.</span></span>

<span data-ttu-id="c0aac-171">以下のコードを見つけて、雲の画像を参照する行からコメント (\\) を削除します。</span><span class="sxs-lookup"><span data-stu-id="c0aac-171">Find the following code, and remove the comments (\\) from the line that references the cloud image.</span></span>

```
 manifest = [
        { src: "walkingDino-SpriteSheet.png", id: "dino" },
        { src: "barrel.png", id: "barrel" },
        { src: "fluffy-cloud-small.png", id: "cloud" },
    ];
```

<span data-ttu-id="c0aac-172">画像などのリソースを読み込むには JavaScript を少し補助する必要があるため、画像をプリロードするための [LoadQueue](http://www.createjs.com/docs/preloadjs/classes/LoadQueue.html) という CreateJS ライブラリの機能を使用します。</span><span class="sxs-lookup"><span data-stu-id="c0aac-172">JavaScript needs a little help when it comes to loading resources such as images, and so we're using a feature of the CreateJS library that can preload images, called a [LoadQueue](http://www.createjs.com/docs/preloadjs/classes/LoadQueue.html).</span></span> <span data-ttu-id="c0aac-173">画像の読み込みにどの程度の時間がかかるか予測できないため、LoadQueue を使用して処理します。</span><span class="sxs-lookup"><span data-stu-id="c0aac-173">We're can't be sure how long it will take the images to load, so we use the LoadQueue to take care of it.</span></span> <span data-ttu-id="c0aac-174">これにより、画像の準備ができると、キューによる通知を受けることができます。</span><span class="sxs-lookup"><span data-stu-id="c0aac-174">Once the images are available, the queue will tell us they are ready.</span></span> <span data-ttu-id="c0aac-175">そのためにはまず、すべての画像をリストした新しいオブジェクトを作成してから、LoadQueue オブジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="c0aac-175">In order to do that, we first create a new object that lists all our images, and then we create a LoadQueue object.</span></span> <span data-ttu-id="c0aac-176">下のコードに示すように、このオブジェクトは、すべての準備が整ったら **loadingComplete()** という関数が呼び出されるようにセットアップされています。</span><span class="sxs-lookup"><span data-stu-id="c0aac-176">You'll see in the code below how it is set-up to call a function called **loadingComplete()** when everything is ready.</span></span>

```
    // Now we create a special queue, and finally a handler that is
    // called when they are loaded. The queue object is provided by preloadjs.

    loader = new createjs.LoadQueue(false);
    loader.addEventListener("complete", loadingComplete);
    loader.loadManifest(manifest, true, "../images/");
```    

<span data-ttu-id="c0aac-177">関数 **loadingComplete()** が呼び出されると、画像が読み込まれ、使用可能な状態になります。</span><span class="sxs-lookup"><span data-stu-id="c0aac-177">When the function **loadingComplete()** is called, the images are loaded and ready to use.</span></span> <span data-ttu-id="c0aac-178">コメントアウトされていたセクションでは雲を作成しますが、そのためのビットマップが使用できます。</span><span class="sxs-lookup"><span data-stu-id="c0aac-178">You'll see a commented-out section that creates the clouds, now their bitmap is available.</span></span> <span data-ttu-id="c0aac-179">コメントを削除すると、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="c0aac-179">Remove the comments, so it looks like this:</span></span>

```
    // Create some clouds to drift by..
    for (var i = 0; i < 3; i++) {
        cloud[i] = new createjs.Bitmap(loader.getResult("cloud"));
        cloud[i].x = Math.random()*1024; // Random start location
        cloud[i].y = 64 + i * 48;
        stage.addChild(cloud[i]);
    }
```
<span data-ttu-id="c0aac-180">このコードでは、プリロードされた画像をそれぞれ使用する cloud オブジェクトを 3 つ作成し、これらの位置を定義して、stage に追加しています。</span><span class="sxs-lookup"><span data-stu-id="c0aac-180">This code creates three cloud objects each using our pre-loaded image, defines their location, and then adds them to the stage.</span></span>

<span data-ttu-id="c0aac-181">アプリをもう一度実行 (press F5 を押す) すると、雲が表示されます。</span><span class="sxs-lookup"><span data-stu-id="c0aac-181">Run the app again (press F5) and you'll see our clouds have appeared.</span></span>

### <a name="3-moving-the-clouds"></a><span data-ttu-id="c0aac-182">3. 雲を動かす</span><span class="sxs-lookup"><span data-stu-id="c0aac-182">3. Moving the clouds</span></span>

<span data-ttu-id="c0aac-183">次は、雲が動くようにします。</span><span class="sxs-lookup"><span data-stu-id="c0aac-183">Now we're going to make the clouds move.</span></span> <span data-ttu-id="c0aac-184">雲を (または、あらゆる物を) を動かすための秘策は、1 秒に何度も呼び出される [ticker](http://www.createjs.com/docs/easeljs/classes/Ticker.html) 関数をセットアップすることです。</span><span class="sxs-lookup"><span data-stu-id="c0aac-184">The secret to moving clouds - and moving anything, in fact - is to set-up a [ticker](http://www.createjs.com/docs/easeljs/classes/Ticker.html) function that is repeatedly called multiple times a second.</span></span> <span data-ttu-id="c0aac-185">この関数が呼び出されるたびに、少し位置を変えてグラフィックスが再描画されます。</span><span class="sxs-lookup"><span data-stu-id="c0aac-185">Every time this function is called, it redraws the graphics in a slightly different place.</span></span>

<p data-height="500" data-theme-id="23761" data-slug-hash="vxZVRK" data-default-tab="result" data-user="MicrosoftEdgeDocumentation" data-embed-version="2" data-pen-title="CreateJS - Animating clouds" data-preview="true" data-editable="true" class="codepen"><span data-ttu-id="c0aac-186"><a href="http://codepen.io">CodePen</a> で、Microsoft Edge Docs (<a href="http://codepen.io/MicrosoftEdgeDocumentation">@MicrosoftEdgeDocumentation</a>) による Pen (<a href="https://codepen.io/MicrosoftEdgeDocumentation/pen/vxZVRK/">CreateJS - Animating clouds</a>) をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c0aac-186">See the Pen <a href="https://codepen.io/MicrosoftEdgeDocumentation/pen/vxZVRK/">CreateJS - Animating clouds</a> by Microsoft Edge Docs (<a href="http://codepen.io/MicrosoftEdgeDocumentation">@MicrosoftEdgeDocumentation</a>) on <a href="http://codepen.io">CodePen</a>.</span></span></p>
<script async src="https://production-assets.codepen.io/assets/embed/ei.js"></script>
 
<span data-ttu-id="c0aac-187">そのためのコードは既に **main.js** に含まれ、CreateJS ライブラリの EaselJS から提供されています。</span><span class="sxs-lookup"><span data-stu-id="c0aac-187">The code to do that is already in the **main.js** file, provided by the CreateJS library, EaselJS.</span></span> <span data-ttu-id="c0aac-188">次のような内容です。</span><span class="sxs-lookup"><span data-stu-id="c0aac-188">It looks like this:</span></span>

```
    // Set up the game loop and keyboard handler.
    // The keyword 'tick' is required to automatically animated the sprite.
    createjs.Ticker.timingMode = createjs.Ticker.RAF;
    createjs.Ticker.addEventListener("tick", gameLoop);
```

<span data-ttu-id="c0aac-189">このコードでは、**gameLoop()** という関数が 1 秒あたり 30 ～ 60 回呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="c0aac-189">This code will call a function called **gameLoop()** between 30 and 60 frames a second.</span></span> <span data-ttu-id="c0aac-190">正確な速度は、使用するコンピューターの速度によって異なります。</span><span class="sxs-lookup"><span data-stu-id="c0aac-190">The exact speed depends on the speed of your computer.</span></span>

<span data-ttu-id="c0aac-191">**gameLoop()** 関数を探すと、終わりの方に **animateClouds()** という関数が記述されています。</span><span class="sxs-lookup"><span data-stu-id="c0aac-191">Look for the **gameLoop()** function, and down towards the end you'll see a function called **animateClouds()**.</span></span> <span data-ttu-id="c0aac-192">編集してコメント アウトを解除してください。</span><span class="sxs-lookup"><span data-stu-id="c0aac-192">Edit it so that it is not commented out.</span></span>

```
    // Move clouds
    animateClouds();
```

<span data-ttu-id="c0aac-193">この関数の定義を見ると、それぞれの雲を順番に表示し、その際に X 座標を変化させていることがわかります。</span><span class="sxs-lookup"><span data-stu-id="c0aac-193">If you look at the defintion of this function, you'll see how it takes each cloud in turn, and changes its x co-ordinate.</span></span> <span data-ttu-id="c0aac-194">X 座標が画面の左端に到達すると、右端にリセットされます。</span><span class="sxs-lookup"><span data-stu-id="c0aac-194">If the x-ordinate is off the side of screen, it is reset to the far right.</span></span> <span data-ttu-id="c0aac-195">また、それぞれの雲は、やや異なる速度で動きます。</span><span class="sxs-lookup"><span data-stu-id="c0aac-195">Each cloud also moves at a slightly different speed.</span></span>

```
function animate_clouds()
{
    // Move the cloud sprites across the sky. If they get to the left edge, 
    // move them over to the right.

    for (var i = 0; i < 3; i++) {    
        cloud[i].x = cloud[i].x - (i+1);
        if (cloud[i].x < -128)
            cloud[i].x = width + 128;
    }
}
```

<span data-ttu-id="c0aac-196">ここでアプリを実行すると、雲が漂い始めます。</span><span class="sxs-lookup"><span data-stu-id="c0aac-196">If you run the app now, you'll see that the clouds have started drifting.</span></span> <span data-ttu-id="c0aac-197">ついに、動かすことができました!</span><span class="sxs-lookup"><span data-stu-id="c0aac-197">Finally we have motion!</span></span>

### <a name="4-adding-keyboard-and-mouse-input"></a><span data-ttu-id="c0aac-198">4. キーボード/マウス入力を追加する</span><span class="sxs-lookup"><span data-stu-id="c0aac-198">4. Adding keyboard and mouse input</span></span>

<span data-ttu-id="c0aac-199">ユーザーが操作できないゲームは、ゲームとは言えません。</span><span class="sxs-lookup"><span data-stu-id="c0aac-199">A game that you can't interact with isn't a game.</span></span> <span data-ttu-id="c0aac-200">そこで、ユーザーがキーボードまたはマウスを使って何かできるようにしてみましょう。</span><span class="sxs-lookup"><span data-stu-id="c0aac-200">So let's allow the player to use the keyboard or the mouse to do something.</span></span> <span data-ttu-id="c0aac-201">**loadingComplete()** 関数に戻ると、次のようなコードがあります。</span><span class="sxs-lookup"><span data-stu-id="c0aac-201">Back in the **loadingComplete()** function, you'll see the following.</span></span> <span data-ttu-id="c0aac-202">コメントを削除してください。</span><span class="sxs-lookup"><span data-stu-id="c0aac-202">Remove the comments.</span></span>

```
    // This code will call the method 'keyboardPressed' is the user presses a key.
    this.document.onkeydown = keyboardPressed;

    // Add support for mouse clicks
    stage.on("stagemousedown", mouseClicked);
```

<span data-ttu-id="c0aac-203">これで、プレイヤーがキーを押すかマウスをクリックしたときに呼び出される 2 つの関数を使用できます。</span><span class="sxs-lookup"><span data-stu-id="c0aac-203">We now have two functions being called whenever the player hits a key or clicks the mouse.</span></span> <span data-ttu-id="c0aac-204">どちらのイベントでも **userDidSomething()** が呼び出されます。この関数では gamestate 変数を調べて、今ゲームで何が行われているかを判断し、その結果、次に何が必要かを決定します。</span><span class="sxs-lookup"><span data-stu-id="c0aac-204">Both event will call **userDidSomething()**, a function which looks at the gamestate variable to decide what the game is currently doing, and what needs to happen next as a result.</span></span>

<span data-ttu-id="c0aac-205">Gamestate は、ゲームで一般的に使用される設計パターンです。</span><span class="sxs-lookup"><span data-stu-id="c0aac-205">Gamestate is a common design pattern used in games.</span></span> <span data-ttu-id="c0aac-206">発生する動作はすべて、ticker タイマーによって呼び出される **gameLoop()** 関数の中で実行されます。</span><span class="sxs-lookup"><span data-stu-id="c0aac-206">Everything that happens, happens in the **gameLoop()** function called by the ticker timer.</span></span> <span data-ttu-id="c0aac-207">gameLoop() では、変数を使用して、ゲームがプレイ中か、"ゲーム オーバー状態"、"プレイ準備完了状態、または作者が定義した他の状態であるかを追跡します。</span><span class="sxs-lookup"><span data-stu-id="c0aac-207">The gameLoop() keeps track of whether the game is playing, or in a "game over state", or a "ready-to-play state", or any other states defined by the author, using a variable.</span></span> <span data-ttu-id="c0aac-208">この状態の変数は、switch ステートメント内でテストされ、その結果によって他のどの関数を呼び出すかが決まります。</span><span class="sxs-lookup"><span data-stu-id="c0aac-208">This state variable is tested in a switch statement, and that defines what other functions are called.</span></span> <span data-ttu-id="c0aac-209">状態が "playing" に設定されている場合は、恐竜にジャンプさせ、樽を動かす関数が呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="c0aac-209">So if the state is set to "playing", the functions to make the dinosaur jump and make the barrels move will be called.</span></span> <span data-ttu-id="c0aac-210">一方、何らかの手段で恐竜が倒されると、gamestate 変数が "ゲーム オーバー状態" に設定され、"Game over!" </span><span class="sxs-lookup"><span data-stu-id="c0aac-210">If the dinosaur is killed by something, the gamestate variable will be set to "game over state", and the "Game over!"</span></span> <span data-ttu-id="c0aac-211">というメッセージが表示されます。</span><span class="sxs-lookup"><span data-stu-id="c0aac-211">message will be displayed instead.</span></span> <span data-ttu-id="c0aac-212">ゲームの設計パターンに興味がある場合は、「[Game Programming Patterns](http://gameprogrammingpatterns.com/)」(ゲーム プログラミングのパターン) という書籍が役立ちます。</span><span class="sxs-lookup"><span data-stu-id="c0aac-212">If you are interested in game design patterns, the book [Game Programming Patterns](http://gameprogrammingpatterns.com/) is very helpful.</span></span>

<span data-ttu-id="c0aac-213">アプリをもう一度実行すると、ついにプレイを開始できます。</span><span class="sxs-lookup"><span data-stu-id="c0aac-213">Try running the app again, and finally you'll be able to start playing.</span></span> <span data-ttu-id="c0aac-214">Space キーを押す (または、マウスをクリックするか画面をタップする) と、ゲームが始まります。</span><span class="sxs-lookup"><span data-stu-id="c0aac-214">Press space (or click the mouse, or tap the screen) to start things happening.</span></span> 

<span data-ttu-id="c0aac-215">樽が、こちらに向かって転がってきます。適切なタイミングで Space キーを押すかもう一度クリックすると、恐竜がジャンプします。</span><span class="sxs-lookup"><span data-stu-id="c0aac-215">You'll see a barrel come rolling towards you: press space or click again at just the right time, and the dinosaur will leap.</span></span> <span data-ttu-id="c0aac-216">タイミングを間違えると、ゲーム オーバーとなります。</span><span class="sxs-lookup"><span data-stu-id="c0aac-216">Time it wrong, and your game is over.</span></span>

<span data-ttu-id="c0aac-217">樽は、雲と同じ方法でアニメーション化されます (ただしこちらは毎回速度が速くなります)。恐竜と樽については、衝突しないように位置を確認します。</span><span class="sxs-lookup"><span data-stu-id="c0aac-217">The barrel is animated in the same way as the clouds (although it gets faster each time), and we check the position of the dinosaur and the barrel to make sure they haven't collided:</span></span>

```
 // Very simple check for collision between dino and barrel
                if ((barrel.x > 220 && barrel.x < 380)
                    &&
                    (!jumping))
                {
                    barrel.x = 380;
                    GameState = GameStateEnum.GameOver;
                }
```

<span data-ttu-id="c0aac-218">恐竜がジャンプ中ではなく、樽が近くにある場合は、状態変数が *GameOver* という状態に変更されます。</span><span class="sxs-lookup"><span data-stu-id="c0aac-218">If the dinosaur isn't jumping and the barrel is nearby, the code changes the state varaible to the state we've called *GameOver*.</span></span> <span data-ttu-id="c0aac-219">ご想像どおり、*GameOver* 状態になるとゲームが停止します。</span><span class="sxs-lookup"><span data-stu-id="c0aac-219">As you can imagine, *GameOver* stops the game.</span></span>

<span data-ttu-id="c0aac-220">また、ゲームのメイン メカニズムも終了します。</span><span class="sxs-lookup"><span data-stu-id="c0aac-220">And so the main mechanics of our game are complete.</span></span>

### <a name="5-resizing-support"></a><span data-ttu-id="c0aac-221">5. サポートのサイズを変更する</span><span class="sxs-lookup"><span data-stu-id="c0aac-221">5. Resizing support</span></span>

<span data-ttu-id="c0aac-222">これで、ほとんどの作業が終わりました。</span><span class="sxs-lookup"><span data-stu-id="c0aac-222">We're almost done here!</span></span> <span data-ttu-id="c0aac-223">ただし、作業を終える前に対処すべき問題がもう 1 つあります。</span><span class="sxs-lookup"><span data-stu-id="c0aac-223">But before we stop, there is one annoying problem to take care of first.</span></span> <span data-ttu-id="c0aac-224">ゲームの実行中、ウィンドウのサイズを変更してみてください。</span><span class="sxs-lookup"><span data-stu-id="c0aac-224">When the game is running, try resizing the window.</span></span> <span data-ttu-id="c0aac-225">オブジェクトの位置が乱れ、ゲームは直ちに混乱状態になります。</span><span class="sxs-lookup"><span data-stu-id="c0aac-225">You'll see that the game quickly becomes very messed-up, as objects are no longer where they should be.</span></span> <span data-ttu-id="c0aac-226">この問題は、ウィンドウのサイズ変更イベント用ハンドラーを作成することで処理できます。このイベントは、プレイヤーがウィンドウのサイズを変更したときや、デバイスが回転されて横から縦になったときに発生します。</span><span class="sxs-lookup"><span data-stu-id="c0aac-226">We can take care of that by creating a handler for the window resizing event generated when the player resizes the window, or when the device is rotated from landscape to portrait.</span></span>

<span data-ttu-id="c0aac-227">ハンドラーのコードは既に存在します (UWP アプリの起動時にはウィンドウのサイズがどうなるかわからないため、既定のウィンドウ サイズを使用できるかどうかを確認するために、ゲームが初めて実行されると、このコードが呼び出されます)。</span><span class="sxs-lookup"><span data-stu-id="c0aac-227">The code to do this is already present (in fact, we call it when the game first starts, to make sure the default window size works, because when a UWP app is launched, you can't be certain what size the window will be).</span></span>

<span data-ttu-id="c0aac-228">画面サイズのイベントが発生したときに関数が呼び出されるように、以下の行のコメントを解除します。</span><span class="sxs-lookup"><span data-stu-id="c0aac-228">Just uncomment this line to call the function when the screen size event is fired:</span></span>

```
    // This code makes the app call the method 'resizeGameWindow' if the user resizes the current window.
     window.addEventListener('resize', resizeGameWindow);
```

<span data-ttu-id="c0aac-229">アプリをもう一度実行すると、ウィンドウのサイズを変更したときの結果が改善されます。</span><span class="sxs-lookup"><span data-stu-id="c0aac-229">If you run the app again, you should now be able to resize the window and get better results.</span></span>

## <a name="publishing-to-the-windows-store"></a><span data-ttu-id="c0aac-230">Windows ストアへの公開</span><span class="sxs-lookup"><span data-stu-id="c0aac-230">Publishing to the Windows Store</span></span>

<span data-ttu-id="c0aac-231">UWP アプリを作成できたため、(もう少し改善すれば) Windows ストアに公開することもできます。</span><span class="sxs-lookup"><span data-stu-id="c0aac-231">Now you have a UWP app, it is possible to publish it to the Windows Store (assuming you have improved it first!)</span></span> 

<span data-ttu-id="c0aac-232">このプロセスにはいくつかの手順が必要になります。</span><span class="sxs-lookup"><span data-stu-id="c0aac-232">There are a few steps to the process.</span></span>

1. <span data-ttu-id="c0aac-233">Windows 開発者として[登録](https://developer.microsoft.com/en-us/store/register)する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c0aac-233">You must be [registered](https://developer.microsoft.com/en-us/store/register) as a Windows Developer.</span></span>
2. <span data-ttu-id="c0aac-234">アプリの申請[チェックリスト](https://msdn.microsoft.com/windows/uwp/publish/app-submissions)を使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c0aac-234">You must use the app submission [checklist](https://msdn.microsoft.com/windows/uwp/publish/app-submissions).</span></span>
3. <span data-ttu-id="c0aac-235">[認定](https://msdn.microsoft.com/windows/uwp/publish/the-app-certification-process)を受けるために、アプリを提出する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c0aac-235">The app must be submitted for [certification](https://msdn.microsoft.com/windows/uwp/publish/the-app-certification-process).</span></span>

<span data-ttu-id="c0aac-236">詳しくは、「[Windows ストア アプリの公開](https://developer.microsoft.com/en-us/store/publish-apps)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c0aac-236">For more details, see [Publishing your Windows Store app](https://developer.microsoft.com/en-us/store/publish-apps).</span></span>

## <a name="suggestions-for-other-features"></a><span data-ttu-id="c0aac-237">その他のおすすめ機能</span><span class="sxs-lookup"><span data-stu-id="c0aac-237">Suggestions for other features.</span></span>

<span data-ttu-id="c0aac-238">次にすること</span><span class="sxs-lookup"><span data-stu-id="c0aac-238">What next?</span></span> <span data-ttu-id="c0aac-239">アプリの質を高めるために追加をお勧めする機能を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="c0aac-239">Here are a few suggestions for features to add to your (soon to be) award-winning app.</span></span>

1. <span data-ttu-id="c0aac-240">音響効果。</span><span class="sxs-lookup"><span data-stu-id="c0aac-240">Sound effects.</span></span> <span data-ttu-id="c0aac-241">CreateJS ライブラリには、[SoundJS](http://www.createjs.com/soundjs) というライブラリによるサウンドのサポートが含まれています。</span><span class="sxs-lookup"><span data-stu-id="c0aac-241">The CreateJS library includes support for sound, with a library called [SoundJS](http://www.createjs.com/soundjs).</span></span>
2. <span data-ttu-id="c0aac-242">ゲームパッドのサポート。</span><span class="sxs-lookup"><span data-stu-id="c0aac-242">Gamepad support.</span></span> <span data-ttu-id="c0aac-243">[利用できる API](https://gamedevelopment.tutsplus.com/tutorials/using-the-html5-gamepad-api-to-add-controller-support-to-browser-games--cms-21345) があります。</span><span class="sxs-lookup"><span data-stu-id="c0aac-243">There is an [API available](https://gamedevelopment.tutsplus.com/tutorials/using-the-html5-gamepad-api-to-add-controller-support-to-browser-games--cms-21345).</span></span>
3. <span data-ttu-id="c0aac-244">もっともっとすばらしいゲームにしてください。</span><span class="sxs-lookup"><span data-stu-id="c0aac-244">Make it a much, much better game!</span></span> <span data-ttu-id="c0aac-245">この部分はあなた次第ですが、オンラインで利用可能なリソースも多数あります。</span><span class="sxs-lookup"><span data-stu-id="c0aac-245">That part is up to you, but there are lots of resources available online.</span></span> 

## <a name="other-links"></a><span data-ttu-id="c0aac-246">その他のリンク</span><span class="sxs-lookup"><span data-stu-id="c0aac-246">Other links</span></span>

* [<span data-ttu-id="c0aac-247">JavaScript で単純な Windows ゲームを作成する</span><span class="sxs-lookup"><span data-stu-id="c0aac-247">Make a simple Windows game with JavaScript</span></span>](https://www.sitepoint.com/creating-a-simple-windows-8-game-with-javascript-game-basics-createjseaseljs/)
* [<span data-ttu-id="c0aac-248">HTML/JS ゲーム エンジンを選択する</span><span class="sxs-lookup"><span data-stu-id="c0aac-248">Picking an HTML/JS game engine</span></span>](https://html5gameengine.com/)
* [<span data-ttu-id="c0aac-249">JS ベースのゲームに CreateJS を使用する</span><span class="sxs-lookup"><span data-stu-id="c0aac-249">Using CreateJS in your JS based game</span></span>](https://blogs.msdn.microsoft.com/cbowen/2012/09/19/using-createjs-in-your-javascript-based-windows-8-game/)
* [<span data-ttu-id="c0aac-250">LinkedIn Learning のゲーム開発コース</span><span class="sxs-lookup"><span data-stu-id="c0aac-250">Game development courses on LinkedIn Learning</span></span>](https://www.linkedin.com/learning/topics/game-development)
