---
Description: After you define your experiment in Partner Center and code your experiment in your app, you are ready to active your experiment and use Partner Center to review the results of your experiment.
title: パートナー センターで実験を管理する
ms.assetid: D48EE0B4-47F2-455C-8FB9-630769AC5ACE
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10、UWP、Microsoft Store Services SDK、A/B テスト、実験
ms.localizationpriority: medium
ms.openlocfilehash: 6e5c0d0ca1b1d771df2b224cc41ec5a37e267bc9
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8946565"
---
# <a name="manage-your-experiment-in-partner-center"></a><span data-ttu-id="6f8ef-103">パートナー センターで実験を管理する</span><span class="sxs-lookup"><span data-stu-id="6f8ef-103">Manage your experiment in Partner Center</span></span>

<span data-ttu-id="6f8ef-104">[パートナー センターで実験を定義](define-your-experiment-in-the-dev-center-dashboard.md)すると、[実験用のアプリのコード](code-your-experiment-in-your-app.md)実験をアクティブ化し、パートナー センターを使用して、実験の結果を確認する準備ができたらします。</span><span class="sxs-lookup"><span data-stu-id="6f8ef-104">After you [define your experiment in Partner Center](define-your-experiment-in-the-dev-center-dashboard.md) and [code your app for experimentation](code-your-experiment-in-your-app.md), you are ready to activate your experiment and use Partner Center to review the results of your experiment.</span></span> <span data-ttu-id="6f8ef-105">必要なすべてのデータを取得したら、実験を終了し、すべてのアプリでコントロールのバリエーションの変数値を使用し続けるか、他のバリエーションの変数値を使用することに切り替えるかを選択できます。</span><span class="sxs-lookup"><span data-stu-id="6f8ef-105">After you have obtained all the data you need, you can end your experiment and choose whether to keep using the variable values in the control variation for all your apps, or switch to using the variable values in one of your other variations.</span></span>

> [!NOTE]
> <span data-ttu-id="6f8ef-106">実験をアクティブ化するとすぐにパートナー センターが実験のデータをログにインストルメント化されたアプリからデータの収集を開始します。</span><span class="sxs-lookup"><span data-stu-id="6f8ef-106">When you activate an experiment, Partner Center immediately starts collecting data from any apps that are instrumented to log data for your experiment.</span></span> <span data-ttu-id="6f8ef-107">ただし、実験のデータがパートナー センターで表示される数時間がかかることができます。</span><span class="sxs-lookup"><span data-stu-id="6f8ef-107">However, it can take several hours for experiment data to appear in Partner Center.</span></span>

