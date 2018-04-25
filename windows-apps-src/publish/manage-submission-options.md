---
author: jnHs
Description: Manage submission options such as publishing hold options, notes for certification, and more.
title: 申請オプションの管理
ms.author: wdg-dev-content
ms.date: 04/03/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, 公開の保留, 公開日, 申請を送信して公開
ms.localizationpriority: high
ms.openlocfilehash: 4f18a4cae88f78b16ea43856cc6166c67a228c2c
ms.sourcegitcommit: 9f059b37e45099b4314c96a0b604449e966d3c3c
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/04/2018
---
# <a name="manage-submission-options"></a><span data-ttu-id="fe8db-103">申請オプションの管理</span><span class="sxs-lookup"><span data-stu-id="fe8db-103">Manage submission options</span></span>

<span data-ttu-id="fe8db-104">アプリの申請プロセスの **[Submission options]** (申請オプション) ページでは、製品の適切なテストに役立ち詳しい情報を提供できます。</span><span class="sxs-lookup"><span data-stu-id="fe8db-104">The **Submission options** page of the app submission process is where you can provide more information to help us test your product properly.</span></span> <span data-ttu-id="fe8db-105">これは、オプションの手順ですが、多くの申請で推奨されます。</span><span class="sxs-lookup"><span data-stu-id="fe8db-105">This is an optional step, but is recommended for many submissions.</span></span> <span data-ttu-id="fe8db-106">公開プロセスを遅らせたい場合は、必要に応じて公開の保留オプションを設定することもできます。</span><span class="sxs-lookup"><span data-stu-id="fe8db-106">You can also optionally set publishing hold options if you want to delay the publishing process.</span></span>


## <a name="publishing-hold-options"></a><span data-ttu-id="fe8db-107">公開の保留オプション</span><span class="sxs-lookup"><span data-stu-id="fe8db-107">Publishing hold options</span></span>

<span data-ttu-id="fe8db-108">既定では、認定に合格するとすぐに (または、**[価格と使用可能状況]** ページの [[スケジュール]](configure-precise-release-scheduling.md) ページで指定した日付に) 申請が公開されます。</span><span class="sxs-lookup"><span data-stu-id="fe8db-108">By default, we'll publish your submission as soon as it passes certification (or per any dates you specified in the  [Schedule](configure-precise-release-scheduling.md) section of the **Pricing and availability** page).</span></span> <span data-ttu-id="fe8db-109">必要に応じて、特定の日付まで、または手動で公開を指定するまで、公開の申請を保留にすることを選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="fe8db-109">You can optionally choose to place a hold on publishing your submission until a certain date, or until you manually indicate that it should be published.</span></span> <span data-ttu-id="fe8db-110">ここでは、このセクションのオプションについて説明します。</span><span class="sxs-lookup"><span data-stu-id="fe8db-110">The options in this section are described below.</span></span>


### <a name="publish-your-submission-as-soon-as-it-passes-certification-or-per-dates-you-specify"></a><span data-ttu-id="fe8db-111">認定に合格したらすぐに (または指定した日付に) 申請を公開する</span><span class="sxs-lookup"><span data-stu-id="fe8db-111">Publish your submission as soon as it passes certification (or per dates you specify)</span></span>

<span data-ttu-id="fe8db-112">**[Publish this submission as soon as it passes certification (or per dates you selected in the Schedule section)]** (認定後すぐに (または [スケジュール] セクションで選択した日付に) この申請を公開) は既定でオンになっています。つまり、申請が認定に合格するとすぐに公開プロセスが始まることを意味します。ただし、**[価格と使用可能状況]** ページの [[スケジュール]](configure-precise-release-scheduling.md) セクションで日付を構成した場合を除きます。</span><span class="sxs-lookup"><span data-stu-id="fe8db-112">**Publish this submission as soon as it passes certification (or per dates you selected in the Schedule section)** is the default selection, and means that your submission will begin the publishing process as soon as it passes certification, unless you have configured dates in the [Schedule](configure-precise-release-scheduling.md) section of the **Pricing and availability** page.</span></span>   

<span data-ttu-id="fe8db-113">ほとんどの申請では、**[Publishing hold options]** (公開の保留オプション) セクションをこのオプションに設定したままにすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="fe8db-113">For most submissions, we recommend leaving the **Publishing hold options** section set to this option.</span></span> <span data-ttu-id="fe8db-114">申請を公開する特定の日付を指定する場合、**[Publish this submission as soon as it passes certification (or per dates you selected in the Schedule section)]** (認定後すぐに (または [スケジュール] セクションで選択した日付に) この申請を公開) を使います。</span><span class="sxs-lookup"><span data-stu-id="fe8db-114">If you want to specify certain dates for your submission to be published, use the **Publish this submission as soon as it passes certification (or per dates you selected in the Schedule section)**.</span></span> <span data-ttu-id="fe8db-115">このセクションを既定のオプションのままにすると、**[スケジュール]** セクションで設定した日付より前に申請が公開されることはありません。</span><span class="sxs-lookup"><span data-stu-id="fe8db-115">Leaving this section set to the default option will not cause the submission to be published earlier than the date(s) that you set in the **Schedule** section.</span></span> <span data-ttu-id="fe8db-116">**[スケジュール]** セクションで選択した日付は、ユーザーが Microsoft Store でアプリを利用できるようになる時期を決定するために使われます。</span><span class="sxs-lookup"><span data-stu-id="fe8db-116">The dates you selected in the **Schedule** section will be used to determine when your app becomes available to customers in the Store.</span></span>


