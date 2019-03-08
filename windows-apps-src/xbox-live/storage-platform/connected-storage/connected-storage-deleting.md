---
title: 接続ストレージを使ったデータの削除
description: 接続ストレージを使って BLOB およびコンテナー データを削除する方法について説明します。
ms.assetid: ccf7488c-5d55-480e-b3aa-412220d03104
ms.date: 02/27/2018
ms.topic: article
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one, 接続ストレージ
ms.localizationpriority: medium
ms.openlocfilehash: 756de46d05cdbf64d85491b4e8c6f783122f2356
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57601317"
---
# <a name="use-connected-storage-to-delete-data"></a>接続ストレージを使ったデータの削除

データ BLOB は、ユーザーの `ConnectedStorageSpace` で `ConnectedStorageContainer` を作成し、blobsToDelete パラメーターの削除する名前付き BLOB を表す文字列の一覧を示すコンテナーで `SubmitUpdatesAsync` メソッドを呼び出すと非同期的に削除されます。

データ コンテナーは、`ConnectedStorageContainer` を作成してその `DeleteContainerAsync` メソッドを呼び出すと非同期的に削除されます。

## <a name="to-delete-blob-data-from-connected-storage"></a>接続ストレージから BLOB データを削除するには

1.  `GetForUserAsync` を呼び出してユーザーの `ConnectedStorageSpace` オブジェクトを取得します。

    XDK の例では、複数のユーザーの `ConnectedStorageSpace` オブジェクトの管理を容易にするために、返される `ConnectedStorageSpace` オブジェクトがマップに追加されています。

2.  `ConnectedStorageContainer` オブジェクトを作成するには、`ConnectedStorageSpace` オブジェクトで `CreateContainer` を呼び出します。
3.  `ConnectedStorageContainer` オブジェクトで `SubmitUpdatesAsync` を呼び出します。

## <a name="to-delete-a-container-from-connected-storage"></a>接続ストレージからコンテナーを削除するには

1.  `GetForUserAsync` を呼び出してユーザーの `ConnectedStorageSpace` オブジェクトを取得します。

    XDK の例では、複数のユーザーの `ConnectedStorageSpace` オブジェクトの管理を容易にするために、返される `ConnectedStorageSpace` オブジェクトがマップに追加されています。

2.  ConnectedStorageSpace メソッドの `DeleteContainerAsync` メソッドを呼び出します。

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

パスの下の XDK .chm ファイルに記載されている XDK 接続されている Storage Api を確認できます。**1 つの XDK Xbox >> API リファレンス >> プラットフォーム API のリファレンス >> システム API リファレンス >> Windows.Xbox.Storage**します。
XDK API については、[developer.microsoft.com サイト](https://developer.microsoft.com/en-us/games/xbox/docs/xdk/storage-xbox-microsoft-n)でも説明されています。
XDK API へのリンクを開くには、Xbox 開発キット (XDK) へのアクセスが有効になっている Microsoft アカウント (MSA) が必要です。
Windows.Xbox.Storage は、Xbox One 本体の接続ストレージ名前空間の名前です。


## <a name="c-uwp-sample"></a>C# UWP のサンプル

XDK ゲームと UWP アプリでは異なる API を使うことがありますが、UWP API はかなり細かく XDK API に倣っています。 データを削除するには、名前空間とクラス名の変更を書き留めると同時に同じ基本的な手順に従う必要があります。 名前空間 `Windows::Xbox::Storage` を使う代わりに、`Windows.Gaming.XboxLive.Storage` を使います。 クラス `ConnectedStorageSpace` は `GameSaveProvider` と同等です。 クラス `ConnectedStorageContainer` は `GameSaveContainer` と同等です。 これらの変更については、「[XDK から UWP への Xbox Live コードの移植](../../using-xbox-live/porting-xbox-live-code-from-xdk-to-uwp.md)」の「接続ストレージ」で詳しく説明されています。

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

UWP アプリの接続ストレージ API については、「[Xbox Live API リファレンス](https://docs.microsoft.com/en-us/uwp/api/windows.gaming.xboxlive.storage)」で説明されています。
接続ストレージを使う別のサンプルについては、[Xbox Live API のサンプル Game Save プロジェクトに関するページ](https://github.com/Microsoft/xbox-live-samples/tree/master/Samples/ID%40XboxSDK/GameSave)をご覧ください。
