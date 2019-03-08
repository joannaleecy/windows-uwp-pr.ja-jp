---
Description: パートナー センターで、実験を定義し、アプリでコードを実験、実験をアクティブに準備が完了し、パートナー センターを使用して、実験の結果を確認します。
title: パートナー センターで実験を管理する
ms.assetid: D48EE0B4-47F2-455C-8FB9-630769AC5ACE
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store Services SDK, A/B テスト, 実験
ms.localizationpriority: medium
ms.openlocfilehash: 6e5c0d0ca1b1d771df2b224cc41ec5a37e267bc9
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57594927"
---
# <a name="manage-your-experiment-in-partner-center"></a><span data-ttu-id="dd791-104">パートナー センターで実験を管理する</span><span class="sxs-lookup"><span data-stu-id="dd791-104">Manage your experiment in Partner Center</span></span>

<span data-ttu-id="dd791-105">したら[パートナー センターで、実験を定義](define-your-experiment-in-the-dev-center-dashboard.md)と[実験用のアプリをコード](code-your-experiment-in-your-app.md)実験をアクティブ化およびパートナー センターを使用して、実験の結果を確認する準備が整いました。</span><span class="sxs-lookup"><span data-stu-id="dd791-105">After you [define your experiment in Partner Center](define-your-experiment-in-the-dev-center-dashboard.md) and [code your app for experimentation](code-your-experiment-in-your-app.md), you are ready to activate your experiment and use Partner Center to review the results of your experiment.</span></span> <span data-ttu-id="dd791-106">必要なすべてのデータを取得したら、実験を終了し、すべてのアプリでコントロールのバリエーションの変数値を使用し続けるか、他のバリエーションの変数値を使用することに切り替えるかを選択できます。</span><span class="sxs-lookup"><span data-stu-id="dd791-106">After you have obtained all the data you need, you can end your experiment and choose whether to keep using the variable values in the control variation for all your apps, or switch to using the variable values in one of your other variations.</span></span>

> [!NOTE]
> <span data-ttu-id="dd791-107">実験をアクティブ化するとすぐにパートナー センターが、実験用のデータをログにインストルメント化されている任意のアプリからデータの収集を開始します。</span><span class="sxs-lookup"><span data-stu-id="dd791-107">When you activate an experiment, Partner Center immediately starts collecting data from any apps that are instrumented to log data for your experiment.</span></span> <span data-ttu-id="dd791-108">ただし、実験のデータがパートナー センターで表示される数時間がかかることができます。</span><span class="sxs-lookup"><span data-stu-id="dd791-108">However, it can take several hours for experiment data to appear in Partner Center.</span></span>

