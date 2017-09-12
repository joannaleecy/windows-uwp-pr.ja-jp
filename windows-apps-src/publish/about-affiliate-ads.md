---
author: jnHs
Description: "アプリにバナー広告が表示される場合、Microsoft アフィリエイト広告をアプリに表示することで、広告のフィル レートと収益を増やすことができます。"
title: "アフィリエイト広告について"
ms.assetid: 7B5478FB-7E68-4956-82EF-B43C2873E3EF
ms.author: wdg-dev-content
ms.date: 07/06/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp
ms.openlocfilehash: db10a33e29437be11765f6b0a4d028404256a8b3
ms.sourcegitcommit: 10f8dcf69d37cdb61562fc9f4d268ccb499c368f
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/07/2017
---
# <a name="about-affiliate-ads"></a><span data-ttu-id="6800e-104">アフィリエイト広告について</span><span class="sxs-lookup"><span data-stu-id="6800e-104">About affiliate ads</span></span>

<span data-ttu-id="6800e-105">アプリに[バナー広告が表示](../monetize/display-ads-in-your-app.md)される場合、ストアの製品に関する Microsoft アフィリエイト広告をアプリに表示することで、広告の収益とフィル レートを増やすことができます。</span><span class="sxs-lookup"><span data-stu-id="6800e-105">If your app [displays banner ads](../monetize/display-ads-in-your-app.md), you can increase your revenue and ad fill rate by showing Microsoft affiliate ads in your app for products in the Store.</span></span> <span data-ttu-id="6800e-106">ユーザーがアフィリエイト広告をクリックして一定の期間内に製品を購入すると、承認された購入について収益を獲得できます。</span><span class="sxs-lookup"><span data-stu-id="6800e-106">When users click the affiliate ads and buy products within a given attribution window, you earn revenue on approved purchases.</span></span>

<span data-ttu-id="6800e-107">このプログラムの内容を次に示します。</span><span class="sxs-lookup"><span data-stu-id="6800e-107">Here's how this program works:</span></span>

