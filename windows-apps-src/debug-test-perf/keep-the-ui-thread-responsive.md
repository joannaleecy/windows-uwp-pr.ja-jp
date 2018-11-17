---
author: jwmsft
ms.assetid: FA25562A-FE62-4DFC-9084-6BD6EAD73636
title: UI スレッドの応答性の確保
description: ユーザーは、コンピューターの種類に関係なく、アプリが計算を実行しているときも引き続き応答性を保つことを期待します。
ms.author: jimwalk
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 7884c7187bf127e15aaaed38a55e5f9827a3990d
ms.sourcegitcommit: 3257416aebb5a7b1515e107866806f8bd57845a8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/17/2018
ms.locfileid: "7159029"
---
# <a name="keep-the-ui-thread-responsive"></a><span data-ttu-id="57b05-104">UI スレッドの応答性の確保</span><span class="sxs-lookup"><span data-stu-id="57b05-104">Keep the UI thread responsive</span></span>


<span data-ttu-id="57b05-105">ユーザーは、コンピューターの種類に関係なく、アプリが計算を実行しているときも引き続き応答性を保つことを期待します。</span><span class="sxs-lookup"><span data-stu-id="57b05-105">Users expect an app to remain responsive while it does computation, regardless of the type of machine.</span></span> <span data-ttu-id="57b05-106">これは、アプリケーションの種類によって異なる意味を持ちます。</span><span class="sxs-lookup"><span data-stu-id="57b05-106">This means different things for different apps.</span></span> <span data-ttu-id="57b05-107">一部のアプリケーションにとっては、これは、よりリアルな物理的効果の再現、ディスクや Web からのデータの読み込み速度の向上、複雑なシーンのすばやい表示とページ間の移動、スナップでの方向検出、高速のデータ処理などを意味します。</span><span class="sxs-lookup"><span data-stu-id="57b05-107">For some, this translates to providing more realistic physics, loading data from disk or the web faster, quickly presenting complex scenes and navigating between pages, finding directions in a snap, or rapidly processing data.</span></span> <span data-ttu-id="57b05-108">計算の種類に関係なく、ユーザーはアプリが入力に対して反応することを求め、計算中にアプリが応答停止しているように見える状況は望ましくありません。</span><span class="sxs-lookup"><span data-stu-id="57b05-108">Regardless of the type of computation, users want their app to act on their input and eliminate instances where it appears unresponsive while it "thinks".</span></span>

<span data-ttu-id="57b05-109">アプリはイベント駆動型です。これは、コードがイベントに応答して操作を実行し、次のイベントまでアイドル状態になることを意味します。</span><span class="sxs-lookup"><span data-stu-id="57b05-109">Your app is event-driven, which means that your code performs work in response to an event and then it sits idle until the next.</span></span> <span data-ttu-id="57b05-110">UI のプラットフォーム コード (レイアウト、入力、および生成イベントなど) と UI 用のアプリのコードはすべて、同じ UI スレッドで実行されます。</span><span class="sxs-lookup"><span data-stu-id="57b05-110">Platform code for UI (layout, input, raising events, etc.) and your app’s code for UI all are executed on the same UI thread.</span></span> <span data-ttu-id="57b05-111">このスレッドでは一度に 1 つの命令しか実行できないため、アプリのコードの実行に長い時間がかかるとイベントを処理できず、フレームワークはレイアウトを実行したりユーザー操作を表す新しいイベントを生成したりできません。</span><span class="sxs-lookup"><span data-stu-id="57b05-111">Only one instruction can execute on that thread at a time so if your app code takes too long to process an event then the framework can’t run layout or raise new events representing user interaction.</span></span> <span data-ttu-id="57b05-112">アプリの応答性は、作業の処理に UI スレッドを使えるかどうかに関係します。</span><span class="sxs-lookup"><span data-stu-id="57b05-112">The responsiveness of your app is related to the availability of the UI thread to process work.</span></span>

