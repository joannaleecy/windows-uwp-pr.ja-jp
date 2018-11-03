---
title: 接続ストレージを使ったデータの保存
author: aablackm
description: 接続ストレージを使ってデータを保存する方法について説明します。
ms.assetid: ccf7488c-5d55-480e-b3aa-412220d03104
ms.author: aablackm
ms.date: 02/27/2018
ms.topic: article
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one, 接続ストレージ
ms.localizationpriority: medium
ms.openlocfilehash: d8c29a3371383209ef2c13eaf2b2ffc69b7e0455
ms.sourcegitcommit: 144f5f127fc4fbd852f2f6780ef26054192d68fc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/03/2018
ms.locfileid: "5990929"
---
# <a name="use-connected-storage-to-save-data"></a><span data-ttu-id="2ebb3-104">接続ストレージを使ったデータの保存</span><span class="sxs-lookup"><span data-stu-id="2ebb3-104">Use Connected Storage to save data</span></span>


<span data-ttu-id="2ebb3-105">データは、ユーザーの `ConnectedStorageSpace` で `ConnectedStorageContainer` を作成し、そのコンテナーで `SubmitUpdatesAsync` メソッドを呼び出すことによって、非同期で保存されます。</span><span class="sxs-lookup"><span data-stu-id="2ebb3-105">Data is asynchronously saved by creating a `ConnectedStorageContainer` in a `ConnectedStorageSpace` for a user and calling the `SubmitUpdatesAsync` method on the container.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="2ebb3-106">接続ストレージ コンテナーをまたがるデータ依存関係は安全ではありません。</span><span class="sxs-lookup"><span data-stu-id="2ebb3-106">Data dependencies across connected storage containers are unsafe.</span></span> <span data-ttu-id="2ebb3-107">たとえば、あるコンテナーをクラウドにアップロードする操作が完了しても、別のコンテナーがアップロードのキューに残っている可能性があります。</span><span class="sxs-lookup"><span data-stu-id="2ebb3-107">For example, uploading of one container to the cloud might complete, while another might remain queued for uploading.</span></span> <span data-ttu-id="2ebb3-108">ユーザーが別の本体に移動しても、同期操作によって最初のコンテナーを同期すると、最初のコンテナーが存在していなくても 2 番目の本体でアクセスすることができます。</span><span class="sxs-lookup"><span data-stu-id="2ebb3-108">If the user moved to another console, the synchronization operation would allow the first container to be synchronized and accessed on the second console, without the first container being present.</span></span>

## <a name="to-save-data-to-connected-storage"></a><span data-ttu-id="2ebb3-109">接続ストレージにデータを保存するには</span><span class="sxs-lookup"><span data-stu-id="2ebb3-109">To save data to Connected Storage</span></span>

1.  <span data-ttu-id="2ebb3-110">`GetForUserAsync` を呼び出してユーザーの `ConnectedStorageSpace` オブジェクトを取得します。</span><span class="sxs-lookup"><span data-stu-id="2ebb3-110">Retrieve a `ConnectedStorageSpace` object for the user by calling `GetForUserAsync`.</span></span>

    <span data-ttu-id="2ebb3-111">XDK の例では、複数のユーザーの `ConnectedStorageSpace` オブジェクトの管理を容易にするために、返される `ConnectedStorageSpace` オブジェクトがマップに追加されています。</span><span class="sxs-lookup"><span data-stu-id="2ebb3-111">In the XDK example the returned `ConnectedStorageSpace` object is being added to a map to enable easy management of `ConnectedStorageSpace` objects for multiple users.</span></span>

2.  <span data-ttu-id="2ebb3-112">`ConnectedStorageContainer` オブジェクトを作成するには、`ConnectedStorageSpace` オブジェクトで `CreateContainer` を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="2ebb3-112">Create a `ConnectedStorageContainer` object by calling `CreateContainer` on the `ConnectedStorageSpace` object.</span></span>
3.  <span data-ttu-id="2ebb3-113">`blobsToWrite` パラメーターとして game save データ BLOB を指定して、`ConnectedStorageContainer` で `SubmitUpdatesAsync` を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="2ebb3-113">Call `SubmitUpdatesAsync` on the `ConnectedStorageContainer` with you game save data blob as the `blobsToWrite` parameter.</span></span>

