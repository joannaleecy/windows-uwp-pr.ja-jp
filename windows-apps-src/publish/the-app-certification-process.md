---
Description: アプリの提出の作成を完了、ストアに送信 をクリックすると、送信は、認定手順になります。
title: アプリの認定プロセス
ms.assetid: 0DCB4344-224D-4E5A-899F-FF7A89F23DBC
ms.date: 10/31/2018
ms.topic: article
keywords: windows 10、uwp、発行、前処理、認定資格、リリース、保留中、送信、発行、ステータス、時間
ms.localizationpriority: medium
ms.openlocfilehash: fe9df9ce95c6b17bcd3d702bf09ac57b9f205e0c
ms.sourcegitcommit: fca0132794ec187e90b2ebdad862f22d9f6c0db8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/24/2019
ms.locfileid: "63790591"
---
# <a name="the-app-certification-process"></a><span data-ttu-id="8b8de-104">アプリの認定プロセス</span><span class="sxs-lookup"><span data-stu-id="8b8de-104">The app certification process</span></span>

<span data-ttu-id="8b8de-105">アプリの申請の作成が完了し、**[Microsoft Store に提出]** をクリックすると、申請が認定手順に入ります。</span><span class="sxs-lookup"><span data-stu-id="8b8de-105">When you finish creating your app's submission and click **Submit to the Store**, the submission enters the certification step.</span></span> <span data-ttu-id="8b8de-106">このプロセスは通常、数時間以内に完了しますが、場合によっては最大で 3 営業日かかることがあります。</span><span class="sxs-lookup"><span data-stu-id="8b8de-106">This process usually is completed within a few hours, though in some cases it may take up to three business days.</span></span> <span data-ttu-id="8b8de-107">お客様の提出証明に合格した後は、顧客の新しい送信、またはパッケージに更新を送信する変更で、アプリの一覧を表示するには、最大で 24 時間かかります。</span><span class="sxs-lookup"><span data-stu-id="8b8de-107">After your submission passes certification, it can take up to 24 hours for customers to see the app’s listing for a new submission, or for an updated submission with changes to packages.</span></span> <span data-ttu-id="8b8de-108">更新は、ストアの一覧の詳細のみを変更する場合、発行プロセスは 1 時間未満で完了できません。</span><span class="sxs-lookup"><span data-stu-id="8b8de-108">If your update only changes Store listing details, the publishing process will be completed in less than an hour.</span></span>  <span data-ttu-id="8b8de-109">お客様の提出が発行され、ダッシュ ボードで、アプリの状態になるときに通知します**ストアに**します。</span><span class="sxs-lookup"><span data-stu-id="8b8de-109">You'll be notified when your submission is published, and the app's status in the dashboard will be **In the Store**.</span></span>

## <a name="preprocessing"></a><span data-ttu-id="8b8de-110">前処理</span><span class="sxs-lookup"><span data-stu-id="8b8de-110">Preprocessing</span></span>

