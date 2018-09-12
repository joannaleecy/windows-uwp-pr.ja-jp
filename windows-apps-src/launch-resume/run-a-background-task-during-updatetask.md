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
ms.sourcegitcommit: 2a63ee6770413bc35ace09b14f56b60007be7433
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3931284"
---
# <a name="run-a-background-task-when-your-uwp-app-is-updated"></a><span data-ttu-id="9121a-104">UWP アプリが更新された際のバックグラウンド タスクの実行</span><span class="sxs-lookup"><span data-stu-id="9121a-104">Run a background task when your UWP app is updated</span></span>

<span data-ttu-id="9121a-105">ユニバーサル Windows プラットフォーム (UWP) ストアのアプリが更新された後に実行するバック グラウンド タスクを記述する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="9121a-105">Learn how to write a background task that runs after your Universal Windows Platform (UWP) store app is updated.</span></span>

<span data-ttu-id="9121a-106">タスクの更新のバック グラウンド タスクは、ユーザーがデバイスにインストールされているアプリケーションに更新プログラムをインストールした後、オペレーティング システムによって呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="9121a-106">The Update Task background task is invoked by the operating system after the user installs an update to an app that is installed on the device.</span></span> <span data-ttu-id="9121a-107">これにより、ユーザーが更新されたアプリを起動する前に、データベース スキーマというようの更新、新しいプッシュ通知チャネルを初期化する初期化タスクを実行するアプリケーションです。</span><span class="sxs-lookup"><span data-stu-id="9121a-107">This allows your app to perform initialization tasks such as initializing a new push notification channel, updating database schema, and so on, before the user launches your updated app.</span></span>

<span data-ttu-id="9121a-108">更新タスク場合アプリに少なくとも 1 回前に実行する、**を有効にするバック グラウンド タスクを登録するために更新されますので、 [ServicingComplete](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Background.SystemTriggerType)のトリガーを使用してバック グラウンド タスクを起動するとは異なるServicingComplete**トリガーします。</span><span class="sxs-lookup"><span data-stu-id="9121a-108">The Update Task differs from launching a background task using the [ServicingComplete](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Background.SystemTriggerType) trigger because in that case your app must run at least once before it is updated in order to register the background task that will be activated by the **ServicingComplete** trigger.</span></span>  <span data-ttu-id="9121a-109">更新タスクが登録されていません、アプリケーションが実行されていないが、アップグレードするがまだ更新タスクがトリガーされるのです。</span><span class="sxs-lookup"><span data-stu-id="9121a-109">The Update Task isn't registered and so an app that has never been run, but that is upgraded, will still have its update task triggered.</span></span>

## <a name="step-1-create-the-background-task-class"></a><span data-ttu-id="9121a-110">ステップ 1: バック グラウンド タスク クラスを作成します。</span><span class="sxs-lookup"><span data-stu-id="9121a-110">Step 1: Create the background task class</span></span>

