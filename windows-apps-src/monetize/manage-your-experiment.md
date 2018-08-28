---
author: mcleanbyron
Description: After you define your experiment in the Dev Center dashboard and code your experiment in your app, you are ready to active your experiment and use the Dev Center dashboard to review the results of your experiment.
title: ダッシュボードで実験を管理する
ms.assetid: D48EE0B4-47F2-455C-8FB9-630769AC5ACE
ms.author: mcleans
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10、UWP、Microsoft Store Services SDK、A/B テスト、実験
ms.localizationpriority: medium
ms.openlocfilehash: 073d5ec67bb012cbfe21c279ee97ec3c50b8458f
ms.sourcegitcommit: 9a17266f208ec415fc718e5254d5b4c08835150c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/28/2018
ms.locfileid: "2881915"
---
# <a name="manage-your-experiment-in-the-dashboard"></a><span data-ttu-id="63d80-103">ダッシュボードで実験を管理する</span><span class="sxs-lookup"><span data-stu-id="63d80-103">Manage your experiment in the dashboard</span></span>

<span data-ttu-id="63d80-104">[デベロッパー センター ダッシュ ボードで実験を定義](define-your-experiment-in-the-dev-center-dashboard.md)し、[アプリでその実験のコードを記述](code-your-experiment-in-your-app.md)したら、実験をアクティブ化し、デベロッパー センター ダッシュ ボードを使用して、実験の結果を確認できます。</span><span class="sxs-lookup"><span data-stu-id="63d80-104">After you [define your experiment in the Dev Center dashboard](define-your-experiment-in-the-dev-center-dashboard.md) and [code your app for experimentation](code-your-experiment-in-your-app.md), you are ready to activate your experiment and use the Dev Center dashboard to review the results of your experiment.</span></span> <span data-ttu-id="63d80-105">必要なすべてのデータを取得したら、実験を終了し、すべてのアプリでコントロールのバリエーションの変数値を使用し続けるか、他のバリエーションの変数値を使用することに切り替えるかを選択できます。</span><span class="sxs-lookup"><span data-stu-id="63d80-105">After you have obtained all the data you need, you can end your experiment and choose whether to keep using the variable values in the control variation for all your apps, or switch to using the variable values in one of your other variations.</span></span>

> [!NOTE]
> <span data-ttu-id="63d80-106">実験をアクティブ化すると、デベロッパー センターでは、実験のデータをログに記録するようにインストルメント化されたアプリからのデータ収集が直ちに開始されます。</span><span class="sxs-lookup"><span data-stu-id="63d80-106">When you activate an experiment, Dev Center immediately starts collecting data from any apps that are instrumented to log data for your experiment.</span></span> <span data-ttu-id="63d80-107">ただし、実験のデータがダッシュボードに表示されるまでに数時間かかることがあります。</span><span class="sxs-lookup"><span data-stu-id="63d80-107">However, it can take several hours for experiment data to appear in the dashboard.</span></span>

