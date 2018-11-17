---
author: mijacobs
Description: You can programmatically pin your app to the taskbar,  bnd you can check if it's currently pinned.
title: アプリをタスク バーにピン留めする
template: detail.hbs
ms.author: mijacobs
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, タスク バー、タスク バー マネージャー、タスク バーにピン留め、プライマリ タイル
ms.localizationpriority: medium
ms.openlocfilehash: 47fcd1f9d090c49ecbd49e05696b33f789973160
ms.sourcegitcommit: 3257416aebb5a7b1515e107866806f8bd57845a8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/17/2018
ms.locfileid: "7167218"
---
# <a name="pin-your-app-to-the-taskbar"></a><span data-ttu-id="0b378-103">アプリをタスク バーにピン留めする</span><span class="sxs-lookup"><span data-stu-id="0b378-103">Pin your app to the taskbar</span></span>

<span data-ttu-id="0b378-104">[アプリをスタート メニューにピン留め](tiles-and-notifications/primary-tile-apis.md)できるのと同様に、プログラムを使ってアプリをタスク バーにピン留めすることができます。</span><span class="sxs-lookup"><span data-stu-id="0b378-104">You can programmatically pin your own app to the taskbar, just like you can [pin your app to the Start menu](tiles-and-notifications/primary-tile-apis.md).</span></span> <span data-ttu-id="0b378-105">アプリが現在ピン留めされているかどうか、またタスク バーがピン留めを許可しているかどうかを確認できます。</span><span class="sxs-lookup"><span data-stu-id="0b378-105">And you can check whether your app is currently pinned, and whether the taskbar allows pinning.</span></span> 

![タスク バー](images/taskbar/taskbar.png)

> [!IMPORTANT]
> <span data-ttu-id="0b378-107">**Fall Creators Update が必要**: タスクバー API を使用するには、SDK 16299 以降をターゲットとし、ビルド 16299 以降を実行している必要があります。</span><span class="sxs-lookup"><span data-stu-id="0b378-107">**Requires Fall Creators Update**: You must target SDK 16299 and be running build 16299 or higher to use the taskbar APIs.</span></span>

> <span data-ttu-id="0b378-108">**重要な API**: [TaskbarManager クラス](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager)</span><span class="sxs-lookup"><span data-stu-id="0b378-108">**Important APIs**: [TaskbarManager class](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager)</span></span> 


## <a name="when-should-you-ask-the-user-to-pin-your-app-to-the-taskbar"></a><span data-ttu-id="0b378-109">アプリのタスク バーへのピン留めをユーザーに確認する</span><span class="sxs-lookup"><span data-stu-id="0b378-109">When should you ask the user to pin your app to the taskbar?</span></span> 

<span data-ttu-id="0b378-110">[TaskbarManager クラス](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager)を使うと、アプリのタスク バーへのピン留めをユーザーに確認できます。ユーザーは要求を承認する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0b378-110">The [TaskbarManager class](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager) lets you ask the user to pin your app to the taskbar; the user must approve the request.</span></span> <span data-ttu-id="0b378-111">多くの労力をかけて優れたアプリを作成したら、ユーザーにそのアプリをタスク バーにピン留めするように求めることができます。</span><span class="sxs-lookup"><span data-stu-id="0b378-111">You put a lot of effort into building a stellar app, and now you have the opportunity to ask the user to pin it to taskbar.</span></span> <span data-ttu-id="0b378-112">コードについて詳しく説明する前に、エクスペリエンスを設計するときの注意点を示します。</span><span class="sxs-lookup"><span data-stu-id="0b378-112">But before we dive into the code, here are some things to keep in mind as you are designing your experience:</span></span>

