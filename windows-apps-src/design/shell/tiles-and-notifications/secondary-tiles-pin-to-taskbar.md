---
Description: Learn how to pin secondary tiles to taskbar.
title: タスク バーにセカンダリ タイルをピン留め
label: Pin secondary tiles to taskbar
template: detail.hbs
ms.date: 11/28/2018
ms.topic: article
keywords: windows 10, uwp, セカンダリ タイルは、タスク バーに暗証番号 (pin)、タスク バーにセカンダリ タイルをピン留めショートカット
ms.localizationpriority: medium
ms.openlocfilehash: 7ad322fe371b0e1f3605ffb4c29108a15bb28e0c
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/30/2018
ms.locfileid: "8331761"
---
# <a name="pin-secondary-tiles-to-taskbar"></a>タスク バーにセカンダリ タイルをピン留め

セカンダリ タイルをスタート画面にピン留めと同様には、クイック アクセス許可を与えるコンテンツに、アプリ内でセカンダリ タイル、タスク バーに固定できます。

<img alt="Taskbar pinning" src="../images/taskbar/pin-secondary-ui.png" width="972"/>

> [!IMPORTANT]
> **制限付きのアクセス API**: この API は、制限されたアクセス機能です。 この API を使用してにお問い合わせください[taskbarsecondarytile@microsoft.com](mailto:taskbarsecondarytile@microsoft.com?Subject=Limited%20Access%20permission%20to%20use%20secondary%20tiles%20on%20taskbar)します。

> **年 2018年 10 月を必要と更新**: ビルド 17763 以上実行をタスク バーにピン留めして 17763 SDK をターゲットにする必要があります。


## <a name="guidance"></a>ガイダンス

セカンダリ タイルは、アプリ内の特定の領域に直接アクセスするユーザーの一貫性があり、効率的な方法を提供します。 ただし、ユーザーがタスク バーにセカンダリ タイルを「ピン留め」するかどうかと、アプリのピン留めできる場合の領域は開発者によって決まります。 詳細なガイダンスについては、[セカンダリ タイルのガイダンス](secondary-tiles-guidance.md)を参照してください。


## <a name="1-determine-if-api-exists-and-unlock-limited-access"></a>1. API が存在するかどうかを特定し、制限付きアクセスをロック解除

古いデバイス (Windows 10 の以前のバージョンをターゲットとしている) 場合は、Api をピン留め、タスク バーはありません。 したがって、ピン留めできるはこれらのデバイスで、暗証番号 (pin) ボタンを表示しないでください。

