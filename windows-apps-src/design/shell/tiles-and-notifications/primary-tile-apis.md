---
author: andrewleader
Description: You can programmatically pin your own app's primary tile to Start, just like you can pin secondary tiles. And you can check whether it's currently pinned.
title: プライマリ タイル API
label: Primary tile API's
template: detail.hbs
ms.author: wdg-dev-content
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, StartScreenManager, プライマリ タイルをピン留めする, プライマリ タイル API, タイルのピン留めの確認, ライブ タイル
ms.localizationpriority: medium
ms.openlocfilehash: 42b4c014dfd49c42497b8846e37e37af53cc3885
ms.sourcegitcommit: f5321b525034e2b3af202709e9b942ad5557e193
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/18/2018
ms.locfileid: "4022794"
---
# <a name="primary-tile-apis"></a><span data-ttu-id="8661f-103">プライマリ タイル API</span><span class="sxs-lookup"><span data-stu-id="8661f-103">Primary tile APIs</span></span>
 

<span data-ttu-id="8661f-104">プライマリ タイル API を使うと、スタートにアプリが現在ピン留めされているかどうかを確認して、アプリのプライマリ タイルのピン留めを要求できます。</span><span class="sxs-lookup"><span data-stu-id="8661f-104">Primary tile APIs let you check whether your app is currently pinned to Start, and request to pin your app's primary tile.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="8661f-105">**Creators Update が必要**: プライマリ タイル API を使用するには、SDK 15063 以降をターゲットとし、ビルド 15063 以降を実行している必要があります。</span><span class="sxs-lookup"><span data-stu-id="8661f-105">**Requires Creators Update**: You must target SDK 15063 and be running build 15063 or higher to use the primary tile APIs.</span></span>

