---
Description: テスト B を A でユニバーサル Windows プラットフォーム (UWP) アプリで実験を実行する前に/プロジェクトを作成し、パートナー センターで、リモートの変数を定義する必要があります。
title: パートナー センターで実験プロジェクトを作成する
ms.assetid: C3809FF1-0A6A-4715-B989-BE9D0E8C9013
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store Services SDK, A/B テスト, 実験
ms.localizationpriority: medium
ms.openlocfilehash: acfd654f02cb7fb727d35271175e59966e2abdc4
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57650797"
---
# <a name="create-an-experiment-project-in-partner-center"></a><span data-ttu-id="95f65-104">パートナー センターで実験プロジェクトを作成する</span><span class="sxs-lookup"><span data-stu-id="95f65-104">Create an experiment project in Partner Center</span></span>

<span data-ttu-id="95f65-105">を実験を開始するには、実験を作成[プロジェクト](run-app-experiments-with-a-b-testing.md#terms)パートナー センターでアプリのアプリにアクセスできるリモート変数を定義します。</span><span class="sxs-lookup"><span data-stu-id="95f65-105">To get started with experimentation, create an experimentation [project](run-app-experiments-with-a-b-testing.md#terms) for your app in Partner Center and define the remote variables that your app can access.</span></span>

<span data-ttu-id="95f65-106">次の手順では、プロジェクトを作成するための主な手順について説明します。</span><span class="sxs-lookup"><span data-stu-id="95f65-106">The following instructions describe the core steps to create a project.</span></span> <span data-ttu-id="95f65-107">プロジェクトの作成と実験の実行のプロセスについて詳しく示すチュートリアルについては、「[A/B テストを使用して最初の実験を作成および実行する](create-and-run-your-first-experiment-with-a-b-testing.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="95f65-107">For a detailed walkthrough that demonstrates the end-to-end process of creating a project and then running an experiment, see [Create and run your first experiment with A/B testing](create-and-run-your-first-experiment-with-a-b-testing.md).</span></span>

## <a name="instructions"></a><span data-ttu-id="95f65-108">手順</span><span class="sxs-lookup"><span data-stu-id="95f65-108">Instructions</span></span>

1. <span data-ttu-id="95f65-109">[パートナー センター](https://partner.microsoft.com/dashboard)にサインインします。</span><span class="sxs-lookup"><span data-stu-id="95f65-109">Sign in to [Partner Center](https://partner.microsoft.com/dashboard).</span></span>
2. <span data-ttu-id="95f65-110">**[Your apps]** で、試験的機能を作成するアプリを選択します。</span><span class="sxs-lookup"><span data-stu-id="95f65-110">Under **Your apps**, select the app for which you want to create an experiment.</span></span>
3. <span data-ttu-id="95f65-111">ナビゲーション ウィンドウで、**[サービス]** を選択し、**[実験]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="95f65-111">In the navigation pane, select **Services** and then select **Experimentation**.</span></span>
4. <span data-ttu-id="95f65-112">**[Experimentation]** ページで、**[プロジェクト]** セクション **[新しいプロジェクト]** ボタンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="95f65-112">On the **Experimentation** page, click the **New project** button in the **Projects** section.</span></span> <span data-ttu-id="95f65-113">1 つ以上のプロジェクトを既に作成している場合、それらのプロジェクトが **[プロジェクト]** セクションに表示されます。</span><span class="sxs-lookup"><span data-stu-id="95f65-113">If you have already created one or more projects, those projects are listed in the **Projects** section.</span></span>
5. <span data-ttu-id="95f65-114">**[新しいプロジェクト]** ページで、新しいプロジェクトの名前を入力します。</span><span class="sxs-lookup"><span data-stu-id="95f65-114">In the **New project** page, enter a name for your new project.</span></span>
6. <span data-ttu-id="95f65-115">**[リモート変数]** セクションで、このプロジェクトのすべての実験で利用できるようにする[変数](run-app-experiments-with-a-b-testing.md#terms)を追加し、各変数の既定値を定義します。</span><span class="sxs-lookup"><span data-stu-id="95f65-115">In the **Remote variables** section, add the [variables](run-app-experiments-with-a-b-testing.md#terms) that you want to be available to all experiments in this project, and define default values for each variable.</span></span> <span data-ttu-id="95f65-116">ここで指定した既定値は、実験のコントロール グループと、実験に参加していないすべてのユーザーに使われます。</span><span class="sxs-lookup"><span data-stu-id="95f65-116">The default values you specify here are used for the control group of the experiments, and for any users who do not participate in the experiment.</span></span>
  1. <span data-ttu-id="95f65-117">**[リモート変数]** セクションが折りたたまれている場合、セクション見出しの **[表示]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="95f65-117">If the **Remote variables** section is collapsed, click **Show** on the section heading.</span></span>
  2. <span data-ttu-id="95f65-118">**[変数の追加]** をクリックして、このプロジェクトのあらゆる実験で利用できるようにする新しい変数をそれぞれ作成し、変数の変数名と既定値を入力します。</span><span class="sxs-lookup"><span data-stu-id="95f65-118">Click **Add variable** to create each new variable that you want to be available to any experiment in this project, and type the variable name and the default value of the variable.</span></span>
  3. <span data-ttu-id="95f65-119">追加の変数が終わったら、**[保存]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="95f65-119">When you are done adding variables, click **Save**.</span></span>
3. <span data-ttu-id="95f65-120">**[SDK 統合]** セクションで、[プロジェクト ID](run-app-experiments-with-a-b-testing.md#terms) 値を書き留めます。</span><span class="sxs-lookup"><span data-stu-id="95f65-120">In the **SDK integration** section, make note of the [Project ID](run-app-experiments-with-a-b-testing.md#terms) value.</span></span> <span data-ttu-id="95f65-121">ときにする[実験用のアプリをコード](code-your-experiment-in-your-app.md)、バリエーションの 1 つのデータを受信し、パートナー センターに表示し、変換のイベントを報告できるように、コードでこのプロジェクトの ID を参照する必要があります。</span><span class="sxs-lookup"><span data-stu-id="95f65-121">When you [code your app for experimentation](code-your-experiment-in-your-app.md), you must reference this project ID in your code so you can receive variation data and report view and conversion events to Partner Center.</span></span>

> [!NOTE]
> <span data-ttu-id="95f65-122">プロジェクトの実験がアクティブなときに、リモート変数を編集、追加、削除することはできません。</span><span class="sxs-lookup"><span data-stu-id="95f65-122">You cannot edit, add, or remove remote variables while an experiment in the project is active.</span></span> <span data-ttu-id="95f65-123">この制限により、アクティブな実験のコントロール グループのデータの整合性を保護できます。</span><span class="sxs-lookup"><span data-stu-id="95f65-123">This limitation helps protect the integrity of the data for the control group for the active experiment.</span></span>


## <a name="next-steps"></a><span data-ttu-id="95f65-124">次のステップ</span><span class="sxs-lookup"><span data-stu-id="95f65-124">Next steps</span></span>

<span data-ttu-id="95f65-125">プロジェクトを作成すると、[アプリの実験用のコードを記述](code-your-experiment-in-your-app.md)して、アプリでリモートの変数値を取得し始めることができ、[プロジェクトで実験を作成](define-your-experiment-in-the-dev-center-dashboard.md)することができます。</span><span class="sxs-lookup"><span data-stu-id="95f65-125">After you create a project, you can [code your app for experimentation](code-your-experiment-in-your-app.md) to start retrieving remote variable values in your app, and you can [create an experiment in the project](define-your-experiment-in-the-dev-center-dashboard.md).</span></span>

## <a name="related-topics"></a><span data-ttu-id="95f65-126">関連トピック</span><span class="sxs-lookup"><span data-stu-id="95f65-126">Related topics</span></span>

* [<span data-ttu-id="95f65-127">実験用のアプリをコードします。</span><span class="sxs-lookup"><span data-stu-id="95f65-127">Code your app for experimentation</span></span>](code-your-experiment-in-your-app.md)
* [<span data-ttu-id="95f65-128">パートナー センターでの実験を定義します。</span><span class="sxs-lookup"><span data-stu-id="95f65-128">Define your experiment in Partner Center</span></span>](define-your-experiment-in-the-dev-center-dashboard.md)
* [<span data-ttu-id="95f65-129">パートナー センターで、実験を管理します。</span><span class="sxs-lookup"><span data-stu-id="95f65-129">Manage your experiment in Partner Center</span></span>](manage-your-experiment.md)
* [<span data-ttu-id="95f65-130">作成し、A で初めての実験を実行する B のテスト</span><span class="sxs-lookup"><span data-stu-id="95f65-130">Create and run your first experiment with A/B testing</span></span>](create-and-run-your-first-experiment-with-a-b-testing.md)
* [<span data-ttu-id="95f65-131">A とアプリの実験を実行する B のテスト</span><span class="sxs-lookup"><span data-stu-id="95f65-131">Run app experiments with A/B testing</span></span>](run-app-experiments-with-a-b-testing.md)
