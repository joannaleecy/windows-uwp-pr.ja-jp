---
Description: プログラムを使って、アプリをタスク バーにピン留めすることができます。また現在ピン留めされているかどうかを確認できます。
title: アプリをタスク バーにピン留めする
template: detail.hbs
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, タスク バー、タスク バー マネージャー、タスク バーにピン留め、プライマリ タイル
ms.localizationpriority: medium
ms.openlocfilehash: 640dc637a1c50718210d87af87cb8b8e706a5ab7
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57604097"
---
# <a name="pin-your-app-to-the-taskbar"></a><span data-ttu-id="62c3c-104">アプリをタスク バーにピン留めする</span><span class="sxs-lookup"><span data-stu-id="62c3c-104">Pin your app to the taskbar</span></span>

<span data-ttu-id="62c3c-105">[アプリをスタート メニューにピン留め](tiles-and-notifications/primary-tile-apis.md)できるのと同様に、プログラムを使ってアプリをタスク バーにピン留めすることができます。</span><span class="sxs-lookup"><span data-stu-id="62c3c-105">You can programmatically pin your own app to the taskbar, just like you can [pin your app to the Start menu](tiles-and-notifications/primary-tile-apis.md).</span></span> <span data-ttu-id="62c3c-106">アプリが現在ピン留めされているかどうか、またタスク バーがピン留めを許可しているかどうかを確認できます。</span><span class="sxs-lookup"><span data-stu-id="62c3c-106">And you can check whether your app is currently pinned, and whether the taskbar allows pinning.</span></span> 

![タスク バー](images/taskbar/taskbar.png)

> [!IMPORTANT]
> <span data-ttu-id="62c3c-108">**Fall Creators Update が必要です**:。SDK 16299 を対象にして、16299 以降、タスク バー Api を使用するビルドを実行します。</span><span class="sxs-lookup"><span data-stu-id="62c3c-108">**Requires Fall Creators Update**: You must target SDK 16299 and be running build 16299 or higher to use the taskbar APIs.</span></span>

> <span data-ttu-id="62c3c-109">**重要な Api**:[TaskbarManager クラス](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager)</span><span class="sxs-lookup"><span data-stu-id="62c3c-109">**Important APIs**: [TaskbarManager class](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager)</span></span> 


## <a name="when-should-you-ask-the-user-to-pin-your-app-to-the-taskbar"></a><span data-ttu-id="62c3c-110">アプリのタスク バーへのピン留めをユーザーに確認する</span><span class="sxs-lookup"><span data-stu-id="62c3c-110">When should you ask the user to pin your app to the taskbar?</span></span> 

<span data-ttu-id="62c3c-111">[TaskbarManager クラス](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager)を使うと、アプリのタスク バーへのピン留めをユーザーに確認できます。ユーザーは要求を承認する必要があります。</span><span class="sxs-lookup"><span data-stu-id="62c3c-111">The [TaskbarManager class](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager) lets you ask the user to pin your app to the taskbar; the user must approve the request.</span></span> <span data-ttu-id="62c3c-112">多くの労力をかけて優れたアプリを作成したら、ユーザーにそのアプリをタスク バーにピン留めするように求めることができます。</span><span class="sxs-lookup"><span data-stu-id="62c3c-112">You put a lot of effort into building a stellar app, and now you have the opportunity to ask the user to pin it to taskbar.</span></span> <span data-ttu-id="62c3c-113">コードについて詳しく説明する前に、エクスペリエンスを設計するときの注意点を示します。</span><span class="sxs-lookup"><span data-stu-id="62c3c-113">But before we dive into the code, here are some things to keep in mind as you are designing your experience:</span></span>

