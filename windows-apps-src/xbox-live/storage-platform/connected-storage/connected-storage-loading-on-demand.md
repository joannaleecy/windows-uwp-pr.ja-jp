---
title: 接続ストレージのオンデマンド読み込み
author: aablackm
description: 接続ストレージ データをすべて一度に読み込むのではなくオンデマンドで読み込む方法について説明します。
ms.assetid: a0797a14-c972-4017-864c-c6ba0d5a3363
ms.author: aablackm
ms.date: 02/27/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one, 接続ストレージ
ms.localizationpriority: medium
ms.openlocfilehash: 62aa90caa899a25fc25b728c0e60cb2db2013c97
ms.sourcegitcommit: 232543fba1fb30bb1489b053310ed6bd4b8f15d5
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/25/2018
ms.locfileid: "4175518"
---
# <a name="connected-storage-loading-on-demand"></a><span data-ttu-id="0dfee-104">接続ストレージのオンデマンド読み込み</span><span class="sxs-lookup"><span data-stu-id="0dfee-104">Connected Storage loading on demand</span></span>

`GetSyncOnDemandForUserAsync` <span data-ttu-id="0dfee-105">を使用すると、クラウド バックアップ データを接続ストレージ領域から、一度にまとめてではなく、"オンデマンド" で読み込むことができます。</span><span class="sxs-lookup"><span data-stu-id="0dfee-105">allows you to load cloud-backed data from a connected storage space "on demand" rather than all at once.</span></span> <span data-ttu-id="0dfee-106">これにより、保存ファイルが特に大きい場合は、`GetForUserAsync` を使用するよりもパフォーマンスを向上させることができます。</span><span class="sxs-lookup"><span data-stu-id="0dfee-106">This can improve performance over `GetForUserAsync` for cases where file saves are particularly large.</span></span>

## <a name="to-load-data-from-a-connected-storage-space-on-demand"></a><span data-ttu-id="0dfee-107">オンデマンドで接続ストレージ領域からデータを読み込むには</span><span class="sxs-lookup"><span data-stu-id="0dfee-107">To load data from a connected storage space on demand</span></span>

### <a name="1--call-getsyncondemandforuserasync"></a><span data-ttu-id="0dfee-108">1: `GetSyncOnDemandForUserAsync` を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="0dfee-108">1:  Call `GetSyncOnDemandForUserAsync`</span></span>

<span data-ttu-id="0dfee-109">これにより、コンテナーの内容ではなく、コンテナーのリストとメタデータをクラウドからダウンロードする部分的な同期がトリガーされます。</span><span class="sxs-lookup"><span data-stu-id="0dfee-109">This triggers a partial sync that downloads a list of containers and their metadata from the cloud, but not their contents.</span></span> <span data-ttu-id="0dfee-110">この操作は高速なので、適切なネットワーク条件下では、ユーザーには読み込み中の UI は表示されません。</span><span class="sxs-lookup"><span data-stu-id="0dfee-110">This operation is fast and, under good network conditions, the user should not see any loading UI.</span></span>

```cpp
auto op = ConnectedStorageSpace::GetSyncOnDemandForUserAsync(user);
op->Completed = ref new AsyncOperationCompletedHandler<ConnectedStorageSpace^>(
    [=](IAsyncOperation<ConnectedStorageSpace^>^ operation, Windows::Foundation::AsyncStatus status)
{
    switch (status)
    {
    case Windows::Foundation::AsyncStatus::Completed:
        auto storageSpace = operation->GetResults();
        break;
    case Windows::Foundation::AsyncStatus::Error:
    case Windows::Foundation::AsyncStatus::Canceled:
        // Present user option: ?Would you like to continue without saving progress??
        if (GetUserInputYesOrNo())
            SetGameState(LoadSaveState::NO_SAVE_MODE);
        else
            SetGameState(LoadSaveState::RETRY_LOAD);
        break;
    }
});
```

```csharp
var users = await Windows.System.User.FindAllAsync();

GameSaveProvider gameSaveProvider;

GameSaveProviderGetResult gameSaveTask = await GameSaveProvider.GetSyncOnDemandForUserAsync(users[0], context.AppConfig.ServiceConfigurationId); 
//Paramaters
//Windows.System.User user
//string SCID

if(gameSaveTask.Status == GameSaveErrorStatus.Ok)
{
    gameSaveProvider = gameSaveTask.Value;
}
```


