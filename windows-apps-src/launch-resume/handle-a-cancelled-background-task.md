---
xxxxx: Xxxxxx x xxxxxxxxx xxxxxxxxxx xxxx
xxxxxxxxxxx: Xxxxx xxx xx xxxx x xxxxxxxxxx xxxx xxxx xxxxxxxxxx xxxxxxxxxxxx xxxxxxxx xxx xxxxx xxxx, xxxxxxxxx xxx xxxxxxxxxxxx xx xxx xxx xxxxx xxxxxxxxxx xxxxxxx.
xx.xxxxxxx: XYXYYYYY-XYXY-YYYY-YYYX-YYYXXYXYYYYX
---

# Xxxxxx x xxxxxxxxx xxxxxxxxxx xxxx

\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

**Xxxxxxxxx XXXx**

-   [**XxxxxxxxxxXxxxXxxxxxxxXxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br224775)
-   [**XXxxxxxxxxxXxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br224797)
-   [**XxxxxxxxxxxXxxx.Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br241619)

Xxxxx xxx xx xxxx x xxxxxxxxxx xxxx xxxx xxxxxxxxxx xxxxxxxxxxxx xxxxxxxx xxx xxxxx xxxx, xxxxxxxxx xxx xxxxxxxxxxxx xx xxx xxx xxxxx xxxxxxxxxx xxxxxxx.

> **Xxxx**  Xxx xxx xxxxxx xxxxxxxx xxxxxx xxxxxxx, xx xxx xxxxxx xxxxxxx xxx xx xxxxxx, xxxxxxxxxx xxxxx xxx xx xxxxxxxxxx. Xx xx xxx xx xxxxxx xxxxxxxxx xx xxx xxxxxxxx, xx xxx xxx xxxx xxx xxxxxx xx, xxxx xxx xxxxxxxxxx xxxx xxxx xx xxxxxxxxxx xxxxxxx xxxxxxx xxx xxxxxxx xxxxxxx xxx XxXxxxxxxx xxxxx. Xxxx xxxxx xx xxxxxx xxx xxxx xxxxxxxxxx xx xxx xxx xx xxx xxxxxxxxxx. Xxxx xxxxxxxxxx xxxx xxxxxx xx xxxxxxxx xx xxxxxx xxxx xxxxxxxx.

Xxxx xxxxx xxxxxxx xxx xxxx xxxxxxx xxxxxxx x xxxxxxxxxx xxxx xxxxx, xxxxxxxxx xxx Xxx xxxxxx xxxx xx xxxx xx xxx xxxxxxxxxx xxxx xxxxx xxxxx. Xx xxx xxxxxxx xxxxxxx xxxxxxxx x xxxxxxxxxx xxxx, xxx [Xxxxxx xxx xxxxxxxx x xxxxxxxxxx xxxx](create-and-register-a-background-task.md). Xxx xxxx xx-xxxxx xxxxxxxxxxx xx xxxxxxxxxx xxx xxxxxxxx, xxx [Xxxxxxx xxxx xxx xxxx xxxxxxxxxx xxxxx](support-your-app-with-background-tasks.md).

## Xxx xxx XxXxxxxxxx xxxxxx xx xxxxxxxxx xxxxxxxxxxxx xxxxxxxx

Xxxxx x xxxxxx xx xxxxxx xxx xxxxxxxxxxxx xxxxx.

Xxxxxx x xxxxxx xxxxx XxXxxxxxxx xxxx xxx xxx xxxxxxxxx xxxxxxxxx. Xxxx xxxxxx xx xxx xxxxx xxxxx xxxxxx xx xxx Xxxxxxx Xxxxxxx xxxxxxxx x xxxxxxxxxxxx xxxxxxx xx xxxx xxxxxxx xxxx xxxxxxxxxx xxxx.

Xxx XxXxxxxxxx xxxxxx xxxxx xx xxxx xxx xxxxxxxxx xxxxxxxxx:

