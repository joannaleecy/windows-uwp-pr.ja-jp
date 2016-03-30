---
xx.xxxxxxx: YXYYYYYY-YXYY-YXYY-YYYX-XYXYYXYXYYXY
xxxxx: Xxxxxx x xxxxxxxx xxxx xxxx
xxxxxxxxxxx: Xxxxx xxx xx xxxxxx x xxxx xxxx xxxx xxxxxxx xxxxxxxxxxxx.
---
# Xxxxxx x xxxxxxxx xxxx xxxx

\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

** Xxxxxxxxx XXXx **

-   [**XxxxxxXxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/Hh967915)
-   [**XxxxxxXxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/BR230587)

Xxxxx xxx xx xxxxxx x xxxx xxxx xxxx xxxxxxx xxxxxxxxxxxx.

## Xxxxxx xxx xxxxxxxx xxxx xxxx

Xxx xxx [**XxxxxxXxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/Hh967915) xxxxxx xx xxxxxx x xxxxxxxx xxxx xxxx. Xxxxxx x xxxxxx xxxx xxxxxxxxxxxx xxx xxxx, xxx xxx xxx *xxxxxx* xxxxxxxxx xx xxxxxxx xxx xxxxxxxx xxxxxxx xxxxxxxxxxx. Xxx xxxxxx xx xxxxxxxxx xxxxx x [**XxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/BR225996) xxxxxxxxx. Xxx xxxx xxxx xxxx xx xxxxxxxxxxx xxxxx xxxx xxx xxxxxx xxxxxxx, xx xxxx xxxx xxx xxxxxx xx xxxx xxxxxx xxx xxxx xx xxxxxxxx.

[
            **XxxxxxXxxxx**](https://msdn.microsoft.com/en-us/library/windows/apps/windows.system.threading.threadpooltimer.createtimer.aspx) xxxxxxx x [**XxxxxxXxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/BR230587) xxxxxx. Xxxxx xxxx xxxxxx xx xxxx xxx xxxxx xxxxx xx xx xxxxxxxx.

> **Xxxx**  Xxxxx xxxxxxxxxx x xxxxx xx xxxx (xx xxx xxxxx xxxx xxxx xxx xxxxxxxxxxx) xxx xxx xxxxxxxx. Xxxx xxxxxx xxx xxxxxxxx xxxxx xx xxxxxx xx x xxxxxx-xxxx xxxxx xxxxxxx.

> **Xxxx**  Xxx xxx xxx [**XxxxXxxxxxxxxx.XxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/Hh750317) xx xxxxxx xxx XX xxx xxxx xxxxxxxx xxxx xxx xxxx xxxx.

Xxx xxxxxxxxx xxxxxxx xxxxxxx x xxxx xxxx xxxx xxxx xxxx xxxxx YY xxxxxxx:

> [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
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

## Xxxxxx xxxxxxxxxxxx xx xxx xxxxxxxx xxxx xxxx (xxxxxxxx)

Xx xxxxxx, xxx xxx xxxxxx xxxxxxxxxxxx xx xxx xxxxxxxx xxxxx xxxx x [**XxxxxXxxxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Hh967926). Xxx xxx [**XxxxxxXxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/Hh967915) xxxxxxxx xx xxxxxx xx xxxxxxxxxx xxxxxx xxxx xxxxxxx xxxxxxxxxxxx xx xxx xxxxxxxx xxxx xxxx.

Xxx xxxxxxxxx xxxxxxx xxxxxxx x xxxxxxxx xxxx xxxx xxxx xxxxxxx xxxxx YY xxxxxxx xxx xx xxxx xxxxxxxx x xxxxxxxxxxxx xxxxxxx:

> [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
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
>         ref new TimerDestroyedHandler([&amp;](ThreadPoolTimer ^ source)
>         {
>             // 
>             // TODO: Handle periodic timer cancellation.
>             // 
> 
>             Dispatcher->RunAsync(CoreDispatcherPriority::High,
>                 ref new DispatchedHandler([&amp;]()
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

## Xxxxxx xxx xxxxx

Xxxx xxxxxxxxx, xxxx xxx [**Xxxxxx**](https://msdn.microsoft.com/en-us/library/windows/apps/windows.system.threading.threadpooltimer.cancel.aspx) xxxxxx xx xxxx xxx xxxxxxxx xxxx xxxx xxxx xxxxxxxxx. Xx xxx xxxx xxxx xx xxxxxxx xxxx xxx xxxxxxxx xxxxx xx xxxxxxxxx xx xx xxxxxxx xx xxxxxxxx. Xxx [**XxxxxXxxxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Hh967926) (xx xxxxxxxx) xx xxxxxx xxxx xxx xxxxxxxxx xx xxx xxxxxxxx xxxx xxxx xxxx xxxxxxxxx.

> [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
> ``` csharp
> PeriodicTimer.Cancel();
> ```
> ``` cpp
> PeriodicTimer->Cancel();
> ```

## Xxxxxxx

Xxx xxxxxxxxxxx xxxxx xxxxxx-xxx xxxxxx, xxx [Xxx x xxxxx xx xxxxxx x xxxx xxxx](use-a-timer-to-submit-a-work-item.md).

## Xxxxxxx xxxxxx

* [Xxxxxx x xxxx xxxx xx xxx xxxxxx xxxx](submit-a-work-item-to-the-thread-pool.md)
* [Xxxx xxxxxxxxx xxx xxxxx xxx xxxxxx xxxx](best-practices-for-using-the-thread-pool.md)
* [Xxx x xxxxx xx xxxxxx x xxxx xxxx](use-a-timer-to-submit-a-work-item.md)
 

<!--HONumber=Mar16_HO1-->
