---
author: TylerMSFT
title: バックグラウンド タスクの登録
description: ほとんどのバックグラウンド タスクを安全に登録できる再利用可能な関数の作成方法について説明します。
ms.assetid: 8B1CADC5-F630-48B8-B3CE-5AB62E3DFB0D
ms.author: twhitney
ms.date: 02/08/2017
ms.topic: article
keywords: バック グラウンド タスクの windows 10, uwp,
ms.localizationpriority: medium
ms.openlocfilehash: faed3f762594ae46b617831615df2448391e1c7d
ms.sourcegitcommit: 38f06f1714334273d865935d9afb80efffe97a17
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/09/2018
ms.locfileid: "6202494"
---
# <a name="register-a-background-task"></a><span data-ttu-id="9d08a-104">バックグラウンド タスクの登録</span><span class="sxs-lookup"><span data-stu-id="9d08a-104">Register a background task</span></span>


**<span data-ttu-id="9d08a-105">重要な API</span><span class="sxs-lookup"><span data-stu-id="9d08a-105">Important APIs</span></span>**

-   [**<span data-ttu-id="9d08a-106">BackgroundTaskRegistration クラス</span><span class="sxs-lookup"><span data-stu-id="9d08a-106">BackgroundTaskRegistration class</span></span>**](https://msdn.microsoft.com/library/windows/apps/br224786)
-   [**<span data-ttu-id="9d08a-107">BackgroundTaskBuilder クラス</span><span class="sxs-lookup"><span data-stu-id="9d08a-107">BackgroundTaskBuilder class</span></span>**](https://msdn.microsoft.com/library/windows/apps/br224768)
-   [**<span data-ttu-id="9d08a-108">SystemCondition クラス</span><span class="sxs-lookup"><span data-stu-id="9d08a-108">SystemCondition class</span></span>**](https://msdn.microsoft.com/library/windows/apps/br224834)

<span data-ttu-id="9d08a-109">ほとんどのバックグラウンド タスクを安全に登録できる再利用可能な関数の作成方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="9d08a-109">Learn how to create a function that can be re-used to safely register most background tasks.</span></span>

<span data-ttu-id="9d08a-110">このトピックは、インプロセスのバックグラウンド タスクとアウトプロセスのバックグラウンド タスクの両方に適用されます。</span><span class="sxs-lookup"><span data-stu-id="9d08a-110">This topic is applicable to both in-process background tasks and out-of-process background tasks.</span></span> <span data-ttu-id="9d08a-111">このトピックの説明では、登録する必要があるバックグラウンド タスクが既に存在すると想定します。</span><span class="sxs-lookup"><span data-stu-id="9d08a-111">This topic assumes that you already have a background task that needs to be registered.</span></span> <span data-ttu-id="9d08a-112">(バックグラウンド タスクの作成方法について詳しくは、「[Create and register a background task that runs out-of-process (アウトプロセスで実行されるバックグラウンド タスクの作成と登録)](create-and-register-a-background-task.md)」または「[Create and register an in-process background task (インプロセスのバックグラウンド タスクの作成と登録)](create-and-register-an-inproc-background-task.md)」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="9d08a-112">(See [Create and register a background task that runs out-of-process](create-and-register-a-background-task.md) or [Create and register an in-process background task](create-and-register-an-inproc-background-task.md) for information about how to write a background task).</span></span>

<span data-ttu-id="9d08a-113">このトピックは、バックグラウンド タスクを登録するユーティリティ関数の作り方を順に説明します。</span><span class="sxs-lookup"><span data-stu-id="9d08a-113">This topic walks through a utility function that registers background tasks.</span></span> <span data-ttu-id="9d08a-114">このユーティリティ関数は、二重登録による問題を防ぐために、同じタスクが登録されていないかどうかをチェックしたうえでタスクを登録します。バックグラウンド タスクにシステムの条件を適用することができます。</span><span class="sxs-lookup"><span data-stu-id="9d08a-114">This utility function checks for existing registrations first before registering the task multiple times to avoid problems with multiple registrations, and it can apply a system condition to the background task.</span></span> <span data-ttu-id="9d08a-115">ここで紹介しているユーティリティ関数は、それ自体で完結した実用的なコード例となっています。</span><span class="sxs-lookup"><span data-stu-id="9d08a-115">The walkthrough includes a complete, working example of this utility function.</span></span>

**<span data-ttu-id="9d08a-116">注:</span><span class="sxs-lookup"><span data-stu-id="9d08a-116">Note</span></span>**  

<span data-ttu-id="9d08a-117">ユニバーサル Windows アプリは、どの種類のバックグラウンド トリガーを登録する場合でも、先に [**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700485) を呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="9d08a-117">Universal Windows apps must call [**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700485) before registering any of the background trigger types.</span></span>

<span data-ttu-id="9d08a-118">更新プログラムのリリース後にユニバーサル Windows アプリが引き続き適切に実行されるようにするには、更新後にアプリが起動する際に、[**RemoveAccess**](https://msdn.microsoft.com/library/windows/apps/hh700471)、[**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700485) の順に呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="9d08a-118">To ensure that your Universal Windows app continues to run properly after you release an update, you must call [**RemoveAccess**](https://msdn.microsoft.com/library/windows/apps/hh700471) and then call [**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700485) when your app launches after being updated.</span></span> <span data-ttu-id="9d08a-119">詳しくは、「[バックグラウンド タスクのガイドライン](guidelines-for-background-tasks.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9d08a-119">For more information, see [Guidelines for background tasks](guidelines-for-background-tasks.md).</span></span>

## <a name="define-the-method-signature-and-return-type"></a><span data-ttu-id="9d08a-120">メソッドのシグニチャと戻り値の型の定義</span><span class="sxs-lookup"><span data-stu-id="9d08a-120">Define the method signature and return type</span></span>

<span data-ttu-id="9d08a-121">このメソッドは、タスクのエントリ ポイント、タスク名、構築済みのバックグラウンド タスク トリガーのほか、(必要に応じて) バックグラウンド タスクの [**SystemCondition**](https://msdn.microsoft.com/library/windows/apps/br224834) を引数として受け取ります。</span><span class="sxs-lookup"><span data-stu-id="9d08a-121">This method takes in the task entry point, task name, a pre-constructed background task trigger, and (optionally) a [**SystemCondition**](https://msdn.microsoft.com/library/windows/apps/br224834) for the background task.</span></span> <span data-ttu-id="9d08a-122">このメソッドは、[**BackgroundTaskRegistration**](https://msdn.microsoft.com/library/windows/apps/br224786) オブジェクトを返します。</span><span class="sxs-lookup"><span data-stu-id="9d08a-122">This method returns a [**BackgroundTaskRegistration**](https://msdn.microsoft.com/library/windows/apps/br224786) object.</span></span>

> [!Important]
> `taskEntryPoint` <span data-ttu-id="9d08a-123">- アウトプロセスで実行するバックグラウンド タスクの場合、名前空間名、"."、バックグラウンド クラスを含むクラス名という形式で構築する必要があります。</span><span class="sxs-lookup"><span data-stu-id="9d08a-123">- for background tasks that run in out of process, this must be constructed as the namespace name, '.', and the name of the class containing your background class.</span></span> <span data-ttu-id="9d08a-124">この文字列では、大文字と小文字を区別します。</span><span class="sxs-lookup"><span data-stu-id="9d08a-124">The string is case-sensitive.</span></span>  <span data-ttu-id="9d08a-125">たとえば、名前空間 "MyBackgroundTasks" と、バックグラウンド クラス コードを含むクラス "BackgroundTask1" がある場合、`taskEntryPoint` 用の文字列は "MyBackgroundTasks.BackgroundTask1" となります。</span><span class="sxs-lookup"><span data-stu-id="9d08a-125">For example, if you had a namespace "MyBackgroundTasks" and a class "BackgroundTask1" that contained your background class code, the string for `taskEntryPoint` would be "MyBackgroundTasks.BackgroundTask1".</span></span>
> <span data-ttu-id="9d08a-126">バックグラウンド タスクをアプリと同じプロセスで実行する (インプロセスのバックグラウンド タスク) 場合、`taskEntryPoint` を設定する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="9d08a-126">If your background task runs in the same process as your app (i.e. a in-process background task) `taskEntryPoint` should not be set.</span></span>

> [!div class="tabbedCodeSnippets"]
> ``` csharp
> public static BackgroundTaskRegistration RegisterBackgroundTask(
>                                                 string taskEntryPoint,
>                                                 string name,
>                                                 IBackgroundTrigger trigger,
>                                                 IBackgroundCondition condition)
> {
>     
>     // We'll add code to this function in subsequent steps.
>
> }
> ```
> ``` cpp
> BackgroundTaskRegistration^ MainPage::RegisterBackgroundTask(
>                                              Platform::String ^ taskEntryPoint,
>                                              Platform::String ^ taskName,
>                                              IBackgroundTrigger ^ trigger,
>                                              IBackgroundCondition ^ condition)
> {
>     
>     // We'll add code to this function in subsequent steps.
>
> }
> ```

## <a name="check-for-existing-registrations"></a><span data-ttu-id="9d08a-127">登録の重複確認</span><span class="sxs-lookup"><span data-stu-id="9d08a-127">Check for existing registrations</span></span>

<span data-ttu-id="9d08a-128">既に登録されたタスクかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="9d08a-128">Check whether the task is already registered.</span></span> <span data-ttu-id="9d08a-129">同じタスクが二重に登録されると、1 回のトリガーにつきタスクが複数回実行され、CPU が無駄に消費されるばかりか、予期しない動作を招くこともあるため、この確認は重要です。</span><span class="sxs-lookup"><span data-stu-id="9d08a-129">It's important to check this because if a task is registered multiple times, it will run more than once whenever it’s triggered; this can use excess CPU and may cause unexpected behavior.</span></span>

<span data-ttu-id="9d08a-130">同じタスクが登録されているかどうかは、[**BackgroundTaskRegistration.AllTasks**](https://msdn.microsoft.com/library/windows/apps/br224787) プロパティを照会し、返された結果を反復処理することで確認できます。</span><span class="sxs-lookup"><span data-stu-id="9d08a-130">You can check for existing registrations by querying the [**BackgroundTaskRegistration.AllTasks**](https://msdn.microsoft.com/library/windows/apps/br224787) property and iterating on the result.</span></span> <span data-ttu-id="9d08a-131">各インスタンスの名前を調べ、登録しようとしているタスクの名前と一致した場合、ループを抜けて、フラグ変数を設定します。このフラグに応じたコード パスが次のステップで選択されます。</span><span class="sxs-lookup"><span data-stu-id="9d08a-131">Check the name of each instance – if it matches the name of the task you’re registering, then break out of the loop and set a flag variable so that your code can choose a different path in the next step.</span></span>

> <span data-ttu-id="9d08a-132">**注:** アプリに固有のものであるバック グラウンド タスク名を使用します。</span><span class="sxs-lookup"><span data-stu-id="9d08a-132">**Note**Use background task names that are unique to your app.</span></span> <span data-ttu-id="9d08a-133">各バックグラウンド タスクには一意の名前が付いている必要があります。</span><span class="sxs-lookup"><span data-stu-id="9d08a-133">Ensure each background task has a unique name.</span></span>

<span data-ttu-id="9d08a-134">次のコードは、最後の手順で作成した [**SystemTrigger**](https://msdn.microsoft.com/library/windows/apps/br224838) を使ってバックグラウンド タスクを登録します。</span><span class="sxs-lookup"><span data-stu-id="9d08a-134">The following code registers a background task using the [**SystemTrigger**](https://msdn.microsoft.com/library/windows/apps/br224838) we created in the last step:</span></span>

> [!div class="tabbedCodeSnippets"]
> ``` csharp
> public static BackgroundTaskRegistration RegisterBackgroundTask(
>                                                 string taskEntryPoint,
>                                                 string name,
>                                                 IBackgroundTrigger trigger,
>                                                 IBackgroundCondition condition)
> {
>     //
>     // Check for existing registrations of this background task.
>     //
>
>     foreach (var cur in BackgroundTaskRegistration.AllTasks)
>     {
>
>         if (cur.Value.Name == name)
>         {
>             //
>             // The task is already registered.
>             //
>
>             return (BackgroundTaskRegistration)(cur.Value);
>         }
>     }
>     
>     // We'll register the task in the next step.
> }
> ```
> ``` cpp
> BackgroundTaskRegistration^ MainPage::RegisterBackgroundTask(
>                                              Platform::String ^ taskEntryPoint,
>                                              Platform::String ^ taskName,
>                                              IBackgroundTrigger ^ trigger,
>                                              IBackgroundCondition ^ condition)
> {
>     //
>     // Check for existing registrations of this background task.
>     //
>     
>     auto iter   = BackgroundTaskRegistration::AllTasks->First();
>     auto hascur = iter->HasCurrent;
>     
>     while (hascur)
>     {
>         auto cur = iter->Current->Value;
>         
>         if(cur->Name == name)
>         {
>             //
>             // The task is registered.
>             //
>             
>             return (BackgroundTaskRegistration ^)(cur);
>         }
>         
>         hascur = iter->MoveNext();
>     }
>     
>     // We'll register the task in the next step.
> }
> ```

## <a name="register-the-background-task-or-return-the-existing-registration"></a><span data-ttu-id="9d08a-135">バックグラウンド タスクを登録する (または既に登録されているタスクを返す)</span><span class="sxs-lookup"><span data-stu-id="9d08a-135">Register the background task (or return the existing registration)</span></span>


<span data-ttu-id="9d08a-136">同じバックグラウンド タスクが既に登録されているかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="9d08a-136">Check to see if the task was found in the list of existing background task registrations.</span></span> <span data-ttu-id="9d08a-137">登録されている場合は、そのタスクのインスタンスを返します。</span><span class="sxs-lookup"><span data-stu-id="9d08a-137">If so, return that instance of the task.</span></span>

<span data-ttu-id="9d08a-138">登録されていない場合は、新しい [**BackgroundTaskBuilder**](https://msdn.microsoft.com/library/windows/apps/br224768) オブジェクトを使ってタスクを登録します。</span><span class="sxs-lookup"><span data-stu-id="9d08a-138">Then, register the task using a new [**BackgroundTaskBuilder**](https://msdn.microsoft.com/library/windows/apps/br224768) object.</span></span> <span data-ttu-id="9d08a-139">このコードは、condition パラメーターが null かどうかを確認し、null でない場合は、その condition を登録オブジェクトに追加します。</span><span class="sxs-lookup"><span data-stu-id="9d08a-139">This code should check whether the condition parameter is null, and if not, add the condition to the registration object.</span></span> <span data-ttu-id="9d08a-140">戻り値は、[**BackgroundTaskBuilder.Register**](https://msdn.microsoft.com/library/windows/apps/br224772) メソッドから返された [**BackgroundTaskRegistration**](https://msdn.microsoft.com/library/windows/apps/br224786) です。</span><span class="sxs-lookup"><span data-stu-id="9d08a-140">Return the [**BackgroundTaskRegistration**](https://msdn.microsoft.com/library/windows/apps/br224786) returned by the [**BackgroundTaskBuilder.Register**](https://msdn.microsoft.com/library/windows/apps/br224772) method.</span></span>

> <span data-ttu-id="9d08a-141">**注:** バック グラウンド タスクの登録パラメーターは登録時に検証されます。</span><span class="sxs-lookup"><span data-stu-id="9d08a-141">**Note**Background task registration parameters are validated at the time of registration.</span></span> <span data-ttu-id="9d08a-142">いずれかの登録パラメーターが有効でない場合は、エラーが返されます。</span><span class="sxs-lookup"><span data-stu-id="9d08a-142">An error is returned if any of the registration parameters are invalid.</span></span> <span data-ttu-id="9d08a-143">バックグラウンド タスクの登録が失敗するシナリオをアプリが適切に処理するようにします。タスクを登録しようとした後で、有効な登録オブジェクトを持っていることを前提として動作するアプリは、クラッシュする場合があります。</span><span class="sxs-lookup"><span data-stu-id="9d08a-143">Ensure that your app gracefully handles scenarios where background task registration fails - if instead your app depends on having a valid registration object after attempting to register a task, it may crash.</span></span>
> <span data-ttu-id="9d08a-144">**注** アプリと同じプロセスで実行されるバックグラウンド タスクを登録する場合、`String.Empty` または `null` を `taskEntryPoint` パラメーターに送信します。</span><span class="sxs-lookup"><span data-stu-id="9d08a-144">**Note** If you are registering a background task that runs in the same process as your app, send `String.Empty` or `null` for the `taskEntryPoint` parameter.</span></span>

<span data-ttu-id="9d08a-145">次の例には、既にあるタスクを返すか、バックグラウンド タスクを登録するコードが追加されています。また、システムの条件 (省略可能) が指定された場合の処理も追加されています。</span><span class="sxs-lookup"><span data-stu-id="9d08a-145">The following example either returns the existing task, or adds code that registers the background task (including the optional system condition if present):</span></span>

> [!div class="tabbedCodeSnippets"]
> ``` csharp
> public static BackgroundTaskRegistration RegisterBackgroundTask(
>                                                 string taskEntryPoint,
>                                                 string name,
>                                                 IBackgroundTrigger trigger,
>                                                 IBackgroundCondition condition)
> {
>     //
>     // Check for existing registrations of this background task.
>     //
>
>     foreach (var cur in BackgroundTaskRegistration.AllTasks)
>     {
>
>         if (cur.Value.Name == taskName)
>         {
>             //
>             // The task is already registered.
>             //
>
>             return (BackgroundTaskRegistration)(cur.Value);
>         }
>     }
>
>     //
>     // Register the background task.
>     //
>
>     var builder = new BackgroundTaskBuilder();
>
>     builder.Name = name;
>
>     // in-process background tasks don't set TaskEntryPoint
>     if ( taskEntryPoint != null && taskEntryPoint != String.Empty)
>     {
>         builder.TaskEntryPoint = taskEntryPoint;
>     }
>     builder.SetTrigger(trigger);
>
>     if (condition != null)
>     {
>         builder.AddCondition(condition);
>     }
>
>     BackgroundTaskRegistration task = builder.Register();
>
>     return task;
> }
> ```
> ``` cpp
> BackgroundTaskRegistration^ MainPage::RegisterBackgroundTask(
>                                              Platform::String ^ taskEntryPoint,
>                                              Platform::String ^ taskName,
>                                              IBackgroundTrigger ^ trigger,
>                                              IBackgroundCondition ^ condition)
> {
>
>     //
>     // Check for existing registrations of this background task.
>     //
>
>     auto iter   = BackgroundTaskRegistration::AllTasks->First();
>     auto hascur = iter->HasCurrent;
>
>     while (hascur)
>     {
>         auto cur = iter->Current->Value;
>
>         if(cur->Name == name)
>         {
>             //
>             // The task is registered.
>             //
>
>             return (BackgroundTaskRegistration ^)(cur);
>         }
>
>         hascur = iter->MoveNext();
>     }
>
>     //
>     // Register the background task.
>     //
>
>     auto builder = ref new BackgroundTaskBuilder();
>
>     builder->Name = name;
>     builder->TaskEntryPoint = taskEntryPoint;
>     builder->SetTrigger(trigger);
>
>     if (condition != nullptr) {
>         
>         builder->AddCondition(condition);
>     }
>
>     BackgroundTaskRegistration ^ task = builder->Register();
>
>     return task;
> }
> ```

## <a name="complete-background-task-registration-utility-function"></a><span data-ttu-id="9d08a-146">バックグラウンド タスク登録ユーティリティ関数の完成</span><span class="sxs-lookup"><span data-stu-id="9d08a-146">Complete background task registration utility function</span></span>

<span data-ttu-id="9d08a-147">この例は、バックグラウンド タスク登録ユーティリティ関数全体を示しています。</span><span class="sxs-lookup"><span data-stu-id="9d08a-147">This example shows the completed background task registration function.</span></span> <span data-ttu-id="9d08a-148">ネットワーク関連のバックグラウンド タスクを除くほとんどのバックグラウンド タスクは、この関数を使って登録できます。</span><span class="sxs-lookup"><span data-stu-id="9d08a-148">This function can be used to register most background tasks, with the exception of networking background tasks.</span></span>

> [!div class="tabbedCodeSnippets"]
> ``` csharp
> //
> // Register a background task with the specified taskEntryPoint, name, trigger,
> // and condition (optional).
> //
> // taskEntryPoint: Task entry point for the background task.
> // taskName: A name for the background task.
> // trigger: The trigger for the background task.
> // condition: Optional parameter. A conditional event that must be true for the task to fire.
> //
> public static BackgroundTaskRegistration RegisterBackgroundTask(string taskEntryPoint,
>                                                                 string taskName,
>                                                                 IBackgroundTrigger trigger,
>                                                                 IBackgroundCondition condition)
> {
>     //
>     // Check for existing registrations of this background task.
>     //
>
>     foreach (var cur in BackgroundTaskRegistration.AllTasks)
>     {
>
>         if (cur.Value.Name == taskName)
>         {
>             //
>             // The task is already registered.
>             //
>
>             return (BackgroundTaskRegistration)(cur.Value);
>         }
>     }
>
>     //
>     // Register the background task.
>     //
>
>     var builder = new BackgroundTaskBuilder();
>
>     builder.Name = taskName;
>     builder.TaskEntryPoint = taskEntryPoint;
>     builder.SetTrigger(trigger);
>
>     if (condition != null)
>     {
>
>         builder.AddCondition(condition);
>     }
>
>     BackgroundTaskRegistration task = builder.Register();
>
>     return task;
> }
> ```
> ``` cpp
> //
> // Register a background task with the specified taskEntryPoint, name, trigger,
> // and condition (optional).
> //
> // taskEntryPoint: Task entry point for the background task.
> // taskName: A name for the background task.
> // trigger: The trigger for the background task.
> // condition: Optional parameter. A conditional event that must be true for the task to fire.
> //
> BackgroundTaskRegistration^ MainPage::RegisterBackgroundTask(Platform::String ^ taskEntryPoint,
>                                                              Platform::String ^ taskName,
>                                                              IBackgroundTrigger ^ trigger,
>                                                              IBackgroundCondition ^ condition)
> {
>
>     //
>     // Check for existing registrations of this background task.
>     //
>
>     auto iter   = BackgroundTaskRegistration::AllTasks->First();
>     auto hascur = iter->HasCurrent;
>
>     while (hascur)
>     {
>         auto cur = iter->Current->Value;
>
>         if(cur->Name == name)
>         {
>             //
>             // The task is registered.
>             //
>
>             return (BackgroundTaskRegistration ^)(cur);
>         }
>
>         hascur = iter->MoveNext();
>     }
>
>
>     //
>     // Register the background task.
>     //
>
>     auto builder = ref new BackgroundTaskBuilder();
>
>     builder->Name = name;
>     builder->TaskEntryPoint = taskEntryPoint;
>     builder->SetTrigger(trigger);
>
>     if (condition != nullptr) {
>
>         builder->AddCondition(condition);
>     }
>
>     BackgroundTaskRegistration ^ task = builder->Register();
>
>     return task;
> }
> ```

## <a name="related-topics"></a><span data-ttu-id="9d08a-149">関連トピック</span><span class="sxs-lookup"><span data-stu-id="9d08a-149">Related topics</span></span>

* [<span data-ttu-id="9d08a-150">アウトプロセス バックグラウンド タスクの作成と登録</span><span class="sxs-lookup"><span data-stu-id="9d08a-150">Create and register an out-of-process background task</span></span>](create-and-register-a-background-task.md)
* [<span data-ttu-id="9d08a-151">インプロセス バックグラウンド タスクの作成と登録</span><span class="sxs-lookup"><span data-stu-id="9d08a-151">Create and register an in-process background task</span></span>](create-and-register-an-inproc-background-task.md)
* [<span data-ttu-id="9d08a-152">アプリケーション マニフェストでのバックグラウンド タスクの宣言</span><span class="sxs-lookup"><span data-stu-id="9d08a-152">Declare background tasks in the application manifest</span></span>](declare-background-tasks-in-the-application-manifest.md)
* [<span data-ttu-id="9d08a-153">取り消されたバックグラウンド タスクの処理</span><span class="sxs-lookup"><span data-stu-id="9d08a-153">Handle a cancelled background task</span></span>](handle-a-cancelled-background-task.md)
* [<span data-ttu-id="9d08a-154">バックグラウンド タスクの進捗状況と完了の監視</span><span class="sxs-lookup"><span data-stu-id="9d08a-154">Monitor background task progress and completion</span></span>](monitor-background-task-progress-and-completion.md)
* [<span data-ttu-id="9d08a-155">バックグラウンド タスクによるシステム イベントへの応答</span><span class="sxs-lookup"><span data-stu-id="9d08a-155">Respond to system events with background tasks</span></span>](respond-to-system-events-with-background-tasks.md)
* [<span data-ttu-id="9d08a-156">バックグラウンド タスクを実行するための条件の設定</span><span class="sxs-lookup"><span data-stu-id="9d08a-156">Set conditions for running a background task</span></span>](set-conditions-for-running-a-background-task.md)
* [<span data-ttu-id="9d08a-157">バックグラウンド タスクのライブ タイルの更新</span><span class="sxs-lookup"><span data-stu-id="9d08a-157">Update a live tile from a background task</span></span>](update-a-live-tile-from-a-background-task.md)
* [<span data-ttu-id="9d08a-158">メンテナンス トリガーの使用</span><span class="sxs-lookup"><span data-stu-id="9d08a-158">Use a maintenance trigger</span></span>](use-a-maintenance-trigger.md)
* [<span data-ttu-id="9d08a-159">タイマーでのバックグラウンド タスクの実行</span><span class="sxs-lookup"><span data-stu-id="9d08a-159">Run a background task on a timer</span></span>](run-a-background-task-on-a-timer-.md)
* [<span data-ttu-id="9d08a-160">バックグラウンド タスクのガイドライン</span><span class="sxs-lookup"><span data-stu-id="9d08a-160">Guidelines for background tasks</span></span>](guidelines-for-background-tasks.md)
* [<span data-ttu-id="9d08a-161">バックグラウンド タスクのデバッグ</span><span class="sxs-lookup"><span data-stu-id="9d08a-161">Debug a background task</span></span>](debug-a-background-task.md)
* [<span data-ttu-id="9d08a-162">UWP アプリで一時停止イベント、再開イベント、バックグラウンド イベントをトリガーする方法 (デバッグ時)</span><span class="sxs-lookup"><span data-stu-id="9d08a-162">How to trigger suspend, resume, and background events in UWP apps (when debugging)</span></span>](http://go.microsoft.com/fwlink/p/?linkid=254345)