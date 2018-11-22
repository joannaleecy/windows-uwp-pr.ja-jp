---
author: Xansky
Description: Before you can run an experiment in your Universal Windows Platform (UWP) app with A/B testing, you must create a project and define your remote variables in Partner Center.
title: パートナー センターで実験プロジェクトを作成する
ms.assetid: C3809FF1-0A6A-4715-B989-BE9D0E8C9013
ms.author: mhopkins
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10、UWP、Microsoft Store Services SDK、A/B テスト、実験
ms.localizationpriority: medium
ms.openlocfilehash: 19a59110fa094aeae3d40dca1372fde9889c108e
ms.sourcegitcommit: 93c0a60cf531c7d9fe7b00e7cf78df86906f9d6e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/21/2018
ms.locfileid: "7565500"
---
# <a name="create-an-experiment-project-in-partner-center"></a><span data-ttu-id="27e56-103">パートナー センターで実験プロジェクトを作成する</span><span class="sxs-lookup"><span data-stu-id="27e56-103">Create an experiment project in Partner Center</span></span>

<span data-ttu-id="27e56-104">実験を最初に、パートナー センターで、アプリの実験[プロジェクト](run-app-experiments-with-a-b-testing.md#terms)を作成し、アプリがアクセスできるリモート変数を定義します。</span><span class="sxs-lookup"><span data-stu-id="27e56-104">To get started with experimentation, create an experimentation [project](run-app-experiments-with-a-b-testing.md#terms) for your app in Partner Center and define the remote variables that your app can access.</span></span>

<span data-ttu-id="27e56-105">次の手順では、プロジェクトを作成するための主な手順について説明します。</span><span class="sxs-lookup"><span data-stu-id="27e56-105">The following instructions describe the core steps to create a project.</span></span> <span data-ttu-id="27e56-106">プロジェクトの作成と実験の実行のプロセスについて詳しく示すチュートリアルについては、「[A/B テストを使用して最初の実験を作成および実行する](create-and-run-your-first-experiment-with-a-b-testing.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="27e56-106">For a detailed walkthrough that demonstrates the end-to-end process of creating a project and then running an experiment, see [Create and run your first experiment with A/B testing](create-and-run-your-first-experiment-with-a-b-testing.md).</span></span>

## <a name="instructions"></a><span data-ttu-id="27e56-107">手順</span><span class="sxs-lookup"><span data-stu-id="27e56-107">Instructions</span></span>

1. <span data-ttu-id="27e56-108">[パートナー センター](https://partner.microsoft.com/dashboard)にサインインします。</span><span class="sxs-lookup"><span data-stu-id="27e56-108">Sign in to [Partner Center](https://partner.microsoft.com/dashboard).</span></span>
2. <span data-ttu-id="27e56-109">**[アプリ]** で、実験を作成するアプリを選択します。</span><span class="sxs-lookup"><span data-stu-id="27e56-109">Under **Your apps**, select the app for which you want to create an experiment.</span></span>
3. <span data-ttu-id="27e56-110">ナビゲーション ウィンドウで、**[Services]** を選択し、**[Experimentation]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="27e56-110">In the navigation pane, select **Services** and then select **Experimentation**.</span></span>
4. <span data-ttu-id="27e56-111">**[Experimentation]** ページで、**[プロジェクト]** セクション **[新しいプロジェクト]** ボタンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="27e56-111">On the **Experimentation** page, click the **New project** button in the **Projects** section.</span></span> <span data-ttu-id="27e56-112">1 つ以上のプロジェクトを既に作成している場合、それらのプロジェクトが **[プロジェクト]** セクションに表示されます。</span><span class="sxs-lookup"><span data-stu-id="27e56-112">If you have already created one or more projects, those projects are listed in the **Projects** section.</span></span>
5. <span data-ttu-id="27e56-113">**[新しいプロジェクト]** ページで、新しいプロジェクトの名前を入力します。</span><span class="sxs-lookup"><span data-stu-id="27e56-113">In the **New project** page, enter a name for your new project.</span></span>
6. <span data-ttu-id="27e56-114">**[リモート変数]** セクションで、このプロジェクトのすべての実験で利用できるようにする[変数](run-app-experiments-with-a-b-testing.md#terms)を追加し、各変数の既定値を定義します。</span><span class="sxs-lookup"><span data-stu-id="27e56-114">In the **Remote variables** section, add the [variables](run-app-experiments-with-a-b-testing.md#terms) that you want to be available to all experiments in this project, and define default values for each variable.</span></span> <span data-ttu-id="27e56-115">ここで指定した既定値は、実験のコントロール グループと、実験に参加していないすべてのユーザーに使われます。</span><span class="sxs-lookup"><span data-stu-id="27e56-115">The default values you specify here are used for the control group of the experiments, and for any users who do not participate in the experiment.</span></span>
  1. <span data-ttu-id="27e56-116">**[リモート変数]** セクションが折りたたまれている場合、セクション見出しの **[表示]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="27e56-116">If the **Remote variables** section is collapsed, click **Show** on the section heading.</span></span>
  2. <span data-ttu-id="27e56-117">**[変数の追加]** をクリックして、このプロジェクトのあらゆる実験で利用できるようにする新しい変数をそれぞれ作成し、変数の変数名と既定値を入力します。</span><span class="sxs-lookup"><span data-stu-id="27e56-117">Click **Add variable** to create each new variable that you want to be available to any experiment in this project, and type the variable name and the default value of the variable.</span></span>
  3. <span data-ttu-id="27e56-118">追加の変数が終わったら、**[保存]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="27e56-118">When you are done adding variables, click **Save**.</span></span>
3. <span data-ttu-id="27e56-119">**[SDK 統合]** セクションで、[プロジェクト ID](run-app-experiments-with-a-b-testing.md#terms) 値を書き留めます。</span><span class="sxs-lookup"><span data-stu-id="27e56-119">In the **SDK integration** section, make note of the [Project ID](run-app-experiments-with-a-b-testing.md#terms) value.</span></span> <span data-ttu-id="27e56-120">[実験用のアプリのコード](code-your-experiment-in-your-app.md)を参照するときする必要がありますこのプロジェクト ID コードでバリエーション データを受信し、パートナー センターにビュー イベントとコンバージョン イベントを報告できます。</span><span class="sxs-lookup"><span data-stu-id="27e56-120">When you [code your app for experimentation](code-your-experiment-in-your-app.md), you must reference this project ID in your code so you can receive variation data and report view and conversion events to Partner Center.</span></span>

> [!NOTE]
> <span data-ttu-id="27e56-121">プロジェクトの実験がアクティブなときに、リモート変数を編集、追加、削除することはできません。</span><span class="sxs-lookup"><span data-stu-id="27e56-121">You cannot edit, add, or remove remote variables while an experiment in the project is active.</span></span> <span data-ttu-id="27e56-122">この制限により、アクティブな実験のコントロール グループのデータの整合性を保護できます。</span><span class="sxs-lookup"><span data-stu-id="27e56-122">This limitation helps protect the integrity of the data for the control group for the active experiment.</span></span>


## <a name="next-steps"></a><span data-ttu-id="27e56-123">次の手順</span><span class="sxs-lookup"><span data-stu-id="27e56-123">Next steps</span></span>

<span data-ttu-id="27e56-124">プロジェクトを作成すると、[アプリの実験用のコードを記述](code-your-experiment-in-your-app.md)して、アプリでリモートの変数値を取得し始めることができ、[プロジェクトで実験を作成](define-your-experiment-in-the-dev-center-dashboard.md)することができます。</span><span class="sxs-lookup"><span data-stu-id="27e56-124">After you create a project, you can [code your app for experimentation](code-your-experiment-in-your-app.md) to start retrieving remote variable values in your app, and you can [create an experiment in the project](define-your-experiment-in-the-dev-center-dashboard.md).</span></span>

## <a name="related-topics"></a><span data-ttu-id="27e56-125">関連トピック</span><span class="sxs-lookup"><span data-stu-id="27e56-125">Related topics</span></span>

* [<span data-ttu-id="27e56-126">アプリの実験用のコードを記述する</span><span class="sxs-lookup"><span data-stu-id="27e56-126">Code your app for experimentation</span></span>](code-your-experiment-in-your-app.md)
* [<span data-ttu-id="27e56-127">パートナー センターで実験を定義する</span><span class="sxs-lookup"><span data-stu-id="27e56-127">Define your experiment in Partner Center</span></span>](define-your-experiment-in-the-dev-center-dashboard.md)
* [<span data-ttu-id="27e56-128">パートナー センターで実験を管理する</span><span class="sxs-lookup"><span data-stu-id="27e56-128">Manage your experiment in Partner Center</span></span>](manage-your-experiment.md)
* [<span data-ttu-id="27e56-129">A/B テストを使用して最初の実験を作成および実行する</span><span class="sxs-lookup"><span data-stu-id="27e56-129">Create and run your first experiment with A/B testing</span></span>](create-and-run-your-first-experiment-with-a-b-testing.md)
* [<span data-ttu-id="27e56-130">A/B テストを使用してアプリの実験を実行する</span><span class="sxs-lookup"><span data-stu-id="27e56-130">Run app experiments with A/B testing</span></span>](run-app-experiments-with-a-b-testing.md)
