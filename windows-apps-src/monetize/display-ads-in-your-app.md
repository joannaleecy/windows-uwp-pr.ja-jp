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
# <a name="display-ads-in-your-app-with-the-microsoft-advertising-sdk"></a><span data-ttu-id="f4ee8-104">Microsoft Advertising SDK を使用したアプリでの広告の表示</span><span class="sxs-lookup"><span data-stu-id="f4ee8-104">Display ads in your app with the Microsoft Advertising SDK</span></span>

<span data-ttu-id="f4ee8-105">Microsoft Advertising SDK を使用して、Windows 10 用ユニバーサル Windows プラットフォーム (UWP) アプリに広告を配置することで、収益機会を増やせます。</span><span class="sxs-lookup"><span data-stu-id="f4ee8-105">Increase your revenue opportunities by putting ads in your Universal Windows Platform (UWP) app for Windows 10 by using the Microsoft Advertising SDK.</span></span> <span data-ttu-id="f4ee8-106">この ad 収益化のプラットフォームでは、さまざまな多くの一般的な ad ネットワークで、アプリとサポートの仲介にシームレスに統合できる ad 形式を提供します。</span><span class="sxs-lookup"><span data-stu-id="f4ee8-106">Our ad monetization platform offers a variety of ad formats that can be seamlessly integrated into your apps and supports mediation with many popular ad networks.</span></span> <span data-ttu-id="f4ee8-107">マイクロソフトのプラットフォームは、OpenRTB、VAST 2.x、MRAID 2、および VPAID 3 の各標準に準拠しており、MOAT および IAS と互換性があります。</span><span class="sxs-lookup"><span data-stu-id="f4ee8-107">Our platform is compliant with the OpenRTB, VAST 2.x, MRAID 2, and VPAID 3 standards and is compatible with MOAT and IAS.</span></span> 

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
<td align="left"><span data-ttu-id="f4ee8-108"><b>作業の開始</b></span><span class="sxs-lookup"><span data-stu-id="f4ee8-108"><b>Get started</b></span></span><br/><br/><span data-ttu-id="f4ee8-109">
    <a href="https://aka.ms/ads-sdk-uwp">Microsoft Advertising SDK をインストールします。</a>
</span><span class="sxs-lookup"><span data-stu-id="f4ee8-109">
    <a href="https://aka.ms/ads-sdk-uwp">Install the Microsoft Advertising SDK</a>
</span></span></td>
<td align="left"><img src="images/write-code.png" alt="Develop icon" /></td>
<td align="left"><span data-ttu-id="f4ee8-110"><b>開発者ガイド</b></span><span class="sxs-lookup"><span data-stu-id="f4ee8-110"><b>Developer guides</b></span></span><br/><br/><span data-ttu-id="f4ee8-111">
    <a href="banner-ads.md">バナー広告</a>
    </span><span class="sxs-lookup"><span data-stu-id="f4ee8-111">
    <a href="banner-ads.md">Banner ads</a>
    </span></span><br/><span data-ttu-id="f4ee8-112">
    <a href="interstitial-ads.md">スポット広告</a>
    </span><span class="sxs-lookup"><span data-stu-id="f4ee8-112">
    <a href="interstitial-ads.md">Interstitial ads</a>
    </span></span><br/><span data-ttu-id="f4ee8-113">
    <a href="native-ads.md">ネイティブの広告</a>
    </span><span class="sxs-lookup"><span data-stu-id="f4ee8-113">
    <a href="native-ads.md">Native ads</a>
    </span></span></td>
<td align="left"><img src="images/api-reference.png" alt="API ref icon" /></td>
<td align="left"><span data-ttu-id="f4ee8-114"><b>その他のリソース</b></span><span class="sxs-lookup"><span data-stu-id="f4ee8-114"><b>Other resources</b></span></span><br/><br/><span data-ttu-id="f4ee8-115">
    <a href="set-up-ad-units-in-your-app.md">アプリでの ad 単位を設定します</a>
    </span><span class="sxs-lookup"><span data-stu-id="f4ee8-115">
    <a href="set-up-ad-units-in-your-app.md">Set up ad units in your app</a>
    </span></span><br/><span data-ttu-id="f4ee8-116">
    <a href="best-practices-for-ads-in-apps.md">ベスト プラクティス</a>
    </span><span class="sxs-lookup"><span data-stu-id="f4ee8-116">
    <a href="best-practices-for-ads-in-apps.md">Best practices</a>
    </span></span><br/><span data-ttu-id="f4ee8-117">
    <a href="https://msdn.microsoft.com/en-us/library/windows/apps/mt691884.aspx">API リファレンス</a>
    </span><span class="sxs-lookup"><span data-stu-id="f4ee8-117">
    <a href="https://msdn.microsoft.com/en-us/library/windows/apps/mt691884.aspx">API reference</a>
    </span></span></td>