> <span data-ttu-id="8661f-106">**重要な API**: [**StartScreenManager クラス**](https://docs.microsoft.com/uwp/api/windows.ui.startscreen.startscreenmanager)、[ContainsAppListEntryAsync](https://docs.microsoft.com/uwp/api/windows.ui.startscreen.startscreenmanager#Windows_UI_StartScreen_StartScreenManager_ContainsAppListEntryAsync_Windows_ApplicationModel_Core_AppListEntry_)、[RequestAddAppListEntryAsync](https://docs.microsoft.com/uwp/api/windows.ui.startscreen.startscreenmanager#Windows_UI_StartScreen_StartScreenManager_RequestAddAppListEntryAsync_Windows_ApplicationModel_Core_AppListEntry_)</span><span class="sxs-lookup"><span data-stu-id="8661f-106">**Important APIs**: [**StartScreenManager class**](https://docs.microsoft.com/uwp/api/windows.ui.startscreen.startscreenmanager), [ContainsAppListEntryAsync](https://docs.microsoft.com/uwp/api/windows.ui.startscreen.startscreenmanager#Windows_UI_StartScreen_StartScreenManager_ContainsAppListEntryAsync_Windows_ApplicationModel_Core_AppListEntry_), [RequestAddAppListEntryAsync](https://docs.microsoft.com/uwp/api/windows.ui.startscreen.startscreenmanager#Windows_UI_StartScreen_StartScreenManager_RequestAddAppListEntryAsync_Windows_ApplicationModel_Core_AppListEntry_)</span></span>


## <a name="when-to-use-primary-tile-apis"></a><span data-ttu-id="8661f-107">プライマリ タイル API を使う状況</span><span class="sxs-lookup"><span data-stu-id="8661f-107">When to use primary tile APIs</span></span>

<span data-ttu-id="8661f-108">アプリのプライマリ タイルに対する優れたエクスペリエンスの設計に多くの労力をかけたので、アプリのプライマリ タイルをスタート画面にピン留めするようユーザーに要求できるようになりました。</span><span class="sxs-lookup"><span data-stu-id="8661f-108">You put a lot of effort into designing a great experience for your app’s primary tile, and now you have the opportunity to ask the user to pin it to Start.</span></span> <span data-ttu-id="8661f-109">ただし、コードについて詳しく説明する前に、エクスペリエンスを設計するときの注意点を示します。</span><span class="sxs-lookup"><span data-stu-id="8661f-109">But before we dive into the code, here are some things to keep in mind as you’re designing your experience:</span></span>

* <span data-ttu-id="8661f-110">アプリに "ライブ タイルのピン留め" を実行するよう明確に呼びかける、スムーズで簡単に無視できる UX を作成すること。\*\*\*\*</span><span class="sxs-lookup"><span data-stu-id="8661f-110">**Do** craft a non-disruptive and easily dismissible UX in your app with a clear "Pin Live Tile" call to action.</span></span>
* <span data-ttu-id="8661f-111">アプリのライブ タイルをピン留めするようユーザーに要求する前に、アプリのライブ タイルの価値について明確に説明すること。\*\*\*\*</span><span class="sxs-lookup"><span data-stu-id="8661f-111">**Do** clearly explain the value of your app’s Live Tile before asking the user to pin it.</span></span>
* <span data-ttu-id="8661f-112">タイルが既にピン留めされているか、デバイスでピン留めがサポートされていない場合、アプリのタイルをピン留めするようユーザーに要求しないこと (詳しくは後で説明します)。\*\*\*\*</span><span class="sxs-lookup"><span data-stu-id="8661f-112">**Don't** ask a user to pin your app’s tile if the tile is already pinned or the device doesn’t support it (more info follows).</span></span>
* <span data-ttu-id="8661f-113">アプリのタイルをピン留めするようユーザーに繰り返し要求しないこと (ユーザーが不快になる恐れがあります)。\*\*\*\*</span><span class="sxs-lookup"><span data-stu-id="8661f-113">**Don't** repeatedly ask the user to pin your app’s tile (they will probably get annoyed).</span></span>
* <span data-ttu-id="8661f-114">明示的なユーザー操作を必要としない場合や、アプリが最小化されているか開いていないときに、ピン留めの API を呼び出さないこと。\*\*\*\*</span><span class="sxs-lookup"><span data-stu-id="8661f-114">**Don't** call the pin API without explicit user interaction or when your app is minimized/not open.</span></span>


## <a name="checking-whether-the-apis-exist"></a><span data-ttu-id="8661f-115">API が存在するかどうかを確認する</span><span class="sxs-lookup"><span data-stu-id="8661f-115">Checking whether the API's exist</span></span>

<span data-ttu-id="8661f-116">アプリで Windows 10 の以前のバージョンをサポートする場合は、プライマリ タイル API が利用できるかどうかを確認する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8661f-116">If your app supports older versions of Windows 10, you need to check whether these primary tile APIs are available.</span></span> <span data-ttu-id="8661f-117">これを行うには、ApiInformation を使います。</span><span class="sxs-lookup"><span data-stu-id="8661f-117">You do this by using ApiInformation.</span></span> <span data-ttu-id="8661f-118">プライマリ タイル API を利用できない場合は、API への呼び出しを実行しないでください。</span><span class="sxs-lookup"><span data-stu-id="8661f-118">If the primary tile APIs aren't available, avoid executing any calls to the APIs.</span></span>

```csharp
if (ApiInformation.IsTypePresent("Windows.UI.StartScreen.StartScreenManager"))
{
    // Primary tile API's supported!
}
else
{
    // Older version of Windows, no primary tile API's
}
```


## <a name="check-if-start-supports-your-app"></a><span data-ttu-id="8661f-119">スタート画面がアプリをサポートしているかどうかを確認する</span><span class="sxs-lookup"><span data-stu-id="8661f-119">Check if Start supports your app</span></span>

<span data-ttu-id="8661f-120">現在のスタート メニューとアプリの種類によっては、現在のスタート画面にアプリをピン留めすることがサポートされていない場合があります。</span><span class="sxs-lookup"><span data-stu-id="8661f-120">Depending on the current Start menu, and your type of app, pinning your app to the current Start screen might not be supported.</span></span> <span data-ttu-id="8661f-121">プライマリ タイルをスタート画面にピン留めできるのは、Desktop と Mobile だけです。</span><span class="sxs-lookup"><span data-stu-id="8661f-121">Only Desktop and Mobile support pinning the primary tile to Start.</span></span> <span data-ttu-id="8661f-122">そのため、ピンの UI を表示またはピン コードを実行する前に、まずはアプリが現在のスタート画面でサポートされているかどうかを確認する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8661f-122">Therefore, before showing any pin UI or executing any pin code, you first need to check if your app is even supported for the current Start screen.</span></span> <span data-ttu-id="8661f-123">サポートされていない場合は、タイルをピン留めするよう求めるメッセージをユーザーに表示しないでください。</span><span class="sxs-lookup"><span data-stu-id="8661f-123">If it's not supported, don't prompt the user to pin the tile.</span></span>

```csharp
// Get your own app list entry
// (which is always the first app list entry assuming you are not a multi-app package)
AppListEntry entry = (await Package.Current.GetAppListEntriesAsync())[0];

// Check if Start supports your app
bool isSupported = StartScreenManager.GetDefault().SupportsAppListEntry(entry);
```


## <a name="check-whether-youre-currently-pinned"></a><span data-ttu-id="8661f-124">現在ピン留めされているかどうかを確認する</span><span class="sxs-lookup"><span data-stu-id="8661f-124">Check whether you're currently pinned</span></span>

<span data-ttu-id="8661f-125">プライマリ タイルが現在スタート画面にピン留めされているかどうかを調べるには、[ContainsAppListEntryAsync](https://docs.microsoft.com/uwp/api/windows.ui.startscreen.startscreenmanager#Windows_UI_StartScreen_StartScreenManager_ContainsAppListEntryAsync_Windows_ApplicationModel_Core_AppListEntry_) メソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="8661f-125">To find out if your primary tile is currently pinned to Start, use the [ContainsAppListEntryAsync](https://docs.microsoft.com/uwp/api/windows.ui.startscreen.startscreenmanager#Windows_UI_StartScreen_StartScreenManager_ContainsAppListEntryAsync_Windows_ApplicationModel_Core_AppListEntry_) method.</span></span>

```csharp
// Get your own app list entry
AppListEntry entry = (await Package.Current.GetAppListEntriesAsync())[0];

// Check if your app is currently pinned
bool isPinned = await StartScreenManager.GetDefault().ContainsAppListEntryAsync(entry);
```


##  <a name="pin-your-primary-tile"></a><span data-ttu-id="8661f-126">プライマリ タイルをピン留めする</span><span class="sxs-lookup"><span data-stu-id="8661f-126">Pin your primary tile</span></span>

<span data-ttu-id="8661f-127">プライマリ タイルが現在ピン留めされていなくて、タイルがスタート画面でサポートされている場合、プライマリ タイルをピン留めできることを伝えるヒントをユーザーに表示できます。</span><span class="sxs-lookup"><span data-stu-id="8661f-127">If your primary tile currently isn't pinned, and your tile is supported by Start, you might want to show a tip to users that they can pin your primary tile.</span></span>

> [!NOTE]
> <span data-ttu-id="8661f-128">アプリがフォアグラウンドにあるときに UI スレッドからこの API を呼び出す必要があります。また、この API を呼び出す必要があるのは、ユーザーが意図的にプライマリ タイルのピン留めを要求した後 (たとえば、ユーザーがタイルのピン留めについてのヒントで [はい] をクリックした後) だけです。</span><span class="sxs-lookup"><span data-stu-id="8661f-128">You must call this API from a UI thread while your app is in the foreground, and you should only call this API after the user has intentionally requested the primary tile be pinned (for example, after the user clicked yes to your tip about pinning the tile).</span></span>

<span data-ttu-id="8661f-129">ユーザーがプライマリ タイルをピン留めするボタンをクリックしたら、[RequestAddAppListEntryAsync](https://docs.microsoft.com/uwp/api/windows.ui.startscreen.startscreenmanager#Windows_UI_StartScreen_StartScreenManager_RequestAddAppListEntryAsync_Windows_ApplicationModel_Core_AppListEntry_) メソッドを呼び出して、タイルがスタート画面にピン留めされるよう要求します。</span><span class="sxs-lookup"><span data-stu-id="8661f-129">If the user clicks your button to pin the primary tile, you would then call the [RequestAddAppListEntryAsync](https://docs.microsoft.com/uwp/api/windows.ui.startscreen.startscreenmanager#Windows_UI_StartScreen_StartScreenManager_RequestAddAppListEntryAsync_Windows_ApplicationModel_Core_AppListEntry_) method to request that your tile be pinned to Start.</span></span> <span data-ttu-id="8661f-130">これにより、タイルをスタート画面にピン留めするかどうかの確認を求めるダイアログがユーザーに表示されます。</span><span class="sxs-lookup"><span data-stu-id="8661f-130">This will display a dialog asking the user to confirm that they want your tile pinned to Start.</span></span>

<span data-ttu-id="8661f-131">タイルがスタート画面にピン留めされたかどうかを表すブール値が返されます。</span><span class="sxs-lookup"><span data-stu-id="8661f-131">This will return a boolean representing whether your tile is now pinned to Start.</span></span> <span data-ttu-id="8661f-132">タイルが既にピン留めされている場合は、ユーザーにダイアログを表示せずに、すぐに true が返されます。</span><span class="sxs-lookup"><span data-stu-id="8661f-132">If your tile was already pinned, this will immediately return true without showing the dialog to the user.</span></span> <span data-ttu-id="8661f-133">ユーザーがダイアログで [いいえ] をクリックしたか、タイルをスタート画面にピン留めすることがサポートされていない場合、false が返されます。</span><span class="sxs-lookup"><span data-stu-id="8661f-133">If the user clicks no on the dialog, or pinning your tile to Start isn't supported, this will return false.</span></span> <span data-ttu-id="8661f-134">その他の場合は、ユーザーが [はい] をクリックしてタイルがピン留めされ、API から true が返されます。</span><span class="sxs-lookup"><span data-stu-id="8661f-134">Otherwise, the user clicked yes and the tile was pinned, and the API will return true.</span></span>

```csharp
// Get your own app list entry
AppListEntry entry = (await Package.Current.GetAppListEntriesAsync())[0];

// And pin it to Start
bool isPinned = await StartScreenManager.GetDefault().RequestAddAppListEntryAsync(entry);
```


## <a name="resources"></a><span data-ttu-id="8661f-135">リソース</span><span class="sxs-lookup"><span data-stu-id="8661f-135">Resources</span></span>

* [<span data-ttu-id="8661f-136">GitHub での完全なコード サンプル</span><span class="sxs-lookup"><span data-stu-id="8661f-136">Full code sample on GitHub</span></span>](https://github.com/WindowsNotifications/quickstart-pin-primary-tile)
* [<span data-ttu-id="8661f-137">タスク バーにピン留めする</span><span class="sxs-lookup"><span data-stu-id="8661f-137">Pin to taskbar</span></span>](../pin-to-taskbar.md)
* [<span data-ttu-id="8661f-138">タイル、バッジ、および通知</span><span class="sxs-lookup"><span data-stu-id="8661f-138">Tiles, badges, and notifications</span></span>](index.md)
* [<span data-ttu-id="8661f-139">アダプティブ タイルのドキュメント</span><span class="sxs-lookup"><span data-stu-id="8661f-139">Adaptive Tile Documentation</span></span>](create-adaptive-tiles.md)
