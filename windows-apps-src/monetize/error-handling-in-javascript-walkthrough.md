---
author: Xansky
ms.assetid: 08b4ae43-69e8-4424-b3c0-a07c93d275c3
description: アプリで AdControl エラーをキャッチする方法について説明します。
title: JavaScript ウォークスルーでのエラー処理
ms.author: mhopkins
ms.date: 05/11/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, 広告, 宣伝, エラー処理, JavaScript
ms.localizationpriority: medium
ms.openlocfilehash: 5e25de40c7fd28cb43c308bd0361b400e7bf6909
ms.sourcegitcommit: c4d3115348c8b54fcc92aae8e18fdabc3deb301d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/22/2018
ms.locfileid: "5398059"
---
# <a name="error-handling-in-javascript-walkthrough"></a>JavaScript ウォークスルーでのエラー処理

このチュートリアルでは、JavaScript アプリで広告関連のエラーをキャッチする方法について説明します。 このチュートリアルでは、[AdControl](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.adcontrol) を使用してバナー広告を表示していますが、その中の一般的な概念はスポット広告やネイティブ広告にも適用されます。

これらの例は、**AdControl** を含む JavaScript アプリがあることを前提としています。 アプリに **AdControl** を追加する方法を示す具体的な手順については、「[HTML 5 および Javascript の AdControl](adcontrol-in-html-5-and-javascript.md)」をご覧ください。 JavaScript/HTML アプリにバナー広告を追加する方法を示す完全なサンプル プロジェクトについては、「[GitHub の広告サンプル](http://aka.ms/githubads)」をご覧ください。

1.  default.html ファイルで、**AdControl** の **div** の **data-win-options** を定義する **onErrorOccurred** イベントの値を追加します。 default.html ファイルで次のコードを探します。
    ``` HTML
    <div id="myAd" style="position: absolute; top: 53px; left: 0px; width: 300px; height: 250px; z-index: 1"
      data-win-control="MicrosoftNSJS.Advertising.AdControl"
      data-win-options="{applicationId: '3f83fe91-d6be-434d-a0ae-7351c5a997f1', adUnitId: 'test'}">
    </div>
    ```
    **adUnitId** 属性の後に、**onErrorOccurred** イベントの値を追加します。
    ``` HTML
    <div id="myAd" style="position: absolute; top: 53px; left: 0px; width: 300px; height: 250px; z-index: 1"
      data-win-control="MicrosoftNSJS.Advertising.AdControl"
      data-win-options="{applicationId: '3f83fe91-d6be-434d-a0ae-7351c5a997f1', adUnitId: 'test', onErrorOccurred: errorLogger}">
  </div>
  ```

2.  テキストを表示する **div** を作成して、生成されたメッセージを確認できるようにします。 これを行うには、**myAd** の **div** の後に次のコードを追加します。
    ``` HTML
    <div style="position:absolute; width:100%; height:130px; top:300px; left:0px">
        <b>Ad Events</b><br />
        <div id="adEvents" style="width:100%; height:110px; overflow:auto"></div>
    </div>
    ```

3.  エラー イベントをトリガーする **AdControl** を作成します。 アプリ内のすべての **AdControl** オブジェクトには、アプリケーション ID が 1 つだけ存在できます。 そのため、異なるアプリケーション ID で追加のオブジェクトを作成すると、実行時にエラーがトリガーされます。 これを行うには、追加済みの前の **div** セクションの後に、default.html ページの本文に次のコードを追加します。
    ``` HTML
    <!-- Because only one applicationId can be used, the following ad control will fire an error event. -->
    <div id="liveAd" style="position: absolute; top:500px; left:0px; width:480px; height:80px"
      data-win-control="MicrosoftNSJS.Advertising.AdControl"
      data-win-options="{applicationId: '00000000-0000-0000-0000-000000000000', adUnitId: 'test', onErrorOccurred: errorLogger }" >
    </div>
    ```

4.  プロジェクトの default.js ファイルで、既定の初期化関数の後に **errorLogger** のイベント ハンドラーを追加します。 ファイルの最後までスクロールし、最後のセミコロンの後に次のコードを配置します。
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