### <a name="publish-your-submission-manually"></a><span data-ttu-id="fe8db-117">手動で申請を公開する</span><span class="sxs-lookup"><span data-stu-id="fe8db-117">Publish your submission manually</span></span>

<span data-ttu-id="fe8db-118">まだリリース日を設定せず、手動で公開プロセスを開始するまで申請を非公開のままにする場合は、**[[今すぐ公開] を選ぶまで、この申請を公開しません]** を選択できます。</span><span class="sxs-lookup"><span data-stu-id="fe8db-118">If you don’t want to set a release date yet, and you prefer your submission to remain unpublished until you manually decide to start the publishing process, you can choose **Don't publish this submission until I select Publish now**.</span></span> <span data-ttu-id="fe8db-119">このオプションを選択した場合、開発者が指示するまで申請は公開されません。</span><span class="sxs-lookup"><span data-stu-id="fe8db-119">Choosing this option means that your selection won’t be published until you indicate that it should be.</span></span> <span data-ttu-id="fe8db-120">アプリが認定に合格した後、認定のステータス ページで **[今すぐ公開]** を選択するか、以下に説明するのと同じ方法で特定の日付を選択すると、申請を公開することができます。</span><span class="sxs-lookup"><span data-stu-id="fe8db-120">After your app passes certification, you can publish it by selecting **Publish now** on the certification status page, or by selecting a specific date in the same manner as described below.</span></span>


### <a name="start-publishing-your-submission-on-a-certain-date"></a><span data-ttu-id="fe8db-121">特定の日に申請の公開を開始する</span><span class="sxs-lookup"><span data-stu-id="fe8db-121">Start publishing your submission on a certain date</span></span>

<span data-ttu-id="fe8db-122">申請が特定の日付まで公開されないようにするには、**[この申請の公開を開始する日付]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="fe8db-122">Choose **Start publishing this submission on** to ensure that the submission is not published until a certain date.</span></span> <span data-ttu-id="fe8db-123">このオプションを選ぶと、申請は指定された日付の当日またはその日以降に、できるだけ早くリリースされます。</span><span class="sxs-lookup"><span data-stu-id="fe8db-123">With this option, your submission will be released as soon as possible on or after the date you specify.</span></span> <span data-ttu-id="fe8db-124">日付は 24 時間以上先の日付にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="fe8db-124">The date must be at least 24 hours in the future.</span></span> <span data-ttu-id="fe8db-125">日付と同時に、申請を公開し始める時刻を指定することもできます。</span><span class="sxs-lookup"><span data-stu-id="fe8db-125">Along with the date, you can also specify the time at which the submission should begin to be published.</span></span> 

<span data-ttu-id="fe8db-126">アプリの提出後にこのリリース日を変更することができます。ただし [公開] ステップに入る前に限ります。</span><span class="sxs-lookup"><span data-stu-id="fe8db-126">You can change this release date after submitting your app, as long as it hasn’t entered the Publish step yet.</span></span> 
 
<span data-ttu-id="fe8db-127">前述のように、申請が公開される特定の日付を指定する場合、**[Publish this submission as soon as it passes certification (or per dates you selected in the Schedule section)]** (認定後すぐに (または [スケジュール] セクションで選択した日付に) この申請を公開) を使い、**[Publishing hold options]** (公開の保留オプション) を既定の選択に設定したままにします。</span><span class="sxs-lookup"><span data-stu-id="fe8db-127">As noted earlier, if you want to specify certain dates for your submission to be published, use the **Publish this submission as soon as it passes certification (or per dates you selected in the Schedule section)** and leave the **Publishing hold options** set to the default selection.</span></span> <span data-ttu-id="fe8db-128">**[この申請の公開を開始する日付]** オプションを使うと、その日まで公開プロセスが開始されませんが、認定や公開が遅れると実際のリリース日が選択した日付より後になる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="fe8db-128">Using the **Start publishing this submission on** option means that your submission will not start the publishing process until that date, but delays during certification or publishing could cause the actual release date to be later than the date you select.</span></span> 


## <a name="notes-for-certification"></a><span data-ttu-id="fe8db-129">認定の注意書き</span><span class="sxs-lookup"><span data-stu-id="fe8db-129">Notes for certification</span></span>

<span data-ttu-id="fe8db-130">アプリの提出時に、**[認定の注意書き]** ページを使って、認定審査担当者に追加情報を提供することができます。</span><span class="sxs-lookup"><span data-stu-id="fe8db-130">As you submit your app, you have the option to use the **Notes for certification** page to provide additional info to the certification testers.</span></span> <span data-ttu-id="fe8db-131">この情報は、アプリを正しく審査するために使用されます。</span><span class="sxs-lookup"><span data-stu-id="fe8db-131">This info can help ensure that your app is tested correctly.</span></span> 

<span data-ttu-id="fe8db-132">詳しくは、「[認定の注意書き](notes-for-certification.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="fe8db-132">For more info, see [Notes for certification](notes-for-certification.md).</span></span>

