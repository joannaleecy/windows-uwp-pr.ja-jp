---
title: 3D の Babylon.js ゲームに WebVR サポートを追加する
description: 既存の 3D Babylon.js ゲームに WebVR サポートを追加する方法について説明します。
ms.date: 11/29/2017
ms.topic: article
keywords: WebVR、Edge、Web 開発、Babylon、Babylonjs、Babylon.js、JavaScript
ms.localizationpriority: medium
ms.openlocfilehash: 1d8029752790e19adc5eb4266615372fb346e001
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57638557"
---
# <a name="adding-webvr-support-to-a-3d-babylonjs-game"></a>3D の Babylon.js ゲームに WebVR サポートを追加する

Babylon.js を使って 3D ゲームを作成したことがあり、仮想現実 (VR) をサポートしてみたいと考えている場合には、次の簡単な手順に沿って、実現することができます。

次に示すゲームに WebVR サポートを追加します。 Xbox コントローラーを接続して、試してみてください。


<iframe height='300' scrolling='no' title='Babylon.GUI を使用して、Babylon.js dino ゲーム' src='//codepen.io/MicrosoftEdgeDocumentation/embed/preview/wrOvoj/?height=300&theme-id=23761&default-tab=result&embed-version=2&editable=true' frameborder='no' allowtransparency='true' allowfullscreen='true' style='width: 100%;'>ペンを参照してください<a href='https://codepen.io/MicrosoftEdgeDocumentation/pen/wrOvoj/'>Babylon.GUI を使用して、Babylon.js dino ゲーム</a>で Microsoft Edge の Docs (<a href='https://codepen.io/MicrosoftEdgeDocumentation'>@MicrosoftEdgeDocumentation</a>) で<a href='https://codepen.io'>CodePen</a>します。
</iframe>

