---
title: 接続ストレージを使ったデータの削除
author: aablackm
description: 接続ストレージを使って BLOB およびコンテナー データを削除する方法について説明します。
ms.assetid: ccf7488c-5d55-480e-b3aa-412220d03104
ms.author: aablackm
ms.date: 02/27/2018
ms.topic: article
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one, 接続ストレージ
ms.localizationpriority: medium
ms.openlocfilehash: 94e77a1059f4c114c94969763317f380a7c49618
ms.sourcegitcommit: 086001cffaf436e6e4324761d59bcc5e598c15ea
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/27/2018
ms.locfileid: "5703377"
---
# <a name="use-connected-storage-to-delete-data"></a><span data-ttu-id="d8c0b-104">接続ストレージを使ったデータの削除</span><span class="sxs-lookup"><span data-stu-id="d8c0b-104">Use Connected Storage to delete data</span></span>

<span data-ttu-id="d8c0b-105">データ BLOB は、ユーザーの `ConnectedStorageSpace` で `ConnectedStorageContainer` を作成し、blobsToDelete パラメーターの削除する名前付き BLOB を表す文字列の一覧を示すコンテナーで `SubmitUpdatesAsync` メソッドを呼び出すと非同期的に削除されます。</span><span class="sxs-lookup"><span data-stu-id="d8c0b-105">Data blobs are asynchronously deleted by creating a `ConnectedStorageContainer` in a `ConnectedStorageSpace` for a user and calling the `SubmitUpdatesAsync` method on the container providing a list of strings representing the named blobs to be deleted for the blobsToDelete parameter.</span></span>

<span data-ttu-id="d8c0b-106">データ コンテナーは、`ConnectedStorageContainer` を作成してその `DeleteContainerAsync` メソッドを呼び出すと非同期的に削除されます。</span><span class="sxs-lookup"><span data-stu-id="d8c0b-106">Data Containers are asynchronously deleted by creating a `ConnectedStorageContainer` and calling its `DeleteContainerAsync` method.</span></span>

## <a name="to-delete-blob-data-from-connected-storage"></a><span data-ttu-id="d8c0b-107">接続ストレージから BLOB データを削除するには</span><span class="sxs-lookup"><span data-stu-id="d8c0b-107">To delete blob data from Connected Storage</span></span>

1.  <span data-ttu-id="d8c0b-108">`GetForUserAsync` を呼び出してユーザーの `ConnectedStorageSpace` オブジェクトを取得します。</span><span class="sxs-lookup"><span data-stu-id="d8c0b-108">Retrieve a `ConnectedStorageSpace` object for the user by calling `GetForUserAsync`.</span></span>

    <span data-ttu-id="d8c0b-109">XDK の例では、複数のユーザーの `ConnectedStorageSpace` オブジェクトの管理を容易にするために、返される `ConnectedStorageSpace` オブジェクトがマップに追加されています。</span><span class="sxs-lookup"><span data-stu-id="d8c0b-109">In the XDK example the returned `ConnectedStorageSpace` object is being added to a map to enable easy management of `ConnectedStorageSpace` objects for multiple users.</span></span>

2.  <span data-ttu-id="d8c0b-110">`ConnectedStorageContainer` オブジェクトを作成するには、`ConnectedStorageSpace` オブジェクトで `CreateContainer` を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="d8c0b-110">Create a `ConnectedStorageContainer` object by calling `CreateContainer` on the `ConnectedStorageSpace` object.</span></span>
3.  <span data-ttu-id="d8c0b-111">`ConnectedStorageContainer` オブジェクトで `SubmitUpdatesAsync` を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="d8c0b-111">Call `SubmitUpdatesAsync` on the `ConnectedStorageContainer` object.</span></span>

## <a name="to-delete-a-container-from-connected-storage"></a><span data-ttu-id="d8c0b-112">接続ストレージからコンテナーを削除するには</span><span class="sxs-lookup"><span data-stu-id="d8c0b-112">To delete a container from Connected Storage</span></span>

1.  <span data-ttu-id="d8c0b-113">`GetForUserAsync` を呼び出してユーザーの `ConnectedStorageSpace` オブジェクトを取得します。</span><span class="sxs-lookup"><span data-stu-id="d8c0b-113">Retrieve a `ConnectedStorageSpace` object for the user by calling `GetForUserAsync`.</span></span>

    <span data-ttu-id="d8c0b-114">XDK の例では、複数のユーザーの `ConnectedStorageSpace` オブジェクトの管理を容易にするために、返される `ConnectedStorageSpace` オブジェクトがマップに追加されています。</span><span class="sxs-lookup"><span data-stu-id="d8c0b-114">In the XDK example the returned `ConnectedStorageSpace` object is being added to a map to enable easy management of `ConnectedStorageSpace` objects for multiple users.</span></span>

