---
xxxxx: Xxxxxx xxx xxxxxxxx x xxxxxxxxxx xxxx
xxxxxxxxxxx: Xxxxxx x xxxxxxxxxx xxxx xxxxx xxx xxxxxxxx xx xx xxx xxxx xxxx xxx xx xxx xx xxx xxxxxxxxxx.
xx.xxxxxxx: YXYYXYXY-YXYX-YXXX-XXYX-YYXXYYXXYYYX
---

# Xxxxxx xxx xxxxxxxx x xxxxxxxxxx xxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


**Xxxxxxxxx XXXx**

-   [**XXxxxxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br224794)
-   [**XxxxxxxxxxXxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br224768)
-   [**XxxxxxxxxxXxxxXxxxxxxxxXxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br224781)

Xxxxxx x xxxxxxxxxx xxxx xxxxx xxx xxxxxxxx xx xx xxx xxxx xxxx xxx xx xxx xx xxx xxxxxxxxxx.

## Xxxxxx xxx Xxxxxxxxxx Xxxx xxxxx


Xxx xxx xxx xxxx xx xxx xxxxxxxxxx xx xxxxxxx xxxxxxx xxxx xxxxxxxxx xxx [**XXxxxxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br224794) xxxxxxxxx. Xxxx xxxx xxxx xxx xxxx x xxxxxxxx xxxxx xx xxxxxxxxx xx xxxxx, xxx xxxxxxx, [**XxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br224839) xx [**XxxxxxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh700517).

Xxx xxxxxxxxx xxxxx xxxx xxx xxx xx xxxxx x xxx xxxxx xxxx xxxxxxxxxx xxx [**XXxxxxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br224794) xxxxxxxxx. Xxxxxx xxxxxxx xxxxxxx, xxxxxx x xxx xxxxxxx xx xxxx xxxxxxxx xxx xxxxxxxxxx xxxxx. Xxx x xxx xxxxx xxxxx xxx xxxx xxxxxxxxxx xxxx xxx xxxxxx xxx [Xxxxxxx.XxxxxxxxxxxXxxxx.Xxxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/br224847) xxxxxxxxx.

1.  Xxxxxx x xxx xxxxxxx xxx xxxxxxxxxx xxxxx xxx xxx xx xx xxxx xxxxxxxx. Xx xx xxxx, xxxxx-xxxxx xx xxxx xxxxxxxx xxxx xx xxx **Xxxxxxxx Xxxxxxxx** xxx xxxxxx Xxx-&xx;Xxx Xxxxxxx. Xxxx xxxxxx xxx **Xxxxxxx Xxxxxxx Xxxxxxxxx (Xxxxxxxxx Xxxxxxx)** xxxxxxx xxxx, xxxx xxx xxxxxxx, xxx xxxxx XX.
2.  Xxxxxxxxx xxx xxxxxxxxxx xxxxx xxxxxxx xxxx xxxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxx xxxxxxx.

    Xxx x X++ xxx, xxxxx-xxxxx xx xxxx xxx xxxxxxx xxx xxxxxx **Xxxxxxxxxx**. Xxxx xx xx **Xxxxxx Xxxxxxxxxx** xxx xxxxx **Xxx Xxx Xxxxxxxxx**, xxxxx xxx xxx xxxx xx xxxx xxxxxxxxxx xxxxx xxxxxxx, xxx xxxxx **XX** xx xxxx xxxxxxx.

    Xxx x X\# xxx, xx xxxx xxx xxxxxxx, xxxxx xxxxx xx **Xxxxxxxxxx** xxx xxxxxx **Xxx Xxx Xxxxxxxxx**. Xxxxx **Xxxxxxxx**, xxxxxx **Xxxxxxxx** xxx xxxx xxxxxx xxx xxxx xx xxxx xxxxxxxxxx xxxx xxxxxxx xxx xxxxx **Xx**.

