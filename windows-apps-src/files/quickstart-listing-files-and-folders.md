---
author: laurenhughes
ms.assetid: 4C59D5AC-58F7-4863-A884-E9E54228A5AD
title: ファイルとフォルダーの列挙と照会
description: フォルダー、ライブラリ、デバイス、またはネットワークの場所にあるファイルやフォルダーにアクセスします。 ファイルやフォルダーのクエリを作成することで、任意の場所にあるファイルやフォルダーを照会することもできます。
ms.author: lahugh
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 04cd59c454f0cd1561f35125f394c68bc5753002
ms.sourcegitcommit: 0ab8f6fac53a6811f977ddc24de039c46c9db0ad
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/15/2018
ms.locfileid: "1652861"
---
# <a name="enumerate-and-query-files-and-folders"></a><span data-ttu-id="03e43-105">ファイルとフォルダーの列挙と照会</span><span class="sxs-lookup"><span data-stu-id="03e43-105">Enumerate and query files and folders</span></span>




<span data-ttu-id="03e43-106">フォルダー、ライブラリ、デバイス、またはネットワークの場所にあるファイルやフォルダーにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="03e43-106">Access files and folders in either a folder, library, device, or network location.</span></span> <span data-ttu-id="03e43-107">ファイルやフォルダーのクエリを作成することで、任意の場所にあるファイルやフォルダーを照会することもできます。</span><span class="sxs-lookup"><span data-stu-id="03e43-107">You can also query the files and folders in a location by constructing file and folder queries.</span></span>

