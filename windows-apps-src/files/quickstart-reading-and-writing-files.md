---
ms.assetid: 27914C0A-2A02-473F-BDD5-C931E3943AA0
title: ファイルの作成、書き込み、および読み取り
description: StorageFile オブジェクトを使ってファイルの読み取りと書き込みを行います。
ms.date: 12/19/2018
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
dev_langs:
- csharp
- cppwinrt
- cpp
- vb
ms.openlocfilehash: 6ff7b37eee4f2b9228a635a117e164d7d9859629
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57610997"
---
# <a name="create-write-and-read-a-file"></a>ファイルの作成、書き込み、および読み取り

**重要な API**

-   [**StorageFolder クラス**](/uwp/api/windows.storage.storagefolder)
-   [**StorageFile クラス**](/uwp/api/windows.storage.storagefile)
-   [**FileIO クラス**](/uwp/api/windows.storage.fileio)

[  **StorageFile**](/uwp/api/windows.storage.storagefile) オブジェクトを使ってファイルの読み取りと書き込みを行います。

> [!NOTE]
> 完全なサンプルを参照してください、[ファイル アクセス サンプル](https://go.microsoft.com/fwlink/p/?linkid=619995)します。

## <a name="prerequisites"></a>前提条件

-   **ユニバーサル Windows プラットフォーム (UWP) アプリの非同期プログラミングを理解します。**

    C# や Visual Basic での非同期アプリの作成方法については、「[C# または Visual Basic での非同期 API の呼び出し](/windows/uwp/threading-async/call-asynchronous-apis-in-csharp-or-visual-basic)」をご覧ください。 C + で非同期アプリを作成する方法について/cli WinRT を参照してください[同時実行と非同期操作を C +/cli WinRT](/windows/uwp/cpp-and-winrt-apis/concurrency)します。 C + で非同期アプリを作成する方法について/cli CX を参照してください[非同期プログラミングの C +/cli CX](/windows/uwp/threading-async/asynchronous-programming-in-cpp-universal-windows-platform-apps)します。

-   **読み取り、書き込み、ファイルを取得する方法、またはその両方を知っています。**

    ファイル ピッカーを使ってファイルを取得する方法については、「[ピッカーでファイルやフォルダーを開く](quickstart-using-file-and-folder-pickers.md)」をご覧ください。

## <a name="creating-a-file"></a>ファイルの作成

アプリのローカル フォルダーにファイルを作成する方法について説明します。 既に存在する場合は置き換えます。

```csharp
// Create sample file; replace if exists.
Windows.Storage.StorageFolder storageFolder =
    Windows.Storage.ApplicationData.Current.LocalFolder;
Windows.Storage.StorageFile sampleFile =
    await storageFolder.CreateFileAsync("sample.txt",
        Windows.Storage.CreationCollisionOption.ReplaceExisting);
```

```cppwinrt
// MainPage.h
#include <winrt/Windows.Storage.h>
...
Windows::Foundation::IAsyncAction ExampleCoroutineAsync()
{
    // Create a sample file; replace if exists.
    Windows::Storage::StorageFolder storageFolder{ Windows::Storage::ApplicationData::Current().LocalFolder() };
    co_await storageFolder.CreateFileAsync(L"sample.txt", Windows::Storage::CreationCollisionOption::ReplaceExisting);
}
```

```cpp
// Create a sample file; replace if exists.
StorageFolder^ storageFolder = ApplicationData::Current->LocalFolder;
concurrency::create_task(storageFolder->CreateFileAsync("sample.txt", CreationCollisionOption::ReplaceExisting));
```

```vb
' Create sample file; replace if exists.
Dim storageFolder As StorageFolder = Windows.Storage.ApplicationData.Current.LocalFolder
Dim sampleFile As StorageFile = Await storageFolder.CreateFileAsync("sample.txt", CreationCollisionOption.ReplaceExisting)
```

## <a name="writing-to-a-file"></a>ファイルへの書き込み

[  **StorageFile**](/uwp/api/windows.storage.storagefile) クラスを使ってディスク上の書き込み可能ファイルに書き込む方法について説明します。 いずれの方法でファイルに書き込む場合でも (ファイルの作成直後に書き込むのでない限り)、まずは [**StorageFolder.GetFileAsync**](/uwp/api/windows.storage.storagefolder.getfileasync) でファイルを取得します。

```csharp
Windows.Storage.StorageFolder storageFolder =
    Windows.Storage.ApplicationData.Current.LocalFolder;
Windows.Storage.StorageFile sampleFile =
    await storageFolder.GetFileAsync("sample.txt");
```

```cppwinrt
// MainPage.h
#include <winrt/Windows.Storage.h>
...
Windows::Foundation::IAsyncAction ExampleCoroutineAsync()
{
    Windows::Storage::StorageFolder storageFolder{ Windows::Storage::ApplicationData::Current().LocalFolder() };
    auto sampleFile{ co_await storageFolder.CreateFileAsync(L"sample.txt", Windows::Storage::CreationCollisionOption::ReplaceExisting) };
    // Process sampleFile
}
```

```cpp
StorageFolder^ storageFolder = ApplicationData::Current->LocalFolder;
create_task(storageFolder->GetFileAsync("sample.txt")).then([](StorageFile^ sampleFile) 
{
    // Process file
});
```

```vb
Dim storageFolder As StorageFolder = Windows.Storage.ApplicationData.Current.LocalFolder
Dim sampleFile As StorageFile = Await storageFolder.GetFileAsync("sample.txt")
```

**テキスト ファイルへの書き込み**

テキストを呼び出すことによって、ファイルを書き込む、 [ **FileIO.WriteTextAsync** ](/uwp/api/windows.storage.fileio.writetextasync)メソッド。

```csharp
await Windows.Storage.FileIO.WriteTextAsync(sampleFile, "Swift as a shadow");
```

```cppwinrt
// MainPage.h
#include <winrt/Windows.Storage.h>
...
Windows::Foundation::IAsyncAction ExampleCoroutineAsync()
{
    Windows::Storage::StorageFolder storageFolder{ Windows::Storage::ApplicationData::Current().LocalFolder() };
    auto sampleFile{ co_await storageFolder.GetFileAsync(L"sample.txt") };
    // Write text to the file.
    co_await Windows::Storage::FileIO::WriteTextAsync(sampleFile, L"Swift as a shadow");
}
```

```cpp
StorageFolder^ storageFolder = ApplicationData::Current->LocalFolder;
create_task(storageFolder->GetFileAsync("sample.txt")).then([](StorageFile^ sampleFile) 
{
    //Write text to a file
    create_task(FileIO::WriteTextAsync(sampleFile, "Swift as a shadow"));
});
```

```vb
Await Windows.Storage.FileIO.WriteTextAsync(sampleFile, "Swift as a shadow")
```

**バッファー (2 つの手順) を使用して、ファイルにバイトを書き込む**

1.  最初に、呼び出す[ **CryptographicBuffer.ConvertStringToBinary** ](/uwp/api/windows.security.cryptography.cryptographicbuffer.convertstringtobinary) (文字列に基づく) バイトのバッファーを取得する、ファイルへの書き込みにします。

    ```csharp
    var buffer = Windows.Security.Cryptography.CryptographicBuffer.ConvertStringToBinary(
        "What fools these mortals be", Windows.Security.Cryptography.BinaryStringEncoding.Utf8);
    ```

    ```cppwinrt
    // MainPage.h
    #include <winrt/Windows.Security.Cryptography.h>
    #include <winrt/Windows.Storage.h>
    #include <winrt/Windows.Storage.Streams.h>
    ...
    Windows::Foundation::IAsyncAction ExampleCoroutineAsync()
    {
        Windows::Storage::StorageFolder storageFolder{ Windows::Storage::ApplicationData::Current().LocalFolder() };
        auto sampleFile{ co_await storageFolder.GetFileAsync(L"sample.txt") };
        // Create the buffer.
        Windows::Storage::Streams::IBuffer buffer{
            Windows::Security::Cryptography::CryptographicBuffer::ConvertStringToBinary(
                L"What fools these mortals be", Windows::Security::Cryptography::BinaryStringEncoding::Utf8)};
        // The code in step 2 goes here.
    }
    ```

    ```cpp
    StorageFolder^ storageFolder = ApplicationData::Current->LocalFolder;
    create_task(storageFolder->GetFileAsync("sample.txt")).then([](StorageFile^ sampleFile)
    {
        // Create the buffer
        IBuffer^ buffer = CryptographicBuffer::ConvertStringToBinary
        ("What fools these mortals be", BinaryStringEncoding::Utf8);
    });
    ```

    ```vb
    Dim buffer = Windows.Security.Cryptography.CryptographicBuffer.ConvertStringToBinary(
        "What fools these mortals be",
        Windows.Security.Cryptography.BinaryStringEncoding.Utf8)
    ```

2.  呼び出すことによっては、バッファーから、ファイルのバイト数を記述し、 [ **FileIO.WriteBufferAsync** ](/uwp/api/windows.storage.fileio.writebufferasync)メソッド。

    ```csharp
    await Windows.Storage.FileIO.WriteBufferAsync(sampleFile, buffer);
    ```

    ```cppwinrt
    co_await Windows::Storage::FileIO::WriteBufferAsync(sampleFile, buffer);
    ```
    
    ```cpp
    StorageFolder^ storageFolder = ApplicationData::Current->LocalFolder;
    create_task(storageFolder->GetFileAsync("sample.txt")).then([](StorageFile^ sampleFile)
    {
        // Create the buffer
        IBuffer^ buffer = CryptographicBuffer::ConvertStringToBinary
        ("What fools these mortals be", BinaryStringEncoding::Utf8);      
        // Write bytes to a file using a buffer
        create_task(FileIO::WriteBufferAsync(sampleFile, buffer));
    });
    ```
    
    ```vb
    Await Windows.Storage.FileIO.WriteBufferAsync(sampleFile, buffer)
    ```

**ストリーム (4 つの手順) を使用してテキスト ファイルへの書き込み**

1.  まず、[**StorageFile.OpenAsync**](/uwp/api/windows.storage.storagefile.openasync) メソッドを呼び出してファイルを開きます。 このメソッドは、オープン操作が完了したときにファイルのコンテンツのストリームを返します。

    ```csharp
    var stream = await sampleFile.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite);
    ```
    
    ```cppwinrt
    // MainPage.h
    #include <winrt/Windows.Storage.h>
    #include <winrt/Windows.Storage.Streams.h>
    ...
    Windows::Foundation::IAsyncAction ExampleCoroutineAsync()
    {
        Windows::Storage::StorageFolder storageFolder{ Windows::Storage::ApplicationData::Current().LocalFolder() };
        auto sampleFile{ co_await storageFolder.GetFileAsync(L"sample.txt") };
        Windows::Storage::Streams::IRandomAccessStream stream{ co_await sampleFile.OpenAsync(Windows::Storage::FileAccessMode::ReadWrite) };
        // The code in step 2 goes here.
    }
    ```
    
    ```cpp
    StorageFolder^ storageFolder = ApplicationData::Current->LocalFolder;
    create_task(storageFolder->GetFileAsync("sample.txt")).then([](StorageFile^ sampleFile)
    {
        create_task(sampleFile->OpenAsync(FileAccessMode::ReadWrite)).then([sampleFile](IRandomAccessStream^ stream)
        {
            // Process stream
        });
    });
    ```
    
    ```vb
    Dim stream = Await sampleFile.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite)
    ```

2.  次に、呼び出すことによって、出力ストリームを取得、 [ **IRandomAccessStream.GetOutputStreamAt** ](/uwp/api/windows.storage.streams.irandomaccessstream.getoutputstreamat)からメソッド、`stream`します。 使用している場合C#でこれを囲む、**を使用して**ステートメントを出力ストリームの有効期間を管理します。 使用している場合[C +/cli WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)、ブロックでそれを囲むまたはに設定すると、その有効期間を制御できるよう`nullptr`を終了するとき。

    ```csharp
    using (var outputStream = stream.GetOutputStreamAt(0))
    {
        // We'll add more code here in the next step.
    }
    stream.Dispose(); // Or use the stream variable (see previous code snippet) with a using statement as well.
    ```
    
    ```cppwinrt
    Windows::Storage::Streams::IOutputStream outputStream{ stream.GetOutputStreamAt(0) };
    // The code in step 3 goes here.
    ```
    
    ```cpp
    // Add to "Process stream" in part 1
    IOutputStream^ outputStream = stream->GetOutputStreamAt(0);
    ```
    
    ```vb
    Using outputStream = stream.GetOutputStreamAt(0)
    ' We'll add more code here in the next step.
    End Using
    ```

3.  このコードを追加するようになりました (を使用する場合C#、既存**を使用して**ステートメント) を出力ストリームに書き込む新しい[ **datawriter の各**](/uwp/api/windows.storage.streams.datawriter)オブジェクトと呼び出し、[ **DataWriter.WriteString** ](/uwp/api/windows.storage.streams.datawriter.writestring)メソッド。

    ```csharp
    using (var dataWriter = new Windows.Storage.Streams.DataWriter(outputStream))
    {
        dataWriter.WriteString("DataWriter has methods to write to various types, such as DataTimeOffset.");
    }
    ```
    
    ```cppwinrt
    Windows::Storage::Streams::DataWriter dataWriter;
    dataWriter.WriteString(L"DataWriter has methods to write to various types, such as DataTimeOffset.");
    // The code in step 4 goes here.
    ```
    
    ```cpp
    // Added after code from part 2
    DataWriter^ dataWriter = ref new DataWriter(outputStream);
    dataWriter->WriteString("DataWriter has methods to write to various types, such as DataTimeOffset.");
    ```
    
    ```vb
    Dim dataWriter As New DataWriter(outputStream)
    dataWriter.WriteString("DataWriter has methods to write to various types, such as DataTimeOffset.")
    ```

4.  最後に、次のコードを追加 (を使用する場合C#、内部内**を使用して**ステートメント) を使用して、ファイルのテキストを保存する[ **DataWriter.StoreAsync** ](/uwp/api/windows.storage.streams.datawriter.storeasync) 、ストリームを閉じると[ **IOutputStream.FlushAsync**](/uwp/api/windows.storage.streams.ioutputstream.flushasync)します。

    ```csharp
    await dataWriter.StoreAsync();
    await outputStream.FlushAsync();
    ```
    
    ```cppwinrt
    dataWriter.StoreAsync();
    outputStream.FlushAsync();
    ```
    
    ```cpp
    // Added after code from part 3
    dataWriter->StoreAsync();
    outputStream->FlushAsync();
    ```
    
    ```vb
    Await dataWriter.StoreAsync()
    Await outputStream.FlushAsync()
    ```

**ファイルに書き込むためのベスト プラクティス**

追加の詳細とベスト プラクティス ガイダンスでは、[ファイルに書き込むためのベスト プラクティス](best-practices-for-writing-to-files.md)を参照してください。
    
## <a name="reading-from-a-file"></a>ファイルからの読み取り

[  **StorageFile**](/uwp/api/Windows.Storage.StorageFile) クラスを使ってディスク上のファイルから読み取る方法について説明します。 いずれの方法でファイルから読み取る場合でも、まずは [**StorageFolder.GetFileAsync**](/uwp/api/windows.storage.storagefolder.getfileasync) を使ってファイルを取得します。

```csharp
Windows.Storage.StorageFolder storageFolder =
    Windows.Storage.ApplicationData.Current.LocalFolder;
Windows.Storage.StorageFile sampleFile =
    await storageFolder.GetFileAsync("sample.txt");
```

```cppwinrt
Windows::Storage::StorageFolder storageFolder{ Windows::Storage::ApplicationData::Current().LocalFolder() };
auto sampleFile{ co_await storageFolder.GetFileAsync(L"sample.txt") };
// Process file
```

```cpp
StorageFolder^ storageFolder = ApplicationData::Current->LocalFolder;
create_task(storageFolder->GetFileAsync("sample.txt")).then([](StorageFile^ sampleFile)
{
    // Process file
});
```

```vb
Dim storageFolder As StorageFolder = Windows.Storage.ApplicationData.Current.LocalFolder
Dim sampleFile As StorageFile = Await storageFolder.GetFileAsync("sample.txt")
```

**ファイルからテキストを読み取る**

呼び出すことによって、ファイルからテキストを読み取る、 [ **FileIO.ReadTextAsync** ](/uwp/api/windows.storage.fileio.readtextasync)メソッド。

```csharp
string text = await Windows.Storage.FileIO.ReadTextAsync(sampleFile);
```

```cppwinrt
Windows::Foundation::IAsyncOperation<winrt::hstring> ExampleCoroutineAsync()
{
    Windows::Storage::StorageFolder storageFolder{ Windows::Storage::ApplicationData::Current().LocalFolder() };
    auto sampleFile{ co_await storageFolder.GetFileAsync(L"sample.txt") };
    co_return co_await Windows::Storage::FileIO::ReadTextAsync(sampleFile);
}
```

```cpp
StorageFolder^ storageFolder = ApplicationData::Current->LocalFolder;
create_task(storageFolder->GetFileAsync("sample.txt")).then([](StorageFile^ sampleFile)
{
    return FileIO::ReadTextAsync(sampleFile);
});
```

```vb
Dim text As String = Await Windows.Storage.FileIO.ReadTextAsync(sampleFile)
```

**バッファー (2 つの手順) を使用して、ファイルからテキストを読み取る**

1.  最初に、呼び出し、 [ **FileIO.ReadBufferAsync** ](/uwp/api/windows.storage.fileio.readbufferasync)メソッド。

    ```csharp
    var buffer = await Windows.Storage.FileIO.ReadBufferAsync(sampleFile);
    ```
    
    ```cppwinrt
    Windows::Storage::StorageFolder storageFolder{ Windows::Storage::ApplicationData::Current().LocalFolder() };
    auto sampleFile{ co_await storageFolder.GetFileAsync(L"sample.txt") };
    Windows::Storage::Streams::IBuffer buffer{ co_await Windows::Storage::FileIO::ReadBufferAsync(sampleFile) };
    // The code in step 2 goes here.
    ```
    
    ```cpp
    StorageFolder^ storageFolder = ApplicationData::Current->LocalFolder;
    create_task(storageFolder->GetFileAsync("sample.txt")).then([](StorageFile^ sampleFile)
    {
        return FileIO::ReadBufferAsync(sampleFile);
    
    }).then([](Streams::IBuffer^ buffer)
    {
        // Process buffer
    });
    ```
    
    ```vb
    Dim buffer = Await Windows.Storage.FileIO.ReadBufferAsync(sampleFile)
    ```

2.  次に、[**DataReader**](/uwp/api/windows.storage.streams.datareader) オブジェクトを使ってバッファーの長さを読み取り、次にバッファーのコンテンツを読み取ります。

    ```csharp
    using (var dataReader = Windows.Storage.Streams.DataReader.FromBuffer(buffer))
    {
        string text = dataReader.ReadString(buffer.Length);
    }
    ```
    
    ```cppwinrt
    auto dataReader{ Windows::Storage::Streams::DataReader::FromBuffer(buffer) };
    winrt::hstring bufferText{ dataReader.ReadString(buffer.Length()) };
    ```
    
    ```cpp
    // Add to "Process buffer" section from part 1
    auto dataReader = DataReader::FromBuffer(buffer);
    String^ bufferText = dataReader->ReadString(buffer->Length);
    ```
    
    ```vb
    Dim dataReader As DataReader = Windows.Storage.Streams.DataReader.FromBuffer(buffer)
    Dim text As String = dataReader.ReadString(buffer.Length)
    ```

**テキスト ストリーム (4 つの手順) を使用してファイルからの読み取り**

1.  [  **StorageFile.OpenAsync**](/uwp/api/windows.storage.storagefile.openasync) メソッドを呼び出してファイルに対するストリームを開きます。 このメソッドは、操作が完了したときにファイルのコンテンツのストリームを返します。

    ```csharp
    var stream = await sampleFile.OpenAsync(Windows.Storage.FileAccessMode.Read);
    ```
    
    ```cppwinrt
    Windows::Storage::StorageFolder storageFolder{ Windows::Storage::ApplicationData::Current().LocalFolder() };
    auto sampleFile{ co_await storageFolder.GetFileAsync(L"sample.txt") };
    Windows::Storage::Streams::IRandomAccessStream stream{ co_await sampleFile.OpenAsync(Windows::Storage::FileAccessMode::Read) };
    // The code in step 2 goes here.
    ```
    
    ```cpp
    StorageFolder^ storageFolder = ApplicationData::Current->LocalFolder;
    create_task(storageFolder->GetFileAsync("sample.txt")).then([](StorageFile^ sampleFile)
    {
        create_task(sampleFile->OpenAsync(FileAccessMode::Read)).then([sampleFile](IRandomAccessStream^ stream)
        {
            // Process stream
        });
    });
    ```
    
    ```vb
    Dim stream = Await sampleFile.OpenAsync(Windows.Storage.FileAccessMode.Read)
    ```

2.  後で使うためにストリームのサイズを取得します。

    ```csharp
    ulong size = stream.Size;
    ```
    
    ```cppwinrt
    uint64_t size{ stream.Size() };
    // The code in step 3 goes here.
    ```
    
    ```cpp
    // Add to "Process stream" from part 1
    UINT64 size = stream->Size;
    ```
    
    ```vb
    Dim size = stream.Size
    ```

3.  呼び出すことで、入力ストリームを取得、 [ **IRandomAccessStream.GetInputStreamAt** ](/uwp/api/windows.storage.streams.irandomaccessstream.getinputstreamat)メソッド。 これを **using** ステートメントに入れて、ストリームの有効期間を管理します。 **GetInputStreamAt** を呼び出すときに 0 を指定して、位置をストリームの先頭に設定します。

    ```csharp
    using (var inputStream = stream.GetInputStreamAt(0))
    {
        // We'll add more code here in the next step.
    }
    ```
    
    ```cppwinrt
    Windows::Storage::Streams::IInputStream inputStream{ stream.GetInputStreamAt(0) };
    Windows::Storage::Streams::DataReader dataReader{ inputStream };
    // The code in step 4 goes here.
    ```
    
    ```cpp
    // Add after code from part 2
    IInputStream^ inputStream = stream->GetInputStreamAt(0);
    auto dataReader = ref new DataReader(inputStream);
    ```
    
    ```vb
    Using inputStream = stream.GetInputStreamAt(0)
    ' We'll add more code here in the next step.
    End Using
    ```

4.  最後に、このコードを既存の **using** ステートメントに追加してストリーム上の [**DataReader**](/uwp/api/windows.storage.streams.datareader) オブジェクトを取得し、[**DataReader.LoadAsync**](/uwp/api/windows.storage.streams.datareader.loadasync) と [**DataReader.ReadString**](/uwp/api/windows.storage.streams.datareader.readstring) を呼び出してテキストを読み取ります。

    ```csharp
    using (var dataReader = new Windows.Storage.Streams.DataReader(inputStream))
    {
        uint numBytesLoaded = await dataReader.LoadAsync((uint)size);
        string text = dataReader.ReadString(numBytesLoaded);
    }
    ```
    
    ```cppwinrt
    unsigned int cBytesLoaded{ co_await dataReader.LoadAsync(size) };
    winrt::hstring streamText{ dataReader.ReadString(cBytesLoaded) };
    ```
    
    ```cpp
    // Add after code from part 3
    create_task(dataReader->LoadAsync(size)).then([sampleFile, dataReader](unsigned int numBytesLoaded)
    {
        String^ streamText = dataReader->ReadString(numBytesLoaded);
    });
    ```
    
    ```vb
    Dim dataReader As New DataReader(inputStream)
    Dim numBytesLoaded As UInteger = Await dataReader.LoadAsync(CUInt(size))
    Dim text As String = dataReader.ReadString(numBytesLoaded)
    ```

## <a name="see-also"></a>関連項目

- [ファイルに書き込むためのベスト プラクティス](best-practices-for-writing-to-files.md)
