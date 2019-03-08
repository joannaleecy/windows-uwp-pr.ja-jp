---
ms.assetid: 3a17e682-40be-41b4-8bd3-fbf0b15259d6
title: "\"Hello, world\" アプリを作成する (JS)"
description: このチュートリアルには、JavaScript と HTML を使用して、単純なを作成する方法が説明します (& a)\#0034;こんにちは, world &\#0034; Windows 10 ユニバーサル Windows プラットフォーム (UWP) を対象とするアプリです。
ms.date: 03/06/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: c5b99c95167940c1ae51dbe96a3e43dc6fb0af34
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57620427"
---
# <a name="create-a-hello-world-app-js"></a>"Hello, world" アプリを作成する (JS)

このチュートリアルには、JavaScript と HTML を使用して、単純なを作成する方法が説明します「こんにちは, world」Windows 10 ユニバーサル Windows プラットフォーム (UWP) を対象とするアプリです。 Microsoft Visual Studio での 1 つのプロジェクトでは、任意の Windows 10 デバイスで実行されているアプリを構築できます。

> [!NOTE]
> このチュートリアルでは、Visual Studio Community 2017 を使います。 異なるバージョンの Visual Studio を使っている場合には、見た目が多少異なることがあります。


ここでは、次の方法について説明します。

-   新規作成**Visual Studio 2017**を対象とするプロジェクト**Windows 10**と**UWP**します。
-   HTML と JavaScript のコンテンツを追加する
-   Visual Studio のローカル デスクトップでプロジェクトを実行する

## <a name="before-you-start"></a>はじめに...

-   [UWP アプリとは](universal-application-platform-guide.md)。
-   このチュートリアルを完了するには、Windows 10 と Visual Studio 2017 が必要です。 [準備してください](get-set-up.md)。
-   また、Visual Studio の既定のウィンドウ レイアウトを使用することを前提としています。 既定のレイアウトを変更した場合は、**[ウィンドウ]** メニューの **[ウィンドウ レイアウトのリセット]** を使って、レイアウトをリセットできます。

## <a name="step-1-create-a-new-project-in-visual-studio"></a>手順 1:Visual Studio で新しいプロジェクトを作成します。

1.  Visual Studio 2017 を起動します。

2.  **[ファイル]** メニューの **[新規作成]、[プロジェクト]** の順にクリックし、*[新しいプロジェクト]* ダイアログを開きます。

3.  左側のテンプレートの一覧で、**[インストール済み] > [テンプレート] > [JavaScript]** の順に開いた後、**[Windows ユニバーサル]** を選択して UWP プロジェクト テンプレートの一覧を表示します。

    ユニバーサル テンプレートが表示されない場合は、UWP アプリを作成するためのコンポーネントがない可能性があります。 インストール プロセスを繰り返して UWP サポートを追加することもできます (*[新しいプロジェクト]* ダイアログで **[Visual Studio インストーラーを開く]** をクリック)。 「[準備](get-set-up.md)」をご覧ください。

4.  **[空白のアプリ (ユニバーサル Windows)]** テンプレートを選択し、**[名前]** に「HelloWorld」と入力します。 **[OK]** を選択します。

    ![[新しいプロジェクト] ウィンドウ](images/win10-js-01.png)

> [!NOTE]
> Visual Studio を初めて使う場合は、[設定] ダイアログ ボックスが表示され、**開発者モード**を有効にするよう求められることがあります。 開発者モードは、アプリをストアからだけではなく、直接実行するためのアクセス許可など、特定の機能を有効にする特別な設定です。 詳しくは、「[デバイスを開発用に有効にする](enable-your-device-for-development.md)」をご覧ください。 先に進むには、**[開発者モード]** を選択し、**[はい]** をクリックしてダイアログ ボックスを閉じます。

 ![開発者モードのアクティブ化ダイアログ](images/win10-cs-00.png)

5.  ターゲット バージョンと最小バージョンのダイアログが表示されます。 このチュートリアルでは既定の設定で問題ないため、**[OK]** を選択してプロジェクトを作成します。

    ![ソリューション エクスプローラーのウィンドウ](images/win10-cs-02.png)