2.  <span data-ttu-id="d8c0b-115">ConnectedStorageSpace メソッドの `DeleteContainerAsync` メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="d8c0b-115">Call the `DeleteContainerAsync` method of the ConnectedStorageSpace Methods.</span></span>

## <a name="c-xdk-sample"></a><span data-ttu-id="d8c0b-116">C++ XDK のサンプル</span><span class="sxs-lookup"><span data-stu-id="d8c0b-116">C++ XDK sample</span></span>
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

// Delete data from a fixed container/blob name into an IBuffer
void DeleteBlob(User^ user)
{

    //Create a list of blob names to delete
    std::vector<Platform::String^> blobsToDelete;

    //Add the blob name to your Generic Iterable
    blobsToDelete.push_back(L"someBlobName");

    auto blobNames = ref new Platform::Collections::VectorView<Platform::String^>(blobsToDelete);

    auto storageSpace = gConnectedStorageSpaceForUsers->Lookup(user->Id);
    auto container = storageSpace->CreateContainer("Saves/Checkpoint");

    //Delete is occurring asynchronously at this point.

    auto op = container->SubmitUpdatesAsync(nullptr, blobNames);

    op->Completed = ref new AsyncActionCompletedHandler(
        [=](IAsyncAction^ a, Windows::Foundation::AsyncStatus status){
            switch(status)
            {
                case Windows::Foundation::AsyncStatus::Completed:
                //Delete was successful no need for action
                break;
                case Windows::Foundation::AsyncStatus::Error:
                case Windows::Foundation::AsyncStatus::Canceled:
                // Handle failed deletion
            }
     });
}