### <a name="2--perform-a-container-query-using-getcontainerinfo2async"></a><span data-ttu-id="0dfee-111">2: `GetContainerInfo2Async` を使用してコンテナー クエリを実行します。</span><span class="sxs-lookup"><span data-stu-id="0dfee-111">2:  Perform a container query using `GetContainerInfo2Async`</span></span>

<span data-ttu-id="0dfee-112">これにより、3 つの新しいメタデータ フィールドを含む `ContainerInfo2` のコレクションが返されます。</span><span class="sxs-lookup"><span data-stu-id="0dfee-112">This will return a collection of `ContainerInfo2`, which contains 3 new metadata fields:</span></span>

    -   `DisplayName`<span data-ttu-id="0dfee-113">: 表示名の文字列をパラメーターとして受け取る `SubmitUpdatesAsync` のオーバーロードを使用して作成した表示名。</span><span class="sxs-lookup"><span data-stu-id="0dfee-113">: Any display name you have written using the overload of `SubmitUpdatesAsync` that takes a display name string as a parameter.</span></span> <span data-ttu-id="0dfee-114">常にこのフィールドを使用して、ユーザーにわかりやすい名前を格納することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="0dfee-114">We suggest always using this field to store a user-friendly name.</span></span>
    -   `LastModifiedTime`<span data-ttu-id="0dfee-115">: このコンテナーが最後に変更された時刻。</span><span class="sxs-lookup"><span data-stu-id="0dfee-115">: The last time this container was modified.</span></span> <span data-ttu-id="0dfee-116">ローカルとリモートのタイムスタンプが競合する場合は、リモートのタイムスタンプが使用されます。</span><span class="sxs-lookup"><span data-stu-id="0dfee-116">Note that in the case of conflicting local and remote timestamps, the remote ones is used.</span></span>
    -   `NeedsSync`<span data-ttu-id="0dfee-117">: このコンテナーのデータをクラウドからダウンロードする必要があるかどうかを示すブール値。</span><span class="sxs-lookup"><span data-stu-id="0dfee-117">: A boolean indicating if this container has data that needs to be downloaded from the cloud.</span></span>

    <span data-ttu-id="0dfee-118">この追加のメタデータを使用することで、実際にはクラウドからの完全ダウンロードを実行せずに、セーブ データについての主要な情報 (名前、最後に使用された時刻、選択した場合にダウンロードが必要かどうかなど) をユーザーに表示できます。</span><span class="sxs-lookup"><span data-stu-id="0dfee-118">Using this additional metadata, you can present the user with core information about their game saves (including name, last time used, and whether selecting one will require a download) without actually performing a full download from the cloud.</span></span>

```cpp
auto containerQuery = storageSpace->CreateContainerInfoQuery(nullptr); //return list of containers in ConnectedStorageSpace
auto queryOperation = containerQuery->GetContainerInfo2Async();

queryOperation->Completed = ref new AsyncOperationCompletedHandler<IVectorView<ContainerInfo2>^ >( 
    [=] (IAsyncOperation<IVectorView<ContainerInfo2>^ >^ operation, Windows::Foundation::AsyncStatus status)
    {
        switch (status)
        {
        case Windows::Foundation::AsyncStatus::Completed:
            // get the resulting vector of container info
            auto infoVector = operation->GetResults();
            break;
        case Windows::Foundation::AsyncStatus::Error:
        case Windows::Foundation::AsyncStatus::Canceled:
            // handle error cases
            break;
        }
    });
```

```csharp
GameSaveContainerInfoQuery infoQuery = gameSaveProvider.createContainerInfoQuery();
GameSaveContainerInfoGetResult containerInfoResult = await infoQuery.GetContainerInfoAsync();
var containerInfoList;

if(containerInfoResult.Status == GameSaveErrorStatus.Ok)
{
    containerInfoList = containerInfoResult.value;
}

// Use the containerInfoList to inform further actions or display container data to user. 
```

### <a name="3--trigger-a-sync"></a><span data-ttu-id="0dfee-119">3: 同期トリガー</span><span class="sxs-lookup"><span data-stu-id="0dfee-119">3:  Trigger a sync</span></span>

<span data-ttu-id="0dfee-120">接続ストレージの同期は、次のいずれかの既存の接続ストレージ API を呼び出すことによってトリガーされます。</span><span class="sxs-lookup"><span data-stu-id="0dfee-120">A Connected Storage synce will be triggered by calling any of the following existing connected storage API:</span></span>

