---
author: mcleanbyron
ms.assetid: 646977ed-1705-4ea7-a3db-a6b9aac70703
description: "JavaScript/HTML. を使ってスポット広告を起動する方法について説明します。"
title: "JavaScript を使ったスポット広告のサンプル コード"
ms.sourcegitcommit: cf695b5c20378f7bbadafb5b98cdd3327bcb0be6
ms.openlocfilehash: d6a561aaff834cd782118abb72b4770985176bf0


---

# JavaScript を使ったスポット広告のサンプル コード


\[ Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください \]

このトピックでは、JavaScript/HTML. を使ってスポット広告を起動する方法について説明します。 このコードを使うためのプロジェクトの詳しい構成手順については、「[スポット広告](interstitial-ads.md)」をご覧ください。 JavaScript/HTML. アプリにビデオのスポット広告を追加する方法を示す完全なサンプル プロジェクトについては、[GitHub の広告サンプル](http://aka.ms/githubads)をご覧ください。

## コードの例


この JavaScript/HTML サンプルでは、スポット広告を実装するユニバーサル Windows プラットフォーム (UWP) アプリのコードを示します。 このサンプルでは、JavaScript の空白のアプリ (ユニバーサル Windows) テンプレートを使って新しい Visual Studio 2015 プロジェクトを作成します。

このコードでは、スポット広告を起動するイベントを発生させるボタンを使用します。 Visual Studio によって生成された default.js ファイルと default.html ファイルは変更されています。これらのファイルを次に示します。 次に示す script.js ファイルは、**js** フォルダー/パスのプロジェクトに追加します。

**applicationId** と **adUnitId** に割り当てられているテキストを実際の値に置き換えてください。

### script.js

``` syntax
(function () {
    "use strict";

    // Assign applicationId and adUnitId.
    // Test values. Replace test values with live values before submitting an app to the store.
    var applicationId = "d25517cb-12d4-4699-8bdc-52040c712cab";
    var adUnitId = "11389925";

    var intAd = null;

    window.startInterstitial = function () {
        writeText("<br>Interstitial Ads in JavaScript Windows 10 Apps");
        registerEvents();

        // We know the opportunity to show an ad is coming soon (because this silly game is
        // so short), so prepare the ad now. In a real app, you should request the interstitial
        // close to when you think it will be shown, but with enough advance time to make the
        // request and prepare the ad (say 30 seconds to a few minutes).
        prepareInterstitial();

        writeText("Press the Button to show the interstitial ad.");
    };

    var registerEvents = function () {
        button1.addEventListener("click", onButtonClick);
    };

    var onButtonClick = function (evt) {
        if (intAd && intAd.state !== MicrosoftNSJS.Advertising.InterstitialAdState.showing) {
            showInterstitial();
        }
    }

    var restart = function () {
        if (intAd) {
            intAd.dispose();
        }
        intAd = null;
        window.startInterstitial();
    };

    var clearText = function (msg) {
        description.innerHTML = "";
    };

    var writeText = function (msg) {
        description.innerHTML = description.innerHTML + msg + "<br>";
        description.scrollTop = description.scrollHeight;
    };

    var prepareInterstitial = function () {
        if (!intAd) {
            intAd = new MicrosoftNSJS.Advertising.InterstitialAd();

            intAd.onErrorOccurred = errorOccurredHandler;
            intAd.onAdReady = adReadyHandler;
            intAd.onCancelled = cancelledHandler;
            intAd.onCompleted = completedHandler;

            intAd.requestAd(MicrosoftNSJS.Advertising.InterstitialAdType.video, applicationId, adUnitId);
        }
    };

    var showInterstitial = function () {
        if (intAd && intAd.state === MicrosoftNSJS.Advertising.InterstitialAdState.ready) {
            intAd.show();
        } else {
            // No ad is available to show. Allow user to try again anyway
            clearText();
            writeText("<br>Unable to show an ad. Check the error log. You can try again.");
            restart();
        }
    };

    var errorOccurredHandler = function (sender, args) {
        console.log("error: " + args.errorMessage + " (" + args.errorCode + ")");
        if (!isPlaying) {
            clearText();
            writeText("<br>Unable to show an ad. Check the error log. You can try again.");
            restart();
        }
    };

    var adReadyHandler = function (sender) {
        console.log("ad ready");
    };

    var cancelledHandler = function (sender) {
        console.log("ad cancelled");
        writeText("<br>You must watch the entire ad to continue. <b>Press the Button to watch the

ad.</b>");
        intAd.dispose();
        intAd = null;
        prepareInterstitial();
    };

    var completedHandler = function (sender) {
        console.log("ad complete");
        clearText();
        writeText("<br>Thanks for watching the ad! You can try again!");
        restart();
    };

})();
```

### default.js

``` syntax
// For an introduction to the Blank template, see the following documentation:
// http://go.microsoft.com/fwlink/?LinkId=232509
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

            startInterstitial();

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

### default.html (Windows 10)

``` syntax
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title>App3JSInterstitial</title>

    <!-- WinJS references -->
    <link href="WinJS/css/ui-dark.css" rel="stylesheet" />
    <script src="WinJS/js/base.js"></script>
    <script src="WinJS/js/ui.js"></script>

    <!-- App3JSInterstitial references -->
    <link href="/css/default.css" rel="stylesheet" />
    <script src="/js/default.js"></script>
    <script src="/js/script.js"></script>

    <!-- ad.js src for Windows 10 -->
    <script src="//Microsoft.Advertising.JS/ad.js"></script>
</head>
<body class="win-type-body">
    <button id="button1" onclick="onButtonClick" class="win-button">Interstitial</button>
    <div id="description" style="height:100%; overflow:auto"></div>
</body>
</html>
```

### default.html (Windows 8.x)

``` syntax
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title>App3JSInterstitial</title>

    <!-- WinJS references -->
    <link href="WinJS/css/ui-dark.css" rel="stylesheet" />
    <script src="WinJS/js/base.js"></script>
    <script src="WinJS/js/ui.js"></script>

    <!-- App3JSInterstitial references -->
    <link href="/css/default.css" rel="stylesheet" />
    <script src="/js/default.js"></script>
    <script src="/js/script.js"></script>

    <!-- ad.js src for Windows 8.x -->
    <script src="//Microsoft.Advertising.JS/ads/ad.js"></script>
</head>
<body class="win-type-body">
    <button id="button1" onclick="onButtonClick" class="win-button">Interstitial</button>
    <div id="description" style="height:100%; overflow:auto"></div>
</body>
</html>
```

## 関連トピック

* [GitHub の広告サンプル](http://aka.ms/githubads)

 



<!--HONumber=Jun16_HO4-->


