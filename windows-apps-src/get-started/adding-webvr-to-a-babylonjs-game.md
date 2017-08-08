---
title: "入門チュートリアル - 3D Babylon.js ゲームに WebVR サポートを追加する"
description: "既存の 3D Babylon.js ゲームに WebVR サポートを追加する方法について説明します。"
author: abbycar
ms.author: abigailc
ms.date: 05/09/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "WebVR、Edge、Web 開発、Babylon、Babylonjs、Babylon.js、JavaScript"
ms.openlocfilehash: 135871f7817c30ef33bc2db2f06d96677b0ac3b3
ms.sourcegitcommit: 512a82a782775795e301d6235d0c977c0a9e9c74
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/11/2017
---
# <a name="get-started-tutorial---adding-webvr-support-to-a-3d-babylonjs-game"></a><span data-ttu-id="d6c94-104">入門チュートリアル - 3D Babylon.js ゲームに WebVR サポートを追加する</span><span class="sxs-lookup"><span data-stu-id="d6c94-104">Get Started Tutorial - Adding WebVR support to a 3D Babylon.js game</span></span>

<span data-ttu-id="d6c94-105">Babylon.js を使って 3D ゲームを作成したことがあり、仮想現実 (VR) をサポートしてみたいと考えている場合には、次の簡単な手順に沿って、実現することができます。</span><span class="sxs-lookup"><span data-stu-id="d6c94-105">If you've created a 3D game with Babylon.js and thought that it might look great in virtual reality (VR), follow the simple steps in this tutorial to make that a reality.</span></span>

<span data-ttu-id="d6c94-106">次に示すゲームに WebVR サポートを追加します。</span><span class="sxs-lookup"><span data-stu-id="d6c94-106">We'll add WebVR support to the game shown here.</span></span> <span data-ttu-id="d6c94-107">Xbox コントローラーを接続して、試してみてください。</span><span class="sxs-lookup"><span data-stu-id="d6c94-107">Go ahead and plug in an Xbox controller to try it out!</span></span>

<iframe height='300' scrolling='no' title='Babylon.js dino game' src='//codepen.io/MicrosoftEdgeDocumentation/embed/MmgdWp/?height=300&theme-id=23761&default-tab=result&embed-version=2&editable=true' frameborder='no' allowtransparency='true' allowfullscreen='true' style='width: 100%;'><span data-ttu-id="d6c94-108"><a href='http://codepen.io'>CodePen</a> で、Microsoft Edge Docs (<a href='http://codepen.io/MicrosoftEdgeDocumentation'>@MicrosoftEdgeDocumentation</a>) による Pen (<a href='http://codepen.io/MicrosoftEdgeDocumentation/pen/MmgdWp/'>Babylon.js dino game</a>) をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d6c94-108">See the Pen <a href='http://codepen.io/MicrosoftEdgeDocumentation/pen/MmgdWp/'>Babylon.js dino game</a> by Microsoft Edge Docs (<a href='http://codepen.io/MicrosoftEdgeDocumentation'>@MicrosoftEdgeDocumentation</a>) on <a href='http://codepen.io'>CodePen</a>.</span></span>
</iframe>

<span data-ttu-id="d6c94-109">これはフラット画面上では適切に動作する 3D ゲームですが、VR ではどうなるでしょうか。</span><span class="sxs-lookup"><span data-stu-id="d6c94-109">This is a 3D game that works well on a flat screen, but what about in VR?</span></span>
<span data-ttu-id="d6c94-110">このチュートリアルでは、このゲームを WebVR で実行できるようにするための、いつくかの手順について説明します。</span><span class="sxs-lookup"><span data-stu-id="d6c94-110">In this tutorial, we'll walk through the few steps it takes to get this up and running with WebVR.</span></span> <span data-ttu-id="d6c94-111">[Windows Mixed Reality](https://developer.microsoft.com/en-us/windows/mixed-reality) ヘッドセットを使って、Microsoft Edge に追加された WebVR サポートを利用します。</span><span class="sxs-lookup"><span data-stu-id="d6c94-111">We’ll use a [Windows Mixed Reality](https://developer.microsoft.com/en-us/windows/mixed-reality) headset that can tap into the added support for WebVR in Microsoft Edge.</span></span> <span data-ttu-id="d6c94-112">これらの変更をゲームに適用すると、WebVR をサポートする他のブラウザー/ヘッドセットの組み合わせでも動作します。</span><span class="sxs-lookup"><span data-stu-id="d6c94-112">After we apply these changes to the game, you can expect it also to work in other browser/headset combinations that support WebVR.</span></span>



## <a name="prerequisites"></a><span data-ttu-id="d6c94-113">前提条件</span><span class="sxs-lookup"><span data-stu-id="d6c94-113">Prerequisites</span></span>

