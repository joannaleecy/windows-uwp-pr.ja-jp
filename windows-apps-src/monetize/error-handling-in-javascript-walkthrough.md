---
author: mcleanbyron
ms.assetid: 08b4ae43-69e8-4424-b3c0-a07c93d275c3
description: "アプリで AdControl エラーをキャッチする方法について説明します。"
title: "JavaScript ウォークスルーでのエラー処理"
ms.author: mcleans
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, 広告, 宣伝, エラー処理, JavaScript"
ms.openlocfilehash: 5b3e9b66ea0b52e9a44b6c71c3d7107a86b038df
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="error-handling-in-javascript-walkthrough"></a>JavaScript ウォークスルーでのエラー処理




このトピックでは、アプリで [AdControl](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.aspx) エラーをキャッチする方法について説明します。

これらの例は、**AdControl** を含む JavaScript/HTML アプリがあることを前提としています。 アプリに **AdControl** を追加する方法を示す具体的な手順については、「[HTML 5 および Javascript の AdControl](adcontrol-in-html-5-and-javascript.md)」をご覧ください。 JavaScript/HTML アプリにバナー広告を追加する方法を示す完全なサンプル プロジェクトについては、「[GitHub の広告サンプル](http://aka.ms/githubads)」をご覧ください。

1.  default.html ファイルで、**AdControl** の **div** の **data-win-options** を定義する **onErrorOccurred** イベントの値を追加します。 default.html ファイルで次のコードを探します。

  > [!div class="tabbedCodeSnippets"]
  ``` html
  <div id="myAd" style="position: absolute; top: 53px; left: 0px; width: 300px; height: 250px; z-index: 1"
      data-win-control="MicrosoftNSJS.Advertising.AdControl"
      data-win-options="{applicationId: '3f83fe91-d6be-434d-a0ae-7351c5a997f1', adUnitId: '10865270'}">
  </div>
  ```

  **adUnitId** 属性の後に、**onErrorOccurred** イベントの値を追加します。

  > [!div class="tabbedCodeSnippets"]
  ``` html
  <div id="myAd" style="position: absolute; top: 53px; left: 0px; width: 300px; height: 250px; z-index: 1"
      data-win-control="MicrosoftNSJS.Advertising.AdControl"
      data-win-options="{applicationId: '3f83fe91-d6be-434d-a0ae-7351c5a997f1', adUnitId: '10865270', onErrorOccurred: errorLogger}">
  </div>
  ```

2.  テキストを表示する **div** を作成して、生成されたメッセージを確認できるようにします。 これを行うには、**myAd** の **div** の後に次のコードを追加します。

  > [!div class="tabbedCodeSnippets"]
  ``` html
  <div style="position:absolute; width:100%; height:130px; top:300px; left:0px">
      <b>Ad Events</b><br />
      <div id="adEvents" style="width:100%; height:110px; overflow:auto"></div>
  </div>
  ```

3.  エラー イベントをトリガーする **AdControl** を作成します。 アプリ内のすべての **AdControl** オブジェクトには、アプリケーション ID が 1 つだけ存在できます。 そのため、異なるアプリケーション ID で追加のオブジェクトを作成すると、実行時にエラーがトリガーされます。 これを行うには、追加済みの前の **div** セクションの後に、default.html ページの本文に次のコードを追加します。

  > [!div class="tabbedCodeSnippets"]
  ``` html
  <!-- Because only one applicationId can be used, the following ad control will fire an error event. -->
  <div id="liveAd" style="position: absolute; top:500px; left:0px; width:480px; height:80px"
      data-win-control="MicrosoftNSJS.Advertising.AdControl"
      data-win-options="{applicationId: '00000000-0000-0000-0000-000000000000', adUnitId: '10865270', onErrorOccurred: errorLogger }" >
  </div>
  ```

4.  プロジェクトの default.js ファイルで、既定の初期化関数の後に **errorLogger** のイベント ハンドラーを追加します。 ファイルの最後までスクロールし、最後のセミコロンの後に次のコードを配置します。

  > [!div class="tabbedCodeSnippets"]
  ``` javascript
  WinJS.Utilities.markSupportedForProcessing(
  window.errorLogger = function (sender, evt) {
        adEvents.innerHTML = (new Date()).toLocaleTimeString() + ": " +
        sender.element.id + " error: " + evt.errorMessage + " error code: " +
        evt.errorCode + "<br>" + adEvents.innerHTML;
        console.log("errorhandler hit. \n");
  });
  ```

5.  ファイルをビルドして実行します。 前にビルドしたサンプル アプリの元の広告が表示され、その広告の下にエラーを説明するテキストが表示されます。 **liveAd** の ID を持つ広告は表示されません。

## <a name="related-topics"></a>関連トピック

* [GitHub の広告サンプル](http://aka.ms/githubads)

 
