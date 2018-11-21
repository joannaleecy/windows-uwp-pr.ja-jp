---
title: 3D Babylon.js ゲームに WebVR サポートを追加
description: 既存の 3D Babylon.js ゲームに WebVR サポートを追加する方法について説明します。
author: abbycar
ms.author: abigailc
ms.date: 11/29/2017
ms.topic: article
keywords: WebVR、Edge、Web 開発、Babylon、Babylonjs、Babylon.js、JavaScript
ms.localizationpriority: medium
ms.openlocfilehash: 72681c3f91fc2dcbfcc4e4531359d6d668e18b80
ms.sourcegitcommit: 93c0a60cf531c7d9fe7b00e7cf78df86906f9d6e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/21/2018
ms.locfileid: "7553267"
---
# <a name="adding-webvr-support-to-a-3d-babylonjs-game"></a><span data-ttu-id="7b12a-104">3D Babylon.js ゲームに WebVR サポートを追加</span><span class="sxs-lookup"><span data-stu-id="7b12a-104">Adding WebVR support to a 3D Babylon.js game</span></span>

<span data-ttu-id="7b12a-105">Babylon.js を使って 3D ゲームを作成したことがあり、仮想現実 (VR) をサポートしてみたいと考えている場合には、次の簡単な手順に沿って、実現することができます。</span><span class="sxs-lookup"><span data-stu-id="7b12a-105">If you've created a 3D game with Babylon.js and thought that it might look great in virtual reality (VR), follow the simple steps in this tutorial to make that a reality.</span></span>

<span data-ttu-id="7b12a-106">次に示すゲームに WebVR サポートを追加します。</span><span class="sxs-lookup"><span data-stu-id="7b12a-106">We'll add WebVR support to the game shown here.</span></span> <span data-ttu-id="7b12a-107">Xbox コントローラーを接続して、試してみてください。</span><span class="sxs-lookup"><span data-stu-id="7b12a-107">Go ahead and plug in an Xbox controller to try it out!</span></span>


<iframe height='300' scrolling='no' title='<span data-ttu-id="7b12a-108">Babylon.GUI を使用して Babylon.js dino ゲーム</span><span class="sxs-lookup"><span data-stu-id="7b12a-108">Babylon.js dino game using Babylon.GUI</span></span>' src='//codepen.io/MicrosoftEdgeDocumentation/embed/preview/wrOvoj/?height=300&theme-id=23761&default-tab=result&embed-version=2&editable=true' frameborder='no' allowtransparency='true' allowfullscreen='true' style='width: 100%;'><span data-ttu-id="7b12a-109">Microsoft Edge Docs ペン<a href='https://codepen.io/MicrosoftEdgeDocumentation/pen/wrOvoj/'>Babylon.GUI を使用して Babylon.js dino ゲーム</a>を参照してください (<a href='https://codepen.io/MicrosoftEdgeDocumentation'>@MicrosoftEdgeDocumentation</a>) <a href='https://codepen.io'>CodePen</a>でします。</span><span class="sxs-lookup"><span data-stu-id="7b12a-109">See the Pen <a href='https://codepen.io/MicrosoftEdgeDocumentation/pen/wrOvoj/'>Babylon.js dino game using Babylon.GUI</a> by Microsoft Edge Docs (<a href='https://codepen.io/MicrosoftEdgeDocumentation'>@MicrosoftEdgeDocumentation</a>) on <a href='https://codepen.io'>CodePen</a>.</span></span>
</iframe>

