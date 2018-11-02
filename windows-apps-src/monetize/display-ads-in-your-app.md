---
author: Xansky
ms.assetid: 63A9EDCF-A418-476C-8677-D8770B45D1D7
description: Microsoft Advertising SDK は、アプリに広告を表示して収益を得るためのいくつかの方法を提供します。
title: Microsoft Advertising SDK を使用したアプリでの広告の表示
ms.author: mhopkins
ms.date: 06/20/2018
ms.topic: article
keywords: Windows 10, UWP, 広告, 宣伝, バナー, 広告コントロール, スポット広告
ms.localizationpriority: medium
ms.openlocfilehash: 7acf2424a7d2fee322ba799ec670f0576b33a208
ms.sourcegitcommit: 144f5f127fc4fbd852f2f6780ef26054192d68fc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/02/2018
ms.locfileid: "5970671"
---
# <a name="display-ads-in-your-app-with-the-microsoft-advertising-sdk"></a><span data-ttu-id="d2526-104">Microsoft Advertising SDK を使用したアプリでの広告の表示</span><span class="sxs-lookup"><span data-stu-id="d2526-104">Display ads in your app with the Microsoft Advertising SDK</span></span>

<span data-ttu-id="d2526-105">Microsoft Advertising SDK を使用して、Windows 10 用ユニバーサル Windows プラットフォーム (UWP) アプリに広告を配置することで、収益機会を増やせます。</span><span class="sxs-lookup"><span data-stu-id="d2526-105">Increase your revenue opportunities by putting ads in your Universal Windows Platform (UWP) app for Windows 10 by using the Microsoft Advertising SDK.</span></span> <span data-ttu-id="d2526-106">広告の収益化プラットフォームでは、さまざまな多くの一般的な広告ネットワークと、アプリとがサポートされますメディエーションにシームレスに統合できる広告形式を提供します。</span><span class="sxs-lookup"><span data-stu-id="d2526-106">Our ad monetization platform offers a variety of ad formats that can be seamlessly integrated into your apps and supports mediation with many popular ad networks.</span></span> <span data-ttu-id="d2526-107">プラットフォームは OpenRTB、膨大な 2.x、MRAID 2、および VPAID 3 標準に準拠していると互換性が堀と IAS します。</span><span class="sxs-lookup"><span data-stu-id="d2526-107">Our platform is compliant with the OpenRTB, VAST 2.x, MRAID 2, and VPAID 3 standards and is compatible with MOAT and IAS.</span></span> 

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
<td align="left"><b><span data-ttu-id="d2526-108">使ってみる</span><span class="sxs-lookup"><span data-stu-id="d2526-108">Get started</span></span></b><br/><br/>
    <a href="http://aka.ms/ads-sdk-uwp"><span data-ttu-id="d2526-109">Microsoft Advertising SDK のインストール</span><span class="sxs-lookup"><span data-stu-id="d2526-109">Install the Microsoft Advertising SDK</span></span></a>
</td>
<td align="left"><img src="images/write-code.png" alt="Develop icon" /></td>
<td align="left"><b><span data-ttu-id="d2526-110">開発者向けガイド</span><span class="sxs-lookup"><span data-stu-id="d2526-110">Developer guides</span></span></b><br/><br/>
    <a href="banner-ads.md"><span data-ttu-id="d2526-111">バナー広告</span><span class="sxs-lookup"><span data-stu-id="d2526-111">Banner ads</span></span></a>
    <br/>
    <a href="interstitial-ads.md"><span data-ttu-id="d2526-112">スポット広告</span><span class="sxs-lookup"><span data-stu-id="d2526-112">Interstitial ads</span></span></a>
    <br/>
    <a href="native-ads.md"><span data-ttu-id="d2526-113">ネイティブ広告</span><span class="sxs-lookup"><span data-stu-id="d2526-113">Native ads</span></span></a>
    </td>