<span data-ttu-id="57b05-113">UI スレッドを使って、UI スレッドへのほぼすべての変更を行う必要があります。これには、UI の種類の作成、そのメンバーへのアクセスも含まれます。</span><span class="sxs-lookup"><span data-stu-id="57b05-113">You need to use the UI thread to make almost all changes to the UI thread, including creating UI types and accessing their members.</span></span> <span data-ttu-id="57b05-114">UI はバックグラウンド スレッドから更新できませんが、[**CoreDispatcher.RunAsync**](https://msdn.microsoft.com/library/windows/apps/Hh750317) を使ってこのスレッドにメッセージを投稿し、コードをそこで実行することができます。</span><span class="sxs-lookup"><span data-stu-id="57b05-114">You can't update the UI from a background thread but you can post a message to it with [**CoreDispatcher.RunAsync**](https://msdn.microsoft.com/library/windows/apps/Hh750317) to cause code to be run there.</span></span>

> <span data-ttu-id="57b05-115">**注:** 1 つの例外は、入力の処理方法に影響を与える UI の変更を適用できる別のレンダリング スレッドまたは基本的なレイアウト。</span><span class="sxs-lookup"><span data-stu-id="57b05-115">**Note**The one exception is that there's a separate render thread that can apply UI changes that won't affect how input is handled or the basic layout.</span></span> <span data-ttu-id="57b05-116">たとえば、レイアウトに影響を及ぼさない多くのアニメーションと切り替えは、このレンダリング スレッド上で実行できます。</span><span class="sxs-lookup"><span data-stu-id="57b05-116">For example many animations and transitions that don’t affect layout can run on this render thread.</span></span>

## <a name="delay-element-instantiation"></a><span data-ttu-id="57b05-117">要素のインスタンス化の遅延</span><span class="sxs-lookup"><span data-stu-id="57b05-117">Delay element instantiation</span></span>

<span data-ttu-id="57b05-118">アプリでの最も低速なステージとして、起動や、ビューの切り替えなどがあります。</span><span class="sxs-lookup"><span data-stu-id="57b05-118">Some of the slowest stages in an app can include startup, and switching views.</span></span> <span data-ttu-id="57b05-119">ユーザーに最初に表示される UI を起動するために必要なもの以上の作業を実行しないでください。</span><span class="sxs-lookup"><span data-stu-id="57b05-119">Don't do more work than necessary to bring up the UI that the user sees initially.</span></span> <span data-ttu-id="57b05-120">たとえば、段階的に公開される UI の UI や、ポップアップのコンテンツなどは作成しないでください。</span><span class="sxs-lookup"><span data-stu-id="57b05-120">For example, don't create the UI for progressively-disclosed UI and the contents of popups.</span></span>

-   <span data-ttu-id="57b05-121">[x:Load attribute](../xaml-platform/x-load-attribute.md) または [x:DeferLoadStrategy](https://msdn.microsoft.com/library/windows/apps/Mt204785) を使って要素のインスタンス化を遅らせます。</span><span class="sxs-lookup"><span data-stu-id="57b05-121">Use [x:Load attribute](../xaml-platform/x-load-attribute.md) or [x:DeferLoadStrategy](https://msdn.microsoft.com/library/windows/apps/Mt204785) to delay-instantiate elements.</span></span>
-   <span data-ttu-id="57b05-122">プログラムを使って、要素をツリーにオンデマンドで挿入します。</span><span class="sxs-lookup"><span data-stu-id="57b05-122">Programmatically insert elements into the tree on-demand.</span></span>

<span data-ttu-id="57b05-123">[**CoreDispatcher.RunIdleAsync**](https://msdn.microsoft.com/library/windows/apps/Hh967918) キューにより、UI スレッドはビジーになっていない状態を処理できます。</span><span class="sxs-lookup"><span data-stu-id="57b05-123">[**CoreDispatcher.RunIdleAsync**](https://msdn.microsoft.com/library/windows/apps/Hh967918) queues work for the UI thread to process when it's not busy.</span></span>

## <a name="use-asynchronous-apis"></a><span data-ttu-id="57b05-124">非同期 API の使用</span><span class="sxs-lookup"><span data-stu-id="57b05-124">Use asynchronous APIs</span></span>

<span data-ttu-id="57b05-125">アプリの高い応答性を維持するため、このプラットフォームの API の大部分に非同期バージョンが用意されています。</span><span class="sxs-lookup"><span data-stu-id="57b05-125">To help keep your app responsive, the platform provides asynchronous versions of many of its APIs.</span></span> <span data-ttu-id="57b05-126">非同期 API を使うと、アクティブな実行スレッドが長時間ブロックされた状態になるのを防ぐことができます。</span><span class="sxs-lookup"><span data-stu-id="57b05-126">An asynchronous API ensures that your active execution thread never blocks for a significant amount of time.</span></span> <span data-ttu-id="57b05-127">UI スレッドから API を呼び出す場合、提供されている限りは非同期バージョンを使ってください。</span><span class="sxs-lookup"><span data-stu-id="57b05-127">When you call an API from the UI thread, use the asynchronous version if it's available.</span></span> <span data-ttu-id="57b05-128">**非同期**パターンを使ったプログラミングについて詳しくは、「[非同期プログラミング](https://msdn.microsoft.com/library/windows/apps/Mt187335)」または「[C# または Visual Basic での非同期 API の呼び出し](https://msdn.microsoft.com/library/windows/apps/Mt187337)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="57b05-128">For more info about programming with **async** patterns, see [Asynchronous programming](https://msdn.microsoft.com/library/windows/apps/Mt187335) or [Call asynchronous APIs in C# or Visual Basic](https://msdn.microsoft.com/library/windows/apps/Mt187337).</span></span>

## <a name="offload-work-to-background-threads"></a><span data-ttu-id="57b05-129">バックグラウンド スレッドへの作業のオフロード</span><span class="sxs-lookup"><span data-stu-id="57b05-129">Offload work to background threads</span></span>

<span data-ttu-id="57b05-130">すばやく戻るイベント ハンドラーを記述します。</span><span class="sxs-lookup"><span data-stu-id="57b05-130">Write event handlers to return quickly.</span></span> <span data-ttu-id="57b05-131">かなりの量の作業を実行する必要がある場合は、バックグラウンド スレッドで実行し、戻るようにスケジュールします。</span><span class="sxs-lookup"><span data-stu-id="57b05-131">In cases where a non-trivial amount of work needs to be performed, schedule it on a background thread and return.</span></span>

<span data-ttu-id="57b05-132">C# では **await** 演算子、Visual Basic では **Await** 演算子、C++ ではデリゲートを使って、作業を非同期で実行するようスケジュールできます。</span><span class="sxs-lookup"><span data-stu-id="57b05-132">You can schedule work asynchronously by using the **await** operator in C#, the **Await** operator in Visual Basic, or delegates in C++.</span></span> <span data-ttu-id="57b05-133">ただし、これは、スケジュールした作業がバックグラウンド スレッドで実行されることを保証するものではありません。</span><span class="sxs-lookup"><span data-stu-id="57b05-133">But this doesn't guarantee that the work you schedule will run on a background thread.</span></span> <span data-ttu-id="57b05-134">ユニバーサル Windows プラットフォーム (UWP) API の多くは、作業をバックグラウンド スレッドで実行するようスケジュールしますが、**await** またはデリゲートのみを使ってアプリのコードを呼び出すと、そのデリゲートまたはメソッドは UI スレッドで実行されます。</span><span class="sxs-lookup"><span data-stu-id="57b05-134">Many of the Universal Windows Platform (UWP) APIs schedule work in the background thread for you, but if you call your app code by using only **await** or a delegate, you run that delegate or method on the UI thread.</span></span> <span data-ttu-id="57b05-135">アプリのコードをバックグラウンド スレッドで実行する場合は、それを明示的に指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="57b05-135">You have to explicitly say when you want to run your app code on a background thread.</span></span> <span data-ttu-id="57b05-136">C# および Visual Basic では[**Task.Run**](https://msdn.microsoft.com/library/windows/apps/xaml/system.threading.tasks.task.run.aspx)にコードを渡すことによってこれを実現できます。</span><span class="sxs-lookup"><span data-stu-id="57b05-136">In C# and Visual Basic you can accomplish this by passing code to [**Task.Run**](https://msdn.microsoft.com/library/windows/apps/xaml/system.threading.tasks.task.run.aspx).</span></span>

<span data-ttu-id="57b05-137">UI 要素には UI スレッドからしかアクセスできないことに注意してください。</span><span class="sxs-lookup"><span data-stu-id="57b05-137">Remember that UI elements may only be accessed from the UI thread.</span></span> <span data-ttu-id="57b05-138">バックグラウンドの作業を起動する前に、UI スレッドを使って UI 要素にアクセスするか、バックグラウンド スレッドで [**CoreDispatcher.RunAsync**](https://msdn.microsoft.com/library/windows/apps/Hh750317) または [**CoreDispatcher.RunIdleAsync**](https://msdn.microsoft.com/library/windows/apps/Hh967918) を使います。</span><span class="sxs-lookup"><span data-stu-id="57b05-138">Use the UI thread to access UI elements before launching the background work and/or use [**CoreDispatcher.RunAsync**](https://msdn.microsoft.com/library/windows/apps/Hh750317) or [**CoreDispatcher.RunIdleAsync**](https://msdn.microsoft.com/library/windows/apps/Hh967918) on the background thread.</span></span>

<span data-ttu-id="57b05-139">バックグラウンド スレッドで実行できる作業の例として、ゲームでのコンピューター AI の計算があります。</span><span class="sxs-lookup"><span data-stu-id="57b05-139">An example of work that can be performed on a background thread is the calculating of computer AI in a game.</span></span> <span data-ttu-id="57b05-140">コンピューターの次の動作を計算するコードは、実行に長い時間がかかる場合があります。</span><span class="sxs-lookup"><span data-stu-id="57b05-140">The code that calculates the computer's next move can take a lot of time to execute.</span></span>

```csharp
public class AsyncExample
{
    private async void NextMove-Click(object sender, RoutedEventArgs e)
    {
        // The await causes the handler to return immediately.
        await System.Threading.Tasks.Task.Run(() => ComputeNextMove());
        // Now update the UI with the results.
        // ...
    }

    private async System.Threading.Tasks.Task ComputeNextMove()
    {
        // Perform background work here.
        // Don't directly access UI elements from this method.
    }
}
```

> [!div class="tabbedCodeSnippets"]
> ```csharp
> public class Example
> {
>     // ...
>     private async void NextMove-Click(object sender, RoutedEventArgs e)
>     {
>         await Task.Run(() => ComputeNextMove());
>         // Update the UI with results
>     }
> 
>     private async Task ComputeNextMove()
>     {
>         // ...
>     }
>     // ...
> }
> ```
> ```vb
> Public Class Example
>     ' ...
>     Private Async Sub NextMove-Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
>         Await Task.Run(Function() ComputeNextMove())
>         ' update the UI with results
>     End Sub
> 
>     Private Async Function ComputeNextMove() As Task
>         ' ...
>     End Function
>     ' ...
> End Class
> ```

<span data-ttu-id="57b05-141">この例では、UI スレッドの応答性を確保するために、`NextMove-Click` ハンドラーが **await** で戻ります。</span><span class="sxs-lookup"><span data-stu-id="57b05-141">In this example, the `NextMove-Click` handler returns at the **await** in order to keep the UI thread responsive.</span></span> <span data-ttu-id="57b05-142">ただし、バックグラウンド スレッドで実行される `ComputeNextMove` が完了すると、そのハンドラーで実行が回復します。</span><span class="sxs-lookup"><span data-stu-id="57b05-142">But execution picks up in that handler again after `ComputeNextMove` (which executes on a background thread) completes.</span></span> <span data-ttu-id="57b05-143">ハンドラーの残りのコードにより、UI がその結果で更新されます。</span><span class="sxs-lookup"><span data-stu-id="57b05-143">The remaining code in the handler updates the UI with the results.</span></span>

> <span data-ttu-id="57b05-144">**注:** も類似したシナリオのために使用すると、UWP 用[**ThreadPool**](https://msdn.microsoft.com/library/windows/apps/BR229621)と[**ThreadPoolTimer**](https://msdn.microsoft.com/library/windows/apps/windows.system.threading.threadpooltimer.aspx)の API が含まれます。</span><span class="sxs-lookup"><span data-stu-id="57b05-144">**Note**There's also a [**ThreadPool**](https://msdn.microsoft.com/library/windows/apps/BR229621) and [**ThreadPoolTimer**](https://msdn.microsoft.com/library/windows/apps/windows.system.threading.threadpooltimer.aspx) API for the UWP, which can be used for similar scenarios.</span></span> <span data-ttu-id="57b05-145">詳しくは、「[スレッド化と非同期プログラミング](https://msdn.microsoft.com/library/windows/apps/Mt187340)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="57b05-145">For more info, see [Threading and async programming](https://msdn.microsoft.com/library/windows/apps/Mt187340).</span></span>

## <a name="related-topics"></a><span data-ttu-id="57b05-146">関連トピック</span><span class="sxs-lookup"><span data-stu-id="57b05-146">Related topics</span></span>

* [<span data-ttu-id="57b05-147">カスタム ユーザー操作</span><span class="sxs-lookup"><span data-stu-id="57b05-147">Custom user interactions</span></span>](https://msdn.microsoft.com/library/windows/apps/Mt185599)
