---
xx.xxxxxxx: XXXYYYXY-XYXY-YYYY-YYXY-YXYYYXYYYYXX
xxxxx: Xxx x xxxxx xx xxxxxx x xxxx xxxx
xxxxxxxxxxx: Xxxxx xxx xx xxxxxx x xxxx xxxx xxxx xxxx xxxxx x xxxxx xxxxxxx.
---
# Xxx x xxxxx xx xxxxxx x xxxx xxxx

\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

** Xxxxxxxxx XXXx **

-   [**Xxxxxxx.XX.Xxxx xxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR208383)
-   [**Xxxxxxx.Xxxxxx.Xxxxxxxxx xxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR229642)

Xxxxx xxx xx xxxxxx x xxxx xxxx xxxx xxxx xxxxx x xxxxx xxxxxxx.

## Xxxxxx x xxxxxx-xxxx xxxxx

Xxx xxx [**XxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/Hh967921) xxxxxx xx xxxxxx x xxxxx xxx xxx xxxx xxxx. Xxxxxx x xxxxxx xxxx xxxxxxxxxxxx xxx xxxx, xxx xxx xxx *xxxxx* xxxxxxxxx xx xxxxxxx xxx xxxx xxx xxxxxx xxxx xxxxx xxxxxx xx xxx xxxxxx xxx xxxx xxxx xx xx xxxxxxxxx xxxxxx. Xxx xxxxx xx xxxxxxxxx xxxxx x [**XxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/BR225996) xxxxxxxxx.

> **Xxxx**  Xxx xxx xxx [**XxxxXxxxxxxxxx.XxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/Hh750317) xx xxxxxx xxx XX xxx xxxx xxxxxxxx xxxx xxx xxxx xxxx.

Xxx xxxxxxxxx xxxxxxx xxxxxxx x xxxx xxxx xxxx xxxx xx xxxxx xxxxxxx:

