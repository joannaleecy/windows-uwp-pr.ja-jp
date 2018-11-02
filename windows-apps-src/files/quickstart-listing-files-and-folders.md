---
author: laurenhughes
ms.assetid: 4C59D5AC-58F7-4863-A884-E9E54228A5AD
title: ファイルとフォルダーの列挙と照会
description: フォルダー、ライブラリ、デバイス、またはネットワークの場所にあるファイルやフォルダーにアクセスします。 ファイルやフォルダーのクエリを作成することで、任意の場所にあるファイルやフォルダーを照会することもできます。
ms.author: lahugh
ms.date: 06/28/2018
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
dev_langs:
- csharp
- cppwinrt
- cpp
- vb
ms.openlocfilehash: 13aa22906e9c5ba64237b2c69025143060ff85a9
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/02/2018
ms.locfileid: "5937361"
---
# <a name="enumerate-and-query-files-and-folders"></a><span data-ttu-id="d6d17-105">ファイルとフォルダーの列挙と照会</span><span class="sxs-lookup"><span data-stu-id="d6d17-105">Enumerate and query files and folders</span></span>

<span data-ttu-id="d6d17-106">フォルダー、ライブラリ、デバイス、またはネットワークの場所にあるファイルやフォルダーにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="d6d17-106">Access files and folders in either a folder, library, device, or network location.</span></span> <span data-ttu-id="d6d17-107">ファイルやフォルダーのクエリを作成することで、任意の場所にあるファイルやフォルダーを照会することもできます。</span><span class="sxs-lookup"><span data-stu-id="d6d17-107">You can also query the files and folders in a location by constructing file and folder queries.</span></span>

<span data-ttu-id="d6d17-108">ユニバーサル Windows プラットフォーム アプリのデータを保存する方法について詳しくは、[ApplicationData](/uwp/api/windows.storage.applicationdata) クラスをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d6d17-108">For guidance on how to store your Universal Windows Platform app's data, see the [ApplicationData](/uwp/api/windows.storage.applicationdata) class.</span></span>

