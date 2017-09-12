---
author: jnHs
Description: "アプリの申請の作成が完了し、[ストアに提出] をクリックすると、認定手順に入ります。"
title: "アプリの認定プロセス"
ms.assetid: 0DCB4344-224D-4E5A-899F-FF7A89F23DBC
ms.author: wdg-dev-content
ms.date: 04/13/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: f075dc6e112a526d7aee71f0f9aa7d4da570d649
ms.sourcegitcommit: cd9b4bdc9c3a0b537a6e910a15df8541b49abf9c
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/21/2017
---
# <a name="the-app-certification-process"></a><span data-ttu-id="03aa1-104">アプリの認定プロセス</span><span class="sxs-lookup"><span data-stu-id="03aa1-104">The app certification process</span></span>

<span data-ttu-id="03aa1-105">アプリの申請の作成が完了し、**[ストアに提出]** をクリックすると、認定手順に入ります。</span><span class="sxs-lookup"><span data-stu-id="03aa1-105">When you are finished creating your app's submission and click **Submit to the Store**, it enters the certification step.</span></span> <span data-ttu-id="03aa1-106">このプロセスは通常、数時間以内に完了しますが、場合によっては最大で 3 営業日かかることがあります。</span><span class="sxs-lookup"><span data-stu-id="03aa1-106">This process usually is completed within a few hours, though in some cases it may take up to three business days.</span></span> <span data-ttu-id="03aa1-107">申請が認定に合格した後、ユーザーがストア内でアプリの掲載ページ (または前に公開したアプリの更新プログラム) を表示できるようになるまで最大 24 時間かかる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="03aa1-107">After your submission passes certification, it can take up to 24 hours for customers to see the app’s listing (or your updates to a previously published app) in the Store.</span></span> <span data-ttu-id="03aa1-108">申請したアプリが公開されてユーザーが利用できるようになった時点で通知が表示され、ダッシュボードのアプリの状態が **[ストア内]** になります。</span><span class="sxs-lookup"><span data-stu-id="03aa1-108">You'll see a notification when your submission is published and available to customers, and the app's status in the dashboard will be **In the Store**.</span></span>

## <a name="preprocessing"></a><span data-ttu-id="03aa1-109">前処理</span><span class="sxs-lookup"><span data-stu-id="03aa1-109">Preprocessing</span></span>

