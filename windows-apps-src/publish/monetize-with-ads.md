---
author: jnHs
Description: "アプリで広告仲介を利用したり、バナーやスポット広告を表示したりするために Microsoft Store Services SDK を使っている場合は、[広告で収入を増やす] ページで広告の使用を管理します。"
title: "広告による収益獲得"
ms.assetid: 09970DE3-461A-4E2A-88E3-68F2399BBCC8
ms.author: wdg-dev-content
ms.date: 07/06/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp
ms.openlocfilehash: 6ecd37e54de266764570606ceaa575614dfb050c
ms.sourcegitcommit: 10f8dcf69d37cdb61562fc9f4d268ccb499c368f
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/07/2017
---
# <a name="monetize-with-ads"></a>広告による収益獲得

ダッシュボードのアプリごとに、**[収益化]** &gt; **[広告で収入を増やす]** ページがあります。 以下の開発シナリオで、アプリ内の広告の使用を管理するには、このページを使います。

* UWP アプリで、[Microsoft Advertising SDK](http://aka.ms/ads-sdk-uwp) の [AdControl](https://msdn.microsoft.com/en-us/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.aspx)、[InterstitialAd](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.interstitialad.aspx)、[NativeAd](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.nativead.aspx) を使っている場合。
* Windows 8.x アプリまたは Windows Phone 8.x アプリで、[Windows および Windows Phone 8.x 用 Microsoft Advertising SDK](http://aka.ms/store-8-sdk) の **AdControl** または **InterstitialAd** を使っている場合。
* Windows 8.x アプリまたは Windows Phone 8.x アプリで、[Windows および Windows Phone 8.x 用 Microsoft Advertising SDK](http://aka.ms/store-8-sdk) の **AdMediatorControl** を使っている場合。

これらの開発シナリオについて詳しくは、「[Microsoft Advertising SDK を使用したアプリでの広告の表示](../monetize/display-ads-in-your-app.md)」をご覧ください。

<span id="create-ad-unit" />
## <a name="create-ad-units"></a>広告ユニットを作成

次のシナリオで広告ユニットを作成する場合は、このセクションを使います。

* アプリで **AdControl** を使ってバナー広告を表示する。 詳しくは、「[XAML および .NET の AdControl](../monetize/adcontrol-in-xaml-and--net.md)」、または「[HTML5 および JavaScript の AdControl](../monetize/adcontrol-in-html-5-and-javascript.md)」をご覧ください。
* アプリで **InterstitialAd** を使ってビデオ スポット広告またはバナー スポット広告を表示する。 詳しくは、「[スポット広告](../monetize/interstitial-ads.md)」をご覧ください。
* アプリで **NativeAd** を使ってネイティブ広告を表示する。 詳しくは、「[ネイティブ広告](../monetize/native-ads.md)」をご覧ください。

広告ユニットを作成するには、次の手順を実行します。

1.  **[広告ユニット名]** フィールドに広告ユニットの名前を入力します。 レポートで広告ユニットを識別しやすくするために、任意の説明文字列を指定できます。
2.  **[広告ユニットの種類]** ドロップダウンで、コントロールに表示する広告に対応する広告ユニットの種類を選択します。 選択できるオプションには、**[バナー]**、**[バナー (スポット)]**、**[ビデオ (スポット)]**、**[ネイティブ]** があります。
    > [!NOTE]
    > **ネイティブ**広告ユニットを作成する機能は、現在はパイロット プログラムに参加している開発者だけが利用できますが、まもなくすべての開発者がこの機能を利用できるようにする予定です。 パイロット プログラムへの参加に関心がある方は、aiacare@microsoft.com までお問い合わせください。

3.  **[デバイス ファミリ]** ドロップダウンで、広告ユニットを使うアプリがターゲットとしているデバイス ファミリを選択します。 選択できるオプションには、**[UWP (Windows 10)]**、**[PC/タブレット (Windows 8.1)]**、**[モバイル (Windows Phone 8.x)]** があります。
4.  **[広告ユニットを作成]** をクリックします。

このページの **[利用可能な広告ユニット]** セクションの上部にある一覧に、新しい広告ユニットが表示されます。 アプリでの広告ユニットの取り扱いについて詳しくは、「[アプリの広告ユニットをセットアップする](../monetize/set-up-ad-units-in-your-app.md)」をご覧ください。

> [!NOTE]
> Windows 8.x アプリまたは Windows Phone 8.x アプリで **AdMediatorControl** を使ってバナー広告を表示する場合は、ここで広告ユニットを要求する必要はありません。 このシナリオでは、広告ユニットが自動的に生成されます。

<span id="available-ad-units" />
## <a name="available-ad-units"></a>利用可能な広告ユニット

広告ユニットは、このセクションの下部にある表に表示されます。 広告ユニットごとに**アプリケーション ID** と**広告ユニット ID** が表示されます。 アプリに広告を表示するには、コードでこれらの値を使う必要があります。

-   アプリにバナー広告を表示する場合は、これらの値を [AdControl](https://msdn.microsoft.com/library/mt313154.aspx) オブジェクトの [ApplicationId](https://msdn.microsoft.com/library/mt313174.aspx) プロパティと [AdUnitId](https://msdn.microsoft.com/library/mt313171.aspx) プロパティに割り当てる必要があります。 詳しくは、「[XAML および .NET の AdControl](../monetize/adcontrol-in-xaml-and--net.md)」、または「[HTML5 および JavaScript の AdControl](../monetize/adcontrol-in-html-5-and-javascript.md)」をご覧ください。
-   アプリでスポット広告を表示する場合は、[InterstitialAd](https://msdn.microsoft.com/library/mt313189.aspx) オブジェクトの [RequestAd](https://msdn.microsoft.com/library/mt313192.aspx) メソッドにこれらの値を渡します。 詳しくは、「[スポット広告](../monetize/interstitial-ads.md)」をご覧ください。
-   アプリにネイティブ広告が表示される場合、それらの値を [NativeAdsManager](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.nativeadsmanager.nativeadsmanager.aspx) コンストラクターの *applicationId* パラメーターと *adUnitId* パラメーターに渡します。 詳しくは、「[ネイティブ広告](../monetize/native-ads.md)」をご覧ください。

> [!IMPORTANT]
> 各広告ユニットは 1 つのアプリのみで使用できます。 同じ広告ユニットを複数のアプリで使うと、その広告ユニットには広告が配信されません。

> [!NOTE]
> 1 つのアプリに複数のバナー広告コントロール、スポット広告コントロール、ネイティブ広告コントロールを使用できます。 このシナリオでは、各コントロールに異なる広告ユニットを割り当てることをお勧めします。 各コントロールに異なる広告ユニットを使用することで、別々に[仲介の設定を構成](../publish/monetize-with-ads.md#mediation)して、個別の[報告データ](../publish/advertising-performance-report.md)を取得することが可能です。 また、これにより、Microsoft のサービスはアプリに提供する広告を最適化できます。

<span id="mediation" />
## <a name="ad-mediation"></a>広告仲介

Windows 10 用の UWP アプリでは、このセクションのオプションを使って、アプリ内のバナー広告、スポット広告、またはネイティブ広告に関連付けられている UWP 広告ユニットに対して広告仲介を有効にすることができます。 広告仲介を使うと、複数の広告ネットワークから広告を表示して、広告収益とアプリ プロモーションの機能を最大限に引き出すことができます。表示される広告には、他の有料広告ネットワークからの広告や、Microsoft のアプリ プロモーション キャンペーン用の収益が生じない広告などが含まれます。 選択した広告ネットワークからのバナー広告要求の仲介は自動的に行われます。

アプリ内のバナー広告、スポット広告、またはネイティブ広告に既に関連付けられている UWP 広告ユニットがある場合は、広告仲介を有効にするためにアプリのコードを変更する必要はありません。

> [!NOTE]
> このセクションでは、UWP アプリ パッケージの **Ad mediation** オプションについて説明します。 アプリ パッケージが Windows 8.x または Windows Phone 8.x をターゲットとしていて、[Windows および Windows Phone 8.x 用 Microsoft Advertising SDK](http://aka.ms/store-8-sdk) の **AdMediatorControl** を使っている場合は、ダッシュボードの **[広告メディエーション]** セクションに表示されるオプションのセットが異なります。 **AdMediatorControl** を使う Windows 8.x アプリ パッケージまたは Windows Phone 8.x アプリ パッケージの仲介設定の構成について詳しくは、[こちらの記事](https://msdn.microsoft.com/library/windows/apps/mt219689)をご覧ください。

アプリ内の UWP 広告ユニットに対して広告仲介設定を構成するには、次の手順を実行します。

1. **[メディエーションの構成対象]** ドロップダウンで、構成するバナー広告、スポット広告、またはネイティブ広告がある UWP アプリ パッケージを選択します。

2. **[広告ユニットの種類]** ドロップダウンで、構成する広告ユニットの種類 (**[バナー]**、**[バナー (スポット)]**、**[ビデオ (スポット)]**、または **[ネイティブ]**) を選びます。

3. **[広告ユニット]** ドロップダウンで、構成する UWP 広告ユニットの名前を選択します。
    > [!NOTE]
    > UWP 広告ユニットで広告仲介を有効にする場合、サードパーティの広告ネットワークから広告ユニットを取得する必要はありません。 必要なサードパーティの広告ユニットは、広告仲介サービスによって自動的に作成されます。

4. 既定では、**[アプリに対して最適な広告仲介設定を Microsoft が選択する]** チェック ボックスがオンになります。 このオプションでは、アプリがサポートする各市場での広告収益を最大化できるように、機械学習アルゴリズムを使ってアプリの広告仲介設定を自動的に選択します。 このオプションを使うことをお勧めします。 独自の広告仲介設定を選択する場合は、このチェック ボックスをオフにします。
    > [!NOTE]
    > このセクションの残りの手順は、このチェック ボックスをオフにして独自の広告仲介設定を選択する場合にのみ適用されます。

5. **[ターゲット]** ドロップダウンで **[ベースライン]** を選択して、既定の広告仲介設定を構成します。 この既定の構成は、市場固有の構成が定義されていないすべての市場に適用されます。

6. 次に、有料ネットワーク (広告表示に応じて収益が支払われるネットワーク) とその他の広告ネットワーク (広告表示に対する収益の支払いがないネットワーク) について、コントロールに表示するそれぞれの広告の割合を指定します。 これを行うには、**[有料の広告ネットワーク]** と **[他の広告ネットワーク]** の **[重さ]** フィールドに 0 ～ 100 の値を入力します。  

7. **[有料の広告ネットワーク]** セクションで、使用する有料ネットワークごとに **[有効]** 列のチェック ボックスをオンにします。次に、**[ランク]** 列の矢印を使ってネットワークをランク順に並べ替えます (これで、コントロールによる各ネットワークの使用頻度が指定されます)。

    現在サポートされている有料ネットワークは次のとおりです。 ただし、[一部の市場では利用できない](#network-markets)ネットワークもあります。

    -   **AOL and AppNexus**:  これは Microsoft が管理する広告ネットワークです。パートナー ネットワークである AOL と AppNexus を通じて広告サービスを提供します。 このネットワークは、**バナー**および**ビデオ (スポット)** 広告ユニットでサポートされています。
        > [!NOTE]
        > **AOL and AppNexus** は、**バナー**広告ユニットの **[有料の広告ネットワーク]** の一覧で常に先頭に位置付けられます。この種類の広告でランクを下げることはできません。

    -   **AppNexus (直接)**: [AppNexus](https://www.appnexus.com) からビデオ スポット広告を提供するには、このオプションを選択します。 このネットワークは、**ビデオ (スポット)** および**ネイティブ**広告ユニットでサポートされています。

    -   **Microsoft アプリ インストール広告**:  Windows エコシステム内の他の開発者で、[各自が開発したアプリのプロモーション用広告キャンペーンを作成している](create-an-ad-campaign-for-your-app.md)開発者によって作成されたアプリ インストール広告やアプリ リエンゲージメント広告を提供するには、このオプションを選択します。 このネットワークは、**バナー**、**バナー (スポット)** および**ネイティブ**広告ユニットでサポートされています。

    -   **Smaato**: [Smaato](https://www.smaato.com/) から広告を提供するには、このオプションを選択します。 このネットワークは、**バナー**広告ユニットでサポートされています。

    -   **smartclip**: [smartclip](http://www.smartclip.com/) から広告を提供するには、このオプションを選択します。 このネットワークは、**ビデオ (スポット)** 広告ユニットでサポートされています。

    -   **SpotX**: [SpotX](https://www.spotx.tv/) から広告を提供するには、このオプションを選択します。 このネットワークは、**ビデオ (スポット)** 広告ユニットでサポートされています。

    -   **Taboola**: [Taboola](https://www.taboola.com/) から広告を提供するには、このオプションを選択します。 このネットワークは、**バナー**広告ユニットでサポートされています。

8. **バナー**または**バナー (スポット)** 広告ユニットを選ぶと、**[他の広告ネットワーク]** という名前のセクションも表示されます。 このセクションのネットワークでは、広告インプレッションに対する収益は生じません。 代わりに、これらのネットワークはアプリ プロモーション キャンペーンなどのソースからの広告を表示します。 

    **[その他の広告ネットワーク]** セクションで、使用するその他のネットワークごとに **[有効]** 列のチェック ボックスをオンにします。次に、**[ランク]** 列の矢印を使ってネットワークをランク順に並べ替えます (これで、コントロールによる各ネットワークの使用頻度が指定されます)。 現在サポートされているその他のネットワークは次のとおりです。

    -   **Microsoft コミュニティ広告**:  [自分のアプリの 1 つを宣伝するプロモーション用の広告キャンペーンを作成](create-an-ad-campaign-for-your-app.md)し、そのキャンペーンを[コミュニティ広告キャンペーン](about-community-ads.md)として構成する場合、このキャンペーンから広告を表示するには、このオプションを選択します。 

    -   **Microsoft の自社広告**:  [自分のアプリの 1 つを宣伝するプロモーション用の広告キャンペーンを作成](create-an-ad-campaign-for-your-app.md)し、そのキャンペーンを[自社広告キャンペーン](about-house-ads.md)として構成する場合、このキャンペーンから広告を表示するには、このオプションを選択します。

9. 既定の仲介構成をオーバーライドする市場ごとに、**[ターゲット]** ドロップダウンで市場を選択し、広告ネットワークの選択とランクを更新します。

10. **[保存]** をクリックします。

<span id="network-markets" />
### <a name="supported-markets-for-ad-networks"></a>広告ネットワークでサポートされる市場

利用可能な広告ネットワークは、UWP アプリで[サポートされるすべての市場](define-pricing-and-market-selection.md#windows-store-consumer-markets)で広告を提供しますが、次の例外があります。

|  広告ネットワーク  |  サポート対象の市場  |
|--------------|---------------------|
| Smaato | ブラジル、カナダ、フランス、ドイツ、イタリア、日本、スペイン、英国、米国 |
| smartclip | オーストリア、ベルギー、デンマーク、フィンランド、ドイツ、イタリア、オランダ、ノルウェー、スウェーデン、スイス  |


## <a name="microsoft-affiliate-ads"></a>Microsoft のアフィリエイト広告

Microsoft アフィリエイト広告をアプリに表示する場合は、このセクションのボックスをオンにします。 このボックスをオンにすると、他の広告ネットワークから広告が配信されない場合にのみ、音楽、ゲーム、映画、アプリ、ハードウェア、ソフトウェアなど、ストアの製品の広告がアプリに表示されます。 ユーザーが広告をクリックし、所定の属性を備えたウィンドウでストアの製品を購入すると、承認された購入について手数料を獲得できます。

この選択を変更した場合、変更を反映させるためにアプリを再公開する必要はありません。 Microsoft アフィリエイト広告について詳しくは、「[アフィリエイト広告について](about-affiliate-ads.md)」をご覧ください。

## <a name="coppa-compliance"></a>COPPA 準拠

アプリが 13 歳未満の子供を対象としている場合、児童オンライン プライバシー保護法 ("COPPA") に従って、マイクロソフトに通知する必要があります。 デベロッパー センターを使用して、アプリの対象が 13 歳未満の子供であることをマイクロソフトに通知した場合、マイクロソフトはアプリに広告を配信する際に、行動広告サービスを無効にする手順を実行します。 アプリの対象が 13 歳未満の子供である場合、COPPA の下で特定の義務が発生します。

COPPA の下での義務について詳しくは、[こちらのページ](http://go.microsoft.com/fwlink/p/?linkid=536558)をご覧ください。
