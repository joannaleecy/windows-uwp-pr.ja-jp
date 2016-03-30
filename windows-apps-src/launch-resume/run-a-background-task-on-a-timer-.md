---
xxxxx: Xxx x xxxxxxxxxx xxxx xx x xxxxx
xxxxxxxxxxx: Xxxxx xxx xx xxxxxxxx x xxx-xxxx xxxxxxxxxx xxxx, xx xxx x xxxxxxxx xxxxxxxxxx xxxx.
xx.xxxxxxx: YXYXYXXX-YYYX-YYYX-XXYY-YYYXYYYXYYXY
---

# Xxx x xxxxxxxxxx xxxx xx x xxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


**Xxxxxxxxx XXXx**

-   [**XxxxxxxxxxXxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br224768)
-   [**XxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br224843)
-   [**XxxxxxxXxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/hh700494)

Xxxxx xxx xx xxxxxxxx x xxx-xxxx xxxxxxxxxx xxxx, xx xxx x xxxxxxxx xxxxxxxxxx xxxx.

-   Xxxx xxxxxxx xxxxxxx xxxx xxx xxxx x xxxxxxxxxx xxxx xxxx xxxxx xx xxx xxxxxxxxxxxx, xx xx x xxxxxxxx xxxx, xx xxxxxxx xxxx xxx. X xxxxxxxxxx xxxx xxxx xxxx xxx xxxxx x [**XxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br224843) xx xxx xxxx xxxxxx [**XxxxxxxXxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/hh700485).
-   Xxxx xxxxx xxxxxxx xxx xxxx xxxxxxx xxxxxxx x xxxxxxxxxx xxxx xxxxx, xxxxxxxxx xxx Xxx xxxxxx xxxx xx xxxx xx xxx xxxxxxxxxx xxxx xxxxx xxxxx. Xx xxx xxxxxxx xxxxxxx xxxxxxxx x xxxxxxxxxx xxxx, xxx [Xxxxxx xxx xxxxxxxx x xxxxxxxxxx xxxx](create-and-register-a-background-task.md). Xxx xxxx xx-xxxxx xxxxxxxxxxx xx xxxxxxxxxx xxx xxxxxxxx, xxx [Xxxxxxx xxxx xxx xxxx xxxxxxxxxx xxxxx](support-your-app-with-background-tasks.md).

## Xxxxxx x xxxx xxxxxxx


-   Xxxxxx x xxx [**XxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br224843). Xxx xxxxxx xxxxxxxxx, *XxxXxxx*, xxxxxxxxx xxxxxxx xxx xxxxxxxxxx xxxx xxxx xxx xxxx xx xxxx xxxxxxx xxxxxxxxxxxx. Xx *XxxXxxx* xx xxx xx xxxx, xxx xxxxx xxxxxxxxx (*XxxxxxxxxXxxx*) xxxxxxxxx xxx xxxxxx xx xxxxxxx xx xxxx xxxxxx xxxxxxxxxx xxx xxxxxxxxxx xxxx. Xx *XxxXxxx* xx xxx xx xxxxx, *XxxxxxxxxXxxx* xxxxxxxxx xxx xxxxxxxxx xx xxxxx xxx xxxxxxxxxx xxxx xxxx xxx.

    Xxx xxxxx-xx xxxxx xxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx xxxx xxxxxxxxxx xxxxx xx YY-xxxxxx xxxxxxxxx.

    -   Xx *XxxxxxxxxXxxx* xx xxx xx YY xxxxxxx xxx *XxxXxxx* xx xxxx, xxx xxxx xxxx xxx xxxx xxxxxxxx xxxxxxx Y xxx YY xxxxxxx xxxx xxx xxxx xx xx xxxxxxxxxx.

    -   Xx *XxxxxxxxxXxxx* xx xxx xx YY xxxxxxx xxx *XxxXxxx* xx xxxxx, xxx xxxx xxxx xxx xxxxx YY xxxxxxx xxxxxxxx xxxxxxx Y xxx YY xxxxxxx xxxx xxx xxxx xx xx xxxxxxxxxx.

    **Xxxx**  Xx *XxxxxxxxxXxxx* xx xxx xx xxxx xxxx YY xxxxxxx, xx xxxxxxxxx xx xxxxxx xxxx xxxxxxxxxx xx xxxxxxxx xxx xxxxxxxxxx xxxx.

     

    For example, this trigger will cause a background task to run once an hour:

    > [!div class="tabbedCodeSnippets"]
    > ```cs
    > TimeTrigger hourlyTrigger = new TimeTrigger(60, false);
    > ```
    > ```cpp
    > TimeTrigger ^ hourlyTrigger = ref new TimeTrigger(60, false);
    > ```

## (Xxxxxxxx) Xxx x xxxxxxxxx


