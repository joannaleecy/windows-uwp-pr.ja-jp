---
title: 接続ストレージを使ったデータの読み込み
description: 接続ストレージを使ってデータを読み込む方法について説明します。
ms.assetid: c660a456-fe7d-453a-ae7b-9ecaa2ba0a15
ms.date: 02/27/2018
ms.topic: article
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one, 接続ストレージ
ms.localizationpriority: medium
ms.openlocfilehash: a2f7498e8063e290dc506de72b34d2c77d29b26e
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/06/2018
ms.locfileid: "8737095"
---
# <a name="use-connected-storage-to-load-data"></a><span data-ttu-id="15e32-104">接続ストレージを使ったデータの読み込み</span><span class="sxs-lookup"><span data-stu-id="15e32-104">Use Connected Storage to load data</span></span>

<span data-ttu-id="15e32-105">非同期のデータ読み取りは、接続ストレージの `ReadAsync` または `GetAsync` メソッドを使用して行います。</span><span class="sxs-lookup"><span data-stu-id="15e32-105">Data is asynchronously read using the `ReadAsync` or `GetAsync` connected storage method.</span></span>

### <a name="to-load-data-from-connected-storage"></a><span data-ttu-id="15e32-106">接続ストレージからデータを読み込むには</span><span class="sxs-lookup"><span data-stu-id="15e32-106">To load data from Connected Storage</span></span>

1.  <span data-ttu-id="15e32-107">`GetForUserAsync` を呼び出してユーザーの `ConnectedStorageSpace` を取得します。</span><span class="sxs-lookup"><span data-stu-id="15e32-107">Retrieve a `ConnectedStorageSpace` for the user by calling `GetForUserAsync`.</span></span>

    <span data-ttu-id="15e32-108">XDK の例では、複数のユーザーの `ConnectedStorageSpace` オブジェクトの管理を容易にするために、返される `ConnectedStorageSpace` がマップに追加されています。</span><span class="sxs-lookup"><span data-stu-id="15e32-108">In the XDK example the returned `ConnectedStorageSpace` is being added to a map to enable easy management of `ConnectedStorageSpace` objects for multiple users.</span></span>

2.  <span data-ttu-id="15e32-109">`ConnectedStorageContainer` を作成するには、`ConnectedStorageSpace` で `CreateContainer` を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="15e32-109">Create a `ConnectedStorageContainer` by calling `CreateContainer` on the `ConnectedStorageSpace`.</span></span>
3.  <span data-ttu-id="15e32-110">`ConnectedStorageContainer` で `ReadAsync` または `GetAsync` を呼び出して、データを取得します。</span><span class="sxs-lookup"><span data-stu-id="15e32-110">Retrieve the data by calling `ReadAsync` or `GetAsync` on the `ConnectedStorageContainer`.</span></span> `ReadAsync` <span data-ttu-id="15e32-111">ではバッファーを渡す必要があります。一方、`GetAsync` は、読み取られるデータを格納するための新しいバッファーを割り当てます。</span><span class="sxs-lookup"><span data-stu-id="15e32-111">requires you to pass in a buffer while `GetAsync` allocates new buffers to store the data that is read.</span></span>

## <a name="c-xdk-sample"></a><span data-ttu-id="15e32-112">C++ XDK のサンプル</span><span class="sxs-lookup"><span data-stu-id="15e32-112">C++ XDK sample</span></span>

