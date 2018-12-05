---
title: バック グラウンドでファイル システムの変更を追跡します。
description: システムで、ユーザーが移動すると、ファイルの変更や、バック グラウンドでのフォルダーを追跡する方法について説明します。
ms.date: 11/20/2018
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: e90692753924572a932767b9c188ed6d24f94593
ms.sourcegitcommit: c01c29cd97f1cbf050950526e18e15823b6a12a0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/05/2018
ms.locfileid: "8701864"
---
# <a name="track-file-system-changes-in-the-background"></a><span data-ttu-id="d2f00-104">バック グラウンドでファイル システムの変更を追跡します。</span><span class="sxs-lookup"><span data-stu-id="d2f00-104">Track file system changes in the background</span></span>

<span data-ttu-id="d2f00-105">[StorageLibraryChangeTracker](https://docs.microsoft.com/uwp/api/Windows.Storage.StorageLibraryChangeTracker)クラスには、システムで、ユーザーが移動すると、ファイルやフォルダーに変更を追跡するアプリができます。</span><span class="sxs-lookup"><span data-stu-id="d2f00-105">The [StorageLibraryChangeTracker](https://docs.microsoft.com/uwp/api/Windows.Storage.StorageLibraryChangeTracker) class allows apps to track changes in files and folders as users move them around the system.</span></span> <span data-ttu-id="d2f00-106">**StorageLibraryChangeTracker**クラスを使用して、アプリを追跡できます。</span><span class="sxs-lookup"><span data-stu-id="d2f00-106">Using the **StorageLibraryChangeTracker** class, an app can track:</span></span>

- <span data-ttu-id="d2f00-107">ファイル操作などの追加、削除、変更します。</span><span class="sxs-lookup"><span data-stu-id="d2f00-107">File operations including add, delete, modify.</span></span>
- <span data-ttu-id="d2f00-108">名前の変更や削除などの操作をフォルダーです。</span><span class="sxs-lookup"><span data-stu-id="d2f00-108">Folder operations such as renames and deletes.</span></span>
- <span data-ttu-id="d2f00-109">ファイルやフォルダー、ドライブに移動します。</span><span class="sxs-lookup"><span data-stu-id="d2f00-109">Files and folders moving on the drive.</span></span>

<span data-ttu-id="d2f00-110">変更トラッカーを管理するためのプログラミング モデルについて説明します、いくつかのサンプル コードを表示および**StorageLibraryChangeTracker**で管理されるファイル操作の種類を理解するには、このガイドを使用します。</span><span class="sxs-lookup"><span data-stu-id="d2f00-110">Use this guide to learn the programing model for working with the change tracker, view some sample code, and understand the different types of file operations that are tracked by **StorageLibraryChangeTracker**.</span></span>

<span data-ttu-id="d2f00-111">**StorageLibraryChangeTracker**は、ユーザーのライブラリ、または任意のフォルダーをローカル コンピューターで動作します。</span><span class="sxs-lookup"><span data-stu-id="d2f00-111">**StorageLibraryChangeTracker** works for user libraries, or for any folder on the local machine.</span></span> <span data-ttu-id="d2f00-112">これにより、セカンダリ ドライブやリムーバブル ドライブが含まれていますが、NAS ドライブやネットワーク ドライブには含まれません。</span><span class="sxs-lookup"><span data-stu-id="d2f00-112">This includes secondary drives or removable drives but does not include NAS drives or network drives.</span></span>

## <a name="using-the-change-tracker"></a><span data-ttu-id="d2f00-113">変更の追跡ツールを使用します。</span><span class="sxs-lookup"><span data-stu-id="d2f00-113">Using the change tracker</span></span>

<span data-ttu-id="d2f00-114">変更トラッカーは、システムで最後の*n 個*のファイル システム操作を格納する循環バッファーとして実装されます。</span><span class="sxs-lookup"><span data-stu-id="d2f00-114">The change tracker is implemented on system as a circular buffer storing the last *N* file system operations.</span></span> <span data-ttu-id="d2f00-115">アプリは、バッファーからの変更を読み取るし、独自のエクスペリエンスにそれらを処理することができます。</span><span class="sxs-lookup"><span data-stu-id="d2f00-115">Apps are able to read the changes off of the buffer and then process them into their own experiences.</span></span> <span data-ttu-id="d2f00-116">アプリが終了する処理の変更をマークすることはありませんが、変更をもう一度表示します。</span><span class="sxs-lookup"><span data-stu-id="d2f00-116">Once the app is finished with the changes it marks the changes as processed and will never see them again.</span></span>

<span data-ttu-id="d2f00-117">フォルダーの変更の追跡ツールを使用するには、次の手順に従います。</span><span class="sxs-lookup"><span data-stu-id="d2f00-117">To use the change tracker on a folder, follow these steps:</span></span>

1. <span data-ttu-id="d2f00-118">変更のフォルダーの追跡を有効にします。</span><span class="sxs-lookup"><span data-stu-id="d2f00-118">Enable change tracking for the folder.</span></span>
2. <span data-ttu-id="d2f00-119">変更を待ちます。</span><span class="sxs-lookup"><span data-stu-id="d2f00-119">Wait for changes.</span></span>
3. <span data-ttu-id="d2f00-120">読み取りを変更します。</span><span class="sxs-lookup"><span data-stu-id="d2f00-120">Read changes.</span></span>
4. <span data-ttu-id="d2f00-121">変更を受け入れます。</span><span class="sxs-lookup"><span data-stu-id="d2f00-121">Accept changes.</span></span>

<span data-ttu-id="d2f00-122">次のセクションでは、これらのコード例をいくつかの手順を説明します。</span><span class="sxs-lookup"><span data-stu-id="d2f00-122">The next sections walk through each of the steps with some code examples.</span></span> <span data-ttu-id="d2f00-123">完全なコード サンプルは、記事の最後に提供されます。</span><span class="sxs-lookup"><span data-stu-id="d2f00-123">The complete code sample is provided at the end of the article.</span></span>

### <a name="enable-the-change-tracker"></a><span data-ttu-id="d2f00-124">変更の追跡ツールを有効にします。</span><span class="sxs-lookup"><span data-stu-id="d2f00-124">Enable the change tracker</span></span>

<span data-ttu-id="d2f00-125">まず、アプリが実行する必要がある変更の指定されたライブラリの追跡を求めていることをシステムに指示することです。</span><span class="sxs-lookup"><span data-stu-id="d2f00-125">The first thing that the app needs to do is to tell the system that it is interested in change tracking a given library.</span></span> <span data-ttu-id="d2f00-126">これは、関心のあるライブラリの変更トラッカーで[有効にする](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrarychangetracker.enable)メソッドを呼び出すことで実行します。</span><span class="sxs-lookup"><span data-stu-id="d2f00-126">It does this by calling the [Enable](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrarychangetracker.enable) method on the change tracker for the library of interest.</span></span>

```csharp
StorageLibrary videosLib = await StorageLibrary.GetLibraryAsync(KnownLibraryId.Videos);
StorageLibraryChangeTracker videoTracker = videosLib.ChangeTracker;
videoTracker.Enable();
```

<span data-ttu-id="d2f00-127">いくつかの重要な注意事項:</span><span class="sxs-lookup"><span data-stu-id="d2f00-127">A few important notes:</span></span>

- <span data-ttu-id="d2f00-128">アプリでは、マニフェストに適切なライブラリにアクセス許可を持つ[StorageLibrary](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrary)オブジェクトを作成する前に確認します。</span><span class="sxs-lookup"><span data-stu-id="d2f00-128">Make sure your app has permission to the correct library in the manifest before creating the [StorageLibrary](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrary) object.</span></span> <span data-ttu-id="d2f00-129">詳細については、[ファイルへのアクセス許可](https://docs.microsoft.com/en-us/windows/uwp/files/file-access-permissions)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="d2f00-129">See [File Access Permissions](https://docs.microsoft.com/en-us/windows/uwp/files/file-access-permissions) for more details.</span></span>
- <span data-ttu-id="d2f00-130">[有効にする](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrarychangetracker.enable)スレッド セーフ、ポインターを使用してリセットされませんおよびとして (詳細については後でこの) して、何回呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="d2f00-130">[Enable](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrarychangetracker.enable) is thread safe, will not reset your pointer, and can be called as many times as you like (more on this later).</span></span>

![空の変更の追跡ツールを有効にします。](images/changetracker-enable.png)

### <a name="wait-for-changes"></a><span data-ttu-id="d2f00-132">変更を待つ</span><span class="sxs-lookup"><span data-stu-id="d2f00-132">Wait for changes</span></span>

<span data-ttu-id="d2f00-133">変更トラッカーは、初期化した後は、すべてのアプリが実行されている場合でも、ライブラリ内に発生する操作の記録が開始されます。</span><span class="sxs-lookup"><span data-stu-id="d2f00-133">After the change tracker is initialized, it will begin to record all of the operations that occur within a library, even while the app isn’t running.</span></span> <span data-ttu-id="d2f00-134">アプリは、 [StorageLibraryChangedTrigger](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Background.StorageLibraryContentChangedTrigger)イベントに登録することにより、変更はいつでもアクティブ化を登録できます。</span><span class="sxs-lookup"><span data-stu-id="d2f00-134">Apps can register to be activated any time there is a change by registering for the [StorageLibraryChangedTrigger](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Background.StorageLibraryContentChangedTrigger) event.</span></span>

![変更を読むためにアプリを変更トラッカーに追加します。](images/changetracker-waiting.png)

### <a name="read-the-changes"></a><span data-ttu-id="d2f00-136">変更内容を読み取る</span><span class="sxs-lookup"><span data-stu-id="d2f00-136">Read the changes</span></span>

<span data-ttu-id="d2f00-137">アプリの変更トラッカーから変更をポーリングし、前回チェックして、変更の一覧が表示します。</span><span class="sxs-lookup"><span data-stu-id="d2f00-137">The app can then poll for changes from the change tracker and receive a list of the changes since the last time it checked.</span></span> <span data-ttu-id="d2f00-138">次のコードは、変更トラッカーから変更の一覧を取得する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="d2f00-138">The code below shows how to get a list of changes from the change tracker.</span></span>

```csharp
StorageLibrary videosLibrary = await StorageLibrary.GetLibraryAsync(KnownLibraryId.Videos);
videosLibrary.ChangeTracker.Enable();
StorageLibraryChangeReader videoChangeReader = videosLibrary.ChangeTracker.GetChangeReader();
IReadOnlyList changeSet = await changeReader.ReadBatchAsync();
```

<span data-ttu-id="d2f00-139">アプリはし、独自のエクスペリエンスまたは必要に応じて、データベースに変更を処理します。</span><span class="sxs-lookup"><span data-stu-id="d2f00-139">The app is then responsible for processing the changes into its own experience or database as needed.</span></span>

![アプリのデータベースに変更トラッカーからの変更内容の読み取り](images/changetracker-reading.png)

> [!TIP]
> <span data-ttu-id="d2f00-141">ユーザーは、アプリは、変更内容の読み取り中に、ライブラリを別のフォルダーを追加する場合、競合状態から防御する 2 番目の呼び出しを有効にすることです。</span><span class="sxs-lookup"><span data-stu-id="d2f00-141">The second call to enable is to defend against a race condition if the user adds another folder to the library while your app is reading changes.</span></span> <span data-ttu-id="d2f00-142">余分な呼び出しを**有効に**することがなく、コードは失敗します ecSearchFolderScopeViolation (0x80070490) と、ユーザーが、ライブラリ内のフォルダーを変更する場合</span><span class="sxs-lookup"><span data-stu-id="d2f00-142">Without the extra call to **Enable** the code will fail with ecSearchFolderScopeViolation (0x80070490) if the user is changing the folders in their library</span></span>

### <a name="accept-the-changes"></a><span data-ttu-id="d2f00-143">変更を確定します。</span><span class="sxs-lookup"><span data-stu-id="d2f00-143">Accept the changes</span></span>

<span data-ttu-id="d2f00-144">アプリが完了したら、変更を処理するにする必要があります、システムに指示[AcceptChangesAsync](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrarychangereader.acceptchangesasync)メソッドを呼び出すことによってこれらの変更をもう一度表示されることはありません。</span><span class="sxs-lookup"><span data-stu-id="d2f00-144">After the app is done processing the changes, it should tell the system to never show those changes again by calling the [AcceptChangesAsync](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrarychangereader.acceptchangesasync) method.</span></span>

```csharp
await changeReader.AcceptChangesAsync();
```

![読み込まれるため、もう一度表示することはそれらの変更としてマークすること](images/changetracker-accepting.png)

<span data-ttu-id="d2f00-146">アプリは今すぐだけ受け取ります新しい変更、今後変更トラッカーを読み取るとき。</span><span class="sxs-lookup"><span data-stu-id="d2f00-146">The app will now only receive new changes when reading the change tracker in the future.</span></span>

- <span data-ttu-id="d2f00-147">ポインターになります[ReadBatchAsync](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrarychangereader.readbatchasync)と[AcceptChangesAsync](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrarychangereader.acceptchangesasync)呼び出しの間で、変更が発生している場合のみが高度な検出が、アプリの最新の変更をします。</span><span class="sxs-lookup"><span data-stu-id="d2f00-147">If changes have happened between calling [ReadBatchAsync](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrarychangereader.readbatchasync) and [AcceptChangesAsync](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrarychangereader.acceptchangesasync), the pointer will be only be advanced to the most recent change the app has seen.</span></span> <span data-ttu-id="d2f00-148">その他の変更も利用できます、次回**ReadBatchAsync**を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="d2f00-148">Those other changes will still be available the next time it calls **ReadBatchAsync**.</span></span>
- <span data-ttu-id="d2f00-149">いない変更を受け入れると、次に、アプリが**ReadBatchAsync**を呼び出すのと同じ一連の変更を返すために、システムが発生します。</span><span class="sxs-lookup"><span data-stu-id="d2f00-149">Not accepting the changes will cause the system to return the same set of changes the next time the app calls **ReadBatchAsync**.</span></span>

## <a name="important-things-to-remember"></a><span data-ttu-id="d2f00-150">重要な注意事項</span><span class="sxs-lookup"><span data-stu-id="d2f00-150">Important things to remember</span></span>

<span data-ttu-id="d2f00-151">変更の追跡ツールを使用する場合は、すべてが正しく動作するかどうかを確認する点に注意する必要がありますが、いくつかの点があります。</span><span class="sxs-lookup"><span data-stu-id="d2f00-151">When using the change tracker, there are a few things that you should keep in mind to make sure that everything is working correctly.</span></span>

### <a name="buffer-overruns"></a><span data-ttu-id="d2f00-152">バッファー オーバーラン</span><span class="sxs-lookup"><span data-stu-id="d2f00-152">Buffer overruns</span></span>

<span data-ttu-id="d2f00-153">アプリが読み取ることができるまで、システムで発生するすべての操作を保持するために変更トラッカーで十分な空き領域を予約するようにして、循環バッファーがそれ自体を上書きする前に、アプリでの変更に読み取りしませんシナリオを想像する非常に簡単です。</span><span class="sxs-lookup"><span data-stu-id="d2f00-153">Although we try to reserve enough space in the change tracker to hold all the operations happening on the system until your app can read them, it is very easy to imagine a scenario where the app doesn’t read the changes before the circular buffer overwrites itself.</span></span> <span data-ttu-id="d2f00-154">特に場合、ユーザーがデータをバックアップから復元またはカメラ電話から画像の大規模なコレクションを同期します。</span><span class="sxs-lookup"><span data-stu-id="d2f00-154">Especially if the user is restoring data from a backup or syncing a large collection of pictures from their camera phone.</span></span>

<span data-ttu-id="d2f00-155">この例では、 **ReadBatchAsync**は[StorageLibraryChangeType.ChangeTrackingLost](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrarychangetype)のエラー コードを返します。</span><span class="sxs-lookup"><span data-stu-id="d2f00-155">In this case, **ReadBatchAsync** will return the error code [StorageLibraryChangeType.ChangeTrackingLost](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrarychangetype).</span></span> <span data-ttu-id="d2f00-156">アプリでは、このエラー コードを受信する場合は、次の点が考えられます。</span><span class="sxs-lookup"><span data-stu-id="d2f00-156">If your app receives this error code, it means a couple things:</span></span>

* <span data-ttu-id="d2f00-157">バッファーが上書きされて自体前回ことについて説明しました。</span><span class="sxs-lookup"><span data-stu-id="d2f00-157">The buffer has overwritten itself since the last time you looked at it.</span></span> <span data-ttu-id="d2f00-158">トラッカーからの情報は完全になるため、ライブラリを再クロールする最善のことです。</span><span class="sxs-lookup"><span data-stu-id="d2f00-158">The best course of action is to recrawl the library, because any information from the tracker will be incomplete.</span></span>
* <span data-ttu-id="d2f00-159">[リセット](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrarychangetracker.reset)を呼び出すまで変更トラッカーは、複数の変更を返しません。</span><span class="sxs-lookup"><span data-stu-id="d2f00-159">The change tracker will not return any more changes until you call [Reset](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrarychangetracker.reset).</span></span> <span data-ttu-id="d2f00-160">アプリは、リセットの呼び出し後、ポインターが、最新の変更に移動し、追跡が正常に再開されます。</span><span class="sxs-lookup"><span data-stu-id="d2f00-160">After the app calls reset, the pointer will be moved to the most recent change and tracking will resume normally.</span></span>

<span data-ttu-id="d2f00-161">このような場合は、取得するまれな場合がありますが、ユーザーが多数の周囲、ディスク上のファイルを移動はのシナリオでしますたく変更トラッカーは吹き出しし、多すぎると記憶域を占有します。</span><span class="sxs-lookup"><span data-stu-id="d2f00-161">It should be rare to get these cases, but in scenarios where the user is moving a large number of files around on their disk we don’t want the change tracker to balloon and take up too much storage.</span></span> <span data-ttu-id="d2f00-162">これにより、windows カスタマー エクスペリエンスをつけていないときに大規模なファイル システム操作に応答するようにアプリする必要があります。</span><span class="sxs-lookup"><span data-stu-id="d2f00-162">This should allow apps to react to massive file system operations while not damaging the customer experience in Windows.</span></span>

### <a name="changes-to-a-storagelibrary"></a><span data-ttu-id="d2f00-163">StorageLibrary への変更</span><span class="sxs-lookup"><span data-stu-id="d2f00-163">Changes to a StorageLibrary</span></span>

<span data-ttu-id="d2f00-164">[StorageLibrary](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrary)クラスは、他のフォルダーが含まれるルート フォルダーの仮想グループとして存在します。</span><span class="sxs-lookup"><span data-stu-id="d2f00-164">The [StorageLibrary](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrary) class exists as a virtual group of root folders that contain other folders.</span></span> <span data-ttu-id="d2f00-165">これの調整ファイル システムの変更の追跡で、次の選択肢を確認しました。</span><span class="sxs-lookup"><span data-stu-id="d2f00-165">To reconcile this with a file system change tracker, we made the following choices:</span></span>

- <span data-ttu-id="d2f00-166">ルート ライブラリ フォルダーの子孫に変更を加えた変更トラッカーで表されます。</span><span class="sxs-lookup"><span data-stu-id="d2f00-166">Any changes to descendent of the root library folders will be represented in the change tracker.</span></span> <span data-ttu-id="d2f00-167">[フォルダー](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrary.folders)のプロパティを使って、ルートのライブラリのフォルダーを参照してください。</span><span class="sxs-lookup"><span data-stu-id="d2f00-167">The root library folders can be found using the [Folders](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrary.folders) property.</span></span>
- <span data-ttu-id="d2f00-168">追加または削除するルート フォルダー ( [RequestAddFolderAsync](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrary.requestaddfolderasync)と[RequestRemoveFolderAsync](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrary.requestremovefolderasync)) を通じて**StorageLibrary**では、変更トラッカーのエントリを作成はできません。</span><span class="sxs-lookup"><span data-stu-id="d2f00-168">Adding or removing root folders from a **StorageLibrary** (through [RequestAddFolderAsync](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrary.requestaddfolderasync) and [RequestRemoveFolderAsync](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrary.requestremovefolderasync)) will not create an entry in the change tracker.</span></span> <span data-ttu-id="d2f00-169">[DefinitionChanged](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrary.definitionchanged)イベントを通じて、または[フォルダー](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrary.folders)のプロパティを使って、ライブラリ内のルート フォルダーを列挙することにより、これらの変更を追跡できます。</span><span class="sxs-lookup"><span data-stu-id="d2f00-169">These changes can be tracked through the [DefinitionChanged](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrary.definitionchanged) event or by enumerating the root folders in the library using the [Folders](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrary.folders) property.</span></span>
- <span data-ttu-id="d2f00-170">既にコンテンツを持つフォルダーをライブラリに追加する場合がありますされません変更通知または変更のトラッカー エントリが生成されます。</span><span class="sxs-lookup"><span data-stu-id="d2f00-170">If a folder with content already in it is added to the library, there will not be a change notification or change tracker entries generated.</span></span> <span data-ttu-id="d2f00-171">その後に変更をそのフォルダーの子孫は通知を生成し、トラッカーのエントリを変更します。</span><span class="sxs-lookup"><span data-stu-id="d2f00-171">Any subsequent changes to the descendants of that folder will generate notifications and change tracker entries.</span></span>

### <a name="calling-the-enable-method"></a><span data-ttu-id="d2f00-172">有効にするメソッドを呼び出す</span><span class="sxs-lookup"><span data-stu-id="d2f00-172">Calling the Enable method</span></span>

<span data-ttu-id="d2f00-173">ファイル システムの追跡を開始するとすぐに、変更がすべて列挙する前に、[有効にする](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrarychangetracker.enable)が、アプリに呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="d2f00-173">Apps should call [Enable](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrarychangetracker.enable) as soon as they start tracking the file system and before every enumeration of the changes.</span></span> <span data-ttu-id="d2f00-174">これによりすべての変更は、変更トラッカーによって取得されます。</span><span class="sxs-lookup"><span data-stu-id="d2f00-174">This will ensure that all changes will be captured by the change tracker.</span></span>  

## <a name="putting-it-together"></a><span data-ttu-id="d2f00-175">これをまとめる</span><span class="sxs-lookup"><span data-stu-id="d2f00-175">Putting it together</span></span>

<span data-ttu-id="d2f00-176">ビデオ ライブラリからの変更を登録し、変更トラッカーからの変更のプルを開始するために使用するすべてのコードを次に示します。</span><span class="sxs-lookup"><span data-stu-id="d2f00-176">Here is all the code that is used to register for the changes from the video library and start pulling the changes from the change tracker.</span></span>

```csharp
private async void EnableChangeTracker()
{
    StorageLibrary videosLib = await StorageLibrary.GetLibraryAsync(KnownLibraryId.Videos);
    StorageLibraryChangeTracker videoTracker = videosLib.ChangeTracker;
    videoTracker.Enable();
}

private async void GetChanges()
{
    StorageLibrary videosLibrary = await StorageLibrary.GetLibraryAsync(KnownLibraryId.Videos);
    videosLibrary.ChangeTracker.Enable();
    StorageLibraryChangeReader videoChangeReader = videosLibrary.ChangeTracker.GetChangeReader();
    IReadOnlyList changeSet = await changeReader.ReadBatchAsync();


    //Below this line is for the blog post. Above the line is for the magazine
    foreach (StorageLibraryChange change in changeSet)
    {
        if (change.ChangeType == StorageLibraryChangeType.ChangeTrackingLost)
        {
            //We are in trouble. Nothing else is going to be valid.
            log("Resetting the change tracker");
            videosLibrary.ChangeTracker.Reset();
            return;
        }
        if (change.IsOfType(StorageItemTypes.Folder))
        {
            await HandleFileChange(change);
        }
        else if (change.IsOfType(StorageItemTypes.File))
        {
            await HandleFolderChange(change);
        }
        else if (change.IsOfType(StorageItemTypes.None))
        {
            if (change.ChangeType == StorageLibraryChangeType.Deleted)
            {
                RemoveItemFromDB(change.Path);
            }
        }
    }
    await changeReader.AcceptChangesAsync();
}
```
