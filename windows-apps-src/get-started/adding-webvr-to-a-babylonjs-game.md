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
# <a name="get-started-tutorial---adding-webvr-support-to-a-3d-babylonjs-game"></a>入門チュートリアル - 3D Babylon.js ゲームに WebVR サポートを追加する

Babylon.js を使って 3D ゲームを作成したことがあり、仮想現実 (VR) をサポートしてみたいと考えている場合には、次の簡単な手順に沿って、実現することができます。

次に示すゲームに WebVR サポートを追加します。 Xbox コントローラーを接続して、試してみてください。

<iframe height='300' scrolling='no' title='Babylon.js dino game' src='//codepen.io/MicrosoftEdgeDocumentation/embed/MmgdWp/?height=300&theme-id=23761&default-tab=result&embed-version=2&editable=true' frameborder='no' allowtransparency='true' allowfullscreen='true' style='width: 100%;'><a href='http://codepen.io'>CodePen</a> で、Microsoft Edge Docs (<a href='http://codepen.io/MicrosoftEdgeDocumentation'>@MicrosoftEdgeDocumentation</a>) による Pen (<a href='http://codepen.io/MicrosoftEdgeDocumentation/pen/MmgdWp/'>Babylon.js dino game</a>) をご覧ください。
</iframe>

