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
# <a name="pin-secondary-tiles-to-taskbar"></a><span data-ttu-id="14b23-104">タスク バーに、セカンダリ タイルをピン留め</span><span class="sxs-lookup"><span data-stu-id="14b23-104">Pin secondary tiles to taskbar</span></span>

<span data-ttu-id="14b23-105">開始するセカンダリ タイルをピン留めと同じようには、アプリ内でコンテンツをユーザー クイック アクセスを付与セカンダリ タイル、タスク バーに固定できます。</span><span class="sxs-lookup"><span data-stu-id="14b23-105">Just like pinning secondary tiles to Start, you can pin secondary tiles to the taskbar, giving your users quick access to content within your app.</span></span>

<img alt="Taskbar pinning" src="../images/taskbar/pin-secondary-ui.png" width="972"/>

> [!IMPORTANT]
> <span data-ttu-id="14b23-106">**API のアクセス制限**:この API は、制限付きアクセス機能です。</span><span class="sxs-lookup"><span data-stu-id="14b23-106">**Limited Access API**: This API is a limited access feature.</span></span> <span data-ttu-id="14b23-107">この API を使用する連絡[ taskbarsecondarytile@microsoft.com](mailto:taskbarsecondarytile@microsoft.com?Subject=Limited%20Access%20permission%20to%20use%20secondary%20tiles%20on%20taskbar)します。</span><span class="sxs-lookup"><span data-stu-id="14b23-107">To use this API, please contact [taskbarsecondarytile@microsoft.com](mailto:taskbarsecondarytile@microsoft.com?Subject=Limited%20Access%20permission%20to%20use%20secondary%20tiles%20on%20taskbar).</span></span>

> <span data-ttu-id="14b23-108">**2018 の年 10 月の更新プログラムが必要**:17763 SDK をターゲットする必要があり、ビルド 17763 以降を実行してあるタスクバーにピン留めします。</span><span class="sxs-lookup"><span data-stu-id="14b23-108">**Requires October 2018 Update**: You must target SDK 17763 and be running build 17763 or higher to pin to taskbar.</span></span>


## <a name="guidance"></a><span data-ttu-id="14b23-109">ガイダンス</span><span class="sxs-lookup"><span data-stu-id="14b23-109">Guidance</span></span>

<span data-ttu-id="14b23-110">セカンダリ タイルは、アプリ内の特定の領域に直接アクセスするユーザーの一貫性があり、効率的な方法を提供します。</span><span class="sxs-lookup"><span data-stu-id="14b23-110">A secondary tile provides a consistent, efficient way for users to directly access specific areas within an app.</span></span> <span data-ttu-id="14b23-111">ユーザーがタスク バーにセカンダリ タイルを「ピン留め」するかどうかを選択、ですが、アプリ内で固定できる領域は、開発者によって決まります。</span><span class="sxs-lookup"><span data-stu-id="14b23-111">Although a user chooses whether or not to "pin" a secondary tile to the taskbar, the pinnable areas in an app are determined by the developer.</span></span> <span data-ttu-id="14b23-112">詳細なガイダンスについては、[セカンダリ タイル ガイダンス](secondary-tiles-guidance.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="14b23-112">For more guidance, see [Secondary tile guidance](secondary-tiles-guidance.md).</span></span>


## <a name="1-determine-if-api-exists-and-unlock-limited-access"></a><span data-ttu-id="14b23-113">1. API が存在するかどうかを判断し、制限付きアクセスのロックを解除</span><span class="sxs-lookup"><span data-stu-id="14b23-113">1. Determine if API exists and unlock Limited-Access</span></span>

<span data-ttu-id="14b23-114">古いデバイスは、(以前のバージョンの Windows 10 を対象としている) 場合は、Api をピン留め、タスク バーに必要はありません。</span><span class="sxs-lookup"><span data-stu-id="14b23-114">Older devices don't have the taskbar pinning APIs (if you're targeting older versions of Windows 10).</span></span> <span data-ttu-id="14b23-115">そのため、これらのピン留め対応ではないデバイスに暗証番号 (pin) ボタンを表示しないでください。</span><span class="sxs-lookup"><span data-stu-id="14b23-115">Therefore, you shouldn't display a pin button on these devices that aren't capable of pinning.</span></span>

