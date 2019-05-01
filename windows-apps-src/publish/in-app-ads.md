---
Description: アプリは Microsoft Advertising SDK を使用して広告を表示する場合は、パートナー センターのアプリ内広告ページを使用して、広告の使用を管理します。
title: アプリ内広告
ms.assetid: 09970DE3-461A-4E2A-88E3-68F2399BBCC8
ms.date: 03/25/2019
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 355cff08c6ab98b0837b8cc95f2480aa1fb17bd4
ms.sourcegitcommit: fca0132794ec187e90b2ebdad862f22d9f6c0db8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/24/2019
ms.locfileid: "63784727"
---
# <a name="in-app-ads"></a>アプリ内広告

使用して、 **Monetize** &gt; **アプリ内広告**ページ[パートナー センター](https://partner.microsoft.com/dashboard)を作成および管理の ad 単位。

* [Microsoft Advertising SDK](https://aka.ms/ads-sdk-uwp) を使用するユニバーサル Windows プラットフォーム (UWP) アプリ。
* 以前に公開された Windows 8.x および Windows Phone 8.x アプリを使用する、 [Microsoft Advertising SDK の Windows と Windows Phone 8.x](https://aka.ms/store-8-sdk)します。

> [!IMPORTANT]
> 2018 年 10 月 31 日の時点で、新しく作成された製品が Windows 8.x/Windows を対象とするパッケージを含めることはできません Phone 8.x 以前のバージョン。 詳細については、「この[ブログの投稿](https://blogs.windows.com/buildingapps/2018/08/20/important-dates-regarding-apps-with-windows-phone-8-x-and-earlier-and-windows-8-8-1-packages-submitted-to-microsoft-store/#SzKghBbqDMlmAO4c.97)します。

これらの SDK をアプリに統合して広告を表示する方法については、「[Microsoft Advertising SDK を使用したアプリでの広告の表示](../monetize/display-ads-in-your-app.md)」をご覧ください。

<span id="create-ad-unit" />

## <a name="create-ad-units"></a>広告ユニットを作成

アプリ内の[バナー広告](../monetize/banner-ads.md), [interstitial ad](../monetize/interstitial-ads.md)または[ネイティブ広告](../monetize/native-ads.md)用に広告ユニットを作成するには:

1.  移動して、 **Monetize** &gt; **アプリ内広告**パートナー センターでページし、をクリックして**作成 ad 単位**します。
2.  **[アプリ名]** ドロップダウンで、広告ユニットを使用するアプリを選択します。
3.  **[広告ユニット名]** フィールドに広告ユニットの名前を入力します。 レポートで広告ユニットを識別しやすくするために、任意の説明文字列を指定できます。
4.  **[広告ユニットの種類]** ドロップダウンで、広告の種類を選択します。

    * アプリ内バナー広告を表示する場合は、選択**バナー**します。
    * アプリ内スポット ビデオ広告やバナーのスポット広告を表示する場合は、選択**ビデオをスポット**または**バナー スポット**(必ずの種類に適したオプションを選択してくださいスポット広告を表示する)。
    * アプリでネイティブの広告を表示する場合は、選択**ネイティブ**します。

5. **[デバイス ファミリ]** ドロップダウンで、広告ユニットを使うアプリがターゲットとしているデバイス ファミリを選択します。 使用可能なオプションは次のとおりです。**UWP (Windows 10)**、 **PC/タブレット (Windows 8.1)**、または**Mobile (Windows Phone 8.x)** します。

6. 必要に応じて、次の追加設定を構成します。

    * 広告ユニットのターゲットに **[UWP (Windows 10)]** デバイス ファミリを選択した場合は、オプションで広告ユニットの[仲介設定](#mediation)を構成できます。
    * バナー広告ユニットのターゲットとして **[PC/タブレット (Windows 8.1)]** デバイス ファミリまたは **[モバイル (Windows Phone 8.x)]** デバイス ファミリを選択した場合は、オプションで **[アプリにコミュニティ広告を表示する]** を選択して[コミュニティ広告](about-community-ads.md)にオプトインすることができます。

7.  選択したアプリに対して COPPA 準拠を設定していない場合は、[[COPPA 準拠](#coppa)] セクションでオプションを選択します。
8.  **[広告ユニットを作成]** をクリックします。

使用可能な ad ユニットのテーブルで表示、新しい ad ユニットを作成した後、 **Monetize** &gt; **アプリ内広告**ページ。

<span id="available-ad-units" />

## <a name="review-and-edit-ad-units"></a>広告ユニットの確認と編集

これらの広告ユニットがの下部にあるテーブルに表示されます自分のアカウントでアプリを 1 つまたは複数の ad 単位を作成した後、 **Monetize** &gt; **アプリ内広告**ページ。 この表には、各広告ユニットの **[アプリケーション ID]** および **[広告ユニット ID]** がその他の情報と共に表示されます。 アプリに広告を表示するには、コードでこれらの値を使う必要があります。 詳しくは、「[アプリの広告ユニットをセットアップする](../monetize/set-up-ad-units-in-your-app.md)」をご覧ください。

* アプリに[バナー広告](../monetize/banner-ads.md)を表示する場合は、これらの値を [AdControl](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.adcontrol) オブジェクトの [ApplicationId](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.adcontrol.applicationid) プロパティと [AdUnitId](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.adcontrol.adunitid) プロパティに割り当てる必要があります。
* アプリに[スポット広告](../monetize/interstitial-ads.md)を表示する場合は、[InterstitialAd](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.interstitialad) オブジェクトの [RequestAd](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.interstitialad.requestad) メソッドにこれらの値を渡します。
* アプリが表示されている場合[ネイティブ広告](../monetize/native-ads.md)、これらの値を渡す、 **NativeAdsManagerV2**コンス トラクター。
  > [!IMPORTANT]
  > 各広告ユニットは 1 つのアプリのみで使用できます。 同じ広告ユニットを複数のアプリで使うと、その広告ユニットには広告が配信されません。

  > [!NOTE]
  > 1 つのアプリに複数のバナー広告コントロール、スポット広告コントロール、ネイティブ広告コントロールを使用できます。 このシナリオでは、各コントロールに異なる広告ユニットを割り当てることをお勧めします。 各コントロールに異なる広告ユニットを使用することで、別々に[仲介の設定を構成](../publish/in-app-ads.md#mediation)して、個別の[報告データ](../publish/advertising-performance-report.md)を取得することが可能です。 また、これにより、Microsoft のサービスはアプリに提供する広告を最適化できます。

UWP 広告ユニットの[仲介設定](#mediation)または広告ユニットを使用しているアプリの [COPPA 準拠](#coppa)を編集するには、ユニット名をクリックします。

> [!NOTE]
> としてラベルは、ad 単位には、過去 6 か月間のアクティビティがなければ、 **Inactive**、最終的にパートナー センターから削除します。 フィルターを使用して "**アクティブ**" または "**非アクティブ**" の広告ユニットのみを表示することもできます。 誤って "**非アクティブ**" がマークされていると思われる広告ユニットを見つけた場合は、[サポートにお問い合わせください](https://aka.ms/storesupport)。

<span id="mediation" />

## <a name="mediation-settings"></a>仲介設定

ときにする[新しい UWP ad 単位を作成](#create-ad-unit)または[既存の UWP ad ユニットを編集](#available-ad-units)、このセクションで構成するオプションを使用して[ad 仲介](../monetize/ad-mediation-service.md)ad 単位。 広告仲介を使うと、複数の広告ネットワークから広告を表示して、広告収益とアプリ プロモーションの機能を最大限に引き出すことができます。表示される広告には、他の有料広告ネットワークからの広告や、Microsoft のアプリ プロモーション キャンペーン用の収益が生じない広告などが含まれます。 選択した広告ネットワークからのバナー広告要求の仲介は自動的に行われます。 アプリ内のバナー広告、スポット広告、またはネイティブ広告に既に関連付けられている UWP 広告ユニットがある場合は、広告仲介を有効にするためにアプリのコードを変更する必要はありません。

> [!NOTE]
> UWP 広告ユニットで広告仲介を有効にする場合、サードパーティの広告ネットワークから広告ユニットを取得する必要はありません。 必要なサードパーティの広告ユニットは、広告仲介サービスによって自動的に作成されます。

アプリ内の UWP 広告ユニットに対して広告仲介設定を構成するには、次の手順を実行します。

1. [広告ユニットを作成](#create-ad-unit)するか、[既にある広告ユニットを選択](#available-ad-units)します。
2. **アプリ内広告** ページに移動して、**仲介設定**セクションと構成の設定。

    * 既定で、**できる点を Microsoft が個人の設定を最適化** チェック ボックスをオンします。 このオプションを使うことをお勧めします。 このオプションでは、アプリがサポートする各市場での広告収益を最大化できるように、機械学習アルゴリズムを使ってアプリの広告仲介設定を自動的に選択します。 このオプションを使用する場合は、構成に使用する広告ネットワークも選択できます。 構成の一部にしないし、アルゴリズムは、アプリは、選択した ad ネットワークから広告をのみ受け取ることを確認する ad ネットワークをオフにします。
    * 独自の ad 仲介の設定を選択する場合は、選択**既定設定を変更**します。

    > [!NOTE]
    > このセクションの残りの手順は、該当するは、選択した場合のみ**既定設定を変更**します。

3. **[ターゲット]** ドロップダウンで **[ベースライン]** を選択して、既定の広告仲介設定を構成します。 この既定の構成は、市場固有の構成が定義されていないすべての市場に適用されます。
4. 次に、有料ネットワーク (広告表示に応じて収益が支払われるネットワーク) とその他の広告ネットワーク (広告表示に対する収益の支払いがないネットワーク) について、コントロールに表示するそれぞれの広告の割合を指定します。 これを行うには、**[有料の広告ネットワーク]** と **[他の広告ネットワーク]** の **[重さ]** フィールドに 0 ～ 100 の値を入力します。  
5. **[有料の広告ネットワーク]** セクションで、使用する[有料ネットワーク](#paid-networks)ごとに **[有効]** 列のチェック ボックスをオンにします。次に、**[ランク]** 列の矢印を使ってネットワークをランク順に並べ替えます (これで、コントロールによる各ネットワークの使用頻度が指定されます)。
6. **[バナー]** または **[バナー (スポット)]** 広告ユニットを選ぶと、**[他の広告ネットワーク]** という名前のセクションも表示されます。 このセクションのネットワークでは、広告インプレッションに対する収益は生じません。 代わりに、これらのネットワークはアプリ プロモーション キャンペーンなどのソースからの広告を表示します。

    **[その他の広告ネットワーク]** セクションで、使用する[その他のネットワーク](#other-networks)ごとに **[有効]** 列のチェック ボックスをオンにします。次に、**[ランク]** 列の矢印を使ってネットワークをランク順に並べ替えます (これで、コントロールによる各ネットワークの使用頻度が指定されます)。 現在サポートされているその他のネットワークは次のとおりです。

7. 既定の仲介構成をオーバーライドする市場ごとに、**[ターゲット]** ドロップダウンで市場を選択し、広告ネットワークの選択とランクを更新します。
8. **[広告ユニットを作成]** (新しい広告ユニットを作成している場合) または **[保存]** (既存の広告ユニットを編集している場合) をクリックします。

<span id="paid-networks" />

### <a name="supported-paid-ad-networks"></a>サポートされている有料広告ネットワーク

次の表は、広告の種類によって現在サポートされている有料ネットワークを示しています。 ただし、[一部の市場では利用できない](#network-markets)ネットワークもあります。

|  広告ネットワーク  |  説明  |  サポートされている広告の種類  |
|--------------|---------------|---------------------|
| Oath と AppNexus |  これは、network、Oath AppNexus 当社のパートナーからの広告を提供する Microsoft が管理する ad ネットワークです。<p/>**注意**:Oath と AppNexus 常にランク付けされて初めて、**有料広告ネットワーク**ような種類の広告の下部の順位付けでは、バナー広告ユニットでは、一覧に変更できません。 | バナー、ビデオ スポット広告 |
| AppNexus (直接) | 広告を提供するには、このオプションを選択[AppNexus](https://www.appnexus.com)します。 | ビデオ (スポット)、ネイティブ  |
| Microsoft アプリ インストール広告 | Windows エコシステム内の他の開発者で、[各自が開発したアプリのプロモーション用広告キャンペーンを作成している](create-an-ad-campaign-for-your-app.md)開発者によって作成されたアプリ インストール広告やアプリ リエンゲージメント広告を提供するには、このオプションを選択します。  |  バナー、バナー (スポット)、ネイティブ  |
| MSN コンテンツの推奨事項 |  MSN コンテンツの推奨事項から広告を配信するには、このオプションを選択します。 |  バナー、バナー (スポット)  |
| Outbrain |  [Outbrain](https://www.outbrain.com/) から広告を提供するには、このオプションを選択します。 |  バナー、バナー (スポット)  |
| Revcontent |  [Revcontent](https://www.revcontent.com/) から広告を提供するには、このオプションを選択します。 |  バナー、ネイティブ  |
| Smaato |  [Smaato](https://www.smaato.com/) から広告を提供するには、このオプションを選択します。 |  バナー  |
| smartclip |  [smartclip](http://www.smartclip.com/) から広告を提供するには、このオプションを選択します。 |  ビデオ (スポット)  |
| SpotX |  [SpotX](https://www.spotx.tv/) から広告を提供するには、このオプションを選択します。 |  ビデオ (スポット)  |
| Taboola |  [Taboola](https://www.taboola.com/) から広告を提供するには、このオプションを選択します。 |  バナー  |
| Undertone | 広告を提供するには、このオプションを選択[Undertone](https://www.undertone.com/)します。 | スポットのバナー |


<span id="other-networks" />

### <a name="other-ad-networks"></a>他の広告ネットワーク

次の表は、広告の種類によって現在サポートされている他のネットワークを示しています。

|  広告ネットワーク  |  説明  |  サポートされている広告の種類  |
|--------------|---------------|---------------------|
| Microsoft コミュニティ広告 |  [自分のアプリの 1 つを宣伝するプロモーション用の広告キャンペーンを作成](create-an-ad-campaign-for-your-app.md)し、そのキャンペーンを[コミュニティ広告キャンペーン](about-community-ads.md)として構成する場合、このキャンペーンから広告を表示するには、このオプションを選択します。 | バナー、バナー (スポット) |
| Microsoft の自社広告 | [自分のアプリの 1 つを宣伝するプロモーション用の広告キャンペーンを作成](create-an-ad-campaign-for-your-app.md)し、そのキャンペーンを[自社広告キャンペーン](about-house-ads.md)として構成する場合、このキャンペーンから広告を表示するには、このオプションを選択します。 | バナー、バナー (スポット)  |


<span id="network-markets" />

### <a name="supported-markets-for-ad-networks"></a>広告ネットワークでサポートされる市場

利用可能な広告ネットワークは、[サポートされるすべての市場](define-market-selection.md#microsoft-store-consumer-markets)で広告を提供しますが、次の例外があります。

|  広告ネットワーク  |  サポート対象の市場  |
|--------------|---------------------|
| Revcontent | ブラジル、カナダ、フランス、ドイツ、イタリア、日本、スペイン、英国、米国  |
| Smaato | ブラジル、カナダ、フランス、ドイツ、イタリア、日本、スペイン、英国、米国 |
| smartclip | オーストリア、ベルギー、デンマーク、フィンランド、ドイツ、イタリア、オランダ、ノルウェー、スウェーデン、スイス  |
| Undertone | 米国 |

<span id="coppa" />

## <a name="coppa-compliance"></a>COPPA 準拠

ときにする[ad 単位を作成](#create-ad-unit)または[既存の ad 単位を選択](#available-ad-units)、 **COPPA コンプライアンス**セクションは、ad 単位の選択したアプリがある少なくとも場合は、ページの下部に表示されます。1 つのサブミッションに達した、[ストアに](../publish/the-app-certification-process.md#in-the-store)アプリの認定プロセスにステップ インします。

アプリの対象が 13 歳未満の子供である場合、児童オンライン プライバシー保護法 ("COPPA") に従って、このセクションで **[This application is directed at children under the age of 13]** (このアプリは 13 歳未満の子供を対象としています) を選ぶ必要があります。 このオプションを選んだ場合、マイクロソフトはアプリに広告を配信する際に、行動広告サービスを無効にする手順を実行します。

選んだ **COPPA 準拠**設定は、選んだアプリのすべての広告ユニットに自動的に適用されます。

> [!IMPORTANT]
> アプリの対象が 13 歳未満の子供である場合、COPPA の下で特定の義務が発生します。 義務について詳しくは、[こちらのページ](https://go.microsoft.com/fwlink/p/?linkid=536558)をご覧ください。
