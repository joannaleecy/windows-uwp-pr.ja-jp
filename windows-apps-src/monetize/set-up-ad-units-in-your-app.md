---
author: mcleanbyron
ms.assetid: bb105fbe-bbbd-4d78-899b-345af2757720
description: "アプリをストアに提出する前に、Windows デベロッパー センター ダッシュ ボードからアプリケーション ID と広告ユニット ID の値をアプリに追加する方法について説明します。"
title: "アプリの広告ユニットをセットアップする"
ms.author: mcleans
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, 広告, Advertising, 広告ユニット"
ms.openlocfilehash: daf0887462a4c84aa827a6261793a0eaf4d512ca
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="set-up-ad-units-in-your-app"></a>アプリの広告ユニットをセットアップする




[AdControl](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.aspx) または [InterstitialAd](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.interstitialad.aspx) を使ってアプリで広告を表示する場合、アプリケーション ID と広告ユニット ID を指定する必要があります。 アプリを開発しているときには、適切な[テスト用のアプリケーション ID と広告ユニット ID の値](test-mode-values.md)を使って、テスト時にアプリでどのように広告がレンダリングされるかを確認します。

アプリのテストが終了し、Windows デベロッパー センターに提出する準備ができたら、[Windows デベロッパー センター ダッシュ ボード](https://msdn.microsoft.com/library/windows/apps/mt170658.aspx)から取得したアプリケーション ID と広告ユニット ID の値を使用するように、アプリのコードを更新する必要があります。 ライブ アプリでテスト用の値を使うと、アプリでライブ広告は表示されません。

ライブ アプリのアプリケーション ID と広告ユニットをセットアップするには

1.  Windows デベロッパー センター ダッシュボードで、アプリを選択し、**[収益化]、[広告で収入を増やす]** の順にクリックします。

2.  このページの **[Microsoft Advertising 広告ユニット]** セクションで広告ユニットを作成します。 広告ユニットの種類は、状況に応じて次のオプションを選択します。

  * アプリで **AdControl** を使用してバナー広告を表示している場合は、広告ユニットの種類として **[バナー]** を選択します。

  * アプリで **InterstitialAd** を使用してビデオ スポット広告やバナー スポット広告を表示している場合は、**[ビデオ (スポット)]** または **[バナー (スポット)]** を選択します (表示するスポット広告の種類に対応した適切なオプションを必ず選択してください)。

3.  生成された広告ユニットごとに、**アプリケーション ID** と**広告ユニット ID** がこのページに表示されます。 アプリに広告を表示するには、アプリのコードでこれらの値を使用する必要があります。

  * アプリにバナー広告を表示する場合は、これらの値を **AdControl** オブジェクトの [ApplicationId](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.applicationid.aspx) プロパティと [AdUnitId](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.adunitid.aspx) プロパティに割り当てる必要があります。 詳しくは、「[XAML および .NET の AdControl](adcontrol-in-xaml-and--net.md)」、または「[HTML 5 および Javascript の AdControl](adcontrol-in-html-5-and-javascript.md)」をご覧ください。

  * アプリでスポット広告を表示する場合は、**InterstitialAd** オブジェクトの [RequestAd](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.interstitialad.requestad.aspx) メソッドにこれらの値を渡します。 詳しくは、「[スポット広告](interstitial-ads.md)」をご覧ください。

**[広告で収入を増やす]** ページについて詳しくは、「[広告による収益獲得](../publish/monetize-with-ads.md)」をご覧ください。

## <a name="related-topics"></a>関連トピック

* [テスト モードの値](test-mode-values.md)
* [XAML および .NET の AdControl](adcontrol-in-xaml-and--net.md)
* [HTML 5 および Javascript の AdControl](adcontrol-in-html-5-and-javascript.md)
* [スポット広告](interstitial-ads.md)


 

 
