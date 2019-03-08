---
title: ファイルに書き込むためのベスト プラクティス
description: FileIO と PathIO クラスのメソッドを記述するさまざまなファイルを使用するためのベスト プラクティスについて説明します。
ms.date: 02/06/2019
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: f8bed97e060015f92ff95c9f7d797bbcb83db431
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57605837"
---
# <a name="best-practices-for-writing-to-files"></a>ファイルに書き込むためのベスト プラクティス

**重要な API**

* [**FileIO クラス**](https://docs.microsoft.com/uwp/api/Windows.Storage.FileIO)
* [**PathIO クラス**](https://docs.microsoft.com/uwp/api/windows.storage.pathio)

開発者の一般的な問題のセットに実行を使用する場合、**書き込み**のメソッド、 [ **FileIO** ](https://docs.microsoft.com/uwp/api/Windows.Storage.FileIO)と[ **PathIO**](https://docs.microsoft.com/uwp/api/windows.storage.pathio)クラス ファイル システム I/O 操作を実行します。 たとえば、一般的な問題が含まれます。

• ファイルには、メソッドのいずれかを呼び出して例外を受け取った • アプリ部分的に書き込まれます。 • の背後にある操作のままにします。ターゲット ファイル名のようなファイル名を持つ TMP ファイルを削除します。

**書き込み**のメソッド、 [ **FileIO** ](https://docs.microsoft.com/uwp/api/Windows.Storage.FileIO)と[ **PathIO** ](https://docs.microsoft.com/uwp/api/windows.storage.pathio)クラスには、次が含まれます。

* **WriteBufferAsync**
* **WriteBytesAsync**
* **WriteLinesAsync**
* **WriteTextAsync**

 この記事では、それらを使用するタイミングと方法は開発者のこれらのメソッドの動作に関する詳細情報をより深く理解します。 この記事では、ガイドラインを提供し、すべての使用可能なファイル I/O の問題に対するソリューションを提供しようとはしません。 

> [!NOTE]
> この記事の重点、 **FileIO**メソッドの例やディスカッション。 ただし、 **PathIO**メソッドと同様のパターンに従うし、この記事のガイダンスのほとんどがもこれらのメソッドに適用されます。 

## <a name="conveience-vs-control"></a>コントロールと Conveience

A [ **StorageFile** ](https://docs.microsoft.com/uwp/api/windows.storage.storagefile)オブジェクトは、ネイティブの Win32 プログラミング モデルのようなファイル ハンドルではありません。 代わりに、 [ **StorageFile** ](https://docs.microsoft.com/uwp/api/windows.storage.storagefile)はその内容を操作するメソッドを使用するファイルの表現です。

この概念を理解することは、I/O を実行する場合に役立ちます、 **StorageFile**します。 など、[ファイルへの書き込み](quickstart-reading-and-writing-files.md#writing-to-a-file)ファイルへの書き込みに 3 つの方法について説明します。

* 使用して、 [ **FileIO.WriteTextAsync** ](https://docs.microsoft.com/uwp/api/windows.storage.fileio.writetextasync)メソッド。
* バッファーを作成し、呼び出すことによって、 [ **FileIO.WriteBufferAsync** ](https://docs.microsoft.com/en-us/uwp/api/windows.storage.fileio.writebufferasync)メソッド。
* ストリームを使用して 4 つのステップ モデル:
  1. [開いている](https://docs.microsoft.com/uwp/api/windows.storage.storagefile.openasync)ファイル ストリームを取得します。
  2. [取得](https://docs.microsoft.com/uwp/api/windows.storage.streams.irandomaccessstream.getoutputstreamat)出力ストリーム。
  3. 作成、 [ **datawriter の各**](https://docs.microsoft.com/uwp/api/windows.storage.streams.datawriter)オブジェクトし、対応する呼び出し**書き込み**メソッド。
  4. [コミット](https://docs.microsoft.com/uwp/api/windows.storage.streams.datawriter.storeasync)データ ライターのデータと[フラッシュ](https://docs.microsoft.com/uwp/api/windows.storage.streams.ioutputstream.flushasync)出力ストリーム。

最初の 2 つのシナリオとは、アプリで最もよく使用されるものです。 1 回の操作でファイルへの書き込みが簡単にコーディングし、保守、およびファイル I/O の複雑さの多くを扱うからアプリの役目が削除されます。 ただし、この便利な機能はコストがかかります。 制御操作全体や特定の時点でエラーをキャッチする機能が失われる。

## <a name="the-transactional-model"></a>トランザクション モデル

**書き込み**のメソッド、 [ **FileIO** ](https://docs.microsoft.com/uwp/api/Windows.Storage.FileIO)と[ **PathIO** ](https://docs.microsoft.com/uwp/api/windows.storage.pathio)クラス、3 番目の書き込み時に、手順をラップします。追加のレイヤーで、上記で説明したモデル。 このレイヤーは、ストレージ トランザクションにカプセル化します。

データの書き込み中に問題が発生した場合、元のファイルの整合性を保護する、**書き込み**メソッドを使用してファイルを開くことで、トランザクションのモデルを使用して[ **OpenTransactedWriteAsync**](https://docs.microsoft.com/uwp/api/windows.storage.storagefile.opentransactedwriteasync). このプロセスを作成、 [ **StorageStreamTransaction** ](https://docs.microsoft.com/uwp/api/windows.storage.storagestreamtransaction)オブジェクト。 Api と同様の方法を次データの書き込みはこのトランザクション オブジェクトの作成後、[ファイル アクセス](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/FileAccess)サンプルやコード例で、 [ **StorageStreamTransaction** ](https://docs.microsoft.com/uwp/api/windows.storage.storagestreamtransaction)記事。

次の図で実行される基になるタスクを示しています。、、 **WriteTextAsync**成功した書き込み操作のメソッド。 この図では、操作の簡略化されたビューを提供します。 たとえば、異なるスレッドでテキストのエンコードと非同期の完了などの手順をスキップします。

![ファイルへの書き込みの UWP API 呼び出しのシーケンス図](images/file-write-call-sequence.svg)

使用する利点、**書き込み**のメソッド、 [ **FileIO** ](https://docs.microsoft.com/uwp/api/Windows.Storage.FileIO)と[ **PathIO** ](https://docs.microsoft.com/uwp/api/windows.storage.pathio)クラスの代わりにストリームを使用してより複雑な 4 つのステップのモデルの次のようには。

* 中間すべてのステップをエラーなどの処理を 1 回の API 呼び出し。
* 問題が発生した場合、元のファイルは保持されます。
* システム状態は保持可能な限りクリーンアップしようとします。

ただし、多く可能な中間一点障害は、障害の可能性が高くがあります。 エラーが発生したときに、プロセスが失敗した場所を理解しにくい場合があります。 次のセクションでは、表示を使用する場合に発生する可能性がエラーのいくつか、**書き込み**メソッドと考えられる解決策を提供します。

## <a name="common-error-codes-for-write-methods-of-the-fileio-and-pathio-classes"></a>FileIO と PathIO クラスの Write メソッドの一般的なエラー コード

このテーブルを使用する場合、アプリの開発者が直面する一般的なエラー コードの表示、**書き込み**メソッド。 表の手順は、前の図の手順に対応します。

|  エラー名 (値)  |  手順  |  原因  |  解決策  |
|----------------------|---------|----------|-------------|
|  ERROR_ACCESS_DENIED (0X80070005)  |  5  |  場合によって、前の操作からの削除元のファイルをマークする可能性があります。  |  操作を再試行します。</br>ファイルへのアクセスが同期されていることを確認します。  |
|  ERROR_SHARING_VIOLATION (0x80070020)  |  5  |  元のファイルが別の排他的書き込みによって開かれます。   |  操作を再試行します。</br>ファイルへのアクセスが同期されていることを確認します。  |
|  ERROR_UNABLE_TO_REMOVE_REPLACED (0x80070497)  |  19-20  |  使用されているために、元のファイル (file.txt) を置き換えられませんでした。 別のプロセスまたは操作は、ファイルへのアクセスを獲得してから、前に、置き換えることができます。  |  操作を再試行します。</br>ファイルへのアクセスが同期されていることを確認します。  |
|  ERROR_DISK_FULL (0X80070070)  |  7, 14, 16, 20  |  トランザクション モデルが、余分なファイルを作成し、これは追加の記憶域を消費します。  |    |
|  ERROR_OUTOFMEMORY (0x8007000E)  |  14, 16  |  これは、複数の未処理の I/O 操作またはより大きなファイル サイズのため発生することができます。  |  ストリームを制御することで詳細な方法は、エラーを解決する可能性があります。  |
|  E_FAIL (0X80004005) |  任意  |  その他  |  操作を再試行します。 まだ失敗する場合は、プラットフォームのエラーがあり、不整合な状態になっているため、アプリが終了する必要があります。 |

## <a name="other-considerations-for-file-states-that-might-lead-to-errors"></a>エラーにつながる可能性のあるファイルの状態に関するその他の考慮事項

によって返されるエラーとは別に、**書き込み**メソッド、ファイルに書き込むときに、アプリに期待をいくつかのガイドラインを示します。

### <a name="data-was-written-to-the-file-if-and-only-if-operation-completed"></a>操作が完了した場合にのみ、データがファイルに書き込まれました。

アプリしないでデータに関するすべての前提条件ファイルの書き込み操作の進行中。 操作が完了する前に、ファイルにアクセスしようとしています。 は、データの矛盾を生じる可能性があります。 アプリは、担当の未処理 I/o 数を追跡する必要があります。

### <a name="readers"></a>Readers

書き込まれるになっているファイルが正常なリーダーによって使用されている場合 (では、開かれた[ **FileAccessMode.Read**](https://docs.microsoft.com/uwp/api/Windows.Storage.FileAccessMode)、それ以降の読み取りは ERROR_OPLOCK_HANDLE_CLOSED (0x80070323) エラーで失敗します。 読み取り中にもう一度ファイルを開くをアプリが再試行することがあります、**書き込み**操作が進行中です。 これを競合状態があります、**書き込み**に置き換えることができませんので、元のファイルを上書きしようとするときは最終的に失敗します。

### <a name="files-from-knownfolders"></a>KnownFolders からのファイル

アプリのいずれかに置かれているファイルへのアクセスを試行している唯一のアプリをできない可能性があります、 [ **KnownFolders**](https://docs.microsoft.com/uwp/api/Windows.Storage.KnownFolders)します。 操作が成功した場合、アプリがファイルに書き込んだ内容が一定に保つように保証ファイルを読み取ろうとした次の時間はありません。 また、共有またはアクセスには、このシナリオでますます一般的になるエラーが拒否されました。

### <a name="conflicting-io"></a>競合している I/O

アプリで使用する場合、同時実行エラーの可能性を下げることができます、**書き込み**メソッドのローカルのデータがいくつか注意が必要でのファイルが必要です。 複数**書き込み**操作に送信される同時に、ファイル、ファイルに最終的にどのようなデータに関する保証はありません。 これを防ぐことをお勧めします、アプリがシリアル化**書き込み**ファイルを操作します。

### <a name="tmp-files"></a>~ TMP ファイル

場合によっては場合 (たとえばアプリが中断または、OS によって終了場合)、操作が強制的に取り消された、トランザクションがコミットまたはいない適切に閉じられました。 ファイルを残すこれを (. ~ TMP) 拡張機能。 (アプリのローカル データに存在する) 場合は、これらの一時ファイルを削除を検討してアプリのアクティブ化を処理するときにします。

## <a name="considerations-based-on-file-types"></a>ファイルの種類に基づくに関する考慮事項

ファイルにアクセス中、頻度や、ファイル サイズの種類に応じてより普及しているいくつかのエラーになります。 一般に、アプリがアクセスできるファイルの 3 つに分類されます。

* ファイルが作成され、アプリのデータをローカル フォルダーにユーザーを編集します。 これらが作成され、アプリを使用している場合にのみ編集して、アプリ内でのみ存在します。
* アプリのメタデータ。 アプリは、独自の状態を追跡するのにこれらのファイルを使用します。
* その他のファイル、アプリがアクセスする機能を宣言されているファイル システム内の場所にします。 いずれかでにあるこれらは通常、 [ **KnownFolders**](https://docs.microsoft.com/uwp/api/Windows.Storage.KnownFolders)します。

アプリは、アプリのパッケージ ファイルの一部であるし、アプリによって排他アクセスがあるため、ファイルの最初の 2 つのカテゴリに対するフル コントロールが。 最後のカテゴリ内のファイル、アプリが、他のアプリと OS のサービスがファイルにアクセスする同時に注意してください必要があります。

アプリによっては、ファイルへのアクセス頻度に変わります。

* 非常に低いです。 通常、これらは、ファイルを開くときに、アプリの起動とが保存した後、アプリが中断されている場合です。
* 低。 これらは、ユーザーが (保存または読み込みなど) での作業を行った具体的にはファイルです。
* 中または高です。 これらは、アプリに更新する必要がありますのデータ (たとえば、自動保存機能または定数のメタデータを追跡) 常にファイルです。

ファイルのサイズ、パフォーマンス データの次のグラフを検討してください、 **WriteBytesAsync**メソッド。 このグラフは、完全な操作とファイル サイズは、管理された環境でのファイル サイズあたり 10,000 操作の平均のパフォーマンスを時間を比較します。

![WriteBytesAsync パフォーマンス](images/writebytesasync-performance.png)

時刻の値、y 軸には、さまざまなハードウェアおよび構成はさまざまな絶対時刻値を生成するためこのグラフから意図的に省略されます。 ただし、マイクロソフトによるテストでこのような傾向を監視していた一貫しています。

* 非常に小さなファイル (< = 1 MB)。操作を完了に時間が一貫して高速です。
* 大きなファイル (> 1 MB)。操作を完了するには、指数関数的に増加を開始します。

## <a name="io-during-app-suspension"></a>アプリの中断中に I/O

アプリは、状態情報の保持またはメタデータを以降のセッションで使用する場合は、中断を処理するために設計する必要があります。 アプリの中断に関する背景情報は、次を参照してください。[アプリのライフ サイクル](../launch-resume/app-lifecycle.md)と[このブログの投稿](https://blogs.windows.com/buildingapps/2016/04/28/the-lifecycle-of-a-uwp-app/#qLwdmV5zfkAPMEco.97)します。

OS がアプリに延長実行を許可しない限り、すべてのリソースを解放し、そのデータを保存するには、5 秒間、アプリが中断されている場合があります。 最高の信頼性とユーザー エクスペリエンス、常に中断タスクを処理する必要がある時間は限られて前提としています。 5 秒間中断タスクを処理するための期間中に、次のガイドラインを考慮してください。

* フラッシュとリリースの操作によって発生する競合状況を回避するために最低限に I/O を維持しようとしてください。
* 数百ミリ秒以上書き込むに必要なファイルを記述しないでください。
* アプリで使用する場合、**書き込み**メソッド、留意してこれらのメソッドを必要とするすべての中間手順。

アプリの動作は、少量の状態データの中断中に場合、ほとんどの場合に使用できます、**書き込み**メソッドは、データをフラッシュします。 ただし、アプリは、大量の状態データを使用している場合は、直接データを格納するストリームを使用して検討してください。 トランザクション モデルでの遅延を減らすこうと、**書き込み**メソッド。 

例については、次を参照してください。、 [BasicSuspension](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/BasicSuspension)サンプル。

## <a name="other-examples-and-resources"></a>その他の例とリソース

いくつかの例とその他のリソースを特定のシナリオを次に示します。

### <a name="code-example-for-retrying-file-io-example"></a>ファイル I/O の例を再試行するためのコード例

書き込みを再試行する方法の擬似コードの例を次に示します (C#)、ユーザーは保存するためのファイルを取得した後で行うには、書き込みと仮定した場合します。

```csharp
Windows.Storage.Pickers.FileSavePicker savePicker = new Windows.Storage.Pickers.FileSavePicker();
savePicker.FileTypeChoices.Add("Plain Text", new List<string>() { ".txt" });
Windows.Storage.StorageFile file = await savePicker.PickSaveFileAsync();

Int32 retryAttempts = 5;

const Int32 ERROR_ACCESS_DENIED = unchecked((Int32)0x80070005);
const Int32 ERROR_SHARING_VIOLATION = unchecked((Int32)0x80070020);

if (file != null)
{
    // Application now has read/write access to the picked file.
    while (retryAttempts > 0)
    {
        try
        {
            retryAttempts--;
            await Windows.Storage.FileIO.WriteTextAsync(file, "Text to write to file");
            break;
        }
        catch (Exception ex) when ((ex.HResult == ERROR_ACCESS_DENIED) ||
                                   (ex.HResult == ERROR_SHARING_VIOLATION))
        {
            // This might be recovered by retrying, otherwise let the exception be raised.
            // The app can decide to wait before retrying.
        }
    }
}
else
{
    // The operation was cancelled in the picker dialog.
}
```

### <a name="synchronize-access-to-the-file"></a>ファイルへのアクセスを同期します。

[.NET ブログでの並列プログラミング](https://blogs.msdn.microsoft.com/pfxteam/)ガイダンスについては、並列プログラミングに関する優れたリソースです。 具体的には、 [AsyncReaderWriterLock について投稿](https://blogs.msdn.microsoft.com/pfxteam/2012/02/12/building-async-coordination-primitives-part-7-asyncreaderwriterlock/)同時の読み取りアクセスを許可するときに書き込み、ファイルへの排他アクセスを維持する方法について説明します。 留意そのシリアル化は I/O に影響を与えるパフォーマンス。

## <a name="see-also"></a>関連項目

* [作成、書き込み、およびファイルの読み取り](quickstart-reading-and-writing-files.md)
