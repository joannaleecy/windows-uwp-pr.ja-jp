---
author: Xansky
ms.assetid: cb7380d0-bc14-4936-aa1c-206304b3dc70
description: Microsoft Advertising ライブラリの AdControl クラスによって生成されたエラーを処理する方法について説明します。
title: 広告のエラー処理
ms.author: mhopkins
ms.date: 05/11/2018
ms.topic: article
keywords: Windows 10, UWP, 広告, 宣伝, エラー処理, JavaScript, XAML, C#
ms.localizationpriority: medium
ms.openlocfilehash: a9fa05ed2ee946fcec9ffb5ff21abd9011db0f2a
ms.sourcegitcommit: 93c0a60cf531c7d9fe7b00e7cf78df86906f9d6e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/21/2018
ms.locfileid: "7577378"
---
# <a name="handle-ad-errors"></a><span data-ttu-id="8cbdd-104">広告のエラー処理</span><span class="sxs-lookup"><span data-stu-id="8cbdd-104">Handle ad errors</span></span>

<span data-ttu-id="8cbdd-105">[AdControl](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.adcontrol)、[InterstitialAd](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.interstitialad)、[NativeAdsManagerV2](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.nativeadsmanagerv2) の各クラスには、広告関連のエラーが発生した場合に発生する **ErrorOccurred** イベントがあります。</span><span class="sxs-lookup"><span data-stu-id="8cbdd-105">The [AdControl](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.adcontrol),  [InterstitialAd](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.interstitialad), and [NativeAdsManagerV2](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.nativeadsmanagerv2) classes each have an **ErrorOccurred** event that is raised if an ad-related error occurs.</span></span> <span data-ttu-id="8cbdd-106">アプリ コードでこのイベントを処理し、イベント引数オブジェクトの [ErrorCode](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.aderroreventargs.errorcode) プロパティと [ErrorMessage](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.aderroreventargs.errormessage) プロパティを調べて、エラーの原因を特定することができます。</span><span class="sxs-lookup"><span data-stu-id="8cbdd-106">Your app code can handle this event and examine the [ErrorCode](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.aderroreventargs.errorcode) and [ErrorMessage](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.aderroreventargs.errormessage) properties of the event args object to help determine the cause of the error.</span></span>

<span id="bkmk-dotnet"/>

## <a name="xaml-apps"></a><span data-ttu-id="8cbdd-107">XAML アプリ</span><span class="sxs-lookup"><span data-stu-id="8cbdd-107">XAML apps</span></span>

<span data-ttu-id="8cbdd-108">XAML アプリで広告関連のエラーを処理するには:</span><span class="sxs-lookup"><span data-stu-id="8cbdd-108">To handle ad-related errors in a XAML app:</span></span>

1. <span data-ttu-id="8cbdd-109">**AdControl**、**InterstitialAd**、**NativeAdsManagerV2** オブジェクトの **ErrorOccurred** イベントを、イベント ハンドラー デリゲートの名前に割り当てます。</span><span class="sxs-lookup"><span data-stu-id="8cbdd-109">Assign the **ErrorOccurred** event of your **AdControl**, **InterstitialAd**, or **NativeAdsManagerV2** object to the name of an event handler delegate.</span></span>

2. <span data-ttu-id="8cbdd-110">送信元の **Object** と [AdErrorEventArgs](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.aderroreventargs) オブジェクトの、2 つのパラメーターを受け取るようにエラー イベント処理デリゲートのコードを記述します。</span><span class="sxs-lookup"><span data-stu-id="8cbdd-110">Code the error event handling delegate so that it takes two parameters: an **Object** for the sender and an [AdErrorEventArgs](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.aderroreventargs) object.</span></span>

<span data-ttu-id="8cbdd-111">**OnAdError** という名前のデリゲートを *myBannerAdControl* という名前の **AdControl** オブジェクトの **ErrorOccurred** イベントに割り当てる例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="8cbdd-111">Here is an example that assigns a delegate named **OnAdError** to the **ErrorOccurred** event of an **AdControl** object named *myBannerAdControl*.</span></span>

> [!div class="tabbedCodeSnippets"]
``` csharp
myBannerAdControl.ErrorOccurred = OnAdError;
```

<span data-ttu-id="8cbdd-112">Visual Studio の出力ウィンドウにエラー情報を書き込む **OnAdError** デリゲートの定義例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="8cbdd-112">Here is an example definition of the **OnAdError** delegate that writes error information to the output window in Visual Studio.</span></span>

> [!div class="tabbedCodeSnippets"]
``` csharp
private void OnAdError(object sender, AdErrorEventArgs e)
{
    System.Diagnostics.Debug.WriteLine("AdControl error (" + ((AdControl)sender).Name + "): " + e.Error +
        " ErrorCode: " + e.ErrorCode.ToString());
}
```