<span data-ttu-id="9121a-111">として他の種類のバック グラウンド タスクを実装するタスクの更新プログラムのバック グラウンド タスク Windows ランタイム コンポーネントとして。</span><span class="sxs-lookup"><span data-stu-id="9121a-111">As with other types of background tasks, you implement the Update Task background task as a Windows Runtime component.</span></span> <span data-ttu-id="9121a-112">このコンポーネントを作成するのには、**バック グラウンド タスク クラスを作成する**のセクション[を作成してプロセス外のバック グラウンド タスクの登録](https://docs.microsoft.com/windows/uwp/launch-resume/create-and-register-a-background-task)で、手順を実行します。</span><span class="sxs-lookup"><span data-stu-id="9121a-112">To create this component, follow the steps in the **Create the Background Task class** section of [Create and register an out-of-process background task](https://docs.microsoft.com/windows/uwp/launch-resume/create-and-register-a-background-task).</span></span> <span data-ttu-id="9121a-113">手順は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="9121a-113">The steps include:</span></span>

- <span data-ttu-id="9121a-114">Windows ランタイム コンポーネント プロジェクトをソリューションに追加します。</span><span class="sxs-lookup"><span data-stu-id="9121a-114">Adding a Windows Runtime Component project to your solution.</span></span>
- <span data-ttu-id="9121a-115">アプリからコンポーネントへの参照を作成しています。</span><span class="sxs-lookup"><span data-stu-id="9121a-115">Creating a reference from your app to the component.</span></span>
- <span data-ttu-id="9121a-116">コンポーネントで公開、シール クラスを作成するには、 [**IBackgroundTask**](https://msdn.microsoft.com/library/windows/apps/br224794)が実装されています。</span><span class="sxs-lookup"><span data-stu-id="9121a-116">Creating a public, sealed class in the component that implements [**IBackgroundTask**](https://msdn.microsoft.com/library/windows/apps/br224794).</span></span>
- <span data-ttu-id="9121a-117">更新タスクの実行時に呼び出される必要なエントリ ポイントは、 [**Run**](https://msdn.microsoft.com/library/windows/apps/br224811)メソッドを実装します。</span><span class="sxs-lookup"><span data-stu-id="9121a-117">Implementing the [**Run**](https://msdn.microsoft.com/library/windows/apps/br224811) method, which is the required entry point that is called when the Update Task is run.</span></span> <span data-ttu-id="9121a-118">バック グラウンド タスクからの非同期の呼び出しを行う場合は、[レジスタ、アウト プロセスのバック グラウンド タスクを作成および](https://docs.microsoft.com/windows/uwp/launch-resume/create-and-register-a-background-task)**実行**メソッドで、遅延を使用する方法を説明します。</span><span class="sxs-lookup"><span data-stu-id="9121a-118">If you are going to make asynchronous calls from your background task, [Create and register an out-of-process background task](https://docs.microsoft.com/windows/uwp/launch-resume/create-and-register-a-background-task) explains how to use a deferral in your **Run** method.</span></span>

<span data-ttu-id="9121a-119">更新タスクを使用して、このバック グラウンド タスク ("を実行するバック グラウンド タスクを登録する] のセクション**を作成および登録、アウト プロセスのバック グラウンド タスク**のトピックで) を登録する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="9121a-119">You don't need to register this background task (the "Register the background task to run" section in the **Create and register an out-of-process background task** topic) to use the Update Task.</span></span> <span data-ttu-id="9121a-120">これは、タスクを登録するのにはアプリケーションにコードを追加する必要はありませんし、バック グラウンド タスクを登録するのには更新される前に 1 回以上実行するアプリケーションがないため、更新タスクを使用する主な理由です。</span><span class="sxs-lookup"><span data-stu-id="9121a-120">This is the main reason to use an Update Task because you don't need to add any code to your app to register the task and the app doesn't have to at least run once before being updated to register the background task.</span></span>

<span data-ttu-id="9121a-121">次のサンプル コードは、C# でタスクの更新プログラムのバック グラウンド タスク クラスの基本的な開始点を示しています。</span><span class="sxs-lookup"><span data-stu-id="9121a-121">The following sample code shows a basic starting point for a Update Task background task class in C#.</span></span> <span data-ttu-id="9121a-122">バック グラウンド タスク クラス自体とバック グラウンド タスク プロジェクト内の他のすべてのクラスは、**パブリック**と**シール**する必要があります。</span><span class="sxs-lookup"><span data-stu-id="9121a-122">The background task class itself - and all other classes in the background task project - need to be **public** and **sealed**.</span></span> <span data-ttu-id="9121a-123">バック グラウンド タスク クラスは、 **IBackgroundTask**から派生し、次に示すシグネチャを持つパブリック**Run()** メソッドがある必要があります。</span><span class="sxs-lookup"><span data-stu-id="9121a-123">Your background task class must derive from **IBackgroundTask** and have a public **Run()** method with the signature shown below:</span></span>

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

## <a name="step-2-declare-your-background-task-in-the-package-manifest"></a><span data-ttu-id="9121a-124">手順 2: パッケージ マニフェストでバック グラウンド タスクを宣言します。</span><span class="sxs-lookup"><span data-stu-id="9121a-124">Step 2: Declare your background task in the package manifest</span></span>

<span data-ttu-id="9121a-125">Visual Studio のソリューション エクスプ ローラーで**Package.appxmanifest**を右クリックし、パッケージ マニフェストを表示するのには**コードの表示**] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="9121a-125">In the Visual Studio Solution Explorer, right-click **Package.appxmanifest** and click **View Code** to view the package manifest.</span></span> <span data-ttu-id="9121a-126">次の追加`<Extensions>`の更新タスクを宣言する XML。</span><span class="sxs-lookup"><span data-stu-id="9121a-126">Add the following `<Extensions>` XML to declare your update task:</span></span>

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

<span data-ttu-id="9121a-127">上記の xml では、確実に、 `EntryPoint` namespace.class クラスの名前、更新作業に属性を設定します。</span><span class="sxs-lookup"><span data-stu-id="9121a-127">In the XML above, ensure that the `EntryPoint` attribute is set to the namespace.class name of your update task class.</span></span> <span data-ttu-id="9121a-128">名前は、大文字小文字を区別します。</span><span class="sxs-lookup"><span data-stu-id="9121a-128">The name is case-sensitive.</span></span>

## <a name="step-3-debugtest-your-update-task"></a><span data-ttu-id="9121a-129">手順 3: デバッグとテストの更新タスク</span><span class="sxs-lookup"><span data-stu-id="9121a-129">Step 3: Debug/test your Update task</span></span>

<span data-ttu-id="9121a-130">配布したアプリのコンピューターに更新するのには何かを使用する必要があるようにすることを確認します。</span><span class="sxs-lookup"><span data-stu-id="9121a-130">Ensure that you have deployed your app to your machine so that there is something to update.</span></span>

<span data-ttu-id="9121a-131">バック グラウンド タスクの Run() メソッドにブレークポイントを設定します。</span><span class="sxs-lookup"><span data-stu-id="9121a-131">Set a breakpoint in the Run() method of your background task.</span></span>

![セット ブレークポイント](images/run-func-breakpoint.png)

<span data-ttu-id="9121a-133">次に、ソリューション エクスプ ローラーでは、アプリのプロジェクト (バック グラウンド タスク プロジェクトではない) を右クリックし、[**プロパティ**] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="9121a-133">Next, in the solution explorer, right-click your app's project (not the background task project) and then click **Properties**.</span></span> <span data-ttu-id="9121a-134">アプリケーションのプロパティ] ウィンドウで、左側の [**デバッグ**] をクリックし **、起動しないが、起動時にコードをデバッグする**を選択します。</span><span class="sxs-lookup"><span data-stu-id="9121a-134">In the application Properties window, click **Debug** on the left, then select **Do not launch, but debug my code when it starts**:</span></span>

![デバッグを設定します。](images/do-not-launch-but-debug.png)

<span data-ttu-id="9121a-136">次に、UpdateTask を発生させることを確認するには、パッケージのバージョン番号を増加します。</span><span class="sxs-lookup"><span data-stu-id="9121a-136">Next, to ensure that the UpdateTask is triggered, increase the package's version number.</span></span> <span data-ttu-id="9121a-137">ソリューション エクスプ ローラーで、パッケージ デザイナーを開き、アプリの**Package.appxmanifest**ファイルをダブルクリックして、**ビルド**番号を更新し。</span><span class="sxs-lookup"><span data-stu-id="9121a-137">In the Solution Explorer, double-click your app's **Package.appxmanifest** file to open the package designer, and then update the **Build** number:</span></span>

![バージョンを更新します。](images/bump-version.png)

<span data-ttu-id="9121a-139">2017 を Visual Studio で f5 キーを押すと、アプリ更新され、システムがバック グラウンドで UpdateTask コンポーネントをアクティブにします。</span><span class="sxs-lookup"><span data-stu-id="9121a-139">Now, in Visual Studio 2017 when you press F5, your app will be updated and the system will activate your UpdateTask component in the background.</span></span> <span data-ttu-id="9121a-140">デバッガーはバック グラウンド プロセスに自動的にアタッチします。</span><span class="sxs-lookup"><span data-stu-id="9121a-140">The debugger will automatically attach to the background process.</span></span> <span data-ttu-id="9121a-141">ブレークポイントはヒットを取得し、更新プログラムのコードのロジックをステップ実行することができます。</span><span class="sxs-lookup"><span data-stu-id="9121a-141">Your breakpoint will get hit and you can step through your update code logic.</span></span>

<span data-ttu-id="9121a-142">バック グラウンド タスクが完了すると、同じデバッグ セッション内で Windows の [スタート] メニューから、フォア グラウンド アプリケーションを起動できます。</span><span class="sxs-lookup"><span data-stu-id="9121a-142">When the background task completes, you can launch the foreground app from the Windows start menu within the same debug session.</span></span> <span data-ttu-id="9121a-143">デバッガーが自動的に再試行を添付する、フォア グラウンドのプロセスには、この時間と、アプリケーションのロジックをステップ実行することができます。</span><span class="sxs-lookup"><span data-stu-id="9121a-143">The debugger will again automatically attach, this time to your foreground process, and you can step through your app's logic.</span></span>

> [!NOTE]
> <span data-ttu-id="9121a-144">2015年の Visual Studio のユーザー: 上記の手順は、Visual Studio の 2017 に適用します。</span><span class="sxs-lookup"><span data-stu-id="9121a-144">Visual Studio 2015 users: The above steps apply to Visual Studio 2017.</span></span> <span data-ttu-id="9121a-145">2015 の Visual Studio を使用する場合は、トリガーをテストは、Visual Studio 以外の UpdateTask を添付しませんと同じ手法を使用できます。</span><span class="sxs-lookup"><span data-stu-id="9121a-145">If you are using Visual Studio 2015, you can use the same techniques to trigger and test the UpdateTask, except Visual Studio will not attach to it.</span></span> <span data-ttu-id="9121a-146">VS 2015 で別のプロシージャでは、そのエントリ ポイントとして、UpdateTask を設定する[ApplicationTrigger](https://docs.microsoft.com/windows/uwp/launch-resume/trigger-background-task-from-app)をセットアップし、フォア グラウンド アプリケーションから直接実行をトリガーします。</span><span class="sxs-lookup"><span data-stu-id="9121a-146">An alternative procedure in VS 2015 is to setup an [ApplicationTrigger](https://docs.microsoft.com/windows/uwp/launch-resume/trigger-background-task-from-app) that sets the UpdateTask as its Entry Point, and trigger the execution directly from the foreground app.</span></span>

## <a name="see-also"></a><span data-ttu-id="9121a-147">関連項目</span><span class="sxs-lookup"><span data-stu-id="9121a-147">See also</span></span>

[<span data-ttu-id="9121a-148">アウトプロセス バックグラウンド タスクの作成と登録</span><span class="sxs-lookup"><span data-stu-id="9121a-148">Create and register an out-of-process background task</span></span>](https://docs.microsoft.com/windows/uwp/launch-resume/create-and-register-a-background-task)