6.  新しいプロジェクトが開き、そのプロジェクトのファイルが右側の**ソリューション エクスプローラー**のウィンドウに表示されます。 場合によっては、ファイルを表示するために **[ソリューション エクスプローラー]** タブを選択する必要があります (**[プロパティ]** タブではありません)。

    ![ソリューション エクスプローラーのウィンドウ](images/win10-js-02.png)

**[空白のアプリ (ユニバーサル Windows)]** は最小限のテンプレートですが、多くのファイルが含まれています。 これらのファイルは、JavaScript を使うすべての UWP アプリに必要です。 Visual Studio で作るすべてのプロジェクトには、これらのファイルが必ず含まれます。


### <a name="whats-in-the-files"></a>ファイルの内容

プロジェクトのファイルを表示して編集するには、**ソリューション エクスプローラー**でファイルをダブルクリックします。 

*default.css*

-  アプリによって使用される既定のスタイルシート。

*main.js*

- 既定の JavaScript ファイル。 index.html ファイル内で参照されます。

*index.html*

- アプリの Web ページです。アプリの起動時に読み込まれ、表示されます。

*ロゴのイメージのセット*
-   Assets/Square150x150Logo.scale-200.png は、スタート メニュー内のアプリを表します。
-   Assets/StoreLogo.png は、Microsoft Store 内のアプリを表します。
-   Assets/SplashScreen.scale-200.png は、アプリが起動したときに表示するスプラッシュ画面です。

## <a name="step-2-adding-a-button"></a>手順 2:ボタンの追加

エディターで *index.html* をクリックして選択し、含まれている HTML を次のように変更します。

```html
<!DOCTYPE html>
<html>

<head>
    <meta charset="utf-8" />
    <title>Hello World</title>
    <script src="js/main.js"></script>
    <link href="css/default.css" rel="stylesheet" />
</head>

<body>
    <p>Click the button..</p>
    <button id="button">Hello world!</button>
</body>

</html>
```

これは次のようになります。

 ![プロジェクトの HTML](images/win10-js-03.png)

この HTML では、JavaScript が含まれた *main.js* を参照し、Web ページの本文に 1 行のテキストと単一のボタンを追加します。 ボタンには、JavaScript が参照できるように *ID* が設定されます。


## <a name="step-3-adding-some-javascript"></a>手順 3:何らかの JavaScript を追加します。

次は、JavaScript を追加します。 *main.js* をクリックして選択し、以下を追加します。

```javascript
// Your code here!

window.onload = function () {
    document.getElementById("button").onclick = function (evt) {
        sayHello()
    }
}


function sayHello() {
    var messageDialog = new Windows.UI.Popups.MessageDialog("Hello, world!", "Alert");
    messageDialog.showAsync();
}

```

これは次のようになります。

 ![プロジェクトの JavaScript](images/win10-js-04.png)

この JavaScript では、2 つの関数を宣言します。 *Window.onload* 関数は、*index.html* が表示されたときに自動的に呼び出されます。 この関数は、(宣言されている ID を使用して) ボタンを検出し、onclick ハンドラーを追加します。onclick は、ボタンのクリック時に呼び出されるメソッドです。

2 番目の関数 *sayHello()* では、ダイアログを作成して表示します。 これは、前の JavaScript 開発で使用した *Alert()* 関数とよく似ています。


## <a name="step-4-run-the-app"></a>手順 4:アプリを実行します。

ここで F5 キーを押すと、アプリを実行できます。 アプリが読み込まれ、Web ページが表示されます。 ボタンをクリックすると、メッセージ ダイアログ ボックスが表示されます。

 ![プロジェクトを実行する](images/win10-js-05.png)



## <a name="summary"></a>概要


これで、Windows 10 と UWP の JavaScript アプリを作成しました。 これは極端にシンプルな例ですが、これに好きな JavaScript ライブラリやフレームワークを追加して、独自のアプリを作成することができます。 また、これは UWP アプリなので、ストアに公開できます。 サード パーティのフレームワークを追加する方法の例については、以下のプロジェクトをご覧ください。

* [JavaScript および CreateJS で記述された、Microsoft Store のゲームを単純な 2D UWP](get-started-tutorial-game-js2d.md)
* [JavaScript および threeJS で記述された、Microsoft Store のゲームの 3D の UWP](get-started-tutorial-game-js3d.md)


