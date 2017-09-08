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
# <a name="use-connected-storage-to-save-data"></a><span data-ttu-id="e4dfd-104">接続ストレージを使ったデータの保存</span><span class="sxs-lookup"><span data-stu-id="e4dfd-104">Use Connected Storage to save data</span></span>


<span data-ttu-id="e4dfd-105">データは、ユーザーの *ConnectedStorageSpace* で *ConnectedStorageContainer* を作成し、そのコンテナーで *SubmitUpdatesAsync* メソッドを呼び出すことによって、非同期で保存されます。</span><span class="sxs-lookup"><span data-stu-id="e4dfd-105">Data is asynchronously saved by creating a *ConnectedStorageContainer* in a *ConnectedStorageSpace* for a user and calling the *SubmitUpdatesAsync* method on the container.</span></span>

| <span data-ttu-id="e4dfd-106">重要</span><span class="sxs-lookup"><span data-stu-id="e4dfd-106">Important</span></span>                                                                                                                                                                                                                                                                                                                                                                        |
|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="e4dfd-107">接続ストレージ コンテナーをまたがるデータ依存関係は安全ではありません。</span><span class="sxs-lookup"><span data-stu-id="e4dfd-107">Data dependencies across connected storage containers are unsafe.</span></span> <span data-ttu-id="e4dfd-108">たとえば、あるコンテナーをクラウドにアップロードする操作が完了しても、別のコンテナーがアップロードのキューに残っている可能性があります。</span><span class="sxs-lookup"><span data-stu-id="e4dfd-108">For example, uploading of one container to the cloud might complete, while another might remain queued for uploading.</span></span> <span data-ttu-id="e4dfd-109">ユーザーが別の本体に移動しても、同期操作によって最初のコンテナーを同期すると、最初のコンテナーが存在していなくても 2 番目の本体でアクセスすることができます。</span><span class="sxs-lookup"><span data-stu-id="e4dfd-109">If the user moved to another console, the synchronization operation would allow the first container to be synchronized and accessed on the second console, without the first container being present.</span></span> |

### <a name="to-save-data-to-connected-storage"></a><span data-ttu-id="e4dfd-110">接続ストレージにデータを保存するには</span><span class="sxs-lookup"><span data-stu-id="e4dfd-110">To save data to connected storage</span></span>

1.  <span data-ttu-id="e4dfd-111">*GetForUserAsync* を呼び出して、ユーザーの *ConnectedStorageSpace* オブジェクトを取得します。</span><span class="sxs-lookup"><span data-stu-id="e4dfd-111">Retrieve a *ConnectedStorageSpace* object for the user by calling *GetForUserAsync*.</span></span>

    <span data-ttu-id="e4dfd-112">この例では、複数のユーザーの *ConnectedStorageSpace* オブジェクトの管理を容易にするために、返される *ConnectedStorageSpace* オブジェクトがマップに追加されています。</span><span class="sxs-lookup"><span data-stu-id="e4dfd-112">In this example the returned *ConnectedStorageSpace* object is being added to a map to enable easy management of *ConnectedStorageSpace* objects for multiple users.</span></span>

2.  <span data-ttu-id="e4dfd-113">*ConnectedStorageSpac* オブジェクトで *CreateContainer* を呼び出して、*ConnectedStorageContainer* オブジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="e4dfd-113">Create a *ConnectedStorageContainer* object by calling *CreateContainer* on the *ConnectedStorageSpac* object.</span></span>
3.  <span data-ttu-id="e4dfd-114">*ConnectedStorageContainer* オブジェクトで *SubmitUpdatesAsync* を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="e4dfd-114">Call *SubmitUpdatesAsync* on the *ConnectedStorageContainer* object.</span></span>

## <a name="sample"></a><span data-ttu-id="e4dfd-115">サンプル</span><span class="sxs-lookup"><span data-stu-id="e4dfd-115">Sample</span></span>

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
