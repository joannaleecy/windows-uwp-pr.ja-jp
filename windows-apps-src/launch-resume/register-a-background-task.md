---
xxxxx: Xxxxxxxx x xxxxxxxxxx xxxx
xxxxxxxxxxx: Xxxxx xxx xx xxxxxx x xxxxxxxx xxxx xxx xx xx-xxxx xx xxxxxx xxxxxxxx xxxx xxxxxxxxxx xxxxx.
xx.xxxxxxx: YXYXXXXY-XYYY-YYXY-XYXX-YXXYYXYXXXYX
---

# Xxxxxxxx x xxxxxxxxxx xxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


**Xxxxxxxxx XXXx**

-   [**XxxxxxxxxxXxxxXxxxxxxxxxxx xxxxx**](https://msdn.microsoft.com/library/windows/apps/br224786)
-   [**XxxxxxxxxxXxxxXxxxxxx xxxxx**](https://msdn.microsoft.com/library/windows/apps/br224768)
-   [**XxxxxxXxxxxxxxx xxxxx**](https://msdn.microsoft.com/library/windows/apps/br224834)

Xxxxx xxx xx xxxxxx x xxxxxxxx xxxx xxx xx xx-xxxx xx xxxxxx xxxxxxxx xxxx xxxxxxxxxx xxxxx.

Xxxx xxxxx xxxxxxx xxxx xxx xxxxxxx xxxx x xxxxxxxxxx xxxx xxxx xxxxx xx xx xxxxxxxxxx. (Xxx [Xxxxxx xxx xxxxxxxx x xxxxxxxxxx xxxx](create-and-register-a-background-task.md) xxx xxxxxxxxxxx xxxxx xxx xx xxxxx x xxxxxxxxxx xxxx).

Xxxx xxxxx xxxxx xxxxxxx x xxxxxxx xxxxxxxx xxxx xxxxxxxxx xxxxxxxxxx xxxxx. Xxxx xxxxxxx xxxxxxxx xxxxxx xxx xxxxxxxx xxxxxxxxxxxxx xxxxx xxxxxx xxxxxxxxxxx xxx xxxx xxxxxxxx xxxxx xx xxxxx xxxxxxxx xxxx xxxxxxxx xxxxxxxxxxxxx, xxx xx xxx xxxxx x xxxxxx xxxxxxxxx xx xxx xxxxxxxxxx xxxx. Xxx xxxxxxxxxxx xxxxxxxx x xxxxxxxx, xxxxxxx xxxxxxx xx xxxx xxxxxxx xxxxxxxx.

**Xxxx**  

Xxxxxxxxx Xxxxxxx xxxx xxxx xxxx [**XxxxxxxXxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/hh700485) xxxxxx xxxxxxxxxxx xxx xx xxx xxxxxxxxxx xxxxxxx xxxxx.

Xx xxxxxx xxxx xxxx Xxxxxxxxx Xxxxxxx xxx xxxxxxxxx xx xxx xxxxxxxx xxxxx xxx xxxxxxx xx xxxxxx, xxx xxxx xxxx [**XxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh700471) xxx xxxx xxxx [**XxxxxxxXxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/hh700485) xxxx xxxx xxx xxxxxxxx xxxxx xxxxx xxxxxxx. Xxx xxxx xxxxxxxxxxx, xxx [Xxxxxxxxxx xxx xxxxxxxxxx xxxxx](guidelines-for-background-tasks.md).

## Xxxxxx xxx xxxxxx xxxxxxxxx xxx xxxxxx xxxx


Xxxx xxxxxx xxxxx xx xxx xxxx xxxxx xxxxx, xxxx xxxx, x xxx-xxxxxxxxxxx xxxxxxxxxx xxxx xxxxxxx, xxx (xxxxxxxxxx) x [**XxxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br224834) xxx xxx xxxxxxxxxx xxxx. Xxxx xxxxxx xxxxxxx x [**XxxxxxxxxxXxxxXxxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br224786) xxxxxx.

> [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
> ```cs
> public static BackgroundTaskRegistration RegisterBackgroundTask(
>                                                 string taskEntryPoint, 
>                                                 string name,
>                                                 IBackgroundTrigger trigger,
>                                                 IBackgroundCondition condition)
> {
>     
>     // We’ll add code to this function in subsequent steps.
> 
> }
> ```
> ```cpp
> BackgroundTaskRegistration^ MainPage::RegisterBackgroundTask(
>                                              Platform::String ^ taskEntryPoint,
>                                              Platform::String ^ taskName,
>                                              IBackgroundTrigger ^ trigger,
>                                              IBackgroundCondition ^ condition)
> {
>     
>     // We’ll add code to this function in subsequent steps.
> 
> }
> ```

## Xxxxx xxx xxxxxxxx xxxxxxxxxxxxx


Xxxxx xxxxxxx xxx xxxx xx xxxxxxx xxxxxxxxxx. Xx'x xxxxxxxxx xx xxxxx xxxx xxxxxxx xx x xxxx xx xxxxxxxxxx xxxxxxxx xxxxx, xx xxxx xxx xxxx xxxx xxxx xxxxxxxx xx’x xxxxxxxxx; xxxx xxx xxx xxxxxx XXX xxx xxx xxxxx xxxxxxxxxx xxxxxxxx.

Xxx xxx xxxxx xxx xxxxxxxx xxxxxxxxxxxxx xx xxxxxxxx xxx [**XxxxxxxxxxXxxxXxxxxxxxxxxx.XxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br224787) xxxxxxxx xxx xxxxxxxxx xx xxx xxxxxx. Xxxxx xxx xxxx xx xxxx xxxxxxxx – xx xx xxxxxxx xxx xxxx xx xxx xxxx xxx’xx xxxxxxxxxxx, xxxx xxxxx xxx xx xxx xxxx xxx xxx x xxxx xxxxxxxx xx xxxx xxxx xxxx xxx xxxxxx x xxxxxxxxx xxxx xx xxx xxxx xxxx.

> **Xxxx**  Xxx xxxxxxxxxx xxxx xxxxx xxxx xxx xxxxxx xx xxxx xxx. Xxxxxx xxxx xxxxxxxxxx xxxx xxx x xxxxxx xxxx.

Xxx xxxxxxxxx xxxx xxxxxxxxx x xxxxxxxxxx xxxx xxxxx xxx [**XxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br224838) xx xxxxxxx xx xxx xxxx xxxx:

> [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
> ```cs
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
>     // We’ll register the task in the next step.
> }
> ```
> ```cpp
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
>     // We’ll register the task in the next step.
> }
> ```

## Xxxxxxxx xxx xxxxxxxxxx xxxx (xx xxxxxx xxx xxxxxxxx xxxxxxxxxxxx)


Xxxxx xx xxx xx xxx xxxx xxx xxxxx xx xxx xxxx xx xxxxxxxx xxxxxxxxxx xxxx xxxxxxxxxxxxx. Xx xx, xxxxxx xxxx xxxxxxxx xx xxx xxxx.

Xxxx, xxxxxxxx xxx xxxx xxxxx x xxx [**XxxxxxxxxxXxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br224768) xxxxxx. Xxxx xxxx xxxxxx xxxxx xxxxxxx xxx xxxxxxxxx xxxxxxxxx xx xxxx, xxx xx xxx, xxx xxx xxxxxxxxx xx xxx xxxxxxxxxxxx xxxxxx. Xxxxxx xxx [**XxxxxxxxxxXxxxXxxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br224786) xxxxxxxx xx xxx [**XxxxxxxxxxXxxxXxxxxxx.Xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br224772) xxxxxx.

> **Xxxx**  Xxxxxxxxxx xxxx xxxxxxxxxxxx xxxxxxxxxx xxx xxxxxxxxx xx xxx xxxx xx xxxxxxxxxxxx. Xx xxxxx xx xxxxxxxx xx xxx xx xxx xxxxxxxxxxxx xxxxxxxxxx xxx xxxxxxx. Xxxxxx xxxx xxxx xxx xxxxxxxxxx xxxxxxx xxxxxxxxx xxxxx xxxxxxxxxx xxxx xxxxxxxxxxxx xxxxx - xx xxxxxxx xxxx xxx xxxxxxx xx xxxxxx x xxxxx xxxxxxxxxxxx xxxxxx xxxxx xxxxxxxxxx xx xxxxxxxx x xxxx, xx xxx xxxxx.

Xxx xxxxxxxxx xxxxxxx xxxxxx xxxxxxx xxx xxxxxxxx xxxx, xx xxxx xxxx xxxx xxxxxxxxx xxx xxxxxxxxxx xxxx (xxxxxxxxx xxx xxxxxxxx xxxxxx xxxxxxxxx xx xxxxxxx):

> [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
> ```cs
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
> ```cpp
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

## Xxxxxxxx xxxxxxxxxx xxxx xxxxxxxxxxxx xxxxxxx xxxxxxxx


Xxxx xxxxxxx xxxxx xxx xxxxxxxxx xxxxxxxxxx xxxx xxxxxxxxxxxx xxxxxxxx. Xxxx xxxxxxxx xxx xx xxxx xx xxxxxxxx xxxx xxxxxxxxxx xxxxx, xxxx xxx xxxxxxxxx xx xxxxxxxxxx xxxxxxxxxx xxxxx.

> [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
> ```cs
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
> ```cpp
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

> **Xxxx**  Xxxx xxxxxxx xx xxx Xxxxxxx YY xxxxxxxxxx xxxxxxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx. Xx xxx’xx xxxxxxxxxx xxx Xxxxxxx Y.x xx Xxxxxxx Xxxxx Y.x, xxx xxx [xxxxxxxx xxxxxxxxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132).

 
## Xxxxxxx xxxxxx


****

* [Xxxxxx xxx xxxxxxxx x xxxxxxxxxx xxxx](create-and-register-a-background-task.md)
* [Xxxxxxx xxxxxxxxxx xxxxx xx xxx xxxxxxxxxxx xxxxxxxx](declare-background-tasks-in-the-application-manifest.md)
* [Xxxxxx x xxxxxxxxx xxxxxxxxxx xxxx](handle-a-cancelled-background-task.md)
* [Xxxxxxx xxxxxxxxxx xxxx xxxxxxxx xxx xxxxxxxxxx](monitor-background-task-progress-and-completion.md)
* [Xxxxxxx xx xxxxxx xxxxxx xxxx xxxxxxxxxx xxxxx](respond-to-system-events-with-background-tasks.md)
* [Xxx xxxxxxxxxx xxx xxxxxxx x xxxxxxxxxx xxxx](set-conditions-for-running-a-background-task.md)
* [Xxxxxx x xxxx xxxx xxxx x xxxxxxxxxx xxxx](update-a-live-tile-from-a-background-task.md)
* [Xxx x xxxxxxxxxxx xxxxxxx](use-a-maintenance-trigger.md)
* [Xxx x xxxxxxxxxx xxxx xx x xxxxx](run-a-background-task-on-a-timer-.md)
* [Xxxxxxxxxx xxx xxxxxxxxxx xxxxx](guidelines-for-background-tasks.md)

****

* [Xxxxx x xxxxxxxxxx xxxx](debug-a-background-task.md)
* [Xxx xx xxxxxxx xxxxxxx, xxxxxx, xxx xxxxxxxxxx xxxxxx xx Xxxxxxx Xxxxx xxxx (xxxx xxxxxxxxx)](http://go.microsoft.com/fwlink/p/?linkid=254345)

 

 



<!--HONumber=Mar16_HO1-->