<span data-ttu-id="dd791-109">実験の作成と実行のプロセスについて詳しく示すチュートリアルについては、「[A/B テストを使用して最初の実験を作成および実行する](create-and-run-your-first-experiment-with-a-b-testing.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="dd791-109">For a walkthrough that demonstrates the end-to-end process of creating and running an experiment, see [Create and run your first experiment with A/B testing](create-and-run-your-first-experiment-with-a-b-testing.md).</span></span>

## <a name="activate-your-experiment"></a><span data-ttu-id="dd791-110">実験をアクティブ化する</span><span class="sxs-lookup"><span data-stu-id="dd791-110">Activate your experiment</span></span>

<span data-ttu-id="dd791-111">パートナー センターで、実験のパラメーターに満足したら、アプリ コードを更新すると、アプリから実験のデータの収集を開始できるように、実験をアクティブにする準備が整いました。</span><span class="sxs-lookup"><span data-stu-id="dd791-111">When you are satisfied with the parameters of your experiment in Partner Center and you have updated your app code, you are ready to activate your experiment so you can start collecting experiment data from your app.</span></span> <span data-ttu-id="dd791-112">実験がアクティブの場合、アプリはバリエーションの 1 つの値を取得し、パートナー センターに表示し、変換のイベントを報告できます。</span><span class="sxs-lookup"><span data-stu-id="dd791-112">When the experiment is active, your app can retrieve variation values and report view and conversion events to Partner Center.</span></span>

1. <span data-ttu-id="dd791-113">[パートナー センター](https://partner.microsoft.com/dashboard)にサインインします。</span><span class="sxs-lookup"><span data-stu-id="dd791-113">Sign in to [Partner Center](https://partner.microsoft.com/dashboard).</span></span>
2. <span data-ttu-id="dd791-114">**[アプリ]** の下で、アクティブ化する実験を備えたアプリを選択します。</span><span class="sxs-lookup"><span data-stu-id="dd791-114">Under **Your apps**, select the app with the experiment that you want to activate.</span></span>
3. <span data-ttu-id="dd791-115">ナビゲーション ウィンドウで、**[サービス]** を選択し、**[実験]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="dd791-115">In the navigation pane, select **Services** and then select **Experimentation**.</span></span>
4. <span data-ttu-id="dd791-116">**[プロジェクト]** セクションのプロジェクトの表で、目的の実験が含まれるプロジェクトを展開し、次のいずれかを実行します。</span><span class="sxs-lookup"><span data-stu-id="dd791-116">In the table of projects in the **Projects** section, expand the project that contains your experiment and then do one of the following:</span></span>
  * <span data-ttu-id="dd791-117">実験の **[アクティブ化]** リンクをクリックします。</span><span class="sxs-lookup"><span data-stu-id="dd791-117">Click the **Activate** link for your experiment.</span></span> <span data-ttu-id="dd791-118">実験が、ページの上部にある **[アクティブな実験]** セクションに追加されます。</span><span class="sxs-lookup"><span data-stu-id="dd791-118">Your experiment is added to the **Active experiments** section near the top of the page.</span></span>
  * <span data-ttu-id="dd791-119">実験の名前をクリックし、実験のページの下部までスクロールして、**[アクティブ化]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="dd791-119">Click the experiment name, scroll to the bottom of the experiment page, and click **Activate**.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="dd791-120">実験の作成時に **[編集可能な実験]** チェック ボックスをオンにしていないと、実験をアクティブ化した後で実験のパラメーターを変更できなくなります。</span><span class="sxs-lookup"><span data-stu-id="dd791-120">After you activate an experiment, you can no longer modify the experiment parameters unless you clicked the **Editable experiment** check box when you created the experiment.</span></span> <span data-ttu-id="dd791-121">アプリで実験のコードを記述してから実験をアクティブ化することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="dd791-121">We recommend that you code the experiment in your app before activating your experiment.</span></span>

## <a name="review-the-results-of-your-experiment"></a><span data-ttu-id="dd791-122">実験の結果を確認する</span><span class="sxs-lookup"><span data-stu-id="dd791-122">Review the results of your experiment</span></span>

1. <span data-ttu-id="dd791-123">パートナー センターでに戻り、**実験**アプリのページ。</span><span class="sxs-lookup"><span data-stu-id="dd791-123">In Partner Center, return to the **Experimentation** page for your app.</span></span>
2. <span data-ttu-id="dd791-124">**[アクティブな実験]** セクションで、目的のアクティブな実験の名前をクリックし、実験のページに移動します。</span><span class="sxs-lookup"><span data-stu-id="dd791-124">In the **Active experiments** section, click the name of your active experiment to go to the experiment page.</span></span>
3. <span data-ttu-id="dd791-125">アクティブな実験または完了した実験の場合、このページの最初の 2 つのセクションに実験の結果が表示されます。</span><span class="sxs-lookup"><span data-stu-id="dd791-125">For an active or completed experiment, the first two sections in this page provide the results of your experiment:</span></span>
  * <span data-ttu-id="dd791-126">**[結果の概要]** セクションには、実験の目標と各バリエーションのコンバージョン率の一覧が表示されます。</span><span class="sxs-lookup"><span data-stu-id="dd791-126">The **Results summary** section lists your experiment goals and the conversion rate percentage for each variation.</span></span>
  * <span data-ttu-id="dd791-127">**[結果の詳細]** セクションには、ビュー、コンバージョン、固有ユーザー数、コンバージョン率、デルタ %、信頼性、重要性など、実験のすべての目標に対する各検証結果の詳細が表示されます。</span><span class="sxs-lookup"><span data-stu-id="dd791-127">The **Results details** section provides more details for each variation of all the goals in your experiment, including the views, conversions, unique users, conversion rate, delta %, confidence, and significance.</span></span> <span data-ttu-id="dd791-128">*信頼性*は、推定値の信頼性の統計的な計測であり、許容誤差を計算したものです。</span><span class="sxs-lookup"><span data-stu-id="dd791-128">The *confidence* is a statistical measure of the reliability of an estimate, which calculates the margin of error.</span></span> <span data-ttu-id="dd791-129">*重要性*は、サンプル サイズに基づいた統計的な計測であり、結果が偶然に発生したのではなく、特定の原因によって発生した可能性があることを示すものです。</span><span class="sxs-lookup"><span data-stu-id="dd791-129">The *significance* is a statistical measure, based on sample size, to determine the likelihood that a result is not due to chance, but is instead attributed to a specific cause.</span></span>

> [!NOTE]
> <span data-ttu-id="dd791-130">パートナー センターでは、24 時間の期間に各ユーザーの最初の変換イベントのみを報告します。</span><span class="sxs-lookup"><span data-stu-id="dd791-130">Partner Center reports only the first conversion event for each user in a 24-hour time period.</span></span> <span data-ttu-id="dd791-131">ユーザーが 24 時間以内にアプリで複数のコンバージョン イベントをトリガーした場合は、最初のコンバージョン イベントのみ報告されます。</span><span class="sxs-lookup"><span data-stu-id="dd791-131">If a user triggers multiple conversion events in your app within a 24-hour period, only the first conversion event is reported.</span></span> <span data-ttu-id="dd791-132">これは、多数のコンバージョン イベントを使用する単一のユーザーによって、サンプルのユーザー グループの実験の実行結果が歪曲されないようにすることを目的としています。</span><span class="sxs-lookup"><span data-stu-id="dd791-132">This is intended to help prevent a single user with many conversion events from skewing the experiment results for a sample group of users.</span></span>


## <a name="complete-your-experiment"></a><span data-ttu-id="dd791-133">実験を完了する</span><span class="sxs-lookup"><span data-stu-id="dd791-133">Complete your experiment</span></span>

1. <span data-ttu-id="dd791-134">パートナー センターでは、実験のページに戻ります。</span><span class="sxs-lookup"><span data-stu-id="dd791-134">In Partner Center, return to your experiment page.</span></span> <span data-ttu-id="dd791-135">手順については、前のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="dd791-135">For instructions, see the previous section.</span></span>
2. <span data-ttu-id="dd791-136">**[Results summary]** セクションで、次のいずれかの操作を行います。</span><span class="sxs-lookup"><span data-stu-id="dd791-136">In the **Results summary** section, do one of the following:</span></span>
  * <span data-ttu-id="dd791-137">実験を終了し、アプリでコントロールのバリエーションの変数値を使用し続ける場合は、**[保存]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="dd791-137">If you want to end the experiment and continue using the variable values in the control variation in your app, click **Keep**.</span></span>
  * <span data-ttu-id="dd791-138">実験を終了するが、アプリでは別のバリエーションの変数値を使用する場合は、新たに使用するバリエーションの下にある **[切り替え]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="dd791-138">If you want to end the experiment but switch to using the variable values in a different variation in your app, click **Switch** under the variation to which you want to switch.</span></span>
3. <span data-ttu-id="dd791-139">**[OK]** をクリックして、試験的機能を終了することを確認します。</span><span class="sxs-lookup"><span data-stu-id="dd791-139">Click **OK** to confirm that you want to end the experiment.</span></span>


## <a name="related-topics"></a><span data-ttu-id="dd791-140">関連トピック</span><span class="sxs-lookup"><span data-stu-id="dd791-140">Related topics</span></span>

* [<span data-ttu-id="dd791-141">プロジェクトを作成し、パートナー センターでのリモート変数の定義</span><span class="sxs-lookup"><span data-stu-id="dd791-141">Create a project and define remote variables in Partner Center</span></span>](create-a-project-and-define-remote-variables-in-the-dev-center-dashboard.md)
* [<span data-ttu-id="dd791-142">実験用のアプリをコードします。</span><span class="sxs-lookup"><span data-stu-id="dd791-142">Code your app for experimentation</span></span>](code-your-experiment-in-your-app.md)
* [<span data-ttu-id="dd791-143">パートナー センターでの実験を定義します。</span><span class="sxs-lookup"><span data-stu-id="dd791-143">Define your experiment in Partner Center</span></span>](define-your-experiment-in-the-dev-center-dashboard.md)
* [<span data-ttu-id="dd791-144">作成し、A で初めての実験を実行する B のテスト</span><span class="sxs-lookup"><span data-stu-id="dd791-144">Create and run your first experiment with A/B testing</span></span>](create-and-run-your-first-experiment-with-a-b-testing.md)
* [<span data-ttu-id="dd791-145">A とアプリの実験を実行する B のテスト</span><span class="sxs-lookup"><span data-stu-id="dd791-145">Run app experiments with A/B testing</span></span>](run-app-experiments-with-a-b-testing.md)
