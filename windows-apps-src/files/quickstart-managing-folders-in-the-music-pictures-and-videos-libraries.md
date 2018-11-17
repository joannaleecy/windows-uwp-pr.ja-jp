---
author: laurenhughes
ms.assetid: 1AE29512-7A7D-4179-ADAC-F02819AC2C39
title: ミュージック、画像、およびビデオ ライブラリのファイルとフォルダー
description: 音楽、画像、またはビデオの既存のフォルダーを対応するライブラリに追加できます。 ライブラリからフォルダーを削除したり、ライブラリ内のフォルダーの一覧を取得したり、保存した写真、音楽、ビデオにアクセスしたりすることもできます。
ms.author: lahugh
ms.date: 06/18/2018
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 1859d758806b4e92758decb40b8a30d02acb254d
ms.sourcegitcommit: 3257416aebb5a7b1515e107866806f8bd57845a8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/17/2018
ms.locfileid: "7159079"
---
# <a name="files-and-folders-in-the-music-pictures-and-videos-libraries"></a><span data-ttu-id="38516-105">ミュージック、画像、およびビデオ ライブラリのファイルとフォルダー</span><span class="sxs-lookup"><span data-stu-id="38516-105">Files and folders in the Music, Pictures, and Videos libraries</span></span>

<span data-ttu-id="38516-106">音楽、画像、またはビデオの既存のフォルダーを対応するライブラリに追加できます。</span><span class="sxs-lookup"><span data-stu-id="38516-106">Add existing folders of music, pictures, or videos to the corresponding libraries.</span></span> <span data-ttu-id="38516-107">ライブラリからフォルダーを削除したり、ライブラリ内のフォルダーの一覧を取得したり、保存した写真、音楽、ビデオにアクセスしたりすることもできます。</span><span class="sxs-lookup"><span data-stu-id="38516-107">You can also remove folders from libraries, get the list of folders in a library, and discover stored photos, music, and videos.</span></span>

<span data-ttu-id="38516-108">ライブラリは、フォルダーの仮想コレクションです。既定で含まれている既知のフォルダーに加えて、ユーザーがアプリや組み込みのアプリのいずれかを使ってライブラリに追加した他のフォルダーが含まれています。</span><span class="sxs-lookup"><span data-stu-id="38516-108">A library is a virtual collection of folders, which includes a known folder by default plus any other folders the user has added to the library by using your app or one of the built-in apps.</span></span> <span data-ttu-id="38516-109">たとえば、画像ライブラリには、既定で画像の既知のフォルダーが含まれています。</span><span class="sxs-lookup"><span data-stu-id="38516-109">For example, the Pictures library includes the Pictures known folder by default.</span></span> <span data-ttu-id="38516-110">ユーザーは、アプリや組み込みのフォト アプリを使って、画像ライブラリに対してフォルダーの追加や削除を行うことができます。</span><span class="sxs-lookup"><span data-stu-id="38516-110">The user can add folders to, or remove them from, the Pictures library by using your app or the built-in Photos app.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="38516-111">前提条件</span><span class="sxs-lookup"><span data-stu-id="38516-111">Prerequisites</span></span>


-   **<span data-ttu-id="38516-112">ユニバーサル Windows プラットフォーム (UWP) アプリの非同期プログラミングについての理解</span><span class="sxs-lookup"><span data-stu-id="38516-112">Understand async programming for Universal Windows Platform (UWP) apps</span></span>**

    <span data-ttu-id="38516-113">C# や Visual Basic での非同期アプリの作成方法については、「[C# または Visual Basic での非同期 API の呼び出し](https://msdn.microsoft.com/library/windows/apps/mt187337)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="38516-113">You can learn how to write asynchronous apps in C# or Visual Basic, see [Call asynchronous APIs in C# or Visual Basic](https://msdn.microsoft.com/library/windows/apps/mt187337).</span></span> <span data-ttu-id="38516-114">C++ での非同期アプリの作成方法については、「[C++ での非同期プログラミング](https://msdn.microsoft.com/library/windows/apps/mt187334)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="38516-114">To learn how to write asynchronous apps in C++, see [Asynchronous programming in C++](https://msdn.microsoft.com/library/windows/apps/mt187334).</span></span>

