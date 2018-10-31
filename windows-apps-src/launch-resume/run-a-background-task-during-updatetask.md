---
author: TylerMSFT
title: UWP アプリが更新された際のバックグラウンド タスクの実行
description: ユニバーサル Windows プラットフォーム (UWP) アプリが更新された際に実行されるバックグラウンド タスクの作成方法を説明します。
ms.author: twhitney
ms.date: 04/21/2017
ms.topic: article
keywords: windows 10, uwp, 更新, バック グラウンド タスク、updatetask, バック グラウンド タスク
ms.localizationpriority: medium
ms.openlocfilehash: 1ef6351bcf2ef57a1900c429ddcb65e5a2a4e67b
ms.sourcegitcommit: ca96031debe1e76d4501621a7680079244ef1c60
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/30/2018
ms.locfileid: "5836506"
---
# <a name="run-a-background-task-when-your-uwp-app-is-updated"></a><span data-ttu-id="e4068-104">UWP アプリが更新された際のバックグラウンド タスクの実行</span><span class="sxs-lookup"><span data-stu-id="e4068-104">Run a background task when your UWP app is updated</span></span>

<span data-ttu-id="e4068-105">ユニバーサル Windows プラットフォーム (UWP) アプリが更新された後に実行されるバック グラウンド タスクを作成する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="e4068-105">Learn how to write a background task that runs after your Universal Windows Platform (UWP) store app is updated.</span></span>

<span data-ttu-id="e4068-106">ユーザーがデバイスにインストールされているアプリに更新プログラムをインストールした後、オペレーティング システムによって更新タスクのバック グラウンド タスクが呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="e4068-106">The Update Task background task is invoked by the operating system after the user installs an update to an app that is installed on the device.</span></span> <span data-ttu-id="e4068-107">これにより、ユーザーが、更新されたアプリを起動する前に、データベース スキーマの更新、新しいプッシュ通知チャネルを初期化などの初期化タスクを実行するアプリです。</span><span class="sxs-lookup"><span data-stu-id="e4068-107">This allows your app to perform initialization tasks such as initializing a new push notification channel, updating database schema, and so on, before the user launches your updated app.</span></span>

<span data-ttu-id="e4068-108">更新タスクとは異なります[ServicingComplete](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Background.SystemTriggerType)トリガーを使用して、その場合は、アプリする必要があります実行するために少なくとも 1 回、**がアクティブ化されるバック グラウンド タスクを登録するために更新される前に、バック グラウンド タスクを起動します。ServicingComplete**トリガーします。</span><span class="sxs-lookup"><span data-stu-id="e4068-108">The Update Task differs from launching a background task using the [ServicingComplete](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Background.SystemTriggerType) trigger because in that case your app must run at least once before it is updated in order to register the background task that will be activated by the **ServicingComplete** trigger.</span></span>  <span data-ttu-id="e4068-109">更新タスクが登録されていないし、ためが実行されていないがをアップグレードすると、アプリがまだその更新タスクをトリガーします。</span><span class="sxs-lookup"><span data-stu-id="e4068-109">The Update Task isn't registered and so an app that has never been run, but that is upgraded, will still have its update task triggered.</span></span>

## <a name="step-1-create-the-background-task-class"></a><span data-ttu-id="e4068-110">手順 1: バック グラウンド タスク クラスを作成します。</span><span class="sxs-lookup"><span data-stu-id="e4068-110">Step 1: Create the background task class</span></span>

