---
xxxxx: Xxxxxxx xxxxxxxxxx xxxx xxxxxxxx xxx xxxxxxxxxx
xxxxxxxxxxx: Xxxxx xxx xxxx xxx xxx xxxxxxxxx xxxxxxxx xxx xxxxxxxxxx xxxxxxxx xx x xxxxxxxxxx xxxx.
xx.xxxxxxx: YYYYYXXY-XYYY-YYYY-YYXX-YXXYYYYXXYXY
---

# Xxxxxxx xxxxxxxxxx xxxx xxxxxxxx xxx xxxxxxxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


**Xxxxxxxxx XXXx**

-   [**XxxxxxxxxxXxxxXxxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br224786)
-   [**XxxxxxxxxxXxxxXxxxxxxxXxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br224785)
-   [**XxxxxxxxxxXxxxXxxxxxxxxXxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br224781)

Xxxxx xxx xxxx xxx xxx xxxxxxxxx xxxxxxxx xxx xxxxxxxxxx xxxxxxxx xx x xxxxxxxxxx xxxx. Xxxxxxxxxx xxxxx xxx xxxxxxxxx xxxx xxx xxx, xxx xxxx xxx xxxxxxxxxx, xxx xxxxxxxxxx xxxx xxxxxxxx xxx xxxxxxxxxx xxx xx xxxxxxxxx xx xxx xxxx. Xx xxxx xxxx xxxxxx, xxx xxx xxxxxxxxxx xx xxxxxx xxxx xxx xxxxxxxxxx xxxx(x) xx xxx xxxxxxxxxx xxxx xxx xxxxxx.

-   Xxxx xxxxx xxxxxxx xxxx xxx xxxx xx xxx xxxx xxxxxxxxx xxxxxxxxxx xxxxx. Xx xxx xxxxxxx xxxxxxx xxxxxxxx x xxxxxxxxxx xxxx, xxx [Xxxxxx xxx xxxxxxxx x xxxxxxxxxx xxxx](create-and-register-a-background-task.md). Xxx xxxx xx-xxxxx xxxxxxxxxxx xx xxxxxxxxxx xxx xxxxxxxx, xxx [Xxxxxxx xxxx xxx xxxx xxxxxxxxxx xxxxx](support-your-app-with-background-tasks.md).

## Xxxxxx xx xxxxx xxxxxxx xx xxxxxx xxxxxxxxx xxxxxxxxxx xxxxx


1.  Xxxxxx xx xxxxx xxxxxxx xxxxxxxx xx xxxxxx xxxxxxxxx xxxxxxxxxx xxxxx. Xxxx xxxx xxxxx xx xxxxxx x xxxxxxxx xxxxxxxxx, xxxxx xxxxx xx xx [**XXxxxxxxxxxXxxxXxxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br224803) xxxxxx xxx x [**XxxxxxxxxxXxxxXxxxxxxxxXxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br224778) xxxxxx.

    Xxx xxx xxxxxxxxx xxxxxxxxx xxx xxx XxXxxxxxxxx xxxxxxxxxx xxxx xxxxx xxxxxxx xxxxxx:

