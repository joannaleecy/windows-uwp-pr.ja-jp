---
author: jnHs
Description: When you finish creating your app's submission and click Submit to the Store, the submission enters the certification step.
title: アプリの認定プロセス
ms.assetid: 0DCB4344-224D-4E5A-899F-FF7A89F23DBC
ms.author: wdg-dev-content
ms.date: 07/02/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: ウィンドウ 10、uwp を公開するには、前処理、認定、離すと、保留中、提出、発行、ステータス、時間
ms.localizationpriority: medium
ms.openlocfilehash: 8372f316786d83d72dff8ef7a0a8fd53e5390743
ms.sourcegitcommit: 3727445c1d6374401b867c78e4ff8b07d92b7adc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/29/2018
ms.locfileid: "2918863"
---
# <a name="the-app-certification-process"></a><span data-ttu-id="46703-103">アプリの認定プロセス</span><span class="sxs-lookup"><span data-stu-id="46703-103">The app certification process</span></span>

<span data-ttu-id="46703-104">アプリの申請の作成が完了し、**[Microsoft Store に提出]** をクリックすると、申請が認定手順に入ります。</span><span class="sxs-lookup"><span data-stu-id="46703-104">When you finish creating your app's submission and click **Submit to the Store**, the submission enters the certification step.</span></span> <span data-ttu-id="46703-105">このプロセスは通常、数時間以内に完了しますが、場合によっては最大で 3 営業日かかることがあります。</span><span class="sxs-lookup"><span data-stu-id="46703-105">This process usually is completed within a few hours, though in some cases it may take up to three business days.</span></span> <span data-ttu-id="46703-106">提出書類は、認定に合格後、は、新しい提出書類、またはパッケージに変更と更新の送信のためのアプリケーションの一覧を表示するには、最大で 24 時間がかかることができます。</span><span class="sxs-lookup"><span data-stu-id="46703-106">After your submission passes certification, it can take up to 24 hours for customers to see the app’s listing for a new submission, or for an updated submission with changes to packages.</span></span> <span data-ttu-id="46703-107">更新内容は、ストアの一覧の詳細のみを変更する場合は、1 時間以内に発行のプロセスが完了します。</span><span class="sxs-lookup"><span data-stu-id="46703-107">If your update only changes Store listing details, the publishing process will be completed in less than an hour.</span></span>  <span data-ttu-id="46703-108">提出書類を発行するととダッシュ ボードでアプリケーションの状態になります**がストア**、に通知されます。</span><span class="sxs-lookup"><span data-stu-id="46703-108">You'll be notified when your submission is published, and the app's status in the dashboard will be **In the Store**.</span></span>

## <a name="preprocessing"></a><span data-ttu-id="46703-109">前処理</span><span class="sxs-lookup"><span data-stu-id="46703-109">Preprocessing</span></span>

