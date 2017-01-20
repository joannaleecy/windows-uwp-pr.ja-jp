---
author: mcleanbyron
ms.assetid: 5fa16a27-fdc0-43b2-84cd-8547fd4915de
description: "HTML の **AdControl** プロパティを割り当てる方法について説明します。"
title: "AdControl HTML プロパティの例"
translationtype: Human Translation
ms.sourcegitcommit: f88a71491e185aec84a86248c44e1200a65ff179
ms.openlocfilehash: 741cf19ee0310c84d1a85f4a1e82b353d88d1b9e

---

# <a name="adcontrol-html-properties-example"></a>AdControl HTML プロパティの例

次の例は、HTML の [AdControl](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.aspx) プロパティを割り当てる方法を示しています。 **applicationId** と **adUnitId** は必須のプロパティです。 その他のプロパティとイベントは省略できます。 省略可能なプロパティの値を指定しなかった場合、アプリのユーザー エクスペリエンスに一致した広告を作成する既定値がコントロールによって使われます。

最後の 5 行は、**AdControl** イベントに関数を登録した例です。 JavaScript コードで定義した関数のみ登録できます。

これらの値は例です。 実際のコードでは、これらの関数とプロパティの値を対象のアプリに適した値に設定します。

> [!div class="tabbedCodeSnippets"]
``` html
<div id="myAd" style="position: absolute; top: 50px; left: 0px; width: 300px; height: 250px; z-index: 1"
    data-win-control="MicrosoftNSJS.Advertising.AdControl"
    data-win-options="{applicationId: '3f83fe91-d6be-434d-a0ae-7351c5a997f1',
                       adUnitId: '10865270',
                       isAutoRefreshEnabled: false,
                       onAdRefreshed: myAdRefreshed,
                       onErrorOccurred: myAdError,
                       onEngagedChanged: myAdEngagedChanged,
                       onPointerDown: myPointerDown,
                       onPointerUp: myPointerUp }" />
```

## <a name="related-topics"></a>関連トピック

* [HTML 5 および JavaScript の AdControl](adcontrol-in-html-5-and-javascript.md)
* [GitHub の広告サンプル](http://aka.ms/githubads)

 



<!--HONumber=Dec16_HO2-->


