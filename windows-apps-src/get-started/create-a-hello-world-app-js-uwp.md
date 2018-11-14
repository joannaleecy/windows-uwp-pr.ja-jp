---
author: GrantMeStrength
ms.assetid: 3a17e682-40be-41b4-8bd3-fbf0b15259d6
title: Hello, world アプリを作成する (JS)
description: このチュートリアルでは、対象を JavaScript と HTML を使って単純な & \#0034; を作成する方法こんにちは, world & \#0034 です。windows 10 のユニバーサル Windows プラットフォーム (UWP) を対象とするアプリ。
ms.author: jken
ms.date: 03/06/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 4d8fb1dc486c039007c3ea0d4ee36d72c0c511f9
ms.sourcegitcommit: f2c9a050a9137a473f28b613968d5782866142c6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/10/2018
ms.locfileid: "6261137"
---
# <a name="create-a-hello-world-app-js"></a><span data-ttu-id="d6079-104">Hello, world アプリを作成する (JS)</span><span class="sxs-lookup"><span data-stu-id="d6079-104">Create a "Hello, world" app (JS)</span></span>

<span data-ttu-id="d6079-105">このチュートリアルは、JavaScript と HTML を使って、シンプルなを作成する方法を教えて「こんにちは, world」アプリを windows 10 のユニバーサル Windows プラットフォーム (UWP) をターゲットとします。</span><span class="sxs-lookup"><span data-stu-id="d6079-105">This tutorial teaches you how to use JavaScript and HTML to create a simple "Hello, world" app that targets the Universal Windows Platform (UWP) on Windows10.</span></span> <span data-ttu-id="d6079-106">Microsoft Visual Studio でプロジェクトを 1 つは、任意の windows 10 デバイスで実行されるアプリをビルドすることができます。</span><span class="sxs-lookup"><span data-stu-id="d6079-106">With a single project in Microsoft Visual Studio, you can build an app that runs on any Windows10 device.</span></span>

> [!NOTE]
> <span data-ttu-id="d6079-107">このチュートリアルでは、Visual Studio Community 2017 を使います。</span><span class="sxs-lookup"><span data-stu-id="d6079-107">This tutorial is using Visual Studio Community 2017.</span></span> <span data-ttu-id="d6079-108">異なるバージョンの Visual Studio を使っている場合には、見た目が多少異なることがあります。</span><span class="sxs-lookup"><span data-stu-id="d6079-108">If you are using a different version of Visual Studio, it may look a little different for you.</span></span>


<span data-ttu-id="d6079-109">ここでは、次の方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="d6079-109">Here you'll learn how to:</span></span>

-   <span data-ttu-id="d6079-110">**Windows 10**と**UWP**を対象とする新しい**Visual Studio 2017**プロジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="d6079-110">Create a new **Visual Studio 2017** project that targets **Windows10** and the **UWP**.</span></span>
-   <span data-ttu-id="d6079-111">HTML と JavaScript のコンテンツを追加する</span><span class="sxs-lookup"><span data-stu-id="d6079-111">Add HTML and JavaScript content</span></span>
-   <span data-ttu-id="d6079-112">Visual Studio のローカル デスクトップでプロジェクトを実行する</span><span class="sxs-lookup"><span data-stu-id="d6079-112">Run the project on the local desktop in Visual Studio</span></span>

## <a name="before-you-start"></a><span data-ttu-id="d6079-113">はじめに...</span><span class="sxs-lookup"><span data-stu-id="d6079-113">Before you start...</span></span>

