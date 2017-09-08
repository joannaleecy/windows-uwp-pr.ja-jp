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
# <a name="use-connected-storage-to-load-data"></a>接続ストレージを使ったデータの読み込み

非同期のデータ読み取りは、接続ストレージの *ReadAsync* または *GetAsync* メソッドを使用して行います。

### <a name="to-load-data-from-connected-storage"></a>接続ストレージからデータを読み込むには

1.  *GetForUserAsync* を呼び出して、ユーザーの *ConnectedStorageSpace* を取得します。

    この例では、複数のユーザーの *ConnectedStorageSpace* オブジェクトの管理を容易にするために、返される *ConnectedStorageSpace* がマップに追加されています。

2.  *ConnectedStorageSpace* で *CreateContainer* を呼び出して、*ConnectedStorageContainer* を作成します。
3.  *ConnectedStorageContainer* で *ReadAsync* または *GetAsync* を呼び出して、データを取得します。 *ReadAsync* ではバッファーを渡す必要があります。一方、*GetAsync* は、読み取られるデータを格納するための新しいバッファーを割り当てます。

## <a name="sample"></a>サンプル

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
