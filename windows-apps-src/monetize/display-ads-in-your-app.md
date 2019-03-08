---
ms.assetid: 63A9EDCF-A418-476C-8677-D8770B45D1D7
description: Microsoft Advertising SDK は、アプリに広告を表示して収益を得るためのいくつかの方法を提供します。
title: Microsoft Advertising SDK を使用したアプリでの広告の表示
ms.date: 06/20/2018
ms.topic: article
keywords: Windows 10, UWP, 広告, 宣伝, バナー, 広告コントロール, スポット広告
ms.localizationpriority: medium
ms.openlocfilehash: 84ed7f5f1eb65f06a47e92de962777ca9d3c50c7
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57658497"
---
# <a name="display-ads-in-your-app-with-the-microsoft-advertising-sdk"></a>Microsoft Advertising SDK を使用したアプリでの広告の表示

Microsoft Advertising SDK を使用して、Windows 10 用ユニバーサル Windows プラットフォーム (UWP) アプリに広告を配置することで、収益機会を増やせます。 この ad 収益化のプラットフォームでは、さまざまな多くの一般的な ad ネットワークで、アプリとサポートの仲介にシームレスに統合できる ad 形式を提供します。 マイクロソフトのプラットフォームは、OpenRTB、VAST 2.x、MRAID 2、および VPAID 3 の各標準に準拠しており、MOAT および IAS と互換性があります。 

<br/>

<table style="border: none !important;">
<colgroup>
<col width="10%" />
<col width="23%" />
<col width="10%" />
<col width="23%" />
<col width="10%" />
<col width="23%" />
</colgroup>
<tbody>
<tr>
<td align="left"><img src="images/install-sdk.png" alt="Install SDK icon" /></td>
<td align="left"><b>作業の開始</b><br/><br/>
    <a href="https://aka.ms/ads-sdk-uwp">Microsoft Advertising SDK をインストールします。</a>
</td>
<td align="left"><img src="images/write-code.png" alt="Develop icon" /></td>
<td align="left"><b>開発者ガイド</b><br/><br/>
    <a href="banner-ads.md">バナー広告</a>
    <br/>
    <a href="interstitial-ads.md">スポット広告</a>
    <br/>
    <a href="native-ads.md">ネイティブの広告</a>
    </td>
<td align="left"><img src="images/api-reference.png" alt="API ref icon" /></td>
<td align="left"><b>その他のリソース</b><br/><br/>
    <a href="set-up-ad-units-in-your-app.md">アプリでの ad 単位を設定します</a>
    <br/>
    <a href="best-practices-for-ads-in-apps.md">ベスト プラクティス</a>
    <br/>
    <a href="https://msdn.microsoft.com/en-us/library/windows/apps/mt691884.aspx">API リファレンス</a>
    </td>
</tr>
</tbody>
</table>

## <a name="step-1-install-the-microsoft-advertising-sdk"></a>手順 1:Microsoft Advertising SDK のインストール

