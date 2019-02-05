---
ms.assetid: AC96F645-1BDE-4316-85E0-2FBDE0A0A62A
title: ファイルのプロパティの取得
description: StorageFile オブジェクトで表されるファイルのプロパティ (最上位、基本、拡張) を取得します。
ms.date: 12/19/2018
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 6cde9d8753248614603ee49fb1415ec18ec4669b
ms.sourcegitcommit: bf600a1fb5f7799961914f638061986d55f6ab12
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 02/04/2019
ms.locfileid: "9044190"
---
# <a name="get-file-properties"></a><span data-ttu-id="ce8a9-104">ファイルのプロパティの取得</span><span class="sxs-lookup"><span data-stu-id="ce8a9-104">Get file properties</span></span>

**<span data-ttu-id="ce8a9-105">重要な API</span><span class="sxs-lookup"><span data-stu-id="ce8a9-105">Important APIs</span></span>**

-   [**<span data-ttu-id="ce8a9-106">StorageFile.GetBasicPropertiesAsync</span><span class="sxs-lookup"><span data-stu-id="ce8a9-106">StorageFile.GetBasicPropertiesAsync</span></span>**](https://msdn.microsoft.com/library/windows/apps/hh701737)
-   [**<span data-ttu-id="ce8a9-107">StorageFile.Properties</span><span class="sxs-lookup"><span data-stu-id="ce8a9-107">StorageFile.Properties</span></span>**](https://msdn.microsoft.com/library/windows/apps/br227225)
-   [**<span data-ttu-id="ce8a9-108">StorageItemContentProperties.RetrievePropertiesAsync</span><span class="sxs-lookup"><span data-stu-id="ce8a9-108">StorageItemContentProperties.RetrievePropertiesAsync</span></span>**](https://msdn.microsoft.com/library/windows/apps/hh770652)

<span data-ttu-id="ce8a9-109">[**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) オブジェクトで表されるファイルのプロパティ (最上位、基本、拡張) を取得します。</span><span class="sxs-lookup"><span data-stu-id="ce8a9-109">Get properties—top-level, basic, and extended—for a file represented by a [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) object.</span></span>

> [!NOTE]
> <span data-ttu-id="ce8a9-110">完全なサンプルについては、[ファイル アクセスのサンプル](https://go.microsoft.com/fwlink/p/?linkid=619995)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="ce8a9-110">For a complete sample, see the [File access sample](https://go.microsoft.com/fwlink/p/?linkid=619995).</span></span>

## <a name="prerequisites"></a><span data-ttu-id="ce8a9-111">前提条件</span><span class="sxs-lookup"><span data-stu-id="ce8a9-111">Prerequisites</span></span>

-   **<span data-ttu-id="ce8a9-112">ユニバーサル Windows プラットフォーム (UWP) アプリの非同期プログラミングについての理解</span><span class="sxs-lookup"><span data-stu-id="ce8a9-112">Understand async programming for Universal Windows Platform (UWP) apps</span></span>**

    <span data-ttu-id="ce8a9-113">C# や Visual Basic での非同期アプリの作成方法については、「[C# または Visual Basic での非同期 API の呼び出し](https://msdn.microsoft.com/library/windows/apps/mt187337)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ce8a9-113">You can learn how to write asynchronous apps in C# or Visual Basic, see [Call asynchronous APIs in C# or Visual Basic](https://msdn.microsoft.com/library/windows/apps/mt187337).</span></span> <span data-ttu-id="ce8a9-114">C++ での非同期アプリの作成方法については、「[C++ での非同期プログラミング](https://msdn.microsoft.com/library/windows/apps/mt187334)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ce8a9-114">To learn how to write asynchronous apps in C++, see [Asynchronous programming in C++](https://msdn.microsoft.com/library/windows/apps/mt187334).</span></span>

-   **<span data-ttu-id="ce8a9-115">場所へのアクセス許可</span><span class="sxs-lookup"><span data-stu-id="ce8a9-115">Access permissions to the location</span></span>**

    <span data-ttu-id="ce8a9-116">たとえば、これらの例のコードでは **picturesLibrary** 機能が必要ですが、場所によっては別の機能が必要であったり、機能をまったく必要としない場合もあります。</span><span class="sxs-lookup"><span data-stu-id="ce8a9-116">For example, the code in these examples require the **picturesLibrary** capability, but your location may require a different capability or no capability at all.</span></span> <span data-ttu-id="ce8a9-117">詳しくは、「[ファイル アクセス許可](file-access-permissions.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ce8a9-117">To learn more, see [File access permissions](file-access-permissions.md).</span></span>

## <a name="getting-a-files-top-level-properties"></a><span data-ttu-id="ce8a9-118">ファイルの最上位プロパティの取得</span><span class="sxs-lookup"><span data-stu-id="ce8a9-118">Getting a file's top-level properties</span></span>

<span data-ttu-id="ce8a9-119">多くの最上位ファイル プロパティは、[**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) クラスのメンバーとしてアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="ce8a9-119">Many top-level file properties are accessible as members of the [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) class.</span></span> <span data-ttu-id="ce8a9-120">これらのプロパティには、ファイル属性、コンテンツの種類、作成日、表示名、ファイルの種類などがあります。</span><span class="sxs-lookup"><span data-stu-id="ce8a9-120">These properties include the files attributes, content type, creation date, display name, file type, and so on.</span></span>

> [!NOTE]
> <span data-ttu-id="ce8a9-121">必ず **picturesLibrary** 機能を宣言してください。</span><span class="sxs-lookup"><span data-stu-id="ce8a9-121">Remember to declare the **picturesLibrary** capability.</span></span>

<span data-ttu-id="ce8a9-122">この例では、画像ライブラリ内のすべてのファイルを列挙して、各ファイルの最上位プロパティの一部にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="ce8a9-122">This example enumerates all of the files in the Pictures library, accessing a few of each file's top-level properties.</span></span>

```csharp
// Enumerate all files in the Pictures library.
var folder = Windows.Storage.KnownFolders.PicturesLibrary;
var query = folder.CreateFileQuery();
var files = await query.GetFilesAsync();

foreach (Windows.Storage.StorageFile file in files)
{
    StringBuilder fileProperties = new StringBuilder();

    // Get top-level file properties.
    fileProperties.AppendLine("File name: " + file.Name);
    fileProperties.AppendLine("File type: " + file.FileType);
}
```

## <a name="getting-a-files-basic-properties"></a><span data-ttu-id="ce8a9-123">ファイルの基本プロパティの取得</span><span class="sxs-lookup"><span data-stu-id="ce8a9-123">Getting a file's basic properties</span></span>

<span data-ttu-id="ce8a9-124">多くの基本ファイル プロパティは、最初に [**StorageFile.GetBasicPropertiesAsync**](https://msdn.microsoft.com/library/windows/apps/hh701737) メソッドを呼び出して取得します。</span><span class="sxs-lookup"><span data-stu-id="ce8a9-124">Many basic file properties are obtained by first calling the [**StorageFile.GetBasicPropertiesAsync**](https://msdn.microsoft.com/library/windows/apps/hh701737) method.</span></span> <span data-ttu-id="ce8a9-125">このメソッドは、項目 (ファイルまたはフォルダー) のサイズや最終変更日のプロパティを定義する [**BasicProperties**](https://msdn.microsoft.com/library/windows/apps/br212113) オブジェクトを返します。</span><span class="sxs-lookup"><span data-stu-id="ce8a9-125">This method returns a [**BasicProperties**](https://msdn.microsoft.com/library/windows/apps/br212113) object, which defines properties for the size of the item (file or folder) as well as when the item was last modified.</span></span>

<span data-ttu-id="ce8a9-126">この例では、画像ライブラリ内のすべてのファイルを列挙して、各ファイルの基本プロパティの一部にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="ce8a9-126">This example enumerates all of the files in the Pictures library, accessing a few of each file's basic properties.</span></span>

```csharp
// Enumerate all files in the Pictures library.
var folder = Windows.Storage.KnownFolders.PicturesLibrary;
var query = folder.CreateFileQuery();
var files = await query.GetFilesAsync();

foreach (Windows.Storage.StorageFile file in files)
{
    StringBuilder fileProperties = new StringBuilder();

    // Get file's basic properties.
    Windows.Storage.FileProperties.BasicProperties basicProperties =
        await file.GetBasicPropertiesAsync();
    string fileSize = string.Format("{0:n0}", basicProperties.Size);
    fileProperties.AppendLine("File size: " + fileSize + " bytes");
    fileProperties.AppendLine("Date modified: " + basicProperties.DateModified);
}
 ```

## <a name="getting-a-files-extended-properties"></a><span data-ttu-id="ce8a9-127">ファイルの拡張プロパティの取得</span><span class="sxs-lookup"><span data-stu-id="ce8a9-127">Getting a file's extended properties</span></span>

<span data-ttu-id="ce8a9-128">最上位と基本ファイル プロパティのほかに、ファイルの内容に関連付けられている多くのプロパティがあります。</span><span class="sxs-lookup"><span data-stu-id="ce8a9-128">Aside from the top-level and basic file properties, there are many properties associated with the file's contents.</span></span> <span data-ttu-id="ce8a9-129">これらの拡張プロパティは、[**BasicProperties.RetrievePropertiesAsync**](https://msdn.microsoft.com/library/windows/apps/br212124) メソッドを呼び出してアクセスします </span><span class="sxs-lookup"><span data-stu-id="ce8a9-129">These extended properties are accessed by calling the [**BasicProperties.RetrievePropertiesAsync**](https://msdn.microsoft.com/library/windows/apps/br212124) method.</span></span> <span data-ttu-id="ce8a9-130">([**BasicProperties**](https://msdn.microsoft.com/library/windows/apps/br212113) オブジェクトは、[**StorageFile.Properties**](https://msdn.microsoft.com/library/windows/apps/br227225) プロパティを呼び出して取得します)。最上位と基本ファイル プロパティは、クラス (それぞれ [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) と **BasicProperties**) のプロパティとしてアクセスできます。拡張プロパティは、取得するプロパティの名前を表す [String](https://go.microsoft.com/fwlink/p/?LinkID=325032) オブジェクトの [IEnumerable](https://go.microsoft.com/fwlink/p/?LinkID=313091) コレクションを **BasicProperties.RetrievePropertiesAsync** メソッドに渡して取得します。</span><span class="sxs-lookup"><span data-stu-id="ce8a9-130">(A [**BasicProperties**](https://msdn.microsoft.com/library/windows/apps/br212113) object is obtained by calling the [**StorageFile.Properties**](https://msdn.microsoft.com/library/windows/apps/br227225) property.) While top-level and basic file properties are accessible as properties of a class—[**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) and **BasicProperties**, respectively—extended properties are obtained by passing an [IEnumerable](https://go.microsoft.com/fwlink/p/?LinkID=313091) collection of [String](https://go.microsoft.com/fwlink/p/?LinkID=325032) objects representing the names of the properties that are to be retrieved to the **BasicProperties.RetrievePropertiesAsync** method.</span></span> <span data-ttu-id="ce8a9-131">このメソッドは、[IDictionary](https://go.microsoft.com/fwlink/p/?LinkId=325238) コレクションを返します。</span><span class="sxs-lookup"><span data-stu-id="ce8a9-131">This method then returns an [IDictionary](https://go.microsoft.com/fwlink/p/?LinkId=325238) collection.</span></span> <span data-ttu-id="ce8a9-132">各拡張プロパティは、コレクションから名前またはインデックスで取得します。</span><span class="sxs-lookup"><span data-stu-id="ce8a9-132">Each extended property is then retrieved from the collection by name or by index.</span></span>

<span data-ttu-id="ce8a9-133">この例では、画像ライブラリ内のすべてのファイルを列挙し、[List](https://go.microsoft.com/fwlink/p/?LinkID=325246) オブジェクトで目的のプロパティの名前 (**DataAccessed** と **FileOwner**) を指定して、その [List](https://go.microsoft.com/fwlink/p/?LinkID=325246) オブジェクトを [**BasicProperties.RetrievePropertiesAsync**](https://msdn.microsoft.com/library/windows/apps/br212124) に渡すことでそれらのプロパティを取得します。その後、返された [IDictionary](https://go.microsoft.com/fwlink/p/?LinkId=325238) オブジェクトから名前でそれらのプロパティを取得します。</span><span class="sxs-lookup"><span data-stu-id="ce8a9-133">This example enumerates all of the files in the Pictures library, specifies the names of desired properties (**DataAccessed** and **FileOwner**) in a [List](https://go.microsoft.com/fwlink/p/?LinkID=325246) object, passes that [List](https://go.microsoft.com/fwlink/p/?LinkID=325246) object to [**BasicProperties.RetrievePropertiesAsync**](https://msdn.microsoft.com/library/windows/apps/br212124) to retrieve those properties, and then retrieves those properties by name from the returned [IDictionary](https://go.microsoft.com/fwlink/p/?LinkId=325238) object.</span></span>

<span data-ttu-id="ce8a9-134">ファイルの拡張プロパティの完全な一覧については、「[Windows コア プロパティ](https://msdn.microsoft.com/library/windows/desktop/mt805470)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ce8a9-134">See the [Windows Core Properties](https://msdn.microsoft.com/library/windows/desktop/mt805470) for a complete list of a file's extended properties.</span></span>

```csharp
const string dateAccessedProperty = "System.DateAccessed";
const string fileOwnerProperty = "System.FileOwner";

// Enumerate all files in the Pictures library.
var folder = KnownFolders.PicturesLibrary;
var query = folder.CreateFileQuery();
var files = await query.GetFilesAsync();

foreach (Windows.Storage.StorageFile file in files)
{
    StringBuilder fileProperties = new StringBuilder();

    // Define property names to be retrieved.
    var propertyNames = new List<string>();
    propertyNames.Add(dateAccessedProperty);
    propertyNames.Add(fileOwnerProperty);

    // Get extended properties.
    IDictionary<string, object> extraProperties =
        await file.Properties.RetrievePropertiesAsync(propertyNames);

    // Get date-accessed property.
    var propValue = extraProperties[dateAccessedProperty];
    if (propValue != null)
    {
        fileProperties.AppendLine("Date accessed: " + propValue);
    }

    // Get file-owner property.
    propValue = extraProperties[fileOwnerProperty];
    if (propValue != null)
    {
        fileProperties.AppendLine("File owner: " + propValue);
    }
}
```

 

 