<span data-ttu-id="e4068-111">として他の種類のバック グラウンド タスクとして実装する更新タスクのバック グラウンド タスク、Windows ランタイム コンポーネントです。</span><span class="sxs-lookup"><span data-stu-id="e4068-111">As with other types of background tasks, you implement the Update Task background task as a Windows Runtime component.</span></span> <span data-ttu-id="e4068-112">このコンポーネントを作成するには、[作成と登録、アウト プロセス バック グラウンド タスク](https://docs.microsoft.com/windows/uwp/launch-resume/create-and-register-a-background-task)の**バック グラウンド タスク クラスを作成する**セクションの手順に従います。</span><span class="sxs-lookup"><span data-stu-id="e4068-112">To create this component, follow the steps in the **Create the Background Task class** section of [Create and register an out-of-process background task](https://docs.microsoft.com/windows/uwp/launch-resume/create-and-register-a-background-task).</span></span> <span data-ttu-id="e4068-113">手順は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="e4068-113">The steps include:</span></span>

- <span data-ttu-id="e4068-114">Windows ランタイム コンポーネント プロジェクトをソリューションに追加します。</span><span class="sxs-lookup"><span data-stu-id="e4068-114">Adding a Windows Runtime Component project to your solution.</span></span>
- <span data-ttu-id="e4068-115">アプリからコンポーネントへの参照を作成します。</span><span class="sxs-lookup"><span data-stu-id="e4068-115">Creating a reference from your app to the component.</span></span>
- <span data-ttu-id="e4068-116">[**IBackgroundTask**](https://msdn.microsoft.com/library/windows/apps/br224794)を実装するコンポーネントのパブリック、シール クラスを作成します。</span><span class="sxs-lookup"><span data-stu-id="e4068-116">Creating a public, sealed class in the component that implements [**IBackgroundTask**](https://msdn.microsoft.com/library/windows/apps/br224794).</span></span>
- <span data-ttu-id="e4068-117">更新タスクの実行時に呼び出される必須のエントリ ポイントは、 [**Run**](https://msdn.microsoft.com/library/windows/apps/br224811)メソッドを実装します。</span><span class="sxs-lookup"><span data-stu-id="e4068-117">Implementing the [**Run**](https://msdn.microsoft.com/library/windows/apps/br224811) method, which is the required entry point that is called when the Update Task is run.</span></span> <span data-ttu-id="e4068-118">バック グラウンド タスクからの非同期呼び出しを行う場合は[の作成と登録、アウト プロセス バック グラウンド タスク](https://docs.microsoft.com/windows/uwp/launch-resume/create-and-register-a-background-task)の**Run**メソッドで、保留を使用する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="e4068-118">If you are going to make asynchronous calls from your background task, [Create and register an out-of-process background task](https://docs.microsoft.com/windows/uwp/launch-resume/create-and-register-a-background-task) explains how to use a deferral in your **Run** method.</span></span>

<span data-ttu-id="e4068-119">更新プログラムのタスクを使用してこのバック グラウンド タスク (「を実行するバック グラウンド タスクの登録」のセクション**の作成と登録、アウト プロセス バック グラウンド タスク**のトピックで) を登録する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="e4068-119">You don't need to register this background task (the "Register the background task to run" section in the **Create and register an out-of-process background task** topic) to use the Update Task.</span></span> <span data-ttu-id="e4068-120">これは、タスクを登録するアプリにコードを追加する必要はなく、アプリがバック グラウンド タスクを登録するように更新される前に 1 回以上実行するがないために、更新タスクを使用する主な理由です。</span><span class="sxs-lookup"><span data-stu-id="e4068-120">This is the main reason to use an Update Task because you don't need to add any code to your app to register the task and the app doesn't have to at least run once before being updated to register the background task.</span></span>

<span data-ttu-id="e4068-121">次のサンプル コードでは、c# で更新タスクのバック グラウンド タスク クラスの基本的な開始点を示します。</span><span class="sxs-lookup"><span data-stu-id="e4068-121">The following sample code shows a basic starting point for a Update Task background task class in C#.</span></span> <span data-ttu-id="e4068-122">バック グラウンド タスク クラス自体と、バック グラウンド タスク プロジェクトで他のすべてのクラスには、**パブリック**にして**シール**必要があります。</span><span class="sxs-lookup"><span data-stu-id="e4068-122">The background task class itself - and all other classes in the background task project - need to be **public** and **sealed**.</span></span> <span data-ttu-id="e4068-123">バック グラウンド タスク クラスでは、 **IBackgroundTask**から派生を次に示すシグネチャを持つパブリック**Run()** メソッドがある必要があります。</span><span class="sxs-lookup"><span data-stu-id="e4068-123">Your background task class must derive from **IBackgroundTask** and have a public **Run()** method with the signature shown below:</span></span>

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

## <a name="step-2-declare-your-background-task-in-the-package-manifest"></a><span data-ttu-id="e4068-124">手順 2: パッケージ マニフェストでバック グラウンド タスクを宣言します。</span><span class="sxs-lookup"><span data-stu-id="e4068-124">Step 2: Declare your background task in the package manifest</span></span>

<span data-ttu-id="e4068-125">Visual Studio のソリューション エクスプ ローラーで、 **Package.appxmanifest**を右クリックし、パッケージ マニフェストを表示する**コードの表示**] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="e4068-125">In the Visual Studio Solution Explorer, right-click **Package.appxmanifest** and click **View Code** to view the package manifest.</span></span> <span data-ttu-id="e4068-126">次の追加`<Extensions>`、更新プログラムのタスクを宣言する XML:</span><span class="sxs-lookup"><span data-stu-id="e4068-126">Add the following `<Extensions>` XML to declare your update task:</span></span>

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

<span data-ttu-id="e4068-127">上記の XML で、`EntryPoint`属性 namespace.class 更新タスク クラスの名前に設定します。</span><span class="sxs-lookup"><span data-stu-id="e4068-127">In the XML above, ensure that the `EntryPoint` attribute is set to the namespace.class name of your update task class.</span></span> <span data-ttu-id="e4068-128">名前が区別されます。</span><span class="sxs-lookup"><span data-stu-id="e4068-128">The name is case-sensitive.</span></span>

## <a name="step-3-debugtest-your-update-task"></a><span data-ttu-id="e4068-129">手順 3: デバッグ/テスト、更新タスク</span><span class="sxs-lookup"><span data-stu-id="e4068-129">Step 3: Debug/test your Update task</span></span>

<span data-ttu-id="e4068-130">展開したアプリをコンピューターに更新する必要があるようにを確認します。</span><span class="sxs-lookup"><span data-stu-id="e4068-130">Ensure that you have deployed your app to your machine so that there is something to update.</span></span>

<span data-ttu-id="e4068-131">バック グラウンド タスクの Run() メソッドにブレークポイントを設定します。</span><span class="sxs-lookup"><span data-stu-id="e4068-131">Set a breakpoint in the Run() method of your background task.</span></span>

![一連のブレークポイント](images/run-func-breakpoint.png)

<span data-ttu-id="e4068-133">次に、ソリューション エクスプ ローラーでは、アプリのプロジェクト (バック グラウンド タスク プロジェクトではない) を右クリックし、[**プロパティ**] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="e4068-133">Next, in the solution explorer, right-click your app's project (not the background task project) and then click **Properties**.</span></span> <span data-ttu-id="e4068-134">アプリケーションのプロパティ] ウィンドウで、左側で、[**デバッグ**] をクリックし、選択 **、起動しないが開始時にマイ コードをデバッグ**します。</span><span class="sxs-lookup"><span data-stu-id="e4068-134">In the application Properties window, click **Debug** on the left, then select **Do not launch, but debug my code when it starts**:</span></span>

![デバッグを設定します。](images/do-not-launch-but-debug.png)

<span data-ttu-id="e4068-136">次に、UpdateTask がトリガーされることを確認するには、パッケージのバージョン番号を大ききます。</span><span class="sxs-lookup"><span data-stu-id="e4068-136">Next, to ensure that the UpdateTask is triggered, increase the package's version number.</span></span> <span data-ttu-id="e4068-137">ソリューション エクスプ ローラーでは、パッケージ デザイナーを開き、アプリの**Package.appxmanifest**ファイルをダブルクリックして、し、**ビルド**番号を更新します。</span><span class="sxs-lookup"><span data-stu-id="e4068-137">In the Solution Explorer, double-click your app's **Package.appxmanifest** file to open the package designer, and then update the **Build** number:</span></span>

![バージョンを更新します。](images/bump-version.png)

<span data-ttu-id="e4068-139">これで、Visual Studio 2017 で f5 キーを押すと、アプリを更新し、システムがバック グラウンドで UpdateTask コンポーネントをアクティブ化します。</span><span class="sxs-lookup"><span data-stu-id="e4068-139">Now, in Visual Studio 2017 when you press F5, your app will be updated and the system will activate your UpdateTask component in the background.</span></span> <span data-ttu-id="e4068-140">デバッガーは、自動的にバック グラウンド プロセスにアタッチします。</span><span class="sxs-lookup"><span data-stu-id="e4068-140">The debugger will automatically attach to the background process.</span></span> <span data-ttu-id="e4068-141">ブレークポイントがヒットを取得して、更新コード ロジックをステップ実行することができます。</span><span class="sxs-lookup"><span data-stu-id="e4068-141">Your breakpoint will get hit and you can step through your update code logic.</span></span>

<span data-ttu-id="e4068-142">バック グラウンド タスクが完了したら、同じデバッグ セッションで Windows のスタート メニューからフォア グラウンド アプリを起動できます。</span><span class="sxs-lookup"><span data-stu-id="e4068-142">When the background task completes, you can launch the foreground app from the Windows start menu within the same debug session.</span></span> <span data-ttu-id="e4068-143">デバッガーはもう一度自動的にアタッチ、今度は、フォア グラウンド プロセスと、アプリのロジックをステップ実行することができます。</span><span class="sxs-lookup"><span data-stu-id="e4068-143">The debugger will again automatically attach, this time to your foreground process, and you can step through your app's logic.</span></span>

> [!NOTE]
> <span data-ttu-id="e4068-144">Visual Studio 2015 ユーザー: 上記の手順は、Visual Studio 2017 に適用します。</span><span class="sxs-lookup"><span data-stu-id="e4068-144">Visual Studio 2015 users: The above steps apply to Visual Studio 2017.</span></span> <span data-ttu-id="e4068-145">Visual Studio 2015 を使用している場合は、トリガーとそれに Visual Studio を除く、UpdateTask を添付しませんテストを同じ手法を使用することができます。</span><span class="sxs-lookup"><span data-stu-id="e4068-145">If you are using Visual Studio 2015, you can use the same techniques to trigger and test the UpdateTask, except Visual Studio will not attach to it.</span></span> <span data-ttu-id="e4068-146">VS 2015 の代替の手順のエントリ ポイントとして、UpdateTask を設定する[ApplicationTrigger](https://docs.microsoft.com/windows/uwp/launch-resume/trigger-background-task-from-app)をセットアップし、フォア グラウンド アプリから直接実行をトリガーすることです。</span><span class="sxs-lookup"><span data-stu-id="e4068-146">An alternative procedure in VS 2015 is to setup an [ApplicationTrigger](https://docs.microsoft.com/windows/uwp/launch-resume/trigger-background-task-from-app) that sets the UpdateTask as its Entry Point, and trigger the execution directly from the foreground app.</span></span>

## <a name="see-also"></a><span data-ttu-id="e4068-147">関連項目</span><span class="sxs-lookup"><span data-stu-id="e4068-147">See also</span></span>

[<span data-ttu-id="e4068-148">アウトプロセス バックグラウンド タスクの作成と登録</span><span class="sxs-lookup"><span data-stu-id="e4068-148">Create and register an out-of-process background task</span></span>](https://docs.microsoft.com/windows/uwp/launch-resume/create-and-register-a-background-task)
