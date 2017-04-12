---
author: mcleanbyron
ms.assetid: d074e9d5-b3e0-4f16-b1e4-02b32ac99b2c
description: "**AdControl** のプロパティに値を割り当てる方法について説明します。"
title: "AdControl XAML プロパティの例"
ms.author: mcleans
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, 広告, 宣伝, AdControl, XAML, プロパティ"
ms.openlocfilehash: 3c5dae93ab6ee58fac7d4593257d357f268c241a
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="adcontrol-xaml-properties-example"></a>AdControl XAML プロパティの例

次の XAML の例は、[AdControl](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.aspx) のプロパティに値を割り当てる方法を示しています。 プロパティが設定されていない場合、**AdControl** は、アプリのユーザー エクスペリエンスと一貫性がある広告を作成する既定値を使います。

これらの値は例です。 実際のコードでは、これらの関数とプロパティの値を対象のアプリに適した値に設定します。

> [!div class="tabbedCodeSnippets"]
``` xml
<UI:AdControl Width="300",
    Height="250",
    AdUnitId="10865270",
    ApplicationId="3f83fe91-d6be-434d-a0ae-7351c5a997f1",
    IsAutoRefreshEnabled="false",
    AdRefreshed="OnAdRefresh",
    ErrorOcurred="OnAdError",
    IsEngagedChanged="OnAdEngagedChanged" />
```

## <a name="related-topics"></a>関連トピック

* [XAML および .NET の AdControl](adcontrol-in-xaml-and--net.md)
* [GitHub の広告サンプル](http://aka.ms/githubads)

 
