---
xxxxx: Xxxxxxx xx xxxxxx xxxxxx xxxx xxxxxxxxxx xxxxx
xxxxxxxxxxx: Xxxxx xxx xx xxxxxx x xxxxxxxxxx xxxx xxxx xxxxxxxx xx XxxxxxXxxxxxx xxxxxx.
xx.xxxxxxx: YYXYYXXX-YYXY-YYYX-YYXX-XYYXYYXYYXYY
---

# Xxxxxxx xx xxxxxx xxxxxx xxxx xxxxxxxxxx xxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


**Xxxxxxxxx XXXx**

-   [**XXxxxxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br224794)
-   [**XxxxxxxxxxXxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br224768)
-   [**XxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br224838)

Xxxxx xxx xx xxxxxx x xxxxxxxxxx xxxx xxxx xxxxxxxx xx [**XxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br224839) xxxxxx.

Xxxx xxxxx xxxxxxx xxxx xxx xxxx x xxxxxxxxxx xxxx xxxxx xxxxxxx xxx xxxx xxx, xxx xxxx xxxx xxxx xxxxx xx xxx xx xxxxxxxx xx xx xxxxx xxxxxxxxx xx xxx xxxxxx xxxx xx xxx xxxxxxxx xxxxxxxx xxxxxxxxx xx xxx xxxx xxxxxxx xx. Xxxx xxxxx xxxxxxx xx xxx [**XxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br224839) xxxxx. Xxxx xxxxxxxxxxx xx xxxxxxx x xxxxxxxxxx xxxx xxxxx xx xxxxxxxxx xx [Xxxxxx xxx xxxxxxxx x xxxxxxxxxx xxxx](create-and-register-a-background-task.md).

## Xxxxxx x XxxxxxXxxxxxx xxxxxx


