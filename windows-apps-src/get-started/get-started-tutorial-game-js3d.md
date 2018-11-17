---
title: 入門チュートリアル - 3D UWP ゲーム (JavaScript)
description: JavaScript と three.js で記述された Microsoft Store 向けの UWP ゲーム
author: abbycar
ms.author: abigailc
ms.date: 03/06/2017
ms.topic: article
keywords: Windows 10, UWP
ms.assetid: fb4249b2-f93c-4993-9e4d-57a62c04be66
ms.localizationpriority: medium
ms.openlocfilehash: 0183e19135758f73dfea9b63535437ff9b66011a
ms.sourcegitcommit: 3257416aebb5a7b1515e107866806f8bd57845a8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/17/2018
ms.locfileid: "7168707"
---
# <a name="creating-a-3d-javascript-game-using-threejs"></a><span data-ttu-id="c7529-104">hree.js を使用して 3D JavaScript ゲームを作成する</span><span class="sxs-lookup"><span data-stu-id="c7529-104">Creating a 3D JavaScript game using three.js</span></span>

## <a name="introduction"></a><span data-ttu-id="c7529-105">はじめに</span><span class="sxs-lookup"><span data-stu-id="c7529-105">Introduction</span></span>

<span data-ttu-id="c7529-106">Web 開発者や JavaScript 作者にとって、JavaScript で UWP アプリを開発することは、作成したアプリを世界中に向けて公開するための簡単な方法です。</span><span class="sxs-lookup"><span data-stu-id="c7529-106">For web developers or JavaScript tinkerers, developing UWP apps with JavaScript is an easy way in to getting your apps out to the world.</span></span> <span data-ttu-id="c7529-107">C# や C++ のような言語を学習する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="c7529-107">No need to worry about learning a language like C# or C++!</span></span>

<span data-ttu-id="c7529-108">このサンプルでは、**three.js** ライブラリを活用します。</span><span class="sxs-lookup"><span data-stu-id="c7529-108">For this sample, we’re going to be taking advantage of the **three.js** library.</span></span> <span data-ttu-id="c7529-109">このライブラリは、WebGL から構築されています。WebGL は、Web ブラウザー用に 2D/3D のグラフィックスをレンダリングするために使用する API です。</span><span class="sxs-lookup"><span data-stu-id="c7529-109">This library builds off of WebGL, an API that's used for rendering 2D and 3D graphics for web browsers.</span></span> <span data-ttu-id="c7529-110">**three.js** は、この複雑な API を単純化したもので、これを使用すると 3D 開発がずっと容易になります。</span><span class="sxs-lookup"><span data-stu-id="c7529-110">**three.js** takes this complicated API and simplifies it, making 3D development much easier.</span></span> 


<span data-ttu-id="c7529-111">先に進む前に、これから作成するアプリを見ておきましょう。</span><span class="sxs-lookup"><span data-stu-id="c7529-111">Want to get a glimpse of the app we'll be making before reading further?</span></span> <span data-ttu-id="c7529-112">CodePen で確認してください。</span><span class="sxs-lookup"><span data-stu-id="c7529-112">Check it out on CodePen!</span></span>

<iframe height='300' scrolling='no' title='<span data-ttu-id="c7529-113">Game final</span><span class="sxs-lookup"><span data-stu-id="c7529-113">Dino game final</span></span>' src='//codepen.io/MicrosoftEdgeDocumentation/embed/preview/NpKejy/?height=300&theme-id=23761&default-tab=result&embed-version=2&editable=true' frameborder='no' allowtransparency='true' allowfullscreen='true' style='width: 100%;'><span data-ttu-id="c7529-114"><a href='https://codepen.io'>CodePen</a> で、Microsoft Edge Docs (<a href='https://codepen.io/MicrosoftEdgeDocumentation'>@MicrosoftEdgeDocumentation</a>) による Pen (<a href='https://codepen.io/MicrosoftEdgeDocumentation/pen/NpKejy/'>Dino game final</a>) をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c7529-114">See the Pen <a href='https://codepen.io/MicrosoftEdgeDocumentation/pen/NpKejy/'>Dino game final</a> by Microsoft Edge Docs (<a href='https://codepen.io/MicrosoftEdgeDocumentation'>@MicrosoftEdgeDocumentation</a>) on <a href='https://codepen.io'>CodePen</a>.</span></span>
</iframe>

> [!NOTE] 
> <span data-ttu-id="c7529-115">ない、完全なゲームです。JavaScript やサード パーティ製ライブラリを使用して、アプリに準備するため、Microsoft Store に公開する方法を示すために設計されています。</span><span class="sxs-lookup"><span data-stu-id="c7529-115">This is a not a complete game; it is designed to demonstrate using JavaScript and a third-party library to make an app ready to publish to the Microsoft Store.</span></span>


## <a name="requirements"></a><span data-ttu-id="c7529-116">要件</span><span class="sxs-lookup"><span data-stu-id="c7529-116">Requirements</span></span>