<span data-ttu-id="14b23-116">さらに、この機能は、制限付きアクセスでロックされています。</span><span class="sxs-lookup"><span data-stu-id="14b23-116">Additionally, this feature is locked under Limited-Access.</span></span> <span data-ttu-id="14b23-117">アクセスを取得するには、Microsoft にお問い合わせください。</span><span class="sxs-lookup"><span data-stu-id="14b23-117">To gain access, contact Microsoft.</span></span> <span data-ttu-id="14b23-118">API の呼び出しに **[TaskbarManager.RequestPinSecondaryTileAsync](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager.requestpinsecondarytileasync#Windows_UI_Shell_TaskbarManager_RequestPinSecondaryTileAsync_Windows_UI_StartScreen_SecondaryTile_)**、  **[TaskbarManager.IsSecondaryTilePinnedAsync](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager.issecondarytilepinnedasync)**、および**[TaskbarManager.TryUnpinSecondaryTileAsync](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager.tryunpinsecondarytileasync)** はアクセス拒否例外で失敗します。</span><span class="sxs-lookup"><span data-stu-id="14b23-118">API calls to **[TaskbarManager.RequestPinSecondaryTileAsync](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager.requestpinsecondarytileasync#Windows_UI_Shell_TaskbarManager_RequestPinSecondaryTileAsync_Windows_UI_StartScreen_SecondaryTile_)**, **[TaskbarManager.IsSecondaryTilePinnedAsync](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager.issecondarytilepinnedasync)**, and **[TaskbarManager.TryUnpinSecondaryTileAsync](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager.tryunpinsecondarytileasync)** will fail with an Access Denied exception.</span></span> <span data-ttu-id="14b23-119">アプリが、アクセス許可なしには、この API を使用して許可されていませんし、API の定義は、いつでもでも変更可能性があります。</span><span class="sxs-lookup"><span data-stu-id="14b23-119">Apps are not allowed to use this API without permission, and the API definition may change at any time.</span></span>

<span data-ttu-id="14b23-120">使用して、 [ApiInformation.IsMethodPresent](https://docs.microsoft.com/uwp/api/windows.foundation.metadata.apiinformation.ismethodpresent#Windows_Foundation_Metadata_ApiInformation_IsMethodPresent_System_String_System_String_) Api が存在するかどうかを判断するメソッド。</span><span class="sxs-lookup"><span data-stu-id="14b23-120">Use the [ApiInformation.IsMethodPresent](https://docs.microsoft.com/uwp/api/windows.foundation.metadata.apiinformation.ismethodpresent#Windows_Foundation_Metadata_ApiInformation_IsMethodPresent_System_String_System_String_) method to determine if the APIs are present.</span></span> <span data-ttu-id="14b23-121">クリックして、 **[LimitedAccessFeatures](https://docs.microsoft.com/uwp/api/windows.applicationmodel.limitedaccessfeatures)** API を API のロックを解除してください。</span><span class="sxs-lookup"><span data-stu-id="14b23-121">And then use the **[LimitedAccessFeatures](https://docs.microsoft.com/uwp/api/windows.applicationmodel.limitedaccessfeatures)** API to try unlocking the API.</span></span>

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


## <a name="2-get-the-taskbarmanager-instance"></a><span data-ttu-id="14b23-122">2. TaskbarManager インスタンスを取得します。</span><span class="sxs-lookup"><span data-stu-id="14b23-122">2. Get the TaskbarManager instance</span></span>

<span data-ttu-id="14b23-123">UWP アプリはさまざまなデバイスで実行できます。それらのすべてがタスク バーをサポートするとは限りません。</span><span class="sxs-lookup"><span data-stu-id="14b23-123">UWP apps can run on a wide variety of devices; not all of them support the taskbar.</span></span> <span data-ttu-id="14b23-124">現時点では、デスクトップ デバイスのみがタスク バーをサポートしています。</span><span class="sxs-lookup"><span data-stu-id="14b23-124">Right now, only Desktop devices support the taskbar.</span></span> <span data-ttu-id="14b23-125">さらに、タスク バーのプレゼンスは、付属し、移動します。</span><span class="sxs-lookup"><span data-stu-id="14b23-125">Additionally, presence of the taskbar might come and go.</span></span> <span data-ttu-id="14b23-126">タスク バーが現在存在するかどうかを確認するには、呼び出し、 **[TaskbarManager.GetDefault](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager.getdefault)** メソッドとインスタンスが返されることを確認が null でないです。</span><span class="sxs-lookup"><span data-stu-id="14b23-126">To check whether taskbar is currently present, call the **[TaskbarManager.GetDefault](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager.getdefault)** method and check that the instance returned is not null.</span></span> <span data-ttu-id="14b23-127">タスク バーが存在しない場合は、ピン留めする ボタンを表示しません。</span><span class="sxs-lookup"><span data-stu-id="14b23-127">Don't display a pin button if the taskbar isn't present.</span></span>

<span data-ttu-id="14b23-128">など、ピン留めすると、次回の別の操作を行う必要がある新しいインスタンスを取得し、1 つの操作の実行中のインスタンス上に保持することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="14b23-128">We recommend holding onto the instance for the duration of a single operation, like pinning, and then grabbing a new instance the next time you need to do another operation.</span></span>

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


## <a name="3-check-whether-your-tile-is-currently-pinned-to-the-taskbar"></a><span data-ttu-id="14b23-129">3.タイルがタスク バーに現在固定されているかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="14b23-129">3. Check whether your tile is currently pinned to the taskbar</span></span>

<span data-ttu-id="14b23-130">タイルが既に固定されている場合は、代わりをピン解除 ボタンを表示する必要があります。</span><span class="sxs-lookup"><span data-stu-id="14b23-130">If your tile is already pinned, you should display an unpin button instead.</span></span> <span data-ttu-id="14b23-131">使用することができます、 **[IsSecondaryTilePinnedAsync](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager.issecondarytilepinnedasync)** タイルが現在固定されているかどうかを確認する方法 (ユーザーはピン留めを外すこと、いつでも)。</span><span class="sxs-lookup"><span data-stu-id="14b23-131">You can use the **[IsSecondaryTilePinnedAsync](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager.issecondarytilepinnedasync)** method to check whether your tile is currently pinned (users can unpin it at any time).</span></span> <span data-ttu-id="14b23-132">この方法で渡す、 **TileId**を知りたいタイルのピン留めします。</span><span class="sxs-lookup"><span data-stu-id="14b23-132">In this method, you pass the **TileId** of the tile you want to know is pinned.</span></span>

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


## <a name="4-check-whether-pinning-is-allowed"></a><span data-ttu-id="14b23-133">4。ピン留めが許可されているかどうか確認します。</span><span class="sxs-lookup"><span data-stu-id="14b23-133">4. Check whether pinning is allowed</span></span>

<span data-ttu-id="14b23-134">タスク バーにピン留めは、グループ ポリシーによって無効にできます。</span><span class="sxs-lookup"><span data-stu-id="14b23-134">Pinning to the taskbar can be disabled by Group Policy.</span></span> <span data-ttu-id="14b23-135">[TaskbarManager.IsPinningAllowed](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager.ispinningallowed)プロパティでは、ピン留めが許可されているかどうか確認することができます。</span><span class="sxs-lookup"><span data-stu-id="14b23-135">The [TaskbarManager.IsPinningAllowed](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager.ispinningallowed) property lets you check whether pinning is allowed.</span></span>

<span data-ttu-id="14b23-136">このプロパティを確認する必要があります、ユーザーは、暗証番号 (pin) ボタンをクリックすると、およびが false の場合は、ピン留めは、このコンピューターでは許可されていないユーザーに通知メッセージ ダイアログ ボックスを表示する必要があります。</span><span class="sxs-lookup"><span data-stu-id="14b23-136">When the user clicks your pin button, you should check this property, and if it's false, you should display a message dialog informing the user that pinning is not allowed on this machine.</span></span>

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


## <a name="5-construct-and-pin-your-tile"></a><span data-ttu-id="14b23-137">5。構築し、タイルをピン留め</span><span class="sxs-lookup"><span data-stu-id="14b23-137">5. Construct and pin your tile</span></span>

<span data-ttu-id="14b23-138">ユーザーが、ピン留めする ボタンをクリックして、Api が存在する、タスク バーが存在する場合は、およびピン留めが許可されていることを確認しています.ピン留めする時間します。</span><span class="sxs-lookup"><span data-stu-id="14b23-138">The user has clicked your pin button, and you've determined that the APIs are present, taskbar is present, and pinning is allowed... time to pin!</span></span>

<span data-ttu-id="14b23-139">最初に、スタートにピン留めしたときと同様に、セカンダリ タイルを構築します。</span><span class="sxs-lookup"><span data-stu-id="14b23-139">First, construct your secondary tile just like you would when pinning to Start.</span></span> <span data-ttu-id="14b23-140">読み取ることによってセカンダリ タイルのプロパティについて説明できる[開始するセカンダリ タイルをピン留め](secondary-tiles-pinning.md)します。</span><span class="sxs-lookup"><span data-stu-id="14b23-140">You can learn more about the secondary tile properties by reading [Pin secondary tiles to Start](secondary-tiles-pinning.md).</span></span> <span data-ttu-id="14b23-141">ただし、以前の必須プロパティだけでなく、タスク バーにピン留めするときに (これは、タスク バーで使用されるロゴ) Square44x44Logo も必要です。</span><span class="sxs-lookup"><span data-stu-id="14b23-141">However, when pinning to taskbar, in addition to the previously required properties, Square44x44Logo (this is the logo used by taskbar) is also required.</span></span> <span data-ttu-id="14b23-142">それ以外の場合、例外がスローされます。</span><span class="sxs-lookup"><span data-stu-id="14b23-142">Otherwise, an exception will be thrown.</span></span>

<span data-ttu-id="14b23-143">次に、タイルを渡す、 **[RequestPinSecondaryTileAsync](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager.requestpinsecondarytileasync)** メソッド。</span><span class="sxs-lookup"><span data-stu-id="14b23-143">Then, pass the tile to the **[RequestPinSecondaryTileAsync](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager.requestpinsecondarytileasync)** method.</span></span> <span data-ttu-id="14b23-144">これは、制限付きアクセスであるためこの確認のダイアログ ボックスは表示されませんし、UI スレッドは必要ありません。</span><span class="sxs-lookup"><span data-stu-id="14b23-144">Since this is under limited-access, this will not display a confirmation dialog and does not require a UI thread.</span></span> <span data-ttu-id="14b23-145">今後これが開かれたときを超えて、アクセスが制限された呼び出し元の制限付きアクセスを利用していないが、ダイアログを受信し、UI スレッドを使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="14b23-145">But in the future when this is opened up beyond limited-access, callers not utilizing limited-access will receive a dialog and be required to use the UI thread.</span></span>

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

<span data-ttu-id="14b23-146">このメソッドは、タスク バーに、タイルがピン留めされたようになりましたかどうかを示すブール値を返します。</span><span class="sxs-lookup"><span data-stu-id="14b23-146">This method returns a boolean value that indicates whether your tile is now pinned to the taskbar.</span></span> <span data-ttu-id="14b23-147">タイルが既にピン留めされた場合、このメソッドは既存のタイルを更新し、true を返します。</span><span class="sxs-lookup"><span data-stu-id="14b23-147">If your tile was already pinned, the method updates the existing tile and returns true.</span></span> <span data-ttu-id="14b23-148">ピン留めが許可されていない、またはタスク バーはサポートされていません、このメソッドは false を返します。</span><span class="sxs-lookup"><span data-stu-id="14b23-148">If pinning wasn't allowed or taskbar isn't supported, the method returns false.</span></span>


## <a name="enumerate-tiles"></a><span data-ttu-id="14b23-149">タイルを列挙します。</span><span class="sxs-lookup"><span data-stu-id="14b23-149">Enumerate tiles</span></span>

<span data-ttu-id="14b23-150">すべてのタイルを作成してはまだピン留めどこか (開始、タスク バーで、またはその両方) を参照してくださいを使用して、  **[FindAllAsync](https://docs.microsoft.com/uwp/api/windows.ui.startscreen.secondarytile.findallasync)** します。</span><span class="sxs-lookup"><span data-stu-id="14b23-150">To see all the tiles that you created and are still pinned somewhere (Start, taskbar, or both), use **[FindAllAsync](https://docs.microsoft.com/uwp/api/windows.ui.startscreen.secondarytile.findallasync)**.</span></span> <span data-ttu-id="14b23-151">その後、これらのタイルがスタートやタスク バーにピン留めされているかどうかを確認できます。</span><span class="sxs-lookup"><span data-stu-id="14b23-151">You can subsequently check whether these tiles are pinned to the taskbar and/or Start.</span></span> <span data-ttu-id="14b23-152">サーフェスがサポートされていない場合は、これらのメソッドは false を返します。</span><span class="sxs-lookup"><span data-stu-id="14b23-152">If the surface isn't supported, these methods return false.</span></span>

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


## <a name="update-a-tile"></a><span data-ttu-id="14b23-153">タイルを更新します。</span><span class="sxs-lookup"><span data-stu-id="14b23-153">Update a tile</span></span>

<span data-ttu-id="14b23-154">使用することができます、既にピン留めされたタイルを更新する、 [ **SecondaryTile.UpdateAsync** ](https://docs.microsoft.com/uwp/api/windows.ui.startscreen.secondarytile.updateasync)メソッド」の説明に従って[セカンダリ タイルの更新](secondary-tiles-pinning.md#updating-a-secondary-tile)します。</span><span class="sxs-lookup"><span data-stu-id="14b23-154">To update an already pinned tile, you can use the [**SecondaryTile.UpdateAsync**](https://docs.microsoft.com/uwp/api/windows.ui.startscreen.secondarytile.updateasync) method as described in [Updating a secondary tile](secondary-tiles-pinning.md#updating-a-secondary-tile).</span></span>


## <a name="unpin-a-tile"></a><span data-ttu-id="14b23-155">タイルをピン留めを外す</span><span class="sxs-lookup"><span data-stu-id="14b23-155">Unpin a tile</span></span>

<span data-ttu-id="14b23-156">アプリは、タイルが現在固定されている場合、[ピン解除] ボタンを提供します。</span><span class="sxs-lookup"><span data-stu-id="14b23-156">Your app should provide an unpin button if the tile is currently pinned.</span></span> <span data-ttu-id="14b23-157">タイルをピン解除だけ呼び出す **[TryUnpinSecondaryTileAsync](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager.tryunpinsecondarytileasync)** で渡し、 **TileId** unpinned するセカンダリ タイルの。</span><span class="sxs-lookup"><span data-stu-id="14b23-157">To unpin the tile, simply call **[TryUnpinSecondaryTileAsync](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager.tryunpinsecondarytileasync)**, passing in the **TileId** of the secondary tile you would like unpinned.</span></span>

<span data-ttu-id="14b23-158">このメソッドは、タイルが不要になったタスク バーにピン留めされたかどうかを示すブール値を返します。</span><span class="sxs-lookup"><span data-stu-id="14b23-158">This method returns a boolean value that indicates whether your tile is no longer pinned to the taskbar.</span></span> <span data-ttu-id="14b23-159">タイルは、最初に固定されている場合も、true を返します。</span><span class="sxs-lookup"><span data-stu-id="14b23-159">If your tile wasn't pinned in the first place, this also returns true.</span></span> <span data-ttu-id="14b23-160">外す許可されていない場合これは false を返します。</span><span class="sxs-lookup"><span data-stu-id="14b23-160">If unpinning wasn't allowed, this returns false.</span></span>

<span data-ttu-id="14b23-161">場合は、タイルは、タスク バーにピン留めのみが、これが任意の場所に固定されて不要になったため、タイルが削除されます。</span><span class="sxs-lookup"><span data-stu-id="14b23-161">If your tile was only pinned to taskbar, this will delete the tile since it is no longer pinned anywhere.</span></span>

```csharp
var taskbarManager = TaskbarManager.GetDefault();
if (taskbarManager != null)
{
    bool isUnpinned = await taskbarManager.TryUnpinSecondaryTileAsync("myTileId");
}
```


## <a name="delete-a-tile"></a><span data-ttu-id="14b23-162">タイルを削除します。</span><span class="sxs-lookup"><span data-stu-id="14b23-162">Delete a tile</span></span>

<span data-ttu-id="14b23-163">Everywhere (開始、タスク バー) からタイルの固定を解除する場合は、使用、 **[RequestDeleteAsync](https://docs.microsoft.com/uwp/api/windows.ui.startscreen.secondarytile.requestdeleteasync)** メソッド。</span><span class="sxs-lookup"><span data-stu-id="14b23-163">If you want to unpin a tile from everywhere (Start, taskbar), use the **[RequestDeleteAsync](https://docs.microsoft.com/uwp/api/windows.ui.startscreen.secondarytile.requestdeleteasync)** method.</span></span>

<span data-ttu-id="14b23-164">これは、コンテンツをピン留めされたユーザーは適用できなくする場合に適してします。</span><span class="sxs-lookup"><span data-stu-id="14b23-164">This is appropriate for cases where the content the user pinned is no longer applicable.</span></span> <span data-ttu-id="14b23-165">たとえば、アプリでは、開始、タスク バーで、ノートブックをピン留めすることができ、ユーザーが、notebook を削除し場合、は、ノートブックに関連付けられたタイルを簡単に削除する必要があります。</span><span class="sxs-lookup"><span data-stu-id="14b23-165">For example, if your app lets you pin a notebook to Start and taskbar, and then the user deletes the notebook, you should simply delete the tile associated with the notebook.</span></span>

```csharp
// Initialize a secondary tile with the same tile ID you want removed.
// Or, locate it with FindAllAsync()
SecondaryTile toBeDeleted = new SecondaryTile(tileId);

// And then delete the tile
await toBeDeleted.RequestDeleteAsync();
```


## <a name="unpin-only-from-start"></a><span data-ttu-id="14b23-166">開始のみからピン留めを外す</span><span class="sxs-lookup"><span data-stu-id="14b23-166">Unpin only from Start</span></span>

<span data-ttu-id="14b23-167">タスク バーのまま開始からのセカンダリ タイルの固定を解除する場合を呼び出すことができます、 **[StartScreenManager.TryRemoveSecondaryTileAsync](https://docs.microsoft.com/uwp/api/windows.ui.startscreen.startscreenmanager.tryremovesecondarytileasync)** メソッド。</span><span class="sxs-lookup"><span data-stu-id="14b23-167">If you only want to unpin a secondary tile from Start while leaving it on Taskbar, you can call the **[StartScreenManager.TryRemoveSecondaryTileAsync](https://docs.microsoft.com/uwp/api/windows.ui.startscreen.startscreenmanager.tryremovesecondarytileasync)** method.</span></span> <span data-ttu-id="14b23-168">不要になった他のサーフェスに固定されている場合、タイル同様に削除されます。</span><span class="sxs-lookup"><span data-stu-id="14b23-168">This will similarly delete the tile if it is no longer pinned to any other surfaces.</span></span>

<span data-ttu-id="14b23-169">このメソッドは、タイルがスタートにピン留め不要になったかどうかを示すブール値を返します。</span><span class="sxs-lookup"><span data-stu-id="14b23-169">This method returns a boolean value that indicates whether your tile is no longer pinned to Start.</span></span> <span data-ttu-id="14b23-170">タイルは、最初に固定されている場合も、true を返します。</span><span class="sxs-lookup"><span data-stu-id="14b23-170">If your tile wasn't pinned in the first place, this also returns true.</span></span> <span data-ttu-id="14b23-171">外すが許可されていないか、開始はサポートされていません、この false を返します。</span><span class="sxs-lookup"><span data-stu-id="14b23-171">If unpinning wasn't allowed or Start isn't supported, this returns false.</span></span>

```csharp
await StartScreenManager.GetDefault().TryRemoveSecondaryTileAsync("myTileId");
```


## <a name="resources"></a><span data-ttu-id="14b23-172">参考資料</span><span class="sxs-lookup"><span data-stu-id="14b23-172">Resources</span></span>

* [<span data-ttu-id="14b23-173">TaskbarManager クラス</span><span class="sxs-lookup"><span data-stu-id="14b23-173">TaskbarManager class</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager)
* [<span data-ttu-id="14b23-174">開始するセカンダリ タイルをピン留め</span><span class="sxs-lookup"><span data-stu-id="14b23-174">Pin secondary tiles to Start</span></span>](secondary-tiles-pinning.md)