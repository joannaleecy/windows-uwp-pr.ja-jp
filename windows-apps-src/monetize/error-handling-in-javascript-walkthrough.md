---
ms.assetid: 08b4ae43-69e8-4424-b3c0-a07c93d275c3
description: アプリで AdControl エラーをキャッチする方法について説明します。
title: JavaScript ウォークスルーでのエラー処理
ms.date: 05/11/2018
ms.topic: article
keywords: Windows 10, UWP, 広告, 宣伝, エラー処理, JavaScript
ms.localizationpriority: medium
ms.openlocfilehash: df33dc84823d5bcdc02d892820967b74ff0e5f65
ms.sourcegitcommit: bf600a1fb5f7799961914f638061986d55f6ab12
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 02/05/2019
ms.locfileid: "9049005"
---
# <a name="error-handling-in-javascript-walkthrough"></a><span data-ttu-id="e9715-104">JavaScript ウォークスルーでのエラー処理</span><span class="sxs-lookup"><span data-stu-id="e9715-104">Error handling in JavaScript walkthrough</span></span>

<span data-ttu-id="e9715-105">このチュートリアルでは、JavaScript アプリで広告関連のエラーをキャッチする方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="e9715-105">This walkthrough demonstrates how to catch ad-related errors in your JavaScript app.</span></span> <span data-ttu-id="e9715-106">このチュートリアルでは、[AdControl](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.adcontrol) を使用してバナー広告を表示していますが、その中の一般的な概念はスポット広告やネイティブ広告にも適用されます。</span><span class="sxs-lookup"><span data-stu-id="e9715-106">This walkthrough uses an [AdControl](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.adcontrol) to display a banner ad, but the general concepts in it also apply to interstitial ads and native ads.</span></span>

