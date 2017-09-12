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
# <a name="display-ads-in-your-app-with-the-microsoft-advertising-sdk"></a><span data-ttu-id="eb4c7-104">Microsoft Advertising SDK を使用したアプリでの広告の表示</span><span class="sxs-lookup"><span data-stu-id="eb4c7-104">Display ads in your app with the Microsoft Advertising SDK</span></span>

<span data-ttu-id="eb4c7-105">Microsoft Advertising SDK を使用して、アプリに広告を配置することで、収益機会を増やせます。</span><span class="sxs-lookup"><span data-stu-id="eb4c7-105">Increase your revenue opportunities by putting ads in your apps by using the Microsoft Advertising SDK.</span></span> <span data-ttu-id="eb4c7-106">マイクロソフトの広告の収益化プラットフォームは、さまざまな種類の広告を提供し、人気のある多くの広告ネットワークとの仲介をサポートします。</span><span class="sxs-lookup"><span data-stu-id="eb4c7-106">Our ad monetization platform offers a variety of ad types and supports mediation with many popular ad networks.</span></span>

<span data-ttu-id="eb4c7-107">アプリに広告を表示するには、次の手順に従います。</span><span class="sxs-lookup"><span data-stu-id="eb4c7-107">To display ads in your apps, follow these steps.</span></span>

## <a name="step-1-install-the-microsoft-advertising-sdk"></a><span data-ttu-id="eb4c7-108">手順 1: Microsoft Advertising SDK をインストールする</span><span class="sxs-lookup"><span data-stu-id="eb4c7-108">Step 1: Install the Microsoft Advertising SDK</span></span>

