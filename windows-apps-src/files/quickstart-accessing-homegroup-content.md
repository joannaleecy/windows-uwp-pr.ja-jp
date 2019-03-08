---
ms.assetid: 12ECEA89-59D2-4BCE-B24C-5A4DD525E0C7
title: ホームグループ コンテンツへのアクセス
description: ユーザーのホームグループ フォルダーに格納されているコンテンツ (画像、音楽、ビデオなど) にアクセスします。
ms.date: 12/19/2018
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 06c42cff51852f7d0456d533af60455d7d1b9caf
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57613897"
---
# <a name="accessing-homegroup-content"></a><span data-ttu-id="3a8fe-104">ホームグループ コンテンツへのアクセス</span><span class="sxs-lookup"><span data-stu-id="3a8fe-104">Accessing HomeGroup content</span></span>



<span data-ttu-id="3a8fe-105">**重要な API**</span><span class="sxs-lookup"><span data-stu-id="3a8fe-105">**Important APIs**</span></span>

-   [<span data-ttu-id="3a8fe-106">**Windows.Storage.KnownFolders クラス**</span><span class="sxs-lookup"><span data-stu-id="3a8fe-106">**Windows.Storage.KnownFolders class**</span></span>](https://msdn.microsoft.com/library/windows/apps/br227151)

<span data-ttu-id="3a8fe-107">ユーザーのホームグループ フォルダーに格納されているコンテンツ (画像、音楽、ビデオなど) にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="3a8fe-107">Access content stored in the user's HomeGroup folder, including pictures, music, and videos.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="3a8fe-108">前提条件</span><span class="sxs-lookup"><span data-stu-id="3a8fe-108">Prerequisites</span></span>

-   <span data-ttu-id="3a8fe-109">**ユニバーサル Windows プラットフォーム (UWP) アプリの非同期プログラミングを理解します。**</span><span class="sxs-lookup"><span data-stu-id="3a8fe-109">**Understand async programming for Universal Windows Platform (UWP) apps**</span></span>

    <span data-ttu-id="3a8fe-110">C# や Visual Basic での非同期アプリの作成方法については、「[C# または Visual Basic での非同期 API の呼び出し](https://msdn.microsoft.com/library/windows/apps/mt187337)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3a8fe-110">You can learn how to write asynchronous apps in C# or Visual Basic, see [Call asynchronous APIs in C# or Visual Basic](https://msdn.microsoft.com/library/windows/apps/mt187337).</span></span> <span data-ttu-id="3a8fe-111">C++ での非同期アプリの作成方法については、「[C++ での非同期プログラミング](https://msdn.microsoft.com/library/windows/apps/mt187334)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3a8fe-111">To learn how to write asynchronous apps in C++, see [Asynchronous programming in C++](https://msdn.microsoft.com/library/windows/apps/mt187334).</span></span>

-   <span data-ttu-id="3a8fe-112">**アプリの capabilty 宣言**</span><span class="sxs-lookup"><span data-stu-id="3a8fe-112">**App capabilty declarations**</span></span>

    <span data-ttu-id="3a8fe-113">ホームグループ コンテンツにアクセスするには、ユーザーのコンピューターにホームグループがセットアップされ、アプリに **picturesLibrary**、**musicLibrary**、**videosLibrary** のうちの少なくとも 1 つの機能が備わっている必要があります。</span><span class="sxs-lookup"><span data-stu-id="3a8fe-113">To access HomeGroup content, the user's machine must have a HomeGroup set up and your app must have at least one of the following capabilities: **picturesLibrary**, **musicLibrary**, or **videosLibrary**.</span></span> <span data-ttu-id="3a8fe-114">アプリは、ホームグループ フォルダーにアクセスすると、アプリのマニフェストで宣言されている機能に対応するライブラリだけを参照します。</span><span class="sxs-lookup"><span data-stu-id="3a8fe-114">When your app accesses the HomeGroup folder, it will see only the libraries that correspond to the capabilities declared in your app's manifest.</span></span> <span data-ttu-id="3a8fe-115">詳しくは、「[ファイル アクセス許可](file-access-permissions.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3a8fe-115">To learn more, see [File access permissions](file-access-permissions.md).</span></span>

    > [!NOTE]
    ><span data-ttu-id="3a8fe-116"> ホーム グループのドキュメント ライブラリ内のコンテンツは、アプリのマニフェストで宣言されている機能に関係なく、ユーザーの共有設定に関係なく、アプリに表示されません。</span><span class="sxs-lookup"><span data-stu-id="3a8fe-116"> Content in the Documents library of a HomeGroup isn't visible to your app regardless of the capabilities declared in your app's manifest and regardless of the user's sharing settings.</span></span>     

-   <span data-ttu-id="3a8fe-117">**ファイル ピッカーを使用する方法を理解します。**</span><span class="sxs-lookup"><span data-stu-id="3a8fe-117">**Understand how to use file pickers**</span></span>

    <span data-ttu-id="3a8fe-118">ホームグループのファイルやフォルダーにアクセスするには、通常、ファイル ピッカーを使います。</span><span class="sxs-lookup"><span data-stu-id="3a8fe-118">You typically use the file picker to access files and folders in the HomeGroup.</span></span> <span data-ttu-id="3a8fe-119">ファイル ピッカーの使い方については、「[ピッカーでファイルやフォルダーを開く](quickstart-using-file-and-folder-pickers.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3a8fe-119">To learn how to use the file picker, see [Open files and folders with a picker](quickstart-using-file-and-folder-pickers.md).</span></span>

-   <span data-ttu-id="3a8fe-120">**ファイルとフォルダーのクエリを理解します。**</span><span class="sxs-lookup"><span data-stu-id="3a8fe-120">**Understand file and folder queries**</span></span>

    <span data-ttu-id="3a8fe-121">ホームグループのファイルやフォルダーを列挙するには、クエリを使うことができます。</span><span class="sxs-lookup"><span data-stu-id="3a8fe-121">You can use queries to enumerate files and folders in the HomeGroup.</span></span> <span data-ttu-id="3a8fe-122">ファイルとフォルダーのクエリについて詳しくは、「[ファイルとフォルダーの列挙と照会](quickstart-listing-files-and-folders.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3a8fe-122">To learn about file and folder queries, see [Enumerating and querying files and folders](quickstart-listing-files-and-folders.md).</span></span>

## <a name="open-the-file-picker-at-the-homegroup"></a><span data-ttu-id="3a8fe-123">ホームグループでファイル ピッカーを開く</span><span class="sxs-lookup"><span data-stu-id="3a8fe-123">Open the file picker at the HomeGroup</span></span>

<span data-ttu-id="3a8fe-124">以下の手順に従って、ユーザーがホームグループのファイルとフォルダーを選ぶことができるファイル ピッカーのインスタンスを開きます。</span><span class="sxs-lookup"><span data-stu-id="3a8fe-124">Follow these steps to open an instance of the file picker that lets the user pick files and folders from the HomeGroup:</span></span>

1.  <span data-ttu-id="3a8fe-125">**作成し、ファイル ピッカーをカスタマイズします。**</span><span class="sxs-lookup"><span data-stu-id="3a8fe-125">**Create and customize the file picker**</span></span>

    <span data-ttu-id="3a8fe-126">[  **FileOpenPicker**](https://msdn.microsoft.com/library/windows/apps/br207847) を使ってファイル ピッカーを作成し、ピッカーの [**SuggestedStartLocation**](https://msdn.microsoft.com/library/windows/apps/br207854) を [**PickerLocationId.HomeGroup**](https://msdn.microsoft.com/library/windows/apps/br207890) に設定します。</span><span class="sxs-lookup"><span data-stu-id="3a8fe-126">Use [**FileOpenPicker**](https://msdn.microsoft.com/library/windows/apps/br207847) to create the file picker, and then set the picker's [**SuggestedStartLocation**](https://msdn.microsoft.com/library/windows/apps/br207854) to [**PickerLocationId.HomeGroup**](https://msdn.microsoft.com/library/windows/apps/br207890).</span></span> <span data-ttu-id="3a8fe-127">または、ユーザーとアプリに関連するその他のプロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="3a8fe-127">Or, set other properties that are relevant to your users and your app.</span></span> <span data-ttu-id="3a8fe-128">ファイル ピッカーのカスタマイズ方法を判断するためのガイドラインについては、「[ファイル ピッカーのガイドラインとチェック リスト](https://msdn.microsoft.com/library/windows/apps/hh465182)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3a8fe-128">For guidelines to help you decide how to customize the file picker, see [Guidelines and checklist for file pickers](https://msdn.microsoft.com/library/windows/apps/hh465182)</span></span>

    <span data-ttu-id="3a8fe-129">次の例では、ホームグループで開かれ、すべての種類のファイルを含み、ファイルをサムネイル画像として表示するファイル ピッカーを作成しています。</span><span class="sxs-lookup"><span data-stu-id="3a8fe-129">This example creates a file picker that opens at the HomeGroup, includes files of any type, and displays the files as thumbnail images:</span></span>
    ```cs
    Windows.Storage.Pickers.FileOpenPicker picker = new Windows.Storage.Pickers.FileOpenPicker();
    picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
    picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.HomeGroup;
    picker.FileTypeFilter.Clear();
    picker.FileTypeFilter.Add("*");
    ```

2.  <span data-ttu-id="3a8fe-130">**ファイル ピッカーを表示し、選択されたファイルを処理します。**</span><span class="sxs-lookup"><span data-stu-id="3a8fe-130">**Show the file picker and process the picked file.**</span></span>

    <span data-ttu-id="3a8fe-131">ファイル ピッカーを作成してカスタマイズしたら、ユーザーが 1 つのファイルを選べるように [**FileOpenPicker.PickSingleFileAsync**](https://msdn.microsoft.com/library/windows/apps/jj635275) を呼び出すか、複数のファイルを選べるように [**FileOpenPicker.PickMultipleFilesAsync**](https://msdn.microsoft.com/library/windows/apps/br207851) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="3a8fe-131">After you create and customize the file picker, let the user pick one file by calling [**FileOpenPicker.PickSingleFileAsync**](https://msdn.microsoft.com/library/windows/apps/jj635275), or multiple files by calling [**FileOpenPicker.PickMultipleFilesAsync**](https://msdn.microsoft.com/library/windows/apps/br207851).</span></span>

    <span data-ttu-id="3a8fe-132">次の例では、ファイル ピッカーを表示して、ユーザーが 1 つのファイルを選べるようにしています。</span><span class="sxs-lookup"><span data-stu-id="3a8fe-132">This example displays the file picker to let the user pick one file:</span></span>
    ```cs
    Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();

    if (file != null)
    {
        // Do something with the file.
    }
    else
    {
        // No file returned. Handle the error.
    }   
    ```

## <a name="search-the-homegroup-for-files"></a><span data-ttu-id="3a8fe-133">ホームグループでファイルを検索する</span><span class="sxs-lookup"><span data-stu-id="3a8fe-133">Search the HomeGroup for files</span></span>

<span data-ttu-id="3a8fe-134">このセクションでは、ユーザーが指定したクエリ語句に一致するホームグループ項目を見つける方法を示します。</span><span class="sxs-lookup"><span data-stu-id="3a8fe-134">This section shows how to find HomeGroup items that match a query term provided by the user.</span></span>

1.  <span data-ttu-id="3a8fe-135">**ユーザーから、クエリ用語を取得します。**</span><span class="sxs-lookup"><span data-stu-id="3a8fe-135">**Get the query term from the user.**</span></span>

    <span data-ttu-id="3a8fe-136">ここでは、ユーザーが `searchQueryTextBox` という名前の [**TextBox**](https://msdn.microsoft.com/library/windows/apps/br209683) コントロールに入力したクエリ語句を取得します。</span><span class="sxs-lookup"><span data-stu-id="3a8fe-136">Here we get a query term that the user has entered into a [**TextBox**](https://msdn.microsoft.com/library/windows/apps/br209683) control called `searchQueryTextBox`:</span></span>
    ```cs
    string queryTerm = this.searchQueryTextBox.Text;    
    ```

2.  <span data-ttu-id="3a8fe-137">**検索フィルター クエリ オプションを設定します。**</span><span class="sxs-lookup"><span data-stu-id="3a8fe-137">**Set the query options and search filter.**</span></span>

    <span data-ttu-id="3a8fe-138">クエリ オプションは、検索結果をどのように並べ替えるかを決めます。検索フィルターは、どの項目が検索結果に含まれるかを決めます。</span><span class="sxs-lookup"><span data-stu-id="3a8fe-138">Query options determine how the search results are sorted, while the search filter determines which items are included in the search results.</span></span>

    <span data-ttu-id="3a8fe-139">次の例は、検索結果をまず関連性で、次に更新日で並べ替えるクエリ オプションを設定します。</span><span class="sxs-lookup"><span data-stu-id="3a8fe-139">This example sets query options that sort the search results by relevance and then the date modified.</span></span> <span data-ttu-id="3a8fe-140">検索フィルターは、ユーザーが前の手順で入力したクエリ語句です。</span><span class="sxs-lookup"><span data-stu-id="3a8fe-140">The search filter is the query term that the user entered in the previous step:</span></span>
    ```cs
    Windows.Storage.Search.QueryOptions queryOptions =
            new Windows.Storage.Search.QueryOptions
                (Windows.Storage.Search.CommonFileQuery.OrderBySearchRank, null);
    queryOptions.UserSearchFilter = queryTerm.Text;
    Windows.Storage.Search.StorageFileQueryResult queryResults =
            Windows.Storage.KnownFolders.HomeGroup.CreateFileQueryWithOptions(queryOptions);    
    ```

3.  <span data-ttu-id="3a8fe-141">**クエリを実行し、結果を処理します。**</span><span class="sxs-lookup"><span data-stu-id="3a8fe-141">**Run the query and process the results.**</span></span>

    <span data-ttu-id="3a8fe-142">次の例は、ホームグループで検索クエリを実行し、一致するファイルの名前を文字列の一覧として保存します。</span><span class="sxs-lookup"><span data-stu-id="3a8fe-142">The following example runs the search query in the HomeGroup and saves the names of any matching files as a list of strings.</span></span>
    ```cs
    System.Collections.Generic.IReadOnlyList<Windows.Storage.StorageFile> files =
        await queryResults.GetFilesAsync();

    if (files.Count > 0)
    {
        outputString += (files.Count == 1) ? "One file found\n" : files.Count.ToString() + " files found\n";
        foreach (Windows.Storage.StorageFile file in files)
        {
            outputString += file.Name + "\n";
        }
    }    
    ```


## <a name="search-the-homegroup-for-a-particular-users-shared-files"></a><span data-ttu-id="3a8fe-143">ホームグループで特定のユーザーの共有ファイルを検索する</span><span class="sxs-lookup"><span data-stu-id="3a8fe-143">Search the HomeGroup for a particular user's shared files</span></span>

<span data-ttu-id="3a8fe-144">このセクションでは、特定のユーザーによって共有されているホームグループ ファイルを見つける方法を示します。</span><span class="sxs-lookup"><span data-stu-id="3a8fe-144">This section shows you how to find HomeGroup files that are shared by a particular user.</span></span>

1.  <span data-ttu-id="3a8fe-145">**ホーム グループのユーザーのコレクションを取得します。**</span><span class="sxs-lookup"><span data-stu-id="3a8fe-145">**Get a collection of HomeGroup users.**</span></span>

    <span data-ttu-id="3a8fe-146">ホームグループの第 1 レベルのフォルダーは、それぞれが個々のホームグループ ユーザーを表しています。</span><span class="sxs-lookup"><span data-stu-id="3a8fe-146">Each of the first-level folders in the HomeGroup represents an individual HomeGroup user.</span></span> <span data-ttu-id="3a8fe-147">そのため、ホームグループ ユーザーのコレクションを取得するには、[**GetFoldersAsync**](https://msdn.microsoft.com/library/windows/apps/br227279) を呼び出し、第 1 レベルのホームグループ フォルダーを取得します。</span><span class="sxs-lookup"><span data-stu-id="3a8fe-147">So, to get the collection of HomeGroup users, call [**GetFoldersAsync**](https://msdn.microsoft.com/library/windows/apps/br227279) retrieve the top-level HomeGroup folders.</span></span>
    ```cs
    System.Collections.Generic.IReadOnlyList<Windows.Storage.StorageFolder> hgFolders =
        await Windows.Storage.KnownFolders.HomeGroup.GetFoldersAsync();    
    ```

2.  <span data-ttu-id="3a8fe-148">**ターゲット ユーザーのフォルダーを見つけて、そのユーザーのフォルダーにスコープ設定ファイルのクエリを作成します。**</span><span class="sxs-lookup"><span data-stu-id="3a8fe-148">**Find the target user's folder, and then create a file query scoped to that user's folder.**</span></span>

    <span data-ttu-id="3a8fe-149">次の例は、取得したフォルダーを反復処理して、目的のユーザーのフォルダーを見つけます。</span><span class="sxs-lookup"><span data-stu-id="3a8fe-149">The following example iterates through the retrieved folders to find the target user's folder.</span></span> <span data-ttu-id="3a8fe-150">次に、クエリ オプションを設定して、フォルダー内のすべてのファイルを検索し、まずは関連性で、次に更新日で並べ替えます。</span><span class="sxs-lookup"><span data-stu-id="3a8fe-150">Then, it sets query options to find all files in the folder, sorted first by relevance and then by the date modified.</span></span> <span data-ttu-id="3a8fe-151">この例では、見つかったファイルの数とファイルの名前を報告する文字列を作成します。</span><span class="sxs-lookup"><span data-stu-id="3a8fe-151">The example builds a string that reports the number of files found, along with the names of the files.</span></span>
    ```cs
    bool userFound = false;
    foreach (Windows.Storage.StorageFolder folder in hgFolders)
    {
        if (folder.DisplayName == targetUserName)
        {
            // Found the target user's folder, now find all files in the folder.
            userFound = true;
            Windows.Storage.Search.QueryOptions queryOptions =
                new Windows.Storage.Search.QueryOptions
                    (Windows.Storage.Search.CommonFileQuery.OrderBySearchRank, null);
            queryOptions.UserSearchFilter = "*";
            Windows.Storage.Search.StorageFileQueryResult queryResults =
                folder.CreateFileQueryWithOptions(queryOptions);
            System.Collections.Generic.IReadOnlyList<Windows.Storage.StorageFile> files =
                await queryResults.GetFilesAsync();

            if (files.Count > 0)
            {
                string outputString = "Searched for files belonging to " + targetUserName + "'\n";
                outputString += (files.Count == 1) ? "One file found\n" : files.Count.ToString() + " files found\n";
                foreach (Windows.Storage.StorageFile file in files)
                {
                    outputString += file.Name + "\n";
                }
            }
        }
    }    
    ```

## <a name="stream-video-from-the-homegroup"></a><span data-ttu-id="3a8fe-152">ホームグループからビデオをストリーミングする</span><span class="sxs-lookup"><span data-stu-id="3a8fe-152">Stream video from the HomeGroup</span></span>

<span data-ttu-id="3a8fe-153">ホームグループからビデオ コンテンツをストリーミングするには、次の手順を実行します。</span><span class="sxs-lookup"><span data-stu-id="3a8fe-153">Follow these steps to stream video content from the HomeGroup:</span></span>

1.  <span data-ttu-id="3a8fe-154">**アプリ内に MediaElement を含めます。**</span><span class="sxs-lookup"><span data-stu-id="3a8fe-154">**Include a MediaElement in your app.**</span></span>

    <span data-ttu-id="3a8fe-155">[  **MediaElement**](https://msdn.microsoft.com/library/windows/apps/br242926) は、アプリのオーディオ コンテンツとビデオ コンテンツを再生します。</span><span class="sxs-lookup"><span data-stu-id="3a8fe-155">A [**MediaElement**](https://msdn.microsoft.com/library/windows/apps/br242926) lets you play back audio and video content in your app.</span></span> <span data-ttu-id="3a8fe-156">オーディオとビデオの再生について詳しくは、「[カスタム トランスポート コントロールを作成する](https://msdn.microsoft.com/library/windows/apps/mt187271)」と「[オーディオ、ビデオ、およびカメラ](https://msdn.microsoft.com/library/windows/apps/mt203788)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3a8fe-156">For more information on audio and video playback, see [Create custom transport controls](https://msdn.microsoft.com/library/windows/apps/mt187271) and [Audio, video, and camera](https://msdn.microsoft.com/library/windows/apps/mt203788).</span></span>
    ```HTML
    <Grid x:Name="Output" HorizontalAlignment="Left" VerticalAlignment="Top" Grid.Row="1">
        <MediaElement x:Name="VideoBox" HorizontalAlignment="Left" VerticalAlignment="Top" Margin="0" Width="400" Height="300"/>
    </Grid>    
    ```

2.  <span data-ttu-id="3a8fe-157">**ホーム グループにファイル ピッカーを開き、アプリでサポートされる形式でビデオ ファイルを含むフィルターを適用します。**</span><span class="sxs-lookup"><span data-stu-id="3a8fe-157">**Open a file picker at the HomeGroup and apply a filter that includes video files in the formats that your app supports.**</span></span>

    <span data-ttu-id="3a8fe-158">次の例では、ファイル オープン ピッカーに .mp4 ファイルと .wmv ファイルが含まれます。</span><span class="sxs-lookup"><span data-stu-id="3a8fe-158">This example includes .mp4 and .wmv files in the file open picker.</span></span>
    ```cs
    Windows.Storage.Pickers.FileOpenPicker picker = new Windows.Storage.Pickers.FileOpenPicker();
    picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
    picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.HomeGroup;
    picker.FileTypeFilter.Clear();
    picker.FileTypeFilter.Add(".mp4");
    picker.FileTypeFilter.Add(".wmv");
    Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();   
    ```

3.  <span data-ttu-id="3a8fe-159">**読み取りアクセス権をユーザーのファイルの選択を開いてのソースとしてファイル ストリームを設定して、** [ **MediaElement**](https://msdn.microsoft.com/library/windows/apps/br242926)、し、ファイルを再生します。</span><span class="sxs-lookup"><span data-stu-id="3a8fe-159">**Open the user's file selection for read access, and set the file stream as the source for the** [**MediaElement**](https://msdn.microsoft.com/library/windows/apps/br242926), and then play the file.</span></span>
    ```cs
    if (file != null)
    {
        var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
        VideoBox.SetSource(stream, file.ContentType);
        VideoBox.Stop();
        VideoBox.Play();
    }
    else
    {
        // No file selected. Handle the error here.
    }    
    ```
