---
author: jnHs
Description: If your app displays ads using the Microsoft Advertising SDK, use the In-app ads page of the Dev Center dashboard to manage your use of ads.
title: "アプリ内広告"
ms.assetid: 09970DE3-461A-4E2A-88E3-68F2399BBCC8
ms.author: wdg-dev-content
ms.date: 12/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, UWP
ms.localizationpriority: high
ms.openlocfilehash: f0faa69cef0f98171c4679d6a94b01199b215cb4
ms.sourcegitcommit: f9a4854b6aecfda472fb3f8b4a2d3b271b327800
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/12/2017
---
# <a name="in-app-ads"></a>アプリ内広告

デベロッパー センター ダッシュボードの **[収益化]** &gt; **[アプリ内広告]** ページを使用して、以下の種類のアプリ用に広告ユニットを作成および管理します。

* [Microsoft Advertising SDK](http://aka.ms/ads-sdk-uwp) を使用するユニバーサル Windows プラットフォーム (UWP) アプリ。
* [Windows および Windows Phone 8.x 用の Microsoft Advertising SDK](http://aka.ms/store-8-sdk) を使用する Windows 8.x および Windows Phone 8.x 用アプリ。

これらの SDK をアプリに統合して広告を表示する方法については、「[Microsoft Advertising SDK を使用したアプリでの広告の表示](../monetize/display-ads-in-your-app.md)」をご覧ください。

<span id="create-ad-unit" />
## <a name="create-ad-units"></a>広告ユニットの作成

アプリ内の[バナー広告](../monetize/banner-ads.md), [interstitial ad](../monetize/interstitial-ads.md)または[ネイティブ広告](../monetize/native-ads.md)用に広告ユニットを作成するには:

1.  ダッシュボードの **[収益化]** &gt; **[アプリ内広告]** ページに移動し、**[広告ユニットを作成]** をクリックします。

2.  **[アプリ名]** ドロップダウンで、広告ユニットを使用するアプリを選択します。

3.  **[広告ユニット名]** フィールドに広告ユニットの名前を入力します。 レポートで広告ユニットを識別しやすくするために、任意の説明文字列を指定できます。

4.  **[広告ユニットの種類]** ドロップダウンで、広告の種類を選択します。

    * アプリで [AdControl](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.aspx) を使ってバナー広告を表示している場合は、**[バナー]** を選択します。

    * アプリで [InterstitialAd](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.interstitialad.aspx) を使ってビデオ広告やバナー スポット広告を表示している場合は、**[ビデオ (スポット)]** または **[バナー (スポット)]** を選択します (表示するスポット広告の種類に対応した適切なオプションを必ず選択してください)。

    * アプリで [NativeAd](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.nativead.aspx) を使ってネイティブ広告を表示している場合は、**[ネイティブ]** を選択します。
      > [!NOTE]
      > **ネイティブ**広告ユニットを作成する機能は、現在はパイロット プログラムに参加している開発者だけが利用できますが、まもなくすべての開発者がこの機能を利用できるようにする予定です。 パイロット プログラムへの参加に関心がある方は、aiacare@microsoft.com までお問い合わせください。

5. **[デバイス ファミリ]** ドロップダウンで、広告ユニットを使うアプリがターゲットとしているデバイス ファミリを選択します。 選択できるオプションには、**[UWP (Windows 10)]**、**[PC/タブレット (Windows 8.1)]**、**[モバイル (Windows Phone 8.x)]** があります。

6. 必要に応じて、次の追加設定を構成します。

    * 広告ユニットのターゲットに **[UWP (Windows 10)]** デバイス ファミリを選択した場合は、オプションで広告ユニットの[仲介設定](#mediation)を構成できます。

    * バナー広告ユニットのターゲットとして **[PC/タブレット (Windows 8.1)]** デバイス ファミリまたは **[モバイル (Windows Phone 8.x)]** デバイス ファミリを選択した場合は、オプションで **[アプリにコミュニティ広告を表示する]** を選択して[コミュニティ広告](about-community-ads.md)にオプトインすることができます。

7.  選択したアプリに対して COPPA 準拠を設定していない場合は、[[COPPA 準拠](#coppa)] セクションでオプションを選択します。

8.  **[広告ユニットを作成]** をクリックします。

作成した新しい広告ユニットは、**[収益化]** &gt; **[アプリ内広告]** ページにある利用可能な広告ユニットの表に表示されます。

<span id="available-ad-units" />
## <a name="review-and-edit-ad-units"></a>広告ユニットの確認と編集

アカウント内で 1 つ以上のアプリに対して広告ユニットを作成すると、これらの広告ユニットが **[収益化]** &gt; **[アプリ内広告]** ページの下部にある表に表示されます。 この表には、各広告ユニットの **[アプリケーション ID]** および **[広告ユニット ID]** がその他の情報と共に表示されます。 アプリに広告を表示するには、コードでこれらの値を使う必要があります。 詳しくは、「[アプリの広告ユニットをセットアップする](../monetize/set-up-ad-units-in-your-app.md)」をご覧ください。

* アプリに[バナー広告](../monetize/banner-ads.md)を表示する場合は、これらの値を [AdControl](https://msdn.microsoft.com/library/mt313154.aspx) オブジェクトの [ApplicationId](https://msdn.microsoft.com/library/mt313174.aspx) プロパティと [AdUnitId](https://msdn.microsoft.com/library/mt313171.aspx) プロパティに割り当てる必要があります。

* アプリに[スポット広告](../monetize/interstitial-ads.md)を表示する場合は、[InterstitialAd](https://msdn.microsoft.com/library/mt313189.aspx) オブジェクトの [RequestAd](https://msdn.microsoft.com/library/mt313192.aspx) メソッドにこれらの値を渡します。

* アプリに[ネイティブ広告](../monetize/native-ads.md)を表示する場合、それらの値を [NativeAdsManager](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.nativeadsmanager.nativeadsmanager.aspx) コンストラクターの *applicationId* パラメーターと *adUnitId* パラメーターに渡します。
  > [!IMPORTANT]
  > 各広告ユニットは 1 つのアプリのみで使用できます。 同じ広告ユニットを複数のアプリで使うと、その広告ユニットには広告が配信されません。

  > [!NOTE]
  > 1 つのアプリに複数のバナー広告コントロール、スポット広告コントロール、ネイティブ広告コントロールを使用できます。 このシナリオでは、各コントロールに異なる広告ユニットを割り当てることをお勧めします。 各コントロールに異なる広告ユニットを使用することで、別々に[仲介の設定を構成](../publish/in-app-ads.md#mediation)して、個別の[報告データ](../publish/advertising-performance-report.md)を取得することが可能です。 また、これにより、Microsoft のサービスはアプリに提供する広告を最適化できます。

UWP 広告ユニットの[仲介設定](#mediation)または広告ユニットを使用しているアプリの [COPPA 準拠](#coppa)を編集するには、ユニット名をクリックします。

<span id="mediation" />
## <a name="mediation-settings"></a>仲介設定

[新しい UWP 広告ユニットを作成する](#create-ad-unit)場合または[既にある UWP 広告ユニットを編集する](#available-ad-units)場合は、このセクションのオプションを使用して広告ユニットの広告仲介を構成します。 広告仲介を使うと、複数の広告ネットワークから広告を表示して、広告収益とアプリ プロモーションの機能を最大限に引き出すことができます。表示される広告には、他の有料広告ネットワークからの広告や、Microsoft のアプリ プロモーション キャンペーン用の収益が生じない広告などが含まれます。 選択した広告ネットワークからのバナー広告要求の仲介は自動的に行われます。 アプリ内のバナー広告、スポット広告、またはネイティブ広告に既に関連付けられている UWP 広告ユニットがある場合は、広告仲介を有効にするためにアプリのコードを変更する必要はありません。

> [!NOTE]
> UWP 広告ユニットで広告仲介を有効にする場合、サードパーティの広告ネットワークから広告ユニットを取得する必要はありません。 必要なサードパーティの広告ユニットは、広告仲介サービスによって自動的に作成されます。

アプリ内の UWP 広告ユニットに対して広告仲介設定を構成するには、次の手順を実行します。

1. [広告ユニットを作成](#create-ad-unit)するか、[既にある広告ユニットを選択](#available-ad-units)します。

2. **[アプリ内広告]** ページの **[仲介設定]** セクションに移動します。

3. 既定では、**[アプリに対して最適な広告仲介設定を Microsoft が選択する]** チェック ボックスがオンになります。 このオプションでは、アプリがサポートする各市場での広告収益を最大化できるように、機械学習アルゴリズムを使ってアプリの広告仲介設定を自動的に選択します。 このオプションを使うことをお勧めします。 独自の広告仲介設定を選択する場合は、このチェック ボックスをオフにします。
    > [!NOTE]
    > このセクションの残りの手順は、このチェック ボックスをオフにして独自の広告仲介設定を選択する場合にのみ適用されます。

4. **[ターゲット]** ドロップダウンで **[ベースライン]** を選択して、既定の広告仲介設定を構成します。 この既定の構成は、市場固有の構成が定義されていないすべての市場に適用されます。

6. 次に、有料ネットワーク (広告表示に応じて収益が支払われるネットワーク) とその他の広告ネットワーク (広告表示に対する収益の支払いがないネットワーク) について、コントロールに表示するそれぞれの広告の割合を指定します。 これを行うには、**[有料の広告ネットワーク]** と **[他の広告ネットワーク]** の **[重さ]** フィールドに 0 ～ 100 の値を入力します。  

7. **[有料の広告ネットワーク]** セクションで、使用する[有料ネットワーク](#paid-networks)ごとに **[有効]** 列のチェック ボックスをオンにします。次に、**[ランク]** 列の矢印を使ってネットワークをランク順に並べ替えます (これで、コントロールによる各ネットワークの使用頻度が指定されます)。

8. **[バナー]** または **[バナー (スポット)]** 広告ユニットを選ぶと、**[他の広告ネットワーク]** という名前のセクションも表示されます。 このセクションのネットワークでは、広告インプレッションに対する収益は生じません。 代わりに、これらのネットワークはアプリ プロモーション キャンペーンなどのソースからの広告を表示します。

    **[その他の広告ネットワーク]** セクションで、使用する[その他のネットワーク](#other-networks)ごとに **[有効]** 列のチェック ボックスをオンにします。次に、**[ランク]** 列の矢印を使ってネットワークをランク順に並べ替えます (これで、コントロールによる各ネットワークの使用頻度が指定されます)。 現在サポートされているその他のネットワークは次のとおりです。

9. 既定の仲介構成をオーバーライドする市場ごとに、**[ターゲット]** ドロップダウンで市場を選択し、広告ネットワークの選択とランクを更新します。

10. **[広告ユニットを作成]** (新しい広告ユニットを作成している場合) または **[保存]** (既存の広告ユニットを編集している場合) をクリックします。

<span id="paid-networks" />
### <a name="supported-paid-ad-networks"></a>サポートされている有料広告ネットワーク

次の表は、広告の種類によって現在サポートされている有料ネットワークを示しています。 ただし、[一部の市場では利用できない](#network-markets)ネットワークもあります。

|  広告ネットワーク  |  説明  |  サポートされている広告の種類  |
|--------------|---------------|---------------------|
| AOL と AppNexus |  これは Microsoft が管理する広告ネットワークです。パートナー ネットワークである AOL と AppNexus を通じて広告サービスを提供します。<p/>**メモ**: AOL and AppNexus は、バナー広告ユニットの **[有料の広告ネットワーク]** の一覧で常に先頭に位置付けられます。この種類の広告でランクを下げることはできません。 | バナー、ビデオ スポット広告 |
| AppNexus (直接) | [AppNexus](https://www.appnexus.com) からビデオ スポット広告を提供するには、このオプションを選択します。 | ビデオ (スポット)、ネイティブ  |
| Microsoft アプリ インストール広告 | Windows エコシステム内の他の開発者で、[各自が開発したアプリのプロモーション用広告キャンペーンを作成している](create-an-ad-campaign-for-your-app.md)開発者によって作成されたアプリ インストール広告やアプリ リエンゲージメント広告を提供するには、このオプションを選択します。  |  バナー、バナー (スポット)、ネイティブ  |
| Outbrain |  [Outbrain](https://www.outbrain.com/) から広告を提供するには、このオプションを選択します。 |  バナー  |
| Revcontent |  [Revcontent](http://www.revcontent.com/) から広告を提供するには、このオプションを選択します。 |  バナー  |
| Smaato |  [Smaato](https://www.smaato.com/) から広告を提供するには、このオプションを選択します。 |  バナー  |
| smartclip |  [smartclip](http://www.smartclip.com/) から広告を提供するには、このオプションを選択します。 |  ビデオ (スポット)  |
| SpotX |  [SpotX](https://www.spotx.tv/) から広告を提供するには、このオプションを選択します。 |  ビデオ (スポット)  |
| Taboola |  [Taboola](https://www.taboola.com/) から広告を提供するには、このオプションを選択します。 |  バナー  |


<span id="other-networks" />
### <a name="other-ad-networks"></a>他の広告ネットワーク

次の表は、広告の種類によって現在サポートされている他のネットワークを示しています。

|  広告ネットワーク  |  説明  |  サポートされている広告の種類  |
|--------------|---------------|---------------------|
| Microsoft コミュニティ広告 |  [自分のアプリの 1 つを宣伝するプロモーション用の広告キャンペーンを作成](create-an-ad-campaign-for-your-app.md)し、そのキャンペーンを[コミュニティ広告キャンペーン](about-community-ads.md)として構成する場合、このキャンペーンから広告を表示するには、このオプションを選択します。 | バナー、バナー (スポット) |
| Microsoft の自社広告 | [自分のアプリの 1 つを宣伝するプロモーション用の広告キャンペーンを作成](create-an-ad-campaign-for-your-app.md)し、そのキャンペーンを[自社広告キャンペーン](about-house-ads.md)として構成する場合、このキャンペーンから広告を表示するには、このオプションを選択します。 | バナー、バナー (スポット)  |


<span id="network-markets" />
### <a name="supported-markets-for-ad-networks"></a>広告ネットワークでサポートされる市場

利用可能な広告ネットワークは、[サポートされるすべての市場](define-pricing-and-market-selection.md#microsoft-store-consumer-markets)で広告を提供しますが、次の例外があります。

|  広告ネットワーク  |  サポートされる市場  |
|--------------|---------------------|
| Revcontent | ブラジル、カナダ、フランス、ドイツ、イタリア、日本、スペイン、英国、米国  |
| Smaato | ブラジル、カナダ、フランス、ドイツ、イタリア、日本、スペイン、英国、米国 |
| smartclip | オーストリア、ベルギー、デンマーク、フィンランド、ドイツ、イタリア、オランダ、ノルウェー、スウェーデン、スイス  |

<span id="coppa" />
## <a name="coppa-compliance"></a>COPPA 準拠

[広告ユニットを作成](#create-ad-unit)または[既存の広告ユニットを選択](#available-ad-units)すると、広告ユニットに対して選んだアプリにアプリ認定プロセスで [Store 内](../publish/the-app-certification-process.md#in-the-store) ステップに到達した申請が 1 つ以上ある場合、**[COPPA 準拠]** セクションがダッシュボード ページの下部に表示されます。

アプリの対象が 13 歳未満の子供である場合、児童オンライン プライバシー保護法 ("COPPA") に従って、このセクションで **[This application is directed at children under the age of 13]** (このアプリは 13 歳未満の子供を対象としています) を選ぶ必要があります。 このオプションを選んだ場合、マイクロソフトはアプリに広告を配信する際に、行動広告サービスを無効にする手順を実行します。

選んだ **COPPA 準拠**設定は、選んだアプリのすべての広告ユニットに自動的に適用されます。

> [!IMPORTANT]
> アプリの対象が 13 歳未満の子供である場合、COPPA の下で特定の義務が発生します。 義務について詳しくは、[こちらのページ](http://go.microsoft.com/fwlink/p/?linkid=536558)をご覧ください。
