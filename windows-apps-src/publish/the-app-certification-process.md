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
keywords: windows 10、uwp、発行、前処理、証明書を離すと、保留中、送信、公開、状態、時間
ms.localizationpriority: medium
ms.openlocfilehash: 8372f316786d83d72dff8ef7a0a8fd53e5390743
ms.sourcegitcommit: 9a17266f208ec415fc718e5254d5b4c08835150c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/28/2018
ms.locfileid: "2882740"
---
# <a name="the-app-certification-process"></a><span data-ttu-id="75e3f-103">アプリの認定プロセス</span><span class="sxs-lookup"><span data-stu-id="75e3f-103">The app certification process</span></span>

<span data-ttu-id="75e3f-104">アプリの申請の作成が完了し、**[Microsoft Store に提出]** をクリックすると、申請が認定手順に入ります。</span><span class="sxs-lookup"><span data-stu-id="75e3f-104">When you finish creating your app's submission and click **Submit to the Store**, the submission enters the certification step.</span></span> <span data-ttu-id="75e3f-105">このプロセスは通常、数時間以内に完了しますが、場合によっては最大で 3 営業日かかることがあります。</span><span class="sxs-lookup"><span data-stu-id="75e3f-105">This process usually is completed within a few hours, though in some cases it may take up to three business days.</span></span> <span data-ttu-id="75e3f-106">送信物に渡します証明後、新しい送信またはパッケージ用に変更と更新を提出する、アプリの一覧を表示する顧客のまで 24 時間かかる場合ことができます。</span><span class="sxs-lookup"><span data-stu-id="75e3f-106">After your submission passes certification, it can take up to 24 hours for customers to see the app’s listing for a new submission, or for an updated submission with changes to packages.</span></span> <span data-ttu-id="75e3f-107">更新プログラムのみストアの一覧の詳細を変更する場合は、1 時間以内に発行のプロセスが完了します。</span><span class="sxs-lookup"><span data-stu-id="75e3f-107">If your update only changes Store listing details, the publishing process will be completed in less than an hour.</span></span>  <span data-ttu-id="75e3f-108">されたときに送信物を公開すると、ダッシュ ボードで、アプリの状態が **[ストアで**通知されます。</span><span class="sxs-lookup"><span data-stu-id="75e3f-108">You'll be notified when your submission is published, and the app's status in the dashboard will be **In the Store**.</span></span>

## <a name="preprocessing"></a><span data-ttu-id="75e3f-109">前処理</span><span class="sxs-lookup"><span data-stu-id="75e3f-109">Preprocessing</span></span>