## <a name="c-xdk-sample"></a><span data-ttu-id="2ebb3-114">C++ XDK のサンプル</span><span class="sxs-lookup"><span data-stu-id="2ebb3-114">C++ XDK sample</span></span>

```cpp
auto gConnectedStorageSpaceForUsers = ref new Platform::Collections::Map<unsigned int, Windows::Xbox::Storage::ConnectedStorageSpace^>();

bool GetUserInputYesOrNo() {return true;};

User^ gCurrentUser;
IBuffer^ WrapRawBuffer( void* ptr, size_t size );

// Acquire a Connected Storage space for a user. A Connected Storage space is required to manipulate Connected Storage Data.
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
            //If the users opts yes, continue in offline mode
          else
            //If the users opts no, retry.
          break;
      }
    });
}

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

void SaveCheckpoint(Windows::Storage::Streams::IBuffer^ buffer, User^ user);

bool ItIsTimeToSaveACheckpoint() {return true;};

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

     //Save is happening here asynchronously

     op->Completed = ref new AsyncActionCompletedHandler(
               [=](IAsyncAction^ a, Windows::Foundation::AsyncStatus status){
                   //Save function has completed
                   //This area can be filled with further post save logic.
     });
}
```

<span data-ttu-id="2ebb3-115">XDK .chm ファイルで説明されている XDK 接続ストレージ API は、パス **Xbox ONE XDK >> API リファレンス >> プラットフォーム API リファレンス >> システム API リファレンス >> Windows.Xbox.Storage** にあります。</span><span class="sxs-lookup"><span data-stu-id="2ebb3-115">You can find the XDK Connected Storage APIs documented in the XDK .chm file under the path: **Xbox ONE XDK >> API Reference >> Platform API Reference >> System API Reference >> Windows.Xbox.Storage**.</span></span>
<span data-ttu-id="2ebb3-116">XDK API については、[developer.microsoft.com サイト](https://developer.microsoft.com/en-us/games/xbox/docs/xdk/storage-xbox-microsoft-n)でも説明されています。</span><span class="sxs-lookup"><span data-stu-id="2ebb3-116">The XDK APIs are also documented on the [developer.microsoft.com site](https://developer.microsoft.com/en-us/games/xbox/docs/xdk/storage-xbox-microsoft-n).</span></span>
<span data-ttu-id="2ebb3-117">XDK API へのリンクを開くには、Xbox 開発キット (XDK) へのアクセスが有効になっている Microsoft アカウント (MSA) が必要です。</span><span class="sxs-lookup"><span data-stu-id="2ebb3-117">The link to XDK APIs requires that you have a Microsoft Account(MSA) that has been enabled for Xbox Developer Kit(XDK) access.</span></span>
<span data-ttu-id="2ebb3-118">Windows.Xbox.Storage は、Xbox One 本体の接続ストレージ名前空間の名前です。</span><span class="sxs-lookup"><span data-stu-id="2ebb3-118">Windows.Xbox.Storage is the name of the Connected Storage namespace for Xbox One consoles.</span></span>

## <a name="c-uwp-sample"></a><span data-ttu-id="2ebb3-119">C# UWP のサンプル</span><span class="sxs-lookup"><span data-stu-id="2ebb3-119">C# UWP sample</span></span>

<span data-ttu-id="2ebb3-120">XDK ゲームと UWP アプリでは異なる API を使うことがありますが、UWP API はかなり細かく XDK API に倣っています。</span><span class="sxs-lookup"><span data-stu-id="2ebb3-120">While XDK games and UWP apps may use different APIs, the UWP API is modeled after the XDK API very closely.</span></span> <span data-ttu-id="2ebb3-121">データを保存するには、名前空間とクラス名の変更を書き留めると同時に同じ基本的な手順に従う必要があります。</span><span class="sxs-lookup"><span data-stu-id="2ebb3-121">To save data you will still need to follow the same basic steps while making note of some namespace and class name changes.</span></span> <span data-ttu-id="2ebb3-122">名前空間 `Windows::Xbox::Storage` を使う代わりに、`Windows.Gaming.XboxLive.Storage` を使います。</span><span class="sxs-lookup"><span data-stu-id="2ebb3-122">Instead of using the namespace `Windows::Xbox::Storage` you will use `Windows.Gaming.XboxLive.Storage`.</span></span> <span data-ttu-id="2ebb3-123">クラス `ConnectedStorageSpace` は `GameSaveProvider` と同等です。</span><span class="sxs-lookup"><span data-stu-id="2ebb3-123">The class `ConnectedStorageSpace`, is equivalent to `GameSaveProvider`.</span></span> <span data-ttu-id="2ebb3-124">クラス `ConnectedStorageContainer` は `GameSaveContainer` と同等です。</span><span class="sxs-lookup"><span data-stu-id="2ebb3-124">The class `ConnectedStorageContainer` is equivalent to `GameSaveContainer`.</span></span> <span data-ttu-id="2ebb3-125">これらの変更については、「[XDK から UWP への Xbox Live コードの移植](../../using-xbox-live/porting-xbox-live-code-from-xdk-to-uwp.md)」の「接続ストレージ」で詳しく説明されています。</span><span class="sxs-lookup"><span data-stu-id="2ebb3-125">These changes are further detailed in the Connected Storage Section of [Porting Xbox Live Code From XDK to UWP](../../using-xbox-live/porting-xbox-live-code-from-xdk-to-uwp.md).</span></span>

```csharp
//Namespace Required
Windows.Gaming.XboxLive.Storage

//Get The User
var users = await Windows.System.User.FindAllAsync();

int intData = 23;
const string c_saveBlobName = "Jersey";
const string c_saveContainerDisplayName = "GameSave";
const string c_saveContainerName = "GameSaveContainer";
GameSaveProvider gameSaveProvider;

GameSaveProviderGetResult gameSaveTask = await GameSaveProvider.GetForUserAsync(users[0], context.AppConfig.ServiceConfigurationId); 
//Parameters
//Windows.System.User user
//string SCID

if(gameSaveTask.Status == GameSaveErrorStatus.Ok)
{
    gameSaveProvider = gameSaveTask.Value;
}
else
{
    return;
    //throw new Exception("Game Save Provider Initialization failed");
}

//Now you have a GameSaveProvider (formerly ConnectedStorageSpace)
//Next you need to call CreateContainer to get a GameSaveContainer (formerly ConnectedStorageContainer)

GameSaveContainer gameSaveContainer = gameSaveProvider.CreateContainer(c_saveContainerName); // this will create a new named game save container with the name = to the input name
//Parameter
//string name

// To store a value in the container, it needs to be written into a buffer, then stored with
// a blob name in a Dictionary.

DataWriter writer = new DataWriter();

writer.WriteInt32(intData); //some number you want to save, in this case 23.

IBuffer dataBuffer = writer.DetachBuffer();

var blobsToWrite = new Dictionary<string, IBuffer>();

blobsToWrite.Add(c_saveBlobName, dataBuffer);

GameSaveOperationResult gameSaveOperationResult = await gameSaveContainer.SubmitUpdatesAsync(blobsToWrite, null, c_saveContainerDisplayName);
//IReadOnlyDictionary<String, IBuffer> blobsToWrite
//IEnumerable<string> blobsToDelete
//string displayName
```

<span data-ttu-id="2ebb3-126">UWP アプリの接続ストレージ API については、「[Xbox Live API リファレンス](https://docs.microsoft.com/en-us/uwp/api/windows.gaming.xboxlive.storage)」で説明されています。</span><span class="sxs-lookup"><span data-stu-id="2ebb3-126">Connected Storage APIs for UWP apps are documented in the [Xbox Live API reference](https://docs.microsoft.com/en-us/uwp/api/windows.gaming.xboxlive.storage).</span></span>
<span data-ttu-id="2ebb3-127">接続ストレージを使う別のサンプルについては、[Xbox Live API のサンプル Game Save プロジェクトに関するページ](https://github.com/Microsoft/xbox-live-samples/tree/master/Samples/ID%40XboxSDK/GameSave)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="2ebb3-127">To see another sample that uses Connected Storage check out the [Xbox Live API Samples Game Save project](https://github.com/Microsoft/xbox-live-samples/tree/master/Samples/ID%40XboxSDK/GameSave).</span></span>