---
author: GrantMeStrength
ms.assetid: CFB3601D-3459-465F-80E2-520F57B88F62
title: Create a "Hello, world" app (JS)
description: "このチュートリアルでは、Windows 10 のユニバーサル Windows プラットフォーム (UWP) を対象にした単純な Hello, world アプリを JavaScript と HTML で作る方法について説明します。"
translationtype: Human Translation
ms.sourcegitcommit: 1a4aea3d31bad97fa0933e1274c037a4bb8d81bb
ms.openlocfilehash: ad34b1bc62abf6c93f5124e774ad374f5b767f2c

---
# <a name="create-a-hello-world-app-js"></a>Hello, world アプリを作成する (JS)

このチュートリアルでは、Windows 10 のユニバーサル Windows プラットフォーム (UWP) を対象にした単純な "Hello, world" アプリを JavaScript と HTML で作る方法について説明します。 Microsoft Visual Studio の 1 つのプロジェクトを使って、Windows 10 のすべてのデバイスで実行されるアプリを構築できます。

ここでは、次の方法について説明します。

-   **Windows 10** と **UWP** を対象とする新しい **Visual Studio 2015** プロジェクトを作る。
-   スタート ページに HTML コンテンツを追加する
-   タッチ、ペン、マウス入力を処理する
-   Visual Studio のローカル デスクトップと電話エミュレーターでプロジェクトを実行します。
-   JavaScript 用 Windows ライブラリのコントロールを使う

## <a name="before-you-start"></a>はじめに...

-   [ユニバーサル Windows アプリとは](whats-a-uwp.md)?
-   このチュートリアルを行うには、Windows 10 と Visual Studio 2015 が必要です。 [準備してください](get-set-up.md)。
-   また、Visual Studio の既定のウィンドウ レイアウトを使用することを前提としています。 既定のレイアウトを変更した場合は、**[ウィンドウ]** メニューの **[ウィンドウ レイアウトのリセット]** を使って、レイアウトをリセットできます。

## <a name="step-1-create-a-new-project-in-visual-studio"></a>手順 1: Visual Studio での新しいプロジェクトの作成

`HelloWorld` という名前の新しいアプリを作成しましょう。 以下にその方法を示します。
1.  Visual Studio 2015 を起動します。

2.  **[ファイル]** メニューの **[新しいプロジェクト]** を選び、*[新しいプロジェクト]* ダイアログを開きます。

3.  左側のテンプレートの一覧で、**[インストール済み]、[テンプレート]、[JavaScript]、[Windows]** の順に展開した後、**[ユニバーサル]** を選んで UWP プロジェクト テンプレートを表示します。 **[WinJS アプリ (ユニバーサル Windows)]** を選びます。

    ![[新しいプロジェクト] ウィンドウ ](images/winjs-tut-newproject.png)

    このチュートリアルでは、**[WinJS アプリ]** テンプレートを使います。 このテンプレートは、コンパイルして実行できる最小限の UWP アプリを作成しますが、ユーザー インターフェイス コントロールやデータは含まれていません。 コントロールとデータは、このチュートリアルの途中でアプリに追加します。

   これらのオプションが見つからない場合は、ユニバーサル Windows アプリ開発ツールがインストールされていることを確認します。 詳しくは、「[準備](get-set-up.md)」をご覧ください。

4.  **[名前]** ボックスに「HelloWorld」と入力します。
5.  **[OK]** をクリックしてプロジェクトを作ります。
6.  サポートする Windows の **[ターゲット バージョン]** と **[最小バージョン]** を選ぶように求められます。 既定の設定で問題ないため、**[OK]** をクリックします。

    Visual Studio によってプロジェクトが作られ、**ソリューション エクスプローラー**に表示されます。

    ![Visual Studio のソリューション エクスプローラーの HelloWorld プロジェクト](images/winjs-tut-helloworld.png)

**[WinJS アプリ]** は最小限のテンプレートですが、次の複数のファイルが含まれています。

