---
author: laurenhughes
ms.assetid: 27914C0A-2A02-473F-BDD5-C931E3943AA0
title: ファイルの作成、書き込み、および読み取り
description: StorageFile オブジェクトを使ってファイルの読み取りと書き込みを行います。
ms.author: lahugh
ms.date: 07/05/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: d99a37ce6d49889439998f8ad8217ae4360500e5
ms.sourcegitcommit: 0ab8f6fac53a6811f977ddc24de039c46c9db0ad
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/15/2018
ms.locfileid: "1653951"
---
# <a name="create-write-and-read-a-file"></a>ファイルの作成、書き込み、および読み取り




**重要な API**

-   [**StorageFolder クラス**](https://msdn.microsoft.com/library/windows/apps/br227230)
-   [**StorageFile クラス**](https://msdn.microsoft.com/library/windows/apps/br227171)
-   [**FileIO クラス**](https://msdn.microsoft.com/library/windows/apps/hh701440)

[**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) オブジェクトを使ってファイルの読み取りと書き込みを行います。

> [!NOTE]
> 「[File access sample](http://go.microsoft.com/fwlink/p/?linkid=619995)」(ファイル アクセスのサンプル) もご覧ください。

## <a name="prerequisites"></a>前提条件

-   **ユニバーサル Windows プラットフォーム (UWP) アプリの非同期プログラミングについての理解**

    C# や Visual Basic での非同期アプリの作成方法については、「[C# または Visual Basic での非同期 API の呼び出し](https://msdn.microsoft.com/library/windows/apps/mt187337)」をご覧ください。 C++ での非同期アプリの作成方法については、「[C++ での非同期プログラミング](https://msdn.microsoft.com/library/windows/apps/mt187334)」をご覧ください。

-   **読み取り、書き込み、またはその両方の対象となるファイルを取得する方法についての知識**

    ファイル ピッカーを使ってファイルを取得する方法については、「[ピッカーでファイルやフォルダーを開く](quickstart-using-file-and-folder-pickers.md)」をご覧ください。

## <a name="creating-a-file"></a>ファイルの作成

アプリのローカル フォルダーにファイルを作成する方法について説明します。 既に存在する場合は置き換えます。

> [!div class="tabbedCodeSnippets"]
```cs  
// Create sample file; replace if exists.
Windows.Storage.StorageFolder storageFolder =
    Windows.Storage.ApplicationData.Current.LocalFolder;
Windows.Storage.StorageFile sampleFile =
    await storageFolder.CreateFileAsync("sample.txt",
        Windows.Storage.CreationCollisionOption.ReplaceExisting);
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

[**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) クラスを使ってディスク上の書き込み可能ファイルに書き込む方法について説明します。 いずれの方法でファイルに書き込む場合でも (ファイルの作成直後に書き込むのでない限り)、まずは [**StorageFolder.GetFileAsync**](https://msdn.microsoft.com/library/windows/apps/br227272) でファイルを取得します。

> [!div class="tabbedCodeSnippets"]
```cs  
Windows.Storage.StorageFolder storageFolder =
    Windows.Storage.ApplicationData.Current.LocalFolder;
Windows.Storage.StorageFile sampleFile =
    await storageFolder.GetFileAsync("sample.txt");
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

**ファイルへのテキストの書き込み**

[**FileIO**](https://msdn.microsoft.com/library/windows/apps/hh701440) クラスの [**WriteTextAsync**](https://msdn.microsoft.com/library/windows/apps/hh701505) メソッドを呼び出してファイルにテキストを書き込みます。

> [!div class="tabbedCodeSnippets"]
```cs  
await Windows.Storage.FileIO.WriteTextAsync(sampleFile, "Swift as a shadow");
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

**バッファーを使ったファイルへのバイトの書き込み (2 ステップ)**

1.  まず、[**ConvertStringToBinary**](https://msdn.microsoft.com/library/windows/apps/br241385) を呼び出してファイルに書き込む任意の文字列に基づくバイトのバッファーを取得します。

    > [!div class="tabbedCodeSnippets"]
    ```cs  
    var buffer = Windows.Security.Cryptography.CryptographicBuffer.ConvertStringToBinary(
            "What fools these mortals be", Windows.Security.Cryptography.BinaryStringEncoding.Utf8);
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

2.  次に、[**FileIO**](https://msdn.microsoft.com/library/windows/apps/hh701440) クラスの [**WriteBufferAsync**](https://msdn.microsoft.com/library/windows/apps/hh701490) メソッドを呼び出してファイルにバッファーからのバイトを書き込みます。

    > [!div class="tabbedCodeSnippets"]
    ```cs  
    await Windows.Storage.FileIO.WriteBufferAsync(sampleFile, buffer);
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

**ストリームを使ったファイルへのテキストの書き込み (4 ステップ)**

1.  まず、[**StorageFile.OpenAsync**](https://msdn.microsoft.com/library/windows/apps/dn889851) メソッドを呼び出してファイルを開きます。 このメソッドは、オープン操作が完了したときにファイルのコンテンツのストリームを返します。

    > [!div class="tabbedCodeSnippets"]
    ```cs  
    var stream = await sampleFile.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite);
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

2.  次に、`stream` の [**GetOutputStreamAt**](https://msdn.microsoft.com/library/windows/apps/br241738) メソッドを呼び出して出力ストリームを取得します。 これを **using** ステートメントに入れて、出力ストリームの有効期間を管理します。

    > [!div class="tabbedCodeSnippets"]
    ```cs  
    using (var outputStream = stream.GetOutputStreamAt(0))
    {
        // We'll add more code here in the next step.
    }
    stream.Dispose(); // Or use the stream variable (see previous code snippet) with a using statement as well.
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

3.  さらに、新しい [**DataWriter**](https://msdn.microsoft.com/library/windows/apps/br208154) オブジェクトを作って [**DataWriter.WriteString**](https://msdn.microsoft.com/library/windows/apps/br241642) メソッドを呼び出し、既存の **using** ステートメントにこのコードを追加して出力ストリームに書き込みます。

    > [!div class="tabbedCodeSnippets"]
    ```cs  
    using (var dataWriter = new Windows.Storage.Streams.DataWriter(outputStream))
    {
        dataWriter.WriteString("DataWriter has methods to write to various types, such as DataTimeOffset.");
    }
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

4.  最後に、(内部 **using** ステートメント内の) このコードを追加し、[**StoreAsync**](https://msdn.microsoft.com/library/windows/apps/br208171) でファイルにテキストを保存して、[**FlushAsync**](https://msdn.microsoft.com/library/windows/apps/br241729) でストリームを閉じます。

    > [!div class="tabbedCodeSnippets"]
    ```cs  
    await dataWriter.StoreAsync();
        await outputStream.FlushAsync();
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

## <a name="reading-from-a-file"></a>ファイルからの読み取り

[**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) クラスを使ってディスク上のファイルから読み取る方法について説明します。 いずれの方法でファイルから読み取る場合でも、まずは [**StorageFolder.GetFileAsync**](https://msdn.microsoft.com/library/windows/apps/br227272) を使ってファイルを取得します。

> [!div class="tabbedCodeSnippets"]
```cs  
Windows.Storage.StorageFolder storageFolder =
    Windows.Storage.ApplicationData.Current.LocalFolder;
Windows.Storage.StorageFile sampleFile =
    await storageFolder.GetFileAsync("sample.txt");
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

**ファイルからのテキストの読み取り**

[**FileIO**](https://msdn.microsoft.com/library/windows/apps/hh701440) クラスの [**ReadTextAsync**](https://msdn.microsoft.com/library/windows/apps/hh701482) メソッドを呼び出してファイルのテキストを読み取ります。

> [!div class="tabbedCodeSnippets"]
```cs  
string text = await Windows.Storage.FileIO.ReadTextAsync(sampleFile);
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

**バッファーを使ったファイルからのテキストの読み取り (2 ステップ)**

1.  まず[**FileIO**](https://msdn.microsoft.com/library/windows/apps/hh701440) クラスの [**ReadBufferAsync**](https://msdn.microsoft.com/library/windows/apps/hh701468) メソッドを呼び出します。

    > [!div class="tabbedCodeSnippets"]
    ```cs  
    var buffer = await Windows.Storage.FileIO.ReadBufferAsync(sampleFile);
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

2.  次に、[**DataReader**](https://msdn.microsoft.com/library/windows/apps/br208119) オブジェクトを使ってバッファーの長さを読み取り、次にバッファーのコンテンツを読み取ります。

    > [!div class="tabbedCodeSnippets"]
    ```cs  
    using (var dataReader = Windows.Storage.Streams.DataReader.FromBuffer(buffer))
    {
        string text = dataReader.ReadString(buffer.Length);
    }
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

**ストリームを使ったファイルからのテキストの読み取り (4 ステップ)**

1.  [**StorageFile.OpenAsync**](https://msdn.microsoft.com/library/windows/apps/dn889851) メソッドを呼び出してファイルに対するストリームを開きます。 このメソッドは、操作が完了したときにファイルのコンテンツのストリームを返します。

    > [!div class="tabbedCodeSnippets"]
    ```cs  
    var stream = await sampleFile.OpenAsync(Windows.Storage.FileAccessMode.Read);
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

    > [!div class="tabbedCodeSnippets"]
    ```cs  
    ulong size = stream.Size;
    ```
    ```cpp  
    // Add to "Process stream" from part 1
    UINT64 size = stream->Size;
    ```
    ```vb  
    Dim size = stream.Size
    ```

3.  [**GetInputStreamAt**](https://msdn.microsoft.com/library/windows/apps/br241737) メソッドを呼び出して入力ストリームを取得します。 これを **using** ステートメントに入れて、ストリームの有効期間を管理します。 **GetInputStreamAt** を呼び出すときに 0 を指定して、位置をストリームの先頭に設定します。

    > [!div class="tabbedCodeSnippets"]
    ```cs  
    using (var inputStream = stream.GetInputStreamAt(0))
    {
        // We'll add more code here in the next step.
    }
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

4.  最後に、このコードを既存の **using** ステートメントに追加してストリーム上の [**DataReader**](https://msdn.microsoft.com/library/windows/apps/br208119) オブジェクトを取得し、[**DataReader.LoadAsync**](https://msdn.microsoft.com/library/windows/apps/br208135) と [**DataReader.ReadString**](https://msdn.microsoft.com/library/windows/apps/br208147) を呼び出してテキストを読み取ります。

    > [!div class="tabbedCodeSnippets"]
    ```cs  
    using (var dataReader = new Windows.Storage.Streams.DataReader(inputStream))
    {
        uint numBytesLoaded = await dataReader.LoadAsync((uint)size);
        string text = dataReader.ReadString(numBytesLoaded);
    }
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
