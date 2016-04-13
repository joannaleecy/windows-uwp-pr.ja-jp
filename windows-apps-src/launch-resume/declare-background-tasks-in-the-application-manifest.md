---
title: アプリケーション マニフェストでのバックグラウンド タスクの宣言
description: アプリ マニフェストでバックグラウンド タスクを拡張機能として宣言し、バックグラウンド タスクを使うことができるようにします。
ms.assetid: 6B4DD3F8-3C24-4692-9084-40999A37A200
---

# アプリケーション マニフェストでのバックグラウンド タスクの宣言


\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]


**重要な API**

-   [**BackgroundTasks スキーマ**](https://msdn.microsoft.com/library/windows/apps/br224794)
-   [**Windows.ApplicationModel.Background**](https://msdn.microsoft.com/library/windows/apps/br224847)

アプリ マニフェストでバックグラウンド タスクを拡張機能として宣言し、バックグラウンド タスクを使うことができるようにします。

バックグラウンド タスクはアプリ マニフェストで宣言されている必要があります。このようにしないと、アプリはバックグラウンド タスクを登録できません (例外がスローされます)。 また、認定に合格するように、アプリケーション マニフェストでバックグラウンド タスクを宣言する必要があります。

このトピックでは、1 つ以上のバックグラウンド タスク クラスが作られていて、少なくとも 1 つのトリガーに応答して実行されるようにアプリで各バックグラウンド タスクを登録するものとします。

## 手動での拡張機能の追加


アプリケーション マニフェスト (Package.appxmanifest) を開き、Application 要素に移動します。 Extensions 要素を作ります (まだ存在していない場合)。

次に示す例は、[バックグラウンド タスクのサンプル](http://go.microsoft.com/fwlink/p/?LinkId=618666)から抜粋したものです。

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

## バックグラウンド タスク拡張機能の追加


最初のバックグラウンド タスクを宣言します。

このコードを Extensions 要素にコピーします (次の手順で属性を追加します)。

```xml
      <Extensions>
        <Extension Category="windows.backgroundTasks" EntryPoint="">
          <BackgroundTasks>
            <Task Type="" />
          </BackgroundTasks>
        </Extension>
      </Extensions>
```

1.  EntryPoint 属性を、バックグラウンド タスクの登録時にエントリ ポイントとしてコードで使ったものと同じ文字列に変更します (**namespace.classname**)。

    この例のエントリ ポイントは、ExampleBackgroundTaskNameSpace.ExampleBackgroundTaskClassName です。

    ```xml
          <Extensions>
            <Extension Category="windows.backgroundTasks" EntryPoint="Tasks.ExampleBackgroundTaskClassName">
              <BackgroundTasks>
                <Task Type="" />
              </BackgroundTasks>
            </Extension>
          </Extensions>
    ```

2.  Task Type 属性のリストを、このバックグラウンド タスクで使われるタスク登録の種類を示すように変更します。 バックグラウンド タスクを複数の種類のトリガーで登録する場合は、必要な Task 要素と Type 属性を個々に追加します。

    **Note**  使っているトリガーの各種類を確実に列記してください。そうしないと、バックグラウンド タスクは宣言されていない種類のトリガーには登録されません ([**Register**](https://msdn.microsoft.com/library/windows/apps/br224772) メソッドが失敗し、例外がスローされます)。

    次の抜粋例は、システム イベント トリガーとプッシュ通知の使用法を示します。

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

## 関連トピック

* [バックグラウンド タスクのデバッグ](debug-a-background-task.md)
* [バックグラウンド タスクの登録](register-a-background-task.md)
* [バックグラウンド タスクのガイドライン](guidelines-for-background-tasks.md)

 

 





<!--HONumber=Mar16_HO1-->