-   アプリ (アプリの名前、説明、タイル、開始ページ、スプラッシュ画面など) を説明し、アプリに含まれるファイルを一覧表示するマニフェスト ファイル (package.appxmanifest)。
-   スタート メニューに表示するロゴ イメージ (images/Square150x150Logo.scale-200.png、images/Square44x44Logo.scale-200.png、images/Wide310x150Logo.scale-200.png) のセット。
-   Windows ストアに表示するアプリの画像 (images/StoreLogo.png)。
-   アプリが起動したときに表示するスプラッシュ画面 (images/SplashScreen.scale-200.png)。
-   スタート ページ (index.html) とそれに付随する、アプリの起動時に実行される JavaScript ファイル (main.js)。

これらのファイルを表示して編集するには、**ソリューション エクスプローラー**でファイルをダブルクリックします。

これらのファイルは、JavaScript を使うすべての UWP アプリに必要です。 Visual Studio で作るプロジェクトには、これらのファイルが必ず含まれます。

## <a name="step-2-launch-the-app"></a>手順 2: アプリの起動


ここまでの操作で、非常に単純なアプリが作成されました。 ここで、アプリをビルド、デプロイ、起動してどうなるかを見てみましょう。 アプリは、ローカル コンピューター、シミュレーターかエミュレーター、またはリモート デバイスでデバッグできます。 Visual Studio の [ターゲット デバイス] メニューを示します。

![アプリをデバッグするデバイス ターゲットのドロップダウン リスト](images/uap-debug.png)

### <a name="start-the-app-on-a-desktop-device"></a>デスクトップ デバイスでアプリを起動する

既定では、アプリはローカル コンピューターで実行されます。 [ターゲット デバイス] メニューには、デスクトップ デバイス ファミリのデバイスでアプリをデバッグするためのいくつかのオプションが用意されています。

-   **シミュレーター**
-   **ローカル コンピューター**
-   **リモート コンピューター**

**ローカル コンピューターでデバッグを開始するには**

1.  **[標準]** ツール バーの [ターゲット デバイス] メニュー (![[デバッグの開始] メニュー](images/startdebug-full.png)) で、**[ローカル コンピューター]** が選択されていることを確認します  (既定で選択されています)。
2.  ツール バーの **[デバッグの開始]** ボタン (![[デバッグの開始] ボタン](images/startdebug-sm.png)) をクリックします。

   または

   **[デバッグ]** メニューの **[デバッグの開始]** をクリックします。

   または

   F5 キーを押します。

アプリがウィンドウで開かれ、最初に既定のスプラッシュ画面が表示されます。 スプラッシュ画面は、画像 (SplashScreen.png) と背景色によって定義されます (背景色はアプリのマニフェスト ファイルに指定します)。

スプラッシュ画面が消えた後、アプリが表示されます。 黒い画面に "Content goes here" というテキストが表示されます。

![PC で動作する HelloWorld アプリ](images/helloworld-1-winjs.png)

Windows キーを押して **[スタート]** メニューを開き、すべてのアプリを表示します。 ローカルにデプロイしたアプリのタイルが **[スタート]** メニューに追加されています。 次にアプリを実行するときは (デバッグ モード以外で)、**[スタート]** メニューでこのタイルをタップまたはクリックします。

お疲れさまでした。これで、初めての UWP アプリの作成は完了です。

**デバッグを停止するには**

-   ツール バーの **[デバッグの停止]** ボタン (![[デバッグの停止] ボタン](images/stopdebug.png)) をクリックします。

   または

   **[デバッグ]** メニューの **[デバッグの停止]** をクリックします。

   または

   アプリ ウィンドウを閉じます。

### <a name="start-the-app-on-a-mobile-device-emulator"></a>モバイル デバイス エミュレーターでアプリを起動する

アプリは、すべての Windows 10 デバイスで実行できます。Windows Phone ではどのようになるかを見てみましょう。

Visual Studio では、デスクトップ デバイスでデバッグするオプションに加えて、コンピューターに接続された物理的なモバイル デバイスにアプリをデプロイしてデバッグするか、モバイル デバイス エミュレーターでアプリをデプロイしてデバッグするオプションが用意されています。 メモリとディスプレイの構成がさまざまなデバイスのエミュレーターの中から選ぶことができます。

-   **デバイス**
-   **Emulator <SDK version> WVGA 4 inch 512MB**
-   **Emulator <SDK version> WVGA 4 inch 1GB**
-   その他... (他の構成のさまざまなエミュレーター)

エミュレーターが見つからない場合は、ユニバーサル Windows アプリ開発ツールがインストールされていることを確認します。 詳しくは、「[準備](get-set-up.md)」をご覧ください。

