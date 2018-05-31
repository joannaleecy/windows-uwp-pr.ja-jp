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
# <a name="create-write-and-read-a-file"></a><span data-ttu-id="6b513-104">ファイルの作成、書き込み、および読み取り</span><span class="sxs-lookup"><span data-stu-id="6b513-104">Create, write, and read a file</span></span>




**<span data-ttu-id="6b513-105">重要な API</span><span class="sxs-lookup"><span data-stu-id="6b513-105">Important APIs</span></span>**

-   [**<span data-ttu-id="6b513-106">StorageFolder クラス</span><span class="sxs-lookup"><span data-stu-id="6b513-106">StorageFolder class</span></span>**](https://msdn.microsoft.com/library/windows/apps/br227230)
-   [**<span data-ttu-id="6b513-107">StorageFile クラス</span><span class="sxs-lookup"><span data-stu-id="6b513-107">StorageFile class</span></span>**](https://msdn.microsoft.com/library/windows/apps/br227171)
-   [**<span data-ttu-id="6b513-108">FileIO クラス</span><span class="sxs-lookup"><span data-stu-id="6b513-108">FileIO class</span></span>**](https://msdn.microsoft.com/library/windows/apps/hh701440)

<span data-ttu-id="6b513-109">[**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) オブジェクトを使ってファイルの読み取りと書き込みを行います。</span><span class="sxs-lookup"><span data-stu-id="6b513-109">Read and write a file using a [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) object.</span></span>

> [!NOTE]
> <span data-ttu-id="6b513-110">「[File access sample](http://go.microsoft.com/fwlink/p/?linkid=619995)」(ファイル アクセスのサンプル) もご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6b513-110">Also see the [File access sample](http://go.microsoft.com/fwlink/p/?linkid=619995).</span></span>

## <a name="prerequisites"></a><span data-ttu-id="6b513-111">前提条件</span><span class="sxs-lookup"><span data-stu-id="6b513-111">Prerequisites</span></span>

-   **<span data-ttu-id="6b513-112">ユニバーサル Windows プラットフォーム (UWP) アプリの非同期プログラミングについての理解</span><span class="sxs-lookup"><span data-stu-id="6b513-112">Understand async programming for Universal Windows Platform (UWP) apps</span></span>**

    <span data-ttu-id="6b513-113">C# や Visual Basic での非同期アプリの作成方法については、「[C# または Visual Basic での非同期 API の呼び出し](https://msdn.microsoft.com/library/windows/apps/mt187337)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6b513-113">You can learn how to write asynchronous apps in C# or Visual Basic, see [Call asynchronous APIs in C# or Visual Basic](https://msdn.microsoft.com/library/windows/apps/mt187337).</span></span> <span data-ttu-id="6b513-114">C++ での非同期アプリの作成方法については、「[C++ での非同期プログラミング](https://msdn.microsoft.com/library/windows/apps/mt187334)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6b513-114">To learn how to write asynchronous apps in C++, see [Asynchronous programming in C++](https://msdn.microsoft.com/library/windows/apps/mt187334).</span></span>

-   **<span data-ttu-id="6b513-115">読み取り、書き込み、またはその両方の対象となるファイルを取得する方法についての知識</span><span class="sxs-lookup"><span data-stu-id="6b513-115">Know how to get the file that you want to read from, write to, or both</span></span>**

    <span data-ttu-id="6b513-116">ファイル ピッカーを使ってファイルを取得する方法については、「[ピッカーでファイルやフォルダーを開く](quickstart-using-file-and-folder-pickers.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6b513-116">You can learn how to get a file by using a file picker in [Open files and folders with a picker](quickstart-using-file-and-folder-pickers.md).</span></span>

## <a name="creating-a-file"></a><span data-ttu-id="6b513-117">ファイルの作成</span><span class="sxs-lookup"><span data-stu-id="6b513-117">Creating a file</span></span>

<span data-ttu-id="6b513-118">アプリのローカル フォルダーにファイルを作成する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="6b513-118">Here's how to create a file in the app's local folder.</span></span> <span data-ttu-id="6b513-119">既に存在する場合は置き換えます。</span><span class="sxs-lookup"><span data-stu-id="6b513-119">If it already exists, we replace it.</span></span>

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

## <a name="writing-to-a-file"></a><span data-ttu-id="6b513-120">ファイルへの書き込み</span><span class="sxs-lookup"><span data-stu-id="6b513-120">Writing to a file</span></span>

<span data-ttu-id="6b513-121">[**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) クラスを使ってディスク上の書き込み可能ファイルに書き込む方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="6b513-121">Here's how to write to a writable file on disk using the [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) class.</span></span> <span data-ttu-id="6b513-122">いずれの方法でファイルに書き込む場合でも (ファイルの作成直後に書き込むのでない限り)、まずは [**StorageFolder.GetFileAsync**](https://msdn.microsoft.com/library/windows/apps/br227272) でファイルを取得します。</span><span class="sxs-lookup"><span data-stu-id="6b513-122">The common first step for each of the ways of writing to a file (unless you're writing to the file immediately after creating it) is to get the file with [**StorageFolder.GetFileAsync**](https://msdn.microsoft.com/library/windows/apps/br227272).</span></span>

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

**<span data-ttu-id="6b513-123">ファイルへのテキストの書き込み</span><span class="sxs-lookup"><span data-stu-id="6b513-123">Writing text to a file</span></span>**

<span data-ttu-id="6b513-124">[**FileIO**](https://msdn.microsoft.com/library/windows/apps/hh701440) クラスの [**WriteTextAsync**](https://msdn.microsoft.com/library/windows/apps/hh701505) メソッドを呼び出してファイルにテキストを書き込みます。</span><span class="sxs-lookup"><span data-stu-id="6b513-124">Write text to your file by calling the [**WriteTextAsync**](https://msdn.microsoft.com/library/windows/apps/hh701505) method of the [**FileIO**](https://msdn.microsoft.com/library/windows/apps/hh701440) class.</span></span>

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

**<span data-ttu-id="6b513-125">バッファーを使ったファイルへのバイトの書き込み (2 ステップ)</span><span class="sxs-lookup"><span data-stu-id="6b513-125">Writing bytes to a file by using a buffer (2 steps)</span></span>**

1.  <span data-ttu-id="6b513-126">まず、[**ConvertStringToBinary**](https://msdn.microsoft.com/library/windows/apps/br241385) を呼び出してファイルに書き込む任意の文字列に基づくバイトのバッファーを取得します。</span><span class="sxs-lookup"><span data-stu-id="6b513-126">First, call [**ConvertStringToBinary**](https://msdn.microsoft.com/library/windows/apps/br241385) to get a buffer of the bytes (based on an arbitrary string) that you want to write to your file.</span></span>

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

2.  <span data-ttu-id="6b513-127">次に、[**FileIO**](https://msdn.microsoft.com/library/windows/apps/hh701440) クラスの [**WriteBufferAsync**](https://msdn.microsoft.com/library/windows/apps/hh701490) メソッドを呼び出してファイルにバッファーからのバイトを書き込みます。</span><span class="sxs-lookup"><span data-stu-id="6b513-127">Then write the bytes from your buffer to your file by calling the [**WriteBufferAsync**](https://msdn.microsoft.com/library/windows/apps/hh701490) method of the [**FileIO**](https://msdn.microsoft.com/library/windows/apps/hh701440) class.</span></span>

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

**<span data-ttu-id="6b513-128">ストリームを使ったファイルへのテキストの書き込み (4 ステップ)</span><span class="sxs-lookup"><span data-stu-id="6b513-128">Writing text to a file by using a stream (4 steps)</span></span>**

1.  <span data-ttu-id="6b513-129">まず、[**StorageFile.OpenAsync**](https://msdn.microsoft.com/library/windows/apps/dn889851) メソッドを呼び出してファイルを開きます。</span><span class="sxs-lookup"><span data-stu-id="6b513-129">First, open the file by calling the [**StorageFile.OpenAsync**](https://msdn.microsoft.com/library/windows/apps/dn889851) method.</span></span> <span data-ttu-id="6b513-130">このメソッドは、オープン操作が完了したときにファイルのコンテンツのストリームを返します。</span><span class="sxs-lookup"><span data-stu-id="6b513-130">It returns a stream of the file's content when the open operation completes.</span></span>

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

2.  <span data-ttu-id="6b513-131">次に、`stream` の [**GetOutputStreamAt**](https://msdn.microsoft.com/library/windows/apps/br241738) メソッドを呼び出して出力ストリームを取得します。</span><span class="sxs-lookup"><span data-stu-id="6b513-131">Next, get an output stream by calling the [**GetOutputStreamAt**](https://msdn.microsoft.com/library/windows/apps/br241738) method from the `stream`.</span></span> <span data-ttu-id="6b513-132">これを **using** ステートメントに入れて、出力ストリームの有効期間を管理します。</span><span class="sxs-lookup"><span data-stu-id="6b513-132">Put this in a **using** statement to manage the output stream's lifetime.</span></span>

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

3.  <span data-ttu-id="6b513-133">さらに、新しい [**DataWriter**](https://msdn.microsoft.com/library/windows/apps/br208154) オブジェクトを作って [**DataWriter.WriteString**](https://msdn.microsoft.com/library/windows/apps/br241642) メソッドを呼び出し、既存の **using** ステートメントにこのコードを追加して出力ストリームに書き込みます。</span><span class="sxs-lookup"><span data-stu-id="6b513-133">Now add this code within the existing **using** statement to write to the output stream by creating a new [**DataWriter**](https://msdn.microsoft.com/library/windows/apps/br208154) object and calling the [**DataWriter.WriteString**](https://msdn.microsoft.com/library/windows/apps/br241642) method.</span></span>

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

4.  <span data-ttu-id="6b513-134">最後に、(内部 **using** ステートメント内の) このコードを追加し、[**StoreAsync**](https://msdn.microsoft.com/library/windows/apps/br208171) でファイルにテキストを保存して、[**FlushAsync**](https://msdn.microsoft.com/library/windows/apps/br241729) でストリームを閉じます。</span><span class="sxs-lookup"><span data-stu-id="6b513-134">Lastly, add this code (within the inner **using** statement) to save the text to your file with [**StoreAsync**](https://msdn.microsoft.com/library/windows/apps/br208171) and close the stream with [**FlushAsync**](https://msdn.microsoft.com/library/windows/apps/br241729).</span></span>

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

## <a name="reading-from-a-file"></a><span data-ttu-id="6b513-135">ファイルからの読み取り</span><span class="sxs-lookup"><span data-stu-id="6b513-135">Reading from a file</span></span>

<span data-ttu-id="6b513-136">[**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) クラスを使ってディスク上のファイルから読み取る方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="6b513-136">Here's how to read from a file on disk using the [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) class.</span></span> <span data-ttu-id="6b513-137">いずれの方法でファイルから読み取る場合でも、まずは [**StorageFolder.GetFileAsync**](https://msdn.microsoft.com/library/windows/apps/br227272) を使ってファイルを取得します。</span><span class="sxs-lookup"><span data-stu-id="6b513-137">The common first step for each of the ways of reading from a file is to get the file with [**StorageFolder.GetFileAsync**](https://msdn.microsoft.com/library/windows/apps/br227272).</span></span>

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

**<span data-ttu-id="6b513-138">ファイルからのテキストの読み取り</span><span class="sxs-lookup"><span data-stu-id="6b513-138">Reading text from a file</span></span>**

<span data-ttu-id="6b513-139">[**FileIO**](https://msdn.microsoft.com/library/windows/apps/hh701440) クラスの [**ReadTextAsync**](https://msdn.microsoft.com/library/windows/apps/hh701482) メソッドを呼び出してファイルのテキストを読み取ります。</span><span class="sxs-lookup"><span data-stu-id="6b513-139">Read text from your file by calling the [**ReadTextAsync**](https://msdn.microsoft.com/library/windows/apps/hh701482) method of the [**FileIO**](https://msdn.microsoft.com/library/windows/apps/hh701440) class.</span></span>

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

**<span data-ttu-id="6b513-140">バッファーを使ったファイルからのテキストの読み取り (2 ステップ)</span><span class="sxs-lookup"><span data-stu-id="6b513-140">Reading text from a file by using a buffer (2 steps)</span></span>**

1.  <span data-ttu-id="6b513-141">まず[**FileIO**](https://msdn.microsoft.com/library/windows/apps/hh701440) クラスの [**ReadBufferAsync**](https://msdn.microsoft.com/library/windows/apps/hh701468) メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="6b513-141">First, call the [**ReadBufferAsync**](https://msdn.microsoft.com/library/windows/apps/hh701468) method of the [**FileIO**](https://msdn.microsoft.com/library/windows/apps/hh701440) class.</span></span>

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

2.  <span data-ttu-id="6b513-142">次に、[**DataReader**](https://msdn.microsoft.com/library/windows/apps/br208119) オブジェクトを使ってバッファーの長さを読み取り、次にバッファーのコンテンツを読み取ります。</span><span class="sxs-lookup"><span data-stu-id="6b513-142">Then use a [**DataReader**](https://msdn.microsoft.com/library/windows/apps/br208119) object to read first the length of the buffer and then its contents.</span></span>

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

**<span data-ttu-id="6b513-143">ストリームを使ったファイルからのテキストの読み取り (4 ステップ)</span><span class="sxs-lookup"><span data-stu-id="6b513-143">Reading text from a file by using a stream (4 steps)</span></span>**

1.  <span data-ttu-id="6b513-144">[**StorageFile.OpenAsync**](https://msdn.microsoft.com/library/windows/apps/dn889851) メソッドを呼び出してファイルに対するストリームを開きます。</span><span class="sxs-lookup"><span data-stu-id="6b513-144">Open a stream for your file by calling the [**StorageFile.OpenAsync**](https://msdn.microsoft.com/library/windows/apps/dn889851) method.</span></span> <span data-ttu-id="6b513-145">このメソッドは、操作が完了したときにファイルのコンテンツのストリームを返します。</span><span class="sxs-lookup"><span data-stu-id="6b513-145">It returns a stream of the file's content when the operation completes.</span></span>

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

2.  <span data-ttu-id="6b513-146">後で使うためにストリームのサイズを取得します。</span><span class="sxs-lookup"><span data-stu-id="6b513-146">Get the size of the stream to use later.</span></span>

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

3.  <span data-ttu-id="6b513-147">[**GetInputStreamAt**](https://msdn.microsoft.com/library/windows/apps/br241737) メソッドを呼び出して入力ストリームを取得します。</span><span class="sxs-lookup"><span data-stu-id="6b513-147">Get an input stream by calling the [**GetInputStreamAt**](https://msdn.microsoft.com/library/windows/apps/br241737) method.</span></span> <span data-ttu-id="6b513-148">これを **using** ステートメントに入れて、ストリームの有効期間を管理します。</span><span class="sxs-lookup"><span data-stu-id="6b513-148">Put this in a **using** statement to manage the stream's lifetime.</span></span> <span data-ttu-id="6b513-149">**GetInputStreamAt** を呼び出すときに 0 を指定して、位置をストリームの先頭に設定します。</span><span class="sxs-lookup"><span data-stu-id="6b513-149">Specify 0 when you call **GetInputStreamAt** to set the position to the beginning of the stream.</span></span>

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

4.  <span data-ttu-id="6b513-150">最後に、このコードを既存の **using** ステートメントに追加してストリーム上の [**DataReader**](https://msdn.microsoft.com/library/windows/apps/br208119) オブジェクトを取得し、[**DataReader.LoadAsync**](https://msdn.microsoft.com/library/windows/apps/br208135) と [**DataReader.ReadString**](https://msdn.microsoft.com/library/windows/apps/br208147) を呼び出してテキストを読み取ります。</span><span class="sxs-lookup"><span data-stu-id="6b513-150">Lastly, add this code within the existing **using** statement to get a [**DataReader**](https://msdn.microsoft.com/library/windows/apps/br208119) object on the stream then read the text by calling [**DataReader.LoadAsync**](https://msdn.microsoft.com/library/windows/apps/br208135) and [**DataReader.ReadString**](https://msdn.microsoft.com/library/windows/apps/br208147).</span></span>

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
