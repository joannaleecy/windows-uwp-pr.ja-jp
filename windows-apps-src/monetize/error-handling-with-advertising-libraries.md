---
author: mcleanbyron
ms.assetid: cb7380d0-bc14-4936-aa1c-206304b3dc70
description: "Microsoft Advertising ライブラリの AdControl クラスで生成されるエラーを処理する方法について説明します。"
title: "Microsoft Advertising ライブラリによるエラーの処理"
translationtype: Human Translation
ms.sourcegitcommit: 5bf07d3001e92ed16931be516fe059ad33c08bb9
ms.openlocfilehash: dedac33d86f50b63de300f78a9f9961efc1c016b

---

# Microsoft Advertising ライブラリによるエラーの処理




このトピックでは、Microsoft Advertising ライブラリで [AdControl](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.aspx) クラスによって生成されたエラーを処理する方法についての基本的な情報を説明します。

<span id="bkmk-javascript"/>
## JavaScript/HTML アプリ

JavaScript アプリで **AdControl** を処理するには:

1.  **onErrorOccurred** イベントをイベント ハンドラーに割り当てます。

2.  イベント ハンドラーのコードを記述します。

**AdControl** の **div** の **data-win-options** 属性で **onErrorOccurred** イベント ハンドラーが設定されます。 次の例では、**onErrorOccurred** イベントが **errorLogger** という名前の関数で処理されるために設定されます。

``` syntax
<div id="myAd" style="position: absolute; top: 53px; left: 0px; width: 250px; height: 250px; z-index: 1"
     data-win-control="MicrosoftNSJS.Advertising.AdControl"
     data-win-options="{applicationId: 'd25517cb-12d4-4699-8bdc-52040c712cab', adUnitId: 'ADPT33', onErrorOccurred: errorLogger}">
</div>
```

エラー処理関数は宣言型で、[markSupportedForProcessing](http://msdn.microsoft.com/library/windows/apps/Hh967819.aspx) 関数内で囲む必要があります。

**AdControl** エラーが発生すると、エラー ハンドラーが JavaScript エラー オブジェクトをキャッチします。 エラー オブジェクトは 2 つの引数をエラー ハンドラーに提供します。 詳しくは、「[非同期 Windows ランタイム メソッドからの特殊なエラー プロパティ](http://msdn.microsoft.com/library/windows/apps/hh994690.aspx)」をご覧ください。

**onErrorOccurred** イベントを処理する **errorLogger** という名前のエラー処理関数の例を示します。

``` syntax
WinJS.Utilities.markSupportedForProcessing(
window.errorLogger = function (sender, evt) {
    console.log(new Date()).toLocaleTimeString() + ": " + sender.element.id + " error: " + evt.errorMessage + " error code: " + evt.errorCode + \n");
});
```

JavaScript での **AdControl** エラー処理について説明するチュートリアルについては、「[JavaScript チュートリアルでのエラー処理](error-handling-in-javascript-walkthrough.md)」をご覧ください。

<span id="bkmk-dotnet"/>
## XAML アプリ

XAML アプリで **AdControl** エラーを処理するには:

* **ErrorOccurred** イベントをイベント ハンドラー デリゲートの名前に割り当てます。

* 送信元の **Object** と **AdErrorEventArgs** オブジェクトの、2 つのパラメーターを受け取るようにエラー イベント処理デリゲートのコードを記述します。

**OnAdError** という名前のデリゲートを **ErrorOccurred** イベントに割り当てる例を次に示します。

``` syntax
this.ErrorOccurred = OnAdError;
```

Visual Studio の出力ウィンドウにエラー情報を書き込む **OnAdError** デリゲートの定義例を次に示します。

``` syntax
private void OnAdError(object sender, AdErrorEventArgs e)
{
    System.Diagnostics.Debug.WriteLine("AdControl error (" + ((AdControl)sender).Name + "): " + e.Error + " ErrorCode: " + e.ErrorCode.ToString());
}
```

XAML および C# での **AdControl** エラー処理について説明するチュートリアルについては、「[XAML/C# チュートリアルでのエラー処理](error-handling-in-xamlc-walkthrough.md)」をご覧ください。

 

 



<!--HONumber=Aug16_HO3-->


