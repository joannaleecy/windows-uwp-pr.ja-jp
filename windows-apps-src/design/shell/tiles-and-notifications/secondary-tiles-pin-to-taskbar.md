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
ms.sourcegitcommit: 8921a9cc0dd3e5665345ae8eca7ab7aeb83ccc6f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8886726"
---
# <a name="pin-secondary-tiles-to-taskbar"></a><span data-ttu-id="8171f-103">タスク バーにセカンダリ タイルをピン留め</span><span class="sxs-lookup"><span data-stu-id="8171f-103">Pin secondary tiles to taskbar</span></span>

<span data-ttu-id="8171f-104">スタート画面にセカンダリ タイルをピン留めと同様には、クイック アクセス許可を与えるコンテンツに、アプリ内でセカンダリ タイル、タスク バーに固定できます。</span><span class="sxs-lookup"><span data-stu-id="8171f-104">Just like pinning secondary tiles to Start, you can pin secondary tiles to the taskbar, giving your users quick access to content within your app.</span></span>

<img alt="Taskbar pinning" src="../images/taskbar/pin-secondary-ui.png" width="972"/>

> [!IMPORTANT]
> <span data-ttu-id="8171f-105">**制限付きのアクセス API**: この API は、制限されたアクセス機能です。</span><span class="sxs-lookup"><span data-stu-id="8171f-105">**Limited Access API**: This API is a limited access feature.</span></span> <span data-ttu-id="8171f-106">この API を使用するお問い合わせください[taskbarsecondarytile@microsoft.com](mailto:taskbarsecondarytile@microsoft.com?Subject=Limited%20Access%20permission%20to%20use%20secondary%20tiles%20on%20taskbar)します。</span><span class="sxs-lookup"><span data-stu-id="8171f-106">To use this API, please contact [taskbarsecondarytile@microsoft.com](mailto:taskbarsecondarytile@microsoft.com?Subject=Limited%20Access%20permission%20to%20use%20secondary%20tiles%20on%20taskbar).</span></span>

> <span data-ttu-id="8171f-107">**年 2018年 10 月を必要と更新**: が実行されているビルド 17763 以上をタスク バーにピン留めして 17763 SDK をターゲットにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="8171f-107">**Requires October 2018 Update**: You must target SDK 17763 and be running build 17763 or higher to pin to taskbar.</span></span>


## <a name="guidance"></a><span data-ttu-id="8171f-108">ガイダンス</span><span class="sxs-lookup"><span data-stu-id="8171f-108">Guidance</span></span>

<span data-ttu-id="8171f-109">セカンダリ タイルは、アプリ内の特定の領域に直接アクセスするユーザーの一貫性があり、効率的な方法を提供します。</span><span class="sxs-lookup"><span data-stu-id="8171f-109">A secondary tile provides a consistent, efficient way for users to directly access specific areas within an app.</span></span> <span data-ttu-id="8171f-110">ただし、ユーザーがタスク バーにセカンダリ タイルを「ピン留め」するかどうかと、アプリのピン留めできる場合の領域は開発者によって決まります。</span><span class="sxs-lookup"><span data-stu-id="8171f-110">Although a user chooses whether or not to "pin" a secondary tile to the taskbar, the pinnable areas in an app are determined by the developer.</span></span> <span data-ttu-id="8171f-111">詳細なガイダンスについては、[セカンダリ タイルのガイダンス](secondary-tiles-guidance.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="8171f-111">For more guidance, see [Secondary tile guidance](secondary-tiles-guidance.md).</span></span>


## <a name="1-determine-if-api-exists-and-unlock-limited-access"></a><span data-ttu-id="8171f-112">1. API の存在を確認し、制限付きアクセスをロック解除</span><span class="sxs-lookup"><span data-stu-id="8171f-112">1. Determine if API exists and unlock Limited-Access</span></span>

<span data-ttu-id="8171f-113">古いデバイス (Windows 10 の以前のバージョンをターゲットとしている) 場合は、Api をピン留めタスク バーはありません。</span><span class="sxs-lookup"><span data-stu-id="8171f-113">Older devices don't have the taskbar pinning APIs (if you're targeting older versions of Windows 10).</span></span> <span data-ttu-id="8171f-114">したがって、ピン留めできるはこれらのデバイスで、暗証番号 (pin) ボタンを表示しないでください。</span><span class="sxs-lookup"><span data-stu-id="8171f-114">Therefore, you shouldn't display a pin button on these devices that aren't capable of pinning.</span></span>