<span data-ttu-id="6f8ef-108">実験の作成および実行のプロセスについて詳しく示すチュートリアルについては、「[A/B テストを使用して最初の実験を作成および実行する](create-and-run-your-first-experiment-with-a-b-testing.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6f8ef-108">For a walkthrough that demonstrates the end-to-end process of creating and running an experiment, see [Create and run your first experiment with A/B testing](create-and-run-your-first-experiment-with-a-b-testing.md).</span></span>

## <a name="activate-your-experiment"></a><span data-ttu-id="6f8ef-109">実験をアクティブ化する</span><span class="sxs-lookup"><span data-stu-id="6f8ef-109">Activate your experiment</span></span>

<span data-ttu-id="6f8ef-110">パートナー センターで実験のパラメーターに問題がなければ、アプリのコードを更新するは、アプリから実験データの収集を開始できるように、実験をアクティブ化する準備ができたらします。</span><span class="sxs-lookup"><span data-stu-id="6f8ef-110">When you are satisfied with the parameters of your experiment in Partner Center and you have updated your app code, you are ready to activate your experiment so you can start collecting experiment data from your app.</span></span> <span data-ttu-id="6f8ef-111">実験がアクティブになって、アプリはバリエーション値を取得し、パートナー センターにビューとコンバージョン イベントを報告できます。</span><span class="sxs-lookup"><span data-stu-id="6f8ef-111">When the experiment is active, your app can retrieve variation values and report view and conversion events to Partner Center.</span></span>

1. <span data-ttu-id="6f8ef-112">[パートナー センター](https://partner.microsoft.com/dashboard)にサインインします。</span><span class="sxs-lookup"><span data-stu-id="6f8ef-112">Sign in to [Partner Center](https://partner.microsoft.com/dashboard).</span></span>
2. <span data-ttu-id="6f8ef-113">**[アプリ]** の下で、アクティブ化する実験を備えたアプリを選択します。</span><span class="sxs-lookup"><span data-stu-id="6f8ef-113">Under **Your apps**, select the app with the experiment that you want to activate.</span></span>
3. <span data-ttu-id="6f8ef-114">ナビゲーション ウィンドウで、**[サービス]** を選択し、**[実験]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="6f8ef-114">In the navigation pane, select **Services** and then select **Experimentation**.</span></span>
4. <span data-ttu-id="6f8ef-115">**[プロジェクト]** セクションのプロジェクトの表で、目的の実験が含まれるプロジェクトを展開し、次のいずれかを実行します。</span><span class="sxs-lookup"><span data-stu-id="6f8ef-115">In the table of projects in the **Projects** section, expand the project that contains your experiment and then do one of the following:</span></span>
  * <span data-ttu-id="6f8ef-116">実験の **[アクティブ化]** リンクをクリックします。</span><span class="sxs-lookup"><span data-stu-id="6f8ef-116">Click the **Activate** link for your experiment.</span></span> <span data-ttu-id="6f8ef-117">実験が、ページの上部にある **[アクティブな実験]** セクションに追加されます。</span><span class="sxs-lookup"><span data-stu-id="6f8ef-117">Your experiment is added to the **Active experiments** section near the top of the page.</span></span>
  * <span data-ttu-id="6f8ef-118">実験の名前をクリックし、実験のページの下部までスクロールして、**[アクティブ化]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="6f8ef-118">Click the experiment name, scroll to the bottom of the experiment page, and click **Activate**.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="6f8ef-119">実験の作成時に **[編集可能な実験]** チェック ボックスをオンにしていないと、実験をアクティブ化した後で実験のパラメーターを変更できなくなります。</span><span class="sxs-lookup"><span data-stu-id="6f8ef-119">After you activate an experiment, you can no longer modify the experiment parameters unless you clicked the **Editable experiment** check box when you created the experiment.</span></span> <span data-ttu-id="6f8ef-120">アプリで実験のコードを記述してから実験をアクティブ化することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="6f8ef-120">We recommend that you code the experiment in your app before activating your experiment.</span></span>

## <a name="review-the-results-of-your-experiment"></a><span data-ttu-id="6f8ef-121">実験の結果を確認する</span><span class="sxs-lookup"><span data-stu-id="6f8ef-121">Review the results of your experiment</span></span>

1. <span data-ttu-id="6f8ef-122">パートナー センターで、アプリの**実験**のページに戻ります。</span><span class="sxs-lookup"><span data-stu-id="6f8ef-122">In Partner Center, return to the **Experimentation** page for your app.</span></span>
2. <span data-ttu-id="6f8ef-123">**[アクティブな実験]** セクションで、目的のアクティブな実験の名前をクリックし、実験のページに移動します。</span><span class="sxs-lookup"><span data-stu-id="6f8ef-123">In the **Active experiments** section, click the name of your active experiment to go to the experiment page.</span></span>
3. <span data-ttu-id="6f8ef-124">アクティブな実験または完了した実験の場合、このページの最初の 2 つのセクションに実験の結果が表示されます。</span><span class="sxs-lookup"><span data-stu-id="6f8ef-124">For an active or completed experiment, the first two sections in this page provide the results of your experiment:</span></span>
  * <span data-ttu-id="6f8ef-125">**[結果の概要]** セクションには、実験の目標と各バリエーションのコンバージョン率の一覧が表示されます。</span><span class="sxs-lookup"><span data-stu-id="6f8ef-125">The **Results summary** section lists your experiment goals and the conversion rate percentage for each variation.</span></span>
  * <span data-ttu-id="6f8ef-126">**[結果の詳細]** セクションには、ビュー、コンバージョン、固有ユーザー数、コンバージョン率、デルタ %、信頼性、重要性など、実験のすべての目標に対する各検証結果の詳細が表示されます。</span><span class="sxs-lookup"><span data-stu-id="6f8ef-126">The **Results details** section provides more details for each variation of all the goals in your experiment, including the views, conversions, unique users, conversion rate, delta %, confidence, and significance.</span></span> <span data-ttu-id="6f8ef-127">*信頼性*は、推定値の信頼性の統計的な計測であり、許容誤差を計算したものです。</span><span class="sxs-lookup"><span data-stu-id="6f8ef-127">The *confidence* is a statistical measure of the reliability of an estimate, which calculates the margin of error.</span></span> <span data-ttu-id="6f8ef-128">*重要性*は、サンプル サイズに基づいた統計的な計測であり、結果が偶然に発生したのではなく、特定の原因によって発生した可能性があることを示すものです。</span><span class="sxs-lookup"><span data-stu-id="6f8ef-128">The *significance* is a statistical measure, based on sample size, to determine the likelihood that a result is not due to chance, but is instead attributed to a specific cause.</span></span>

> [!NOTE]
> <span data-ttu-id="6f8ef-129">パートナー センターでは、24 時間の期間に各ユーザーの最初のコンバージョン イベントのみを報告します。</span><span class="sxs-lookup"><span data-stu-id="6f8ef-129">Partner Center reports only the first conversion event for each user in a 24-hour time period.</span></span> <span data-ttu-id="6f8ef-130">ユーザーが 24 時間以内にアプリで複数のコンバージョン イベントをトリガーした場合は、最初のコンバージョン イベントのみ報告されます。</span><span class="sxs-lookup"><span data-stu-id="6f8ef-130">If a user triggers multiple conversion events in your app within a 24-hour period, only the first conversion event is reported.</span></span> <span data-ttu-id="6f8ef-131">これは、多数のコンバージョン イベントを使用する単一のユーザーによって、サンプルのユーザー グループの実験の結果が歪曲されないようにすることを目的としています。</span><span class="sxs-lookup"><span data-stu-id="6f8ef-131">This is intended to help prevent a single user with many conversion events from skewing the experiment results for a sample group of users.</span></span>


## <a name="complete-your-experiment"></a><span data-ttu-id="6f8ef-132">実験を完了する</span><span class="sxs-lookup"><span data-stu-id="6f8ef-132">Complete your experiment</span></span>

1. <span data-ttu-id="6f8ef-133">パートナー センターで、実験のページに戻ります。</span><span class="sxs-lookup"><span data-stu-id="6f8ef-133">In Partner Center, return to your experiment page.</span></span> <span data-ttu-id="6f8ef-134">手順については、前のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6f8ef-134">For instructions, see the previous section.</span></span>
2. <span data-ttu-id="6f8ef-135">**[結果の概要]** セクションで、次のいずれかの操作を行います。</span><span class="sxs-lookup"><span data-stu-id="6f8ef-135">In the **Results summary** section, do one of the following:</span></span>
  * <span data-ttu-id="6f8ef-136">実験を終了し、アプリでコントロールのバリエーションの変数値を使用し続ける場合は、**[保存]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="6f8ef-136">If you want to end the experiment and continue using the variable values in the control variation in your app, click **Keep**.</span></span>
  * <span data-ttu-id="6f8ef-137">実験を終了するが、アプリでは別のバリエーションの変数値を使用する場合は、新たに使用するバリエーションの下にある **[切り替え]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="6f8ef-137">If you want to end the experiment but switch to using the variable values in a different variation in your app, click **Switch** under the variation to which you want to switch.</span></span>
3. <span data-ttu-id="6f8ef-138">**[OK]** をクリックして、実験を終了することを確認します。</span><span class="sxs-lookup"><span data-stu-id="6f8ef-138">Click **OK** to confirm that you want to end the experiment.</span></span>


## <a name="related-topics"></a><span data-ttu-id="6f8ef-139">関連トピック</span><span class="sxs-lookup"><span data-stu-id="6f8ef-139">Related topics</span></span>

* [<span data-ttu-id="6f8ef-140">プロジェクトを作成し、パートナー センターでリモート変数を定義します。</span><span class="sxs-lookup"><span data-stu-id="6f8ef-140">Create a project and define remote variables in Partner Center</span></span>](create-a-project-and-define-remote-variables-in-the-dev-center-dashboard.md)
* [<span data-ttu-id="6f8ef-141">アプリの実験用のコードを記述する</span><span class="sxs-lookup"><span data-stu-id="6f8ef-141">Code your app for experimentation</span></span>](code-your-experiment-in-your-app.md)
* [<span data-ttu-id="6f8ef-142">パートナー センターで実験を定義する</span><span class="sxs-lookup"><span data-stu-id="6f8ef-142">Define your experiment in Partner Center</span></span>](define-your-experiment-in-the-dev-center-dashboard.md)
* [<span data-ttu-id="6f8ef-143">A/B テストを使用して最初の実験を作成および実行する</span><span class="sxs-lookup"><span data-stu-id="6f8ef-143">Create and run your first experiment with A/B testing</span></span>](create-and-run-your-first-experiment-with-a-b-testing.md)
* [<span data-ttu-id="6f8ef-144">A/B テストを使用してアプリの実験を実行する</span><span class="sxs-lookup"><span data-stu-id="6f8ef-144">Run app experiments with A/B testing</span></span>](run-app-experiments-with-a-b-testing.md)