<span data-ttu-id="c7529-117">このプロジェクトを操作するには、以下が必要になります。</span><span class="sxs-lookup"><span data-stu-id="c7529-117">To play with this project, you'll need the following:</span></span>
-   <span data-ttu-id="c7529-118">現在のバージョンの Windows 10 を実行する Windows コンピューター (または仮想マシン)。</span><span class="sxs-lookup"><span data-stu-id="c7529-118">A Windows computer (or a virtual machine) running the current version of Windows 10.</span></span>
-   <span data-ttu-id="c7529-119">Visual Studio。</span><span class="sxs-lookup"><span data-stu-id="c7529-119">A copy of Visual Studio.</span></span> <span data-ttu-id="c7529-120">無料の Visual Studio Community Edition は、[Visual Studio ホームページ](http://visualstudio.com/)からダウンロードできます。</span><span class="sxs-lookup"><span data-stu-id="c7529-120">The free Visual Studio Community Edition can be downloaded from the [Visual Studio homepage](http://visualstudio.com/).</span></span>
<span data-ttu-id="c7529-121">このプロジェクトでは、**three.js** という JavaScript ライブラリを使用します。</span><span class="sxs-lookup"><span data-stu-id="c7529-121">This project makes use of the **three.js** JavaScript library.</span></span> <span data-ttu-id="c7529-122">**three.js** は、MIT ライセンスの下でリリースされています。</span><span class="sxs-lookup"><span data-stu-id="c7529-122">**three.js** is released under the MIT license.</span></span> <span data-ttu-id="c7529-123">このライブラリは、プロジェクト内に既に存在します (ソリューション エクスプローラー ビューで `js/libs` を探してください)。</span><span class="sxs-lookup"><span data-stu-id="c7529-123">This library is already present in the project (look for `js/libs` in the Solution Explorer view).</span></span> <span data-ttu-id="c7529-124">このライブラリについて詳しくは、[**three.js**](https://threejs.org/) のホーム ページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c7529-124">More information about this library can be found at the [**three.js**](https://threejs.org/) home page.</span></span>

## <a name="getting-started"></a><span data-ttu-id="c7529-125">はじめに</span><span class="sxs-lookup"><span data-stu-id="c7529-125">Getting started</span></span>

<span data-ttu-id="c7529-126">アプリの完全なソース コードは、[GitHub](https://github.com/Microsoft/Windows-appsample-get-started-js3d) にあります。</span><span class="sxs-lookup"><span data-stu-id="c7529-126">The complete source code for the app is stored on [GitHub](https://github.com/Microsoft/Windows-appsample-get-started-js3d).</span></span>

<span data-ttu-id="c7529-127">最も簡単に始める方法は、GitHub のページで、緑色の [Clone or download] (複製またはダウンロード) ボタンをクリックし、[Open in Visual Studio] (Visual Studio で開く) を選択することです。</span><span class="sxs-lookup"><span data-stu-id="c7529-127">The simplest way to get started is to visit GitHub, click on the green Clone or download button, and select Open in Visual Studio.</span></span> 

![[Clone or download] (複製またはダウンロード) ボタン](images/3dclone.png)

<span data-ttu-id="c7529-129">プロジェクトを複製しない場合は、zip ファイルとしてダウンロードすることもできます。</span><span class="sxs-lookup"><span data-stu-id="c7529-129">If you don't want to clone the project, you can download it as a zip file.</span></span>
<span data-ttu-id="c7529-130">ソリューションを Visual Studio に読み込むと、次のようなファイルが表示されます。</span><span class="sxs-lookup"><span data-stu-id="c7529-130">Once the solution has been loaded into Visual Studio, you'll see several files, including:</span></span>
-   <span data-ttu-id="c7529-131">Images/ - UWP アプリに必要なさまざまなアイコンが含まれるフォルダー。</span><span class="sxs-lookup"><span data-stu-id="c7529-131">Images/ - a folder containing the various icons required by UWP apps.</span></span>
- <span data-ttu-id="c7529-132">css/ - 使用する CSS が含まれるフォルダー。</span><span class="sxs-lookup"><span data-stu-id="c7529-132">css/ - a folder containing the CSS to be used.</span></span>
-   <span data-ttu-id="c7529-133">js/ - JavaScript ファイルが含まれるフォルダー。</span><span class="sxs-lookup"><span data-stu-id="c7529-133">js/ - a folder containing the JavaScript files.</span></span> <span data-ttu-id="c7529-134">main.js ファイルはゲームで、他のファイルはサード パーティ製ライブラリです。</span><span class="sxs-lookup"><span data-stu-id="c7529-134">The main.js file is our game while the other files are the third-party libraries.</span></span>
-   <span data-ttu-id="c7529-135">models/ - 3D モデルが含まれるフォルダー。</span><span class="sxs-lookup"><span data-stu-id="c7529-135">models/ - a folder containing the 3D models.</span></span> <span data-ttu-id="c7529-136">このゲームでは、恐竜を 1 匹のみ使用します。</span><span class="sxs-lookup"><span data-stu-id="c7529-136">For this game, we only have one for the dinosaur.</span></span>
-   <span data-ttu-id="c7529-137">Index.html - ゲームのレンダラーをホストする Web ページです。</span><span class="sxs-lookup"><span data-stu-id="c7529-137">index.html - the webpage that hosts the game's renderer.</span></span>

<span data-ttu-id="c7529-138">これでゲームを実行できます。</span><span class="sxs-lookup"><span data-stu-id="c7529-138">Now you can run the game!</span></span>

<span data-ttu-id="c7529-139">F5 キーを押してアプリを起動します。</span><span class="sxs-lookup"><span data-stu-id="c7529-139">Press F5 to start the app.</span></span> <span data-ttu-id="c7529-140">ウィンドウが開き、画面上をクリックするよう求められます。</span><span class="sxs-lookup"><span data-stu-id="c7529-140">You should see a window open, prompting you to click on the screen.</span></span> <span data-ttu-id="c7529-141">また、背景で動き回る恐竜も見えます。</span><span class="sxs-lookup"><span data-stu-id="c7529-141">You’ll also see a dinosaur moving around in the background.</span></span> <span data-ttu-id="c7529-142">ゲームを閉じて、アプリと主要なコンポーネントを調べましょう。</span><span class="sxs-lookup"><span data-stu-id="c7529-142">Go ahead and close out of the game and we’ll begin examining the app and its key components.</span></span>

> [!NOTE] 
> <span data-ttu-id="c7529-143">うまくいかない場合は、</span><span class="sxs-lookup"><span data-stu-id="c7529-143">Something go wrong?</span></span> <span data-ttu-id="c7529-144">Web サポートを含めて Visual Studio がインストールされていることを確認してください。</span><span class="sxs-lookup"><span data-stu-id="c7529-144">Be sure you have installed Visual Studio with web support.</span></span> <span data-ttu-id="c7529-145">これは、新しいプロジェクトを作成することで確認できます。JavaScript のサポートが含まれていない場合は、[Microsoft Web Developer Tools] ボックスをオンにして Visual Studio を再インストールする必要があります。</span><span class="sxs-lookup"><span data-stu-id="c7529-145">You can check by creating a new project - if there is no support for JavaScript, you will need to re-install Visual Studio and check the Microsoft Web Developer Tools box.</span></span>

## <a name="walkthrough"></a><span data-ttu-id="c7529-146">チュートリアル</span><span class="sxs-lookup"><span data-stu-id="c7529-146">Walkthrough</span></span>

<span data-ttu-id="c7529-147">このゲームを開始すると、画面上をクリックするよう求めるメッセージが表示されます。</span><span class="sxs-lookup"><span data-stu-id="c7529-147">When you start up this game, you’ll see a prompt to click on the screen.</span></span> <span data-ttu-id="c7529-148">マウスで位置を探すことができるように、[Pointer Lock API](https://developer.mozilla.org/docs/Web/API/Pointer_Lock_API) が使用されています。</span><span class="sxs-lookup"><span data-stu-id="c7529-148">The [Pointer Lock API](https://developer.mozilla.org/docs/Web/API/Pointer_Lock_API) is used to allow you to look around with your mouse.</span></span> <span data-ttu-id="c7529-149">移動は、W キー、A キー、S キー、D キー、方向キーを押すことで操作できます。</span><span class="sxs-lookup"><span data-stu-id="c7529-149">Moving is done by pressing the W, A, S, D/arrow keys.</span></span>
<span data-ttu-id="c7529-150">このゲームの目的は、恐竜から常に離れていることです。</span><span class="sxs-lookup"><span data-stu-id="c7529-150">The goal of this game is to stay away from the dinosaur.</span></span> <span data-ttu-id="c7529-151">恐竜は、十分近くなると、圏外に出るか近付きすぎてゲームに負けるまで、プレイヤーを追いかけ始めます。</span><span class="sxs-lookup"><span data-stu-id="c7529-151">Once the dinosaur is close enough to you, it’ll start chasing you until you either get out of range or get too close and lose the game.</span></span>

### <a name="1-setting-up-your-initial-html-file"></a><span data-ttu-id="c7529-152">1. 初期 HTML ファイルをセットアップする</span><span class="sxs-lookup"><span data-stu-id="c7529-152">1. Setting up your initial HTML file</span></span>

<span data-ttu-id="c7529-153">最初に、小さな HTML を **index.html** 内に追加します。</span><span class="sxs-lookup"><span data-stu-id="c7529-153">Within **index.html**, you'll need to add a little HTML to get started.</span></span> <span data-ttu-id="c7529-154">このファイルは、アプリが含まれる既定の Web ページです。</span><span class="sxs-lookup"><span data-stu-id="c7529-154">This file is the default web page that contains our app.</span></span>

<span data-ttu-id="c7529-155">ここでは、使用するライブラリと、グラフィックスの表示先として使用する `div` (名前: `container`) でセットアップします</span><span class="sxs-lookup"><span data-stu-id="c7529-155">Right now, we'll set it up with the libraries we'll be using and the `div` (named `container`) that we'll use to render our graphics to.</span></span> <span data-ttu-id="c7529-156">また、**main.js** (ゲーム コード) がポイントされるように指定しておきます。</span><span class="sxs-lookup"><span data-stu-id="c7529-156">We'll also set it to point to our **main.js** (our game code).</span></span>


```html
<!DOCTYPE html>
<html lang='en'>

<head>
    <link rel="stylesheet" type="text/css" href="css/stylesheet.css" />
</head>

    <body>
        <div id='container'></div>
        <script src='js/libs/three.js'></script>
        <script src="js/controls/PointerLockControls.js"></script>
        <script src="js/main.js"></script>
    </body>

</html>
```


<span data-ttu-id="c7529-157">スターター HTML を準備できたので、**main.js** に移動し、いくつかのグラフィックスを作成しましょう。</span><span class="sxs-lookup"><span data-stu-id="c7529-157">Now that we have our starter HTML ready to go, let's head over to **main.js** and make some graphics!</span></span>

### <a name="2-creating-your-scene"></a><span data-ttu-id="c7529-158">2. シーンを作成する</span><span class="sxs-lookup"><span data-stu-id="c7529-158">2. Creating your scene</span></span>

<span data-ttu-id="c7529-159">このセクションでは、ゲームの基盤を追加します。</span><span class="sxs-lookup"><span data-stu-id="c7529-159">In the section of the walkthrough we're going to adding the foundation of the game.</span></span>

<span data-ttu-id="c7529-160">それでは、`scene` の肉付けから始めましょう。</span><span class="sxs-lookup"><span data-stu-id="c7529-160">We'll start off by fleshing out a `scene`.</span></span> <span data-ttu-id="c7529-161">**three.js** の `scene` は、カメラ、オブジェクト、光源を追加する場所です。</span><span class="sxs-lookup"><span data-stu-id="c7529-161">A `scene` in **three.js** is where your camera, objects, and lights will be added.</span></span> <span data-ttu-id="c7529-162">カメラが認識したものをシーンに反映して表示するためのレンダラーも必要です。</span><span class="sxs-lookup"><span data-stu-id="c7529-162">You'll also need a renderer which will take what your camera sees in the scene and display it.</span></span>

<span data-ttu-id="c7529-163">これらはすべて、**main.js** 内の `init()` という関数で行います。ここでは他の関数も呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="c7529-163">In **main.js** we'll make a function that does all of this called `init()` which calls on some additional functions:</span></span>

```javascript
var UNITWIDTH = 90; // Width of a cubes in the maze
var UNITHEIGHT = 45; // Height of the cubes in the maze

var camera, scene, renderer;

init();
animate();

function init() {
    // Create the scene where everything will go
    scene = new THREE.Scene();

    // Add some fog for effects
    scene.fog = new THREE.FogExp2(0xcccccc, 0.0015);

    // Set render settings
    renderer = new THREE.WebGLRenderer();
    renderer.setClearColor(scene.fog.color);
    renderer.setPixelRatio(window.devicePixelRatio);
    renderer.setSize(window.innerWidth, window.innerHeight);

    // Get the HTML container and connect renderer to it
    var container = document.getElementById('container');
    container.appendChild(renderer.domElement);

    // Set camera position and view details
    camera = new THREE.PerspectiveCamera(60, window.innerWidth / window.innerHeight, 1, 2000);
    camera.position.y = 20; // Height the camera will be looking from
    camera.position.x = 0;
    camera.position.z = 0;

    // Add the camera
    scene.add(camera);

    // Add the walls(cubes) of the maze
    createMazeCubes();

    // Add lights to the scene
    addLights();

    // Listen for if the window changes sizes and adjust
    window.addEventListener('resize', onWindowResize, false);
}

```

<span data-ttu-id="c7529-164">他の関数として、以下を作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c7529-164">The other functions we'll need to create include:</span></span>
- `createMazeCubes()`
- `addLights()`
- `onWindowResize()`
- `animate()` / `render()`
- <span data-ttu-id="c7529-165">単位変換関数</span><span class="sxs-lookup"><span data-stu-id="c7529-165">Unit conversion functions</span></span>

#### <a name="createmazecubes"></a><span data-ttu-id="c7529-166">createMazeCubes()</span><span class="sxs-lookup"><span data-stu-id="c7529-166">createMazeCubes()</span></span>

<span data-ttu-id="c7529-167">`createMazeCubes()` 関数は、単純な立方体をシーンに追加します。</span><span class="sxs-lookup"><span data-stu-id="c7529-167">The `createMazeCubes()` function will add a simple cube to our scene.</span></span> <span data-ttu-id="c7529-168">この関数では、後で多数の立方体を追加して迷路を作成します。</span><span class="sxs-lookup"><span data-stu-id="c7529-168">Later on we'll make the funcion add many cubes to make our maze.</span></span>

```javascript
function createMazeCubes() {

  // Make the shape of the cube that is UNITWIDTH wide/deep, and UNITHEIGHT tall
  var cubeGeo = new THREE.BoxGeometry(UNITWIDTH, UNITHEIGHT, UNITWIDTH);
  // Make the material of the cube and set it to blue
  var cubeMat = new THREE.MeshPhongMaterial({
    color: 0x81cfe0,
  });
  
  // Combine the geometry and material to make the cube
  var cube = new THREE.Mesh(cubeGeo, cubeMat);

  // Add the cube to the scene
  scene.add(cube);

  // Update the cube's position
  cube.position.y = UNITHEIGHT / 2;
  cube.position.x = 0;
  cube.position.z = -100;
  // rotate the cube by 30 degrees
  cube.rotation.y = degreesToRadians(30);
}

```

#### <a name="addlights"></a><span data-ttu-id="c7529-169">addLights()</span><span class="sxs-lookup"><span data-stu-id="c7529-169">addLights()</span></span>

<span data-ttu-id="c7529-170">`addLights()` 関数は、光源の作成をグループ化してシーンに追加する単純な関数です。</span><span class="sxs-lookup"><span data-stu-id="c7529-170">The `addLights()` function is a simple function that groups the creation of our lights and adds them to the scene.</span></span>

```javascript
function addLights() {
  var lightOne = new THREE.DirectionalLight(0xffffff);
  lightOne.position.set(1, 1, 1);
  scene.add(lightOne);

  // Add a second light with half the intensity
  var lightTwo = new THREE.DirectionalLight(0xffffff, .5);
  lightTwo.position.set(1, -1, -1);
  scene.add(lightTwo);
}
```

#### <a name="onwindowresize"></a><span data-ttu-id="c7529-171">onWindowResize()</span><span class="sxs-lookup"><span data-stu-id="c7529-171">onWindowResize()</span></span>

<span data-ttu-id="c7529-172">`onWindowResize` 関数は、`resize` イベントの発生をイベント リスナーが認識するたびに呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="c7529-172">The `onWindowResize` function is called whenever our event listener hears that a `resize` event was fired.</span></span> <span data-ttu-id="c7529-173">このイベントは、ユーザーがウィンドウのサイズを調整するたびに発生します。</span><span class="sxs-lookup"><span data-stu-id="c7529-173">This happens whenever the user adjusts the size of the window.</span></span> <span data-ttu-id="c7529-174">このとき、画像の縦横比が維持され、ウィンドウ全体に表示できることを確認する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c7529-174">If this happens, we want to make sure tha the image stays proportional and can be seen in the entire window.</span></span>

```javascript
function onWindowResize() {

  camera.aspect = window.innerWidth / window.innerHeight;
  camera.updateProjectionMatrix();

  renderer.setSize(window.innerWidth, window.innerHeight);
}
```

#### <a name="animate"></a><span data-ttu-id="c7529-175">animate()</span><span class="sxs-lookup"><span data-stu-id="c7529-175">animate()</span></span>

<span data-ttu-id="c7529-176">最後に必要になるのが `animate()` 関数です。この関数からは、`render()` 関数も呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="c7529-176">The last thing we'll need is our `animate()` function, which will also call the `render()` function.</span></span> <span data-ttu-id="c7529-177">レンダラーを定期的に更新するためには、[`requestAnimationFrame()`](https://developer.mozilla.org/docs/Web/API/window/requestAnimationFrame) 関数を使用します。</span><span class="sxs-lookup"><span data-stu-id="c7529-177">The [`requestAnimationFrame()`](https://developer.mozilla.org/docs/Web/API/window/requestAnimationFrame) function is used to constantly update our renderer.</span></span> <span data-ttu-id="c7529-178">後で、これらの関数を使ってレンダラーを更新し、迷路内の移動などのアニメーションを追加します。</span><span class="sxs-lookup"><span data-stu-id="c7529-178">Later on, we'll use these functions to update our renderer with cool animations like moving around the maze.</span></span>

```javascript
function animate() {
    render();
    // Keep updating the renderer
    requestAnimationFrame(animate);
}

function render() {
    renderer.render(scene, camera);
}
```

#### <a name="unit-conversion-functions"></a><span data-ttu-id="c7529-179">単位変換関数</span><span class="sxs-lookup"><span data-stu-id="c7529-179">Unit conversion functions</span></span>

<span data-ttu-id="c7529-180">**three.js** では、回転の単位としてラジアンが使用されています。</span><span class="sxs-lookup"><span data-stu-id="c7529-180">In **three.js** rotations are measured in radians.</span></span> <span data-ttu-id="c7529-181">このため、度とラジアンの変換を簡単に処理できるように、必要な関数を追加します。</span><span class="sxs-lookup"><span data-stu-id="c7529-181">To make things easy for us, we'll go ahead and add some functions so that we can easily convert between degrees and radians.</span></span> 


```javascript
function degreesToRadians(degrees) {
  return degrees * Math.PI / 180;
}

function radiansToDegrees(radians) {
  return radians * 180 / Math.PI;
}
```

<span data-ttu-id="c7529-182">30 度が 0.523 ラジアンであることは覚えにくいので、</span><span class="sxs-lookup"><span data-stu-id="c7529-182">Who would remember that 30 degrees is .523 radians?</span></span> <span data-ttu-id="c7529-183">代わりに `degreesToRadians(30)` を実行して回転角度を取得する方が簡単です。これを `createMazeCubes()` 関数内で使用します。</span><span class="sxs-lookup"><span data-stu-id="c7529-183">It's much simpler to instead do `degreesToRadians(30)` to get our rotation amount which is used in our `createMazeCubes()` function.</span></span>

___

<span data-ttu-id="c7529-184">さまざまなコードを使いましたが、これできちんと立方体を `container` に表示できました。</span><span class="sxs-lookup"><span data-stu-id="c7529-184">That was quite a bit of code to take in, but we now have a beautiful cube the is rendered to our `container`!</span></span> <span data-ttu-id="c7529-185">結果を CodePen で確認してください。</span><span class="sxs-lookup"><span data-stu-id="c7529-185">Check out the results in the CodePen.</span></span>

<span data-ttu-id="c7529-186">問題が発生した場合や、光源の調整または色の変更を行う場合は、この CodePen で提供されている JavaScript をすべてコピーして貼り付けることで、対処できます。</span><span class="sxs-lookup"><span data-stu-id="c7529-186">You can copy and paste all the JavaScript in this CodePen to get caught up if you encountered issues, or edit it to adjust some lights and change some colors.</span></span> 

<iframe height='300' scrolling='no' title='<span data-ttu-id="c7529-187">ライト、カメラ、立方体です。</span><span class="sxs-lookup"><span data-stu-id="c7529-187">Lights, camera, cube!</span></span>' src='//codepen.io/MicrosoftEdgeDocumentation/embed/YZWygZ/?height=300&theme-id=23761&default-tab=result&embed-version=2&editable=true' frameborder='no' allowtransparency='true' allowfullscreen='true' style='width: 100%;'><span data-ttu-id="c7529-188">ペンを参照してください<a href='https://codepen.io/MicrosoftEdgeDocumentation/pen/YZWygZ/'>ライト、カメラ、立方体!</a> 。</span><span class="sxs-lookup"><span data-stu-id="c7529-188">See the Pen <a href='https://codepen.io/MicrosoftEdgeDocumentation/pen/YZWygZ/'>Lights, camera, cube!</a></span></span> <span data-ttu-id="c7529-189">Microsoft Edge Docs (<a href='https://codepen.io/MicrosoftEdgeDocumentation'>@MicrosoftEdgeDocumentation</a>) <a href='https://codepen.io'>CodePen</a>でします。</span><span class="sxs-lookup"><span data-stu-id="c7529-189">by Microsoft Edge Docs (<a href='https://codepen.io/MicrosoftEdgeDocumentation'>@MicrosoftEdgeDocumentation</a>) on <a href='https://codepen.io'>CodePen</a>.</span></span>
</iframe>


### <a name="3-making-the-maze"></a><span data-ttu-id="c7529-190">3. 迷路を作成する</span><span class="sxs-lookup"><span data-stu-id="c7529-190">3. Making the maze</span></span>

<span data-ttu-id="c7529-191">立方体を表示できたので、次は立方体でできた迷路全体を表示してみましょう。</span><span class="sxs-lookup"><span data-stu-id="c7529-191">While staring at a cube is breathtaking, what’s even better is a whole maze made out of cubes!</span></span> <span data-ttu-id="c7529-192">ゲーム コミュニティではよく知られた手法ですが、レベルを最短時間で作成する手法の 1 つは、2D 配列によって立方体を全体に配置することです。</span><span class="sxs-lookup"><span data-stu-id="c7529-192">It’s a pretty well-known secret in the games community that one of the quickest ways to creating a level is by placing cubes all over with a 2D array.</span></span>
 
![2D 配列で作成された迷路](images/dinomap.png)

<span data-ttu-id="c7529-194">立方体の場所に 1 を配置して空白の場所に 0 を配置すると、迷路を手動で簡単に作成または調整できます。</span><span class="sxs-lookup"><span data-stu-id="c7529-194">Placing 1’s where cubes are and 0’s where empty space is allows for a manual and simple way for you to create/tweak the maze.</span></span>

<span data-ttu-id="c7529-195">これには、元の `createMazeCubes()` 関数に、複数の立方体を作成および配置するための入れ子になったループを追加します。</span><span class="sxs-lookup"><span data-stu-id="c7529-195">We achieve this by replacing our old `createMazeCubes()` function with one that uses a nested loop to create and place multiple cubes.</span></span> <span data-ttu-id="c7529-196">また、`collidableObjects` という名前の配列を作成して、立方体を追加します。これは、後で衝突を検出するために使用します。</span><span class="sxs-lookup"><span data-stu-id="c7529-196">We'll also create an array name `collidableObjects` and add the cubes to it for collision detection later in this tutorial:</span></span>

```javascript
var totalCubesWide; // How many cubes wide the maze will be
var collidableObjects = []; // An array of collidable objects used later

function createMazeCubes() {
  // Maze wall mapping, assuming even square
  // 1's are cubes, 0's are empty space
  var map = [
    [0, 0, 1, 0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, ],
    [0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, ],
    [0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 1, 1, 1, 1, 1, 0, 1, 1, 0, 0, ],
    [0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, ],
    [0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, ],
    [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, ],
    [1, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, ],
    [0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, ],
    [0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, ],
    [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, ],
    [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, ],
    [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 1, 0, 0, ],
    [0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 1, 0, 1, 0, 0, 1, 1, 1, ],
    [0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, ],
    [0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 1, 1, 1, 0, 1, 0, 0, 0, 0, 0, ],
    [1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 0, 1, 1, 0, 1, 0, 0, 0, 0, 0, ],
    [0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, ],
    [1, 1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, ],
    [0, 0, 1, 0, 1, 1, 1, 1, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, ],
    [0, 0, 1, 1, 1, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, ]
  ];

  // wall details
  var cubeGeo = new THREE.BoxGeometry(UNITWIDTH, UNITHEIGHT, UNITWIDTH);
  var cubeMat = new THREE.MeshPhongMaterial({
    color: 0x81cfe0,
  });

  // Keep cubes within boundry walls
  var widthOffset = UNITWIDTH / 2;
  // Put the bottom of the cube at y = 0
  var heightOffset = UNITHEIGHT / 2;
  
  // See how wide the map is by seeing how long the first array is
  totalCubesWide = map[0].length;

  // Place walls where 1`s are
  for (var i = 0; i < totalCubesWide; i++) {
    for (var j = 0; j < map[i].length; j++) {
      // If a 1 is found, add a cube at the corresponding position
      if (map[i][j]) {
        // Make the cube
        var cube = new THREE.Mesh(cubeGeo, cubeMat);
        // Set the cube position
        cube.position.z = (i - totalCubesWide / 2) * UNITWIDTH + widthOffset;
        cube.position.y = heightOffset;
        cube.position.x = (j - totalCubesWide / 2) * UNITWIDTH + widthOffset;
        // Add the cube
        scene.add(cube);
        // Used later for collision detection
        collidableObjects.push(cube);
      }
    }
  }
    // The size of the maze will be how many cubes wide the array is * the width of a cube
    mapSize = totalCubesWide * UNITWIDTH;
}

```

<span data-ttu-id="c7529-197">使用する立方体の数 (およびその大きさ) が決まったため、計算された `mapSize` 変数を使用して、グループ化された平面の寸法を設定できます。</span><span class="sxs-lookup"><span data-stu-id="c7529-197">Now that we know how many cubes are being used (and how big they are), we can now use the calculated `mapSize` variable to set the dimensions of the ground plane:</span></span>

```javascript
var mapSize;    // The width/depth of the maze

function createGround() {
    // Create ground geometry and material
    var groundGeo = new THREE.PlaneGeometry(mapSize, mapSize);
    var groundMat = new THREE.MeshPhongMaterial({ color: 0xA0522D, side: THREE.DoubleSide});

    var ground = new THREE.Mesh(groundGeo, groundMat);
    ground.position.set(0, 1, 0);
    // Rotate the place to ground level
    ground.rotation.x = degreesToRadians(90);
    scene.add(ground);
}
```

<span data-ttu-id="c7529-198">迷路に追加する最後の部分は、すべてを囲む外周の壁です。</span><span class="sxs-lookup"><span data-stu-id="c7529-198">The last piece of the maze we'll add is perimeter walls to box everything in.</span></span> <span data-ttu-id="c7529-199">ループを使用して、一度に 2 つの平面 (壁) を作成します。幅を決定するには、`createGround()` で計算した `mapSize` 変数を使用します。</span><span class="sxs-lookup"><span data-stu-id="c7529-199">We'll use a loop to make two planes (our walls) at a time, using the `mapSize` variable we calculated in `createGround()` to determine how wide they should be.</span></span> <span data-ttu-id="c7529-200">新しい壁は、衝突の検出用に `collidableObjects` 配列にも追加されます。</span><span class="sxs-lookup"><span data-stu-id="c7529-200">The new walls will also be added to our `collidableObjects` array for future collision detection:</span></span>

```javascript
function createPerimWalls() {
    var halfMap = mapSize / 2;  // Half the size of the map
    var sign = 1;               // Used to make an amount positive or negative

    // Loop through twice, making two perimeter walls at a time
    for (var i = 0; i < 2; i++) {
        var perimGeo = new THREE.PlaneGeometry(mapSize, UNITHEIGHT);
        // Make the material double sided
        var perimMat = new THREE.MeshPhongMaterial({ color: 0x464646, side: THREE.DoubleSide });
        // Make two walls
        var perimWallLR = new THREE.Mesh(perimGeo, perimMat);
        var perimWallFB = new THREE.Mesh(perimGeo, perimMat);

        // Create left/right wall
        perimWallLR.position.set(halfMap * sign, UNITHEIGHT / 2, 0);
        perimWallLR.rotation.y = degreesToRadians(90);
        scene.add(perimWallLR);
        // Used later for collision detection
        collidableObjects.push(perimWallLR);
        // Create front/back wall
        perimWallFB.position.set(0, UNITHEIGHT / 2, halfMap * sign);
        scene.add(perimWallFB);

        // Used later for collision detection
        collidableObjects.push(perimWallFB);

        sign = -1; // Swap to negative value
    }
}
```


<span data-ttu-id="c7529-201">`createGround()` と `createPerimWalls` を正しくコンパイルするには、`init()` 関数内で、`createMazeCubes()` の後にこれらを呼び出すことを忘れないでください。</span><span class="sxs-lookup"><span data-stu-id="c7529-201">Don't forget to add a call to `createGround()` and `createPerimWalls` after `createMazeCubes()` in your `init()` function so that they get compiled!</span></span>
___

<span data-ttu-id="c7529-202">これで立派な迷路を表示できましたが、カメラが 1 点に固定されているため、特におもしろくありません。</span><span class="sxs-lookup"><span data-stu-id="c7529-202">We now have a beautiful maze to look at but can't really get a feel for just how cool it is because our camera is stuck in one spot.</span></span> <span data-ttu-id="c7529-203">カメラ コントロールを加えて、ゲームをパワーアップしてみましょう。</span><span class="sxs-lookup"><span data-stu-id="c7529-203">It's time to kick this game up a notch and add in some camera controls.</span></span>

<span data-ttu-id="c7529-204">CodePen を使うと、立方体の色を変更したり、`init()` 関数の `createGround()` をコメントアウトして地面を削除するなど、さまざまなテストを行うことができます。</span><span class="sxs-lookup"><span data-stu-id="c7529-204">Feel free to test things out in the CodePen like changing the colors of the cubes or removing the ground by commenting out `createGround()` in the `init()` function.</span></span>


<iframe height='300' scrolling='no' title='<span data-ttu-id="c7529-205">迷路の構築</span><span class="sxs-lookup"><span data-stu-id="c7529-205">Maze building</span></span>' src='//codepen.io/MicrosoftEdgeDocumentation/embed/JWKYzG/?height=300&theme-id=23761&default-tab=result&embed-version=2&editable=true' frameborder='no' allowtransparency='true' allowfullscreen='true' style='width: 100%;'><span data-ttu-id="c7529-206"><a href='https://codepen.io'>CodePen</a> で、Microsoft Edge Docs (<a href='https://codepen.io/MicrosoftEdgeDocumentation'>@MicrosoftEdgeDocumentation</a>) による Pen (<a href='https://codepen.io/MicrosoftEdgeDocumentation/pen/JWKYzG/'>Maze building</a>) をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c7529-206">See the Pen <a href='https://codepen.io/MicrosoftEdgeDocumentation/pen/JWKYzG/'>Maze building</a> by Microsoft Edge Docs (<a href='https://codepen.io/MicrosoftEdgeDocumentation'>@MicrosoftEdgeDocumentation</a>) on <a href='https://codepen.io'>CodePen</a>.</span></span>
</iframe>

### <a name="4-allowing-the-player-to-look-around"></a><span data-ttu-id="c7529-207">4. プレイヤーによる探検を可能にする</span><span class="sxs-lookup"><span data-stu-id="c7529-207">4. Allowing the player to look around</span></span>

<span data-ttu-id="c7529-208">では、迷路に入り、探検を開始しましょう。</span><span class="sxs-lookup"><span data-stu-id="c7529-208">Now it’s time to get in that maze and start looking around.</span></span> <span data-ttu-id="c7529-209">これを行うには、**PointerLockControls.js** ライブラリとカメラを使います。</span><span class="sxs-lookup"><span data-stu-id="c7529-209">To do this we’ll be using the **PointerLockControls.js** library and our camera.</span></span>

<span data-ttu-id="c7529-210">**PoinerLockControls.js** ライブラリでは、マウスを使用して、マウスの移動方向にカメラを回転することで、プレイヤーによる探検を可能にします。</span><span class="sxs-lookup"><span data-stu-id="c7529-210">The **PoinerLockControls.js** library uses the mouse to rotate the camera in the direction that the mouse is moved, allowing the player to look around.</span></span> 

<span data-ttu-id="c7529-211">まず、**index.html** ファイルにいくつか新しい要素を追加しましょう。</span><span class="sxs-lookup"><span data-stu-id="c7529-211">First let's add some new elements to our **index.html** file:</span></span>

```html
<div id="blocker">
    <div id="instructions">
    <strong>Click to look!</strong>
    </div>
</div>

<script src="main.js"></script>
```

<span data-ttu-id="c7529-212">また、このセクションの最後には、CodePen 内のすべての CSS も必要になります。</span><span class="sxs-lookup"><span data-stu-id="c7529-212">You'll also need all the CSS in the CodePen at the bottom of this section.</span></span> <span data-ttu-id="c7529-213">CSS は、**stylesheet.css** ファイルに貼り付けます。</span><span class="sxs-lookup"><span data-stu-id="c7529-213">It should be pasted into your **stylesheet.css** file.</span></span>

<span data-ttu-id="c7529-214">**main.js** に戻り、新しい変数をいくつか追加します。`controls` にはコントローラーを格納し、`controlsEnabled` ではコントローラーの状態を追跡します。`blocker` には、**index.html** の `blocker` 要素を格納します。</span><span class="sxs-lookup"><span data-stu-id="c7529-214">Switching back to **main.js**, add a few new global variables; `controls` to store our controller, `controlsEnabled` to keep track of the controller state, and `blocker` to grab the `blocker` element in **index.html**:</span></span>

```javascript
var controls;
var controlsEnabled = false;

// HTML elements to be changed
var blocker = document.getElementById('blocker');
```


<span data-ttu-id="c7529-215">これで、`init()` 関数内で新しい `PoinerLockControls` オブジェクトを作成し、これに `camera`, を渡して、`camera` を追加します (`controls.getObject()` でアクセスします)。</span><span class="sxs-lookup"><span data-stu-id="c7529-215">Now in our `init()` function we can make a new `PoinerLockControls` object, pass it our `camera`, and add the `camera` (accessed with `controls.getObject()`).</span></span>

```javascript
controls = new THREE.PointerLockControls(camera);
scene.add(controls.getObject());
```

<span data-ttu-id="c7529-216">これでカメラが接続されましたが、探検のためには、マウスとコントローラーの間でのやり取りが必要です。</span><span class="sxs-lookup"><span data-stu-id="c7529-216">The camera is now connected, but we need to somehow let the mouse and controller interact so that we can look around.</span></span> 

<span data-ttu-id="c7529-217">このような場合は、マウスの動きとカメラを連動させる [Pointer Lock API](https://docs.microsoft.com/microsoft-edge/dev-guide/dom/pointer-lock) が役立ちます。</span><span class="sxs-lookup"><span data-stu-id="c7529-217">For this situation, the [Pointer Lock API](https://docs.microsoft.com/microsoft-edge/dev-guide/dom/pointer-lock) comes to the rescue by letting us connect mouse movements to our camera.</span></span> <span data-ttu-id="c7529-218">Pointer Lock API では、よりイマーシブなエクスペリエンスを提供するために、マウス カーソルを非表示にすることもできます。</span><span class="sxs-lookup"><span data-stu-id="c7529-218">The Pointer Lock API also makes the mouse disappear for a more immersive experience.</span></span> <span data-ttu-id="c7529-219">Esc キーを押すと、マウスからカメラへの接続が終了し、マウス カーソルが再び現れます。</span><span class="sxs-lookup"><span data-stu-id="c7529-219">By pressing ESC we end the mouse to camera connection and make the mouse reappear.</span></span> <span data-ttu-id="c7529-220">これには、`getPointerLock()` 関数と `lockChange()` 関数を追加します。</span><span class="sxs-lookup"><span data-stu-id="c7529-220">Additions of the `getPointerLock()` and `lockChange()` functions will help us do just that.</span></span>

<span data-ttu-id="c7529-221">`getPointerLock()` 関数は、マウス クリックの発生をリッスンします。</span><span class="sxs-lookup"><span data-stu-id="c7529-221">The `getPointerLock()` function listens for when a mouse click happens.</span></span> <span data-ttu-id="c7529-222">クリックの後、レンダリングされたゲームでは、(`container` 要素内で) マウス コントロールの取得が試行されます。</span><span class="sxs-lookup"><span data-stu-id="c7529-222">After the click, our rendered game (in the `container` element) tries to get control of the mouse.</span></span> <span data-ttu-id="c7529-223">コードに、イベント リスナーも追加します。これにより、プレイヤーによるロックの有効化および無効化を検出して `lockChange()` を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="c7529-223">We also add an event listener to detect when the player activates or deactivates the lock which then calls `lockChange()`.</span></span> 

```javascript
function getPointerLock() {
  document.onclick = function () {
    container.requestPointerLock();
  }
  document.addEventListener('pointerlockchange', lockChange, false); 
}

```

<span data-ttu-id="c7529-224">`lockChange()` 関数では、コントロールと `blocker` 要素を無効化または有効化する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c7529-224">Our `lockChange()` function needs to either disable or enable the controls and `blocker` element.</span></span> <span data-ttu-id="c7529-225">ポインター ロックの状態を判断するには、[`pointerLockElement`](https://developer.mozilla.org/docs/Web/API/Document/pointerLockElement) プロパティでマウス イベントのターゲットが `container` に設定されているかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="c7529-225">We can determine the state of the pointer lock by checking if the [`pointerLockElement`](https://developer.mozilla.org/docs/Web/API/Document/pointerLockElement) property's target for mouse events is set to our `container`.</span></span>

```javascript
function lockChange() {
    // Turn on controls
    if (document.pointerLockElement === container) {
        // Hide blocker and instructions
        blocker.style.display = "none";
        controls.enabled = true;
    // Turn off the controls
    } else {
      // Display the blocker and instruction
        blocker.style.display = "";
        controls.enabled = false;
    }
}
```

<span data-ttu-id="c7529-226">次に、`init()` 関数のすぐ前に、`getPointerLock()` の呼び出しを追加します。</span><span class="sxs-lookup"><span data-stu-id="c7529-226">Now we can add a call to `getPointerLock()` just before our `init()` function.</span></span>
```javascript
// Get the pointer lock state
getPointerLock();
init();
animate();
```

---

<span data-ttu-id="c7529-227">これで、周囲を**見回す**ことができますが、実際には**動き回る**機能が欲しいところです。</span><span class="sxs-lookup"><span data-stu-id="c7529-227">At this point we now have the ability to **look** around, but the real 'wow' factor is being able to **move** around.</span></span> <span data-ttu-id="c7529-228">ベクトルなど、少し数学的な説明になりますが、3D グラフィックスの動作には数学が不可欠です。</span><span class="sxs-lookup"><span data-stu-id="c7529-228">Things are about to get a little mathematical with vectors, but what's 3D graphics without a bit of math?</span></span>

<iframe height='300' scrolling='no' title='<span data-ttu-id="c7529-229">探検します。</span><span class="sxs-lookup"><span data-stu-id="c7529-229">Look around</span></span>' src='//codepen.io/MicrosoftEdgeDocumentation/embed/gmwbMo/?height=300&theme-id=23761&default-tab=result&embed-version=2&editable=true' frameborder='no' allowtransparency='true' allowfullscreen='true' style='width: 100%;'><span data-ttu-id="c7529-230"><a href='https://codepen.io'>CodePen</a> で、Microsoft Edge Docs (<a href='https://codepen.io/MicrosoftEdgeDocumentation'>@MicrosoftEdgeDocumentation</a>) による Pen (<a href='https://codepen.io/MicrosoftEdgeDocumentation/pen/gmwbMo/'>Look around</a>) をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c7529-230">See the Pen <a href='https://codepen.io/MicrosoftEdgeDocumentation/pen/gmwbMo/'>Look around</a> by Microsoft Edge Docs (<a href='https://codepen.io/MicrosoftEdgeDocumentation'>@MicrosoftEdgeDocumentation</a>) on <a href='https://codepen.io'>CodePen</a>.</span></span>
</iframe>


### <a name="5-adding-player-movement"></a><span data-ttu-id="c7529-231">5. プレイヤーの動きを追加する</span><span class="sxs-lookup"><span data-stu-id="c7529-231">5. Adding player movement</span></span>

<span data-ttu-id="c7529-232">プレイヤーに動きを提供する方法を理解するには、数学の勉強に戻る必要があります。</span><span class="sxs-lookup"><span data-stu-id="c7529-232">To dig into how to get our player moving, we've got to think back to our calculus days.</span></span> <span data-ttu-id="c7529-233">特定のベクトル (direction) に沿って、速度 (movement) を `camera` に適用します。</span><span class="sxs-lookup"><span data-stu-id="c7529-233">We want to apply velocity (movement) to the `camera` along a certain vector (direction).</span></span>

<span data-ttu-id="c7529-234">それでは、プレイヤーの移動方向を追跡するためのグローバル変数をいくつか追加し、初期速度ベクトルを設定しましょう。</span><span class="sxs-lookup"><span data-stu-id="c7529-234">Let's add a few more global variables to keep track of which direction the player is moving, and set an initial velocity vector:</span></span>

```javascript
// Flags to determine which direction the player is moving
var moveForward = false;
var moveBackward = false;
var moveLeft = false;
var moveRight = false;

// Velocity vector for the player
var playerVelocity = new THREE.Vector3();

// How fast the player will move
var PLAYERSPEED = 800.0;

var clock;
```

<span data-ttu-id="c7529-235">`init()` 関数の先頭で、`clock` を新しい `Clock` オブジェクトに設定します。</span><span class="sxs-lookup"><span data-stu-id="c7529-235">In the beginning of the `init()` function, set `clock` to a new `Clock` object.</span></span> <span data-ttu-id="c7529-236">これは、新しいフレームのレンダリングにかかる時間の経過 (delta) を追跡するために使用します。</span><span class="sxs-lookup"><span data-stu-id="c7529-236">We'll be using this to keep track of the change in time (delta) it takes to render new frames.</span></span> <span data-ttu-id="c7529-237">また、ユーザー入力を収集する `listenForPlayerMovement()` の呼び出しも追加します。</span><span class="sxs-lookup"><span data-stu-id="c7529-237">You'll also need to add a call to `listenForPlayerMovement()`, which gathers user input.</span></span> 

```
clock = new THREE.Clock();
listenForPlayerMovement();
```

<span data-ttu-id="c7529-238">`listenForPlayerMovement()` 関数では、方向の状態の切り替えが行われます。</span><span class="sxs-lookup"><span data-stu-id="c7529-238">Our `listenForPlayerMovement()` function is what will be flipping our direction states.</span></span> <span data-ttu-id="c7529-239">この関数の終わり近くには、キーが押されるか離されるのを待機する 2 つのイベント リスナーがあります。</span><span class="sxs-lookup"><span data-stu-id="c7529-239">At the bottom of the function we have two event listeners that are waiting for keys to be pressed and released.</span></span> <span data-ttu-id="c7529-240">どちらかのイベントが発生した場合は、動きをトリガーするキーか、動きを停止させるキーかを確認します。</span><span class="sxs-lookup"><span data-stu-id="c7529-240">Once one of these events are fired, we'll then check to see if it's a key that we want to trigger or stop movement.</span></span>

<span data-ttu-id="c7529-241">このゲームは、プレイヤーが W キー、A キー、S キー、D キー、または方向キーで動き回ることができるとセットアップしてあります。</span><span class="sxs-lookup"><span data-stu-id="c7529-241">For this game, we've set it up so that the player can move around with the W, A, S, D keys or the arrow keys.</span></span>

```javascript
function listenForPlayerMovement() {
    
    // A key has been pressed
    var onKeyDown = function(event) {

    switch (event.keyCode) {

      case 38: // up
      case 87: // w
        moveForward = true;
        break;

      case 37: // left
      case 65: // a
        moveLeft = true;
        break;

      case 40: // down
      case 83: // s
        moveBackward = true;
        break;

      case 39: // right
      case 68: // d
        moveRight = true;
        break;
    }
  };

  // A key has been released
    var onKeyUp = function(event) {

    switch (event.keyCode) {

      case 38: // up
      case 87: // w
        moveForward = false;
        break;

      case 37: // left
      case 65: // a
        moveLeft = false;
        break;

      case 40: // down
      case 83: // s
        moveBackward = false;
        break;

      case 39: // right
      case 68: // d
        moveRight = false;
        break;
    }
  };

  // Add event listeners for when movement keys are pressed and released
  document.addEventListener('keydown', onKeyDown, false);
  document.addEventListener('keyup', onKeyUp, false);
}
```

<span data-ttu-id="c7529-242">これで、ユーザーが進もうとしている方向 (いずれかのグローバル方向フラグに `true` として格納されている) を判断できるため、少しアクションを加えてみましょう。</span><span class="sxs-lookup"><span data-stu-id="c7529-242">Now that we're able to determine which direction the user wants to go (which is now stored as `true` in one of the global direction flags), it's time for some action.</span></span> <span data-ttu-id="c7529-243">アクションは、`animatePlayer()` 関数の形式で発生します。</span><span class="sxs-lookup"><span data-stu-id="c7529-243">This action happens to come in the form of the `animatePlayer()` function.</span></span>

<span data-ttu-id="c7529-244">この関数は、`animate()` 内で呼び出します。このとき、フレームレートが変化しても動作がずれないように、`delta` によってフレーム間の時間の経過を取得します。</span><span class="sxs-lookup"><span data-stu-id="c7529-244">This function will be called from within `animate()`, passing in `delta` to get the change in time between frames so that our movement doesn't seem out of sync during changes in framerate:</span></span>

```javascript
function animate() {
  render();
  requestAnimationFrame(animate);
  // Get the change in time between frames
  var delta = clock.getDelta();
  animatePlayer(delta);
}
```

<span data-ttu-id="c7529-245">では、楽しい部分に移りましょう。</span><span class="sxs-lookup"><span data-stu-id="c7529-245">Now it's time for the fun part!</span></span> <span data-ttu-id="c7529-246">推進力を決定するベクトル (`playerVeloctiy`) には、3 つのパラメーター `(x, y, z)` があり、`y` が垂直方向の推進力になります。</span><span class="sxs-lookup"><span data-stu-id="c7529-246">Our momentum vector (`playerVeloctiy`) has three parameters, `(x, y, z)`, with `y` being the vertical momentum.</span></span> <span data-ttu-id="c7529-247">このゲームにはジャンプ動作が含まれないため、処理するのは `x` パラメーターと `z` パラメーターのみです。</span><span class="sxs-lookup"><span data-stu-id="c7529-247">Since we aren't doing any jumping in this game, we'll only be working with the `x` and `z` parameters.</span></span> <span data-ttu-id="c7529-248">このベクトルは、最初は (0, 0, 0) に設定されています。</span><span class="sxs-lookup"><span data-stu-id="c7529-248">Initially this vector is set to (0, 0, 0).</span></span>

<span data-ttu-id="c7529-249">以下のコードに示されているように、どの方向フラグが `true` になっているかを確認するために、一連のチェックが行われます。</span><span class="sxs-lookup"><span data-stu-id="c7529-249">As seen in the code below, a series of checks are done to see which direction flag is flipped to `true`.</span></span> <span data-ttu-id="c7529-250">方向を取得したら、`x` および `y` に値を加算または減算して、その方向に推進力を適用します。</span><span class="sxs-lookup"><span data-stu-id="c7529-250">Once we have the direction, we add or subtract from `x` and `y` to apply momentum in that direction.</span></span> <span data-ttu-id="c7529-251">移動キーが押されていない場合は、ベクトルの設定が `(0, 0, 0)` に戻ります。</span><span class="sxs-lookup"><span data-stu-id="c7529-251">If no movement keys are being pressed, the vector will be set back to `(0, 0, 0)`.</span></span>


```javascript

function animatePlayer(delta) {
  // Gradual slowdown
  playerVelocity.x -= playerVelocity.x * 10.0 * delta;
  playerVelocity.z -= playerVelocity.z * 10.0 * delta;

  if (moveForward) {
    playerVelocity.z -= PLAYERSPEED * delta;
  } 
  if (moveBackward) {
    playerVelocity.z += PLAYERSPEED * delta;
  } 
  if (moveLeft) {
    playerVelocity.x -= PLAYERSPEED * delta;
  } 
  if (moveRight) {
    playerVelocity.x += PLAYERSPEED * delta;
  }
  if( !( moveForward || moveBackward || moveLeft ||moveRight)) {
    // No movement key being pressed. Stop movememnt
    playerVelocity.x = 0;
    playerVelocity.z = 0;
  }
  controls.getObject().translateX(playerVelocity.x * delta);
  controls.getObject().translateZ(playerVelocity.z * delta);
}
```

<span data-ttu-id="c7529-252">最後に、更新された `x` と `y` の値を、実際にプレイヤーを移動させる値に変換して、カメラに適用します。</span><span class="sxs-lookup"><span data-stu-id="c7529-252">In the end, we apply the whatever the updated `x` and `y` values are to the camera as translations to make the player actually move.</span></span>

---

<span data-ttu-id="c7529-253">これで、</span><span class="sxs-lookup"><span data-stu-id="c7529-253">Congratulations!</span></span> <span data-ttu-id="c7529-254">プレイヤーによって制御されるカメラで、自由に見回し、動き回ることができます。</span><span class="sxs-lookup"><span data-stu-id="c7529-254">You now have a player controlled camera that can move and look around.</span></span> <span data-ttu-id="c7529-255">まだ、壁に入り込むことができますが、これについては後で考えましょう。</span><span class="sxs-lookup"><span data-stu-id="c7529-255">We still slip right through walls, but that's something to worry about later.</span></span> <span data-ttu-id="c7529-256">次は、恐竜を追加します。</span><span class="sxs-lookup"><span data-stu-id="c7529-256">Next we'll add our dinosaur.</span></span>

<iframe height='300' scrolling='no' title='<span data-ttu-id="c7529-257">移動します。</span><span class="sxs-lookup"><span data-stu-id="c7529-257">Move around</span></span>' src='//codepen.io/MicrosoftEdgeDocumentation/embed/qrbKZg/?height=300&theme-id=23761&default-tab=result&embed-version=2&editable=true' frameborder='no' allowtransparency='true' allowfullscreen='true' style='width: 100%;'><span data-ttu-id="c7529-258">ペン<a href='https://codepen.io/MicrosoftEdgeDocumentation/pen/qrbKZg/'>の移動</a>で Microsoft Edge Docs を参照してください (<a href='https://codepen.io/MicrosoftEdgeDocumentation'>@MicrosoftEdgeDocumentation</a>) <a href='https://codepen.io'>CodePen</a>でします。</span><span class="sxs-lookup"><span data-stu-id="c7529-258">See the Pen <a href='https://codepen.io/MicrosoftEdgeDocumentation/pen/qrbKZg/'>Move around</a> by Microsoft Edge Docs (<a href='https://codepen.io/MicrosoftEdgeDocumentation'>@MicrosoftEdgeDocumentation</a>) on <a href='https://codepen.io'>CodePen</a>.</span></span>
</iframe>

> [!NOTE]
> <span data-ttu-id="c7529-259">UWP アプリでこれらのコントロールを使用する場合、動きの遅延や `keyUp` イベントの未登録エラーが発生することがあります。</span><span class="sxs-lookup"><span data-stu-id="c7529-259">If you use these controls in your UWP app you may experience movement lag and unregistered `keyUp` events.</span></span> <span data-ttu-id="c7529-260">この問題については調査中であり、サンプルの該当部分も間もなく修正される予定です。</span><span class="sxs-lookup"><span data-stu-id="c7529-260">We're looking into this and hope to fix this portion of the sample soon!</span></span>

### <a name="6-load-that-dino"></a><span data-ttu-id="c7529-261">6. 恐竜を読み込む</span><span class="sxs-lookup"><span data-stu-id="c7529-261">6. Load that dino!</span></span>

<span data-ttu-id="c7529-262">このプロジェクト リポジトリを複製またはダウンロードした場合は、`models` フォルダー内に `dino.json` があります。</span><span class="sxs-lookup"><span data-stu-id="c7529-262">If you cloned or downloaded this projects repo, you'll see a `models` folder with `dino.json` inside.</span></span> <span data-ttu-id="c7529-263">この JSON ファイルは、Blender で作成され、エクスポートされた 3D の恐竜です。</span><span class="sxs-lookup"><span data-stu-id="c7529-263">This JSON file is a 3D dinosaur model that was made and exported from Blender.</span></span>


<span data-ttu-id="c7529-264">この恐竜を読み込むには、さらにグローバル変数を追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c7529-264">We'll have to add more global variables to get this dino loaded up:</span></span>

```javascript
var DINOSCALE = 20;  // How big our dino is scaled to

var clock;
var dino;
var loader = new THREE.JSONLoader();

var instructions = document.getElementById('instructions');
```

<span data-ttu-id="c7529-265">作成した `JSONLoader` には、**dino.json** のパスと、ファイルから収集した geometry および materials が指定されたコールバックを渡します。</span><span class="sxs-lookup"><span data-stu-id="c7529-265">Now that we have our `JSONLoader` created, we'll pass in the path to our **dino.json** and a callback with the geometry and materials gathered from the file.</span></span>
<span data-ttu-id="c7529-266">恐竜の読み込みは非同期タスクです。つまり、恐竜が完全に読み込まれるまで、レンダリングは一切行われません。</span><span class="sxs-lookup"><span data-stu-id="c7529-266">Loading the dino is an asynchronous task, meaning nothing will render until the dino is completely loaded.</span></span> <span data-ttu-id="c7529-267">**index.html** の `instructions` 要素内の文字列は、処理中であることをプレイヤーに伝えるために、`"Loading..."` に変更してあります。</span><span class="sxs-lookup"><span data-stu-id="c7529-267">In our **index.html** we changed the string in the `instructions` element to `"Loading..."` to let the player know things are in progress.</span></span>

<span data-ttu-id="c7529-268">以下のように、恐竜が読み込まれた後、`instructions` 要素の内容をゲームの実際の手順に更新し、`animate()` 関数を `init()` の末尾から関数コールバックの末尾に移動します。</span><span class="sxs-lookup"><span data-stu-id="c7529-268">After the dino is loaded, update the `instructions` element with the actual instructions of the game, and move the `animate()` function from the end of `init()` to the end of the function callback seen below:</span></span>

```javascript
   // load the dino JSON model and start animating once complete
    loader.load('./models/dino.json', function (geometry, materials) {


        // Get the geometry and materials from the JSON
        var dinoObject = new THREE.Mesh(geometry, new THREE.MultiMaterial(materials));

        // Scale the size of the dino
        dinoObject.scale.set(DINOSCALE, DINOSCALE, DINOSCALE);
        dinoObject.rotation.y = degreesToRadians(-90);
        dinoObject.position.set(30, 0, -400);
        dinoObject.name = "dino";
        scene.add(dinoObject);
        
        // Store the dino
        dino = scene.getObjectByName("dino"); 

        // Model is loaded, switch from "Loading..." to instruction text
        instructions.innerHTML = "<strong>Click to Play!</strong> </br></br> W,A,S,D or arrow keys = move </br>Mouse = look around";

        // Call the animate function so that animation begins after the model is loaded
        animate();
    });
```

---

<span data-ttu-id="c7529-269">これで、恐竜モデルが読み込まれました。</span><span class="sxs-lookup"><span data-stu-id="c7529-269">We now have our dino model loaded in.</span></span> <span data-ttu-id="c7529-270">ご確認ください。</span><span class="sxs-lookup"><span data-stu-id="c7529-270">Check it out!</span></span>

<iframe height='300' scrolling='no' title='<span data-ttu-id="c7529-271">恐竜を追加します。</span><span class="sxs-lookup"><span data-stu-id="c7529-271">Adding the dino</span></span>' src='//codepen.io/MicrosoftEdgeDocumentation/embed/xqOwBw/?height=300&theme-id=23761&default-tab=result&embed-version=2&editable=true' frameborder='no' allowtransparency='true' allowfullscreen='true' style='width: 100%;'><span data-ttu-id="c7529-272"><a href='https://codepen.io'>CodePen</a> で、Microsoft Edge Docs (<a href='https://codepen.io/MicrosoftEdgeDocumentation'>@MicrosoftEdgeDocumentation</a>) による Pen (<a href='https://codepen.io/MicrosoftEdgeDocumentation/pen/xqOwBw/'>Adding the dino</a>) をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c7529-272">See the Pen <a href='https://codepen.io/MicrosoftEdgeDocumentation/pen/xqOwBw/'>Adding the dino</a> by Microsoft Edge Docs (<a href='https://codepen.io/MicrosoftEdgeDocumentation'>@MicrosoftEdgeDocumentation</a>) on <a href='https://codepen.io'>CodePen</a>.</span></span>
</iframe>

### <a name="7-move-that-dino"></a><span data-ttu-id="c7529-273">7. 恐竜を動かす</span><span class="sxs-lookup"><span data-stu-id="c7529-273">7. Move that dino!</span></span>

<span data-ttu-id="c7529-274">ゲーム用に AI を作成するときわめて複雑になる可能性があるため、この例の恐竜には単純な動作を適用します。</span><span class="sxs-lookup"><span data-stu-id="c7529-274">Creating AI for a game can get extremely complex, so for this example we'll make this dino have a simple movement behavior.</span></span> <span data-ttu-id="c7529-275">今のところ、恐竜はまっすぐ移動し、そのまま壁を突き抜けていきます。</span><span class="sxs-lookup"><span data-stu-id="c7529-275">Our dino will move straight, slipping its way through walls and off into the distant fog.</span></span>

<span data-ttu-id="c7529-276">では、まずグローバル変数 `dinoVelocity` を追加します。</span><span class="sxs-lookup"><span data-stu-id="c7529-276">To do this, first add the global variable `dinoVelocity`.</span></span>

```javascript
var DINOSPEED = 400.0;

var dinoVelocity = new THREE.Vector3();
```
 <span data-ttu-id="c7529-277">次に、`animation()` 関数から `animateDino()` 関数を呼び出し、以下のコードを追加します。</span><span class="sxs-lookup"><span data-stu-id="c7529-277">Next, call the `animateDino()` function from the `animation()` function and add in the below code:</span></span>

```javascript
function animateDino(delta) {
    // Gradual slowdown
    dinoVelocity.x -= dinoVelocity.x * 10.0 * delta;
    dinoVelocity.z -= dinoVelocity.z * 10.0 * delta;

    dinoVelocity.z += DINOSPEED * delta;
    // Move the dino
    dino.translateZ(dinoVelocity.z * delta);
}
```
---

<span data-ttu-id="c7529-278">このままでは恐竜が消えるのを見守るだけですが、衝突検出機能を追加すると、もう少しおもしろくなります。</span><span class="sxs-lookup"><span data-stu-id="c7529-278">Watching the dino sail away isn't very fun, but once we add collision detection things will get more interesting.</span></span>

<iframe height='300' scrolling='no' title='<span data-ttu-id="c7529-279">Moving the - なし</span><span class="sxs-lookup"><span data-stu-id="c7529-279">Moving the dino - no collision</span></span>' src='//codepen.io/MicrosoftEdgeDocumentation/embed/preview/jBMbbL/?height=300&theme-id=23761&default-tab=result&embed-version=2&editable=true' frameborder='no' allowtransparency='true' allowfullscreen='true' style='width: 100%;'><span data-ttu-id="c7529-280"><a href='https://codepen.io'>CodePen</a> で、Microsoft Edge Docs (<a href='https://codepen.io/MicrosoftEdgeDocumentation'>@MicrosoftEdgeDocumentation</a>) による Pen (<a href='https://codepen.io/MicrosoftEdgeDocumentation/pen/jBMbbL/'>Moving the dino - no collision</a>) をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c7529-280">See the Pen <a href='https://codepen.io/MicrosoftEdgeDocumentation/pen/jBMbbL/'>Moving the dino - no collision</a> by Microsoft Edge Docs (<a href='https://codepen.io/MicrosoftEdgeDocumentation'>@MicrosoftEdgeDocumentation</a>) on <a href='https://codepen.io'>CodePen</a>.</span></span>
</iframe>

### <a name="8-collision-detection-for-the-player"></a><span data-ttu-id="c7529-281">8. プレイヤーの衝突を検出する</span><span class="sxs-lookup"><span data-stu-id="c7529-281">8. Collision detection for the player</span></span>

<span data-ttu-id="c7529-282">これで、プレイヤーと恐竜が動き回るようになりましたが、全員が壁をつきぬけてしまうという問題が残っています。</span><span class="sxs-lookup"><span data-stu-id="c7529-282">So we now have the player and the dino moving around, but there's still that annoying issue with everyone going through walls.</span></span> <span data-ttu-id="c7529-283">このチュートリアルで初めて立方体や壁の追加を始めたときは、`collidableObjects` 配列に配置しました。</span><span class="sxs-lookup"><span data-stu-id="c7529-283">When we first started adding our cubes and walls earlier in this tutorial, we pushed them into the `collidableObjects` array.</span></span> <span data-ttu-id="c7529-284">プレイヤーが何かに近すぎて通ることができない状態を判断するには、この配列を使用します。</span><span class="sxs-lookup"><span data-stu-id="c7529-284">This array is what we'll be using to tell if a player is too close to something they can't walk through.</span></span>

<span data-ttu-id="c7529-285">交差が発生するタイミングを判断するには、Raycaster を使用します。</span><span class="sxs-lookup"><span data-stu-id="c7529-285">We'll be using raycasters to determine when an intersection is about to occur.</span></span> <span data-ttu-id="c7529-286">Raycaster は、カメラから指定の角度で出ているレーザー ビームのようなものと考えることができます。Raycaster では、物に当たったかどうかという情報と正確な距離が返されます。</span><span class="sxs-lookup"><span data-stu-id="c7529-286">You could imagine a raycaster as a laser beam coming out of the camera at some specified direction, reporting back if it hit an object and exactly how far away it is.</span></span>

```javascript
var PLAYERCOLLISIONDISTANCE = 20;
```

<span data-ttu-id="c7529-287">新しい関数として `detectPlayerCollision()` を作成しますが、この関数では、プレイヤーがオブジェクトに当たるほど近い場合は `true` が返されます。</span><span class="sxs-lookup"><span data-stu-id="c7529-287">We'll be making a new function called `detectPlayerCollision()` that will return `true` if the player is too close to a collidable object.</span></span>
<span data-ttu-id="c7529-288">プレイヤー用には 1 つの Raycaster を適用し、プレイヤーの進行方向に応じて方向を変更します。</span><span class="sxs-lookup"><span data-stu-id="c7529-288">For the player, we're going to apply one raycaster to it, changing which direction it's pointing depending on which direction they're going.</span></span>

<span data-ttu-id="c7529-289">これを行うには、未定義のマトリックス `rotationMatrix` を作成します。</span><span class="sxs-lookup"><span data-stu-id="c7529-289">To do this, we create `rotationMatrix`, an undefined matrix.</span></span> <span data-ttu-id="c7529-290">進行方向を確認し、定義された `rotationMatrix` を使用するか、前進する場合は未定義のマトリックスを使用します。</span><span class="sxs-lookup"><span data-stu-id="c7529-290">As we check which direction we're going, we'll end up with either a defined `rotationMatrix`, or undefined if you're moving forward.</span></span>
<span data-ttu-id="c7529-291">定義されている場合、コントロールの方向に `rotationMatrix` が適用されます。</span><span class="sxs-lookup"><span data-stu-id="c7529-291">If defined, the `rotationMatrix` will be applied to the direction of the controls.</span></span> 

<span data-ttu-id="c7529-292">次に、カメラから `cameraDirection` 方向へ向かう Raycaster が作成されます。</span><span class="sxs-lookup"><span data-stu-id="c7529-292">A raycaster will then be created, starting from and camera and reaching out in the `cameraDirection` direction.</span></span>


```javascript
function detectPlayerCollision() {
    // The rotation matrix to apply to our direction vector
    // Undefined by default to indicate ray should coming from front
    var rotationMatrix;
    // Get direction of camera
    var cameraDirection = controls.getDirection(new THREE.Vector3(0, 0, 0)).clone();

    // Check which direction we're moving (not looking)
    // Flip matrix to that direction so that we can reposition the ray
    if (moveBackward) {
        rotationMatrix = new THREE.Matrix4();
        rotationMatrix.makeRotationY(degreesToRadians(180));
    }
    else if (moveLeft) {
        rotationMatrix = new THREE.Matrix4();
        rotationMatrix.makeRotationY(degreesToRadians(90));
    }
    else if (moveRight) {
        rotationMatrix = new THREE.Matrix4();
        rotationMatrix.makeRotationY(degreesToRadians(270));
    }

    // Player is not moving forward, apply rotation matrix needed
    if (rotationMatrix !== undefined) {
        cameraDirection.applyMatrix4(rotationMatrix);
    }

    // Apply ray to player camera
    var rayCaster = new THREE.Raycaster(controls.getObject().position, cameraDirection);

    // If our ray hit a collidable object, return true
    if (rayIntersect(rayCaster, PLAYERCOLLISIONDISTANCE)) {
        return true;
    } else {
        return false;
    }
}
```

<span data-ttu-id="c7529-293">`detectPlayerCollision()` 関数は、`rayIntersect()` ヘルパー関数に依存しています。</span><span class="sxs-lookup"><span data-stu-id="c7529-293">Our `detectPlayerCollision()` function relies on the `rayIntersect()` helper function.</span></span>
<span data-ttu-id="c7529-294">衝突が発生したと判断するには、Raycaster のほか、`collidableObjects` 配列に格納されているオブジェクトにどの程度近付くことができるかを表した値が必要です。</span><span class="sxs-lookup"><span data-stu-id="c7529-294">This takes a raycaster and value representing how close we can get to an object in the `collidableObjects` array before determining a collision has occured.</span></span>

```javascript
function rayIntersect(ray, distance) {
    var intersects = ray.intersectObjects(collidableObjects);
    for (var i = 0; i < intersects.length; i++) {
        // Check if there's a collision
        if (intersects[i].distance < distance) {
            return true;
        }
    }
    return false;
}
```

<span data-ttu-id="c7529-295">これで、衝突がいつ発生するかを判断できるようになったため、`animatePlayer()` 関数を仕上げることができます。</span><span class="sxs-lookup"><span data-stu-id="c7529-295">Now that we can determine when a collision is about to occur, we can spruce up our `animatePlayer()` function:</span></span>

```javascript
function animatePlayer(delta) {
    // Gradual slowdown
    playerVelocity.x -= playerVelocity.x * 10.0 * delta;
    playerVelocity.z -= playerVelocity.z * 10.0 * delta;

    // If no collision and a movement key is being pressed, apply movement velocity
    if (detectPlayerCollision() == false) {
        if (moveForward) {
            playerVelocity.z -= PLAYERSPEED * delta;
        }
        if (moveBackward) {
            playerVelocity.z += PLAYERSPEED * delta;
        } 
        if (moveLeft) {
            playerVelocity.x -= PLAYERSPEED * delta;
        }
        if (moveRight) {
            playerVelocity.x += PLAYERSPEED * delta;
        }

        controls.getObject().translateX(playerVelocity.x * delta);
        controls.getObject().translateZ(playerVelocity.z * delta);
    } else {
        // Collision or no movement key being pressed. Stop movememnt
        playerVelocity.x = 0;
        playerVelocity.z = 0;
    }
}
```

---

<span data-ttu-id="c7529-296">プレイヤーの衝突も検出できるので、何か所かの壁に突き当たってみてください。</span><span class="sxs-lookup"><span data-stu-id="c7529-296">We now have player collision detection, so go ahead and try to run into some walls!</span></span>

<iframe height='300' scrolling='no' title='<span data-ttu-id="c7529-297">します player-collision</span><span class="sxs-lookup"><span data-stu-id="c7529-297">Moving the player - collision</span></span>' src='//codepen.io/MicrosoftEdgeDocumentation/embed/preview/qraOeO/?height=300&theme-id=23761&default-tab=result&embed-version=2&editable=true' frameborder='no' allowtransparency='true' allowfullscreen='true' style='width: 100%;'><span data-ttu-id="c7529-298"><a href='https://codepen.io'>CodePen</a> で、Microsoft Edge Docs (<a href='https://codepen.io/MicrosoftEdgeDocumentation'>@MicrosoftEdgeDocumentation</a>) による Pen (<a href='https://codepen.io/MicrosoftEdgeDocumentation/pen/qraOeO/'>Moving the player - collision</a>) をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c7529-298">See the Pen <a href='https://codepen.io/MicrosoftEdgeDocumentation/pen/qraOeO/'>Moving the player - collision</a> by Microsoft Edge Docs (<a href='https://codepen.io/MicrosoftEdgeDocumentation'>@MicrosoftEdgeDocumentation</a>) on <a href='https://codepen.io'>CodePen</a>.</span></span>
</iframe>


### <a name="9-collision-detection-and-animation-for-dino"></a><span data-ttu-id="c7529-299">9. 衝突の検出と恐竜のアニメーション</span><span class="sxs-lookup"><span data-stu-id="c7529-299">9. Collision detection and animation for dino</span></span>

<span data-ttu-id="c7529-300">ここで、恐竜が壁を突き抜ける動作を修正し、衝突可能なオブジェクトに近付き過ぎた場合はランダムな方向に進むようにしましょう。</span><span class="sxs-lookup"><span data-stu-id="c7529-300">It's time to stop our dino from moving through walls, and instead have it go a random direction once it's too close to a collidable object.</span></span>

<span data-ttu-id="c7529-301">まず、恐竜がいつ衝突するかを把握しましょう。</span><span class="sxs-lookup"><span data-stu-id="c7529-301">First let's figure out when our dino has a collision.</span></span> 

<span data-ttu-id="c7529-302">衝突の距離用に、グローバル変数をもう 1 つ設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c7529-302">We'll need to set anothe global variable for the collision distance:</span></span>

```javascript
var DINOCOLLISIONDISTANCE = 55;     
```

<span data-ttu-id="c7529-303">恐竜にどの程度近付くと衝突が発生するかを指定したので、`detectPlayerCollision()` に似ていてもう少し単純な関数を追加しましょう。</span><span class="sxs-lookup"><span data-stu-id="c7529-303">Now that we've specifed at what distance we want our dino to collide at, let's add a function similar to `detectPlayerCollision()`, but a bit simpler.</span></span>
<span data-ttu-id="c7529-304">`detectDinoCollision` 関数は、常に恐竜の中央から 1 つの Raycasterがまっすぐ出ているという点で単純です。</span><span class="sxs-lookup"><span data-stu-id="c7529-304">The `detectDinoCollision` function is simple in that we always have one raycaster coming straight out the front of the dino.</span></span> <span data-ttu-id="c7529-305">プレイヤーの衝突のように、回転させる必要はありません。</span><span class="sxs-lookup"><span data-stu-id="c7529-305">No need to rotate it around like for the player collision.</span></span>

```javascript
function detectDinoCollision() {
    // Get the rotation matrix from dino
    var matrix = new THREE.Matrix4();
    matrix.extractRotation(dino.matrix);
    // Create direction vector
    var directionFront = new THREE.Vector3(0, 0, 1);

    // Get the vectors coming from the front of the dino
    directionFront.applyMatrix4(matrix);

    // Create raycaster
    var rayCasterF = new THREE.Raycaster(dino.position, directionFront);
    // If we have a front collision, we have to adjust our direction so return true
    if (rayIntersect(rayCasterF, DINOCOLLISIONDISTANCE))
        return true;
    else
        return false;
}
```

<span data-ttu-id="c7529-306">では、衝突検出機能を組み込んだ最終的な `animateDino()` 関数がどのようなものか、見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="c7529-306">Let's take a peek at what our final `animateDino()` function will look like when hooked up with collision detection:</span></span>


```javascript
function animateDino(delta) {
    // Gradual slowdown
    dinoVelocity.x -= dinoVelocity.x * 10.0 * delta;
    dinoVelocity.z -= dinoVelocity.z * 10.0 * delta;


    // If no collision, apply movement velocity
    if (detectDinoCollision() == false) {
        dinoVelocity.z += DINOSPEED * delta;
        // Move the dino
        dino.translateZ(dinoVelocity.z * delta);

    } else {
        // Collision. Adjust direction
        var directionMultiples = [-1, 1, 2];
        var randomIndex = getRandomInt(0, 2);
        var randomDirection = degreesToRadians(90 * directionMultiples[randomIndex]);

        dinoVelocity.z += DINOSPEED * delta;
        dino.rotation.y += randomDirection;
    }
}
```

<span data-ttu-id="c7529-307">恐竜の方向転換は、常に -90 度、90 度、180 度のいずれかです。</span><span class="sxs-lookup"><span data-stu-id="c7529-307">We always want our dino to turn either -90, 90, or 180 degrees.</span></span> <span data-ttu-id="c7529-308">これを単純化するために、上のコードでは `directionMultiples` 配列を使用し、90 の倍数としてこれらの数値を生成しています。</span><span class="sxs-lookup"><span data-stu-id="c7529-308">To make this straight forward, above we've made the `directionMultiples` array which will produce these numbers when multiplied by 90.</span></span>
<span data-ttu-id="c7529-309">回転角度がランダムに選択されるようにするために、ヘルパー関数として `getRandomInt()` を追加しました。この関数では、配列のランダム インデックスを表す値 0、1、または 2 を取得します。</span><span class="sxs-lookup"><span data-stu-id="c7529-309">To make selecting the rotation degrees random, we've added the `getRandomInt()` helper function to grab a value of 0, 1, or 2, which will represent a random index of the array.</span></span>

```javascript
function getRandomInt(min, max) {
    min = Math.ceil(min);
    max = Math.floor(max);
    return Math.floor(Math.random() * (max - min)) + min;
}
```

<span data-ttu-id="c7529-310">これらがすべて完了したら、配列のランダム インデックスに 90 を掛けて、回転角度 (ラジアンに変換した値) を取得します。</span><span class="sxs-lookup"><span data-stu-id="c7529-310">Once this is all done, we multiply the random index of the array by 90 to get the degree (converted to radians) of rotation.</span></span>
<span data-ttu-id="c7529-311">この値を恐竜の `y` 回転に加算することによって (`dino.rotation.y += randomDirection;`)、恐竜は衝突時にランダムに回転するようになります。</span><span class="sxs-lookup"><span data-stu-id="c7529-311">By adding this value to the dino's `y` rotation with `dino.rotation.y += randomDirection;`, the dino now makes random turns upon collision.</span></span>


---

<span data-ttu-id="c7529-312">これで、</span><span class="sxs-lookup"><span data-stu-id="c7529-312">We did it!</span></span> <span data-ttu-id="c7529-313">AI を持った恐竜が、迷路を動き回るようになりました。</span><span class="sxs-lookup"><span data-stu-id="c7529-313">We now have a dino with AI that can move around our maze!</span></span>

<iframe height='300' scrolling='no' title='<span data-ttu-id="c7529-314">Moving、</span><span class="sxs-lookup"><span data-stu-id="c7529-314">Moving the dino - collision</span></span>' src='//codepen.io/MicrosoftEdgeDocumentation/embed/preview/bqwMXZ/?height=300&theme-id=23761&default-tab=result&embed-version=2&editable=true' frameborder='no' allowtransparency='true' allowfullscreen='true' style='width: 100%;'><span data-ttu-id="c7529-315">ペン<a href='https://codepen.io/MicrosoftEdgeDocumentation/pen/bqwMXZ/'>Moving the -</a>で、Microsoft Edge Docs を参照してください (<a href='https://codepen.io/MicrosoftEdgeDocumentation'>@MicrosoftEdgeDocumentation</a>) <a href='https://codepen.io'>CodePen</a>でします。</span><span class="sxs-lookup"><span data-stu-id="c7529-315">See the Pen <a href='https://codepen.io/MicrosoftEdgeDocumentation/pen/bqwMXZ/'>Moving the dino - collision</a> by Microsoft Edge Docs (<a href='https://codepen.io/MicrosoftEdgeDocumentation'>@MicrosoftEdgeDocumentation</a>) on <a href='https://codepen.io'>CodePen</a>.</span></span>
</iframe>

### <a name="10-starting-the-chase"></a><span data-ttu-id="c7529-316">10. 追随を開始する</span><span class="sxs-lookup"><span data-stu-id="c7529-316">10. Starting the chase</span></span>

<span data-ttu-id="c7529-317">ここで、恐竜がプレイヤーから一定の範囲内に入った場合はプレイヤーに追随するようにセットアップします。</span><span class="sxs-lookup"><span data-stu-id="c7529-317">Once the dino is within a certain distance to the player, we want it to start chasing them.</span></span> <span data-ttu-id="c7529-318">ここに示すのは単なる例であるため、プレイヤーを追い詰めるための高度なアルゴリズムは適用されていません。</span><span class="sxs-lookup"><span data-stu-id="c7529-318">Since this is just an example, there aren't any advanced algorithms applied for the dino to track the player down.</span></span> <span data-ttu-id="c7529-319">代わりに、恐竜はプレイヤーを見て、歩いて追随します。</span><span class="sxs-lookup"><span data-stu-id="c7529-319">Instead, the dino will look at the player and walk towards them.</span></span> <span data-ttu-id="c7529-320">迷路内で通ることのできる部分では、これが正しく機能しますが、進行方向に壁があると恐竜はぶつかってしまいます。</span><span class="sxs-lookup"><span data-stu-id="c7529-320">In an open part of the maze this works great, but the dino does get stuck when a wall is in the way.</span></span>

<span data-ttu-id="c7529-321">これに対処するため、`animate()` 関数に、`triggerChase()` から返された値によって決定されるブール変数を追加します。</span><span class="sxs-lookup"><span data-stu-id="c7529-321">In our `animate()` function we'll add a boolean variable that is determined by what is returned by `triggerChase()`:</span></span>

```javascript
function animate() {
    render();
    requestAnimationFrame(animate);

    // Get the change in time between frames
    var delta = clock.getDelta();

    // If the player is in dino's range, trigger the chase
    var isBeingChased = triggerChase();

    animateDino(delta);
    animatePlayer(delta);
}
```

<span data-ttu-id="c7529-322">`triggerChase` 関数では、恐竜の追随範囲にプレイヤーがいるかどうかを確認し、恐竜が常にプレイヤーに向くように設定します。これにより、恐竜がプレイヤー方向に移動できます。</span><span class="sxs-lookup"><span data-stu-id="c7529-322">Our `triggerChase` function will check to see if the player is in chasing range of the dino, and then make the dino always face the player, which allows it to move in the player's direction.</span></span> 

```javascript
function triggerChase() {
    // Check if in dino detection range of the player
    if (dino.position.distanceTo(controls.getObject().position) < 300) {
        // Set the dino target's y value to the current y value. We only care about x and z for movement.
        var lookTarget = new THREE.Vector3();
        lookTarget.copy(controls.getObject().position);
        lookTarget.y = dino.position.y;

        // Make dino face camera
        dino.lookAt(lookTarget);

        // Get distance between dino and camera with a unit offset
        // Game over when dino is the value of CATCHOFFSET units away from camera
        var distanceFrom = Math.round(dino.position.distanceTo(controls.getObject().position)) - CATCHOFFSET;
        // Alert and display distance between camera and dino
        dinoAlert.innerHTML = "Dino has spotted you! Distance from you: " + distanceFrom;
        dinoAlert.style.display = '';
        return true;
        // Not in agro range, don't start distance countdown
    } else {
        dinoAlert.style.display = 'none';
        return false;
    }
}
```

<span data-ttu-id="c7529-323">`triggerChase` の後半では、恐竜からどの程度離れているかをプレイヤーに知らせるテキストの表示処理を行います。</span><span class="sxs-lookup"><span data-stu-id="c7529-323">The second half of `triggerChase` deals with displaying some text that lets the player know how far away the dino is.</span></span> <span data-ttu-id="c7529-324">また、`CATCHOFFSET` を使用して、`0` の距離を指定します。</span><span class="sxs-lookup"><span data-stu-id="c7529-324">We also introduce `CATCHOFFSET` to specify how far away `0` should be.</span></span> <span data-ttu-id="c7529-325">オフセットがなければ、`0` はプレイヤーに重なり、視覚的に印象的な終わり方になりません。</span><span class="sxs-lookup"><span data-stu-id="c7529-325">If we didn't have the offset, `0` would be right on top of the player which doesn't make for a very cinematic end to all this.</span></span>



```javascript
var dinoAlert = document.getElementById('dino-alert');
dinoAlert.style.display = 'none';
```

---

<span data-ttu-id="c7529-326">今の時点では、気の荒い恐竜はプレイヤーが近くなると追随を始め、プレイヤーの位置になるまで止まりません。</span><span class="sxs-lookup"><span data-stu-id="c7529-326">At this point we have a wild dinosaur that starts following the player once you get too close, and doesn't stop until it's position is on top of the player.</span></span>
<span data-ttu-id="c7529-327">最後の手順では、恐竜までの距離が `CATCHOFFSET` 単位になったらゲーム オーバー状態を追加します。</span><span class="sxs-lookup"><span data-stu-id="c7529-327">The final step is to add some game over conditions once the dino is `CATCHOFFSET` units away.</span></span>

<iframe height='300' scrolling='no' title='<span data-ttu-id="c7529-328">追随</span><span class="sxs-lookup"><span data-stu-id="c7529-328">The chase</span></span>' src='//codepen.io/MicrosoftEdgeDocumentation/embed/preview/NpRBqR/?height=300&theme-id=23761&default-tab=result&embed-version=2&editable=true' frameborder='no' allowtransparency='true' allowfullscreen='true' style='width: 100%;'><span data-ttu-id="c7529-329"><a href='https://codepen.io'>CodePen</a> で、Microsoft Edge Docs (<a href='https://codepen.io/MicrosoftEdgeDocumentation'>@MicrosoftEdgeDocumentation</a>) による Pen (<a href='https://codepen.io/MicrosoftEdgeDocumentation/pen/NpRBqR/'>The chase</a>) をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c7529-329">See the Pen <a href='https://codepen.io/MicrosoftEdgeDocumentation/pen/NpRBqR/'>The chase</a> by Microsoft Edge Docs (<a href='https://codepen.io/MicrosoftEdgeDocumentation'>@MicrosoftEdgeDocumentation</a>) on <a href='https://codepen.io'>CodePen</a>.</span></span>
</iframe>


### <a name="11-ending-the-game"></a><span data-ttu-id="c7529-330">11. ゲームを終了する</span><span class="sxs-lookup"><span data-stu-id="c7529-330">11. Ending the game</span></span>


<span data-ttu-id="c7529-331">単純な立方体から長い道のりでしたが、終了の操作に取り掛かりましょう。</span><span class="sxs-lookup"><span data-stu-id="c7529-331">We've come a long away from a simple cube, and now it's time to end things.</span></span>

<span data-ttu-id="c7529-332">まず、ゲーム オーバーかどうかを追跡するための変数を設定しましょう。</span><span class="sxs-lookup"><span data-stu-id="c7529-332">Let's first set a variable to keep track of whether the game is over or not:</span></span>

```javascript
var gameOver = false;
```

<span data-ttu-id="c7529-333">最後にもう一度だけ `animate()` 関数を更新して、恐竜がプレイヤーに近付きすぎていないか確認できるようにします。</span><span class="sxs-lookup"><span data-stu-id="c7529-333">Now we need to update our `animate()` function one last time to check if the dino is too close to the player.</span></span>
<span data-ttu-id="c7529-334">恐竜が近すぎる場合は、`caught()` という新しい関数を呼び出して、プレイヤーと恐竜の動作を停止します。そうでない場合は、プレイヤーと恐竜が動き回れる状態で通常の動作を継続します。</span><span class="sxs-lookup"><span data-stu-id="c7529-334">If the dino is too close, we'll start a new function called `caught()` and will stop the player and dino from moving, if not, we'll carry on with business as usual and let the player and dino move around.</span></span>

```javascript
function animate() {
    render();
    requestAnimationFrame(animate);

    // Get the change in time between frames
    var delta = clock.getDelta();
    // Update our frames per second monitor

    // If the player is in dino's range, trigger the chase
    var isBeingChased = triggerChase();
    // If the player is too close, trigger the end of the game
    if (dino.position.distanceTo(controls.getObject().position) < CATCHOFFSET) {
        caught();
    // Player is at an undetected distance
    // Keep the dino moving and let the player keep moving too
    } else {
        animateDino(delta);
        animatePlayer(delta);
    }
}
```

<span data-ttu-id="c7529-335">プレイヤーが恐竜につかまった場合は、`caught()` によって `blocker` 要素が表示され、ゲームに負けたことを示すテキストに更新されます。</span><span class="sxs-lookup"><span data-stu-id="c7529-335">If the dino catches the player, `caught()` will display our `blocker` element and update the text to indicate that the game has been lost.</span></span>
<span data-ttu-id="c7529-336">`gameOver` 変数も、ゲーム オーバーを示す `true` に設定されます。</span><span class="sxs-lookup"><span data-stu-id="c7529-336">The `gameOver` variable is also set to `true`, which now lets us know the game is over.</span></span>  


```javascript
function caught() {
    blocker.style.display = '';
    instructions.innerHTML = "GAME OVER </br></br></br> Press ESC to restart";
    gameOver = true;
    instructions.style.display = '';
    dinoAlert.style.display = 'none';
}
```


<span data-ttu-id="c7529-337">ゲーム オーバーかどうかがわかるようになったため、ゲーム オーバーのチェックを `lockChange()` 関数に追加できます。</span><span class="sxs-lookup"><span data-stu-id="c7529-337">Now that we know whether the game is over or not, we can add a check for game over to our `lockChange()` function.</span></span>
<span data-ttu-id="c7529-338">ゲームが終了してユーザーによって Esc キーを押されたら、`location.reload` を追加してゲームを再起動できます。</span><span class="sxs-lookup"><span data-stu-id="c7529-338">Now when the user presses ESC once the game is over, we can add `location.reload` to restart the game.</span></span>

```javascript
function lockChange() {
    if (document.pointerLockElement === container) {
        blocker.style.display = "none";
        controls.enabled = true;
    } else {
        if (gameOver) {
            location.reload();
        }
        blocker.style.display = "";
        controls.enabled = false;
    }
}
```

---

<span data-ttu-id="c7529-339">以上で作業は終了です。</span><span class="sxs-lookup"><span data-stu-id="c7529-339">That's it!</span></span> <span data-ttu-id="c7529-340">長い道のりでしたが、**three.js** でゲームを作成できました。</span><span class="sxs-lookup"><span data-stu-id="c7529-340">It was quite the journey, but we now have a game made with **three.js**.</span></span>

<span data-ttu-id="c7529-341">[最終的な CodePen](#introduction) は、ページの上部から確認できます。</span><span class="sxs-lookup"><span data-stu-id="c7529-341">Head back up to the top of the page to see the [final CodePen](#introduction)!</span></span>


## <a name="publishing-to-the-microsoft-store"></a><span data-ttu-id="c7529-342">Microsoft Store への公開</span><span class="sxs-lookup"><span data-stu-id="c7529-342">Publishing to the Microsoft Store</span></span>
<span data-ttu-id="c7529-343">UWP アプリがある場合は、ここでは、(もう少し改善が最初に!)、Microsoft Store に申請を公開することもできます。プロセスにいくつかの手順があります。</span><span class="sxs-lookup"><span data-stu-id="c7529-343">Now you have a UWP app, it is possible to publish it to the Microsoft Store (assuming you have improved it first!) There are a few steps to the process.</span></span>

1.  <span data-ttu-id="c7529-344">Windows 開発者として[登録](https://developer.microsoft.com/store/register)する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c7529-344">You must be [registered](https://developer.microsoft.com/store/register) as a Windows Developer.</span></span>
2.  <span data-ttu-id="c7529-345">アプリの申請[チェックリスト](https://msdn.microsoft.com/windows/uwp/publish/app-submissions)を使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c7529-345">You must use the app submission [checklist](https://msdn.microsoft.com/windows/uwp/publish/app-submissions).</span></span>
3.  <span data-ttu-id="c7529-346">[認定](https://msdn.microsoft.com/windows/uwp/publish/the-app-certification-process)を受けるために、アプリを提出する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c7529-346">The app must be submitted for [certification](https://msdn.microsoft.com/windows/uwp/publish/the-app-certification-process).</span></span>
<span data-ttu-id="c7529-347">詳細については、 [UWP アプリの公開](https://developer.microsoft.com/store/publish-apps)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="c7529-347">For more details, see [Publishing your UWP app](https://developer.microsoft.com/store/publish-apps).</span></span>

