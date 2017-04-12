---
author: jnHs
Description: "アプリで Microsoft Advertising の広告仲介を使ったり、バナーやスポット広告を表示したりする場合は、[収益化]、[広告で収入を増やす] ページの順に選択して、広告の使用を管理します。"
title: "広告による収益獲得"
ms.assetid: 09970DE3-461A-4E2A-88E3-68F2399BBCC8
ms.author: wdg-dev-content
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 6418fe1b47ac89e8decb135aa9a2108b3b95ef82
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="monetize-with-ads"></a>広告による収益獲得


アプリで **AdMediatorControl**、**AdControl**、または **InterstitialAd** コントロールを使用してバナー広告またはスポット広告を表示する場合は、**[収益化]**、**[広告で収入を増やす]** ページの順に選択して、広告の使用を管理します。

## <a name="windows-ad-mediation"></a>Windows 広告仲介


アプリで広告仲介を使う場合は、このセクションを使って、仲介の設定を構成し、アプリで使う各広告ネットワークで必要なパラメーターを追加します。 このセクションのオプションについて詳しくは、「[アプリの提出と広告の仲介の構成](https://msdn.microsoft.com/library/windows/apps/mt219689)」をご覧ください。

広告仲介によって、複数の広告ネットワークからのバナー広告要求を仲介してアプリ内広告の収益を最大限に増やすことができます。 広告の仲介について詳しくは、「[広告の仲介を追加して収益を最大限に高める](https://msdn.microsoft.com/library/windows/apps/mt219691)」をご覧ください。

## <a name="coppa-compliance"></a>COPPA 準拠

アプリが 13 歳未満の子供を対象としている場合、児童オンライン プライバシー保護法 ("COPPA") に従って、マイクロソフトに通知する必要があります。 デベロッパー センターを使用して、アプリの対象が 13 歳未満の子供であることをマイクロソフトに通知した場合、マイクロソフトはアプリに広告を配信する際に、行動広告サービスを無効にする手順を実行します。 アプリの対象が 13 歳未満の子供である場合、COPPA の下で特定の義務が発生します。

COPPA の下での義務について詳しくは、[こちらのページ](http://go.microsoft.com/fwlink/p/?linkid=536558)をご覧ください。

## <a name="microsoft-affiliate-ads"></a>Microsoft アフィリエイト広告

Microsoft アフィリエイト広告をアプリに表示する場合は、このセクションのボックスをオンにします。 このボックスをオンにすると、他の広告ネットワークから広告が配信されない場合にのみ、音楽、ゲーム、映画、アプリ、ハードウェア、ソフトウェアなど、ストアの製品の広告がアプリに表示されます。 ユーザーが広告をクリックし、所定の属性を備えたウィンドウでストアの製品を購入すると、承認された購入について手数料を獲得できます。

この選択を変更した場合、変更を反映させるためにアプリを再公開する必要はありません。 Microsoft アフィリエイト広告について詳しくは、「[アフィリエイト広告について](about-affiliate-ads.md)」をご覧ください。

> **注**  アプリで広告仲介を使用するときは (つまり、**AdMediatorControl** を使用して広告を表示する場合)、Microsoft からの広告を表示するように広告仲介が設定されている場合にのみ、アプリでアフィリエイト広告を表示できます。

## <a name="community-ads"></a>コミュニティ広告

自分のアプリと他の開発者が公開したアプリを相互に販売促進する場合は、このセクションのボックスをオンにします。 このボックスをオンにして、[コミュニティ広告キャンペーンを作成](create-an-ad-campaign-for-your-app.md)すると、自分のアプリの広告が他の開発者 (コミュニティ広告キャンペーンの作成者) が公開したアプリに表示され、他の開発者のアプリの広告が自分のアプリに表示されます。 コミュニティ広告は無料で、他の広告ネットワークからの広告が配信されない場合にのみ表示されます。

この選択を変更した場合、変更を反映させるためにアプリを再公開する必要はありません。 コミュニティ広告について詳しくは、「[コミュニティ広告について](about-community-ads.md)」をご覧ください。

## <a name="microsoft-advertising-ad-units"></a>Microsoft Advertising 広告ユニット

このセクションを使って、Microsoft Advertising 広告ユニットを作成できます。 次のシナリオでのみ、広告ユニットを作成する必要があります。

-   アプリで [AdControl](https://msdn.microsoft.com/library/mt313154.aspx) オブジェクトを使ってバナー広告を表示する。
-   アプリで [InterstitialAd](https://msdn.microsoft.com/library/mt313189.aspx)オブジェクトを使ってスポット広告を表示する。

これらのシナリオの広告ユニットを作成するには

1.  広告ユニットに名前を付けます。
2.  広告ユニットの種類 (**[バナー]**、**[ビデオ (スポット)]**、または **[バナー (スポット)]**) を選択します。
3.  デバイスの種類 (**[モバイル]** または **[PC/タブレット]**) を選びます。
4.  **[広告ユニットを作成]** をクリックします。

広告ユニットは、このセクションの下部にある表に表示されます。 広告ユニットごとに**アプリケーション ID** と**広告ユニット ID** が表示されます。 アプリに広告を表示するには、コードでこれらの値を使う必要があります。

-   アプリにバナー広告を表示する場合は、これらの値を [AdControl](https://msdn.microsoft.com/library/mt313154.aspx) オブジェクトの [ApplicationId](https://msdn.microsoft.com/library/mt313174.aspx) プロパティと [AdUnitId](https://msdn.microsoft.com/library/mt313171.aspx) プロパティに割り当てる必要があります。 詳しくは、「[XAML および .NET の AdControl](../monetize/adcontrol-in-xaml-and--net.md)」、または「[HTML5 および JavaScript の AdControl](../monetize/adcontrol-in-html-5-and-javascript.md)」をご覧ください。
-   アプリでスポット広告を表示する場合は、[InterstitialAd](https://msdn.microsoft.com/library/mt313189.aspx) オブジェクトの [RequestAd](https://msdn.microsoft.com/library/mt313192.aspx) メソッドにこれらの値を渡します。 詳しくは、「[スポット広告](../monetize/interstitial-ads.md)」をご覧ください。

> **注**  アプリで **AdMediatorControl** オブジェクトを使って、Microsoft Advertising からバナー広告を表示する場合は、広告ユニットを要求する必要はありません。 このシナリオでは、Microsoft Advertising 広告ユニットが自動的に生成されます。

 

 

 
