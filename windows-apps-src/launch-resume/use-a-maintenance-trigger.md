---
xxxxx: Xxx x xxxxxxxxxxx xxxxxxx
xxxxxxxxxxx: Xxxxx xxx xx xxx xxx XxxxxxxxxxxXxxxxxx xxxxx xx xxx xxxxxxxxxxx xxxx xx xxx xxxxxxxxxx xxxxx xxx xxxxxx xx xxxxxxx xx.
xx.xxxxxxx: YYYXYXYY-YXYX-YXXY-XYXY-YYYYXXYXYYXX
---

# Xxx x xxxxxxxxxxx xxxxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


**Xxxxxxxxx XXXx**

-   [**XxxxxxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh700517)
-   [**XxxxxxxxxxXxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br224768)
-   [**XxxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br224834)

Xxxxx xxx xx xxx xxx [**XxxxxxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh700517) xxxxx xx xxx xxxxxxxxxxx xxxx xx xxx xxxxxxxxxx xxxxx xxx xxxxxx xx xxxxxxx xx.

## Xxxxxx x xxxxxxxxxxx xxxxxxx xxxxxx


Xxxx xxxxxxx xxxxxxx xxxx xxx xxxx xxxxxxxxxxx xxxx xxx xxx xxx xx xxx xxxxxxxxxx xx xxxxxxx xxxx xxx xxxxx xxx xxxxxx xx xxxxxxx xx. Xxxx xxxxx xxxxxxx xx xxx [**XxxxxxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh700517) xxxxx, xxxxx xx xxxxxxx xx [**XxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br224839). Xxxx xxxxxxxxxxx xx xxxxxxx x xxxxxxxxxx xxxx xxxxx xx xxxxxxxxx xx [Xxxxxx xxx xxxxxxxx x xxxxxxxxxx xxxx](create-and-register-a-background-task.md).

Xxxxxx x xxx [**XxxxxxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br224843) xxxxxx. Xxx xxxxxx xxxxxxxxx, *XxxXxxx*, xxxxxxxxx xxxxxxx xxx xxxxxxxxxxx xxxx xxxx xxx xxxx xx xxxxxxxx xx xxx xxxxxxxxxxxx. Xx *XxxXxxx* xx xxx xx xxxx, xxx xxxxx xxxxxxxxx (*XxxxxxxxxXxxx*) xxxxxxxxx xxx xxxxxx xx xxxxxxx xx xxxx xxxxxx xxxxxxxxxx xxx xxxxxxxxxx xxxx. Xx *XxxXxxx* xx xxx xx xxxxx, *XxxxxxxxxXxxx* xxxxxxxxx xxx xxxxxxxxx xx xxxxx xxx xxxxxxxxxx xxxx xxxx xxx.

> **Xxxx**  Xx *XxxxxxxxxXxxx* xx xxx xx xxxx xxxx YY xxxxxxx, xx xxxxxxxxx xx xxxxxx xxxx xxxxxxxxxx xx xxxxxxxx xxx xxxxxxxxxx xxxx.

 

Xxxx xxxxxxx xxxx xxxxxxx x xxxxxxx xxxx xxxx xxxx xx xxxx:

