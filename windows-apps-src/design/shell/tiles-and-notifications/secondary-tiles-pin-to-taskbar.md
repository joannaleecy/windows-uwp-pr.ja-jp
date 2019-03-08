---
Description: タスク バーに、セカンダリ タイルをピン留めする方法について説明します。
title: タスク バーに、セカンダリ タイルをピン留め
label: Pin secondary tiles to taskbar
template: detail.hbs
ms.date: 11/28/2018
ms.topic: article
keywords: windows 10、uwp、タスク バーで、セカンダリ タイルにピン留めするには、タスク バーで、セカンダリ タイルをピン留めショートカット
ms.localizationpriority: medium
ms.openlocfilehash: 7ad322fe371b0e1f3605ffb4c29108a15bb28e0c
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57591977"
---
# <a name="pin-secondary-tiles-to-taskbar"></a>タスク バーに、セカンダリ タイルをピン留め

開始するセカンダリ タイルをピン留めと同じようには、アプリ内でコンテンツをユーザー クイック アクセスを付与セカンダリ タイル、タスク バーに固定できます。

<img alt="Taskbar pinning" src="../images/taskbar/pin-secondary-ui.png" width="972"/>

> [!IMPORTANT]
> **API のアクセス制限**:この API は、制限付きアクセス機能です。 この API を使用する連絡[ taskbarsecondarytile@microsoft.com](mailto:taskbarsecondarytile@microsoft.com?Subject=Limited%20Access%20permission%20to%20use%20secondary%20tiles%20on%20taskbar)します。

> **2018 の年 10 月の更新プログラムが必要**:17763 SDK をターゲットする必要があり、ビルド 17763 以降を実行してあるタスクバーにピン留めします。


## <a name="guidance"></a>ガイダンス

セカンダリ タイルは、アプリ内の特定の領域に直接アクセスするユーザーの一貫性があり、効率的な方法を提供します。 ユーザーがタスク バーにセカンダリ タイルを「ピン留め」するかどうかを選択、ですが、アプリ内で固定できる領域は、開発者によって決まります。 詳細なガイダンスについては、次を参照してください。[セカンダリ タイル ガイダンス](secondary-tiles-guidance.md)します。


## <a name="1-determine-if-api-exists-and-unlock-limited-access"></a>1. API が存在するかどうかを判断し、制限付きアクセスのロックを解除

古いデバイスは、(以前のバージョンの Windows 10 を対象としている) 場合は、Api をピン留め、タスク バーに必要はありません。 そのため、これらのピン留め対応ではないデバイスに暗証番号 (pin) ボタンを表示しないでください。