* <span data-ttu-id="62c3c-114">"タスク バーへのピン留め" を実行するよう明確に呼びかける、スムーズで簡単に無視できる **UX** をアプリで作成すること。</span><span class="sxs-lookup"><span data-stu-id="62c3c-114">**Do** craft a non-disruptive and easily dismissible UX in your app with a clear "Pin to taskbar" call to action.</span></span> <span data-ttu-id="62c3c-115">このためには、ダイアログとポップアップを使用しないようにします。</span><span class="sxs-lookup"><span data-stu-id="62c3c-115">Avoid using dialogs and flyouts for this purpose.</span></span> 
* <span data-ttu-id="62c3c-116">**アプ**リをピン留めするようユーザーに要求する前に、アプリのピン留めの価値について明確に説明すること。</span><span class="sxs-lookup"><span data-stu-id="62c3c-116">**Do** clearly explain the value of your app before asking the user to pin it.</span></span>
* <span data-ttu-id="62c3c-117">**タイルが**既にピン留めされているか、デバイスでピン留めがサポートされていない場合、アプリをピン留めするようユーザーに要求しないこと。</span><span class="sxs-lookup"><span data-stu-id="62c3c-117">**Don't** ask a user to pin your app if the tile is already pinned or the device doesn’t support it.</span></span> <span data-ttu-id="62c3c-118">(この記事では、ピン留めがサポートされているかどうかを判別する方法を説明します。)</span><span class="sxs-lookup"><span data-stu-id="62c3c-118">(This article explains how to determine whether pinning is supported.)</span></span>
* <span data-ttu-id="62c3c-119">**アプリをピ**ン留めするようユーザーに繰り返し要求しないこと (ユーザーが不快になる恐れがあります)。</span><span class="sxs-lookup"><span data-stu-id="62c3c-119">**Don't** repeatedly ask the user to pin your app (they will probably get annoyed).</span></span>
* <span data-ttu-id="62c3c-120">**明示的なユ**ーザー操作を必要としない場合や、アプリが最小化されているか開いていないときに、ピン留めの API を呼び出さないこと。</span><span class="sxs-lookup"><span data-stu-id="62c3c-120">**Don't** call the pin API without explicit user interaction or when your app is minimized/not open.</span></span>


## <a name="1-check-whether-the-required-apis-exist"></a><span data-ttu-id="62c3c-121">1. 必要な Api が存在するかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="62c3c-121">1. Check whether the required APIs exist</span></span>

