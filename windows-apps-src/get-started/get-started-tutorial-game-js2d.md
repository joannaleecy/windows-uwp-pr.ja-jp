---
title: JavaScript で UWP ゲームを作成する
description: JavaScript と CreateJS で記述された Microsoft Store のゲームのシンプルな UWP
author: GrantMeStrength
ms.author: jken
ms.date: 02/09/2017
ms.topic: article
keywords: Windows 10, UWP
ms.assetid: 01af8254-b073-445e-af4c-e474528f8aa3
ms.localizationpriority: medium
ms.openlocfilehash: 597451826958c355dad9f9380dbdc1264bc87883
ms.sourcegitcommit: e814a13978f33654d8e995584f4b047cb53e0aef
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/05/2018
ms.locfileid: "6044449"
---
# <a name="create-a-uwp-game-in-javascript"></a>JavaScript で UWP ゲームを作成する

## <a name="a-simple-2d-uwp-game-for-the-microsoft-store-written-in-javascript-and-createjs"></a>JavaScript と CreateJS で記述された Microsoft Store 向けのシンプルな 2D UWP ゲーム


![Walking Dino スプライト シート](images/JS2D_1.png)


## <a name="introduction"></a>はじめに


Microsoft Store にアプリを公開することができます共有 (または販売!) 何百万もの多くの異なるデバイス上のユーザーとします。  

Microsoft Store にアプリを公開するために、UWP (ユニバーサル Windows プラットフォーム) アプリとして記述する必要があります。 ただし、UWP はきわめて柔軟であり、多様な言語およびフレームワークをサポートしています。 これを証明するために、いくつかの CreateJS ライブラリを活用して JavaScript で記述されたシンプルなゲームをサンプルとして紹介します。このサンプルでは、スプライトの記述、ゲーム ループの作成、キーボードとマウスのサポート、さまざまな画面サイズへの調整の方法を示します。

このプロジェクトは、Visual Studio を使って JavaScript で構築します。 少し変更を加えると、Web サイトでホスティングすることも、他のプラットフォームに合わせることもできます。 

**注:** ない、完全な (または適切な) のゲームアプリようにする、Microsoft Store に公開する準備が JavaScript やサード パーティのライブラリを使用する方法を示すために設計されています。


## <a name="requirements"></a>要件

このプロジェクトを操作するには、以下が必要になります。

