---
author: JnHs
Description: "Windows アプリについての詳しい分析をダッシュボードやその他の手段で確認しましょう。"
title: "アプリのパフォーマンスの分析"
ms.assetid: 3A3C6F10-0DB1-416D-B632-CD388EA66759
ms.author: wdg-dev-content
ms.date: 06/28/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, 分析, 報告, ダッシュ ボード, アプリ"
ms.openlocfilehash: 57e4a30258fa25411bb461cac56aa18d2f74981d
ms.sourcegitcommit: a93b1da07b386a682435de58a8129d7b4ee90c14
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 06/29/2017
---
# <a name="analyze-app-performance"></a><span data-ttu-id="b4979-104">アプリのパフォーマンスの分析</span><span class="sxs-lookup"><span data-stu-id="b4979-104">Analyze app performance</span></span>

<span data-ttu-id="b4979-105">アプリについての詳しい分析を Windows デベロッパー センター ダッシュボードで確認できます。</span><span class="sxs-lookup"><span data-stu-id="b4979-105">You can view detailed analytics for your apps in the Windows Dev Center dashboard.</span></span> <span data-ttu-id="b4979-106">統計情報とチャートでは、アプリの状況 (獲得したユーザーから、ユーザーによるアプリの使い方、ユーザーによるアプリの評判まで) を知ることができます。</span><span class="sxs-lookup"><span data-stu-id="b4979-106">Statistics and charts let you know how your apps are doing, from how many customers you've reached to how they're using your app and what they have to say about it.</span></span> <span data-ttu-id="b4979-107">アプリの正常性、広告の使用状況などに関するメトリックも確認できます。</span><span class="sxs-lookup"><span data-stu-id="b4979-107">You can also find metrics on app health, ad usage, and more.</span></span>