-   **<span data-ttu-id="38516-115">場所へのアクセス許可</span><span class="sxs-lookup"><span data-stu-id="38516-115">Access permissions to the location</span></span>**

    <span data-ttu-id="38516-116">Visual Studio のマニフェスト デザイナーで、アプリ マニフェスト ファイルを開きます。</span><span class="sxs-lookup"><span data-stu-id="38516-116">In Visual Studio, open the app manifest file in Manifest Designer.</span></span> <span data-ttu-id="38516-117">**[機能]** ページで、アプリで管理するライブラリを選択します。</span><span class="sxs-lookup"><span data-stu-id="38516-117">On the **Capabilities** page, select the libraries that your app manages.</span></span>

    -   **<span data-ttu-id="38516-118">音楽ライブラリ</span><span class="sxs-lookup"><span data-stu-id="38516-118">Music Library</span></span>**
    -   **<span data-ttu-id="38516-119">画像ライブラリ</span><span class="sxs-lookup"><span data-stu-id="38516-119">Pictures Library</span></span>**
    -   **<span data-ttu-id="38516-120">ビデオ ライブラリ</span><span class="sxs-lookup"><span data-stu-id="38516-120">Videos Library</span></span>**

    <span data-ttu-id="38516-121">詳しくは、「[ファイル アクセス許可](file-access-permissions.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="38516-121">To learn more, see [File access permissions](file-access-permissions.md).</span></span>

## <a name="get-a-reference-to-a-library"></a><span data-ttu-id="38516-122">ライブラリへの参照を取得する</span><span class="sxs-lookup"><span data-stu-id="38516-122">Get a reference to a library</span></span>

> [!NOTE]
> <span data-ttu-id="38516-123">必ず適切な機能を宣言してください。</span><span class="sxs-lookup"><span data-stu-id="38516-123">Remember to declare the appropriate capability.</span></span> <span data-ttu-id="38516-124">詳しくは、「[アプリ機能の宣言](https://docs.microsoft.com/windows/uwp/packaging/app-capability-declarations)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="38516-124">See [App capability declarations](https://docs.microsoft.com/windows/uwp/packaging/app-capability-declarations) for more information.</span></span>
 

<span data-ttu-id="38516-125">ユーザーの音楽、画像、またはビデオ ライブラリへの参照を取得するには、[**StorageLibrary.GetLibraryAsync**](https://msdn.microsoft.com/library/windows/apps/dn251725) メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="38516-125">To get a reference to the user's Music, Pictures, or Video library, call the [**StorageLibrary.GetLibraryAsync**](https://msdn.microsoft.com/library/windows/apps/dn251725) method.</span></span> <span data-ttu-id="38516-126">[**KnownLibraryId**](https://msdn.microsoft.com/library/windows/apps/dn298399) 列挙体の対応する値を指定します。</span><span class="sxs-lookup"><span data-stu-id="38516-126">Provide the corresponding value from the [**KnownLibraryId**](https://msdn.microsoft.com/library/windows/apps/dn298399) enumeration.</span></span>

-   [**<span data-ttu-id="38516-127">KnownLibraryId.Music</span><span class="sxs-lookup"><span data-stu-id="38516-127">KnownLibraryId.Music</span></span>**](https://msdn.microsoft.com/library/windows/apps/br227155)
-   [**<span data-ttu-id="38516-128">KnownLibraryId.Pictures</span><span class="sxs-lookup"><span data-stu-id="38516-128">KnownLibraryId.Pictures</span></span>**](https://msdn.microsoft.com/library/windows/apps/br227156)
-   [**<span data-ttu-id="38516-129">KnownLibraryId.Videos</span><span class="sxs-lookup"><span data-stu-id="38516-129">KnownLibraryId.Videos</span></span>**](https://msdn.microsoft.com/library/windows/apps/br227159)

```cs
var myPictures = await Windows.Storage.StorageLibrary.GetLibraryAsync(Windows.Storage.KnownLibraryId.Pictures);
```

## <a name="get-the-list-of-folders-in-a-library"></a><span data-ttu-id="38516-130">ライブラリ内のフォルダーの一覧を取得する</span><span class="sxs-lookup"><span data-stu-id="38516-130">Get the list of folders in a library</span></span>


<span data-ttu-id="38516-131">ライブラリ内のフォルダーの一覧を取得するには、[**StorageLibrary.Folders**](https://msdn.microsoft.com/library/windows/apps/dn251724) プロパティの値を取得します。</span><span class="sxs-lookup"><span data-stu-id="38516-131">To get the list of folders in a library, get the value of the [**StorageLibrary.Folders**](https://msdn.microsoft.com/library/windows/apps/dn251724) property.</span></span>

```cs
using Windows.Foundation.Collections;
IObservableVector<Windows.Storage.StorageFolder> myPictureFolders = myPictures.Folders;
```

## <a name="get-the-folder-in-a-library-where-new-files-are-saved-by-default"></a><span data-ttu-id="38516-132">新しいファイルが既定で保存されるライブラリのフォルダーを取得する</span><span class="sxs-lookup"><span data-stu-id="38516-132">Get the folder in a library where new files are saved by default</span></span>


<span data-ttu-id="38516-133">新しいファイルが既定で保存されるライブラリのフォルダーを取得するには、[**StorageLibrary.SaveFolder**](https://msdn.microsoft.com/library/windows/apps/dn251728) プロパティの値を取得します。</span><span class="sxs-lookup"><span data-stu-id="38516-133">To get the folder in a library where new files are saved by default, get the value of the [**StorageLibrary.SaveFolder**](https://msdn.microsoft.com/library/windows/apps/dn251728) property.</span></span>

```cs
Windows.Storage.StorageFolder savePicturesFolder = myPictures.SaveFolder;
```

## <a name="add-an-existing-folder-to-a-library"></a><span data-ttu-id="38516-134">ライブラリに既存のフォルダーを追加する</span><span class="sxs-lookup"><span data-stu-id="38516-134">Add an existing folder to a library</span></span>

<span data-ttu-id="38516-135">ライブラリにフォルダーを追加するには、[**StorageLibrary.RequestAddFolderAsync**](https://msdn.microsoft.com/library/windows/apps/dn251726) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="38516-135">To add a folder to a library, you call the [**StorageLibrary.RequestAddFolderAsync**](https://msdn.microsoft.com/library/windows/apps/dn251726).</span></span> <span data-ttu-id="38516-136">画像ライブラリを例として考えた場合、このメソッドを呼び出すとフォルダー ピッカーが **[ピクチャにこのフォルダーを追加]** ボタンと共に表示されます。</span><span class="sxs-lookup"><span data-stu-id="38516-136">Taking the Pictures Library as an example, calling this method causes a folder picker to be shown to the user with an **Add this folder to Pictures** button.</span></span> <span data-ttu-id="38516-137">ユーザーがフォルダーを選ぶと、フォルダーはディスク上の元の場所に残り、[**StorageLibrary.Folders**](https://msdn.microsoft.com/library/windows/apps/dn251724) プロパティ (および組み込みのフォト アプリ) 内の項目となりますが、フォルダーはエクスプローラーでピクチャ フォルダーの子として表示されません。</span><span class="sxs-lookup"><span data-stu-id="38516-137">If the user picks a folder then the folder remains in its original location on disk and it becomes an item in the [**StorageLibrary.Folders**](https://msdn.microsoft.com/library/windows/apps/dn251724) property (and in the built-in Photos app), but the folder does not appear as a child of the Pictures folder in File Explorer.</span></span>


```cs
Windows.Storage.StorageFolder newFolder = await myPictures.RequestAddFolderAsync();
```

## <a name="remove-a-folder-from-a-library"></a><span data-ttu-id="38516-138">フォルダーをライブラリから削除する</span><span class="sxs-lookup"><span data-stu-id="38516-138">Remove a folder from a library</span></span>

<span data-ttu-id="38516-139">フォルダーをライブラリから削除するには、[**StorageLibrary.RequestRemoveFolderAsync**](https://msdn.microsoft.com/library/windows/apps/dn251727) メソッドを呼び出して、削除するフォルダーを指定します。</span><span class="sxs-lookup"><span data-stu-id="38516-139">To remove a folder from a library, call the [**StorageLibrary.RequestRemoveFolderAsync**](https://msdn.microsoft.com/library/windows/apps/dn251727) method and specify the folder to be removed.</span></span> <span data-ttu-id="38516-140">[**StorageLibrary.Folders**](https://msdn.microsoft.com/library/windows/apps/dn251724) と [**ListView**](https://msdn.microsoft.com/library/windows/apps/br242878) コントロール (または同様のコントロール) を使って、ユーザーが削除するフォルダーを選べるようにすることができます。</span><span class="sxs-lookup"><span data-stu-id="38516-140">You could use [**StorageLibrary.Folders**](https://msdn.microsoft.com/library/windows/apps/dn251724) and a [**ListView**](https://msdn.microsoft.com/library/windows/apps/br242878) control (or similar) for the user to select a folder to remove.</span></span>

<span data-ttu-id="38516-141">[**StorageLibrary.RequestRemoveFolderAsync**](https://msdn.microsoft.com/library/windows/apps/dn251727) を呼び出すと、フォルダーが "ピクチャに表示されなくなるが、削除されない" ことを示す確認ダイアログがユーザーに表示されます。</span><span class="sxs-lookup"><span data-stu-id="38516-141">When you call [**StorageLibrary.RequestRemoveFolderAsync**](https://msdn.microsoft.com/library/windows/apps/dn251727), the user sees a confirmation dialog saying that the folder "won't appear in Pictures anymore, but won't be deleted."</span></span> <span data-ttu-id="38516-142">これは、フォルダーがディスク上の元の場所に残るが、[**StorageLibrary.Folders**](https://msdn.microsoft.com/library/windows/apps/dn251724) プロパティから削除され、組み込みのフォト アプリには含まれなくなることを意味します。</span><span class="sxs-lookup"><span data-stu-id="38516-142">What this means is that the folder remains in its original location on disk, is removed from the [**StorageLibrary.Folders**](https://msdn.microsoft.com/library/windows/apps/dn251724) property, and will no longer included in the built-in Photos app.</span></span>

<span data-ttu-id="38516-143">次の例では、ユーザーが削除するフォルダーを **lvPictureFolders** という名前の [**ListView**](https://msdn.microsoft.com/library/windows/apps/br242878) コントロールから選んだことを前提としています。</span><span class="sxs-lookup"><span data-stu-id="38516-143">The following example assumes that the user has selected the folder to remove from a [**ListView**](https://msdn.microsoft.com/library/windows/apps/br242878) control named **lvPictureFolders**.</span></span>


```cs
bool result = await myPictures.RequestRemoveFolderAsync(folder);
```

## <a name="get-notified-of-changes-to-the-list-of-folders-in-a-library"></a><span data-ttu-id="38516-144">ライブラリ内のフォルダーの一覧に対する変更の通知を受け取る</span><span class="sxs-lookup"><span data-stu-id="38516-144">Get notified of changes to the list of folders in a library</span></span>


<span data-ttu-id="38516-145">ライブラリ内のフォルダーの一覧に対する変更について通知を受け取るには、ライブラリの [**StorageLibrary.DefinitionChanged**](https://msdn.microsoft.com/library/windows/apps/dn251723) イベントにハンドラーを登録します。</span><span class="sxs-lookup"><span data-stu-id="38516-145">To get notified about changes to the list of folders in a library, register a handler for the [**StorageLibrary.DefinitionChanged**](https://msdn.microsoft.com/library/windows/apps/dn251723) event of the library.</span></span>


```cs
myPictures.DefinitionChanged += MyPictures_DefinitionChanged;

void HandleDefinitionChanged(Windows.Storage.StorageLibrary sender, object args)
{
    // ...
}
```

## <a name="media-library-folders"></a><span data-ttu-id="38516-146">メディア ライブラリ フォルダー</span><span class="sxs-lookup"><span data-stu-id="38516-146">Media library folders</span></span>


<span data-ttu-id="38516-147">デバイスには、ユーザーやアプリがメディア ファイルを格納するための定義済みの場所が 5 つ用意されています。</span><span class="sxs-lookup"><span data-stu-id="38516-147">A device provides five predefined locations for users and apps to store media files.</span></span> <span data-ttu-id="38516-148">組み込みのアプリでは、ユーザーが作成したメディアとダウンロードしたメディアをこれらの場所に格納できます。</span><span class="sxs-lookup"><span data-stu-id="38516-148">Built-in apps store both user-created media and downloaded media in these locations.</span></span>

<span data-ttu-id="38516-149">次の場所が定義されています。</span><span class="sxs-lookup"><span data-stu-id="38516-149">The locations are:</span></span>

-   <span data-ttu-id="38516-150">**ピクチャ** フォルダー。</span><span class="sxs-lookup"><span data-stu-id="38516-150">**Pictures** folder.</span></span> <span data-ttu-id="38516-151">画像が格納されます。</span><span class="sxs-lookup"><span data-stu-id="38516-151">Contains pictures.</span></span>

    -   <span data-ttu-id="38516-152">**カメラ ロール** フォルダー。</span><span class="sxs-lookup"><span data-stu-id="38516-152">**Camera Roll** folder.</span></span> <span data-ttu-id="38516-153">組み込みのカメラからの写真やビデオが格納されます。</span><span class="sxs-lookup"><span data-stu-id="38516-153">Contains photos and video from the built-in camera.</span></span>

    -   <span data-ttu-id="38516-154">**保存済みの写真**フォルダー。</span><span class="sxs-lookup"><span data-stu-id="38516-154">**Saved Pictures** folder.</span></span> <span data-ttu-id="38516-155">ユーザーが他のアプリから保存した画像が格納されます。</span><span class="sxs-lookup"><span data-stu-id="38516-155">Contains pictures that the user has saved from other apps.</span></span>

-   <span data-ttu-id="38516-156">**ミュージック** フォルダー。</span><span class="sxs-lookup"><span data-stu-id="38516-156">**Music** folder.</span></span> <span data-ttu-id="38516-157">楽曲、ポッドキャスト、オーディオ ブックが格納されます。</span><span class="sxs-lookup"><span data-stu-id="38516-157">Contains songs, podcasts, and audio books.</span></span>

-   <span data-ttu-id="38516-158">**ビデオ** フォルダー。</span><span class="sxs-lookup"><span data-stu-id="38516-158">**Video** folder.</span></span> <span data-ttu-id="38516-159">ビデオが格納されます。</span><span class="sxs-lookup"><span data-stu-id="38516-159">Contains videos.</span></span>

<span data-ttu-id="38516-160">ユーザーやアプリは、メディア ライブラリ フォルダーだけではなく、SD カード上にメディア ファイルを保存することもできます。</span><span class="sxs-lookup"><span data-stu-id="38516-160">Users or apps may also store media files outside the media library folders on the SD card.</span></span> <span data-ttu-id="38516-161">SD カード上のメディア ファイルを確実に検索するには、SD カードのコンテンツをスキャンするか、ファイル ピッカーを使ってファイルを検索するようにユーザーに対して要求します。</span><span class="sxs-lookup"><span data-stu-id="38516-161">To find a media file reliably on the SD card, scan the contents of the SD card, or ask the user to locate the file by using a file picker.</span></span> <span data-ttu-id="38516-162">詳しくは、「[SD カードへのアクセス](access-the-sd-card.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="38516-162">For more info, see [Access the SD card](access-the-sd-card.md).</span></span>

## <a name="querying-the-media-libraries"></a><span data-ttu-id="38516-163">メディア ライブラリへの照会</span><span class="sxs-lookup"><span data-stu-id="38516-163">Querying the media libraries</span></span>

<span data-ttu-id="38516-164">ファイルのコレクションを取得するには、ライブラリと必要なファイルの種類を指定します。</span><span class="sxs-lookup"><span data-stu-id="38516-164">To get a collection of files, specify the library and the type of files that you want.</span></span>

```cs
using Windows.Storage;
using Windows.Storage.Search;

private async void getSongs()
{
    QueryOptions queryOption = new QueryOptions
        (CommonFileQuery.OrderByTitle, new string[] { ".mp3", ".mp4", ".wma" });

    queryOption.FolderDepth = FolderDepth.Deep;

    Queue<IStorageFolder> folders = new Queue<IStorageFolder>();

    var files = await KnownFolders.MusicLibrary.CreateFileQueryWithOptions
      (queryOption).GetFilesAsync();

    foreach (var file in files)
    {
        // do something with the music files
    }
}
```

### <a name="query-results-include-both-internal-and-removable-storage"></a><span data-ttu-id="38516-165">内部ストレージとリムーバブル ストレージの両方が含まれるクエリ結果</span><span class="sxs-lookup"><span data-stu-id="38516-165">Query results include both internal and removable storage</span></span>

<span data-ttu-id="38516-166">ユーザーは、既定でオプションの SD カードにファイルを格納するように選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="38516-166">Users can choose to store files by default on the optional SD card.</span></span> <span data-ttu-id="38516-167">また、アプリでは、ファイルが SD カードに格納されないようにすることができます。</span><span class="sxs-lookup"><span data-stu-id="38516-167">Apps, however, can opt out of allowing files to be stored on the SD card.</span></span> <span data-ttu-id="38516-168">その結果、メディア ライブラリがデバイスの内部ストレージと SD カードの両方に存在する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="38516-168">As a result, the media libraries can be split across the device's internal storage and the SD card.</span></span>

<span data-ttu-id="38516-169">この状況を処理するために追加のコードを記述する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="38516-169">You don't have to write additional code to handle this possibility.</span></span> <span data-ttu-id="38516-170">既知のフォルダーを照会する [**Windows.Storage**](https://msdn.microsoft.com/library/windows/apps/br227346) 名前空間のメソッドが、両方の場所からのクエリ結果を透過的に結合します。</span><span class="sxs-lookup"><span data-stu-id="38516-170">The methods in the [**Windows.Storage**](https://msdn.microsoft.com/library/windows/apps/br227346) namespace that query known folders transparently combine the query results from both locations.</span></span> <span data-ttu-id="38516-171">結合された結果を取得するために、アプリ マニフェスト ファイルで **removableStorage** 機能を指定する必要もありません。</span><span class="sxs-lookup"><span data-stu-id="38516-171">You don't have to specify the **removableStorage** capability in the app manifest file to get these combined results, either.</span></span>

<span data-ttu-id="38516-172">次の図に示すデバイスのストレージの状態について考えてみましょう。</span><span class="sxs-lookup"><span data-stu-id="38516-172">Consider the state of the device's storage shown in the following image:</span></span>

![電話と SD カード上にある画像](images/phone-media-locations.png)

<span data-ttu-id="38516-174">`await KnownFolders.PicturesLibrary.GetFilesAsync()`を呼び出して、画像ライブラリのコンテンツを照会すると、その結果には internalPic.jpg と SDPic.jpg の両方が含まれます。</span><span class="sxs-lookup"><span data-stu-id="38516-174">If you query the contents of the Pictures Library by calling `await KnownFolders.PicturesLibrary.GetFilesAsync()`, the results include both internalPic.jpg and SDPic.jpg.</span></span>


## <a name="working-with-photos"></a><span data-ttu-id="38516-175">写真の操作</span><span class="sxs-lookup"><span data-stu-id="38516-175">Working with photos</span></span>

<span data-ttu-id="38516-176">すべての画像について低解像度の画像と高解像度の画像の両方を保存するカメラ機能を備えたデバイスでは、深いクエリからは低解像度の画像のみが返されます。</span><span class="sxs-lookup"><span data-stu-id="38516-176">On devices where the camera saves both a low-resolution image and a high-resolution image of every picture, the deep queries return only the low-resolution image.</span></span>

<span data-ttu-id="38516-177">[カメラ ロール] フォルダーと [保存済みの写真] フォルダーでは、深いクエリがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="38516-177">The Camera Roll and the Saved Pictures folder do not support the deep queries.</span></span>

**<span data-ttu-id="38516-178">撮影に使ったアプリで写真を開く</span><span class="sxs-lookup"><span data-stu-id="38516-178">Opening a photo in the app that captured it</span></span>**

<span data-ttu-id="38516-179">ユーザーが撮影に使ったアプリで後から再び写真を表示できるようにするには、写真のメタデータと一緒に **CreatorAppId** を保存します。次のコード例を参考にしてください。</span><span class="sxs-lookup"><span data-stu-id="38516-179">If you want to let the user open a photo again later in the app that captured it, you can save the **CreatorAppId** with the photo's metadata by using code similar to the following example.</span></span> <span data-ttu-id="38516-180">この例では、**testPhoto** は [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) です。</span><span class="sxs-lookup"><span data-stu-id="38516-180">In this example, **testPhoto** is a [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171).</span></span>

```cs
IDictionary<string, object> propertiesToSave = new Dictionary<string, object>();

propertiesToSave.Add("System.CreatorOpenWithUIOptions", 1);
propertiesToSave.Add("System.CreatorAppId", appId);

testPhoto.Properties.SavePropertiesAsync(propertiesToSave).AsyncWait();   
```

## <a name="using-stream-methods-to-add-a-file-to-a-media-library"></a><span data-ttu-id="38516-181">ストリーム メソッドを使ってメディア ライブラリにファイルを追加する</span><span class="sxs-lookup"><span data-stu-id="38516-181">Using stream methods to add a file to a media library</span></span>

<span data-ttu-id="38516-182">**KnownFolders.PictureLibrary** など、既知のフォルダーを使ってメディア ライブラリにアクセスし、ストリーム メソッドを使ってそのメディア ライブラリにファイルを追加するときは、コードで開いているすべてのストリームを閉じる必要があります。</span><span class="sxs-lookup"><span data-stu-id="38516-182">When you access a media library by using a known folder such as **KnownFolders.PictureLibrary**, and you use stream methods to add a file to the media library, you have to make sure to close all the streams that your code opens.</span></span> <span data-ttu-id="38516-183">そのようにしなかった場合、ファイルへのハンドルを保持しているストリームが少なくとも 1 つは存在することとなり、ストリーム メソッドは、メディア ライブラリに正しくファイルを追加できません。</span><span class="sxs-lookup"><span data-stu-id="38516-183">Otherwise these methods fail to add the file to the media library as expected because at least one stream still has a handle to the file.</span></span>

<span data-ttu-id="38516-184">たとえば、以下のコードを実行したときに、メディア ライブラリにファイルが追加されません。</span><span class="sxs-lookup"><span data-stu-id="38516-184">For example, when you run the following code, the file is not added to the media library.</span></span> <span data-ttu-id="38516-185">`using (var destinationStream = (await destinationFile.OpenAsync(FileAccessMode.ReadWrite)).GetOutputStreamAt(0))` のコード行において、**OpenAsync** メソッドと **GetOutputStreamAt** メソッドの両方がストリームを開いています。</span><span class="sxs-lookup"><span data-stu-id="38516-185">In the line of code, `using (var destinationStream = (await destinationFile.OpenAsync(FileAccessMode.ReadWrite)).GetOutputStreamAt(0))`, both the **OpenAsync** method and the **GetOutputStreamAt** method open a stream.</span></span> <span data-ttu-id="38516-186">しかし、**using** ステートメントの結果として破棄されるのは、**GetOutputStreamAt** メソッドによって開かれたストリームだけです。</span><span class="sxs-lookup"><span data-stu-id="38516-186">However only the stream opened by the **GetOutputStreamAt** method is disposed as a result of the **using** statement.</span></span> <span data-ttu-id="38516-187">もう一方のストリームは開いたままであり、そのことがファイルの保存を妨げます。</span><span class="sxs-lookup"><span data-stu-id="38516-187">The other stream remains open and prevents saving the file.</span></span>

```cs
StorageFolder testFolder = await StorageFolder.GetFolderFromPathAsync(@"C:\test");
StorageFile sourceFile = await testFolder.GetFileAsync("TestImage.jpg");
StorageFile destinationFile = await KnownFolders.CameraRoll.CreateFileAsync("MyTestImage.jpg");
using (var sourceStream = (await sourceFile.OpenReadAsync()).GetInputStreamAt(0))
{
    using (var destinationStream = (await destinationFile.OpenAsync(FileAccessMode.ReadWrite)).GetOutputStreamAt(0))
    {
        await RandomAccessStream.CopyAndCloseAsync(sourceStream, destinationStream);
    }
}
```

<span data-ttu-id="38516-188">ストリーム メソッドを正しく使ってメディア ライブラリにファイルを追加するには、以下の例のように、コード中で開いているストリームをすべて閉じてください。</span><span class="sxs-lookup"><span data-stu-id="38516-188">To use stream methods successfully to add a file to the media library, make sure to close all the streams that your code opens, as shown in the following example.</span></span>

```cs
StorageFolder testFolder = await StorageFolder.GetFolderFromPathAsync(@"C:\test");
StorageFile sourceFile = await testFolder.GetFileAsync("TestImage.jpg");
StorageFile destinationFile = await KnownFolders.CameraRoll.CreateFileAsync("MyTestImage.jpg");

using (var sourceStream = await sourceFile.OpenReadAsync())
{
    using (var sourceInputStream = sourceStream.GetInputStreamAt(0))
    {
        using (var destinationStream = await destinationFile.OpenAsync(FileAccessMode.ReadWrite))
        {
            using (var destinationOutputStream = destinationStream.GetOutputStreamAt(0))
            {
                await RandomAccessStream.CopyAndCloseAsync(sourceInputStream, destinationStream);
            }
        }
    }
}
```