3.  Xxxxxx x xxx xxxxx xxxx xxxxxxxxxx xxx [**XXxxxxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br224794) xxxxxxxxx. Xxx [**Xxx**](https://msdn.microsoft.com/library/windows/apps/br224811) xxxxxx xx x xxxxxxxx xxxxx xxxxx xxxx xxxx xx xxxxxx xxxx xxx xxxxxxxxx xxxxx xx xxxxxxxxx; xxxx xxxxxx xx xxxxxxxx xx xxxxx xxxxxxxxxx xxxx.

    > **Xxxx**  Xxx xxxxxxxxxx xxxx xxxxx xxxxxx - xxx xxx xxxxx xxxxxxx xx xxx xxxxxxxxxx xxxx xxxxxxx - xxxx xx xx **xxxxxx** xxxxxxx xxxx xxx **xxxxxx**.

    Xxx xxxxxxxxx xxxxxx xxxx xxxxx x xxxx xxxxx xxxxxxxx xxxxx xxx x xxxxxxxxxx xxxx xxxxx:

> [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
> ```cs
>     //
>     // ExampleBackgroundTask.cs
>     //
> 
>     using Windows.ApplicationModel.Background;
> 
>     namespace Tasks
>     {
>         public sealed class ExampleBackgroundTask : IBackgroundTask
>         {
>             public void Run(IBackgroundTaskInstance taskInstance)
>             {
>                 
>             }        
>         }
>     }
> ```
> ```cpp
>     //
>     // ExampleBackgroundTask.cpp
>     //
> 
>     #include "ExampleBackgroundTask.h"
> 
>     using namespace Tasks;
> 
>     void ExampleBackgroundTask::Run(IBackgroundTaskInstance^ taskInstance)
>     {
> 
>     }
>  ```

    
> ```cpp
>     //
>     // ExampleBackgroundTask.h
>     //
> 
>     #pragma once
> 
>     using namespace Windows::ApplicationModel::Background;
> 
>     namespace RuntimeComponent1
>     {
>         public ref class ExampleBackgroundTask sealed : public IBackgroundTask
>         {
> 
>         public:
>             ExampleBackgroundTask();
> 
>             virtual void Run(IBackgroundTaskInstance^ taskInstance);
>             void OnCompleted(
>                     BackgroundTaskRegistration^ task,
>                     BackgroundTaskCompletedEventArgs^ args
>                     );
>         };
>     }
> ```

4.  Xx xxx xxx xxx xxxxxxxxxxxx xxxx xx xxxx xxxxxxxxxx xxxx, xxxx xxxx xxxxxxxxxx xxxx xxxxx xx xxx x xxxxxxxx. Xx xxx xxx'x xxx x xxxxxxxx, xxxx xxx xxxxxxxxxx xxxx xxxxxxx xxx xxxxxxxxx xxxxxxxxxxxx xx xxx Xxx xxxxxx xxxxxxxxx xxxxxx xxxx xxxxxxxxxxxx xxxxxx xxxx xxx xxxxxxxxx.

    Xxxxxxx xxx xxxxxxxx xx xxx Xxx xxxxxx xxxxxx xxxxxxx xxx xxxxxxxxxxxx xxxxxx. Xxxx xxx xxxxxxxx xx x xxxxxx xxxxxxxx xx xx xxx xx xxxxxxxx xxxx xxx xxxxxxxxxxxx xxxxxx. Xxxxxxx xxx xxxxxxxx xxxxxxxx xxxxx xxx xxxxxxxxxxxx xxxx xxxxxxxxx.

    Xxx xxxxxxxxx xxxxxx xxxx xxxx xxx xxxxxxxx, xxxxx xx, xxx xxxxxxxx xx xxxx xxx xxxxxxxxxxxx xxxx xx xxxxxxxx:

> [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
> ```cs
>     BackgroundTaskDeferral _deferral = taskInstance.GetDeferral(); // Note: define at class scope
>     public async void Run(IBackgroundTaskInstance taskInstance)
>     {
>         //
>         // TODO: Insert code to start one or more asynchronous methods using the
>         //       await keyword, for example:
>         //
>         // await ExampleMethodAsync();
>         //
>         
>         _deferral.Complete();
>     }
> ```
> ```cpp
>     BackgroundTaskDeferral^ deferral = taskInstance->GetDeferral(); // Note: define at class scope
>     void ExampleBackgroundTask::Run(IBackgroundTaskInstance^ taskInstance)
>     {
>         //
>         // TODO: Modify the following line of code to call a real async function.
>         //       Note that the task<void> return type applies only to async
>         //       actions. If you need to call an async operation instead, replace
>         //       task<void> with the correct return type.
>         //
>         task<void> myTask(ExampleFunctionAsync());
>         
>         myTask.then([=] () {
>             deferral->Complete();
>         });
>     }
> ```

    **Note**  In C\#, your background task's asynchronous methods can be called using the **async/await** keywords. In C++, a similar result can be achieved by using a task chain.

    For more information on asynchronous patterns, see [Asynchronous programming](https://msdn.microsoft.com/library/windows/apps/mt187335). For additional examples of how to use deferrals to keep a background task from stopping early, see the [background task sample](http://go.microsoft.com/fwlink/p/?LinkId=618666).

Xxx xxxxxxxxx xxxxx xxx xxxxxxxxx xx xxx xx xxxx xxx xxxxxxx (xxx xxxxxxx, XxxxXxxx.xxxx.xx).

> **Xxxx**  Xxx xxx xxxx xxxxxx x xxxxxxxx xxxxxxxxx xx xxxxxxxxxxx xxxxxxxxxx xxxxx - xxx [Xxxxxxxx x xxxxxxxxxx xxxx](register-a-background-task.md). Xx xxxx xxxx, xxxxxxx xx xxxxx xxx xxxx Y xxxxx, xxx xxx xxxxxx xxxxxxxxx xxx xxxxxxx xxx xxxxxxx xx xx xxx xxxxxxxxxxxx xxxxxxxx xxxxx xxxx xxx xxxx xxxx, xxxx xxxxx xxxxx, xxx (xxxxxxxxxx) x xxxxxxxxx.

 
**Xxxxxxxx xxx xxxxxxxxxx xxxx xx xxx**

1.  Xxxx xxx xx xxx xxxxxxxxxx xxxx xx xxxxxxx xxxxxxxxxx xx xxxxxxxxx xxxxxxx xxx [**XxxxxxxxxxXxxxXxxxxxxxxxxx.XxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br224787) xxxxxxxx. Xxxx xxxx xx xxxxxxxxx; xx xxxx xxx xxxxx'x xxxxx xxx xxxxxxxx xxxxxxxxxx xxxx xxxxxxxxxxxxx, xx xxxxx xxxxxx xxxxxxxx xxx xxxx xxxxxxxx xxxxx, xxxxxxx xxxxxx xxxx xxxxxxxxxxx xxx xxxxxx xxx xxx xxxx'x xxxxxxxxx XXX xxxx xxxxxx xxxx xxx xxxxxxxx.

    Xxx xxxxxxxxx xxxxxxx xxxxxxxx xx xxx XxxXxxxx xxxxxxxx xxx xxxx x xxxx xxxxxxxx xx xxxx xx xxx xxxx xx xxxxxxx xxxxxxxxxx:

> [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
> ```cs
>     var taskRegistered = false;
>     var exampleTaskName = "ExampleBackgroundTask";
> 
>     foreach (var task in BackgroundTaskRegistration.AllTasks)
>     {
>         if (task.Value.Name == exampleTaskName)
>         {
>             taskRegistered = true;
>             break;
>         }
>     }
> ```
> ```cpp
>     boolean taskRegistered = false;
>     Platform::String^ exampleTaskName = "ExampleBackgroundTask";
> 
>     auto iter = BackgroundTaskRegistration::AllTasks->First();
>     auto hascur = iter->HasCurrent;
> 
>     while (hascur)
>     {
>         auto cur = iter->Current->Value;
> 
>         if(cur->Name == exampleTaskName)
>         {
>             taskRegistered = true;
>             break;
>         }
> 
>         hascur = iter->MoveNext();
>     }
> ```

2.  Xx xxx xxxxxxxxxx xxxx xx xxx xxxxxxx xxxxxxxxxx, xxx [**XxxxxxxxxxXxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br224768) xx xxxxxx xx xxxxxxxx xx xxxx xxxxxxxxxx xxxx. Xxx xxxx xxxxx xxxxx xxxxxx xx xxx xxxx xx xxxx xxxxxxxxxx xxxx xxxxx xxxxxxxx xx xxx xxxxxxxxx.

    Xxx xxxxxxxxxx xxxx xxxxxxx xxxxxxxx xxxx xxx xxxxxxxxxx xxxx xxxx xxx. Xxx x xxxx xx xxxxxxxx xxxxxxxx, xxx [**XxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br224839).

    Xxx xxxxxxx, xxxx xxxx xxxxxxx x xxx xxxxxxxxxx xxxx xxx xxxx xx xx xxx xxxx xxx **XxxxXxxxXxxxxxx** xxxxxxx xx xxxxx:

> [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
> ```cs
>     var builder = new BackgroundTaskBuilder();
> 
>     builder.Name = exampleTaskName;
>     builder.TaskEntryPoint = "RuntimeComponent1.ExampleBackgroundTask";
>     builder.SetTrigger(new SystemTrigger(SystemTriggerType.TimeZoneChange, false));
> ```
> ```cpp
>     auto builder = ref new BackgroundTaskBuilder();
> 
>     builder->Name = exampleTaskName;
>     builder->TaskEntryPoint = "RuntimeComponent1.ExampleBackgroundTask";
>     builder->SetTrigger(ref new SystemTrigger(SystemTriggerType::TimeZoneChange, false));
> ```

3.  Xxx xxx xxx x xxxxxxxxx xx xxxxxxx xxxx xxxx xxxx xxxx xxx xxxxx xxx xxxxxxx xxxxx xxxxxx (xxxxxxxx). Xxx xxxxxxx, xx xxx xxx'x xxxx xxx xxxx xx xxx xxxxx xxx xxxx xx xxxxxxx, xxx xxx xxxxxxxxx **XxxxXxxxxxx**. Xxx x xxxx xx xxxxxxxx xxxxxxxxxx, xxx [**XxxxxxXxxxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br224835).

    Xxx xxxxxxxxx xxxxxx xxxx xxxxxxx x xxxxxxxxx xxxxxxxxx xxx xxxx xx xx xxxxxxx:

> [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
> ```cs
>     builder.AddCondition(new SystemCondition(SystemConditionType.UserPresent));
> ```
> ```cpp
>     builder->AddCondition(ref new SystemCondition(SystemConditionType::UserPresent));
> ```

4.  Xxxxxxxx xxx xxxxxxxxxx xxxx xx xxxxxxx xxx Xxxxxxxx xxxxxx xx xxx [**XxxxxxxxxxXxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br224768) xxxxxx. Xxxxx xxx [**XxxxxxxxxxXxxxXxxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br224786) xxxxxx xx xx xxx xx xxxx xx xxx xxxx xxxx.

    Xxx xxxxxxxxx xxxx xxxxxxxxx xxx xxxxxxxxxx xxxx xxx xxxxxx xxx xxxxxx:

> [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
>     ```cs
>     BackgroundTaskRegistration task = builder.Register();
>     ```
>     ```cpp
>     BackgroundTaskRegistration^ task = builder->Register();
>     ```

    > **Note**  Universal Windows apps must call [**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700485) before registering any of the background trigger types.

    To ensure that your Universal Windows app continues to run properly after you release an update, you must call [**RemoveAccess**](https://msdn.microsoft.com/library/windows/apps/hh700471) and then call [**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700485) when your app launches after being updated. For more information, see [Guidelines for background tasks](guidelines-for-background-tasks.md).

## Xxxxxx xxxxxxxxxx xxxx xxxxxxxxxx xxxxx xxxxx xxxxxxxx


Xxx xxxxxx xxxxxxxx x xxxxxx xxxx xxx [**XxxxxxxxxxXxxxXxxxxxxxxXxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br224781), xx xxxx xxxx xxx xxx xxx xxxxxxx xxxx xxx xxxxxxxxxx xxxx. Xxxx xxx xxx xx xxxxxxxx xx xxxxxxx, xxx xxxx xxxxxx xxxx xx xxxxxx xx xxx xxxxxxxxxx xxxx xxx xxxxxxxxx xxxxx xxx xxxx xxxx xxx xxx xxx xx xxx xxxxxxxxxx. (Xxx XxXxxxxxxxx xxxxxx xxxx xx xxxxxx xxxxxxxxxxx xx xxx xxxxxxxxxx xxxx xxxxxxxxx xxxxx xxxx xxx xx xxxxxxxxx xx xxx xxxxxxxxxx.)

1.  Xxxxx xx XxXxxxxxxxx xxxxxx xx xxxxxx xxx xxxxxxxxxx xx xxxxxxxxxx xxxxx. Xxx xxxxxxx, xxx xxxxxxxxxx xxxx xxxxxx xxxxx xxxxx x XX xxxxxx. Xxx xxxxxx xxxxxxxxx xxxxx xxxx xx xxxxxxxx xxx xxx XxXxxxxxxxx xxxxx xxxxxxx xxxxxx, xxxx xxxxxx xxxx xxxxxxx xxxx xxx xxx xxx *xxxx* xxxxxxxxx.

    Xxx xxxxxxxxx xxxxxx xxxx xxxxxxxxxx xxxxxxxxxx xxxx xxxxxxxxxx xxx xxxxx xx xxxxxxx XX xxxxxx xxxxxx xxxx xxxxx x xxxxxxx xxxxxx.

> [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
>     ```cs
>     private void OnCompleted(IBackgroundTaskRegistration task, BackgroundTaskCompletedEventArgs args)
>     {
>         var settings = Windows.Storage.ApplicationData.Current.LocalSettings;
>         var key = task.TaskId.ToString();
>         var message = settings.Values[key].ToString();
>         UpdateUI(message);
>     }
>     ```
>     ```cpp
>     void ExampleBackgroundTask::OnCompleted(BackgroundTaskRegistration^ task, BackgroundTaskCompletedEventArgs^ args)
>     {
>         auto settings = ApplicationData::Current->LocalSettings->Values;
>         auto key = task->TaskId.ToString();
>         auto message = dynamic_cast<String^>(settings->Lookup(key));
>         UpdateUI(message);
>     }
>     ```

    > **Note**  UI updates should be performed asynchronously, to avoid holding up the UI thread. For an example, see the UpdateUI method in the [background task sample](http://go.microsoft.com/fwlink/p/?LinkId=618666).

     

2.  Xx xxxx xx xxxxx xxx xxxxxxxxxx xxx xxxxxxxxxx xxxx. Xxxxx xxxx xxxx xx xxxx, xxx x xxx [**XxxxxxxxxxXxxxXxxxxxxxxXxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br224781) xxxxxx. Xxxxxxx xxxx XxXxxxxxxxx xxxxxx xx xxx xxxxxxxxx xxx xxx **XxxxxxxxxxXxxxXxxxxxxxxXxxxxXxxxxxx** xxxxxxxxxxx.

    Xxx xxxxxxxxx xxxxxx xxxx xxxx x [**XxxxxxxxxxXxxxXxxxxxxxxXxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br224781) xx xxx [**XxxxxxxxxxXxxxXxxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br224786):

> [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
>     ```cs
>     task.Completed += new BackgroundTaskCompletedEventHandler(OnCompleted);
>     ```
>     ```cpp
>     task->Completed += ref new BackgroundTaskCompletedEventHandler(this, &amp;ExampleBackgroundTask::OnCompleted);
>     ```

## Xxxxxxx xxxx xxxx xxx xxxx xxxxxxxxxx xxxxx xx xxx xxx xxxxxxxx


Xxxxxx xxxx xxx xxx xxx xxxxxxxxxx xxxxx, xxx xxxx xxxxxxx xxxx xxxxxxxxxx xxxx xx xxx xxx xxxxxxxx. Xx xxxx xxx xxxxxxxx xx xxxxxxxx x xxxxxxxxxx xxxx xxxx x xxxxxxx xxxx xxx'x xxxxxx xx xxx xxxxxxxx, xxx xxxxxxxxxxxx xxxx xxxx.

1.  Xxxx xxx xxxxxxx xxxxxxxx xxxxxxxx xx xxxxxxx xxx xxxx xxxxx Xxxxxxx.xxxxxxxxxxxx.
2.  Xxxx xxx **Xxxxxxxxxxxx** xxx.
3.  Xxxx xxx **Xxxxxxxxx Xxxxxxxxxxxx** xxxx-xxxx, xxxxxx **Xxxxxxxxxx Xxxxx** xxx xxxxx **Xxx**.
4.  Xxxxxx xxx **Xxxxxx xxxxx** xxxxxxxx.
5.  Xx xxx **Xxxxx xxxxx:** xxxxxxx, xxxxx xxx xxxxxxxxx xxx xxxx xx xxxx xxxxxxxxxx xxxxx xxxxx xx xxx xxxx xxxxxxx xx XxxxxxxXxxxxxxxxY.XxxxxxxXxxxxxxxxxXxxx.
6.  Xxxxx xxx xxxxxxxx xxxxxxxx.

    Xxx xxxxxxxxx Xxxxxxxxxx xxxxxxx xx xxxxx xx xxxx Xxxxxxx.xxxxxxxxxxxx xxxx xx xxxxxxxx xxx xxxxxxxxxx xxxx:

    ```xaml
    <Extensions>
      <Extension Category="windows.backgroundTasks" EntryPoint="RuntimeComponent1.ExampleBackgroundTask">
        <BackgroundTasks>
          <Task Type="systemEvent" />
        </BackgroundTasks>
      </Extension>
    </Extensions>
    ```

## Xxxxxxx xxx xxxx xxxxx


Xxx xxxxxx xxx xxxxxxxxxx xxx xxxxxx xx xxx xx xxxxx x xxxxxxxxxx xxxx xxxxx, xxx xx xxxxxxxx xxx xxxxxxxxxx xxxx xxxx xxxxxx xxxx xxx, xxx xxx xx xxxx xxxx xxx xxxxxxxxx xxxx xxx xxxxxxxxxx xxxx xx xxxxxxxx. Xxx xxxxxx xxxx xxxxxxxxxx xxx xx xxxxxx xxx xxxxxxxxxxx xxxxxxxx xx xxxx xxxx xxx xxx xxxxxxxxxxxx xxxxxxxx xxx xxxxxxxxxx xxxx.

> **Xxxx**  Xxxxxxxx xxx [xxxxxxxxxx xxxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkId=618666) xx xxx xxxxxxx xxxx xxxxxxxx xx xxx xxxxxxx xx x xxxxxxxx xxx xxxxxx XXX xxx xxxx xxxx xxxxxxxxxx xxxxx.

 

Xxx xxx xxxxxxxxx xxxxxxx xxxxxx xxx XXX xxxxxxxxx, xxxxxxxxxx xxxx xxxxxxxxxx xxxxxxxx, xxx xxxx xxxxxxxx xxxxxxxxxxxx xxx xxxxxxx xxxx xxxx xxx xxxxxxxxxx xxxxx.

> **Xxxx**  Xxxx xxxxxxx xx xxx Xxxxxxx YY xxxxxxxxxx xxxxxxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx. Xx xxx’xx xxxxxxxxxx xxx Xxxxxxx Y.x xx Xxxxxxx Xxxxx Y.x, xxx xxx [xxxxxxxx xxxxxxxxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132).

 

## Xxxxxxx xxxxxx


**Xxxxxxxx xxxxxxxxxx xxxx xxxxxxxxxxxxx xxxxxx**

* [Xxxxxxx xx xxxxxx xxxxxx xxxx xxxxxxxxxx xxxxx](respond-to-system-events-with-background-tasks.md)
* [Xxxxxxxx x xxxxxxxxxx xxxx](register-a-background-task.md)
* [Xxx xxxxxxxxxx xxx xxxxxxx x xxxxxxxxxx xxxx](set-conditions-for-running-a-background-task.md)
* [Xxx x xxxxxxxxxxx xxxxxxx](use-a-maintenance-trigger.md)
* [Xxxxxx x xxxxxxxxx xxxxxxxxxx xxxx](handle-a-cancelled-background-task.md)
* [Xxxxxxx xxxxxxxxxx xxxx xxxxxxxx xxx xxxxxxxxxx](monitor-background-task-progress-and-completion.md)
* [Xxx x xxxxxxxxxx xxxx xx x xxxxx](run-a-background-task-on-a-timer-.md)

**Xxxxxxxxxx xxxx xxxxxxxx**

* [Xxxxxxxxxx xxx xxxxxxxxxx xxxxx](guidelines-for-background-tasks.md)
* [Xxxxx x xxxxxxxxxx xxxx](debug-a-background-task.md)
* [Xxx xx xxxxxxx xxxxxxx, xxxxxx, xxx xxxxxxxxxx xxxxxx xx Xxxxxxx Xxxxx xxxx (xxxx xxxxxxxxx)](http://go.microsoft.com/fwlink/p/?linkid=254345)

**Xxxxxxxxxx Xxxx XXX Xxxxxxxxx**

* [**Xxxxxxx.XxxxxxxxxxxXxxxx.Xxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br224847)

 

 



<!--HONumber=Mar16_HO1-->
