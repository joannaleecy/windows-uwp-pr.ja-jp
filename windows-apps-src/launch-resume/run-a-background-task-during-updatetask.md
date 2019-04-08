---
title: UWP アプリが更新された際のバックグラウンド タスクの実行
description: ユニバーサル Windows プラットフォーム (UWP) アプリが更新された際に実行されるバックグラウンド タスクの作成方法を説明します。
ms.date: 04/21/2017
ms.topic: article
keywords: windows 10、uwp、更新、バック グラウンド タスク、updatetask、バック グラウンド タスク
ms.localizationpriority: medium
ms.openlocfilehash: 8cd7d4494340d1c5e617361f2e3d750b35ebabb9
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57603527"
---
# <a name="run-a-background-task-when-your-uwp-app-is-updated"></a><span data-ttu-id="38d86-104">UWP アプリが更新された際のバックグラウンド タスクの実行</span><span class="sxs-lookup"><span data-stu-id="38d86-104">Run a background task when your UWP app is updated</span></span>

<span data-ttu-id="38d86-105">ユニバーサル Windows プラットフォーム (UWP) アプリが更新された後に実行されるバックグラウンド タスクの作成方法を説明します。</span><span class="sxs-lookup"><span data-stu-id="38d86-105">Learn how to write a background task that runs after your Universal Windows Platform (UWP) store app is updated.</span></span>

<span data-ttu-id="38d86-106">更新タスク バックグラウンド タスクは、ユーザーがデバイスにインストールされるアプリに更新プログラムをインストールした後、オペレーティング システムによって呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="38d86-106">The Update Task background task is invoked by the operating system after the user installs an update to an app that is installed on the device.</span></span> <span data-ttu-id="38d86-107">これによって、更新されたアプリをユーザーが起動する前に、アプリで新しいプッシュ通知チャネルの初期化やデータベース スキーマの更新などの初期化タスクを実行できます。</span><span class="sxs-lookup"><span data-stu-id="38d86-107">This allows your app to perform initialization tasks such as initializing a new push notification channel, updating database schema, and so on, before the user launches your updated app.</span></span>

<span data-ttu-id="38d86-108">更新タスクは、[ServicingComplete](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Background.SystemTriggerType) トリガーを使用してバックグラウンド タスクを起動することとは異なります。それは、トリガーを使用する場合、アプリが更新される前にアプリが少なくとも 1 回は実行されて、**ServicingComplete** トリガーによってアクティブ化されるバックグラウンド タスクが登録されている必要があるからです。</span><span class="sxs-lookup"><span data-stu-id="38d86-108">The Update Task differs from launching a background task using the [ServicingComplete](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Background.SystemTriggerType) trigger because in that case your app must run at least once before it is updated in order to register the background task that will be activated by the **ServicingComplete** trigger.</span></span>  <span data-ttu-id="38d86-109">更新タスクは登録されないので、1 回も実行されずにアップグレードされたアプリでも更新タスクはトリガーされます。</span><span class="sxs-lookup"><span data-stu-id="38d86-109">The Update Task isn't registered and so an app that has never been run, but that is upgraded, will still have its update task triggered.</span></span>

## <a name="step-1-create-the-background-task-class"></a><span data-ttu-id="38d86-110">手順 1:バック グラウンド タスク クラスを作成します。</span><span class="sxs-lookup"><span data-stu-id="38d86-110">Step 1: Create the background task class</span></span>

