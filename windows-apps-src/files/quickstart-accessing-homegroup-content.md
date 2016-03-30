---
xx.xxxxxxx: YYXXXXYY-YYXY-YXXX-XYYX-YXYXXYYYXYXY
xxxxx: Xxxxxxxxx XxxxXxxxx xxxxxxx
xxxxxxxxxxx: Xxxxxx xxxxxxx xxxxxx xx xxx xxxx'x XxxxXxxxx xxxxxx, xxxxxxxxx xxxxxxxx, xxxxx, xxx xxxxxx.
---
# Xxxxxxxxx XxxxXxxxx xxxxxxx

\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


** Xxxxxxxxx XXXx **

-   [**Xxxxxxx.Xxxxxxx.XxxxxXxxxxxx xxxxx**](https://msdn.microsoft.com/library/windows/apps/br227151)

Xxxxxx xxxxxxx xxxxxx xx xxx xxxx'x XxxxXxxxx xxxxxx, xxxxxxxxx xxxxxxxx, xxxxx, xxx xxxxxx.

## Xxxxxxxxxxxxx

-   **Xxxxxxxxxx xxxxx xxxxxxxxxxx xxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx**

    Xxx xxx xxxxx xxx xx xxxxx xxxxxxxxxxxx xxxx xx X# xx Xxxxxx Xxxxx, xxx [Xxxx xxxxxxxxxxxx XXXx xx X# xx Xxxxxx Xxxxx](https://msdn.microsoft.com/library/windows/apps/mt187337). Xx xxxxx xxx xx xxxxx xxxxxxxxxxxx xxxx xx X++, xxx [Xxxxxxxxxxxx xxxxxxxxxxx xx X++](https://msdn.microsoft.com/library/windows/apps/mt187334).

-   **Xxx xxxxxxxxx xxxxxxxxxxxx**

    Xx xxxxxx XxxxXxxxx xxxxxxx, xxx xxxx'x xxxxxxx xxxx xxxx x XxxxXxxxx xxx xx xxx xxxx xxx xxxx xxxx xx xxxxx xxx xx xxx xxxxxxxxx xxxxxxxxxxxx: **xxxxxxxxXxxxxxx**, **xxxxxXxxxxxx**, xx **xxxxxxXxxxxxx**. Xxxx xxxx xxx xxxxxxxx xxx XxxxXxxxx xxxxxx, xx xxxx xxx xxxx xxx xxxxxxxxx xxxx xxxxxxxxxx xx xxx xxxxxxxxxxxx xxxxxxxx xx xxxx xxx'x xxxxxxxx. Xx xxxxx xxxx, xxx [Xxxx xxxxxx xxxxxxxxxxx](file-access-permissions.md).

    **Xxxx**  Xxxxxxx xx xxx Xxxxxxxxx xxxxxxx xx x XxxxXxxxx xxx'x xxxxxxx xx xxxx xxx xxxxxxxxxx xx xxx xxxxxxxxxxxx xxxxxxxx xx xxxx xxx'x xxxxxxxx xxx xxxxxxxxxx xx xxx xxxx'x xxxxxxx xxxxxxxx.

     

-   **Xxxxxxxxxx xxx xx xxx xxxx xxxxxxx**

    Xxx xxxxxxxxx xxx xxx xxxx xxxxxx xx xxxxxx xxxxx xxx xxxxxxx xx xxx XxxxXxxxx. Xx xxxxx xxx xx xxx xxx xxxx xxxxxx, xxx [Xxxx xxxxx xxx xxxxxxx xxxx x xxxxxx](quickstart-using-file-and-folder-pickers.md).

-   **Xxxxxxxxxx xxxx xxx xxxxxx xxxxxxx**

    Xxx xxx xxx xxxxxxx xx xxxxxxxxx xxxxx xxx xxxxxxx xx xxx XxxxXxxxx. Xx xxxxx xxxxx xxxx xxx xxxxxx xxxxxxx, xxx [Xxxxxxxxxxx xxx xxxxxxxx xxxxx xxx xxxxxxx](quickstart-listing-files-and-folders.md).

## Xxxx xxx xxxx xxxxxx xx xxx XxxxXxxxx

Xxxxxx xxxxx xxxxx xx xxxx xx xxxxxxxx xx xxx xxxx xxxxxx xxxx xxxx xxx xxxx xxxx xxxxx xxx xxxxxxx xxxx xxx XxxxXxxxx:

1.  **Xxxxxx xxx xxxxxxxxx xxx xxxx xxxxxx**

    Xxx [**XxxxXxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br207847) xx xxxxxx xxx xxxx xxxxxx, xxx xxxx xxx xxx xxxxxx'x [**XxxxxxxxxXxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br207854) xx [**XxxxxxXxxxxxxxXx.XxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br207890). Xx, xxx xxxxx xxxxxxxxxx xxxx xxx xxxxxxxx xx xxxx xxxxx xxx xxxx xxx. Xxx xxxxxxxxxx xx xxxx xxx xxxxxx xxx xx xxxxxxxxx xxx xxxx xxxxxx, xxx [Xxxxxxxxxx xxx xxxxxxxxx xxx xxxx xxxxxxx](https://msdn.microsoft.com/library/windows/apps/hh465182)

    Xxxx xxxxxxx xxxxxxx x xxxx xxxxxx xxxx xxxxx xx xxx XxxxXxxxx, xxxxxxxx xxxxx xx xxx xxxx, xxx xxxxxxxx xxx xxxxx xx xxxxxxxxx xxxxxx:
    ```csharp
    Windows.Storage.Pickers.FileOpenPicker picker = new Windows.Storage.Pickers.FileOpenPicker();
    picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
    picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.HomeGroup;
    picker.FileTypeFilter.Clear();
    picker.FileTypeFilter.Add("*");
    ```
  
2.  **Xxxx xxx xxxx xxxxxx xxx xxxxxxx xxx xxxxxx xxxx.**

    Xxxxx xxx xxxxxx xxx xxxxxxxxx xxx xxxx xxxxxx, xxx xxx xxxx xxxx xxx xxxx xx xxxxxxx [**XxxxXxxxXxxxxx.XxxxXxxxxxXxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/jj635275), xx xxxxxxxx xxxxx xx xxxxxxx [**XxxxXxxxXxxxxx.XxxxXxxxxxxxXxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br207851).

    Xxxx xxxxxxx xxxxxxxx xxx xxxx xxxxxx xx xxx xxx xxxx xxxx xxx xxxx:
    ```csharp
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

## Xxxxxx xxx XxxxXxxxx xxx xxxxx

Xxxx xxxxxxx xxxxx xxx xx xxxx XxxxXxxxx xxxxx xxxx xxxxx x xxxxx xxxx xxxxxxxx xx xxx xxxx.

1.  **Xxx xxx xxxxx xxxx xxxx xxx xxxx.**

    Xxxx xx xxx x xxxxx xxxx xxxx xxx xxxx xxx xxxxxxx xxxx x [**XxxxXxx**](https://msdn.microsoft.com/library/windows/apps/br209683) xxxxxxx xxxxxx `searchQueryTextBox`:
    ```csharp
    string queryTerm = this.searchQueryTextBox.Text;    
    ```

2.  **Xxx xxx xxxxx xxxxxxx xxx xxxxxx xxxxxx.**

    Xxxxx xxxxxxx xxxxxxxxx xxx xxx xxxxxx xxxxxxx xxx xxxxxx, xxxxx xxx xxxxxx xxxxxx xxxxxxxxxx xxxxx xxxxx xxx xxxxxxxx xx xxx xxxxxx xxxxxxx.

    Xxxx xxxxxxx xxxx xxxxx xxxxxxx xxxx xxxx xxx xxxxxx xxxxxxx xx xxxxxxxxx xxx xxxx xxx xxxx xxxxxxxx. Xxx xxxxxx xxxxxx xx xxx xxxxx xxxx xxxx xxx xxxx xxxxxxx xx xxx xxxxxxxx xxxx:
    ```csharp
    Windows.Storage.Search.QueryOptions queryOptions = 
            new Windows.Storage.Search.QueryOptions
                (Windows.Storage.Search.CommonFileQuery.OrderBySearchRank, null);
    queryOptions.UserSearchFilter = queryTerm.Text;
    Windows.Storage.Search.StorageFileQueryResult queryResults = 
            Windows.Storage.KnownFolders.HomeGroup.CreateFileQueryWithOptions(queryOptions);    
    ```

3.  **Xxx xxx xxxxx xxx xxxxxxx xxx xxxxxxx.**

    Xxx xxxxxxxxx xxxxxxx xxxx xxx xxxxxx xxxxx xx xxx XxxxXxxxx xxx xxxxx xxx xxxxx xx xxx xxxxxxxx xxxxx xx x xxxx xx xxxxxxx.
    ```csharp
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


## Xxxxxx xxx XxxxXxxxx xxx x xxxxxxxxxx xxxx'x xxxxxx xxxxx

Xxxx xxxxxxx xxxxx xxx xxx xx xxxx XxxxXxxxx xxxxx xxxx xxx xxxxxx xx x xxxxxxxxxx xxxx.

1.  **Xxx x xxxxxxxxxx xx XxxxXxxxx xxxxx.**

    Xxxx xx xxx xxxxx-xxxxx xxxxxxx xx xxx XxxxXxxxx xxxxxxxxxx xx xxxxxxxxxx XxxxXxxxx xxxx. Xx, xx xxx xxx xxxxxxxxxx xx XxxxXxxxx xxxxx, xxxx [**XxxXxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br227279) xxxxxxxx xxx xxx-xxxxx XxxxXxxxx xxxxxxx.
    ```csharp
    System.Collections.Generic.IReadOnlyList<Windows.Storage.StorageFolder> hgFolders = 
        await Windows.Storage.KnownFolders.HomeGroup.GetFoldersAsync();    
    ```

2.  **Xxxx xxx xxxxxx xxxx'x xxxxxx, xxx xxxx xxxxxx x xxxx xxxxx xxxxxx xx xxxx xxxx'x xxxxxx.**

    Xxx xxxxxxxxx xxxxxxx xxxxxxxx xxxxxxx xxx xxxxxxxxx xxxxxxx xx xxxx xxx xxxxxx xxxx'x xxxxxx. Xxxx, xx xxxx xxxxx xxxxxxx xx xxxx xxx xxxxx xx xxx xxxxxx, xxxxxx xxxxx xx xxxxxxxxx xxx xxxx xx xxx xxxx xxxxxxxx. Xxx xxxxxxx xxxxxx x xxxxxx xxxx xxxxxxx xxx xxxxxx xx xxxxx xxxxx, xxxxx xxxx xxx xxxxx xx xxx xxxxx.
    ```csharp
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

## Xxxxxx xxxxx xxxx xxx XxxxXxxxx

Xxxxxx xxxxx xxxxx xx xxxxxx xxxxx xxxxxxx xxxx xxx XxxxXxxxx:

1.  **Xxxxxxx x XxxxxXxxxxxx xx xxxx xxx.**

    X [**XxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br242926) xxxx xxx xxxx xxxx xxxxx xxx xxxxx xxxxxxx xx xxxx xxx. Xxx xxxx xxxxxxxxxxx xx xxxxx xxx xxxxx xxxxxxxx, xxx [Xxxxxx xxxxxx xxxxxxxxx xxxxxxxx](https://msdn.microsoft.com/library/windows/apps/mt187271) xxx [Xxxxx, xxxxx, xxx xxxxxx](https://msdn.microsoft.com/library/windows/apps/mt203788).
    ```HTML
    <Grid x:Name="Output" HorizontalAlignment="Left" VerticalAlignment="Top" Grid.Row="1">
        <MediaElement x:Name="VideoBox" HorizontalAlignment="Left" VerticalAlignment="Top" Margin="0" Width="400" Height="300"/>
    </Grid>    
    ```

2.  **Xxxx x xxxx xxxxxx xx xxx XxxxXxxxx xxx xxxxx x xxxxxx xxxx xxxxxxxx xxxxx xxxxx xx xxx xxxxxxx xxxx xxxx xxx xxxxxxxx.**

    Xxxx xxxxxxx xxxxxxxx .xxY xxx .xxx xxxxx xx xxx xxxx xxxx xxxxxx.
    ```csharp
    Windows.Storage.Pickers.FileOpenPicker picker = new Windows.Storage.Pickers.FileOpenPicker();
    picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
    picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.HomeGroup;
    picker.FileTypeFilter.Clear();
    picker.FileTypeFilter.Add(".mp4");
    picker.FileTypeFilter.Add(".wmv");
    Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();   
    ```

3.  **Xxxx xxx xxx xxxx'x xxxx xxxxxxxxx xxx xxxx xxxxxx, xxx xxx xxx xxxx xxxxxx xx xxx xxxxxx xxx xxx**[**XxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br242926), xxx xxxx xxxx xxx xxxx.
    ```csharp
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

 

 




<!--HONumber=Mar16_HO1-->
