---
author: martinekuan
ms.assetid: CFB3601D-3459-465F-80E2-520F57B88F62
title: "Hello, world アプリを作成する (JS)"
description: "このチュートリアルでは、Windows 10 のユニバーサル Windows プラットフォーム (UWP) を対象にした単純な Hello, world アプリを JavaScript と HTML で作る方法について説明します。"
translationtype: Human Translation
ms.sourcegitcommit: 3de603aec1dd4d4e716acbbb3daa52a306dfa403
ms.openlocfilehash: be731072824e81eadc95cebd5855234f9331962b

---
# Hello, world アプリを作成する (JS)

このチュートリアルでは、Windows 10 のユニバーサル Windows プラットフォーム (UWP) を対象にした単純な "Hello, world" アプリを JavaScript と HTML で作る方法について説明します。 Microsoft Visual Studio の 1 つのプロジェクトを使って、Windows 10 のすべてのデバイスで実行されるアプリを構築できます。 ここでは、デスクトップとモバイル デバイスで同じように適切に実行されるアプリを作ることに焦点を合わせます。


              **重要:** このチュートリアルは、Microsoft Visual Studio 2015 と Windows 10 で使うためのものです。 それ以前のバージョンでは正しく動作しません。

ここでは、次の方法について説明します。

-   新しいプロジェクトを作る
-   スタート ページに HTML コンテンツを追加する
-   タッチ、ペン、マウス入力を処理する
-   Visual Studio のローカル デスクトップと電話エミュレーターでプロジェクトを実行する
-   カスタム スタイルを作成する
-   JavaScript 用 Windows ライブラリのコントロールを使う

##はじめに...