> [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
> ```cs
> uint waitIntervalMinutes = 60;
> 
> MaintenanceTrigger taskTrigger = new MaintenanceTrigger(waitIntervalMinutes, false);
> ```
> ```cpp
> unsigned int waitIntervalMinutes = 60;
> 
> MaintenanceTrigger ^ taskTrigger = ref new MaintenanceTrigger(waitIntervalMinutes, false);
> ```

## (Xxxxxxxx) Xxx x xxxxxxxxx

-   Xx xxxxxxxxx, xxxxxx x xxxxxxxxxx xxxx xxxxxxxxx xx xxxxxxx xxxx xxx xxxx xxxx. X xxxxxxxxx xxxxxxxx xxxx xxxxxxxxxx xxxx xxxx xxxxxxx xxxxx xxx xxxxxxxxx xx xxx - xxx xxxx xxxxxxxxxxx, xxx [Xxx xxxxxxxxxx xxx xxxxxxx x xxxxxxxxxx xxxx](set-conditions-for-running-a-background-task.md)

    Xx xxxx xxxxxxx, xxx xxxxxxxxx xx xxx xx **XxxxxxxxXxxxxxxxx** xx xxxx xxxxxxxxxxx xxxx xxxx xxx Xxxxxxxx xx xxxxxxxxx (xx xxxx xx xxxxxxx xxxxxxxxx). Xxx x xxxx xx xxxxxxxx xxxxxxxxxx xxxx xxxxxxxxxx, xxx [**XxxxxxXxxxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br224835).

    Xxx xxxxxxxxx xxxx xxxx x xxxxxxxxx xx xxx xxxxxxxxxxx xxxx xxxxxxx:

    > [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
    > ```cs
    > SystemCondition exampleCondition = new SystemCondition(SystemConditionType.InternetAvailable);
    > ```
    > ```cpp
    > SystemCondition ^ exampleCondition = ref new SystemCondition(SystemConditionType::InternetAvailable);
    > ```

## Xxxxxxxx xxx xxxxxxxxxx xxxx


-   Xxxxxxxx xxx xxxxxxxxxx xxxx xx xxxxxxx xxxx xxxxxxxxxx xxxx xxxxxxxxxxxx xxxxxxxx. Xxx xxxx xxxxxxxxxxx xx xxxxxxxxxxx xxxxxxxxxx xxxxx, xxx [Xxxxxxxx x xxxxxxxxxx xxxx](register-a-background-task.md).

    Xxx xxxxxxxxx xxxx xxxxxxxxx xxx xxxxxxxxxxx xxxx:

    > [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
    > ```cs
    > string entryPoint = "Tasks.ExampleBackgroundTaskClass";
    > string taskName   = "Maintenance background task example";
    > 
    > BackgroundTaskRegistration task = RegisterBackgroundTask(entryPoint, taskName, taskTrigger, exampleCondition);
    > ```
    > ```cpp
    > String ^ entryPoint = "Tasks.ExampleBackgroundTaskClass";
    > String ^ taskName   = "Maintenance background task example";
    > 
    > BackgroundTaskRegistration ^ task = RegisterBackgroundTask(entryPoint, taskName, taskTrigger, exampleCondition);
    > ```
    
    > **Xxxx**  Xxx xxx xxxxxx xxxxxxxx xxxxxx xxxxxxx, xx xxx xxxxxx xxxxxxx xxx xx xxxxxx, xxxxxxxxxx xxxxx xxx xx xxxxxxxxxx. Xx xx xxx xx xxxxxx xxxxxxxxx xx xxx xxxxxxxx, xx xxx xxx xxxx xxx xxxxxx xx, xxxx xxx xxxxxxxxxx xxxx xxxx xx xxxxxxxxxx xxxxxxx xxxxxxx xxx xxxxxxx xxxxxxx xxx XxXxxxxxxx xxxxx. Xxxx xxxxx xx xxxxxx xxx xxxx xxxxxxxxxx xx xxx xxx xx xxx xxxxxxxxxx. Xxxx xxxxxxxxxx xxxx xxxxxx xx xxxxxxxx xx xxxxxx xxxx xxxxxxxx.

    > **Xxxx**  Xxxxxxxxx Xxxxxxx xxxx xxxx xxxx [**XxxxxxxXxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/hh700485) xxxxxx xxxxxxxxxxx xxx xx xxx xxxxxxxxxx xxxxxxx xxxxx.

    Xx xxxxxx xxxx xxxx Xxxxxxxxx Xxxxxxx xxx xxxxxxxxx xx xxx xxxxxxxx xxxxx xxx xxxxxxx xx xxxxxx, xxx xxxx xxxx [**XxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh700471) xxx xxxx xxxx [**XxxxxxxXxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/hh700485) xxxx xxxx xxx xxxxxxxx xxxxx xxxxx xxxxxxx. Xxx xxxx xxxxxxxxxxx, xxx [Xxxxxxxxxx xxx xxxxxxxxxx xxxxx](guidelines-for-background-tasks.md).

    > **Xxxx**  Xxxxxxxxxx xxxx xxxxxxxxxxxx xxxxxxxxxx xxx xxxxxxxxx xx xxx xxxx xx xxxxxxxxxxxx. Xx xxxxx xx xxxxxxxx xx xxx xx xxx xxxxxxxxxxxx xxxxxxxxxx xxx xxxxxxx. Xxxxxx xxxx xxxx xxx xxxxxxxxxx xxxxxxx xxxxxxxxx xxxxx xxxxxxxxxx xxxx xxxxxxxxxxxx xxxxx - xx xxxxxxx xxxx xxx xxxxxxx xx xxxxxx x xxxxx xxxxxxxxxxxx xxxxxx xxxxx xxxxxxxxxx xx xxxxxxxx x xxxx, xx xxx xxxxx.


> **Xxxx**  Xxxx xxxxxxx xx xxx Xxxxxxx YY xxxxxxxxxx xxxxxxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx. Xx xxx’xx xxxxxxxxxx xxx Xxxxxxx Y.x xx Xxxxxxx Xxxxx Y.x, xxx xxx [xxxxxxxx xxxxxxxxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132).

## Xxxxxxx xxxxxx


****

* [Xxxxxx xxx xxxxxxxx x xxxxxxxxxx xxxx](create-and-register-a-background-task.md)
* [Xxxxxxx xxxxxxxxxx xxxxx xx xxx xxxxxxxxxxx xxxxxxxx](declare-background-tasks-in-the-application-manifest.md)
* [Xxxxxx x xxxxxxxxx xxxxxxxxxx xxxx](handle-a-cancelled-background-task.md)
* [Xxxxxxx xxxxxxxxxx xxxx xxxxxxxx xxx xxxxxxxxxx](monitor-background-task-progress-and-completion.md)
* [Xxxxxxxx x xxxxxxxxxx xxxx](register-a-background-task.md)
* [Xxxxxxx xx xxxxxx xxxxxx xxxx xxxxxxxxxx xxxxx](respond-to-system-events-with-background-tasks.md)
* [Xxx xxxxxxxxxx xxx xxxxxxx x xxxxxxxxxx xxxx](set-conditions-for-running-a-background-task.md)
* [Xxxxxx x xxxx xxxx xxxx x xxxxxxxxxx xxxx](update-a-live-tile-from-a-background-task.md)
* [Xxx x xxxxxxxxxx xxxx xx x xxxxx](run-a-background-task-on-a-timer-.md)
* [Xxxxxxxxxx xxx xxxxxxxxxx xxxxx](guidelines-for-background-tasks.md)

****

* [Xxxxx x xxxxxxxxxx xxxx](debug-a-background-task.md)
* [Xxx xx xxxxxxx xxxxxxx, xxxxxx, xxx xxxxxxxxxx xxxxxx xx Xxxxxxx Xxxxx xxxx (xxxx xxxxxxxxx)](http://go.microsoft.com/fwlink/p/?linkid=254345)

 

 



<!--HONumber=Mar16_HO1-->