**<span data-ttu-id="0dfee-121">C++</span><span class="sxs-lookup"><span data-stu-id="0dfee-121">C++</span></span>**

    -   <span data-ttu-id="0dfee-122">BlobInfoQueryResult::GetBlobInfoAsync</span><span class="sxs-lookup"><span data-stu-id="0dfee-122">BlobInfoQueryResult::GetBlobInfoAsync</span></span>
    -   <span data-ttu-id="0dfee-123">BlobInfoQueryResult::GetItemCountAsync</span><span class="sxs-lookup"><span data-stu-id="0dfee-123">BlobInfoQueryResult::GetItemCountAsync</span></span>
    -   <span data-ttu-id="0dfee-124">ConnectedStorageContainer::GetAsync</span><span class="sxs-lookup"><span data-stu-id="0dfee-124">ConnectedStorageContainer::GetAsync</span></span>
    -   <span data-ttu-id="0dfee-125">ConnectedStorageContainer::ReadAsync</span><span class="sxs-lookup"><span data-stu-id="0dfee-125">ConnectedStorageContainer::ReadAsync</span></span>
    -   <span data-ttu-id="0dfee-126">ConnectedStorageSpace::DeleteContainerAsync</span><span class="sxs-lookup"><span data-stu-id="0dfee-126">ConnectedStorageSpace::DeleteContainerAsync</span></span>

**<span data-ttu-id="0dfee-127">C#</span><span class="sxs-lookup"><span data-stu-id="0dfee-127">C#</span></span>**

    -   <span data-ttu-id="0dfee-128">GameSaveBlobInfoQuery.GetBlobInfoAsync</span><span class="sxs-lookup"><span data-stu-id="0dfee-128">GameSaveBlobInfoQuery.GetBlobInfoAsync</span></span>
    -   <span data-ttu-id="0dfee-129">GameSaveBlobInfoQuery.GetItemCountAsync</span><span class="sxs-lookup"><span data-stu-id="0dfee-129">GameSaveBlobInfoQuery.GetItemCountAsync</span></span>
    -   <span data-ttu-id="0dfee-130">GameSaveContainer.GetAsync</span><span class="sxs-lookup"><span data-stu-id="0dfee-130">GameSaveContainer.GetAsync</span></span>
    -   <span data-ttu-id="0dfee-131">GameSaveContainer.ReadAsync</span><span class="sxs-lookup"><span data-stu-id="0dfee-131">GameSaveContainer.ReadAsync</span></span>
    -   <span data-ttu-id="0dfee-132">GameSaveProvider.DeleteContainerAsync</span><span class="sxs-lookup"><span data-stu-id="0dfee-132">GameSaveProvider.DeleteContainerAsync</span></span>

<span data-ttu-id="0dfee-133">これにより、選択したコンテナーのデータがダウンロードされていることを示す通常の同期 UI と進行状況バーがユーザーに表示されます。</span><span class="sxs-lookup"><span data-stu-id="0dfee-133">This will cause the user to see the usual sync UI and progress bar as data from their selected container is downloaded.</span></span> <span data-ttu-id="0dfee-134">選択したコンテナーのデータのみが同期され、その他のコンテナーのデータはダウンロードされません。</span><span class="sxs-lookup"><span data-stu-id="0dfee-134">Note that only data from the selected container is synchronized; data from other containers is not downloaded.</span></span>

<span data-ttu-id="0dfee-135">オンデマンドによる同期のコンテキストでこれらの API を呼び出すと、それらの操作のすべてで、以下の新しいエラー コードが生成されます。</span><span class="sxs-lookup"><span data-stu-id="0dfee-135">When calling these API in the context of an on demand sync, these operations can all produce the following new error codes:</span></span>

