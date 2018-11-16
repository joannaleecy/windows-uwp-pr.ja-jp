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
ms.sourcegitcommit: e38b334edb82bf2b1474ba686990f4299b8f59c7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/15/2018
ms.locfileid: "6856169"
---
# <a name="adding-webvr-support-to-a-3d-babylonjs-game"></a>3D Babylon.js ゲームに WebVR サポートを追加

Babylon.js を使って 3D ゲームを作成したことがあり、仮想現実 (VR) をサポートしてみたいと考えている場合には、次の簡単な手順に沿って、実現することができます。

次に示すゲームに WebVR サポートを追加します。 Xbox コントローラーを接続して、試してみてください。


<iframe height='300' scrolling='no' title='Babylon.GUI を使用して Babylon.js dino ゲーム' src='//codepen.io/MicrosoftEdgeDocumentation/embed/preview/wrOvoj/?height=300&theme-id=23761&default-tab=result&embed-version=2&editable=true' frameborder='no' allowtransparency='true' allowfullscreen='true' style='width: 100%;'>Microsoft Edge Docs ペン<a href='https://codepen.io/MicrosoftEdgeDocumentation/pen/wrOvoj/'>Babylon.GUI を使用して Babylon.js dino ゲーム</a>を参照してください (<a href='https://codepen.io/MicrosoftEdgeDocumentation'>@MicrosoftEdgeDocumentation</a>) <a href='https://codepen.io'>CodePen</a>でします。
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
-   **テクスチャ/** - ゲームで使用するイメージを含むフォルダー。
-   **css/** - ゲームの CSS を含むフォルダー。
-   **js/** - JavaScript ファイルが含まれるフォルダー。 main.js ファイルはゲームで、他のファイルは使用されるライブラリです。
-   **モデル/** - 3D モデルが含まれるフォルダー。 このゲームでは、恐竜の 1 つのモデルのみがあります。
-   **index.html** - ゲームのレンダラーをホストする web ページです。 Microsoft Edge でこのページを開くと、ゲームが起動します。

Microsoft Edge でそれぞれの index.html ファイルを開くことによって、ゲームの両方のバージョンをテストすることができます。



## <a name="the-mixed-reality-portal"></a>Mixed Reality ポータル

Windows Mixed Reality をまだお使いでなく、Windows 10 Creators Update がコンピューターにインストールされており、Windows Mixed Reality に対応しているグラフィックス カードが備えられている場合は、Windows 10 のスタート メニューから [**Mixed Reality ポータル**] アプリを開いてみてください。

![Mixed Reality ポータルの検索](images/mixed-reality-portal.png)

すべての要件が満たされいる場合、開発者向け機能をオンにすると、コンピューターに接続された Windows Mixed Reality ヘッドセットをシミュレートできます。 また既に実際のヘッドセットをお持ちの場合は、接続してセットアップを実行します。

> [!IMPORTANT]
> Mixed Reality ポータルは、このチュートリアルの間、常に開いておく必要があります。

これで、Microsoft Edge で webvr を取得する準備ができました。

## <a name="2d-ui-in-a-virtual-world"></a>仮想世界の 2D UI

>[!NOTE]
> スターター サンプルを取得する[**前に**](https://github.com/Microsoft/Windows-tutorials-web/tree/master/BabylonJS-game-with-WebVR/before)フォルダーを取得します。

[Babylon.GUI](https://doc.babylonjs.com/how_to/gui) VR フレンドリーなライブラリは、対話ユーザー インターフェイスの VR 適切に動作する単純なを作成して、VR で非表示を有効にします。
Babylon.js、拡張機能を`GUI`ライブラリは throuhout 2D 要素を作成するサンプルを使用します。


2D テキスト`GUI`要素を調整する属性の数に応じて、いくつかの行で作成できます。
次のコード スニペットは、既にサンプルでは、[**前に**](https://github.com/Microsoft/Windows-tutorials-web/tree/master/BabylonJS-game-with-WebVR/before)、みましょうが何が起こってチュートリアルです。
最初に行い、[`AdvancedDynamicTexture`](https://doc.babylonjs.com/how_to/gui#advanceddynamictexture)取り上げる GUI を確立するオブジェクト。 サンプルでは、これを設定`CreateFullScreenUI()`、画面全体を取り上げます UI を意味します。 `AdvancedDynamicTexture`を作成し、行いを使用してゲームの開始時に表示される 2D のテキスト ボックス`GUI.Rectanlge()`と`GUI.TextBlock()`します。


このコードは[**main.js**](https://github.com/Microsoft/Windows-tutorials-web/blob/master/BabylonJS-game-with-WebVR/before/js/main.js#L157-L168)内で追加されます。
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


この UI は作成をオンまたはオフを切り替えることが表示されます。`isVisible`によっては、ゲームで何が起こっていたか。
```javascript
startUI.isVisible = false;
```



## <a name="detecting-headsets"></a>ヘッドセットを検出する

VR アプリケーションの 2 種類のカメラを備えて、複数のシナリオをサポートすることをお勧めします。 このゲームでは、ヘッドセットの接続を必要とする 1 つのカメラと、ヘッドセットを使用しないもう 1 つのカメラをサポートします。 ゲームでどちらを使用するかを判断するため、最初にヘッドセットが検出されたかどうかをチェックする必要があります。 そのために使用します[`navigator.getVRDisplays()`](https://developer.mozilla.org/en-US/docs/Web/API/Navigator/getVRDisplays)します。


上記の次のコードを追加`window.addEventListener('DOMContentLoaded')` **main.js**でします。
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


## <a name="creating-and-selecting-the-initial-camera"></a>作成して、初期のカメラを選択します。

Babylon.js を使って WebVR すぐに追加できるを使用して、[`WebVRFreeCamera`](http://doc.babylonjs.com/classes/3.1/webvrfreecamera)します。 このカメラはキーボード入力を受け取ることができ、VR ヘッドセットを使用して、「ヘッド」の回転を制御することができます。


### <a name="step-1-checking-for-headsets"></a>手順 1: ヘッドセットを確認する

フォールバック カメラを使用します、[`UniversalCamera`](https://doc.babylonjs.com/classes/3.1/universalcamera)元のゲームで現在使用されています。

確認、`headset`変数を使用しているかどうかを判断する、`WebVRFreeCamera`カメラ。

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
この機能をマウス クリック フックします。


`createScene()` 関数内のコードを `camera.applyGravity = true;` の後に貼り付けます。
```javascript
        scene.onPointerDown = function () {
            scene.onPointerDown = undefined
            camera.attachControl(canvas, true);
        }
```

ゲームでクリック、次のようなプロンプト以降を表示します、ゲーム、ヘッドセットですぐ、ユーザーがこのプロンプトを受け入れた場合。

![イマーシブのプロンプト](images/immersiveview.png)

表示するコードの追加することも、`UniversalCamera`に切り替える前に、表示、`WebVRFreeCamera`を調べるには、青いウィンドウではなく、ゲームのユーザーを許可します。 

後に、次の追加`engine.runRenderLoop(function () {`します。
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

### <a name="step-3-adding-gamepad-support"></a>手順 3: ゲームパッドのサポートを追加する

`WebVRFreeCamera`最初に、ゲームパッドをサポートしていない、ゲームパッドのボタンをキーボードの方向キーにマッピングします。 それではを行います、 `inputs` 、カメラのプロパティです。 左のアナログ スティックの上、下、左、右を方向キーに対応させるコードを追加します。これでゲームパッドを使えるようになります。


次のコードを追加、`scene.onPointerDown = function() {...}`呼び出します。
``` javascript
    // Custom input, adding Xbox controller support for left analog stick to map to keyboard arrows
    camera.inputs.attached.keyboard.keysUp.push(211);    // Left analog up
    camera.inputs.attached.keyboard.keysDown.push(212);  // Left analog down
    camera.inputs.attached.keyboard.keysLeft.push(214);  // Left analog left
    camera.inputs.attached.keyboard.keysRight.push(213); // Left analog right
```


### <a name="step-4-give-it-a-try"></a>手順 4: 試してみる

ヘッドセットして**index.html**を開き、ゲーム コント ローラーが接続されている場合は、青いゲーム ウィンドウで左クリックと、ゲームが VR モードに切り替わります。 ヘッドセットを装着して、結果を確認します。 


<iframe height='300' scrolling='no' title='Babylon.GUI - WebVR を使用して Babylon.js dino ゲーム' src='//codepen.io/MicrosoftEdgeDocumentation/embed/preview/RjgpJd/?height=300&theme-id=23761&default-tab=result&embed-version=2&editable=true' frameborder='no' allowtransparency='true' allowfullscreen='true' style='width: 100%;'>Microsoft Edge Docs ペン<a href='https://codepen.io/MicrosoftEdgeDocumentation/pen/RjgpJd/'>Babylon.GUI - WebVR を使用して Babylon.js dino ゲーム</a>を参照してください (<a href='https://codepen.io/MicrosoftEdgeDocumentation'>@MicrosoftEdgeDocumentation</a>) <a href='https://codepen.io'>CodePen</a>でします。
</iframe>


## <a name="conclusion"></a>まとめ

これで終了です。 WebVR サポートが追加された、完全な Babylon.js ゲームが完成しました。 学習した内容を利用して、さらにこのゲームを改良したり、変更したりできます。
