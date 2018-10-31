---
author: jnHs
Description: When you finish creating your app's submission and click Submit to the Store, the submission enters the certification step.
title: アプリの認定プロセス
ms.assetid: 0DCB4344-224D-4E5A-899F-FF7A89F23DBC
ms.author: wdg-dev-content
ms.date: 10/31/2018
ms.topic: article
keywords: windows 10, uwp, 公開, 前処理, 認定, リリース, 保留, 申請, 公開, ステータス、時間
ms.localizationpriority: medium
ms.openlocfilehash: 161a95141511bc00b1d1a707e893d85dccfa8409
ms.sourcegitcommit: ca96031debe1e76d4501621a7680079244ef1c60
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/30/2018
ms.locfileid: "5835939"
---
# <a name="the-app-certification-process"></a><span data-ttu-id="aa2b2-103">アプリの認定プロセス</span><span class="sxs-lookup"><span data-stu-id="aa2b2-103">The app certification process</span></span>

<span data-ttu-id="aa2b2-104">アプリの申請の作成が完了し、**[Microsoft Store に提出]** をクリックすると、申請が認定手順に入ります。</span><span class="sxs-lookup"><span data-stu-id="aa2b2-104">When you finish creating your app's submission and click **Submit to the Store**, the submission enters the certification step.</span></span> <span data-ttu-id="aa2b2-105">このプロセスは通常、数時間以内に完了しますが、場合によっては最大で 3 営業日かかることがあります。</span><span class="sxs-lookup"><span data-stu-id="aa2b2-105">This process usually is completed within a few hours, though in some cases it may take up to three business days.</span></span> <span data-ttu-id="aa2b2-106">申請が認定に合格した後、ユーザーを新しい申請または更新した提出パッケージに変更が、アプリの登録情報を表示するには、最大 24 時間がかかることができます。</span><span class="sxs-lookup"><span data-stu-id="aa2b2-106">After your submission passes certification, it can take up to 24 hours for customers to see the app’s listing for a new submission, or for an updated submission with changes to packages.</span></span> <span data-ttu-id="aa2b2-107">更新は、ストア登録情報の詳細のみを変更する場合は、1 時間以内に公開プロセスが完了します。</span><span class="sxs-lookup"><span data-stu-id="aa2b2-107">If your update only changes Store listing details, the publishing process will be completed in less than an hour.</span></span>  <span data-ttu-id="aa2b2-108">申請が公開されるとダッシュ ボードで、アプリの状態が**ストア内**になります。 ときに通知されます。</span><span class="sxs-lookup"><span data-stu-id="aa2b2-108">You'll be notified when your submission is published, and the app's status in the dashboard will be **In the Store**.</span></span>

## <a name="preprocessing"></a><span data-ttu-id="aa2b2-109">前処理</span><span class="sxs-lookup"><span data-stu-id="aa2b2-109">Preprocessing</span></span>