> [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
> ```cs
>    private void OnCanceled(IBackgroundTaskInstance sender, BackgroundTaskCancellationReason reason)
>    {
>        // TODO: Add code to notify the background task that it is cancelled.
>    }
> ```
> ```cpp
>    void ExampleBackgroundTask::OnCanceled(IBackgroundTaskInstance^ taskInstance, BackgroundTaskCancellationReason reason)
>    {
>        // TODO: Add code to notify the background task that it is cancelled.
>    }
> ```

Xxx x xxxx xxxxxxxx xxxxxx **\_XxxxxxXxxxxxxxx** xx xxx xxxxxxxxxx xxxx xxxxx. Xxxx xxxxxxxx xxxx xx xxxx xx xxxxxxxx xxxx x xxxxxxxxxxxx xxxxxxx xxx xxxx xxxx.

> [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
> ```cs
>   volatile bool _CancelRequested = false;
> ```
> ```cpp
>   private:
>     volatile bool CancelRequested;
> ```

Xx xxx XxXxxxxxxx xxxxxx xxx xxxxxxx xx xxxx Y, xxx xxx xxxx xxxxxxxx **\_XxxxxxXxxxxxxxx** xx **xxxx**.

Xxx xxxx [xxxxxxxxxx xxxx xxxxxx]( http://go.microsoft.com/fwlink/p/?linkid=227509) XxXxxxxxxx xxxxxx xxxx **\_XxxxxxXxxxxxxxx** xx **xxxx** xxx xxxxxx xxxxxxxxxxx xxxxxx xxxxx xxxxxx:

> [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
> ```cs
>     private void OnCanceled(IBackgroundTaskInstance sender, BackgroundTaskCancellationReason reason)
>     {
>         //
>         // Indicate that the background task is canceled.
>         //
> 
>         _cancelRequested = true;
> 
>         Debug.WriteLine("Background " + sender.Task.Name + " Cancel Requested...");
>     }
> ```
> ```cpp
>     void SampleBackgroundTask::OnCanceled(IBackgroundTaskInstance^ taskInstance, BackgroundTaskCancellationReason reason)
>     {
>         //
>         // Indicate that the background task is canceled.
>         //
> 
>         CancelRequested = true;
>     }
> ```

Xx xxx xxxxxxxxxx xxxx'x Xxx xxxxxx, xxxxxxxx xxx XxXxxxxxxx xxxxx xxxxxxx xxxxxx xxxxxx xxxxxxxx xxxx. Xxx xxxxxxx, xxx xxx xxxxxxxxx xxxx xx xxxx:

> [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
> ```cs
>     taskInstance.Canceled += new BackgroundTaskCanceledEventHandler(OnCanceled);
> ```
> ```cpp
>     taskInstance->Canceled += ref new BackgroundTaskCanceledEventHandler(this, &SampleBackgroundTask::OnCanceled);
> ```

## Xxxxxx xxxxxxxxxxxx xx xxxxxxx xxx Xxx xxxxxx


Xxxx x xxxxxxxxxxxx xxxxxxx xx xxxxxxxx, xxx Xxx xxxxxx xxxxx xx xxxx xxxx xxx xxxx xx xxxxxxxxxxx xxxx **\_xxxxxxXxxxxxxxx** xx xxx xx **xxxx**.

Xxxxxx xxx xxxx xx xxxx xxxxxxxxxx xxxx xxxxx xx xxxxx xxx xxxx xxxxxxxx xxxxx xx'x xxxxxxx. Xx **\_xxxxxxXxxxxxxxx** xxx xx xxxx, xxxx xxxx xxxx xxxxxxxxxx.

Xxx [xxxxxxxxxx xxxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkId=618666) xxxxxxxx x xxxxx xxxx xxxxx xxx xxxxxxxx xxxxx xxxxxxxx xx xxx xxxxxxxxxx xxxx xx xxxxxxxx:

> [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
> ```cs
>     if ((_cancelRequested == false) &amp;&amp; (_progress &lt; 100))
>     {
>         _progress += 10;
>         _taskInstance.Progress = _progress;
>     }
>     else
>     {
>         _periodicTimer.Cancel();
> 
>         // TODO: Record whether the task completed or was cancelled.
>     }
> ```
> ```cpp
>     if ((CancelRequested == false) &amp;&amp; (Progress &lt; 100))
>     {
>         Progress += 10;
>         TaskInstance->Progress = Progress;
>     }
>     else
>     {
>         PeriodicTimer->Cancel();
> 
>         // TODO: Record whether the task completed or was cancelled.
>     }
> ```

> **Xxxx**  Xxx xxxx xxxxxx xxxxx xxxxx xxxx xxx [**XXxxxxxxxxxXxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br224797).[**Xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br224800) xxxxxxxx xxxxx xxxx xx xxxxxx xxxxxxxxxx xxxx xxxxxxxx. Xxxxxxxx xx xxxxxxxx xxxx xx xxx xxx xxxxx xxx [**XxxxxxxxxxXxxxXxxxxxxxXxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br224782) xxxxx.

Xxxxxx xxx Xxx xxxxxx xx xxxx xxxxx xxxx xxx xxxxxxx, xx xxxxxxx xxxxxxx xxx xxxx xxxxxxxxx xx xxx xxxxxxxxx.

Xxx [xxxxxxxxxx xxxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkId=618666) xxxxxxx xxxxxx xx XxxxxXxxxxxxx:

> [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
> ```cs
>     if ((_cancelRequested == false) &amp;&amp; (_progress &lt; 100))
>     {
>         _progress += 10;
>         _taskInstance.Progress = _progress;
>     }
>     else
>     {
>         _periodicTimer.Cancel();
> 
>         var settings = ApplicationData.Current.LocalSettings;
>         var key = _taskInstance.Task.TaskId.ToString();
> 
>         //
>         // Write to LocalSettings to indicate that this background task ran.
>         //
> 
>         if (_cancelRequested)
>         {
>             settings.Values[key] = "Canceled";
>         }
>         else
>         {
>             settings.Values[key] = "Completed";
>         }
>         
>         Debug.WriteLine("Background " + _taskInstance.Task.Name + (_cancelRequested ? " Canceled" : " Completed"));
>         
>         //
>         // Indicate that the background task has completed.
>         //
> 
>         _deferral.Complete();
>     }
> ```
> ```cpp
>     if ((CancelRequested == false) &amp;&amp; (Progress &lt; 100))
>     {
>         Progress += 10;
>         TaskInstance->Progress = Progress;
>     }
>     else
>     {
>         PeriodicTimer->Cancel();
>         
>         //
>         // Write to LocalSettings to indicate that this background task ran.
>         //
>         
>         auto settings = ApplicationData::Current->LocalSettings;
>         auto key = TaskInstance->Task->Name;
>         settings->Values->Insert(key, (Progress &lt; 100) ? "Canceled" : "Completed");
>         
>         //
>         // Indicate that the background task has completed.
>         //
>         
>         Deferral->Complete();
>     }
> ```

## Xxxxxxx

Xxx xxx xxxxxxxx xxx [xxxxxxxxxx xxxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkId=618666) xx xxx xxxxx xxxx xxxxxxxx xx xxx xxxxxxx xx xxxxxxx.

Xxx xxxxxxxxxxxx xxxxxxxx, xxx xxxxxx xxxx xxxxx xxxx xxxxxxxx xx xxx Xxx xxxxxx (xxx xxxxxxxx xxxxx) xxxx xxx [xxxxxxxxxx xxxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkId=618666).

## Xxx xxxxxx xxxxxxx

Xxx xxxxxxxx Xxx xxxxxx, xxx xxxxx xxxxxxxx xxxx, xxxx xxx [xxxxxxxxxx xxxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkId=618666) xxx xxxxx xxxxx xxx xxxxxxx:

> [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
> ```cs
> //
> // The Run method is the entry point of a background task.
> //
> public void Run(IBackgroundTaskInstance taskInstance)
> {
>     Debug.WriteLine("Background " + taskInstance.Task.Name + " Starting...");
> 
>     //
>     // Query BackgroundWorkCost
>     // Guidance: If BackgroundWorkCost is high, then perform only the minimum amount
>     // of work in the background task and return immediately.
>     //
>     var cost = BackgroundWorkCost.CurrentBackgroundWorkCost;
>     var settings = ApplicationData.Current.LocalSettings;
>     settings.Values["BackgroundWorkCost"] = cost.ToString();
> 
>     //
>     // Associate a cancellation handler with the background task.
>     //
>     taskInstance.Canceled += new BackgroundTaskCanceledEventHandler(OnCanceled);
> 
>     //
>     // Get the deferral object from the task instance, and take a reference to the taskInstance;
>     //
>     _deferral = taskInstance.GetDeferral();
>     _taskInstance = taskInstance;
> 
>     _periodicTimer = ThreadPoolTimer.CreatePeriodicTimer(new TimerElapsedHandler(PeriodicTimerCallback), TimeSpan.FromSeconds(1));
> }
> 
> //
> // Simulate the background task activity.
> //
> private void PeriodicTimerCallback(ThreadPoolTimer timer)
> {
>     if ((_cancelRequested == false) &amp;&amp; (_progress < 100))
>     {
>         _progress += 10;
>         _taskInstance.Progress = _progress;
>     }
>     else
>     {
>         _periodicTimer.Cancel();
> 
>         var settings = ApplicationData.Current.LocalSettings;
>         var key = _taskInstance.Task.Name;
> 
>         //
>         // Write to LocalSettings to indicate that this background task ran.
>         //
>         settings.Values[key] = (_progress < 100) ? "Canceled with reason: " + _cancelReason.ToString() : "Completed";
>         Debug.WriteLine("Background " + _taskInstance.Task.Name + settings.Values[key]);
> 
>         //
>         // Indicate that the background task has completed.
>         //
>         _deferral.Complete();
>     }
> }
> ```
> ```cpp
> void SampleBackgroundTask::Run(IBackgroundTaskInstance^ taskInstance)
> {
>     //
>     // Query BackgroundWorkCost
>     // Guidance: If BackgroundWorkCost is high, then perform only the minimum amount
>     // of work in the background task and return immediately.
>     //
>     auto cost = BackgroundWorkCost::CurrentBackgroundWorkCost;
>     auto settings = ApplicationData::Current->LocalSettings;
>     settings->Values->Insert("BackgroundWorkCost", cost.ToString());
> 
>     //
>     // Associate a cancellation handler with the background task.
>     //
>     taskInstance->Canceled += ref new BackgroundTaskCanceledEventHandler(this, &amp;SampleBackgroundTask::OnCanceled);
> 
>     //
>     // Get the deferral object from the task instance, and take a reference to the taskInstance.
>     //
>     TaskDeferral = taskInstance->GetDeferral();
>     TaskInstance = taskInstance;
> 
>     auto timerDelegate = [this](ThreadPoolTimer^ timer)
>     {
>         if ((CancelRequested == false) &amp;&amp;
>             (Progress < 100))
>         {
>             Progress += 10;
>             TaskInstance->Progress = Progress;
>         }
>         else
>         {
>             PeriodicTimer->Cancel();
> 
>             //
>             // Write to LocalSettings to indicate that this background task ran.
>             //
>             auto settings = ApplicationData::Current->LocalSettings;
>             auto key = TaskInstance->Task->Name;
>             settings->Values->Insert(key, (Progress < 100) ? "Canceled with reason: " + CancelReason.ToString() : "Completed");
> 
>             //
>             // Indicate that the background task has completed.
>             //
>             TaskDeferral->Complete();
>         }
>     };
> 
>     TimeSpan period;
>     period.Duration = 1000 * 10000; // 1 second
>     PeriodicTimer = ThreadPoolTimer::CreatePeriodicTimer(ref new TimerElapsedHandler(timerDelegate), period);
> }
> ```

> **Xxxx**  Xxxx xxxxxxx xx xxx Xxxxxxx YY xxxxxxxxxx xxxxxxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx. Xx xxx’xx xxxxxxxxxx xxx Xxxxxxx Y.x xx Xxxxxxx Xxxxx Y.x, xxx xxx [xxxxxxxx xxxxxxxxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132).

## Xxxxxxx xxxxxx

* [Xxxxxx xxx xxxxxxxx x xxxxxxxxxx xxxx](create-and-register-a-background-task.md)
* [Xxxxxxx xxxxxxxxxx xxxxx xx xxx xxxxxxxxxxx xxxxxxxx](declare-background-tasks-in-the-application-manifest.md)
* [Xxxxxxxxxx xxx xxxxxxxxxx xxxxx](guidelines-for-background-tasks.md)
* [Xxxxxxx xxxxxxxxxx xxxx xxxxxxxx xxx xxxxxxxxxx](monitor-background-task-progress-and-completion.md)
* [Xxxxxxxx x xxxxxxxxxx xxxx](register-a-background-task.md)
* [Xxxxxxx xx xxxxxx xxxxxx xxxx xxxxxxxxxx xxxxx](respond-to-system-events-with-background-tasks.md)
* [Xxx x xxxxxxxxxx xxxx xx x xxxxx](run-a-background-task-on-a-timer-.md)
* [Xxx xxxxxxxxxx xxx xxxxxxx x xxxxxxxxxx xxxx](set-conditions-for-running-a-background-task.md)
* [Xxxxxx x xxxx xxxx xxxx x xxxxxxxxxx xxxx](update-a-live-tile-from-a-background-task.md)
* [Xxx x xxxxxxxxxxx xxxxxxx](use-a-maintenance-trigger.md)

* [Xxxxx x xxxxxxxxxx xxxx](debug-a-background-task.md)
* [Xxx xx xxxxxxx xxxxxxx, xxxxxx, xxx xxxxxxxxxx xxxxxx xx Xxxxxxx Xxxxx xxxx (xxxx xxxxxxxxx)](http://go.microsoft.com/fwlink/p/?linkid=254345)



<!--HONumber=Mar16_HO1-->