* 現在のバージョンの Windows 10 を実行する Windows コンピューター (または仮想マシン)。
* Visual Studio。 無料の Visual Studio Community Edition は、[Visual Studio ホームページ](http://visualstudio.com)からダウンロードできます。

このプロジェクトでは、CreateJS という JavaScript フレームワークを使用します。 CreateJS は、MIT ライセンスの下にリリースされる無料のツールであり、スプライト ベースのゲームを簡単に作成できるように設計されています。 CreateJS ライブラリは、既にプロジェクトに含まれています (ソリューション エクスプローラー ビューで *js/easeljs-0.8.2.min.js* および *js/preloadjs-0.6.2.min.js* を探してください)。 CreateJS について詳しくは、[CreateJS ホーム ページ](http://www.createjs.com)をご覧ください。


## <a name="getting-started"></a>はじめに

アプリの完全なソース コードは、[GitHub](https://github.com/Microsoft/Windows-appsample-get-started-js2d) にあります。

最も簡単に始める方法は、GitHub のページで、緑色の **[Clone or download]** (複製またはダウンロード) ボタンをクリックし、**[Open in Visual Studio]** (Visual Studio で開く) を選択することです。 

![リポジトリを複製する](images/JS2D_2.png)

[GitHub プロジェクト](https://msdn.microsoft.com/en-us/windows/uwp/get-started/get-uwp-app-samples)は、zip ファイルとしてダウンロードすることも、その他の標準的な方法で操作することもできます。

ソリューションを Visual Studio に読み込むと、次のようなファイルが表示されます。

* Images/ - UWP アプリに必要なさまざまなアイコン、ゲームの SpriteSheet、その他のビットマップが含まれるフォルダー。
* js/ - JavaScript ファイルが含まれるフォルダー。 main.js ファイルはゲームで、その他のファイルは EaselJS と PreloadJS です。
* index.html - ゲームのグラフィックをホストする canvas オブジェクトが含まれる Web ページ。

これでゲームを実行できます。

**F5** キーを押して、アプリの実行を開始します。 ウィンドウを開いていると、(スパース) 場合は、のどか横向きありふれた恐竜が表示されます。 それでは、アプリを調べていきましょう。重要な部分について説明し、他の機能についても、その都度明らかにします。

![ありふれた恐竜の背中に、ニンジャ キャットが乗っている](images/JS2D_3.png)

**注:** うまくいかない場合は、 Web サポートを含めて Visual Studio がインストールされていることを確認してください。 これは、新しいプロジェクトを作成することで確認できます。JavaScript のサポートが含まれていない場合は、*[Microsoft Web Developer Tools]* ボックスをオンにして Visual Studio を再インストールする必要があります。

## <a name="walkthough"></a>チュートリアル

F5 キーでゲームを開始した場合は、内部的に何が起こっているのか疑問に思うかもしれません。 その答えは、"できません"とコードの多くは、現在コメント アウトします。これまでは、すべてが表示されますが、恐竜 Space キーを押すだけ要請です。 

### <a name="1-setting-the-stage"></a>1. ステージを設定する

**index.html** を開いて内容を見ると、ほとんど空であることがわかります。 このファイルはアプリを含む既定の Web ページであり、重要な役割は次の 2 つだけです。 1 つ目は、CreateJS の **EaselJS** ライブラリおよび **PreloadJS**  ライブラリと **main.js** (このチュートリアルのソース コード ファイル) の JavaScript ソース コードが含まれていることです。
2 つ目は、すべてのグラフィックスを表示する場所として、&lt;canvas&gt; タグが定義されていることです。 &lt;canvas&gt; は、HTML5 ドキュメントの標準コンポーネントです。 これには、**main.js** のコードから参照できるように gameCanvas という名前を付けます。 JavaScript で独自のゲームを 1 から記述する場合は、**EaselJS** ファイルと **PreloadJS** ファイルをソリューションにコピーして、canvas オブジェクトを作成する必要があります。

EaselJS では、*stage* と呼ばれる新しいオブジェクトが提供されます。 stage は canvas にリンクされ、画像とテキストを表示するために使用されます。 stage に表示するオブジェクトはすべて、まず stage の子として以下のように追加する必要があります。

```
    stage.addChild(myObject);
```

このコード行は、**main.js** に数回出てきます。

それでは、**main.js** を開いてみましょう。

### <a name="2-loading-the-bitmaps"></a>2. ビットマップを読み込む

EaselJS では、数種類のグラフィック オブジェクトが提供されます。 単純な図形 (空に使用する青色の長方形など)、ビットマップ (後で追加する雲など)、テキスト オブジェクト、ストライプを作成できます。 スプライト (SpriteSheet) を使用して [http://createjs.com/docs/easeljs/classes/SpriteSheet.html]: 複数の画像を含む単一ビットマップです。 たとえば、この SpriteSheet を使用して、共有アニメーションの複数フレームを格納することができます。

![Walking Dino スプライト シート](images/JS2D_4.png)

恐竜を歩かせるには、複数のフレームを定義し、アニメーション化する際の速度をこのコードで指定します。

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

ここで、小さくてふわふわした雲をいくつか、stage に追加します。 ゲームが実行されると、画面上に雲が漂います。 雲の画像は、既にソリューションの *images* フォルダーに含まれています。

**main.js** 内で、**init()** 関数を見つけます。 この関数は、ゲームが開始されると呼び出されます。すべてのグラフィック オブジェクトのセットアップは、ここから開始します。

以下のコードを見つけて、雲の画像を参照する行からコメント (\\) を削除します。

```
 manifest = [
        { src: "walkingDino-SpriteSheet.png", id: "dino" },
        { src: "barrel.png", id: "barrel" },
        { src: "fluffy-cloud-small.png", id: "cloud" },
    ];
```

画像などのリソースを読み込むには JavaScript を少し補助する必要があるため、画像をプリロードするための [LoadQueue](http://www.createjs.com/docs/preloadjs/classes/LoadQueue.html) という CreateJS ライブラリの機能を使用します。 画像の読み込みにどの程度の時間がかかるか予測できないため、LoadQueue を使用して処理します。 これにより、画像の準備ができると、キューによる通知を受けることができます。 そのためにはまず、すべての画像をリストした新しいオブジェクトを作成してから、LoadQueue オブジェクトを作成します。 下のコードに示すように、このオブジェクトは、すべての準備が整ったら **loadingComplete()** という関数が呼び出されるようにセットアップされています。

```
    // Now we create a special queue, and finally a handler that is
    // called when they are loaded. The queue object is provided by preloadjs.

    loader = new createjs.LoadQueue(false);
    loader.addEventListener("complete", loadingComplete);
    loader.loadManifest(manifest, true, "../images/");
```    

関数 **loadingComplete()** が呼び出されると、画像が読み込まれ、使用可能な状態になります。 コメントアウトされていたセクションでは雲を作成しますが、そのためのビットマップが使用できます。 コメントを削除すると、次のようになります。

```
    // Create some clouds to drift by..
    for (var i = 0; i < 3; i++) {
        cloud[i] = new createjs.Bitmap(loader.getResult("cloud"));
        cloud[i].x = Math.random()*1024; // Random start location
        cloud[i].y = 64 + i * 48;
        stage.addChild(cloud[i]);
    }
```
このコードでは、プリロードされた画像をそれぞれ使用する cloud オブジェクトを 3 つ作成し、これらの位置を定義して、stage に追加しています。

アプリをもう一度実行 (press F5 を押す) すると、雲が表示されます。

### <a name="3-moving-the-clouds"></a>3. 雲を動かす

次は、雲が動くようにします。 雲を (または、あらゆる物を) を動かすための秘策は、1 秒に何度も呼び出される [ticker](http://www.createjs.com/docs/easeljs/classes/Ticker.html) 関数をセットアップすることです。 この関数が呼び出されるたびに、少し位置を変えてグラフィックスが再描画されます。

<p data-height="500" data-theme-id="23761" data-slug-hash="vxZVRK" data-default-tab="result" data-user="MicrosoftEdgeDocumentation" data-embed-version="2" data-pen-title="CreateJS - Animating clouds" data-preview="true" data-editable="true" class="codepen"><a href="http://codepen.io">CodePen</a> で、Microsoft Edge Docs (<a href="http://codepen.io/MicrosoftEdgeDocumentation">@MicrosoftEdgeDocumentation</a>) による Pen (<a href="https://codepen.io/MicrosoftEdgeDocumentation/pen/vxZVRK/">CreateJS - Animating clouds</a>) をご覧ください。</p>
<script async src="https://production-assets.codepen.io/assets/embed/ei.js"></script>
 
そのためのコードは既に **main.js** に含まれ、CreateJS ライブラリの EaselJS から提供されています。 次のような内容です。

```
    // Set up the game loop and keyboard handler.
    // The keyword 'tick' is required to automatically animated the sprite.
    createjs.Ticker.timingMode = createjs.Ticker.RAF;
    createjs.Ticker.addEventListener("tick", gameLoop);
```

このコードでは、**gameLoop()** という関数が 1 秒あたり 30 ～ 60 回呼び出されます。 正確な速度は、使用するコンピューターの速度によって異なります。

**gameLoop()** 関数を探すと、終わりの方に **animateClouds()** という関数が記述されています。 編集してコメント アウトを解除してください。

```
    // Move clouds
    animateClouds();
```

この関数の定義を見ると、それぞれの雲を順番に表示し、その際に X 座標を変化させていることがわかります。 X 座標が画面の左端に到達すると、右端にリセットされます。 また、それぞれの雲は、やや異なる速度で動きます。

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

ここでアプリを実行すると、雲が漂い始めます。 ついに、動かすことができました!

### <a name="4-adding-keyboard-and-mouse-input"></a>4. キーボード/マウス入力を追加する

ユーザーが操作できないゲームは、ゲームとは言えません。 そこで、ユーザーがキーボードまたはマウスを使って何かできるようにしてみましょう。 **loadingComplete()** 関数に戻ると、次のようなコードがあります。 コメントを削除してください。

```
    // This code will call the method 'keyboardPressed' is the user presses a key.
    this.document.onkeydown = keyboardPressed;

    // Add support for mouse clicks
    stage.on("stagemousedown", mouseClicked);
```

これで、プレイヤーがキーを押すかマウスをクリックしたときに呼び出される 2 つの関数を使用できます。 どちらのイベントでも **userDidSomething()** が呼び出されます。この関数では gamestate 変数を調べて、今ゲームで何が行われているかを判断し、その結果、次に何が必要かを決定します。

Gamestate は、ゲームで一般的に使用される設計パターンです。 発生する動作はすべて、ticker タイマーによって呼び出される **gameLoop()** 関数の中で実行されます。 gameLoop() では、変数を使用して、ゲームがプレイ中か、"ゲーム オーバー状態"、"プレイ準備完了状態、または作者が定義した他の状態であるかを追跡します。 この状態の変数は、switch ステートメント内でテストされ、その結果によって他のどの関数を呼び出すかが決まります。 状態が "playing" に設定されている場合は、恐竜にジャンプさせ、樽を動かす関数が呼び出されます。 一方、何らかの手段で恐竜が倒されると、gamestate 変数が "ゲーム オーバー状態" に設定され、"Game over!"  というメッセージが表示されます。 ゲームの設計パターンに興味がある場合は、「[Game Programming Patterns](http://gameprogrammingpatterns.com/)」(ゲーム プログラミングのパターン) という書籍が役立ちます。

アプリをもう一度実行すると、ついにプレイを開始できます。 Space キーを押す (または、マウスをクリックするか画面をタップする) と、ゲームが始まります。 

樽が、こちらに向かって転がってきます。適切なタイミングで Space キーを押すかもう一度クリックすると、恐竜がジャンプします。 タイミングを間違えると、ゲーム オーバーとなります。

樽は、雲と同じ方法でアニメーション化されます (ただしこちらは毎回速度が速くなります)。恐竜と樽については、衝突しないように位置を確認します。

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

恐竜がジャンプ中ではなく、樽が近くにある場合は、状態変数が *GameOver* という状態に変更されます。 ご想像どおり、*GameOver* 状態になるとゲームが停止します。

また、ゲームのメイン メカニズムも終了します。

### <a name="5-resizing-support"></a>5. サポートのサイズを変更する

これで、ほとんどの作業が終わりました。 ただし、作業を終える前に対処すべき問題がもう 1 つあります。 ゲームの実行中、ウィンドウのサイズを変更してみてください。 オブジェクトの位置が乱れ、ゲームは直ちに混乱状態になります。 この問題は、ウィンドウのサイズ変更イベント用ハンドラーを作成することで処理できます。このイベントは、プレイヤーがウィンドウのサイズを変更したときや、デバイスが回転されて横から縦になったときに発生します。

ハンドラーのコードは既に存在します (UWP アプリの起動時にはウィンドウのサイズがどうなるかわからないため、既定のウィンドウ サイズを使用できるかどうかを確認するために、ゲームが初めて実行されると、このコードが呼び出されます)。

画面サイズのイベントが発生したときに関数が呼び出されるように、以下の行のコメントを解除します。

```
    // This code makes the app call the method 'resizeGameWindow' if the user resizes the current window.
     window.addEventListener('resize', resizeGameWindow);
```

アプリをもう一度実行すると、ウィンドウのサイズを変更したときの結果が改善されます。

## <a name="publishing-to-the-microsoft-store"></a>Microsoft Store への公開

UWP アプリがある場合は、ここでは、(もう少し改善がまず!)、Microsoft Store に申請を公開することもできます。 

このプロセスにはいくつかの手順が必要になります。

1. Windows 開発者として[登録](https://developer.microsoft.com/en-us/store/register)する必要があります。
2. アプリの申請[チェックリスト](https://msdn.microsoft.com/windows/uwp/publish/app-submissions)を使用する必要があります。
3. [認定](https://msdn.microsoft.com/windows/uwp/publish/the-app-certification-process)を受けるために、アプリを提出する必要があります。

詳細については、 [UWP アプリの公開](https://developer.microsoft.com/en-us/store/publish-apps)を参照してください。

## <a name="suggestions-for-other-features"></a>その他のおすすめ機能

次にすること アプリの質を高めるために追加をお勧めする機能を以下に示します。

1. 音響効果。 CreateJS ライブラリには、[SoundJS](http://www.createjs.com/soundjs) というライブラリによるサウンドのサポートが含まれています。
2. ゲームパッドのサポート。 [利用できる API](https://gamedevelopment.tutsplus.com/tutorials/using-the-html5-gamepad-api-to-add-controller-support-to-browser-games--cms-21345) があります。
3. もっともっとすばらしいゲームにしてください。 この部分はあなた次第ですが、オンラインで利用可能なリソースも多数あります。 

## <a name="other-links"></a>その他のリンク

* [JavaScript で単純な Windows ゲームを作成する](https://www.sitepoint.com/creating-a-simple-windows-8-game-with-javascript-game-basics-createjseaseljs/)
* [HTML/JS ゲーム エンジンを選択する](https://html5gameengine.com/)
* [JS ベースのゲームに CreateJS を使用する](https://blogs.msdn.microsoft.com/cbowen/2012/09/19/using-createjs-in-your-javascript-based-windows-8-game/)
* [LinkedIn Learning のゲーム開発コース](https://www.linkedin.com/learning/topics/game-development)