<td align="left"><img src="images/api-reference.png" alt="API ref icon" /></td>
<td align="left"><b><span data-ttu-id="d2526-114">その他のリソース</span><span class="sxs-lookup"><span data-stu-id="d2526-114">Other resources</span></span></b><br/><br/>
    <a href="set-up-ad-units-in-your-app.md"><span data-ttu-id="d2526-115">アプリの広告ユニットをセットアップする</span><span class="sxs-lookup"><span data-stu-id="d2526-115">Set up ad units in your app</span></span></a>
    <br/>
    <a href="best-practices-for-ads-in-apps.md"><span data-ttu-id="d2526-116">ベスト プラクティス</span><span class="sxs-lookup"><span data-stu-id="d2526-116">Best practices</span></span></a>
    <br/>
    <a href="https://msdn.microsoft.com/en-us/library/windows/apps/mt691884.aspx"><span data-ttu-id="d2526-117">API リファレンス</span><span class="sxs-lookup"><span data-stu-id="d2526-117">API reference</span></span></a>
    </td>
</tr>
</tbody>
</table>

## <a name="step-1-install-the-microsoft-advertising-sdk"></a><span data-ttu-id="d2526-118">手順 1: Microsoft Advertising SDK をインストールする</span><span class="sxs-lookup"><span data-stu-id="d2526-118">Step 1: Install the Microsoft Advertising SDK</span></span>