>  [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
>  ```cs
>  private void OnCompleted(IBackgroundTaskRegistration task, BackgroundTaskCompletedEventArgs args)
>  {
>      // TODO: Add code that deals with background task completion.
>  }
>  ```
>  ```cpp
>  auto completed = [this](BackgroundTaskRegistration^ task, BackgroundTaskCompletedEventArgs^ args)
>  {
>      // TODO: Add code that deals with background task completion.
>  };
>  ```
    
2.  Xxx xxxx xx xxx xxxxx xxxxxxx xxxx xxxxx xxxx xxx xxxxxxxxxx xxxx xxxxxxxxxx.

    Xxx xxxxxxx, xxx [xxxxxxxxxx xxxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkId=618666) xxxxxxx xxx XX.

    > [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
    >     ```cs
    >     private void OnCompleted(IBackgroundTaskRegistration task, BackgroundTaskCompletedEventArgs args)
    >     {
    >         UpdateUI();
    >     }
    >     ```
    >     ```cpp
    >     auto completed = [this](BackgroundTaskRegistration^ task, BackgroundTaskCompletedEventArgs^ args)
    >     {    
    >         UpdateUI();
    >     };
    >     ```

## Xxxxxx xx xxxxx xxxxxxx xxxxxxxx xx xxxxxx xxxxxxxxxx xxxx xxxxxxxx


1.  Xxxxxx xx xxxxx xxxxxxx xxxxxxxx xx xxxxxx xxxxxxxxx xxxxxxxxxx xxxxx. Xxxx xxxx xxxxx xx xxxxxx x xxxxxxxx xxxxxxxxx, xxxxx xxxxx xx xx [**XXxxxxxxxxxXxxxXxxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br224803) xxxxxx xxx x [**XxxxxxxxxxXxxxXxxxxxxxXxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br224782) xxxxxx:

    Xxx xxx xxxxxxxxx xxxxxxxxx xxx xxx XxXxxxxxxx xxxxxxxxxx xxxx xxxxx xxxxxxx xxxxxx:

    > [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
    >     ```cs
    >     private void OnProgress(IBackgroundTaskRegistration task, BackgroundTaskProgressEventArgs args)
    >     {
    >         // TODO: Add code that deals with background task progress.
    >     }
    >     ```
    >     ```cpp
    >     auto progress = [this](BackgroundTaskRegistration^ task, BackgroundTaskProgressEventArgs^ args)
    >     {
    >         // TODO: Add code that deals with background task progress.
    >     };
    >     ```

2.  Xxx xxxx xx xxx xxxxx xxxxxxx xxxx xxxxx xxxx xxx xxxxxxxxxx xxxx xxxxxxxxxx.

    Xxx xxxxxxx, xxx [xxxxxxxxxx xxxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkId=618666) xxxxxxx xxx XX xxxx xxx xxxxxxxx xxxxxx xxxxxx xx xxx xxx *xxxx* xxxxxxxxx:

    > [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
    >     ```xx
    >     xxxxxxx xxxx XxXxxxxxxx(XXxxxxxxxxxXxxxXxxxxxxxxxxx xxxx, XxxxxxxxxxXxxxXxxxxxxxXxxxxXxxx xxxx)
    >     {
    >         xxx xxxxxxxx = "Xxxxxxxx: " + xxxx.Xxxxxxxx + "%";
    >         XxxxxxxxxxXxxxXxxxxx.XxxxxxXxxxxxxxxxXxxxXxxxxxxx = xxxxxxxx;
    > 
    >         UpdateUI();
    >     }
    >     ```
    >     ```cpp
    >     auto progress = [this](BackgroundTaskRegistration^ task, BackgroundTaskProgressEventArgs^ args)
    >     {
    >         auto progress = "Progress: " + args->Progress + "%";
    >         BackgroundTaskSample::SampleBackgroundTaskProgress = progress;
    > 
    >         UpdateUI();
    >     };
    >     ```

## Xxxxxxxx xxx xxxxx xxxxxxx xxxxxxxxx xxxx xxx xxx xxxxxxxx xxxxxxxxxx xxxxx.


1.  Xxxx xxx xxx xxxxxxxxx x xxxxxxxxxx xxxx xxx xxx xxxxx xxxx, xx xxxxxx xxxxxxxx xx xxxxxxx xxxxxxxx xxx xxxxxxxxxx xxxxxxx xxx xx, xx xxxx xxx xxxx xxxx xxxxx xxx xxx xx xxxxx xxxxxx xx xxx xxxxxxxxxx.

    Xxx xxxxxxx, xxx [xxxxxxxxxx xxxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkId=618666) xxxxx xxx xxxxxxxxx xxxxxxxx xx xxxx xxxxxxxxxx xxxx xxxx xx xxxxxxxxx:

    > [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
    >     ```cs
    >     private void AttachProgressAndCompletedHandlers(IBackgroundTaskRegistration task)
    >     {
    >         task.Progress += new BackgroundTaskProgressEventHandler(OnProgress);
    >         task.Completed += new BackgroundTaskCompletedEventHandler(OnCompleted);
    >     }
    >     ```
    >     ```xxx
    >     xxxx XxxxxxXxxxxxxxxxXxxx::XxxxxxXxxxxxxxXxxXxxxxxxxxXxxxxxxx(XXxxxxxxxxxXxxxXxxxxxxxxxxx^ xxxx)
    >     {
    >         xxxx xxxxxxxx = [xxxx](XxxxxxxxxxXxxxXxxxxxxxxxxx^ xxxx, XxxxxxxxxxXxxxXxxxxxxxXxxxxXxxx^ xxxx)
    >         {
    >             xxxx xxxxxxxx = "Xxxxxxxx: " + xxxx->Xxxxxxxx + "%";
    >             XxxxxxxxxxXxxxXxxxxx::XxxxxxXxxxxxxxxxXxxxXxxxxxxx = xxxxxxxx;
    >             XxxxxxXX();
    >         };
    > 
    >         task->Progress += ref new BackgroundTaskProgressEventHandler(progress);
    >         
    > 
    >         auto completed = [this](BackgroundTaskRegistration^ task, BackgroundTaskCompletedEventArgs^ args)
    >         {
    >             UpdateUI();
    >         };
    > 
    >         task->Completed += ref new BackgroundTaskCompletedEventHandler(completed);
    >     }
    >     ```

2.  Xxxx xxx xxx xxxxxxxx, xx xxxxxxxxx xx x xxx xxxx xxxxx xxxxxxxxxx xxxx xxxxxx xx xxxxxxxx, xx xxxxxx xxx x xxxx xx xxxxxxxxxx xxxxx xxxxxxxxx xxxxxxxxxx xxx xxxxxxxxx xxxx xxxx xxx xxxxxxxx xxx xxxxxxxxxx xxxxx xxxxxxx xxxxxxxxx. Xxx xxxx xx xxxxxxxxxx xxxxx xxxxxxxxx xxxxxxxxxx xx xxx xxxxxxxxxxx xx xxxx xx xxx [**XxxxxxxxxxXxxxXxxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br224786).[**XxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br224787) xxxxxxxx.

    Xxx xxxxxxx, xxx [xxxxxxxxxx xxxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkId=618666) xxxx xxx xxxxxxxxx xxxx xx xxxxxx xxxxx xxxxxxxx xxxx xxx XxxxxxXxxxxxxxxxXxxx xxxx xx xxxxxxxxx xx:

    > [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
    >     ```xx
    >     xxxxxxxxx xxxxxxxx xxxx XxXxxxxxxxxXx(XxxxxxxxxxXxxxxXxxx x)
    >     {
    >         xxxxxxx (xxx xxxx xx XxxxxxxxxxXxxxXxxxxxxxxxxx.XxxXxxxx)
    >         {
    >             xx (xxxx.Xxxxx.Xxxx == XxxxxxxxxxXxxxXxxxxx.XxxxxxXxxxxxxxxxXxxxXxxx)
    >             {
    >                 XxxxxxXxxxxxxxXxxXxxxxxxxxXxxxxxxx(xxxx.Xxxxx);
    >                 XxxxxxxxxxXxxxXxxxxx.XxxxxxXxxxxxxxxxXxxxXxxxxx(XxxxxxxxxxXxxxXxxxxx.XxxxxxXxxxxxxxxxXxxxXxxx, xxxx);
    >             }
    >         }
    > 
    >         UpdateUI();
    >     }
    >     ```
    >     ```cpp
    >     void SampleBackgroundTask::OnNavigatedTo(NavigationEventArgs^ e)
    >     {
    >         // A pointer back to the main page.  This is needed if you want to call methods in MainPage such
    >         // as NotifyUser()
    >         rootPage = MainPage::Current;
    > 
    >         //
    >         // Attach progress and completed handlers to any existing tasks.
    >         //
    >         auto iter = BackgroundTaskRegistration::AllTasks->First();
    >         auto hascur = iter->HasCurrent;
    >         while (hascur)
    >         {
    >             auto cur = iter->Current->Value;
    > 
    >             if (cur->Name == SampleBackgroundTaskName)
    >             {
    >                 AttachProgressAndCompletedHandlers(cur);
    >                 break;
    >             }
    > 
    >             hascur = iter->MoveNext();
    >         }
    > 
    >         UpdateUI();
    >     }
    >     ```

## Xxxxxxx xxxxxx


****

* [Xxxxxx xxx xxxxxxxx x xxxxxxxxxx xxxx](create-and-register-a-background-task.md)
* [Xxxxxxx xxxxxxxxxx xxxxx xx xxx xxxxxxxxxxx xxxxxxxx](declare-background-tasks-in-the-application-manifest.md)
* [Xxxxxx x xxxxxxxxx xxxxxxxxxx xxxx](handle-a-cancelled-background-task.md)
* [Xxxxxxxx x xxxxxxxxxx xxxx](register-a-background-task.md)
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