<span data-ttu-id="aa2b2-110">アプリのパッケージを正常にアップロードし、認定のためにアプリを提出すると、パッケージはテストを受けるためのキューに登録されます。</span><span class="sxs-lookup"><span data-stu-id="aa2b2-110">After you successfully upload the app's packages and submit the app for certification, the packages are queued for testing.</span></span> <span data-ttu-id="aa2b2-111">前処理中にエラーを検出した場合は、メッセージを表示します。</span><span class="sxs-lookup"><span data-stu-id="aa2b2-111">We'll display a message if we detect any errors during preprocessing.</span></span> <span data-ttu-id="aa2b2-112">可能性のあるエラーについて詳しくは、「[申請エラーの解決](resolve-submission-errors.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="aa2b2-112">For more info on possible errors, see [Resolve submission errors](resolve-submission-errors.md).</span></span>

## <a name="certification"></a><span data-ttu-id="aa2b2-113">認定</span><span class="sxs-lookup"><span data-stu-id="aa2b2-113">Certification</span></span>

<span data-ttu-id="aa2b2-114">このフェーズでは、いくつかのテストが行われます。</span><span class="sxs-lookup"><span data-stu-id="aa2b2-114">During this phase, several tests are conducted:</span></span>

-   <span data-ttu-id="aa2b2-115">**セキュリティ テスト:** 最初のテストでは、アプリのパッケージがチェックされ、ウイルスやマルウェアに感染していないか確認が行われます。</span><span class="sxs-lookup"><span data-stu-id="aa2b2-115">**Security tests:** This first test checks your app's packages for viruses and malware.</span></span> <span data-ttu-id="aa2b2-116">このテストで不合格になった場合は、最新のウイルス対策ソフトウェアを実行して開発システムをチェックしてから、クリーンなシステム上でアプリのパッケージをリビルドする必要があります。</span><span class="sxs-lookup"><span data-stu-id="aa2b2-116">If your app fails this test, you'll need to check your development system by running the latest antivirus software, then rebuild your app's package on a clean system.</span></span>
-   <span data-ttu-id="aa2b2-117">**技術的な適合性のテスト:** 技術的な適合性のテストは、Windows アプリ認定キットを使って行われます。</span><span class="sxs-lookup"><span data-stu-id="aa2b2-117">**Technical compliance tests:** Technical compliance is tested by the Windows App Certification Kit.</span></span> <span data-ttu-id="aa2b2-118">(開発者は、ストアに提出する前に必ず [Windows アプリ認定キットでアプリのテスト](../debug-test-perf/windows-app-certification-kit.md)を実施する必要があります)。</span><span class="sxs-lookup"><span data-stu-id="aa2b2-118">(You should always make sure to [test your app with the Windows App Certification Kit](../debug-test-perf/windows-app-certification-kit.md) before you submit it to the Store.)</span></span>
-   <span data-ttu-id="aa2b2-119">**コンテンツの適合性:** このテストにかかる時間は、アプリの複雑さ、視覚的なコンテンツの量、同時期に提出されたアプリの数などによって異なります。</span><span class="sxs-lookup"><span data-stu-id="aa2b2-119">**Content compliance:** The amount of time this takes varies depending on how complex your app is, how much visual content it has, and how many apps have been submitted recently.</span></span> <span data-ttu-id="aa2b2-120">認定を求めるにあたって伝えておく必要のある情報があれば、[[Notes for certification]](notes-for-certification.md) (認定を求めるにあたってのコメント) ページに記入してください。</span><span class="sxs-lookup"><span data-stu-id="aa2b2-120">Be sure to provide any info that testers should be aware of in the [Notes for certification](notes-for-certification.md) page.</span></span>

<span data-ttu-id="aa2b2-121">認定プロセスが完了した後、アプリが認定に合格したかどうかを示す認定レポートをお届けします。</span><span class="sxs-lookup"><span data-stu-id="aa2b2-121">After the certification process is complete, you'll get a certification report telling you whether or not your app passed certification.</span></span> <span data-ttu-id="aa2b2-122">アプリが認定されなかった場合、レポートには、どのテストに不合格になり、どの[ポリシー](https://docs.microsoft.com/legal/windows/agreements/store-policies)を満たしていなかったかが示されます。</span><span class="sxs-lookup"><span data-stu-id="aa2b2-122">If it didn't pass, the report will indicate which test failed or which [policy](https://docs.microsoft.com/legal/windows/agreements/store-policies) was not met.</span></span> <span data-ttu-id="aa2b2-123">問題の修正後、アプリの新しい申請を作成して、認定プロセスを再び始めることができます。</span><span class="sxs-lookup"><span data-stu-id="aa2b2-123">After you fix the problem, you can create a new submission for your app to start the certification process again.</span></span>

## <a name="release"></a><span data-ttu-id="aa2b2-124">リリース</span><span class="sxs-lookup"><span data-stu-id="aa2b2-124">Release</span></span>

<span data-ttu-id="aa2b2-125">アプリが認定に合格するときは、**公開**のプロセスへの移行する準備が。</span><span class="sxs-lookup"><span data-stu-id="aa2b2-125">When your app passes certification, it's ready to move to the **Publishing** process.</span></span>

- <span data-ttu-id="aa2b2-126">申請する必要があります (既定のオプション) をできる限り早く公開することを指定した場合は、すぐ公開プロセスが開始されます。</span><span class="sxs-lookup"><span data-stu-id="aa2b2-126">If you've indicated that your submission should be published as soon as possible (the default option), the publishing process will begin right away.</span></span>
- <span data-ttu-id="aa2b2-127">初めてこれがある場合、アプリが公開されていると[スケジュール](configure-precise-release-scheduling.md#release)] セクションで**リリース日**を指定したと、アプリは、**リリース日**の選択に従って利用可能です。</span><span class="sxs-lookup"><span data-stu-id="aa2b2-127">If this is the first time you've published the app, and you specified a **Release date** in the [Schedule](configure-precise-release-scheduling.md#release) section, the app will become available according to your **Release date** selections.</span></span>
- <span data-ttu-id="aa2b2-128">使用する場合[の公開のオプションを保持する](manage-submission-options.md#publishing-hold-options)ことが必要がありますまでリリースされません、特定の日付を指定する、**変更のリリース日**を選択した場合を除き、公開のプロセスを開始するには、その日付まで待機しますがします。</span><span class="sxs-lookup"><span data-stu-id="aa2b2-128">If you've used [Publishing hold options](manage-submission-options.md#publishing-hold-options) to specify that it should not be released until a certain date, we'll wait until that date to begin the publishing process, unless you select **Change release date**.</span></span>
- <span data-ttu-id="aa2b2-129">使用する場合[の公開保持オプション](manage-submission-options.md#publishing-hold-options)を手動で申請を公開することを指定する、**今すぐ公開**を選択 (または**変更リリース日**を選択して特定の日付の選択) まで公開プロセスを開始しません。</span><span class="sxs-lookup"><span data-stu-id="aa2b2-129">If you've used [Publishing hold options](manage-submission-options.md#publishing-hold-options) to specify that you want to publish the submission manually, we won't start the publishing process until you select **Publish now** (or select **Change release date** and pick a specific date).</span></span>


## <a name="publishing"></a><span data-ttu-id="aa2b2-130">公開</span><span class="sxs-lookup"><span data-stu-id="aa2b2-130">Publishing</span></span>

<span data-ttu-id="aa2b2-131">リリース後の改ざん防止のために、アプリのパッケージにはデジタル署名が施されます。</span><span class="sxs-lookup"><span data-stu-id="aa2b2-131">Your app's packages are digitally signed to protect them against tampering after they have been released.</span></span> <span data-ttu-id="aa2b2-132">このフェーズが始まると、申請をキャンセルしたり、リリース日を変更したりすることはできません。</span><span class="sxs-lookup"><span data-stu-id="aa2b2-132">Once this phase has begun, you can no longer cancel your submission or change its release date.</span></span>

<span data-ttu-id="aa2b2-133">新しいアプリとアプリのパッケージへの変更が含まれる更新プログラムは、公開のプロセスは 24 時間内で実行されます。</span><span class="sxs-lookup"><span data-stu-id="aa2b2-133">For new apps and updates which include changes to the app's packages, the publishing process will be completed within 24 hours.</span></span> <span data-ttu-id="aa2b2-134">更新プログラムの登録情報の詳細については、ストアなどのオプションを変更するが、アプリのパッケージを変更しないでくださいのみ、公開のプロセスには 1 時間以内にかかる時間します。</span><span class="sxs-lookup"><span data-stu-id="aa2b2-134">For updates that only change options such as Store listing details, but don't change the app's packages, the publishing process will take less than one hour.</span></span>

<span data-ttu-id="aa2b2-135">アプリは、公開フェーズ中に、アプリの申請の状態] 列で**詳細を表示する**リンクが、新しいパッケージとストア登録情報の各、サポートされている OS バージョンのユーザーに提供できます。</span><span class="sxs-lookup"><span data-stu-id="aa2b2-135">While your app is in the publishing phase, the **Show details** link in the Status column for your app’s submission lets you know when your new packages and Store listing details are available to customers on each of your supported OS versions.</span></span> <span data-ttu-id="aa2b2-136">まだ完了していない手順は **"保留中"** と表示されます。</span><span class="sxs-lookup"><span data-stu-id="aa2b2-136">Steps that have not yet completed will show **Pending**.</span></span> <span data-ttu-id="aa2b2-137">アプリのプロセスが完了するまで公開フェーズのままですが、つまり、新しいパッケージ、登録情報の詳細や、すべてのアプリの潜在的なユーザーに利用可能です。</span><span class="sxs-lookup"><span data-stu-id="aa2b2-137">Your app will remain in the publishing phase until the process has completed, meaning that the new packages and/or listing details are available to all of your app’s potential customers.</span></span>

## <a name="in-the-store"></a><span data-ttu-id="aa2b2-138">ストア内</span><span class="sxs-lookup"><span data-stu-id="aa2b2-138">In the Store</span></span> 

<span data-ttu-id="aa2b2-139">上記の手順が正常に完了すると、申請の状態が **[公開中]** から **[Microsoft Store 内]** に変わります。</span><span class="sxs-lookup"><span data-stu-id="aa2b2-139">After successfully going through the steps above, the submission's status will change from **Publishing** to **In the Store**.</span></span> <span data-ttu-id="aa2b2-140">その後、申請したアプリは Microsoft Store でユーザーがダウンロードできるようになります (他の[見つけやすさ](choose-visibility-options.md#discoverability)オプションを選んでいる場合は除きます)。</span><span class="sxs-lookup"><span data-stu-id="aa2b2-140">Your submission will then be available in the Microsoft Store for customers to download (unless you have chosen another [Discoverability](choose-visibility-options.md#discoverability) option).</span></span> 

> [!NOTE]
> <span data-ttu-id="aa2b2-141">アプリの公開後にもスポット チェックが実施され、発生する可能性のある問題の検出や、アプリが [Microsoft Store ポリシー](https://docs.microsoft.com/legal/windows/agreements/store-policies)のすべてに準拠しているかどうかの確認が行われます。</span><span class="sxs-lookup"><span data-stu-id="aa2b2-141">We also conduct spot checks of apps after they've been published so we can identify potential problems and ensure that your app complies with all of the [Microsoft Store Policies](https://docs.microsoft.com/legal/windows/agreements/store-policies).</span></span> <span data-ttu-id="aa2b2-142">アプリに問題が見つかった場合は、問題とその修正方法が通知されます。または、ストアからのアプリの削除が妥当な場合は、削除されたことが通知されます。</span><span class="sxs-lookup"><span data-stu-id="aa2b2-142">If we find any problems, you'll be notified about the issue and how to fix it, if applicable, or if it has been removed from the Store.</span></span>

 

 

 