<span data-ttu-id="03e43-108">ユニバーサル Windows プラットフォーム アプリのデータを保存する方法について詳しくは、[ApplicationData](https://msdn.microsoft.com/library/windows/apps/windows.storage.applicationdata.aspx) クラスをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="03e43-108">For guidance on how to store your Universal Windows Platform app's data, see the [ApplicationData](https://msdn.microsoft.com/library/windows/apps/windows.storage.applicationdata.aspx) class.</span></span>

> [!NOTE]
> <span data-ttu-id="03e43-109">また、[フォルダーの列挙のサンプル](http://go.microsoft.com/fwlink/p/?linkid=619993)に関するページも参照してください。</span><span class="sxs-lookup"><span data-stu-id="03e43-109">Also see the [Folder enumeration sample](http://go.microsoft.com/fwlink/p/?linkid=619993).</span></span>

 
## <a name="prerequisites"></a><span data-ttu-id="03e43-110">前提条件</span><span class="sxs-lookup"><span data-stu-id="03e43-110">Prerequisites</span></span>

-   **<span data-ttu-id="03e43-111">ユニバーサル Windows プラットフォーム (UWP) アプリの非同期プログラミングについての理解</span><span class="sxs-lookup"><span data-stu-id="03e43-111">Understand async programming for Universal Windows Platform (UWP) apps</span></span>**

    <span data-ttu-id="03e43-112">C# や Visual Basic での非同期アプリの作成方法については、「[C# または Visual Basic での非同期 API の呼び出し](https://msdn.microsoft.com/library/windows/apps/mt187337)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="03e43-112">You can learn how to write asynchronous apps in C# or Visual Basic, see [Call asynchronous APIs in C# or Visual Basic](https://msdn.microsoft.com/library/windows/apps/mt187337).</span></span> <span data-ttu-id="03e43-113">C++ での非同期アプリの作成方法については、「[C++ での非同期プログラミング](https://msdn.microsoft.com/library/windows/apps/mt187334)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="03e43-113">To learn how to write asynchronous apps in C++, see [Asynchronous programming in C++](https://msdn.microsoft.com/library/windows/apps/mt187334).</span></span>

-   **<span data-ttu-id="03e43-114">場所へのアクセス許可</span><span class="sxs-lookup"><span data-stu-id="03e43-114">Access permissions to the location</span></span>**

    <span data-ttu-id="03e43-115">たとえば、これらの例のコードでは **picturesLibrary** 機能が必要ですが、場所によっては別の機能が必要であったり、機能をまったく必要としない場合もあります。</span><span class="sxs-lookup"><span data-stu-id="03e43-115">For example, the code in these examples require the **picturesLibrary** capability, but your location may require a different capability or no capability at all.</span></span> <span data-ttu-id="03e43-116">詳しくは、「[ファイル アクセス許可](file-access-permissions.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="03e43-116">To learn more, see [File access permissions](file-access-permissions.md).</span></span>

## <a name="enumerate-files-and-folders-in-a-location"></a><span data-ttu-id="03e43-117">ある場所のファイルやフォルダーを列挙する</span><span class="sxs-lookup"><span data-stu-id="03e43-117">Enumerate files and folders in a location</span></span>

> [!NOTE]
> <span data-ttu-id="03e43-118">必ず **picturesLibrary** 機能を宣言してください。</span><span class="sxs-lookup"><span data-stu-id="03e43-118">Remember to declare the **picturesLibrary** capability.</span></span>

<span data-ttu-id="03e43-119">この例では、まず [**StorageFolder.GetFilesAsync**](https://msdn.microsoft.com/library/windows/apps/br227276) メソッドを使って [**PicturesLibrary**](https://msdn.microsoft.com/library/windows/apps/br227156) 内のルート フォルダー (サブフォルダーは除く) にあるすべてのファイルを取得し、各ファイルの名前を一覧表示します。</span><span class="sxs-lookup"><span data-stu-id="03e43-119">In this example we first use the [**StorageFolder.GetFilesAsync**](https://msdn.microsoft.com/library/windows/apps/br227276) method to get all the files in the root folder of the [**PicturesLibrary**](https://msdn.microsoft.com/library/windows/apps/br227156) (not in subfolders) and list the name of each file.</span></span> <span data-ttu-id="03e43-120">次に、[**GetFoldersAsync**](https://msdn.microsoft.com/library/windows/apps/br227280) メソッドを使って **PicturesLibrary** 内のすべてのサブフォルダーを取得し、各サブフォルダーの名前を一覧表示します。</span><span class="sxs-lookup"><span data-stu-id="03e43-120">Next, we use the [**GetFoldersAsync**](https://msdn.microsoft.com/library/windows/apps/br227280) method to get all the subfolders in the **PicturesLibrary** and list the name of each subfolder.</span></span>

<!--BUGBUG: IAsyncOperation<IVectorView<StorageFolder^>^>^  causes build to flake out-->
> [!div class="tabbedCodeSnippets"]
> ```cpp
> //#include <ppltasks.h>
> //#include <string>
> //#include <memory>
> using namespace Windows::Storage;
> using namespace Platform::Collections;
> using namespace concurrency;
> using namespace std;
>
> // Be sure to specify the Pictures Folder capability in the appxmanifext file.
> StorageFolder^ picturesFolder = KnownFolders::PicturesLibrary;
>
> // Use a shared_ptr so that the string stays in memory
> // until the last task is complete.
> auto outputString = make_shared<wstring>();
> *outputString += L"Files:\n";
>
> // Get a read-only vector of the file objects
> // and pass it to the continuation.
> create_task(picturesFolder->GetFilesAsync())        
>    // outputString is captured by value, which creates a copy
>    // of the shared_ptr and increments its reference count.
>    .then ([outputString] (IVectorView\<StorageFile^>^ files)
>    {        
>        for ( unsigned int i = 0 ; i < files->Size; i++)
>        {
>            *outputString += files->GetAt(i)->Name->Data();
>            *outputString += L"\n";
>       }
>    })
>    // We need to explicitly state the return type
>    // here: -> IAsyncOperation<...>
>    .then([picturesFolder]() -> IAsyncOperation\<IVectorView\<StorageFolder^>^>^
>    {
>        return picturesFolder->GetFoldersAsync();
>    })
>    // Capture "this" to access m_OutputTextBlock from within the lambda.
>    .then([this, outputString](IVectorView/<StorageFolder^>^ folders)
>    {        
>        *outputString += L"Folders:\n";
>
>        for ( unsigned int i = 0; i < folders->Size; i++)
>        {
>           *outputString += folders->GetAt(i)->Name->Data();
>           *outputString += L"\n";
>        }
>
>        // Assume m_OutputTextBlock is a TextBlock defined in the XAML.
>        m_OutputTextBlock->Text = ref new String((*outputString).c_str());
>     });
> ```
> ```cs
> StorageFolder picturesFolder = KnownFolders.PicturesLibrary;
> StringBuilder outputText = new StringBuilder();
>
> IReadOnlyList<StorageFile> fileList = await picturesFolder.GetFilesAsync();
>
> outputText.AppendLine("Files:");
> foreach (StorageFile file in fileList)
> {
>     outputText.Append(file.Name + "\n");
> }
>
> IReadOnlyList<StorageFolder> folderList = await picturesFolder.GetFoldersAsync();
>            
> outputText.AppendLine("Folders:");
> foreach (StorageFolder folder in folderList)
> {
>     outputText.Append(folder.DisplayName + "\n");
> }
> ```
> ```vb
> Dim picturesFolder As StorageFolder = KnownFolders.PicturesLibrary
> Dim outputText As New StringBuilder
>
> Dim fileList As IReadOnlyList(Of StorageFile) =
>     Await picturesFolder.GetFilesAsync()
>
> outputText.AppendLine("Files:")
> For Each file As StorageFile In fileList
>
>     outputText.Append(file.Name & vbLf)
>
> Next file
>
> Dim folderList As IReadOnlyList(Of StorageFolder) =
>     Await picturesFolder.GetFoldersAsync()
>
> outputText.AppendLine("Folders:")
> For Each folder As StorageFolder In folderList
>
>     outputText.Append(folder.DisplayName & vbLf)
>
> Next folder
> ```


> [!NOTE]
> <span data-ttu-id="03e43-121">C# または Visual Basic では、**await** 演算子を使うすべてのメソッドのメソッド宣言で、必ず **async** キーワードを使ってください。</span><span class="sxs-lookup"><span data-stu-id="03e43-121">In C# or Visual Basic, remember to put the **async** keyword in the method declaration of any method in which you use the **await** operator.</span></span>
 

<span data-ttu-id="03e43-122">または、[**GetItemsAsync**](https://msdn.microsoft.com/library/windows/apps/br227286) メソッドを使って、特定の場所にあるすべての項目 (ファイルとサブフォルダーの両方) を取得することもできます。</span><span class="sxs-lookup"><span data-stu-id="03e43-122">Alternatively, you can use the [**GetItemsAsync**](https://msdn.microsoft.com/library/windows/apps/br227286) method to get all items (both files and subfolders) in a particular location.</span></span> <span data-ttu-id="03e43-123">次の例では、**GetItemsAsync** メソッドを使って [**PicturesLibrary**](https://msdn.microsoft.com/library/windows/apps/br227156) 内のルート フォルダー (サブフォルダーは除く) にあるすべてのファイルとサブフォルダーを取得します。</span><span class="sxs-lookup"><span data-stu-id="03e43-123">The following example uses the **GetItemsAsync** method to get all files and subfolders in the root folder of the [**PicturesLibrary**](https://msdn.microsoft.com/library/windows/apps/br227156) (not in subfolders).</span></span> <span data-ttu-id="03e43-124">その後、各ファイルとサブフォルダーの名前を一覧表示します。</span><span class="sxs-lookup"><span data-stu-id="03e43-124">Then the example lists the name of each file and subfolder.</span></span> <span data-ttu-id="03e43-125">項目がサブフォルダーの場合は、名前に `"folder"` を追加します。</span><span class="sxs-lookup"><span data-stu-id="03e43-125">If the item is a subfolder, the example appends `"folder"` to the name.</span></span>

> [!div class="tabbedCodeSnippets"]
> ```cpp
> // See previous example for comments, namespace and #include info.
> StorageFolder^ picturesFolder = KnownFolders::PicturesLibrary;
> auto outputString = make_shared<wstring>();
>
> create_task(picturesFolder->GetItemsAsync())        
>     .then ([this, outputString] (IVectorView<IStorageItem^>^ items)
> {        
>     for ( unsigned int i = 0 ; i < items->Size; i++)
>     {
>         *outputString += items->GetAt(i)->Name->Data();
>         if(items->GetAt(i)->IsOfType(StorageItemTypes::Folder))
>         {
>             *outputString += L"  folder\n";
>         }
>         else
>         {
>             *outputString += L"\n";
>         }
>         m_OutputTextBlock->Text = ref new String((*outputString).c_str());
>     }
> });
> ```
> ```cs
> StorageFolder picturesFolder = KnownFolders.PicturesLibrary;
> StringBuilder outputText = new StringBuilder();
>
> IReadOnlyList<IStorageItem> itemsList = await picturesFolder.GetItemsAsync();
>
> foreach (var item in itemsList)
> {
>     if (item is StorageFolder)
>     {
>         outputText.Append(item.Name + " folder\n");
>
>     }
>     else
>     {
>         outputText.Append(item.Name + "\n");
>     }
> }
> ```
> ```vb
> Dim picturesFolder As StorageFolder = KnownFolders.PicturesLibrary
> Dim outputText As New StringBuilder
>
> Dim itemsList As IReadOnlyList(Of IStorageItem) =
>     Await picturesFolder.GetItemsAsync()
>
> For Each item In itemsList
>
>     If TypeOf item Is StorageFolder Then
>
>         outputText.Append(item.Name & " folder" & vbLf)
>
>     Else
>
>         outputText.Append(item.Name & vbLf)
>
>     End If
>
> Next item
> ```

## <a name="query-files-in-a-location-and-enumerate-matching-files"></a><span data-ttu-id="03e43-126">ある場所に保存されているファイルを照会して、一致するファイルを列挙する</span><span class="sxs-lookup"><span data-stu-id="03e43-126">Query files in a location and enumerate matching files</span></span>

<span data-ttu-id="03e43-127">この例では [**PicturesLibrary**](https://msdn.microsoft.com/library/windows/apps/br227156) にある月ごとにグループ化されたすべてのファイルを照会し、今回はサブフォルダーに再帰的に呼び出します。</span><span class="sxs-lookup"><span data-stu-id="03e43-127">In this example we query for all the files in the [**PicturesLibrary**](https://msdn.microsoft.com/library/windows/apps/br227156) grouped by the month, and this time the example recurses into subfolders.</span></span> <span data-ttu-id="03e43-128">まず、[**StorageFolder.CreateFolderQuery**](https://msdn.microsoft.com/library/windows/apps/br227262) を呼び出し、[**CommonFolderQuery.GroupByMonth**](https://msdn.microsoft.com/library/windows/apps/br207957) の値をメソッドに渡します。</span><span class="sxs-lookup"><span data-stu-id="03e43-128">First, we call [**StorageFolder.CreateFolderQuery**](https://msdn.microsoft.com/library/windows/apps/br227262) and pass the [**CommonFolderQuery.GroupByMonth**](https://msdn.microsoft.com/library/windows/apps/br207957) value to the method.</span></span> <span data-ttu-id="03e43-129">これで、[**StorageFolderQueryResult**](https://msdn.microsoft.com/library/windows/apps/br208066) オブジェクトが取得されます。</span><span class="sxs-lookup"><span data-stu-id="03e43-129">That gives us a [**StorageFolderQueryResult**](https://msdn.microsoft.com/library/windows/apps/br208066) object.</span></span>

<span data-ttu-id="03e43-130">次に、仮想フォルダーを表す [**StorageFolder**](https://msdn.microsoft.com/library/windows/apps/br227230) のオブジェクトを返す [**StorageFolderQueryResult.GetFoldersAsync**](https://msdn.microsoft.com/library/windows/apps/br208074) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="03e43-130">Next we call [**StorageFolderQueryResult.GetFoldersAsync**](https://msdn.microsoft.com/library/windows/apps/br208074) which returns [**StorageFolder**](https://msdn.microsoft.com/library/windows/apps/br227230) objects representing virtual folders.</span></span> <span data-ttu-id="03e43-131">ここでは月でグループ化されているため、各仮想フォルダーは同じ月にあるファイルのグループを表します。</span><span class="sxs-lookup"><span data-stu-id="03e43-131">In this case we're grouping by month, so the virtual folders each represent a group of files with the same month.</span></span>

> [!div class="tabbedCodeSnippets"]
> ```cpp
> //#include <ppltasks.h>
> //#include <string>
> //#include <memory>
> using namespace Windows::Storage;
> using namespace Windows::Storage::Search;
> using namespace concurrency;
> using namespace Platform::Collections;
> using namespace Windows::Foundation::Collections;
> using namespace std;
>
> StorageFolder^ picturesFolder = KnownFolders::PicturesLibrary;
>
> StorageFolderQueryResult^ queryResult =
>     picturesFolder->CreateFolderQuery(CommonFolderQuery::GroupByMonth);
>
> // Use shared_ptr so that outputString remains in memory
> // until the task completes, which is after the function goes out of scope.
> auto outputString = std::make_shared<wstring>();
>
> create_task( queryResult->GetFoldersAsync()).then([this, outputString] (IVectorView<StorageFolder^>^ view)
> {        
>     for ( unsigned int i = 0; i < view->Size; i++)
>     {
>         create_task(view->GetAt(i)->GetFilesAsync()).then([this, i, view, outputString](IVectorView<StorageFile^>^ files)
>         {
>             *outputString += view->GetAt(i)->Name->Data();
>             *outputString += L"(";
>             *outputString += to_wstring(files->Size);
>             *outputString += L")\r\n";
>             for (unsigned int j = 0; j < files->Size; j++)
>             {
>                 *outputString += L"     ";
>                 *outputString += files->GetAt(j)->Name->Data();
>                 *outputString += L"\r\n";
>             }
>         }).then([this, outputString]()
>         {
>             m_OutputTextBlock->Text = ref new String((*outputString).c_str());
>         });
>     }    
> });
> ```
> ```cs
> StorageFolder picturesFolder = KnownFolders.PicturesLibrary;
>
> StorageFolderQueryResult queryResult =
>     picturesFolder.CreateFolderQuery(CommonFolderQuery.GroupByMonth);
>         
> IReadOnlyList<StorageFolder> folderList =
>     await queryResult.GetFoldersAsync();
>
> StringBuilder outputText = new StringBuilder();
>
> foreach (StorageFolder folder in folderList)
> {
>     IReadOnlyList<StorageFile> fileList = await folder.GetFilesAsync();
>
>     // Print the month and number of files in this group.
>     outputText.AppendLine(folder.Name + " (" + fileList.Count + ")");
>
>     foreach (StorageFile file in fileList)
>     {
>         // Print the name of the file.
>         outputText.AppendLine("   " + file.Name);
>     }
> }
> ```
> ```vb
> Dim picturesFolder As StorageFolder = KnownFolders.PicturesLibrary
> Dim outputText As New StringBuilder
>
> Dim queryResult As StorageFolderQueryResult =
>     picturesFolder.CreateFolderQuery(CommonFolderQuery.GroupByMonth)
>
> Dim folderList As IReadOnlyList(Of StorageFolder) =
>     Await queryResult.GetFoldersAsync()
>
> For Each folder As StorageFolder In folderList
>
>     Dim fileList As IReadOnlyList(Of StorageFile) =
>         Await folder.GetFilesAsync()
>
>     ' Print the month and number of files in this group.
>     outputText.AppendLine(folder.Name & " (" & fileList.Count & ")")
>
>     For Each file As StorageFile In fileList
>
>         ' Print the name of the file.
>         outputText.AppendLine("   " & file.Name)
>
>     Next file
>
> Next folder
> ```

<span data-ttu-id="03e43-132">この例の出力は次のようになります。</span><span class="sxs-lookup"><span data-stu-id="03e43-132">The output of the example looks similar to the following.</span></span>

``` syntax
July ‎2015 (2)
   MyImage3.png
   MyImage4.png
‎December ‎2014 (2)
   MyImage1.png
   MyImage2.png
```