さらに、この機能は、制限付きアクセスでロックされています。 アクセスを取得するには、Microsoft にお問い合わせください。 API の呼び出しに **[TaskbarManager.RequestPinSecondaryTileAsync](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager.requestpinsecondarytileasync#Windows_UI_Shell_TaskbarManager_RequestPinSecondaryTileAsync_Windows_UI_StartScreen_SecondaryTile_)**、  **[TaskbarManager.IsSecondaryTilePinnedAsync](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager.issecondarytilepinnedasync)**、および**[TaskbarManager.TryUnpinSecondaryTileAsync](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager.tryunpinsecondarytileasync)** はアクセス拒否例外で失敗します。 アプリが、アクセス許可なしには、この API を使用して許可されていませんし、API の定義は、いつでもでも変更可能性があります。

使用して、 [ApiInformation.IsMethodPresent](https://docs.microsoft.com/uwp/api/windows.foundation.metadata.apiinformation.ismethodpresent#Windows_Foundation_Metadata_ApiInformation_IsMethodPresent_System_String_System_String_) Api が存在するかどうかを判断するメソッド。 クリックして、 **[LimitedAccessFeatures](https://docs.microsoft.com/uwp/api/windows.applicationmodel.limitedaccessfeatures)** API を API のロックを解除してください。

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

UWP アプリはさまざまなデバイスで実行できます。それらのすべてがタスク バーをサポートするとは限りません。 現時点では、デスクトップ デバイスのみがタスク バーをサポートしています。 さらに、タスク バーのプレゼンスは、付属し、移動します。 タスク バーが現在存在するかどうかを確認するには、呼び出し、 **[TaskbarManager.GetDefault](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager.getdefault)** メソッドとインスタンスが返されることを確認が null でないです。 タスク バーが存在しない場合は、ピン留めする ボタンを表示しません。

など、ピン留めすると、次回の別の操作を行う必要がある新しいインスタンスを取得し、1 つの操作の実行中のインスタンス上に保持することをお勧めします。

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


## <a name="3-check-whether-your-tile-is-currently-pinned-to-the-taskbar"></a>3.タイルがタスク バーに現在固定されているかどうかを確認します。

タイルが既に固定されている場合は、代わりをピン解除 ボタンを表示する必要があります。 使用することができます、 **[IsSecondaryTilePinnedAsync](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager.issecondarytilepinnedasync)** タイルが現在固定されているかどうかを確認する方法 (ユーザーはピン留めを外すこと、いつでも)。 この方法で渡す、 **TileId**を知りたいタイルのピン留めします。

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


## <a name="4-check-whether-pinning-is-allowed"></a>4。ピン留めが許可されているかどうか確認します。

タスク バーにピン留めは、グループ ポリシーによって無効にできます。 [TaskbarManager.IsPinningAllowed](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager.ispinningallowed)プロパティでは、ピン留めが許可されているかどうか確認することができます。

このプロパティを確認する必要があります、ユーザーは、暗証番号 (pin) ボタンをクリックすると、およびが false の場合は、ピン留めは、このコンピューターでは許可されていないユーザーに通知メッセージ ダイアログ ボックスを表示する必要があります。

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


## <a name="5-construct-and-pin-your-tile"></a>5。構築し、タイルをピン留め

ユーザーが、ピン留めする ボタンをクリックして、Api が存在する、タスク バーが存在する場合は、およびピン留めが許可されていることを確認しています.ピン留めする時間します。

最初に、スタートにピン留めしたときと同様に、セカンダリ タイルを構築します。 読み取ることによってセカンダリ タイルのプロパティについて説明できる[開始するセカンダリ タイルをピン留め](secondary-tiles-pinning.md)します。 ただし、以前の必須プロパティだけでなく、タスク バーにピン留めするときに (これは、タスク バーで使用されるロゴ) Square44x44Logo も必要です。 それ以外の場合、例外がスローされます。

次に、タイルを渡す、 **[RequestPinSecondaryTileAsync](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager.requestpinsecondarytileasync)** メソッド。 これは、制限付きアクセスであるためこの確認のダイアログ ボックスは表示されませんし、UI スレッドは必要ありません。 今後これが開かれたときを超えて、アクセスが制限された呼び出し元の制限付きアクセスを利用していないが、ダイアログを受信し、UI スレッドを使用する必要があります。

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

このメソッドは、タスク バーに、タイルがピン留めされたようになりましたかどうかを示すブール値を返します。 タイルが既にピン留めされた場合、このメソッドは既存のタイルを更新し、true を返します。 ピン留めが許可されていない、またはタスク バーはサポートされていません、このメソッドは false を返します。


## <a name="enumerate-tiles"></a>タイルを列挙します。

すべてのタイルを作成してはまだピン留めどこか (開始、タスク バーで、またはその両方) を参照してくださいを使用して、  **[FindAllAsync](https://docs.microsoft.com/uwp/api/windows.ui.startscreen.secondarytile.findallasync)** します。 その後、これらのタイルがスタートやタスク バーにピン留めされているかどうかを確認できます。 サーフェスがサポートされていない場合は、これらのメソッドは false を返します。

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

使用することができます、既にピン留めされたタイルを更新する、 [ **SecondaryTile.UpdateAsync** ](https://docs.microsoft.com/uwp/api/windows.ui.startscreen.secondarytile.updateasync)メソッド」の説明に従って[セカンダリ タイルの更新](secondary-tiles-pinning.md#updating-a-secondary-tile)します。


## <a name="unpin-a-tile"></a>タイルをピン留めを外す

アプリは、タイルが現在固定されている場合、[ピン解除] ボタンを提供します。 タイルをピン解除だけ呼び出す **[TryUnpinSecondaryTileAsync](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager.tryunpinsecondarytileasync)** で渡し、 **TileId** unpinned するセカンダリ タイルの。

このメソッドは、タイルが不要になったタスク バーにピン留めされたかどうかを示すブール値を返します。 タイルは、最初に固定されている場合も、true を返します。 外す許可されていない場合これは false を返します。

場合は、タイルは、タスク バーにピン留めのみが、これが任意の場所に固定されて不要になったため、タイルが削除されます。

```csharp
var taskbarManager = TaskbarManager.GetDefault();
if (taskbarManager != null)
{
    bool isUnpinned = await taskbarManager.TryUnpinSecondaryTileAsync("myTileId");
}
```


## <a name="delete-a-tile"></a>タイルを削除します。

Everywhere (開始、タスク バー) からタイルの固定を解除する場合は、使用、 **[RequestDeleteAsync](https://docs.microsoft.com/uwp/api/windows.ui.startscreen.secondarytile.requestdeleteasync)** メソッド。

これは、コンテンツをピン留めされたユーザーは適用できなくする場合に適してします。 たとえば、アプリでは、開始、タスク バーで、ノートブックをピン留めすることができ、ユーザーが、notebook を削除し場合、は、ノートブックに関連付けられたタイルを簡単に削除する必要があります。

```csharp
// Initialize a secondary tile with the same tile ID you want removed.
// Or, locate it with FindAllAsync()
SecondaryTile toBeDeleted = new SecondaryTile(tileId);

// And then delete the tile
await toBeDeleted.RequestDeleteAsync();
```


## <a name="unpin-only-from-start"></a>開始のみからピン留めを外す

タスク バーのまま開始からのセカンダリ タイルの固定を解除する場合を呼び出すことができます、 **[StartScreenManager.TryRemoveSecondaryTileAsync](https://docs.microsoft.com/uwp/api/windows.ui.startscreen.startscreenmanager.tryremovesecondarytileasync)** メソッド。 不要になった他のサーフェスに固定されている場合、タイル同様に削除されます。

このメソッドは、タイルがスタートにピン留め不要になったかどうかを示すブール値を返します。 タイルは、最初に固定されている場合も、true を返します。 外すが許可されていないか、開始はサポートされていません、この false を返します。

```csharp
await StartScreenManager.GetDefault().TryRemoveSecondaryTileAsync("myTileId");
```


## <a name="resources"></a>参考資料

* [TaskbarManager クラス](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager)
* [開始するセカンダリ タイルをピン留め](secondary-tiles-pinning.md)