- <span data-ttu-id="d6c94-114">テキスト エディター ([Visual Studio Code](https://code.visualstudio.com/download) など)</span><span class="sxs-lookup"><span data-stu-id="d6c94-114">A text editor (like [Visual Studio Code](https://code.visualstudio.com/download))</span></span>
- <span data-ttu-id="d6c94-115">コンピューターに接続されている Xbox コントローラー</span><span class="sxs-lookup"><span data-stu-id="d6c94-115">An Xbox controller that’s plugged in to your computer</span></span>
- <span data-ttu-id="d6c94-116">Windows 10 Creators Update</span><span class="sxs-lookup"><span data-stu-id="d6c94-116">Windows 10 Creators Update</span></span>
- <span data-ttu-id="d6c94-117">[Windows Mixed Reality を実行するための最小要件仕様](https://developer.microsoft.com/en-us/windows/mixed-reality/immersive_headset_setup)を満たすコンピューター</span><span class="sxs-lookup"><span data-stu-id="d6c94-117">A computer with the [minimum required specs to run Windows Mixed Reality](https://developer.microsoft.com/en-us/windows/mixed-reality/immersive_headset_setup)</span></span>
- <span data-ttu-id="d6c94-118">Windows Mixed Reality デバイス (オプション)</span><span class="sxs-lookup"><span data-stu-id="d6c94-118">A Windows Mixed Reality device (Optional)</span></span> 



## <a name="getting-started"></a><span data-ttu-id="d6c94-119">はじめに</span><span class="sxs-lookup"><span data-stu-id="d6c94-119">Getting started</span></span>

<span data-ttu-id="d6c94-120">最も簡単に始める方法は、[Windows-tutorials-web GitHub repo](https://github.com/Microsoft/Windows-tutorials-web) に移動して、緑色の [**Clone or download**] (複製またはダウンロード) ボタンを押し、[**Open in Visual Studio**] (Visual Studio で開く) を選択することです。</span><span class="sxs-lookup"><span data-stu-id="d6c94-120">The simplest way to get started is to visit the [Windows-tutorials-web GitHub repo](https://github.com/Microsoft/Windows-tutorials-web), press the green **Clone or download** button, and select **Open in Visual Studio**.</span></span>

![[Clone or download] (複製またはダウンロード) ボタン](images/3dclone.png)

<span data-ttu-id="d6c94-122">プロジェクトを複製しない場合は、zip ファイルとしてダウンロードすることもできます。</span><span class="sxs-lookup"><span data-stu-id="d6c94-122">If you don't want to clone the project, you can download it as a zip file.</span></span>
<span data-ttu-id="d6c94-123">[[Before](https://github.com/Microsoft/Windows-tutorials-web/tree/master/BabylonJS-game-with-WebVR/before)] と [[After](https://github.com/Microsoft/Windows-tutorials-web/tree/master/BabylonJS-game-with-WebVR/after)] という 2 つのフォルダーがあります。</span><span class="sxs-lookup"><span data-stu-id="d6c94-123">You'll then have two folders, [before](https://github.com/Microsoft/Windows-tutorials-web/tree/master/BabylonJS-game-with-WebVR/before) and [after](https://github.com/Microsoft/Windows-tutorials-web/tree/master/BabylonJS-game-with-WebVR/after).</span></span> <span data-ttu-id="d6c94-124">[Before] フォルダーは VR 機能が追加される前のゲームで、[After] フォルダーは、VR サポートを追加して完成したゲームです。</span><span class="sxs-lookup"><span data-stu-id="d6c94-124">The "before" folder is our game before any VR features are added, and the "after" folder is the finished game with VR support.</span></span>

<span data-ttu-id="d6c94-125">[Before] と [After] のフォルダーには、次のファイルが含まれています。</span><span class="sxs-lookup"><span data-stu-id="d6c94-125">The before and after folders contain these files:</span></span>
-   <span data-ttu-id="d6c94-126">textures/ - ゲームで使用するイメージを含むフォルダー。</span><span class="sxs-lookup"><span data-stu-id="d6c94-126">textures/ - A folder containing any images used in the game.</span></span>
-   <span data-ttu-id="d6c94-127">css/ - ゲームの CSS を含むフォルダー。</span><span class="sxs-lookup"><span data-stu-id="d6c94-127">css/ - A folder containing the CSS for the game.</span></span>
-   <span data-ttu-id="d6c94-128">js/ - JavaScript ファイルが含まれるフォルダー。</span><span class="sxs-lookup"><span data-stu-id="d6c94-128">js/ - A folder containing the JavaScript files.</span></span> <span data-ttu-id="d6c94-129">main.js ファイルはゲームで、他のファイルは使用されるライブラリです。</span><span class="sxs-lookup"><span data-stu-id="d6c94-129">The main.js file is our game, and the other files are the libraries used.</span></span>
-   <span data-ttu-id="d6c94-130">models/ - 3D モデルが含まれるフォルダー。</span><span class="sxs-lookup"><span data-stu-id="d6c94-130">models/ - A folder containing the 3D models.</span></span> <span data-ttu-id="d6c94-131">このゲームでは、恐竜の 1 つのモデルのみがあります。</span><span class="sxs-lookup"><span data-stu-id="d6c94-131">For this game we have only one model, for the dinosaur.</span></span>
-   <span data-ttu-id="d6c94-132">Index.html - ゲームのレンダラーをホストする Web ページです。</span><span class="sxs-lookup"><span data-stu-id="d6c94-132">index.html - The webpage that hosts the game's renderer.</span></span> <span data-ttu-id="d6c94-133">Edge でこのページを開くと、ゲームが起動します。</span><span class="sxs-lookup"><span data-stu-id="d6c94-133">Opening this page in Edge launches the game.</span></span>

<span data-ttu-id="d6c94-134">Edge でそれぞれの index.html ファイルを開くと、ゲームの両方のバージョンをテストできます。</span><span class="sxs-lookup"><span data-stu-id="d6c94-134">You can test both versions of the game by opening their respective index.html files in Edge.</span></span>



## <a name="the-mixed-reality-portal"></a><span data-ttu-id="d6c94-135">Mixed Reality ポータル</span><span class="sxs-lookup"><span data-stu-id="d6c94-135">The Mixed Reality Portal</span></span>

<span data-ttu-id="d6c94-136">Windows Mixed Reality をまだお使いでなく、Windows 10 Creators Update がコンピューターにインストールされており、Windows Mixed Reality に対応しているグラフィックス カードが備えられている場合は、Windows 10 のスタート メニューから [**Mixed Reality ポータル**] アプリを開いてみてください。</span><span class="sxs-lookup"><span data-stu-id="d6c94-136">If you're unfamiliar with Windows Mixed Reality and have the Windows 10 Creators Update installed on a computer with a compatible graphics card, try opening the **Mixed Reality Portal** app from the Start menu in Windows 10.</span></span>

![Mixed Reality ポータルの検索](images/mixed-reality-portal.png)

<span data-ttu-id="d6c94-138">すべての要件が満たされいる場合、開発者向け機能をオンにすると、コンピューターに接続された Windows Mixed Reality ヘッドセットをシミュレートできます。</span><span class="sxs-lookup"><span data-stu-id="d6c94-138">If you met all the requirements, you can then turn on developer features and simulate a Windows Mixed Reality headset plugged in to your computer.</span></span> <span data-ttu-id="d6c94-139">また既に実際のヘッドセットをお持ちの場合は、接続してセットアップを実行します。</span><span class="sxs-lookup"><span data-stu-id="d6c94-139">If you're fortunate enough to have an actual headset nearby, plug it in and run the setup.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="d6c94-140">Mixed Reality ポータルは、このチュートリアルの間、常に開いておく必要があります。</span><span class="sxs-lookup"><span data-stu-id="d6c94-140">The Mixed Reality Portal must be open at all times during this tutorial.</span></span>

<span data-ttu-id="d6c94-141">これで Edge を使って WebVR を試す準備ができました。</span><span class="sxs-lookup"><span data-stu-id="d6c94-141">You're now ready to experience WebVR with Edge.</span></span>

## <a name="2d-ui-in-a-virtual-world"></a><span data-ttu-id="d6c94-142">仮想世界の 2D UI</span><span class="sxs-lookup"><span data-stu-id="d6c94-142">2D UI in a virtual world</span></span>

>[!NOTE]
> <span data-ttu-id="d6c94-143">スターター コードは [[**Before**](https://github.com/Microsoft/Windows-tutorials-web/tree/master/BabylonJS-game-with-WebVR/before)] フォルダーにあります。</span><span class="sxs-lookup"><span data-stu-id="d6c94-143">Grab the [**before**](https://github.com/Microsoft/Windows-tutorials-web/tree/master/BabylonJS-game-with-WebVR/before) folder to get the starter code.</span></span>

<span data-ttu-id="d6c94-144">現在使われている [`Canvas2D`](http://doc.babylonjs.com/classes/2.5/canvas2d) 要素は仮想現実では十分に動作しないため、このゲームではすべての 2D UI を削除または変更します。</span><span class="sxs-lookup"><span data-stu-id="d6c94-144">Because the [`Canvas2D`](http://doc.babylonjs.com/classes/2.5/canvas2d) element that is currently being used doesn't work well in virtual reality, we'll be cutting or changing all the 2D UI in our game.</span></span>
<span data-ttu-id="d6c94-145">スタート UI を更新して VR で動作するようにします。簡単のため、距離カウンターとゲームオーバー UI の処理は省略します。</span><span class="sxs-lookup"><span data-stu-id="d6c94-145">We'll be updating the start UI to work in VR, but we'll forgo the distance counter and game-over UI to keep things simple.</span></span>


### <a name="step-1-creating-a-worldspacecanvas2d-object"></a><span data-ttu-id="d6c94-146">手順 1: WorldSpaceCanvas2D オブジェクトを作成する</span><span class="sxs-lookup"><span data-stu-id="d6c94-146">Step 1: Creating a WorldSpaceCanvas2D object</span></span>

<span data-ttu-id="d6c94-147">`create2d()` 関数で、すべてを削除し、UI テキストを保持する新しい [`Text2D`](http://doc.babylonjs.com/classes/2.5/text2d) オブジェクトを追加します。</span><span class="sxs-lookup"><span data-stu-id="d6c94-147">Within the `create2d()` function, we'll strip everything out and add a new [`Text2D`](http://doc.babylonjs.com/classes/2.5/text2d) object to hold our UI text.</span></span> <span data-ttu-id="d6c94-148">その `Text2D` オブジェクトと新しい[`WorldSpaceCanvas2D`](http://doc.babylonjs.com/classes/2.5/worldspacecanvas2d) オブジェクトを使用します。</span><span class="sxs-lookup"><span data-stu-id="d6c94-148">We'll then use that `Text2D` object with a new [`WorldSpaceCanvas2D`](http://doc.babylonjs.com/classes/2.5/worldspacecanvas2d) object.</span></span> `WorldSpaceCanvas2D` <span data-ttu-id="d6c94-149">は 3D 環境に配置できる 2D UI です (3D キャンバスの上に UI のレイヤーを追加する [`ScreenSpaceCanvas2D`](http://doc.babylonjs.com/classes/2.5/screenspacecanvas2d) オブジェクトとは異なります)。</span><span class="sxs-lookup"><span data-stu-id="d6c94-149">is 2D UI that can be placed in a 3D environment (unlike the [`ScreenSpaceCanvas2D`](http://doc.babylonjs.com/classes/2.5/screenspacecanvas2d) object, which adds a layer of UI on top of the 3D canvas).</span></span>


<span data-ttu-id="d6c94-150">このコードを、既存の `var create2d = function...` コードの上に貼り付けます。</span><span class="sxs-lookup"><span data-stu-id="d6c94-150">Paste this code over the existing `var create2d = function...` code.</span></span>
```javascript
    var create2d = function (scene) {
        // Start button UI
        startUI = new BABYLON.Rectangle2D({
            id: "startUI",
            children:
            [
                new BABYLON.Text2D("Left click to enter VR", {
                    size: new BABYLON.Size(110, 15), marginBottom: "20", textAlignment: "h: left, v: top",
                    wordWrap: true, fontName: "7pt Arial", fontSignedDistanceField: true
                })
            ]
        });

        var canvas = new BABYLON.WorldSpaceCanvas2D(scene, new BABYLON.Size(105, 40), {
            id: "ScreenCanvas",
            backgroundFill: "#000000F2",
            backgroundRoundRadius: 5,
            children: [startUI]
        });
        return canvas;
    };
```

<span data-ttu-id="d6c94-151">これで 2D UI をシーンに追加する準備ができました。</span><span class="sxs-lookup"><span data-stu-id="d6c94-151">Our 2D UI is now ready to be added to our scene.</span></span> 


### <a name="step-2-positioning-2d-ui"></a><span data-ttu-id="d6c94-152">手順 2: 2D UI を配置する</span><span class="sxs-lookup"><span data-stu-id="d6c94-152">Step 2: Positioning 2D UI</span></span>

<span data-ttu-id="d6c94-153">`createScene` 関数で、コードを数行記述して、シーンから UI を追加し、ユーザーの前に配置します。</span><span class="sxs-lookup"><span data-stu-id="d6c94-153">Within the `createScene` function, we'll now write a few lines of code to add the UI from our scene and position it so that it's in front of the user.</span></span>


<span data-ttu-id="d6c94-154">このコードを `skybox.material = skyboxMaterial;` の後に貼り付けます。</span><span class="sxs-lookup"><span data-stu-id="d6c94-154">Paste this code after `skybox.material = skyboxMaterial;` .</span></span>
```javascript
        canvas2d = create2d(scene);
        canvas2d.worldSpaceCanvasNode.position = new BABYLON.Vector3(0, 30, 175);
```

### <a name="step-3-toggling-2d-ui-visibility"></a><span data-ttu-id="d6c94-155">手順 3: 2D UI の表示を切り替える</span><span class="sxs-lookup"><span data-stu-id="d6c94-155">Step 3: Toggling 2D UI visibility</span></span>
<span data-ttu-id="d6c94-156">ゲームの開始後にスタート UI を非表示にするため、**A** ボタンの押下チェックを変更して、`canvas2d` の `isVisible = false;` 呼び出しを含めます。</span><span class="sxs-lookup"><span data-stu-id="d6c94-156">To make the start UI disappear after the game starts, we'll tweak the **A** button-press check to include an `isVisible = false;` call on `canvas2d`.</span></span>


<span data-ttu-id="d6c94-157">このコードを現在の `xboxpad.onbuttondown` 呼び出しの上に貼り付けます。</span><span class="sxs-lookup"><span data-stu-id="d6c94-157">Paste this code over your current `xboxpad.onbuttondown` call.</span></span>
```javascript
        xboxpad.onbuttondown(function (buttonValue) {
            // When the A button is pressed, either start or reload the game depending on the game state
            if (buttonValue == BABYLON.Xbox360Button.A) {

                // Game is over, reload it
                if (gameOver) {
                    location.href = location.href;
                }
                // Game has begun
                else {
                    // Hide start UI
                    canvas2d.worldSpaceCanvasNode.isVisible = false;
                    begin = true;
                    // Start looping the dino walking animation
                    scene.beginAnimation(dino.skeleton, 111, 130, true, 1);
                }
            }
        });
```

### <a name="step-4-resizing"></a><span data-ttu-id="d6c94-158">手順 4: サイズを変更する</span><span class="sxs-lookup"><span data-stu-id="d6c94-158">Step 4: Resizing</span></span> 
<span data-ttu-id="d6c94-159">UI への最後の変更として、`onWindowResize()` 関数を更新して UI への参照をすべて削除します。これはウィンドウのサイズの影響を受けなくなったためです。</span><span class="sxs-lookup"><span data-stu-id="d6c94-159">As a final note on our UI, we can now update the `onWindowResize()` function to remove any references to the UI because it's no longer impacted by the size of the window.</span></span>

<span data-ttu-id="d6c94-160">次のコードを `onWindowResize()` 関数の上に貼り付けます。</span><span class="sxs-lookup"><span data-stu-id="d6c94-160">Paste the following code over the `onWindowResize()` function.</span></span>
```javascript
function onWindowResize() {
     engine.resize();
}
```


<span data-ttu-id="d6c94-161">Edge で index.html ファイルを開くと、ゲームを読み込むことができます。</span><span class="sxs-lookup"><span data-stu-id="d6c94-161">You can load the game by opening the index.html file in Edge.</span></span> <span data-ttu-id="d6c94-162">2D UI が 3D 世界に表示されます。</span><span class="sxs-lookup"><span data-stu-id="d6c94-162">And there you have it: 2D UI in a 3D world!</span></span>

![startUI](images/startUI.png)



## <a name="detecting-headsets"></a><span data-ttu-id="d6c94-164">ヘッドセットを検出する</span><span class="sxs-lookup"><span data-stu-id="d6c94-164">Detecting headsets</span></span>

<span data-ttu-id="d6c94-165">VR アプリで 2 種類のカメラを備えて、複数のシナリオをサポートすることは、推奨されるプラクティスです。</span><span class="sxs-lookup"><span data-stu-id="d6c94-165">It's good practice for VR apps to have two types of cameras so that multiple scenarios can be supported.</span></span> <span data-ttu-id="d6c94-166">このゲームでは、ヘッドセットの接続を必要とする 1 つのカメラと、ヘッドセットを使用しないもう 1 つのカメラをサポートします。</span><span class="sxs-lookup"><span data-stu-id="d6c94-166">For this game, we'll support one camera that requires a working headset to be plugged in, and another that uses no headset.</span></span> <span data-ttu-id="d6c94-167">ゲームでどちらを使用するかを判断するため、最初にヘッドセットが検出されたかどうかをチェックする必要があります。</span><span class="sxs-lookup"><span data-stu-id="d6c94-167">To determine which one the game will use, we must first check to see whether a headset has been detected.</span></span> <span data-ttu-id="d6c94-168">これには、[navigator.getVRDisplays()](https://msdn.microsoft.com/en-us/library/mt793853(v=vs.85).aspx) を使用します。</span><span class="sxs-lookup"><span data-stu-id="d6c94-168">To do that, we’ll use [navigator.getVRDisplays()](https://msdn.microsoft.com/en-us/library/mt793853(v=vs.85).aspx).</span></span>


<span data-ttu-id="d6c94-169">次のコードを `window.addEventListener('DOMContentLoaded')` の前に追加します。</span><span class="sxs-lookup"><span data-stu-id="d6c94-169">Add this code above `window.addEventListener('DOMContentLoaded')` .</span></span>
```javascript
var headset;
// If a VR headset is connected, get its info
navigator.getVRDisplays().then(function (displays) {
    if (displays[0]) {
        headset = displays[0];
    }
});
```

<span data-ttu-id="d6c94-170">`headset` 変数に保存されている情報を使って、ユーザーに適切なカメラを選択することができます。</span><span class="sxs-lookup"><span data-stu-id="d6c94-170">With the info stored in the `headset` variable, we'll now be able to choose the camera that’s right for the user.</span></span>


## <a name="selecting-the-initial-camera"></a><span data-ttu-id="d6c94-171">初期のカメラを選択する</span><span class="sxs-lookup"><span data-stu-id="d6c94-171">Selecting the initial camera</span></span>

<span data-ttu-id="d6c94-172">Babylon.js では、[WebVRFreeCamera](http://doc.babylonjs.com/classes/2.5/webvrfreecamera) を使って、WebVR をすばやく追加することができます。</span><span class="sxs-lookup"><span data-stu-id="d6c94-172">With Babylon.js, WebVR can be added quickly by using the [WebVRFreeCamera](http://doc.babylonjs.com/classes/2.5/webvrfreecamera).</span></span> <span data-ttu-id="d6c94-173">このカメラはキーボード入力を受け取ることができ、VR ヘッドセットを使用して、「ヘッド」の回転を制御することができます。</span><span class="sxs-lookup"><span data-stu-id="d6c94-173">This camera can take keyboard input and enables you to use a VR headset to control your "head" rotation.</span></span>


### <a name="step-1-checking-for-headsets"></a><span data-ttu-id="d6c94-174">手順 1: ヘッドセットを確認する</span><span class="sxs-lookup"><span data-stu-id="d6c94-174">Step 1: Checking for headsets</span></span>

<span data-ttu-id="d6c94-175">フォールバック カメラには、元のゲームで使用されている [UniversalCamera](https://doc.babylonjs.com/classes/2.5/universalcamera) を使用します。</span><span class="sxs-lookup"><span data-stu-id="d6c94-175">For our fallback camera, we'll be using the [UniversalCamera](https://doc.babylonjs.com/classes/2.5/universalcamera) that’s currently used in the original game.</span></span>

<span data-ttu-id="d6c94-176">`headset` 変数を確認して、**WebVRFreeCamera** カメラを使用できるかどうかを判断します。</span><span class="sxs-lookup"><span data-stu-id="d6c94-176">We'll check our `headset` variable to determine whether we can use the **WebVRFreeCamera** camera.</span></span>

<span data-ttu-id="d6c94-177">次のコードで `camera = new BABYLON.UniversalCamera("Camera", new BABYLON.Vector3(0, 18, -45), scene);` を置き換えます。</span><span class="sxs-lookup"><span data-stu-id="d6c94-177">Replace `camera = new BABYLON.UniversalCamera("Camera", new BABYLON.Vector3(0, 18, -45), scene);` with the following code.</span></span>
```javascript
        if(headset){
            // Create a WebVR camera with the trackPosition property set to false so that we can control movement with the gamepad
            camera = new BABYLON.WebVRFreeCamera("vrcamera", new BABYLON.Vector3(0, 14, 0), scene, true, { trackPosition: false });
            camera.deviceScaleFactor = 1;
        } else {
            // No headset, use universal camera
            camera = new BABYLON.UniversalCamera("camera", new BABYLON.Vector3(0, 18, -45), scene);
        }
```

### <a name="step-2-activating-the-webvrfreecamera"></a><span data-ttu-id="d6c94-178">手順 2: WebVRFreeCamera をアクティブ化する</span><span class="sxs-lookup"><span data-stu-id="d6c94-178">Step 2: Activating the WebVRFreeCamera</span></span>
<span data-ttu-id="d6c94-179">ほとんどのブラウザーでは、このカメラをアクティブ化するため、仮想操作を要求するいくつかの操作を実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d6c94-179">To activate this camera in most browsers, the user must perform some interaction that requests the virtual experience.</span></span>

<span data-ttu-id="d6c94-180">この機能をマウス クリックにフックします。その後、スタート UI のテキストを更新して、異なる指示を表示するようにします。</span><span class="sxs-lookup"><span data-stu-id="d6c94-180">Now we'll hook this functionality up to a mouse click, and update our start UI text to show a different set of instructions after doing so.</span></span>


<span data-ttu-id="d6c94-181">`createScene()` 関数内のコードを `camera.applyGravity = true;` の後に貼り付けます。</span><span class="sxs-lookup"><span data-stu-id="d6c94-181">Paste the code within  `createScene()` function after `camera.applyGravity = true;` .</span></span>
```javascript
        scene.onPointerDown = function () {
            startUI.children[0].text = "Dino is to your right! Press A button to start. L analog stick to move.";
            scene.onPointerDown = undefined
            camera.attachControl(canvas, true);
        }
```

<span data-ttu-id="d6c94-182">ゲームでクリックすると、次のようなプロンプトが表示されます。一度ユーザーがこのプロンプトに答えると、次回以降はすぐにヘッドセットにゲームを表示します。</span><span class="sxs-lookup"><span data-stu-id="d6c94-182">A click in the game now creates a prompt like the following, or displays the game in the headset right away if the user has encountered the prompt before.</span></span>

![イマーシブのプロンプト](images/immersiveview.png)


### <a name="step-3-adding-gamepad-support"></a><span data-ttu-id="d6c94-184">手順 3: ゲームパッドのサポートを追加する</span><span class="sxs-lookup"><span data-stu-id="d6c94-184">Step 3: Adding gamepad support</span></span>

<span data-ttu-id="d6c94-185">**WebVRFreeCamera** は最初はゲームパッドをサポートしないため、ゲームパッドのボタンをキーボードの方向キーにマッピングします。</span><span class="sxs-lookup"><span data-stu-id="d6c94-185">Because the **WebVRFreeCamera** doesn't initially support gamepads, we'll map our gamepad buttons to the keyboard arrow keys.</span></span> <span data-ttu-id="d6c94-186">カメラの**入力**プロパティの詳細な設定でこれを行います。</span><span class="sxs-lookup"><span data-stu-id="d6c94-186">We'll do this by digging into the **input** property of the camera.</span></span> <span data-ttu-id="d6c94-187">左のアナログ スティックの上、下、左、右を方向キーに対応させるコードを追加します。これでゲームパッドを使えるようになります。</span><span class="sxs-lookup"><span data-stu-id="d6c94-187">By adding the corresponding codes for left analog stick up, down, left, and right to match up with the arrow keys, our gamepad is back in action.</span></span>


<span data-ttu-id="d6c94-188">次のコードを \`scene.onPointerDown = function() {...} 呼び出しの下に</span><span class="sxs-lookup"><span data-stu-id="d6c94-188">Add this code below the \`scene.onPointerDown = function() {...}</span></span> <span data-ttu-id="d6c94-189">追加します。</span><span class="sxs-lookup"><span data-stu-id="d6c94-189">call.</span></span>
``` javascript
    // Custom input, adding Xbox controller support for left analog stick to map to keyboard arrows
    camera.inputs.attached.keyboard.keysUp.push(211);    // Left analog up
    camera.inputs.attached.keyboard.keysDown.push(212);  // Left analog down
    camera.inputs.attached.keyboard.keysLeft.push(214);  // Left analog left
    camera.inputs.attached.keyboard.keysRight.push(213); // Left analog right
```

<span data-ttu-id="d6c94-190">このゲームでは、ユーザーが向く方向が常に前方となります。</span><span class="sxs-lookup"><span data-stu-id="d6c94-190">For this game, wherever the user looks will be forward.</span></span> <span data-ttu-id="d6c94-191">たとえば、壁を見ている場合に、左のアナログ スティックの上を押すと、壁に向かって前に進みます。</span><span class="sxs-lookup"><span data-stu-id="d6c94-191">For example, if they look at a wall and push up on the left analog stick, they'll move towards the wall.</span></span>

### <a name="step-4-give-it-a-try"></a><span data-ttu-id="d6c94-192">手順 4: 試してみる</span><span class="sxs-lookup"><span data-stu-id="d6c94-192">Step 4: Give it a try!</span></span>

<span data-ttu-id="d6c94-193">ヘッドセットとゲーム コントローラーを接続して index.html を開き、青いゲーム ウィンドウで左クリックすると、ゲームが VR モードに切り替わります。</span><span class="sxs-lookup"><span data-stu-id="d6c94-193">If we open index.html with our headset and game controller plugged in, a left click on the blue game window will switch our game to VR mode!</span></span> <span data-ttu-id="d6c94-194">ヘッドセットを装着して、結果を確認します。</span><span class="sxs-lookup"><span data-stu-id="d6c94-194">Go ahead and put on your headset to check out the results.</span></span> 

<span data-ttu-id="d6c94-195">次のセクションでは、Edge ブラウザーで VR モードを終了するときに発生する不快感について説明します。またヘッドセットが接続されていない場合の対応についても説明します。</span><span class="sxs-lookup"><span data-stu-id="d6c94-195">In the next section, we'll cover the unpleasantness that occurs when you exit VR mode while in the Edge browser, and what should happen when a headset isn't plugged in.</span></span>

![VR での指示ボックス](images/webvrfreecamera.png)



## <a name="swapping-between-cameras"></a><span data-ttu-id="d6c94-197">カメラを切り替える</span><span class="sxs-lookup"><span data-stu-id="d6c94-197">Swapping between cameras</span></span>

<span data-ttu-id="d6c94-198">**WebVRFreeCamera** のみを使用できる場合には、WebVR を終了しようとするときに、Edge ブラウザーで画面が斜めになる場合があります (このカメラはヘッドセットがコンテンツを表示するときのみ動作するためです)。</span><span class="sxs-lookup"><span data-stu-id="d6c94-198">With only the **WebVRFreeCamera** available, things can go awry in the Edge browser when you try to escape from WebVR (because this camera works only while a headset is displaying content).</span></span>

<span data-ttu-id="d6c94-199">シーンでアクティブなカメラが突然失われると、Edge の表示がビューの間で切り替わり、ちらつきが発生します。</span><span class="sxs-lookup"><span data-stu-id="d6c94-199">When the scene suddenly loses an active camera, the display in Edge will switch between views, causing a flickering effect.</span></span> <span data-ttu-id="d6c94-200">これを防ぐため、バックアップの **UniversalCamera** を追加して、ヘッドセットをオフにした後、または **ESC** を押したとき、または Edge のタブが切り替わるときに、表示するようにします。</span><span class="sxs-lookup"><span data-stu-id="d6c94-200">To prevent this, we'll add a backup **UniversalCamera** to display after we've taken our headset off, pressed **ESC**, or switched between tabs in Edge.</span></span>


<span data-ttu-id="d6c94-201">VR ヘッドセットは接続したままにできますが、コンテンツは表示されません。</span><span class="sxs-lookup"><span data-stu-id="d6c94-201">A VR headset can be plugged in but not displaying content (presenting).</span></span> <span data-ttu-id="d6c94-202">`headset` 変数を使用できるため、`animate()` 関数を使って、ヘッドセットが `isPresenting` プロパティを使用して表示しているかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="d6c94-202">With the `headset` variable available to us, we can now use our `animate()` function to see whether the headset is presenting using the `isPresenting` property.</span></span> <span data-ttu-id="d6c94-203">ヘッドセットが表示している場合には、**WebVRFreeCamera** をアクティブなままにします。表示していない場合には、バックアップの **UniversalCamera** に切り替えます。</span><span class="sxs-lookup"><span data-stu-id="d6c94-203">If it is, keep the **WebVRFreeCamera** active; if it isn't, switch to the backup **UniversalCamera**.</span></span>


<span data-ttu-id="d6c94-204">この `if` のチェックを `engine.runRenderLoop()` の下に追加します。</span><span class="sxs-lookup"><span data-stu-id="d6c94-204">Add this `if` check under `engine.runRenderLoop()` .</span></span>
```javascript
    // Determine which camera should be showing depending on whether or not the headset is presenting
    if (headset) {
        if (!(headset.isPresenting)) {
            var camera2 = new BABYLON.UniversalCamera("Camera", new BABYLON.Vector3(0, 18, -45), scene);
            scene.activeCamera = camera2;
        } else {
            scene.activeCamera = camera;
        }
    }
```


## <a name="ending-the-game-and-fog-changes"></a><span data-ttu-id="d6c94-205">ゲームを終了して霧を変更する</span><span class="sxs-lookup"><span data-stu-id="d6c94-205">Ending the game and fog changes</span></span>

<span data-ttu-id="d6c94-206">最後に、いくつかの呼び出しを追加して、霧の色を調整します。</span><span class="sxs-lookup"><span data-stu-id="d6c94-206">The last pieces we'll add are a couple calls to adjust the color of our fog.</span></span> <span data-ttu-id="d6c94-207">これは WebVR には関係ありませんが、ゲームの仕上がりに良い効果をもたらします。</span><span class="sxs-lookup"><span data-stu-id="d6c94-207">While this doesn't relate to WebVR, it's a nice finishing touch to the game.</span></span> <span data-ttu-id="d6c94-208">これにより、恐竜がプレイヤーを見つけるか、プレイヤーが捕まったときに、空に薄い色がつきます。</span><span class="sxs-lookup"><span data-stu-id="d6c94-208">This will add a tint to our sky when the dinosaur detects the player and after the player has been caught.</span></span>

### <a name="step-1-player-detected-changes"></a><span data-ttu-id="d6c94-209">手順 1: プレイヤーが見つかった場合の変更</span><span class="sxs-lookup"><span data-stu-id="d6c94-209">Step 1: Player detected changes</span></span>

<span data-ttu-id="d6c94-210">恐竜がプレイヤーを見つけると、霧が赤色に変わります。</span><span class="sxs-lookup"><span data-stu-id="d6c94-210">When the dinosaur has detected the player, we'll make the fog turn red.</span></span> <span data-ttu-id="d6c94-211">プレイヤーが恐竜から逃れると、空は元の色 (グレイ) に戻ります。</span><span class="sxs-lookup"><span data-stu-id="d6c94-211">If the player evades the dinosaur, we make sure to switch the sky back to normal (grey).</span></span>


<span data-ttu-id="d6c94-212">現在の `beginChase()` 関数を次のコードで置き換えます。</span><span class="sxs-lookup"><span data-stu-id="d6c94-212">Replace your current `beginChase()` function with this code.</span></span>
```javascript
    function beginChase(distanceAway) {
        if (distanceAway < CHASERANGE) {
              // Change fog to red
            scene.fogColor = new BABYLON.Color3(.5, 0, 0);
            dino.lookAt(new BABYLON.Vector3(camera.position.x, dino.position.y, camera.position.z));
            // Switch fog back to grey, dino out of range
        } else {
            scene.fogColor = new BABYLON.Color3(0.9, 0.9, 0.85);
        }
    }
```


### <a name="step-2-player-caught-changes"></a><span data-ttu-id="d6c94-213">手順 2: プレイヤーが捕まった場合の変更</span><span class="sxs-lookup"><span data-stu-id="d6c94-213">Step 2: Player caught changes</span></span>

<span data-ttu-id="d6c94-214">プレイヤーが捕まった後で空を黒くするため、`caught()` 関数の始めに色の変更を追加します。</span><span class="sxs-lookup"><span data-stu-id="d6c94-214">To make the sky turn black after the player has been caught, we'll add a color change to the beginning of the `caught()` function.</span></span> <span data-ttu-id="d6c94-215">さらに `caught()` で、プレイヤーが身体を動かさないようにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="d6c94-215">Within `caught()`,we also want to prevent the player from moving their body.</span></span> <span data-ttu-id="d6c94-216">これは `FreeCameraKeyboardMoveInput` を削除することにより行えます。</span><span class="sxs-lookup"><span data-stu-id="d6c94-216">We can do this by removing the `FreeCameraKeyboardMoveInput`.</span></span> <span data-ttu-id="d6c94-217">これによって、プレイヤーは移動することはできず、頭を動かすことだけができます。</span><span class="sxs-lookup"><span data-stu-id="d6c94-217">This means the player won't be able to move, and will be allowed only to look around with their head.</span></span>


<span data-ttu-id="d6c94-218">現在の `caught()` 関数を次のコードで置き換えます。</span><span class="sxs-lookup"><span data-stu-id="d6c94-218">Replace your current `caught()` function with this code.</span></span>
```javascript
    function caught() {
        // Change fog to black
        scene.fogColor = new BABYLON.Color3(0, 0, 0);
        gameOver = true;

        // Disable all movement except head rotation
        camera.inputs.removeByType("FreeCameraKeyboardMoveInput");

        if (frameCount % ROARDIVISOR == 0) {
            dino.skeleton.beginAnimation("roar", false, .5, function () {
                dino.skeleton.beginAnimation("stand", true, .5);
            });
        }
        frameCount++;
    }
```

![最終的な VR ビュー](images/vrfinal.png)

## <a name="conclusion"></a><span data-ttu-id="d6c94-220">まとめ</span><span class="sxs-lookup"><span data-stu-id="d6c94-220">Conclusion</span></span>

<span data-ttu-id="d6c94-221">これで終了です。</span><span class="sxs-lookup"><span data-stu-id="d6c94-221">Congratulations!</span></span> <span data-ttu-id="d6c94-222">WebVR サポートが追加された、完全な Babylon.js ゲームが完成しました。</span><span class="sxs-lookup"><span data-stu-id="d6c94-222">You now have a complete Babylon.js game with WebVR support.</span></span> <span data-ttu-id="d6c94-223">学習した内容を利用して、さらにこのゲームを改良したり、変更したりできます。</span><span class="sxs-lookup"><span data-stu-id="d6c94-223">From here you can take what you've learned to build an even better game, or build off this one.</span></span>


