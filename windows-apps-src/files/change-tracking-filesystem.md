---
title: ファイル システムの変更のバック グラウンドでの追跡
description: システムで、ユーザーが移動すると、ファイルの変更や、バック グラウンドでのフォルダーを追跡する方法について説明します。
ms.date: 12/19/2018
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: b0ec7762fd64f0f0b8de65faa1aaf079bdaba3a3
ms.sourcegitcommit: 1cf708443d132306e6c99027662de8ec99177de6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/20/2018
ms.locfileid: "8980290"
---
# <a name="track-file-system-changes-in-the-background"></a><span data-ttu-id="891dc-104">ファイル システムの変更のバック グラウンドでの追跡</span><span class="sxs-lookup"><span data-stu-id="891dc-104">Track file system changes in the background</span></span>

**<span data-ttu-id="891dc-105">重要な API</span><span class="sxs-lookup"><span data-stu-id="891dc-105">Important APIs</span></span>**

-   [**<span data-ttu-id="891dc-106">StorageLibraryChangeTracker</span><span class="sxs-lookup"><span data-stu-id="891dc-106">StorageLibraryChangeTracker</span></span>**](https://docs.microsoft.com/uwp/api/Windows.Storage.StorageLibraryChangeTracker)
-   [**<span data-ttu-id="891dc-107">StorageLibraryChangeReader</span><span class="sxs-lookup"><span data-stu-id="891dc-107">StorageLibraryChangeReader</span></span>**](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrarychangereader)
-   [**<span data-ttu-id="891dc-108">StorageLibraryChangedTrigger</span><span class="sxs-lookup"><span data-stu-id="891dc-108">StorageLibraryChangedTrigger</span></span>**](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Background.StorageLibraryContentChangedTrigger)
-   [**<span data-ttu-id="891dc-109">StorageLibrary</span><span class="sxs-lookup"><span data-stu-id="891dc-109">StorageLibrary</span></span>**](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrary)

<span data-ttu-id="891dc-110">[**StorageLibraryChangeTracker**](https://docs.microsoft.com/uwp/api/Windows.Storage.StorageLibraryChangeTracker)クラスには、システムで、ユーザーが移動すると、ファイルやフォルダーに変更を追跡するアプリができます。</span><span class="sxs-lookup"><span data-stu-id="891dc-110">The [**StorageLibraryChangeTracker**](https://docs.microsoft.com/uwp/api/Windows.Storage.StorageLibraryChangeTracker) class allows apps to track changes in files and folders as users move them around the system.</span></span> <span data-ttu-id="891dc-111">**StorageLibraryChangeTracker**クラスを使用して、アプリを追跡できます。</span><span class="sxs-lookup"><span data-stu-id="891dc-111">Using the **StorageLibraryChangeTracker** class, an app can track:</span></span>

- <span data-ttu-id="891dc-112">ファイル操作などの追加、削除、変更します。</span><span class="sxs-lookup"><span data-stu-id="891dc-112">File operations including add, delete, modify.</span></span>
- <span data-ttu-id="891dc-113">名前の変更や削除などの操作をフォルダー。</span><span class="sxs-lookup"><span data-stu-id="891dc-113">Folder operations such as renames and deletes.</span></span>
- <span data-ttu-id="891dc-114">ファイルとフォルダー、ドライブに移動します。</span><span class="sxs-lookup"><span data-stu-id="891dc-114">Files and folders moving on the drive.</span></span>

<span data-ttu-id="891dc-115">変更の追跡ツールを操作するためのプログラミング モデルについて説明します、いくつかのサンプル コードを表示および**StorageLibraryChangeTracker**で管理されるファイル操作の種類を理解するのには、このガイドを使用します。</span><span class="sxs-lookup"><span data-stu-id="891dc-115">Use this guide to learn the programing model for working with the change tracker, view some sample code, and understand the different types of file operations that are tracked by **StorageLibraryChangeTracker**.</span></span>

<span data-ttu-id="891dc-116">**StorageLibraryChangeTracker**は、ユーザーのライブラリ、または任意のフォルダーをローカル コンピューターで動作します。</span><span class="sxs-lookup"><span data-stu-id="891dc-116">**StorageLibraryChangeTracker** works for user libraries, or for any folder on the local machine.</span></span> <span data-ttu-id="891dc-117">これにより、セカンダリ ドライブやリムーバブル ドライブが含まれていますが、NAS ドライブやネットワーク ドライブには含まれません。</span><span class="sxs-lookup"><span data-stu-id="891dc-117">This includes secondary drives or removable drives but does not include NAS drives or network drives.</span></span>

## <a name="using-the-change-tracker"></a><span data-ttu-id="891dc-118">変更の追跡ツールを使用します。</span><span class="sxs-lookup"><span data-stu-id="891dc-118">Using the change tracker</span></span>

<span data-ttu-id="891dc-119">変更トラッカーは、システムの最後の*n 個*のファイル システム操作を格納する循環バッファーとして実装されます。</span><span class="sxs-lookup"><span data-stu-id="891dc-119">The change tracker is implemented on system as a circular buffer storing the last *N* file system operations.</span></span> <span data-ttu-id="891dc-120">アプリは、バッファーからの変更を読み取るし、独自のエクスペリエンスに処理することができます。</span><span class="sxs-lookup"><span data-stu-id="891dc-120">Apps are able to read the changes off of the buffer and then process them into their own experiences.</span></span> <span data-ttu-id="891dc-121">アプリが終了する処理は、変更をマークすることはありませんが、変更をもう一度表示します。</span><span class="sxs-lookup"><span data-stu-id="891dc-121">Once the app is finished with the changes it marks the changes as processed and will never see them again.</span></span>

<span data-ttu-id="891dc-122">フォルダーの変更の追跡ツールを使用するには、次の手順に従います。</span><span class="sxs-lookup"><span data-stu-id="891dc-122">To use the change tracker on a folder, follow these steps:</span></span>

1. <span data-ttu-id="891dc-123">変更のフォルダーの追跡を有効にします。</span><span class="sxs-lookup"><span data-stu-id="891dc-123">Enable change tracking for the folder.</span></span>
2. <span data-ttu-id="891dc-124">変更を待ちます。</span><span class="sxs-lookup"><span data-stu-id="891dc-124">Wait for changes.</span></span>
3. <span data-ttu-id="891dc-125">読み取りを変更します。</span><span class="sxs-lookup"><span data-stu-id="891dc-125">Read changes.</span></span>
4. <span data-ttu-id="891dc-126">変更を受け入れます。</span><span class="sxs-lookup"><span data-stu-id="891dc-126">Accept changes.</span></span>

<span data-ttu-id="891dc-127">次のセクションでは、を通じてこれらのコード例をいくつかの手順について説明します。</span><span class="sxs-lookup"><span data-stu-id="891dc-127">The next sections walk through each of the steps with some code examples.</span></span> <span data-ttu-id="891dc-128">完全なコード サンプルは、記事の最後に提供されます。</span><span class="sxs-lookup"><span data-stu-id="891dc-128">The complete code sample is provided at the end of the article.</span></span>

### <a name="enable-the-change-tracker"></a><span data-ttu-id="891dc-129">変更の追跡ツールを有効にします。</span><span class="sxs-lookup"><span data-stu-id="891dc-129">Enable the change tracker</span></span>

<span data-ttu-id="891dc-130">まず、アプリが実行する必要がある変更の特定のライブラリの追跡を求めていることをシステムに指示することです。</span><span class="sxs-lookup"><span data-stu-id="891dc-130">The first thing that the app needs to do is to tell the system that it is interested in change tracking a given library.</span></span> <span data-ttu-id="891dc-131">これは、関心のあるライブラリの変更トラッカーで[**を有効にする**](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrarychangetracker.enable)メソッドを呼び出して実行します。</span><span class="sxs-lookup"><span data-stu-id="891dc-131">It does this by calling the [**Enable**](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrarychangetracker.enable) method on the change tracker for the library of interest.</span></span>

```csharp
StorageLibrary videosLib = await StorageLibrary.GetLibraryAsync(KnownLibraryId.Videos);
StorageLibraryChangeTracker videoTracker = videosLib.ChangeTracker;
videoTracker.Enable();
```

<span data-ttu-id="891dc-132">いくつかの重要な注意事項:</span><span class="sxs-lookup"><span data-stu-id="891dc-132">A few important notes:</span></span>

- <span data-ttu-id="891dc-133">アプリでは、マニフェストに適切なライブラリにアクセス許可を持つ[**StorageLibrary**](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrary)オブジェクトを作成する前に確認します。</span><span class="sxs-lookup"><span data-stu-id="891dc-133">Make sure your app has permission to the correct library in the manifest before creating the [**StorageLibrary**](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrary) object.</span></span> <span data-ttu-id="891dc-134">詳細については、[ファイルへのアクセス許可](https://docs.microsoft.com/en-us/windows/uwp/files/file-access-permissions)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="891dc-134">See [File Access Permissions](https://docs.microsoft.com/en-us/windows/uwp/files/file-access-permissions) for more details.</span></span>
- <span data-ttu-id="891dc-135">[**有効にする**](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrarychangetracker.enable)スレッド セーフでは、ポインターがリセットされません、として (詳細については後でこの) して、何回呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="891dc-135">[**Enable**](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrarychangetracker.enable) is thread safe, will not reset your pointer, and can be called as many times as you like (more on this later).</span></span>

![空の変更の追跡ツールを有効にします。](images/changetracker-enable.png)

### <a name="wait-for-changes"></a><span data-ttu-id="891dc-137">変更を待つ</span><span class="sxs-lookup"><span data-stu-id="891dc-137">Wait for changes</span></span>

<span data-ttu-id="891dc-138">変更トラッカーは、初期化した後は、すべてのアプリが実行されている場合でも、ライブラリ内に発生する操作の記録が開始されます。</span><span class="sxs-lookup"><span data-stu-id="891dc-138">After the change tracker is initialized, it will begin to record all of the operations that occur within a library, even while the app isn’t running.</span></span> <span data-ttu-id="891dc-139">アプリは、 [**StorageLibraryChangedTrigger**](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Background.StorageLibraryContentChangedTrigger)イベントに登録することで、変更はいつでもアクティブ化を登録できます。</span><span class="sxs-lookup"><span data-stu-id="891dc-139">Apps can register to be activated any time there is a change by registering for the [**StorageLibraryChangedTrigger**](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Background.StorageLibraryContentChangedTrigger) event.</span></span>

![変更を読むためにアプリを変更トラッカーに追加します。](images/changetracker-waiting.png)

### <a name="read-the-changes"></a><span data-ttu-id="891dc-141">変更内容を読み取る</span><span class="sxs-lookup"><span data-stu-id="891dc-141">Read the changes</span></span>

<span data-ttu-id="891dc-142">アプリでは、変更トラッカーから変更をポーリングし、しにチェックが前回変更の一覧を表示できます。</span><span class="sxs-lookup"><span data-stu-id="891dc-142">The app can then poll for changes from the change tracker and receive a list of the changes since the last time it checked.</span></span> <span data-ttu-id="891dc-143">次のコードは、変更トラッカーから変更の一覧を取得する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="891dc-143">The code below shows how to get a list of changes from the change tracker.</span></span>

```csharp
StorageLibrary videosLibrary = await StorageLibrary.GetLibraryAsync(KnownLibraryId.Videos);
videosLibrary.ChangeTracker.Enable();
StorageLibraryChangeReader videoChangeReader = videosLibrary.ChangeTracker.GetChangeReader();
IReadOnlyList changeSet = await changeReader.ReadBatchAsync();
```

<span data-ttu-id="891dc-144">アプリはし、独自のエクスペリエンスまたは必要に応じて、データベースに変更を処理します。</span><span class="sxs-lookup"><span data-stu-id="891dc-144">The app is then responsible for processing the changes into its own experience or database as needed.</span></span>

![アプリのデータベースに変更トラッカーから変更内容の読み取り](images/changetracker-reading.png)

> [!TIP]
> <span data-ttu-id="891dc-146">ユーザーは、アプリは、変更内容の読み取り中に、ライブラリを別のフォルダーを追加する場合、競合状態から防御する 2 番目の呼び出しを有効にすることです。</span><span class="sxs-lookup"><span data-stu-id="891dc-146">The second call to enable is to defend against a race condition if the user adds another folder to the library while your app is reading changes.</span></span> <span data-ttu-id="891dc-147">余分な呼び出しを**有効に**することがなく、コードは失敗します ecSearchFolderScopeViolation (0x80070490) と、ユーザーが、ライブラリ内のフォルダーを変更する場合</span><span class="sxs-lookup"><span data-stu-id="891dc-147">Without the extra call to **Enable** the code will fail with ecSearchFolderScopeViolation (0x80070490) if the user is changing the folders in their library</span></span>

### <a name="accept-the-changes"></a><span data-ttu-id="891dc-148">変更を確定します。</span><span class="sxs-lookup"><span data-stu-id="891dc-148">Accept the changes</span></span>

<span data-ttu-id="891dc-149">アプリが完了したら、変更を処理するにする必要があります、システムに指示[**AcceptChangesAsync**](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrarychangereader.acceptchangesasync)メソッドを呼び出すことによってこれらの変更をもう一度表示されることはありません。</span><span class="sxs-lookup"><span data-stu-id="891dc-149">After the app is done processing the changes, it should tell the system to never show those changes again by calling the [**AcceptChangesAsync**](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrarychangereader.acceptchangesasync) method.</span></span>

```csharp
await changeReader.AcceptChangesAsync();
```

![読み込まれるため、もう一度表示することはそれらの変更としてマークすること](images/changetracker-accepting.png)

<span data-ttu-id="891dc-151">アプリは今すぐだけ受け取ります新しい変更、今後変更トラッカーを読み取るとき。</span><span class="sxs-lookup"><span data-stu-id="891dc-151">The app will now only receive new changes when reading the change tracker in the future.</span></span>

- <span data-ttu-id="891dc-152">ポインターがなります[**ReadBatchAsync**](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrarychangereader.readbatchasync)と[AcceptChangesAsync](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrarychangereader.acceptchangesasync)呼び出しの間、変更が発生している場合のみが高度な検出が、アプリの最新の変更にします。</span><span class="sxs-lookup"><span data-stu-id="891dc-152">If changes have happened between calling [**ReadBatchAsync**](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrarychangereader.readbatchasync) and [AcceptChangesAsync](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrarychangereader.acceptchangesasync), the pointer will be only be advanced to the most recent change the app has seen.</span></span> <span data-ttu-id="891dc-153">その他の変更も利用できます、次回**ReadBatchAsync**を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="891dc-153">Those other changes will still be available the next time it calls **ReadBatchAsync**.</span></span>
- <span data-ttu-id="891dc-154">いない変更を受け入れると、次回、アプリが**ReadBatchAsync**を呼び出すのと同じ一連の変更を返すために、システムが発生します。</span><span class="sxs-lookup"><span data-stu-id="891dc-154">Not accepting the changes will cause the system to return the same set of changes the next time the app calls **ReadBatchAsync**.</span></span>

## <a name="important-things-to-remember"></a><span data-ttu-id="891dc-155">重要な注意事項</span><span class="sxs-lookup"><span data-stu-id="891dc-155">Important things to remember</span></span>

<span data-ttu-id="891dc-156">変更の追跡ツールを使用する場合は、すべてが正しく動作しているかどうかを確認する点に注意する必要がありますが、いくつかの点があります。</span><span class="sxs-lookup"><span data-stu-id="891dc-156">When using the change tracker, there are a few things that you should keep in mind to make sure that everything is working correctly.</span></span>

### <a name="buffer-overruns"></a><span data-ttu-id="891dc-157">バッファー オーバーラン</span><span class="sxs-lookup"><span data-stu-id="891dc-157">Buffer overruns</span></span>

<span data-ttu-id="891dc-158">アプリが読み取ることができるまで、システムで発生するすべての操作を保持するために変更トラッカーで十分な空き領域を予約するようにして、循環バッファーがそれ自体を上書きする前に、アプリでの変更に読み取りしませんシナリオを想像する非常に簡単です。</span><span class="sxs-lookup"><span data-stu-id="891dc-158">Although we try to reserve enough space in the change tracker to hold all the operations happening on the system until your app can read them, it is very easy to imagine a scenario where the app doesn’t read the changes before the circular buffer overwrites itself.</span></span> <span data-ttu-id="891dc-159">特に場合、ユーザーがデータをバックアップから復元またはカメラ電話から画像の大規模なコレクションを同期します。</span><span class="sxs-lookup"><span data-stu-id="891dc-159">Especially if the user is restoring data from a backup or syncing a large collection of pictures from their camera phone.</span></span>

<span data-ttu-id="891dc-160">この例では、 **ReadBatchAsync**は[**StorageLibraryChangeType.ChangeTrackingLost**](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrarychangetype)エラー コードを返します。</span><span class="sxs-lookup"><span data-stu-id="891dc-160">In this case, **ReadBatchAsync** will return the error code [**StorageLibraryChangeType.ChangeTrackingLost**](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrarychangetype).</span></span> <span data-ttu-id="891dc-161">アプリでは、このエラー コードを受信する場合は、次の点が考えられます。</span><span class="sxs-lookup"><span data-stu-id="891dc-161">If your app receives this error code, it means a couple things:</span></span>

* <span data-ttu-id="891dc-162">バッファーが上書きされて自体前回ことについて説明しました。</span><span class="sxs-lookup"><span data-stu-id="891dc-162">The buffer has overwritten itself since the last time you looked at it.</span></span> <span data-ttu-id="891dc-163">トラッカーからの情報は完全になるため、ライブラリを再クロールする最善のことです。</span><span class="sxs-lookup"><span data-stu-id="891dc-163">The best course of action is to recrawl the library, because any information from the tracker will be incomplete.</span></span>
* <span data-ttu-id="891dc-164">[**リセット**](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrarychangetracker.reset)を呼び出すまで変更トラッカーは、複数の変更を返しません。</span><span class="sxs-lookup"><span data-stu-id="891dc-164">The change tracker will not return any more changes until you call [**Reset**](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrarychangetracker.reset).</span></span> <span data-ttu-id="891dc-165">アプリは、リセットの呼び出し後ポインターは、最新の変更に移動して、追跡が正常に再開されます。</span><span class="sxs-lookup"><span data-stu-id="891dc-165">After the app calls reset, the pointer will be moved to the most recent change and tracking will resume normally.</span></span>

<span data-ttu-id="891dc-166">このような場合を取得するまれな場合がありますが、ユーザーが多数の周り、ディスク上のファイルを移動はのシナリオでしますたく変更トラッカーは吹き出しおよびが多すぎる記憶域を占有します。</span><span class="sxs-lookup"><span data-stu-id="891dc-166">It should be rare to get these cases, but in scenarios where the user is moving a large number of files around on their disk we don’t want the change tracker to balloon and take up too much storage.</span></span> <span data-ttu-id="891dc-167">これにより、windows カスタマー エクスペリエンスをつけていない中に大規模なファイル システム操作に応答するようにアプリする必要があります。</span><span class="sxs-lookup"><span data-stu-id="891dc-167">This should allow apps to react to massive file system operations while not damaging the customer experience in Windows.</span></span>

### <a name="changes-to-a-storagelibrary"></a><span data-ttu-id="891dc-168">StorageLibrary への変更</span><span class="sxs-lookup"><span data-stu-id="891dc-168">Changes to a StorageLibrary</span></span>

<span data-ttu-id="891dc-169">[**StorageLibrary**](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrary)クラスは、他のフォルダーが含まれるルート フォルダーの仮想グループとして存在します。</span><span class="sxs-lookup"><span data-stu-id="891dc-169">The [**StorageLibrary**](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrary) class exists as a virtual group of root folders that contain other folders.</span></span> <span data-ttu-id="891dc-170">これの調整ファイル システムの変更の追跡で、次の選択肢を確認しました。</span><span class="sxs-lookup"><span data-stu-id="891dc-170">To reconcile this with a file system change tracker, we made the following choices:</span></span>

- <span data-ttu-id="891dc-171">ルート ライブラリ フォルダーの子孫に変更を加えた変更トラッカーで表されます。</span><span class="sxs-lookup"><span data-stu-id="891dc-171">Any changes to descendent of the root library folders will be represented in the change tracker.</span></span> <span data-ttu-id="891dc-172">[**フォルダー**](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrary.folders)のプロパティを使って、ルートのライブラリのフォルダーを参照してください。</span><span class="sxs-lookup"><span data-stu-id="891dc-172">The root library folders can be found using the [**Folders**](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrary.folders) property.</span></span>
- <span data-ttu-id="891dc-173">追加または削除するルート フォルダー ( [**RequestAddFolderAsync**](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrary.requestaddfolderasync)と[**RequestRemoveFolderAsync**](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrary.requestremovefolderasync)) を通じて**StorageLibrary**では、変更トラッカーのエントリを作成はできません。</span><span class="sxs-lookup"><span data-stu-id="891dc-173">Adding or removing root folders from a **StorageLibrary** (through [**RequestAddFolderAsync**](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrary.requestaddfolderasync) and [**RequestRemoveFolderAsync**](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrary.requestremovefolderasync)) will not create an entry in the change tracker.</span></span> <span data-ttu-id="891dc-174">[**DefinitionChanged**](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrary.definitionchanged)イベントを通じて、または[**フォルダー**](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrary.folders)のプロパティを使用して、ライブラリ内のルート フォルダーを列挙することにより、これらの変更を追跡できます。</span><span class="sxs-lookup"><span data-stu-id="891dc-174">These changes can be tracked through the [**DefinitionChanged**](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrary.definitionchanged) event or by enumerating the root folders in the library using the [**Folders**](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrary.folders) property.</span></span>
- <span data-ttu-id="891dc-175">既にコンテンツを持つフォルダーをライブラリに追加する場合がありますされません変更通知または変更のトラッカー エントリが生成されます。</span><span class="sxs-lookup"><span data-stu-id="891dc-175">If a folder with content already in it is added to the library, there will not be a change notification or change tracker entries generated.</span></span> <span data-ttu-id="891dc-176">その後に変更をそのフォルダーの子孫は通知を生成し、トラッカーのエントリを変更します。</span><span class="sxs-lookup"><span data-stu-id="891dc-176">Any subsequent changes to the descendants of that folder will generate notifications and change tracker entries.</span></span>

### <a name="calling-the-enable-method"></a><span data-ttu-id="891dc-177">有効にするメソッドを呼び出す</span><span class="sxs-lookup"><span data-stu-id="891dc-177">Calling the Enable method</span></span>

<span data-ttu-id="891dc-178">ファイル システムの追跡を開始するとすぐに、変更がすべて列挙する前に、[**有効にする**](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrarychangetracker.enable)が、アプリに呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="891dc-178">Apps should call [**Enable**](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrarychangetracker.enable) as soon as they start tracking the file system and before every enumeration of the changes.</span></span> <span data-ttu-id="891dc-179">これは、ように変更トラッカーですべての変更がキャプチャします。</span><span class="sxs-lookup"><span data-stu-id="891dc-179">This will ensure that all changes will be captured by the change tracker.</span></span>  

## <a name="putting-it-together"></a><span data-ttu-id="891dc-180">これをまとめる</span><span class="sxs-lookup"><span data-stu-id="891dc-180">Putting it together</span></span>

<span data-ttu-id="891dc-181">ビデオ ライブラリから変更を登録し、変更の追跡ツールからの変更のプルを開始するために使用するすべてのコードを次に示します。</span><span class="sxs-lookup"><span data-stu-id="891dc-181">Here is all the code that is used to register for the changes from the video library and start pulling the changes from the change tracker.</span></span>

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
