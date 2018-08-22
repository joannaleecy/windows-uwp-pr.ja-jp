---
author: TylerMSFT
title: UWP アプリが更新された際のバックグラウンド タスクの実行
description: ユニバーサル Windows プラットフォーム (UWP) アプリが更新された際に実行されるバックグラウンド タスクの作成方法を説明します。
ms.author: twhitney
ms.date: 04/21/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10、uwp、更新、バック グラウンド タスク、updatetask、バック グラウンド タスク
ms.localizationpriority: medium
ms.openlocfilehash: fcba2cb736f86cebc6d2664e2ec3b557d47c86d7
ms.sourcegitcommit: f2f4820dd2026f1b47a2b1bf2bc89d7220a79c1a
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/22/2018
ms.locfileid: "2787064"
---
# <a name="run-a-background-task-when-your-uwp-app-is-updated"></a><span data-ttu-id="7ed04-104">UWP アプリが更新された際のバックグラウンド タスクの実行</span><span class="sxs-lookup"><span data-stu-id="7ed04-104">Run a background task when your UWP app is updated</span></span>

<span data-ttu-id="7ed04-105">どこからでも Windows プラットフォーム (UWP) ストア アプリの更新後に実行するバック グラウンド タスクを作成する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="7ed04-105">Learn how to write a background task that runs after your Universal Windows Platform (UWP) store app is updated.</span></span>

<span data-ttu-id="7ed04-106">ユーザーがデバイスにインストールされているアプリに、更新プログラムをインストールした後は、オペレーティング システムでタスクを更新するバック グラウンド タスクが呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="7ed04-106">The Update Task background task is invoked by the operating system after the user installs an update to an app that is installed on the device.</span></span> <span data-ttu-id="7ed04-107">これにより、アプリなど、データベース スキーマに更新すると、ユーザーが更新されたアプリを起動する前に、新しいプッシュ通知チャネルを初期化初期化タスクを実行できます。</span><span class="sxs-lookup"><span data-stu-id="7ed04-107">This allows your app to perform initialization tasks such as initializing a new push notification channel, updating database schema, and so on, before the user launches your updated app.</span></span>

<span data-ttu-id="7ed04-108">更新のタスクとは異なります、**をアクティブになるバック グラウンド タスクを登録するために更新される前に、アプリする必要があります少なくとも 1 回実行する場合は、 [ServicingComplete](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Background.SystemTriggerType)トリガーの使用をバック グラウンド タスクを起動します。ServicingComplete**トリガーします。</span><span class="sxs-lookup"><span data-stu-id="7ed04-108">The Update Task differs from launching a background task using the [ServicingComplete](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Background.SystemTriggerType) trigger because in that case your app must run at least once before it is updated in order to register the background task that will be activated by the **ServicingComplete** trigger.</span></span>  <span data-ttu-id="7ed04-109">更新するタスクが登録されていないし、ようにが実行されていないはをアップグレードすると、アプリでトリガーの更新プログラムのタスクがあります。</span><span class="sxs-lookup"><span data-stu-id="7ed04-109">The Update Task isn't registered and so an app that has never been run, but that is upgraded, will still have its update task triggered.</span></span>

## <a name="step-1-create-the-background-task-class"></a><span data-ttu-id="7ed04-110">手順 1: バック グラウンド タスク クラスを作成します。</span><span class="sxs-lookup"><span data-stu-id="7ed04-110">Step 1: Create the background task class</span></span>