<span data-ttu-id="eb4c7-109">Microsoft Advertising SDK では、さまざまな種類の広告を表示するためにアプリで使用できる各種コントロールを用意しています。</span><span class="sxs-lookup"><span data-stu-id="eb4c7-109">The Microsoft Advertising SDK provides a variety of controls you can use in your app to show different types of ads.</span></span> <span data-ttu-id="eb4c7-110">インストール手順については、[この記事](install-the-microsoft-advertising-libraries.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="eb4c7-110">For installation instructions, see [this article](install-the-microsoft-advertising-libraries.md).</span></span>

## <a name="step-2-choose-your-ad-type-and-add-code-to-display-test-ads-in-your-app"></a><span data-ttu-id="eb4c7-111">手順 2: 広告の種類を選択し、コードを追加して、アプリにテスト広告を表示する</span><span class="sxs-lookup"><span data-stu-id="eb4c7-111">Step 2: Choose your ad type and add code to display test ads in your app</span></span>

<span data-ttu-id="eb4c7-112">Microsoft Advertising SDK では、アプリに表示できるさまざまな種類の広告を提供しています。</span><span class="sxs-lookup"><span data-stu-id="eb4c7-112">The Microsoft Advertising SDK provides several different types of ads you can display in your app.</span></span> <span data-ttu-id="eb4c7-113">自分のシナリオに最適な広告の種類を選び、コードをアプリに追加することで、それらの広告を表示します。</span><span class="sxs-lookup"><span data-stu-id="eb4c7-113">Choose which types of ads are best for your scenario and then add code to your app to display those ads.</span></span>

<span data-ttu-id="eb4c7-114">アプリに広告を用意するには、コードでアプリケーション ID と広告ユニット ID を指定しなければなりません。</span><span class="sxs-lookup"><span data-stu-id="eb4c7-114">You must specify an application ID and ad unit ID in your code to serve ads to your app.</span></span> <span data-ttu-id="eb4c7-115">アプリの開発中は、[テスト用のアプリケーション ID と広告ユニット ID の値](test-mode-values.md)を使って、テスト時にアプリでどのように広告がレンダリングされるかを確認する必要があります。</span><span class="sxs-lookup"><span data-stu-id="eb4c7-115">While you are developing your app, you should use [test application ID and ad unit ID values](test-mode-values.md) to see how your app renders ads during testing.</span></span>

### <a name="banner-ads"></a><span data-ttu-id="eb4c7-116">バナー広告</span><span class="sxs-lookup"><span data-stu-id="eb4c7-116">Banner ads</span></span>

<span data-ttu-id="eb4c7-117">これはアプリ内のページの一部分 (多くの場合、アプリの上部または下部) を利用する静的な表示広告です。</span><span class="sxs-lookup"><span data-stu-id="eb4c7-117">These are static display ads that utilize a portion of a page in an app, often at the top or bottom of the page.</span></span>

<span data-ttu-id="eb4c7-118">手順とコード例については、「[XAML および .NET の AdControl](adcontrol-in-xaml-and--net.md)」または「[HTML 5 および Javascript の AdControl](adcontrol-in-html-5-and-javascript.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="eb4c7-118">For instructions and code examples, see [AdControl in XAML and .NET](adcontrol-in-xaml-and--net.md) and [AdControl in HTML 5 and Javascript](adcontrol-in-html-5-and-javascript.md).</span></span> <span data-ttu-id="eb4c7-119">C# と C++ を使って JavaScript/HTML アプリと XAML アプリにバナー広告を追加する方法を示す完全なサンプル プロジェクトについては、[GitHub の広告サンプル](http://aka.ms/githubads)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="eb4c7-119">For complete sample projects that demonstrate how to add banner ads to JavaScript/HTML apps and XAML apps using C# and C++, see the [advertising samples on GitHub](http://aka.ms/githubads).</span></span>

![addreferences](images/banner-ad.png)

### <a name="interstitial-ads"></a><span data-ttu-id="eb4c7-121">スポット広告</span><span class="sxs-lookup"><span data-stu-id="eb4c7-121">Interstitial ads</span></span>

<span data-ttu-id="eb4c7-122">これは通常、アプリやゲームを続行するために、ビデオを視聴することや広告をクリックスルーすることをユーザーに求める全画面表示の広告です。</span><span class="sxs-lookup"><span data-stu-id="eb4c7-122">These are full-screen ads that typically require the user to watch a video or click through them to continue in the app or game.</span></span> <span data-ttu-id="eb4c7-123">サポートしているスポット広告には、ビデオおよびバナーの 2 種類があります。</span><span class="sxs-lookup"><span data-stu-id="eb4c7-123">We support two types of interstitial ads: video and banner.</span></span>

<span data-ttu-id="eb4c7-124">手順とコード例については、「[スポット広告](interstitial-ads.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="eb4c7-124">For instructions and code examples, see [Interstitial ads](interstitial-ads.md).</span></span> <span data-ttu-id="eb4c7-125">C# と C++ を使って JavaScript/HTML アプリと XAML アプリにスポット広告を追加する方法を示す完全なサンプル プロジェクトについては、[GitHub の広告サンプル](http://aka.ms/githubads)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="eb4c7-125">For complete sample projects that demonstrate how to add interstitial ads to JavaScript/HTML apps and XAML apps using C# and C++, see the [advertising samples on GitHub](http://aka.ms/githubads).</span></span>

![addreferences](images/interstitial-ad.png)

### <a name="native-ads"></a><span data-ttu-id="eb4c7-127">ネイティブ広告</span><span class="sxs-lookup"><span data-stu-id="eb4c7-127">Native ads</span></span>

<span data-ttu-id="eb4c7-128">これはコンポーネント ベースの広告です。</span><span class="sxs-lookup"><span data-stu-id="eb4c7-128">These are component-based ads.</span></span> <span data-ttu-id="eb4c7-129">各広告クリエイティブ (タイトル、画像、説明、行動喚起テキストなど) が、独自のフォント、色、その他の UI コンポーネントを使ってアプリに溶け込ませられる個々の要素として、アプリに配信され、控えめなユーザー エクスペリエンスをまとめます。</span><span class="sxs-lookup"><span data-stu-id="eb4c7-129">Each piece of the ad creative (such as the title, image, description, and call-to-action text) is delivered to your app as an individual element that you can integrate into your app using your own fonts, colors, and other UI components to stitch together an unobtrusive user experience.</span></span>

<span data-ttu-id="eb4c7-130">手順とコード例については、「[ネイティブ広告](native-ads.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="eb4c7-130">For instructions and code examples, see [Native ads](native-ads.md).</span></span>

![addreferences](images/native-ad.png)

## <a name="step-3-get-an-ad-unit-from-dev-center-and-configure-your-app-to-receive-live-ads"></a><span data-ttu-id="eb4c7-132">手順 3: デベロッパー センターから広告ユニットを取得し、ライブ広告を受信するようにアプリを構成する</span><span class="sxs-lookup"><span data-stu-id="eb4c7-132">Step 3: Get an ad unit from Dev Center and configure your app to receive live ads</span></span>

<span data-ttu-id="eb4c7-133">アプリのテストが完了し、ストアにそのアプリを提出する準備ができたら、Windows デベロッパー センター ダッシュボードの [[広告で収入を増やす](../publish/monetize-with-ads.md)] ページで広告ユニットを作成します。</span><span class="sxs-lookup"><span data-stu-id="eb4c7-133">After you finish testing your app and you are ready to submit it to the Store, create an ad unit on the [Monetize with ads](../publish/monetize-with-ads.md) page in the Windows Dev Center dashboard.</span></span> <span data-ttu-id="eb4c7-134">次に、この広告ユニットのアプリケーション ID と広告ユニット ID の値を使用するように、アプリのコードを更新します。</span><span class="sxs-lookup"><span data-stu-id="eb4c7-134">Then, update your app code to use the application ID and ad unit ID values for this ad unit.</span></span> <span data-ttu-id="eb4c7-135">ストアで公開されているバージョンのアプリで、テスト用のアプリケーション ID と広告ユニット ID の値を使用しようとしても、ライブ広告は受信されません。</span><span class="sxs-lookup"><span data-stu-id="eb4c7-135">If you try to use test application ID and ad unit ID values in the published version of your app in the Store, your app will not receive live ads.</span></span> <span data-ttu-id="eb4c7-136">詳しくは、「[アプリの広告ユニットをセットアップする](set-up-ad-units-in-your-app.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="eb4c7-136">For more information, see [Set up ad units in your app](set-up-ad-units-in-your-app.md).</span></span>

<span id="ad-mediation"/>
### <a name="configure-ad-mediation"></a><span data-ttu-id="eb4c7-137">広告仲介を構成する</span><span class="sxs-lookup"><span data-stu-id="eb4c7-137">Configure ad mediation</span></span>

<span data-ttu-id="eb4c7-138">既定では、バナー広告、スポット広告、およびネイティブ広告には Microsoft の有料広告ネットワークの広告が表示されます。</span><span class="sxs-lookup"><span data-stu-id="eb4c7-138">By default, banner ads, interstitial ads, and native ads display advertisements from Microsoft's network for paid ads.</span></span> <span data-ttu-id="eb4c7-139">広告の収益を最大化するには、広告ユニットの広告仲介を有効化することで、Taboola や Smaato など、その他の有料広告ネットワークの広告を表示できます。</span><span class="sxs-lookup"><span data-stu-id="eb4c7-139">To maximize your ad revenue, you can enable ad mediation for your ad unit to display ads from additional paid ad networks such as Taboola and Smaato.</span></span> <span data-ttu-id="eb4c7-140">また、Microsoft アプリ プロモーション キャンペーンの広告を用意することでも、アプリ プロモーション機能を強化できます。</span><span class="sxs-lookup"><span data-stu-id="eb4c7-140">You can also increase your app promotion capabilities by serving ads from Microsoft app promotion campaigns.</span></span>

<span data-ttu-id="eb4c7-141">UWP アプリで広告仲介の使用を開始するには、広告ユニットの[広告仲介の設定を構成](../publish/monetize-with-ads.md#mediation)します。</span><span class="sxs-lookup"><span data-stu-id="eb4c7-141">To start using ad mediation in your UWP app, [configure ad mediation settings](../publish/monetize-with-ads.md#mediation) for your ad unit.</span></span> <span data-ttu-id="eb4c7-142">既定では、アプリがサポートする市場全体で広告の収益を最大化できるように、機械学習アルゴリズムを使った仲介設定が自動的に構成されます。</span><span class="sxs-lookup"><span data-stu-id="eb4c7-142">By default, we automatically configure the mediation settings using machine-learning algorithms to help you maximize your ad revenue across the markets your app supports.</span></span> <span data-ttu-id="eb4c7-143">ただし、使うネットワークを手動で選ぶオプションもあります。</span><span class="sxs-lookup"><span data-stu-id="eb4c7-143">However, also have the option to manually choose the networks you want to use.</span></span> <span data-ttu-id="eb4c7-144">どちらの方法でも、仲介設定はすべてサービスで構成されます。アプリのコードを変更する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="eb4c7-144">Either way, the mediation settings are configured entirely in the service; you do not need to make any code changes in your app.</span></span>    

<span id="8.x-mediation"/>
### <a name="mediation-in-windows-81-and-windows-phone-8x-apps"></a><span data-ttu-id="eb4c7-145">Windows 8.1 と Windows Phone 8.x アプリにおける仲介</span><span class="sxs-lookup"><span data-stu-id="eb4c7-145">Mediation in Windows 8.1 and Windows Phone 8.x apps</span></span>

<span data-ttu-id="eb4c7-146">Windows 8.1 と Windows Phone 8.x アプリでは、広告仲介はバナー広告にのみ利用できます。</span><span class="sxs-lookup"><span data-stu-id="eb4c7-146">In Windows 8.1 and Windows Phone 8.x apps, ad mediation is only available for banner ads.</span></span> <span data-ttu-id="eb4c7-147">広告仲介を使うには、**AdControl** クラスの代わりに [Windows および Windows Phone 8.x 用 Microsoft Advertising SDK](http://aka.ms/store-8-sdk) の **AdMediatorControl** クラスを使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="eb4c7-147">To use ad mediation, you must use the **AdMediatorControl** class in the [Microsoft Advertising SDK for Windows and Windows Phone 8.x](http://aka.ms/store-8-sdk) instead of the **AdControl** class.</span></span> <span data-ttu-id="eb4c7-148">このコントロールをアプリに追加すると、ダッシュボードで広告仲介設定を手動で構成できます。</span><span class="sxs-lookup"><span data-stu-id="eb4c7-148">After you add this control to your app, you can manually configure your ad mediation settings on the dashboard.</span></span>

<span data-ttu-id="eb4c7-149">Windows 8.1 または Windows Phone 8.x アプリで広告仲介を使う方法について詳しくは、[この記事](https://msdn.microsoft.com/library/windows/apps/xaml/dn864359.aspx)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="eb4c7-149">For more information about using ad mediation in a Windows 8.1 or Windows Phone 8.x app, see [this article](https://msdn.microsoft.com/library/windows/apps/xaml/dn864359.aspx).</span></span>

> [!NOTE]
> <span data-ttu-id="eb4c7-150">Windows 8.1 および Windows Phone 8.x アプリの広告仲介は、アクティブな開発対象ではなくなりました。</span><span class="sxs-lookup"><span data-stu-id="eb4c7-150">Ad mediation for Windows 8.1 and Windows Phone 8.x apps is no longer under active development.</span></span> <span data-ttu-id="eb4c7-151">広告収益の可能性を最大限に引き出すため、バナー広告、スポット広告、またはネイティブ広告で広告仲介を使う UWP アプリを構築することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="eb4c7-151">To maximize your potential advertising revenue, we recommend that you build UWP apps that use ad mediation with banner ads, interstitial ads, or native ads.</span></span>

## <a name="step-4-submit-your-app-and-review-performance"></a><span data-ttu-id="eb4c7-152">手順 4: アプリを提出してパフォーマンスを確認する</span><span class="sxs-lookup"><span data-stu-id="eb4c7-152">Step 4: Submit your app and review performance</span></span>

<span data-ttu-id="eb4c7-153">広告を含むアプリの開発が完了したら、デベロッパー センター ダッシュボードに[更新したアプリを提出](https://msdn.microsoft.com/windows/uwp/publish/app-submissions)できます。それにより、ストアでアプリを利用できるようになります。</span><span class="sxs-lookup"><span data-stu-id="eb4c7-153">After you finish developing your app with ads, you can [submit your updated app](https://msdn.microsoft.com/windows/uwp/publish/app-submissions) to the Dev Center dashboard so it is available in the Store.</span></span> <span data-ttu-id="eb4c7-154">広告を表示するアプリは、[Windows ストア ポリシーの第 10.10 項](https://msdn.microsoft.com/library/windows/apps/dn764944.aspx#pol_10_10) と、[アプリ開発者契約の追加条項 E](https://msdn.microsoft.com/library/windows/apps/hh694058.aspx) で指定されたその他の要件を満たしている必要があります。</span><span class="sxs-lookup"><span data-stu-id="eb4c7-154">Apps that display ads must meet the additional requirements that are specified in [section 10.10 of the Windows Store Policies](https://msdn.microsoft.com/library/windows/apps/dn764944.aspx#pol_10_10) and [Exhibit E of the App Developer Agreement](https://msdn.microsoft.com/library/windows/apps/hh694058.aspx).</span></span>

<span data-ttu-id="eb4c7-155">アプリがストアで公開されて利用できるようになったら、ダッシュボードで[広告パフォーマンス レポート](../publish/advertising-performance-report.md)を確認して、継続的に仲介の設定に変更を加えることで、広告のパフォーマンスを最適化できます。</span><span class="sxs-lookup"><span data-stu-id="eb4c7-155">After your app is published and available in the Store, you can review your [advertising performance reports](../publish/advertising-performance-report.md) in the dashboard and continue to make changes to your mediation settings to optimize the performance of your ads.</span></span> <span data-ttu-id="eb4c7-156">広告の収益は[入金状況](../publish/payout-summary.md)に表示されます。</span><span class="sxs-lookup"><span data-stu-id="eb4c7-156">Your advertising revenue is included in your [payout summary](../publish/payout-summary.md).</span></span>

<span id="additional-help" />
## <a name="additional-help"></a><span data-ttu-id="eb4c7-157">追加のヘルプ</span><span class="sxs-lookup"><span data-stu-id="eb4c7-157">Additional help</span></span>

<span data-ttu-id="eb4c7-158">Microsoft Advertising SDK の使用に関するその他のヘルプについては、次のリソースを参照してください。</span><span class="sxs-lookup"><span data-stu-id="eb4c7-158">For additional help using the Microsoft Advertising SDK, use the following resources.</span></span>

|  <span data-ttu-id="eb4c7-159">タスク</span><span class="sxs-lookup"><span data-stu-id="eb4c7-159">Task</span></span>    | <span data-ttu-id="eb4c7-160">リソース</span><span class="sxs-lookup"><span data-stu-id="eb4c7-160">Resource</span></span> |               
|----------|-------|
| <span data-ttu-id="eb4c7-161">広告のバグを報告したり個別のサポートを受けたりする</span><span class="sxs-lookup"><span data-stu-id="eb4c7-161">Report a bug or get assisted support for advertising</span></span>     | <span data-ttu-id="eb4c7-162">[サポート ページ](https://go.microsoft.com/fwlink/p/?LinkId=331508)にアクセスし、**[In-App 広告]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="eb4c7-162">Visit the [support page](https://go.microsoft.com/fwlink/p/?LinkId=331508) and choose **In-App Advertising**.</span></span>        |
| <span data-ttu-id="eb4c7-163">コミュニティ サポートを受ける</span><span class="sxs-lookup"><span data-stu-id="eb4c7-163">Get community support</span></span>     | <span data-ttu-id="eb4c7-164">[フォーラム](http://go.microsoft.com/fwlink/p/?LinkId=401266)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="eb4c7-164">Visit the [forum](http://go.microsoft.com/fwlink/p/?LinkId=401266).</span></span>       |
| <span data-ttu-id="eb4c7-165">バナーやスポット広告をアプリに追加する方法を説明するサンプル プロジェクトをダウンロードする</span><span class="sxs-lookup"><span data-stu-id="eb4c7-165">Download sample projects that demonstrate how to add banner and interstitial ads to apps.</span></span>     | <span data-ttu-id="eb4c7-166">「[GitHub の広告サンプル](http://aka.ms/githubads)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="eb4c7-166">See the [Advertising samples on GitHub](http://aka.ms/githubads).</span></span>       |
| <span data-ttu-id="eb4c7-167">Windows アプリの最新の収益機会について学ぶ</span><span class="sxs-lookup"><span data-stu-id="eb4c7-167">Learn about the latest monetization opportunities for Windows apps</span></span>     | <span data-ttu-id="eb4c7-168">「[アプリの収益の獲得](https://developer.microsoft.com/store/monetize)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="eb4c7-168">Visit [Monetize your apps](https://developer.microsoft.com/store/monetize).</span></span>        |

## <a name="related-topics"></a><span data-ttu-id="eb4c7-169">関連トピック</span><span class="sxs-lookup"><span data-stu-id="eb4c7-169">Related topics</span></span>

* [<span data-ttu-id="eb4c7-170">Microsoft Advertising SDK</span><span class="sxs-lookup"><span data-stu-id="eb4c7-170">Microsoft Advertising SDK</span></span>](http://aka.ms/ads-sdk-uwp)
* [<span data-ttu-id="eb4c7-171">広告によるアプリの収益の獲得</span><span class="sxs-lookup"><span data-stu-id="eb4c7-171">Monetize your app with ads</span></span>](http://go.microsoft.com/fwlink/p/?LinkId=699559)
* [<span data-ttu-id="eb4c7-172">広告パフォーマンス レポート</span><span class="sxs-lookup"><span data-stu-id="eb4c7-172">Advertising performance report</span></span>](../publish/advertising-performance-report.md)