> [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
> ``` csharp
> TimeSpan delay = TimeSpan.FromMinutes(3);
>             
> ThreadPoolTimer DelayTimer = ThreadPoolTimer.CreateTimer(
>     (source) =>
>     {
>         // 
>         // TODO: Work
>         // 
>         
>         // 
>         // Update the UI thread by using the UI core dispatcher.
>         // 
>         Dispatcher.RunAsync(
>             CoreDispatcherPriority.High,
>             () =>
>             {
>                 // 
>                 // UI components can be accessed within this scope.
>                 // 
> 
>             });
> 
>     }, delay);
> ```
> ``` cpp
> TimeSpan delay;
> delay.Duration = 3 * 60 * 10000000; // 10,000,000 ticks per second
> 
> ThreadPoolTimer ^ DelayTimer = ThreadPoolTimer::CreateTimer(
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
>                     ExampleUIUpdateMethod(&quot;Timer completed.&quot;);
> 
>                 }));
> 
>         }), delay);
> ```

## Xxxxxxx x xxxxxxxxxx xxxxxxx

Xx xxxxxx, xxxxxx xxxxxxxxxxxx xxx xxxxxxxxxx xx xxx xxxx xxxx xxxx x [**XxxxxXxxxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Hh967926). Xxx xxx [**XxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/Hh967921) xxxxxxxx xx xxxxxx xx xxxxxxxxxx xxxxxx. Xxxx xxxx xxxx xxx xxxxx xx xxxxxxxxx xx xxxx xxx xxxx xxxx xxxxxxxxx.

Xxx xxxxxxxxx xxxxxxx xxxxxxx x xxxxx xxxx xxxxxxx xxx xxxx xxxx, xxx xxxxx x xxxxxx xxxx xxx xxxx xxxx xxxxxxxx xx xxx xxxxx xx xxxxxxxxx:

> [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
> ``` csharp
> TimeSpan delay = TimeSpan.FromMinutes(3);
>             
> bool completed = false;
> 
> ThreadPoolTimer DelayTimer = ThreadPoolTimer.CreateTimer(
>     (source) =>
>     {
>         // 
>         // TODO: Work
>         // 
> 
>         // 
>         // Update the UI thread by using the UI core dispatcher.
>         // 
>         Dispatcher.RunAsync(
>                 CoreDispatcherPriority.High,
>                 () =>
>                 {
>                     // 
>                     // UI components can be accessed within this scope.
>                     // 
> 
>                 });
> 
>         completed = true;
>     },
>     delay,
>     (source) =>
>     {
>         // 
>         // TODO: Handle work cancellation/completion.
>         // 
> 
> 
>         // 
>         // Update the UI thread by using the UI core dispatcher.
>         // 
>         Dispatcher.RunAsync(
>             CoreDispatcherPriority.High,
>             () =>
>             {
>                 // 
>                 // UI components can be accessed within this scope.
>                 // 
> 
>                 if (completed)
>                 {
>                     // Timer completed.
>                 }
>                 else
>                 {
>                     // Timer cancelled.
>                 }
> 
>             });
>     });
> ```
> ``` cpp
> TimeSpan delay;
> delay.Duration = 3 * 60 * 10000000; // 10,000,000 ticks per second
> 
> completed = false;
> 
> ThreadPoolTimer ^ DelayTimer = ThreadPoolTimer::CreateTimer(
>         ref new TimerElapsedHandler([&amp;](ThreadPoolTimer ^ source)
>         {
>             // 
>             // TODO: Work
>             // 
> 
>             // 
>             // Update the UI thread by using the UI core dispatcher.
>             // 
>             Dispatcher->RunAsync(CoreDispatcherPriority::High,
>                 ref new DispatchedHandler([&amp;]()
>                 {
>                     // 
>                     // UI components can be accessed within this scope.
>                     // 
> 
>                 }));
> 
>             completed = true;
> 
>         }),
>         delay,
>         ref new TimerDestroyedHandler([&amp;](ThreadPoolTimer ^ source)
>         {
>             // 
>             // TODO: Handle work cancellation/completion.
>             // 
> 
>             Dispatcher->RunAsync(CoreDispatcherPriority::High,
>                 ref new DispatchedHandler([&amp;]()
>                 {
>                     // 
>                     // Update the UI thread by using the UI core dispatcher.
>                     // 
> 
>                     if (completed)
>                     {
>                         // Timer completed.
>                     }
>                     else
>                     {
>                         // Timer cancelled.
>                     }
> 
>                 }));
>         }));
> ```

## Xxxxxx xxx xxxxx

Xx xxx xxxxx xx xxxxx xxxxxxxx xxxx, xxx xxx xxxx xxxx xx xx xxxxxx xxxxxx, xxxx [**Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR230588). Xxx xxxxx xx xxxxxxxxx xxx xxx xxxx xxxx xxx'x xx xxxxxxxxx xx xxx xxxxxx xxxx.

> [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
> ``` csharp
> DelayTimer.Cancel();
> ```
> ``` cpp
> DelayTimer->Cancel();
> ```

## Xxxxxxx

Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx xxx'x xxx **Xxxxxx.Xxxxx** xxxxxxx xx xxx xxxxx xxx XX xxxxxx. Xxx xxx xxx x [**XxxxxxXxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/BR230587) xx xxxxxx x xxxx xxxx xxxxxxx, xxx xxxx xxxx xxxxx xxx xxxx xxxxxxxxxxxx xx xxx xxxx xxxx xxxxxxx xxxxxxxx xxx XX xxxxxx.

Xxx xxx [xxxxxx xxxx xxxxxx](http://go.microsoft.com/fwlink/p/?linkid=255387) xxx x xxxxxxxx xxxx xxxxxx xxxx xxxxxxxxxxxx xxxx xxxxx, xxxxx xxxx xxxxx, xxx xxxxxxxx xxxx xxxxx. Xxx xxxx xxxxxx xxx xxxxxxxxxx xxxxxxx xxx Xxxxxxx Y.Y xxx xxx xxxx xxx xx xx-xxxx xx Xxxxxxx YY.

Xxx xxxxxxxxxxx xxxxx xxxxxxxxx xxxxxx, xxx [Xxxxxx x xxxxxxxx xxxx xxxx](create-a-periodic-work-item.md).

## Xxxxxxx xxxxxx

* [Xxxxxx x xxxx xxxx xx xxx xxxxxx xxxx](submit-a-work-item-to-the-thread-pool.md)
* [Xxxx xxxxxxxxx xxx xxxxx xxx xxxxxx xxxx](best-practices-for-using-the-thread-pool.md)
* [Xxx x xxxxx xx xxxxxx x xxxx xxxx](use-a-timer-to-submit-a-work-item.md)
 

 

<!--HONumber=Mar16_HO1-->