<span data-ttu-id="b4979-108">ダッシュボードで分析レポートを表示するか、[必要なレポートをダウンロード](download-analytic-reports.md)してデータをオフラインで分析できます。</span><span class="sxs-lookup"><span data-stu-id="b4979-108">You can view analytic reports in the dashboard, or [download the reports you need](download-analytic-reports.md) to analyze your data offline.</span></span> <span data-ttu-id="b4979-109">[ダッシュボードを使わずに分析データにアクセスする](#no-dashboard)こともできます。</span><span class="sxs-lookup"><span data-stu-id="b4979-109">We also provide several ways for you to [access your analytics data without using the dashboard](#no-dashboard).</span></span>

## <a name="view-key-analytics-for-all-your-apps"></a><span data-ttu-id="b4979-110">すべてのアプリについての主要な分析を表示する</span><span class="sxs-lookup"><span data-stu-id="b4979-110">View key analytics for all your apps</span></span>

<span data-ttu-id="b4979-111">最もダウンロードされたアプリについての主要な分析を表示するには、**[分析]** を展開し、**[概要]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="b4979-111">To view key analytics about your most downloaded apps, expand **Analyze** and select **Overview**.</span></span> <span data-ttu-id="b4979-112">既定では、**[分析の概要]** ページには、有効期間内の取得数が最も多い 5 つのアプリに関する情報が表示されます。</span><span class="sxs-lookup"><span data-stu-id="b4979-112">By default, the **Analytics overview** page shows info about your five apps that have the most lifetime acquisitions.</span></span> <span data-ttu-id="b4979-113">別の発行済みのアプリを選んで表示するには、**[フィルター]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="b4979-113">To choose different published apps to show, select **Filters**.</span></span>

## <a name="view-individual-reports-for-each-app"></a><span data-ttu-id="b4979-114">アプリごとに個別レポートを表示する</span><span class="sxs-lookup"><span data-stu-id="b4979-114">View individual reports for each app</span></span>

<span data-ttu-id="b4979-115">ここでは、次の各レポートに表示される情報の詳細情報を示します。</span><span class="sxs-lookup"><span data-stu-id="b4979-115">In this section you'll find details about the info presented in each of the following reports:</span></span>

-   [<span data-ttu-id="b4979-116">[取得] レポート</span><span class="sxs-lookup"><span data-stu-id="b4979-116">Acquisitions report</span></span>](acquisitions-report.md)
-   [<span data-ttu-id="b4979-117">[アドオン取得] レポート</span><span class="sxs-lookup"><span data-stu-id="b4979-117">Add-on acquisitions report</span></span>](add-on-acquisitions-report.md)
-   [<span data-ttu-id="b4979-118">[使用状況] レポート</span><span class="sxs-lookup"><span data-stu-id="b4979-118">Usage report</span></span>](usage-report.md)
-   [<span data-ttu-id="b4979-119">[安定性] レポート</span><span class="sxs-lookup"><span data-stu-id="b4979-119">Health report</span></span>](health-report.md)
-   [<span data-ttu-id="b4979-120">[レビュー] レポート</span><span class="sxs-lookup"><span data-stu-id="b4979-120">Reviews report</span></span>](reviews-report.md)
-   [<span data-ttu-id="b4979-121">[フィードバック] レポート</span><span class="sxs-lookup"><span data-stu-id="b4979-121">Feedback report</span></span>](feedback-report.md)
-   [<span data-ttu-id="b4979-122">[広告パフォーマンス] レポート</span><span class="sxs-lookup"><span data-stu-id="b4979-122">Advertising performance report</span></span>](advertising-performance-report.md)
-   [<span data-ttu-id="b4979-123">[広告キャンペーン] レポート</span><span class="sxs-lookup"><span data-stu-id="b4979-123">Ad campaign report</span></span>](promote-your-app-report.md)

> [!NOTE]
> <span data-ttu-id="b4979-124">アプリの実際の機能や実装によっては、これらのレポートの一部にデータが含まれていないことがあります。</span><span class="sxs-lookup"><span data-stu-id="b4979-124">You may not see data in all of these reports, depending on your app's specific features and implementation.</span></span>

<span id="no-dashboard"/>
## <a name="access-analytics-data-without-using-the-dev-center-dashboard"></a><span data-ttu-id="b4979-125">デベロッパー センター ダッシュボードを使わずに分析データにアクセスする</span><span class="sxs-lookup"><span data-stu-id="b4979-125">Access analytics data without using the Dev Center dashboard</span></span>

<span data-ttu-id="b4979-126">分析データにアクセスするには、ダッシュボードの分析レポートのほかにもいくつかの方法があります。</span><span class="sxs-lookup"><span data-stu-id="b4979-126">In addition to the analytic reports in the dashboard, there are several other ways to access your analytic data.</span></span>

### <a name="windows-store-analytics-api"></a><span data-ttu-id="b4979-127">Windows ストア分析 API</span><span class="sxs-lookup"><span data-stu-id="b4979-127">Windows Store analytics API</span></span>

<span data-ttu-id="b4979-128">[Windows ストア分析 API](../monetize/access-analytics-data-using-windows-store-services.md) を使うと、アプリの分析データをプログラムで取得できます。</span><span class="sxs-lookup"><span data-stu-id="b4979-128">Use the [Windows Store analytics API](../monetize/access-analytics-data-using-windows-store-services.md) to programmatically retrieve analytics data for your apps.</span></span> <span data-ttu-id="b4979-129">この REST API では、アプリおよびアドオンの入手数、エラー、アプリの評価とレビューに関するデータを取得できます。</span><span class="sxs-lookup"><span data-stu-id="b4979-129">This REST API enables you to retrieve data for app and add-on acquisitions, errors, app ratings and reviews.</span></span> <span data-ttu-id="b4979-130">この API は、Azure Active Directory (Azure AD) を使って、アプリまたはサービスからの呼び出しを認証します。</span><span class="sxs-lookup"><span data-stu-id="b4979-130">This API uses Azure Active Directory (Azure AD) to authenticate the calls from your app or service.</span></span>

### <a name="windows-dev-center-content-pack-for-power-bi"></a><span data-ttu-id="b4979-131">Power BI 用 Windows デベロッパー センター コンテンツ パック</span><span class="sxs-lookup"><span data-stu-id="b4979-131">Windows Dev Center content pack for Power BI</span></span>

<span data-ttu-id="b4979-132">[Power BI 用 Windows デベロッパー センター コンテンツ パック](https://powerbi.microsoft.com/documentation/powerbi-content-pack-windows-dev-center/)を使うと、デベロッパー センターの分析データを Power BI で確認および監視できます。</span><span class="sxs-lookup"><span data-stu-id="b4979-132">Use the [Windows Dev Center content pack for Power BI](https://powerbi.microsoft.com/documentation/powerbi-content-pack-windows-dev-center/) to explore and monitor your Dev Center analytics data in Power BI.</span></span> <span data-ttu-id="b4979-133">Power BI とは、ビジネス データの 1 つのビューを提供するクラウド ベースのビジネス分析サービスです。</span><span class="sxs-lookup"><span data-stu-id="b4979-133">Power BI is a cloud-based business analytics service that gives you a single view of your business data.</span></span>

<span data-ttu-id="b4979-134">Power BI を使って分析データにアクセスするには、まず、次のリソースをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b4979-134">Use the following resources to get started using Power BI to access your analytics data.</span></span>

* [<span data-ttu-id="b4979-135">Power BI のサインアップ</span><span class="sxs-lookup"><span data-stu-id="b4979-135">Sign up for Power BI</span></span>](https://powerbi.microsoft.com/documentation/powerbi-service-self-service-signup-for-power-bi/)
* [<span data-ttu-id="b4979-136">Power BI の使い方</span><span class="sxs-lookup"><span data-stu-id="b4979-136">Learn how to use Power BI</span></span>](https://powerbi.microsoft.com/guided-learning/)
* [<span data-ttu-id="b4979-137">Power BI 用 Windows デベロッパー センター コンテンツ パックを使って分析データに接続する方法</span><span class="sxs-lookup"><span data-stu-id="b4979-137">Learn how to use the Windows Dev Center content pack for Power BI to connect to your analytics data</span></span>](https://powerbi.microsoft.com/documentation/powerbi-content-pack-windows-dev-center/)

> [!NOTE]
> <span data-ttu-id="b4979-138">Power BI 用 Windows デベロッパー センター コンテンツ パックに接続する際には、デベロッパー センター アカウントに関連付けられた Azure AD ディレクトリの資格情報を指定することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="b4979-138">To connect to the Windows Dev Center content pack for Power BI, we recommend that you specify credentials from an Azure AD directory that is associated with your Dev Center account.</span></span> <span data-ttu-id="b4979-139">Microsoft アカウントの資格情報を使う場合は、Power BI の分析データが自動的に更新されないため、Power BI にサインインしてデータを更新する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b4979-139">If you use your Microsoft account credentials, your analytics data in Power BI does not refresh automatically, and you will need to sign in to Power BI to refresh your data.</span></span> <span data-ttu-id="b4979-140">組織で Office 365 または Microsoft の他のビジネス サービスが既に使用されている場合は、既に Azure AD をお持ちです。</span><span class="sxs-lookup"><span data-stu-id="b4979-140">If your organization already uses Office 365 or other business services from Microsoft, you already have Azure AD.</span></span> <span data-ttu-id="b4979-141">それ以外の場合は、[こちらから無料で入手](http://go.microsoft.com/fwlink/p/?LinkId=703757)できます。</span><span class="sxs-lookup"><span data-stu-id="b4979-141">Otherwise, you can [get it for free](http://go.microsoft.com/fwlink/p/?LinkId=703757).</span></span> <span data-ttu-id="b4979-142">デベロッパー センター アカウントを Azure AD に関連付ける方法について詳しくは、「[アカウント ユーザーの管理](manage-account-users.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b4979-142">For more information about associating your Dev Center account with an Azure AD, see [Manage account users](manage-account-users.md).</span></span>

### <a name="dev-center-app"></a><span data-ttu-id="b4979-143">Dev Center アプリ</span><span class="sxs-lookup"><span data-stu-id="b4979-143">Dev Center app</span></span>

<span data-ttu-id="b4979-144">[Dev Center](https://www.microsoft.com/store/apps/dev-center/9nblggh4r5ws) アプリをインストールすると、すべての Windows 10 デバイスでアプリの正常性とパフォーマンスに関する詳細情報をすばやく確認できます。</span><span class="sxs-lookup"><span data-stu-id="b4979-144">Install the [Dev Center](https://www.microsoft.com/store/apps/dev-center/9nblggh4r5ws) app to quickly view details about the health and performance of your apps on any Windows 10 device.</span></span>