</tr>
</tbody>
</table>

## <a name="step-1-install-the-microsoft-advertising-sdk"></a><span data-ttu-id="f4ee8-118">手順 1:Microsoft Advertising SDK のインストール</span><span class="sxs-lookup"><span data-stu-id="f4ee8-118">Step 1: Install the Microsoft Advertising SDK</span></span>

<span data-ttu-id="f4ee8-119">まず、アプリの構築に使用する開発用コンピューターに [Microsoft Advertising SDK](https://aka.ms/ads-sdk-uwp) をインストールします。</span><span class="sxs-lookup"><span data-stu-id="f4ee8-119">To get started, install the [Microsoft Advertising SDK](https://aka.ms/ads-sdk-uwp) on the development computer you use to build your app.</span></span> <span data-ttu-id="f4ee8-120">インストール手順については、[この記事](install-the-microsoft-advertising-libraries.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f4ee8-120">For installation instructions, see [this article](install-the-microsoft-advertising-libraries.md).</span></span>

## <a name="step-2-implement-ads-in-your-app"></a><span data-ttu-id="f4ee8-121">手順 2:アプリでの広告の実装</span><span class="sxs-lookup"><span data-stu-id="f4ee8-121">Step 2: Implement ads in your app</span></span>

<span data-ttu-id="f4ee8-122">Microsoft Advertising SDK では、アプリで使用できるさまざまな種類の広告コントロールを提供しています。</span><span class="sxs-lookup"><span data-stu-id="f4ee8-122">The Microsoft Advertising SDK provides several different types of ad controls you can use in your app.</span></span> <span data-ttu-id="f4ee8-123">自分のシナリオに最適な広告の種類を選び、コードをアプリに追加することで、それらの広告を表示します。</span><span class="sxs-lookup"><span data-stu-id="f4ee8-123">Choose which types of ads are best for your scenario and then add code to your app to display those ads.</span></span> <span data-ttu-id="f4ee8-124">この手順では、テスト広告ユニットを使用して、テスト中にアプリが広告をレンダリングする方法を確認できます。</span><span class="sxs-lookup"><span data-stu-id="f4ee8-124">During this step, you will use a test ad unit so you can see how your app renders ads during testing.</span></span>

### <a name="banner-ads"></a><span data-ttu-id="f4ee8-125">バナー広告</span><span class="sxs-lookup"><span data-stu-id="f4ee8-125">Banner ads</span></span>

<span data-ttu-id="f4ee8-126">これらは、アプリ内のページの四角形の部分を利用してプロモーション用のコンテンツを表示する静的な表示広告です。</span><span class="sxs-lookup"><span data-stu-id="f4ee8-126">These are static display ads that utilize a rectangular portion of a page in your app to display promotional content.</span></span> <span data-ttu-id="f4ee8-127">これらの広告は、一定間隔で自動的に更新できます。</span><span class="sxs-lookup"><span data-stu-id="f4ee8-127">These ads can refresh automatically at regular intervals.</span></span> <span data-ttu-id="f4ee8-128">これは、初めてアプリで広告を行う場合はここから始めることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="f4ee8-128">This is a good place to start if you are new to advertising in your app.</span></span>

<span data-ttu-id="f4ee8-129">手順とコード例については、[この記事](adcontrol-in-xaml-and--net.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f4ee8-129">For instructions and code examples, see [this article](adcontrol-in-xaml-and--net.md).</span></span>

![addreferences](images/banner-ad.png)

### <a name="interstitial-video-and-interstitial-banner-ads"></a><span data-ttu-id="f4ee8-131">スポット ビデオ広告とスポット バナー広告</span><span class="sxs-lookup"><span data-stu-id="f4ee8-131">Interstitial video and interstitial banner ads</span></span>

<span data-ttu-id="f4ee8-132">これは通常、アプリやゲームを続行するために、ビデオを視聴することや広告をクリックスルーすることをユーザーに求める全画面表示の広告です。</span><span class="sxs-lookup"><span data-stu-id="f4ee8-132">These are full-screen ads that typically require the user to watch a video or click through them to continue in the app or game.</span></span> <span data-ttu-id="f4ee8-133">サポートしているスポット広告には、ビデオおよびバナーの 2 種類があります。</span><span class="sxs-lookup"><span data-stu-id="f4ee8-133">We support two types of interstitial ads: video and banner.</span></span>

<span data-ttu-id="f4ee8-134">手順とコード例については、[この記事](interstitial-ads.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f4ee8-134">For instructions and code examples, see [this article](interstitial-ads.md).</span></span>

![addreferences](images/interstitial-ad.png)

### <a name="native-ads"></a><span data-ttu-id="f4ee8-136">ネイティブ広告</span><span class="sxs-lookup"><span data-stu-id="f4ee8-136">Native ads</span></span>

<span data-ttu-id="f4ee8-137">これはコンポーネント ベースの広告です。</span><span class="sxs-lookup"><span data-stu-id="f4ee8-137">These are component-based ads.</span></span> <span data-ttu-id="f4ee8-138">各広告クリエイティブ (タイトル、画像、説明、行動喚起テキストなど) が、独自のフォント、色、その他の UI コンポーネントを使ってアプリに溶け込ませられる個々の要素として、アプリに配信されます。</span><span class="sxs-lookup"><span data-stu-id="f4ee8-138">Each piece of the ad creative (such as the title, image, description, and call-to-action text) is delivered to your app as an individual element that you can integrate into your app using your own fonts, colors, and other UI components.</span></span>

<span data-ttu-id="f4ee8-139">手順とコード例については、[この記事](native-ads.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f4ee8-139">For instructions and code examples, see [this article](native-ads.md).</span></span>

![addreferences](images/native-ad.png)

<span id="ad-mediation"/>

## <a name="step-3-create-an-ad-unit-and-configure-mediation"></a><span data-ttu-id="f4ee8-141">手順 3:Ad 単位を作成し、仲介の構成</span><span class="sxs-lookup"><span data-stu-id="f4ee8-141">Step 3: Create an ad unit and configure mediation</span></span>

<span data-ttu-id="f4ee8-142">アプリのテストを完了して、ストアに提出する準備が完了したら後で、ad 単位を作成する、[アプリ内広告](../publish/in-app-ads.md)パートナー センターでのページ。</span><span class="sxs-lookup"><span data-stu-id="f4ee8-142">After you finish testing your app and you are ready to submit it to the Store, create an ad unit on the [In-app ads](../publish/in-app-ads.md) page in Partner Center.</span></span> <span data-ttu-id="f4ee8-143">次に、アプリがライブ広告を受信できるように、この広告ユニットを使用するようにアプリのコードを更新します。</span><span class="sxs-lookup"><span data-stu-id="f4ee8-143">Then, update your app code to use this ad unit so that your app will receive live ads.</span></span> <span data-ttu-id="f4ee8-144">詳しくは、「[アプリの広告ユニットをセットアップする](set-up-ad-units-in-your-app.md#live-ad-units)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f4ee8-144">For more information, see [Set up ad units in your app](set-up-ad-units-in-your-app.md#live-ad-units).</span></span>

<span data-ttu-id="f4ee8-145">既定では、アプリはマイクロソフトの有料広告ネットワークの広告を表示します。</span><span class="sxs-lookup"><span data-stu-id="f4ee8-145">By default, your app will show ads from Microsoft's network for paid ads.</span></span> <span data-ttu-id="f4ee8-146">広告の収益を最大化するには、広告ユニットの[広告仲介](ad-mediation-service.md)を有効化することで、Taboola や Smaato など、その他の有料広告ネットワークの広告を表示できます。</span><span class="sxs-lookup"><span data-stu-id="f4ee8-146">To maximize your ad revenue, you can enable [ad mediation](ad-mediation-service.md) for your ad unit to display ads from additional paid ad networks such as Taboola and Smaato.</span></span> <span data-ttu-id="f4ee8-147">また、Microsoft アプリ プロモーション キャンペーンの広告を用意することでも、アプリ プロモーション機能を強化できます。</span><span class="sxs-lookup"><span data-stu-id="f4ee8-147">You can also increase your app promotion capabilities by serving ads from Microsoft app promotion campaigns.</span></span>

<span data-ttu-id="f4ee8-148">UWP アプリで広告仲介の使用を開始するには、広告ユニットの[広告仲介の設定を構成](../publish/in-app-ads.md#mediation-settings)します。</span><span class="sxs-lookup"><span data-stu-id="f4ee8-148">To start using ad mediation in your UWP app, [configure ad mediation settings](../publish/in-app-ads.md#mediation-settings) for your ad unit.</span></span> <span data-ttu-id="f4ee8-149">既定では、アプリがサポートする市場全体で広告の収益を最大化できるように、機械学習アルゴリズムを使った仲介設定が自動的に構成されます。</span><span class="sxs-lookup"><span data-stu-id="f4ee8-149">By default, we automatically configure the mediation settings using machine-learning algorithms to help you maximize your ad revenue across the markets your app supports.</span></span> <span data-ttu-id="f4ee8-150">ただし、使用するネットワークを手動で選ぶこともできます。</span><span class="sxs-lookup"><span data-stu-id="f4ee8-150">However, you also have the option to manually choose the networks you want to use.</span></span> <span data-ttu-id="f4ee8-151">どちらの方法でも、仲介設定はすべてサーバーで構成されます。アプリのコードを変更する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="f4ee8-151">Either way, the mediation settings are configured entirely on our servers; you do not need to make any code changes in your app.</span></span>    

## <a name="step-4-submit-your-app-and-review-performance"></a><span data-ttu-id="f4ee8-152">手順 4:アプリを提出してパフォーマンスを確認する</span><span class="sxs-lookup"><span data-stu-id="f4ee8-152">Step 4: Submit your app and review performance</span></span>

<span data-ttu-id="f4ee8-153">後に広告を使用してアプリの開発が完了したら、[更新されたアプリの提出](https://docs.microsoft.com/windows/uwp/publish/app-submissions)ストアで使用できるように、パートナー センターでします。</span><span class="sxs-lookup"><span data-stu-id="f4ee8-153">After you finish developing your app with ads, you can [submit your updated app](https://docs.microsoft.com/windows/uwp/publish/app-submissions) in Partner Center to make it available in the Store.</span></span> <span data-ttu-id="f4ee8-154">広告を表示するアプリは、[Microsoft Store ポリシーの第 10.10 項](https://docs.microsoft.com/legal/windows/agreements/store-policies#1010-advertising-conduct-and-content)と、[アプリ開発者契約の追加条項 E](https://docs.microsoft.com/legal/windows/agreements/app-developer-agreement) で指定されたその他の要件を満たしている必要があります。</span><span class="sxs-lookup"><span data-stu-id="f4ee8-154">Apps that display ads must meet the additional requirements that are specified in [section 10.10 of the Microsoft Store Policies](https://docs.microsoft.com/legal/windows/agreements/store-policies#1010-advertising-conduct-and-content) and [Exhibit E of the App Developer Agreement](https://docs.microsoft.com/legal/windows/agreements/app-developer-agreement).</span></span>

<span data-ttu-id="f4ee8-155">アプリを発行すると、ストアで使用可能な確認すること、[広告のパフォーマンス レポート](../publish/advertising-performance-report.md)パートナー センターで続行、ads のパフォーマンスを最適化するために、仲介の設定を変更するとします。</span><span class="sxs-lookup"><span data-stu-id="f4ee8-155">After your app is published and available in the Store, you can review your [advertising performance reports](../publish/advertising-performance-report.md) in Partner Center and continue to make changes to your mediation settings to optimize the performance of your ads.</span></span> <span data-ttu-id="f4ee8-156">広告の収益は[入金状況](../publish/payout-summary.md)に表示されます。</span><span class="sxs-lookup"><span data-stu-id="f4ee8-156">Your advertising revenue is included in your [payout summary](../publish/payout-summary.md).</span></span>

<span id="additional-help" />

## <a name="additional-help"></a><span data-ttu-id="f4ee8-157">追加のヘルプ</span><span class="sxs-lookup"><span data-stu-id="f4ee8-157">Additional help</span></span>

<span data-ttu-id="f4ee8-158">Microsoft Advertising SDK の使用に関するその他のヘルプについては、次のリソースを参照してください。</span><span class="sxs-lookup"><span data-stu-id="f4ee8-158">For additional help using the Microsoft Advertising SDK, use the following resources.</span></span>

|  <span data-ttu-id="f4ee8-159">タスク</span><span class="sxs-lookup"><span data-stu-id="f4ee8-159">Task</span></span>    | <span data-ttu-id="f4ee8-160">リソース</span><span class="sxs-lookup"><span data-stu-id="f4ee8-160">Resource</span></span> |               
|----------|-------|
| <span data-ttu-id="f4ee8-161">広告のバグを報告したり個別のサポートを受けたりする</span><span class="sxs-lookup"><span data-stu-id="f4ee8-161">Report a bug or get assisted support for advertising</span></span>     | <span data-ttu-id="f4ee8-162">[サポート ページ](https://developer.microsoft.com/en-us/windows/support)にアクセスし、**[アプリ内広告]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="f4ee8-162">Visit the [support page](https://developer.microsoft.com/en-us/windows/support) and choose **Ads-In-Apps**.</span></span>        |
| <span data-ttu-id="f4ee8-163">コミュニティ サポートを受ける</span><span class="sxs-lookup"><span data-stu-id="f4ee8-163">Get community support</span></span>     | <span data-ttu-id="f4ee8-164">[フォーラム](https://go.microsoft.com/fwlink/p/?LinkId=401266)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f4ee8-164">Visit the [forum](https://go.microsoft.com/fwlink/p/?LinkId=401266).</span></span>       |
| <span data-ttu-id="f4ee8-165">バナーやスポット広告をアプリに追加する方法を説明するサンプル プロジェクトをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="f4ee8-165">Download sample projects that demonstrate how to add banner and interstitial ads to apps.</span></span>     | <span data-ttu-id="f4ee8-166">「[GitHub の広告サンプル](https://aka.ms/githubads)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f4ee8-166">See the [Advertising samples on GitHub](https://aka.ms/githubads).</span></span>       |
| <span data-ttu-id="f4ee8-167">Windows アプリの最新の収益機会について学ぶ</span><span class="sxs-lookup"><span data-stu-id="f4ee8-167">Learn about the latest monetization opportunities for Windows apps</span></span>     | <span data-ttu-id="f4ee8-168">「[アプリの収益の獲得](https://developer.microsoft.com/store/monetize)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f4ee8-168">Visit [Monetize your apps](https://developer.microsoft.com/store/monetize).</span></span>        |

## <a name="windows-81-and-windows-phone-8x-apps"></a><span data-ttu-id="f4ee8-169">Windows 8.1 と Windows Phone 8.x のアプリ</span><span class="sxs-lookup"><span data-stu-id="f4ee8-169">Windows 8.1 and Windows Phone 8.x apps</span></span>

<span data-ttu-id="f4ee8-170">Windows 8.1 および Windows Phone 8.x 用のアプリについては、[Windows および Windows Phone 8.x 用の Microsoft Advertising SDK](https://aka.ms/store-8-sdk) を提供しています。</span><span class="sxs-lookup"><span data-stu-id="f4ee8-170">For Windows 8.1 and Windows Phone 8.x apps, we provide the [Microsoft Advertising SDK for Windows and Windows Phone 8.x](https://aka.ms/store-8-sdk).</span></span> <span data-ttu-id="f4ee8-171">Windows 8.1 または Windows Phone 8.x アプリでこの SDK を使用して広告を表示する方法について詳しくは、[この記事](https://docs.microsoft.com/en-us/previous-versions/windows/apps/dn792120(v=win.10))をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f4ee8-171">For more information about using this SDK to show ads in Windows 8.1 and Windows Phone 8.x apps, see [this article](https://docs.microsoft.com/en-us/previous-versions/windows/apps/dn792120(v=win.10)).</span></span>

## <a name="related-topics"></a><span data-ttu-id="f4ee8-172">関連トピック</span><span class="sxs-lookup"><span data-stu-id="f4ee8-172">Related topics</span></span>

* [<span data-ttu-id="f4ee8-173">Microsoft Advertising SDK</span><span class="sxs-lookup"><span data-stu-id="f4ee8-173">Microsoft Advertising SDK</span></span>](https://aka.ms/ads-sdk-uwp)
* [<span data-ttu-id="f4ee8-174">広告パフォーマンス レポート</span><span class="sxs-lookup"><span data-stu-id="f4ee8-174">Advertising performance report</span></span>](../publish/advertising-performance-report.md)
* [<span data-ttu-id="f4ee8-175">Windows Premium 広告の発行元のプログラム</span><span class="sxs-lookup"><span data-stu-id="f4ee8-175">Windows Premium Ads Publishers Program</span></span>](windows-premium-ads-publishers-program.md)