<span data-ttu-id="7b12a-110">これはフラット画面上では適切に動作する 3D ゲームですが、VR ではどうなるでしょうか。</span><span class="sxs-lookup"><span data-stu-id="7b12a-110">This is a 3D game that works well on a flat screen, but what about in VR?</span></span>
<span data-ttu-id="7b12a-111">このチュートリアルでは、このゲームを WebVR で実行できるようにするための、いつくかの手順について説明します。</span><span class="sxs-lookup"><span data-stu-id="7b12a-111">In this tutorial, we'll walk through the few steps it takes to get this up and running with WebVR.</span></span> <span data-ttu-id="7b12a-112">[Windows Mixed Reality](https://developer.microsoft.com/en-us/windows/mixed-reality) ヘッドセットを使って、Microsoft Edge に追加された WebVR サポートを利用します。</span><span class="sxs-lookup"><span data-stu-id="7b12a-112">We’ll use a [Windows Mixed Reality](https://developer.microsoft.com/en-us/windows/mixed-reality) headset that can tap into the added support for WebVR in Microsoft Edge.</span></span> <span data-ttu-id="7b12a-113">これらの変更をゲームに適用すると、WebVR をサポートする他のブラウザー/ヘッドセットの組み合わせでも動作します。</span><span class="sxs-lookup"><span data-stu-id="7b12a-113">After we apply these changes to the game, you can expect it also to work in other browser/headset combinations that support WebVR.</span></span>



## <a name="prerequisites"></a><span data-ttu-id="7b12a-114">前提条件</span><span class="sxs-lookup"><span data-stu-id="7b12a-114">Prerequisites</span></span>

