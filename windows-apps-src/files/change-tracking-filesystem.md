---
title: ファイル システムの変更のバック グラウンドでの追跡
description: システム内のユーザーを移動して、ファイルの変更と、バック グラウンドでフォルダーを追跡する方法について説明します。
ms.date: 12/19/2018
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: b0ec7762fd64f0f0b8de65faa1aaf079bdaba3a3
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57621577"
---
# <a name="track-file-system-changes-in-the-background"></a><span data-ttu-id="9ad27-104">ファイル システムの変更のバック グラウンドでの追跡</span><span class="sxs-lookup"><span data-stu-id="9ad27-104">Track file system changes in the background</span></span>

<span data-ttu-id="9ad27-105">**重要な API**</span><span class="sxs-lookup"><span data-stu-id="9ad27-105">**Important APIs**</span></span>

-   [<span data-ttu-id="9ad27-106">**StorageLibraryChangeTracker**</span><span class="sxs-lookup"><span data-stu-id="9ad27-106">**StorageLibraryChangeTracker**</span></span>](https://docs.microsoft.com/uwp/api/Windows.Storage.StorageLibraryChangeTracker)
-   [<span data-ttu-id="9ad27-107">**StorageLibraryChangeReader**</span><span class="sxs-lookup"><span data-stu-id="9ad27-107">**StorageLibraryChangeReader**</span></span>](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrarychangereader)
-   [<span data-ttu-id="9ad27-108">**StorageLibraryChangedTrigger**</span><span class="sxs-lookup"><span data-stu-id="9ad27-108">**StorageLibraryChangedTrigger**</span></span>](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Background.StorageLibraryContentChangedTrigger)
-   [<span data-ttu-id="9ad27-109">**StorageLibrary**</span><span class="sxs-lookup"><span data-stu-id="9ad27-109">**StorageLibrary**</span></span>](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrary)

<span data-ttu-id="9ad27-110">[ **StorageLibraryChangeTracker** ](https://docs.microsoft.com/uwp/api/Windows.Storage.StorageLibraryChangeTracker)クラスは、システム内のユーザーを移動して、ファイルとフォルダーの変更を追跡するためにアプリを使用できます。</span><span class="sxs-lookup"><span data-stu-id="9ad27-110">The [**StorageLibraryChangeTracker**](https://docs.microsoft.com/uwp/api/Windows.Storage.StorageLibraryChangeTracker) class allows apps to track changes in files and folders as users move them around the system.</span></span> <span data-ttu-id="9ad27-111">使用して、 **StorageLibraryChangeTracker**クラス、アプリを追跡できます。</span><span class="sxs-lookup"><span data-stu-id="9ad27-111">Using the **StorageLibraryChangeTracker** class, an app can track:</span></span>

- <span data-ttu-id="9ad27-112">ファイル操作などの追加、削除、変更します。</span><span class="sxs-lookup"><span data-stu-id="9ad27-112">File operations including add, delete, modify.</span></span>
- <span data-ttu-id="9ad27-113">名前変更や削除などのフォルダーの操作。</span><span class="sxs-lookup"><span data-stu-id="9ad27-113">Folder operations such as renames and deletes.</span></span>
- <span data-ttu-id="9ad27-114">ファイルとフォルダー、ドライブに移動します。</span><span class="sxs-lookup"><span data-stu-id="9ad27-114">Files and folders moving on the drive.</span></span>

<span data-ttu-id="9ad27-115">このガイドを使用して、変更トラッカーを操作するためのプログラミング モデルについて説明します、いくつかのサンプル コードを表示し、によって追跡されるファイルの操作の種類を理解する**StorageLibraryChangeTracker**します。</span><span class="sxs-lookup"><span data-stu-id="9ad27-115">Use this guide to learn the programing model for working with the change tracker, view some sample code, and understand the different types of file operations that are tracked by **StorageLibraryChangeTracker**.</span></span>

<span data-ttu-id="9ad27-116">**StorageLibraryChangeTracker**ユーザー ライブラリ、または任意のフォルダーをローカル コンピューターで動作します。</span><span class="sxs-lookup"><span data-stu-id="9ad27-116">**StorageLibraryChangeTracker** works for user libraries, or for any folder on the local machine.</span></span> <span data-ttu-id="9ad27-117">これにより、セカンダリのドライブまたはリムーバブル ドライブが含まれていますが、NAS のドライブまたはネットワーク ドライブは含まれません。</span><span class="sxs-lookup"><span data-stu-id="9ad27-117">This includes secondary drives or removable drives but does not include NAS drives or network drives.</span></span>

## <a name="using-the-change-tracker"></a><span data-ttu-id="9ad27-118">変更の追跡ツールを使用します。</span><span class="sxs-lookup"><span data-stu-id="9ad27-118">Using the change tracker</span></span>

<span data-ttu-id="9ad27-119">変更の追跡ツールは、最後に保存する循環バッファーとしてシステムに実装されて*N*ファイル システム操作。</span><span class="sxs-lookup"><span data-stu-id="9ad27-119">The change tracker is implemented on system as a circular buffer storing the last *N* file system operations.</span></span> <span data-ttu-id="9ad27-120">アプリは、バッファーからの変更を読み取るし、それらを独自の経験に処理できます。</span><span class="sxs-lookup"><span data-stu-id="9ad27-120">Apps are able to read the changes off of the buffer and then process them into their own experiences.</span></span> <span data-ttu-id="9ad27-121">アプリが処理されるときに、変更をマークされことはありませんが、変更を完了すると再び表示されます。</span><span class="sxs-lookup"><span data-stu-id="9ad27-121">Once the app is finished with the changes it marks the changes as processed and will never see them again.</span></span>

<span data-ttu-id="9ad27-122">フォルダーの変更の追跡ツールを使用するには、次の手順に従います。</span><span class="sxs-lookup"><span data-stu-id="9ad27-122">To use the change tracker on a folder, follow these steps:</span></span>

1. <span data-ttu-id="9ad27-123">フォルダーの変更の追跡を有効にします。</span><span class="sxs-lookup"><span data-stu-id="9ad27-123">Enable change tracking for the folder.</span></span>
2. <span data-ttu-id="9ad27-124">変更を待ちます。</span><span class="sxs-lookup"><span data-stu-id="9ad27-124">Wait for changes.</span></span>
3. <span data-ttu-id="9ad27-125">変更を読み取る。</span><span class="sxs-lookup"><span data-stu-id="9ad27-125">Read changes.</span></span>
4. <span data-ttu-id="9ad27-126">変更を受け入れます。</span><span class="sxs-lookup"><span data-stu-id="9ad27-126">Accept changes.</span></span>

<span data-ttu-id="9ad27-127">次のセクションでは、各コード例をいくつかの手順説明します。</span><span class="sxs-lookup"><span data-stu-id="9ad27-127">The next sections walk through each of the steps with some code examples.</span></span> <span data-ttu-id="9ad27-128">完全なコード サンプルは、この記事の最後で提供されます。</span><span class="sxs-lookup"><span data-stu-id="9ad27-128">The complete code sample is provided at the end of the article.</span></span>

### <a name="enable-the-change-tracker"></a><span data-ttu-id="9ad27-129">変更の追跡を有効にします。</span><span class="sxs-lookup"><span data-stu-id="9ad27-129">Enable the change tracker</span></span>

<span data-ttu-id="9ad27-130">変更の追跡、特定のライブラリを求めていることをシステムに通知する、アプリが実行する必要がある最初のことです。</span><span class="sxs-lookup"><span data-stu-id="9ad27-130">The first thing that the app needs to do is to tell the system that it is interested in change tracking a given library.</span></span> <span data-ttu-id="9ad27-131">これは、呼び出すことで、 [**を有効にする**](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrarychangetracker.enable)関心のあるライブラリの変更の追跡ツールのメソッド。</span><span class="sxs-lookup"><span data-stu-id="9ad27-131">It does this by calling the [**Enable**](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrarychangetracker.enable) method on the change tracker for the library of interest.</span></span>

```csharp
StorageLibrary videosLib = await StorageLibrary.GetLibraryAsync(KnownLibraryId.Videos);
StorageLibraryChangeTracker videoTracker = videosLib.ChangeTracker;
videoTracker.Enable();
```

<span data-ttu-id="9ad27-132">いくつかの重要な注意事項:</span><span class="sxs-lookup"><span data-stu-id="9ad27-132">A few important notes:</span></span>

- <span data-ttu-id="9ad27-133">アプリが、マニフェストで適切なライブラリを作成する前に権限を持っているかどうかを確認、 [ **StorageLibrary** ](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrary)オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="9ad27-133">Make sure your app has permission to the correct library in the manifest before creating the [**StorageLibrary**](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrary) object.</span></span> <span data-ttu-id="9ad27-134">参照してください[ファイル アクセス許可](https://docs.microsoft.com/en-us/windows/uwp/files/file-access-permissions)の詳細。</span><span class="sxs-lookup"><span data-stu-id="9ad27-134">See [File Access Permissions](https://docs.microsoft.com/en-us/windows/uwp/files/file-access-permissions) for more details.</span></span>
- <span data-ttu-id="9ad27-135">[**有効にする**](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrarychangetracker.enable)がスレッド セーフや、ポインターはリセットされません (これについては後で) 必要な回数だけ呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="9ad27-135">[**Enable**](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrarychangetracker.enable) is thread safe, will not reset your pointer, and can be called as many times as you like (more on this later).</span></span>

![空の変更の追跡ツールを有効にします。](images/changetracker-enable.png)

### <a name="wait-for-changes"></a><span data-ttu-id="9ad27-137">変更の待機</span><span class="sxs-lookup"><span data-stu-id="9ad27-137">Wait for changes</span></span>

<span data-ttu-id="9ad27-138">変更の追跡ツールが初期化された後は、すべてのアプリが実行されていないときにも、ライブラリ内に発生する操作を記録する開始されます。</span><span class="sxs-lookup"><span data-stu-id="9ad27-138">After the change tracker is initialized, it will begin to record all of the operations that occur within a library, even while the app isn’t running.</span></span> <span data-ttu-id="9ad27-139">登録することによって変更がある任意の時間をアクティブにするアプリを登録できます、 [ **StorageLibraryChangedTrigger** ](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Background.StorageLibraryContentChangedTrigger)イベント。</span><span class="sxs-lookup"><span data-stu-id="9ad27-139">Apps can register to be activated any time there is a change by registering for the [**StorageLibraryChangedTrigger**](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Background.StorageLibraryContentChangedTrigger) event.</span></span>

![アプリを読み取ることがなく変更トラッカーに追加される変更](images/changetracker-waiting.png)

### <a name="read-the-changes"></a><span data-ttu-id="9ad27-141">変更を読み取る</span><span class="sxs-lookup"><span data-stu-id="9ad27-141">Read the changes</span></span>

<span data-ttu-id="9ad27-142">アプリでは、変更の追跡ツールからの変更をポーリングし、し、最後にチェックしてから、変更の一覧を受信できます。</span><span class="sxs-lookup"><span data-stu-id="9ad27-142">The app can then poll for changes from the change tracker and receive a list of the changes since the last time it checked.</span></span> <span data-ttu-id="9ad27-143">次のコードでは、変更の追跡ツールからの変更の一覧を取得する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="9ad27-143">The code below shows how to get a list of changes from the change tracker.</span></span>

```csharp
StorageLibrary videosLibrary = await StorageLibrary.GetLibraryAsync(KnownLibraryId.Videos);
videosLibrary.ChangeTracker.Enable();
StorageLibraryChangeReader videoChangeReader = videosLibrary.ChangeTracker.GetChangeReader();
IReadOnlyList changeSet = await changeReader.ReadBatchAsync();
```

<span data-ttu-id="9ad27-144">アプリは、独自のエクスペリエンスまたは必要に応じて、データベースに変更の処理を担当し、</span><span class="sxs-lookup"><span data-stu-id="9ad27-144">The app is then responsible for processing the changes into its own experience or database as needed.</span></span>

![変更の追跡ツールから、アプリのデータベースへの変更の読み取り](images/changetracker-reading.png)

> [!TIP]
> <span data-ttu-id="9ad27-146">有効にする 2 つ目の呼び出しは、アプリが変更を読み取り中に、ユーザーがライブラリに別のフォルダーを追加する場合は、競合状態に対する防御です。</span><span class="sxs-lookup"><span data-stu-id="9ad27-146">The second call to enable is to defend against a race condition if the user adds another folder to the library while your app is reading changes.</span></span> <span data-ttu-id="9ad27-147">余分な呼び出しなし**を有効にする**ユーザーが各自のライブラリ内のフォルダーを変更する場合は、コードを ecSearchFolderScopeViolation (0x80070490) で失敗</span><span class="sxs-lookup"><span data-stu-id="9ad27-147">Without the extra call to **Enable** the code will fail with ecSearchFolderScopeViolation (0x80070490) if the user is changing the folders in their library</span></span>

### <a name="accept-the-changes"></a><span data-ttu-id="9ad27-148">変更を確定します。</span><span class="sxs-lookup"><span data-stu-id="9ad27-148">Accept the changes</span></span>

<span data-ttu-id="9ad27-149">アプリが完了したら、変更を処理するを呼び出すことによってこれらの変更を今後表示しないシステムに通知が必要があります、 [ **AcceptChangesAsync** ](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrarychangereader.acceptchangesasync)メソッド。</span><span class="sxs-lookup"><span data-stu-id="9ad27-149">After the app is done processing the changes, it should tell the system to never show those changes again by calling the [**AcceptChangesAsync**](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrarychangereader.acceptchangesasync) method.</span></span>

```csharp
await changeReader.AcceptChangesAsync();
```

![もう一度表示することは、読むとして変更をマークします。](images/changetracker-accepting.png)

<span data-ttu-id="9ad27-151">アプリはようになりました変更の受信のみ新しい変更の追跡ツールの今後の読み取り時にします。</span><span class="sxs-lookup"><span data-stu-id="9ad27-151">The app will now only receive new changes when reading the change tracker in the future.</span></span>

- <span data-ttu-id="9ad27-152">呼び出しの間の変更が生じた場合[ **ReadBatchAsync** ](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrarychangereader.readbatchasync)と[AcceptChangesAsync](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrarychangereader.acceptchangesasync)ポインターになります、アプリが表示される最新の変更に移すことのみです。</span><span class="sxs-lookup"><span data-stu-id="9ad27-152">If changes have happened between calling [**ReadBatchAsync**](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrarychangereader.readbatchasync) and [AcceptChangesAsync](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrarychangereader.acceptchangesasync), the pointer will be only be advanced to the most recent change the app has seen.</span></span> <span data-ttu-id="9ad27-153">その他の変更は引き続き使用できます、次回呼び出し**ReadBatchAsync**します。</span><span class="sxs-lookup"><span data-stu-id="9ad27-153">Those other changes will still be available the next time it calls **ReadBatchAsync**.</span></span>
- <span data-ttu-id="9ad27-154">アプリの呼び出しに時間を次の変更の同じセットを返すシステムにより、変更を受け入れていません**ReadBatchAsync**します。</span><span class="sxs-lookup"><span data-stu-id="9ad27-154">Not accepting the changes will cause the system to return the same set of changes the next time the app calls **ReadBatchAsync**.</span></span>

## <a name="important-things-to-remember"></a><span data-ttu-id="9ad27-155">重要な注意点</span><span class="sxs-lookup"><span data-stu-id="9ad27-155">Important things to remember</span></span>

<span data-ttu-id="9ad27-156">変更の追跡ツールを使用する場合は、すべてが正しく動作するかどうかを確認する点に注意する必要がありますをいくつかの点。</span><span class="sxs-lookup"><span data-stu-id="9ad27-156">When using the change tracker, there are a few things that you should keep in mind to make sure that everything is working correctly.</span></span>

### <a name="buffer-overruns"></a><span data-ttu-id="9ad27-157">バッファー オーバーラン</span><span class="sxs-lookup"><span data-stu-id="9ad27-157">Buffer overruns</span></span>

<span data-ttu-id="9ad27-158">アプリが読み取ることができるまでに、システムで発生したすべての操作を保持するために、変更トラッカーのための十分な領域を予約するようにしては、非常に簡単に循環バッファがそれ自体を上書きする前に、アプリでの変更に読み取るしないシナリオを考えてみましょう。</span><span class="sxs-lookup"><span data-stu-id="9ad27-158">Although we try to reserve enough space in the change tracker to hold all the operations happening on the system until your app can read them, it is very easy to imagine a scenario where the app doesn’t read the changes before the circular buffer overwrites itself.</span></span> <span data-ttu-id="9ad27-159">特に場合、ユーザーがバックアップからデータを復元または、電話のカメラから画像の大規模なコレクションを同期します。</span><span class="sxs-lookup"><span data-stu-id="9ad27-159">Especially if the user is restoring data from a backup or syncing a large collection of pictures from their camera phone.</span></span>

<span data-ttu-id="9ad27-160">この場合、 **ReadBatchAsync**はエラー コードを返します[ **StorageLibraryChangeType.ChangeTrackingLost**](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrarychangetype)します。</span><span class="sxs-lookup"><span data-stu-id="9ad27-160">In this case, **ReadBatchAsync** will return the error code [**StorageLibraryChangeType.ChangeTrackingLost**](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrarychangetype).</span></span> <span data-ttu-id="9ad27-161">アプリでは、このエラー コードを受信する場合は、次の点が考えられます。</span><span class="sxs-lookup"><span data-stu-id="9ad27-161">If your app receives this error code, it means a couple things:</span></span>

* <span data-ttu-id="9ad27-162">バッファーでは、前回をもたらして上書き自体。</span><span class="sxs-lookup"><span data-stu-id="9ad27-162">The buffer has overwritten itself since the last time you looked at it.</span></span> <span data-ttu-id="9ad27-163">トラッカーからの情報は不完全になりますが、ライブラリの再クロールする最善のです。</span><span class="sxs-lookup"><span data-stu-id="9ad27-163">The best course of action is to recrawl the library, because any information from the tracker will be incomplete.</span></span>
* <span data-ttu-id="9ad27-164">呼び出すまでは、変更の追跡ツールはそれ以上変更を返しません。 [**リセット**](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrarychangetracker.reset)します。</span><span class="sxs-lookup"><span data-stu-id="9ad27-164">The change tracker will not return any more changes until you call [**Reset**](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrarychangetracker.reset).</span></span> <span data-ttu-id="9ad27-165">アプリでは、リセットを呼び出し、ポインターは最新の変更に移動して追跡が正常に再開されます。</span><span class="sxs-lookup"><span data-stu-id="9ad27-165">After the app calls reset, the pointer will be moved to the most recent change and tracking will resume normally.</span></span>

<span data-ttu-id="9ad27-166">まれに、これらのケースを取得する必要があるが、ユーザーに多数の周囲、ディスク上のファイルを移動のシナリオで、変更追跡が巨大になるし、大量の記憶域を占有したくないです。</span><span class="sxs-lookup"><span data-stu-id="9ad27-166">It should be rare to get these cases, but in scenarios where the user is moving a large number of files around on their disk we don’t want the change tracker to balloon and take up too much storage.</span></span> <span data-ttu-id="9ad27-167">これで Windows カスタマー エクスペリエンスを破壊しない中に大量のファイル システム操作に対応するためのアプリできるようにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="9ad27-167">This should allow apps to react to massive file system operations while not damaging the customer experience in Windows.</span></span>

### <a name="changes-to-a-storagelibrary"></a><span data-ttu-id="9ad27-168">StorageLibrary への変更</span><span class="sxs-lookup"><span data-stu-id="9ad27-168">Changes to a StorageLibrary</span></span>

<span data-ttu-id="9ad27-169">[ **StorageLibrary** ](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrary)クラスが他のフォルダーを含むルート フォルダーの仮想グループとして存在します。</span><span class="sxs-lookup"><span data-stu-id="9ad27-169">The [**StorageLibrary**](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrary) class exists as a virtual group of root folders that contain other folders.</span></span> <span data-ttu-id="9ad27-170">ファイル システムの変更の追跡ツールでは、これを調整、次の選択肢を行いました。</span><span class="sxs-lookup"><span data-stu-id="9ad27-170">To reconcile this with a file system change tracker, we made the following choices:</span></span>

- <span data-ttu-id="9ad27-171">ライブラリのルート フォルダーの子孫に対する変更は、変更トラッカーで表現されます。</span><span class="sxs-lookup"><span data-stu-id="9ad27-171">Any changes to descendent of the root library folders will be represented in the change tracker.</span></span> <span data-ttu-id="9ad27-172">使用してライブラリのルート フォルダーを確認することができます、 [**フォルダー** ](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrary.folders)プロパティ。</span><span class="sxs-lookup"><span data-stu-id="9ad27-172">The root library folders can be found using the [**Folders**](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrary.folders) property.</span></span>
- <span data-ttu-id="9ad27-173">追加または削除からのルート フォルダー、 **StorageLibrary** (を通じて[ **RequestAddFolderAsync** ](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrary.requestaddfolderasync)と[ **RequestRemoveFolderAsync** ](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrary.requestremovefolderasync)) エントリを変更トラッカーが作成されません。</span><span class="sxs-lookup"><span data-stu-id="9ad27-173">Adding or removing root folders from a **StorageLibrary** (through [**RequestAddFolderAsync**](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrary.requestaddfolderasync) and [**RequestRemoveFolderAsync**](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrary.requestremovefolderasync)) will not create an entry in the change tracker.</span></span> <span data-ttu-id="9ad27-174">により、これらの変更を追跡できます、 [ **DefinitionChanged** ](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrary.definitionchanged)イベントまたはライブラリを使用して、ルート フォルダーを列挙することによって、 [**フォルダー** ](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrary.folders)プロパティ。</span><span class="sxs-lookup"><span data-stu-id="9ad27-174">These changes can be tracked through the [**DefinitionChanged**](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrary.definitionchanged) event or by enumerating the root folders in the library using the [**Folders**](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrary.folders) property.</span></span>
- <span data-ttu-id="9ad27-175">ライブラリに既に含まれているコンテンツのフォルダーを追加する場合がありますされません変更を生成された通知のほか、変更の追跡ツール エントリ。</span><span class="sxs-lookup"><span data-stu-id="9ad27-175">If a folder with content already in it is added to the library, there will not be a change notification or change tracker entries generated.</span></span> <span data-ttu-id="9ad27-176">そのフォルダーの子孫が変更されたは、通知を生成し、トラッカー エントリを変更します。</span><span class="sxs-lookup"><span data-stu-id="9ad27-176">Any subsequent changes to the descendants of that folder will generate notifications and change tracker entries.</span></span>

### <a name="calling-the-enable-method"></a><span data-ttu-id="9ad27-177">有効にするメソッドを呼び出す</span><span class="sxs-lookup"><span data-stu-id="9ad27-177">Calling the Enable method</span></span>

<span data-ttu-id="9ad27-178">アプリを呼び出す必要があります[**を有効にする**](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrarychangetracker.enable)ファイル システムの追跡を開始するとすぐに、変更のすべての列挙体の前にします。</span><span class="sxs-lookup"><span data-stu-id="9ad27-178">Apps should call [**Enable**](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrarychangetracker.enable) as soon as they start tracking the file system and before every enumeration of the changes.</span></span> <span data-ttu-id="9ad27-179">これにより、すべての変更は、変更トラッカーによってキャプチャされますが保証されます。</span><span class="sxs-lookup"><span data-stu-id="9ad27-179">This will ensure that all changes will be captured by the change tracker.</span></span>  

## <a name="putting-it-together"></a><span data-ttu-id="9ad27-180">これをまとめる</span><span class="sxs-lookup"><span data-stu-id="9ad27-180">Putting it together</span></span>

<span data-ttu-id="9ad27-181">次のビデオ ライブラリからの変更の登録し、変更の追跡ツールからの変更のプルを開始するために使用するすべてのコードに示します。</span><span class="sxs-lookup"><span data-stu-id="9ad27-181">Here is all the code that is used to register for the changes from the video library and start pulling the changes from the change tracker.</span></span>

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
