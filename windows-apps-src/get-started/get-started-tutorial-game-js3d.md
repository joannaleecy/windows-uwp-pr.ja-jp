---
title: 入門チュートリアル - 3D UWP ゲーム (JavaScript)
description: JavaScript と three.js で記述された Microsoft Store 向けの UWP ゲーム
author: abbycar
ms.author: abigailc
ms.date: 03/06/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.assetid: fb4249b2-f93c-4993-9e4d-57a62c04be66
ms.localizationpriority: medium
ms.openlocfilehash: fa3722c5b011d16ca793b3541efe124b7c255dfd
ms.sourcegitcommit: e16c9845b52d5bd43fc02bbe92296a9682d96926
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/19/2018
ms.locfileid: "4961332"
---
# <a name="creating-a-3d-javascript-game-using-threejs"></a>hree.js を使用して 3D JavaScript ゲームを作成する

## <a name="introduction"></a>はじめに

Web 開発者や JavaScript 作者にとって、JavaScript で UWP アプリを開発することは、作成したアプリを世界中に向けて公開するための簡単な方法です。 C# や C++ のような言語を学習する必要はありません。

このサンプルでは、**three.js** ライブラリを活用します。 このライブラリは、WebGL から構築されています。WebGL は、Web ブラウザー用に 2D/3D のグラフィックスをレンダリングするために使用する API です。 **three.js** は、この複雑な API を単純化したもので、これを使用すると 3D 開発がずっと容易になります。 


先に進む前に、これから作成するアプリを見ておきましょう。 CodePen で確認してください。

<iframe height='300' scrolling='no' title='Game final' src='//codepen.io/MicrosoftEdgeDocumentation/embed/preview/NpKejy/?height=300&theme-id=23761&default-tab=result&embed-version=2&editable=true' frameborder='no' allowtransparency='true' allowfullscreen='true' style='width: 100%;'><a href='https://codepen.io'>CodePen</a> で、Microsoft Edge Docs (<a href='https://codepen.io/MicrosoftEdgeDocumentation'>@MicrosoftEdgeDocumentation</a>) による Pen (<a href='https://codepen.io/MicrosoftEdgeDocumentation/pen/NpKejy/'>Dino game final</a>) をご覧ください。
</iframe>

> [!NOTE] 
> ない、完全なゲームです。JavaScript やサード パーティのライブラリを使用してアプリを Microsoft Store に公開する準備が方法を示すために設計されています。


## <a name="requirements"></a>要件