<span data-ttu-id="7ed04-111">として他の種類のバック グラウンド タスクを実装するタスクの更新プログラムのバック グラウンド タスク Windows ランタイム コンポーネントとしてします。</span><span class="sxs-lookup"><span data-stu-id="7ed04-111">As with other types of background tasks, you implement the Update Task background task as a Windows Runtime component.</span></span> <span data-ttu-id="7ed04-112">このコンポーネントを作成するには、[登録、プロセスのバック グラウンド タスクを作成および](https://docs.microsoft.com/windows/uwp/launch-resume/create-and-register-a-background-task)の**バック グラウンド タスク クラスを作成する**セクションの手順に従います。</span><span class="sxs-lookup"><span data-stu-id="7ed04-112">To create this component, follow the steps in the **Create the Background Task class** section of [Create and register an out-of-process background task](https://docs.microsoft.com/windows/uwp/launch-resume/create-and-register-a-background-task).</span></span> <span data-ttu-id="7ed04-113">手順は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="7ed04-113">The steps include:</span></span>

- <span data-ttu-id="7ed04-114">Windows ランタイム コンポーネント プロジェクトのソリューションを追加します。</span><span class="sxs-lookup"><span data-stu-id="7ed04-114">Adding a Windows Runtime Component project to your solution.</span></span>
- <span data-ttu-id="7ed04-115">アプリからコンポーネントに参照を作成します。</span><span class="sxs-lookup"><span data-stu-id="7ed04-115">Creating a reference from your app to the component.</span></span>
- <span data-ttu-id="7ed04-116">コンポーネントの公開、シール クラスを作成するには、 [**IBackgroundTask**](https://msdn.microsoft.com/library/windows/apps/br224794)が実装されています。</span><span class="sxs-lookup"><span data-stu-id="7ed04-116">Creating a public, sealed class in the component that implements [**IBackgroundTask**](https://msdn.microsoft.com/library/windows/apps/br224794).</span></span>
- <span data-ttu-id="7ed04-117">[**実行**](https://msdn.microsoft.com/library/windows/apps/br224811)方法を実装するには、更新プログラムのタスクの実行時と呼ばれる必要なエントリ ポイントです。</span><span class="sxs-lookup"><span data-stu-id="7ed04-117">Implementing the [**Run**](https://msdn.microsoft.com/library/windows/apps/br224811) method, which is the required entry point that is called when the Update Task is run.</span></span> <span data-ttu-id="7ed04-118">場合は、バック グラウンド タスクから非同期の通話の発信する予定の場合は、 [register、プロセスのバック グラウンド タスクの作成と](https://docs.microsoft.com/windows/uwp/launch-resume/create-and-register-a-background-task)、**実行する**方法で、遅延を使用する方法を説明します。</span><span class="sxs-lookup"><span data-stu-id="7ed04-118">If you are going to make asynchronous calls from your background task, [Create and register an out-of-process background task](https://docs.microsoft.com/windows/uwp/launch-resume/create-and-register-a-background-task) explains how to use a deferral in your **Run** method.</span></span>

<span data-ttu-id="7ed04-119">更新プログラムのタスクを使用してこのバック グラウンド タスク (「登録バック グラウンド タスクを実行する」のセクション**を作成してプロセスのバック グラウンド タスクに登録する**トピックの「) を登録する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="7ed04-119">You don't need to register this background task (the "Register the background task to run" section in the **Create and register an out-of-process background task** topic) to use the Update Task.</span></span> <span data-ttu-id="7ed04-120">これは、タスクを登録するアプリにコードを追加する必要はありませんし、アプリがバック グラウンド タスクを登録する更新される前に、1 回以上を実行するために、更新するタスクを使用する主な理由です。</span><span class="sxs-lookup"><span data-stu-id="7ed04-120">This is the main reason to use an Update Task because you don't need to add any code to your app to register the task and the app doesn't have to at least run once before being updated to register the background task.</span></span>

<span data-ttu-id="7ed04-121">次のサンプル コードでは、c# で基本的なタスクの更新プログラムのバック グラウンド タスク クラスの開始点を示します。</span><span class="sxs-lookup"><span data-stu-id="7ed04-121">The following sample code shows a basic starting point for a Update Task background task class in C#.</span></span> <span data-ttu-id="7ed04-122">バック グラウンド タスク クラス自体とバック グラウンド タスクのプロジェクト内でその他のすべてのクラスは、**パブリック**と**シール**する必要があります。</span><span class="sxs-lookup"><span data-stu-id="7ed04-122">The background task class itself - and all other classes in the background task project - need to be **public** and **sealed**.</span></span> <span data-ttu-id="7ed04-123">バック グラウンド タスク クラスは、 **IBackgroundTask**から派生し、一般向けの**Run()** 方法を次に示す署名がある必要があります。</span><span class="sxs-lookup"><span data-stu-id="7ed04-123">Your background task class must derive from **IBackgroundTask** and have a public **Run()** method with the signature shown below:</span></span>

```cs
using Windows.ApplicationModel.Background;

namespace BackgroundTasks
{
    public sealed class UpdateTask : IBackgroundTask
    {
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            // your app migration/update code here
        }
    }
}
```

## <a name="step-2-declare-your-background-task-in-the-package-manifest"></a><span data-ttu-id="7ed04-124">手順 2: 背景のタスクのパッケージ マニフェストの宣言します。</span><span class="sxs-lookup"><span data-stu-id="7ed04-124">Step 2: Declare your background task in the package manifest</span></span>

<span data-ttu-id="7ed04-125">Visual Studio ソリューション エクスプ ローラーでは、 **Package.appxmanifest**を右クリックし、パッケージ マニフェストを表示するのには、**コードの表示**] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="7ed04-125">In the Visual Studio Solution Explorer, right-click **Package.appxmanifest** and click **View Code** to view the package manifest.</span></span> <span data-ttu-id="7ed04-126">次の追加`<Extensions>`XML、更新プログラムのタスクを宣言するのには。</span><span class="sxs-lookup"><span data-stu-id="7ed04-126">Add the following `<Extensions>` XML to declare your update task:</span></span>

```XML
<Package ...>
    ...
  <Applications>  
    <Application ...>  
        ...
      <Extensions>  
        <Extension Category="windows.updateTask"  EntryPoint="BackgroundTasks.UpdateTask">  
        </Extension>  
      </Extensions>

    </Application>  
  </Applications>  
</Package>
```

<span data-ttu-id="7ed04-127">上記の XML] で、`EntryPoint`属性が更新タスク クラスの namespace.class 名前に設定します。</span><span class="sxs-lookup"><span data-stu-id="7ed04-127">In the XML above, ensure that the `EntryPoint` attribute is set to the namespace.class name of your update task class.</span></span> <span data-ttu-id="7ed04-128">名前は区別されます。</span><span class="sxs-lookup"><span data-stu-id="7ed04-128">The name is case-sensitive.</span></span>

## <a name="step-3-debugtest-your-update-task"></a><span data-ttu-id="7ed04-129">手順 3: デバッグ/テスト更新タスク</span><span class="sxs-lookup"><span data-stu-id="7ed04-129">Step 3: Debug/test your Update task</span></span>

<span data-ttu-id="7ed04-130">展開した場合、アプリのコンピューターに更新する必要があることを確認します。</span><span class="sxs-lookup"><span data-stu-id="7ed04-130">Ensure that you have deployed your app to your machine so that there is something to update.</span></span>

<span data-ttu-id="7ed04-131">バック グラウンド タスクの Run() メソッドでブレークポイントを設定します。</span><span class="sxs-lookup"><span data-stu-id="7ed04-131">Set a breakpoint in the Run() method of your background task.</span></span>

![ブレークポイントを設定します。](images/run-func-breakpoint.png)

<span data-ttu-id="7ed04-133">次に、ソリューション エクスプ ローラーでは、アプリのプロジェクト (バック グラウンド タスク プロジェクトではない) を右クリックし、[**プロパティ**] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="7ed04-133">Next, in the solution explorer, right-click your app's project (not the background task project) and then click **Properties**.</span></span> <span data-ttu-id="7ed04-134">アプリケーションのプロパティ ウィンドウで、左側の [**デバッグ**] をクリックし、**起動時にコードをデバッグ起動しない]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="7ed04-134">In the application Properties window, click **Debug** on the left, then select **Do not launch, but debug my code when it starts**:</span></span>

![デバッグを設定します。](images/do-not-launch-but-debug.png)

<span data-ttu-id="7ed04-136">次に、UpdateTask が行われることを確認するには、パッケージのバージョンの数を増やします。</span><span class="sxs-lookup"><span data-stu-id="7ed04-136">Next, to ensure that the UpdateTask is triggered, increase the package's version number.</span></span> <span data-ttu-id="7ed04-137">ソリューション エクスプ ローラーでパッケージ デザイナーを開く、アプリの**Package.appxmanifest**ファイルをダブルクリックし、[**ビルド**番号を更新し、します。</span><span class="sxs-lookup"><span data-stu-id="7ed04-137">In the Solution Explorer, double-click your app's **Package.appxmanifest** file to open the package designer, and then update the **Build** number:</span></span>

![バージョンを更新します。](images/bump-version.png)

<span data-ttu-id="7ed04-139">これで、Visual Studio 2017 で f5 キーを押すと、アプリ更新され、システムがバック グラウンドで UpdateTask コンポーネントをアクティブにします。</span><span class="sxs-lookup"><span data-stu-id="7ed04-139">Now, in Visual Studio 2017 when you press F5, your app will be updated and the system will activate your UpdateTask component in the background.</span></span> <span data-ttu-id="7ed04-140">デバッガーは、バック グラウンド プロセスに自動的に添付されます。</span><span class="sxs-lookup"><span data-stu-id="7ed04-140">The debugger will automatically attach to the background process.</span></span> <span data-ttu-id="7ed04-141">ブレークポイントがヒットして、コード ロジックを更新する手順を実行できます。</span><span class="sxs-lookup"><span data-stu-id="7ed04-141">Your breakpoint will get hit and you can step through your update code logic.</span></span>

<span data-ttu-id="7ed04-142">バック グラウンド タスクが完了したらは、同じデバッグ セッション内で、Windows のスタート メニューから前景色アプリを起動することができます。</span><span class="sxs-lookup"><span data-stu-id="7ed04-142">When the background task completes, you can launch the foreground app from the Windows start menu within the same debug session.</span></span> <span data-ttu-id="7ed04-143">デバッガーが自動的にもう一度、添付、フォア グラウンド プロセスには、この時間と、アプリのロジック手順を実行できます。</span><span class="sxs-lookup"><span data-stu-id="7ed04-143">The debugger will again automatically attach, this time to your foreground process, and you can step through your app's logic.</span></span>

> [!NOTE]
> <span data-ttu-id="7ed04-144">Visual Studio 2015 ユーザー: 上記の手順は、Visual Studio 2017 に適用します。</span><span class="sxs-lookup"><span data-stu-id="7ed04-144">Visual Studio 2015 users: The above steps apply to Visual Studio 2017.</span></span> <span data-ttu-id="7ed04-145">Visual Studio 2015 を使用している場合は、トリガーをテストして添付しません Visual Studio を除く、UpdateTask と同じ方法を使用することができます。</span><span class="sxs-lookup"><span data-stu-id="7ed04-145">If you are using Visual Studio 2015, you can use the same techniques to trigger and test the UpdateTask, except Visual Studio will not attach to it.</span></span> <span data-ttu-id="7ed04-146">VS 2015 で手順は、エントリ ポイントでは、名前を付けて、UpdateTask を設定する[ApplicationTrigger](https://docs.microsoft.com/windows/uwp/launch-resume/trigger-background-task-from-app)をセットアップを開始する前景色アプリから直接実行です。</span><span class="sxs-lookup"><span data-stu-id="7ed04-146">An alternative procedure in VS 2015 is to setup an [ApplicationTrigger](https://docs.microsoft.com/windows/uwp/launch-resume/trigger-background-task-from-app) that sets the UpdateTask as its Entry Point, and trigger the execution directly from the foreground app.</span></span>

## <a name="see-also"></a><span data-ttu-id="7ed04-147">関連項目</span><span class="sxs-lookup"><span data-stu-id="7ed04-147">See also</span></span>

[<span data-ttu-id="7ed04-148">アウトプロセス バックグラウンド タスクの作成と登録</span><span class="sxs-lookup"><span data-stu-id="7ed04-148">Create and register an out-of-process background task</span></span>](https://docs.microsoft.com/windows/uwp/launch-resume/create-and-register-a-background-task)