* <span data-ttu-id="6800e-108">デベロッパー センターで [Microsoft アフィリエイト広告プログラムにオプトイン](#opt-in)すると、Microsoft がストア内の有力製品の広告を選択してアプリに提供します。</span><span class="sxs-lookup"><span data-stu-id="6800e-108">After you [opt-in to the Microsoft affiliate ads program](#opt-in) in Dev Center, Microsoft picks ads for top products in the Store to serve to your app.</span></span> <span data-ttu-id="6800e-109">アプリ、ゲーム、音楽、映画、ハードウェア、およびソフトウェアがこれらの製品に含まれます。</span><span class="sxs-lookup"><span data-stu-id="6800e-109">These products may include apps, games, music, movies, hardware, and software.</span></span>

 > [!NOTE]
 > <span data-ttu-id="6800e-110">Microsoft が提供するアフィリエイト広告の広告ユニット サイズは、300 x 50、480 x 80、160 x 600、300 x 250、728 x 90 のみです。</span><span class="sxs-lookup"><span data-stu-id="6800e-110">Microsoft only serves affiliate ads to the following ad unit sizes: 300 x 50, 480 x 80, 160 x 600, 300 x 250, or 728 x 90.</span></span>

* <span data-ttu-id="6800e-111">Microsoft がアフィリエイト広告をアプリに提供するのは、他の広告ネットワークの広告が利用できない場合のみです。</span><span class="sxs-lookup"><span data-stu-id="6800e-111">Microsoft will serve affiliate ads to your app only when no ads from other ad networks are available.</span></span> <span data-ttu-id="6800e-112">これは、満たされないインプレッションを収益につなげ、広告のフィル レートを最大限に高めることを目的としています。</span><span class="sxs-lookup"><span data-stu-id="6800e-112">This is intended to help to monetize your unfilled impressions and maximize your ad fill rate.</span></span>
* <span data-ttu-id="6800e-113">ユーザーがアフィリエイト広告をクリックして一定の期間内にストアの製品を購入すると、その購入に対する収益の配分または固定の手数料 (最大 10%) を獲得できます。</span><span class="sxs-lookup"><span data-stu-id="6800e-113">When a user clicks an affiliate ad and buys any product in the Store within a given attribution window, you will be paid a revenue share or a fixed commission for the purchase (up to 10% commission).</span></span>

  <span data-ttu-id="6800e-114">手数料の対象となるのは、Windows 10 デバイスのストアまたは Web ベースのストアでの販売のみです。Windows 8.x デバイスのストアでの販売は対象外です。</span><span class="sxs-lookup"><span data-stu-id="6800e-114">To be eligible for a commission, the affiliate ad must result in an eligible sale in either the Store on Windows 10 devices or the web-based Store; sales in the Store on Windows 8.x devices are not eligible for a commission.</span></span> <span data-ttu-id="6800e-115">デジタル ストアの製品 (アプリ、ゲーム、音楽、映画など) のアフィリエイト広告は、Windows 10 デバイスにのみ提供されます。</span><span class="sxs-lookup"><span data-stu-id="6800e-115">Affiliate ads for digital Store products (including apps, games, music and movies) are only served on Windows 10 devices.</span></span> <span data-ttu-id="6800e-116">Web ベースのストアの製品 (デバイス、ソフトウェアなど) のアフィリエイト広告は、Windows 10 デバイスと Windows 8.x デバイスに提供されます。</span><span class="sxs-lookup"><span data-stu-id="6800e-116">Affiliate ads for products in the web-based Store (including devices and software) are served on Windows 10 and Windows 8.x devices.</span></span>

 > [!NOTE]
 > <span data-ttu-id="6800e-117">アプリ内で販売促進を行った製品だけでなく、一定の期間内にユーザーが購入した*すべての*製品について支払いを受けることができます。</span><span class="sxs-lookup"><span data-stu-id="6800e-117">You can get paid for *any* product the user purchases within the attribution window, not just the product that was promoted in your app.</span></span> <span data-ttu-id="6800e-118">アプリ内で販売促進を行った無料アプリについては、一定の期間内におけるユーザーのアプリ内購入の収益配分を獲得できます。</span><span class="sxs-lookup"><span data-stu-id="6800e-118">For free apps that are promoted in your app, you can earn a revenue share for in-app purchases made by the user within the attribution window.</span></span>

* <span data-ttu-id="6800e-119">Microsoft アフィリエイト広告プログラムに関連して獲得した売り上げは、他の広告による売り上げと併せて、[デベロッパー センターで設定した受取りアカウント](setting-up-your-payout-account-and-tax-forms.md)に配分されます。</span><span class="sxs-lookup"><span data-stu-id="6800e-119">Any earnings you accrue in connection with the Microsoft affiliate ads program will be distributed to you in the [payout account you set up in Dev Center](setting-up-your-payout-account-and-tax-forms.md), along with your other advertising earnings.</span></span>
* <span data-ttu-id="6800e-120">アプリ内のアフィリエイト広告のパフォーマンスを追跡するには、「[[広告パフォーマンス] レポート](advertising-performance-report.md)」の「**アフィリエイト パフォーマンス**」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6800e-120">To track the performance of the affiliate ads in your app, refer to the **Affiliates performance** section of the [Advertising performance report](advertising-performance-report.md).</span></span> <span data-ttu-id="6800e-121">アプリ内のアフィリエイト広告を経由して行われた 1 日の購入および受け取った収益配分を追跡できます。</span><span class="sxs-lookup"><span data-stu-id="6800e-121">You can track daily purchases made through affiliate ads in your app and the revenue share that you received.</span></span>  

 > [!NOTE]
 > <span data-ttu-id="6800e-122">お客様がストアで製品を購入してからアフィリエイト広告プログラムで承認されるまでには 45 日かかります。</span><span class="sxs-lookup"><span data-stu-id="6800e-122">After a customer buys a product in the Store, there is a 45 day waiting period before the purchase can be approved for the affiliate ads program.</span></span> <span data-ttu-id="6800e-123">この待期期間があるため、この期間中は購入の承認または拒否に伴い、[[広告パフォーマンス] レポート](advertising-performance-report.md)の **[アフィリエイト パフォーマンス]** セクションに表示されるデータが変動する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="6800e-123">Because of this waiting period, you may see some of the data in the **Affiliates performance** section of the [Advertising performance report](advertising-performance-report.md) change during this period, as purchases are approved or rejected.</span></span>

<span id="opt-in" />
## <a name="how-to-opt-in-to-the-affiliate-ads-program"></a><span data-ttu-id="6800e-124">アフィリエイト広告プログラムにオプトインする方法</span><span class="sxs-lookup"><span data-stu-id="6800e-124">How to opt in to the affiliate ads program</span></span>

<span data-ttu-id="6800e-125">アプリの Microsoft アフィリエイト広告プログラムにオプトインするには、次の手順を実行します。</span><span class="sxs-lookup"><span data-stu-id="6800e-125">To opt in to the Microsoft affiliate ads program for an app:</span></span>

1. <span data-ttu-id="6800e-126">Windows デベロッパー センター ダッシュボードで、アプリの **[収益化]** &gt; **[広告で収入を増やす]** ページにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="6800e-126">Go to the **Monetization** &gt; **Monetize with ads** page for your app in the Windows Dev Center dashboard.</span></span>
2. <span data-ttu-id="6800e-127">**[Microsoft affiliate ads]** (Microsoft アフィリエイト広告) セクションの **[Show Microsoft affiliate ads in my app]** (アプリに Microsoft アフィリエイト広告を表示する) チェック ボックスをオンにします。</span><span class="sxs-lookup"><span data-stu-id="6800e-127">In the **Microsoft affiliate ads** section, check the **Show Microsoft affiliate ads in my app** box.</span></span>

<span data-ttu-id="6800e-128">このチェック ボックスをオンまたはオフにした後、アプリを再公開して変更を有効にする必要はありません。</span><span class="sxs-lookup"><span data-stu-id="6800e-128">After you check or uncheck this box, you do not need to republish your app for the changes to take effect.</span></span>

