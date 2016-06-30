---
author: mcleanbyron
ms.assetid: 2383296e-c3d7-4b49-bcd2-621391228fdb
description: "AdControl クラスのイベントを処理する方法について説明します。"
title: "JavaScript の AdControl イベント"
translationtype: Human Translation
ms.sourcegitcommit: cf695b5c20378f7bbadafb5b98cdd3327bcb0be6
ms.openlocfilehash: 5a47915b0dd2792ed50cc5d556b1181ee2c259e1


---

# JavaScript の AdControl イベント


\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]

以下の例は、[AdControl](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.aspx) クラスのイベントを処理する方法を示しています。 これらの例では、既に **AdControl** イベントにイベント ハンドラーが割り当てられていることを前提としています。 この方法について詳しくは、「[HTML プロパティの例](html-properties-example.md)」をご覧ください。

JavaScript では、**AdControl** イベントを [MarkSupportedForProcessing](http://msdn.microsoft.com/en-us/library/windows/apps/Hh967819.aspx) 関数で囲む必要があります。 JavaScript でのイベントの処理について詳しくは、「[基本的なアプリのコーディング (HTML)](https://msdn.microsoft.com/en-us/library/windows/apps/hh780660.aspx#adding-event-handlers)」をご覧ください。

## 例

``` syntax
WinJS.Utilities.markSupportedForProcessing(
window.myAdError = function (sender, msg) {
  // place code here for when there is an error serving an ad.
  // e.g. you may opt to show a default experience, or reclaim the div for other purposes.
});

WinJS.Utilities.markSupportedForProcessing(
window.myAdRefreshed = function (sender) {
  // place code here that you wish to execute when the ad refreshes.
});

WinJS.Utilities.markSupportedForProcessing(
window.myAdEngagedChanged = function (sender) {
  if (true == sender.isEngaged) {
    // code here for when user engaged with ad, e.g. if a game, pause it.
  }
  else {
    // user no longer engaged with ad, include code to unpause.
  }
});
```

## 関連トピック

* [GitHub の広告サンプル](http://aka.ms/githubads)
* [AdControl エラーの処理](adcontrol-error-handling.md)
* [RoutedEventArgs Class (RoutedEventArgs クラス)](http://msdn.microsoft.com/en-us/library/system.windows.routedeventargs.aspx)

 

 



<!--HONumber=Jun16_HO4-->


