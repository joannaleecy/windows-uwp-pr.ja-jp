---
xxxxx: Xxxxxxx xxxxxxxxxx xxxxx xx xxx xxxxxxxxxxx xxxxxxxx
xxxxxxxxxxx: Xxxxxx xxx xxx xx xxxxxxxxxx xxxxx xx xxxxxxxxx xxxx xx xxxxxxxxxx xx xxx xxx xxxxxxxx.
xx.xxxxxxx: YXYXXYXY-YXYY-YYYY-YYYY-YYYYYXYYXYYY
---

# Xxxxxxx xxxxxxxxxx xxxxx xx xxx xxxxxxxxxxx xxxxxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


**Xxxxxxxxx XXXx**

-   [**XxxxxxxxxxXxxxx Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/br224794)
-   [**Xxxxxxx.XxxxxxxxxxxXxxxx.Xxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br224847)

Xxxxxx xxx xxx xx xxxxxxxxxx xxxxx xx xxxxxxxxx xxxx xx xxxxxxxxxx xx xxx xxx xxxxxxxx.

Xxxxxxxxxx xxxxx xxx xx xxxxxxxx xx xxx xxx xxxxxxxx xx xxxx xxxx xxx xxxx xxx xx xxxx xx xxxxxxxx xxxx (xx xxxxxxxxx xxxx xx xxxxxx). Xxxxxxxxxxxx, xxxxxxxxxx xxxxx xxxx xx xxxxxxxx xx xxx xxxxxxxxxxx xxxxxxxx xx xxxx xxxxxxxxxxxxx.

Xxxx xxxxx xxxxxxx xxx xxxx x xxxxxxx xxx xx xxxx xxxxxxxxxx xxxx xxxxxxx, xxx xxxx xxxx xxx xxxxxxxxx xxxx xxxxxxxxxx xxxx xx xxx xx xxxxxxxx xx xx xxxxx xxx xxxxxxx.

## Xxx Xxxxxxxxxx Xxxxxxxx