これはフラット画面上では適切に動作する 3D ゲームですが、VR ではどうなるでしょうか。
このチュートリアルでは、このゲームを WebVR で実行できるようにするための、いつくかの手順について説明します。 [Windows Mixed Reality](https://developer.microsoft.com/en-us/windows/mixed-reality) ヘッドセットを使って、Microsoft Edge に追加された WebVR サポートを利用します。 これらの変更をゲームに適用すると、WebVR をサポートする他のブラウザー/ヘッドセットの組み合わせでも動作します。



## <a name="prerequisites"></a>前提条件

- テキスト エディター ([Visual Studio Code](https://code.visualstudio.com/download) など)
- コンピューターに接続されている Xbox コントローラー
- Windows 10 Creators Update
- [Windows Mixed Reality を実行するための最小要件仕様](https://developer.microsoft.com/en-us/windows/mixed-reality/immersive_headset_setup)を満たすコンピューター
- Windows Mixed Reality デバイス (オプション) 



## <a name="getting-started"></a>はじめに

最も簡単に始める方法は、[Windows-tutorials-web GitHub repo](https://github.com/Microsoft/Windows-tutorials-web) に移動して、緑色の [**Clone or download**] (複製またはダウンロード) ボタンを押し、[**Open in Visual Studio**] (Visual Studio で開く) を選択することです。

![[Clone or download] (複製またはダウンロード) ボタン](images/3dclone.png)

プロジェクトを複製しない場合は、zip ファイルとしてダウンロードすることもできます。
[[Before](https://github.com/Microsoft/Windows-tutorials-web/tree/master/BabylonJS-game-with-WebVR/before)] と [[After](https://github.com/Microsoft/Windows-tutorials-web/tree/master/BabylonJS-game-with-WebVR/after)] という 2 つのフォルダーがあります。 [Before] フォルダーは VR 機能が追加される前のゲームで、[After] フォルダーは、VR サポートを追加して完成したゲームです。

[Before] と [After] のフォルダーには、次のファイルが含まれています。
-   textures/ - ゲームで使用するイメージを含むフォルダー。
-   css/ - ゲームの CSS を含むフォルダー。
-   js/ - JavaScript ファイルが含まれるフォルダー。 main.js ファイルはゲームで、他のファイルは使用されるライブラリです。
-   models/ - 3D モデルが含まれるフォルダー。 このゲームでは、恐竜の 1 つのモデルのみがあります。
-   Index.html - ゲームのレンダラーをホストする Web ページです。 Edge でこのページを開くと、ゲームが起動します。

Edge でそれぞれの index.html ファイルを開くと、ゲームの両方のバージョンをテストできます。



## <a name="the-mixed-reality-portal"></a>Mixed Reality ポータル

Windows Mixed Reality をまだお使いでなく、Windows 10 Creators Update がコンピューターにインストールされており、Windows Mixed Reality に対応しているグラフィックス カードが備えられている場合は、Windows 10 のスタート メニューから [**Mixed Reality ポータル**] アプリを開いてみてください。

![Mixed Reality ポータルの検索](images/mixed-reality-portal.png)

すべての要件が満たされいる場合、開発者向け機能をオンにすると、コンピューターに接続された Windows Mixed Reality ヘッドセットをシミュレートできます。 また既に実際のヘッドセットをお持ちの場合は、接続してセットアップを実行します。

> [!IMPORTANT]
> Mixed Reality ポータルは、このチュートリアルの間、常に開いておく必要があります。

これで Edge を使って WebVR を試す準備ができました。

## <a name="2d-ui-in-a-virtual-world"></a>仮想世界の 2D UI

>[!NOTE]
> スターター コードは [[**Before**](https://github.com/Microsoft/Windows-tutorials-web/tree/master/BabylonJS-game-with-WebVR/before)] フォルダーにあります。

現在使われている [`Canvas2D`](http://doc.babylonjs.com/classes/2.5/canvas2d) 要素は仮想現実では十分に動作しないため、このゲームではすべての 2D UI を削除または変更します。
スタート UI を更新して VR で動作するようにします。簡単のため、距離カウンターとゲームオーバー UI の処理は省略します。


### <a name="step-1-creating-a-worldspacecanvas2d-object"></a>手順 1: WorldSpaceCanvas2D オブジェクトを作成する

`create2d()` 関数で、すべてを削除し、UI テキストを保持する新しい [`Text2D`](http://doc.babylonjs.com/classes/2.5/text2d) オブジェクトを追加します。 その `Text2D` オブジェクトと新しい[`WorldSpaceCanvas2D`](http://doc.babylonjs.com/classes/2.5/worldspacecanvas2d) オブジェクトを使用します。 `WorldSpaceCanvas2D` は 3D 環境に配置できる 2D UI です (3D キャンバスの上に UI のレイヤーを追加する [`ScreenSpaceCanvas2D`](http://doc.babylonjs.com/classes/2.5/screenspacecanvas2d) オブジェクトとは異なります)。


このコードを、既存の `var create2d = function...` コードの上に貼り付けます。
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

これで 2D UI をシーンに追加する準備ができました。 


### <a name="step-2-positioning-2d-ui"></a>手順 2: 2D UI を配置する

`createScene` 関数で、コードを数行記述して、シーンから UI を追加し、ユーザーの前に配置します。


このコードを `skybox.material = skyboxMaterial;` の後に貼り付けます。
```javascript
        canvas2d = create2d(scene);
        canvas2d.worldSpaceCanvasNode.position = new BABYLON.Vector3(0, 30, 175);
```

### <a name="step-3-toggling-2d-ui-visibility"></a>手順 3: 2D UI の表示を切り替える
ゲームの開始後にスタート UI を非表示にするため、**A** ボタンの押下チェックを変更して、`canvas2d` の `isVisible = false;` 呼び出しを含めます。


このコードを現在の `xboxpad.onbuttondown` 呼び出しの上に貼り付けます。
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

### <a name="step-4-resizing"></a>手順 4: サイズを変更する 
UI への最後の変更として、`onWindowResize()` 関数を更新して UI への参照をすべて削除します。これはウィンドウのサイズの影響を受けなくなったためです。

次のコードを `onWindowResize()` 関数の上に貼り付けます。
```javascript
function onWindowResize() {
     engine.resize();
}
```


Edge で index.html ファイルを開くと、ゲームを読み込むことができます。 2D UI が 3D 世界に表示されます。

![startUI](images/startUI.png)



## <a name="detecting-headsets"></a>ヘッドセットを検出する

VR アプリで 2 種類のカメラを備えて、複数のシナリオをサポートすることは、推奨されるプラクティスです。 このゲームでは、ヘッドセットの接続を必要とする 1 つのカメラと、ヘッドセットを使用しないもう 1 つのカメラをサポートします。 ゲームでどちらを使用するかを判断するため、最初にヘッドセットが検出されたかどうかをチェックする必要があります。 これには、[navigator.getVRDisplays()](https://msdn.microsoft.com/en-us/library/mt793853(v=vs.85).aspx) を使用します。


次のコードを `window.addEventListener('DOMContentLoaded')` の前に追加します。
```javascript
var headset;
// If a VR headset is connected, get its info
navigator.getVRDisplays().then(function (displays) {
    if (displays[0]) {
        headset = displays[0];
    }
});
```

`headset` 変数に保存されている情報を使って、ユーザーに適切なカメラを選択することができます。


## <a name="selecting-the-initial-camera"></a>初期のカメラを選択する

Babylon.js では、[WebVRFreeCamera](http://doc.babylonjs.com/classes/2.5/webvrfreecamera) を使って、WebVR をすばやく追加することができます。 このカメラはキーボード入力を受け取ることができ、VR ヘッドセットを使用して、「ヘッド」の回転を制御することができます。


### <a name="step-1-checking-for-headsets"></a>手順 1: ヘッドセットを確認する

フォールバック カメラには、元のゲームで使用されている [UniversalCamera](https://doc.babylonjs.com/classes/2.5/universalcamera) を使用します。

`headset` 変数を確認して、**WebVRFreeCamera** カメラを使用できるかどうかを判断します。

次のコードで `camera = new BABYLON.UniversalCamera("Camera", new BABYLON.Vector3(0, 18, -45), scene);` を置き換えます。
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

### <a name="step-2-activating-the-webvrfreecamera"></a>手順 2: WebVRFreeCamera をアクティブ化する
ほとんどのブラウザーでは、このカメラをアクティブ化するため、仮想操作を要求するいくつかの操作を実行する必要があります。

この機能をマウス クリックにフックします。その後、スタート UI のテキストを更新して、異なる指示を表示するようにします。


`createScene()` 関数内のコードを `camera.applyGravity = true;` の後に貼り付けます。
```javascript
        scene.onPointerDown = function () {
            startUI.children[0].text = "Dino is to your right! Press A button to start. L analog stick to move.";
            scene.onPointerDown = undefined
            camera.attachControl(canvas, true);
        }
```

ゲームでクリックすると、次のようなプロンプトが表示されます。一度ユーザーがこのプロンプトに答えると、次回以降はすぐにヘッドセットにゲームを表示します。

![イマーシブのプロンプト](images/immersiveview.png)


### <a name="step-3-adding-gamepad-support"></a>手順 3: ゲームパッドのサポートを追加する

**WebVRFreeCamera** は最初はゲームパッドをサポートしないため、ゲームパッドのボタンをキーボードの方向キーにマッピングします。 カメラの**入力**プロパティの詳細な設定でこれを行います。 左のアナログ スティックの上、下、左、右を方向キーに対応させるコードを追加します。これでゲームパッドを使えるようになります。


次のコードを `scene.onPointerDown = function() {...} 呼び出しの下に 追加します。
``` javascript
    // Custom input, adding Xbox controller support for left analog stick to map to keyboard arrows
    camera.inputs.attached.keyboard.keysUp.push(211);    // Left analog up
    camera.inputs.attached.keyboard.keysDown.push(212);  // Left analog down
    camera.inputs.attached.keyboard.keysLeft.push(214);  // Left analog left
    camera.inputs.attached.keyboard.keysRight.push(213); // Left analog right
```

このゲームでは、ユーザーが向く方向が常に前方となります。 たとえば、壁を見ている場合に、左のアナログ スティックの上を押すと、壁に向かって前に進みます。

### <a name="step-4-give-it-a-try"></a>手順 4: 試してみる

ヘッドセットとゲーム コントローラーを接続して index.html を開き、青いゲーム ウィンドウで左クリックすると、ゲームが VR モードに切り替わります。 ヘッドセットを装着して、結果を確認します。 

次のセクションでは、Edge ブラウザーで VR モードを終了するときに発生する不快感について説明します。またヘッドセットが接続されていない場合の対応についても説明します。

![VR での指示ボックス](images/webvrfreecamera.png)



## <a name="swapping-between-cameras"></a>カメラを切り替える

**WebVRFreeCamera** のみを使用できる場合には、WebVR を終了しようとするときに、Edge ブラウザーで画面が斜めになる場合があります (このカメラはヘッドセットがコンテンツを表示するときのみ動作するためです)。

シーンでアクティブなカメラが突然失われると、Edge の表示がビューの間で切り替わり、ちらつきが発生します。 これを防ぐため、バックアップの **UniversalCamera** を追加して、ヘッドセットをオフにした後、または **ESC** を押したとき、または Edge のタブが切り替わるときに、表示するようにします。


VR ヘッドセットは接続したままにできますが、コンテンツは表示されません。 `headset` 変数を使用できるため、`animate()` 関数を使って、ヘッドセットが `isPresenting` プロパティを使用して表示しているかどうかを確認します。 ヘッドセットが表示している場合には、**WebVRFreeCamera** をアクティブなままにします。表示していない場合には、バックアップの **UniversalCamera** に切り替えます。


この `if` のチェックを `engine.runRenderLoop()` の下に追加します。
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


## <a name="ending-the-game-and-fog-changes"></a>ゲームを終了して霧を変更する

最後に、いくつかの呼び出しを追加して、霧の色を調整します。 これは WebVR には関係ありませんが、ゲームの仕上がりに良い効果をもたらします。 これにより、恐竜がプレイヤーを見つけるか、プレイヤーが捕まったときに、空に薄い色がつきます。

### <a name="step-1-player-detected-changes"></a>手順 1: プレイヤーが見つかった場合の変更

恐竜がプレイヤーを見つけると、霧が赤色に変わります。 プレイヤーが恐竜から逃れると、空は元の色 (グレイ) に戻ります。


現在の `beginChase()` 関数を次のコードで置き換えます。
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


### <a name="step-2-player-caught-changes"></a>手順 2: プレイヤーが捕まった場合の変更

プレイヤーが捕まった後で空を黒くするため、`caught()` 関数の始めに色の変更を追加します。 さらに `caught()` で、プレイヤーが身体を動かさないようにする必要があります。 これは `FreeCameraKeyboardMoveInput` を削除することにより行えます。 これによって、プレイヤーは移動することはできず、頭を動かすことだけができます。


現在の `caught()` 関数を次のコードで置き換えます。
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

## <a name="conclusion"></a>まとめ

これで終了です。 WebVR サポートが追加された、完全な Babylon.js ゲームが完成しました。 学習した内容を利用して、さらにこのゲームを改良したり、変更したりできます。


