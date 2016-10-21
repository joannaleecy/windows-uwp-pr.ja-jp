---
author: mcleanbyron
ms.assetid: 2fba38c4-11be-4058-bfa3-5f979390791c
description: "AdControl クラスのイベントを処理する方法について説明します。"
title: "C の AdControl イベント#"
translationtype: Human Translation
ms.sourcegitcommit: 5bf07d3001e92ed16931be516fe059ad33c08bb9
ms.openlocfilehash: 969d668c89b40e37245a8168879842159b4f5c14

---

# C\ の AdControl イベント# #  




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
* [AdControl エラー処理](adcontrol-error-handling.md)
* [RoutedEventArgs Class (RoutedEventArgs クラス)](http://msdn.microsoft.com/library/system.windows.routedeventargs.aspx)

 

 



<!--HONumber=Aug16_HO3-->


