---
author: mcleanbyron
ms.assetid: cb7380d0-bc14-4936-aa1c-206304b3dc70
description: "Microsoft Advertising ライブラリの AdControl クラスによって生成されたエラーを処理する方法について説明します。"
title: "Advertising ライブラリでのエラーの処理"
ms.author: mcleans
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, 広告, 宣伝, エラー処理, JavaScript, XAML, C#"
ms.openlocfilehash: 7c65f424341517072b06aaba30929f17303dcf1f
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="error-handling-with-the-advertising-libraries"></a>Advertising ライブラリでのエラーの処理

このトピックでは、Microsoft Advertising ライブラリの [AdControl](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.aspx) クラスによって生成されたエラーを処理する方法についての基本的な情報を説明します。

<span id="bkmk-javascript"/>
## <a name="javascripthtml-apps"></a>JavaScript/HTML アプリ

JavaScript アプリで **AdControl** を処理するには:

1.  **onErrorOccurred** イベントをイベント ハンドラーに割り当てます。

2.  イベント ハンドラーのコードを記述します。

**AdControl** の **div** の **data-win-options** 属性で **onErrorOccurred** イベント ハンドラーが設定されます。 次の例では、**onErrorOccurred** イベントが **errorLogger** という名前の関数で処理されるために設定されます。

> [!div class="tabbedCodeSnippets"]
``` html
<div id="myAd" style="position: absolute; top: 53px; left: 0px; width: 250px; height: 250px; z-index: 1"
     data-win-control="MicrosoftNSJS.Advertising.AdControl"
     data-win-options="{applicationId: 'd25517cb-12d4-4699-8bdc-52040c712cab', adUnitId: 'ADPT33', onErrorOccurred: errorLogger}">
</div>
```

エラー処理関数は宣言型で、[markSupportedForProcessing](http://msdn.microsoft.com/library/windows/apps/Hh967819.aspx) 関数内で囲む必要があります。

**AdControl** エラーが発生すると、エラー ハンドラーが JavaScript エラー オブジェクトをキャッチします。 エラー オブジェクトは 2 つの引数をエラー ハンドラーに提供します。 詳しくは、「[非同期 Windows ランタイム メソッドからの特殊なエラー プロパティ](http://msdn.microsoft.com/library/windows/apps/hh994690.aspx)」をご覧ください。

**onErrorOccurred** イベントを処理する **errorLogger** という名前のエラー処理関数の例を示します。

> [!div class="tabbedCodeSnippets"]
``` javascript
WinJS.Utilities.markSupportedForProcessing(
window.errorLogger = function (sender, evt) {
    console.log(new Date()).toLocaleTimeString() + ": " + sender.element.id + " error: " + evt.errorMessage +
    " error code: " + evt.errorCode + \n");
});
```

JavaScript での **AdControl** エラー処理について説明するチュートリアルについては、「[JavaScript チュートリアルでのエラー処理](error-handling-in-javascript-walkthrough.md)」をご覧ください。

<span id="bkmk-dotnet"/>
## <a name="xaml-apps"></a>XAML アプリ

XAML アプリで **AdControl** エラーを処理するには:

* **ErrorOccurred** イベントをイベント ハンドラー デリゲートの名前に割り当てます。

* 送信元の **Object** と **AdErrorEventArgs** オブジェクトの、2 つのパラメーターを受け取るようにエラー イベント処理デリゲートのコードを記述します。

**OnAdError** という名前のデリゲートを **ErrorOccurred** イベントに割り当てる例を次に示します。

> [!div class="tabbedCodeSnippets"]
``` csharp
this.ErrorOccurred = OnAdError;
```

Visual Studio の出力ウィンドウにエラー情報を書き込む **OnAdError** デリゲートの定義例を次に示します。

> [!div class="tabbedCodeSnippets"]
``` csharp
private void OnAdError(object sender, AdErrorEventArgs e)
{
    System.Diagnostics.Debug.WriteLine("AdControl error (" + ((AdControl)sender).Name + "): " + e.Error +
        " ErrorCode: " + e.ErrorCode.ToString());
}
```

XAML および C# での **AdControl** エラー処理について説明するチュートリアルについては、「[XAML/C# チュートリアルでのエラー処理](error-handling-in-xamlc-walkthrough.md)」をご覧ください。

 

 