void DeleteContainer(User^ user)
{
    auto storageSpace = gConnectedStorageSpaceForUsers->Lookup(user->Id);

    auto deleteOperation = storageSpace->DeleteContainerAsync("Saves/Checkpoint");

    deleteOperation->Completed = ref new AsyncActionCompletedHandler(
        [=](IAsyncAction^ a, Windows::Foundation::AsyncStatus status){
            switch(status)
            {
                case Windows::Foundation::AsyncStatus::Completed:
                //Delete was successful no need for action
                break;
                case Windows::Foundation::AsyncStatus::Error:
                case Windows::Foundation::AsyncStatus::Canceled:
                // Handle failed deletion
            }
     });

}
```

<span data-ttu-id="d8c0b-117">XDK .chm ファイルで説明されている XDK 接続ストレージ API は、パス **Xbox ONE XDK >> API リファレンス >> プラットフォーム API リファレンス >> システム API リファレンス >> Windows.Xbox.Storage** にあります。</span><span class="sxs-lookup"><span data-stu-id="d8c0b-117">You can find the XDK Connected Storage APIs documented in the XDK .chm file under the path: **Xbox ONE XDK >> API Reference >> Platform API Reference >> System API Reference >> Windows.Xbox.Storage**.</span></span>
<span data-ttu-id="d8c0b-118">XDK API については、[developer.microsoft.com サイト](https://developer.microsoft.com/en-us/games/xbox/docs/xdk/storage-xbox-microsoft-n)でも説明されています。</span><span class="sxs-lookup"><span data-stu-id="d8c0b-118">The XDK APIs are also documented on the [developer.microsoft.com site](https://developer.microsoft.com/en-us/games/xbox/docs/xdk/storage-xbox-microsoft-n).</span></span>
<span data-ttu-id="d8c0b-119">XDK API へのリンクを開くには、Xbox 開発キット (XDK) へのアクセスが有効になっている Microsoft アカウント (MSA) が必要です。</span><span class="sxs-lookup"><span data-stu-id="d8c0b-119">The link to XDK APIs requires that you have a Microsoft Account(MSA) that has been enabled for Xbox Developer Kit(XDK) access.</span></span>
<span data-ttu-id="d8c0b-120">Windows.Xbox.Storage は、Xbox One 本体の接続ストレージ名前空間の名前です。</span><span class="sxs-lookup"><span data-stu-id="d8c0b-120">Windows.Xbox.Storage is the name of the Connected Storage namespace for Xbox One consoles.</span></span>


## <a name="c-uwp-sample"></a><span data-ttu-id="d8c0b-121">C# UWP のサンプル</span><span class="sxs-lookup"><span data-stu-id="d8c0b-121">C# UWP sample</span></span>

<span data-ttu-id="d8c0b-122">XDK ゲームと UWP アプリでは異なる API を使うことがありますが、UWP API はかなり細かく XDK API に倣っています。</span><span class="sxs-lookup"><span data-stu-id="d8c0b-122">While XDK games and UWP apps may use different APIs, the UWP API is modeled after the XDK API very closely.</span></span> <span data-ttu-id="d8c0b-123">データを削除するには、名前空間とクラス名の変更を書き留めると同時に同じ基本的な手順に従う必要があります。</span><span class="sxs-lookup"><span data-stu-id="d8c0b-123">To delete data you will still need to follow the same basic steps while making note of some namespace and class name changes.</span></span> <span data-ttu-id="d8c0b-124">名前空間 `Windows::Xbox::Storage` を使う代わりに、`Windows.Gaming.XboxLive.Storage` を使います。</span><span class="sxs-lookup"><span data-stu-id="d8c0b-124">Instead of using the namespace `Windows::Xbox::Storage` you will use `Windows.Gaming.XboxLive.Storage`.</span></span> <span data-ttu-id="d8c0b-125">クラス `ConnectedStorageSpace` は `GameSaveProvider` と同等です。</span><span class="sxs-lookup"><span data-stu-id="d8c0b-125">The class `ConnectedStorageSpace`, is equivalent to `GameSaveProvider`.</span></span> <span data-ttu-id="d8c0b-126">クラス `ConnectedStorageContainer` は `GameSaveContainer` と同等です。</span><span class="sxs-lookup"><span data-stu-id="d8c0b-126">The class `ConnectedStorageContainer` is equivalent to `GameSaveContainer`.</span></span> <span data-ttu-id="d8c0b-127">これらの変更については、「[XDK から UWP への Xbox Live コードの移植](../../using-xbox-live/porting-xbox-live-code-from-xdk-to-uwp.md)」の「接続ストレージ」で詳しく説明されています。</span><span class="sxs-lookup"><span data-stu-id="d8c0b-127">These changes are further detailed in the Connected Storage Section of [Porting Xbox Live Code From XDK to UWP](../../using-xbox-live/porting-xbox-live-code-from-xdk-to-uwp.md).</span></span>

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
//string name (name of container to be created) 

//DELETE A BLOB
//form an array of strings containing the blob names you would like to delete.
string[] blobsToDelete = new string[] { c_saveBlobName };

//Call SubmitUpdatesAsync with the dictionary of the names of blobs to delete as the second parameter.
GameSaveOperationResult gameSaveOperationResult = await gameSaveContainer.SubmitUpdatesAsync(null, blobsToDelete, c_saveContainerDisplayName);
//Parameters
//IReadOnlyDictionary<String, IBuffer> blobsToWrite
//IEnumerable<string> blobsToDelete
//string displayName

//Check status of the operation to ensure successful delete.
if(gameSaveOperationResult.Status == GameSaveErrorStatus.Ok)
{
    //Successful Deletion Logic
}
else
{
    //handle failed deletion logic. 
}

//DELETE A SAVE CONTAINER
GameSaveOperationResult deleteContainerResult = await gameSaveProvider.DeleteContainerAsync(c_saveContainerName);
//Parameter
//string name (name of container to be deleted)

//Check status of the operation to ensure successful delete.
if(deleteContainerResult.Status == GameSaveErrorStatus.Ok)
{
    //Successful Deletion Logic
}
else
{
    //handle failed deletion logic. 
}
```

<span data-ttu-id="d8c0b-128">UWP アプリの接続ストレージ API については、「[Xbox Live API リファレンス](https://docs.microsoft.com/en-us/uwp/api/windows.gaming.xboxlive.storage)」で説明されています。</span><span class="sxs-lookup"><span data-stu-id="d8c0b-128">Connected Storage APIs for UWP apps are documented in the [Xbox Live API reference](https://docs.microsoft.com/en-us/uwp/api/windows.gaming.xboxlive.storage).</span></span>
<span data-ttu-id="d8c0b-129">接続ストレージを使う別のサンプルについては、[Xbox Live API のサンプル Game Save プロジェクトに関するページ](https://github.com/Microsoft/xbox-live-samples/tree/master/Samples/ID%40XboxSDK/GameSave)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d8c0b-129">To see another sample that uses Connected Storage check out the [Xbox Live API Samples Game Save project](https://github.com/Microsoft/xbox-live-samples/tree/master/Samples/ID%40XboxSDK/GameSave).</span></span>