まず、アプリの構築に使用する開発用コンピューターに [Microsoft Advertising SDK](https://aka.ms/ads-sdk-uwp) をインストールします。 インストール手順については、[この記事](install-the-microsoft-advertising-libraries.md)をご覧ください。

## <a name="step-2-implement-ads-in-your-app"></a>手順 2:アプリでの広告の実装

Microsoft Advertising SDK では、アプリで使用できるさまざまな種類の広告コントロールを提供しています。 自分のシナリオに最適な広告の種類を選び、コードをアプリに追加することで、それらの広告を表示します。 この手順では、テスト広告ユニットを使用して、テスト中にアプリが広告をレンダリングする方法を確認できます。

### <a name="banner-ads"></a>バナー広告

これらは、アプリ内のページの四角形の部分を利用してプロモーション用のコンテンツを表示する静的な表示広告です。 これらの広告は、一定間隔で自動的に更新できます。 これは、初めてアプリで広告を行う場合はここから始めることをお勧めします。

手順とコード例については、[この記事](adcontrol-in-xaml-and--net.md)をご覧ください。

![addreferences](images/banner-ad.png)

### <a name="interstitial-video-and-interstitial-banner-ads"></a>スポット ビデオ広告とスポット バナー広告

これは通常、アプリやゲームを続行するために、ビデオを視聴することや広告をクリックスルーすることをユーザーに求める全画面表示の広告です。 サポートしているスポット広告には、ビデオおよびバナーの 2 種類があります。

手順とコード例については、[この記事](interstitial-ads.md)をご覧ください。

![addreferences](images/interstitial-ad.png)

### <a name="native-ads"></a>ネイティブ広告

これはコンポーネント ベースの広告です。 各広告クリエイティブ (タイトル、画像、説明、行動喚起テキストなど) が、独自のフォント、色、その他の UI コンポーネントを使ってアプリに溶け込ませられる個々の要素として、アプリに配信されます。

手順とコード例については、[この記事](native-ads.md)をご覧ください。

![addreferences](images/native-ad.png)

<span id="ad-mediation"/>

## <a name="step-3-create-an-ad-unit-and-configure-mediation"></a>手順 3:Ad 単位を作成し、仲介の構成

アプリのテストを完了して、ストアに提出する準備が完了したら後で、ad 単位を作成する、[アプリ内広告](../publish/in-app-ads.md)パートナー センターでのページ。 次に、アプリがライブ広告を受信できるように、この広告ユニットを使用するようにアプリのコードを更新します。 詳しくは、「[アプリの広告ユニットをセットアップする](set-up-ad-units-in-your-app.md#live-ad-units)」をご覧ください。

既定では、アプリはマイクロソフトの有料広告ネットワークの広告を表示します。 広告の収益を最大化するには、広告ユニットの[広告仲介](ad-mediation-service.md)を有効化することで、Taboola や Smaato など、その他の有料広告ネットワークの広告を表示できます。 また、Microsoft アプリ プロモーション キャンペーンの広告を用意することでも、アプリ プロモーション機能を強化できます。

UWP アプリで広告仲介の使用を開始するには、広告ユニットの[広告仲介の設定を構成](../publish/in-app-ads.md#mediation-settings)します。 既定では、アプリがサポートする市場全体で広告の収益を最大化できるように、機械学習アルゴリズムを使った仲介設定が自動的に構成されます。 ただし、使用するネットワークを手動で選ぶこともできます。 どちらの方法でも、仲介設定はすべてサーバーで構成されます。アプリのコードを変更する必要はありません。    

## <a name="step-4-submit-your-app-and-review-performance"></a>手順 4:アプリを提出してパフォーマンスを確認する

後に広告を使用してアプリの開発が完了したら、[更新されたアプリの提出](https://docs.microsoft.com/windows/uwp/publish/app-submissions)ストアで使用できるように、パートナー センターでします。 広告を表示するアプリは、[Microsoft Store ポリシーの第 10.10 項](https://docs.microsoft.com/legal/windows/agreements/store-policies#1010-advertising-conduct-and-content)と、[アプリ開発者契約の追加条項 E](https://docs.microsoft.com/legal/windows/agreements/app-developer-agreement) で指定されたその他の要件を満たしている必要があります。

アプリを発行すると、ストアで使用可能な確認すること、[広告のパフォーマンス レポート](../publish/advertising-performance-report.md)パートナー センターで続行、ads のパフォーマンスを最適化するために、仲介の設定を変更するとします。 広告の収益は[入金状況](../publish/payout-summary.md)に表示されます。

<span id="additional-help" />

## <a name="additional-help"></a>追加のヘルプ

Microsoft Advertising SDK の使用に関するその他のヘルプについては、次のリソースを参照してください。

|  タスク    | リソース |               
|----------|-------|
| 広告のバグを報告したり個別のサポートを受けたりする     | [サポート ページ](https://developer.microsoft.com/en-us/windows/support)にアクセスし、**[アプリ内広告]** を選択します。        |
| コミュニティ サポートを受ける     | [フォーラム](https://go.microsoft.com/fwlink/p/?LinkId=401266)をご覧ください。       |
| バナーやスポット広告をアプリに追加する方法を説明するサンプル プロジェクトをダウンロードします。     | 「[GitHub の広告サンプル](https://aka.ms/githubads)」をご覧ください。       |
| Windows アプリの最新の収益機会について学ぶ     | 「[アプリの収益の獲得](https://developer.microsoft.com/store/monetize)」をご覧ください。        |

## <a name="windows-81-and-windows-phone-8x-apps"></a>Windows 8.1 と Windows Phone 8.x のアプリ

Windows 8.1 および Windows Phone 8.x 用のアプリについては、[Windows および Windows Phone 8.x 用の Microsoft Advertising SDK](https://aka.ms/store-8-sdk) を提供しています。 Windows 8.1 または Windows Phone 8.x アプリでこの SDK を使用して広告を表示する方法について詳しくは、[この記事](https://docs.microsoft.com/en-us/previous-versions/windows/apps/dn792120(v=win.10))をご覧ください。

## <a name="related-topics"></a>関連トピック

* [Microsoft Advertising SDK](https://aka.ms/ads-sdk-uwp)
* [広告パフォーマンス レポート](../publish/advertising-performance-report.md)
* [Windows Premium 広告の発行元のプログラム](windows-premium-ads-publishers-program.md)
