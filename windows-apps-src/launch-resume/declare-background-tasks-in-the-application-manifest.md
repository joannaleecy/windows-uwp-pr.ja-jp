---
title: アプリケーション マニフェストでのバックグラウンド タスクの宣言
description: アプリ マニフェストでバックグラウンド タスクを拡張機能として宣言し、バックグラウンド タスクを使うことができるようにします。
ms.assetid: 6B4DD3F8-3C24-4692-9084-40999A37A200
ms.date: 02/08/2017
ms.topic: article
keywords: バック グラウンド タスクの windows 10, uwp,
ms.localizationpriority: medium
ms.openlocfilehash: 4b30cd39a4440a1ade1ea0dda5a35d3f7c15f963
ms.sourcegitcommit: 175d0fc32db60017705ab58136552aee31407412
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 02/27/2019
ms.locfileid: "9114518"
---
# <a name="declare-background-tasks-in-the-application-manifest"></a>アプリケーション マニフェストでのバックグラウンド タスクの宣言




**重要な API**

-   [**BackgroundTasks スキーマ**](https://msdn.microsoft.com/library/windows/apps/br224794)
-   [**Windows.ApplicationModel.Background**](https://msdn.microsoft.com/library/windows/apps/br224847)

アプリ マニフェストでバックグラウンド タスクを拡張機能として宣言し、バックグラウンド タスクを使うことができるようにします。

> [!Important]
>  この記事は、アウトプロセスのバック グラウンド タスクに固有です。 インプロセスのバックグラウンド タスクは、マニフェストで宣言されていません。

アウトプロセスのバックグラウンド タスクはアプリ マニフェストで宣言されている必要があります。このようにしないと、アプリはバックグラウンド タスクを登録できません (例外がスローされます)。 また、認定に合格するには、アプリケーション マニフェストでアウトプロセスのバックグラウンド タスクを宣言する必要があります。

このトピックでは、1 つ以上のバックグラウンド タスク クラスが作られていて、少なくとも 1 つのトリガーに応答して実行されるようにアプリで各バックグラウンド タスクを登録するものとします。

## <a name="add-extensions-manually"></a>手動での拡張機能の追加


アプリケーション マニフェスト (Package.appxmanifest) を開き、Application 要素に移動します。 Extensions 要素を作ります (まだ存在していない場合)。

次に示す例は、[バックグラウンド タスクのサンプル](https://go.microsoft.com/fwlink/p/?LinkId=618666)から抜粋したものです。

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

## <a name="add-a-background-task-extension"></a>バックグラウンド タスク拡張機能の追加  

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

    **注:** トリガーの種類の各リストを使用している、または宣言されていないトリガーの種類 ([**登録**](https://msdn.microsoft.com/library/windows/apps/br224772)メソッドが失敗し、例外がスロー) と、バック グラウンド タスクは登録されないかどうかを確認します。

    次の抜粋例は、システム イベント トリガーとプッシュ通知の使用法を示します。

```xml
<Extension Category="windows.backgroundTasks" EntryPoint="Tasks.BackgroundTaskClass">
    <BackgroundTasks>
        <Task Type="systemEvent" />
        <Task Type="pushNotification" />
    </BackgroundTasks>
</Extension>
```

### <a name="add-multiple-background-task-extensions"></a>複数のバックグラウンド タスク拡張機能の追加

アプリで登録する追加のバックグラウンド タスク クラスごとに、手順 2. を繰り返します。

次に、[バックグラウンド タスク サンプル]( https://go.microsoft.com/fwlink/p/?linkid=227509)の完全な Application 要素の例を示します。 これは、計 3 種類のトリガーで 2 つのバックグラウンド タスク クラスを使う例を示します。 この例の Extensions セクションをコピーし、必要に応じて変更して、アプリケーション マニフェストでバックグラウンド タスクを宣言します。

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

## <a name="declare-where-your-background-task-will-run"></a>バック グラウンド タスクの実行先の宣言

バックグラウンド タスクの実行先を指定することができます。

* 既定では、BackgroundTaskHost.exe プロセスで実行されます。
* フォアグラウンド アプリケーションと同じプロセスで実行できます。
* `ResourceGroup` を使用すると、複数のバックグラウンド タスクを同じホスティング プロセスに配置したり、異なるプロセスに分離したりすることができます。
* `SupportsMultipleInstances` を使用すると、新しいトリガーが発生するたびに、独自のリソース制限 (メモリ、CPU) を持つ新しいプロセスでバックグラウンド プロセスが実行されます。

### <a name="run-in-the-same-process-as-your-foreground-application"></a>フォアグラウンド アプリケーションと同じプロセスでの実行

フォアグラウンド アプリケーションと同じプロセスで実行されるバック グラウンド タスクを宣言する XML の例を次に示します。

```xml
<Extensions>
    <Extension Category="windows.backgroundTasks" EntryPoint="ExecModelTestBackgroundTasks.ApplicationTriggerTask">
        <BackgroundTasks>
            <Task Type="systemEvent" />
        </BackgroundTasks>
    </Extension>
</Extensions>
```

**EntryPoint** を指定すると、アプリケーションは指定されたメソッドへのコールバックをトリガーの発生時に受け取ります。 **EntryPoint** を指定していない場合、アプリケーションは [OnBackgroundActivated()](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.application.onbackgroundactivated.aspx) を介してコールバックを受け取ります。  詳しくは、「[インプロセス バックグラウンド タスクの作成と登録](create-and-register-an-inproc-background-task.md)」をご覧ください

### <a name="specify-where-your-background-task-runs-with-the-resourcegroup-attribute"></a>ResourceGroup 属性を使用して、バックグラウンド タスクの実行先を指定

BackgroundTaskHost.exe プロセスで実行されるが、同じアプリのバックグラウンド タスクの他のインスタンスとは別に実行される、バックグラウンド タスクを宣言する XML の例を示します。 共に実行されるバックグラウンド タスクを指定する、`ResourceGroup` 属性に注意してください。

```xml
<Extensions>
    <Extension Category="windows.backgroundTasks" EntryPoint="BackgroundTasks.SessionConnectedTriggerTask" ResourceGroup="foo">
      <BackgroundTasks>
        <Task Type="systemEvent" />
      </BackgroundTasks>
    </Extension>
    <Extension Category="windows.backgroundTasks" EntryPoint="BackgroundTasks.TimeZoneTriggerTask" ResourceGroup="foo">
      <BackgroundTasks>
        <Task Type="systemEvent" />
      </BackgroundTasks>
    </Extension>
    <Extension Category="windows.backgroundTasks" EntryPoint="BackgroundTasks.TimerTriggerTask" ResourceGroup="bar">
      <BackgroundTasks>
        <Task Type="timer" />
      </BackgroundTasks>
    </Extension>
    <Extension Category="windows.backgroundTasks" EntryPoint="BackgroundTasks.ApplicationTriggerTask" ResourceGroup="bar">
      <BackgroundTasks>
        <Task Type="general" />
      </BackgroundTasks>
    </Extension>
    <Extension Category="windows.backgroundTasks" EntryPoint="BackgroundTasks.MaintenanceTriggerTask" ResourceGroup="foobar">
      <BackgroundTasks>
        <Task Type="general" />
      </BackgroundTasks>
    </Extension>
</Extensions>
```

### <a name="run-in-a-new-process-each-time-a-trigger-fires-with-the-supportsmultipleinstances-attribute"></a>SupportsMultipleInstances 属性を使用して、トリガーが発生するたびに新しいプロセスで実行

この例では、新しいトリガーが発生するたびに独自のリソース制限 (メモリと CPU) を持つ新しいプロセスで実行される、バックグラウンド タスクを宣言します。 `SupportsMultipleInstances` を使っていることに注目してください。この属性がこの動作を実現します。 この属性を使用するためにはターゲット SDK バージョン '10.0.15063' (Windows 10 Creators Update) 以上。

```xml
<Package
    xmlns:uap4="http://schemas.microsoft.com/appx/manifest/uap/windows10/4"
    ...
    <Applications>
        <Application ...>
            ...
            <Extensions>
                <Extension Category="windows.backgroundTasks" EntryPoint="BackgroundTasks.TimerTriggerTask">
                    <BackgroundTasks uap4:SupportsMultipleInstances=“True”>
                        <Task Type="timer" />
                    </BackgroundTasks>
                </Extension>
            </Extensions>
        </Application>
    </Applications>
```

> [!NOTE]
> `SupportsMultipleInstances` と共に `ResourceGroup` または `ServerName` を指定することはできません。

## <a name="related-topics"></a>関連トピック

* [バックグラウンド タスクのデバッグ](debug-a-background-task.md)
* [バックグラウンド タスクの登録](register-a-background-task.md)
* [バックグラウンド タスクのガイドライン](guidelines-for-background-tasks.md)
