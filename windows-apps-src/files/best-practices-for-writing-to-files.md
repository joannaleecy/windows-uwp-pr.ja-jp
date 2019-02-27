---
title: ファイルに書き込むためのベスト プラクティス
description: FileIO と PathIO クラスのメソッドを記述するさまざまなファイルを使用するためのベスト プラクティスについて説明します。
ms.date: 02/06/2019
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: f8bed97e060015f92ff95c9f7d797bbcb83db431
ms.sourcegitcommit: 079801609165bc7eb69670d771a05bffe236d483
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 02/27/2019
ms.locfileid: "9115709"
---
# <a name="best-practices-for-writing-to-files"></a>ファイルに書き込むためのベスト プラクティス

**重要な API**

* [**FileIO クラス**](https://docs.microsoft.com/uwp/api/Windows.Storage.FileIO)
* [**PathIO クラス**](https://docs.microsoft.com/uwp/api/windows.storage.pathio)

[**FileIO**](https://docs.microsoft.com/uwp/api/Windows.Storage.FileIO)と[**PathIO**](https://docs.microsoft.com/uwp/api/windows.storage.pathio)クラスの**書き込み**メソッドを使用して、ファイル システムの I/O 操作を実行する場合、一般的な問題のセットに開発者が実行場合があります。 たとえば、一般的な問題は次のとおりです。

• ファイルには、•、アプリは、メソッドのいずれかを呼び出すときに例外を受け取る部分的に書き込まれます。 • の背後にある操作のままにします。ターゲット ファイル名のようなファイル名を持つ TMP ファイルを削除します。

[**FileIO**](https://docs.microsoft.com/uwp/api/Windows.Storage.FileIO)と[**PathIO**](https://docs.microsoft.com/uwp/api/windows.storage.pathio)クラスの**記述**方法を以下に示します。

* **WriteBufferAsync**
* **WriteBytesAsync**
* **WriteLinesAsync**
* **WriteTextAsync**

 この記事では、それらを使用する方法とタイミングは開発者のこれらのメソッドのしくみの詳細をより深く理解を提供します。 この記事では、ガイドラインを提供し、すべての考えられるファイル I/O の問題のソリューションを提供しません。 

> [!NOTE]
> この記事では、例やディスカッションで**FileIO**方法について説明します。 ただし、 **PathIO**メソッドと同様のパターンに従うし、この記事のガイダンスのほとんどはこれらのメソッドにも適用されます。 

## <a name="conveience-vs-control"></a>コントロールと Conveience

[**StorageFile**](https://docs.microsoft.com/uwp/api/windows.storage.storagefile)オブジェクトは、Win32 のネイティブのプログラミング モデルのようなファイル ハンドルではありません。 代わりに、 [**StorageFile**](https://docs.microsoft.com/uwp/api/windows.storage.storagefile)は、その内容を操作するメソッドを持つファイルの表現です。

**StorageFile**と I/O を実行する場合は、この概念を理解すると便利です。 たとえば、[ファイルへの書き込み](quickstart-reading-and-writing-files.md#writing-to-a-file)] セクションでは、ファイルへの書き込みを 3 つの方法が表示されます。

* [**FileIO.WriteTextAsync**](https://docs.microsoft.com/uwp/api/windows.storage.fileio.writetextasync)メソッドを使用します。
* バッファーを作成し、し[**FileIO.WriteBufferAsync**](https://docs.microsoft.com/en-us/uwp/api/windows.storage.fileio.writebufferasync)メソッドを呼び出すことです。
* ストリームを使用して、4 つのステップ モデルには:
  1. [開いている](https://docs.microsoft.com/uwp/api/windows.storage.storagefile.openasync)ファイル ストリームを取得します。
  2. [取得する](https://docs.microsoft.com/uwp/api/windows.storage.streams.irandomaccessstream.getoutputstreamat)出力ストリームをします。
  3. [**DataWriter**](https://docs.microsoft.com/uwp/api/windows.storage.streams.datawriter)オブジェクトを作成し、対応する**書き込み**メソッドを呼び出します。
  4. [コミット](https://docs.microsoft.com/uwp/api/windows.storage.streams.datawriter.storeasync)データ ライターと、出力ストリーム[をフラッシュ](https://docs.microsoft.com/uwp/api/windows.storage.streams.ioutputstream.flushasync)のデータ。

最初の 2 つのシナリオは、アプリで最もよく使用されるものです。 1 つの操作でファイルへの書き込みが容易コードおよび管理するになり、また、アプリの責任ファイル I/O の複雑さの多くを扱うから削除します。 ただし、この利便性はコストがかかる: 制御操作全体や特定の時点でのエラーをキャッチする機能が失われる。

## <a name="the-transactional-model"></a>トランザクションのモデル

[**FileIO**](https://docs.microsoft.com/uwp/api/Windows.Storage.FileIO)と[**PathIO**](https://docs.microsoft.com/uwp/api/windows.storage.pathio)クラスの**書き込み**メソッドは、追加のレイヤーを上記で説明した 3 つ目の書き込みモデルでの手順をラップします。 このレイヤーは、記憶域のトランザクションでカプセル化されます。

データの書き込み中に問題が発生する場合に備えて、元のファイルの整合性の保護、**書き込み**メソッドは[**OpenTransactedWriteAsync**](https://docs.microsoft.com/uwp/api/windows.storage.storagefile.opentransactedwriteasync)を使用してファイルを開くことによってトランザクション モデルを使用します。 このプロセスは、 [**StorageStreamTransaction**](https://docs.microsoft.com/uwp/api/windows.storage.storagestreamtransaction)オブジェクトを作成します。 このトランザクション オブジェクトが作成されたら、Api は、[ファイルへのアクセス](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/FileAccess)のサンプルや[**StorageStreamTransaction**](https://docs.microsoft.com/uwp/api/windows.storage.storagestreamtransaction) 」の記事のコード例を次の同様の方法データを書き込みます。

次の図は、基になるタスクによって実行される、成功の書き込み操作で**WriteTextAsync**メソッドです。 次の図は、操作の簡素化されたビューを提供します。 たとえば、異なるスレッドでテキストのエンコードと非同期の完了などの手順をスキップします。

![ファイルへの書き込みの UWP API の呼び出しのシーケンス図](images/file-write-call-sequence.svg)

ストリームを使用して、複雑な 4 つのステップ モデルではなく、 [**FileIO**](https://docs.microsoft.com/uwp/api/Windows.Storage.FileIO)と[**PathIO**](https://docs.microsoft.com/uwp/api/windows.storage.pathio)クラスの**書き込み**メソッドを使用する利点は次のとおりです。

* 中間すべての手順をエラーを含むを処理する 1 つの API の呼び出しです。
* 問題が発生した場合、元のファイルが保持されます。
* システムの状態は、可能な限りクリーンアップを保持するしようとしています。

ただし、すぎると考えられる中間障害点では、障害が発生した可能性が高くがあります。 エラーが発生した場合は、プロセスが失敗した場所がわかりにくい場合があります。 次のセクションでは、いくつかの**書き込み**メソッドを使用する場合に発生し、可能な解決策を提供する可能性がありますエラーを示します。

## <a name="common-error-codes-for-write-methods-of-the-fileio-and-pathio-classes"></a>FileIO と PathIO クラスの書き込みメソッドの一般的なエラー コード

この表では、アプリの開発者が**書き込み**メソッドを使用する場合に発生する一般的なエラー コードを示します。 テーブルの手順は、前の図の手順に対応します。

|  エラーの名前 (value)  |  手順  |  原因  |  解決策  |
|----------------------|---------|----------|-------------|
|  ERROR_ACCESS_DENIED (0X80070005)  |  5  |  元のファイルは、場合によって、以前の操作の削除対象としてマークする可能性があります。  |  操作を再試行します。</br>ファイルへのアクセスが同期されることを確認します。  |
|  ERROR_SHARING_VIOLATION (0X80070020)  |  5  |  専用の別の書き込みによっては、元のファイルが開きます。   |  操作を再試行します。</br>ファイルへのアクセスが同期されることを確認します。  |
|  ERROR_UNABLE_TO_REMOVE_REPLACED (0X80070497)  |  19 20  |  使用されているために、元のファイル (file.txt) を置き換えることができませんでした。 別のプロセスまたは操作は、ファイルへのアクセスを獲得に置き換えることができます。  |  操作を再試行します。</br>ファイルへのアクセスが同期されることを確認します。  |
|  ERROR_DISK_FULL (0X80070070)  |  7、14、16、20  |  トランザクションのモデル、余分なファイルを作成し、この余分な記憶域を消費します。  |    |
|  ERROR_OUTOFMEMORY (0X8007000E)  |  14、16  |  これは、問題は、複数の未処理の I/O 操作や大規模なファイル サイズの問題が発生します。  |  ストリームを制御することより詳細なアプローチでは、エラーを解決する可能性があります。  |
|  E_FAIL (0X80004005) |  任意  |  その他  |  操作を再試行します。 まだに失敗した場合は、プラットフォーム エラー場合があり、不整合な状態であるため、アプリが終了する必要があります。 |

## <a name="other-considerations-for-file-states-that-might-lead-to-errors"></a>エラーにつながる可能性のあるファイルの状態に関するその他の考慮事項

**書き込み**メソッドによって返されたエラー、またお客様には、ファイルに書き込むときに、アプリに期待のガイドラインをいくつかを次に示します。

### <a name="data-was-written-to-the-file-if-and-only-if-operation-completed"></a>操作が完了した場合にのみファイルにデータが書き込まれました。

アプリしないでくださいデータに関するすべての前提ファイルの書き込み操作が進行中。 一貫性のないデータを招く可能性が操作が完了する前に、ファイルにアクセスしようとしています。 アプリは、未処理の I/o を追跡の担当する必要があります。

### <a name="readers"></a>リーダー

ファイルに書き込まれてもは、ていねいリーダーで使用されている場合 (つまり、 [**FileAccessMode.Read**](https://docs.microsoft.com/uwp/api/Windows.Storage.FileAccessMode)で開くと、後続の読み取りエラーで失敗、ERROR_OPLOCK_HANDLE_CLOSED (0x80070323)。 場合によってアプリでは、**書き込み**操作の進行中に読み取りのファイルをもう一度開く再試行してください。 これにより、競合状態を**記述**する置き換えができないため、元のファイルを上書きしようとしたとき最終的に失敗した可能性があります。

### <a name="files-from-knownfolders"></a>KnownFolders からのファイル

アプリは、 [**KnownFolders**](https://docs.microsoft.com/uwp/api/Windows.Storage.KnownFolders)のいずれかの上にあるファイルにアクセスしようとする唯一のアプリをできない可能性があります。 保証、操作が成功した場合は、アプリがファイルに記述内容が一定のままですが、ファイルを読み取ろうとした、次回はありません。 また、共有またはへのアクセスにこのシナリオで一般的なエラーを拒否されます。

### <a name="conflicting-io"></a>競合する I/O

アプリのローカル データ内のファイルの**書き込み**メソッドを使用していて、いくつか注意が必要、同時実行のエラーの可能性を下げることができます。 複数の**書き込み**操作は、ファイルを同時に送信されるが場合、は、ファイルにどのようなデータが最終的には保証されません。 これを軽減するためには、ファイルへの**書き込み**操作がアプリにシリアル化をお勧めします。

### <a name="tmp-files"></a>~ TMP ファイル

場合によっては、(たとえば、するアプリが中断または終了、OS によって場合)、操作が強制的に取り消された場合、トランザクションまたはされていないコミット適切に終了します。 ファイルの背後にあるこのままでかまいません、(. ~ TMP) 拡張機能です。 これらの一時ファイルを削除する (存在する場合、アプリのローカル データ) を検討してください。 アプリのアクティブ化を処理する場合。

## <a name="considerations-based-on-file-types"></a>ファイルの種類に基づいてに関する考慮事項

いくつかのエラーは、ファイルにアクセス中、頻度と、ファイル サイズの種類に応じてより一般的なになることができます。 一般に、アプリがアクセスできるファイルの 3 つのカテゴリがあります。

* ファイルが作成され、アプリのローカル データ フォルダー内のユーザーを編集します。 これらを作成し、アプリを使用している場合にのみを編集し、アプリ内でのみ存在します。
* アプリのメタデータ。 アプリでは、独自の状態を追跡するのにこれらのファイルを使用します。
* アプリがアクセスする機能を宣言されているファイル システムの場所にその他のファイル。 これらは、最もよく、 [**KnownFolders**](https://docs.microsoft.com/uwp/api/Windows.Storage.KnownFolders)のいずれかにあります。

アプリでは、アプリのパッケージ ファイルの一部になっているし、は、アプリによってのみアクセスするために、ファイルの最初の 2 つのカテゴリの完全なコントロールがあります。 最後の項目内のファイル、アプリが、他のアプリと OS のサービスがファイルにアクセスする同時に注意してくださいである必要があります。

アプリによっては、ファイルへのアクセスは頻度の異なることができます。

* 非常に低いします。 これらは、通常、とき、アプリの起動とが保存されると、アプリが中断されたときに開いているファイルです。
* 低します。 これらは、ユーザーは、具体的には、に対してアクションを実行 (保存または読み込みなど) のファイルです。
* 中程度またはハイします。 これらは、アプリに更新する必要がありますのデータ (たとえば、自動機能または定数のメタデータを追跡) 常にファイルです。

ファイルのサイズ、 **WriteBytesAsync**メソッドでは、次のグラフ内のパフォーマンス データを検討してください。 このグラフでは、10000 操作管理された環境でのファイル サイズごとの平均パフォーマンス経由で操作 vs ファイルのサイズを完了する時間を比較します。

![WriteBytesAsync パフォーマンス](images/writebytesasync-performance.png)

Y 軸の時間の値は、さまざまなハードウェアと構成別の絶対時刻の値が生成されますのでこのグラフから意図的に省略されます。 ただし、マイクロソフトによるテストでこれらの傾向を監視していた一貫しています。

* 非常に小さいファイル (_lt _ = 1 MB): 操作を完了するには一貫して高速です。
* 大きなファイル (_gt 1 MB): 急激に増加する操作を完了する時間を開始します。

## <a name="io-during-app-suspension"></a>アプリの中断中の I/O

アプリは必要がありますの中断の処理する場合の状態情報を保持するまたはメタデータ後のセッションで使用するために設計されています。 アプリの中断に関する背景情報は、[アプリのライフ サイクル](../launch-resume/app-lifecycle.md)と[このブログ記事](https://blogs.windows.com/buildingapps/2016/04/28/the-lifecycle-of-a-uwp-app/#qLwdmV5zfkAPMEco.97)を参照してください。

OS がアプリでは、延長実行を許可しない限り、そのすべてのリソースを解放し、そのデータを保存するには、5 秒間、アプリが中断されたときがあります。 最適な信頼性とユーザー エクスペリエンス、常に一時停止のタスクを処理する必要が時間が限られていると仮定します。 5 秒間の一時停止のタスクを処理するための期間中に、次のガイドラインを考慮してください。

* I/O をフラッシュとリリースの操作による競合を回避するために最小限に抑えるしようとしてください。
* 何百もミリ秒以上を記述するを必要とするファイルの記述しないでください。
* アプリは、**書き込み**メソッドを使用している場合は、これらのメソッドを必要とするすべての中間手順に留意してください。

場合は、少量の状態データでは、変換されたアプリは中断された動作、ほとんどの場合できますメソッドを使って**書き込み**データをフラッシュします。 ただし、アプリは、大量の状態データを使用している場合は、直接データを格納するストリームを使用して検討してください。 これは、**書き込み**の方法のトランザクションのモデルで導入された遅延時間を減らすために役立ちます。 

たとえば、 [BasicSuspension](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/BasicSuspension)サンプルを参照してください。

## <a name="other-examples-and-resources"></a>その他の例とリソース

次に例をいくつかと、特定のシナリオには、その他のリソースを示します。

### <a name="code-example-for-retrying-file-io-example"></a>ファイル I/O の例を再試行するためのコード例

書き込みは、ユーザーが選ぶと、ファイルを保存した後に実行すると想定すると (c#)、書き込みを再試行する方法について擬似コード例を次に示します。

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

[並列プログラミング .NET ブログで](https://blogs.msdn.microsoft.com/pfxteam/)は、並列プログラミングに関するガイダンスについては優れたリソースです。 具体的には、 [AsyncReaderWriterLock に関する投稿](https://blogs.msdn.microsoft.com/pfxteam/2012/02/12/building-async-coordination-primitives-part-7-asyncreaderwriterlock/)するには、読み取りの同時アクセスできるようにすることの書き込みのファイルへの排他的アクセスを管理する方法について説明します。 留意そのシリアル化され、I/O の影響のパフォーマンス。

## <a name="see-also"></a>関連項目

* [ファイルの作成、書き込み、および読み取り](quickstart-reading-and-writing-files.md)