> [!NOTE]
> <span data-ttu-id="d6d17-109">また、[フォルダーの列挙のサンプル](http://go.microsoft.com/fwlink/p/?linkid=619993)に関するページも参照してください。</span><span class="sxs-lookup"><span data-stu-id="d6d17-109">Also see the [Folder enumeration sample](http://go.microsoft.com/fwlink/p/?linkid=619993).</span></span>

## <a name="prerequisites"></a><span data-ttu-id="d6d17-110">前提条件</span><span class="sxs-lookup"><span data-stu-id="d6d17-110">Prerequisites</span></span>

-   **<span data-ttu-id="d6d17-111">ユニバーサル Windows プラットフォーム (UWP) アプリの非同期プログラミングについての理解</span><span class="sxs-lookup"><span data-stu-id="d6d17-111">Understand async programming for Universal Windows Platform (UWP) apps</span></span>**

    <span data-ttu-id="d6d17-112">C# や Visual Basic での非同期アプリの作成方法については、「[C# または Visual Basic での非同期 API の呼び出し](/windows/uwp/threading-async/call-asynchronous-apis-in-csharp-or-visual-basic)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d6d17-112">You can learn how to write asynchronous apps in C# or Visual Basic, see [Call asynchronous APIs in C# or Visual Basic](/windows/uwp/threading-async/call-asynchronous-apis-in-csharp-or-visual-basic).</span></span> <span data-ttu-id="d6d17-113">C++ 非同期アプリの作成する方法について/WinRT を参照してください[同時実行と非同期操作において、C++/WinRT](/windows/uwp/cpp-and-winrt-apis/concurrency)します。</span><span class="sxs-lookup"><span data-stu-id="d6d17-113">To learn how to write asynchronous apps in C++/WinRT, see [Concurrency and asynchronous operations with C++/WinRT](/windows/uwp/cpp-and-winrt-apis/concurrency).</span></span> <span data-ttu-id="d6d17-114">C++ 非同期アプリの作成する方法について +/CX を参照してください[、C++ での非同期プログラミング/CX](/windows/uwp/threading-async/asynchronous-programming-in-cpp-universal-windows-platform-apps)します。</span><span class="sxs-lookup"><span data-stu-id="d6d17-114">To learn how to write asynchronous apps in C++/CX, see [Asynchronous programming in C++/CX](/windows/uwp/threading-async/asynchronous-programming-in-cpp-universal-windows-platform-apps).</span></span>

-   **<span data-ttu-id="d6d17-115">場所へのアクセス許可</span><span class="sxs-lookup"><span data-stu-id="d6d17-115">Access permissions to the location</span></span>**

    <span data-ttu-id="d6d17-116">たとえば、これらの例のコードでは **picturesLibrary** 機能が必要ですが、場所によっては別の機能が必要であったり、機能をまったく必要としない場合もあります。</span><span class="sxs-lookup"><span data-stu-id="d6d17-116">For example, the code in these examples require the **picturesLibrary** capability, but your location may require a different capability or no capability at all.</span></span> <span data-ttu-id="d6d17-117">詳しくは、「[ファイル アクセス許可](file-access-permissions.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d6d17-117">To learn more, see [File access permissions](file-access-permissions.md).</span></span>

## <a name="enumerate-files-and-folders-in-a-location"></a><span data-ttu-id="d6d17-118">ある場所のファイルやフォルダーを列挙する</span><span class="sxs-lookup"><span data-stu-id="d6d17-118">Enumerate files and folders in a location</span></span>

> [!NOTE]
> <span data-ttu-id="d6d17-119">必ず **picturesLibrary** 機能を宣言してください。</span><span class="sxs-lookup"><span data-stu-id="d6d17-119">Remember to declare the **picturesLibrary** capability.</span></span>

<span data-ttu-id="d6d17-120">この例ではまずメソッドを使用して、 [**StorageFolder.GetFilesAsync**](/uwp/api/windows.storage.storagefolder.getfilesasync) (サブフォルダーは除く) ではなく[**KnownFolders.PicturesLibrary**](/uwp/api/windows.storage.knownfolders.pictureslibrary)のルート フォルダー内のすべてのファイルを取得して、各ファイルの名前を一覧表示します。</span><span class="sxs-lookup"><span data-stu-id="d6d17-120">In this example we first use the [**StorageFolder.GetFilesAsync**](/uwp/api/windows.storage.storagefolder.getfilesasync) method to get all the files in the root folder of the [**KnownFolders.PicturesLibrary**](/uwp/api/windows.storage.knownfolders.pictureslibrary) (not in subfolders) and list the name of each file.</span></span> <span data-ttu-id="d6d17-121">次に、メソッドを使用して、 [**StorageFolder.GetFoldersAsync**](/uwp/api/windows.storage.storagefolder.getfoldersasync) **PicturesLibrary**内のすべてのサブフォルダーを取得し、各サブフォルダーの名前を一覧表示します。</span><span class="sxs-lookup"><span data-stu-id="d6d17-121">Next, we use the [**StorageFolder.GetFoldersAsync**](/uwp/api/windows.storage.storagefolder.getfoldersasync) method to get all the subfolders in the **PicturesLibrary** and list the name of each subfolder.</span></span>

```csharp
StorageFolder picturesFolder = KnownFolders.PicturesLibrary;
StringBuilder outputText = new StringBuilder();

IReadOnlyList<StorageFile> fileList = await picturesFolder.GetFilesAsync();

outputText.AppendLine("Files:");
foreach (StorageFile file in fileList)
{
    outputText.Append(file.Name + "\n");
}

IReadOnlyList<StorageFolder> folderList = await picturesFolder.GetFoldersAsync();
           
outputText.AppendLine("Folders:");
foreach (StorageFolder folder in folderList)
{
    outputText.Append(folder.DisplayName + "\n");
}
```

```cppwinrt
// MainPage.h
// In MainPage.xaml: <TextBlock x:Name="OutputTextBlock"/>
#include <winrt/Windows.Storage.h>
#include <sstream>
...
Windows::Foundation::IAsyncAction ExampleCoroutineAsync()
{
    // Be sure to specify the Pictures Folder capability in your Package.appxmanifest.
    Windows::Storage::StorageFolder picturesFolder{
        Windows::Storage::KnownFolders::PicturesLibrary()
    };

    std::wstringstream outputString;
    outputString << L"Files:" << std::endl;

    for (auto const& file : co_await picturesFolder.GetFilesAsync())
    {
        outputString << file.Name().c_str() << std::endl;
    }

    outputString << L"Folders:" << std::endl;
    for (auto const& folder : co_await picturesFolder.GetFoldersAsync())
    {
        outputString << folder.Name().c_str() << std::endl;
    }

    OutputTextBlock().Text(outputString.str().c_str());
}
```

```cpp
#include <ppltasks.h>
#include <string>
#include <memory>

using namespace Windows::Storage;
using namespace Platform::Collections;
using namespace concurrency;
using namespace std;

// Be sure to specify the Pictures Folder capability in the appxmanifext file.
StorageFolder^ picturesFolder = KnownFolders::PicturesLibrary;

// Use a shared_ptr so that the string stays in memory
// until the last task is complete.
auto outputString = make_shared<wstring>();
*outputString += L"Files:\n";

// Get a read-only vector of the file objects
// and pass it to the continuation.
create_task(picturesFolder->GetFilesAsync())        
   // outputString is captured by value, which creates a copy
   // of the shared_ptr and increments its reference count.
   .then ([outputString] (IVectorView\<StorageFile^>^ files)
   {        
       for ( unsigned int i = 0 ; i < files->Size; i++)
       {
           *outputString += files->GetAt(i)->Name->Data();
           *outputString += L"\n";
      }
   })
   // We need to explicitly state the return type
   // here: -IAsyncOperation<...>
   .then([picturesFolder]() -IAsyncOperation\<IVectorView\<StorageFolder^>^>^
   {
       return picturesFolder->GetFoldersAsync();
   })
   // Capture "this" to access m_OutputTextBlock from within the lambda.
   .then([this, outputString](IVectorView/<StorageFolder^>^ folders)
   {        
       *outputString += L"Folders:\n";

       for ( unsigned int i = 0; i < folders->Size; i++)
       {
          *outputString += folders->GetAt(i)->Name->Data();
          *outputString += L"\n";
       }

       // Assume m_OutputTextBlock is a TextBlock defined in the XAML.
       m_OutputTextBlock->Text = ref new String((*outputString).c_str());
    });
```

```vb
Dim picturesFolder As StorageFolder = KnownFolders.PicturesLibrary
Dim outputText As New StringBuilder

Dim fileList As IReadOnlyList(Of StorageFile) =
    Await picturesFolder.GetFilesAsync()

outputText.AppendLine("Files:")
For Each file As StorageFile In fileList

    outputText.Append(file.Name & vbLf)

Next file

Dim folderList As IReadOnlyList(Of StorageFolder) =
    Await picturesFolder.GetFoldersAsync()

outputText.AppendLine("Folders:")
For Each folder As StorageFolder In folderList

    outputText.Append(folder.DisplayName & vbLf)

Next folder
```

> [!NOTE]
> <span data-ttu-id="d6d17-122">C# または Visual Basic では、**await** 演算子を使うすべてのメソッドのメソッド宣言で、必ず **async** キーワードを使ってください。</span><span class="sxs-lookup"><span data-stu-id="d6d17-122">In C# or Visual Basic, remember to put the **async** keyword in the method declaration of any method in which you use the **await** operator.</span></span>

<span data-ttu-id="d6d17-123">また、特定の場所ですべての項目 (ファイルとサブフォルダーの両方) を取得するのに[**StorageFolder.GetItemsAsync**](/uwp/api/windows.storage.storagefolder.getitemsasync)メソッドを使用することができます。</span><span class="sxs-lookup"><span data-stu-id="d6d17-123">Alternatively, you can use the [**StorageFolder.GetItemsAsync**](/uwp/api/windows.storage.storagefolder.getitemsasync) method to get all items (both files and subfolders) in a particular location.</span></span> <span data-ttu-id="d6d17-124">次の例では、(サブフォルダーは除く) ではなく、すべてのファイルと[**KnownFolders.PicturesLibrary**](/uwp/api/windows.storage.knownfolders.pictureslibrary)のルート フォルダーにサブフォルダーを取得する、 **GetItemsAsync**メソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="d6d17-124">The following example uses the **GetItemsAsync** method to get all files and subfolders in the root folder of the [**KnownFolders.PicturesLibrary**](/uwp/api/windows.storage.knownfolders.pictureslibrary) (not in subfolders).</span></span> <span data-ttu-id="d6d17-125">その後、各ファイルとサブフォルダーの名前を一覧表示します。</span><span class="sxs-lookup"><span data-stu-id="d6d17-125">Then the example lists the name of each file and subfolder.</span></span> <span data-ttu-id="d6d17-126">項目がサブフォルダーの場合は、名前に `"folder"` を追加します。</span><span class="sxs-lookup"><span data-stu-id="d6d17-126">If the item is a subfolder, the example appends `"folder"` to the name.</span></span>

```csharp
StorageFolder picturesFolder = KnownFolders.PicturesLibrary;
StringBuilder outputText = new StringBuilder();

IReadOnlyList<IStorageItem> itemsList = await picturesFolder.GetItemsAsync();

foreach (var item in itemsList)
{
    if (item is StorageFolder)
    {
        outputText.Append(item.Name + " folder\n");

    }
    else
    {
        outputText.Append(item.Name + "\n");
    }
}
```

```cppwinrt
// MainPage.h
// In MainPage.xaml: <TextBlock x:Name="OutputTextBlock"/>
#include <winrt/Windows.Storage.h>
#include <sstream>
...
Windows::Foundation::IAsyncAction ExampleCoroutineAsync()
{
    // Be sure to specify the Pictures Folder capability in your Package.appxmanifest.
    Windows::Storage::StorageFolder picturesFolder{
        Windows::Storage::KnownFolders::PicturesLibrary()
    };

    std::wstringstream outputString;

    for (Windows::Storage::IStorageItem const& item : co_await picturesFolder.GetItemsAsync())
    {
        outputString << item.Name().c_str();

        if (item.IsOfType(Windows::Storage::StorageItemTypes::Folder))
        {
            outputString << L" folder" << std::endl;
        }
        else
        {
            outputString << std::endl;
        }

        OutputTextBlock().Text(outputString.str().c_str());
    }
}
```

```cpp
// See previous example for comments, namespace and #include info.
StorageFolder^ picturesFolder = KnownFolders::PicturesLibrary;
auto outputString = make_shared<wstring>();

create_task(picturesFolder->GetItemsAsync())        
    .then ([this, outputString] (IVectorView<IStorageItem^>^ items)
{        
    for ( unsigned int i = 0 ; i < items->Size; i++)
    {
        *outputString += items->GetAt(i)->Name->Data();
        if(items->GetAt(i)->IsOfType(StorageItemTypes::Folder))
        {
            *outputString += L"  folder\n";
        }
        else
        {
            *outputString += L"\n";
        }
        m_OutputTextBlock->Text = ref new String((*outputString).c_str());
    }
});
```

```vb
Dim picturesFolder As StorageFolder = KnownFolders.PicturesLibrary
Dim outputText As New StringBuilder

Dim itemsList As IReadOnlyList(Of IStorageItem) =
    Await picturesFolder.GetItemsAsync()

For Each item In itemsList

    If TypeOf item Is StorageFolder Then

        outputText.Append(item.Name & " folder" & vbLf)

    Else

        outputText.Append(item.Name & vbLf)

    End If

Next item
```

## <a name="query-files-in-a-location-and-enumerate-matching-files"></a><span data-ttu-id="d6d17-127">ある場所に保存されているファイルを照会して、一致するファイルを列挙する</span><span class="sxs-lookup"><span data-stu-id="d6d17-127">Query files in a location and enumerate matching files</span></span>

<span data-ttu-id="d6d17-128">この例では、月、この時点でグループ化された[**KnownFolders.PicturesLibrary**](/uwp/api/windows.storage.knownfolders.pictureslibrary)内のすべてのファイルを照会しますの例のサブフォルダーに再帰の回数します。</span><span class="sxs-lookup"><span data-stu-id="d6d17-128">In this example we query for all the files in the [**KnownFolders.PicturesLibrary**](/uwp/api/windows.storage.knownfolders.pictureslibrary) grouped by the month, and this time the example recurses into subfolders.</span></span> <span data-ttu-id="d6d17-129">まず、[**StorageFolder.CreateFolderQuery**](/uwp/api/windows.storage.storagefolder.createfolderquery) を呼び出し、[**CommonFolderQuery.GroupByMonth**](/uwp/api/windows.storage.search.commonfolderquery) の値をメソッドに渡します。</span><span class="sxs-lookup"><span data-stu-id="d6d17-129">First, we call [**StorageFolder.CreateFolderQuery**](/uwp/api/windows.storage.storagefolder.createfolderquery) and pass the [**CommonFolderQuery.GroupByMonth**](/uwp/api/windows.storage.search.commonfolderquery) value to the method.</span></span> <span data-ttu-id="d6d17-130">これで、[**StorageFolderQueryResult**](/uwp/api/windows.storage.search.storagefolderqueryresult) オブジェクトが取得されます。</span><span class="sxs-lookup"><span data-stu-id="d6d17-130">That gives us a [**StorageFolderQueryResult**](/uwp/api/windows.storage.search.storagefolderqueryresult) object.</span></span>

<span data-ttu-id="d6d17-131">次に、仮想フォルダーを表す [**StorageFolder**](/uwp/api/windows.storage.storagefolder) のオブジェクトを返す [**StorageFolderQueryResult.GetFoldersAsync**](/uwp/api/windows.storage.search.storagefolderqueryresult.getfoldersasync) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="d6d17-131">Next we call [**StorageFolderQueryResult.GetFoldersAsync**](/uwp/api/windows.storage.search.storagefolderqueryresult.getfoldersasync) which returns [**StorageFolder**](/uwp/api/windows.storage.storagefolder) objects representing virtual folders.</span></span> <span data-ttu-id="d6d17-132">ここでは月でグループ化されているため、各仮想フォルダーは同じ月にあるファイルのグループを表します。</span><span class="sxs-lookup"><span data-stu-id="d6d17-132">In this case we're grouping by month, so the virtual folders each represent a group of files with the same month.</span></span>

```csharp
StorageFolder picturesFolder = KnownFolders.PicturesLibrary;

StorageFolderQueryResult queryResult =
    picturesFolder.CreateFolderQuery(CommonFolderQuery.GroupByMonth);
        
IReadOnlyList<StorageFolder> folderList =
    await queryResult.GetFoldersAsync();

StringBuilder outputText = new StringBuilder();

foreach (StorageFolder folder in folderList)
{
    IReadOnlyList<StorageFile> fileList = await folder.GetFilesAsync();

    // Print the month and number of files in this group.
    outputText.AppendLine(folder.Name + " (" + fileList.Count + ")");

    foreach (StorageFile file in fileList)
    {
        // Print the name of the file.
        outputText.AppendLine("   " + file.Name);
    }
}
```

```cppwinrt
// MainPage.h
// In MainPage.xaml: <TextBlock x:Name="OutputTextBlock"/>
#include <winrt/Windows.Storage.h>
#include <winrt/Windows.Storage.Search.h>
#include <sstream>
...
Windows::Foundation::IAsyncAction ExampleCoroutineAsync()
{
    // Be sure to specify the Pictures Folder capability in your Package.appxmanifest.
    Windows::Storage::StorageFolder picturesFolder{
        Windows::Storage::KnownFolders::PicturesLibrary()
    };

    Windows::Storage::Search::StorageFolderQueryResult queryResult{
        picturesFolder.CreateFolderQuery(Windows::Storage::Search::CommonFolderQuery::GroupByMonth)
    };

    std::wstringstream outputString;

    for (Windows::Storage::StorageFolder const& folder : co_await queryResult.GetFoldersAsync())
    {
        auto files{ co_await folder.GetFilesAsync() };
        outputString << folder.Name().c_str() << L" (" << files.Size() << L")" << std::endl;

        for (Windows::Storage::StorageFile const& file : files)
        {
            outputString << L"    " << file.Name().c_str() << std::endl;
        }
    }

    OutputTextBlock().Text(outputString.str().c_str());
}
```

```cpp
#include <ppltasks.h>
#include <string>
#include <memory>
using namespace Windows::Storage;
using namespace Windows::Storage::Search;
using namespace concurrency;
using namespace Platform::Collections;
using namespace Windows::Foundation::Collections;
using namespace std;

StorageFolder^ picturesFolder = KnownFolders::PicturesLibrary;

StorageFolderQueryResult^ queryResult =
    picturesFolder->CreateFolderQuery(CommonFolderQuery::GroupByMonth);

// Use shared_ptr so that outputString remains in memory
// until the task completes, which is after the function goes out of scope.
auto outputString = std::make_shared<wstring>();

create_task( queryResult->GetFoldersAsync()).then([this, outputString] (IVectorView<StorageFolder^>^ view)
{        
    for ( unsigned int i = 0; i < view->Size; i++)
    {
        create_task(view->GetAt(i)->GetFilesAsync()).then([this, i, view, outputString](IVectorView<StorageFile^>^ files)
        {
            *outputString += view->GetAt(i)->Name->Data();
            *outputString += L" (";
            *outputString += to_wstring(files->Size);
            *outputString += L")\r\n";
            for (unsigned int j = 0; j < files->Size; j++)
            {
                *outputString += L"     ";
                *outputString += files->GetAt(j)->Name->Data();
                *outputString += L"\r\n";
            }
        }).then([this, outputString]()
        {
            m_OutputTextBlock->Text = ref new String((*outputString).c_str());
        });
    }    
});
```

```vb
Dim picturesFolder As StorageFolder = KnownFolders.PicturesLibrary
Dim outputText As New StringBuilder

Dim queryResult As StorageFolderQueryResult =
    picturesFolder.CreateFolderQuery(CommonFolderQuery.GroupByMonth)

Dim folderList As IReadOnlyList(Of StorageFolder) =
    Await queryResult.GetFoldersAsync()

For Each folder As StorageFolder In folderList

    Dim fileList As IReadOnlyList(Of StorageFile) =
        Await folder.GetFilesAsync()

    ' Print the month and number of files in this group.
    outputText.AppendLine(folder.Name & " (" & fileList.Count & ")")

    For Each file As StorageFile In fileList

        ' Print the name of the file.
        outputText.AppendLine("   " & file.Name)

    Next file

Next folder
```

<span data-ttu-id="d6d17-133">この例の出力は次のようになります。</span><span class="sxs-lookup"><span data-stu-id="d6d17-133">The output of the example looks similar to the following.</span></span>

```syntax
July ‎2015 (2)
   MyImage3.png
   MyImage4.png
‎December ‎2014 (2)
   MyImage1.png
   MyImage2.png
```
