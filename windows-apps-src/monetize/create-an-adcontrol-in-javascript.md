---
author: mcleanbyron
ms.assetid: 48a1ef86-8514-4af8-9c93-81e869d36de7
description: JavaScript を使ってプログラムで **AdControl** を作成する方法について説明します。
title: JavaScript での AdControl の作成

---

# JavaScript での AdControl の作成


\[ Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\ ]

この例では、JavaScript を使ってプログラムで [AdControl](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.aspx) を作成する方法について説明します。

## AdControl 用の HTML の div

**AdControl** で広告を表示するには、対象の html ページに **div** を含める必要があります。 この **div** のコード例を次に示します。

``` syntax
<div id="myAd" style="position: absolute; top: 50px; left: 0px; width: 300px; height: 250px; z-index: 1"
    data-win-control="MicrosoftNSJS.Advertising.AdControl">
</div>
```

## AdControl を作成するための JavaScript

次の例では、HTML に **div** が既にあることを前提にしています。ID は **myAd** です。

**AdControl** を **app.onactivated** 関数でインスタンス化します。

``` syntax
// TODO: This application has been newly launched. Initialize
// your application here.
var adDiv = document.getElementById("myAd");
var myAdControl = new MicrosoftNSJS.Advertising.AdControl(adDiv,
    {
        applicationId: "3f83fe91-d6be-434d-a0ae-7351c5a997f1",
        adUnitId: "10865270"
    });
myAdControl.isAutoRefreshEnabled = false;
myAdControl.onErrorOccurred = myAdError;
myAdControl.onAdRefreshed = myAdRefreshed;
myAdControl.onEngagedChanged = myAdEngagedChanged;
```

これらの値は例です。 実際のコードでは、これらの関数とプロパティの値を対象のアプリに適した値に設定します。

このコードで広告が表示されない場合は、**AdControl** を含む **div** に **position:relative** の属性を挿入してみてください。 これにより、**IFrame** の既定の設定が上書きされます。 この属性の値が原因でなければ、広告が正しく表示されるようになります。 新しい広告ユニットが利用可能になるまでに最大で 30 分かかる場合があることに注意してください。

## 関連トピック

* [GitHub の広告サンプル](http://aka.ms/githubads)

 

 


<!--HONumber=May16_HO2-->