<span data-ttu-id="d2526-119">まず、アプリの構築に使用する開発用コンピューターに [Microsoft Advertising SDK](http://aka.ms/ads-sdk-uwp) をインストールします。</span><span class="sxs-lookup"><span data-stu-id="d2526-119">To get started, install the [Microsoft Advertising SDK](http://aka.ms/ads-sdk-uwp) on the development computer you use to build your app.</span></span> <span data-ttu-id="d2526-120">インストール手順については、[この記事](install-the-microsoft-advertising-libraries.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d2526-120">For installation instructions, see [this article](install-the-microsoft-advertising-libraries.md).</span></span>

## <a name="step-2-implement-ads-in-your-app"></a><span data-ttu-id="d2526-121">手順 2: アプリで広告を実装する</span><span class="sxs-lookup"><span data-stu-id="d2526-121">Step 2: Implement ads in your app</span></span>

<span data-ttu-id="d2526-122">Microsoft Advertising SDK では、アプリで使用できるさまざまな種類の広告コントロールを提供しています。</span><span class="sxs-lookup"><span data-stu-id="d2526-122">The Microsoft Advertising SDK provides several different types of ad controls you can use in your app.</span></span> <span data-ttu-id="d2526-123">自分のシナリオに最適な広告の種類を選び、コードをアプリに追加することで、それらの広告を表示します。</span><span class="sxs-lookup"><span data-stu-id="d2526-123">Choose which types of ads are best for your scenario and then add code to your app to display those ads.</span></span> <span data-ttu-id="d2526-124">この手順では、テスト広告ユニットを使用して、テスト中にアプリが広告をレンダリングする方法を確認できます。</span><span class="sxs-lookup"><span data-stu-id="d2526-124">During this step, you will use a test ad unit so you can see how your app renders ads during testing.</span></span>

### <a name="banner-ads"></a><span data-ttu-id="d2526-125">バナー広告</span><span class="sxs-lookup"><span data-stu-id="d2526-125">Banner ads</span></span>

<span data-ttu-id="d2526-126">これらは、アプリ内のページの四角形の部分を利用してプロモーション用のコンテンツを表示する静的な表示広告です。</span><span class="sxs-lookup"><span data-stu-id="d2526-126">These are static display ads that utilize a rectangular portion of a page in your app to display promotional content.</span></span> <span data-ttu-id="d2526-127">これらの広告は、一定間隔で自動的に更新できます。</span><span class="sxs-lookup"><span data-stu-id="d2526-127">These ads can refresh automatically at regular intervals.</span></span> <span data-ttu-id="d2526-128">これは、初めてアプリで広告を行う場合はここから始めることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="d2526-128">This is a good place to start if you are new to advertising in your app.</span></span>

<span data-ttu-id="d2526-129">手順とコード例については、[この記事](adcontrol-in-xaml-and--net.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d2526-129">For instructions and code examples, see [this article](adcontrol-in-xaml-and--net.md).</span></span>

![addreferences](images/banner-ad.png)

### <a name="interstitial-video-and-interstitial-banner-ads"></a><span data-ttu-id="d2526-131">スポット ビデオ広告とスポット バナー広告</span><span class="sxs-lookup"><span data-stu-id="d2526-131">Interstitial video and interstitial banner ads</span></span>

<span data-ttu-id="d2526-132">これは通常、アプリやゲームを続行するために、ビデオを視聴することや広告をクリックスルーすることをユーザーに求める全画面表示の広告です。</span><span class="sxs-lookup"><span data-stu-id="d2526-132">These are full-screen ads that typically require the user to watch a video or click through them to continue in the app or game.</span></span> <span data-ttu-id="d2526-133">サポートしているスポット広告には、ビデオおよびバナーの 2 種類があります。</span><span class="sxs-lookup"><span data-stu-id="d2526-133">We support two types of interstitial ads: video and banner.</span></span>

<span data-ttu-id="d2526-134">手順とコード例については、[この記事](interstitial-ads.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d2526-134">For instructions and code examples, see [this article](interstitial-ads.md).</span></span>

![addreferences](images/interstitial-ad.png)

### <a name="native-ads"></a><span data-ttu-id="d2526-136">ネイティブ広告</span><span class="sxs-lookup"><span data-stu-id="d2526-136">Native ads</span></span>

<span data-ttu-id="d2526-137">これはコンポーネント ベースの広告です。</span><span class="sxs-lookup"><span data-stu-id="d2526-137">These are component-based ads.</span></span> <span data-ttu-id="d2526-138">各広告クリエイティブ (タイトル、画像、説明、行動喚起テキストなど) が、独自のフォント、色、その他の UI コンポーネントを使ってアプリに溶け込ませられる個々の要素として、アプリに配信されます。</span><span class="sxs-lookup"><span data-stu-id="d2526-138">Each piece of the ad creative (such as the title, image, description, and call-to-action text) is delivered to your app as an individual element that you can integrate into your app using your own fonts, colors, and other UI components.</span></span>

<span data-ttu-id="d2526-139">手順とコード例については、[この記事](native-ads.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d2526-139">For instructions and code examples, see [this article](native-ads.md).</span></span>

![addreferences](images/native-ad.png)

<span id="ad-mediation"/>

## <a name="step-3-create-an-ad-unit-and-configure-mediation"></a><span data-ttu-id="d2526-141">手順 3: 広告ユニットを作成し、仲介を構成する</span><span class="sxs-lookup"><span data-stu-id="d2526-141">Step 3: Create an ad unit and configure mediation</span></span>

<span data-ttu-id="d2526-142">アプリのテストが完了し、ストアに提出する準備ができたら、パートナー センターで[アプリ内広告](../publish/in-app-ads.md)] ページで広告ユニットを作成します。</span><span class="sxs-lookup"><span data-stu-id="d2526-142">After you finish testing your app and you are ready to submit it to the Store, create an ad unit on the [In-app ads](../publish/in-app-ads.md) page in Partner Center.</span></span> <span data-ttu-id="d2526-143">次に、アプリがライブ広告を受信できるように、この広告ユニットを使用するようにアプリのコードを更新します。</span><span class="sxs-lookup"><span data-stu-id="d2526-143">Then, update your app code to use this ad unit so that your app will receive live ads.</span></span> <span data-ttu-id="d2526-144">詳しくは、「[アプリの広告ユニットをセットアップする](set-up-ad-units-in-your-app.md#live-ad-units)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d2526-144">For more information, see [Set up ad units in your app](set-up-ad-units-in-your-app.md#live-ad-units).</span></span>

<span data-ttu-id="d2526-145">既定では、アプリはマイクロソフトの有料広告ネットワークの広告を表示します。</span><span class="sxs-lookup"><span data-stu-id="d2526-145">By default, your app will show ads from Microsoft's network for paid ads.</span></span> <span data-ttu-id="d2526-146">広告の収益を最大化するには、広告ユニットの[広告仲介](ad-mediation-service.md)を有効化することで、Taboola や Smaato など、その他の有料広告ネットワークの広告を表示できます。</span><span class="sxs-lookup"><span data-stu-id="d2526-146">To maximize your ad revenue, you can enable [ad mediation](ad-mediation-service.md) for your ad unit to display ads from additional paid ad networks such as Taboola and Smaato.</span></span> <span data-ttu-id="d2526-147">また、Microsoft アプリ プロモーション キャンペーンの広告を用意することでも、アプリ プロモーション機能を強化できます。</span><span class="sxs-lookup"><span data-stu-id="d2526-147">You can also increase your app promotion capabilities by serving ads from Microsoft app promotion campaigns.</span></span>

<span data-ttu-id="d2526-148">UWP アプリで広告仲介の使用を開始するには、広告ユニットの[広告仲介の設定を構成](../publish/in-app-ads.md#mediation-settings)します。</span><span class="sxs-lookup"><span data-stu-id="d2526-148">To start using ad mediation in your UWP app, [configure ad mediation settings](../publish/in-app-ads.md#mediation-settings) for your ad unit.</span></span> <span data-ttu-id="d2526-149">既定では、アプリがサポートする市場全体で広告の収益を最大化できるように、機械学習アルゴリズムを使った仲介設定が自動的に構成されます。</span><span class="sxs-lookup"><span data-stu-id="d2526-149">By default, we automatically configure the mediation settings using machine-learning algorithms to help you maximize your ad revenue across the markets your app supports.</span></span> <span data-ttu-id="d2526-150">ただし、使用するネットワークを手動で選ぶこともできます。</span><span class="sxs-lookup"><span data-stu-id="d2526-150">However, you also have the option to manually choose the networks you want to use.</span></span> <span data-ttu-id="d2526-151">どちらの方法でも、仲介設定はすべてサーバーで構成されます。アプリのコードを変更する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="d2526-151">Either way, the mediation settings are configured entirely on our servers; you do not need to make any code changes in your app.</span></span>    

## <a name="step-4-submit-your-app-and-review-performance"></a><span data-ttu-id="d2526-152">手順 4: アプリを提出してパフォーマンスを確認する</span><span class="sxs-lookup"><span data-stu-id="d2526-152">Step 4: Submit your app and review performance</span></span>

<span data-ttu-id="d2526-153">広告を含むアプリの開発が完了したら、ストアで利用できるようにするパートナー センターでの[更新されたアプリを提出](https://docs.microsoft.com/windows/uwp/publish/app-submissions)することができます。</span><span class="sxs-lookup"><span data-stu-id="d2526-153">After you finish developing your app with ads, you can [submit your updated app](https://docs.microsoft.com/windows/uwp/publish/app-submissions) in Partner Center to make it available in the Store.</span></span> <span data-ttu-id="d2526-154">広告を表示するアプリは、[Microsoft Store ポリシーの第 10.10 項](https://docs.microsoft.com/legal/windows/agreements/store-policies#1010-advertising-conduct-and-content)と、[アプリ開発者契約の追加条項 E](https://docs.microsoft.com/legal/windows/agreements/app-developer-agreement) で指定されたその他の要件を満たしている必要があります。</span><span class="sxs-lookup"><span data-stu-id="d2526-154">Apps that display ads must meet the additional requirements that are specified in [section 10.10 of the Microsoft Store Policies](https://docs.microsoft.com/legal/windows/agreements/store-policies#1010-advertising-conduct-and-content) and [Exhibit E of the App Developer Agreement](https://docs.microsoft.com/legal/windows/agreements/app-developer-agreement).</span></span>

<span data-ttu-id="d2526-155">後、アプリが公開されてストア、パートナー センターで、[広告パフォーマンス レポート](../publish/advertising-performance-report.md)を確認し、引き続き、広告のパフォーマンスを最適化するために、仲介設定を変更できます。</span><span class="sxs-lookup"><span data-stu-id="d2526-155">After your app is published and available in the Store, you can review your [advertising performance reports](../publish/advertising-performance-report.md) in Partner Center and continue to make changes to your mediation settings to optimize the performance of your ads.</span></span> <span data-ttu-id="d2526-156">広告の収益は[入金状況](../publish/payout-summary.md)に表示されます。</span><span class="sxs-lookup"><span data-stu-id="d2526-156">Your advertising revenue is included in your [payout summary](../publish/payout-summary.md).</span></span>

<span id="additional-help" />

## <a name="additional-help"></a><span data-ttu-id="d2526-157">追加のヘルプ</span><span class="sxs-lookup"><span data-stu-id="d2526-157">Additional help</span></span>

<span data-ttu-id="d2526-158">Microsoft Advertising SDK の使用に関するその他のヘルプについては、次のリソースを参照してください。</span><span class="sxs-lookup"><span data-stu-id="d2526-158">For additional help using the Microsoft Advertising SDK, use the following resources.</span></span>

|  <span data-ttu-id="d2526-159">タスク</span><span class="sxs-lookup"><span data-stu-id="d2526-159">Task</span></span>    | <span data-ttu-id="d2526-160">リソース</span><span class="sxs-lookup"><span data-stu-id="d2526-160">Resource</span></span> |               
|----------|-------|
| <span data-ttu-id="d2526-161">広告のバグを報告したり個別のサポートを受けたりする</span><span class="sxs-lookup"><span data-stu-id="d2526-161">Report a bug or get assisted support for advertising</span></span>     | <span data-ttu-id="d2526-162">[サポート ページ](https://developer.microsoft.com/en-us/windows/support)にアクセスし、**[アプリ内広告]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="d2526-162">Visit the [support page](https://developer.microsoft.com/en-us/windows/support) and choose **Ads-In-Apps**.</span></span>        |
| <span data-ttu-id="d2526-163">コミュニティ サポートを受ける</span><span class="sxs-lookup"><span data-stu-id="d2526-163">Get community support</span></span>     | <span data-ttu-id="d2526-164">[フォーラム](http://go.microsoft.com/fwlink/p/?LinkId=401266)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d2526-164">Visit the [forum](http://go.microsoft.com/fwlink/p/?LinkId=401266).</span></span>       |
| <span data-ttu-id="d2526-165">バナーやスポット広告をアプリに追加する方法を説明するサンプル プロジェクトをダウンロードする</span><span class="sxs-lookup"><span data-stu-id="d2526-165">Download sample projects that demonstrate how to add banner and interstitial ads to apps.</span></span>     | <span data-ttu-id="d2526-166">「[GitHub の広告サンプル](http://aka.ms/githubads)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d2526-166">See the [Advertising samples on GitHub](http://aka.ms/githubads).</span></span>       |
| <span data-ttu-id="d2526-167">Windows アプリの最新の収益機会について学ぶ</span><span class="sxs-lookup"><span data-stu-id="d2526-167">Learn about the latest monetization opportunities for Windows apps</span></span>     | <span data-ttu-id="d2526-168">「[アプリの収益の獲得](https://developer.microsoft.com/store/monetize)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d2526-168">Visit [Monetize your apps](https://developer.microsoft.com/store/monetize).</span></span>        |

## <a name="windows-81-and-windows-phone-8x-apps"></a><span data-ttu-id="d2526-169">Windows8.1 と Windows Phone 8.x のアプリ</span><span class="sxs-lookup"><span data-stu-id="d2526-169">Windows 8.1 and Windows Phone 8.x apps</span></span>

<span data-ttu-id="d2526-170">Windows 8.1 および Windows Phone 8.x 用のアプリについては、[Windows および Windows Phone 8.x 用の Microsoft Advertising SDK](http://aka.ms/store-8-sdk) を提供しています。</span><span class="sxs-lookup"><span data-stu-id="d2526-170">For Windows 8.1 and Windows Phone 8.x apps, we provide the [Microsoft Advertising SDK for Windows and Windows Phone 8.x](http://aka.ms/store-8-sdk).</span></span> <span data-ttu-id="d2526-171">Windows 8.1 または Windows Phone 8.x アプリでこの SDK を使用して広告を表示する方法について詳しくは、[この記事](https://docs.microsoft.com/en-us/previous-versions/windows/apps/dn792120(v=win.10))をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d2526-171">For more information about using this SDK to show ads in Windows 8.1 and Windows Phone 8.x apps, see [this article](https://docs.microsoft.com/en-us/previous-versions/windows/apps/dn792120(v=win.10)).</span></span>

## <a name="related-topics"></a><span data-ttu-id="d2526-172">関連トピック</span><span class="sxs-lookup"><span data-stu-id="d2526-172">Related topics</span></span>

* [<span data-ttu-id="d2526-173">Microsoft Advertising SDK</span><span class="sxs-lookup"><span data-stu-id="d2526-173">Microsoft Advertising SDK</span></span>](http://aka.ms/ads-sdk-uwp)
* [<span data-ttu-id="d2526-174">[広告パフォーマンス] レポート</span><span class="sxs-lookup"><span data-stu-id="d2526-174">Advertising performance report</span></span>](../publish/advertising-performance-report.md)
* [<span data-ttu-id="d2526-175">Windows Premium Ads Publishers Program</span><span class="sxs-lookup"><span data-stu-id="d2526-175">Windows Premium Ads Publishers Program</span></span>](windows-premium-ads-publishers-program.md)