<span data-ttu-id="8171f-115">さらに、この機能は、アクセスが制限された [ロックされています。</span><span class="sxs-lookup"><span data-stu-id="8171f-115">Additionally, this feature is locked under Limited-Access.</span></span> <span data-ttu-id="8171f-116">アクセスを取得するには、Microsoft にお問い合わせください。</span><span class="sxs-lookup"><span data-stu-id="8171f-116">To gain access, contact Microsoft.</span></span> <span data-ttu-id="8171f-117">**[TaskbarManager.RequestPinSecondaryTileAsync](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager.requestpinsecondarytileasync#Windows_UI_Shell_TaskbarManager_RequestPinSecondaryTileAsync_Windows_UI_StartScreen_SecondaryTile_)**、 **[TaskbarManager.IsSecondaryTilePinnedAsync](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager.issecondarytilepinnedasync)**、および**[TaskbarManager.TryUnpinSecondaryTileAsync](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager.tryunpinsecondarytileasync)** API 呼び出しは、アクセス拒否例外で失敗します。</span><span class="sxs-lookup"><span data-stu-id="8171f-117">API calls to **[TaskbarManager.RequestPinSecondaryTileAsync](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager.requestpinsecondarytileasync#Windows_UI_Shell_TaskbarManager_RequestPinSecondaryTileAsync_Windows_UI_StartScreen_SecondaryTile_)**, **[TaskbarManager.IsSecondaryTilePinnedAsync](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager.issecondarytilepinnedasync)**, and **[TaskbarManager.TryUnpinSecondaryTileAsync](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager.tryunpinsecondarytileasync)** will fail with an Access Denied exception.</span></span> <span data-ttu-id="8171f-118">アプリは、アクセス許可することがなく、この API を使用して許可されず、API の定義は、いつでもでも変更可能性があります。</span><span class="sxs-lookup"><span data-stu-id="8171f-118">Apps are not allowed to use this API without permission, and the API definition may change at any time.</span></span>

<span data-ttu-id="8171f-119">Api が存在するかを判断するには、 [ApiInformation.IsMethodPresent](https://docs.microsoft.com/uwp/api/windows.foundation.metadata.apiinformation.ismethodpresent#Windows_Foundation_Metadata_ApiInformation_IsMethodPresent_System_String_System_String_)メソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="8171f-119">Use the [ApiInformation.IsMethodPresent](https://docs.microsoft.com/uwp/api/windows.foundation.metadata.apiinformation.ismethodpresent#Windows_Foundation_Metadata_ApiInformation_IsMethodPresent_System_String_System_String_) method to determine if the APIs are present.</span></span> <span data-ttu-id="8171f-120">**[LimitedAccessFeatures](https://docs.microsoft.com/uwp/api/windows.applicationmodel.limitedaccessfeatures)** API を使用して、API のロックを解除してみてください。</span><span class="sxs-lookup"><span data-stu-id="8171f-120">And then use the **[LimitedAccessFeatures](https://docs.microsoft.com/uwp/api/windows.applicationmodel.limitedaccessfeatures)** API to try unlocking the API.</span></span>

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


## <a name="2-get-the-taskbarmanager-instance"></a><span data-ttu-id="8171f-121">2. TaskbarManager インスタンスを取得します。</span><span class="sxs-lookup"><span data-stu-id="8171f-121">2. Get the TaskbarManager instance</span></span>

<span data-ttu-id="8171f-122">UWP アプリはさまざまなデバイスで実行できます。それらのすべてがタスク バーをサポートするとは限りません。</span><span class="sxs-lookup"><span data-stu-id="8171f-122">UWP apps can run on a wide variety of devices; not all of them support the taskbar.</span></span> <span data-ttu-id="8171f-123">現時点では、デスクトップ デバイスのみがタスク バーをサポートしています。</span><span class="sxs-lookup"><span data-stu-id="8171f-123">Right now, only Desktop devices support the taskbar.</span></span> <span data-ttu-id="8171f-124">さらに、タスク バーのプレゼンスは、付属し、移動します。</span><span class="sxs-lookup"><span data-stu-id="8171f-124">Additionally, presence of the taskbar might come and go.</span></span> <span data-ttu-id="8171f-125">タスク バーが現在存在するかどうかを確認、 **[TaskbarManager.GetDefault](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager.getdefault)** メソッドを呼び出して、返されるインスタンスを確認して、が null でないです。</span><span class="sxs-lookup"><span data-stu-id="8171f-125">To check whether taskbar is currently present, call the **[TaskbarManager.GetDefault](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager.getdefault)** method and check that the instance returned is not null.</span></span> <span data-ttu-id="8171f-126">タスク バーが存在していない場合、暗証番号 (pin) ボタンを表示しないでください。</span><span class="sxs-lookup"><span data-stu-id="8171f-126">Don't display a pin button if the taskbar isn't present.</span></span>

<span data-ttu-id="8171f-127">ピン留めすると、次回の別の操作を実行する必要がある新しいインスタンスを取得しなどの 1 つの操作の期間中のインスタンスを保持することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="8171f-127">We recommend holding onto the instance for the duration of a single operation, like pinning, and then grabbing a new instance the next time you need to do another operation.</span></span>

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


## <a name="3-check-whether-your-tile-is-currently-pinned-to-the-taskbar"></a><span data-ttu-id="8171f-128">3.、タイルが現在タスク バーにピン留めされているかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="8171f-128">3. Check whether your tile is currently pinned to the taskbar</span></span>

<span data-ttu-id="8171f-129">タイルが既にピン留めした場合は、代わりに、ピン留めを外す] ボタンを表示する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8171f-129">If your tile is already pinned, you should display an unpin button instead.</span></span> <span data-ttu-id="8171f-130">**[IsSecondaryTilePinnedAsync](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager.issecondarytilepinnedasync)** メソッドを使用して、タイルが現在ピン留めされているかどうかを確認することができます (ユーザーをピン留めを外すにいつでもでも)。</span><span class="sxs-lookup"><span data-stu-id="8171f-130">You can use the **[IsSecondaryTilePinnedAsync](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager.issecondarytilepinnedasync)** method to check whether your tile is currently pinned (users can unpin it at any time).</span></span> <span data-ttu-id="8171f-131">知りたいタイルの**TileId**を渡すことで、このメソッドは、ピン留めされています。</span><span class="sxs-lookup"><span data-stu-id="8171f-131">In this method, you pass the **TileId** of the tile you want to know is pinned.</span></span>

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


## <a name="4-check-whether-pinning-is-allowed"></a><span data-ttu-id="8171f-132">4. ピン留めが許可されているかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="8171f-132">4. Check whether pinning is allowed</span></span>

<span data-ttu-id="8171f-133">グループ ポリシーによって、タスク バーにピン留めを無効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="8171f-133">Pinning to the taskbar can be disabled by Group Policy.</span></span> <span data-ttu-id="8171f-134">[TaskbarManager.IsPinningAllowed](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager.ispinningallowed)プロパティを使用して、ピン留めが許可されているかどうかを確認できます。</span><span class="sxs-lookup"><span data-stu-id="8171f-134">The [TaskbarManager.IsPinningAllowed](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager.ispinningallowed) property lets you check whether pinning is allowed.</span></span>

<span data-ttu-id="8171f-135">このプロパティをチェックする必要があります、ユーザーが、暗証番号 (pin) ボタンをクリックしが false の場合は、このコンピューターにピン留めが許可されていないユーザーに知らせるメッセージ ダイアログを表示する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8171f-135">When the user clicks your pin button, you should check this property, and if it's false, you should display a message dialog informing the user that pinning is not allowed on this machine.</span></span>

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


## <a name="5-construct-and-pin-your-tile"></a><span data-ttu-id="8171f-136">5. を構築し、タイルをピン留め</span><span class="sxs-lookup"><span data-stu-id="8171f-136">5. Construct and pin your tile</span></span>

<span data-ttu-id="8171f-137">ユーザーが、暗証番号 (pin) ボタンをクリックして、Api が存在すること、タスク バーが存在して、ピン留めを許可する] を決定した暗証番号 (pin) までの時間です。</span><span class="sxs-lookup"><span data-stu-id="8171f-137">The user has clicked your pin button, and you've determined that the APIs are present, taskbar is present, and pinning is allowed... time to pin!</span></span>

<span data-ttu-id="8171f-138">最初に、スタート画面にピン留めした場合と同様に、セカンダリ タイルを作成します。</span><span class="sxs-lookup"><span data-stu-id="8171f-138">First, construct your secondary tile just like you would when pinning to Start.</span></span> <span data-ttu-id="8171f-139">セカンダリ タイルのプロパティについて詳しくは、[スタート画面にセカンダリ タイルをピン留め](secondary-tiles-pinning.md)を読み取ること知ることができます。</span><span class="sxs-lookup"><span data-stu-id="8171f-139">You can learn more about the secondary tile properties by reading [Pin secondary tiles to Start](secondary-tiles-pinning.md).</span></span> <span data-ttu-id="8171f-140">ただし、以前の必須のプロパティだけでなく、タスク バーにピン留めした場合 (これは、タスク バーで使われるロゴ) Square44x44Logo も必要です。</span><span class="sxs-lookup"><span data-stu-id="8171f-140">However, when pinning to taskbar, in addition to the previously required properties, Square44x44Logo (this is the logo used by taskbar) is also required.</span></span> <span data-ttu-id="8171f-141">それ以外の場合、例外がスローされます。</span><span class="sxs-lookup"><span data-stu-id="8171f-141">Otherwise, an exception will be thrown.</span></span>

<span data-ttu-id="8171f-142">次に、タイルを**[RequestPinSecondaryTileAsync](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager.requestpinsecondarytileasync)** メソッドに渡します。</span><span class="sxs-lookup"><span data-stu-id="8171f-142">Then, pass the tile to the **[RequestPinSecondaryTileAsync](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager.requestpinsecondarytileasync)** method.</span></span> <span data-ttu-id="8171f-143">これは、制限付きアクセスの下であるためこれによって確認のダイアログ ボックスが表示されなくされ、UI スレッドは必要ありません。</span><span class="sxs-lookup"><span data-stu-id="8171f-143">Since this is under limited-access, this will not display a confirmation dialog and does not require a UI thread.</span></span> <span data-ttu-id="8171f-144">ただし、今後このを開いたときアクセス制限されたを超えて呼び出し元の制限付きアクセスを利用していないダイアログ ボックスが表示され、UI スレッドを使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8171f-144">But in the future when this is opened up beyond limited-access, callers not utilizing limited-access will receive a dialog and be required to use the UI thread.</span></span>

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

<span data-ttu-id="8171f-145">このメソッドは、タイルがタスク バーにピン留めできるようになりましたかどうかを示すブール値を返します。</span><span class="sxs-lookup"><span data-stu-id="8171f-145">This method returns a boolean value that indicates whether your tile is now pinned to the taskbar.</span></span> <span data-ttu-id="8171f-146">タイルが既にピン留めされている場合、このメソッドは、既存のタイルを更新し、true を返します。</span><span class="sxs-lookup"><span data-stu-id="8171f-146">If your tile was already pinned, the method updates the existing tile and returns true.</span></span> <span data-ttu-id="8171f-147">ピン留めが許可されている、またはタスク バーがサポートされていない、このメソッドは false を返します。</span><span class="sxs-lookup"><span data-stu-id="8171f-147">If pinning wasn't allowed or taskbar isn't supported, the method returns false.</span></span>


## <a name="enumerate-tiles"></a><span data-ttu-id="8171f-148">タイルを列挙します。</span><span class="sxs-lookup"><span data-stu-id="8171f-148">Enumerate tiles</span></span>

<span data-ttu-id="8171f-149">作成し、まだはどこかにピン留めされているすべてのタイルを参照してください (スタート画面、タスク バー、またはその両方)、 **[FindAllAsync](https://docs.microsoft.com/uwp/api/windows.ui.startscreen.secondarytile.findallasync)** を使用します。</span><span class="sxs-lookup"><span data-stu-id="8171f-149">To see all the tiles that you created and are still pinned somewhere (Start, taskbar, or both), use **[FindAllAsync](https://docs.microsoft.com/uwp/api/windows.ui.startscreen.secondarytile.findallasync)**.</span></span> <span data-ttu-id="8171f-150">その後、これらのタイルがスタート画面やタスク バーにピン留めされているかどうかを確認できます。</span><span class="sxs-lookup"><span data-stu-id="8171f-150">You can subsequently check whether these tiles are pinned to the taskbar and/or Start.</span></span> <span data-ttu-id="8171f-151">サーフェスがサポートされていない場合は、これらのメソッドは false を返します。</span><span class="sxs-lookup"><span data-stu-id="8171f-151">If the surface isn't supported, these methods return false.</span></span>

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


## <a name="update-a-tile"></a><span data-ttu-id="8171f-152">タイルを更新します。</span><span class="sxs-lookup"><span data-stu-id="8171f-152">Update a tile</span></span>

<span data-ttu-id="8171f-153">[セカンダリ タイルを更新](secondary-tiles-pinning.md#updating-a-secondary-tile)」の説明に従って、既にピン留めしたタイルを更新して、 [**SecondaryTile.UpdateAsync**](https://docs.microsoft.com/uwp/api/windows.ui.startscreen.secondarytile.updateasync)メソッドを使用できます。</span><span class="sxs-lookup"><span data-stu-id="8171f-153">To update an already pinned tile, you can use the [**SecondaryTile.UpdateAsync**](https://docs.microsoft.com/uwp/api/windows.ui.startscreen.secondarytile.updateasync) method as described in [Updating a secondary tile](secondary-tiles-pinning.md#updating-a-secondary-tile).</span></span>


## <a name="unpin-a-tile"></a><span data-ttu-id="8171f-154">タイルのピン留めを外す</span><span class="sxs-lookup"><span data-stu-id="8171f-154">Unpin a tile</span></span>

<span data-ttu-id="8171f-155">タイルが現在ピン留めした場合、アプリは、ピン留めを外す] ボタンを用意する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8171f-155">Your app should provide an unpin button if the tile is currently pinned.</span></span> <span data-ttu-id="8171f-156">タイルをピン留めを外すを**[TryUnpinSecondaryTileAsync](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager.tryunpinsecondarytileasync)** を渡して外したするセカンダリ タイルの**TileId**を呼び出すだけです。</span><span class="sxs-lookup"><span data-stu-id="8171f-156">To unpin the tile, simply call **[TryUnpinSecondaryTileAsync](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager.tryunpinsecondarytileasync)**, passing in the **TileId** of the secondary tile you would like unpinned.</span></span>

<span data-ttu-id="8171f-157">このメソッドは、タイルがタスク バーにピン留めできなくするかどうかを示すブール値を返します。</span><span class="sxs-lookup"><span data-stu-id="8171f-157">This method returns a boolean value that indicates whether your tile is no longer pinned to the taskbar.</span></span> <span data-ttu-id="8171f-158">場合は、タイルがピン留めされている、最初に、これも true を返します。</span><span class="sxs-lookup"><span data-stu-id="8171f-158">If your tile wasn't pinned in the first place, this also returns true.</span></span> <span data-ttu-id="8171f-159">外したりが許可された場合、これは false を返します。</span><span class="sxs-lookup"><span data-stu-id="8171f-159">If unpinning wasn't allowed, this returns false.</span></span>

<span data-ttu-id="8171f-160">タイルがタスク バーにピン留めのみと、タイルを任意の場所にピン留めされなくなったためこの削除されます。</span><span class="sxs-lookup"><span data-stu-id="8171f-160">If your tile was only pinned to taskbar, this will delete the tile since it is no longer pinned anywhere.</span></span>

```csharp
var taskbarManager = TaskbarManager.GetDefault();
if (taskbarManager != null)
{
    bool isUnpinned = await taskbarManager.TryUnpinSecondaryTileAsync("myTileId");
}
```


## <a name="delete-a-tile"></a><span data-ttu-id="8171f-161">タイルを削除します。</span><span class="sxs-lookup"><span data-stu-id="8171f-161">Delete a tile</span></span>

<span data-ttu-id="8171f-162">すべての場所 (スタート画面、タスク バー) からのタイルのピン留めを外すする場合は、 **[RequestDeleteAsync](https://docs.microsoft.com/uwp/api/windows.ui.startscreen.secondarytile.requestdeleteasync)** メソッドを使用します。</span><span class="sxs-lookup"><span data-stu-id="8171f-162">If you want to unpin a tile from everywhere (Start, taskbar), use the **[RequestDeleteAsync](https://docs.microsoft.com/uwp/api/windows.ui.startscreen.secondarytile.requestdeleteasync)** method.</span></span>

<span data-ttu-id="8171f-163">これは、ユーザーがピン留めされている内容が適用されるしなくなった場合に適しています。</span><span class="sxs-lookup"><span data-stu-id="8171f-163">This is appropriate for cases where the content the user pinned is no longer applicable.</span></span> <span data-ttu-id="8171f-164">たとえば、アプリでは、スタート画面とタスク バーにノートブックをピン留めすることができ、ユーザーがノートブックを削除し場合、は、ノートブックに関連付けられているタイルを単に削除する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8171f-164">For example, if your app lets you pin a notebook to Start and taskbar, and then the user deletes the notebook, you should simply delete the tile associated with the notebook.</span></span>

```csharp
// Initialize a secondary tile with the same tile ID you want removed.
// Or, locate it with FindAllAsync()
SecondaryTile toBeDeleted = new SecondaryTile(tileId);

// And then delete the tile
await toBeDeleted.RequestDeleteAsync();
```


## <a name="unpin-only-from-start"></a><span data-ttu-id="8171f-165">スタート画面からのみピン留めを外す</span><span class="sxs-lookup"><span data-stu-id="8171f-165">Unpin only from Start</span></span>

<span data-ttu-id="8171f-166">タスク バーのまま、セカンダリ タイルをスタートからピン留めを外す場合は、 **[StartScreenManager.TryRemoveSecondaryTileAsync](https://docs.microsoft.com/uwp/api/windows.ui.startscreen.startscreenmanager.tryremovesecondarytileasync)** メソッドを呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="8171f-166">If you only want to unpin a secondary tile from Start while leaving it on Taskbar, you can call the **[StartScreenManager.TryRemoveSecondaryTileAsync](https://docs.microsoft.com/uwp/api/windows.ui.startscreen.startscreenmanager.tryremovesecondarytileasync)** method.</span></span> <span data-ttu-id="8171f-167">同様に他の任意のサーフェスになったピン留めした場合、タイルが削除されます。</span><span class="sxs-lookup"><span data-stu-id="8171f-167">This will similarly delete the tile if it is no longer pinned to any other surfaces.</span></span>

<span data-ttu-id="8171f-168">このメソッドは、タイルがスタート画面にピン留めできなくするかどうかを示すブール値を返します。</span><span class="sxs-lookup"><span data-stu-id="8171f-168">This method returns a boolean value that indicates whether your tile is no longer pinned to Start.</span></span> <span data-ttu-id="8171f-169">場合は、タイルがピン留めされている、最初に、これも true を返します。</span><span class="sxs-lookup"><span data-stu-id="8171f-169">If your tile wasn't pinned in the first place, this also returns true.</span></span> <span data-ttu-id="8171f-170">外したり許可されない、またはスタート画面はサポートされていません、これは false を返します。</span><span class="sxs-lookup"><span data-stu-id="8171f-170">If unpinning wasn't allowed or Start isn't supported, this returns false.</span></span>

```csharp
await StartScreenManager.GetDefault().TryRemoveSecondaryTileAsync("myTileId");
```


## <a name="resources"></a><span data-ttu-id="8171f-171">リソース</span><span class="sxs-lookup"><span data-stu-id="8171f-171">Resources</span></span>

* [<span data-ttu-id="8171f-172">TaskbarManager クラス</span><span class="sxs-lookup"><span data-stu-id="8171f-172">TaskbarManager class</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager)
* [<span data-ttu-id="8171f-173">スタート画面にセカンダリ タイルをピン留め</span><span class="sxs-lookup"><span data-stu-id="8171f-173">Pin secondary tiles to Start</span></span>](secondary-tiles-pinning.md)