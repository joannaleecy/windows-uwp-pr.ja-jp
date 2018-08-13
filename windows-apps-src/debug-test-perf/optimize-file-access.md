---
author: jwmsft
ms.assetid: 40122343-1FE3-4160-BABE-6A2DD9AF1E8E
title: ファイル アクセスの最適化
description: ファイル システムに効率的にアクセスすることで、ディスクの待ち時間とメモリ/CPU サイクルによるパフォーマンスの問題を回避するユニバーサル Windows プラットフォーム (UWP) アプリを作成します。
ms.author: jimwalk
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 00ad06179ed4a77cb3e5144df12d5490f79a5df2
ms.sourcegitcommit: ec18e10f750f3f59fbca2f6a41bf1892072c3692
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/14/2017
ms.locfileid: "894616"
---
# <a name="optimize-file-access"></a>ファイル アクセスの最適化

\[ Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください。\]

ファイル システムに効率的にアクセスすることで、ディスクの待ち時間とメモリ/CPU サイクルによるパフォーマンスの問題を回避するユニバーサル Windows プラットフォーム (UWP) アプリを作成します。

ファイルの大規模なコレクションにアクセスして、Name、FileType、Path のような一般的なプロパティ以外のプロパティ値にアクセスする場合は、[**QueryOptions**](https://msdn.microsoft.com/library/windows/apps/BR207995) を作成して、[**SetPropertyPrefetch**](https://msdn.microsoft.com/library/windows/apps/hh973319) を呼び出してアクセスします。 **SetPropertyPrefetch** メソッドによって、イメージ コレクションなど、項目のコレクションをファイル システムから取得して表示するアプリのパフォーマンスを大幅に向上できます。 次の一連の例では、複数のファイルにアクセスする方法をいくつか紹介します。

最初の例では、[**Windows.Storage.StorageFolder.GetFilesAsync**](https://msdn.microsoft.com/library/windows/apps/BR227273) を使って一連のファイルの名前情報を取得しています。 この例のように Name プロパティだけにアクセスすることで、この手法は高いパフォーマンスを実現しています。

> [!div class="tabbedCodeSnippets"]
> ```csharp
> StorageFolder library = Windows.Storage.KnownFolders.PicturesLibrary;
> IReadOnlyList<StorageFile> files = await library.GetFilesAsync(Windows.Storage.Search.CommonFileQuery.OrderByDate);
> 
> for (int i = 0; i < files.Count; i++)
> {
>     // do something with the name of each file
>     string fileName = files[i].Name;
> }
> ```
> ```vb
> Dim library As StorageFolder = Windows.Storage.KnownFolders.PicturesLibrary
> Dim files As IReadOnlyList(Of StorageFile) =
>     Await library.GetFilesAsync(Windows.Storage.Search.CommonFileQuery.OrderByDate)
> 
> For i As Integer = 0 To files.Count - 1
>     ' do something with the name of each file
>     Dim fileName As String = files(i).Name
> Next i
> ```

2 番目の例では、[**Windows.Storage.StorageFolder.GetFilesAsync**](https://msdn.microsoft.com/library/windows/apps/BR227273) を使って、各ファイルのイメージ プロパティを取得しています。 この手法のパフォーマンスは高くありません。

> [!div class="tabbedCodeSnippets"]
> ```csharp
> StorageFolder library = Windows.Storage.KnownFolders.PicturesLibrary;
> IReadOnlyList<StorageFile> files = await library.GetFilesAsync(Windows.Storage.Search.CommonFileQuery.OrderByDate);
> for (int i = 0; i < files.Count; i++)
> {
>     ImageProperties imgProps = await files[i].Properties.GetImagePropertiesAsync();
> 
>     // do something with the date the image was taken
>     DateTimeOffset date = imgProps.DateTaken;
> }
> ```
> ```vb
> Dim library As StorageFolder = Windows.Storage.KnownFolders.PicturesLibrary
> Dim files As IReadOnlyList(Of StorageFile) = Await library.GetFilesAsync(Windows.Storage.Search.CommonFileQuery.OrderByDate)
> For i As Integer = 0 To files.Count - 1
>     Dim imgProps As ImageProperties =
>         Await files(i).Properties.GetImagePropertiesAsync()
> 
>     ' do something with the date the image was taken
>     Dim dateTaken As DateTimeOffset = imgProps.DateTaken
> Next i
> ```

3 番目の例では、[**QueryOptions**](https://msdn.microsoft.com/library/windows/apps/BR207995) を使って、一連のファイルの情報を取得しています。 この手法のパフォーマンスは前の例よりもかなり高くなります。

> [!div class="tabbedCodeSnippets"]
> ```csharp
> // Set QueryOptions to prefetch our specific properties
> var queryOptions = new Windows.Storage.Search.QueryOptions(CommonFileQuery.OrderByDate, null);
> queryOptions.SetThumbnailPrefetch(ThumbnailMode.PicturesView, 100,
>         ThumbnailOptions.ReturnOnlyIfCached);
> queryOptions.SetPropertyPrefetch(PropertyPrefetchOptions.ImageProperties, 
>        new string[] {"System.Size"});
> 
> StorageFileQueryResult queryResults = KnownFolders.PicturesLibrary.CreateFileQueryWithOptions(queryOptions);
> IReadOnlyList<StorageFile> files = await queryResults.GetFilesAsync();
> 
> foreach (var file in files)
> {
>     ImageProperties imageProperties = await file.Properties.GetImagePropertiesAsync();
> 
>     // Do something with the date the image was taken.
>     DateTimeOffset dateTaken = imageProperties.DateTaken;
> 
>     // Performance gains increase with the number of properties that are accessed.
>     IDictionary<String, object> propertyResults =
>         await file.Properties.RetrievePropertiesAsync(
>               new string[] {"System.Size" });
> 
>     // Get/Set extra properties here
>     var systemSize = propertyResults["System.Size"];
> }
> ```
> ```vb
> ' Set QueryOptions to prefetch our specific properties
> Dim queryOptions = New Windows.Storage.Search.QueryOptions(CommonFileQuery.OrderByDate, Nothing)
> queryOptions.SetThumbnailPrefetch(ThumbnailMode.PicturesView,
>             100, Windows.Storage.FileProperties.ThumbnailOptions.ReturnOnlyIfCached)
> queryOptions.SetPropertyPrefetch(PropertyPrefetchOptions.ImageProperties,
>                                  New String() {"System.Size"})
> 
> Dim queryResults As StorageFileQueryResult = KnownFolders.PicturesLibrary.CreateFileQueryWithOptions(queryOptions)
> Dim files As IReadOnlyList(Of StorageFile) = Await queryResults.GetFilesAsync()
> 
> 
> For Each file In files
>     Dim imageProperties As ImageProperties = Await file.Properties.GetImagePropertiesAsync()
> 
>     ' Do something with the date the image was taken.
>     Dim dateTaken As DateTimeOffset = imageProperties.DateTaken
> 
>     ' Performance gains increase with the number of properties that are accessed.
>     Dim propertyResults As IDictionary(Of String, Object) =
>         Await file.Properties.RetrievePropertiesAsync(New String() {"System.Size"})
> 
>     ' Get/Set extra properties here
>     Dim systemSize = propertyResults("System.Size")
> 
> Next file
> ```
`Windows.Storage.ApplicationData.Current.LocalFolder` などの Windows.Storage オブジェクトで複数の操作を実行する場合は、対象のストレージ ソースを参照するローカル変数を作成すると、アクセスのたびに中間オブジェクトを再作成する必要がなくなります。

## <a name="stream-performance-in-c-and-visual-basic"></a>C# と Visual Basic におけるストリームのパフォーマンス

### <a name="buffering-between-uwp-and-net-streams"></a>UWP ストリームと .NET ストリーム間のバッファリング

UWP ストリーム ([**Windows.Storage.Streams.IInputStream**](https://msdn.microsoft.com/library/windows/apps/BR241718)、[**IOutputStream**](https://msdn.microsoft.com/library/windows/apps/BR241728) など) から .NET ストリーム ([**System.IO.Stream**](https://msdn.microsoft.com/library/windows/apps/xaml/system.io.stream.aspx)) への変換が必要になるケースは少なくありません。 たとえば、UWP アプリを作成しているとき、ストリームを扱う従来の .NET コードを、UWP のファイル システムで利用する場合に活用できます。 Windows ストア アプリ用 .NET API には、.NET と UWP 間のストリーム型変換を行う拡張メソッドが用意されています。 詳しくは、「[**WindowsRuntimeStreamExtensions**](https://msdn.microsoft.com/library/windows/apps/xaml/system.io.windowsruntimestreamextensions.aspx)」をご覧ください。

UWP のストリームを .NET のストリームに変換するとき、実質的には、基になる UWP ストリーム用のアダプターを作成することになります。 場合によっては、UWP ストリームのメソッド呼び出しに伴うコストが実行時に発生します。 このことがアプリの実行速度に影響を及ぼす可能性があり、特に、小規模な読み取り/書き込み操作を高頻度で何度も実行するケースにおいて顕著に表れます。

UWP のストリーム アダプターには、アプリの実行速度を高めるために、データ バッファーが用意されています。 次のコード サンプルでは、既定のバッファー サイズの UWP ストリーム アダプターを使い、少量のデータを連続して読み取ります。

> [!div class="tabbedCodeSnippets"]
> ```csharp
> StorageFile file = await Windows.Storage.ApplicationData.Current
>     .LocalFolder.GetFileAsync("example.txt");
> Windows.Storage.Streams.IInputStream windowsRuntimeStream = 
>     await file.OpenReadAsync();
> 
> byte[] destinationArray = new byte[8];
> 
> // Create an adapter with the default buffer size.
> using (var managedStream = windowsRuntimeStream.AsStreamForRead())
> {
> 
>     // Read 8 bytes into destinationArray.
>     // A larger block is actually read from the underlying 
>     // windowsRuntimeStream and buffered within the adapter.
>     await managedStream.ReadAsync(destinationArray, 0, 8);
> 
>     // Read 8 more bytes into destinationArray.
>     // This call may complete much faster than the first call
>     // because the data is buffered and no call to the 
>     // underlying windowsRuntimeStream needs to be made.
>     await managedStream.ReadAsync(destinationArray, 0, 8);
> }
> ```
> ```vb
> Dim file As StorageFile = Await Windows.Storage.ApplicationData.Current -
> .LocalFolder.GetFileAsync("example.txt")
> Dim windowsRuntimeStream As Windows.Storage.Streams.IInputStream =
>     Await file.OpenReadAsync()
> 
> Dim destinationArray() As Byte = New Byte(8) {}
> 
> ' Create an adapter with the default buffer size.
> Dim managedStream As Stream = windowsRuntimeStream.AsStreamForRead()
> Using (managedStream)
> 
>     ' Read 8 bytes into destinationArray.
>     ' A larger block is actually read from the underlying 
>     ' windowsRuntimeStream and buffered within the adapter.
>     Await managedStream.ReadAsync(destinationArray, 0, 8)
> 
>     ' Read 8 more bytes into destinationArray.
>     ' This call may complete much faster than the first call
>     ' because the data is buffered and no call to the 
>     ' underlying windowsRuntimeStream needs to be made.
>     Await managedStream.ReadAsync(destinationArray, 0, 8)
> 
> End Using
> ```

ここに示した既定のバッファリング動作は、UWP のストリームを .NET のストリームに変換するほとんどのシナリオに対応します。 しかし、パフォーマンス強化の観点から、シナリオによっては、バッファリングの動作を調整した方がよい場合もあります。

### <a name="working-with-large-data-sets"></a>大きなデータ セットの操作

大きなデータ セットの読み取りまたは書き込みを行う場合、そのスループットを向上させるには、[**AsStreamForRead**](https://msdn.microsoft.com/library/windows/apps/xaml/system.io.windowsruntimestreamextensions.asstream.aspx)、[**AsStreamForWrite**](https://msdn.microsoft.com/library/windows/apps/xaml/system.io.windowsruntimestreamextensions.asstreamforwrite.aspx)、[**AsStream**](https://msdn.microsoft.com/library/windows/apps/xaml/system.io.windowsruntimestreamextensions.asstream.aspx) の各拡張メソッドに指定するバッファー サイズを増やします。 これによって、ストリーム アダプターに割り当てられる内部バッファーのサイズが大きくなります。 たとえば、大きなファイルから取得したストリームを XML パーサーに渡すと、パーサーが、ストリームから小刻みにデータを読み取り、多数の読み取りが連続して発生することがあります。 バッファーを大きくすると、基になる UWP ストリームに対する呼び出しの回数を減らし、パフォーマンスを大きく高めることができます。

> **注**   約 80 KB を超えるバッファー サイズを設定するときは注意が必要です。ガベージ コレクターのヒープが断片化する可能性があるためです (「[ガベージ コレクションのパフォーマンスの向上](improve-garbage-collection-performance.md)」を参照)。 次のコード例では、81,920 バイトのバッファーを持つマネージ ストリーム アダプターを作成しています。

> [!div class="tabbedCodeSnippets"]
```csharp
// Create a stream adapter with an 80 KB buffer.
Stream managedStream = nativeStream.AsStreamForRead(bufferSize: 81920);
```
```vb
' Create a stream adapter with an 80 KB buffer.
Dim managedStream As Stream = nativeStream.AsStreamForRead(bufferSize:=81920)
```

[**Stream.CopyTo**](https://msdn.microsoft.com/library/windows/apps/xaml/system.io.stream.copyto.aspx) メソッドと [**CopyToAsync**](https://msdn.microsoft.com/library/windows/apps/xaml/system.io.stream.copytoasync.aspx) メソッドでも、ストリーム間のコピー用にローカル バッファーが割り当てられます。 [**AsStreamForRead**](https://msdn.microsoft.com/library/windows/apps/xaml/system.io.windowsruntimestreamextensions.asstreamforread.aspx) 拡張メソッドと同様、大きなストリームのコピーでは、既定のバッファー サイズをオーバーライドすることによってパフォーマンスを向上できる場合があります。 次のコード例では、**CopyToAsync** 呼び出しの既定のバッファー サイズを変更しています。

> [!div class="tabbedCodeSnippets"]
> ```csharp
> MemoryStream destination = new MemoryStream();
> // copies the buffer into memory using the default copy buffer
> await managedStream.CopyToAsync(destination);
> 
> // Copy the buffer into memory using a 1 MB copy buffer.
> await managedStream.CopyToAsync(destination, bufferSize: 1024 * 1024);
> ```
> ```vb
> Dim destination As MemoryStream = New MemoryStream()
> ' copies the buffer into memory using the default copy buffer
> Await managedStream.CopyToAsync(destination)
> 
> ' Copy the buffer into memory using a 1 MB copy buffer.
> Await managedStream.CopyToAsync(destination, bufferSize:=1024 * 1024)
> ```

この例では、先ほど推奨した 80 KB を超える 1 MB をバッファー サイズに設定しています。 このように大きなバッファーを使うと、きわめて大きなデータ セット (数百メガバイトなど) のコピー操作で高いスループットを得ることができます。 ただし、このバッファーは大きなオブジェクト ヒープ上に割り当てられるため、ガベージ コレクションのパフォーマンスが損なわれる可能性があります。 大きなバッファー サイズの使用は、アプリのパフォーマンスに顕著な向上が見られる場合に限定してください。

多数のストリームを同時に扱うとき、必要に応じてバッファーのメモリ オーバーヘッドを削減 (または排除) することができます。 ストリーム アダプターに指定するバッファーを小さくするか、*bufferSize* パラメーターを 0 に設定してバッファリングを完全にオフにすることもできます。 大規模な読み取りと書き込みをマネージ ストリームに対して行う場合、バッファリングしなくても良好なスループット パフォーマンスを確保できます。

### <a name="performing-latency-sensitive-operations"></a>待機時間の影響を受けやすい操作の実行

バッファリングを回避した方がよいケースは他にもあります。読み取りと書き込みの待機時間を短くする必要があり、基になる UWP ストリームから大きなブロック単位で読み取ることが適していないケースが該当します。 たとえば、ネットワーク通信のストリームを使う場合、読み取りと書き込みの待機時間を短くする必要があります。

チャット アプリでは、ネットワーク インターフェイス経由でストリームを使い、メッセージをやり取りすることが考えられます。 この場合、バッファーにメッセージが満たされるまで待機するのではなく、完成したメッセージをすぐに送信する必要があります。 [**AsStreamForRead**](https://msdn.microsoft.com/library/windows/apps/xaml/system.io.windowsruntimestreamextensions.asstreamforread.aspx)、[**AsStreamForWrite**](https://msdn.microsoft.com/library/windows/apps/xaml/system.io.windowsruntimestreamextensions.asstreamforwrite.aspx)、[**AsStream**](https://msdn.microsoft.com/library/windows/apps/xaml/system.io.windowsruntimestreamextensions.asstream.aspx) の各拡張メソッドを呼び出す際にバッファー サイズを 0 に設定した場合、そのアダプターでは、バッファーが割り当てられず、すべての呼び出しについて、基になる UWP ストリームが直接操作されます。


