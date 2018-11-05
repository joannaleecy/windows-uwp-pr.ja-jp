---
author: laurenhughes
title: UWP でファイルのプロパティにすばやくアクセスする
description: UWP アプリで使用するために、ライブラリからファイルとそのプロパティの一覧を効率的に収集します。
ms.author: lahugh
ms.date: 03/22/2018
ms.topic: article
keywords: Windows 10, UWP, ファイル, プロパティ
ms.localizationpriority: medium
ms.openlocfilehash: e2f63e848820361a64a2a96348a8e1cc2419f233
ms.sourcegitcommit: e814a13978f33654d8e995584f4b047cb53e0aef
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/05/2018
ms.locfileid: "6035348"
---
# <a name="fast-access-to-file-properties-in-uwp"></a><span data-ttu-id="1fa0e-104">UWP でファイルのプロパティにすばやくアクセスする</span><span class="sxs-lookup"><span data-stu-id="1fa0e-104">Fast access to file properties in UWP</span></span> 

<span data-ttu-id="1fa0e-105">ライブラリからファイルとそのプロパティの一覧をすばやく収集し、アプリでそれらのプロパティを使用する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="1fa0e-105">Learn how to quickly gather a list of files and their properties from a library and use those properties in an app.</span></span>  

<span data-ttu-id="1fa0e-106">前提条件</span><span class="sxs-lookup"><span data-stu-id="1fa0e-106">Prerequisites</span></span> 
- <span data-ttu-id="1fa0e-107">**ユニバーサル Windows プラットフォーム (UWP) アプリの非同期プログラミング** c# または Visual Basic での非同期アプリの作成を[c# または Visual Basic での非同期 Api の呼び出し](https://docs.microsoft.com/windows/uwp/threading-async/call-asynchronous-apis-in-csharp-or-visual-basic)を確認方法を学びます。    </span><span class="sxs-lookup"><span data-stu-id="1fa0e-107">**Asynchronous programming for Universal Windows Platform (UWP) apps**     You can learn how to write asynchronous apps in C# or Visual Basic, see [Call asynchronous APIs in C# or Visual Basic](https://docs.microsoft.com/windows/uwp/threading-async/call-asynchronous-apis-in-csharp-or-visual-basic).</span></span> <span data-ttu-id="1fa0e-108">C++ での非同期アプリの作成方法については、「[C++ での非同期プログラミング](https://docs.microsoft.com/windows/uwp/threading-async/asynchronous-programming-in-cpp-universal-windows-platform-apps)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1fa0e-108">To learn how to write asynchronous apps in C++, see [Asynchronous programming in C++](https://docs.microsoft.com/windows/uwp/threading-async/asynchronous-programming-in-cpp-universal-windows-platform-apps).</span></span> 
- <span data-ttu-id="1fa0e-109">**ライブラリへのアクセス許可**これらの例のコードで、 **picturesLibrary**機能が必要ですが、ファイルの場所がまったく必要としない別の機能では、機能がないです。</span><span class="sxs-lookup"><span data-stu-id="1fa0e-109">**Access permissions to Libraries**  The code in these examples requires the **picturesLibrary** capability, but your file location may require a different capability, or no capability at all.</span></span> <span data-ttu-id="1fa0e-110">詳しくは、「[ファイル アクセス許可](https://docs.microsoft.com/windows/uwp/files/file-access-permissions)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1fa0e-110">To learn more, see [File access permissions](https://docs.microsoft.com/windows/uwp/files/file-access-permissions).</span></span> 
- <span data-ttu-id="1fa0e-111">**単純なファイルの列挙**この例では、 [QueryOptions](https://docs.microsoft.com/uwp/api/Windows.Storage.Search.QueryOptions)を使用して、いくつかの高度な列挙プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="1fa0e-111">**Simple file enumeration**  This example uses [QueryOptions](https://docs.microsoft.com/uwp/api/Windows.Storage.Search.QueryOptions) to set a few advanced enumeration properties.</span></span> <span data-ttu-id="1fa0e-112">小さいディレクトリを対象としてファイルの簡単な一覧を取得する方法について詳しくは、「[ファイルとフォルダーの列挙と照会](https://docs.microsoft.com/windows/uwp/files/quickstart-listing-files-and-folders)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1fa0e-112">To learn more about just getting a simple list of files for a smaller directory, see [Enumerate and query files and folders](https://docs.microsoft.com/windows/uwp/files/quickstart-listing-files-and-folders).</span></span> 

## <a name="usage"></a><span data-ttu-id="1fa0e-113">使用方法</span><span class="sxs-lookup"><span data-stu-id="1fa0e-113">Usage</span></span>  
<span data-ttu-id="1fa0e-114">多くのアプリでは、ファイルのグループのプロパティを一覧表示する必要がありますが、常にファイルと直接やり取りする必要はありません。</span><span class="sxs-lookup"><span data-stu-id="1fa0e-114">Many apps need to list the properties of a group of files, but don't always need to interact with the files directly.</span></span> <span data-ttu-id="1fa0e-115">たとえば、音楽アプリは一度に 1 つのファイルを再生します (開きます) が、アプリで曲のキューを表示したり、ユーザーが再生可能なファイルを選択したりする場合には、フォルダー内にあるすべてのファイルのプロパティが必要になります。</span><span class="sxs-lookup"><span data-stu-id="1fa0e-115">For example, a music app plays (opens) one file at a time, but it needs the properties of all of the files in a folder so the app can show the song queue, or so the user can choose a valid file to play.</span></span> 

<span data-ttu-id="1fa0e-116">このページで紹介する例は、すべてのファイルのメタデータを変更するアプリや、プロパティを読み取ることができない場合に、生成されるすべての StorageFiles とやり取りするアプリには使用しないでください。</span><span class="sxs-lookup"><span data-stu-id="1fa0e-116">The examples on this page shouldn't be used in apps that will modify the metadata of every file or apps that interact with all the resulting StorageFiles beyond reading their properties.</span></span> <span data-ttu-id="1fa0e-117">詳しくは、「[ファイルとフォルダーの列挙と照会](https://docs.microsoft.com/windows/uwp/files/quickstart-listing-files-and-folders)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1fa0e-117">See [Enumerate and query files and folders](https://docs.microsoft.com/windows/uwp/files/quickstart-listing-files-and-folders) for more information.</span></span> 

## <a name="enumerate-all-the-pictures-in-a-location"></a><span data-ttu-id="1fa0e-118">ある場所に保存されているすべての画像を列挙する</span><span class="sxs-lookup"><span data-stu-id="1fa0e-118">Enumerate all the pictures in a location</span></span> 
<span data-ttu-id="1fa0e-119">この例では、以下を行います。</span><span class="sxs-lookup"><span data-stu-id="1fa0e-119">In this example, we will</span></span>
-  <span data-ttu-id="1fa0e-120">[QueryOptions](https://docs.microsoft.com/uwp/api/Windows.Storage.Search.QueryOptions) オブジェクトを作成して、アプリではできるだけ早くファイルを列挙する必要があることを指定します。</span><span class="sxs-lookup"><span data-stu-id="1fa0e-120">Build a [QueryOptions](https://docs.microsoft.com/uwp/api/Windows.Storage.Search.QueryOptions) object to specify that the app wants to enumerate the files as quickly as possible.</span></span>
-  <span data-ttu-id="1fa0e-121">StorageFile オブジェクトをアプリにページングすることにより、ファイル プロパティをフェッチします。</span><span class="sxs-lookup"><span data-stu-id="1fa0e-121">Fetch file properties by paging StorageFile objects into the app.</span></span> <span data-ttu-id="1fa0e-122">ファイルをページングすることで、アプリによるメモリの使用量を削減し、認識可能な応答性を向上させることができます。</span><span class="sxs-lookup"><span data-stu-id="1fa0e-122">Paging the files in reduces the memory used by the app and improves its perceived responsiveness.</span></span>

### <a name="creating-the-query"></a><span data-ttu-id="1fa0e-123">クエリの作成</span><span class="sxs-lookup"><span data-stu-id="1fa0e-123">Creating the query</span></span> 
<span data-ttu-id="1fa0e-124">クエリを作成するには、QueryOptions オブジェクトを使用して、アプリでは特定の種類の画像ファイルだけを列挙する必要があることを指定し、Windows 情報保護 (System.Security.EncryptionOwners) によって保護されているファイルを除外します。</span><span class="sxs-lookup"><span data-stu-id="1fa0e-124">To build the query, we use a QueryOptions object to specify that the app is interested in enumerating only certain types of images files and to filter out files protected with Windows Information Protection (System.Security.EncryptionOwners).</span></span> 

<span data-ttu-id="1fa0e-125">[QueryOptions.SetPropertyPrefetch](https://docs.microsoft.com/uwp/api/windows.storage.search.queryoptions.setpropertyprefetch) を使用して、アプリがアクセサリするプロパティを設定することが重要です。</span><span class="sxs-lookup"><span data-stu-id="1fa0e-125">It is important to set the properties the app is going to access using [QueryOptions.SetPropertyPrefetch](https://docs.microsoft.com/uwp/api/windows.storage.search.queryoptions.setpropertyprefetch).</span></span> <span data-ttu-id="1fa0e-126">アプリがプリフェッチされていないプロパティにアクセスすると、重大なパフォーマンス ペナルティが発生します。</span><span class="sxs-lookup"><span data-stu-id="1fa0e-126">If the app accesses a property that isn’t prefetched, it will incur a significant performance penalty.</span></span>

<span data-ttu-id="1fa0e-127">[IndexerOption.OnlyUseIndexerAndOptimzeForIndexedProperties](https://docs.microsoft.com/uwp/api/Windows.Storage.Search.IndexerOption) を設定して、結果をできるだけ早く返すこと、および [SetPropertyPrefetch](https://docs.microsoft.com/uwp/api/windows.storage.search.queryoptions.setpropertyprefetch) で指定したプロパティのみを含めることをシステムに通知します。</span><span class="sxs-lookup"><span data-stu-id="1fa0e-127">Setting [IndexerOption.OnlyUseIndexerAndOptimzeForIndexedProperties](https://docs.microsoft.com/uwp/api/Windows.Storage.Search.IndexerOption) tells the system to return results as quickly as possible, but to only include the properties specified in [SetPropertyPrefetch](https://docs.microsoft.com/uwp/api/windows.storage.search.queryoptions.setpropertyprefetch).</span></span> 

### <a name="paging-in-the-results"></a><span data-ttu-id="1fa0e-128">ページングして結果を生成する</span><span class="sxs-lookup"><span data-stu-id="1fa0e-128">Paging in the results</span></span> 
<span data-ttu-id="1fa0e-129">画像ライブラリには数十万または数百万のファイルが保存されている場合があり、[GetFilesAsync](https://docs.microsoft.com/uwp/api/windows.storage.search.storagefilequeryresult.getfilesasync) を呼び出すことによって、コンピューターに過剰な負荷がかかる可能性があります。これは、画像ごとに StorageFile が作成されるためです。</span><span class="sxs-lookup"><span data-stu-id="1fa0e-129">Users may have thousands or millions of files in their pictures library, so calling [GetFilesAsync](https://docs.microsoft.com/uwp/api/windows.storage.search.storagefilequeryresult.getfilesasync) would overwhelm their machine because it creates a StorageFile for each image.</span></span> <span data-ttu-id="1fa0e-130">これを解決するには、一度に一定数の StorageFiles を作成し、それらを処理して UI を作成してから、メモリを解放します。</span><span class="sxs-lookup"><span data-stu-id="1fa0e-130">This can be solved by creating a fixed number of StorageFiles at one time, processing them into the UI, and then releasing the memory.</span></span> 

<span data-ttu-id="1fa0e-131">この例では、[StorageFileQueryResult.GetFilesAsync(UInt32 StartIndex, UInt32 maxNumberOfItems)](https://docs.microsoft.com/uwp/api/windows.storage.search.storagefilequeryresult.getfilesasync) を使用して、一度に 100 個のファイルのみをフェッチして、こうした問題に対処しています。</span><span class="sxs-lookup"><span data-stu-id="1fa0e-131">In our example, we do this by using [StorageFileQueryResult.GetFilesAsync(UInt32 StartIndex, UInt32 maxNumberOfItems)](https://docs.microsoft.com/uwp/api/windows.storage.search.storagefilequeryresult.getfilesasync) to only fetch 100 files at a time.</span></span> <span data-ttu-id="1fa0e-132">この処理の次にアプリでファイルが処理され、その後で OS がメモリーを解放できるようにしています。</span><span class="sxs-lookup"><span data-stu-id="1fa0e-132">The app will then process the files and allow the OS to release that memory afterwards.</span></span> <span data-ttu-id="1fa0e-133">この方法では、アプリの最大メモリが制限され、システムは応答性を維持します。</span><span class="sxs-lookup"><span data-stu-id="1fa0e-133">This technique caps the maximum memory of the app and ensures the system stays responsive.</span></span> <span data-ttu-id="1fa0e-134">もちろん、実施するシナリオで返されるファイルの数は調整する必要がありますが、すべてのユーザーに対して応答性の高いエクスペリエンスを確保するために、一度にフェッチするファイルの数は 500 未満にすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="1fa0e-134">Of course, you will need to adjust the number of files returned for your scenario, but to ensure a responsive experience for all users, it's recommended to not fetch more than 500 files at one time.</span></span>


**<span data-ttu-id="1fa0e-135">例</span><span class="sxs-lookup"><span data-stu-id="1fa0e-135">Example</span></span>**  
```csharp
StorageFolder folderToEnumerate = KnownFolders.PicturesLibrary; 
// Check if the folder is indexed before doing anything. 
IndexedState folderIndexedState = await folderToEnumerate.GetIndexedStateAsync(); 
if (folderIndexedState == IndexedState.NotIndexed || folderIndexedState == IndexedState.Unknown) 
{ 
    // Only possible in indexed directories.  
    return; 
} 
 
QueryOptions picturesQuery = new QueryOptions() 
{ 
    FolderDepth = FolderDepth.Deep, 
    // Filter out all files that have WIP enabled
    ApplicationSearchFilter = "System.Security.EncryptionOwners:[]", 
    IndexerOption = IndexerOption.OnlyUseIndexerAndOptimizeForIndexedProperties 
}; 

picturesQuery.FileTypeFilter.Add(".jpg"); 
string[] otherProperties = new string[] 
{ 
    SystemProperties.GPS.LatitudeDecimal, 
    SystemProperties.GPS.LongitudeDecimal 
}; 
 
picturesQuery.SetPropertyPrefetch(PropertyPrefetchOptions.BasicProperties | PropertyPrefetchOptions.ImageProperties, 
                                    otherProperties); 
SortEntry sortOrder = new SortEntry() 
{ 
    AscendingOrder = true, 
    PropertyName = "System.FileName" // FileName property is used as an example. Any property can be used here.  
}; 
picturesQuery.SortOrder.Add(sortOrder); 
 
// Create the query and get the results 
uint index = 0; 
const uint stepSize = 100; 
if (!folderToEnumerate.AreQueryOptionsSupported(picturesQuery)) 
{ 
    log("Querying for a sort order is not supported in this location"); 
    picturesQuery.SortOrder.Clear(); 
} 
StorageFileQueryResult queryResult = folderToEnumerate.CreateFileQueryWithOptions(picturesQuery); 
IReadOnlyList<StorageFile> images = await queryResult.GetFilesAsync(index, stepSize); 
while (images.Count != 0 || index < 10000) 
{ 
    foreach (StorageFile file in images) 
    { 
        // With the OnlyUseIndexerAndOptimizeForIndexedProperties set, this won't  
        // be async. It will run synchronously. 
        var imageProps = await file.Properties.GetImagePropertiesAsync(); 
 
        // Build the UI 
        log(String.Format("{0} at {1}, {2}", 
                    file.Path, 
                    imageProps.Latitude, 
                    imageProps.Longitude)); 
    } 
    index += stepSize; 
    images = await queryResult.GetFilesAsync(index, stepSize); 
} 
```

### <a name="results"></a><span data-ttu-id="1fa0e-136">結果</span><span class="sxs-lookup"><span data-stu-id="1fa0e-136">Results</span></span> 
<span data-ttu-id="1fa0e-137">結果として生成される StorageFile ファイルには要求したプロパティのみが含まれますが、他の IndexerOptions と比較して、10 倍速く結果が返されます。</span><span class="sxs-lookup"><span data-stu-id="1fa0e-137">The resulting StorageFile files only contain the properties requested, but are returned 10 times faster compared to the other IndexerOptions.</span></span><span data-ttu-id="1fa0e-138">アプリでは、クエリにまだ含まれていないプロパティへのアクセスを要求できますが、ファイルを開き、それらのプロパティを取得するとパフォーマンス ペナルティが発生します。</span><span class="sxs-lookup"><span data-stu-id="1fa0e-138">The app can still request access to properties not already included in the query, but there is a performance penalty to open the file and retrieve those properties.</span></span>  

## <a name="adding-folders-to-libraries"></a><span data-ttu-id="1fa0e-139">フォルダーをライブラリに追加する</span><span class="sxs-lookup"><span data-stu-id="1fa0e-139">Adding folders to Libraries</span></span> 
<span data-ttu-id="1fa0e-140">アプリでは、[StorageLibrary.RequestAddFolderAsync](https://docs.microsoft.com/uwp/api/Windows.Storage.StorageLibrary.RequestAddFolderAsync) を使用して、ファイルの場所をインデックスに追加するよう、ユーザーに対して要求することができます。</span><span class="sxs-lookup"><span data-stu-id="1fa0e-140">Apps can request the user to add the location to the index using [StorageLibrary.RequestAddFolderAsync](https://docs.microsoft.com/uwp/api/Windows.Storage.StorageLibrary.RequestAddFolderAsync).</span></span> <span data-ttu-id="1fa0e-141">場所が追加されると、自動的にインデックスが作成されます。アプリはこの方法を使用してファイルを列挙することができます。</span><span class="sxs-lookup"><span data-stu-id="1fa0e-141">Once the location is included, it will be automatically indexed and apps can use this technique to enumerate the files.</span></span>
 
## <a name="see-also"></a><span data-ttu-id="1fa0e-142">関連項目</span><span class="sxs-lookup"><span data-stu-id="1fa0e-142">See also</span></span>
[<span data-ttu-id="1fa0e-143">QueryOptions API リファレンス</span><span class="sxs-lookup"><span data-stu-id="1fa0e-143">QueryOptions API Reference</span></span>](https://docs.microsoft.com/uwp/api/windows.storage.search.queryoptions)  
[<span data-ttu-id="1fa0e-144">ファイルとフォルダーの列挙と照会</span><span class="sxs-lookup"><span data-stu-id="1fa0e-144">Enumerate and query files and folders</span></span>](https://docs.microsoft.com/windows/uwp/files/quickstart-listing-files-and-folders)  
[<span data-ttu-id="1fa0e-145">ファイル アクセス許可</span><span class="sxs-lookup"><span data-stu-id="1fa0e-145">File access permissions</span></span>](https://docs.microsoft.com/windows/uwp/files/file-access-permissions)  
[<span data-ttu-id="1fa0e-146">プロパティにすばやくアクセスするためのチュートリアル</span><span class="sxs-lookup"><span data-stu-id="1fa0e-146">Fast Property Access Walkthrough</span></span>](https://blogs.msdn.microsoft.com/adamdwilson/2017/12/20/fast-file-enumeration-with-partially-initialized-storagefiles/)
 
 
