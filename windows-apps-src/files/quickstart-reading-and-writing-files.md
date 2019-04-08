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
# <a name="create-write-and-read-a-file"></a><span data-ttu-id="651e7-104">ファイルの作成、書き込み、および読み取り</span><span class="sxs-lookup"><span data-stu-id="651e7-104">Create, write, and read a file</span></span>

<span data-ttu-id="651e7-105">**重要な API**</span><span class="sxs-lookup"><span data-stu-id="651e7-105">**Important APIs**</span></span>

-   [<span data-ttu-id="651e7-106">**StorageFolder クラス**</span><span class="sxs-lookup"><span data-stu-id="651e7-106">**StorageFolder class**</span></span>](/uwp/api/windows.storage.storagefolder)
-   [<span data-ttu-id="651e7-107">**StorageFile クラス**</span><span class="sxs-lookup"><span data-stu-id="651e7-107">**StorageFile class**</span></span>](/uwp/api/windows.storage.storagefile)
-   [<span data-ttu-id="651e7-108">**FileIO クラス**</span><span class="sxs-lookup"><span data-stu-id="651e7-108">**FileIO class**</span></span>](/uwp/api/windows.storage.fileio)

<span data-ttu-id="651e7-109">[  **StorageFile**](/uwp/api/windows.storage.storagefile) オブジェクトを使ってファイルの読み取りと書き込みを行います。</span><span class="sxs-lookup"><span data-stu-id="651e7-109">Read and write a file using a [**StorageFile**](/uwp/api/windows.storage.storagefile) object.</span></span>

