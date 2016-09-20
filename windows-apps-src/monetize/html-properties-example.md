---
author: mcleanbyron
ms.assetid: 5fa16a27-fdc0-43b2-84cd-8547fd4915de
description: "HTML の **AdControl** プロパティを割り当てる方法について説明します。"
title: "HTML プロパティの例"
ms.sourcegitcommit: cf695b5c20378f7bbadafb5b98cdd3327bcb0be6
ms.openlocfilehash: 53b9afdcdc697e3ed508ef6e5ed5d684bdf5aa69


---

# HTML プロパティの例


\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]

次の例は、HTML の [AdControl](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.aspx) プロパティを割り当てる方法を示しています。 **applicationId** と **adUnitId** は必須のプロパティです。 その他のプロパティとイベントは省略できます。 省略可能なプロパティの値を指定しなかった場合、アプリのユーザー エクスペリエンスに一致した広告を作成する既定値がコントロールによって使われます。

最後の 5 行は、**AdControl** イベントに関数を登録した例です。 JavaScript コードで定義した関数のみ登録できます。

これらの値は例です。 実際のコードでは、これらの関数とプロパティの値を対象のアプリに適した値に設定します。

``` syntax
data-win-control="MicrosoftNSJS.Advertising.AdControl"
data-win-options="{applicationId: '3f83fe91-d6be-434d-a0ae-7351c5a997f1',
                    adUnitId: '10865270',
                    isAutoRefreshEnabled: false,
                    onAdRefreshed: myAdRefreshed,
                    onErrorOccurred: myAdError,
                    onEngagedChanged: myAdEngagedChanged,
                    onPointerDown: myPointerDown,
                    onPointerUp: myPointerUp }"
```

## 関連トピック

* [GitHub の広告サンプル](http://aka.ms/githubads)

 



<!--HONumber=Jun16_HO4-->


