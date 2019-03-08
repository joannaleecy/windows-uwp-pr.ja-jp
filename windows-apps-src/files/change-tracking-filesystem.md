---
title: ファイル システムの変更のバック グラウンドでの追跡
description: システム内のユーザーを移動して、ファイルの変更と、バック グラウンドでフォルダーを追跡する方法について説明します。
ms.date: 12/19/2018
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: b0ec7762fd64f0f0b8de65faa1aaf079bdaba3a3
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57621577"
---
# <a name="track-file-system-changes-in-the-background"></a>ファイル システムの変更のバック グラウンドでの追跡

**重要な API**

-   [**StorageLibraryChangeTracker**](https://docs.microsoft.com/uwp/api/Windows.Storage.StorageLibraryChangeTracker)
-   [**StorageLibraryChangeReader**](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrarychangereader)
-   [**StorageLibraryChangedTrigger**](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Background.StorageLibraryContentChangedTrigger)
-   [**StorageLibrary**](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrary)

[ **StorageLibraryChangeTracker** ](https://docs.microsoft.com/uwp/api/Windows.Storage.StorageLibraryChangeTracker)クラスは、システム内のユーザーを移動して、ファイルとフォルダーの変更を追跡するためにアプリを使用できます。 使用して、 **StorageLibraryChangeTracker**クラス、アプリを追跡できます。

- ファイル操作などの追加、削除、変更します。
- 名前変更や削除などのフォルダーの操作。
- ファイルとフォルダー、ドライブに移動します。

このガイドを使用して、変更トラッカーを操作するためのプログラミング モデルについて説明します、いくつかのサンプル コードを表示し、によって追跡されるファイルの操作の種類を理解する**StorageLibraryChangeTracker**します。

**StorageLibraryChangeTracker**ユーザー ライブラリ、または任意のフォルダーをローカル コンピューターで動作します。 これにより、セカンダリのドライブまたはリムーバブル ドライブが含まれていますが、NAS のドライブまたはネットワーク ドライブは含まれません。

## <a name="using-the-change-tracker"></a>変更の追跡ツールを使用します。

変更の追跡ツールは、最後に保存する循環バッファーとしてシステムに実装されて*N*ファイル システム操作。 アプリは、バッファーからの変更を読み取るし、それらを独自の経験に処理できます。 アプリが処理されるときに、変更をマークされことはありませんが、変更を完了すると再び表示されます。

フォルダーの変更の追跡ツールを使用するには、次の手順に従います。

1. フォルダーの変更の追跡を有効にします。
2. 変更を待ちます。
3. 変更を読み取る。
4. 変更を受け入れます。

次のセクションでは、各コード例をいくつかの手順説明します。 完全なコード サンプルは、この記事の最後で提供されます。

### <a name="enable-the-change-tracker"></a>変更の追跡を有効にします。

変更の追跡、特定のライブラリを求めていることをシステムに通知する、アプリが実行する必要がある最初のことです。 これは、呼び出すことで、 [**を有効にする**](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrarychangetracker.enable)関心のあるライブラリの変更の追跡ツールのメソッド。

```csharp
StorageLibrary videosLib = await StorageLibrary.GetLibraryAsync(KnownLibraryId.Videos);
StorageLibraryChangeTracker videoTracker = videosLib.ChangeTracker;
videoTracker.Enable();
```

いくつかの重要な注意事項:

- アプリが、マニフェストで適切なライブラリを作成する前に権限を持っているかどうかを確認、 [ **StorageLibrary** ](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrary)オブジェクト。 参照してください[ファイル アクセス許可](https://docs.microsoft.com/en-us/windows/uwp/files/file-access-permissions)の詳細。
- [**有効にする**](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrarychangetracker.enable)がスレッド セーフや、ポインターはリセットされません (これについては後で) 必要な回数だけ呼び出すことができます。

![空の変更の追跡ツールを有効にします。](images/changetracker-enable.png)

### <a name="wait-for-changes"></a>変更の待機

変更の追跡ツールが初期化された後は、すべてのアプリが実行されていないときにも、ライブラリ内に発生する操作を記録する開始されます。 登録することによって変更がある任意の時間をアクティブにするアプリを登録できます、 [ **StorageLibraryChangedTrigger** ](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Background.StorageLibraryContentChangedTrigger)イベント。

![アプリを読み取ることがなく変更トラッカーに追加される変更](images/changetracker-waiting.png)

### <a name="read-the-changes"></a>変更を読み取る

アプリでは、変更の追跡ツールからの変更をポーリングし、し、最後にチェックしてから、変更の一覧を受信できます。 次のコードでは、変更の追跡ツールからの変更の一覧を取得する方法を示します。

```csharp
StorageLibrary videosLibrary = await StorageLibrary.GetLibraryAsync(KnownLibraryId.Videos);
videosLibrary.ChangeTracker.Enable();
StorageLibraryChangeReader videoChangeReader = videosLibrary.ChangeTracker.GetChangeReader();
IReadOnlyList changeSet = await changeReader.ReadBatchAsync();
```

アプリは、独自のエクスペリエンスまたは必要に応じて、データベースに変更の処理を担当し、

![変更の追跡ツールから、アプリのデータベースへの変更の読み取り](images/changetracker-reading.png)

> [!TIP]
> 有効にする 2 つ目の呼び出しは、アプリが変更を読み取り中に、ユーザーがライブラリに別のフォルダーを追加する場合は、競合状態に対する防御です。 余分な呼び出しなし**を有効にする**ユーザーが各自のライブラリ内のフォルダーを変更する場合は、コードを ecSearchFolderScopeViolation (0x80070490) で失敗

### <a name="accept-the-changes"></a>変更を確定します。

アプリが完了したら、変更を処理するを呼び出すことによってこれらの変更を今後表示しないシステムに通知が必要があります、 [ **AcceptChangesAsync** ](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrarychangereader.acceptchangesasync)メソッド。

```csharp
await changeReader.AcceptChangesAsync();
```

![もう一度表示することは、読むとして変更をマークします。](images/changetracker-accepting.png)

アプリはようになりました変更の受信のみ新しい変更の追跡ツールの今後の読み取り時にします。

- 呼び出しの間の変更が生じた場合[ **ReadBatchAsync** ](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrarychangereader.readbatchasync)と[AcceptChangesAsync](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrarychangereader.acceptchangesasync)ポインターになります、アプリが表示される最新の変更に移すことのみです。 その他の変更は引き続き使用できます、次回呼び出し**ReadBatchAsync**します。
- アプリの呼び出しに時間を次の変更の同じセットを返すシステムにより、変更を受け入れていません**ReadBatchAsync**します。

## <a name="important-things-to-remember"></a>重要な注意点

変更の追跡ツールを使用する場合は、すべてが正しく動作するかどうかを確認する点に注意する必要がありますをいくつかの点。

### <a name="buffer-overruns"></a>バッファー オーバーラン

アプリが読み取ることができるまでに、システムで発生したすべての操作を保持するために、変更トラッカーのための十分な領域を予約するようにしては、非常に簡単に循環バッファがそれ自体を上書きする前に、アプリでの変更に読み取るしないシナリオを考えてみましょう。 特に場合、ユーザーがバックアップからデータを復元または、電話のカメラから画像の大規模なコレクションを同期します。

この場合、 **ReadBatchAsync**はエラー コードを返します[ **StorageLibraryChangeType.ChangeTrackingLost**](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrarychangetype)します。 アプリでは、このエラー コードを受信する場合は、次の点が考えられます。

* バッファーでは、前回をもたらして上書き自体。 トラッカーからの情報は不完全になりますが、ライブラリの再クロールする最善のです。
* 呼び出すまでは、変更の追跡ツールはそれ以上変更を返しません。 [**リセット**](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrarychangetracker.reset)します。 アプリでは、リセットを呼び出し、ポインターは最新の変更に移動して追跡が正常に再開されます。

まれに、これらのケースを取得する必要があるが、ユーザーに多数の周囲、ディスク上のファイルを移動のシナリオで、変更追跡が巨大になるし、大量の記憶域を占有したくないです。 これで Windows カスタマー エクスペリエンスを破壊しない中に大量のファイル システム操作に対応するためのアプリできるようにする必要があります。

### <a name="changes-to-a-storagelibrary"></a>StorageLibrary への変更

[ **StorageLibrary** ](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrary)クラスが他のフォルダーを含むルート フォルダーの仮想グループとして存在します。 ファイル システムの変更の追跡ツールでは、これを調整、次の選択肢を行いました。

- ライブラリのルート フォルダーの子孫に対する変更は、変更トラッカーで表現されます。 使用してライブラリのルート フォルダーを確認することができます、 [**フォルダー** ](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrary.folders)プロパティ。
- 追加または削除からのルート フォルダー、 **StorageLibrary** (を通じて[ **RequestAddFolderAsync** ](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrary.requestaddfolderasync)と[ **RequestRemoveFolderAsync** ](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrary.requestremovefolderasync)) エントリを変更トラッカーが作成されません。 により、これらの変更を追跡できます、 [ **DefinitionChanged** ](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrary.definitionchanged)イベントまたはライブラリを使用して、ルート フォルダーを列挙することによって、 [**フォルダー** ](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrary.folders)プロパティ。
- ライブラリに既に含まれているコンテンツのフォルダーを追加する場合がありますされません変更を生成された通知のほか、変更の追跡ツール エントリ。 そのフォルダーの子孫が変更されたは、通知を生成し、トラッカー エントリを変更します。

### <a name="calling-the-enable-method"></a>有効にするメソッドを呼び出す

アプリを呼び出す必要があります[**を有効にする**](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrarychangetracker.enable)ファイル システムの追跡を開始するとすぐに、変更のすべての列挙体の前にします。 これにより、すべての変更は、変更トラッカーによってキャプチャされますが保証されます。  

## <a name="putting-it-together"></a>これをまとめる

次のビデオ ライブラリからの変更の登録し、変更の追跡ツールからの変更のプルを開始するために使用するすべてのコードに示します。

```csharp
private async void EnableChangeTracker()
{
    StorageLibrary videosLib = await StorageLibrary.GetLibraryAsync(KnownLibraryId.Videos);
    StorageLibraryChangeTracker videoTracker = videosLib.ChangeTracker;
    videoTracker.Enable();
}

private async void GetChanges()
{
    StorageLibrary videosLibrary = await StorageLibrary.GetLibraryAsync(KnownLibraryId.Videos);
    videosLibrary.ChangeTracker.Enable();
    StorageLibraryChangeReader videoChangeReader = videosLibrary.ChangeTracker.GetChangeReader();
    IReadOnlyList changeSet = await changeReader.ReadBatchAsync();


    //Below this line is for the blog post. Above the line is for the magazine
    foreach (StorageLibraryChange change in changeSet)
    {
        if (change.ChangeType == StorageLibraryChangeType.ChangeTrackingLost)
        {
            //We are in trouble. Nothing else is going to be valid.
            log("Resetting the change tracker");
            videosLibrary.ChangeTracker.Reset();
            return;
        }
        if (change.IsOfType(StorageItemTypes.Folder))
        {
            await HandleFileChange(change);
        }
        else if (change.IsOfType(StorageItemTypes.File))
        {
            await HandleFolderChange(change);
        }
        else if (change.IsOfType(StorageItemTypes.None))
        {
            if (change.ChangeType == StorageLibraryChangeType.Deleted)
            {
                RemoveItemFromDB(change.Path);
            }
        }
    }
    await changeReader.AcceptChangesAsync();
}
```
