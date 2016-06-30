---
author: mcleanbyron
ms.assetid: 63A9EDCF-A418-476C-8677-D8770B45D1D7
description: "Microsoft Store Engagement and Monetization SDK は、アプリに広告を表示して収益を得るためのいくつかの方法を提供します。"
title: "アプリでの広告の表示"
translationtype: Human Translation
ms.sourcegitcommit: 8a5b02dbc40f3f0cd9be32aa7d5184e60a3b2707
ms.openlocfilehash: c79ba96908cc7b52afefbe44c3f56ce009c87f16

---

# アプリでの広告の表示


\[ Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください \]

[Microsoft Store Engagement and Monetization SDK](monetize-your-app-with-the-microsoft-store-engagement-and-monetization-sdk.md) は、アプリに広告を表示して収益を得るためのいくつかの方法を提供します。

## Microsoft Advertising ライブラリを使用したバナーおよびビデオのスポット広告の表示

バナーやビデオのスポット広告を組み込むと、Windows アプリでより多くの収益を得ることができます。 広告は、PC、タブレット、電話用の Windows アプリに表示されます。 Windows デベロッパー センター ダッシュボードを使って、広告のパフォーマンスをリアルタイムで監視できます。

アプリに広告を組み込むには、Microsoft Store Engagement and Monetization SDK で配布されている広告ライブラリの **AdControl** および **InterstitialAd** コントロールを使います。 これらのコントロールを使うことで、Windows 10、Windows 8.1、Windows Phone 8.1、Windows Phone 8 用の XAML または JavaScript/HTML アプリに Microsoft からのバナーやビデオのスポット広告を表示することができます。

詳しくは、「[Microsoft Advertising ライブラリを使用した広告の表示](display-ads-using-the-microsoft-advertising-libraries.md)」をご覧ください。 広告でアプリを公開した後は、[advertising performance report](../publish/advertising-performance-report.md) を使って広告のパフォーマンスを追跡します。                                           

## 複数の広告ネットワークからのバナー広告のための広告仲介の使用

XAML アプリで **AdMediatorControl** クラスを使うことで、複数の広告ネットワークからバナー広告を表示して広告の収益を最適化できます。 このコントロールをアプリに追加した後に、Windows デベロッパー センター ダッシュボードで広告仲介の設定を構成すると、選択した広告ネットワークからのバナー広告要求の仲介が行われます。 詳しくは、「[広告仲介を追加して広告収益を最大限に高める](use-ad-mediation-to-maximize-revenue.md)」をご覧ください。

## Microsoft Advertising ライブラリと広告仲介の相違点

Microsoft Store Engagement and Monetization SDK には、Microsoft Advertising と広告仲介のためのライブラリが含まれています。 ただし、これらのライブラリは異なるクラスを提供し、異なる目的のために使用されます。

* XAML または JavaScript アプリでバナーやビデオのスポット広告を表示する場合には、Microsoft Advertising ライブラリで **AdControl** および **InterstitialAd** のクラスを使います。
* XAML アプリで複数の広告ネットワークからのバナー広告を表示する場合には、広告仲介ライブラリの **AdMediatorControl** クラスを使います。

詳しくは、「[AdMediatorControl と AdControl の違い](what-is-the-difference-admediatorcontrol-or-adcontrol.md)」をご覧ください。

## 関連トピック

* [Microsoft Store Engagement and Monetization SDK](monetize-your-app-with-the-microsoft-store-engagement-and-monetization-sdk.md)
* [広告によるアプリの収益の獲得]( http://go.microsoft.com/fwlink/p/?LinkId=699559)



<!--HONumber=Jun16_HO4-->


