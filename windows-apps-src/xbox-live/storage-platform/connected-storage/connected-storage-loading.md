---
title: 接続ストレージを使ったデータの読み込み
author: aablackm
description: 接続ストレージを使ってデータを読み込む方法について説明します。
ms.assetid: c660a456-fe7d-453a-ae7b-9ecaa2ba0a15
ms.author: aablackm
ms.date: 02/27/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one, 接続ストレージ
ms.localizationpriority: medium
ms.openlocfilehash: d3252ad2ffb9145088f38f4a8d6c7c5ebc94e9e5
ms.sourcegitcommit: d10fb9eb5f75f2d10e1c543a177402b50fe4019e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/12/2018
ms.locfileid: "4571779"
---
# <a name="use-connected-storage-to-load-data"></a>接続ストレージを使ったデータの読み込み

非同期のデータ読み取りは、接続ストレージの `ReadAsync` または `GetAsync` メソッドを使用して行います。

### <a name="to-load-data-from-connected-storage"></a>接続ストレージからデータを読み込むには

1.  `GetForUserAsync` を呼び出してユーザーの `ConnectedStorageSpace` を取得します。

    XDK の例では、複数のユーザーの `ConnectedStorageSpace` オブジェクトの管理を容易にするために、返される `ConnectedStorageSpace` がマップに追加されています。

2.  `ConnectedStorageContainer` を作成するには、`ConnectedStorageSpace` で `CreateContainer` を呼び出します。
3.  `ConnectedStorageContainer` で `ReadAsync` または `GetAsync` を呼び出して、データを取得します。 `ReadAsync` ではバッファーを渡す必要があります。一方、`GetAsync` は、読み取られるデータを格納するための新しいバッファーを割り当てます。

## <a name="c-xdk-sample"></a>C++ XDK のサンプル

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

XDK .chm ファイルで説明されている XDK 接続ストレージ API は、パス **Xbox ONE XDK >> API リファレンス >> プラットフォーム API リファレンス >> システム API リファレンス >> Windows.Xbox.Storage** にあります。
XDK API については、[developer.microsoft.com サイト](https://developer.microsoft.com/en-us/games/xbox/docs/xdk/storage-xbox-microsoft-n)でも説明されています。
XDK API へのリンクを開くには、Xbox 開発キット (XDK) へのアクセスが有効になっている Microsoft アカウント (MSA) が必要です。
Windows.Xbox.Storage は、Xbox One 本体の接続ストレージ名前空間の名前です。

## <a name="c-uwp-sample"></a>C# UWP のサンプル

XDK ゲームと UWP アプリでは異なる API を使うことがありますが、UWP API はかなり細かく XDK API に倣っています。 データを読み込むには、名前空間とクラス名の変更を書き留めると同時に同じ基本的な手順に従う必要があります。 名前空間 `Windows::Xbox::Storage` を使う代わりに、`Windows.Gaming.XboxLive.Storage` を使います。 クラス `ConnectedStorageSpace` は `GameSaveProvider` と同等です。 クラス `ConnectedStorageContainer` は `GameSaveContainer` と同等です。 これらの変更については、「[XDK から UWP への Xbox Live コードの移植](../../using-xbox-live/porting-xbox-live-code-from-xdk-to-uwp.md)」の「接続ストレージ」で詳しく説明されています。

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

UWP アプリの接続ストレージ API については、「[Xbox Live API リファレンス](https://docs.microsoft.com/en-us/uwp/api/windows.gaming.xboxlive.storage)」で説明されています。
接続ストレージを使う別のサンプルについては、[Xbox Live API のサンプル Game Save プロジェクトに関するページ](https://github.com/Microsoft/xbox-live-samples/tree/master/Samples/ID%40XboxSDK/GameSave)をご覧ください。