- <span data-ttu-id="7b12a-115">テキスト エディター ([Visual Studio Code](https://code.visualstudio.com/download) など)</span><span class="sxs-lookup"><span data-stu-id="7b12a-115">A text editor (like [Visual Studio Code](https://code.visualstudio.com/download))</span></span>
- <span data-ttu-id="7b12a-116">コンピューターに接続されている Xbox コントローラー</span><span class="sxs-lookup"><span data-stu-id="7b12a-116">An Xbox controller that’s plugged in to your computer</span></span>
- <span data-ttu-id="7b12a-117">Windows 10 Creators Update</span><span class="sxs-lookup"><span data-stu-id="7b12a-117">Windows 10 Creators Update</span></span>
- <span data-ttu-id="7b12a-118">[Windows Mixed Reality を実行するための最小要件仕様](https://developer.microsoft.com/en-us/windows/mixed-reality/immersive_headset_setup)を満たすコンピューター</span><span class="sxs-lookup"><span data-stu-id="7b12a-118">A computer with the [minimum required specs to run Windows Mixed Reality](https://developer.microsoft.com/en-us/windows/mixed-reality/immersive_headset_setup)</span></span>
- <span data-ttu-id="7b12a-119">Windows Mixed Reality デバイス (オプション)</span><span class="sxs-lookup"><span data-stu-id="7b12a-119">A Windows Mixed Reality device (Optional)</span></span> 



## <a name="getting-started"></a><span data-ttu-id="7b12a-120">はじめに</span><span class="sxs-lookup"><span data-stu-id="7b12a-120">Getting started</span></span>

<span data-ttu-id="7b12a-121">最も簡単に始める方法は、[Windows-tutorials-web GitHub repo](https://github.com/Microsoft/Windows-tutorials-web) に移動して、緑色の [**Clone or download**] (複製またはダウンロード) ボタンを押し、[**Open in Visual Studio**] (Visual Studio で開く) を選択することです。</span><span class="sxs-lookup"><span data-stu-id="7b12a-121">The simplest way to get started is to visit the [Windows-tutorials-web GitHub repo](https://github.com/Microsoft/Windows-tutorials-web), press the green **Clone or download** button, and select **Open in Visual Studio**.</span></span>

![[Clone or download] (複製またはダウンロード) ボタン](images/3dclone.png)

<span data-ttu-id="7b12a-123">プロジェクトを複製しない場合は、zip ファイルとしてダウンロードすることもできます。</span><span class="sxs-lookup"><span data-stu-id="7b12a-123">If you don't want to clone the project, you can download it as a zip file.</span></span>
<span data-ttu-id="7b12a-124">[[Before](https://github.com/Microsoft/Windows-tutorials-web/tree/master/BabylonJS-game-with-WebVR/before)] と [[After](https://github.com/Microsoft/Windows-tutorials-web/tree/master/BabylonJS-game-with-WebVR/after)] という 2 つのフォルダーがあります。</span><span class="sxs-lookup"><span data-stu-id="7b12a-124">You'll then have two folders, [before](https://github.com/Microsoft/Windows-tutorials-web/tree/master/BabylonJS-game-with-WebVR/before) and [after](https://github.com/Microsoft/Windows-tutorials-web/tree/master/BabylonJS-game-with-WebVR/after).</span></span> <span data-ttu-id="7b12a-125">[Before] フォルダーは VR 機能が追加される前のゲームで、[After] フォルダーは、VR サポートを追加して完成したゲームです。</span><span class="sxs-lookup"><span data-stu-id="7b12a-125">The "before" folder is our game before any VR features are added, and the "after" folder is the finished game with VR support.</span></span>

<span data-ttu-id="7b12a-126">[Before] と [After] のフォルダーには、次のファイルが含まれています。</span><span class="sxs-lookup"><span data-stu-id="7b12a-126">The before and after folders contain these files:</span></span>
-   <span data-ttu-id="7b12a-127">**テクスチャ/** - ゲームで使用するイメージを含むフォルダー。</span><span class="sxs-lookup"><span data-stu-id="7b12a-127">**textures/** - A folder containing any images used in the game.</span></span>
-   <span data-ttu-id="7b12a-128">**css/** - ゲームの CSS を含むフォルダー。</span><span class="sxs-lookup"><span data-stu-id="7b12a-128">**css/** - A folder containing the CSS for the game.</span></span>
-   <span data-ttu-id="7b12a-129">**js/** - JavaScript ファイルが含まれるフォルダー。</span><span class="sxs-lookup"><span data-stu-id="7b12a-129">**js/** - A folder containing the JavaScript files.</span></span> <span data-ttu-id="7b12a-130">main.js ファイルはゲームで、他のファイルは使用されるライブラリです。</span><span class="sxs-lookup"><span data-stu-id="7b12a-130">The main.js file is our game, and the other files are the libraries used.</span></span>
-   <span data-ttu-id="7b12a-131">**モデル/** - 3D モデルが含まれるフォルダー。</span><span class="sxs-lookup"><span data-stu-id="7b12a-131">**models/** - A folder containing the 3D models.</span></span> <span data-ttu-id="7b12a-132">このゲームでは、恐竜の 1 つのモデルのみがあります。</span><span class="sxs-lookup"><span data-stu-id="7b12a-132">For this game we have only one model, for the dinosaur.</span></span>
-   <span data-ttu-id="7b12a-133">**index.html** - ゲームのレンダラーをホストする web ページです。</span><span class="sxs-lookup"><span data-stu-id="7b12a-133">**index.html** - The webpage that hosts the game's renderer.</span></span> <span data-ttu-id="7b12a-134">Microsoft Edge でこのページを開くと、ゲームが起動します。</span><span class="sxs-lookup"><span data-stu-id="7b12a-134">Opening this page in Microsoft Edge launches the game.</span></span>

<span data-ttu-id="7b12a-135">Microsoft Edge でそれぞれの index.html ファイルを開くことによって、ゲームの両方のバージョンをテストすることができます。</span><span class="sxs-lookup"><span data-stu-id="7b12a-135">You can test both versions of the game by opening their respective index.html files in Microsoft Edge.</span></span>



## <a name="the-mixed-reality-portal"></a><span data-ttu-id="7b12a-136">Mixed Reality ポータル</span><span class="sxs-lookup"><span data-stu-id="7b12a-136">The Mixed Reality Portal</span></span>

<span data-ttu-id="7b12a-137">Windows Mixed Reality をまだお使いでなく、Windows 10 Creators Update がコンピューターにインストールされており、Windows Mixed Reality に対応しているグラフィックス カードが備えられている場合は、Windows 10 のスタート メニューから [**Mixed Reality ポータル**] アプリを開いてみてください。</span><span class="sxs-lookup"><span data-stu-id="7b12a-137">If you're unfamiliar with Windows Mixed Reality and have the Windows 10 Creators Update installed on a computer with a compatible graphics card, try opening the **Mixed Reality Portal** app from the Start menu in Windows 10.</span></span>

![Mixed Reality ポータルの検索](images/mixed-reality-portal.png)

<span data-ttu-id="7b12a-139">すべての要件が満たされいる場合、開発者向け機能をオンにすると、コンピューターに接続された Windows Mixed Reality ヘッドセットをシミュレートできます。</span><span class="sxs-lookup"><span data-stu-id="7b12a-139">If you met all the requirements, you can then turn on developer features and simulate a Windows Mixed Reality headset plugged in to your computer.</span></span> <span data-ttu-id="7b12a-140">また既に実際のヘッドセットをお持ちの場合は、接続してセットアップを実行します。</span><span class="sxs-lookup"><span data-stu-id="7b12a-140">If you're fortunate enough to have an actual headset nearby, plug it in and run the setup.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="7b12a-141">Mixed Reality ポータルは、このチュートリアルの間、常に開いておく必要があります。</span><span class="sxs-lookup"><span data-stu-id="7b12a-141">The Mixed Reality Portal must be open at all times during this tutorial.</span></span>

<span data-ttu-id="7b12a-142">これで、Microsoft Edge で webvr を取得する準備ができました。</span><span class="sxs-lookup"><span data-stu-id="7b12a-142">You're now ready to experience WebVR with Microsoft Edge.</span></span>

## <a name="2d-ui-in-a-virtual-world"></a><span data-ttu-id="7b12a-143">仮想世界の 2D UI</span><span class="sxs-lookup"><span data-stu-id="7b12a-143">2D UI in a virtual world</span></span>

>[!NOTE]
> <span data-ttu-id="7b12a-144">スターター サンプルを取得する[**前に**](https://github.com/Microsoft/Windows-tutorials-web/tree/master/BabylonJS-game-with-WebVR/before)フォルダーを取得します。</span><span class="sxs-lookup"><span data-stu-id="7b12a-144">Grab the [**before**](https://github.com/Microsoft/Windows-tutorials-web/tree/master/BabylonJS-game-with-WebVR/before) folder to get the starter sample.</span></span>

<span data-ttu-id="7b12a-145">[Babylon.GUI](https://doc.babylonjs.com/how_to/gui) VR フレンドリーなライブラリは、対話ユーザー インターフェイスの VR 適切に動作する単純なを作成して、VR で非表示を有効にします。</span><span class="sxs-lookup"><span data-stu-id="7b12a-145">[Babylon.GUI](https://doc.babylonjs.com/how_to/gui) is a VR-friendly library, enabling you to create simple, interactive user interfaces that work well for VR and non-VR displays.</span></span>
<span data-ttu-id="7b12a-146">Babylon.js、拡張機能を`GUI`ライブラリは throuhout 2D 要素を作成するサンプルを使用します。</span><span class="sxs-lookup"><span data-stu-id="7b12a-146">An extension to Babylon.js, the `GUI` library is used throuhout the sample to create 2D elements.</span></span>


<span data-ttu-id="7b12a-147">2D テキスト`GUI`要素を調整する属性の数に応じて、いくつかの行で作成できます。</span><span class="sxs-lookup"><span data-stu-id="7b12a-147">A 2D text `GUI` element can be created with a few lines depending on how many attributes you want to tweak.</span></span>
<span data-ttu-id="7b12a-148">次のコード スニペットは、既にサンプルでは、[**前に**](https://github.com/Microsoft/Windows-tutorials-web/tree/master/BabylonJS-game-with-WebVR/before)、みましょうが何が起こってチュートリアルです。</span><span class="sxs-lookup"><span data-stu-id="7b12a-148">The following code snippet is already in our [**before**](https://github.com/Microsoft/Windows-tutorials-web/tree/master/BabylonJS-game-with-WebVR/before) sample, but let's walkthrough what's happening.</span></span>
<span data-ttu-id="7b12a-149">最初に行い、[`AdvancedDynamicTexture`](https://doc.babylonjs.com/how_to/gui#advanceddynamictexture)取り上げる GUI を確立するオブジェクト。</span><span class="sxs-lookup"><span data-stu-id="7b12a-149">We first make an [`AdvancedDynamicTexture`](https://doc.babylonjs.com/how_to/gui#advanceddynamictexture) object to establish what the GUI will cover.</span></span> <span data-ttu-id="7b12a-150">サンプルでは、これを設定`CreateFullScreenUI()`、画面全体を取り上げます UI を意味します。</span><span class="sxs-lookup"><span data-stu-id="7b12a-150">The sample sets this to `CreateFullScreenUI()`, meaning our UI will cover the entire screen.</span></span> <span data-ttu-id="7b12a-151">`AdvancedDynamicTexture`を作成し、行いを使用してゲームの開始時に表示される 2D のテキスト ボックス`GUI.Rectanlge()`と`GUI.TextBlock()`します。</span><span class="sxs-lookup"><span data-stu-id="7b12a-151">With `AdvancedDynamicTexture` created, we then make a 2D text box that appears upon starting the game using `GUI.Rectanlge()` and `GUI.TextBlock()`.</span></span>


<span data-ttu-id="7b12a-152">このコードは[**main.js**](https://github.com/Microsoft/Windows-tutorials-web/blob/master/BabylonJS-game-with-WebVR/before/js/main.js#L157-L168)内で追加されます。</span><span class="sxs-lookup"><span data-stu-id="7b12a-152">This code is added within [**main.js**](https://github.com/Microsoft/Windows-tutorials-web/blob/master/BabylonJS-game-with-WebVR/before/js/main.js#L157-L168).</span></span>
```javascript
// GUI
var advancedTexture = BABYLON.GUI.AdvancedDynamicTexture.CreateFullscreenUI("UI");

// Start UI
startUI = new BABYLON.GUI.Rectangle("start");
startUI.background = "black"
startUI.alpha = .8;
startUI.thickness = 0;
startUI.height = "60px";
startUI.width = "400px";
advancedTexture.addControl(startUI); 
var tex2 = new BABYLON.GUI.TextBlock();
tex2.text = "Stay away from the dinosaur! \n Plug in an Xbox controller and press A to start";
tex2.color = "white";
startUI.addControl(tex2); 
```


<span data-ttu-id="7b12a-153">この UI は作成をオンまたはオフを切り替えることが表示されます。`isVisible`によっては、ゲームで何が起こっていたか。</span><span class="sxs-lookup"><span data-stu-id="7b12a-153">This UI is visible once created but can be toggled on or off with `isVisible` depending on what's happening in the game.</span></span>
```javascript
startUI.isVisible = false;
```



## <a name="detecting-headsets"></a><span data-ttu-id="7b12a-154">ヘッドセットを検出する</span><span class="sxs-lookup"><span data-stu-id="7b12a-154">Detecting headsets</span></span>

<span data-ttu-id="7b12a-155">VR アプリケーションの 2 種類のカメラを備えて、複数のシナリオをサポートすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="7b12a-155">It's good practice for VR applications to have two types of cameras so that multiple scenarios can be supported.</span></span> <span data-ttu-id="7b12a-156">このゲームでは、ヘッドセットの接続を必要とする 1 つのカメラと、ヘッドセットを使用しないもう 1 つのカメラをサポートします。</span><span class="sxs-lookup"><span data-stu-id="7b12a-156">For this game, we'll support one camera that requires a working headset to be plugged in, and another that uses no headset.</span></span> <span data-ttu-id="7b12a-157">ゲームでどちらを使用するかを判断するため、最初にヘッドセットが検出されたかどうかをチェックする必要があります。</span><span class="sxs-lookup"><span data-stu-id="7b12a-157">To determine which one the game will use, we must first check to see whether a headset has been detected.</span></span> <span data-ttu-id="7b12a-158">そのために使用します[`navigator.getVRDisplays()`](https://developer.mozilla.org/en-US/docs/Web/API/Navigator/getVRDisplays)します。</span><span class="sxs-lookup"><span data-stu-id="7b12a-158">To do that, we’ll use [`navigator.getVRDisplays()`](https://developer.mozilla.org/en-US/docs/Web/API/Navigator/getVRDisplays).</span></span>


<span data-ttu-id="7b12a-159">上記の次のコードを追加`window.addEventListener('DOMContentLoaded')` **main.js**でします。</span><span class="sxs-lookup"><span data-stu-id="7b12a-159">Add this code above `window.addEventListener('DOMContentLoaded')` in **main.js**.</span></span>
```javascript
var headset;
// If a VR headset is connected, get its info
navigator.getVRDisplays().then(function (displays) {
    if (displays[0]) {
        headset = displays[0];
    }
});
```

<span data-ttu-id="7b12a-160">`headset` 変数に保存されている情報を使って、ユーザーに適切なカメラを選択することができます。</span><span class="sxs-lookup"><span data-stu-id="7b12a-160">With the info stored in the `headset` variable, we'll now be able to choose the camera that’s right for the user.</span></span>


## <a name="creating-and-selecting-the-initial-camera"></a><span data-ttu-id="7b12a-161">作成して、初期のカメラを選択します。</span><span class="sxs-lookup"><span data-stu-id="7b12a-161">Creating and selecting the initial camera</span></span>

<span data-ttu-id="7b12a-162">Babylon.js を使って WebVR すぐに追加できるを使用して、[`WebVRFreeCamera`](http://doc.babylonjs.com/classes/3.1/webvrfreecamera)します。</span><span class="sxs-lookup"><span data-stu-id="7b12a-162">With Babylon.js, WebVR can be added quickly by using the [`WebVRFreeCamera`](http://doc.babylonjs.com/classes/3.1/webvrfreecamera).</span></span> <span data-ttu-id="7b12a-163">このカメラはキーボード入力を受け取ることができ、VR ヘッドセットを使用して、「ヘッド」の回転を制御することができます。</span><span class="sxs-lookup"><span data-stu-id="7b12a-163">This camera can take keyboard input and enables you to use a VR headset to control your "head" rotation.</span></span>


### <a name="step-1-checking-for-headsets"></a><span data-ttu-id="7b12a-164">手順 1: ヘッドセットを確認する</span><span class="sxs-lookup"><span data-stu-id="7b12a-164">Step 1: Checking for headsets</span></span>

<span data-ttu-id="7b12a-165">フォールバック カメラを使用します、[`UniversalCamera`](https://doc.babylonjs.com/classes/3.1/universalcamera)元のゲームで現在使用されています。</span><span class="sxs-lookup"><span data-stu-id="7b12a-165">For our fallback camera, we'll be using the [`UniversalCamera`](https://doc.babylonjs.com/classes/3.1/universalcamera) that’s currently used in the original game.</span></span>

<span data-ttu-id="7b12a-166">確認、`headset`変数を使用しているかどうかを判断する、`WebVRFreeCamera`カメラ。</span><span class="sxs-lookup"><span data-stu-id="7b12a-166">We'll check our `headset` variable to determine whether we can use the `WebVRFreeCamera` camera.</span></span>

<span data-ttu-id="7b12a-167">次のコードで `camera = new BABYLON.UniversalCamera("Camera", new BABYLON.Vector3(0, 18, -45), scene);` を置き換えます。</span><span class="sxs-lookup"><span data-stu-id="7b12a-167">Replace `camera = new BABYLON.UniversalCamera("Camera", new BABYLON.Vector3(0, 18, -45), scene);` with the following code.</span></span>
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


### <a name="step-2-activating-the-webvrfreecamera"></a><span data-ttu-id="7b12a-168">手順 2: WebVRFreeCamera をアクティブ化する</span><span class="sxs-lookup"><span data-stu-id="7b12a-168">Step 2: Activating the WebVRFreeCamera</span></span>
<span data-ttu-id="7b12a-169">ほとんどのブラウザーでは、このカメラをアクティブ化するため、仮想操作を要求するいくつかの操作を実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="7b12a-169">To activate this camera in most browsers, the user must perform some interaction that requests the virtual experience.</span></span>
<span data-ttu-id="7b12a-170">この機能をマウス クリック フックします。</span><span class="sxs-lookup"><span data-stu-id="7b12a-170">We'll hook this functionality up to a mouse click.</span></span>


<span data-ttu-id="7b12a-171">`createScene()` 関数内のコードを `camera.applyGravity = true;` の後に貼り付けます。</span><span class="sxs-lookup"><span data-stu-id="7b12a-171">Paste the code within  `createScene()` function after `camera.applyGravity = true;` .</span></span>
```javascript
        scene.onPointerDown = function () {
            scene.onPointerDown = undefined
            camera.attachControl(canvas, true);
        }
```

<span data-ttu-id="7b12a-172">ゲームでクリック、次のようなプロンプト以降を表示します、ゲーム、ヘッドセットですぐ、ユーザーがこのプロンプトを受け入れた場合。</span><span class="sxs-lookup"><span data-stu-id="7b12a-172">A click in the game now creates a prompt like the following, or displays the game in the headset right away if the user has accepted the prompt before.</span></span>

![イマーシブのプロンプト](images/immersiveview.png)

<span data-ttu-id="7b12a-174">表示するコードの追加することも、`UniversalCamera`に切り替える前に、表示、`WebVRFreeCamera`を調べるには、青いウィンドウではなく、ゲームのユーザーを許可します。</span><span class="sxs-lookup"><span data-stu-id="7b12a-174">We can also add a piece of code that will display the `UniversalCamera` view before we switch to our `WebVRFreeCamera`, allowing the user to look at the game instead of a blue window.</span></span> 

<span data-ttu-id="7b12a-175">後に、次の追加`engine.runRenderLoop(function () {`します。</span><span class="sxs-lookup"><span data-stu-id="7b12a-175">Add the following after `engine.runRenderLoop(function () {`.</span></span>
```javascript
            if (headset) {
                if (!(headset.isPresenting)) {
                    var camera2 = new BABYLON.UniversalCamera("Camera", new BABYLON.Vector3(0, 18, -45), scene);
                    scene.activeCamera = camera2;
                } else {
                    scene.activeCamera = camera;
                }
            }
```

### <a name="step-3-adding-gamepad-support"></a><span data-ttu-id="7b12a-176">手順 3: ゲームパッドのサポートを追加する</span><span class="sxs-lookup"><span data-stu-id="7b12a-176">Step 3: Adding gamepad support</span></span>

<span data-ttu-id="7b12a-177">`WebVRFreeCamera`最初に、ゲームパッドをサポートしていない、ゲームパッドのボタンをキーボードの方向キーにマッピングします。</span><span class="sxs-lookup"><span data-stu-id="7b12a-177">Since the `WebVRFreeCamera` doesn't initially support gamepads, we'll map our gamepad buttons to the keyboard arrow keys.</span></span> <span data-ttu-id="7b12a-178">それではを行います、 `inputs` 、カメラのプロパティです。</span><span class="sxs-lookup"><span data-stu-id="7b12a-178">We'll do this by digging into the `inputs` property of the camera.</span></span> <span data-ttu-id="7b12a-179">左のアナログ スティックの上、下、左、右を方向キーに対応させるコードを追加します。これでゲームパッドを使えるようになります。</span><span class="sxs-lookup"><span data-stu-id="7b12a-179">By adding the corresponding codes for left analog stick up, down, left, and right to match up with the arrow keys, our gamepad is back in action.</span></span>


<span data-ttu-id="7b12a-180">次のコードを追加、`scene.onPointerDown = function() {...}`呼び出します。</span><span class="sxs-lookup"><span data-stu-id="7b12a-180">Add this code below the `scene.onPointerDown = function() {...}` call.</span></span>
``` javascript
    // Custom input, adding Xbox controller support for left analog stick to map to keyboard arrows
    camera.inputs.attached.keyboard.keysUp.push(211);    // Left analog up
    camera.inputs.attached.keyboard.keysDown.push(212);  // Left analog down
    camera.inputs.attached.keyboard.keysLeft.push(214);  // Left analog left
    camera.inputs.attached.keyboard.keysRight.push(213); // Left analog right
```


### <a name="step-4-give-it-a-try"></a><span data-ttu-id="7b12a-181">手順 4: 試してみる</span><span class="sxs-lookup"><span data-stu-id="7b12a-181">Step 4: Give it a try!</span></span>

<span data-ttu-id="7b12a-182">ヘッドセットして**index.html**を開き、ゲーム コント ローラーが接続されている場合は、青いゲーム ウィンドウで左クリックと、ゲームが VR モードに切り替わります。</span><span class="sxs-lookup"><span data-stu-id="7b12a-182">If we open **index.html** with our headset and game controller plugged in, a left click on the blue game window will switch our game to VR mode!</span></span> <span data-ttu-id="7b12a-183">ヘッドセットを装着して、結果を確認します。</span><span class="sxs-lookup"><span data-stu-id="7b12a-183">Go ahead and put on your headset to check out the results.</span></span> 


<iframe height='300' scrolling='no' title='<span data-ttu-id="7b12a-184">Babylon.GUI - WebVR を使用して Babylon.js dino ゲーム</span><span class="sxs-lookup"><span data-stu-id="7b12a-184">Babylon.js dino game using Babylon.GUI - WebVR</span></span>' src='//codepen.io/MicrosoftEdgeDocumentation/embed/preview/RjgpJd/?height=300&theme-id=23761&default-tab=result&embed-version=2&editable=true' frameborder='no' allowtransparency='true' allowfullscreen='true' style='width: 100%;'><span data-ttu-id="7b12a-185">Microsoft Edge Docs ペン<a href='https://codepen.io/MicrosoftEdgeDocumentation/pen/RjgpJd/'>Babylon.GUI - WebVR を使用して Babylon.js dino ゲーム</a>を参照してください (<a href='https://codepen.io/MicrosoftEdgeDocumentation'>@MicrosoftEdgeDocumentation</a>) <a href='https://codepen.io'>CodePen</a>でします。</span><span class="sxs-lookup"><span data-stu-id="7b12a-185">See the Pen <a href='https://codepen.io/MicrosoftEdgeDocumentation/pen/RjgpJd/'>Babylon.js dino game using Babylon.GUI - WebVR</a> by Microsoft Edge Docs (<a href='https://codepen.io/MicrosoftEdgeDocumentation'>@MicrosoftEdgeDocumentation</a>) on <a href='https://codepen.io'>CodePen</a>.</span></span>
</iframe>


## <a name="conclusion"></a><span data-ttu-id="7b12a-186">まとめ</span><span class="sxs-lookup"><span data-stu-id="7b12a-186">Conclusion</span></span>

<span data-ttu-id="7b12a-187">これで終了です。</span><span class="sxs-lookup"><span data-stu-id="7b12a-187">Congratulations!</span></span> <span data-ttu-id="7b12a-188">WebVR サポートが追加された、完全な Babylon.js ゲームが完成しました。</span><span class="sxs-lookup"><span data-stu-id="7b12a-188">You now have a complete Babylon.js game with WebVR support.</span></span> <span data-ttu-id="7b12a-189">学習した内容を利用して、さらにこのゲームを改良したり、変更したりできます。</span><span class="sxs-lookup"><span data-stu-id="7b12a-189">From here you can take what you've learned to build an even better game, or build off this one.</span></span>
