---
author: mcleanbyron
ms.assetid: 2fba38c4-11be-4058-bfa3-5f979390791c
description: "AdControl クラスのイベントを処理する方法について説明します。"
title: "C の AdControl イベント#"
translationtype: Human Translation
ms.sourcegitcommit: f88a71491e185aec84a86248c44e1200a65ff179
ms.openlocfilehash: e25e0f915c0b9b6ec2423d2a95386b45b4502253

---

# <a name="adcontrol-events-in-c"></a>C\ の AdControl イベント# #  


次の例は、[AdControl](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.aspx) イベントである [ErrorOccurred](https://msdn.microsoft.com/library/windows/apps/xaml/microsoft.advertising.winrt.ui.adcontrol.erroroccurred.aspx)、[AdRefreshed](https://msdn.microsoft.com/library/windows/apps/xaml/microsoft.advertising.winrt.ui.adcontrol.adrefreshed.aspx)、および [IsEngagedChanged](https://msdn.microsoft.com/library/windows/apps/xaml/microsoft.advertising.winrt.ui.adcontrol.isengagedchanged.aspx) 用の基本的なイベント ハンドラーを示しています。 これらの例では、既に XAML コードのイベントにイベント ハンドラーが割り当てられていることを前提としています。 この方法について詳しくは、「[XAML プロパティの例](xaml-properties-example.md)」をご覧ください。

C# でのイベントの処理について詳しくは、「[イベントとルーティング イベントの概要](http://msdn.microsoft.com/library/windows/apps/hh758286)」(C#/VB/C++ と XAML を使ったユニバーサル Windows アプリ) をご覧ください。

## <a name="examples"></a>例

> [!div class="tabbedCodeSnippets"]
[!code-cs[AdControl](./code/AdvertisingSamples/AdControlSamples/cs/MainPage.xaml.cs#EventHandlers)]

## <a name="related-topics"></a>関連トピック

* [GitHub の広告サンプル](http://aka.ms/githubads)
* [AdControl エラー処理](adcontrol-error-handling.md)
* [RoutedEventArgs Class (RoutedEventArgs クラス)](http://msdn.microsoft.com/library/system.windows.routedeventargs.aspx)

 

 



<!--HONumber=Dec16_HO2-->