<span data-ttu-id="63d80-108">実験の作成および実行のプロセスについて詳しく示すチュートリアルについては、「[A/B テストを使用して最初の実験を作成および実行する](create-and-run-your-first-experiment-with-a-b-testing.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="63d80-108">For a walkthrough that demonstrates the end-to-end process of creating and running an experiment, see [Create and run your first experiment with A/B testing](create-and-run-your-first-experiment-with-a-b-testing.md).</span></span>

## <a name="activate-your-experiment"></a><span data-ttu-id="63d80-109">実験をアクティブ化する</span><span class="sxs-lookup"><span data-stu-id="63d80-109">Activate your experiment</span></span>

<span data-ttu-id="63d80-110">ダッシュボードの実験のパラメーターに問題がなく、アプリのコードを更新したら、実験をアクティブ化し、アプリから実験のデータを収集できるようになります。</span><span class="sxs-lookup"><span data-stu-id="63d80-110">When you are satisfied with the parameters of your experiment on the dashboard and you have updated your app code, you are ready to activate your experiment so you can start collecting experiment data from your app.</span></span> <span data-ttu-id="63d80-111">実験がアクティブになっていると、アプリはバリエーション値を取得し、デベロッパー センターにビュー イベントとコンバージョン イベントをレポートできます。</span><span class="sxs-lookup"><span data-stu-id="63d80-111">When the experiment is active, your app can retrieve variation values and report view and conversion events to Dev Center.</span></span>

1. <span data-ttu-id="63d80-112">[デベロッパー センター ダッシュボード](https://dev.windows.com/overview)にサインインします。</span><span class="sxs-lookup"><span data-stu-id="63d80-112">Sign in to the [Dev Center dashboard](https://dev.windows.com/overview).</span></span>
2. <span data-ttu-id="63d80-113">**[アプリ]** の下で、アクティブ化する実験を備えたアプリを選択します。</span><span class="sxs-lookup"><span data-stu-id="63d80-113">Under **Your apps**, select the app with the experiment that you want to activate.</span></span>
3. <span data-ttu-id="63d80-114">ナビゲーション ウィンドウで、**[サービス]** を選択し、**[実験]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="63d80-114">In the navigation pane, select **Services** and then select **Experimentation**.</span></span>
4. <span data-ttu-id="63d80-115">**[プロジェクト]** セクションのプロジェクトの表で、目的の実験が含まれるプロジェクトを展開し、次のいずれかを実行します。</span><span class="sxs-lookup"><span data-stu-id="63d80-115">In the table of projects in the **Projects** section, expand the project that contains your experiment and then do one of the following:</span></span>
  * <span data-ttu-id="63d80-116">実験の **[アクティブ化]** リンクをクリックします。</span><span class="sxs-lookup"><span data-stu-id="63d80-116">Click the **Activate** link for your experiment.</span></span> <span data-ttu-id="63d80-117">実験が、ページの上部にある **[アクティブな実験]** セクションに追加されます。</span><span class="sxs-lookup"><span data-stu-id="63d80-117">Your experiment is added to the **Active experiments** section near the top of the page.</span></span>
  * <span data-ttu-id="63d80-118">実験の名前をクリックし、実験のページの下部までスクロールして、**[アクティブ化]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="63d80-118">Click the experiment name, scroll to the bottom of the experiment page, and click **Activate**.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="63d80-119">実験の作成時に **[編集可能な実験]** チェック ボックスをオンにしていないと、実験をアクティブ化した後で実験のパラメーターを変更できなくなります。</span><span class="sxs-lookup"><span data-stu-id="63d80-119">After you activate an experiment, you can no longer modify the experiment parameters unless you clicked the **Editable experiment** check box when you created the experiment.</span></span> <span data-ttu-id="63d80-120">アプリで実験のコードを記述してから実験をアクティブ化することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="63d80-120">We recommend that you code the experiment in your app before activating your experiment.</span></span>

## <a name="review-the-results-of-your-experiment"></a><span data-ttu-id="63d80-121">実験の結果を確認する</span><span class="sxs-lookup"><span data-stu-id="63d80-121">Review the results of your experiment</span></span>

1. <span data-ttu-id="63d80-122">デベロッパー センターで、アプリの **[実験]** ページに戻ります。</span><span class="sxs-lookup"><span data-stu-id="63d80-122">In Dev Center, return to the **Experimentation** page for your app.</span></span>
2. <span data-ttu-id="63d80-123">**[アクティブな実験]** セクションで、目的のアクティブな実験の名前をクリックし、実験のページに移動します。</span><span class="sxs-lookup"><span data-stu-id="63d80-123">In the **Active experiments** section, click the name of your active experiment to go to the experiment page.</span></span>
3. <span data-ttu-id="63d80-124">アクティブな実験または完了した実験の場合、このページの最初の 2 つのセクションに実験の結果が表示されます。</span><span class="sxs-lookup"><span data-stu-id="63d80-124">For an active or completed experiment, the first two sections in this page provide the results of your experiment:</span></span>
  * <span data-ttu-id="63d80-125">**[結果の概要]** セクションには、実験の目標と各バリエーションのコンバージョン率の一覧が表示されます。</span><span class="sxs-lookup"><span data-stu-id="63d80-125">The **Results summary** section lists your experiment goals and the conversion rate percentage for each variation.</span></span>
  * <span data-ttu-id="63d80-126">**[結果の詳細]** セクションには、ビュー、コンバージョン、固有ユーザー数、コンバージョン率、デルタ %、信頼性、重要性など、実験のすべての目標に対する各検証結果の詳細が表示されます。</span><span class="sxs-lookup"><span data-stu-id="63d80-126">The **Results details** section provides more details for each variation of all the goals in your experiment, including the views, conversions, unique users, conversion rate, delta %, confidence, and significance.</span></span> <span data-ttu-id="63d80-127">*信頼性*は、推定値の信頼性の統計的な計測であり、許容誤差を計算したものです。</span><span class="sxs-lookup"><span data-stu-id="63d80-127">The *confidence* is a statistical measure of the reliability of an estimate, which calculates the margin of error.</span></span> <span data-ttu-id="63d80-128">*重要性*は、サンプル サイズに基づいた統計的な計測であり、結果が偶然に発生したのではなく、特定の原因によって発生した可能性があることを示すものです。</span><span class="sxs-lookup"><span data-stu-id="63d80-128">The *significance* is a statistical measure, based on sample size, to determine the likelihood that a result is not due to chance, but is instead attributed to a specific cause.</span></span>

> [!NOTE]
> <span data-ttu-id="63d80-129">デベロッパー センターで報告されるのは、24 時間以内に発生した、各ユーザーの最初のコンバージョン イベントのみです。</span><span class="sxs-lookup"><span data-stu-id="63d80-129">Dev Center reports only the first conversion event for each user in a 24-hour time period.</span></span> <span data-ttu-id="63d80-130">ユーザーが 24 時間以内にアプリで複数のコンバージョン イベントをトリガーした場合は、最初のコンバージョン イベントのみ報告されます。</span><span class="sxs-lookup"><span data-stu-id="63d80-130">If a user triggers multiple conversion events in your app within a 24-hour period, only the first conversion event is reported.</span></span> <span data-ttu-id="63d80-131">これは、多数のコンバージョン イベントを使用する単一のユーザーによって、サンプルのユーザー グループの実験の結果が歪曲されないようにすることを目的としています。</span><span class="sxs-lookup"><span data-stu-id="63d80-131">This is intended to help prevent a single user with many conversion events from skewing the experiment results for a sample group of users.</span></span>


## <a name="complete-your-experiment"></a><span data-ttu-id="63d80-132">実験を完了する</span><span class="sxs-lookup"><span data-stu-id="63d80-132">Complete your experiment</span></span>

1. <span data-ttu-id="63d80-133">ダッシュボードで、実験のページに戻ります。</span><span class="sxs-lookup"><span data-stu-id="63d80-133">In the dashboard, return to your experiment page.</span></span> <span data-ttu-id="63d80-134">手順については、前のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="63d80-134">For instructions, see the previous section.</span></span>
2. <span data-ttu-id="63d80-135">**[結果の概要]** セクションで、次のいずれかの操作を行います。</span><span class="sxs-lookup"><span data-stu-id="63d80-135">In the **Results summary** section, do one of the following:</span></span>
  * <span data-ttu-id="63d80-136">実験を終了し、アプリでコントロールのバリエーションの変数値を使用し続ける場合は、**[保存]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="63d80-136">If you want to end the experiment and continue using the variable values in the control variation in your app, click **Keep**.</span></span>
  * <span data-ttu-id="63d80-137">実験を終了するが、アプリでは別のバリエーションの変数値を使用する場合は、新たに使用するバリエーションの下にある **[切り替え]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="63d80-137">If you want to end the experiment but switch to using the variable values in a different variation in your app, click **Switch** under the variation to which you want to switch.</span></span>
3. <span data-ttu-id="63d80-138">**[OK]** をクリックして、実験を終了することを確認します。</span><span class="sxs-lookup"><span data-stu-id="63d80-138">Click **OK** to confirm that you want to end the experiment.</span></span>


## <a name="related-topics"></a><span data-ttu-id="63d80-139">関連トピック</span><span class="sxs-lookup"><span data-stu-id="63d80-139">Related topics</span></span>

* [<span data-ttu-id="63d80-140">プロジェクトを作成し、デベロッパー センター ダッシュボードでリモート変数を定義する</span><span class="sxs-lookup"><span data-stu-id="63d80-140">Create a project and define remote variables in the Dev Center dashboard</span></span>](create-a-project-and-define-remote-variables-in-the-dev-center-dashboard.md)
* [<span data-ttu-id="63d80-141">アプリの実験用のコードを記述する</span><span class="sxs-lookup"><span data-stu-id="63d80-141">Code your app for experimentation</span></span>](code-your-experiment-in-your-app.md)
* [<span data-ttu-id="63d80-142">デベロッパー センター ダッシュボードで実験を定義する</span><span class="sxs-lookup"><span data-stu-id="63d80-142">Define your experiment in the Dev Center dashboard</span></span>](define-your-experiment-in-the-dev-center-dashboard.md)
* [<span data-ttu-id="63d80-143">A/B テストを使用して最初の実験を作成および実行する</span><span class="sxs-lookup"><span data-stu-id="63d80-143">Create and run your first experiment with A/B testing</span></span>](create-and-run-your-first-experiment-with-a-b-testing.md)
* [<span data-ttu-id="63d80-144">A/B テストを使用してアプリの実験を実行する</span><span class="sxs-lookup"><span data-stu-id="63d80-144">Run app experiments with A/B testing</span></span>](run-app-experiments-with-a-b-testing.md)
