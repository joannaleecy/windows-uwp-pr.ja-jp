---
author: mcleblanc
ms.assetid: FA25562A-FE62-4DFC-9084-6BD6EAD73636
title: "UI スレッドの応答性の確保"
description: "ユーザーは、コンピューターの種類に関係なく、アプリが計算を実行しているときも引き続き応答性を保つことを期待します。"
ms.author: markl
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
translationtype: Human Translation
ms.sourcegitcommit: c6b64cff1bbebc8ba69bc6e03d34b69f85e798fc
ms.openlocfilehash: eae6c26979f3aa6b1c9fabf217f6a49ed89dd38b
ms.lasthandoff: 02/07/2017

---
# <a name="keep-the-ui-thread-responsive"></a>UI スレッドの応答性の確保

\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください \]

ユーザーは、コンピューターの種類に関係なく、アプリが計算を実行しているときも引き続き応答性を保つことを期待します。 これは、アプリケーションの種類によって異なる意味を持ちます。 一部のアプリケーションにとっては、これは、よりリアルな物理的効果の再現、ディスクや Web からのデータの読み込み速度の向上、複雑なシーンのすばやい表示とページ間の移動、スナップでの方向検出、高速のデータ処理などを意味します。 計算の種類に関係なく、ユーザーはアプリが入力に対して反応することを求め、計算中にアプリが応答停止しているように見える状況は望ましくありません。

アプリはイベント駆動型です。これは、コードがイベントに応答して操作を実行し、次のイベントまでアイドル状態になることを意味します。 UI のプラットフォーム コード (レイアウト、入力、および生成イベントなど) と UI 用のアプリのコードはすべて、同じ UI スレッドで実行されます。 このスレッドでは一度に 1 つの命令しか実行できないため、アプリのコードの実行に長い時間がかかるとイベントを処理できず、フレームワークはレイアウトを実行したりユーザー操作を表す新しいイベントを生成したりできません。 アプリの応答性は、作業の処理に UI スレッドを使えるかどうかに関係します。

UI スレッドを使って、UI スレッドへのほぼすべての変更を行う必要があります。これには、UI の種類の作成、そのメンバーへのアクセスも含まれます。 UI はバックグラウンド スレッドから更新できませんが、[**CoreDispatcher.RunAsync**](https://msdn.microsoft.com/library/windows/apps/Hh750317) を使ってこのスレッドにメッセージを投稿し、コードをそこで実行することができます。

> **注**  1 つの例外は、入力の処理方法や基本的なレイアウトに影響を及ぼさない UI 変更を適用できる別のレンダリング スレッドがあることです。 たとえば、レイアウトに影響を及ぼさない多くのアニメーションと切り替えは、このレンダリング スレッド上で実行できます。

## <a name="delay-element-instantiation"></a>要素のインスタンス化の遅延

アプリでの最も低速なステージとして、起動や、ビューの切り替えなどがあります。 ユーザーに最初に表示される UI を起動するために必要なもの以上の作業を実行しないでください。 たとえば、段階的に公開される UI の UI や、ポップアップのコンテンツなどは作成しないでください。

-   [x:DeferLoadStrategy](https://msdn.microsoft.com/library/windows/apps/Mt204785) を使って要素のインスタンス化を遅らせます。
-   プログラムを使って、要素をツリーにオンデマンドで挿入します。

[**CoreDispatcher.RunIdleAsync**](https://msdn.microsoft.com/library/windows/apps/Hh967918) キューにより、UI スレッドはビジーになっていない状態を処理できます。

## <a name="use-asynchronous-apis"></a>非同期 API の使用

アプリの高い応答性を維持するため、このプラットフォームの API の大部分に非同期バージョンが用意されています。 非同期 API を使うと、アクティブな実行スレッドが長時間ブロックされた状態になるのを防ぐことができます。 UI スレッドから API を呼び出す場合、提供されている限りは非同期バージョンを使ってください。 **非同期**パターンを使ったプログラミングについて詳しくは、「[非同期プログラミング](https://msdn.microsoft.com/library/windows/apps/Mt187335)」または「[C# または Visual Basic での非同期 API の呼び出し](https://msdn.microsoft.com/library/windows/apps/Mt187337)」をご覧ください。

## <a name="offload-work-to-background-threads"></a>バックグラウンド スレッドへの作業のオフロード

すばやく戻るイベント ハンドラーを記述します。 かなりの量の作業を実行する必要がある場合は、バックグラウンド スレッドで実行し、戻るようにスケジュールします。

C# では **await** 演算子、Visual Basic では **Await** 演算子、C++ ではデリゲートを使って、作業を非同期で実行するようスケジュールできます。 ただし、これは、スケジュールした作業がバックグラウンド スレッドで実行されることを保証するものではありません。 ユニバーサル Windows プラットフォーム (UWP) API の多くは、作業をバックグラウンド スレッドで実行するようスケジュールしますが、**await** またはデリゲートのみを使ってアプリのコードを呼び出すと、そのデリゲートまたはメソッドは UI スレッドで実行されます。 アプリのコードをバックグラウンド スレッドで実行する場合は、それを明示的に指定する必要があります。 C# および Visual Basic の場合、これはコードを [**Task.Run**](https://msdn.microsoft.com/library/windows/apps/xaml/system.threading.tasks.task.run.aspx) に渡すことで実現できます。

UI 要素には UI スレッドからしかアクセスできないことに注意してください。 バックグラウンドの作業を起動する前に、UI スレッドを使って UI 要素にアクセスするか、バックグラウンド スレッドで [**CoreDispatcher.RunAsync**](https://msdn.microsoft.com/library/windows/apps/Hh750317) または [**CoreDispatcher.RunIdleAsync**](https://msdn.microsoft.com/library/windows/apps/Hh967918) を使います。

バックグラウンド スレッドで実行できる作業の例として、ゲームでのコンピューター AI の計算があります。 コンピューターの次の動作を計算するコードは、実行に長い時間がかかる場合があります。

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

この例では、UI スレッドの応答性を確保するために、`NextMove-Click` ハンドラーが **await** で戻ります。 ただし、バックグラウンド スレッドで実行される `ComputeNextMove` が完了すると、そのハンドラーで実行が回復します。 ハンドラーの残りのコードにより、UI がその結果で更新されます。

> **注**  UWP 用の [**ThreadPool**](https://msdn.microsoft.com/library/windows/apps/BR229621) API と [**ThreadPoolTimer**](https://msdn.microsoft.com/library/windows/apps/windows.system.threading.threadpooltimer.aspx) API もあり、これを類似したシナリオで使うこともできます。 詳しくは、「[スレッド化と非同期プログラミング](https://msdn.microsoft.com/library/windows/apps/Mt187340)」をご覧ください。

## <a name="related-topics"></a>関連トピック

* [カスタム ユーザー操作](https://msdn.microsoft.com/library/windows/apps/Mt185599)