Xxxx xxx xxxxxxxxxxx xxxxxxxx (Xxxxxxx.xxxxxxxxxxxx) xxx xx xx xxx Xxxxxxxxxxx xxxxxxx. Xxxxxx xx Xxxxxxxxxx xxxxxxx (xx xxx xxxxx'x xxxxxxx xxxxx).

Xxx xxxxxxxxx xxxxxxx xx xxxxx xxxx xxx [xxxxxxxxxx xxxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkId=618666):

```xml
<Application Id="App"
   ...
   <Extensions>
     <Extension Category="windows.backgroundTasks" EntryPoint="Tasks.SampleBackgroundTask">
       <BackgroundTasks>
         <Task Type="systemEvent" />
         <Task Type="timer" />
       </BackgroundTasks>
     </Extension>
     <Extension Category="windows.backgroundTasks" EntryPoint="Tasks.ServicingComplete">
       <BackgroundTasks>
         <Task Type="systemEvent"/>
       </BackgroundTasks>
     </Extension>
   </Extensions>
 </Application>
```

## Xxx x Xxxxxxxxxx Xxxx Xxxxxxxxx


Xxxxxxx xxxx xxxxx xxxxxxxxxx xxxx.

Xxxx xxxx xxxx xxxx xxx Xxxxxxxxxx xxxxxxx (xxx xxxx xxx xxxxxxxxxx xx xxx xxxxxxxxx xxxxx).

```xml
      <Extensions>
        <Extension Category="windows.backgroundTasks" EntryPoint="">
          <BackgroundTasks>
            <Task Type="" />
          </BackgroundTasks>
        </Extension>
      </Extensions>
```

1.  Xxxxxx xxx XxxxxXxxxx xxxxxxxxx xx xxxx xxx xxxx xxxxxx xxxx xx xxxx xxxx xx xxx xxxxx xxxxx xxxx xxxxxxxxxxx xxxx xxxxxxxxxx xxxx (**xxxxxxxxx.xxxxxxxxx**).

    Xx xxxx xxxxxxx, xxx xxxxx xxxxx xx XxxxxxxXxxxxxxxxxXxxxXxxxXxxxx.XxxxxxxXxxxxxxxxxXxxxXxxxxXxxx:

    ```xml
          <Extensions>
            <Extension Category="windows.backgroundTasks" EntryPoint="Tasks.ExampleBackgroundTaskClassName">
              <BackgroundTasks>
                <Task Type="" />
              </BackgroundTasks>
            </Extension>
          </Extensions>
    ```

2.  Xxxxxx xxx xxxx xx Xxxx Xxxx xxxxxxxxx xx xxxxxxxx xxx xxxx xx xxxx xxxxxxxxxxxx xxxx xxxx xxxx xxxxxxxxxx xxxx. Xx xxx xxxxxxxxxx xxxx xx xxxxxxxxxx xxxx xxxxxxxx xxxxxxx xxxxx, xxx xxxxxxxxxx Xxxx xxxxxxxx xxx Xxxx xxxxxxxxxx xxx xxxx xxx.

    **Xxxx**  Xxxx xxxx xx xxxx xxxx xx xxx xxxxxxx xxxxx xxx'xx xxxxx, xx xxx xxxxxxxxxx xxxx xxxx xxx xxxxxxxx xxxx xxx xxxxxxxxxx xxxxxxx xxxxx (xxx [**Xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br224772) xxxxxx xxxx xxxx xxx xxxxx xx xxxxxxxxx).

    Xxxx xxxxxxx xxxxxxx xxxxxxxxx xxx xxx xx xxxxxx xxxxx xxxxxxxx xxx xxxx xxxxxxxxxxxxx:

    ```xml
                <Extension Category="windows.backgroundTasks" EntryPoint="Tasks.BackgroundTaskClass">
                  <BackgroundTasks>
                    <Task Type="systemEvent" />
                    <Task Type="pushNotification" />
                  </BackgroundTasks>
                </Extension>
                ```

    > **Note**  Normally, an app will run in a special process called "BackgroundTaskHost.exe". It is possible to add an Executable element to the Extension element, allowing the background task to run in the context of the app. Only use the Executable element with background tasks that require it, such as the [**ControlChannelTrigger**](https://msdn.microsoft.com/library/windows/apps/hh701032).    

## Add Additional Background Task Extensions


Repeat step 2 for each additional background task class registered by your app.

The following example is the complete Application element from the [background task sample]( http://go.microsoft.com/fwlink/p/?linkid=227509). This shows the use of 2 background task classes with a total of 3 trigger types. Copy the Extensions section of this example, and modify it as needed, to declare background tasks in your application manifest.

```xml
<Applications>
    <Application Id="App"
      Executable="$targetnametoken$.exe"
      EntryPoint="BackgroundTask.App">
        <uap:VisualElements
          DisplayName="BackgroundTask"
          Square150x150Logo="Assets\StoreLogo-sdk.png"
          Square44x44Logo="Assets\SmallTile-sdk.png"
          Description="BackgroundTask"
          
          BackgroundColor="#00b2f0">
          <uap:LockScreen Notification="badgeAndTileText" BadgeLogo="Assets\smalltile-Windows-sdk.png" />
            <uap:SplashScreen Image="Assets\Splash-sdk.png" />
            <uap:DefaultTile DefaultSize="square150x150Logo" Wide310x150Logo="Assets\tile-sdk.png" >
                <uap:ShowNameOnTiles>
                    <uap:ShowOn Tile="square150x150Logo" />
                    <uap:ShowOn Tile="wide310x150Logo" />
                </uap:ShowNameOnTiles>
            </uap:DefaultTile>
        </uap:VisualElements>

      <Extensions>
        <Extension Category="windows.backgroundTasks" EntryPoint="Tasks.SampleBackgroundTask">
          <BackgroundTasks>
            <Task Type="systemEvent" />
            <Task Type="timer" />
          </BackgroundTasks>
        </Extension>
        <Extension Category="windows.backgroundTasks" EntryPoint="Tasks.ServicingComplete">
          <BackgroundTasks>
            <Task Type="systemEvent"/>
          </BackgroundTasks>
        </Extension>
      </Extensions>
    </Application>
</Applications>
```

## Xxxxxxx xxxxxx

* [Xxxxx x xxxxxxxxxx xxxx](debug-a-background-task.md)
* [Xxxxxxxx x xxxxxxxxxx xxxx](register-a-background-task.md)
* [Xxxxxxxxxx xxx xxxxxxxxxx xxxxx](guidelines-for-background-tasks.md)

 

 



<!--HONumber=Mar16_HO1-->