* <span data-ttu-id="0b378-113">"タスク バーへのピン留め" を実行するよう明確に呼びかける、スムーズで簡単に無視できる UX をアプリで作成すること。\*\*\*\*</span><span class="sxs-lookup"><span data-stu-id="0b378-113">**Do** craft a non-disruptive and easily dismissible UX in your app with a clear "Pin to taskbar" call to action.</span></span> <span data-ttu-id="0b378-114">このためには、ダイアログとポップアップを使用しないようにします。</span><span class="sxs-lookup"><span data-stu-id="0b378-114">Avoid using dialogs and flyouts for this purpose.</span></span> 
* <span data-ttu-id="0b378-115">アプリをピン留めするようユーザーに要求する前に、アプリのピン留めの価値について明確に説明すること。\*\*\*\*</span><span class="sxs-lookup"><span data-stu-id="0b378-115">**Do** clearly explain the value of your app before asking the user to pin it.</span></span>
* <span data-ttu-id="0b378-116">タイルが既にピン留めされているか、デバイスでピン留めがサポートされていない場合、アプリをピン留めするようユーザーに要求しないこと。\*\*\*\*</span><span class="sxs-lookup"><span data-stu-id="0b378-116">**Don't** ask a user to pin your app if the tile is already pinned or the device doesn’t support it.</span></span> <span data-ttu-id="0b378-117">(この記事では、ピン留めがサポートされているかどうかを判別する方法を説明します。)</span><span class="sxs-lookup"><span data-stu-id="0b378-117">(This article explains how to determine whether pinning is supported.)</span></span>
* <span data-ttu-id="0b378-118">アプリをピン留めするようユーザーに繰り返し要求しないこと (ユーザーが不快になる恐れがあります)。\*\*\*\*</span><span class="sxs-lookup"><span data-stu-id="0b378-118">**Don't** repeatedly ask the user to pin your app (they will probably get annoyed).</span></span>
* <span data-ttu-id="0b378-119">明示的なユーザー操作を必要としない場合や、アプリが最小化されているか開いていないときに、ピン留めの API を呼び出さないこと。\*\*\*\*</span><span class="sxs-lookup"><span data-stu-id="0b378-119">**Don't** call the pin API without explicit user interaction or when your app is minimized/not open.</span></span>


## <a name="1-check-whether-the-required-apis-exist"></a><span data-ttu-id="0b378-120">1. 必要な API が存在するかどうかを確認する</span><span class="sxs-lookup"><span data-stu-id="0b378-120">1. Check whether the required APIs exist</span></span>

<span data-ttu-id="0b378-121">アプリで Windows 10 の以前のバージョンをサポートする場合は、TaskbarManager クラスが利用できるかどうかを確認する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0b378-121">If your app supports older versions of Windows 10, you need to check whether the TaskbarManager class is available.</span></span> <span data-ttu-id="0b378-122">[ApiInformation.IsTypePresent メソッド](https://docs.microsoft.com/en-us/uwp/api/windows.foundation.metadata.apiinformation#Windows_Foundation_Metadata_ApiInformation_IsTypePresent_System_String_)を使ってこの確認を行えます。</span><span class="sxs-lookup"><span data-stu-id="0b378-122">You can use the  [ApiInformation.IsTypePresent method](https://docs.microsoft.com/en-us/uwp/api/windows.foundation.metadata.apiinformation#Windows_Foundation_Metadata_ApiInformation_IsTypePresent_System_String_) to perform this check.</span></span> <span data-ttu-id="0b378-123">TaskbarManager クラスを利用できない場合は、API への呼び出しを実行しないでください。</span><span class="sxs-lookup"><span data-stu-id="0b378-123">If the TaskbarManager class isn't available, avoid executing any calls to the APIs.</span></span>

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


## <a name="2-check-whether-taskbar-is-present-and-allows-pinning"></a><span data-ttu-id="0b378-124">2. タスク バーが存在し、ピン留めを使用できるかどうかを確認する</span><span class="sxs-lookup"><span data-stu-id="0b378-124">2. Check whether taskbar is present and allows pinning</span></span>