<span data-ttu-id="75e3f-110">アプリのパッケージを正常にアップロードし、認定のためにアプリを提出すると、パッケージはテストを受けるためのキューに登録されます。</span><span class="sxs-lookup"><span data-stu-id="75e3f-110">After you successfully upload the app's packages and submit the app for certification, the packages are queued for testing.</span></span> <span data-ttu-id="75e3f-111">前処理中にエラーを検出した場合は、メッセージを表示します。</span><span class="sxs-lookup"><span data-stu-id="75e3f-111">We'll display a message if we detect any errors during preprocessing.</span></span> <span data-ttu-id="75e3f-112">可能性のあるエラーについて詳しくは、「[申請エラーの解決](resolve-submission-errors.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="75e3f-112">For more info on possible errors, see [Resolve submission errors](resolve-submission-errors.md).</span></span>

## <a name="certification"></a><span data-ttu-id="75e3f-113">認定</span><span class="sxs-lookup"><span data-stu-id="75e3f-113">Certification</span></span>

<span data-ttu-id="75e3f-114">このフェーズでは、いくつかのテストが行われます。</span><span class="sxs-lookup"><span data-stu-id="75e3f-114">During this phase, several tests are conducted:</span></span>

-   <span data-ttu-id="75e3f-115">**セキュリティ テスト:** 最初のテストでは、アプリのパッケージがチェックされ、ウイルスやマルウェアに感染していないか確認が行われます。</span><span class="sxs-lookup"><span data-stu-id="75e3f-115">**Security tests:** This first test checks your app's packages for viruses and malware.</span></span> <span data-ttu-id="75e3f-116">このテストで不合格になった場合は、最新のウイルス対策ソフトウェアを実行して開発システムをチェックしてから、クリーンなシステム上でアプリのパッケージをリビルドする必要があります。</span><span class="sxs-lookup"><span data-stu-id="75e3f-116">If your app fails this test, you'll need to check your development system by running the latest antivirus software, then rebuild your app's package on a clean system.</span></span>
-   <span data-ttu-id="75e3f-117">**技術的な適合性のテスト:** 技術的な適合性のテストは、Windows アプリ認定キットを使って行われます。</span><span class="sxs-lookup"><span data-stu-id="75e3f-117">**Technical compliance tests:** Technical compliance is tested by the Windows App Certification Kit.</span></span> <span data-ttu-id="75e3f-118">(開発者は、ストアに提出する前に必ず [Windows アプリ認定キットでアプリのテスト](../debug-test-perf/windows-app-certification-kit.md)を実施する必要があります)。</span><span class="sxs-lookup"><span data-stu-id="75e3f-118">(You should always make sure to [test your app with the Windows App Certification Kit](../debug-test-perf/windows-app-certification-kit.md) before you submit it to the Store.)</span></span>
-   <span data-ttu-id="75e3f-119">**コンテンツの適合性:** このテストにかかる時間は、アプリの複雑さ、視覚的なコンテンツの量、同時期に提出されたアプリの数などによって異なります。</span><span class="sxs-lookup"><span data-stu-id="75e3f-119">**Content compliance:** The amount of time this takes varies depending on how complex your app is, how much visual content it has, and how many apps have been submitted recently.</span></span> <span data-ttu-id="75e3f-120">認定を求めるにあたって伝えておく必要のある情報があれば、[[Notes for certification]](notes-for-certification.md) (認定を求めるにあたってのコメント) ページに記入してください。</span><span class="sxs-lookup"><span data-stu-id="75e3f-120">Be sure to provide any info that testers should be aware of in the [Notes for certification](notes-for-certification.md) page.</span></span>

<span data-ttu-id="75e3f-121">認定プロセスが完了した後、アプリが認定に合格したかどうかを示す認定レポートをお届けします。</span><span class="sxs-lookup"><span data-stu-id="75e3f-121">After the certification process is complete, you'll get a certification report telling you whether or not your app passed certification.</span></span> <span data-ttu-id="75e3f-122">アプリが認定されなかった場合、レポートには、どのテストに不合格になり、どの[ポリシー](https://docs.microsoft.com/legal/windows/agreements/store-policies)を満たしていなかったかが示されます。</span><span class="sxs-lookup"><span data-stu-id="75e3f-122">If it didn't pass, the report will indicate which test failed or which [policy](https://docs.microsoft.com/legal/windows/agreements/store-policies) was not met.</span></span> <span data-ttu-id="75e3f-123">問題の修正後、アプリの新しい申請を作成して、認定プロセスを再び始めることができます。</span><span class="sxs-lookup"><span data-stu-id="75e3f-123">After you fix the problem, you can create a new submission for your app to start the certification process again.</span></span>

## <a name="release"></a><span data-ttu-id="75e3f-124">リリース</span><span class="sxs-lookup"><span data-stu-id="75e3f-124">Release</span></span>

<span data-ttu-id="75e3f-125">アプリでは、証明書を渡す、準備ができました**発行**プロセスに移動します。</span><span class="sxs-lookup"><span data-stu-id="75e3f-125">When your app passes certification, it's ready to move to the **Publishing** process.</span></span>

- <span data-ttu-id="75e3f-126">送信物をできるだけ早く (既定のオプション) 公開する必要があることを指定した場合は、今すぐ発行プロセスが開始されます。</span><span class="sxs-lookup"><span data-stu-id="75e3f-126">If you've indicated that your submission should be published as soon as possible (the default option), the publishing process will begin right away.</span></span>
- <span data-ttu-id="75e3f-127">初めての場合、アプリを発行したと**リリース日**を指定した[スケジュール](configure-precise-release-scheduling.md#release)] セクションでは、アプリは、**リリース日**の選択内容に応じて利用可能になります。</span><span class="sxs-lookup"><span data-stu-id="75e3f-127">If this is the first time you've published the app, and you specified a **Release date** in the [Schedule](configure-precise-release-scheduling.md#release) section, the app will become available according to your **Release date** selections.</span></span>
- <span data-ttu-id="75e3f-128">[発行オプションを保持する](manage-submission-options.md#publishing-hold-options)ことは解放しないで特定の日付までを指定するに使用した場合は、**リリース日を変更する**選択しない限り、発行プロセスを開始するには、その日付まで待機おされます。</span><span class="sxs-lookup"><span data-stu-id="75e3f-128">If you've used [Publishing hold options](manage-submission-options.md#publishing-hold-options) to specify that it should not be released until a certain date, we'll wait until that date to begin the publishing process, unless you select **Change release date**.</span></span>
- <span data-ttu-id="75e3f-129">[発行オプションを押したまま](manage-submission-options.md#publishing-hold-options)送信を手動で公開することを指定するに使用した場合が選択されるまで **[今すぐ発行**] を選びます (または**リリース日を変更する**特定の日付を選びます)、発行プロセスを起動してしません。</span><span class="sxs-lookup"><span data-stu-id="75e3f-129">If you've used [Publishing hold options](manage-submission-options.md#publishing-hold-options) to specify that you want to publish the submission manually, we won't start the publishing process until you select **Publish now** (or select **Change release date** and pick a specific date).</span></span>


## <a name="publishing"></a><span data-ttu-id="75e3f-130">公開</span><span class="sxs-lookup"><span data-stu-id="75e3f-130">Publishing</span></span>

<span data-ttu-id="75e3f-131">リリース後の改ざん防止のために、アプリのパッケージにはデジタル署名が施されます。</span><span class="sxs-lookup"><span data-stu-id="75e3f-131">Your app's packages are digitally signed to protect them against tampering after they have been released.</span></span> <span data-ttu-id="75e3f-132">このフェーズが始まると、申請をキャンセルしたり、リリース日を変更したりすることはできません。</span><span class="sxs-lookup"><span data-stu-id="75e3f-132">Once this phase has begun, you can no longer cancel your submission or change its release date.</span></span>

<span data-ttu-id="75e3f-133">新しいアプリとは、アプリのパッケージに加えた変更は、24 時間以内発行のプロセスが完了します。</span><span class="sxs-lookup"><span data-stu-id="75e3f-133">For new apps and updates which include changes to the app's packages, the publishing process will be completed within 24 hours.</span></span> <span data-ttu-id="75e3f-134">更新プログラムをストアの詳細については、対象の連絡先リストなどのオプションを変更するだけで、アプリのパッケージを変更しないが、発行プロセスに 1 未満の時間がかかります。</span><span class="sxs-lookup"><span data-stu-id="75e3f-134">For updates that only change options such as Store listing details, but don't change the app's packages, the publishing process will take less than one hour.</span></span>

<span data-ttu-id="75e3f-135">アプリは、発行フェーズでは、アプリの送信の状態] 列に**詳細を表示する**リンクされてストアの詳細を一覧表示、新しいパッケージのでは、サポートされている OS のバージョンの各ユーザーに提供を確認できます。</span><span class="sxs-lookup"><span data-stu-id="75e3f-135">While your app is in the publishing phase, the **Show details** link in the Status column for your app’s submission lets you know when your new packages and Store listing details are available to customers on each of your supported OS versions.</span></span> <span data-ttu-id="75e3f-136">まだ完了していない手順は **"保留中"** と表示されます。</span><span class="sxs-lookup"><span data-stu-id="75e3f-136">Steps that have not yet completed will show **Pending**.</span></span> <span data-ttu-id="75e3f-137">アプリは、発行フェーズ、プロセスが完了するまでのまま、新しいパッケージを意味する、または詳細を一覧表示に使用可能なすべてのアプリの見込み客します。</span><span class="sxs-lookup"><span data-stu-id="75e3f-137">Your app will remain in the publishing phase until the process has completed, meaning that the new packages and/or listing details are available to all of your app’s potential customers.</span></span>

## <a name="in-the-store"></a><span data-ttu-id="75e3f-138">ストア内</span><span class="sxs-lookup"><span data-stu-id="75e3f-138">In the Store</span></span> 

<span data-ttu-id="75e3f-139">上記の手順が正常に完了すると、申請の状態が **[公開中]** から **[Microsoft Store 内]** に変わります。</span><span class="sxs-lookup"><span data-stu-id="75e3f-139">After successfully going through the steps above, the submission's status will change from **Publishing** to **In the Store**.</span></span> <span data-ttu-id="75e3f-140">その後、申請したアプリは Microsoft Store でユーザーがダウンロードできるようになります (他の[見つけやすさ](choose-visibility-options.md#discoverability)オプションを選んでいる場合は除きます)。</span><span class="sxs-lookup"><span data-stu-id="75e3f-140">Your submission will then be available in the Microsoft Store for customers to download (unless you have chosen another [Discoverability](choose-visibility-options.md#discoverability) option).</span></span> 

> [!NOTE]
> <span data-ttu-id="75e3f-141">アプリの公開後にもスポット チェックが実施され、発生する可能性のある問題の検出や、アプリが [Microsoft Store ポリシー](https://docs.microsoft.com/legal/windows/agreements/store-policies)のすべてに準拠しているかどうかの確認が行われます。</span><span class="sxs-lookup"><span data-stu-id="75e3f-141">We also conduct spot checks of apps after they've been published so we can identify potential problems and ensure that your app complies with all of the [Microsoft Store Policies](https://docs.microsoft.com/legal/windows/agreements/store-policies).</span></span> <span data-ttu-id="75e3f-142">アプリに問題が見つかった場合は、問題とその修正方法が通知されます。または、ストアからのアプリの削除が妥当な場合は、削除されたことが通知されます。</span><span class="sxs-lookup"><span data-stu-id="75e3f-142">If we find any problems, you'll be notified about the issue and how to fix it, if applicable, or if it has been removed from the Store.</span></span>

 

 

 