<span data-ttu-id="46703-110">アプリのパッケージを正常にアップロードし、認定のためにアプリを提出すると、パッケージはテストを受けるためのキューに登録されます。</span><span class="sxs-lookup"><span data-stu-id="46703-110">After you successfully upload the app's packages and submit the app for certification, the packages are queued for testing.</span></span> <span data-ttu-id="46703-111">前処理中にエラーを検出した場合は、メッセージを表示します。</span><span class="sxs-lookup"><span data-stu-id="46703-111">We'll display a message if we detect any errors during preprocessing.</span></span> <span data-ttu-id="46703-112">可能性のあるエラーについて詳しくは、「[申請エラーの解決](resolve-submission-errors.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="46703-112">For more info on possible errors, see [Resolve submission errors](resolve-submission-errors.md).</span></span>

## <a name="certification"></a><span data-ttu-id="46703-113">認定</span><span class="sxs-lookup"><span data-stu-id="46703-113">Certification</span></span>

<span data-ttu-id="46703-114">このフェーズでは、いくつかのテストが行われます。</span><span class="sxs-lookup"><span data-stu-id="46703-114">During this phase, several tests are conducted:</span></span>

-   <span data-ttu-id="46703-115">**セキュリティ テスト:** 最初のテストでは、アプリのパッケージがチェックされ、ウイルスやマルウェアに感染していないか確認が行われます。</span><span class="sxs-lookup"><span data-stu-id="46703-115">**Security tests:** This first test checks your app's packages for viruses and malware.</span></span> <span data-ttu-id="46703-116">このテストで不合格になった場合は、最新のウイルス対策ソフトウェアを実行して開発システムをチェックしてから、クリーンなシステム上でアプリのパッケージをリビルドする必要があります。</span><span class="sxs-lookup"><span data-stu-id="46703-116">If your app fails this test, you'll need to check your development system by running the latest antivirus software, then rebuild your app's package on a clean system.</span></span>
-   <span data-ttu-id="46703-117">**技術的な適合性のテスト:** 技術的な適合性のテストは、Windows アプリ認定キットを使って行われます。</span><span class="sxs-lookup"><span data-stu-id="46703-117">**Technical compliance tests:** Technical compliance is tested by the Windows App Certification Kit.</span></span> <span data-ttu-id="46703-118">(開発者は、ストアに提出する前に必ず [Windows アプリ認定キットでアプリのテスト](../debug-test-perf/windows-app-certification-kit.md)を実施する必要があります)。</span><span class="sxs-lookup"><span data-stu-id="46703-118">(You should always make sure to [test your app with the Windows App Certification Kit](../debug-test-perf/windows-app-certification-kit.md) before you submit it to the Store.)</span></span>
-   <span data-ttu-id="46703-119">**コンテンツの適合性:** このテストにかかる時間は、アプリの複雑さ、視覚的なコンテンツの量、同時期に提出されたアプリの数などによって異なります。</span><span class="sxs-lookup"><span data-stu-id="46703-119">**Content compliance:** The amount of time this takes varies depending on how complex your app is, how much visual content it has, and how many apps have been submitted recently.</span></span> <span data-ttu-id="46703-120">認定を求めるにあたって伝えておく必要のある情報があれば、[[Notes for certification]](notes-for-certification.md) (認定を求めるにあたってのコメント) ページに記入してください。</span><span class="sxs-lookup"><span data-stu-id="46703-120">Be sure to provide any info that testers should be aware of in the [Notes for certification](notes-for-certification.md) page.</span></span>

<span data-ttu-id="46703-121">認定プロセスが完了した後、アプリが認定に合格したかどうかを示す認定レポートをお届けします。</span><span class="sxs-lookup"><span data-stu-id="46703-121">After the certification process is complete, you'll get a certification report telling you whether or not your app passed certification.</span></span> <span data-ttu-id="46703-122">アプリが認定されなかった場合、レポートには、どのテストに不合格になり、どの[ポリシー](https://docs.microsoft.com/legal/windows/agreements/store-policies)を満たしていなかったかが示されます。</span><span class="sxs-lookup"><span data-stu-id="46703-122">If it didn't pass, the report will indicate which test failed or which [policy](https://docs.microsoft.com/legal/windows/agreements/store-policies) was not met.</span></span> <span data-ttu-id="46703-123">問題の修正後、アプリの新しい申請を作成して、認定プロセスを再び始めることができます。</span><span class="sxs-lookup"><span data-stu-id="46703-123">After you fix the problem, you can create a new submission for your app to start the certification process again.</span></span>

## <a name="release"></a><span data-ttu-id="46703-124">リリース</span><span class="sxs-lookup"><span data-stu-id="46703-124">Release</span></span>

<span data-ttu-id="46703-125">アプリが認定に合格するとは、**発行**プロセスに移動する準備ができました。</span><span class="sxs-lookup"><span data-stu-id="46703-125">When your app passes certification, it's ready to move to the **Publishing** process.</span></span>

- <span data-ttu-id="46703-126">送信する必要があります (既定のオプション) をできる限り早く公開することを指定した場合は、すぐ公開プロセスが開始されます。</span><span class="sxs-lookup"><span data-stu-id="46703-126">If you've indicated that your submission should be published as soon as possible (the default option), the publishing process will begin right away.</span></span>
- <span data-ttu-id="46703-127">これが初めてである場合、アプリケーションを公開したと**リリース日**を[スケジュール](configure-precise-release-scheduling.md#release)] セクションで指定した、アプリケーションは、**リリース日**の選択内容に応じて利用可能になります。</span><span class="sxs-lookup"><span data-stu-id="46703-127">If this is the first time you've published the app, and you specified a **Release date** in the [Schedule](configure-precise-release-scheduling.md#release) section, the app will become available according to your **Release date** selections.</span></span>
- <span data-ttu-id="46703-128">[発行オプションを保持する](manage-submission-options.md#publishing-hold-options)ことに解放しないで特定の日付までを指定に使用した場合は、**リリース日の変更**を選択する場合を除き、発行プロセスを開始するには、その日付まで待っていますよ。</span><span class="sxs-lookup"><span data-stu-id="46703-128">If you've used [Publishing hold options](manage-submission-options.md#publishing-hold-options) to specify that it should not be released until a certain date, we'll wait until that date to begin the publishing process, unless you select **Change release date**.</span></span>
- <span data-ttu-id="46703-129">使用した[公開オプションを保持する](manage-submission-options.md#publishing-hold-options)提出書類を手動で発行することを指定するのには、**今すぐ発行**] を選択または**変更のリリース日**を選択して特定の日付を選択) するまでに発行のプロセスが起動はしません。</span><span class="sxs-lookup"><span data-stu-id="46703-129">If you've used [Publishing hold options](manage-submission-options.md#publishing-hold-options) to specify that you want to publish the submission manually, we won't start the publishing process until you select **Publish now** (or select **Change release date** and pick a specific date).</span></span>


## <a name="publishing"></a><span data-ttu-id="46703-130">公開</span><span class="sxs-lookup"><span data-stu-id="46703-130">Publishing</span></span>

<span data-ttu-id="46703-131">リリース後の改ざん防止のために、アプリのパッケージにはデジタル署名が施されます。</span><span class="sxs-lookup"><span data-stu-id="46703-131">Your app's packages are digitally signed to protect them against tampering after they have been released.</span></span> <span data-ttu-id="46703-132">このフェーズが始まると、申請をキャンセルしたり、リリース日を変更したりすることはできません。</span><span class="sxs-lookup"><span data-stu-id="46703-132">Once this phase has begun, you can no longer cancel your submission or change its release date.</span></span>

<span data-ttu-id="46703-133">新しいアプリケーションとアプリケーションのパッケージに加えた変更を含む更新プログラムでは、発行プロセスは 24 時間以内で完了されます。</span><span class="sxs-lookup"><span data-stu-id="46703-133">For new apps and updates which include changes to the app's packages, the publishing process will be completed within 24 hours.</span></span> <span data-ttu-id="46703-134">更新プログラムのみストアの詳細については、一覧の表示などのオプションを変更するが、アプリケーションのパッケージを変更しないで、公開プロセスを 1 時間未満となります。</span><span class="sxs-lookup"><span data-stu-id="46703-134">For updates that only change options such as Store listing details, but don't change the app's packages, the publishing process will take less than one hour.</span></span>

<span data-ttu-id="46703-135">アプリは、公開の段階では、アプリの提出書類の [状態] 列の**詳細を表示する**リンクでは、ストアの詳細を一覧表示、新しいパッケージが使える場合に、サポートされている OS のバージョンごとにお客様に確認することができます。</span><span class="sxs-lookup"><span data-stu-id="46703-135">While your app is in the publishing phase, the **Show details** link in the Status column for your app’s submission lets you know when your new packages and Store listing details are available to customers on each of your supported OS versions.</span></span> <span data-ttu-id="46703-136">まだ完了していない手順は **"保留中"** と表示されます。</span><span class="sxs-lookup"><span data-stu-id="46703-136">Steps that have not yet completed will show **Pending**.</span></span> <span data-ttu-id="46703-137">アプリのプロセスが完了するまでは、発行の段階では、新しいパッケージを意味するか、一覧の詳細は、アプリケーションの潜在的な顧客のすべてに使用可能です。</span><span class="sxs-lookup"><span data-stu-id="46703-137">Your app will remain in the publishing phase until the process has completed, meaning that the new packages and/or listing details are available to all of your app’s potential customers.</span></span>

## <a name="in-the-store"></a><span data-ttu-id="46703-138">ストア内</span><span class="sxs-lookup"><span data-stu-id="46703-138">In the Store</span></span> 

<span data-ttu-id="46703-139">上記の手順が正常に完了すると、申請の状態が **[公開中]** から **[Microsoft Store 内]** に変わります。</span><span class="sxs-lookup"><span data-stu-id="46703-139">After successfully going through the steps above, the submission's status will change from **Publishing** to **In the Store**.</span></span> <span data-ttu-id="46703-140">その後、申請したアプリは Microsoft Store でユーザーがダウンロードできるようになります (他の[見つけやすさ](choose-visibility-options.md#discoverability)オプションを選んでいる場合は除きます)。</span><span class="sxs-lookup"><span data-stu-id="46703-140">Your submission will then be available in the Microsoft Store for customers to download (unless you have chosen another [Discoverability](choose-visibility-options.md#discoverability) option).</span></span> 

> [!NOTE]
> <span data-ttu-id="46703-141">アプリの公開後にもスポット チェックが実施され、発生する可能性のある問題の検出や、アプリが [Microsoft Store ポリシー](https://docs.microsoft.com/legal/windows/agreements/store-policies)のすべてに準拠しているかどうかの確認が行われます。</span><span class="sxs-lookup"><span data-stu-id="46703-141">We also conduct spot checks of apps after they've been published so we can identify potential problems and ensure that your app complies with all of the [Microsoft Store Policies](https://docs.microsoft.com/legal/windows/agreements/store-policies).</span></span> <span data-ttu-id="46703-142">アプリに問題が見つかった場合は、問題とその修正方法が通知されます。または、ストアからのアプリの削除が妥当な場合は、削除されたことが通知されます。</span><span class="sxs-lookup"><span data-stu-id="46703-142">If we find any problems, you'll be notified about the issue and how to fix it, if applicable, or if it has been removed from the Store.</span></span>

 

 

 




