---
title: "接続ストレージを使ったデータの保存"
author: KevinAsgari
description: "接続ストレージを使ってデータを保存する方法について説明します。"
ms.assetid: ccf7488c-5d55-480e-b3aa-412220d03104
ms.author: kevinasg
ms.date: 04-04-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "xbox live, xbox, ゲーム, uwp, windows 10, xbox one"
ms.openlocfilehash: 0da3e79c0a89575504a1cd3e772c10158b34eb6c
ms.sourcegitcommit: 2b436dc5e5681b8884e0531ee303f851a3e3ccf2
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/18/2017
---
# <a name="use-connected-storage-to-save-data"></a>接続ストレージを使ったデータの保存


データは、ユーザーの *ConnectedStorageSpace* で *ConnectedStorageContainer* を作成し、そのコンテナーで *SubmitUpdatesAsync* メソッドを呼び出すことによって、非同期で保存されます。

| 重要                                                                                                                                                                                                                                                                                                                                                                        |
|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 接続ストレージ コンテナーをまたがるデータ依存関係は安全ではありません。 たとえば、あるコンテナーをクラウドにアップロードする操作が完了しても、別のコンテナーがアップロードのキューに残っている可能性があります。 ユーザーが別の本体に移動しても、同期操作によって最初のコンテナーを同期すると、最初のコンテナーが存在していなくても 2 番目の本体でアクセスすることができます。 |

### <a name="to-save-data-to-connected-storage"></a>接続ストレージにデータを保存するには

1.  *GetForUserAsync* を呼び出して、ユーザーの *ConnectedStorageSpace* オブジェクトを取得します。

    この例では、複数のユーザーの *ConnectedStorageSpace* オブジェクトの管理を容易にするために、返される *ConnectedStorageSpace* オブジェクトがマップに追加されています。

2.  *ConnectedStorageSpac* オブジェクトで *CreateContainer* を呼び出して、*ConnectedStorageContainer* オブジェクトを作成します。
3.  *ConnectedStorageContainer* オブジェクトで *SubmitUpdatesAsync* を呼び出します。

## <a name="sample"></a>サンプル

```cpp
Platform::Guid gPrimarySCID;
Platform::Guid gSecondarySCID;
Windows::Xbox::Storage::ConnectedStorageSpace^ gConnectedStorageSpaceForMachine;
enum LoadSaveState { LOADING, LOAD_COMPLETED, LOAD_FAILED, NO_SAVE_MODE, RETRY_LOAD, GETTING_STORAGE_SPACE, DELETE_SAVE_UI, SAVING, SAVE_COMPLETED, NONE };
LoadSaveState loadSaveState = LoadSaveState::NONE;
auto gConnectedStorageSpaceForUsers = ref new Platform::Collections::Map<unsigned int, Windows::Xbox::Storage::ConnectedStorageSpace^>();

void SetGameState(LoadSaveState state) {loadSaveState = state;}
bool GetUserInputYesOrNo() {return true;};

User^ gCurrentUser;
byte* GetBufferData(Windows::Storage::Streams::IBuffer^ buffer);
IBuffer^ WrapRawBuffer( void* ptr, size_t size );

void PrepareConnectedStorage(User^ user)
{
  auto op = ConnectedStorageSpace::GetForUserAsync(user);
  op->Completed = ref new AsyncOperationCompletedHandler<ConnectedStorageSpace^>(
    [=](IAsyncOperation<ConnectedStorageSpace^>^ operation, Windows::Foundation::AsyncStatus status)
    {
      switch(status)
      {
        case Windows::Foundation::AsyncStatus::Completed:
          gConnectedStorageSpaceForUsers->Insert(user->Id, operation->GetResults());
          break;
        case Windows::Foundation::AsyncStatus::Error:
        case Windows::Foundation::AsyncStatus::Canceled:
          // Present user option: ?Would you like to continue without saving progress??
          if( GetUserInputYesOrNo() )
            SetGameState(LoadSaveState::NO_SAVE_MODE);
          else
            SetGameState(LoadSaveState::RETRY_LOAD);
          break;
      }
    });
}

uint8* GetBufferPointer(IBuffer^ buffer);




enum Color { RED, BLUE };
enum EngineSize { BIG, SMALL };

struct CarData
{
    Color color;
    bool hasWheels;
    bool hasFancyRims;
    EngineSize engineSize;
};


const int MAX_CARS = 10;

struct SaveData
{
    CarData cars[MAX_CARS];
    int numCars;
    int currentCar;
    int cash;
};

SaveData gMySaveData;

bool gSaveInProgress;
void SaveCheckpoint(Windows::Storage::Streams::IBuffer^ buffer, User^ user);

void RenderSpinner() {};
bool ItIsTimeToSaveACheckpoint() {return true;};

void RenderOneFrame()
{
    // ...

    if (gSaveInProgress)
        RenderSpinner();

    // ...
}

void Update()
{
    if (ItIsTimeToSaveACheckpoint())
        SaveCheckpoint(WrapRawBuffer(&gMySaveData,sizeof(SaveData)),gCurrentUser);
}


void SaveCheckpoint(Windows::Storage::Streams::IBuffer^ buffer, User^ user)
{
     auto storageSpace = gConnectedStorageSpaceForUsers->Lookup( user->Id );

     auto container = storageSpace->CreateContainer("Saves/Checkpoint");

     auto updates = ref new Platform::Collections::Map<Platform::String^, Windows::Storage::Streams::IBuffer^>();
     updates->Insert("data", buffer);

     auto op = container->SubmitUpdatesAsync(updates->GetView(), nullptr);

     SetGameState(LoadSaveState::SAVING);
     //gSaveInProgress = true;

     op->Completed = ref new AsyncActionCompletedHandler(
               [=](IAsyncAction^ a, Windows::Foundation::AsyncStatus status){
                   SetGameState(LoadSaveState::SAVE_COMPLETED);
     });
}
```
