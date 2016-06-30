---
author: mcleanbyron
ms.assetid: 2fba38c4-11be-4058-bfa3-5f979390791c
description: "AdControl クラスのイベントを処理する方法について説明します。"
title: "C の AdControl イベント#"
translationtype: Human Translation
ms.sourcegitcommit: cf695b5c20378f7bbadafb5b98cdd3327bcb0be6
ms.openlocfilehash: cc5dfbfacefb4be32153f3266878be41a3b923f8

---

# C\ の AdControl イベント# #  


\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]

以下の例は、[AdControl](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.aspx) クラスのイベントを処理する方法を示しています。 これらの例では、既に XAML で **AdControl** イベントにイベント ハンドラーが割り当てられていることを前提としています。 この方法について詳しくは、「[XAML プロパティの例](xaml-properties-example.md)」をご覧ください。

C# でのイベントの処理について詳しくは、「[イベントとルーティング イベントの概要](http://msdn.microsoft.com/library/windows/apps/hh758286)」 (C#/VB/C++ と XAML を使ったユニバーサル Windows アプリ) をご覧ください。

## 例


``` syntax
private void OnAdError(object sender, AdErrorEventArgs e) {
  // place code here for when there is an error serving an ad
  // e.g. you may opt to show a default experience, or reclaim the div for other purposes
  return;
}

private void OnAdRefresh(object sender, RoutedEventArgs e) {
  // place code here that you wish to execute when the ad refreshes.
 return;
}

private void OnAdEngagedChanged(object sender, RoutedEventArgs e) {
  // place code here for when there is an error serving an ad
  // e.g. you may opt to show a default experience, or reclaim the div for other purposes
  return;
}
```

## 関連トピック

* [GitHub の広告サンプル](http://aka.ms/githubads)
* [AdControl エラーの処理](adcontrol-error-handling.md)
* [RoutedEventArgs Class (RoutedEventArgs クラス)](http://msdn.microsoft.com/en-us/library/system.windows.routedeventargs.aspx)

 

 



<!--HONumber=Jun16_HO4-->