<span data-ttu-id="38d86-111">他の種類のバックグラウンド タスクの場合と同様に、Windows ランタイム コンポーネントとして更新タスク バックグラウンド タスクを実装します。</span><span class="sxs-lookup"><span data-stu-id="38d86-111">As with other types of background tasks, you implement the Update Task background task as a Windows Runtime component.</span></span> <span data-ttu-id="38d86-112">このコンポーネントを作成するには、「[アウトプロセス バックグラウンド タスクの作成と登録](https://docs.microsoft.com/windows/uwp/launch-resume/create-and-register-a-background-task)」の「**バックグラウンド タスク クラスを作る**」セクションの手順に従ってください。</span><span class="sxs-lookup"><span data-stu-id="38d86-112">To create this component, follow the steps in the **Create the Background Task class** section of [Create and register an out-of-process background task](https://docs.microsoft.com/windows/uwp/launch-resume/create-and-register-a-background-task).</span></span> <span data-ttu-id="38d86-113">次の手順を実行します。</span><span class="sxs-lookup"><span data-stu-id="38d86-113">The steps include:</span></span>

- <span data-ttu-id="38d86-114">ソリューションに Windows ランタイム コンポーネント プロジェクトを追加する。</span><span class="sxs-lookup"><span data-stu-id="38d86-114">Adding a Windows Runtime Component project to your solution.</span></span>
- <span data-ttu-id="38d86-115">アプリからコンポーネントへの参照を作成する。</span><span class="sxs-lookup"><span data-stu-id="38d86-115">Creating a reference from your app to the component.</span></span>
- <span data-ttu-id="38d86-116">[  **IBackgroundTask**](https://msdn.microsoft.com/library/windows/apps/br224794) を実装するコンポーネント内の public sealed クラスを作成する。</span><span class="sxs-lookup"><span data-stu-id="38d86-116">Creating a public, sealed class in the component that implements [**IBackgroundTask**](https://msdn.microsoft.com/library/windows/apps/br224794).</span></span>
- <span data-ttu-id="38d86-117">更新タスクの実行時に呼び出される必要なエントリ ポイントである [**Run**](https://msdn.microsoft.com/library/windows/apps/br224811) メソッドを実装する。</span><span class="sxs-lookup"><span data-stu-id="38d86-117">Implementing the [**Run**](https://msdn.microsoft.com/library/windows/apps/br224811) method, which is the required entry point that is called when the Update Task is run.</span></span> <span data-ttu-id="38d86-118">バックグラウンド タスクからの非同期呼び出しを作成する場合は、「[アウトプロセス バックグラウンド タスクの作成と登録](https://docs.microsoft.com/windows/uwp/launch-resume/create-and-register-a-background-task)」で **Run** メソッドでの遅延の使用方法を説明しています。</span><span class="sxs-lookup"><span data-stu-id="38d86-118">If you are going to make asynchronous calls from your background task, [Create and register an out-of-process background task](https://docs.microsoft.com/windows/uwp/launch-resume/create-and-register-a-background-task) explains how to use a deferral in your **Run** method.</span></span>

<span data-ttu-id="38d86-119">更新タスクを使用するうえで、このバックグラウンド タスクの登録 (**「アウトプロセス バックグラウンド タスクの作成と登録」** トピックの「実行するバックグラウンド タスクを登録する」セクション) は不要です。</span><span class="sxs-lookup"><span data-stu-id="38d86-119">You don't need to register this background task (the "Register the background task to run" section in the **Create and register an out-of-process background task** topic) to use the Update Task.</span></span> <span data-ttu-id="38d86-120">更新タスクを使用する主な理由は、タスクを登録するためにコードをアプリに追加する必要がないこと、およびアプリの更新前にアプリを少なくとも 1 回実行してバックグラウンド タスクを登録する必要がないことです。</span><span class="sxs-lookup"><span data-stu-id="38d86-120">This is the main reason to use an Update Task because you don't need to add any code to your app to register the task and the app doesn't have to at least run once before being updated to register the background task.</span></span>

<span data-ttu-id="38d86-121">次のサンプル コードは、C# の更新タスク バックグラウンド タスク クラスの基本的な開始点を示しています。</span><span class="sxs-lookup"><span data-stu-id="38d86-121">The following sample code shows a basic starting point for a Update Task background task class in C#.</span></span> <span data-ttu-id="38d86-122">バックグラウンド タスク クラス自体と、バックグラウンド タスク プロジェクト内のその他すべてのクラスは、**public\*\*\*\*sealed** クラスである必要があります。</span><span class="sxs-lookup"><span data-stu-id="38d86-122">The background task class itself - and all other classes in the background task project - need to be **public** and **sealed**.</span></span> <span data-ttu-id="38d86-123">バックグラウンド タスク クラスは **IBackgroundTask** から派生する必要があり、以下に示すシグネチャを持つパブリック **Run()** メソッドが含まれている必要があります。</span><span class="sxs-lookup"><span data-stu-id="38d86-123">Your background task class must derive from **IBackgroundTask** and have a public **Run()** method with the signature shown below:</span></span>

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

## <a name="step-2-declare-your-background-task-in-the-package-manifest"></a><span data-ttu-id="38d86-124">手順 2:パッケージ マニフェストに、バック グラウンド タスクを宣言します。</span><span class="sxs-lookup"><span data-stu-id="38d86-124">Step 2: Declare your background task in the package manifest</span></span>

<span data-ttu-id="38d86-125">Visual Studio のソリューション エクスプローラーで、**Package.appxmanifest** を右クリックし、**[コードの表示]** をクリックして、パッケージ マニフェストを表示します。</span><span class="sxs-lookup"><span data-stu-id="38d86-125">In the Visual Studio Solution Explorer, right-click **Package.appxmanifest** and click **View Code** to view the package manifest.</span></span> <span data-ttu-id="38d86-126">次の `<Extensions>` XML を追加して更新タスクを宣言します。</span><span class="sxs-lookup"><span data-stu-id="38d86-126">Add the following `<Extensions>` XML to declare your update task:</span></span>

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

<span data-ttu-id="38d86-127">上記の XML で、`EntryPoint` 属性が更新タスク クラスの <名前空間>.<クラス> 名となるように設定します。</span><span class="sxs-lookup"><span data-stu-id="38d86-127">In the XML above, ensure that the `EntryPoint` attribute is set to the namespace.class name of your update task class.</span></span> <span data-ttu-id="38d86-128">この名前では、大文字と小文字を区別します。</span><span class="sxs-lookup"><span data-stu-id="38d86-128">The name is case-sensitive.</span></span>

## <a name="step-3-debugtest-your-update-task"></a><span data-ttu-id="38d86-129">手順 3:デバッグ/テスト タスクの更新</span><span class="sxs-lookup"><span data-stu-id="38d86-129">Step 3: Debug/test your Update task</span></span>

<span data-ttu-id="38d86-130">アプリを PC に展開して、更新対象を用意します。</span><span class="sxs-lookup"><span data-stu-id="38d86-130">Ensure that you have deployed your app to your machine so that there is something to update.</span></span>

<span data-ttu-id="38d86-131">バックグラウンド タスクの Run() メソッドにブレークポイントを設定します。</span><span class="sxs-lookup"><span data-stu-id="38d86-131">Set a breakpoint in the Run() method of your background task.</span></span>

![ブレークポイントの設定](images/run-func-breakpoint.png)

<span data-ttu-id="38d86-133">次に、ソリューション エクスプローラーで、アプリのプロジェクト (バックグラウンド タスクのプロジェクトではない) を右クリックし、**[プロパティ]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="38d86-133">Next, in the solution explorer, right-click your app's project (not the background task project) and then click **Properties**.</span></span> <span data-ttu-id="38d86-134">アプリケーションの [プロパティ] ウィンドウで、左側の **[デバッグ]** をクリックし、**[起動しないが、開始時にコードをデバッグ]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="38d86-134">In the application Properties window, click **Debug** on the left, then select **Do not launch, but debug my code when it starts**:</span></span>

![デバッグ設定の設定](images/do-not-launch-but-debug.png)

<span data-ttu-id="38d86-136">次に、UpdateTask がトリガーされるように、パッケージのバージョン番号を増やします。</span><span class="sxs-lookup"><span data-stu-id="38d86-136">Next, to ensure that the UpdateTask is triggered, increase the package's version number.</span></span> <span data-ttu-id="38d86-137">ソリューション エクスプローラーで、アプリの **Package.appxmanifest** ファイルをダブルクリックして、パッケージ デザイナーを開き、**[ビルド]** 番号を更新します。</span><span class="sxs-lookup"><span data-stu-id="38d86-137">In the Solution Explorer, double-click your app's **Package.appxmanifest** file to open the package designer, and then update the **Build** number:</span></span>

![バージョンの更新](images/bump-version.png)

<span data-ttu-id="38d86-139">これで、Visual Studio 2017 で F5 キーを押すと、アプリが更新され、システムによってバックグラウンドで UpdateTask コンポーネントがアクティブ化されます。</span><span class="sxs-lookup"><span data-stu-id="38d86-139">Now, in Visual Studio 2017 when you press F5, your app will be updated and the system will activate your UpdateTask component in the background.</span></span> <span data-ttu-id="38d86-140">デバッガーは自動的にバックグラウンド プロセスにアタッチします。</span><span class="sxs-lookup"><span data-stu-id="38d86-140">The debugger will automatically attach to the background process.</span></span> <span data-ttu-id="38d86-141">ブレークポイントに到達すると、更新コード ロジックをステップ実行できます。</span><span class="sxs-lookup"><span data-stu-id="38d86-141">Your breakpoint will get hit and you can step through your update code logic.</span></span>

<span data-ttu-id="38d86-142">バックグラウンド タスクが完了したら、同じデバッグ セッション内で Windows のスタート メニューからフォアグラウンド アプリを起動できます。</span><span class="sxs-lookup"><span data-stu-id="38d86-142">When the background task completes, you can launch the foreground app from the Windows start menu within the same debug session.</span></span> <span data-ttu-id="38d86-143">デバッガーが今回はフォアグラウンド プロセスに自動的にアタッチし、アプリのロジックをステップ実行できます。</span><span class="sxs-lookup"><span data-stu-id="38d86-143">The debugger will again automatically attach, this time to your foreground process, and you can step through your app's logic.</span></span>

> [!NOTE]
> <span data-ttu-id="38d86-144">Visual Studio 2015 のユーザー:上記の手順は、Visual Studio 2017 に適用されます。</span><span class="sxs-lookup"><span data-stu-id="38d86-144">Visual Studio 2015 users: The above steps apply to Visual Studio 2017.</span></span> <span data-ttu-id="38d86-145">Visual Studio 2015 を使用している場合、同じ手法を使用して UpdateTask をトリガーしてテストできますが、Visual Studio によってデバッガーがアタッチされることはありません。</span><span class="sxs-lookup"><span data-stu-id="38d86-145">If you are using Visual Studio 2015, you can use the same techniques to trigger and test the UpdateTask, except Visual Studio will not attach to it.</span></span> <span data-ttu-id="38d86-146">VS 2015 での代替の手順は、UpdateTask をエントリ ポイントとして設定する [ApplicationTrigger](https://docs.microsoft.com/windows/uwp/launch-resume/trigger-background-task-from-app) をセットアップし、フォアグラウンド アプリから直接実行をトリガーすることです。</span><span class="sxs-lookup"><span data-stu-id="38d86-146">An alternative procedure in VS 2015 is to setup an [ApplicationTrigger](https://docs.microsoft.com/windows/uwp/launch-resume/trigger-background-task-from-app) that sets the UpdateTask as its Entry Point, and trigger the execution directly from the foreground app.</span></span>

## <a name="see-also"></a><span data-ttu-id="38d86-147">関連項目</span><span class="sxs-lookup"><span data-stu-id="38d86-147">See also</span></span>

[<span data-ttu-id="38d86-148">アウトプロセス バックグラウンド タスクの作成と登録</span><span class="sxs-lookup"><span data-stu-id="38d86-148">Create and register an out-of-process background task</span></span>](https://docs.microsoft.com/windows/uwp/launch-resume/create-and-register-a-background-task)