<span data-ttu-id="8b8de-111">アプリのパッケージを正常にアップロードし、認定のためにアプリを提出すると、パッケージはテストを受けるためのキューに登録されます。</span><span class="sxs-lookup"><span data-stu-id="8b8de-111">After you successfully upload the app's packages and submit the app for certification, the packages are queued for testing.</span></span> <span data-ttu-id="8b8de-112">前処理中にエラーを検出した場合は、メッセージを表示します。</span><span class="sxs-lookup"><span data-stu-id="8b8de-112">We'll display a message if we detect any errors during preprocessing.</span></span> <span data-ttu-id="8b8de-113">可能性のあるエラーについて詳しくは、「[申請エラーの解決](resolve-submission-errors.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8b8de-113">For more info on possible errors, see [Resolve submission errors](resolve-submission-errors.md).</span></span>

## <a name="certification"></a><span data-ttu-id="8b8de-114">認定</span><span class="sxs-lookup"><span data-stu-id="8b8de-114">Certification</span></span>

<span data-ttu-id="8b8de-115">このフェーズでは、いくつかのテストが行われます。</span><span class="sxs-lookup"><span data-stu-id="8b8de-115">During this phase, several tests are conducted:</span></span>

-   <span data-ttu-id="8b8de-116">**セキュリティをテストします。** この最初のテストでは、ウイルスとマルウェア、アプリのパッケージを確認します。</span><span class="sxs-lookup"><span data-stu-id="8b8de-116">**Security tests:** This first test checks your app's packages for viruses and malware.</span></span> <span data-ttu-id="8b8de-117">このテストで不合格になった場合は、最新のウイルス対策ソフトウェアを実行して開発システムをチェックしてから、クリーンなシステム上でアプリのパッケージをリビルドする必要があります。</span><span class="sxs-lookup"><span data-stu-id="8b8de-117">If your app fails this test, you'll need to check your development system by running the latest antivirus software, then rebuild your app's package on a clean system.</span></span>
-   <span data-ttu-id="8b8de-118">**技術的なコンプライアンス対応をテストします。** Windows アプリ認定キットを使用すると、技術的なコンプライアンス対応をテストします。</span><span class="sxs-lookup"><span data-stu-id="8b8de-118">**Technical compliance tests:** Technical compliance is tested by the Windows App Certification Kit.</span></span> <span data-ttu-id="8b8de-119">(開発者は、ストアに提出する前に必ず [Windows アプリ認定キットでアプリのテスト](../debug-test-perf/windows-app-certification-kit.md)を実施する必要があります)。</span><span class="sxs-lookup"><span data-stu-id="8b8de-119">(You should always make sure to [test your app with the Windows App Certification Kit](../debug-test-perf/windows-app-certification-kit.md) before you submit it to the Store.)</span></span>
-   <span data-ttu-id="8b8de-120">**コンテンツ コンプライアンス:** これにかかる時間の量は、複雑なアプリは、ビジュアル コンテンツの量、および最近送信されたアプリの数によって異なります。</span><span class="sxs-lookup"><span data-stu-id="8b8de-120">**Content compliance:** The amount of time this takes varies depending on how complex your app is, how much visual content it has, and how many apps have been submitted recently.</span></span> <span data-ttu-id="8b8de-121">認定を求めるにあたって伝えておく必要のある情報があれば、[[Notes for certification]](notes-for-certification.md) (認定を求めるにあたってのコメント) ページに記入してください。</span><span class="sxs-lookup"><span data-stu-id="8b8de-121">Be sure to provide any info that testers should be aware of in the [Notes for certification](notes-for-certification.md) page.</span></span>

<span data-ttu-id="8b8de-122">認定プロセスが完了した後、アプリが認定に合格したかどうかを示す認定レポートをお届けします。</span><span class="sxs-lookup"><span data-stu-id="8b8de-122">After the certification process is complete, you'll get a certification report telling you whether or not your app passed certification.</span></span> <span data-ttu-id="8b8de-123">アプリが認定されなかった場合、レポートには、どのテストに不合格になり、どの[ポリシー](https://docs.microsoft.com/legal/windows/agreements/store-policies)を満たしていなかったかが示されます。</span><span class="sxs-lookup"><span data-stu-id="8b8de-123">If it didn't pass, the report will indicate which test failed or which [policy](https://docs.microsoft.com/legal/windows/agreements/store-policies) was not met.</span></span> <span data-ttu-id="8b8de-124">問題の修正後、アプリの新しい申請を作成して、認定プロセスを再び始めることができます。</span><span class="sxs-lookup"><span data-stu-id="8b8de-124">After you fix the problem, you can create a new submission for your app to start the certification process again.</span></span>

## <a name="release"></a><span data-ttu-id="8b8de-125">リリース</span><span class="sxs-lookup"><span data-stu-id="8b8de-125">Release</span></span>

<span data-ttu-id="8b8de-126">アプリが認定を渡す場合に移動する準備ができて、**発行**プロセス。</span><span class="sxs-lookup"><span data-stu-id="8b8de-126">When your app passes certification, it's ready to move to the **Publishing** process.</span></span>

- <span data-ttu-id="8b8de-127">提出する必要があります (既定のオプション) をできる限り早く公開することを指定した場合は、発行プロセスがすぐに開始されます。</span><span class="sxs-lookup"><span data-stu-id="8b8de-127">If you've indicated that your submission should be published as soon as possible (the default option), the publishing process will begin right away.</span></span>
- <span data-ttu-id="8b8de-128">これが初めてである場合、アプリを発行して、指定した、**リリース日**で、[スケジュール](configure-precise-release-scheduling.md#release) セクションで、アプリが使用可能になるに従い、**リリース日**選択します。</span><span class="sxs-lookup"><span data-stu-id="8b8de-128">If this is the first time you've published the app, and you specified a **Release date** in the [Schedule](configure-precise-release-scheduling.md#release) section, the app will become available according to your **Release date** selections.</span></span>
- <span data-ttu-id="8b8de-129">使用した場合[パブリッシング オプションを保持する](manage-submission-options.md#publishing-hold-options)にする必要がありますいないでリリースする特定の日付までを指定するには、お待ちしています、発行プロセスを開始するには、その日まで選択しない限り**変更リリース日**します。</span><span class="sxs-lookup"><span data-stu-id="8b8de-129">If you've used [Publishing hold options](manage-submission-options.md#publishing-hold-options) to specify that it should not be released until a certain date, we'll wait until that date to begin the publishing process, unless you select **Change release date**.</span></span>
- <span data-ttu-id="8b8de-130">使用した場合[パブリッシング オプションを保持する](manage-submission-options.md#publishing-hold-options)提出パッケージを手動で発行することを指定するには開始されません、発行プロセスを選択するまで**を今すぐ発行**(または選択**変更リリース日**し、特定の日付を選択)。</span><span class="sxs-lookup"><span data-stu-id="8b8de-130">If you've used [Publishing hold options](manage-submission-options.md#publishing-hold-options) to specify that you want to publish the submission manually, we won't start the publishing process until you select **Publish now** (or select **Change release date** and pick a specific date).</span></span>


## <a name="publishing"></a><span data-ttu-id="8b8de-131">公開</span><span class="sxs-lookup"><span data-stu-id="8b8de-131">Publishing</span></span>

<span data-ttu-id="8b8de-132">リリース後の改ざん防止のために、アプリのパッケージにはデジタル署名が施されます。</span><span class="sxs-lookup"><span data-stu-id="8b8de-132">Your app's packages are digitally signed to protect them against tampering after they have been released.</span></span> <span data-ttu-id="8b8de-133">このフェーズが始まると、申請をキャンセルしたり、リリース日を変更したりすることはできません。</span><span class="sxs-lookup"><span data-stu-id="8b8de-133">Once this phase has begun, you can no longer cancel your submission or change its release date.</span></span>

<span data-ttu-id="8b8de-134">新しいアプリとアプリのパッケージへの変更を含む更新プログラムは、発行プロセスは 24 時間以内に完了できません。</span><span class="sxs-lookup"><span data-stu-id="8b8de-134">For new apps and updates which include changes to the app's packages, the publishing process will be completed within 24 hours.</span></span> <span data-ttu-id="8b8de-135">一覧の詳細、ストアなどのオプションを変更するが、アプリのパッケージは変更しないでくださいのみが更新では、発行プロセスを 1 時間未満となります。</span><span class="sxs-lookup"><span data-stu-id="8b8de-135">For updates that only change options such as Store listing details, but don't change the app's packages, the publishing process will take less than one hour.</span></span>

<span data-ttu-id="8b8de-136">アプリが発行のフェーズの間、**の詳細を表示**新しいパッケージとストアの一覧の詳細が、サポートされている OS の各ユーザーに提供することができます、アプリの送信の状態 列のリンクバージョン。</span><span class="sxs-lookup"><span data-stu-id="8b8de-136">While your app is in the publishing phase, the **Show details** link in the Status column for your app’s submission lets you know when your new packages and Store listing details are available to customers on each of your supported OS versions.</span></span> <span data-ttu-id="8b8de-137">まだ完了していない手順は **"保留中"** と表示されます。</span><span class="sxs-lookup"><span data-stu-id="8b8de-137">Steps that have not yet completed will show **Pending**.</span></span> <span data-ttu-id="8b8de-138">発行の段階のプロセスが完了するまでに、アプリが残ります、つまり、新しいパッケージや一覧の詳細は、アプリの潜在顧客のすべて利用できます。</span><span class="sxs-lookup"><span data-stu-id="8b8de-138">Your app will remain in the publishing phase until the process has completed, meaning that the new packages and/or listing details are available to all of your app’s potential customers.</span></span>

## <a name="in-the-store"></a><span data-ttu-id="8b8de-139">Microsoft Store 内</span><span class="sxs-lookup"><span data-stu-id="8b8de-139">In the Store</span></span> 

<span data-ttu-id="8b8de-140">上記の手順が正常に完了すると、申請の状態が **[公開中]** から **[Microsoft Store 内]** に変わります。</span><span class="sxs-lookup"><span data-stu-id="8b8de-140">After successfully going through the steps above, the submission's status will change from **Publishing** to **In the Store**.</span></span> <span data-ttu-id="8b8de-141">その後、申請したアプリは Microsoft Store でユーザーがダウンロードできるようになります (他の[見つけやすさ](choose-visibility-options.md#discoverability)オプションを選んでいる場合は除きます)。</span><span class="sxs-lookup"><span data-stu-id="8b8de-141">Your submission will then be available in the Microsoft Store for customers to download (unless you have chosen another [Discoverability](choose-visibility-options.md#discoverability) option).</span></span> 

> [!NOTE]
> <span data-ttu-id="8b8de-142">アプリの公開後にもスポット チェックが実施され、発生する可能性のある問題の検出や、アプリが [Microsoft Store ポリシー](https://docs.microsoft.com/legal/windows/agreements/store-policies)のすべてに準拠しているかどうかの確認が行われます。</span><span class="sxs-lookup"><span data-stu-id="8b8de-142">We also conduct spot checks of apps after they've been published so we can identify potential problems and ensure that your app complies with all of the [Microsoft Store Policies](https://docs.microsoft.com/legal/windows/agreements/store-policies).</span></span> <span data-ttu-id="8b8de-143">アプリに問題が見つかった場合は、問題とその修正方法が通知されます。または、ストアからのアプリの削除が妥当な場合は、削除されたことが通知されます。</span><span class="sxs-lookup"><span data-stu-id="8b8de-143">If we find any problems, you'll be notified about the issue and how to fix it, if applicable, or if it has been removed from the Store.</span></span>

 

 

 