-   `ConnectedStorageErrorStatus::ContainerSyncFailed`<span data-ttu-id="0dfee-136">(UWP C# API の `GameSaveErrorStatus.ContainerSyncFailed`): このエラーは、操作が失敗し、コンテナーをクラウドと同期できなかったことを示します。</span><span class="sxs-lookup"><span data-stu-id="0dfee-136">(`GameSaveErrorStatus.ContainerSyncFailed` in UWP C# API): This error indicates that the operation failed and the container could not be synced with the cloud.</span></span> <span data-ttu-id="0dfee-137">ほとんどの場合、同期に失敗するのはユーザーのネットワークの状態が原因です。</span><span class="sxs-lookup"><span data-stu-id="0dfee-137">The most likely cause is the user's network conditions caused the sync to fail.</span></span> <span data-ttu-id="0dfee-138">その場合、ユーザーはネットワークを調整した後にもう一度やり直すか、または同期を必要としないコンテナーを使用することを選択できます。これらのオプションのいずれかを UI で選択できる必要があります。</span><span class="sxs-lookup"><span data-stu-id="0dfee-138">They may want to try again after they've fixed their network or they may choose to use a container they don't have to sync. Your UI should allow either of these options.</span></span> <span data-ttu-id="0dfee-139">システム UI の再試行のダイアログ ボックスはユーザーに既に表示されているので、再試行のダイアログ ボックスは必要ありません。</span><span class="sxs-lookup"><span data-stu-id="0dfee-139">No retry dialog is required, since they will have already seen the system UI retry dialog.</span></span>

-   `ConnectedStorageErrorStatus::ContainerNotInSync`<span data-ttu-id="0dfee-140">(UWP C# API の `GameSaveErrorStatus.ContainerNotInSync`): このエラーは、同期されていないコンテナーへの書き込みをタイトルが誤って実行しようとしたことを示します。</span><span class="sxs-lookup"><span data-stu-id="0dfee-140">(`GameSaveErrorStatus.ContainerNotInSync` in UWP C# API): This error indicates that your title incorrectly tried to write to an unsynced container.</span></span> <span data-ttu-id="0dfee-141">NeedsSync フラグが true に設定されているコンテナーに対して `ConnectedStorageContainer::SubmitUpdatesAsync`(UWP C# API の `GameSaveContainer.SubmitUpdatesAsync`) を呼び出すことはできません。</span><span class="sxs-lookup"><span data-stu-id="0dfee-141">Calling `ConnectedStorageContainer::SubmitUpdatesAsync`(`GameSaveContainer.SubmitUpdatesAsync` in UWP C# API) on a container that has the NeedsSync flag set to true is NOT allowed.</span></span> <span data-ttu-id="0dfee-142">コンテナーに書き込む前に、まず、同期をトリガーするためにそのコンテナーを読み取る必要があります。</span><span class="sxs-lookup"><span data-stu-id="0dfee-142">You must first read a container to trigger a sync before writing to it.</span></span> <span data-ttu-id="0dfee-143">コンテナーの読み取りを行わずにそこに書き込む場合、そのタイトルは、ユーザーの進行状況を失うかもしれないという欠陥を持つ可能性があります。</span><span class="sxs-lookup"><span data-stu-id="0dfee-143">If you write to a container without reading from it, it is likely your title has a bug where you could lose user progress.</span></span>

<span data-ttu-id="0dfee-144">この動作は、ユーザーがオフラインでプレイする場合とは異なります。</span><span class="sxs-lookup"><span data-stu-id="0dfee-144">This behavior is different from when a user plays offline.</span></span> <span data-ttu-id="0dfee-145">オフライン時は、コンテナーが同期されているかどうかは示されないので、後で競合を解決するのはユーザーの責任となります。</span><span class="sxs-lookup"><span data-stu-id="0dfee-145">While offline, there is no indication of whether containers are synchronized, so it is up to the user to resolve any conflicts at a later time.</span></span> <span data-ttu-id="0dfee-146">ただし、この場合、システムはユーザーが同期を必要としていることを把握しているので、ユーザーが古いコンテナーを使用して間違った状態にすることは許可されません (ただし、ユーザーが希望する場合は、タイトルを再起動してオフラインでプレイすることもできます)。</span><span class="sxs-lookup"><span data-stu-id="0dfee-146">In this case, however, the system knows the user needs to sync, so it will not allow them to get into a bad state by using an out-of-date container (though if they desire, they can still restart the title and play it offline).</span></span>

### <a name="4--use-the-rest-of-the-connected-storage-api-as-normal"></a><span data-ttu-id="0dfee-147">4: 接続ストレージ API の残り部分を通常どおりに使用します。</span><span class="sxs-lookup"><span data-stu-id="0dfee-147">4:  Use the rest of the connected storage API as normal</span></span>

<span data-ttu-id="0dfee-148">接続ストレージの動作は、オンデマンドで同期するときもそのままです。</span><span class="sxs-lookup"><span data-stu-id="0dfee-148">Connected Storage behavior remains unchanged when synchronizing on demand.</span></span>