-   <span data-ttu-id="d6079-114">[UWP アプリとは](universal-application-platform-guide.md)。</span><span class="sxs-lookup"><span data-stu-id="d6079-114">[What's a UWP app?](universal-application-platform-guide.md).</span></span>
-   <span data-ttu-id="d6079-115">このチュートリアルを完了するには、windows 10 と Visual Studio2017 が必要です。</span><span class="sxs-lookup"><span data-stu-id="d6079-115">To complete this tutorial, you need Windows10 and Visual Studio2017.</span></span> <span data-ttu-id="d6079-116">[準備してください](get-set-up.md)。</span><span class="sxs-lookup"><span data-stu-id="d6079-116">[Get set up](get-set-up.md).</span></span>
-   <span data-ttu-id="d6079-117">また、Visual Studio の既定のウィンドウ レイアウトを使用することを前提としています。</span><span class="sxs-lookup"><span data-stu-id="d6079-117">We also assume you're using the default window layout in Visual Studio.</span></span> <span data-ttu-id="d6079-118">既定のレイアウトを変更した場合は、**[ウィンドウ]** メニューの **[ウィンドウ レイアウトのリセット]** を使って、レイアウトをリセットできます。</span><span class="sxs-lookup"><span data-stu-id="d6079-118">If you change the default layout, you can reset it in the **Window** menu by using the **Reset Window Layout** command.</span></span>

## <a name="step-1-create-a-new-project-in-visual-studio"></a><span data-ttu-id="d6079-119">手順 1. Visual Studio で新しいプロジェクトを作る</span><span class="sxs-lookup"><span data-stu-id="d6079-119">Step 1: Create a new project in Visual Studio.</span></span>

1.  <span data-ttu-id="d6079-120">Visual Studio 2017 を起動します。</span><span class="sxs-lookup"><span data-stu-id="d6079-120">Launch Visual Studio 2017.</span></span>

2.  <span data-ttu-id="d6079-121">**[ファイル]** メニューの **[新規作成] > [プロジェクト]** を選択し、*[新しいプロジェクト]* ダイアログを開きます。</span><span class="sxs-lookup"><span data-stu-id="d6079-121">From the **File** menu, select **New > Project...** to open the *New Project* dialog.</span></span>

3.  <span data-ttu-id="d6079-122">左側のテンプレートの一覧で、**[インストール済み] > [テンプレート] > [JavaScript]** の順に開いた後、**[Windows ユニバーサル]** を選択して UWP プロジェクト テンプレートの一覧を表示します。</span><span class="sxs-lookup"><span data-stu-id="d6079-122">From the list of templates on the left, open **Installed > Templates > JavaScript**, and then choose **Windows Universal** to see the list of UWP project templates.</span></span>

    <span data-ttu-id="d6079-123">ユニバーサル テンプレートが表示されない場合は、UWP アプリを作成するためのコンポーネントがない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="d6079-123">(If you don't see any Universal templates, you might be missing the components for creating UWP apps.</span></span> <span data-ttu-id="d6079-124">インストール プロセスを繰り返して UWP サポートを追加することもできます (*[新しいプロジェクト]* ダイアログで **[Visual Studio インストーラーを開く]** をクリック)。</span><span class="sxs-lookup"><span data-stu-id="d6079-124">You can repeat the installation process and add UWP support by clicking **Open Visual Studio installer** on the *New Project* dialog.</span></span> <span data-ttu-id="d6079-125">「[準備](get-set-up.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d6079-125">See [Get set up](get-set-up.md)</span></span>

4.  <span data-ttu-id="d6079-126">**[空白のアプリ (ユニバーサル Windows)]** テンプレートを選択し、**[名前]** に「HelloWorld」と入力します。</span><span class="sxs-lookup"><span data-stu-id="d6079-126">Choose the **Blank App (Universal Windows)** template, and enter "HelloWorld" as the **Name**.</span></span> <span data-ttu-id="d6079-127">**[OK]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="d6079-127">Select **OK**.</span></span>

    ![[新しいプロジェクト] ウィンドウ](images/win10-js-01.png)

> [!NOTE]
> <span data-ttu-id="d6079-129">Visual Studio を初めて使う場合は、[設定] ダイアログ ボックスが表示され、**開発者モード**を有効にするよう求められることがあります。</span><span class="sxs-lookup"><span data-stu-id="d6079-129">If this is the first time you have used Visual Studio, you might see a Settings dialog asking you to enable **Developer mode**.</span></span> <span data-ttu-id="d6079-130">開発者モードは、アプリをストアからだけではなく、直接実行するためのアクセス許可など、特定の機能を有効にする特別な設定です。</span><span class="sxs-lookup"><span data-stu-id="d6079-130">Developer mode is a special setting that enables certain features, such as permission to run apps directly, rather than only from the Store.</span></span> <span data-ttu-id="d6079-131">詳しくは、「[デバイスを開発用に有効にする](enable-your-device-for-development.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d6079-131">For more information, please read [Enable your device for development](enable-your-device-for-development.md).</span></span> <span data-ttu-id="d6079-132">先に進むには、**[開発者モード]** を選択し、**[はい]** をクリックしてダイアログ ボックスを閉じます。</span><span class="sxs-lookup"><span data-stu-id="d6079-132">To continue with this guide, select **Developer mode**, click **Yes**, and close the dialog.</span></span>

 ![開発者モードのアクティブ化ダイアログ](images/win10-cs-00.png)

5.  <span data-ttu-id="d6079-134">ターゲット バージョンと最小バージョンのダイアログが表示されます。</span><span class="sxs-lookup"><span data-stu-id="d6079-134">The target version/minimum version dialog appears.</span></span> <span data-ttu-id="d6079-135">このチュートリアルでは既定の設定で問題ないため、**[OK]** を選択してプロジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="d6079-135">The default settings are fine for this tutorial, so select **OK** to create the project.</span></span>

    ![ソリューション エクスプローラーのウィンドウ](images/win10-cs-02.png)

6.  <span data-ttu-id="d6079-137">新しいプロジェクトが開き、そのプロジェクトのファイルが右側の**ソリューション エクスプローラー**のウィンドウに表示されます。</span><span class="sxs-lookup"><span data-stu-id="d6079-137">When your new project opens, its files are displayed in the **Solution Explorer** pane on the right.</span></span> <span data-ttu-id="d6079-138">場合によっては、ファイルを表示するために **[ソリューション エクスプローラー]** タブを選択する必要があります (**[プロパティ]** タブではありません)。</span><span class="sxs-lookup"><span data-stu-id="d6079-138">You may need to choose the **Solution Explorer** tab instead of the **Properties** tab to see your files.</span></span>

    ![ソリューション エクスプローラーのウィンドウ](images/win10-js-02.png)

<span data-ttu-id="d6079-140">**[空白のアプリ (ユニバーサル Windows)]** は最小限のテンプレートですが、多くのファイルが含まれています。</span><span class="sxs-lookup"><span data-stu-id="d6079-140">Although the **Blank App (Universal Window)** is a minimal template, it still contains a lot of files.</span></span> <span data-ttu-id="d6079-141">これらのファイルは、JavaScript を使うすべての UWP アプリに必要です。</span><span class="sxs-lookup"><span data-stu-id="d6079-141">These files are essential to all UWP apps using JavaScript.</span></span> <span data-ttu-id="d6079-142">Visual Studio で作るすべてのプロジェクトには、これらのファイルが必ず含まれます。</span><span class="sxs-lookup"><span data-stu-id="d6079-142">Every project that you create in Visual Studio contains them.</span></span>


### <a name="whats-in-the-files"></a><span data-ttu-id="d6079-143">ファイルの内容</span><span class="sxs-lookup"><span data-stu-id="d6079-143">What's in the files?</span></span>

<span data-ttu-id="d6079-144">プロジェクトのファイルを表示して編集するには、**ソリューション エクスプローラー**でファイルをダブルクリックします。</span><span class="sxs-lookup"><span data-stu-id="d6079-144">To view and edit a file in your project, double-click the file in the **Solution Explorer**.</span></span> 

*<span data-ttu-id="d6079-145">default.css</span><span class="sxs-lookup"><span data-stu-id="d6079-145">default.css</span></span>*

-  <span data-ttu-id="d6079-146">アプリによって使用される既定のスタイルシート。</span><span class="sxs-lookup"><span data-stu-id="d6079-146">The default stylesheet used by the app.</span></span>

*<span data-ttu-id="d6079-147">main.js</span><span class="sxs-lookup"><span data-stu-id="d6079-147">main.js</span></span>*

- <span data-ttu-id="d6079-148">既定の JavaScript ファイル。</span><span class="sxs-lookup"><span data-stu-id="d6079-148">The default JavaScript file.</span></span> <span data-ttu-id="d6079-149">index.html ファイル内で参照されます。</span><span class="sxs-lookup"><span data-stu-id="d6079-149">It's referenced in the index.html file.</span></span>

*<span data-ttu-id="d6079-150">index.html</span><span class="sxs-lookup"><span data-stu-id="d6079-150">index.html</span></span>*

- <span data-ttu-id="d6079-151">アプリの Web ページです。アプリの起動時に読み込まれ、表示されます。</span><span class="sxs-lookup"><span data-stu-id="d6079-151">The app's web page, loaded and displayed when the app is launched.</span></span>

*<span data-ttu-id="d6079-152">一連のロゴ イメージ</span><span class="sxs-lookup"><span data-stu-id="d6079-152">A set of logo images</span></span>*
-   <span data-ttu-id="d6079-153">Assets/Square150x150Logo.scale-200.png は、スタート メニュー内のアプリを表します。</span><span class="sxs-lookup"><span data-stu-id="d6079-153">Assets/Square150x150Logo.scale-200.png represents your app in the start menu.</span></span>
-   <span data-ttu-id="d6079-154">Assets/StoreLogo.png は、Microsoft Store 内のアプリを表します。</span><span class="sxs-lookup"><span data-stu-id="d6079-154">Assets/StoreLogo.png represents your app in the Microsoft Store.</span></span>
-   <span data-ttu-id="d6079-155">Assets/SplashScreen.scale-200.png は、アプリが起動したときに表示するスプラッシュ画面です。</span><span class="sxs-lookup"><span data-stu-id="d6079-155">Assets/SplashScreen.scale-200.png is the splash screen that appears when your app starts.</span></span>

## <a name="step-2-adding-a-button"></a><span data-ttu-id="d6079-156">手順 2. ボタンを追加する</span><span class="sxs-lookup"><span data-stu-id="d6079-156">Step 2: Adding a button</span></span>

<span data-ttu-id="d6079-157">エディターで *index.html* をクリックして選択し、含まれている HTML を次のように変更します。</span><span class="sxs-lookup"><span data-stu-id="d6079-157">Click on *index.html* to select it in the editor, and change the HTML it contains to read:</span></span>

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

<span data-ttu-id="d6079-158">次のようになります。</span><span class="sxs-lookup"><span data-stu-id="d6079-158">It should look like this:</span></span>

 ![プロジェクトの HTML](images/win10-js-03.png)

<span data-ttu-id="d6079-160">この HTML では、JavaScript が含まれた *main.js* を参照し、Web ページの本文に 1 行のテキストと単一のボタンを追加します。</span><span class="sxs-lookup"><span data-stu-id="d6079-160">This HTML references the *main.js* that will contain our JavaScript, and then adds a single line of text and a single button to the body of the web page.</span></span> <span data-ttu-id="d6079-161">ボタンには、JavaScript が参照できるように *ID* が設定されます。</span><span class="sxs-lookup"><span data-stu-id="d6079-161">The button is given an *ID* so the JavaScript will be able to reference it.</span></span>


## <a name="step-3-adding-some-javascript"></a><span data-ttu-id="d6079-162">手順 3: JavaScript を追加する</span><span class="sxs-lookup"><span data-stu-id="d6079-162">Step 3: Adding some JavaScript</span></span>

<span data-ttu-id="d6079-163">次は、JavaScript を追加します。</span><span class="sxs-lookup"><span data-stu-id="d6079-163">Now we'll add the JavaScript.</span></span> <span data-ttu-id="d6079-164">*main.js* をクリックして選択し、以下を追加します。</span><span class="sxs-lookup"><span data-stu-id="d6079-164">Click on *main.js* to select it, and add the following:</span></span>

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

<span data-ttu-id="d6079-165">次のようになります。</span><span class="sxs-lookup"><span data-stu-id="d6079-165">It should look like this:</span></span>

 ![プロジェクトの JavaScript](images/win10-js-04.png)

<span data-ttu-id="d6079-167">この JavaScript では、2 つの関数を宣言します。</span><span class="sxs-lookup"><span data-stu-id="d6079-167">This JavaScript declares two functions.</span></span> <span data-ttu-id="d6079-168">*Window.onload* 関数は、*index.html* が表示されたときに自動的に呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="d6079-168">The *window.onload* function is called automatically when *index.html* is displayed.</span></span> <span data-ttu-id="d6079-169">この関数は、(宣言されている ID を使用して) ボタンを検出し、onclick ハンドラーを追加します。onclick は、ボタンのクリック時に呼び出されるメソッドです。</span><span class="sxs-lookup"><span data-stu-id="d6079-169">It finds the button (using the ID we declared) and adds an onclick handler: the method that will be called when the button is clicked.</span></span>

<span data-ttu-id="d6079-170">2 番目の関数 *sayHello()* では、ダイアログを作成して表示します。</span><span class="sxs-lookup"><span data-stu-id="d6079-170">The second function, *sayHello()*, creates and displays a dialog.</span></span> <span data-ttu-id="d6079-171">これは、前の JavaScript 開発で使用した *Alert()* 関数とよく似ています。</span><span class="sxs-lookup"><span data-stu-id="d6079-171">This is very similar to the *Alert()* function you may know from previous JavaScript development.</span></span>


## <a name="step-4-run-the-app"></a><span data-ttu-id="d6079-172">手順 4: アプリを実行する</span><span class="sxs-lookup"><span data-stu-id="d6079-172">Step 4: Run the app!</span></span>

<span data-ttu-id="d6079-173">ここで F5 キーを押すと、アプリを実行できます。</span><span class="sxs-lookup"><span data-stu-id="d6079-173">Now you can run the app by pressing F5.</span></span> <span data-ttu-id="d6079-174">アプリが読み込まれ、Web ページが表示されます。</span><span class="sxs-lookup"><span data-stu-id="d6079-174">The app will load, the web page will be displayed.</span></span> <span data-ttu-id="d6079-175">ボタンをクリックすると、メッセージ ダイアログ ボックスが表示されます。</span><span class="sxs-lookup"><span data-stu-id="d6079-175">Click on the button, and the message dialog will pop-up.</span></span>

 ![プロジェクトを実行する](images/win10-js-05.png)



## <a name="summary"></a><span data-ttu-id="d6079-177">まとめ</span><span class="sxs-lookup"><span data-stu-id="d6079-177">Summary</span></span>


<span data-ttu-id="d6079-178">これで、windows 10 と UWP の JavaScript アプリを作成しました。</span><span class="sxs-lookup"><span data-stu-id="d6079-178">Congratulations, you've created a JavaScript app for Windows10 and the UWP!</span></span> <span data-ttu-id="d6079-179">これは極端にシンプルな例ですが、これに好きな JavaScript ライブラリやフレームワークを追加して、独自のアプリを作成することができます。</span><span class="sxs-lookup"><span data-stu-id="d6079-179">This is a ridiculously simple example, however, you can now start adding your favorite JavaScript libraries and frameworks to create your own app.</span></span> <span data-ttu-id="d6079-180">また、これは UWP アプリなので、ストアに公開できます。</span><span class="sxs-lookup"><span data-stu-id="d6079-180">And as it's a UWP app, you can publish it to the Store.</span></span> <span data-ttu-id="d6079-181">サード パーティのフレームワークを追加する方法の例については、以下のプロジェクトをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d6079-181">For example of how third party frameworks can be added, see these  projects:</span></span>

* [<span data-ttu-id="d6079-182">JavaScript と CreateJS で記述された Microsoft Store 向けのシンプルな 2D UWP ゲーム</span><span class="sxs-lookup"><span data-stu-id="d6079-182">A simple 2D UWP game for the Microsoft Store, written in JavaScript and CreateJS</span></span>](get-started-tutorial-game-js2d.md)
* [<span data-ttu-id="d6079-183">JavaScript と threeJS で記述された Microsoft Store 向けの 3D UWP ゲーム</span><span class="sxs-lookup"><span data-stu-id="d6079-183">A 3D UWP game for the Microsoft Store, written in JavaScript and threeJS</span></span>](get-started-tutorial-game-js3d.md)


