---
xx.xxxxxxx: YYYYYYYY-YXXY-YYYY-XXXX-YXYXXYXXYXYX
xxxxx: Xxxxxxxx xxxx xxxxxx
xxxxxxxxxxx: Xxxxxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx xxxx xxxxxx xxx xxxx xxxxxx xxxxxxxxxxx, xxxxxxxx xxxxxxxxxxx xxxxxx xxx xx xxxx xxxxxxx xxx xxxxxx/XXX xxxxxx.
---
# Xxxxxxxx xxxx xxxxxx

\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

Xxxxxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx xxxx xxxxxx xxx xxxx xxxxxx xxxxxxxxxxx, xxxxxxxx xxxxxxxxxxx xxxxxx xxx xx xxxx xxxxxxx xxx xxxxxx/XXX xxxxxx.

Xxxx xxx xxxx xx xxxxxx x xxxxx xxxxxxxxxx xx xxxxx xxx xxx xxxx xx xxxxxx xxxxxxxx xxxxxx xxxxx xxxx xxx xxxxxxx Xxxx, XxxxXxxx, xxx Xxxx xxxxxxxxxx, xxxxxx xxxx xx xxxxxxxx [**XxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR207995) xxx xxxxxxx [**XxxXxxxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR207995-setpropertyprefetch). Xxx **XxxXxxxxxxxXxxxxxxx** xxxxxx xxx xxxxxxxxxxxx xxxxxxx xxx xxxxxxxxxxx xx xxxx xxxx xxxxxxx x xxxxxxxxxx xx xxxxx xxxxxxxx xxxx xxx xxxx xxxxxx, xxxx xx x xxxxxxxxxx xx xxxxxx. Xxx xxxx xxx xx xxxxxxxx xxxxx x xxx xxxx xx xxxxxx xxxxxxxx xxxxx.

Xxx xxxxx xxxxxxx xxxx [**Xxxxxxx.Xxxxxxx.XxxxxxxXxxxxx.XxxXxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/BR227273) xx xxxxxxxx xxx xxxx xxxx xxx x xxx xx xxxxx. Xxxx xxxxxxxx xxxxxxxx xxxx xxxxxxxxxxx, xxxxxxx xxx xxxxxxx xxxxxxxx xxxx xxx xxxx xxxxxxxx.

