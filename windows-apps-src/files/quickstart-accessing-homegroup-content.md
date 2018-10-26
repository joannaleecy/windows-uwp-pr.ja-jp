---
author: laurenhughes
ms.assetid: 12ECEA89-59D2-4BCE-B24C-5A4DD525E0C7
title: ホームグループ コンテンツへのアクセス
description: ユーザーのホームグループ フォルダーに格納されているコンテンツ (画像、音楽、ビデオなど) にアクセスします。
ms.author: lahugh
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 398c44db6a391008605ed6fa4dad877bcead035d
ms.sourcegitcommit: 6cc275f2151f78db40c11ace381ee2d35f0155f9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5562991"
---
# <a name="accessing-homegroup-content"></a>ホームグループ コンテンツへのアクセス



**重要な API**

-   [**Windows.Storage.KnownFolders クラス**](https://msdn.microsoft.com/library/windows/apps/br227151)

ユーザーのホームグループ フォルダーに格納されているコンテンツ (画像、音楽、ビデオなど) にアクセスします。

## <a name="prerequisites"></a>前提条件

-   **ユニバーサル Windows プラットフォーム (UWP) アプリの非同期プログラミングについての理解**

    C# や Visual Basic での非同期アプリの作成方法については、「[C# または Visual Basic での非同期 API の呼び出し](https://msdn.microsoft.com/library/windows/apps/mt187337)」をご覧ください。 C++ での非同期アプリの作成方法については、「[C++ での非同期プログラミング](https://msdn.microsoft.com/library/windows/apps/mt187334)」をご覧ください。

-   **アプリ機能の宣言**

    ホームグループ コンテンツにアクセスするには、ユーザーのコンピューターにホームグループがセットアップされ、アプリに **picturesLibrary**、**musicLibrary**、**videosLibrary** のうちの少なくとも 1 つの機能が備わっている必要があります。 アプリは、ホームグループ フォルダーにアクセスすると、アプリのマニフェストで宣言されている機能に対応するライブラリだけを参照します。 詳しくは、「[ファイル アクセス許可](file-access-permissions.md)」をご覧ください。

    > [!NOTE]
    >  ホームグループのドキュメント ライブラリのコンテンツは、アプリのマニフェストで宣言されている機能や、ユーザーの共有設定にかかわらず、アプリからは参照できません。     

-   **ファイル ピッカーの使い方についての理解**

    ホームグループのファイルやフォルダーにアクセスするには、通常、ファイル ピッカーを使います。 ファイル ピッカーの使い方については、「[ピッカーでファイルやフォルダーを開く](quickstart-using-file-and-folder-pickers.md)」をご覧ください。

-   **ファイルとフォルダーのクエリについての理解**

    ホームグループのファイルやフォルダーを列挙するには、クエリを使うことができます。 ファイルとフォルダーのクエリについて詳しくは、「[ファイルとフォルダーの列挙と照会](quickstart-listing-files-and-folders.md)」をご覧ください。

## <a name="open-the-file-picker-at-the-homegroup"></a>ホームグループでファイル ピッカーを開く

以下の手順に従って、ユーザーがホームグループのファイルとフォルダーを選ぶことができるファイル ピッカーのインスタンスを開きます。

1.  **ファイル ピッカーを作成してカスタマイズする**

    [**FileOpenPicker**](https://msdn.microsoft.com/library/windows/apps/br207847) を使ってファイル ピッカーを作成し、ピッカーの [**SuggestedStartLocation**](https://msdn.microsoft.com/library/windows/apps/br207854) を [**PickerLocationId.HomeGroup**](https://msdn.microsoft.com/library/windows/apps/br207890) に設定します。 または、ユーザーとアプリに関連するその他のプロパティを設定します。 ファイル ピッカーのカスタマイズ方法を判断するためのガイドラインについては、「[ファイル ピッカーのガイドラインとチェック リスト](https://msdn.microsoft.com/library/windows/apps/hh465182)」をご覧ください。

    次の例では、ホームグループで開かれ、すべての種類のファイルを含み、ファイルをサムネイル イメージとして表示するファイル ピッカーを作成しています。
    ```cs
    Windows.Storage.Pickers.FileOpenPicker picker = new Windows.Storage.Pickers.FileOpenPicker();
    picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
    picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.HomeGroup;
    picker.FileTypeFilter.Clear();
    picker.FileTypeFilter.Add("*");
    ```

2.  **ファイル ピッカーを表示して、選ばれたファイルを処理する**

    ファイル ピッカーを作成してカスタマイズしたら、ユーザーが 1 つのファイルを選べるように [**FileOpenPicker.PickSingleFileAsync**](https://msdn.microsoft.com/library/windows/apps/jj635275) を呼び出すか、複数のファイルを選べるように [**FileOpenPicker.PickMultipleFilesAsync**](https://msdn.microsoft.com/library/windows/apps/br207851) を呼び出します。

    次の例では、ファイル ピッカーを表示して、ユーザーが 1 つのファイルを選べるようにしています。
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

## <a name="search-the-homegroup-for-files"></a>ホームグループでファイルを検索する

このセクションでは、ユーザーが指定したクエリ語句に一致するホームグループ項目を見つける方法を示します。

1.  **ユーザーからクエリ語句を取得します。**

    ここでは、ユーザーが `searchQueryTextBox` という名前の [**TextBox**](https://msdn.microsoft.com/library/windows/apps/br209683) コントロールに入力したクエリ語句を取得します。
    ```cs
    string queryTerm = this.searchQueryTextBox.Text;    
    ```

2.  **クエリ オプションと検索フィルターを設定します。**

    クエリ オプションは、検索結果をどのように並べ替えるかを決めます。検索フィルターは、どの項目が検索結果に含まれるかを決めます。

    次の例は、検索結果をまず関連性で、次に更新日で並べ替えるクエリ オプションを設定します。 検索フィルターは、ユーザーが前の手順で入力したクエリ語句です。
    ```cs
    Windows.Storage.Search.QueryOptions queryOptions =
            new Windows.Storage.Search.QueryOptions
                (Windows.Storage.Search.CommonFileQuery.OrderBySearchRank, null);
    queryOptions.UserSearchFilter = queryTerm.Text;
    Windows.Storage.Search.StorageFileQueryResult queryResults =
            Windows.Storage.KnownFolders.HomeGroup.CreateFileQueryWithOptions(queryOptions);    
    ```

3.  **クエリを実行し、結果を処理します。**

    次の例は、ホームグループで検索クエリを実行し、一致するファイルの名前を文字列の一覧として保存します。
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


## <a name="search-the-homegroup-for-a-particular-users-shared-files"></a>ホームグループで特定のユーザーの共有ファイルを検索する

このセクションでは、特定のユーザーによって共有されているホームグループ ファイルを見つける方法を示します。

1.  **ホームグループ ユーザーのコレクションを取得します。**

    ホームグループの第 1 レベルのフォルダーは、それぞれが個々のホームグループ ユーザーを表しています。 そのため、ホームグループ ユーザーのコレクションを取得するには、[**GetFoldersAsync**](https://msdn.microsoft.com/library/windows/apps/br227279) を呼び出し、第 1 レベルのホームグループ フォルダーを取得します。
    ```cs
    System.Collections.Generic.IReadOnlyList<Windows.Storage.StorageFolder> hgFolders =
        await Windows.Storage.KnownFolders.HomeGroup.GetFoldersAsync();    
    ```

2.  **目的のユーザーのフォルダーを見つけ、そのユーザーのフォルダーをスコープにしたファイル クエリを作成します。**

    次の例は、取得したフォルダーを反復処理して、目的のユーザーのフォルダーを見つけます。 次に、クエリ オプションを設定して、フォルダー内のすべてのファイルを検索し、まずは関連性で、次に更新日で並べ替えます。 この例では、見つかったファイルの数とファイルの名前を報告する文字列を作成します。
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

## <a name="stream-video-from-the-homegroup"></a>ホームグループからビデオをストリーミングする

ホームグループからビデオ コンテンツをストリーミングするには、次の手順を実行します。

1.  **アプリに MediaElement を含めます。**

    [**MediaElement**](https://msdn.microsoft.com/library/windows/apps/br242926) は、アプリのオーディオ コンテンツとビデオ コンテンツを再生します。 オーディオとビデオの再生について詳しくは、「[カスタム トランスポート コントロールを作成する](https://msdn.microsoft.com/library/windows/apps/mt187271)」と「[オーディオ、ビデオ、およびカメラ](https://msdn.microsoft.com/library/windows/apps/mt203788)」をご覧ください。
    ```HTML
    <Grid x:Name="Output" HorizontalAlignment="Left" VerticalAlignment="Top" Grid.Row="1">
        <MediaElement x:Name="VideoBox" HorizontalAlignment="Left" VerticalAlignment="Top" Margin="0" Width="400" Height="300"/>
    </Grid>    
    ```

2.  **ファイル ピッカーをホームグループで開き、アプリでサポートされている形式のビデオ ファイルを含めるフィルターを適用します。**

    次の例では、ファイル オープン ピッカーに .mp4 ファイルと .wmv ファイルが含まれます。
    ```cs
    Windows.Storage.Pickers.FileOpenPicker picker = new Windows.Storage.Pickers.FileOpenPicker();
    picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
    picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.HomeGroup;
    picker.FileTypeFilter.Clear();
    picker.FileTypeFilter.Add(".mp4");
    picker.FileTypeFilter.Add(".wmv");
    Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();   
    ```

3.  **、読み取りアクセスのユーザーのファイルの選択内容を開き、ファイル ストリームをソースとして設定、**[**MediaElement**](https://msdn.microsoft.com/library/windows/apps/br242926)、し、プレイ ファイル。
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