```cpp
auto gConnectedStorageSpaceForUsers = ref new Platform::Collections::Map<unsigned int, Windows::Xbox::Storage::ConnectedStorageSpace^>();

bool GetUserInputYesOrNo() { return true; };

User^ gCurrentUser;
IBuffer^ WrapRawBuffer(void* ptr, size_t size);

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

void OnLoadCompleted(IAsyncAction^ action, Windows::Foundation::AsyncStatus status);

// Load data from a fixed container/blob name into an IBuffer
void Load(Windows::Storage::Streams::IBuffer^ buffer)
{

    auto reads = ref new Platform::Collections::Map<Platform::String^, Windows::Storage::Streams::IBuffer^>();
    reads->Insert("data", buffer);

    auto storageSpace = gConnectedStorageSpaceForUsers->Lookup(gCurrentUser->Id);
    auto container = storageSpace->CreateContainer("Saves/Checkpoint");

    //Save Data is Loading

    auto op = container->ReadAsync(reads->GetView());

    op->Completed = ref new AsyncActionCompletedHandler(OnLoadCompleted);
}

void OnLoadCompleted(IAsyncAction^ action, Windows::Foundation::AsyncStatus status)
{
    switch (action->Status)
    {
    case Windows::Foundation::AsyncStatus::Completed:
        //Successful load logic here.
        break;

    case Windows::Foundation::AsyncStatus::Error:
    case Windows::Foundation::AsyncStatus::Canceled:
        //Fail logic here
        break;

    default:
        //all other possible values of action->status are also failures, alternate fail logic here. 
        break;
    }
}
```