画面が小さくメモリが限られているデバイスでアプリをテストすることをお勧めします。そのためには、**[Emulator 10.0.14393.0 WVGA 4 inch 512MB]** オプションを使用します。

**モバイル デバイス エミュレーターでデバッグを開始するには**

1.  **[標準]** ツール バーの [ターゲット デバイス] メニュー (![[デバッグの開始] メニュー](images/startdebug-full.png)) で、**[Emulator 10.0.14393.0 WVGA 4 inch 512MB]** を選びます。
2.  ツール バーの **[デバッグの開始]** ボタン (![[デバッグの開始] ボタン](images/startdebug-sm.png)) をクリックします。

   または

   **[デバッグ]** メニューの **[デバッグの開始]** をクリックします。


Visual Studio で、選択したエミュレーターが起動し、アプリが展開されて起動されます。 初回起動時は、エミュレーターの起動に少しの時間がかかる可能性があります。 Hyper-V に関するエラーが表示される場合があります。これを解決するには、**[再試行]** をクリックします。 モバイル デバイス エミュレーターでは、アプリは次のように表示されます。

![モバイル デバイスでのアプリの初期画面](images/helloworld-1-winjs-phone.png)

## <a name="step-3-modify-your-start-page"></a>手順 3: スタート ページの変更

Visual Studio によって作成されるファイルの中に **index.html** があります。これはアプリのスタート ページです。 アプリが実行されると、スタート ページのコンテンツが表示されます。 スタート ページには、アプリのコード ファイルとスタイル シートへの参照も含まれます。 Visual Studio によって作成されるスタート ページを次に示します。

```html
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title>HelloWorld</title>

    <!-- WinJS references -->
    <link href="lib/winjs-4.0.1/css/ui-light.css" rel="stylesheet" />
    <script src="lib/winjs-4.0.1/js/base.js"></script>
    <script src="lib/winjs-4.0.1/js/ui.js"></script>

    <!-- HelloWorld references -->
    <link href="/css/default.css" rel="stylesheet" />
    <script src="/js/main.js"></script>
</head>
<body class="win-type-body">
    <div>Content goes here!</div>
</body>
</html>
```

