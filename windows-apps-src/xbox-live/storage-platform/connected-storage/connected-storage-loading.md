---
title: "接続ストレージを使ったデータの読み込み"
author: KevinAsgari
description: "接続ストレージを使ってデータを読み込む方法について説明します。"
ms.assetid: c660a456-fe7d-453a-ae7b-9ecaa2ba0a15
ms.author: kevinasg
ms.date: 04-04-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "xbox live, xbox, ゲーム, uwp, windows 10, xbox one, 接続ストレージ"
ms.openlocfilehash: c683e7219c5c3dfd3a7e4d5cbd91aba270df75c7
ms.sourcegitcommit: 2b436dc5e5681b8884e0531ee303f851a3e3ccf2
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/18/2017
---
# <a name="use-connected-storage-to-load-data"></a><span data-ttu-id="15cc2-104">接続ストレージを使ったデータの読み込み</span><span class="sxs-lookup"><span data-stu-id="15cc2-104">Use Connected Storage to load data</span></span>

<span data-ttu-id="15cc2-105">非同期のデータ読み取りは、接続ストレージの *ReadAsync* または *GetAsync* メソッドを使用して行います。</span><span class="sxs-lookup"><span data-stu-id="15cc2-105">Data is asynchronously read using the *ReadAsync* or *GetAsync* connected storage method.</span></span>

### <a name="to-load-data-from-connected-storage"></a><span data-ttu-id="15cc2-106">接続ストレージからデータを読み込むには</span><span class="sxs-lookup"><span data-stu-id="15cc2-106">To load data from Connected Storage</span></span>

1.  <span data-ttu-id="15cc2-107">*GetForUserAsync* を呼び出して、ユーザーの *ConnectedStorageSpace* を取得します。</span><span class="sxs-lookup"><span data-stu-id="15cc2-107">Retrieve a *ConnectedStorageSpace* for the user by calling *GetForUserAsync*.</span></span>

    <span data-ttu-id="15cc2-108">この例では、複数のユーザーの *ConnectedStorageSpace* オブジェクトの管理を容易にするために、返される *ConnectedStorageSpace* がマップに追加されています。</span><span class="sxs-lookup"><span data-stu-id="15cc2-108">In this example the returned *ConnectedStorageSpace* is being added to a map to enable easy management of *ConnectedStorageSpace* objects for multiple users.</span></span>

2.  <span data-ttu-id="15cc2-109">*ConnectedStorageSpace* で *CreateContainer* を呼び出して、*ConnectedStorageContainer* を作成します。</span><span class="sxs-lookup"><span data-stu-id="15cc2-109">Create a *ConnectedStorageContainer* by calling *CreateContainer* on the *ConnectedStorageSpace*.</span></span>
3.  <span data-ttu-id="15cc2-110">*ConnectedStorageContainer* で *ReadAsync* または *GetAsync* を呼び出して、データを取得します。</span><span class="sxs-lookup"><span data-stu-id="15cc2-110">Retrieve the data by calling *ReadAsync* or *GetAsync* on the *ConnectedStorageContainer*.</span></span> <span data-ttu-id="15cc2-111">*ReadAsync* ではバッファーを渡す必要があります。一方、*GetAsync* は、読み取られるデータを格納するための新しいバッファーを割り当てます。</span><span class="sxs-lookup"><span data-stu-id="15cc2-111">*ReadAsync* requires you to pass in a buffer while *GetAsync* allocates new buffers to store the data that is read.</span></span>

## <a name="sample"></a><span data-ttu-id="15cc2-112">サンプル</span><span class="sxs-lookup"><span data-stu-id="15cc2-112">Sample</span></span>

```cpp
Platform::Guid gPrimarySCID;
Platform::Guid gSecondarySCID;
Windows::Xbox::Storage::ConnectedStorageSpace^ gConnectedStorageSpaceForMachine;
enum LoadSaveState { LOADING, LOAD_COMPLETED, LOAD_FAILED, NO_SAVE_MODE, RETRY_LOAD, GETTING_STORAGE_SPACE, DELETE_SAVE_UI, SAVING, SAVE_COMPLETED, NONE };
LoadSaveState loadSaveState = LoadSaveState::NONE;
auto gConnectedStorageSpaceForUsers = ref new Platform::Collections::Map<unsigned int, Windows::Xbox::Storage::ConnectedStorageSpace^>();

void SetGameState(LoadSaveState state) { loadSaveState = state; }
bool GetUserInputYesOrNo() { return true; };

User^ gCurrentUser;
byte* GetBufferData(Windows::Storage::Streams::IBuffer^ buffer);
IBuffer^ WrapRawBuffer(void* ptr, size_t size);

void PrepareConnectedStorage(User^ user)
{
    auto op = ConnectedStorageSpace::GetForUserAsync(user);
    op->Completed = ref new AsyncOperationCompletedHandler<ConnectedStorageSpace^>(
        [=](IAsyncOperation<ConnectedStorageSpace^>^ operation, Windows::Foundation::AsyncStatus status)
    {
        switch (status)
        {
        case Windows::Foundation::AsyncStatus::Completed:
            gConnectedStorageSpaceForUsers->Insert(user->Id, operation->GetResults());
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
}

extern void SetGameState(LoadSaveState state);

void OnLoadCompleted(IAsyncAction^ action, Windows::Foundation::AsyncStatus status);

// Load data from a fixed container/blob name into an IBuffer
void Load(Windows::Storage::Streams::IBuffer^ buffer)
{

    auto reads = ref new Platform::Collections::Map<Platform::String^, Windows::Storage::Streams::IBuffer^>();
    reads->Insert("data", buffer);

    auto storageSpace = gConnectedStorageSpaceForUsers->Lookup(gCurrentUser->Id);
    auto container = storageSpace->CreateContainer("Saves/Checkpoint");

    SetGameState(LoadSaveState::LOADING);

    auto op = container->ReadAsync(reads->GetView());

    op->Completed = ref new AsyncActionCompletedHandler(OnLoadCompleted);
}

void OnLoadCompleted(IAsyncAction^ action, Windows::Foundation::AsyncStatus status)
{
    switch (action->Status)
    {
    case Windows::Foundation::AsyncStatus::Completed:
        SetGameState(LoadSaveState::LOAD_COMPLETED);
        break;

    case Windows::Foundation::AsyncStatus::Error:
    case Windows::Foundation::AsyncStatus::Canceled:
        SetGameState(LoadSaveState::LOAD_FAILED);
        break;

    default:
        SetGameState(LoadSaveState::LOAD_FAILED);
        break;
    }
}
```