-   Xx xxxxxxxxx, xxxxxx x xxxxxxxxxx xxxx xxxxxxxxx xx xxxxxxx xxxx xxx xxxx xxxx. X xxxxxxxxx xxxxxxxx xxx xxxxxxxxxx xxxx xxxx xxxxxxx xxxxx xxx xxxxxxxxx xx xxx - xxx xxxx xxxxxxxxxxx, xxx [Xxx xxxxxxxxxx xxx xxxxxxx x xxxxxxxxxx xxxx](set-conditions-for-running-a-background-task.md).

    Xx xxxx xxxxxxx xxx xxxxxxxxx xx xxx xx **XxxxXxxxxxx** xx xxxx, xxxx xxxxxxxxx, xxx xxxx xxxx xxxx xxxx xxx xxxx xx xxxxxx. Xxx x xxxx xx xxxxxxxx xxxxxxxxxx, xxx [**XxxxxxXxxxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br224835).

    > [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
    > ```cs
    > SystemCondition userCondition = new SystemCondition(SystemConditionType.UserPresent);
    > ```
    > ```cpp
    > SystemCondition ^ userCondition = ref new SystemCondition(SystemConditionType::UserPresent)
    > ```

##  Xxxx XxxxxxxXxxxxxXxxxx()


-   Xxxxxx xxxxxx xx xxxxxxxx xxx [**XxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br224843) xxxxxxxxxx xxxx, xxxx [**XxxxxxxXxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/hh700494).

    > [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
    > ```cs
    > BackgroundExecutionManager.RequestAccessAsync();
    > ```
    > ```cpp
    > BackgroundExecutionManager::RequestAccessAsync();
    > ```

## Xxxxxxxx xxx xxxxxxxxxx xxxx


-   Xxxxxxxx xxx xxxxxxxxxx xxxx xx xxxxxxx xxxx xxxxxxxxxx xxxx xxxxxxxxxxxx xxxxxxxx. Xxx xxxx xxxxxxxxxxx xx xxxxxxxxxxx xxxxxxxxxx xxxxx, xxx [Xxxxxxxx x xxxxxxxxxx xxxx](register-a-background-task.md).

    Xxx xxxxxxxxx xxxx xxxxxxxxx xxx xxxxxxxxxx xxxx:

    > > [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
    > ```cs
    > string entryPoint = “Tasks.ExampleBackgroundTaskClass”;
    > string taskName   = “Example hourly background task”;
    > 
    > BackgroundTaskRegistration task = RegisterBackgroundTask(entryPoint, taskName, hourlyTrigger, userCondition);
    > ```
    > ```cpp
    > String ^ entryPoint = “Tasks.ExampleBackgroundTaskClass”;
    > String ^ taskName   = “Example hourly background task”;
    > 
    > BackgroundTaskRegistration ^ task = RegisterBackgroundTask(entryPoint, taskName, hourlyTrigger, userCondition);
    > ```
    
    > **Xxxx**  Xxxxxxxxxx xxxx xxxxxxxxxxxx xxxxxxxxxx xxx xxxxxxxxx xx xxx xxxx xx xxxxxxxxxxxx. Xx xxxxx xx xxxxxxxx xx xxx xx xxx xxxxxxxxxxxx xxxxxxxxxx xxx xxxxxxx. Xxxxxx xxxx xxxx xxx xxxxxxxxxx xxxxxxx xxxxxxxxx xxxxx xxxxxxxxxx xxxx xxxxxxxxxxxx xxxxx - xx xxxxxxx xxxx xxx xxxxxxx xx xxxxxx x xxxxx xxxxxxxxxxxx xxxxxx xxxxx xxxxxxxxxx xx xxxxxxxx x xxxx, xx xxx xxxxx.

   
## Xxxxxxx

> **Xxxx**  Xxxxxxxx xxxx Xxxxxxx YY, xx xx xx xxxxxx xxxxxxxxx xxx xxx xxxx xx xxx xxxx xxx xx xxx xxxx xxxxxx xx xxxxx xx xxxxxxx xxxxxxxxxx xxxxx. Xxx xxxxxxxx xx xxx xxxxx xx xxxxxxxxxx xxxx xxxxxxxx, xxx [Xxxxxxx xxxx xxx xxxx xxxxxxxxxx xxxxx](support-your-app-with-background-tasks.md).

> **Xxxx**  Xxxx xxxxxxx xx xxx Xxxxxxx YY xxxxxxxxxx xxxxxxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx. Xx xxx’xx xxxxxxxxxx xxx Xxxxxxx Y.x xx Xxxxxxx Xxxxx Y.x, xxx xxx [xxxxxxxx xxxxxxxxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132).


## Xxxxxxx xxxxxx


* [Xxxxxx xxx xxxxxxxx x xxxxxxxxxx xxxx](create-and-register-a-background-task.md)
* [Xxxxxxx xxxxxxxxxx xxxxx xx xxx xxxxxxxxxxx xxxxxxxx](declare-background-tasks-in-the-application-manifest.md)
* [Xxxxxx x xxxxxxxxx xxxxxxxxxx xxxx](handle-a-cancelled-background-task.md)
* [Xxxxxxx xxxxxxxxxx xxxx xxxxxxxx xxx xxxxxxxxxx](monitor-background-task-progress-and-completion.md)
* [Xxxxxxxx x xxxxxxxxxx xxxx](register-a-background-task.md)
* [Xxxxxxx xx xxxxxx xxxxxx xxxx xxxxxxxxxx xxxxx](respond-to-system-events-with-background-tasks.md)
* [Xxx xxxxxxxxxx xxx xxxxxxx x xxxxxxxxxx xxxx](set-conditions-for-running-a-background-task.md)
* [Xxxxxx x xxxx xxxx xxxx x xxxxxxxxxx xxxx](update-a-live-tile-from-a-background-task.md)
* [Xxx x xxxxxxxxxxx xxxxxxx](use-a-maintenance-trigger.md)
* [Xxxxxxxxxx xxx xxxxxxxxxx xxxxx](guidelines-for-background-tasks.md)

* [Xxxxx x xxxxxxxxxx xxxx](debug-a-background-task.md)
* [Xxx xx xxxxxxx xxxxxxx, xxxxxx, xxx xxxxxxxxxx xxxxxx xx Xxxxxxx Xxxxx xxxx (xxxx xxxxxxxxx)](http://go.microsoft.com/fwlink/p/?linkid=254345)

 

 



<!--HONumber=Mar16_HO1-->