<span data-ttu-id="15e32-113">XDK .chm ファイルで説明されている XDK 接続ストレージ API は、パス **Xbox ONE XDK >> API リファレンス >> プラットフォーム API リファレンス >> システム API リファレンス >> Windows.Xbox.Storage** にあります。</span><span class="sxs-lookup"><span data-stu-id="15e32-113">You can find the XDK Connected Storage APIs documented in the XDK .chm file under the path: **Xbox ONE XDK >> API Reference >> Platform API Reference >> System API Reference >> Windows.Xbox.Storage**.</span></span>
<span data-ttu-id="15e32-114">XDK API については、[developer.microsoft.com サイト](https://developer.microsoft.com/en-us/games/xbox/docs/xdk/storage-xbox-microsoft-n)でも説明されています。</span><span class="sxs-lookup"><span data-stu-id="15e32-114">The XDK APIs are also documented on the [developer.microsoft.com site](https://developer.microsoft.com/en-us/games/xbox/docs/xdk/storage-xbox-microsoft-n).</span></span>
<span data-ttu-id="15e32-115">XDK API へのリンクを開くには、Xbox 開発キット (XDK) へのアクセスが有効になっている Microsoft アカウント (MSA) が必要です。</span><span class="sxs-lookup"><span data-stu-id="15e32-115">The link to XDK APIs requires that you have a Microsoft Account(MSA) that has been enabled for Xbox Developer Kit(XDK) access.</span></span>
<span data-ttu-id="15e32-116">Windows.Xbox.Storage は、Xbox One 本体の接続ストレージ名前空間の名前です。</span><span class="sxs-lookup"><span data-stu-id="15e32-116">Windows.Xbox.Storage is the name of the Connected Storage namespace for Xbox One consoles.</span></span>

## <a name="c-uwp-sample"></a><span data-ttu-id="15e32-117">C# UWP のサンプル</span><span class="sxs-lookup"><span data-stu-id="15e32-117">C# UWP sample</span></span>

<span data-ttu-id="15e32-118">XDK ゲームと UWP アプリでは異なる API を使うことがありますが、UWP API はかなり細かく XDK API に倣っています。</span><span class="sxs-lookup"><span data-stu-id="15e32-118">While XDK games and UWP apps may use different APIs, the UWP API is modeled after the XDK API very closely.</span></span> <span data-ttu-id="15e32-119">データを読み込むには、名前空間とクラス名の変更を書き留めると同時に同じ基本的な手順に従う必要があります。</span><span class="sxs-lookup"><span data-stu-id="15e32-119">To load data you will still need to follow the same basic steps while making note of some namespace and class name changes.</span></span> <span data-ttu-id="15e32-120">名前空間 `Windows::Xbox::Storage` を使う代わりに、`Windows.Gaming.XboxLive.Storage` を使います。</span><span class="sxs-lookup"><span data-stu-id="15e32-120">Instead of using the namespace `Windows::Xbox::Storage` you will use `Windows.Gaming.XboxLive.Storage`.</span></span> <span data-ttu-id="15e32-121">クラス `ConnectedStorageSpace` は `GameSaveProvider` と同等です。</span><span class="sxs-lookup"><span data-stu-id="15e32-121">The class `ConnectedStorageSpace`, is equivalent to `GameSaveProvider`.</span></span> <span data-ttu-id="15e32-122">クラス `ConnectedStorageContainer` は `GameSaveContainer` と同等です。</span><span class="sxs-lookup"><span data-stu-id="15e32-122">The class `ConnectedStorageContainer` is equivalent to `GameSaveContainer`.</span></span> <span data-ttu-id="15e32-123">これらの変更については、「[XDK から UWP への Xbox Live コードの移植](../../using-xbox-live/porting-xbox-live-code-from-xdk-to-uwp.md)」の「接続ストレージ」で詳しく説明されています。</span><span class="sxs-lookup"><span data-stu-id="15e32-123">These changes are further detailed in the Connected Storage Section of [Porting Xbox Live Code From XDK to UWP](../../using-xbox-live/porting-xbox-live-code-from-xdk-to-uwp.md).</span></span>

```csharp
//Namespace Required
Windows.Gaming.XboxLive.Storage

//Get The User
var users = await Windows.System.User.FindAllAsync();

int intData = 0;
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
    //throw new Exception("Game Save Provider Initialization failed");;
}

//Now you have a GameSaveProvider
//Next you need to call CreateContainer to get a GameSaveContainer

GameSaveContainer gameSaveContainer = gameSaveProvider.CreateContainer(c_saveContainerName);
//Parameter
//string name (name of the GameSaveContainer Created)

//form an array of strings containing the blob names you would like to read.
string[] blobsToRead = new string[] { c_saveBlobName };

// GetAsync allocates a new Dictionary to hold the retrieved data. You can also use ReadAsync
// to provide your own preallocated Dictionary.
GameSaveBlobGetResult result = await gameSaveContainer.GetAsync(blobsToRead);

int loadedData = 0;

//Check status to make sure data was read from the container
if(result.Status == GameSaveErrorStatus.Ok)
{
    //prepare a buffer to receive blob
    IBuffer loadedBuffer;

    //retrieve the named blob from the GetAsync result, place it in loaded buffer.
    result.Value.TryGetValue(c_saveBlobName, out loadedBuffer);

    if(loadedBuffer == null)
    {

        throw new Exception(String.Format("Didn't find expected blob \"{0}\" in the loaded data.", c_saveBlobName));

    }
    DataReader reader = DataReader.FromBuffer(loadedBuffer);
    loadedData = reader.ReadInt32();
}
```

<span data-ttu-id="15e32-124">UWP アプリの接続ストレージ API については、「[Xbox Live API リファレンス](https://docs.microsoft.com/en-us/uwp/api/windows.gaming.xboxlive.storage)」で説明されています。</span><span class="sxs-lookup"><span data-stu-id="15e32-124">Connected Storage APIs for UWP apps are documented in the [Xbox Live API reference](https://docs.microsoft.com/en-us/uwp/api/windows.gaming.xboxlive.storage).</span></span>
<span data-ttu-id="15e32-125">接続ストレージを使う別のサンプルについては、[Xbox Live API のサンプル Game Save プロジェクトに関するページ](https://github.com/Microsoft/xbox-live-samples/tree/master/Samples/ID%40XboxSDK/GameSave)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="15e32-125">To see another sample that uses Connected Storage check out the [Xbox Live API Samples Game Save project](https://github.com/Microsoft/xbox-live-samples/tree/master/Samples/ID%40XboxSDK/GameSave).</span></span>