<span data-ttu-id="e9715-107">これらの例は、**AdControl** を含む JavaScript アプリがあることを前提としています。</span><span class="sxs-lookup"><span data-stu-id="e9715-107">These examples assume that you have a JavaScript app that contains an **AdControl**.</span></span> <span data-ttu-id="e9715-108">アプリに **AdControl** を追加する方法を示す具体的な手順については、「[HTML 5 および Javascript の AdControl](adcontrol-in-html-5-and-javascript.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e9715-108">For step-by-step instructions that demonstrate how to add an **AdControl** to your app, see [AdControl in HTML 5 and Javascript](adcontrol-in-html-5-and-javascript.md).</span></span> <span data-ttu-id="e9715-109">JavaScript/HTML アプリにバナー広告を追加する方法を示す完全なサンプル プロジェクトについては、「[GitHub の広告サンプル](https://aka.ms/githubads)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e9715-109">For a complete sample project that demonstrates how to add banner ads to a JavaScript/HTML app, see the [advertising samples on GitHub](https://aka.ms/githubads).</span></span>

1.  <span data-ttu-id="e9715-110">default.html ファイルで、**AdControl** の **div** の **data-win-options** を定義する **onErrorOccurred** イベントの値を追加します。</span><span class="sxs-lookup"><span data-stu-id="e9715-110">In the default.html file, add a value for the **onErrorOccurred** event where you define the **data-win-options** in the **div** for the **AdControl**.</span></span> <span data-ttu-id="e9715-111">default.html ファイルで次のコードを探します。</span><span class="sxs-lookup"><span data-stu-id="e9715-111">Find the following code in the default.html file.</span></span>
    ``` HTML
    <div id="myAd" style="position: absolute; top: 53px; left: 0px; width: 300px; height: 250px; z-index: 1"
      data-win-control="MicrosoftNSJS.Advertising.AdControl"
      data-win-options="{applicationId: '3f83fe91-d6be-434d-a0ae-7351c5a997f1', adUnitId: 'test'}">
    </div>
    ```
    <span data-ttu-id="e9715-112">**adUnitId** 属性の後に、**onErrorOccurred** イベントの値を追加します。</span><span class="sxs-lookup"><span data-stu-id="e9715-112">Following the **adUnitId** attribute, add the value for the **onErrorOccurred** event.</span></span>
    ``` HTML
    <div id="myAd" style="position: absolute; top: 53px; left: 0px; width: 300px; height: 250px; z-index: 1"
      data-win-control="MicrosoftNSJS.Advertising.AdControl"
      data-win-options="{applicationId: '3f83fe91-d6be-434d-a0ae-7351c5a997f1', adUnitId: 'test', onErrorOccurred: errorLogger}">
  </div>
  ```

2.  <span data-ttu-id="e9715-113">テキストを表示する **div** を作成して、生成されたメッセージを確認できるようにします。</span><span class="sxs-lookup"><span data-stu-id="e9715-113">Create a **div** that will display text so you can see the messages being generated.</span></span> <span data-ttu-id="e9715-114">これを行うには、**myAd** の **div** の後に次のコードを追加します。</span><span class="sxs-lookup"><span data-stu-id="e9715-114">To do this, add the following code after the **div** for **myAd**.</span></span>
    ``` HTML
    <div style="position:absolute; width:100%; height:130px; top:300px; left:0px">
        <b>Ad Events</b><br />
        <div id="adEvents" style="width:100%; height:110px; overflow:auto"></div>
    </div>
    ```

3.  <span data-ttu-id="e9715-115">エラー イベントをトリガーする **AdControl** を作成します。</span><span class="sxs-lookup"><span data-stu-id="e9715-115">Create an **AdControl** that will trigger an error event.</span></span> <span data-ttu-id="e9715-116">アプリ内のすべての **AdControl** オブジェクトには、アプリケーション ID が 1 つだけ存在できます。</span><span class="sxs-lookup"><span data-stu-id="e9715-116">There can only be one application id for all **AdControl** objects in an app.</span></span> <span data-ttu-id="e9715-117">そのため、異なるアプリケーション ID で追加のオブジェクトを作成すると、実行時にエラーがトリガーされます。</span><span class="sxs-lookup"><span data-stu-id="e9715-117">So creating an additional one with a different application id will trigger an error at runtime.</span></span> <span data-ttu-id="e9715-118">これを行うには、追加済みの前の **div** セクションの後に、default.html ページの本文に次のコードを追加します。</span><span class="sxs-lookup"><span data-stu-id="e9715-118">To do this, after the previous **div** sections you have added, add the following code to the body of the default.html page.</span></span>
    ``` HTML
    <!-- Because only one applicationId can be used, the following ad control will fire an error event. -->
    <div id="liveAd" style="position: absolute; top:500px; left:0px; width:480px; height:80px"
      data-win-control="MicrosoftNSJS.Advertising.AdControl"
      data-win-options="{applicationId: '00000000-0000-0000-0000-000000000000', adUnitId: 'test', onErrorOccurred: errorLogger }" >
    </div>
    ```

4.  <span data-ttu-id="e9715-119">プロジェクトの default.js ファイルで、既定の初期化関数の後に **errorLogger** のイベント ハンドラーを追加します。</span><span class="sxs-lookup"><span data-stu-id="e9715-119">In the project’s default.js file, after the default initialization function, you will add the event handler for **errorLogger**.</span></span> <span data-ttu-id="e9715-120">ファイルの最後までスクロールし、最後のセミコロンの後に次のコードを配置します。</span><span class="sxs-lookup"><span data-stu-id="e9715-120">Scroll to the end of the file and after the last semi-colon is where you will put the following code.</span></span>
    ``` javascript
    WinJS.Utilities.markSupportedForProcessing(
    window.errorLogger = function (sender, evt) {
        adEvents.innerHTML = (new Date()).toLocaleTimeString() + ": " +
        sender.element.id + " error: " + evt.errorMessage + " error code: " +
        evt.errorCode + "<br>" + adEvents.innerHTML;
        console.log("errorhandler hit. \n");
    });
    ```

5.  <span data-ttu-id="e9715-121">ファイルをビルドして実行します。</span><span class="sxs-lookup"><span data-stu-id="e9715-121">Build and run the file.</span></span> <span data-ttu-id="e9715-122">前にビルドしたサンプル アプリの元の広告が表示され、その広告の下にエラーを説明するテキストが表示されます。</span><span class="sxs-lookup"><span data-stu-id="e9715-122">You will see the original ad from the sample app you built previously and text under that ad describing the error.</span></span> <span data-ttu-id="e9715-123">**liveAd** の ID を持つ広告は表示されません。</span><span class="sxs-lookup"><span data-stu-id="e9715-123">You will not see the ad with the id of **liveAd**.</span></span>

## <a name="related-topics"></a><span data-ttu-id="e9715-124">関連トピック</span><span class="sxs-lookup"><span data-stu-id="e9715-124">Related topics</span></span>

* [<span data-ttu-id="e9715-125">GitHub の広告サンプル</span><span class="sxs-lookup"><span data-stu-id="e9715-125">Advertising samples on GitHub</span></span>](https://aka.ms/githubads)