さらに、この機能は、アクセスが制限された [ロックされています。 アクセスを取得するには、Microsoft にお問い合わせください。 **[TaskbarManager.RequestPinSecondaryTileAsync](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager.requestpinsecondarytileasync#Windows_UI_Shell_TaskbarManager_RequestPinSecondaryTileAsync_Windows_UI_StartScreen_SecondaryTile_)**、 **[TaskbarManager.IsSecondaryTilePinnedAsync](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager.issecondarytilepinnedasync)**、および**[TaskbarManager.TryUnpinSecondaryTileAsync](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager.tryunpinsecondarytileasync)** API 呼び出しは、アクセス拒否例外で失敗します。 アプリは、アクセス許可することがなく、この API を使用して許可されず、API の定義は、いつでもでも変更可能性があります。

Api が存在するかどうかを判断するには、 [ApiInformation.IsMethodPresent](https://docs.microsoft.com/uwp/api/windows.foundation.metadata.apiinformation.ismethodpresent#Windows_Foundation_Metadata_ApiInformation_IsMethodPresent_System_String_System_String_)メソッドを使います。 **[LimitedAccessFeatures](https://docs.microsoft.com/uwp/api/windows.applicationmodel.limitedaccessfeatures)** API を使用して、API のロックを解除してみてください。

```csharp
if (ApiInformation.IsMethodPresent("Windows.UI.Shell.TaskbarManager", "RequestPinSecondaryTileAsync"))
{
    // API present!
    // Unlock the pin to taskbar feature
    var result = LimitedAccessFeatures.TryUnlockFeature(
        "com.microsoft.windows.secondarytilemanagement",
        "<tokenFromMicrosoft>",
        "<publisher> has registered their use of com.microsoft.windows.secondarytilemanagement with Microsoft and agrees to the terms of use.");

    // If unlock succeeded
    if ((result.Status == LimitedAccessFeatureStatus.Available) ||
        (result.Status == LimitedAccessFeatureStatus.AvailableWithoutToken))
    {
        // Continue
    }
    else
    {
        // Don't show pin to taskbar button or call any of the below APIs
    }
}

else
{
    // Don't show pin to taskbar button or call any of the below APIs
}
```


## <a name="2-get-the-taskbarmanager-instance"></a>2. TaskbarManager インスタンスを取得します。

UWP アプリはさまざまなデバイスで実行できます。それらのすべてがタスク バーをサポートするとは限りません。 現時点では、デスクトップ デバイスのみがタスク バーをサポートしています。 さらに、タスク バーのプレゼンスは、付属し、移動します。 タスク バーが現在存在するかどうかを確認する、 **[TaskbarManager.GetDefault](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager.getdefault)** メソッドを呼び出して、返されるインスタンスを確認して、が null でないです。 タスク バーが存在していない場合、暗証番号 (pin) ボタンを表示しないでください。

ピン留めすると、次回の別の操作を実行する必要がある新しいインスタンスを取得しなどの 1 つの操作の期間中のインスタンスを保持することをお勧めします。

```csharp
TaskbarManager taskbarManager = TaskbarManager.GetDefault();

if (taskbarManager != null)
{
    // Continue
}
else
{
    // Taskbar not present, don't display a pin button
}
```


## <a name="3-check-whether-your-tile-is-currently-pinned-to-the-taskbar"></a>3.、タイルが現在タスク バーにピン留めされているかどうかを確認します。

タイルが既にピン留めした場合は、代わりに、ピン留めを外す] ボタンを表示する必要があります。 タイルが現在ピン留めされているかどうかを確認する**[IsSecondaryTilePinnedAsync](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager.issecondarytilepinnedasync)** メソッドを使用することができます (ユーザーをピン留めを外すにいつでもでも)。 知りたいタイルの**TileId**を渡すことで、このメソッドをピン留めします。

```csharp
if (await taskbarManager.IsSecondaryTilePinnedAsync("myTileId"))
{
    // The tile is already pinned. Display the unpin button.
}

else 
{
    // The tile is not pinned. Display the pin button.
}
```


## <a name="4-check-whether-pinning-is-allowed"></a>4. ピン留めが許可されているかどうかを確認します。

グループ ポリシーによって、タスク バーにピン留めを無効にすることができます。 [TaskbarManager.IsPinningAllowed](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager.ispinningallowed)プロパティを使用して、ピン留めが許可されているかどうかを確認できます。

このプロパティをチェックする必要があります、ユーザーが、暗証番号 (pin) ボタンをクリックしが false の場合は、このコンピューターにピン留めが許可されていないユーザーに知らせるメッセージ ダイアログを表示する必要があります。

```csharp
TaskbarManager taskbarManager = TaskbarManager.GetDefault();
if (taskbarManager == null)
{
    // Display message dialog informing user that taskbar is no longer present, and then hide the button
}

else if (taskbarManager.IsPinningAllowed == false)
{
    // Display message dialog informing user pinning is not allowed on this machine
}

else
{
    // Continue pinning
}
```


## <a name="5-construct-and-pin-your-tile"></a>5. を構築し、タイルをピン留め

ユーザーが、暗証番号 (pin) ボタンをクリックし、Api が存在すること、タスク バーが存在する、およびピン留めを許可する] を決定した暗証番号 (pin) までの時間です。

最初に、スタート画面にピン留めした場合と同様に、セカンダリ タイルを作成します。 セカンダリ タイルのプロパティについて詳しくは、[スタート画面にセカンダリ タイルをピン留め](secondary-tiles-pinning.md)を読み取ること知ることができます。 ただし、以前の必須のプロパティだけでなく、タスク バーにピン留めした場合 (これは、タスク バーで使われるロゴ) Square44x44Logo も必要です。 それ以外の場合、例外がスローされます。

次に、タイルを**[RequestPinSecondaryTileAsync](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager.requestpinsecondarytileasync)** メソッドに渡します。 これは、制限付きアクセスの下であるためこれによって確認のダイアログ ボックスが表示されなくされ、UI スレッドは必要ありません。 ただし、今後このを開いたときアクセス制限されたを超えて呼び出し元の制限付きアクセスを利用していないダイアログ ボックスが表示され、UI スレッドを使用する必要があります。

```csharp
// Initialize the tile (all properties below are required)
SecondaryTile tile = new SecondaryTile("myTileId");
tile.DisplayName = "PowerPoint 2016 (Remote)";
tile.Arguments = "app=powerpoint";
tile.VisualElements.Square44x44Logo = new Uri("ms-appdata:///AppIcons/PowerPoint_Square44x44Logo.png");
tile.VisualElements.Square150x150Logo = new Uri("ms-appdata:///AppIcons/PowerPoint_Square150x150Logo.png");

// Pin it to the taskbar
bool isPinned = await taskbarManager.RequestPinSecondaryTileAsync(tile);
```

このメソッドは、タイルがタスク バーにピン留めできるようになりましたかどうかを示すブール値を返します。 タイルが既にピン留めされている場合、このメソッドは、既存のタイルを更新し、true を返します。 ピン留めが許可されているか、タスク バーがサポートされていない場合、このメソッドは false を返します。


## <a name="enumerate-tiles"></a>タイルを列挙します。

作成し、まだはどこかにピン留めされているすべてのタイルを参照してください (スタート画面、タスク バー、またはその両方)、 **[FindAllAsync](https://docs.microsoft.com/uwp/api/windows.ui.startscreen.secondarytile.findallasync)** を使用します。 その後、これらのタイルがスタート画面やタスク バーにピン留めされているかどうかを確認できます。 サーフェスがサポートされていない場合は、これらのメソッドは false を返します。

```csharp
var taskbarManager = TaskbarManager.GetDefault();
var startScreenManager = StartScreenManager.GetDefault();

// Look through all tiles
foreach (SecondaryTile tile in await SecondaryTile.FindAllAsync())
{
    if (taskbarManager != null && await taskbarManager.IsSecondaryTilePinnedAsync(tile.TileId))
    {
        // Tile is pinned to the taskbar
    }

    if (startScreenManager != null && await startScreenManager.ContainsSecondaryTileAsync(tile.TileId))
    {
        // Tile is pinned to Start
    }
}
```


## <a name="update-a-tile"></a>タイルを更新します。

[セカンダリ タイルを更新](secondary-tiles-pinning.md#updating-a-secondary-tile)」の説明に従って、既にピン留めしたタイルを更新して、 [**SecondaryTile.UpdateAsync**](https://docs.microsoft.com/uwp/api/windows.ui.startscreen.secondarytile.updateasync)メソッドを使用できます。


## <a name="unpin-a-tile"></a>タイルのピン留めを外す

タイルが現在ピン留めされている場合、アプリは、ピン留めを外す] ボタンを用意する必要があります。 タイルをピン留めを外すを**[TryUnpinSecondaryTileAsync](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager.tryunpinsecondarytileasync)** を渡して外したするセカンダリ タイルの**TileId**を呼び出すだけです。

このメソッドは、タイルがタスク バーにピン留めできなくするかどうかを示すブール値を返します。 場合は、タイルがピン留めされている、最初に、これも true を返します。 外したりが許可された場合、これは false を返します。

タイルがタスク バーにピン留めのみと、タイルを任意の場所にピン留めされなくなったためこの削除されます。

```csharp
var taskbarManager = TaskbarManager.GetDefault();
if (taskbarManager != null)
{
    bool isUnpinned = await taskbarManager.TryUnpinSecondaryTileAsync("myTileId");
}
```


## <a name="delete-a-tile"></a>タイルを削除します。

すべての場所 (スタート画面、タスク バー) からのタイルのピン留めを外す場合は、 **[RequestDeleteAsync](https://docs.microsoft.com/uwp/api/windows.ui.startscreen.secondarytile.requestdeleteasync)** メソッドを使用します。

これは、ユーザーがピン留めされている内容が適用可能なしなくなった場合に適しています。 たとえば、アプリでは、スタート画面とタスク バーにノートブックをピン留めすることができ、ユーザーがノートブックを削除し場合、は、ノートブックに関連付けられているタイルを単に削除する必要があります。

```csharp
// Initialize a secondary tile with the same tile ID you want removed.
// Or, locate it with FindAllAsync()
SecondaryTile toBeDeleted = new SecondaryTile(tileId);

// And then delete the tile
await toBeDeleted.RequestDeleteAsync();
```


## <a name="unpin-only-from-start"></a>スタート画面からのみピン留めを外す

タスク バーのまま、セカンダリ タイルをスタートからピン留めを外す場合は、 **[StartScreenManager.TryRemoveSecondaryTileAsync](https://docs.microsoft.com/uwp/api/windows.ui.startscreen.startscreenmanager.tryremovesecondarytileasync)** メソッドを呼び出すことができます。 同様に他の任意のサーフェスになったピン留めした場合、タイルが削除されます。

このメソッドは、タイルがスタート画面にピン留めできなくするかどうかを示すブール値を返します。 場合は、タイルがピン留めされている、最初に、これも true を返します。 外したり許可されない、またはスタート画面がサポートされていない、これは false を返します。

```csharp
await StartScreenManager.GetDefault().TryRemoveSecondaryTileAsync("myTileId");
```


## <a name="resources"></a>リソース

* [TaskbarManager クラス](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager)
* [スタート画面にセカンダリ タイルをピン留め](secondary-tiles-pinning.md)