---
xx.xxxxxxx: YYYYYXYX-YXYY-YYYX-XXXY-XYYYXYYYYXXY
xxxxx: Xxxxxx, xxxxx, xxx xxxx x xxxx
xxxxxxxxxxx: Xxxx xxx xxxxx x xxxx xxxxx x XxxxxxxXxxx xxxxxx.
---

# Xxxxxx, xxxxx, xxx xxxx x xxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


**Xxxxxxxxx XXXx**

-   [**XxxxxxxXxxxxx xxxxx**](https://msdn.microsoft.com/library/windows/apps/br227230)
-   [**XxxxxxxXxxx xxxxx**](https://msdn.microsoft.com/library/windows/apps/br227171)
-   [**XxxxXX xxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701440)

Xxxx xxx xxxxx x xxxx xxxxx x [**XxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br227171) xxxxxx.

> **Xxxx**  Xxxx xxx xxx [Xxxx xxxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619995).

## Xxxxxxxxxxxxx

-   **Xxxxxxxxxx xxxxx xxxxxxxxxxx xxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx**

    Xxx xxx xxxxx xxx xx xxxxx xxxxxxxxxxxx xxxx xx X# xx Xxxxxx Xxxxx, xxx [Xxxx xxxxxxxxxxxx XXXx xx X# xx Xxxxxx Xxxxx](https://msdn.microsoft.com/library/windows/apps/mt187337). Xx xxxxx xxx xx xxxxx xxxxxxxxxxxx xxxx xx X++, xxx [Xxxxxxxxxxxx xxxxxxxxxxx xx X++](https://msdn.microsoft.com/library/windows/apps/mt187334).

-   **Xxxx xxx xx xxx xxx xxxx xxxx xxx xxxx xx xxxx xxxx, xxxxx xx, xx xxxx**

    Xxx xxx xxxxx xxx xx xxx x xxxx xx xxxxx x xxxx xxxxxx xx [Xxxx xxxxx xxx xxxxxxx xxxx x xxxxxx](quickstart-using-file-and-folder-pickers.md).

## Xxxxxxxx x xxxx

Xxxx'x xxx xx xxxxxx x xxxx xx xxx xxx'x xxxxx xxxxxx. Xx xx xxxxxxx xxxxxx, xx xxxxxxx xx.
> [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
```cs
// Create sample file; replace if exists.
Windows.Storage.StorageFolder storageFolder =
    Windows.Storage.ApplicationData.Current.LocalFolder;
Windows.Storage.StorageFile sampleFile =
    await storageFolder.CreateFileAsync("sample.txt",
        Windows.Storage.CreationCollisionOption.ReplaceExisting);
```
```vb
' Create sample file; replace if exists.
Dim storageFolder As StorageFolder = Windows.Storage.ApplicationData.Current.LocalFolder
Dim sampleFile As StorageFile = Await storageFolder.CreateFileAsync("sample.txt", CreationCollisionOption.ReplaceExisting)
```

## Xxxxxxx xx x xxxx


Xxxx'x xxx xx xxxxx xx x xxxxxxxx xxxx xx xxxx xxxxx xxx [**XxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br227171) xxxxx. Xxx xxxxxx xxxxx xxxx xxx xxxx xx xxx xxxx xx xxxxxxx xx x xxxx (xxxxxx xxx'xx xxxxxxx xx xxx xxxx xxxxxxxxxxx xxxxx xxxxxxxx xx) xx xx xxx xxx xxxx xxxx [**XxxxxxxXxxxxx.XxxXxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br227272).
> [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
```cs
Windows.Storage.StorageFolder storageFolder =
    Windows.Storage.ApplicationData.Current.LocalFolder;
Windows.Storage.StorageFile sampleFile =
    await storageFolder.GetFileAsync("sample.txt");
```
```vb
Dim storageFolder As StorageFolder = Windows.Storage.ApplicationData.Current.LocalFolder
Dim sampleFile As StorageFile = Await storageFolder.GetFileAsync("sample.txt")
```

**Xxxxxxx xxxx xx x xxxx**

Xxxxx xxxx xx xxxx xxxx xx xxxxxxx xxx [**XxxxxXxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701505) xxxxxx xx xxx [**XxxxXX**](https://msdn.microsoft.com/library/windows/apps/hh701440) xxxxx.
> [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
```cs
await Windows.Storage.FileIO.WriteTextAsync(sampleFile, "Swift as a shadow");
```
```vb
Await Windows.Storage.FileIO.WriteTextAsync(sampleFile, "Swift as a shadow")
```

**Xxxxxxx xxxxx xx x xxxx xx xxxxx x xxxxxx (Y xxxxx)**

1.  Xxxxx, xxxx [**XxxxxxxXxxxxxXxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br241385) xx xxx x xxxxxx xx xxx xxxxx (xxxxx xx xx xxxxxxxxx xxxxxx) xxxx xxx xxxx xx xxxxx xx xxxx xxxx.
> [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
```cs
var buffer = Windows.Security.Cryptography.CryptographicBuffer.ConvertStringToBinary(
        "What fools these mortals be", Windows.Security.Cryptography.BinaryStringEncoding.Utf8);
```
```vb
Dim buffer = Windows.Security.Cryptography.CryptographicBuffer.ConvertStringToBinary(
                    "What fools these mortals be",
                    Windows.Security.Cryptography.BinaryStringEncoding.Utf8)
```

2.  Xxxx xxxxx xxx xxxxx xxxx xxxx xxxxxx xx xxxx xxxx xx xxxxxxx xxx [**XxxxxXxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701490) xxxxxx xx xxx [**XxxxXX**](https://msdn.microsoft.com/library/windows/apps/hh701440) xxxxx.
> [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
```cs
await Windows.Storage.FileIO.WriteBufferAsync(sampleFile, buffer);
```
```vb
Await Windows.Storage.FileIO.WriteBufferAsync(sampleFile, buffer)
```

**Xxxxxxx xxxx xx x xxxx xx xxxxx x xxxxxx (Y xxxxx)**

1.  Xxxxx, xxxx xxx xxxx xx xxxxxxx xxx [**XxxxxxxXxxx.XxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn889851) xxxxxx. Xx xxxxxxx x xxxxxx xx xxx xxxx'x xxxxxxx xxxx xxx xxxx xxxxxxxxx xxxxxxxxx.
> [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
```cs
var stream = await sampleFile.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite);
```
```vb
Dim stream = Await sampleFile.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite)
```

2.  Xxxx, xxx xx xxxxxx xxxxxx xx xxxxxxx xxx [**XxxXxxxxxXxxxxxXx**](https://msdn.microsoft.com/library/windows/apps/br241738) xxxxxx xxxx xxx `stream`. Xxx xxxx xx x **xxxxx** xxxxxxxxx xx xxxxxx xxx xxxxxx xxxxxx'x xxxxxxxx.
> [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
```cs
using (var outputStream = stream.GetOutputStreamAt(0))
    {
        // We'll add more code here in the next step.
    }
    stream.Dispose(); // Or use the stream variable (see previous code snippet) with a using statement as well.
```
```vb
Using outputStream = stream.GetOutputStreamAt(0)
  ' We'll add more code here in the next step.
End Using
```

3.  Xxx xxx xxxx xxxx xxxxxx xxx xxxxxxxx **xxxxx** xxxxxxxxx xx xxxxx xx xxx xxxxxx xxxxxx xx xxxxxxxx x xxx [**XxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208154) xxxxxx xxx xxxxxxx xxx [**XxxxXxxxxx.XxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br241642) xxxxxx.
> [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
```cs
using (var dataWriter = new Windows.Storage.Streams.DataWriter(outputStream))
    {
        dataWriter.WriteString("DataWriter has methods to write to various types, such as DataTimeOffset.");
    }
```
```vb
    Dim dataWriter As New DataWriter(outputStream)
    
    dataWriter.WriteString("DataWriter has methods to write to various types, such as DataTimeOffset.")
```

4.  Xxxxxx, xxx xxxx xxxx (xxxxxx xxx xxxxx **xxxxx** xxxxxxxxx) xx xxxx xxx xxxx xx xxxx xxxx xxxx [**XxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br208171) xxx xxxxx xxx xxxxxx xxxx [**XxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br241729).
> [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
```cs
    await dataWriter.StoreAsync();
        await outputStream.FlushAsync(); 
```
```vb
    Await dataWriter.StoreAsync()
        Await outputStream.FlushAsync()
```

## Xxxxxxx xxxx x xxxx


Xxxx'x xxx xx xxxx xxxx x xxxx xx xxxx xxxxx xxx [**XxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br227171) xxxxx. Xxx xxxxxx xxxxx xxxx xxx xxxx xx xxx xxxx xx xxxxxxx xxxx x xxxx xx xx xxx xxx xxxx xxxx [**XxxxxxxXxxxxx.XxxXxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br227272).
> [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
```cs
Windows.Storage.StorageFolder storageFolder =
    Windows.Storage.ApplicationData.Current.LocalFolder;
Windows.Storage.StorageFile sampleFile =
    await storageFolder.GetFileAsync("sample.txt");
```
```vb
Dim storageFolder As StorageFolder = Windows.Storage.ApplicationData.Current.LocalFolder
Dim sampleFile As StorageFile = Await storageFolder.GetFileAsync("sample.txt")
```

**Xxxxxxx xxxx xxxx x xxxx**

Xxxx xxxx xxxx xxxx xxxx xx xxxxxxx xxx [**XxxxXxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701482) xxxxxx xx xxx [**XxxxXX**](https://msdn.microsoft.com/library/windows/apps/hh701440) xxxxx.
> [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
```cs
string text = await Windows.Storage.FileIO.ReadTextAsync(sampleFile);
```
```vb
Dim text As String = Await Windows.Storage.FileIO.ReadTextAsync(sampleFile)
```

**Xxxxxxx xxxxx xxxx x xxxx xx xxxxx x xxxxxx (Y xxxxx)**

1.  Xxxxx, xxxx xxxxx xxxx xxxx xxxxxx xx xxxx xxxx xx xxxxxxx xxx [**XxxxXxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701468) xxxxxx xx xxx [**XxxxXX**](https://msdn.microsoft.com/library/windows/apps/hh701440) xxxxx.
> [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
```cs
var buffer = await Windows.Storage.FileIO.ReadBufferAsync(sampleFile);
```
```vb
Dim buffer = Await Windows.Storage.FileIO.ReadBufferAsync(sampleFile)
```

2.  Xxxx xxx x [**XxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208119) xxxxxx xx xxxx xxxxx xxx xxxxxx xx xxx xxxxxx xxx xxxx xxx xxxxxxxx.
> [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
```cs
using (var dataReader = Windows.Storage.Streams.DataReader.FromBuffer(buffer))
    {
        string text = dataReader.ReadString(buffer.Length);
    }
```
```vb
Dim dataReader As DataReader = Windows.Storage.Streams.DataReader.FromBuffer(buffer)
    Dim text As String = dataReader.ReadString(buffer.Length)
```

**Xxxxxxx xxxx xxxx x xxxx xx xxxxx x xxxxxx (Y xxxxx)**

1.  Xxxx x xxxxxx xxx xxxx xxxx xx xxxxxxx xxx [**XxxxxxxXxxx.XxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn889851) xxxxxx. Xx xxxxxxx x xxxxxx xx xxx xxxx'x xxxxxxx xxxx xxx xxxxxxxxx xxxxxxxxx.
> [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
```cs
var stream = await sampleFile.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite);
```
```vb
Dim stream = Await sampleFile.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite)
```

2.  Xxx xxx xxxx xx xxx xxxxxx xx xxx xxxxx.
> [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
```cs
ulong size = stream.Size;
```
```vb
Dim size = stream.Size
```

3.  Xxx xx xxxxx xxxxxx xx xxxxxxx xxx [**XxxXxxxxXxxxxxXx**](https://msdn.microsoft.com/library/windows/apps/br241737) xxxxxx. Xxx xxxx xx x **xxxxx** xxxxxxxxx xx xxxxxx xxx xxxxxx'x xxxxxxxx. Xxxxxxx Y xxxx xxx xxxx **XxxXxxxxXxxxxxXx** xx xxx xxx xxxxxxxx xx xxx xxxxxxxxx xx xxx xxxxxx.
> [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
```cs
using (var inputStream = stream.GetInputStreamAt(0))
    {
        // We'll add more code here in the next step.
    }
```
```vb
Using inputStream = stream.GetInputStreamAt(0)
    ' We'll add more code here in the next step.
End Using
```

4.  Xxxxxx, xxx xxxx xxxx xxxxxx xxx xxxxxxxx **xxxxx** xxxxxxxxx xx xxx x [**XxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208119) xxxxxx xx xxx xxxxxx xxxx xxxx xxx xxxx xx xxxxxxx [**XxxxXxxxxx.XxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br208135) xxx [**XxxxXxxxxx.XxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208147).
> [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
```cs
using (var dataReader = new Windows.Storage.Streams.DataReader(inputStream))
    {
        uint numBytesLoaded = await dataReader.LoadAsync((uint)size);
        string text = dataReader.ReadString(numBytesLoaded);
    }
```
```vb
Dim dataReader As New DataReader(inputStream)
    Dim numBytesLoaded As UInteger = Await dataReader.LoadAsync(CUInt(size))
    Dim text As String = dataReader.ReadString(numBytesLoaded)
```

 

 




<!--HONumber=Mar16_HO1-->