この default.html ファイルに、新しいコンテンツを追加しましょう。 他の HTML ファイルでの追加と同じように、[body](https://msdn.microsoft.com/library/windows/apps/Hh453011) 要素の中にコンテンツを追加します。 HTML5 要素を使ってアプリを作成できます ([いくつか例外があります](https://msdn.microsoft.com/library/windows/apps/Hh465380))。 つまり、[h1](https://msdn.microsoft.com/library/windows/apps/Hh441078)、[p](https://msdn.microsoft.com/library/windows/apps/Hh453431), [button](https://msdn.microsoft.com/library/windows/apps/Hh453017)、[div](https://msdn.microsoft.com/library/windows/apps/Hh453133)、[img](https://msdn.microsoft.com/library/windows/apps/Hh466114) などの HTML5 要素を使うことができます。

**スタート ページの編集**

1.  第 1 レベルの見出しが "Hello, world!" である **body** 要素の既存のコンテンツを、ユーザーの名前をたずねるテキスト、ユーザーの名前を受け取る **input** 要素、**button** 要素、**div** 要素に置き換えます。 **input**、**button**、**div** に ID を割り当てます。

 ```html
    <body class="win-type-body">
        <h1>Hello, world!</h1>
        <p>What's your name?</p>
        <input id="nameInput" type="text" />
        <button id="helloButton">Say "Hello"</button>
        <div id="greetingOutput"></div>
    </body>
 ```

2.  ローカル コンピューターでアプリを実行します。 次のようになります。

![新しい内容の HelloWorld アプリ](images/helloworld-2-winjs.png)

   **input** 要素に入力できますが、この時点では **button** をクリックしても何も起こりません。 **button** などの一部のオブジェクトは、特定のイベントが発生したときにメッセージを送信できます。 これらのイベント メッセージにより、イベントに応答してアクションを実行できます。 イベントに応答するためのコードをイベント ハンドラー メソッドに配置します。

   次の手順で、ユーザーに合わせたあいさつを表示する **button** 用のイベント ハンドラーを作成します。 イベント ハンドラーのコードを main.js ファイルに追加します。

## <a name="step-4-create-an-event-handler"></a>手順 4: イベント ハンドラーの作成

新しいプロジェクトを作成したときに、/js/main.js というファイルが自動的に作成されました。 このファイルには、アプリのライフサイクルを処理するコードが含まれています。 このファイルは、index.html ファイルにインタラクティビティを追加するコードを記述する場所でもあります。

main.js ファイルを開きます。

独自のコードを追加する前に、ファイル内のコードの最初と最後の数行を見てみましょう。

```javascript
(function () {
    "use strict";

     // Omitted code

 })();
```

ここで何が行われているかについて説明します。 これらの行は、main.js コードの残りの行を自己実行型の匿名関数でラップしています。 自己実行型の匿名関数により、名前の競合や値の間違った変更を簡単に避けられます。 また、必要のない識別子をグローバル名前空間から排除できるため、パフォーマンスが向上します。 奇妙に思えるかもしれませんが、これは適切なプログラミング方法です。

次のコード行は、JavaScript コードに対して [strict モード](https://msdn.microsoft.com/library/windows/apps/br230269.aspx)を有効にします。 strict モードにより、コードのエラー チェック機能が強化されます。 たとえば、暗黙的に宣言された変数の使用や、読み取り専用プロパティへの値の割り当てを回避します。

main.js の残りのコードを見てください。 これは、アプリの [activated](https://msdn.microsoft.com/library/windows/apps/BR212679) イベントと [checkpoint](https://msdn.microsoft.com/library/windows/apps/BR229839) イベントを処理します。 これらのイベントについては、後で詳しく説明します。 ここでは、アプリが起動すると **activated** イベントが発生することだけを覚えておいてください。

```javascript
   (function () {
    "use strict";

    var app = WinJS.Application;
    var activation = Windows.ApplicationModel.Activation;
    var isFirstActivation = true;

    app.onactivated = function (args) {
          if (args.detail.kind === activation.ActivationKind.voiceCommand) {
            // TODO: Handle relevant ActivationKinds. For example, if your app can be started by voice commands,
            // this is a good place to decide whether to populate an input field or choose a different initial view.
        }
          else if (args.detail.kind === activation.ActivationKind.launch) {
            // A Launch activation happens when the user launches your app via the tile
            // or invokes a toast notification by clicking or tapping on the body.
              if (args.detail.arguments) {
                // TODO: If the app supports toasts, use this value from the toast payload to determine where in the app
                // to take the user in response to them invoking a toast notification.
              }
              else if (args.detail.previousExecutionState === activation.ApplicationExecutionState.terminated) {
                // TODO: This application had been suspended and was then terminated to reclaim memory.
                // To create a smooth user experience, restore application state here so that it looks like the app never stopped running.
                // Note: You may want to record the time when the app was last suspended and only restore state if they've returned after a short period.
            }
        }

        if (!args.detail.prelaunchActivated) {
            // TODO: If prelaunchActivated were true, it would mean the app was prelaunched in the background as an optimization.
            // In that case it would be suspended shortly thereafter.
            // Any long-running operations (like expensive network or disk I/O) or changes to user state which occur at launch
            // should be done here (to avoid doing them in the prelaunch case).
            // Alternatively, this work can be done in a resume or visibilitychanged handler.
        }

        if (isFirstActivation) {
            // TODO: The app was activated and had not been running. Do general startup initialization here.
            document.addEventListener("visibilitychange", onVisibilityChanged);
            args.setPromise(WinJS.UI.processAll());
        }

        isFirstActivation = false;
    };
```

それでは、[button](https://msdn.microsoft.com/library/windows/apps/Hh453017) 用のイベント ハンドラーを定義しましょう。 新しいイベント ハンドラーは、`nameInput` [input](https://msdn.microsoft.com/library/windows/apps/Hh453271) コントロールからユーザーの名前を取得し、それを使って前のセクションで作成した `greetingOutput` **div** 要素にあいさつを出力します。

### <a name="using-events-that-work-for-touch-mouse-and-pen-input"></a>タッチ、マウス、ペン入力で動作するイベントの使用

UWP アプリでは、入力方法 (タッチ、マウス、その他の形式のポインター入力) の違いを気にする必要はありません。 [click](https://msdn.microsoft.com/library/windows/apps/Hh441312) などのイベントを使うだけで、あらゆる形式の入力に対応できます。

**ヒント:** アプリでは、新しい *MSPointer\** イベントと *MSGesture\** イベントも使用できます。これらはタッチ、マウス、ペン入力に対応し、イベントを発生させたデバイスについての情報も提供できます。 詳しくは、「[ユーザー操作への応答](https://msdn.microsoft.com/library/windows/apps/Hh700412)」と「[ジェスチャ、操作、対話的操作](https://msdn.microsoft.com/library/windows/apps/Hh761498)」をご覧ください。

それでは、イベント ハンドラーを作成してみましょう。

**イベント ハンドラーの作成**

1.  main.js で、[**app.oncheckpoint**](https://msdn.microsoft.com/library/windows/apps/BR229839) イベント ハンドラーの後、[**app.start**](https://msdn.microsoft.com/library/windows/apps/BR229705) の呼び出しの前に、`eventInfo` という名前の 1 つのパラメーターを受け取る `buttonClickHandler` という名前の [**click**](https://msdn.microsoft.com/library/windows/apps/Hh441312) イベント ハンドラー関数を作成します。
```javascript
    function buttonClickHandler(eventInfo) {

        }
```

2.  作成したイベント ハンドラーの中で、`nameInput`[**input**](https://msdn.microsoft.com/library/windows/apps/Hh453271) コントロールからユーザー名を取得し、それを使ってあいさつを作ります。 結果を表示するには、`greetingOutput` [**div**](https://msdn.microsoft.com/library/windows/apps/Hh453133) を使います。
```javascript
    function buttonClickHandler(eventInfo) {
            var userName = document.getElementById("nameInput").value;
            var greetingString = "Hello, " + userName + "!";
            document.getElementById("greetingOutput").innerText = greetingString;
        }
 ```

これで、イベント ハンドラーが main.js に追加されました。 次に、そのハンドラーを登録する必要があります。

## <a name="step-5-register-the-event-handler-when-your-app-launches"></a>手順 5: アプリ起動時のイベント ハンドラーの登録


ここで行う必要があるのは、ボタンにイベント ハンドラーを登録する作業だけです。 イベント ハンドラーを登録する際に推奨される方法は、コードから [addEventListener](https://msdn.microsoft.com/library/windows/apps/Hh441145) を呼び出す方法です。 イベント ハンドラーを登録するのに最適なタイミングは、アプリがアクティブ化される時点です。 さいわい、これまで見たように、アプリのアクティブ化を処理するコードが main.js ファイル内に自動的に生成されています。


[onactivated](https://msdn.microsoft.com/library/windows/apps/BR212679) ハンドラーのコードでは、発生したアクティブ化の種類を確認します。 アクティブ化にはさまざまな種類があります。 たとえば、ユーザーがアプリを起動したときと、ユーザーがアプリに関連付けられているファイルを開くときに、アプリはアクティブ化されます  (詳しくは、「[アプリのライフサイクル](https://msdn.microsoft.com/library/windows/apps/Mt243287)」をご覧ください)。

ここでは、[launch](https://msdn.microsoft.com/library/windows/apps/BR224693) アクティブ化に注目します。 アプリは、実行されていないときにユーザーがアクティブ化すると*起動*します。 [WinJS.UI.processAll](https://msdn.microsoft.com/library/windows/apps/Hh440975) は、アプリが前回シャットダウンされているか、または今回が初めての起動であるかどうかにかかわらず、呼び出されます。 **WinJS.UI.processAll** を [setPromise](https://msdn.microsoft.com/library/windows/apps/JJ215609) メソッドの呼び出しで囲むことで、アプリのページが準備できるまで、スプラッシュ画面が消えないようにします。

**ヒント:** **WinJS.UI.processAll** 関数は、default.html ファイルをスキャンして WinJS コントロールを探し、それらを初期化します。 これらのコントロールはまだ追加しませんが、後で追加する場合に備えて、このコードを削除しないでおくことをお勧めします。

WinJS 以外のコントロール用のイベント ハンドラーは、**WinJS.UI.processAll** を呼び出した直後に登録します。

**イベント ハンドラーの登録**

-   main.js の [**onactivated**](https://msdn.microsoft.com/library/windows/apps/BR212679) イベント ハンドラーで、`helloButton` を取得し、[**addEventListener**](https://msdn.microsoft.com/library/windows/apps/Hh441145) を使って、[**click**](https://msdn.microsoft.com/library/windows/apps/Hh441312) イベント用のイベント ハンドラーを登録します。 [**WinJS.UI.processAll**](https://msdn.microsoft.com/library/windows/apps/Hh440975) の呼び出しの後に、次のコードを追加します。

```javascript
   app.onactivated = function (args) {
           // Omitted code
           if (isFirstActivation) {
              document.addEventListener("visibilitychange", onVisibilityChanged);
              args.setPromise(WinJS.UI.processAll());

              // Add your code to retrieve the button and register the event handler.
              var helloButton = document.getElementById("helloButton");
              helloButton.addEventListener("click", buttonClickHandler, false);
            }

```    



アプリを実行します。 テキスト ボックスに名前を入力してボタンをクリックすると、ユーザーに合わせたあいさつが表示されます。

**注:** HTML に [onclick](https://msdn.microsoft.com/library/windows/apps/Hh441312) イベントを設定するのではなく [addEventListener](https://msdn.microsoft.com/library/windows/apps/Hh441145) を使ってコード内のイベントを登録する理由を理解するには、「[基本的なアプリのコーディング](https://msdn.microsoft.com/library/windows/apps/Hh780660)」の詳しい説明をご覧ください。

## <a name="step-6-add-a-windows-library-for-javascript-control"></a>手順 6: JavaScript 用 Windows ライブラリ コントロールの追加


アプリでは、標準の HTML コントロール以外にも、[WinJS.UI.DatePicker](https://msdn.microsoft.com/library/windows/apps/BR211681)、[WinJS.UI.FlipView](https://msdn.microsoft.com/library/windows/apps/BR211711)、[WinjS.UI.ListView](https://msdn.microsoft.com/library/windows/apps/BR211837)、[WinJS.UI.Rating](https://msdn.microsoft.com/library/windows/apps/BR211895) コントロールなど、[JavaScript 用 Windows ライブラリ](https://msdn.microsoft.com/library/windows/apps/BR229782)のいずれのコントロールも使うことができます。

HTML コントロールには専用のマークアップ要素がありますが、WinJS コントロールにはありません。たとえば、`<rating />` 要素を追加しても、[Rating](https://msdn.microsoft.com/library/windows/apps/BR211895) コントロールを作成することはできません。 WinJS コントロールを追加するには、**div** 要素を作成し、[data-win-control](https://msdn.microsoft.com/library/windows/apps/Hh440969) 属性を使ってコントロールの種類を指定します。 **Rating** コントロールを追加するには、この属性を "WinJS.UI.Rating" に設定します。

**アプリに Rating コントロールを追加します。**

1.  index.html ファイルで、`greetingOutput` **div** の後ろに [label](https://msdn.microsoft.com/library/windows/apps/Hh453321) コントロールと [Rating](https://msdn.microsoft.com/library/windows/apps/BR211895) コントロールを追加します。

```html
    <body class="win-type-body">
        <h1>Hello, world!</h1>
        <p>What's your name?</p>
        <input id="nameInput" type="text" />
        <button id="helloButton">Say "Hello"</button>
        <div id="greetingOutput"></div>
        <label for="ratingControlDiv">
            Rate this greeting:
        </label>
        <div id="ratingControlDiv" data-win-control="WinJS.UI.Rating">
        </div>
    </body>
```

2.  ローカル コンピューターでアプリを実行します。 新しい [**Rating**](https://msdn.microsoft.com/library/windows/apps/BR211895) コントロールに注目してください。

   ![JavaScript 用 Windows ライブラリのコントロールを使った "Hello, world" アプリ](images/helloworld-4-winjs.png)

> **Rating** を読み込むには、ページで [WinJS.UI.processAll](https://msdn.microsoft.com/library/windows/apps/Hh440975) を呼び出す必要があります。 このアプリでは、Visual Studio テンプレートの 1 つを使っているため、先ほど説明したように、main.js には **WinJS.UI.processAll** の呼び出しが既に含まれています。そのため、コードを追加する必要はありません。

ここで **Rating** コントロールをクリックすると評価が変化しますが、それ以外は何も起こりません。 イベント ハンドラーを使って、ユーザーが評価を変更したときに何か処理を行うようにしましょう。

## <a name="step-7-register-an-event-handler-for-a-windows-library-for-javascript-control"></a>手順 7: Windows ライブラリの JavaScript 用コントロールのイベント ハンドラーの登録


WinJS コントロールのイベント ハンドラーを登録する方法は、標準の HTML コントロールのイベント ハンドラーを登録する方法と少し異なります。 前に説明したように、**onactivated** イベント ハンドラーでは、**WinJS.UI.processAll** メソッドを呼び出して、マークアップ内で WinJS を初期化します。 **WinJS.UI.processAll** 呼び出しが、次のように **setPromise** メソッドの呼び出しの中にカプセル化されます。

```javascript
            args.setPromise(WinJS.UI.processAll());           
```

**Rating** が標準の HTML コントロールであれば、この **WinJS.UI.processAll** の呼び出しの後にイベント ハンドラーを追加できます。 しかし、**Rating** などの WinJS コントロールの場合は、もう少し複雑です。 **WinJS.UI.processAll** によって **Rating** コントロールが作成されるため、**WinJS.UI.processAll** の処理が終わるまで、**Rating** にイベント ハンドラーを追加できません。

**WinJS.UI.processAll** が通常のメソッドであれば、呼び出した直後に **Rating** イベント ハンドラーを登録できます。 しかし、**WinJS.UI.processAll** メソッドは非同期メソッドです。そのため、**WinJS.UI.processAll** が完了する前に次のコードが実行されることもあります。 どうしたらよいでしょうか。 [Promise](https://msdn.microsoft.com/library/windows/apps/BR211867) オブジェクトを使って、**WinJS.UI.processAll** が完了したときに通知を受け取るようにします。

すべての非同期 WinJS メソッドと同じように、**WinJS.UI.processAll** は **Promise** オブジェクトを返します。 **Promise** は、後で何かが起こるという "約束" (promise) です。その何かが起こった場合、**Promise** が完了したと言います。

[Promise](https://msdn.microsoft.com/library/windows/apps/BR211867) オブジェクトには、パラメーターとして "completed" 関数を受け取る [then](https://msdn.microsoft.com/library/windows/apps/BR229728) メソッドがあります。 **Promise** が完了すると、この関数が呼び出されます。

"completed" 関数にコードを追加し、それを **Promise** オブジェクトの **then** メソッドに渡すと、**WinJS.UI.processAll** の完了後に、そのコードを確実に実行できます。

**ユーザーが選んだ評価値の出力**

1.  main.html ファイルで、評価値を表示する [**div**](https://msdn.microsoft.com/library/windows/apps/Hh453133) 要素を作成し、それに "ratingOutput" という **ID** を付けます。

```html
        <body class="win-type-body">
        <h1>Hello, world!</h1>
        <p>What's your name?</p>
        <input id="nameInput" type="text" />
        <button id="helloButton">Say "Hello"</button>
        <div id="greetingOutput"></div>
        <label for="ratingControlDiv">
            Rate this greeting:
        </label>
        <div id="ratingControlDiv" data-win-control="WinJS.UI.Rating">
        </div>
        <div id="ratingOutput"></div>
    </body>
```

2.  main.js ファイルで、**Rating** コントロールの [change](https://msdn.microsoft.com/library/windows/apps/BR211891) イベントのイベント ハンドラーを作成します。このイベント ハンドラーには、`ratingChanged` という名前を付けます。 [eventInfo](https://msdn.microsoft.com/library/windows/apps/Hh465776) パラメーターには、新しいユーザー評価を示す **detail.tentativeRating** プロパティが含まれています。 この値を取得し、出力 **div** で表示します。

```javascript
        function ratingChanged(eventInfo) {

            var ratingOutput = document.getElementById("ratingOutput");
            ratingOutput.innerText = eventInfo.detail.tentativeRating;
        }
```

3.  [WinJS.UI.processAll](https://msdn.microsoft.com/library/windows/apps/Hh440975) を呼び出す [onactivated](https://msdn.microsoft.com/library/windows/apps/BR212679) イベント ハンドラーのコードを更新して、[then](https://msdn.microsoft.com/library/windows/apps/BR229728) メソッドの呼び出しを追加し、それに `completed` 関数を渡すようにします。 `completed` 関数では、[Rating](https://msdn.microsoft.com/library/windows/apps/BR211895) コントロールをホストする `ratingControlDiv` 要素を取得します。 次に、[winControl](https://msdn.microsoft.com/library/windows/apps/Hh770814) プロパティを使って、実際の **Rating** コントロールを取得します  (この例では、`completed` 関数がインラインで定義されます)。

```javascript
           args.setPromise(WinJS.UI.processAll().then(function completed() {

                    // Retrieve the div that hosts the Rating control.
                    var ratingControlDiv = document.getElementById("ratingControlDiv");

                    // Retrieve the actual Rating control.
                    var ratingControl = ratingControlDiv.winControl;

                    // Register the event handler.
                    ratingControl.addEventListener("change", ratingChanged, false);

                }));
```

4.  [**WinJS.UI.processAll**](https://msdn.microsoft.com/library/windows/apps/Hh440975) を呼び出した後に、HTML コントロールのイベント ハンドラーを登録できる場合は、それらを `completed` 関数内でも登録できます。 作業を簡単にするために、すべてのイベント ハンドラーの登録を [**then**](https://msdn.microsoft.com/library/windows/apps/BR229728) イベント ハンドラー内に移動しましょう。

    更新後の [**onactivated**](https://msdn.microsoft.com/library/windows/apps/BR212679) イベント ハンドラーは次のようになります。

```javascript
    (function () {
    "use strict";

    var app = WinJS.Application;
    var activation = Windows.ApplicationModel.Activation;
    var isFirstActivation = true;

    app.onactivated = function (args) {
        if (args.detail.kind === activation.ActivationKind.voiceCommand) {
            // TODO: Handle relevant ActivationKinds. For example, if your app can be started by voice commands,
            // this is a good place to decide whether to populate an input field or choose a different initial view.
        }
        else if (args.detail.kind === activation.ActivationKind.launch) {
            // A Launch activation happens when the user launches your app via the tile
            // or invokes a toast notification by clicking or tapping on the body.
            if (args.detail.arguments) {
                // TODO: If the app supports toasts, use this value from the toast payload to determine where in the app
                // to take the user in response to them invoking a toast notification.
            }
            else if (args.detail.previousExecutionState === activation.ApplicationExecutionState.terminated) {
                // TODO: This application had been suspended and was then terminated to reclaim memory.
                // To create a smooth user experience, restore application state here so that it looks like the app never stopped running.
                // Note: You may want to record the time when the app was last suspended and only restore state if they've returned after a short period.
            }
        }

        if (!args.detail.prelaunchActivated) {
            // TODO: If prelaunchActivated were true, it would mean the app was prelaunched in the background as an optimization.
            // In that case it would be suspended shortly thereafter.
            // Any long-running operations (like expensive network or disk I/O) or changes to user state which occur at launch
            // should be done here (to avoid doing them in the prelaunch case).
            // Alternatively, this work can be done in a resume or visibilitychanged handler.
        }

        if (isFirstActivation) {
            // TODO: The app was activated and had not been running. Do general startup initialization here.
            document.addEventListener("visibilitychange", onVisibilityChanged);

            args.setPromise(WinJS.UI.processAll().then(function completed() {
                var ratingControlDiv = document.getElementById("ratingControlDiv");
                var ratingControl = ratingControlDiv.winControl;
                ratingControl.addEventListener("change",ratingChanged, false);
            }));

            var helloButton = document.getElementById("helloButton");
            helloButton.addEventListener("click", buttonClickHandler, false);

        }

        isFirstActivation = false;
    };

```        

    Run the app. When you select a rating value, it outputs the numeric value below the [**Rating**](https://msdn.microsoft.com/library/windows/apps/BR211895) control.

![PC で動作する完成した Hello World アプリ](images/helloworld-5-winjs.png)

## <a name="summary"></a>概要

これで、JavaScript と HTML を使って Windows 10 と UWP 用の初めてのアプリを作成しました。

次の手順 [WinJS](https://developer.microsoft.com/en-us/windows/develop/winjs) ドキュメントは、JavaScript 用 Windows ライブラリの利用に役立ちます。



<!--HONumber=Dec16_HO1-->


