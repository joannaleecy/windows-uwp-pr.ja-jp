---
author: mcleanbyron
ms.assetid: d074e9d5-b3e0-4f16-b1e4-02b32ac99b2c
description: 値に **AdControl** プロパティを割り当てる方法について説明します。
title: XAML プロパティの例

---

# XAML プロパティの例


\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]

次の XAML の例では、値に [AdControl](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.aspx) プロパティを割り当てる方法を示しています。 プロパティが設定されていない場合、**AdControl** は、アプリのユーザー エクスペリエンスと一貫性がある広告を作成する既定値を使います。

これらの値は例です。 実際のコードでは、これらの関数とプロパティの値を対象のアプリに適した値に設定します。

``` syntax
Width="300",
Height="250",
AdUnitId="10865270",
ApplicationId="3f83fe91-d6be-434d-a0ae-7351c5a997f1",
IsAutoRefreshEnabled="false",
AdRefreshed="OnAdRefresh",
ErrorOcurred="OnAdError",
IsEngagedChanged="OnAdEngagedChanged"
```

## 関連トピック

* [GitHub の広告サンプル](http://aka.ms/githubads)

 


<!--HONumber=May16_HO2-->