<span data-ttu-id="0b378-125">UWP アプリはさまざまなデバイスで実行できます。それらのすべてがタスク バーをサポートするとは限りません。</span><span class="sxs-lookup"><span data-stu-id="0b378-125">UWP apps can run on a wide variety of devices; not all of them support the taskbar.</span></span> <span data-ttu-id="0b378-126">現時点では、デスクトップ デバイスのみがタスク バーをサポートしています。</span><span class="sxs-lookup"><span data-stu-id="0b378-126">Right now, only Desktop devices support the taskbar.</span></span> 

<span data-ttu-id="0b378-127">タスク バーが利用できる場合でも、ユーザーのコンピューターのグループ ポリシーにより、タスク バーのピン留めが無効になっている場合があります。</span><span class="sxs-lookup"><span data-stu-id="0b378-127">Even if the taskbar is available, a group policy on the user's machine might disable taskbar pinning.</span></span> <span data-ttu-id="0b378-128">そのため、アプリをピン留めする前に、タスク バーへのピン留めがサポートされているかどうかを確認する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0b378-128">So, before you attempt to pin your app, you need to check whether pinning to the taskbar is supported.</span></span> <span data-ttu-id="0b378-129">[TaskbarManager.IsPinningAllowed プロパティ](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager.IsPinningAllowed)は、タスク バーが存在してピン留めを使用できる場合には true を返します。</span><span class="sxs-lookup"><span data-stu-id="0b378-129">The [TaskbarManager.IsPinningAllowed property](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager.IsPinningAllowed) returns true if the taskbar is present and allows pinning.</span></span> 

```csharp
// Check if taskbar allows pinning (Group Policy can disable it, or some device families don't have taskbar)
bool isPinningAllowed = TaskbarManager.GetDefault().IsPinningAllowed;
```

> [!NOTE]
> <span data-ttu-id="0b378-130">アプリのタスク バーへのピン留めを行わず、タスク バーが利用できるかどうかだけを確認するには、[TaskbarManager.IsSupported プロパティ](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager.IsSupported)を使用します。</span><span class="sxs-lookup"><span data-stu-id="0b378-130">If you don't want to pin your app to the taskbar and just want to find out whether the taskbar is available, use the [TaskbarManager.IsSupported property](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager.IsSupported).</span></span>


## <a name="3-check-whether-your-app-is-currently-pinned-to-the-taskbar"></a><span data-ttu-id="0b378-131">3. アプリが現在タスク バーにピン留めされているかどうかを確認する</span><span class="sxs-lookup"><span data-stu-id="0b378-131">3. Check whether your app is currently pinned to the taskbar</span></span>

<span data-ttu-id="0b378-132">アプリが既にタスク バーにピン留めされている場合には、アプリのタスク バーへのピン留めをユーザーに求める意味がありません。</span><span class="sxs-lookup"><span data-stu-id="0b378-132">Obviously, there's no point in asking the user to let you pin the app to the taskbar if it's already pinned there.</span></span> <span data-ttu-id="0b378-133">ユーザーに要求する前に、[TaskbarManager.IsCurrentAppPinnedAsync メソッド](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager.IsCurrentAppPinnedAsync)を使うと、アプリが既にピン留めされているかどうかを確認できます。</span><span class="sxs-lookup"><span data-stu-id="0b378-133">You can use the [TaskbarManager.IsCurrentAppPinnedAsync method](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager.IsCurrentAppPinnedAsync) to check whether the app is already pinned before asking the user.</span></span>

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


##  <a name="4-pin-your-app"></a><span data-ttu-id="0b378-134">4. アプリをピン留めする</span><span class="sxs-lookup"><span data-stu-id="0b378-134">4. Pin your app</span></span>