これはフラット画面上では適切に動作する 3D ゲームですが、VR ではどうなるでしょうか。
このチュートリアルでは、このゲームを WebVR で実行できるようにするための、いつくかの手順について説明します。 [Windows Mixed Reality](https://developer.microsoft.com/en-us/windows/mixed-reality) ヘッドセットを使って、Microsoft Edge に追加された WebVR サポートを利用します。 これらの変更をゲームに適用すると、WebVR をサポートする他のブラウザー/ヘッドセットの組み合わせでも動作します。



## <a name="prerequisites"></a>前提条件

- テキスト エディター ([Visual Studio Code](https://code.visualstudio.com/download) など)
- コンピューターに接続されている Xbox コントローラー
- Windows 10 Creators Update
- [Windows Mixed Reality を実行するための最小要件仕様](https://developer.microsoft.com/en-us/windows/mixed-reality/immersive_headset_setup)を満たすコンピューター
- Windows Mixed Reality デバイス (オプション) 



## <a name="getting-started"></a>概要

最も簡単に始める方法は、[Windows-tutorials-web GitHub repo](https://github.com/Microsoft/Windows-tutorials-web) に移動して、緑色の **[Clone or download]** (複製またはダウンロード) ボタンを押し、**[Open in Visual Studio]** (Visual Studio で開く) を選択することです。

![[Clone or download] (複製またはダウンロード) ボタン](images/3dclone.png)

プロジェクトを複製しない場合は、zip ファイルとしてダウンロードすることもできます。
[[Before](https://github.com/Microsoft/Windows-tutorials-web/tree/master/BabylonJS-game-with-WebVR/before)] と [[After](https://github.com/Microsoft/Windows-tutorials-web/tree/master/BabylonJS-game-with-WebVR/after)] という 2 つのフォルダーがあります。 [Before] フォルダーは VR 機能が追加される前のゲームで、[After] フォルダーは、VR サポートを追加して完成したゲームです。

[Before] と [After] のフォルダーには、次のファイルが含まれています。
-   **テクスチャ/** - ゲームで使用するイメージを格納するフォルダー。
-   **css/** - ゲームの CSS を含むフォルダー。
-   **js/** - JavaScript ファイルを含むフォルダー。 main.js ファイルはゲームで、他のファイルは使用されるライブラリです。
-   **モデル/** - 3D モデルを含むフォルダー。 このゲームでは、恐竜の 1 つのモデルのみがあります。
-   **index.html** -ゲームのレンダラーをホストする web ページ。 Microsoft Edge でのこのページを開くには、ゲームが起動します。

ゲームの両方のバージョンをテストするには、Microsoft Edge で、それぞれの index.html ファイルを開きます。



## <a name="the-mixed-reality-portal"></a>Mixed Reality ポータル

Windows Mixed Reality をまだお使いでなく、Windows 10 Creators Update がコンピューターにインストールされており、Windows Mixed Reality に対応しているグラフィックス カードが備えられている場合は、Windows 10 のスタート メニューから **[Mixed Reality ポータル]** アプリを開いてみてください。

![Mixed Reality ポータルの検索](images/mixed-reality-portal.png)

すべての要件が満たされいる場合、開発者向け機能をオンにすると、コンピューターに接続された Windows Mixed Reality ヘッドセットをシミュレートできます。 また既に実際のヘッドセットをお持ちの場合は、接続してセットアップを実行します。

> [!IMPORTANT]
> Mixed Reality ポータルは、このチュートリアルの間、常に開いておく必要があります。

Microsoft Edge で WebVR を体験する準備ができました。

## <a name="2d-ui-in-a-virtual-world"></a>仮想世界の 2D UI

>[!NOTE]
> 取得、 [**する前に**](https://github.com/Microsoft/Windows-tutorials-web/tree/master/BabylonJS-game-with-WebVR/before) starter サンプルを取得するフォルダー。

[Babylon.GUI](https://doc.babylonjs.com/how_to/gui) VR に適したライブラリ、対話型ユーザー インターフェイス VR のも、その作業を単純なを作成して VR 以外を表示できるようにすることです。
拡張機能、Babylon.js が、`GUI`ライブラリは throuhout 2D 要素を作成するサンプルを使用します。


2D テキスト`GUI`要素を調整する属性の数に応じて、いくつかの行で作成できます。
次のコード スニペットは既に、 [**する前に**](https://github.com/Microsoft/Windows-tutorials-web/tree/master/BabylonJS-game-with-WebVR/before)サンプルが、それでは何が起きているチュートリアル。
最初に、 [ `AdvancedDynamicTexture` ](https://doc.babylonjs.com/how_to/gui#advanceddynamictexture)取り上げる GUI を確立するオブジェクト。 サンプルでは、これを設定`CreateFullScreenUI()`、つまり、UI 画面全体がカバーされます。 `AdvancedDynamicTexture`を作成し、行ったゲームの使用の開始時に表示された 2D テキスト ボックス`GUI.Rectanlge()`と`GUI.TextBlock()`します。


このコードは内で追加[ **main.js**](https://github.com/Microsoft/Windows-tutorials-web/blob/master/BabylonJS-game-with-WebVR/before/js/main.js#L157-L168)します。
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


この UI が表示されるは、作成した後でオンまたはオフに切り替えることができます`isVisible`ゲームでは、何が起こっているかによって異なります。
```javascript
startUI.isVisible = false;
```



## <a name="detecting-headsets"></a>ヘッドセットを検出する

複数のシナリオをサポートするように 2 つの種類のカメラには、VR アプリケーションのことをお勧めします。 このゲームでは、ヘッドセットの接続を必要とする 1 つのカメラと、ヘッドセットを使用しないもう 1 つのカメラをサポートします。 ゲームでどちらを使用するかを判断するため、最初にヘッドセットが検出されたかどうかをチェックする必要があります。 そのために使用します[ `navigator.getVRDisplays()`](https://developer.mozilla.org/en-US/docs/Web/API/Navigator/getVRDisplays)します。


このコードで追加`window.addEventListener('DOMContentLoaded')`で**main.js**します。
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


## <a name="creating-and-selecting-the-initial-camera"></a>作成して、初期カメラを選択

Babylon.js、WebVR 追加できるすばやくを使用して、 [ `WebVRFreeCamera`](https://doc.babylonjs.com/classes/3.1/webvrfreecamera)します。 このカメラはキーボード入力を受け取ることができ、VR ヘッドセットを使用して、「ヘッド」の回転を制御することができます。


### <a name="step-1-checking-for-headsets"></a>手順 1:ヘッドセットのチェック

使用するフォールバック、カメラ、 [ `UniversalCamera` ](https://doc.babylonjs.com/classes/3.1/universalcamera)元のゲームで現在使用されています。

いたします、`headset`変数を使用できるかどうかを判断、`WebVRFreeCamera`カメラ。

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


### <a name="step-2-activating-the-webvrfreecamera"></a>手順 2:WebVRFreeCamera をアクティブ化します。
ほとんどのブラウザーでは、このカメラをアクティブ化するため、仮想操作を要求するいくつかの操作を実行する必要があります。
マウスのクリックまでこの機能をフックします。


`createScene()` 関数内のコードを `camera.applyGravity = true;` の後に貼り付けます。
```javascript
        scene.onPointerDown = function () {
            scene.onPointerDown = undefined
            camera.attachControl(canvas, true);
        }
```

ゲームをクリックして、次のようなプロンプトを作成するか、ユーザーが前にプロンプトを受け入れられた場合に、ヘッドセットでゲームをすぐ表示ようになりました。

![イマーシブのプロンプト](images/immersiveview.png)

表示するコードの 1 つ追加することも、`UniversalCamera`ための前に表示、`WebVRFreeCamera`ユーザーが青のウィンドウではなく、ゲームを確認できるようにします。 

後に次の追加`engine.runRenderLoop(function () {`します。
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

### <a name="step-3-adding-gamepad-support"></a>手順 3:ゲームパッドのサポートの追加

以降、`WebVRFreeCamera`ゲームパッドを最初にサポートしていないキーボードの矢印キーをゲームパッド ボタンをマッピングします。 これを掘り下げは、`inputs`カメラのプロパティ。 左のアナログ スティックの上、下、左、右を方向キーに対応させるコードを追加します。これでゲームパッドを使えるようになります。


この次のコードを追加、`scene.onPointerDown = function() {...}`呼び出します。
``` javascript
    // Custom input, adding Xbox controller support for left analog stick to map to keyboard arrows
    camera.inputs.attached.keyboard.keysUp.push(211);    // Left analog up
    camera.inputs.attached.keyboard.keysDown.push(212);  // Left analog down
    camera.inputs.attached.keyboard.keysLeft.push(214);  // Left analog left
    camera.inputs.attached.keyboard.keysRight.push(213); // Left analog right
```


### <a name="step-4-give-it-a-try"></a>手順 4:試してみてください。

開く場合**index.html**ヘッドセットとゲーム コント ローラーの電源接続時に、青いゲーム画面の左クリックは、VR モードにゲームが切り替えるされます! ヘッドセットを装着して、結果を確認します。 


<iframe height='300' scrolling='no' title='Babylon.GUI - WebVR を使用して、Babylon.js dino ゲーム' src='//codepen.io/MicrosoftEdgeDocumentation/embed/preview/RjgpJd/?height=300&theme-id=23761&default-tab=result&embed-version=2&editable=true' frameborder='no' allowtransparency='true' allowfullscreen='true' style='width: 100%;'>ペンを参照してください<a href='https://codepen.io/MicrosoftEdgeDocumentation/pen/RjgpJd/'>Babylon.GUI - WebVR を使用して、Babylon.js dino ゲーム</a>で Microsoft Edge の Docs (<a href='https://codepen.io/MicrosoftEdgeDocumentation'>@MicrosoftEdgeDocumentation</a>) で<a href='https://codepen.io'>CodePen</a>します。
</iframe>


## <a name="conclusion"></a>まとめ

これで終了です。 WebVR サポートが追加された、完全な Babylon.js ゲームが完成しました。 学習した内容を利用して、さらにこのゲームを改良したり、変更したりできます。