> [!NOTE]
><span data-ttu-id="651e7-110"> 完全なサンプルを参照してください、[ファイル アクセス サンプル](https://go.microsoft.com/fwlink/p/?linkid=619995)します。</span><span class="sxs-lookup"><span data-stu-id="651e7-110"> For a complete sample, see the [File access sample](https://go.microsoft.com/fwlink/p/?linkid=619995).</span></span>

## <a name="prerequisites"></a><span data-ttu-id="651e7-111">前提条件</span><span class="sxs-lookup"><span data-stu-id="651e7-111">Prerequisites</span></span>

-   <span data-ttu-id="651e7-112">**ユニバーサル Windows プラットフォーム (UWP) アプリの非同期プログラミングを理解します。**</span><span class="sxs-lookup"><span data-stu-id="651e7-112">**Understand async programming for Universal Windows Platform (UWP) apps**</span></span>

    <span data-ttu-id="651e7-113">C# や Visual Basic での非同期アプリの作成方法については、「[C# または Visual Basic での非同期 API の呼び出し](/windows/uwp/threading-async/call-asynchronous-apis-in-csharp-or-visual-basic)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="651e7-113">You can learn how to write asynchronous apps in C# or Visual Basic, see [Call asynchronous APIs in C# or Visual Basic](/windows/uwp/threading-async/call-asynchronous-apis-in-csharp-or-visual-basic).</span></span> <span data-ttu-id="651e7-114">C + で非同期アプリを作成する方法について/cli WinRT を参照してください[同時実行と非同期操作を C +/cli WinRT](/windows/uwp/cpp-and-winrt-apis/concurrency)します。</span><span class="sxs-lookup"><span data-stu-id="651e7-114">To learn how to write asynchronous apps in C++/WinRT, see [Concurrency and asynchronous operations with C++/WinRT](/windows/uwp/cpp-and-winrt-apis/concurrency).</span></span> <span data-ttu-id="651e7-115">C + で非同期アプリを作成する方法について/cli CX を参照してください[非同期プログラミングの C +/cli CX](/windows/uwp/threading-async/asynchronous-programming-in-cpp-universal-windows-platform-apps)します。</span><span class="sxs-lookup"><span data-stu-id="651e7-115">To learn how to write asynchronous apps in C++/CX, see [Asynchronous programming in C++/CX](/windows/uwp/threading-async/asynchronous-programming-in-cpp-universal-windows-platform-apps).</span></span>

-   <span data-ttu-id="651e7-116">**読み取り、書き込み、ファイルを取得する方法、またはその両方を知っています。**</span><span class="sxs-lookup"><span data-stu-id="651e7-116">**Know how to get the file that you want to read from, write to, or both**</span></span>

    <span data-ttu-id="651e7-117">ファイル ピッカーを使ってファイルを取得する方法については、「[ピッカーでファイルやフォルダーを開く](quickstart-using-file-and-folder-pickers.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="651e7-117">You can learn how to get a file by using a file picker in [Open files and folders with a picker](quickstart-using-file-and-folder-pickers.md).</span></span>

## <a name="creating-a-file"></a><span data-ttu-id="651e7-118">ファイルの作成</span><span class="sxs-lookup"><span data-stu-id="651e7-118">Creating a file</span></span>

<span data-ttu-id="651e7-119">アプリのローカル フォルダーにファイルを作成する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="651e7-119">Here's how to create a file in the app's local folder.</span></span> <span data-ttu-id="651e7-120">既に存在する場合は置き換えます。</span><span class="sxs-lookup"><span data-stu-id="651e7-120">If it already exists, we replace it.</span></span>

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

## <a name="writing-to-a-file"></a><span data-ttu-id="651e7-121">ファイルへの書き込み</span><span class="sxs-lookup"><span data-stu-id="651e7-121">Writing to a file</span></span>

<span data-ttu-id="651e7-122">[  **StorageFile**](/uwp/api/windows.storage.storagefile) クラスを使ってディスク上の書き込み可能ファイルに書き込む方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="651e7-122">Here's how to write to a writable file on disk using the [**StorageFile**](/uwp/api/windows.storage.storagefile) class.</span></span> <span data-ttu-id="651e7-123">いずれの方法でファイルに書き込む場合でも (ファイルの作成直後に書き込むのでない限り)、まずは [**StorageFolder.GetFileAsync**](/uwp/api/windows.storage.storagefolder.getfileasync) でファイルを取得します。</span><span class="sxs-lookup"><span data-stu-id="651e7-123">The common first step for each of the ways of writing to a file (unless you're writing to the file immediately after creating it) is to get the file with [**StorageFolder.GetFileAsync**](/uwp/api/windows.storage.storagefolder.getfileasync).</span></span>

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

<span data-ttu-id="651e7-124">**テキスト ファイルへの書き込み**</span><span class="sxs-lookup"><span data-stu-id="651e7-124">**Writing text to a file**</span></span>

<span data-ttu-id="651e7-125">テキストを呼び出すことによって、ファイルを書き込む、 [ **FileIO.WriteTextAsync** ](/uwp/api/windows.storage.fileio.writetextasync)メソッド。</span><span class="sxs-lookup"><span data-stu-id="651e7-125">Write text to your file by calling the [**FileIO.WriteTextAsync**](/uwp/api/windows.storage.fileio.writetextasync) method.</span></span>

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

<span data-ttu-id="651e7-126">**バッファー (2 つの手順) を使用して、ファイルにバイトを書き込む**</span><span class="sxs-lookup"><span data-stu-id="651e7-126">**Writing bytes to a file by using a buffer (2 steps)**</span></span>

1.  <span data-ttu-id="651e7-127">最初に、呼び出す[ **CryptographicBuffer.ConvertStringToBinary** ](/uwp/api/windows.security.cryptography.cryptographicbuffer.convertstringtobinary) (文字列に基づく) バイトのバッファーを取得する、ファイルへの書き込みにします。</span><span class="sxs-lookup"><span data-stu-id="651e7-127">First, call [**CryptographicBuffer.ConvertStringToBinary**](/uwp/api/windows.security.cryptography.cryptographicbuffer.convertstringtobinary) to get a buffer of the bytes (based on a string) that you want to write to your file.</span></span>

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

2.  <span data-ttu-id="651e7-128">呼び出すことによっては、バッファーから、ファイルのバイト数を記述し、 [ **FileIO.WriteBufferAsync** ](/uwp/api/windows.storage.fileio.writebufferasync)メソッド。</span><span class="sxs-lookup"><span data-stu-id="651e7-128">Then write the bytes from your buffer to your file by calling the [**FileIO.WriteBufferAsync**](/uwp/api/windows.storage.fileio.writebufferasync) method.</span></span>

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

<span data-ttu-id="651e7-129">**ストリーム (4 つの手順) を使用してテキスト ファイルへの書き込み**</span><span class="sxs-lookup"><span data-stu-id="651e7-129">**Writing text to a file by using a stream (4 steps)**</span></span>

1.  <span data-ttu-id="651e7-130">まず、[**StorageFile.OpenAsync**](/uwp/api/windows.storage.storagefile.openasync) メソッドを呼び出してファイルを開きます。</span><span class="sxs-lookup"><span data-stu-id="651e7-130">First, open the file by calling the [**StorageFile.OpenAsync**](/uwp/api/windows.storage.storagefile.openasync) method.</span></span> <span data-ttu-id="651e7-131">このメソッドは、オープン操作が完了したときにファイルのコンテンツのストリームを返します。</span><span class="sxs-lookup"><span data-stu-id="651e7-131">It returns a stream of the file's content when the open operation completes.</span></span>

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

2.  <span data-ttu-id="651e7-132">次に、呼び出すことによって、出力ストリームを取得、 [ **IRandomAccessStream.GetOutputStreamAt** ](/uwp/api/windows.storage.streams.irandomaccessstream.getoutputstreamat)からメソッド、`stream`します。</span><span class="sxs-lookup"><span data-stu-id="651e7-132">Next, get an output stream by calling the [**IRandomAccessStream.GetOutputStreamAt**](/uwp/api/windows.storage.streams.irandomaccessstream.getoutputstreamat) method from the `stream`.</span></span> <span data-ttu-id="651e7-133">使用している場合C#でこれを囲む、**を使用して**ステートメントを出力ストリームの有効期間を管理します。</span><span class="sxs-lookup"><span data-stu-id="651e7-133">If you're using C#, then enclose this in a **using** statement to manage the output stream's lifetime.</span></span> <span data-ttu-id="651e7-134">使用している場合[C +/cli WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)、ブロックでそれを囲むまたはに設定すると、その有効期間を制御できるよう`nullptr`を終了するとき。</span><span class="sxs-lookup"><span data-stu-id="651e7-134">If you're using [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt), then you can control its lifetime by enclosing it in a block, or setting it to `nullptr` when you're done with it.</span></span>

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

3.  <span data-ttu-id="651e7-135">このコードを追加するようになりました (を使用する場合C#、既存**を使用して**ステートメント) を出力ストリームに書き込む新しい[ **datawriter の各**](/uwp/api/windows.storage.streams.datawriter)オブジェクトと呼び出し、[ **DataWriter.WriteString** ](/uwp/api/windows.storage.streams.datawriter.writestring)メソッド。</span><span class="sxs-lookup"><span data-stu-id="651e7-135">Now add this code (if you're using C#, within the existing **using** statement) to write to the output stream by creating a new [**DataWriter**](/uwp/api/windows.storage.streams.datawriter) object and calling the [**DataWriter.WriteString**](/uwp/api/windows.storage.streams.datawriter.writestring) method.</span></span>

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

4.  <span data-ttu-id="651e7-136">最後に、次のコードを追加 (を使用する場合C#、内部内**を使用して**ステートメント) を使用して、ファイルのテキストを保存する[ **DataWriter.StoreAsync** ](/uwp/api/windows.storage.streams.datawriter.storeasync) 、ストリームを閉じると[ **IOutputStream.FlushAsync**](/uwp/api/windows.storage.streams.ioutputstream.flushasync)します。</span><span class="sxs-lookup"><span data-stu-id="651e7-136">Lastly, add this code (if you're using C#, within the inner **using** statement) to save the text to your file with [**DataWriter.StoreAsync**](/uwp/api/windows.storage.streams.datawriter.storeasync) and close the stream with [**IOutputStream.FlushAsync**](/uwp/api/windows.storage.streams.ioutputstream.flushasync).</span></span>

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

<span data-ttu-id="651e7-137">**ファイルに書き込むためのベスト プラクティス**</span><span class="sxs-lookup"><span data-stu-id="651e7-137">**Best practices for writing to a file**</span></span>

<span data-ttu-id="651e7-138">追加の詳細とベスト プラクティス ガイダンスでは、次を参照してください。[ファイルに書き込むためのベスト プラクティス](best-practices-for-writing-to-files.md)します。</span><span class="sxs-lookup"><span data-stu-id="651e7-138">For additional details and best practice guidance, see [Best practices for writing to files](best-practices-for-writing-to-files.md).</span></span>
    
## <a name="reading-from-a-file"></a><span data-ttu-id="651e7-139">ファイルからの読み取り</span><span class="sxs-lookup"><span data-stu-id="651e7-139">Reading from a file</span></span>

<span data-ttu-id="651e7-140">[  **StorageFile**](/uwp/api/Windows.Storage.StorageFile) クラスを使ってディスク上のファイルから読み取る方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="651e7-140">Here's how to read from a file on disk using the [**StorageFile**](/uwp/api/Windows.Storage.StorageFile) class.</span></span> <span data-ttu-id="651e7-141">いずれの方法でファイルから読み取る場合でも、まずは [**StorageFolder.GetFileAsync**](/uwp/api/windows.storage.storagefolder.getfileasync) を使ってファイルを取得します。</span><span class="sxs-lookup"><span data-stu-id="651e7-141">The common first step for each of the ways of reading from a file is to get the file with [**StorageFolder.GetFileAsync**](/uwp/api/windows.storage.storagefolder.getfileasync).</span></span>

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

<span data-ttu-id="651e7-142">**ファイルからテキストを読み取る**</span><span class="sxs-lookup"><span data-stu-id="651e7-142">**Reading text from a file**</span></span>

<span data-ttu-id="651e7-143">呼び出すことによって、ファイルからテキストを読み取る、 [ **FileIO.ReadTextAsync** ](/uwp/api/windows.storage.fileio.readtextasync)メソッド。</span><span class="sxs-lookup"><span data-stu-id="651e7-143">Read text from your file by calling the [**FileIO.ReadTextAsync**](/uwp/api/windows.storage.fileio.readtextasync) method.</span></span>

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

<span data-ttu-id="651e7-144">**バッファー (2 つの手順) を使用して、ファイルからテキストを読み取る**</span><span class="sxs-lookup"><span data-stu-id="651e7-144">**Reading text from a file by using a buffer (2 steps)**</span></span>

1.  <span data-ttu-id="651e7-145">最初に、呼び出し、 [ **FileIO.ReadBufferAsync** ](/uwp/api/windows.storage.fileio.readbufferasync)メソッド。</span><span class="sxs-lookup"><span data-stu-id="651e7-145">First, call the [**FileIO.ReadBufferAsync**](/uwp/api/windows.storage.fileio.readbufferasync) method.</span></span>

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

2.  <span data-ttu-id="651e7-146">次に、[**DataReader**](/uwp/api/windows.storage.streams.datareader) オブジェクトを使ってバッファーの長さを読み取り、次にバッファーのコンテンツを読み取ります。</span><span class="sxs-lookup"><span data-stu-id="651e7-146">Then use a [**DataReader**](/uwp/api/windows.storage.streams.datareader) object to read first the length of the buffer and then its contents.</span></span>

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

<span data-ttu-id="651e7-147">**テキスト ストリーム (4 つの手順) を使用してファイルからの読み取り**</span><span class="sxs-lookup"><span data-stu-id="651e7-147">**Reading text from a file by using a stream (4 steps)**</span></span>

1.  <span data-ttu-id="651e7-148">[  **StorageFile.OpenAsync**](/uwp/api/windows.storage.storagefile.openasync) メソッドを呼び出してファイルに対するストリームを開きます。</span><span class="sxs-lookup"><span data-stu-id="651e7-148">Open a stream for your file by calling the [**StorageFile.OpenAsync**](/uwp/api/windows.storage.storagefile.openasync) method.</span></span> <span data-ttu-id="651e7-149">このメソッドは、操作が完了したときにファイルのコンテンツのストリームを返します。</span><span class="sxs-lookup"><span data-stu-id="651e7-149">It returns a stream of the file's content when the operation completes.</span></span>

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

2.  <span data-ttu-id="651e7-150">後で使うためにストリームのサイズを取得します。</span><span class="sxs-lookup"><span data-stu-id="651e7-150">Get the size of the stream to use later.</span></span>

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

3.  <span data-ttu-id="651e7-151">呼び出すことで、入力ストリームを取得、 [ **IRandomAccessStream.GetInputStreamAt** ](/uwp/api/windows.storage.streams.irandomaccessstream.getinputstreamat)メソッド。</span><span class="sxs-lookup"><span data-stu-id="651e7-151">Get an input stream by calling the [**IRandomAccessStream.GetInputStreamAt**](/uwp/api/windows.storage.streams.irandomaccessstream.getinputstreamat) method.</span></span> <span data-ttu-id="651e7-152">これを **using** ステートメントに入れて、ストリームの有効期間を管理します。</span><span class="sxs-lookup"><span data-stu-id="651e7-152">Put this in a **using** statement to manage the stream's lifetime.</span></span> <span data-ttu-id="651e7-153">**GetInputStreamAt** を呼び出すときに 0 を指定して、位置をストリームの先頭に設定します。</span><span class="sxs-lookup"><span data-stu-id="651e7-153">Specify 0 when you call **GetInputStreamAt** to set the position to the beginning of the stream.</span></span>

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

4.  <span data-ttu-id="651e7-154">最後に、このコードを既存の **using** ステートメントに追加してストリーム上の [**DataReader**](/uwp/api/windows.storage.streams.datareader) オブジェクトを取得し、[**DataReader.LoadAsync**](/uwp/api/windows.storage.streams.datareader.loadasync) と [**DataReader.ReadString**](/uwp/api/windows.storage.streams.datareader.readstring) を呼び出してテキストを読み取ります。</span><span class="sxs-lookup"><span data-stu-id="651e7-154">Lastly, add this code within the existing **using** statement to get a [**DataReader**](/uwp/api/windows.storage.streams.datareader) object on the stream then read the text by calling [**DataReader.LoadAsync**](/uwp/api/windows.storage.streams.datareader.loadasync) and [**DataReader.ReadString**](/uwp/api/windows.storage.streams.datareader.readstring).</span></span>

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

## <a name="see-also"></a><span data-ttu-id="651e7-155">関連項目</span><span class="sxs-lookup"><span data-stu-id="651e7-155">See also</span></span>

- [<span data-ttu-id="651e7-156">ファイルへの書き込みに関するベスト プラクティス</span><span class="sxs-lookup"><span data-stu-id="651e7-156">Best practices for writing to files</span></span>](best-practices-for-writing-to-files.md)