<span data-ttu-id="0b378-135">タスク バーが存在し、ピン留めが許可されており、アプリが現在ピン留めされていない場合には、ユーザーがアプリをピン留めできることをユーザーに知らせる、控えめなヒントを表示することができます。</span><span class="sxs-lookup"><span data-stu-id="0b378-135">If the taskbar is present and pinning is allowed and your app currently isn't pinned, you might want to show a subtle tip to let users know that they can pin your app.</span></span> <span data-ttu-id="0b378-136">たとえば、UI のどこかにピンのアイコンを表示して、ユーザーがクリックできるようにすることができます。</span><span class="sxs-lookup"><span data-stu-id="0b378-136">For example, you might show a pin icon somewhere in your UI that the user can click.</span></span> 

<span data-ttu-id="0b378-137">ユーザーがピン留めのお勧めの UI をクリックした場合、[TaskbarManager.RequestPinCurrentAppAsync メソッド](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager.RequestPinCurrentAppAsync)を呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="0b378-137">If the user clicks your pin suggestion UI, you would then call the [TaskbarManager.RequestPinCurrentAppAsync method](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager.RequestPinCurrentAppAsync).</span></span> <span data-ttu-id="0b378-138">このメソッドにより、アプリをタスク バーにピン留めするかどうかの確認を求めるダイアログがユーザーに表示されます。</span><span class="sxs-lookup"><span data-stu-id="0b378-138">This method displays a dialog that asks the user to confirm that they want your app pinned to the taskbar.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="0b378-139">これは、フォアグラウンド UI スレッドから呼び出す必要があります。それ以外の場合は例外がスローされます。</span><span class="sxs-lookup"><span data-stu-id="0b378-139">This must be called from a foreground UI thread, otherwise an exception will be thrown.</span></span>

```csharp
// Request to be pinned to the taskbar
bool isPinned = await TaskbarManager.GetDefault().RequestPinCurrentAppAsync();
```

![ピン留めのダイアログ](images/taskbar/pin-dialog.png)

<span data-ttu-id="0b378-141">このメソッドは、アプリがタスク バーにピン留めされたかどうかを示す、ブール値を返します。</span><span class="sxs-lookup"><span data-stu-id="0b378-141">This method returns a boolean value that indicates whether your app is now pinned to the taskbar.</span></span> <span data-ttu-id="0b378-142">アプリが既にピン留めされている場合は、このメソッドは、ユーザーにダイアログを表示せずに、すぐに true を返します。</span><span class="sxs-lookup"><span data-stu-id="0b378-142">If your app was already pinned, the method immediately returns true without showing the dialog to the user.</span></span> <span data-ttu-id="0b378-143">ユーザーがダイアログで [いいえ] をクリックしたか、アプリをタスク バーにピン留めすることが許可されていない場合、メソッドは false を返します。</span><span class="sxs-lookup"><span data-stu-id="0b378-143">If the user clicks "no" on the dialog, or pinning your app to the taskbar isn't allowed, the method returns false.</span></span> <span data-ttu-id="0b378-144">ユーザーが [はい] をクリックすると、アプリがピン留めされ、API から true が返されます。</span><span class="sxs-lookup"><span data-stu-id="0b378-144">Otherwise, the user clicked yes and the app was pinned, and the API will return true.</span></span>


## <a name="resources"></a><span data-ttu-id="0b378-145">リソース</span><span class="sxs-lookup"><span data-stu-id="0b378-145">Resources</span></span>

* [<span data-ttu-id="0b378-146">GitHub での完全なコード サンプル</span><span class="sxs-lookup"><span data-stu-id="0b378-146">Full code sample on GitHub</span></span>](https://github.com/WindowsNotifications/quickstart-pin-to-taskbar)
* [<span data-ttu-id="0b378-147">TaskbarManager クラス</span><span class="sxs-lookup"><span data-stu-id="0b378-147">TaskbarManager class</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager)
* [<span data-ttu-id="0b378-148">スタート メニューにアプリをピン留めする</span><span class="sxs-lookup"><span data-stu-id="0b378-148">Pin an app to the Start menu</span></span>](tiles-and-notifications/primary-tile-apis.md)