-   このチュートリアルでは、簡単なユニバーサル アプリを作る手順だけを説明します。 そのため、このチュートリアルを始める前に、「[Windows 10 の開発者向け最新情報](https://dev.windows.com/whats-new-windows-10-dev-preview)」と「[ユニバーサル Windows アプリとは?](whats-a-uwp.md)」で概要について読み、理解しておくことを強くお勧めします。
-   このチュートリアルを行うには、Windows 10 と Visual Studio 2015 が必要です。 詳しくは、「[準備](get-set-up.md)」をご覧ください。
-   また、Visual Studio の既定のウィンドウ レイアウトを使うことを前提としています。 既定のレイアウトを変更した場合は、**[ウィンドウ]** メニューの **[ウィンドウ レイアウトのリセット]** を使って、レイアウトをリセットできます。

##手順 1: Visual Studio での新しいプロジェクトの作成


`HelloWorld` という名前の新しいアプリを作成しましょう。 手順は次のとおりです。

1.  Visual Studio 2015 を起動します。

    Visual Studio 2015 のスタート画面が表示されます。

    (以下、Visual Studio 2015 を単に Visual Studio と表記します。)

2.  **[ファイル]** メニューの **[新規作成]** > **[プロジェクト]** の順にクリックします。

    **[新しいプロジェクト]** ダイアログ ボックスが表示されます。 ダイアログの左側のウィンドウで、表示するテンプレートの種類を選択できます。

3.  左側のウィンドウで、**[インストール済み]、[テンプレート]、[JavaScript]、[Windows]** の順に展開した後、**[ユニバーサル]** テンプレート グループを選びます。 ユニバーサル Windows プラットフォーム (UWP) アプリで使うことができるプロジェクト テンプレートの一覧がダイアログの中央のウィンドウに表示されます。

    ![[新しいプロジェクト] ウィンドウ ](images/js-tut-newproject.png)

    このチュートリアルでは、**[空白のアプリ]** テンプレートを使います。 このテンプレートは、コンパイルして実行できる最小限の UWP アプリを作成しますが、ユーザー インターフェイス コントロールやデータは含まれていません。 コントロールとデータは、このチュートリアルの途中でアプリに追加します。

   これらのオプションが見つからない場合は、ユニバーサル Windows アプリ開発ツールがインストールされていることを確認します。 詳しくは、「[準備](get-set-up.md)」をご覧ください。

4.  中央のウィンドウで、**[空白のアプリ (ユニバーサル Windows)]** プロジェクト テンプレートを選びます。

    **[空白のアプリ]** テンプレートは、コンパイルして実行できる最小限の UWP アプリを作成しますが、ユーザー インターフェイス コントロールやデータは含まれていません。 コントロールは、このチュートリアルの途中でアプリに追加します。

5.  **[名前]** ボックスに「HelloWorld」と入力します。
6.  **[OK]** をクリックしてプロジェクトを作ります。

    Visual Studio によってプロジェクトが作られ、**ソリューション エクスプローラー**に表示されます。

    ![Visual Studio のソリューション エクスプローラーの HelloWorld プロジェクト](images/js-tut-helloworld.png)

**[空白のアプリ]** は最小限のテンプレートですが、次の複数のファイルが含まれています。

-   アプリ (アプリの名前、説明、タイル、開始ページ、スプラッシュ画面など) を説明し、アプリに含まれるファイルを一覧表示するマニフェスト ファイル (package.appxmanifest)。
-   スタート メニューに表示するロゴ イメージ (images/Square150x150Logo.scale-200.png、images/Square44x44Logo.scale-200.png、images/Wide310x150Logo.scale-200.png) のセット。
-   Windows ストアに表示するアプリの画像 (images/StoreLogo.png)。
-   アプリが起動したときに表示するスプラッシュ画面 (images/SplashScreen.scale-200.png)。
-   スタート ページ (default.html) とそれに付随する、アプリの起動時に実行される JavaScript ファイル (default.js)。

これらのファイルを表示して編集するには、**ソリューション エクスプローラー**でファイルをダブルクリックします。

これらのファイルは、JavaScript を使うすべての UWP アプリに必要です。 Visual Studio で作るプロジェクトには、これらのファイルが必ず含まれます。

##手順 2: アプリの起動


ここまでの操作で、非常に単純なアプリが作成されました。 ここで、アプリをビルド、デプロイ、起動してどうなるかを見てみましょう。 アプリは、ローカル コンピューター、シミュレーターかエミュレーター、またはリモート デバイスでデバッグできます。 Visual Studio の [ターゲット デバイス] メニューを示します。

![アプリをデバッグするデバイス ターゲットのドロップダウン リスト](images/uap-debug.png)

### デスクトップ デバイスでアプリを起動する

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

![PC で動作する HelloWorld アプリ](images/helloworld-1-js.png)

Windows キーを押して **[スタート]** メニューを開き、すべてのアプリを表示します。 ローカルにデプロイしたアプリのタイルが **[スタート]** メニューに追加されています。 次にアプリを実行するときは (デバッグ モード以外で)、**[スタート]** メニューでこのタイルをタップまたはクリックします。

お疲れさまでした。これで、初めての UWP アプリの作成は完了です。

**デバッグを停止するには**

-   ツール バーの **[デバッグの停止]** ボタン (![[デバッグの停止] ボタン](images/stopdebug.png)) をクリックします。

   または

   **[デバッグ]** メニューの **[デバッグの停止]** をクリックします。

   または

   アプリ ウィンドウを閉じます。

### モバイル デバイス エミュレーターでアプリを起動する

アプリは、すべての Windows 10 デバイスで実行できます。Windows Phone ではどのようになるかを見てみましょう。

Visual Studio では、デスクトップ デバイスでデバッグするオプションに加えて、コンピューターに接続された物理的なモバイル デバイスにアプリをデプロイしてデバッグするか、モバイル デバイス エミュレーターでアプリをデプロイしてデバッグするオプションが用意されています。 メモリとディスプレイの構成がさまざまなデバイスのエミュレーターの中から選ぶことができます。

-   **デバイス**
-   **Emulator <SDK version> WVGA 4 inch 512MB**
-   **Emulator <SDK version> WVGA 4 inch 1GB**
-   その他... (他の構成のさまざまなエミュレーター)

エミュレーターが見つからない場合は、ユニバーサル Windows アプリ開発ツールがインストールされていることを確認します。 詳しくは、「[準備](get-set-up.md)」をご覧ください。

画面が小さくメモリが限られているデバイスでアプリをテストすることをお勧めします。そのためには、**[Emulator 10.0.10240.0 WVGA 4 inch 512MB]** オプションを使用します。
**モバイル デバイス エミュレーターでデバッグを開始するには**

1.  **[標準]** ツール バーの [ターゲット デバイス] メニュー (![[デバッグの開始] メニュー](images/startdebug-full.png)) で、**[Emulator 10.0.10240.0 WVGA 4 inch 512MB]** を選びます。
2.  ツール バーの **[デバッグの開始]** ボタン (![[デバッグの開始] ボタン](images/startdebug-sm.png)) をクリックします。

   または

   **[デバッグ]** メニューの **[デバッグの開始]** をクリックします。

   
Visual Studio で、選択したエミュレーターが起動し、アプリが展開されて起動されます。 モバイル デバイス エミュレーターでは、アプリは次のように表示されます。

![モバイル デバイスでのアプリの初期画面](images/helloworld-1-js-phone.png)

## 手順 3: スタート ページの変更

Visual Studio によって作成されるファイルの中に default.html があります。これはアプリのスタート ページです。 アプリが実行されると、スタート ページのコンテンツが表示されます。 スタート ページには、アプリのコード ファイルとスタイル シートへの参照も含まれます。 Visual Studio によって作成されるスタート ページを次に示します。

```html
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title>HelloWorld</title>

    <!-- WinJS references -->
    <link href="WinJS/css/ui-dark.css" rel="stylesheet" />
    <script src="WinJS/js/base.js"></script>
    <script src="WinJS/js/ui.js"></script>

    <!-- HelloWorld references -->
    <link href="/css/default.css" rel="stylesheet" />
    <script src="/js/default.js"></script>
</head>
<body class="win-type-body">
    <p>Content goes here</p>
</body>
</html>
```

この default.html ファイルに、新しいコンテンツを追加しましょう。 他の HTML ファイルでの追加と同じように、[**body**](https://msdn.microsoft.com/library/windows/apps/Hh453011) 要素の中にコンテンツを追加します。 HTML5 要素を使ってアプリを作成できます ([いくつか例外があります](https://msdn.microsoft.com/library/windows/apps/Hh465380))。 つまり、[**h1**](https://msdn.microsoft.com/library/windows/apps/Hh441078)、[**p**](https://msdn.microsoft.com/library/windows/apps/Hh453431)、[**button**](https://msdn.microsoft.com/library/windows/apps/Hh453017)、[**div**](https://msdn.microsoft.com/library/windows/apps/Hh453133)、[**img**](https://msdn.microsoft.com/library/windows/apps/Hh466114) などの HTML5 要素を使うことができます。

**スタート ページを変更するには**

1.  第 1 レベルの見出しが "Hello, world!" である [**body**](https://msdn.microsoft.com/library/windows/apps/Hh453011) 要素の既存のコンテンツを、ユーザーの名前をたずねるテキスト、ユーザーの名前を受け取る [**input**](https://msdn.microsoft.com/library/windows/apps/Hh453271) 要素、[**button**](https://msdn.microsoft.com/library/windows/apps/Hh453017) 要素、[**div**](https://msdn.microsoft.com/library/windows/apps/Hh453133) 要素に置き換えます。 **input**、**button**、**div** に ID を割り当てます。

 ```html
    <body class="win-type-body">
        <h1>Hello, world!</h1>
        <p>What' s your name?</p>
        <input id="nameInput" type="text" />
        <button id="helloButton">Say "Hello"</button>
        <div id="greetingOutput"></div>
    </body>
 ```

2.  ローカル コンピューターでアプリを実行します。 次のようになります。

![新しい内容の HelloWorld アプリ](images/helloworld-2-js.png)

   [**input**](https://msdn.microsoft.com/library/windows/apps/Hh453271) 要素に入力できますが、この時点では [**button**](https://msdn.microsoft.com/library/windows/apps/Hh453017) をクリックしても何も起こりません。 **button** などの一部のオブジェクトは、特定のイベントが発生したときにメッセージを送信できます。 これらのイベント メッセージにより、イベントに応答してアクションを実行できます。 イベントに応答するためのコードをイベント ハンドラー メソッドに配置します。

   次の手順で、ユーザーに合わせたあいさつを表示する [**button**](https://msdn.microsoft.com/library/windows/apps/Hh453017) 用のイベント ハンドラーを作成します。 イベント ハンドラーのコードを default.js ファイルに追加します。

##手順 4: イベント ハンドラーの作成

新しいプロジェクトを作成したときに、/js/default.js というファイルが自動的に作成されました。 このファイルには、アプリのライフサイクルを処理するコードが含まれています。 このファイルは、default.html ファイルにインタラクティビティを追加するコードを記述する場所でもあります。

default.js ファイルを開きます。

独自のコードを追加する前に、ファイル内のコードの最初と最後の数行を見てみましょう。

```javascript
(function () {
    "use strict";

     // Omitted code 

 })(); 
```

ここで何が行われているかについて説明します。 これらの行は、default.js コードの残りの行を自己実行型の匿名関数でラップしています。 自己実行型の匿名関数により、名前の競合や値の間違った変更を簡単に避けられます。 また、必要のない識別子をグローバル名前空間から排除できるため、パフォーマンスが向上します。 奇妙に思えるかもしれませんが、これは適切なプログラミング方法です。

次のコード行は、JavaScript コードに対して [strict モード](https://msdn.microsoft.com/library/windows/apps/br230269.aspx)を有効にします。 strict モードにより、コードのエラー チェック機能が強化されます。 たとえば、暗黙的に宣言された変数の使用や、読み取り専用プロパティへの値の割り当てを回避します。

default.js の残りのコードを見てください。 これは、アプリの [**activated**](https://msdn.microsoft.com/library/windows/apps/BR212679) イベントと [**checkpoint**](https://msdn.microsoft.com/library/windows/apps/BR229839) イベントを処理します。 これらのイベントについては、後で詳しく説明します。 ここでは、アプリが起動すると **activated** イベントが発生することだけを覚えておいてください。

```javascript
   (function () {
    "use strict";

    var app = WinJS.Application;
    var activation = Windows.ApplicationModel.Activation;

    app.onactivated = function (args) {
        if (args.detail.kind === activation.ActivationKind.launch) {
            if (args.detail.previousExecutionState !== activation.ApplicationExecutionState.terminated) {
                // TODO: This application has been newly launched. Initialize your application here.
            } else {
                // TODO: This application was suspended and then terminated.
                // To create a smooth user experience, restore application state here so that it looks like the app never stopped running.
            }
            args.setPromise(WinJS.UI.processAll());
        }
    };

    app.oncheckpoint = function (args) {
        // TODO: This application is about to be suspended. Save any state that needs to persist across suspensions here.
        // You might use the WinJS.Application.sessionState object, which is automatically saved and restored across suspension.
        // If you need to complete an asynchronous operation before your application is suspended, call args.setPromise().
    };

    app.start();
})();
```

それでは、[**button**](https://msdn.microsoft.com/library/windows/apps/Hh453017) 用のイベント ハンドラーを定義しましょう。 新しいイベント ハンドラーは、`nameInput` [**input**](https://msdn.microsoft.com/library/windows/apps/Hh453271) コントロールからユーザーの名前を取得し、それを使って前のセクションで作成した `greetingOutput` [**div**](https://msdn.microsoft.com/library/windows/apps/Hh453133) 要素にあいさつを出力します。

### タッチ、マウス、ペン入力で動作するイベントの使用

UWP アプリでは、入力方法 (タッチ、マウス、その他の形式のポインター入力) の違いを気にする必要はありません。 [**click**](https://msdn.microsoft.com/library/windows/apps/Hh441312) などのイベントを使うだけで、あらゆる形式の入力に対応できます。


              **ヒント:** アプリでは、新しい *MSPointer\** イベントと *MSGesture\** イベントも使用できます。これらはタッチ、マウス、ペン入力に対応し、イベントを発生させたデバイスについての情報も提供できます。 詳しくは、「[ユーザー操作への応答](https://msdn.microsoft.com/library/windows/apps/Hh700412)」と「[ジェスチャ、操作、対話的操作](https://msdn.microsoft.com/library/windows/apps/Hh761498)」をご覧ください。

それでは、イベント ハンドラーを作成してみましょう。

**イベント ハンドラーを作成するには**

1.  default.js で、[**app.oncheckpoint**](https://msdn.microsoft.com/library/windows/apps/BR229839) イベント ハンドラーの後、[**app.start**](https://msdn.microsoft.com/library/windows/apps/BR229705) の呼び出しの前に、`eventInfo` という名前の 1 つのパラメーターを受け取る `buttonClickHandler` という名前の [**click**](https://msdn.microsoft.com/library/windows/apps/Hh441312) イベント ハンドラー関数を作成します。
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

これで、イベント ハンドラーが default.js に追加されました。 次に、そのハンドラーを登録する必要があります。

## 手順 5: アプリ起動時のイベント ハンドラーの登録


ここで行う必要があるのは、ボタンにイベント ハンドラーを登録する作業だけです。 イベント ハンドラーを登録する際に推奨される方法は、コードから [**addEventListener**](https://msdn.microsoft.com/library/windows/apps/Hh441145) を呼び出す方法です。 イベント ハンドラーを登録するのに最適なタイミングは、アプリがアクティブ化される時点です。 幸いなことに、アプリのアクティブ化を処理するコード ([**app.onactivated**](https://msdn.microsoft.com/library/windows/apps/BR212679) イベント ハンドラー) が default.js ファイル内に自動的に生成されています。 このコードを見てみましょう。

```javascript
    var app = WinJS.Application;
    var activation = Windows.ApplicationModel.Activation;

    app.onactivated = function (args) {
        if (args.detail.kind === activation.ActivationKind.launch) {
            if (args.detail.previousExecutionState !== activation.ApplicationExecutionState.terminated) {
                // TODO: This application has been newly launched. Initialize your application here.
            } else {
                // TODO: This application was suspended and then terminated.
                // To create a smooth user experience, restore application state here so that it looks like the app never stopped running.
            }
            args.setPromise(WinJS.UI.processAll());
        }
    };
```

[**onactivated**](https://msdn.microsoft.com/library/windows/apps/BR212679) ハンドラーのコードでは、発生したアクティブ化の種類を確認します。 アクティブ化にはさまざまな種類があります。 たとえば、ユーザーがアプリを起動したときと、ユーザーがアプリに関連付けられているファイルを開くときに、アプリはアクティブ化されます  (詳しくは、「[アプリのライフサイクル](https://msdn.microsoft.com/library/windows/apps/Mt243287)」をご覧ください)。

ここでは、[**launch**](https://msdn.microsoft.com/library/windows/apps/BR224693) アクティブ化に注目します。 アプリは、実行されていないときにユーザーがアクティブ化すると*起動*します。

```javascript
    app.onactivated = function (args) {
        if (args.detail.kind === activation.ActivationKind.launch) {
```

アクティブ化が起動アクティブ化の場合、このコードでは、前回アプリがどのようにシャットダウンされたかを確認します。

```javascript
            if (args.detail.previousExecutionState !== activation.ApplicationExecutionState.terminated) {
                // TODO: This application has been newly launched. Initialize your application here.
            } else {
                // TODO: This application was suspended and then terminated.
                // To create a smooth user experience, restore application state here so that it looks like the app never stopped running.
            }
```

その後、[**WinJS.UI.processAll**](https://msdn.microsoft.com/library/windows/apps/Hh440975) を呼び出します。

```javascript
            args.setPromise(WinJS.UI.processAll());
        }
    };
```    

[**WinJS.UI.processAll**](https://msdn.microsoft.com/library/windows/apps/Hh440975) は、アプリが前回シャットダウンされているか、または今回が初めての起動であるかどうかにかかわらず、呼び出されます。 **WinJS.UI.processAll** を [**setPromise**](https://msdn.microsoft.com/library/windows/apps/JJ215609) メソッドの呼び出しで囲むことで、アプリのページが準備できるまで、スプラッシュ画面が消えないようにします。


              **ヒント:** [**WinJS.UI.processAll**](https://msdn.microsoft.com/library/windows/apps/Hh440975) 関数は、default.html ファイルをスキャンして WinJS コントロールを探し、それらを初期化します。 これらのコントロールはまだ追加しませんが、後で追加する場合に備えて、このコードを削除しないでおくことをお勧めします。

WinJS 以外のコントロール用のイベント ハンドラーは、[**WinJS.UI.processAll**](https://msdn.microsoft.com/library/windows/apps/Hh440975) を呼び出した直後に登録します。

**イベント ハンドラーを登録するには**

-   default.js の [**onactivated**](https://msdn.microsoft.com/library/windows/apps/BR212679) イベント ハンドラーで、`helloButton` を取得し、[**addEventListener**](https://msdn.microsoft.com/library/windows/apps/Hh441145) を使用して、[**click**](https://msdn.microsoft.com/library/windows/apps/Hh441312) イベント用のイベント ハンドラーを登録します。 [**WinJS.UI.processAll**](https://msdn.microsoft.com/library/windows/apps/Hh440975) の呼び出しの後に、次のコードを追加します。

```javascript
   app.onactivated = function (args) {
            if (args.detail.kind === activation.ActivationKind.launch) {
                if (args.detail.previousExecutionState !== activation.ApplicationExecutionState.terminated) {
                    // TODO: This application has been newly launched. Initialize your application here.
                } else {
                    // TODO: This application was suspended and then terminated.
                    // To create a smooth user experience, restore application state here so that it looks like the app never stopped running.
                }
                args.setPromise(WinJS.UI.processAll());

             // Retrieve the button and register our event handler. 
                var helloButton = document.getElementById("helloButton");
                helloButton.addEventListener("click", buttonClickHandler, false);
            }
        };
```    

更新された default.js ファイルの完全なコードを以下に示します。

```javascript
   (function () {
    "use strict";

    var app = WinJS.Application;
    var activation = Windows.ApplicationModel.Activation;

    app.onactivated = function (args) {
        if (args.detail.kind === activation.ActivationKind.launch) {
            if (args.detail.previousExecutionState !== activation.ApplicationExecutionState.terminated) {
                // TODO: This application has been newly launched. Initialize your application here.
            } else {
                // TODO: This application was suspended and then terminated.
                // To create a smooth user experience, restore application state here so that it looks like the app never stopped running.
            }
            args.setPromise(WinJS.UI.processAll());

            // Retrieve the button and register our event handler. 
            var helloButton = document.getElementById("helloButton");
            helloButton.addEventListener("click", buttonClickHandler, false);
        }
    };

    app.oncheckpoint = function (args) {
        // TODO: This application is about to be suspended. Save any state that needs to persist across suspensions here.
        // You might use the WinJS.Application.sessionState object, which is automatically saved and restored across suspension.
        // If you need to complete an asynchronous operation before your application is suspended, call args.setPromise().
    };

    function buttonClickHandler(eventInfo) {
        var userName = document.getElementById("nameInput").value;
        var greetingString = "Hello, " + userName + "!";
        document.getElementById("greetingOutput").innerText = greetingString;
    }

    app.start();
})();
```

アプリを実行します。 テキスト ボックスに名前を入力してボタンをクリックすると、ユーザーに合わせたあいさつが表示されます。 ローカル コンピューターとエミュレーターでは次のように表示されます。

![HelloWorld アプリのユーザーに合わせたあいさつ](images/helloworld-3-js.png)

![HelloWorld アプリのユーザーに合わせたあいさつ](images/helloworld-3-js-phone.png)


              **注:** HTML に [**onclick**](https://msdn.microsoft.com/library/windows/apps/Hh441312) イベントを設定するのではなく [**addEventListener**](https://msdn.microsoft.com/library/windows/apps/Hh441145) を使ってコード内のイベントを登録する理由を理解するには、「[基本的なアプリのコーディング](https://msdn.microsoft.com/library/windows/apps/Hh780660)」の詳しい説明をご覧ください。

## 手順 6: JavaScript 用 Windows ライブラリ コントロールの追加


アプリでは、標準の HTML コントロール以外にも、[**WinJS.UI.DatePicker**](https://msdn.microsoft.com/library/windows/apps/BR211681)、[**WinJS.UI.FlipView**](https://msdn.microsoft.com/library/windows/apps/BR211711)、[**WinjS.UI.ListView**](https://msdn.microsoft.com/library/windows/apps/BR211837)、[**WinJS.UI.Rating**](https://msdn.microsoft.com/library/windows/apps/BR211895) コントロールなど、JavaScript 用 Windows ライブラリのいずれのコントロールも使うことができます。

HTML コントロールには専用のマークアップ要素がありますが、WinJS コントロールにはありません。たとえば、`<rating />` 要素を追加しても、[**Rating**](https://msdn.microsoft.com/library/windows/apps/BR211895) コントロールを作成することはできません。 WinJS コントロールを追加するには、[**div**](https://msdn.microsoft.com/library/windows/apps/Hh453133) 要素を作成し、[**data-win-control**](https://msdn.microsoft.com/library/windows/apps/Hh440969) 属性を使ってコントロールの種類を指定します。 **Rating** コントロールを追加するには、この属性を "WinJS.UI.Rating" に設定します。

[**Rating**](https://msdn.microsoft.com/library/windows/apps/BR211895) コントロールをアプリに追加しましょう。

1.  default.html ファイルで、`greetingOutput` [**div**](https://msdn.microsoft.com/library/windows/apps/Hh453133) の後ろに [**label**](https://msdn.microsoft.com/library/windows/apps/Hh453321) コントロールと [**Rating**](https://msdn.microsoft.com/library/windows/apps/BR211895) コントロールを追加します。

    ```html
    <body class="win-type-body">
        <h1>Hello, world!</h1>
        <p>What' s your name?</p>
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

   ![JavaScript 用 Windows ライブラリのコントロールを使った "Hello, world" アプリ](images/helloworld-4-js.png)

> [**Rating**](https://msdn.microsoft.com/library/windows/apps/BR211895) を読み込むには、ページで [**WinJS.UI.processAll**](https://msdn.microsoft.com/library/windows/apps/Hh440975) を呼び出す必要があります。 このアプリでは、Visual Studio テンプレートの 1 つを使っているため、先ほど説明したように、default.js には **WinJS.UI.processAll** の呼び出しが既に含まれています。そのため、コードを追加する必要はありません。

ここで [**Rating**](https://msdn.microsoft.com/library/windows/apps/BR211895) コントロールをクリックすると評価が変化しますが、それ以外は何も起こりません。 イベント ハンドラーを使って、ユーザーが評価を変更したときに何か処理を行うようにしましょう。

## 手順 7: Windows ライブラリの JavaScript 用コントロールのイベント ハンドラーの登録


WinJS コントロールのイベント ハンドラーを登録する方法は、標準の HTML コントロールのイベント ハンドラーを登録する方法と少し異なります。 前に説明したように、[**onactivated**](https://msdn.microsoft.com/library/windows/apps/BR212679) イベント ハンドラーでは、[**WinJS.UI.processAll**](https://msdn.microsoft.com/library/windows/apps/Hh440975) メソッドを呼び出して、マークアップ内で WinJS を初期化します。 **WinJS.UI.processAll** が、[**setPromise**](https://msdn.microsoft.com/library/windows/apps/JJ215609) メソッドの呼び出しの中にカプセル化されます。

```javascript
            args.setPromise(WinJS.UI.processAll());           
```

[**Rating**](https://msdn.microsoft.com/library/windows/apps/BR211895) が標準の HTML コントロールであれば、この [**WinJS.UI.processAll**](https://msdn.microsoft.com/library/windows/apps/Hh440975) の呼び出しの後にイベント ハンドラーを追加できます。 しかし、**Rating** などの WinJS コントロールの場合は、もう少し複雑です。 **WinJS.UI.processAll** によって **Rating** コントロールが作成されるため、**WinJS.UI.processAll** の処理が終わるまで、**Rating** にイベント ハンドラーを追加できません。

[**WinJS.UI.processAll**](https://msdn.microsoft.com/library/windows/apps/Hh440975) が通常のメソッドであれば、呼び出した直後に [**Rating**](https://msdn.microsoft.com/library/windows/apps/BR211895) イベント ハンドラーを登録できます。 しかし、**WinJS.UI.processAll** メソッドは非同期メソッドです。そのため、**WinJS.UI.processAll** が完了する前に次のコードが実行されることもあります。 どうしたらよいでしょうか。 [**Promise**](https://msdn.microsoft.com/library/windows/apps/BR211867) オブジェクトを使って、**WinJS.UI.processAll** が完了したときに通知を受け取るようにします。

すべての非同期 WinJS メソッドと同じように、[**WinJS.UI.processAll**](https://msdn.microsoft.com/library/windows/apps/Hh440975) は [**Promise**](https://msdn.microsoft.com/library/windows/apps/BR211867) オブジェクトを返します。 **Promise** は、後で何かが起こるという "約束" (promise) です。その何かが起こった場合、**Promise** が完了したと言います。


              [
              **Promise**](https://msdn.microsoft.com/library/windows/apps/BR211867) オブジェクトには、パラメーターとして "completed" 関数を受け取る [**then**](https://msdn.microsoft.com/library/windows/apps/BR229728) メソッドがあります。 **Promise** が完了すると、この関数が呼び出されます。

"completed" 関数にコードを追加し、それを [**Promise**](https://msdn.microsoft.com/library/windows/apps/BR211867) オブジェクトの [**then**](https://msdn.microsoft.com/library/windows/apps/BR229728) メソッドに渡すと、[**WinJS.UI.processAll**](https://msdn.microsoft.com/library/windows/apps/Hh440975) の完了後に、そのコードを確実に実行できます。

1.  ユーザーが評価を選んだときに、評価値を出力するようにします。 default.html ファイルで、評価値を表示する [**div**](https://msdn.microsoft.com/library/windows/apps/Hh453133) 要素を作成し、それに "ratingOutput" という **ID** を付けます。
```html
        <body class="win-type-body">
        <h1>Hello, world!</h1>
        <p>What' s your name?</p>
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

2.  default.js ファイルで、[**Rating**](https://msdn.microsoft.com/library/windows/apps/BR211895) コントロールの [**change**](https://msdn.microsoft.com/library/windows/apps/BR211891) イベントのイベント ハンドラーを作成します。このイベント ハンドラーには、`ratingChanged` という名前を付けます。 [**eventInfo**](https://msdn.microsoft.com/library/windows/apps/Hh465776) パラメーターには、新しいユーザー評価を示す **detail.tentativeRating** プロパティが含まれています。 この値を取得し、出力 [**div**](https://msdn.microsoft.com/library/windows/apps/Hh453133) で表示します。

```javascript
        function ratingChanged(eventInfo) {

            var ratingOutput = document.getElementById("ratingOutput");
            ratingOutput.innerText = eventInfo.detail.tentativeRating; 
        }
    ```

3.  Update the code in the [**onactivated**](https://msdn.microsoft.com/library/windows/apps/BR212679) event handler that calls [**WinJS.UI.processAll**](https://msdn.microsoft.com/library/windows/apps/Hh440975) by adding a call to the [**then**](https://msdn.microsoft.com/library/windows/apps/BR229728) method and passing it a `completed` function. In the `completed` function, retrieve the `ratingControlDiv` element that hosts the [**Rating**](https://msdn.microsoft.com/library/windows/apps/BR211895) control. Then use the [**winControl**](https://msdn.microsoft.com/library/windows/apps/Hh770814) property to retrieve the actual **Rating** control. (This example defines the `completed` function inline.)

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

4.  While it's fine to register event handlers for HTML controls after the call to [**WinJS.UI.processAll**](https://msdn.microsoft.com/library/windows/apps/Hh440975), it's also OK to register them inside your `completed` function. For simplicity, let's go ahead and move all your event handler registrations inside the [**then**](https://msdn.microsoft.com/library/windows/apps/BR229728) event handler.

Here's the updated [**onactivated**](https://msdn.microsoft.com/library/windows/apps/BR212679) event handler:

```javascript
       app.onactivated = function (args) {
            if (args.detail.kind === activation.ActivationKind.launch) {
                if (args.detail.previousExecutionState !== activation.ApplicationExecutionState.terminated) {
                    // TODO: This application has been newly launched. Initialize your application here.
                } else {
                    // TODO: This application was suspended and then terminated.
                    // To create a smooth user experience, restore application state here so that it looks like the app never stopped running.
                }
                args.setPromise(WinJS.UI.processAll().then(function completed() {

                    // Retrieve the div that hosts the Rating control.
                    var ratingControlDiv = document.getElementById("ratingControlDiv");

                    // Retrieve the actual Rating control.
                    var ratingControl = ratingControlDiv.winControl;

                    // Register the event handler. 
                    ratingControl.addEventListener("change", ratingChanged, false);

                    // Retrieve the button and register our event handler. 
                    var helloButton = document.getElementById("helloButton");
                    helloButton.addEventListener("click", buttonClickHandler, false);

                }));

            }
        };
```        

5.  アプリを実行します。 評価値を選ぶと、[**Rating**](https://msdn.microsoft.com/library/windows/apps/BR211895) コントロールの下に数値が出力されます。

![PC で動作する完成した HelloWorld アプリ](images/helloworld-5-js.png)

![電話で動作する完成した HelloWorld アプリ](images/helloworld-5-js-phone.png)

## 要約

これで、JavaScript と HTML を使って Windows 10 と UWP 用の初めてのアプリを作成しました。




<!--HONumber=Jul16_HO2-->


