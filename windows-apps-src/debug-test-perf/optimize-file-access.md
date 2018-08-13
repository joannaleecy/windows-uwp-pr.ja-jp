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
# <a name="optimize-file-access"></a><span data-ttu-id="dac67-104">ファイル アクセスの最適化</span><span class="sxs-lookup"><span data-stu-id="dac67-104">Optimize file access</span></span>

<span data-ttu-id="dac67-105">\[ Windows 10 の UWP アプリ向けに更新。</span><span class="sxs-lookup"><span data-stu-id="dac67-105">\[ Updated for UWP apps on Windows 10.</span></span> <span data-ttu-id="dac67-106">Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください。\]</span><span class="sxs-lookup"><span data-stu-id="dac67-106">For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]</span></span>

<span data-ttu-id="dac67-107">ファイル システムに効率的にアクセスすることで、ディスクの待ち時間とメモリ/CPU サイクルによるパフォーマンスの問題を回避するユニバーサル Windows プラットフォーム (UWP) アプリを作成します。</span><span class="sxs-lookup"><span data-stu-id="dac67-107">Create Universal Windows Platform (UWP) apps that access the file system efficiently, avoiding performance issues due to disk latency and memory/CPU cycles.</span></span>

<span data-ttu-id="dac67-108">ファイルの大規模なコレクションにアクセスして、Name、FileType、Path のような一般的なプロパティ以外のプロパティ値にアクセスする場合は、[**QueryOptions**](https://msdn.microsoft.com/library/windows/apps/BR207995) を作成して、[**SetPropertyPrefetch**](https://msdn.microsoft.com/library/windows/apps/hh973319) を呼び出してアクセスします。</span><span class="sxs-lookup"><span data-stu-id="dac67-108">When you want to access a large collection of files and you want to access property values other than the typical Name, FileType, and Path properties, access them by creating [**QueryOptions**](https://msdn.microsoft.com/library/windows/apps/BR207995) and calling [**SetPropertyPrefetch**](https://msdn.microsoft.com/library/windows/apps/hh973319).</span></span> <span data-ttu-id="dac67-109">**SetPropertyPrefetch** メソッドによって、イメージ コレクションなど、項目のコレクションをファイル システムから取得して表示するアプリのパフォーマンスを大幅に向上できます。</span><span class="sxs-lookup"><span data-stu-id="dac67-109">The **SetPropertyPrefetch** method can dramatically improve the performance of apps that display a collection of items obtained from the file system, such as a collection of images.</span></span> <span data-ttu-id="dac67-110">次の一連の例では、複数のファイルにアクセスする方法をいくつか紹介します。</span><span class="sxs-lookup"><span data-stu-id="dac67-110">The next set of examples shows a few ways to access multiple files.</span></span>

<span data-ttu-id="dac67-111">最初の例では、[**Windows.Storage.StorageFolder.GetFilesAsync**](https://msdn.microsoft.com/library/windows/apps/BR227273) を使って一連のファイルの名前情報を取得しています。</span><span class="sxs-lookup"><span data-stu-id="dac67-111">The first example uses [**Windows.Storage.StorageFolder.GetFilesAsync**](https://msdn.microsoft.com/library/windows/apps/BR227273) to retrieve the name info for a set of files.</span></span> <span data-ttu-id="dac67-112">この例のように Name プロパティだけにアクセスすることで、この手法は高いパフォーマンスを実現しています。</span><span class="sxs-lookup"><span data-stu-id="dac67-112">This approach provides good performance, because the example accesses only the name property.</span></span>

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

<span data-ttu-id="dac67-113">2 番目の例では、[**Windows.Storage.StorageFolder.GetFilesAsync**](https://msdn.microsoft.com/library/windows/apps/BR227273) を使って、各ファイルのイメージ プロパティを取得しています。</span><span class="sxs-lookup"><span data-stu-id="dac67-113">The second example uses [**Windows.Storage.StorageFolder.GetFilesAsync**](https://msdn.microsoft.com/library/windows/apps/BR227273) and then retrieves the image properties for each file.</span></span> <span data-ttu-id="dac67-114">この手法のパフォーマンスは高くありません。</span><span class="sxs-lookup"><span data-stu-id="dac67-114">This approach provides poor performance.</span></span>

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

<span data-ttu-id="dac67-115">3 番目の例では、[**QueryOptions**](https://msdn.microsoft.com/library/windows/apps/BR207995) を使って、一連のファイルの情報を取得しています。</span><span class="sxs-lookup"><span data-stu-id="dac67-115">The third example uses [**QueryOptions**](https://msdn.microsoft.com/library/windows/apps/BR207995) to get info about a set of files.</span></span> <span data-ttu-id="dac67-116">この手法のパフォーマンスは前の例よりもかなり高くなります。</span><span class="sxs-lookup"><span data-stu-id="dac67-116">This approach provides much better performance than the previous example.</span></span>

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
<span data-ttu-id="dac67-117">`Windows.Storage.ApplicationData.Current.LocalFolder` などの Windows.Storage オブジェクトで複数の操作を実行する場合は、対象のストレージ ソースを参照するローカル変数を作成すると、アクセスのたびに中間オブジェクトを再作成する必要がなくなります。</span><span class="sxs-lookup"><span data-stu-id="dac67-117">If you're performing multiple operations on Windows.Storage objects such as `Windows.Storage.ApplicationData.Current.LocalFolder`, create a local variable to reference that storage source so that you don't recreate intermediate objects each time you access it.</span></span>

## <a name="stream-performance-in-c-and-visual-basic"></a><span data-ttu-id="dac67-118">C# と Visual Basic におけるストリームのパフォーマンス</span><span class="sxs-lookup"><span data-stu-id="dac67-118">Stream performance in C# and Visual Basic</span></span>

### <a name="buffering-between-uwp-and-net-streams"></a><span data-ttu-id="dac67-119">UWP ストリームと .NET ストリーム間のバッファリング</span><span class="sxs-lookup"><span data-stu-id="dac67-119">Buffering between UWP and .NET streams</span></span>

<span data-ttu-id="dac67-120">UWP ストリーム ([**Windows.Storage.Streams.IInputStream**](https://msdn.microsoft.com/library/windows/apps/BR241718)、[**IOutputStream**](https://msdn.microsoft.com/library/windows/apps/BR241728) など) から .NET ストリーム ([**System.IO.Stream**](https://msdn.microsoft.com/library/windows/apps/xaml/system.io.stream.aspx)) への変換が必要になるケースは少なくありません。</span><span class="sxs-lookup"><span data-stu-id="dac67-120">There are many scenarios when you might want to convert a UWP stream (such as a [**Windows.Storage.Streams.IInputStream**](https://msdn.microsoft.com/library/windows/apps/BR241718) or [**IOutputStream**](https://msdn.microsoft.com/library/windows/apps/BR241728)) to a .NET stream ([**System.IO.Stream**](https://msdn.microsoft.com/library/windows/apps/xaml/system.io.stream.aspx)).</span></span> <span data-ttu-id="dac67-121">たとえば、UWP アプリを作成しているとき、ストリームを扱う従来の .NET コードを、UWP のファイル システムで利用する場合に活用できます。</span><span class="sxs-lookup"><span data-stu-id="dac67-121">For example, this is useful when you are writing a UWP app and want to use existing .NET code that works on streams with the UWP file system.</span></span> <span data-ttu-id="dac67-122">Windows ストア アプリ用 .NET API には、.NET と UWP 間のストリーム型変換を行う拡張メソッドが用意されています。</span><span class="sxs-lookup"><span data-stu-id="dac67-122">In order to enable this, .NET APIs for Windows Store apps provides extension methods that allow you to convert between .NET and UWP stream types.</span></span> <span data-ttu-id="dac67-123">詳しくは、「[**WindowsRuntimeStreamExtensions**](https://msdn.microsoft.com/library/windows/apps/xaml/system.io.windowsruntimestreamextensions.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="dac67-123">For more info, see [**WindowsRuntimeStreamExtensions**](https://msdn.microsoft.com/library/windows/apps/xaml/system.io.windowsruntimestreamextensions.aspx).</span></span>

<span data-ttu-id="dac67-124">UWP のストリームを .NET のストリームに変換するとき、実質的には、基になる UWP ストリーム用のアダプターを作成することになります。</span><span class="sxs-lookup"><span data-stu-id="dac67-124">When you convert a UWP stream to a .NET stream, you effectively create an adapter for the underlying UWP stream.</span></span> <span data-ttu-id="dac67-125">場合によっては、UWP ストリームのメソッド呼び出しに伴うコストが実行時に発生します。</span><span class="sxs-lookup"><span data-stu-id="dac67-125">Under some circumstances, there is a runtime cost associated with invoking methods on UWP streams.</span></span> <span data-ttu-id="dac67-126">このことがアプリの実行速度に影響を及ぼす可能性があり、特に、小規模な読み取り/書き込み操作を高頻度で何度も実行するケースにおいて顕著に表れます。</span><span class="sxs-lookup"><span data-stu-id="dac67-126">This may affect the speed of your app, especially in scenarios where you perform many small, frequent read or write operations.</span></span>

<span data-ttu-id="dac67-127">UWP のストリーム アダプターには、アプリの実行速度を高めるために、データ バッファーが用意されています。</span><span class="sxs-lookup"><span data-stu-id="dac67-127">In order to speed up apps, the UWP stream adapters contain a data buffer.</span></span> <span data-ttu-id="dac67-128">次のコード サンプルでは、既定のバッファー サイズの UWP ストリーム アダプターを使い、少量のデータを連続して読み取ります。</span><span class="sxs-lookup"><span data-stu-id="dac67-128">The following code sample demonstrates small consecutive reads using a UWP stream adapter with a default buffer size.</span></span>

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

<span data-ttu-id="dac67-129">ここに示した既定のバッファリング動作は、UWP のストリームを .NET のストリームに変換するほとんどのシナリオに対応します。</span><span class="sxs-lookup"><span data-stu-id="dac67-129">This default buffering behavior is desirable in most scenarios where you convert a UWP stream to a .NET stream.</span></span> <span data-ttu-id="dac67-130">しかし、パフォーマンス強化の観点から、シナリオによっては、バッファリングの動作を調整した方がよい場合もあります。</span><span class="sxs-lookup"><span data-stu-id="dac67-130">However, in some scenarios you may want to tweak the buffering behavior in order to increase performance.</span></span>

### <a name="working-with-large-data-sets"></a><span data-ttu-id="dac67-131">大きなデータ セットの操作</span><span class="sxs-lookup"><span data-stu-id="dac67-131">Working with large data sets</span></span>

<span data-ttu-id="dac67-132">大きなデータ セットの読み取りまたは書き込みを行う場合、そのスループットを向上させるには、[**AsStreamForRead**](https://msdn.microsoft.com/library/windows/apps/xaml/system.io.windowsruntimestreamextensions.asstream.aspx)、[**AsStreamForWrite**](https://msdn.microsoft.com/library/windows/apps/xaml/system.io.windowsruntimestreamextensions.asstreamforwrite.aspx)、[**AsStream**](https://msdn.microsoft.com/library/windows/apps/xaml/system.io.windowsruntimestreamextensions.asstream.aspx) の各拡張メソッドに指定するバッファー サイズを増やします。</span><span class="sxs-lookup"><span data-stu-id="dac67-132">When reading or writing larger sets of data you may be able to increase your read or write throughput by providing a large buffer size to the [**AsStreamForRead**](https://msdn.microsoft.com/library/windows/apps/xaml/system.io.windowsruntimestreamextensions.asstream.aspx), [**AsStreamForWrite**](https://msdn.microsoft.com/library/windows/apps/xaml/system.io.windowsruntimestreamextensions.asstreamforwrite.aspx), and [**AsStream**](https://msdn.microsoft.com/library/windows/apps/xaml/system.io.windowsruntimestreamextensions.asstream.aspx) extension methods.</span></span> <span data-ttu-id="dac67-133">これによって、ストリーム アダプターに割り当てられる内部バッファーのサイズが大きくなります。</span><span class="sxs-lookup"><span data-stu-id="dac67-133">This gives the stream adapter a larger internal buffer size.</span></span> <span data-ttu-id="dac67-134">たとえば、大きなファイルから取得したストリームを XML パーサーに渡すと、パーサーが、ストリームから小刻みにデータを読み取り、多数の読み取りが連続して発生することがあります。</span><span class="sxs-lookup"><span data-stu-id="dac67-134">For instance, when passing a stream that comes from a large file to an XML parser, the parser can make many sequential small reads from the stream.</span></span> <span data-ttu-id="dac67-135">バッファーを大きくすると、基になる UWP ストリームに対する呼び出しの回数を減らし、パフォーマンスを大きく高めることができます。</span><span class="sxs-lookup"><span data-stu-id="dac67-135">A large buffer can reduce the number of calls to the underlying UWP stream and boost performance.</span></span>

> <span data-ttu-id="dac67-136">**注**   約 80 KB を超えるバッファー サイズを設定するときは注意が必要です。ガベージ コレクターのヒープが断片化する可能性があるためです (「[ガベージ コレクションのパフォーマンスの向上](improve-garbage-collection-performance.md)」を参照)。</span><span class="sxs-lookup"><span data-stu-id="dac67-136">**Note**   You should be careful when setting a buffer size that is larger than approximately 80 KB, as this may cause fragmentation on the garbage collector heap (see [Improve garbage collection performance](improve-garbage-collection-performance.md)).</span></span> <span data-ttu-id="dac67-137">次のコード例では、81,920 バイトのバッファーを持つマネージ ストリーム アダプターを作成しています。</span><span class="sxs-lookup"><span data-stu-id="dac67-137">The following code example creates a managed stream adapter with an 81,920 byte buffer.</span></span>

> [!div class="tabbedCodeSnippets"]
```csharp
// Create a stream adapter with an 80 KB buffer.
Stream managedStream = nativeStream.AsStreamForRead(bufferSize: 81920);
```
```vb
' Create a stream adapter with an 80 KB buffer.
Dim managedStream As Stream = nativeStream.AsStreamForRead(bufferSize:=81920)
```

<span data-ttu-id="dac67-138">[**Stream.CopyTo**](https://msdn.microsoft.com/library/windows/apps/xaml/system.io.stream.copyto.aspx) メソッドと [**CopyToAsync**](https://msdn.microsoft.com/library/windows/apps/xaml/system.io.stream.copytoasync.aspx) メソッドでも、ストリーム間のコピー用にローカル バッファーが割り当てられます。</span><span class="sxs-lookup"><span data-stu-id="dac67-138">The [**Stream.CopyTo**](https://msdn.microsoft.com/library/windows/apps/xaml/system.io.stream.copyto.aspx) and [**CopyToAsync**](https://msdn.microsoft.com/library/windows/apps/xaml/system.io.stream.copytoasync.aspx) methods also allocate a local buffer for copying between streams.</span></span> <span data-ttu-id="dac67-139">[**AsStreamForRead**](https://msdn.microsoft.com/library/windows/apps/xaml/system.io.windowsruntimestreamextensions.asstreamforread.aspx) 拡張メソッドと同様、大きなストリームのコピーでは、既定のバッファー サイズをオーバーライドすることによってパフォーマンスを向上できる場合があります。</span><span class="sxs-lookup"><span data-stu-id="dac67-139">As with the [**AsStreamForRead**](https://msdn.microsoft.com/library/windows/apps/xaml/system.io.windowsruntimestreamextensions.asstreamforread.aspx) extension method, you may be able to get better performance for large stream copies by overriding the default buffer size.</span></span> <span data-ttu-id="dac67-140">次のコード例では、**CopyToAsync** 呼び出しの既定のバッファー サイズを変更しています。</span><span class="sxs-lookup"><span data-stu-id="dac67-140">The following code example demonstrates changing the default buffer size of a **CopyToAsync** call.</span></span>

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

<span data-ttu-id="dac67-141">この例では、先ほど推奨した 80 KB を超える 1 MB をバッファー サイズに設定しています。</span><span class="sxs-lookup"><span data-stu-id="dac67-141">This example uses a buffer size of 1 MB, which is greater than the 80 KB previously recommended.</span></span> <span data-ttu-id="dac67-142">このように大きなバッファーを使うと、きわめて大きなデータ セット (数百メガバイトなど) のコピー操作で高いスループットを得ることができます。</span><span class="sxs-lookup"><span data-stu-id="dac67-142">Using such a large buffer can improve throughput of the copy operation for very large data sets (that is, several hundred megabytes).</span></span> <span data-ttu-id="dac67-143">ただし、このバッファーは大きなオブジェクト ヒープ上に割り当てられるため、ガベージ コレクションのパフォーマンスが損なわれる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="dac67-143">However, this buffer is allocated on the large object heap and could potentially degrade garbage collection performance.</span></span> <span data-ttu-id="dac67-144">大きなバッファー サイズの使用は、アプリのパフォーマンスに顕著な向上が見られる場合に限定してください。</span><span class="sxs-lookup"><span data-stu-id="dac67-144">You should only use large buffer sizes if it will noticeably improve the performance of your app.</span></span>

<span data-ttu-id="dac67-145">多数のストリームを同時に扱うとき、必要に応じてバッファーのメモリ オーバーヘッドを削減 (または排除) することができます。</span><span class="sxs-lookup"><span data-stu-id="dac67-145">When you are working with a large number of streams simultaneously, you might want to reduce or eliminate the memory overhead of the buffer.</span></span> <span data-ttu-id="dac67-146">ストリーム アダプターに指定するバッファーを小さくするか、*bufferSize* パラメーターを 0 に設定してバッファリングを完全にオフにすることもできます。</span><span class="sxs-lookup"><span data-stu-id="dac67-146">You can specify a smaller buffer, or set the *bufferSize* parameter to 0 to turn off buffering entirely for that stream adapter.</span></span> <span data-ttu-id="dac67-147">大規模な読み取りと書き込みをマネージ ストリームに対して行う場合、バッファリングしなくても良好なスループット パフォーマンスを確保できます。</span><span class="sxs-lookup"><span data-stu-id="dac67-147">You can still achieve good throughput performance without buffering if you perform large reads and writes to the managed stream.</span></span>

### <a name="performing-latency-sensitive-operations"></a><span data-ttu-id="dac67-148">待機時間の影響を受けやすい操作の実行</span><span class="sxs-lookup"><span data-stu-id="dac67-148">Performing latency-sensitive operations</span></span>

<span data-ttu-id="dac67-149">バッファリングを回避した方がよいケースは他にもあります。読み取りと書き込みの待機時間を短くする必要があり、基になる UWP ストリームから大きなブロック単位で読み取ることが適していないケースが該当します。</span><span class="sxs-lookup"><span data-stu-id="dac67-149">You might also want to avoid buffering if you want low-latency reads and writes and do not want to read in large blocks out of the underlying UWP stream.</span></span> <span data-ttu-id="dac67-150">たとえば、ネットワーク通信のストリームを使う場合、読み取りと書き込みの待機時間を短くする必要があります。</span><span class="sxs-lookup"><span data-stu-id="dac67-150">For example, you might want low-latency reads and writes if you are using the stream for network communications.</span></span>

<span data-ttu-id="dac67-151">チャット アプリでは、ネットワーク インターフェイス経由でストリームを使い、メッセージをやり取りすることが考えられます。</span><span class="sxs-lookup"><span data-stu-id="dac67-151">In a chat app you might use a stream over a network interface to send messages back in forth.</span></span> <span data-ttu-id="dac67-152">この場合、バッファーにメッセージが満たされるまで待機するのではなく、完成したメッセージをすぐに送信する必要があります。</span><span class="sxs-lookup"><span data-stu-id="dac67-152">In this case you want to send messages as soon as they are ready and not wait for the buffer to fill up.</span></span> <span data-ttu-id="dac67-153">[**AsStreamForRead**](https://msdn.microsoft.com/library/windows/apps/xaml/system.io.windowsruntimestreamextensions.asstreamforread.aspx)、[**AsStreamForWrite**](https://msdn.microsoft.com/library/windows/apps/xaml/system.io.windowsruntimestreamextensions.asstreamforwrite.aspx)、[**AsStream**](https://msdn.microsoft.com/library/windows/apps/xaml/system.io.windowsruntimestreamextensions.asstream.aspx) の各拡張メソッドを呼び出す際にバッファー サイズを 0 に設定した場合、そのアダプターでは、バッファーが割り当てられず、すべての呼び出しについて、基になる UWP ストリームが直接操作されます。</span><span class="sxs-lookup"><span data-stu-id="dac67-153">If you set the buffer size to 0 when calling the [**AsStreamForRead**](https://msdn.microsoft.com/library/windows/apps/xaml/system.io.windowsruntimestreamextensions.asstreamforread.aspx), [**AsStreamForWrite**](https://msdn.microsoft.com/library/windows/apps/xaml/system.io.windowsruntimestreamextensions.asstreamforwrite.aspx), and [**AsStream**](https://msdn.microsoft.com/library/windows/apps/xaml/system.io.windowsruntimestreamextensions.asstream.aspx) extension methods, then the resulting adapter will not allocate a buffer, and all calls will manipulate the underlying UWP stream directly.</span></span>


