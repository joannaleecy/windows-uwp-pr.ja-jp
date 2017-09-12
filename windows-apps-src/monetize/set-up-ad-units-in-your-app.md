---
author: mcleanbyron
ms.assetid: bb105fbe-bbbd-4d78-899b-345af2757720
description: "アプリをストアに提出する前に、Windows デベロッパー センター ダッシュ ボードからアプリケーション ID と広告ユニット ID の値をアプリに追加する方法について説明します。"
title: "アプリの広告ユニットをセットアップする"
ms.author: mcleans
ms.date: 06/26/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, 広告, Advertising, 広告ユニット"
ms.openlocfilehash: f96e81079764682a9f603fe93a9c123a69690507
ms.sourcegitcommit: 8c4d50ef819ed1a2f8cac4eebefb5ccdaf3fa898
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 06/27/2017
---
# <a name="set-up-ad-units-in-your-app"></a>アプリの広告ユニットをセットアップする

アプリ内の各バナー広告コントロール、スポット広告コントロール、ネイティブ広告コントロールに、対応する*広告ユニット*があります。広告ユニットは、コントロールに広告を提供するためにサービスで使用されます。 各広告ユニットは、*広告ユニット ID* と*アプリケーション ID* で構成されます。 アプリを開発しているときには、[アプリケーション ID と広告ユニット ID のテスト値](test-mode-values.md)をコントロールに割り当てて、アプリでテスト広告が表示されることを確認します。 これらのテスト値は、テスト バージョンのアプリでのみ使用できます。

アプリのテストが終了し、Windows デベロッパー センターに提出する準備ができたら、Windows デベロッパー センター ダッシュボードの [[広告で収入を増やす]](../publish/monetize-with-ads.md) ページから取得したアプリケーション ID と広告ユニット ID の値を使うためにアプリのコードを更新する必要があります。 ライブ アプリでテスト用の値を使うと、アプリでライブ広告は表示されません。

ライブ アプリの広告ユニットをセットアップするには

1.  Windows デベロッパー センター ダッシュボードで、アプリを選択し、**[収益化]、[広告で収入を増やす]** の順にクリックします。

2.  **[広告ユニットを作成]** セクションで、**[広告ユニット名]** フィールドに広告ユニットの名前を入力します。

3. **[広告ユニットの種類]** ドロップダウンで、コントロールに表示する広告に対応する広告ユニットの種類を選択します。

    -   アプリで [AdControl](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.aspx) を使ってバナー広告を表示している場合は、**[バナー]** を選択します。

    -   アプリで [InterstitialAd](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.interstitialad.aspx) を使ってビデオ スポット広告やバナー スポット広告を表示している場合は、**[ビデオ (スポット)]** または **[バナー (スポット)]** を選択します (表示するスポット広告の種類に対応した適切なオプションを必ず選択してください)。

    -   アプリで [NativeAd](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.nativead.aspx) を使ってネイティブ広告を表示している場合は、**[ネイティブ]** を選択します。
      > [!NOTE]
      > **ネイティブ**広告ユニットを作成する機能は、現在はパイロット プログラムに参加している開発者だけが利用できますが、まもなくすべての開発者がこの機能を利用できるようにする予定です。 パイロット プログラムへの参加に関心がある方は、aiacare@microsoft.com までお問い合わせください。

4.  **[デバイス ファミリ]** ドロップダウンで、広告ユニットを使うアプリがターゲットとしているデバイス ファミリを選択します。 選択できるオプションには、**[UWP (Windows 10)]**、**[PC/タブレット (Windows 8.1)]**、**[モバイル (Windows Phone 8.x)]** があります。

5.  **[広告ユニットを作成]** をクリックします。 このページの **[利用可能な広告ユニット]** セクションの上部にある一覧に、新しい広告ユニットが表示されます。

6.  生成された広告ユニットごとに**アプリケーション ID** と**広告ユニット ID** が表示されます。 アプリに広告を表示するには、アプリのコードでこれらの値を使用する必要があります。

    -   アプリにバナー広告を表示する場合は、これらの値を **AdControl** オブジェクトの [ApplicationId](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.applicationid.aspx) プロパティと [AdUnitId](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.adunitid.aspx) プロパティに割り当てる必要があります。 詳しくは、「[XAML および .NET の AdControl](adcontrol-in-xaml-and--net.md)」、または「[HTML 5 および Javascript の AdControl](adcontrol-in-html-5-and-javascript.md)」をご覧ください。

    -   アプリでスポット広告を表示する場合は、**InterstitialAd** オブジェクトの [RequestAd](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.interstitialad.requestad.aspx) メソッドにこれらの値を渡します。 詳しくは、「[スポット広告](interstitial-ads.md)」をご覧ください。

    -   アプリにネイティブ広告が表示される場合、それらの値を [NativeAdsManager](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.nativeadsmanager.nativeadsmanager.aspx) コンストラクターの *applicationId* パラメーターと *adUnitId* パラメーターに渡します。 詳しくは、「[ネイティブ広告](../monetize/native-ads.md)」をご覧ください。

7. アプリが Windows 10 用 UWP アプリである場合、[[広告仲介]](../publish/monetize-with-ads.md#mediation) セクションで設定を構成することにより、必要に応じて **AdControl** の広告仲介を有効にできます。 広告仲介を使うと、複数の広告ネットワークから広告を表示して、広告収益とアプリ プロモーションの機能を最大限に引き出すことができます。表示される広告には、Taboola や Smaato などの他の有料広告ネットワークからの広告や、Microsoft のアプリ プロモーション キャンペーン用の広告などが含まれます。 既定では、アプリがサポートする市場全体で広告の収益を最大化できるように、機械学習アルゴリズムを使った仲介設定が自動的に構成されますが、必要に応じて仲介設定を手動で構成することができます。

<span id="manage" />
## <a name="manage-ad-units-for-multiple-ad-controls-in-your-app"></a>アプリで複数の広告コントロールの広告ユニットを管理する

1 つのアプリに複数のバナー広告コントロール、スポット広告コントロール、ネイティブ広告コントロールを使用できます。 このシナリオでは、各コントロールに異なる広告ユニットを割り当てることをお勧めします。 各コントロールに異なる広告ユニットを使用することで、別々に[仲介の設定を構成](../publish/monetize-with-ads.md#mediation)して、個別の[報告データ](../publish/advertising-performance-report.md)を取得することが可能です。 また、これにより、Microsoft のサービスはアプリに提供する広告を最適化できます。

> [!IMPORTANT]
> 各広告ユニットは 1 つのアプリのみで使用できます。 複数のアプリで広告ユニットを使うと、広告ユニットに広告が提供されません。

## <a name="related-topics"></a>関連トピック

* [テスト モードの値](test-mode-values.md)
* [XAML および .NET の AdControl](adcontrol-in-xaml-and--net.md)
* [HTML 5 および Javascript の AdControl](adcontrol-in-html-5-and-javascript.md)
* [スポット広告](interstitial-ads.md)
* [ネイティブ広告](../monetize/native-ads.md)


 

 