このプロジェクトを操作するには、以下が必要になります。
-   現在のバージョンの Windows 10 を実行する Windows コンピューター (または仮想マシン)。
-   Visual Studio。 無料の Visual Studio Community Edition は、[Visual Studio ホームページ](http://visualstudio.com/)からダウンロードできます。
このプロジェクトでは、**three.js** という JavaScript ライブラリを使用します。 **three.js** は、MIT ライセンスの下でリリースされています。 このライブラリは、プロジェクト内に既に存在します (ソリューション エクスプローラー ビューで `js/libs` を探してください)。 このライブラリについて詳しくは、[**three.js**](https://threejs.org/) のホーム ページをご覧ください。

## <a name="getting-started"></a>はじめに

アプリの完全なソース コードは、[GitHub](https://github.com/Microsoft/Windows-appsample-get-started-js3d) にあります。

最も簡単に始める方法は、GitHub のページで、緑色の [Clone or download] (複製またはダウンロード) ボタンをクリックし、[Open in Visual Studio] (Visual Studio で開く) を選択することです。 

![[Clone or download] (複製またはダウンロード) ボタン](images/3dclone.png)

プロジェクトを複製しない場合は、zip ファイルとしてダウンロードすることもできます。
ソリューションを Visual Studio に読み込むと、次のようなファイルが表示されます。
-   Images/ - UWP アプリに必要なさまざまなアイコンが含まれるフォルダー。
- css/ - 使用する CSS が含まれるフォルダー。
-   js/ - JavaScript ファイルが含まれるフォルダー。 main.js ファイルはゲームで、他のファイルはサード パーティ製ライブラリです。
-   models/ - 3D モデルが含まれるフォルダー。 このゲームでは、恐竜を 1 匹のみ使用します。
-   Index.html - ゲームのレンダラーをホストする Web ページです。

これでゲームを実行できます。

F5 キーを押してアプリを起動します。 ウィンドウが開き、画面上をクリックするよう求められます。 また、背景で動き回る恐竜も見えます。 ゲームを閉じて、アプリと主要なコンポーネントを調べましょう。

> [!NOTE] 
> うまくいかない場合は、 Web サポートを含めて Visual Studio がインストールされていることを確認してください。 これは、新しいプロジェクトを作成することで確認できます。JavaScript のサポートが含まれていない場合は、[Microsoft Web Developer Tools] ボックスをオンにして Visual Studio を再インストールする必要があります。

## <a name="walkthrough"></a>チュートリアル

このゲームを開始すると、画面上をクリックするよう求めるメッセージが表示されます。 マウスで位置を探すことができるように、[Pointer Lock API](https://developer.mozilla.org/docs/Web/API/Pointer_Lock_API) が使用されています。 移動は、W キー、A キー、S キー、D キー、方向キーを押すことで操作できます。
このゲームの目的は、恐竜から常に離れていることです。 恐竜は、十分近くなると、圏外に出るか近付きすぎてゲームに負けるまで、プレイヤーを追いかけ始めます。

### <a name="1-setting-up-your-initial-html-file"></a>1. 初期 HTML ファイルをセットアップする

最初に、小さな HTML を **index.html** 内に追加します。 このファイルは、アプリが含まれる既定の Web ページです。

ここでは、使用するライブラリと、グラフィックスの表示先として使用する `div` (名前: `container`) でセットアップします また、**main.js** (ゲーム コード) がポイントされるように指定しておきます。


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


スターター HTML を準備できたので、**main.js** に移動し、いくつかのグラフィックスを作成しましょう。

### <a name="2-creating-your-scene"></a>2. シーンを作成する

このセクションでは、ゲームの基盤を追加します。

それでは、`scene` の肉付けから始めましょう。 **three.js** の `scene` は、カメラ、オブジェクト、光源を追加する場所です。 カメラが認識したものをシーンに反映して表示するためのレンダラーも必要です。

これらはすべて、**main.js** 内の `init()` という関数で行います。ここでは他の関数も呼び出されます。

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

他の関数として、以下を作成する必要があります。
- `createMazeCubes()`
- `addLights()`
- `onWindowResize()`
- `animate()` / `render()`
- 単位変換関数

#### <a name="createmazecubes"></a>createMazeCubes()

`createMazeCubes()` 関数は、単純な立方体をシーンに追加します。 この関数では、後で多数の立方体を追加して迷路を作成します。

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

#### <a name="addlights"></a>addLights()

`addLights()` 関数は、光源の作成をグループ化してシーンに追加する単純な関数です。

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

#### <a name="onwindowresize"></a>onWindowResize()

`onWindowResize` 関数は、`resize` イベントの発生をイベント リスナーが認識するたびに呼び出されます。 このイベントは、ユーザーがウィンドウのサイズを調整するたびに発生します。 このとき、画像の縦横比が維持され、ウィンドウ全体に表示できることを確認する必要があります。

```javascript
function onWindowResize() {

  camera.aspect = window.innerWidth / window.innerHeight;
  camera.updateProjectionMatrix();

  renderer.setSize(window.innerWidth, window.innerHeight);
}
```

#### <a name="animate"></a>animate()

最後に必要になるのが `animate()` 関数です。この関数からは、`render()` 関数も呼び出されます。 レンダラーを定期的に更新するためには、[`requestAnimationFrame()`](https://developer.mozilla.org/docs/Web/API/window/requestAnimationFrame) 関数を使用します。 後で、これらの関数を使ってレンダラーを更新し、迷路内の移動などのアニメーションを追加します。

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

#### <a name="unit-conversion-functions"></a>単位変換関数

**three.js** では、回転の単位としてラジアンが使用されています。 このため、度とラジアンの変換を簡単に処理できるように、必要な関数を追加します。 


```javascript
function degreesToRadians(degrees) {
  return degrees * Math.PI / 180;
}

function radiansToDegrees(radians) {
  return radians * 180 / Math.PI;
}
```

30 度が 0.523 ラジアンであることは覚えにくいので、 代わりに `degreesToRadians(30)` を実行して回転角度を取得する方が簡単です。これを `createMazeCubes()` 関数内で使用します。

___

さまざまなコードを使いましたが、これできちんと立方体を `container` に表示できました。 結果を CodePen で確認してください。

問題が発生した場合や、光源の調整または色の変更を行う場合は、この CodePen で提供されている JavaScript をすべてコピーして貼り付けることで、対処できます。 

<iframe height='300' scrolling='no' title='ライト、カメラ、立方体です。' src='//codepen.io/MicrosoftEdgeDocumentation/embed/YZWygZ/?height=300&theme-id=23761&default-tab=result&embed-version=2&editable=true' frameborder='no' allowtransparency='true' allowfullscreen='true' style='width: 100%;'>ペンを参照してください<a href='https://codepen.io/MicrosoftEdgeDocumentation/pen/YZWygZ/'>ライト、カメラ、立方体!</a> Microsoft Edge Docs (<a href='https://codepen.io/MicrosoftEdgeDocumentation'>@MicrosoftEdgeDocumentation</a>) <a href='https://codepen.io'>CodePen</a>でします。
</iframe>


### <a name="3-making-the-maze"></a>3. 迷路を作成する

立方体を表示できたので、次は立方体でできた迷路全体を表示してみましょう。 ゲーム コミュニティではよく知られた手法ですが、レベルを最短時間で作成する手法の 1 つは、2D 配列によって立方体を全体に配置することです。
 
![2D 配列で作成された迷路](images/dinomap.png)

立方体の場所に 1 を配置して空白の場所に 0 を配置すると、迷路を手動で簡単に作成または調整できます。

これには、元の `createMazeCubes()` 関数に、複数の立方体を作成および配置するための入れ子になったループを追加します。 また、`collidableObjects` という名前の配列を作成して、立方体を追加します。これは、後で衝突を検出するために使用します。

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

使用する立方体の数 (およびその大きさ) が決まったため、計算された `mapSize` 変数を使用して、グループ化された平面の寸法を設定できます。

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

迷路に追加する最後の部分は、すべてを囲む外周の壁です。 ループを使用して、一度に 2 つの平面 (壁) を作成します。幅を決定するには、`createGround()` で計算した `mapSize` 変数を使用します。 新しい壁は、衝突の検出用に `collidableObjects` 配列にも追加されます。

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


`createGround()` と `createPerimWalls` を正しくコンパイルするには、`init()` 関数内で、`createMazeCubes()` の後にこれらを呼び出すことを忘れないでください。
___

これで立派な迷路を表示できましたが、カメラが 1 点に固定されているため、特におもしろくありません。 カメラ コントロールを加えて、ゲームをパワーアップしてみましょう。

CodePen を使うと、立方体の色を変更したり、`init()` 関数の `createGround()` をコメントアウトして地面を削除するなど、さまざまなテストを行うことができます。


<iframe height='300' scrolling='no' title='迷路の構築' src='//codepen.io/MicrosoftEdgeDocumentation/embed/JWKYzG/?height=300&theme-id=23761&default-tab=result&embed-version=2&editable=true' frameborder='no' allowtransparency='true' allowfullscreen='true' style='width: 100%;'><a href='https://codepen.io'>CodePen</a> で、Microsoft Edge Docs (<a href='https://codepen.io/MicrosoftEdgeDocumentation'>@MicrosoftEdgeDocumentation</a>) による Pen (<a href='https://codepen.io/MicrosoftEdgeDocumentation/pen/JWKYzG/'>Maze building</a>) をご覧ください。
</iframe>

### <a name="4-allowing-the-player-to-look-around"></a>4. プレイヤーによる探検を可能にする

では、迷路に入り、探検を開始しましょう。 これを行うには、**PointerLockControls.js** ライブラリとカメラを使います。

**PoinerLockControls.js** ライブラリでは、マウスを使用して、マウスの移動方向にカメラを回転することで、プレイヤーによる探検を可能にします。 

まず、**index.html** ファイルにいくつか新しい要素を追加しましょう。

```html
<div id="blocker">
    <div id="instructions">
    <strong>Click to look!</strong>
    </div>
</div>

<script src="main.js"></script>
```

また、このセクションの最後には、CodePen 内のすべての CSS も必要になります。 CSS は、**stylesheet.css** ファイルに貼り付けます。

**main.js** に戻り、新しい変数をいくつか追加します。`controls` にはコントローラーを格納し、`controlsEnabled` ではコントローラーの状態を追跡します。`blocker` には、**index.html** の `blocker` 要素を格納します。

```javascript
var controls;
var controlsEnabled = false;

// HTML elements to be changed
var blocker = document.getElementById('blocker');
```


これで、`init()` 関数内で新しい `PoinerLockControls` オブジェクトを作成し、これに `camera`, を渡して、`camera` を追加します (`controls.getObject()` でアクセスします)。

```javascript
controls = new THREE.PointerLockControls(camera);
scene.add(controls.getObject());
```

これでカメラが接続されましたが、探検のためには、マウスとコントローラーの間でのやり取りが必要です。 

このような場合は、マウスの動きとカメラを連動させる [Pointer Lock API](https://docs.microsoft.com/microsoft-edge/dev-guide/dom/pointer-lock) が役立ちます。 Pointer Lock API では、よりイマーシブなエクスペリエンスを提供するために、マウス カーソルを非表示にすることもできます。 Esc キーを押すと、マウスからカメラへの接続が終了し、マウス カーソルが再び現れます。 これには、`getPointerLock()` 関数と `lockChange()` 関数を追加します。

`getPointerLock()` 関数は、マウス クリックの発生をリッスンします。 クリックの後、レンダリングされたゲームでは、(`container` 要素内で) マウス コントロールの取得が試行されます。 コードに、イベント リスナーも追加します。これにより、プレイヤーによるロックの有効化および無効化を検出して `lockChange()` を呼び出します。 

```javascript
function getPointerLock() {
  document.onclick = function () {
    container.requestPointerLock();
  }
  document.addEventListener('pointerlockchange', lockChange, false); 
}

```

`lockChange()` 関数では、コントロールと `blocker` 要素を無効化または有効化する必要があります。 ポインター ロックの状態を判断するには、[`pointerLockElement`](https://developer.mozilla.org/docs/Web/API/Document/pointerLockElement) プロパティでマウス イベントのターゲットが `container` に設定されているかどうかを確認します。

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

次に、`init()` 関数のすぐ前に、`getPointerLock()` の呼び出しを追加します。
```javascript
// Get the pointer lock state
getPointerLock();
init();
animate();
```

---

これで、周囲を**見回す**ことができますが、実際には**動き回る**機能が欲しいところです。 ベクトルなど、少し数学的な説明になりますが、3D グラフィックスの動作には数学が不可欠です。

<iframe height='300' scrolling='no' title='探検します。' src='//codepen.io/MicrosoftEdgeDocumentation/embed/gmwbMo/?height=300&theme-id=23761&default-tab=result&embed-version=2&editable=true' frameborder='no' allowtransparency='true' allowfullscreen='true' style='width: 100%;'><a href='https://codepen.io'>CodePen</a> で、Microsoft Edge Docs (<a href='https://codepen.io/MicrosoftEdgeDocumentation'>@MicrosoftEdgeDocumentation</a>) による Pen (<a href='https://codepen.io/MicrosoftEdgeDocumentation/pen/gmwbMo/'>Look around</a>) をご覧ください。
</iframe>


### <a name="5-adding-player-movement"></a>5. プレイヤーの動きを追加する

プレイヤーに動きを提供する方法を理解するには、数学の勉強に戻る必要があります。 特定のベクトル (direction) に沿って、速度 (movement) を `camera` に適用します。

それでは、プレイヤーの移動方向を追跡するためのグローバル変数をいくつか追加し、初期速度ベクトルを設定しましょう。

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

`init()` 関数の先頭で、`clock` を新しい `Clock` オブジェクトに設定します。 これは、新しいフレームのレンダリングにかかる時間の経過 (delta) を追跡するために使用します。 また、ユーザー入力を収集する `listenForPlayerMovement()` の呼び出しも追加します。 

```
clock = new THREE.Clock();
listenForPlayerMovement();
```

`listenForPlayerMovement()` 関数では、方向の状態の切り替えが行われます。 この関数の終わり近くには、キーが押されるか離されるのを待機する 2 つのイベント リスナーがあります。 どちらかのイベントが発生した場合は、動きをトリガーするキーか、動きを停止させるキーかを確認します。

このゲームは、プレイヤーが W キー、A キー、S キー、D キー、または方向キーで動き回ることができるとセットアップしてあります。

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

これで、ユーザーが進もうとしている方向 (いずれかのグローバル方向フラグに `true` として格納されている) を判断できるため、少しアクションを加えてみましょう。 アクションは、`animatePlayer()` 関数の形式で発生します。

この関数は、`animate()` 内で呼び出します。このとき、フレームレートが変化しても動作がずれないように、`delta` によってフレーム間の時間の経過を取得します。

```javascript
function animate() {
  render();
  requestAnimationFrame(animate);
  // Get the change in time between frames
  var delta = clock.getDelta();
  animatePlayer(delta);
}
```

では、楽しい部分に移りましょう。 推進力を決定するベクトル (`playerVeloctiy`) には、3 つのパラメーター `(x, y, z)` があり、`y` が垂直方向の推進力になります。 このゲームにはジャンプ動作が含まれないため、処理するのは `x` パラメーターと `z` パラメーターのみです。 このベクトルは、最初は (0, 0, 0) に設定されています。

以下のコードに示されているように、どの方向フラグが `true` になっているかを確認するために、一連のチェックが行われます。 方向を取得したら、`x` および `y` に値を加算または減算して、その方向に推進力を適用します。 移動キーが押されていない場合は、ベクトルの設定が `(0, 0, 0)` に戻ります。


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

最後に、更新された `x` と `y` の値を、実際にプレイヤーを移動させる値に変換して、カメラに適用します。

---

これで、 プレイヤーによって制御されるカメラで、自由に見回し、動き回ることができます。 まだ、壁に入り込むことができますが、これについては後で考えましょう。 次は、恐竜を追加します。

<iframe height='300' scrolling='no' title='移動します。' src='//codepen.io/MicrosoftEdgeDocumentation/embed/qrbKZg/?height=300&theme-id=23761&default-tab=result&embed-version=2&editable=true' frameborder='no' allowtransparency='true' allowfullscreen='true' style='width: 100%;'>ペン<a href='https://codepen.io/MicrosoftEdgeDocumentation/pen/qrbKZg/'>の移動</a>で Microsoft Edge Docs を参照してください (<a href='https://codepen.io/MicrosoftEdgeDocumentation'>@MicrosoftEdgeDocumentation</a>) <a href='https://codepen.io'>CodePen</a>でします。
</iframe>

> [!NOTE]
> UWP アプリでこれらのコントロールを使用する場合、動きの遅延や `keyUp` イベントの未登録エラーが発生することがあります。 この問題については調査中であり、サンプルの該当部分も間もなく修正される予定です。

### <a name="6-load-that-dino"></a>6. 恐竜を読み込む

このプロジェクト リポジトリを複製またはダウンロードした場合は、`models` フォルダー内に `dino.json` があります。 この JSON ファイルは、Blender で作成され、エクスポートされた 3D の恐竜です。


この恐竜を読み込むには、さらにグローバル変数を追加する必要があります。

```javascript
var DINOSCALE = 20;  // How big our dino is scaled to

var clock;
var dino;
var loader = new THREE.JSONLoader();

var instructions = document.getElementById('instructions');
```

作成した `JSONLoader` には、**dino.json** のパスと、ファイルから収集した geometry および materials が指定されたコールバックを渡します。
恐竜の読み込みは非同期タスクです。つまり、恐竜が完全に読み込まれるまで、レンダリングは一切行われません。 **index.html** の `instructions` 要素内の文字列は、処理中であることをプレイヤーに伝えるために、`"Loading..."` に変更してあります。

以下のように、恐竜が読み込まれた後、`instructions` 要素の内容をゲームの実際の手順に更新し、`animate()` 関数を `init()` の末尾から関数コールバックの末尾に移動します。

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

これで、恐竜モデルが読み込まれました。 ご確認ください。

<iframe height='300' scrolling='no' title='恐竜を追加します。' src='//codepen.io/MicrosoftEdgeDocumentation/embed/xqOwBw/?height=300&theme-id=23761&default-tab=result&embed-version=2&editable=true' frameborder='no' allowtransparency='true' allowfullscreen='true' style='width: 100%;'><a href='https://codepen.io'>CodePen</a> で、Microsoft Edge Docs (<a href='https://codepen.io/MicrosoftEdgeDocumentation'>@MicrosoftEdgeDocumentation</a>) による Pen (<a href='https://codepen.io/MicrosoftEdgeDocumentation/pen/xqOwBw/'>Adding the dino</a>) をご覧ください。
</iframe>

### <a name="7-move-that-dino"></a>7. 恐竜を動かす

ゲーム用に AI を作成するときわめて複雑になる可能性があるため、この例の恐竜には単純な動作を適用します。 今のところ、恐竜はまっすぐ移動し、そのまま壁を突き抜けていきます。

では、まずグローバル変数 `dinoVelocity` を追加します。

```javascript
var DINOSPEED = 400.0;

var dinoVelocity = new THREE.Vector3();
```
 次に、`animation()` 関数から `animateDino()` 関数を呼び出し、以下のコードを追加します。

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

このままでは恐竜が消えるのを見守るだけですが、衝突検出機能を追加すると、もう少しおもしろくなります。

<iframe height='300' scrolling='no' title='Moving、なし' src='//codepen.io/MicrosoftEdgeDocumentation/embed/preview/jBMbbL/?height=300&theme-id=23761&default-tab=result&embed-version=2&editable=true' frameborder='no' allowtransparency='true' allowfullscreen='true' style='width: 100%;'><a href='https://codepen.io'>CodePen</a> で、Microsoft Edge Docs (<a href='https://codepen.io/MicrosoftEdgeDocumentation'>@MicrosoftEdgeDocumentation</a>) による Pen (<a href='https://codepen.io/MicrosoftEdgeDocumentation/pen/jBMbbL/'>Moving the dino - no collision</a>) をご覧ください。
</iframe>

### <a name="8-collision-detection-for-the-player"></a>8. プレイヤーの衝突を検出する

これで、プレイヤーと恐竜が動き回るようになりましたが、全員が壁をつきぬけてしまうという問題が残っています。 このチュートリアルで初めて立方体や壁の追加を始めたときは、`collidableObjects` 配列に配置しました。 プレイヤーが何かに近すぎて通ることができない状態を判断するには、この配列を使用します。

交差が発生するタイミングを判断するには、Raycaster を使用します。 Raycaster は、カメラから指定の角度で出ているレーザー ビームのようなものと考えることができます。Raycaster では、物に当たったかどうかという情報と正確な距離が返されます。

```javascript
var PLAYERCOLLISIONDISTANCE = 20;
```

新しい関数として `detectPlayerCollision()` を作成しますが、この関数では、プレイヤーがオブジェクトに当たるほど近い場合は `true` が返されます。
プレイヤー用には 1 つの Raycaster を適用し、プレイヤーの進行方向に応じて方向を変更します。

これを行うには、未定義のマトリックス `rotationMatrix` を作成します。 進行方向を確認し、定義された `rotationMatrix` を使用するか、前進する場合は未定義のマトリックスを使用します。
定義されている場合、コントロールの方向に `rotationMatrix` が適用されます。 

次に、カメラから `cameraDirection` 方向へ向かう Raycaster が作成されます。


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

`detectPlayerCollision()` 関数は、`rayIntersect()` ヘルパー関数に依存しています。
衝突が発生したと判断するには、Raycaster のほか、`collidableObjects` 配列に格納されているオブジェクトにどの程度近付くことができるかを表した値が必要です。

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

これで、衝突がいつ発生するかを判断できるようになったため、`animatePlayer()` 関数を仕上げることができます。

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

プレイヤーの衝突も検出できるので、何か所かの壁に突き当たってみてください。

<iframe height='300' scrolling='no' title='プレイヤーの衝突の移行' src='//codepen.io/MicrosoftEdgeDocumentation/embed/preview/qraOeO/?height=300&theme-id=23761&default-tab=result&embed-version=2&editable=true' frameborder='no' allowtransparency='true' allowfullscreen='true' style='width: 100%;'><a href='https://codepen.io'>CodePen</a> で、Microsoft Edge Docs (<a href='https://codepen.io/MicrosoftEdgeDocumentation'>@MicrosoftEdgeDocumentation</a>) による Pen (<a href='https://codepen.io/MicrosoftEdgeDocumentation/pen/qraOeO/'>Moving the player - collision</a>) をご覧ください。
</iframe>


### <a name="9-collision-detection-and-animation-for-dino"></a>9. 衝突の検出と恐竜のアニメーション

ここで、恐竜が壁を突き抜ける動作を修正し、衝突可能なオブジェクトに近付き過ぎた場合はランダムな方向に進むようにしましょう。

まず、恐竜がいつ衝突するかを把握しましょう。 

衝突の距離用に、グローバル変数をもう 1 つ設定する必要があります。

```javascript
var DINOCOLLISIONDISTANCE = 55;     
```

恐竜にどの程度近付くと衝突が発生するかを指定したので、`detectPlayerCollision()` に似ていてもう少し単純な関数を追加しましょう。
`detectDinoCollision` 関数は、常に恐竜の中央から 1 つの Raycasterがまっすぐ出ているという点で単純です。 プレイヤーの衝突のように、回転させる必要はありません。

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

では、衝突検出機能を組み込んだ最終的な `animateDino()` 関数がどのようなものか、見てみましょう。


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

恐竜の方向転換は、常に -90 度、90 度、180 度のいずれかです。 これを単純化するために、上のコードでは `directionMultiples` 配列を使用し、90 の倍数としてこれらの数値を生成しています。
回転角度がランダムに選択されるようにするために、ヘルパー関数として `getRandomInt()` を追加しました。この関数では、配列のランダム インデックスを表す値 0、1、または 2 を取得します。

```javascript
function getRandomInt(min, max) {
    min = Math.ceil(min);
    max = Math.floor(max);
    return Math.floor(Math.random() * (max - min)) + min;
}
```

これらがすべて完了したら、配列のランダム インデックスに 90 を掛けて、回転角度 (ラジアンに変換した値) を取得します。
この値を恐竜の `y` 回転に加算することによって (`dino.rotation.y += randomDirection;`)、恐竜は衝突時にランダムに回転するようになります。


---

これで、 AI を持った恐竜が、迷路を動き回るようになりました。

<iframe height='300' scrolling='no' title='Moving、' src='//codepen.io/MicrosoftEdgeDocumentation/embed/preview/bqwMXZ/?height=300&theme-id=23761&default-tab=result&embed-version=2&editable=true' frameborder='no' allowtransparency='true' allowfullscreen='true' style='width: 100%;'>ペン<a href='https://codepen.io/MicrosoftEdgeDocumentation/pen/bqwMXZ/'>Moving the -</a>で、Microsoft Edge Docs を参照してください (<a href='https://codepen.io/MicrosoftEdgeDocumentation'>@MicrosoftEdgeDocumentation</a>) <a href='https://codepen.io'>CodePen</a>でします。
</iframe>

### <a name="10-starting-the-chase"></a>10. 追随を開始する

ここで、恐竜がプレイヤーから一定の範囲内に入った場合はプレイヤーに追随するようにセットアップします。 ここに示すのは単なる例であるため、プレイヤーを追い詰めるための高度なアルゴリズムは適用されていません。 代わりに、恐竜はプレイヤーを見て、歩いて追随します。 迷路内で通ることのできる部分では、これが正しく機能しますが、進行方向に壁があると恐竜はぶつかってしまいます。

これに対処するため、`animate()` 関数に、`triggerChase()` から返された値によって決定されるブール変数を追加します。

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

`triggerChase` 関数では、恐竜の追随範囲にプレイヤーがいるかどうかを確認し、恐竜が常にプレイヤーに向くように設定します。これにより、恐竜がプレイヤー方向に移動できます。 

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

`triggerChase` の後半では、恐竜からどの程度離れているかをプレイヤーに知らせるテキストの表示処理を行います。 また、`CATCHOFFSET` を使用して、`0` の距離を指定します。 オフセットがなければ、`0` はプレイヤーに重なり、視覚的に印象的な終わり方になりません。



```javascript
var dinoAlert = document.getElementById('dino-alert');
dinoAlert.style.display = 'none';
```

---

今の時点では、気の荒い恐竜はプレイヤーが近くなると追随を始め、プレイヤーの位置になるまで止まりません。
最後の手順では、恐竜までの距離が `CATCHOFFSET` 単位になったらゲーム オーバー状態を追加します。

<iframe height='300' scrolling='no' title='追随' src='//codepen.io/MicrosoftEdgeDocumentation/embed/preview/NpRBqR/?height=300&theme-id=23761&default-tab=result&embed-version=2&editable=true' frameborder='no' allowtransparency='true' allowfullscreen='true' style='width: 100%;'><a href='https://codepen.io'>CodePen</a> で、Microsoft Edge Docs (<a href='https://codepen.io/MicrosoftEdgeDocumentation'>@MicrosoftEdgeDocumentation</a>) による Pen (<a href='https://codepen.io/MicrosoftEdgeDocumentation/pen/NpRBqR/'>The chase</a>) をご覧ください。
</iframe>


### <a name="11-ending-the-game"></a>11. ゲームを終了する


単純な立方体から長い道のりでしたが、終了の操作に取り掛かりましょう。

まず、ゲーム オーバーかどうかを追跡するための変数を設定しましょう。

```javascript
var gameOver = false;
```

最後にもう一度だけ `animate()` 関数を更新して、恐竜がプレイヤーに近付きすぎていないか確認できるようにします。
恐竜が近すぎる場合は、`caught()` という新しい関数を呼び出して、プレイヤーと恐竜の動作を停止します。そうでない場合は、プレイヤーと恐竜が動き回れる状態で通常の動作を継続します。

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

プレイヤーが恐竜につかまった場合は、`caught()` によって `blocker` 要素が表示され、ゲームに負けたことを示すテキストに更新されます。
`gameOver` 変数も、ゲーム オーバーを示す `true` に設定されます。  


```javascript
function caught() {
    blocker.style.display = '';
    instructions.innerHTML = "GAME OVER </br></br></br> Press ESC to restart";
    gameOver = true;
    instructions.style.display = '';
    dinoAlert.style.display = 'none';
}
```


ゲーム オーバーかどうかがわかるようになったため、ゲーム オーバーのチェックを `lockChange()` 関数に追加できます。
ゲームが終了してユーザーによって Esc キーを押されたら、`location.reload` を追加してゲームを再起動できます。

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

以上で作業は終了です。 長い道のりでしたが、**three.js** でゲームを作成できました。

[最終的な CodePen](#introduction) は、ページの上部から確認できます。


## <a name="publishing-to-the-microsoft-store"></a>Microsoft Store への公開
UWP アプリがある場合は、これは、(もう少し改善が最初に!)、Microsoft Store に公開することもできます。プロセスにいくつかの手順があります。

1.  Windows 開発者として[登録](https://developer.microsoft.com/store/register)する必要があります。
2.  アプリの申請[チェックリスト](https://msdn.microsoft.com/windows/uwp/publish/app-submissions)を使用する必要があります。
3.  [認定](https://msdn.microsoft.com/windows/uwp/publish/the-app-certification-process)を受けるために、アプリを提出する必要があります。
詳細については、 [UWP アプリの公開](https://developer.microsoft.com/store/publish-apps)を参照してください。

