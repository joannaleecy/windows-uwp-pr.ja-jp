---
author: normesta
ms.assetid: 1B077801-0A58-4A34-887C-F1E85E9A37B0
title: 定期的な作業項目の作成
description: 定期的に実行される作業項目の作成方法を説明します。
ms.author: normesta
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10、UWP、定期的な作業項目、スレッド、タイマー
ms.localizationpriority: medium
ms.openlocfilehash: 4afa137b01738c42f8e15c95ef09ec921d1e44ae
ms.sourcegitcommit: 93c0a60cf531c7d9fe7b00e7cf78df86906f9d6e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/21/2018
ms.locfileid: "7570315"
---
# <a name="create-a-periodic-work-item"></a>定期的な作業項目の作成


** 重要な API **

-   [**CreatePeriodicTimer**](https://msdn.microsoft.com/library/windows/apps/Hh967915)
-   [**ThreadPoolTimer**](https://msdn.microsoft.com/library/windows/apps/BR230587)

定期的に実行される作業項目の作成方法を説明します。

## <a name="create-the-periodic-work-item"></a>定期的な作業項目の作成

定期的な作業項目を作成するには、[**CreatePeriodicTimer**](https://msdn.microsoft.com/library/windows/apps/Hh967915) メソッドを使います。 作業を実行するラムダを指定し、*period* パラメーターを使って送信の間隔を指定します。 period パラメーターは [**TimeSpan**](https://msdn.microsoft.com/library/windows/apps/BR225996) 構造体を使って指定します。 この期間が経過するたびに作業項目が再送信されるため、作業を完了できる十分な長さを確保してください。

[**CreateTimer**](https://msdn.microsoft.com/library/windows/apps/windows.system.threading.threadpooltimer.createtimer.aspx) は [**ThreadPoolTimer**](https://msdn.microsoft.com/library/windows/apps/BR230587) オブジェクトを返します。 タイマーを取り消す必要が生じた場合は、このオブジェクトを格納します。

> **注:** 0 の値を指定することを避けるため (または 1 ミリ秒未満の値) の間隔をします。 この場合、定期タイマーは 1 回限りのタイマーとして動作します。

> **注:** を UI にアクセスし、作業項目の進捗状況を表示する[**CoreDispatcher.RunAsync**](https://msdn.microsoft.com/library/windows/apps/Hh750317)を使用することができます。

次の例では、60 秒ごとに 1 回実行される作業項目を作成します。

> [!div class="tabbedCodeSnippets"]
> ```csharp
> TimeSpan period = TimeSpan.FromSeconds(60);
>
> ThreadPoolTimer PeriodicTimer = ThreadPoolTimer.CreatePeriodicTimer((source) =>
>     {
>         //
>         // TODO: Work
>         //
>         
>         //
>         // Update the UI thread by using the UI core dispatcher.
>         //
>         Dispatcher.RunAsync(CoreDispatcherPriority.High,
>             () =>
>             {
>                 //
>                 // UI components can be accessed within this scope.
>                 //
>
>             });
>
>     }, period);
> ```
> ``` cpp
> TimeSpan period;
> period.Duration = 60 * 10000000; // 10,000,000 ticks per second
>
> ThreadPoolTimer ^ PeriodicTimer = ThreadPoolTimer::CreatePeriodicTimer(
>         ref new TimerElapsedHandler([this](ThreadPoolTimer^ source)
>         {
>             //
>             // TODO: Work
>             //
>             
>             //
>             // Update the UI thread by using the UI core dispatcher.
>             //
>             Dispatcher->RunAsync(CoreDispatcherPriority::High,
>                 ref new DispatchedHandler([this]()
>                 {
>                     //
>                     // UI components can be accessed within this scope.
>                     //
>                         
>                 }));
>
>         }), period);
> ```

## <a name="handle-cancellation-of-the-periodic-work-item-optional"></a>定期的な作業項目の取り消しの処理 (オプション)

必要であれば、[**TimerDestroyedHandler**](https://msdn.microsoft.com/library/windows/apps/Hh967926) を使って、定期タイマーの取り消しを処理できます。 定期的な作業項目の取り消しを処理するラムダを追加で指定するには、[**CreatePeriodicTimer**](https://msdn.microsoft.com/library/windows/apps/Hh967915) オーバーロードを使います。

次の例では、60 秒ごとに実行される定期的な作業項目を作成します。ここでは取り消しハンドラーも指定しています。

> [!div class="tabbedCodeSnippets"]
> ``` csharp
> using Windows.System.Threading;
>
>     TimeSpan period = TimeSpan.FromSeconds(60);
>
>     ThreadPoolTimer PeriodicTimer = ThreadPoolTimer.CreatePeriodicTimer((source) =>
>     {
>         //
>         // TODO: Work
>         //
>         
>         //
>         // Update the UI thread by using the UI core dispatcher.
>         //
>         Dispatcher.RunAsync(CoreDispatcherPriority.High,
>             () =>
>             {
>                 //
>                 // UI components can be accessed within this scope.
>                 //
>
>             });
>     },
>     period,
>     (source) =>
>     {
>         //
>         // TODO: Handle periodic timer cancellation.
>         //
>
>         //
>         // Update the UI thread by using the UI core dispatcher.
>         //
>         Dispatcher->RunAsync(CoreDispatcherPriority.High,
>             ()=>
>             {
>                 //
>                 // UI components can be accessed within this scope.
>                 //                 
>
>                 // Periodic timer cancelled.
>
>             }));
>     });
> ```
> ``` cpp
> using namespace Windows::System::Threading;
> using namespace Windows::UI::Core;
>
> TimeSpan period;
> period.Duration = 60 * 10000000; // 10,000,000 ticks per second
>
> ThreadPoolTimer ^ PeriodicTimer = ThreadPoolTimer::CreatePeriodicTimer(
>         ref new TimerElapsedHandler([this](ThreadPoolTimer^ source)
>         {
>             //
>             // TODO: Work
>             //
>                 
>             //
>             // Update the UI thread by using the UI core dispatcher.
>             //
>             Dispatcher->RunAsync(CoreDispatcherPriority::High,
>                 ref new DispatchedHandler([this]()
>                 {
>                     //
>                     // UI components can be accessed within this scope.
>                     //
>
>                 }));
>
>         }),
>         period,
>         ref new TimerDestroyedHandler([&](ThreadPoolTimer ^ source)
>         {
>             //
>             // TODO: Handle periodic timer cancellation.
>             //
>
>             Dispatcher->RunAsync(CoreDispatcherPriority::High,
>                 ref new DispatchedHandler([&]()
>                 {
>                     //
>                     // UI components can be accessed within this scope.
>                     //
>
>                     // Periodic timer cancelled.
>
>                 }));
>         }));
> ```

## <a name="cancel-the-timer"></a>タイマーの取り消し

必要に応じて [**Cancel**](https://msdn.microsoft.com/library/windows/apps/windows.system.threading.threadpooltimer.cancel.aspx) メソッドを呼び出し、定期的な作業項目の繰り返しを停止します。 定期タイマーが取り消されたときに作業項目が実行中だった場合には、完了するまで実行することができます。 定期的な作業項目のすべてのインスタンスが完了したときに、[**TimerDestroyedHandler**](https://msdn.microsoft.com/library/windows/apps/Hh967926) が呼び出されます (指定していた場合)。

> [!div class="tabbedCodeSnippets"]
> ``` csharp
> PeriodicTimer.Cancel();
> ```
> ``` cpp
> PeriodicTimer->Cancel();
> ```

## <a name="remarks"></a>注釈

1 回限りのタイマーについて詳しくは、「[タイマーを使った作業項目の送信](use-a-timer-to-submit-a-work-item.md)」をご覧ください。

## <a name="related-topics"></a>関連トピック

* [スレッド プールへの作業項目の送信](submit-a-work-item-to-the-thread-pool.md)
* [スレッド プールを使うためのベスト プラクティス](best-practices-for-using-the-thread-pool.md)
* [タイマーを使った作業項目の送信](use-a-timer-to-submit-a-work-item.md)
 
