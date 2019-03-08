---
ms.assetid: 3604524F-112A-474F-B0CA-0726DC8DB885
title: Microsoft OneDrive ファイルが利用可能かどうかの確認
description: StorageFile.IsAvailable プロパティを使って、Microsoft OneDrive ファイルが利用可能かどうかを確認します。
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 26eb371e767f0c1e7f3d5855cf68728958c0cda3
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57608937"
---
# <a name="determining-availability-of-microsoft-onedrive-files"></a><span data-ttu-id="d168d-104">Microsoft OneDrive ファイルが利用可能かどうかの確認</span><span class="sxs-lookup"><span data-stu-id="d168d-104">Determining availability of Microsoft OneDrive files</span></span>


<span data-ttu-id="d168d-105">**重要な API**</span><span class="sxs-lookup"><span data-stu-id="d168d-105">**Important APIs**</span></span>

-   [<span data-ttu-id="d168d-106">**FileIO クラス**</span><span class="sxs-lookup"><span data-stu-id="d168d-106">**FileIO class**</span></span>](https://msdn.microsoft.com/library/windows/apps/Hh701440)
-   [<span data-ttu-id="d168d-107">**StorageFile クラス**</span><span class="sxs-lookup"><span data-stu-id="d168d-107">**StorageFile class**</span></span>](https://msdn.microsoft.com/library/windows/apps/BR227171)
-   [<span data-ttu-id="d168d-108">**StorageFile.IsAvailable property**</span><span class="sxs-lookup"><span data-stu-id="d168d-108">**StorageFile.IsAvailable property**</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.storage.storagefile.isavailable.aspx)

<span data-ttu-id="d168d-109">[  **StorageFile.IsAvailable**](https://msdn.microsoft.com/library/windows/apps/windows.storage.storagefile.isavailable.aspx) プロパティを使って、Microsoft OneDrive ファイルが利用可能かどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="d168d-109">Determine if a Microsoft OneDrive file is available using the [**StorageFile.IsAvailable**](https://msdn.microsoft.com/library/windows/apps/windows.storage.storagefile.isavailable.aspx) property.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="d168d-110">前提条件</span><span class="sxs-lookup"><span data-stu-id="d168d-110">Prerequisites</span></span>

-   <span data-ttu-id="d168d-111">**ユニバーサル Windows プラットフォーム (UWP) アプリの非同期プログラミングを理解します。**</span><span class="sxs-lookup"><span data-stu-id="d168d-111">**Understand async programming for Universal Windows Platform (UWP) apps**</span></span>

    <span data-ttu-id="d168d-112">C# や Visual Basic での非同期アプリの作成方法については、「[C# または Visual Basic での非同期 API の呼び出し](https://msdn.microsoft.com/library/windows/apps/Mt187337)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d168d-112">You can learn how to write asynchronous apps in C# or Visual Basic, see [Call asynchronous APIs in C# or Visual Basic](https://msdn.microsoft.com/library/windows/apps/Mt187337).</span></span> <span data-ttu-id="d168d-113">C++ での非同期アプリの作成方法については、「[C++ での非同期プログラミング](https://msdn.microsoft.com/library/windows/apps/Mt187334)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d168d-113">To learn how to write asynchronous apps in C++, see [Asynchronous programming in C++](https://msdn.microsoft.com/library/windows/apps/Mt187334).</span></span>

-   <span data-ttu-id="d168d-114">**アプリの capabilty 宣言**</span><span class="sxs-lookup"><span data-stu-id="d168d-114">**App capabilty declarations**</span></span>

    <span data-ttu-id="d168d-115">「[ファイル アクセス許可](file-access-permissions.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d168d-115">See [File access permissions](file-access-permissions.md).</span></span>

## <a name="using-the-storagefileisavailable-property"></a><span data-ttu-id="d168d-116">StorageFile.IsAvailable プロパティの使用</span><span class="sxs-lookup"><span data-stu-id="d168d-116">Using the StorageFile.IsAvailable property</span></span>

<span data-ttu-id="d168d-117">ユーザーは、OneDrive ファイルを "オフラインで利用可能" (既定) または "オンラインのみ" とマークできます。</span><span class="sxs-lookup"><span data-stu-id="d168d-117">Users are able to mark OneDrive files as either available-offline (default) or online-only.</span></span> <span data-ttu-id="d168d-118">この機能を使うと、大容量のファイル (写真やビデオなど) を自分の OneDrive に移動し、オンラインのみとマークすることで、ディスク領域を節約できます (ローカルに保存されるのはメタデータ ファイルのみです)。</span><span class="sxs-lookup"><span data-stu-id="d168d-118">This capability enables users to move large files (such as pictures and videos) to their OneDrive, mark them as online-only, and save disk space (the only thing kept locally is a metadata file).</span></span>

<span data-ttu-id="d168d-119">[**StorageFile.IsAvailable**](https://msdn.microsoft.com/library/windows/apps/windows.storage.storagefile.isavailable.aspx)ファイルが現在使用できるかを判断するために使用します。</span><span class="sxs-lookup"><span data-stu-id="d168d-119">[**StorageFile.IsAvailable**](https://msdn.microsoft.com/library/windows/apps/windows.storage.storagefile.isavailable.aspx), is used to determine if a file is currently available.</span></span> <span data-ttu-id="d168d-120">次の表に、さまざまなシナリオでの **StorageFile.IsAvailable** プロパティの値を示します。</span><span class="sxs-lookup"><span data-stu-id="d168d-120">The following table shows the value of the **StorageFile.IsAvailable** property in various scenarios.</span></span>

| <span data-ttu-id="d168d-121">ファイルの種類</span><span class="sxs-lookup"><span data-stu-id="d168d-121">Type of file</span></span>                              | <span data-ttu-id="d168d-122">オンライン</span><span class="sxs-lookup"><span data-stu-id="d168d-122">Online</span></span> | <span data-ttu-id="d168d-123">従量制課金接続</span><span class="sxs-lookup"><span data-stu-id="d168d-123">Metered network</span></span>        | <span data-ttu-id="d168d-124">オフライン</span><span class="sxs-lookup"><span data-stu-id="d168d-124">Offline</span></span> |
|-------------------------------------------|--------|------------------------|---------|
| <span data-ttu-id="d168d-125">ローカル ファイル</span><span class="sxs-lookup"><span data-stu-id="d168d-125">Local file</span></span>                                | <span data-ttu-id="d168d-126">True</span><span class="sxs-lookup"><span data-stu-id="d168d-126">True</span></span>   | <span data-ttu-id="d168d-127">True</span><span class="sxs-lookup"><span data-stu-id="d168d-127">True</span></span>                   | <span data-ttu-id="d168d-128">True</span><span class="sxs-lookup"><span data-stu-id="d168d-128">True</span></span>    |
| <span data-ttu-id="d168d-129">オフラインで利用可能とマークされている OneDrive ファイル</span><span class="sxs-lookup"><span data-stu-id="d168d-129">OneDrive file marked as available-offline</span></span> | <span data-ttu-id="d168d-130">True</span><span class="sxs-lookup"><span data-stu-id="d168d-130">True</span></span>   | <span data-ttu-id="d168d-131">True</span><span class="sxs-lookup"><span data-stu-id="d168d-131">True</span></span>                   | <span data-ttu-id="d168d-132">True</span><span class="sxs-lookup"><span data-stu-id="d168d-132">True</span></span>    |
| <span data-ttu-id="d168d-133">オンラインのみとマークされている OneDrive ファイル</span><span class="sxs-lookup"><span data-stu-id="d168d-133">OneDrive file marked as online-only</span></span>       | <span data-ttu-id="d168d-134">True</span><span class="sxs-lookup"><span data-stu-id="d168d-134">True</span></span>   | <span data-ttu-id="d168d-135">ユーザー設定に基づく</span><span class="sxs-lookup"><span data-stu-id="d168d-135">Based on user settings</span></span> | <span data-ttu-id="d168d-136">False</span><span class="sxs-lookup"><span data-stu-id="d168d-136">False</span></span>   |
| <span data-ttu-id="d168d-137">ネットワーク ファイル</span><span class="sxs-lookup"><span data-stu-id="d168d-137">Network file</span></span>                              | <span data-ttu-id="d168d-138">True</span><span class="sxs-lookup"><span data-stu-id="d168d-138">True</span></span>   | <span data-ttu-id="d168d-139">ユーザー設定に基づく</span><span class="sxs-lookup"><span data-stu-id="d168d-139">Based on user settings</span></span> | <span data-ttu-id="d168d-140">False</span><span class="sxs-lookup"><span data-stu-id="d168d-140">False</span></span>   |

 

<span data-ttu-id="d168d-141">次の手順では、ファイルが現在利用できるかどうかを判別する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="d168d-141">The following steps illustrate how to determine if a file is currently available.</span></span>

1.  <span data-ttu-id="d168d-142">アクセスするライブラリに適した機能を宣言します。</span><span class="sxs-lookup"><span data-stu-id="d168d-142">Declare a capability appropriate for the library you want to access.</span></span>
2.  <span data-ttu-id="d168d-143">[  **Windows.Storage**](https://msdn.microsoft.com/library/windows/apps/BR227346) 名前空間を含めます。</span><span class="sxs-lookup"><span data-stu-id="d168d-143">Include the [**Windows.Storage**](https://msdn.microsoft.com/library/windows/apps/BR227346) namespace.</span></span> <span data-ttu-id="d168d-144">この名前空間には、ファイル、フォルダー、アプリケーション設定を管理するための型が含まれています。</span><span class="sxs-lookup"><span data-stu-id="d168d-144">This namespace includes the types for managing files, folders, and application settings.</span></span> <span data-ttu-id="d168d-145">また、必要な [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/BR227171) 型も含まれています。</span><span class="sxs-lookup"><span data-stu-id="d168d-145">It also includes the needed [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/BR227171) type.</span></span>
3.  <span data-ttu-id="d168d-146">必要なファイルの [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/BR227171) オブジェクトを取得します。</span><span class="sxs-lookup"><span data-stu-id="d168d-146">Acquire a [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/BR227171) object for the desired file(s).</span></span> <span data-ttu-id="d168d-147">ライブラリを列挙する場合、通常、この手順は [**StorageFolder.CreateFileQuery**](https://msdn.microsoft.com/library/windows/apps/BR227252) メソッドを呼び出し、結果の [**StorageFileQueryResult**](https://msdn.microsoft.com/library/windows/apps/BR208046) オブジェクトの [**GetFilesAsync**](https://msdn.microsoft.com/library/windows/apps/br227276.aspx) メソッドを呼び出して行います。</span><span class="sxs-lookup"><span data-stu-id="d168d-147">If you are enumerating a library, this step is usually accomplished by calling the [**StorageFolder.CreateFileQuery**](https://msdn.microsoft.com/library/windows/apps/BR227252) method and then calling the resulting [**StorageFileQueryResult**](https://msdn.microsoft.com/library/windows/apps/BR208046) object's [**GetFilesAsync**](https://msdn.microsoft.com/library/windows/apps/br227276.aspx) method.</span></span> <span data-ttu-id="d168d-148">**GetFilesAsync** メソッドは、**StorageFile** オブジェクトの [IReadOnlyList](https://go.microsoft.com/fwlink/p/?LinkId=324970) コレクションを返します。</span><span class="sxs-lookup"><span data-stu-id="d168d-148">The **GetFilesAsync** method returns an [IReadOnlyList](https://go.microsoft.com/fwlink/p/?LinkId=324970) collection of **StorageFile** objects.</span></span>
4.  <span data-ttu-id="d168d-149">目的のファイルを表す [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/BR227171) オブジェクトにアクセスできるようになると、[**StorageFile.IsAvailable**](https://msdn.microsoft.com/library/windows/apps/windows.storage.storagefile.isavailable.aspx) プロパティの値は、ファイルが利用できるかどうかを表します。</span><span class="sxs-lookup"><span data-stu-id="d168d-149">Once you have the access to a [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/BR227171) object representing the desired file(s), the value of the [**StorageFile.IsAvailable**](https://msdn.microsoft.com/library/windows/apps/windows.storage.storagefile.isavailable.aspx) property reflects whether or not the file is available.</span></span>

<span data-ttu-id="d168d-150">次の汎用的なメソッドは、フォルダーを列挙し、そのフォルダーの [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/BR227171) オブジェクトのコレクションを返す方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="d168d-150">The following generic method illustrates how to enumerate any folder and return the collection of [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/BR227171) objects for that folder.</span></span> <span data-ttu-id="d168d-151">その後、呼び出し元メソッドで、各ファイルの [**StorageFile.IsAvailable**](https://msdn.microsoft.com/library/windows/apps/windows.storage.storagefile.isavailable.aspx) プロパティを参照する返されたコレクションを反復処理します。</span><span class="sxs-lookup"><span data-stu-id="d168d-151">The calling method then iterates over the returned collection referencing the [**StorageFile.IsAvailable**](https://msdn.microsoft.com/library/windows/apps/windows.storage.storagefile.isavailable.aspx) property for each file.</span></span>

```cs
/// <summary>
/// Generic function that retrieves all files from the specified folder.
/// </summary>
/// <param name="folder">The folder to be searched.</param>
/// <returns>An IReadOnlyList collection containing the file objects.</returns>
async Task<System.Collections.Generic.IReadOnlyList<StorageFile>> GetLibraryFilesAsync(StorageFolder folder)
{
    var query = folder.CreateFileQuery();
    return await query.GetFilesAsync();
}

private async void CheckAvailabilityOfFilesInPicturesLibrary()
{
    // Determine availability of all files within Pictures library.
    var files = await GetLibraryFilesAsync(KnownFolders.PicturesLibrary);
    for (int i = 0; i < files.Count; i++)
    {
        StorageFile file = files[i];

        StringBuilder fileInfo = new StringBuilder();
        fileInfo.AppendFormat("{0} (on {1}) is {2}",
                    file.Name,
                    file.Provider.DisplayName,
                    file.IsAvailable ? "available" : "not available");
    }
}
```