<span data-ttu-id="8cbdd-113">XAML および C# での **AdControl** エラー処理について説明するチュートリアルについては、「[XAML/C# チュートリアルでのエラー処理](error-handling-in-xamlc-walkthrough.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8cbdd-113">See [Error handling in XAML/C# walkthrough](error-handling-in-xamlc-walkthrough.md) for a walkthrough that demonstrates **AdControl** error handling in XAML and C#.</span></span>

<span id="bkmk-javascript"/>

## <a name="javascripthtml-apps"></a><span data-ttu-id="8cbdd-114">JavaScript/HTML アプリ</span><span class="sxs-lookup"><span data-stu-id="8cbdd-114">JavaScript/HTML apps</span></span>

<span data-ttu-id="8cbdd-115">JavaScript アプリで **ErrorOccur** エラーを処理するには:</span><span class="sxs-lookup"><span data-stu-id="8cbdd-115">To handle **ErrorOccur** errors in a JavaScript app:</span></span>

1.  <span data-ttu-id="8cbdd-116">**onErrorOccurred** イベントをイベント ハンドラーに割り当てます。</span><span class="sxs-lookup"><span data-stu-id="8cbdd-116">Assign the **onErrorOccurred** event to an event handler.</span></span>

2.  <span data-ttu-id="8cbdd-117">イベント ハンドラーのコードを記述します。</span><span class="sxs-lookup"><span data-stu-id="8cbdd-117">Code the event handler.</span></span>

<span data-ttu-id="8cbdd-118">**errorLogger** という名前のイベント ハンドラーを **AdControl** オブジェクトの **ErrorOccurred** イベントに割り当てる例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="8cbdd-118">Here is an example that assigns an event handler named **errorLogger** to the **ErrorOccurred** event of an **AdControl** object.</span></span>

> [!div class="tabbedCodeSnippets"]
``` html
<div id="myAd" style="position: absolute; top: 53px; left: 0px; width: 250px; height: 250px; z-index: 1"
     data-win-control="MicrosoftNSJS.Advertising.AdControl"
     data-win-options="{applicationId: '3f83fe91-d6be-434d-a0ae-7351c5a997f1', adUnitId: 'test', onErrorOccurred: errorLogger}">
</div>
```

<span data-ttu-id="8cbdd-119">エラー処理関数は宣言型で、[markSupportedForProcessing](http://msdn.microsoft.com/library/windows/apps/Hh967819.aspx) 関数内で囲む必要があります。</span><span class="sxs-lookup"><span data-stu-id="8cbdd-119">The error handling function is declarative and must be enclosed in the [markSupportedForProcessing](http://msdn.microsoft.com/library/windows/apps/Hh967819.aspx) function.</span></span>

<span data-ttu-id="8cbdd-120">エラーが発生すると、エラー ハンドラーが JavaScript エラー オブジェクトをキャッチします。</span><span class="sxs-lookup"><span data-stu-id="8cbdd-120">The error handler catches the JavaScript error object when an error occurs.</span></span> <span data-ttu-id="8cbdd-121">エラー オブジェクトは 2 つの引数をエラー ハンドラーに提供します。</span><span class="sxs-lookup"><span data-stu-id="8cbdd-121">The error object provides two arguments to the error handler.</span></span> <span data-ttu-id="8cbdd-122">詳しくは、「[非同期 Windows ランタイム メソッドからの特殊なエラー プロパティ](http://msdn.microsoft.com/library/windows/apps/hh994690.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8cbdd-122">For more information, see [Special Error Properties from Asynchronous Windows Runtime Methods](http://msdn.microsoft.com/library/windows/apps/hh994690.aspx).</span></span>

<span data-ttu-id="8cbdd-123">**onErrorOccurred** イベントを処理する **errorLogger** という名前のエラー処理関数の例を示します。</span><span class="sxs-lookup"><span data-stu-id="8cbdd-123">Here is an example of an error handling function named **errorLogger** that handles the **onErrorOccurred** event.</span></span>

> [!div class="tabbedCodeSnippets"]
``` javascript
WinJS.Utilities.markSupportedForProcessing(
window.errorLogger = function (sender, evt) {
    console.log(new Date()).toLocaleTimeString() + ": " + sender.element.id + " error: " + evt.errorMessage +
    " error code: " + evt.errorCode + \n");
});
```

<span data-ttu-id="8cbdd-124">JavaScript での **AdControl** エラー処理について説明するチュートリアルについては、「[JavaScript チュートリアルでのエラー処理](error-handling-in-javascript-walkthrough.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8cbdd-124">See [Error Handling in JavaScript walkthrough](error-handling-in-javascript-walkthrough.md) for a walkthrough that demonstrates **AdControl** error handling in JavaScript.</span></span>