<span data-ttu-id="03aa1-110">アプリのパッケージを正常にアップロードし、認定のためにアプリを提出すると、パッケージはテストを受けるためのキューに登録されます。</span><span class="sxs-lookup"><span data-stu-id="03aa1-110">After you successfully upload the app's packages and submit the app for certification, the packages are queued for testing.</span></span> <span data-ttu-id="03aa1-111">前処理中にエラーを検出した場合は、メッセージを表示します。</span><span class="sxs-lookup"><span data-stu-id="03aa1-111">We'll display a message if we detect any errors during preprocessing.</span></span> <span data-ttu-id="03aa1-112">可能性のあるエラーについて詳しくは、「[申請エラーの解決](resolve-submission-errors.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="03aa1-112">For more info on possible errors, see [Resolve submission errors](resolve-submission-errors.md).</span></span>

## <a name="certification"></a><span data-ttu-id="03aa1-113">認定</span><span class="sxs-lookup"><span data-stu-id="03aa1-113">Certification</span></span>

<span data-ttu-id="03aa1-114">このフェーズでは、いくつかのテストが行われます。</span><span class="sxs-lookup"><span data-stu-id="03aa1-114">During this phase, several tests are conducted:</span></span>

-   <span data-ttu-id="03aa1-115">**セキュリティ テスト:** 最初のテストでは、アプリのパッケージがチェックされ、ウイルスやマルウェアに感染していないか確認が行われます。</span><span class="sxs-lookup"><span data-stu-id="03aa1-115">**Security tests:** This first test checks your app's packages for viruses and malware.</span></span> <span data-ttu-id="03aa1-116">このテストで不合格になった場合は、最新のウイルス対策ソフトウェアを実行して開発システムをチェックしてから、クリーンなシステム上でアプリのパッケージをリビルドする必要があります。</span><span class="sxs-lookup"><span data-stu-id="03aa1-116">If your app fails this test, you'll need to check your development system by running the latest antivirus software, then rebuild your app's package on a clean system.</span></span>
-   <span data-ttu-id="03aa1-117">**技術的な適合性のテスト:** 技術的な適合性のテストは、Windows アプリ認定キットを使って行われます。</span><span class="sxs-lookup"><span data-stu-id="03aa1-117">**Technical compliance tests:** Technical compliance is tested by the Windows App Certification Kit.</span></span> <span data-ttu-id="03aa1-118">(開発者は、ストアに提出する前に必ず [Windows アプリ認定キットでアプリのテスト](../debug-test-perf/windows-app-certification-kit.md)を実施する必要があります)。</span><span class="sxs-lookup"><span data-stu-id="03aa1-118">(You should always make sure to [test your app with the Windows App Certification Kit](../debug-test-perf/windows-app-certification-kit.md) before you submit it to the Store.)</span></span>
-   <span data-ttu-id="03aa1-119">**コンテンツの適合性:** このテストにかかる時間は、アプリの複雑さ、視覚的なコンテンツの量、同時期に提出されたアプリの数などによって異なります。</span><span class="sxs-lookup"><span data-stu-id="03aa1-119">**Content compliance:** The amount of time this takes varies depending on how complex your app is, how much visual content it has, and how many apps have been submitted recently.</span></span> <span data-ttu-id="03aa1-120">認定を求めるにあたって伝えておく必要のある情報があれば、[[Notes for certification]](notes-for-certification.md) (認定を求めるにあたってのコメント) ページに記入してください。</span><span class="sxs-lookup"><span data-stu-id="03aa1-120">Be sure to provide any info that testers should be aware of in the [Notes for certification](notes-for-certification.md) page.</span></span>

<span data-ttu-id="03aa1-121">認定プロセスが完了した後、アプリが認定に合格したかどうかを示す認定レポートをお届けします。</span><span class="sxs-lookup"><span data-stu-id="03aa1-121">After the certification process is complete, you'll get a certification report telling you whether or not your app passed certification.</span></span> <span data-ttu-id="03aa1-122">アプリが認定されなかった場合、レポートには、どのテストに不合格になり、どの[ポリシー](https://msdn.microsoft.com/library/windows/apps/dn764944)を満たしていなかったかが示されます。</span><span class="sxs-lookup"><span data-stu-id="03aa1-122">If it didn't pass, the report will indicate which test failed or which [policy](https://msdn.microsoft.com/library/windows/apps/dn764944) was not met.</span></span> <span data-ttu-id="03aa1-123">問題の修正後、アプリの新しい申請を作成して、認定プロセスを再び始めることができます。</span><span class="sxs-lookup"><span data-stu-id="03aa1-123">After you fix the problem, you can create a new submission for your app to start the certification process again.</span></span>

## <a name="release"></a><span data-ttu-id="03aa1-124">リリース</span><span class="sxs-lookup"><span data-stu-id="03aa1-124">Release</span></span>

<span data-ttu-id="03aa1-125">アプリが認定に合格すると、**公開**プロセスに進むことができます。</span><span class="sxs-lookup"><span data-stu-id="03aa1-125">When your app passes certification, it's ready to move to the to the **Publishing** process.</span></span> <span data-ttu-id="03aa1-126">できる限り早く申請が公開されるように指定していた場合、このプロセスはすぐに始まります。</span><span class="sxs-lookup"><span data-stu-id="03aa1-126">If you've indicated that your submission should be published as soon as possible, this will happen right away.</span></span> <span data-ttu-id="03aa1-127">特定の日付までアプリがリリースされないように指定していた場合は、その日付までリリースされません。ただし、**[リリース日の変更]** へのリンクをクリックして、その日付を変更できます。</span><span class="sxs-lookup"><span data-stu-id="03aa1-127">If you've specified that it should not be released until a certain date, we'll wait until that date, unless you click the link to **Change release date**.</span></span> <span data-ttu-id="03aa1-128">申請を手動で公開するように指定していた場合、**[今すぐ公開]** ボタンをクリックするまで、アプリは公開されません。または、**[リリース日の変更]** リンクをクリックして特定の日付を選んだ場合、その日付までアプリは公開されません。</span><span class="sxs-lookup"><span data-stu-id="03aa1-128">If you've indicated that you want to publish the submission manually, then we won't publish it until you indicate that we should by clicking the button to **Publish now**, or if you click the link to **Change release date** and pick a specific date.</span></span>

## <a name="publishing"></a><span data-ttu-id="03aa1-129">公開</span><span class="sxs-lookup"><span data-stu-id="03aa1-129">Publishing</span></span>

<span data-ttu-id="03aa1-130">リリース後の改ざん防止のために、アプリのパッケージにはデジタル署名が施されます。</span><span class="sxs-lookup"><span data-stu-id="03aa1-130">Your app's packages are digitally signed to protect them against tampering after they have been released.</span></span> <span data-ttu-id="03aa1-131">このフェーズが始まると、申請をキャンセルしたり、リリース日を変更したりすることはできません。</span><span class="sxs-lookup"><span data-stu-id="03aa1-131">Once this phase has begun, you can no longer cancel your submission or change its release date.</span></span>

<span data-ttu-id="03aa1-132">アプリが公開フェーズになると、アプリの申請の [状態] 列で **[詳細の表示]** リンクをクリックして、新しいパッケージとストア登録情報の詳細が、サポートされている各 OS バージョンのユーザーに対して、いつ公開されるかを確認できます。</span><span class="sxs-lookup"><span data-stu-id="03aa1-132">While your app is in the publishing phase, the **Show details** link in the Status column for your app’s submission will let you know when your new packages and Store listing details become available to customers on each of your supported OS versions.</span></span> <span data-ttu-id="03aa1-133">アプリの潜在的なすべてのユーザーに新しいパッケージと登録情報の詳細が提供されるようになるまでには最大 24 時間かかる可能性があり、それまでアプリは公開フェーズのままです。</span><span class="sxs-lookup"><span data-stu-id="03aa1-133">Your app will remain in the publishing phase until the new packages and listing details are available to all of your app’s potential customers, which can take up to 24 hours.</span></span> 

## <a name="in-the-store"></a><span data-ttu-id="03aa1-134">ストア内</span><span class="sxs-lookup"><span data-stu-id="03aa1-134">In the Store</span></span> 

<span data-ttu-id="03aa1-135">上記の手順が正常に完了すると、申請の状態が **[公開中]** から **[ストア内]** に変わります。</span><span class="sxs-lookup"><span data-stu-id="03aa1-135">After successfully going through the steps above, the submission's status will change from **Publishing** to **In the Store**.</span></span> <span data-ttu-id="03aa1-136">その後、申請したアプリは Windows ストアでユーザーがダウンロードできるようになります (他の[表示](set-app-pricing-and-availability.md#visibility)オプションを選んでいる場合は除きます)。</span><span class="sxs-lookup"><span data-stu-id="03aa1-136">Your submission will then be available in the Windows Store for customers to download (unless you have chosen another [Visibility](set-app-pricing-and-availability.md#visibility) option).</span></span> 

<span data-ttu-id="03aa1-137">**注**  アプリの公開後にもスポット チェックが実施され、発生する可能性のある問題の検出や、アプリが [Windows ストア ポリシー](https://msdn.microsoft.com/library/windows/apps/dn764944)のすべてに準拠しているかどうかの確認が行われます。</span><span class="sxs-lookup"><span data-stu-id="03aa1-137">**Note**  We also conduct spot checks of apps after they've been published so we can identify potential problems and ensure that your app complies with all of the [Windows Store Policies](https://msdn.microsoft.com/library/windows/apps/dn764944).</span></span> <span data-ttu-id="03aa1-138">アプリに問題が見つかった場合は、問題とその修正方法が通知されます。または、ストアからのアプリの削除が妥当な場合は、削除されたことが通知されます。</span><span class="sxs-lookup"><span data-stu-id="03aa1-138">If we find any problems, you'll be notified about the issue and how to fix it, if applicable, or if it has been removed from the Store.</span></span>

 

 

 




