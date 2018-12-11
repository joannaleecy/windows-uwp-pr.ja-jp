---
title: バック グラウンドでファイル システムの変更を追跡します。
description: システムで、ユーザーが移動すると、ファイルの変更や、バック グラウンドでのフォルダーを追跡する方法について説明します。
ms.date: 11/20/2018
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: e90692753924572a932767b9c188ed6d24f94593
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8926780"
---
# <a name="track-file-system-changes-in-the-background"></a>バック グラウンドでファイル システムの変更を追跡します。

[StorageLibraryChangeTracker](https://docs.microsoft.com/uwp/api/Windows.Storage.StorageLibraryChangeTracker)クラスには、システムで、ユーザーが移動すると、ファイルやフォルダーに変更を追跡するアプリができます。 **StorageLibraryChangeTracker**クラスを使用して、アプリを追跡できます。

- ファイル操作などの追加、削除、変更します。
- 名前の変更や削除などの操作をフォルダーです。
- ファイルとフォルダー、ドライブに移動します。

変更トラッカーを操作するためのプログラミング モデルについて説明します、いくつかのサンプル コードを表示および**StorageLibraryChangeTracker**で管理されるファイル操作の種類を理解するには、このガイドを使用します。

**StorageLibraryChangeTracker**は、ユーザーのライブラリ、または任意のフォルダーをローカル コンピューターで動作します。 これにより、セカンダリ ドライブやリムーバブル ドライブが含まれていますが、NAS ドライブやネットワーク ドライブには含まれません。

## <a name="using-the-change-tracker"></a>変更の追跡ツールを使用します。

変更のトラッカーは、システムで最後の*n 個*のファイル システム操作を格納する循環バッファーとして実装されます。 アプリは、バッファーからの変更を読み取るし、独自のエクスペリエンスにそれらを処理することができます。 アプリが終了する処理は、変更をマークすることはありませんが、変更をもう一度表示します。

フォルダーの変更の追跡ツールを使用するには、次の手順に従います。

1. 変更のフォルダーの追跡を有効にします。
2. 変更を待ちます。
3. 読み取りを変更します。
4. 変更を受け入れます。

次のセクションでは、これらのコード例をいくつかの手順を説明します。 完全なコード サンプルは、記事の最後に提供されます。

### <a name="enable-the-change-tracker"></a>変更の追跡を有効にします。

まず、アプリが実行する必要がある変更の特定のライブラリの追跡を求めていることをシステムに指示することです。 これは、関心のあるライブラリの変更トラッカーで[有効にする](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrarychangetracker.enable)メソッドを呼び出すことによって実行されます。

```csharp
StorageLibrary videosLib = await StorageLibrary.GetLibraryAsync(KnownLibraryId.Videos);
StorageLibraryChangeTracker videoTracker = videosLib.ChangeTracker;
videoTracker.Enable();
```

いくつかの重要な注意事項:

- アプリでは、マニフェストに適切なライブラリにアクセス許可を持つ[StorageLibrary](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrary)オブジェクトを作成する前に確認します。 詳細については、[ファイルへのアクセス許可](https://docs.microsoft.com/en-us/windows/uwp/files/file-access-permissions)を参照してください。
- [有効にする](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrarychangetracker.enable)スレッド セーフであるは、ポインターを使用してリセットされませんおよびとして (詳細については後でこの) して、何回呼び出すことができます。

![空の変更の追跡ツールを有効にします。](images/changetracker-enable.png)

### <a name="wait-for-changes"></a>変更を待つ

変更のトラッカーは、初期化した後は、すべてのアプリが実行されている場合でも、ライブラリ内に発生する操作の記録が開始されます。 アプリは、 [StorageLibraryChangedTrigger](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Background.StorageLibraryContentChangedTrigger)イベントに登録することにより、変更はいつでもアクティブ化を登録できます。

![変更を読むためにアプリを変更トラッカーに追加します。](images/changetracker-waiting.png)

### <a name="read-the-changes"></a>変更内容を読み取る

アプリの変更トラッカーから変更をポーリングし、前回チェックして、変更の一覧が表示されます。 次のコードは、変更トラッカーから変更の一覧を取得する方法を示しています。

```csharp
StorageLibrary videosLibrary = await StorageLibrary.GetLibraryAsync(KnownLibraryId.Videos);
videosLibrary.ChangeTracker.Enable();
StorageLibraryChangeReader videoChangeReader = videosLibrary.ChangeTracker.GetChangeReader();
IReadOnlyList changeSet = await changeReader.ReadBatchAsync();
```

アプリはし、独自のエクスペリエンスまたは必要に応じて、データベースに変更を処理します。

![アプリのデータベースに変更トラッカーから変更内容の読み取り](images/changetracker-reading.png)

> [!TIP]
> ユーザーは、アプリは、変更内容の読み取り中に、ライブラリを別のフォルダーを追加する場合、競合状態から防御する 2 番目の呼び出しを有効にすることです。 余分な呼び出しを**有効に**することがなく、コードは失敗します ecSearchFolderScopeViolation (0x80070490) と、ユーザーが、ライブラリ内のフォルダーを変更する場合

### <a name="accept-the-changes"></a>変更を確定します。

アプリが完了したら、変更を処理するにする必要があります、システムに指示[AcceptChangesAsync](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrarychangereader.acceptchangesasync)メソッドを呼び出すことによってこれらの変更をもう一度表示されることはありません。

```csharp
await changeReader.AcceptChangesAsync();
```

![読み込まれるため、もう一度表示することはそれらの変更としてマークすること](images/changetracker-accepting.png)

アプリは今すぐだけ受け取ります新しい変更、今後変更トラッカーを読み取るとき。

- ポインターになります[ReadBatchAsync](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrarychangereader.readbatchasync)と[AcceptChangesAsync](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrarychangereader.acceptchangesasync)呼び出しの間、変更が発生している場合のみが高度な検出が、アプリの最新の変更をします。 その他の変更も利用できます、次回**ReadBatchAsync**を呼び出します。
- いない変更を受け入れると、次回、アプリが**ReadBatchAsync**を呼び出すのと同じ一連の変更を返すために、システムが発生します。

## <a name="important-things-to-remember"></a>重要な注意事項

変更の追跡ツールを使用する場合は、すべてが正しく動作しているかどうかを確認する点に注意する必要がありますが、いくつかの点があります。

### <a name="buffer-overruns"></a>バッファー オーバーラン

アプリが読み取ることができるまで、システムで発生するすべての操作を保持するために変更トラッカーで十分な空き領域を予約するようにして、循環バッファーがそれ自体を上書きする前に、アプリでの変更に読み取りしませんシナリオを想像する非常に簡単です。 特に場合、ユーザーがデータをバックアップから復元またはカメラ電話から画像の大規模なコレクションを同期します。

この場合、 **ReadBatchAsync**は[StorageLibraryChangeType.ChangeTrackingLost](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrarychangetype)エラー コードを返します。 アプリでは、このエラー コードを受信する場合は、次の点が考えられます。

* バッファーが上書きされて自体前回ことについて説明しました。 トラッカーからの情報は完全になるため、ライブラリを再クロールする最善のことです。
* [リセット](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrarychangetracker.reset)を呼び出すまで変更トラッカーは、複数の変更を返しません。 アプリは、リセットの呼び出し後ポインターは、最新の変更に移動して、追跡が正常に再開されます。

このような場合は、取得するまれな場合がありますが、ユーザーが多数の周囲、ディスク上のファイルを移動はのシナリオでしますたく吹き出しし、多すぎると記憶域を占有するには、変更トラッカーします。 これにより、windows カスタマー エクスペリエンスをつけていない中に大規模なファイル システム操作に応答するようにアプリする必要があります。

### <a name="changes-to-a-storagelibrary"></a>StorageLibrary への変更

[StorageLibrary](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrary)クラスは、他のフォルダーが含まれるルート フォルダーの仮想グループとして存在します。 これを調整ファイル システムの変更の追跡で、次の選択肢が行われます。

- ルートのライブラリ フォルダーの子孫に変更を加えた変更トラッカーで表されます。 [フォルダー](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrary.folders)のプロパティを使って、ルートのライブラリのフォルダーを参照してください。
- 追加または削除するルート フォルダー ( [RequestAddFolderAsync](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrary.requestaddfolderasync)と[RequestRemoveFolderAsync](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrary.requestremovefolderasync)) を通じて**StorageLibrary**では、変更トラッカーのエントリを作成はできません。 [DefinitionChanged](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrary.definitionchanged)イベントを通じて、または[フォルダー](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrary.folders)のプロパティを使って、ライブラリ内のルート フォルダーを列挙することにより、これらの変更を追跡できます。
- 既にコンテンツを持つフォルダーをライブラリに追加する場合がありますされません変更通知または変更のトラッカー エントリが生成されます。 その後に変更をそのフォルダーの子孫は通知を生成し、トラッカーのエントリを変更します。

### <a name="calling-the-enable-method"></a>有効にするメソッドを呼び出す

ファイル システムの追跡を開始するとすぐに、変更がすべて列挙する前に、[有効にする](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrarychangetracker.enable)が、アプリに呼び出す必要があります。 これによりすべての変更は、変更トラッカーによって取得されます。  

## <a name="putting-it-together"></a>これをまとめる

ビデオ ライブラリから変更を登録し、変更の追跡ツールからの変更のプルを開始するために使用するすべてのコードを次に示します。

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