> [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
```csharp
StorageFolder library = Windows.Storage.KnownFolders.PicturesLibrary;
IReadOnlyList<StorageFile> files = await library.GetFilesAsync(Windows.Storage.Search.CommonFileQuery.OrderByDate);

for (int i = 0; i < files.Count; i++)
{
    // do something with the name of each file
    string fileName = files[i].Name;
}
```
```vb
Dim library As StorageFolder = Windows.Storage.KnownFolders.PicturesLibrary
Dim files As IReadOnlyList(Of StorageFile) =
    Await library.GetFilesAsync(Windows.Storage.Search.CommonFileQuery.OrderByDate)

For i As Integer = 0 To files.Count - 1
    ' do something with the name of each file
    Dim fileName As String = files(i).Name
Next i
```

Xxx xxxxxx xxxxxxx xxxx [**Xxxxxxx.Xxxxxxx.XxxxxxxXxxxxx.XxxXxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/BR227273) xxx xxxx xxxxxxxxx xxx xxxxx xxxxxxxxxx xxx xxxx xxxx. Xxxx xxxxxxxx xxxxxxxx xxxx xxxxxxxxxxx.

> [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
```csharp
StorageFolder library = Windows.Storage.KnownFolders.PicturesLibrary;
IReadOnlyList<StorageFile> files = await library.GetFilesAsync(Windows.Storage.Search.CommonFileQuery.OrderByDate);
for (int i = 0; i < files.Count; i++)
{
    ImageProperties imgProps = await files[i].Properties.GetImagePropertiesAsync();

    // do something with the date the image was taken
    DateTimeOffset date = imgProps.DateTaken;
}
```
```vb
Dim library As StorageFolder = Windows.Storage.KnownFolders.PicturesLibrary
Dim files As IReadOnlyList(Of StorageFile) = Await library.GetFilesAsync(Windows.Storage.Search.CommonFileQuery.OrderByDate)
For i As Integer = 0 To files.Count - 1
    Dim imgProps As ImageProperties =
        Await files(i).Properties.GetImagePropertiesAsync()

    ' do something with the date the image was taken
    Dim dateTaken As DateTimeOffset = imgProps.DateTaken
Next i
```

Xxx xxxxx xxxxxxx xxxx [**XxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR207995) xx xxx xxxx xxxxx x xxx xx xxxxx. Xxxx xxxxxxxx xxxxxxxx xxxx xxxxxx xxxxxxxxxxx xxxx xxx xxxxxxxx xxxxxxx.

> [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
```csharp
// Set QueryOptions to prefetch our specific properties
var queryOptions = new Windows.Storage.Search.QueryOptions(CommonFileQuery.OrderByDate, null);
queryOptions.SetThumbnailPrefetch(ThumbnailMode.PicturesView, 100,
        ThumbnailOptions.ReturnOnlyIfCached);
queryOptions.SetPropertyPrefetch(PropertyPrefetchOptions.ImageProperties, 
       new string[] {"System.Size"});

StorageFileQueryResult queryResults = KnownFolders.PicturesLibrary.CreateFileQueryWithOptions(queryOptions);
IReadOnlyList<StorageFile> files = await queryResults.GetFilesAsync();

foreach (var file in files)
{
    ImageProperties imageProperties = await file.Properties.GetImagePropertiesAsync();

    // Do something with the date the image was taken.
    DateTimeOffset dateTaken = imageProperties.DateTaken;

    // Performance gains increase with the number of properties that are accessed.
    IDictionary<String, object> propertyResults =
        await file.Properties.RetrievePropertiesAsync(
              new string[] {"System.Size" });

    // Get/Set extra properties here
    var systemSize = propertyResults["System.Size"];

}
```
```vb
' Set QueryOptions to prefetch our specific properties
Dim queryOptions = New Windows.Storage.Search.QueryOptions(CommonFileQuery.OrderByDate, Nothing)
queryOptions.SetThumbnailPrefetch(ThumbnailMode.PicturesView,
            100, Windows.Storage.FileProperties.ThumbnailOptions.ReturnOnlyIfCached)
queryOptions.SetPropertyPrefetch(PropertyPrefetchOptions.ImageProperties,
                                 New String() {"System.Size"})

Dim queryResults As StorageFileQueryResult = KnownFolders.PicturesLibrary.CreateFileQueryWithOptions(queryOptions)
Dim files As IReadOnlyList(Of StorageFile) = Await queryResults.GetFilesAsync()


For Each file In files
    Dim imageProperties As ImageProperties = Await file.Properties.GetImagePropertiesAsync()

    ' Do something with the date the image was taken.
    Dim dateTaken As DateTimeOffset = imageProperties.DateTaken

    ' Performance gains increase with the number of properties that are accessed.
    Dim propertyResults As IDictionary(Of String, Object) =
        Await file.Properties.RetrievePropertiesAsync(New String() {"System.Size"})

    ' Get/Set extra properties here
    Dim systemSize = propertyResults("System.Size")

Next file
```
Xx xxx'xx xxxxxxxxxx xxxxxxxx xxxxxxxxxx xx Xxxxxxx.Xxxxxxx xxxxxxx xxxx xx `Windows.Storage.ApplicationData.Current.LocalFolder`, xxxxxx x xxxxx xxxxxxxx xx xxxxxxxxx xxxx xxxxxxx xxxxxx xx xxxx xxx xxx'x xxxxxxxx xxxxxxxxxxxx xxxxxxx xxxx xxxx xxx xxxxxx xx.

## Xxxxxx xxxxxxxxxxx xx X# xxx Xxxxxx Xxxxx

### Xxxxxxxxx xxxxxxx XXX xxx .XXX xxxxxxx

Xxxxx xxx xxxx xxxxxxxxx xxxx xxx xxxxx xxxx xx xxxxxxx x XXX xxxxxx (xxxx xx x [**Xxxxxxx.Xxxxxxx.Xxxxxxx.XXxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR241718) xx [**XXxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR241728)) xx x .XXX xxxxxx ([**Xxxxxx.XX.Xxxxxx**](https://msdn.microsoft.com/en-us/library/windows/apps/xaml/system.io.stream.aspx)). Xxx xxxxxxx, xxxx xx xxxxxx xxxx xxx xxx xxxxxxx x XXX xxx xxx xxxx xx xxx xxxxxxxx .XXX xxxx xxxx xxxxx xx xxxxxxx xxxx xxx XXX xxxx xxxxxx. Xx xxxxx xx xxxxxx xxxx, .XXX XXXx xxx Xxxxxxx Xxxxx xxxx xxxxxxxx xxxxxxxxx xxxxxxx xxxx xxxxx xxx xx xxxxxxx xxxxxxx .XXX xxx XXX xxxxxx xxxxx. Xxx xxxx xxxx, xxx [**XxxxxxxXxxxxxxXxxxxxXxxxxxxxxx**](https://msdn.microsoft.com/en-us/library/windows/apps/xaml/system.io.windowsruntimestreamextensions.aspx).

Xxxx xxx xxxxxxx x XXX xxxxxx xx x .XXX xxxxxx, xxx xxxxxxxxxxx xxxxxx xx xxxxxxx xxx xxx xxxxxxxxxx XXX xxxxxx. Xxxxx xxxx xxxxxxxxxxxxx, xxxxx xx x xxxxxxx xxxx xxxxxxxxxx xxxx xxxxxxxx xxxxxxx xx XXX xxxxxxx. Xxxx xxx xxxxxx xxx xxxxx xx xxxx xxx, xxxxxxxxxx xx xxxxxxxxx xxxxx xxx xxxxxxx xxxx xxxxx, xxxxxxxx xxxx xx xxxxx xxxxxxxxxx.

Xx xxxxx xx xxxxx xx xxxx, xxx XXX xxxxxx xxxxxxxx xxxxxxx x xxxx xxxxxx. Xxx xxxxxxxxx xxxx xxxxxx xxxxxxxxxxxx xxxxx xxxxxxxxxxx xxxxx xxxxx x XXX xxxxxx xxxxxxx xxxx x xxxxxxx xxxxxx xxxx.

> [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
```csharp
StorageFile file = await Windows.Storage.ApplicationData.Current
    .LocalFolder.GetFileAsync("example.txt");
Windows.Storage.Streams.IInputStream windowsRuntimeStream = 
    await file.OpenReadAsync();

byte[] destinationArray = new byte[8];

// Create an adapter with the default buffer size.
using (var managedStream = windowsRuntimeStream.AsStreamForRead())
{

    // Read 8 bytes into destinationArray.
    // A larger block is actually read from the underlying 
    // windowsRuntimeStream and buffered within the adapter.
    await managedStream.ReadAsync(destinationArray, 0, 8);

    // Read 8 more bytes into destinationArray.
    // This call may complete much faster than the first call
    // because the data is buffered and no call to the 
    // underlying windowsRuntimeStream needs to be made.
    await managedStream.ReadAsync(destinationArray, 0, 8);
}
```
```vb
Dim file As StorageFile = Await Windows.Storage.ApplicationData.Current -
.LocalFolder.GetFileAsync("example.txt")
Dim windowsRuntimeStream As Windows.Storage.Streams.IInputStream =
    Await file.OpenReadAsync()

Dim destinationArray() As Byte = New Byte(8) {}

' Create an adapter with the default buffer size.
Dim managedStream As Stream = windowsRuntimeStream.AsStreamForRead()
Using (managedStream)

    ' Read 8 bytes into destinationArray.
    ' A larger block is actually read from the underlying 
    ' windowsRuntimeStream and buffered within the adapter.
    Await managedStream.ReadAsync(destinationArray, 0, 8)

    ' Read 8 more bytes into destinationArray.
    ' This call may complete much faster than the first call
    ' because the data is buffered and no call to the 
    ' underlying windowsRuntimeStream needs to be made.
    Await managedStream.ReadAsync(destinationArray, 0, 8)

End Using
```

Xxxx xxxxxxx xxxxxxxxx xxxxxxxx xx xxxxxxxxx xx xxxx xxxxxxxxx xxxxx xxx xxxxxxx x XXX xxxxxx xx x .XXX xxxxxx. Xxxxxxx, xx xxxx xxxxxxxxx xxx xxx xxxx xx xxxxx xxx xxxxxxxxx xxxxxxxx xx xxxxx xx xxxxxxxx xxxxxxxxxxx.

### Xxxxxxx xxxx xxxxx xxxx xxxx

Xxxx xxxxxxx xx xxxxxxx xxxxxx xxxx xx xxxx xxx xxx xx xxxx xx xxxxxxxx xxxx xxxx xx xxxxx xxxxxxxxxx xx xxxxxxxxx x xxxxx xxxxxx xxxx xx xxx [**XxXxxxxxXxxXxxx**](Overload:System.IO.WindowsRuntimeStreamExtensions.AsStreamForRead), [**XxXxxxxxXxxXxxxx**](Overload:System.IO.WindowsRuntimeStreamExtensions.AsStreamForWrite), xxx [**XxXxxxxx**](Overload:System.IO.WindowsRuntimeStreamExtensions.AsStream) xxxxxxxxx xxxxxxx. Xxxx xxxxx xxx xxxxxx xxxxxxx x xxxxxx xxxxxxxx xxxxxx xxxx. Xxx xxxxxxxx, xxxx xxxxxxx x xxxxxx xxxx xxxxx xxxx x xxxxx xxxx xx xx XXX xxxxxx, xxx xxxxxx xxx xxxx xxxx xxxxxxxxxx xxxxx xxxxx xxxx xxx xxxxxx. X xxxxx xxxxxx xxx xxxxxx xxx xxxxxx xx xxxxx xx xxx xxxxxxxxxx XXX xxxxxx xxx xxxxx xxxxxxxxxxx.

> **Xxxx**   Xxx xxxxxx xx xxxxxxx xxxx xxxxxxx x xxxxxx xxxx xxxx xx xxxxxx xxxx xxxxxxxxxxxxx YY XX, xx xxxx xxx xxxxx xxxxxxxxxxxxx xx xxx xxxxxxx xxxxxxxxx xxxx (xxx [Xxxxxxx xxxxxxx xxxxxxxxxx xxxxxxxxxxx](improve-garbage-collection-performance.md)). Xxx xxxxxxxxx xxxx xxxxxxx xxxxxxx x xxxxxxx xxxxxx xxxxxxx xxxx xx YY,YYY xxxx xxxxxx.

> [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
```csharp
// Create a stream adapter with an 80 KB buffer.
Stream managedStream = nativeStream.AsStreamForRead(bufferSize: 81920);
```
```vb
' Create a stream adapter with an 80 KB buffer.
Dim managedStream As Stream = nativeStream.AsStreamForRead(bufferSize:=81920)
```

Xxx [**Xxxxxx.XxxxXx**](https://msdn.microsoft.com/en-us/library/windows/apps/xaml/system.io.stream.copyto.aspx) xxx [**XxxxXxXxxxx**](https://msdn.microsoft.com/en-us/library/windows/apps/xaml/system.io.stream.copytoasync.aspx) xxxxxxx xxxx xxxxxxxx x xxxxx xxxxxx xxx xxxxxxx xxxxxxx xxxxxxx. Xx xxxx xxx [**XxXxxxxxXxxXxxx**](https://msdn.microsoft.com/en-us/library/windows/apps/xaml/system.io.windowsruntimestreamextensions.asstreamforread.aspx) xxxxxxxxx xxxxxx, xxx xxx xx xxxx xx xxx xxxxxx xxxxxxxxxxx xxx xxxxx xxxxxx xxxxxx xx xxxxxxxxxx xxx xxxxxxx xxxxxx xxxx. Xxx xxxxxxxxx xxxx xxxxxxx xxxxxxxxxxxx xxxxxxxx xxx xxxxxxx xxxxxx xxxx xx x **XxxxXxXxxxx** xxxx.

> [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
```csharp
MemoryStream destination = new MemoryStream();
// copies the buffer into memory using the default copy buffer
await managedStream.CopyToAsync(destination);

// Copy the buffer into memory using a 1 MB copy buffer.
await managedStream.CopyToAsync(destination, bufferSize: 1024 * 1024);
```
```vb
Dim destination As MemoryStream = New MemoryStream()
' copies the buffer into memory using the default copy buffer
Await managedStream.CopyToAsync(destination)

' Copy the buffer into memory using a 1 MB copy buffer.
Await managedStream.CopyToAsync(destination, bufferSize:=1024 * 1024)
```

Xxxx xxxxxxx xxxx x xxxxxx xxxx xx Y XX, xxxxx xx xxxxxxx xxxx xxx YY XX xxxxxxxxxx xxxxxxxxxxx. Xxxxx xxxx x xxxxx xxxxxx xxx xxxxxxx xxxxxxxxxx xx xxx xxxx xxxxxxxxx xxx xxxx xxxxx xxxx xxxx (xxxx xx, xxxxxxx xxxxxxx xxxxxxxxx). Xxxxxxx, xxxx xxxxxx xx xxxxxxxxx xx xxx xxxxx xxxxxx xxxx xxx xxxxx xxxxxxxxxxx xxxxxxx xxxxxxx xxxxxxxxxx xxxxxxxxxxx. Xxx xxxxxx xxxx xxx xxxxx xxxxxx xxxxx xx xx xxxx xxxxxxxxxx xxxxxxx xxx xxxxxxxxxxx xx xxxx xxx.

Xxxx xxx xxx xxxxxxx xxxx x xxxxx xxxxxx xx xxxxxxx xxxxxxxxxxxxxx, xxx xxxxx xxxx xx xxxxxx xx xxxxxxxxx xxx xxxxxx xxxxxxxx xx xxx xxxxxx. Xxx xxx xxxxxxx x xxxxxxx xxxxxx, xx xxx xxx *xxxxxxXxxx* xxxxxxxxx xx Y xx xxxx xxx xxxxxxxxx xxxxxxxx xxx xxxx xxxxxx xxxxxxx. Xxx xxx xxxxx xxxxxxx xxxx xxxxxxxxxx xxxxxxxxxxx xxxxxxx xxxxxxxxx xx xxx xxxxxxx xxxxx xxxxx xxx xxxxxx xx xxx xxxxxxx xxxxxx.

### Xxxxxxxxxx xxxxxxx-xxxxxxxxx xxxxxxxxxx

Xxx xxxxx xxxx xxxx xx xxxxx xxxxxxxxx xx xxx xxxx xxx-xxxxxxx xxxxx xxx xxxxxx xxx xx xxx xxxx xx xxxx xx xxxxx xxxxxx xxx xx xxx xxxxxxxxxx XXX xxxxxx. Xxx xxxxxxx, xxx xxxxx xxxx xxx-xxxxxxx xxxxx xxx xxxxxx xx xxx xxx xxxxx xxx xxxxxx xxx xxxxxxx xxxxxxxxxxxxxx.

Xx x xxxx xxx xxx xxxxx xxx x xxxxxx xxxx x xxxxxxx xxxxxxxxx xx xxxx xxxxxxxx xxxx xx xxxxx. Xx xxxx xxxx xxx xxxx xx xxxx xxxxxxxx xx xxxx xx xxxx xxx xxxxx xxx xxx xxxx xxx xxx xxxxxx xx xxxx xx. Xx xxx xxx xxx xxxxxx xxxx xx Y xxxx xxxxxxx xxx [**XxXxxxxxXxxXxxx**](Overload:System.IO.WindowsRuntimeStreamExtensions.AsStreamForRead), [**XxXxxxxxXxxXxxxx**](Overload:System.IO.WindowsRuntimeStreamExtensions.AsStreamForWrite), xxx [**XxXxxxxx**](Overload:System.IO.WindowsRuntimeStreamExtensions.AsStream) xxxxxxxxx xxxxxxx, xxxx xxx xxxxxxxxx xxxxxxx xxxx xxx xxxxxxxx x xxxxxx, xxx xxx xxxxx xxxx xxxxxxxxxx xxx xxxxxxxxxx XXX xxxxxx xxxxxxxx.


<!--HONumber=Mar16_HO1-->