<span data-ttu-id="62c3c-122">アプリで Windows 10 の以前のバージョンをサポートする場合は、TaskbarManager クラスが利用できるかどうかを確認する必要があります。</span><span class="sxs-lookup"><span data-stu-id="62c3c-122">If your app supports older versions of Windows 10, you need to check whether the TaskbarManager class is available.</span></span> <span data-ttu-id="62c3c-123">[ApiInformation.IsTypePresent メソッド](https://docs.microsoft.com/en-us/uwp/api/windows.foundation.metadata.apiinformation#Windows_Foundation_Metadata_ApiInformation_IsTypePresent_System_String_)を使ってこの確認を行えます。</span><span class="sxs-lookup"><span data-stu-id="62c3c-123">You can use the  [ApiInformation.IsTypePresent method](https://docs.microsoft.com/en-us/uwp/api/windows.foundation.metadata.apiinformation#Windows_Foundation_Metadata_ApiInformation_IsTypePresent_System_String_) to perform this check.</span></span> <span data-ttu-id="62c3c-124">TaskbarManager クラスを利用できない場合は、API への呼び出しを実行しないでください。</span><span class="sxs-lookup"><span data-stu-id="62c3c-124">If the TaskbarManager class isn't available, avoid executing any calls to the APIs.</span></span>

```csharp
if (ApiInformation.IsTypePresent("Windows.UI.Shell.TaskbarManager"))
{
    // Taskbar APIs exist!
}

else
{
    // Older version of Windows, no taskbar APIs
}
```


## <a name="2-check-whether-taskbar-is-present-and-allows-pinning"></a><span data-ttu-id="62c3c-125">2. タスク バーが存在し、ピン留めを使用するかどうかを確認してください。</span><span class="sxs-lookup"><span data-stu-id="62c3c-125">2. Check whether taskbar is present and allows pinning</span></span>

<span data-ttu-id="62c3c-126">UWP アプリはさまざまなデバイスで実行できます。それらのすべてがタスク バーをサポートするとは限りません。</span><span class="sxs-lookup"><span data-stu-id="62c3c-126">UWP apps can run on a wide variety of devices; not all of them support the taskbar.</span></span> <span data-ttu-id="62c3c-127">現時点では、デスクトップ デバイスのみがタスク バーをサポートしています。</span><span class="sxs-lookup"><span data-stu-id="62c3c-127">Right now, only Desktop devices support the taskbar.</span></span> 

<span data-ttu-id="62c3c-128">タスク バーが利用できる場合でも、ユーザーのコンピューターのグループ ポリシーにより、タスク バーのピン留めが無効になっている場合があります。</span><span class="sxs-lookup"><span data-stu-id="62c3c-128">Even if the taskbar is available, a group policy on the user's machine might disable taskbar pinning.</span></span> <span data-ttu-id="62c3c-129">そのため、アプリをピン留めする前に、タスク バーへのピン留めがサポートされているかどうかを確認する必要があります。</span><span class="sxs-lookup"><span data-stu-id="62c3c-129">So, before you attempt to pin your app, you need to check whether pinning to the taskbar is supported.</span></span> <span data-ttu-id="62c3c-130">[TaskbarManager.IsPinningAllowed プロパティ](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager.IsPinningAllowed)は、タスク バーが存在してピン留めを使用できる場合には true を返します。</span><span class="sxs-lookup"><span data-stu-id="62c3c-130">The [TaskbarManager.IsPinningAllowed property](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager.IsPinningAllowed) returns true if the taskbar is present and allows pinning.</span></span> 

```csharp
// Check if taskbar allows pinning (Group Policy can disable it, or some device families don't have taskbar)
bool isPinningAllowed = TaskbarManager.GetDefault().IsPinningAllowed;
```

> [!NOTE]
> <span data-ttu-id="62c3c-131">アプリのタスク バーへのピン留めを行わず、タスク バーが利用できるかどうかだけを確認するには、[TaskbarManager.IsSupported プロパティ](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager.IsSupported)を使用します。</span><span class="sxs-lookup"><span data-stu-id="62c3c-131">If you don't want to pin your app to the taskbar and just want to find out whether the taskbar is available, use the [TaskbarManager.IsSupported property](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager.IsSupported).</span></span>


## <a name="3-check-whether-your-app-is-currently-pinned-to-the-taskbar"></a><span data-ttu-id="62c3c-132">3.アプリがタスク バーに現在固定されているかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="62c3c-132">3. Check whether your app is currently pinned to the taskbar</span></span>

<span data-ttu-id="62c3c-133">アプリが既にタスク バーにピン留めされている場合には、アプリのタスク バーへのピン留めをユーザーに求める意味がありません。</span><span class="sxs-lookup"><span data-stu-id="62c3c-133">Obviously, there's no point in asking the user to let you pin the app to the taskbar if it's already pinned there.</span></span> <span data-ttu-id="62c3c-134">ユーザーに要求する前に、[TaskbarManager.IsCurrentAppPinnedAsync メソッド](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager.IsCurrentAppPinnedAsync)を使うと、アプリが既にピン留めされているかどうかを確認できます。</span><span class="sxs-lookup"><span data-stu-id="62c3c-134">You can use the [TaskbarManager.IsCurrentAppPinnedAsync method](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager.IsCurrentAppPinnedAsync) to check whether the app is already pinned before asking the user.</span></span>

```csharp
// Check whether your app is currently pinned
bool isPinned = await TaskbarManager.GetDefault().IsCurrentAppPinnedAsync();

if (isPinned)
{
    // The app is already pinned--no point in asking to pin it again!
}
else 
{
    //The app is not pinned. 
}
```


##  <a name="4-pin-your-app"></a><span data-ttu-id="62c3c-135">4。アプリをピン留め</span><span class="sxs-lookup"><span data-stu-id="62c3c-135">4. Pin your app</span></span>

<span data-ttu-id="62c3c-136">タスク バーが存在し、ピン留めが許可されており、アプリが現在ピン留めされていない場合には、ユーザーがアプリをピン留めできることをユーザーに知らせる、控えめなヒントを表示することができます。</span><span class="sxs-lookup"><span data-stu-id="62c3c-136">If the taskbar is present and pinning is allowed and your app currently isn't pinned, you might want to show a subtle tip to let users know that they can pin your app.</span></span> <span data-ttu-id="62c3c-137">たとえば、UI のどこかにピンのアイコンを表示して、ユーザーがクリックできるようにすることができます。</span><span class="sxs-lookup"><span data-stu-id="62c3c-137">For example, you might show a pin icon somewhere in your UI that the user can click.</span></span> 

<span data-ttu-id="62c3c-138">ユーザーがピン留めのお勧めの UI をクリックした場合、[TaskbarManager.RequestPinCurrentAppAsync メソッド](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager.RequestPinCurrentAppAsync)を呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="62c3c-138">If the user clicks your pin suggestion UI, you would then call the [TaskbarManager.RequestPinCurrentAppAsync method](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager.RequestPinCurrentAppAsync).</span></span> <span data-ttu-id="62c3c-139">このメソッドにより、アプリをタスク バーにピン留めするかどうかの確認を求めるダイアログがユーザーに表示されます。</span><span class="sxs-lookup"><span data-stu-id="62c3c-139">This method displays a dialog that asks the user to confirm that they want your app pinned to the taskbar.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="62c3c-140">これは、フォアグラウンド UI スレッドから呼び出す必要があります。それ以外の場合は例外がスローされます。</span><span class="sxs-lookup"><span data-stu-id="62c3c-140">This must be called from a foreground UI thread, otherwise an exception will be thrown.</span></span>

```csharp
// Request to be pinned to the taskbar
bool isPinned = await TaskbarManager.GetDefault().RequestPinCurrentAppAsync();
```

![ピン留めのダイアログ](images/taskbar/pin-dialog.png)

<span data-ttu-id="62c3c-142">このメソッドは、アプリがタスク バーにピン留めされたかどうかを示す、ブール値を返します。</span><span class="sxs-lookup"><span data-stu-id="62c3c-142">This method returns a boolean value that indicates whether your app is now pinned to the taskbar.</span></span> <span data-ttu-id="62c3c-143">アプリが既にピン留めされている場合は、このメソッドは、ユーザーにダイアログを表示せずに、すぐに true を返します。</span><span class="sxs-lookup"><span data-stu-id="62c3c-143">If your app was already pinned, the method immediately returns true without showing the dialog to the user.</span></span> <span data-ttu-id="62c3c-144">ユーザーがダイアログで [いいえ] をクリックしたか、アプリをタスク バーにピン留めすることが許可されていない場合、メソッドは false を返します。</span><span class="sxs-lookup"><span data-stu-id="62c3c-144">If the user clicks "no" on the dialog, or pinning your app to the taskbar isn't allowed, the method returns false.</span></span> <span data-ttu-id="62c3c-145">ユーザーが [はい] をクリックすると、アプリがピン留めされ、API から true が返されます。</span><span class="sxs-lookup"><span data-stu-id="62c3c-145">Otherwise, the user clicked yes and the app was pinned, and the API will return true.</span></span>


## <a name="resources"></a><span data-ttu-id="62c3c-146">参考資料</span><span class="sxs-lookup"><span data-stu-id="62c3c-146">Resources</span></span>

* [<span data-ttu-id="62c3c-147">GitHub の完全なコード サンプル</span><span class="sxs-lookup"><span data-stu-id="62c3c-147">Full code sample on GitHub</span></span>](https://github.com/WindowsNotifications/quickstart-pin-to-taskbar)
* [<span data-ttu-id="62c3c-148">TaskbarManager クラス</span><span class="sxs-lookup"><span data-stu-id="62c3c-148">TaskbarManager class</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager)
* <span data-ttu-id="62c3c-149">[[スタート] メニューにアプリをピン留め](tiles-and-notifications/primary-tile-apis.md)</span><span class="sxs-lookup"><span data-stu-id="62c3c-149">[Pin an app to the Start menu](tiles-and-notifications/primary-tile-apis.md)</span></span>