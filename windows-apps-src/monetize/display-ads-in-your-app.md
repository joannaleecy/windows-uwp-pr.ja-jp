---
author: mcleanbyron
ms.assetid: 63A9EDCF-A418-476C-8677-D8770B45D1D7
description: "Microsoft Advertising SDK は、アプリに広告を表示して収益を得るためのいくつかの方法を提供します。"
title: "Microsoft Advertising SDK を使用したアプリでの広告の表示"
ms.author: mcleans
ms.date: 07/20/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, 広告, 宣伝, バナー, 広告コントロール, スポット広告"
ms.openlocfilehash: 4730ebaf55af8e7063c444d5b3bbd973b0508db2
ms.sourcegitcommit: a9e4be98688b3a6125fd5dd126190fcfcd764f95
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/21/2017
---
# <a name="display-ads-in-your-app-with-the-microsoft-advertising-sdk"></a>Microsoft Advertising SDK を使用したアプリでの広告の表示

Microsoft Advertising SDK を使用して、アプリに広告を配置することで、収益機会を増やせます。 マイクロソフトの広告の収益化プラットフォームは、さまざまな種類の広告を提供し、人気のある多くの広告ネットワークとの仲介をサポートします。

アプリに広告を表示するには、次の手順に従います。

## <a name="step-1-install-the-microsoft-advertising-sdk"></a>手順 1: Microsoft Advertising SDK をインストールする

Microsoft Advertising SDK では、さまざまな種類の広告を表示するためにアプリで使用できる各種コントロールを用意しています。 インストール手順については、[この記事](install-the-microsoft-advertising-libraries.md)をご覧ください。

## <a name="step-2-choose-your-ad-type-and-add-code-to-display-test-ads-in-your-app"></a>手順 2: 広告の種類を選択し、コードを追加して、アプリにテスト広告を表示する

Microsoft Advertising SDK では、アプリに表示できるさまざまな種類の広告を提供しています。 自分のシナリオに最適な広告の種類を選び、コードをアプリに追加することで、それらの広告を表示します。

アプリに広告を用意するには、コードでアプリケーション ID と広告ユニット ID を指定しなければなりません。 アプリの開発中は、[テスト用のアプリケーション ID と広告ユニット ID の値](test-mode-values.md)を使って、テスト時にアプリでどのように広告がレンダリングされるかを確認する必要があります。

### <a name="banner-ads"></a>バナー広告

これはアプリ内のページの一部分 (多くの場合、アプリの上部または下部) を利用する静的な表示広告です。

手順とコード例については、「[XAML および .NET の AdControl](adcontrol-in-xaml-and--net.md)」または「[HTML 5 および Javascript の AdControl](adcontrol-in-html-5-and-javascript.md)」をご覧ください。 C# と C++ を使って JavaScript/HTML アプリと XAML アプリにバナー広告を追加する方法を示す完全なサンプル プロジェクトについては、[GitHub の広告サンプル](http://aka.ms/githubads)をご覧ください。

![addreferences](images/banner-ad.png)

### <a name="interstitial-ads"></a>スポット広告

これは通常、アプリやゲームを続行するために、ビデオを視聴することや広告をクリックスルーすることをユーザーに求める全画面表示の広告です。 サポートしているスポット広告には、ビデオおよびバナーの 2 種類があります。

手順とコード例については、「[スポット広告](interstitial-ads.md)」をご覧ください。 C# と C++ を使って JavaScript/HTML アプリと XAML アプリにスポット広告を追加する方法を示す完全なサンプル プロジェクトについては、[GitHub の広告サンプル](http://aka.ms/githubads)をご覧ください。

![addreferences](images/interstitial-ad.png)

### <a name="native-ads"></a>ネイティブ広告

これはコンポーネント ベースの広告です。 各広告クリエイティブ (タイトル、画像、説明、行動喚起テキストなど) が、独自のフォント、色、その他の UI コンポーネントを使ってアプリに溶け込ませられる個々の要素として、アプリに配信され、控えめなユーザー エクスペリエンスをまとめます。

手順とコード例については、「[ネイティブ広告](native-ads.md)」をご覧ください。

![addreferences](images/native-ad.png)

## <a name="step-3-get-an-ad-unit-from-dev-center-and-configure-your-app-to-receive-live-ads"></a>手順 3: デベロッパー センターから広告ユニットを取得し、ライブ広告を受信するようにアプリを構成する

アプリのテストが完了し、ストアにそのアプリを提出する準備ができたら、Windows デベロッパー センター ダッシュボードの [[広告で収入を増やす](../publish/monetize-with-ads.md)] ページで広告ユニットを作成します。 次に、この広告ユニットのアプリケーション ID と広告ユニット ID の値を使用するように、アプリのコードを更新します。 ストアで公開されているバージョンのアプリで、テスト用のアプリケーション ID と広告ユニット ID の値を使用しようとしても、ライブ広告は受信されません。 詳しくは、「[アプリの広告ユニットをセットアップする](set-up-ad-units-in-your-app.md)」をご覧ください。