-   Xx xxxx xxx xxxx, xxxxxx x xxx [**XxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br224838) xxxxxx. Xxx xxxxx xxxxxxxxx, *xxxxxxxXxxx*, xxxxxxxxx xxx xxxx xx xxxxxx xxxxx xxxxxxx xxxx xxxx xxxxxxxx xxxx xxxxxxxxxx xxxx. Xxx x xxxx xx xxxxx xxxxx, xxx [**XxxxxxXxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br224839).

    Xxx xxxxxx xxxxxxxxx, *XxxXxxx*, xxxxxxxxx xxxxxxx xxx xxxxxxxxxx xxxx xxxx xxx xxxx xxx xxxx xxxx xxx xxxxxx xxxxx xxxxxx xxx xxxxxxxx xxxxxxxxxx xxxxx; xx, xxxxx xxxx xxx xxxxxx xxxxx xxxxxx, xxxxx xxx xxxx xx xxxxxxxxxxxx.

    Xxx xxxxxxxxx xxxx xxxxxxxxx xxxx xxx xxxxxxxxxx xxxx xxxx xxxxxxxx xxx Xxxxxxxx xxxxxxx xxxxxxxxx:

    > [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
    > ```cs
    > SystemTrigger internetTrigger = new SystemTrigger(SystemTriggerType.InternetAvailable, false);
    > ```
    > ```cpp
    > SystemTrigger ^ internetTrigger = ref new SystemTrigger(SystemTriggerType::InternetAvailable, false);
    > ```

## Xxxxxxxx xxx xxxxxxxxxx xxxx


-   Xxxxxxxx xxx xxxxxxxxxx xxxx xx xxxxxxx xxxx xxxxxxxxxx xxxx xxxxxxxxxxxx xxxxxxxx. Xxx xxxx xxxxxxxxxxx xx xxxxxxxxxxx xxxxxxxxxx xxxxx, xxx [Xxxxxxxx x xxxxxxxxxx xxxx](register-a-background-task.md).

    Xxx xxxxxxxxx xxxx xxxxxxxxx xxx xxxxxxxxxx xxxx:

    > [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
    > ```cs
    > string entryPoint = "Tasks.ExampleBackgroundTaskClass";
    > string taskName   = "Internet-based background task";
    > 
    > BackgroundTaskRegistration task = RegisterBackgroundTask(entryPoint, taskName, internetTrigger, exampleCondition);
    > ```
    > ```cpp
    > String ^ entryPoint = "Tasks.ExampleBackgroundTaskClass";
    > String ^ taskName   = "Internet-based background task";
    > 
    > BackgroundTaskRegistration ^ task = RegisterBackgroundTask(entryPoint, taskName, internetTrigger, exampleCondition);
    > ```

    > **Xxxx**  Xxxxxxxxx Xxxxxxx xxxx xxxx xxxx [**XxxxxxxXxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/hh700485) xxxxxx xxxxxxxxxxx xxx xx xxx xxxxxxxxxx xxxxxxx xxxxx.

    Xx xxxxxx xxxx xxxx Xxxxxxxxx Xxxxxxx xxx xxxxxxxxx xx xxx xxxxxxxx xxxxx xxx xxxxxxx xx xxxxxx, xxx xxxx xxxx [**XxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh700471) xxx xxxx xxxx [**XxxxxxxXxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/hh700485) xxxx xxxx xxx xxxxxxxx xxxxx xxxxx xxxxxxx. Xxx xxxx xxxxxxxxxxx, xxx [Xxxxxxxxxx xxx xxxxxxxxxx xxxxx](guidelines-for-background-tasks.md).

    > **Xxxx**  Xxxxxxxxxx xxxx xxxxxxxxxxxx xxxxxxxxxx xxx xxxxxxxxx xx xxx xxxx xx xxxxxxxxxxxx. Xx xxxxx xx xxxxxxxx xx xxx xx xxx xxxxxxxxxxxx xxxxxxxxxx xxx xxxxxxx. Xxxxxx xxxx xxxx xxx xxxxxxxxxx xxxxxxx xxxxxxxxx xxxxx xxxxxxxxxx xxxx xxxxxxxxxxxx xxxxx - xx xxxxxxx xxxx xxx xxxxxxx xx xxxxxx x xxxxx xxxxxxxxxxxx xxxxxx xxxxx xxxxxxxxxx xx xxxxxxxx x xxxx, xx xxx xxxxx.

     

## Xxxxxxx


Xx xxx xxxxxxxxxx xxxx xxxxxxxxxxxx xx xxxxxx, xxxxxxxx xxx [xxxxxxxxxx xxxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkId=618666).

Xxxxxxxxxx xxxxx xxx xxx xx xxxxxxxx xx [**XxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br224838) xxx [**XxxxxxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh700517) xxxxxx, xxx xxx xxxxx xxxx xx [Xxxxxxx xxxxxxxxxx xxxxx xx xxx xxxxxxxxxxx xxxxxxxx](declare-background-tasks-in-the-application-manifest.md). Xxx xxxx xxxx xxxx [**XxxxxxxXxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/hh700485) xxxxxx xxxxxxxxxxx xxx xxxxxxxxxx xxxx xxxx.

Xxxx xxx xxxxxxxx xxxxxxxxxx xxxxx xxxx xxxxxxx xx [**XxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br224843), [**XxxxXxxxxxxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh700543), xxx [**XxxxxxxXxxxxxxxXxxxxxxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br224831) xxxxxx, xxxxxxxx xxxx xx xxxxxxx xxxx-xxxx xxxxxxxxxxxxx xxxx xxx xxxx xxxx xxxx xxx xxx xx xxx xx xxx xxxxxxxxxx. Xxx xxxx xxxxxxxxxxx, xxx [Xxxxxxx xxxx xxx xxxx xxxxxxxxxx xxxxx](support-your-app-with-background-tasks.md).

> **Xxxx**  Xxxx xxxxxxx xx xxx Xxxxxxx YY xxxxxxxxxx xxxxxxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx. Xx xxx’xx xxxxxxxxxx xxx Xxxxxxx Y.x xx Xxxxxxx Xxxxx Y.x, xxx xxx [xxxxxxxx xxxxxxxxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132).

 
## Xxxxxxx xxxxxx


****

* [Xxxxxx xxx xxxxxxxx x xxxxxxxxxx xxxx](create-and-register-a-background-task.md)
* [Xxxxxxx xxxxxxxxxx xxxxx xx xxx xxxxxxxxxxx xxxxxxxx](declare-background-tasks-in-the-application-manifest.md)
* [Xxxxxx x xxxxxxxxx xxxxxxxxxx xxxx](handle-a-cancelled-background-task.md)
* [Xxxxxxx xxxxxxxxxx xxxx xxxxxxxx xxx xxxxxxxxxx](monitor-background-task-progress-and-completion.md)
* [Xxxxxxxx x xxxxxxxxxx xxxx](register-a-background-task.md)
* [Xxx xxxxxxxxxx xxx xxxxxxx x xxxxxxxxxx xxxx](set-conditions-for-running-a-background-task.md)
* [Xxxxxx x xxxx xxxx xxxx x xxxxxxxxxx xxxx](update-a-live-tile-from-a-background-task.md)
* [Xxx x xxxxxxxxxxx xxxxxxx](use-a-maintenance-trigger.md)
* [Xxx x xxxxxxxxxx xxxx xx x xxxxx](run-a-background-task-on-a-timer-.md)
* [Xxxxxxxxxx xxx xxxxxxxxxx xxxxx](guidelines-for-background-tasks.md)

****

* [Xxxxx x xxxxxxxxxx xxxx](debug-a-background-task.md)
* [Xxx xx xxxxxxx xxxxxxx, xxxxxx, xxx xxxxxxxxxx xxxxxx xx Xxxxxxx Xxxxx xxxx (xxxx xxxxxxxxx)](http://go.microsoft.com/fwlink/p/?linkid=254345)

 

 



<!--HONumber=Mar16_HO1-->
