---
author: mcleanbyron
ms.assetid: 2383296e-c3d7-4b49-bcd2-621391228fdb
description: "AdControl クラスのイベントを処理する方法について説明します。"
title: "JavaScript の AdControl イベント"
ms.author: mcleans
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10、UWP、広告、宣伝、AdControl、イベント、javascript"
ms.openlocfilehash: 62363ebce006f8ad21645d907c3e63360472887d
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="adcontrol-events-in-javascript"></a>JavaScript の AdControl イベント

次の例は、[AdControl](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.aspx) イベントである [ErrorOccurred](https://msdn.microsoft.com/library/windows/apps/xaml/microsoft.advertising.winrt.ui.adcontrol.erroroccurred.aspx)、[AdRefreshed](https://msdn.microsoft.com/library/windows/apps/xaml/microsoft.advertising.winrt.ui.adcontrol.adrefreshed.aspx)、および [IsEngagedChanged](https://msdn.microsoft.com/library/windows/apps/xaml/microsoft.advertising.winrt.ui.adcontrol.isengagedchanged.aspx) 用の基本的なイベント ハンドラーを示しています。 これらの例では、既に HTML マークアップのイベントにイベント ハンドラーが割り当てられていることを前提としています。 この方法について詳しくは、「[HTML プロパティの例](html-properties-example.md)」をご覧ください。

JavaScript では、**AdControl** イベントを [MarkSupportedForProcessing](http://msdn.microsoft.com/library/windows/apps/Hh967819.aspx) 関数で囲む必要があります。 JavaScript でのイベントの処理について詳しくは、「[基本的なアプリのコーディング (HTML)](https://msdn.microsoft.com/library/windows/apps/hh780660.aspx#adding-event-handlers)」をご覧ください。

## <a name="examples"></a>例

> [!div class="tabbedCodeSnippets"]
[!code-javascript[AdControl](./code/AdvertisingSamples/AdControlSamples/js/main.js#EventHandlers)]

## <a name="related-topics"></a>関連トピック

* [GitHub の広告サンプル](http://aka.ms/githubads)
* [AdControl エラー処理](adcontrol-error-handling.md)
* [RoutedEventArgs Class (RoutedEventArgs クラス)](http://msdn.microsoft.com/library/system.windows.routedeventargs.aspx)

 

 