<span id="ad-mediation"/>
### <a name="configure-ad-mediation"></a>広告仲介を構成する

既定では、バナー広告、スポット広告、およびネイティブ広告には Microsoft の有料広告ネットワークの広告が表示されます。 広告の収益を最大化するには、広告ユニットの広告仲介を有効化することで、Taboola や Smaato など、その他の有料広告ネットワークの広告を表示できます。 また、Microsoft アプリ プロモーション キャンペーンの広告を用意することでも、アプリ プロモーション機能を強化できます。

UWP アプリで広告仲介の使用を開始するには、広告ユニットの[広告仲介の設定を構成](../publish/monetize-with-ads.md#mediation)します。 既定では、アプリがサポートする市場全体で広告の収益を最大化できるように、機械学習アルゴリズムを使った仲介設定が自動的に構成されます。 ただし、使うネットワークを手動で選ぶオプションもあります。 どちらの方法でも、仲介設定はすべてサービスで構成されます。アプリのコードを変更する必要はありません。    

<span id="8.x-mediation"/>
### <a name="mediation-in-windows-81-and-windows-phone-8x-apps"></a>Windows 8.1 と Windows Phone 8.x アプリにおける仲介

Windows 8.1 と Windows Phone 8.x アプリでは、広告仲介はバナー広告にのみ利用できます。 広告仲介を使うには、**AdControl** クラスの代わりに [Windows および Windows Phone 8.x 用 Microsoft Advertising SDK](http://aka.ms/store-8-sdk) の **AdMediatorControl** クラスを使う必要があります。 このコントロールをアプリに追加すると、ダッシュボードで広告仲介設定を手動で構成できます。

Windows 8.1 または Windows Phone 8.x アプリで広告仲介を使う方法について詳しくは、[この記事](https://msdn.microsoft.com/library/windows/apps/xaml/dn864359.aspx)をご覧ください。

> [!NOTE]
> Windows 8.1 および Windows Phone 8.x アプリの広告仲介は、アクティブな開発対象ではなくなりました。 広告収益の可能性を最大限に引き出すため、バナー広告、スポット広告、またはネイティブ広告で広告仲介を使う UWP アプリを構築することをお勧めします。

## <a name="step-4-submit-your-app-and-review-performance"></a>手順 4: アプリを提出してパフォーマンスを確認する

広告を含むアプリの開発が完了したら、デベロッパー センター ダッシュボードに[更新したアプリを提出](https://msdn.microsoft.com/windows/uwp/publish/app-submissions)できます。それにより、ストアでアプリを利用できるようになります。 広告を表示するアプリは、[Windows ストア ポリシーの第 10.10 項](https://msdn.microsoft.com/library/windows/apps/dn764944.aspx#pol_10_10) と、[アプリ開発者契約の追加条項 E](https://msdn.microsoft.com/library/windows/apps/hh694058.aspx) で指定されたその他の要件を満たしている必要があります。

アプリがストアで公開されて利用できるようになったら、ダッシュボードで[広告パフォーマンス レポート](../publish/advertising-performance-report.md)を確認して、継続的に仲介の設定に変更を加えることで、広告のパフォーマンスを最適化できます。 広告の収益は[入金状況](../publish/payout-summary.md)に表示されます。

<span id="additional-help" />
## <a name="additional-help"></a>追加のヘルプ

Microsoft Advertising SDK の使用に関するその他のヘルプについては、次のリソースを参照してください。

|  タスク    | リソース |               
|----------|-------|
| 広告のバグを報告したり個別のサポートを受けたりする     | [サポート ページ](https://go.microsoft.com/fwlink/p/?LinkId=331508)にアクセスし、**[In-App 広告]** を選択します。        |
| コミュニティ サポートを受ける     | [フォーラム](http://go.microsoft.com/fwlink/p/?LinkId=401266)をご覧ください。       |
| バナーやスポット広告をアプリに追加する方法を説明するサンプル プロジェクトをダウンロードする     | 「[GitHub の広告サンプル](http://aka.ms/githubads)」をご覧ください。       |
| Windows アプリの最新の収益機会について学ぶ     | 「[アプリの収益の獲得](https://developer.microsoft.com/store/monetize)」をご覧ください。        |

## <a name="related-topics"></a>関連トピック

* [Microsoft Advertising SDK](http://aka.ms/ads-sdk-uwp)
* [広告によるアプリの収益の獲得](http://go.microsoft.com/fwlink/p/?LinkId=699559)
* [広告パフォーマンス レポート](../publish/advertising-performance-report.md)
