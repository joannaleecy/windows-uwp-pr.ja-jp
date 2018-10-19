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
ms.sourcegitcommit: 310a4555fedd4246188a98b31f6c094abb33ec60
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/19/2018
ms.locfileid: "5141184"
---
# <a name="connected-storage-loading-on-demand"></a>接続ストレージのオンデマンド読み込み

`GetSyncOnDemandForUserAsync` を使用すると、クラウド バックアップ データを接続ストレージ領域から、一度にまとめてではなく、"オンデマンド" で読み込むことができます。 これにより、保存ファイルが特に大きい場合は、`GetForUserAsync` を使用するよりもパフォーマンスを向上させることができます。

## <a name="to-load-data-from-a-connected-storage-space-on-demand"></a>オンデマンドで接続ストレージ領域からデータを読み込むには

### <a name="1--call-getsyncondemandforuserasync"></a>1: `GetSyncOnDemandForUserAsync` を呼び出します。

これにより、コンテナーの内容ではなく、コンテナーのリストとメタデータをクラウドからダウンロードする部分的な同期がトリガーされます。 この操作は高速なので、適切なネットワーク条件下では、ユーザーには読み込み中の UI は表示されません。

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


### <a name="2--perform-a-container-query-using-getcontainerinfo2async"></a>2: `GetContainerInfo2Async` を使用してコンテナー クエリを実行します。

これにより、3 つの新しいメタデータ フィールドを含む `ContainerInfo2` のコレクションが返されます。

    -   `DisplayName`: 表示名の文字列をパラメーターとして受け取る `SubmitUpdatesAsync` のオーバーロードを使用して作成した表示名。 常にこのフィールドを使用して、ユーザーにわかりやすい名前を格納することをお勧めします。
    -   `LastModifiedTime`: このコンテナーが最後に変更された時刻。 ローカルとリモートのタイムスタンプが競合する場合は、リモートのタイムスタンプが使用されます。
    -   `NeedsSync`: このコンテナーのデータをクラウドからダウンロードする必要があるかどうかを示すブール値。

    この追加のメタデータを使用することで、実際にはクラウドからの完全ダウンロードを実行せずに、セーブ データについての主要な情報 (名前、最後に使用された時刻、選択した場合にダウンロードが必要かどうかなど) をユーザーに表示できます。

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

### <a name="3--trigger-a-sync"></a>3: 同期トリガー

接続ストレージの同期は、次のいずれかの既存の接続ストレージ API を呼び出すことによってトリガーされます。

**C++**

    -   BlobInfoQueryResult::GetBlobInfoAsync
    -   BlobInfoQueryResult::GetItemCountAsync
    -   ConnectedStorageContainer::GetAsync
    -   ConnectedStorageContainer::ReadAsync
    -   ConnectedStorageSpace::DeleteContainerAsync

**C#**

    -   GameSaveBlobInfoQuery.GetBlobInfoAsync
    -   GameSaveBlobInfoQuery.GetItemCountAsync
    -   GameSaveContainer.GetAsync
    -   GameSaveContainer.ReadAsync
    -   GameSaveProvider.DeleteContainerAsync

これにより、選択したコンテナーのデータがダウンロードされていることを示す通常の同期 UI と進行状況バーがユーザーに表示されます。 選択したコンテナーのデータのみが同期され、その他のコンテナーのデータはダウンロードされません。

オンデマンドによる同期のコンテキストでこれらの API を呼び出すと、それらの操作のすべてで、以下の新しいエラー コードが生成されます。

-   `ConnectedStorageErrorStatus::ContainerSyncFailed`(UWP C# API の `GameSaveErrorStatus.ContainerSyncFailed`): このエラーは、操作が失敗し、コンテナーをクラウドと同期できなかったことを示します。 ほとんどの場合、同期に失敗するのはユーザーのネットワークの状態が原因です。 その場合、ユーザーはネットワークを調整した後にもう一度やり直すか、または同期を必要としないコンテナーを使用することを選択できます。これらのオプションのいずれかを UI で選択できる必要があります。 システム UI の再試行のダイアログ ボックスはユーザーに既に表示されているので、再試行のダイアログ ボックスは必要ありません。

-   `ConnectedStorageErrorStatus::ContainerNotInSync`(UWP C# API の `GameSaveErrorStatus.ContainerNotInSync`): このエラーは、同期されていないコンテナーへの書き込みをタイトルが誤って実行しようとしたことを示します。 NeedsSync フラグが true に設定されているコンテナーに対して `ConnectedStorageContainer::SubmitUpdatesAsync`(UWP C# API の `GameSaveContainer.SubmitUpdatesAsync`) を呼び出すことはできません。 コンテナーに書き込む前に、まず、同期をトリガーするためにそのコンテナーを読み取る必要があります。 コンテナーの読み取りを行わずにそこに書き込む場合、そのタイトルは、ユーザーの進行状況を失うかもしれないという欠陥を持つ可能性があります。

この動作は、ユーザーがオフラインでプレイする場合とは異なります。 オフライン時は、コンテナーが同期されているかどうかは示されないので、後で競合を解決するのはユーザーの責任となります。 ただし、この場合、システムはユーザーが同期を必要としていることを把握しているので、ユーザーが古いコンテナーを使用して間違った状態にすることは許可されません (ただし、ユーザーが希望する場合は、タイトルを再起動してオフラインでプレイすることもできます)。

### <a name="4--use-the-rest-of-the-connected-storage-api-as-normal"></a>4: 接続ストレージ API の残り部分を通常どおりに使用します。

接続ストレージの動作は、オンデマンドで同期するときもそのままです。
