---
author: laurenhughes
title: "UWP でファイルのプロパティにすばやくアクセスする"
description: "UWP アプリで使用するために、ライブラリからファイルとそのプロパティの一覧を効率的に収集します。"
ms.author: lahugh
ms.date: 10/13/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, ファイル, プロパティ"
localizationpriority: medium
ms.openlocfilehash: 1376774b619a94940d12b0c33439b9ebfe2e4a61
ms.sourcegitcommit: 44a24b580feea0f188c7eae36e72e4a4f412802b
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/31/2017
---
# <a name="fast-access-to-file-properties-in-uwp"></a><span data-ttu-id="d090c-104">UWP でファイルのプロパティにすばやくアクセスする</span><span class="sxs-lookup"><span data-stu-id="d090c-104">Fast Access to file properties in UWP</span></span> 

<span data-ttu-id="d090c-105">ライブラリからファイルとそのプロパティの一覧をすばやく収集し、アプリでそれらのプロパティを使用する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="d090c-105">Learn how to quickly gather a list of files and their properties from a library and use those properties in an app.</span></span>  

<span data-ttu-id="d090c-106">前提条件</span><span class="sxs-lookup"><span data-stu-id="d090c-106">Prerequisites</span></span> 
- **<span data-ttu-id="d090c-107">ユニバーサル Windows プラットフォーム (UWP) アプリの非同期プログラミング</span><span class="sxs-lookup"><span data-stu-id="d090c-107">Asynchronous programming for Universal Windows Platform (UWP) apps</span></span>**     
<span data-ttu-id="d090c-108">C# や Visual Basic での非同期アプリの作成方法については、「[C# または Visual Basic での非同期 API の呼び出し](https://docs.microsoft.com/windows/uwp/threading-async/call-asynchronous-apis-in-csharp-or-visual-basic)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d090c-108">You can learn how to write asynchronous apps in C# or Visual Basic, see [Call asynchronous APIs in C# or Visual Basic](https://docs.microsoft.com/windows/uwp/threading-async/call-asynchronous-apis-in-csharp-or-visual-basic).</span></span> <span data-ttu-id="d090c-109">C++ での非同期アプリの作成方法については、「[C++ での非同期プログラミング](https://docs.microsoft.com/windows/uwp/threading-async/asynchronous-programming-in-cpp-universal-windows-platform-apps)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d090c-109">To learn how to write asynchronous apps in C++, see [Asynchronous programming in C++](https://docs.microsoft.com/windows/uwp/threading-async/asynchronous-programming-in-cpp-universal-windows-platform-apps).</span></span> 
- **<span data-ttu-id="d090c-110">ライブラリへのアクセス許可</span><span class="sxs-lookup"><span data-stu-id="d090c-110">Access permissions to Libraries</span></span>**  
<span data-ttu-id="d090c-111">これらの例のコードでは **picturesLibrary** 機能が必要ですが、ファイルの場所によっては別の機能が必要であったり、機能をまったく必要としない場合もあります。</span><span class="sxs-lookup"><span data-stu-id="d090c-111">The code in these examples requires the **picturesLibrary** capability, but your file location may require a different capability, or no capability at all.</span></span> <span data-ttu-id="d090c-112">詳しくは、「[ファイル アクセス許可](https://docs.microsoft.com/windows/uwp/files/file-access-permissions)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d090c-112">To learn more, see [File access permissions](https://docs.microsoft.com/windows/uwp/files/file-access-permissions).</span></span> 
- **<span data-ttu-id="d090c-113">簡単なファイルの列挙</span><span class="sxs-lookup"><span data-stu-id="d090c-113">Simple file enumeration</span></span>**   
<span data-ttu-id="d090c-114">この例では、[QueryOptions](https://docs.microsoft.com/uwp/api/Windows.Storage.Search.QueryOptions) を使用して、高度な列挙プロパティをいくつか設定します。</span><span class="sxs-lookup"><span data-stu-id="d090c-114">This example uses [QueryOptions](https://docs.microsoft.com/uwp/api/Windows.Storage.Search.QueryOptions) to set a few advanced enumeration properties.</span></span> <span data-ttu-id="d090c-115">小さいディレクトリを対象としてファイルの簡単な一覧を取得する方法について詳しくは、「[ファイルとフォルダーの列挙と照会](https://docs.microsoft.com/windows/uwp/files/quickstart-listing-files-and-folders)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d090c-115">To learn more about just getting a simple list of files for a smaller directory, see [Enumerate and query files and folders](https://docs.microsoft.com/windows/uwp/files/quickstart-listing-files-and-folders).</span></span> 

## <a name="usage"></a><span data-ttu-id="d090c-116">使用方法</span><span class="sxs-lookup"><span data-stu-id="d090c-116">Usage</span></span>  
<span data-ttu-id="d090c-117">多くのアプリでは、ファイルのグループのプロパティを一覧表示する必要がありますが、常にファイルと直接やり取りする必要はありません。</span><span class="sxs-lookup"><span data-stu-id="d090c-117">Many apps need to list the properties of a group of files, but don't always need to interact with the files directly.</span></span> <span data-ttu-id="d090c-118">たとえば、音楽アプリは一度に 1 つのファイルを再生します (開きます) が、アプリで曲のキューを表示したり、ユーザーが再生可能なファイルを選択したりする場合には、フォルダー内にあるすべてのファイルのプロパティが必要になります。</span><span class="sxs-lookup"><span data-stu-id="d090c-118">For example, a music app plays (opens) one file at a time, but it needs the properties of all of the files in a folder so the app can show the song queue, or so the user can choose a valid file to play.</span></span> 

<span data-ttu-id="d090c-119">このページで紹介する例は、すべてのファイルのメタデータを変更するアプリや、プロパティを読み取ることができない場合に、生成されるすべての StorageFiles とやり取りするアプリには使用しないでください。</span><span class="sxs-lookup"><span data-stu-id="d090c-119">The examples on this page shouldn't be used in apps that will modify the metadata of every file or apps that interact with all the resulting StorageFiles beyond reading their properties.</span></span> <span data-ttu-id="d090c-120">詳しくは、「[ファイルとフォルダーの列挙と照会](https://docs.microsoft.com/windows/uwp/files/quickstart-listing-files-and-folders)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d090c-120">See [Enumerate and query files and folders](https://docs.microsoft.com/windows/uwp/files/quickstart-listing-files-and-folders) for more information.</span></span> 

## <a name="enumerate-all-the-pictures-in-a-location"></a><span data-ttu-id="d090c-121">ある場所に保存されているすべての画像を列挙する</span><span class="sxs-lookup"><span data-stu-id="d090c-121">Enumerate all the pictures in a location</span></span> 
<span data-ttu-id="d090c-122">この例では、以下を行います。</span><span class="sxs-lookup"><span data-stu-id="d090c-122">In this example, we will</span></span>
-  <span data-ttu-id="d090c-123">[QueryOptions](https://docs.microsoft.com/uwp/api/Windows.Storage.Search.QueryOptions) オブジェクトを作成して、アプリではできるだけ早くファイルを列挙する必要があることを指定します。</span><span class="sxs-lookup"><span data-stu-id="d090c-123">Build a [QueryOptions](https://docs.microsoft.com/uwp/api/Windows.Storage.Search.QueryOptions) object to specify that the app wants to enumerate the files as quickly as possible.</span></span>
-  <span data-ttu-id="d090c-124">StorageFile オブジェクトをアプリにページングすることにより、ファイル プロパティをフェッチします。</span><span class="sxs-lookup"><span data-stu-id="d090c-124">Fetch file properties by paging StorageFile objects into the app.</span></span> <span data-ttu-id="d090c-125">ファイルをページングすることで、アプリによるメモリの使用量を削減し、認識可能な応答性を向上させることができます。</span><span class="sxs-lookup"><span data-stu-id="d090c-125">Paging the files in reduces the memory used by the app and improves its perceived responsiveness.</span></span>

### <a name="creating-the-query"></a><span data-ttu-id="d090c-126">クエリの作成</span><span class="sxs-lookup"><span data-stu-id="d090c-126">Creating the query</span></span> 
<span data-ttu-id="d090c-127">クエリを作成するには、QueryOptions オブジェクトを使用して、アプリでは特定の種類の画像ファイルだけを列挙する必要があることを指定し、Windows 情報保護 (System.Security.EncryptionOwners) によって保護されているファイルを除外します。</span><span class="sxs-lookup"><span data-stu-id="d090c-127">To build the query, we use a QueryOptions object to specify that the app is interested in enumerating only certain types of images files and to filter out files protected with Windows Information Protection (System.Security.EncryptionOwners).</span></span> 

<span data-ttu-id="d090c-128">[QueryOptions.SetPropertyPrefetch](https://docs.microsoft.com/uwp/api/Windows.Storage.Search.QueryOptions#Windows_Storage_Search_QueryOptions_SetPropertyPrefetch_Windows_Storage_FileProperties_PropertyPrefetchOptions_Windows_Foundation_Collections_IIterable_System_String__) を使用して、アプリがアクセサリするプロパティを設定することが重要です。</span><span class="sxs-lookup"><span data-stu-id="d090c-128">It is important to set the properties the app is going to access using [QueryOptions.SetPropertyPrefetch](https://docs.microsoft.com/uwp/api/Windows.Storage.Search.QueryOptions#Windows_Storage_Search_QueryOptions_SetPropertyPrefetch_Windows_Storage_FileProperties_PropertyPrefetchOptions_Windows_Foundation_Collections_IIterable_System_String__).</span></span> <span data-ttu-id="d090c-129">アプリがプリフェッチされていないプロパティにアクセスすると、重大なパフォーマンス ペナルティが発生します。</span><span class="sxs-lookup"><span data-stu-id="d090c-129">If the app accesses a property that isn’t prefetched, it will incur a significant performance penalty.</span></span>

<span data-ttu-id="d090c-130">[IndexerOption.OnlyUseIndexerAndOptimzeForIndexedProperties](https://docs.microsoft.com/uwp/api/Windows.Storage.Search.IndexerOption) を設定して、結果をできるだけ早く返すこと、および [SetPropertyPrefetch](https://docs.microsoft.com/uwp/api/Windows.Storage.Search.QueryOptions#Windows_Storage_Search_QueryOptions_SetPropertyPrefetch_Windows_Storage_FileProperties_PropertyPrefetchOptions_Windows_Foundation_Collections_IIterable_System_String__) で指定したプロパティのみを含めることをシステムに通知します。</span><span class="sxs-lookup"><span data-stu-id="d090c-130">Setting [IndexerOption.OnlyUseIndexerAndOptimzeForIndexedProperties](https://docs.microsoft.com/uwp/api/Windows.Storage.Search.IndexerOption) tells the system to return results as quickly as possible, but to only include the properties specified in [SetPropertyPrefetch](https://docs.microsoft.com/uwp/api/Windows.Storage.Search.QueryOptions#Windows_Storage_Search_QueryOptions_SetPropertyPrefetch_Windows_Storage_FileProperties_PropertyPrefetchOptions_Windows_Foundation_Collections_IIterable_System_String__).</span></span> 

### <a name="paging-in-the-results"></a><span data-ttu-id="d090c-131">ページングして結果を生成する</span><span class="sxs-lookup"><span data-stu-id="d090c-131">Paging in the results</span></span> 
<span data-ttu-id="d090c-132">画像ライブラリには数十万または数百万のファイルが保存されている場合があり、[GetFilesAsync](https://docs.microsoft.com/uwp/api/windows.storage.search.storagefilequeryresult#Windows_Storage_Search_StorageFileQueryResult_GetFilesAsync_System_UInt32_System_UInt32_) を呼び出すことによって、コンピューターに過剰な負荷がかかる可能性があります。これは、画像ごとに StorageFile が作成されるためです。</span><span class="sxs-lookup"><span data-stu-id="d090c-132">Users may have thousands or millions of files in their pictures library, so calling [GetFilesAsync](https://docs.microsoft.com/uwp/api/windows.storage.search.storagefilequeryresult#Windows_Storage_Search_StorageFileQueryResult_GetFilesAsync_System_UInt32_System_UInt32_) would overwhelm their machine because it creates a StorageFile for each image.</span></span> <span data-ttu-id="d090c-133">これを解決するには、一度に一定数の StorageFiles を作成し、それらを処理して UI を作成してから、メモリを解放します。</span><span class="sxs-lookup"><span data-stu-id="d090c-133">This can be solved by creating a fixed number of StorageFiles at one time, processing them into the UI, and then releasing the memory.</span></span> 

<span data-ttu-id="d090c-134">この例では、[StorageFileQueryResult.GetFilesAsync(UInt32 StartIndex, UInt32 maxNumberOfItems)](https://docs.microsoft.com/uwp/api/windows.storage.search.storagefilequeryresult#Windows_Storage_Search_StorageFileQueryResult_GetFilesAsync_System_UInt32_System_UInt32_) を使用して、一度に 100 個のファイルのみをフェッチして、こうした問題に対処しています。</span><span class="sxs-lookup"><span data-stu-id="d090c-134">In our example, we do this by using [StorageFileQueryResult.GetFilesAsync(UInt32 StartIndex, UInt32 maxNumberOfItems)](https://docs.microsoft.com/uwp/api/windows.storage.search.storagefilequeryresult#Windows_Storage_Search_StorageFileQueryResult_GetFilesAsync_System_UInt32_System_UInt32_) to only fetch 100 files at a time.</span></span> <span data-ttu-id="d090c-135">この処理の次にアプリでファイルが処理され、その後で OS がメモリーを解放できるようにしています。</span><span class="sxs-lookup"><span data-stu-id="d090c-135">The app will then process the files and allow the OS to release that memory afterwards.</span></span> <span data-ttu-id="d090c-136">この方法では、アプリの最大メモリが制限され、システムは応答性を維持します。</span><span class="sxs-lookup"><span data-stu-id="d090c-136">This technique caps the maximum memory of the app and ensures the system stays responsive.</span></span> <span data-ttu-id="d090c-137">もちろん、実施するシナリオで返されるファイルの数は調整する必要がありますが、すべてのユーザーに対して応答性の高いエクスペリエンスを確保するために、一度にフェッチするファイルの数は 500 未満にすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="d090c-137">Of course, you will need to adjust the number of files returned for your scenario, but to ensure a responsive experience for all users, it's recommended to not fetch more than 500 files at one time.</span></span>


<span data-ttu-id="d090c-138">C# のサンプル</span><span class="sxs-lookup"><span data-stu-id="d090c-138">C# Sample</span></span>  
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

### <a name="results"></a><span data-ttu-id="d090c-139">結果</span><span class="sxs-lookup"><span data-stu-id="d090c-139">Results</span></span> 
<span data-ttu-id="d090c-140">結果として生成される StorageFile ファイルには要求したプロパティのみが含まれますが、他の IndexerOptions と比較して、10 倍速く結果が返されます。</span><span class="sxs-lookup"><span data-stu-id="d090c-140">The resulting StorageFile files only contain the properties requested, but are returned 10 times faster compared to the other IndexerOptions.</span></span> <span data-ttu-id="d090c-141">アプリでは、クエリにまだ含まれていないプロパティへのアクセスを要求できますが、ファイルを開き、それらのプロパティを取得するとパフォーマンス ペナルティが発生します。</span><span class="sxs-lookup"><span data-stu-id="d090c-141">The app can still request access to properties not already included in the query, but there is a performance penalty to open the file and retrieve those properties.</span></span>  

## <a name="adding-folders-to-libraries"></a><span data-ttu-id="d090c-142">フォルダーをライブラリに追加する</span><span class="sxs-lookup"><span data-stu-id="d090c-142">Adding folders to Libraries</span></span> 
<span data-ttu-id="d090c-143">アプリでは、[StorageLibrary.RequestAddFolderAsync](https://docs.microsoft.com/uwp/api/Windows.Storage.StorageLibrary#Windows_Storage_StorageLibrary_RequestAddFolderAsync) を使用して、ファイルの場所をインデックスに追加するよう、ユーザーに対して要求することができます。</span><span class="sxs-lookup"><span data-stu-id="d090c-143">Apps can request the user to add the location to the index using [StorageLibrary.RequestAddFolderAsync](https://docs.microsoft.com/uwp/api/Windows.Storage.StorageLibrary#Windows_Storage_StorageLibrary_RequestAddFolderAsync).</span></span> <span data-ttu-id="d090c-144">場所が追加されると、自動的にインデックスが作成されます。アプリはこの方法を使用してファイルを列挙することができます。</span><span class="sxs-lookup"><span data-stu-id="d090c-144">Once the location is included, it will be automatically indexed and apps can use this technique to enumerate the files.</span></span>
 
## <a name="see-also"></a><span data-ttu-id="d090c-145">関連項目</span><span class="sxs-lookup"><span data-stu-id="d090c-145">See also</span></span>
[<span data-ttu-id="d090c-146">QueryOptions API リファレンス</span><span class="sxs-lookup"><span data-stu-id="d090c-146">QueryOptions API Reference</span></span>](https://docs.microsoft.com/uwp/api/windows.storage.search.queryoptions)  
[<span data-ttu-id="d090c-147">ファイルとフォルダーの列挙と照会</span><span class="sxs-lookup"><span data-stu-id="d090c-147">Enumerate and query files and folders</span></span>](https://docs.microsoft.com/windows/uwp/files/quickstart-listing-files-and-folders)  
[<span data-ttu-id="d090c-148">ファイル アクセス許可</span><span class="sxs-lookup"><span data-stu-id="d090c-148">File access permissions</span></span>](https://docs.microsoft.com/windows/uwp/files/file-access-permissions)   
 
 